using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Core;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Serialization;
using Splat;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("7.1.1.22514")]
[assembly: AssemblyInformationalVersion("7.1.1+f257b0f8b9")]
[assembly: InternalsVisibleTo("Akavache.Tests")]
[assembly: InternalsVisibleTo("Akavache.Sqlite3")]
[assembly: InternalsVisibleTo("Akavache.Mobile")]
[assembly: InternalsVisibleTo("Akavache.Drawing")]
[assembly: InternalsVisibleTo("Akavache")]
[assembly: Akavache.Core.Preserve]
[assembly: ResourceDesigner("Akavache.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("An asynchronous, persistent key-value store for desktop and mobile applications on .NET")]
[assembly: AssemblyProduct("Akavache.Core (MonoAndroid90)")]
[assembly: AssemblyTitle("Akavache.Core")]
[assembly: AssemblyVersion("7.1.0.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "7.1.0.0";

	internal const string AssemblyFileVersion = "7.1.1.22514";

	internal const string AssemblyInformationalVersion = "7.1.1+f257b0f8b9";

	internal const string AssemblyName = "Akavache.Core";

	internal const string AssemblyTitle = "Akavache.Core";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "f257b0f8b93ff304a0dc9c9fe33dbad619138537";

	internal const bool IsPublicRelease = true;

	internal const bool IsPrerelease = false;

	internal static readonly DateTime GitCommitDate = new DateTime(637390339680000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Akavache";
}
namespace System
{
	public static class StreamMixins
	{
		public static IObservable<Unit> WriteAsyncRx(this Stream blobCache, byte[] data, int start, int length)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			AsyncSubject<Unit> ret = new AsyncSubject<Unit>();
			try
			{
				blobCache.BeginWrite(data, start, length, delegate(IAsyncResult result)
				{
					try
					{
						blobCache.EndWrite(result);
						ret.OnNext(Unit.Default);
						ret.OnCompleted();
					}
					catch (Exception error2)
					{
						ret.OnError(error2);
					}
				}, null);
			}
			catch (Exception error)
			{
				ret.OnError(error);
			}
			return ret;
		}
	}
}
namespace Akavache
{
	public static class BlobCache
	{
		private class ShutdownBlobCache : ISecureBlobCache, IBlobCache, IDisposable
		{
			IObservable<Unit> IBlobCache.Shutdown => Observable.Return(Unit.Default);

			public IScheduler Scheduler => System.Reactive.Concurrency.Scheduler.Immediate;

			public DateTimeKind? ForcedDateTimeKind
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public void Dispose()
			{
			}

			public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
			{
				return Observable.Empty<Unit>();
			}

			public IObservable<byte[]> Get(string key)
			{
				return Observable.Empty<byte[]>();
			}

			public IObservable<IEnumerable<string>> GetAllKeys()
			{
				return Observable.Empty<IEnumerable<string>>();
			}

			public IObservable<DateTimeOffset?> GetCreatedAt(string key)
			{
				return Observable.Empty<DateTimeOffset?>();
			}

			public IObservable<Unit> Flush()
			{
				return Observable.Empty<Unit>();
			}

			public IObservable<Unit> Invalidate(string key)
			{
				return Observable.Empty<Unit>();
			}

			public IObservable<Unit> InvalidateAll()
			{
				return Observable.Empty<Unit>();
			}

			public IObservable<Unit> Vacuum()
			{
				return Observable.Empty<Unit>();
			}
		}

		private static string? _applicationName;

		private static IBlobCache? _localMachine;

		private static IBlobCache? _userAccount;

		private static ISecureBlobCache? _secure;

		private static bool _shutdownRequested;

		private static IScheduler? _taskPoolOverride;

		[ThreadStatic]
		private static IBlobCache? _unitTestLocalMachine;

		[ThreadStatic]
		private static IBlobCache? _unitTestUserAccount;

		[ThreadStatic]
		private static ISecureBlobCache? _unitTestSecure;

		public static string ApplicationName
		{
			get
			{
				if (_applicationName == null)
				{
					throw new Exception("Make sure to set BlobCache.ApplicationName on startup");
				}
				return _applicationName;
			}
			set
			{
				_applicationName = value;
			}
		}

		public static IBlobCache LocalMachine
		{
			get
			{
				object obj = _unitTestLocalMachine;
				if (obj == null)
				{
					obj = _localMachine;
					if (obj == null)
					{
						IBlobCache blobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
						obj = blobCache ?? Locator.Current.GetService<IBlobCache>("LocalMachine");
					}
				}
				return (IBlobCache)obj;
			}
			set
			{
				if (ModeDetector.InUnitTestRunner())
				{
					_unitTestLocalMachine = value;
					if (_localMachine == null)
					{
						_localMachine = value;
					}
				}
				else
				{
					_localMachine = value;
				}
			}
		}

		public static IBlobCache UserAccount
		{
			get
			{
				object obj = _unitTestUserAccount;
				if (obj == null)
				{
					obj = _userAccount;
					if (obj == null)
					{
						IBlobCache blobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
						obj = blobCache ?? Locator.Current.GetService<IBlobCache>("UserAccount");
					}
				}
				return (IBlobCache)obj;
			}
			set
			{
				if (ModeDetector.InUnitTestRunner())
				{
					_unitTestUserAccount = value;
					if (_userAccount == null)
					{
						_userAccount = value;
					}
				}
				else
				{
					_userAccount = value;
				}
			}
		}

		public static ISecureBlobCache Secure
		{
			get
			{
				object obj = _unitTestSecure;
				if (obj == null)
				{
					obj = _secure;
					if (obj == null)
					{
						ISecureBlobCache secureBlobCache = (_shutdownRequested ? new ShutdownBlobCache() : null);
						obj = secureBlobCache ?? Locator.Current.GetService<ISecureBlobCache>();
					}
				}
				return (ISecureBlobCache)obj;
			}
			set
			{
				if (ModeDetector.InUnitTestRunner())
				{
					_unitTestSecure = value;
					if (_secure == null)
					{
						_secure = value;
					}
				}
				else
				{
					_secure = value;
				}
			}
		}

		public static ISecureBlobCache InMemory { get; set; }

		public static DateTimeKind? ForcedDateTimeKind { get; set; }

		public static IScheduler TaskpoolScheduler
		{
			get
			{
				return _taskPoolOverride ?? Locator.Current.GetService<IScheduler>("Taskpool") ?? TaskPoolScheduler.Default;
			}
			set
			{
				_taskPoolOverride = value;
			}
		}

		static BlobCache()
		{
			Locator.RegisterResolverCallbackChanged(delegate
			{
				if (Locator.CurrentMutable != null)
				{
					Locator.CurrentMutable.InitializeAkavache(Locator.Current);
				}
			});
			InMemory = new InMemoryBlobCache(Scheduler.Default);
		}

		public static void EnsureInitialized()
		{
			LogHost.Default.Debug("Initializing Akavache");
		}

		public static Task Shutdown()
		{
			_shutdownRequested = true;
			return (from _ in new IBlobCache[4] { LocalMachine, UserAccount, Secure, InMemory }.Select(delegate(IBlobCache x)
				{
					x.Dispose();
					return x.Shutdown;
				}).Merge().ToList()
				select Unit.Default).ToTask();
		}
	}
	public class CacheEntry
	{
		public DateTimeOffset CreatedAt { get; protected set; }

		public DateTimeOffset? ExpiresAt { get; protected set; }

		public string? TypeName { get; protected set; }

		public byte[] Value { get; protected set; }

		public CacheEntry(string? typeName, byte[] value, DateTimeOffset createdAt, DateTimeOffset? expiresAt)
		{
			TypeName = typeName;
			Value = value;
			CreatedAt = createdAt;
			ExpiresAt = expiresAt;
		}
	}
	public interface IBlobCache : IDisposable
	{
		IObservable<Unit> Shutdown { get; }

		IScheduler Scheduler { get; }

		DateTimeKind? ForcedDateTimeKind { get; set; }

		IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null);

		IObservable<byte[]> Get(string key);

		IObservable<IEnumerable<string>> GetAllKeys();

		IObservable<DateTimeOffset?> GetCreatedAt(string key);

		IObservable<Unit> Flush();

		IObservable<Unit> Invalidate(string key);

		IObservable<Unit> InvalidateAll();

		IObservable<Unit> Vacuum();
	}
	public interface IBulkBlobCache : IBlobCache, IDisposable
	{
		IObservable<Unit> Insert(IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

		IObservable<IDictionary<string, byte[]>> Get(IEnumerable<string> keys);

		IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(IEnumerable<string> keys);

		IObservable<Unit> Invalidate(IEnumerable<string> keys);
	}
	public class InMemoryBlobCache : ISecureBlobCache, IBlobCache, IDisposable, IObjectBlobCache, IEnableLogger
	{
		private readonly AsyncSubject<Unit> _shutdown = new AsyncSubject<Unit>();

		private readonly IDisposable? _inner;

		private Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();

		private bool _disposed;

		private DateTimeKind? _dateTimeKind;

		private JsonDateTimeContractResolver _jsonDateTimeContractResolver = new JsonDateTimeContractResolver();

		public DateTimeKind? ForcedDateTimeKind
		{
			get
			{
				return _dateTimeKind ?? BlobCache.ForcedDateTimeKind;
			}
			set
			{
				_dateTimeKind = value;
				if (_jsonDateTimeContractResolver != null)
				{
					_jsonDateTimeContractResolver.ForceDateTimeKindOverride = value;
				}
			}
		}

		public IScheduler Scheduler { get; protected set; }

		public IObservable<Unit> Shutdown => _shutdown;

		public InMemoryBlobCache()
			: this(null, null)
		{
		}

		public InMemoryBlobCache(IScheduler scheduler)
			: this(scheduler, null)
		{
		}

		public InMemoryBlobCache(IEnumerable<KeyValuePair<string, byte[]>> initialContents)
			: this(null, initialContents)
		{
		}

		public InMemoryBlobCache(IScheduler? scheduler, IEnumerable<KeyValuePair<string, byte[]>>? initialContents)
		{
			Scheduler = scheduler ?? CurrentThreadScheduler.Instance;
			foreach (KeyValuePair<string, byte[]> item in initialContents ?? Enumerable.Empty<KeyValuePair<string, byte[]>>())
			{
				_cache[item.Key] = new CacheEntry(null, item.Value, Scheduler.Now, null);
			}
		}

		internal InMemoryBlobCache(Action disposer, IScheduler? scheduler, IEnumerable<KeyValuePair<string, byte[]>> initialContents)
			: this(scheduler, initialContents)
		{
			_inner = Disposable.Create(disposer);
		}

		public static InMemoryBlobCache OverrideGlobals(IScheduler? scheduler = null, params KeyValuePair<string, byte[]>[] initialContents)
		{
			IBlobCache local = BlobCache.LocalMachine;
			IBlobCache user = BlobCache.UserAccount;
			ISecureBlobCache sec = BlobCache.Secure;
			return (InMemoryBlobCache)(BlobCache.UserAccount = (BlobCache.Secure = (ISecureBlobCache)(BlobCache.LocalMachine = new InMemoryBlobCache(delegate
			{
				BlobCache.LocalMachine = local;
				BlobCache.Secure = sec;
				BlobCache.UserAccount = user;
			}, scheduler, initialContents))));
		}

		public static InMemoryBlobCache OverrideGlobals(IDictionary<string, byte[]> initialContents, IScheduler? scheduler = null)
		{
			return OverrideGlobals(scheduler, initialContents.ToArray());
		}

		public static InMemoryBlobCache OverrideGlobals(IDictionary<string, object> initialContents, IScheduler? scheduler = null)
		{
			KeyValuePair<string, byte[]>[] initialContents2 = initialContents.Select<KeyValuePair<string, object>, KeyValuePair<string, byte[]>>((KeyValuePair<string, object> item) => new KeyValuePair<string, byte[]>(item.Key, JsonSerializationMixin.SerializeObject(item.Value))).ToArray();
			return OverrideGlobals(scheduler, initialContents2);
		}

		public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				_cache[key] = new CacheEntry(null, data, Scheduler.Now, absoluteExpiration);
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<Unit> Flush()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<byte[]> Get(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("InMemoryBlobCache");
			}
			CacheEntry value;
			lock (_cache)
			{
				if (!_cache.TryGetValue(key, out value))
				{
					return ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key);
				}
			}
			if (value.ExpiresAt.HasValue && Scheduler.Now > value.ExpiresAt.Value)
			{
				lock (_cache)
				{
					_cache.Remove(key);
				}
				return ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key);
			}
			return Observable.Return(value.Value, Scheduler);
		}

		public IObservable<DateTimeOffset?> GetCreatedAt(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<DateTimeOffset?>("InMemoryBlobCache");
			}
			CacheEntry value;
			lock (_cache)
			{
				if (!_cache.TryGetValue(key, out value))
				{
					return Observable.Return<DateTimeOffset?>(null);
				}
			}
			return Observable.Return((DateTimeOffset?)value.CreatedAt, Scheduler);
		}

		public IObservable<IEnumerable<string>> GetAllKeys()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<List<string>>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				return Observable.Return((from x in _cache
					where !x.Value.ExpiresAt.HasValue || x.Value.ExpiresAt >= Scheduler.Now
					select x.Key).ToList());
			}
		}

		public IObservable<Unit> Invalidate(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				_cache.Remove(key);
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<Unit> InvalidateAll()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				_cache.Clear();
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			byte[] value2 = SerializeObject(value);
			lock (_cache)
			{
				_cache[key] = new CacheEntry(typeof(T).FullName, value2, Scheduler.Now, absoluteExpiration);
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<T> GetObject<T>(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<T>("InMemoryBlobCache");
			}
			CacheEntry value;
			lock (_cache)
			{
				if (!_cache.TryGetValue(key, out value))
				{
					return ExceptionHelper.ObservableThrowKeyNotFoundException<T>(key);
				}
			}
			if (value.ExpiresAt.HasValue && Scheduler.Now > value.ExpiresAt.Value)
			{
				lock (_cache)
				{
					_cache.Remove(key);
				}
				return ExceptionHelper.ObservableThrowKeyNotFoundException<T>(key);
			}
			return Observable.Return(DeserializeObject<T>(value.Value), Scheduler);
		}

		public IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key)
		{
			return GetCreatedAt(key);
		}

		public IObservable<IEnumerable<T>> GetAllObjects<T>()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<IEnumerable<T>>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				return Observable.Return((from x in _cache
					where x.Value.TypeName == typeof(T).FullName && (!x.Value.ExpiresAt.HasValue || x.Value.ExpiresAt >= Scheduler.Now)
					select DeserializeObject<T>(x.Value.Value)).ToList(), Scheduler);
			}
		}

		public IObservable<Unit> InvalidateObject<T>(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			return Invalidate(key);
		}

		public IObservable<Unit> InvalidateAllObjects<T>()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				KeyValuePair<string, CacheEntry>[] array = _cache.Where<KeyValuePair<string, CacheEntry>>((KeyValuePair<string, CacheEntry> x) => x.Value.TypeName == typeof(T).FullName).ToArray();
				foreach (KeyValuePair<string, CacheEntry> keyValuePair in array)
				{
					_cache.Remove(keyValuePair.Key);
				}
			}
			return Observable.Return(Unit.Default);
		}

		public IObservable<Unit> Vacuum()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("InMemoryBlobCache");
			}
			lock (_cache)
			{
				KeyValuePair<string, CacheEntry>[] array = _cache.Where<KeyValuePair<string, CacheEntry>>(delegate(KeyValuePair<string, CacheEntry> x)
				{
					if (x.Value.ExpiresAt.HasValue)
					{
						DateTimeOffset now = Scheduler.Now;
						DateTimeOffset? expiresAt = x.Value.ExpiresAt;
						return now > expiresAt;
					}
					return false;
				}).ToArray();
				foreach (KeyValuePair<string, CacheEntry> keyValuePair in array)
				{
					_cache.Remove(keyValuePair.Key);
				}
			}
			return Observable.Return(Unit.Default);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (_disposed)
			{
				return;
			}
			if (isDisposing)
			{
				Scheduler = CurrentThreadScheduler.Instance;
				lock (_cache)
				{
					_cache.Clear();
				}
				_inner?.Dispose();
				_shutdown.OnNext(Unit.Default);
				_shutdown.OnCompleted();
			}
			_disposed = true;
		}

		private byte[] SerializeObject<T>(T value)
		{
			JsonSerializer serializer = GetSerializer();
			using MemoryStream memoryStream = new MemoryStream();
			using BsonDataWriter jsonWriter = new BsonDataWriter(memoryStream);
			serializer.Serialize(jsonWriter, new ObjectWrapper<T>
			{
				Value = value
			});
			return memoryStream.ToArray();
		}

		private T DeserializeObject<T>(byte[] data)
		{
			JsonSerializer serializer = GetSerializer();
			using BsonDataReader bsonDataReader = new BsonDataReader(new MemoryStream(data));
			DateTimeKind? forcedDateTimeKind = BlobCache.ForcedDateTimeKind;
			if (forcedDateTimeKind.HasValue)
			{
				bsonDataReader.DateTimeKindHandling = forcedDateTimeKind.Value;
			}
			try
			{
				ObjectWrapper<T> objectWrapper = serializer.Deserialize<ObjectWrapper<T>>(bsonDataReader);
				if (objectWrapper == null)
				{
					return default(T);
				}
				return objectWrapper.Value;
			}
			catch (Exception exception)
			{
				this.Log().Warn(exception, "Failed to deserialize data as boxed, we may be migrating from an old Akavache");
			}
			return serializer.Deserialize<T>(bsonDataReader);
		}

		private JsonSerializer GetSerializer()
		{
			JsonSerializerSettings jsonSerializerSettings = Locator.Current.GetService<JsonSerializerSettings>() ?? new JsonSerializerSettings();
			lock (jsonSerializerSettings)
			{
				_jsonDateTimeContractResolver.ExistingContractResolver = jsonSerializerSettings.ContractResolver;
				jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver;
				JsonSerializer result = JsonSerializer.Create(jsonSerializerSettings);
				jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver.ExistingContractResolver;
				return result;
			}
		}
	}
	public interface IObjectBlobCache : IBlobCache, IDisposable
	{
		IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null);

		IObservable<T> GetObject<T>(string key);

		IObservable<IEnumerable<T>> GetAllObjects<T>();

		IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key);

		IObservable<Unit> InvalidateObject<T>(string key);

		IObservable<Unit> InvalidateAllObjects<T>();
	}
	public interface IObjectBulkBlobCache : IObjectBlobCache, IBlobCache, IDisposable, IBulkBlobCache
	{
		IObservable<Unit> InsertObjects<T>(IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null);

		IObservable<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys);

		IObservable<Unit> InvalidateObjects<T>(IEnumerable<string> keys);
	}
	internal interface IObjectWrapper
	{
	}
	public interface ISecureBlobCache : IBlobCache, IDisposable
	{
	}
	internal class ObjectWrapper<T> : IObjectWrapper
	{
		public T Value { get; set; }
	}
	public static class BulkOperationsMixin
	{
		public static IObservable<IDictionary<string, byte[]>> Get(this IBlobCache blobCache, IEnumerable<string> keys)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Get(keys);
			}
			return keys.ToObservable().SelectMany((string x) => (from y in blobCache.Get(x)
				select new KeyValuePair<string, byte[]>(x, y)).Catch((KeyNotFoundException _) => Observable.Empty<KeyValuePair<string, byte[]>>())).ToDictionary((KeyValuePair<string, byte[]> k) => k.Key, (KeyValuePair<string, byte[]> v) => v.Value);
		}

		public static IObservable<Unit> Insert(this IBlobCache blobCache, IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Insert(keyValuePairs, absoluteExpiration);
			}
			return keyValuePairs.ToObservable().SelectMany<KeyValuePair<string, byte[]>, Unit>((KeyValuePair<string, byte[]> x) => blobCache.Insert(x.Key, x.Value, absoluteExpiration)).TakeLast(1);
		}

		public static IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(this IBlobCache blobCache, IEnumerable<string> keys)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.GetCreatedAt(keys);
			}
			return keys.ToObservable().SelectMany((string x) => from y in blobCache.GetCreatedAt(x)
				select new
				{
					Key = x,
					Value = y
				}).ToDictionary(k => k.Key, v => v.Value);
		}

		public static IObservable<Unit> Invalidate(this IBlobCache blobCache, IEnumerable<string> keys)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IBulkBlobCache bulkBlobCache)
			{
				return bulkBlobCache.Invalidate(keys);
			}
			return keys.ToObservable().SelectMany(blobCache.Invalidate).TakeLast(1);
		}

		public static IObservable<IDictionary<string, T>> GetObjects<T>(this IBlobCache blobCache, IEnumerable<string> keys)
		{
			if (blobCache is IObjectBulkBlobCache objectBulkBlobCache)
			{
				return objectBulkBlobCache.GetObjects<T>(keys);
			}
			return keys.ToObservable().SelectMany((string x) => (from y in blobCache.GetObject<T>(x)
				select new KeyValuePair<string, T>(x, y)).Catch((KeyNotFoundException _) => Observable.Empty<KeyValuePair<string, T>>())).ToDictionary((KeyValuePair<string, T> k) => k.Key, (KeyValuePair<string, T> v) => v.Value);
		}

		public static IObservable<Unit> InsertObjects<T>(this IBlobCache blobCache, IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBulkBlobCache objectBulkBlobCache)
			{
				return objectBulkBlobCache.InsertObjects(keyValuePairs, absoluteExpiration);
			}
			return keyValuePairs.ToObservable().SelectMany<KeyValuePair<string, T>, Unit>((KeyValuePair<string, T> x) => blobCache.InsertObject(x.Key, x.Value, absoluteExpiration)).TakeLast(1);
		}

		public static IObservable<Unit> InvalidateObjects<T>(this IBlobCache blobCache, IEnumerable<string> keys)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBulkBlobCache objectBulkBlobCache)
			{
				return objectBulkBlobCache.InvalidateObjects<T>(keys);
			}
			return keys.ToObservable().SelectMany(blobCache.InvalidateObject<T>).TakeLast(1);
		}
	}
	public enum DataProtectionScope
	{
		CurrentUser
	}
	public static class DependencyResolverMixin
	{
		public static void InitializeAkavache(this IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
		{
			string[] obj = new string[7] { "Akavache", "Akavache.Core", "Akavache.Mac", "Akavache.Deprecated", "Akavache.Mobile", "Akavache.Sqlite3", "Akavache.Drawing" };
			Type typeFromHandle = typeof(DependencyResolverMixin);
			if (typeFromHandle == null || typeFromHandle.AssemblyQualifiedName == null)
			{
				throw new Exception("Cannot find valid assembly name for the DependencyResolverMixin class.");
			}
			AssemblyName assemblyName = new AssemblyName(typeFromHandle.AssemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty));
			string[] array = obj;
			foreach (string text in array)
			{
				Type type = Type.GetType(string.Concat(text + ".Registrations", ", ", assemblyName.FullName.Replace(assemblyName.Name, text)), throwOnError: false);
				if ((object)type != null)
				{
					((IWantsToRegisterStuff)Activator.CreateInstance(type)).Register(resolver, readonlyDependencyResolver);
				}
			}
		}
	}
	internal static class ExceptionHelper
	{
		public static IObservable<T> ObservableThrowKeyNotFoundException<T>(string key, Exception? innerException = null)
		{
			return Observable.Throw<T>(new KeyNotFoundException("The given key '" + key + "' was not present in the cache.", innerException));
		}

		public static IObservable<T> ObservableThrowObjectDisposedException<T>(string obj, Exception? innerException = null)
		{
			return Observable.Throw<T>(new ObjectDisposedException("The cache '" + obj + "' was disposed.", innerException));
		}
	}
	public static class HttpMixinExtensions
	{
		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			return Locator.Current.GetService<IAkavacheHttpMixin>().DownloadUrl(blobCache, new Uri(url), headers, fetchAlways, absoluteExpiration);
		}

		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			return Locator.Current.GetService<IAkavacheHttpMixin>().DownloadUrl(blobCache, url, headers, fetchAlways, absoluteExpiration);
		}

		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			return Locator.Current.GetService<IAkavacheHttpMixin>().DownloadUrl(blobCache, key, new Uri(url), headers, fetchAlways, absoluteExpiration);
		}

		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			return Locator.Current.GetService<IAkavacheHttpMixin>().DownloadUrl(blobCache, key, url, headers, fetchAlways, absoluteExpiration);
		}
	}
	public interface IAkavacheHttpMixin
	{
		IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

		IObservable<byte[]> DownloadUrl(IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

		IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

		IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);
	}
	internal interface IWantsToRegisterStuff
	{
		void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver);
	}
	internal class JsonDateTimeContractResolver : DefaultContractResolver
	{
		public IContractResolver? ExistingContractResolver { get; set; }

		public DateTimeKind? ForceDateTimeKindOverride { get; set; }

		public JsonDateTimeContractResolver()
			: this(null, null)
		{
		}

		public JsonDateTimeContractResolver(IContractResolver? contractResolver, DateTimeKind? forceDateTimeKindOverride)
		{
			ExistingContractResolver = contractResolver;
			ForceDateTimeKindOverride = forceDateTimeKindOverride;
		}

		public override JsonContract ResolveContract(Type type)
		{
			JsonContract jsonContract = ExistingContractResolver?.ResolveContract(type);
			if (jsonContract?.Converter != null)
			{
				return jsonContract;
			}
			if (jsonContract == null)
			{
				jsonContract = base.ResolveContract(type);
			}
			if (type == typeof(DateTime) || type == typeof(DateTime?))
			{
				jsonContract.Converter = ((ForceDateTimeKindOverride == DateTimeKind.Local) ? JsonDateTimeTickConverter.LocalDateTimeKindDefault : JsonDateTimeTickConverter.Default);
			}
			else if (type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?))
			{
				jsonContract.Converter = JsonDateTimeOffsetTickConverter.Default;
			}
			return jsonContract;
		}
	}
	internal class JsonDateTimeOffsetTickConverter : JsonConverter
	{
		internal class DateTimeOffsetData
		{
			public long Ticks { get; set; }

			public long OffsetTicks { get; set; }

			public DateTimeOffsetData(DateTimeOffset offset)
			{
				Ticks = offset.Ticks;
				OffsetTicks = offset.Offset.Ticks;
			}

			public static explicit operator DateTimeOffset(DateTimeOffsetData value)
			{
				return new DateTimeOffset(value.Ticks, new TimeSpan(value.OffsetTicks));
			}
		}

		public static JsonDateTimeOffsetTickConverter Default { get; } = new JsonDateTimeOffsetTickConverter();

		public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
		{
			if (value is DateTimeOffset offset)
			{
				serializer.Serialize(writer, new DateTimeOffsetData(offset));
			}
		}

		public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Date && reader.Value != null)
			{
				return (DateTimeOffset)reader.Value;
			}
			DateTimeOffsetData dateTimeOffsetData = serializer.Deserialize<DateTimeOffsetData>(reader);
			if (dateTimeOffsetData == null)
			{
				return null;
			}
			return (DateTimeOffset)dateTimeOffsetData;
		}

		public override bool CanConvert(Type objectType)
		{
			if (!(objectType == typeof(DateTimeOffset)))
			{
				return objectType == typeof(DateTimeOffset?);
			}
			return true;
		}
	}
	internal class JsonDateTimeTickConverter : JsonConverter
	{
		private readonly DateTimeKind? _forceDateTimeKindOverride;

		public static JsonDateTimeTickConverter Default { get; } = new JsonDateTimeTickConverter();

		public static JsonDateTimeTickConverter LocalDateTimeKindDefault { get; } = new JsonDateTimeTickConverter(DateTimeKind.Local);

		public JsonDateTimeTickConverter(DateTimeKind? forceDateTimeKindOverride = null)
		{
			_forceDateTimeKindOverride = forceDateTimeKindOverride;
		}

		public override bool CanConvert(Type objectType)
		{
			if (!(objectType == typeof(DateTime)))
			{
				return objectType == typeof(DateTime?);
			}
			return true;
		}

		public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader.TokenType != JsonToken.Integer && reader.TokenType != JsonToken.Date)
			{
				return null;
			}
			if (reader.TokenType == JsonToken.Date && reader.Value != null)
			{
				return (DateTime)reader.Value;
			}
			if ((objectType == typeof(DateTime) || objectType == typeof(DateTime?)) && reader.Value != null)
			{
				return new DateTime((long)reader.Value, _forceDateTimeKindOverride ?? DateTimeKind.Utc);
			}
			return null;
		}

		public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
		{
			if (value is DateTime dateTime)
			{
				DateTimeKind? forceDateTimeKindOverride = _forceDateTimeKindOverride;
				if (forceDateTimeKindOverride.HasValue && forceDateTimeKindOverride == DateTimeKind.Local)
				{
					serializer.Serialize(writer, dateTime.Ticks);
				}
				else
				{
					serializer.Serialize(writer, dateTime.ToUniversalTime().Ticks);
				}
			}
		}
	}
	public static class JsonSerializationMixin
	{
		private static readonly ConcurrentDictionary<string, object> _inflightFetchRequests = new ConcurrentDictionary<string, object>();

		public static IObservable<Unit> InsertObject<T>(this IBlobCache blobCache, string key, T value, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InsertObject(key, value, absoluteExpiration);
			}
			byte[] data = SerializeObject(value);
			return blobCache.Insert(GetTypePrefixedKey(key, typeof(T)), data, absoluteExpiration);
		}

		public static IObservable<Unit> InsertAllObjects<T>(this IBlobCache blobCache, IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache is IObjectBlobCache blobCache2)
			{
				return blobCache2.InsertObjects(keyValuePairs, absoluteExpiration);
			}
			throw new NotImplementedException();
		}

		public static IObservable<T> GetObject<T>(this IBlobCache blobCache, string key)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetObject<T>(key);
			}
			return blobCache.Get(GetTypePrefixedKey(key, typeof(T))).SelectMany(DeserializeObject<T>);
		}

		public static IObservable<IEnumerable<T>> GetAllObjects<T>(this IBlobCache blobCache)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetAllObjects<T>();
			}
			return blobCache.GetAllKeys().SelectMany((IEnumerable<string> x) => x.Where((string y) => y.StartsWith(GetTypePrefixedKey(string.Empty, typeof(T)), StringComparison.InvariantCulture)).ToObservable()).SelectMany((string x) => blobCache.GetObject<T>(x).Catch(Observable.Empty<T>()))
				.ToList();
		}

		public static IObservable<T> GetOrFetchObject<T>(this IBlobCache blobCache, string key, Func<IObservable<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.GetObject<T>(key).Catch<T, Exception>(delegate
			{
				string prefixedKey = blobCache.GetHashCode().ToString(CultureInfo.InvariantCulture) + key;
				IObservable<T> value = Observable.Defer(fetchFunc).Do<T>(delegate(T x)
				{
					blobCache.InsertObject(key, x, absoluteExpiration);
				}).Finally(delegate
				{
					_inflightFetchRequests.TryRemove(prefixedKey, out object _);
				})
					.Multicast(new AsyncSubject<T>())
					.RefCount();
				return (IObservable<T>)_inflightFetchRequests.GetOrAdd(prefixedKey, value);
			});
		}

		public static IObservable<T> GetOrFetchObject<T>(this IBlobCache blobCache, string key, Func<Task<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.GetOrFetchObject(key, () => fetchFunc().ToObservable(), absoluteExpiration);
		}

		public static IObservable<T> GetOrCreateObject<T>(this IBlobCache blobCache, string key, Func<T> fetchFunc, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.GetOrFetchObject(key, () => Observable.Return(fetchFunc()), absoluteExpiration);
		}

		public static IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(this IBlobCache blobCache, string key)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.GetObjectCreatedAt<T>(key);
			}
			return blobCache.GetCreatedAt(GetTypePrefixedKey(key, typeof(T)));
		}

		public static IObservable<T> GetAndFetchLatest<T>(this IBlobCache blobCache, string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool>? fetchPredicate = null, DateTimeOffset? absoluteExpiration = null, bool shouldInvalidateOnError = false, Func<T, bool>? cacheValidationPredicate = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			IObservable<T> second = (from x in Observable.Defer(() => blobCache.GetObjectCreatedAt<T>(key))
				select fetchPredicate == null || !x.HasValue || fetchPredicate(x.Value) into x
				where x
				select x).SelectMany((bool _) => fetchFunc().Catch((Exception ex) => (shouldInvalidateOnError ? blobCache.InvalidateObject<T>(key) : Observable.Return(Unit.Default)).SelectMany((Unit __) => Observable.Throw<T>(ex))).SelectMany((T x) => (cacheValidationPredicate == null || cacheValidationPredicate(x)) ? (from __ in blobCache.InvalidateObject<T>(key)
				select x) : Observable.Return(default(T))).SelectMany((T x) => (cacheValidationPredicate == null || cacheValidationPredicate(x)) ? (from __ in blobCache.InsertObject(key, x, absoluteExpiration)
				select x) : Observable.Return(default(T))));
			return (from x in blobCache.GetObject<T>(key)
				select new Tuple<T, bool>(x, item2: true)).Catch(Observable.Return(new Tuple<T, bool>(default(T), item2: false))).SelectMany((Tuple<T, bool> x) => (!x.Item2) ? Observable.Empty<T>() : Observable.Return(x.Item1)).Concat(second)
				.Multicast(new ReplaySubject<T>())
				.RefCount();
		}

		public static IObservable<T> GetAndFetchLatest<T>(this IBlobCache blobCache, string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool>? fetchPredicate = null, DateTimeOffset? absoluteExpiration = null, bool shouldInvalidateOnError = false, Func<T, bool>? cacheValidationPredicate = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.GetAndFetchLatest(key, () => fetchFunc().ToObservable(), fetchPredicate, absoluteExpiration, shouldInvalidateOnError, cacheValidationPredicate);
		}

		public static IObservable<Unit> InvalidateObject<T>(this IBlobCache blobCache, string key)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InvalidateObject<T>(key);
			}
			return blobCache.Invalidate(GetTypePrefixedKey(key, typeof(T)));
		}

		public static IObservable<Unit> InvalidateAllObjects<T>(this IBlobCache blobCache)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if (blobCache is IObjectBlobCache objectBlobCache)
			{
				return objectBlobCache.InvalidateAllObjects<T>();
			}
			AsyncSubject<Unit> ret = new AsyncSubject<Unit>();
			blobCache.GetAllKeys().SelectMany((IEnumerable<string> x) => x.Where((string y) => y.StartsWith(GetTypePrefixedKey(string.Empty, typeof(T)), StringComparison.InvariantCulture)).ToObservable()).SelectMany(blobCache.Invalidate)
				.Subscribe(delegate
				{
				}, delegate(Exception ex)
				{
					ret.OnError(ex);
				}, delegate
				{
					ret.OnNext(Unit.Default);
					ret.OnCompleted();
				});
			return ret;
		}

		internal static byte[] SerializeObject(object value)
		{
			return JsonSerializationMixin.SerializeObject<object>(value);
		}

		internal static byte[] SerializeObject<T>(T value)
		{
			JsonSerializerSettings service = Locator.Current.GetService<JsonSerializerSettings>();
			return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, service));
		}

		internal static IObservable<T> DeserializeObject<T>(byte[] x)
		{
			JsonSerializerSettings service = Locator.Current.GetService<JsonSerializerSettings>();
			try
			{
				return Observable.Return(JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(x, 0, x.Length), service));
			}
			catch (Exception exception)
			{
				return Observable.Throw<T>(exception);
			}
		}

		internal static string GetTypePrefixedKey(string key, Type type)
		{
			return type.FullName + "___" + key;
		}
	}
	public interface IKeyedOperationQueue
	{
		IObservable<T> EnqueueObservableOperation<T>(string key, Func<IObservable<T>> asyncCalculationFunc);

		IObservable<T> EnqueueOperation<T>(string key, Func<T> calculationFunc);

		IObservable<Unit> EnqueueOperation(string key, Action action);

		IObservable<Unit> ShutdownQueue();
	}
	internal abstract class KeyedOperation
	{
		public string Key { get; set; }

		public int Id { get; set; }

		public KeyedOperation(string key, int id)
		{
			Key = key;
			Id = id;
		}

		public abstract IObservable<Unit> EvaluateFunc();
	}
	internal class KeyedOperation<T> : KeyedOperation
	{
		public Func<IObservable<T>> Func { get; }

		public ReplaySubject<T> Result { get; } = new ReplaySubject<T>();

		public KeyedOperation(Func<IObservable<T>> func, string key, int id)
			: base(key, id)
		{
			Func = func;
		}

		public override IObservable<Unit> EvaluateFunc()
		{
			IConnectableObservable<T> connectableObservable = Func().Multicast(Result);
			connectableObservable.Connect();
			return connectableObservable.Select((T _) => Unit.Default);
		}
	}
	public class KeyedOperationQueue : IKeyedOperationQueue, IEnableLogger, IDisposable
	{
		private static int _sequenceNumber = 1;

		private readonly IScheduler _scheduler;

		private readonly Subject<KeyedOperation> _queuedOps = new Subject<KeyedOperation>();

		private readonly IConnectableObservable<KeyedOperation> _resultObs;

		private AsyncSubject<Unit>? _shutdownObs;

		public KeyedOperationQueue(IScheduler? scheduler = null)
		{
			if (scheduler == null)
			{
				scheduler = BlobCache.TaskpoolScheduler;
			}
			_scheduler = scheduler;
			_resultObs = (from x in _queuedOps
				group x by x.Key into x
				select x.Select(ProcessOperation).Concat()).Merge().Multicast<KeyedOperation, KeyedOperation>(new Subject<KeyedOperation>());
			_resultObs.Connect();
		}

		public IObservable<Unit> EnqueueOperation(string key, Action action)
		{
			return EnqueueOperation(key, delegate
			{
				action();
				return Unit.Default;
			});
		}

		public IObservable<T> EnqueueOperation<T>(string key, Func<T> calculationFunc)
		{
			return EnqueueObservableOperation(key, () => SafeStart(calculationFunc));
		}

		public IObservable<T> EnqueueObservableOperation<T>(string key, Func<IObservable<T>> asyncCalculationFunc)
		{
			int num = Interlocked.Increment(ref _sequenceNumber);
			if (key == null)
			{
				key = "__NONE__";
			}
			this.Log().Debug(CultureInfo.InvariantCulture, "Queuing operation {0} with key {1}", num, key);
			KeyedOperation<T> keyedOperation = new KeyedOperation<T>(asyncCalculationFunc, key, num);
			_queuedOps.OnNext(keyedOperation);
			return keyedOperation.Result;
		}

		public IObservable<Unit> ShutdownQueue()
		{
			lock (_queuedOps)
			{
				if (_shutdownObs != null)
				{
					return _shutdownObs;
				}
				_queuedOps.OnCompleted();
				_shutdownObs = new AsyncSubject<Unit>();
				(from x in _resultObs.Materialize()
					where x.Kind != NotificationKind.OnNext
					select x).SelectMany((Notification<KeyedOperation> x) => (x.Kind != NotificationKind.OnError) ? Observable.Return(Unit.Default) : Observable.Throw<Unit>(x.Exception)).Multicast(_shutdownObs).Connect();
				return _shutdownObs;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_queuedOps?.Dispose();
				_shutdownObs?.Dispose();
			}
		}

		private static IObservable<KeyedOperation> ProcessOperation(KeyedOperation operation)
		{
			return (from _ in Observable.Defer(operation.EvaluateFunc)
				select operation).Catch(Observable.Return(operation));
		}

		private IObservable<T> SafeStart<T>(Func<T> calculationFunc)
		{
			AsyncSubject<T> ret = new AsyncSubject<T>();
			Observable.Start(delegate
			{
				try
				{
					T value = calculationFunc();
					ret.OnNext(value);
					ret.OnCompleted();
				}
				catch (Exception ex)
				{
					this.Log().Warn(ex, "Failure running queued op");
					ret.OnError(ex);
				}
			}, _scheduler);
			return ret;
		}
	}
	public class LoginInfo
	{
		public string UserName { get; }

		public string Password { get; }

		public LoginInfo(string username, string password)
		{
			UserName = username;
			Password = password;
		}

		internal LoginInfo((string UserName, string Password) usernameAndLogin)
			: this(usernameAndLogin.UserName, usernameAndLogin.Password)
		{
		}
	}
	public static class LoginMixin
	{
		public static IObservable<Unit> SaveLogin(this ISecureBlobCache blobCache, string user, string password, string host = "default", DateTimeOffset? absoluteExpiration = null)
		{
			return blobCache.InsertObject("login:" + host, new Tuple<string, string>(user, password), absoluteExpiration);
		}

		public static IObservable<LoginInfo> GetLoginAsync(this ISecureBlobCache blobCache, string host = "default")
		{
			return from x in blobCache.GetObject<(string, string)>("login:" + host)
				select new LoginInfo(x);
		}

		public static IObservable<Unit> EraseLogin(this ISecureBlobCache blobCache, string host = "default")
		{
			return blobCache.InvalidateObject<(string, string)>("login:" + host);
		}
	}
	internal struct ABCDStruct
	{
		public uint A;

		public uint B;

		public uint C;

		public uint D;
	}
	internal sealed class MD5Core
	{
		private MD5Core()
		{
		}

		public static byte[] GetHash(string input, Encoding encoding)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input", "Unable to calculate hash over null input data");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding", "Unable to calculate hash over a string without a default encoding. Consider using the GetHash(string) overload to use UTF8 Encoding");
			}
			return GetHash(encoding.GetBytes(input));
		}

		public static byte[] GetHash(string input)
		{
			return GetHash(input, new UTF8Encoding());
		}

		public static string GetHashString(byte[] input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input", "Unable to calculate hash over null input data");
			}
			return BitConverter.ToString(GetHash(input)).Replace("-", "");
		}

		public static string GetHashString(string input, Encoding encoding)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input", "Unable to calculate hash over null input data");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding", "Unable to calculate hash over a string without a default encoding. Consider using the GetHashString(string) overload to use UTF8 Encoding");
			}
			return GetHashString(encoding.GetBytes(input));
		}

		public static string GetHashString(string input)
		{
			return GetHashString(input, new UTF8Encoding());
		}

		public static byte[] GetHash(byte[] input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input", "Unable to calculate hash over null input data");
			}
			ABCDStruct ABCDValue = new ABCDStruct
			{
				A = 1732584193u,
				B = 4023233417u,
				C = 2562383102u,
				D = 271733878u
			};
			int i;
			for (i = 0; i <= input.Length - 64; i += 64)
			{
				GetHashBlock(input, ref ABCDValue, i);
			}
			return GetHashFinalBlock(input, i, input.Length - i, ABCDValue, (long)input.Length * 8L);
		}

		internal static byte[] GetHashFinalBlock(byte[] input, int ibStart, int cbSize, ABCDStruct ABCD, long len)
		{
			byte[] array = new byte[64];
			byte[] bytes = BitConverter.GetBytes(len);
			Array.Copy(input, ibStart, array, 0, cbSize);
			array[cbSize] = 128;
			if (cbSize < 56)
			{
				Array.Copy(bytes, 0, array, 56, 8);
				GetHashBlock(array, ref ABCD, 0);
			}
			else
			{
				GetHashBlock(array, ref ABCD, 0);
				array = new byte[64];
				Array.Copy(bytes, 0, array, 56, 8);
				GetHashBlock(array, ref ABCD, 0);
			}
			byte[] array2 = new byte[16];
			Array.Copy(BitConverter.GetBytes(ABCD.A), 0, array2, 0, 4);
			Array.Copy(BitConverter.GetBytes(ABCD.B), 0, array2, 4, 4);
			Array.Copy(BitConverter.GetBytes(ABCD.C), 0, array2, 8, 4);
			Array.Copy(BitConverter.GetBytes(ABCD.D), 0, array2, 12, 4);
			return array2;
		}

		internal static void GetHashBlock(byte[] input, ref ABCDStruct ABCDValue, int ibStart)
		{
			uint[] array = Converter(input, ibStart);
			uint a = ABCDValue.A;
			uint b = ABCDValue.B;
			uint c = ABCDValue.C;
			uint d = ABCDValue.D;
			a = r1(a, b, c, d, array[0], 7, 3614090360u);
			d = r1(d, a, b, c, array[1], 12, 3905402710u);
			c = r1(c, d, a, b, array[2], 17, 606105819u);
			b = r1(b, c, d, a, array[3], 22, 3250441966u);
			a = r1(a, b, c, d, array[4], 7, 4118548399u);
			d = r1(d, a, b, c, array[5], 12, 1200080426u);
			c = r1(c, d, a, b, array[6], 17, 2821735955u);
			b = r1(b, c, d, a, array[7], 22, 4249261313u);
			a = r1(a, b, c, d, array[8], 7, 1770035416u);
			d = r1(d, a, b, c, array[9], 12, 2336552879u);
			c = r1(c, d, a, b, array[10], 17, 4294925233u);
			b = r1(b, c, d, a, array[11], 22, 2304563134u);
			a = r1(a, b, c, d, array[12], 7, 1804603682u);
			d = r1(d, a, b, c, array[13], 12, 4254626195u);
			c = r1(c, d, a, b, array[14], 17, 2792965006u);
			b = r1(b, c, d, a, array[15], 22, 1236535329u);
			a = r2(a, b, c, d, array[1], 5, 4129170786u);
			d = r2(d, a, b, c, array[6], 9, 3225465664u);
			c = r2(c, d, a, b, array[11], 14, 643717713u);
			b = r2(b, c, d, a, array[0], 20, 3921069994u);
			a = r2(a, b, c, d, array[5], 5, 3593408605u);
			d = r2(d, a, b, c, array[10], 9, 38016083u);
			c = r2(c, d, a, b, array[15], 14, 3634488961u);
			b = r2(b, c, d, a, array[4], 20, 3889429448u);
			a = r2(a, b, c, d, array[9], 5, 568446438u);
			d = r2(d, a, b, c, array[14], 9, 3275163606u);
			c = r2(c, d, a, b, array[3], 14, 4107603335u);
			b = r2(b, c, d, a, array[8], 20, 1163531501u);
			a = r2(a, b, c, d, array[13], 5, 2850285829u);
			d = r2(d, a, b, c, array[2], 9, 4243563512u);
			c = r2(c, d, a, b, array[7], 14, 1735328473u);
			b = r2(b, c, d, a, array[12], 20, 2368359562u);
			a = r3(a, b, c, d, array[5], 4, 4294588738u);
			d = r3(d, a, b, c, array[8], 11, 2272392833u);
			c = r3(c, d, a, b, array[11], 16, 1839030562u);
			b = r3(b, c, d, a, array[14], 23, 4259657740u);
			a = r3(a, b, c, d, array[1], 4, 2763975236u);
			d = r3(d, a, b, c, array[4], 11, 1272893353u);
			c = r3(c, d, a, b, array[7], 16, 4139469664u);
			b = r3(b, c, d, a, array[10], 23, 3200236656u);
			a = r3(a, b, c, d, array[13], 4, 681279174u);
			d = r3(d, a, b, c, array[0], 11, 3936430074u);
			c = r3(c, d, a, b, array[3], 16, 3572445317u);
			b = r3(b, c, d, a, array[6], 23, 76029189u);
			a = r3(a, b, c, d, array[9], 4, 3654602809u);
			d = r3(d, a, b, c, array[12], 11, 3873151461u);
			c = r3(c, d, a, b, array[15], 16, 530742520u);
			b = r3(b, c, d, a, array[2], 23, 3299628645u);
			a = r4(a, b, c, d, array[0], 6, 4096336452u);
			d = r4(d, a, b, c, array[7], 10, 1126891415u);
			c = r4(c, d, a, b, array[14], 15, 2878612391u);
			b = r4(b, c, d, a, array[5], 21, 4237533241u);
			a = r4(a, b, c, d, array[12], 6, 1700485571u);
			d = r4(d, a, b, c, array[3], 10, 2399980690u);
			c = r4(c, d, a, b, array[10], 15, 4293915773u);
			b = r4(b, c, d, a, array[1], 21, 2240044497u);
			a = r4(a, b, c, d, array[8], 6, 1873313359u);
			d = r4(d, a, b, c, array[15], 10, 4264355552u);
			c = r4(c, d, a, b, array[6], 15, 2734768916u);
			b = r4(b, c, d, a, array[13], 21, 1309151649u);
			a = r4(a, b, c, d, array[4], 6, 4149444226u);
			d = r4(d, a, b, c, array[11], 10, 3174756917u);
			c = r4(c, d, a, b, array[2], 15, 718787259u);
			b = r4(b, c, d, a, array[9], 21, 3951481745u);
			ABCDValue.A = a + ABCDValue.A;
			ABCDValue.B = b + ABCDValue.B;
			ABCDValue.C = c + ABCDValue.C;
			ABCDValue.D = d + ABCDValue.D;
		}

		private static uint r1(uint a, uint b, uint c, uint d, uint x, int s, uint t)
		{
			return b + LSR(a + ((b & c) | ((b ^ 0xFFFFFFFFu) & d)) + x + t, s);
		}

		private static uint r2(uint a, uint b, uint c, uint d, uint x, int s, uint t)
		{
			return b + LSR(a + ((b & d) | (c & (d ^ 0xFFFFFFFFu))) + x + t, s);
		}

		private static uint r3(uint a, uint b, uint c, uint d, uint x, int s, uint t)
		{
			return b + LSR(a + (b ^ c ^ d) + x + t, s);
		}

		private static uint r4(uint a, uint b, uint c, uint d, uint x, int s, uint t)
		{
			return b + LSR(a + (c ^ (b | (d ^ 0xFFFFFFFFu))) + x + t, s);
		}

		private static uint LSR(uint i, int s)
		{
			return (i << s) | (i >> 32 - s);
		}

		private static uint[] Converter(byte[] input, int ibStart)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input", "Unable convert null array to array of uInts");
			}
			uint[] array = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = input[ibStart + i * 4];
				array[i] += (uint)(input[ibStart + i * 4 + 1] << 8);
				array[i] += (uint)(input[ibStart + i * 4 + 2] << 16);
				array[i] += (uint)(input[ibStart + i * 4 + 3] << 24);
			}
			return array;
		}
	}
	internal static class PortableExtensions
	{
		public static T Retry<T>(this Func<T> block, int retries = 3)
		{
			while (true)
			{
				try
				{
					return block();
				}
				catch (Exception)
				{
					retries--;
					if (retries == 0)
					{
						throw;
					}
				}
			}
		}

		internal static IObservable<T> PermaRef<T>(this IConnectableObservable<T> observable)
		{
			observable.Connect();
			return observable;
		}
	}
	public static class ProtectedData
	{
		public static byte[] Protect(byte[] originalData, byte[]? entropy, DataProtectionScope scope = DataProtectionScope.CurrentUser)
		{
			return originalData;
		}

		public static byte[] Unprotect(byte[] originalData, byte[]? entropy, DataProtectionScope scope = DataProtectionScope.CurrentUser)
		{
			return originalData;
		}
	}
	public interface IEncryptionProvider
	{
		IObservable<byte[]> EncryptBlock(byte[] block);

		IObservable<byte[]> DecryptBlock(byte[] block);
	}
	public interface IFilesystemProvider
	{
		IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler);

		IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler);

		IObservable<Unit> CreateRecursive(string path);

		IObservable<Unit> Delete(string path);

		string? GetDefaultLocalMachineCacheDirectory();

		string? GetDefaultRoamingCacheDirectory();

		string? GetDefaultSecretCacheDirectory();
	}
	public static class RelativeTimeMixin
	{
		public static IObservable<Unit> Insert(this IBlobCache blobCache, string key, byte[] data, TimeSpan expiration)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.Insert(key, data, blobCache.Scheduler.Now + expiration);
		}

		public static IObservable<Unit> InsertObject<T>(this IBlobCache blobCache, string key, T value, TimeSpan expiration)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.InsertObject(key, value, blobCache.Scheduler.Now + expiration);
		}

		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string url, TimeSpan expiration, Dictionary<string, string>? headers = null, bool fetchAlways = false)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.DownloadUrl(url, headers, fetchAlways, blobCache.Scheduler.Now + expiration);
		}

		public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, Uri url, TimeSpan expiration, Dictionary<string, string>? headers = null, bool fetchAlways = false)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.DownloadUrl(url, headers, fetchAlways, blobCache.Scheduler.Now + expiration);
		}

		public static IObservable<Unit> SaveLogin(this ISecureBlobCache blobCache, string user, string password, string host, TimeSpan expiration)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.SaveLogin(user, password, host, blobCache.Scheduler.Now + expiration);
		}
	}
	public class AkavacheHttpMixin : IAkavacheHttpMixin
	{
		public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			return blobCache.DownloadUrl(url, url, headers, fetchAlways, absoluteExpiration);
		}

		public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			if ((object)url == null)
			{
				throw new ArgumentNullException("url");
			}
			return blobCache.DownloadUrl(url.ToString(), url, headers, fetchAlways, absoluteExpiration);
		}

		public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			IObservable<byte[]> observable = MakeWebRequest(new Uri(url), headers).SelectMany((WebResponse x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
				select x);
			IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch<byte[]>(observable));
			IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
			connectableObservable.Connect();
			return connectableObservable;
		}

		public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
		{
			if (blobCache == null)
			{
				throw new ArgumentNullException("blobCache");
			}
			IObservable<byte[]> observable = MakeWebRequest(url, headers).SelectMany((WebResponse x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
				select x);
			IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch<byte[]>(observable));
			IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
			connectableObservable.Connect();
			return connectableObservable;
		}

		private static IObservable<WebResponse> MakeWebRequest(Uri uri, IDictionary<string, string>? headers = null, string? content = null, int retries = 3, TimeSpan? timeout = null)
		{
			IObservable<WebResponse> source = ((!ModeDetector.InUnitTestRunner()) ? Observable.Defer(delegate
			{
				WebRequest hwr = CreateWebRequest(uri, headers);
				if (content == null)
				{
					return Observable.FromAsync(() => Task.Factory.FromAsync(hwr.BeginGetResponse, hwr.EndGetResponse, hwr));
				}
				byte[] buf = Encoding.UTF8.GetBytes(content);
				AsyncSubject<WebResponse> ret = new AsyncSubject<WebResponse>();
				Observable.Start(delegate
				{
					Observable.FromAsync(() => Task.Factory.FromAsync(hwr.BeginGetRequestStream, hwr.EndGetRequestStream, hwr)).SelectMany((Stream x) => x.WriteAsyncRx(buf, 0, buf.Length)).SelectMany((Unit _) => Observable.FromAsync(() => Task.Factory.FromAsync(hwr.BeginGetResponse, hwr.EndGetResponse, hwr)))
						.Multicast<WebResponse, WebResponse>(ret)
						.Connect();
				}, BlobCache.TaskpoolScheduler);
				return ret;
			}) : Observable.Defer(delegate
			{
				WebRequest hwr = CreateWebRequest(uri, headers);
				if (content == null)
				{
					return Observable.Start(() => hwr.GetResponse(), BlobCache.TaskpoolScheduler);
				}
				byte[] buf = Encoding.UTF8.GetBytes(content);
				return Observable.Start(delegate
				{
					hwr.GetRequestStream().Write(buf, 0, buf.Length);
					return hwr.GetResponse();
				}, BlobCache.TaskpoolScheduler);
			}));
			return source.Timeout(timeout ?? TimeSpan.FromSeconds(15.0), BlobCache.TaskpoolScheduler).Retry(retries);
		}

		private static WebRequest CreateWebRequest(Uri uri, IDictionary<string, string>? headers)
		{
			WebRequest webRequest = WebRequest.Create(uri);
			if (headers != null)
			{
				foreach (KeyValuePair<string, string> header in headers)
				{
					webRequest.Headers[header.Key] = header.Value;
				}
			}
			return webRequest;
		}

		private static IObservable<byte[]> ProcessWebResponse(WebResponse wr, string url, DateTimeOffset? absoluteExpiration)
		{
			if (!(wr is HttpWebResponse httpWebResponse))
			{
				DateTimeOffset? dateTimeOffset = absoluteExpiration;
				throw new ArgumentException("The Web Response is somehow null but shouldn't be: " + url + " with expiry: " + dateTimeOffset.ToString(), "wr");
			}
			if (httpWebResponse.StatusCode >= HttpStatusCode.BadRequest)
			{
				return Observable.Throw<byte[]>(new WebException(httpWebResponse.StatusDescription));
			}
			using MemoryStream memoryStream = new MemoryStream();
			using (Stream stream = httpWebResponse.GetResponseStream())
			{
				if (stream == null)
				{
					DateTimeOffset? dateTimeOffset = absoluteExpiration;
					throw new InvalidOperationException("The response stream is somehow null: " + url + " with expiry: " + dateTimeOffset.ToString());
				}
				stream.CopyTo(memoryStream);
			}
			return Observable.Return(memoryStream.ToArray());
		}

		private static IObservable<byte[]> ProcessWebResponse(WebResponse wr, Uri url, DateTimeOffset? absoluteExpiration)
		{
			if (!(wr is HttpWebResponse httpWebResponse))
			{
				string obj = url?.ToString();
				DateTimeOffset? dateTimeOffset = absoluteExpiration;
				throw new ArgumentException("The Web Response is somehow null but shouldn't be: " + obj + " with expiry: " + dateTimeOffset.ToString(), "wr");
			}
			if (httpWebResponse.StatusCode >= HttpStatusCode.BadRequest)
			{
				return Observable.Throw<byte[]>(new WebException(httpWebResponse.StatusDescription));
			}
			using MemoryStream memoryStream = new MemoryStream();
			using (Stream stream = httpWebResponse.GetResponseStream())
			{
				if (stream == null)
				{
					string obj2 = url?.ToString();
					DateTimeOffset? dateTimeOffset = absoluteExpiration;
					throw new InvalidOperationException("The response stream is somehow null: " + obj2 + " with expiry: " + dateTimeOffset.ToString());
				}
				stream.CopyTo(memoryStream);
			}
			return Observable.Return(memoryStream.ToArray());
		}
	}
	public class EncryptionProvider : IEncryptionProvider
	{
		public IObservable<byte[]> EncryptBlock(byte[] block)
		{
			return Observable.Return(ProtectedData.Protect(block, null));
		}

		public IObservable<byte[]> DecryptBlock(byte[] block)
		{
			return Observable.Return(ProtectedData.Unprotect(block, null));
		}
	}
	internal class MD5Managed : MD5
	{
		private byte[] _data;

		private ABCDStruct _abcd;

		private long _totalLength;

		private int _dataSize;

		public MD5Managed()
		{
			HashSizeValue = 128;
			_data = new byte[64];
			_abcd = default(ABCDStruct);
		}

		public override void Initialize()
		{
			_data = new byte[64];
			_dataSize = 0;
			_totalLength = 0L;
			_abcd = default(ABCDStruct);
			_abcd.A = 1732584193u;
			_abcd.B = 4023233417u;
			_abcd.C = 2562383102u;
			_abcd.D = 271733878u;
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			int num = ibStart;
			int num2 = _dataSize + cbSize;
			if (num2 >= 64)
			{
				Array.Copy(array, num, _data, _dataSize, 64 - _dataSize);
				MD5Core.GetHashBlock(_data, ref _abcd, 0);
				num += 64 - _dataSize;
				num2 -= 64;
				while (num2 >= 64)
				{
					Array.Copy(array, num, _data, 0, 64);
					MD5Core.GetHashBlock(array, ref _abcd, num);
					num2 -= 64;
					num += 64;
				}
				_dataSize = num2;
				Array.Copy(array, num, _data, 0, num2);
			}
			else
			{
				Array.Copy(array, num, _data, _dataSize, cbSize);
				_dataSize = num2;
			}
			_totalLength += cbSize;
		}

		protected override byte[] HashFinal()
		{
			HashValue = MD5Core.GetHashFinalBlock(_data, 0, _dataSize, _abcd, _totalLength * 8);
			return HashValue;
		}
	}
	internal static class Utility
	{
		public static string GetMd5Hash(string input)
		{
			using MD5Managed mD5Managed = new MD5Managed();
			byte[] array = mD5Managed.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
			}
			return stringBuilder.ToString();
		}

		public static IObservable<Stream> SafeOpenFileAsync(string path, FileMode mode, FileAccess access, FileShare share, IScheduler? scheduler = null)
		{
			if (scheduler == null)
			{
				scheduler = BlobCache.TaskpoolScheduler;
			}
			AsyncSubject<Stream> ret = new AsyncSubject<Stream>();
			Observable.Start(delegate
			{
				try
				{
					if (!new FileMode[3]
					{
						FileMode.Create,
						FileMode.CreateNew,
						FileMode.OpenOrCreate
					}.Contains(mode) && !File.Exists(path))
					{
						ret.OnError(new FileNotFoundException());
					}
					else
					{
						Observable.Start(() => new FileStream(path, mode, access, share, 4096, useAsync: false), scheduler).Cast<Stream>().Subscribe(ret);
					}
				}
				catch (Exception error)
				{
					ret.OnError(error);
				}
			}, scheduler);
			return ret;
		}

		public static void CreateRecursive(this DirectoryInfo directoryInfo)
		{
			directoryInfo.SplitFullPath().Aggregate(delegate(string parent, string dir)
			{
				string text = Path.Combine(parent, dir);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				return text;
			});
		}

		public static IEnumerable<string> SplitFullPath(this DirectoryInfo directoryInfo)
		{
			string pathRoot = Path.GetPathRoot(directoryInfo.FullName);
			List<string> list = new List<string>();
			string text = directoryInfo.FullName;
			while (text != pathRoot && text != null)
			{
				string fileName = Path.GetFileName(text);
				if (!string.IsNullOrEmpty(fileName))
				{
					list.Add(fileName);
				}
				text = Path.GetDirectoryName(text);
			}
			list.Add(pathRoot);
			list.Reverse();
			return list;
		}

		public static IObservable<T> LogErrors<T>(this IObservable<T> observable, string? message = null)
		{
			return Observable.Create((IObserver<T> subj) => observable.Subscribe(subj.OnNext, delegate(Exception ex)
			{
				string argument = message ?? ("0x" + observable.GetHashCode().ToString("x", CultureInfo.InvariantCulture));
				LogHost.Default.Info(ex, "{0} failed", argument);
				subj.OnError(ex);
			}, subj.OnCompleted));
		}

		public static IObservable<Unit> CopyToAsync(this Stream stream, Stream destination, IScheduler? scheduler = null)
		{
			return Observable.Start(delegate
			{
				try
				{
					stream.CopyTo(destination);
				}
				catch (Exception exception)
				{
					LogHost.Default.Warn(exception, "CopyToAsync failed");
				}
				finally
				{
					stream.Dispose();
					destination.Dispose();
				}
			}, scheduler ?? BlobCache.TaskpoolScheduler);
		}
	}
	public class SimpleFilesystemProvider : IFilesystemProvider
	{
		public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
		{
			return Utility.SafeOpenFileAsync(path, FileMode.Open, FileAccess.Read, FileShare.Read, scheduler);
		}

		public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
		{
			return Utility.SafeOpenFileAsync(path, FileMode.Create, FileAccess.Write, FileShare.None, scheduler);
		}

		public IObservable<Unit> CreateRecursive(string path)
		{
			new DirectoryInfo(path).CreateRecursive();
			return Observable.Return(Unit.Default);
		}

		public IObservable<Unit> Delete(string path)
		{
			return Observable.Start(delegate
			{
				File.Delete(path);
			}, BlobCache.TaskpoolScheduler);
		}

		public string GetDefaultRoamingCacheDirectory()
		{
			if (!ModeDetector.InUnitTestRunner())
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), BlobCache.ApplicationName, "BlobCache");
			}
			return Path.Combine(GetAssemblyDirectoryName(), "BlobCache");
		}

		public string GetDefaultSecretCacheDirectory()
		{
			if (!ModeDetector.InUnitTestRunner())
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), BlobCache.ApplicationName, "SecretCache");
			}
			return Path.Combine(GetAssemblyDirectoryName(), "SecretCache");
		}

		public string GetDefaultLocalMachineCacheDirectory()
		{
			if (!ModeDetector.InUnitTestRunner())
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), BlobCache.ApplicationName, "BlobCache");
			}
			return Path.Combine(GetAssemblyDirectoryName(), "LocalBlobCache");
		}

		protected static string GetAssemblyDirectoryName()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException("The directory name of the assembly location is null");
		}
	}
	public class AndroidFilesystemProvider : IFilesystemProvider
	{
		private readonly SimpleFilesystemProvider _inner = new SimpleFilesystemProvider();

		public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
		{
			return _inner.OpenFileForReadAsync(path, scheduler);
		}

		public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
		{
			return _inner.OpenFileForWriteAsync(path, scheduler);
		}

		public IObservable<Unit> CreateRecursive(string path)
		{
			return _inner.CreateRecursive(path);
		}

		public IObservable<Unit> Delete(string path)
		{
			return _inner.Delete(path);
		}

		public string? GetDefaultLocalMachineCacheDirectory()
		{
			return Application.Context.CacheDir?.AbsolutePath;
		}

		public string? GetDefaultRoamingCacheDirectory()
		{
			return Application.Context.FilesDir?.AbsolutePath;
		}

		public string? GetDefaultSecretCacheDirectory()
		{
			string text = Application.Context.FilesDir?.AbsolutePath;
			if (text == null)
			{
				return null;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(text, "Secret"));
			if (!directoryInfo.Exists)
			{
				directoryInfo.CreateRecursive();
			}
			return directoryInfo.FullName;
		}
	}
	public class IsolatedStorageProvider : IFilesystemProvider
	{
		public IObservable<Stream> OpenFileForReadAsync(string path, IScheduler scheduler)
		{
			return Observable.Create(delegate(IObserver<Stream> subj)
			{
				CompositeDisposable compositeDisposable = new CompositeDisposable();
				try
				{
					IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
					compositeDisposable.Add(fs);
					compositeDisposable.Add(Observable.Start(() => fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read), BlobCache.TaskpoolScheduler).Subscribe(subj));
				}
				catch (Exception error)
				{
					subj.OnError(error);
				}
				return compositeDisposable;
			});
		}

		public IObservable<Stream> OpenFileForWriteAsync(string path, IScheduler scheduler)
		{
			return Observable.Create(delegate(IObserver<Stream> subj)
			{
				CompositeDisposable compositeDisposable = new CompositeDisposable();
				try
				{
					IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
					compositeDisposable.Add(fs);
					compositeDisposable.Add(Observable.Start(() => fs.OpenFile(path, FileMode.Create, FileAccess.Write, FileShare.None), BlobCache.TaskpoolScheduler).Subscribe(subj));
				}
				catch (Exception error)
				{
					subj.OnError(error);
				}
				return compositeDisposable;
			});
		}

		public IObservable<Unit> CreateRecursive(string dirPath)
		{
			return Observable.Start(delegate
			{
				using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
				string path = string.Empty;
				string[] array = dirPath.Split(Path.DirectorySeparatorChar);
				foreach (string path2 in array)
				{
					string text = Path.Combine(path, path2);
					if (text[text.Length - 1] == Path.VolumeSeparatorChar)
					{
						text += Path.DirectorySeparatorChar;
					}
					if (!isolatedStorageFile.DirectoryExists(text))
					{
						isolatedStorageFile.CreateDirectory(text);
					}
					path = text;
				}
			}, BlobCache.TaskpoolScheduler);
		}

		public IObservable<Unit> Delete(string path)
		{
			return Observable.Start(delegate
			{
				using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
				if (!isolatedStorageFile.FileExists(path))
				{
					return;
				}
				try
				{
					isolatedStorageFile.DeleteFile(path);
				}
				catch (FileNotFoundException)
				{
				}
				catch (IsolatedStorageException)
				{
				}
			}, BlobCache.TaskpoolScheduler);
		}

		public string GetDefaultRoamingCacheDirectory()
		{
			return "BlobCache";
		}

		public string GetDefaultSecretCacheDirectory()
		{
			return "SecretCache";
		}

		public string GetDefaultLocalMachineCacheDirectory()
		{
			return "LocalBlobCache";
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			static Attribute()
			{
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
namespace Akavache.Internal
{
	[Flags]
	public enum FileAccess
	{
		Read = 1,
		Write = 2,
		ReadWrite = 3
	}
	public enum FileMode
	{
		CreateNew = 1,
		Create,
		Open,
		OpenOrCreate,
		Truncate,
		Append
	}
	[Flags]
	public enum FileShare
	{
		None = 0,
		Read = 1,
		Write = 2,
		ReadWrite = 3,
		Delete = 4,
		Inheritable = 0x10
	}
}
namespace Akavache.Core
{
	[AttributeUsage(AttributeTargets.All)]
	internal class PreserveAttribute : Attribute
	{
		public bool AllMembers { get; set; }

		public bool Conditional { get; }

		public PreserveAttribute(bool allMembers, bool conditional)
		{
			AllMembers = allMembers;
			Conditional = conditional;
		}

		public PreserveAttribute()
		{
		}
	}
	[Preserve(AllMembers = true)]
	public class Registrations : IWantsToRegisterStuff
	{
		public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			IsolatedStorageProvider fs = new IsolatedStorageProvider();
			resolver.Register(() => fs, typeof(IFilesystemProvider));
			EncryptionProvider enc = new EncryptionProvider();
			resolver.Register(() => enc, typeof(IEncryptionProvider));
			Lazy<IBlobCache> localCache = new Lazy<IBlobCache>(() => new InMemoryBlobCache());
			Lazy<IBlobCache> userAccount = new Lazy<IBlobCache>(() => new InMemoryBlobCache());
			Lazy<ISecureBlobCache> secure = new Lazy<ISecureBlobCache>(() => new InMemoryBlobCache());
			resolver.Register(() => localCache.Value, typeof(IBlobCache), "LocalMachine");
			resolver.Register(() => userAccount.Value, typeof(IBlobCache), "UserAccount");
			resolver.Register(() => secure.Value, typeof(ISecureBlobCache));
			resolver.Register(() => new AkavacheHttpMixin(), typeof(IAkavacheHttpMixin));
			PackageManager packageManager = Application.Context.PackageManager;
			BlobCache.ApplicationName = packageManager?.GetApplicationInfo(Application.Context.PackageName, (PackageInfoFlags)0)?.LoadLabel(packageManager) ?? "Unknown";
			resolver.Register(() => new AndroidFilesystemProvider(), typeof(IFilesystemProvider));
		}
	}
}
