#define TRACE
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Delegating;
using MoreLinq.Experimental;
using MoreLinq.Reactive;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MoreLINQ")]
[assembly: AssemblyDescription("Extensions to LINQ to Objects")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MoreLINQ")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyConfiguration("RELEASE")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: Guid("fc632c9d-390e-4902-8c1c-3e57b08c1d38")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCopyright("© 2008 Jonathan Skeet. Portions © 2009 Atif Aziz, Chris Ammerman, Konrad Rudolph. Portions © 2010 Johannes Rudolph, Leopold Bushkin. Portions © 2015 Felipe Sateler, “sholland”. Portions © 2016 Andreas Gullberg Larsen, Leandro F. Vieira (leandromoh). Portions © 2017 Jonas Nyrup (jnyrup). Portions © Microsoft. All rights reserved.")]
[assembly: AssemblyFileVersion("3.3.2.0")]
[assembly: AssemblyInformationalVersion("3.3.2+b8021734c1b78ae861e6df13f9d7de6db26d87f9")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("3.3.2.0")]
namespace Delegating
{
	internal static class Delegate
	{
		public static IDisposable Disposable(Action delegatee)
		{
			return new DelegatingDisposable(delegatee);
		}

		public static IObserver<T> Observer<T>(Action<T> onNext, Action<Exception> onError = null, Action onCompleted = null)
		{
			return new DelegatingObserver<T>(onNext, onError, onCompleted);
		}
	}
	internal sealed class DelegatingDisposable : IDisposable
	{
		private Action _delegatee;

		public DelegatingDisposable(Action delegatee)
		{
			_delegatee = delegatee ?? throw new ArgumentNullException("delegatee");
		}

		public void Dispose()
		{
			Action delegatee = _delegatee;
			if (delegatee != null && !(Interlocked.CompareExchange(ref _delegatee, null, delegatee) != delegatee))
			{
				delegatee();
			}
		}
	}
	internal sealed class DelegatingObserver<T> : IObserver<T>
	{
		private readonly Action<T> _onNext;

		private readonly Action<Exception> _onError;

		private readonly Action _onCompleted;

		public DelegatingObserver(Action<T> onNext, Action<Exception> onError = null, Action onCompleted = null)
		{
			_onNext = onNext ?? throw new ArgumentNullException("onNext");
			_onError = onError;
			_onCompleted = onCompleted;
		}

		public void OnCompleted()
		{
			_onCompleted?.Invoke();
		}

		public void OnError(Exception error)
		{
			_onError?.Invoke(error);
		}

		public void OnNext(T value)
		{
			_onNext(value);
		}
	}
}
namespace MoreLinq
{
	public static class MoreEnumerable
	{
		private static class Grouping
		{
			public static Grouping<TKey, TElement> Create<TKey, TElement>(TKey key, IEnumerable<TElement> members)
			{
				return new Grouping<TKey, TElement>(key, members);
			}
		}

		[Serializable]
		private sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable
		{
			private readonly IEnumerable<TElement> _members;

			public TKey Key { get; }

			public Grouping(TKey key, IEnumerable<TElement> members)
			{
				Key = key;
				_members = members;
			}

			public IEnumerator<TElement> GetEnumerator()
			{
				return _members.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private sealed class ExtremaEnumerable<T, TKey> : IExtremaEnumerable<T>, IEnumerable<T>, IEnumerable
		{
			private static class Extrema
			{
				private sealed class FirstExtrema : Extrema<List<T>, T>
				{
					protected override IEnumerable<T> GetSomeEnumerable(List<T> store)
					{
						return store;
					}

					protected override int Count(List<T> store)
					{
						return store?.Count ?? 0;
					}

					protected override void Push(ref List<T> store, T item)
					{
						(store ?? (store = new List<T>())).Add(item);
					}

					protected override bool TryPop(ref List<T> store)
					{
						return false;
					}
				}

				private sealed class LastExtrema : Extrema<Queue<T>, T>
				{
					protected override IEnumerable<T> GetSomeEnumerable(Queue<T> store)
					{
						return store;
					}

					protected override int Count(Queue<T> store)
					{
						return store?.Count ?? 0;
					}

					protected override void Push(ref Queue<T> store, T item)
					{
						(store ?? (store = new Queue<T>())).Enqueue(item);
					}

					protected override bool TryPop(ref Queue<T> store)
					{
						store.Dequeue();
						return true;
					}
				}

				public static readonly Extrema<List<T>, T> First = new FirstExtrema();

				public static readonly Extrema<Queue<T>, T> Last = new LastExtrema();
			}

			private sealed class Extremum : Extrema<(bool HasValue, T Value), T>
			{
				public static readonly Extrema<(bool, T), T> First = new Extremum(poppable: false);

				public static readonly Extrema<(bool, T), T> Last = new Extremum(poppable: true);

				private readonly bool _poppable;

				private Extremum(bool poppable)
				{
					_poppable = poppable;
				}

				protected override IEnumerable<T> GetSomeEnumerable((bool HasValue, T Value) store)
				{
					return Enumerable.Repeat(store.Value, 1);
				}

				protected override int Count((bool HasValue, T Value) store)
				{
					if (!store.HasValue)
					{
						return 0;
					}
					return 1;
				}

				protected override void Push(ref (bool, T) store, T item)
				{
					store = (true, item);
				}

				protected override bool TryPop(ref (bool, T) store)
				{
					if (!_poppable)
					{
						return false;
					}
					Restart(ref store);
					return true;
				}
			}

			private readonly IEnumerable<T> _source;

			private readonly Func<T, TKey> _selector;

			private readonly Func<TKey, TKey, int> _comparer;

			public ExtremaEnumerable(IEnumerable<T> source, Func<T, TKey> selector, Func<TKey, TKey, int> comparer)
			{
				_source = source;
				_selector = selector;
				_comparer = comparer;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return _source.ExtremaBy(Extrema.First, null, _selector, _comparer).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public IEnumerable<T> Take(int count)
			{
				return count switch
				{
					1 => _source.ExtremaBy(Extremum.First, 1, _selector, _comparer), 
					0 => Enumerable.Empty<T>(), 
					_ => _source.ExtremaBy(Extrema.First, count, _selector, _comparer), 
				};
			}

			public IEnumerable<T> TakeLast(int count)
			{
				return count switch
				{
					1 => _source.ExtremaBy(Extremum.Last, 1, _selector, _comparer), 
					0 => Enumerable.Empty<T>(), 
					_ => _source.ExtremaBy(Extrema.Last, count, _selector, _comparer), 
				};
			}
		}

		private abstract class Extrema<TStore, T>
		{
			public virtual TStore New()
			{
				return default(TStore);
			}

			public virtual void Restart(ref TStore store)
			{
				store = default(TStore);
			}

			public void Add(ref TStore store, int? limit, T item)
			{
				if (!limit.HasValue || Count(store) < limit || TryPop(ref store))
				{
					Push(ref store, item);
				}
			}

			protected abstract int Count(TStore store);

			protected abstract void Push(ref TStore store, T item);

			protected abstract bool TryPop(ref TStore store);

			public virtual IEnumerable<T> GetEnumerable(TStore store)
			{
				if (Count(store) <= 0)
				{
					return Enumerable.Empty<T>();
				}
				return GetSomeEnumerable(store);
			}

			protected abstract IEnumerable<T> GetSomeEnumerable(TStore store);
		}

		private class PermutationEnumerator<T> : IEnumerator<IList<T>>, IEnumerator, IDisposable
		{
			private readonly IList<T> _valueSet;

			private readonly int[] _permutation;

			private readonly IEnumerable<Action> _generator;

			private IEnumerator<Action> _generatorIterator;

			private bool _hasMoreResults;

			public IList<T> Current { get; private set; }

			object IEnumerator.Current => Current;

			public PermutationEnumerator(IEnumerable<T> valueSet)
			{
				_valueSet = valueSet.ToArray();
				_permutation = new int[_valueSet.Count];
				_generator = NestedLoops(NextPermutation, Enumerable.Range(2, Math.Max(0, _valueSet.Count - 1)));
				Reset();
			}

			public void Reset()
			{
				_generatorIterator?.Dispose();
				for (int i = 0; i < _permutation.Length; i++)
				{
					_permutation[i] = i;
				}
				_generatorIterator = _generator.GetEnumerator();
				_generatorIterator.MoveNext();
				_hasMoreResults = true;
			}

			public bool MoveNext()
			{
				Current = PermuteValueSet();
				bool hasMoreResults = _hasMoreResults;
				_hasMoreResults = _generatorIterator.MoveNext();
				if (_hasMoreResults)
				{
					_generatorIterator.Current();
				}
				return hasMoreResults;
			}

			void IDisposable.Dispose()
			{
			}

			private void NextPermutation()
			{
				int num = _permutation.Length - 2;
				while (_permutation[num] > _permutation[num + 1])
				{
					num--;
				}
				int num2 = _permutation.Length - 1;
				while (_permutation[num] > _permutation[num2])
				{
					num2--;
				}
				int num3 = _permutation[num2];
				_permutation[num2] = _permutation[num];
				_permutation[num] = num3;
				int num4 = _permutation.Length - 1;
				for (int i = num + 1; num4 > i; i++)
				{
					num3 = _permutation[i];
					_permutation[i] = _permutation[num4];
					_permutation[num4] = num3;
					num4--;
				}
			}

			private IList<T> PermuteValueSet()
			{
				T[] array = new T[_permutation.Length];
				for (int i = 0; i < _permutation.Length; i++)
				{
					array[i] = _valueSet[_permutation[i]];
				}
				return array;
			}
		}

		private sealed class GlobalRandom : Random
		{
			public static readonly Random Instance = new GlobalRandom();

			private static int _seed = Environment.TickCount;

			[ThreadStatic]
			private static Random _threadRandom;

			private static Random ThreadRandom => _threadRandom ?? (_threadRandom = new Random(Interlocked.Increment(ref _seed)));

			private GlobalRandom()
			{
			}

			public override int Next()
			{
				return ThreadRandom.Next();
			}

			public override int Next(int minValue, int maxValue)
			{
				return ThreadRandom.Next(minValue, maxValue);
			}

			public override int Next(int maxValue)
			{
				return ThreadRandom.Next(maxValue);
			}

			public override double NextDouble()
			{
				return ThreadRandom.NextDouble();
			}

			public override void NextBytes(byte[] buffer)
			{
				ThreadRandom.NextBytes(buffer);
			}

			protected override double Sample()
			{
				throw new NotImplementedException();
			}
		}

		private sealed class SingleElementList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
		{
			private readonly T _item;

			public int Count => 1;

			public bool IsReadOnly => true;

			public T this[int index]
			{
				get
				{
					if (index != 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					return _item;
				}
				set
				{
					throw ReadOnlyException();
				}
			}

			public SingleElementList(T item)
			{
				_item = item;
			}

			public IEnumerator<T> GetEnumerator()
			{
				yield return _item;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public int IndexOf(T item)
			{
				if (!Contains(item))
				{
					return -1;
				}
				return 0;
			}

			public bool Contains(T item)
			{
				return EqualityComparer<T>.Default.Equals(_item, item);
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				array[arrayIndex] = _item;
			}

			public void Add(T item)
			{
				throw ReadOnlyException();
			}

			public void Clear()
			{
				throw ReadOnlyException();
			}

			public bool Remove(T item)
			{
				throw ReadOnlyException();
			}

			public void Insert(int index, T item)
			{
				throw ReadOnlyException();
			}

			public void RemoveAt(int index)
			{
				throw ReadOnlyException();
			}

			private static NotSupportedException ReadOnlyException()
			{
				return new NotSupportedException("Single element list is immutable.");
			}
		}

		private sealed class DisposableGroup<T> : IDisposable
		{
			public List<IEnumerator<T>> Iterators { get; }

			public IEnumerator<T> this[int index] => Iterators[index];

			public DisposableGroup(IEnumerable<IEnumerator<T>> iterators)
			{
				Iterators = new List<IEnumerator<T>>(iterators);
			}

			public void Exclude(int index)
			{
				Iterators[index].Dispose();
				Iterators.RemoveAt(index);
			}

			public void Dispose()
			{
				Iterators.ForEach(delegate(IEnumerator<T> iter)
				{
					iter.Dispose();
				});
			}
		}

		private sealed class SubsetGenerator<T> : IEnumerable<IList<T>>, IEnumerable
		{
			private class SubsetEnumerator : IEnumerator<IList<T>>, IEnumerator, IDisposable
			{
				private readonly IList<T> _set;

				private readonly T[] _subset;

				private readonly int[] _indices;

				private bool _continue;

				private int _m;

				private int _m2;

				private int _k;

				private int _n;

				private int _z;

				public IList<T> Current => (IList<T>)_subset.Clone();

				object IEnumerator.Current => Current;

				public SubsetEnumerator(IList<T> set, int subsetSize)
				{
					if (subsetSize > set.Count)
					{
						throw new ArgumentOutOfRangeException("subsetSize", "Subset size must be <= sequence.Count()");
					}
					_set = set;
					_subset = new T[subsetSize];
					_indices = new int[subsetSize];
					Reset();
				}

				public void Reset()
				{
					_m = _subset.Length;
					_m2 = -1;
					_k = _subset.Length;
					_n = _set.Count;
					_z = _n - _k + 1;
					_continue = _subset.Length != 0;
				}

				public bool MoveNext()
				{
					if (!_continue)
					{
						return false;
					}
					if (_m2 == -1)
					{
						_m2 = 0;
						_m = _k;
					}
					else
					{
						if (_m2 < _n - _m)
						{
							_m = 0;
						}
						_m++;
						_m2 = _indices[_k - _m];
					}
					for (int i = 1; i <= _m; i++)
					{
						_indices[_k + i - _m - 1] = _m2 + i;
					}
					ExtractSubset();
					_continue = _indices[0] != _z;
					return true;
				}

				void IDisposable.Dispose()
				{
				}

				private void ExtractSubset()
				{
					for (int i = 0; i < _k; i++)
					{
						_subset[i] = _set[_indices[i] - 1];
					}
				}
			}

			private readonly IEnumerable<T> _sequence;

			private readonly int _subsetSize;

			public SubsetGenerator(IEnumerable<T> sequence, int subsetSize)
			{
				if (sequence == null)
				{
					throw new ArgumentNullException("sequence");
				}
				if (subsetSize < 0)
				{
					throw new ArgumentOutOfRangeException("subsetSize", "{subsetSize} must be between 0 and set.Count()");
				}
				_subsetSize = subsetSize;
				_sequence = sequence;
			}

			public IEnumerator<IList<T>> GetEnumerator()
			{
				return new SubsetEnumerator(_sequence.ToList(), _subsetSize);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private static class StringBuilderAppenders
		{
			public static readonly Func<StringBuilder, bool, StringBuilder> Boolean = (StringBuilder sb, bool e) => sb.Append(e);

			public static readonly Func<StringBuilder, byte, StringBuilder> Byte = (StringBuilder sb, byte e) => sb.Append(e);

			public static readonly Func<StringBuilder, char, StringBuilder> Char = (StringBuilder sb, char e) => sb.Append(e);

			public static readonly Func<StringBuilder, decimal, StringBuilder> Decimal = (StringBuilder sb, decimal e) => sb.Append(e);

			public static readonly Func<StringBuilder, double, StringBuilder> Double = (StringBuilder sb, double e) => sb.Append(e);

			public static readonly Func<StringBuilder, float, StringBuilder> Single = (StringBuilder sb, float e) => sb.Append(e);

			public static readonly Func<StringBuilder, int, StringBuilder> Int32 = (StringBuilder sb, int e) => sb.Append(e);

			public static readonly Func<StringBuilder, long, StringBuilder> Int64 = (StringBuilder sb, long e) => sb.Append(e);

			public static readonly Func<StringBuilder, sbyte, StringBuilder> SByte = (StringBuilder sb, sbyte e) => sb.Append(e);

			public static readonly Func<StringBuilder, short, StringBuilder> Int16 = (StringBuilder sb, short e) => sb.Append(e);

			public static readonly Func<StringBuilder, string, StringBuilder> String = (StringBuilder sb, string e) => sb.Append(e);

			public static readonly Func<StringBuilder, uint, StringBuilder> UInt32 = (StringBuilder sb, uint e) => sb.Append(e);

			public static readonly Func<StringBuilder, ulong, StringBuilder> UInt64 = (StringBuilder sb, ulong e) => sb.Append(e);

			public static readonly Func<StringBuilder, ushort, StringBuilder> UInt16 = (StringBuilder sb, ushort e) => sb.Append(e);
		}

		private delegate TResult Folder<in T, out TResult>(params T[] args);

		[CompilerGenerated]
		private sealed class <>c__DisplayClass23_0<TSource, TResult>
		{
			public Func<IEnumerable<TSource>, TResult> resultSelector;

			public IEnumerable<TSource> source;
		}

		private static readonly Func<int, int, Exception> DefaultErrorSelector = OnAssertCountFailure;

		private static readonly string[] OrdinalNumbers = new string[4] { "First", "Second", "Third", "Fourth" };

		private static readonly Func<int, int, Exception> OnFolderSourceSizeErrorSelector = OnFolderSourceSizeError;

		public static TSource[] Acquire<TSource>(this IEnumerable<TSource> source) where TSource : IDisposable
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			List<TSource> list = new List<TSource>();
			try
			{
				list.AddRange(source);
				return list.ToArray();
			}
			catch
			{
				foreach (TSource item in list)
				{
					item.Dispose();
				}
				throw;
			}
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, Func<TAccumulate1, TAccumulate2, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
			}
			return resultSelector(arg, val);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, Func<TAccumulate1, TAccumulate2, TAccumulate3, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
			}
			return resultSelector(arg, val, val2);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			TAccumulate4 val3 = seed4;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
				val3 = accumulator4(val3, item);
			}
			return resultSelector(arg, val, val2, val3);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			TAccumulate4 val3 = seed4;
			TAccumulate5 val4 = seed5;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
				val3 = accumulator4(val3, item);
				val4 = accumulator5(val4, item);
			}
			return resultSelector(arg, val, val2, val3, val4);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			TAccumulate4 val3 = seed4;
			TAccumulate5 val4 = seed5;
			TAccumulate6 val5 = seed6;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
				val3 = accumulator4(val3, item);
				val4 = accumulator5(val4, item);
				val5 = accumulator6(val5, item);
			}
			return resultSelector(arg, val, val2, val3, val4, val5);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, TAccumulate7 seed7, Func<TAccumulate7, T, TAccumulate7> accumulator7, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (accumulator7 == null)
			{
				throw new ArgumentNullException("accumulator7");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			TAccumulate4 val3 = seed4;
			TAccumulate5 val4 = seed5;
			TAccumulate6 val5 = seed6;
			TAccumulate7 val6 = seed7;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
				val3 = accumulator4(val3, item);
				val4 = accumulator5(val4, item);
				val5 = accumulator6(val5, item);
				val6 = accumulator7(val6, item);
			}
			return resultSelector(arg, val, val2, val3, val4, val5, val6);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TAccumulate8, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, TAccumulate7 seed7, Func<TAccumulate7, T, TAccumulate7> accumulator7, TAccumulate8 seed8, Func<TAccumulate8, T, TAccumulate8> accumulator8, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TAccumulate8, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (accumulator7 == null)
			{
				throw new ArgumentNullException("accumulator7");
			}
			if (accumulator8 == null)
			{
				throw new ArgumentNullException("accumulator8");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TAccumulate1 arg = seed1;
			TAccumulate2 val = seed2;
			TAccumulate3 val2 = seed3;
			TAccumulate4 val3 = seed4;
			TAccumulate5 val4 = seed5;
			TAccumulate6 val5 = seed6;
			TAccumulate7 val6 = seed7;
			TAccumulate8 val7 = seed8;
			foreach (T item in source)
			{
				arg = accumulator1(arg, item);
				val = accumulator2(val, item);
				val2 = accumulator3(val2, item);
				val3 = accumulator4(val3, item);
				val4 = accumulator5(val4, item);
				val5 = accumulator6(val5, item);
				val6 = accumulator7(val6, item);
				val7 = accumulator8(val7, item);
			}
			return resultSelector(arg, val, val2, val3, val4, val5, val6, val7);
		}

		public static TSource AggregateRight<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			IListLike<TSource> listLike = source.ToListLike();
			if (listLike.Count == 0)
			{
				throw new InvalidOperationException("Sequence contains no elements.");
			}
			return AggregateRightImpl(listLike, listLike[listLike.Count - 1], func, listLike.Count - 1);
		}

		public static TAccumulate AggregateRight<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			IListLike<TSource> listLike = source.ToListLike();
			return AggregateRightImpl(listLike, seed, func, listLike.Count);
		}

		public static TResult AggregateRight<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return resultSelector(source.AggregateRight(seed, func));
		}

		private static TResult AggregateRightImpl<TSource, TResult>(IListLike<TSource> list, TResult accumulator, Func<TSource, TResult, TResult> func, int i)
		{
			while (i-- > 0)
			{
				accumulator = func(list[i], accumulator);
			}
			return accumulator;
		}

		public static IEnumerable<T> Append<T>(this IEnumerable<T> head, T tail)
		{
			if (head == null)
			{
				throw new ArgumentNullException("head");
			}
			if (!(head is PendNode<T> pendNode))
			{
				return PendNode<T>.WithSource(head).Concat(tail);
			}
			return pendNode.Concat(tail);
		}

		[Obsolete("Use Append instead.")]
		public static IEnumerable<T> Concat<T>(this IEnumerable<T> head, T tail)
		{
			return head.Append(tail);
		}

		public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return source.Assert(predicate, null);
		}

		public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, Exception> errorSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return _();
			IEnumerable<TSource> _()
			{
				foreach (TSource item in source)
				{
					if (!predicate(item))
					{
						throw errorSelector?.Invoke(item) ?? new InvalidOperationException("Sequence contains an invalid item.");
					}
					yield return item;
				}
			}
		}

		public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count)
		{
			return AssertCountImpl(source, count, DefaultErrorSelector);
		}

		public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count, Func<int, int, Exception> errorSelector)
		{
			return AssertCountImpl(source, count, errorSelector);
		}

		private static Exception OnAssertCountFailure(int cmp, int count)
		{
			return new SequenceException(string.Format((cmp < 0) ? "Sequence contains too few elements when exactly {0} were expected." : "Sequence contains too many elements when exactly {0} were expected.", count.ToString("N0")));
		}

		private static IEnumerable<TSource> AssertCountImpl<TSource>(IEnumerable<TSource> source, int count, Func<int, int, Exception> errorSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (errorSelector == null)
			{
				throw new ArgumentNullException("errorSelector");
			}
			int? num = source.TryGetCollectionCount();
			if (num.HasValue)
			{
				int collectionCount = num.GetValueOrDefault();
				if (collectionCount != count)
				{
					return From((Func<TSource>)delegate
					{
						throw errorSelector(collectionCount.CompareTo(count), count);
					});
				}
				return source;
			}
			return _();
			IEnumerable<TSource> _()
			{
				int iterations = 0;
				foreach (TSource item in source)
				{
					iterations++;
					if (iterations > count)
					{
						throw errorSelector(1, count);
					}
					yield return item;
				}
				if (iterations != count)
				{
					throw errorSelector(-1, count);
				}
			}
		}

		public static IEnumerable<T> Backsert<T>(this IEnumerable<T> first, IEnumerable<T> second, int index)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Index cannot be negative.");
			}
			if (index == 0)
			{
				return first.Concat(second);
			}
			return _();
			IEnumerable<T> _()
			{
				using IEnumerator<(T, int?)> e = first.CountDown(index, ValueTuple.Create).GetEnumerator();
				if (e.MoveNext())
				{
					int? item = e.Current.Item2;
					if (item.HasValue)
					{
						int valueOrDefault = item.GetValueOrDefault();
						if (valueOrDefault != index - 1)
						{
							throw new ArgumentOutOfRangeException("index", "Insertion index is greater than the length of the first sequence.");
						}
					}
					do
					{
						(T, int?) current = e.Current;
						var (a, _) = current;
						if (current.Item2 == index - 1)
						{
							foreach (T item2 in second)
							{
								yield return item2;
							}
						}
						yield return a;
					}
					while (e.MoveNext());
				}
			}
		}

		public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
		{
			return source.Batch(size, (IEnumerable<TSource> x) => x);
		}

		public static IEnumerable<TResult> Batch<TSource, TResult>(this IEnumerable<TSource> source, int size, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			ICollection<TSource> collection2;
			IReadOnlyList<TSource> readOnlyList;
			IReadOnlyCollection<TSource> readOnlyCollection;
			if (source is ICollection<TSource> collection)
			{
				if (collection.Count == 0)
				{
					return Enumerable.Empty<TResult>();
				}
				collection2 = collection;
				if (collection2.Count <= size)
				{
					return _();
				}
				readOnlyList = source as IReadOnlyList<TSource>;
				if (readOnlyList != null)
				{
					goto IL_0111;
				}
				readOnlyCollection = source as IReadOnlyCollection<TSource>;
				if (readOnlyCollection != null)
				{
					goto IL_013b;
				}
			}
			else
			{
				readOnlyList = source as IReadOnlyList<TSource>;
				if (readOnlyList != null)
				{
					goto IL_0111;
				}
				readOnlyCollection = source as IReadOnlyCollection<TSource>;
				if (readOnlyCollection != null)
				{
					goto IL_013b;
				}
			}
			goto IL_0158;
			IL_0111:
			if (readOnlyList.Count == 0)
			{
				return Enumerable.Empty<TResult>();
			}
			IReadOnlyList<TSource> readOnlyList2 = readOnlyList;
			if (readOnlyList2.Count > size)
			{
				readOnlyCollection = (IReadOnlyCollection<TSource>)source;
				goto IL_013b;
			}
			return _2();
			IL_013b:
			if (readOnlyCollection.Count <= size)
			{
				return Batch(readOnlyCollection.Count);
			}
			goto IL_0158;
			IL_0158:
			return Batch(size);
			IEnumerable<TResult> Batch(int num2)
			{
				TSource[] array = null;
				int num = 0;
				foreach (TSource item in ((<>c__DisplayClass23_0<TSource, TResult>)this).source)
				{
					if (array == null)
					{
						array = new TSource[num2];
					}
					array[num++] = item;
					if (num == num2)
					{
						yield return ((<>c__DisplayClass23_0<TSource, TResult>)this).resultSelector(array);
						array = null;
						num = 0;
					}
				}
				if (array != null && num > 0)
				{
					Array.Resize(ref array, num);
					yield return ((<>c__DisplayClass23_0<TSource, TResult>)this).resultSelector(array);
				}
			}
			IEnumerable<TResult> _()
			{
				TSource[] array = new TSource[collection2.Count];
				collection2.CopyTo(array, 0);
				yield return resultSelector(array);
			}
			IEnumerable<TResult> _2()
			{
				TSource[] array = new TSource[readOnlyList2.Count];
				for (int i = 0; i < readOnlyList2.Count; i++)
				{
					array[i] = readOnlyList2[i];
				}
				yield return resultSelector(array);
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					foreach (T1 item1 in first)
					{
						foreach (T2 item2 in secondMemo)
						{
							yield return resultSelector(item1, item2);
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						foreach (T1 item1 in first)
						{
							foreach (T2 item2 in secondMemo)
							{
								foreach (T3 item3 in thirdMemo)
								{
									yield return resultSelector(item1, item2, item3);
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						IEnumerable<T4> enumerable3;
						IEnumerable<T4> fourthMemo = (enumerable3 = fourth.Memoize());
						using (enumerable3 as IDisposable)
						{
							foreach (T1 item1 in first)
							{
								foreach (T2 item2 in secondMemo)
								{
									foreach (T3 item3 in thirdMemo)
									{
										foreach (T4 item4 in fourthMemo)
										{
											yield return resultSelector(item1, item2, item3, item4);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (fifth == null)
			{
				throw new ArgumentNullException("fifth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						IEnumerable<T4> enumerable3;
						IEnumerable<T4> fourthMemo = (enumerable3 = fourth.Memoize());
						using (enumerable3 as IDisposable)
						{
							IEnumerable<T5> enumerable4;
							IEnumerable<T5> fifthMemo = (enumerable4 = fifth.Memoize());
							using (enumerable4 as IDisposable)
							{
								foreach (T1 item1 in first)
								{
									foreach (T2 item2 in secondMemo)
									{
										foreach (T3 item3 in thirdMemo)
										{
											foreach (T4 item4 in fourthMemo)
											{
												foreach (T5 item5 in fifthMemo)
												{
													yield return resultSelector(item1, item2, item3, item4, item5);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (fifth == null)
			{
				throw new ArgumentNullException("fifth");
			}
			if (sixth == null)
			{
				throw new ArgumentNullException("sixth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						IEnumerable<T4> enumerable3;
						IEnumerable<T4> fourthMemo = (enumerable3 = fourth.Memoize());
						using (enumerable3 as IDisposable)
						{
							IEnumerable<T5> enumerable4;
							IEnumerable<T5> fifthMemo = (enumerable4 = fifth.Memoize());
							using (enumerable4 as IDisposable)
							{
								IEnumerable<T6> enumerable5;
								IEnumerable<T6> sixthMemo = (enumerable5 = sixth.Memoize());
								using (enumerable5 as IDisposable)
								{
									foreach (T1 item1 in first)
									{
										foreach (T2 item2 in secondMemo)
										{
											foreach (T3 item3 in thirdMemo)
											{
												foreach (T4 item4 in fourthMemo)
												{
													foreach (T5 item5 in fifthMemo)
													{
														foreach (T6 item6 in sixthMemo)
														{
															yield return resultSelector(item1, item2, item3, item4, item5, item6);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, IEnumerable<T7> seventh, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (fifth == null)
			{
				throw new ArgumentNullException("fifth");
			}
			if (sixth == null)
			{
				throw new ArgumentNullException("sixth");
			}
			if (seventh == null)
			{
				throw new ArgumentNullException("seventh");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						IEnumerable<T4> enumerable3;
						IEnumerable<T4> fourthMemo = (enumerable3 = fourth.Memoize());
						using (enumerable3 as IDisposable)
						{
							IEnumerable<T5> enumerable4;
							IEnumerable<T5> fifthMemo = (enumerable4 = fifth.Memoize());
							using (enumerable4 as IDisposable)
							{
								IEnumerable<T6> enumerable5;
								IEnumerable<T6> sixthMemo = (enumerable5 = sixth.Memoize());
								using (enumerable5 as IDisposable)
								{
									IEnumerable<T7> enumerable6;
									IEnumerable<T7> seventhMemo = (enumerable6 = seventh.Memoize());
									using (enumerable6 as IDisposable)
									{
										foreach (T1 item1 in first)
										{
											foreach (T2 item2 in secondMemo)
											{
												foreach (T3 item3 in thirdMemo)
												{
													foreach (T4 item4 in fourthMemo)
													{
														foreach (T5 item5 in fifthMemo)
														{
															foreach (T6 item6 in sixthMemo)
															{
																foreach (T7 item7 in seventhMemo)
																{
																	yield return resultSelector(item1, item2, item3, item4, item5, item6, item7);
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, IEnumerable<T7> seventh, IEnumerable<T8> eighth, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (fifth == null)
			{
				throw new ArgumentNullException("fifth");
			}
			if (sixth == null)
			{
				throw new ArgumentNullException("sixth");
			}
			if (seventh == null)
			{
				throw new ArgumentNullException("seventh");
			}
			if (eighth == null)
			{
				throw new ArgumentNullException("eighth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				IEnumerable<T2> enumerable;
				IEnumerable<T2> secondMemo = (enumerable = second.Memoize());
				using (enumerable as IDisposable)
				{
					IEnumerable<T3> enumerable2;
					IEnumerable<T3> thirdMemo = (enumerable2 = third.Memoize());
					using (enumerable2 as IDisposable)
					{
						IEnumerable<T4> enumerable3;
						IEnumerable<T4> fourthMemo = (enumerable3 = fourth.Memoize());
						using (enumerable3 as IDisposable)
						{
							IEnumerable<T5> enumerable4;
							IEnumerable<T5> fifthMemo = (enumerable4 = fifth.Memoize());
							using (enumerable4 as IDisposable)
							{
								IEnumerable<T6> enumerable5;
								IEnumerable<T6> sixthMemo = (enumerable5 = sixth.Memoize());
								using (enumerable5 as IDisposable)
								{
									IEnumerable<T7> enumerable6;
									IEnumerable<T7> seventhMemo = (enumerable6 = seventh.Memoize());
									using (enumerable6 as IDisposable)
									{
										IEnumerable<T8> enumerable7;
										IEnumerable<T8> eighthMemo = (enumerable7 = eighth.Memoize());
										using (enumerable7 as IDisposable)
										{
											foreach (T1 item1 in first)
											{
												foreach (T2 item2 in secondMemo)
												{
													foreach (T3 item3 in thirdMemo)
													{
														foreach (T4 item4 in fourthMemo)
														{
															foreach (T5 item5 in fifthMemo)
															{
																foreach (T6 item6 in sixthMemo)
																{
																	foreach (T7 item7 in seventhMemo)
																	{
																		foreach (T8 item8 in eighthMemo)
																		{
																			yield return resultSelector(item1, item2, item3, item4, item5, item6, item7, item8);
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public static IEnumerable<TResult> Choose<T, TResult>(this IEnumerable<T> source, Func<T, (bool, TResult)> chooser)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (chooser == null)
			{
				throw new ArgumentNullException("chooser");
			}
			return _();
			IEnumerable<TResult> _()
			{
				foreach (T item in source)
				{
					var (flag, val) = chooser(item);
					if (flag)
					{
						yield return val;
					}
				}
			}
		}

		public static void Consume<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			foreach (T item in source)
			{
				_ = item;
			}
		}

		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.CountBy(keySelector, null);
		}

		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return _();
			void Loop(IEqualityComparer<TKey> cmp)
			{
				Dictionary<TKey, int> dic = new Dictionary<TKey, int>(cmp);
				int? nullIndex = null;
				P_1.keys = new List<TKey>();
				P_1.counts = new List<int>();
				bool flag = false;
				TKey val = default(TKey);
				int i = 0;
				foreach (TSource item in source)
				{
					TKey val2 = keySelector(item);
					if ((flag && cmp.GetHashCode(val) == cmp.GetHashCode(val2) && cmp.Equals(val, val2)) || TryGetIndex(val2, out i))
					{
						P_1.counts[i]++;
					}
					else
					{
						i = P_1.keys.Count;
						if (val2 != null)
						{
							dic[val2] = i;
						}
						else
						{
							nullIndex = i;
						}
						P_1.keys.Add(val2);
						P_1.counts.Add(1);
					}
					val = val2;
					flag = true;
				}
				bool TryGetIndex(TKey key, out int reference)
				{
					if (key == null)
					{
						reference = nullIndex.GetValueOrDefault();
						return nullIndex.HasValue;
					}
					return dic.TryGetValue(key, out reference);
				}
			}
			IEnumerable<KeyValuePair<TKey, int>> _()
			{
				Loop(comparer ?? EqualityComparer<TKey>.Default);
				List<TKey> keys = default(List<TKey>);
				List<int> counts = default(List<int>);
				for (int i = 0; i < keys.Count; i++)
				{
					yield return new KeyValuePair<TKey, int>(keys[i], counts[i]);
				}
			}
		}

		public static IEnumerable<TResult> CountDown<T, TResult>(this IEnumerable<T> source, int count, Func<T, int?, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			IListLike<T> listLike = source.TryAsListLike();
			if (listLike == null)
			{
				int? num = source.TryGetCollectionCount();
				if (num.HasValue)
				{
					int valueOrDefault = num.GetValueOrDefault();
					return IterateCollection(valueOrDefault);
				}
				return IterateSequence();
			}
			return IterateList(listLike);
			IEnumerable<TResult> IterateCollection(int i)
			{
				foreach (T item in source)
				{
					yield return resultSelector(item, (i-- <= count) ? new int?(i) : ((int?)null));
				}
			}
			IEnumerable<TResult> IterateList(IListLike<T> list)
			{
				int countdown = Math.Min(count, list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					int? num2;
					if (list.Count - i > count)
					{
						num2 = null;
					}
					else
					{
						int num3 = countdown - 1;
						countdown = num3;
						num2 = num3;
					}
					int? arg = num2;
					yield return resultSelector(list[i], arg);
				}
			}
			IEnumerable<TResult> IterateSequence()
			{
				Queue<T> queue = new Queue<T>(Math.Max(1, count + 1));
				foreach (T item2 in source)
				{
					queue.Enqueue(item2);
					if (queue.Count > count)
					{
						yield return resultSelector(queue.Dequeue(), null);
					}
				}
				while (queue.Count > 0)
				{
					yield return resultSelector(queue.Dequeue(), queue.Count);
				}
			}
		}

		public static bool AtLeast<T>(this IEnumerable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Count cannot be negative.");
			}
			return QuantityIterator(source, count, count, 2147483647);
		}

		public static bool AtMost<T>(this IEnumerable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Count cannot be negative.");
			}
			return QuantityIterator(source, count + 1, 0, count);
		}

		public static bool Exactly<T>(this IEnumerable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Count cannot be negative.");
			}
			return QuantityIterator(source, count + 1, count, count);
		}

		public static bool CountBetween<T>(this IEnumerable<T> source, int min, int max)
		{
			if (min < 0)
			{
				throw new ArgumentOutOfRangeException("min", "Minimum count cannot be negative.");
			}
			if (max < min)
			{
				throw new ArgumentOutOfRangeException("max", "Maximum count must be greater than or equal to the minimum count.");
			}
			return QuantityIterator(source, max + 1, min, max);
		}

		private static bool QuantityIterator<T>(IEnumerable<T> source, int limit, int min, int max)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			int num = source.TryGetCollectionCount() ?? source.CountUpTo(limit);
			if (num >= min)
			{
				return num <= max;
			}
			return false;
		}

		public static int CompareCount<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			int? num = first.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				return valueOrDefault.CompareTo(second.TryGetCollectionCount() ?? second.CountUpTo(valueOrDefault + 1));
			}
			num = second.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault2 = num.GetValueOrDefault();
				return first.CountUpTo(valueOrDefault2 + 1).CompareTo(valueOrDefault2);
			}
			using IEnumerator<TFirst> enumerator = first.GetEnumerator();
			bool flag;
			bool flag2;
			using (IEnumerator<TSecond> enumerator2 = second.GetEnumerator())
			{
				do
				{
					flag = enumerator.MoveNext();
					flag2 = enumerator2.MoveNext();
				}
				while (flag && flag2);
			}
			return flag.CompareTo(flag2);
		}

		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.DistinctBy(keySelector, null);
		}

		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return _();
			IEnumerable<TSource> _()
			{
				HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
				foreach (TSource item in source)
				{
					if (knownKeys.Add(keySelector(item)))
					{
						yield return item;
					}
				}
			}
		}

		public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return first.EndsWith(second, null);
		}

		public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<T>.Default;
			}
			int? num = second.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				num = first.TryGetCollectionCount();
				if (num.HasValue)
				{
					int valueOrDefault2 = num.GetValueOrDefault();
					if (valueOrDefault > valueOrDefault2)
					{
						return false;
					}
				}
				return Impl(second, valueOrDefault);
			}
			List<T> list;
			return Impl(list = second.ToList(), list.Count);
			bool Impl(IEnumerable<T> snd, int count)
			{
				IEnumerator<T> firstIter = first.TakeLast(count).GetEnumerator();
				try
				{
					return snd.All((T item) => firstIter.MoveNext() && comparer.Equals(firstIter.Current, item));
				}
				finally
				{
					if (firstIter != null)
					{
						firstIter.Dispose();
					}
				}
			}
		}

		public static IEnumerable<TResult> EquiZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return EquiZipImpl(first, second, null, null, (TFirst a, TSecond b, object c, object d) => resultSelector(a, b));
		}

		public static IEnumerable<TResult> EquiZip<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return EquiZipImpl(first, second, third, null, (T1 a, T2 b, T3 c, object _) => resultSelector(a, b, c));
		}

		public static IEnumerable<TResult> EquiZip<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return EquiZipImpl(first, second, third, fourth, resultSelector);
		}

		private static IEnumerable<TResult> EquiZipImpl<T1, T2, T3, T4, TResult>(IEnumerable<T1> s1, IEnumerable<T2> s2, IEnumerable<T3> s3, IEnumerable<T4> s4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			int limit = 1 + ((s3 != null) ? 1 : 0) + ((s4 != null) ? 1 : 0);
			return ZipImpl(s1, s2, s3, s4, resultSelector, limit, delegate(IEnumerator[] enumerators)
			{
				int key = enumerators.Index().First((KeyValuePair<int, IEnumerator> x) => x.Value == null).Key;
				return new InvalidOperationException(OrdinalNumbers[key] + " sequence too short.");
			});
		}

		public static IEnumerable<T> Evaluate<T>(this IEnumerable<Func<T>> functions)
		{
			return (functions ?? throw new ArgumentNullException("functions")).Select((Func<T> f) => f());
		}

		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		{
			return first.ExceptBy(second, keySelector, null);
		}

		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return _();
			IEnumerable<TSource> _()
			{
				HashSet<TKey> keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
				foreach (TSource item in first)
				{
					TKey key = keySelector(item);
					if (!keys.Contains(key))
					{
						yield return item;
						keys.Add(key);
					}
				}
			}
		}

		public static IEnumerable<T> Exclude<T>(this IEnumerable<T> sequence, int startIndex, int count)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return sequence;
			}
			return _();
			IEnumerable<T> _()
			{
				int index = -1;
				int endIndex = startIndex + count;
				using IEnumerator<T> iter = sequence.GetEnumerator();
				int num;
				while (iter.MoveNext())
				{
					num = index + 1;
					index = num;
					if (num >= startIndex)
					{
						break;
					}
					yield return iter.Current;
				}
				do
				{
					num = index + 1;
					index = num;
				}
				while (num < endIndex && iter.MoveNext());
				while (iter.MoveNext())
				{
					yield return iter.Current;
				}
			}
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return FallbackIfEmptyImpl(source, 1, fallback, default(T), default(T), default(T), null);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return FallbackIfEmptyImpl(source, 2, fallback1, fallback2, default(T), default(T), null);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return FallbackIfEmptyImpl(source, 3, fallback1, fallback2, fallback3, default(T), null);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3, T fallback4)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return FallbackIfEmptyImpl(source, 4, fallback1, fallback2, fallback3, fallback4, null);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, params T[] fallback)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (fallback == null)
			{
				throw new ArgumentNullException("fallback");
			}
			return source.FallbackIfEmpty((IEnumerable<T>)fallback);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, IEnumerable<T> fallback)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (fallback == null)
			{
				throw new ArgumentNullException("fallback");
			}
			return FallbackIfEmptyImpl(source, null, default(T), default(T), default(T), default(T), fallback);
		}

		private static IEnumerable<T> FallbackIfEmptyImpl<T>(IEnumerable<T> source, int? count, T fallback1, T fallback2, T fallback3, T fallback4, IEnumerable<T> fallback)
		{
			int? num = source.TryGetCollectionCount();
			if (!num.HasValue)
			{
				return _();
			}
			if (num.GetValueOrDefault() != 0)
			{
				return source;
			}
			return Fallback();
			IEnumerable<T> Fallback()
			{
				if (!count.HasValue)
				{
					return fallback;
				}
				int valueOrDefault = count.GetValueOrDefault();
				if (valueOrDefault >= 1 && valueOrDefault <= 4)
				{
					return FallbackOnArgs();
				}
				throw new ArgumentOutOfRangeException("count", count, null);
			}
			IEnumerable<T> FallbackOnArgs()
			{
				yield return fallback1;
				if (count > 1)
				{
					yield return fallback2;
				}
				if (count > 2)
				{
					yield return fallback3;
				}
				if (count > 3)
				{
					yield return fallback4;
				}
			}
			IEnumerable<T> _()
			{
				using (IEnumerator<T> e = source.GetEnumerator())
				{
					if (e.MoveNext())
					{
						do
						{
							yield return e.Current;
						}
						while (e.MoveNext());
						yield break;
					}
				}
				foreach (T item in Fallback())
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source)
		{
			return source.FillBackward((T e) => e == null);
		}

		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return FillBackwardImpl(source, predicate, null);
		}

		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (fillSelector == null)
			{
				throw new ArgumentNullException("fillSelector");
			}
			return FillBackwardImpl(source, predicate, fillSelector);
		}

		private static IEnumerable<T> FillBackwardImpl<T>(IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			List<T> blanks = null;
			foreach (T item in source)
			{
				if (predicate(item))
				{
					List<T> list = blanks;
					if (list == null)
					{
						List<T> list2;
						blanks = (list2 = new List<T>());
						list = list2;
					}
					list.Add(item);
					continue;
				}
				if (blanks != null)
				{
					foreach (T item2 in blanks)
					{
						yield return (fillSelector != null) ? fillSelector(item2, item) : item;
					}
					blanks.Clear();
				}
				yield return item;
			}
			List<T> list3 = blanks;
			if (list3 == null || list3.Count <= 0)
			{
				yield break;
			}
			foreach (T item3 in blanks)
			{
				yield return item3;
			}
		}

		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source)
		{
			return source.FillForward((T e) => e == null);
		}

		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return FillForwardImpl(source, predicate, null);
		}

		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (fillSelector == null)
			{
				throw new ArgumentNullException("fillSelector");
			}
			return FillForwardImpl(source, predicate, fillSelector);
		}

		private static IEnumerable<T> FillForwardImpl<T>(IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			bool seeded = false;
			T seed = default(T);
			foreach (T item in source)
			{
				if (predicate(item))
				{
					yield return (!seeded) ? item : ((fillSelector != null) ? fillSelector(item, seed) : seed);
					continue;
				}
				seeded = true;
				seed = item;
				yield return item;
			}
		}

		public static IEnumerable<object> Flatten(this IEnumerable source)
		{
			return source.Flatten((IEnumerable obj) => !(obj is string));
		}

		public static IEnumerable<object> Flatten(this IEnumerable source, Func<IEnumerable, bool> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return source.Flatten((object obj) => (!(obj is IEnumerable enumerable) || !predicate(enumerable)) ? null : enumerable);
		}

		public static IEnumerable<object> Flatten(this IEnumerable source, Func<object, IEnumerable> selector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			return _();
			IEnumerable<object> _()
			{
				IEnumerator e = source.GetEnumerator();
				Stack<IEnumerator> stack = new Stack<IEnumerator>();
				stack.Push(e);
				try
				{
					while (stack.Any())
					{
						e = stack.Pop();
						while (e.MoveNext())
						{
							IEnumerable enumerable = selector(e.Current);
							if (enumerable != null)
							{
								stack.Push(e);
								e = enumerable.GetEnumerator();
							}
							else
							{
								yield return e.Current;
							}
						}
						(e as IDisposable)?.Dispose();
						e = null;
					}
				}
				finally
				{
					(e as IDisposable)?.Dispose();
					foreach (IEnumerator item in stack)
					{
						(item as IDisposable)?.Dispose();
					}
				}
			}
		}

		private static TResult FoldImpl<T, TResult>(IEnumerable<T> source, int count, Func<T, TResult> folder1 = null, Func<T, T, TResult> folder2 = null, Func<T, T, T, TResult> folder3 = null, Func<T, T, T, T, TResult> folder4 = null, Func<T, T, T, T, T, TResult> folder5 = null, Func<T, T, T, T, T, T, TResult> folder6 = null, Func<T, T, T, T, T, T, T, TResult> folder7 = null, Func<T, T, T, T, T, T, T, T, TResult> folder8 = null, Func<T, T, T, T, T, T, T, T, T, TResult> folder9 = null, Func<T, T, T, T, T, T, T, T, T, T, TResult> folder10 = null, Func<T, T, T, T, T, T, T, T, T, T, T, TResult> folder11 = null, Func<T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder12 = null, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder13 = null, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder14 = null, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder15 = null, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder16 = null)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if ((count == 1 && folder1 == null) || (count == 2 && folder2 == null) || (count == 3 && folder3 == null) || (count == 4 && folder4 == null) || (count == 5 && folder5 == null) || (count == 6 && folder6 == null) || (count == 7 && folder7 == null) || (count == 8 && folder8 == null) || (count == 9 && folder9 == null) || (count == 10 && folder10 == null) || (count == 11 && folder11 == null) || (count == 12 && folder12 == null) || (count == 13 && folder13 == null) || (count == 14 && folder14 == null) || (count == 15 && folder15 == null) || (count == 16 && folder16 == null))
			{
				throw new ArgumentNullException("folder");
			}
			T[] array = new T[count];
			foreach (KeyValuePair<int, T> item in AssertCountImpl(source.Index(), count, OnFolderSourceSizeErrorSelector))
			{
				array[item.Key] = item.Value;
			}
			return count switch
			{
				1 => folder1(array[0]), 
				2 => folder2(array[0], array[1]), 
				3 => folder3(array[0], array[1], array[2]), 
				4 => folder4(array[0], array[1], array[2], array[3]), 
				5 => folder5(array[0], array[1], array[2], array[3], array[4]), 
				6 => folder6(array[0], array[1], array[2], array[3], array[4], array[5]), 
				7 => folder7(array[0], array[1], array[2], array[3], array[4], array[5], array[6]), 
				8 => folder8(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]), 
				9 => folder9(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8]), 
				10 => folder10(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9]), 
				11 => folder11(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10]), 
				12 => folder12(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11]), 
				13 => folder13(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12]), 
				14 => folder14(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12], array[13]), 
				15 => folder15(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12], array[13], array[14]), 
				16 => folder16(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12], array[13], array[14], array[15]), 
				_ => throw new NotSupportedException(), 
			};
		}

		private static Exception OnFolderSourceSizeError(int cmp, int count)
		{
			return new InvalidOperationException(string.Format((cmp < 0) ? "Sequence contains too few elements when exactly {0} {1} expected." : "Sequence contains too many elements when exactly {0} {1} expected.", count.ToString("N0"), (count == 1) ? "was" : "were"));
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, TResult> folder)
		{
			return FoldImpl(source, 1, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, TResult> folder)
		{
			return FoldImpl(source, 2, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, TResult> folder)
		{
			return FoldImpl(source, 3, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 4, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 5, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 6, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 7, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 8, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 9, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 10, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 11, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 12, null, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 13, null, null, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 14, null, null, null, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 15, null, null, null, null, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return FoldImpl(source, 16, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, folder);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			foreach (T item in source)
			{
				action(item);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			int num = 0;
			foreach (T item in source)
			{
				action(item, num++);
			}
		}

		public static IEnumerable<T> From<T>(Func<T> function)
		{
			return _();
			IEnumerable<T> _()
			{
				yield return function();
			}
		}

		public static IEnumerable<T> From<T>(Func<T> function1, Func<T> function2)
		{
			return _();
			IEnumerable<T> _()
			{
				yield return function1();
				yield return function2();
			}
		}

		public static IEnumerable<T> From<T>(Func<T> function1, Func<T> function2, Func<T> function3)
		{
			return _();
			IEnumerable<T> _()
			{
				yield return function1();
				yield return function2();
				yield return function3();
			}
		}

		public static IEnumerable<T> From<T>(params Func<T>[] functions)
		{
			if (functions == null)
			{
				throw new ArgumentNullException("functions");
			}
			return functions.Evaluate();
		}

		public static IEnumerable<(TKey Key, IEnumerable<TFirst> First, IEnumerable<TSecond> Second)> FullGroupJoin<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector)
		{
			return first.FullGroupJoin(second, firstKeySelector, secondKeySelector, ValueTuple.Create, EqualityComparer<TKey>.Default);
		}

		public static IEnumerable<(TKey Key, IEnumerable<TFirst> First, IEnumerable<TSecond> Second)> FullGroupJoin<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, IEqualityComparer<TKey> comparer)
		{
			return first.FullGroupJoin(second, firstKeySelector, secondKeySelector, ValueTuple.Create, comparer);
		}

		public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector)
		{
			return first.FullGroupJoin(second, firstKeySelector, secondKeySelector, resultSelector, EqualityComparer<TKey>.Default);
		}

		public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (firstKeySelector == null)
			{
				throw new ArgumentNullException("firstKeySelector");
			}
			if (secondKeySelector == null)
			{
				throw new ArgumentNullException("secondKeySelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _(comparer ?? EqualityComparer<TKey>.Default);
			IEnumerable<TResult> _(IEqualityComparer<TKey> comparer2)
			{
				Lookup<TKey, TFirst> alookup = Lookup<TKey, TFirst>.CreateForJoin(first, firstKeySelector, comparer2);
				Lookup<TKey, TSecond> blookup = Lookup<TKey, TSecond>.CreateForJoin(second, secondKeySelector, comparer2);
				foreach (IGrouping<TKey, TFirst> item in alookup)
				{
					yield return resultSelector(item.Key, item, blookup[item.Key]);
				}
				foreach (IGrouping<TKey, TSecond> item2 in blookup)
				{
					if (!alookup.Contains(item2.Key))
					{
						yield return resultSelector(item2.Key, Enumerable.Empty<TFirst>(), item2);
					}
				}
			}
		}

		public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.FullJoin(second, keySelector, firstSelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.FullJoin(second, keySelector, keySelector, firstSelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> FullJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return first.FullJoin(second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> FullJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (firstKeySelector == null)
			{
				throw new ArgumentNullException("firstKeySelector");
			}
			if (secondKeySelector == null)
			{
				throw new ArgumentNullException("secondKeySelector");
			}
			if (firstSelector == null)
			{
				throw new ArgumentNullException("firstSelector");
			}
			if (secondSelector == null)
			{
				throw new ArgumentNullException("secondSelector");
			}
			if (bothSelector == null)
			{
				throw new ArgumentNullException("bothSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				KeyValuePair<TKey, TSecond>[] seconds = second.Select((TSecond e) => new KeyValuePair<TKey, TSecond>(secondKeySelector(e), e)).ToArray();
				ILookup<TKey, TSecond> secondLookup = seconds.ToLookup((KeyValuePair<TKey, TSecond> e) => e.Key, (KeyValuePair<TKey, TSecond> e) => e.Value, comparer);
				HashSet<TKey> firstKeys = new HashSet<TKey>(comparer);
				foreach (TFirst fe in first)
				{
					TKey val = firstKeySelector(fe);
					firstKeys.Add(val);
					using IEnumerator<TSecond> se = secondLookup[val].GetEnumerator();
					if (se.MoveNext())
					{
						do
						{
							yield return bothSelector(fe, se.Current);
						}
						while (se.MoveNext());
					}
					else
					{
						se.Dispose();
						yield return firstSelector(fe);
					}
				}
				KeyValuePair<TKey, TSecond>[] array = seconds;
				for (int num = 0; num < array.Length; num++)
				{
					KeyValuePair<TKey, TSecond> keyValuePair = array[num];
					if (!firstKeys.Contains(keyValuePair.Key))
					{
						yield return secondSelector(keyValuePair.Value);
					}
				}
			}
		}

		public static IEnumerable<TResult> Generate<TResult>(TResult initial, Func<TResult, TResult> generator)
		{
			if (generator == null)
			{
				throw new ArgumentNullException("generator");
			}
			return _();
			IEnumerable<TResult> _()
			{
				TResult current = initial;
				while (true)
				{
					yield return current;
					current = generator(current);
				}
			}
		}

		public static IEnumerable<TResult> GenerateByIndex<TResult>(Func<int, TResult> generator)
		{
			if (generator == null)
			{
				throw new ArgumentNullException("generator");
			}
			return Sequence(0, 2147483647).Select(generator);
		}

		public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.GroupAdjacent(keySelector, null);
		}

		public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return source.GroupAdjacent(keySelector, (TSource e) => e, comparer);
		}

		public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return source.GroupAdjacent(keySelector, elementSelector, null);
		}

		public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (elementSelector == null)
			{
				throw new ArgumentNullException("elementSelector");
			}
			return source.GroupAdjacentImpl(keySelector, elementSelector, CreateGroupAdjacentGrouping, comparer ?? EqualityComparer<TKey>.Default);
		}

		public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.GroupAdjacentImpl(keySelector, (TSource i) => i, ResultSelectorWrapper, EqualityComparer<TKey>.Default);
			TResult ResultSelectorWrapper(TKey key, IList<TSource> group)
			{
				return resultSelector(key, group);
			}
		}

		public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.GroupAdjacentImpl(keySelector, (TSource i) => i, ResultSelectorWrapper, comparer ?? EqualityComparer<TKey>.Default);
			TResult ResultSelectorWrapper(TKey key, IList<TSource> group)
			{
				return resultSelector(key, group);
			}
		}

		private static IEnumerable<TResult> GroupAdjacentImpl<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IList<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			using IEnumerator<TSource> iterator = source.GetEnumerator();
			TKey val = default(TKey);
			List<TElement> list = null;
			while (iterator.MoveNext())
			{
				TKey key = keySelector(iterator.Current);
				TElement element = elementSelector(iterator.Current);
				if (list != null && comparer.Equals(val, key))
				{
					list.Add(element);
					continue;
				}
				if (list != null)
				{
					yield return resultSelector(val, list);
				}
				val = key;
				list = new List<TElement> { element };
			}
			if (list != null)
			{
				yield return resultSelector(val, list);
			}
		}

		private static IGrouping<TKey, TElement> CreateGroupAdjacentGrouping<TKey, TElement>(TKey key, IList<TElement> members)
		{
			IList<TElement> members2;
			if (!members.IsReadOnly)
			{
				IList<TElement> list = new ReadOnlyCollection<TElement>(members);
				members2 = list;
			}
			else
			{
				members2 = members;
			}
			return Grouping.Create(key, members2);
		}

		public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source)
		{
			return source.Index(0);
		}

		public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source, int startIndex)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Select((TSource item, int index) => new KeyValuePair<int, TSource>(startIndex + index, item));
		}

		public static IEnumerable<KeyValuePair<int, TSource>> IndexBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.IndexBy(keySelector, null);
		}

		public static IEnumerable<KeyValuePair<int, TSource>> IndexBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return source.ScanBy(keySelector, (TKey k) => (Index: -1, Item: default(TSource)), ((int Index, TSource Item) s, TKey k, TSource e) => (Index: s.Index + 1, Item: e), comparer).Select(delegate(KeyValuePair<TKey, (int Index, TSource Item)> e)
			{
				KeyValuePair<TKey, (int, TSource)> keyValuePair = e;
				int item = keyValuePair.Value.Item1;
				keyValuePair = e;
				return new KeyValuePair<int, TSource>(item, keyValuePair.Value.Item2);
			});
		}

		public static IEnumerable<T> Insert<T>(this IEnumerable<T> first, IEnumerable<T> second, int index)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Index cannot be negative.");
			}
			return _();
			IEnumerable<T> _()
			{
				int i = -1;
				using IEnumerator<T> iter = first.GetEnumerator();
				while (true)
				{
					int num = i + 1;
					i = num;
					if (num >= index || !iter.MoveNext())
					{
						break;
					}
					yield return iter.Current;
				}
				if (i < index)
				{
					throw new ArgumentOutOfRangeException("index", "Insertion index is greater than the length of the first sequence.");
				}
				foreach (T item in second)
				{
					yield return item;
				}
				while (iter.MoveNext())
				{
					yield return iter.Current;
				}
			}
		}

		public static IEnumerable<T> Interleave<T>(this IEnumerable<T> sequence, params IEnumerable<T>[] otherSequences)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (otherSequences == null)
			{
				throw new ArgumentNullException("otherSequences");
			}
			if (otherSequences.Any((IEnumerable<T> s) => s == null))
			{
				throw new ArgumentNullException("otherSequences", "One or more sequences passed to Interleave was null.");
			}
			return _();
			IEnumerable<T> _()
			{
				IEnumerable<IEnumerable<T>> source = new IEnumerable<T>[1] { sequence }.Concat(otherSequences);
				IEnumerator<T>[] enumerators = source.Select((IEnumerable<T> e) => e.GetEnumerator()).Acquire();
				try
				{
					bool hasNext = true;
					while (hasNext)
					{
						hasNext = false;
						for (int i = 0; i < enumerators.Length; i++)
						{
							IEnumerator<T> enumerator = enumerators[i];
							if (enumerator != null)
							{
								if (enumerator.MoveNext())
								{
									hasNext = true;
									yield return enumerator.Current;
								}
								else
								{
									enumerators[i] = null;
									enumerator.Dispose();
								}
							}
						}
					}
				}
				finally
				{
					IEnumerator<T>[] array = enumerators;
					for (int num = 0; num < array.Length; num++)
					{
						array[num]?.Dispose();
					}
				}
			}
		}

		public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
		{
			return source.Lag(offset, default(TSource), resultSelector);
		}

		public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLagValue, Func<TSource, TSource, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			if (offset <= 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return _();
			IEnumerable<TResult> _()
			{
				using IEnumerator<TSource> iter = source.GetEnumerator();
				int i = offset;
				Queue<TSource> lagQueue = new Queue<TSource>(offset);
				bool hasMore = true;
				while (i-- > 0)
				{
					bool flag;
					hasMore = (flag = iter.MoveNext());
					if (!flag)
					{
						break;
					}
					lagQueue.Enqueue(iter.Current);
					yield return resultSelector(iter.Current, defaultLagValue);
				}
				if (hasMore)
				{
					while (iter.MoveNext())
					{
						TSource arg = lagQueue.Dequeue();
						yield return resultSelector(iter.Current, arg);
						lagQueue.Enqueue(iter.Current);
					}
				}
			}
		}

		public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
		{
			return source.Lead(offset, default(TSource), resultSelector);
		}

		public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLeadValue, Func<TSource, TSource, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			if (offset <= 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return _();
			IEnumerable<TResult> _()
			{
				Queue<TSource> leadQueue = new Queue<TSource>(offset);
				using IEnumerator<TSource> iter = source.GetEnumerator();
				bool flag;
				while ((flag = iter.MoveNext()) && leadQueue.Count < offset)
				{
					leadQueue.Enqueue(iter.Current);
				}
				while (flag)
				{
					yield return resultSelector(leadQueue.Dequeue(), iter.Current);
					leadQueue.Enqueue(iter.Current);
					flag = iter.MoveNext();
				}
				while (leadQueue.Count > 0)
				{
					yield return resultSelector(leadQueue.Dequeue(), defaultLeadValue);
				}
			}
		}

		public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.LeftJoin(second, keySelector, firstSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.LeftJoin(second, keySelector, keySelector, firstSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> LeftJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return first.LeftJoin(second, firstKeySelector, secondKeySelector, firstSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> LeftJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (firstKeySelector == null)
			{
				throw new ArgumentNullException("firstKeySelector");
			}
			if (secondKeySelector == null)
			{
				throw new ArgumentNullException("secondKeySelector");
			}
			if (firstSelector == null)
			{
				throw new ArgumentNullException("firstSelector");
			}
			if (bothSelector == null)
			{
				throw new ArgumentNullException("bothSelector");
			}
			return from f in first.GroupJoin(second, firstKeySelector, secondKeySelector, (TFirst f, IEnumerable<TSecond> ss) => (Value: f, Seconds: ss.Select((TSecond s) => (HasValue: true, Value: s))), comparer)
				from s in f.Seconds.DefaultIfEmpty()
				select (!s.HasValue) ? firstSelector(f.Value) : bothSelector(f.Value, s.Value);
		}

		public static T First<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Take(1).AsEnumerable().First();
		}

		public static T FirstOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Take(1).AsEnumerable().FirstOrDefault();
		}

		public static T Last<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.TakeLast(1).AsEnumerable().Last();
		}

		public static T LastOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Take(1).AsEnumerable().LastOrDefault();
		}

		public static T Single<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Take(2).AsEnumerable().Single();
		}

		public static T SingleOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.Take(2).AsEnumerable().SingleOrDefault();
		}

		public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MaxBy(selector, null);
		}

		public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			return new ExtremaEnumerable<TSource, TKey>(source, selector, (TKey x, TKey y) => comparer.Compare(x, y));
		}

		private static IEnumerable<TSource> ExtremaBy<TSource, TKey, TStore>(this IEnumerable<TSource> source, Extrema<TStore, TSource> extrema, int? limit, Func<TSource, TKey> selector, Func<TKey, TKey, int> comparer)
		{
			foreach (TSource item in Extrema())
			{
				yield return item;
			}
			IEnumerable<TSource> Extrema()
			{
				using IEnumerator<TSource> enumerator2 = source.GetEnumerator();
				if (!enumerator2.MoveNext())
				{
					return new List<TSource>();
				}
				TStore store = extrema.New();
				extrema.Add(ref store, limit, enumerator2.Current);
				TKey arg = selector(enumerator2.Current);
				while (enumerator2.MoveNext())
				{
					TSource current = enumerator2.Current;
					TKey val = selector(current);
					int num = comparer(val, arg);
					if (num > 0)
					{
						extrema.Restart(ref store);
						extrema.Add(ref store, limit, current);
						arg = val;
					}
					else if (num == 0)
					{
						extrema.Add(ref store, limit, current);
					}
				}
				return extrema.GetEnumerable(store);
			}
		}

		public static IExtremaEnumerable<TSource> MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MinBy(selector, null);
		}

		public static IExtremaEnumerable<TSource> MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			return new ExtremaEnumerable<TSource, TKey>(source, selector, (TKey x, TKey y) => -Math.Sign(comparer.Compare(x, y)));
		}

		internal static int? TryGetCollectionCount<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (!(source is ICollection<T> collection))
			{
				if (!(source is IReadOnlyCollection<T> readOnlyCollection))
				{
					return null;
				}
				return readOnlyCollection.Count;
			}
			return collection.Count;
		}

		private static int CountUpTo<T>(this IEnumerable<T> source, int max)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (max < 0)
			{
				throw new ArgumentOutOfRangeException("max", "The maximum count argument cannot be negative.");
			}
			int i = 0;
			using (IEnumerator<T> enumerator = source.GetEnumerator())
			{
				for (; i < max; i++)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
				}
			}
			return i;
		}

		public static IEnumerable<T> Move<T>(this IEnumerable<T> source, int fromIndex, int count, int toIndex)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (fromIndex < 0)
			{
				throw new ArgumentOutOfRangeException("fromIndex", "The source index cannot be negative.");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Count cannot be negative.");
			}
			if (toIndex < 0)
			{
				throw new ArgumentOutOfRangeException("toIndex", "Target index of range to move cannot be negative.");
			}
			if (toIndex == fromIndex || count == 0)
			{
				return source;
			}
			if (toIndex >= fromIndex)
			{
				return _(fromIndex, count, toIndex - fromIndex);
			}
			return _(toIndex, fromIndex - toIndex, count);
			IEnumerable<T> _(int bufferStartIndex, int bufferSize, int bufferYieldIndex)
			{
				bool hasMore = true;
				using (IEnumerator<T> e = source.GetEnumerator())
				{
					for (int i = 0; i < bufferStartIndex; i++)
					{
						if (!MoveNext(e))
						{
							break;
						}
						yield return e.Current;
					}
					T[] buffer = new T[bufferSize];
					int length;
					for (length = 0; length < bufferSize; length++)
					{
						if (!MoveNext(e))
						{
							break;
						}
						buffer[length] = e.Current;
					}
					for (int i = 0; i < bufferYieldIndex; i++)
					{
						if (!MoveNext(e))
						{
							break;
						}
						yield return e.Current;
					}
					for (int i = 0; i < length; i++)
					{
						yield return buffer[i];
					}
					while (MoveNext(e))
					{
						yield return e.Current;
					}
				}
				bool MoveNext(IEnumerator<T> enumerator)
				{
					if (hasMore)
					{
						return hasMore = enumerator.MoveNext();
					}
					return false;
				}
			}
		}

		private static IEnumerable<Action> NestedLoops(this Action action, IEnumerable<int> loopCounts)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			if (loopCounts == null)
			{
				throw new ArgumentNullException("loopCounts");
			}
			return _();
			IEnumerable<Action> _()
			{
				int count = loopCounts.Assert((int n) => n >= 0, (int n) => new InvalidOperationException("Invalid loop count (must be greater than or equal to zero).")).DefaultIfEmpty().Aggregate((int acc, int x) => acc * x);
				for (int i = 0; i < count; i++)
				{
					yield return action;
				}
			}
		}

		public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
		{
			return source.OrderBy(keySelector, null, direction);
		}

		public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (direction != OrderByDirection.Ascending)
			{
				return source.OrderByDescending(keySelector, comparer);
			}
			return source.OrderBy(keySelector, comparer);
		}

		public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
		{
			return source.ThenBy(keySelector, null, direction);
		}

		public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (direction != OrderByDirection.Ascending)
			{
				return source.ThenByDescending(keySelector, comparer);
			}
			return source.ThenBy(keySelector, comparer);
		}

		public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return first.OrderedMerge(second, null);
		}

		public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second, IComparer<T> comparer)
		{
			return first.OrderedMerge(second, (T e) => e, (T f) => f, (T s) => s, (T a, T _) => a, comparer);
		}

		public static IEnumerable<T> OrderedMerge<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector)
		{
			return first.OrderedMerge(second, keySelector, (T a) => a, (T b) => b, (T a, T _) => a, null);
		}

		public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector)
		{
			return first.OrderedMerge(second, keySelector, firstSelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector, IComparer<TKey> comparer)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.OrderedMerge(second, keySelector, keySelector, firstSelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return first.OrderedMerge(second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IComparer<TKey> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (firstKeySelector == null)
			{
				throw new ArgumentNullException("firstKeySelector");
			}
			if (secondKeySelector == null)
			{
				throw new ArgumentNullException("secondKeySelector");
			}
			if (firstSelector == null)
			{
				throw new ArgumentNullException("firstSelector");
			}
			if (bothSelector == null)
			{
				throw new ArgumentNullException("bothSelector");
			}
			if (secondSelector == null)
			{
				throw new ArgumentNullException("secondSelector");
			}
			return _(comparer ?? Comparer<TKey>.Default);
			IEnumerable<TResult> _(IComparer<TKey> comparer2)
			{
				using IEnumerator<TFirst> e1 = first.GetEnumerator();
				using IEnumerator<TSecond> e2 = second.GetEnumerator();
				bool gotFirst = e1.MoveNext();
				bool gotSecond = e2.MoveNext();
				while (gotFirst || gotSecond)
				{
					if (gotFirst && gotSecond)
					{
						TFirst current = e1.Current;
						TKey x = firstKeySelector(current);
						TSecond current2 = e2.Current;
						TKey y = secondKeySelector(current2);
						int num = comparer2.Compare(x, y);
						if (num < 0)
						{
							yield return firstSelector(current);
							gotFirst = e1.MoveNext();
						}
						else if (num > 0)
						{
							yield return secondSelector(current2);
							gotSecond = e2.MoveNext();
						}
						else
						{
							yield return bothSelector(current, current2);
							gotFirst = e1.MoveNext();
							gotSecond = e2.MoveNext();
						}
					}
					else if (gotSecond)
					{
						yield return secondSelector(e2.Current);
						gotSecond = e2.MoveNext();
					}
					else
					{
						yield return firstSelector(e1.Current);
						gotFirst = e1.MoveNext();
					}
				}
			}
		}

		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width)
		{
			return source.Pad(width, default(TSource));
		}

		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, TSource padding)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (width < 0)
			{
				throw new ArgumentException(null, "width");
			}
			return PadImpl(source, width, padding, null);
		}

		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, Func<int, TSource> paddingSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (paddingSelector == null)
			{
				throw new ArgumentNullException("paddingSelector");
			}
			if (width < 0)
			{
				throw new ArgumentException(null, "width");
			}
			return PadImpl(source, width, default(TSource), paddingSelector);
		}

		private static IEnumerable<T> PadImpl<T>(IEnumerable<T> source, int width, T padding, Func<int, T> paddingSelector)
		{
			int count = 0;
			foreach (T item in source)
			{
				yield return item;
				count++;
			}
			for (; count < width; count++)
			{
				yield return (paddingSelector != null) ? paddingSelector(count) : padding;
			}
		}

		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width)
		{
			return source.PadStart(width, default(TSource));
		}

		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width, TSource padding)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (width < 0)
			{
				throw new ArgumentException(null, "width");
			}
			return PadStartImpl(source, width, padding, null);
		}

		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width, Func<int, TSource> paddingSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (paddingSelector == null)
			{
				throw new ArgumentNullException("paddingSelector");
			}
			if (width < 0)
			{
				throw new ArgumentException(null, "width");
			}
			return PadStartImpl(source, width, default(TSource), paddingSelector);
		}

		private static IEnumerable<T> PadStartImpl<T>(IEnumerable<T> source, int width, T padding, Func<int, T> paddingSelector)
		{
			int? num = source.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				if (valueOrDefault < width)
				{
					return (from i in Enumerable.Range(0, width - valueOrDefault)
						select (paddingSelector == null) ? padding : paddingSelector(i)).Concat(source);
				}
				return source;
			}
			return _();
			IEnumerable<T> _()
			{
				T[] array = new T[width];
				int count = 0;
				using (IEnumerator<T> e = source.GetEnumerator())
				{
					for (; count < width; count++)
					{
						if (!e.MoveNext())
						{
							break;
						}
						array[count] = e.Current;
					}
					if (count == width)
					{
						for (int i = 0; i < count; i++)
						{
							yield return array[i];
						}
						while (e.MoveNext())
						{
							yield return e.Current;
						}
						yield break;
					}
				}
				int len = width - count;
				for (int i = 0; i < len; i++)
				{
					yield return (paddingSelector != null) ? paddingSelector(i) : padding;
				}
				for (int i = 0; i < count; i++)
				{
					yield return array[i];
				}
			}
		}

		public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				using IEnumerator<TSource> e = source.GetEnumerator();
				if (e.MoveNext())
				{
					TSource current = e.Current;
					while (e.MoveNext())
					{
						yield return resultSelector(current, e.Current);
						current = e.Current;
					}
				}
			}
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count)
		{
			return source.PartialSort(count, null);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, OrderByDirection direction)
		{
			return source.PartialSort(count, null, direction);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return PartialSortByImpl<T, T>(source, count, null, null, comparer);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer, OrderByDirection direction)
		{
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			if (direction == OrderByDirection.Descending)
			{
				comparer = new ReverseComparer<T>(comparer);
			}
			return source.PartialSort(count, comparer);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector)
		{
			return source.PartialSortBy(count, keySelector, null);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, OrderByDirection direction)
		{
			return source.PartialSortBy(count, keySelector, null, direction);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return PartialSortByImpl(source, count, keySelector, comparer, null);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			if (direction == OrderByDirection.Descending)
			{
				comparer = new ReverseComparer<TKey>(comparer);
			}
			return source.PartialSortBy(count, keySelector, comparer);
		}

		private static IEnumerable<TSource> PartialSortByImpl<TSource, TKey>(IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> keyComparer, IComparer<TSource> comparer)
		{
			List<TKey> list = ((keySelector != null) ? new List<TKey>(count) : null);
			List<TSource> list2 = new List<TSource>(count);
			foreach (TSource item2 in source)
			{
				TKey item = default(TKey);
				int num;
				if (list != null)
				{
					item = keySelector(item2);
					num = list.BinarySearch(item, keyComparer);
				}
				else
				{
					num = list2.BinarySearch(item2, comparer);
				}
				if (num >= 0 || (num = ~num) < count)
				{
					if (list2.Count == count)
					{
						list?.RemoveAt(list2.Count - 1);
						list2.RemoveAt(list2.Count - 1);
					}
					list?.Insert(num, item);
					list2.Insert(num, item2);
				}
			}
			foreach (TSource item3 in list2)
			{
				yield return item3;
			}
		}

		public static (IEnumerable<T> True, IEnumerable<T> False) Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return source.Partition(predicate, ValueTuple.Create);
		}

		public static TResult Partition<T, TResult>(this IEnumerable<T> source, Func<T, bool> predicate, Func<IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return source.GroupBy(predicate).Partition(resultSelector);
		}

		public static TResult Partition<T, TResult>(this IEnumerable<IGrouping<bool, T>> source, Func<IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.Partition(key1: true, key2: false, (IEnumerable<T> t, IEnumerable<T> f, IEnumerable<IGrouping<bool, T>> _) => resultSelector(t, f));
		}

		public static TResult Partition<T, TResult>(this IEnumerable<IGrouping<bool?, T>> source, Func<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.Partition(true, false, null, (IEnumerable<T> t, IEnumerable<T> f, IEnumerable<T> n, IEnumerable<IGrouping<bool?, T>> _) => resultSelector(t, f, n));
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key, Func<IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return source.Partition(key, null, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return PartitionImpl(source, 1, key, default(TKey), default(TKey), comparer, (IEnumerable<TElement> a, IEnumerable<TElement> b, IEnumerable<TElement> c, IEnumerable<IGrouping<TKey, TElement>> rest) => resultSelector(a, rest));
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return source.Partition(key1, key2, null, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return PartitionImpl(source, 2, key1, key2, default(TKey), comparer, (IEnumerable<TElement> a, IEnumerable<TElement> b, IEnumerable<TElement> c, IEnumerable<IGrouping<TKey, TElement>> rest) => resultSelector(a, b, rest));
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, TKey key3, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return source.Partition(key1, key2, key3, null, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, TKey key3, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return PartitionImpl(source, 3, key1, key2, key3, comparer, resultSelector);
		}

		private static TResult PartitionImpl<TKey, TElement, TResult>(IEnumerable<IGrouping<TKey, TElement>> source, int count, TKey key1, TKey key2, TKey key3, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<TKey>.Default;
			}
			List<IGrouping<TKey, TElement>> list = null;
			IEnumerable<TElement>[] array = new IEnumerable<TElement>[3]
			{
				Enumerable.Empty<TElement>(),
				Enumerable.Empty<TElement>(),
				Enumerable.Empty<TElement>()
			};
			foreach (IGrouping<TKey, TElement> item in source)
			{
				int num = ((count <= 0 || !comparer.Equals(item.Key, key1)) ? ((count > 1 && comparer.Equals(item.Key, key2)) ? 1 : ((count > 2 && comparer.Equals(item.Key, key3)) ? 2 : (-1))) : 0);
				if (num < 0)
				{
					if (list == null)
					{
						list = new List<IGrouping<TKey, TElement>>();
					}
					list.Add(item);
				}
				else
				{
					array[num] = item;
				}
			}
			IEnumerable<TElement> arg = array[0];
			IEnumerable<TElement> arg2 = array[1];
			IEnumerable<TElement> arg3 = array[2];
			IEnumerable<IGrouping<TKey, TElement>> enumerable = list;
			return resultSelector(arg, arg2, arg3, enumerable ?? Enumerable.Empty<IGrouping<TKey, TElement>>());
		}

		public static IEnumerable<IList<T>> Permutations<T>(this IEnumerable<T> sequence)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			return _();
			IEnumerable<IList<T>> _()
			{
				using PermutationEnumerator<T> iter = new PermutationEnumerator<T>(sequence);
				while (iter.MoveNext())
				{
					yield return iter.Current;
				}
			}
		}

		public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			return _();
			IEnumerable<T> _()
			{
				foreach (T item in source)
				{
					action(item);
					yield return item;
				}
			}
		}

		public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource value)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (!(source is PendNode<TSource> pendNode))
			{
				return PendNode<TSource>.WithSource(source).Prepend(value);
			}
			return pendNode.Prepend(value);
		}

		public static IEnumerable<TSource> PreScan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation, TSource identity)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (transformation == null)
			{
				throw new ArgumentNullException("transformation");
			}
			return _();
			IEnumerable<TSource> _()
			{
				TSource aggregator = identity;
				using IEnumerator<TSource> e = source.GetEnumerator();
				if (e.MoveNext())
				{
					yield return aggregator;
					TSource current = e.Current;
					while (e.MoveNext())
					{
						aggregator = transformation(aggregator, current);
						yield return aggregator;
						current = e.Current;
					}
				}
			}
		}

		public static IEnumerable<int> Random()
		{
			return Random(GlobalRandom.Instance);
		}

		public static IEnumerable<int> Random(Random rand)
		{
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			return RandomImpl(rand, (Random r) => r.Next());
		}

		public static IEnumerable<int> Random(int maxValue)
		{
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue");
			}
			return Random(GlobalRandom.Instance, maxValue);
		}

		public static IEnumerable<int> Random(Random rand, int maxValue)
		{
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue");
			}
			return RandomImpl(rand, (Random r) => r.Next(maxValue));
		}

		public static IEnumerable<int> Random(int minValue, int maxValue)
		{
			return Random(GlobalRandom.Instance, minValue, maxValue);
		}

		public static IEnumerable<int> Random(Random rand, int minValue, int maxValue)
		{
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException("minValue", $"The argument minValue ({minValue}) is greater than maxValue ({maxValue})");
			}
			return RandomImpl(rand, (Random r) => r.Next(minValue, maxValue));
		}

		public static IEnumerable<double> RandomDouble()
		{
			return RandomDouble(GlobalRandom.Instance);
		}

		public static IEnumerable<double> RandomDouble(Random rand)
		{
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			return RandomImpl(rand, (Random r) => r.NextDouble());
		}

		private static IEnumerable<T> RandomImpl<T>(Random rand, Func<Random, T> nextValue)
		{
			while (true)
			{
				yield return nextValue(rand);
			}
		}

		public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int subsetSize)
		{
			return source.RandomSubset(subsetSize, new Random());
		}

		public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int subsetSize, Random rand)
		{
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (subsetSize < 0)
			{
				throw new ArgumentOutOfRangeException("subsetSize");
			}
			return RandomSubsetImpl(source, rand, (IEnumerable<T> seq) => (seq.ToArray(), subsetSize));
		}

		private static IEnumerable<T> RandomSubsetImpl<T>(IEnumerable<T> source, Random rand, Func<IEnumerable<T>, (T[], int)> seeder)
		{
			var (array, subsetSize) = seeder(source);
			if (array.Length < subsetSize)
			{
				throw new ArgumentOutOfRangeException("subsetSize", "Subset size must be less than or equal to the source length.");
			}
			int num = 0;
			int num2 = array.Length;
			int num3 = num2 - 1;
			while (num < subsetSize)
			{
				int num4 = num3 - rand.Next(num2);
				T val = array[num4];
				array[num4] = array[num];
				array[num] = val;
				num++;
				num2--;
			}
			for (int i = 0; i < subsetSize; i++)
			{
				yield return array[i];
			}
		}

		public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source)
		{
			return source.RankBy((TSource x) => x);
		}

		public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
		{
			return source.RankBy((TSource x) => x, comparer);
		}

		public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.RankBy(keySelector, null);
		}

		public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return _(comparer ?? Comparer<TKey>.Default);
			IEnumerable<int> _(IComparer<TKey> comparer2)
			{
				source = source.ToArray();
				Dictionary<TSource, int> rankDictionary = source.Distinct().OrderByDescending(keySelector, comparer2).Index(1)
					.ToDictionary((KeyValuePair<int, TSource> item) => item.Value, (KeyValuePair<int, TSource> item) => item.Key);
				foreach (TSource item in source)
				{
					yield return rankDictionary[item];
				}
			}
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence, int count)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Repeat count must be greater than or equal to zero.");
			}
			return RepeatImpl(sequence, count);
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			return RepeatImpl(sequence, null);
		}

		private static IEnumerable<T> RepeatImpl<T>(IEnumerable<T> sequence, int? count)
		{
			IEnumerable<T> memo = sequence.Memoize();
			using (memo as IDisposable)
			{
				while (!count.HasValue || count-- > 0)
				{
					foreach (T item in memo)
					{
						yield return item;
					}
				}
			}
		}

		public static IEnumerable<T> Return<T>(T item)
		{
			return new SingleElementList<T>(item);
		}

		public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.RightJoin(second, keySelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			return first.RightJoin(second, keySelector, keySelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> RightJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return first.RightJoin(second, firstKeySelector, secondKeySelector, secondSelector, bothSelector, null);
		}

		public static IEnumerable<TResult> RightJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (firstKeySelector == null)
			{
				throw new ArgumentNullException("firstKeySelector");
			}
			if (secondKeySelector == null)
			{
				throw new ArgumentNullException("secondKeySelector");
			}
			if (secondSelector == null)
			{
				throw new ArgumentNullException("secondSelector");
			}
			if (bothSelector == null)
			{
				throw new ArgumentNullException("bothSelector");
			}
			return second.LeftJoin(first, secondKeySelector, firstKeySelector, secondSelector, (TSecond x, TFirst y) => bothSelector(y, x), comparer);
		}

		public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence)
		{
			return sequence.RunLengthEncode(null);
		}

		public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comparer)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			return _(comparer ?? EqualityComparer<T>.Default);
			IEnumerable<KeyValuePair<T, int>> _(IEqualityComparer<T> equalityComparer)
			{
				using IEnumerator<T> iter = sequence.GetEnumerator();
				if (iter.MoveNext())
				{
					T current = iter.Current;
					int num = 1;
					while (iter.MoveNext())
					{
						if (equalityComparer.Equals(current, iter.Current))
						{
							num++;
						}
						else
						{
							yield return new KeyValuePair<T, int>(current, num);
							current = iter.Current;
							num = 1;
						}
					}
					yield return new KeyValuePair<T, int>(current, num);
				}
			}
		}

		public static IEnumerable<TSource> Scan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (transformation == null)
			{
				throw new ArgumentNullException("transformation");
			}
			return ScanImpl(source, transformation, (IEnumerator<TSource> e) => (!e.MoveNext()) ? default((bool, TSource)) : (true, e.Current));
		}

		public static IEnumerable<TState> Scan<TSource, TState>(this IEnumerable<TSource> source, TState seed, Func<TState, TSource, TState> transformation)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (transformation == null)
			{
				throw new ArgumentNullException("transformation");
			}
			return ScanImpl(source, transformation, (IEnumerator<TSource> e) => (true, seed));
		}

		private static IEnumerable<TState> ScanImpl<TSource, TState>(IEnumerable<TSource> source, Func<TState, TSource, TState> transformation, Func<IEnumerator<TSource>, (bool, TState)> seeder)
		{
			using IEnumerator<TSource> e = source.GetEnumerator();
			var (flag, aggregator) = seeder(e);
			if (flag)
			{
				yield return aggregator;
				while (e.MoveNext())
				{
					aggregator = transformation(aggregator, e.Current);
					yield return aggregator;
				}
			}
		}

		public static IEnumerable<KeyValuePair<TKey, TState>> ScanBy<TSource, TKey, TState>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TState> seedSelector, Func<TState, TKey, TSource, TState> accumulator)
		{
			return source.ScanBy(keySelector, seedSelector, accumulator, null);
		}

		public static IEnumerable<KeyValuePair<TKey, TState>> ScanBy<TSource, TKey, TState>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TState> seedSelector, Func<TState, TKey, TSource, TState> accumulator, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (seedSelector == null)
			{
				throw new ArgumentNullException("seedSelector");
			}
			if (accumulator == null)
			{
				throw new ArgumentNullException("accumulator");
			}
			return _(comparer ?? EqualityComparer<TKey>.Default);
			IEnumerable<KeyValuePair<TKey, TState>> _(IEqualityComparer<TKey> equalityComparer)
			{
				Dictionary<TKey, TState> stateByKey = new Dictionary<TKey, TState>(equalityComparer);
				(bool, TKey) tuple = (false, default(TKey));
				(bool HasValue, TState Value) nullKeyState = (HasValue: false, Value: default(TState));
				TState state = default(TState);
				foreach (TSource item in source)
				{
					TKey key = keySelector(item);
					if ((!tuple.Item1 || equalityComparer.GetHashCode(tuple.Item2) != equalityComparer.GetHashCode(key) || !equalityComparer.Equals(tuple.Item2, key)) && !TryGetState(key, out state))
					{
						state = seedSelector(key);
					}
					state = accumulator(state, key, item);
					if (key != null)
					{
						stateByKey[key] = state;
					}
					else
					{
						nullKeyState = (HasValue: true, Value: state);
					}
					yield return new KeyValuePair<TKey, TState>(key, state);
					tuple = (true, key);
				}
				bool TryGetState(TKey val, out TState value)
				{
					if (val == null)
					{
						value = nullKeyState.Value;
						return nullKeyState.HasValue;
					}
					return stateByKey.TryGetValue(val, out value);
				}
			}
		}

		public static IEnumerable<TSource> ScanRight<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			return ScanRightImpl<TSource, TSource>(source, func, (Func<IListLike<TSource>, (TSource Seed, int Count)?>)((IListLike<TSource> list) => (list.Count <= 0) ? (((TSource, int)?)null) : new(TSource, int)?((list[list.Count - 1], list.Count - 1))));
		}

		public static IEnumerable<TAccumulate> ScanRight<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			return ScanRightImpl<TSource, TAccumulate>(source, func, (Func<IListLike<TSource>, (TAccumulate Seed, int Count)?>)((IListLike<TSource> list) => (seed, list.Count)));
		}

		private static IEnumerable<TResult> ScanRightImpl<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult, TResult> func, Func<IListLike<TSource>, (TResult Seed, int Count)?> seeder)
		{
			IListLike<TSource> listLike = source.ToListLike();
			(TResult, int)? tuple = seeder(listLike);
			if (!tuple.HasValue)
			{
				yield break;
			}
			TResult val = tuple.Value.Item1;
			int item = tuple.Value.Item2;
			Stack<TResult> stack = new Stack<TResult>(item + 1);
			stack.Push(val);
			while (item-- > 0)
			{
				val = func(listLike[item], val);
				stack.Push(val);
			}
			foreach (TResult item2 in stack)
			{
				yield return item2;
			}
		}

		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, bool> newSegmentPredicate)
		{
			if (newSegmentPredicate == null)
			{
				throw new ArgumentNullException("newSegmentPredicate");
			}
			return source.Segment((T curr, T prev, int index) => newSegmentPredicate(curr));
		}

		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, int, bool> newSegmentPredicate)
		{
			if (newSegmentPredicate == null)
			{
				throw new ArgumentNullException("newSegmentPredicate");
			}
			return source.Segment((T curr, T prev, int index) => newSegmentPredicate(curr, index));
		}

		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, T, int, bool> newSegmentPredicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (newSegmentPredicate == null)
			{
				throw new ArgumentNullException("newSegmentPredicate");
			}
			return _();
			IEnumerable<IEnumerable<T>> _()
			{
				using IEnumerator<T> e = source.GetEnumerator();
				if (e.MoveNext())
				{
					T val = e.Current;
					List<T> list = new List<T> { val };
					int index = 1;
					while (e.MoveNext())
					{
						T current = e.Current;
						if (newSegmentPredicate(current, val, index))
						{
							yield return list;
							list = new List<T> { current };
						}
						else
						{
							list.Add(current);
						}
						val = current;
						index++;
					}
					yield return list;
				}
			}
		}

		public static IEnumerable<int> Sequence(int start, int stop)
		{
			return Sequence(start, stop, (start < stop) ? 1 : (-1));
		}

		public static IEnumerable<int> Sequence(int start, int stop, int step)
		{
			for (long current = start; (step >= 0) ? (stop >= current) : (stop <= current); current += step)
			{
				yield return (int)current;
			}
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.Shuffle(new Random());
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rand)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (rand == null)
			{
				throw new ArgumentNullException("rand");
			}
			return RandomSubsetImpl(source, rand, delegate(IEnumerable<T> seq)
			{
				T[] array = seq.ToArray();
				return (array, array.Length);
			});
		}

		public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 1)
			{
				return source;
			}
			int? num = source.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				return source.Take(valueOrDefault - count);
			}
			return from e in source.CountDown(count, (T e, int? cd) => (Element: e, Countdown: cd)).TakeWhile(((T Element, int? Countdown) e) => !e.Countdown.HasValue)
				select e.Element;
		}

		public static IEnumerable<TSource> SkipUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return _();
			IEnumerable<TSource> _()
			{
				using IEnumerator<TSource> enumerator = source.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (predicate(enumerator.Current))
					{
						while (enumerator.MoveNext())
						{
							yield return enumerator.Current;
						}
						break;
					}
				}
			}
		}

		public static IEnumerable<T> Slice<T>(this IEnumerable<T> sequence, int startIndex, int count)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			IList<T> list = sequence as IList<T>;
			if (list == null)
			{
				IReadOnlyList<T> readOnlyList = sequence as IReadOnlyList<T>;
				if (readOnlyList == null)
				{
					return sequence.Skip(startIndex).Take(count);
				}
				return SliceList(readOnlyList.Count, (int i) => readOnlyList[i]);
			}
			return SliceList(list.Count, (int i) => list[i]);
			IEnumerable<T> SliceList(int listCount, Func<int, T> indexer)
			{
				int countdown = count;
				int index = startIndex;
				while (index < listCount && countdown-- > 0)
				{
					yield return indexer(index++);
				}
			}
		}

		public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, params IEnumerable<TSource>[] otherSequences)
		{
			return source.SortedMerge(direction, null, otherSequences);
		}

		public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, IComparer<TSource> comparer, params IEnumerable<TSource>[] otherSequences)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (otherSequences == null)
			{
				throw new ArgumentNullException("otherSequences");
			}
			if (otherSequences.Length == 0)
			{
				return source;
			}
			if (comparer == null)
			{
				comparer = Comparer<TSource>.Default;
			}
			Func<TSource, TSource, bool> precedenceFunc = ((direction == OrderByDirection.Ascending) ? ((Func<TSource, TSource, bool>)((TSource a, TSource b) => comparer.Compare(b, a) < 0)) : ((Func<TSource, TSource, bool>)((TSource a, TSource b) => comparer.Compare(b, a) > 0)));
			return Impl(new IEnumerable<TSource>[1] { source }.Concat(otherSequences));
			IEnumerable<TSource> Impl(IEnumerable<IEnumerable<TSource>> sequences)
			{
				using DisposableGroup<TSource> disposables = new DisposableGroup<TSource>(sequences.Select((IEnumerable<TSource> e) => e.GetEnumerator()).Acquire());
				List<IEnumerator<TSource>> iterators = disposables.Iterators;
				for (int num = iterators.Count - 1; num >= 0; num--)
				{
					if (!iterators[num].MoveNext())
					{
						disposables.Exclude(num);
					}
				}
				while (iterators.Count > 0)
				{
					int nextIndex = 0;
					TSource val = disposables[0].Current;
					for (int num2 = 1; num2 < iterators.Count; num2++)
					{
						TSource current = disposables[num2].Current;
						if (precedenceFunc(val, current))
						{
							nextIndex = num2;
							val = current;
						}
					}
					yield return val;
					if (!iterators[nextIndex].MoveNext())
					{
						disposables.Exclude(nextIndex);
					}
				}
			}
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator)
		{
			return source.Split(separator, 2147483647);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, int count)
		{
			return source.Split(separator, count, (IEnumerable<TSource> s) => s);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return source.Split(separator, 2147483647, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return source.Split(separator, null, count, resultSelector);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer)
		{
			return source.Split(separator, comparer, 2147483647);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count)
		{
			return source.Split(separator, comparer, count, (IEnumerable<TSource> s) => s);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return source.Split(separator, comparer, 2147483647, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}
			return source.Split((TSource item) => comparer.Equals(item, separator), count, resultSelector);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc)
		{
			return source.Split(separatorFunc, 2147483647);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count)
		{
			return source.Split(separatorFunc, count, (IEnumerable<TSource> s) => s);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return source.Split(separatorFunc, 2147483647, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (separatorFunc == null)
			{
				throw new ArgumentNullException("separatorFunc");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				if (count == 0)
				{
					yield return resultSelector(source);
				}
				else
				{
					List<TSource> list = null;
					foreach (TSource item in source)
					{
						if (count > 0 && separatorFunc(item))
						{
							Func<IEnumerable<TSource>, TResult> func = resultSelector;
							IEnumerable<TSource> enumerable = list;
							yield return func(enumerable ?? Enumerable.Empty<TSource>());
							count--;
							list = null;
						}
						else
						{
							if (list == null)
							{
								list = new List<TSource>();
							}
							list.Add(item);
						}
					}
					if (list != null && list.Count > 0)
					{
						yield return resultSelector(list);
					}
				}
			}
		}

		public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return first.StartsWith(second, null);
		}

		public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			int? num = first.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				num = second.TryGetCollectionCount();
				if (num.HasValue)
				{
					int valueOrDefault2 = num.GetValueOrDefault();
					if (valueOrDefault2 > valueOrDefault)
					{
						return false;
					}
				}
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<T>.Default;
			}
			IEnumerator<T> firstIter = first.GetEnumerator();
			try
			{
				return second.All((T item) => firstIter.MoveNext() && comparer.Equals(firstIter.Current, item));
			}
			finally
			{
				if (firstIter != null)
				{
					firstIter.Dispose();
				}
			}
		}

		public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			return _();
			IEnumerable<IList<T>> _()
			{
				List<T> sequenceAsList = sequence.ToList();
				int sequenceLength = sequenceAsList.Count;
				yield return new List<T>();
				if (sequenceLength > 0)
				{
					for (int i = 1; i < sequenceLength; i++)
					{
						SubsetGenerator<T> subsetGenerator = new SubsetGenerator<T>(sequenceAsList, i);
						foreach (IList<T> item in subsetGenerator)
						{
							yield return item;
						}
					}
					yield return sequenceAsList;
				}
			}
		}

		public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence, int subsetSize)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (subsetSize < 0)
			{
				throw new ArgumentOutOfRangeException("subsetSize", "Subset size must be >= 0");
			}
			return new SubsetGenerator<T>(sequence, subsetSize);
		}

		public static IEnumerable<TResult> TagFirstLast<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool, bool, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.Index().CountDown(1, (KeyValuePair<int, TSource> e, int? cd) => resultSelector(e.Value, e.Key == 0, cd == 0));
		}

		public static IEnumerable<TSource> TakeEvery<TSource>(this IEnumerable<TSource> source, int step)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (step <= 0)
			{
				throw new ArgumentOutOfRangeException("step");
			}
			return source.Where((TSource e, int i) => i % step == 0);
		}

		public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 1)
			{
				return Enumerable.Empty<TSource>();
			}
			int? num = source.TryGetCollectionCount();
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				return source.Slice(Math.Max(0, valueOrDefault - count), 2147483647);
			}
			return from e in source.CountDown(count, (TSource e, int? cd) => (Element: e, Countdown: cd)).SkipWhile(((TSource Element, int? Countdown) e) => !e.Countdown.HasValue)
				select e.Element;
		}

		public static IEnumerable<TSource> TakeUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return _();
			IEnumerable<TSource> _()
			{
				foreach (TSource item in source)
				{
					yield return item;
					if (predicate(item))
					{
						yield break;
					}
				}
			}
		}

		public static T[] ToArrayByIndex<T>(this IEnumerable<T> source, Func<T, int> indexSelector)
		{
			return source.ToArrayByIndex(indexSelector, (T e, int _) => e);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, Func<T, int> indexSelector, Func<T, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.ToArrayByIndex(indexSelector, (T e, int _) => resultSelector(e));
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, Func<T, int> indexSelector, Func<T, int, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (indexSelector == null)
			{
				throw new ArgumentNullException("indexSelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			int num = -1;
			List<KeyValuePair<int, T>> indexed = null;
			foreach (T item in source)
			{
				int num2 = indexSelector(item);
				if (num2 < 0)
				{
					throw new IndexOutOfRangeException();
				}
				num = Math.Max(num2, num);
				Indexed().Add(new KeyValuePair<int, T>(num2, item));
			}
			int num3 = num + 1;
			if (num3 != 0)
			{
				return Indexed().ToArrayByIndex(num3, (KeyValuePair<int, T> e) => e.Key, (KeyValuePair<int, T> e) => resultSelector(e.Value, e.Key));
			}
			return new TResult[0];
			List<KeyValuePair<int, T>> Indexed()
			{
				return indexed ?? (indexed = new List<KeyValuePair<int, T>>());
			}
		}

		public static T[] ToArrayByIndex<T>(this IEnumerable<T> source, int length, Func<T, int> indexSelector)
		{
			return source.ToArrayByIndex(length, indexSelector, (T e, int _) => e);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, int length, Func<T, int> indexSelector, Func<T, TResult> resultSelector)
		{
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return source.ToArrayByIndex(length, indexSelector, (T e, int _) => resultSelector(e));
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, int length, Func<T, int> indexSelector, Func<T, int, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if (indexSelector == null)
			{
				throw new ArgumentNullException("indexSelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			TResult[] array = new TResult[length];
			foreach (T item in source)
			{
				int num = indexSelector(item);
				if (num < 0 || num > array.Length)
				{
					throw new IndexOutOfRangeException();
				}
				array[num] = resultSelector(item, num);
			}
			return array;
		}

		public static TTable ToDataTable<T, TTable>(this IEnumerable<T> source, TTable table) where TTable : DataTable
		{
			return source.ToDataTable(table, (Expression<Func<T, object>>[])null);
		}

		public static DataTable ToDataTable<T>(this IEnumerable<T> source, params Expression<Func<T, object>>[] expressions)
		{
			return source.ToDataTable(new DataTable(), expressions);
		}

		public static DataTable ToDataTable<T>(this IEnumerable<T> source)
		{
			return source.ToDataTable(new DataTable());
		}

		public static TTable ToDataTable<T, TTable>(this IEnumerable<T> source, TTable table, params Expression<Func<T, object>>[] expressions) where TTable : DataTable
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			MemberInfo[] members = PrepareMemberInfos(expressions).ToArray();
			members = BuildOrBindSchema(table, members);
			Func<T, object[]> func = CreateShredder<T>(members);
			table.BeginLoadData();
			try
			{
				foreach (T item in source)
				{
					DataRow dataRow = table.NewRow();
					dataRow.ItemArray = func(item);
					table.Rows.Add(dataRow);
				}
			}
			finally
			{
				table.EndLoadData();
			}
			return table;
		}

		private static IEnumerable<MemberInfo> PrepareMemberInfos<T>(ICollection<Expression<Func<T, object>>> expressions)
		{
			if (expressions == null || expressions.Count == 0)
			{
				return from m in typeof(T).GetMembers(BindingFlags.Instance | BindingFlags.Public)
					where m.MemberType == MemberTypes.Field || (m is PropertyInfo { CanRead: not false } propertyInfo && propertyInfo.GetIndexParameters().Length == 0)
					select m;
			}
			if (expressions.Any((Expression<Func<T, object>> e) => e == null))
			{
				throw new ArgumentException("One of the supplied expressions was null.", "expressions");
			}
			try
			{
				return expressions.Select(GetAccessedMember);
			}
			catch (ArgumentException innerException)
			{
				throw new ArgumentException("One of the supplied expressions is not allowed.", "expressions", innerException);
			}
			static MemberInfo GetAccessedMember(LambdaExpression lambda)
			{
				Expression expression = lambda.Body;
				if (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
				{
					expression = ((UnaryExpression)expression).Operand;
				}
				if (!(expression is MemberExpression memberExpression) || memberExpression.Expression.NodeType != ExpressionType.Parameter)
				{
					throw new ArgumentException($"Illegal expression: {lambda}", "lambda");
				}
				return memberExpression.Member;
			}
		}

		private static MemberInfo[] BuildOrBindSchema(DataTable table, MemberInfo[] members)
		{
			DataColumnCollection columns = table.Columns;
			var enumerable = from m in members
				let type = (m.MemberType == MemberTypes.Property) ? ((PropertyInfo)m).PropertyType : ((FieldInfo)m).FieldType
				select new
				{
					Member = m,
					Type = ((type.IsGenericType && typeof(Nullable<>) == type.GetGenericTypeDefinition()) ? type.GetGenericArguments()[0] : type),
					Column = columns[m.Name]
				};
			if (columns.Count == 0)
			{
				columns.AddRange(enumerable.Select(m => new DataColumn(m.Member.Name, m.Type)).ToArray());
			}
			else
			{
				members = new MemberInfo[columns.Count];
				foreach (var item in enumerable)
				{
					MemberInfo member = item.Member;
					DataColumn column = item.Column;
					if (column == null)
					{
						throw new ArgumentException("Column named '" + member.Name + "' is missing.", "table");
					}
					if (item.Type != column.DataType)
					{
						throw new ArgumentException($"Column named '{member.Name}' has wrong data type. It should be {item.Type} when it is {column.DataType}.", "table");
					}
					members[column.Ordinal] = member;
				}
			}
			return members;
		}

		private static Func<T, object[]> CreateShredder<T>(IEnumerable<MemberInfo> members)
		{
			ParameterExpression parameter = Expression.Parameter(typeof(T), "e");
			IEnumerable<Expression> initializers = members.Select((MemberInfo m) => (!(m != null)) ? ((Expression)Expression.Constant(null, typeof(object))) : ((Expression)CreateMemberAccessor(m)));
			return Expression.Lambda<Func<T, object[]>>(Expression.NewArrayInit(typeof(object), initializers), new ParameterExpression[1] { parameter }).Compile();
			UnaryExpression CreateMemberAccessor(MemberInfo member)
			{
				return Expression.Convert(Expression.MakeMemberAccess(parameter, member), typeof(object));
			}
		}

		public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, (StringBuilder sb, TSource e) => sb.Append(e));
		}

		private static string ToDelimitedStringImpl<T>(IEnumerable<T> source, string delimiter, Func<StringBuilder, T, StringBuilder> append)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (T item in source)
			{
				if (num++ > 0)
				{
					stringBuilder.Append(delimiter);
				}
				append(stringBuilder, item);
			}
			return stringBuilder.ToString();
		}

		public static string ToDelimitedString(this IEnumerable<bool> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Boolean);
		}

		public static string ToDelimitedString(this IEnumerable<byte> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Byte);
		}

		public static string ToDelimitedString(this IEnumerable<char> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Char);
		}

		public static string ToDelimitedString(this IEnumerable<decimal> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Decimal);
		}

		public static string ToDelimitedString(this IEnumerable<double> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Double);
		}

		public static string ToDelimitedString(this IEnumerable<float> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Single);
		}

		public static string ToDelimitedString(this IEnumerable<int> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Int32);
		}

		public static string ToDelimitedString(this IEnumerable<long> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Int64);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<sbyte> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.SByte);
		}

		public static string ToDelimitedString(this IEnumerable<short> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.Int16);
		}

		public static string ToDelimitedString(this IEnumerable<string> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.String);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<uint> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.UInt32);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<ulong> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.UInt64);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<ushort> source, string delimiter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (delimiter == null)
			{
				throw new ArgumentNullException("delimiter");
			}
			return ToDelimitedStringImpl(source, delimiter, StringBuilderAppenders.UInt16);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return source.ToDictionary(null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.ToDictionary((KeyValuePair<TKey, TValue> e) => e.Key, (KeyValuePair<TKey, TValue> e) => e.Value, comparer);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source)
		{
			return source.ToDictionary(null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.ToDictionary(((TKey Key, TValue Value) e) => e.Key, ((TKey Key, TValue Value) e) => e.Value, comparer);
		}

		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
		{
			return source.ToHashSet(null);
		}

		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new HashSet<TSource>(source, comparer);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return source.ToLookup(null);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.ToLookup((KeyValuePair<TKey, TValue> e) => e.Key, (KeyValuePair<TKey, TValue> e) => e.Value, comparer);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source)
		{
			return source.ToLookup(null);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.ToLookup(((TKey Key, TValue Value) e) => e.Key, ((TKey Key, TValue Value) e) => e.Value, comparer);
		}

		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source)
		{
			return source.Trace((string)null);
		}

		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, string format)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return TraceImpl(source, string.IsNullOrEmpty(format) ? ((Func<TSource, string>)((TSource x) => (x != null) ? x.ToString() : string.Empty)) : ((Func<TSource, string>)((TSource x) => string.Format(format, x))));
		}

		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, Func<TSource, string> formatter)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (formatter == null)
			{
				throw new ArgumentNullException("formatter");
			}
			return TraceImpl(source, formatter);
		}

		private static IEnumerable<TSource> TraceImpl<TSource>(IEnumerable<TSource> source, Func<TSource, string> formatter)
		{
			return source.Pipe(delegate(TSource x)
			{
				System.Diagnostics.Trace.WriteLine(formatter(x));
			});
		}

		public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return _();
			IEnumerable<IEnumerable<T>> _()
			{
				IEnumerator<T>[] enumerators = source.Select((IEnumerable<T> e) => e.GetEnumerator()).Acquire();
				try
				{
					while (true)
					{
						T[] array = new T[enumerators.Length];
						int num = 0;
						for (int num2 = 0; num2 < enumerators.Length; num2++)
						{
							if (enumerators[num2] != null)
							{
								if (enumerators[num2].MoveNext())
								{
									array[num++] = enumerators[num2].Current;
								}
								else
								{
									enumerators[num2].Dispose();
									enumerators[num2] = null;
								}
							}
						}
						if (num == 0)
						{
							break;
						}
						Array.Resize(ref array, num);
						yield return array;
					}
				}
				finally
				{
					IEnumerator<T>[] array2 = enumerators;
					for (int num3 = 0; num3 < array2.Length; num3++)
					{
						array2[num3]?.Dispose();
					}
				}
			}
		}

		public static IEnumerable<T> TraverseBreadthFirst<T>(T root, Func<T, IEnumerable<T>> childrenSelector)
		{
			if (childrenSelector == null)
			{
				throw new ArgumentNullException("childrenSelector");
			}
			return _();
			IEnumerable<T> _()
			{
				Queue<T> queue = new Queue<T>();
				queue.Enqueue(root);
				while (queue.Count != 0)
				{
					T current = queue.Dequeue();
					yield return current;
					foreach (T item in childrenSelector(current))
					{
						queue.Enqueue(item);
					}
				}
			}
		}

		public static IEnumerable<T> TraverseDepthFirst<T>(T root, Func<T, IEnumerable<T>> childrenSelector)
		{
			if (childrenSelector == null)
			{
				throw new ArgumentNullException("childrenSelector");
			}
			return _();
			IEnumerable<T> _()
			{
				Stack<T> stack = new Stack<T>();
				stack.Push(root);
				while (stack.Count != 0)
				{
					T current = stack.Pop();
					yield return current;
					foreach (T item in childrenSelector(current).Reverse())
					{
						stack.Push(item);
					}
				}
			}
		}

		public static IEnumerable<TResult> Unfold<TState, T, TResult>(TState state, Func<TState, T> generator, Func<T, bool> predicate, Func<T, TState> stateSelector, Func<T, TResult> resultSelector)
		{
			if (generator == null)
			{
				throw new ArgumentNullException("generator");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (stateSelector == null)
			{
				throw new ArgumentNullException("stateSelector");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return _();
			IEnumerable<TResult> _()
			{
				while (true)
				{
					T step = generator(state);
					if (!predicate(step))
					{
						break;
					}
					yield return resultSelector(step);
					state = stateSelector(step);
				}
			}
		}

		public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			return _();
			IEnumerable<IList<TSource>> _()
			{
				using IEnumerator<TSource> iter = source.GetEnumerator();
				TSource[] array = new TSource[size];
				int i;
				for (i = 0; i < size; i++)
				{
					if (!iter.MoveNext())
					{
						break;
					}
					array[i] = iter.Current;
				}
				if (i >= size)
				{
					while (iter.MoveNext())
					{
						TSource[] newWindow = new TSource[size];
						Array.Copy(array, 1, newWindow, 0, size - 1);
						newWindow[size - 1] = iter.Current;
						yield return array;
						array = newWindow;
					}
					yield return array;
				}
			}
		}

		[Obsolete("Use Window instead.")]
		public static IEnumerable<IEnumerable<TSource>> Windowed<TSource>(this IEnumerable<TSource> source, int size)
		{
			return source.Window(size);
		}

		public static IEnumerable<IList<TSource>> WindowLeft<TSource>(this IEnumerable<TSource> source, int size)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			return _();
			IEnumerable<IList<TSource>> _()
			{
				List<TSource> list = new List<TSource>();
				foreach (TSource item in source)
				{
					list.Add(item);
					if (list.Count >= size)
					{
						List<TSource> nextWindow = new List<TSource>(list.Skip(1));
						yield return list;
						list = nextWindow;
					}
				}
				while (list.Count > 0)
				{
					List<TSource> nextWindow = new List<TSource>(list.Skip(1));
					yield return list;
					list = nextWindow;
				}
			}
		}

		public static IEnumerable<IList<TSource>> WindowRight<TSource>(this IEnumerable<TSource> source, int size)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			return source.WindowRightWhile((TSource _, int i) => i < size);
		}

		private static IEnumerable<IList<TSource>> WindowRightWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return _();
			IEnumerable<IList<TSource>> _()
			{
				List<TSource> list = new List<TSource>();
				foreach (TSource item in source)
				{
					list.Add(item);
					IEnumerable<TSource> collection;
					if (!predicate(item, list.Count))
					{
						collection = list.Skip(1);
					}
					else
					{
						IEnumerable<TSource> enumerable = list;
						collection = enumerable;
					}
					List<TSource> nextWindow = new List<TSource>(collection);
					yield return list;
					list = nextWindow;
				}
			}
		}

		private static IEnumerable<TResult> ZipImpl<T1, T2, T3, T4, TResult>(IEnumerable<T1> s1, IEnumerable<T2> s2, IEnumerable<T3> s3, IEnumerable<T4> s4, Func<T1, T2, T3, T4, TResult> resultSelector, int limit, Folder<IEnumerator, Exception> errorSelector = null)
		{
			IEnumerator<T1> e1 = null;
			IEnumerator<T2> e2 = null;
			IEnumerator<T3> e3 = null;
			IEnumerator<T4> e4 = null;
			int terminations = 0;
			try
			{
				e1 = s1.GetEnumerator();
				e2 = s2.GetEnumerator();
				e3 = s3?.GetEnumerator();
				e4 = s4?.GetEnumerator();
				while (true)
				{
					int num = 0;
					T1 arg = Read<T1>(ref e1, ++num);
					T2 arg2 = Read<T2>(ref e2, ++num);
					T3 arg3 = Read<T3>(ref e3, ++num);
					T4 arg4 = Read<T4>(ref e4, num + 1);
					if (terminations <= limit)
					{
						yield return resultSelector(arg, arg2, arg3, arg4);
						continue;
					}
					break;
				}
			}
			finally
			{
				e1?.Dispose();
				e2?.Dispose();
				e3?.Dispose();
				e4?.Dispose();
				T Read<T>(ref IEnumerator<T> reference, int n)
				{
					if (reference == null || terminations > limit)
					{
						return default(T);
					}
					T result;
					if (reference.MoveNext())
					{
						result = reference.Current;
					}
					else
					{
						reference.Dispose();
						reference = null;
						terminations++;
						result = default(T);
					}
					if (errorSelector != null && terminations > 0 && terminations < n)
					{
						throw errorSelector(e1, e2, e3, e4);
					}
					return result;
				}
			}
		}

		public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, null, null, (TFirst a, TSecond b, object c, object d) => resultSelector(a, b), 1);
		}

		public static IEnumerable<TResult> ZipLongest<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, third, null, (T1 a, T2 b, T3 c, object d) => resultSelector(a, b, c), 2);
		}

		public static IEnumerable<TResult> ZipLongest<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, third, fourth, resultSelector, 3);
		}

		public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, null, null, (TFirst a, TSecond b, object c, object d) => resultSelector(a, b));
		}

		public static IEnumerable<TResult> ZipShortest<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, third, null, (T1 a, T2 b, T3 c, object _) => resultSelector(a, b, c));
		}

		public static IEnumerable<TResult> ZipShortest<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (second == null)
			{
				throw new ArgumentNullException("second");
			}
			if (third == null)
			{
				throw new ArgumentNullException("third");
			}
			if (fourth == null)
			{
				throw new ArgumentNullException("fourth");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			return ZipImpl(first, second, third, fourth, resultSelector);
		}

		private static IEnumerable<TResult> ZipImpl<T1, T2, T3, T4, TResult>(IEnumerable<T1> s1, IEnumerable<T2> s2, IEnumerable<T3> s3, IEnumerable<T4> s4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return ZipImpl(s1, s2, s3, s4, resultSelector, 0);
		}
	}
	internal static class Disposable
	{
		public static readonly IDisposable Nop = Delegating.Delegate.Disposable(delegate
		{
		});
	}
	internal interface IListLike<out T>
	{
		int Count { get; }

		T this[int index] { get; }
	}
	internal static class ListLike
	{
		private sealed class List<T> : IListLike<T>
		{
			private readonly IList<T> _list;

			public int Count => _list.Count;

			public T this[int index] => _list[index];

			public List(IList<T> list)
			{
				_list = list ?? throw new ArgumentNullException("list");
			}
		}

		private sealed class ReadOnlyList<T> : IListLike<T>
		{
			private readonly IReadOnlyList<T> _list;

			public int Count => _list.Count;

			public T this[int index] => _list[index];

			public ReadOnlyList(IReadOnlyList<T> list)
			{
				_list = list ?? throw new ArgumentNullException("list");
			}
		}

		public static IListLike<T> ToListLike<T>(this IEnumerable<T> source)
		{
			return source.TryAsListLike() ?? new List<T>(source.ToList());
		}

		public static IListLike<T> TryAsListLike<T>(this IEnumerable<T> source)
		{
			if (source != null)
			{
				if (!(source is IList<T> list))
				{
					if (!(source is IReadOnlyList<T> list2))
					{
						return null;
					}
					return new ReadOnlyList<T>(list2);
				}
				return new List<T>(list);
			}
			throw new ArgumentNullException("source");
		}
	}
	internal class Lookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, IEnumerable, ILookup<TKey, TElement>
	{
		private IEqualityComparer<TKey> _comparer;

		private Grouping<TKey, TElement>[] _groupings;

		private Grouping<TKey, TElement> _lastGrouping;

		private int _count;

		public int Count => _count;

		public IEnumerable<TElement> this[TKey key]
		{
			get
			{
				Grouping<TKey, TElement> grouping = GetGrouping(key, create: false);
				if (grouping != null)
				{
					return grouping;
				}
				return Enumerable.Empty<TElement>();
			}
		}

		internal static Lookup<TKey, TElement> Create<TSource>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			if (elementSelector == null)
			{
				throw new ArgumentNullException("elementSelector");
			}
			Lookup<TKey, TElement> lookup = new Lookup<TKey, TElement>(comparer);
			foreach (TSource item in source)
			{
				lookup.GetGrouping(keySelector(item), create: true).Add(elementSelector(item));
			}
			return lookup;
		}

		internal static Lookup<TKey, TElement> CreateForJoin(IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			Lookup<TKey, TElement> lookup = new Lookup<TKey, TElement>(comparer);
			foreach (TElement item in source)
			{
				TKey val = keySelector(item);
				if (val != null)
				{
					lookup.GetGrouping(val, create: true).Add(item);
				}
			}
			return lookup;
		}

		private Lookup(IEqualityComparer<TKey> comparer)
		{
			if (comparer == null)
			{
				comparer = EqualityComparer<TKey>.Default;
			}
			_comparer = comparer;
			_groupings = new Grouping<TKey, TElement>[7];
		}

		public bool Contains(TKey key)
		{
			if (_count > 0)
			{
				return GetGrouping(key, create: false) != null;
			}
			return false;
		}

		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			Grouping<TKey, TElement> g = _lastGrouping;
			if (g != null)
			{
				do
				{
					g = g.next;
					yield return g;
				}
				while (g != _lastGrouping);
			}
		}

		public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		{
			Grouping<TKey, TElement> g = _lastGrouping;
			if (g == null)
			{
				yield break;
			}
			do
			{
				g = g.next;
				if (g.count != g.elements.Length)
				{
					Array.Resize(ref g.elements, g.count);
				}
				yield return resultSelector(g.key, g.elements);
			}
			while (g != _lastGrouping);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		internal int InternalGetHashCode(TKey key)
		{
			if (key != null)
			{
				return _comparer.GetHashCode(key) & 0x7FFFFFFF;
			}
			return 0;
		}

		internal Grouping<TKey, TElement> GetGrouping(TKey key, bool create)
		{
			int num = InternalGetHashCode(key);
			for (Grouping<TKey, TElement> grouping = _groupings[num % _groupings.Length]; grouping != null; grouping = grouping.hashNext)
			{
				if (grouping.hashCode == num && _comparer.Equals(grouping.key, key))
				{
					return grouping;
				}
			}
			if (create)
			{
				if (_count == _groupings.Length)
				{
					Resize();
				}
				int num2 = num % _groupings.Length;
				Grouping<TKey, TElement> grouping2 = new Grouping<TKey, TElement>();
				grouping2.key = key;
				grouping2.hashCode = num;
				grouping2.elements = new TElement[1];
				grouping2.hashNext = _groupings[num2];
				_groupings[num2] = grouping2;
				if (_lastGrouping == null)
				{
					grouping2.next = grouping2;
				}
				else
				{
					grouping2.next = _lastGrouping.next;
					_lastGrouping.next = grouping2;
				}
				_lastGrouping = grouping2;
				_count++;
				return grouping2;
			}
			return null;
		}

		private void Resize()
		{
			int num = checked(_count * 2 + 1);
			Grouping<TKey, TElement>[] array = new Grouping<TKey, TElement>[num];
			Grouping<TKey, TElement> grouping = _lastGrouping;
			do
			{
				grouping = grouping.next;
				int num2 = grouping.hashCode % num;
				grouping.hashNext = array[num2];
				array[num2] = grouping;
			}
			while (grouping != _lastGrouping);
			_groupings = array;
		}
	}
	internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IList<TElement>, ICollection<TElement>
	{
		internal TKey key;

		internal int hashCode;

		internal TElement[] elements;

		internal int count;

		internal Grouping<TKey, TElement> hashNext;

		internal Grouping<TKey, TElement> next;

		public TKey Key => key;

		int ICollection<TElement>.Count => count;

		bool ICollection<TElement>.IsReadOnly => true;

		TElement IList<TElement>.this[int index]
		{
			get
			{
				if (index < 0 || index >= count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return elements[index];
			}
			set
			{
				throw new NotSupportedException("Lookup is immutable");
			}
		}

		internal Grouping()
		{
		}

		internal void Add(TElement element)
		{
			if (elements.Length == count)
			{
				Array.Resize(ref elements, checked(count * 2));
			}
			elements[count] = element;
			count++;
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
			{
				yield return elements[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void ICollection<TElement>.Add(TElement item)
		{
			throw new NotSupportedException("Lookup is immutable");
		}

		void ICollection<TElement>.Clear()
		{
			throw new NotSupportedException("Lookup is immutable");
		}

		bool ICollection<TElement>.Contains(TElement item)
		{
			return Array.IndexOf(elements, item, 0, count) >= 0;
		}

		void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex)
		{
			Array.Copy(elements, 0, array, arrayIndex, count);
		}

		bool ICollection<TElement>.Remove(TElement item)
		{
			throw new NotSupportedException("Lookup is immutable");
		}

		int IList<TElement>.IndexOf(TElement item)
		{
			return Array.IndexOf(elements, item, 0, count);
		}

		void IList<TElement>.Insert(int index, TElement item)
		{
			throw new NotSupportedException("Lookup is immutable");
		}

		void IList<TElement>.RemoveAt(int index)
		{
			throw new NotSupportedException("Lookup is immutable");
		}
	}
	public interface IExtremaEnumerable<out T> : IEnumerable<T>, IEnumerable
	{
		IEnumerable<T> Take(int count);

		IEnumerable<T> TakeLast(int count);
	}
	public enum OrderByDirection
	{
		Ascending,
		Descending
	}
	internal abstract class PendNode<T> : IEnumerable<T>, IEnumerable
	{
		private sealed class Item : PendNode<T>
		{
			public T Value { get; }

			public bool IsPrepend { get; }

			public int ConcatCount { get; }

			public PendNode<T> Next { get; }

			public Item(T item, bool isPrepend, PendNode<T> next)
			{
				if (next == null)
				{
					throw new ArgumentNullException("next");
				}
				Value = item;
				IsPrepend = isPrepend;
				ConcatCount = ((!(next is Item { ConcatCount: var concatCount })) ? 1 : (concatCount + ((!isPrepend) ? 1 : 0)));
				Next = next;
			}
		}

		private sealed class Source : PendNode<T>
		{
			public IEnumerable<T> Value { get; }

			public Source(IEnumerable<T> source)
			{
				Value = source;
			}
		}

		public static PendNode<T> WithSource(IEnumerable<T> source)
		{
			return new Source(source);
		}

		public PendNode<T> Prepend(T item)
		{
			return new Item(item, isPrepend: true, this);
		}

		public PendNode<T> Concat(T item)
		{
			return new Item(item, isPrepend: false, this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			int i = 0;
			T[] concats = null;
			T concat1 = default(T);
			T concat2 = default(T);
			T concat3 = default(T);
			T concat4 = default(T);
			PendNode<T> pendNode;
			for (pendNode = this; pendNode is Item item; pendNode = item.Next)
			{
				if (item.IsPrepend)
				{
					yield return item.Value;
					continue;
				}
				if (concats == null)
				{
					if (i != 0 || item.ConcatCount <= 4)
					{
						switch (i++)
						{
						case 0:
							concat1 = item.Value;
							break;
						case 1:
							concat2 = item.Value;
							break;
						case 2:
							concat3 = item.Value;
							break;
						case 3:
							concat4 = item.Value;
							break;
						default:
							throw new IndexOutOfRangeException();
						}
						continue;
					}
					concats = new T[item.ConcatCount];
				}
				concats[i++] = item.Value;
			}
			Source source = (Source)pendNode;
			foreach (T item2 in source.Value)
			{
				yield return item2;
			}
			if (concats == null)
			{
				if (i == 4)
				{
					yield return concat4;
					i--;
				}
				if (i == 3)
				{
					yield return concat3;
					i--;
				}
				if (i == 2)
				{
					yield return concat2;
					i--;
				}
				if (i == 1)
				{
					yield return concat1;
				}
			}
			else
			{
				for (i--; i >= 0; i--)
				{
					yield return concats[i];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	internal sealed class ReverseComparer<T> : IComparer<T>
	{
		private readonly IComparer<T> _underlying;

		public ReverseComparer(IComparer<T> underlying)
		{
			_underlying = underlying ?? Comparer<T>.Default;
		}

		public int Compare(T x, T y)
		{
			int num = _underlying.Compare(x, y);
			if (num >= 0)
			{
				if (num <= 0)
				{
					return 0;
				}
				return -1;
			}
			return 1;
		}
	}
	[Serializable]
	public class SequenceException : Exception
	{
		private const string DefaultMessage = "Error in sequence.";

		public SequenceException()
			: this(null)
		{
		}

		public SequenceException(string message)
			: this(message, null)
		{
		}

		public SequenceException(string message, Exception innerException)
			: base(string.IsNullOrEmpty(message) ? "Error in sequence." : message, innerException)
		{
		}

		protected SequenceException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
namespace MoreLinq.Reactive
{
	internal static class Observable
	{
		public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError = null, Action onCompleted = null)
		{
			if (source != null)
			{
				return source.Subscribe(Delegating.Delegate.Observer(onNext, onError, onCompleted));
			}
			throw new ArgumentNullException("source");
		}
	}
	internal sealed class Subject<T> : IObservable<T>, IObserver<T>
	{
		private List<IObserver<T>> _observers;

		private bool _completed;

		private Exception _error;

		private bool _shouldDeleteObserver;

		private bool HasObservers => (_observers?.Count ?? 0) > 0;

		private List<IObserver<T>> Observers => _observers ?? (_observers = new List<IObserver<T>>());

		private bool IsMuted
		{
			get
			{
				if (!_completed)
				{
					return _error != null;
				}
				return true;
			}
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (observer == null)
			{
				throw new ArgumentNullException("observer");
			}
			if (_error != null)
			{
				observer.OnError(_error);
				return Disposable.Nop;
			}
			if (_completed)
			{
				observer.OnCompleted();
				return Disposable.Nop;
			}
			Observers.Add(observer);
			return Delegating.Delegate.Disposable(delegate
			{
				List<IObserver<T>> observers = Observers;
				for (int i = 0; i < observers.Count; i++)
				{
					if (observers[i] == observer)
					{
						if (_shouldDeleteObserver)
						{
							observers[i] = null;
						}
						else
						{
							observers.RemoveAt(i);
						}
						break;
					}
				}
			});
		}

		public void OnNext(T value)
		{
			if (!HasObservers)
			{
				return;
			}
			List<IObserver<T>> observers = Observers;
			_shouldDeleteObserver = true;
			try
			{
				for (int i = 0; i < observers.Count; i++)
				{
					observers[i].OnNext(value);
				}
			}
			finally
			{
				_shouldDeleteObserver = false;
				observers.RemoveAll((IObserver<T> o) => o == null);
			}
		}

		public void OnError(Exception error)
		{
			OnFinality(ref _error, error, delegate(IObserver<T> observer, Exception err)
			{
				observer.OnError(err);
			});
		}

		public void OnCompleted()
		{
			OnFinality(ref _completed, value: true, delegate(IObserver<T> observer, bool _)
			{
				observer.OnCompleted();
			});
		}

		private void OnFinality<TState>(ref TState state, TState value, Action<IObserver<T>, TState> action)
		{
			if (IsMuted)
			{
				return;
			}
			state = value;
			List<IObserver<T>> observers = _observers;
			_observers = null;
			if (observers == null)
			{
				return;
			}
			foreach (IObserver<T> item in observers)
			{
				action(item, value);
			}
		}
	}
}
namespace MoreLinq.Extensions
{
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AcquireExtension
	{
		public static TSource[] Acquire<TSource>(this IEnumerable<TSource> source) where TSource : IDisposable
		{
			return MoreEnumerable.Acquire(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AggregateExtension
	{
		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, Func<TAccumulate1, TAccumulate2, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, Func<TAccumulate1, TAccumulate2, TAccumulate3, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, seed4, accumulator4, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, seed4, accumulator4, seed5, accumulator5, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, seed4, accumulator4, seed5, accumulator5, seed6, accumulator6, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, TAccumulate7 seed7, Func<TAccumulate7, T, TAccumulate7> accumulator7, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, seed4, accumulator4, seed5, accumulator5, seed6, accumulator6, seed7, accumulator7, resultSelector);
		}

		public static TResult Aggregate<T, TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TAccumulate8, TResult>(this IEnumerable<T> source, TAccumulate1 seed1, Func<TAccumulate1, T, TAccumulate1> accumulator1, TAccumulate2 seed2, Func<TAccumulate2, T, TAccumulate2> accumulator2, TAccumulate3 seed3, Func<TAccumulate3, T, TAccumulate3> accumulator3, TAccumulate4 seed4, Func<TAccumulate4, T, TAccumulate4> accumulator4, TAccumulate5 seed5, Func<TAccumulate5, T, TAccumulate5> accumulator5, TAccumulate6 seed6, Func<TAccumulate6, T, TAccumulate6> accumulator6, TAccumulate7 seed7, Func<TAccumulate7, T, TAccumulate7> accumulator7, TAccumulate8 seed8, Func<TAccumulate8, T, TAccumulate8> accumulator8, Func<TAccumulate1, TAccumulate2, TAccumulate3, TAccumulate4, TAccumulate5, TAccumulate6, TAccumulate7, TAccumulate8, TResult> resultSelector)
		{
			return MoreEnumerable.Aggregate(source, seed1, accumulator1, seed2, accumulator2, seed3, accumulator3, seed4, accumulator4, seed5, accumulator5, seed6, accumulator6, seed7, accumulator7, seed8, accumulator8, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AggregateRightExtension
	{
		public static TSource AggregateRight<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			return MoreEnumerable.AggregateRight(source, func);
		}

		public static TAccumulate AggregateRight<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func)
		{
			return MoreEnumerable.AggregateRight(source, seed, func);
		}

		public static TResult AggregateRight<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			return MoreEnumerable.AggregateRight(source, seed, func, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AppendExtension
	{
		public static IEnumerable<T> Append<T>(this IEnumerable<T> head, T tail)
		{
			return MoreEnumerable.Append(head, tail);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AssertExtension
	{
		public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return MoreEnumerable.Assert(source, predicate);
		}

		public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, Exception> errorSelector)
		{
			return MoreEnumerable.Assert(source, predicate, errorSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AssertCountExtension
	{
		public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count)
		{
			return MoreEnumerable.AssertCount(source, count);
		}

		public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count, Func<int, int, Exception> errorSelector)
		{
			return MoreEnumerable.AssertCount(source, count, errorSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AtLeastExtension
	{
		public static bool AtLeast<T>(this IEnumerable<T> source, int count)
		{
			return MoreEnumerable.AtLeast(source, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class AtMostExtension
	{
		public static bool AtMost<T>(this IEnumerable<T> source, int count)
		{
			return MoreEnumerable.AtMost(source, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class BacksertExtension
	{
		public static IEnumerable<T> Backsert<T>(this IEnumerable<T> first, IEnumerable<T> second, int index)
		{
			return MoreEnumerable.Backsert(first, second, index);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class BatchExtension
	{
		public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
		{
			return MoreEnumerable.Batch(source, size);
		}

		public static IEnumerable<TResult> Batch<TSource, TResult>(this IEnumerable<TSource> source, int size, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Batch(source, size, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class CartesianExtension
	{
		public static IEnumerable<TResult> Cartesian<T1, T2, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, fourth, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, fourth, fifth, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, fourth, fifth, sixth, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, IEnumerable<T7> seventh, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, fourth, fifth, sixth, seventh, resultSelector);
		}

		public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, IEnumerable<T5> fifth, IEnumerable<T6> sixth, IEnumerable<T7> seventh, IEnumerable<T8> eighth, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			return MoreEnumerable.Cartesian(first, second, third, fourth, fifth, sixth, seventh, eighth, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ChooseExtension
	{
		public static IEnumerable<TResult> Choose<T, TResult>(this IEnumerable<T> source, Func<T, (bool, TResult)> chooser)
		{
			return MoreEnumerable.Choose(source, chooser);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class CompareCountExtension
	{
		public static int CompareCount<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
		{
			return MoreEnumerable.CompareCount(first, second);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ConsumeExtension
	{
		public static void Consume<T>(this IEnumerable<T> source)
		{
			MoreEnumerable.Consume(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class CountBetweenExtension
	{
		public static bool CountBetween<T>(this IEnumerable<T> source, int min, int max)
		{
			return MoreEnumerable.CountBetween(source, min, max);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class CountByExtension
	{
		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.CountBy(source, keySelector);
		}

		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.CountBy(source, keySelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class CountDownExtension
	{
		public static IEnumerable<TResult> CountDown<T, TResult>(this IEnumerable<T> source, int count, Func<T, int?, TResult> resultSelector)
		{
			return MoreEnumerable.CountDown(source, count, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class DistinctByExtension
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.DistinctBy(source, keySelector);
		}

		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.DistinctBy(source, keySelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class EndsWithExtension
	{
		public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return MoreEnumerable.EndsWith(first, second);
		}

		public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
		{
			return MoreEnumerable.EndsWith(first, second, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class EquiZipExtension
	{
		public static IEnumerable<TResult> EquiZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			return MoreEnumerable.EquiZip(first, second, resultSelector);
		}

		public static IEnumerable<TResult> EquiZip<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			return MoreEnumerable.EquiZip(first, second, third, resultSelector);
		}

		public static IEnumerable<TResult> EquiZip<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return MoreEnumerable.EquiZip(first, second, third, fourth, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class EvaluateExtension
	{
		public static IEnumerable<T> Evaluate<T>(this IEnumerable<Func<T>> functions)
		{
			return MoreEnumerable.Evaluate(functions);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ExactlyExtension
	{
		public static bool Exactly<T>(this IEnumerable<T> source, int count)
		{
			return MoreEnumerable.Exactly(source, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ExceptByExtension
	{
		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.ExceptBy(first, second, keySelector);
		}

		public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
		{
			return MoreEnumerable.ExceptBy(first, second, keySelector, keyComparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ExcludeExtension
	{
		public static IEnumerable<T> Exclude<T>(this IEnumerable<T> sequence, int startIndex, int count)
		{
			return MoreEnumerable.Exclude(sequence, startIndex, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FallbackIfEmptyExtension
	{
		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, IEnumerable<T> fallback)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, params T[] fallback)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2, fallback3);
		}

		public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3, T fallback4)
		{
			return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2, fallback3, fallback4);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FillBackwardExtension
	{
		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source)
		{
			return MoreEnumerable.FillBackward(source);
		}

		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return MoreEnumerable.FillBackward(source, predicate);
		}

		public static IEnumerable<T> FillBackward<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			return MoreEnumerable.FillBackward(source, predicate, fillSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FillForwardExtension
	{
		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source)
		{
			return MoreEnumerable.FillForward(source);
		}

		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return MoreEnumerable.FillForward(source, predicate);
		}

		public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
		{
			return MoreEnumerable.FillForward(source, predicate, fillSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FirstExtension
	{
		public static T First<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.First(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FirstOrDefaultExtension
	{
		public static T FirstOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.FirstOrDefault(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FlattenExtension
	{
		public static IEnumerable<object> Flatten(this IEnumerable source)
		{
			return MoreEnumerable.Flatten(source);
		}

		public static IEnumerable<object> Flatten(this IEnumerable source, Func<IEnumerable, bool> predicate)
		{
			return MoreEnumerable.Flatten(source, predicate);
		}

		public static IEnumerable<object> Flatten(this IEnumerable source, Func<object, IEnumerable> selector)
		{
			return MoreEnumerable.Flatten(source, selector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FoldExtension
	{
		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}

		public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, TResult> folder)
		{
			return MoreEnumerable.Fold(source, folder);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ForEachExtension
	{
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			MoreEnumerable.ForEach(source, action);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			MoreEnumerable.ForEach(source, action);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FullGroupJoinExtension
	{
		public static IEnumerable<(TKey Key, IEnumerable<TFirst> First, IEnumerable<TSecond> Second)> FullGroupJoin<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector)
		{
			return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector);
		}

		public static IEnumerable<(TKey Key, IEnumerable<TFirst> First, IEnumerable<TSecond> Second)> FullGroupJoin<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector, comparer);
		}

		public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector)
		{
			return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector, resultSelector);
		}

		public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector, resultSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class FullJoinExtension
	{
		public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			return MoreEnumerable.FullJoin(first, second, keySelector, firstSelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> FullJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.FullJoin(first, second, keySelector, firstSelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> FullJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return MoreEnumerable.FullJoin(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> FullJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.FullJoin(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class GroupAdjacentExtension
	{
		public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector);
		}

		public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector, comparer);
		}

		public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector, elementSelector);
		}

		public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector, resultSelector);
		}

		public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector, elementSelector, comparer);
		}

		public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.GroupAdjacent(source, keySelector, resultSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class IndexExtension
	{
		public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source)
		{
			return MoreEnumerable.Index(source);
		}

		public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source, int startIndex)
		{
			return MoreEnumerable.Index(source, startIndex);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class IndexByExtension
	{
		public static IEnumerable<KeyValuePair<int, TSource>> IndexBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.IndexBy(source, keySelector);
		}

		public static IEnumerable<KeyValuePair<int, TSource>> IndexBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.IndexBy(source, keySelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class InsertExtension
	{
		public static IEnumerable<T> Insert<T>(this IEnumerable<T> first, IEnumerable<T> second, int index)
		{
			return MoreEnumerable.Insert(first, second, index);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class InterleaveExtension
	{
		public static IEnumerable<T> Interleave<T>(this IEnumerable<T> sequence, params IEnumerable<T>[] otherSequences)
		{
			return MoreEnumerable.Interleave(sequence, otherSequences);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class LagExtension
	{
		public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
		{
			return MoreEnumerable.Lag(source, offset, resultSelector);
		}

		public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLagValue, Func<TSource, TSource, TResult> resultSelector)
		{
			return MoreEnumerable.Lag(source, offset, defaultLagValue, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class LastExtension
	{
		public static T Last<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.Last(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class LastOrDefaultExtension
	{
		public static T LastOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.LastOrDefault(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class LeadExtension
	{
		public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
		{
			return MoreEnumerable.Lead(source, offset, resultSelector);
		}

		public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLeadValue, Func<TSource, TSource, TResult> resultSelector)
		{
			return MoreEnumerable.Lead(source, offset, defaultLeadValue, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class LeftJoinExtension
	{
		public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			return MoreEnumerable.LeftJoin(first, second, keySelector, firstSelector, bothSelector);
		}

		public static IEnumerable<TResult> LeftJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> firstSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.LeftJoin(first, second, keySelector, firstSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> LeftJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return MoreEnumerable.LeftJoin(first, second, firstKeySelector, secondKeySelector, firstSelector, bothSelector);
		}

		public static IEnumerable<TResult> LeftJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.LeftJoin(first, second, firstKeySelector, secondKeySelector, firstSelector, bothSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class MaxByExtension
	{
		public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return MoreEnumerable.MaxBy(source, selector);
		}

		public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.MaxBy(source, selector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class MinByExtension
	{
		public static IExtremaEnumerable<TSource> MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return MoreEnumerable.MinBy(source, selector);
		}

		public static IExtremaEnumerable<TSource> MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.MinBy(source, selector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class MoveExtension
	{
		public static IEnumerable<T> Move<T>(this IEnumerable<T> source, int fromIndex, int count, int toIndex)
		{
			return MoreEnumerable.Move(source, fromIndex, count, toIndex);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class OrderByExtension
	{
		public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
		{
			return MoreEnumerable.OrderBy(source, keySelector, direction);
		}

		public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			return MoreEnumerable.OrderBy(source, keySelector, comparer, direction);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class OrderedMergeExtension
	{
		public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return MoreEnumerable.OrderedMerge(first, second);
		}

		public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second, IComparer<T> comparer)
		{
			return MoreEnumerable.OrderedMerge(first, second, comparer);
		}

		public static IEnumerable<T> OrderedMerge<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector)
		{
			return MoreEnumerable.OrderedMerge(first, second, keySelector);
		}

		public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector)
		{
			return MoreEnumerable.OrderedMerge(first, second, keySelector, firstSelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.OrderedMerge(first, second, keySelector, firstSelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return MoreEnumerable.OrderedMerge(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.OrderedMerge(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PadExtension
	{
		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width)
		{
			return MoreEnumerable.Pad(source, width);
		}

		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, TSource padding)
		{
			return MoreEnumerable.Pad(source, width, padding);
		}

		public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, Func<int, TSource> paddingSelector)
		{
			return MoreEnumerable.Pad(source, width, paddingSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PadStartExtension
	{
		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width)
		{
			return MoreEnumerable.PadStart(source, width);
		}

		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width, TSource padding)
		{
			return MoreEnumerable.PadStart(source, width, padding);
		}

		public static IEnumerable<TSource> PadStart<TSource>(this IEnumerable<TSource> source, int width, Func<int, TSource> paddingSelector)
		{
			return MoreEnumerable.PadStart(source, width, paddingSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PairwiseExtension
	{
		public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
		{
			return MoreEnumerable.Pairwise(source, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PartialSortExtension
	{
		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count)
		{
			return MoreEnumerable.PartialSort(source, count);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, OrderByDirection direction)
		{
			return MoreEnumerable.PartialSort(source, count, direction);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer)
		{
			return MoreEnumerable.PartialSort(source, count, comparer);
		}

		public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer, OrderByDirection direction)
		{
			return MoreEnumerable.PartialSort(source, count, comparer, direction);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PartialSortByExtension
	{
		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.PartialSortBy(source, count, keySelector);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, OrderByDirection direction)
		{
			return MoreEnumerable.PartialSortBy(source, count, keySelector, direction);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.PartialSortBy(source, count, keySelector, comparer);
		}

		public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			return MoreEnumerable.PartialSortBy(source, count, keySelector, comparer, direction);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PartitionExtension
	{
		public static (IEnumerable<T> True, IEnumerable<T> False) Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return MoreEnumerable.Partition(source, predicate);
		}

		public static TResult Partition<T, TResult>(this IEnumerable<IGrouping<bool, T>> source, Func<IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, resultSelector);
		}

		public static TResult Partition<T, TResult>(this IEnumerable<IGrouping<bool?, T>> source, Func<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, resultSelector);
		}

		public static TResult Partition<T, TResult>(this IEnumerable<T> source, Func<T, bool> predicate, Func<IEnumerable<T>, IEnumerable<T>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, predicate, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key, Func<IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key1, key2, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key, comparer, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, TKey key3, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key1, key2, key3, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key1, key2, comparer, resultSelector);
		}

		public static TResult Partition<TKey, TElement, TResult>(this IEnumerable<IGrouping<TKey, TElement>> source, TKey key1, TKey key2, TKey key3, IEqualityComparer<TKey> comparer, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<TElement>, IEnumerable<IGrouping<TKey, TElement>>, TResult> resultSelector)
		{
			return MoreEnumerable.Partition(source, key1, key2, key3, comparer, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PermutationsExtension
	{
		public static IEnumerable<IList<T>> Permutations<T>(this IEnumerable<T> sequence)
		{
			return MoreEnumerable.Permutations(sequence);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PipeExtension
	{
		public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
		{
			return MoreEnumerable.Pipe(source, action);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PrependExtension
	{
		public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource value)
		{
			return MoreEnumerable.Prepend(source, value);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class PreScanExtension
	{
		public static IEnumerable<TSource> PreScan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation, TSource identity)
		{
			return MoreEnumerable.PreScan(source, transformation, identity);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RandomSubsetExtension
	{
		public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int subsetSize)
		{
			return MoreEnumerable.RandomSubset(source, subsetSize);
		}

		public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> source, int subsetSize, Random rand)
		{
			return MoreEnumerable.RandomSubset(source, subsetSize, rand);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RankExtension
	{
		public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source)
		{
			return MoreEnumerable.Rank(source);
		}

		public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
		{
			return MoreEnumerable.Rank(source, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RankByExtension
	{
		public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return MoreEnumerable.RankBy(source, keySelector);
		}

		public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			return MoreEnumerable.RankBy(source, keySelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RepeatExtension
	{
		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence)
		{
			return MoreEnumerable.Repeat(sequence);
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence, int count)
		{
			return MoreEnumerable.Repeat(sequence, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RightJoinExtension
	{
		public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector)
		{
			return MoreEnumerable.RightJoin(first, second, keySelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> RightJoin<TSource, TKey, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, Func<TSource, TResult> secondSelector, Func<TSource, TSource, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.RightJoin(first, second, keySelector, secondSelector, bothSelector, comparer);
		}

		public static IEnumerable<TResult> RightJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
		{
			return MoreEnumerable.RightJoin(first, second, firstKeySelector, secondKeySelector, secondSelector, bothSelector);
		}

		public static IEnumerable<TResult> RightJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.RightJoin(first, second, firstKeySelector, secondKeySelector, secondSelector, bothSelector, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class RunLengthEncodeExtension
	{
		public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence)
		{
			return MoreEnumerable.RunLengthEncode(sequence);
		}

		public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comparer)
		{
			return MoreEnumerable.RunLengthEncode(sequence, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ScanExtension
	{
		public static IEnumerable<TSource> Scan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation)
		{
			return MoreEnumerable.Scan(source, transformation);
		}

		public static IEnumerable<TState> Scan<TSource, TState>(this IEnumerable<TSource> source, TState seed, Func<TState, TSource, TState> transformation)
		{
			return MoreEnumerable.Scan(source, seed, transformation);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ScanByExtension
	{
		public static IEnumerable<KeyValuePair<TKey, TState>> ScanBy<TSource, TKey, TState>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TState> seedSelector, Func<TState, TKey, TSource, TState> accumulator)
		{
			return MoreEnumerable.ScanBy(source, keySelector, seedSelector, accumulator);
		}

		public static IEnumerable<KeyValuePair<TKey, TState>> ScanBy<TSource, TKey, TState>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TState> seedSelector, Func<TState, TKey, TSource, TState> accumulator, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.ScanBy(source, keySelector, seedSelector, accumulator, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ScanRightExtension
	{
		public static IEnumerable<TSource> ScanRight<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			return MoreEnumerable.ScanRight(source, func);
		}

		public static IEnumerable<TAccumulate> ScanRight<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, TAccumulate, TAccumulate> func)
		{
			return MoreEnumerable.ScanRight(source, seed, func);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SegmentExtension
	{
		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, bool> newSegmentPredicate)
		{
			return MoreEnumerable.Segment(source, newSegmentPredicate);
		}

		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, int, bool> newSegmentPredicate)
		{
			return MoreEnumerable.Segment(source, newSegmentPredicate);
		}

		public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, T, int, bool> newSegmentPredicate)
		{
			return MoreEnumerable.Segment(source, newSegmentPredicate);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ShuffleExtension
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return MoreEnumerable.Shuffle(source);
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rand)
		{
			return MoreEnumerable.Shuffle(source, rand);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SingleExtension
	{
		public static T Single<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.Single(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SingleOrDefaultExtension
	{
		public static T SingleOrDefault<T>(this IExtremaEnumerable<T> source)
		{
			return MoreEnumerable.SingleOrDefault(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SkipLastExtension
	{
		public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
		{
			return MoreEnumerable.SkipLast(source, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SkipUntilExtension
	{
		public static IEnumerable<TSource> SkipUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return MoreEnumerable.SkipUntil(source, predicate);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SliceExtension
	{
		public static IEnumerable<T> Slice<T>(this IEnumerable<T> sequence, int startIndex, int count)
		{
			return MoreEnumerable.Slice(sequence, startIndex, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SortedMergeExtension
	{
		public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, params IEnumerable<TSource>[] otherSequences)
		{
			return MoreEnumerable.SortedMerge(source, direction, otherSequences);
		}

		public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, IComparer<TSource> comparer, params IEnumerable<TSource>[] otherSequences)
		{
			return MoreEnumerable.SortedMerge(source, direction, comparer, otherSequences);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SplitExtension
	{
		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator)
		{
			return MoreEnumerable.Split(source, separator);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc)
		{
			return MoreEnumerable.Split(source, separatorFunc);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, int count)
		{
			return MoreEnumerable.Split(source, separator, count);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer)
		{
			return MoreEnumerable.Split(source, separator, comparer);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count)
		{
			return MoreEnumerable.Split(source, separatorFunc, count);
		}

		public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count)
		{
			return MoreEnumerable.Split(source, separator, comparer, count);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separator, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separatorFunc, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separator, count, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separator, comparer, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separatorFunc, count, resultSelector);
		}

		public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
		{
			return MoreEnumerable.Split(source, separator, comparer, count, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class StartsWithExtension
	{
		public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return MoreEnumerable.StartsWith(first, second);
		}

		public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
		{
			return MoreEnumerable.StartsWith(first, second, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class SubsetsExtension
	{
		public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence)
		{
			return MoreEnumerable.Subsets(sequence);
		}

		public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence, int subsetSize)
		{
			return MoreEnumerable.Subsets(sequence, subsetSize);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TagFirstLastExtension
	{
		public static IEnumerable<TResult> TagFirstLast<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool, bool, TResult> resultSelector)
		{
			return MoreEnumerable.TagFirstLast(source, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TakeEveryExtension
	{
		public static IEnumerable<TSource> TakeEvery<TSource>(this IEnumerable<TSource> source, int step)
		{
			return MoreEnumerable.TakeEvery(source, step);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TakeLastExtension
	{
		public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
		{
			return MoreEnumerable.TakeLast(source, count);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TakeUntilExtension
	{
		public static IEnumerable<TSource> TakeUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return MoreEnumerable.TakeUntil(source, predicate);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ThenByExtension
	{
		public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
		{
			return MoreEnumerable.ThenBy(source, keySelector, direction);
		}

		public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
		{
			return MoreEnumerable.ThenBy(source, keySelector, comparer, direction);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToArrayByIndexExtension
	{
		public static T[] ToArrayByIndex<T>(this IEnumerable<T> source, Func<T, int> indexSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, indexSelector);
		}

		public static T[] ToArrayByIndex<T>(this IEnumerable<T> source, int length, Func<T, int> indexSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, length, indexSelector);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, Func<T, int> indexSelector, Func<T, TResult> resultSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, indexSelector, resultSelector);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, Func<T, int> indexSelector, Func<T, int, TResult> resultSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, indexSelector, resultSelector);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, int length, Func<T, int> indexSelector, Func<T, TResult> resultSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, length, indexSelector, resultSelector);
		}

		public static TResult[] ToArrayByIndex<T, TResult>(this IEnumerable<T> source, int length, Func<T, int> indexSelector, Func<T, int, TResult> resultSelector)
		{
			return MoreEnumerable.ToArrayByIndex(source, length, indexSelector, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToDelimitedStringExtension
	{
		public static string ToDelimitedString(this IEnumerable<bool> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<byte> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<char> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<decimal> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<double> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<float> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<int> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<long> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<sbyte> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<short> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString(this IEnumerable<string> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<uint> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<ulong> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		[CLSCompliant(false)]
		public static string ToDelimitedString(this IEnumerable<ushort> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}

		public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
		{
			return MoreEnumerable.ToDelimitedString(source, delimiter);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToDictionaryExtension
	{
		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source)
		{
			return MoreEnumerable.ToDictionary(source);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return MoreEnumerable.ToDictionary(source);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.ToDictionary(source, comparer);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.ToDictionary(source, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToHashSetExtension
	{
		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
		{
			return MoreEnumerable.ToHashSet(source);
		}

		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			return MoreEnumerable.ToHashSet(source, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToLookupExtension
	{
		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source)
		{
			return MoreEnumerable.ToLookup(source);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return MoreEnumerable.ToLookup(source);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.ToLookup(source, comparer);
		}

		public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer)
		{
			return MoreEnumerable.ToLookup(source, comparer);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TraceExtension
	{
		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source)
		{
			return MoreEnumerable.Trace(source);
		}

		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, string format)
		{
			return MoreEnumerable.Trace(source, format);
		}

		public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, Func<TSource, string> formatter)
		{
			return MoreEnumerable.Trace(source, formatter);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class TransposeExtension
	{
		public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
		{
			return MoreEnumerable.Transpose(source);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class WindowExtension
	{
		public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
		{
			return MoreEnumerable.Window(source, size);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class WindowLeftExtension
	{
		public static IEnumerable<IList<TSource>> WindowLeft<TSource>(this IEnumerable<TSource> source, int size)
		{
			return MoreEnumerable.WindowLeft(source, size);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class WindowRightExtension
	{
		public static IEnumerable<IList<TSource>> WindowRight<TSource>(this IEnumerable<TSource> source, int size)
		{
			return MoreEnumerable.WindowRight(source, size);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ZipLongestExtension
	{
		public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			return MoreEnumerable.ZipLongest(first, second, resultSelector);
		}

		public static IEnumerable<TResult> ZipLongest<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			return MoreEnumerable.ZipLongest(first, second, third, resultSelector);
		}

		public static IEnumerable<TResult> ZipLongest<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return MoreEnumerable.ZipLongest(first, second, third, fourth, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ZipShortestExtension
	{
		public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			return MoreEnumerable.ZipShortest(first, second, resultSelector);
		}

		public static IEnumerable<TResult> ZipShortest<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
		{
			return MoreEnumerable.ZipShortest(first, second, third, resultSelector);
		}

		public static IEnumerable<TResult> ZipShortest<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return MoreEnumerable.ZipShortest(first, second, third, fourth, resultSelector);
		}
	}
	[GeneratedCode("MoreLinq.ExtensionsGenerator", "1.0.0.0")]
	public static class ToDataTableExtension
	{
		public static DataTable ToDataTable<T>(this IEnumerable<T> source)
		{
			return MoreEnumerable.ToDataTable(source);
		}

		public static DataTable ToDataTable<T>(this IEnumerable<T> source, params Expression<Func<T, object>>[] expressions)
		{
			return MoreEnumerable.ToDataTable(source, expressions);
		}

		public static TTable ToDataTable<T, TTable>(this IEnumerable<T> source, TTable table) where TTable : DataTable
		{
			return MoreEnumerable.ToDataTable(source, table);
		}

		public static TTable ToDataTable<T, TTable>(this IEnumerable<T> source, TTable table, params Expression<Func<T, object>>[] expressions) where TTable : DataTable
		{
			return MoreEnumerable.ToDataTable(source, table, expressions);
		}
	}
}
namespace MoreLinq.Experimental
{
	public static class ExperimentalEnumerable
	{
		private enum Notice
		{
			End,
			Result,
			Error
		}

		private static class AwaitQuery
		{
			public static IAwaitQuery<T> Create<T>(Func<AwaitQueryOptions, IEnumerable<T>> impl, AwaitQueryOptions options = null)
			{
				return new AwaitQuery<T>(impl, options);
			}
		}

		private sealed class AwaitQuery<T> : IAwaitQuery<T>, IEnumerable<T>, IEnumerable
		{
			private readonly Func<AwaitQueryOptions, IEnumerable<T>> _impl;

			public AwaitQueryOptions Options { get; }

			public AwaitQuery(Func<AwaitQueryOptions, IEnumerable<T>> impl, AwaitQueryOptions options = null)
			{
				_impl = impl;
				Options = options ?? AwaitQueryOptions.Default;
			}

			public IAwaitQuery<T> WithOptions(AwaitQueryOptions options)
			{
				if (options == null)
				{
					throw new ArgumentNullException("options");
				}
				if (Options != options)
				{
					return new AwaitQuery<T>(_impl, options);
				}
				return this;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return _impl(Options).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private static class TupleComparer<T1, T2, T3>
		{
			public static readonly IComparer<(T1, T2, T3)> Item1 = Comparer<(T1, T2, T3)>.Create(((T1, T2, T3) x, (T1, T2, T3) y) => Comparer<T1>.Default.Compare(x.Item1, y.Item1));

			public static readonly IComparer<(T1, T2, T3)> Item2 = Comparer<(T1, T2, T3)>.Create(((T1, T2, T3) x, (T1, T2, T3) y) => Comparer<T2>.Default.Compare(x.Item2, y.Item2));

			public static readonly IComparer<(T1, T2, T3)> Item3 = Comparer<(T1, T2, T3)>.Create(((T1, T2, T3) x, (T1, T2, T3) y) => Comparer<T3>.Default.Compare(x.Item3, y.Item3));
		}

		private static class CompletedTask
		{
			public static readonly Task Instance = Task.CompletedTask;
		}

		private sealed class ConcurrencyGate
		{
			public static readonly ConcurrencyGate Unbounded = new ConcurrencyGate();

			private readonly SemaphoreSlim _semaphore;

			private ConcurrencyGate(SemaphoreSlim semaphore = null)
			{
				_semaphore = semaphore;
			}

			public ConcurrencyGate(int max)
				: this(new SemaphoreSlim(max, max))
			{
			}

			public Task EnterAsync(CancellationToken token)
			{
				if (_semaphore == null)
				{
					token.ThrowIfCancellationRequested();
					return CompletedTask.Instance;
				}
				return _semaphore.WaitAsync(token);
			}

			public void Exit()
			{
				_semaphore?.Release();
			}
		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass18_0<T, TTaskResult, TResult>
		{
			public IEnumerable<T> source;

			public Func<T, CancellationToken, Task<TTaskResult>> evaluator;

			public Func<T, Task<TTaskResult>, TResult> resultSelector;

			internal IEnumerable<TResult> <AwaitCompletion>b__0(AwaitQueryOptions options)
			{
				return _(options.MaxConcurrency, options.Scheduler ?? TaskScheduler.Default, options.PreserveOrder);
				void PostNotice(Notice notice, (int, T, Task<TTaskResult>) item, Exception error)
				{
					try
					{
						ExceptionDispatchInfo item2 = ((error != null) ? ExceptionDispatchInfo.Capture(error) : null);
						((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).notices.Add((notice, item, item2));
					}
					catch (Exception item3)
					{
						((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).lastCriticalErrors = (item3, error);
						((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).consumerCancellationTokenSource.Cancel();
						throw;
					}
				}
				IEnumerable<TResult> _(int? maxConcurrency, TaskScheduler scheduler, bool ordered)
				{
					BlockingCollection<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)> notices = new BlockingCollection<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)>();
					CancellationTokenSource consumerCancellationTokenSource = new CancellationTokenSource();
					(Exception, Exception) lastCriticalErrors = default((Exception, Exception));
					bool completed = false;
					CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
					IEnumerator<KeyValuePair<int, T>> enumerator = source.Index().GetEnumerator();
					IDisposable disposable = enumerator;
					try
					{
						CancellationToken cancellationToken = cancellationTokenSource.Token;
						Task.Factory.StartNew((Func<Task>)async delegate
						{
							try
							{
								await enumerator.StartAsync((KeyValuePair<int, T> e) => evaluator(e.Value, cancellationToken), delegate(KeyValuePair<int, T> e, Task<TTaskResult> r)
								{
									PostNotice(Notice.Result, (e.Key, e.Value, r), null);
								}, delegate
								{
									PostNotice(Notice.End, default((int, T, Task<TTaskResult>)), null);
								}, maxConcurrency, cancellationToken);
							}
							catch (Exception error)
							{
								PostNotice(Notice.Error, default((int, T, Task<TTaskResult>)), error);
							}
						}, CancellationToken.None, TaskCreationOptions.DenyChildAttach, scheduler);
						int nextKey = 0;
						List<(int, T, Task<TTaskResult>)> holds = (ordered ? new List<(int, T, Task<TTaskResult>)>() : null);
						using (IEnumerator<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)> notice = notices.GetConsumingEnumerable(consumerCancellationTokenSource.Token).GetEnumerator())
						{
							while (true)
							{
								try
								{
									if (!notice.MoveNext())
									{
										break;
									}
								}
								catch (OperationCanceledException ex) when (ex.CancellationToken == consumerCancellationTokenSource.Token)
								{
									var (ex2, ex3) = lastCriticalErrors;
									throw new Exception("One or more critical errors have occurred.", (ex3 != null) ? new AggregateException(ex2, ex3) : new AggregateException(ex2));
								}
								var (notice2, tuple3, exceptionDispatchInfo) = notice.Current;
								if (notice2 == Notice.Error)
								{
									exceptionDispatchInfo.Throw();
								}
								if (notice2 == Notice.End)
								{
									break;
								}
								var (num, arg, arg2) = tuple3;
								if (holds == null || num == nextKey)
								{
									yield return resultSelector(arg, arg2);
									if (holds != null)
									{
										int releaseCount = 0;
										nextKey++;
										while (holds.Count > 0)
										{
											var (num2, arg3, arg4) = holds[0];
											if (num2 != nextKey)
											{
												break;
											}
											releaseCount++;
											yield return resultSelector(arg3, arg4);
											nextKey++;
										}
										holds.RemoveRange(0, releaseCount);
									}
								}
								else
								{
									int num3 = holds.BinarySearch(tuple3, TupleComparer<int, T, Task<TTaskResult>>.Item1);
									holds.Insert(~num3, tuple3);
								}
							}
						}
						if (holds != null && holds.Count > 0)
						{
							foreach (var item4 in holds)
							{
								T item = item4.Item2;
								Task<TTaskResult> item2 = item4.Item3;
								yield return resultSelector(item, item2);
							}
						}
						completed = true;
					}
					finally
					{
						if (!completed)
						{
							cancellationTokenSource.Cancel();
						}
						disposable.Dispose();
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass18_1<T, TTaskResult, TResult>
		{
			public BlockingCollection<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)> notices;

			public (Exception, Exception) lastCriticalErrors;

			public CancellationTokenSource consumerCancellationTokenSource;

			public IEnumerator<KeyValuePair<int, T>> enumerator;

			public int? maxConcurrency;

			public <>c__DisplayClass18_0<T, TTaskResult, TResult> CS$<>8__locals1;

			public Action<KeyValuePair<int, T>, Task<TTaskResult>> <>9__5;

			public Action <>9__6;

			internal void <AwaitCompletion>b__5(KeyValuePair<int, T> e, Task<TTaskResult> r)
			{
				PostNotice(Notice.Result, (e.Key, e.Value, r), null);
				void PostNotice(Notice notice, (int, T, Task<TTaskResult>) item, Exception error)
				{
					try
					{
						ExceptionDispatchInfo item2 = ((error != null) ? ExceptionDispatchInfo.Capture(error) : null);
						notices.Add((notice, item, item2));
					}
					catch (Exception item3)
					{
						lastCriticalErrors = (item3, error);
						consumerCancellationTokenSource.Cancel();
						throw;
					}
				}
			}

			internal void <AwaitCompletion>b__6()
			{
				PostNotice(Notice.End, default((int, T, Task<TTaskResult>)), null);
				void PostNotice(Notice notice, (int, T, Task<TTaskResult>) item, Exception error)
				{
					try
					{
						ExceptionDispatchInfo item2 = ((error != null) ? ExceptionDispatchInfo.Capture(error) : null);
						notices.Add((notice, item, item2));
					}
					catch (Exception item3)
					{
						lastCriticalErrors = (item3, error);
						consumerCancellationTokenSource.Cancel();
						throw;
					}
				}
			}
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<TResult1, TResult2, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					foreach (T item in source)
					{
						subject.OnNext(item);
					}
					subject.OnCompleted();
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<TResult1, TResult2, TResult3, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						foreach (T item in source)
						{
							subject.OnNext(item);
						}
						subject.OnCompleted();
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult4, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<IObservable<T>, IObservable<TResult4>> accumulator4, Func<TResult1, TResult2, TResult3, TResult4, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			(bool, TResult4)[] array4 = new(bool, TResult4)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						using (SubscribeSingle(accumulator4, subject, array4, "accumulator4"))
						{
							foreach (T item in source)
							{
								subject.OnNext(item);
							}
							subject.OnCompleted();
						}
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"), GetAggregateResult(array4[0], "accumulator4"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult4, TResult5, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<IObservable<T>, IObservable<TResult4>> accumulator4, Func<IObservable<T>, IObservable<TResult5>> accumulator5, Func<TResult1, TResult2, TResult3, TResult4, TResult5, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			(bool, TResult4)[] array4 = new(bool, TResult4)[1];
			(bool, TResult5)[] array5 = new(bool, TResult5)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						using (SubscribeSingle(accumulator4, subject, array4, "accumulator4"))
						{
							using (SubscribeSingle(accumulator5, subject, array5, "accumulator5"))
							{
								foreach (T item in source)
								{
									subject.OnNext(item);
								}
								subject.OnCompleted();
							}
						}
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"), GetAggregateResult(array4[0], "accumulator4"), GetAggregateResult(array5[0], "accumulator5"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<IObservable<T>, IObservable<TResult4>> accumulator4, Func<IObservable<T>, IObservable<TResult5>> accumulator5, Func<IObservable<T>, IObservable<TResult6>> accumulator6, Func<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			(bool, TResult4)[] array4 = new(bool, TResult4)[1];
			(bool, TResult5)[] array5 = new(bool, TResult5)[1];
			(bool, TResult6)[] array6 = new(bool, TResult6)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						using (SubscribeSingle(accumulator4, subject, array4, "accumulator4"))
						{
							using (SubscribeSingle(accumulator5, subject, array5, "accumulator5"))
							{
								using (SubscribeSingle(accumulator6, subject, array6, "accumulator6"))
								{
									foreach (T item in source)
									{
										subject.OnNext(item);
									}
									subject.OnCompleted();
								}
							}
						}
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"), GetAggregateResult(array4[0], "accumulator4"), GetAggregateResult(array5[0], "accumulator5"), GetAggregateResult(array6[0], "accumulator6"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<IObservable<T>, IObservable<TResult4>> accumulator4, Func<IObservable<T>, IObservable<TResult5>> accumulator5, Func<IObservable<T>, IObservable<TResult6>> accumulator6, Func<IObservable<T>, IObservable<TResult7>> accumulator7, Func<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (accumulator7 == null)
			{
				throw new ArgumentNullException("accumulator7");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			(bool, TResult4)[] array4 = new(bool, TResult4)[1];
			(bool, TResult5)[] array5 = new(bool, TResult5)[1];
			(bool, TResult6)[] array6 = new(bool, TResult6)[1];
			(bool, TResult7)[] array7 = new(bool, TResult7)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						using (SubscribeSingle(accumulator4, subject, array4, "accumulator4"))
						{
							using (SubscribeSingle(accumulator5, subject, array5, "accumulator5"))
							{
								using (SubscribeSingle(accumulator6, subject, array6, "accumulator6"))
								{
									using (SubscribeSingle(accumulator7, subject, array7, "accumulator7"))
									{
										foreach (T item in source)
										{
											subject.OnNext(item);
										}
										subject.OnCompleted();
									}
								}
							}
						}
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"), GetAggregateResult(array4[0], "accumulator4"), GetAggregateResult(array5[0], "accumulator5"), GetAggregateResult(array6[0], "accumulator6"), GetAggregateResult(array7[0], "accumulator7"));
		}

		public static TResult Aggregate<T, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult>(this IEnumerable<T> source, Func<IObservable<T>, IObservable<TResult1>> accumulator1, Func<IObservable<T>, IObservable<TResult2>> accumulator2, Func<IObservable<T>, IObservable<TResult3>> accumulator3, Func<IObservable<T>, IObservable<TResult4>> accumulator4, Func<IObservable<T>, IObservable<TResult5>> accumulator5, Func<IObservable<T>, IObservable<TResult6>> accumulator6, Func<IObservable<T>, IObservable<TResult7>> accumulator7, Func<IObservable<T>, IObservable<TResult8>> accumulator8, Func<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (accumulator1 == null)
			{
				throw new ArgumentNullException("accumulator1");
			}
			if (accumulator2 == null)
			{
				throw new ArgumentNullException("accumulator2");
			}
			if (accumulator3 == null)
			{
				throw new ArgumentNullException("accumulator3");
			}
			if (accumulator4 == null)
			{
				throw new ArgumentNullException("accumulator4");
			}
			if (accumulator5 == null)
			{
				throw new ArgumentNullException("accumulator5");
			}
			if (accumulator6 == null)
			{
				throw new ArgumentNullException("accumulator6");
			}
			if (accumulator7 == null)
			{
				throw new ArgumentNullException("accumulator7");
			}
			if (accumulator8 == null)
			{
				throw new ArgumentNullException("accumulator8");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			(bool, TResult1)[] array = new(bool, TResult1)[1];
			(bool, TResult2)[] array2 = new(bool, TResult2)[1];
			(bool, TResult3)[] array3 = new(bool, TResult3)[1];
			(bool, TResult4)[] array4 = new(bool, TResult4)[1];
			(bool, TResult5)[] array5 = new(bool, TResult5)[1];
			(bool, TResult6)[] array6 = new(bool, TResult6)[1];
			(bool, TResult7)[] array7 = new(bool, TResult7)[1];
			(bool, TResult8)[] array8 = new(bool, TResult8)[1];
			Subject<T> subject = new Subject<T>();
			using (SubscribeSingle(accumulator1, subject, array, "accumulator1"))
			{
				using (SubscribeSingle(accumulator2, subject, array2, "accumulator2"))
				{
					using (SubscribeSingle(accumulator3, subject, array3, "accumulator3"))
					{
						using (SubscribeSingle(accumulator4, subject, array4, "accumulator4"))
						{
							using (SubscribeSingle(accumulator5, subject, array5, "accumulator5"))
							{
								using (SubscribeSingle(accumulator6, subject, array6, "accumulator6"))
								{
									using (SubscribeSingle(accumulator7, subject, array7, "accumulator7"))
									{
										using (SubscribeSingle(accumulator8, subject, array8, "accumulator8"))
										{
											foreach (T item in source)
											{
												subject.OnNext(item);
											}
											subject.OnCompleted();
										}
									}
								}
							}
						}
					}
				}
			}
			return resultSelector(GetAggregateResult(array[0], "accumulator1"), GetAggregateResult(array2[0], "accumulator2"), GetAggregateResult(array3[0], "accumulator3"), GetAggregateResult(array4[0], "accumulator4"), GetAggregateResult(array5[0], "accumulator5"), GetAggregateResult(array6[0], "accumulator6"), GetAggregateResult(array7[0], "accumulator7"), GetAggregateResult(array8[0], "accumulator8"));
		}

		private static IDisposable SubscribeSingle<T, TResult>(Func<IObservable<T>, IObservable<TResult>> aggregatorSelector, IObservable<T> subject, (bool Defined, TResult)[] r, string paramName)
		{
			IObservable<TResult> observable = aggregatorSelector(subject);
			if (observable != subject)
			{
				return observable.Subscribe(delegate(TResult s)
				{
					(bool Defined, TResult)[] array = r;
					if (r[0].Defined)
					{
						throw new InvalidOperationException("Aggregator supplied for parameter \"" + paramName + "\" produced multiple results when only one is allowed.");
					}
					array[0] = (Defined: true, s);
				});
			}
			throw new ArgumentException("Aggregator cannot be identical to the source.", paramName);
		}

		private static T GetAggregateResult<T>((bool Defined, T Value) result, string paramName)
		{
			if (result.Defined)
			{
				return result.Value;
			}
			throw new InvalidOperationException("Aggregator supplied for parameter \"" + paramName + "\" has an undefined result.");
		}

		public static IEnumerable<T> AsSequential<T>(this IAwaitQuery<T> source)
		{
			return source.MaxConcurrency(1);
		}

		public static IAwaitQuery<T> MaxConcurrency<T>(this IAwaitQuery<T> source, int value)
		{
			return source.WithOptions(source.Options.WithMaxConcurrency(value));
		}

		public static IAwaitQuery<T> UnboundedConcurrency<T>(this IAwaitQuery<T> source)
		{
			return source.WithOptions(source.Options.WithMaxConcurrency(null));
		}

		public static IAwaitQuery<T> Scheduler<T>(this IAwaitQuery<T> source, TaskScheduler value)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return source.WithOptions(source.Options.WithScheduler(value));
		}

		public static IAwaitQuery<T> AsOrdered<T>(this IAwaitQuery<T> source)
		{
			return source.PreserveOrder(value: true);
		}

		public static IAwaitQuery<T> AsUnordered<T>(this IAwaitQuery<T> source)
		{
			return source.PreserveOrder(value: false);
		}

		public static IAwaitQuery<T> PreserveOrder<T>(this IAwaitQuery<T> source, bool value)
		{
			return source.WithOptions(source.Options.WithPreserveOrder(value));
		}

		public static IAwaitQuery<T> Await<T>(this IEnumerable<Task<T>> source)
		{
			return source.Await((Task<T> e, CancellationToken _) => e);
		}

		public static IAwaitQuery<TResult> Await<T, TResult>(this IEnumerable<T> source, Func<T, CancellationToken, Task<TResult>> evaluator)
		{
			return AwaitQuery.Create((AwaitQueryOptions options) => from t in source.AwaitCompletion(evaluator, (T _, Task<TResult> t) => t).WithOptions(options)
				select t.GetAwaiter().GetResult());
		}

		public static IAwaitQuery<TResult> AwaitCompletion<T, TTaskResult, TResult>(this IEnumerable<T> source, Func<T, CancellationToken, Task<TTaskResult>> evaluator, Func<T, Task<TTaskResult>, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (evaluator == null)
			{
				throw new ArgumentNullException("evaluator");
			}
			return AwaitQuery.Create((AwaitQueryOptions options) => _(options.MaxConcurrency, options.Scheduler ?? TaskScheduler.Default, options.PreserveOrder));
			void PostNotice(Notice notice, (int, T, Task<TTaskResult>) item, Exception error)
			{
				try
				{
					ExceptionDispatchInfo item2 = ((error != null) ? ExceptionDispatchInfo.Capture(error) : null);
					((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).notices.Add((notice, item, item2));
				}
				catch (Exception item3)
				{
					((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).lastCriticalErrors = (item3, error);
					((<>c__DisplayClass18_1<T, TTaskResult, TResult>)this).consumerCancellationTokenSource.Cancel();
					throw;
				}
			}
			IEnumerable<TResult> _(int? maxConcurrency, TaskScheduler scheduler, bool ordered)
			{
				BlockingCollection<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)> notices = new BlockingCollection<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)>();
				CancellationTokenSource consumerCancellationTokenSource = new CancellationTokenSource();
				(Exception, Exception) lastCriticalErrors = default((Exception, Exception));
				bool completed = false;
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				IEnumerator<KeyValuePair<int, T>> enumerator = source.Index().GetEnumerator();
				IDisposable disposable = enumerator;
				try
				{
					CancellationToken cancellationToken = cancellationTokenSource.Token;
					Task.Factory.StartNew((Func<Task>)async delegate
					{
						try
						{
							await enumerator.StartAsync((KeyValuePair<int, T> e) => evaluator(e.Value, cancellationToken), delegate(KeyValuePair<int, T> e, Task<TTaskResult> r)
							{
								PostNotice(Notice.Result, (e.Key, e.Value, r), null);
							}, delegate
							{
								PostNotice(Notice.End, default((int, T, Task<TTaskResult>)), null);
							}, maxConcurrency, cancellationToken);
						}
						catch (Exception error)
						{
							PostNotice(Notice.Error, default((int, T, Task<TTaskResult>)), error);
						}
					}, CancellationToken.None, TaskCreationOptions.DenyChildAttach, scheduler);
					int nextKey = 0;
					List<(int, T, Task<TTaskResult>)> holds = (ordered ? new List<(int, T, Task<TTaskResult>)>() : null);
					using (IEnumerator<(Notice, (int, T, Task<TTaskResult>), ExceptionDispatchInfo)> notice = notices.GetConsumingEnumerable(consumerCancellationTokenSource.Token).GetEnumerator())
					{
						while (true)
						{
							try
							{
								if (!notice.MoveNext())
								{
									break;
								}
							}
							catch (OperationCanceledException ex) when (ex.CancellationToken == consumerCancellationTokenSource.Token)
							{
								var (ex2, ex3) = lastCriticalErrors;
								throw new Exception("One or more critical errors have occurred.", (ex3 != null) ? new AggregateException(ex2, ex3) : new AggregateException(ex2));
							}
							var (notice2, tuple3, exceptionDispatchInfo) = notice.Current;
							if (notice2 == Notice.Error)
							{
								exceptionDispatchInfo.Throw();
							}
							if (notice2 == Notice.End)
							{
								break;
							}
							var (num, arg, arg2) = tuple3;
							if (holds == null || num == nextKey)
							{
								yield return resultSelector(arg, arg2);
								if (holds != null)
								{
									int releaseCount = 0;
									nextKey++;
									while (holds.Count > 0)
									{
										var (num2, arg3, arg4) = holds[0];
										if (num2 != nextKey)
										{
											break;
										}
										releaseCount++;
										yield return resultSelector(arg3, arg4);
										nextKey++;
									}
									holds.RemoveRange(0, releaseCount);
								}
							}
							else
							{
								int num3 = holds.BinarySearch(tuple3, TupleComparer<int, T, Task<TTaskResult>>.Item1);
								holds.Insert(~num3, tuple3);
							}
						}
					}
					if (holds != null && holds.Count > 0)
					{
						foreach (var item4 in holds)
						{
							T item = item4.Item2;
							Task<TTaskResult> item2 = item4.Item3;
							yield return resultSelector(item, item2);
						}
					}
					completed = true;
				}
				finally
				{
					if (!completed)
					{
						cancellationTokenSource.Cancel();
					}
					disposable.Dispose();
				}
			}
		}

		private static async Task StartAsync<T, TResult>(this IEnumerator<T> enumerator, Func<T, Task<TResult>> starter, Action<T, Task<TResult>> onTaskCompletion, Action onEnd, int? maxConcurrency, CancellationToken cancellationToken)
		{
			if (enumerator == null)
			{
				throw new ArgumentNullException("enumerator");
			}
			if (starter == null)
			{
				throw new ArgumentNullException("starter");
			}
			if (onTaskCompletion == null)
			{
				throw new ArgumentNullException("onTaskCompletion");
			}
			if (onEnd == null)
			{
				throw new ArgumentNullException("onEnd");
			}
			if (maxConcurrency < 1)
			{
				throw new ArgumentOutOfRangeException("maxConcurrency");
			}
			int pendingCount;
			using (enumerator)
			{
				pendingCount = 1;
				ConcurrencyGate concurrencyGate;
				if (maxConcurrency.HasValue)
				{
					int valueOrDefault = maxConcurrency.GetValueOrDefault();
					concurrencyGate = new ConcurrencyGate(valueOrDefault);
				}
				else
				{
					concurrencyGate = ConcurrencyGate.Unbounded;
				}
				ConcurrencyGate concurrencyGate2 = concurrencyGate;
				while (enumerator.MoveNext())
				{
					try
					{
						await concurrencyGate2.EnterAsync(cancellationToken);
					}
					catch (OperationCanceledException ex) when (ex.CancellationToken == cancellationToken)
					{
						return;
					}
					Interlocked.Increment(ref pendingCount);
					T item = enumerator.Current;
					starter(item).ContinueWith(delegate(Task<TResult> t)
					{
						concurrencyGate2.Exit();
						if (!cancellationToken.IsCancellationRequested)
						{
							onTaskCompletion(item, t);
							OnPendingCompleted();
						}
					}, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Current);
				}
				OnPendingCompleted();
			}
			void OnPendingCompleted()
			{
				if (Interlocked.Decrement(ref pendingCount) == 0)
				{
					onEnd();
				}
			}
		}

		public static IEnumerable<T> Memoize<T>(this IEnumerable<T> source)
		{
			if (source != null)
			{
				if (source is ICollection<T> || source is IReadOnlyCollection<T> || source is MemoizedEnumerable<T>)
				{
					return source;
				}
				return new MemoizedEnumerable<T>(source);
			}
			throw new ArgumentNullException("source");
		}

		public static (TCardinality Cardinality, T Value) TrySingle<T, TCardinality>(this IEnumerable<T> source, TCardinality zero, TCardinality one, TCardinality many)
		{
			return source.TrySingle(zero, one, many, ValueTuple.Create);
		}

		public static TResult TrySingle<T, TCardinality, TResult>(this IEnumerable<T> source, TCardinality zero, TCardinality one, TCardinality many, Func<TCardinality, T, TResult> resultSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (resultSelector == null)
			{
				throw new ArgumentNullException("resultSelector");
			}
			switch (source.TryGetCollectionCount())
			{
			case 0:
				return resultSelector(zero, default(T));
			case 1:
			{
				T val = ((source is IReadOnlyList<T> readOnlyList) ? readOnlyList[0] : ((!(source is IList<T> list)) ? source.First() : list[0]));
				T arg = val;
				return resultSelector(one, arg);
			}
			default:
				return resultSelector(many, default(T));
			case null:
			{
				using IEnumerator<T> enumerator = source.GetEnumerator();
				if (!enumerator.MoveNext())
				{
					return resultSelector(zero, default(T));
				}
				T current = enumerator.Current;
				return (!enumerator.MoveNext()) ? resultSelector(one, current) : resultSelector(many, default(T));
			}
			}
		}
	}
	public sealed class AwaitQueryOptions
	{
		public static readonly AwaitQueryOptions Default = new AwaitQueryOptions(null, TaskScheduler.Default, preserveOrder: false);

		public int? MaxConcurrency { get; }

		public TaskScheduler Scheduler { get; }

		public bool PreserveOrder { get; }

		private AwaitQueryOptions(int? maxConcurrency, TaskScheduler scheduler, bool preserveOrder)
		{
			if (maxConcurrency.HasValue && !(maxConcurrency > 0))
			{
				throw new ArgumentOutOfRangeException("maxConcurrency", maxConcurrency, "Maximum concurrency must be 1 or greater.");
			}
			MaxConcurrency = maxConcurrency;
			Scheduler = scheduler ?? throw new ArgumentNullException("scheduler");
			PreserveOrder = preserveOrder;
		}

		public AwaitQueryOptions WithMaxConcurrency(int? value)
		{
			if (value != MaxConcurrency)
			{
				return new AwaitQueryOptions(value, Scheduler, PreserveOrder);
			}
			return this;
		}

		public AwaitQueryOptions WithScheduler(TaskScheduler value)
		{
			if (value != Scheduler)
			{
				return new AwaitQueryOptions(MaxConcurrency, value, PreserveOrder);
			}
			return this;
		}

		public AwaitQueryOptions WithPreserveOrder(bool value)
		{
			if (value != PreserveOrder)
			{
				return new AwaitQueryOptions(MaxConcurrency, Scheduler, value);
			}
			return this;
		}
	}
	public interface IAwaitQuery<out T> : IEnumerable<T>, IEnumerable
	{
		AwaitQueryOptions Options { get; }

		IAwaitQuery<T> WithOptions(AwaitQueryOptions options);
	}
	internal sealed class MemoizedEnumerable<T> : IEnumerable<T>, IEnumerable, IDisposable
	{
		private List<T> _cache;

		private readonly object _locker;

		private readonly IEnumerable<T> _source;

		private IEnumerator<T> _sourceEnumerator;

		private int? _errorIndex;

		private ExceptionDispatchInfo _error;

		public MemoizedEnumerable(IEnumerable<T> sequence)
		{
			_source = sequence ?? throw new ArgumentNullException("sequence");
			_locker = new object();
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (_cache == null)
			{
				lock (_locker)
				{
					if (_cache == null)
					{
						_error?.Throw();
						try
						{
							List<T> cache = new List<T>();
							_sourceEnumerator = _source.GetEnumerator();
							_cache = cache;
						}
						catch (Exception source)
						{
							_error = ExceptionDispatchInfo.Capture(source);
							throw;
						}
					}
				}
			}
			return _();
			IEnumerator<T> _()
			{
				int index = 0;
				while (true)
				{
					T val;
					lock (_locker)
					{
						if (_cache == null)
						{
							throw new ObjectDisposedException("MemoizedEnumerable");
						}
						if (index >= _cache.Count)
						{
							if (index == _errorIndex)
							{
								_error.Throw();
							}
							if (_sourceEnumerator == null)
							{
								break;
							}
							bool flag;
							try
							{
								flag = _sourceEnumerator.MoveNext();
							}
							catch (Exception source2)
							{
								_error = ExceptionDispatchInfo.Capture(source2);
								_errorIndex = index;
								_sourceEnumerator.Dispose();
								_sourceEnumerator = null;
								throw;
							}
							if (!flag)
							{
								_sourceEnumerator.Dispose();
								_sourceEnumerator = null;
								break;
							}
							_cache.Add(_sourceEnumerator.Current);
						}
						val = _cache[index];
					}
					yield return val;
					index++;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			lock (_locker)
			{
				_error = null;
				_cache = null;
				_errorIndex = null;
				_sourceEnumerator?.Dispose();
				_sourceEnumerator = null;
			}
		}
	}
}
