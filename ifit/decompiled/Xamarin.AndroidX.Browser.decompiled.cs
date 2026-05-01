using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "791ebe2cb9b9b044bb1d30e9bd4c6097326f4bbe")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20230120.4")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "1/20/2023 8:31:40 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "android.support.customtabs", Managed = "Android.Support.CustomTabs")]
[assembly: NamespaceMapping(Java = "android.support.customtabs.trusted", Managed = "Android.Support.Customtabs.Trusted")]
[assembly: NamespaceMapping(Java = "androidx.browser.browseractions", Managed = "AndroidX.Browser.BrowserActions")]
[assembly: NamespaceMapping(Java = "androidx.browser.customtabs", Managed = "AndroidX.Browser.CustomTabs")]
[assembly: NamespaceMapping(Java = "androidx.browser.trusted", Managed = "AndroidX.Browser.Trusted")]
[assembly: NamespaceMapping(Java = "androidx.browser.trusted.sharing", Managed = "AndroidX.Browser.Trusted.Sharing")]
[assembly: NamespaceMapping(Java = "androidx.browser.trusted.splashscreens", Managed = "AndroidX.Browser.Trusted.Splashscreens")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.browser:browser'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Browser")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Browser")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
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
	}
}
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPILZL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, bool p2, IntPtr p3);
internal delegate bool _JniMarshal_PPJ_Z(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
namespace AndroidX.Browser.CustomTabs
{
	[Register("androidx/browser/customtabs/CustomTabsClient", DoNotGenerateAcw = true)]
	public class CustomTabsClient : Java.Lang.Object
	{
		public delegate void OnNavigationEventDelegate(int navigationEvent, Bundle extras);

		public delegate void ExtraCallbackDelegate(string callbackName, Bundle args);

		internal class CustomTabsCallbackImpl : CustomTabsCallback
		{
			private OnNavigationEventDelegate onNavigationEventHandler;

			private ExtraCallbackDelegate extraCallbackHandler;

			public CustomTabsCallbackImpl(OnNavigationEventDelegate onNavigationEventHandler)
			{
				this.onNavigationEventHandler = onNavigationEventHandler;
			}

			public CustomTabsCallbackImpl(OnNavigationEventDelegate onNavigationEventHandler, ExtraCallbackDelegate extraCallbackHandler)
			{
				this.onNavigationEventHandler = onNavigationEventHandler;
				this.extraCallbackHandler = extraCallbackHandler;
			}

			public override void OnNavigationEvent(int navigationEvent, Bundle extras)
			{
				if (onNavigationEventHandler != null)
				{
					onNavigationEventHandler(navigationEvent, extras);
				}
			}

			public override void ExtraCallback(string callbackName, Bundle args)
			{
				if (extraCallbackHandler != null)
				{
					extraCallbackHandler(callbackName, args);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsClient", typeof(CustomTabsClient));

		private static Delegate cb_attachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_;

		private static Delegate cb_extraCommand_Ljava_lang_String_Landroid_os_Bundle_;

		private static Delegate cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_;

		private static Delegate cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_I;

		private static Delegate cb_warmup_J;

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

		public CustomTabsSession NewSession(OnNavigationEventDelegate onNavigationEventHandler)
		{
			return NewSession(new CustomTabsCallbackImpl(onNavigationEventHandler));
		}

		public CustomTabsSession NewSession(OnNavigationEventDelegate onNavigationEventHandler, ExtraCallbackDelegate extraCallbackHandler)
		{
			return NewSession(new CustomTabsCallbackImpl(onNavigationEventHandler, extraCallbackHandler));
		}

		protected CustomTabsClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetAttachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_Handler()
		{
			if ((object)cb_attachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_ == null)
			{
				cb_attachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AttachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_));
			}
			return cb_attachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_;
		}

		private static IntPtr n_AttachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_(IntPtr jnienv, IntPtr native__this, IntPtr native_session)
		{
			CustomTabsClient customTabsClient = Java.Lang.Object.GetObject<CustomTabsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomTabsSession.PendingSession session = Java.Lang.Object.GetObject<CustomTabsSession.PendingSession>(native_session, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(customTabsClient.AttachSession(session));
		}

		[Register("attachSession", "(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsSession;", "GetAttachSession_Landroidx_browser_customtabs_CustomTabsSession_PendingSession_Handler")]
		public unsafe virtual CustomTabsSession AttachSession(CustomTabsSession.PendingSession session)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CustomTabsSession>(_members.InstanceMethods.InvokeVirtualObjectMethod("attachSession.(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsSession;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(session);
			}
		}

		[Register("bindCustomTabsService", "(Landroid/content/Context;Ljava/lang/String;Landroidx/browser/customtabs/CustomTabsServiceConnection;)Z", "")]
		public unsafe static bool BindCustomTabsService(Context context, string packageName, CustomTabsServiceConnection connection)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(connection?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("bindCustomTabsService.(Landroid/content/Context;Ljava/lang/String;Landroidx/browser/customtabs/CustomTabsServiceConnection;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(connection);
			}
		}

		[Register("bindCustomTabsServicePreservePriority", "(Landroid/content/Context;Ljava/lang/String;Landroidx/browser/customtabs/CustomTabsServiceConnection;)Z", "")]
		public unsafe static bool BindCustomTabsServicePreservePriority(Context context, string packageName, CustomTabsServiceConnection connection)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(connection?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("bindCustomTabsServicePreservePriority.(Landroid/content/Context;Ljava/lang/String;Landroidx/browser/customtabs/CustomTabsServiceConnection;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(connection);
			}
		}

		[Register("connectAndInitialize", "(Landroid/content/Context;Ljava/lang/String;)Z", "")]
		public unsafe static bool ConnectAndInitialize(Context context, string packageName)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("connectAndInitialize.(Landroid/content/Context;Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetExtraCommand_Ljava_lang_String_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_extraCommand_Ljava_lang_String_Landroid_os_Bundle_ == null)
			{
				cb_extraCommand_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ExtraCommand_Ljava_lang_String_Landroid_os_Bundle_));
			}
			return cb_extraCommand_Ljava_lang_String_Landroid_os_Bundle_;
		}

		private static IntPtr n_ExtraCommand_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_commandName, IntPtr native_args)
		{
			CustomTabsClient customTabsClient = Java.Lang.Object.GetObject<CustomTabsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string commandName = JNIEnv.GetString(native_commandName, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(customTabsClient.ExtraCommand(commandName, args));
		}

		[Register("extraCommand", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetExtraCommand_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public unsafe virtual Bundle ExtraCommand(string commandName, Bundle args)
		{
			IntPtr intPtr = JNIEnv.NewString(commandName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("extraCommand.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(args);
			}
		}

		[Register("getPackageName", "(Landroid/content/Context;Ljava/util/List;)Ljava/lang/String;", "")]
		public unsafe static string GetPackageName(Context context, IList<string> packages)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(packages);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getPackageName.(Landroid/content/Context;Ljava/util/List;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(packages);
			}
		}

		[Register("getPackageName", "(Landroid/content/Context;Ljava/util/List;Z)Ljava/lang/String;", "")]
		public unsafe static string GetPackageName(Context context, IList<string> packages, bool ignoreDefault)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(packages);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(ignoreDefault);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getPackageName.(Landroid/content/Context;Ljava/util/List;Z)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(packages);
			}
		}

		[Register("newPendingSession", "(Landroid/content/Context;Landroidx/browser/customtabs/CustomTabsCallback;I)Landroidx/browser/customtabs/CustomTabsSession$PendingSession;", "")]
		public unsafe static CustomTabsSession.PendingSession NewPendingSession(Context context, CustomTabsCallback callback, int id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(id);
				return Java.Lang.Object.GetObject<CustomTabsSession.PendingSession>(_members.StaticMethods.InvokeObjectMethod("newPendingSession.(Landroid/content/Context;Landroidx/browser/customtabs/CustomTabsCallback;I)Landroidx/browser/customtabs/CustomTabsSession$PendingSession;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetNewSession_Landroidx_browser_customtabs_CustomTabsCallback_Handler()
		{
			if ((object)cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_ == null)
			{
				cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewSession_Landroidx_browser_customtabs_CustomTabsCallback_));
			}
			return cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_;
		}

		private static IntPtr n_NewSession_Landroidx_browser_customtabs_CustomTabsCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			CustomTabsClient customTabsClient = Java.Lang.Object.GetObject<CustomTabsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomTabsCallback callback = Java.Lang.Object.GetObject<CustomTabsCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(customTabsClient.NewSession(callback));
		}

		[Register("newSession", "(Landroidx/browser/customtabs/CustomTabsCallback;)Landroidx/browser/customtabs/CustomTabsSession;", "GetNewSession_Landroidx_browser_customtabs_CustomTabsCallback_Handler")]
		public unsafe virtual CustomTabsSession NewSession(CustomTabsCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CustomTabsSession>(_members.InstanceMethods.InvokeVirtualObjectMethod("newSession.(Landroidx/browser/customtabs/CustomTabsCallback;)Landroidx/browser/customtabs/CustomTabsSession;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetNewSession_Landroidx_browser_customtabs_CustomTabsCallback_IHandler()
		{
			if ((object)cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_I == null)
			{
				cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_NewSession_Landroidx_browser_customtabs_CustomTabsCallback_I));
			}
			return cb_newSession_Landroidx_browser_customtabs_CustomTabsCallback_I;
		}

		private static IntPtr n_NewSession_Landroidx_browser_customtabs_CustomTabsCallback_I(IntPtr jnienv, IntPtr native__this, IntPtr native__callback, int id)
		{
			CustomTabsClient customTabsClient = Java.Lang.Object.GetObject<CustomTabsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomTabsCallback callback = Java.Lang.Object.GetObject<CustomTabsCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(customTabsClient.NewSession(callback, id));
		}

		[Register("newSession", "(Landroidx/browser/customtabs/CustomTabsCallback;I)Landroidx/browser/customtabs/CustomTabsSession;", "GetNewSession_Landroidx_browser_customtabs_CustomTabsCallback_IHandler")]
		public unsafe virtual CustomTabsSession NewSession(CustomTabsCallback callback, int id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(id);
				return Java.Lang.Object.GetObject<CustomTabsSession>(_members.InstanceMethods.InvokeVirtualObjectMethod("newSession.(Landroidx/browser/customtabs/CustomTabsCallback;I)Landroidx/browser/customtabs/CustomTabsSession;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetWarmup_JHandler()
		{
			if ((object)cb_warmup_J == null)
			{
				cb_warmup_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_Z(n_Warmup_J));
			}
			return cb_warmup_J;
		}

		private static bool n_Warmup_J(IntPtr jnienv, IntPtr native__this, long flags)
		{
			return Java.Lang.Object.GetObject<CustomTabsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Warmup(flags);
		}

		[Register("warmup", "(J)Z", "GetWarmup_JHandler")]
		public unsafe virtual bool Warmup(long flags)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("warmup.(J)Z", this, ptr);
		}
	}
	public class CustomTabsActivityManager
	{
		public delegate void NavigationEventDelegate(int navigationEvent, Bundle extras);

		public delegate void ExtraCallbackDelegate(object sender, ExtraCallbackEventArgs e);

		public delegate void CustomTabsServiceConnectedDelegate(ComponentName name, CustomTabsClient client);

		public delegate void CustomTabsServiceDisconnectedDelegate(ComponentName name);

		public class ExtraCallbackEventArgs
		{
			[CompilerGenerated]
			private string <CallbackName>k__BackingField;

			[CompilerGenerated]
			private Bundle <Args>k__BackingField;

			public string CallbackName
			{
				[CompilerGenerated]
				set
				{
					<CallbackName>k__BackingField = value;
				}
			}

			public Bundle Args
			{
				[CompilerGenerated]
				set
				{
					<Args>k__BackingField = value;
				}
			}
		}

		private static CustomTabsActivityManager instance;

		private CustomTabsSession session;

		private CustomTabsServiceConnectionImpl connection;

		[CompilerGenerated]
		private NavigationEventDelegate NavigationEvent;

		[CompilerGenerated]
		private ExtraCallbackDelegate ExtraCallback;

		[CompilerGenerated]
		private CustomTabsServiceDisconnectedDelegate CustomTabsServiceDisconnected;

		public Activity ParentActivity { get; private set; }

		public CustomTabsClient Client { get; private set; }

		public CustomTabsSession Session
		{
			get
			{
				if (Client == null)
				{
					return null;
				}
				if (session == null)
				{
					session = Client.NewSession(delegate(int navEvent, Bundle extras)
					{
						NavigationEvent?.Invoke(navEvent, extras);
					}, delegate(string callbackName, Bundle args)
					{
						ExtraCallback?.Invoke(this, new ExtraCallbackEventArgs
						{
							CallbackName = callbackName,
							Args = args
						});
					});
				}
				return session;
			}
		}

		public event CustomTabsServiceConnectedDelegate CustomTabsServiceConnected;

		public static CustomTabsActivityManager From(Activity parentActivity, string servicePackageName = null)
		{
			if (instance == null)
			{
				instance = new CustomTabsActivityManager(parentActivity);
			}
			return instance;
		}

		public CustomTabsActivityManager(Activity parentActivity)
		{
			ParentActivity = parentActivity;
		}

		public bool BindService(string servicePackageName = null)
		{
			if (string.IsNullOrEmpty(servicePackageName))
			{
				servicePackageName = CustomTabsHelper.GetPackageNameToUse(ParentActivity);
				if (servicePackageName == null)
				{
					return false;
				}
			}
			connection = new CustomTabsServiceConnectionImpl
			{
				CustomTabsServiceConnectedHandler = delegate(ComponentName name, CustomTabsClient client)
				{
					Client = client;
					this.CustomTabsServiceConnected?.Invoke(name, client);
				},
				OnServiceDisconnectedHandler = delegate(ComponentName name)
				{
					CustomTabsServiceDisconnected?.Invoke(name);
				}
			};
			return CustomTabsClient.BindCustomTabsService(ParentActivity, servicePackageName, connection);
		}
	}
	public class CustomTabsHelper
	{
		private static string packageNameToUse;

		public static string[] Packages = new string[5] { "", "com.android.chrome", "com.chrome.beta", "com.chrome.dev", "com.google.android.apps.chrome" };

		public static string GetPackageNameToUse(Context context)
		{
			if (packageNameToUse != null)
			{
				return packageNameToUse;
			}
			PackageManager packageManager = context.PackageManager;
			Intent intent = new Intent("android.intent.action.VIEW", Android.Net.Uri.Parse("http://www.example.com"));
			ResolveInfo resolveInfo = packageManager.ResolveActivity(intent, (PackageInfoFlags)0);
			string text = null;
			if (resolveInfo != null)
			{
				text = resolveInfo.ActivityInfo.PackageName;
			}
			IList<ResolveInfo> list = packageManager.QueryIntentActivities(intent, (PackageInfoFlags)0);
			List<string> list2 = new List<string>();
			foreach (ResolveInfo item in list)
			{
				Intent intent2 = new Intent();
				intent2.SetAction("android.support.customtabs.action.CustomTabsService");
				intent2.SetPackage(item.ActivityInfo.PackageName);
				if (packageManager.ResolveService(intent2, (PackageInfoFlags)0) != null)
				{
					list2.Add(item.ActivityInfo.PackageName);
				}
			}
			if (!list2.Any())
			{
				packageNameToUse = null;
			}
			else if (list2.Count == 1)
			{
				packageNameToUse = list2[0];
			}
			else if (!string.IsNullOrEmpty(text) && !hasSpecializedHandlerIntents(context, intent) && list2.Contains(text))
			{
				packageNameToUse = text;
			}
			else if (list2.Contains("com.android.chrome"))
			{
				packageNameToUse = "com.android.chrome";
			}
			else if (list2.Contains("com.chrome.beta"))
			{
				packageNameToUse = "com.chrome.beta";
			}
			else if (list2.Contains("com.chrome.dev"))
			{
				packageNameToUse = "com.chrome.dev";
			}
			else if (list2.Contains("com.google.android.apps.chrome"))
			{
				packageNameToUse = "com.google.android.apps.chrome";
			}
			return packageNameToUse;
		}

		private static bool hasSpecializedHandlerIntents(Context context, Intent intent)
		{
			try
			{
				IList<ResolveInfo> list = context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.ResolvedFilter);
				if (list == null || list.Count == 0)
				{
					return false;
				}
				foreach (ResolveInfo item in list)
				{
					IntentFilter filter = item.Filter;
					if (filter != null && filter.CountDataAuthorities() != 0 && filter.CountDataPaths() != 0 && item.ActivityInfo != null)
					{
						return true;
					}
				}
			}
			catch (RuntimeException)
			{
				Log.Error("CustomTabsHelper", "Runtime exception while getting specialized handlers");
			}
			return false;
		}
	}
	internal class CustomTabsServiceConnectionImpl : CustomTabsServiceConnection
	{
		public Action<ComponentName, CustomTabsClient> CustomTabsServiceConnectedHandler { get; set; }

		public Action<ComponentName> OnServiceDisconnectedHandler { get; set; }

		public override void OnCustomTabsServiceConnected(ComponentName name, CustomTabsClient customTabsClient)
		{
			CustomTabsServiceConnectedHandler?.Invoke(name, customTabsClient);
		}

		public override void OnServiceDisconnected(ComponentName name)
		{
			OnServiceDisconnectedHandler?.Invoke(name);
		}
	}
	[Register("androidx/browser/customtabs/CustomTabColorSchemeParams", DoNotGenerateAcw = true)]
	public sealed class CustomTabColorSchemeParams : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabColorSchemeParams", typeof(CustomTabColorSchemeParams));

		[Register("navigationBarColor")]
		public Integer NavigationBarColor
		{
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("navigationBarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("navigationBarColor.Ljava/lang/Integer;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("navigationBarDividerColor")]
		public Integer NavigationBarDividerColor
		{
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("navigationBarDividerColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("navigationBarDividerColor.Ljava/lang/Integer;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("secondaryToolbarColor")]
		public Integer SecondaryToolbarColor
		{
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("secondaryToolbarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("secondaryToolbarColor.Ljava/lang/Integer;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("toolbarColor")]
		public Integer ToolbarColor
		{
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceFields.GetObjectValue("toolbarColor.Ljava/lang/Integer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("toolbarColor.Ljava/lang/Integer;", this, new JniObjectReference(jobject));
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

		internal CustomTabColorSchemeParams(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("androidx/browser/customtabs/CustomTabsCallback", DoNotGenerateAcw = true)]
	public class CustomTabsCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsCallback", typeof(CustomTabsCallback));

		private static Delegate cb_extraCallback_Ljava_lang_String_Landroid_os_Bundle_;

		private static Delegate cb_extraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_;

		private static Delegate cb_onMessageChannelReady_Landroid_os_Bundle_;

		private static Delegate cb_onNavigationEvent_ILandroid_os_Bundle_;

		private static Delegate cb_onPostMessage_Ljava_lang_String_Landroid_os_Bundle_;

		private static Delegate cb_onRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_;

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

		protected CustomTabsCallback(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomTabsCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetExtraCallback_Ljava_lang_String_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_extraCallback_Ljava_lang_String_Landroid_os_Bundle_ == null)
			{
				cb_extraCallback_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ExtraCallback_Ljava_lang_String_Landroid_os_Bundle_));
			}
			return cb_extraCallback_Ljava_lang_String_Landroid_os_Bundle_;
		}

		private static void n_ExtraCallback_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackName, IntPtr native_args)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string callbackName = JNIEnv.GetString(native_callbackName, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			customTabsCallback.ExtraCallback(callbackName, args);
		}

		[Register("extraCallback", "(Ljava/lang/String;Landroid/os/Bundle;)V", "GetExtraCallback_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public unsafe virtual void ExtraCallback(string callbackName, Bundle args)
		{
			IntPtr intPtr = JNIEnv.NewString(callbackName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("extraCallback.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetExtraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_extraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_ == null)
			{
				cb_extraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ExtraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_));
			}
			return cb_extraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_;
		}

		private static IntPtr n_ExtraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackName, IntPtr native_args)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string callbackName = JNIEnv.GetString(native_callbackName, JniHandleOwnership.DoNotTransfer);
			Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(customTabsCallback.ExtraCallbackWithResult(callbackName, args));
		}

		[Register("extraCallbackWithResult", "(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", "GetExtraCallbackWithResult_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public unsafe virtual Bundle ExtraCallbackWithResult(string callbackName, Bundle args)
		{
			IntPtr intPtr = JNIEnv.NewString(callbackName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("extraCallbackWithResult.(Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetOnMessageChannelReady_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onMessageChannelReady_Landroid_os_Bundle_ == null)
			{
				cb_onMessageChannelReady_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMessageChannelReady_Landroid_os_Bundle_));
			}
			return cb_onMessageChannelReady_Landroid_os_Bundle_;
		}

		private static void n_OnMessageChannelReady_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_extras)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			customTabsCallback.OnMessageChannelReady(extras);
		}

		[Register("onMessageChannelReady", "(Landroid/os/Bundle;)V", "GetOnMessageChannelReady_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnMessageChannelReady(Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMessageChannelReady.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetOnNavigationEvent_ILandroid_os_Bundle_Handler()
		{
			if ((object)cb_onNavigationEvent_ILandroid_os_Bundle_ == null)
			{
				cb_onNavigationEvent_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_OnNavigationEvent_ILandroid_os_Bundle_));
			}
			return cb_onNavigationEvent_ILandroid_os_Bundle_;
		}

		private static void n_OnNavigationEvent_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, int navigationEvent, IntPtr native_extras)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			customTabsCallback.OnNavigationEvent(navigationEvent, extras);
		}

		[Register("onNavigationEvent", "(ILandroid/os/Bundle;)V", "GetOnNavigationEvent_ILandroid_os_Bundle_Handler")]
		public unsafe virtual void OnNavigationEvent(int navigationEvent, Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(navigationEvent);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNavigationEvent.(ILandroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetOnPostMessage_Ljava_lang_String_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onPostMessage_Ljava_lang_String_Landroid_os_Bundle_ == null)
			{
				cb_onPostMessage_Ljava_lang_String_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnPostMessage_Ljava_lang_String_Landroid_os_Bundle_));
			}
			return cb_onPostMessage_Ljava_lang_String_Landroid_os_Bundle_;
		}

		private static void n_OnPostMessage_Ljava_lang_String_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_message, IntPtr native_extras)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			customTabsCallback.OnPostMessage(message, extras);
		}

		[Register("onPostMessage", "(Ljava/lang/String;Landroid/os/Bundle;)V", "GetOnPostMessage_Ljava_lang_String_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnPostMessage(string message, Bundle extras)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onPostMessage.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(extras);
			}
		}

		private static Delegate GetOnRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_Handler()
		{
			if ((object)cb_onRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_ == null)
			{
				cb_onRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILZL_V(n_OnRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_));
			}
			return cb_onRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_;
		}

		private static void n_OnRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, int relation, IntPtr native_requestedOrigin, bool result, IntPtr native_extras)
		{
			CustomTabsCallback customTabsCallback = Java.Lang.Object.GetObject<CustomTabsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri requestedOrigin = Java.Lang.Object.GetObject<Android.Net.Uri>(native_requestedOrigin, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			customTabsCallback.OnRelationshipValidationResult(relation, requestedOrigin, result, extras);
		}

		[Register("onRelationshipValidationResult", "(ILandroid/net/Uri;ZLandroid/os/Bundle;)V", "GetOnRelationshipValidationResult_ILandroid_net_Uri_ZLandroid_os_Bundle_Handler")]
		public unsafe virtual void OnRelationshipValidationResult(int relation, Android.Net.Uri requestedOrigin, bool result, Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(relation);
				ptr[1] = new JniArgumentValue(requestedOrigin?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(result);
				ptr[3] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onRelationshipValidationResult.(ILandroid/net/Uri;ZLandroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(requestedOrigin);
				GC.KeepAlive(extras);
			}
		}
	}
	[Register("androidx/browser/customtabs/CustomTabsIntent", DoNotGenerateAcw = true)]
	public sealed class CustomTabsIntent : Java.Lang.Object
	{
		[Register("androidx/browser/customtabs/CustomTabsIntent$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsIntent$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register(".ctor", "(Landroidx/browser/customtabs/CustomTabsSession;)V", "")]
			public unsafe Builder(CustomTabsSession session)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/browser/customtabs/CustomTabsSession;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroidx/browser/customtabs/CustomTabsSession;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(session);
				}
			}

			[Register("addDefaultShareMenuItem", "()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder AddDefaultShareMenuItem()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addDefaultShareMenuItem.()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("addMenuItem", "(Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder AddMenuItem(string label, PendingIntent pendingIntent)
			{
				IntPtr intPtr = JNIEnv.NewString(label);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addMenuItem.(Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(pendingIntent);
				}
			}

			[Register("addToolbarItem", "(ILandroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder AddToolbarItem(int id, Bitmap icon, string description, PendingIntent pendingIntent)
			{
				IntPtr intPtr = JNIEnv.NewString(description);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(id);
					ptr[1] = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(intPtr);
					ptr[3] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addToolbarItem.(ILandroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(icon);
					GC.KeepAlive(pendingIntent);
				}
			}

			[Register("build", "()Landroidx/browser/customtabs/CustomTabsIntent;", "")]
			public unsafe CustomTabsIntent Build()
			{
				return Java.Lang.Object.GetObject<CustomTabsIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/browser/customtabs/CustomTabsIntent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("enableUrlBarHiding", "()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder EnableUrlBarHiding()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableUrlBarHiding.()Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetActionButton(Bitmap icon, string description, PendingIntent pendingIntent)
			{
				IntPtr intPtr = JNIEnv.NewString(description);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(icon);
					GC.KeepAlive(pendingIntent);
				}
			}

			[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetActionButton(Bitmap icon, string description, PendingIntent pendingIntent, bool shouldTint)
			{
				IntPtr intPtr = JNIEnv.NewString(description);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(shouldTint);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;Landroid/app/PendingIntent;Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(icon);
					GC.KeepAlive(pendingIntent);
				}
			}

			[Register("setCloseButtonIcon", "(Landroid/graphics/Bitmap;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetCloseButtonIcon(Bitmap icon)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCloseButtonIcon.(Landroid/graphics/Bitmap;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(icon);
				}
			}

			[Register("setColorScheme", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetColorScheme(int colorScheme)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(colorScheme);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setColorScheme.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setColorSchemeParams", "(ILandroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetColorSchemeParams(int colorScheme, CustomTabColorSchemeParams @params)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(colorScheme);
					ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setColorSchemeParams.(ILandroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(@params);
				}
			}

			[Register("setDefaultColorSchemeParams", "(Landroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetDefaultColorSchemeParams(CustomTabColorSchemeParams @params)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultColorSchemeParams.(Landroidx/browser/customtabs/CustomTabColorSchemeParams;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(@params);
				}
			}

			[Register("setDefaultShareMenuItemEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetDefaultShareMenuItemEnabled(bool enabled)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enabled);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultShareMenuItemEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setExitAnimations", "(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetExitAnimations(Context context, int enterResId, int exitResId)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(enterResId);
					ptr[2] = new JniArgumentValue(exitResId);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExitAnimations.(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}

			[Register("setInstantAppsEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetInstantAppsEnabled(bool enabled)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enabled);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInstantAppsEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setNavigationBarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetNavigationBarColor(int color)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(color);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNavigationBarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setNavigationBarDividerColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetNavigationBarDividerColor(int color)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(color);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNavigationBarDividerColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setPendingSession", "(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetPendingSession(CustomTabsSession.PendingSession session)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPendingSession.(Landroidx/browser/customtabs/CustomTabsSession$PendingSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(session);
				}
			}

			[Register("setSecondaryToolbarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetSecondaryToolbarColor(int color)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(color);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSecondaryToolbarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setSecondaryToolbarViews", "(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetSecondaryToolbarViews(RemoteViews remoteViews, int[] clickableIDs, PendingIntent pendingIntent)
			{
				IntPtr intPtr = JNIEnv.NewArray(clickableIDs);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(remoteViews?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSecondaryToolbarViews.(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (clickableIDs != null)
					{
						JNIEnv.CopyArray(intPtr, clickableIDs);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(remoteViews);
					GC.KeepAlive(clickableIDs);
					GC.KeepAlive(pendingIntent);
				}
			}

			[Register("setSession", "(Landroidx/browser/customtabs/CustomTabsSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetSession(CustomTabsSession session)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(session?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSession.(Landroidx/browser/customtabs/CustomTabsSession;)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(session);
				}
			}

			[Register("setShareState", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetShareState(int shareState)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(shareState);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShareState.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setShowTitle", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetShowTitle(bool showTitle)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(showTitle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShowTitle.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setStartAnimations", "(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetStartAnimations(Context context, int enterResId, int exitResId)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(enterResId);
					ptr[2] = new JniArgumentValue(exitResId);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setStartAnimations.(Landroid/content/Context;II)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}

			[Register("setToolbarColor", "(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetToolbarColor(int color)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(color);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setToolbarColor.(I)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setUrlBarHidingEnabled", "(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", "")]
			public unsafe Builder SetUrlBarHidingEnabled(bool enabled)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enabled);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUrlBarHidingEnabled.(Z)Landroidx/browser/customtabs/CustomTabsIntent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsIntent", typeof(CustomTabsIntent));

		[Register("intent")]
		public Intent Intent
		{
			get
			{
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceFields.GetObjectValue("intent.Landroid/content/Intent;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("intent.Landroid/content/Intent;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("startAnimationBundle")]
		public Bundle StartAnimationBundle
		{
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceFields.GetObjectValue("startAnimationBundle.Landroid/os/Bundle;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("startAnimationBundle.Landroid/os/Bundle;", this, new JniObjectReference(jobject));
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

		public unsafe static int MaxToolbarItems
		{
			[Register("getMaxToolbarItems", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getMaxToolbarItems.()I", null);
			}
		}

		internal CustomTabsIntent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getColorSchemeParams", "(Landroid/content/Intent;I)Landroidx/browser/customtabs/CustomTabColorSchemeParams;", "")]
		public unsafe static CustomTabColorSchemeParams GetColorSchemeParams(Intent intent, int colorScheme)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(colorScheme);
				return Java.Lang.Object.GetObject<CustomTabColorSchemeParams>(_members.StaticMethods.InvokeObjectMethod("getColorSchemeParams.(Landroid/content/Intent;I)Landroidx/browser/customtabs/CustomTabColorSchemeParams;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[Register("launchUrl", "(Landroid/content/Context;Landroid/net/Uri;)V", "")]
		public unsafe void LaunchUrl(Context context, Android.Net.Uri url)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("launchUrl.(Landroid/content/Context;Landroid/net/Uri;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(url);
			}
		}

		[Register("setAlwaysUseBrowserUI", "(Landroid/content/Intent;)Landroid/content/Intent;", "")]
		public unsafe static Intent SetAlwaysUseBrowserUI(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Intent>(_members.StaticMethods.InvokeObjectMethod("setAlwaysUseBrowserUI.(Landroid/content/Intent;)Landroid/content/Intent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[Register("shouldAlwaysUseBrowserUI", "(Landroid/content/Intent;)Z", "")]
		public unsafe static bool ShouldAlwaysUseBrowserUI(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("shouldAlwaysUseBrowserUI.(Landroid/content/Intent;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
	[Register("androidx/browser/customtabs/CustomTabsServiceConnection", DoNotGenerateAcw = true)]
	public abstract class CustomTabsServiceConnection : Java.Lang.Object, IServiceConnection, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsServiceConnection", typeof(CustomTabsServiceConnection));

		private static Delegate cb_onCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_;

		private static Delegate cb_onServiceDisconnected_Landroid_content_ComponentName_;

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

		protected CustomTabsServiceConnection(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CustomTabsServiceConnection()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_Handler()
		{
			if ((object)cb_onCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_ == null)
			{
				cb_onCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_));
			}
			return cb_onCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_;
		}

		private static void n_OnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_client)
		{
			CustomTabsServiceConnection customTabsServiceConnection = Java.Lang.Object.GetObject<CustomTabsServiceConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName name = Java.Lang.Object.GetObject<ComponentName>(native_name, JniHandleOwnership.DoNotTransfer);
			CustomTabsClient client = Java.Lang.Object.GetObject<CustomTabsClient>(native_client, JniHandleOwnership.DoNotTransfer);
			customTabsServiceConnection.OnCustomTabsServiceConnected(name, client);
		}

		[Register("onCustomTabsServiceConnected", "(Landroid/content/ComponentName;Landroidx/browser/customtabs/CustomTabsClient;)V", "GetOnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_Handler")]
		public abstract void OnCustomTabsServiceConnected(ComponentName name, CustomTabsClient client);

		[Register("onServiceConnected", "(Landroid/content/ComponentName;Landroid/os/IBinder;)V", "")]
		public unsafe void OnServiceConnected(ComponentName name, IBinder service)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((service == null) ? IntPtr.Zero : ((Java.Lang.Object)service).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onServiceConnected.(Landroid/content/ComponentName;Landroid/os/IBinder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
				GC.KeepAlive(service);
			}
		}

		private static Delegate GetOnServiceDisconnected_Landroid_content_ComponentName_Handler()
		{
			if ((object)cb_onServiceDisconnected_Landroid_content_ComponentName_ == null)
			{
				cb_onServiceDisconnected_Landroid_content_ComponentName_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnServiceDisconnected_Landroid_content_ComponentName_));
			}
			return cb_onServiceDisconnected_Landroid_content_ComponentName_;
		}

		private static void n_OnServiceDisconnected_Landroid_content_ComponentName_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			CustomTabsServiceConnection customTabsServiceConnection = Java.Lang.Object.GetObject<CustomTabsServiceConnection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName name = Java.Lang.Object.GetObject<ComponentName>(native_name, JniHandleOwnership.DoNotTransfer);
			customTabsServiceConnection.OnServiceDisconnected(name);
		}

		[Register("onServiceDisconnected", "(Landroid/content/ComponentName;)V", "GetOnServiceDisconnected_Landroid_content_ComponentName_Handler")]
		public abstract void OnServiceDisconnected(ComponentName name);
	}
	[Register("androidx/browser/customtabs/CustomTabsServiceConnection", DoNotGenerateAcw = true)]
	internal class CustomTabsServiceConnectionInvoker : CustomTabsServiceConnection
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsServiceConnection", typeof(CustomTabsServiceConnectionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CustomTabsServiceConnectionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onCustomTabsServiceConnected", "(Landroid/content/ComponentName;Landroidx/browser/customtabs/CustomTabsClient;)V", "GetOnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroidx_browser_customtabs_CustomTabsClient_Handler")]
		public unsafe override void OnCustomTabsServiceConnected(ComponentName name, CustomTabsClient client)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(client?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onCustomTabsServiceConnected.(Landroid/content/ComponentName;Landroidx/browser/customtabs/CustomTabsClient;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
				GC.KeepAlive(client);
			}
		}

		[Register("onServiceDisconnected", "(Landroid/content/ComponentName;)V", "GetOnServiceDisconnected_Landroid_content_ComponentName_Handler")]
		public unsafe override void OnServiceDisconnected(ComponentName name)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(name?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onServiceDisconnected.(Landroid/content/ComponentName;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(name);
			}
		}
	}
	[Register("androidx/browser/customtabs/CustomTabsSession", DoNotGenerateAcw = true)]
	public sealed class CustomTabsSession : Java.Lang.Object
	{
		[Register("androidx/browser/customtabs/CustomTabsSession$PendingSession", DoNotGenerateAcw = true)]
		public class PendingSession : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsSession$PendingSession", typeof(PendingSession));

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

			protected PendingSession(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/CustomTabsSession", typeof(CustomTabsSession));

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

		internal CustomTabsSession(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("createMockSessionForTesting", "(Landroid/content/ComponentName;)Landroidx/browser/customtabs/CustomTabsSession;", "")]
		public unsafe static CustomTabsSession CreateMockSessionForTesting(ComponentName componentName)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(componentName?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CustomTabsSession>(_members.StaticMethods.InvokeObjectMethod("createMockSessionForTesting.(Landroid/content/ComponentName;)Landroidx/browser/customtabs/CustomTabsSession;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(componentName);
			}
		}

		[Register("mayLaunchUrl", "(Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z", "")]
		public unsafe bool MayLaunchUrl(Android.Net.Uri url, Bundle extras, IList<Bundle> otherLikelyBundles)
		{
			IntPtr intPtr = JavaList<Bundle>.ToLocalJniHandle(otherLikelyBundles);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("mayLaunchUrl.(Landroid/net/Uri;Landroid/os/Bundle;Ljava/util/List;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(url);
				GC.KeepAlive(extras);
				GC.KeepAlive(otherLikelyBundles);
			}
		}

		[Register("postMessage", "(Ljava/lang/String;Landroid/os/Bundle;)I", "")]
		public unsafe int PostMessage(string message, Bundle extras)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("postMessage.(Ljava/lang/String;Landroid/os/Bundle;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(extras);
			}
		}

		[Register("receiveFile", "(Landroid/net/Uri;ILandroid/os/Bundle;)Z", "")]
		public unsafe bool ReceiveFile(Android.Net.Uri uri, int purpose, Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(purpose);
				ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("receiveFile.(Landroid/net/Uri;ILandroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(uri);
				GC.KeepAlive(extras);
			}
		}

		[Register("requestPostMessageChannel", "(Landroid/net/Uri;)Z", "")]
		public unsafe bool RequestPostMessageChannel(Android.Net.Uri postMessageOrigin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(postMessageOrigin?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("requestPostMessageChannel.(Landroid/net/Uri;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(postMessageOrigin);
			}
		}

		[Register("setActionButton", "(Landroid/graphics/Bitmap;Ljava/lang/String;)Z", "")]
		public unsafe bool SetActionButton(Bitmap icon, string description)
		{
			IntPtr intPtr = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("setActionButton.(Landroid/graphics/Bitmap;Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(icon);
			}
		}

		[Register("setSecondaryToolbarViews", "(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Z", "")]
		public unsafe bool SetSecondaryToolbarViews(RemoteViews remoteViews, int[] clickableIDs, PendingIntent pendingIntent)
		{
			IntPtr intPtr = JNIEnv.NewArray(clickableIDs);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(remoteViews?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("setSecondaryToolbarViews.(Landroid/widget/RemoteViews;[ILandroid/app/PendingIntent;)Z", this, ptr);
			}
			finally
			{
				if (clickableIDs != null)
				{
					JNIEnv.CopyArray(intPtr, clickableIDs);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(remoteViews);
				GC.KeepAlive(clickableIDs);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("setToolbarItem", "(ILandroid/graphics/Bitmap;Ljava/lang/String;)Z", "")]
		public unsafe bool SetToolbarItem(int id, Bitmap icon, string description)
		{
			IntPtr intPtr = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("setToolbarItem.(ILandroid/graphics/Bitmap;Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(icon);
			}
		}

		[Register("validateRelationship", "(ILandroid/net/Uri;Landroid/os/Bundle;)Z", "")]
		public unsafe bool ValidateRelationship(int relation, Android.Net.Uri origin, Bundle extras)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(relation);
				ptr[1] = new JniArgumentValue(origin?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("validateRelationship.(ILandroid/net/Uri;Landroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(origin);
				GC.KeepAlive(extras);
			}
		}
	}
}
