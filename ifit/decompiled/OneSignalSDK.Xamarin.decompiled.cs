using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Com.OneSignal.Android;
using Java.Interop;
using Java.Lang;
using Laters;
using OneSignalSDK.Xamarin.Core;
using Org.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v11.0", FrameworkDisplayName = "Xamarin.Android v11.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace OneSignalSDK.Xamarin;

public class OneSignalImplementation : OneSignalSDKInternal
{
	private class JavaLaterProxy<TResult> : Java.Lang.Object, ILater<TResult>, ILater
	{
		protected Later<TResult> _later = new Later<TResult>();

		public event Action<TResult> OnComplete
		{
			add
			{
				_later.OnComplete += value;
			}
			remove
			{
				_later.OnComplete -= value;
			}
		}

		public TaskAwaiter<TResult> GetAwaiter()
		{
			return _later.GetAwaiter();
		}
	}

	private sealed class OSPermissionObserver : Java.Lang.Object, IOSPermissionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnOSPermissionChanged(OSPermissionStateChanges stateChanges)
		{
			NotificationPermission previous = NativeConversion.PermissionStateToXam(stateChanges.From.AreNotificationsEnabled());
			NotificationPermission current = NativeConversion.PermissionStateToXam(stateChanges.To.AreNotificationsEnabled());
			_instance.NotificationPermissionChanged?.Invoke(current, previous);
		}
	}

	private sealed class OSPushSubscriptionObserver : Java.Lang.Object, IOSSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnOSSubscriptionChanged(OSSubscriptionStateChanges stateChanges)
		{
			PushSubscriptionState previous = NativeConversion.PushSubscriptionStateToXam(stateChanges.From);
			PushSubscriptionState current = NativeConversion.PushSubscriptionStateToXam(stateChanges.To);
			_instance.PushSubscriptionStateChanged?.Invoke(current, previous);
		}
	}

	private sealed class OSEmailSubscriptionObserver : Java.Lang.Object, IOSEmailSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnOSEmailSubscriptionChanged(OSEmailSubscriptionStateChanges stateChanges)
		{
			EmailSubscriptionState previous = NativeConversion.EmailSubscriptionStateToXam(stateChanges.From);
			EmailSubscriptionState current = NativeConversion.EmailSubscriptionStateToXam(stateChanges.To);
			_instance.EmailSubscriptionStateChanged?.Invoke(current, previous);
		}
	}

	private sealed class OSSMSSubscriptionObserver : Java.Lang.Object, IOSSMSSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSMSSubscriptionChanged(OSSMSSubscriptionStateChanges stateChanges)
		{
			SMSSubscriptionState previous = NativeConversion.SMSSubscriptionStateToXam(stateChanges.From);
			SMSSubscriptionState current = NativeConversion.SMSSubscriptionStateToXam(stateChanges.To);
			_instance.SMSSubscriptionStateChanged?.Invoke(current, previous);
		}
	}

	private sealed class OSNotificationWillShowInForegroundHandler : Java.Lang.Object, Com.OneSignal.Android.OneSignal.IOSNotificationWillShowInForegroundHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void NotificationWillShowInForeground(OSNotificationReceivedEvent notificationReceivedEvent)
		{
			OSNotification notification = notificationReceivedEvent.Notification;
			if (_instance.NotificationWillShow == null)
			{
				notificationReceivedEvent.Complete(notification);
				return;
			}
			OneSignalSDK.Xamarin.Core.Notification notification2 = NativeConversion.NotificationToXam(notificationReceivedEvent.Notification);
			OneSignalSDK.Xamarin.Core.Notification notification3 = _instance.NotificationWillShow(notification2);
			notificationReceivedEvent.Complete((notification3 != null) ? notification : null);
		}
	}

	private sealed class OSNotificationOpenedHandler : Java.Lang.Object, Com.OneSignal.Android.OneSignal.IOSNotificationOpenedHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void NotificationOpened(OSNotificationOpenedResult notificationOpenedResult)
		{
			NotificationOpenedResult result = NativeConversion.NotificationOpenedResultToXam(notificationOpenedResult);
			_instance.NotificationOpened?.Invoke(result);
		}
	}

	private sealed class OSInAppMessageClickHandler : Java.Lang.Object, Com.OneSignal.Android.OneSignal.IOSInAppMessageClickHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void InAppMessageClicked(OSInAppMessageAction inAppMessageAction)
		{
			InAppMessageAction action = NativeConversion.InAppMessageClickedActionToXam(inAppMessageAction);
			_instance.InAppMessageTriggeredAction?.Invoke(action);
		}
	}

	private sealed class OSInAppMessageLifeCycleHandler : OSInAppMessageLifecycleHandler
	{
		public override void OnWillDisplayInAppMessage(OSInAppMessage message)
		{
			_instance.InAppMessageWillDisplay?.Invoke(NativeConversion.InAppMessageToXam(message));
		}

		public override void OnDidDisplayInAppMessage(OSInAppMessage message)
		{
			_instance.InAppMessageDidDisplay?.Invoke(NativeConversion.InAppMessageToXam(message));
		}

		public override void OnWillDismissInAppMessage(OSInAppMessage message)
		{
			_instance.InAppMessageWillDismiss?.Invoke(NativeConversion.InAppMessageToXam(message));
		}

		public override void OnDidDismissInAppMessage(OSInAppMessage message)
		{
			_instance.InAppMessageDidDismiss?.Invoke(NativeConversion.InAppMessageToXam(message));
		}
	}

	private sealed class OSSMSUpdateHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IOSSMSUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(JSONObject jsonResults)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.OSSMSUpdateError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSEmailUpdateHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IEmailUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess()
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.EmailUpdateError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSGetTagsHandler : JavaLaterProxy<Dictionary<string, object>>, Com.OneSignal.Android.OneSignal.IOSGetTagsHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void TagsAvailable(JSONObject tags)
		{
			Dictionary<string, object> result = Json.Deserialize(tags.ToString()) as Dictionary<string, object>;
			_later.Complete(result);
		}
	}

	private sealed class OSExternalUserIDUpdateHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IOSExternalUserIdUpdateCompletionHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(JSONObject jsonResults)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.ExternalIdError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSLanguageUpdateHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IOSSetLanguageCompletionHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(string results)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.OSLanguageError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSPromptForPushNotificationPermissionResponseHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IPromptForPushNotificationPermissionResponseHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void Response(bool accepted)
		{
			_later.Complete(accepted);
		}
	}

	private sealed class OSChangeTagsUpdateHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IChangeTagsUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(JSONObject jsonResults)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.SendTagsError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSOutcomeCallback : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IOutcomeCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(OSOutcomeEvent outcome)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(Com.OneSignal.Android.OneSignal.SendTagsError error)
		{
			_later.Complete(result: false);
		}
	}

	private sealed class OSPostNotificationResponseHandler : JavaLaterProxy<bool>, Com.OneSignal.Android.OneSignal.IPostNotificationResponseHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		public void OnSuccess(JSONObject jsonResults)
		{
			_later.Complete(result: true);
		}

		public void OnFailure(JSONObject error)
		{
			_later.Complete(result: false);
		}
	}

	public LogLevel currentLogLevel;

	public LogLevel currentAlertLevel;

	private static OneSignalImplementation _instance;

	public override bool PrivacyConsent
	{
		get
		{
			return Com.OneSignal.Android.OneSignal.UserProvidedPrivacyConsent();
		}
		set
		{
			Com.OneSignal.Android.OneSignal.ProvideUserConsent(value);
		}
	}

	public override bool RequiresPrivacyConsent
	{
		get
		{
			return Com.OneSignal.Android.OneSignal.RequiresUserPrivacyConsent();
		}
		set
		{
			Com.OneSignal.Android.OneSignal.SetRequiresUserPrivacyConsent(value);
		}
	}

	public override LogLevel LogLevel
	{
		get
		{
			return currentLogLevel;
		}
		set
		{
			currentLogLevel = value;
			Com.OneSignal.Android.OneSignal.SetLogLevel(NativeConversion.LogConversion(currentLogLevel), NativeConversion.LogConversion(currentAlertLevel));
		}
	}

	public override LogLevel AlertLevel
	{
		get
		{
			return currentAlertLevel;
		}
		set
		{
			currentAlertLevel = value;
			Com.OneSignal.Android.OneSignal.SetLogLevel(NativeConversion.LogConversion(currentLogLevel), NativeConversion.LogConversion(currentAlertLevel));
		}
	}

	public override DeviceState DeviceState => NativeConversion.DeviceStateToXam(Com.OneSignal.Android.OneSignal.DeviceState);

	public override NotificationPermission NotificationPermission => DeviceState.notificationPermission;

	public override PushSubscriptionState PushSubscriptionState => new PushSubscriptionState
	{
		userId = DeviceState.userId,
		pushToken = DeviceState.pushToken,
		isSubscribed = DeviceState.isSubscribed,
		isPushDisabled = DeviceState.isPushDisabled
	};

	public override EmailSubscriptionState EmailSubscriptionState => new EmailSubscriptionState
	{
		emailUserId = DeviceState.emailUserId,
		emailAddress = DeviceState.emailAddress,
		isSubscribed = DeviceState.isEmailSubscribed
	};

	public override SMSSubscriptionState SMSSubscriptionState => new SMSSubscriptionState
	{
		smsUserId = DeviceState.smsUserId,
		smsNumber = DeviceState.smsNumber,
		isSubscribed = DeviceState.isSMSSubscribed
	};

	public override bool ShareLocation
	{
		get
		{
			return Com.OneSignal.Android.OneSignal.LocationShared;
		}
		set
		{
			Com.OneSignal.Android.OneSignal.LocationShared = value;
		}
	}

	public override bool PushEnabled
	{
		get
		{
			return !DeviceState.isPushDisabled;
		}
		set
		{
			Com.OneSignal.Android.OneSignal.DisablePush(!value);
		}
	}

	public override bool InAppMessagesArePaused
	{
		get
		{
			return Com.OneSignal.Android.OneSignal.IsInAppMessagingPaused;
		}
		set
		{
			Com.OneSignal.Android.OneSignal.PauseInAppMessages(value);
		}
	}

	public override event NotificationWillShowDelegate NotificationWillShow;

	public override event NotificationActionDelegate NotificationOpened;

	public override event InAppMessageLifecycleDelegate InAppMessageWillDisplay;

	public override event InAppMessageLifecycleDelegate InAppMessageDidDisplay;

	public override event InAppMessageLifecycleDelegate InAppMessageWillDismiss;

	public override event InAppMessageLifecycleDelegate InAppMessageDidDismiss;

	public override event InAppMessageActionDelegate InAppMessageTriggeredAction;

	public override event StateChangeDelegate<NotificationPermission> NotificationPermissionChanged;

	public override event StateChangeDelegate<PushSubscriptionState> PushSubscriptionStateChanged;

	public override event StateChangeDelegate<EmailSubscriptionState> EmailSubscriptionStateChanged;

	public override event StateChangeDelegate<SMSSubscriptionState> SMSSubscriptionStateChanged;

	public override void Initialize(string appId)
	{
		Context context = Application.Context;
		Com.OneSignal.Android.OneSignal.SetAppId(appId);
		Com.OneSignal.Android.OneSignal.InitWithContext(context);
		Com.OneSignal.Android.OneSignal.AddPermissionObserver(new OSPermissionObserver());
		Com.OneSignal.Android.OneSignal.AddSubscriptionObserver(new OSPushSubscriptionObserver());
		Com.OneSignal.Android.OneSignal.AddEmailSubscriptionObserver(new OSEmailSubscriptionObserver());
		Com.OneSignal.Android.OneSignal.AddSMSSubscriptionObserver(new OSSMSSubscriptionObserver());
		Com.OneSignal.Android.OneSignal.SetNotificationWillShowInForegroundHandler(new OSNotificationWillShowInForegroundHandler());
		Com.OneSignal.Android.OneSignal.SetNotificationOpenedHandler(new OSNotificationOpenedHandler());
		Com.OneSignal.Android.OneSignal.SetInAppMessageClickHandler(new OSInAppMessageClickHandler());
		Com.OneSignal.Android.OneSignal.SetInAppMessageLifecycleHandler(new OSInAppMessageLifeCycleHandler());
	}

	public override async Task<NotificationPermission> PromptForPushNotificationsWithUserResponse()
	{
		return await PromptForPushNotificationsWithUserResponse(fallbackToSettings: false);
	}

	public override async Task<NotificationPermission> PromptForPushNotificationsWithUserResponse(bool fallbackToSettings)
	{
		OSPromptForPushNotificationPermissionResponseHandler oSPromptForPushNotificationPermissionResponseHandler = new OSPromptForPushNotificationPermissionResponseHandler();
		Com.OneSignal.Android.OneSignal.PromptForPushNotifications(fallbackToSettings, oSPromptForPushNotificationPermissionResponseHandler);
		return (!(await oSPromptForPushNotificationPermissionResponseHandler)) ? NotificationPermission.Denied : NotificationPermission.Authorized;
	}

	public override async Task<bool> SetSMSNumber(string smsNumber, string authHash = null)
	{
		OSSMSUpdateHandler oSSMSUpdateHandler = new OSSMSUpdateHandler();
		Com.OneSignal.Android.OneSignal.SetSMSNumber(smsNumber, authHash, oSSMSUpdateHandler);
		return await oSSMSUpdateHandler;
	}

	public override async Task<bool> SetEmail(string email, string authHash = null)
	{
		OSEmailUpdateHandler oSEmailUpdateHandler = new OSEmailUpdateHandler();
		Com.OneSignal.Android.OneSignal.SetEmail(email, authHash, oSEmailUpdateHandler);
		return await oSEmailUpdateHandler;
	}

	public override async Task<bool> SetExternalUserId(string externalId)
	{
		OSExternalUserIDUpdateHandler oSExternalUserIDUpdateHandler = new OSExternalUserIDUpdateHandler();
		Com.OneSignal.Android.OneSignal.SetExternalUserId(externalId, oSExternalUserIDUpdateHandler);
		return await oSExternalUserIDUpdateHandler;
	}

	public override async Task<bool> SetExternalUserId(string externalId, string authHash = null)
	{
		OSExternalUserIDUpdateHandler oSExternalUserIDUpdateHandler = new OSExternalUserIDUpdateHandler();
		Com.OneSignal.Android.OneSignal.SetExternalUserId(externalId, authHash, oSExternalUserIDUpdateHandler);
		return await oSExternalUserIDUpdateHandler;
	}

	public override async Task<bool> RemoveExternalUserId()
	{
		OSExternalUserIDUpdateHandler oSExternalUserIDUpdateHandler = new OSExternalUserIDUpdateHandler();
		Com.OneSignal.Android.OneSignal.RemoveExternalUserId(oSExternalUserIDUpdateHandler);
		return await oSExternalUserIDUpdateHandler;
	}

	public override async Task<bool> LogoutEmail()
	{
		OSEmailUpdateHandler oSEmailUpdateHandler = new OSEmailUpdateHandler();
		Com.OneSignal.Android.OneSignal.LogoutEmail(oSEmailUpdateHandler);
		return await oSEmailUpdateHandler;
	}

	public override async Task<bool> LogoutSMS()
	{
		OSSMSUpdateHandler oSSMSUpdateHandler = new OSSMSUpdateHandler();
		Com.OneSignal.Android.OneSignal.LogoutSMSNumber(oSSMSUpdateHandler);
		return await oSSMSUpdateHandler;
	}

	public override void SetLaunchURLsInApp(bool launchInApp)
	{
		Console.WriteLine("OneSignal: SetLaunchURLsInApp is available on iOS only");
	}

	public override async Task<bool> SetLanguage(string language)
	{
		OSLanguageUpdateHandler oSLanguageUpdateHandler = new OSLanguageUpdateHandler();
		Com.OneSignal.Android.OneSignal.SetLanguage(language, oSLanguageUpdateHandler);
		return await oSLanguageUpdateHandler;
	}

	public override async Task<bool> SendTag(string key, string value)
	{
		Com.OneSignal.Android.OneSignal.SendTag(key, value);
		return true;
	}

	public override async Task<bool> SendTags(Dictionary<string, object> tags)
	{
		OSChangeTagsUpdateHandler oSChangeTagsUpdateHandler = new OSChangeTagsUpdateHandler();
		Com.OneSignal.Android.OneSignal.SendTags((JSONObject)(Java.Lang.Object)Json.Serialize(tags), oSChangeTagsUpdateHandler);
		return await oSChangeTagsUpdateHandler;
	}

	public override async Task<Dictionary<string, object>> GetTags()
	{
		OSGetTagsHandler oSGetTagsHandler = new OSGetTagsHandler();
		Com.OneSignal.Android.OneSignal.GetTags(oSGetTagsHandler);
		return await oSGetTagsHandler;
	}

	public override async Task<bool> DeleteTag(string key)
	{
		OSChangeTagsUpdateHandler oSChangeTagsUpdateHandler = new OSChangeTagsUpdateHandler();
		Com.OneSignal.Android.OneSignal.DeleteTag(key, oSChangeTagsUpdateHandler);
		return await oSChangeTagsUpdateHandler;
	}

	public override async Task<bool> DeleteTags(params string[] keys)
	{
		OSChangeTagsUpdateHandler oSChangeTagsUpdateHandler = new OSChangeTagsUpdateHandler();
		Com.OneSignal.Android.OneSignal.DeleteTags(Json.Serialize(keys), oSChangeTagsUpdateHandler);
		return await oSChangeTagsUpdateHandler;
	}

	public override async Task<bool> PostNotification(Dictionary<string, object> options)
	{
		OSPostNotificationResponseHandler oSPostNotificationResponseHandler = new OSPostNotificationResponseHandler();
		Com.OneSignal.Android.OneSignal.PostNotification(Json.Serialize(options), oSPostNotificationResponseHandler);
		return await oSPostNotificationResponseHandler;
	}

	public override void PromptLocation()
	{
		Com.OneSignal.Android.OneSignal.PromptLocation();
	}

	public override void ClearOneSignalNotifications()
	{
		Com.OneSignal.Android.OneSignal.ClearOneSignalNotifications();
	}

	public override void SetTriggers(Dictionary<string, object> triggers)
	{
		IDictionary<string, Java.Lang.Object> dictionary = new Dictionary<string, Java.Lang.Object>();
		foreach (KeyValuePair<string, object> trigger in triggers)
		{
			dictionary[trigger.Key] = trigger.Value.ToJavaObject();
		}
		Com.OneSignal.Android.OneSignal.AddTriggers(dictionary);
	}

	public override void SetTrigger(string key, object triggerObject)
	{
		Com.OneSignal.Android.OneSignal.AddTrigger(key, triggerObject.ToJavaObject());
	}

	public override void RemoveTriggers(params string[] keys)
	{
		Com.OneSignal.Android.OneSignal.RemoveTriggersForKeys(keys);
	}

	public override void RemoveTrigger(string key)
	{
		Com.OneSignal.Android.OneSignal.RemoveTriggerForKey(key);
	}

	public override object GetTrigger(string key)
	{
		return Com.OneSignal.Android.OneSignal.GetTriggerValueForKey(key);
	}

	public override Dictionary<string, object> GetTriggers()
	{
		IDictionary<string, Java.Lang.Object> triggers = Com.OneSignal.Android.OneSignal.Triggers;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<string, Java.Lang.Object> item in triggers)
		{
			dictionary[item.Key] = item.Value;
		}
		return dictionary;
	}

	public override async Task<bool> SendOutcome(string name)
	{
		OSOutcomeCallback oSOutcomeCallback = new OSOutcomeCallback();
		Com.OneSignal.Android.OneSignal.SendOutcome(name, oSOutcomeCallback);
		return await oSOutcomeCallback;
	}

	public override async Task<bool> SendUniqueOutcome(string name)
	{
		OSOutcomeCallback oSOutcomeCallback = new OSOutcomeCallback();
		Com.OneSignal.Android.OneSignal.SendUniqueOutcome(name, oSOutcomeCallback);
		return await oSOutcomeCallback;
	}

	public override async Task<bool> SendOutcomeWithValue(string name, float value)
	{
		OSOutcomeCallback oSOutcomeCallback = new OSOutcomeCallback();
		Com.OneSignal.Android.OneSignal.SendOutcomeWithValue(name, value, oSOutcomeCallback);
		return await oSOutcomeCallback;
	}

	public OneSignalImplementation()
	{
		_ = _instance;
		_instance = this;
	}
}
public class OneSignal
{
	private static readonly Lazy<OneSignalSDKInternal> Implementation = new Lazy<OneSignalSDKInternal>(CreateOneSignal);

	public static OneSignalSDKInternal Default
	{
		get
		{
			if (Implementation.Value == null)
			{
				throw NotImplementedInReferenceAssembly();
			}
			return Implementation.Value;
		}
	}

	private static OneSignalSDKInternal CreateOneSignal()
	{
		return new OneSignalImplementation();
	}

	internal static System.Exception NotImplementedInReferenceAssembly()
	{
		return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
	}
}
public static class NativeConversion
{
	public class JavaHolder : Java.Lang.Object
	{
		public readonly object Instance;

		public JavaHolder(object instance)
		{
			Instance = instance;
		}
	}

	public static OneSignalSDK.Xamarin.Core.Notification NotificationToXam(OSNotification notification)
	{
		OneSignalSDK.Xamarin.Core.Notification notification2 = new OneSignalSDK.Xamarin.Core.Notification
		{
			androidNotificationId = notification.AndroidNotificationId,
			notificationId = notification.NotificationId,
			title = notification.Title,
			body = notification.Body,
			smallIcon = notification.SmallIcon,
			largeIcon = notification.LargeIcon,
			bigPicture = notification.BigPicture,
			smallIconAccentColor = notification.SmallIconAccentColor,
			launchUrl = notification.LaunchURL,
			sound = notification.Sound,
			ledColor = notification.LedColor,
			lockScreenVisibility = notification.LockScreenVisibility,
			fromProjectNumber = notification.FromProjectNumber,
			groupKey = notification.GroupKey,
			groupMessage = notification.GroupMessage,
			CollapseId = notification.CollapseId,
			priority = notification.Priority,
			rawPayload = notification.RawPayload
		};
		if (notification.AdditionalData != null)
		{
			notification2.additionalData = Json.Deserialize(notification.AdditionalData.ToString()) as Dictionary<string, object>;
		}
		if (notification.GroupedNotifications != null)
		{
			foreach (OSNotification groupedNotification in notification.GroupedNotifications)
			{
				notification2.groupedNotifications.Add(NotificationToXam(groupedNotification));
			}
		}
		if (notification.ActionButtons != null)
		{
			notification2.actionButtons = new List<ActionButton>();
			foreach (OSNotification.ActionButton actionButton in notification.ActionButtons)
			{
				notification2.actionButtons.Add(new ActionButton(actionButton.Id, actionButton.Text, actionButton.Icon));
			}
		}
		if (notification.GetBackgroundImageLayout() != null)
		{
			notification2.backgroundImageLayout = new BackgroundImageLayout(notification.GetBackgroundImageLayout().Image, notification.GetBackgroundImageLayout().TitleTextColor, notification.GetBackgroundImageLayout().BodyTextColor);
		}
		return notification2;
	}

	public static InAppMessage InAppMessageToXam(OSInAppMessage inAppMessage)
	{
		return new InAppMessage
		{
			messageId = inAppMessage.MessageId
		};
	}

	public static InAppMessageAction InAppMessageClickedActionToXam(OSInAppMessageAction action)
	{
		InAppMessageAction result = new InAppMessageAction
		{
			clickName = action.ClickName,
			clickUrl = action.ClickUrl,
			firstClick = action.IsFirstClick,
			closesMessage = action.DoesCloseMessage()
		};
		IList<InAppMessageOutcome> list = new List<InAppMessageOutcome>();
		foreach (OSInAppMessageOutcome outcome in action.Outcomes)
		{
			list.Add(InAppMessageOutcomeToXam(outcome));
		}
		return result;
	}

	public static NotificationOpenedResult NotificationOpenedResultToXam(OSNotificationOpenedResult result)
	{
		return new NotificationOpenedResult
		{
			notification = NotificationToXam(result.Notification),
			action = NotificationActionToXam(result.Action)
		};
	}

	public static NotificationAction NotificationActionToXam(OSNotificationAction notificationAction)
	{
		return new NotificationAction
		{
			actionID = notificationAction.ActionId,
			type = (NotificationActionType)notificationAction.Type.Ordinal()
		};
	}

	public static InAppMessageOutcome InAppMessageOutcomeToXam(OSInAppMessageOutcome outcome)
	{
		return new InAppMessageOutcome
		{
			name = outcome.Name,
			weight = outcome.Weight,
			unique = outcome.Unique
		};
	}

	public static DeviceState DeviceStateToXam(OSDeviceState deviceState)
	{
		return new DeviceState
		{
			notificationPermission = PermissionStateToXam(deviceState.AreNotificationsEnabled()),
			areNotificationsEnabled = deviceState.AreNotificationsEnabled(),
			isSubscribed = deviceState.IsSubscribed,
			userId = deviceState.UserId,
			pushToken = deviceState.PushToken,
			isPushDisabled = deviceState.IsPushDisabled,
			isEmailSubscribed = deviceState.IsEmailSubscribed,
			emailUserId = deviceState.EmailUserId,
			emailAddress = deviceState.EmailAddress,
			isSMSSubscribed = deviceState.IsSMSSubscribed,
			smsNumber = deviceState.SMSNumber,
			smsUserId = deviceState.SMSUserId
		};
	}

	public static NotificationPermission PermissionStateToXam(bool areNotificationsEnabled)
	{
		if (!areNotificationsEnabled)
		{
			return NotificationPermission.Denied;
		}
		return NotificationPermission.Authorized;
	}

	public static PushSubscriptionState PushSubscriptionStateToXam(OSSubscriptionState androidSubscriptionState)
	{
		return new PushSubscriptionState
		{
			isPushDisabled = androidSubscriptionState.IsPushDisabled,
			pushToken = androidSubscriptionState.PushToken,
			isSubscribed = androidSubscriptionState.IsSubscribed,
			userId = androidSubscriptionState.UserId
		};
	}

	public static EmailSubscriptionState EmailSubscriptionStateToXam(OSEmailSubscriptionState androidEmailSubscriptionState)
	{
		return new EmailSubscriptionState
		{
			emailAddress = androidEmailSubscriptionState.EmailAddress,
			emailUserId = androidEmailSubscriptionState.EmailUserId,
			isSubscribed = androidEmailSubscriptionState.IsSubscribed
		};
	}

	public static SMSSubscriptionState SMSSubscriptionStateToXam(OSSMSSubscriptionState androidSMSSubscriptionState)
	{
		return new SMSSubscriptionState
		{
			smsNumber = androidSMSSubscriptionState.SMSNumber,
			smsUserId = androidSMSSubscriptionState.SMSNumber,
			isSubscribed = androidSMSSubscriptionState.IsSubscribed
		};
	}

	public static Com.OneSignal.Android.OneSignal.LOG_LEVEL LogConversion(LogLevel logLevel)
	{
		return logLevel switch
		{
			LogLevel.NONE => Com.OneSignal.Android.OneSignal.LOG_LEVEL.None, 
			LogLevel.FATAL => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Fatal, 
			LogLevel.ERROR => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Error, 
			LogLevel.WARN => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Warn, 
			LogLevel.INFO => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Info, 
			LogLevel.DEBUG => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Debug, 
			LogLevel.VERBOSE => Com.OneSignal.Android.OneSignal.LOG_LEVEL.Debug, 
			_ => Com.OneSignal.Android.OneSignal.LOG_LEVEL.None, 
		};
	}

	public static Java.Lang.Object ToJavaObject<TObject>(this TObject value)
	{
		if (object.Equals(value, default(TObject)) && !typeof(TObject).IsValueType)
		{
			return null;
		}
		return new JavaHolder(value);
	}
}
