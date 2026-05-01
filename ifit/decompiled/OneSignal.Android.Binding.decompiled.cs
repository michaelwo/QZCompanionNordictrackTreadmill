using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.Database.Sqlite;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using Com.OneSignal.Android;
using Com.Onesignal.Influence.Data;
using Com.Onesignal.Influence.Domain;
using Com.Onesignal.Outcomes.Domain;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Javax.Net.Ssl;
using Org.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.onesignal", Managed = "Com.OneSignal.Android")]
[assembly: NamespaceMapping(Java = "com.onesignal.influence.data", Managed = "Com.Onesignal.Influence.Data")]
[assembly: NamespaceMapping(Java = "com.onesignal.influence.domain", Managed = "Com.Onesignal.Influence.Domain")]
[assembly: NamespaceMapping(Java = "com.onesignal.language", Managed = "Com.Onesignal.Language")]
[assembly: NamespaceMapping(Java = "com.onesignal.outcomes.data", Managed = "Com.Onesignal.Outcomes.Data")]
[assembly: NamespaceMapping(Java = "com.onesignal.outcomes.domain", Managed = "Com.Onesignal.Outcomes.Domain")]
[assembly: NamespaceMapping(Java = "com.onesignal.shortcutbadger", Managed = "Com.Onesignal.Shortcutbadger")]
[assembly: NamespaceMapping(Java = "com.onesignal.shortcutbadger.impl", Managed = "Com.Onesignal.Shortcutbadger.Impl")]
[assembly: NamespaceMapping(Java = "com.onesignal.shortcutbadger.util", Managed = "Com.Onesignal.Shortcutbadger.Util")]
[assembly: TargetFramework("MonoAndroid,Version=v11.0", FrameworkDisplayName = "Xamarin.Android v11.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPIIIIIIIIZ_Z(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, bool p8);
internal delegate void _JniMarshal_PPILL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate int _JniMarshal_PPLII_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLILI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, int p3);
internal delegate void _JniMarshal_PPLILL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate int _JniMarshal_PPLLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate IntPtr _JniMarshal_PPLLIZ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, bool p3);
internal delegate long _JniMarshal_PPLLJ_J(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, long p2);
internal delegate void _JniMarshal_PPLLJ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, long p2);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate int _JniMarshal_PPLLLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLLLLLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5, IntPtr p6);
internal delegate IntPtr _JniMarshal_PPLLLLLLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5, IntPtr p6, IntPtr p7);
internal delegate void _JniMarshal_PPLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
internal delegate bool _JniMarshal_PPLLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
internal delegate bool _JniMarshal_PPLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace System.Runtime.Versioning
{
	[Conditional("NEVER")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
	internal sealed class SupportedOSPlatformAttribute : Attribute
	{
		public SupportedOSPlatformAttribute(string platformName)
		{
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_onesignal_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/onesignal" }, new Converter<string, Type>[1] { lookup_com_onesignal_package });
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_com_onesignal_package(string klass)
		{
			if (package_com_onesignal_mappings == null)
			{
				package_com_onesignal_mappings = new string[77]
				{
					"com/onesignal/AlertDialogPrepromptForAndroidSettings:Com.OneSignal.Android.AlertDialogPrepromptForAndroidSettings", "com/onesignal/BootUpReceiver:Com.OneSignal.Android.BootUpReceiver", "com/onesignal/BuildConfig:Com.OneSignal.Android.BuildConfig", "com/onesignal/FCMIntentJobService:Com.OneSignal.Android.FCMIntentJobService", "com/onesignal/GenerateNotificationOpenIntent:Com.OneSignal.Android.GenerateNotificationOpenIntent", "com/onesignal/GenerateNotificationOpenIntentFromPushPayload:Com.OneSignal.Android.GenerateNotificationOpenIntentFromPushPayload", "com/onesignal/IntentGeneratorForAttachingToNotifications:Com.OneSignal.Android.IntentGeneratorForAttachingToNotifications", "com/onesignal/LocationPermissionController:Com.OneSignal.Android.LocationPermissionController", "com/onesignal/NavigateToAndroidSettingsForLocation:Com.OneSignal.Android.NavigateToAndroidSettingsForLocation", "com/onesignal/NavigateToAndroidSettingsForNotifications:Com.OneSignal.Android.NavigateToAndroidSettingsForNotifications",
					"com/onesignal/NotificationDismissReceiver:Com.OneSignal.Android.NotificationDismissReceiver", "com/onesignal/NotificationOpenedActivityHMS:Com.OneSignal.Android.NotificationOpenedActivityHMS", "com/onesignal/NotificationOpenedReceiver:Com.OneSignal.Android.NotificationOpenedReceiver", "com/onesignal/NotificationOpenedReceiverAndroid22AndOlder:Com.OneSignal.Android.NotificationOpenedReceiverAndroid22AndOlder", "com/onesignal/NotificationOpenedReceiverBase:Com.OneSignal.Android.NotificationOpenedReceiverBase", "com/onesignal/NotificationPermissionController:Com.OneSignal.Android.NotificationPermissionController", "com/onesignal/OSBackgroundManager:Com.OneSignal.Android.OSBackgroundManager", "com/onesignal/OSDeviceState:Com.OneSignal.Android.OSDeviceState", "com/onesignal/OSEmailSubscriptionState:Com.OneSignal.Android.OSEmailSubscriptionState", "com/onesignal/OSEmailSubscriptionStateChanges:Com.OneSignal.Android.OSEmailSubscriptionStateChanges",
					"com/onesignal/OSFocusHandler:Com.OneSignal.Android.OSFocusHandler", "com/onesignal/OSFocusHandler$Companion:Com.OneSignal.Android.OSFocusHandler/Companion", "com/onesignal/OSInAppMessage:Com.OneSignal.Android.OSInAppMessage", "com/onesignal/OSInAppMessageAction:Com.OneSignal.Android.OSInAppMessageAction", "com/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType:Com.OneSignal.Android.OSInAppMessageAction/OSInAppMessageActionUrlType", "com/onesignal/OSInAppMessageContentKt:Com.OneSignal.Android.OSInAppMessageContentKt", "com/onesignal/OSInAppMessageLifecycleHandler:Com.OneSignal.Android.OSInAppMessageLifecycleHandler", "com/onesignal/OSInAppMessageOutcome:Com.OneSignal.Android.OSInAppMessageOutcome", "com/onesignal/OSInAppMessagePageKt:Com.OneSignal.Android.OSInAppMessagePageKt", "com/onesignal/OSInAppMessagePrompt:Com.OneSignal.Android.OSInAppMessagePrompt",
					"com/onesignal/OSInAppMessagePushPrompt:Com.OneSignal.Android.OSInAppMessagePushPrompt", "com/onesignal/OSInAppMessageTag:Com.OneSignal.Android.OSInAppMessageTag", "com/onesignal/OSMutableNotification:Com.OneSignal.Android.OSMutableNotification", "com/onesignal/OSNotification:Com.OneSignal.Android.OSNotification", "com/onesignal/OSNotification$ActionButton:Com.OneSignal.Android.OSNotification/ActionButton", "com/onesignal/OSNotification$BackgroundImageLayout:Com.OneSignal.Android.OSNotification/BackgroundImageLayout", "com/onesignal/OSNotification$OSNotificationBuilder:Com.OneSignal.Android.OSNotification/OSNotificationBuilder", "com/onesignal/OSNotificationAction:Com.OneSignal.Android.OSNotificationAction", "com/onesignal/OSNotificationAction$ActionType:Com.OneSignal.Android.OSNotificationAction/ActionType", "com/onesignal/OSNotificationController:Com.OneSignal.Android.OSNotificationController",
					"com/onesignal/OSNotificationGenerationJob:Com.OneSignal.Android.OSNotificationGenerationJob", "com/onesignal/OSNotificationIntentExtras:Com.OneSignal.Android.OSNotificationIntentExtras", "com/onesignal/OSNotificationOpenAppSettings:Com.OneSignal.Android.OSNotificationOpenAppSettings", "com/onesignal/OSNotificationOpenBehaviorFromPushPayload:Com.OneSignal.Android.OSNotificationOpenBehaviorFromPushPayload", "com/onesignal/OSNotificationOpenedResult:Com.OneSignal.Android.OSNotificationOpenedResult", "com/onesignal/OSNotificationReceivedEvent:Com.OneSignal.Android.OSNotificationReceivedEvent", "com/onesignal/OSOutcomeEvent:Com.OneSignal.Android.OSOutcomeEvent", "com/onesignal/OSPermissionState:Com.OneSignal.Android.OSPermissionState", "com/onesignal/OSPermissionStateChanges:Com.OneSignal.Android.OSPermissionStateChanges", "com/onesignal/OSSMSSubscriptionState:Com.OneSignal.Android.OSSMSSubscriptionState",
					"com/onesignal/OSSMSSubscriptionStateChanges:Com.OneSignal.Android.OSSMSSubscriptionStateChanges", "com/onesignal/OSSessionManager:Com.OneSignal.Android.OSSessionManager", "com/onesignal/OSSubscriptionState:Com.OneSignal.Android.OSSubscriptionState", "com/onesignal/OSSubscriptionStateChanges:Com.OneSignal.Android.OSSubscriptionStateChanges", "com/onesignal/OSTimeImpl:Com.OneSignal.Android.OSTimeImpl", "com/onesignal/OSWebView:Com.OneSignal.Android.OSWebView", "com/onesignal/OneSignal:Com.OneSignal.Android.OneSignal", "com/onesignal/OneSignal$AppEntryAction:Com.OneSignal.Android.OneSignal/AppEntryAction", "com/onesignal/OneSignal$EmailErrorType:Com.OneSignal.Android.OneSignal/EmailErrorType", "com/onesignal/OneSignal$EmailUpdateError:Com.OneSignal.Android.OneSignal/EmailUpdateError",
					"com/onesignal/OneSignal$ExternalIdError:Com.OneSignal.Android.OneSignal/ExternalIdError", "com/onesignal/OneSignal$ExternalIdErrorType:Com.OneSignal.Android.OneSignal/ExternalIdErrorType", "com/onesignal/OneSignal$LOG_LEVEL:Com.OneSignal.Android.OneSignal/LOG_LEVEL", "com/onesignal/OneSignal$OSLanguageError:Com.OneSignal.Android.OneSignal/OSLanguageError", "com/onesignal/OneSignal$OSSMSUpdateError:Com.OneSignal.Android.OneSignal/OSSMSUpdateError", "com/onesignal/OneSignal$SMSErrorType:Com.OneSignal.Android.OneSignal/SMSErrorType", "com/onesignal/OneSignal$SendTagsError:Com.OneSignal.Android.OneSignal/SendTagsError", "com/onesignal/OneSignalHmsEventBridge:Com.OneSignal.Android.OneSignalHmsEventBridge", "com/onesignal/OneSignalNotificationManager:Com.OneSignal.Android.OneSignalNotificationManager", "com/onesignal/OneSignalRemoteParams:Com.OneSignal.Android.OneSignalRemoteParams",
					"com/onesignal/OneSignalRemoteParams$InfluenceParams:Com.OneSignal.Android.OneSignalRemoteParams/InfluenceParams", "com/onesignal/PermissionsActivity:Com.OneSignal.Android.PermissionsActivity", "com/onesignal/PushRegistratorADM:Com.OneSignal.Android.PushRegistratorADM", "com/onesignal/SyncJobService:Com.OneSignal.Android.SyncJobService", "com/onesignal/SyncService:Com.OneSignal.Android.SyncService", "com/onesignal/TLS12SocketFactory:Com.OneSignal.Android.TLS12SocketFactory", "com/onesignal/UpgradeReceiver:Com.OneSignal.Android.UpgradeReceiver"
				};
			}
			return Lookup(package_com_onesignal_mappings, klass);
		}
	}
}
namespace Com.Onesignal.Shortcutbadger
{
	[Register("com/onesignal/shortcutbadger/Badger", "", "Com.Onesignal.Shortcutbadger.IBadgerInvoker")]
	public interface IBadger : IJavaObject, IDisposable, IJavaPeerable
	{
		IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler:Com.Onesignal.Shortcutbadger.IBadgerInvoker, OneSignal.Android.Binding")]
			get;
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler:Com.Onesignal.Shortcutbadger.IBadgerInvoker, OneSignal.Android.Binding")]
		void ExecuteBadge(Context p0, ComponentName p1, int p2);
	}
	[Register("com/onesignal/shortcutbadger/Badger", DoNotGenerateAcw = true)]
	internal class IBadgerInvoker : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/Badger", typeof(IBadgerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getSupportLaunchers;

		private IntPtr id_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		private IntPtr id_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public IList<string> SupportLaunchers
		{
			get
			{
				if (id_getSupportLaunchers == IntPtr.Zero)
				{
					id_getSupportLaunchers = JNIEnv.GetMethodID(class_ref, "getSupportLaunchers", "()Ljava/util/List;");
				}
				return JavaList<string>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportLaunchers), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IBadger GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBadger>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.shortcutbadger.Badger'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IBadgerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			IBadger badger = Java.Lang.Object.GetObject<IBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(badger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2)
		{
			IBadger badger = Java.Lang.Object.GetObject<IBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p3 = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			ComponentName p4 = Java.Lang.Object.GetObject<ComponentName>(native_p1, JniHandleOwnership.DoNotTransfer);
			badger.ExecuteBadge(p3, p4, p2);
		}

		public unsafe void ExecuteBadge(Context p0, ComponentName p1, int p2)
		{
			if (id_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == IntPtr.Zero)
			{
				id_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNIEnv.GetMethodID(class_ref, "executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I, ptr);
		}
	}
	[Register("com/onesignal/shortcutbadger/ShortcutBadgeException", DoNotGenerateAcw = true)]
	public class ShortcutBadgeException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/ShortcutBadgeException", typeof(ShortcutBadgeException));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ShortcutBadgeException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe ShortcutBadgeException(string message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Exception;)V", "")]
		public unsafe ShortcutBadgeException(string message, Java.Lang.Exception e)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Exception;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(e);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/ShortcutBadger", DoNotGenerateAcw = true)]
	public sealed class ShortcutBadger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/ShortcutBadger", typeof(ShortcutBadger));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal ShortcutBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("applyCount", "(Landroid/content/Context;I)Z", "")]
		public unsafe static bool ApplyCount(Context context, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(badgeCount);
				return _members.StaticMethods.InvokeBooleanMethod("applyCount.(Landroid/content/Context;I)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("applyCountOrThrow", "(Landroid/content/Context;I)V", "")]
		public unsafe static void ApplyCountOrThrow(Context context, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(badgeCount);
				_members.StaticMethods.InvokeVoidMethod("applyCountOrThrow.(Landroid/content/Context;I)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("applyNotification", "(Landroid/content/Context;Landroid/app/Notification;I)V", "")]
		public unsafe static void ApplyNotification(Context context, Notification notification, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.StaticMethods.InvokeVoidMethod("applyNotification.(Landroid/content/Context;Landroid/app/Notification;I)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(notification);
			}
		}

		[Register("isBadgeCounterSupported", "(Landroid/content/Context;)Z", "")]
		public unsafe static bool IsBadgeCounterSupported(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("isBadgeCounterSupported.(Landroid/content/Context;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("removeCount", "(Landroid/content/Context;)Z", "")]
		public unsafe static bool RemoveCount(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("removeCount.(Landroid/content/Context;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("removeCountOrThrow", "(Landroid/content/Context;)V", "")]
		public unsafe static void RemoveCountOrThrow(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("removeCountOrThrow.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
}
namespace Com.Onesignal.Shortcutbadger.Util
{
	[Register("com/onesignal/shortcutbadger/util/BroadcastHelper", DoNotGenerateAcw = true)]
	public class BroadcastHelper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/util/BroadcastHelper", typeof(BroadcastHelper));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected BroadcastHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BroadcastHelper()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("canResolveBroadcast", "(Landroid/content/Context;Landroid/content/Intent;)Z", "")]
		public unsafe static bool CanResolveBroadcast(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("canResolveBroadcast.(Landroid/content/Context;Landroid/content/Intent;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}

		[Register("resolveBroadcast", "(Landroid/content/Context;Landroid/content/Intent;)Ljava/util/List;", "")]
		public unsafe static IList<ResolveInfo> ResolveBroadcast(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return JavaList<ResolveInfo>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("resolveBroadcast.(Landroid/content/Context;Landroid/content/Intent;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}

		[Register("sendIntentExplicitly", "(Landroid/content/Context;Landroid/content/Intent;)V", "")]
		public unsafe static void SendIntentExplicitly(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("sendIntentExplicitly.(Landroid/content/Context;Landroid/content/Intent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/util/CloseHelper", DoNotGenerateAcw = true)]
	public class CloseHelper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/util/CloseHelper", typeof(CloseHelper));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected CloseHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CloseHelper()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("close", "(Landroid/database/Cursor;)V", "")]
		public unsafe static void Close(ICursor cursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				_members.StaticMethods.InvokeVoidMethod("close.(Landroid/database/Cursor;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(cursor);
			}
		}

		[Register("closeQuietly", "(Ljava/io/Closeable;)V", "")]
		public unsafe static void CloseQuietly(ICloseable closeable)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((closeable == null) ? IntPtr.Zero : ((Java.Lang.Object)closeable).Handle);
				_members.StaticMethods.InvokeVoidMethod("closeQuietly.(Ljava/io/Closeable;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(closeable);
			}
		}
	}
}
namespace Com.Onesignal.Shortcutbadger.Impl
{
	[Register("com/onesignal/shortcutbadger/impl/AdwHomeBadger", DoNotGenerateAcw = true)]
	public class AdwHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("CLASSNAME")]
		public const string Classname = "CNAME";

		[Register("COUNT")]
		public const string Count = "COUNT";

		[Register("INTENT_UPDATE_COUNTER")]
		public const string IntentUpdateCounter = "org.adw.launcher.counter.SEND";

		[Register("PACKAGENAME")]
		public const string Packagename = "PNAME";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/AdwHomeBadger", typeof(AdwHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected AdwHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AdwHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			AdwHomeBadger adwHomeBadger = Java.Lang.Object.GetObject<AdwHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(adwHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			AdwHomeBadger adwHomeBadger = Java.Lang.Object.GetObject<AdwHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			adwHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/ApexHomeBadger", DoNotGenerateAcw = true)]
	public class ApexHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/ApexHomeBadger", typeof(ApexHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ApexHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ApexHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			ApexHomeBadger apexHomeBadger = Java.Lang.Object.GetObject<ApexHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(apexHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			ApexHomeBadger apexHomeBadger = Java.Lang.Object.GetObject<ApexHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			apexHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/AsusHomeBadger", DoNotGenerateAcw = true)]
	public class AsusHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/AsusHomeBadger", typeof(AsusHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected AsusHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AsusHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			AsusHomeBadger asusHomeBadger = Java.Lang.Object.GetObject<AsusHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(asusHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			AsusHomeBadger asusHomeBadger = Java.Lang.Object.GetObject<AsusHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			asusHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/DefaultBadger", DoNotGenerateAcw = true)]
	public class DefaultBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/DefaultBadger", typeof(DefaultBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected DefaultBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DefaultBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			DefaultBadger defaultBadger = Java.Lang.Object.GetObject<DefaultBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(defaultBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			DefaultBadger defaultBadger = Java.Lang.Object.GetObject<DefaultBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			defaultBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/EverythingMeHomeBadger", DoNotGenerateAcw = true)]
	public class EverythingMeHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/EverythingMeHomeBadger", typeof(EverythingMeHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected EverythingMeHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EverythingMeHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			EverythingMeHomeBadger everythingMeHomeBadger = Java.Lang.Object.GetObject<EverythingMeHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(everythingMeHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			EverythingMeHomeBadger everythingMeHomeBadger = Java.Lang.Object.GetObject<EverythingMeHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			everythingMeHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/HuaweiHomeBadger", DoNotGenerateAcw = true)]
	public class HuaweiHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/HuaweiHomeBadger", typeof(HuaweiHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected HuaweiHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe HuaweiHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			HuaweiHomeBadger huaweiHomeBadger = Java.Lang.Object.GetObject<HuaweiHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(huaweiHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			HuaweiHomeBadger huaweiHomeBadger = Java.Lang.Object.GetObject<HuaweiHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			huaweiHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/onesignal/shortcutbadger/impl/LGHomeBadger", DoNotGenerateAcw = true)]
	public class LGHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/LGHomeBadger", typeof(LGHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LGHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LGHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			LGHomeBadger lGHomeBadger = Java.Lang.Object.GetObject<LGHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(lGHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			LGHomeBadger lGHomeBadger = Java.Lang.Object.GetObject<LGHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			lGHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/NewHtcHomeBadger", DoNotGenerateAcw = true)]
	public class NewHtcHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("COUNT")]
		public const string Count = "count";

		[Register("EXTRA_COMPONENT")]
		public const string ExtraComponent = "com.htc.launcher.extra.COMPONENT";

		[Register("EXTRA_COUNT")]
		public const string ExtraCount = "com.htc.launcher.extra.COUNT";

		[Register("INTENT_SET_NOTIFICATION")]
		public const string IntentSetNotification = "com.htc.launcher.action.SET_NOTIFICATION";

		[Register("INTENT_UPDATE_SHORTCUT")]
		public const string IntentUpdateShortcut = "com.htc.launcher.action.UPDATE_SHORTCUT";

		[Register("PACKAGENAME")]
		public const string Packagename = "packagename";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/NewHtcHomeBadger", typeof(NewHtcHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NewHtcHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NewHtcHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			NewHtcHomeBadger newHtcHomeBadger = Java.Lang.Object.GetObject<NewHtcHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(newHtcHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			NewHtcHomeBadger newHtcHomeBadger = Java.Lang.Object.GetObject<NewHtcHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			newHtcHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/NovaHomeBadger", DoNotGenerateAcw = true)]
	public class NovaHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/NovaHomeBadger", typeof(NovaHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected NovaHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NovaHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			NovaHomeBadger novaHomeBadger = Java.Lang.Object.GetObject<NovaHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(novaHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			NovaHomeBadger novaHomeBadger = Java.Lang.Object.GetObject<NovaHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			novaHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/OPPOHomeBader", DoNotGenerateAcw = true)]
	public class OPPOHomeBader : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/OPPOHomeBader", typeof(OPPOHomeBader));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OPPOHomeBader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OPPOHomeBader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			OPPOHomeBader oPPOHomeBader = Java.Lang.Object.GetObject<OPPOHomeBader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(oPPOHomeBader.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			OPPOHomeBader oPPOHomeBader = Java.Lang.Object.GetObject<OPPOHomeBader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			oPPOHomeBader.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/SamsungHomeBadger", DoNotGenerateAcw = true)]
	public class SamsungHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/SamsungHomeBadger", typeof(SamsungHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SamsungHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SamsungHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			SamsungHomeBadger samsungHomeBadger = Java.Lang.Object.GetObject<SamsungHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(samsungHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			SamsungHomeBadger samsungHomeBadger = Java.Lang.Object.GetObject<SamsungHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			samsungHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/SonyHomeBadger", DoNotGenerateAcw = true)]
	public class SonyHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/SonyHomeBadger", typeof(SonyHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected SonyHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SonyHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			SonyHomeBadger sonyHomeBadger = Java.Lang.Object.GetObject<SonyHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(sonyHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			SonyHomeBadger sonyHomeBadger = Java.Lang.Object.GetObject<SonyHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			sonyHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/VivoHomeBadger", DoNotGenerateAcw = true)]
	public class VivoHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/VivoHomeBadger", typeof(VivoHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected VivoHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe VivoHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			VivoHomeBadger vivoHomeBadger = Java.Lang.Object.GetObject<VivoHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(vivoHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			VivoHomeBadger vivoHomeBadger = Java.Lang.Object.GetObject<VivoHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			vivoHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/onesignal/shortcutbadger/impl/XiaomiHomeBadger", DoNotGenerateAcw = true)]
	public class XiaomiHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("EXTRA_UPDATE_APP_COMPONENT_NAME")]
		public const string ExtraUpdateAppComponentName = "android.intent.extra.update_application_component_name";

		[Register("EXTRA_UPDATE_APP_MSG_TEXT")]
		public const string ExtraUpdateAppMsgText = "android.intent.extra.update_application_message_text";

		[Register("INTENT_ACTION")]
		public const string IntentAction = "android.intent.action.APPLICATION_MESSAGE_UPDATE";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/XiaomiHomeBadger", typeof(XiaomiHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected XiaomiHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe XiaomiHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			XiaomiHomeBadger xiaomiHomeBadger = Java.Lang.Object.GetObject<XiaomiHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(xiaomiHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			XiaomiHomeBadger xiaomiHomeBadger = Java.Lang.Object.GetObject<XiaomiHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			xiaomiHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
	[Register("com/onesignal/shortcutbadger/impl/ZukHomeBadger", DoNotGenerateAcw = true)]
	public class ZukHomeBadger : Java.Lang.Object, IBadger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/shortcutbadger/impl/ZukHomeBadger", typeof(ZukHomeBadger));

		private static Delegate cb_getSupportLaunchers;

		private static Delegate cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<string> SupportLaunchers
		{
			[Register("getSupportLaunchers", "()Ljava/util/List;", "GetGetSupportLaunchersHandler")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLaunchers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ZukHomeBadger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ZukHomeBadger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSupportLaunchersHandler()
		{
			if ((object)cb_getSupportLaunchers == null)
			{
				cb_getSupportLaunchers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportLaunchers));
			}
			return cb_getSupportLaunchers;
		}

		private static IntPtr n_GetSupportLaunchers(IntPtr jnienv, IntPtr native__this)
		{
			ZukHomeBadger zukHomeBadger = Java.Lang.Object.GetObject<ZukHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<string>.ToLocalJniHandle(zukHomeBadger.SupportLaunchers);
		}

		private static Delegate GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler()
		{
			if ((object)cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I == null)
			{
				cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I));
			}
			return cb_executeBadge_Landroid_content_Context_Landroid_content_ComponentName_I;
		}

		private static void n_ExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_componentName, int badgeCount)
		{
			ZukHomeBadger zukHomeBadger = Java.Lang.Object.GetObject<ZukHomeBadger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ComponentName componentName = Java.Lang.Object.GetObject<ComponentName>(native_componentName, JniHandleOwnership.DoNotTransfer);
			zukHomeBadger.ExecuteBadge(context, componentName, badgeCount);
		}

		[Register("executeBadge", "(Landroid/content/Context;Landroid/content/ComponentName;I)V", "GetExecuteBadge_Landroid_content_Context_Landroid_content_ComponentName_IHandler")]
		public unsafe virtual void ExecuteBadge(Context context, ComponentName componentName, int badgeCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(badgeCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("executeBadge.(Landroid/content/Context;Landroid/content/ComponentName;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(componentName);
			}
		}
	}
}
namespace Com.Onesignal.Outcomes.Domain
{
	[Register("com/onesignal/outcomes/domain/OSOutcomeEventsRepository", "", "Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker")]
	public interface IOSOutcomeEventsRepository : IJavaObject, IDisposable, IJavaPeerable
	{
		IList<OSOutcomeEventParams> SavedOutcomeEvents
		{
			[Register("getSavedOutcomeEvents", "()Ljava/util/List;", "GetGetSavedOutcomeEventsHandler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
			get;
		}

		ICollection<string> UnattributedUniqueOutcomeEventsSent
		{
			[Register("getUnattributedUniqueOutcomeEventsSent", "()Ljava/util/Set;", "GetGetUnattributedUniqueOutcomeEventsSentHandler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
			get;
		}

		[Register("cleanCachedUniqueOutcomeEventNotifications", "(Ljava/lang/String;Ljava/lang/String;)V", "GetCleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void CleanCachedUniqueOutcomeEventNotifications(string notificationTableName, string notificationIdColumnName);

		[Register("getNotCachedUniqueOutcome", "(Ljava/lang/String;Ljava/util/List;)Ljava/util/List;", "GetGetNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		IList<OSInfluence> GetNotCachedUniqueOutcome(string name, IList<OSInfluence> influences);

		[Register("removeEvent", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V", "GetRemoveEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void RemoveEvent(OSOutcomeEventParams outcomeEvent);

		[Register("requestMeasureOutcomeEvent", "(Ljava/lang/String;ILcom/onesignal/outcomes/domain/OSOutcomeEventParams;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetRequestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void RequestMeasureOutcomeEvent(string appId, int deviceType, OSOutcomeEventParams e, IOneSignalApiResponseHandler responseHandler);

		[Register("saveOutcomeEvent", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V", "GetSaveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void SaveOutcomeEvent(OSOutcomeEventParams e);

		[Register("saveUnattributedUniqueOutcomeEventsSent", "(Ljava/util/Set;)V", "GetSaveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void SaveUnattributedUniqueOutcomeEventsSent(ICollection<string> unattributedUniqueOutcomeEvents);

		[Register("saveUniqueOutcomeNotifications", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V", "GetSaveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler:Com.Onesignal.Outcomes.Domain.IOSOutcomeEventsRepositoryInvoker, OneSignal.Android.Binding")]
		void SaveUniqueOutcomeNotifications(OSOutcomeEventParams eventParams);
	}
	[Register("com/onesignal/outcomes/domain/OSOutcomeEventsRepository", DoNotGenerateAcw = true)]
	internal class IOSOutcomeEventsRepositoryInvoker : Java.Lang.Object, IOSOutcomeEventsRepository, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/domain/OSOutcomeEventsRepository", typeof(IOSOutcomeEventsRepositoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getSavedOutcomeEvents;

		private IntPtr id_getSavedOutcomeEvents;

		private static Delegate cb_getUnattributedUniqueOutcomeEventsSent;

		private IntPtr id_getUnattributedUniqueOutcomeEventsSent;

		private static Delegate cb_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_;

		private IntPtr id_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_;

		private static Delegate cb_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private IntPtr id_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private static Delegate cb_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static Delegate cb_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private IntPtr id_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private static Delegate cb_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_;

		private IntPtr id_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_;

		private static Delegate cb_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private IntPtr id_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public IList<OSOutcomeEventParams> SavedOutcomeEvents
		{
			get
			{
				if (id_getSavedOutcomeEvents == IntPtr.Zero)
				{
					id_getSavedOutcomeEvents = JNIEnv.GetMethodID(class_ref, "getSavedOutcomeEvents", "()Ljava/util/List;");
				}
				return JavaList<OSOutcomeEventParams>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSavedOutcomeEvents), JniHandleOwnership.TransferLocalRef);
			}
		}

		public ICollection<string> UnattributedUniqueOutcomeEventsSent
		{
			get
			{
				if (id_getUnattributedUniqueOutcomeEventsSent == IntPtr.Zero)
				{
					id_getUnattributedUniqueOutcomeEventsSent = JNIEnv.GetMethodID(class_ref, "getUnattributedUniqueOutcomeEventsSent", "()Ljava/util/Set;");
				}
				return JavaSet<string>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getUnattributedUniqueOutcomeEventsSent), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IOSOutcomeEventsRepository GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.outcomes.domain.OSOutcomeEventsRepository'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSOutcomeEventsRepositoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetSavedOutcomeEventsHandler()
		{
			if ((object)cb_getSavedOutcomeEvents == null)
			{
				cb_getSavedOutcomeEvents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSavedOutcomeEvents));
			}
			return cb_getSavedOutcomeEvents;
		}

		private static IntPtr n_GetSavedOutcomeEvents(IntPtr jnienv, IntPtr native__this)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<OSOutcomeEventParams>.ToLocalJniHandle(iOSOutcomeEventsRepository.SavedOutcomeEvents);
		}

		private static Delegate GetGetUnattributedUniqueOutcomeEventsSentHandler()
		{
			if ((object)cb_getUnattributedUniqueOutcomeEventsSent == null)
			{
				cb_getUnattributedUniqueOutcomeEventsSent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUnattributedUniqueOutcomeEventsSent));
			}
			return cb_getUnattributedUniqueOutcomeEventsSent;
		}

		private static IntPtr n_GetUnattributedUniqueOutcomeEventsSent(IntPtr jnienv, IntPtr native__this)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaSet<string>.ToLocalJniHandle(iOSOutcomeEventsRepository.UnattributedUniqueOutcomeEventsSent);
		}

		private static Delegate GetCleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_CleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_notificationTableName, IntPtr native_notificationIdColumnName)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string notificationTableName = JNIEnv.GetString(native_notificationTableName, JniHandleOwnership.DoNotTransfer);
			string notificationIdColumnName = JNIEnv.GetString(native_notificationIdColumnName, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.CleanCachedUniqueOutcomeEventNotifications(notificationTableName, notificationIdColumnName);
		}

		public unsafe void CleanCachedUniqueOutcomeEventNotifications(string notificationTableName, string notificationIdColumnName)
		{
			if (id_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "cleanCachedUniqueOutcomeEventNotifications", "(Ljava/lang/String;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(notificationTableName);
			IntPtr intPtr2 = JNIEnv.NewString(notificationIdColumnName);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_cleanCachedUniqueOutcomeEventNotifications_Ljava_lang_String_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetGetNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_Handler()
		{
			if ((object)cb_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_ == null)
			{
				cb_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_));
			}
			return cb_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_;
		}

		private static IntPtr n_GetNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_influences)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			IList<OSInfluence> influences = JavaList<OSInfluence>.FromJniHandle(native_influences, JniHandleOwnership.DoNotTransfer);
			return JavaList<OSInfluence>.ToLocalJniHandle(iOSOutcomeEventsRepository.GetNotCachedUniqueOutcome(name, influences));
		}

		public unsafe IList<OSInfluence> GetNotCachedUniqueOutcome(string name, IList<OSInfluence> influences)
		{
			if (id_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_ == IntPtr.Zero)
			{
				id_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "getNotCachedUniqueOutcome", "(Ljava/lang/String;Ljava/util/List;)Ljava/util/List;");
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			IntPtr intPtr2 = JavaList<OSInfluence>.ToLocalJniHandle(influences);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			IList<OSInfluence> result = JavaList<OSInfluence>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getNotCachedUniqueOutcome_Ljava_lang_String_Ljava_util_List_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetRemoveEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler()
		{
			if ((object)cb_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == null)
			{
				cb_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_));
			}
			return cb_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;
		}

		private static void n_RemoveEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_outcomeEvent)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSOutcomeEventParams outcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEventParams>(native_outcomeEvent, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.RemoveEvent(outcomeEvent);
		}

		public unsafe void RemoveEvent(OSOutcomeEventParams outcomeEvent)
		{
			if (id_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == IntPtr.Zero)
			{
				id_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNIEnv.GetMethodID(class_ref, "removeEvent", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(outcomeEvent?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_removeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_, ptr);
		}

		private static Delegate GetRequestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILL_V(n_RequestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_RequestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_appId, int deviceType, IntPtr native_e, IntPtr native_responseHandler)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string appId = JNIEnv.GetString(native_appId, JniHandleOwnership.DoNotTransfer);
			OSOutcomeEventParams e = Java.Lang.Object.GetObject<OSOutcomeEventParams>(native_e, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler responseHandler = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_responseHandler, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.RequestMeasureOutcomeEvent(appId, deviceType, e, responseHandler);
		}

		public unsafe void RequestMeasureOutcomeEvent(string appId, int deviceType, OSOutcomeEventParams e, IOneSignalApiResponseHandler responseHandler)
		{
			if (id_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "requestMeasureOutcomeEvent", "(Ljava/lang/String;ILcom/onesignal/outcomes/domain/OSOutcomeEventParams;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(appId);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(deviceType);
			ptr[2] = new JValue(e?.Handle ?? IntPtr.Zero);
			ptr[3] = new JValue((responseHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)responseHandler).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_requestMeasureOutcomeEvent_Ljava_lang_String_ILcom_onesignal_outcomes_domain_OSOutcomeEventParams_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetSaveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler()
		{
			if ((object)cb_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == null)
			{
				cb_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SaveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_));
			}
			return cb_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;
		}

		private static void n_SaveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSOutcomeEventParams e = Java.Lang.Object.GetObject<OSOutcomeEventParams>(native_e, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.SaveOutcomeEvent(e);
		}

		public unsafe void SaveOutcomeEvent(OSOutcomeEventParams e)
		{
			if (id_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == IntPtr.Zero)
			{
				id_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNIEnv.GetMethodID(class_ref, "saveOutcomeEvent", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(e?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_saveOutcomeEvent_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_, ptr);
		}

		private static Delegate GetSaveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_Handler()
		{
			if ((object)cb_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_ == null)
			{
				cb_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SaveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_));
			}
			return cb_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_;
		}

		private static void n_SaveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_(IntPtr jnienv, IntPtr native__this, IntPtr native_unattributedUniqueOutcomeEvents)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<string> unattributedUniqueOutcomeEvents = JavaSet<string>.FromJniHandle(native_unattributedUniqueOutcomeEvents, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.SaveUnattributedUniqueOutcomeEventsSent(unattributedUniqueOutcomeEvents);
		}

		public unsafe void SaveUnattributedUniqueOutcomeEventsSent(ICollection<string> unattributedUniqueOutcomeEvents)
		{
			if (id_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_ == IntPtr.Zero)
			{
				id_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_ = JNIEnv.GetMethodID(class_ref, "saveUnattributedUniqueOutcomeEventsSent", "(Ljava/util/Set;)V");
			}
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(unattributedUniqueOutcomeEvents);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_saveUnattributedUniqueOutcomeEventsSent_Ljava_util_Set_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetSaveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_Handler()
		{
			if ((object)cb_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == null)
			{
				cb_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SaveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_));
			}
			return cb_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_;
		}

		private static void n_SaveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_(IntPtr jnienv, IntPtr native__this, IntPtr native_eventParams)
		{
			IOSOutcomeEventsRepository iOSOutcomeEventsRepository = Java.Lang.Object.GetObject<IOSOutcomeEventsRepository>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSOutcomeEventParams eventParams = Java.Lang.Object.GetObject<OSOutcomeEventParams>(native_eventParams, JniHandleOwnership.DoNotTransfer);
			iOSOutcomeEventsRepository.SaveUniqueOutcomeNotifications(eventParams);
		}

		public unsafe void SaveUniqueOutcomeNotifications(OSOutcomeEventParams eventParams)
		{
			if (id_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ == IntPtr.Zero)
			{
				id_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_ = JNIEnv.GetMethodID(class_ref, "saveUniqueOutcomeNotifications", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(eventParams?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_saveUniqueOutcomeNotifications_Lcom_onesignal_outcomes_domain_OSOutcomeEventParams_, ptr);
		}
	}
	[Register("com/onesignal/outcomes/domain/OSCachedUniqueOutcome", DoNotGenerateAcw = true)]
	public class OSCachedUniqueOutcome : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/domain/OSCachedUniqueOutcome", typeof(OSCachedUniqueOutcome));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSCachedUniqueOutcome(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/onesignal/influence/domain/OSInfluenceChannel;)V", "")]
		public unsafe OSCachedUniqueOutcome(string influenceId, OSInfluenceChannel channel)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(influenceId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(channel?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/onesignal/influence/domain/OSInfluenceChannel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/onesignal/influence/domain/OSInfluenceChannel;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(channel);
			}
		}
	}
	[Register("com/onesignal/outcomes/domain/OSOutcomeEventParams", DoNotGenerateAcw = true)]
	public sealed class OSOutcomeEventParams : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/domain/OSOutcomeEventParams", typeof(OSOutcomeEventParams));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsUnattributed
		{
			[Register("isUnattributed", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isUnattributed.()Z", this, null);
			}
		}

		public unsafe string OutcomeId
		{
			[Register("getOutcomeId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOutcomeId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSOutcomeSource OutcomeSource
		{
			[Register("getOutcomeSource", "()Lcom/onesignal/outcomes/domain/OSOutcomeSource;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSOutcomeSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOutcomeSource.()Lcom/onesignal/outcomes/domain/OSOutcomeSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe long Timestamp
		{
			[Register("getTimestamp", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("getTimestamp.()J", this, null);
			}
			[Register("setTimestamp", "(J)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTimestamp.(J)V", this, ptr);
			}
		}

		public unsafe float Weight
		{
			[Register("getWeight", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getWeight.()F", this, null);
			}
			[Register("setWeight", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setWeight.(F)V", this, ptr);
			}
		}

		internal OSOutcomeEventParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/onesignal/outcomes/domain/OSOutcomeSource;FJ)V", "")]
		public unsafe OSOutcomeEventParams(string outcomeId, OSOutcomeSource outcomeSource, float weight, long timestamp)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(outcomeId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(outcomeSource?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(weight);
				ptr[3] = new JniArgumentValue(timestamp);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/onesignal/outcomes/domain/OSOutcomeSource;FJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/onesignal/outcomes/domain/OSOutcomeSource;FJ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(outcomeSource);
			}
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/outcomes/domain/OSOutcomeSource", DoNotGenerateAcw = true)]
	public sealed class OSOutcomeSource : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/domain/OSOutcomeSource", typeof(OSOutcomeSource));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe OSOutcomeSourceBody DirectBody
		{
			[Register("getDirectBody", "()Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSOutcomeSourceBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDirectBody.()Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDirectBody", "(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDirectBody.(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe OSOutcomeSourceBody IndirectBody
		{
			[Register("getIndirectBody", "()Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSOutcomeSourceBody>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIndirectBody.()Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIndirectBody", "(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIndirectBody.(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal OSOutcomeSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", "")]
		public unsafe OSOutcomeSource(OSOutcomeSourceBody directBody, OSOutcomeSourceBody indirectBody)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(directBody?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(indirectBody?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(directBody);
				GC.KeepAlive(indirectBody);
			}
		}

		[Register("setDirectBody", "(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)Lcom/onesignal/outcomes/domain/OSOutcomeSource;", "")]
		public unsafe OSOutcomeSource SetDirectBody(OSOutcomeSourceBody directBody)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(directBody?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OSOutcomeSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setDirectBody.(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)Lcom/onesignal/outcomes/domain/OSOutcomeSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(directBody);
			}
		}

		[Register("setIndirectBody", "(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)Lcom/onesignal/outcomes/domain/OSOutcomeSource;", "")]
		public unsafe OSOutcomeSource SetIndirectBody(OSOutcomeSourceBody indirectBody)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(indirectBody?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OSOutcomeSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setIndirectBody.(Lcom/onesignal/outcomes/domain/OSOutcomeSourceBody;)Lcom/onesignal/outcomes/domain/OSOutcomeSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(indirectBody);
			}
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/outcomes/domain/OSOutcomeSourceBody", DoNotGenerateAcw = true)]
	public sealed class OSOutcomeSourceBody : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/domain/OSOutcomeSourceBody", typeof(OSOutcomeSourceBody));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe JSONArray InAppMessagesIds
		{
			[Register("getInAppMessagesIds", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInAppMessagesIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setInAppMessagesIds", "(Lorg/json/JSONArray;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInAppMessagesIds.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe JSONArray NotificationIds
		{
			[Register("getNotificationIds", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNotificationIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setNotificationIds", "(Lorg/json/JSONArray;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setNotificationIds.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal OSOutcomeSourceBody(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSOutcomeSourceBody()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lorg/json/JSONArray;)V", "")]
		public unsafe OSOutcomeSourceBody(JSONArray notificationIds)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(notificationIds?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/json/JSONArray;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notificationIds);
			}
		}

		[Register(".ctor", "(Lorg/json/JSONArray;Lorg/json/JSONArray;)V", "")]
		public unsafe OSOutcomeSourceBody(JSONArray notificationIds, JSONArray inAppMessagesIds)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(notificationIds?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(inAppMessagesIds?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/json/JSONArray;Lorg/json/JSONArray;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lorg/json/JSONArray;Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notificationIds);
				GC.KeepAlive(inAppMessagesIds);
			}
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Com.Onesignal.Outcomes.Data
{
	[Register("com/onesignal/outcomes/data/OutcomeEventsService", "", "Com.Onesignal.Outcomes.Data.IOutcomeEventsServiceInvoker")]
	public interface IOutcomeEventsService : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("sendOutcomeEvent", "(Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetSendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.Onesignal.Outcomes.Data.IOutcomeEventsServiceInvoker, OneSignal.Android.Binding")]
		void SendOutcomeEvent(JSONObject jsonObject, IOneSignalApiResponseHandler responseHandler);
	}
	[Register("com/onesignal/outcomes/data/OutcomeEventsService", DoNotGenerateAcw = true)]
	internal class IOutcomeEventsServiceInvoker : Java.Lang.Object, IOutcomeEventsService, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/data/OutcomeEventsService", typeof(IOutcomeEventsServiceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOutcomeEventsService GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOutcomeEventsService>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.outcomes.data.OutcomeEventsService'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOutcomeEventsServiceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_SendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_jsonObject, IntPtr native_responseHandler)
		{
			IOutcomeEventsService outcomeEventsService = Java.Lang.Object.GetObject<IOutcomeEventsService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject jsonObject = Java.Lang.Object.GetObject<JSONObject>(native_jsonObject, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler responseHandler = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_responseHandler, JniHandleOwnership.DoNotTransfer);
			outcomeEventsService.SendOutcomeEvent(jsonObject, responseHandler);
		}

		public unsafe void SendOutcomeEvent(JSONObject jsonObject, IOneSignalApiResponseHandler responseHandler)
		{
			if (id_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "sendOutcomeEvent", "(Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(jsonObject?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((responseHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)responseHandler).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_sendOutcomeEvent_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
		}
	}
	[Register("com/onesignal/outcomes/data/OSOutcomeEventsFactory", DoNotGenerateAcw = true)]
	public sealed class OSOutcomeEventsFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/data/OSOutcomeEventsFactory", typeof(OSOutcomeEventsFactory));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSOutcomeEventsFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSLogger;Lcom/onesignal/OneSignalAPIClient;Lcom/onesignal/OneSignalDb;Lcom/onesignal/OSSharedPreferences;)V", "")]
		public unsafe OSOutcomeEventsFactory(IOSLogger logger, IOneSignalAPIClient apiClient, IOneSignalDb dbHelper, IOSSharedPreferences preferences)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((logger == null) ? IntPtr.Zero : ((Java.Lang.Object)logger).Handle);
				ptr[1] = new JniArgumentValue((apiClient == null) ? IntPtr.Zero : ((Java.Lang.Object)apiClient).Handle);
				ptr[2] = new JniArgumentValue((dbHelper == null) ? IntPtr.Zero : ((Java.Lang.Object)dbHelper).Handle);
				ptr[3] = new JniArgumentValue((preferences == null) ? IntPtr.Zero : ((Java.Lang.Object)preferences).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSLogger;Lcom/onesignal/OneSignalAPIClient;Lcom/onesignal/OneSignalDb;Lcom/onesignal/OSSharedPreferences;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSLogger;Lcom/onesignal/OneSignalAPIClient;Lcom/onesignal/OneSignalDb;Lcom/onesignal/OSSharedPreferences;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(logger);
				GC.KeepAlive(apiClient);
				GC.KeepAlive(dbHelper);
				GC.KeepAlive(preferences);
			}
		}
	}
	[Register("com/onesignal/outcomes/data/OSOutcomeTableProvider", DoNotGenerateAcw = true)]
	public sealed class OSOutcomeTableProvider : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/outcomes/data/OSOutcomeTableProvider", typeof(OSOutcomeTableProvider));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSOutcomeTableProvider(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSOutcomeTableProvider()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("upgradeCacheOutcomeTableRevision1To2", "(Landroid/database/sqlite/SQLiteDatabase;)V", "")]
		public unsafe void UpgradeCacheOutcomeTableRevision1To2(SQLiteDatabase db)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(db?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("upgradeCacheOutcomeTableRevision1To2.(Landroid/database/sqlite/SQLiteDatabase;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(db);
			}
		}

		[Register("upgradeOutcomeTableRevision1To2", "(Landroid/database/sqlite/SQLiteDatabase;)V", "")]
		public unsafe void UpgradeOutcomeTableRevision1To2(SQLiteDatabase db)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(db?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("upgradeOutcomeTableRevision1To2.(Landroid/database/sqlite/SQLiteDatabase;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(db);
			}
		}

		[Register("upgradeOutcomeTableRevision2To3", "(Landroid/database/sqlite/SQLiteDatabase;)V", "")]
		public unsafe void UpgradeOutcomeTableRevision2To3(SQLiteDatabase db)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(db?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("upgradeOutcomeTableRevision2To3.(Landroid/database/sqlite/SQLiteDatabase;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(db);
			}
		}
	}
}
namespace Com.Onesignal.Language
{
	[Register("com/onesignal/language/LanguageProvider", "", "Com.Onesignal.Language.ILanguageProviderInvoker")]
	public interface ILanguageProvider : IJavaObject, IDisposable, IJavaPeerable
	{
		string Language
		{
			[Register("getLanguage", "()Ljava/lang/String;", "GetGetLanguageHandler:Com.Onesignal.Language.ILanguageProviderInvoker, OneSignal.Android.Binding")]
			get;
		}
	}
	[Register("com/onesignal/language/LanguageProvider", DoNotGenerateAcw = true)]
	internal class ILanguageProviderInvoker : Java.Lang.Object, ILanguageProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/language/LanguageProvider", typeof(ILanguageProviderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getLanguage;

		private IntPtr id_getLanguage;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public string Language
		{
			get
			{
				if (id_getLanguage == IntPtr.Zero)
				{
					id_getLanguage = JNIEnv.GetMethodID(class_ref, "getLanguage", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getLanguage), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ILanguageProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILanguageProvider>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.language.LanguageProvider'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public ILanguageProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetLanguageHandler()
		{
			if ((object)cb_getLanguage == null)
			{
				cb_getLanguage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLanguage));
			}
			return cb_getLanguage;
		}

		private static IntPtr n_GetLanguage(IntPtr jnienv, IntPtr native__this)
		{
			ILanguageProvider languageProvider = Java.Lang.Object.GetObject<ILanguageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(languageProvider.Language);
		}
	}
	[Register("com/onesignal/language/LanguageContext", DoNotGenerateAcw = true)]
	public class LanguageContext : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/language/LanguageContext", typeof(LanguageContext));

		private static Delegate cb_getLanguage;

		private static Delegate cb_setStrategy_Lcom_onesignal_language_LanguageProvider_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static LanguageContext Instance
		{
			[Register("getInstance", "()Lcom/onesignal/language/LanguageContext;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LanguageContext>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/onesignal/language/LanguageContext;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Language
		{
			[Register("getLanguage", "()Ljava/lang/String;", "GetGetLanguageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLanguage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LanguageContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSharedPreferences;)V", "")]
		public unsafe LanguageContext(IOSSharedPreferences preferences)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((preferences == null) ? IntPtr.Zero : ((Java.Lang.Object)preferences).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(preferences);
			}
		}

		private static Delegate GetGetLanguageHandler()
		{
			if ((object)cb_getLanguage == null)
			{
				cb_getLanguage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLanguage));
			}
			return cb_getLanguage;
		}

		private static IntPtr n_GetLanguage(IntPtr jnienv, IntPtr native__this)
		{
			LanguageContext languageContext = Java.Lang.Object.GetObject<LanguageContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(languageContext.Language);
		}

		private static Delegate GetSetStrategy_Lcom_onesignal_language_LanguageProvider_Handler()
		{
			if ((object)cb_setStrategy_Lcom_onesignal_language_LanguageProvider_ == null)
			{
				cb_setStrategy_Lcom_onesignal_language_LanguageProvider_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStrategy_Lcom_onesignal_language_LanguageProvider_));
			}
			return cb_setStrategy_Lcom_onesignal_language_LanguageProvider_;
		}

		private static void n_SetStrategy_Lcom_onesignal_language_LanguageProvider_(IntPtr jnienv, IntPtr native__this, IntPtr native_strategy)
		{
			LanguageContext languageContext = Java.Lang.Object.GetObject<LanguageContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILanguageProvider strategy = Java.Lang.Object.GetObject<ILanguageProvider>(native_strategy, JniHandleOwnership.DoNotTransfer);
			languageContext.SetStrategy(strategy);
		}

		[Register("setStrategy", "(Lcom/onesignal/language/LanguageProvider;)V", "GetSetStrategy_Lcom_onesignal_language_LanguageProvider_Handler")]
		public unsafe virtual void SetStrategy(ILanguageProvider strategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((strategy == null) ? IntPtr.Zero : ((Java.Lang.Object)strategy).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrategy.(Lcom/onesignal/language/LanguageProvider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(strategy);
			}
		}
	}
	[Register("com/onesignal/language/LanguageProviderAppDefined", DoNotGenerateAcw = true)]
	public class LanguageProviderAppDefined : Java.Lang.Object, ILanguageProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("PREFS_OS_LANGUAGE")]
		public const string PrefsOsLanguage = "PREFS_OS_LANGUAGE";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/language/LanguageProviderAppDefined", typeof(LanguageProviderAppDefined));

		private static Delegate cb_getLanguage;

		private static Delegate cb_setLanguage_Ljava_lang_String_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string Language
		{
			[Register("getLanguage", "()Ljava/lang/String;", "GetGetLanguageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLanguage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLanguage", "(Ljava/lang/String;)V", "GetSetLanguage_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setLanguage.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		protected LanguageProviderAppDefined(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSharedPreferences;)V", "")]
		public unsafe LanguageProviderAppDefined(IOSSharedPreferences preferences)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((preferences == null) ? IntPtr.Zero : ((Java.Lang.Object)preferences).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(preferences);
			}
		}

		private static Delegate GetGetLanguageHandler()
		{
			if ((object)cb_getLanguage == null)
			{
				cb_getLanguage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLanguage));
			}
			return cb_getLanguage;
		}

		private static IntPtr n_GetLanguage(IntPtr jnienv, IntPtr native__this)
		{
			LanguageProviderAppDefined languageProviderAppDefined = Java.Lang.Object.GetObject<LanguageProviderAppDefined>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(languageProviderAppDefined.Language);
		}

		private static Delegate GetSetLanguage_Ljava_lang_String_Handler()
		{
			if ((object)cb_setLanguage_Ljava_lang_String_ == null)
			{
				cb_setLanguage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLanguage_Ljava_lang_String_));
			}
			return cb_setLanguage_Ljava_lang_String_;
		}

		private static void n_SetLanguage_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_language)
		{
			LanguageProviderAppDefined languageProviderAppDefined = Java.Lang.Object.GetObject<LanguageProviderAppDefined>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string language = JNIEnv.GetString(native_language, JniHandleOwnership.DoNotTransfer);
			languageProviderAppDefined.Language = language;
		}
	}
	[Register("com/onesignal/language/LanguageProviderDevice", DoNotGenerateAcw = true)]
	public class LanguageProviderDevice : Java.Lang.Object, ILanguageProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/language/LanguageProviderDevice", typeof(LanguageProviderDevice));

		private static Delegate cb_getLanguage;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string Language
		{
			[Register("getLanguage", "()Ljava/lang/String;", "GetGetLanguageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLanguage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LanguageProviderDevice(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LanguageProviderDevice()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetLanguageHandler()
		{
			if ((object)cb_getLanguage == null)
			{
				cb_getLanguage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLanguage));
			}
			return cb_getLanguage;
		}

		private static IntPtr n_GetLanguage(IntPtr jnienv, IntPtr native__this)
		{
			LanguageProviderDevice languageProviderDevice = Java.Lang.Object.GetObject<LanguageProviderDevice>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(languageProviderDevice.Language);
		}
	}
}
namespace Com.Onesignal.Influence.Domain
{
	[Register("com/onesignal/influence/domain/OSInfluence", DoNotGenerateAcw = true)]
	public sealed class OSInfluence : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/domain/OSInfluence", typeof(OSInfluence));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string DirectId
		{
			[Register("getDirectId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDirectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe JSONArray Ids
		{
			[Register("getIds", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIds", "(Lorg/json/JSONArray;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIds.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe OSInfluenceChannel InfluenceChannel
		{
			[Register("getInfluenceChannel", "()Lcom/onesignal/influence/domain/OSInfluenceChannel;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInfluenceChannel.()Lcom/onesignal/influence/domain/OSInfluenceChannel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSInfluenceType InfluenceType
		{
			[Register("getInfluenceType", "()Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInfluenceType.()Lcom/onesignal/influence/domain/OSInfluenceType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setInfluenceType", "(Lcom/onesignal/influence/domain/OSInfluenceType;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInfluenceType.(Lcom/onesignal/influence/domain/OSInfluenceType;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal OSInfluence(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/influence/domain/OSInfluenceChannel;Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;)V", "")]
		public unsafe OSInfluence(OSInfluenceChannel influenceChannel, OSInfluenceType influenceType, JSONArray ids)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(influenceChannel?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(influenceType?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(ids?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/influence/domain/OSInfluenceChannel;Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/influence/domain/OSInfluenceChannel;Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(influenceChannel);
				GC.KeepAlive(influenceType);
				GC.KeepAlive(ids);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe OSInfluence(string jsonString)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(jsonString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("copy", "()Lcom/onesignal/influence/domain/OSInfluence;", "")]
		public unsafe OSInfluence Copy()
		{
			return Java.Lang.Object.GetObject<OSInfluence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.()Lcom/onesignal/influence/domain/OSInfluence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("toJSONString", "()Ljava/lang/String;", "")]
		public unsafe string ToJSONString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toJSONString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/influence/domain/OSInfluenceChannel", DoNotGenerateAcw = true)]
	public sealed class OSInfluenceChannel : Java.Lang.Enum
	{
		[Register("com/onesignal/influence/domain/OSInfluenceChannel$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/domain/OSInfluenceChannel$Companion", typeof(Companion));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("fromString", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", "")]
			public unsafe OSInfluenceChannel FromString(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fromString.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/domain/OSInfluenceChannel", typeof(OSInfluenceChannel));

		[Register("IAM")]
		public static OSInfluenceChannel Iam => Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.StaticFields.GetObjectValue("IAM.Lcom/onesignal/influence/domain/OSInfluenceChannel;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NOTIFICATION")]
		public static OSInfluenceChannel Notification => Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.StaticFields.GetObjectValue("NOTIFICATION.Lcom/onesignal/influence/domain/OSInfluenceChannel;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSInfluenceChannel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("equalsName", "(Ljava/lang/String;)Z", "")]
		public unsafe bool EqualsName(string otherName)
		{
			IntPtr intPtr = JNIEnv.NewString(otherName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equalsName.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("fromString", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", "")]
		public unsafe static OSInfluenceChannel FromString(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.StaticMethods.InvokeObjectMethod("fromString.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", "")]
		public unsafe static OSInfluenceChannel ValueOf(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceChannel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/onesignal/influence/domain/OSInfluenceChannel;", "")]
		public unsafe static OSInfluenceChannel[] Values()
		{
			return (OSInfluenceChannel[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/influence/domain/OSInfluenceChannel;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OSInfluenceChannel));
		}
	}
	[Register("com/onesignal/influence/domain/OSInfluenceType", DoNotGenerateAcw = true)]
	public sealed class OSInfluenceType : Java.Lang.Enum
	{
		[Register("com/onesignal/influence/domain/OSInfluenceType$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/domain/OSInfluenceType$Companion", typeof(Companion));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("fromString", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
			public unsafe OSInfluenceType FromString(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("fromString.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/domain/OSInfluenceType", typeof(OSInfluenceType));

		[Register("DIRECT")]
		public static OSInfluenceType Direct => Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticFields.GetObjectValue("DIRECT.Lcom/onesignal/influence/domain/OSInfluenceType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DISABLED")]
		public static OSInfluenceType Disabled => Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticFields.GetObjectValue("DISABLED.Lcom/onesignal/influence/domain/OSInfluenceType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INDIRECT")]
		public static OSInfluenceType Indirect => Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticFields.GetObjectValue("INDIRECT.Lcom/onesignal/influence/domain/OSInfluenceType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNATTRIBUTED")]
		public static OSInfluenceType Unattributed => Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticFields.GetObjectValue("UNATTRIBUTED.Lcom/onesignal/influence/domain/OSInfluenceType;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool IsAttributed
		{
			[Register("isAttributed", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isAttributed.()Z", this, null);
			}
		}

		public unsafe bool IsDirect
		{
			[Register("isDirect", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDirect.()Z", this, null);
			}
		}

		public unsafe bool IsDisabled
		{
			[Register("isDisabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDisabled.()Z", this, null);
			}
		}

		public unsafe bool IsIndirect
		{
			[Register("isIndirect", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isIndirect.()Z", this, null);
			}
		}

		public unsafe bool IsUnattributed
		{
			[Register("isUnattributed", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isUnattributed.()Z", this, null);
			}
		}

		internal OSInfluenceType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fromString", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
		public unsafe static OSInfluenceType FromString(string value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticMethods.InvokeObjectMethod("fromString.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
		public unsafe static OSInfluenceType ValueOf(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/influence/domain/OSInfluenceType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
		public unsafe static OSInfluenceType[] Values()
		{
			return (OSInfluenceType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/influence/domain/OSInfluenceType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OSInfluenceType));
		}
	}
}
namespace Com.Onesignal.Influence.Data
{
	[Register("com/onesignal/influence/data/OSChannelTracker", DoNotGenerateAcw = true)]
	public abstract class OSChannelTracker : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/data/OSChannelTracker", typeof(OSChannelTracker));

		private static Delegate cb_getChannelLimit;

		private static Delegate cb_getChannelType;

		private static Delegate cb_getIdTag;

		private static Delegate cb_getIndirectAttributionWindow;

		private static Delegate cb_getLastChannelObjects;

		private static Delegate cb_addSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_;

		private static Delegate cb_cacheState;

		private static Delegate cb_getLastChannelObjectsReceivedByNewId_Ljava_lang_String_;

		private static Delegate cb_initInfluencedTypeFromCache;

		private static Delegate cb_saveChannelObjects_Lorg_json_JSONArray_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract int ChannelLimit
		{
			[Register("getChannelLimit", "()I", "GetGetChannelLimitHandler")]
			get;
		}

		public abstract OSInfluenceChannel ChannelType
		{
			[Register("getChannelType", "()Lcom/onesignal/influence/domain/OSInfluenceChannel;", "GetGetChannelTypeHandler")]
			get;
		}

		public unsafe OSInfluence CurrentSessionInfluence
		{
			[Register("getCurrentSessionInfluence", "()Lcom/onesignal/influence/domain/OSInfluence;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCurrentSessionInfluence.()Lcom/onesignal/influence/domain/OSInfluence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe OSInfluenceDataRepository DataRepository
		{
			[Register("getDataRepository", "()Lcom/onesignal/influence/data/OSInfluenceDataRepository;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceDataRepository>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDataRepository.()Lcom/onesignal/influence/data/OSInfluenceDataRepository;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDataRepository", "(Lcom/onesignal/influence/data/OSInfluenceDataRepository;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDataRepository.(Lcom/onesignal/influence/data/OSInfluenceDataRepository;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string DirectId
		{
			[Register("getDirectId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDirectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDirectId", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDirectId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public abstract string IdTag
		{
			[Register("getIdTag", "()Ljava/lang/String;", "GetGetIdTagHandler")]
			get;
		}

		public abstract int IndirectAttributionWindow
		{
			[Register("getIndirectAttributionWindow", "()I", "GetGetIndirectAttributionWindowHandler")]
			get;
		}

		public unsafe JSONArray IndirectIds
		{
			[Register("getIndirectIds", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIndirectIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIndirectIds", "(Lorg/json/JSONArray;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIndirectIds.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe OSInfluenceType InfluenceType
		{
			[Register("getInfluenceType", "()Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInfluenceType.()Lcom/onesignal/influence/domain/OSInfluenceType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setInfluenceType", "(Lcom/onesignal/influence/domain/OSInfluenceType;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInfluenceType.(Lcom/onesignal/influence/domain/OSInfluenceType;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public abstract JSONArray LastChannelObjects
		{
			[Register("getLastChannelObjects", "()Lorg/json/JSONArray;", "GetGetLastChannelObjectsHandler")]
			get;
		}

		public unsafe JSONArray LastReceivedIds
		{
			[Register("getLastReceivedIds", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastReceivedIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IOSLogger Logger
		{
			[Register("getLogger", "()Lcom/onesignal/OSLogger;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IOSLogger>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLogger.()Lcom/onesignal/OSLogger;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLogger", "(Lcom/onesignal/OSLogger;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLogger.(Lcom/onesignal/OSLogger;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected OSChannelTracker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetChannelLimitHandler()
		{
			if ((object)cb_getChannelLimit == null)
			{
				cb_getChannelLimit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetChannelLimit));
			}
			return cb_getChannelLimit;
		}

		private static int n_GetChannelLimit(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSChannelTracker.ChannelLimit;
		}

		private static Delegate GetGetChannelTypeHandler()
		{
			if ((object)cb_getChannelType == null)
			{
				cb_getChannelType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetChannelType));
			}
			return cb_getChannelType;
		}

		private static IntPtr n_GetChannelType(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSChannelTracker.ChannelType);
		}

		private static Delegate GetGetIdTagHandler()
		{
			if ((object)cb_getIdTag == null)
			{
				cb_getIdTag = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIdTag));
			}
			return cb_getIdTag;
		}

		private static IntPtr n_GetIdTag(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSChannelTracker.IdTag);
		}

		private static Delegate GetGetIndirectAttributionWindowHandler()
		{
			if ((object)cb_getIndirectAttributionWindow == null)
			{
				cb_getIndirectAttributionWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetIndirectAttributionWindow));
			}
			return cb_getIndirectAttributionWindow;
		}

		private static int n_GetIndirectAttributionWindow(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSChannelTracker.IndirectAttributionWindow;
		}

		private static Delegate GetGetLastChannelObjectsHandler()
		{
			if ((object)cb_getLastChannelObjects == null)
			{
				cb_getLastChannelObjects = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastChannelObjects));
			}
			return cb_getLastChannelObjects;
		}

		private static IntPtr n_GetLastChannelObjects(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSChannelTracker.LastChannelObjects);
		}

		private static Delegate GetAddSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_Handler()
		{
			if ((object)cb_addSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_ == null)
			{
				cb_addSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_));
			}
			return cb_addSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_;
		}

		private static void n_AddSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_(IntPtr jnienv, IntPtr native__this, IntPtr native_jsonObject, IntPtr native_influence)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject jsonObject = Java.Lang.Object.GetObject<JSONObject>(native_jsonObject, JniHandleOwnership.DoNotTransfer);
			OSInfluence influence = Java.Lang.Object.GetObject<OSInfluence>(native_influence, JniHandleOwnership.DoNotTransfer);
			oSChannelTracker.AddSessionData(jsonObject, influence);
		}

		[Register("addSessionData", "(Lorg/json/JSONObject;Lcom/onesignal/influence/domain/OSInfluence;)V", "GetAddSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_Handler")]
		public abstract void AddSessionData(JSONObject jsonObject, OSInfluence influence);

		private static Delegate GetCacheStateHandler()
		{
			if ((object)cb_cacheState == null)
			{
				cb_cacheState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CacheState));
			}
			return cb_cacheState;
		}

		private static void n_CacheState(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSChannelTracker.CacheState();
		}

		[Register("cacheState", "()V", "GetCacheStateHandler")]
		public abstract void CacheState();

		private static Delegate GetGetLastChannelObjectsReceivedByNewId_Ljava_lang_String_Handler()
		{
			if ((object)cb_getLastChannelObjectsReceivedByNewId_Ljava_lang_String_ == null)
			{
				cb_getLastChannelObjectsReceivedByNewId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLastChannelObjectsReceivedByNewId_Ljava_lang_String_));
			}
			return cb_getLastChannelObjectsReceivedByNewId_Ljava_lang_String_;
		}

		private static IntPtr n_GetLastChannelObjectsReceivedByNewId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSChannelTracker.GetLastChannelObjectsReceivedByNewId(id));
		}

		[Register("getLastChannelObjectsReceivedByNewId", "(Ljava/lang/String;)Lorg/json/JSONArray;", "GetGetLastChannelObjectsReceivedByNewId_Ljava_lang_String_Handler")]
		public abstract JSONArray GetLastChannelObjectsReceivedByNewId(string id);

		private static Delegate GetInitInfluencedTypeFromCacheHandler()
		{
			if ((object)cb_initInfluencedTypeFromCache == null)
			{
				cb_initInfluencedTypeFromCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InitInfluencedTypeFromCache));
			}
			return cb_initInfluencedTypeFromCache;
		}

		private static void n_InitInfluencedTypeFromCache(IntPtr jnienv, IntPtr native__this)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSChannelTracker.InitInfluencedTypeFromCache();
		}

		[Register("initInfluencedTypeFromCache", "()V", "GetInitInfluencedTypeFromCacheHandler")]
		public abstract void InitInfluencedTypeFromCache();

		[Register("resetAndInitInfluence", "()V", "")]
		public unsafe void ResetAndInitInfluence()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("resetAndInitInfluence.()V", this, null);
		}

		private static Delegate GetSaveChannelObjects_Lorg_json_JSONArray_Handler()
		{
			if ((object)cb_saveChannelObjects_Lorg_json_JSONArray_ == null)
			{
				cb_saveChannelObjects_Lorg_json_JSONArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SaveChannelObjects_Lorg_json_JSONArray_));
			}
			return cb_saveChannelObjects_Lorg_json_JSONArray_;
		}

		private static void n_SaveChannelObjects_Lorg_json_JSONArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_channelObjects)
		{
			OSChannelTracker oSChannelTracker = Java.Lang.Object.GetObject<OSChannelTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONArray channelObjects = Java.Lang.Object.GetObject<JSONArray>(native_channelObjects, JniHandleOwnership.DoNotTransfer);
			oSChannelTracker.SaveChannelObjects(channelObjects);
		}

		[Register("saveChannelObjects", "(Lorg/json/JSONArray;)V", "GetSaveChannelObjects_Lorg_json_JSONArray_Handler")]
		public abstract void SaveChannelObjects(JSONArray channelObjects);

		[Register("saveLastId", "(Ljava/lang/String;)V", "")]
		public unsafe void SaveLastId(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("saveLastId.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/onesignal/influence/data/OSChannelTracker", DoNotGenerateAcw = true)]
	internal class OSChannelTrackerInvoker : OSChannelTracker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/data/OSChannelTracker", typeof(OSChannelTrackerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int ChannelLimit
		{
			[Register("getChannelLimit", "()I", "GetGetChannelLimitHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getChannelLimit.()I", this, null);
			}
		}

		public unsafe override OSInfluenceChannel ChannelType
		{
			[Register("getChannelType", "()Lcom/onesignal/influence/domain/OSInfluenceChannel;", "GetGetChannelTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceChannel>(_members.InstanceMethods.InvokeAbstractObjectMethod("getChannelType.()Lcom/onesignal/influence/domain/OSInfluenceChannel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string IdTag
		{
			[Register("getIdTag", "()Ljava/lang/String;", "GetGetIdTagHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getIdTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int IndirectAttributionWindow
		{
			[Register("getIndirectAttributionWindow", "()I", "GetGetIndirectAttributionWindowHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getIndirectAttributionWindow.()I", this, null);
			}
		}

		public unsafe override JSONArray LastChannelObjects
		{
			[Register("getLastChannelObjects", "()Lorg/json/JSONArray;", "GetGetLastChannelObjectsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLastChannelObjects.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public OSChannelTrackerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addSessionData", "(Lorg/json/JSONObject;Lcom/onesignal/influence/domain/OSInfluence;)V", "GetAddSessionData_Lorg_json_JSONObject_Lcom_onesignal_influence_domain_OSInfluence_Handler")]
		public unsafe override void AddSessionData(JSONObject jsonObject, OSInfluence influence)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(jsonObject?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(influence?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addSessionData.(Lorg/json/JSONObject;Lcom/onesignal/influence/domain/OSInfluence;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(jsonObject);
				GC.KeepAlive(influence);
			}
		}

		[Register("cacheState", "()V", "GetCacheStateHandler")]
		public unsafe override void CacheState()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cacheState.()V", this, null);
		}

		[Register("getLastChannelObjectsReceivedByNewId", "(Ljava/lang/String;)Lorg/json/JSONArray;", "GetGetLastChannelObjectsReceivedByNewId_Ljava_lang_String_Handler")]
		public unsafe override JSONArray GetLastChannelObjectsReceivedByNewId(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLastChannelObjectsReceivedByNewId.(Ljava/lang/String;)Lorg/json/JSONArray;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("initInfluencedTypeFromCache", "()V", "GetInitInfluencedTypeFromCacheHandler")]
		public unsafe override void InitInfluencedTypeFromCache()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("initInfluencedTypeFromCache.()V", this, null);
		}

		[Register("saveChannelObjects", "(Lorg/json/JSONArray;)V", "GetSaveChannelObjects_Lorg_json_JSONArray_Handler")]
		public unsafe override void SaveChannelObjects(JSONArray channelObjects)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(channelObjects?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("saveChannelObjects.(Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(channelObjects);
			}
		}
	}
	[Register("com/onesignal/influence/data/OSInfluenceDataRepository", DoNotGenerateAcw = true)]
	public sealed class OSInfluenceDataRepository : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/data/OSInfluenceDataRepository", typeof(OSInfluenceDataRepository));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe string CachedNotificationOpenId
		{
			[Register("getCachedNotificationOpenId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCachedNotificationOpenId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSInfluenceType IamCachedInfluenceType
		{
			[Register("getIamCachedInfluenceType", "()Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIamCachedInfluenceType.()Lcom/onesignal/influence/domain/OSInfluenceType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int IamIndirectAttributionWindow
		{
			[Register("getIamIndirectAttributionWindow", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getIamIndirectAttributionWindow.()I", this, null);
			}
		}

		public unsafe int IamLimit
		{
			[Register("getIamLimit", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getIamLimit.()I", this, null);
			}
		}

		public unsafe bool IsDirectInfluenceEnabled
		{
			[Register("isDirectInfluenceEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isDirectInfluenceEnabled.()Z", this, null);
			}
		}

		public unsafe bool IsIndirectInfluenceEnabled
		{
			[Register("isIndirectInfluenceEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isIndirectInfluenceEnabled.()Z", this, null);
			}
		}

		public unsafe bool IsUnattributedInfluenceEnabled
		{
			[Register("isUnattributedInfluenceEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isUnattributedInfluenceEnabled.()Z", this, null);
			}
		}

		public unsafe JSONArray LastIAMsReceivedData
		{
			[Register("getLastIAMsReceivedData", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastIAMsReceivedData.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe JSONArray LastNotificationsReceivedData
		{
			[Register("getLastNotificationsReceivedData", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastNotificationsReceivedData.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSInfluenceType NotificationCachedInfluenceType
		{
			[Register("getNotificationCachedInfluenceType", "()Lcom/onesignal/influence/domain/OSInfluenceType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNotificationCachedInfluenceType.()Lcom/onesignal/influence/domain/OSInfluenceType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int NotificationIndirectAttributionWindow
		{
			[Register("getNotificationIndirectAttributionWindow", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getNotificationIndirectAttributionWindow.()I", this, null);
			}
		}

		public unsafe int NotificationLimit
		{
			[Register("getNotificationLimit", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getNotificationLimit.()I", this, null);
			}
		}

		internal OSInfluenceDataRepository(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSharedPreferences;)V", "")]
		public unsafe OSInfluenceDataRepository(IOSSharedPreferences preferences)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((preferences == null) ? IntPtr.Zero : ((Java.Lang.Object)preferences).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSharedPreferences;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(preferences);
			}
		}

		[Register("cacheIAMInfluenceType", "(Lcom/onesignal/influence/domain/OSInfluenceType;)V", "")]
		public unsafe void CacheIAMInfluenceType(OSInfluenceType influenceType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(influenceType?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("cacheIAMInfluenceType.(Lcom/onesignal/influence/domain/OSInfluenceType;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(influenceType);
			}
		}

		[Register("cacheNotificationInfluenceType", "(Lcom/onesignal/influence/domain/OSInfluenceType;)V", "")]
		public unsafe void CacheNotificationInfluenceType(OSInfluenceType influenceType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(influenceType?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("cacheNotificationInfluenceType.(Lcom/onesignal/influence/domain/OSInfluenceType;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(influenceType);
			}
		}

		[Register("cacheNotificationOpenId", "(Ljava/lang/String;)V", "")]
		public unsafe void CacheNotificationOpenId(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("cacheNotificationOpenId.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("saveIAMs", "(Lorg/json/JSONArray;)V", "")]
		public unsafe void SaveIAMs(JSONArray iams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(iams?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("saveIAMs.(Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(iams);
			}
		}

		[Register("saveInfluenceParams", "(Lcom/onesignal/OneSignalRemoteParams$InfluenceParams;)V", "")]
		public unsafe void SaveInfluenceParams(OneSignalRemoteParams.InfluenceParams influenceParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(influenceParams?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("saveInfluenceParams.(Lcom/onesignal/OneSignalRemoteParams$InfluenceParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(influenceParams);
			}
		}

		[Register("saveNotifications", "(Lorg/json/JSONArray;)V", "")]
		public unsafe void SaveNotifications(JSONArray notifications)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(notifications?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("saveNotifications.(Lorg/json/JSONArray;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notifications);
			}
		}
	}
	[Register("com/onesignal/influence/data/OSTrackerFactory", DoNotGenerateAcw = true)]
	public sealed class OSTrackerFactory : Java.Lang.Object
	{
		[Register("com/onesignal/influence/data/OSTrackerFactory$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/data/OSTrackerFactory$WhenMappings", typeof(WhenMappings));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/influence/data/OSTrackerFactory", typeof(OSTrackerFactory));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe IList<OSChannelTracker> Channels
		{
			[Register("getChannels", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<OSChannelTracker>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChannels.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSChannelTracker IAMChannelTracker
		{
			[Register("getIAMChannelTracker", "()Lcom/onesignal/influence/data/OSChannelTracker;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSChannelTracker>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIAMChannelTracker.()Lcom/onesignal/influence/data/OSChannelTracker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<OSInfluence> Influences
		{
			[Register("getInfluences", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<OSInfluence>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInfluences.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OSChannelTracker NotificationChannelTracker
		{
			[Register("getNotificationChannelTracker", "()Lcom/onesignal/influence/data/OSChannelTracker;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSChannelTracker>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNotificationChannelTracker.()Lcom/onesignal/influence/data/OSChannelTracker;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<OSInfluence> SessionInfluences
		{
			[Register("getSessionInfluences", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<OSInfluence>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSessionInfluences.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal OSTrackerFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSharedPreferences;Lcom/onesignal/OSLogger;Lcom/onesignal/OSTime;)V", "")]
		public unsafe OSTrackerFactory(IOSSharedPreferences preferences, IOSLogger logger, IOSTime timeProvider)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((preferences == null) ? IntPtr.Zero : ((Java.Lang.Object)preferences).Handle);
				ptr[1] = new JniArgumentValue((logger == null) ? IntPtr.Zero : ((Java.Lang.Object)logger).Handle);
				ptr[2] = new JniArgumentValue((timeProvider == null) ? IntPtr.Zero : ((Java.Lang.Object)timeProvider).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSharedPreferences;Lcom/onesignal/OSLogger;Lcom/onesignal/OSTime;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSharedPreferences;Lcom/onesignal/OSLogger;Lcom/onesignal/OSTime;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(preferences);
				GC.KeepAlive(logger);
				GC.KeepAlive(timeProvider);
			}
		}

		[Register("addSessionData", "(Lorg/json/JSONObject;Ljava/util/List;)V", "")]
		public unsafe void AddSessionData(JSONObject jsonObject, IList<OSInfluence> influences)
		{
			IntPtr intPtr = JavaList<OSInfluence>.ToLocalJniHandle(influences);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(jsonObject?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addSessionData.(Lorg/json/JSONObject;Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(jsonObject);
				GC.KeepAlive(influences);
			}
		}

		[Register("getChannelByEntryAction", "(Lcom/onesignal/OneSignal$AppEntryAction;)Lcom/onesignal/influence/data/OSChannelTracker;", "")]
		public unsafe OSChannelTracker GetChannelByEntryAction(Com.OneSignal.Android.OneSignal.AppEntryAction entryAction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(entryAction?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OSChannelTracker>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChannelByEntryAction.(Lcom/onesignal/OneSignal$AppEntryAction;)Lcom/onesignal/influence/data/OSChannelTracker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(entryAction);
			}
		}

		[Register("getChannelsToResetByEntryAction", "(Lcom/onesignal/OneSignal$AppEntryAction;)Ljava/util/List;", "")]
		public unsafe IList<OSChannelTracker> GetChannelsToResetByEntryAction(Com.OneSignal.Android.OneSignal.AppEntryAction entryAction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(entryAction?.Handle ?? IntPtr.Zero);
				return JavaList<OSChannelTracker>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChannelsToResetByEntryAction.(Lcom/onesignal/OneSignal$AppEntryAction;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(entryAction);
			}
		}

		[Register("initFromCache", "()V", "")]
		public unsafe void InitFromCache()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("initFromCache.()V", this, null);
		}

		[Register("saveInfluenceParams", "(Lcom/onesignal/OneSignalRemoteParams$InfluenceParams;)V", "")]
		public unsafe void SaveInfluenceParams(OneSignalRemoteParams.InfluenceParams influenceParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(influenceParams?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("saveInfluenceParams.(Lcom/onesignal/OneSignalRemoteParams$InfluenceParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(influenceParams);
			}
		}
	}
}
namespace Com.OneSignal.Android
{
	[Register("com/onesignal/AlertDialogPrepromptForAndroidSettings", DoNotGenerateAcw = true)]
	public sealed class AlertDialogPrepromptForAndroidSettings : Java.Lang.Object
	{
		[Register("com/onesignal/AlertDialogPrepromptForAndroidSettings$Callback", "", "Com.OneSignal.Android.AlertDialogPrepromptForAndroidSettings/ICallbackInvoker")]
		public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onAccept", "()V", "GetOnAcceptHandler:Com.OneSignal.Android.AlertDialogPrepromptForAndroidSettings/ICallbackInvoker, OneSignal.Android.Binding")]
			void OnAccept();

			[Register("onDecline", "()V", "GetOnDeclineHandler:Com.OneSignal.Android.AlertDialogPrepromptForAndroidSettings/ICallbackInvoker, OneSignal.Android.Binding")]
			void OnDecline();
		}

		[Register("com/onesignal/AlertDialogPrepromptForAndroidSettings$Callback", DoNotGenerateAcw = true)]
		internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/AlertDialogPrepromptForAndroidSettings$Callback", typeof(ICallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onAccept;

			private IntPtr id_onAccept;

			private static Delegate cb_onDecline;

			private IntPtr id_onDecline;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static ICallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.AlertDialogPrepromptForAndroidSettings.Callback'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public ICallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnAcceptHandler()
			{
				if ((object)cb_onAccept == null)
				{
					cb_onAccept = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnAccept));
				}
				return cb_onAccept;
			}

			private static void n_OnAccept(IntPtr jnienv, IntPtr native__this)
			{
				ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				callback.OnAccept();
			}

			public void OnAccept()
			{
				if (id_onAccept == IntPtr.Zero)
				{
					id_onAccept = JNIEnv.GetMethodID(class_ref, "onAccept", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onAccept);
			}

			private static Delegate GetOnDeclineHandler()
			{
				if ((object)cb_onDecline == null)
				{
					cb_onDecline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDecline));
				}
				return cb_onDecline;
			}

			private static void n_OnDecline(IntPtr jnienv, IntPtr native__this)
			{
				ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				callback.OnDecline();
			}

			public void OnDecline()
			{
				if (id_onDecline == IntPtr.Zero)
				{
					id_onDecline = JNIEnv.GetMethodID(class_ref, "onDecline", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onDecline);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/AlertDialogPrepromptForAndroidSettings", typeof(AlertDialogPrepromptForAndroidSettings));

		[Register("INSTANCE")]
		public static AlertDialogPrepromptForAndroidSettings Instance => Java.Lang.Object.GetObject<AlertDialogPrepromptForAndroidSettings>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/AlertDialogPrepromptForAndroidSettings;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal AlertDialogPrepromptForAndroidSettings(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("show", "(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/AlertDialogPrepromptForAndroidSettings$Callback;)V", "")]
		public unsafe void Show(Activity activity, string titlePrefix, string previouslyDeniedPostfix, ICallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(titlePrefix);
			IntPtr intPtr2 = JNIEnv.NewString(previouslyDeniedPostfix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("show.(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/AlertDialogPrepromptForAndroidSettings$Callback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(activity);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/onesignal/BootUpReceiver", DoNotGenerateAcw = true)]
	public class BootUpReceiver : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/BootUpReceiver", typeof(BootUpReceiver));

		private static Delegate cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected BootUpReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BootUpReceiver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnReceive_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_intent)
		{
			BootUpReceiver bootUpReceiver = Java.Lang.Object.GetObject<BootUpReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			bootUpReceiver.OnReceive(context, intent);
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void OnReceive(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/onesignal/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.onesignal";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/BuildConfig", typeof(BuildConfig));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal BuildConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BuildConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/FCMIntentJobService", DoNotGenerateAcw = true)]
	public class FCMIntentJobService : Service
	{
		[Register("BUNDLE_EXTRA")]
		public const string BundleExtra = "Bundle:Parcelable:Extras";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/FCMIntentJobService", typeof(FCMIntentJobService));

		private static Delegate cb_isStopped;

		private static Delegate cb_onBind_Landroid_content_Intent_;

		private static Delegate cb_onCreate;

		private static Delegate cb_onDestroy;

		private static Delegate cb_onHandleWork_Landroid_content_Intent_;

		private static Delegate cb_onStartCommand_Landroid_content_Intent_II;

		private static Delegate cb_onStopCurrentWork;

		private static Delegate cb_setInterruptIfStopped_Z;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsStopped
		{
			[Register("isStopped", "()Z", "GetIsStoppedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStopped.()Z", this, null);
			}
		}

		protected FCMIntentJobService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FCMIntentJobService()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsStoppedHandler()
		{
			if ((object)cb_isStopped == null)
			{
				cb_isStopped = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStopped));
			}
			return cb_isStopped;
		}

		private static bool n_IsStopped(IntPtr jnienv, IntPtr native__this)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return fCMIntentJobService.IsStopped;
		}

		[Register("enqueueWork", "(Landroid/content/Context;Landroid/content/Intent;)V", "")]
		public unsafe static void EnqueueWork(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("enqueueWork.(Landroid/content/Context;Landroid/content/Intent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}

		private static Delegate GetOnBind_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onBind_Landroid_content_Intent_ == null)
			{
				cb_onBind_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnBind_Landroid_content_Intent_));
			}
			return cb_onBind_Landroid_content_Intent_;
		}

		private static IntPtr n_OnBind_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fCMIntentJobService.OnBind(intent));
		}

		[Register("onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;", "GetOnBind_Landroid_content_Intent_Handler")]
		public unsafe override IBinder OnBind(Intent p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IBinder>(_members.InstanceMethods.InvokeVirtualObjectMethod("onBind.(Landroid/content/Intent;)Landroid/os/IBinder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnCreateHandler()
		{
			if ((object)cb_onCreate == null)
			{
				cb_onCreate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCreate));
			}
			return cb_onCreate;
		}

		private static void n_OnCreate(IntPtr jnienv, IntPtr native__this)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			fCMIntentJobService.OnCreate();
		}

		[Register("onCreate", "()V", "GetOnCreateHandler")]
		public unsafe override void OnCreate()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.()V", this, null);
		}

		private static Delegate GetOnDestroyHandler()
		{
			if ((object)cb_onDestroy == null)
			{
				cb_onDestroy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDestroy));
			}
			return cb_onDestroy;
		}

		private static void n_OnDestroy(IntPtr jnienv, IntPtr native__this)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			fCMIntentJobService.OnDestroy();
		}

		[Register("onDestroy", "()V", "GetOnDestroyHandler")]
		public unsafe override void OnDestroy()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
		}

		private static Delegate GetOnHandleWork_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onHandleWork_Landroid_content_Intent_ == null)
			{
				cb_onHandleWork_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnHandleWork_Landroid_content_Intent_));
			}
			return cb_onHandleWork_Landroid_content_Intent_;
		}

		private static void n_OnHandleWork_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			fCMIntentJobService.OnHandleWork(intent);
		}

		[Register("onHandleWork", "(Landroid/content/Intent;)V", "GetOnHandleWork_Landroid_content_Intent_Handler")]
		protected unsafe virtual void OnHandleWork(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onHandleWork.(Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		private static Delegate GetOnStartCommand_Landroid_content_Intent_IIHandler()
		{
			if ((object)cb_onStartCommand_Landroid_content_Intent_II == null)
			{
				cb_onStartCommand_Landroid_content_Intent_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_I(n_OnStartCommand_Landroid_content_Intent_II));
			}
			return cb_onStartCommand_Landroid_content_Intent_II;
		}

		private static int n_OnStartCommand_Landroid_content_Intent_II(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int native_p1, int p2)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return (int)fCMIntentJobService.OnStartCommand(intent, (StartCommandFlags)native_p1, p2);
		}

		[Register("onStartCommand", "(Landroid/content/Intent;II)I", "GetOnStartCommand_Landroid_content_Intent_IIHandler")]
		public unsafe override StartCommandResult OnStartCommand(Intent p0, [GeneratedEnum] StartCommandFlags p1, int p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)p1);
				ptr[2] = new JniArgumentValue(p2);
				return (StartCommandResult)_members.InstanceMethods.InvokeVirtualInt32Method("onStartCommand.(Landroid/content/Intent;II)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnStopCurrentWorkHandler()
		{
			if ((object)cb_onStopCurrentWork == null)
			{
				cb_onStopCurrentWork = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_OnStopCurrentWork));
			}
			return cb_onStopCurrentWork;
		}

		private static bool n_OnStopCurrentWork(IntPtr jnienv, IntPtr native__this)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return fCMIntentJobService.OnStopCurrentWork();
		}

		[Register("onStopCurrentWork", "()Z", "GetOnStopCurrentWorkHandler")]
		public unsafe virtual bool OnStopCurrentWork()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStopCurrentWork.()Z", this, null);
		}

		private static Delegate GetSetInterruptIfStopped_ZHandler()
		{
			if ((object)cb_setInterruptIfStopped_Z == null)
			{
				cb_setInterruptIfStopped_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetInterruptIfStopped_Z));
			}
			return cb_setInterruptIfStopped_Z;
		}

		private static void n_SetInterruptIfStopped_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			FCMIntentJobService fCMIntentJobService = Java.Lang.Object.GetObject<FCMIntentJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			fCMIntentJobService.SetInterruptIfStopped(p0);
		}

		[Register("setInterruptIfStopped", "(Z)V", "GetSetInterruptIfStopped_ZHandler")]
		public unsafe virtual void SetInterruptIfStopped(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterruptIfStopped.(Z)V", this, ptr);
		}

		[Register("enqueueWork", "(Landroid/content/Context;Landroid/content/ComponentName;ILandroid/content/Intent;Z)V", "")]
		public unsafe static void EnqueueWork(Context context, ComponentName component, int jobId, Intent work, bool useWakefulService)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(component?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(jobId);
				ptr[3] = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(useWakefulService);
				_members.StaticMethods.InvokeVoidMethod("enqueueWork.(Landroid/content/Context;Landroid/content/ComponentName;ILandroid/content/Intent;Z)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(component);
				GC.KeepAlive(work);
			}
		}

		[Register("enqueueWork", "(Landroid/content/Context;Ljava/lang/Class;ILandroid/content/Intent;Z)V", "")]
		public unsafe static void EnqueueWork(Context context, Class cls, int jobId, Intent work, bool useWakefulService)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(cls?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(jobId);
				ptr[3] = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(useWakefulService);
				_members.StaticMethods.InvokeVoidMethod("enqueueWork.(Landroid/content/Context;Ljava/lang/Class;ILandroid/content/Intent;Z)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(cls);
				GC.KeepAlive(work);
			}
		}
	}
	[Register("com/onesignal/GenerateNotificationOpenIntent", DoNotGenerateAcw = true)]
	public sealed class GenerateNotificationOpenIntent : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/GenerateNotificationOpenIntent", typeof(GenerateNotificationOpenIntent));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Intent IntentVisible
		{
			[Register("getIntentVisible", "()Landroid/content/Intent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getIntentVisible.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal GenerateNotificationOpenIntent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/content/Intent;Z)V", "")]
		public unsafe GenerateNotificationOpenIntent(Context context, Intent intent, bool startApp)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(startApp);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/content/Intent;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/content/Intent;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/onesignal/GenerateNotificationOpenIntentFromPushPayload", DoNotGenerateAcw = true)]
	public sealed class GenerateNotificationOpenIntentFromPushPayload : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/GenerateNotificationOpenIntentFromPushPayload", typeof(GenerateNotificationOpenIntentFromPushPayload));

		[Register("INSTANCE")]
		public static GenerateNotificationOpenIntentFromPushPayload Instance => Java.Lang.Object.GetObject<GenerateNotificationOpenIntentFromPushPayload>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/GenerateNotificationOpenIntentFromPushPayload;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GenerateNotificationOpenIntentFromPushPayload(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("create", "(Landroid/content/Context;Lorg/json/JSONObject;)Lcom/onesignal/GenerateNotificationOpenIntent;", "")]
		public unsafe GenerateNotificationOpenIntent Create(Context context, JSONObject fcmPayload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fcmPayload?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GenerateNotificationOpenIntent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("create.(Landroid/content/Context;Lorg/json/JSONObject;)Lcom/onesignal/GenerateNotificationOpenIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(fcmPayload);
			}
		}
	}
	[Register("com/onesignal/BundleCompat", "", "Com.OneSignal.Android.IBundleCompatInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IBundleCompat : IJavaObject, IDisposable, IJavaPeerable
	{
		Java.Lang.Object Bundle
		{
			[Register("getBundle", "()Ljava/lang/Object;", "GetGetBundleHandler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
			get;
		}

		[Register("containsKey", "(Ljava/lang/String;)Z", "GetContainsKey_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		bool ContainsKey(string p0);

		[Register("getBoolean", "(Ljava/lang/String;)Z", "GetGetBoolean_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		bool GetBoolean(string p0);

		[Register("getBoolean", "(Ljava/lang/String;Z)Z", "GetGetBoolean_Ljava_lang_String_ZHandler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		bool GetBoolean(string p0, bool p1);

		[Register("getInt", "(Ljava/lang/String;)Ljava/lang/Integer;", "GetGetInt_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		Integer GetInt(string p0);

		[Register("getLong", "(Ljava/lang/String;)Ljava/lang/Long;", "GetGetLong_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		Long GetLong(string p0);

		[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetString_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		string GetString(string p0);

		[Register("putBoolean", "(Ljava/lang/String;Ljava/lang/Boolean;)V", "GetPutBoolean_Ljava_lang_String_Ljava_lang_Boolean_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		void PutBoolean(string p0, Java.Lang.Boolean p1);

		[Register("putInt", "(Ljava/lang/String;Ljava/lang/Integer;)V", "GetPutInt_Ljava_lang_String_Ljava_lang_Integer_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		void PutInt(string p0, Integer p1);

		[Register("putLong", "(Ljava/lang/String;Ljava/lang/Long;)V", "GetPutLong_Ljava_lang_String_Ljava_lang_Long_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		void PutLong(string p0, Long p1);

		[Register("putString", "(Ljava/lang/String;Ljava/lang/String;)V", "GetPutString_Ljava_lang_String_Ljava_lang_String_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		void PutString(string p0, string p1);

		[Register("setBundle", "(Landroid/os/Parcelable;)V", "GetSetBundle_Landroid_os_Parcelable_Handler:Com.OneSignal.Android.IBundleCompatInvoker, OneSignal.Android.Binding")]
		void SetBundle(IParcelable p0);
	}
	[Register("com/onesignal/BundleCompat", DoNotGenerateAcw = true)]
	internal class IBundleCompatInvoker : Java.Lang.Object, IBundleCompat, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/BundleCompat", typeof(IBundleCompatInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getBundle;

		private IntPtr id_getBundle;

		private static Delegate cb_containsKey_Ljava_lang_String_;

		private IntPtr id_containsKey_Ljava_lang_String_;

		private static Delegate cb_getBoolean_Ljava_lang_String_;

		private IntPtr id_getBoolean_Ljava_lang_String_;

		private static Delegate cb_getBoolean_Ljava_lang_String_Z;

		private IntPtr id_getBoolean_Ljava_lang_String_Z;

		private static Delegate cb_getInt_Ljava_lang_String_;

		private IntPtr id_getInt_Ljava_lang_String_;

		private static Delegate cb_getLong_Ljava_lang_String_;

		private IntPtr id_getLong_Ljava_lang_String_;

		private static Delegate cb_getString_Ljava_lang_String_;

		private IntPtr id_getString_Ljava_lang_String_;

		private static Delegate cb_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_;

		private IntPtr id_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_;

		private static Delegate cb_putInt_Ljava_lang_String_Ljava_lang_Integer_;

		private IntPtr id_putInt_Ljava_lang_String_Ljava_lang_Integer_;

		private static Delegate cb_putLong_Ljava_lang_String_Ljava_lang_Long_;

		private IntPtr id_putLong_Ljava_lang_String_Ljava_lang_Long_;

		private static Delegate cb_putString_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_putString_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_setBundle_Landroid_os_Parcelable_;

		private IntPtr id_setBundle_Landroid_os_Parcelable_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public Java.Lang.Object Bundle
		{
			get
			{
				if (id_getBundle == IntPtr.Zero)
				{
					id_getBundle = JNIEnv.GetMethodID(class_ref, "getBundle", "()Ljava/lang/Object;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getBundle), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IBundleCompat GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBundleCompat>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.BundleCompat'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IBundleCompatInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetBundleHandler()
		{
			if ((object)cb_getBundle == null)
			{
				cb_getBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBundle));
			}
			return cb_getBundle;
		}

		private static IntPtr n_GetBundle(IntPtr jnienv, IntPtr native__this)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bundleCompat.Bundle);
		}

		private static Delegate GetContainsKey_Ljava_lang_String_Handler()
		{
			if ((object)cb_containsKey_Ljava_lang_String_ == null)
			{
				cb_containsKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ContainsKey_Ljava_lang_String_));
			}
			return cb_containsKey_Ljava_lang_String_;
		}

		private static bool n_ContainsKey_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return bundleCompat.ContainsKey(p);
		}

		public unsafe bool ContainsKey(string p0)
		{
			if (id_containsKey_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_containsKey_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "containsKey", "(Ljava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_containsKey_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetBoolean_Ljava_lang_String_Handler()
		{
			if ((object)cb_getBoolean_Ljava_lang_String_ == null)
			{
				cb_getBoolean_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_GetBoolean_Ljava_lang_String_));
			}
			return cb_getBoolean_Ljava_lang_String_;
		}

		private static bool n_GetBoolean_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return bundleCompat.GetBoolean(p);
		}

		public unsafe bool GetBoolean(string p0)
		{
			if (id_getBoolean_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getBoolean_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getBoolean", "(Ljava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_getBoolean_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetBoolean_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_getBoolean_Ljava_lang_String_Z == null)
			{
				cb_getBoolean_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_Z(n_GetBoolean_Ljava_lang_String_Z));
			}
			return cb_getBoolean_Ljava_lang_String_Z;
		}

		private static bool n_GetBoolean_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return bundleCompat.GetBoolean(p2, p1);
		}

		public unsafe bool GetBoolean(string p0, bool p1)
		{
			if (id_getBoolean_Ljava_lang_String_Z == IntPtr.Zero)
			{
				id_getBoolean_Ljava_lang_String_Z = JNIEnv.GetMethodID(class_ref, "getBoolean", "(Ljava/lang/String;Z)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_getBoolean_Ljava_lang_String_Z, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetInt_Ljava_lang_String_Handler()
		{
			if ((object)cb_getInt_Ljava_lang_String_ == null)
			{
				cb_getInt_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetInt_Ljava_lang_String_));
			}
			return cb_getInt_Ljava_lang_String_;
		}

		private static IntPtr n_GetInt_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bundleCompat.GetInt(p));
		}

		public unsafe Integer GetInt(string p0)
		{
			if (id_getInt_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getInt_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getInt", "(Ljava/lang/String;)Ljava/lang/Integer;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Integer result = Java.Lang.Object.GetObject<Integer>(JNIEnv.CallObjectMethod(base.Handle, id_getInt_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetLong_Ljava_lang_String_Handler()
		{
			if ((object)cb_getLong_Ljava_lang_String_ == null)
			{
				cb_getLong_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLong_Ljava_lang_String_));
			}
			return cb_getLong_Ljava_lang_String_;
		}

		private static IntPtr n_GetLong_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bundleCompat.GetLong(p));
		}

		public unsafe Long GetLong(string p0)
		{
			if (id_getLong_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getLong_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getLong", "(Ljava/lang/String;)Ljava/lang/Long;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Long result = Java.Lang.Object.GetObject<Long>(JNIEnv.CallObjectMethod(base.Handle, id_getLong_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetString_Ljava_lang_String_Handler()
		{
			if ((object)cb_getString_Ljava_lang_String_ == null)
			{
				cb_getString_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetString_Ljava_lang_String_));
			}
			return cb_getString_Ljava_lang_String_;
		}

		private static IntPtr n_GetString_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(bundleCompat.GetString(p));
		}

		public unsafe string GetString(string p0)
		{
			if (id_getString_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getString_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getString", "(Ljava/lang/String;)Ljava/lang/String;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			string result = JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getString_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetPutBoolean_Ljava_lang_String_Ljava_lang_Boolean_Handler()
		{
			if ((object)cb_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_ == null)
			{
				cb_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_PutBoolean_Ljava_lang_String_Ljava_lang_Boolean_));
			}
			return cb_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_;
		}

		private static void n_PutBoolean_Ljava_lang_String_Ljava_lang_Boolean_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Boolean p2 = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_p1, JniHandleOwnership.DoNotTransfer);
			bundleCompat.PutBoolean(p, p2);
		}

		public unsafe void PutBoolean(string p0, Java.Lang.Boolean p1)
		{
			if (id_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_ == IntPtr.Zero)
			{
				id_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_ = JNIEnv.GetMethodID(class_ref, "putBoolean", "(Ljava/lang/String;Ljava/lang/Boolean;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_putBoolean_Ljava_lang_String_Ljava_lang_Boolean_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPutInt_Ljava_lang_String_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_putInt_Ljava_lang_String_Ljava_lang_Integer_ == null)
			{
				cb_putInt_Ljava_lang_String_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_PutInt_Ljava_lang_String_Ljava_lang_Integer_));
			}
			return cb_putInt_Ljava_lang_String_Ljava_lang_Integer_;
		}

		private static void n_PutInt_Ljava_lang_String_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Integer p2 = Java.Lang.Object.GetObject<Integer>(native_p1, JniHandleOwnership.DoNotTransfer);
			bundleCompat.PutInt(p, p2);
		}

		public unsafe void PutInt(string p0, Integer p1)
		{
			if (id_putInt_Ljava_lang_String_Ljava_lang_Integer_ == IntPtr.Zero)
			{
				id_putInt_Ljava_lang_String_Ljava_lang_Integer_ = JNIEnv.GetMethodID(class_ref, "putInt", "(Ljava/lang/String;Ljava/lang/Integer;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_putInt_Ljava_lang_String_Ljava_lang_Integer_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPutLong_Ljava_lang_String_Ljava_lang_Long_Handler()
		{
			if ((object)cb_putLong_Ljava_lang_String_Ljava_lang_Long_ == null)
			{
				cb_putLong_Ljava_lang_String_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_PutLong_Ljava_lang_String_Ljava_lang_Long_));
			}
			return cb_putLong_Ljava_lang_String_Ljava_lang_Long_;
		}

		private static void n_PutLong_Ljava_lang_String_Ljava_lang_Long_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Long p2 = Java.Lang.Object.GetObject<Long>(native_p1, JniHandleOwnership.DoNotTransfer);
			bundleCompat.PutLong(p, p2);
		}

		public unsafe void PutLong(string p0, Long p1)
		{
			if (id_putLong_Ljava_lang_String_Ljava_lang_Long_ == IntPtr.Zero)
			{
				id_putLong_Ljava_lang_String_Ljava_lang_Long_ = JNIEnv.GetMethodID(class_ref, "putLong", "(Ljava/lang/String;Ljava/lang/Long;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_putLong_Ljava_lang_String_Ljava_lang_Long_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPutString_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_putString_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_putString_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_PutString_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_putString_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_PutString_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			bundleCompat.PutString(p, p2);
		}

		public unsafe void PutString(string p0, string p1)
		{
			if (id_putString_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_putString_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "putString", "(Ljava/lang/String;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_putString_Ljava_lang_String_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetSetBundle_Landroid_os_Parcelable_Handler()
		{
			if ((object)cb_setBundle_Landroid_os_Parcelable_ == null)
			{
				cb_setBundle_Landroid_os_Parcelable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetBundle_Landroid_os_Parcelable_));
			}
			return cb_setBundle_Landroid_os_Parcelable_;
		}

		private static void n_SetBundle_Landroid_os_Parcelable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBundleCompat bundleCompat = Java.Lang.Object.GetObject<IBundleCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable bundle = Java.Lang.Object.GetObject<IParcelable>(native_p0, JniHandleOwnership.DoNotTransfer);
			bundleCompat.SetBundle(bundle);
		}

		public unsafe void SetBundle(IParcelable p0)
		{
			if (id_setBundle_Landroid_os_Parcelable_ == IntPtr.Zero)
			{
				id_setBundle_Landroid_os_Parcelable_ = JNIEnv.GetMethodID(class_ref, "setBundle", "(Landroid/os/Parcelable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_setBundle_Landroid_os_Parcelable_, ptr);
		}
	}
	[Register("com/onesignal/IntentGeneratorForAttachingToNotifications", DoNotGenerateAcw = true)]
	public sealed class IntentGeneratorForAttachingToNotifications : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/IntentGeneratorForAttachingToNotifications", typeof(IntentGeneratorForAttachingToNotifications));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal IntentGeneratorForAttachingToNotifications(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe IntentGeneratorForAttachingToNotifications(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("getNewActionPendingIntent", "(ILandroid/content/Intent;)Landroid/app/PendingIntent;", "")]
		public unsafe PendingIntent GetNewActionPendingIntent(int requestCode, Intent oneSignalIntent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(oneSignalIntent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNewActionPendingIntent.(ILandroid/content/Intent;)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(oneSignalIntent);
			}
		}

		[Register("getNewBaseIntent", "(I)Landroid/content/Intent;", "")]
		public unsafe Intent GetNewBaseIntent(int notificationId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(notificationId);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNewBaseIntent.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OneSignalAPIClient", "", "Com.OneSignal.Android.IOneSignalAPIClientInvoker")]
	public interface IOneSignalAPIClient : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("get", "(Ljava/lang/String;Lcom/onesignal/OneSignalApiResponseHandler;Ljava/lang/String;)V", "GetGet_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void Get(string p0, IOneSignalApiResponseHandler p1, string p2);

		[Register("getSync", "(Ljava/lang/String;Lcom/onesignal/OneSignalApiResponseHandler;Ljava/lang/String;)V", "GetGetSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void GetSync(string p0, IOneSignalApiResponseHandler p1, string p2);

		[Register("post", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetPost_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void Post(string p0, JSONObject p1, IOneSignalApiResponseHandler p2);

		[Register("postSync", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetPostSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void PostSync(string p0, JSONObject p1, IOneSignalApiResponseHandler p2);

		[Register("put", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetPut_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void Put(string p0, JSONObject p1, IOneSignalApiResponseHandler p2);

		[Register("putSync", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V", "GetPutSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler:Com.OneSignal.Android.IOneSignalAPIClientInvoker, OneSignal.Android.Binding")]
		void PutSync(string p0, JSONObject p1, IOneSignalApiResponseHandler p2);
	}
	[Register("com/onesignal/OneSignalAPIClient", DoNotGenerateAcw = true)]
	internal class IOneSignalAPIClientInvoker : Java.Lang.Object, IOneSignalAPIClient, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalAPIClient", typeof(IOneSignalAPIClientInvoker));

		private IntPtr class_ref;

		private static Delegate cb_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;

		private IntPtr id_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;

		private static Delegate cb_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;

		private IntPtr id_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;

		private static Delegate cb_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static Delegate cb_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static Delegate cb_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static Delegate cb_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private IntPtr id_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOneSignalAPIClient GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOneSignalAPIClient>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignalAPIClient'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOneSignalAPIClientInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGet_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_Handler()
		{
			if ((object)cb_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ == null)
			{
				cb_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_));
			}
			return cb_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;
		}

		private static void n_Get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p2 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.Get(p, p2, p3);
		}

		public unsafe void Get(string p0, IOneSignalApiResponseHandler p1, string p2)
		{
			if (id_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "get", "(Ljava/lang/String;Lcom/onesignal/OneSignalApiResponseHandler;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_get_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetGetSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_Handler()
		{
			if ((object)cb_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ == null)
			{
				cb_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_GetSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_));
			}
			return cb_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_;
		}

		private static void n_GetSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p2 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.GetSync(p, p2, p3);
		}

		public unsafe void GetSync(string p0, IOneSignalApiResponseHandler p1, string p2)
		{
			if (id_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getSync", "(Ljava/lang/String;Lcom/onesignal/OneSignalApiResponseHandler;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_getSync_Ljava_lang_String_Lcom_onesignal_OneSignalApiResponseHandler_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetPost_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_Post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			JSONObject p2 = Java.Lang.Object.GetObject<JSONObject>(native_p1, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p3 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.Post(p, p2, p3);
		}

		public unsafe void Post(string p0, JSONObject p1, IOneSignalApiResponseHandler p2)
		{
			if (id_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "post", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_post_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPostSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_PostSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_PostSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			JSONObject p2 = Java.Lang.Object.GetObject<JSONObject>(native_p1, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p3 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.PostSync(p, p2, p3);
		}

		public unsafe void PostSync(string p0, JSONObject p1, IOneSignalApiResponseHandler p2)
		{
			if (id_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "postSync", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_postSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPut_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_Put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			JSONObject p2 = Java.Lang.Object.GetObject<JSONObject>(native_p1, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p3 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.Put(p, p2, p3);
		}

		public unsafe void Put(string p0, JSONObject p1, IOneSignalApiResponseHandler p2)
		{
			if (id_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "put", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_put_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetPutSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_Handler()
		{
			if ((object)cb_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == null)
			{
				cb_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_PutSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_));
			}
			return cb_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_;
		}

		private static void n_PutSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalAPIClient oneSignalAPIClient = Java.Lang.Object.GetObject<IOneSignalAPIClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			JSONObject p2 = Java.Lang.Object.GetObject<JSONObject>(native_p1, JniHandleOwnership.DoNotTransfer);
			IOneSignalApiResponseHandler p3 = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalAPIClient.PutSync(p, p2, p3);
		}

		public unsafe void PutSync(string p0, JSONObject p1, IOneSignalApiResponseHandler p2)
		{
			if (id_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ == IntPtr.Zero)
			{
				id_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_ = JNIEnv.GetMethodID(class_ref, "putSync", "(Ljava/lang/String;Lorg/json/JSONObject;Lcom/onesignal/OneSignalApiResponseHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_putSync_Ljava_lang_String_Lorg_json_JSONObject_Lcom_onesignal_OneSignalApiResponseHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/onesignal/OneSignalApiResponseHandler", "", "Com.OneSignal.Android.IOneSignalApiResponseHandlerInvoker")]
	public interface IOneSignalApiResponseHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFailure", "(ILjava/lang/String;Ljava/lang/Throwable;)V", "GetOnFailure_ILjava_lang_String_Ljava_lang_Throwable_Handler:Com.OneSignal.Android.IOneSignalApiResponseHandlerInvoker, OneSignal.Android.Binding")]
		void OnFailure(int p0, string p1, Throwable p2);

		[Register("onSuccess", "(Ljava/lang/String;)V", "GetOnSuccess_Ljava_lang_String_Handler:Com.OneSignal.Android.IOneSignalApiResponseHandlerInvoker, OneSignal.Android.Binding")]
		void OnSuccess(string p0);
	}
	[Register("com/onesignal/OneSignalApiResponseHandler", DoNotGenerateAcw = true)]
	internal class IOneSignalApiResponseHandlerInvoker : Java.Lang.Object, IOneSignalApiResponseHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalApiResponseHandler", typeof(IOneSignalApiResponseHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onFailure_ILjava_lang_String_Ljava_lang_Throwable_;

		private IntPtr id_onFailure_ILjava_lang_String_Ljava_lang_Throwable_;

		private static Delegate cb_onSuccess_Ljava_lang_String_;

		private IntPtr id_onSuccess_Ljava_lang_String_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOneSignalApiResponseHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignalApiResponseHandler'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOneSignalApiResponseHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnFailure_ILjava_lang_String_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_onFailure_ILjava_lang_String_Ljava_lang_Throwable_ == null)
			{
				cb_onFailure_ILjava_lang_String_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_V(n_OnFailure_ILjava_lang_String_Ljava_lang_Throwable_));
			}
			return cb_onFailure_ILjava_lang_String_Ljava_lang_Throwable_;
		}

		private static void n_OnFailure_ILjava_lang_String_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalApiResponseHandler oneSignalApiResponseHandler = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Throwable p2 = Java.Lang.Object.GetObject<Throwable>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalApiResponseHandler.OnFailure(p0, p1, p2);
		}

		public unsafe void OnFailure(int p0, string p1, Throwable p2)
		{
			if (id_onFailure_ILjava_lang_String_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_onFailure_ILjava_lang_String_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(ILjava/lang/String;Ljava/lang/Throwable;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onFailure_ILjava_lang_String_Ljava_lang_Throwable_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnSuccess_Ljava_lang_String_Handler()
		{
			if ((object)cb_onSuccess_Ljava_lang_String_ == null)
			{
				cb_onSuccess_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_String_));
			}
			return cb_onSuccess_Ljava_lang_String_;
		}

		private static void n_OnSuccess_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOneSignalApiResponseHandler oneSignalApiResponseHandler = Java.Lang.Object.GetObject<IOneSignalApiResponseHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			oneSignalApiResponseHandler.OnSuccess(p);
		}

		public unsafe void OnSuccess(string p0)
		{
			if (id_onSuccess_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onSuccess_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/onesignal/OneSignalDb", "", "Com.OneSignal.Android.IOneSignalDbInvoker")]
	public interface IOneSignalDb : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("delete", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V", "GetDelete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		void Delete(string p0, string p1, string[] p2);

		[Register("insert", "(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V", "GetInsert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		void Insert(string p0, string p1, ContentValues p2);

		[Register("insertOrThrow", "(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V", "GetInsertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		void InsertOrThrow(string p0, string p1, ContentValues p2);

		[Register("query", "(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", "GetQuery_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		ICursor Query(string p0, string[] p1, string p2, string[] p3, string p4, string p5, string p6);

		[Register("query", "(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", "GetQuery_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		ICursor Query(string p0, string[] p1, string p2, string[] p3, string p4, string p5, string p6, string p7);

		[Register("update", "(Ljava/lang/String;Landroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/String;)I", "GetUpdate_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_Handler:Com.OneSignal.Android.IOneSignalDbInvoker, OneSignal.Android.Binding")]
		int Update(string p0, ContentValues p1, string p2, string[] p3);
	}
	[Register("com/onesignal/OneSignalDb", DoNotGenerateAcw = true)]
	internal class IOneSignalDbInvoker : Java.Lang.Object, IOneSignalDb, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalDb", typeof(IOneSignalDbInvoker));

		private IntPtr class_ref;

		private static Delegate cb_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_;

		private IntPtr id_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_;

		private static Delegate cb_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;

		private IntPtr id_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;

		private static Delegate cb_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;

		private IntPtr id_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;

		private static Delegate cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_;

		private IntPtr id_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOneSignalDb GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOneSignalDb>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignalDb'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOneSignalDbInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDelete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_ == null)
			{
				cb_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_));
			}
			return cb_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_;
		}

		private static void n_Delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(string));
			oneSignalDb.Delete(p, p2, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p2);
			}
		}

		public unsafe void Delete(string p0, string p1, string[] p2)
		{
			if (id_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
			{
				id_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "delete", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			IntPtr intPtr3 = JNIEnv.NewArray(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			JNIEnv.CallVoidMethod(base.Handle, id_delete_Ljava_lang_String_Ljava_lang_String_arrayLjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			if (p2 != null)
			{
				JNIEnv.CopyArray(intPtr3, p2);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
		}

		private static Delegate GetInsert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_Handler()
		{
			if ((object)cb_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ == null)
			{
				cb_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_));
			}
			return cb_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;
		}

		private static void n_Insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			ContentValues p3 = Java.Lang.Object.GetObject<ContentValues>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalDb.Insert(p, p2, p3);
		}

		public unsafe void Insert(string p0, string p1, ContentValues p2)
		{
			if (id_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ == IntPtr.Zero)
			{
				id_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ = JNIEnv.GetMethodID(class_ref, "insert", "(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_insert_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetInsertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_Handler()
		{
			if ((object)cb_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ == null)
			{
				cb_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_InsertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_));
			}
			return cb_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_;
		}

		private static void n_InsertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			ContentValues p3 = Java.Lang.Object.GetObject<ContentValues>(native_p2, JniHandleOwnership.DoNotTransfer);
			oneSignalDb.InsertOrThrow(p, p2, p3);
		}

		public unsafe void InsertOrThrow(string p0, string p1, ContentValues p2)
		{
			if (id_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ == IntPtr.Zero)
			{
				id_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_ = JNIEnv.GetMethodID(class_ref, "insertOrThrow", "(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_insertOrThrow_Ljava_lang_String_Ljava_lang_String_Landroid_content_ContentValues_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetQuery_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLLLL_L(n_Query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_Query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5, IntPtr native_p6)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(string));
			string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array2 = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			string p3 = JNIEnv.GetString(native_p4, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p5, JniHandleOwnership.DoNotTransfer);
			string p5 = JNIEnv.GetString(native_p6, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(oneSignalDb.Query(p, array, p2, array2, p3, p4, p5));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_p3);
			}
			return result;
		}

		public unsafe ICursor Query(string p0, string[] p1, string p2, string[] p3, string p4, string p5, string p6)
		{
			if (id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "query", "(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			IntPtr intPtr3 = JNIEnv.NewString(p2);
			IntPtr intPtr4 = JNIEnv.NewArray(p3);
			IntPtr intPtr5 = JNIEnv.NewString(p4);
			IntPtr intPtr6 = JNIEnv.NewString(p5);
			IntPtr intPtr7 = JNIEnv.NewString(p6);
			JValue* ptr = stackalloc JValue[7];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			ptr[3] = new JValue(intPtr4);
			ptr[4] = new JValue(intPtr5);
			ptr[5] = new JValue(intPtr6);
			ptr[6] = new JValue(intPtr7);
			ICursor result = Java.Lang.Object.GetObject<ICursor>(JNIEnv.CallObjectMethod(base.Handle, id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			if (p1 != null)
			{
				JNIEnv.CopyArray(intPtr2, p1);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			JNIEnv.DeleteLocalRef(intPtr3);
			if (p3 != null)
			{
				JNIEnv.CopyArray(intPtr4, p3);
				JNIEnv.DeleteLocalRef(intPtr4);
			}
			JNIEnv.DeleteLocalRef(intPtr5);
			JNIEnv.DeleteLocalRef(intPtr6);
			JNIEnv.DeleteLocalRef(intPtr7);
			return result;
		}

		private static Delegate GetQuery_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLLLLL_L(n_Query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_Query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5, IntPtr native_p6, IntPtr native_p7)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(string));
			string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array2 = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			string p3 = JNIEnv.GetString(native_p4, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p5, JniHandleOwnership.DoNotTransfer);
			string p5 = JNIEnv.GetString(native_p6, JniHandleOwnership.DoNotTransfer);
			string p6 = JNIEnv.GetString(native_p7, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(oneSignalDb.Query(p, array, p2, array2, p3, p4, p5, p6));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_p3);
			}
			return result;
		}

		public unsafe ICursor Query(string p0, string[] p1, string p2, string[] p3, string p4, string p5, string p6, string p7)
		{
			if (id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "query", "(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			IntPtr intPtr3 = JNIEnv.NewString(p2);
			IntPtr intPtr4 = JNIEnv.NewArray(p3);
			IntPtr intPtr5 = JNIEnv.NewString(p4);
			IntPtr intPtr6 = JNIEnv.NewString(p5);
			IntPtr intPtr7 = JNIEnv.NewString(p6);
			IntPtr intPtr8 = JNIEnv.NewString(p7);
			JValue* ptr = stackalloc JValue[8];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			ptr[3] = new JValue(intPtr4);
			ptr[4] = new JValue(intPtr5);
			ptr[5] = new JValue(intPtr6);
			ptr[6] = new JValue(intPtr7);
			ptr[7] = new JValue(intPtr8);
			ICursor result = Java.Lang.Object.GetObject<ICursor>(JNIEnv.CallObjectMethod(base.Handle, id_query_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			if (p1 != null)
			{
				JNIEnv.CopyArray(intPtr2, p1);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
			JNIEnv.DeleteLocalRef(intPtr3);
			if (p3 != null)
			{
				JNIEnv.CopyArray(intPtr4, p3);
				JNIEnv.DeleteLocalRef(intPtr4);
			}
			JNIEnv.DeleteLocalRef(intPtr5);
			JNIEnv.DeleteLocalRef(intPtr6);
			JNIEnv.DeleteLocalRef(intPtr7);
			JNIEnv.DeleteLocalRef(intPtr8);
			return result;
		}

		private static Delegate GetUpdate_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_ == null)
			{
				cb_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_I(n_Update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_));
			}
			return cb_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_;
		}

		private static int n_Update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			IOneSignalDb oneSignalDb = Java.Lang.Object.GetObject<IOneSignalDb>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			ContentValues p2 = Java.Lang.Object.GetObject<ContentValues>(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			int result = oneSignalDb.Update(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
			}
			return result;
		}

		public unsafe int Update(string p0, ContentValues p1, string p2, string[] p3)
		{
			if (id_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
			{
				id_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "update", "(Ljava/lang/String;Landroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/String;)I");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			IntPtr intPtr3 = JNIEnv.NewArray(p3);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(intPtr2);
			ptr[3] = new JValue(intPtr3);
			int result = JNIEnv.CallIntMethod(base.Handle, id_update_Ljava_lang_String_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			if (p3 != null)
			{
				JNIEnv.CopyArray(intPtr3, p3);
				JNIEnv.DeleteLocalRef(intPtr3);
			}
			return result;
		}
	}
	[Register("com/onesignal/OSEmailSubscriptionObserver", "", "Com.OneSignal.Android.IOSEmailSubscriptionObserverInvoker")]
	public interface IOSEmailSubscriptionObserver : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onOSEmailSubscriptionChanged", "(Lcom/onesignal/OSEmailSubscriptionStateChanges;)V", "GetOnOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_Handler:Com.OneSignal.Android.IOSEmailSubscriptionObserverInvoker, OneSignal.Android.Binding")]
		void OnOSEmailSubscriptionChanged(OSEmailSubscriptionStateChanges p0);
	}
	[Register("com/onesignal/OSEmailSubscriptionObserver", DoNotGenerateAcw = true)]
	internal class IOSEmailSubscriptionObserverInvoker : Java.Lang.Object, IOSEmailSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSEmailSubscriptionObserver", typeof(IOSEmailSubscriptionObserverInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_;

		private IntPtr id_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOSEmailSubscriptionObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSEmailSubscriptionObserver>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSEmailSubscriptionObserver'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSEmailSubscriptionObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_Handler()
		{
			if ((object)cb_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_ == null)
			{
				cb_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_));
			}
			return cb_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_;
		}

		private static void n_OnOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSEmailSubscriptionObserver iOSEmailSubscriptionObserver = Java.Lang.Object.GetObject<IOSEmailSubscriptionObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSEmailSubscriptionStateChanges p = Java.Lang.Object.GetObject<OSEmailSubscriptionStateChanges>(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSEmailSubscriptionObserver.OnOSEmailSubscriptionChanged(p);
		}

		public unsafe void OnOSEmailSubscriptionChanged(OSEmailSubscriptionStateChanges p0)
		{
			if (id_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_ == IntPtr.Zero)
			{
				id_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_ = JNIEnv.GetMethodID(class_ref, "onOSEmailSubscriptionChanged", "(Lcom/onesignal/OSEmailSubscriptionStateChanges;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onOSEmailSubscriptionChanged_Lcom_onesignal_OSEmailSubscriptionStateChanges_, ptr);
		}
	}
	[Register("com/onesignal/OSLogger", "", "Com.OneSignal.Android.IOSLoggerInvoker")]
	public interface IOSLogger : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("debug", "(Ljava/lang/String;)V", "GetDebug_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Debug(string p0);

		[Register("error", "(Ljava/lang/String;)V", "GetError_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Error(string p0);

		[Register("error", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "GetError_Ljava_lang_String_Ljava_lang_Throwable_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Error(string p0, Throwable p1);

		[Register("info", "(Ljava/lang/String;)V", "GetInfo_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Info(string p0);

		[Register("verbose", "(Ljava/lang/String;)V", "GetVerbose_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Verbose(string p0);

		[Register("warning", "(Ljava/lang/String;)V", "GetWarning_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSLoggerInvoker, OneSignal.Android.Binding")]
		void Warning(string p0);
	}
	[Register("com/onesignal/OSLogger", DoNotGenerateAcw = true)]
	internal class IOSLoggerInvoker : Java.Lang.Object, IOSLogger, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSLogger", typeof(IOSLoggerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_debug_Ljava_lang_String_;

		private IntPtr id_debug_Ljava_lang_String_;

		private static Delegate cb_error_Ljava_lang_String_;

		private IntPtr id_error_Ljava_lang_String_;

		private static Delegate cb_error_Ljava_lang_String_Ljava_lang_Throwable_;

		private IntPtr id_error_Ljava_lang_String_Ljava_lang_Throwable_;

		private static Delegate cb_info_Ljava_lang_String_;

		private IntPtr id_info_Ljava_lang_String_;

		private static Delegate cb_verbose_Ljava_lang_String_;

		private IntPtr id_verbose_Ljava_lang_String_;

		private static Delegate cb_warning_Ljava_lang_String_;

		private IntPtr id_warning_Ljava_lang_String_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOSLogger GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSLogger>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSLogger'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSLoggerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDebug_Ljava_lang_String_Handler()
		{
			if ((object)cb_debug_Ljava_lang_String_ == null)
			{
				cb_debug_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Debug_Ljava_lang_String_));
			}
			return cb_debug_Ljava_lang_String_;
		}

		private static void n_Debug_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Debug(p);
		}

		public unsafe void Debug(string p0)
		{
			if (id_debug_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_debug_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "debug", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_debug_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetError_Ljava_lang_String_Handler()
		{
			if ((object)cb_error_Ljava_lang_String_ == null)
			{
				cb_error_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Error_Ljava_lang_String_));
			}
			return cb_error_Ljava_lang_String_;
		}

		private static void n_Error_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Error(p);
		}

		public unsafe void Error(string p0)
		{
			if (id_error_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_error_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "error", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_error_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetError_Ljava_lang_String_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_error_Ljava_lang_String_Ljava_lang_Throwable_ == null)
			{
				cb_error_Ljava_lang_String_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Error_Ljava_lang_String_Ljava_lang_Throwable_));
			}
			return cb_error_Ljava_lang_String_Ljava_lang_Throwable_;
		}

		private static void n_Error_Ljava_lang_String_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Throwable p2 = Java.Lang.Object.GetObject<Throwable>(native_p1, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Error(p, p2);
		}

		public unsafe void Error(string p0, Throwable p1)
		{
			if (id_error_Ljava_lang_String_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_error_Ljava_lang_String_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "error", "(Ljava/lang/String;Ljava/lang/Throwable;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_error_Ljava_lang_String_Ljava_lang_Throwable_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetInfo_Ljava_lang_String_Handler()
		{
			if ((object)cb_info_Ljava_lang_String_ == null)
			{
				cb_info_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Info_Ljava_lang_String_));
			}
			return cb_info_Ljava_lang_String_;
		}

		private static void n_Info_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Info(p);
		}

		public unsafe void Info(string p0)
		{
			if (id_info_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_info_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "info", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_info_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetVerbose_Ljava_lang_String_Handler()
		{
			if ((object)cb_verbose_Ljava_lang_String_ == null)
			{
				cb_verbose_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Verbose_Ljava_lang_String_));
			}
			return cb_verbose_Ljava_lang_String_;
		}

		private static void n_Verbose_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Verbose(p);
		}

		public unsafe void Verbose(string p0)
		{
			if (id_verbose_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_verbose_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "verbose", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_verbose_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetWarning_Ljava_lang_String_Handler()
		{
			if ((object)cb_warning_Ljava_lang_String_ == null)
			{
				cb_warning_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Warning_Ljava_lang_String_));
			}
			return cb_warning_Ljava_lang_String_;
		}

		private static void n_Warning_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSLogger iOSLogger = Java.Lang.Object.GetObject<IOSLogger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSLogger.Warning(p);
		}

		public unsafe void Warning(string p0)
		{
			if (id_warning_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_warning_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "warning", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_warning_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/onesignal/OSPermissionObserver", "", "Com.OneSignal.Android.IOSPermissionObserverInvoker")]
	public interface IOSPermissionObserver : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onOSPermissionChanged", "(Lcom/onesignal/OSPermissionStateChanges;)V", "GetOnOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_Handler:Com.OneSignal.Android.IOSPermissionObserverInvoker, OneSignal.Android.Binding")]
		void OnOSPermissionChanged(OSPermissionStateChanges p0);
	}
	[Register("com/onesignal/OSPermissionObserver", DoNotGenerateAcw = true)]
	internal class IOSPermissionObserverInvoker : Java.Lang.Object, IOSPermissionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSPermissionObserver", typeof(IOSPermissionObserverInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_;

		private IntPtr id_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOSPermissionObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSPermissionObserver>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSPermissionObserver'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSPermissionObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_Handler()
		{
			if ((object)cb_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_ == null)
			{
				cb_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_));
			}
			return cb_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_;
		}

		private static void n_OnOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSPermissionObserver iOSPermissionObserver = Java.Lang.Object.GetObject<IOSPermissionObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSPermissionStateChanges p = Java.Lang.Object.GetObject<OSPermissionStateChanges>(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSPermissionObserver.OnOSPermissionChanged(p);
		}

		public unsafe void OnOSPermissionChanged(OSPermissionStateChanges p0)
		{
			if (id_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_ == IntPtr.Zero)
			{
				id_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_ = JNIEnv.GetMethodID(class_ref, "onOSPermissionChanged", "(Lcom/onesignal/OSPermissionStateChanges;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onOSPermissionChanged_Lcom_onesignal_OSPermissionStateChanges_, ptr);
		}
	}
	[Register("com/onesignal/OSSharedPreferences", "", "Com.OneSignal.Android.IOSSharedPreferencesInvoker")]
	public interface IOSSharedPreferences : IJavaObject, IDisposable, IJavaPeerable
	{
		string OutcomesV2KeyName
		{
			[Register("getOutcomesV2KeyName", "()Ljava/lang/String;", "GetGetOutcomesV2KeyNameHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
			get;
		}

		string PreferencesName
		{
			[Register("getPreferencesName", "()Ljava/lang/String;", "GetGetPreferencesNameHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
			get;
		}

		[Register("getBool", "(Ljava/lang/String;Ljava/lang/String;Z)Z", "GetGetBool_Ljava_lang_String_Ljava_lang_String_ZHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		bool GetBool(string p0, string p1, bool p2);

		[Register("getInt", "(Ljava/lang/String;Ljava/lang/String;I)I", "GetGetInt_Ljava_lang_String_Ljava_lang_String_IHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		int GetInt(string p0, string p1, int p2);

		[Register("getLong", "(Ljava/lang/String;Ljava/lang/String;J)J", "GetGetLong_Ljava_lang_String_Ljava_lang_String_JHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		long GetLong(string p0, string p1, long p2);

		[Register("getObject", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/Object;", "GetGetObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		Java.Lang.Object GetObject(string p0, string p1, Java.Lang.Object p2);

		[Register("getString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		string GetString(string p0, string p1, string p2);

		[Register("getStringSet", "(Ljava/lang/String;Ljava/lang/String;Ljava/util/Set;)Ljava/util/Set;", "GetGetStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		ICollection<string> GetStringSet(string p0, string p1, ICollection<string> p2);

		[Register("saveBool", "(Ljava/lang/String;Ljava/lang/String;Z)V", "GetSaveBool_Ljava_lang_String_Ljava_lang_String_ZHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveBool(string p0, string p1, bool p2);

		[Register("saveInt", "(Ljava/lang/String;Ljava/lang/String;I)V", "GetSaveInt_Ljava_lang_String_Ljava_lang_String_IHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveInt(string p0, string p1, int p2);

		[Register("saveLong", "(Ljava/lang/String;Ljava/lang/String;J)V", "GetSaveLong_Ljava_lang_String_Ljava_lang_String_JHandler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveLong(string p0, string p1, long p2);

		[Register("saveObject", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V", "GetSaveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveObject(string p0, string p1, Java.Lang.Object p2);

		[Register("saveString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetSaveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveString(string p0, string p1, string p2);

		[Register("saveStringSet", "(Ljava/lang/String;Ljava/lang/String;Ljava/util/Set;)V", "GetSaveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_Handler:Com.OneSignal.Android.IOSSharedPreferencesInvoker, OneSignal.Android.Binding")]
		void SaveStringSet(string p0, string p1, ICollection<string> p2);
	}
	[Register("com/onesignal/OSSharedPreferences", DoNotGenerateAcw = true)]
	internal class IOSSharedPreferencesInvoker : Java.Lang.Object, IOSSharedPreferences, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSharedPreferences", typeof(IOSSharedPreferencesInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getOutcomesV2KeyName;

		private IntPtr id_getOutcomesV2KeyName;

		private static Delegate cb_getPreferencesName;

		private IntPtr id_getPreferencesName;

		private static Delegate cb_getBool_Ljava_lang_String_Ljava_lang_String_Z;

		private IntPtr id_getBool_Ljava_lang_String_Ljava_lang_String_Z;

		private static Delegate cb_getInt_Ljava_lang_String_Ljava_lang_String_I;

		private IntPtr id_getInt_Ljava_lang_String_Ljava_lang_String_I;

		private static Delegate cb_getLong_Ljava_lang_String_Ljava_lang_String_J;

		private IntPtr id_getLong_Ljava_lang_String_Ljava_lang_String_J;

		private static Delegate cb_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;

		private IntPtr id_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;

		private IntPtr id_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;

		private static Delegate cb_saveBool_Ljava_lang_String_Ljava_lang_String_Z;

		private IntPtr id_saveBool_Ljava_lang_String_Ljava_lang_String_Z;

		private static Delegate cb_saveInt_Ljava_lang_String_Ljava_lang_String_I;

		private IntPtr id_saveInt_Ljava_lang_String_Ljava_lang_String_I;

		private static Delegate cb_saveLong_Ljava_lang_String_Ljava_lang_String_J;

		private IntPtr id_saveLong_Ljava_lang_String_Ljava_lang_String_J;

		private static Delegate cb_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;

		private IntPtr id_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate cb_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;

		private IntPtr id_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public string OutcomesV2KeyName
		{
			get
			{
				if (id_getOutcomesV2KeyName == IntPtr.Zero)
				{
					id_getOutcomesV2KeyName = JNIEnv.GetMethodID(class_ref, "getOutcomesV2KeyName", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getOutcomesV2KeyName), JniHandleOwnership.TransferLocalRef);
			}
		}

		public string PreferencesName
		{
			get
			{
				if (id_getPreferencesName == IntPtr.Zero)
				{
					id_getPreferencesName = JNIEnv.GetMethodID(class_ref, "getPreferencesName", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getPreferencesName), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IOSSharedPreferences GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSSharedPreferences>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSSharedPreferences'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSSharedPreferencesInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetOutcomesV2KeyNameHandler()
		{
			if ((object)cb_getOutcomesV2KeyName == null)
			{
				cb_getOutcomesV2KeyName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOutcomesV2KeyName));
			}
			return cb_getOutcomesV2KeyName;
		}

		private static IntPtr n_GetOutcomesV2KeyName(IntPtr jnienv, IntPtr native__this)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iOSSharedPreferences.OutcomesV2KeyName);
		}

		private static Delegate GetGetPreferencesNameHandler()
		{
			if ((object)cb_getPreferencesName == null)
			{
				cb_getPreferencesName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreferencesName));
			}
			return cb_getPreferencesName;
		}

		private static IntPtr n_GetPreferencesName(IntPtr jnienv, IntPtr native__this)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iOSSharedPreferences.PreferencesName);
		}

		private static Delegate GetGetBool_Ljava_lang_String_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_getBool_Ljava_lang_String_Ljava_lang_String_Z == null)
			{
				cb_getBool_Ljava_lang_String_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLZ_Z(n_GetBool_Ljava_lang_String_Ljava_lang_String_Z));
			}
			return cb_getBool_Ljava_lang_String_Ljava_lang_String_Z;
		}

		private static bool n_GetBool_Ljava_lang_String_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return iOSSharedPreferences.GetBool(p3, p4, p2);
		}

		public unsafe bool GetBool(string p0, string p1, bool p2)
		{
			if (id_getBool_Ljava_lang_String_Ljava_lang_String_Z == IntPtr.Zero)
			{
				id_getBool_Ljava_lang_String_Ljava_lang_String_Z = JNIEnv.GetMethodID(class_ref, "getBool", "(Ljava/lang/String;Ljava/lang/String;Z)Z");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_getBool_Ljava_lang_String_Ljava_lang_String_Z, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetGetInt_Ljava_lang_String_Ljava_lang_String_IHandler()
		{
			if ((object)cb_getInt_Ljava_lang_String_Ljava_lang_String_I == null)
			{
				cb_getInt_Ljava_lang_String_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_I(n_GetInt_Ljava_lang_String_Ljava_lang_String_I));
			}
			return cb_getInt_Ljava_lang_String_Ljava_lang_String_I;
		}

		private static int n_GetInt_Ljava_lang_String_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return iOSSharedPreferences.GetInt(p3, p4, p2);
		}

		public unsafe int GetInt(string p0, string p1, int p2)
		{
			if (id_getInt_Ljava_lang_String_Ljava_lang_String_I == IntPtr.Zero)
			{
				id_getInt_Ljava_lang_String_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "getInt", "(Ljava/lang/String;Ljava/lang/String;I)I");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			int result = JNIEnv.CallIntMethod(base.Handle, id_getInt_Ljava_lang_String_Ljava_lang_String_I, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetGetLong_Ljava_lang_String_Ljava_lang_String_JHandler()
		{
			if ((object)cb_getLong_Ljava_lang_String_Ljava_lang_String_J == null)
			{
				cb_getLong_Ljava_lang_String_Ljava_lang_String_J = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLJ_J(n_GetLong_Ljava_lang_String_Ljava_lang_String_J));
			}
			return cb_getLong_Ljava_lang_String_Ljava_lang_String_J;
		}

		private static long n_GetLong_Ljava_lang_String_Ljava_lang_String_J(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, long p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return iOSSharedPreferences.GetLong(p3, p4, p2);
		}

		public unsafe long GetLong(string p0, string p1, long p2)
		{
			if (id_getLong_Ljava_lang_String_Ljava_lang_String_J == IntPtr.Zero)
			{
				id_getLong_Ljava_lang_String_Ljava_lang_String_J = JNIEnv.GetMethodID(class_ref, "getLong", "(Ljava/lang/String;Ljava/lang/String;J)J");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			long result = JNIEnv.CallLongMethod(base.Handle, id_getLong_Ljava_lang_String_Ljava_lang_String_J, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetGetObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_GetObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static IntPtr n_GetObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p3 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iOSSharedPreferences.GetObject(p, p2, p3));
		}

		public unsafe Java.Lang.Object GetObject(string p0, string p1, Java.Lang.Object p2)
		{
			if (id_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "getObject", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetGetString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_GetString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		private static IntPtr n_GetString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iOSSharedPreferences.GetString(p, p2, p3));
		}

		public unsafe string GetString(string p0, string p1, string p2)
		{
			if (id_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "getString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			IntPtr intPtr3 = JNIEnv.NewString(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			string result = JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
			return result;
		}

		private static Delegate GetGetStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_Handler()
		{
			if ((object)cb_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ == null)
			{
				cb_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_GetStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_));
			}
			return cb_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;
		}

		private static IntPtr n_GetStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			ICollection<string> p3 = JavaSet<string>.FromJniHandle(native_p2, JniHandleOwnership.DoNotTransfer);
			return JavaSet<string>.ToLocalJniHandle(iOSSharedPreferences.GetStringSet(p, p2, p3));
		}

		public unsafe ICollection<string> GetStringSet(string p0, string p1, ICollection<string> p2)
		{
			if (id_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ == IntPtr.Zero)
			{
				id_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ = JNIEnv.GetMethodID(class_ref, "getStringSet", "(Ljava/lang/String;Ljava/lang/String;Ljava/util/Set;)Ljava/util/Set;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			IntPtr intPtr3 = JavaSet<string>.ToLocalJniHandle(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			ICollection<string> result = JavaSet<string>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
			return result;
		}

		private static Delegate GetSaveBool_Ljava_lang_String_Ljava_lang_String_ZHandler()
		{
			if ((object)cb_saveBool_Ljava_lang_String_Ljava_lang_String_Z == null)
			{
				cb_saveBool_Ljava_lang_String_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_SaveBool_Ljava_lang_String_Ljava_lang_String_Z));
			}
			return cb_saveBool_Ljava_lang_String_Ljava_lang_String_Z;
		}

		private static void n_SaveBool_Ljava_lang_String_Ljava_lang_String_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveBool(p3, p4, p2);
		}

		public unsafe void SaveBool(string p0, string p1, bool p2)
		{
			if (id_saveBool_Ljava_lang_String_Ljava_lang_String_Z == IntPtr.Zero)
			{
				id_saveBool_Ljava_lang_String_Ljava_lang_String_Z = JNIEnv.GetMethodID(class_ref, "saveBool", "(Ljava/lang/String;Ljava/lang/String;Z)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_saveBool_Ljava_lang_String_Ljava_lang_String_Z, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetSaveInt_Ljava_lang_String_Ljava_lang_String_IHandler()
		{
			if ((object)cb_saveInt_Ljava_lang_String_Ljava_lang_String_I == null)
			{
				cb_saveInt_Ljava_lang_String_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_SaveInt_Ljava_lang_String_Ljava_lang_String_I));
			}
			return cb_saveInt_Ljava_lang_String_Ljava_lang_String_I;
		}

		private static void n_SaveInt_Ljava_lang_String_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveInt(p3, p4, p2);
		}

		public unsafe void SaveInt(string p0, string p1, int p2)
		{
			if (id_saveInt_Ljava_lang_String_Ljava_lang_String_I == IntPtr.Zero)
			{
				id_saveInt_Ljava_lang_String_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "saveInt", "(Ljava/lang/String;Ljava/lang/String;I)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_saveInt_Ljava_lang_String_Ljava_lang_String_I, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetSaveLong_Ljava_lang_String_Ljava_lang_String_JHandler()
		{
			if ((object)cb_saveLong_Ljava_lang_String_Ljava_lang_String_J == null)
			{
				cb_saveLong_Ljava_lang_String_Ljava_lang_String_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLJ_V(n_SaveLong_Ljava_lang_String_Ljava_lang_String_J));
			}
			return cb_saveLong_Ljava_lang_String_Ljava_lang_String_J;
		}

		private static void n_SaveLong_Ljava_lang_String_Ljava_lang_String_J(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, long p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveLong(p3, p4, p2);
		}

		public unsafe void SaveLong(string p0, string p1, long p2)
		{
			if (id_saveLong_Ljava_lang_String_Ljava_lang_String_J == IntPtr.Zero)
			{
				id_saveLong_Ljava_lang_String_Ljava_lang_String_J = JNIEnv.GetMethodID(class_ref, "saveLong", "(Ljava/lang/String;Ljava/lang/String;J)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_saveLong_Ljava_lang_String_Ljava_lang_String_J, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetSaveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SaveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static void n_SaveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p3 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p2, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveObject(p, p2, p3);
		}

		public unsafe void SaveObject(string p0, string p1, Java.Lang.Object p2)
		{
			if (id_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "saveObject", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_saveObject_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetSaveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SaveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_SaveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveString(p, p2, p3);
		}

		public unsafe void SaveString(string p0, string p1, string p2)
		{
			if (id_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "saveString", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			IntPtr intPtr3 = JNIEnv.NewString(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			JNIEnv.CallVoidMethod(base.Handle, id_saveString_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
		}

		private static Delegate GetSaveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_Handler()
		{
			if ((object)cb_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ == null)
			{
				cb_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SaveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_));
			}
			return cb_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_;
		}

		private static void n_SaveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IOSSharedPreferences iOSSharedPreferences = Java.Lang.Object.GetObject<IOSSharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			ICollection<string> p3 = JavaSet<string>.FromJniHandle(native_p2, JniHandleOwnership.DoNotTransfer);
			iOSSharedPreferences.SaveStringSet(p, p2, p3);
		}

		public unsafe void SaveStringSet(string p0, string p1, ICollection<string> p2)
		{
			if (id_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ == IntPtr.Zero)
			{
				id_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_ = JNIEnv.GetMethodID(class_ref, "saveStringSet", "(Ljava/lang/String;Ljava/lang/String;Ljava/util/Set;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			IntPtr intPtr3 = JavaSet<string>.ToLocalJniHandle(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			ptr[2] = new JValue(intPtr3);
			JNIEnv.CallVoidMethod(base.Handle, id_saveStringSet_Ljava_lang_String_Ljava_lang_String_Ljava_util_Set_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
		}
	}
	[Register("com/onesignal/OSSMSSubscriptionObserver", "", "Com.OneSignal.Android.IOSSMSSubscriptionObserverInvoker")]
	public interface IOSSMSSubscriptionObserver : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSMSSubscriptionChanged", "(Lcom/onesignal/OSSMSSubscriptionStateChanges;)V", "GetOnSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_Handler:Com.OneSignal.Android.IOSSMSSubscriptionObserverInvoker, OneSignal.Android.Binding")]
		void OnSMSSubscriptionChanged(OSSMSSubscriptionStateChanges p0);
	}
	[Register("com/onesignal/OSSMSSubscriptionObserver", DoNotGenerateAcw = true)]
	internal class IOSSMSSubscriptionObserverInvoker : Java.Lang.Object, IOSSMSSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSMSSubscriptionObserver", typeof(IOSSMSSubscriptionObserverInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_;

		private IntPtr id_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOSSMSSubscriptionObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSSMSSubscriptionObserver>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSSMSSubscriptionObserver'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSSMSSubscriptionObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_Handler()
		{
			if ((object)cb_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_ == null)
			{
				cb_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_));
			}
			return cb_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_;
		}

		private static void n_OnSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSSMSSubscriptionObserver iOSSMSSubscriptionObserver = Java.Lang.Object.GetObject<IOSSMSSubscriptionObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSSMSSubscriptionStateChanges p = Java.Lang.Object.GetObject<OSSMSSubscriptionStateChanges>(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSSMSSubscriptionObserver.OnSMSSubscriptionChanged(p);
		}

		public unsafe void OnSMSSubscriptionChanged(OSSMSSubscriptionStateChanges p0)
		{
			if (id_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_ == IntPtr.Zero)
			{
				id_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_ = JNIEnv.GetMethodID(class_ref, "onSMSSubscriptionChanged", "(Lcom/onesignal/OSSMSSubscriptionStateChanges;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onSMSSubscriptionChanged_Lcom_onesignal_OSSMSSubscriptionStateChanges_, ptr);
		}
	}
	[Register("com/onesignal/OSSubscriptionObserver", "", "Com.OneSignal.Android.IOSSubscriptionObserverInvoker")]
	public interface IOSSubscriptionObserver : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onOSSubscriptionChanged", "(Lcom/onesignal/OSSubscriptionStateChanges;)V", "GetOnOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_Handler:Com.OneSignal.Android.IOSSubscriptionObserverInvoker, OneSignal.Android.Binding")]
		void OnOSSubscriptionChanged(OSSubscriptionStateChanges p0);
	}
	[Register("com/onesignal/OSSubscriptionObserver", DoNotGenerateAcw = true)]
	internal class IOSSubscriptionObserverInvoker : Java.Lang.Object, IOSSubscriptionObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSubscriptionObserver", typeof(IOSSubscriptionObserverInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_;

		private IntPtr id_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IOSSubscriptionObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSSubscriptionObserver>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSSubscriptionObserver'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSSubscriptionObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_Handler()
		{
			if ((object)cb_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_ == null)
			{
				cb_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_));
			}
			return cb_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_;
		}

		private static void n_OnOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOSSubscriptionObserver iOSSubscriptionObserver = Java.Lang.Object.GetObject<IOSSubscriptionObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSSubscriptionStateChanges p = Java.Lang.Object.GetObject<OSSubscriptionStateChanges>(native_p0, JniHandleOwnership.DoNotTransfer);
			iOSSubscriptionObserver.OnOSSubscriptionChanged(p);
		}

		public unsafe void OnOSSubscriptionChanged(OSSubscriptionStateChanges p0)
		{
			if (id_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_ == IntPtr.Zero)
			{
				id_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_ = JNIEnv.GetMethodID(class_ref, "onOSSubscriptionChanged", "(Lcom/onesignal/OSSubscriptionStateChanges;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onOSSubscriptionChanged_Lcom_onesignal_OSSubscriptionStateChanges_, ptr);
		}
	}
	[Register("com/onesignal/OSTime", "", "Com.OneSignal.Android.IOSTimeInvoker")]
	public interface IOSTime : IJavaObject, IDisposable, IJavaPeerable
	{
		long CurrentTimeMillis
		{
			[Register("getCurrentTimeMillis", "()J", "GetGetCurrentTimeMillisHandler:Com.OneSignal.Android.IOSTimeInvoker, OneSignal.Android.Binding")]
			get;
		}

		long ElapsedRealtime
		{
			[Register("getElapsedRealtime", "()J", "GetGetElapsedRealtimeHandler:Com.OneSignal.Android.IOSTimeInvoker, OneSignal.Android.Binding")]
			get;
		}
	}
	[Register("com/onesignal/OSTime", DoNotGenerateAcw = true)]
	internal class IOSTimeInvoker : Java.Lang.Object, IOSTime, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSTime", typeof(IOSTimeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getCurrentTimeMillis;

		private IntPtr id_getCurrentTimeMillis;

		private static Delegate cb_getElapsedRealtime;

		private IntPtr id_getElapsedRealtime;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public long CurrentTimeMillis
		{
			get
			{
				if (id_getCurrentTimeMillis == IntPtr.Zero)
				{
					id_getCurrentTimeMillis = JNIEnv.GetMethodID(class_ref, "getCurrentTimeMillis", "()J");
				}
				return JNIEnv.CallLongMethod(base.Handle, id_getCurrentTimeMillis);
			}
		}

		public long ElapsedRealtime
		{
			get
			{
				if (id_getElapsedRealtime == IntPtr.Zero)
				{
					id_getElapsedRealtime = JNIEnv.GetMethodID(class_ref, "getElapsedRealtime", "()J");
				}
				return JNIEnv.CallLongMethod(base.Handle, id_getElapsedRealtime);
			}
		}

		public static IOSTime GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOSTime>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSTime'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IOSTimeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetCurrentTimeMillisHandler()
		{
			if ((object)cb_getCurrentTimeMillis == null)
			{
				cb_getCurrentTimeMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurrentTimeMillis));
			}
			return cb_getCurrentTimeMillis;
		}

		private static long n_GetCurrentTimeMillis(IntPtr jnienv, IntPtr native__this)
		{
			IOSTime iOSTime = Java.Lang.Object.GetObject<IOSTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return iOSTime.CurrentTimeMillis;
		}

		private static Delegate GetGetElapsedRealtimeHandler()
		{
			if ((object)cb_getElapsedRealtime == null)
			{
				cb_getElapsedRealtime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetElapsedRealtime));
			}
			return cb_getElapsedRealtime;
		}

		private static long n_GetElapsedRealtime(IntPtr jnienv, IntPtr native__this)
		{
			IOSTime iOSTime = Java.Lang.Object.GetObject<IOSTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return iOSTime.ElapsedRealtime;
		}
	}
	[Register("com/onesignal/PushRegistrator$RegisteredHandler", "", "Com.OneSignal.Android.IPushRegistratorRegisteredHandlerInvoker")]
	public interface IPushRegistratorRegisteredHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("complete", "(Ljava/lang/String;I)V", "GetComplete_Ljava_lang_String_IHandler:Com.OneSignal.Android.IPushRegistratorRegisteredHandlerInvoker, OneSignal.Android.Binding")]
		void Complete(string p0, int p1);
	}
	[Register("com/onesignal/PushRegistrator$RegisteredHandler", DoNotGenerateAcw = true)]
	internal class IPushRegistratorRegisteredHandlerInvoker : Java.Lang.Object, IPushRegistratorRegisteredHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/PushRegistrator$RegisteredHandler", typeof(IPushRegistratorRegisteredHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_complete_Ljava_lang_String_I;

		private IntPtr id_complete_Ljava_lang_String_I;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IPushRegistratorRegisteredHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPushRegistratorRegisteredHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.PushRegistrator.RegisteredHandler'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IPushRegistratorRegisteredHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetComplete_Ljava_lang_String_IHandler()
		{
			if ((object)cb_complete_Ljava_lang_String_I == null)
			{
				cb_complete_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Complete_Ljava_lang_String_I));
			}
			return cb_complete_Ljava_lang_String_I;
		}

		private static void n_Complete_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			IPushRegistratorRegisteredHandler pushRegistratorRegisteredHandler = Java.Lang.Object.GetObject<IPushRegistratorRegisteredHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			pushRegistratorRegisteredHandler.Complete(p2, p1);
		}

		public unsafe void Complete(string p0, int p1)
		{
			if (id_complete_Ljava_lang_String_I == IntPtr.Zero)
			{
				id_complete_Ljava_lang_String_I = JNIEnv.GetMethodID(class_ref, "complete", "(Ljava/lang/String;I)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_complete_Ljava_lang_String_I, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/onesignal/PushRegistrator", "", "Com.OneSignal.Android.IPushRegistratorInvoker")]
	public interface IPushRegistrator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("registerForPush", "(Landroid/content/Context;Ljava/lang/String;Lcom/onesignal/PushRegistrator$RegisteredHandler;)V", "GetRegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_Handler:Com.OneSignal.Android.IPushRegistratorInvoker, OneSignal.Android.Binding")]
		void RegisterForPush(Context p0, string p1, IPushRegistratorRegisteredHandler p2);
	}
	[Register("com/onesignal/PushRegistrator", DoNotGenerateAcw = true)]
	internal class IPushRegistratorInvoker : Java.Lang.Object, IPushRegistrator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/PushRegistrator", typeof(IPushRegistratorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_;

		private IntPtr id_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IPushRegistrator GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPushRegistrator>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.PushRegistrator'.");
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IPushRegistratorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetRegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_Handler()
		{
			if ((object)cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ == null)
			{
				cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_RegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_));
			}
			return cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_;
		}

		private static void n_RegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IPushRegistrator pushRegistrator = Java.Lang.Object.GetObject<IPushRegistrator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			IPushRegistratorRegisteredHandler p3 = Java.Lang.Object.GetObject<IPushRegistratorRegisteredHandler>(native_p2, JniHandleOwnership.DoNotTransfer);
			pushRegistrator.RegisterForPush(p, p2, p3);
		}

		public unsafe void RegisterForPush(Context p0, string p1, IPushRegistratorRegisteredHandler p2)
		{
			if (id_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ == IntPtr.Zero)
			{
				id_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ = JNIEnv.GetMethodID(class_ref, "registerForPush", "(Landroid/content/Context;Ljava/lang/String;Lcom/onesignal/PushRegistrator$RegisteredHandler;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/onesignal/LocationPermissionController", DoNotGenerateAcw = true)]
	public sealed class LocationPermissionController : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/LocationPermissionController", typeof(LocationPermissionController));

		[Register("INSTANCE")]
		public static LocationPermissionController Instance => Java.Lang.Object.GetObject<LocationPermissionController>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/LocationPermissionController;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal LocationPermissionController(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("onAccept", "()V", "")]
		public unsafe void OnAccept()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onAccept.()V", this, null);
		}

		[Register("onReject", "(Z)V", "")]
		public unsafe void OnReject(bool fallbackToSettings)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fallbackToSettings);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onReject.(Z)V", this, ptr);
		}

		[Register("prompt", "(ZLjava/lang/String;)V", "")]
		public unsafe void Prompt(bool fallbackToSettings, string androidPermissionString)
		{
			IntPtr intPtr = JNIEnv.NewString(androidPermissionString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fallbackToSettings);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prompt.(ZLjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/onesignal/NavigateToAndroidSettingsForLocation", DoNotGenerateAcw = true)]
	public sealed class NavigateToAndroidSettingsForLocation : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NavigateToAndroidSettingsForLocation", typeof(NavigateToAndroidSettingsForLocation));

		[Register("INSTANCE")]
		public static NavigateToAndroidSettingsForLocation Instance => Java.Lang.Object.GetObject<NavigateToAndroidSettingsForLocation>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/NavigateToAndroidSettingsForLocation;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal NavigateToAndroidSettingsForLocation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("show", "(Landroid/content/Context;)V", "")]
		public unsafe void Show(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("show.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/onesignal/NavigateToAndroidSettingsForNotifications", DoNotGenerateAcw = true)]
	public sealed class NavigateToAndroidSettingsForNotifications : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NavigateToAndroidSettingsForNotifications", typeof(NavigateToAndroidSettingsForNotifications));

		[Register("INSTANCE")]
		public static NavigateToAndroidSettingsForNotifications Instance => Java.Lang.Object.GetObject<NavigateToAndroidSettingsForNotifications>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/NavigateToAndroidSettingsForNotifications;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal NavigateToAndroidSettingsForNotifications(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("show", "(Landroid/content/Context;)V", "")]
		public unsafe void Show(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("show.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/onesignal/NotificationDismissReceiver", DoNotGenerateAcw = true)]
	public class NotificationDismissReceiver : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationDismissReceiver", typeof(NotificationDismissReceiver));

		private static Delegate cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NotificationDismissReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationDismissReceiver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnReceive_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_intent)
		{
			NotificationDismissReceiver notificationDismissReceiver = Java.Lang.Object.GetObject<NotificationDismissReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			notificationDismissReceiver.OnReceive(context, intent);
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void OnReceive(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/onesignal/NotificationOpenedActivityHMS", DoNotGenerateAcw = true)]
	public class NotificationOpenedActivityHMS : Activity
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationOpenedActivityHMS", typeof(NotificationOpenedActivityHMS));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NotificationOpenedActivityHMS(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationOpenedActivityHMS()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/NotificationOpenedReceiver", DoNotGenerateAcw = true)]
	public sealed class NotificationOpenedReceiver : NotificationOpenedReceiverBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationOpenedReceiver", typeof(NotificationOpenedReceiver));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal NotificationOpenedReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationOpenedReceiver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/NotificationOpenedReceiverAndroid22AndOlder", DoNotGenerateAcw = true)]
	public sealed class NotificationOpenedReceiverAndroid22AndOlder : NotificationOpenedReceiverBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationOpenedReceiverAndroid22AndOlder", typeof(NotificationOpenedReceiverAndroid22AndOlder));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal NotificationOpenedReceiverAndroid22AndOlder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationOpenedReceiverAndroid22AndOlder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/NotificationOpenedReceiverBase", DoNotGenerateAcw = true)]
	public abstract class NotificationOpenedReceiverBase : Activity
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationOpenedReceiverBase", typeof(NotificationOpenedReceiverBase));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NotificationOpenedReceiverBase(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NotificationOpenedReceiverBase()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/NotificationOpenedReceiverBase", DoNotGenerateAcw = true)]
	internal class NotificationOpenedReceiverBaseInvoker : NotificationOpenedReceiverBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationOpenedReceiverBase", typeof(NotificationOpenedReceiverBaseInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public NotificationOpenedReceiverBaseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/onesignal/NotificationPermissionController", DoNotGenerateAcw = true)]
	public sealed class NotificationPermissionController : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/NotificationPermissionController", typeof(NotificationPermissionController));

		[Register("INSTANCE")]
		public static NotificationPermissionController Instance => Java.Lang.Object.GetObject<NotificationPermissionController>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/NotificationPermissionController;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool SupportsNativePrompt
		{
			[Register("getSupportsNativePrompt", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getSupportsNativePrompt.()Z", this, null);
			}
		}

		internal NotificationPermissionController(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("onAccept", "()V", "")]
		public unsafe void OnAccept()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onAccept.()V", this, null);
		}

		[Register("onAppForegrounded", "()V", "")]
		public unsafe void OnAppForegrounded()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onAppForegrounded.()V", this, null);
		}

		[Register("onReject", "(Z)V", "")]
		public unsafe void OnReject(bool fallbackToSettings)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fallbackToSettings);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onReject.(Z)V", this, ptr);
		}

		[Register("prompt", "(ZLcom/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler;)V", "")]
		public unsafe void Prompt(bool fallbackToSettings, OneSignal.IPromptForPushNotificationPermissionResponseHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fallbackToSettings);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("prompt.(ZLcom/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/onesignal/OneSignal", DoNotGenerateAcw = true)]
	public class OneSignal : Java.Lang.Object
	{
		[Register("com/onesignal/OneSignal$AppEntryAction", DoNotGenerateAcw = true)]
		public sealed class AppEntryAction : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$AppEntryAction", typeof(AppEntryAction));

			[Register("APP_CLOSE")]
			public static AppEntryAction AppClose => Java.Lang.Object.GetObject<AppEntryAction>(_members.StaticFields.GetObjectValue("APP_CLOSE.Lcom/onesignal/OneSignal$AppEntryAction;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("APP_OPEN")]
			public static AppEntryAction AppOpen => Java.Lang.Object.GetObject<AppEntryAction>(_members.StaticFields.GetObjectValue("APP_OPEN.Lcom/onesignal/OneSignal$AppEntryAction;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NOTIFICATION_CLICK")]
			public static AppEntryAction NotificationClick => Java.Lang.Object.GetObject<AppEntryAction>(_members.StaticFields.GetObjectValue("NOTIFICATION_CLICK.Lcom/onesignal/OneSignal$AppEntryAction;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe bool IsAppClose
			{
				[Register("isAppClose", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAppClose.()Z", this, null);
				}
			}

			public unsafe bool IsAppOpen
			{
				[Register("isAppOpen", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAppOpen.()Z", this, null);
				}
			}

			public unsafe bool IsNotificationClick
			{
				[Register("isNotificationClick", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("isNotificationClick.()Z", this, null);
				}
			}

			internal AppEntryAction(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OneSignal$AppEntryAction;", "")]
			public unsafe static AppEntryAction ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<AppEntryAction>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OneSignal$AppEntryAction;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OneSignal$AppEntryAction;", "")]
			public unsafe static AppEntryAction[] Values()
			{
				return (AppEntryAction[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OneSignal$AppEntryAction;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AppEntryAction));
			}
		}

		[Register("com/onesignal/OneSignal$ChangeTagsUpdateHandler", "", "Com.OneSignal.Android.OneSignal/IChangeTagsUpdateHandlerInvoker")]
		public interface IChangeTagsUpdateHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lcom/onesignal/OneSignal$SendTagsError;)V", "GetOnFailure_Lcom_onesignal_OneSignal_SendTagsError_Handler:Com.OneSignal.Android.OneSignal/IChangeTagsUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(SendTagsError p0);

			[Register("onSuccess", "(Lorg/json/JSONObject;)V", "GetOnSuccess_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IChangeTagsUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess(JSONObject p0);
		}

		[Register("com/onesignal/OneSignal$ChangeTagsUpdateHandler", DoNotGenerateAcw = true)]
		internal class IChangeTagsUpdateHandlerInvoker : Java.Lang.Object, IChangeTagsUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$ChangeTagsUpdateHandler", typeof(IChangeTagsUpdateHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lcom_onesignal_OneSignal_SendTagsError_;

			private IntPtr id_onFailure_Lcom_onesignal_OneSignal_SendTagsError_;

			private static Delegate cb_onSuccess_Lorg_json_JSONObject_;

			private IntPtr id_onSuccess_Lorg_json_JSONObject_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IChangeTagsUpdateHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IChangeTagsUpdateHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.ChangeTagsUpdateHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IChangeTagsUpdateHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lcom_onesignal_OneSignal_SendTagsError_Handler()
			{
				if ((object)cb_onFailure_Lcom_onesignal_OneSignal_SendTagsError_ == null)
				{
					cb_onFailure_Lcom_onesignal_OneSignal_SendTagsError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_onesignal_OneSignal_SendTagsError_));
				}
				return cb_onFailure_Lcom_onesignal_OneSignal_SendTagsError_;
			}

			private static void n_OnFailure_Lcom_onesignal_OneSignal_SendTagsError_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IChangeTagsUpdateHandler changeTagsUpdateHandler = Java.Lang.Object.GetObject<IChangeTagsUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SendTagsError p = Java.Lang.Object.GetObject<SendTagsError>(native_p0, JniHandleOwnership.DoNotTransfer);
				changeTagsUpdateHandler.OnFailure(p);
			}

			public unsafe void OnFailure(SendTagsError p0)
			{
				if (id_onFailure_Lcom_onesignal_OneSignal_SendTagsError_ == IntPtr.Zero)
				{
					id_onFailure_Lcom_onesignal_OneSignal_SendTagsError_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lcom/onesignal/OneSignal$SendTagsError;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lcom_onesignal_OneSignal_SendTagsError_, ptr);
			}

			private static Delegate GetOnSuccess_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_onSuccess_Lorg_json_JSONObject_ == null)
				{
					cb_onSuccess_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lorg_json_JSONObject_));
				}
				return cb_onSuccess_Lorg_json_JSONObject_;
			}

			private static void n_OnSuccess_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IChangeTagsUpdateHandler changeTagsUpdateHandler = Java.Lang.Object.GetObject<IChangeTagsUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				changeTagsUpdateHandler.OnSuccess(p);
			}

			public unsafe void OnSuccess(JSONObject p0)
			{
				if (id_onSuccess_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_onSuccess_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Lorg_json_JSONObject_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$EmailErrorType", DoNotGenerateAcw = true)]
		public sealed class EmailErrorType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$EmailErrorType", typeof(EmailErrorType));

			[Register("INVALID_OPERATION")]
			public static EmailErrorType InvalidOperation => Java.Lang.Object.GetObject<EmailErrorType>(_members.StaticFields.GetObjectValue("INVALID_OPERATION.Lcom/onesignal/OneSignal$EmailErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NETWORK")]
			public static EmailErrorType Network => Java.Lang.Object.GetObject<EmailErrorType>(_members.StaticFields.GetObjectValue("NETWORK.Lcom/onesignal/OneSignal$EmailErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("REQUIRES_EMAIL_AUTH")]
			public static EmailErrorType RequiresEmailAuth => Java.Lang.Object.GetObject<EmailErrorType>(_members.StaticFields.GetObjectValue("REQUIRES_EMAIL_AUTH.Lcom/onesignal/OneSignal$EmailErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("VALIDATION")]
			public static EmailErrorType Validation => Java.Lang.Object.GetObject<EmailErrorType>(_members.StaticFields.GetObjectValue("VALIDATION.Lcom/onesignal/OneSignal$EmailErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal EmailErrorType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OneSignal$EmailErrorType;", "")]
			public unsafe static EmailErrorType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<EmailErrorType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OneSignal$EmailErrorType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OneSignal$EmailErrorType;", "")]
			public unsafe static EmailErrorType[] Values()
			{
				return (EmailErrorType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OneSignal$EmailErrorType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(EmailErrorType));
			}
		}

		[Register("com/onesignal/OneSignal$EmailUpdateError", DoNotGenerateAcw = true)]
		public class EmailUpdateError : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$EmailUpdateError", typeof(EmailUpdateError));

			private static Delegate cb_getMessage;

			private static Delegate cb_getType;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string Message
			{
				[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual EmailErrorType Type
			{
				[Register("getType", "()Lcom/onesignal/OneSignal$EmailErrorType;", "GetGetTypeHandler")]
				get
				{
					return Java.Lang.Object.GetObject<EmailErrorType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Lcom/onesignal/OneSignal$EmailErrorType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected EmailUpdateError(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetMessageHandler()
			{
				if ((object)cb_getMessage == null)
				{
					cb_getMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
				}
				return cb_getMessage;
			}

			private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
			{
				EmailUpdateError emailUpdateError = Java.Lang.Object.GetObject<EmailUpdateError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(emailUpdateError.Message);
			}

			private static Delegate GetGetTypeHandler()
			{
				if ((object)cb_getType == null)
				{
					cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
				}
				return cb_getType;
			}

			private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
			{
				EmailUpdateError emailUpdateError = Java.Lang.Object.GetObject<EmailUpdateError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(emailUpdateError.Type);
			}
		}

		[Register("com/onesignal/OneSignal$EmailUpdateHandler", "", "Com.OneSignal.Android.OneSignal/IEmailUpdateHandlerInvoker")]
		public interface IEmailUpdateHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lcom/onesignal/OneSignal$EmailUpdateError;)V", "GetOnFailure_Lcom_onesignal_OneSignal_EmailUpdateError_Handler:Com.OneSignal.Android.OneSignal/IEmailUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(EmailUpdateError p0);

			[Register("onSuccess", "()V", "GetOnSuccessHandler:Com.OneSignal.Android.OneSignal/IEmailUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess();
		}

		[Register("com/onesignal/OneSignal$EmailUpdateHandler", DoNotGenerateAcw = true)]
		internal class IEmailUpdateHandlerInvoker : Java.Lang.Object, IEmailUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$EmailUpdateHandler", typeof(IEmailUpdateHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_;

			private IntPtr id_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_;

			private static Delegate cb_onSuccess;

			private IntPtr id_onSuccess;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IEmailUpdateHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IEmailUpdateHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.EmailUpdateHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IEmailUpdateHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lcom_onesignal_OneSignal_EmailUpdateError_Handler()
			{
				if ((object)cb_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_ == null)
				{
					cb_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_onesignal_OneSignal_EmailUpdateError_));
				}
				return cb_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_;
			}

			private static void n_OnFailure_Lcom_onesignal_OneSignal_EmailUpdateError_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IEmailUpdateHandler emailUpdateHandler = Java.Lang.Object.GetObject<IEmailUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				EmailUpdateError p = Java.Lang.Object.GetObject<EmailUpdateError>(native_p0, JniHandleOwnership.DoNotTransfer);
				emailUpdateHandler.OnFailure(p);
			}

			public unsafe void OnFailure(EmailUpdateError p0)
			{
				if (id_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_ == IntPtr.Zero)
				{
					id_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lcom/onesignal/OneSignal$EmailUpdateError;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lcom_onesignal_OneSignal_EmailUpdateError_, ptr);
			}

			private static Delegate GetOnSuccessHandler()
			{
				if ((object)cb_onSuccess == null)
				{
					cb_onSuccess = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnSuccess));
				}
				return cb_onSuccess;
			}

			private static void n_OnSuccess(IntPtr jnienv, IntPtr native__this)
			{
				IEmailUpdateHandler emailUpdateHandler = Java.Lang.Object.GetObject<IEmailUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				emailUpdateHandler.OnSuccess();
			}

			public void OnSuccess()
			{
				if (id_onSuccess == IntPtr.Zero)
				{
					id_onSuccess = JNIEnv.GetMethodID(class_ref, "onSuccess", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess);
			}
		}

		[Register("com/onesignal/OneSignal$ExternalIdError", DoNotGenerateAcw = true)]
		public class ExternalIdError : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$ExternalIdError", typeof(ExternalIdError));

			private static Delegate cb_getMessage;

			private static Delegate cb_getType;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string Message
			{
				[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual ExternalIdErrorType Type
			{
				[Register("getType", "()Lcom/onesignal/OneSignal$ExternalIdErrorType;", "GetGetTypeHandler")]
				get
				{
					return Java.Lang.Object.GetObject<ExternalIdErrorType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Lcom/onesignal/OneSignal$ExternalIdErrorType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected ExternalIdError(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetMessageHandler()
			{
				if ((object)cb_getMessage == null)
				{
					cb_getMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
				}
				return cb_getMessage;
			}

			private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
			{
				ExternalIdError externalIdError = Java.Lang.Object.GetObject<ExternalIdError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(externalIdError.Message);
			}

			private static Delegate GetGetTypeHandler()
			{
				if ((object)cb_getType == null)
				{
					cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
				}
				return cb_getType;
			}

			private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
			{
				ExternalIdError externalIdError = Java.Lang.Object.GetObject<ExternalIdError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(externalIdError.Type);
			}
		}

		[Register("com/onesignal/OneSignal$ExternalIdErrorType", DoNotGenerateAcw = true)]
		public sealed class ExternalIdErrorType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$ExternalIdErrorType", typeof(ExternalIdErrorType));

			[Register("INVALID_OPERATION")]
			public static ExternalIdErrorType InvalidOperation => Java.Lang.Object.GetObject<ExternalIdErrorType>(_members.StaticFields.GetObjectValue("INVALID_OPERATION.Lcom/onesignal/OneSignal$ExternalIdErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NETWORK")]
			public static ExternalIdErrorType Network => Java.Lang.Object.GetObject<ExternalIdErrorType>(_members.StaticFields.GetObjectValue("NETWORK.Lcom/onesignal/OneSignal$ExternalIdErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("REQUIRES_EXTERNAL_ID_AUTH")]
			public static ExternalIdErrorType RequiresExternalIdAuth => Java.Lang.Object.GetObject<ExternalIdErrorType>(_members.StaticFields.GetObjectValue("REQUIRES_EXTERNAL_ID_AUTH.Lcom/onesignal/OneSignal$ExternalIdErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal ExternalIdErrorType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OneSignal$ExternalIdErrorType;", "")]
			public unsafe static ExternalIdErrorType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ExternalIdErrorType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OneSignal$ExternalIdErrorType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OneSignal$ExternalIdErrorType;", "")]
			public unsafe static ExternalIdErrorType[] Values()
			{
				return (ExternalIdErrorType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OneSignal$ExternalIdErrorType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ExternalIdErrorType));
			}
		}

		[Register("com/onesignal/OneSignal$LOG_LEVEL", DoNotGenerateAcw = true)]
		public sealed class LOG_LEVEL : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$LOG_LEVEL", typeof(LOG_LEVEL));

			[Register("DEBUG")]
			public static LOG_LEVEL Debug => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("DEBUG.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("ERROR")]
			public static LOG_LEVEL Error => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("ERROR.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FATAL")]
			public static LOG_LEVEL Fatal => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("FATAL.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("INFO")]
			public static LOG_LEVEL Info => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("INFO.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NONE")]
			public static LOG_LEVEL None => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("NONE.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("VERBOSE")]
			public static LOG_LEVEL Verbose => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("VERBOSE.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WARN")]
			public static LOG_LEVEL Warn => Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticFields.GetObjectValue("WARN.Lcom/onesignal/OneSignal$LOG_LEVEL;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal LOG_LEVEL(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OneSignal$LOG_LEVEL;", "")]
			public unsafe static LOG_LEVEL ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<LOG_LEVEL>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OneSignal$LOG_LEVEL;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OneSignal$LOG_LEVEL;", "")]
			public unsafe static LOG_LEVEL[] Values()
			{
				return (LOG_LEVEL[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OneSignal$LOG_LEVEL;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LOG_LEVEL));
			}
		}

		[Register("com/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler", "", "Com.OneSignal.Android.OneSignal/IOSExternalUserIdUpdateCompletionHandlerInvoker")]
		public interface IOSExternalUserIdUpdateCompletionHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lcom/onesignal/OneSignal$ExternalIdError;)V", "GetOnFailure_Lcom_onesignal_OneSignal_ExternalIdError_Handler:Com.OneSignal.Android.OneSignal/IOSExternalUserIdUpdateCompletionHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(ExternalIdError p0);

			[Register("onSuccess", "(Lorg/json/JSONObject;)V", "GetOnSuccess_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IOSExternalUserIdUpdateCompletionHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess(JSONObject p0);
		}

		[Register("com/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler", DoNotGenerateAcw = true)]
		internal class IOSExternalUserIdUpdateCompletionHandlerInvoker : Java.Lang.Object, IOSExternalUserIdUpdateCompletionHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler", typeof(IOSExternalUserIdUpdateCompletionHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_;

			private IntPtr id_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_;

			private static Delegate cb_onSuccess_Lorg_json_JSONObject_;

			private IntPtr id_onSuccess_Lorg_json_JSONObject_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSExternalUserIdUpdateCompletionHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSExternalUserIdUpdateCompletionHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSExternalUserIdUpdateCompletionHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSExternalUserIdUpdateCompletionHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lcom_onesignal_OneSignal_ExternalIdError_Handler()
			{
				if ((object)cb_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_ == null)
				{
					cb_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_onesignal_OneSignal_ExternalIdError_));
				}
				return cb_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_;
			}

			private static void n_OnFailure_Lcom_onesignal_OneSignal_ExternalIdError_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSExternalUserIdUpdateCompletionHandler iOSExternalUserIdUpdateCompletionHandler = Java.Lang.Object.GetObject<IOSExternalUserIdUpdateCompletionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ExternalIdError p = Java.Lang.Object.GetObject<ExternalIdError>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSExternalUserIdUpdateCompletionHandler.OnFailure(p);
			}

			public unsafe void OnFailure(ExternalIdError p0)
			{
				if (id_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_ == IntPtr.Zero)
				{
					id_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lcom/onesignal/OneSignal$ExternalIdError;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lcom_onesignal_OneSignal_ExternalIdError_, ptr);
			}

			private static Delegate GetOnSuccess_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_onSuccess_Lorg_json_JSONObject_ == null)
				{
					cb_onSuccess_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lorg_json_JSONObject_));
				}
				return cb_onSuccess_Lorg_json_JSONObject_;
			}

			private static void n_OnSuccess_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSExternalUserIdUpdateCompletionHandler iOSExternalUserIdUpdateCompletionHandler = Java.Lang.Object.GetObject<IOSExternalUserIdUpdateCompletionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSExternalUserIdUpdateCompletionHandler.OnSuccess(p);
			}

			public unsafe void OnSuccess(JSONObject p0)
			{
				if (id_onSuccess_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_onSuccess_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Lorg_json_JSONObject_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSGetTagsHandler", "", "Com.OneSignal.Android.OneSignal/IOSGetTagsHandlerInvoker")]
		public interface IOSGetTagsHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("tagsAvailable", "(Lorg/json/JSONObject;)V", "GetTagsAvailable_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IOSGetTagsHandlerInvoker, OneSignal.Android.Binding")]
			void TagsAvailable(JSONObject p0);
		}

		[Register("com/onesignal/OneSignal$OSGetTagsHandler", DoNotGenerateAcw = true)]
		internal class IOSGetTagsHandlerInvoker : Java.Lang.Object, IOSGetTagsHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSGetTagsHandler", typeof(IOSGetTagsHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_tagsAvailable_Lorg_json_JSONObject_;

			private IntPtr id_tagsAvailable_Lorg_json_JSONObject_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSGetTagsHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSGetTagsHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSGetTagsHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSGetTagsHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetTagsAvailable_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_tagsAvailable_Lorg_json_JSONObject_ == null)
				{
					cb_tagsAvailable_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_TagsAvailable_Lorg_json_JSONObject_));
				}
				return cb_tagsAvailable_Lorg_json_JSONObject_;
			}

			private static void n_TagsAvailable_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSGetTagsHandler iOSGetTagsHandler = Java.Lang.Object.GetObject<IOSGetTagsHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSGetTagsHandler.TagsAvailable(p);
			}

			public unsafe void TagsAvailable(JSONObject p0)
			{
				if (id_tagsAvailable_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_tagsAvailable_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "tagsAvailable", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_tagsAvailable_Lorg_json_JSONObject_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSInAppMessageClickHandler", "", "Com.OneSignal.Android.OneSignal/IOSInAppMessageClickHandlerInvoker")]
		public interface IOSInAppMessageClickHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("inAppMessageClicked", "(Lcom/onesignal/OSInAppMessageAction;)V", "GetInAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_Handler:Com.OneSignal.Android.OneSignal/IOSInAppMessageClickHandlerInvoker, OneSignal.Android.Binding")]
			void InAppMessageClicked(OSInAppMessageAction p0);
		}

		[Register("com/onesignal/OneSignal$OSInAppMessageClickHandler", DoNotGenerateAcw = true)]
		internal class IOSInAppMessageClickHandlerInvoker : Java.Lang.Object, IOSInAppMessageClickHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSInAppMessageClickHandler", typeof(IOSInAppMessageClickHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_;

			private IntPtr id_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSInAppMessageClickHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSInAppMessageClickHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSInAppMessageClickHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSInAppMessageClickHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetInAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_Handler()
			{
				if ((object)cb_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_ == null)
				{
					cb_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_InAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_));
				}
				return cb_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_;
			}

			private static void n_InAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSInAppMessageClickHandler iOSInAppMessageClickHandler = Java.Lang.Object.GetObject<IOSInAppMessageClickHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSInAppMessageAction p = Java.Lang.Object.GetObject<OSInAppMessageAction>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSInAppMessageClickHandler.InAppMessageClicked(p);
			}

			public unsafe void InAppMessageClicked(OSInAppMessageAction p0)
			{
				if (id_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_ == IntPtr.Zero)
				{
					id_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_ = JNIEnv.GetMethodID(class_ref, "inAppMessageClicked", "(Lcom/onesignal/OSInAppMessageAction;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_inAppMessageClicked_Lcom_onesignal_OSInAppMessageAction_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSLanguageError", DoNotGenerateAcw = true)]
		public class OSLanguageError : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSLanguageError", typeof(OSLanguageError));

			private static Delegate cb_getCode;

			private static Delegate cb_getMessage;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int Code
			{
				[Register("getCode", "()I", "GetGetCodeHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getCode.()I", this, null);
				}
			}

			public unsafe virtual string Message
			{
				[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected OSLanguageError(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetCodeHandler()
			{
				if ((object)cb_getCode == null)
				{
					cb_getCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCode));
				}
				return cb_getCode;
			}

			private static int n_GetCode(IntPtr jnienv, IntPtr native__this)
			{
				OSLanguageError oSLanguageError = Java.Lang.Object.GetObject<OSLanguageError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return oSLanguageError.Code;
			}

			private static Delegate GetGetMessageHandler()
			{
				if ((object)cb_getMessage == null)
				{
					cb_getMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
				}
				return cb_getMessage;
			}

			private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
			{
				OSLanguageError oSLanguageError = Java.Lang.Object.GetObject<OSLanguageError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(oSLanguageError.Message);
			}
		}

		[Register("com/onesignal/OneSignal$OSNotificationOpenedHandler", "", "Com.OneSignal.Android.OneSignal/IOSNotificationOpenedHandlerInvoker")]
		public interface IOSNotificationOpenedHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("notificationOpened", "(Lcom/onesignal/OSNotificationOpenedResult;)V", "GetNotificationOpened_Lcom_onesignal_OSNotificationOpenedResult_Handler:Com.OneSignal.Android.OneSignal/IOSNotificationOpenedHandlerInvoker, OneSignal.Android.Binding")]
			void NotificationOpened(OSNotificationOpenedResult p0);
		}

		[Register("com/onesignal/OneSignal$OSNotificationOpenedHandler", DoNotGenerateAcw = true)]
		internal class IOSNotificationOpenedHandlerInvoker : Java.Lang.Object, IOSNotificationOpenedHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSNotificationOpenedHandler", typeof(IOSNotificationOpenedHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_;

			private IntPtr id_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSNotificationOpenedHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSNotificationOpenedHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSNotificationOpenedHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSNotificationOpenedHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetNotificationOpened_Lcom_onesignal_OSNotificationOpenedResult_Handler()
			{
				if ((object)cb_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_ == null)
				{
					cb_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_NotificationOpened_Lcom_onesignal_OSNotificationOpenedResult_));
				}
				return cb_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_;
			}

			private static void n_NotificationOpened_Lcom_onesignal_OSNotificationOpenedResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSNotificationOpenedHandler iOSNotificationOpenedHandler = Java.Lang.Object.GetObject<IOSNotificationOpenedHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSNotificationOpenedResult p = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSNotificationOpenedHandler.NotificationOpened(p);
			}

			public unsafe void NotificationOpened(OSNotificationOpenedResult p0)
			{
				if (id_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_ == IntPtr.Zero)
				{
					id_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_ = JNIEnv.GetMethodID(class_ref, "notificationOpened", "(Lcom/onesignal/OSNotificationOpenedResult;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_notificationOpened_Lcom_onesignal_OSNotificationOpenedResult_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSNotificationWillShowInForegroundHandler", "", "Com.OneSignal.Android.OneSignal/IOSNotificationWillShowInForegroundHandlerInvoker")]
		public interface IOSNotificationWillShowInForegroundHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("notificationWillShowInForeground", "(Lcom/onesignal/OSNotificationReceivedEvent;)V", "GetNotificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_Handler:Com.OneSignal.Android.OneSignal/IOSNotificationWillShowInForegroundHandlerInvoker, OneSignal.Android.Binding")]
			void NotificationWillShowInForeground(OSNotificationReceivedEvent p0);
		}

		[Register("com/onesignal/OneSignal$OSNotificationWillShowInForegroundHandler", DoNotGenerateAcw = true)]
		internal class IOSNotificationWillShowInForegroundHandlerInvoker : Java.Lang.Object, IOSNotificationWillShowInForegroundHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSNotificationWillShowInForegroundHandler", typeof(IOSNotificationWillShowInForegroundHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_;

			private IntPtr id_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSNotificationWillShowInForegroundHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSNotificationWillShowInForegroundHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSNotificationWillShowInForegroundHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSNotificationWillShowInForegroundHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetNotificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_Handler()
			{
				if ((object)cb_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_ == null)
				{
					cb_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_NotificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_));
				}
				return cb_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_;
			}

			private static void n_NotificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSNotificationWillShowInForegroundHandler iOSNotificationWillShowInForegroundHandler = Java.Lang.Object.GetObject<IOSNotificationWillShowInForegroundHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSNotificationReceivedEvent p = Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSNotificationWillShowInForegroundHandler.NotificationWillShowInForeground(p);
			}

			public unsafe void NotificationWillShowInForeground(OSNotificationReceivedEvent p0)
			{
				if (id_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_ == IntPtr.Zero)
				{
					id_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_ = JNIEnv.GetMethodID(class_ref, "notificationWillShowInForeground", "(Lcom/onesignal/OSNotificationReceivedEvent;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_notificationWillShowInForeground_Lcom_onesignal_OSNotificationReceivedEvent_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSRemoteNotificationReceivedHandler", "", "Com.OneSignal.Android.OneSignal/IOSRemoteNotificationReceivedHandlerInvoker")]
		public interface IOSRemoteNotificationReceivedHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("remoteNotificationReceived", "(Landroid/content/Context;Lcom/onesignal/OSNotificationReceivedEvent;)V", "GetRemoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_Handler:Com.OneSignal.Android.OneSignal/IOSRemoteNotificationReceivedHandlerInvoker, OneSignal.Android.Binding")]
			void RemoteNotificationReceived(Context p0, OSNotificationReceivedEvent p1);
		}

		[Register("com/onesignal/OneSignal$OSRemoteNotificationReceivedHandler", DoNotGenerateAcw = true)]
		internal class IOSRemoteNotificationReceivedHandlerInvoker : Java.Lang.Object, IOSRemoteNotificationReceivedHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSRemoteNotificationReceivedHandler", typeof(IOSRemoteNotificationReceivedHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_;

			private IntPtr id_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSRemoteNotificationReceivedHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSRemoteNotificationReceivedHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSRemoteNotificationReceivedHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSRemoteNotificationReceivedHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetRemoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_Handler()
			{
				if ((object)cb_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_ == null)
				{
					cb_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RemoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_));
				}
				return cb_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_;
			}

			private static void n_RemoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				IOSRemoteNotificationReceivedHandler iOSRemoteNotificationReceivedHandler = Java.Lang.Object.GetObject<IOSRemoteNotificationReceivedHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
				OSNotificationReceivedEvent p2 = Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(native_p1, JniHandleOwnership.DoNotTransfer);
				iOSRemoteNotificationReceivedHandler.RemoteNotificationReceived(p, p2);
			}

			public unsafe void RemoteNotificationReceived(Context p0, OSNotificationReceivedEvent p1)
			{
				if (id_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_ == IntPtr.Zero)
				{
					id_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_ = JNIEnv.GetMethodID(class_ref, "remoteNotificationReceived", "(Landroid/content/Context;Lcom/onesignal/OSNotificationReceivedEvent;)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_remoteNotificationReceived_Landroid_content_Context_Lcom_onesignal_OSNotificationReceivedEvent_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OSSetLanguageCompletionHandler", "", "Com.OneSignal.Android.OneSignal/IOSSetLanguageCompletionHandlerInvoker")]
		public interface IOSSetLanguageCompletionHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lcom/onesignal/OneSignal$OSLanguageError;)V", "GetOnFailure_Lcom_onesignal_OneSignal_OSLanguageError_Handler:Com.OneSignal.Android.OneSignal/IOSSetLanguageCompletionHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(OSLanguageError p0);

			[Register("onSuccess", "(Ljava/lang/String;)V", "GetOnSuccess_Ljava_lang_String_Handler:Com.OneSignal.Android.OneSignal/IOSSetLanguageCompletionHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess(string p0);
		}

		[Register("com/onesignal/OneSignal$OSSetLanguageCompletionHandler", DoNotGenerateAcw = true)]
		internal class IOSSetLanguageCompletionHandlerInvoker : Java.Lang.Object, IOSSetLanguageCompletionHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSSetLanguageCompletionHandler", typeof(IOSSetLanguageCompletionHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_;

			private IntPtr id_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_;

			private static Delegate cb_onSuccess_Ljava_lang_String_;

			private IntPtr id_onSuccess_Ljava_lang_String_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSSetLanguageCompletionHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSSetLanguageCompletionHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSSetLanguageCompletionHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSSetLanguageCompletionHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lcom_onesignal_OneSignal_OSLanguageError_Handler()
			{
				if ((object)cb_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_ == null)
				{
					cb_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_onesignal_OneSignal_OSLanguageError_));
				}
				return cb_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_;
			}

			private static void n_OnFailure_Lcom_onesignal_OneSignal_OSLanguageError_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSSetLanguageCompletionHandler iOSSetLanguageCompletionHandler = Java.Lang.Object.GetObject<IOSSetLanguageCompletionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSLanguageError p = Java.Lang.Object.GetObject<OSLanguageError>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSSetLanguageCompletionHandler.OnFailure(p);
			}

			public unsafe void OnFailure(OSLanguageError p0)
			{
				if (id_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_ == IntPtr.Zero)
				{
					id_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lcom/onesignal/OneSignal$OSLanguageError;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lcom_onesignal_OneSignal_OSLanguageError_, ptr);
			}

			private static Delegate GetOnSuccess_Ljava_lang_String_Handler()
			{
				if ((object)cb_onSuccess_Ljava_lang_String_ == null)
				{
					cb_onSuccess_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_String_));
				}
				return cb_onSuccess_Ljava_lang_String_;
			}

			private static void n_OnSuccess_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSSetLanguageCompletionHandler iOSSetLanguageCompletionHandler = Java.Lang.Object.GetObject<IOSSetLanguageCompletionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSSetLanguageCompletionHandler.OnSuccess(p);
			}

			public unsafe void OnSuccess(string p0)
			{
				if (id_onSuccess_Ljava_lang_String_ == IntPtr.Zero)
				{
					id_onSuccess_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(p0);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Ljava_lang_String_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("com/onesignal/OneSignal$OSSMSUpdateError", DoNotGenerateAcw = true)]
		public class OSSMSUpdateError : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSSMSUpdateError", typeof(OSSMSUpdateError));

			private static Delegate cb_getMessage;

			private static Delegate cb_getType;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string Message
			{
				[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual SMSErrorType Type
			{
				[Register("getType", "()Lcom/onesignal/OneSignal$SMSErrorType;", "GetGetTypeHandler")]
				get
				{
					return Java.Lang.Object.GetObject<SMSErrorType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Lcom/onesignal/OneSignal$SMSErrorType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected OSSMSUpdateError(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetMessageHandler()
			{
				if ((object)cb_getMessage == null)
				{
					cb_getMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
				}
				return cb_getMessage;
			}

			private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
			{
				OSSMSUpdateError oSSMSUpdateError = Java.Lang.Object.GetObject<OSSMSUpdateError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(oSSMSUpdateError.Message);
			}

			private static Delegate GetGetTypeHandler()
			{
				if ((object)cb_getType == null)
				{
					cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
				}
				return cb_getType;
			}

			private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
			{
				OSSMSUpdateError oSSMSUpdateError = Java.Lang.Object.GetObject<OSSMSUpdateError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSSMSUpdateError.Type);
			}
		}

		[Register("com/onesignal/OneSignal$OSSMSUpdateHandler", "", "Com.OneSignal.Android.OneSignal/IOSSMSUpdateHandlerInvoker")]
		public interface IOSSMSUpdateHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lcom/onesignal/OneSignal$OSSMSUpdateError;)V", "GetOnFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_Handler:Com.OneSignal.Android.OneSignal/IOSSMSUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(OSSMSUpdateError p0);

			[Register("onSuccess", "(Lorg/json/JSONObject;)V", "GetOnSuccess_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IOSSMSUpdateHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess(JSONObject p0);
		}

		[Register("com/onesignal/OneSignal$OSSMSUpdateHandler", DoNotGenerateAcw = true)]
		internal class IOSSMSUpdateHandlerInvoker : Java.Lang.Object, IOSSMSUpdateHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OSSMSUpdateHandler", typeof(IOSSMSUpdateHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_;

			private IntPtr id_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_;

			private static Delegate cb_onSuccess_Lorg_json_JSONObject_;

			private IntPtr id_onSuccess_Lorg_json_JSONObject_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOSSMSUpdateHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOSSMSUpdateHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OSSMSUpdateHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOSSMSUpdateHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_Handler()
			{
				if ((object)cb_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_ == null)
				{
					cb_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_));
				}
				return cb_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_;
			}

			private static void n_OnFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSSMSUpdateHandler iOSSMSUpdateHandler = Java.Lang.Object.GetObject<IOSSMSUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSSMSUpdateError p = Java.Lang.Object.GetObject<OSSMSUpdateError>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSSMSUpdateHandler.OnFailure(p);
			}

			public unsafe void OnFailure(OSSMSUpdateError p0)
			{
				if (id_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_ == IntPtr.Zero)
				{
					id_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lcom/onesignal/OneSignal$OSSMSUpdateError;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lcom_onesignal_OneSignal_OSSMSUpdateError_, ptr);
			}

			private static Delegate GetOnSuccess_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_onSuccess_Lorg_json_JSONObject_ == null)
				{
					cb_onSuccess_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lorg_json_JSONObject_));
				}
				return cb_onSuccess_Lorg_json_JSONObject_;
			}

			private static void n_OnSuccess_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOSSMSUpdateHandler iOSSMSUpdateHandler = Java.Lang.Object.GetObject<IOSSMSUpdateHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				iOSSMSUpdateHandler.OnSuccess(p);
			}

			public unsafe void OnSuccess(JSONObject p0)
			{
				if (id_onSuccess_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_onSuccess_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Lorg_json_JSONObject_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$OutcomeCallback", "", "Com.OneSignal.Android.OneSignal/IOutcomeCallbackInvoker")]
		public interface IOutcomeCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onSuccess", "(Lcom/onesignal/OSOutcomeEvent;)V", "GetOnSuccess_Lcom_onesignal_OSOutcomeEvent_Handler:Com.OneSignal.Android.OneSignal/IOutcomeCallbackInvoker, OneSignal.Android.Binding")]
			void OnSuccess(OSOutcomeEvent p0);
		}

		[Register("com/onesignal/OneSignal$OutcomeCallback", DoNotGenerateAcw = true)]
		internal class IOutcomeCallbackInvoker : Java.Lang.Object, IOutcomeCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$OutcomeCallback", typeof(IOutcomeCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onSuccess_Lcom_onesignal_OSOutcomeEvent_;

			private IntPtr id_onSuccess_Lcom_onesignal_OSOutcomeEvent_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOutcomeCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOutcomeCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.OutcomeCallback'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IOutcomeCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnSuccess_Lcom_onesignal_OSOutcomeEvent_Handler()
			{
				if ((object)cb_onSuccess_Lcom_onesignal_OSOutcomeEvent_ == null)
				{
					cb_onSuccess_Lcom_onesignal_OSOutcomeEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lcom_onesignal_OSOutcomeEvent_));
				}
				return cb_onSuccess_Lcom_onesignal_OSOutcomeEvent_;
			}

			private static void n_OnSuccess_Lcom_onesignal_OSOutcomeEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOutcomeCallback outcomeCallback = Java.Lang.Object.GetObject<IOutcomeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OSOutcomeEvent p = Java.Lang.Object.GetObject<OSOutcomeEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
				outcomeCallback.OnSuccess(p);
			}

			public unsafe void OnSuccess(OSOutcomeEvent p0)
			{
				if (id_onSuccess_Lcom_onesignal_OSOutcomeEvent_ == IntPtr.Zero)
				{
					id_onSuccess_Lcom_onesignal_OSOutcomeEvent_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Lcom/onesignal/OSOutcomeEvent;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Lcom_onesignal_OSOutcomeEvent_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$PostNotificationResponseHandler", "", "Com.OneSignal.Android.OneSignal/IPostNotificationResponseHandlerInvoker")]
		public interface IPostNotificationResponseHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onFailure", "(Lorg/json/JSONObject;)V", "GetOnFailure_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IPostNotificationResponseHandlerInvoker, OneSignal.Android.Binding")]
			void OnFailure(JSONObject p0);

			[Register("onSuccess", "(Lorg/json/JSONObject;)V", "GetOnSuccess_Lorg_json_JSONObject_Handler:Com.OneSignal.Android.OneSignal/IPostNotificationResponseHandlerInvoker, OneSignal.Android.Binding")]
			void OnSuccess(JSONObject p0);
		}

		[Register("com/onesignal/OneSignal$PostNotificationResponseHandler", DoNotGenerateAcw = true)]
		internal class IPostNotificationResponseHandlerInvoker : Java.Lang.Object, IPostNotificationResponseHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$PostNotificationResponseHandler", typeof(IPostNotificationResponseHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onFailure_Lorg_json_JSONObject_;

			private IntPtr id_onFailure_Lorg_json_JSONObject_;

			private static Delegate cb_onSuccess_Lorg_json_JSONObject_;

			private IntPtr id_onSuccess_Lorg_json_JSONObject_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IPostNotificationResponseHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPostNotificationResponseHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.PostNotificationResponseHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IPostNotificationResponseHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnFailure_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_onFailure_Lorg_json_JSONObject_ == null)
				{
					cb_onFailure_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lorg_json_JSONObject_));
				}
				return cb_onFailure_Lorg_json_JSONObject_;
			}

			private static void n_OnFailure_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IPostNotificationResponseHandler postNotificationResponseHandler = Java.Lang.Object.GetObject<IPostNotificationResponseHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				postNotificationResponseHandler.OnFailure(p);
			}

			public unsafe void OnFailure(JSONObject p0)
			{
				if (id_onFailure_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_onFailure_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lorg_json_JSONObject_, ptr);
			}

			private static Delegate GetOnSuccess_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_onSuccess_Lorg_json_JSONObject_ == null)
				{
					cb_onSuccess_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lorg_json_JSONObject_));
				}
				return cb_onSuccess_Lorg_json_JSONObject_;
			}

			private static void n_OnSuccess_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IPostNotificationResponseHandler postNotificationResponseHandler = Java.Lang.Object.GetObject<IPostNotificationResponseHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
				postNotificationResponseHandler.OnSuccess(p);
			}

			public unsafe void OnSuccess(JSONObject p0)
			{
				if (id_onSuccess_Lorg_json_JSONObject_ == IntPtr.Zero)
				{
					id_onSuccess_Lorg_json_JSONObject_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Lorg/json/JSONObject;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Lorg_json_JSONObject_, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler", "", "Com.OneSignal.Android.OneSignal/IPromptForPushNotificationPermissionResponseHandlerInvoker")]
		public interface IPromptForPushNotificationPermissionResponseHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("response", "(Z)V", "GetResponse_ZHandler:Com.OneSignal.Android.OneSignal/IPromptForPushNotificationPermissionResponseHandlerInvoker, OneSignal.Android.Binding")]
			void Response(bool p0);
		}

		[Register("com/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler", DoNotGenerateAcw = true)]
		internal class IPromptForPushNotificationPermissionResponseHandlerInvoker : Java.Lang.Object, IPromptForPushNotificationPermissionResponseHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler", typeof(IPromptForPushNotificationPermissionResponseHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_response_Z;

			private IntPtr id_response_Z;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IPromptForPushNotificationPermissionResponseHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPromptForPushNotificationPermissionResponseHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OneSignal.PromptForPushNotificationPermissionResponseHandler'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IPromptForPushNotificationPermissionResponseHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetResponse_ZHandler()
			{
				if ((object)cb_response_Z == null)
				{
					cb_response_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_Response_Z));
				}
				return cb_response_Z;
			}

			private static void n_Response_Z(IntPtr jnienv, IntPtr native__this, bool p0)
			{
				IPromptForPushNotificationPermissionResponseHandler promptForPushNotificationPermissionResponseHandler = Java.Lang.Object.GetObject<IPromptForPushNotificationPermissionResponseHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				promptForPushNotificationPermissionResponseHandler.Response(p0);
			}

			public unsafe void Response(bool p0)
			{
				if (id_response_Z == IntPtr.Zero)
				{
					id_response_Z = JNIEnv.GetMethodID(class_ref, "response", "(Z)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				JNIEnv.CallVoidMethod(base.Handle, id_response_Z, ptr);
			}
		}

		[Register("com/onesignal/OneSignal$SendTagsError", DoNotGenerateAcw = true)]
		public class SendTagsError : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$SendTagsError", typeof(SendTagsError));

			private static Delegate cb_getCode;

			private static Delegate cb_getMessage;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int Code
			{
				[Register("getCode", "()I", "GetGetCodeHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getCode.()I", this, null);
				}
			}

			public unsafe virtual string Message
			{
				[Register("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected SendTagsError(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetCodeHandler()
			{
				if ((object)cb_getCode == null)
				{
					cb_getCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCode));
				}
				return cb_getCode;
			}

			private static int n_GetCode(IntPtr jnienv, IntPtr native__this)
			{
				SendTagsError sendTagsError = Java.Lang.Object.GetObject<SendTagsError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return sendTagsError.Code;
			}

			private static Delegate GetGetMessageHandler()
			{
				if ((object)cb_getMessage == null)
				{
					cb_getMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessage));
				}
				return cb_getMessage;
			}

			private static IntPtr n_GetMessage(IntPtr jnienv, IntPtr native__this)
			{
				SendTagsError sendTagsError = Java.Lang.Object.GetObject<SendTagsError>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(sendTagsError.Message);
			}
		}

		[Register("com/onesignal/OneSignal$SMSErrorType", DoNotGenerateAcw = true)]
		public sealed class SMSErrorType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal$SMSErrorType", typeof(SMSErrorType));

			[Register("INVALID_OPERATION")]
			public static SMSErrorType InvalidOperation => Java.Lang.Object.GetObject<SMSErrorType>(_members.StaticFields.GetObjectValue("INVALID_OPERATION.Lcom/onesignal/OneSignal$SMSErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NETWORK")]
			public static SMSErrorType Network => Java.Lang.Object.GetObject<SMSErrorType>(_members.StaticFields.GetObjectValue("NETWORK.Lcom/onesignal/OneSignal$SMSErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("REQUIRES_SMS_AUTH")]
			public static SMSErrorType RequiresSmsAuth => Java.Lang.Object.GetObject<SMSErrorType>(_members.StaticFields.GetObjectValue("REQUIRES_SMS_AUTH.Lcom/onesignal/OneSignal$SMSErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("VALIDATION")]
			public static SMSErrorType Validation => Java.Lang.Object.GetObject<SMSErrorType>(_members.StaticFields.GetObjectValue("VALIDATION.Lcom/onesignal/OneSignal$SMSErrorType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal SMSErrorType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OneSignal$SMSErrorType;", "")]
			public unsafe static SMSErrorType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<SMSErrorType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OneSignal$SMSErrorType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OneSignal$SMSErrorType;", "")]
			public unsafe static SMSErrorType[] Values()
			{
				return (SMSErrorType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OneSignal$SMSErrorType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SMSErrorType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignal", typeof(OneSignal));

		[Register("sdkType")]
		public static string SdkType
		{
			get
			{
				return JNIEnv.GetString(_members.StaticFields.GetObjectValue("sdkType.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.StaticFields.SetValue("sdkType.Ljava/lang/String;", new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static OSDeviceState DeviceState
		{
			[Register("getDeviceState", "()Lcom/onesignal/OSDeviceState;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OSDeviceState>(_members.StaticMethods.InvokeObjectMethod("getDeviceState.()Lcom/onesignal/OSDeviceState;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static bool IsInAppMessagingPaused
		{
			[Register("isInAppMessagingPaused", "()Z", "")]
			get
			{
				return _members.StaticMethods.InvokeBooleanMethod("isInAppMessagingPaused.()Z", null);
			}
		}

		public unsafe static bool LocationShared
		{
			[Register("isLocationShared", "()Z", "")]
			get
			{
				return _members.StaticMethods.InvokeBooleanMethod("isLocationShared.()Z", null);
			}
			[Register("setLocationShared", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.StaticMethods.InvokeVoidMethod("setLocationShared.(Z)V", ptr);
			}
		}

		public unsafe static string SdkVersionRaw
		{
			[Register("getSdkVersionRaw", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getSdkVersionRaw.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static IDictionary<string, Java.Lang.Object> Triggers
		{
			[Register("getTriggers", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, Java.Lang.Object>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getTriggers.()Ljava/util/Map;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OneSignal(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneSignal()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("addEmailSubscriptionObserver", "(Lcom/onesignal/OSEmailSubscriptionObserver;)V", "")]
		public unsafe static void AddEmailSubscriptionObserver(IOSEmailSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("addEmailSubscriptionObserver.(Lcom/onesignal/OSEmailSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("addPermissionObserver", "(Lcom/onesignal/OSPermissionObserver;)V", "")]
		public unsafe static void AddPermissionObserver(IOSPermissionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("addPermissionObserver.(Lcom/onesignal/OSPermissionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("addSMSSubscriptionObserver", "(Lcom/onesignal/OSSMSSubscriptionObserver;)V", "")]
		public unsafe static void AddSMSSubscriptionObserver(IOSSMSSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("addSMSSubscriptionObserver.(Lcom/onesignal/OSSMSSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("addSubscriptionObserver", "(Lcom/onesignal/OSSubscriptionObserver;)V", "")]
		public unsafe static void AddSubscriptionObserver(IOSSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("addSubscriptionObserver.(Lcom/onesignal/OSSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("addTrigger", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe static void AddTrigger(string key, Java.Lang.Object @object)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("addTrigger.(Ljava/lang/String;Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@object);
			}
		}

		[Register("addTriggers", "(Ljava/util/Map;)V", "")]
		public unsafe static void AddTriggers(IDictionary<string, Java.Lang.Object> triggers)
		{
			IntPtr intPtr = JavaDictionary<string, Java.Lang.Object>.ToLocalJniHandle(triggers);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("addTriggers.(Ljava/util/Map;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(triggers);
			}
		}

		[Register("clearOneSignalNotifications", "()V", "")]
		public unsafe static void ClearOneSignalNotifications()
		{
			_members.StaticMethods.InvokeVoidMethod("clearOneSignalNotifications.()V", null);
		}

		[Register("deleteTag", "(Ljava/lang/String;)V", "")]
		public unsafe static void DeleteTag(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("deleteTag.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("deleteTag", "(Ljava/lang/String;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", "")]
		public unsafe static void DeleteTag(string key, IChangeTagsUpdateHandler handler)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("deleteTag.(Ljava/lang/String;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(handler);
			}
		}

		[Register("deleteTags", "(Ljava/lang/String;)V", "")]
		public unsafe static void DeleteTags(string jsonArrayString)
		{
			IntPtr intPtr = JNIEnv.NewString(jsonArrayString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("deleteTags.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("deleteTags", "(Ljava/lang/String;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", "")]
		public unsafe static void DeleteTags(string jsonArrayString, IChangeTagsUpdateHandler handler)
		{
			IntPtr intPtr = JNIEnv.NewString(jsonArrayString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("deleteTags.(Ljava/lang/String;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(handler);
			}
		}

		[Register("deleteTags", "(Ljava/util/Collection;)V", "")]
		public unsafe static void DeleteTags(ICollection<string> keys)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(keys);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("deleteTags.(Ljava/util/Collection;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(keys);
			}
		}

		[Register("deleteTags", "(Ljava/util/Collection;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", "")]
		public unsafe static void DeleteTags(ICollection<string> keys, IChangeTagsUpdateHandler handler)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(keys);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("deleteTags.(Ljava/util/Collection;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(keys);
				GC.KeepAlive(handler);
			}
		}

		[Register("deleteTags", "(Lorg/json/JSONArray;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", "")]
		public unsafe static void DeleteTags(JSONArray jsonArray, IChangeTagsUpdateHandler handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(jsonArray?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("deleteTags.(Lorg/json/JSONArray;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(jsonArray);
				GC.KeepAlive(handler);
			}
		}

		[Register("disableGMSMissingPrompt", "(Z)V", "")]
		public unsafe static void DisableGMSMissingPrompt(bool promptDisable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(promptDisable);
			_members.StaticMethods.InvokeVoidMethod("disableGMSMissingPrompt.(Z)V", ptr);
		}

		[Register("disablePush", "(Z)V", "")]
		public unsafe static void DisablePush(bool disable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(disable);
			_members.StaticMethods.InvokeVoidMethod("disablePush.(Z)V", ptr);
		}

		[Register("getTags", "(Lcom/onesignal/OneSignal$OSGetTagsHandler;)V", "")]
		public unsafe static void GetTags(IOSGetTagsHandler getTagsHandler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((getTagsHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)getTagsHandler).Handle);
				_members.StaticMethods.InvokeVoidMethod("getTags.(Lcom/onesignal/OneSignal$OSGetTagsHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(getTagsHandler);
			}
		}

		[Register("getTriggerValueForKey", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object GetTriggerValueForKey(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getTriggerValueForKey.(Ljava/lang/String;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("initWithContext", "(Landroid/content/Context;)V", "")]
		public unsafe static void InitWithContext(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("initWithContext.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("logoutEmail", "()V", "")]
		public unsafe static void LogoutEmail()
		{
			_members.StaticMethods.InvokeVoidMethod("logoutEmail.()V", null);
		}

		[Register("logoutEmail", "(Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", "")]
		public unsafe static void LogoutEmail(IEmailUpdateHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("logoutEmail.(Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("logoutSMSNumber", "()V", "")]
		public unsafe static void LogoutSMSNumber()
		{
			_members.StaticMethods.InvokeVoidMethod("logoutSMSNumber.()V", null);
		}

		[Register("logoutSMSNumber", "(Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", "")]
		public unsafe static void LogoutSMSNumber(IOSSMSUpdateHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("logoutSMSNumber.(Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("onesignalLog", "(Lcom/onesignal/OneSignal$LOG_LEVEL;Ljava/lang/String;)V", "")]
		public unsafe static void OnesignalLog(LOG_LEVEL level, string message)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(level?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("onesignalLog.(Lcom/onesignal/OneSignal$LOG_LEVEL;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(level);
			}
		}

		[Register("pauseInAppMessages", "(Z)V", "")]
		public unsafe static void PauseInAppMessages(bool pause)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pause);
			_members.StaticMethods.InvokeVoidMethod("pauseInAppMessages.(Z)V", ptr);
		}

		[Register("postNotification", "(Ljava/lang/String;Lcom/onesignal/OneSignal$PostNotificationResponseHandler;)V", "")]
		public unsafe static void PostNotification(string json, IPostNotificationResponseHandler handler)
		{
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("postNotification.(Ljava/lang/String;Lcom/onesignal/OneSignal$PostNotificationResponseHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(handler);
			}
		}

		[Register("postNotification", "(Lorg/json/JSONObject;Lcom/onesignal/OneSignal$PostNotificationResponseHandler;)V", "")]
		public unsafe static void PostNotification(JSONObject json, IPostNotificationResponseHandler handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(json?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("postNotification.(Lorg/json/JSONObject;Lcom/onesignal/OneSignal$PostNotificationResponseHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(json);
				GC.KeepAlive(handler);
			}
		}

		[Register("promptForPushNotifications", "()V", "")]
		public unsafe static void PromptForPushNotifications()
		{
			_members.StaticMethods.InvokeVoidMethod("promptForPushNotifications.()V", null);
		}

		[Register("promptForPushNotifications", "(Z)V", "")]
		public unsafe static void PromptForPushNotifications(bool fallbackToSettings)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fallbackToSettings);
			_members.StaticMethods.InvokeVoidMethod("promptForPushNotifications.(Z)V", ptr);
		}

		[Register("promptForPushNotifications", "(ZLcom/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler;)V", "")]
		public unsafe static void PromptForPushNotifications(bool fallbackToSettings, IPromptForPushNotificationPermissionResponseHandler handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fallbackToSettings);
				ptr[1] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.StaticMethods.InvokeVoidMethod("promptForPushNotifications.(ZLcom/onesignal/OneSignal$PromptForPushNotificationPermissionResponseHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Register("promptLocation", "()V", "")]
		public unsafe static void PromptLocation()
		{
			_members.StaticMethods.InvokeVoidMethod("promptLocation.()V", null);
		}

		[Register("provideUserConsent", "(Z)V", "")]
		public unsafe static void ProvideUserConsent(bool consent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(consent);
			_members.StaticMethods.InvokeVoidMethod("provideUserConsent.(Z)V", ptr);
		}

		[Register("removeEmailSubscriptionObserver", "(Lcom/onesignal/OSEmailSubscriptionObserver;)V", "")]
		public unsafe static void RemoveEmailSubscriptionObserver(IOSEmailSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("removeEmailSubscriptionObserver.(Lcom/onesignal/OSEmailSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("removeExternalUserId", "()V", "")]
		public unsafe static void RemoveExternalUserId()
		{
			_members.StaticMethods.InvokeVoidMethod("removeExternalUserId.()V", null);
		}

		[Register("removeExternalUserId", "(Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", "")]
		public unsafe static void RemoveExternalUserId(IOSExternalUserIdUpdateCompletionHandler completionHandler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((completionHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)completionHandler).Handle);
				_members.StaticMethods.InvokeVoidMethod("removeExternalUserId.(Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(completionHandler);
			}
		}

		[Register("removeGroupedNotifications", "(Ljava/lang/String;)V", "")]
		public unsafe static void RemoveGroupedNotifications(string group)
		{
			IntPtr intPtr = JNIEnv.NewString(group);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("removeGroupedNotifications.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("removeNotification", "(I)V", "")]
		public unsafe static void RemoveNotification(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.StaticMethods.InvokeVoidMethod("removeNotification.(I)V", ptr);
		}

		[Register("removePermissionObserver", "(Lcom/onesignal/OSPermissionObserver;)V", "")]
		public unsafe static void RemovePermissionObserver(IOSPermissionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("removePermissionObserver.(Lcom/onesignal/OSPermissionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("removeSMSSubscriptionObserver", "(Lcom/onesignal/OSSMSSubscriptionObserver;)V", "")]
		public unsafe static void RemoveSMSSubscriptionObserver(IOSSMSSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("removeSMSSubscriptionObserver.(Lcom/onesignal/OSSMSSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("removeSubscriptionObserver", "(Lcom/onesignal/OSSubscriptionObserver;)V", "")]
		public unsafe static void RemoveSubscriptionObserver(IOSSubscriptionObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.StaticMethods.InvokeVoidMethod("removeSubscriptionObserver.(Lcom/onesignal/OSSubscriptionObserver;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[Register("removeTriggerForKey", "(Ljava/lang/String;)V", "")]
		public unsafe static void RemoveTriggerForKey(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("removeTriggerForKey.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("removeTriggersForKeys", "(Ljava/util/Collection;)V", "")]
		public unsafe static void RemoveTriggersForKeys(ICollection<string> keys)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(keys);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("removeTriggersForKeys.(Ljava/util/Collection;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(keys);
			}
		}

		[Register("requiresUserPrivacyConsent", "()Z", "")]
		public unsafe static bool RequiresUserPrivacyConsent()
		{
			return _members.StaticMethods.InvokeBooleanMethod("requiresUserPrivacyConsent.()Z", null);
		}

		[Register("sendOutcome", "(Ljava/lang/String;)V", "")]
		public unsafe static void SendOutcome(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("sendOutcome.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("sendOutcome", "(Ljava/lang/String;Lcom/onesignal/OneSignal$OutcomeCallback;)V", "")]
		public unsafe static void SendOutcome(string name, IOutcomeCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("sendOutcome.(Ljava/lang/String;Lcom/onesignal/OneSignal$OutcomeCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(callback);
			}
		}

		[Register("sendOutcomeWithValue", "(Ljava/lang/String;F)V", "")]
		public unsafe static void SendOutcomeWithValue(string name, float value)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				_members.StaticMethods.InvokeVoidMethod("sendOutcomeWithValue.(Ljava/lang/String;F)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("sendOutcomeWithValue", "(Ljava/lang/String;FLcom/onesignal/OneSignal$OutcomeCallback;)V", "")]
		public unsafe static void SendOutcomeWithValue(string name, float value, IOutcomeCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(value);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("sendOutcomeWithValue.(Ljava/lang/String;FLcom/onesignal/OneSignal$OutcomeCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(callback);
			}
		}

		[Register("sendTag", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void SendTag(string key, string value)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("sendTag.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("sendTags", "(Ljava/lang/String;)V", "")]
		public unsafe static void SendTags(string jsonString)
		{
			IntPtr intPtr = JNIEnv.NewString(jsonString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("sendTags.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("sendTags", "(Lorg/json/JSONObject;)V", "")]
		public unsafe static void SendTags(JSONObject keyValues)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(keyValues?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("sendTags.(Lorg/json/JSONObject;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(keyValues);
			}
		}

		[Register("sendTags", "(Lorg/json/JSONObject;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", "")]
		public unsafe static void SendTags(JSONObject keyValues, IChangeTagsUpdateHandler changeTagsUpdateHandler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(keyValues?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((changeTagsUpdateHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)changeTagsUpdateHandler).Handle);
				_members.StaticMethods.InvokeVoidMethod("sendTags.(Lorg/json/JSONObject;Lcom/onesignal/OneSignal$ChangeTagsUpdateHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(keyValues);
				GC.KeepAlive(changeTagsUpdateHandler);
			}
		}

		[Register("sendUniqueOutcome", "(Ljava/lang/String;)V", "")]
		public unsafe static void SendUniqueOutcome(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("sendUniqueOutcome.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("sendUniqueOutcome", "(Ljava/lang/String;Lcom/onesignal/OneSignal$OutcomeCallback;)V", "")]
		public unsafe static void SendUniqueOutcome(string name, IOutcomeCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("sendUniqueOutcome.(Ljava/lang/String;Lcom/onesignal/OneSignal$OutcomeCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(callback);
			}
		}

		[Register("setAppId", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetAppId(string newAppId)
		{
			IntPtr intPtr = JNIEnv.NewString(newAppId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setAppId.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setEmail", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetEmail(string email)
		{
			IntPtr intPtr = JNIEnv.NewString(email);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setEmail.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setEmail", "(Ljava/lang/String;Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", "")]
		public unsafe static void SetEmail(string email, IEmailUpdateHandler callback)
		{
			IntPtr intPtr = JNIEnv.NewString(email);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setEmail.(Ljava/lang/String;Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(callback);
			}
		}

		[Register("setEmail", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void SetEmail(string email, string emailAuthHash)
		{
			IntPtr intPtr = JNIEnv.NewString(email);
			IntPtr intPtr2 = JNIEnv.NewString(emailAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("setEmail.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("setEmail", "(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", "")]
		public unsafe static void SetEmail(string email, string emailAuthHash, IEmailUpdateHandler callback)
		{
			IntPtr intPtr = JNIEnv.NewString(email);
			IntPtr intPtr2 = JNIEnv.NewString(emailAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setEmail.(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$EmailUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(callback);
			}
		}

		[Register("setExternalUserId", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetExternalUserId(string externalId)
		{
			IntPtr intPtr = JNIEnv.NewString(externalId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setExternalUserId.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setExternalUserId", "(Ljava/lang/String;Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", "")]
		public unsafe static void SetExternalUserId(string externalId, IOSExternalUserIdUpdateCompletionHandler completionCallback)
		{
			IntPtr intPtr = JNIEnv.NewString(externalId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((completionCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)completionCallback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setExternalUserId.(Ljava/lang/String;Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(completionCallback);
			}
		}

		[Register("setExternalUserId", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void SetExternalUserId(string externalId, string externalIdAuthHash)
		{
			IntPtr intPtr = JNIEnv.NewString(externalId);
			IntPtr intPtr2 = JNIEnv.NewString(externalIdAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("setExternalUserId.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("setExternalUserId", "(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", "")]
		public unsafe static void SetExternalUserId(string externalId, string externalIdAuthHash, IOSExternalUserIdUpdateCompletionHandler completionCallback)
		{
			IntPtr intPtr = JNIEnv.NewString(externalId);
			IntPtr intPtr2 = JNIEnv.NewString(externalIdAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue((completionCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)completionCallback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setExternalUserId.(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$OSExternalUserIdUpdateCompletionHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(completionCallback);
			}
		}

		[Register("setInAppMessageClickHandler", "(Lcom/onesignal/OneSignal$OSInAppMessageClickHandler;)V", "")]
		public unsafe static void SetInAppMessageClickHandler(IOSInAppMessageClickHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setInAppMessageClickHandler.(Lcom/onesignal/OneSignal$OSInAppMessageClickHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("setInAppMessageLifecycleHandler", "(Lcom/onesignal/OSInAppMessageLifecycleHandler;)V", "")]
		public unsafe static void SetInAppMessageLifecycleHandler(OSInAppMessageLifecycleHandler handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setInAppMessageLifecycleHandler.(Lcom/onesignal/OSInAppMessageLifecycleHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Register("setLanguage", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetLanguage(string language)
		{
			IntPtr intPtr = JNIEnv.NewString(language);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setLanguage.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setLanguage", "(Ljava/lang/String;Lcom/onesignal/OneSignal$OSSetLanguageCompletionHandler;)V", "")]
		public unsafe static void SetLanguage(string language, IOSSetLanguageCompletionHandler completionCallback)
		{
			IntPtr intPtr = JNIEnv.NewString(language);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((completionCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)completionCallback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setLanguage.(Ljava/lang/String;Lcom/onesignal/OneSignal$OSSetLanguageCompletionHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(completionCallback);
			}
		}

		[Register("setLogLevel", "(Lcom/onesignal/OneSignal$LOG_LEVEL;Lcom/onesignal/OneSignal$LOG_LEVEL;)V", "")]
		public unsafe static void SetLogLevel(LOG_LEVEL inLogCatLevel, LOG_LEVEL inVisualLogLevel)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(inLogCatLevel?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(inVisualLogLevel?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setLogLevel.(Lcom/onesignal/OneSignal$LOG_LEVEL;Lcom/onesignal/OneSignal$LOG_LEVEL;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(inLogCatLevel);
				GC.KeepAlive(inVisualLogLevel);
			}
		}

		[Register("setLogLevel", "(II)V", "")]
		public unsafe static void SetLogLevel(int inLogCatLevel, int inVisualLogLevel)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(inLogCatLevel);
			ptr[1] = new JniArgumentValue(inVisualLogLevel);
			_members.StaticMethods.InvokeVoidMethod("setLogLevel.(II)V", ptr);
		}

		[Register("setNotificationOpenedHandler", "(Lcom/onesignal/OneSignal$OSNotificationOpenedHandler;)V", "")]
		public unsafe static void SetNotificationOpenedHandler(IOSNotificationOpenedHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setNotificationOpenedHandler.(Lcom/onesignal/OneSignal$OSNotificationOpenedHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("setNotificationWillShowInForegroundHandler", "(Lcom/onesignal/OneSignal$OSNotificationWillShowInForegroundHandler;)V", "")]
		public unsafe static void SetNotificationWillShowInForegroundHandler(IOSNotificationWillShowInForegroundHandler callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setNotificationWillShowInForegroundHandler.(Lcom/onesignal/OneSignal$OSNotificationWillShowInForegroundHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("setRequiresUserPrivacyConsent", "(Z)V", "")]
		public unsafe static void SetRequiresUserPrivacyConsent(bool required)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(required);
			_members.StaticMethods.InvokeVoidMethod("setRequiresUserPrivacyConsent.(Z)V", ptr);
		}

		[Register("setSMSNumber", "(Ljava/lang/String;)V", "")]
		public unsafe static void SetSMSNumber(string smsNumber)
		{
			IntPtr intPtr = JNIEnv.NewString(smsNumber);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("setSMSNumber.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setSMSNumber", "(Ljava/lang/String;Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", "")]
		public unsafe static void SetSMSNumber(string smsNumber, IOSSMSUpdateHandler callback)
		{
			IntPtr intPtr = JNIEnv.NewString(smsNumber);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setSMSNumber.(Ljava/lang/String;Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(callback);
			}
		}

		[Register("setSMSNumber", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void SetSMSNumber(string smsNumber, string smsAuthHash)
		{
			IntPtr intPtr = JNIEnv.NewString(smsNumber);
			IntPtr intPtr2 = JNIEnv.NewString(smsAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("setSMSNumber.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("setSMSNumber", "(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", "")]
		public unsafe static void SetSMSNumber(string smsNumber, string smsAuthHash, IOSSMSUpdateHandler callback)
		{
			IntPtr intPtr = JNIEnv.NewString(smsNumber);
			IntPtr intPtr2 = JNIEnv.NewString(smsAuthHash);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("setSMSNumber.(Ljava/lang/String;Ljava/lang/String;Lcom/onesignal/OneSignal$OSSMSUpdateHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(callback);
			}
		}

		[Register("unsubscribeWhenNotificationsAreDisabled", "(Z)V", "")]
		public unsafe static void UnsubscribeWhenNotificationsAreDisabled(bool set)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(set);
			_members.StaticMethods.InvokeVoidMethod("unsubscribeWhenNotificationsAreDisabled.(Z)V", ptr);
		}

		[Register("userProvidedPrivacyConsent", "()Z", "")]
		public unsafe static bool UserProvidedPrivacyConsent()
		{
			return _members.StaticMethods.InvokeBooleanMethod("userProvidedPrivacyConsent.()Z", null);
		}
	}
	[Register("com/onesignal/OneSignalHmsEventBridge", DoNotGenerateAcw = true)]
	public class OneSignalHmsEventBridge : Java.Lang.Object
	{
		[Register("HMS_SENT_TIME_KEY")]
		public const string HmsSentTimeKey = "hms.sent_time";

		[Register("HMS_TTL_KEY")]
		public const string HmsTtlKey = "hms.ttl";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalHmsEventBridge", typeof(OneSignalHmsEventBridge));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OneSignalHmsEventBridge(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneSignalHmsEventBridge()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Obsolete("deprecated")]
		[Register("onNewToken", "(Landroid/content/Context;Ljava/lang/String;)V", "")]
		public unsafe static void OnNewToken(Context context, string token)
		{
			IntPtr intPtr = JNIEnv.NewString(token);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("onNewToken.(Landroid/content/Context;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		[Register("onNewToken", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", "")]
		public unsafe static void OnNewToken(Context context, string token, Bundle bundle)
		{
			IntPtr intPtr = JNIEnv.NewString(token);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("onNewToken.(Landroid/content/Context;Ljava/lang/String;Landroid/os/Bundle;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(bundle);
			}
		}
	}
	[Register("com/onesignal/OneSignalNotificationManager", DoNotGenerateAcw = true)]
	public class OneSignalNotificationManager : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalNotificationManager", typeof(OneSignalNotificationManager));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OneSignalNotificationManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneSignalNotificationManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("areNotificationsEnabled", "(Landroid/content/Context;Ljava/lang/String;)Z", "")]
		public unsafe static bool AreNotificationsEnabled(Context context, string channelId)
		{
			IntPtr intPtr = JNIEnv.NewString(channelId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("areNotificationsEnabled.(Landroid/content/Context;Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/onesignal/OneSignalRemoteParams", DoNotGenerateAcw = true)]
	public class OneSignalRemoteParams : Java.Lang.Object
	{
		[Register("com/onesignal/OneSignalRemoteParams$InfluenceParams", DoNotGenerateAcw = true)]
		public class InfluenceParams : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalRemoteParams$InfluenceParams", typeof(InfluenceParams));

			private static Delegate cb_getIamLimit;

			private static Delegate cb_getIndirectIAMAttributionWindow;

			private static Delegate cb_getIndirectNotificationAttributionWindow;

			private static Delegate cb_isDirectEnabled;

			private static Delegate cb_isIndirectEnabled;

			private static Delegate cb_isUnattributedEnabled;

			private static Delegate cb_getNotificationLimit;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int IamLimit
			{
				[Register("getIamLimit", "()I", "GetGetIamLimitHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getIamLimit.()I", this, null);
				}
			}

			public unsafe virtual int IndirectIAMAttributionWindow
			{
				[Register("getIndirectIAMAttributionWindow", "()I", "GetGetIndirectIAMAttributionWindowHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getIndirectIAMAttributionWindow.()I", this, null);
				}
			}

			public unsafe virtual int IndirectNotificationAttributionWindow
			{
				[Register("getIndirectNotificationAttributionWindow", "()I", "GetGetIndirectNotificationAttributionWindowHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getIndirectNotificationAttributionWindow.()I", this, null);
				}
			}

			public unsafe virtual bool IsDirectEnabled
			{
				[Register("isDirectEnabled", "()Z", "GetIsDirectEnabledHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDirectEnabled.()Z", this, null);
				}
			}

			public unsafe virtual bool IsIndirectEnabled
			{
				[Register("isIndirectEnabled", "()Z", "GetIsIndirectEnabledHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isIndirectEnabled.()Z", this, null);
				}
			}

			public unsafe virtual bool IsUnattributedEnabled
			{
				[Register("isUnattributedEnabled", "()Z", "GetIsUnattributedEnabledHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUnattributedEnabled.()Z", this, null);
				}
			}

			public unsafe virtual int NotificationLimit
			{
				[Register("getNotificationLimit", "()I", "GetGetNotificationLimitHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getNotificationLimit.()I", this, null);
				}
			}

			protected InfluenceParams(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe InfluenceParams()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetGetIamLimitHandler()
			{
				if ((object)cb_getIamLimit == null)
				{
					cb_getIamLimit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetIamLimit));
				}
				return cb_getIamLimit;
			}

			private static int n_GetIamLimit(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IamLimit;
			}

			private static Delegate GetGetIndirectIAMAttributionWindowHandler()
			{
				if ((object)cb_getIndirectIAMAttributionWindow == null)
				{
					cb_getIndirectIAMAttributionWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetIndirectIAMAttributionWindow));
				}
				return cb_getIndirectIAMAttributionWindow;
			}

			private static int n_GetIndirectIAMAttributionWindow(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IndirectIAMAttributionWindow;
			}

			private static Delegate GetGetIndirectNotificationAttributionWindowHandler()
			{
				if ((object)cb_getIndirectNotificationAttributionWindow == null)
				{
					cb_getIndirectNotificationAttributionWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetIndirectNotificationAttributionWindow));
				}
				return cb_getIndirectNotificationAttributionWindow;
			}

			private static int n_GetIndirectNotificationAttributionWindow(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IndirectNotificationAttributionWindow;
			}

			private static Delegate GetIsDirectEnabledHandler()
			{
				if ((object)cb_isDirectEnabled == null)
				{
					cb_isDirectEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDirectEnabled));
				}
				return cb_isDirectEnabled;
			}

			private static bool n_IsDirectEnabled(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IsDirectEnabled;
			}

			private static Delegate GetIsIndirectEnabledHandler()
			{
				if ((object)cb_isIndirectEnabled == null)
				{
					cb_isIndirectEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsIndirectEnabled));
				}
				return cb_isIndirectEnabled;
			}

			private static bool n_IsIndirectEnabled(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IsIndirectEnabled;
			}

			private static Delegate GetIsUnattributedEnabledHandler()
			{
				if ((object)cb_isUnattributedEnabled == null)
				{
					cb_isUnattributedEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsUnattributedEnabled));
				}
				return cb_isUnattributedEnabled;
			}

			private static bool n_IsUnattributedEnabled(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.IsUnattributedEnabled;
			}

			private static Delegate GetGetNotificationLimitHandler()
			{
				if ((object)cb_getNotificationLimit == null)
				{
					cb_getNotificationLimit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetNotificationLimit));
				}
				return cb_getNotificationLimit;
			}

			private static int n_GetNotificationLimit(IntPtr jnienv, IntPtr native__this)
			{
				InfluenceParams influenceParams = Java.Lang.Object.GetObject<InfluenceParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return influenceParams.NotificationLimit;
			}
		}

		[Register("DEFAULT_INDIRECT_ATTRIBUTION_WINDOW")]
		public const int DefaultIndirectAttributionWindow = 1440;

		[Register("DEFAULT_NOTIFICATION_LIMIT")]
		public const int DefaultNotificationLimit = 10;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OneSignalRemoteParams", typeof(OneSignalRemoteParams));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OneSignalRemoteParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OneSignalRemoteParams()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/OSBackgroundManager", DoNotGenerateAcw = true)]
	public class OSBackgroundManager : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSBackgroundManager", typeof(OSBackgroundManager));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSBackgroundManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSBackgroundManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("runRunnableOnThread", "(Ljava/lang/Runnable;Ljava/lang/String;)V", "")]
		public unsafe void RunRunnableOnThread(IRunnable runnable, string threadName)
		{
			IntPtr intPtr = JNIEnv.NewString(threadName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("runRunnableOnThread.(Ljava/lang/Runnable;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(runnable);
			}
		}
	}
	[Register("com/onesignal/OSDeviceState", DoNotGenerateAcw = true)]
	public class OSDeviceState : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSDeviceState", typeof(OSDeviceState));

		private static Delegate cb_getEmailAddress;

		private static Delegate cb_getEmailUserId;

		private static Delegate cb_isEmailSubscribed;

		private static Delegate cb_isPushDisabled;

		private static Delegate cb_isSMSSubscribed;

		private static Delegate cb_isSubscribed;

		private static Delegate cb_getPushToken;

		private static Delegate cb_getSMSNumber;

		private static Delegate cb_getSMSUserId;

		private static Delegate cb_getUserId;

		private static Delegate cb_areNotificationsEnabled;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string EmailAddress
		{
			[Register("getEmailAddress", "()Ljava/lang/String;", "GetGetEmailAddressHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmailAddress.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string EmailUserId
		{
			[Register("getEmailUserId", "()Ljava/lang/String;", "GetGetEmailUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmailUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsEmailSubscribed
		{
			[Register("isEmailSubscribed", "()Z", "GetIsEmailSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmailSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual bool IsPushDisabled
		{
			[Register("isPushDisabled", "()Z", "GetIsPushDisabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPushDisabled.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSMSSubscribed
		{
			[Register("isSMSSubscribed", "()Z", "GetIsSMSSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSMSSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSubscribed
		{
			[Register("isSubscribed", "()Z", "GetIsSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual string PushToken
		{
			[Register("getPushToken", "()Ljava/lang/String;", "GetGetPushTokenHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPushToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SMSNumber
		{
			[Register("getSMSNumber", "()Ljava/lang/String;", "GetGetSMSNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSMSNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SMSUserId
		{
			[Register("getSMSUserId", "()Ljava/lang/String;", "GetGetSMSUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSMSUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string UserId
		{
			[Register("getUserId", "()Ljava/lang/String;", "GetGetUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSDeviceState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetEmailAddressHandler()
		{
			if ((object)cb_getEmailAddress == null)
			{
				cb_getEmailAddress = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmailAddress));
			}
			return cb_getEmailAddress;
		}

		private static IntPtr n_GetEmailAddress(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.EmailAddress);
		}

		private static Delegate GetGetEmailUserIdHandler()
		{
			if ((object)cb_getEmailUserId == null)
			{
				cb_getEmailUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmailUserId));
			}
			return cb_getEmailUserId;
		}

		private static IntPtr n_GetEmailUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.EmailUserId);
		}

		private static Delegate GetIsEmailSubscribedHandler()
		{
			if ((object)cb_isEmailSubscribed == null)
			{
				cb_isEmailSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEmailSubscribed));
			}
			return cb_isEmailSubscribed;
		}

		private static bool n_IsEmailSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSDeviceState.IsEmailSubscribed;
		}

		private static Delegate GetIsPushDisabledHandler()
		{
			if ((object)cb_isPushDisabled == null)
			{
				cb_isPushDisabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPushDisabled));
			}
			return cb_isPushDisabled;
		}

		private static bool n_IsPushDisabled(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSDeviceState.IsPushDisabled;
		}

		private static Delegate GetIsSMSSubscribedHandler()
		{
			if ((object)cb_isSMSSubscribed == null)
			{
				cb_isSMSSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSMSSubscribed));
			}
			return cb_isSMSSubscribed;
		}

		private static bool n_IsSMSSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSDeviceState.IsSMSSubscribed;
		}

		private static Delegate GetIsSubscribedHandler()
		{
			if ((object)cb_isSubscribed == null)
			{
				cb_isSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSubscribed));
			}
			return cb_isSubscribed;
		}

		private static bool n_IsSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSDeviceState.IsSubscribed;
		}

		private static Delegate GetGetPushTokenHandler()
		{
			if ((object)cb_getPushToken == null)
			{
				cb_getPushToken = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPushToken));
			}
			return cb_getPushToken;
		}

		private static IntPtr n_GetPushToken(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.PushToken);
		}

		private static Delegate GetGetSMSNumberHandler()
		{
			if ((object)cb_getSMSNumber == null)
			{
				cb_getSMSNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSMSNumber));
			}
			return cb_getSMSNumber;
		}

		private static IntPtr n_GetSMSNumber(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.SMSNumber);
		}

		private static Delegate GetGetSMSUserIdHandler()
		{
			if ((object)cb_getSMSUserId == null)
			{
				cb_getSMSUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSMSUserId));
			}
			return cb_getSMSUserId;
		}

		private static IntPtr n_GetSMSUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.SMSUserId);
		}

		private static Delegate GetGetUserIdHandler()
		{
			if ((object)cb_getUserId == null)
			{
				cb_getUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUserId));
			}
			return cb_getUserId;
		}

		private static IntPtr n_GetUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSDeviceState.UserId);
		}

		private static Delegate GetAreNotificationsEnabledHandler()
		{
			if ((object)cb_areNotificationsEnabled == null)
			{
				cb_areNotificationsEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_AreNotificationsEnabled));
			}
			return cb_areNotificationsEnabled;
		}

		private static bool n_AreNotificationsEnabled(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSDeviceState.AreNotificationsEnabled();
		}

		[Register("areNotificationsEnabled", "()Z", "GetAreNotificationsEnabledHandler")]
		public unsafe virtual bool AreNotificationsEnabled()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("areNotificationsEnabled.()Z", this, null);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSDeviceState oSDeviceState = Java.Lang.Object.GetObject<OSDeviceState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSDeviceState.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSEmailSubscriptionState", DoNotGenerateAcw = true)]
	public class OSEmailSubscriptionState : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSEmailSubscriptionState", typeof(OSEmailSubscriptionState));

		private static Delegate cb_getEmailAddress;

		private static Delegate cb_getEmailUserId;

		private static Delegate cb_isSubscribed;

		private static Delegate cb_getObservable;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string EmailAddress
		{
			[Register("getEmailAddress", "()Ljava/lang/String;", "GetGetEmailAddressHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmailAddress.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string EmailUserId
		{
			[Register("getEmailUserId", "()Ljava/lang/String;", "GetGetEmailUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getEmailUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsSubscribed
		{
			[Register("isSubscribed", "()Z", "GetIsSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object Observable
		{
			[Register("getObservable", "()Ljava/lang/Object;", "GetGetObservableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObservable.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSEmailSubscriptionState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetEmailAddressHandler()
		{
			if ((object)cb_getEmailAddress == null)
			{
				cb_getEmailAddress = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmailAddress));
			}
			return cb_getEmailAddress;
		}

		private static IntPtr n_GetEmailAddress(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionState oSEmailSubscriptionState = Java.Lang.Object.GetObject<OSEmailSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSEmailSubscriptionState.EmailAddress);
		}

		private static Delegate GetGetEmailUserIdHandler()
		{
			if ((object)cb_getEmailUserId == null)
			{
				cb_getEmailUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEmailUserId));
			}
			return cb_getEmailUserId;
		}

		private static IntPtr n_GetEmailUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionState oSEmailSubscriptionState = Java.Lang.Object.GetObject<OSEmailSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSEmailSubscriptionState.EmailUserId);
		}

		private static Delegate GetIsSubscribedHandler()
		{
			if ((object)cb_isSubscribed == null)
			{
				cb_isSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSubscribed));
			}
			return cb_isSubscribed;
		}

		private static bool n_IsSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionState oSEmailSubscriptionState = Java.Lang.Object.GetObject<OSEmailSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSEmailSubscriptionState.IsSubscribed;
		}

		private static Delegate GetGetObservableHandler()
		{
			if ((object)cb_getObservable == null)
			{
				cb_getObservable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetObservable));
			}
			return cb_getObservable;
		}

		private static IntPtr n_GetObservable(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionState oSEmailSubscriptionState = Java.Lang.Object.GetObject<OSEmailSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSEmailSubscriptionState.Observable);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionState oSEmailSubscriptionState = Java.Lang.Object.GetObject<OSEmailSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSEmailSubscriptionState.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSEmailSubscriptionStateChanges", DoNotGenerateAcw = true)]
	public class OSEmailSubscriptionStateChanges : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSEmailSubscriptionStateChanges", typeof(OSEmailSubscriptionStateChanges));

		private static Delegate cb_getFrom;

		private static Delegate cb_getTo;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSEmailSubscriptionState From
		{
			[Register("getFrom", "()Lcom/onesignal/OSEmailSubscriptionState;", "GetGetFromHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSEmailSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrom.()Lcom/onesignal/OSEmailSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSEmailSubscriptionState To
		{
			[Register("getTo", "()Lcom/onesignal/OSEmailSubscriptionState;", "GetGetToHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSEmailSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTo.()Lcom/onesignal/OSEmailSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSEmailSubscriptionStateChanges(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSEmailSubscriptionState;Lcom/onesignal/OSEmailSubscriptionState;)V", "")]
		public unsafe OSEmailSubscriptionStateChanges(OSEmailSubscriptionState from, OSEmailSubscriptionState to)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSEmailSubscriptionState;Lcom/onesignal/OSEmailSubscriptionState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSEmailSubscriptionState;Lcom/onesignal/OSEmailSubscriptionState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(from);
				GC.KeepAlive(to);
			}
		}

		private static Delegate GetGetFromHandler()
		{
			if ((object)cb_getFrom == null)
			{
				cb_getFrom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFrom));
			}
			return cb_getFrom;
		}

		private static IntPtr n_GetFrom(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionStateChanges oSEmailSubscriptionStateChanges = Java.Lang.Object.GetObject<OSEmailSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSEmailSubscriptionStateChanges.From);
		}

		private static Delegate GetGetToHandler()
		{
			if ((object)cb_getTo == null)
			{
				cb_getTo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTo));
			}
			return cb_getTo;
		}

		private static IntPtr n_GetTo(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionStateChanges oSEmailSubscriptionStateChanges = Java.Lang.Object.GetObject<OSEmailSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSEmailSubscriptionStateChanges.To);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSEmailSubscriptionStateChanges oSEmailSubscriptionStateChanges = Java.Lang.Object.GetObject<OSEmailSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSEmailSubscriptionStateChanges.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSFocusHandler", DoNotGenerateAcw = true)]
	public sealed class OSFocusHandler : Java.Lang.Object
	{
		[Register("com/onesignal/OSFocusHandler$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSFocusHandler$Companion", typeof(Companion));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("onLostFocusDoWork", "()V", "")]
			public unsafe void OnLostFocusDoWork()
			{
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onLostFocusDoWork.()V", this, null);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSFocusHandler", typeof(OSFocusHandler));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool HasBackgrounded
		{
			[Register("hasBackgrounded", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasBackgrounded.()Z", this, null);
			}
		}

		public unsafe bool HasCompleted
		{
			[Register("hasCompleted", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasCompleted.()Z", this, null);
			}
		}

		internal OSFocusHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSFocusHandler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("cancelOnLostFocusWorker", "(Ljava/lang/String;Landroid/content/Context;)V", "")]
		public unsafe void CancelOnLostFocusWorker(string tag, Context context)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancelOnLostFocusWorker.(Ljava/lang/String;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		[Register("startOnFocusWork", "()V", "")]
		public unsafe void StartOnFocusWork()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startOnFocusWork.()V", this, null);
		}

		[Register("startOnLostFocusWorker", "(Ljava/lang/String;JLandroid/content/Context;)V", "")]
		public unsafe void StartOnLostFocusWorker(string tag, long delay, Context context)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(delay);
				ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("startOnLostFocusWorker.(Ljava/lang/String;JLandroid/content/Context;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		[Register("startOnStartFocusWork", "()V", "")]
		public unsafe void StartOnStartFocusWork()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startOnStartFocusWork.()V", this, null);
		}

		[Register("startOnStopFocusWork", "()V", "")]
		public unsafe void StartOnStopFocusWork()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startOnStopFocusWork.()V", this, null);
		}
	}
	[Register("com/onesignal/OSInAppMessage", DoNotGenerateAcw = true)]
	public class OSInAppMessage : Java.Lang.Object
	{
		[Register("IAM_ID")]
		public const string IamId = "messageId";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessage", typeof(OSInAppMessage));

		private static Delegate cb_getMessageId;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string MessageId
		{
			[Register("getMessageId", "()Ljava/lang/String;", "GetGetMessageIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessageId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSInAppMessage(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetMessageIdHandler()
		{
			if ((object)cb_getMessageId == null)
			{
				cb_getMessageId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessageId));
			}
			return cb_getMessageId;
		}

		private static IntPtr n_GetMessageId(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessage oSInAppMessage = Java.Lang.Object.GetObject<OSInAppMessage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSInAppMessage.MessageId);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessage oSInAppMessage = Java.Lang.Object.GetObject<OSInAppMessage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessage.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSInAppMessageAction", DoNotGenerateAcw = true)]
	public class OSInAppMessageAction : Java.Lang.Object
	{
		[Register("com/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType", DoNotGenerateAcw = true)]
		public sealed class OSInAppMessageActionUrlType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType", typeof(OSInAppMessageActionUrlType));

			[Register("BROWSER")]
			public static OSInAppMessageActionUrlType Browser => Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.StaticFields.GetObjectValue("BROWSER.Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("IN_APP_WEBVIEW")]
			public static OSInAppMessageActionUrlType InAppWebview => Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.StaticFields.GetObjectValue("IN_APP_WEBVIEW.Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("REPLACE_CONTENT")]
			public static OSInAppMessageActionUrlType ReplaceContent => Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.StaticFields.GetObjectValue("REPLACE_CONTENT.Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal OSInAppMessageActionUrlType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("fromString", "(Ljava/lang/String;)Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", "")]
			public unsafe static OSInAppMessageActionUrlType FromString(string text)
			{
				IntPtr intPtr = JNIEnv.NewString(text);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.StaticMethods.InvokeObjectMethod("fromString.(Ljava/lang/String;)Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("toJSONObject", "()Lorg/json/JSONObject;", "")]
			public unsafe JSONObject ToJSONObject()
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeAbstractObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", "")]
			public unsafe static OSInAppMessageActionUrlType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", "")]
			public unsafe static OSInAppMessageActionUrlType[] Values()
			{
				return (OSInAppMessageActionUrlType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OSInAppMessageActionUrlType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageAction", typeof(OSInAppMessageAction));

		private static Delegate cb_getClickName;

		private static Delegate cb_getClickUrl;

		private static Delegate cb_isFirstClick;

		private static Delegate cb_getOutcomes;

		private static Delegate cb_getPrompts;

		private static Delegate cb_getTags;

		private static Delegate cb_getUrlTarget;

		private static Delegate cb_doesCloseMessage;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string ClickName
		{
			[Register("getClickName", "()Ljava/lang/String;", "GetGetClickNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClickName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string ClickUrl
		{
			[Register("getClickUrl", "()Ljava/lang/String;", "GetGetClickUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getClickUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsFirstClick
		{
			[Register("isFirstClick", "()Z", "GetIsFirstClickHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFirstClick.()Z", this, null);
			}
		}

		public unsafe virtual IList<OSInAppMessageOutcome> Outcomes
		{
			[Register("getOutcomes", "()Ljava/util/List;", "GetGetOutcomesHandler")]
			get
			{
				return JavaList<OSInAppMessageOutcome>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOutcomes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<OSInAppMessagePrompt> Prompts
		{
			[Register("getPrompts", "()Ljava/util/List;", "GetGetPromptsHandler")]
			get
			{
				return JavaList<OSInAppMessagePrompt>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrompts.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSInAppMessageTag Tags
		{
			[Register("getTags", "()Lcom/onesignal/OSInAppMessageTag;", "GetGetTagsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSInAppMessageTag>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTags.()Lcom/onesignal/OSInAppMessageTag;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSInAppMessageActionUrlType UrlTarget
		{
			[Register("getUrlTarget", "()Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", "GetGetUrlTargetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSInAppMessageActionUrlType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUrlTarget.()Lcom/onesignal/OSInAppMessageAction$OSInAppMessageActionUrlType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSInAppMessageAction(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetClickNameHandler()
		{
			if ((object)cb_getClickName == null)
			{
				cb_getClickName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClickName));
			}
			return cb_getClickName;
		}

		private static IntPtr n_GetClickName(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSInAppMessageAction.ClickName);
		}

		private static Delegate GetGetClickUrlHandler()
		{
			if ((object)cb_getClickUrl == null)
			{
				cb_getClickUrl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClickUrl));
			}
			return cb_getClickUrl;
		}

		private static IntPtr n_GetClickUrl(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSInAppMessageAction.ClickUrl);
		}

		private static Delegate GetIsFirstClickHandler()
		{
			if ((object)cb_isFirstClick == null)
			{
				cb_isFirstClick = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFirstClick));
			}
			return cb_isFirstClick;
		}

		private static bool n_IsFirstClick(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSInAppMessageAction.IsFirstClick;
		}

		private static Delegate GetGetOutcomesHandler()
		{
			if ((object)cb_getOutcomes == null)
			{
				cb_getOutcomes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOutcomes));
			}
			return cb_getOutcomes;
		}

		private static IntPtr n_GetOutcomes(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<OSInAppMessageOutcome>.ToLocalJniHandle(oSInAppMessageAction.Outcomes);
		}

		private static Delegate GetGetPromptsHandler()
		{
			if ((object)cb_getPrompts == null)
			{
				cb_getPrompts = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrompts));
			}
			return cb_getPrompts;
		}

		private static IntPtr n_GetPrompts(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<OSInAppMessagePrompt>.ToLocalJniHandle(oSInAppMessageAction.Prompts);
		}

		private static Delegate GetGetTagsHandler()
		{
			if ((object)cb_getTags == null)
			{
				cb_getTags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTags));
			}
			return cb_getTags;
		}

		private static IntPtr n_GetTags(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageAction.Tags);
		}

		private static Delegate GetGetUrlTargetHandler()
		{
			if ((object)cb_getUrlTarget == null)
			{
				cb_getUrlTarget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUrlTarget));
			}
			return cb_getUrlTarget;
		}

		private static IntPtr n_GetUrlTarget(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageAction.UrlTarget);
		}

		private static Delegate GetDoesCloseMessageHandler()
		{
			if ((object)cb_doesCloseMessage == null)
			{
				cb_doesCloseMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_DoesCloseMessage));
			}
			return cb_doesCloseMessage;
		}

		private static bool n_DoesCloseMessage(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSInAppMessageAction.DoesCloseMessage();
		}

		[Register("doesCloseMessage", "()Z", "GetDoesCloseMessageHandler")]
		public unsafe virtual bool DoesCloseMessage()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("doesCloseMessage.()Z", this, null);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageAction oSInAppMessageAction = Java.Lang.Object.GetObject<OSInAppMessageAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageAction.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSInAppMessageContentKt", DoNotGenerateAcw = true)]
	public sealed class OSInAppMessageContentKt : Java.Lang.Object
	{
		[Register("DISPLAY_DURATION")]
		public const string DisplayDuration = "display_duration";

		[Register("HTML")]
		public const string Html = "html";

		[Register("REMOVE_HEIGHT_MARGIN")]
		public const string RemoveHeightMargin = "remove_height_margin";

		[Register("REMOVE_WIDTH_MARGIN")]
		public const string RemoveWidthMargin = "remove_width_margin";

		[Register("STYLES")]
		public const string Styles = "styles";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageContentKt", typeof(OSInAppMessageContentKt));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSInAppMessageContentKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/onesignal/OSInAppMessageLifecycleHandler", DoNotGenerateAcw = true)]
	public abstract class OSInAppMessageLifecycleHandler : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageLifecycleHandler", typeof(OSInAppMessageLifecycleHandler));

		private static Delegate cb_onDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_;

		private static Delegate cb_onDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_;

		private static Delegate cb_onWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_;

		private static Delegate cb_onWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSInAppMessageLifecycleHandler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSInAppMessageLifecycleHandler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_Handler()
		{
			if ((object)cb_onDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_ == null)
			{
				cb_onDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_));
			}
			return cb_onDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_;
		}

		private static void n_OnDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			OSInAppMessageLifecycleHandler oSInAppMessageLifecycleHandler = Java.Lang.Object.GetObject<OSInAppMessageLifecycleHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSInAppMessage message = Java.Lang.Object.GetObject<OSInAppMessage>(native_message, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageLifecycleHandler.OnDidDismissInAppMessage(message);
		}

		[Register("onDidDismissInAppMessage", "(Lcom/onesignal/OSInAppMessage;)V", "GetOnDidDismissInAppMessage_Lcom_onesignal_OSInAppMessage_Handler")]
		public unsafe virtual void OnDidDismissInAppMessage(OSInAppMessage message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDidDismissInAppMessage.(Lcom/onesignal/OSInAppMessage;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		private static Delegate GetOnDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_Handler()
		{
			if ((object)cb_onDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_ == null)
			{
				cb_onDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_));
			}
			return cb_onDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_;
		}

		private static void n_OnDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			OSInAppMessageLifecycleHandler oSInAppMessageLifecycleHandler = Java.Lang.Object.GetObject<OSInAppMessageLifecycleHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSInAppMessage message = Java.Lang.Object.GetObject<OSInAppMessage>(native_message, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageLifecycleHandler.OnDidDisplayInAppMessage(message);
		}

		[Register("onDidDisplayInAppMessage", "(Lcom/onesignal/OSInAppMessage;)V", "GetOnDidDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_Handler")]
		public unsafe virtual void OnDidDisplayInAppMessage(OSInAppMessage message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDidDisplayInAppMessage.(Lcom/onesignal/OSInAppMessage;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		private static Delegate GetOnWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_Handler()
		{
			if ((object)cb_onWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_ == null)
			{
				cb_onWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_));
			}
			return cb_onWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_;
		}

		private static void n_OnWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			OSInAppMessageLifecycleHandler oSInAppMessageLifecycleHandler = Java.Lang.Object.GetObject<OSInAppMessageLifecycleHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSInAppMessage message = Java.Lang.Object.GetObject<OSInAppMessage>(native_message, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageLifecycleHandler.OnWillDismissInAppMessage(message);
		}

		[Register("onWillDismissInAppMessage", "(Lcom/onesignal/OSInAppMessage;)V", "GetOnWillDismissInAppMessage_Lcom_onesignal_OSInAppMessage_Handler")]
		public unsafe virtual void OnWillDismissInAppMessage(OSInAppMessage message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onWillDismissInAppMessage.(Lcom/onesignal/OSInAppMessage;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}

		private static Delegate GetOnWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_Handler()
		{
			if ((object)cb_onWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_ == null)
			{
				cb_onWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_));
			}
			return cb_onWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_;
		}

		private static void n_OnWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_(IntPtr jnienv, IntPtr native__this, IntPtr native_message)
		{
			OSInAppMessageLifecycleHandler oSInAppMessageLifecycleHandler = Java.Lang.Object.GetObject<OSInAppMessageLifecycleHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSInAppMessage message = Java.Lang.Object.GetObject<OSInAppMessage>(native_message, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageLifecycleHandler.OnWillDisplayInAppMessage(message);
		}

		[Register("onWillDisplayInAppMessage", "(Lcom/onesignal/OSInAppMessage;)V", "GetOnWillDisplayInAppMessage_Lcom_onesignal_OSInAppMessage_Handler")]
		public unsafe virtual void OnWillDisplayInAppMessage(OSInAppMessage message)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(message?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onWillDisplayInAppMessage.(Lcom/onesignal/OSInAppMessage;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(message);
			}
		}
	}
	[Register("com/onesignal/OSInAppMessageLifecycleHandler", DoNotGenerateAcw = true)]
	internal class OSInAppMessageLifecycleHandlerInvoker : OSInAppMessageLifecycleHandler
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageLifecycleHandler", typeof(OSInAppMessageLifecycleHandlerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OSInAppMessageLifecycleHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/onesignal/OSInAppMessageOutcome", DoNotGenerateAcw = true)]
	public class OSInAppMessageOutcome : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageOutcome", typeof(OSInAppMessageOutcome));

		private static Delegate cb_getName;

		private static Delegate cb_setName_Ljava_lang_String_;

		private static Delegate cb_isUnique;

		private static Delegate cb_setUnique_Z;

		private static Delegate cb_getWeight;

		private static Delegate cb_setWeight_F;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "GetSetName_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual bool Unique
		{
			[Register("isUnique", "()Z", "GetIsUniqueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUnique.()Z", this, null);
			}
			[Register("setUnique", "(Z)V", "GetSetUnique_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setUnique.(Z)V", this, ptr);
			}
		}

		public unsafe virtual float Weight
		{
			[Register("getWeight", "()F", "GetGetWeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getWeight.()F", this, null);
			}
			[Register("setWeight", "(F)V", "GetSetWeight_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setWeight.(F)V", this, ptr);
			}
		}

		protected OSInAppMessageOutcome(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName == null)
			{
				cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName;
		}

		private static IntPtr n_GetName(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSInAppMessageOutcome.Name);
		}

		private static Delegate GetSetName_Ljava_lang_String_Handler()
		{
			if ((object)cb_setName_Ljava_lang_String_ == null)
			{
				cb_setName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetName_Ljava_lang_String_));
			}
			return cb_setName_Ljava_lang_String_;
		}

		private static void n_SetName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageOutcome.Name = name;
		}

		private static Delegate GetIsUniqueHandler()
		{
			if ((object)cb_isUnique == null)
			{
				cb_isUnique = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsUnique));
			}
			return cb_isUnique;
		}

		private static bool n_IsUnique(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSInAppMessageOutcome.Unique;
		}

		private static Delegate GetSetUnique_ZHandler()
		{
			if ((object)cb_setUnique_Z == null)
			{
				cb_setUnique_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetUnique_Z));
			}
			return cb_setUnique_Z;
		}

		private static void n_SetUnique_Z(IntPtr jnienv, IntPtr native__this, bool unique)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageOutcome.Unique = unique;
		}

		private static Delegate GetGetWeightHandler()
		{
			if ((object)cb_getWeight == null)
			{
				cb_getWeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetWeight));
			}
			return cb_getWeight;
		}

		private static float n_GetWeight(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSInAppMessageOutcome.Weight;
		}

		private static Delegate GetSetWeight_FHandler()
		{
			if ((object)cb_setWeight_F == null)
			{
				cb_setWeight_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetWeight_F));
			}
			return cb_setWeight_F;
		}

		private static void n_SetWeight_F(IntPtr jnienv, IntPtr native__this, float weight)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageOutcome.Weight = weight;
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageOutcome oSInAppMessageOutcome = Java.Lang.Object.GetObject<OSInAppMessageOutcome>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageOutcome.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSInAppMessagePageKt", DoNotGenerateAcw = true)]
	public sealed class OSInAppMessagePageKt : Java.Lang.Object
	{
		[Register("PAGE_ID")]
		public const string PageId = "pageId";

		[Register("PAGE_INDEX")]
		public const string PageIndex = "pageIndex";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessagePageKt", typeof(OSInAppMessagePageKt));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSInAppMessagePageKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/onesignal/OSInAppMessagePrompt", DoNotGenerateAcw = true)]
	public abstract class OSInAppMessagePrompt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessagePrompt", typeof(OSInAppMessagePrompt));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSInAppMessagePrompt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/onesignal/OSInAppMessagePrompt", DoNotGenerateAcw = true)]
	internal class OSInAppMessagePromptInvoker : OSInAppMessagePrompt
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessagePrompt", typeof(OSInAppMessagePromptInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OSInAppMessagePromptInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/onesignal/OSInAppMessagePushPrompt", DoNotGenerateAcw = true)]
	public class OSInAppMessagePushPrompt : OSInAppMessagePrompt
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessagePushPrompt", typeof(OSInAppMessagePushPrompt));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSInAppMessagePushPrompt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSInAppMessagePushPrompt()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/OSInAppMessageTag", DoNotGenerateAcw = true)]
	public class OSInAppMessageTag : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSInAppMessageTag", typeof(OSInAppMessageTag));

		private static Delegate cb_getTagsToAdd;

		private static Delegate cb_setTagsToAdd_Lorg_json_JSONObject_;

		private static Delegate cb_getTagsToRemove;

		private static Delegate cb_setTagsToRemove_Lorg_json_JSONArray_;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual JSONObject TagsToAdd
		{
			[Register("getTagsToAdd", "()Lorg/json/JSONObject;", "GetGetTagsToAddHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTagsToAdd.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTagsToAdd", "(Lorg/json/JSONObject;)V", "GetSetTagsToAdd_Lorg_json_JSONObject_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setTagsToAdd.(Lorg/json/JSONObject;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual JSONArray TagsToRemove
		{
			[Register("getTagsToRemove", "()Lorg/json/JSONArray;", "GetGetTagsToRemoveHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTagsToRemove.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTagsToRemove", "(Lorg/json/JSONArray;)V", "GetSetTagsToRemove_Lorg_json_JSONArray_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setTagsToRemove.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected OSInAppMessageTag(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetTagsToAddHandler()
		{
			if ((object)cb_getTagsToAdd == null)
			{
				cb_getTagsToAdd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTagsToAdd));
			}
			return cb_getTagsToAdd;
		}

		private static IntPtr n_GetTagsToAdd(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageTag oSInAppMessageTag = Java.Lang.Object.GetObject<OSInAppMessageTag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageTag.TagsToAdd);
		}

		private static Delegate GetSetTagsToAdd_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_setTagsToAdd_Lorg_json_JSONObject_ == null)
			{
				cb_setTagsToAdd_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTagsToAdd_Lorg_json_JSONObject_));
			}
			return cb_setTagsToAdd_Lorg_json_JSONObject_;
		}

		private static void n_SetTagsToAdd_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_tagsToAdd)
		{
			OSInAppMessageTag oSInAppMessageTag = Java.Lang.Object.GetObject<OSInAppMessageTag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject tagsToAdd = Java.Lang.Object.GetObject<JSONObject>(native_tagsToAdd, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageTag.TagsToAdd = tagsToAdd;
		}

		private static Delegate GetGetTagsToRemoveHandler()
		{
			if ((object)cb_getTagsToRemove == null)
			{
				cb_getTagsToRemove = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTagsToRemove));
			}
			return cb_getTagsToRemove;
		}

		private static IntPtr n_GetTagsToRemove(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageTag oSInAppMessageTag = Java.Lang.Object.GetObject<OSInAppMessageTag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageTag.TagsToRemove);
		}

		private static Delegate GetSetTagsToRemove_Lorg_json_JSONArray_Handler()
		{
			if ((object)cb_setTagsToRemove_Lorg_json_JSONArray_ == null)
			{
				cb_setTagsToRemove_Lorg_json_JSONArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTagsToRemove_Lorg_json_JSONArray_));
			}
			return cb_setTagsToRemove_Lorg_json_JSONArray_;
		}

		private static void n_SetTagsToRemove_Lorg_json_JSONArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_tagsToRemove)
		{
			OSInAppMessageTag oSInAppMessageTag = Java.Lang.Object.GetObject<OSInAppMessageTag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONArray tagsToRemove = Java.Lang.Object.GetObject<JSONArray>(native_tagsToRemove, JniHandleOwnership.DoNotTransfer);
			oSInAppMessageTag.TagsToRemove = tagsToRemove;
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSInAppMessageTag oSInAppMessageTag = Java.Lang.Object.GetObject<OSInAppMessageTag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSInAppMessageTag.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSMutableNotification", DoNotGenerateAcw = true)]
	public class OSMutableNotification : OSNotification
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSMutableNotification", typeof(OSMutableNotification));

		private static Delegate cb_setAndroidNotificationId_I;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSMutableNotification(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetSetAndroidNotificationId_IHandler()
		{
			if ((object)cb_setAndroidNotificationId_I == null)
			{
				cb_setAndroidNotificationId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetAndroidNotificationId_I));
			}
			return cb_setAndroidNotificationId_I;
		}

		private static void n_SetAndroidNotificationId_I(IntPtr jnienv, IntPtr native__this, int androidNotificationId)
		{
			OSMutableNotification oSMutableNotification = Java.Lang.Object.GetObject<OSMutableNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSMutableNotification.SetAndroidNotificationId(androidNotificationId);
		}

		[Register("setAndroidNotificationId", "(I)V", "GetSetAndroidNotificationId_IHandler")]
		public new unsafe virtual void SetAndroidNotificationId(int androidNotificationId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(androidNotificationId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAndroidNotificationId.(I)V", this, ptr);
		}
	}
	[Register("com/onesignal/OSNotification", DoNotGenerateAcw = true)]
	public class OSNotification : Java.Lang.Object
	{
		[Register("com/onesignal/OSNotification$ActionButton", DoNotGenerateAcw = true)]
		public class ActionButton : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotification$ActionButton", typeof(ActionButton));

			private static Delegate cb_getIcon;

			private static Delegate cb_getId;

			private static Delegate cb_getText;

			private static Delegate cb_toJSONObject;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string Icon
			{
				[Register("getIcon", "()Ljava/lang/String;", "GetGetIconHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIcon.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual string Id
			{
				[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual string Text
			{
				[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected ActionButton(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe ActionButton()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "")]
			public unsafe ActionButton(string id, string text, string icon)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.NewString(id);
				IntPtr intPtr2 = JNIEnv.NewString(text);
				IntPtr intPtr3 = JNIEnv.NewString(icon);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					ptr[2] = new JniArgumentValue(intPtr3);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					JNIEnv.DeleteLocalRef(intPtr3);
				}
			}

			[Register(".ctor", "(Lorg/json/JSONObject;)V", "")]
			public unsafe ActionButton(JSONObject jsonObject)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(jsonObject?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/json/JSONObject;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lorg/json/JSONObject;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(jsonObject);
				}
			}

			private static Delegate GetGetIconHandler()
			{
				if ((object)cb_getIcon == null)
				{
					cb_getIcon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIcon));
				}
				return cb_getIcon;
			}

			private static IntPtr n_GetIcon(IntPtr jnienv, IntPtr native__this)
			{
				ActionButton actionButton = Java.Lang.Object.GetObject<ActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(actionButton.Icon);
			}

			private static Delegate GetGetIdHandler()
			{
				if ((object)cb_getId == null)
				{
					cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
				}
				return cb_getId;
			}

			private static IntPtr n_GetId(IntPtr jnienv, IntPtr native__this)
			{
				ActionButton actionButton = Java.Lang.Object.GetObject<ActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(actionButton.Id);
			}

			private static Delegate GetGetTextHandler()
			{
				if ((object)cb_getText == null)
				{
					cb_getText = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetText));
				}
				return cb_getText;
			}

			private static IntPtr n_GetText(IntPtr jnienv, IntPtr native__this)
			{
				ActionButton actionButton = Java.Lang.Object.GetObject<ActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(actionButton.Text);
			}

			private static Delegate GetToJSONObjectHandler()
			{
				if ((object)cb_toJSONObject == null)
				{
					cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
				}
				return cb_toJSONObject;
			}

			private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
			{
				ActionButton actionButton = Java.Lang.Object.GetObject<ActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(actionButton.ToJSONObject());
			}

			[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
			public unsafe virtual JSONObject ToJSONObject()
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/onesignal/OSNotification$BackgroundImageLayout", DoNotGenerateAcw = true)]
		public class BackgroundImageLayout : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotification$BackgroundImageLayout", typeof(BackgroundImageLayout));

			private static Delegate cb_getBodyTextColor;

			private static Delegate cb_getImage;

			private static Delegate cb_getTitleTextColor;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual string BodyTextColor
			{
				[Register("getBodyTextColor", "()Ljava/lang/String;", "GetGetBodyTextColorHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getBodyTextColor.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual string Image
			{
				[Register("getImage", "()Ljava/lang/String;", "GetGetImageHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getImage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe virtual string TitleTextColor
			{
				[Register("getTitleTextColor", "()Ljava/lang/String;", "GetGetTitleTextColorHandler")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitleTextColor.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected BackgroundImageLayout(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe BackgroundImageLayout()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetGetBodyTextColorHandler()
			{
				if ((object)cb_getBodyTextColor == null)
				{
					cb_getBodyTextColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBodyTextColor));
				}
				return cb_getBodyTextColor;
			}

			private static IntPtr n_GetBodyTextColor(IntPtr jnienv, IntPtr native__this)
			{
				BackgroundImageLayout backgroundImageLayout = Java.Lang.Object.GetObject<BackgroundImageLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(backgroundImageLayout.BodyTextColor);
			}

			private static Delegate GetGetImageHandler()
			{
				if ((object)cb_getImage == null)
				{
					cb_getImage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImage));
				}
				return cb_getImage;
			}

			private static IntPtr n_GetImage(IntPtr jnienv, IntPtr native__this)
			{
				BackgroundImageLayout backgroundImageLayout = Java.Lang.Object.GetObject<BackgroundImageLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(backgroundImageLayout.Image);
			}

			private static Delegate GetGetTitleTextColorHandler()
			{
				if ((object)cb_getTitleTextColor == null)
				{
					cb_getTitleTextColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTitleTextColor));
				}
				return cb_getTitleTextColor;
			}

			private static IntPtr n_GetTitleTextColor(IntPtr jnienv, IntPtr native__this)
			{
				BackgroundImageLayout backgroundImageLayout = Java.Lang.Object.GetObject<BackgroundImageLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(backgroundImageLayout.TitleTextColor);
			}
		}

		[Register("com/onesignal/OSNotification$OSNotificationBuilder", DoNotGenerateAcw = true)]
		public class OSNotificationBuilder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotification$OSNotificationBuilder", typeof(OSNotificationBuilder));

			private static Delegate cb_build;

			private static Delegate cb_setActionButtons_Ljava_util_List_;

			private static Delegate cb_setAdditionalData_Lorg_json_JSONObject_;

			private static Delegate cb_setAndroidNotificationId_I;

			private static Delegate cb_setBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_;

			private static Delegate cb_setBigPicture_Ljava_lang_String_;

			private static Delegate cb_setBody_Ljava_lang_String_;

			private static Delegate cb_setCollapseId_Ljava_lang_String_;

			private static Delegate cb_setFromProjectNumber_Ljava_lang_String_;

			private static Delegate cb_setGroupKey_Ljava_lang_String_;

			private static Delegate cb_setGroupMessage_Ljava_lang_String_;

			private static Delegate cb_setGroupedNotifications_Ljava_util_List_;

			private static Delegate cb_setLargeIcon_Ljava_lang_String_;

			private static Delegate cb_setLaunchURL_Ljava_lang_String_;

			private static Delegate cb_setLedColor_Ljava_lang_String_;

			private static Delegate cb_setLockScreenVisibility_I;

			private static Delegate cb_setNotificationId_Ljava_lang_String_;

			private static Delegate cb_setPriority_I;

			private static Delegate cb_setRawPayload_Ljava_lang_String_;

			private static Delegate cb_setSenttime_J;

			private static Delegate cb_setSmallIcon_Ljava_lang_String_;

			private static Delegate cb_setSmallIconAccentColor_Ljava_lang_String_;

			private static Delegate cb_setSound_Ljava_lang_String_;

			private static Delegate cb_setTTL_I;

			private static Delegate cb_setTemplateId_Ljava_lang_String_;

			private static Delegate cb_setTemplateName_Ljava_lang_String_;

			private static Delegate cb_setTitle_Ljava_lang_String_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected OSNotificationBuilder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe OSNotificationBuilder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetBuildHandler()
			{
				if ((object)cb_build == null)
				{
					cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
				}
				return cb_build;
			}

			private static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.Build());
			}

			[Register("build", "()Lcom/onesignal/OSNotification;", "GetBuildHandler")]
			public unsafe virtual OSNotification Build()
			{
				return Java.Lang.Object.GetObject<OSNotification>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/onesignal/OSNotification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetActionButtons_Ljava_util_List_Handler()
			{
				if ((object)cb_setActionButtons_Ljava_util_List_ == null)
				{
					cb_setActionButtons_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetActionButtons_Ljava_util_List_));
				}
				return cb_setActionButtons_Ljava_util_List_;
			}

			private static IntPtr n_SetActionButtons_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_actionButtons)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<ActionButton> actionButtons = JavaList<ActionButton>.FromJniHandle(native_actionButtons, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetActionButtons(actionButtons));
			}

			[Register("setActionButtons", "(Ljava/util/List;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetActionButtons_Ljava_util_List_Handler")]
			public unsafe virtual OSNotificationBuilder SetActionButtons(IList<ActionButton> actionButtons)
			{
				IntPtr intPtr = JavaList<ActionButton>.ToLocalJniHandle(actionButtons);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setActionButtons.(Ljava/util/List;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(actionButtons);
				}
			}

			private static Delegate GetSetAdditionalData_Lorg_json_JSONObject_Handler()
			{
				if ((object)cb_setAdditionalData_Lorg_json_JSONObject_ == null)
				{
					cb_setAdditionalData_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetAdditionalData_Lorg_json_JSONObject_));
				}
				return cb_setAdditionalData_Lorg_json_JSONObject_;
			}

			private static IntPtr n_SetAdditionalData_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_additionalData)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				JSONObject additionalData = Java.Lang.Object.GetObject<JSONObject>(native_additionalData, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetAdditionalData(additionalData));
			}

			[Register("setAdditionalData", "(Lorg/json/JSONObject;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetAdditionalData_Lorg_json_JSONObject_Handler")]
			public unsafe virtual OSNotificationBuilder SetAdditionalData(JSONObject additionalData)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(additionalData?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAdditionalData.(Lorg/json/JSONObject;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(additionalData);
				}
			}

			private static Delegate GetSetAndroidNotificationId_IHandler()
			{
				if ((object)cb_setAndroidNotificationId_I == null)
				{
					cb_setAndroidNotificationId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetAndroidNotificationId_I));
				}
				return cb_setAndroidNotificationId_I;
			}

			private static IntPtr n_SetAndroidNotificationId_I(IntPtr jnienv, IntPtr native__this, int androidNotificationId)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetAndroidNotificationId(androidNotificationId));
			}

			[Register("setAndroidNotificationId", "(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetAndroidNotificationId_IHandler")]
			public unsafe virtual OSNotificationBuilder SetAndroidNotificationId(int androidNotificationId)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(androidNotificationId);
				return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAndroidNotificationId.(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_Handler()
			{
				if ((object)cb_setBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_ == null)
				{
					cb_setBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_));
				}
				return cb_setBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_;
			}

			private static IntPtr n_SetBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_(IntPtr jnienv, IntPtr native__this, IntPtr native_backgroundImageLayout)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				BackgroundImageLayout backgroundImageLayout = Java.Lang.Object.GetObject<BackgroundImageLayout>(native_backgroundImageLayout, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetBackgroundImageLayout(backgroundImageLayout));
			}

			[Register("setBackgroundImageLayout", "(Lcom/onesignal/OSNotification$BackgroundImageLayout;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetBackgroundImageLayout_Lcom_onesignal_OSNotification_BackgroundImageLayout_Handler")]
			public unsafe virtual OSNotificationBuilder SetBackgroundImageLayout(BackgroundImageLayout backgroundImageLayout)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(backgroundImageLayout?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBackgroundImageLayout.(Lcom/onesignal/OSNotification$BackgroundImageLayout;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(backgroundImageLayout);
				}
			}

			private static Delegate GetSetBigPicture_Ljava_lang_String_Handler()
			{
				if ((object)cb_setBigPicture_Ljava_lang_String_ == null)
				{
					cb_setBigPicture_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBigPicture_Ljava_lang_String_));
				}
				return cb_setBigPicture_Ljava_lang_String_;
			}

			private static IntPtr n_SetBigPicture_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_bigPicture)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string bigPicture = JNIEnv.GetString(native_bigPicture, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetBigPicture(bigPicture));
			}

			[Register("setBigPicture", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetBigPicture_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetBigPicture(string bigPicture)
			{
				IntPtr intPtr = JNIEnv.NewString(bigPicture);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBigPicture.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetBody_Ljava_lang_String_Handler()
			{
				if ((object)cb_setBody_Ljava_lang_String_ == null)
				{
					cb_setBody_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBody_Ljava_lang_String_));
				}
				return cb_setBody_Ljava_lang_String_;
			}

			private static IntPtr n_SetBody_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_body)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string body = JNIEnv.GetString(native_body, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetBody(body));
			}

			[Register("setBody", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetBody_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetBody(string body)
			{
				IntPtr intPtr = JNIEnv.NewString(body);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBody.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetCollapseId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setCollapseId_Ljava_lang_String_ == null)
				{
					cb_setCollapseId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCollapseId_Ljava_lang_String_));
				}
				return cb_setCollapseId_Ljava_lang_String_;
			}

			private static IntPtr n_SetCollapseId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_collapseId)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string collapseId = JNIEnv.GetString(native_collapseId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetCollapseId(collapseId));
			}

			[Register("setCollapseId", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetCollapseId_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetCollapseId(string collapseId)
			{
				IntPtr intPtr = JNIEnv.NewString(collapseId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCollapseId.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetFromProjectNumber_Ljava_lang_String_Handler()
			{
				if ((object)cb_setFromProjectNumber_Ljava_lang_String_ == null)
				{
					cb_setFromProjectNumber_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFromProjectNumber_Ljava_lang_String_));
				}
				return cb_setFromProjectNumber_Ljava_lang_String_;
			}

			private static IntPtr n_SetFromProjectNumber_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_fromProjectNumber)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string fromProjectNumber = JNIEnv.GetString(native_fromProjectNumber, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetFromProjectNumber(fromProjectNumber));
			}

			[Register("setFromProjectNumber", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetFromProjectNumber_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetFromProjectNumber(string fromProjectNumber)
			{
				IntPtr intPtr = JNIEnv.NewString(fromProjectNumber);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFromProjectNumber.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetGroupKey_Ljava_lang_String_Handler()
			{
				if ((object)cb_setGroupKey_Ljava_lang_String_ == null)
				{
					cb_setGroupKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetGroupKey_Ljava_lang_String_));
				}
				return cb_setGroupKey_Ljava_lang_String_;
			}

			private static IntPtr n_SetGroupKey_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_groupKey)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string groupKey = JNIEnv.GetString(native_groupKey, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetGroupKey(groupKey));
			}

			[Register("setGroupKey", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetGroupKey_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetGroupKey(string groupKey)
			{
				IntPtr intPtr = JNIEnv.NewString(groupKey);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setGroupKey.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetGroupMessage_Ljava_lang_String_Handler()
			{
				if ((object)cb_setGroupMessage_Ljava_lang_String_ == null)
				{
					cb_setGroupMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetGroupMessage_Ljava_lang_String_));
				}
				return cb_setGroupMessage_Ljava_lang_String_;
			}

			private static IntPtr n_SetGroupMessage_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_groupMessage)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string groupMessage = JNIEnv.GetString(native_groupMessage, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetGroupMessage(groupMessage));
			}

			[Register("setGroupMessage", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetGroupMessage_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetGroupMessage(string groupMessage)
			{
				IntPtr intPtr = JNIEnv.NewString(groupMessage);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setGroupMessage.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetGroupedNotifications_Ljava_util_List_Handler()
			{
				if ((object)cb_setGroupedNotifications_Ljava_util_List_ == null)
				{
					cb_setGroupedNotifications_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetGroupedNotifications_Ljava_util_List_));
				}
				return cb_setGroupedNotifications_Ljava_util_List_;
			}

			private static IntPtr n_SetGroupedNotifications_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_groupedNotifications)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<OSNotification> groupedNotifications = JavaList<OSNotification>.FromJniHandle(native_groupedNotifications, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetGroupedNotifications(groupedNotifications));
			}

			[Register("setGroupedNotifications", "(Ljava/util/List;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetGroupedNotifications_Ljava_util_List_Handler")]
			public unsafe virtual OSNotificationBuilder SetGroupedNotifications(IList<OSNotification> groupedNotifications)
			{
				IntPtr intPtr = JavaList<OSNotification>.ToLocalJniHandle(groupedNotifications);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setGroupedNotifications.(Ljava/util/List;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(groupedNotifications);
				}
			}

			private static Delegate GetSetLargeIcon_Ljava_lang_String_Handler()
			{
				if ((object)cb_setLargeIcon_Ljava_lang_String_ == null)
				{
					cb_setLargeIcon_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLargeIcon_Ljava_lang_String_));
				}
				return cb_setLargeIcon_Ljava_lang_String_;
			}

			private static IntPtr n_SetLargeIcon_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_largeIcon)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string largeIcon = JNIEnv.GetString(native_largeIcon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetLargeIcon(largeIcon));
			}

			[Register("setLargeIcon", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetLargeIcon_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetLargeIcon(string largeIcon)
			{
				IntPtr intPtr = JNIEnv.NewString(largeIcon);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLargeIcon.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetLaunchURL_Ljava_lang_String_Handler()
			{
				if ((object)cb_setLaunchURL_Ljava_lang_String_ == null)
				{
					cb_setLaunchURL_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLaunchURL_Ljava_lang_String_));
				}
				return cb_setLaunchURL_Ljava_lang_String_;
			}

			private static IntPtr n_SetLaunchURL_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_launchURL)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string launchURL = JNIEnv.GetString(native_launchURL, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetLaunchURL(launchURL));
			}

			[Register("setLaunchURL", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetLaunchURL_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetLaunchURL(string launchURL)
			{
				IntPtr intPtr = JNIEnv.NewString(launchURL);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLaunchURL.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetLedColor_Ljava_lang_String_Handler()
			{
				if ((object)cb_setLedColor_Ljava_lang_String_ == null)
				{
					cb_setLedColor_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLedColor_Ljava_lang_String_));
				}
				return cb_setLedColor_Ljava_lang_String_;
			}

			private static IntPtr n_SetLedColor_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_ledColor)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string ledColor = JNIEnv.GetString(native_ledColor, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetLedColor(ledColor));
			}

			[Register("setLedColor", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetLedColor_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetLedColor(string ledColor)
			{
				IntPtr intPtr = JNIEnv.NewString(ledColor);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLedColor.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetLockScreenVisibility_IHandler()
			{
				if ((object)cb_setLockScreenVisibility_I == null)
				{
					cb_setLockScreenVisibility_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetLockScreenVisibility_I));
				}
				return cb_setLockScreenVisibility_I;
			}

			private static IntPtr n_SetLockScreenVisibility_I(IntPtr jnienv, IntPtr native__this, int lockScreenVisibility)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetLockScreenVisibility(lockScreenVisibility));
			}

			[Register("setLockScreenVisibility", "(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetLockScreenVisibility_IHandler")]
			public unsafe virtual OSNotificationBuilder SetLockScreenVisibility(int lockScreenVisibility)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(lockScreenVisibility);
				return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLockScreenVisibility.(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetNotificationId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setNotificationId_Ljava_lang_String_ == null)
				{
					cb_setNotificationId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetNotificationId_Ljava_lang_String_));
				}
				return cb_setNotificationId_Ljava_lang_String_;
			}

			private static IntPtr n_SetNotificationId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_notificationId)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string notificationId = JNIEnv.GetString(native_notificationId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetNotificationId(notificationId));
			}

			[Register("setNotificationId", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetNotificationId_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetNotificationId(string notificationId)
			{
				IntPtr intPtr = JNIEnv.NewString(notificationId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNotificationId.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetPriority_IHandler()
			{
				if ((object)cb_setPriority_I == null)
				{
					cb_setPriority_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPriority_I));
				}
				return cb_setPriority_I;
			}

			private static IntPtr n_SetPriority_I(IntPtr jnienv, IntPtr native__this, int priority)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetPriority(priority));
			}

			[Register("setPriority", "(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetPriority_IHandler")]
			public unsafe virtual OSNotificationBuilder SetPriority(int priority)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(priority);
				return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPriority.(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetRawPayload_Ljava_lang_String_Handler()
			{
				if ((object)cb_setRawPayload_Ljava_lang_String_ == null)
				{
					cb_setRawPayload_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetRawPayload_Ljava_lang_String_));
				}
				return cb_setRawPayload_Ljava_lang_String_;
			}

			private static IntPtr n_SetRawPayload_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_rawPayload)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string rawPayload = JNIEnv.GetString(native_rawPayload, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetRawPayload(rawPayload));
			}

			[Register("setRawPayload", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetRawPayload_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetRawPayload(string rawPayload)
			{
				IntPtr intPtr = JNIEnv.NewString(rawPayload);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRawPayload.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetSenttime_JHandler()
			{
				if ((object)cb_setSenttime_J == null)
				{
					cb_setSenttime_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetSenttime_J));
				}
				return cb_setSenttime_J;
			}

			private static IntPtr n_SetSenttime_J(IntPtr jnienv, IntPtr native__this, long sentTime)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetSenttime(sentTime));
			}

			[Register("setSenttime", "(J)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetSenttime_JHandler")]
			public unsafe virtual OSNotificationBuilder SetSenttime(long sentTime)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sentTime);
				return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSenttime.(J)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetSmallIcon_Ljava_lang_String_Handler()
			{
				if ((object)cb_setSmallIcon_Ljava_lang_String_ == null)
				{
					cb_setSmallIcon_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSmallIcon_Ljava_lang_String_));
				}
				return cb_setSmallIcon_Ljava_lang_String_;
			}

			private static IntPtr n_SetSmallIcon_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_smallIcon)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string smallIcon = JNIEnv.GetString(native_smallIcon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetSmallIcon(smallIcon));
			}

			[Register("setSmallIcon", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetSmallIcon_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetSmallIcon(string smallIcon)
			{
				IntPtr intPtr = JNIEnv.NewString(smallIcon);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSmallIcon.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetSmallIconAccentColor_Ljava_lang_String_Handler()
			{
				if ((object)cb_setSmallIconAccentColor_Ljava_lang_String_ == null)
				{
					cb_setSmallIconAccentColor_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSmallIconAccentColor_Ljava_lang_String_));
				}
				return cb_setSmallIconAccentColor_Ljava_lang_String_;
			}

			private static IntPtr n_SetSmallIconAccentColor_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_smallIconAccentColor)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string smallIconAccentColor = JNIEnv.GetString(native_smallIconAccentColor, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetSmallIconAccentColor(smallIconAccentColor));
			}

			[Register("setSmallIconAccentColor", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetSmallIconAccentColor_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetSmallIconAccentColor(string smallIconAccentColor)
			{
				IntPtr intPtr = JNIEnv.NewString(smallIconAccentColor);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSmallIconAccentColor.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetSound_Ljava_lang_String_Handler()
			{
				if ((object)cb_setSound_Ljava_lang_String_ == null)
				{
					cb_setSound_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSound_Ljava_lang_String_));
				}
				return cb_setSound_Ljava_lang_String_;
			}

			private static IntPtr n_SetSound_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_sound)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string sound = JNIEnv.GetString(native_sound, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetSound(sound));
			}

			[Register("setSound", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetSound_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetSound(string sound)
			{
				IntPtr intPtr = JNIEnv.NewString(sound);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSound.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetTTL_IHandler()
			{
				if ((object)cb_setTTL_I == null)
				{
					cb_setTTL_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTTL_I));
				}
				return cb_setTTL_I;
			}

			private static IntPtr n_SetTTL_I(IntPtr jnienv, IntPtr native__this, int ttl)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetTTL(ttl));
			}

			[Register("setTTL", "(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetTTL_IHandler")]
			public unsafe virtual OSNotificationBuilder SetTTL(int ttl)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(ttl);
				return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTTL.(I)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetTemplateId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTemplateId_Ljava_lang_String_ == null)
				{
					cb_setTemplateId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTemplateId_Ljava_lang_String_));
				}
				return cb_setTemplateId_Ljava_lang_String_;
			}

			private static IntPtr n_SetTemplateId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_templateId)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string templateId = JNIEnv.GetString(native_templateId, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetTemplateId(templateId));
			}

			[Register("setTemplateId", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetTemplateId_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetTemplateId(string templateId)
			{
				IntPtr intPtr = JNIEnv.NewString(templateId);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTemplateId.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetTemplateName_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTemplateName_Ljava_lang_String_ == null)
				{
					cb_setTemplateName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTemplateName_Ljava_lang_String_));
				}
				return cb_setTemplateName_Ljava_lang_String_;
			}

			private static IntPtr n_SetTemplateName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_templateName)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string templateName = JNIEnv.GetString(native_templateName, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetTemplateName(templateName));
			}

			[Register("setTemplateName", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetTemplateName_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetTemplateName(string templateName)
			{
				IntPtr intPtr = JNIEnv.NewString(templateName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTemplateName.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetSetTitle_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTitle_Ljava_lang_String_ == null)
				{
					cb_setTitle_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTitle_Ljava_lang_String_));
				}
				return cb_setTitle_Ljava_lang_String_;
			}

			private static IntPtr n_SetTitle_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_title)
			{
				OSNotificationBuilder oSNotificationBuilder = Java.Lang.Object.GetObject<OSNotificationBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string title = JNIEnv.GetString(native_title, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(oSNotificationBuilder.SetTitle(title));
			}

			[Register("setTitle", "(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", "GetSetTitle_Ljava_lang_String_Handler")]
			public unsafe virtual OSNotificationBuilder SetTitle(string title)
			{
				IntPtr intPtr = JNIEnv.NewString(title);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<OSNotificationBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(Ljava/lang/String;)Lcom/onesignal/OSNotification$OSNotificationBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotification", typeof(OSNotification));

		private static Delegate cb_getActionButtons;

		private static Delegate cb_getAdditionalData;

		private static Delegate cb_getAndroidNotificationId;

		private static Delegate cb_getBigPicture;

		private static Delegate cb_getBody;

		private static Delegate cb_getCollapseId;

		private static Delegate cb_getFromProjectNumber;

		private static Delegate cb_getGroupKey;

		private static Delegate cb_getGroupMessage;

		private static Delegate cb_getGroupedNotifications;

		private static Delegate cb_getLargeIcon;

		private static Delegate cb_getLaunchURL;

		private static Delegate cb_getLedColor;

		private static Delegate cb_getLockScreenVisibility;

		private static Delegate cb_getNotificationId;

		private static Delegate cb_getPriority;

		private static Delegate cb_getRawPayload;

		private static Delegate cb_getSentTime;

		private static Delegate cb_getSmallIcon;

		private static Delegate cb_getSmallIconAccentColor;

		private static Delegate cb_getSound;

		private static Delegate cb_getTemplateId;

		private static Delegate cb_getTemplateName;

		private static Delegate cb_getTitle;

		private static Delegate cb_getTtl;

		private static Delegate cb_getBackgroundImageLayout;

		private static Delegate cb_mutableCopy;

		private static Delegate cb_setAndroidNotificationId_I;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<ActionButton> ActionButtons
		{
			[Register("getActionButtons", "()Ljava/util/List;", "GetGetActionButtonsHandler")]
			get
			{
				return JavaList<ActionButton>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionButtons.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual JSONObject AdditionalData
		{
			[Register("getAdditionalData", "()Lorg/json/JSONObject;", "GetGetAdditionalDataHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdditionalData.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int AndroidNotificationId
		{
			[Register("getAndroidNotificationId", "()I", "GetGetAndroidNotificationIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAndroidNotificationId.()I", this, null);
			}
		}

		public unsafe virtual string BigPicture
		{
			[Register("getBigPicture", "()Ljava/lang/String;", "GetGetBigPictureHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getBigPicture.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Body
		{
			[Register("getBody", "()Ljava/lang/String;", "GetGetBodyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getBody.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string CollapseId
		{
			[Register("getCollapseId", "()Ljava/lang/String;", "GetGetCollapseIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCollapseId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string FromProjectNumber
		{
			[Register("getFromProjectNumber", "()Ljava/lang/String;", "GetGetFromProjectNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getFromProjectNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string GroupKey
		{
			[Register("getGroupKey", "()Ljava/lang/String;", "GetGetGroupKeyHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getGroupKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string GroupMessage
		{
			[Register("getGroupMessage", "()Ljava/lang/String;", "GetGetGroupMessageHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getGroupMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<OSNotification> GroupedNotifications
		{
			[Register("getGroupedNotifications", "()Ljava/util/List;", "GetGetGroupedNotificationsHandler")]
			get
			{
				return JavaList<OSNotification>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getGroupedNotifications.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string LargeIcon
		{
			[Register("getLargeIcon", "()Ljava/lang/String;", "GetGetLargeIconHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLargeIcon.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string LaunchURL
		{
			[Register("getLaunchURL", "()Ljava/lang/String;", "GetGetLaunchURLHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLaunchURL.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string LedColor
		{
			[Register("getLedColor", "()Ljava/lang/String;", "GetGetLedColorHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLedColor.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int LockScreenVisibility
		{
			[Register("getLockScreenVisibility", "()I", "GetGetLockScreenVisibilityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLockScreenVisibility.()I", this, null);
			}
		}

		public unsafe virtual string NotificationId
		{
			[Register("getNotificationId", "()Ljava/lang/String;", "GetGetNotificationIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotificationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Priority
		{
			[Register("getPriority", "()I", "GetGetPriorityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPriority.()I", this, null);
			}
		}

		public unsafe virtual string RawPayload
		{
			[Register("getRawPayload", "()Ljava/lang/String;", "GetGetRawPayloadHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getRawPayload.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long SentTime
		{
			[Register("getSentTime", "()J", "GetGetSentTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getSentTime.()J", this, null);
			}
		}

		public unsafe virtual string SmallIcon
		{
			[Register("getSmallIcon", "()Ljava/lang/String;", "GetGetSmallIconHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSmallIcon.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SmallIconAccentColor
		{
			[Register("getSmallIconAccentColor", "()Ljava/lang/String;", "GetGetSmallIconAccentColorHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSmallIconAccentColor.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Sound
		{
			[Register("getSound", "()Ljava/lang/String;", "GetGetSoundHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSound.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string TemplateId
		{
			[Register("getTemplateId", "()Ljava/lang/String;", "GetGetTemplateIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTemplateId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string TemplateName
		{
			[Register("getTemplateName", "()Ljava/lang/String;", "GetGetTemplateNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTemplateName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "GetGetTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Ttl
		{
			[Register("getTtl", "()I", "GetGetTtlHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTtl.()I", this, null);
			}
		}

		protected OSNotification(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe OSNotification()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lcom/onesignal/OSNotification;)V", "")]
		protected unsafe OSNotification(OSNotification notification)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSNotification;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSNotification;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notification);
			}
		}

		private static Delegate GetGetActionButtonsHandler()
		{
			if ((object)cb_getActionButtons == null)
			{
				cb_getActionButtons = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActionButtons));
			}
			return cb_getActionButtons;
		}

		private static IntPtr n_GetActionButtons(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<ActionButton>.ToLocalJniHandle(oSNotification.ActionButtons);
		}

		private static Delegate GetGetAdditionalDataHandler()
		{
			if ((object)cb_getAdditionalData == null)
			{
				cb_getAdditionalData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAdditionalData));
			}
			return cb_getAdditionalData;
		}

		private static IntPtr n_GetAdditionalData(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotification.AdditionalData);
		}

		private static Delegate GetGetAndroidNotificationIdHandler()
		{
			if ((object)cb_getAndroidNotificationId == null)
			{
				cb_getAndroidNotificationId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAndroidNotificationId));
			}
			return cb_getAndroidNotificationId;
		}

		private static int n_GetAndroidNotificationId(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotification.AndroidNotificationId;
		}

		private static Delegate GetGetBigPictureHandler()
		{
			if ((object)cb_getBigPicture == null)
			{
				cb_getBigPicture = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBigPicture));
			}
			return cb_getBigPicture;
		}

		private static IntPtr n_GetBigPicture(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.BigPicture);
		}

		private static Delegate GetGetBodyHandler()
		{
			if ((object)cb_getBody == null)
			{
				cb_getBody = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBody));
			}
			return cb_getBody;
		}

		private static IntPtr n_GetBody(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.Body);
		}

		private static Delegate GetGetCollapseIdHandler()
		{
			if ((object)cb_getCollapseId == null)
			{
				cb_getCollapseId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCollapseId));
			}
			return cb_getCollapseId;
		}

		private static IntPtr n_GetCollapseId(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.CollapseId);
		}

		private static Delegate GetGetFromProjectNumberHandler()
		{
			if ((object)cb_getFromProjectNumber == null)
			{
				cb_getFromProjectNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFromProjectNumber));
			}
			return cb_getFromProjectNumber;
		}

		private static IntPtr n_GetFromProjectNumber(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.FromProjectNumber);
		}

		private static Delegate GetGetGroupKeyHandler()
		{
			if ((object)cb_getGroupKey == null)
			{
				cb_getGroupKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGroupKey));
			}
			return cb_getGroupKey;
		}

		private static IntPtr n_GetGroupKey(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.GroupKey);
		}

		private static Delegate GetGetGroupMessageHandler()
		{
			if ((object)cb_getGroupMessage == null)
			{
				cb_getGroupMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGroupMessage));
			}
			return cb_getGroupMessage;
		}

		private static IntPtr n_GetGroupMessage(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.GroupMessage);
		}

		private static Delegate GetGetGroupedNotificationsHandler()
		{
			if ((object)cb_getGroupedNotifications == null)
			{
				cb_getGroupedNotifications = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGroupedNotifications));
			}
			return cb_getGroupedNotifications;
		}

		private static IntPtr n_GetGroupedNotifications(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaList<OSNotification>.ToLocalJniHandle(oSNotification.GroupedNotifications);
		}

		private static Delegate GetGetLargeIconHandler()
		{
			if ((object)cb_getLargeIcon == null)
			{
				cb_getLargeIcon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLargeIcon));
			}
			return cb_getLargeIcon;
		}

		private static IntPtr n_GetLargeIcon(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.LargeIcon);
		}

		private static Delegate GetGetLaunchURLHandler()
		{
			if ((object)cb_getLaunchURL == null)
			{
				cb_getLaunchURL = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLaunchURL));
			}
			return cb_getLaunchURL;
		}

		private static IntPtr n_GetLaunchURL(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.LaunchURL);
		}

		private static Delegate GetGetLedColorHandler()
		{
			if ((object)cb_getLedColor == null)
			{
				cb_getLedColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLedColor));
			}
			return cb_getLedColor;
		}

		private static IntPtr n_GetLedColor(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.LedColor);
		}

		private static Delegate GetGetLockScreenVisibilityHandler()
		{
			if ((object)cb_getLockScreenVisibility == null)
			{
				cb_getLockScreenVisibility = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLockScreenVisibility));
			}
			return cb_getLockScreenVisibility;
		}

		private static int n_GetLockScreenVisibility(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotification.LockScreenVisibility;
		}

		private static Delegate GetGetNotificationIdHandler()
		{
			if ((object)cb_getNotificationId == null)
			{
				cb_getNotificationId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotificationId));
			}
			return cb_getNotificationId;
		}

		private static IntPtr n_GetNotificationId(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.NotificationId);
		}

		private static Delegate GetGetPriorityHandler()
		{
			if ((object)cb_getPriority == null)
			{
				cb_getPriority = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPriority));
			}
			return cb_getPriority;
		}

		private static int n_GetPriority(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotification.Priority;
		}

		private static Delegate GetGetRawPayloadHandler()
		{
			if ((object)cb_getRawPayload == null)
			{
				cb_getRawPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRawPayload));
			}
			return cb_getRawPayload;
		}

		private static IntPtr n_GetRawPayload(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.RawPayload);
		}

		private static Delegate GetGetSentTimeHandler()
		{
			if ((object)cb_getSentTime == null)
			{
				cb_getSentTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetSentTime));
			}
			return cb_getSentTime;
		}

		private static long n_GetSentTime(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotification.SentTime;
		}

		private static Delegate GetGetSmallIconHandler()
		{
			if ((object)cb_getSmallIcon == null)
			{
				cb_getSmallIcon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSmallIcon));
			}
			return cb_getSmallIcon;
		}

		private static IntPtr n_GetSmallIcon(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.SmallIcon);
		}

		private static Delegate GetGetSmallIconAccentColorHandler()
		{
			if ((object)cb_getSmallIconAccentColor == null)
			{
				cb_getSmallIconAccentColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSmallIconAccentColor));
			}
			return cb_getSmallIconAccentColor;
		}

		private static IntPtr n_GetSmallIconAccentColor(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.SmallIconAccentColor);
		}

		private static Delegate GetGetSoundHandler()
		{
			if ((object)cb_getSound == null)
			{
				cb_getSound = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSound));
			}
			return cb_getSound;
		}

		private static IntPtr n_GetSound(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.Sound);
		}

		private static Delegate GetGetTemplateIdHandler()
		{
			if ((object)cb_getTemplateId == null)
			{
				cb_getTemplateId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTemplateId));
			}
			return cb_getTemplateId;
		}

		private static IntPtr n_GetTemplateId(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.TemplateId);
		}

		private static Delegate GetGetTemplateNameHandler()
		{
			if ((object)cb_getTemplateName == null)
			{
				cb_getTemplateName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTemplateName));
			}
			return cb_getTemplateName;
		}

		private static IntPtr n_GetTemplateName(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.TemplateName);
		}

		private static Delegate GetGetTitleHandler()
		{
			if ((object)cb_getTitle == null)
			{
				cb_getTitle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTitle));
			}
			return cb_getTitle;
		}

		private static IntPtr n_GetTitle(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotification.Title);
		}

		private static Delegate GetGetTtlHandler()
		{
			if ((object)cb_getTtl == null)
			{
				cb_getTtl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTtl));
			}
			return cb_getTtl;
		}

		private static int n_GetTtl(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotification.Ttl;
		}

		private static Delegate GetGetBackgroundImageLayoutHandler()
		{
			if ((object)cb_getBackgroundImageLayout == null)
			{
				cb_getBackgroundImageLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBackgroundImageLayout));
			}
			return cb_getBackgroundImageLayout;
		}

		private static IntPtr n_GetBackgroundImageLayout(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotification.GetBackgroundImageLayout());
		}

		[Register("getBackgroundImageLayout", "()Lcom/onesignal/OSNotification$BackgroundImageLayout;", "GetGetBackgroundImageLayoutHandler")]
		public unsafe virtual BackgroundImageLayout GetBackgroundImageLayout()
		{
			return Java.Lang.Object.GetObject<BackgroundImageLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBackgroundImageLayout.()Lcom/onesignal/OSNotification$BackgroundImageLayout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMutableCopyHandler()
		{
			if ((object)cb_mutableCopy == null)
			{
				cb_mutableCopy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_MutableCopy));
			}
			return cb_mutableCopy;
		}

		private static IntPtr n_MutableCopy(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotification.MutableCopy());
		}

		[Register("mutableCopy", "()Lcom/onesignal/OSMutableNotification;", "GetMutableCopyHandler")]
		public unsafe virtual OSMutableNotification MutableCopy()
		{
			return Java.Lang.Object.GetObject<OSMutableNotification>(_members.InstanceMethods.InvokeVirtualObjectMethod("mutableCopy.()Lcom/onesignal/OSMutableNotification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetAndroidNotificationId_IHandler()
		{
			if ((object)cb_setAndroidNotificationId_I == null)
			{
				cb_setAndroidNotificationId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetAndroidNotificationId_I));
			}
			return cb_setAndroidNotificationId_I;
		}

		private static void n_SetAndroidNotificationId_I(IntPtr jnienv, IntPtr native__this, int androidNotificationId)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSNotification.SetAndroidNotificationId(androidNotificationId);
		}

		[Register("setAndroidNotificationId", "(I)V", "GetSetAndroidNotificationId_IHandler")]
		protected unsafe virtual void SetAndroidNotificationId(int androidNotificationId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(androidNotificationId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAndroidNotificationId.(I)V", this, ptr);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSNotification oSNotification = Java.Lang.Object.GetObject<OSNotification>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotification.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSNotificationAction", DoNotGenerateAcw = true)]
	public class OSNotificationAction : Java.Lang.Object
	{
		[Register("com/onesignal/OSNotificationAction$ActionType", DoNotGenerateAcw = true)]
		public sealed class ActionType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationAction$ActionType", typeof(ActionType));

			[Register("ActionTaken")]
			public static ActionType ActionTaken => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("ActionTaken.Lcom/onesignal/OSNotificationAction$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("Opened")]
			public static ActionType Opened => Java.Lang.Object.GetObject<ActionType>(_members.StaticFields.GetObjectValue("Opened.Lcom/onesignal/OSNotificationAction$ActionType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal ActionType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/onesignal/OSNotificationAction$ActionType;", "")]
			public unsafe static ActionType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ActionType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/onesignal/OSNotificationAction$ActionType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/onesignal/OSNotificationAction$ActionType;", "")]
			public unsafe static ActionType[] Values()
			{
				return (ActionType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/onesignal/OSNotificationAction$ActionType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ActionType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationAction", typeof(OSNotificationAction));

		private static Delegate cb_getActionId;

		private static Delegate cb_getType;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string ActionId
		{
			[Register("getActionId", "()Ljava/lang/String;", "GetGetActionIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ActionType Type
		{
			[Register("getType", "()Lcom/onesignal/OSNotificationAction$ActionType;", "GetGetTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ActionType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Lcom/onesignal/OSNotificationAction$ActionType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSNotificationAction(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSNotificationAction$ActionType;Ljava/lang/String;)V", "")]
		public unsafe OSNotificationAction(ActionType type, string actionId)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(actionId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSNotificationAction$ActionType;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSNotificationAction$ActionType;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetGetActionIdHandler()
		{
			if ((object)cb_getActionId == null)
			{
				cb_getActionId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActionId));
			}
			return cb_getActionId;
		}

		private static IntPtr n_GetActionId(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationAction oSNotificationAction = Java.Lang.Object.GetObject<OSNotificationAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotificationAction.ActionId);
		}

		private static Delegate GetGetTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
			}
			return cb_getType;
		}

		private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationAction oSNotificationAction = Java.Lang.Object.GetObject<OSNotificationAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationAction.Type);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationAction oSNotificationAction = Java.Lang.Object.GetObject<OSNotificationAction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationAction.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSNotificationController", DoNotGenerateAcw = true)]
	public class OSNotificationController : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationController", typeof(OSNotificationController));

		private static Delegate cb_isFromBackgroundLogic;

		private static Delegate cb_setFromBackgroundLogic_Z;

		private static Delegate cb_isNotificationWithinTTL;

		private static Delegate cb_getNotificationJob;

		private static Delegate cb_getNotificationReceivedEvent;

		private static Delegate cb_isRestoring;

		private static Delegate cb_setRestoring_Z;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool FromBackgroundLogic
		{
			[Register("isFromBackgroundLogic", "()Z", "GetIsFromBackgroundLogicHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFromBackgroundLogic.()Z", this, null);
			}
			[Register("setFromBackgroundLogic", "(Z)V", "GetSetFromBackgroundLogic_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFromBackgroundLogic.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool IsNotificationWithinTTL
		{
			[Register("isNotificationWithinTTL", "()Z", "GetIsNotificationWithinTTLHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isNotificationWithinTTL.()Z", this, null);
			}
		}

		public unsafe virtual OSNotificationGenerationJob NotificationJob
		{
			[Register("getNotificationJob", "()Lcom/onesignal/OSNotificationGenerationJob;", "GetGetNotificationJobHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotificationGenerationJob>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotificationJob.()Lcom/onesignal/OSNotificationGenerationJob;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSNotificationReceivedEvent NotificationReceivedEvent
		{
			[Register("getNotificationReceivedEvent", "()Lcom/onesignal/OSNotificationReceivedEvent;", "GetGetNotificationReceivedEventHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotificationReceivedEvent.()Lcom/onesignal/OSNotificationReceivedEvent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool Restoring
		{
			[Register("isRestoring", "()Z", "GetIsRestoringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRestoring.()Z", this, null);
			}
			[Register("setRestoring", "(Z)V", "GetSetRestoring_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRestoring.(Z)V", this, ptr);
			}
		}

		protected OSNotificationController(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetIsFromBackgroundLogicHandler()
		{
			if ((object)cb_isFromBackgroundLogic == null)
			{
				cb_isFromBackgroundLogic = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFromBackgroundLogic));
			}
			return cb_isFromBackgroundLogic;
		}

		private static bool n_IsFromBackgroundLogic(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotificationController.FromBackgroundLogic;
		}

		private static Delegate GetSetFromBackgroundLogic_ZHandler()
		{
			if ((object)cb_setFromBackgroundLogic_Z == null)
			{
				cb_setFromBackgroundLogic_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetFromBackgroundLogic_Z));
			}
			return cb_setFromBackgroundLogic_Z;
		}

		private static void n_SetFromBackgroundLogic_Z(IntPtr jnienv, IntPtr native__this, bool fromBackgroundLogic)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSNotificationController.FromBackgroundLogic = fromBackgroundLogic;
		}

		private static Delegate GetIsNotificationWithinTTLHandler()
		{
			if ((object)cb_isNotificationWithinTTL == null)
			{
				cb_isNotificationWithinTTL = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsNotificationWithinTTL));
			}
			return cb_isNotificationWithinTTL;
		}

		private static bool n_IsNotificationWithinTTL(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotificationController.IsNotificationWithinTTL;
		}

		private static Delegate GetGetNotificationJobHandler()
		{
			if ((object)cb_getNotificationJob == null)
			{
				cb_getNotificationJob = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotificationJob));
			}
			return cb_getNotificationJob;
		}

		private static IntPtr n_GetNotificationJob(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationController.NotificationJob);
		}

		private static Delegate GetGetNotificationReceivedEventHandler()
		{
			if ((object)cb_getNotificationReceivedEvent == null)
			{
				cb_getNotificationReceivedEvent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotificationReceivedEvent));
			}
			return cb_getNotificationReceivedEvent;
		}

		private static IntPtr n_GetNotificationReceivedEvent(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationController.NotificationReceivedEvent);
		}

		private static Delegate GetIsRestoringHandler()
		{
			if ((object)cb_isRestoring == null)
			{
				cb_isRestoring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRestoring));
			}
			return cb_isRestoring;
		}

		private static bool n_IsRestoring(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotificationController.Restoring;
		}

		private static Delegate GetSetRestoring_ZHandler()
		{
			if ((object)cb_setRestoring_Z == null)
			{
				cb_setRestoring_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRestoring_Z));
			}
			return cb_setRestoring_Z;
		}

		private static void n_SetRestoring_Z(IntPtr jnienv, IntPtr native__this, bool restoring)
		{
			OSNotificationController oSNotificationController = Java.Lang.Object.GetObject<OSNotificationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSNotificationController.Restoring = restoring;
		}
	}
	[Register("com/onesignal/OSNotificationGenerationJob", DoNotGenerateAcw = true)]
	public class OSNotificationGenerationJob : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationGenerationJob", typeof(OSNotificationGenerationJob));

		private static Delegate cb_getContext;

		private static Delegate cb_setContext_Landroid_content_Context_;

		private static Delegate cb_getJsonPayload;

		private static Delegate cb_setJsonPayload_Lorg_json_JSONObject_;

		private static Delegate cb_getNotification;

		private static Delegate cb_setNotification_Lcom_onesignal_OSNotification_;

		private static Delegate cb_getOrgFlags;

		private static Delegate cb_setOrgFlags_Ljava_lang_Integer_;

		private static Delegate cb_getOrgSound;

		private static Delegate cb_setOrgSound_Landroid_net_Uri_;

		private static Delegate cb_getOverriddenBodyFromExtender;

		private static Delegate cb_setOverriddenBodyFromExtender_Ljava_lang_CharSequence_;

		private static Delegate cb_getOverriddenFlags;

		private static Delegate cb_setOverriddenFlags_Ljava_lang_Integer_;

		private static Delegate cb_getOverriddenSound;

		private static Delegate cb_setOverriddenSound_Landroid_net_Uri_;

		private static Delegate cb_getOverriddenTitleFromExtender;

		private static Delegate cb_setOverriddenTitleFromExtender_Ljava_lang_CharSequence_;

		private static Delegate cb_isRestoring;

		private static Delegate cb_setRestoring_Z;

		private static Delegate cb_getShownTimeStamp;

		private static Delegate cb_setShownTimeStamp_Ljava_lang_Long_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setContext", "(Landroid/content/Context;)V", "GetSetContext_Landroid_content_Context_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setContext.(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual JSONObject JsonPayload
		{
			[Register("getJsonPayload", "()Lorg/json/JSONObject;", "GetGetJsonPayloadHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getJsonPayload.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setJsonPayload", "(Lorg/json/JSONObject;)V", "GetSetJsonPayload_Lorg_json_JSONObject_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setJsonPayload.(Lorg/json/JSONObject;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual OSNotification Notification
		{
			[Register("getNotification", "()Lcom/onesignal/OSNotification;", "GetGetNotificationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotification>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotification.()Lcom/onesignal/OSNotification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setNotification", "(Lcom/onesignal/OSNotification;)V", "GetSetNotification_Lcom_onesignal_OSNotification_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setNotification.(Lcom/onesignal/OSNotification;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual Integer OrgFlags
		{
			[Register("getOrgFlags", "()Ljava/lang/Integer;", "GetGetOrgFlagsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrgFlags.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOrgFlags", "(Ljava/lang/Integer;)V", "GetSetOrgFlags_Ljava_lang_Integer_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOrgFlags.(Ljava/lang/Integer;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual global::Android.Net.Uri OrgSound
		{
			[Register("getOrgSound", "()Landroid/net/Uri;", "GetGetOrgSoundHandler")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrgSound.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOrgSound", "(Landroid/net/Uri;)V", "GetSetOrgSound_Landroid_net_Uri_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOrgSound.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual ICharSequence OverriddenBodyFromExtenderFormatted
		{
			[Register("getOverriddenBodyFromExtender", "()Ljava/lang/CharSequence;", "GetGetOverriddenBodyFromExtenderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOverriddenBodyFromExtender.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOverriddenBodyFromExtender", "(Ljava/lang/CharSequence;)V", "GetSetOverriddenBodyFromExtender_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOverriddenBodyFromExtender.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string OverriddenBodyFromExtender
		{
			get
			{
				if (OverriddenBodyFromExtenderFormatted != null)
				{
					return OverriddenBodyFromExtenderFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(OverriddenBodyFromExtenderFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual Integer OverriddenFlags
		{
			[Register("getOverriddenFlags", "()Ljava/lang/Integer;", "GetGetOverriddenFlagsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOverriddenFlags.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOverriddenFlags", "(Ljava/lang/Integer;)V", "GetSetOverriddenFlags_Ljava_lang_Integer_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOverriddenFlags.(Ljava/lang/Integer;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual global::Android.Net.Uri OverriddenSound
		{
			[Register("getOverriddenSound", "()Landroid/net/Uri;", "GetGetOverriddenSoundHandler")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOverriddenSound.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOverriddenSound", "(Landroid/net/Uri;)V", "GetSetOverriddenSound_Landroid_net_Uri_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOverriddenSound.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual ICharSequence OverriddenTitleFromExtenderFormatted
		{
			[Register("getOverriddenTitleFromExtender", "()Ljava/lang/CharSequence;", "GetGetOverriddenTitleFromExtenderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOverriddenTitleFromExtender.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOverriddenTitleFromExtender", "(Ljava/lang/CharSequence;)V", "GetSetOverriddenTitleFromExtender_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setOverriddenTitleFromExtender.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string OverriddenTitleFromExtender
		{
			get
			{
				if (OverriddenTitleFromExtenderFormatted != null)
				{
					return OverriddenTitleFromExtenderFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(OverriddenTitleFromExtenderFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual bool Restoring
		{
			[Register("isRestoring", "()Z", "GetIsRestoringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRestoring.()Z", this, null);
			}
			[Register("setRestoring", "(Z)V", "GetSetRestoring_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRestoring.(Z)V", this, ptr);
			}
		}

		public unsafe virtual Long ShownTimeStamp
		{
			[Register("getShownTimeStamp", "()Ljava/lang/Long;", "GetGetShownTimeStampHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Long>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShownTimeStamp.()Ljava/lang/Long;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setShownTimeStamp", "(Ljava/lang/Long;)V", "GetSetShownTimeStamp_Ljava_lang_Long_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setShownTimeStamp.(Ljava/lang/Long;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected OSNotificationGenerationJob(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetContextHandler()
		{
			if ((object)cb_getContext == null)
			{
				cb_getContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContext));
			}
			return cb_getContext;
		}

		private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.Context);
		}

		private static Delegate GetSetContext_Landroid_content_Context_Handler()
		{
			if ((object)cb_setContext_Landroid_content_Context_ == null)
			{
				cb_setContext_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetContext_Landroid_content_Context_));
			}
			return cb_setContext_Landroid_content_Context_;
		}

		private static void n_SetContext_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.Context = context;
		}

		private static Delegate GetGetJsonPayloadHandler()
		{
			if ((object)cb_getJsonPayload == null)
			{
				cb_getJsonPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetJsonPayload));
			}
			return cb_getJsonPayload;
		}

		private static IntPtr n_GetJsonPayload(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.JsonPayload);
		}

		private static Delegate GetSetJsonPayload_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_setJsonPayload_Lorg_json_JSONObject_ == null)
			{
				cb_setJsonPayload_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetJsonPayload_Lorg_json_JSONObject_));
			}
			return cb_setJsonPayload_Lorg_json_JSONObject_;
		}

		private static void n_SetJsonPayload_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_jsonPayload)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject jsonPayload = Java.Lang.Object.GetObject<JSONObject>(native_jsonPayload, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.JsonPayload = jsonPayload;
		}

		private static Delegate GetGetNotificationHandler()
		{
			if ((object)cb_getNotification == null)
			{
				cb_getNotification = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotification));
			}
			return cb_getNotification;
		}

		private static IntPtr n_GetNotification(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.Notification);
		}

		private static Delegate GetSetNotification_Lcom_onesignal_OSNotification_Handler()
		{
			if ((object)cb_setNotification_Lcom_onesignal_OSNotification_ == null)
			{
				cb_setNotification_Lcom_onesignal_OSNotification_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetNotification_Lcom_onesignal_OSNotification_));
			}
			return cb_setNotification_Lcom_onesignal_OSNotification_;
		}

		private static void n_SetNotification_Lcom_onesignal_OSNotification_(IntPtr jnienv, IntPtr native__this, IntPtr native_notification)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSNotification notification = Java.Lang.Object.GetObject<OSNotification>(native_notification, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.Notification = notification;
		}

		private static Delegate GetGetOrgFlagsHandler()
		{
			if ((object)cb_getOrgFlags == null)
			{
				cb_getOrgFlags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOrgFlags));
			}
			return cb_getOrgFlags;
		}

		private static IntPtr n_GetOrgFlags(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.OrgFlags);
		}

		private static Delegate GetSetOrgFlags_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_setOrgFlags_Ljava_lang_Integer_ == null)
			{
				cb_setOrgFlags_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOrgFlags_Ljava_lang_Integer_));
			}
			return cb_setOrgFlags_Ljava_lang_Integer_;
		}

		private static void n_SetOrgFlags_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_orgFlags)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer orgFlags = Java.Lang.Object.GetObject<Integer>(native_orgFlags, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OrgFlags = orgFlags;
		}

		private static Delegate GetGetOrgSoundHandler()
		{
			if ((object)cb_getOrgSound == null)
			{
				cb_getOrgSound = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOrgSound));
			}
			return cb_getOrgSound;
		}

		private static IntPtr n_GetOrgSound(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.OrgSound);
		}

		private static Delegate GetSetOrgSound_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setOrgSound_Landroid_net_Uri_ == null)
			{
				cb_setOrgSound_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOrgSound_Landroid_net_Uri_));
			}
			return cb_setOrgSound_Landroid_net_Uri_;
		}

		private static void n_SetOrgSound_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_orgSound)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri orgSound = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_orgSound, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OrgSound = orgSound;
		}

		private static Delegate GetGetOverriddenBodyFromExtenderHandler()
		{
			if ((object)cb_getOverriddenBodyFromExtender == null)
			{
				cb_getOverriddenBodyFromExtender = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOverriddenBodyFromExtender));
			}
			return cb_getOverriddenBodyFromExtender;
		}

		private static IntPtr n_GetOverriddenBodyFromExtender(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(oSNotificationGenerationJob.OverriddenBodyFromExtenderFormatted);
		}

		private static Delegate GetSetOverriddenBodyFromExtender_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setOverriddenBodyFromExtender_Ljava_lang_CharSequence_ == null)
			{
				cb_setOverriddenBodyFromExtender_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOverriddenBodyFromExtender_Ljava_lang_CharSequence_));
			}
			return cb_setOverriddenBodyFromExtender_Ljava_lang_CharSequence_;
		}

		private static void n_SetOverriddenBodyFromExtender_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_overriddenBodyFromExtender)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence overriddenBodyFromExtenderFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_overriddenBodyFromExtender, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OverriddenBodyFromExtenderFormatted = overriddenBodyFromExtenderFormatted;
		}

		private static Delegate GetGetOverriddenFlagsHandler()
		{
			if ((object)cb_getOverriddenFlags == null)
			{
				cb_getOverriddenFlags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOverriddenFlags));
			}
			return cb_getOverriddenFlags;
		}

		private static IntPtr n_GetOverriddenFlags(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.OverriddenFlags);
		}

		private static Delegate GetSetOverriddenFlags_Ljava_lang_Integer_Handler()
		{
			if ((object)cb_setOverriddenFlags_Ljava_lang_Integer_ == null)
			{
				cb_setOverriddenFlags_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOverriddenFlags_Ljava_lang_Integer_));
			}
			return cb_setOverriddenFlags_Ljava_lang_Integer_;
		}

		private static void n_SetOverriddenFlags_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_overriddenFlags)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Integer overriddenFlags = Java.Lang.Object.GetObject<Integer>(native_overriddenFlags, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OverriddenFlags = overriddenFlags;
		}

		private static Delegate GetGetOverriddenSoundHandler()
		{
			if ((object)cb_getOverriddenSound == null)
			{
				cb_getOverriddenSound = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOverriddenSound));
			}
			return cb_getOverriddenSound;
		}

		private static IntPtr n_GetOverriddenSound(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.OverriddenSound);
		}

		private static Delegate GetSetOverriddenSound_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setOverriddenSound_Landroid_net_Uri_ == null)
			{
				cb_setOverriddenSound_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOverriddenSound_Landroid_net_Uri_));
			}
			return cb_setOverriddenSound_Landroid_net_Uri_;
		}

		private static void n_SetOverriddenSound_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_overriddenSound)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri overriddenSound = Java.Lang.Object.GetObject<global::Android.Net.Uri>(native_overriddenSound, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OverriddenSound = overriddenSound;
		}

		private static Delegate GetGetOverriddenTitleFromExtenderHandler()
		{
			if ((object)cb_getOverriddenTitleFromExtender == null)
			{
				cb_getOverriddenTitleFromExtender = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOverriddenTitleFromExtender));
			}
			return cb_getOverriddenTitleFromExtender;
		}

		private static IntPtr n_GetOverriddenTitleFromExtender(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(oSNotificationGenerationJob.OverriddenTitleFromExtenderFormatted);
		}

		private static Delegate GetSetOverriddenTitleFromExtender_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setOverriddenTitleFromExtender_Ljava_lang_CharSequence_ == null)
			{
				cb_setOverriddenTitleFromExtender_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOverriddenTitleFromExtender_Ljava_lang_CharSequence_));
			}
			return cb_setOverriddenTitleFromExtender_Ljava_lang_CharSequence_;
		}

		private static void n_SetOverriddenTitleFromExtender_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_overriddenTitleFromExtender)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence overriddenTitleFromExtenderFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_overriddenTitleFromExtender, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.OverriddenTitleFromExtenderFormatted = overriddenTitleFromExtenderFormatted;
		}

		private static Delegate GetIsRestoringHandler()
		{
			if ((object)cb_isRestoring == null)
			{
				cb_isRestoring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRestoring));
			}
			return cb_isRestoring;
		}

		private static bool n_IsRestoring(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSNotificationGenerationJob.Restoring;
		}

		private static Delegate GetSetRestoring_ZHandler()
		{
			if ((object)cb_setRestoring_Z == null)
			{
				cb_setRestoring_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRestoring_Z));
			}
			return cb_setRestoring_Z;
		}

		private static void n_SetRestoring_Z(IntPtr jnienv, IntPtr native__this, bool restoring)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.Restoring = restoring;
		}

		private static Delegate GetGetShownTimeStampHandler()
		{
			if ((object)cb_getShownTimeStamp == null)
			{
				cb_getShownTimeStamp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetShownTimeStamp));
			}
			return cb_getShownTimeStamp;
		}

		private static IntPtr n_GetShownTimeStamp(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationGenerationJob.ShownTimeStamp);
		}

		private static Delegate GetSetShownTimeStamp_Ljava_lang_Long_Handler()
		{
			if ((object)cb_setShownTimeStamp_Ljava_lang_Long_ == null)
			{
				cb_setShownTimeStamp_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetShownTimeStamp_Ljava_lang_Long_));
			}
			return cb_setShownTimeStamp_Ljava_lang_Long_;
		}

		private static void n_SetShownTimeStamp_Ljava_lang_Long_(IntPtr jnienv, IntPtr native__this, IntPtr native_shownTimeStamp)
		{
			OSNotificationGenerationJob oSNotificationGenerationJob = Java.Lang.Object.GetObject<OSNotificationGenerationJob>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Long shownTimeStamp = Java.Lang.Object.GetObject<Long>(native_shownTimeStamp, JniHandleOwnership.DoNotTransfer);
			oSNotificationGenerationJob.ShownTimeStamp = shownTimeStamp;
		}
	}
	[Register("com/onesignal/OSNotificationIntentExtras", DoNotGenerateAcw = true)]
	public sealed class OSNotificationIntentExtras : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationIntentExtras", typeof(OSNotificationIntentExtras));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe JSONArray DataArray
		{
			[Register("getDataArray", "()Lorg/json/JSONArray;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getDataArray.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDataArray", "(Lorg/json/JSONArray;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDataArray.(Lorg/json/JSONArray;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe JSONObject JsonData
		{
			[Register("getJsonData", "()Lorg/json/JSONObject;", "")]
			get
			{
				return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getJsonData.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setJsonData", "(Lorg/json/JSONObject;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setJsonData.(Lorg/json/JSONObject;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		internal OSNotificationIntentExtras(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lorg/json/JSONArray;Lorg/json/JSONObject;)V", "")]
		public unsafe OSNotificationIntentExtras(JSONArray dataArray, JSONObject jsonData)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dataArray?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(jsonData?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lorg/json/JSONArray;Lorg/json/JSONObject;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lorg/json/JSONArray;Lorg/json/JSONObject;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dataArray);
				GC.KeepAlive(jsonData);
			}
		}

		[Register("component1", "()Lorg/json/JSONArray;", "")]
		public unsafe JSONArray Component1()
		{
			return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("component2", "()Lorg/json/JSONObject;", "")]
		public unsafe JSONObject Component2()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component2.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Lorg/json/JSONArray;Lorg/json/JSONObject;)Lcom/onesignal/OSNotificationIntentExtras;", "")]
		public unsafe OSNotificationIntentExtras Copy(JSONArray dataArray, JSONObject jsonData)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dataArray?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(jsonData?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OSNotificationIntentExtras>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Lorg/json/JSONArray;Lorg/json/JSONObject;)Lcom/onesignal/OSNotificationIntentExtras;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(dataArray);
				GC.KeepAlive(jsonData);
			}
		}
	}
	[Register("com/onesignal/OSNotificationOpenAppSettings", DoNotGenerateAcw = true)]
	public sealed class OSNotificationOpenAppSettings : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationOpenAppSettings", typeof(OSNotificationOpenAppSettings));

		[Register("INSTANCE")]
		public static OSNotificationOpenAppSettings Instance => Java.Lang.Object.GetObject<OSNotificationOpenAppSettings>(_members.StaticFields.GetObjectValue("INSTANCE.Lcom/onesignal/OSNotificationOpenAppSettings;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OSNotificationOpenAppSettings(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getShouldOpenActivity", "(Landroid/content/Context;)Z", "")]
		public unsafe bool GetShouldOpenActivity(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getShouldOpenActivity.(Landroid/content/Context;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("getSuppressLaunchURL", "(Landroid/content/Context;)Z", "")]
		public unsafe bool GetSuppressLaunchURL(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getSuppressLaunchURL.(Landroid/content/Context;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
	[Register("com/onesignal/OSNotificationOpenBehaviorFromPushPayload", DoNotGenerateAcw = true)]
	public sealed class OSNotificationOpenBehaviorFromPushPayload : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationOpenBehaviorFromPushPayload", typeof(OSNotificationOpenBehaviorFromPushPayload));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe bool ShouldOpenApp
		{
			[Register("getShouldOpenApp", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getShouldOpenApp.()Z", this, null);
			}
		}

		public unsafe global::Android.Net.Uri Uri
		{
			[Register("getUri", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<global::Android.Net.Uri>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal OSNotificationOpenBehaviorFromPushPayload(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lorg/json/JSONObject;)V", "")]
		public unsafe OSNotificationOpenBehaviorFromPushPayload(Context context, JSONObject fcmPayload)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fcmPayload?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lorg/json/JSONObject;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lorg/json/JSONObject;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(fcmPayload);
			}
		}
	}
	[Register("com/onesignal/OSNotificationOpenedResult", DoNotGenerateAcw = true)]
	public class OSNotificationOpenedResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationOpenedResult", typeof(OSNotificationOpenedResult));

		private static Delegate cb_getAction;

		private static Delegate cb_getNotification;

		private static Delegate cb_onEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_;

		private static Delegate cb_stringify;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSNotificationAction Action
		{
			[Register("getAction", "()Lcom/onesignal/OSNotificationAction;", "GetGetActionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotificationAction>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAction.()Lcom/onesignal/OSNotificationAction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSNotification Notification
		{
			[Register("getNotification", "()Lcom/onesignal/OSNotification;", "GetGetNotificationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotification>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotification.()Lcom/onesignal/OSNotification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSNotificationOpenedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSNotification;Lcom/onesignal/OSNotificationAction;)V", "")]
		public unsafe OSNotificationOpenedResult(OSNotification notification, OSNotificationAction action)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSNotification;Lcom/onesignal/OSNotificationAction;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSNotification;Lcom/onesignal/OSNotificationAction;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notification);
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetGetActionHandler()
		{
			if ((object)cb_getAction == null)
			{
				cb_getAction = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAction));
			}
			return cb_getAction;
		}

		private static IntPtr n_GetAction(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationOpenedResult oSNotificationOpenedResult = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationOpenedResult.Action);
		}

		private static Delegate GetGetNotificationHandler()
		{
			if ((object)cb_getNotification == null)
			{
				cb_getNotification = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotification));
			}
			return cb_getNotification;
		}

		private static IntPtr n_GetNotification(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationOpenedResult oSNotificationOpenedResult = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationOpenedResult.Notification);
		}

		private static Delegate GetOnEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_Handler()
		{
			if ((object)cb_onEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_ == null)
			{
				cb_onEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_));
			}
			return cb_onEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_;
		}

		private static void n_OnEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_(IntPtr jnienv, IntPtr native__this, IntPtr native_appEntryState)
		{
			OSNotificationOpenedResult oSNotificationOpenedResult = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OneSignal.AppEntryAction appEntryState = Java.Lang.Object.GetObject<OneSignal.AppEntryAction>(native_appEntryState, JniHandleOwnership.DoNotTransfer);
			oSNotificationOpenedResult.OnEntryStateChange(appEntryState);
		}

		[Register("onEntryStateChange", "(Lcom/onesignal/OneSignal$AppEntryAction;)V", "GetOnEntryStateChange_Lcom_onesignal_OneSignal_AppEntryAction_Handler")]
		public unsafe virtual void OnEntryStateChange(OneSignal.AppEntryAction appEntryState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(appEntryState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onEntryStateChange.(Lcom/onesignal/OneSignal$AppEntryAction;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(appEntryState);
			}
		}

		[Obsolete]
		private static Delegate GetStringifyHandler()
		{
			if ((object)cb_stringify == null)
			{
				cb_stringify = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Stringify));
			}
			return cb_stringify;
		}

		[Obsolete]
		private static IntPtr n_Stringify(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationOpenedResult oSNotificationOpenedResult = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSNotificationOpenedResult.Stringify());
		}

		[Obsolete("deprecated")]
		[Register("stringify", "()Ljava/lang/String;", "GetStringifyHandler")]
		public unsafe virtual string Stringify()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("stringify.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationOpenedResult oSNotificationOpenedResult = Java.Lang.Object.GetObject<OSNotificationOpenedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationOpenedResult.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSNotificationReceivedEvent", DoNotGenerateAcw = true)]
	public class OSNotificationReceivedEvent : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSNotificationReceivedEvent", typeof(OSNotificationReceivedEvent));

		private static Delegate cb_getNotification;

		private static Delegate cb_complete_Lcom_onesignal_OSNotification_;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSNotification Notification
		{
			[Register("getNotification", "()Lcom/onesignal/OSNotification;", "GetGetNotificationHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSNotification>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotification.()Lcom/onesignal/OSNotification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSNotificationReceivedEvent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetNotificationHandler()
		{
			if ((object)cb_getNotification == null)
			{
				cb_getNotification = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotification));
			}
			return cb_getNotification;
		}

		private static IntPtr n_GetNotification(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationReceivedEvent oSNotificationReceivedEvent = Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationReceivedEvent.Notification);
		}

		private static Delegate GetComplete_Lcom_onesignal_OSNotification_Handler()
		{
			if ((object)cb_complete_Lcom_onesignal_OSNotification_ == null)
			{
				cb_complete_Lcom_onesignal_OSNotification_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Complete_Lcom_onesignal_OSNotification_));
			}
			return cb_complete_Lcom_onesignal_OSNotification_;
		}

		private static void n_Complete_Lcom_onesignal_OSNotification_(IntPtr jnienv, IntPtr native__this, IntPtr native_notification)
		{
			OSNotificationReceivedEvent oSNotificationReceivedEvent = Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OSNotification notification = Java.Lang.Object.GetObject<OSNotification>(native_notification, JniHandleOwnership.DoNotTransfer);
			oSNotificationReceivedEvent.Complete(notification);
		}

		[Register("complete", "(Lcom/onesignal/OSNotification;)V", "GetComplete_Lcom_onesignal_OSNotification_Handler")]
		public unsafe virtual void Complete(OSNotification notification)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("complete.(Lcom/onesignal/OSNotification;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notification);
			}
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSNotificationReceivedEvent oSNotificationReceivedEvent = Java.Lang.Object.GetObject<OSNotificationReceivedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSNotificationReceivedEvent.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSOutcomeEvent", DoNotGenerateAcw = true)]
	public class OSOutcomeEvent : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSOutcomeEvent", typeof(OSOutcomeEvent));

		private static Delegate cb_getName;

		private static Delegate cb_getNotificationIds;

		private static Delegate cb_getSession;

		private static Delegate cb_getTimestamp;

		private static Delegate cb_getWeight;

		private static Delegate cb_toJSONObject;

		private static Delegate cb_toJSONObjectForMeasure;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual JSONArray NotificationIds
		{
			[Register("getNotificationIds", "()Lorg/json/JSONArray;", "GetGetNotificationIdsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<JSONArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNotificationIds.()Lorg/json/JSONArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSInfluenceType Session
		{
			[Register("getSession", "()Lcom/onesignal/influence/domain/OSInfluenceType;", "GetGetSessionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSInfluenceType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSession.()Lcom/onesignal/influence/domain/OSInfluenceType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long Timestamp
		{
			[Register("getTimestamp", "()J", "GetGetTimestampHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTimestamp.()J", this, null);
			}
		}

		public unsafe virtual float Weight
		{
			[Register("getWeight", "()F", "GetGetWeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getWeight.()F", this, null);
			}
		}

		protected OSOutcomeEvent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;Ljava/lang/String;JF)V", "")]
		public unsafe OSOutcomeEvent(OSInfluenceType session, JSONArray notificationIds, string name, long timestamp, float weight)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(notificationIds?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(timestamp);
				ptr[4] = new JniArgumentValue(weight);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;Ljava/lang/String;JF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/influence/domain/OSInfluenceType;Lorg/json/JSONArray;Ljava/lang/String;JF)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(session);
				GC.KeepAlive(notificationIds);
			}
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName == null)
			{
				cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName;
		}

		private static IntPtr n_GetName(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSOutcomeEvent.Name);
		}

		private static Delegate GetGetNotificationIdsHandler()
		{
			if ((object)cb_getNotificationIds == null)
			{
				cb_getNotificationIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNotificationIds));
			}
			return cb_getNotificationIds;
		}

		private static IntPtr n_GetNotificationIds(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSOutcomeEvent.NotificationIds);
		}

		private static Delegate GetGetSessionHandler()
		{
			if ((object)cb_getSession == null)
			{
				cb_getSession = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSession));
			}
			return cb_getSession;
		}

		private static IntPtr n_GetSession(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSOutcomeEvent.Session);
		}

		private static Delegate GetGetTimestampHandler()
		{
			if ((object)cb_getTimestamp == null)
			{
				cb_getTimestamp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTimestamp));
			}
			return cb_getTimestamp;
		}

		private static long n_GetTimestamp(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSOutcomeEvent.Timestamp;
		}

		private static Delegate GetGetWeightHandler()
		{
			if ((object)cb_getWeight == null)
			{
				cb_getWeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetWeight));
			}
			return cb_getWeight;
		}

		private static float n_GetWeight(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSOutcomeEvent.Weight;
		}

		[Register("fromOutcomeEventParamsV2toOutcomeEventV1", "(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)Lcom/onesignal/OSOutcomeEvent;", "")]
		public unsafe static OSOutcomeEvent FromOutcomeEventParamsV2toOutcomeEventV1(OSOutcomeEventParams outcomeEventParams)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(outcomeEventParams?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OSOutcomeEvent>(_members.StaticMethods.InvokeObjectMethod("fromOutcomeEventParamsV2toOutcomeEventV1.(Lcom/onesignal/outcomes/domain/OSOutcomeEventParams;)Lcom/onesignal/OSOutcomeEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(outcomeEventParams);
			}
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSOutcomeEvent.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToJSONObjectForMeasureHandler()
		{
			if ((object)cb_toJSONObjectForMeasure == null)
			{
				cb_toJSONObjectForMeasure = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObjectForMeasure));
			}
			return cb_toJSONObjectForMeasure;
		}

		private static IntPtr n_ToJSONObjectForMeasure(IntPtr jnienv, IntPtr native__this)
		{
			OSOutcomeEvent oSOutcomeEvent = Java.Lang.Object.GetObject<OSOutcomeEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSOutcomeEvent.ToJSONObjectForMeasure());
		}

		[Register("toJSONObjectForMeasure", "()Lorg/json/JSONObject;", "GetToJSONObjectForMeasureHandler")]
		public unsafe virtual JSONObject ToJSONObjectForMeasure()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObjectForMeasure.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSPermissionState", DoNotGenerateAcw = true)]
	public class OSPermissionState : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSPermissionState", typeof(OSPermissionState));

		private static Delegate cb_getObservable;

		private static Delegate cb_areNotificationsEnabled;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Java.Lang.Object Observable
		{
			[Register("getObservable", "()Ljava/lang/Object;", "GetGetObservableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObservable.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSPermissionState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetObservableHandler()
		{
			if ((object)cb_getObservable == null)
			{
				cb_getObservable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetObservable));
			}
			return cb_getObservable;
		}

		private static IntPtr n_GetObservable(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionState oSPermissionState = Java.Lang.Object.GetObject<OSPermissionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSPermissionState.Observable);
		}

		private static Delegate GetAreNotificationsEnabledHandler()
		{
			if ((object)cb_areNotificationsEnabled == null)
			{
				cb_areNotificationsEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_AreNotificationsEnabled));
			}
			return cb_areNotificationsEnabled;
		}

		private static bool n_AreNotificationsEnabled(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionState oSPermissionState = Java.Lang.Object.GetObject<OSPermissionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSPermissionState.AreNotificationsEnabled();
		}

		[Register("areNotificationsEnabled", "()Z", "GetAreNotificationsEnabledHandler")]
		public unsafe virtual bool AreNotificationsEnabled()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("areNotificationsEnabled.()Z", this, null);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionState oSPermissionState = Java.Lang.Object.GetObject<OSPermissionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSPermissionState.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSPermissionStateChanges", DoNotGenerateAcw = true)]
	public class OSPermissionStateChanges : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSPermissionStateChanges", typeof(OSPermissionStateChanges));

		private static Delegate cb_getFrom;

		private static Delegate cb_getTo;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSPermissionState From
		{
			[Register("getFrom", "()Lcom/onesignal/OSPermissionState;", "GetGetFromHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSPermissionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrom.()Lcom/onesignal/OSPermissionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSPermissionState To
		{
			[Register("getTo", "()Lcom/onesignal/OSPermissionState;", "GetGetToHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSPermissionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTo.()Lcom/onesignal/OSPermissionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSPermissionStateChanges(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSPermissionState;Lcom/onesignal/OSPermissionState;)V", "")]
		public unsafe OSPermissionStateChanges(OSPermissionState from, OSPermissionState to)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSPermissionState;Lcom/onesignal/OSPermissionState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSPermissionState;Lcom/onesignal/OSPermissionState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(from);
				GC.KeepAlive(to);
			}
		}

		private static Delegate GetGetFromHandler()
		{
			if ((object)cb_getFrom == null)
			{
				cb_getFrom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFrom));
			}
			return cb_getFrom;
		}

		private static IntPtr n_GetFrom(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionStateChanges oSPermissionStateChanges = Java.Lang.Object.GetObject<OSPermissionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSPermissionStateChanges.From);
		}

		private static Delegate GetGetToHandler()
		{
			if ((object)cb_getTo == null)
			{
				cb_getTo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTo));
			}
			return cb_getTo;
		}

		private static IntPtr n_GetTo(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionStateChanges oSPermissionStateChanges = Java.Lang.Object.GetObject<OSPermissionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSPermissionStateChanges.To);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSPermissionStateChanges oSPermissionStateChanges = Java.Lang.Object.GetObject<OSPermissionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSPermissionStateChanges.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSSessionManager", DoNotGenerateAcw = true)]
	public class OSSessionManager : Java.Lang.Object
	{
		[Register("com/onesignal/OSSessionManager$SessionListener", "", "Com.OneSignal.Android.OSSessionManager/ISessionListenerInvoker")]
		public interface ISessionListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onSessionEnding", "(Ljava/util/List;)V", "GetOnSessionEnding_Ljava_util_List_Handler:Com.OneSignal.Android.OSSessionManager/ISessionListenerInvoker, OneSignal.Android.Binding")]
			void OnSessionEnding(IList<OSInfluence> p0);
		}

		[Register("com/onesignal/OSSessionManager$SessionListener", DoNotGenerateAcw = true)]
		internal class ISessionListenerInvoker : Java.Lang.Object, ISessionListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSessionManager$SessionListener", typeof(ISessionListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onSessionEnding_Ljava_util_List_;

			private IntPtr id_onSessionEnding_Ljava_util_List_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static ISessionListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ISessionListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.onesignal.OSSessionManager.SessionListener'.");
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public ISessionListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnSessionEnding_Ljava_util_List_Handler()
			{
				if ((object)cb_onSessionEnding_Ljava_util_List_ == null)
				{
					cb_onSessionEnding_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSessionEnding_Ljava_util_List_));
				}
				return cb_onSessionEnding_Ljava_util_List_;
			}

			private static void n_OnSessionEnding_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				ISessionListener sessionListener = Java.Lang.Object.GetObject<ISessionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<OSInfluence> p = JavaList<OSInfluence>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
				sessionListener.OnSessionEnding(p);
			}

			public unsafe void OnSessionEnding(IList<OSInfluence> p0)
			{
				if (id_onSessionEnding_Ljava_util_List_ == IntPtr.Zero)
				{
					id_onSessionEnding_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "onSessionEnding", "(Ljava/util/List;)V");
				}
				IntPtr intPtr = JavaList<OSInfluence>.ToLocalJniHandle(p0);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_onSessionEnding_Ljava_util_List_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		public class SessionEventArgs : EventArgs
		{
			private IList<OSInfluence> p0;

			public IList<OSInfluence> P0 => p0;

			public SessionEventArgs(IList<OSInfluence> p0)
			{
				this.p0 = p0;
			}
		}

		[Register("mono/com/onesignal/OSSessionManager_SessionListenerImplementor")]
		internal sealed class ISessionListenerImplementor : Java.Lang.Object, ISessionListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<SessionEventArgs> Handler;

			public ISessionListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/onesignal/OSSessionManager_SessionListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnSessionEnding(IList<OSInfluence> p0)
			{
				Handler?.Invoke(sender, new SessionEventArgs(p0));
			}

			internal static bool __IsEmpty(ISessionListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSessionManager", typeof(OSSessionManager));

		[Register("trackerFactory")]
		protected OSTrackerFactory TrackerFactory
		{
			get
			{
				return Java.Lang.Object.GetObject<OSTrackerFactory>(_members.InstanceFields.GetObjectValue("trackerFactory.Lcom/onesignal/influence/data/OSTrackerFactory;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("trackerFactory.Lcom/onesignal/influence/data/OSTrackerFactory;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSSessionManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSessionManager$SessionListener;Lcom/onesignal/influence/data/OSTrackerFactory;Lcom/onesignal/OSLogger;)V", "")]
		public unsafe OSSessionManager(ISessionListener sessionListener, OSTrackerFactory trackerFactory, IOSLogger logger)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((sessionListener == null) ? IntPtr.Zero : ((Java.Lang.Object)sessionListener).Handle);
				ptr[1] = new JniArgumentValue(trackerFactory?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((logger == null) ? IntPtr.Zero : ((Java.Lang.Object)logger).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSessionManager$SessionListener;Lcom/onesignal/influence/data/OSTrackerFactory;Lcom/onesignal/OSLogger;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSessionManager$SessionListener;Lcom/onesignal/influence/data/OSTrackerFactory;Lcom/onesignal/OSLogger;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sessionListener);
				GC.KeepAlive(trackerFactory);
				GC.KeepAlive(logger);
			}
		}
	}
	[Register("com/onesignal/OSSMSSubscriptionState", DoNotGenerateAcw = true)]
	public class OSSMSSubscriptionState : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSMSSubscriptionState", typeof(OSSMSSubscriptionState));

		private static Delegate cb_isSubscribed;

		private static Delegate cb_getObservable;

		private static Delegate cb_getSMSNumber;

		private static Delegate cb_getSmsUserId;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsSubscribed
		{
			[Register("isSubscribed", "()Z", "GetIsSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object Observable
		{
			[Register("getObservable", "()Ljava/lang/Object;", "GetGetObservableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObservable.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SMSNumber
		{
			[Register("getSMSNumber", "()Ljava/lang/String;", "GetGetSMSNumberHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSMSNumber.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string SmsUserId
		{
			[Register("getSmsUserId", "()Ljava/lang/String;", "GetGetSmsUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSmsUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSSMSSubscriptionState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetIsSubscribedHandler()
		{
			if ((object)cb_isSubscribed == null)
			{
				cb_isSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSubscribed));
			}
			return cb_isSubscribed;
		}

		private static bool n_IsSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionState oSSMSSubscriptionState = Java.Lang.Object.GetObject<OSSMSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSSMSSubscriptionState.IsSubscribed;
		}

		private static Delegate GetGetObservableHandler()
		{
			if ((object)cb_getObservable == null)
			{
				cb_getObservable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetObservable));
			}
			return cb_getObservable;
		}

		private static IntPtr n_GetObservable(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionState oSSMSSubscriptionState = Java.Lang.Object.GetObject<OSSMSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSMSSubscriptionState.Observable);
		}

		private static Delegate GetGetSMSNumberHandler()
		{
			if ((object)cb_getSMSNumber == null)
			{
				cb_getSMSNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSMSNumber));
			}
			return cb_getSMSNumber;
		}

		private static IntPtr n_GetSMSNumber(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionState oSSMSSubscriptionState = Java.Lang.Object.GetObject<OSSMSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSSMSSubscriptionState.SMSNumber);
		}

		private static Delegate GetGetSmsUserIdHandler()
		{
			if ((object)cb_getSmsUserId == null)
			{
				cb_getSmsUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSmsUserId));
			}
			return cb_getSmsUserId;
		}

		private static IntPtr n_GetSmsUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionState oSSMSSubscriptionState = Java.Lang.Object.GetObject<OSSMSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSSMSSubscriptionState.SmsUserId);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionState oSSMSSubscriptionState = Java.Lang.Object.GetObject<OSSMSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSMSSubscriptionState.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSSMSSubscriptionStateChanges", DoNotGenerateAcw = true)]
	public class OSSMSSubscriptionStateChanges : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSMSSubscriptionStateChanges", typeof(OSSMSSubscriptionStateChanges));

		private static Delegate cb_getFrom;

		private static Delegate cb_getTo;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSSMSSubscriptionState From
		{
			[Register("getFrom", "()Lcom/onesignal/OSSMSSubscriptionState;", "GetGetFromHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSSMSSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrom.()Lcom/onesignal/OSSMSSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSSMSSubscriptionState To
		{
			[Register("getTo", "()Lcom/onesignal/OSSMSSubscriptionState;", "GetGetToHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSSMSSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTo.()Lcom/onesignal/OSSMSSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSSMSSubscriptionStateChanges(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSMSSubscriptionState;Lcom/onesignal/OSSMSSubscriptionState;)V", "")]
		public unsafe OSSMSSubscriptionStateChanges(OSSMSSubscriptionState from, OSSMSSubscriptionState to)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSMSSubscriptionState;Lcom/onesignal/OSSMSSubscriptionState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSMSSubscriptionState;Lcom/onesignal/OSSMSSubscriptionState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(from);
				GC.KeepAlive(to);
			}
		}

		private static Delegate GetGetFromHandler()
		{
			if ((object)cb_getFrom == null)
			{
				cb_getFrom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFrom));
			}
			return cb_getFrom;
		}

		private static IntPtr n_GetFrom(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionStateChanges oSSMSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSMSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSMSSubscriptionStateChanges.From);
		}

		private static Delegate GetGetToHandler()
		{
			if ((object)cb_getTo == null)
			{
				cb_getTo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTo));
			}
			return cb_getTo;
		}

		private static IntPtr n_GetTo(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionStateChanges oSSMSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSMSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSMSSubscriptionStateChanges.To);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSSMSSubscriptionStateChanges oSSMSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSMSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSMSSubscriptionStateChanges.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSSubscriptionState", DoNotGenerateAcw = true)]
	public class OSSubscriptionState : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSubscriptionState", typeof(OSSubscriptionState));

		private static Delegate cb_isPushDisabled;

		private static Delegate cb_isSubscribed;

		private static Delegate cb_getObservable;

		private static Delegate cb_getPushToken;

		private static Delegate cb_getUserId;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsPushDisabled
		{
			[Register("isPushDisabled", "()Z", "GetIsPushDisabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPushDisabled.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSubscribed
		{
			[Register("isSubscribed", "()Z", "GetIsSubscribedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSubscribed.()Z", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object Observable
		{
			[Register("getObservable", "()Ljava/lang/Object;", "GetGetObservableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getObservable.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string PushToken
		{
			[Register("getPushToken", "()Ljava/lang/String;", "GetGetPushTokenHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPushToken.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string UserId
		{
			[Register("getUserId", "()Ljava/lang/String;", "GetGetUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSSubscriptionState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetIsPushDisabledHandler()
		{
			if ((object)cb_isPushDisabled == null)
			{
				cb_isPushDisabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPushDisabled));
			}
			return cb_isPushDisabled;
		}

		private static bool n_IsPushDisabled(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSSubscriptionState.IsPushDisabled;
		}

		private static Delegate GetIsSubscribedHandler()
		{
			if ((object)cb_isSubscribed == null)
			{
				cb_isSubscribed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSubscribed));
			}
			return cb_isSubscribed;
		}

		private static bool n_IsSubscribed(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSSubscriptionState.IsSubscribed;
		}

		private static Delegate GetGetObservableHandler()
		{
			if ((object)cb_getObservable == null)
			{
				cb_getObservable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetObservable));
			}
			return cb_getObservable;
		}

		private static IntPtr n_GetObservable(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSubscriptionState.Observable);
		}

		private static Delegate GetGetPushTokenHandler()
		{
			if ((object)cb_getPushToken == null)
			{
				cb_getPushToken = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPushToken));
			}
			return cb_getPushToken;
		}

		private static IntPtr n_GetPushToken(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSSubscriptionState.PushToken);
		}

		private static Delegate GetGetUserIdHandler()
		{
			if ((object)cb_getUserId == null)
			{
				cb_getUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUserId));
			}
			return cb_getUserId;
		}

		private static IntPtr n_GetUserId(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(oSSubscriptionState.UserId);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionState oSSubscriptionState = Java.Lang.Object.GetObject<OSSubscriptionState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSubscriptionState.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSSubscriptionStateChanges", DoNotGenerateAcw = true)]
	public class OSSubscriptionStateChanges : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSSubscriptionStateChanges", typeof(OSSubscriptionStateChanges));

		private static Delegate cb_getFrom;

		private static Delegate cb_getTo;

		private static Delegate cb_toJSONObject;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual OSSubscriptionState From
		{
			[Register("getFrom", "()Lcom/onesignal/OSSubscriptionState;", "GetGetFromHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFrom.()Lcom/onesignal/OSSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual OSSubscriptionState To
		{
			[Register("getTo", "()Lcom/onesignal/OSSubscriptionState;", "GetGetToHandler")]
			get
			{
				return Java.Lang.Object.GetObject<OSSubscriptionState>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTo.()Lcom/onesignal/OSSubscriptionState;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OSSubscriptionStateChanges(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/onesignal/OSSubscriptionState;Lcom/onesignal/OSSubscriptionState;)V", "")]
		public unsafe OSSubscriptionStateChanges(OSSubscriptionState from, OSSubscriptionState to)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/onesignal/OSSubscriptionState;Lcom/onesignal/OSSubscriptionState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/onesignal/OSSubscriptionState;Lcom/onesignal/OSSubscriptionState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(from);
				GC.KeepAlive(to);
			}
		}

		private static Delegate GetGetFromHandler()
		{
			if ((object)cb_getFrom == null)
			{
				cb_getFrom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFrom));
			}
			return cb_getFrom;
		}

		private static IntPtr n_GetFrom(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionStateChanges oSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSubscriptionStateChanges.From);
		}

		private static Delegate GetGetToHandler()
		{
			if ((object)cb_getTo == null)
			{
				cb_getTo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTo));
			}
			return cb_getTo;
		}

		private static IntPtr n_GetTo(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionStateChanges oSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSubscriptionStateChanges.To);
		}

		private static Delegate GetToJSONObjectHandler()
		{
			if ((object)cb_toJSONObject == null)
			{
				cb_toJSONObject = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToJSONObject));
			}
			return cb_toJSONObject;
		}

		private static IntPtr n_ToJSONObject(IntPtr jnienv, IntPtr native__this)
		{
			OSSubscriptionStateChanges oSSubscriptionStateChanges = Java.Lang.Object.GetObject<OSSubscriptionStateChanges>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(oSSubscriptionStateChanges.ToJSONObject());
		}

		[Register("toJSONObject", "()Lorg/json/JSONObject;", "GetToJSONObjectHandler")]
		public unsafe virtual JSONObject ToJSONObject()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("toJSONObject.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/onesignal/OSTimeImpl", DoNotGenerateAcw = true)]
	public class OSTimeImpl : Java.Lang.Object, IOSTime, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSTimeImpl", typeof(OSTimeImpl));

		private static Delegate cb_getCurrentTimeMillis;

		private static Delegate cb_getElapsedRealtime;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual long CurrentTimeMillis
		{
			[Register("getCurrentTimeMillis", "()J", "GetGetCurrentTimeMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getCurrentTimeMillis.()J", this, null);
			}
		}

		public unsafe virtual long ElapsedRealtime
		{
			[Register("getElapsedRealtime", "()J", "GetGetElapsedRealtimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getElapsedRealtime.()J", this, null);
			}
		}

		protected OSTimeImpl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OSTimeImpl()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCurrentTimeMillisHandler()
		{
			if ((object)cb_getCurrentTimeMillis == null)
			{
				cb_getCurrentTimeMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCurrentTimeMillis));
			}
			return cb_getCurrentTimeMillis;
		}

		private static long n_GetCurrentTimeMillis(IntPtr jnienv, IntPtr native__this)
		{
			OSTimeImpl oSTimeImpl = Java.Lang.Object.GetObject<OSTimeImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSTimeImpl.CurrentTimeMillis;
		}

		private static Delegate GetGetElapsedRealtimeHandler()
		{
			if ((object)cb_getElapsedRealtime == null)
			{
				cb_getElapsedRealtime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetElapsedRealtime));
			}
			return cb_getElapsedRealtime;
		}

		private static long n_GetElapsedRealtime(IntPtr jnienv, IntPtr native__this)
		{
			OSTimeImpl oSTimeImpl = Java.Lang.Object.GetObject<OSTimeImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSTimeImpl.ElapsedRealtime;
		}
	}
	[Register("com/onesignal/OSWebView", DoNotGenerateAcw = true)]
	public class OSWebView : WebView
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/OSWebView", typeof(OSWebView));

		private static Delegate cb_overScrollBy_IIIIIIIIZ;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected OSWebView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe OSWebView(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetOverScrollBy_IIIIIIIIZHandler()
		{
			if ((object)cb_overScrollBy_IIIIIIIIZ == null)
			{
				cb_overScrollBy_IIIIIIIIZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIIIIIIIZ_Z(n_OverScrollBy_IIIIIIIIZ));
			}
			return cb_overScrollBy_IIIIIIIIZ;
		}

		private static bool n_OverScrollBy_IIIIIIIIZ(IntPtr jnienv, IntPtr native__this, int deltaX, int deltaY, int scrollX, int scrollY, int scrollRangeX, int scrollRangeY, int maxOverScrollX, int maxOverScrollY, bool isTouchEvent)
		{
			OSWebView oSWebView = Java.Lang.Object.GetObject<OSWebView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return oSWebView.OverScrollBy(deltaX, deltaY, scrollX, scrollY, scrollRangeX, scrollRangeY, maxOverScrollX, maxOverScrollY, isTouchEvent);
		}

		[Register("overScrollBy", "(IIIIIIIIZ)Z", "GetOverScrollBy_IIIIIIIIZHandler")]
		public new unsafe virtual bool OverScrollBy(int deltaX, int deltaY, int scrollX, int scrollY, int scrollRangeX, int scrollRangeY, int maxOverScrollX, int maxOverScrollY, bool isTouchEvent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(deltaX);
			ptr[1] = new JniArgumentValue(deltaY);
			ptr[2] = new JniArgumentValue(scrollX);
			ptr[3] = new JniArgumentValue(scrollY);
			ptr[4] = new JniArgumentValue(scrollRangeX);
			ptr[5] = new JniArgumentValue(scrollRangeY);
			ptr[6] = new JniArgumentValue(maxOverScrollX);
			ptr[7] = new JniArgumentValue(maxOverScrollY);
			ptr[8] = new JniArgumentValue(isTouchEvent);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("overScrollBy.(IIIIIIIIZ)Z", this, ptr);
		}
	}
	[Register("com/onesignal/PermissionsActivity", DoNotGenerateAcw = true)]
	public class PermissionsActivity : Activity
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/PermissionsActivity", typeof(PermissionsActivity));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected PermissionsActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PermissionsActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/onesignal/PushRegistratorADM", DoNotGenerateAcw = true)]
	public class PushRegistratorADM : Java.Lang.Object, IPushRegistrator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/PushRegistratorADM", typeof(PushRegistratorADM));

		private static Delegate cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected PushRegistratorADM(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PushRegistratorADM()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("fireCallback", "(Ljava/lang/String;)V", "")]
		public unsafe static void FireCallback(string id)
		{
			IntPtr intPtr = JNIEnv.NewString(id);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("fireCallback.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetRegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_Handler()
		{
			if ((object)cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ == null)
			{
				cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_RegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_));
			}
			return cb_registerForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_;
		}

		private static void n_RegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_noKeyNeeded, IntPtr native__callback)
		{
			PushRegistratorADM pushRegistratorADM = Java.Lang.Object.GetObject<PushRegistratorADM>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string noKeyNeeded = JNIEnv.GetString(native_noKeyNeeded, JniHandleOwnership.DoNotTransfer);
			IPushRegistratorRegisteredHandler callback = Java.Lang.Object.GetObject<IPushRegistratorRegisteredHandler>(native__callback, JniHandleOwnership.DoNotTransfer);
			pushRegistratorADM.RegisterForPush(context, noKeyNeeded, callback);
		}

		[Register("registerForPush", "(Landroid/content/Context;Ljava/lang/String;Lcom/onesignal/PushRegistrator$RegisteredHandler;)V", "GetRegisterForPush_Landroid_content_Context_Ljava_lang_String_Lcom_onesignal_PushRegistrator_RegisteredHandler_Handler")]
		public unsafe virtual void RegisterForPush(Context context, string noKeyNeeded, IPushRegistratorRegisteredHandler callback)
		{
			IntPtr intPtr = JNIEnv.NewString(noKeyNeeded);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerForPush.(Landroid/content/Context;Ljava/lang/String;Lcom/onesignal/PushRegistrator$RegisteredHandler;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/onesignal/SyncJobService", DoNotGenerateAcw = true)]
	public class SyncJobService : JobService
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/SyncJobService", typeof(SyncJobService));

		private static Delegate cb_onStartJob_Landroid_app_job_JobParameters_;

		private static Delegate cb_onStopJob_Landroid_app_job_JobParameters_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected SyncJobService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SyncJobService()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnStartJob_Landroid_app_job_JobParameters_Handler()
		{
			if ((object)cb_onStartJob_Landroid_app_job_JobParameters_ == null)
			{
				cb_onStartJob_Landroid_app_job_JobParameters_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnStartJob_Landroid_app_job_JobParameters_));
			}
			return cb_onStartJob_Landroid_app_job_JobParameters_;
		}

		private static bool n_OnStartJob_Landroid_app_job_JobParameters_(IntPtr jnienv, IntPtr native__this, IntPtr native_jobParameters)
		{
			SyncJobService syncJobService = Java.Lang.Object.GetObject<SyncJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JobParameters jobParameters = Java.Lang.Object.GetObject<JobParameters>(native_jobParameters, JniHandleOwnership.DoNotTransfer);
			return syncJobService.OnStartJob(jobParameters);
		}

		[Register("onStartJob", "(Landroid/app/job/JobParameters;)Z", "GetOnStartJob_Landroid_app_job_JobParameters_Handler")]
		public unsafe override bool OnStartJob(JobParameters jobParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(jobParameters?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartJob.(Landroid/app/job/JobParameters;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(jobParameters);
			}
		}

		private static Delegate GetOnStopJob_Landroid_app_job_JobParameters_Handler()
		{
			if ((object)cb_onStopJob_Landroid_app_job_JobParameters_ == null)
			{
				cb_onStopJob_Landroid_app_job_JobParameters_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnStopJob_Landroid_app_job_JobParameters_));
			}
			return cb_onStopJob_Landroid_app_job_JobParameters_;
		}

		private static bool n_OnStopJob_Landroid_app_job_JobParameters_(IntPtr jnienv, IntPtr native__this, IntPtr native_jobParameters)
		{
			SyncJobService syncJobService = Java.Lang.Object.GetObject<SyncJobService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JobParameters jobParameters = Java.Lang.Object.GetObject<JobParameters>(native_jobParameters, JniHandleOwnership.DoNotTransfer);
			return syncJobService.OnStopJob(jobParameters);
		}

		[Register("onStopJob", "(Landroid/app/job/JobParameters;)Z", "GetOnStopJob_Landroid_app_job_JobParameters_Handler")]
		public unsafe override bool OnStopJob(JobParameters jobParameters)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(jobParameters?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStopJob.(Landroid/app/job/JobParameters;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(jobParameters);
			}
		}
	}
	[Register("com/onesignal/SyncService", DoNotGenerateAcw = true)]
	public class SyncService : Service
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/SyncService", typeof(SyncService));

		private static Delegate cb_onBind_Landroid_content_Intent_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected SyncService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SyncService()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnBind_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onBind_Landroid_content_Intent_ == null)
			{
				cb_onBind_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnBind_Landroid_content_Intent_));
			}
			return cb_onBind_Landroid_content_Intent_;
		}

		private static IntPtr n_OnBind_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_intent)
		{
			SyncService syncService = Java.Lang.Object.GetObject<SyncService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(syncService.OnBind(intent));
		}

		[Register("onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;", "GetOnBind_Landroid_content_Intent_Handler")]
		public unsafe override IBinder OnBind(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IBinder>(_members.InstanceMethods.InvokeVirtualObjectMethod("onBind.(Landroid/content/Intent;)Landroid/os/IBinder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("com/onesignal/TLS12SocketFactory", DoNotGenerateAcw = true)]
	public class TLS12SocketFactory : SSLSocketFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/TLS12SocketFactory", typeof(TLS12SocketFactory));

		private static Delegate cb_createSocket_Ljava_lang_String_I;

		private static Delegate cb_createSocket_Ljava_lang_String_ILjava_net_InetAddress_I;

		private static Delegate cb_createSocket_Ljava_net_InetAddress_I;

		private static Delegate cb_createSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I;

		private static Delegate cb_createSocket_Ljava_net_Socket_Ljava_lang_String_IZ;

		private static Delegate cb_getDefaultCipherSuites;

		private static Delegate cb_getSupportedCipherSuites;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected TLS12SocketFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljavax/net/ssl/SSLSocketFactory;)V", "")]
		public unsafe TLS12SocketFactory(SSLSocketFactory sslSocketFactory)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sslSocketFactory?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljavax/net/ssl/SSLSocketFactory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljavax/net/ssl/SSLSocketFactory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sslSocketFactory);
			}
		}

		private static Delegate GetCreateSocket_Ljava_lang_String_IHandler()
		{
			if ((object)cb_createSocket_Ljava_lang_String_I == null)
			{
				cb_createSocket_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_CreateSocket_Ljava_lang_String_I));
			}
			return cb_createSocket_Ljava_lang_String_I;
		}

		private static IntPtr n_CreateSocket_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_host, int port)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(tLS12SocketFactory.CreateSocket(host, port));
		}

		[Register("createSocket", "(Ljava/lang/String;I)Ljava/net/Socket;", "GetCreateSocket_Ljava_lang_String_IHandler")]
		public unsafe override Socket CreateSocket(string host, int port)
		{
			IntPtr intPtr = JNIEnv.NewString(host);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(port);
				return Java.Lang.Object.GetObject<Socket>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSocket.(Ljava/lang/String;I)Ljava/net/Socket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetCreateSocket_Ljava_lang_String_ILjava_net_InetAddress_IHandler()
		{
			if ((object)cb_createSocket_Ljava_lang_String_ILjava_net_InetAddress_I == null)
			{
				cb_createSocket_Ljava_lang_String_ILjava_net_InetAddress_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILI_L(n_CreateSocket_Ljava_lang_String_ILjava_net_InetAddress_I));
			}
			return cb_createSocket_Ljava_lang_String_ILjava_net_InetAddress_I;
		}

		private static IntPtr n_CreateSocket_Ljava_lang_String_ILjava_net_InetAddress_I(IntPtr jnienv, IntPtr native__this, IntPtr native_host, int port, IntPtr native_localHost, int localPort)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
			InetAddress localHost = Java.Lang.Object.GetObject<InetAddress>(native_localHost, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(tLS12SocketFactory.CreateSocket(host, port, localHost, localPort));
		}

		[Register("createSocket", "(Ljava/lang/String;ILjava/net/InetAddress;I)Ljava/net/Socket;", "GetCreateSocket_Ljava_lang_String_ILjava_net_InetAddress_IHandler")]
		public unsafe override Socket CreateSocket(string host, int port, InetAddress localHost, int localPort)
		{
			IntPtr intPtr = JNIEnv.NewString(host);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(port);
				ptr[2] = new JniArgumentValue(localHost?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(localPort);
				return Java.Lang.Object.GetObject<Socket>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSocket.(Ljava/lang/String;ILjava/net/InetAddress;I)Ljava/net/Socket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(localHost);
			}
		}

		private static Delegate GetCreateSocket_Ljava_net_InetAddress_IHandler()
		{
			if ((object)cb_createSocket_Ljava_net_InetAddress_I == null)
			{
				cb_createSocket_Ljava_net_InetAddress_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_CreateSocket_Ljava_net_InetAddress_I));
			}
			return cb_createSocket_Ljava_net_InetAddress_I;
		}

		private static IntPtr n_CreateSocket_Ljava_net_InetAddress_I(IntPtr jnienv, IntPtr native__this, IntPtr native_host, int port)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InetAddress host = Java.Lang.Object.GetObject<InetAddress>(native_host, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(tLS12SocketFactory.CreateSocket(host, port));
		}

		[Register("createSocket", "(Ljava/net/InetAddress;I)Ljava/net/Socket;", "GetCreateSocket_Ljava_net_InetAddress_IHandler")]
		public unsafe override Socket CreateSocket(InetAddress host, int port)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(port);
				return Java.Lang.Object.GetObject<Socket>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSocket.(Ljava/net/InetAddress;I)Ljava/net/Socket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(host);
			}
		}

		private static Delegate GetCreateSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_IHandler()
		{
			if ((object)cb_createSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I == null)
			{
				cb_createSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLILI_L(n_CreateSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I));
			}
			return cb_createSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I;
		}

		private static IntPtr n_CreateSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_I(IntPtr jnienv, IntPtr native__this, IntPtr native_address, int port, IntPtr native_localAddress, int localPort)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InetAddress address = Java.Lang.Object.GetObject<InetAddress>(native_address, JniHandleOwnership.DoNotTransfer);
			InetAddress localAddress = Java.Lang.Object.GetObject<InetAddress>(native_localAddress, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(tLS12SocketFactory.CreateSocket(address, port, localAddress, localPort));
		}

		[Register("createSocket", "(Ljava/net/InetAddress;ILjava/net/InetAddress;I)Ljava/net/Socket;", "GetCreateSocket_Ljava_net_InetAddress_ILjava_net_InetAddress_IHandler")]
		public unsafe override Socket CreateSocket(InetAddress address, int port, InetAddress localAddress, int localPort)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(address?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(port);
				ptr[2] = new JniArgumentValue(localAddress?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(localPort);
				return Java.Lang.Object.GetObject<Socket>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSocket.(Ljava/net/InetAddress;ILjava/net/InetAddress;I)Ljava/net/Socket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(address);
				GC.KeepAlive(localAddress);
			}
		}

		private static Delegate GetCreateSocket_Ljava_net_Socket_Ljava_lang_String_IZHandler()
		{
			if ((object)cb_createSocket_Ljava_net_Socket_Ljava_lang_String_IZ == null)
			{
				cb_createSocket_Ljava_net_Socket_Ljava_lang_String_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLIZ_L(n_CreateSocket_Ljava_net_Socket_Ljava_lang_String_IZ));
			}
			return cb_createSocket_Ljava_net_Socket_Ljava_lang_String_IZ;
		}

		private static IntPtr n_CreateSocket_Ljava_net_Socket_Ljava_lang_String_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_s, IntPtr native_host, int port, bool autoClose)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Socket s = Java.Lang.Object.GetObject<Socket>(native_s, JniHandleOwnership.DoNotTransfer);
			string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(tLS12SocketFactory.CreateSocket(s, host, port, autoClose));
		}

		[Register("createSocket", "(Ljava/net/Socket;Ljava/lang/String;IZ)Ljava/net/Socket;", "GetCreateSocket_Ljava_net_Socket_Ljava_lang_String_IZHandler")]
		public unsafe override Socket CreateSocket(Socket s, string host, int port, bool autoClose)
		{
			IntPtr intPtr = JNIEnv.NewString(host);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(s?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(port);
				ptr[3] = new JniArgumentValue(autoClose);
				return Java.Lang.Object.GetObject<Socket>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSocket.(Ljava/net/Socket;Ljava/lang/String;IZ)Ljava/net/Socket;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(s);
			}
		}

		private static Delegate GetGetDefaultCipherSuitesHandler()
		{
			if ((object)cb_getDefaultCipherSuites == null)
			{
				cb_getDefaultCipherSuites = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultCipherSuites));
			}
			return cb_getDefaultCipherSuites;
		}

		private static IntPtr n_GetDefaultCipherSuites(IntPtr jnienv, IntPtr native__this)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(tLS12SocketFactory.GetDefaultCipherSuites());
		}

		[Register("getDefaultCipherSuites", "()[Ljava/lang/String;", "GetGetDefaultCipherSuitesHandler")]
		public unsafe override string[] GetDefaultCipherSuites()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultCipherSuites.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}

		private static Delegate GetGetSupportedCipherSuitesHandler()
		{
			if ((object)cb_getSupportedCipherSuites == null)
			{
				cb_getSupportedCipherSuites = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedCipherSuites));
			}
			return cb_getSupportedCipherSuites;
		}

		private static IntPtr n_GetSupportedCipherSuites(IntPtr jnienv, IntPtr native__this)
		{
			TLS12SocketFactory tLS12SocketFactory = Java.Lang.Object.GetObject<TLS12SocketFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(tLS12SocketFactory.GetSupportedCipherSuites());
		}

		[Register("getSupportedCipherSuites", "()[Ljava/lang/String;", "GetGetSupportedCipherSuitesHandler")]
		public unsafe override string[] GetSupportedCipherSuites()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedCipherSuites.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("com/onesignal/UpgradeReceiver", DoNotGenerateAcw = true)]
	public class UpgradeReceiver : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/onesignal/UpgradeReceiver", typeof(UpgradeReceiver));

		private static Delegate cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected UpgradeReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UpgradeReceiver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_onReceive_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnReceive_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_onReceive_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_OnReceive_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_intent)
		{
			UpgradeReceiver upgradeReceiver = Java.Lang.Object.GetObject<UpgradeReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			upgradeReceiver.OnReceive(context, intent);
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void OnReceive(Context context, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(intent);
			}
		}
	}
}
