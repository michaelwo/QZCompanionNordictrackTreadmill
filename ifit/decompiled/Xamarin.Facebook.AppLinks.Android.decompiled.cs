using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Org.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook.applinks", Managed = "Xamarin.Facebook.AppLinks")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - App Links")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.AppLinks.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.AppLinks.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
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
namespace Xamarin.Facebook.AppLinks
{
	[Register("com/facebook/applinks/AppLinkData", DoNotGenerateAcw = true)]
	public class AppLinkData : Java.Lang.Object
	{
		[Register("com/facebook/applinks/AppLinkData$CompletionHandler", "", "Xamarin.Facebook.AppLinks.AppLinkData/ICompletionHandlerInvoker")]
		public interface ICompletionHandler : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onDeferredAppLinkDataFetched", "(Lcom/facebook/applinks/AppLinkData;)V", "GetOnDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_Handler:Xamarin.Facebook.AppLinks.AppLinkData/ICompletionHandlerInvoker, Xamarin.Facebook.AppLinks.Android")]
			void OnDeferredAppLinkDataFetched(AppLinkData appLinkData);
		}

		[Register("com/facebook/applinks/AppLinkData$CompletionHandler", DoNotGenerateAcw = true)]
		internal class ICompletionHandlerInvoker : Java.Lang.Object, ICompletionHandler, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/applinks/AppLinkData$CompletionHandler", typeof(ICompletionHandlerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_;

			private IntPtr id_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_;

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

			public static ICompletionHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICompletionHandler>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.applinks.AppLinkData.CompletionHandler'.");
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

			public ICompletionHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_Handler()
			{
				if ((object)cb_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_ == null)
				{
					cb_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_));
				}
				return cb_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_;
			}

			private static void n_OnDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_(IntPtr jnienv, IntPtr native__this, IntPtr native_appLinkData)
			{
				ICompletionHandler completionHandler = Java.Lang.Object.GetObject<ICompletionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AppLinkData appLinkData = Java.Lang.Object.GetObject<AppLinkData>(native_appLinkData, JniHandleOwnership.DoNotTransfer);
				completionHandler.OnDeferredAppLinkDataFetched(appLinkData);
			}

			public unsafe void OnDeferredAppLinkDataFetched(AppLinkData appLinkData)
			{
				if (id_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_ == IntPtr.Zero)
				{
					id_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_ = JNIEnv.GetMethodID(class_ref, "onDeferredAppLinkDataFetched", "(Lcom/facebook/applinks/AppLinkData;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(appLinkData?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onDeferredAppLinkDataFetched_Lcom_facebook_applinks_AppLinkData_, ptr);
			}
		}

		[Register("ARGUMENTS_EXTRAS_KEY")]
		public const string ArgumentsExtrasKey = "extras";

		[Register("ARGUMENTS_NATIVE_CLASS_KEY")]
		public const string ArgumentsNativeClassKey = "com.facebook.platform.APPLINK_NATIVE_CLASS";

		[Register("ARGUMENTS_NATIVE_URL")]
		public const string ArgumentsNativeUrl = "com.facebook.platform.APPLINK_NATIVE_URL";

		[Register("ARGUMENTS_REFERER_DATA_KEY")]
		public const string ArgumentsRefererDataKey = "referer_data";

		[Register("ARGUMENTS_TAPTIME_KEY")]
		public const string ArgumentsTaptimeKey = "com.facebook.platform.APPLINK_TAP_TIME_UTC";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/applinks/AppLinkData", typeof(AppLinkData));

		private static Delegate cb_getArgumentBundle;

		private static Delegate cb_isAutoAppLink;

		private static Delegate cb_getPromotionCode;

		private static Delegate cb_getRef;

		private static Delegate cb_getRefererData;

		private static Delegate cb_getTargetUri;

		private static Delegate cb_getAppLinkData;

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

		public unsafe virtual Bundle ArgumentBundle
		{
			[Register("getArgumentBundle", "()Landroid/os/Bundle;", "GetGetArgumentBundleHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArgumentBundle.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsAutoAppLink
		{
			[Register("isAutoAppLink", "()Z", "GetIsAutoAppLinkHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAutoAppLink.()Z", this, null);
			}
		}

		public unsafe virtual string PromotionCode
		{
			[Register("getPromotionCode", "()Ljava/lang/String;", "GetGetPromotionCodeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPromotionCode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string Ref
		{
			[Register("getRef", "()Ljava/lang/String;", "GetGetRefHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getRef.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Bundle RefererData
		{
			[Register("getRefererData", "()Landroid/os/Bundle;", "GetGetRefererDataHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRefererData.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Android.Net.Uri TargetUri
		{
			[Register("getTargetUri", "()Landroid/net/Uri;", "GetGetTargetUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTargetUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected AppLinkData(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetArgumentBundleHandler()
		{
			if ((object)cb_getArgumentBundle == null)
			{
				cb_getArgumentBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetArgumentBundle));
			}
			return cb_getArgumentBundle;
		}

		private static IntPtr n_GetArgumentBundle(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArgumentBundle);
		}

		private static Delegate GetIsAutoAppLinkHandler()
		{
			if ((object)cb_isAutoAppLink == null)
			{
				cb_isAutoAppLink = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAutoAppLink));
			}
			return cb_isAutoAppLink;
		}

		private static bool n_IsAutoAppLink(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAutoAppLink;
		}

		private static Delegate GetGetPromotionCodeHandler()
		{
			if ((object)cb_getPromotionCode == null)
			{
				cb_getPromotionCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPromotionCode));
			}
			return cb_getPromotionCode;
		}

		private static IntPtr n_GetPromotionCode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PromotionCode);
		}

		private static Delegate GetGetRefHandler()
		{
			if ((object)cb_getRef == null)
			{
				cb_getRef = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRef));
			}
			return cb_getRef;
		}

		private static IntPtr n_GetRef(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Ref);
		}

		private static Delegate GetGetRefererDataHandler()
		{
			if ((object)cb_getRefererData == null)
			{
				cb_getRefererData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRefererData));
			}
			return cb_getRefererData;
		}

		private static IntPtr n_GetRefererData(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefererData);
		}

		private static Delegate GetGetTargetUriHandler()
		{
			if ((object)cb_getTargetUri == null)
			{
				cb_getTargetUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTargetUri));
			}
			return cb_getTargetUri;
		}

		private static IntPtr n_GetTargetUri(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetUri);
		}

		[Register("createFromActivity", "(Landroid/app/Activity;)Lcom/facebook/applinks/AppLinkData;", "")]
		public unsafe static AppLinkData CreateFromActivity(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AppLinkData>(_members.StaticMethods.InvokeObjectMethod("createFromActivity.(Landroid/app/Activity;)Lcom/facebook/applinks/AppLinkData;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register("createFromAlApplinkData", "(Landroid/content/Intent;)Lcom/facebook/applinks/AppLinkData;", "")]
		public unsafe static AppLinkData CreateFromAlApplinkData(Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AppLinkData>(_members.StaticMethods.InvokeObjectMethod("createFromAlApplinkData.(Landroid/content/Intent;)Lcom/facebook/applinks/AppLinkData;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}

		[Register("fetchDeferredAppLinkData", "(Landroid/content/Context;Lcom/facebook/applinks/AppLinkData$CompletionHandler;)V", "")]
		public unsafe static void FetchDeferredAppLinkData(Context context, ICompletionHandler completionHandler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((completionHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)completionHandler).Handle);
				_members.StaticMethods.InvokeVoidMethod("fetchDeferredAppLinkData.(Landroid/content/Context;Lcom/facebook/applinks/AppLinkData$CompletionHandler;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(completionHandler);
			}
		}

		[Register("fetchDeferredAppLinkData", "(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/applinks/AppLinkData$CompletionHandler;)V", "")]
		public unsafe static void FetchDeferredAppLinkData(Context context, string applicationId, ICompletionHandler completionHandler)
		{
			IntPtr intPtr = JNIEnv.NewString(applicationId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((completionHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)completionHandler).Handle);
				_members.StaticMethods.InvokeVoidMethod("fetchDeferredAppLinkData.(Landroid/content/Context;Ljava/lang/String;Lcom/facebook/applinks/AppLinkData$CompletionHandler;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(completionHandler);
			}
		}

		private static Delegate GetGetAppLinkDataHandler()
		{
			if ((object)cb_getAppLinkData == null)
			{
				cb_getAppLinkData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAppLinkData));
			}
			return cb_getAppLinkData;
		}

		private static IntPtr n_GetAppLinkData(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppLinkData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAppLinkData());
		}

		[Register("getAppLinkData", "()Lorg/json/JSONObject;", "GetGetAppLinkDataHandler")]
		public unsafe virtual JSONObject GetAppLinkData()
		{
			return Java.Lang.Object.GetObject<JSONObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAppLinkData.()Lorg/json/JSONObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/facebook/applinks/AppLinks", DoNotGenerateAcw = true)]
	public sealed class AppLinks : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/applinks/AppLinks", typeof(AppLinks));

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

		internal AppLinks(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/facebook/applinks/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.applinks";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/applinks/BuildConfig", typeof(BuildConfig));

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
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_facebook_applinks_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/facebook/applinks" }, new Converter<string, Type>[1] { lookup_com_facebook_applinks_package });
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

		private static Type lookup_com_facebook_applinks_package(string klass)
		{
			if (package_com_facebook_applinks_mappings == null)
			{
				package_com_facebook_applinks_mappings = new string[3] { "com/facebook/applinks/AppLinkData:Xamarin.Facebook.AppLinks.AppLinkData", "com/facebook/applinks/AppLinks:Xamarin.Facebook.AppLinks.AppLinks", "com/facebook/applinks/BuildConfig:Xamarin.Facebook.AppLinks.BuildConfig" };
			}
			return Lookup(package_com_facebook_applinks_mappings, klass);
		}
	}
}
