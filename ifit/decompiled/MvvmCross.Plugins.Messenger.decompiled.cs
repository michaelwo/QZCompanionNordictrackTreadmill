using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.Messenger.Subscriptions;
using MvvmCross.Plugins.Messenger.ThreadRunners;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.Messenger")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.Messenger")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	public sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
namespace MvvmCross.Plugins.Messenger
{
	public enum MvxReference
	{
		Weak,
		Strong
	}
	[Preserve(AllMembers = true)]
	public class MvxSubscriberChangeMessage : MvxMessage
	{
		public Type MessageType { get; private set; }

		public int SubscriberCount { get; private set; }

		public MvxSubscriberChangeMessage(object sender, Type messageType, int countSubscribers = 0)
			: base(sender)
		{
			SubscriberCount = countSubscribers;
			MessageType = messageType;
		}
	}
	public abstract class MvxMessage
	{
		public object Sender { get; private set; }

		protected MvxMessage(object sender)
		{
			if (sender == null)
			{
				throw new ArgumentNullException("sender");
			}
			Sender = sender;
		}
	}
	public interface IMvxMessenger
	{
		MvxSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage;

		MvxSubscriptionToken SubscribeOnMainThread<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage;

		MvxSubscriptionToken SubscribeOnThreadPoolThread<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage;

		void Unsubscribe<TMessage>(MvxSubscriptionToken mvxSubscriptionId) where TMessage : MvxMessage;

		bool HasSubscriptionsFor<TMessage>() where TMessage : MvxMessage;

		int CountSubscriptionsFor<TMessage>() where TMessage : MvxMessage;

		bool HasSubscriptionsForTag<TMessage>(string tag) where TMessage : MvxMessage;

		int CountSubscriptionsForTag<TMessage>(string tag) where TMessage : MvxMessage;

		IList<string> GetSubscriptionTagsFor<TMessage>() where TMessage : MvxMessage;

		void Publish<TMessage>(TMessage message) where TMessage : MvxMessage;

		void Publish(MvxMessage message);

		void Publish(MvxMessage message, Type messageType);

		void RequestPurge(Type messageType);

		void RequestPurgeAll();
	}
	[Preserve(AllMembers = true)]
	public class MvxMessengerHub : IMvxMessenger
	{
		private readonly Dictionary<Type, Dictionary<Guid, BaseSubscription>> _subscriptions = new Dictionary<Type, Dictionary<Guid, BaseSubscription>>();

		private readonly Dictionary<Type, bool> _scheduledPurges = new Dictionary<Type, bool>();

		public MvxSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage
		{
			return SubscribeInternal(deliveryAction, new MvxSimpleActionRunner(), reference, tag);
		}

		public MvxSubscriptionToken SubscribeOnMainThread<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage
		{
			return SubscribeInternal(deliveryAction, new MvxMainThreadActionRunner(), reference, tag);
		}

		public MvxSubscriptionToken SubscribeOnThreadPoolThread<TMessage>(Action<TMessage> deliveryAction, MvxReference reference = MvxReference.Weak, string tag = null) where TMessage : MvxMessage
		{
			return SubscribeInternal(deliveryAction, new MvxThreadPoolActionRunner(), reference, tag);
		}

		private MvxSubscriptionToken SubscribeInternal<TMessage>(Action<TMessage> deliveryAction, IMvxActionRunner actionRunner, MvxReference reference, string tag) where TMessage : MvxMessage
		{
			if (deliveryAction == null)
			{
				throw new ArgumentNullException("deliveryAction");
			}
			BaseSubscription subscription;
			switch (reference)
			{
			case MvxReference.Strong:
				subscription = new StrongSubscription<TMessage>(actionRunner, deliveryAction, tag);
				break;
			case MvxReference.Weak:
				subscription = new WeakSubscription<TMessage>(actionRunner, deliveryAction, tag);
				break;
			default:
				throw new ArgumentOutOfRangeException("reference", "reference type unexpected " + reference);
			}
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					value = new Dictionary<Guid, BaseSubscription>();
					_subscriptions[typeof(TMessage)] = value;
				}
				MvxTrace.Trace("Adding subscription {0} for {1}", subscription.Id, typeof(TMessage).Name);
				value[subscription.Id] = subscription;
				PublishSubscriberChangeMessage<TMessage>(value);
			}
			return new MvxSubscriptionToken(subscription.Id, delegate
			{
				InternalUnsubscribe<TMessage>(subscription.Id);
			}, deliveryAction);
		}

		public void Unsubscribe<TMessage>(MvxSubscriptionToken mvxSubscriptionId) where TMessage : MvxMessage
		{
			InternalUnsubscribe<TMessage>(mvxSubscriptionId.Id);
		}

		private void InternalUnsubscribe<TMessage>(Guid subscriptionGuid) where TMessage : MvxMessage
		{
			lock (this)
			{
				if (_subscriptions.TryGetValue(typeof(TMessage), out var value) && value.ContainsKey(subscriptionGuid))
				{
					MvxTrace.Trace("Removing subscription {0}", subscriptionGuid);
					value.Remove(subscriptionGuid);
				}
				PublishSubscriberChangeMessage<TMessage>(value);
			}
		}

		protected virtual void PublishSubscriberChangeMessage<TMessage>(Dictionary<Guid, BaseSubscription> messageSubscriptions) where TMessage : MvxMessage
		{
			PublishSubscriberChangeMessage(typeof(TMessage), messageSubscriptions);
		}

		protected virtual void PublishSubscriberChangeMessage(Type messageType, Dictionary<Guid, BaseSubscription> messageSubscriptions)
		{
			int countSubscribers = messageSubscriptions?.Count ?? 0;
			Publish(new MvxSubscriberChangeMessage(this, messageType, countSubscribers));
		}

		public bool HasSubscriptionsFor<TMessage>() where TMessage : MvxMessage
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					return false;
				}
				return value.Any();
			}
		}

		public int CountSubscriptionsFor<TMessage>() where TMessage : MvxMessage
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					return 0;
				}
				return value.Count;
			}
		}

		public bool HasSubscriptionsForTag<TMessage>(string tag) where TMessage : MvxMessage
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					return false;
				}
				return value.Any((KeyValuePair<Guid, BaseSubscription> x) => x.Value.Tag == tag);
			}
		}

		public int CountSubscriptionsForTag<TMessage>(string tag) where TMessage : MvxMessage
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					return 0;
				}
				return value.Count((KeyValuePair<Guid, BaseSubscription> x) => x.Value.Tag == tag);
			}
		}

		public IList<string> GetSubscriptionTagsFor<TMessage>() where TMessage : MvxMessage
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(typeof(TMessage), out var value))
				{
					return new List<string>(0);
				}
				return value.Select((KeyValuePair<Guid, BaseSubscription> x) => x.Value.Tag).ToList();
			}
		}

		public void Publish<TMessage>(TMessage message) where TMessage : MvxMessage
		{
			if ((object)typeof(TMessage) == typeof(MvxMessage))
			{
				MvxTrace.Warning("MvxMessage publishing not allowed - this normally suggests non-specific generic used in calling code - switching to message.GetType()");
				Publish(message, message.GetType());
			}
			else
			{
				Publish(message, typeof(TMessage));
			}
		}

		public void Publish(MvxMessage message)
		{
			Publish(message, message.GetType());
		}

		public void Publish(MvxMessage message, Type messageType)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			List<BaseSubscription> list = null;
			lock (this)
			{
				if (_subscriptions.TryGetValue(messageType, out var value))
				{
					list = value.Values.ToList();
				}
			}
			if (list == null || list.Count == 0)
			{
				MvxTrace.Trace("Nothing registered for messages of type {0}", messageType.Name);
				return;
			}
			bool flag = true;
			foreach (BaseSubscription item in list)
			{
				flag &= item.Invoke(message);
			}
			if (!flag)
			{
				MvxTrace.Trace("One or more listeners failed - purge scheduled");
				SchedulePurge(messageType);
			}
		}

		public void RequestPurge(Type messageType)
		{
			SchedulePurge(messageType);
		}

		public void RequestPurgeAll()
		{
			lock (this)
			{
				SchedulePurge(_subscriptions.Keys.ToArray());
			}
		}

		private void SchedulePurge(params Type[] messageTypes)
		{
			lock (this)
			{
				bool flag = _scheduledPurges.Count > 0;
				foreach (Type key in messageTypes)
				{
					_scheduledPurges[key] = true;
				}
				if (!flag)
				{
					Task.Run(delegate
					{
						DoPurge();
					});
				}
			}
		}

		private void DoPurge()
		{
			List<Type> list = null;
			lock (this)
			{
				list = _scheduledPurges.Select((KeyValuePair<Type, bool> x) => x.Key).ToList();
				_scheduledPurges.Clear();
			}
			foreach (Type item in list)
			{
				PurgeMessagesOfType(item);
			}
		}

		private void PurgeMessagesOfType(Type type)
		{
			lock (this)
			{
				if (!_subscriptions.TryGetValue(type, out var value))
				{
					return;
				}
				List<Guid> list = new List<Guid>();
				foreach (KeyValuePair<Guid, BaseSubscription> item in value)
				{
					if (!item.Value.IsAlive)
					{
						list.Add(item.Key);
					}
				}
				MvxTrace.Trace("Purging {0} subscriptions", list.Count);
				foreach (Guid item2 in list)
				{
					value.Remove(item2);
				}
				PublishSubscriberChangeMessage(type, value);
			}
		}
	}
	[Preserve(AllMembers = true)]
	public class PluginLoader : IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		private bool _loaded;

		public void EnsureLoaded()
		{
			if (!_loaded)
			{
				Mvx.RegisterSingleton((IMvxMessenger)new MvxMessengerHub());
				_loaded = true;
			}
		}
	}
	[Preserve(AllMembers = true)]
	public sealed class MvxSubscriptionToken : IDisposable
	{
		private readonly object[] _dependentObjects;

		private readonly Action _disposeMe;

		public Guid Id { get; private set; }

		public MvxSubscriptionToken(Guid id, Action disposeMe, params object[] dependentObjects)
		{
			Id = id;
			_disposeMe = disposeMe;
			_dependentObjects = dependentObjects;
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_disposeMe();
			}
		}
	}
}
namespace MvvmCross.Plugins.Messenger.Subscriptions
{
	public abstract class BaseSubscription
	{
		private readonly IMvxActionRunner _actionRunner;

		public Guid Id { get; private set; }

		public string Tag { get; private set; }

		public abstract bool IsAlive { get; }

		public abstract bool Invoke(object message);

		protected BaseSubscription(IMvxActionRunner actionRunner, string tag)
		{
			_actionRunner = actionRunner;
			Id = Guid.NewGuid();
			Tag = tag;
		}

		protected void Call(Action action)
		{
			_actionRunner.Run(action);
		}
	}
	public abstract class TypedSubscription<TMessage> : BaseSubscription where TMessage : MvxMessage
	{
		protected TypedSubscription(IMvxActionRunner actionRunner, string tag)
			: base(actionRunner, tag)
		{
		}

		public sealed override bool Invoke(object message)
		{
			if (!(message is TMessage message2))
			{
				throw new MvxException("Unexpected message {0}", message);
			}
			return TypedInvoke(message2);
		}

		protected abstract bool TypedInvoke(TMessage message);
	}
	public class StrongSubscription<TMessage> : TypedSubscription<TMessage> where TMessage : MvxMessage
	{
		private readonly Action<TMessage> _action;

		public override bool IsAlive => true;

		protected override bool TypedInvoke(TMessage message)
		{
			Call(delegate
			{
				_action?.Invoke(message);
			});
			return true;
		}

		public StrongSubscription(IMvxActionRunner actionRunner, Action<TMessage> action, string tag)
			: base(actionRunner, tag)
		{
			_action = action;
		}
	}
	public class WeakSubscription<TMessage> : TypedSubscription<TMessage> where TMessage : MvxMessage
	{
		private readonly WeakReference _weakReference;

		public override bool IsAlive => _weakReference.IsAlive;

		protected override bool TypedInvoke(TMessage message)
		{
			if (!_weakReference.IsAlive)
			{
				return false;
			}
			Action<TMessage> action = _weakReference.Target as Action<TMessage>;
			if (action == null)
			{
				return false;
			}
			Call(delegate
			{
				action?.Invoke(message);
			});
			return true;
		}

		public WeakSubscription(IMvxActionRunner actionRunner, Action<TMessage> listener, string tag)
			: base(actionRunner, tag)
		{
			_weakReference = new WeakReference(listener);
		}
	}
}
namespace MvvmCross.Plugins.Messenger.ThreadRunners
{
	public interface IMvxActionRunner
	{
		void Run(Action action);
	}
	public class MvxThreadPoolActionRunner : IMvxActionRunner
	{
		public void Run(Action action)
		{
			Task.Run(action);
		}
	}
	public class MvxMainThreadActionRunner : IMvxActionRunner
	{
		public void Run(Action action)
		{
			IMvxMainThreadDispatcher instance = MvxSingleton<IMvxMainThreadDispatcher>.Instance;
			if (instance == null)
			{
				MvxTrace.Warning("Not able to deliver message - no ui thread dispatcher available");
			}
			else
			{
				instance.RequestMainThreadAction(action);
			}
		}
	}
	public class MvxSimpleActionRunner : IMvxActionRunner
	{
		public void Run(Action action)
		{
			action?.Invoke();
		}
	}
}
