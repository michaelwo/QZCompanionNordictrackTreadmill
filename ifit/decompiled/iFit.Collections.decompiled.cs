using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit Collection Extensions")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Collections")]
[assembly: AssemblyTitle("iFit.Collections")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Collections;

public static class Comparator
{
	public static List<Variance> DetailedCompare<T>(this T val1, T val2)
	{
		List<Variance> list = new List<Variance>();
		foreach (PropertyInfo declaredProperty in val1.GetType().GetTypeInfo().DeclaredProperties)
		{
			Variance variance = new Variance
			{
				Prop = declaredProperty.Name,
				ValA = declaredProperty.GetValue(val1),
				ValB = declaredProperty.GetValue(val2)
			};
			if (!variance.ValA.Equals(variance.ValB))
			{
				list.Add(variance);
			}
		}
		return list;
	}
}
public class Variance
{
	public string Prop { get; set; }

	public object ValA { get; set; }

	public object ValB { get; set; }
}
public class ConcurrentList<T> : List<T>, IDisposable
{
	private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

	private int _count;

	private T[] _arr;

	public new int Count
	{
		get
		{
			locker.EnterReadLock();
			try
			{
				return _count;
			}
			finally
			{
				locker.ExitReadLock();
			}
		}
	}

	public int InternalArrayLength
	{
		get
		{
			locker.EnterReadLock();
			try
			{
				return _arr.Length;
			}
			finally
			{
				locker.ExitReadLock();
			}
		}
	}

	public bool IsReadOnly => false;

	public new T this[int index]
	{
		get
		{
			locker.EnterReadLock();
			try
			{
				if (index >= _count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return _arr[index];
			}
			finally
			{
				locker.ExitReadLock();
			}
		}
		set
		{
			locker.EnterUpgradeableReadLock();
			try
			{
				if (index >= _count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				locker.EnterWriteLock();
				try
				{
					_arr[index] = value;
				}
				finally
				{
					locker.ExitWriteLock();
				}
			}
			finally
			{
				locker.ExitUpgradeableReadLock();
			}
		}
	}

	public ConcurrentList(int initialCapacity)
	{
		_arr = new T[initialCapacity];
	}

	public ConcurrentList()
		: this(4)
	{
	}

	public ConcurrentList(IEnumerable<T> items)
	{
		_arr = items.ToArray();
		_count = _arr.Length;
		base.AddRange((IEnumerable<T>)_arr);
	}

	public new void Add(T item)
	{
		locker.EnterWriteLock();
		try
		{
			int num = _count + 1;
			EnsureCapacity(num);
			_arr[_count] = item;
			_count = num;
			base.Add(item);
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}

	public ConcurrentList<T> Clone()
	{
		locker.EnterReadLock();
		try
		{
			return new ConcurrentList<T>(this);
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	public new void AddRange(IEnumerable<T> items)
	{
		if (items == null)
		{
			throw new ArgumentNullException("items");
		}
		locker.EnterWriteLock();
		try
		{
			T[] array = (items as T[]) ?? items.ToArray();
			int num = _count + array.Length;
			EnsureCapacity(num);
			Array.Copy(array, 0, _arr, _count, array.Length);
			_count = num;
			base.AddRange((IEnumerable<T>)array);
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}

	private void EnsureCapacity(int capacity)
	{
		if (_arr.Length < capacity)
		{
			int val;
			try
			{
				val = checked(_arr.Length * 2);
			}
			catch (OverflowException)
			{
				val = 2147483647;
			}
			int newSize = Math.Max(val, capacity);
			Array.Resize(ref _arr, newSize);
		}
	}

	public new bool Remove(T item)
	{
		locker.EnterUpgradeableReadLock();
		try
		{
			int num = IndexOfInternal(item);
			if (num == -1)
			{
				return false;
			}
			locker.EnterWriteLock();
			try
			{
				RemoveAtInternal(num);
				base.Remove(item);
				return true;
			}
			finally
			{
				locker.ExitWriteLock();
			}
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
	}

	public new IEnumerator<T> GetEnumerator()
	{
		locker.EnterReadLock();
		try
		{
			for (int i = 0; i < _count; i++)
			{
				yield return _arr[i];
			}
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	public new int IndexOf(T item)
	{
		locker.EnterReadLock();
		try
		{
			return IndexOfInternal(item);
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	private int IndexOfInternal(T item)
	{
		return Array.FindIndex(_arr, 0, _count, (T x) => x.Equals(item));
	}

	public new void Insert(int index, T item)
	{
		locker.EnterUpgradeableReadLock();
		try
		{
			if (index > _count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			locker.EnterWriteLock();
			try
			{
				int num = _count + 1;
				EnsureCapacity(num);
				Array.Copy(_arr, index, _arr, index + 1, _count - index);
				_arr[index] = item;
				_count = num;
				base.Insert(index, item);
			}
			finally
			{
				locker.ExitWriteLock();
			}
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
	}

	public new void RemoveAt(int index)
	{
		locker.EnterUpgradeableReadLock();
		try
		{
			if (index >= _count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			locker.EnterWriteLock();
			try
			{
				RemoveAtInternal(index);
				base.RemoveAt(index);
			}
			finally
			{
				locker.ExitWriteLock();
			}
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
	}

	private void RemoveAtInternal(int index)
	{
		Array.Copy(_arr, index + 1, _arr, index, _count - index - 1);
		_count--;
		Array.Clear(_arr, _count, 1);
	}

	public new void Clear()
	{
		locker.EnterWriteLock();
		try
		{
			Array.Clear(_arr, 0, _count);
			_count = 0;
			base.Clear();
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}

	public new bool Contains(T item)
	{
		locker.EnterReadLock();
		try
		{
			return IndexOfInternal(item) != -1;
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	public new void CopyTo(T[] array, int arrayIndex)
	{
		locker.EnterReadLock();
		try
		{
			if (_count > array.Length - arrayIndex)
			{
				throw new ArgumentException("Destination array was not long enough.");
			}
			Array.Copy(_arr, 0, array, arrayIndex, _count);
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	public void DoSync(Action<ConcurrentList<T>> action)
	{
		GetSync(delegate(ConcurrentList<T> l)
		{
			action(l);
			return 0;
		});
	}

	public TResult GetSync<TResult>(Func<ConcurrentList<T>, TResult> func)
	{
		locker.EnterWriteLock();
		try
		{
			return func(this);
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}

	public void Dispose()
	{
		locker.Dispose();
	}
}
public static class DictionaryExtensions
{
	public static TValue GetValueSafely<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
	{
		if (key == null)
		{
			return defaultValue;
		}
		if (!dictionary.ContainsKey(key))
		{
			return defaultValue;
		}
		return dictionary[key];
	}
}
public static class EnumerableExtensions
{
	public static void DoForEach<E>(this IEnumerable<E> list, Action<E> action, bool ignoreNulls = false)
	{
		foreach (E item in list)
		{
			if (!ignoreNulls || item != null)
			{
				action(item);
			}
		}
	}

	public static IEnumerable<E> ExcludingNulls<E>(this IEnumerable<E> list) where E : class
	{
		return list.Where((E item) => item != null);
	}

	public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> instance, int partitionSize)
	{
		return from i in instance.Select((T value, int index) => new
			{
				Index = index,
				Value = value
			})
			group i by i.Index / partitionSize into i
			select from anon in i
				select anon.Value;
	}

	public static int CountSafe<TData>(this IEnumerable<TData> enumerable)
	{
		return (enumerable?.Count()).GetValueOrDefault();
	}

	public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) where T : class
	{
		if (list != null)
		{
			return list.CountSafe() == 0;
		}
		return true;
	}

	public static List<TData> BoundDataWithoutModification<TData>(this IEnumerable<TData> data, Func<TData, double> dataSelector, Func<TData, double, TData> newValue, double? min = null, double? max = null)
	{
		List<TData> list = new List<TData>();
		if (min.HasValue && max.HasValue && max.Value < min.Value)
		{
			max = min.Value;
		}
		foreach (TData datum in data)
		{
			double num = dataSelector(datum);
			if (min.HasValue && num < min.Value)
			{
				num = min.Value;
			}
			if (max.HasValue && num > max.Value)
			{
				num = max.Value;
			}
			list.Add(newValue(datum, num));
		}
		return list;
	}
}
public class ImprovedObservableCollection<T> : ObservableCollection<T>
{
	public ImprovedObservableCollection(IEnumerable<T> collection)
		: base(collection)
	{
	}

	public ImprovedObservableCollection()
	{
	}

	public void ReplaceItems(IEnumerable<T> newItems)
	{
		CheckReentrancy();
		using (BlockReentrancy())
		{
			List<T> list = (newItems as List<T>) ?? newItems.ToList();
			bool flag = !base.Items.Any();
			bool flag2 = !list.Any();
			if (!(flag && flag2))
			{
				NotifyCollectionChangedAction action;
				List<T> changedItems;
				if (flag)
				{
					action = NotifyCollectionChangedAction.Add;
					changedItems = list;
				}
				else if (flag2)
				{
					action = NotifyCollectionChangedAction.Remove;
					changedItems = base.Items.ToList();
				}
				else
				{
					action = NotifyCollectionChangedAction.Reset;
					changedItems = null;
				}
				base.Items.Clear();
				AddList(list);
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, changedItems));
			}
		}
	}

	public void AddRange(IEnumerable<T> range)
	{
		CheckReentrancy();
		using (BlockReentrancy())
		{
			List<T> list = (range as List<T>) ?? range.ToList();
			AddList(list);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list));
		}
	}

	public void RemoveAll(Func<T, bool> filter)
	{
		CheckReentrancy();
		using (BlockReentrancy())
		{
			List<T> list = this.Where(filter).ToList();
			foreach (T item in list)
			{
				base.Items.Remove(item);
			}
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list));
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
		}
	}

	public void RemoveRange(int index, int count)
	{
		CheckReentrancy();
		List<T> list = this.Skip(index).Take(count).ToList();
		foreach (T item in list)
		{
			base.Items.Remove(item);
		}
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list, index));
		OnPropertyChanged(new PropertyChangedEventArgs("Count"));
	}

	private void AddList(IEnumerable<T> range)
	{
		foreach (T item in range)
		{
			base.Items.Add(item);
		}
		OnPropertyChanged(new PropertyChangedEventArgs("Count"));
	}
}
public static class INotifyCollectionChangedExtensions
{
	public static IObservable<NotifyCollectionChangedEventArgs> ObservableEvent(this INotifyCollectionChanged collection)
	{
		return Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(Action<NotifyCollectionChangedEventArgs> handler)
		{
			return changeHandler;
			void changeHandler(object sender, NotifyCollectionChangedEventArgs e)
			{
				handler(e);
			}
		}, delegate(NotifyCollectionChangedEventHandler changeHandler)
		{
			collection.CollectionChanged += changeHandler;
		}, delegate(NotifyCollectionChangedEventHandler changeHandler)
		{
			collection.CollectionChanged -= changeHandler;
		});
	}
}
public class KeyedList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	private readonly Dictionary<TKey, int> indexLookup = new Dictionary<TKey, int>();

	public ICollection<TKey> Keys => this.Select((KeyValuePair<TKey, TValue> x) => x.Key).ToList();

	public ICollection<TValue> Values => this.Select((KeyValuePair<TKey, TValue> x) => x.Value).ToList();

	public TValue this[TKey key]
	{
		get
		{
			return base[indexLookup[key]].Value;
		}
		set
		{
			if (ContainsKey(key))
			{
				UpdateEntry(key, value);
				return;
			}
			Add(new KeyValuePair<TKey, TValue>(key, value));
			indexLookup.Add(key, base.Count - 1);
		}
	}

	public bool ContainsKey(TKey key)
	{
		return indexLookup.ContainsKey(key);
	}

	public void Add(TKey key, TValue value)
	{
		if (indexLookup.ContainsKey(key))
		{
			throw new ArgumentException($"KeyedList already contains key: {key}");
		}
		this[key] = value;
	}

	private void UpdateEntry(TKey key, TValue value)
	{
		KeyValuePair<TKey, TValue> value2 = new KeyValuePair<TKey, TValue>(key, value);
		base[indexLookup[key]] = value2;
	}

	public bool Remove(TKey key)
	{
		if (!ContainsKey(key))
		{
			return false;
		}
		int num = indexLookup[key];
		RemoveAll((KeyValuePair<TKey, TValue> x) => x.Key.Equals(key));
		indexLookup.Remove(key);
		foreach (KeyValuePair<TKey, int> item in indexLookup.ToList())
		{
			if (item.Value > num)
			{
				indexLookup[item.Key] = item.Value - 1;
			}
		}
		return true;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (!ContainsKey(key))
		{
			value = default(TValue);
			return false;
		}
		value = this[key];
		return true;
	}
}
public class ReadOnlyKeyedList<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
{
	private readonly KeyedList<TKey, TValue> keyedList;

	public int Count => keyedList.Count;

	public IEnumerable<TKey> Keys => keyedList.Keys;

	public IEnumerable<TValue> Values => keyedList.Values;

	public TValue this[TKey key] => keyedList[key];

	public static implicit operator ReadOnlyKeyedList<TKey, TValue>(KeyedList<TKey, TValue> keyedList)
	{
		return new ReadOnlyKeyedList<TKey, TValue>(keyedList);
	}

	public ReadOnlyKeyedList(KeyedList<TKey, TValue> keyedList)
	{
		this.keyedList = keyedList;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return keyedList.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return keyedList.GetEnumerator();
	}

	public bool ContainsKey(TKey key)
	{
		return keyedList.ContainsKey(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		return keyedList.TryGetValue(key, out value);
	}
}
public static class ListExtensions
{
	public static T PopAt<T>(this List<T> list, int index)
	{
		if (list == null)
		{
			return default(T);
		}
		if (index < 0 || index > list.Count - 1)
		{
			return default(T);
		}
		T result = list[index];
		list.RemoveAt(index);
		return result;
	}

	public static T PopLast<T>(this List<T> list)
	{
		if (list == null)
		{
			return default(T);
		}
		if (list.Count == 0)
		{
			return default(T);
		}
		return list.PopAt(list.Count - 1);
	}

	public static T PopFirst<T>(this List<T> list)
	{
		if (list == null)
		{
			return default(T);
		}
		if (list.Count == 0)
		{
			return default(T);
		}
		return list.PopAt(0);
	}

	public static void AddIfNotNull<T>(this List<T> list, T element) where T : class
	{
		if (element != null)
		{
			list.Add(element);
		}
	}

	public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
	{
		T value = list[indexA];
		list[indexA] = list[indexB];
		list[indexB] = value;
		return list;
	}

	public static ConcurrentList<T> ToConcurrentList<T>(this IList<T> list)
	{
		return new ConcurrentList<T>(list);
	}

	public static T GetSafe<T>(this IList<T> list, int index, T fallback = default(T))
	{
		if (list == null || index >= list.Count)
		{
			return fallback;
		}
		return list[index];
	}
}
public static class MergeLists
{
	public static void Merge<T>(ObservableCollection<T> target, List<T> source, Func<T, IComparable> id)
	{
		foreach (T item2 in target.Where((T x) => !source.Any((T k) => id(k).Equals(id(x)))).ToList())
		{
			target.Remove(item2);
		}
		foreach (T item3 in source.Where((T x) => target.Count((T j) => id(j).Equals(id(x))) == 0))
		{
			target.Add(item3);
		}
		int i;
		for (i = 0; i < source.Count; i++)
		{
			T item = target.FirstOrDefault((T x) => id(x).Equals(id(source[i])));
			target.Move(target.IndexOf(item), i);
		}
	}

	public static void Merge<T>(ObservableCollection<T> target, List<T> source)
	{
		foreach (T item2 in target.Where((T x) => !source.Any((T k) => k.Equals(x))).ToList())
		{
			target.Remove(item2);
		}
		foreach (T item3 in source.Where((T x) => target.Count((T j) => j.Equals(x)) == 0))
		{
			target.Add(item3);
		}
		int i;
		for (i = 0; i < source.Count; i++)
		{
			T item = target.FirstOrDefault((T x) => x.Equals(source[i]));
			target.Move(target.IndexOf(item), i);
		}
	}
}
