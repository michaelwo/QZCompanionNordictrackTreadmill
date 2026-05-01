using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook.login", Managed = "Xamarin.Facebook.Login")]
[assembly: NamespaceMapping(Java = "com.facebook.login.widget", Managed = "Xamarin.Facebook.Login.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - Login")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.Login.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.Login.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
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
		private static string[] package_com_facebook_login_mappings;

		private static string[] package_com_facebook_login_widget_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[2] { "com/facebook/login", "com/facebook/login/widget" }, new Converter<string, Type>[2] { lookup_com_facebook_login_package, lookup_com_facebook_login_widget_package });
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

		private static Type lookup_com_facebook_login_package(string klass)
		{
			if (package_com_facebook_login_mappings == null)
			{
				package_com_facebook_login_mappings = new string[3] { "com/facebook/login/BuildConfig:Xamarin.Facebook.Login.BuildConfig", "com/facebook/login/DeviceLoginManager:Xamarin.Facebook.Login.DeviceLoginManager", "com/facebook/login/Login:Xamarin.Facebook.Login.Login" };
			}
			return Lookup(package_com_facebook_login_mappings, klass);
		}

		private static Type lookup_com_facebook_login_widget_package(string klass)
		{
			if (package_com_facebook_login_widget_mappings == null)
			{
				package_com_facebook_login_widget_mappings = new string[7] { "com/facebook/login/widget/DeviceLoginButton:Xamarin.Facebook.Login.Widget.DeviceLoginButton", "com/facebook/login/widget/LoginButton:Xamarin.Facebook.Login.Widget.LoginButton", "com/facebook/login/widget/LoginButton$LoginClickListener:Xamarin.Facebook.Login.Widget.LoginButton/LoginClickListener", "com/facebook/login/widget/LoginButton$ToolTipMode:Xamarin.Facebook.Login.Widget.LoginButton/ToolTipMode", "com/facebook/login/widget/ProfilePictureView:Xamarin.Facebook.Login.Widget.ProfilePictureView", "com/facebook/login/widget/ToolTipPopup:Xamarin.Facebook.Login.Widget.ToolTipPopup", "com/facebook/login/widget/ToolTipPopup$Style:Xamarin.Facebook.Login.Widget.ToolTipPopup/Style" };
			}
			return Lookup(package_com_facebook_login_widget_mappings, klass);
		}
	}
}
namespace Xamarin.Facebook
{
	public class GraphRequestAsyncTask : AsyncTask
	{
		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			return new Java.Lang.Object(JNIEnv.CallObjectMethod(base.Handle, JNIEnv.GetMethodID(JNIEnv.GetObjectClass(base.Handle), "doInBackground", "([Ljava/lang/Object;)Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Xamarin.Facebook.Login
{
	[Register("com/facebook/login/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.login";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/BuildConfig", typeof(BuildConfig));

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
	[Register("com/facebook/login/DeviceLoginManager", DoNotGenerateAcw = true)]
	public class DeviceLoginManager : LoginManager
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/DeviceLoginManager", typeof(DeviceLoginManager));

		private static Delegate cb_getDeviceAuthTargetUserId;

		private static Delegate cb_setDeviceAuthTargetUserId_Ljava_lang_String_;

		private static Delegate cb_getDeviceRedirectUri;

		private static Delegate cb_setDeviceRedirectUri_Landroid_net_Uri_;

		private static Delegate cb_createLoginRequest_Ljava_util_Collection_;

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

		public unsafe virtual string DeviceAuthTargetUserId
		{
			[Register("getDeviceAuthTargetUserId", "()Ljava/lang/String;", "GetGetDeviceAuthTargetUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeviceAuthTargetUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDeviceAuthTargetUserId", "(Ljava/lang/String;)V", "GetSetDeviceAuthTargetUserId_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDeviceAuthTargetUserId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual Android.Net.Uri DeviceRedirectUri
		{
			[Register("getDeviceRedirectUri", "()Landroid/net/Uri;", "GetGetDeviceRedirectUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeviceRedirectUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDeviceRedirectUri", "(Landroid/net/Uri;)V", "GetSetDeviceRedirectUri_Landroid_net_Uri_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDeviceRedirectUri.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public new unsafe static DeviceLoginManager Instance
		{
			[Register("getInstance", "()Lcom/facebook/login/DeviceLoginManager;", "")]
			get
			{
				return Java.Lang.Object.GetObject<DeviceLoginManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/facebook/login/DeviceLoginManager;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected DeviceLoginManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DeviceLoginManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDeviceAuthTargetUserIdHandler()
		{
			if ((object)cb_getDeviceAuthTargetUserId == null)
			{
				cb_getDeviceAuthTargetUserId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeviceAuthTargetUserId));
			}
			return cb_getDeviceAuthTargetUserId;
		}

		private static IntPtr n_GetDeviceAuthTargetUserId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DeviceLoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeviceAuthTargetUserId);
		}

		private static Delegate GetSetDeviceAuthTargetUserId_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDeviceAuthTargetUserId_Ljava_lang_String_ == null)
			{
				cb_setDeviceAuthTargetUserId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDeviceAuthTargetUserId_Ljava_lang_String_));
			}
			return cb_setDeviceAuthTargetUserId_Ljava_lang_String_;
		}

		private static void n_SetDeviceAuthTargetUserId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetUserId)
		{
			DeviceLoginManager deviceLoginManager = Java.Lang.Object.GetObject<DeviceLoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string deviceAuthTargetUserId = JNIEnv.GetString(native_targetUserId, JniHandleOwnership.DoNotTransfer);
			deviceLoginManager.DeviceAuthTargetUserId = deviceAuthTargetUserId;
		}

		private static Delegate GetGetDeviceRedirectUriHandler()
		{
			if ((object)cb_getDeviceRedirectUri == null)
			{
				cb_getDeviceRedirectUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeviceRedirectUri));
			}
			return cb_getDeviceRedirectUri;
		}

		private static IntPtr n_GetDeviceRedirectUri(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeviceLoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeviceRedirectUri);
		}

		private static Delegate GetSetDeviceRedirectUri_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setDeviceRedirectUri_Landroid_net_Uri_ == null)
			{
				cb_setDeviceRedirectUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDeviceRedirectUri_Landroid_net_Uri_));
			}
			return cb_setDeviceRedirectUri_Landroid_net_Uri_;
		}

		private static void n_SetDeviceRedirectUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_uri)
		{
			DeviceLoginManager deviceLoginManager = Java.Lang.Object.GetObject<DeviceLoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri deviceRedirectUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			deviceLoginManager.DeviceRedirectUri = deviceRedirectUri;
		}

		private static Delegate GetCreateLoginRequest_Ljava_util_Collection_Handler()
		{
			if ((object)cb_createLoginRequest_Ljava_util_Collection_ == null)
			{
				cb_createLoginRequest_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateLoginRequest_Ljava_util_Collection_));
			}
			return cb_createLoginRequest_Ljava_util_Collection_;
		}

		private static IntPtr n_CreateLoginRequest_Ljava_util_Collection_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			DeviceLoginManager deviceLoginManager = Java.Lang.Object.GetObject<DeviceLoginManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<string> permissions = JavaCollection<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(deviceLoginManager.CreateLoginRequest(permissions));
		}

		[Register("createLoginRequest", "(Ljava/util/Collection;)Lcom/facebook/login/LoginClient$Request;", "GetCreateLoginRequest_Ljava_util_Collection_Handler")]
		protected new unsafe virtual LoginClient.Request CreateLoginRequest(ICollection<string> permissions)
		{
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoginClient.Request>(_members.InstanceMethods.InvokeVirtualObjectMethod("createLoginRequest.(Ljava/util/Collection;)Lcom/facebook/login/LoginClient$Request;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}
	}
	[Register("com/facebook/login/Login", DoNotGenerateAcw = true)]
	public class Login : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/Login", typeof(Login));

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

		protected Login(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Login()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
}
namespace Xamarin.Facebook.Login.Widget
{
	[Register("com/facebook/login/widget/DeviceLoginButton", DoNotGenerateAcw = true)]
	public class DeviceLoginButton : LoginButton
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/DeviceLoginButton", typeof(DeviceLoginButton));

		private static Delegate cb_getDeviceRedirectUri;

		private static Delegate cb_setDeviceRedirectUri_Landroid_net_Uri_;

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

		public unsafe virtual Android.Net.Uri DeviceRedirectUri
		{
			[Register("getDeviceRedirectUri", "()Landroid/net/Uri;", "GetGetDeviceRedirectUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeviceRedirectUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDeviceRedirectUri", "(Landroid/net/Uri;)V", "GetSetDeviceRedirectUri_Landroid_net_Uri_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDeviceRedirectUri.(Landroid/net/Uri;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected DeviceLoginButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe DeviceLoginButton(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe DeviceLoginButton(Context context, IAttributeSet attrs)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe DeviceLoginButton(Context context, IAttributeSet attrs, int defStyle)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetDeviceRedirectUriHandler()
		{
			if ((object)cb_getDeviceRedirectUri == null)
			{
				cb_getDeviceRedirectUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeviceRedirectUri));
			}
			return cb_getDeviceRedirectUri;
		}

		private static IntPtr n_GetDeviceRedirectUri(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeviceLoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeviceRedirectUri);
		}

		private static Delegate GetSetDeviceRedirectUri_Landroid_net_Uri_Handler()
		{
			if ((object)cb_setDeviceRedirectUri_Landroid_net_Uri_ == null)
			{
				cb_setDeviceRedirectUri_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDeviceRedirectUri_Landroid_net_Uri_));
			}
			return cb_setDeviceRedirectUri_Landroid_net_Uri_;
		}

		private static void n_SetDeviceRedirectUri_Landroid_net_Uri_(IntPtr jnienv, IntPtr native__this, IntPtr native_uri)
		{
			DeviceLoginButton deviceLoginButton = Java.Lang.Object.GetObject<DeviceLoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri deviceRedirectUri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			deviceLoginButton.DeviceRedirectUri = deviceRedirectUri;
		}
	}
	[Register("com/facebook/login/widget/LoginButton", DoNotGenerateAcw = true)]
	public class LoginButton : FacebookButtonBase
	{
		[Register("com/facebook/login/widget/LoginButton$LoginClickListener", DoNotGenerateAcw = true)]
		protected internal class LoginClickListener : Java.Lang.Object, IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/LoginButton$LoginClickListener", typeof(LoginClickListener));

			private static Delegate cb_isFamilyLogin;

			private static Delegate cb_getLoginManager;

			private static Delegate cb_getLoginTargetApp;

			private static Delegate cb_onClick_Landroid_view_View_;

			private static Delegate cb_performLogin;

			private static Delegate cb_performLogout_Landroid_content_Context_;

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

			protected unsafe virtual bool IsFamilyLogin
			{
				[Register("isFamilyLogin", "()Z", "GetIsFamilyLoginHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFamilyLogin.()Z", this, null);
				}
			}

			protected unsafe virtual LoginManager LoginManager
			{
				[Register("getLoginManager", "()Lcom/facebook/login/LoginManager;", "GetGetLoginManagerHandler")]
				get
				{
					return Java.Lang.Object.GetObject<LoginManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoginManager.()Lcom/facebook/login/LoginManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected unsafe virtual LoginTargetApp LoginTargetApp
			{
				[Register("getLoginTargetApp", "()Lcom/facebook/login/LoginTargetApp;", "GetGetLoginTargetAppHandler")]
				get
				{
					return Java.Lang.Object.GetObject<LoginTargetApp>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoginTargetApp.()Lcom/facebook/login/LoginTargetApp;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			protected LoginClickListener(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/facebook/login/widget/LoginButton;)V", "")]
			protected unsafe LoginClickListener(LoginButton __self)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
				}
				finally
				{
					GC.KeepAlive(__self);
				}
			}

			private static Delegate GetIsFamilyLoginHandler()
			{
				if ((object)cb_isFamilyLogin == null)
				{
					cb_isFamilyLogin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFamilyLogin));
				}
				return cb_isFamilyLogin;
			}

			private static bool n_IsFamilyLogin(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFamilyLogin;
			}

			private static Delegate GetGetLoginManagerHandler()
			{
				if ((object)cb_getLoginManager == null)
				{
					cb_getLoginManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoginManager));
				}
				return cb_getLoginManager;
			}

			private static IntPtr n_GetLoginManager(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoginManager);
			}

			private static Delegate GetGetLoginTargetAppHandler()
			{
				if ((object)cb_getLoginTargetApp == null)
				{
					cb_getLoginTargetApp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoginTargetApp));
				}
				return cb_getLoginTargetApp;
			}

			private static IntPtr n_GetLoginTargetApp(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoginTargetApp);
			}

			private static Delegate GetOnClick_Landroid_view_View_Handler()
			{
				if ((object)cb_onClick_Landroid_view_View_ == null)
				{
					cb_onClick_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnClick_Landroid_view_View_));
				}
				return cb_onClick_Landroid_view_View_;
			}

			private static void n_OnClick_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_v)
			{
				LoginClickListener loginClickListener = Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				loginClickListener.OnClick(v);
			}

			[Register("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler")]
			public unsafe virtual void OnClick(View v)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onClick.(Landroid/view/View;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(v);
				}
			}

			private static Delegate GetPerformLoginHandler()
			{
				if ((object)cb_performLogin == null)
				{
					cb_performLogin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_PerformLogin));
				}
				return cb_performLogin;
			}

			private static void n_PerformLogin(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformLogin();
			}

			[Register("performLogin", "()V", "GetPerformLoginHandler")]
			protected unsafe virtual void PerformLogin()
			{
				_members.InstanceMethods.InvokeVirtualVoidMethod("performLogin.()V", this, null);
			}

			private static Delegate GetPerformLogout_Landroid_content_Context_Handler()
			{
				if ((object)cb_performLogout_Landroid_content_Context_ == null)
				{
					cb_performLogout_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PerformLogout_Landroid_content_Context_));
				}
				return cb_performLogout_Landroid_content_Context_;
			}

			private static void n_PerformLogout_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
			{
				LoginClickListener loginClickListener = Java.Lang.Object.GetObject<LoginClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				loginClickListener.PerformLogout(context);
			}

			[Register("performLogout", "(Landroid/content/Context;)V", "GetPerformLogout_Landroid_content_Context_Handler")]
			protected unsafe virtual void PerformLogout(Context context)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("performLogout.(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(context);
				}
			}
		}

		[Register("com/facebook/login/widget/LoginButton$ToolTipMode", DoNotGenerateAcw = true)]
		public sealed class ToolTipMode : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/LoginButton$ToolTipMode", typeof(ToolTipMode));

			[Register("AUTOMATIC")]
			public static ToolTipMode Automatic => Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticFields.GetObjectValue("AUTOMATIC.Lcom/facebook/login/widget/LoginButton$ToolTipMode;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("DEFAULT")]
			public static ToolTipMode Default
			{
				get
				{
					return Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/facebook/login/widget/LoginButton$ToolTipMode;").Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.StaticFields.SetValue("DEFAULT.Lcom/facebook/login/widget/LoginButton$ToolTipMode;", new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("DISPLAY_ALWAYS")]
			public static ToolTipMode DisplayAlways => Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticFields.GetObjectValue("DISPLAY_ALWAYS.Lcom/facebook/login/widget/LoginButton$ToolTipMode;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NEVER_DISPLAY")]
			public static ToolTipMode NeverDisplay => Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticFields.GetObjectValue("NEVER_DISPLAY.Lcom/facebook/login/widget/LoginButton$ToolTipMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

			public unsafe int Value
			{
				[Register("getValue", "()I", "")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractInt32Method("getValue.()I", this, null);
				}
			}

			internal ToolTipMode(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("fromInt", "(I)Lcom/facebook/login/widget/LoginButton$ToolTipMode;", "")]
			public unsafe static ToolTipMode FromInt(int enumValue)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enumValue);
				return Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticMethods.InvokeObjectMethod("fromInt.(I)Lcom/facebook/login/widget/LoginButton$ToolTipMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/login/widget/LoginButton$ToolTipMode;", "")]
			public unsafe static ToolTipMode ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ToolTipMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/login/widget/LoginButton$ToolTipMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/login/widget/LoginButton$ToolTipMode;", "")]
			public unsafe static ToolTipMode[] Values()
			{
				return (ToolTipMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/login/widget/LoginButton$ToolTipMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ToolTipMode));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/LoginButton", typeof(LoginButton));

		private static Delegate cb_getAuthType;

		private static Delegate cb_setAuthType_Ljava_lang_String_;

		private static Delegate cb_getCallbackManager;

		private static Delegate cb_getDefaultAudience;

		private static Delegate cb_setDefaultAudience_Lcom_facebook_login_DefaultAudience_;

		private static Delegate cb_getDefaultRequestCode;

		private static Delegate cb_getLoggerID;

		private static Delegate cb_getLoginBehavior;

		private static Delegate cb_setLoginBehavior_Lcom_facebook_login_LoginBehavior_;

		private static Delegate cb_getLoginButtonContinueLabel;

		private static Delegate cb_getLoginTargetApp;

		private static Delegate cb_setLoginTargetApp_Lcom_facebook_login_LoginTargetApp_;

		private static Delegate cb_getMessengerPageId;

		private static Delegate cb_setMessengerPageId_Ljava_lang_String_;

		private static Delegate cb_getNewLoginClickListener;

		private static Delegate cb_getResetMessengerState;

		private static Delegate cb_setResetMessengerState_Z;

		private static Delegate cb_getShouldSkipAccountDeduplication;

		private static Delegate cb_getToolTipDisplayTime;

		private static Delegate cb_setToolTipDisplayTime_J;

		private static Delegate cb_clearPermissions;

		private static Delegate cb_dismissToolTip;

		private static Delegate cb_getLoginButtonWidth_I;

		private static Delegate cb_getToolTipMode;

		private static Delegate cb_parseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_setButtonIcon;

		private static Delegate cb_setButtonRadius;

		private static Delegate cb_setButtonText;

		private static Delegate cb_setButtonTransparency;

		private static Delegate cb_setLoginText_Ljava_lang_String_;

		private static Delegate cb_setLogoutText_Ljava_lang_String_;

		private static Delegate cb_setPermissions_arrayLjava_lang_String_;

		private static Delegate cb_setPermissions_Ljava_util_List_;

		private static Delegate cb_setPublishPermissions_arrayLjava_lang_String_;

		private static Delegate cb_setPublishPermissions_Ljava_util_List_;

		private static Delegate cb_setReadPermissions_arrayLjava_lang_String_;

		private static Delegate cb_setReadPermissions_Ljava_util_List_;

		private static Delegate cb_setToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_;

		private static Delegate cb_setToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_;

		private static Delegate cb_unregisterCallback_Lcom_facebook_CallbackManager_;

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

		public unsafe virtual string AuthType
		{
			[Register("getAuthType", "()Ljava/lang/String;", "GetGetAuthTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getAuthType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setAuthType", "(Ljava/lang/String;)V", "GetSetAuthType_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setAuthType.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual ICallbackManager CallbackManager
		{
			[Register("getCallbackManager", "()Lcom/facebook/CallbackManager;", "GetGetCallbackManagerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICallbackManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCallbackManager.()Lcom/facebook/CallbackManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual DefaultAudience DefaultAudience
		{
			[Register("getDefaultAudience", "()Lcom/facebook/login/DefaultAudience;", "GetGetDefaultAudienceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DefaultAudience>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultAudience.()Lcom/facebook/login/DefaultAudience;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDefaultAudience", "(Lcom/facebook/login/DefaultAudience;)V", "GetSetDefaultAudience_Lcom_facebook_login_DefaultAudience_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDefaultAudience.(Lcom/facebook/login/DefaultAudience;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected unsafe override int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "GetGetDefaultRequestCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDefaultRequestCode.()I", this, null);
			}
		}

		public unsafe virtual string LoggerID
		{
			[Register("getLoggerID", "()Ljava/lang/String;", "GetGetLoggerIDHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoggerID.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual LoginBehavior LoginBehavior
		{
			[Register("getLoginBehavior", "()Lcom/facebook/login/LoginBehavior;", "GetGetLoginBehaviorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LoginBehavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoginBehavior.()Lcom/facebook/login/LoginBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLoginBehavior", "(Lcom/facebook/login/LoginBehavior;)V", "GetSetLoginBehavior_Lcom_facebook_login_LoginBehavior_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setLoginBehavior.(Lcom/facebook/login/LoginBehavior;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected unsafe virtual int LoginButtonContinueLabel
		{
			[Register("getLoginButtonContinueLabel", "()I", "GetGetLoginButtonContinueLabelHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLoginButtonContinueLabel.()I", this, null);
			}
		}

		public unsafe virtual LoginTargetApp LoginTargetApp
		{
			[Register("getLoginTargetApp", "()Lcom/facebook/login/LoginTargetApp;", "GetGetLoginTargetAppHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LoginTargetApp>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLoginTargetApp.()Lcom/facebook/login/LoginTargetApp;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLoginTargetApp", "(Lcom/facebook/login/LoginTargetApp;)V", "GetSetLoginTargetApp_Lcom_facebook_login_LoginTargetApp_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setLoginTargetApp.(Lcom/facebook/login/LoginTargetApp;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual string MessengerPageId
		{
			[Register("getMessengerPageId", "()Ljava/lang/String;", "GetGetMessengerPageIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessengerPageId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMessengerPageId", "(Ljava/lang/String;)V", "GetSetMessengerPageId_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setMessengerPageId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		protected unsafe virtual LoginClickListener NewLoginClickListener
		{
			[Register("getNewLoginClickListener", "()Lcom/facebook/login/widget/LoginButton$LoginClickListener;", "GetGetNewLoginClickListenerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LoginClickListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNewLoginClickListener.()Lcom/facebook/login/widget/LoginButton$LoginClickListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool ResetMessengerState
		{
			[Register("getResetMessengerState", "()Z", "GetGetResetMessengerStateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getResetMessengerState.()Z", this, null);
			}
			[Register("setResetMessengerState", "(Z)V", "GetSetResetMessengerState_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setResetMessengerState.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool ShouldSkipAccountDeduplication
		{
			[Register("getShouldSkipAccountDeduplication", "()Z", "GetGetShouldSkipAccountDeduplicationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getShouldSkipAccountDeduplication.()Z", this, null);
			}
		}

		public unsafe virtual long ToolTipDisplayTime
		{
			[Register("getToolTipDisplayTime", "()J", "GetGetToolTipDisplayTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getToolTipDisplayTime.()J", this, null);
			}
			[Register("setToolTipDisplayTime", "(J)V", "GetSetToolTipDisplayTime_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setToolTipDisplayTime.(J)V", this, ptr);
			}
		}

		protected LoginButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe LoginButton(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LoginButton(Context context, IAttributeSet attrs)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe LoginButton(Context context, IAttributeSet attrs, int defStyle)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", "")]
		protected unsafe LoginButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes, string analyticsButtonCreatedEventName, string analyticsButtonTappedEventName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(analyticsButtonCreatedEventName);
			IntPtr intPtr2 = JNIEnv.NewString(analyticsButtonTappedEventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				ptr[4] = new JniArgumentValue(intPtr);
				ptr[5] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;IILjava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetAuthTypeHandler()
		{
			if ((object)cb_getAuthType == null)
			{
				cb_getAuthType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAuthType));
			}
			return cb_getAuthType;
		}

		private static IntPtr n_GetAuthType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AuthType);
		}

		private static Delegate GetSetAuthType_Ljava_lang_String_Handler()
		{
			if ((object)cb_setAuthType_Ljava_lang_String_ == null)
			{
				cb_setAuthType_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAuthType_Ljava_lang_String_));
			}
			return cb_setAuthType_Ljava_lang_String_;
		}

		private static void n_SetAuthType_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_authType)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			loginButton.AuthType = authType;
		}

		private static Delegate GetGetCallbackManagerHandler()
		{
			if ((object)cb_getCallbackManager == null)
			{
				cb_getCallbackManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCallbackManager));
			}
			return cb_getCallbackManager;
		}

		private static IntPtr n_GetCallbackManager(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CallbackManager);
		}

		private static Delegate GetGetDefaultAudienceHandler()
		{
			if ((object)cb_getDefaultAudience == null)
			{
				cb_getDefaultAudience = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultAudience));
			}
			return cb_getDefaultAudience;
		}

		private static IntPtr n_GetDefaultAudience(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultAudience);
		}

		private static Delegate GetSetDefaultAudience_Lcom_facebook_login_DefaultAudience_Handler()
		{
			if ((object)cb_setDefaultAudience_Lcom_facebook_login_DefaultAudience_ == null)
			{
				cb_setDefaultAudience_Lcom_facebook_login_DefaultAudience_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDefaultAudience_Lcom_facebook_login_DefaultAudience_));
			}
			return cb_setDefaultAudience_Lcom_facebook_login_DefaultAudience_;
		}

		private static void n_SetDefaultAudience_Lcom_facebook_login_DefaultAudience_(IntPtr jnienv, IntPtr native__this, IntPtr native_defaultAudience)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DefaultAudience defaultAudience = Java.Lang.Object.GetObject<DefaultAudience>(native_defaultAudience, JniHandleOwnership.DoNotTransfer);
			loginButton.DefaultAudience = defaultAudience;
		}

		private static Delegate GetGetDefaultRequestCodeHandler()
		{
			if ((object)cb_getDefaultRequestCode == null)
			{
				cb_getDefaultRequestCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDefaultRequestCode));
			}
			return cb_getDefaultRequestCode;
		}

		private static int n_GetDefaultRequestCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultRequestCode;
		}

		private static Delegate GetGetLoggerIDHandler()
		{
			if ((object)cb_getLoggerID == null)
			{
				cb_getLoggerID = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoggerID));
			}
			return cb_getLoggerID;
		}

		private static IntPtr n_GetLoggerID(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoggerID);
		}

		private static Delegate GetGetLoginBehaviorHandler()
		{
			if ((object)cb_getLoginBehavior == null)
			{
				cb_getLoginBehavior = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoginBehavior));
			}
			return cb_getLoginBehavior;
		}

		private static IntPtr n_GetLoginBehavior(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoginBehavior);
		}

		private static Delegate GetSetLoginBehavior_Lcom_facebook_login_LoginBehavior_Handler()
		{
			if ((object)cb_setLoginBehavior_Lcom_facebook_login_LoginBehavior_ == null)
			{
				cb_setLoginBehavior_Lcom_facebook_login_LoginBehavior_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLoginBehavior_Lcom_facebook_login_LoginBehavior_));
			}
			return cb_setLoginBehavior_Lcom_facebook_login_LoginBehavior_;
		}

		private static void n_SetLoginBehavior_Lcom_facebook_login_LoginBehavior_(IntPtr jnienv, IntPtr native__this, IntPtr native_loginBehavior)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginBehavior loginBehavior = Java.Lang.Object.GetObject<LoginBehavior>(native_loginBehavior, JniHandleOwnership.DoNotTransfer);
			loginButton.LoginBehavior = loginBehavior;
		}

		private static Delegate GetGetLoginButtonContinueLabelHandler()
		{
			if ((object)cb_getLoginButtonContinueLabel == null)
			{
				cb_getLoginButtonContinueLabel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLoginButtonContinueLabel));
			}
			return cb_getLoginButtonContinueLabel;
		}

		private static int n_GetLoginButtonContinueLabel(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoginButtonContinueLabel;
		}

		private static Delegate GetGetLoginTargetAppHandler()
		{
			if ((object)cb_getLoginTargetApp == null)
			{
				cb_getLoginTargetApp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLoginTargetApp));
			}
			return cb_getLoginTargetApp;
		}

		private static IntPtr n_GetLoginTargetApp(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoginTargetApp);
		}

		private static Delegate GetSetLoginTargetApp_Lcom_facebook_login_LoginTargetApp_Handler()
		{
			if ((object)cb_setLoginTargetApp_Lcom_facebook_login_LoginTargetApp_ == null)
			{
				cb_setLoginTargetApp_Lcom_facebook_login_LoginTargetApp_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLoginTargetApp_Lcom_facebook_login_LoginTargetApp_));
			}
			return cb_setLoginTargetApp_Lcom_facebook_login_LoginTargetApp_;
		}

		private static void n_SetLoginTargetApp_Lcom_facebook_login_LoginTargetApp_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetApp)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LoginTargetApp loginTargetApp = Java.Lang.Object.GetObject<LoginTargetApp>(native_targetApp, JniHandleOwnership.DoNotTransfer);
			loginButton.LoginTargetApp = loginTargetApp;
		}

		private static Delegate GetGetMessengerPageIdHandler()
		{
			if ((object)cb_getMessengerPageId == null)
			{
				cb_getMessengerPageId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMessengerPageId));
			}
			return cb_getMessengerPageId;
		}

		private static IntPtr n_GetMessengerPageId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MessengerPageId);
		}

		private static Delegate GetSetMessengerPageId_Ljava_lang_String_Handler()
		{
			if ((object)cb_setMessengerPageId_Ljava_lang_String_ == null)
			{
				cb_setMessengerPageId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMessengerPageId_Ljava_lang_String_));
			}
			return cb_setMessengerPageId_Ljava_lang_String_;
		}

		private static void n_SetMessengerPageId_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_messengerPageId)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string messengerPageId = JNIEnv.GetString(native_messengerPageId, JniHandleOwnership.DoNotTransfer);
			loginButton.MessengerPageId = messengerPageId;
		}

		private static Delegate GetGetNewLoginClickListenerHandler()
		{
			if ((object)cb_getNewLoginClickListener == null)
			{
				cb_getNewLoginClickListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNewLoginClickListener));
			}
			return cb_getNewLoginClickListener;
		}

		private static IntPtr n_GetNewLoginClickListener(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewLoginClickListener);
		}

		private static Delegate GetGetResetMessengerStateHandler()
		{
			if ((object)cb_getResetMessengerState == null)
			{
				cb_getResetMessengerState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetResetMessengerState));
			}
			return cb_getResetMessengerState;
		}

		private static bool n_GetResetMessengerState(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetMessengerState;
		}

		private static Delegate GetSetResetMessengerState_ZHandler()
		{
			if ((object)cb_setResetMessengerState_Z == null)
			{
				cb_setResetMessengerState_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetResetMessengerState_Z));
			}
			return cb_setResetMessengerState_Z;
		}

		private static void n_SetResetMessengerState_Z(IntPtr jnienv, IntPtr native__this, bool resetMessengerState)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetMessengerState = resetMessengerState;
		}

		private static Delegate GetGetShouldSkipAccountDeduplicationHandler()
		{
			if ((object)cb_getShouldSkipAccountDeduplication == null)
			{
				cb_getShouldSkipAccountDeduplication = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetShouldSkipAccountDeduplication));
			}
			return cb_getShouldSkipAccountDeduplication;
		}

		private static bool n_GetShouldSkipAccountDeduplication(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldSkipAccountDeduplication;
		}

		private static Delegate GetGetToolTipDisplayTimeHandler()
		{
			if ((object)cb_getToolTipDisplayTime == null)
			{
				cb_getToolTipDisplayTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetToolTipDisplayTime));
			}
			return cb_getToolTipDisplayTime;
		}

		private static long n_GetToolTipDisplayTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToolTipDisplayTime;
		}

		private static Delegate GetSetToolTipDisplayTime_JHandler()
		{
			if ((object)cb_setToolTipDisplayTime_J == null)
			{
				cb_setToolTipDisplayTime_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetToolTipDisplayTime_J));
			}
			return cb_setToolTipDisplayTime_J;
		}

		private static void n_SetToolTipDisplayTime_J(IntPtr jnienv, IntPtr native__this, long displayTime)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToolTipDisplayTime = displayTime;
		}

		private static Delegate GetClearPermissionsHandler()
		{
			if ((object)cb_clearPermissions == null)
			{
				cb_clearPermissions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearPermissions));
			}
			return cb_clearPermissions;
		}

		private static void n_ClearPermissions(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearPermissions();
		}

		[Register("clearPermissions", "()V", "GetClearPermissionsHandler")]
		public unsafe virtual void ClearPermissions()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearPermissions.()V", this, null);
		}

		private static Delegate GetDismissToolTipHandler()
		{
			if ((object)cb_dismissToolTip == null)
			{
				cb_dismissToolTip = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DismissToolTip));
			}
			return cb_dismissToolTip;
		}

		private static void n_DismissToolTip(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissToolTip();
		}

		[Register("dismissToolTip", "()V", "GetDismissToolTipHandler")]
		public unsafe virtual void DismissToolTip()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("dismissToolTip.()V", this, null);
		}

		private static Delegate GetGetLoginButtonWidth_IHandler()
		{
			if ((object)cb_getLoginButtonWidth_I == null)
			{
				cb_getLoginButtonWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetLoginButtonWidth_I));
			}
			return cb_getLoginButtonWidth_I;
		}

		private static int n_GetLoginButtonWidth_I(IntPtr jnienv, IntPtr native__this, int widthMeasureSpec)
		{
			return Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLoginButtonWidth(widthMeasureSpec);
		}

		[Register("getLoginButtonWidth", "(I)I", "GetGetLoginButtonWidth_IHandler")]
		protected unsafe virtual int GetLoginButtonWidth(int widthMeasureSpec)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widthMeasureSpec);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLoginButtonWidth.(I)I", this, ptr);
		}

		private static Delegate GetGetToolTipModeHandler()
		{
			if ((object)cb_getToolTipMode == null)
			{
				cb_getToolTipMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetToolTipMode));
			}
			return cb_getToolTipMode;
		}

		private static IntPtr n_GetToolTipMode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetToolTipMode());
		}

		[Register("getToolTipMode", "()Lcom/facebook/login/widget/LoginButton$ToolTipMode;", "GetGetToolTipModeHandler")]
		public unsafe virtual ToolTipMode GetToolTipMode()
		{
			return Java.Lang.Object.GetObject<ToolTipMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getToolTipMode.()Lcom/facebook/login/widget/LoginButton$ToolTipMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetParseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_IIHandler()
		{
			if ((object)cb_parseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II == null)
			{
				cb_parseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_V(n_ParseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II));
			}
			return cb_parseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II;
		}

		private static void n_ParseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_II(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_attrs, int defStyleAttr, int defStyleRes)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			loginButton.ParseLoginButtonAttributes(context, attrs, defStyleAttr, defStyleRes);
		}

		[Register("parseLoginButtonAttributes", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "GetParseLoginButtonAttributes_Landroid_content_Context_Landroid_util_AttributeSet_IIHandler")]
		protected unsafe virtual void ParseLoginButtonAttributes(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				_members.InstanceMethods.InvokeVirtualVoidMethod("parseLoginButtonAttributes.(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			loginButton.RegisterCallback(callbackManager, callback);
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler")]
		public unsafe virtual void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetSetButtonIconHandler()
		{
			if ((object)cb_setButtonIcon == null)
			{
				cb_setButtonIcon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetButtonIcon));
			}
			return cb_setButtonIcon;
		}

		private static void n_SetButtonIcon(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonIcon();
		}

		[Register("setButtonIcon", "()V", "GetSetButtonIconHandler")]
		protected unsafe virtual void SetButtonIcon()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonIcon.()V", this, null);
		}

		private static Delegate GetSetButtonRadiusHandler()
		{
			if ((object)cb_setButtonRadius == null)
			{
				cb_setButtonRadius = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetButtonRadius));
			}
			return cb_setButtonRadius;
		}

		private static void n_SetButtonRadius(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonRadius();
		}

		[Register("setButtonRadius", "()V", "GetSetButtonRadiusHandler")]
		protected unsafe virtual void SetButtonRadius()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonRadius.()V", this, null);
		}

		private static Delegate GetSetButtonTextHandler()
		{
			if ((object)cb_setButtonText == null)
			{
				cb_setButtonText = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetButtonText));
			}
			return cb_setButtonText;
		}

		private static void n_SetButtonText(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonText();
		}

		[Register("setButtonText", "()V", "GetSetButtonTextHandler")]
		protected unsafe virtual void SetButtonText()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonText.()V", this, null);
		}

		private static Delegate GetSetButtonTransparencyHandler()
		{
			if ((object)cb_setButtonTransparency == null)
			{
				cb_setButtonTransparency = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetButtonTransparency));
			}
			return cb_setButtonTransparency;
		}

		private static void n_SetButtonTransparency(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetButtonTransparency();
		}

		[Register("setButtonTransparency", "()V", "GetSetButtonTransparencyHandler")]
		protected unsafe virtual void SetButtonTransparency()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("setButtonTransparency.()V", this, null);
		}

		private static Delegate GetSetLoginText_Ljava_lang_String_Handler()
		{
			if ((object)cb_setLoginText_Ljava_lang_String_ == null)
			{
				cb_setLoginText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLoginText_Ljava_lang_String_));
			}
			return cb_setLoginText_Ljava_lang_String_;
		}

		private static void n_SetLoginText_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_loginText)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string loginText = JNIEnv.GetString(native_loginText, JniHandleOwnership.DoNotTransfer);
			loginButton.SetLoginText(loginText);
		}

		[Register("setLoginText", "(Ljava/lang/String;)V", "GetSetLoginText_Ljava_lang_String_Handler")]
		public unsafe virtual void SetLoginText(string loginText)
		{
			IntPtr intPtr = JNIEnv.NewString(loginText);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLoginText.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetLogoutText_Ljava_lang_String_Handler()
		{
			if ((object)cb_setLogoutText_Ljava_lang_String_ == null)
			{
				cb_setLogoutText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLogoutText_Ljava_lang_String_));
			}
			return cb_setLogoutText_Ljava_lang_String_;
		}

		private static void n_SetLogoutText_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_logoutText)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string logoutText = JNIEnv.GetString(native_logoutText, JniHandleOwnership.DoNotTransfer);
			loginButton.SetLogoutText(logoutText);
		}

		[Register("setLogoutText", "(Ljava/lang/String;)V", "GetSetLogoutText_Ljava_lang_String_Handler")]
		public unsafe virtual void SetLogoutText(string logoutText)
		{
			IntPtr intPtr = JNIEnv.NewString(logoutText);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLogoutText.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetPermissions_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_setPermissions_arrayLjava_lang_String_ == null)
			{
				cb_setPermissions_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPermissions_arrayLjava_lang_String_));
			}
			return cb_setPermissions_arrayLjava_lang_String_;
		}

		private static void n_SetPermissions_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			loginButton.SetPermissions(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
		}

		[Register("setPermissions", "([Ljava/lang/String;)V", "GetSetPermissions_arrayLjava_lang_String_Handler")]
		public unsafe virtual void SetPermissions(params string[] permissions)
		{
			IntPtr intPtr = JNIEnv.NewArray(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPermissions.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (permissions != null)
				{
					JNIEnv.CopyArray(intPtr, permissions);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(permissions);
			}
		}

		private static Delegate GetSetPermissions_Ljava_util_List_Handler()
		{
			if ((object)cb_setPermissions_Ljava_util_List_ == null)
			{
				cb_setPermissions_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPermissions_Ljava_util_List_));
			}
			return cb_setPermissions_Ljava_util_List_;
		}

		private static void n_SetPermissions_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> permissions = JavaList<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			loginButton.SetPermissions(permissions);
		}

		[Register("setPermissions", "(Ljava/util/List;)V", "GetSetPermissions_Ljava_util_List_Handler")]
		public unsafe virtual void SetPermissions(IList<string> permissions)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPermissions.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete]
		private static Delegate GetSetPublishPermissions_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_setPublishPermissions_arrayLjava_lang_String_ == null)
			{
				cb_setPublishPermissions_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPublishPermissions_arrayLjava_lang_String_));
			}
			return cb_setPublishPermissions_arrayLjava_lang_String_;
		}

		[Obsolete]
		private static void n_SetPublishPermissions_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			loginButton.SetPublishPermissions(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
		}

		[Obsolete("deprecated")]
		[Register("setPublishPermissions", "([Ljava/lang/String;)V", "GetSetPublishPermissions_arrayLjava_lang_String_Handler")]
		public unsafe virtual void SetPublishPermissions(params string[] permissions)
		{
			IntPtr intPtr = JNIEnv.NewArray(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPublishPermissions.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (permissions != null)
				{
					JNIEnv.CopyArray(intPtr, permissions);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete]
		private static Delegate GetSetPublishPermissions_Ljava_util_List_Handler()
		{
			if ((object)cb_setPublishPermissions_Ljava_util_List_ == null)
			{
				cb_setPublishPermissions_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPublishPermissions_Ljava_util_List_));
			}
			return cb_setPublishPermissions_Ljava_util_List_;
		}

		[Obsolete]
		private static void n_SetPublishPermissions_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> publishPermissions = JavaList<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			loginButton.SetPublishPermissions(publishPermissions);
		}

		[Obsolete("deprecated")]
		[Register("setPublishPermissions", "(Ljava/util/List;)V", "GetSetPublishPermissions_Ljava_util_List_Handler")]
		public unsafe virtual void SetPublishPermissions(IList<string> permissions)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPublishPermissions.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete]
		private static Delegate GetSetReadPermissions_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_setReadPermissions_arrayLjava_lang_String_ == null)
			{
				cb_setReadPermissions_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReadPermissions_arrayLjava_lang_String_));
			}
			return cb_setReadPermissions_arrayLjava_lang_String_;
		}

		[Obsolete]
		private static void n_SetReadPermissions_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
			loginButton.SetReadPermissions(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_permissions);
			}
		}

		[Obsolete("deprecated")]
		[Register("setReadPermissions", "([Ljava/lang/String;)V", "GetSetReadPermissions_arrayLjava_lang_String_Handler")]
		public unsafe virtual void SetReadPermissions(params string[] permissions)
		{
			IntPtr intPtr = JNIEnv.NewArray(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReadPermissions.([Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				if (permissions != null)
				{
					JNIEnv.CopyArray(intPtr, permissions);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(permissions);
			}
		}

		[Obsolete]
		private static Delegate GetSetReadPermissions_Ljava_util_List_Handler()
		{
			if ((object)cb_setReadPermissions_Ljava_util_List_ == null)
			{
				cb_setReadPermissions_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetReadPermissions_Ljava_util_List_));
			}
			return cb_setReadPermissions_Ljava_util_List_;
		}

		[Obsolete]
		private static void n_SetReadPermissions_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_permissions)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> readPermissions = JavaList<string>.FromJniHandle(native_permissions, JniHandleOwnership.DoNotTransfer);
			loginButton.SetReadPermissions(readPermissions);
		}

		[Obsolete("deprecated")]
		[Register("setReadPermissions", "(Ljava/util/List;)V", "GetSetReadPermissions_Ljava_util_List_Handler")]
		public unsafe virtual void SetReadPermissions(IList<string> permissions)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(permissions);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setReadPermissions.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(permissions);
			}
		}

		private static Delegate GetSetToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_Handler()
		{
			if ((object)cb_setToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_ == null)
			{
				cb_setToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_));
			}
			return cb_setToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_;
		}

		private static void n_SetToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_(IntPtr jnienv, IntPtr native__this, IntPtr native_toolTipMode)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ToolTipMode toolTipMode = Java.Lang.Object.GetObject<ToolTipMode>(native_toolTipMode, JniHandleOwnership.DoNotTransfer);
			loginButton.SetToolTipMode(toolTipMode);
		}

		[Register("setToolTipMode", "(Lcom/facebook/login/widget/LoginButton$ToolTipMode;)V", "GetSetToolTipMode_Lcom_facebook_login_widget_LoginButton_ToolTipMode_Handler")]
		public unsafe virtual void SetToolTipMode(ToolTipMode toolTipMode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(toolTipMode?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setToolTipMode.(Lcom/facebook/login/widget/LoginButton$ToolTipMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(toolTipMode);
			}
		}

		private static Delegate GetSetToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_Handler()
		{
			if ((object)cb_setToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_ == null)
			{
				cb_setToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_));
			}
			return cb_setToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_;
		}

		private static void n_SetToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_(IntPtr jnienv, IntPtr native__this, IntPtr native_toolTipStyle)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ToolTipPopup.Style toolTipStyle = Java.Lang.Object.GetObject<ToolTipPopup.Style>(native_toolTipStyle, JniHandleOwnership.DoNotTransfer);
			loginButton.SetToolTipStyle(toolTipStyle);
		}

		[Register("setToolTipStyle", "(Lcom/facebook/login/widget/ToolTipPopup$Style;)V", "GetSetToolTipStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_Handler")]
		public unsafe virtual void SetToolTipStyle(ToolTipPopup.Style toolTipStyle)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(toolTipStyle?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setToolTipStyle.(Lcom/facebook/login/widget/ToolTipPopup$Style;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(toolTipStyle);
			}
		}

		private static Delegate GetUnregisterCallback_Lcom_facebook_CallbackManager_Handler()
		{
			if ((object)cb_unregisterCallback_Lcom_facebook_CallbackManager_ == null)
			{
				cb_unregisterCallback_Lcom_facebook_CallbackManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterCallback_Lcom_facebook_CallbackManager_));
			}
			return cb_unregisterCallback_Lcom_facebook_CallbackManager_;
		}

		private static void n_UnregisterCallback_Lcom_facebook_CallbackManager_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager)
		{
			LoginButton loginButton = Java.Lang.Object.GetObject<LoginButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			loginButton.UnregisterCallback(callbackManager);
		}

		[Register("unregisterCallback", "(Lcom/facebook/CallbackManager;)V", "GetUnregisterCallback_Lcom_facebook_CallbackManager_Handler")]
		public unsafe virtual void UnregisterCallback(ICallbackManager callbackManager)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterCallback.(Lcom/facebook/CallbackManager;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
			}
		}
	}
	[Register("com/facebook/login/widget/ProfilePictureView", DoNotGenerateAcw = true)]
	public class ProfilePictureView : FrameLayout
	{
		[Register("com/facebook/login/widget/ProfilePictureView$OnErrorListener", "", "Xamarin.Facebook.Login.Widget.ProfilePictureView/IOnErrorListenerInvoker")]
		public interface IOnErrorListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onError", "(Lcom/facebook/FacebookException;)V", "GetOnError_Lcom_facebook_FacebookException_Handler:Xamarin.Facebook.Login.Widget.ProfilePictureView/IOnErrorListenerInvoker, Xamarin.Facebook.Login.Android")]
			void OnError(FacebookException error);
		}

		[Register("com/facebook/login/widget/ProfilePictureView$OnErrorListener", DoNotGenerateAcw = true)]
		internal class IOnErrorListenerInvoker : Java.Lang.Object, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/ProfilePictureView$OnErrorListener", typeof(IOnErrorListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onError_Lcom_facebook_FacebookException_;

			private IntPtr id_onError_Lcom_facebook_FacebookException_;

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

			public static IOnErrorListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnErrorListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.login.widget.ProfilePictureView.OnErrorListener'.");
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

			public IOnErrorListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
			{
				if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
				{
					cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
				}
				return cb_onError_Lcom_facebook_FacebookException_;
			}

			private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
			{
				IOnErrorListener onErrorListener = Java.Lang.Object.GetObject<IOnErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FacebookException error = Java.Lang.Object.GetObject<FacebookException>(native_error, JniHandleOwnership.DoNotTransfer);
				onErrorListener.OnError(error);
			}

			public unsafe void OnError(FacebookException error)
			{
				if (id_onError_Lcom_facebook_FacebookException_ == IntPtr.Zero)
				{
					id_onError_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Lcom/facebook/FacebookException;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(error?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onError_Lcom_facebook_FacebookException_, ptr);
			}
		}

		public class ErrorEventArgs : EventArgs
		{
			private FacebookException error;

			public FacebookException Error => error;

			public ErrorEventArgs(FacebookException error)
			{
				this.error = error;
			}
		}

		[Register("mono/com/facebook/login/widget/ProfilePictureView_OnErrorListenerImplementor")]
		internal sealed class IOnErrorListenerImplementor : Java.Lang.Object, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<ErrorEventArgs> Handler;

			public IOnErrorListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/login/widget/ProfilePictureView_OnErrorListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnError(FacebookException error)
			{
				Handler?.Invoke(sender, new ErrorEventArgs(error));
			}

			internal static bool __IsEmpty(IOnErrorListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("CUSTOM")]
		public const int Custom = -1;

		[Register("LARGE")]
		public const int Large = -4;

		[Register("NORMAL")]
		public const int Normal = -3;

		[Register("SMALL")]
		public const int Small = -2;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/ProfilePictureView", typeof(ProfilePictureView));

		private WeakReference weak_implementor___SetOnErrorListener;

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

		public unsafe bool Cropped
		{
			[Register("isCropped", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isCropped.()Z", this, null);
			}
			[Register("setCropped", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCropped.(Z)V", this, ptr);
			}
		}

		public unsafe IOnErrorListener OnErrorListener
		{
			[Register("getOnErrorListener", "()Lcom/facebook/login/widget/ProfilePictureView$OnErrorListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IOnErrorListener>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOnErrorListener.()Lcom/facebook/login/widget/ProfilePictureView$OnErrorListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setOnErrorListener", "(Lcom/facebook/login/widget/ProfilePictureView$OnErrorListener;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnErrorListener.(Lcom/facebook/login/widget/ProfilePictureView$OnErrorListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe int PresetSize
		{
			[Register("getPresetSize", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getPresetSize.()I", this, null);
			}
			[Register("setPresetSize", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPresetSize.(I)V", this, ptr);
			}
		}

		public unsafe string ProfileId
		{
			[Register("getProfileId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getProfileId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setProfileId", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeNonvirtualVoidMethod("setProfileId.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe bool ShouldUpdateOnProfileChange
		{
			[Register("getShouldUpdateOnProfileChange", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getShouldUpdateOnProfileChange.()Z", this, null);
			}
			[Register("setShouldUpdateOnProfileChange", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setShouldUpdateOnProfileChange.(Z)V", this, ptr);
			}
		}

		public event EventHandler<ErrorEventArgs> Error
		{
			add
			{
				EventHelper.AddEventHandler(ref weak_implementor___SetOnErrorListener, __CreateIOnErrorListenerImplementor, delegate(IOnErrorListener __v)
				{
					OnErrorListener = __v;
				}, delegate(IOnErrorListenerImplementor __h)
				{
					__h.Handler = (EventHandler<ErrorEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnErrorListener, IOnErrorListenerImplementor>(ref weak_implementor___SetOnErrorListener, IOnErrorListenerImplementor.__IsEmpty, delegate
				{
					OnErrorListener = null;
				}, delegate(IOnErrorListenerImplementor __h)
				{
					__h.Handler = (EventHandler<ErrorEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected ProfilePictureView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ProfilePictureView(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe ProfilePictureView(Context context, IAttributeSet attrs)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe ProfilePictureView(Context context, IAttributeSet attrs, int defStyle)
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
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register("setDefaultProfilePicture", "(Landroid/graphics/Bitmap;)V", "")]
		public unsafe void SetDefaultProfilePicture(Bitmap inputBitmap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(inputBitmap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setDefaultProfilePicture.(Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(inputBitmap);
			}
		}

		private IOnErrorListenerImplementor __CreateIOnErrorListenerImplementor()
		{
			return new IOnErrorListenerImplementor(this);
		}
	}
	[Register("com/facebook/login/widget/ToolTipPopup", DoNotGenerateAcw = true)]
	public class ToolTipPopup : Java.Lang.Object
	{
		[Register("com/facebook/login/widget/ToolTipPopup$Style", DoNotGenerateAcw = true)]
		public sealed class Style : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/ToolTipPopup$Style", typeof(Style));

			[Register("BLACK")]
			public static Style Black => Java.Lang.Object.GetObject<Style>(_members.StaticFields.GetObjectValue("BLACK.Lcom/facebook/login/widget/ToolTipPopup$Style;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("BLUE")]
			public static Style Blue => Java.Lang.Object.GetObject<Style>(_members.StaticFields.GetObjectValue("BLUE.Lcom/facebook/login/widget/ToolTipPopup$Style;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Style(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/login/widget/ToolTipPopup$Style;", "")]
			public unsafe static Style ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Style>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/login/widget/ToolTipPopup$Style;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/facebook/login/widget/ToolTipPopup$Style;", "")]
			public unsafe static Style[] Values()
			{
				return (Style[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/login/widget/ToolTipPopup$Style;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Style));
			}
		}

		[Register("DEFAULT_POPUP_DISPLAY_TIME")]
		public const long DefaultPopupDisplayTime = 6000L;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/login/widget/ToolTipPopup", typeof(ToolTipPopup));

		private static Delegate cb_dismiss;

		private static Delegate cb_setNuxDisplayTime_J;

		private static Delegate cb_setStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_;

		private static Delegate cb_show;

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

		protected ToolTipPopup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/view/View;)V", "")]
		public unsafe ToolTipPopup(string text, View anchor)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetDismissHandler()
		{
			if ((object)cb_dismiss == null)
			{
				cb_dismiss = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Dismiss));
			}
			return cb_dismiss;
		}

		private static void n_Dismiss(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ToolTipPopup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
		}

		[Register("dismiss", "()V", "GetDismissHandler")]
		public unsafe virtual void Dismiss()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
		}

		private static Delegate GetSetNuxDisplayTime_JHandler()
		{
			if ((object)cb_setNuxDisplayTime_J == null)
			{
				cb_setNuxDisplayTime_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_SetNuxDisplayTime_J));
			}
			return cb_setNuxDisplayTime_J;
		}

		private static void n_SetNuxDisplayTime_J(IntPtr jnienv, IntPtr native__this, long displayTime)
		{
			Java.Lang.Object.GetObject<ToolTipPopup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNuxDisplayTime(displayTime);
		}

		[Register("setNuxDisplayTime", "(J)V", "GetSetNuxDisplayTime_JHandler")]
		public unsafe virtual void SetNuxDisplayTime(long displayTime)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(displayTime);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setNuxDisplayTime.(J)V", this, ptr);
		}

		private static Delegate GetSetStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_Handler()
		{
			if ((object)cb_setStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_ == null)
			{
				cb_setStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_));
			}
			return cb_setStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_;
		}

		private static void n_SetStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_(IntPtr jnienv, IntPtr native__this, IntPtr native_mStyle)
		{
			ToolTipPopup toolTipPopup = Java.Lang.Object.GetObject<ToolTipPopup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Style style = Java.Lang.Object.GetObject<Style>(native_mStyle, JniHandleOwnership.DoNotTransfer);
			toolTipPopup.SetStyle(style);
		}

		[Register("setStyle", "(Lcom/facebook/login/widget/ToolTipPopup$Style;)V", "GetSetStyle_Lcom_facebook_login_widget_ToolTipPopup_Style_Handler")]
		public unsafe virtual void SetStyle(Style mStyle)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mStyle?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStyle.(Lcom/facebook/login/widget/ToolTipPopup$Style;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mStyle);
			}
		}

		private static Delegate GetShowHandler()
		{
			if ((object)cb_show == null)
			{
				cb_show = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Show));
			}
			return cb_show;
		}

		private static void n_Show(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ToolTipPopup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
		}

		[Register("show", "()V", "GetShowHandler")]
		public unsafe virtual void Show()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
		}
	}
}
