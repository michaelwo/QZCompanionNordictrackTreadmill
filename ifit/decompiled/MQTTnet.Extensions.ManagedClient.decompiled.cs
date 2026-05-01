using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Publishing;
using MQTTnet.Client.Receiving;
using MQTTnet.Diagnostics;
using MQTTnet.Exceptions;
using MQTTnet.Internal;
using MQTTnet.Protocol;
using MQTTnet.Server;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("MQTTnet.Extensions.ManagedClient")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("3.0.12")]
[assembly: AssemblyInformationalVersion("1.0.0+6b6627f823105c05851b683c29cd2206697b4bdc")]
[assembly: AssemblyProduct("MQTTnet.Extensions.ManagedClient")]
[assembly: AssemblyTitle("MQTTnet.Extensions.ManagedClient")]
[assembly: AssemblyVersion("3.0.12.0")]
namespace MQTTnet.Extensions.ManagedClient;

public class ApplicationMessageProcessedEventArgs : EventArgs
{
	public ManagedMqttApplicationMessage ApplicationMessage { get; }

	public Exception Exception { get; }

	public bool HasFailed => Exception != null;

	public bool HasSucceeded => Exception == null;

	public ApplicationMessageProcessedEventArgs(ManagedMqttApplicationMessage applicationMessage, Exception exception)
	{
		ApplicationMessage = applicationMessage ?? throw new ArgumentNullException("applicationMessage");
		Exception = exception;
	}
}
public class ApplicationMessageProcessedHandlerDelegate : IApplicationMessageProcessedHandler
{
	private readonly Func<ApplicationMessageProcessedEventArgs, Task> _handler;

	public ApplicationMessageProcessedHandlerDelegate(Action<ApplicationMessageProcessedEventArgs> handler)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		_handler = delegate(ApplicationMessageProcessedEventArgs context)
		{
			handler(context);
			return Task.FromResult(0);
		};
	}

	public ApplicationMessageProcessedHandlerDelegate(Func<ApplicationMessageProcessedEventArgs, Task> handler)
	{
		_handler = handler ?? throw new ArgumentNullException("handler");
	}

	public Task HandleApplicationMessageProcessedAsync(ApplicationMessageProcessedEventArgs eventArgs)
	{
		return _handler(eventArgs);
	}
}
public class ApplicationMessageSkippedEventArgs : EventArgs
{
	public ManagedMqttApplicationMessage ApplicationMessage { get; }

	public ApplicationMessageSkippedEventArgs(ManagedMqttApplicationMessage applicationMessage)
	{
		ApplicationMessage = applicationMessage ?? throw new ArgumentNullException("applicationMessage");
	}
}
public class ApplicationMessageSkippedHandlerDelegate : IApplicationMessageSkippedHandler
{
	private readonly Func<ApplicationMessageSkippedEventArgs, Task> _handler;

	public ApplicationMessageSkippedHandlerDelegate(Action<ApplicationMessageSkippedEventArgs> handler)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		_handler = delegate(ApplicationMessageSkippedEventArgs eventArgs)
		{
			handler(eventArgs);
			return Task.FromResult(0);
		};
	}

	public ApplicationMessageSkippedHandlerDelegate(Func<ApplicationMessageSkippedEventArgs, Task> handler)
	{
		_handler = handler ?? throw new ArgumentNullException("handler");
	}

	public Task HandleApplicationMessageSkippedAsync(ApplicationMessageSkippedEventArgs eventArgs)
	{
		return _handler(eventArgs);
	}
}
public class ConnectingFailedHandlerDelegate : IConnectingFailedHandler
{
	private readonly Func<ManagedProcessFailedEventArgs, Task> _handler;

	public ConnectingFailedHandlerDelegate(Action<ManagedProcessFailedEventArgs> handler)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		_handler = delegate(ManagedProcessFailedEventArgs eventArgs)
		{
			handler(eventArgs);
			return Task.FromResult(0);
		};
	}

	public ConnectingFailedHandlerDelegate(Func<ManagedProcessFailedEventArgs, Task> handler)
	{
		_handler = handler ?? throw new ArgumentNullException("handler");
	}

	public Task HandleConnectingFailedAsync(ManagedProcessFailedEventArgs eventArgs)
	{
		return _handler(eventArgs);
	}
}
public interface IApplicationMessageProcessedHandler
{
	Task HandleApplicationMessageProcessedAsync(ApplicationMessageProcessedEventArgs eventArgs);
}
public interface IApplicationMessageSkippedHandler
{
	Task HandleApplicationMessageSkippedAsync(ApplicationMessageSkippedEventArgs eventArgs);
}
public interface IConnectingFailedHandler
{
	Task HandleConnectingFailedAsync(ManagedProcessFailedEventArgs eventArgs);
}
public interface IManagedMqttClient : IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
{
	bool IsStarted { get; }

	bool IsConnected { get; }

	int PendingApplicationMessagesCount { get; }

	IManagedMqttClientOptions Options { get; }

	IMqttClientConnectedHandler ConnectedHandler { get; set; }

	IMqttClientDisconnectedHandler DisconnectedHandler { get; set; }

	IApplicationMessageProcessedHandler ApplicationMessageProcessedHandler { get; set; }

	IApplicationMessageSkippedHandler ApplicationMessageSkippedHandler { get; set; }

	IConnectingFailedHandler ConnectingFailedHandler { get; set; }

	ISynchronizingSubscriptionsFailedHandler SynchronizingSubscriptionsFailedHandler { get; set; }

	Task StartAsync(IManagedMqttClientOptions options);

	Task StopAsync();

	Task PingAsync(CancellationToken cancellationToken);

	Task SubscribeAsync(IEnumerable<MqttTopicFilter> topicFilters);

	Task UnsubscribeAsync(IEnumerable<string> topics);

	Task PublishAsync(ManagedMqttApplicationMessage applicationMessages);
}
public interface IManagedMqttClientOptions
{
	IMqttClientOptions ClientOptions { get; }

	TimeSpan AutoReconnectDelay { get; }

	TimeSpan ConnectionCheckInterval { get; }

	IManagedMqttClientStorage Storage { get; }

	int MaxPendingMessages { get; }

	MqttPendingMessagesOverflowStrategy PendingMessagesOverflowStrategy { get; }
}
public interface IManagedMqttClientStorage
{
	Task SaveQueuedMessagesAsync(IList<ManagedMqttApplicationMessage> messages);

	Task<IList<ManagedMqttApplicationMessage>> LoadQueuedMessagesAsync();
}
public interface ISynchronizingSubscriptionsFailedHandler
{
	Task HandleSynchronizingSubscriptionsFailedAsync(ManagedProcessFailedEventArgs eventArgs);
}
public class ManagedMqttApplicationMessage
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public MqttApplicationMessage ApplicationMessage { get; set; }
}
public class ManagedMqttApplicationMessageBuilder
{
	private Guid _id = Guid.NewGuid();

	private MqttApplicationMessage _applicationMessage;

	public ManagedMqttApplicationMessageBuilder WithId(Guid id)
	{
		_id = id;
		return this;
	}

	public ManagedMqttApplicationMessageBuilder WithApplicationMessage(MqttApplicationMessage applicationMessage)
	{
		_applicationMessage = applicationMessage;
		return this;
	}

	public ManagedMqttApplicationMessageBuilder WithApplicationMessage(Action<MqttApplicationMessageBuilder> builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		MqttApplicationMessageBuilder mqttApplicationMessageBuilder = new MqttApplicationMessageBuilder();
		builder(mqttApplicationMessageBuilder);
		_applicationMessage = mqttApplicationMessageBuilder.Build();
		return this;
	}

	public ManagedMqttApplicationMessage Build()
	{
		if (_applicationMessage == null)
		{
			throw new InvalidOperationException("The ApplicationMessage cannot be null.");
		}
		return new ManagedMqttApplicationMessage
		{
			Id = _id,
			ApplicationMessage = _applicationMessage
		};
	}
}
public class ManagedMqttClient : Disposable, IManagedMqttClient, IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
{
	private readonly BlockingQueue<ManagedMqttApplicationMessage> _messageQueue = new BlockingQueue<ManagedMqttApplicationMessage>();

	private readonly Dictionary<string, MqttQualityOfServiceLevel> _reconnectSubscriptions = new Dictionary<string, MqttQualityOfServiceLevel>();

	private readonly Dictionary<string, MqttQualityOfServiceLevel> _subscriptions = new Dictionary<string, MqttQualityOfServiceLevel>();

	private readonly HashSet<string> _unsubscriptions = new HashSet<string>();

	private readonly SemaphoreSlim _subscriptionsQueuedSignal = new SemaphoreSlim(0);

	private readonly IMqttClient _mqttClient;

	private readonly IMqttNetScopedLogger _logger;

	private readonly AsyncLock _messageQueueLock = new AsyncLock();

	private CancellationTokenSource _connectionCancellationToken;

	private CancellationTokenSource _publishingCancellationToken;

	private Task _maintainConnectionTask;

	private ManagedMqttClientStorageManager _storageManager;

	public bool IsConnected => _mqttClient.IsConnected;

	public bool IsStarted => _connectionCancellationToken != null;

	public int PendingApplicationMessagesCount => _messageQueue.Count;

	public IManagedMqttClientOptions Options { get; private set; }

	public IMqttClientConnectedHandler ConnectedHandler
	{
		get
		{
			return _mqttClient.ConnectedHandler;
		}
		set
		{
			_mqttClient.ConnectedHandler = value;
		}
	}

	public IMqttClientDisconnectedHandler DisconnectedHandler
	{
		get
		{
			return _mqttClient.DisconnectedHandler;
		}
		set
		{
			_mqttClient.DisconnectedHandler = value;
		}
	}

	public IMqttApplicationMessageReceivedHandler ApplicationMessageReceivedHandler
	{
		get
		{
			return _mqttClient.ApplicationMessageReceivedHandler;
		}
		set
		{
			_mqttClient.ApplicationMessageReceivedHandler = value;
		}
	}

	public IApplicationMessageProcessedHandler ApplicationMessageProcessedHandler { get; set; }

	public IApplicationMessageSkippedHandler ApplicationMessageSkippedHandler { get; set; }

	public IConnectingFailedHandler ConnectingFailedHandler { get; set; }

	public ISynchronizingSubscriptionsFailedHandler SynchronizingSubscriptionsFailedHandler { get; set; }

	public ManagedMqttClient(IMqttClient mqttClient, IMqttNetLogger logger)
	{
		_mqttClient = mqttClient ?? throw new ArgumentNullException("mqttClient");
		if (logger == null)
		{
			throw new ArgumentNullException("logger");
		}
		_logger = logger.CreateScopedLogger("ManagedMqttClient");
	}

	public async Task StartAsync(IManagedMqttClientOptions options)
	{
		ThrowIfDisposed();
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		if (options.ClientOptions == null)
		{
			throw new ArgumentException("The client options are not set.", "options");
		}
		Task maintainConnectionTask = _maintainConnectionTask;
		if (maintainConnectionTask != null && !maintainConnectionTask.IsCompleted)
		{
			throw new InvalidOperationException("The managed client is already started.");
		}
		Options = options;
		if (Options.Storage != null)
		{
			_storageManager = new ManagedMqttClientStorageManager(Options.Storage);
			foreach (ManagedMqttApplicationMessage item in await _storageManager.LoadQueuedMessagesAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_messageQueue.Enqueue(item);
			}
		}
		_connectionCancellationToken = new CancellationTokenSource();
		_maintainConnectionTask = Task.Run(() => MaintainConnectionAsync(_connectionCancellationToken.Token), _connectionCancellationToken.Token);
		_maintainConnectionTask.Forget(_logger);
		_logger.Info("Started");
	}

	public async Task StopAsync()
	{
		ThrowIfDisposed();
		StopPublishing();
		StopMaintainingConnection();
		_messageQueue.Clear();
		if (_maintainConnectionTask != null)
		{
			await Task.WhenAny(_maintainConnectionTask);
			_maintainConnectionTask = null;
		}
	}

	public Task PingAsync(CancellationToken cancellationToken)
	{
		return _mqttClient.PingAsync(cancellationToken);
	}

	public async Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		if (applicationMessage == null)
		{
			throw new ArgumentNullException("applicationMessage");
		}
		await PublishAsync(new ManagedMqttApplicationMessageBuilder().WithApplicationMessage(applicationMessage).Build()).ConfigureAwait(continueOnCapturedContext: false);
		return new MqttClientPublishResult();
	}

	public async Task PublishAsync(ManagedMqttApplicationMessage applicationMessage)
	{
		ThrowIfDisposed();
		if (applicationMessage == null)
		{
			throw new ArgumentNullException("applicationMessage");
		}
		if (Options == null)
		{
			throw new InvalidOperationException("call StartAsync before publishing messages");
		}
		MqttTopicValidator.ThrowIfInvalid(applicationMessage.ApplicationMessage.Topic);
		ManagedMqttApplicationMessage removedMessage = null;
		ApplicationMessageSkippedEventArgs applicationMessageSkippedEventArgs = null;
		object obj = null;
		int num = 0;
		try
		{
			using (await _messageQueueLock.WaitAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false))
			{
				if (_messageQueue.Count >= Options.MaxPendingMessages)
				{
					if (Options.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropNewMessage)
					{
						_logger.Verbose("Skipping publish of new application message because internal queue is full.");
						applicationMessageSkippedEventArgs = new ApplicationMessageSkippedEventArgs(applicationMessage);
						goto IL_02c8;
					}
					if (Options.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropOldestQueuedMessage)
					{
						removedMessage = _messageQueue.RemoveFirst();
						_logger.Verbose("Removed oldest application message from internal queue because it is full.");
						applicationMessageSkippedEventArgs = new ApplicationMessageSkippedEventArgs(removedMessage);
					}
				}
				_messageQueue.Enqueue(applicationMessage);
				if (_storageManager != null)
				{
					if (removedMessage != null)
					{
						await _storageManager.RemoveAsync(removedMessage).ConfigureAwait(continueOnCapturedContext: false);
					}
					await _storageManager.AddAsync(applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			goto end_IL_0080;
			IL_02c8:
			num = 1;
			end_IL_0080:;
		}
		catch (object obj2)
		{
			obj = obj2;
		}
		if (applicationMessageSkippedEventArgs != null)
		{
			IApplicationMessageSkippedHandler applicationMessageSkippedHandler = ApplicationMessageSkippedHandler;
			if (applicationMessageSkippedHandler != null)
			{
				await applicationMessageSkippedHandler.HandleApplicationMessageSkippedAsync(applicationMessageSkippedEventArgs).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		object obj3 = obj;
		if (obj3 != null)
		{
			ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
		}
		if (num != 1)
		{
		}
	}

	public Task SubscribeAsync(IEnumerable<MqttTopicFilter> topicFilters)
	{
		ThrowIfDisposed();
		if (topicFilters == null)
		{
			throw new ArgumentNullException("topicFilters");
		}
		lock (_subscriptions)
		{
			foreach (MqttTopicFilter topicFilter in topicFilters)
			{
				_subscriptions[topicFilter.Topic] = topicFilter.QualityOfServiceLevel;
				_unsubscriptions.Remove(topicFilter.Topic);
			}
		}
		_subscriptionsQueuedSignal.Release();
		return Task.FromResult(0);
	}

	public Task UnsubscribeAsync(IEnumerable<string> topics)
	{
		ThrowIfDisposed();
		if (topics == null)
		{
			throw new ArgumentNullException("topics");
		}
		lock (_subscriptions)
		{
			foreach (string topic in topics)
			{
				_subscriptions.Remove(topic);
				_unsubscriptions.Add(topic);
			}
		}
		_subscriptionsQueuedSignal.Release();
		return Task.FromResult(0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			StopPublishing();
			StopMaintainingConnection();
			if (_maintainConnectionTask != null)
			{
				_maintainConnectionTask.GetAwaiter().GetResult();
				_maintainConnectionTask = null;
			}
			_messageQueue.Dispose();
			_messageQueueLock.Dispose();
			_mqttClient.Dispose();
			_subscriptionsQueuedSignal.Dispose();
		}
		base.Dispose(disposing);
	}

	private async Task MaintainConnectionAsync(CancellationToken cancellationToken)
	{
		object obj = null;
		try
		{
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					await TryMaintainConnectionAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error exception while maintaining connection.");
			}
		}
		catch (object obj2)
		{
			obj = obj2;
		}
		if (!base.IsDisposed)
		{
			try
			{
				await _mqttClient.DisconnectAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception2)
			{
				_logger.Error(exception2, "Error while disconnecting.");
			}
			_logger.Info("Stopped");
		}
		_reconnectSubscriptions.Clear();
		lock (_subscriptions)
		{
			_subscriptions.Clear();
			_unsubscriptions.Clear();
		}
		object obj3 = obj;
		if (obj3 != null)
		{
			ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
		}
	}

	private async Task TryMaintainConnectionAsync(CancellationToken cancellationToken)
	{
		_ = 3;
		try
		{
			switch (await ReconnectIfRequiredAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
			case ReconnectionResult.NotConnected:
				StopPublishing();
				await Task.Delay(Options.AutoReconnectDelay, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				break;
			case ReconnectionResult.Reconnected:
				await PublishReconnectSubscriptionsAsync().ConfigureAwait(continueOnCapturedContext: false);
				StartPublishing();
				break;
			case ReconnectionResult.Recovered:
				StartPublishing();
				break;
			case ReconnectionResult.StillConnected:
				await PublishSubscriptionsAsync(Options.ConnectionCheckInterval, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				break;
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (MqttCommunicationException exception)
		{
			_logger.Warning(exception, "Communication error while maintaining connection.");
		}
		catch (Exception exception2)
		{
			_logger.Error(exception2, "Error exception while maintaining connection.");
		}
	}

	private async Task PublishQueuedMessagesAsync(CancellationToken cancellationToken)
	{
		try
		{
			while (!cancellationToken.IsCancellationRequested && _mqttClient.IsConnected)
			{
				ManagedMqttApplicationMessage managedMqttApplicationMessage = _messageQueue.PeekAndWait(cancellationToken);
				if (managedMqttApplicationMessage != null)
				{
					cancellationToken.ThrowIfCancellationRequested();
					await TryPublishQueuedMessageAsync(managedMqttApplicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception exception)
		{
			_logger.Error(exception, "Error while publishing queued application messages.");
		}
		finally
		{
			_logger.Verbose("Stopped publishing messages.");
		}
	}

	private async Task TryPublishQueuedMessageAsync(ManagedMqttApplicationMessage message)
	{
		Exception transmitException = null;
		object obj = null;
		try
		{
			try
			{
				await _mqttClient.PublishAsync(message.ApplicationMessage).ConfigureAwait(continueOnCapturedContext: false);
				using (await _messageQueueLock.WaitAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false))
				{
					_messageQueue.RemoveFirst((ManagedMqttApplicationMessage i) => i.Id.Equals(message.Id));
					if (_storageManager != null)
					{
						await _storageManager.RemoveAsync(message).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
			}
			catch (MqttCommunicationException ex)
			{
				transmitException = ex;
				_logger.Warning(ex, $"Publishing application ({message.Id}) message failed.");
				if (message.ApplicationMessage.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce)
				{
					using (await _messageQueueLock.WaitAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false))
					{
						_messageQueue.RemoveFirst((ManagedMqttApplicationMessage i) => i.Id.Equals(message.Id));
						if (_storageManager != null)
						{
							await _storageManager.RemoveAsync(message).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
				}
			}
			catch (Exception ex2)
			{
				transmitException = ex2;
				_logger.Error(ex2, $"Error while publishing application message ({message.Id}).");
			}
		}
		catch (object obj2)
		{
			obj = obj2;
		}
		IApplicationMessageProcessedHandler applicationMessageProcessedHandler = ApplicationMessageProcessedHandler;
		if (applicationMessageProcessedHandler != null)
		{
			ApplicationMessageProcessedEventArgs eventArgs = new ApplicationMessageProcessedEventArgs(message, transmitException);
			await applicationMessageProcessedHandler.HandleApplicationMessageProcessedAsync(eventArgs).ConfigureAwait(continueOnCapturedContext: false);
		}
		object obj3 = obj;
		if (obj3 != null)
		{
			ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
		}
	}

	private async Task PublishSubscriptionsAsync(TimeSpan timeout, CancellationToken cancellationToken)
	{
		DateTime endTime = DateTime.UtcNow + timeout;
		while (await _subscriptionsQueuedSignal.WaitAsync(GetRemainingTime(endTime), cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
			List<MqttTopicFilter> subscriptions;
			HashSet<string> hashSet;
			lock (_subscriptions)
			{
				subscriptions = _subscriptions.Select((KeyValuePair<string, MqttQualityOfServiceLevel> i) => new MqttTopicFilter
				{
					Topic = i.Key,
					QualityOfServiceLevel = i.Value
				}).ToList();
				_subscriptions.Clear();
				hashSet = new HashSet<string>(_unsubscriptions);
				_unsubscriptions.Clear();
			}
			if (!subscriptions.Any() && !hashSet.Any())
			{
				continue;
			}
			_logger.Verbose($"Publishing subscriptions ({subscriptions.Count} subscriptions and {hashSet.Count} unsubscriptions)");
			foreach (string item in hashSet)
			{
				_reconnectSubscriptions.Remove(item);
			}
			foreach (MqttTopicFilter item2 in subscriptions)
			{
				_reconnectSubscriptions[item2.Topic] = item2.QualityOfServiceLevel;
			}
			try
			{
				if (hashSet.Any())
				{
					await _mqttClient.UnsubscribeAsync(hashSet.ToArray()).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (subscriptions.Any())
				{
					await _mqttClient.SubscribeAsync(subscriptions.ToArray()).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				await HandleSubscriptionExceptionAsync(exception).ConfigureAwait(continueOnCapturedContext: false);
			}
			subscriptions = null;
		}
	}

	private async Task PublishReconnectSubscriptionsAsync()
	{
		_logger.Info("Publishing subscriptions at reconnect");
		try
		{
			if (_reconnectSubscriptions.Any())
			{
				IEnumerable<MqttTopicFilter> source = _reconnectSubscriptions.Select((KeyValuePair<string, MqttQualityOfServiceLevel> i) => new MqttTopicFilter
				{
					Topic = i.Key,
					QualityOfServiceLevel = i.Value
				});
				await _mqttClient.SubscribeAsync(source.ToArray()).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		catch (Exception exception)
		{
			await HandleSubscriptionExceptionAsync(exception).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private async Task HandleSubscriptionExceptionAsync(Exception exception)
	{
		_logger.Warning(exception, "Synchronizing subscriptions failed.");
		ISynchronizingSubscriptionsFailedHandler synchronizingSubscriptionsFailedHandler = SynchronizingSubscriptionsFailedHandler;
		if (SynchronizingSubscriptionsFailedHandler != null)
		{
			await synchronizingSubscriptionsFailedHandler.HandleSynchronizingSubscriptionsFailedAsync(new ManagedProcessFailedEventArgs(exception)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private async Task<ReconnectionResult> ReconnectIfRequiredAsync()
	{
		if (_mqttClient.IsConnected)
		{
			return ReconnectionResult.StillConnected;
		}
		ReconnectionResult result = default(ReconnectionResult);
		object obj;
		int num;
		try
		{
			result = ((!(await _mqttClient.ConnectAsync(Options.ClientOptions).ConfigureAwait(continueOnCapturedContext: false)).IsSessionPresent) ? ReconnectionResult.Reconnected : ReconnectionResult.Recovered);
			return result;
		}
		catch (Exception ex)
		{
			obj = ex;
			num = 1;
		}
		if (num != 1)
		{
			return result;
		}
		Exception exception = (Exception)obj;
		IConnectingFailedHandler connectingFailedHandler = ConnectingFailedHandler;
		if (connectingFailedHandler != null)
		{
			await connectingFailedHandler.HandleConnectingFailedAsync(new ManagedProcessFailedEventArgs(exception)).ConfigureAwait(continueOnCapturedContext: false);
		}
		return ReconnectionResult.NotConnected;
	}

	private void StartPublishing()
	{
		if (_publishingCancellationToken != null)
		{
			StopPublishing();
		}
		CancellationTokenSource cts = new CancellationTokenSource();
		_publishingCancellationToken = cts;
		Task.Run(() => PublishQueuedMessagesAsync(cts.Token), cts.Token).Forget(_logger);
	}

	private void StopPublishing()
	{
		_publishingCancellationToken?.Cancel(throwOnFirstException: false);
		_publishingCancellationToken?.Dispose();
		_publishingCancellationToken = null;
	}

	private void StopMaintainingConnection()
	{
		_connectionCancellationToken?.Cancel(throwOnFirstException: false);
		_connectionCancellationToken?.Dispose();
		_connectionCancellationToken = null;
	}

	private TimeSpan GetRemainingTime(DateTime endTime)
	{
		TimeSpan timeSpan = endTime - DateTime.UtcNow;
		if (!(timeSpan < TimeSpan.Zero))
		{
			return timeSpan;
		}
		return TimeSpan.Zero;
	}
}
public static class ManagedMqttClientExtensions
{
	public static IManagedMqttClient UseConnectedHandler(this IManagedMqttClient client, Func<MqttClientConnectedEventArgs, Task> handler)
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

	public static IManagedMqttClient UseConnectedHandler(this IManagedMqttClient client, Action<MqttClientConnectedEventArgs> handler)
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

	public static IManagedMqttClient UseConnectedHandler(this IManagedMqttClient client, IMqttClientConnectedHandler handler)
	{
		if (client == null)
		{
			throw new ArgumentNullException("client");
		}
		client.ConnectedHandler = handler;
		return client;
	}

	public static IManagedMqttClient UseDisconnectedHandler(this IManagedMqttClient client, Func<MqttClientDisconnectedEventArgs, Task> handler)
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

	public static IManagedMqttClient UseDisconnectedHandler(this IManagedMqttClient client, Action<MqttClientDisconnectedEventArgs> handler)
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

	public static IManagedMqttClient UseDisconnectedHandler(this IManagedMqttClient client, IMqttClientDisconnectedHandler handler)
	{
		if (client == null)
		{
			throw new ArgumentNullException("client");
		}
		client.DisconnectedHandler = handler;
		return client;
	}

	public static TReceiver UseApplicationMessageReceivedHandler<TReceiver>(this TReceiver receiver, Func<MqttApplicationMessageReceivedEventArgs, Task> handler) where TReceiver : IApplicationMessageReceiver
	{
		if (receiver == null)
		{
			throw new ArgumentNullException("receiver");
		}
		if (handler == null)
		{
			return receiver.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
		}
		return receiver.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
	}

	public static TReceiver UseApplicationMessageReceivedHandler<TReceiver>(this TReceiver receiver, Action<MqttApplicationMessageReceivedEventArgs> handler) where TReceiver : IApplicationMessageReceiver
	{
		if (receiver == null)
		{
			throw new ArgumentNullException("receiver");
		}
		if (handler == null)
		{
			return receiver.UseApplicationMessageReceivedHandler((IMqttApplicationMessageReceivedHandler)null);
		}
		return receiver.UseApplicationMessageReceivedHandler(new MqttApplicationMessageReceivedHandlerDelegate(handler));
	}

	public static TReceiver UseApplicationMessageReceivedHandler<TReceiver>(this TReceiver receiver, IMqttApplicationMessageReceivedHandler handler) where TReceiver : IApplicationMessageReceiver
	{
		if (receiver == null)
		{
			throw new ArgumentNullException("receiver");
		}
		receiver.ApplicationMessageReceivedHandler = handler;
		return receiver;
	}

	public static Task SubscribeAsync(this IManagedMqttClient client, params MqttTopicFilter[] topicFilters)
	{
		if (client == null)
		{
			throw new ArgumentNullException("client");
		}
		return client.SubscribeAsync(topicFilters);
	}

	public static Task SubscribeAsync(this IManagedMqttClient client, string topic, MqttQualityOfServiceLevel qualityOfServiceLevel)
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

	public static Task SubscribeAsync(this IManagedMqttClient client, string topic)
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

	public static Task UnsubscribeAsync(this IManagedMqttClient client, params string[] topicFilters)
	{
		if (client == null)
		{
			throw new ArgumentNullException("client");
		}
		return client.UnsubscribeAsync(topicFilters);
	}

	public static async Task PublishAsync(this IApplicationMessagePublisher publisher, IEnumerable<MqttApplicationMessage> applicationMessages)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (applicationMessages == null)
		{
			throw new ArgumentNullException("applicationMessages");
		}
		foreach (MqttApplicationMessage applicationMessage in applicationMessages)
		{
			await publisher.PublishAsync(applicationMessage).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, MqttApplicationMessage applicationMessage)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (applicationMessage == null)
		{
			throw new ArgumentNullException("applicationMessage");
		}
		return publisher.PublishAsync(applicationMessage, CancellationToken.None);
	}

	public static async Task PublishAsync(this IApplicationMessagePublisher publisher, params MqttApplicationMessage[] applicationMessages)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (applicationMessages == null)
		{
			throw new ArgumentNullException("applicationMessages");
		}
		foreach (MqttApplicationMessage applicationMessage in applicationMessages)
		{
			await publisher.PublishAsync(applicationMessage, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, string topic)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (topic == null)
		{
			throw new ArgumentNullException("topic");
		}
		return publisher.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic));
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, string topic, string payload)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (topic == null)
		{
			throw new ArgumentNullException("topic");
		}
		return publisher.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload));
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (topic == null)
		{
			throw new ArgumentNullException("topic");
		}
		return publisher.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel));
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, string topic, string payload, MqttQualityOfServiceLevel qualityOfServiceLevel, bool retain)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		if (topic == null)
		{
			throw new ArgumentNullException("topic");
		}
		return publisher.PublishAsync((MqttApplicationMessageBuilder builder) => builder.WithTopic(topic).WithPayload(payload).WithQualityOfServiceLevel(qualityOfServiceLevel)
			.WithRetainFlag(retain));
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, Func<MqttApplicationMessageBuilder, MqttApplicationMessageBuilder> builder, CancellationToken cancellationToken)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		MqttApplicationMessage applicationMessage = builder(new MqttApplicationMessageBuilder()).Build();
		return publisher.PublishAsync(applicationMessage, cancellationToken);
	}

	public static Task<MqttClientPublishResult> PublishAsync(this IApplicationMessagePublisher publisher, Func<MqttApplicationMessageBuilder, MqttApplicationMessageBuilder> builder)
	{
		if (publisher == null)
		{
			throw new ArgumentNullException("publisher");
		}
		MqttApplicationMessage applicationMessage = builder(new MqttApplicationMessageBuilder()).Build();
		return publisher.PublishAsync(applicationMessage, CancellationToken.None);
	}
}
public class ManagedMqttClientOptions : IManagedMqttClientOptions
{
	public IMqttClientOptions ClientOptions { get; set; }

	public TimeSpan AutoReconnectDelay { get; set; } = TimeSpan.FromSeconds(5.0);

	public TimeSpan ConnectionCheckInterval { get; set; } = TimeSpan.FromSeconds(1.0);

	public IManagedMqttClientStorage Storage { get; set; }

	public int MaxPendingMessages { get; set; } = 2147483647;

	public MqttPendingMessagesOverflowStrategy PendingMessagesOverflowStrategy { get; set; } = MqttPendingMessagesOverflowStrategy.DropNewMessage;
}
public class ManagedMqttClientOptionsBuilder
{
	private readonly ManagedMqttClientOptions _options = new ManagedMqttClientOptions();

	private MqttClientOptionsBuilder _clientOptionsBuilder;

	public ManagedMqttClientOptionsBuilder WithMaxPendingMessages(int value)
	{
		_options.MaxPendingMessages = value;
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithPendingMessagesOverflowStrategy(MqttPendingMessagesOverflowStrategy value)
	{
		_options.PendingMessagesOverflowStrategy = value;
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithAutoReconnectDelay(TimeSpan value)
	{
		_options.AutoReconnectDelay = value;
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithStorage(IManagedMqttClientStorage value)
	{
		_options.Storage = value;
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithClientOptions(IMqttClientOptions value)
	{
		if (_clientOptionsBuilder != null)
		{
			throw new InvalidOperationException("Cannot use client options builder and client options at the same time.");
		}
		_options.ClientOptions = value ?? throw new ArgumentNullException("value");
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithClientOptions(MqttClientOptionsBuilder builder)
	{
		if (_options.ClientOptions != null)
		{
			throw new InvalidOperationException("Cannot use client options builder and client options at the same time.");
		}
		_clientOptionsBuilder = builder;
		return this;
	}

	public ManagedMqttClientOptionsBuilder WithClientOptions(Action<MqttClientOptionsBuilder> options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		if (_clientOptionsBuilder == null)
		{
			_clientOptionsBuilder = new MqttClientOptionsBuilder();
		}
		options(_clientOptionsBuilder);
		return this;
	}

	public ManagedMqttClientOptions Build()
	{
		if (_clientOptionsBuilder != null)
		{
			_options.ClientOptions = _clientOptionsBuilder.Build();
		}
		if (_options.ClientOptions == null)
		{
			throw new InvalidOperationException("The ClientOptions cannot be null.");
		}
		return _options;
	}
}
public class ManagedMqttClientStorageManager
{
	private readonly List<ManagedMqttApplicationMessage> _messages = new List<ManagedMqttApplicationMessage>();

	private readonly AsyncLock _messagesLock = new AsyncLock();

	private readonly IManagedMqttClientStorage _storage;

	public ManagedMqttClientStorageManager(IManagedMqttClientStorage storage)
	{
		_storage = storage ?? throw new ArgumentNullException("storage");
	}

	public async Task<List<ManagedMqttApplicationMessage>> LoadQueuedMessagesAsync()
	{
		IList<ManagedMqttApplicationMessage> collection = await _storage.LoadQueuedMessagesAsync().ConfigureAwait(continueOnCapturedContext: false);
		_messages.AddRange(collection);
		return _messages;
	}

	public async Task AddAsync(ManagedMqttApplicationMessage applicationMessage)
	{
		if (applicationMessage == null)
		{
			throw new ArgumentNullException("applicationMessage");
		}
		using (await _messagesLock.WaitAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false))
		{
			_messages.Add(applicationMessage);
			await SaveAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public async Task RemoveAsync(ManagedMqttApplicationMessage applicationMessage)
	{
		if (applicationMessage == null)
		{
			throw new ArgumentNullException("applicationMessage");
		}
		using (await _messagesLock.WaitAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false))
		{
			int num = _messages.IndexOf(applicationMessage);
			if (num == -1)
			{
				return;
			}
			_messages.RemoveAt(num);
			await SaveAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private Task SaveAsync()
	{
		return _storage.SaveQueuedMessagesAsync(_messages);
	}
}
public class ManagedProcessFailedEventArgs : EventArgs
{
	public Exception Exception { get; }

	public ManagedProcessFailedEventArgs(Exception exception)
	{
		Exception = exception ?? throw new ArgumentNullException("exception");
	}
}
public static class MqttFactoryExtensions
{
	public static IManagedMqttClient CreateManagedMqttClient(this IMqttFactory factory)
	{
		if (factory == null)
		{
			throw new ArgumentNullException("factory");
		}
		return new ManagedMqttClient(factory.CreateMqttClient(), factory.DefaultLogger);
	}

	public static IManagedMqttClient CreateManagedMqttClient(this IMqttFactory factory, IMqttNetLogger logger)
	{
		if (factory == null)
		{
			throw new ArgumentNullException("factory");
		}
		if (logger == null)
		{
			throw new ArgumentNullException("logger");
		}
		return new ManagedMqttClient(factory.CreateMqttClient(logger), logger);
	}
}
public enum ReconnectionResult
{
	StillConnected,
	Reconnected,
	Recovered,
	NotConnected
}
public class SynchronizingSubscriptionsFailedHandlerDelegate : ISynchronizingSubscriptionsFailedHandler
{
	private readonly Func<ManagedProcessFailedEventArgs, Task> _handler;

	public SynchronizingSubscriptionsFailedHandlerDelegate(Action<ManagedProcessFailedEventArgs> handler)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		_handler = delegate(ManagedProcessFailedEventArgs context)
		{
			handler(context);
			return Task.FromResult(0);
		};
	}

	public SynchronizingSubscriptionsFailedHandlerDelegate(Func<ManagedProcessFailedEventArgs, Task> handler)
	{
		_handler = handler ?? throw new ArgumentNullException("handler");
	}

	public Task HandleSynchronizingSubscriptionsFailedAsync(ManagedProcessFailedEventArgs eventArgs)
	{
		return _handler(eventArgs);
	}
}
