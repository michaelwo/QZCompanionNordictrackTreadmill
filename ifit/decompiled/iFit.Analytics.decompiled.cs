using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using Akavache.Sqlite3;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Segment;
using Segment.Model;
using Segment.Request;
using iFit.Api.Support;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit.Analytics adapted from https://github.com/segmentio/Analytics.Xamarin")]
[assembly: AssemblyFileVersion("3.2.3")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Analytics")]
[assembly: AssemblyTitle("iFit.Analytics")]
[assembly: AssemblyVersion("3.2.3.0")]
namespace Segment
{
	public class Analytics
	{
		public static string VERSION = "3.2.1";

		public static IClient Client { get; private set; }

		public static void Initialize(string writeKey, string osName, string deviceId)
		{
			if (Client == null)
			{
				Client = new Client(writeKey, osName, deviceId);
			}
		}

		public static void Initialize(string writeKey, string osName, string deviceId, Config config)
		{
			if (Client == null)
			{
				Client = new Client(writeKey, osName, deviceId, config);
			}
		}
	}
	public class Client : IClient
	{
		protected IRequestHandler _requestHandler;

		private string _writeKey;

		private string _osName;

		private string _deviceId;

		private Config _config;

		public string WriteKey => _writeKey;

		public Config Config => _config;

		public LogDelegate Logger { get; set; }

		public Client()
		{
		}

		public Client(string writeKey, string osName, string deviceId)
			: this(writeKey, osName, deviceId, new Config())
		{
		}

		public Client(string writeKey, string osName, string deviceId, Config config)
		{
			Initialize(writeKey, osName, deviceId, config);
		}

		public virtual void Initialize(string writeKey, string osName, string deviceId, Config config = null)
		{
			_osName = osName;
			_deviceId = deviceId;
			_config = config ?? new Config();
			SetWriteKey(writeKey);
		}

		public void SetWriteKey(string writeKey)
		{
			if (string.IsNullOrEmpty(writeKey))
			{
				throw new InvalidOperationException("Please supply a valid writeKey to iFit.Analytics.");
			}
			_writeKey = writeKey;
			_requestHandler = new RequestHandler(_writeKey, Config.Host, Config.Timeout);
		}

		public virtual Task Identify(string userId, IDictionary<string, object> traits = null, Options options = null, string advertisingId = null)
		{
			EnsureId(userId, options, anonymousAccepted: false);
			SetupDeviceInfo(ref options, advertisingId);
			return Enqueue(new Identify(userId, traits, options));
		}

		public virtual Task Group(string userId, string groupId, IDictionary<string, object> traits = null, Options options = null)
		{
			EnsureId(userId, options);
			if (string.IsNullOrEmpty(groupId))
			{
				throw new InvalidOperationException("Please supply a valid groupId to call #Group.");
			}
			return Enqueue(new Group(userId, groupId, traits, options));
		}

		public virtual Task Track(string userId, string eventName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null)
		{
			EnsureId(userId, options);
			SetupDeviceInfo(ref options, advertisingId);
			if (string.IsNullOrEmpty(eventName))
			{
				throw new InvalidOperationException("Please supply a valid event to Track.");
			}
			return Enqueue(new Track(userId, eventName, properties, options));
		}

		public virtual Task Alias(string previousId, string userId, Options options = null)
		{
			if (string.IsNullOrEmpty(previousId))
			{
				throw new InvalidOperationException("Please supply a valid previousId to Alias.");
			}
			EnsureId(userId, options);
			return Enqueue(new Alias(previousId, userId, options));
		}

		public virtual Task Page(string userId, string name, string category = "", IDictionary<string, object> properties = null, Options options = null)
		{
			EnsureId(userId, options);
			if (string.IsNullOrEmpty(name))
			{
				throw new InvalidOperationException("Please supply a valid name to #Page.");
			}
			return Enqueue(new Page(userId, name, category, properties, options));
		}

		public virtual Task Screen(string userId, string name, string category = "", IDictionary<string, object> properties = null, Options options = null, string advertisingId = null)
		{
			EnsureId(userId, options);
			SetupDeviceInfo(ref options, advertisingId);
			if (string.IsNullOrEmpty(name))
			{
				throw new InvalidOperationException("Please supply a valid name to #Screen.");
			}
			return Enqueue(new Screen(userId, name, category, properties, options));
		}

		protected void EnsureId(string userId, Options options, bool anonymousAccepted = true)
		{
			if (string.IsNullOrWhiteSpace(userId))
			{
				if (!anonymousAccepted)
				{
					throw new InvalidOperationException("Please supply a valid userId");
				}
				if (string.IsNullOrWhiteSpace(options?.AnonymousId))
				{
					throw new InvalidOperationException("Please supply a valid userId or Options.AnonymousId");
				}
			}
		}

		private Task Enqueue(BaseAction action)
		{
			return _requestHandler.Process(action, Logger);
		}

		private void SetupDeviceInfo(ref Options options, string advertisingId = null)
		{
			if (options == null)
			{
				options = new Options();
			}
			options.Context.OperatingSystemName = _osName;
			options.Context.Device.Id = _deviceId;
			if (!string.IsNullOrEmpty(advertisingId))
			{
				options.Context.Device.AdvertisingId = advertisingId;
			}
		}
	}
	public class Config
	{
		public string Host { get; private set; }

		public TimeSpan Timeout { get; private set; }

		public Config()
			: this(Defaults.Host, Defaults.Timeout)
		{
		}

		public Config(TimeSpan timeout)
			: this(Defaults.Host, timeout)
		{
		}

		public Config(string host)
			: this(host, Defaults.Timeout)
		{
		}

		public Config(string host, TimeSpan timeout)
		{
			Host = host;
			Timeout = timeout;
		}

		public Config SetTimeout(TimeSpan timeout)
		{
			Timeout = timeout;
			return this;
		}
	}
	public class Defaults
	{
		public static string Host = "https://api.segment.io";

		public static TimeSpan Timeout = TimeSpan.FromSeconds(7.0);
	}
	public interface IClient
	{
		string WriteKey { get; }

		Config Config { get; }

		LogDelegate Logger { get; }

		void Initialize(string writeKey, string osName, string deviceId, Config config = null);

		void SetWriteKey(string writeKey);

		Task Identify(string userId, IDictionary<string, object> traits = null, Options options = null, string advertisingId = null);

		Task Group(string userId, string groupId, IDictionary<string, object> traits = null, Options options = null);

		Task Track(string userId, string eventName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null);

		Task Alias(string previousId, string userId, Options options = null);

		Task Page(string userId, string name, string category = "", IDictionary<string, object> properties = null, Options options = null);

		Task Screen(string userId, string name, string category = "", IDictionary<string, object> properties = null, Options options = null, string advertisingId = null);
	}
	public delegate void LogDelegate(string message);
}
namespace Segment.Request
{
	public interface IRequestHandler : IDisposable
	{
		Task Process(BaseAction action, LogDelegate logger);
	}
	internal class RequestHandler : IRequestHandler, IDisposable
	{
		private Uri _host;

		private HttpClient _client;

		private string WriteKey { get; set; }

		internal RequestHandler(string writeKey, string host, TimeSpan timeout)
		{
			WriteKey = writeKey;
			_host = new Uri(host);
			_client = new HttpClient();
			_client.Timeout = timeout;
			_client.DefaultRequestHeaders.ExpectContinue = false;
		}

		public async Task Process(BaseAction action, LogDelegate logger)
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				throw new ConnectivityException("Request cannot be processed because there is no data connection.");
			}
			try
			{
				await Send(action);
			}
			catch (Exception ex)
			{
				logger?.Invoke("Analytics call failed: " + ex.Message);
			}
		}

		private async Task Send(BaseAction action)
		{
			Batch batch = new Batch(WriteKey, new List<BaseAction> { action });
			batch.SentAt = DateTime.Now.ToString("o");
			string content = JsonConvert.SerializeObject(batch);
			Uri requestUri = new Uri(_host, "/v1/import");
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
			httpRequestMessage.Headers.Add("Authorization", BasicAuthHeader(batch.WriteKey, ""));
			httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
			_ = DateTime.Now;
			HttpResponseMessage httpResponseMessage = await _client.SendAsync(httpRequestMessage);
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				throw new WebException($"Segment API request returned an unexpected status code: {httpResponseMessage.StatusCode} {httpResponseMessage.Content}");
			}
		}

		private string BasicAuthHeader(string user, string pass)
		{
			return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + pass));
		}

		public void Dispose()
		{
			_client.Dispose();
		}
	}
}
namespace Segment.Model
{
	public class Alias : BaseAction
	{
		[JsonProperty(PropertyName = "previousId")]
		private string PreviousId { get; set; }

		[JsonProperty(PropertyName = "userId")]
		private string UserId { get; set; }

		internal Alias(string previousId, string userId, Options options)
			: base("alias", options)
		{
			PreviousId = previousId;
			UserId = userId;
		}
	}
	public abstract class BaseAction
	{
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "messageId")]
		public string MessageId { get; private set; }

		[JsonProperty(PropertyName = "timestamp")]
		public string Timestamp { get; private set; }

		[JsonProperty(PropertyName = "context")]
		public Context Context { get; set; }

		[JsonProperty(PropertyName = "integrations")]
		public Dict Integrations { get; set; }

		[JsonProperty(PropertyName = "anonymousId")]
		public string AnonymousId { get; private set; }

		internal BaseAction(string type, Options options)
		{
			options = options ?? new Options();
			Type = type;
			MessageId = Guid.NewGuid().ToString();
			if (options.Timestamp.HasValue)
			{
				Timestamp = options.Timestamp.Value.ToString("o");
			}
			else
			{
				Timestamp = DateTime.Now.ToString("o");
			}
			Context = options.Context;
			Integrations = options.Integrations;
			AnonymousId = options.AnonymousId;
		}
	}
	internal class Batch
	{
		internal string WriteKey { get; set; }

		[JsonProperty(PropertyName = "messageId")]
		internal string MessageId { get; private set; }

		[JsonProperty(PropertyName = "sentAt")]
		internal string SentAt { get; set; }

		[JsonProperty(PropertyName = "batch")]
		internal List<BaseAction> batch { get; set; }

		internal Batch()
		{
			MessageId = Guid.NewGuid().ToString();
		}

		internal Batch(string writeKey, List<BaseAction> batch)
			: this()
		{
			WriteKey = writeKey;
			this.batch = batch;
		}
	}
	[Serializable]
	public class Context : Dict
	{
		private const string DEVICE_KEY = "device";

		private const string OS_KEY = "os";

		private const string NAME_KEY = "name";

		public Device Device
		{
			get
			{
				if (!ContainsKey("device"))
				{
					Add("device", new Device());
				}
				return (Device)base["device"];
			}
		}

		public string OperatingSystemName
		{
			get
			{
				if (TryGetValue("os", out var value) && ((Dict)value).TryGetValue("name", out var value2))
				{
					return (string)value2;
				}
				return null;
			}
			set
			{
				if (!ContainsKey("os"))
				{
					Add("os", new Dict { { "name", value } });
				}
			}
		}

		public Context()
		{
			Add("library", new Dict
			{
				{ "name", "Analytics.Xamarin" },
				{
					"version",
					Analytics.VERSION
				}
			});
		}

		protected Context(SerializationInfo info, StreamingContext context)
		{
		}

		public new Context Add(string key, object val)
		{
			base.Add(key, val);
			return this;
		}
	}
	[Serializable]
	public class Device : Dict
	{
		private const string ID_KEY = "id";

		private const string ADVERTISING_KEY = "advertisingId";

		private const string AD_TRACKING_KEY = "adTrackingEnabled";

		public string Id
		{
			get
			{
				if (TryGetValue("id", out var value))
				{
					return (string)value;
				}
				return null;
			}
			set
			{
				if (ContainsKey("id"))
				{
					base["id"] = value;
				}
				else
				{
					Add("id", value);
				}
			}
		}

		public string AdvertisingId
		{
			get
			{
				if (TryGetValue("advertisingId", out var value))
				{
					return (string)value;
				}
				return null;
			}
			set
			{
				if (ContainsKey("advertisingId"))
				{
					base["advertisingId"] = value;
					return;
				}
				base["adTrackingEnabled"] = true;
				Add("advertisingId", value);
			}
		}

		public Device()
		{
			Add("adTrackingEnabled", false);
		}

		protected Device(SerializationInfo info, StreamingContext context)
		{
		}
	}
	public class Dict : Dictionary<string, object>
	{
		public new Dict Add(string key, object val)
		{
			base.Add(key, val);
			return this;
		}
	}
	public class Group : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "groupId")]
		private string GroupId { get; set; }

		[JsonProperty(PropertyName = "traits")]
		private IDictionary<string, object> Traits { get; set; }

		internal Group(string userId, string groupId, IDictionary<string, object> traits, Options options)
			: base("group", options)
		{
			UserId = userId;
			GroupId = groupId;
			Traits = traits ?? new Traits();
		}
	}
	public class Identify : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "traits")]
		public IDictionary<string, object> Traits { get; set; }

		internal Identify(string userId, IDictionary<string, object> traits, Options options)
			: base("identify", options)
		{
			UserId = userId;
			Traits = traits ?? new Traits();
		}
	}
	public class Options
	{
		public string AnonymousId { get; set; }

		public Dict Integrations { get; private set; }

		public DateTime? Timestamp { get; private set; }

		public Context Context { get; private set; }

		public Options()
		{
			Integrations = new Dict();
			Context = new Context();
		}

		public Options SetAnonymousId(string anonymousId)
		{
			AnonymousId = anonymousId;
			return this;
		}

		public Options SetTimestamp(DateTime? timestamp)
		{
			Timestamp = timestamp;
			return this;
		}

		public Options SetContext(Context context)
		{
			Context = context;
			return this;
		}

		public Options SetIntegration(string integration, bool enabled)
		{
			Integrations.Add(integration, enabled);
			return this;
		}
	}
	public class Page : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "name")]
		private string Name { get; set; }

		[JsonProperty(PropertyName = "category")]
		private string Category { get; set; }

		[JsonProperty(PropertyName = "properties")]
		private IDictionary<string, object> Properties { get; set; }

		internal Page(string userId, string name, string category, IDictionary<string, object> properties, Options options)
			: base("page", options)
		{
			UserId = userId;
			Name = name;
			Category = category;
			Properties = properties ?? new Properties();
		}
	}
	public class Properties : Dict
	{
	}
	public class Providers : Dict
	{
		public Providers SetDefault(bool enabled)
		{
			Add("all", enabled);
			return this;
		}

		public Providers SetEnabled(string providerName, bool enabled)
		{
			Add(providerName, enabled);
			return this;
		}
	}
	public class Screen : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "name")]
		private string Name { get; set; }

		[JsonProperty(PropertyName = "category")]
		private string Category { get; set; }

		[JsonProperty(PropertyName = "properties")]
		private IDictionary<string, object> Properties { get; set; }

		public Screen(string userId, string name, string category, IDictionary<string, object> properties, Options options)
			: base("screen", options)
		{
			UserId = userId;
			Name = name;
			Category = category;
			Properties = properties ?? new Properties();
		}
	}
	public class Track : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "event")]
		private string EventName { get; set; }

		[JsonProperty(PropertyName = "properties")]
		private IDictionary<string, object> Properties { get; set; }

		internal Track(string userId, string eventName, IDictionary<string, object> properties, Options options)
			: base("track", options)
		{
			UserId = userId;
			EventName = eventName;
			Properties = properties ?? new Properties();
		}
	}
	public class Traits : Dict
	{
	}
}
namespace iFit.Analytics
{
	[Preserve]
	public static class LinkerPreserve
	{
		static LinkerPreserve()
		{
			throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}
	public class PreserveAttribute : Attribute
	{
	}
	public interface IAnalytics
	{
		string AnonymousUserId { get; }

		bool ShouldIdentifyAnonymousUser { get; set; }

		AnonymousTrackingState TrackAnonymousUserAnalytics { get; set; }

		Task Initialize(string apiKey, string currentlyLoggedInUserId, string osName, string deviceId, Config config = null);

		void SetWriteKey(string apiKey);

		Task<bool> Identify(string userId, IDictionary<string, object> traits = null, Options options = null, string advertisingId = null);

		Task<bool> Screen(string screenName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null);

		Task<bool> Track(string eventName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null);
	}
	public enum AnonymousTrackingState
	{
		Enabled,
		Disabled,
		CachingOnly
	}
	public class SegmentAnalytics : IAnalytics
	{
		public class Event
		{
			public enum SegmentEventType
			{
				Alias,
				Identify,
				Screen,
				Track,
				Identity
			}

			private const string TimeStampFormat = "o";

			public string EventName { get; set; }

			public SegmentEventType EventType { get; set; }

			public string PreviousId { get; set; }

			public string UserId { get; set; }

			public IDictionary<string, object> Properties { get; set; }

			public Options Options { get; set; }

			public string Key { get; set; } = DateTime.UtcNow.ToString("o");

			public DateTime TimeStamp => DateTime.ParseExact(Key, "o", CultureInfo.InvariantCulture);
		}

		public class AnonymousUserInfo
		{
			public string AnonymousUserId { get; set; }

			public bool HasBeenIdentified { get; set; }

			public static async Task<AnonymousUserInfo> GetOrCreate(IBlobCache cache)
			{
				return new AnonymousUserInfo(await cache.GetOrFetchObject("AnonymousUserId", () => Observable.Return(Guid.NewGuid().ToString())), await cache.GetOrFetchObject("HasBeenIdentified", () => Observable.Return(value: false)));
			}

			public static IObservable<Unit> SetHasBeenIdentified(bool val, IBlobCache cache)
			{
				return cache.InsertObject("HasBeenIdentified", val);
			}

			private AnonymousUserInfo(string anonymousUserId, bool hasBeenIdentified)
			{
				AnonymousUserId = anonymousUserId;
				HasBeenIdentified = hasBeenIdentified;
			}
		}

		private bool shouldIdentifyAnonymousUser;

		private AnonymousTrackingState trackAnonymousUserAnalytics;

		protected LogDelegate Logger;

		protected readonly IClient segmentClient;

		protected IConnectivity Connectivity;

		private readonly IBlobCache cache;

		public string AnonymousUserId { get; private set; }

		public bool ShouldIdentifyAnonymousUser
		{
			get
			{
				bool flag = TrackAnonymousUserAnalytics == AnonymousTrackingState.Enabled || TrackAnonymousUserAnalytics == AnonymousTrackingState.CachingOnly;
				return shouldIdentifyAnonymousUser && flag;
			}
			set
			{
				bool flag = TrackAnonymousUserAnalytics == AnonymousTrackingState.Enabled || TrackAnonymousUserAnalytics == AnonymousTrackingState.CachingOnly;
				shouldIdentifyAnonymousUser = value && flag;
			}
		}

		public AnonymousTrackingState TrackAnonymousUserAnalytics
		{
			get
			{
				return trackAnonymousUserAnalytics;
			}
			set
			{
				trackAnonymousUserAnalytics = value;
				switch (trackAnonymousUserAnalytics)
				{
				case AnonymousTrackingState.Enabled:
					TrySendCachedEvents(null, null);
					break;
				case AnonymousTrackingState.Disabled:
					Task.Run(async delegate
					{
						await DeleteCachedAnonymousEvents();
					});
					break;
				case AnonymousTrackingState.CachingOnly:
					break;
				}
			}
		}

		protected string UserId { get; private set; }

		public SegmentAnalytics(LogDelegate logger, IConnectivity connectivity)
			: this(new Client
			{
				Logger = logger
			}, connectivity)
		{
		}

		public SegmentAnalytics(LogDelegate logger, IBlobCache cache, IConnectivity connectivity)
			: this(new Client
			{
				Logger = logger
			}, cache, connectivity)
		{
		}

		public SegmentAnalytics(IClient segmentClient, IConnectivity connectivity)
			: this(segmentClient, BlobCache.UserAccount, connectivity)
		{
		}

		public SegmentAnalytics(IClient segmentClient, IBlobCache cache, IConnectivity connectivity)
		{
			this.segmentClient = segmentClient;
			this.cache = cache;
			Connectivity = connectivity;
		}

		public virtual async Task Initialize(string apiKey, string currentlyLoggedInUserId, string osName, string deviceId, Config config = null)
		{
			UserId = currentlyLoggedInUserId;
			segmentClient.Initialize(apiKey, osName, deviceId, config);
			AnonymousUserId = (await GetOrCreateAnonymousUserInfo()).AnonymousUserId;
			Connectivity.ConnectivityChanged -= TrySendCachedEvents;
			Connectivity.ConnectivityChanged += TrySendCachedEvents;
			TrySendCachedEvents(null, null);
		}

		public void SetWriteKey(string apiKey)
		{
			segmentClient.SetWriteKey(apiKey);
		}

		private void TrySendCachedEvents(object sender, ConnectivityChangedEventArgs e)
		{
			if (Connectivity.IsConnected)
			{
				Task.Run(async delegate
				{
					await SendCachedEvents();
				});
			}
		}

		protected virtual async Task SendCachedEvents()
		{
			_ = 5;
			try
			{
				IEnumerable<Event> allCachedEvents = await cache.GetAllObjects<Event>();
				await cache.InvalidateAllObjects<Event>();
				foreach (Event item in allCachedEvents)
				{
					item.Options = item.Options ?? new Options();
					item.Options.SetTimestamp(item.TimeStamp);
					switch (item.EventType)
					{
					case Event.SegmentEventType.Alias:
						await Alias(item.PreviousId, item.UserId, item.Options).ConfigureAwait(continueOnCapturedContext: false);
						break;
					case Event.SegmentEventType.Identify:
					case Event.SegmentEventType.Identity:
						await Identify(item.UserId, item.Properties, item.Options).ConfigureAwait(continueOnCapturedContext: false);
						break;
					case Event.SegmentEventType.Screen:
						await Screen(item.EventName, item.Properties, item.Options).ConfigureAwait(continueOnCapturedContext: false);
						break;
					case Event.SegmentEventType.Track:
						await Track(item.EventName, item.Properties, item.Options).ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ReportException($"Analytics caught an Exception. Exception: {ex.GetType()} Message: {ex.Message}. One or a few analytics events will be lost.", ex);
			}
		}

		protected virtual async Task DeleteCachedAnonymousEvents()
		{
			foreach (Event item in await cache.GetAllObjects<Event>())
			{
				if (!string.IsNullOrWhiteSpace(item?.Options?.AnonymousId))
				{
					await cache.InvalidateObject<Event>(item.Key);
				}
			}
		}

		protected virtual void ReportException(string message, Exception ex)
		{
			segmentClient?.Logger?.Invoke(message);
		}

		public virtual async Task<bool> Identify(string userId, IDictionary<string, object> traits = null, Options options = null, string advertisingId = null)
		{
			bool num = string.IsNullOrWhiteSpace(UserId) && !string.IsNullOrWhiteSpace(userId);
			bool flag = ShouldIdentifyAnonymousUser && string.IsNullOrWhiteSpace(options?.AnonymousId);
			if (num && flag)
			{
				AnonymousUserInfo anonymousUserInfo = await GetOrCreateAnonymousUserInfo();
				if (!anonymousUserInfo.HasBeenIdentified)
				{
					options = SetAnonymousIdOption(options, anonymousUserInfo.AnonymousUserId);
				}
			}
			UserId = userId;
			try
			{
				if (!string.IsNullOrWhiteSpace(userId) && !string.IsNullOrWhiteSpace(options?.AnonymousId))
				{
					ShouldIdentifyAnonymousUser = false;
					await AnonymousUserInfo.SetHasBeenIdentified(val: true, cache);
				}
				CheckShouldForceCacheAnonymousEvents(options);
				await segmentClient.Identify(userId, traits, options, advertisingId);
				return true;
			}
			catch (InvalidOperationException ex)
			{
				ReportException("Invalid call to Identify(). userId: " + (userId ?? "null") + ", AnonymousUserId: " + (options?.AnonymousId ?? "null"), ex);
			}
			catch (ConnectivityException)
			{
				await CacheEventToLogLater("", Event.SegmentEventType.Identify, userId, userId, traits, options);
			}
			return false;
		}

		protected virtual async Task<bool> Alias(string previousId, string userId, Options options = null)
		{
			try
			{
				options = await SetAnonymousIdOptionIfNeeded(options);
				CheckShouldForceCacheAnonymousEvents(options);
				await segmentClient.Alias(previousId, userId, options);
				return true;
			}
			catch (InvalidOperationException ex)
			{
				ReportException("Invalid call to Alias(). previousId: " + (previousId ?? "null") + ", userId: " + (userId ?? "null"), ex);
			}
			catch (ConnectivityException)
			{
				await CacheEventToLogLater("", Event.SegmentEventType.Alias, previousId, userId, null, options);
			}
			return false;
		}

		public virtual async Task<bool> Screen(string screenName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null)
		{
			try
			{
				string className = screenName.Split('.').LastOrDefault();
				options = await SetAnonymousIdOptionIfNeeded(options);
				CheckShouldForceCacheAnonymousEvents(options);
				await segmentClient.Screen(UserId, className, "", properties, options, advertisingId);
				return true;
			}
			catch (InvalidOperationException ex)
			{
				ReportException("Invalid call to Screen(). AnonymousId: " + (options?.AnonymousId ?? "null") + ", UserId: " + (UserId ?? "null") + ", screenName: " + (screenName ?? "null"), ex);
			}
			catch (ConnectivityException)
			{
				await CacheEventToLogLater(screenName, Event.SegmentEventType.Screen, UserId, UserId, properties, options);
			}
			return false;
		}

		public virtual async Task<bool> Track(string eventName, IDictionary<string, object> properties = null, Options options = null, string advertisingId = null)
		{
			try
			{
				options = await SetAnonymousIdOptionIfNeeded(options);
				CheckShouldForceCacheAnonymousEvents(options);
				await segmentClient.Track(UserId, eventName, properties, options, advertisingId);
				return true;
			}
			catch (InvalidOperationException ex)
			{
				ReportException("Invalid call to Track(). AnonymousId: " + (options?.AnonymousId ?? "null") + ", UserId: " + (UserId ?? "null") + ", eventName: " + (eventName ?? "null"), ex);
			}
			catch (ConnectivityException)
			{
				await CacheEventToLogLater(eventName, Event.SegmentEventType.Track, UserId, UserId, properties, options);
			}
			return false;
		}

		private async Task CacheEventToLogLater(string eventName, Event.SegmentEventType eventType, string previousId, string userId, IDictionary<string, object> properties, Options options)
		{
			Event obj = new Event
			{
				EventName = eventName,
				EventType = eventType,
				PreviousId = previousId,
				UserId = userId,
				Properties = properties,
				Options = options
			};
			try
			{
				await cache.InsertObject(obj.Key, obj);
			}
			catch (Exception ex)
			{
				ReportException($"Caught an Exception in {eventType}. Exception: {ex.GetType()} Message: {ex.Message}. Event will not be cached", ex);
			}
		}

		private async Task<Options> SetAnonymousIdOptionIfNeeded(Options options)
		{
			if (!string.IsNullOrWhiteSpace(UserId) || !string.IsNullOrWhiteSpace(options?.AnonymousId) || TrackAnonymousUserAnalytics == AnonymousTrackingState.Disabled)
			{
				return options;
			}
			return SetAnonymousIdOption(options, (await GetOrCreateAnonymousUserInfo().ConfigureAwait(continueOnCapturedContext: false)).AnonymousUserId);
		}

		protected Task<AnonymousUserInfo> GetOrCreateAnonymousUserInfo()
		{
			return AnonymousUserInfo.GetOrCreate(cache);
		}

		private Options SetAnonymousIdOption(Options options, string anonymousId)
		{
			options = options ?? new Options();
			options.AnonymousId = anonymousId;
			return options;
		}

		private void CheckShouldForceCacheAnonymousEvents(Options options)
		{
			if (TrackAnonymousUserAnalytics != AnonymousTrackingState.CachingOnly || string.IsNullOrWhiteSpace(options?.AnonymousId))
			{
				return;
			}
			throw new ConnectivityException(string.Format("{0} == {1}. Forcing anonymous event to be cached until ready.", "TrackAnonymousUserAnalytics", TrackAnonymousUserAnalytics));
		}
	}
}
