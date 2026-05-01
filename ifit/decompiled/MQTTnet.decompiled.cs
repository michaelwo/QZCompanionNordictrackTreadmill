using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Adapter;
using MQTTnet.Certificates;
using MQTTnet.Channel;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.ExtendedAuthenticationExchange;
using MQTTnet.Client.Options;
using MQTTnet.Client.Publishing;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Client.Unsubscribing;
using MQTTnet.Diagnostics;
using MQTTnet.Exceptions;
using MQTTnet.Formatter;
using MQTTnet.Formatter.V3;
using MQTTnet.Formatter.V5;
using MQTTnet.Implementations;
using MQTTnet.Internal;
using MQTTnet.LowLevelClient;
using MQTTnet.PacketDispatcher;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using MQTTnet.Server;
using MQTTnet.Server.Status;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("MQTTnet")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("3.0.12")]
[assembly: AssemblyInformationalVersion("1.0.0+6b6627f823105c05851b683c29cd2206697b4bdc")]
[assembly: AssemblyProduct("MQTTnet")]
[assembly: AssemblyTitle("MQTTnet")]
[assembly: AssemblyVersion("3.0.12.0")]
namespace MQTTnet
{
	public interface IApplicationMessagePublisher
	{
		Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken);
	}
	public interface IApplicationMessageReceiver
	{
		IMqttApplicationMessageReceivedHandler ApplicationMessageReceivedHandler { get; set; }
	}
	public interface IMqttFactory : IMqttClientFactory, IMqttServerFactory
	{
		IMqttNetLogger DefaultLogger { get; }

		IDictionary<object, object> Properties { get; }
	}
	public class MqttApplicationMessage
	{
		public string Topic { get; set; }

		public byte[] Payload { get; set; }

		public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

		public bool Retain { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }

		public string ContentType { get; set; }

		public string ResponseTopic { get; set; }

		public MqttPayloadFormatIndicator? PayloadFormatIndicator { get; set; }

		public uint? MessageExpiryInterval { get; set; }

		public ushort? TopicAlias { get; set; }

		public byte[] CorrelationData { get; set; }

		public List<uint> SubscriptionIdentifiers { get; set; }
	}
	public class MqttApplicationMessageBuilder
	{
		private MqttQualityOfServiceLevel _qualityOfServiceLevel;

		private string _topic;

		private byte[] _payload;

		private bool _retain;

		private string _contentType;

		private string _responseTopic;

		private byte[] _correlationData;

		private ushort? _topicAlias;

		private List<uint> _subscriptionIdentifiers;

		private uint? _messageExpiryInterval;

		private MqttPayloadFormatIndicator? _payloadFormatIndicator;

		private List<MqttUserProperty> _userProperties;

		public MqttApplicationMessageBuilder WithTopic(string topic)
		{
			_topic = topic;
			return this;
		}

		public MqttApplicationMessageBuilder WithPayload(byte[] payload)
		{
			_payload = payload;
			return this;
		}

		public MqttApplicationMessageBuilder WithPayload(IEnumerable<byte> payload)
		{
			if (payload == null)
			{
				_payload = null;
				return this;
			}
			_payload = payload as byte[];
			if (_payload == null)
			{
				_payload = payload.ToArray();
			}
			return this;
		}

		public MqttApplicationMessageBuilder WithPayload(Stream payload)
		{
			if (payload == null)
			{
				_payload = null;
				return this;
			}
			return WithPayload(payload, payload.Length - payload.Position);
		}

		public MqttApplicationMessageBuilder WithPayload(Stream payload, long length)
		{
			if (payload == null)
			{
				_payload = null;
				return this;
			}
			if (payload.Length == 0L)
			{
				_payload = null;
			}
			else
			{
				_payload = new byte[length];
				payload.Read(_payload, 0, _payload.Length);
			}
			return this;
		}

		public MqttApplicationMessageBuilder WithPayload(string payload)
		{
			if (payload == null)
			{
				_payload = null;
				return this;
			}
			_payload = (string.IsNullOrEmpty(payload) ? null : Encoding.UTF8.GetBytes(payload));
			return this;
		}

		public MqttApplicationMessageBuilder WithQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			_qualityOfServiceLevel = qualityOfServiceLevel;
			return this;
		}

		public MqttApplicationMessageBuilder WithRetainFlag(bool value = true)
		{
			_retain = value;
			return this;
		}

		public MqttApplicationMessageBuilder WithAtLeastOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce;
			return this;
		}

		public MqttApplicationMessageBuilder WithAtMostOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;
			return this;
		}

		public MqttApplicationMessageBuilder WithExactlyOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce;
			return this;
		}

		public MqttApplicationMessageBuilder WithUserProperty(string name, string value)
		{
			if (_userProperties == null)
			{
				_userProperties = new List<MqttUserProperty>();
			}
			_userProperties.Add(new MqttUserProperty(name, value));
			return this;
		}

		public MqttApplicationMessageBuilder WithContentType(string contentType)
		{
			_contentType = contentType;
			return this;
		}

		public MqttApplicationMessageBuilder WithResponseTopic(string responseTopic)
		{
			_responseTopic = responseTopic;
			return this;
		}

		public MqttApplicationMessageBuilder WithCorrelationData(byte[] correlationData)
		{
			_correlationData = correlationData;
			return this;
		}

		public MqttApplicationMessageBuilder WithTopicAlias(ushort topicAlias)
		{
			_topicAlias = topicAlias;
			return this;
		}

		public MqttApplicationMessageBuilder WithSubscriptionIdentifier(uint subscriptionIdentifier)
		{
			if (_subscriptionIdentifiers == null)
			{
				_subscriptionIdentifiers = new List<uint>();
			}
			_subscriptionIdentifiers.Add(subscriptionIdentifier);
			return this;
		}

		public MqttApplicationMessageBuilder WithMessageExpiryInterval(uint messageExpiryInterval)
		{
			_messageExpiryInterval = messageExpiryInterval;
			return this;
		}

		public MqttApplicationMessageBuilder WithPayloadFormatIndicator(MqttPayloadFormatIndicator payloadFormatIndicator)
		{
			_payloadFormatIndicator = payloadFormatIndicator;
			return this;
		}

		public MqttApplicationMessage Build()
		{
			if (string.IsNullOrEmpty(_topic))
			{
				throw new MqttProtocolViolationException("Topic is not set.");
			}
			return new MqttApplicationMessage
			{
				Topic = _topic,
				Payload = _payload,
				QualityOfServiceLevel = _qualityOfServiceLevel,
				Retain = _retain,
				ContentType = _contentType,
				ResponseTopic = _responseTopic,
				CorrelationData = _correlationData,
				TopicAlias = _topicAlias,
				SubscriptionIdentifiers = _subscriptionIdentifiers,
				MessageExpiryInterval = _messageExpiryInterval,
				PayloadFormatIndicator = _payloadFormatIndicator,
				UserProperties = _userProperties
			};
		}
	}
	public static class MqttApplicationMessageExtensions
	{
		public static string ConvertPayloadToString(this MqttApplicationMessage applicationMessage)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			if (applicationMessage.Payload == null)
			{
				return null;
			}
			if (applicationMessage.Payload.Length == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString(applicationMessage.Payload, 0, applicationMessage.Payload.Length);
		}
	}
	public class MqttApplicationMessageReceivedEventArgs : EventArgs
	{
		public string ClientId { get; }

		public MqttApplicationMessage ApplicationMessage { get; }

		public bool ProcessingFailed { get; set; }

		public MqttApplicationMessageReceivedEventArgs(string clientId, MqttApplicationMessage applicationMessage)
		{
			ClientId = clientId;
			ApplicationMessage = applicationMessage ?? throw new ArgumentNullException("applicationMessage");
		}
	}
	public sealed class MqttFactory : IMqttFactory, IMqttClientFactory, IMqttServerFactory
	{
		private IMqttClientAdapterFactory _clientAdapterFactory;

		public IMqttNetLogger DefaultLogger { get; }

		public IList<Func<IMqttFactory, IMqttServerAdapter>> DefaultServerAdapters { get; } = new List<Func<IMqttFactory, IMqttServerAdapter>>
		{
			(IMqttFactory factory) => new MqttTcpServerAdapter(factory.DefaultLogger)
		};

		public IDictionary<object, object> Properties { get; } = new Dictionary<object, object>();

		public MqttFactory()
			: this(new MqttNetLogger())
		{
		}

		public MqttFactory(IMqttNetLogger logger)
		{
			DefaultLogger = logger ?? throw new ArgumentNullException("logger");
			_clientAdapterFactory = new MqttClientAdapterFactory(logger);
		}

		public IMqttFactory UseClientAdapterFactory(IMqttClientAdapterFactory clientAdapterFactory)
		{
			_clientAdapterFactory = clientAdapterFactory ?? throw new ArgumentNullException("clientAdapterFactory");
			return this;
		}

		public ILowLevelMqttClient CreateLowLevelMqttClient()
		{
			return CreateLowLevelMqttClient(DefaultLogger);
		}

		public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			return new LowLevelMqttClient(_clientAdapterFactory, logger);
		}

		public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttClientAdapterFactory clientAdapterFactory)
		{
			if (clientAdapterFactory == null)
			{
				throw new ArgumentNullException("clientAdapterFactory");
			}
			return new LowLevelMqttClient(_clientAdapterFactory, DefaultLogger);
		}

		public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory clientAdapterFactory)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (clientAdapterFactory == null)
			{
				throw new ArgumentNullException("clientAdapterFactory");
			}
			return new LowLevelMqttClient(_clientAdapterFactory, logger);
		}

		public IMqttClient CreateMqttClient()
		{
			return CreateMqttClient(DefaultLogger);
		}

		public IMqttClient CreateMqttClient(IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			return new MqttClient(_clientAdapterFactory, logger);
		}

		public IMqttClient CreateMqttClient(IMqttClientAdapterFactory clientAdapterFactory)
		{
			if (clientAdapterFactory == null)
			{
				throw new ArgumentNullException("clientAdapterFactory");
			}
			return new MqttClient(clientAdapterFactory, DefaultLogger);
		}

		public IMqttClient CreateMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory clientAdapterFactory)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (clientAdapterFactory == null)
			{
				throw new ArgumentNullException("clientAdapterFactory");
			}
			return new MqttClient(clientAdapterFactory, logger);
		}

		public IMqttServer CreateMqttServer()
		{
			return CreateMqttServer(DefaultLogger);
		}

		public IMqttServer CreateMqttServer(IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			IEnumerable<IMqttServerAdapter> serverAdapters = DefaultServerAdapters.Select((Func<IMqttFactory, IMqttServerAdapter> a) => a(this));
			return CreateMqttServer(serverAdapters, logger);
		}

		public IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> serverAdapters, IMqttNetLogger logger)
		{
			if (serverAdapters == null)
			{
				throw new ArgumentNullException("serverAdapters");
			}
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			return new MqttServer(serverAdapters, logger);
		}

		public IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> serverAdapters)
		{
			if (serverAdapters == null)
			{
				throw new ArgumentNullException("serverAdapters");
			}
			return new MqttServer(serverAdapters, DefaultLogger);
		}
	}
	[Obsolete("Use MqttTopicFilter instead. It is just a renamed version to align with general namings in this lib.")]
	public class TopicFilter : MqttTopicFilter
	{
	}
	public class MqttTopicFilter
	{
		public string Topic { get; set; }

		public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

		public bool? NoLocal { get; set; }

		public bool? RetainAsPublished { get; set; }

		public MqttRetainHandling? RetainHandling { get; set; }

		public override string ToString()
		{
			return string.Concat("TopicFilter: [Topic=", Topic, "] [QualityOfServiceLevel=", QualityOfServiceLevel, "] [NoLocal=", NoLocal, "] [RetainAsPublished=", RetainAsPublished, "] [RetainHandling=", RetainHandling, "]");
		}
	}
	[Obsolete("Use MqttTopicFilterBuilder instead. It is just a renamed version to align with general namings in this lib.")]
	public class TopicFilterBuilder : MqttTopicFilterBuilder
	{
	}
	public class MqttTopicFilterBuilder
	{
		private MqttQualityOfServiceLevel _qualityOfServiceLevel;

		private string _topic;

		public MqttTopicFilterBuilder WithTopic(string topic)
		{
			_topic = topic;
			return this;
		}

		public MqttTopicFilterBuilder WithQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			_qualityOfServiceLevel = qualityOfServiceLevel;
			return this;
		}

		public MqttTopicFilterBuilder WithAtLeastOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce;
			return this;
		}

		public MqttTopicFilterBuilder WithAtMostOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;
			return this;
		}

		public MqttTopicFilterBuilder WithExactlyOnceQoS()
		{
			_qualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce;
			return this;
		}

		public MqttTopicFilter Build()
		{
			if (string.IsNullOrEmpty(_topic))
			{
				throw new MqttProtocolViolationException("Topic is not set.");
			}
			return new MqttTopicFilter
			{
				Topic = _topic,
				QualityOfServiceLevel = _qualityOfServiceLevel
			};
		}
	}
}
namespace MQTTnet.Server
{
	public class CheckSubscriptionsResult
	{
		public bool IsSubscribed { get; set; }

		public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }
	}
	public interface IMqttClientSession
	{
		string ClientId { get; }

		Task StopAsync();
	}
	public interface IMqttRetainedMessagesManager
	{
		Task Start(IMqttServerOptions options, IMqttNetLogger logger);

		Task LoadMessagesAsync();

		Task ClearMessagesAsync();

		Task HandleMessageAsync(string clientId, MqttApplicationMessage applicationMessage);

		Task<IList<MqttApplicationMessage>> GetMessagesAsync();

		Task<IList<MqttApplicationMessage>> GetSubscribedMessagesAsync(ICollection<MqttTopicFilter> topicFilters);
	}
	public interface IMqttServer : IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
	{
		bool IsStarted { get; }

		IMqttServerStartedHandler StartedHandler { get; set; }

		IMqttServerStoppedHandler StoppedHandler { get; set; }

		IMqttServerClientConnectedHandler ClientConnectedHandler { get; set; }

		IMqttServerClientDisconnectedHandler ClientDisconnectedHandler { get; set; }

		IMqttServerClientSubscribedTopicHandler ClientSubscribedTopicHandler { get; set; }

		IMqttServerClientUnsubscribedTopicHandler ClientUnsubscribedTopicHandler { get; set; }

		IMqttServerOptions Options { get; }

		Task<IList<IMqttClientStatus>> GetClientStatusAsync();

		Task<IList<IMqttSessionStatus>> GetSessionStatusAsync();

		Task<IList<MqttApplicationMessage>> GetRetainedApplicationMessagesAsync();

		Task ClearRetainedApplicationMessagesAsync();

		Task SubscribeAsync(string clientId, ICollection<MqttTopicFilter> topicFilters);

		Task UnsubscribeAsync(string clientId, ICollection<string> topicFilters);

		Task StartAsync(IMqttServerOptions options);

		Task StopAsync();
	}
	public interface IMqttServerApplicationMessageInterceptor
	{
		Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context);
	}
	public interface IMqttServerCertificateCredentials
	{
		string Password { get; }
	}
	public interface IMqttServerClientConnectedHandler
	{
		Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs);
	}
	public interface IMqttServerClientDisconnectedHandler
	{
		Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs);
	}
	public interface IMqttServerClientMessageQueueInterceptor
	{
		Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context);
	}
	public interface IMqttServerClientSubscribedTopicHandler
	{
		Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs);
	}
	public interface IMqttServerClientUnsubscribedTopicHandler
	{
		Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs);
	}
	public interface IMqttServerConnectionValidator
	{
		Task ValidateConnectionAsync(MqttConnectionValidatorContext context);
	}
	public interface IMqttServerFactory
	{
		IList<Func<IMqttFactory, IMqttServerAdapter>> DefaultServerAdapters { get; }

		IMqttServer CreateMqttServer();

		IMqttServer CreateMqttServer(IMqttNetLogger logger);

		IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> adapters);

		IMqttServer CreateMqttServer(IEnumerable<IMqttServerAdapter> adapters, IMqttNetLogger logger);
	}
	public interface IMqttServerOptions
	{
		string ClientId { get; set; }

		bool EnablePersistentSessions { get; }

		int MaxPendingMessagesPerClient { get; }

		MqttPendingMessagesOverflowStrategy PendingMessagesOverflowStrategy { get; }

		TimeSpan DefaultCommunicationTimeout { get; }

		IMqttServerConnectionValidator ConnectionValidator { get; }

		IMqttServerSubscriptionInterceptor SubscriptionInterceptor { get; }

		IMqttServerUnsubscriptionInterceptor UnsubscriptionInterceptor { get; }

		IMqttServerApplicationMessageInterceptor ApplicationMessageInterceptor { get; }

		IMqttServerClientMessageQueueInterceptor ClientMessageQueueInterceptor { get; }

		MqttServerTcpEndpointOptions DefaultEndpointOptions { get; }

		MqttServerTlsTcpEndpointOptions TlsEndpointOptions { get; }

		IMqttServerStorage Storage { get; }

		IMqttRetainedMessagesManager RetainedMessagesManager { get; }

		IMqttServerApplicationMessageInterceptor UndeliveredMessageInterceptor { get; set; }
	}
	public interface IMqttServerPersistedSession
	{
		string ClientId { get; }

		IDictionary<object, object> Items { get; }

		IList<MqttTopicFilter> Subscriptions { get; }

		MqttApplicationMessage WillMessage { get; }

		uint? WillDelayInterval { get; }

		DateTime? SessionExpiryTimestamp { get; }

		IList<MqttQueuedApplicationMessage> PendingApplicationMessages { get; }
	}
	public interface IMqttServerPersistedSessionsStorage
	{
		Task<IList<IMqttServerPersistedSession>> LoadPersistedSessionsAsync();
	}
	public interface IMqttServerStartedHandler
	{
		Task HandleServerStartedAsync(EventArgs eventArgs);
	}
	public interface IMqttServerStoppedHandler
	{
		Task HandleServerStoppedAsync(EventArgs eventArgs);
	}
	public interface IMqttServerStorage
	{
		Task SaveRetainedMessagesAsync(IList<MqttApplicationMessage> messages);

		Task<IList<MqttApplicationMessage>> LoadRetainedMessagesAsync();
	}
	public interface IMqttServerSubscriptionInterceptor
	{
		Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context);
	}
	public interface IMqttServerUnsubscriptionInterceptor
	{
		Task InterceptUnsubscriptionAsync(MqttUnsubscriptionInterceptorContext context);
	}
	public class MqttApplicationMessageInterceptorContext
	{
		public string ClientId { get; }

		public MqttApplicationMessage ApplicationMessage { get; set; }

		public IDictionary<object, object> SessionItems { get; }

		public bool AcceptPublish { get; set; } = true;

		public bool CloseConnection { get; set; }

		public MqttApplicationMessageInterceptorContext(string clientId, IDictionary<object, object> sessionItems, MqttApplicationMessage applicationMessage)
		{
			ClientId = clientId;
			ApplicationMessage = applicationMessage;
			SessionItems = sessionItems;
		}
	}
	public sealed class MqttClientConnection : IDisposable
	{
		private readonly MqttPacketIdentifierProvider _packetIdentifierProvider = new MqttPacketIdentifierProvider();

		private readonly MqttPacketDispatcher _packetDispatcher = new MqttPacketDispatcher();

		private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();

		private readonly IMqttRetainedMessagesManager _retainedMessagesManager;

		private readonly Func<Task> _onStart;

		private readonly Func<MqttClientDisconnectType, Task> _onStop;

		private readonly MqttClientKeepAliveMonitor _keepAliveMonitor;

		private readonly MqttClientSessionsManager _sessionsManager;

		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttServerOptions _serverOptions;

		private readonly IMqttChannelAdapter _channelAdapter;

		private readonly IMqttDataConverter _dataConverter;

		private readonly string _endpoint;

		private readonly DateTime _connectedTimestamp;

		private volatile Task _packageReceiverTask;

		private DateTime _lastPacketReceivedTimestamp;

		private DateTime _lastNonKeepAlivePacketReceivedTimestamp;

		private long _receivedPacketsCount;

		private long _sentPacketsCount = 1L;

		private long _receivedApplicationMessagesCount;

		private long _sentApplicationMessagesCount;

		private volatile bool _isTakeover;

		public MqttConnectPacket ConnectPacket { get; }

		public string ClientId => ConnectPacket.ClientId;

		public MqttClientSession Session { get; }

		public MqttClientConnection(MqttConnectPacket connectPacket, IMqttChannelAdapter channelAdapter, MqttClientSession session, IMqttServerOptions serverOptions, MqttClientSessionsManager sessionsManager, IMqttRetainedMessagesManager retainedMessagesManager, Func<Task> onStart, Func<MqttClientDisconnectType, Task> onStop, IMqttNetLogger logger)
		{
			Session = session ?? throw new ArgumentNullException("session");
			_serverOptions = serverOptions ?? throw new ArgumentNullException("serverOptions");
			_sessionsManager = sessionsManager ?? throw new ArgumentNullException("sessionsManager");
			_retainedMessagesManager = retainedMessagesManager ?? throw new ArgumentNullException("retainedMessagesManager");
			_onStart = onStart ?? throw new ArgumentNullException("onStart");
			_onStop = onStop ?? throw new ArgumentNullException("onStop");
			_channelAdapter = channelAdapter ?? throw new ArgumentNullException("channelAdapter");
			_dataConverter = _channelAdapter.PacketFormatterAdapter.DataConverter;
			_endpoint = _channelAdapter.Endpoint;
			ConnectPacket = connectPacket ?? throw new ArgumentNullException("connectPacket");
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttClientConnection");
			_keepAliveMonitor = new MqttClientKeepAliveMonitor(ConnectPacket.ClientId, () => StopAsync(), logger);
			_connectedTimestamp = DateTime.UtcNow;
			_lastPacketReceivedTimestamp = _connectedTimestamp;
			_lastNonKeepAlivePacketReceivedTimestamp = _lastPacketReceivedTimestamp;
		}

		public Task StopAsync(bool isTakeover = false)
		{
			_isTakeover = isTakeover;
			Task packageReceiverTask = _packageReceiverTask;
			StopInternal();
			if (packageReceiverTask != null)
			{
				return packageReceiverTask;
			}
			return PlatformAbstractionLayer.CompletedTask;
		}

		public void ResetStatistics()
		{
			_channelAdapter.ResetStatistics();
		}

		public void FillStatus(MqttClientStatus status)
		{
			status.ClientId = ClientId;
			status.Endpoint = _endpoint;
			status.ProtocolVersion = _channelAdapter.PacketFormatterAdapter.ProtocolVersion;
			status.ReceivedApplicationMessagesCount = Interlocked.Read(ref _receivedApplicationMessagesCount);
			status.SentApplicationMessagesCount = Interlocked.Read(ref _sentApplicationMessagesCount);
			status.ReceivedPacketsCount = Interlocked.Read(ref _receivedPacketsCount);
			status.SentPacketsCount = Interlocked.Read(ref _sentPacketsCount);
			status.ConnectedTimestamp = _connectedTimestamp;
			status.LastPacketReceivedTimestamp = _lastPacketReceivedTimestamp;
			status.LastNonKeepAlivePacketReceivedTimestamp = _lastNonKeepAlivePacketReceivedTimestamp;
			status.BytesSent = _channelAdapter.BytesSent;
			status.BytesReceived = _channelAdapter.BytesReceived;
		}

		public void Dispose()
		{
			_cancellationToken.Dispose();
		}

		public Task RunAsync(MqttConnectionValidatorContext connectionValidatorContext)
		{
			_packageReceiverTask = RunInternalAsync(connectionValidatorContext);
			return _packageReceiverTask;
		}

		private async Task RunInternalAsync(MqttConnectionValidatorContext connectionValidatorContext)
		{
			MqttClientDisconnectType disconnectType = MqttClientDisconnectType.NotClean;
			object obj = null;
			try
			{
				_ = 7;
				try
				{
					await _onStart();
					_logger.Info("Client '{0}': Session started.", ClientId);
					_channelAdapter.ReadingPacketStartedCallback = OnAdapterReadingPacketStarted;
					_channelAdapter.ReadingPacketCompletedCallback = OnAdapterReadingPacketCompleted;
					Session.WillMessage = ConnectPacket.WillMessage;
					Task.Run(() => SendPendingPacketsAsync(_cancellationToken.Token), _cancellationToken.Token).Forget(_logger);
					_keepAliveMonitor.Start(ConnectPacket.KeepAlivePeriod, _cancellationToken.Token);
					await SendAsync(_channelAdapter.PacketFormatterAdapter.DataConverter.CreateConnAckPacket(connectionValidatorContext)).ConfigureAwait(continueOnCapturedContext: false);
					Session.IsCleanSession = false;
					while (!_cancellationToken.IsCancellationRequested)
					{
						MqttBasePacket mqttBasePacket = await _channelAdapter.ReceivePacketAsync(TimeSpan.Zero, _cancellationToken.Token).ConfigureAwait(continueOnCapturedContext: false);
						if (mqttBasePacket == null)
						{
							break;
						}
						Interlocked.Increment(ref _sentPacketsCount);
						_lastPacketReceivedTimestamp = DateTime.UtcNow;
						if (!(mqttBasePacket is MqttPingReqPacket) && !(mqttBasePacket is MqttPingRespPacket))
						{
							_lastNonKeepAlivePacketReceivedTimestamp = _lastPacketReceivedTimestamp;
						}
						_keepAliveMonitor.PacketReceived();
						if (mqttBasePacket is MqttPublishPacket publishPacket)
						{
							await HandleIncomingPublishPacketAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (mqttBasePacket is MqttPubRelPacket mqttPubRelPacket)
						{
							MqttPubCompPacket packet = new MqttPubCompPacket
							{
								PacketIdentifier = mqttPubRelPacket.PacketIdentifier,
								ReasonCode = MqttPubCompReasonCode.Success
							};
							await SendAsync(packet).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (mqttBasePacket is MqttSubscribePacket subscribePacket)
						{
							await HandleIncomingSubscribePacketAsync(subscribePacket).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (mqttBasePacket is MqttUnsubscribePacket unsubscribePacket)
						{
							await HandleIncomingUnsubscribePacketAsync(unsubscribePacket).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (mqttBasePacket is MqttPingReqPacket)
						{
							await SendAsync(new MqttPingRespPacket()).ConfigureAwait(continueOnCapturedContext: false);
							continue;
						}
						if (mqttBasePacket is MqttDisconnectPacket)
						{
							Session.WillMessage = null;
							disconnectType = MqttClientDisconnectType.Clean;
							StopInternal();
							break;
						}
						_packetDispatcher.Dispatch(mqttBasePacket);
					}
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception ex2)
				{
					if (ex2 is MqttCommunicationException)
					{
						_logger.Warning(ex2, "Client '{0}': Communication exception while receiving client packets.", ClientId);
					}
					else
					{
						_logger.Error(ex2, "Client '{0}': Error while receiving client packets.", ClientId);
					}
					StopInternal();
				}
			}
			catch (object obj2)
			{
				obj = obj2;
			}
			if (_isTakeover)
			{
				disconnectType = MqttClientDisconnectType.Takeover;
			}
			if (Session.WillMessage != null)
			{
				_sessionsManager.DispatchApplicationMessage(Session.WillMessage, this);
				Session.WillMessage = null;
			}
			_packetDispatcher.Reset();
			_channelAdapter.ReadingPacketStartedCallback = null;
			_channelAdapter.ReadingPacketCompletedCallback = null;
			_logger.Info("Client '{0}': Connection stopped.", ClientId);
			_packageReceiverTask = null;
			try
			{
				await _onStop(disconnectType);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "client '{0}': Error while cleaning up", ClientId);
			}
			object obj3 = obj;
			if (obj3 != null)
			{
				ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
			}
		}

		private void StopInternal()
		{
			_cancellationToken.Cancel(throwOnFirstException: false);
		}

		private async Task EnqueueSubscribedRetainedMessagesAsync(ICollection<MqttTopicFilter> topicFilters)
		{
			foreach (MqttApplicationMessage item in await _retainedMessagesManager.GetSubscribedMessagesAsync(topicFilters).ConfigureAwait(continueOnCapturedContext: false))
			{
				Session.EnqueueApplicationMessage(item, ClientId, isRetainedApplicationMessage: true);
			}
		}

		private async Task HandleIncomingSubscribePacketAsync(MqttSubscribePacket subscribePacket)
		{
			MqttClientSubscribeResult subscribeResult = await Session.SubscriptionsManager.SubscribeAsync(subscribePacket, ConnectPacket).ConfigureAwait(continueOnCapturedContext: false);
			await SendAsync(subscribeResult.ResponsePacket).ConfigureAwait(continueOnCapturedContext: false);
			if (subscribeResult.CloseConnection)
			{
				StopInternal();
			}
			else
			{
				await EnqueueSubscribedRetainedMessagesAsync(subscribePacket.TopicFilters).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private async Task HandleIncomingUnsubscribePacketAsync(MqttUnsubscribePacket unsubscribePacket)
		{
			await SendAsync(await Session.SubscriptionsManager.UnsubscribeAsync(unsubscribePacket).ConfigureAwait(continueOnCapturedContext: false)).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task HandleIncomingPublishPacketAsync(MqttPublishPacket publishPacket)
		{
			Interlocked.Increment(ref _sentApplicationMessagesCount);
			return publishPacket.QualityOfServiceLevel switch
			{
				MqttQualityOfServiceLevel.AtMostOnce => HandleIncomingPublishPacketWithQoS0Async(publishPacket), 
				MqttQualityOfServiceLevel.AtLeastOnce => HandleIncomingPublishPacketWithQoS1Async(publishPacket), 
				MqttQualityOfServiceLevel.ExactlyOnce => HandleIncomingPublishPacketWithQoS2Async(publishPacket), 
				_ => throw new MqttCommunicationException("Received a not supported QoS level."), 
			};
		}

		private Task HandleIncomingPublishPacketWithQoS0Async(MqttPublishPacket publishPacket)
		{
			MqttApplicationMessage applicationMessage = _dataConverter.CreateApplicationMessage(publishPacket);
			_sessionsManager.DispatchApplicationMessage(applicationMessage, this);
			return PlatformAbstractionLayer.CompletedTask;
		}

		private Task HandleIncomingPublishPacketWithQoS1Async(MqttPublishPacket publishPacket)
		{
			MqttApplicationMessage applicationMessage = _dataConverter.CreateApplicationMessage(publishPacket);
			_sessionsManager.DispatchApplicationMessage(applicationMessage, this);
			MqttPubAckPacket packet = _dataConverter.CreatePubAckPacket(publishPacket);
			return SendAsync(packet);
		}

		private Task HandleIncomingPublishPacketWithQoS2Async(MqttPublishPacket publishPacket)
		{
			MqttApplicationMessage applicationMessage = _dataConverter.CreateApplicationMessage(publishPacket);
			_sessionsManager.DispatchApplicationMessage(applicationMessage, this);
			MqttPubRecPacket packet = new MqttPubRecPacket
			{
				PacketIdentifier = publishPacket.PacketIdentifier,
				ReasonCode = MqttPubRecReasonCode.Success
			};
			return SendAsync(packet);
		}

		private async Task SendPendingPacketsAsync(CancellationToken cancellationToken)
		{
			MqttQueuedApplicationMessage queuedApplicationMessage = null;
			MqttPublishPacket publishPacket = null;
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					queuedApplicationMessage = await Session.ApplicationMessagesQueue.TakeAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (queuedApplicationMessage == null || cancellationToken.IsCancellationRequested)
					{
						return;
					}
					publishPacket = _dataConverter.CreatePublishPacket(queuedApplicationMessage.ApplicationMessage);
					publishPacket.QualityOfServiceLevel = queuedApplicationMessage.QualityOfServiceLevel;
					publishPacket.Retain = queuedApplicationMessage.IsRetainedMessage;
					if (publishPacket.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
					{
						publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();
					}
					if (_serverOptions.ClientMessageQueueInterceptor != null)
					{
						MqttClientMessageQueueInterceptorContext context = new MqttClientMessageQueueInterceptorContext(queuedApplicationMessage.SenderClientId, ClientId, queuedApplicationMessage.ApplicationMessage);
						if (_serverOptions.ClientMessageQueueInterceptor != null)
						{
							await _serverOptions.ClientMessageQueueInterceptor.InterceptClientMessageQueueEnqueueAsync(context).ConfigureAwait(continueOnCapturedContext: false);
						}
						if (!context.AcceptEnqueue || context.ApplicationMessage == null)
						{
							return;
						}
						publishPacket.Topic = context.ApplicationMessage.Topic;
						publishPacket.Payload = context.ApplicationMessage.Payload;
						publishPacket.QualityOfServiceLevel = context.ApplicationMessage.QualityOfServiceLevel;
					}
					if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce)
					{
						await SendAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false);
					}
					else if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtLeastOnce)
					{
						MqttPacketAwaiter<MqttPubAckPacket> awaiter = _packetDispatcher.AddAwaiter<MqttPubAckPacket>(publishPacket.PacketIdentifier);
						await SendAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false);
						await awaiter.WaitOneAsync(_serverOptions.DefaultCommunicationTimeout).ConfigureAwait(continueOnCapturedContext: false);
					}
					else if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.ExactlyOnce)
					{
						using MqttPacketAwaiter<MqttPubRecPacket> awaiter2 = _packetDispatcher.AddAwaiter<MqttPubRecPacket>(publishPacket.PacketIdentifier);
						using MqttPacketAwaiter<MqttPubCompPacket> awaiter3 = _packetDispatcher.AddAwaiter<MqttPubCompPacket>(publishPacket.PacketIdentifier);
						await SendAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false);
						await awaiter2.WaitOneAsync(_serverOptions.DefaultCommunicationTimeout).ConfigureAwait(continueOnCapturedContext: false);
						await SendAsync(new MqttPubRelPacket
						{
							PacketIdentifier = publishPacket.PacketIdentifier
						}).ConfigureAwait(continueOnCapturedContext: false);
						await awaiter3.WaitOneAsync(_serverOptions.DefaultCommunicationTimeout).ConfigureAwait(continueOnCapturedContext: false);
					}
					_logger.Verbose("Queued application message sent (ClientId: {0}).", ClientId);
				}
			}
			catch (Exception ex)
			{
				if (ex is MqttCommunicationTimedOutException)
				{
					_logger.Warning(ex, "Sending publish packet failed: Timeout (ClientId: {0}).", ClientId);
				}
				else if (ex is MqttCommunicationException)
				{
					_logger.Warning(ex, "Sending publish packet failed: Communication exception (ClientId: {0}).", ClientId);
				}
				else if (!(ex is OperationCanceledException))
				{
					_logger.Error(ex, "Sending publish packet failed (ClientId: {0}).", ClientId);
				}
				MqttPublishPacket mqttPublishPacket = publishPacket;
				if (mqttPublishPacket != null && mqttPublishPacket.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
				{
					queuedApplicationMessage.IsDuplicate = true;
					Session.ApplicationMessagesQueue.Enqueue(queuedApplicationMessage);
				}
				if (!_cancellationToken.Token.IsCancellationRequested)
				{
					await StopAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		private async Task SendAsync(MqttBasePacket packet)
		{
			await _channelAdapter.SendPacketAsync(packet, _serverOptions.DefaultCommunicationTimeout, _cancellationToken.Token).ConfigureAwait(continueOnCapturedContext: false);
			Interlocked.Increment(ref _receivedPacketsCount);
			if (packet is MqttPublishPacket)
			{
				Interlocked.Increment(ref _receivedApplicationMessagesCount);
			}
		}

		private void OnAdapterReadingPacketCompleted()
		{
			_keepAliveMonitor?.Resume();
		}

		private void OnAdapterReadingPacketStarted()
		{
			_keepAliveMonitor?.Pause();
		}
	}
	public enum MqttClientDisconnectType
	{
		Clean,
		NotClean,
		Takeover
	}
	public sealed class MqttClientKeepAliveMonitor
	{
		private readonly Stopwatch _lastPacketReceivedTracker = new Stopwatch();

		private readonly string _clientId;

		private readonly Func<Task> _keepAliveElapsedCallback;

		private readonly IMqttNetScopedLogger _logger;

		private bool _isPaused;

		public MqttClientKeepAliveMonitor(string clientId, Func<Task> keepAliveElapsedCallback, IMqttNetLogger logger)
		{
			_clientId = clientId ?? throw new ArgumentNullException("clientId");
			_keepAliveElapsedCallback = keepAliveElapsedCallback ?? throw new ArgumentNullException("keepAliveElapsedCallback");
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttClientKeepAliveMonitor");
		}

		public void Start(int keepAlivePeriod, CancellationToken cancellationToken)
		{
			if (keepAlivePeriod != 0)
			{
				Task.Run(() => RunAsync(keepAlivePeriod, cancellationToken), cancellationToken).Forget(_logger);
			}
		}

		public void Pause()
		{
			_isPaused = true;
		}

		public void Resume()
		{
			_isPaused = false;
		}

		public void PacketReceived()
		{
			_lastPacketReceivedTracker.Restart();
		}

		private async Task RunAsync(int keepAlivePeriod, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				_lastPacketReceivedTracker.Restart();
				while (!cancellationToken.IsCancellationRequested)
				{
					if (!_isPaused && _lastPacketReceivedTracker.Elapsed.TotalSeconds >= (double)keepAlivePeriod * 1.5)
					{
						_logger.Warning(null, "Client '{0}': Did not receive any packet or keep alive signal.", _clientId);
						await _keepAliveElapsedCallback().ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
					await Task.Delay(TimeSpan.FromSeconds((double)keepAlivePeriod * 0.5), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Client '{0}': Unhandled exception while checking keep alive timeouts.", _clientId);
			}
			finally
			{
				_logger.Verbose("Client '{0}': Stopped checking keep alive timeout.", _clientId);
			}
		}
	}
	public class MqttClientMessageQueueInterceptorContext
	{
		public string SenderClientId { get; }

		public string ReceiverClientId { get; }

		public MqttApplicationMessage ApplicationMessage { get; set; }

		public bool AcceptEnqueue { get; set; } = true;

		public MqttClientMessageQueueInterceptorContext(string senderClientId, string receiverClientId, MqttApplicationMessage applicationMessage)
		{
			SenderClientId = senderClientId;
			ReceiverClientId = receiverClientId;
			ApplicationMessage = applicationMessage;
		}
	}
	public class MqttClientSession
	{
		private readonly IMqttNetScopedLogger _logger;

		private readonly DateTime _createdTimestamp = DateTime.UtcNow;

		private readonly IMqttRetainedMessagesManager _retainedMessagesManager;

		public string ClientId { get; }

		public bool IsCleanSession { get; set; } = true;

		public MqttApplicationMessage WillMessage { get; set; }

		public MqttClientSubscriptionsManager SubscriptionsManager { get; }

		public MqttClientSessionApplicationMessagesQueue ApplicationMessagesQueue { get; }

		public IDictionary<object, object> Items { get; }

		public MqttClientSession(string clientId, IDictionary<object, object> items, MqttServerEventDispatcher eventDispatcher, IMqttServerOptions serverOptions, IMqttRetainedMessagesManager retainedMessagesManager, IMqttNetLogger logger)
		{
			ClientId = clientId ?? throw new ArgumentNullException("clientId");
			Items = items ?? throw new ArgumentNullException("items");
			_retainedMessagesManager = retainedMessagesManager ?? throw new ArgumentNullException("retainedMessagesManager");
			SubscriptionsManager = new MqttClientSubscriptionsManager(this, eventDispatcher, serverOptions);
			ApplicationMessagesQueue = new MqttClientSessionApplicationMessagesQueue(serverOptions);
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttClientSession");
		}

		public bool EnqueueApplicationMessage(MqttApplicationMessage applicationMessage, string senderClientId, bool isRetainedApplicationMessage)
		{
			CheckSubscriptionsResult checkSubscriptionsResult = SubscriptionsManager.CheckSubscriptions(applicationMessage.Topic, applicationMessage.QualityOfServiceLevel);
			if (!checkSubscriptionsResult.IsSubscribed)
			{
				return false;
			}
			_logger.Verbose("Queued application message with topic '{0}' (ClientId: {1}).", applicationMessage.Topic, ClientId);
			ApplicationMessagesQueue.Enqueue(applicationMessage, senderClientId, checkSubscriptionsResult.QualityOfServiceLevel, isRetainedApplicationMessage);
			return true;
		}

		public async Task SubscribeAsync(ICollection<MqttTopicFilter> topicFilters)
		{
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			await SubscriptionsManager.SubscribeAsync(topicFilters).ConfigureAwait(continueOnCapturedContext: false);
			foreach (MqttApplicationMessage item in await _retainedMessagesManager.GetSubscribedMessagesAsync(topicFilters).ConfigureAwait(continueOnCapturedContext: false))
			{
				EnqueueApplicationMessage(item, null, isRetainedApplicationMessage: true);
			}
		}

		public Task UnsubscribeAsync(IEnumerable<string> topicFilters)
		{
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			return SubscriptionsManager.UnsubscribeAsync(topicFilters);
		}

		public void FillStatus(MqttSessionStatus status)
		{
			status.ClientId = ClientId;
			status.CreatedTimestamp = _createdTimestamp;
			status.PendingApplicationMessagesCount = ApplicationMessagesQueue.Count;
			status.Items = Items;
		}
	}
	public class MqttClientSessionApplicationMessagesQueue : Disposable
	{
		private readonly AsyncQueue<MqttQueuedApplicationMessage> _messageQueue = new AsyncQueue<MqttQueuedApplicationMessage>();

		private readonly IMqttServerOptions _options;

		public int Count => _messageQueue.Count;

		public MqttClientSessionApplicationMessagesQueue(IMqttServerOptions options)
		{
			_options = options ?? throw new ArgumentNullException("options");
		}

		public void Enqueue(MqttApplicationMessage applicationMessage, string senderClientId, MqttQualityOfServiceLevel qualityOfServiceLevel, bool isRetainedMessage)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			Enqueue(new MqttQueuedApplicationMessage
			{
				ApplicationMessage = applicationMessage,
				SenderClientId = senderClientId,
				QualityOfServiceLevel = qualityOfServiceLevel,
				IsRetainedMessage = isRetainedMessage
			});
		}

		public void Clear()
		{
			_messageQueue.Clear();
		}

		public async Task<MqttQueuedApplicationMessage> TakeAsync(CancellationToken cancellationToken)
		{
			AsyncQueueDequeueResult<MqttQueuedApplicationMessage> asyncQueueDequeueResult = await _messageQueue.TryDequeueAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (!asyncQueueDequeueResult.IsSuccess)
			{
				return null;
			}
			return asyncQueueDequeueResult.Item;
		}

		public void Enqueue(MqttQueuedApplicationMessage queuedApplicationMessage)
		{
			if (queuedApplicationMessage == null)
			{
				throw new ArgumentNullException("queuedApplicationMessage");
			}
			lock (_messageQueue)
			{
				if (_messageQueue.Count >= _options.MaxPendingMessagesPerClient)
				{
					if (_options.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropNewMessage)
					{
						return;
					}
					if (_options.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropOldestQueuedMessage)
					{
						_messageQueue.TryDequeue();
					}
				}
				_messageQueue.Enqueue(queuedApplicationMessage);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_messageQueue.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	public sealed class MqttClientSessionsManager : IDisposable
	{
		private readonly AsyncQueue<MqttEnqueuedApplicationMessage> _messageQueue = new AsyncQueue<MqttEnqueuedApplicationMessage>();

		private readonly AsyncLock _createConnectionGate = new AsyncLock();

		private readonly ConcurrentDictionary<string, MqttClientConnection> _connections = new ConcurrentDictionary<string, MqttClientConnection>();

		private readonly ConcurrentDictionary<string, MqttClientSession> _sessions = new ConcurrentDictionary<string, MqttClientSession>();

		private readonly IDictionary<object, object> _serverSessionItems = new ConcurrentDictionary<object, object>();

		private readonly CancellationToken _cancellationToken;

		private readonly MqttServerEventDispatcher _eventDispatcher;

		private readonly IMqttRetainedMessagesManager _retainedMessagesManager;

		private readonly IMqttServerOptions _options;

		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttNetLogger _rootLogger;

		public MqttClientSessionsManager(IMqttServerOptions options, IMqttRetainedMessagesManager retainedMessagesManager, CancellationToken cancellationToken, MqttServerEventDispatcher eventDispatcher, IMqttNetLogger logger)
		{
			_cancellationToken = cancellationToken;
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttClientSessionsManager");
			_rootLogger = logger;
			_eventDispatcher = eventDispatcher ?? throw new ArgumentNullException("eventDispatcher");
			_options = options ?? throw new ArgumentNullException("options");
			_retainedMessagesManager = retainedMessagesManager ?? throw new ArgumentNullException("retainedMessagesManager");
		}

		public void Start()
		{
			Task.Run(() => TryProcessQueuedApplicationMessagesAsync(_cancellationToken), _cancellationToken).Forget(_logger);
		}

		public async Task StopAsync()
		{
			foreach (MqttClientConnection value in _connections.Values)
			{
				await value.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public Task HandleClientConnectionAsync(IMqttChannelAdapter clientAdapter)
		{
			if (clientAdapter == null)
			{
				throw new ArgumentNullException("clientAdapter");
			}
			return HandleClientConnectionAsync(clientAdapter, _cancellationToken);
		}

		public Task<IList<IMqttClientStatus>> GetClientStatusAsync()
		{
			List<IMqttClientStatus> list = new List<IMqttClientStatus>();
			foreach (MqttClientConnection value in _connections.Values)
			{
				MqttClientStatus mqttClientStatus = new MqttClientStatus(value);
				value.FillStatus(mqttClientStatus);
				MqttSessionStatus mqttSessionStatus = new MqttSessionStatus(value.Session, this);
				value.Session.FillStatus(mqttSessionStatus);
				mqttClientStatus.Session = mqttSessionStatus;
				list.Add(mqttClientStatus);
			}
			return Task.FromResult((IList<IMqttClientStatus>)list);
		}

		public Task<IList<IMqttSessionStatus>> GetSessionStatusAsync()
		{
			List<IMqttSessionStatus> list = new List<IMqttSessionStatus>();
			foreach (MqttClientSession value in _sessions.Values)
			{
				MqttSessionStatus mqttSessionStatus = new MqttSessionStatus(value, this);
				value.FillStatus(mqttSessionStatus);
				list.Add(mqttSessionStatus);
			}
			return Task.FromResult((IList<IMqttSessionStatus>)list);
		}

		public void DispatchApplicationMessage(MqttApplicationMessage applicationMessage, MqttClientConnection sender)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			_messageQueue.Enqueue(new MqttEnqueuedApplicationMessage(applicationMessage, sender));
		}

		public Task SubscribeAsync(string clientId, ICollection<MqttTopicFilter> topicFilters)
		{
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			if (!_sessions.TryGetValue(clientId, out var value))
			{
				throw new InvalidOperationException("Client session '" + clientId + "' is unknown.");
			}
			return value.SubscribeAsync(topicFilters);
		}

		public Task UnsubscribeAsync(string clientId, IEnumerable<string> topicFilters)
		{
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			if (!_sessions.TryGetValue(clientId, out var value))
			{
				throw new InvalidOperationException("Client session '" + clientId + "' is unknown.");
			}
			return value.UnsubscribeAsync(topicFilters);
		}

		public async Task DeleteSessionAsync(string clientId)
		{
			if (_connections.TryGetValue(clientId, out var value))
			{
				await value.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			_sessions.TryRemove(clientId, out var _);
			_logger.Verbose("Session for client '{0}' deleted.", clientId);
		}

		public void Dispose()
		{
			_messageQueue?.Dispose();
		}

		private async Task TryProcessQueuedApplicationMessagesAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					await TryProcessNextQueuedApplicationMessageAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception exception)
				{
					_logger.Error(exception, "Unhandled exception while processing queued application messages.");
				}
			}
		}

		private async Task TryProcessNextQueuedApplicationMessageAsync(CancellationToken cancellationToken)
		{
			_ = 5;
			try
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return;
				}
				AsyncQueueDequeueResult<MqttEnqueuedApplicationMessage> asyncQueueDequeueResult = await _messageQueue.TryDequeueAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (!asyncQueueDequeueResult.IsSuccess)
				{
					return;
				}
				MqttEnqueuedApplicationMessage item = asyncQueueDequeueResult.Item;
				MqttClientConnection sender = item.Sender;
				MqttApplicationMessage applicationMessage = item.ApplicationMessage;
				MqttApplicationMessageInterceptorContext interceptorContext = await InterceptApplicationMessageAsync(sender, applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				if (interceptorContext != null)
				{
					if (interceptorContext.CloseConnection && sender != null)
					{
						await sender.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					if (interceptorContext.ApplicationMessage == null || !interceptorContext.AcceptPublish)
					{
						return;
					}
					applicationMessage = interceptorContext.ApplicationMessage;
				}
				await _eventDispatcher.SafeNotifyApplicationMessageReceivedAsync(sender?.ClientId, applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				if (applicationMessage.Retain)
				{
					await _retainedMessagesManager.HandleMessageAsync(sender?.ClientId, applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
				int num = 0;
				foreach (MqttClientSession value in _sessions.Values)
				{
					if (value.EnqueueApplicationMessage(applicationMessage, sender?.ClientId, isRetainedApplicationMessage: false))
					{
						num++;
					}
				}
				if (num == 0)
				{
					IMqttServerApplicationMessageInterceptor undeliveredMessageInterceptor = _options.UndeliveredMessageInterceptor;
					if (undeliveredMessageInterceptor != null)
					{
						await undeliveredMessageInterceptor.InterceptApplicationMessagePublishAsync(new MqttApplicationMessageInterceptorContext(sender?.ClientId, sender?.Session?.Items, applicationMessage));
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unhandled exception while processing next queued application message.");
			}
		}

		private async Task HandleClientConnectionAsync(IMqttChannelAdapter channelAdapter, CancellationToken cancellationToken)
		{
			string clientId = null;
			try
			{
				MqttConnectPacket connectPacket;
				try
				{
					connectPacket = (await channelAdapter.ReceivePacketAsync(_options.DefaultCommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) as MqttConnectPacket;
					if (connectPacket == null)
					{
						_logger.Warning(null, "The first packet from client '{0}' was no 'CONNECT' packet [MQTT-3.1.0-1].", channelAdapter.Endpoint);
						return;
					}
				}
				catch (MqttCommunicationTimedOutException)
				{
					_logger.Warning(null, "Client '{0}' connected but did not sent a CONNECT packet.", channelAdapter.Endpoint);
					return;
				}
				MqttConnectionValidatorContext connectionValidatorContext = await ValidateConnectionAsync(connectPacket, channelAdapter).ConfigureAwait(continueOnCapturedContext: false);
				if (connectionValidatorContext.ReasonCode != MqttConnectReasonCode.Success)
				{
					MqttConnAckPacket packet = channelAdapter.PacketFormatterAdapter.DataConverter.CreateConnAckPacket(connectionValidatorContext);
					await channelAdapter.SendPacketAsync(packet, _options.DefaultCommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				clientId = connectPacket.ClientId;
				await (await CreateClientConnectionAsync(connectPacket, connectionValidatorContext, channelAdapter, async delegate
				{
					await _eventDispatcher.SafeNotifyClientConnectedAsync(clientId).ConfigureAwait(continueOnCapturedContext: false);
				}, async delegate(MqttClientDisconnectType disconnectType)
				{
					await CleanUpClient(clientId, channelAdapter, disconnectType);
				}).ConfigureAwait(continueOnCapturedContext: false)).RunAsync(connectionValidatorContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex3)
			{
				_logger.Error(ex3, ex3.Message);
			}
		}

		private async Task CleanUpClient(string clientId, IMqttChannelAdapter channelAdapter, MqttClientDisconnectType disconnectType)
		{
			if (clientId != null)
			{
				_connections.TryRemove(clientId, out var _);
				if (!_options.EnablePersistentSessions)
				{
					await DeleteSessionAsync(clientId).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			await SafeCleanupChannelAsync(channelAdapter).ConfigureAwait(continueOnCapturedContext: false);
			if (clientId != null)
			{
				await _eventDispatcher.SafeNotifyClientDisconnectedAsync(clientId, disconnectType).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private async Task<MqttConnectionValidatorContext> ValidateConnectionAsync(MqttConnectPacket connectPacket, IMqttChannelAdapter channelAdapter)
		{
			MqttConnectionValidatorContext context = new MqttConnectionValidatorContext(connectPacket, channelAdapter, new ConcurrentDictionary<object, object>());
			IMqttServerConnectionValidator connectionValidator = _options.ConnectionValidator;
			if (connectionValidator == null)
			{
				context.ReasonCode = MqttConnectReasonCode.Success;
				return context;
			}
			await connectionValidator.ValidateConnectionAsync(context).ConfigureAwait(continueOnCapturedContext: false);
			if (string.IsNullOrEmpty(connectPacket.ClientId) && channelAdapter.PacketFormatterAdapter.ProtocolVersion == MqttProtocolVersion.V500)
			{
				connectPacket.ClientId = context.AssignedClientIdentifier;
			}
			if (string.IsNullOrEmpty(connectPacket.ClientId))
			{
				context.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
			}
			return context;
		}

		private async Task<MqttClientConnection> CreateClientConnectionAsync(MqttConnectPacket connectPacket, MqttConnectionValidatorContext connectionValidatorContext, IMqttChannelAdapter channelAdapter, Func<Task> onStart, Func<MqttClientDisconnectType, Task> onStop)
		{
			using (await _createConnectionGate.WaitAsync(_cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				MqttClientSession session;
				bool isSessionPresent = _sessions.TryGetValue(connectPacket.ClientId, out session);
				if (_connections.TryGetValue(connectPacket.ClientId, out var value))
				{
					await value.StopAsync(isTakeover: true).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (isSessionPresent)
				{
					if (connectPacket.CleanSession)
					{
						session = null;
						_logger.Verbose("Deleting existing session of client '{0}'.", connectPacket.ClientId);
					}
					else
					{
						_logger.Verbose("Reusing existing session of client '{0}'.", connectPacket.ClientId);
					}
				}
				if (session == null)
				{
					session = new MqttClientSession(connectPacket.ClientId, connectionValidatorContext.SessionItems, _eventDispatcher, _options, _retainedMessagesManager, _rootLogger);
					_logger.Verbose("Created a new session for client '{0}'.", connectPacket.ClientId);
				}
				MqttClientConnection mqttClientConnection = new MqttClientConnection(connectPacket, channelAdapter, session, _options, this, _retainedMessagesManager, onStart, onStop, _rootLogger);
				_connections[mqttClientConnection.ClientId] = mqttClientConnection;
				_sessions[session.ClientId] = session;
				return mqttClientConnection;
			}
		}

		private async Task<MqttApplicationMessageInterceptorContext> InterceptApplicationMessageAsync(MqttClientConnection senderConnection, MqttApplicationMessage applicationMessage)
		{
			IMqttServerApplicationMessageInterceptor applicationMessageInterceptor = _options.ApplicationMessageInterceptor;
			if (applicationMessageInterceptor == null)
			{
				return null;
			}
			string clientId;
			IDictionary<object, object> sessionItems;
			if (senderConnection == null)
			{
				clientId = _options.ClientId;
				sessionItems = _serverSessionItems;
			}
			else
			{
				clientId = senderConnection.ClientId;
				sessionItems = senderConnection.Session.Items;
			}
			MqttApplicationMessageInterceptorContext interceptorContext = new MqttApplicationMessageInterceptorContext(clientId, sessionItems, applicationMessage);
			await applicationMessageInterceptor.InterceptApplicationMessagePublishAsync(interceptorContext).ConfigureAwait(continueOnCapturedContext: false);
			return interceptorContext;
		}

		private async Task SafeCleanupChannelAsync(IMqttChannelAdapter channelAdapter)
		{
			try
			{
				await channelAdapter.DisconnectAsync(_options.DefaultCommunicationTimeout, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while disconnecting client channel.");
			}
		}
	}
	public class MqttClientSubscribeResult
	{
		public MqttSubAckPacket ResponsePacket { get; set; }

		public bool CloseConnection { get; set; }
	}
	public class MqttClientSubscriptionsManager
	{
		private readonly Dictionary<string, MqttTopicFilter> _subscriptions = new Dictionary<string, MqttTopicFilter>();

		private readonly MqttClientSession _clientSession;

		private readonly IMqttServerOptions _serverOptions;

		private readonly MqttServerEventDispatcher _eventDispatcher;

		public MqttClientSubscriptionsManager(MqttClientSession clientSession, MqttServerEventDispatcher eventDispatcher, IMqttServerOptions serverOptions)
		{
			_clientSession = clientSession ?? throw new ArgumentNullException("clientSession");
			_serverOptions = serverOptions ?? throw new ArgumentNullException("serverOptions");
			_eventDispatcher = eventDispatcher ?? throw new ArgumentNullException("eventDispatcher");
		}

		public async Task<MqttClientSubscribeResult> SubscribeAsync(MqttSubscribePacket subscribePacket, MqttConnectPacket connectPacket)
		{
			if (subscribePacket == null)
			{
				throw new ArgumentNullException("subscribePacket");
			}
			if (connectPacket == null)
			{
				throw new ArgumentNullException("connectPacket");
			}
			MqttClientSubscribeResult result = new MqttClientSubscribeResult
			{
				ResponsePacket = new MqttSubAckPacket
				{
					PacketIdentifier = subscribePacket.PacketIdentifier
				},
				CloseConnection = false
			};
			foreach (MqttTopicFilter topicFilter2 in subscribePacket.TopicFilters)
			{
				MqttSubscriptionInterceptorContext mqttSubscriptionInterceptorContext = await InterceptSubscribeAsync(topicFilter2).ConfigureAwait(continueOnCapturedContext: false);
				MqttTopicFilter topicFilter = mqttSubscriptionInterceptorContext.TopicFilter;
				if (topicFilter == null || string.IsNullOrEmpty(topicFilter.Topic) || !mqttSubscriptionInterceptorContext.AcceptSubscription)
				{
					result.ResponsePacket.ReturnCodes.Add(MqttSubscribeReturnCode.Failure);
					result.ResponsePacket.ReasonCodes.Add(MqttSubscribeReasonCode.UnspecifiedError);
				}
				else
				{
					result.ResponsePacket.ReturnCodes.Add(ConvertToSubscribeReturnCode(topicFilter.QualityOfServiceLevel));
					result.ResponsePacket.ReasonCodes.Add(ConvertToSubscribeReasonCode(topicFilter.QualityOfServiceLevel));
				}
				if (mqttSubscriptionInterceptorContext.CloseConnection)
				{
					result.CloseConnection = true;
				}
				if (mqttSubscriptionInterceptorContext.AcceptSubscription && !string.IsNullOrEmpty(topicFilter?.Topic))
				{
					lock (_subscriptions)
					{
						_subscriptions[topicFilter.Topic] = topicFilter;
					}
					await _eventDispatcher.SafeNotifyClientSubscribedTopicAsync(_clientSession.ClientId, topicFilter).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			return result;
		}

		public async Task SubscribeAsync(IEnumerable<MqttTopicFilter> topicFilters)
		{
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			foreach (MqttTopicFilter topicFilter in topicFilters)
			{
				MqttSubscriptionInterceptorContext mqttSubscriptionInterceptorContext = await InterceptSubscribeAsync(topicFilter).ConfigureAwait(continueOnCapturedContext: false);
				if (mqttSubscriptionInterceptorContext.AcceptSubscription && mqttSubscriptionInterceptorContext.AcceptSubscription)
				{
					lock (_subscriptions)
					{
						_subscriptions[topicFilter.Topic] = topicFilter;
					}
					await _eventDispatcher.SafeNotifyClientSubscribedTopicAsync(_clientSession.ClientId, topicFilter).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		public async Task<MqttUnsubAckPacket> UnsubscribeAsync(MqttUnsubscribePacket unsubscribePacket)
		{
			if (unsubscribePacket == null)
			{
				throw new ArgumentNullException("unsubscribePacket");
			}
			MqttUnsubAckPacket unsubAckPacket = new MqttUnsubAckPacket
			{
				PacketIdentifier = unsubscribePacket.PacketIdentifier
			};
			foreach (string topicFilter in unsubscribePacket.TopicFilters)
			{
				if (!(await InterceptUnsubscribeAsync(topicFilter).ConfigureAwait(continueOnCapturedContext: false)).AcceptUnsubscription)
				{
					unsubAckPacket.ReasonCodes.Add(MqttUnsubscribeReasonCode.ImplementationSpecificError);
					continue;
				}
				lock (_subscriptions)
				{
					if (_subscriptions.Remove(topicFilter))
					{
						unsubAckPacket.ReasonCodes.Add(MqttUnsubscribeReasonCode.Success);
					}
					else
					{
						unsubAckPacket.ReasonCodes.Add(MqttUnsubscribeReasonCode.NoSubscriptionExisted);
					}
				}
			}
			foreach (string topicFilter2 in unsubscribePacket.TopicFilters)
			{
				await _eventDispatcher.SafeNotifyClientUnsubscribedTopicAsync(_clientSession.ClientId, topicFilter2).ConfigureAwait(continueOnCapturedContext: false);
			}
			return unsubAckPacket;
		}

		public async Task UnsubscribeAsync(IEnumerable<string> topicFilters)
		{
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			foreach (string topicFilter in topicFilters)
			{
				if ((await InterceptUnsubscribeAsync(topicFilter).ConfigureAwait(continueOnCapturedContext: false)).AcceptUnsubscription)
				{
					lock (_subscriptions)
					{
						_subscriptions.Remove(topicFilter);
					}
				}
			}
		}

		public CheckSubscriptionsResult CheckSubscriptions(string topic, MqttQualityOfServiceLevel qosLevel)
		{
			HashSet<MqttQualityOfServiceLevel> hashSet = new HashSet<MqttQualityOfServiceLevel>();
			lock (_subscriptions)
			{
				foreach (KeyValuePair<string, MqttTopicFilter> subscription in _subscriptions)
				{
					if (MqttTopicFilterComparer.IsMatch(topic, subscription.Key))
					{
						hashSet.Add(subscription.Value.QualityOfServiceLevel);
					}
				}
			}
			if (hashSet.Count == 0)
			{
				return new CheckSubscriptionsResult
				{
					IsSubscribed = false
				};
			}
			return CreateSubscriptionResult(qosLevel, hashSet);
		}

		private static MqttSubscribeReturnCode ConvertToSubscribeReturnCode(MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			return qualityOfServiceLevel switch
			{
				MqttQualityOfServiceLevel.AtMostOnce => MqttSubscribeReturnCode.SuccessMaximumQoS0, 
				MqttQualityOfServiceLevel.AtLeastOnce => MqttSubscribeReturnCode.SuccessMaximumQoS1, 
				MqttQualityOfServiceLevel.ExactlyOnce => MqttSubscribeReturnCode.SuccessMaximumQoS2, 
				_ => MqttSubscribeReturnCode.Failure, 
			};
		}

		private static MqttSubscribeReasonCode ConvertToSubscribeReasonCode(MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			return qualityOfServiceLevel switch
			{
				MqttQualityOfServiceLevel.AtMostOnce => MqttSubscribeReasonCode.GrantedQoS0, 
				MqttQualityOfServiceLevel.AtLeastOnce => MqttSubscribeReasonCode.GrantedQoS1, 
				MqttQualityOfServiceLevel.ExactlyOnce => MqttSubscribeReasonCode.GrantedQoS2, 
				_ => MqttSubscribeReasonCode.UnspecifiedError, 
			};
		}

		private async Task<MqttSubscriptionInterceptorContext> InterceptSubscribeAsync(MqttTopicFilter topicFilter)
		{
			MqttSubscriptionInterceptorContext context = new MqttSubscriptionInterceptorContext(_clientSession.ClientId, topicFilter, _clientSession.Items);
			if (_serverOptions.SubscriptionInterceptor != null)
			{
				await _serverOptions.SubscriptionInterceptor.InterceptSubscriptionAsync(context).ConfigureAwait(continueOnCapturedContext: false);
			}
			return context;
		}

		private async Task<MqttUnsubscriptionInterceptorContext> InterceptUnsubscribeAsync(string topicFilter)
		{
			MqttUnsubscriptionInterceptorContext context = new MqttUnsubscriptionInterceptorContext(_clientSession.ClientId, topicFilter, _clientSession.Items);
			if (_serverOptions.UnsubscriptionInterceptor != null)
			{
				await _serverOptions.UnsubscriptionInterceptor.InterceptUnsubscriptionAsync(context).ConfigureAwait(continueOnCapturedContext: false);
			}
			return context;
		}

		private static CheckSubscriptionsResult CreateSubscriptionResult(MqttQualityOfServiceLevel qosLevel, HashSet<MqttQualityOfServiceLevel> subscribedQoSLevels)
		{
			MqttQualityOfServiceLevel qualityOfServiceLevel = (subscribedQoSLevels.Contains(qosLevel) ? qosLevel : ((subscribedQoSLevels.Count != 1) ? subscribedQoSLevels.Max() : subscribedQoSLevels.First()));
			return new CheckSubscriptionsResult
			{
				IsSubscribed = true,
				QualityOfServiceLevel = qualityOfServiceLevel
			};
		}
	}
	public class MqttConnectionValidatorContext
	{
		private readonly MqttConnectPacket _connectPacket;

		private readonly IMqttChannelAdapter _clientAdapter;

		public string ClientId => _connectPacket.ClientId;

		public string Endpoint => _clientAdapter.Endpoint;

		public bool IsSecureConnection => _clientAdapter.IsSecureConnection;

		public X509Certificate2 ClientCertificate => _clientAdapter.ClientCertificate;

		public MqttProtocolVersion ProtocolVersion => _clientAdapter.PacketFormatterAdapter.ProtocolVersion;

		public string Username => _connectPacket?.Username;

		public byte[] RawPassword => _connectPacket?.Password;

		public string Password => Encoding.UTF8.GetString(RawPassword ?? new byte[0]);

		public MqttApplicationMessage WillMessage => _connectPacket?.WillMessage;

		public bool? CleanSession => _connectPacket?.CleanSession;

		public ushort? KeepAlivePeriod => _connectPacket?.KeepAlivePeriod;

		public List<MqttUserProperty> UserProperties => _connectPacket?.Properties?.UserProperties;

		public byte[] AuthenticationData => _connectPacket?.Properties?.AuthenticationData;

		public string AuthenticationMethod => _connectPacket?.Properties?.AuthenticationMethod;

		public uint? MaximumPacketSize => _connectPacket?.Properties?.MaximumPacketSize;

		public ushort? ReceiveMaximum => _connectPacket?.Properties?.ReceiveMaximum;

		public ushort? TopicAliasMaximum => _connectPacket?.Properties?.TopicAliasMaximum;

		public bool? RequestProblemInformation => _connectPacket?.Properties?.RequestProblemInformation;

		public bool? RequestResponseInformation => _connectPacket?.Properties?.RequestResponseInformation;

		public uint? SessionExpiryInterval => _connectPacket?.Properties?.SessionExpiryInterval;

		public uint? WillDelayInterval => _connectPacket?.Properties?.WillDelayInterval;

		public IDictionary<object, object> SessionItems { get; }

		[Obsolete("Use ReasonCode instead. It is MQTTv5 only but will be converted to a valid ReturnCode.")]
		public MqttConnectReturnCode ReturnCode
		{
			get
			{
				return new MqttConnectReasonCodeConverter().ToConnectReturnCode(ReasonCode);
			}
			set
			{
				ReasonCode = new MqttConnectReasonCodeConverter().ToConnectReasonCode(value);
			}
		}

		public MqttConnectReasonCode ReasonCode { get; set; }

		public List<MqttUserProperty> ResponseUserProperties { get; set; }

		public byte[] ResponseAuthenticationData { get; set; }

		public string AssignedClientIdentifier { get; set; }

		public string ReasonString { get; set; }

		public MqttConnectionValidatorContext(MqttConnectPacket connectPacket, IMqttChannelAdapter clientAdapter, IDictionary<object, object> sessionItems)
		{
			_connectPacket = connectPacket;
			_clientAdapter = clientAdapter ?? throw new ArgumentNullException("clientAdapter");
			SessionItems = sessionItems;
		}
	}
	public class MqttEnqueuedApplicationMessage
	{
		public MqttClientConnection Sender { get; }

		public MqttApplicationMessage ApplicationMessage { get; }

		public MqttEnqueuedApplicationMessage(MqttApplicationMessage applicationMessage, MqttClientConnection sender)
		{
			Sender = sender;
			ApplicationMessage = applicationMessage;
		}
	}
	public enum MqttPendingMessagesOverflowStrategy
	{
		DropOldestQueuedMessage,
		DropNewMessage
	}
	public class MqttQueuedApplicationMessage
	{
		public MqttApplicationMessage ApplicationMessage { get; set; }

		public string SenderClientId { get; set; }

		public bool IsRetainedMessage { get; set; }

		public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

		public bool IsDuplicate { get; set; }
	}
	public class MqttRetainedMessagesManager : IMqttRetainedMessagesManager
	{
		private readonly byte[] _emptyArray = new byte[0];

		private readonly AsyncLock _messagesLock = new AsyncLock();

		private readonly Dictionary<string, MqttApplicationMessage> _messages = new Dictionary<string, MqttApplicationMessage>();

		private IMqttNetScopedLogger _logger;

		private IMqttServerOptions _options;

		public Task Start(IMqttServerOptions options, IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttRetainedMessagesManager");
			_options = options ?? throw new ArgumentNullException("options");
			return PlatformAbstractionLayer.CompletedTask;
		}

		public async Task LoadMessagesAsync()
		{
			if (_options.Storage == null)
			{
				return;
			}
			try
			{
				IList<MqttApplicationMessage> retainedMessages = await _options.Storage.LoadRetainedMessagesAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (!(retainedMessages?.Any() ?? false))
				{
					return;
				}
				using (await _messagesLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					_messages.Clear();
					foreach (MqttApplicationMessage item in retainedMessages)
					{
						_messages[item.Topic] = item;
					}
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unhandled exception while loading retained messages.");
			}
		}

		public async Task HandleMessageAsync(string clientId, MqttApplicationMessage applicationMessage)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			try
			{
				using (await _messagesLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					bool flag = false;
					if (applicationMessage.Payload == null || applicationMessage.Payload.Length == 0)
					{
						flag = _messages.Remove(applicationMessage.Topic);
						_logger.Verbose("Client '{0}' cleared retained message for topic '{1}'.", clientId, applicationMessage.Topic);
					}
					else
					{
						if (!_messages.TryGetValue(applicationMessage.Topic, out var value))
						{
							_messages[applicationMessage.Topic] = applicationMessage;
							flag = true;
						}
						else if (value.QualityOfServiceLevel != applicationMessage.QualityOfServiceLevel || !Enumerable.SequenceEqual(value.Payload, applicationMessage.Payload ?? _emptyArray))
						{
							_messages[applicationMessage.Topic] = applicationMessage;
							flag = true;
						}
						_logger.Verbose("Client '{0}' set retained message for topic '{1}'.", clientId, applicationMessage.Topic);
					}
					if (flag && _options.Storage != null)
					{
						List<MqttApplicationMessage> messages = new List<MqttApplicationMessage>(_messages.Values);
						await _options.Storage.SaveRetainedMessagesAsync(messages).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Unhandled exception while handling retained messages.");
			}
		}

		public async Task<IList<MqttApplicationMessage>> GetSubscribedMessagesAsync(ICollection<MqttTopicFilter> topicFilters)
		{
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			List<MqttApplicationMessage> matchingRetainedMessages = new List<MqttApplicationMessage>();
			List<MqttApplicationMessage> list;
			using (await _messagesLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				list = _messages.Values.ToList();
			}
			foreach (MqttApplicationMessage item in list)
			{
				foreach (MqttTopicFilter topicFilter in topicFilters)
				{
					if (MqttTopicFilterComparer.IsMatch(item.Topic, topicFilter.Topic))
					{
						matchingRetainedMessages.Add(item);
						break;
					}
				}
			}
			return matchingRetainedMessages;
		}

		public async Task<IList<MqttApplicationMessage>> GetMessagesAsync()
		{
			using (await _messagesLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				return _messages.Values.ToList();
			}
		}

		public async Task ClearMessagesAsync()
		{
			using (await _messagesLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_messages.Clear();
				if (_options.Storage != null)
				{
					await _options.Storage.SaveRetainedMessagesAsync(new List<MqttApplicationMessage>()).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}
	}
	public class MqttServer : Disposable, IMqttServer, IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
	{
		private readonly MqttServerEventDispatcher _eventDispatcher;

		private readonly ICollection<IMqttServerAdapter> _adapters;

		private readonly IMqttNetLogger _rootLogger;

		private readonly IMqttNetScopedLogger _logger;

		private MqttClientSessionsManager _clientSessionsManager;

		private IMqttRetainedMessagesManager _retainedMessagesManager;

		private CancellationTokenSource _cancellationTokenSource;

		public bool IsStarted => _cancellationTokenSource != null;

		public IMqttServerStartedHandler StartedHandler { get; set; }

		public IMqttServerStoppedHandler StoppedHandler { get; set; }

		public IMqttServerClientConnectedHandler ClientConnectedHandler
		{
			get
			{
				return _eventDispatcher.ClientConnectedHandler;
			}
			set
			{
				_eventDispatcher.ClientConnectedHandler = value;
			}
		}

		public IMqttServerClientDisconnectedHandler ClientDisconnectedHandler
		{
			get
			{
				return _eventDispatcher.ClientDisconnectedHandler;
			}
			set
			{
				_eventDispatcher.ClientDisconnectedHandler = value;
			}
		}

		public IMqttServerClientSubscribedTopicHandler ClientSubscribedTopicHandler
		{
			get
			{
				return _eventDispatcher.ClientSubscribedTopicHandler;
			}
			set
			{
				_eventDispatcher.ClientSubscribedTopicHandler = value;
			}
		}

		public IMqttServerClientUnsubscribedTopicHandler ClientUnsubscribedTopicHandler
		{
			get
			{
				return _eventDispatcher.ClientUnsubscribedTopicHandler;
			}
			set
			{
				_eventDispatcher.ClientUnsubscribedTopicHandler = value;
			}
		}

		public IMqttApplicationMessageReceivedHandler ApplicationMessageReceivedHandler
		{
			get
			{
				return _eventDispatcher.ApplicationMessageReceivedHandler;
			}
			set
			{
				_eventDispatcher.ApplicationMessageReceivedHandler = value;
			}
		}

		public IMqttServerOptions Options { get; private set; }

		public MqttServer(IEnumerable<IMqttServerAdapter> adapters, IMqttNetLogger logger)
		{
			if (adapters == null)
			{
				throw new ArgumentNullException("adapters");
			}
			_adapters = adapters.ToList();
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttServer");
			_rootLogger = logger;
			_eventDispatcher = new MqttServerEventDispatcher(logger);
		}

		public Task<IList<IMqttClientStatus>> GetClientStatusAsync()
		{
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _clientSessionsManager.GetClientStatusAsync();
		}

		public Task<IList<IMqttSessionStatus>> GetSessionStatusAsync()
		{
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _clientSessionsManager.GetSessionStatusAsync();
		}

		public Task<IList<MqttApplicationMessage>> GetRetainedApplicationMessagesAsync()
		{
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _retainedMessagesManager.GetMessagesAsync();
		}

		public Task ClearRetainedApplicationMessagesAsync()
		{
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _retainedMessagesManager?.ClearMessagesAsync() ?? PlatformAbstractionLayer.CompletedTask;
		}

		public Task SubscribeAsync(string clientId, ICollection<MqttTopicFilter> topicFilters)
		{
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _clientSessionsManager.SubscribeAsync(clientId, topicFilters);
		}

		public Task UnsubscribeAsync(string clientId, ICollection<string> topicFilters)
		{
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			ThrowIfDisposed();
			ThrowIfNotStarted();
			return _clientSessionsManager.UnsubscribeAsync(clientId, topicFilters);
		}

		public Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			ThrowIfDisposed();
			MqttTopicValidator.ThrowIfInvalid(applicationMessage.Topic);
			ThrowIfNotStarted();
			_clientSessionsManager.DispatchApplicationMessage(applicationMessage, null);
			return Task.FromResult(new MqttClientPublishResult());
		}

		public async Task StartAsync(IMqttServerOptions options)
		{
			ThrowIfDisposed();
			ThrowIfStarted();
			Options = options ?? throw new ArgumentNullException("options");
			_cancellationTokenSource = new CancellationTokenSource();
			_retainedMessagesManager = Options.RetainedMessagesManager ?? throw new MqttConfigurationException("options.RetainedMessagesManager should not be null.");
			await _retainedMessagesManager.Start(Options, _rootLogger).ConfigureAwait(continueOnCapturedContext: false);
			await _retainedMessagesManager.LoadMessagesAsync().ConfigureAwait(continueOnCapturedContext: false);
			_clientSessionsManager = new MqttClientSessionsManager(Options, _retainedMessagesManager, _cancellationTokenSource.Token, _eventDispatcher, _rootLogger);
			_clientSessionsManager.Start();
			foreach (IMqttServerAdapter adapter in _adapters)
			{
				adapter.ClientHandler = OnHandleClient;
				await adapter.StartAsync(Options).ConfigureAwait(continueOnCapturedContext: false);
			}
			_logger.Info("Started.");
			IMqttServerStartedHandler startedHandler = StartedHandler;
			if (startedHandler != null)
			{
				await startedHandler.HandleServerStartedAsync(EventArgs.Empty).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public async Task StopAsync()
		{
			try
			{
				if (_cancellationTokenSource == null)
				{
					return;
				}
				await _clientSessionsManager.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
				_cancellationTokenSource.Cancel(throwOnFirstException: false);
				foreach (IMqttServerAdapter adapter in _adapters)
				{
					adapter.ClientHandler = null;
					await adapter.StopAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				_logger.Info("Stopped.");
			}
			finally
			{
				_clientSessionsManager?.Dispose();
				_clientSessionsManager = null;
				_cancellationTokenSource?.Dispose();
				_cancellationTokenSource = null;
				_retainedMessagesManager = null;
			}
			IMqttServerStoppedHandler stoppedHandler = StoppedHandler;
			if (stoppedHandler != null)
			{
				await stoppedHandler.HandleServerStoppedAsync(EventArgs.Empty).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				StopAsync().GetAwaiter().GetResult();
				foreach (IMqttServerAdapter adapter in _adapters)
				{
					adapter.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private Task OnHandleClient(IMqttChannelAdapter channelAdapter)
		{
			return _clientSessionsManager.HandleClientConnectionAsync(channelAdapter);
		}

		private void ThrowIfStarted()
		{
			if (_cancellationTokenSource != null)
			{
				throw new InvalidOperationException("The MQTT server is already started.");
			}
		}

		private void ThrowIfNotStarted()
		{
			if (_cancellationTokenSource == null)
			{
				throw new InvalidOperationException("The MQTT server is not started.");
			}
		}
	}
	public class MqttServerApplicationMessageInterceptorDelegate : IMqttServerApplicationMessageInterceptor
	{
		private readonly Func<MqttApplicationMessageInterceptorContext, Task> _callback;

		public MqttServerApplicationMessageInterceptorDelegate(Action<MqttApplicationMessageInterceptorContext> callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			_callback = delegate(MqttApplicationMessageInterceptorContext context)
			{
				callback(context);
				return Task.FromResult(0);
			};
		}

		public MqttServerApplicationMessageInterceptorDelegate(Func<MqttApplicationMessageInterceptorContext, Task> callback)
		{
			_callback = callback ?? throw new ArgumentNullException("callback");
		}

		public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
		{
			return _callback(context);
		}
	}
	public class MqttServerCertificateCredentials : IMqttServerCertificateCredentials
	{
		public string Password { get; set; }
	}
	public class MqttServerClientConnectedEventArgs : EventArgs
	{
		public string ClientId { get; }

		public MqttServerClientConnectedEventArgs(string clientId)
		{
			ClientId = clientId ?? throw new ArgumentNullException("clientId");
		}
	}
	public class MqttServerClientConnectedHandlerDelegate : IMqttServerClientConnectedHandler
	{
		private readonly Func<MqttServerClientConnectedEventArgs, Task> _handler;

		public MqttServerClientConnectedHandlerDelegate(Action<MqttServerClientConnectedEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttServerClientConnectedEventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerClientConnectedHandlerDelegate(Func<MqttServerClientConnectedEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerClientDisconnectedEventArgs : EventArgs
	{
		public string ClientId { get; }

		public MqttClientDisconnectType DisconnectType { get; }

		public MqttServerClientDisconnectedEventArgs(string clientId, MqttClientDisconnectType disconnectType)
		{
			ClientId = clientId ?? throw new ArgumentNullException("clientId");
			DisconnectType = disconnectType;
		}
	}
	public class MqttServerClientDisconnectedHandlerDelegate : IMqttServerClientDisconnectedHandler
	{
		private readonly Func<MqttServerClientDisconnectedEventArgs, Task> _handler;

		public MqttServerClientDisconnectedHandlerDelegate(Action<MqttServerClientDisconnectedEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttServerClientDisconnectedEventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerClientDisconnectedHandlerDelegate(Func<MqttServerClientDisconnectedEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerClientSubscribedTopicEventArgs : EventArgs
	{
		public string ClientId { get; }

		public MqttTopicFilter TopicFilter { get; }

		public MqttServerClientSubscribedTopicEventArgs(string clientId, MqttTopicFilter topicFilter)
		{
			ClientId = clientId ?? throw new ArgumentNullException("clientId");
			TopicFilter = topicFilter ?? throw new ArgumentNullException("topicFilter");
		}
	}
	public class MqttServerClientSubscribedHandlerDelegate : IMqttServerClientSubscribedTopicHandler
	{
		private readonly Func<MqttServerClientSubscribedTopicEventArgs, Task> _handler;

		public MqttServerClientSubscribedHandlerDelegate(Action<MqttServerClientSubscribedTopicEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttServerClientSubscribedTopicEventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerClientSubscribedHandlerDelegate(Func<MqttServerClientSubscribedTopicEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerClientUnsubscribedTopicEventArgs : EventArgs
	{
		public string ClientId { get; }

		public string TopicFilter { get; }

		public MqttServerClientUnsubscribedTopicEventArgs(string clientId, string topicFilter)
		{
			ClientId = clientId ?? throw new ArgumentNullException("clientId");
			TopicFilter = topicFilter ?? throw new ArgumentNullException("topicFilter");
		}
	}
	public class MqttServerClientUnsubscribedTopicHandlerDelegate : IMqttServerClientUnsubscribedTopicHandler
	{
		private readonly Func<MqttServerClientUnsubscribedTopicEventArgs, Task> _handler;

		public MqttServerClientUnsubscribedTopicHandlerDelegate(Action<MqttServerClientUnsubscribedTopicEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerClientUnsubscribedTopicHandlerDelegate(Func<MqttServerClientUnsubscribedTopicEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerConnectionValidatorDelegate : IMqttServerConnectionValidator
	{
		private readonly Func<MqttConnectionValidatorContext, Task> _callback;

		public MqttServerConnectionValidatorDelegate(Action<MqttConnectionValidatorContext> callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			_callback = delegate(MqttConnectionValidatorContext context)
			{
				callback(context);
				return Task.FromResult(0);
			};
		}

		public MqttServerConnectionValidatorDelegate(Func<MqttConnectionValidatorContext, Task> callback)
		{
			_callback = callback ?? throw new ArgumentNullException("callback");
		}

		public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
		{
			return _callback(context);
		}
	}
	public sealed class MqttServerEventDispatcher
	{
		private readonly IMqttNetScopedLogger _logger;

		public IMqttServerClientConnectedHandler ClientConnectedHandler { get; set; }

		public IMqttServerClientDisconnectedHandler ClientDisconnectedHandler { get; set; }

		public IMqttServerClientSubscribedTopicHandler ClientSubscribedTopicHandler { get; set; }

		public IMqttServerClientUnsubscribedTopicHandler ClientUnsubscribedTopicHandler { get; set; }

		public IMqttApplicationMessageReceivedHandler ApplicationMessageReceivedHandler { get; set; }

		public MqttServerEventDispatcher(IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger.CreateScopedLogger("MqttServerEventDispatcher");
		}

		public async Task SafeNotifyClientConnectedAsync(string clientId)
		{
			try
			{
				IMqttServerClientConnectedHandler clientConnectedHandler = ClientConnectedHandler;
				if (clientConnectedHandler != null)
				{
					await clientConnectedHandler.HandleClientConnectedAsync(new MqttServerClientConnectedEventArgs(clientId)).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while handling custom 'ClientConnected' event.");
			}
		}

		public async Task SafeNotifyClientDisconnectedAsync(string clientId, MqttClientDisconnectType disconnectType)
		{
			try
			{
				IMqttServerClientDisconnectedHandler clientDisconnectedHandler = ClientDisconnectedHandler;
				if (clientDisconnectedHandler != null)
				{
					await clientDisconnectedHandler.HandleClientDisconnectedAsync(new MqttServerClientDisconnectedEventArgs(clientId, disconnectType)).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while handling custom 'ClientDisconnected' event.");
			}
		}

		public async Task SafeNotifyClientSubscribedTopicAsync(string clientId, MqttTopicFilter topicFilter)
		{
			try
			{
				IMqttServerClientSubscribedTopicHandler clientSubscribedTopicHandler = ClientSubscribedTopicHandler;
				if (clientSubscribedTopicHandler != null)
				{
					await clientSubscribedTopicHandler.HandleClientSubscribedTopicAsync(new MqttServerClientSubscribedTopicEventArgs(clientId, topicFilter)).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while handling custom 'ClientSubscribedTopic' event.");
			}
		}

		public async Task SafeNotifyClientUnsubscribedTopicAsync(string clientId, string topicFilter)
		{
			try
			{
				IMqttServerClientUnsubscribedTopicHandler clientUnsubscribedTopicHandler = ClientUnsubscribedTopicHandler;
				if (clientUnsubscribedTopicHandler != null)
				{
					await clientUnsubscribedTopicHandler.HandleClientUnsubscribedTopicAsync(new MqttServerClientUnsubscribedTopicEventArgs(clientId, topicFilter)).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while handling custom 'ClientUnsubscribedTopic' event.");
			}
		}

		public async Task SafeNotifyApplicationMessageReceivedAsync(string senderClientId, MqttApplicationMessage applicationMessage)
		{
			try
			{
				IMqttApplicationMessageReceivedHandler applicationMessageReceivedHandler = ApplicationMessageReceivedHandler;
				if (applicationMessageReceivedHandler != null)
				{
					await applicationMessageReceivedHandler.HandleApplicationMessageReceivedAsync(new MqttApplicationMessageReceivedEventArgs(senderClientId, applicationMessage)).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while handling custom 'ApplicationMessageReceived' event.");
			}
		}
	}
	public static class MqttServerExtensions
	{
		public static IMqttServer UseClientConnectedHandler(this IMqttServer server, Func<MqttServerClientConnectedEventArgs, Task> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseClientConnectedHandler((IMqttServerClientConnectedHandler)null);
			}
			return server.UseClientConnectedHandler(new MqttServerClientConnectedHandlerDelegate(handler));
		}

		public static IMqttServer UseClientConnectedHandler(this IMqttServer server, Action<MqttServerClientConnectedEventArgs> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseClientConnectedHandler((IMqttServerClientConnectedHandler)null);
			}
			return server.UseClientConnectedHandler(new MqttServerClientConnectedHandlerDelegate(handler));
		}

		public static IMqttServer UseClientConnectedHandler(this IMqttServer server, IMqttServerClientConnectedHandler handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			server.ClientConnectedHandler = handler;
			return server;
		}

		public static IMqttServer UseClientDisconnectedHandler(this IMqttServer server, Func<MqttServerClientDisconnectedEventArgs, Task> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseClientDisconnectedHandler((IMqttServerClientDisconnectedHandler)null);
			}
			return server.UseClientDisconnectedHandler(new MqttServerClientDisconnectedHandlerDelegate(handler));
		}

		public static IMqttServer UseClientDisconnectedHandler(this IMqttServer server, Action<MqttServerClientDisconnectedEventArgs> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseClientDisconnectedHandler((IMqttServerClientDisconnectedHandler)null);
			}
			return server.UseClientDisconnectedHandler(new MqttServerClientDisconnectedHandlerDelegate(handler));
		}

		public static IMqttServer UseClientDisconnectedHandler(this IMqttServer server, IMqttServerClientDisconnectedHandler handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			server.ClientDisconnectedHandler = handler;
			return server;
		}

		public static IMqttServer UseApplicationMessageReceivedHandler(this IMqttServer server, Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
			}
			return server.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
		}

		public static IMqttServer UseApplicationMessageReceivedHandler(this IMqttServer server, Action<MqttApplicationMessageReceivedEventArgs> handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (handler == null)
			{
				return server.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
			}
			return server.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
		}

		public static IMqttServer UseApplicationMessageReceivedHandler(this IMqttServer server, IMqttApplicationMessageReceivedHandler handler)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			server.ApplicationMessageReceivedHandler = handler;
			return server;
		}

		public static Task SubscribeAsync(this IMqttServer server, string clientId, params MqttTopicFilter[] topicFilters)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			return server.SubscribeAsync(clientId, topicFilters);
		}

		public static Task SubscribeAsync(this IMqttServer server, string clientId, string topic, MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.SubscribeAsync(clientId, new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel(qualityOfServiceLevel).Build());
		}

		public static Task SubscribeAsync(this IMqttServer server, string clientId, string topic)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.SubscribeAsync(clientId, new MqttTopicFilterBuilder().WithTopic(topic).Build());
		}

		public static Task UnsubscribeAsync(this IMqttServer server, string clientId, params string[] topicFilters)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (clientId == null)
			{
				throw new ArgumentNullException("clientId");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			return server.UnsubscribeAsync(clientId, topicFilters);
		}

		public static async Task PublishAsync(this IMqttServer server, IEnumerable<MqttApplicationMessage> applicationMessages)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (applicationMessages == null)
			{
				throw new ArgumentNullException("applicationMessages");
			}
			foreach (MqttApplicationMessage applicationMessage in applicationMessages)
			{
				await server.PublishAsync(applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, MqttApplicationMessage applicationMessage)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			return server.PublishAsync(applicationMessage, CancellationToken.None);
		}

		public static async Task PublishAsync(this IMqttServer server, params MqttApplicationMessage[] applicationMessages)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (applicationMessages == null)
			{
				throw new ArgumentNullException("applicationMessages");
			}
			foreach (MqttApplicationMessage applicationMessage in applicationMessages)
			{
				await server.PublishAsync(applicationMessage, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, string topic)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic));
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, string topic, string payload)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload));
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel));
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel, bool retain)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return server.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel)
				.WithRetainFlag(retain));
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, Func<MqttApplicationMessageBuilder, MqttApplicationMessageBuilder> builder, CancellationToken cancellationToken)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			MqttApplicationMessage applicationMessage = builder(new MqttApplicationMessageBuilder()).Build();
			return server.PublishAsync(applicationMessage, cancellationToken);
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttServer server, Func<MqttApplicationMessageBuilder, MqttApplicationMessageBuilder> builder)
		{
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}
			MqttApplicationMessage applicationMessage = builder(new MqttApplicationMessageBuilder()).Build();
			return server.PublishAsync(applicationMessage, CancellationToken.None);
		}
	}
	public class MqttServerOptions : IMqttServerOptions
	{
		public MqttServerTcpEndpointOptions DefaultEndpointOptions { get; } = new MqttServerTcpEndpointOptions();

		public MqttServerTlsTcpEndpointOptions TlsEndpointOptions { get; } = new MqttServerTlsTcpEndpointOptions();

		public string ClientId { get; set; }

		public bool EnablePersistentSessions { get; set; }

		public int MaxPendingMessagesPerClient { get; set; } = 250;

		public MqttPendingMessagesOverflowStrategy PendingMessagesOverflowStrategy { get; set; }

		public TimeSpan DefaultCommunicationTimeout { get; set; } = TimeSpan.FromSeconds(15.0);

		public IMqttServerConnectionValidator ConnectionValidator { get; set; }

		public IMqttServerApplicationMessageInterceptor ApplicationMessageInterceptor { get; set; }

		public IMqttServerClientMessageQueueInterceptor ClientMessageQueueInterceptor { get; set; }

		public IMqttServerSubscriptionInterceptor SubscriptionInterceptor { get; set; }

		public IMqttServerUnsubscriptionInterceptor UnsubscriptionInterceptor { get; set; }

		public IMqttServerStorage Storage { get; set; }

		public IMqttRetainedMessagesManager RetainedMessagesManager { get; set; } = new MqttRetainedMessagesManager();

		public IMqttServerApplicationMessageInterceptor UndeliveredMessageInterceptor { get; set; }
	}
	public class MqttServerOptionsBuilder
	{
		private readonly MqttServerOptions _options = new MqttServerOptions();

		public MqttServerOptionsBuilder WithConnectionBacklog(int value)
		{
			_options.DefaultEndpointOptions.ConnectionBacklog = value;
			_options.TlsEndpointOptions.ConnectionBacklog = value;
			return this;
		}

		public MqttServerOptionsBuilder WithMaxPendingMessagesPerClient(int value)
		{
			_options.MaxPendingMessagesPerClient = value;
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultCommunicationTimeout(TimeSpan value)
		{
			_options.DefaultCommunicationTimeout = value;
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultEndpoint()
		{
			_options.DefaultEndpointOptions.IsEnabled = true;
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultEndpointPort(int value)
		{
			_options.DefaultEndpointOptions.Port = value;
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultEndpointBoundIPAddress(IPAddress value)
		{
			_options.DefaultEndpointOptions.BoundInterNetworkAddress = value ?? IPAddress.Any;
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultEndpointBoundIPV6Address(IPAddress value)
		{
			_options.DefaultEndpointOptions.BoundInterNetworkV6Address = value ?? IPAddress.Any;
			return this;
		}

		public MqttServerOptionsBuilder WithoutDefaultEndpoint()
		{
			_options.DefaultEndpointOptions.IsEnabled = false;
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptedEndpoint()
		{
			_options.TlsEndpointOptions.IsEnabled = true;
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptedEndpointPort(int value)
		{
			_options.TlsEndpointOptions.Port = value;
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptedEndpointBoundIPAddress(IPAddress value)
		{
			_options.TlsEndpointOptions.BoundInterNetworkAddress = value;
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptedEndpointBoundIPV6Address(IPAddress value)
		{
			_options.TlsEndpointOptions.BoundInterNetworkV6Address = value;
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptionCertificate(byte[] value, IMqttServerCertificateCredentials credentials = null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_options.TlsEndpointOptions.CertificateProvider = new BlobCertificateProvider(value)
			{
				Password = credentials?.Password
			};
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptionCertificate(X509Certificate2 certificate)
		{
			if (certificate == null)
			{
				throw new ArgumentNullException("certificate");
			}
			_options.TlsEndpointOptions.CertificateProvider = new X509CertificateProvider(certificate);
			return this;
		}

		public MqttServerOptionsBuilder WithEncryptionSslProtocol(SslProtocols value)
		{
			_options.TlsEndpointOptions.SslProtocol = value;
			return this;
		}

		public MqttServerOptionsBuilder WithClientCertificate(RemoteCertificateValidationCallback validationCallback = null, bool checkCertificateRevocation = false)
		{
			_options.TlsEndpointOptions.ClientCertificateRequired = true;
			_options.TlsEndpointOptions.CheckCertificateRevocation = checkCertificateRevocation;
			_options.TlsEndpointOptions.RemoteCertificateValidationCallback = validationCallback;
			return this;
		}

		public MqttServerOptionsBuilder WithoutEncryptedEndpoint()
		{
			_options.TlsEndpointOptions.IsEnabled = false;
			return this;
		}

		public MqttServerOptionsBuilder WithRemoteCertificateValidationCallback(RemoteCertificateValidationCallback value)
		{
			_options.TlsEndpointOptions.RemoteCertificateValidationCallback = value;
			return this;
		}

		public MqttServerOptionsBuilder WithStorage(IMqttServerStorage value)
		{
			_options.Storage = value;
			return this;
		}

		public MqttServerOptionsBuilder WithRetainedMessagesManager(IMqttRetainedMessagesManager value)
		{
			_options.RetainedMessagesManager = value;
			return this;
		}

		public MqttServerOptionsBuilder WithConnectionValidator(IMqttServerConnectionValidator value)
		{
			_options.ConnectionValidator = value;
			return this;
		}

		public MqttServerOptionsBuilder WithConnectionValidator(Action<MqttConnectionValidatorContext> value)
		{
			_options.ConnectionValidator = new MqttServerConnectionValidatorDelegate(value);
			return this;
		}

		public MqttServerOptionsBuilder WithApplicationMessageInterceptor(IMqttServerApplicationMessageInterceptor value)
		{
			_options.ApplicationMessageInterceptor = value;
			return this;
		}

		public MqttServerOptionsBuilder WithApplicationMessageInterceptor(Action<MqttApplicationMessageInterceptorContext> value)
		{
			_options.ApplicationMessageInterceptor = new MqttServerApplicationMessageInterceptorDelegate(value);
			return this;
		}

		public MqttServerOptionsBuilder WithSubscriptionInterceptor(IMqttServerSubscriptionInterceptor value)
		{
			_options.SubscriptionInterceptor = value;
			return this;
		}

		public MqttServerOptionsBuilder WithUnsubscriptionInterceptor(IMqttServerUnsubscriptionInterceptor value)
		{
			_options.UnsubscriptionInterceptor = value;
			return this;
		}

		public MqttServerOptionsBuilder WithSubscriptionInterceptor(Action<MqttSubscriptionInterceptorContext> value)
		{
			_options.SubscriptionInterceptor = new MqttServerSubscriptionInterceptorDelegate(value);
			return this;
		}

		public MqttServerOptionsBuilder WithDefaultEndpointReuseAddress()
		{
			_options.DefaultEndpointOptions.ReuseAddress = true;
			return this;
		}

		public MqttServerOptionsBuilder WithTlsEndpointReuseAddress()
		{
			_options.TlsEndpointOptions.ReuseAddress = true;
			return this;
		}

		public MqttServerOptionsBuilder WithPersistentSessions()
		{
			_options.EnablePersistentSessions = true;
			return this;
		}

		public MqttServerOptionsBuilder WithClientId(string value)
		{
			_options.ClientId = value;
			return this;
		}

		public IMqttServerOptions Build()
		{
			return _options;
		}

		public MqttServerOptionsBuilder WithUndeliveredMessageInterceptor(Action<MqttApplicationMessageInterceptorContext> value)
		{
			_options.UndeliveredMessageInterceptor = new MqttServerApplicationMessageInterceptorDelegate(value);
			return this;
		}
	}
	public class MqttServerStartedHandlerDelegate : IMqttServerStartedHandler
	{
		private readonly Func<EventArgs, Task> _handler;

		public MqttServerStartedHandlerDelegate(Action<EventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(EventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerStartedHandlerDelegate(Func<EventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleServerStartedAsync(EventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerStoppedHandlerDelegate : IMqttServerStoppedHandler
	{
		private readonly Func<EventArgs, Task> _handler;

		public MqttServerStoppedHandlerDelegate(Action<EventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(EventArgs eventArgs)
			{
				handler(eventArgs);
				return Task.FromResult(0);
			};
		}

		public MqttServerStoppedHandlerDelegate(Func<EventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleServerStoppedAsync(EventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttServerSubscriptionInterceptorDelegate : IMqttServerSubscriptionInterceptor
	{
		private readonly Func<MqttSubscriptionInterceptorContext, Task> _callback;

		public MqttServerSubscriptionInterceptorDelegate(Action<MqttSubscriptionInterceptorContext> callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			_callback = delegate(MqttSubscriptionInterceptorContext context)
			{
				callback(context);
				return Task.FromResult(0);
			};
		}

		public MqttServerSubscriptionInterceptorDelegate(Func<MqttSubscriptionInterceptorContext, Task> callback)
		{
			_callback = callback ?? throw new ArgumentNullException("callback");
		}

		public Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context)
		{
			return _callback(context);
		}
	}
	public abstract class MqttServerTcpEndpointBaseOptions
	{
		public bool IsEnabled { get; set; }

		public int Port { get; set; }

		public int ConnectionBacklog { get; set; } = 10;

		public bool NoDelay { get; set; } = true;

		public IPAddress BoundInterNetworkAddress { get; set; } = IPAddress.Any;

		public IPAddress BoundInterNetworkV6Address { get; set; } = IPAddress.IPv6Any;

		public bool ReuseAddress { get; set; }
	}
	public class MqttServerTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
	{
		public MqttServerTcpEndpointOptions()
		{
			base.IsEnabled = true;
			base.Port = 1883;
		}
	}
	public class MqttServerTlsTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
	{
		private ICertificateProvider _certificateProvider;

		[Obsolete("Please use CertificateProvider with 'BlobCertificateProvider' instead.")]
		public byte[] Certificate { get; set; }

		[Obsolete("Please use CertificateProvider with 'BlobCertificateProvider' including password property instead.")]
		public IMqttServerCertificateCredentials CertificateCredentials { get; set; }

		public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

		public ICertificateProvider CertificateProvider
		{
			get
			{
				if (_certificateProvider != null)
				{
					return _certificateProvider;
				}
				if (Certificate == null)
				{
					return null;
				}
				return new BlobCertificateProvider(Certificate)
				{
					Password = CertificateCredentials?.Password
				};
			}
			set
			{
				_certificateProvider = value;
			}
		}

		public bool ClientCertificateRequired { get; set; }

		public bool CheckCertificateRevocation { get; set; }

		public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12;

		public MqttServerTlsTcpEndpointOptions()
		{
			base.Port = 8883;
		}
	}
	public class MqttSubscriptionInterceptorContext
	{
		public string ClientId { get; }

		public MqttTopicFilter TopicFilter { get; set; }

		public IDictionary<object, object> SessionItems { get; }

		public bool AcceptSubscription { get; set; } = true;

		public bool CloseConnection { get; set; }

		public MqttSubscriptionInterceptorContext(string clientId, MqttTopicFilter topicFilter, IDictionary<object, object> sessionItems)
		{
			ClientId = clientId;
			TopicFilter = topicFilter;
			SessionItems = sessionItems;
		}
	}
	public static class MqttTopicFilterComparer
	{
		private const char LevelSeparator = '/';

		private const char MultiLevelWildcard = '#';

		private const char SingleLevelWildcard = '+';

		public static bool IsMatch(string topic, string filter)
		{
			if (string.IsNullOrEmpty(topic))
			{
				throw new ArgumentNullException("topic");
			}
			if (string.IsNullOrEmpty(filter))
			{
				throw new ArgumentNullException("filter");
			}
			int num = 0;
			int length = filter.Length;
			int i = 0;
			int length2 = topic.Length;
			while (num < length && i < length2)
			{
				if (filter[num] == topic[i])
				{
					if (i == length2 - 1 && num == length - 3 && filter[num + 1] == '/' && filter[num + 2] == '#')
					{
						return true;
					}
					num++;
					i++;
					if (num == length && i == length2)
					{
						return true;
					}
					if (i == length2 && num == length - 1 && filter[num] == '+')
					{
						if (num > 0 && filter[num - 1] != '/')
						{
							return false;
						}
						return true;
					}
					continue;
				}
				if (filter[num] == '+')
				{
					if (num > 0 && filter[num - 1] != '/')
					{
						return false;
					}
					if (num < length - 1 && filter[num + 1] != '/')
					{
						return false;
					}
					num++;
					for (; i < length2 && topic[i] != '/'; i++)
					{
					}
					if (i == length2 && num == length)
					{
						return true;
					}
					continue;
				}
				if (filter[num] == '#')
				{
					if (num > 0 && filter[num - 1] != '/')
					{
						return false;
					}
					if (num + 1 != length)
					{
						return false;
					}
					return true;
				}
				if (num > 0 && num + 2 == length && i == length2 && filter[num - 1] == '+' && filter[num] == '/' && filter[num + 1] == '#')
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}
	public class MqttUnsubscriptionInterceptorContext
	{
		public string ClientId { get; }

		public string Topic { get; set; }

		public IDictionary<object, object> SessionItems { get; }

		public bool AcceptUnsubscription { get; set; } = true;

		public bool CloseConnection { get; set; }

		public MqttUnsubscriptionInterceptorContext(string clientId, string topic, IDictionary<object, object> sessionItems)
		{
			ClientId = clientId;
			Topic = topic;
			SessionItems = sessionItems;
		}
	}
	public class PrepareClientSessionResult
	{
		public bool IsExistingSession { get; set; }

		public MqttClientConnection Session { get; set; }
	}
}
namespace MQTTnet.Server.Status
{
	public interface IMqttClientStatus
	{
		string ClientId { get; }

		string Endpoint { get; }

		MqttProtocolVersion ProtocolVersion { get; }

		DateTime LastPacketReceivedTimestamp { get; }

		DateTime LastNonKeepAlivePacketReceivedTimestamp { get; }

		long ReceivedApplicationMessagesCount { get; }

		long SentApplicationMessagesCount { get; }

		long ReceivedPacketsCount { get; }

		long SentPacketsCount { get; }

		IMqttSessionStatus Session { get; }

		long BytesSent { get; }

		long BytesReceived { get; }

		Task DisconnectAsync();

		void ResetStatistics();
	}
	public interface IMqttSessionStatus
	{
		string ClientId { get; }

		long PendingApplicationMessagesCount { get; }

		IDictionary<object, object> Items { get; }

		Task ClearPendingApplicationMessagesAsync();

		Task DeleteAsync();
	}
	public class MqttClientStatus : IMqttClientStatus
	{
		private readonly MqttClientConnection _connection;

		public string ClientId { get; set; }

		public string Endpoint { get; set; }

		public MqttProtocolVersion ProtocolVersion { get; set; }

		public DateTime LastPacketReceivedTimestamp { get; set; }

		public DateTime ConnectedTimestamp { get; set; }

		public DateTime LastNonKeepAlivePacketReceivedTimestamp { get; set; }

		public long ReceivedApplicationMessagesCount { get; set; }

		public long SentApplicationMessagesCount { get; set; }

		public long ReceivedPacketsCount { get; set; }

		public long SentPacketsCount { get; set; }

		public IMqttSessionStatus Session { get; set; }

		public long BytesSent { get; set; }

		public long BytesReceived { get; set; }

		public MqttClientStatus(MqttClientConnection connection)
		{
			_connection = connection ?? throw new ArgumentNullException("connection");
		}

		public Task DisconnectAsync()
		{
			return _connection.StopAsync();
		}

		public void ResetStatistics()
		{
			_connection.ResetStatistics();
		}
	}
	public class MqttSessionStatus : IMqttSessionStatus
	{
		private readonly MqttClientSession _session;

		private readonly MqttClientSessionsManager _sessionsManager;

		public string ClientId { get; set; }

		public long PendingApplicationMessagesCount { get; set; }

		public DateTime CreatedTimestamp { get; set; }

		public IDictionary<object, object> Items { get; set; }

		public MqttSessionStatus(MqttClientSession session, MqttClientSessionsManager sessionsManager)
		{
			_session = session ?? throw new ArgumentNullException("session");
			_sessionsManager = sessionsManager ?? throw new ArgumentNullException("sessionsManager");
		}

		public Task DeleteAsync()
		{
			return _sessionsManager.DeleteSessionAsync(ClientId);
		}

		public Task ClearPendingApplicationMessagesAsync()
		{
			_session.ApplicationMessagesQueue.Clear();
			return Task.FromResult(0);
		}
	}
}
namespace MQTTnet.Protocol
{
	public enum MqttAuthenticateReasonCode
	{
		Success = 0,
		ContinueAuthentication = 24,
		ReAuthenticate = 25
	}
	public enum MqttConnectReasonCode
	{
		Success = 0,
		UnspecifiedError = 128,
		MalformedPacket = 129,
		ProtocolError = 130,
		ImplementationSpecificError = 131,
		UnsupportedProtocolVersion = 132,
		ClientIdentifierNotValid = 133,
		BadUserNameOrPassword = 134,
		NotAuthorized = 135,
		ServerUnavailable = 136,
		ServerBusy = 137,
		Banned = 138,
		BadAuthenticationMethod = 140,
		TopicNameInvalid = 144,
		PacketTooLarge = 149,
		QuotaExceeded = 151,
		PayloadFormatInvalid = 153,
		RetainNotSupported = 154,
		QoSNotSupported = 155,
		UseAnotherServer = 156,
		ServerMoved = 157,
		ConnectionRateExceeded = 159
	}
	public class MqttConnectReasonCodeConverter
	{
		public MqttConnectReturnCode ToConnectReturnCode(MqttConnectReasonCode reasonCode)
		{
			switch (reasonCode)
			{
			case MqttConnectReasonCode.Success:
				return MqttConnectReturnCode.ConnectionAccepted;
			case MqttConnectReasonCode.NotAuthorized:
				return MqttConnectReturnCode.ConnectionRefusedNotAuthorized;
			case MqttConnectReasonCode.BadUserNameOrPassword:
				return MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
			case MqttConnectReasonCode.ClientIdentifierNotValid:
				return MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
			case MqttConnectReasonCode.UnsupportedProtocolVersion:
				return MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion;
			case MqttConnectReasonCode.ServerUnavailable:
			case MqttConnectReasonCode.ServerBusy:
			case MqttConnectReasonCode.ServerMoved:
				return MqttConnectReturnCode.ConnectionRefusedServerUnavailable;
			default:
				throw new MqttProtocolViolationException("Unable to convert connect reason code (MQTTv5) to return code (MQTTv3).");
			}
		}

		public MqttConnectReasonCode ToConnectReasonCode(MqttConnectReturnCode returnCode)
		{
			return returnCode switch
			{
				MqttConnectReturnCode.ConnectionAccepted => MqttConnectReasonCode.Success, 
				MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion => MqttConnectReasonCode.UnsupportedProtocolVersion, 
				MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword => MqttConnectReasonCode.BadUserNameOrPassword, 
				MqttConnectReturnCode.ConnectionRefusedIdentifierRejected => MqttConnectReasonCode.ClientIdentifierNotValid, 
				MqttConnectReturnCode.ConnectionRefusedServerUnavailable => MqttConnectReasonCode.ServerUnavailable, 
				MqttConnectReturnCode.ConnectionRefusedNotAuthorized => MqttConnectReasonCode.NotAuthorized, 
				_ => throw new MqttProtocolViolationException("Unable to convert connect reason code (MQTTv5) to return code (MQTTv3)."), 
			};
		}
	}
	public enum MqttConnectReturnCode
	{
		ConnectionAccepted,
		ConnectionRefusedUnacceptableProtocolVersion,
		ConnectionRefusedIdentifierRejected,
		ConnectionRefusedServerUnavailable,
		ConnectionRefusedBadUsernameOrPassword,
		ConnectionRefusedNotAuthorized
	}
	public enum MqttControlPacketType
	{
		Connect = 1,
		ConnAck,
		Publish,
		PubAck,
		PubRec,
		PubRel,
		PubComp,
		Subscribe,
		SubAck,
		Unsubscibe,
		UnsubAck,
		PingReq,
		PingResp,
		Disconnect,
		Auth
	}
	public enum MqttDisconnectReasonCode
	{
		NormalDisconnection = 0,
		DisconnectWithWillMessage = 4,
		UnspecifiedError = 128,
		MalformedPacket = 129,
		ProtocolError = 130,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		ServerBusy = 137,
		ServerShuttingDown = 139,
		KeepAliveTimeout = 141,
		SessionTakenOver = 142,
		TopicFilterInvalid = 143,
		TopicNameInvalid = 144,
		ReceiveMaximumExceeded = 147,
		TopicAliasInvalid = 148,
		PacketTooLarge = 149,
		MessageRateTooHigh = 150,
		QuotaExceeded = 151,
		AdministrativeAction = 152,
		PayloadFormatInvalid = 153,
		RetainNotSupported = 154,
		QoSNotSupported = 155,
		UseAnotherServer = 156,
		ServerMoved = 157,
		SharedSubscriptionsNotSupported = 158,
		ConnectionRateExceeded = 159,
		MaximumConnectTime = 160,
		SubscriptionIdentifiersNotSupported = 161,
		WildcardSubscriptionsNotSupported = 162
	}
	public enum MqttPayloadFormatIndicator
	{
		Unspecified,
		CharacterData
	}
	public enum MqttPropertyId
	{
		PayloadFormatIndicator = 1,
		MessageExpiryInterval = 2,
		ContentType = 3,
		ResponseTopic = 8,
		CorrelationData = 9,
		SubscriptionIdentifier = 11,
		SessionExpiryInterval = 17,
		AssignedClientIdentifier = 18,
		ServerKeepAlive = 19,
		AuthenticationMethod = 21,
		AuthenticationData = 22,
		RequestProblemInformation = 23,
		WillDelayInterval = 24,
		RequestResponseInformation = 25,
		ResponseInformation = 26,
		ServerReference = 28,
		ReasonString = 31,
		ReceiveMaximum = 33,
		TopicAliasMaximum = 34,
		TopicAlias = 35,
		MaximumQoS = 36,
		RetainAvailable = 37,
		UserProperty = 38,
		MaximumPacketSize = 39,
		WildcardSubscriptionAvailable = 40,
		SubscriptionIdentifiersAvailable = 41,
		SharedSubscriptionAvailable = 42
	}
	public enum MqttPubAckReasonCode
	{
		Success = 0,
		NoMatchingSubscribers = 16,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicNameInvalid = 144,
		PacketIdentifierInUse = 145,
		QuotaExceeded = 151,
		PayloadFormatInvalid = 153
	}
	public enum MqttPubCompReasonCode
	{
		Success = 0,
		PacketIdentifierNotFound = 146
	}
	public enum MqttPubRecReasonCode
	{
		Success = 0,
		NoMatchingSubscribers = 16,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicNameInvalid = 144,
		PacketIdentifierInUse = 145,
		QuotaExceeded = 151,
		PayloadFormatInvalid = 153
	}
	public enum MqttPubRelReasonCode
	{
		Success = 0,
		PacketIdentifierNotFound = 146
	}
	public enum MqttQualityOfServiceLevel
	{
		AtMostOnce,
		AtLeastOnce,
		ExactlyOnce
	}
	public enum MqttRetainHandling
	{
		SendAtSubscribe,
		SendAtSubscribeIfNewSubscriptionOnly,
		DoNotSendOnSubscribe
	}
	public enum MqttSubscribeReasonCode
	{
		GrantedQoS0 = 0,
		GrantedQoS1 = 1,
		GrantedQoS2 = 2,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicFilterInvalid = 143,
		PacketIdentifierInUse = 145,
		QuotaExceeded = 151,
		SharedSubscriptionsNotSupported = 158,
		SubscriptionIdentifiersNotSupported = 161,
		WildcardSubscriptionsNotSupported = 162
	}
	public enum MqttSubscribeReturnCode
	{
		SuccessMaximumQoS0 = 0,
		SuccessMaximumQoS1 = 1,
		SuccessMaximumQoS2 = 2,
		Failure = 0x80
	}
	public static class MqttTopicValidator
	{
		public static void ThrowIfInvalid(string topic)
		{
			if (string.IsNullOrEmpty(topic))
			{
				throw new MqttProtocolViolationException("Topic should not be empty.");
			}
			for (int i = 0; i < topic.Length; i++)
			{
				switch (topic[i])
				{
				case '+':
					throw new MqttProtocolViolationException("The character '+' is not allowed in topics.");
				case '#':
					throw new MqttProtocolViolationException("The character '#' is not allowed in topics.");
				}
			}
		}
	}
	public enum MqttUnsubscribeReasonCode
	{
		Success = 0,
		NoSubscriptionExisted = 17,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicFilterInvalid = 143,
		PacketIdentifierInUse = 145
	}
}
namespace MQTTnet.Packets
{
	public interface IMqttPacketWithIdentifier
	{
		ushort? PacketIdentifier { get; set; }
	}
	public class MqttAuthPacket : MqttBasePacket
	{
		public MqttAuthenticateReasonCode ReasonCode { get; set; }

		public MqttAuthPacketProperties Properties { get; set; }
	}
	public class MqttAuthPacketProperties
	{
		public string AuthenticationMethod { get; set; }

		public byte[] AuthenticationData { get; set; }

		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public abstract class MqttBasePacket
	{
	}
	public class MqttBasePublishPacket : MqttBasePacket, IMqttPacketWithIdentifier
	{
		public ushort? PacketIdentifier { get; set; }
	}
	public class MqttConnAckPacket : MqttBasePacket
	{
		public MqttConnectReturnCode? ReturnCode { get; set; }

		public bool IsSessionPresent { get; set; }

		public MqttConnectReasonCode? ReasonCode { get; set; }

		public MqttConnAckPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("ConnAck: [ReturnCode=", ReturnCode, "] [ReasonCode=", ReasonCode, "] [IsSessionPresent=", IsSessionPresent, "]");
		}
	}
	public class MqttConnAckPacketProperties
	{
		public uint? SessionExpiryInterval { get; set; }

		public ushort? ReceiveMaximum { get; set; }

		public bool? RetainAvailable { get; set; }

		public uint? MaximumPacketSize { get; set; }

		public string AssignedClientIdentifier { get; set; }

		public ushort? TopicAliasMaximum { get; set; }

		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }

		public bool? WildcardSubscriptionAvailable { get; set; }

		public bool? SubscriptionIdentifiersAvailable { get; set; }

		public bool? SharedSubscriptionAvailable { get; set; }

		public ushort? ServerKeepAlive { get; set; }

		public string ResponseInformation { get; set; }

		public string ServerReference { get; set; }

		public string AuthenticationMethod { get; set; }

		public byte[] AuthenticationData { get; set; }
	}
	public class MqttConnectPacket : MqttBasePacket
	{
		public string ClientId { get; set; }

		public string Username { get; set; }

		public byte[] Password { get; set; }

		public ushort KeepAlivePeriod { get; set; }

		public bool CleanSession { get; set; }

		public MqttApplicationMessage WillMessage { get; set; }

		public MqttConnectPacketProperties Properties { get; set; }

		public override string ToString()
		{
			string text = string.Empty;
			if (Password != null)
			{
				text = "****";
			}
			return "Connect: [ClientId=" + ClientId + "] [Username=" + Username + "] [Password=" + text + "] [KeepAlivePeriod=" + KeepAlivePeriod + "] [CleanSession=" + CleanSession + "]";
		}
	}
	public class MqttConnectPacketProperties
	{
		public uint? WillDelayInterval { get; set; }

		public uint? SessionExpiryInterval { get; set; }

		public string AuthenticationMethod { get; set; }

		public byte[] AuthenticationData { get; set; }

		public bool? RequestProblemInformation { get; set; }

		public bool? RequestResponseInformation { get; set; }

		public ushort? ReceiveMaximum { get; set; }

		public ushort? TopicAliasMaximum { get; set; }

		public uint? MaximumPacketSize { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttDisconnectPacket : MqttBasePacket
	{
		public MqttDisconnectReasonCode? ReasonCode { get; set; }

		public MqttDisconnectPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("Disconnect: [ReasonCode=", ReasonCode, "]");
		}
	}
	public class MqttDisconnectPacketProperties
	{
		public uint? SessionExpiryInterval { get; set; }

		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }

		public string ServerReference { get; set; }
	}
	public class MqttPingReqPacket : MqttBasePacket
	{
		public override string ToString()
		{
			return "PingReq";
		}
	}
	public class MqttPingRespPacket : MqttBasePacket
	{
		public override string ToString()
		{
			return "PingResp";
		}
	}
	public class MqttPubAckPacket : MqttBasePublishPacket
	{
		public MqttPubAckReasonCode? ReasonCode { get; set; }

		public MqttPubAckPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("PubAck: [PacketIdentifier=", base.PacketIdentifier, "] [ReasonCode=", ReasonCode, "]");
		}
	}
	public class MqttPubAckPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttPubCompPacket : MqttBasePublishPacket
	{
		public MqttPubCompReasonCode? ReasonCode { get; set; }

		public MqttPubCompPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("PubComp: [PacketIdentifier=", base.PacketIdentifier, "] [ReasonCode=", ReasonCode, "]");
		}
	}
	public class MqttPubCompPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttPublishPacket : MqttBasePublishPacket
	{
		public bool Retain { get; set; }

		public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

		public bool Dup { get; set; }

		public string Topic { get; set; }

		public byte[] Payload { get; set; }

		public MqttPublishPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("Publish: [Topic=", Topic, "] [Payload.Length=", Payload?.Length, "] [QoSLevel=", QualityOfServiceLevel, "] [Dup=", Dup, "] [Retain=", Retain, "] [PacketIdentifier=", base.PacketIdentifier, "]");
		}
	}
	public class MqttPublishPacketProperties
	{
		public MqttPayloadFormatIndicator? PayloadFormatIndicator { get; set; }

		public uint? MessageExpiryInterval { get; set; }

		public ushort? TopicAlias { get; set; }

		public string ResponseTopic { get; set; }

		public byte[] CorrelationData { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }

		public List<uint> SubscriptionIdentifiers { get; set; }

		public string ContentType { get; set; }
	}
	public class MqttPubRecPacket : MqttBasePublishPacket
	{
		public MqttPubRecReasonCode? ReasonCode { get; set; }

		public MqttPubRecPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("PubRec: [PacketIdentifier=", base.PacketIdentifier, "] [ReasonCode=", ReasonCode, "]");
		}
	}
	public class MqttPubRecPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttPubRelPacket : MqttBasePublishPacket
	{
		public MqttPubRelReasonCode? ReasonCode { get; set; }

		public MqttPubRelPacketProperties Properties { get; set; }

		public override string ToString()
		{
			return string.Concat("PubRel: [PacketIdentifier=", base.PacketIdentifier, "] [ReasonCode=", ReasonCode, "]");
		}
	}
	public class MqttPubRelPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttSubAckPacket : MqttBasePacket, IMqttPacketWithIdentifier
	{
		public ushort? PacketIdentifier { get; set; }

		public List<MqttSubscribeReturnCode> ReturnCodes { get; set; } = new List<MqttSubscribeReturnCode>();

		public List<MqttSubscribeReasonCode> ReasonCodes { get; } = new List<MqttSubscribeReasonCode>();

		public MqttSubAckPacketProperties Properties { get; set; }

		public override string ToString()
		{
			string text = string.Join(",", ReturnCodes.Select((MqttSubscribeReturnCode f) => f.ToString()));
			string text2 = string.Join(",", ReasonCodes.Select((MqttSubscribeReasonCode f) => f.ToString()));
			return "SubAck: [PacketIdentifier=" + PacketIdentifier + "] [ReturnCodes=" + text + "] [ReasonCode=" + text2 + "]";
		}
	}
	public class MqttSubAckPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttSubscribePacket : MqttBasePacket, IMqttPacketWithIdentifier
	{
		public ushort? PacketIdentifier { get; set; }

		public List<MqttTopicFilter> TopicFilters { get; set; } = new List<MqttTopicFilter>();

		public MqttSubscribePacketProperties Properties { get; set; }

		public override string ToString()
		{
			string text = string.Join(",", TopicFilters.Select((MqttTopicFilter f) => f.Topic + "@" + f.QualityOfServiceLevel));
			return "Subscribe: [PacketIdentifier=" + PacketIdentifier + "] [TopicFilters=" + text + "]";
		}
	}
	public class MqttSubscribePacketProperties
	{
		public uint? SubscriptionIdentifier { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttUnsubAckPacket : MqttBasePacket, IMqttPacketWithIdentifier
	{
		public ushort? PacketIdentifier { get; set; }

		public MqttUnsubAckPacketProperties Properties { get; set; }

		public List<MqttUnsubscribeReasonCode> ReasonCodes { get; set; } = new List<MqttUnsubscribeReasonCode>();

		public override string ToString()
		{
			string text = string.Join(",", ReasonCodes.Select((MqttUnsubscribeReasonCode f) => f.ToString()));
			return "UnsubAck: [PacketIdentifier=" + PacketIdentifier + "] [ReasonCodes=" + text + "]";
		}
	}
	public class MqttUnsubAckPacketProperties
	{
		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttUnsubscribePacket : MqttBasePacket, IMqttPacketWithIdentifier
	{
		public ushort? PacketIdentifier { get; set; }

		public List<string> TopicFilters { get; set; } = new List<string>();

		public MqttUnsubscribePacketProperties Properties { get; set; }

		public override string ToString()
		{
			string text = string.Join(",", TopicFilters);
			return "Unsubscribe: [PacketIdentifier=" + PacketIdentifier + "] [TopicFilters=" + text + "]";
		}
	}
	public class MqttUnsubscribePacketProperties
	{
		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttUserProperty
	{
		public string Name { get; }

		public string Value { get; }

		public MqttUserProperty(string name, string value)
		{
			Name = name ?? throw new ArgumentNullException("name");
			Value = value ?? throw new ArgumentNullException("value");
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() ^ Value.GetHashCode();
		}

		public override bool Equals(object other)
		{
			return Equals(other as MqttUserProperty);
		}

		public bool Equals(MqttUserProperty other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (string.Equals(Name, other.Name, StringComparison.Ordinal))
			{
				return string.Equals(Value, other.Value, StringComparison.Ordinal);
			}
			return false;
		}
	}
}
namespace MQTTnet.PacketDispatcher
{
	public interface IMqttPacketAwaiter : IDisposable
	{
		void Complete(MqttBasePacket packet);

		void Fail(Exception exception);

		void Cancel();
	}
	public sealed class MqttPacketAwaiter<TPacket> : IMqttPacketAwaiter, IDisposable where TPacket : MqttBasePacket
	{
		private readonly TaskCompletionSource<MqttBasePacket> _taskCompletionSource;

		private readonly ushort? _packetIdentifier;

		private readonly MqttPacketDispatcher _owningPacketDispatcher;

		public MqttPacketAwaiter(ushort? packetIdentifier, MqttPacketDispatcher owningPacketDispatcher)
		{
			_packetIdentifier = packetIdentifier;
			_owningPacketDispatcher = owningPacketDispatcher ?? throw new ArgumentNullException("owningPacketDispatcher");
			_taskCompletionSource = new TaskCompletionSource<MqttBasePacket>(TaskCreationOptions.RunContinuationsAsynchronously);
		}

		public async Task<TPacket> WaitOneAsync(TimeSpan timeout)
		{
			using CancellationTokenSource timeoutToken = new CancellationTokenSource(timeout);
			timeoutToken.Token.Register(delegate
			{
				Fail(new MqttCommunicationTimedOutException());
			});
			return (TPacket)(await _taskCompletionSource.Task.ConfigureAwait(continueOnCapturedContext: false));
		}

		public void Complete(MqttBasePacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			_taskCompletionSource.TrySetResult(packet);
		}

		public void Fail(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			_taskCompletionSource.TrySetException(exception);
		}

		public void Cancel()
		{
			_taskCompletionSource.TrySetCanceled();
		}

		public void Dispose()
		{
			_owningPacketDispatcher.RemoveAwaiter<TPacket>(_packetIdentifier);
		}
	}
	public sealed class MqttPacketDispatcher
	{
		private readonly ConcurrentDictionary<Tuple<ushort, Type>, IMqttPacketAwaiter> _awaiters = new ConcurrentDictionary<Tuple<ushort, Type>, IMqttPacketAwaiter>();

		public void Dispatch(Exception exception)
		{
			foreach (KeyValuePair<Tuple<ushort, Type>, IMqttPacketAwaiter> awaiter in _awaiters)
			{
				awaiter.Value.Fail(exception);
			}
			_awaiters.Clear();
		}

		public void Dispatch(MqttBasePacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (packet is MqttDisconnectPacket disconnectPacket)
			{
				{
					foreach (KeyValuePair<Tuple<ushort, Type>, IMqttPacketAwaiter> awaiter in _awaiters)
					{
						awaiter.Value.Fail(new MqttUnexpectedDisconnectReceivedException(disconnectPacket));
					}
					return;
				}
			}
			ushort item = 0;
			if (packet is IMqttPacketWithIdentifier { PacketIdentifier: not null, PacketIdentifier: var packetIdentifier })
			{
				item = packetIdentifier.Value;
			}
			Type type = packet.GetType();
			Tuple<ushort, Type> key = new Tuple<ushort, Type>(item, type);
			if (_awaiters.TryRemove(key, out var value))
			{
				value.Complete(packet);
				return;
			}
			throw new MqttProtocolViolationException($"Received packet '{packet}' at an unexpected time.");
		}

		public void Reset()
		{
			foreach (KeyValuePair<Tuple<ushort, Type>, IMqttPacketAwaiter> awaiter in _awaiters)
			{
				awaiter.Value.Cancel();
			}
			_awaiters.Clear();
		}

		public MqttPacketAwaiter<TResponsePacket> AddAwaiter<TResponsePacket>(ushort? identifier) where TResponsePacket : MqttBasePacket
		{
			if (!identifier.HasValue)
			{
				identifier = 0;
			}
			MqttPacketAwaiter<TResponsePacket> mqttPacketAwaiter = new MqttPacketAwaiter<TResponsePacket>(identifier, this);
			Tuple<ushort, Type> tuple = new Tuple<ushort, Type>(identifier.Value, typeof(TResponsePacket));
			if (!_awaiters.TryAdd(tuple, mqttPacketAwaiter))
			{
				throw new InvalidOperationException($"The packet dispatcher already has an awaiter for packet of type '{tuple.Item2.Name}' with identifier {tuple.Item1}.");
			}
			return mqttPacketAwaiter;
		}

		public void RemoveAwaiter<TResponsePacket>(ushort? identifier) where TResponsePacket : MqttBasePacket
		{
			if (!identifier.HasValue)
			{
				identifier = 0;
			}
			Tuple<ushort, Type> key = new Tuple<ushort, Type>(identifier.Value, typeof(TResponsePacket));
			_awaiters.TryRemove(key, out var _);
		}
	}
}
namespace MQTTnet.LowLevelClient
{
	public interface ILowLevelMqttClient : IDisposable
	{
		Task ConnectAsync(IMqttClientOptions options, CancellationToken cancellationToken);

		Task DisconnectAsync(CancellationToken cancellationToken);

		Task SendAsync(MqttBasePacket packet, CancellationToken cancellationToken);

		Task<MqttBasePacket> ReceiveAsync(CancellationToken cancellationToken);
	}
	public sealed class LowLevelMqttClient : ILowLevelMqttClient, IDisposable
	{
		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttClientAdapterFactory _clientAdapterFactory;

		private IMqttChannelAdapter _adapter;

		private IMqttClientOptions _options;

		private bool IsConnected => _adapter != null;

		public LowLevelMqttClient(IMqttClientAdapterFactory clientAdapterFactory, IMqttNetLogger logger)
		{
			if (clientAdapterFactory == null)
			{
				throw new ArgumentNullException("clientAdapterFactory");
			}
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_clientAdapterFactory = clientAdapterFactory;
			_logger = logger.CreateScopedLogger("LowLevelMqttClient");
		}

		public async Task ConnectAsync(IMqttClientOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (_adapter != null)
			{
				throw new InvalidOperationException("Low level MQTT client is already connected. Disconnect first before connecting again.");
			}
			IMqttChannelAdapter newAdapter = _clientAdapterFactory.CreateClientAdapter(options);
			try
			{
				_logger.Verbose($"Trying to connect with server '{options.ChannelOptions}' (Timeout={options.CommunicationTimeout}).");
				await newAdapter.ConnectAsync(options.CommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_logger.Verbose("Connection with server established.");
				_options = options;
			}
			catch (Exception)
			{
				_adapter?.Dispose();
				throw;
			}
			_adapter = newAdapter;
		}

		public async Task DisconnectAsync(CancellationToken cancellationToken)
		{
			if (_adapter != null)
			{
				await SafeDisconnect(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_adapter = null;
			}
		}

		public async Task SendAsync(MqttBasePacket packet, CancellationToken cancellationToken)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (_adapter == null)
			{
				throw new InvalidOperationException("Low level MQTT client is not connected.");
			}
			try
			{
				await _adapter.SendPacketAsync(packet, _options.CommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				await SafeDisconnect(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				ExceptionDispatchInfo.Capture((ex as Exception) ?? throw ex).Throw();
			}
		}

		public async Task<MqttBasePacket> ReceiveAsync(CancellationToken cancellationToken)
		{
			if (_adapter == null)
			{
				throw new InvalidOperationException("Low level MQTT client is not connected.");
			}
			MqttBasePacket result = default(MqttBasePacket);
			try
			{
				result = await _adapter.ReceivePacketAsync(_options.CommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return result;
			}
			catch (Exception ex)
			{
				await SafeDisconnect(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				ExceptionDispatchInfo.Capture((ex as Exception) ?? throw ex).Throw();
			}
			return result;
		}

		public void Dispose()
		{
			_adapter?.Dispose();
		}

		private async Task SafeDisconnect(CancellationToken cancellationToken)
		{
			try
			{
				await _adapter.DisconnectAsync(_options.CommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while disconnecting.");
			}
			finally
			{
				_adapter.Dispose();
			}
		}
	}
}
namespace MQTTnet.Internal
{
	public sealed class AsyncLock : IDisposable
	{
		private class Releaser : IDisposable
		{
			private readonly AsyncLock _toRelease;

			internal Releaser(AsyncLock toRelease)
			{
				_toRelease = toRelease;
			}

			public void Dispose()
			{
				_toRelease._semaphore.Release();
			}
		}

		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		private readonly Task<IDisposable> _releaser;

		public AsyncLock()
		{
			_releaser = Task.FromResult((IDisposable)new Releaser(this));
		}

		public Task<IDisposable> WaitAsync()
		{
			return WaitAsync(CancellationToken.None);
		}

		public Task<IDisposable> WaitAsync(CancellationToken cancellationToken)
		{
			Task task = _semaphore.WaitAsync(cancellationToken);
			if (task.Status == TaskStatus.RanToCompletion)
			{
				return _releaser;
			}
			return task.ContinueWith((Task _, object state) => (IDisposable)state, _releaser.Result, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
		}

		public void Dispose()
		{
			_semaphore?.Dispose();
		}
	}
	public sealed class AsyncQueue<TItem> : IDisposable
	{
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

		private ConcurrentQueue<TItem> _queue = new ConcurrentQueue<TItem>();

		public int Count => _queue.Count;

		public void Enqueue(TItem item)
		{
			_queue.Enqueue(item);
			_semaphore.Release();
		}

		public async Task<AsyncQueueDequeueResult<TItem>> TryDequeueAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					cancellationToken.ThrowIfCancellationRequested();
				}
				catch (OperationCanceledException)
				{
					return new AsyncQueueDequeueResult<TItem>(isSuccess: false, default(TItem));
				}
				if (_queue.TryDequeue(out var result))
				{
					return new AsyncQueueDequeueResult<TItem>(isSuccess: true, result);
				}
			}
			return new AsyncQueueDequeueResult<TItem>(isSuccess: false, default(TItem));
		}

		public AsyncQueueDequeueResult<TItem> TryDequeue()
		{
			if (_queue.TryDequeue(out var result))
			{
				return new AsyncQueueDequeueResult<TItem>(isSuccess: true, result);
			}
			return new AsyncQueueDequeueResult<TItem>(isSuccess: false, default(TItem));
		}

		public void Clear()
		{
			Interlocked.Exchange(ref _queue, new ConcurrentQueue<TItem>());
		}

		public void Dispose()
		{
			_semaphore?.Dispose();
		}
	}
	public class AsyncQueueDequeueResult<TItem>
	{
		public bool IsSuccess { get; }

		public TItem Item { get; }

		public AsyncQueueDequeueResult(bool isSuccess, TItem item)
		{
			IsSuccess = isSuccess;
			Item = item;
		}
	}
	public sealed class BlockingQueue<TItem> : IDisposable
	{
		private readonly object _syncRoot = new object();

		private readonly LinkedList<TItem> _items = new LinkedList<TItem>();

		private ManualResetEventSlim _gate = new ManualResetEventSlim(initialState: false);

		public int Count
		{
			get
			{
				lock (_syncRoot)
				{
					return _items.Count;
				}
			}
		}

		public void Enqueue(TItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			lock (_syncRoot)
			{
				_items.AddLast(item);
				_gate?.Set();
			}
		}

		public TItem Dequeue(CancellationToken cancellationToken = default(CancellationToken))
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				lock (_syncRoot)
				{
					if (_items.Count > 0)
					{
						TItem value = _items.First.Value;
						_items.RemoveFirst();
						return value;
					}
					if (_items.Count == 0)
					{
						_gate?.Reset();
					}
				}
				_gate?.Wait(cancellationToken);
			}
			throw new OperationCanceledException();
		}

		public TItem PeekAndWait(CancellationToken cancellationToken = default(CancellationToken))
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				lock (_syncRoot)
				{
					if (_items.Count > 0)
					{
						return _items.First.Value;
					}
					if (_items.Count == 0)
					{
						_gate?.Reset();
					}
				}
				_gate?.Wait(cancellationToken);
			}
			throw new OperationCanceledException();
		}

		public void RemoveFirst(Predicate<TItem> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
			lock (_syncRoot)
			{
				if (_items.Count > 0 && match(_items.First.Value))
				{
					_items.RemoveFirst();
				}
			}
		}

		public TItem RemoveFirst()
		{
			lock (_syncRoot)
			{
				LinkedListNode<TItem> first = _items.First;
				_items.RemoveFirst();
				return first.Value;
			}
		}

		public void Clear()
		{
			lock (_syncRoot)
			{
				_items.Clear();
			}
		}

		public void Dispose()
		{
			_gate?.Dispose();
			_gate = null;
		}
	}
	public abstract class Disposable : IDisposable
	{
		protected bool IsDisposed { get; private set; }

		protected void ThrowIfDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}
	}
	public static class MqttTaskTimeout
	{
		public static async Task WaitAsync(Func<CancellationToken, Task> action, TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			using CancellationTokenSource timeoutCts = new CancellationTokenSource(timeout);
			using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken);
			try
			{
				await action(linkedCts.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException innerException)
			{
				if (timeoutCts.IsCancellationRequested && !cancellationToken.IsCancellationRequested)
				{
					throw new MqttCommunicationTimedOutException(innerException);
				}
				throw;
			}
		}

		public static async Task<TResult> WaitAsync<TResult>(Func<CancellationToken, Task<TResult>> action, TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			using CancellationTokenSource timeoutCts = new CancellationTokenSource(timeout);
			using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken);
			try
			{
				return await action(linkedCts.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException innerException)
			{
				if (timeoutCts.IsCancellationRequested && !cancellationToken.IsCancellationRequested)
				{
					throw new MqttCommunicationTimedOutException(innerException);
				}
				throw;
			}
		}
	}
	public static class TaskExtensions
	{
		public static void Forget(this Task task, IMqttNetScopedLogger logger)
		{
			task?.ContinueWith(delegate(Task t)
			{
				logger.Error(t.Exception, "Unhandled exception.");
			}, TaskContinuationOptions.OnlyOnFaulted);
		}
	}
	public class TestMqttChannel : IMqttChannel, IDisposable
	{
		private readonly MemoryStream _stream;

		public string Endpoint { get; } = "<Test channel>";

		public bool IsSecureConnection { get; }

		public X509Certificate2 ClientCertificate { get; }

		public TestMqttChannel(MemoryStream stream)
		{
			_stream = stream;
		}

		public Task ConnectAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(0);
		}

		public Task DisconnectAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(0);
		}

		public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return _stream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return _stream.WriteAsync(buffer, offset, count, cancellationToken);
		}

		public void Dispose()
		{
		}
	}
}
namespace MQTTnet.Implementations
{
	public sealed class CrossPlatformSocket : IDisposable
	{
		private readonly Socket _socket;

		private NetworkStream _networkStream;

		public bool NoDelay
		{
			get
			{
				return (int)_socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug) > 0;
			}
			set
			{
				_socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, value ? 1 : 0);
			}
		}

		public bool DualMode
		{
			get
			{
				return _socket.DualMode;
			}
			set
			{
				_socket.DualMode = value;
			}
		}

		public int ReceiveBufferSize
		{
			get
			{
				return _socket.ReceiveBufferSize;
			}
			set
			{
				_socket.ReceiveBufferSize = value;
			}
		}

		public int SendBufferSize
		{
			get
			{
				return _socket.SendBufferSize;
			}
			set
			{
				_socket.SendBufferSize = value;
			}
		}

		public EndPoint RemoteEndPoint => _socket.RemoteEndPoint;

		public bool ReuseAddress
		{
			get
			{
				return (int)_socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress) != 0;
			}
			set
			{
				_socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, value ? 1 : 0);
			}
		}

		public CrossPlatformSocket(AddressFamily addressFamily)
		{
			_socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
		}

		public CrossPlatformSocket()
		{
			_socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
		}

		public CrossPlatformSocket(Socket socket)
		{
			_socket = socket ?? throw new ArgumentNullException("socket");
			_networkStream = new NetworkStream(socket, ownsSocket: true);
		}

		public async Task<CrossPlatformSocket> AcceptAsync()
		{
			try
			{
				return new CrossPlatformSocket(await _socket.AcceptAsync().ConfigureAwait(continueOnCapturedContext: false));
			}
			catch (ObjectDisposedException)
			{
				return null;
			}
		}

		public void Bind(EndPoint localEndPoint)
		{
			if (localEndPoint == null)
			{
				throw new ArgumentNullException("localEndPoint");
			}
			_socket.Bind(localEndPoint);
		}

		public void Listen(int connectionBacklog)
		{
			_socket.Listen(connectionBacklog);
		}

		public async Task ConnectAsync(string host, int port, CancellationToken cancellationToken)
		{
			if (host == null)
			{
				throw new ArgumentNullException("host");
			}
			try
			{
				_networkStream?.Dispose();
				using (cancellationToken.Register(delegate
				{
					_socket.Dispose();
				}))
				{
					cancellationToken.ThrowIfCancellationRequested();
					await _socket.ConnectAsync(host, port).ConfigureAwait(continueOnCapturedContext: false);
					_networkStream = new NetworkStream(_socket, ownsSocket: true);
				}
			}
			catch (ObjectDisposedException)
			{
			}
		}

		public async Task SendAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
		{
			try
			{
				await _socket.SendAsync(buffer, socketFlags).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (ObjectDisposedException)
			{
			}
		}

		public async Task<int> ReceiveAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
		{
			try
			{
				return await _socket.ReceiveAsync(buffer, socketFlags).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (ObjectDisposedException)
			{
				return -1;
			}
		}

		public NetworkStream GetStream()
		{
			return _networkStream ?? throw new IOException("The socket is not connected.");
		}

		public void Dispose()
		{
			_networkStream?.Dispose();
			_socket?.Dispose();
		}
	}
	public class MqttClientAdapterFactory : IMqttClientAdapterFactory
	{
		private readonly IMqttNetLogger _logger;

		public MqttClientAdapterFactory(IMqttNetLogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException("logger");
		}

		public IMqttChannelAdapter CreateClientAdapter(IMqttClientOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			IMqttClientChannelOptions channelOptions = options.ChannelOptions;
			if (!(channelOptions is MqttClientTcpOptions))
			{
				if (channelOptions is MqttClientWebSocketOptions options2)
				{
					return new MqttChannelAdapter(new MqttWebSocketChannel(options2), new MqttPacketFormatterAdapter(options.ProtocolVersion, new MqttPacketWriter()), _logger);
				}
				throw new NotSupportedException();
			}
			return new MqttChannelAdapter(new MqttTcpChannel(options), new MqttPacketFormatterAdapter(options.ProtocolVersion, new MqttPacketWriter()), _logger);
		}
	}
	public sealed class MqttTcpChannel : IMqttChannel, IDisposable
	{
		private readonly IMqttClientOptions _clientOptions;

		private readonly MqttClientTcpOptions _options;

		private Stream _stream;

		public string Endpoint { get; private set; }

		public bool IsSecureConnection { get; }

		public X509Certificate2 ClientCertificate { get; }

		public MqttTcpChannel(IMqttClientOptions clientOptions)
		{
			_clientOptions = clientOptions ?? throw new ArgumentNullException("clientOptions");
			_options = (MqttClientTcpOptions)clientOptions.ChannelOptions;
			IMqttClientChannelOptions channelOptions = clientOptions.ChannelOptions;
			IsSecureConnection = channelOptions != null && channelOptions.TlsOptions?.UseTls == true;
		}

		public MqttTcpChannel(Stream stream, string endpoint, X509Certificate2 clientCertificate)
		{
			_stream = stream ?? throw new ArgumentNullException("stream");
			Endpoint = endpoint;
			IsSecureConnection = stream is SslStream;
			ClientCertificate = clientCertificate;
		}

		public async Task ConnectAsync(CancellationToken cancellationToken)
		{
			CrossPlatformSocket socket = null;
			try
			{
				socket = ((_options.AddressFamily != AddressFamily.Unspecified) ? new CrossPlatformSocket(_options.AddressFamily) : new CrossPlatformSocket());
				socket.ReceiveBufferSize = _options.BufferSize;
				socket.SendBufferSize = _options.BufferSize;
				socket.NoDelay = _options.NoDelay;
				if (_options.DualMode.HasValue)
				{
					socket.DualMode = _options.DualMode.Value;
				}
				await socket.ConnectAsync(_options.Server, _options.GetPort(), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				cancellationToken.ThrowIfCancellationRequested();
				NetworkStream stream = socket.GetStream();
				if (_options.TlsOptions?.UseTls ?? false)
				{
					SslStream sslStream = new SslStream(stream, leaveInnerStreamOpen: false, InternalUserCertificateValidationCallback);
					try
					{
						await sslStream.AuthenticateAsClientAsync(_options.Server, LoadCertificates(), _options.TlsOptions.SslProtocol, !_options.TlsOptions.IgnoreCertificateRevocationErrors).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (object obj)
					{
						await sslStream.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
						ExceptionDispatchInfo.Capture((obj as Exception) ?? throw obj).Throw();
					}
					_stream = sslStream;
				}
				else
				{
					_stream = stream;
				}
				Endpoint = socket.RemoteEndPoint?.ToString();
			}
			catch (Exception)
			{
				socket?.Dispose();
				throw;
			}
		}

		public Task DisconnectAsync(CancellationToken cancellationToken)
		{
			Dispose();
			return Task.FromResult(0);
		}

		public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			cancellationToken.ThrowIfCancellationRequested();
			try
			{
				using (cancellationToken.Register(Dispose))
				{
					return await (_stream ?? throw new ObjectDisposedException("stream")).ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (ObjectDisposedException)
			{
				return 0;
			}
			catch (IOException ex2)
			{
				if (ex2.InnerException is SocketException source)
				{
					ExceptionDispatchInfo.Capture(source).Throw();
				}
				throw;
			}
		}

		public async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			cancellationToken.ThrowIfCancellationRequested();
			try
			{
				using (cancellationToken.Register(Dispose))
				{
					await (_stream ?? throw new ObjectDisposedException("stream")).WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (ObjectDisposedException)
			{
			}
			catch (IOException ex2)
			{
				if (ex2.InnerException is SocketException source)
				{
					ExceptionDispatchInfo.Capture(source).Throw();
				}
				throw;
			}
		}

		public void Dispose()
		{
			try
			{
				_stream?.Dispose();
			}
			catch (ObjectDisposedException)
			{
			}
			catch (NullReferenceException)
			{
			}
			_stream = null;
		}

		private bool InternalUserCertificateValidationCallback(object sender, X509Certificate x509Certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			Func<X509Certificate, X509Chain, SslPolicyErrors, IMqttClientOptions, bool> func = _options?.TlsOptions?.CertificateValidationCallback;
			if (func != null)
			{
				return func(x509Certificate, chain, sslPolicyErrors, _clientOptions);
			}
			Func<MqttClientCertificateValidationCallbackContext, bool> func2 = _options?.TlsOptions?.CertificateValidationHandler;
			if (func2 != null)
			{
				MqttClientCertificateValidationCallbackContext arg = new MqttClientCertificateValidationCallbackContext
				{
					Certificate = x509Certificate,
					Chain = chain,
					SslPolicyErrors = sslPolicyErrors,
					ClientOptions = _options
				};
				return func2(arg);
			}
			if (sslPolicyErrors == SslPolicyErrors.None)
			{
				return true;
			}
			if (chain.ChainStatus.Any((X509ChainStatus c) => c.Status == X509ChainStatusFlags.RevocationStatusUnknown || c.Status == X509ChainStatusFlags.Revoked || c.Status == X509ChainStatusFlags.OfflineRevocation))
			{
				MqttClientTcpOptions options = _options;
				if (options == null || options.TlsOptions?.IgnoreCertificateRevocationErrors != true)
				{
					return false;
				}
			}
			if (chain.ChainStatus.Any((X509ChainStatus c) => c.Status == X509ChainStatusFlags.PartialChain))
			{
				MqttClientTcpOptions options2 = _options;
				if (options2 == null || options2.TlsOptions?.IgnoreCertificateChainErrors != true)
				{
					return false;
				}
			}
			MqttClientTcpOptions options3 = _options;
			if (options3 == null)
			{
				return false;
			}
			return options3.TlsOptions?.AllowUntrustedCertificates == true;
		}

		private X509CertificateCollection LoadCertificates()
		{
			X509CertificateCollection x509CertificateCollection = new X509CertificateCollection();
			if (_options.TlsOptions.Certificates == null)
			{
				return x509CertificateCollection;
			}
			foreach (X509Certificate certificate in _options.TlsOptions.Certificates)
			{
				x509CertificateCollection.Add(certificate);
			}
			return x509CertificateCollection;
		}
	}
	public sealed class MqttTcpServerAdapter : IMqttServerAdapter, IDisposable
	{
		private readonly List<MqttTcpServerListener> _listeners = new List<MqttTcpServerListener>();

		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttNetLogger _rootLogger;

		private CancellationTokenSource _cancellationTokenSource;

		public Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }

		public bool TreatSocketOpeningErrorAsWarning { get; set; }

		public MqttTcpServerAdapter(IMqttNetLogger logger)
		{
			_rootLogger = logger ?? throw new ArgumentNullException("logger");
			_logger = logger.CreateScopedLogger("MqttTcpServerAdapter");
		}

		public Task StartAsync(IMqttServerOptions options)
		{
			if (_cancellationTokenSource != null)
			{
				throw new InvalidOperationException("Server is already started.");
			}
			_cancellationTokenSource = new CancellationTokenSource();
			if (options.DefaultEndpointOptions.IsEnabled)
			{
				RegisterListeners(options.DefaultEndpointOptions, null, _cancellationTokenSource.Token);
			}
			MqttServerTlsTcpEndpointOptions tlsEndpointOptions = options.TlsEndpointOptions;
			if (tlsEndpointOptions != null && tlsEndpointOptions.IsEnabled)
			{
				if (options.TlsEndpointOptions.CertificateProvider == null)
				{
					throw new ArgumentException("TLS certificate is not set.");
				}
				X509Certificate2 certificate = options.TlsEndpointOptions.CertificateProvider.GetCertificate();
				if (!certificate.HasPrivateKey)
				{
					throw new InvalidOperationException("The certificate for TLS encryption must contain the private key.");
				}
				RegisterListeners(options.TlsEndpointOptions, certificate, _cancellationTokenSource.Token);
			}
			return PlatformAbstractionLayer.CompletedTask;
		}

		public Task StopAsync()
		{
			Cleanup();
			return PlatformAbstractionLayer.CompletedTask;
		}

		public void Dispose()
		{
			Cleanup();
		}

		private void Cleanup()
		{
			_cancellationTokenSource?.Cancel(throwOnFirstException: false);
			_cancellationTokenSource?.Dispose();
			_cancellationTokenSource = null;
			foreach (MqttTcpServerListener listener in _listeners)
			{
				listener.Dispose();
			}
			_listeners.Clear();
		}

		private void RegisterListeners(MqttServerTcpEndpointBaseOptions options, X509Certificate2 tlsCertificate, CancellationToken cancellationToken)
		{
			if (!options.BoundInterNetworkAddress.Equals(IPAddress.None))
			{
				MqttTcpServerListener mqttTcpServerListener = new MqttTcpServerListener(AddressFamily.InterNetwork, options, tlsCertificate, _rootLogger)
				{
					ClientHandler = OnClientAcceptedAsync
				};
				if (mqttTcpServerListener.Start(TreatSocketOpeningErrorAsWarning, cancellationToken))
				{
					_listeners.Add(mqttTcpServerListener);
				}
			}
			if (!options.BoundInterNetworkV6Address.Equals(IPAddress.None))
			{
				MqttTcpServerListener mqttTcpServerListener2 = new MqttTcpServerListener(AddressFamily.InterNetworkV6, options, tlsCertificate, _rootLogger)
				{
					ClientHandler = OnClientAcceptedAsync
				};
				if (mqttTcpServerListener2.Start(TreatSocketOpeningErrorAsWarning, cancellationToken))
				{
					_listeners.Add(mqttTcpServerListener2);
				}
			}
		}

		private Task OnClientAcceptedAsync(IMqttChannelAdapter channelAdapter)
		{
			Func<IMqttChannelAdapter, Task> clientHandler = ClientHandler;
			if (clientHandler == null)
			{
				return Task.FromResult(0);
			}
			return clientHandler(channelAdapter);
		}
	}
	public sealed class MqttTcpServerListener : IDisposable
	{
		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttNetLogger _rootLogger;

		private readonly AddressFamily _addressFamily;

		private readonly MqttServerTcpEndpointBaseOptions _options;

		private readonly MqttServerTlsTcpEndpointOptions _tlsOptions;

		private readonly X509Certificate2 _tlsCertificate;

		private CrossPlatformSocket _socket;

		private IPEndPoint _localEndPoint;

		public Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }

		public MqttTcpServerListener(AddressFamily addressFamily, MqttServerTcpEndpointBaseOptions options, X509Certificate2 tlsCertificate, IMqttNetLogger logger)
		{
			_addressFamily = addressFamily;
			_options = options;
			_tlsCertificate = tlsCertificate;
			_rootLogger = logger;
			_logger = logger.CreateScopedLogger("MqttTcpServerListener");
			if (_options is MqttServerTlsTcpEndpointOptions tlsOptions)
			{
				_tlsOptions = tlsOptions;
			}
		}

		public bool Start(bool treatErrorsAsWarning, CancellationToken cancellationToken)
		{
			try
			{
				IPAddress address = _options.BoundInterNetworkAddress;
				if (_addressFamily == AddressFamily.InterNetworkV6)
				{
					address = _options.BoundInterNetworkV6Address;
				}
				_localEndPoint = new IPEndPoint(address, _options.Port);
				_logger.Info($"Starting TCP listener for {_localEndPoint} TLS={_tlsCertificate != null}.");
				_socket = new CrossPlatformSocket(_addressFamily);
				if (_options.ReuseAddress)
				{
					_socket.ReuseAddress = true;
				}
				if (_options.NoDelay)
				{
					_socket.NoDelay = true;
				}
				_socket.Bind(_localEndPoint);
				_socket.Listen(_options.ConnectionBacklog);
				Task.Run(() => AcceptClientConnectionsAsync(cancellationToken), cancellationToken).Forget(_logger);
				return true;
			}
			catch (Exception exception)
			{
				if (!treatErrorsAsWarning)
				{
					throw;
				}
				_logger.Warning(exception, "Error while creating listener socket for local end point '{0}'.", _localEndPoint);
				return false;
			}
		}

		public void Dispose()
		{
			_socket?.Dispose();
		}

		private async Task AcceptClientConnectionsAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					CrossPlatformSocket clientSocket = await _socket.AcceptAsync().ConfigureAwait(continueOnCapturedContext: false);
					if (clientSocket != null)
					{
						Task.Run(() => TryHandleClientConnectionAsync(clientSocket), cancellationToken).Forget(_logger);
					}
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception ex2)
				{
					if (!(ex2 is SocketException ex3) || (ex3.SocketErrorCode != SocketError.ConnectionAborted && ex3.SocketErrorCode != SocketError.OperationAborted))
					{
						_logger.Error(ex2, $"Error while accepting connection at TCP listener {_localEndPoint} TLS={_tlsCertificate != null}.");
						await Task.Delay(TimeSpan.FromSeconds(1.0), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
			}
		}

		private async Task TryHandleClientConnectionAsync(CrossPlatformSocket clientSocket)
		{
			Stream stream = null;
			string remoteEndPoint = null;
			try
			{
				remoteEndPoint = clientSocket.RemoteEndPoint.ToString();
				_logger.Verbose("Client '{0}' accepted by TCP listener '{1}, {2}'.", remoteEndPoint, _localEndPoint, (_addressFamily == AddressFamily.InterNetwork) ? "ipv4" : "ipv6");
				clientSocket.NoDelay = _options.NoDelay;
				stream = clientSocket.GetStream();
				X509Certificate2 x509Certificate = null;
				if (_tlsCertificate != null)
				{
					SslStream sslStream = new SslStream(stream, leaveInnerStreamOpen: false, _tlsOptions.RemoteCertificateValidationCallback);
					await sslStream.AuthenticateAsServerAsync(_tlsCertificate, _tlsOptions.ClientCertificateRequired, _tlsOptions.SslProtocol, _tlsOptions.CheckCertificateRevocation).ConfigureAwait(continueOnCapturedContext: false);
					stream = sslStream;
					x509Certificate = sslStream.RemoteCertificate as X509Certificate2;
					if (x509Certificate == null && sslStream.RemoteCertificate != null)
					{
						x509Certificate = new X509Certificate2(sslStream.RemoteCertificate.Export(X509ContentType.Cert));
					}
				}
				Func<IMqttChannelAdapter, Task> clientHandler = ClientHandler;
				if (clientHandler != null)
				{
					using MqttChannelAdapter clientAdapter = new MqttChannelAdapter(new MqttTcpChannel(stream, remoteEndPoint, x509Certificate), new MqttPacketFormatterAdapter(new MqttPacketWriter()), _rootLogger);
					await clientHandler(clientAdapter).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex)
			{
				if (!(ex is ObjectDisposedException) && !(ex is SocketException { SocketErrorCode: SocketError.OperationAborted }))
				{
					_logger.Error(ex, "Error while handling client connection.");
				}
			}
			finally
			{
				try
				{
					stream?.Dispose();
					clientSocket?.Dispose();
					_logger.Verbose("Client '{0}' disconnected at TCP listener '{1}, {2}'.", remoteEndPoint, _localEndPoint, (_addressFamily == AddressFamily.InterNetwork) ? "ipv4" : "ipv6");
				}
				catch (Exception exception)
				{
					_logger.Error(exception, "Error while cleaning up client connection");
				}
			}
		}
	}
	public sealed class MqttWebSocketChannel : IMqttChannel, IDisposable
	{
		private readonly MqttClientWebSocketOptions _options;

		private AsyncLock _sendLock = new AsyncLock();

		private WebSocket _webSocket;

		public string Endpoint { get; }

		public bool IsSecureConnection { get; private set; }

		public X509Certificate2 ClientCertificate { get; }

		public MqttWebSocketChannel(MqttClientWebSocketOptions options)
		{
			_options = options ?? throw new ArgumentNullException("options");
		}

		public MqttWebSocketChannel(WebSocket webSocket, string endpoint, bool isSecureConnection, X509Certificate2 clientCertificate)
		{
			_webSocket = webSocket ?? throw new ArgumentNullException("webSocket");
			Endpoint = endpoint;
			IsSecureConnection = isSecureConnection;
			ClientCertificate = clientCertificate;
		}

		public async Task ConnectAsync(CancellationToken cancellationToken)
		{
			string uri = _options.Uri;
			if (!uri.StartsWith("ws://", StringComparison.OrdinalIgnoreCase) && !uri.StartsWith("wss://", StringComparison.OrdinalIgnoreCase))
			{
				MqttClientTlsOptions tlsOptions = _options.TlsOptions;
				uri = ((tlsOptions == null || tlsOptions.UseTls) ? ("wss://" + uri) : ("ws://" + uri));
			}
			ClientWebSocket clientWebSocket = new ClientWebSocket();
			try
			{
				SetupClientWebSocket(clientWebSocket);
				await clientWebSocket.ConnectAsync(new Uri(uri), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception)
			{
				clientWebSocket.Dispose();
				throw;
			}
			_webSocket = clientWebSocket;
			IsSecureConnection = uri.StartsWith("wss://", StringComparison.OrdinalIgnoreCase);
		}

		public async Task DisconnectAsync(CancellationToken cancellationToken)
		{
			if (_webSocket != null)
			{
				if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting)
				{
					await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				Cleanup();
			}
		}

		public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return (await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer, offset, count), cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).Count;
		}

		public async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (_sendLock != null)
			{
				using (await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
				{
					await _webSocket.SendAsync(new ArraySegment<byte>(buffer, offset, count), WebSocketMessageType.Binary, endOfMessage: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		public void Dispose()
		{
			Cleanup();
		}

		private void SetupClientWebSocket(ClientWebSocket clientWebSocket)
		{
			if (_options.ProxyOptions != null)
			{
				clientWebSocket.Options.Proxy = CreateProxy();
			}
			if (_options.RequestHeaders != null)
			{
				foreach (KeyValuePair<string, string> requestHeader in _options.RequestHeaders)
				{
					clientWebSocket.Options.SetRequestHeader(requestHeader.Key, requestHeader.Value);
				}
			}
			if (_options.SubProtocols != null)
			{
				foreach (string subProtocol in _options.SubProtocols)
				{
					clientWebSocket.Options.AddSubProtocol(subProtocol);
				}
			}
			if (_options.CookieContainer != null)
			{
				clientWebSocket.Options.Cookies = _options.CookieContainer;
			}
			MqttClientTlsOptions tlsOptions = _options.TlsOptions;
			if (tlsOptions != null && tlsOptions.UseTls && _options.TlsOptions?.Certificates != null)
			{
				clientWebSocket.Options.ClientCertificates = new X509CertificateCollection();
				foreach (X509Certificate certificate in _options.TlsOptions.Certificates)
				{
					clientWebSocket.Options.ClientCertificates.Add(certificate);
				}
			}
			Func<MqttClientCertificateValidationCallbackContext, bool> certificateValidationHandler = _options.TlsOptions?.CertificateValidationHandler;
			if (certificateValidationHandler != null)
			{
				clientWebSocket.Options.RemoteCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
				{
					MqttClientCertificateValidationCallbackContext arg = new MqttClientCertificateValidationCallbackContext
					{
						Certificate = certificate,
						Chain = chain,
						SslPolicyErrors = sslPolicyErrors,
						ClientOptions = _options
					};
					return certificateValidationHandler(arg);
				};
			}
		}

		private void Cleanup()
		{
			_sendLock?.Dispose();
			_sendLock = null;
			try
			{
				_webSocket?.Dispose();
			}
			catch (ObjectDisposedException)
			{
			}
			finally
			{
				_webSocket = null;
			}
		}

		private IWebProxy CreateProxy()
		{
			if (string.IsNullOrEmpty(_options.ProxyOptions?.Address))
			{
				return null;
			}
			Uri address = new Uri(_options.ProxyOptions.Address);
			if (!string.IsNullOrEmpty(_options.ProxyOptions.Username) && !string.IsNullOrEmpty(_options.ProxyOptions.Password))
			{
				NetworkCredential credentials = new NetworkCredential(_options.ProxyOptions.Username, _options.ProxyOptions.Password, _options.ProxyOptions.Domain);
				return new WebProxy(address, _options.ProxyOptions.BypassOnLocal, _options.ProxyOptions.BypassList, credentials);
			}
			return new WebProxy(address, _options.ProxyOptions.BypassOnLocal, _options.ProxyOptions.BypassList);
		}
	}
	public static class PlatformAbstractionLayer
	{
		public static Task CompletedTask => Task.CompletedTask;
	}
}
namespace MQTTnet.Formatter
{
	public interface IMqttDataConverter
	{
		MqttPublishPacket CreatePublishPacket(MqttApplicationMessage applicationMessage);

		MqttPubAckPacket CreatePubAckPacket(MqttPublishPacket publishPacket);

		MqttApplicationMessage CreateApplicationMessage(MqttPublishPacket publishPacket);

		MqttClientAuthenticateResult CreateClientConnectResult(MqttConnAckPacket connAckPacket);

		MqttConnectPacket CreateConnectPacket(MqttApplicationMessage willApplicationMessage, IMqttClientOptions options);

		MqttConnAckPacket CreateConnAckPacket(MqttConnectionValidatorContext connectionValidatorContext);

		MQTTnet.Client.Subscribing.MqttClientSubscribeResult CreateClientSubscribeResult(MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket);

		MqttClientUnsubscribeResult CreateClientUnsubscribeResult(MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket);

		MqttSubscribePacket CreateSubscribePacket(MqttClientSubscribeOptions options);

		MqttUnsubscribePacket CreateUnsubscribePacket(MqttClientUnsubscribeOptions options);

		MqttDisconnectPacket CreateDisconnectPacket(MqttClientDisconnectOptions options);

		MqttClientPublishResult CreatePublishResult(MqttPubAckPacket pubAckPacket);

		MqttClientPublishResult CreatePublishResult(MqttPubRecPacket pubRecPacket, MqttPubCompPacket pubCompPacket);
	}
	public interface IMqttPacketBodyReader
	{
		int Length { get; }

		int Offset { get; }

		bool EndOfStream { get; }

		byte ReadByte();

		byte[] ReadRemainingData();

		ushort ReadTwoByteInteger();

		string ReadStringWithLengthPrefix();

		byte[] ReadWithLengthPrefix();

		uint ReadFourByteInteger();

		uint ReadVariableLengthInteger();

		bool ReadBoolean();

		void Seek(int position);
	}
	public interface IMqttPacketFormatter
	{
		IMqttDataConverter DataConverter { get; }

		ArraySegment<byte> Encode(MqttBasePacket mqttPacket);

		MqttBasePacket Decode(ReceivedMqttPacket receivedMqttPacket);

		void FreeBuffer();
	}
	public interface IMqttPacketWriter
	{
		int Length { get; }

		void WriteWithLengthPrefix(string value);

		void Write(byte value);

		void WriteWithLengthPrefix(byte[] value);

		void Write(ushort value);

		void Write(IMqttPacketWriter value);

		void WriteVariableLengthInteger(uint value);

		void Write(byte[] value, int offset, int length);

		void Reset(int length);

		void Seek(int offset);

		void FreeBuffer();

		byte[] GetBuffer();
	}
	public struct MqttFixedHeader(byte flags, int remainingLength, int totalLength)
	{
		public byte Flags { get; } = flags;

		public int RemainingLength { get; } = remainingLength;

		public int TotalLength { get; } = totalLength;
	}
	public class MqttPacketBodyReader : IMqttPacketBodyReader
	{
		private readonly byte[] _buffer;

		private readonly int _initialOffset;

		private readonly int _length;

		private int _offset;

		public int Offset => _offset;

		public int Length => _length - _offset;

		public bool EndOfStream => _offset == _length;

		public MqttPacketBodyReader(byte[] buffer, int offset, int length)
		{
			_buffer = buffer;
			_initialOffset = offset;
			_offset = offset;
			_length = length;
		}

		public void Seek(int position)
		{
			_offset = _initialOffset + position;
		}

		public byte ReadByte()
		{
			ValidateReceiveBuffer(1);
			return _buffer[_offset++];
		}

		public bool ReadBoolean()
		{
			ValidateReceiveBuffer(1);
			return _buffer[_offset++] switch
			{
				0 => false, 
				1 => true, 
				_ => throw new MqttProtocolViolationException("Boolean values can be 0 or 1 only."), 
			};
		}

		public byte[] ReadRemainingData()
		{
			int num = _length - _offset;
			byte[] array = new byte[num];
			Array.Copy(_buffer, _offset, array, 0, num);
			return array;
		}

		public ushort ReadTwoByteInteger()
		{
			ValidateReceiveBuffer(2);
			byte num = _buffer[_offset++];
			byte b = _buffer[_offset++];
			return (ushort)((num << 8) | b);
		}

		public uint ReadFourByteInteger()
		{
			ValidateReceiveBuffer(4);
			byte num = _buffer[_offset++];
			byte b = _buffer[_offset++];
			byte b2 = _buffer[_offset++];
			byte b3 = _buffer[_offset++];
			return (uint)((num << 24) | (b << 16) | (b2 << 8) | b3);
		}

		public uint ReadVariableLengthInteger()
		{
			int num = 1;
			uint num2 = 0u;
			byte b;
			do
			{
				b = ReadByte();
				num2 += (uint)((b & 0x7F) * num);
				if (num > 2097152)
				{
					throw new MqttProtocolViolationException("Variable length integer is invalid.");
				}
				num *= 128;
			}
			while ((b & 0x80) != 0);
			return num2;
		}

		public byte[] ReadWithLengthPrefix()
		{
			return ReadSegmentWithLengthPrefix().ToArray();
		}

		private ArraySegment<byte> ReadSegmentWithLengthPrefix()
		{
			ushort num = ReadTwoByteInteger();
			ValidateReceiveBuffer(num);
			ArraySegment<byte> result = new ArraySegment<byte>(_buffer, _offset, num);
			_offset += num;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateReceiveBuffer(int length)
		{
			if (_length < _offset + length)
			{
				throw new MqttProtocolViolationException($"Expected at least {_offset + length} bytes but there are only {_length} bytes");
			}
		}

		public string ReadStringWithLengthPrefix()
		{
			ArraySegment<byte> arraySegment = ReadSegmentWithLengthPrefix();
			return Encoding.UTF8.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
		}
	}
	public class MqttPacketFormatterAdapter
	{
		private IMqttPacketFormatter _formatter;

		public MqttProtocolVersion ProtocolVersion { get; private set; }

		public IMqttDataConverter DataConverter
		{
			get
			{
				ThrowIfFormatterNotSet();
				return _formatter.DataConverter;
			}
		}

		public IMqttPacketWriter Writer { get; }

		public MqttPacketFormatterAdapter(MqttProtocolVersion protocolVersion)
			: this(protocolVersion, new MqttPacketWriter())
		{
		}

		public MqttPacketFormatterAdapter(MqttProtocolVersion protocolVersion, IMqttPacketWriter writer)
			: this(writer)
		{
			UseProtocolVersion(protocolVersion);
		}

		public MqttPacketFormatterAdapter(IMqttPacketWriter writer)
		{
			Writer = writer;
		}

		public ArraySegment<byte> Encode(MqttBasePacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			ThrowIfFormatterNotSet();
			return _formatter.Encode(packet);
		}

		public MqttBasePacket Decode(ReceivedMqttPacket receivedMqttPacket)
		{
			if (receivedMqttPacket == null)
			{
				throw new ArgumentNullException("receivedMqttPacket");
			}
			ThrowIfFormatterNotSet();
			return _formatter.Decode(receivedMqttPacket);
		}

		public void FreeBuffer()
		{
			_formatter?.FreeBuffer();
		}

		public void DetectProtocolVersion(ReceivedMqttPacket receivedMqttPacket)
		{
			MqttProtocolVersion protocolVersion = ParseProtocolVersion(receivedMqttPacket);
			receivedMqttPacket.Body.Seek(0);
			UseProtocolVersion(protocolVersion);
		}

		private void UseProtocolVersion(MqttProtocolVersion protocolVersion)
		{
			if (protocolVersion == MqttProtocolVersion.Unknown)
			{
				throw new InvalidOperationException("MQTT protocol version is invalid.");
			}
			ProtocolVersion = protocolVersion;
			_formatter = GetMqttPacketFormatter(protocolVersion, Writer);
		}

		public static IMqttPacketFormatter GetMqttPacketFormatter(MqttProtocolVersion protocolVersion, IMqttPacketWriter writer)
		{
			return protocolVersion switch
			{
				MqttProtocolVersion.Unknown => throw new InvalidOperationException("MQTT protocol version is invalid."), 
				MqttProtocolVersion.V500 => new MqttV500PacketFormatter(writer), 
				MqttProtocolVersion.V311 => new MqttV311PacketFormatter(writer), 
				MqttProtocolVersion.V310 => new MqttV310PacketFormatter(writer), 
				_ => throw new NotSupportedException(), 
			};
		}

		private MqttProtocolVersion ParseProtocolVersion(ReceivedMqttPacket receivedMqttPacket)
		{
			if (receivedMqttPacket == null)
			{
				throw new ArgumentNullException("receivedMqttPacket");
			}
			if (receivedMqttPacket.Body.Length < 7)
			{
				throw new MqttProtocolViolationException("CONNECT packet must have at least 7 bytes.");
			}
			string text = receivedMqttPacket.Body.ReadStringWithLengthPrefix();
			byte b = receivedMqttPacket.Body.ReadByte();
			if (text == "MQTT")
			{
				return b switch
				{
					5 => MqttProtocolVersion.V500, 
					4 => MqttProtocolVersion.V311, 
					_ => throw new MqttProtocolViolationException($"Protocol level '{b}' not supported."), 
				};
			}
			if (text == "MQIsdp")
			{
				if (b == 3)
				{
					return MqttProtocolVersion.V310;
				}
				throw new MqttProtocolViolationException($"Protocol level '{b}' not supported.");
			}
			throw new MqttProtocolViolationException("Protocol '" + text + "' not supported.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ThrowIfFormatterNotSet()
		{
			if (_formatter == null)
			{
				throw new InvalidOperationException("Protocol version not set or detected.");
			}
		}
	}
	public class MqttPacketReader
	{
		private readonly byte[] _singleByteBuffer = new byte[1];

		private readonly IMqttChannel _channel;

		public MqttPacketReader(IMqttChannel channel)
		{
			_channel = channel ?? throw new ArgumentNullException("channel");
		}

		public async Task<ReadFixedHeaderResult> ReadFixedHeaderAsync(byte[] fixedHeaderBuffer, CancellationToken cancellationToken)
		{
			int num;
			int totalBytesRead;
			for (totalBytesRead = 0; totalBytesRead < fixedHeaderBuffer.Length; totalBytesRead += num)
			{
				num = await _channel.ReadAsync(fixedHeaderBuffer, totalBytesRead, fixedHeaderBuffer.Length - totalBytesRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (cancellationToken.IsCancellationRequested)
				{
					return null;
				}
				if (num == 0)
				{
					return new ReadFixedHeaderResult
					{
						ConnectionClosed = true
					};
				}
			}
			if (fixedHeaderBuffer[1] == 0)
			{
				return new ReadFixedHeaderResult
				{
					FixedHeader = new MqttFixedHeader(fixedHeaderBuffer[0], 0, totalBytesRead)
				};
			}
			int? num2 = await ReadBodyLengthAsync(fixedHeaderBuffer[1], cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (!num2.HasValue)
			{
				return new ReadFixedHeaderResult
				{
					ConnectionClosed = true
				};
			}
			totalBytesRead += num2.Value;
			return new ReadFixedHeaderResult
			{
				FixedHeader = new MqttFixedHeader(fixedHeaderBuffer[0], num2.Value, totalBytesRead)
			};
		}

		private async Task<int?> ReadBodyLengthAsync(byte initialEncodedByte, CancellationToken cancellationToken)
		{
			int offset = 0;
			int multiplier = 128;
			int value = initialEncodedByte & 0x7F;
			int num = initialEncodedByte;
			while ((num & 0x80) != 0)
			{
				offset++;
				if (offset > 3)
				{
					throw new MqttProtocolViolationException("Remaining length is invalid.");
				}
				if (cancellationToken.IsCancellationRequested)
				{
					return null;
				}
				int num2 = await _channel.ReadAsync(_singleByteBuffer, 0, 1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (cancellationToken.IsCancellationRequested)
				{
					return null;
				}
				if (num2 == 0)
				{
					return null;
				}
				num = _singleByteBuffer[0];
				value += (num & 0x7F) * multiplier;
				multiplier *= 128;
			}
			return value;
		}
	}
	public sealed class MqttPacketWriter : IMqttPacketWriter
	{
		private static readonly ArraySegment<byte> ZeroVariableLengthIntegerArray = new ArraySegment<byte>(new byte[1], 0, 1);

		private static readonly ArraySegment<byte> ZeroTwoByteIntegerArray = new ArraySegment<byte>(new byte[2], 0, 2);

		public static int InitialBufferSize = 128;

		public static int MaxBufferSize = 4096;

		private byte[] _buffer = new byte[InitialBufferSize];

		private int _offset;

		public int Length { get; private set; }

		public static byte BuildFixedHeader(MqttControlPacketType packetType, byte flags = 0)
		{
			return (byte)(((int)packetType << 4) | flags);
		}

		public static int GetLengthOfVariableInteger(uint value)
		{
			int num = 0;
			uint num2 = value;
			do
			{
				num2 /= 128;
				num++;
			}
			while (num2 != 0);
			return num;
		}

		public static ArraySegment<byte> EncodeVariableLengthInteger(uint value)
		{
			if (value == 0)
			{
				return ZeroVariableLengthIntegerArray;
			}
			if (value <= 127)
			{
				return new ArraySegment<byte>(new byte[1] { (byte)value }, 0, 1);
			}
			byte[] array = new byte[4];
			int num = 0;
			uint num2 = value;
			do
			{
				uint num3 = num2 % 128;
				num2 /= 128;
				if (num2 != 0)
				{
					num3 |= 0x80;
				}
				array[num] = (byte)num3;
				num++;
			}
			while (num2 != 0);
			return new ArraySegment<byte>(array, 0, num);
		}

		public void WriteVariableLengthInteger(uint value)
		{
			Write(EncodeVariableLengthInteger(value));
		}

		public void WriteWithLengthPrefix(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				Write(ZeroTwoByteIntegerArray);
			}
			else
			{
				WriteWithLengthPrefix(Encoding.UTF8.GetBytes(value));
			}
		}

		public void WriteWithLengthPrefix(byte[] value)
		{
			if (value == null || value.Length == 0)
			{
				Write(ZeroTwoByteIntegerArray);
				return;
			}
			EnsureAdditionalCapacity(value.Length + 2);
			Write((ushort)value.Length);
			Write(value, 0, value.Length);
		}

		public void Write(byte @byte)
		{
			EnsureAdditionalCapacity(1);
			_buffer[_offset] = @byte;
			IncreasePosition(1);
		}

		public void Write(ushort value)
		{
			EnsureAdditionalCapacity(2);
			_buffer[_offset] = (byte)(value >> 8);
			IncreasePosition(1);
			_buffer[_offset] = (byte)value;
			IncreasePosition(1);
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count != 0)
			{
				EnsureAdditionalCapacity(count);
				Array.Copy(buffer, offset, _buffer, _offset, count);
				IncreasePosition(count);
			}
		}

		public void Write(IMqttPacketWriter propertyWriter)
		{
			if (propertyWriter == null)
			{
				throw new ArgumentNullException("propertyWriter");
			}
			if (propertyWriter is MqttPacketWriter mqttPacketWriter)
			{
				if (mqttPacketWriter.Length != 0)
				{
					Write(mqttPacketWriter._buffer, 0, mqttPacketWriter.Length);
				}
				return;
			}
			throw new InvalidOperationException("propertyWriter must be of type " + typeof(MqttPacketWriter).Name);
		}

		public void Reset(int length)
		{
			Length = length;
		}

		public void Seek(int position)
		{
			EnsureCapacity(position);
			_offset = position;
		}

		public byte[] GetBuffer()
		{
			return _buffer;
		}

		public void FreeBuffer()
		{
			if (_buffer.Length >= MaxBufferSize)
			{
				Array.Resize(ref _buffer, MaxBufferSize);
			}
		}

		private void Write(ArraySegment<byte> buffer)
		{
			Write(buffer.Array, buffer.Offset, buffer.Count);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureAdditionalCapacity(int additionalCapacity)
		{
			int num = _buffer.Length - _offset;
			if (num < additionalCapacity)
			{
				EnsureCapacity(_buffer.Length + additionalCapacity - num);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureCapacity(int capacity)
		{
			int num = _buffer.Length;
			if (num < capacity)
			{
				while (num < capacity)
				{
					num *= 2;
				}
				Array.Resize(ref _buffer, num);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void IncreasePosition(int length)
		{
			_offset += length;
			if (_offset > Length)
			{
				Length = _offset;
			}
		}
	}
	public enum MqttProtocolVersion
	{
		Unknown = 0,
		V310 = 3,
		V311 = 4,
		V500 = 5
	}
	public class ReadFixedHeaderResult
	{
		public bool ConnectionClosed { get; set; }

		public MqttFixedHeader FixedHeader { get; set; }
	}
}
namespace MQTTnet.Formatter.V5
{
	public class MqttV500DataConverter : IMqttDataConverter
	{
		public MqttPublishPacket CreatePublishPacket(MqttApplicationMessage applicationMessage)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			MqttPublishPacket mqttPublishPacket = new MqttPublishPacket
			{
				Topic = applicationMessage.Topic,
				Payload = applicationMessage.Payload,
				QualityOfServiceLevel = applicationMessage.QualityOfServiceLevel,
				Retain = applicationMessage.Retain,
				Dup = false,
				Properties = new MqttPublishPacketProperties
				{
					ContentType = applicationMessage.ContentType,
					CorrelationData = applicationMessage.CorrelationData,
					MessageExpiryInterval = applicationMessage.MessageExpiryInterval,
					PayloadFormatIndicator = applicationMessage.PayloadFormatIndicator,
					ResponseTopic = applicationMessage.ResponseTopic,
					SubscriptionIdentifiers = applicationMessage.SubscriptionIdentifiers,
					TopicAlias = applicationMessage.TopicAlias
				}
			};
			if (applicationMessage.UserProperties != null)
			{
				mqttPublishPacket.Properties.UserProperties = new List<MqttUserProperty>();
				mqttPublishPacket.Properties.UserProperties.AddRange(applicationMessage.UserProperties);
			}
			return mqttPublishPacket;
		}

		public MqttPubAckPacket CreatePubAckPacket(MqttPublishPacket publishPacket)
		{
			return new MqttPubAckPacket
			{
				PacketIdentifier = publishPacket.PacketIdentifier,
				ReasonCode = MqttPubAckReasonCode.Success
			};
		}

		public MqttApplicationMessage CreateApplicationMessage(MqttPublishPacket publishPacket)
		{
			return new MqttApplicationMessage
			{
				Topic = publishPacket.Topic,
				Payload = publishPacket.Payload,
				QualityOfServiceLevel = publishPacket.QualityOfServiceLevel,
				Retain = publishPacket.Retain,
				ResponseTopic = publishPacket.Properties?.ResponseTopic,
				ContentType = publishPacket.Properties?.ContentType,
				CorrelationData = publishPacket.Properties?.CorrelationData,
				MessageExpiryInterval = publishPacket.Properties?.MessageExpiryInterval,
				SubscriptionIdentifiers = publishPacket.Properties?.SubscriptionIdentifiers,
				TopicAlias = publishPacket.Properties?.TopicAlias,
				PayloadFormatIndicator = publishPacket.Properties?.PayloadFormatIndicator,
				UserProperties = (publishPacket.Properties?.UserProperties ?? new List<MqttUserProperty>())
			};
		}

		public MqttClientAuthenticateResult CreateClientConnectResult(MqttConnAckPacket connAckPacket)
		{
			if (connAckPacket == null)
			{
				throw new ArgumentNullException("connAckPacket");
			}
			return new MqttClientAuthenticateResult
			{
				IsSessionPresent = connAckPacket.IsSessionPresent,
				ResultCode = (MqttClientConnectResultCode)connAckPacket.ReasonCode.Value,
				WildcardSubscriptionAvailable = connAckPacket.Properties?.WildcardSubscriptionAvailable,
				RetainAvailable = connAckPacket.Properties?.RetainAvailable,
				AssignedClientIdentifier = connAckPacket.Properties?.AssignedClientIdentifier,
				AuthenticationMethod = connAckPacket.Properties?.AuthenticationMethod,
				AuthenticationData = connAckPacket.Properties?.AuthenticationData,
				MaximumPacketSize = connAckPacket.Properties?.MaximumPacketSize,
				ReasonString = connAckPacket.Properties?.ReasonString,
				ReceiveMaximum = connAckPacket.Properties?.ReceiveMaximum,
				ResponseInformation = connAckPacket.Properties?.ResponseInformation,
				TopicAliasMaximum = connAckPacket.Properties?.TopicAliasMaximum,
				ServerReference = connAckPacket.Properties?.ServerReference,
				ServerKeepAlive = connAckPacket.Properties?.ServerKeepAlive,
				SessionExpiryInterval = connAckPacket.Properties?.SessionExpiryInterval,
				SubscriptionIdentifiersAvailable = connAckPacket.Properties?.SubscriptionIdentifiersAvailable,
				SharedSubscriptionAvailable = connAckPacket.Properties?.SharedSubscriptionAvailable,
				UserProperties = connAckPacket.Properties?.UserProperties
			};
		}

		public MqttConnectPacket CreateConnectPacket(MqttApplicationMessage willApplicationMessage, IMqttClientOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			return new MqttConnectPacket
			{
				ClientId = options.ClientId,
				Username = options.Credentials?.Username,
				Password = options.Credentials?.Password,
				CleanSession = options.CleanSession,
				KeepAlivePeriod = (ushort)options.KeepAlivePeriod.TotalSeconds,
				WillMessage = willApplicationMessage,
				Properties = new MqttConnectPacketProperties
				{
					AuthenticationMethod = options.AuthenticationMethod,
					AuthenticationData = options.AuthenticationData,
					WillDelayInterval = options.WillDelayInterval,
					MaximumPacketSize = options.MaximumPacketSize,
					ReceiveMaximum = options.ReceiveMaximum,
					RequestProblemInformation = options.RequestProblemInformation,
					RequestResponseInformation = options.RequestResponseInformation,
					SessionExpiryInterval = options.SessionExpiryInterval,
					TopicAliasMaximum = options.TopicAliasMaximum,
					UserProperties = options.UserProperties
				}
			};
		}

		public MqttConnAckPacket CreateConnAckPacket(MqttConnectionValidatorContext connectionValidatorContext)
		{
			return new MqttConnAckPacket
			{
				ReasonCode = connectionValidatorContext.ReasonCode,
				Properties = new MqttConnAckPacketProperties
				{
					UserProperties = connectionValidatorContext.ResponseUserProperties,
					AuthenticationMethod = connectionValidatorContext.AuthenticationMethod,
					AuthenticationData = connectionValidatorContext.ResponseAuthenticationData,
					AssignedClientIdentifier = connectionValidatorContext.AssignedClientIdentifier,
					ReasonString = connectionValidatorContext.ReasonString
				}
			};
		}

		public MQTTnet.Client.Subscribing.MqttClientSubscribeResult CreateClientSubscribeResult(MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
		{
			if (subscribePacket == null)
			{
				throw new ArgumentNullException("subscribePacket");
			}
			if (subAckPacket == null)
			{
				throw new ArgumentNullException("subAckPacket");
			}
			if (subAckPacket.ReasonCodes.Count != subscribePacket.TopicFilters.Count)
			{
				throw new MqttProtocolViolationException("The reason codes are not matching the topic filters [MQTT-3.9.3-1].");
			}
			MQTTnet.Client.Subscribing.MqttClientSubscribeResult mqttClientSubscribeResult = new MQTTnet.Client.Subscribing.MqttClientSubscribeResult();
			mqttClientSubscribeResult.Items.AddRange(subscribePacket.TopicFilters.Select((MqttTopicFilter t, int i) => new MqttClientSubscribeResultItem(t, (MqttClientSubscribeResultCode)subAckPacket.ReasonCodes[i])));
			return mqttClientSubscribeResult;
		}

		public MqttClientUnsubscribeResult CreateClientUnsubscribeResult(MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
		{
			if (unsubscribePacket == null)
			{
				throw new ArgumentNullException("unsubscribePacket");
			}
			if (unsubAckPacket == null)
			{
				throw new ArgumentNullException("unsubAckPacket");
			}
			if (unsubAckPacket.ReasonCodes.Count != unsubscribePacket.TopicFilters.Count)
			{
				throw new MqttProtocolViolationException("The return codes are not matching the topic filters [MQTT-3.9.3-1].");
			}
			MqttClientUnsubscribeResult mqttClientUnsubscribeResult = new MqttClientUnsubscribeResult();
			mqttClientUnsubscribeResult.Items.AddRange(unsubscribePacket.TopicFilters.Select((string t, int i) => new MqttClientUnsubscribeResultItem(t, (MqttClientUnsubscribeResultCode)unsubAckPacket.ReasonCodes[i])));
			return mqttClientUnsubscribeResult;
		}

		public MqttSubscribePacket CreateSubscribePacket(MqttClientSubscribeOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			MqttSubscribePacket mqttSubscribePacket = new MqttSubscribePacket();
			mqttSubscribePacket.Properties = new MqttSubscribePacketProperties();
			mqttSubscribePacket.TopicFilters.AddRange(options.TopicFilters);
			mqttSubscribePacket.Properties.SubscriptionIdentifier = options.SubscriptionIdentifier;
			mqttSubscribePacket.Properties.UserProperties = options.UserProperties;
			return mqttSubscribePacket;
		}

		public MqttUnsubscribePacket CreateUnsubscribePacket(MqttClientUnsubscribeOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			MqttUnsubscribePacket mqttUnsubscribePacket = new MqttUnsubscribePacket();
			mqttUnsubscribePacket.Properties = new MqttUnsubscribePacketProperties();
			mqttUnsubscribePacket.TopicFilters.AddRange(options.TopicFilters);
			mqttUnsubscribePacket.Properties.UserProperties = options.UserProperties;
			return mqttUnsubscribePacket;
		}

		public MqttDisconnectPacket CreateDisconnectPacket(MqttClientDisconnectOptions options)
		{
			MqttDisconnectPacket mqttDisconnectPacket = new MqttDisconnectPacket();
			if (options == null)
			{
				mqttDisconnectPacket.ReasonCode = MqttDisconnectReasonCode.NormalDisconnection;
			}
			else
			{
				mqttDisconnectPacket.ReasonCode = (MqttDisconnectReasonCode)options.ReasonCode;
			}
			return mqttDisconnectPacket;
		}

		public MqttClientPublishResult CreatePublishResult(MqttPubAckPacket pubAckPacket)
		{
			MqttClientPublishResult mqttClientPublishResult = new MqttClientPublishResult
			{
				ReasonCode = MqttClientPublishReasonCode.Success,
				ReasonString = pubAckPacket?.Properties?.ReasonString,
				UserProperties = pubAckPacket?.Properties?.UserProperties
			};
			if (pubAckPacket != null)
			{
				mqttClientPublishResult.ReasonCode = (MqttClientPublishReasonCode)pubAckPacket.ReasonCode.Value;
				mqttClientPublishResult.PacketIdentifier = pubAckPacket.PacketIdentifier;
			}
			return mqttClientPublishResult;
		}

		public MqttClientPublishResult CreatePublishResult(MqttPubRecPacket pubRecPacket, MqttPubCompPacket pubCompPacket)
		{
			if (pubRecPacket == null || pubCompPacket == null)
			{
				return new MqttClientPublishResult
				{
					ReasonCode = MqttClientPublishReasonCode.UnspecifiedError
				};
			}
			if (pubCompPacket.ReasonCode == MqttPubCompReasonCode.PacketIdentifierNotFound)
			{
				return new MqttClientPublishResult
				{
					PacketIdentifier = pubCompPacket.PacketIdentifier,
					ReasonCode = MqttClientPublishReasonCode.UnspecifiedError,
					ReasonString = pubCompPacket.Properties?.ReasonString,
					UserProperties = pubCompPacket.Properties?.UserProperties
				};
			}
			MqttClientPublishResult mqttClientPublishResult = new MqttClientPublishResult
			{
				PacketIdentifier = pubCompPacket.PacketIdentifier,
				ReasonCode = MqttClientPublishReasonCode.Success,
				ReasonString = pubCompPacket.Properties?.ReasonString,
				UserProperties = pubCompPacket.Properties?.UserProperties
			};
			if (pubRecPacket.ReasonCode.HasValue)
			{
				mqttClientPublishResult.ReasonCode = (MqttClientPublishReasonCode)pubRecPacket.ReasonCode.Value;
			}
			return mqttClientPublishResult;
		}
	}
	public class MqttV500PacketDecoder
	{
		private static readonly MqttPingReqPacket PingReqPacket = new MqttPingReqPacket();

		private static readonly MqttPingRespPacket PingRespPacket = new MqttPingRespPacket();

		public MqttBasePacket Decode(ReceivedMqttPacket receivedMqttPacket)
		{
			if (receivedMqttPacket == null)
			{
				throw new ArgumentNullException("receivedMqttPacket");
			}
			int num = receivedMqttPacket.FixedHeader >> 4;
			if (num < 1 || num > 15)
			{
				throw new MqttProtocolViolationException($"The packet type is invalid ({num}).");
			}
			return (MqttControlPacketType)num switch
			{
				MqttControlPacketType.Connect => DecodeConnectPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.ConnAck => DecodeConnAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Disconnect => DecodeDisconnectPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Publish => DecodePublishPacket(receivedMqttPacket.FixedHeader, receivedMqttPacket.Body), 
				MqttControlPacketType.PubAck => DecodePubAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubRec => DecodePubRecPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubRel => DecodePubRelPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubComp => DecodePubCompPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PingReq => DecodePingReqPacket(), 
				MqttControlPacketType.PingResp => DecodePingRespPacket(), 
				MqttControlPacketType.Subscribe => DecodeSubscribePacket(receivedMqttPacket.Body), 
				MqttControlPacketType.SubAck => DecodeSubAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Unsubscibe => DecodeUnsubscribePacket(receivedMqttPacket.Body), 
				MqttControlPacketType.UnsubAck => DecodeUnsubAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Auth => DecodeAuthPacket(receivedMqttPacket.Body), 
				_ => throw new MqttProtocolViolationException($"Packet type ({num}) not supported."), 
			};
		}

		private static MqttBasePacket DecodeConnectPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttConnectPacket mqttConnectPacket = new MqttConnectPacket();
			string text = body.ReadStringWithLengthPrefix();
			byte b = body.ReadByte();
			if (text != "MQTT" && b != 5)
			{
				throw new MqttProtocolViolationException("MQTT protocol name and version do not match MQTT v5.");
			}
			byte num = body.ReadByte();
			bool cleanSession = (num & 2) > 0;
			bool flag = (num & 4) > 0;
			byte qualityOfServiceLevel = (byte)((num >> 3) & 3);
			bool retain = (num & 0x20) > 0;
			bool flag2 = (num & 0x40) > 0;
			bool flag3 = (num & 0x80) > 0;
			mqttConnectPacket.CleanSession = cleanSession;
			if (flag)
			{
				mqttConnectPacket.WillMessage = new MqttApplicationMessage
				{
					QualityOfServiceLevel = (MqttQualityOfServiceLevel)qualityOfServiceLevel,
					Retain = retain
				};
			}
			mqttConnectPacket.KeepAlivePeriod = body.ReadTwoByteInteger();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttConnectPacket.Properties == null)
				{
					mqttConnectPacket.Properties = new MqttConnectPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
				{
					mqttConnectPacket.Properties.SessionExpiryInterval = mqttV500PropertiesReader.ReadSessionExpiryInterval();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
				{
					mqttConnectPacket.Properties.AuthenticationMethod = mqttV500PropertiesReader.ReadAuthenticationMethod();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
				{
					mqttConnectPacket.Properties.AuthenticationData = mqttV500PropertiesReader.ReadAuthenticationData();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReceiveMaximum)
				{
					mqttConnectPacket.Properties.ReceiveMaximum = mqttV500PropertiesReader.ReadReceiveMaximum();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.TopicAliasMaximum)
				{
					mqttConnectPacket.Properties.TopicAliasMaximum = mqttV500PropertiesReader.ReadTopicAliasMaximum();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.MaximumPacketSize)
				{
					mqttConnectPacket.Properties.MaximumPacketSize = mqttV500PropertiesReader.ReadMaximumPacketSize();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.RequestResponseInformation)
				{
					mqttConnectPacket.Properties.RequestResponseInformation = mqttV500PropertiesReader.RequestResponseInformation();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.RequestProblemInformation)
				{
					mqttConnectPacket.Properties.RequestProblemInformation = mqttV500PropertiesReader.RequestProblemInformation();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttConnectPacket.Properties.UserProperties == null)
					{
						mqttConnectPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttConnectPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttConnectPacket));
				}
			}
			mqttConnectPacket.ClientId = body.ReadStringWithLengthPrefix();
			if (mqttConnectPacket.WillMessage != null)
			{
				MqttV500PropertiesReader mqttV500PropertiesReader2 = new MqttV500PropertiesReader(body);
				while (mqttV500PropertiesReader2.MoveNext())
				{
					if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.PayloadFormatIndicator)
					{
						mqttConnectPacket.WillMessage.PayloadFormatIndicator = mqttV500PropertiesReader.ReadPayloadFormatIndicator();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.MessageExpiryInterval)
					{
						mqttConnectPacket.WillMessage.MessageExpiryInterval = mqttV500PropertiesReader.ReadMessageExpiryInterval();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.TopicAlias)
					{
						mqttConnectPacket.WillMessage.TopicAlias = mqttV500PropertiesReader.ReadTopicAlias();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.ResponseTopic)
					{
						mqttConnectPacket.WillMessage.ResponseTopic = mqttV500PropertiesReader.ReadResponseTopic();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.CorrelationData)
					{
						mqttConnectPacket.WillMessage.CorrelationData = mqttV500PropertiesReader.ReadCorrelationData();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifier)
					{
						if (mqttConnectPacket.WillMessage.SubscriptionIdentifiers == null)
						{
							mqttConnectPacket.WillMessage.SubscriptionIdentifiers = new List<uint>();
						}
						mqttConnectPacket.WillMessage.SubscriptionIdentifiers.Add(mqttV500PropertiesReader.ReadSubscriptionIdentifier());
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.ContentType)
					{
						mqttConnectPacket.WillMessage.ContentType = mqttV500PropertiesReader.ReadContentType();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.WillDelayInterval)
					{
						mqttConnectPacket.Properties.WillDelayInterval = mqttV500PropertiesReader.ReadWillDelayInterval();
					}
					else if (mqttV500PropertiesReader2.CurrentPropertyId == MqttPropertyId.UserProperty)
					{
						if (mqttConnectPacket.WillMessage.UserProperties == null)
						{
							mqttConnectPacket.WillMessage.UserProperties = new List<MqttUserProperty>();
						}
						mqttV500PropertiesReader.AddUserPropertyTo(mqttConnectPacket.Properties.UserProperties);
					}
					else
					{
						mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPublishPacket));
					}
				}
				mqttConnectPacket.WillMessage.Topic = body.ReadStringWithLengthPrefix();
				mqttConnectPacket.WillMessage.Payload = body.ReadWithLengthPrefix();
			}
			if (flag3)
			{
				mqttConnectPacket.Username = body.ReadStringWithLengthPrefix();
			}
			if (flag2)
			{
				mqttConnectPacket.Password = body.ReadWithLengthPrefix();
			}
			return mqttConnectPacket;
		}

		private static MqttBasePacket DecodeConnAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			byte b = body.ReadByte();
			MqttConnAckPacket mqttConnAckPacket = new MqttConnAckPacket
			{
				IsSessionPresent = ((b & 1) > 0),
				ReasonCode = (MqttConnectReasonCode)body.ReadByte()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttConnAckPacket.Properties == null)
				{
					mqttConnAckPacket.Properties = new MqttConnAckPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
				{
					mqttConnAckPacket.Properties.SessionExpiryInterval = mqttV500PropertiesReader.ReadSessionExpiryInterval();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
				{
					mqttConnAckPacket.Properties.AuthenticationMethod = mqttV500PropertiesReader.ReadAuthenticationMethod();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
				{
					mqttConnAckPacket.Properties.AuthenticationData = mqttV500PropertiesReader.ReadAuthenticationData();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.RetainAvailable)
				{
					mqttConnAckPacket.Properties.RetainAvailable = mqttV500PropertiesReader.ReadRetainAvailable();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReceiveMaximum)
				{
					mqttConnAckPacket.Properties.ReceiveMaximum = mqttV500PropertiesReader.ReadReceiveMaximum();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AssignedClientIdentifier)
				{
					mqttConnAckPacket.Properties.AssignedClientIdentifier = mqttV500PropertiesReader.ReadAssignedClientIdentifier();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.TopicAliasMaximum)
				{
					mqttConnAckPacket.Properties.TopicAliasMaximum = mqttV500PropertiesReader.ReadTopicAliasMaximum();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttConnAckPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.MaximumPacketSize)
				{
					mqttConnAckPacket.Properties.MaximumPacketSize = mqttV500PropertiesReader.ReadMaximumPacketSize();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.WildcardSubscriptionAvailable)
				{
					mqttConnAckPacket.Properties.WildcardSubscriptionAvailable = mqttV500PropertiesReader.ReadWildcardSubscriptionAvailable();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifiersAvailable)
				{
					mqttConnAckPacket.Properties.SubscriptionIdentifiersAvailable = mqttV500PropertiesReader.ReadSubscriptionIdentifiersAvailable();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SharedSubscriptionAvailable)
				{
					mqttConnAckPacket.Properties.SharedSubscriptionAvailable = mqttV500PropertiesReader.ReadSharedSubscriptionAvailable();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ServerKeepAlive)
				{
					mqttConnAckPacket.Properties.ServerKeepAlive = mqttV500PropertiesReader.ReadServerKeepAlive();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ResponseInformation)
				{
					mqttConnAckPacket.Properties.ResponseInformation = mqttV500PropertiesReader.ReadResponseInformation();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ServerReference)
				{
					mqttConnAckPacket.Properties.ServerReference = mqttV500PropertiesReader.ReadServerReference();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttConnAckPacket.Properties.UserProperties == null)
					{
						mqttConnAckPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttConnAckPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttConnAckPacket));
				}
			}
			return mqttConnAckPacket;
		}

		private static MqttBasePacket DecodeDisconnectPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttDisconnectPacket mqttDisconnectPacket = new MqttDisconnectPacket
			{
				ReasonCode = (MqttDisconnectReasonCode)body.ReadByte()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttDisconnectPacket.Properties == null)
				{
					mqttDisconnectPacket.Properties = new MqttDisconnectPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
				{
					mqttDisconnectPacket.Properties.SessionExpiryInterval = mqttV500PropertiesReader.ReadSessionExpiryInterval();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttDisconnectPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ServerReference)
				{
					mqttDisconnectPacket.Properties.ServerReference = mqttV500PropertiesReader.ReadServerReference();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttDisconnectPacket.Properties.UserProperties == null)
					{
						mqttDisconnectPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttDisconnectPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttDisconnectPacket));
				}
			}
			return mqttDisconnectPacket;
		}

		private static MqttBasePacket DecodeSubscribePacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttSubscribePacket mqttSubscribePacket = new MqttSubscribePacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttSubscribePacket.Properties == null)
				{
					mqttSubscribePacket.Properties = new MqttSubscribePacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifier)
				{
					mqttSubscribePacket.Properties.SubscriptionIdentifier = mqttV500PropertiesReader.ReadSubscriptionIdentifier();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttSubscribePacket.Properties.UserProperties == null)
					{
						mqttSubscribePacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttSubscribePacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttSubscribePacket));
				}
			}
			while (!body.EndOfStream)
			{
				string topic = body.ReadStringWithLengthPrefix();
				byte num = body.ReadByte();
				MqttQualityOfServiceLevel qualityOfServiceLevel = (MqttQualityOfServiceLevel)(num & 3);
				bool value = (num & 4) > 0;
				bool value2 = (num & 8) > 0;
				MqttRetainHandling value3 = (MqttRetainHandling)((num >> 4) & 3);
				mqttSubscribePacket.TopicFilters.Add(new MqttTopicFilter
				{
					Topic = topic,
					QualityOfServiceLevel = qualityOfServiceLevel,
					NoLocal = value,
					RetainAsPublished = value2,
					RetainHandling = value3
				});
			}
			return mqttSubscribePacket;
		}

		private static MqttBasePacket DecodeSubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttSubAckPacket mqttSubAckPacket = new MqttSubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttSubAckPacket.Properties == null)
				{
					mqttSubAckPacket.Properties = new MqttSubAckPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttSubAckPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttSubAckPacket.Properties.UserProperties == null)
					{
						mqttSubAckPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttSubAckPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttSubAckPacket));
				}
			}
			while (!body.EndOfStream)
			{
				MqttSubscribeReasonCode item = (MqttSubscribeReasonCode)body.ReadByte();
				mqttSubAckPacket.ReasonCodes.Add(item);
			}
			return mqttSubAckPacket;
		}

		private static MqttBasePacket DecodeUnsubscribePacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttUnsubscribePacket mqttUnsubscribePacket = new MqttUnsubscribePacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttUnsubscribePacket.Properties == null)
				{
					mqttUnsubscribePacket.Properties = new MqttUnsubscribePacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttUnsubscribePacket.Properties.UserProperties == null)
					{
						mqttUnsubscribePacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttUnsubscribePacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttUnsubscribePacket));
				}
			}
			while (!body.EndOfStream)
			{
				mqttUnsubscribePacket.TopicFilters.Add(body.ReadStringWithLengthPrefix());
			}
			return mqttUnsubscribePacket;
		}

		private static MqttBasePacket DecodeUnsubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttUnsubAckPacket mqttUnsubAckPacket = new MqttUnsubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttUnsubAckPacket.Properties == null)
				{
					mqttUnsubAckPacket.Properties = new MqttUnsubAckPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttUnsubAckPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttUnsubAckPacket.Properties.UserProperties == null)
					{
						mqttUnsubAckPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttUnsubAckPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttUnsubAckPacket));
				}
			}
			while (!body.EndOfStream)
			{
				MqttUnsubscribeReasonCode item = (MqttUnsubscribeReasonCode)body.ReadByte();
				mqttUnsubAckPacket.ReasonCodes.Add(item);
			}
			return mqttUnsubAckPacket;
		}

		private static MqttBasePacket DecodePingReqPacket()
		{
			return PingReqPacket;
		}

		private static MqttBasePacket DecodePingRespPacket()
		{
			return PingRespPacket;
		}

		private static MqttBasePacket DecodePublishPacket(byte header, IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			bool retain = (header & 1) > 0;
			MqttQualityOfServiceLevel mqttQualityOfServiceLevel = (MqttQualityOfServiceLevel)((header >> 1) & 3);
			bool dup = ((header >> 3) & 1) > 0;
			MqttPublishPacket mqttPublishPacket = new MqttPublishPacket
			{
				Topic = body.ReadStringWithLengthPrefix(),
				Retain = retain,
				QualityOfServiceLevel = mqttQualityOfServiceLevel,
				Dup = dup
			};
			if (mqttQualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
			{
				mqttPublishPacket.PacketIdentifier = body.ReadTwoByteInteger();
			}
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttPublishPacket.Properties == null)
				{
					mqttPublishPacket.Properties = new MqttPublishPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.PayloadFormatIndicator)
				{
					mqttPublishPacket.Properties.PayloadFormatIndicator = mqttV500PropertiesReader.ReadPayloadFormatIndicator();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.MessageExpiryInterval)
				{
					mqttPublishPacket.Properties.MessageExpiryInterval = mqttV500PropertiesReader.ReadMessageExpiryInterval();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.TopicAlias)
				{
					mqttPublishPacket.Properties.TopicAlias = mqttV500PropertiesReader.ReadTopicAlias();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ResponseTopic)
				{
					mqttPublishPacket.Properties.ResponseTopic = mqttV500PropertiesReader.ReadResponseTopic();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.CorrelationData)
				{
					mqttPublishPacket.Properties.CorrelationData = mqttV500PropertiesReader.ReadCorrelationData();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifier)
				{
					if (mqttPublishPacket.Properties.SubscriptionIdentifiers == null)
					{
						mqttPublishPacket.Properties.SubscriptionIdentifiers = new List<uint>();
					}
					mqttPublishPacket.Properties.SubscriptionIdentifiers.Add(mqttV500PropertiesReader.ReadSubscriptionIdentifier());
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ContentType)
				{
					mqttPublishPacket.Properties.ContentType = mqttV500PropertiesReader.ReadContentType();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttPublishPacket.Properties.UserProperties == null)
					{
						mqttPublishPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttPublishPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPublishPacket));
				}
			}
			if (!body.EndOfStream)
			{
				mqttPublishPacket.Payload = body.ReadRemainingData();
			}
			return mqttPublishPacket;
		}

		private static MqttBasePacket DecodePubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttPubAckPacket mqttPubAckPacket = new MqttPubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			if (body.EndOfStream)
			{
				mqttPubAckPacket.ReasonCode = MqttPubAckReasonCode.Success;
				return mqttPubAckPacket;
			}
			mqttPubAckPacket.ReasonCode = (MqttPubAckReasonCode)body.ReadByte();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttPubAckPacket.Properties == null)
				{
					mqttPubAckPacket.Properties = new MqttPubAckPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttPubAckPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttPubAckPacket.Properties.UserProperties == null)
					{
						mqttPubAckPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttPubAckPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubAckPacket));
				}
			}
			return mqttPubAckPacket;
		}

		private static MqttBasePacket DecodePubRecPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttPubRecPacket mqttPubRecPacket = new MqttPubRecPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			if (body.EndOfStream)
			{
				mqttPubRecPacket.ReasonCode = MqttPubRecReasonCode.Success;
				return mqttPubRecPacket;
			}
			mqttPubRecPacket.ReasonCode = (MqttPubRecReasonCode)body.ReadByte();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttPubRecPacket.Properties == null)
				{
					mqttPubRecPacket.Properties = new MqttPubRecPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttPubRecPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttPubRecPacket.Properties.UserProperties == null)
					{
						mqttPubRecPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttPubRecPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubRecPacket));
				}
			}
			return mqttPubRecPacket;
		}

		private static MqttBasePacket DecodePubRelPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttPubRelPacket mqttPubRelPacket = new MqttPubRelPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			if (body.EndOfStream)
			{
				mqttPubRelPacket.ReasonCode = MqttPubRelReasonCode.Success;
				return mqttPubRelPacket;
			}
			mqttPubRelPacket.ReasonCode = (MqttPubRelReasonCode)body.ReadByte();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttPubRelPacket.Properties == null)
				{
					mqttPubRelPacket.Properties = new MqttPubRelPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttPubRelPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttPubRelPacket.Properties.UserProperties == null)
					{
						mqttPubRelPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttPubRelPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubRelPacket));
				}
			}
			return mqttPubRelPacket;
		}

		private static MqttBasePacket DecodePubCompPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttPubCompPacket mqttPubCompPacket = new MqttPubCompPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			if (body.EndOfStream)
			{
				mqttPubCompPacket.ReasonCode = MqttPubCompReasonCode.Success;
				return mqttPubCompPacket;
			}
			mqttPubCompPacket.ReasonCode = (MqttPubCompReasonCode)body.ReadByte();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttPubCompPacket.Properties == null)
				{
					mqttPubCompPacket.Properties = new MqttPubCompPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttPubCompPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttPubCompPacket.Properties.UserProperties == null)
					{
						mqttPubCompPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttPubCompPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubCompPacket));
				}
			}
			return mqttPubCompPacket;
		}

		private static MqttBasePacket DecodeAuthPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttAuthPacket mqttAuthPacket = new MqttAuthPacket();
			if (body.EndOfStream)
			{
				mqttAuthPacket.ReasonCode = MqttAuthenticateReasonCode.Success;
				return mqttAuthPacket;
			}
			mqttAuthPacket.ReasonCode = (MqttAuthenticateReasonCode)body.ReadByte();
			MqttV500PropertiesReader mqttV500PropertiesReader = new MqttV500PropertiesReader(body);
			while (mqttV500PropertiesReader.MoveNext())
			{
				if (mqttAuthPacket.Properties == null)
				{
					mqttAuthPacket.Properties = new MqttAuthPacketProperties();
				}
				if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
				{
					mqttAuthPacket.Properties.AuthenticationMethod = mqttV500PropertiesReader.ReadAuthenticationMethod();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
				{
					mqttAuthPacket.Properties.AuthenticationData = mqttV500PropertiesReader.ReadAuthenticationData();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
				{
					mqttAuthPacket.Properties.ReasonString = mqttV500PropertiesReader.ReadReasonString();
				}
				else if (mqttV500PropertiesReader.CurrentPropertyId == MqttPropertyId.UserProperty)
				{
					if (mqttAuthPacket.Properties.UserProperties == null)
					{
						mqttAuthPacket.Properties.UserProperties = new List<MqttUserProperty>();
					}
					mqttV500PropertiesReader.AddUserPropertyTo(mqttAuthPacket.Properties.UserProperties);
				}
				else
				{
					mqttV500PropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttAuthPacket));
				}
			}
			return mqttAuthPacket;
		}

		private static void ThrowIfBodyIsEmpty(IMqttPacketBodyReader body)
		{
			if (body == null || body.Length == 0)
			{
				throw new MqttProtocolViolationException("Data from the body is required but not present.");
			}
		}
	}
	public class MqttV500PacketEncoder
	{
		private readonly IMqttPacketWriter _packetWriter;

		public MqttV500PacketEncoder()
			: this(new MqttPacketWriter())
		{
		}

		public MqttV500PacketEncoder(IMqttPacketWriter packetWriter)
		{
			_packetWriter = packetWriter;
		}

		public ArraySegment<byte> Encode(MqttBasePacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			_packetWriter.Reset(5);
			_packetWriter.Seek(5);
			byte value = EncodePacket(packet, _packetWriter);
			uint value2 = (uint)(_packetWriter.Length - 5);
			int lengthOfVariableInteger = MqttPacketWriter.GetLengthOfVariableInteger(value2);
			int num = 1 + lengthOfVariableInteger;
			int num2 = 5 - num;
			_packetWriter.Seek(num2);
			_packetWriter.Write(value);
			_packetWriter.WriteVariableLengthInteger(value2);
			return new ArraySegment<byte>(_packetWriter.GetBuffer(), num2, _packetWriter.Length - num2);
		}

		public void FreeBuffer()
		{
			_packetWriter.FreeBuffer();
		}

		private static byte EncodePacket(MqttBasePacket packet, IMqttPacketWriter packetWriter)
		{
			if (!(packet is MqttConnectPacket packet2))
			{
				if (!(packet is MqttConnAckPacket packet3))
				{
					if (!(packet is MqttDisconnectPacket packet4))
					{
						if (!(packet is MqttPingReqPacket))
						{
							if (!(packet is MqttPingRespPacket))
							{
								if (!(packet is MqttPublishPacket packet5))
								{
									if (!(packet is MqttPubAckPacket packet6))
									{
										if (!(packet is MqttPubRecPacket packet7))
										{
											if (!(packet is MqttPubRelPacket packet8))
											{
												if (!(packet is MqttPubCompPacket packet9))
												{
													if (!(packet is MqttSubscribePacket packet10))
													{
														if (!(packet is MqttSubAckPacket packet11))
														{
															if (!(packet is MqttUnsubscribePacket packet12))
															{
																if (!(packet is MqttUnsubAckPacket packet13))
																{
																	if (packet is MqttAuthPacket packet14)
																	{
																		return EncodeAuthPacket(packet14, packetWriter);
																	}
																	throw new MqttProtocolViolationException("Packet type invalid.");
																}
																return EncodeUnsubAckPacket(packet13, packetWriter);
															}
															return EncodeUnsubscribePacket(packet12, packetWriter);
														}
														return EncodeSubAckPacket(packet11, packetWriter);
													}
													return EncodeSubscribePacket(packet10, packetWriter);
												}
												return EncodePubCompPacket(packet9, packetWriter);
											}
											return EncodePubRelPacket(packet8, packetWriter);
										}
										return EncodePubRecPacket(packet7, packetWriter);
									}
									return EncodePubAckPacket(packet6, packetWriter);
								}
								return EncodePublishPacket(packet5, packetWriter);
							}
							return EncodePingRespPacket();
						}
						return EncodePingReqPacket();
					}
					return EncodeDisconnectPacket(packet4, packetWriter);
				}
				return EncodeConnAckPacket(packet3, packetWriter);
			}
			return EncodeConnectPacket(packet2, packetWriter);
		}

		private static byte EncodeConnectPacket(MqttConnectPacket packet, IMqttPacketWriter packetWriter)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (packetWriter == null)
			{
				throw new ArgumentNullException("packetWriter");
			}
			if (string.IsNullOrEmpty(packet.ClientId) && !packet.CleanSession)
			{
				throw new MqttProtocolViolationException("CleanSession must be set if ClientId is empty [MQTT-3.1.3-7].");
			}
			packetWriter.WriteWithLengthPrefix("MQTT");
			packetWriter.Write(5);
			byte b = 0;
			if (packet.CleanSession)
			{
				b |= 2;
			}
			if (packet.WillMessage != null)
			{
				b |= 4;
				b |= (byte)((byte)packet.WillMessage.QualityOfServiceLevel << 3);
				if (packet.WillMessage.Retain)
				{
					b |= 0x20;
				}
			}
			if (packet.Password != null && packet.Username == null)
			{
				throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
			}
			if (packet.Password != null)
			{
				b |= 0x40;
			}
			if (packet.Username != null)
			{
				b |= 0x80;
			}
			packetWriter.Write(b);
			packetWriter.Write(packet.KeepAlivePeriod);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteSessionExpiryInterval(packet.Properties.SessionExpiryInterval);
				mqttV500PropertiesWriter.WriteAuthenticationMethod(packet.Properties.AuthenticationMethod);
				mqttV500PropertiesWriter.WriteAuthenticationData(packet.Properties.AuthenticationData);
				mqttV500PropertiesWriter.WriteRequestProblemInformation(packet.Properties.RequestProblemInformation);
				mqttV500PropertiesWriter.WriteRequestResponseInformation(packet.Properties.RequestResponseInformation);
				mqttV500PropertiesWriter.WriteReceiveMaximum(packet.Properties.ReceiveMaximum);
				mqttV500PropertiesWriter.WriteTopicAliasMaximum(packet.Properties.TopicAliasMaximum);
				mqttV500PropertiesWriter.WriteMaximumPacketSize(packet.Properties.MaximumPacketSize);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			packetWriter.WriteWithLengthPrefix(packet.ClientId);
			if (packet.WillMessage != null)
			{
				MqttV500PropertiesWriter mqttV500PropertiesWriter2 = new MqttV500PropertiesWriter();
				mqttV500PropertiesWriter2.WritePayloadFormatIndicator(packet.WillMessage.PayloadFormatIndicator);
				mqttV500PropertiesWriter2.WriteMessageExpiryInterval(packet.WillMessage.MessageExpiryInterval);
				mqttV500PropertiesWriter2.WriteTopicAlias(packet.WillMessage.TopicAlias);
				mqttV500PropertiesWriter2.WriteResponseTopic(packet.WillMessage.ResponseTopic);
				mqttV500PropertiesWriter2.WriteCorrelationData(packet.WillMessage.CorrelationData);
				mqttV500PropertiesWriter2.WriteSubscriptionIdentifiers(packet.WillMessage.SubscriptionIdentifiers);
				mqttV500PropertiesWriter2.WriteContentType(packet.WillMessage.ContentType);
				mqttV500PropertiesWriter2.WriteUserProperties(packet.WillMessage.UserProperties);
				mqttV500PropertiesWriter2.WriteWillDelayInterval(packet.Properties?.WillDelayInterval);
				mqttV500PropertiesWriter2.WriteTo(packetWriter);
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Topic);
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Payload);
			}
			if (packet.Username != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Username);
			}
			if (packet.Password != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Password);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Connect, 0);
		}

		private static byte EncodeConnAckPacket(MqttConnAckPacket packet, IMqttPacketWriter packetWriter)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (packetWriter == null)
			{
				throw new ArgumentNullException("packetWriter");
			}
			if (!packet.ReasonCode.HasValue)
			{
				ThrowReasonCodeNotSetException();
			}
			byte b = 0;
			if (packet.IsSessionPresent)
			{
				b |= 1;
			}
			packetWriter.Write(b);
			packetWriter.Write((byte)packet.ReasonCode.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteSessionExpiryInterval(packet.Properties.SessionExpiryInterval);
				mqttV500PropertiesWriter.WriteAuthenticationMethod(packet.Properties.AuthenticationMethod);
				mqttV500PropertiesWriter.WriteAuthenticationData(packet.Properties.AuthenticationData);
				mqttV500PropertiesWriter.WriteRetainAvailable(packet.Properties.RetainAvailable);
				mqttV500PropertiesWriter.WriteReceiveMaximum(packet.Properties.ReceiveMaximum);
				mqttV500PropertiesWriter.WriteAssignedClientIdentifier(packet.Properties.AssignedClientIdentifier);
				mqttV500PropertiesWriter.WriteTopicAliasMaximum(packet.Properties.TopicAliasMaximum);
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteMaximumPacketSize(packet.Properties.MaximumPacketSize);
				mqttV500PropertiesWriter.WriteWildcardSubscriptionAvailable(packet.Properties.WildcardSubscriptionAvailable);
				mqttV500PropertiesWriter.WriteSubscriptionIdentifiersAvailable(packet.Properties.SubscriptionIdentifiersAvailable);
				mqttV500PropertiesWriter.WriteSharedSubscriptionAvailable(packet.Properties.SharedSubscriptionAvailable);
				mqttV500PropertiesWriter.WriteServerKeepAlive(packet.Properties.ServerKeepAlive);
				mqttV500PropertiesWriter.WriteResponseInformation(packet.Properties.ResponseInformation);
				mqttV500PropertiesWriter.WriteServerReference(packet.Properties.ServerReference);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.ConnAck, 0);
		}

		private static byte EncodePublishPacket(MqttPublishPacket packet, IMqttPacketWriter packetWriter)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (packetWriter == null)
			{
				throw new ArgumentNullException("packetWriter");
			}
			if (packet.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce && packet.Dup)
			{
				throw new MqttProtocolViolationException("Dup flag must be false for QoS 0 packets [MQTT-3.3.1-2].");
			}
			packetWriter.WriteWithLengthPrefix(packet.Topic);
			if (packet.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
			{
				if (!packet.PacketIdentifier.HasValue)
				{
					throw new MqttProtocolViolationException("Publish packet has no packet identifier.");
				}
				packetWriter.Write(packet.PacketIdentifier.Value);
			}
			else if (packet.PacketIdentifier > 0)
			{
				throw new MqttProtocolViolationException("Packet identifier must be 0 if QoS == 0 [MQTT-2.3.1-5].");
			}
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WritePayloadFormatIndicator(packet.Properties.PayloadFormatIndicator);
				mqttV500PropertiesWriter.WriteMessageExpiryInterval(packet.Properties.MessageExpiryInterval);
				mqttV500PropertiesWriter.WriteTopicAlias(packet.Properties.TopicAlias);
				mqttV500PropertiesWriter.WriteResponseTopic(packet.Properties.ResponseTopic);
				mqttV500PropertiesWriter.WriteCorrelationData(packet.Properties.CorrelationData);
				mqttV500PropertiesWriter.WriteSubscriptionIdentifiers(packet.Properties.SubscriptionIdentifiers);
				mqttV500PropertiesWriter.WriteContentType(packet.Properties.ContentType);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			byte[] payload = packet.Payload;
			if (payload != null && payload.Length != 0)
			{
				packetWriter.Write(packet.Payload, 0, packet.Payload.Length);
			}
			byte b = 0;
			if (packet.Retain)
			{
				b |= 1;
			}
			b |= (byte)((byte)packet.QualityOfServiceLevel << 1);
			if (packet.Dup)
			{
				b |= 8;
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Publish, b);
		}

		private static byte EncodePubAckPacket(MqttPubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (packetWriter == null)
			{
				throw new ArgumentNullException("packetWriter");
			}
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("PubAck packet has no packet identifier.");
			}
			if (!packet.ReasonCode.HasValue)
			{
				throw new MqttProtocolViolationException("PubAck packet must contain a reason code.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			if (packetWriter.Length > 0 || packet.ReasonCode.Value != MqttPubAckReasonCode.Success)
			{
				packetWriter.Write((byte)packet.ReasonCode.Value);
				mqttV500PropertiesWriter.WriteTo(packetWriter);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubAck, 0);
		}

		private static byte EncodePubRecPacket(MqttPubRecPacket packet, IMqttPacketWriter packetWriter)
		{
			ThrowIfPacketIdentifierIsInvalid(packet);
			if (!packet.ReasonCode.HasValue)
			{
				ThrowReasonCodeNotSetException();
			}
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			if (packetWriter.Length > 0 || packet.ReasonCode.Value != MqttPubRecReasonCode.Success)
			{
				packetWriter.Write((byte)packet.ReasonCode.Value);
				mqttV500PropertiesWriter.WriteTo(packetWriter);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubRec, 0);
		}

		private static byte EncodePubRelPacket(MqttPubRelPacket packet, IMqttPacketWriter packetWriter)
		{
			ThrowIfPacketIdentifierIsInvalid(packet);
			if (!packet.ReasonCode.HasValue)
			{
				ThrowReasonCodeNotSetException();
			}
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			if (mqttV500PropertiesWriter.Length > 0 || packet.ReasonCode.Value != MqttPubRelReasonCode.Success)
			{
				packetWriter.Write((byte)packet.ReasonCode.Value);
				mqttV500PropertiesWriter.WriteTo(packetWriter);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubRel, 2);
		}

		private static byte EncodePubCompPacket(MqttPubCompPacket packet, IMqttPacketWriter packetWriter)
		{
			ThrowIfPacketIdentifierIsInvalid(packet);
			if (!packet.ReasonCode.HasValue)
			{
				ThrowReasonCodeNotSetException();
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			if (mqttV500PropertiesWriter.Length > 0 || packet.ReasonCode.Value != MqttPubCompReasonCode.Success)
			{
				packetWriter.Write((byte)packet.ReasonCode.Value);
				mqttV500PropertiesWriter.WriteTo(packetWriter);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubComp, 0);
		}

		private static byte EncodeSubscribePacket(MqttSubscribePacket packet, IMqttPacketWriter packetWriter)
		{
			List<MqttTopicFilter> topicFilters = packet.TopicFilters;
			if (topicFilters == null || !topicFilters.Any())
			{
				throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.8.3-3].");
			}
			ThrowIfPacketIdentifierIsInvalid(packet);
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteSubscriptionIdentifier(packet.Properties.SubscriptionIdentifier);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			List<MqttTopicFilter> topicFilters2 = packet.TopicFilters;
			if (topicFilters2 != null && topicFilters2.Count > 0)
			{
				foreach (MqttTopicFilter topicFilter in packet.TopicFilters)
				{
					packetWriter.WriteWithLengthPrefix(topicFilter.Topic);
					byte b = (byte)topicFilter.QualityOfServiceLevel;
					if (topicFilter.NoLocal == true)
					{
						b |= 4;
					}
					if (topicFilter.RetainAsPublished == true)
					{
						b |= 8;
					}
					if (topicFilter.RetainHandling.HasValue)
					{
						b |= (byte)((byte)topicFilter.RetainHandling.Value << 4);
					}
					packetWriter.Write(b);
				}
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Subscribe, 2);
		}

		private static byte EncodeSubAckPacket(MqttSubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			List<MqttSubscribeReasonCode> reasonCodes = packet.ReasonCodes;
			if (reasonCodes == null || !reasonCodes.Any())
			{
				throw new MqttProtocolViolationException("At least one reason code must be set[MQTT - 3.8.3 - 3].");
			}
			ThrowIfPacketIdentifierIsInvalid(packet);
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			foreach (MqttSubscribeReasonCode reasonCode in packet.ReasonCodes)
			{
				packetWriter.Write((byte)reasonCode);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.SubAck, 0);
		}

		private static byte EncodeUnsubscribePacket(MqttUnsubscribePacket packet, IMqttPacketWriter packetWriter)
		{
			List<string> topicFilters = packet.TopicFilters;
			if (topicFilters == null || !topicFilters.Any())
			{
				throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.10.3-2].");
			}
			ThrowIfPacketIdentifierIsInvalid(packet);
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			foreach (string topicFilter in packet.TopicFilters)
			{
				packetWriter.WriteWithLengthPrefix(topicFilter);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Unsubscibe, 2);
		}

		private static byte EncodeUnsubAckPacket(MqttUnsubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			List<MqttUnsubscribeReasonCode> reasonCodes = packet.ReasonCodes;
			if (reasonCodes == null || !reasonCodes.Any())
			{
				throw new MqttProtocolViolationException("At least one reason code must be set[MQTT - 3.8.3 - 3].");
			}
			ThrowIfPacketIdentifierIsInvalid(packet);
			packetWriter.Write(packet.PacketIdentifier.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			foreach (MqttUnsubscribeReasonCode reasonCode in packet.ReasonCodes)
			{
				packetWriter.Write((byte)reasonCode);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.UnsubAck, 0);
		}

		private static byte EncodeDisconnectPacket(MqttDisconnectPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.ReasonCode.HasValue)
			{
				ThrowReasonCodeNotSetException();
			}
			packetWriter.Write((byte)packet.ReasonCode.Value);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteServerReference(packet.Properties.ServerReference);
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteSessionExpiryInterval(packet.Properties.SessionExpiryInterval);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Disconnect, 0);
		}

		private static byte EncodePingReqPacket()
		{
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PingReq, 0);
		}

		private static byte EncodePingRespPacket()
		{
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PingResp, 0);
		}

		private static byte EncodeAuthPacket(MqttAuthPacket packet, IMqttPacketWriter packetWriter)
		{
			packetWriter.Write((byte)packet.ReasonCode);
			MqttV500PropertiesWriter mqttV500PropertiesWriter = new MqttV500PropertiesWriter();
			if (packet.Properties != null)
			{
				mqttV500PropertiesWriter.WriteAuthenticationMethod(packet.Properties.AuthenticationMethod);
				mqttV500PropertiesWriter.WriteAuthenticationData(packet.Properties.AuthenticationData);
				mqttV500PropertiesWriter.WriteReasonString(packet.Properties.ReasonString);
				mqttV500PropertiesWriter.WriteUserProperties(packet.Properties.UserProperties);
			}
			mqttV500PropertiesWriter.WriteTo(packetWriter);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Auth, 0);
		}

		private static void ThrowReasonCodeNotSetException()
		{
			throw new MqttProtocolViolationException("The ReasonCode must be set for MQTT version 5.");
		}

		private static void ThrowIfPacketIdentifierIsInvalid(IMqttPacketWithIdentifier packet)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("Packet identifier is not set for " + packet.GetType().Name + ".");
			}
		}
	}
	public class MqttV500PacketFormatter : IMqttPacketFormatter
	{
		private readonly MqttV500PacketEncoder _encoder;

		private readonly MqttV500PacketDecoder _decoder = new MqttV500PacketDecoder();

		public IMqttDataConverter DataConverter { get; } = new MqttV500DataConverter();

		public MqttV500PacketFormatter()
		{
			_encoder = new MqttV500PacketEncoder();
		}

		public MqttV500PacketFormatter(IMqttPacketWriter writer)
		{
			_encoder = new MqttV500PacketEncoder(writer);
		}

		public ArraySegment<byte> Encode(MqttBasePacket mqttPacket)
		{
			if (mqttPacket == null)
			{
				throw new ArgumentNullException("mqttPacket");
			}
			return _encoder.Encode(mqttPacket);
		}

		public MqttBasePacket Decode(ReceivedMqttPacket receivedMqttPacket)
		{
			if (receivedMqttPacket == null)
			{
				throw new ArgumentNullException("receivedMqttPacket");
			}
			return _decoder.Decode(receivedMqttPacket);
		}

		public void FreeBuffer()
		{
			_encoder.FreeBuffer();
		}
	}
	public class MqttV500PropertiesReader
	{
		private readonly IMqttPacketBodyReader _body;

		private readonly int _length;

		private readonly int _targetOffset;

		public MqttPropertyId CurrentPropertyId { get; private set; }

		public MqttV500PropertiesReader(IMqttPacketBodyReader body)
		{
			_body = body ?? throw new ArgumentNullException("body");
			if (!body.EndOfStream)
			{
				_length = (int)body.ReadVariableLengthInteger();
			}
			_targetOffset = body.Offset + _length;
		}

		public bool MoveNext()
		{
			if (_length == 0)
			{
				return false;
			}
			if (_body.Offset >= _targetOffset)
			{
				return false;
			}
			CurrentPropertyId = (MqttPropertyId)_body.ReadByte();
			return true;
		}

		public void AddUserPropertyTo(List<MqttUserProperty> userProperties)
		{
			if (userProperties == null)
			{
				throw new ArgumentNullException("userProperties");
			}
			string name = _body.ReadStringWithLengthPrefix();
			string value = _body.ReadStringWithLengthPrefix();
			userProperties.Add(new MqttUserProperty(name, value));
		}

		public string ReadReasonString()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public string ReadAuthenticationMethod()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public byte[] ReadAuthenticationData()
		{
			return _body.ReadWithLengthPrefix();
		}

		public bool ReadRetainAvailable()
		{
			return _body.ReadBoolean();
		}

		public uint ReadSessionExpiryInterval()
		{
			return _body.ReadFourByteInteger();
		}

		public ushort ReadReceiveMaximum()
		{
			return _body.ReadTwoByteInteger();
		}

		public string ReadAssignedClientIdentifier()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public string ReadServerReference()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public ushort ReadTopicAliasMaximum()
		{
			return _body.ReadTwoByteInteger();
		}

		public uint ReadMaximumPacketSize()
		{
			return _body.ReadFourByteInteger();
		}

		public ushort ReadServerKeepAlive()
		{
			return _body.ReadTwoByteInteger();
		}

		public string ReadResponseInformation()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public bool ReadSharedSubscriptionAvailable()
		{
			return _body.ReadBoolean();
		}

		public bool ReadSubscriptionIdentifiersAvailable()
		{
			return _body.ReadBoolean();
		}

		public bool ReadWildcardSubscriptionAvailable()
		{
			return _body.ReadBoolean();
		}

		public uint ReadSubscriptionIdentifier()
		{
			return _body.ReadVariableLengthInteger();
		}

		public MqttPayloadFormatIndicator? ReadPayloadFormatIndicator()
		{
			return (MqttPayloadFormatIndicator)_body.ReadByte();
		}

		public uint ReadMessageExpiryInterval()
		{
			return _body.ReadFourByteInteger();
		}

		public ushort ReadTopicAlias()
		{
			return _body.ReadTwoByteInteger();
		}

		public string ReadResponseTopic()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public byte[] ReadCorrelationData()
		{
			return _body.ReadWithLengthPrefix();
		}

		public string ReadContentType()
		{
			return _body.ReadStringWithLengthPrefix();
		}

		public uint ReadWillDelayInterval()
		{
			return _body.ReadFourByteInteger();
		}

		public bool RequestResponseInformation()
		{
			return _body.ReadBoolean();
		}

		public bool RequestProblemInformation()
		{
			return _body.ReadBoolean();
		}

		public void ThrowInvalidPropertyIdException(Type type)
		{
			throw new MqttProtocolViolationException($"Property ID '{CurrentPropertyId}' is not supported for package type '{type.Name}'.");
		}
	}
	public class MqttV500PropertiesWriter
	{
		private readonly MqttPacketWriter _packetWriter = new MqttPacketWriter();

		public int Length => _packetWriter.Length;

		public void WriteUserProperties(List<MqttUserProperty> userProperties)
		{
			if (userProperties == null || userProperties.Count == 0)
			{
				return;
			}
			foreach (MqttUserProperty userProperty in userProperties)
			{
				_packetWriter.Write(38);
				_packetWriter.WriteWithLengthPrefix(userProperty.Name);
				_packetWriter.WriteWithLengthPrefix(userProperty.Value);
			}
		}

		public void WriteCorrelationData(byte[] value)
		{
			Write(MqttPropertyId.CorrelationData, value);
		}

		public void WriteAuthenticationData(byte[] value)
		{
			Write(MqttPropertyId.AuthenticationData, value);
		}

		public void WriteReasonString(string value)
		{
			Write(MqttPropertyId.ReasonString, value);
		}

		public void WriteResponseTopic(string value)
		{
			Write(MqttPropertyId.ResponseTopic, value);
		}

		public void WriteContentType(string value)
		{
			Write(MqttPropertyId.ContentType, value);
		}

		public void WriteServerReference(string value)
		{
			Write(MqttPropertyId.ServerReference, value);
		}

		public void WriteAuthenticationMethod(string value)
		{
			Write(MqttPropertyId.AuthenticationMethod, value);
		}

		public void WriteTo(IMqttPacketWriter packetWriter)
		{
			if (packetWriter == null)
			{
				throw new ArgumentNullException("packetWriter");
			}
			packetWriter.WriteVariableLengthInteger((uint)_packetWriter.Length);
			packetWriter.Write(_packetWriter);
		}

		public void WriteSessionExpiryInterval(uint? value)
		{
			WriteAsFourByteInteger(MqttPropertyId.SessionExpiryInterval, value);
		}

		public void WriteSubscriptionIdentifier(uint? value)
		{
			WriteAsVariableLengthInteger(MqttPropertyId.SubscriptionIdentifier, value);
		}

		public void WriteSubscriptionIdentifiers(IEnumerable<uint> value)
		{
			if (value == null)
			{
				return;
			}
			foreach (uint item in value)
			{
				WriteAsVariableLengthInteger(MqttPropertyId.SubscriptionIdentifier, item);
			}
		}

		public void WriteTopicAlias(ushort? value)
		{
			Write(MqttPropertyId.TopicAlias, value);
		}

		public void WriteMessageExpiryInterval(uint? value)
		{
			WriteAsFourByteInteger(MqttPropertyId.MessageExpiryInterval, value);
		}

		public void WritePayloadFormatIndicator(MqttPayloadFormatIndicator? value)
		{
			if (value.HasValue)
			{
				Write(MqttPropertyId.PayloadFormatIndicator, (byte)value.Value);
			}
		}

		public void WriteWillDelayInterval(uint? value)
		{
			WriteAsFourByteInteger(MqttPropertyId.WillDelayInterval, value);
		}

		public void WriteRequestProblemInformation(bool? value)
		{
			Write(MqttPropertyId.RequestProblemInformation, value);
		}

		public void WriteRequestResponseInformation(bool? value)
		{
			Write(MqttPropertyId.RequestResponseInformation, value);
		}

		public void WriteReceiveMaximum(ushort? value)
		{
			Write(MqttPropertyId.ReceiveMaximum, value);
		}

		public void WriteMaximumPacketSize(uint? value)
		{
			WriteAsFourByteInteger(MqttPropertyId.MaximumPacketSize, value);
		}

		public void WriteRetainAvailable(bool? value)
		{
			Write(MqttPropertyId.RetainAvailable, value);
		}

		public void WriteAssignedClientIdentifier(string value)
		{
			Write(MqttPropertyId.AssignedClientIdentifier, value);
		}

		public void WriteTopicAliasMaximum(ushort? value)
		{
			Write(MqttPropertyId.TopicAliasMaximum, value);
		}

		public void WriteWildcardSubscriptionAvailable(bool? value)
		{
			Write(MqttPropertyId.WildcardSubscriptionAvailable, value);
		}

		public void WriteSubscriptionIdentifiersAvailable(bool? value)
		{
			Write(MqttPropertyId.SubscriptionIdentifiersAvailable, value);
		}

		public void WriteSharedSubscriptionAvailable(bool? value)
		{
			Write(MqttPropertyId.SharedSubscriptionAvailable, value);
		}

		public void WriteServerKeepAlive(ushort? value)
		{
			Write(MqttPropertyId.ServerKeepAlive, value);
		}

		public void WriteResponseInformation(string value)
		{
			Write(MqttPropertyId.ResponseInformation, value);
		}

		private void Write(MqttPropertyId id, bool? value)
		{
			if (value.HasValue)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.Write((byte)(value.Value ? 1 : 0));
			}
		}

		private void Write(MqttPropertyId id, byte? value)
		{
			if (value.HasValue)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.Write(value.Value);
			}
		}

		private void Write(MqttPropertyId id, ushort? value)
		{
			if (value.HasValue)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.Write(value.Value);
			}
		}

		private void WriteAsVariableLengthInteger(MqttPropertyId id, uint? value)
		{
			if (value.HasValue)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.WriteVariableLengthInteger(value.Value);
			}
		}

		private void WriteAsFourByteInteger(MqttPropertyId id, uint? value)
		{
			if (value.HasValue)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.Write((byte)(value.Value >> 24));
				_packetWriter.Write((byte)(value.Value >> 16));
				_packetWriter.Write((byte)(value.Value >> 8));
				_packetWriter.Write((byte)value.Value);
			}
		}

		private void Write(MqttPropertyId id, string value)
		{
			if (value != null)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.WriteWithLengthPrefix(value);
			}
		}

		private void Write(MqttPropertyId id, byte[] value)
		{
			if (value != null)
			{
				_packetWriter.Write((byte)id);
				_packetWriter.WriteWithLengthPrefix(value);
			}
		}
	}
}
namespace MQTTnet.Formatter.V3
{
	public class MqttV310DataConverter : IMqttDataConverter
	{
		public MqttPublishPacket CreatePublishPacket(MqttApplicationMessage applicationMessage)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			return new MqttPublishPacket
			{
				Topic = applicationMessage.Topic,
				Payload = applicationMessage.Payload,
				QualityOfServiceLevel = applicationMessage.QualityOfServiceLevel,
				Retain = applicationMessage.Retain,
				Dup = false
			};
		}

		public MqttPubAckPacket CreatePubAckPacket(MqttPublishPacket publishPacket)
		{
			return new MqttPubAckPacket
			{
				PacketIdentifier = publishPacket.PacketIdentifier,
				ReasonCode = MqttPubAckReasonCode.Success
			};
		}

		public MqttApplicationMessage CreateApplicationMessage(MqttPublishPacket publishPacket)
		{
			if (publishPacket == null)
			{
				throw new ArgumentNullException("publishPacket");
			}
			return new MqttApplicationMessage
			{
				Topic = publishPacket.Topic,
				Payload = publishPacket.Payload,
				QualityOfServiceLevel = publishPacket.QualityOfServiceLevel,
				Retain = publishPacket.Retain
			};
		}

		public MqttClientAuthenticateResult CreateClientConnectResult(MqttConnAckPacket connAckPacket)
		{
			if (connAckPacket == null)
			{
				throw new ArgumentNullException("connAckPacket");
			}
			MqttClientConnectResultCode resultCode = connAckPacket.ReturnCode.Value switch
			{
				MqttConnectReturnCode.ConnectionAccepted => MqttClientConnectResultCode.Success, 
				MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion => MqttClientConnectResultCode.UnsupportedProtocolVersion, 
				MqttConnectReturnCode.ConnectionRefusedNotAuthorized => MqttClientConnectResultCode.NotAuthorized, 
				MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword => MqttClientConnectResultCode.BadUserNameOrPassword, 
				MqttConnectReturnCode.ConnectionRefusedIdentifierRejected => MqttClientConnectResultCode.ClientIdentifierNotValid, 
				MqttConnectReturnCode.ConnectionRefusedServerUnavailable => MqttClientConnectResultCode.ServerUnavailable, 
				_ => throw new MqttProtocolViolationException("Received unexpected return code."), 
			};
			return new MqttClientAuthenticateResult
			{
				IsSessionPresent = connAckPacket.IsSessionPresent,
				ResultCode = resultCode
			};
		}

		public MqttConnectPacket CreateConnectPacket(MqttApplicationMessage willApplicationMessage, IMqttClientOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			return new MqttConnectPacket
			{
				ClientId = options.ClientId,
				Username = options.Credentials?.Username,
				Password = options.Credentials?.Password,
				CleanSession = options.CleanSession,
				KeepAlivePeriod = (ushort)options.KeepAlivePeriod.TotalSeconds,
				WillMessage = willApplicationMessage
			};
		}

		public MqttConnAckPacket CreateConnAckPacket(MqttConnectionValidatorContext connectionValidatorContext)
		{
			if (connectionValidatorContext == null)
			{
				throw new ArgumentNullException("connectionValidatorContext");
			}
			return new MqttConnAckPacket
			{
				ReturnCode = new MqttConnectReasonCodeConverter().ToConnectReturnCode(connectionValidatorContext.ReasonCode)
			};
		}

		public MQTTnet.Client.Subscribing.MqttClientSubscribeResult CreateClientSubscribeResult(MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
		{
			if (subscribePacket == null)
			{
				throw new ArgumentNullException("subscribePacket");
			}
			if (subAckPacket == null)
			{
				throw new ArgumentNullException("subAckPacket");
			}
			if (subAckPacket.ReturnCodes.Count != subscribePacket.TopicFilters.Count)
			{
				throw new MqttProtocolViolationException("The return codes are not matching the topic filters [MQTT-3.9.3-1].");
			}
			MQTTnet.Client.Subscribing.MqttClientSubscribeResult mqttClientSubscribeResult = new MQTTnet.Client.Subscribing.MqttClientSubscribeResult();
			mqttClientSubscribeResult.Items.AddRange(subscribePacket.TopicFilters.Select((MqttTopicFilter t, int i) => new MqttClientSubscribeResultItem(t, (MqttClientSubscribeResultCode)subAckPacket.ReturnCodes[i])));
			return mqttClientSubscribeResult;
		}

		public MqttClientUnsubscribeResult CreateClientUnsubscribeResult(MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
		{
			if (unsubscribePacket == null)
			{
				throw new ArgumentNullException("unsubscribePacket");
			}
			if (unsubAckPacket == null)
			{
				throw new ArgumentNullException("unsubAckPacket");
			}
			MqttClientUnsubscribeResult mqttClientUnsubscribeResult = new MqttClientUnsubscribeResult();
			mqttClientUnsubscribeResult.Items.AddRange(unsubscribePacket.TopicFilters.Select((string t, int i) => new MqttClientUnsubscribeResultItem(t, MqttClientUnsubscribeResultCode.Success)));
			return mqttClientUnsubscribeResult;
		}

		public MqttSubscribePacket CreateSubscribePacket(MqttClientSubscribeOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			MqttSubscribePacket mqttSubscribePacket = new MqttSubscribePacket();
			mqttSubscribePacket.TopicFilters.AddRange(options.TopicFilters);
			return mqttSubscribePacket;
		}

		public MqttUnsubscribePacket CreateUnsubscribePacket(MqttClientUnsubscribeOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			MqttUnsubscribePacket mqttUnsubscribePacket = new MqttUnsubscribePacket();
			mqttUnsubscribePacket.TopicFilters.AddRange(options.TopicFilters);
			return mqttUnsubscribePacket;
		}

		public MqttDisconnectPacket CreateDisconnectPacket(MqttClientDisconnectOptions options)
		{
			if (options.ReasonCode != MqttClientDisconnectReason.NormalDisconnection || options.ReasonString != null)
			{
				throw new MqttProtocolViolationException("Reason codes and reason string for disconnect are only supported for MQTTv5.");
			}
			return new MqttDisconnectPacket();
		}

		public MqttClientPublishResult CreatePublishResult(MqttPubAckPacket pubAckPacket)
		{
			return new MqttClientPublishResult
			{
				PacketIdentifier = pubAckPacket?.PacketIdentifier,
				ReasonCode = MqttClientPublishReasonCode.Success
			};
		}

		public MqttClientPublishResult CreatePublishResult(MqttPubRecPacket pubRecPacket, MqttPubCompPacket pubCompPacket)
		{
			if (pubRecPacket == null || pubCompPacket == null)
			{
				return new MqttClientPublishResult
				{
					ReasonCode = MqttClientPublishReasonCode.UnspecifiedError
				};
			}
			return new MqttClientPublishResult
			{
				PacketIdentifier = pubCompPacket.PacketIdentifier,
				ReasonCode = MqttClientPublishReasonCode.Success
			};
		}
	}
	public class MqttV310PacketFormatter : IMqttPacketFormatter
	{
		private const int FixedHeaderSize = 1;

		private static readonly MqttPingReqPacket PingReqPacket = new MqttPingReqPacket();

		private static readonly MqttPingRespPacket PingRespPacket = new MqttPingRespPacket();

		private static readonly MqttDisconnectPacket DisconnectPacket = new MqttDisconnectPacket();

		private readonly IMqttPacketWriter _packetWriter;

		public IMqttDataConverter DataConverter { get; } = new MqttV310DataConverter();

		public MqttV310PacketFormatter(IMqttPacketWriter packetWriter)
		{
			_packetWriter = packetWriter;
		}

		public ArraySegment<byte> Encode(MqttBasePacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			_packetWriter.Reset(5);
			_packetWriter.Seek(5);
			byte value = EncodePacket(packet, _packetWriter);
			uint value2 = (uint)(_packetWriter.Length - 5);
			int lengthOfVariableInteger = MqttPacketWriter.GetLengthOfVariableInteger(value2);
			int num = 1 + lengthOfVariableInteger;
			int num2 = 5 - num;
			_packetWriter.Seek(num2);
			_packetWriter.Write(value);
			_packetWriter.WriteVariableLengthInteger(value2);
			return new ArraySegment<byte>(_packetWriter.GetBuffer(), num2, _packetWriter.Length - num2);
		}

		public MqttBasePacket Decode(ReceivedMqttPacket receivedMqttPacket)
		{
			if (receivedMqttPacket == null)
			{
				throw new ArgumentNullException("receivedMqttPacket");
			}
			int num = receivedMqttPacket.FixedHeader >> 4;
			if (num < 1 || num > 14)
			{
				throw new MqttProtocolViolationException($"The packet type is invalid ({num}).");
			}
			return (MqttControlPacketType)num switch
			{
				MqttControlPacketType.Connect => DecodeConnectPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.ConnAck => DecodeConnAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Disconnect => DisconnectPacket, 
				MqttControlPacketType.Publish => DecodePublishPacket(receivedMqttPacket), 
				MqttControlPacketType.PubAck => DecodePubAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubRec => DecodePubRecPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubRel => DecodePubRelPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PubComp => DecodePubCompPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.PingReq => PingReqPacket, 
				MqttControlPacketType.PingResp => PingRespPacket, 
				MqttControlPacketType.Subscribe => DecodeSubscribePacket(receivedMqttPacket.Body), 
				MqttControlPacketType.SubAck => DecodeSubAckPacket(receivedMqttPacket.Body), 
				MqttControlPacketType.Unsubscibe => DecodeUnsubscribePacket(receivedMqttPacket.Body), 
				MqttControlPacketType.UnsubAck => DecodeUnsubAckPacket(receivedMqttPacket.Body), 
				_ => throw new MqttProtocolViolationException($"Packet type ({num}) not supported."), 
			};
		}

		public void FreeBuffer()
		{
			_packetWriter.FreeBuffer();
		}

		private byte EncodePacket(MqttBasePacket packet, IMqttPacketWriter packetWriter)
		{
			if (!(packet is MqttConnectPacket packet2))
			{
				if (!(packet is MqttConnAckPacket packet3))
				{
					if (!(packet is MqttDisconnectPacket))
					{
						if (!(packet is MqttPingReqPacket))
						{
							if (!(packet is MqttPingRespPacket))
							{
								if (!(packet is MqttPublishPacket packet4))
								{
									if (!(packet is MqttPubAckPacket packet5))
									{
										if (!(packet is MqttPubRecPacket packet6))
										{
											if (!(packet is MqttPubRelPacket packet7))
											{
												if (!(packet is MqttPubCompPacket packet8))
												{
													if (!(packet is MqttSubscribePacket packet9))
													{
														if (!(packet is MqttSubAckPacket packet10))
														{
															if (!(packet is MqttUnsubscribePacket packet11))
															{
																if (packet is MqttUnsubAckPacket packet12)
																{
																	return EncodeUnsubAckPacket(packet12, packetWriter);
																}
																throw new MqttProtocolViolationException("Packet type invalid.");
															}
															return EncodeUnsubscribePacket(packet11, packetWriter);
														}
														return EncodeSubAckPacket(packet10, packetWriter);
													}
													return EncodeSubscribePacket(packet9, packetWriter);
												}
												return EncodePubCompPacket(packet8, packetWriter);
											}
											return EncodePubRelPacket(packet7, packetWriter);
										}
										return EncodePubRecPacket(packet6, packetWriter);
									}
									return EncodePubAckPacket(packet5, packetWriter);
								}
								return EncodePublishPacket(packet4, packetWriter);
							}
							return EncodeEmptyPacket(MqttControlPacketType.PingResp);
						}
						return EncodeEmptyPacket(MqttControlPacketType.PingReq);
					}
					return EncodeEmptyPacket(MqttControlPacketType.Disconnect);
				}
				return EncodeConnAckPacket(packet3, packetWriter);
			}
			return EncodeConnectPacket(packet2, packetWriter);
		}

		private static MqttBasePacket DecodeUnsubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			return new MqttUnsubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
		}

		private static MqttBasePacket DecodePubCompPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			return new MqttPubCompPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
		}

		private static MqttBasePacket DecodePubRelPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			return new MqttPubRelPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
		}

		private static MqttBasePacket DecodePubRecPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			return new MqttPubRecPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
		}

		private static MqttBasePacket DecodePubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			return new MqttPubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
		}

		private static MqttBasePacket DecodeUnsubscribePacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttUnsubscribePacket mqttUnsubscribePacket = new MqttUnsubscribePacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			while (!body.EndOfStream)
			{
				mqttUnsubscribePacket.TopicFilters.Add(body.ReadStringWithLengthPrefix());
			}
			return mqttUnsubscribePacket;
		}

		private static MqttBasePacket DecodeSubscribePacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttSubscribePacket mqttSubscribePacket = new MqttSubscribePacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			while (!body.EndOfStream)
			{
				MqttTopicFilter item = new MqttTopicFilter
				{
					Topic = body.ReadStringWithLengthPrefix(),
					QualityOfServiceLevel = (MqttQualityOfServiceLevel)body.ReadByte()
				};
				mqttSubscribePacket.TopicFilters.Add(item);
			}
			return mqttSubscribePacket;
		}

		private static MqttBasePacket DecodePublishPacket(ReceivedMqttPacket receivedMqttPacket)
		{
			ThrowIfBodyIsEmpty(receivedMqttPacket.Body);
			bool retain = (receivedMqttPacket.FixedHeader & 1) > 0;
			MqttQualityOfServiceLevel mqttQualityOfServiceLevel = (MqttQualityOfServiceLevel)((receivedMqttPacket.FixedHeader >> 1) & 3);
			bool dup = (receivedMqttPacket.FixedHeader & 8) > 0;
			string topic = receivedMqttPacket.Body.ReadStringWithLengthPrefix();
			ushort? packetIdentifier = null;
			if (mqttQualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
			{
				packetIdentifier = receivedMqttPacket.Body.ReadTwoByteInteger();
			}
			MqttPublishPacket mqttPublishPacket = new MqttPublishPacket
			{
				PacketIdentifier = packetIdentifier,
				Retain = retain,
				Topic = topic,
				QualityOfServiceLevel = mqttQualityOfServiceLevel,
				Dup = dup
			};
			if (!receivedMqttPacket.Body.EndOfStream)
			{
				mqttPublishPacket.Payload = receivedMqttPacket.Body.ReadRemainingData();
			}
			return mqttPublishPacket;
		}

		private MqttBasePacket DecodeConnectPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			string text = body.ReadStringWithLengthPrefix();
			byte b = body.ReadByte();
			if (text != "MQTT" && text != "MQIsdp")
			{
				throw new MqttProtocolViolationException("MQTT protocol name do not match MQTT v3.");
			}
			if (b != 3 && b != 4)
			{
				throw new MqttProtocolViolationException("MQTT protocol version do not match MQTT v3.");
			}
			MqttConnectPacket mqttConnectPacket = new MqttConnectPacket();
			byte b2 = body.ReadByte();
			if ((b2 & 1) > 0)
			{
				throw new MqttProtocolViolationException("The first bit of the Connect Flags must be set to 0.");
			}
			mqttConnectPacket.CleanSession = (b2 & 2) > 0;
			bool flag = (b2 & 4) > 0;
			int qualityOfServiceLevel = (b2 & 0x18) >> 3;
			bool retain = (b2 & 0x20) > 0;
			bool num = (b2 & 0x40) > 0;
			bool num2 = (b2 & 0x80) > 0;
			mqttConnectPacket.KeepAlivePeriod = body.ReadTwoByteInteger();
			mqttConnectPacket.ClientId = body.ReadStringWithLengthPrefix();
			if (flag)
			{
				mqttConnectPacket.WillMessage = new MqttApplicationMessage
				{
					Topic = body.ReadStringWithLengthPrefix(),
					Payload = body.ReadWithLengthPrefix(),
					QualityOfServiceLevel = (MqttQualityOfServiceLevel)qualityOfServiceLevel,
					Retain = retain
				};
			}
			if (num2)
			{
				mqttConnectPacket.Username = body.ReadStringWithLengthPrefix();
			}
			if (num)
			{
				mqttConnectPacket.Password = body.ReadWithLengthPrefix();
			}
			ValidateConnectPacket(mqttConnectPacket);
			return mqttConnectPacket;
		}

		private static MqttBasePacket DecodeSubAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttSubAckPacket mqttSubAckPacket = new MqttSubAckPacket
			{
				PacketIdentifier = body.ReadTwoByteInteger()
			};
			while (!body.EndOfStream)
			{
				mqttSubAckPacket.ReturnCodes.Add((MqttSubscribeReturnCode)body.ReadByte());
			}
			return mqttSubAckPacket;
		}

		protected virtual MqttBasePacket DecodeConnAckPacket(IMqttPacketBodyReader body)
		{
			ThrowIfBodyIsEmpty(body);
			MqttConnAckPacket mqttConnAckPacket = new MqttConnAckPacket();
			body.ReadByte();
			mqttConnAckPacket.ReturnCode = (MqttConnectReturnCode)body.ReadByte();
			return mqttConnAckPacket;
		}

		protected void ValidateConnectPacket(MqttConnectPacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet");
			}
			if (string.IsNullOrEmpty(packet.ClientId) && !packet.CleanSession)
			{
				throw new MqttProtocolViolationException("CleanSession must be set if ClientId is empty [MQTT-3.1.3-7].");
			}
		}

		private static void ValidatePublishPacket(MqttPublishPacket packet)
		{
			if (packet.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce && packet.Dup)
			{
				throw new MqttProtocolViolationException("Dup flag must be false for QoS 0 packets [MQTT-3.3.1-2].");
			}
		}

		protected virtual byte EncodeConnectPacket(MqttConnectPacket packet, IMqttPacketWriter packetWriter)
		{
			ValidateConnectPacket(packet);
			packetWriter.WriteWithLengthPrefix("MQIsdp");
			packetWriter.Write(3);
			byte b = 0;
			if (packet.CleanSession)
			{
				b |= 2;
			}
			if (packet.WillMessage != null)
			{
				b |= 4;
				b |= (byte)((byte)packet.WillMessage.QualityOfServiceLevel << 3);
				if (packet.WillMessage.Retain)
				{
					b |= 0x20;
				}
			}
			if (packet.Password != null && packet.Username == null)
			{
				throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
			}
			if (packet.Password != null)
			{
				b |= 0x40;
			}
			if (packet.Username != null)
			{
				b |= 0x80;
			}
			packetWriter.Write(b);
			packetWriter.Write(packet.KeepAlivePeriod);
			packetWriter.WriteWithLengthPrefix(packet.ClientId);
			if (packet.WillMessage != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Topic);
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Payload);
			}
			if (packet.Username != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Username);
			}
			if (packet.Password != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Password);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Connect, 0);
		}

		protected virtual byte EncodeConnAckPacket(MqttConnAckPacket packet, IMqttPacketWriter packetWriter)
		{
			packetWriter.Write(0);
			packetWriter.Write((byte)packet.ReturnCode.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.ConnAck, 0);
		}

		private static byte EncodePubRelPacket(MqttPubRelPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("PubRel packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubRel, 2);
		}

		private static byte EncodePublishPacket(MqttPublishPacket packet, IMqttPacketWriter packetWriter)
		{
			ValidatePublishPacket(packet);
			packetWriter.WriteWithLengthPrefix(packet.Topic);
			if (packet.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
			{
				if (!packet.PacketIdentifier.HasValue)
				{
					throw new MqttProtocolViolationException("Publish packet has no packet identifier.");
				}
				packetWriter.Write(packet.PacketIdentifier.Value);
			}
			else if (packet.PacketIdentifier > 0)
			{
				throw new MqttProtocolViolationException("Packet identifier must be empty if QoS == 0 [MQTT-2.3.1-5].");
			}
			byte[] payload = packet.Payload;
			if (payload != null && payload.Length != 0)
			{
				packetWriter.Write(packet.Payload, 0, packet.Payload.Length);
			}
			byte b = 0;
			if (packet.Retain)
			{
				b |= 1;
			}
			b |= (byte)((byte)packet.QualityOfServiceLevel << 1);
			if (packet.Dup)
			{
				b |= 8;
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Publish, b);
		}

		private static byte EncodePubAckPacket(MqttPubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("PubAck packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubAck, 0);
		}

		private static byte EncodePubRecPacket(MqttPubRecPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("PubRec packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubRec, 0);
		}

		private static byte EncodePubCompPacket(MqttPubCompPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("PubComp packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.PubComp, 0);
		}

		private static byte EncodeSubscribePacket(MqttSubscribePacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.TopicFilters.Any())
			{
				throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.8.3-3].");
			}
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("Subscribe packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			List<MqttTopicFilter> topicFilters = packet.TopicFilters;
			if (topicFilters != null && topicFilters.Count > 0)
			{
				foreach (MqttTopicFilter topicFilter in packet.TopicFilters)
				{
					packetWriter.WriteWithLengthPrefix(topicFilter.Topic);
					packetWriter.Write((byte)topicFilter.QualityOfServiceLevel);
				}
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Subscribe, 2);
		}

		private static byte EncodeSubAckPacket(MqttSubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("SubAck packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			List<MqttSubscribeReturnCode> returnCodes = packet.ReturnCodes;
			if (returnCodes != null && returnCodes.Any())
			{
				foreach (MqttSubscribeReturnCode returnCode in packet.ReturnCodes)
				{
					packetWriter.Write((byte)returnCode);
				}
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.SubAck, 0);
		}

		private static byte EncodeUnsubscribePacket(MqttUnsubscribePacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.TopicFilters.Any())
			{
				throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.10.3-2].");
			}
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("Unsubscribe packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			List<string> topicFilters = packet.TopicFilters;
			if (topicFilters != null && topicFilters.Any())
			{
				foreach (string topicFilter in packet.TopicFilters)
				{
					packetWriter.WriteWithLengthPrefix(topicFilter);
				}
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Unsubscibe, 2);
		}

		private static byte EncodeUnsubAckPacket(MqttUnsubAckPacket packet, IMqttPacketWriter packetWriter)
		{
			if (!packet.PacketIdentifier.HasValue)
			{
				throw new MqttProtocolViolationException("UnsubAck packet has no packet identifier.");
			}
			packetWriter.Write(packet.PacketIdentifier.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.UnsubAck, 0);
		}

		private static byte EncodeEmptyPacket(MqttControlPacketType type)
		{
			return MqttPacketWriter.BuildFixedHeader(type, 0);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static void ThrowIfBodyIsEmpty(IMqttPacketBodyReader body)
		{
			if (body == null || body.Length == 0)
			{
				throw new MqttProtocolViolationException("Data from the body is required but not present.");
			}
		}
	}
	public class MqttV311PacketFormatter : MqttV310PacketFormatter
	{
		public MqttV311PacketFormatter(IMqttPacketWriter packetWriter)
			: base(packetWriter)
		{
		}

		protected override byte EncodeConnectPacket(MqttConnectPacket packet, IMqttPacketWriter packetWriter)
		{
			ValidateConnectPacket(packet);
			packetWriter.WriteWithLengthPrefix("MQTT");
			packetWriter.Write(4);
			byte b = 0;
			if (packet.CleanSession)
			{
				b |= 2;
			}
			if (packet.WillMessage != null)
			{
				b |= 4;
				b |= (byte)((byte)packet.WillMessage.QualityOfServiceLevel << 3);
				if (packet.WillMessage.Retain)
				{
					b |= 0x20;
				}
			}
			if (packet.Password != null && packet.Username == null)
			{
				throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
			}
			if (packet.Password != null)
			{
				b |= 0x40;
			}
			if (packet.Username != null)
			{
				b |= 0x80;
			}
			packetWriter.Write(b);
			packetWriter.Write(packet.KeepAlivePeriod);
			packetWriter.WriteWithLengthPrefix(packet.ClientId);
			if (packet.WillMessage != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Topic);
				packetWriter.WriteWithLengthPrefix(packet.WillMessage.Payload);
			}
			if (packet.Username != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Username);
			}
			if (packet.Password != null)
			{
				packetWriter.WriteWithLengthPrefix(packet.Password);
			}
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.Connect, 0);
		}

		protected override byte EncodeConnAckPacket(MqttConnAckPacket packet, IMqttPacketWriter packetWriter)
		{
			byte b = 0;
			if (packet.IsSessionPresent)
			{
				b |= 1;
			}
			packetWriter.Write(b);
			packetWriter.Write((byte)packet.ReturnCode.Value);
			return MqttPacketWriter.BuildFixedHeader(MqttControlPacketType.ConnAck, 0);
		}

		protected override MqttBasePacket DecodeConnAckPacket(IMqttPacketBodyReader body)
		{
			MqttV310PacketFormatter.ThrowIfBodyIsEmpty(body);
			MqttConnAckPacket mqttConnAckPacket = new MqttConnAckPacket();
			byte b = body.ReadByte();
			mqttConnAckPacket.IsSessionPresent = (b & 1) > 0;
			mqttConnAckPacket.ReturnCode = (MqttConnectReturnCode)body.ReadByte();
			return mqttConnAckPacket;
		}
	}
}
namespace MQTTnet.Extensions
{
	public static class MqttClientOptionsBuilderExtension
	{
		public static MqttClientOptionsBuilder WithConnectionUri(this MqttClientOptionsBuilder builder, Uri uri)
		{
			int? port = (uri.IsDefaultPort ? ((int?)null) : new int?(uri.Port));
			switch (uri.Scheme.ToLower())
			{
			case "tcp":
			case "mqtt":
				builder.WithTcpServer(uri.Host, port);
				break;
			case "mqtts":
				builder.WithTcpServer(uri.Host, port).WithTls();
				break;
			case "ws":
			case "wss":
				builder.WithWebSocketServer(uri.ToString());
				break;
			default:
				throw new ArgumentException("Unexpected scheme in uri.");
			}
			if (!string.IsNullOrEmpty(uri.UserInfo))
			{
				string[] array = uri.UserInfo.Split(':');
				string username = array[0];
				string password = ((array.Length > 1) ? array[1] : "");
				builder.WithCredentials(username, password);
			}
			return builder;
		}

		public static MqttClientOptionsBuilder WithConnectionUri(this MqttClientOptionsBuilder builder, string uri)
		{
			return builder.WithConnectionUri(new Uri(uri, UriKind.Absolute));
		}
	}
	public static class UserPropertyExtension
	{
		public static string GetUserProperty(this MqttApplicationMessage message, string propertyName, StringComparison comparisonType = StringComparison.Ordinal)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			if (propertyName == null)
			{
				throw new ArgumentNullException("propertyName");
			}
			return message.UserProperties?.SingleOrDefault((MqttUserProperty up) => up.Name.Equals(propertyName, comparisonType))?.Value;
		}
	}
}
namespace MQTTnet.Exceptions
{
	public class MqttCommunicationException : Exception
	{
		protected MqttCommunicationException()
		{
		}

		public MqttCommunicationException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public MqttCommunicationException(string message)
			: base(message)
		{
		}
	}
	public class MqttCommunicationTimedOutException : MqttCommunicationException
	{
		public MqttCommunicationTimedOutException()
		{
		}

		public MqttCommunicationTimedOutException(Exception innerException)
			: base(innerException)
		{
		}
	}
	public class MqttConfigurationException : Exception
	{
		protected MqttConfigurationException()
		{
		}

		public MqttConfigurationException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public MqttConfigurationException(string message)
			: base(message)
		{
		}
	}
	public class MqttProtocolViolationException : Exception
	{
		public MqttProtocolViolationException(string message)
			: base(message)
		{
		}
	}
	public class MqttUnexpectedDisconnectReceivedException : MqttCommunicationException
	{
		public MqttDisconnectReasonCode? ReasonCode { get; }

		public uint? SessionExpiryInterval { get; }

		public string ReasonString { get; }

		public List<MqttUserProperty> UserProperties { get; }

		public string ServerReference { get; }

		public MqttUnexpectedDisconnectReceivedException(MqttDisconnectPacket disconnectPacket)
			: base($"Unexpected DISCONNECT (Reason code={disconnectPacket.ReasonCode}) received.")
		{
			ReasonCode = disconnectPacket.ReasonCode;
			SessionExpiryInterval = disconnectPacket.Properties?.SessionExpiryInterval;
			ReasonString = disconnectPacket.Properties?.ReasonString;
			ServerReference = disconnectPacket.Properties?.ServerReference;
			UserProperties = disconnectPacket.Properties?.UserProperties;
		}
	}
}
namespace MQTTnet.Diagnostics
{
	public interface IMqttNetLogger
	{
		event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;

		IMqttNetScopedLogger CreateScopedLogger(string source);

		void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception);
	}
	public interface IMqttNetScopedLogger
	{
		IMqttNetScopedLogger CreateScopedLogger(string source);

		void Publish(MqttNetLogLevel logLevel, string message, object[] parameters, Exception exception);
	}
	public static class MqttNetGlobalLogger
	{
		public static bool HasListeners => MqttNetGlobalLogger.LogMessagePublished != null;

		public static event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;

		public static void Publish(MqttNetLogMessage logMessage)
		{
			if (logMessage == null)
			{
				throw new ArgumentNullException("logMessage");
			}
			MqttNetGlobalLogger.LogMessagePublished?.Invoke(null, new MqttNetLogMessagePublishedEventArgs(logMessage));
		}
	}
	public class MqttNetLogger : IMqttNetLogger
	{
		private readonly string _logId;

		public event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;

		public MqttNetLogger()
		{
		}

		public MqttNetLogger(string logId)
		{
			_logId = logId;
		}

		public IMqttNetScopedLogger CreateScopedLogger(string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new MqttNetScopedLogger(this, source);
		}

		public void Publish(MqttNetLogLevel level, string source, string message, object[] parameters, Exception exception)
		{
			bool flag = this.LogMessagePublished != null;
			bool hasListeners = MqttNetGlobalLogger.HasListeners;
			if (flag || hasListeners)
			{
				try
				{
					message = string.Format(message ?? string.Empty, parameters);
				}
				catch (FormatException)
				{
					message = "MESSAGE FORMAT INVALID: " + message;
				}
				MqttNetLogMessage logMessage = new MqttNetLogMessage
				{
					LogId = _logId,
					Timestamp = DateTime.UtcNow,
					Source = source,
					ThreadId = Environment.CurrentManagedThreadId,
					Level = level,
					Message = message,
					Exception = exception
				};
				if (hasListeners)
				{
					MqttNetGlobalLogger.Publish(logMessage);
				}
				if (flag)
				{
					this.LogMessagePublished?.Invoke(this, new MqttNetLogMessagePublishedEventArgs(logMessage));
				}
			}
		}
	}
	public enum MqttNetLogLevel
	{
		Verbose,
		Info,
		Warning,
		Error
	}
	public class MqttNetLogMessage
	{
		public string LogId { get; set; }

		public DateTime Timestamp { get; set; }

		public int ThreadId { get; set; }

		public string Source { get; set; }

		public MqttNetLogLevel Level { get; set; }

		public string Message { get; set; }

		public Exception Exception { get; set; }

		public override string ToString()
		{
			string text = $"[{Timestamp:O}] [{LogId}] [{ThreadId}] [{Source}] [{Level}]: {Message}";
			if (Exception != null)
			{
				text = text + Environment.NewLine + Exception;
			}
			return text;
		}
	}
	public class MqttNetLogMessagePublishedEventArgs : EventArgs
	{
		[Obsolete("Use new proeprty LogMessage instead.")]
		public MqttNetLogMessage TraceMessage { get; }

		public MqttNetLogMessage LogMessage { get; }

		public MqttNetLogMessagePublishedEventArgs(MqttNetLogMessage logMessage)
		{
			LogMessage = logMessage ?? throw new ArgumentNullException("logMessage");
			TraceMessage = logMessage ?? throw new ArgumentNullException("logMessage");
		}
	}
	public sealed class MqttNetScopedLogger : IMqttNetScopedLogger
	{
		private readonly IMqttNetLogger _logger;

		private readonly string _source;

		public MqttNetScopedLogger(IMqttNetLogger logger, string source)
		{
			_logger = logger ?? throw new ArgumentNullException("logger");
			_source = source ?? throw new ArgumentNullException("source");
		}

		public IMqttNetScopedLogger CreateScopedLogger(string source)
		{
			return new MqttNetScopedLogger(_logger, source);
		}

		public void Publish(MqttNetLogLevel logLevel, string message, object[] parameters, Exception exception)
		{
			_logger.Publish(logLevel, _source, message, parameters, exception);
		}
	}
	public static class MqttNetScopedLoggerExtensions
	{
		public static void Verbose(this IMqttNetScopedLogger logger, string message, params object[] parameters)
		{
			logger.Publish(MqttNetLogLevel.Verbose, message, parameters, null);
		}

		public static void Info(this IMqttNetScopedLogger logger, string message, params object[] parameters)
		{
			logger.Publish(MqttNetLogLevel.Info, message, parameters, null);
		}

		public static void Warning(this IMqttNetScopedLogger logger, Exception exception, string message, params object[] parameters)
		{
			logger.Publish(MqttNetLogLevel.Warning, message, parameters, exception);
		}

		public static void Error(this IMqttNetScopedLogger logger, Exception exception, string message, params object[] parameters)
		{
			logger.Publish(MqttNetLogLevel.Error, message, parameters, exception);
		}
	}
	public static class TargetFrameworkProvider
	{
		public static string TargetFramework => "netstandard2.1";
	}
}
namespace MQTTnet.Client
{
	public interface IMqttClient : IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
	{
		bool IsConnected { get; }

		IMqttClientOptions Options { get; }

		IMqttClientConnectedHandler ConnectedHandler { get; set; }

		IMqttClientDisconnectedHandler DisconnectedHandler { get; set; }

		Task<MqttClientAuthenticateResult> ConnectAsync(IMqttClientOptions options, CancellationToken cancellationToken);

		Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken);

		Task PingAsync(CancellationToken cancellationToken);

		Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data, CancellationToken cancellationToken);

		Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken);

		Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken);
	}
	public interface IMqttClientFactory
	{
		IMqttFactory UseClientAdapterFactory(IMqttClientAdapterFactory clientAdapterFactory);

		ILowLevelMqttClient CreateLowLevelMqttClient();

		ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger);

		ILowLevelMqttClient CreateLowLevelMqttClient(IMqttClientAdapterFactory clientAdapterFactory);

		ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory clientAdapterFactory);

		IMqttClient CreateMqttClient();

		IMqttClient CreateMqttClient(IMqttNetLogger logger);

		IMqttClient CreateMqttClient(IMqttClientAdapterFactory adapterFactory);

		IMqttClient CreateMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory adapterFactory);
	}
	public class MqttClient : Disposable, IMqttClient, IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
	{
		private readonly MqttPacketIdentifierProvider _packetIdentifierProvider = new MqttPacketIdentifierProvider();

		private readonly MqttPacketDispatcher _packetDispatcher = new MqttPacketDispatcher();

		private readonly Stopwatch _sendTracker = new Stopwatch();

		private readonly Stopwatch _receiveTracker = new Stopwatch();

		private readonly object _disconnectLock = new object();

		private readonly IMqttClientAdapterFactory _adapterFactory;

		private readonly IMqttNetScopedLogger _logger;

		private CancellationTokenSource _backgroundCancellationTokenSource;

		private Task _packetReceiverTask;

		private Task _keepAlivePacketsSenderTask;

		private Task _publishPacketReceiverTask;

		private AsyncQueue<MqttPublishPacket> _publishPacketReceiverQueue;

		private IMqttChannelAdapter _adapter;

		private bool _cleanDisconnectInitiated;

		private long _isDisconnectPending;

		private bool _isConnected;

		public IMqttClientConnectedHandler ConnectedHandler { get; set; }

		public IMqttClientDisconnectedHandler DisconnectedHandler { get; set; }

		public IMqttApplicationMessageReceivedHandler ApplicationMessageReceivedHandler { get; set; }

		public bool IsConnected
		{
			get
			{
				if (_isConnected)
				{
					return Interlocked.Read(ref _isDisconnectPending) == 0;
				}
				return false;
			}
		}

		public IMqttClientOptions Options { get; private set; }

		public MqttClient(IMqttClientAdapterFactory channelFactory, IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_adapterFactory = channelFactory ?? throw new ArgumentNullException("channelFactory");
			_logger = logger.CreateScopedLogger("MqttClient");
		}

		public async Task<MqttClientAuthenticateResult> ConnectAsync(IMqttClientOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (options.ChannelOptions == null)
			{
				throw new ArgumentException("ChannelOptions are not set.");
			}
			ThrowIfConnected("It is not allowed to connect with a server after the connection is established.");
			ThrowIfDisposed();
			MqttClientAuthenticateResult authenticateResult = null;
			MqttClientAuthenticateResult result = default(MqttClientAuthenticateResult);
			try
			{
				Options = options;
				_packetIdentifierProvider.Reset();
				_packetDispatcher.Reset();
				_backgroundCancellationTokenSource = new CancellationTokenSource();
				CancellationToken backgroundCancellationToken = _backgroundCancellationTokenSource.Token;
				_isDisconnectPending = 0L;
				IMqttChannelAdapter adapter = (_adapter = _adapterFactory.CreateClientAdapter(options));
				using (CancellationTokenSource combined = CancellationTokenSource.CreateLinkedTokenSource(backgroundCancellationToken, cancellationToken))
				{
					_logger.Verbose($"Trying to connect with server '{options.ChannelOptions}' (Timeout={options.CommunicationTimeout}).");
					await _adapter.ConnectAsync(options.CommunicationTimeout, combined.Token).ConfigureAwait(continueOnCapturedContext: false);
					_logger.Verbose("Connection with server established.");
					_publishPacketReceiverQueue = new AsyncQueue<MqttPublishPacket>();
					_publishPacketReceiverTask = Task.Run(() => ProcessReceivedPublishPackets(backgroundCancellationToken), backgroundCancellationToken);
					_packetReceiverTask = Task.Run(() => TryReceivePacketsAsync(backgroundCancellationToken), backgroundCancellationToken);
					authenticateResult = await AuthenticateAsync(adapter, options.WillMessage, combined.Token).ConfigureAwait(continueOnCapturedContext: false);
				}
				_sendTracker.Restart();
				_receiveTracker.Restart();
				if (Options.KeepAlivePeriod != TimeSpan.Zero)
				{
					_keepAlivePacketsSenderTask = Task.Run(() => TrySendKeepAliveMessagesAsync(backgroundCancellationToken), backgroundCancellationToken);
				}
				_isConnected = true;
				_logger.Info("Connected.");
				IMqttClientConnectedHandler connectedHandler = ConnectedHandler;
				if (connectedHandler != null)
				{
					await connectedHandler.HandleConnectedAsync(new MqttClientConnectedEventArgs(authenticateResult)).ConfigureAwait(continueOnCapturedContext: false);
				}
				result = authenticateResult;
				return result;
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				_logger.Error(exception, "Error while connecting with server.");
				if (!DisconnectIsPending())
				{
					await DisconnectInternalAsync(null, exception, authenticateResult).ConfigureAwait(continueOnCapturedContext: false);
				}
				ExceptionDispatchInfo.Capture((ex as Exception) ?? throw ex).Throw();
			}
			return result;
		}

		public async Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			ThrowIfDisposed();
			object obj = null;
			try
			{
				_cleanDisconnectInitiated = true;
				if (IsConnected)
				{
					MqttDisconnectPacket packet = _adapter.PacketFormatterAdapter.DataConverter.CreateDisconnectPacket(options);
					await SendAsync(packet, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (object obj2)
			{
				obj = obj2;
			}
			if (!DisconnectIsPending())
			{
				await DisconnectInternalAsync(null, null, null).ConfigureAwait(continueOnCapturedContext: false);
			}
			object obj3 = obj;
			if (obj3 != null)
			{
				ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
			}
		}

		public Task PingAsync(CancellationToken cancellationToken)
		{
			return SendAndReceiveAsync<MqttPingRespPacket>(new MqttPingReqPacket(), cancellationToken);
		}

		public Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data, CancellationToken cancellationToken)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			ThrowIfDisposed();
			ThrowIfNotConnected();
			return SendAsync(new MqttAuthPacket
			{
				Properties = new MqttAuthPacketProperties
				{
					AuthenticationMethod = Options.AuthenticationMethod,
					AuthenticationData = data.AuthenticationData,
					ReasonString = data.ReasonString,
					UserProperties = data.UserProperties
				}
			}, cancellationToken);
		}

		public async Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			ThrowIfDisposed();
			ThrowIfNotConnected();
			MqttSubscribePacket subscribePacket = _adapter.PacketFormatterAdapter.DataConverter.CreateSubscribePacket(options);
			subscribePacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();
			MqttSubAckPacket subAckPacket = await SendAndReceiveAsync<MqttSubAckPacket>(subscribePacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return _adapter.PacketFormatterAdapter.DataConverter.CreateClientSubscribeResult(subscribePacket, subAckPacket);
		}

		public async Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			ThrowIfDisposed();
			ThrowIfNotConnected();
			MqttUnsubscribePacket unsubscribePacket = _adapter.PacketFormatterAdapter.DataConverter.CreateUnsubscribePacket(options);
			unsubscribePacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();
			MqttUnsubAckPacket unsubAckPacket = await SendAndReceiveAsync<MqttUnsubAckPacket>(unsubscribePacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return _adapter.PacketFormatterAdapter.DataConverter.CreateClientUnsubscribeResult(unsubscribePacket, unsubAckPacket);
		}

		public Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken)
		{
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			MqttTopicValidator.ThrowIfInvalid(applicationMessage.Topic);
			ThrowIfDisposed();
			ThrowIfNotConnected();
			MqttPublishPacket publishPacket = _adapter.PacketFormatterAdapter.DataConverter.CreatePublishPacket(applicationMessage);
			return applicationMessage.QualityOfServiceLevel switch
			{
				MqttQualityOfServiceLevel.AtMostOnce => PublishAtMostOnce(publishPacket, cancellationToken), 
				MqttQualityOfServiceLevel.AtLeastOnce => PublishAtLeastOnceAsync(publishPacket, cancellationToken), 
				MqttQualityOfServiceLevel.ExactlyOnce => PublishExactlyOnceAsync(publishPacket, cancellationToken), 
				_ => throw new NotSupportedException(), 
			};
		}

		private void Cleanup()
		{
			_backgroundCancellationTokenSource?.Cancel(throwOnFirstException: false);
			_backgroundCancellationTokenSource?.Dispose();
			_backgroundCancellationTokenSource = null;
			_publishPacketReceiverQueue?.Dispose();
			_publishPacketReceiverQueue = null;
			_adapter?.Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Cleanup();
				DisconnectedHandler = null;
			}
			base.Dispose(disposing);
		}

		private async Task<MqttClientAuthenticateResult> AuthenticateAsync(IMqttChannelAdapter channelAdapter, MqttApplicationMessage willApplicationMessage, CancellationToken cancellationToken)
		{
			MqttConnectPacket requestPacket = channelAdapter.PacketFormatterAdapter.DataConverter.CreateConnectPacket(willApplicationMessage, Options);
			MqttConnAckPacket connAckPacket = await SendAndReceiveAsync<MqttConnAckPacket>(requestPacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			MqttClientAuthenticateResult mqttClientAuthenticateResult = channelAdapter.PacketFormatterAdapter.DataConverter.CreateClientConnectResult(connAckPacket);
			if (mqttClientAuthenticateResult.ResultCode != MqttClientConnectResultCode.Success)
			{
				throw new MqttConnectingFailedException(mqttClientAuthenticateResult);
			}
			_logger.Verbose("Authenticated MQTT connection with server established.");
			return mqttClientAuthenticateResult;
		}

		private void ThrowIfNotConnected()
		{
			if (!IsConnected || Interlocked.Read(ref _isDisconnectPending) == 1)
			{
				throw new MqttCommunicationException("The client is not connected.");
			}
		}

		private void ThrowIfConnected(string message)
		{
			if (IsConnected)
			{
				throw new MqttProtocolViolationException(message);
			}
		}

		private async Task DisconnectInternalAsync(Task sender, Exception exception, MqttClientAuthenticateResult authenticateResult)
		{
			bool clientWasConnected = IsConnected;
			MqttClientDisconnectReason reasonCode = MqttClientDisconnectReason.NormalDisconnection;
			TryInitiateDisconnect();
			_isConnected = false;
			try
			{
				if (_adapter != null)
				{
					_logger.Verbose("Disconnecting [Timeout={0}]", Options.CommunicationTimeout);
					await _adapter.DisconnectAsync(Options.CommunicationTimeout, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
				}
				_logger.Verbose("Disconnected from adapter.");
			}
			catch (Exception exception2)
			{
				_logger.Warning(exception2, "Error while disconnecting from adapter.");
				reasonCode = MqttClientDisconnectReason.UnspecifiedError;
			}
			try
			{
				Task task = WaitForTaskAsync(_packetReceiverTask, sender);
				Task task2 = WaitForTaskAsync(_publishPacketReceiverTask, sender);
				Task task3 = WaitForTaskAsync(_keepAlivePacketsSenderTask, sender);
				await Task.WhenAll(task, task2, task3).ConfigureAwait(continueOnCapturedContext: false);
				_publishPacketReceiverQueue?.Dispose();
			}
			catch (Exception exception3)
			{
				_logger.Warning(exception3, "Error while waiting for internal tasks.");
				reasonCode = MqttClientDisconnectReason.UnspecifiedError;
			}
			finally
			{
				Cleanup();
				_cleanDisconnectInitiated = false;
				_logger.Info("Disconnected.");
				IMqttClientDisconnectedHandler disconnectedHandler = DisconnectedHandler;
				if (disconnectedHandler != null)
				{
					Task.Run(() => disconnectedHandler.HandleDisconnectedAsync(new MqttClientDisconnectedEventArgs(clientWasConnected, exception, authenticateResult, reasonCode))).Forget(_logger);
				}
			}
		}

		private void TryInitiateDisconnect()
		{
			lock (_disconnectLock)
			{
				try
				{
					CancellationTokenSource backgroundCancellationTokenSource = _backgroundCancellationTokenSource;
					if (backgroundCancellationTokenSource == null || !backgroundCancellationTokenSource.IsCancellationRequested)
					{
						_backgroundCancellationTokenSource?.Cancel(throwOnFirstException: false);
					}
				}
				catch (Exception exception)
				{
					_logger.Warning(exception, "Error while initiating disconnect.");
				}
			}
		}

		private Task SendAsync(MqttBasePacket packet, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			_sendTracker.Restart();
			return _adapter.SendPacketAsync(packet, Options.CommunicationTimeout, cancellationToken);
		}

		private async Task<TResponsePacket> SendAndReceiveAsync<TResponsePacket>(MqttBasePacket requestPacket, CancellationToken cancellationToken) where TResponsePacket : MqttBasePacket
		{
			cancellationToken.ThrowIfCancellationRequested();
			ushort value = 0;
			if (requestPacket is IMqttPacketWithIdentifier { PacketIdentifier: not null, PacketIdentifier: var packetIdentifier })
			{
				value = packetIdentifier.Value;
			}
			using MqttPacketAwaiter<TResponsePacket> packetAwaiter = _packetDispatcher.AddAwaiter<TResponsePacket>(value);
			try
			{
				_sendTracker.Restart();
				await _adapter.SendPacketAsync(requestPacket, Options.CommunicationTimeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_logger.Warning(exception, "Error when sending packet of type '{0}'.", typeof(TResponsePacket).Name);
				packetAwaiter.Cancel();
			}
			try
			{
				return await packetAwaiter.WaitOneAsync(Options.CommunicationTimeout).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				if (ex is MqttCommunicationTimedOutException)
				{
					_logger.Warning(null, "Timeout while waiting for packet of type '{0}'.", typeof(TResponsePacket).Name);
				}
				throw;
			}
		}

		private async Task TrySendKeepAliveMessagesAsync(CancellationToken cancellationToken)
		{
			_ = 2;
			try
			{
				_logger.Verbose("Start sending keep alive packets.");
				TimeSpan keepAlivePeriod = Options.KeepAlivePeriod;
				while (!cancellationToken.IsCancellationRequested)
				{
					if (keepAlivePeriod - _sendTracker.Elapsed <= TimeSpan.Zero)
					{
						await SendAndReceiveAsync<MqttPingRespPacket>(new MqttPingReqPacket(), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					await Task.Delay(TimeSpan.FromMilliseconds(100.0), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex)
			{
				if (_cleanDisconnectInitiated)
				{
					return;
				}
				if (!(ex is OperationCanceledException))
				{
					if (ex is MqttCommunicationException)
					{
						_logger.Warning(ex, "Communication error while sending/receiving keep alive packets.");
					}
					else
					{
						_logger.Error(ex, "Error exception while sending/receiving keep alive packets.");
					}
				}
				if (!DisconnectIsPending())
				{
					await DisconnectInternalAsync(_keepAlivePacketsSenderTask, ex, null).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			finally
			{
				_logger.Verbose("Stopped sending keep alive packets.");
			}
		}

		private async Task TryReceivePacketsAsync(CancellationToken cancellationToken)
		{
			_ = 3;
			try
			{
				_logger.Verbose("Start receiving packets.");
				while (!cancellationToken.IsCancellationRequested)
				{
					MqttBasePacket mqttBasePacket = await _adapter.ReceivePacketAsync(TimeSpan.Zero, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (cancellationToken.IsCancellationRequested)
					{
						return;
					}
					if (mqttBasePacket == null)
					{
						if (!DisconnectIsPending())
						{
							await DisconnectInternalAsync(_packetReceiverTask, null, null).ConfigureAwait(continueOnCapturedContext: false);
						}
						return;
					}
					await TryProcessReceivedPacketAsync(mqttBasePacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex)
			{
				if (_cleanDisconnectInitiated)
				{
					return;
				}
				if (!(ex is OperationCanceledException))
				{
					if (ex is MqttCommunicationException)
					{
						_logger.Warning(ex, "Communication error while receiving packets.");
					}
					else
					{
						_logger.Error(ex, "Error while receiving packets.");
					}
				}
				_packetDispatcher.Dispatch(ex);
				if (!DisconnectIsPending())
				{
					await DisconnectInternalAsync(_packetReceiverTask, ex, null).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			finally
			{
				_logger.Verbose("Stopped receiving packets.");
			}
		}

		private async Task TryProcessReceivedPacketAsync(MqttBasePacket packet, CancellationToken cancellationToken)
		{
			try
			{
				_receiveTracker.Restart();
				if (packet is MqttPublishPacket publishPacket)
				{
					EnqueueReceivedPublishPacket(publishPacket);
				}
				else if (packet is MqttPubRelPacket mqttPubRelPacket)
				{
					await SendAsync(new MqttPubCompPacket
					{
						PacketIdentifier = mqttPubRelPacket.PacketIdentifier,
						ReasonCode = MqttPubCompReasonCode.Success
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (packet is MqttPingReqPacket)
				{
					await SendAsync(new MqttPingRespPacket(), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (packet is MqttDisconnectPacket)
				{
					_packetDispatcher.Dispatch(packet);
					await DisconnectAsync(null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else if (packet is MqttAuthPacket authPacket)
				{
					IMqttExtendedAuthenticationExchangeHandler extendedAuthenticationExchangeHandler = Options.ExtendedAuthenticationExchangeHandler;
					if (extendedAuthenticationExchangeHandler != null)
					{
						await extendedAuthenticationExchangeHandler.HandleRequestAsync(new MqttExtendedAuthenticationExchangeContext(authPacket, this)).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				else
				{
					_packetDispatcher.Dispatch(packet);
				}
			}
			catch (Exception ex)
			{
				if (_cleanDisconnectInitiated)
				{
					return;
				}
				if (!(ex is OperationCanceledException))
				{
					if (ex is MqttCommunicationException)
					{
						_logger.Warning(ex, "Communication error while receiving packets.");
					}
					else
					{
						_logger.Error(ex, "Error while receiving packets.");
					}
				}
				_packetDispatcher.Dispatch(ex);
				if (!DisconnectIsPending())
				{
					await DisconnectInternalAsync(_packetReceiverTask, ex, null).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		private void EnqueueReceivedPublishPacket(MqttPublishPacket publishPacket)
		{
			try
			{
				_publishPacketReceiverQueue.Enqueue(publishPacket);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while enqueueing application message.");
			}
		}

		private async Task ProcessReceivedPublishPackets(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					AsyncQueueDequeueResult<MqttPublishPacket> asyncQueueDequeueResult = await _publishPacketReceiverQueue.TryDequeueAsync(cancellationToken);
					if (!asyncQueueDequeueResult.IsSuccess)
					{
						break;
					}
					MqttPublishPacket publishPacket = asyncQueueDequeueResult.Item;
					if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce)
					{
						await HandleReceivedApplicationMessageAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false);
						continue;
					}
					if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtLeastOnce)
					{
						if (await HandleReceivedApplicationMessageAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false))
						{
							await SendAsync(new MqttPubAckPacket
							{
								PacketIdentifier = publishPacket.PacketIdentifier,
								ReasonCode = MqttPubAckReasonCode.Success
							}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						continue;
					}
					if (publishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.ExactlyOnce)
					{
						if (await HandleReceivedApplicationMessageAsync(publishPacket).ConfigureAwait(continueOnCapturedContext: false))
						{
							MqttPubRecPacket packet = new MqttPubRecPacket
							{
								PacketIdentifier = publishPacket.PacketIdentifier,
								ReasonCode = MqttPubRecReasonCode.Success
							};
							await SendAsync(packet, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						continue;
					}
					throw new MqttProtocolViolationException("Received a not supported QoS level.");
				}
				catch (Exception exception)
				{
					_logger.Error(exception, "Error while handling application message.");
				}
			}
		}

		private async Task<MqttClientPublishResult> PublishAtMostOnce(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
		{
			await SendAsync(publishPacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return _adapter.PacketFormatterAdapter.DataConverter.CreatePublishResult(null);
		}

		private async Task<MqttClientPublishResult> PublishAtLeastOnceAsync(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
		{
			publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();
			MqttPubAckPacket pubAckPacket = await SendAndReceiveAsync<MqttPubAckPacket>(publishPacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return _adapter.PacketFormatterAdapter.DataConverter.CreatePublishResult(pubAckPacket);
		}

		private async Task<MqttClientPublishResult> PublishExactlyOnceAsync(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
		{
			publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();
			MqttPubRecPacket pubRecPacket = await SendAndReceiveAsync<MqttPubRecPacket>(publishPacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			MqttPubRelPacket requestPacket = new MqttPubRelPacket
			{
				PacketIdentifier = publishPacket.PacketIdentifier,
				ReasonCode = MqttPubRelReasonCode.Success
			};
			MqttPubCompPacket pubCompPacket = await SendAndReceiveAsync<MqttPubCompPacket>(requestPacket, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return _adapter.PacketFormatterAdapter.DataConverter.CreatePublishResult(pubRecPacket, pubCompPacket);
		}

		private async Task<bool> HandleReceivedApplicationMessageAsync(MqttPublishPacket publishPacket)
		{
			MqttApplicationMessage applicationMessage = _adapter.PacketFormatterAdapter.DataConverter.CreateApplicationMessage(publishPacket);
			IMqttApplicationMessageReceivedHandler applicationMessageReceivedHandler = ApplicationMessageReceivedHandler;
			if (applicationMessageReceivedHandler != null)
			{
				MqttApplicationMessageReceivedEventArgs eventArgs = new MqttApplicationMessageReceivedEventArgs(Options.ClientId, applicationMessage);
				await applicationMessageReceivedHandler.HandleApplicationMessageReceivedAsync(eventArgs).ConfigureAwait(continueOnCapturedContext: false);
				return !eventArgs.ProcessingFailed;
			}
			return true;
		}

		private async Task WaitForTaskAsync(Task task, Task sender)
		{
			if (task == null)
			{
				return;
			}
			if (task == sender)
			{
				if (task.IsFaulted)
				{
					_logger.Warning(task.Exception, "Error while waiting for background task.");
				}
				return;
			}
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
			}
		}

		private bool DisconnectIsPending()
		{
			return Interlocked.CompareExchange(ref _isDisconnectPending, 1L, 0L) != 0;
		}
	}
	public static class MqttClientExtensions
	{
		public static IMqttClient UseConnectedHandler(this IMqttClient client, Func<MqttClientConnectedEventArgs, Task> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseConnectedHandler((IMqttClientConnectedHandler)null);
			}
			return client.UseConnectedHandler(new MqttClientConnectedHandlerDelegate(handler));
		}

		public static IMqttClient UseConnectedHandler(this IMqttClient client, Action<MqttClientConnectedEventArgs> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseConnectedHandler((IMqttClientConnectedHandler)null);
			}
			return client.UseConnectedHandler(new MqttClientConnectedHandlerDelegate(handler));
		}

		public static IMqttClient UseConnectedHandler(this IMqttClient client, IMqttClientConnectedHandler handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			client.ConnectedHandler = handler;
			return client;
		}

		public static IMqttClient UseDisconnectedHandler(this IMqttClient client, Func<MqttClientDisconnectedEventArgs, Task> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseDisconnectedHandler((IMqttClientDisconnectedHandler)null);
			}
			return client.UseDisconnectedHandler(new MqttClientDisconnectedHandlerDelegate(handler));
		}

		public static IMqttClient UseDisconnectedHandler(this IMqttClient client, Action<MqttClientDisconnectedEventArgs> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseDisconnectedHandler((IMqttClientDisconnectedHandler)null);
			}
			return client.UseDisconnectedHandler(new MqttClientDisconnectedHandlerDelegate(handler));
		}

		public static IMqttClient UseDisconnectedHandler(this IMqttClient client, IMqttClientDisconnectedHandler handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			client.DisconnectedHandler = handler;
			return client;
		}

		public static IMqttClient UseApplicationMessageReceivedHandler(this IMqttClient client, Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
			}
			return client.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
		}

		public static IMqttClient UseApplicationMessageReceivedHandler(this IMqttClient client, Action<MqttApplicationMessageReceivedEventArgs> handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (handler == null)
			{
				return client.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
			}
			return client.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
		}

		public static IMqttClient UseApplicationMessageReceivedHandler(this IMqttClient client, IMqttApplicationMessageReceivedHandler handler)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			client.ApplicationMessageReceivedHandler = handler;
			return client;
		}

		public static Task ReconnectAsync(this IMqttClient client)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (client.Options == null)
			{
				throw new InvalidOperationException("_ReconnectAsync_ can be used only if _ConnectAsync_ was called before.");
			}
			return client.ConnectAsync(client.Options);
		}

		public static Task DisconnectAsync(this IMqttClient client)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.DisconnectAsync(new MqttClientDisconnectOptions());
		}

		public static Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(this IMqttClient client, params MqttTopicFilter[] topicFilters)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			MqttClientSubscribeOptions mqttClientSubscribeOptions = new MqttClientSubscribeOptions();
			mqttClientSubscribeOptions.TopicFilters.AddRange(topicFilters);
			return client.SubscribeAsync(mqttClientSubscribeOptions);
		}

		public static Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(this IMqttClient client, string topic, MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel(qualityOfServiceLevel).Build());
		}

		public static Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(this IMqttClient client, string topic)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
		}

		public static Task<MqttClientUnsubscribeResult> UnsubscribeAsync(this IMqttClient client, params string[] topicFilters)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topicFilters == null)
			{
				throw new ArgumentNullException("topicFilters");
			}
			MqttClientUnsubscribeOptions mqttClientUnsubscribeOptions = new MqttClientUnsubscribeOptions();
			mqttClientUnsubscribeOptions.TopicFilters.AddRange(topicFilters);
			return client.UnsubscribeAsync(mqttClientUnsubscribeOptions);
		}

		public static Task<MqttClientAuthenticateResult> ConnectAsync(this IMqttClient client, IMqttClientOptions options)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.ConnectAsync(options, CancellationToken.None);
		}

		public static Task DisconnectAsync(this IMqttClient client, MqttClientDisconnectOptions options)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.DisconnectAsync(options, CancellationToken.None);
		}

		public static Task SendExtendedAuthenticationExchangeDataAsync(this IMqttClient client, MqttExtendedAuthenticationExchangeData data)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.SendExtendedAuthenticationExchangeDataAsync(data, CancellationToken.None);
		}

		public static Task<MQTTnet.Client.Subscribing.MqttClientSubscribeResult> SubscribeAsync(this IMqttClient client, MqttClientSubscribeOptions options)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.SubscribeAsync(options, CancellationToken.None);
		}

		public static Task<MqttClientUnsubscribeResult> UnsubscribeAsync(this IMqttClient client, MqttClientUnsubscribeOptions options)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			return client.UnsubscribeAsync(options, CancellationToken.None);
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, MqttApplicationMessage applicationMessage)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (applicationMessage == null)
			{
				throw new ArgumentNullException("applicationMessage");
			}
			return client.PublishAsync(applicationMessage, CancellationToken.None);
		}

		public static async Task PublishAsync(this IMqttClient client, IEnumerable<MqttApplicationMessage> applicationMessages)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (applicationMessages == null)
			{
				throw new ArgumentNullException("applicationMessages");
			}
			foreach (MqttApplicationMessage applicationMessage in applicationMessages)
			{
				await client.PublishAsync(applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).Build());
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic, IEnumerable<byte> payload)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).Build());
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic, string payload)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).Build());
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel)
				.Build());
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel, bool retain)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel)
				.WithRetainFlag(retain)
				.Build());
		}

		public static Task<MqttClientPublishResult> PublishAsync(this IMqttClient client, string topic, string payload, bool retain)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			return client.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).WithRetainFlag(retain)
				.Build());
		}
	}
	public class MqttPacketIdentifierProvider
	{
		private readonly object _syncRoot = new object();

		private ushort _value;

		public void Reset()
		{
			lock (_syncRoot)
			{
				_value = 0;
			}
		}

		public ushort GetNextPacketIdentifier()
		{
			lock (_syncRoot)
			{
				_value++;
				if (_value == 0)
				{
					_value = 1;
				}
				return _value;
			}
		}
	}
}
namespace MQTTnet.Client.Unsubscribing
{
	public class MqttClientUnsubscribeOptions
	{
		public List<string> TopicFilters { get; set; } = new List<string>();

		public List<MqttUserProperty> UserProperties { get; set; } = new List<MqttUserProperty>();
	}
	public class MqttClientUnsubscribeOptionsBuilder
	{
		private readonly MqttClientUnsubscribeOptions _unsubscribeOptions = new MqttClientUnsubscribeOptions();

		public MqttClientUnsubscribeOptionsBuilder WithUserProperty(string name, string value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return WithUserProperty(new MqttUserProperty(name, value));
		}

		public MqttClientUnsubscribeOptionsBuilder WithUserProperty(MqttUserProperty userProperty)
		{
			if (userProperty == null)
			{
				throw new ArgumentNullException("userProperty");
			}
			if (_unsubscribeOptions.UserProperties == null)
			{
				_unsubscribeOptions.UserProperties = new List<MqttUserProperty>();
			}
			_unsubscribeOptions.UserProperties.Add(userProperty);
			return this;
		}

		public MqttClientUnsubscribeOptionsBuilder WithTopicFilter(string topic)
		{
			if (topic == null)
			{
				throw new ArgumentNullException("topic");
			}
			if (_unsubscribeOptions.TopicFilters == null)
			{
				_unsubscribeOptions.TopicFilters = new List<string>();
			}
			_unsubscribeOptions.TopicFilters.Add(topic);
			return this;
		}

		public MqttClientUnsubscribeOptionsBuilder WithTopicFilter(MqttTopicFilter topicFilter)
		{
			if (topicFilter == null)
			{
				throw new ArgumentNullException("topicFilter");
			}
			return WithTopicFilter(topicFilter.Topic);
		}

		public MqttClientUnsubscribeOptions Build()
		{
			return _unsubscribeOptions;
		}
	}
	public class MqttClientUnsubscribeResult
	{
		public List<MqttClientUnsubscribeResultItem> Items { get; } = new List<MqttClientUnsubscribeResultItem>();
	}
	public enum MqttClientUnsubscribeResultCode
	{
		Success = 0,
		NoSubscriptionExisted = 17,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicFilterInvalid = 143,
		PacketIdentifierInUse = 145
	}
	public class MqttClientUnsubscribeResultItem
	{
		public string TopicFilter { get; }

		public MqttClientUnsubscribeResultCode ReasonCode { get; }

		public MqttClientUnsubscribeResultItem(string topicFilter, MqttClientUnsubscribeResultCode reasonCode)
		{
			TopicFilter = topicFilter ?? throw new ArgumentNullException("topicFilter");
			ReasonCode = reasonCode;
		}
	}
}
namespace MQTTnet.Client.Subscribing
{
	public class MqttClientSubscribeOptions
	{
		public List<MqttTopicFilter> TopicFilters { get; set; } = new List<MqttTopicFilter>();

		public uint? SubscriptionIdentifier { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttClientSubscribeOptionsBuilder
	{
		private readonly MqttClientSubscribeOptions _subscribeOptions = new MqttClientSubscribeOptions();

		public MqttClientSubscribeOptionsBuilder WithUserProperty(string name, string value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (_subscribeOptions.UserProperties == null)
			{
				_subscribeOptions.UserProperties = new List<MqttUserProperty>();
			}
			_subscribeOptions.UserProperties.Add(new MqttUserProperty(name, value));
			return this;
		}

		public MqttClientSubscribeOptionsBuilder WithSubscriptionIdentifier(uint? subscriptionIdentifier)
		{
			_subscribeOptions.SubscriptionIdentifier = subscriptionIdentifier;
			return this;
		}

		public MqttClientSubscribeOptionsBuilder WithTopicFilter(string topic, MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce, bool? noLocal = null, bool? retainAsPublished = null, MqttRetainHandling? retainHandling = null)
		{
			return WithTopicFilter(new MqttTopicFilter
			{
				Topic = topic,
				QualityOfServiceLevel = qualityOfServiceLevel,
				NoLocal = noLocal,
				RetainAsPublished = retainAsPublished,
				RetainHandling = retainHandling
			});
		}

		public MqttClientSubscribeOptionsBuilder WithTopicFilter(Action<MqttTopicFilterBuilder> topicFilterBuilder)
		{
			if (topicFilterBuilder == null)
			{
				throw new ArgumentNullException("topicFilterBuilder");
			}
			MqttTopicFilterBuilder mqttTopicFilterBuilder = new MqttTopicFilterBuilder();
			topicFilterBuilder(mqttTopicFilterBuilder);
			return WithTopicFilter(mqttTopicFilterBuilder);
		}

		public MqttClientSubscribeOptionsBuilder WithTopicFilter(MqttTopicFilterBuilder topicFilterBuilder)
		{
			if (topicFilterBuilder == null)
			{
				throw new ArgumentNullException("topicFilterBuilder");
			}
			return WithTopicFilter(topicFilterBuilder.Build());
		}

		public MqttClientSubscribeOptionsBuilder WithTopicFilter(MqttTopicFilter topicFilter)
		{
			if (topicFilter == null)
			{
				throw new ArgumentNullException("topicFilter");
			}
			if (_subscribeOptions.TopicFilters == null)
			{
				_subscribeOptions.TopicFilters = new List<MqttTopicFilter>();
			}
			_subscribeOptions.TopicFilters.Add(topicFilter);
			return this;
		}

		public MqttClientSubscribeOptions Build()
		{
			return _subscribeOptions;
		}
	}
	public class MqttClientSubscribeResult
	{
		public List<MqttClientSubscribeResultItem> Items { get; } = new List<MqttClientSubscribeResultItem>();
	}
	public enum MqttClientSubscribeResultCode
	{
		GrantedQoS0 = 0,
		GrantedQoS1 = 1,
		GrantedQoS2 = 2,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicFilterInvalid = 143,
		PacketIdentifierInUse = 145,
		QuotaExceeded = 151,
		SharedSubscriptionsNotSupported = 158,
		SubscriptionIdentifiersNotSupported = 161,
		WildcardSubscriptionsNotSupported = 162
	}
	public class MqttClientSubscribeResultItem
	{
		public MqttTopicFilter TopicFilter { get; }

		public MqttClientSubscribeResultCode ResultCode { get; }

		public MqttClientSubscribeResultItem(MqttTopicFilter topicFilter, MqttClientSubscribeResultCode resultCode)
		{
			TopicFilter = topicFilter ?? throw new ArgumentNullException("topicFilter");
			ResultCode = resultCode;
		}
	}
}
namespace MQTTnet.Client.Receiving
{
	public interface IMqttApplicationMessageReceivedHandler
	{
		Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs);
	}
	public class MqttApplicationMessageReceivedHandlerDelegate : IMqttApplicationMessageReceivedHandler
	{
		private readonly Func<MqttApplicationMessageReceivedEventArgs, Task> _handler;

		public MqttApplicationMessageReceivedHandlerDelegate(Action<MqttApplicationMessageReceivedEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttApplicationMessageReceivedEventArgs context)
			{
				handler(context);
				return Task.FromResult(0);
			};
		}

		public MqttApplicationMessageReceivedHandlerDelegate(Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs context)
		{
			return _handler(context);
		}
	}
}
namespace MQTTnet.Client.Publishing
{
	public enum MqttClientPublishReasonCode
	{
		Success = 0,
		NoMatchingSubscribers = 16,
		UnspecifiedError = 128,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		TopicNameInvalid = 144,
		PacketIdentifierInUse = 145,
		QuotaExceeded = 151,
		PayloadFormatInvalid = 153
	}
	public class MqttClientPublishResult
	{
		public ushort? PacketIdentifier { get; set; }

		public MqttClientPublishReasonCode ReasonCode { get; set; }

		public string ReasonString { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
}
namespace MQTTnet.Client.Options
{
	public interface IMqttClientChannelOptions
	{
		MqttClientTlsOptions TlsOptions { get; }
	}
	public interface IMqttClientCredentials
	{
		string Username { get; }

		byte[] Password { get; }
	}
	public interface IMqttClientOptions
	{
		string ClientId { get; }

		bool CleanSession { get; }

		IMqttClientCredentials Credentials { get; }

		IMqttExtendedAuthenticationExchangeHandler ExtendedAuthenticationExchangeHandler { get; }

		MqttProtocolVersion ProtocolVersion { get; }

		IMqttClientChannelOptions ChannelOptions { get; }

		TimeSpan CommunicationTimeout { get; }

		TimeSpan KeepAlivePeriod { get; }

		MqttApplicationMessage WillMessage { get; }

		uint? WillDelayInterval { get; }

		string AuthenticationMethod { get; }

		byte[] AuthenticationData { get; }

		uint? MaximumPacketSize { get; }

		ushort? ReceiveMaximum { get; }

		bool? RequestProblemInformation { get; }

		bool? RequestResponseInformation { get; }

		uint? SessionExpiryInterval { get; }

		ushort? TopicAliasMaximum { get; }

		List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttClientCertificateValidationCallbackContext
	{
		public X509Certificate Certificate { get; set; }

		public X509Chain Chain { get; set; }

		public SslPolicyErrors SslPolicyErrors { get; set; }

		public IMqttClientChannelOptions ClientOptions { get; set; }
	}
	public class MqttClientCredentials : IMqttClientCredentials
	{
		public string Username { get; set; }

		public byte[] Password { get; set; }
	}
	public class MqttClientOptions : IMqttClientOptions
	{
		public string ClientId { get; set; } = Guid.NewGuid().ToString("N");

		public bool CleanSession { get; set; } = true;

		public IMqttClientCredentials Credentials { get; set; }

		public IMqttExtendedAuthenticationExchangeHandler ExtendedAuthenticationExchangeHandler { get; set; }

		public MqttProtocolVersion ProtocolVersion { get; set; } = MqttProtocolVersion.V311;

		public IMqttClientChannelOptions ChannelOptions { get; set; }

		public TimeSpan CommunicationTimeout { get; set; } = TimeSpan.FromSeconds(10.0);

		public TimeSpan KeepAlivePeriod { get; set; } = TimeSpan.FromSeconds(15.0);

		public MqttApplicationMessage WillMessage { get; set; }

		public uint? WillDelayInterval { get; set; }

		public string AuthenticationMethod { get; set; }

		public byte[] AuthenticationData { get; set; }

		public uint? MaximumPacketSize { get; set; }

		public ushort? ReceiveMaximum { get; set; }

		public bool? RequestProblemInformation { get; set; }

		public bool? RequestResponseInformation { get; set; }

		public uint? SessionExpiryInterval { get; set; }

		public ushort? TopicAliasMaximum { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttClientOptionsBuilder
	{
		private readonly MqttClientOptions _options = new MqttClientOptions();

		private MqttClientTcpOptions _tcpOptions;

		private MqttClientWebSocketOptions _webSocketOptions;

		private MqttClientOptionsBuilderTlsParameters _tlsParameters;

		private MqttClientWebSocketProxyOptions _proxyOptions;

		public MqttClientOptionsBuilder WithProtocolVersion(MqttProtocolVersion value)
		{
			if (value == MqttProtocolVersion.Unknown)
			{
				throw new ArgumentException("Protocol version is invalid.");
			}
			_options.ProtocolVersion = value;
			return this;
		}

		public MqttClientOptionsBuilder WithCommunicationTimeout(TimeSpan value)
		{
			_options.CommunicationTimeout = value;
			return this;
		}

		public MqttClientOptionsBuilder WithCleanSession(bool value = true)
		{
			_options.CleanSession = value;
			return this;
		}

		[Obsolete("This method is no longer supported. The client will send ping requests just before the keep alive interval is going to elapse. As per MQTT RFC the serve has to wait 1.5 times the interval so we don't need this anymore.")]
		public MqttClientOptionsBuilder WithKeepAliveSendInterval(TimeSpan value)
		{
			return this;
		}

		public MqttClientOptionsBuilder WithNoKeepAlive()
		{
			return WithKeepAlivePeriod(TimeSpan.Zero);
		}

		public MqttClientOptionsBuilder WithKeepAlivePeriod(TimeSpan value)
		{
			_options.KeepAlivePeriod = value;
			return this;
		}

		public MqttClientOptionsBuilder WithClientId(string value)
		{
			_options.ClientId = value;
			return this;
		}

		public MqttClientOptionsBuilder WithWillMessage(MqttApplicationMessage value)
		{
			_options.WillMessage = value;
			return this;
		}

		public MqttClientOptionsBuilder WithAuthentication(string method, byte[] data)
		{
			_options.AuthenticationMethod = method;
			_options.AuthenticationData = data;
			return this;
		}

		public MqttClientOptionsBuilder WithWillDelayInterval(uint? willDelayInterval)
		{
			_options.WillDelayInterval = willDelayInterval;
			return this;
		}

		public MqttClientOptionsBuilder WithTopicAliasMaximum(ushort? topicAliasMaximum)
		{
			_options.TopicAliasMaximum = topicAliasMaximum;
			return this;
		}

		public MqttClientOptionsBuilder WithMaximumPacketSize(uint? maximumPacketSize)
		{
			_options.MaximumPacketSize = maximumPacketSize;
			return this;
		}

		public MqttClientOptionsBuilder WithReceiveMaximum(ushort? receiveMaximum)
		{
			_options.ReceiveMaximum = receiveMaximum;
			return this;
		}

		public MqttClientOptionsBuilder WithRequestProblemInformation(bool? requestProblemInformation = true)
		{
			_options.RequestProblemInformation = requestProblemInformation;
			return this;
		}

		public MqttClientOptionsBuilder WithRequestResponseInformation(bool? requestResponseInformation = true)
		{
			_options.RequestResponseInformation = requestResponseInformation;
			return this;
		}

		public MqttClientOptionsBuilder WithSessionExpiryInterval(uint? sessionExpiryInterval)
		{
			_options.SessionExpiryInterval = sessionExpiryInterval;
			return this;
		}

		public MqttClientOptionsBuilder WithUserProperty(string name, string value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (_options.UserProperties == null)
			{
				_options.UserProperties = new List<MqttUserProperty>();
			}
			_options.UserProperties.Add(new MqttUserProperty(name, value));
			return this;
		}

		public MqttClientOptionsBuilder WithCredentials(string username, string password = null)
		{
			byte[] password2 = null;
			if (password != null)
			{
				password2 = Encoding.UTF8.GetBytes(password);
			}
			return WithCredentials(username, password2);
		}

		public MqttClientOptionsBuilder WithCredentials(string username, byte[] password = null)
		{
			_options.Credentials = new MqttClientCredentials
			{
				Username = username,
				Password = password
			};
			return this;
		}

		public MqttClientOptionsBuilder WithCredentials(IMqttClientCredentials credentials)
		{
			_options.Credentials = credentials;
			return this;
		}

		public MqttClientOptionsBuilder WithExtendedAuthenticationExchangeHandler(IMqttExtendedAuthenticationExchangeHandler handler)
		{
			_options.ExtendedAuthenticationExchangeHandler = handler;
			return this;
		}

		public MqttClientOptionsBuilder WithTcpServer(string server, int? port = null)
		{
			_tcpOptions = new MqttClientTcpOptions
			{
				Server = server,
				Port = port
			};
			return this;
		}

		public MqttClientOptionsBuilder WithTcpServer(Action<MqttClientTcpOptions> optionsBuilder)
		{
			if (optionsBuilder == null)
			{
				throw new ArgumentNullException("optionsBuilder");
			}
			_tcpOptions = new MqttClientTcpOptions();
			optionsBuilder(_tcpOptions);
			return this;
		}

		public MqttClientOptionsBuilder WithProxy(string address, string username = null, string password = null, string domain = null, bool bypassOnLocal = false, string[] bypassList = null)
		{
			_proxyOptions = new MqttClientWebSocketProxyOptions
			{
				Address = address,
				Username = username,
				Password = password,
				Domain = domain,
				BypassOnLocal = bypassOnLocal,
				BypassList = bypassList
			};
			return this;
		}

		public MqttClientOptionsBuilder WithProxy(Action<MqttClientWebSocketProxyOptions> optionsBuilder)
		{
			if (optionsBuilder == null)
			{
				throw new ArgumentNullException("optionsBuilder");
			}
			_proxyOptions = new MqttClientWebSocketProxyOptions();
			optionsBuilder(_proxyOptions);
			return this;
		}

		public MqttClientOptionsBuilder WithWebSocketServer(string uri, MqttClientOptionsBuilderWebSocketParameters parameters = null)
		{
			_webSocketOptions = new MqttClientWebSocketOptions
			{
				Uri = uri,
				RequestHeaders = parameters?.RequestHeaders,
				CookieContainer = parameters?.CookieContainer
			};
			return this;
		}

		public MqttClientOptionsBuilder WithWebSocketServer(Action<MqttClientWebSocketOptions> optionsBuilder)
		{
			if (optionsBuilder == null)
			{
				throw new ArgumentNullException("optionsBuilder");
			}
			_webSocketOptions = new MqttClientWebSocketOptions();
			optionsBuilder(_webSocketOptions);
			return this;
		}

		public MqttClientOptionsBuilder WithTls(MqttClientOptionsBuilderTlsParameters parameters)
		{
			_tlsParameters = parameters;
			return this;
		}

		public MqttClientOptionsBuilder WithTls()
		{
			return WithTls(new MqttClientOptionsBuilderTlsParameters
			{
				UseTls = true
			});
		}

		public MqttClientOptionsBuilder WithTls(Action<MqttClientOptionsBuilderTlsParameters> optionsBuilder)
		{
			if (optionsBuilder == null)
			{
				throw new ArgumentNullException("optionsBuilder");
			}
			_tlsParameters = new MqttClientOptionsBuilderTlsParameters();
			optionsBuilder(_tlsParameters);
			return this;
		}

		public IMqttClientOptions Build()
		{
			if (_tcpOptions == null && _webSocketOptions == null)
			{
				throw new InvalidOperationException("A channel must be set.");
			}
			if (_tlsParameters != null)
			{
				MqttClientOptionsBuilderTlsParameters tlsParameters = _tlsParameters;
				if (tlsParameters != null && tlsParameters.UseTls)
				{
					MqttClientTlsOptions tlsOptions = new MqttClientTlsOptions
					{
						UseTls = true,
						SslProtocol = _tlsParameters.SslProtocol,
						AllowUntrustedCertificates = _tlsParameters.AllowUntrustedCertificates,
						Certificates = _tlsParameters.Certificates?.ToList(),
						CertificateValidationCallback = _tlsParameters.CertificateValidationCallback,
						CertificateValidationHandler = _tlsParameters.CertificateValidationHandler,
						IgnoreCertificateChainErrors = _tlsParameters.IgnoreCertificateChainErrors,
						IgnoreCertificateRevocationErrors = _tlsParameters.IgnoreCertificateRevocationErrors
					};
					if (_tcpOptions != null)
					{
						_tcpOptions.TlsOptions = tlsOptions;
					}
					else if (_webSocketOptions != null)
					{
						_webSocketOptions.TlsOptions = tlsOptions;
					}
				}
			}
			if (_proxyOptions != null)
			{
				if (_webSocketOptions == null)
				{
					throw new InvalidOperationException("Proxies are only supported for WebSocket connections.");
				}
				_webSocketOptions.ProxyOptions = _proxyOptions;
			}
			MqttClientOptions options = _options;
			IMqttClientChannelOptions tcpOptions = _tcpOptions;
			options.ChannelOptions = tcpOptions ?? _webSocketOptions;
			return _options;
		}
	}
	public class MqttClientOptionsBuilderTlsParameters
	{
		public bool UseTls { get; set; }

		[Obsolete("This property will be removed soon. Use CertificateValidationHandler instead.")]
		public Func<X509Certificate, X509Chain, SslPolicyErrors, IMqttClientOptions, bool> CertificateValidationCallback { get; set; }

		public Func<MqttClientCertificateValidationCallbackContext, bool> CertificateValidationHandler { get; set; }

		public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12;

		public IEnumerable<X509Certificate> Certificates { get; set; }

		public bool AllowUntrustedCertificates { get; set; }

		public bool IgnoreCertificateChainErrors { get; set; }

		public bool IgnoreCertificateRevocationErrors { get; set; }
	}
	public class MqttClientOptionsBuilderWebSocketParameters
	{
		public IDictionary<string, string> RequestHeaders { get; set; }

		public CookieContainer CookieContainer { get; set; }
	}
	public class MqttClientTcpOptions : IMqttClientChannelOptions
	{
		public string Server { get; set; }

		public int? Port { get; set; }

		public int BufferSize { get; set; } = 65536;

		public bool? DualMode { get; set; }

		public bool NoDelay { get; set; } = true;

		public AddressFamily AddressFamily { get; set; }

		public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();

		public override string ToString()
		{
			return Server + ":" + this.GetPort();
		}
	}
	public static class MqttClientTcpOptionsExtensions
	{
		public static int GetPort(this MqttClientTcpOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (options.Port.HasValue)
			{
				return options.Port.Value;
			}
			if (options.TlsOptions.UseTls)
			{
				return 8883;
			}
			return 1883;
		}
	}
	public class MqttClientTlsOptions
	{
		public bool UseTls { get; set; }

		public bool IgnoreCertificateRevocationErrors { get; set; }

		public bool IgnoreCertificateChainErrors { get; set; }

		public bool AllowUntrustedCertificates { get; set; }

		public List<X509Certificate> Certificates { get; set; }

		public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12;

		[Obsolete("This property will be removed soon. Use CertificateValidationHandler instead.")]
		public Func<X509Certificate, X509Chain, SslPolicyErrors, IMqttClientOptions, bool> CertificateValidationCallback { get; set; }

		public Func<MqttClientCertificateValidationCallbackContext, bool> CertificateValidationHandler { get; set; }
	}
	public class MqttClientWebSocketOptions : IMqttClientChannelOptions
	{
		public string Uri { get; set; }

		public IDictionary<string, string> RequestHeaders { get; set; }

		public ICollection<string> SubProtocols { get; set; } = new List<string> { "mqtt" };

		public CookieContainer CookieContainer { get; set; }

		public MqttClientWebSocketProxyOptions ProxyOptions { get; set; }

		public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();

		public override string ToString()
		{
			return Uri;
		}
	}
	public class MqttClientWebSocketProxyOptions
	{
		public string Address { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Domain { get; set; }

		public bool BypassOnLocal { get; set; }

		public string[] BypassList { get; set; }
	}
}
namespace MQTTnet.Client.ExtendedAuthenticationExchange
{
	public interface IMqttExtendedAuthenticationExchangeHandler
	{
		Task HandleRequestAsync(MqttExtendedAuthenticationExchangeContext context);
	}
	public class MqttExtendedAuthenticationExchangeContext
	{
		public MqttAuthenticateReasonCode ReasonCode { get; }

		public string ReasonString { get; }

		public string AuthenticationMethod { get; }

		public byte[] AuthenticationData { get; }

		public List<MqttUserProperty> UserProperties { get; }

		public IMqttClient Client { get; }

		public MqttExtendedAuthenticationExchangeContext(MqttAuthPacket authPacket, IMqttClient client)
		{
			if (authPacket == null)
			{
				throw new ArgumentNullException("authPacket");
			}
			ReasonCode = authPacket.ReasonCode;
			ReasonString = authPacket.Properties?.ReasonString;
			AuthenticationMethod = authPacket.Properties?.AuthenticationMethod;
			AuthenticationData = authPacket.Properties?.AuthenticationData;
			UserProperties = authPacket.Properties?.UserProperties;
			Client = client ?? throw new ArgumentNullException("client");
		}
	}
	public class MqttExtendedAuthenticationExchangeData
	{
		public MqttAuthenticateReasonCode ReasonCode { get; set; }

		public string ReasonString { get; set; }

		public byte[] AuthenticationData { get; set; }

		public List<MqttUserProperty> UserProperties { get; }
	}
}
namespace MQTTnet.Client.Disconnecting
{
	public interface IMqttClientDisconnectedHandler
	{
		Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs);
	}
	public class MqttClientDisconnectedEventArgs : EventArgs
	{
		public bool ClientWasConnected { get; }

		public Exception Exception { get; }

		public MqttClientAuthenticateResult AuthenticateResult { get; }

		public MqttClientDisconnectReason ReasonCode { get; set; }

		public MqttClientDisconnectedEventArgs(bool clientWasConnected, Exception exception, MqttClientAuthenticateResult authenticateResult, MqttClientDisconnectReason reasonCode)
		{
			ClientWasConnected = clientWasConnected;
			Exception = exception;
			AuthenticateResult = authenticateResult;
			ReasonCode = reasonCode;
		}
	}
	public class MqttClientDisconnectedHandlerDelegate : IMqttClientDisconnectedHandler
	{
		private readonly Func<MqttClientDisconnectedEventArgs, Task> _handler;

		public MqttClientDisconnectedHandlerDelegate(Action<MqttClientDisconnectedEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttClientDisconnectedEventArgs context)
			{
				handler(context);
				return Task.FromResult(0);
			};
		}

		public MqttClientDisconnectedHandlerDelegate(Func<MqttClientDisconnectedEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public class MqttClientDisconnectOptions
	{
		public MqttClientDisconnectReason ReasonCode { get; set; }

		public string ReasonString { get; set; }
	}
	public enum MqttClientDisconnectReason
	{
		NormalDisconnection = 0,
		DisconnectWithWillMessage = 4,
		UnspecifiedError = 128,
		MalformedPacket = 129,
		ProtocolError = 130,
		ImplementationSpecificError = 131,
		NotAuthorized = 135,
		ServerBusy = 137,
		ServerShuttingDown = 139,
		BadAuthenticationMethod = 140,
		KeepaliveTimeout = 141,
		SessionTakenOver = 142,
		TopicFilterInvalid = 143,
		TopicNameInvalid = 144,
		ReceiveMaximumExceeded = 147,
		TopicAliasInvalid = 148,
		PacketTooLarge = 149,
		MessageRateTooHigh = 150,
		QuotaExceeded = 151,
		AdministrativeAction = 152,
		PayloadFormatInvalid = 153,
		RetainNotSupported = 154,
		QosNotSupported = 155,
		UseAnotherServer = 156,
		ServerMoved = 157,
		SharedSubscriptionsNotSupported = 158,
		ConnectionRateExceeded = 159,
		MaximumConnectTime = 160,
		SubscriptionIdentifiersNotSupported = 161,
		WildcardSubscriptionsNotSupported = 162
	}
}
namespace MQTTnet.Client.Connecting
{
	public interface IMqttClientConnectedHandler
	{
		Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs);
	}
	public class MqttClientAuthenticateResult
	{
		public MqttClientConnectResultCode ResultCode { get; set; }

		public bool IsSessionPresent { get; set; }

		public bool? WildcardSubscriptionAvailable { get; set; }

		public bool? RetainAvailable { get; set; }

		public string AssignedClientIdentifier { get; set; }

		public string AuthenticationMethod { get; set; }

		public byte[] AuthenticationData { get; set; }

		public uint? MaximumPacketSize { get; set; }

		public string ReasonString { get; set; }

		public ushort? ReceiveMaximum { get; set; }

		public string ResponseInformation { get; set; }

		public ushort? TopicAliasMaximum { get; set; }

		public string ServerReference { get; set; }

		public ushort? ServerKeepAlive { get; set; }

		public uint? SessionExpiryInterval { get; set; }

		public bool? SubscriptionIdentifiersAvailable { get; set; }

		public bool? SharedSubscriptionAvailable { get; set; }

		public List<MqttUserProperty> UserProperties { get; set; }
	}
	public class MqttClientConnectedEventArgs : EventArgs
	{
		public MqttClientAuthenticateResult AuthenticateResult { get; }

		public MqttClientConnectedEventArgs(MqttClientAuthenticateResult authenticateResult)
		{
			AuthenticateResult = authenticateResult ?? throw new ArgumentNullException("authenticateResult");
		}
	}
	public class MqttClientConnectedHandlerDelegate : IMqttClientConnectedHandler
	{
		private readonly Func<MqttClientConnectedEventArgs, Task> _handler;

		public MqttClientConnectedHandlerDelegate(Action<MqttClientConnectedEventArgs> handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = delegate(MqttClientConnectedEventArgs context)
			{
				handler(context);
				return Task.FromResult(0);
			};
		}

		public MqttClientConnectedHandlerDelegate(Func<MqttClientConnectedEventArgs, Task> handler)
		{
			_handler = handler ?? throw new ArgumentNullException("handler");
		}

		public Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
		{
			return _handler(eventArgs);
		}
	}
	public enum MqttClientConnectResultCode
	{
		Success = 0,
		UnspecifiedError = 128,
		MalformedPacket = 129,
		ProtocolError = 130,
		ImplementationSpecificError = 131,
		UnsupportedProtocolVersion = 132,
		ClientIdentifierNotValid = 133,
		BadUserNameOrPassword = 134,
		NotAuthorized = 135,
		ServerUnavailable = 136,
		ServerBusy = 137,
		Banned = 138,
		BadAuthenticationMethod = 140,
		TopicNameInvalid = 144,
		PacketTooLarge = 149,
		QuotaExceeded = 151,
		PayloadFormatInvalid = 153,
		RetainNotSupported = 154,
		QoSNotSupported = 155,
		UseAnotherServer = 156,
		ServerMoved = 157,
		ConnectionRateExceeded = 159
	}
}
namespace MQTTnet.Channel
{
	public interface IMqttChannel : IDisposable
	{
		string Endpoint { get; }

		bool IsSecureConnection { get; }

		X509Certificate2 ClientCertificate { get; }

		Task ConnectAsync(CancellationToken cancellationToken);

		Task DisconnectAsync(CancellationToken cancellationToken);

		Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);

		Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
	}
}
namespace MQTTnet.Certificates
{
	public class BlobCertificateProvider : ICertificateProvider
	{
		public byte[] Blob { get; }

		public string Password { get; set; }

		public BlobCertificateProvider(byte[] blob)
		{
			Blob = blob ?? throw new ArgumentNullException("blob");
		}

		public X509Certificate2 GetCertificate()
		{
			if (string.IsNullOrEmpty(Password))
			{
				return new X509Certificate2(Blob);
			}
			return new X509Certificate2(Blob, Password);
		}
	}
	public interface ICertificateProvider
	{
		X509Certificate2 GetCertificate();
	}
	public class X509CertificateProvider : ICertificateProvider
	{
		private readonly X509Certificate2 _certificate;

		public X509CertificateProvider(X509Certificate2 certificate)
		{
			_certificate = certificate ?? throw new ArgumentNullException("certificate");
		}

		public X509Certificate2 GetCertificate()
		{
			return _certificate;
		}
	}
}
namespace MQTTnet.Adapter
{
	public interface IMqttChannelAdapter : IDisposable
	{
		string Endpoint { get; }

		bool IsSecureConnection { get; }

		X509Certificate2 ClientCertificate { get; }

		MqttPacketFormatterAdapter PacketFormatterAdapter { get; }

		long BytesSent { get; }

		long BytesReceived { get; }

		Action ReadingPacketStartedCallback { get; set; }

		Action ReadingPacketCompletedCallback { get; set; }

		Task ConnectAsync(TimeSpan timeout, CancellationToken cancellationToken);

		Task DisconnectAsync(TimeSpan timeout, CancellationToken cancellationToken);

		Task SendPacketAsync(MqttBasePacket packet, TimeSpan timeout, CancellationToken cancellationToken);

		Task<MqttBasePacket> ReceivePacketAsync(TimeSpan timeout, CancellationToken cancellationToken);

		void ResetStatistics();
	}
	public interface IMqttClientAdapterFactory
	{
		IMqttChannelAdapter CreateClientAdapter(IMqttClientOptions options);
	}
	public interface IMqttServerAdapter : IDisposable
	{
		Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }

		Task StartAsync(IMqttServerOptions options);

		Task StopAsync();
	}
	public sealed class MqttChannelAdapter : Disposable, IMqttChannelAdapter, IDisposable
	{
		private const uint ErrorOperationAborted = 2147943395u;

		private const int ReadBufferSize = 4096;

		private readonly IMqttNetScopedLogger _logger;

		private readonly IMqttChannel _channel;

		private readonly MqttPacketReader _packetReader;

		private readonly byte[] _fixedHeaderBuffer = new byte[2];

		private readonly AsyncLock _syncRoot = new AsyncLock();

		private long _bytesReceived;

		private long _bytesSent;

		public string Endpoint => _channel.Endpoint;

		public bool IsSecureConnection => _channel.IsSecureConnection;

		public X509Certificate2 ClientCertificate => _channel.ClientCertificate;

		public MqttPacketFormatterAdapter PacketFormatterAdapter { get; }

		public long BytesSent => Interlocked.Read(ref _bytesSent);

		public long BytesReceived => Interlocked.Read(ref _bytesReceived);

		public Action ReadingPacketStartedCallback { get; set; }

		public Action ReadingPacketCompletedCallback { get; set; }

		public MqttChannelAdapter(IMqttChannel channel, MqttPacketFormatterAdapter packetFormatterAdapter, IMqttNetLogger logger)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_channel = channel ?? throw new ArgumentNullException("channel");
			PacketFormatterAdapter = packetFormatterAdapter ?? throw new ArgumentNullException("packetFormatterAdapter");
			_packetReader = new MqttPacketReader(_channel);
			_logger = logger.CreateScopedLogger("MqttChannelAdapter");
		}

		public async Task ConnectAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			try
			{
				if (timeout == TimeSpan.Zero)
				{
					await _channel.ConnectAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				await MqttTaskTimeout.WaitAsync((CancellationToken t) => _channel.ConnectAsync(t), timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				if (IsWrappedException(exception))
				{
					throw;
				}
				WrapException(exception);
			}
		}

		public async Task DisconnectAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			try
			{
				if (timeout == TimeSpan.Zero)
				{
					await _channel.DisconnectAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				await MqttTaskTimeout.WaitAsync((CancellationToken t) => _channel.DisconnectAsync(t), timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				if (IsWrappedException(exception))
				{
					throw;
				}
				WrapException(exception);
			}
		}

		public async Task SendPacketAsync(MqttBasePacket packet, TimeSpan timeout, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			try
			{
				using (await _syncRoot.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
				{
					cancellationToken.ThrowIfCancellationRequested();
					try
					{
						ArraySegment<byte> packetData = PacketFormatterAdapter.Encode(packet);
						if (!(timeout == TimeSpan.Zero))
						{
							await MqttTaskTimeout.WaitAsync((CancellationToken t) => _channel.WriteAsync(packetData.Array, packetData.Offset, packetData.Count, t), timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						else
						{
							await _channel.WriteAsync(packetData.Array, packetData.Offset, packetData.Count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						}
						Interlocked.Add(ref _bytesReceived, packetData.Count);
						_logger.Verbose("TX ({0} bytes) >>> {1}", packetData.Count, packet);
					}
					catch (Exception exception)
					{
						if (IsWrappedException(exception))
						{
							throw;
						}
						WrapException(exception);
					}
					finally
					{
						PacketFormatterAdapter.FreeBuffer();
					}
				}
			}
			catch (ObjectDisposedException)
			{
				throw new OperationCanceledException();
			}
		}

		public async Task<MqttBasePacket> ReceivePacketAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			try
			{
				ReceivedMqttPacket receivedMqttPacket = ((!(timeout == TimeSpan.Zero)) ? (await MqttTaskTimeout.WaitAsync(ReceiveAsync, timeout, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) : (await ReceiveAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
				if (receivedMqttPacket == null || cancellationToken.IsCancellationRequested)
				{
					return null;
				}
				Interlocked.Add(ref _bytesSent, receivedMqttPacket.TotalLength);
				if (PacketFormatterAdapter.ProtocolVersion == MqttProtocolVersion.Unknown)
				{
					PacketFormatterAdapter.DetectProtocolVersion(receivedMqttPacket);
				}
				MqttBasePacket mqttBasePacket = PacketFormatterAdapter.Decode(receivedMqttPacket);
				if (mqttBasePacket == null)
				{
					throw new MqttProtocolViolationException("Received malformed packet.");
				}
				_logger.Verbose("RX ({0} bytes) <<< {1}", receivedMqttPacket.TotalLength, mqttBasePacket);
				return mqttBasePacket;
			}
			catch (OperationCanceledException)
			{
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception exception)
			{
				if (IsWrappedException(exception))
				{
					throw;
				}
				WrapException(exception);
			}
			return null;
		}

		public void ResetStatistics()
		{
			Interlocked.Exchange(ref _bytesReceived, 0L);
			Interlocked.Exchange(ref _bytesSent, 0L);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_channel.Dispose();
				_syncRoot.Dispose();
			}
			base.Dispose(disposing);
		}

		private async Task<ReceivedMqttPacket> ReceiveAsync(CancellationToken cancellationToken)
		{
			ReadFixedHeaderResult readFixedHeaderResult = await _packetReader.ReadFixedHeaderAsync(_fixedHeaderBuffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (cancellationToken.IsCancellationRequested)
			{
				return null;
			}
			try
			{
				if (readFixedHeaderResult.ConnectionClosed)
				{
					return null;
				}
				ReadingPacketStartedCallback?.Invoke();
				MqttFixedHeader fixedHeader = readFixedHeaderResult.FixedHeader;
				if (fixedHeader.RemainingLength == 0)
				{
					return new ReceivedMqttPacket(fixedHeader.Flags, null, 2);
				}
				byte[] body = new byte[fixedHeader.RemainingLength];
				int bodyOffset = 0;
				int chunkSize = Math.Min(4096, fixedHeader.RemainingLength);
				do
				{
					int num = body.Length - bodyOffset;
					if (chunkSize > num)
					{
						chunkSize = num;
					}
					int num2 = await _channel.ReadAsync(body, bodyOffset, chunkSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (cancellationToken.IsCancellationRequested)
					{
						return null;
					}
					if (num2 == 0)
					{
						return null;
					}
					bodyOffset += num2;
				}
				while (bodyOffset < body.Length);
				MqttPacketBodyReader body2 = new MqttPacketBodyReader(body, 0, body.Length);
				return new ReceivedMqttPacket(fixedHeader.Flags, body2, fixedHeader.TotalLength);
			}
			finally
			{
				ReadingPacketCompletedCallback?.Invoke();
			}
		}

		private static bool IsWrappedException(Exception exception)
		{
			if (!(exception is OperationCanceledException) && !(exception is MqttCommunicationTimedOutException))
			{
				return exception is MqttCommunicationException;
			}
			return true;
		}

		private static void WrapException(Exception exception)
		{
			if (exception is IOException && exception.InnerException is SocketException ex)
			{
				exception = ex;
			}
			if (exception is SocketException ex2 && (ex2.SocketErrorCode == SocketError.ConnectionAborted || ex2.SocketErrorCode == SocketError.OperationAborted))
			{
				throw new OperationCanceledException();
			}
			if (exception is COMException { HResult: -2147023901 })
			{
				throw new OperationCanceledException();
			}
			throw new MqttCommunicationException(exception);
		}
	}
	public class MqttConnectingFailedException : MqttCommunicationException
	{
		public MqttClientAuthenticateResult Result { get; }

		public MqttClientConnectResultCode ResultCode => Result.ResultCode;

		public MqttConnectingFailedException(MqttClientAuthenticateResult result)
			: base("Connecting with MQTT server failed (" + result.ResultCode.ToString() + ").")
		{
			Result = result;
		}
	}
	public class ReceivedMqttPacket
	{
		public byte FixedHeader { get; set; }

		public IMqttPacketBodyReader Body { get; }

		public int TotalLength { get; }

		public ReceivedMqttPacket(byte fixedHeader, IMqttPacketBodyReader body, int totalLength)
		{
			FixedHeader = fixedHeader;
			Body = body;
			TotalLength = totalLength;
		}
	}
}
