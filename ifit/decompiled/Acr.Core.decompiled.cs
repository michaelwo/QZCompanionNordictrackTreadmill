using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Acr.Reactive;
using Acr.Reflection;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Java.IO;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v8.0", FrameworkDisplayName = "Xamarin.Android v8.0 Support")]
[assembly: AssemblyCompany("aritchie")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("ACR Core Extensions")]
[assembly: AssemblyFileVersion("2.2.0.0")]
[assembly: AssemblyInformationalVersion("2.2.0")]
[assembly: AssemblyProduct("ACR Core Extensions (MonoAndroid80)")]
[assembly: AssemblyTitle("Acr.Core")]
[assembly: AssemblyVersion("2.2.0.0")]
namespace Acr
{
	public interface IPlatform
	{
		void InvokeOnMainThread(Action action);
	}
	public static class Platform
	{
		private static IPlatform current;

		public static IPlatform Current
		{
			get
			{
				if (current == null)
				{
					throw new Exception("[Acr.Core] Platform implementation not found.  Have you added a nuget reference to your platform project?");
				}
				return current;
			}
			set
			{
				current = value;
			}
		}

		static Platform()
		{
			Current = new PlatformImpl();
		}
	}
	public static class PlatformExtensions
	{
		public static IObservable<T> InvokeOnMainThread<T>(this IPlatform platform, Func<T> func)
		{
			return Observable.Create(delegate(IObserver<T> ob)
			{
				platform.InvokeOnMainThread(delegate
				{
					try
					{
						T value = func();
						ob.Respond(value);
					}
					catch (Exception error)
					{
						ob.OnError(error);
					}
				});
				return Disposable.Empty;
			});
		}

		public static IObservable<Unit> InvokeOnMainThread<T>(this IPlatform platform, Action action)
		{
			return Observable.Create(delegate(IObserver<Unit> ob)
			{
				platform.InvokeOnMainThread(delegate
				{
					try
					{
						action();
						ob.Respond(Unit.Default);
					}
					catch (Exception error)
					{
						ob.OnError(error);
					}
				});
				return Disposable.Empty;
			});
		}
	}
	public static class StringExtensions
	{
		public static bool IsEmpty(this string s)
		{
			return string.IsNullOrWhiteSpace(s);
		}

		public static bool HasMinLength(this string @string, int length)
		{
			if (@string.IsEmpty())
			{
				return false;
			}
			return @string.Length >= length;
		}

		public static byte[] FromHexString(this string hex)
		{
			hex = hex.Replace("-", string.Empty).Replace(" ", string.Empty);
			return (from x in Enumerable.Range(0, hex.Length)
				where x % 2 == 0
				select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
		}

		public static string ToHexString(this byte[] bytes)
		{
			return string.Concat(bytes.Select((byte b) => b.ToString("X2")));
		}
	}
	public static class AndroidObservables
	{
		public static IObservable<Configuration> WhenConfigurationChanged()
		{
			return from intent in WhenIntentReceived("android.intent.action.CONFIGURATION_CHANGED")
				select Application.Context.Resources.Configuration;
		}

		public static IObservable<Intent> WhenIntentReceived(string intentAction)
		{
			return Observable.Create(delegate(IObserver<Intent> ob)
			{
				IntentFilter intentFilter = new IntentFilter();
				intentFilter.AddAction(intentAction);
				ObservableBroadcastReceiver receiver = new ObservableBroadcastReceiver
				{
					OnEvent = ob.OnNext
				};
				Application.Context.RegisterReceiver(receiver, intentFilter);
				return delegate
				{
					Application.Context.UnregisterReceiver(receiver);
				};
			});
		}
	}
	public class ObservableBroadcastReceiver : BroadcastReceiver
	{
		public Action<Intent> OnEvent { get; set; }

		public override void OnReceive(Context context, Intent intent)
		{
			OnEvent?.Invoke(intent);
		}
	}
	public class PlatformImpl : IPlatform
	{
		public void InvokeOnMainThread(Action action)
		{
			if (Application.SynchronizationContext == SynchronizationContext.Current)
			{
				action();
				return;
			}
			Application.SynchronizationContext.Post(delegate
			{
				action();
			}, null);
		}
	}
	public class StickyService : Service
	{
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			return StartCommandResult.Sticky;
		}
	}
}
namespace Acr.Reflection
{
	public static class ReflectionExtensions
	{
		public static PropertyInfo GetPropertyInfo<TSender, TRet>(this TSender sender, Expression<Func<TSender, TRet>> expression)
		{
			MemberExpression memberExpression = expression.Body as MemberExpression;
			return sender.GetType().GetRuntimeProperty(memberExpression.Member.Name);
		}

		public static Type UnwrapType(Type type)
		{
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = Nullable.GetUnderlyingType(type);
			}
			return type;
		}
	}
}
namespace Acr.Reactive
{
	public class ClearableReplaySubject<TSource, TClearTrigger> : IConnectableObservable<TSource>, IObservable<TSource>
	{
		private readonly IConnectableObservable<IObservable<TSource>> underlying;

		private readonly SerialDisposable replayConnectDisposable = new SerialDisposable();

		public ClearableReplaySubject(IObservable<TSource> src, IObservable<TClearTrigger> clearTrigger)
		{
			ClearableReplaySubject<TSource, TClearTrigger> clearableReplaySubject = this;
			underlying = clearTrigger.Select((TClearTrigger _) => Unit.Default).StartWith(Unit.Default).Select((Func<Unit, IConnectableObservable<TSource>>)delegate
			{
				IConnectableObservable<TSource> connectableObservable = src.Replay();
				clearableReplaySubject.replayConnectDisposable.Disposable = connectableObservable.Connect();
				return connectableObservable;
			})
				.Replay(1);
		}

		public IDisposable Subscribe(IObserver<TSource> observer)
		{
			return underlying.Switch().Subscribe(observer);
		}

		public IDisposable Connect()
		{
			return new CompositeDisposable(underlying.Connect(), replayConnectDisposable.Disposable);
		}
	}
	public class ObservableQueue
	{
		private readonly ConcurrentQueue<Func<Task>> queue = new ConcurrentQueue<Func<Task>>();

		public bool IsProcessing { get; private set; }

		public int ItemsInQueue => queue.Count;

		public IObservable<T> Queue<T>(IObservable<T> observable)
		{
			return Observable.Create(delegate(IObserver<T> ob)
			{
				bool cancel = false;
				queue.Enqueue(async delegate
				{
					try
					{
						if (!cancel)
						{
							T value = await observable.Take(1).ToTask().ConfigureAwait(continueOnCapturedContext: false);
							ob.Respond(value);
						}
					}
					catch (Exception error)
					{
						ob.OnError(error);
					}
				});
				ProcessQueue();
				return delegate
				{
					cancel = true;
				};
			});
		}

		private async void ProcessQueue()
		{
			if (!IsProcessing)
			{
				IsProcessing = true;
				Func<Task> result;
				while (queue.TryDequeue(out result))
				{
					await result();
				}
				IsProcessing = false;
			}
		}
	}
	public static class RxExtensions
	{
		public static IConnectableObservable<TItem> ReplayWithReset<TItem, TReset>(this IObservable<TItem> src, IObservable<TReset> resetTrigger)
		{
			return new ClearableReplaySubject<TItem, TReset>(src, resetTrigger);
		}

		public static void Respond<T>(this IObserver<T> ob, T value)
		{
			ob.OnNext(value);
			ob.OnCompleted();
		}

		public static IObservable<List<TOut>> SelectEach<TIn, TOut>(this IObservable<List<TIn>> observable, Func<TIn, TOut> transform)
		{
			return observable.Select(delegate(List<TIn> data)
			{
				List<TOut> list = new List<TOut>();
				foreach (TIn datum in data)
				{
					TOut item = transform(datum);
					list.Add(item);
				}
				return list;
			});
		}

		public static IObservable<List<Timestamped<T>>> BufferWhile<T>(this IObservable<T> thisObs, Func<T, bool> predicate)
		{
			return Observable.Create(delegate(IObserver<List<Timestamped<T>>> ob)
			{
				List<Timestamped<T>> list = null;
				return thisObs.Timestamp().Subscribe(delegate(Timestamped<T> x)
				{
					if (predicate(x.Value))
					{
						if (list == null)
						{
							list = new List<Timestamped<T>>();
						}
						list.Add(x);
					}
					else if (list != null)
					{
						ob.OnNext(list);
						list = null;
					}
				});
			});
		}

		public static IObservable<TRet> RxWhenAnyValue<TSender, TRet>(this TSender This, Expression<Func<TSender, TRet>> expression) where TSender : INotifyPropertyChanged
		{
			PropertyInfo p = This.GetPropertyInfo(expression);
			return from x in Observable.FromEventPattern<PropertyChangedEventArgs>(This, "PropertyChanged").StartWith(new EventPattern<PropertyChangedEventArgs>(This, new PropertyChangedEventArgs(p.Name)))
				where x.EventArgs.PropertyName == p.Name
				select (TRet)p.GetValue(This);
		}

		public static IObservable<TSender> RxWhenAnyPropertyChanged<TSender>(this TSender This) where TSender : INotifyPropertyChanged
		{
			return from x in Observable.FromEventPattern<PropertyChangedEventArgs>(This, "PropertyChanged")
				select This;
		}

		public static IDisposable ApplyMaxLengthConstraint<T>(this T npc, Expression<Func<T, string>> expression, int maxLength) where T : INotifyPropertyChanged
		{
			PropertyInfo property = npc.GetPropertyInfo(expression);
			if (property.PropertyType != typeof(string))
			{
				throw new ArgumentException($"You can only use maxlength constraints on string based properties - {npc.GetType()}.{property.Name}");
			}
			if (!property.CanWrite)
			{
				throw new ArgumentException($"You can only apply maxlength constraints to public setter properties - {npc.GetType()}.{property.Name}");
			}
			return (from x in npc.RxWhenAnyValue(expression)
				where x != null && x.Length > maxLength
				select x).Subscribe(delegate(string x)
			{
				string value = x.Substring(0, maxLength);
				property.SetValue(npc, value);
			});
		}
	}
}
namespace Acr.Logging
{
	public static class Log
	{
		public static LogLevel MinLogLevel { get; set; }

		public static Action<string, string, LogLevel> Out { get; set; }

		static Log()
		{
			MinLogLevel = LogLevel.Info;
			Out = delegate
			{
			};
		}

		public static void Debug(string category, string msg)
		{
			Write(category, msg);
		}

		public static void Info(string category, string msg)
		{
			Write(category, msg, LogLevel.Info);
		}

		public static void Warn(string category, string msg)
		{
			Write(category, msg, LogLevel.Warn);
		}

		public static void Error(string category, string msg)
		{
			Write(category, msg, LogLevel.Error);
		}

		public static void Write(string category, string msg, LogLevel level = LogLevel.Debug)
		{
			if (level >= MinLogLevel)
			{
				Out?.Invoke(category, msg, level);
			}
		}

		public static void ToDebug()
		{
			Out = delegate
			{
			};
		}
	}
	public enum LogLevel
	{
		Debug,
		Info,
		Warn,
		Error
	}
}
namespace Acr.IO
{
	public class ControlStream : Stream
	{
		private readonly Stream innerStream;

		public bool IsOperationsCancelled { get; private set; }

		public override int ReadTimeout => innerStream.ReadTimeout;

		public override int WriteTimeout => innerStream.WriteTimeout;

		public override bool CanRead => innerStream.CanRead;

		public override bool CanSeek => innerStream.CanSeek;

		public override bool CanWrite => innerStream.CanWrite;

		public override long Length => innerStream.Length;

		public override long Position
		{
			get
			{
				return innerStream.Position;
			}
			set
			{
				innerStream.Position = value;
			}
		}

		public event EventHandler<ControlStreamEventArgs> BytesMoved;

		public event EventHandler<ControlStreamEventArgs> BytesRead;

		public event EventHandler<ControlStreamEventArgs> BytesWritten;

		public ControlStream(Stream innerStream)
		{
			this.innerStream = innerStream;
		}

		public virtual void CancelOperations()
		{
			IsOperationsCancelled = true;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (IsOperationsCancelled)
			{
				throw new StreamOperationCanceledException();
			}
			int num = innerStream.Read(buffer, offset, count);
			OnEvent(read: true, Position, Length, num);
			return num;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (IsOperationsCancelled)
			{
				throw new StreamOperationCanceledException();
			}
			innerStream.Write(buffer, offset, count);
			OnEvent(read: false, Position, Length, count);
		}

		protected virtual void OnEvent(bool read, long position, long length, int byteCount)
		{
			ControlStreamEventArgs e = new ControlStreamEventArgs(read, byteCount, length, byteCount);
			this.BytesMoved?.Invoke(this, e);
			if (read)
			{
				this.BytesRead?.Invoke(this, e);
			}
			else
			{
				this.BytesWritten?.Invoke(this, e);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return innerStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			innerStream.SetLength(value);
		}

		public override void Flush()
		{
			innerStream.Flush();
		}
	}
	public class ControlStreamEventArgs : EventArgs
	{
		public long Bytes { get; }

		public long Position { get; }

		public long Length { get; }

		public bool IsRead { get; }

		public ControlStreamEventArgs(bool read, long bytes, long length, long position)
		{
			IsRead = read;
			Bytes = bytes;
			Length = length;
			Position = position;
		}
	}
	public static class Extensions
	{
		public static string ToTempFile(this Stream stream, int bufferSize = 8192)
		{
			string tempFileName = Path.GetTempFileName();
			using FileStream destination = System.IO.File.Create(tempFileName, bufferSize);
			stream.CopyTo(destination, bufferSize);
			return tempFileName;
		}

		public static async Task<string> ToTempFileAsync(this Stream stream, int bufferSize = 8192, CancellationToken? cancelToken = null)
		{
			string path = Path.GetTempFileName();
			using (FileStream fs = System.IO.File.Create(path, bufferSize))
			{
				await stream.CopyToAsync(fs, bufferSize, cancelToken ?? CancellationToken.None);
			}
			return path;
		}

		public static IObservable<FileProgress> CopyProgress(this FileInfo from, FileInfo target, bool overwriteIfExists)
		{
			return Observable.Create(async delegate(IObserver<FileProgress> ob)
			{
				bool completed = false;
				CancellationTokenSource cts = new CancellationTokenSource();
				if (overwriteIfExists)
				{
					target.DeleteIfExists();
				}
				byte[] buffer = new byte[65535];
				int totalCopy = 0;
				DateTime start = DateTime.UtcNow;
				using (FileStream readStream = from.OpenRead())
				{
					using FileStream writeStream = target.Create();
					int num = await readStream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
					while (num > 0 && !cts.IsCancellationRequested)
					{
						await writeStream.WriteAsync(buffer, 0, num, cts.Token).ConfigureAwait(continueOnCapturedContext: false);
						num = await readStream.ReadAsync(buffer, 0, buffer.Length, cts.Token).ConfigureAwait(continueOnCapturedContext: false);
						totalCopy += num;
						ob.OnNext(new FileProgress(totalCopy, from.Length, start));
					}
				}
				completed = true;
				ob.OnCompleted();
				return delegate
				{
					cts.Cancel();
					if (!completed)
					{
						target.DeleteIfExists();
					}
				};
			});
		}

		public static FileInfo GetExistingFile(this DirectoryInfo directory, string fileName)
		{
			return directory.GetFiles().FirstOrDefault((FileInfo x) => x.Name.Equals(fileName, StringComparison.Ordinal));
		}

		public static bool TryDelete(string filePath)
		{
			if (!System.IO.File.Exists(filePath))
			{
				return false;
			}
			System.IO.File.Delete(filePath);
			return true;
		}

		public static void DeleteIfExists(this FileInfo file)
		{
			if (file.Exists)
			{
				file.Delete();
			}
		}
	}
	public class FileProgress
	{
		public TimeSpan TimeRemaining { get; }

		public TimeSpan TimeSpent { get; }

		public int PercentComplete { get; }

		public long FileSize { get; }

		public long BytesCompleted { get; }

		public double BytesPerSecond { get; }

		public FileProgress(long bytesCompleted, long fileSize, DateTime startUtc)
		{
			FileSize = fileSize;
			BytesCompleted = bytesCompleted;
			PercentComplete = Convert.ToInt32((double)bytesCompleted * 100.0 / (double)fileSize);
			TimeSpent = DateTime.UtcNow.Subtract(startUtc);
			BytesPerSecond = (double)bytesCompleted / TimeSpent.TotalSeconds;
			TimeRemaining = TimeSpan.FromSeconds((double)BytesCompleted / BytesPerSecond);
		}
	}
	public static class FileSystem
	{
		private static IFileSystem current;

		public static IFileSystem Current
		{
			get
			{
				if (current == null)
				{
					throw new Exception("[Acr.Core] FileSystem platform implementation not found.  Have you added a nuget reference to your platform project?");
				}
				return current;
			}
			set
			{
				current = value;
			}
		}

		static FileSystem()
		{
			Current = new FileSystemImpl();
		}
	}
	public interface IFileSystem
	{
		DirectoryInfo AppData { get; }

		DirectoryInfo Cache { get; }

		DirectoryInfo Public { get; }

		string ToFileUri(string path);
	}
	public class StreamOperationCanceledException : Exception
	{
		public StreamOperationCanceledException()
			: base("Stream operations have been cancelled")
		{
		}
	}
	public class FileSystemImpl : IFileSystem
	{
		public DirectoryInfo AppData { get; }

		public DirectoryInfo Cache { get; }

		public DirectoryInfo Public { get; }

		public FileSystemImpl()
		{
			Context context = Application.Context;
			Cache = new DirectoryInfo(context.CacheDir.AbsolutePath);
			string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			AppData = new DirectoryInfo(folderPath);
			Java.IO.File externalFilesDir = context.GetExternalFilesDir(null);
			if (externalFilesDir != null)
			{
				Public = new DirectoryInfo(externalFilesDir.AbsolutePath);
			}
		}

		public string ToFileUri(string path)
		{
			return "file:/" + path;
		}
	}
}
namespace Acr.ComponentModel
{
	public class NotifyPropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
		{
			if (!(expression.Body is MemberExpression memberExpression))
			{
				throw new ArgumentException("Expression is not a MemberExpression");
			}
			OnPropertyChanged(memberExpression.Member.Name);
		}

		protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(property, value))
			{
				return false;
			}
			property = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
namespace Acr.Collections
{
	public static class EnumerableExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> en)
		{
			if (en != null)
			{
				return !en.Any();
			}
			return true;
		}

		public static void Each<T>(this IEnumerable<T> en, Action<T> action)
		{
			if (en == null)
			{
				return;
			}
			foreach (T item in en)
			{
				action(item);
			}
		}

		public static void Each<T>(this IEnumerable<T> en, Action<int, T> action)
		{
			if (en == null)
			{
				return;
			}
			int num = 0;
			foreach (T item in en)
			{
				action(num, item);
				num++;
			}
		}
	}
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
	{
		private const string CountString = "Count";

		private const string IndexerName = "Item[]";

		private const string KeysName = "Keys";

		private const string ValuesName = "Values";

		private IDictionary<TKey, TValue> innerDictionary;

		protected IDictionary<TKey, TValue> InnerDictionary => innerDictionary;

		public ICollection<TKey> Keys => InnerDictionary.Keys;

		public ICollection<TValue> Values => InnerDictionary.Values;

		public TValue this[TKey key]
		{
			get
			{
				return InnerDictionary[key];
			}
			set
			{
				Insert(key, value, add: false);
			}
		}

		public int Count => InnerDictionary.Count;

		public bool IsReadOnly => InnerDictionary.IsReadOnly;

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableDictionary()
		{
			innerDictionary = new Dictionary<TKey, TValue>();
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			innerDictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
			innerDictionary = new Dictionary<TKey, TValue>(comparer);
		}

		public ObservableDictionary(int capacity)
		{
			innerDictionary = new Dictionary<TKey, TValue>(capacity);
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			innerDictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			innerDictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		public void Add(TKey key, TValue value)
		{
			Insert(key, value, add: true);
		}

		public bool ContainsKey(TKey key)
		{
			return InnerDictionary.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			InnerDictionary.TryGetValue(key, out var _);
			bool num = InnerDictionary.Remove(key);
			if (num)
			{
				OnCollectionChanged();
			}
			return num;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return InnerDictionary.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Insert(item.Key, item.Value, add: true);
		}

		public void Clear()
		{
			if (InnerDictionary.Count > 0)
			{
				InnerDictionary.Clear();
				OnCollectionChanged();
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return InnerDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			InnerDictionary.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return InnerDictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)InnerDictionary).GetEnumerator();
		}

		public void AddRange(IDictionary<TKey, TValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (items.Count <= 0)
			{
				return;
			}
			if (InnerDictionary.Count > 0)
			{
				if (items.Keys.Any((TKey k) => InnerDictionary.ContainsKey(k)))
				{
					throw new ArgumentException("An item with the same key has already been added.");
				}
				foreach (KeyValuePair<TKey, TValue> item in items)
				{
					InnerDictionary.Add(item);
				}
			}
			else
			{
				innerDictionary = new Dictionary<TKey, TValue>(items);
			}
			OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
		}

		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (InnerDictionary.TryGetValue(key, out var value2))
			{
				if (add)
				{
					throw new ArgumentException("An item with the same key has already been added.");
				}
				if (!object.Equals(value2, value))
				{
					InnerDictionary[key] = value;
					OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, value2));
				}
			}
			else
			{
				InnerDictionary[key] = value;
				OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
			}
		}

		private void OnPropertyChanged()
		{
			OnPropertyChanged("Count");
			OnPropertyChanged("Item[]");
			OnPropertyChanged("Keys");
			OnPropertyChanged("Values");
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void OnCollectionChanged()
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
		}
	}
	public class ObservableList<T> : ObservableCollection<T>
	{
		public ObservableList()
		{
		}

		public ObservableList(IEnumerable<T> items)
			: base(items)
		{
		}

		public virtual void AddRange(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				base.Items.Add(item);
			}
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items));
		}

		public virtual void Repopulate(IEnumerable<T> items)
		{
			Clear();
			foreach (T item in items)
			{
				base.Items.Add(item);
			}
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
namespace Acr.Caching
{
	public abstract class AbstractCache : ICache, IDisposable
	{
		private readonly object syncLock = new object();

		private bool init;

		public TimeSpan DefaultLifeSpan { get; set; }

		public bool Enabled { get; set; }

		protected abstract void Init();

		protected void EnsureInitialized()
		{
			if (init)
			{
				return;
			}
			lock (syncLock)
			{
				Init();
				init = true;
			}
		}

		public virtual async Task<T> TryGet<T>(string key, Func<Task<T>> getter, TimeSpan? timeSpan = null)
		{
			T val = Get<T>(key);
			if (val == null)
			{
				val = await getter();
				Set(key, val, timeSpan);
			}
			return val;
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public virtual void Dispose()
		{
			Dispose(disposing: true);
		}

		public abstract void Set(string key, object obj, TimeSpan? timeSpan = null);

		public abstract T Get<T>(string key);

		public abstract bool Remove(string key);

		public abstract void Clear();
	}
	public abstract class AbstractTimerCache : AbstractCache
	{
		private readonly CancellationTokenSource cancelSource = new CancellationTokenSource();

		public TimeSpan CleanUpTime { get; set; }

		protected abstract void OnTimerElapsed();

		protected override void Init()
		{
			RunCleanUp();
		}

		private async Task RunCleanUp()
		{
			while (!cancelSource.IsCancellationRequested)
			{
				try
				{
					await Task.Delay(CleanUpTime);
					if (cancelSource.IsCancellationRequested)
					{
						break;
					}
					OnTimerElapsed();
				}
				catch (Exception)
				{
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				cancelSource.Cancel(throwOnFirstException: false);
			}
		}
	}
	public class CacheItem
	{
		public string Key { get; set; }

		public DateTime ExpiryTime { get; set; }

		public object Object { get; set; }
	}
	public interface ICache
	{
		TimeSpan DefaultLifeSpan { get; set; }

		bool Enabled { get; set; }

		void Set(string key, object obj, TimeSpan? timeSpan = null);

		T Get<T>(string key);

		Task<T> TryGet<T>(string key, Func<Task<T>> getter, TimeSpan? timeSpan = null);

		bool Remove(string key);

		void Clear();
	}
	public class MemoryCache : AbstractTimerCache
	{
		private readonly IDictionary<string, object> cache = new Dictionary<string, object>();

		private readonly object syncLock = new object();

		protected override void OnTimerElapsed()
		{
			DateTime now = DateTime.UtcNow;
			lock (syncLock)
			{
				foreach (CacheItem item in (from x in cache.Keys
					select (CacheItem)cache[x] into x
					where x.ExpiryTime < now
					select x).ToList())
				{
					cache.Remove(item.Key);
				}
			}
		}

		public override void Clear()
		{
			lock (syncLock)
			{
				cache.Clear();
			}
		}

		public override T Get<T>(string key)
		{
			if (!base.Enabled)
			{
				return default(T);
			}
			lock (syncLock)
			{
				if (!cache.ContainsKey(key))
				{
					return default(T);
				}
				return (T)((CacheItem)cache[key]).Object;
			}
		}

		public override bool Remove(string key)
		{
			if (!base.Enabled)
			{
				return false;
			}
			lock (syncLock)
			{
				return cache.Remove(key);
			}
		}

		public override void Set(string key, object obj, TimeSpan? timeSpan = null)
		{
			if (!base.Enabled)
			{
				return;
			}
			EnsureInitialized();
			lock (syncLock)
			{
				TimeSpan value = timeSpan ?? base.DefaultLifeSpan;
				CacheItem value2 = new CacheItem
				{
					Key = key,
					Object = obj,
					ExpiryTime = DateTime.UtcNow.Add(value)
				};
				cache[key] = value2;
			}
		}
	}
	public class VoidCacheImpl : AbstractCache
	{
		protected override void Init()
		{
		}

		public override T Get<T>(string key)
		{
			return default(T);
		}

		public override void Set(string key, object obj, TimeSpan? timeSpan = null)
		{
		}

		public override void Clear()
		{
		}

		public override bool Remove(string key)
		{
			return false;
		}
	}
}
