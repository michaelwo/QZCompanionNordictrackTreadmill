using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Common.Api.Internal;
using Android.Gms.Common.Apis;
using Android.Gms.Common.Apis.Internal;
using Android.Gms.Common.Internal;
using Android.Gms.Common.Util;
using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Fragment.App;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Ref;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "fb4985bc40adce1eed066f366d7905c21957aac8")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220414.6")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "4/14/2022 7:04:25 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common", Managed = "Android.Gms.Common")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.dynamic", Managed = "Android.Gms.Dynamic")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.api.internal", Managed = "Android.Gms.Common.Api.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.api", Managed = "Android.Gms.Common.Apis")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.auth.api.signin", Managed = "Android.Gms.Auth.Api.SignIn")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.auth.api.signin.internal", Managed = "Android.Gms.Auth.Api.SignIn.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.data", Managed = "Android.Gms.Common.Data")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.images", Managed = "Android.Gms.Common.Images")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.server", Managed = "Android.Gms.Common.Server")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.server.converter", Managed = "Android.Gms.Common.Server.Converter")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.server.response", Managed = "Android.Gms.Common.Server.Response")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.signin", Managed = "Android.Gms.SignIn")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Base 117.6.0.5 artifact=com.google.android.gms:play-services-base artifact_versioned=com.google.android.gms:play-services-base:17.6.0\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Base")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Base")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPJL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate bool _JniMarshal_PPLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLIIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate bool _JniMarshal_PPLIIL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPLJL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
namespace Android.Gms.Common
{
	[Register("com/google/android/gms/common/GoogleApiAvailability", DoNotGenerateAcw = true)]
	public class GoogleApiAvailability : GoogleApiAvailabilityLight
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/GoogleApiAvailability", typeof(GoogleApiAvailability));

		private static Delegate cb_checkApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_;

		private static Delegate cb_checkApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_;

		private static Delegate cb_getErrorDialog_Landroid_app_Activity_II;

		private static Delegate cb_getErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_;

		private static Delegate cb_getErrorDialog_Landroidx_fragment_app_Fragment_II;

		private static Delegate cb_getErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_;

		private static Delegate cb_getErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_;

		private static Delegate cb_makeGooglePlayServicesAvailable_Landroid_app_Activity_;

		private static Delegate cb_setDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_;

		private static Delegate cb_showErrorDialogFragment_Landroid_app_Activity_II;

		private static Delegate cb_showErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_;

		private static Delegate cb_showErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_;

		private static Delegate cb_showErrorNotification_Landroid_content_Context_I;

		[Register("GOOGLE_PLAY_SERVICES_VERSION_CODE")]
		public new static int GooglePlayServicesVersionCode => _members.StaticFields.GetInt32Value("GOOGLE_PLAY_SERVICES_VERSION_CODE.I");

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

		public new unsafe static GoogleApiAvailability Instance
		{
			[Register("getInstance", "()Lcom/google/android/gms/common/GoogleApiAvailability;", "")]
			get
			{
				return Java.Lang.Object.GetObject<GoogleApiAvailability>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/android/gms/common/GoogleApiAvailability;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public override int IsGooglePlayServicesAvailable(Context context)
		{
			return base.IsGooglePlayServicesAvailable(context);
		}

		public override PendingIntent GetErrorResolutionPendingIntent(Context context, int errorCode, int requestCode)
		{
			return base.GetErrorResolutionPendingIntent(context, errorCode, requestCode);
		}

		public System.Threading.Tasks.Task MakeGooglePlayServicesAvailableAsync(Activity activity)
		{
			return MakeGooglePlayServicesAvailable(activity).AsAsync();
		}

		public System.Threading.Tasks.Task CheckApiAvailabilityAsync(GoogleApi apiClient, GoogleApi[] apis)
		{
			return CheckApiAvailability(apiClient, apis).AsAsync();
		}

		protected GoogleApiAvailability(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GoogleApiAvailability()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCheckApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_Handler()
		{
			if ((object)cb_checkApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_ == null)
			{
				cb_checkApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_CheckApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_));
			}
			return cb_checkApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_;
		}

		private static IntPtr n_CheckApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_(IntPtr jnienv, IntPtr native__this, IntPtr native_api, IntPtr native_apis)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			GoogleApi api = Java.Lang.Object.GetObject<GoogleApi>(native_api, JniHandleOwnership.DoNotTransfer);
			GoogleApi[] array = (GoogleApi[])JNIEnv.GetArray(native_apis, JniHandleOwnership.DoNotTransfer, typeof(GoogleApi));
			IntPtr result = JNIEnv.ToLocalJniHandle(googleApiAvailability.CheckApiAvailability(api, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_apis);
			}
			return result;
		}

		[Register("checkApiAvailability", "(Lcom/google/android/gms/common/api/GoogleApi;[Lcom/google/android/gms/common/api/GoogleApi;)Lcom/google/android/gms/tasks/Task;", "GetCheckApiAvailability_Lcom_google_android_gms_common_api_GoogleApi_arrayLcom_google_android_gms_common_api_GoogleApi_Handler")]
		public unsafe virtual Android.Gms.Tasks.Task CheckApiAvailability(GoogleApi api, params GoogleApi[] apis)
		{
			IntPtr intPtr = JNIEnv.NewArray(apis);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(api?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("checkApiAvailability.(Lcom/google/android/gms/common/api/GoogleApi;[Lcom/google/android/gms/common/api/GoogleApi;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (apis != null)
				{
					JNIEnv.CopyArray(intPtr, apis);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(api);
				GC.KeepAlive(apis);
			}
		}

		private static Delegate GetCheckApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_Handler()
		{
			if ((object)cb_checkApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_ == null)
			{
				cb_checkApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_CheckApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_));
			}
			return cb_checkApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_;
		}

		private static IntPtr n_CheckApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IHasApiKey p = Java.Lang.Object.GetObject<IHasApiKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			IHasApiKey[] array = (IHasApiKey[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(IHasApiKey));
			IntPtr result = JNIEnv.ToLocalJniHandle(googleApiAvailability.CheckApiAvailability(p, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			return result;
		}

		[Register("checkApiAvailability", "(Lcom/google/android/gms/common/api/HasApiKey;[Lcom/google/android/gms/common/api/HasApiKey;)Lcom/google/android/gms/tasks/Task;", "GetCheckApiAvailability_Lcom_google_android_gms_common_api_HasApiKey_arrayLcom_google_android_gms_common_api_HasApiKey_Handler")]
		public unsafe virtual Android.Gms.Tasks.Task CheckApiAvailability(IHasApiKey p0, params IHasApiKey[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("checkApiAvailability.(Lcom/google/android/gms/common/api/HasApiKey;[Lcom/google/android/gms/common/api/HasApiKey;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetGetErrorDialog_Landroid_app_Activity_IIHandler()
		{
			if ((object)cb_getErrorDialog_Landroid_app_Activity_II == null)
			{
				cb_getErrorDialog_Landroid_app_Activity_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_GetErrorDialog_Landroid_app_Activity_II));
			}
			return cb_getErrorDialog_Landroid_app_Activity_II;
		}

		private static IntPtr n_GetErrorDialog_Landroid_app_Activity_II(IntPtr jnienv, IntPtr native__this, IntPtr native_activity, int errorCode, int requestCode)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.GetErrorDialog(activity, errorCode, requestCode));
		}

		[Register("getErrorDialog", "(Landroid/app/Activity;II)Landroid/app/Dialog;", "GetGetErrorDialog_Landroid_app_Activity_IIHandler")]
		public unsafe virtual Dialog GetErrorDialog(Activity activity, int errorCode, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorDialog.(Landroid/app/Activity;II)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		private static Delegate GetGetErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_Handler()
		{
			if ((object)cb_getErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_ == null)
			{
				cb_getErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_L(n_GetErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_));
			}
			return cb_getErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_;
		}

		private static IntPtr n_GetErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_activity, int errorCode, int requestCode, IntPtr native_cancelListener)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnCancelListener cancelListener = Java.Lang.Object.GetObject<IDialogInterfaceOnCancelListener>(native_cancelListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.GetErrorDialog(activity, errorCode, requestCode, cancelListener));
		}

		[Register("getErrorDialog", "(Landroid/app/Activity;IILandroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", "GetGetErrorDialog_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_Handler")]
		public unsafe virtual Dialog GetErrorDialog(Activity activity, int errorCode, int requestCode, IDialogInterfaceOnCancelListener cancelListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				ptr[3] = new JniArgumentValue((cancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)cancelListener).Handle);
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorDialog.(Landroid/app/Activity;IILandroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(cancelListener);
			}
		}

		private static Delegate GetGetErrorDialog_Landroidx_fragment_app_Fragment_IIHandler()
		{
			if ((object)cb_getErrorDialog_Landroidx_fragment_app_Fragment_II == null)
			{
				cb_getErrorDialog_Landroidx_fragment_app_Fragment_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_GetErrorDialog_Landroidx_fragment_app_Fragment_II));
			}
			return cb_getErrorDialog_Landroidx_fragment_app_Fragment_II;
		}

		private static IntPtr n_GetErrorDialog_Landroidx_fragment_app_Fragment_II(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.Fragment.App.Fragment p3 = Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.GetErrorDialog(p3, p1, p2));
		}

		[Register("getErrorDialog", "(Landroidx/fragment/app/Fragment;II)Landroid/app/Dialog;", "GetGetErrorDialog_Landroidx_fragment_app_Fragment_IIHandler")]
		public unsafe virtual Dialog GetErrorDialog(AndroidX.Fragment.App.Fragment p0, int p1, int p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorDialog.(Landroidx/fragment/app/Fragment;II)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_Handler()
		{
			if ((object)cb_getErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_ == null)
			{
				cb_getErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_L(n_GetErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_));
			}
			return cb_getErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_;
		}

		private static IntPtr n_GetErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.Fragment.App.Fragment p3 = Java.Lang.Object.GetObject<AndroidX.Fragment.App.Fragment>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnCancelListener p4 = Java.Lang.Object.GetObject<IDialogInterfaceOnCancelListener>(native_p3, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.GetErrorDialog(p3, p1, p2, p4));
		}

		[Register("getErrorDialog", "(Landroidx/fragment/app/Fragment;IILandroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", "GetGetErrorDialog_Landroidx_fragment_app_Fragment_IILandroid_content_DialogInterface_OnCancelListener_Handler")]
		public unsafe virtual Dialog GetErrorDialog(AndroidX.Fragment.App.Fragment p0, int p1, int p2, IDialogInterfaceOnCancelListener p3)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorDialog.(Landroidx/fragment/app/Fragment;IILandroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetGetErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_Handler()
		{
			if ((object)cb_getErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_ == null)
			{
				cb_getErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_));
			}
			return cb_getErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_;
		}

		private static IntPtr n_GetErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_result)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ConnectionResult result = Java.Lang.Object.GetObject<ConnectionResult>(native_result, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.GetErrorResolutionPendingIntent(context, result));
		}

		[Register("getErrorResolutionPendingIntent", "(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;)Landroid/app/PendingIntent;", "GetGetErrorResolutionPendingIntent_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_Handler")]
		public unsafe virtual PendingIntent GetErrorResolutionPendingIntent(Context context, ConnectionResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorResolutionPendingIntent.(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(result);
			}
		}

		[Register("getErrorString", "(I)Ljava/lang/String;", "")]
		public unsafe sealed override string GetErrorString(int errorCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorCode);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getErrorString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("isUserResolvableError", "(I)Z", "")]
		public unsafe sealed override bool IsUserResolvableError(int errorCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorCode);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isUserResolvableError.(I)Z", this, ptr);
		}

		private static Delegate GetMakeGooglePlayServicesAvailable_Landroid_app_Activity_Handler()
		{
			if ((object)cb_makeGooglePlayServicesAvailable_Landroid_app_Activity_ == null)
			{
				cb_makeGooglePlayServicesAvailable_Landroid_app_Activity_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MakeGooglePlayServicesAvailable_Landroid_app_Activity_));
			}
			return cb_makeGooglePlayServicesAvailable_Landroid_app_Activity_;
		}

		private static IntPtr n_MakeGooglePlayServicesAvailable_Landroid_app_Activity_(IntPtr jnienv, IntPtr native__this, IntPtr native_activity)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailability.MakeGooglePlayServicesAvailable(activity));
		}

		[Register("makeGooglePlayServicesAvailable", "(Landroid/app/Activity;)Lcom/google/android/gms/tasks/Task;", "GetMakeGooglePlayServicesAvailable_Landroid_app_Activity_Handler")]
		public unsafe virtual Android.Gms.Tasks.Task MakeGooglePlayServicesAvailable(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("makeGooglePlayServicesAvailable.(Landroid/app/Activity;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		private static Delegate GetSetDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_ == null)
			{
				cb_setDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_));
			}
			return cb_setDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_;
		}

		private static void n_SetDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_notificationChannelId)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string notificationChannelId = JNIEnv.GetString(native_notificationChannelId, JniHandleOwnership.DoNotTransfer);
			googleApiAvailability.SetDefaultNotificationChannelId(context, notificationChannelId);
		}

		[Register("setDefaultNotificationChannelId", "(Landroid/content/Context;Ljava/lang/String;)V", "GetSetDefaultNotificationChannelId_Landroid_content_Context_Ljava_lang_String_Handler")]
		public unsafe virtual void SetDefaultNotificationChannelId(Context context, string notificationChannelId)
		{
			IntPtr intPtr = JNIEnv.NewString(notificationChannelId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDefaultNotificationChannelId.(Landroid/content/Context;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetShowErrorDialogFragment_Landroid_app_Activity_IIHandler()
		{
			if ((object)cb_showErrorDialogFragment_Landroid_app_Activity_II == null)
			{
				cb_showErrorDialogFragment_Landroid_app_Activity_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_Z(n_ShowErrorDialogFragment_Landroid_app_Activity_II));
			}
			return cb_showErrorDialogFragment_Landroid_app_Activity_II;
		}

		private static bool n_ShowErrorDialogFragment_Landroid_app_Activity_II(IntPtr jnienv, IntPtr native__this, IntPtr native_activity, int errorCode, int requestCode)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailability.ShowErrorDialogFragment(activity, errorCode, requestCode);
		}

		[Register("showErrorDialogFragment", "(Landroid/app/Activity;II)Z", "GetShowErrorDialogFragment_Landroid_app_Activity_IIHandler")]
		public unsafe virtual bool ShowErrorDialogFragment(Activity activity, int errorCode, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("showErrorDialogFragment.(Landroid/app/Activity;II)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		private static Delegate GetShowErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_Handler()
		{
			if ((object)cb_showErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_ == null)
			{
				cb_showErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIL_Z(n_ShowErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_));
			}
			return cb_showErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_;
		}

		private static bool n_ShowErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_activity, int errorCode, int requestCode, IntPtr native_cancelListener)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
			IDialogInterfaceOnCancelListener cancelListener = Java.Lang.Object.GetObject<IDialogInterfaceOnCancelListener>(native_cancelListener, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailability.ShowErrorDialogFragment(activity, errorCode, requestCode, cancelListener);
		}

		[Register("showErrorDialogFragment", "(Landroid/app/Activity;IILandroid/content/DialogInterface$OnCancelListener;)Z", "GetShowErrorDialogFragment_Landroid_app_Activity_IILandroid_content_DialogInterface_OnCancelListener_Handler")]
		public unsafe virtual bool ShowErrorDialogFragment(Activity activity, int errorCode, int requestCode, IDialogInterfaceOnCancelListener cancelListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				ptr[3] = new JniArgumentValue((cancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)cancelListener).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("showErrorDialogFragment.(Landroid/app/Activity;IILandroid/content/DialogInterface$OnCancelListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(cancelListener);
			}
		}

		private static Delegate GetShowErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_Handler()
		{
			if ((object)cb_showErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_ == null)
			{
				cb_showErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ShowErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_));
			}
			return cb_showErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_;
		}

		private static void n_ShowErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_result)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ConnectionResult result = Java.Lang.Object.GetObject<ConnectionResult>(native_result, JniHandleOwnership.DoNotTransfer);
			googleApiAvailability.ShowErrorNotification(context, result);
		}

		[Register("showErrorNotification", "(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;)V", "GetShowErrorNotification_Landroid_content_Context_Lcom_google_android_gms_common_ConnectionResult_Handler")]
		public unsafe virtual void ShowErrorNotification(Context context, ConnectionResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showErrorNotification.(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetShowErrorNotification_Landroid_content_Context_IHandler()
		{
			if ((object)cb_showErrorNotification_Landroid_content_Context_I == null)
			{
				cb_showErrorNotification_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_ShowErrorNotification_Landroid_content_Context_I));
			}
			return cb_showErrorNotification_Landroid_content_Context_I;
		}

		private static void n_ShowErrorNotification_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode)
		{
			GoogleApiAvailability googleApiAvailability = Java.Lang.Object.GetObject<GoogleApiAvailability>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			googleApiAvailability.ShowErrorNotification(context, errorCode);
		}

		[Register("showErrorNotification", "(Landroid/content/Context;I)V", "GetShowErrorNotification_Landroid_content_Context_IHandler")]
		public unsafe virtual void ShowErrorNotification(Context context, int errorCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				_members.InstanceMethods.InvokeVirtualVoidMethod("showErrorNotification.(Landroid/content/Context;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("zaa", "(Landroid/app/Activity;Lcom/google/android/gms/common/api/internal/LifecycleFragment;IILandroid/content/DialogInterface$OnCancelListener;)Z", "")]
		public unsafe bool Zaa(Activity p0, ILifecycleFragment p1, int p2, int p3, IDialogInterfaceOnCancelListener p4)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue((p4 == null) ? IntPtr.Zero : ((Java.Lang.Object)p4).Handle);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("zaa.(Landroid/app/Activity;Lcom/google/android/gms/common/api/internal/LifecycleFragment;IILandroid/content/DialogInterface$OnCancelListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p4);
			}
		}

		[Register("zac", "(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;I)Z", "")]
		public unsafe bool Zac(Context p0, ConnectionResult p1, int p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("zac.(Landroid/content/Context;Lcom/google/android/gms/common/ConnectionResult;I)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zad", "(Landroid/app/Activity;Landroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", "")]
		public unsafe Dialog Zad(Activity p0, IDialogInterfaceOnCancelListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Dialog>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zad.(Landroid/app/Activity;Landroid/content/DialogInterface$OnCancelListener;)Landroid/app/Dialog;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zae", "(Landroid/content/Context;Lcom/google/android/gms/common/api/internal/zabq;)Lcom/google/android/gms/common/api/internal/zabr;", "")]
		public unsafe Zabr Zae(Context p0, Zabq p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Zabr>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zae.(Landroid/content/Context;Lcom/google/android/gms/common/api/internal/zabq;)Lcom/google/android/gms/common/api/internal/zabr;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zai", "(Lcom/google/android/gms/common/api/HasApiKey;[Lcom/google/android/gms/common/api/HasApiKey;)Lcom/google/android/gms/tasks/Task;", "")]
		public unsafe static Android.Gms.Tasks.Task Zai(IHasApiKey p0, params IHasApiKey[] p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.StaticMethods.InvokeObjectMethod("zai.(Lcom/google/android/gms/common/api/HasApiKey;[Lcom/google/android/gms/common/api/HasApiKey;)Lcom/google/android/gms/tasks/Task;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
}
namespace Android.Gms.Common.Api.Internal
{
	[Register("com/google/android/gms/common/api/internal/ApiKey", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
	public sealed class ApiKey : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/ApiKey", typeof(ApiKey));

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

		internal ApiKey(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("equals", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Equals(Java.Lang.Object p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("hashCode", "()I", "")]
		public unsafe sealed override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
		}

		[Register("zaa", "(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Ljava/lang/String;)Lcom/google/android/gms/common/api/internal/ApiKey;", "")]
		[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
		public unsafe static ApiKey Zaa(Android.Gms.Common.Apis.Api p0, Java.Lang.Object p1, string p2)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<ApiKey>(_members.StaticMethods.InvokeObjectMethod("zaa.(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Ljava/lang/String;)Lcom/google/android/gms/common/api/internal/ApiKey;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zab", "()Ljava/lang/String;", "")]
		public unsafe string Zab()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zab.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/common/api/internal/ConnectionCallbacks", "", "Android.Gms.Common.Api.Internal.IConnectionCallbacksInvoker")]
	public interface IConnectionCallbacks : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onConnected", "(Landroid/os/Bundle;)V", "GetOnConnected_Landroid_os_Bundle_Handler:Android.Gms.Common.Api.Internal.IConnectionCallbacksInvoker, Xamarin.GooglePlayServices.Base")]
		void OnConnected(Bundle p0);

		[Register("onConnectionSuspended", "(I)V", "GetOnConnectionSuspended_IHandler:Android.Gms.Common.Api.Internal.IConnectionCallbacksInvoker, Xamarin.GooglePlayServices.Base")]
		void OnConnectionSuspended(int p0);
	}
	[Register("com/google/android/gms/common/api/internal/ConnectionCallbacks", DoNotGenerateAcw = true)]
	internal class IConnectionCallbacksInvoker : Java.Lang.Object, IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/ConnectionCallbacks", typeof(IConnectionCallbacksInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onConnected_Landroid_os_Bundle_;

		private IntPtr id_onConnected_Landroid_os_Bundle_;

		private static Delegate cb_onConnectionSuspended_I;

		private IntPtr id_onConnectionSuspended_I;

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

		public static IConnectionCallbacks GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IConnectionCallbacks>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.ConnectionCallbacks'.");
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

		public IConnectionCallbacksInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnConnected_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onConnected_Landroid_os_Bundle_ == null)
			{
				cb_onConnected_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnected_Landroid_os_Bundle_));
			}
			return cb_onConnected_Landroid_os_Bundle_;
		}

		private static void n_OnConnected_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IConnectionCallbacks connectionCallbacks = Java.Lang.Object.GetObject<IConnectionCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
			connectionCallbacks.OnConnected(p);
		}

		public unsafe void OnConnected(Bundle p0)
		{
			if (id_onConnected_Landroid_os_Bundle_ == IntPtr.Zero)
			{
				id_onConnected_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "onConnected", "(Landroid/os/Bundle;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnected_Landroid_os_Bundle_, ptr);
		}

		private static Delegate GetOnConnectionSuspended_IHandler()
		{
			if ((object)cb_onConnectionSuspended_I == null)
			{
				cb_onConnectionSuspended_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnConnectionSuspended_I));
			}
			return cb_onConnectionSuspended_I;
		}

		private static void n_OnConnectionSuspended_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<IConnectionCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnConnectionSuspended(p0);
		}

		public unsafe void OnConnectionSuspended(int p0)
		{
			if (id_onConnectionSuspended_I == IntPtr.Zero)
			{
				id_onConnectionSuspended_I = JNIEnv.GetMethodID(class_ref, "onConnectionSuspended", "(I)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnectionSuspended_I, ptr);
		}
	}
	[Register("com/google/android/gms/common/api/internal/OnConnectionFailedListener", "", "Android.Gms.Common.Api.Internal.IOnConnectionFailedListenerInvoker")]
	public interface IOnConnectionFailedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onConnectionFailed", "(Lcom/google/android/gms/common/ConnectionResult;)V", "GetOnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_Handler:Android.Gms.Common.Api.Internal.IOnConnectionFailedListenerInvoker, Xamarin.GooglePlayServices.Base")]
		void OnConnectionFailed(ConnectionResult p0);
	}
	[Register("com/google/android/gms/common/api/internal/OnConnectionFailedListener", DoNotGenerateAcw = true)]
	internal class IOnConnectionFailedListenerInvoker : Java.Lang.Object, IOnConnectionFailedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/OnConnectionFailedListener", typeof(IOnConnectionFailedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;

		private IntPtr id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;

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

		public static IOnConnectionFailedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnConnectionFailedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.OnConnectionFailedListener'.");
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

		public IOnConnectionFailedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_Handler()
		{
			if ((object)cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ == null)
			{
				cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_));
			}
			return cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;
		}

		private static void n_OnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IOnConnectionFailedListener onConnectionFailedListener = Java.Lang.Object.GetObject<IOnConnectionFailedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConnectionResult p = Java.Lang.Object.GetObject<ConnectionResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			onConnectionFailedListener.OnConnectionFailed(p);
		}

		public unsafe void OnConnectionFailed(ConnectionResult p0)
		{
			if (id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ == IntPtr.Zero)
			{
				id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ = JNIEnv.GetMethodID(class_ref, "onConnectionFailed", "(Lcom/google/android/gms/common/ConnectionResult;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_, ptr);
		}
	}
	[Register("com/google/android/gms/common/api/internal/RemoteCall", "", "Android.Gms.Common.Api.Internal.IRemoteCallInvoker")]
	[JavaTypeParameters(new string[] { "T", "U" })]
	public interface IRemoteCall : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("accept", "(Ljava/lang/Object;Ljava/lang/Object;)V", "GetAccept_Ljava_lang_Object_Ljava_lang_Object_Handler:Android.Gms.Common.Api.Internal.IRemoteCallInvoker, Xamarin.GooglePlayServices.Base")]
		void Accept(Java.Lang.Object p0, Java.Lang.Object p1);
	}
	[Register("com/google/android/gms/common/api/internal/RemoteCall", DoNotGenerateAcw = true)]
	internal class IRemoteCallInvoker : Java.Lang.Object, IRemoteCall, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/RemoteCall", typeof(IRemoteCallInvoker));

		private IntPtr class_ref;

		private static Delegate cb_accept_Ljava_lang_Object_Ljava_lang_Object_;

		private IntPtr id_accept_Ljava_lang_Object_Ljava_lang_Object_;

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

		public static IRemoteCall GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRemoteCall>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.RemoteCall'.");
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

		public IRemoteCallInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAccept_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_accept_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_accept_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Accept_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_accept_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static void n_Accept_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IRemoteCall remoteCall = Java.Lang.Object.GetObject<IRemoteCall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			remoteCall.Accept(p, p2);
		}

		public unsafe void Accept(Java.Lang.Object p0, Java.Lang.Object p1)
		{
			if (id_accept_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_accept_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "accept", "(Ljava/lang/Object;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_accept_Ljava_lang_Object_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}
	}
	[Register("com/google/android/gms/common/api/internal/SignInConnectionListener", "", "Android.Gms.Common.Api.Internal.ISignInConnectionListenerInvoker")]
	public interface ISignInConnectionListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onComplete", "()V", "GetOnCompleteHandler:Android.Gms.Common.Api.Internal.ISignInConnectionListenerInvoker, Xamarin.GooglePlayServices.Base")]
		void OnComplete();
	}
	[Register("com/google/android/gms/common/api/internal/SignInConnectionListener", DoNotGenerateAcw = true)]
	internal class ISignInConnectionListenerInvoker : Java.Lang.Object, ISignInConnectionListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/SignInConnectionListener", typeof(ISignInConnectionListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onComplete;

		private IntPtr id_onComplete;

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

		public static ISignInConnectionListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISignInConnectionListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.SignInConnectionListener'.");
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

		public ISignInConnectionListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCompleteHandler()
		{
			if ((object)cb_onComplete == null)
			{
				cb_onComplete = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnComplete));
			}
			return cb_onComplete;
		}

		private static void n_OnComplete(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ISignInConnectionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnComplete();
		}

		public void OnComplete()
		{
			if (id_onComplete == IntPtr.Zero)
			{
				id_onComplete = JNIEnv.GetMethodID(class_ref, "onComplete", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onComplete);
		}
	}
	[Register("com/google/android/gms/common/api/internal/zat", "", "Android.Gms.Common.Api.Internal.IZatInvoker")]
	public interface IZat : GoogleApiClient.IConnectionCallbacks, IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("zaa", "(Lcom/google/android/gms/common/ConnectionResult;Lcom/google/android/gms/common/api/Api;Z)V", "GetZaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_ZHandler:Android.Gms.Common.Api.Internal.IZatInvoker, Xamarin.GooglePlayServices.Base")]
		void Zaa(ConnectionResult p0, Android.Gms.Common.Apis.Api p1, bool p2);
	}
	[Register("com/google/android/gms/common/api/internal/zat", DoNotGenerateAcw = true)]
	internal class IZatInvoker : Java.Lang.Object, IZat, GoogleApiClient.IConnectionCallbacks, IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zat", typeof(IZatInvoker));

		private IntPtr class_ref;

		private static Delegate cb_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z;

		private IntPtr id_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z;

		private static Delegate cb_onConnected_Landroid_os_Bundle_;

		private IntPtr id_onConnected_Landroid_os_Bundle_;

		private static Delegate cb_onConnectionSuspended_I;

		private IntPtr id_onConnectionSuspended_I;

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

		public static IZat GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IZat>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.zat'.");
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

		public IZatInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetZaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_ZHandler()
		{
			if ((object)cb_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z == null)
			{
				cb_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_Zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z));
			}
			return cb_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z;
		}

		private static void n_Zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2)
		{
			IZat zat = Java.Lang.Object.GetObject<IZat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConnectionResult p3 = Java.Lang.Object.GetObject<ConnectionResult>(native_p0, JniHandleOwnership.DoNotTransfer);
			Android.Gms.Common.Apis.Api p4 = Java.Lang.Object.GetObject<Android.Gms.Common.Apis.Api>(native_p1, JniHandleOwnership.DoNotTransfer);
			zat.Zaa(p3, p4, p2);
		}

		public unsafe void Zaa(ConnectionResult p0, Android.Gms.Common.Apis.Api p1, bool p2)
		{
			if (id_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z == IntPtr.Zero)
			{
				id_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z = JNIEnv.GetMethodID(class_ref, "zaa", "(Lcom/google/android/gms/common/ConnectionResult;Lcom/google/android/gms/common/api/Api;Z)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_zaa_Lcom_google_android_gms_common_ConnectionResult_Lcom_google_android_gms_common_api_Api_Z, ptr);
		}

		private static Delegate GetOnConnected_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onConnected_Landroid_os_Bundle_ == null)
			{
				cb_onConnected_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnected_Landroid_os_Bundle_));
			}
			return cb_onConnected_Landroid_os_Bundle_;
		}

		private static void n_OnConnected_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IZat zat = Java.Lang.Object.GetObject<IZat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
			zat.OnConnected(p);
		}

		public unsafe void OnConnected(Bundle p0)
		{
			if (id_onConnected_Landroid_os_Bundle_ == IntPtr.Zero)
			{
				id_onConnected_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "onConnected", "(Landroid/os/Bundle;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnected_Landroid_os_Bundle_, ptr);
		}

		private static Delegate GetOnConnectionSuspended_IHandler()
		{
			if ((object)cb_onConnectionSuspended_I == null)
			{
				cb_onConnectionSuspended_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnConnectionSuspended_I));
			}
			return cb_onConnectionSuspended_I;
		}

		private static void n_OnConnectionSuspended_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<IZat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnConnectionSuspended(p0);
		}

		public unsafe void OnConnectionSuspended(int p0)
		{
			if (id_onConnectionSuspended_I == IntPtr.Zero)
			{
				id_onConnectionSuspended_I = JNIEnv.GetMethodID(class_ref, "onConnectionSuspended", "(I)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_onConnectionSuspended_I, ptr);
		}
	}
	[Register("com/google/android/gms/common/api/internal/ListenerHolder", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "L" })]
	public sealed class ListenerHolder : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/internal/ListenerHolder$ListenerKey", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "L" })]
		public sealed class ListenerKey : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/ListenerHolder$ListenerKey", typeof(ListenerKey));

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

			internal ListenerKey(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/google/android/gms/common/api/internal/ListenerHolder$Notifier", "", "Android.Gms.Common.Api.Internal.ListenerHolder/INotifierInvoker")]
		[JavaTypeParameters(new string[] { "L" })]
		public interface INotifier : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("notifyListener", "(Ljava/lang/Object;)V", "GetNotifyListener_Ljava_lang_Object_Handler:Android.Gms.Common.Api.Internal.ListenerHolder/INotifierInvoker, Xamarin.GooglePlayServices.Base")]
			void NotifyListener(Java.Lang.Object p0);

			[Register("onNotifyListenerFailed", "()V", "GetOnNotifyListenerFailedHandler:Android.Gms.Common.Api.Internal.ListenerHolder/INotifierInvoker, Xamarin.GooglePlayServices.Base")]
			void OnNotifyListenerFailed();
		}

		[Register("com/google/android/gms/common/api/internal/ListenerHolder$Notifier", DoNotGenerateAcw = true)]
		internal class INotifierInvoker : Java.Lang.Object, INotifier, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/ListenerHolder$Notifier", typeof(INotifierInvoker));

			private IntPtr class_ref;

			private static Delegate cb_notifyListener_Ljava_lang_Object_;

			private IntPtr id_notifyListener_Ljava_lang_Object_;

			private static Delegate cb_onNotifyListenerFailed;

			private IntPtr id_onNotifyListenerFailed;

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

			public static INotifier GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<INotifier>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.ListenerHolder.Notifier'.");
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

			public INotifierInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetNotifyListener_Ljava_lang_Object_Handler()
			{
				if ((object)cb_notifyListener_Ljava_lang_Object_ == null)
				{
					cb_notifyListener_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_NotifyListener_Ljava_lang_Object_));
				}
				return cb_notifyListener_Ljava_lang_Object_;
			}

			private static void n_NotifyListener_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				INotifier notifier = Java.Lang.Object.GetObject<INotifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
				notifier.NotifyListener(p);
			}

			public unsafe void NotifyListener(Java.Lang.Object p0)
			{
				if (id_notifyListener_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_notifyListener_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "notifyListener", "(Ljava/lang/Object;)V");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_notifyListener_Ljava_lang_Object_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}

			private static Delegate GetOnNotifyListenerFailedHandler()
			{
				if ((object)cb_onNotifyListenerFailed == null)
				{
					cb_onNotifyListenerFailed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnNotifyListenerFailed));
				}
				return cb_onNotifyListenerFailed;
			}

			private static void n_OnNotifyListenerFailed(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<INotifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnNotifyListenerFailed();
			}

			public void OnNotifyListenerFailed()
			{
				if (id_onNotifyListenerFailed == IntPtr.Zero)
				{
					id_onNotifyListenerFailed = JNIEnv.GetMethodID(class_ref, "onNotifyListenerFailed", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onNotifyListenerFailed);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/ListenerHolder", typeof(ListenerHolder));

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

		public unsafe bool HasListener
		{
			[Register("hasListener", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasListener.()Z", this, null);
			}
		}

		internal ListenerHolder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		[Register("getListenerKey", "()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", "")]
		public unsafe ListenerKey GetListenerKey()
		{
			return Java.Lang.Object.GetObject<ListenerKey>(_members.InstanceMethods.InvokeAbstractObjectMethod("getListenerKey.()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("notifyListener", "(Lcom/google/android/gms/common/api/internal/ListenerHolder$Notifier;)V", "")]
		public unsafe void NotifyListener(INotifier p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("notifyListener.(Lcom/google/android/gms/common/api/internal/ListenerHolder$Notifier;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/RegisterListenerMethod", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "L" })]
	public abstract class RegisterListenerMethod : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/RegisterListenerMethod", typeof(RegisterListenerMethod));

		private static Delegate cb_getListenerKey;

		private static Delegate cb_clearListener;

		private static Delegate cb_getRequiredFeatures;

		private static Delegate cb_registerListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;

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

		public unsafe virtual ListenerHolder.ListenerKey ListenerKey
		{
			[Register("getListenerKey", "()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", "GetGetListenerKeyHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ListenerHolder.ListenerKey>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListenerKey.()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected RegisterListenerMethod(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/ListenerHolder;)V", "")]
		protected unsafe RegisterListenerMethod(ListenerHolder p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;Z)V", "")]
		protected unsafe RegisterListenerMethod(ListenerHolder p0, Feature[] p1, bool p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;Z)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;ZI)V", "")]
		protected unsafe RegisterListenerMethod(ListenerHolder p0, Feature[] p1, bool p2, int p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;ZI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder;[Lcom/google/android/gms/common/Feature;ZI)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetGetListenerKeyHandler()
		{
			if ((object)cb_getListenerKey == null)
			{
				cb_getListenerKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetListenerKey));
			}
			return cb_getListenerKey;
		}

		private static IntPtr n_GetListenerKey(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RegisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListenerKey);
		}

		private static Delegate GetClearListenerHandler()
		{
			if ((object)cb_clearListener == null)
			{
				cb_clearListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearListener));
			}
			return cb_clearListener;
		}

		private static void n_ClearListener(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<RegisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearListener();
		}

		[Register("clearListener", "()V", "GetClearListenerHandler")]
		public unsafe virtual void ClearListener()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearListener.()V", this, null);
		}

		private static Delegate GetGetRequiredFeaturesHandler()
		{
			if ((object)cb_getRequiredFeatures == null)
			{
				cb_getRequiredFeatures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRequiredFeatures));
			}
			return cb_getRequiredFeatures;
		}

		private static IntPtr n_GetRequiredFeatures(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<RegisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRequiredFeatures());
		}

		[Register("getRequiredFeatures", "()[Lcom/google/android/gms/common/Feature;", "GetGetRequiredFeaturesHandler")]
		public unsafe virtual Feature[] GetRequiredFeatures()
		{
			return (Feature[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getRequiredFeatures.()[Lcom/google/android/gms/common/Feature;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Feature));
		}

		private static Delegate GetRegisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler()
		{
			if ((object)cb_registerListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ == null)
			{
				cb_registerListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_));
			}
			return cb_registerListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;
		}

		private static void n_RegisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RegisterListenerMethod registerListenerMethod = Java.Lang.Object.GetObject<RegisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			TaskCompletionSource p2 = Java.Lang.Object.GetObject<TaskCompletionSource>(native_p1, JniHandleOwnership.DoNotTransfer);
			registerListenerMethod.RegisterListener(p, p2);
		}

		[Register("registerListener", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetRegisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected abstract void RegisterListener(Java.Lang.Object p0, TaskCompletionSource p1);

		[Register("zaa", "()Z", "")]
		public unsafe bool Zaa()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("zaa.()Z", this, null);
		}

		[Register("zab", "()I", "")]
		public unsafe int Zab()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("zab.()I", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/RegisterListenerMethod", DoNotGenerateAcw = true)]
	internal class RegisterListenerMethodInvoker : RegisterListenerMethod
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/RegisterListenerMethod", typeof(RegisterListenerMethodInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public RegisterListenerMethodInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("registerListener", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetRegisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected unsafe override void RegisterListener(Java.Lang.Object p0, TaskCompletionSource p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("registerListener.(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/RegistrationMethods", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "L" })]
	public class RegistrationMethods : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/internal/RegistrationMethods$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "L" })]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/RegistrationMethods$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_onConnectionSuspended_Ljava_lang_Runnable_;

			private static Delegate cb_register_Lcom_google_android_gms_common_api_internal_RemoteCall_;

			private static Delegate cb_register_Lcom_google_android_gms_common_util_BiConsumer_;

			private static Delegate cb_setAutoResolveMissingFeatures_Z;

			private static Delegate cb_setFeatures_arrayLcom_google_android_gms_common_Feature_;

			private static Delegate cb_setMethodKey_I;

			private static Delegate cb_unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_;

			private static Delegate cb_unregister_Lcom_google_android_gms_common_util_BiConsumer_;

			private static Delegate cb_withHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_;

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

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/google/android/gms/common/api/internal/RegistrationMethods;", "GetBuildHandler")]
			public unsafe virtual RegistrationMethods Build()
			{
				return Java.Lang.Object.GetObject<RegistrationMethods>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/google/android/gms/common/api/internal/RegistrationMethods;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetOnConnectionSuspended_Ljava_lang_Runnable_Handler()
			{
				if ((object)cb_onConnectionSuspended_Ljava_lang_Runnable_ == null)
				{
					cb_onConnectionSuspended_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnConnectionSuspended_Ljava_lang_Runnable_));
				}
				return cb_onConnectionSuspended_Ljava_lang_Runnable_;
			}

			private static IntPtr n_OnConnectionSuspended_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRunnable p = Java.Lang.Object.GetObject<IRunnable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.OnConnectionSuspended(p));
			}

			[Register("onConnectionSuspended", "(Ljava/lang/Runnable;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetOnConnectionSuspended_Ljava_lang_Runnable_Handler")]
			public unsafe virtual Builder OnConnectionSuspended(IRunnable p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("onConnectionSuspended.(Ljava/lang/Runnable;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetRegister_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler()
			{
				if ((object)cb_register_Lcom_google_android_gms_common_api_internal_RemoteCall_ == null)
				{
					cb_register_Lcom_google_android_gms_common_api_internal_RemoteCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Register_Lcom_google_android_gms_common_api_internal_RemoteCall_));
				}
				return cb_register_Lcom_google_android_gms_common_api_internal_RemoteCall_;
			}

			private static IntPtr n_Register_Lcom_google_android_gms_common_api_internal_RemoteCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRemoteCall p = Java.Lang.Object.GetObject<IRemoteCall>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Register(p));
			}

			[Register("register", "(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetRegister_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler")]
			public unsafe virtual Builder Register(IRemoteCall p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetRegister_Lcom_google_android_gms_common_util_BiConsumer_Handler()
			{
				if ((object)cb_register_Lcom_google_android_gms_common_util_BiConsumer_ == null)
				{
					cb_register_Lcom_google_android_gms_common_util_BiConsumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Register_Lcom_google_android_gms_common_util_BiConsumer_));
				}
				return cb_register_Lcom_google_android_gms_common_util_BiConsumer_;
			}

			private static IntPtr n_Register_Lcom_google_android_gms_common_util_BiConsumer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IBiConsumer p = Java.Lang.Object.GetObject<IBiConsumer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Register(p));
			}

			[Register("register", "(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetRegister_Lcom_google_android_gms_common_util_BiConsumer_Handler")]
			public unsafe virtual Builder Register(IBiConsumer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("register.(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetSetAutoResolveMissingFeatures_ZHandler()
			{
				if ((object)cb_setAutoResolveMissingFeatures_Z == null)
				{
					cb_setAutoResolveMissingFeatures_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAutoResolveMissingFeatures_Z));
				}
				return cb_setAutoResolveMissingFeatures_Z;
			}

			private static IntPtr n_SetAutoResolveMissingFeatures_Z(IntPtr jnienv, IntPtr native__this, bool p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutoResolveMissingFeatures(p0));
			}

			[Register("setAutoResolveMissingFeatures", "(Z)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetSetAutoResolveMissingFeatures_ZHandler")]
			public unsafe virtual Builder SetAutoResolveMissingFeatures(bool p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAutoResolveMissingFeatures.(Z)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetFeatures_arrayLcom_google_android_gms_common_Feature_Handler()
			{
				if ((object)cb_setFeatures_arrayLcom_google_android_gms_common_Feature_ == null)
				{
					cb_setFeatures_arrayLcom_google_android_gms_common_Feature_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFeatures_arrayLcom_google_android_gms_common_Feature_));
				}
				return cb_setFeatures_arrayLcom_google_android_gms_common_Feature_;
			}

			private static IntPtr n_SetFeatures_arrayLcom_google_android_gms_common_Feature_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Feature[] array = (Feature[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(Feature));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.SetFeatures(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p0);
				}
				return result;
			}

			[Register("setFeatures", "([Lcom/google/android/gms/common/Feature;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetSetFeatures_arrayLcom_google_android_gms_common_Feature_Handler")]
			public unsafe virtual Builder SetFeatures(params Feature[] p0)
			{
				IntPtr intPtr = JNIEnv.NewArray(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFeatures.([Lcom/google/android/gms/common/Feature;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (p0 != null)
					{
						JNIEnv.CopyArray(intPtr, p0);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetSetMethodKey_IHandler()
			{
				if ((object)cb_setMethodKey_I == null)
				{
					cb_setMethodKey_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetMethodKey_I));
				}
				return cb_setMethodKey_I;
			}

			private static IntPtr n_SetMethodKey_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMethodKey(p0));
			}

			[Register("setMethodKey", "(I)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetSetMethodKey_IHandler")]
			public unsafe virtual Builder SetMethodKey(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMethodKey.(I)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetUnregister_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler()
			{
				if ((object)cb_unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_ == null)
				{
					cb_unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_));
				}
				return cb_unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_;
			}

			private static IntPtr n_Unregister_Lcom_google_android_gms_common_api_internal_RemoteCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRemoteCall p = Java.Lang.Object.GetObject<IRemoteCall>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Unregister(p));
			}

			[Register("unregister", "(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetUnregister_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler")]
			public unsafe virtual Builder Unregister(IRemoteCall p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("unregister.(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetUnregister_Lcom_google_android_gms_common_util_BiConsumer_Handler()
			{
				if ((object)cb_unregister_Lcom_google_android_gms_common_util_BiConsumer_ == null)
				{
					cb_unregister_Lcom_google_android_gms_common_util_BiConsumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Unregister_Lcom_google_android_gms_common_util_BiConsumer_));
				}
				return cb_unregister_Lcom_google_android_gms_common_util_BiConsumer_;
			}

			private static IntPtr n_Unregister_Lcom_google_android_gms_common_util_BiConsumer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IBiConsumer p = Java.Lang.Object.GetObject<IBiConsumer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Unregister(p));
			}

			[Register("unregister", "(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetUnregister_Lcom_google_android_gms_common_util_BiConsumer_Handler")]
			public unsafe virtual Builder Unregister(IBiConsumer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("unregister.(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetWithHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_Handler()
			{
				if ((object)cb_withHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_ == null)
				{
					cb_withHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_));
				}
				return cb_withHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_;
			}

			private static IntPtr n_WithHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ListenerHolder p = Java.Lang.Object.GetObject<ListenerHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.WithHolder(p));
			}

			[Register("withHolder", "(Lcom/google/android/gms/common/api/internal/ListenerHolder;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "GetWithHolder_Lcom_google_android_gms_common_api_internal_ListenerHolder_Handler")]
			public unsafe virtual Builder WithHolder(ListenerHolder p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("withHolder.(Lcom/google/android/gms/common/api/internal/ListenerHolder;)Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/RegistrationMethods", typeof(RegistrationMethods));

		[Register("register")]
		public RegisterListenerMethod Register
		{
			get
			{
				return Java.Lang.Object.GetObject<RegisterListenerMethod>(_members.InstanceFields.GetObjectValue("register.Lcom/google/android/gms/common/api/internal/RegisterListenerMethod;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("register.Lcom/google/android/gms/common/api/internal/RegisterListenerMethod;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("zaa")]
		public UnregisterListenerMethod Zaa
		{
			get
			{
				return Java.Lang.Object.GetObject<UnregisterListenerMethod>(_members.InstanceFields.GetObjectValue("zaa.Lcom/google/android/gms/common/api/internal/UnregisterListenerMethod;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("zaa.Lcom/google/android/gms/common/api/internal/UnregisterListenerMethod;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("zab")]
		public IRunnable Zab
		{
			get
			{
				return Java.Lang.Object.GetObject<IRunnable>(_members.InstanceFields.GetObjectValue("zab.Ljava/lang/Runnable;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("zab.Ljava/lang/Runnable;", this, new JniObjectReference(jobject));
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

		protected RegistrationMethods(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("builder", "()Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", "")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "L" })]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/gms/common/api/internal/RegistrationMethods$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/common/api/internal/TaskApiCall", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "ResultT" })]
	public abstract class TaskApiCall : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/internal/TaskApiCall$Builder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "ResultT" })]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/TaskApiCall$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_execute_Lcom_google_android_gms_common_util_BiConsumer_;

			private static Delegate cb_run_Lcom_google_android_gms_common_api_internal_RemoteCall_;

			private static Delegate cb_setAutoResolveMissingFeatures_Z;

			private static Delegate cb_setFeatures_arrayLcom_google_android_gms_common_Feature_;

			private static Delegate cb_setMethodKey_I;

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

			protected Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Lcom/google/android/gms/common/api/internal/TaskApiCall;", "GetBuildHandler")]
			public unsafe virtual TaskApiCall Build()
			{
				return Java.Lang.Object.GetObject<TaskApiCall>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/google/android/gms/common/api/internal/TaskApiCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetExecute_Lcom_google_android_gms_common_util_BiConsumer_Handler()
			{
				if ((object)cb_execute_Lcom_google_android_gms_common_util_BiConsumer_ == null)
				{
					cb_execute_Lcom_google_android_gms_common_util_BiConsumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Execute_Lcom_google_android_gms_common_util_BiConsumer_));
				}
				return cb_execute_Lcom_google_android_gms_common_util_BiConsumer_;
			}

			private static IntPtr n_Execute_Lcom_google_android_gms_common_util_BiConsumer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IBiConsumer p = Java.Lang.Object.GetObject<IBiConsumer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Execute(p));
			}

			[Register("execute", "(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "GetExecute_Lcom_google_android_gms_common_util_BiConsumer_Handler")]
			public unsafe virtual Builder Execute(IBiConsumer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("execute.(Lcom/google/android/gms/common/util/BiConsumer;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetRun_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler()
			{
				if ((object)cb_run_Lcom_google_android_gms_common_api_internal_RemoteCall_ == null)
				{
					cb_run_Lcom_google_android_gms_common_api_internal_RemoteCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Run_Lcom_google_android_gms_common_api_internal_RemoteCall_));
				}
				return cb_run_Lcom_google_android_gms_common_api_internal_RemoteCall_;
			}

			private static IntPtr n_Run_Lcom_google_android_gms_common_api_internal_RemoteCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRemoteCall p = Java.Lang.Object.GetObject<IRemoteCall>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.Run(p));
			}

			[Register("run", "(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "GetRun_Lcom_google_android_gms_common_api_internal_RemoteCall_Handler")]
			public unsafe virtual Builder Run(IRemoteCall p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("run.(Lcom/google/android/gms/common/api/internal/RemoteCall;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetSetAutoResolveMissingFeatures_ZHandler()
			{
				if ((object)cb_setAutoResolveMissingFeatures_Z == null)
				{
					cb_setAutoResolveMissingFeatures_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetAutoResolveMissingFeatures_Z));
				}
				return cb_setAutoResolveMissingFeatures_Z;
			}

			private static IntPtr n_SetAutoResolveMissingFeatures_Z(IntPtr jnienv, IntPtr native__this, bool p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutoResolveMissingFeatures(p0));
			}

			[Register("setAutoResolveMissingFeatures", "(Z)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "GetSetAutoResolveMissingFeatures_ZHandler")]
			public unsafe virtual Builder SetAutoResolveMissingFeatures(bool p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAutoResolveMissingFeatures.(Z)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetFeatures_arrayLcom_google_android_gms_common_Feature_Handler()
			{
				if ((object)cb_setFeatures_arrayLcom_google_android_gms_common_Feature_ == null)
				{
					cb_setFeatures_arrayLcom_google_android_gms_common_Feature_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFeatures_arrayLcom_google_android_gms_common_Feature_));
				}
				return cb_setFeatures_arrayLcom_google_android_gms_common_Feature_;
			}

			private static IntPtr n_SetFeatures_arrayLcom_google_android_gms_common_Feature_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Feature[] array = (Feature[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(Feature));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.SetFeatures(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p0);
				}
				return result;
			}

			[Register("setFeatures", "([Lcom/google/android/gms/common/Feature;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "GetSetFeatures_arrayLcom_google_android_gms_common_Feature_Handler")]
			public unsafe virtual Builder SetFeatures(params Feature[] p0)
			{
				IntPtr intPtr = JNIEnv.NewArray(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFeatures.([Lcom/google/android/gms/common/Feature;)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (p0 != null)
					{
						JNIEnv.CopyArray(intPtr, p0);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(p0);
				}
			}

			private static Delegate GetSetMethodKey_IHandler()
			{
				if ((object)cb_setMethodKey_I == null)
				{
					cb_setMethodKey_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetMethodKey_I));
				}
				return cb_setMethodKey_I;
			}

			private static IntPtr n_SetMethodKey_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMethodKey(p0));
			}

			[Register("setMethodKey", "(I)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "GetSetMethodKey_IHandler")]
			public unsafe virtual Builder SetMethodKey(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMethodKey.(I)Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/TaskApiCall", typeof(TaskApiCall));

		private static Delegate cb_doExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;

		private static Delegate cb_shouldAutoResolveMissingFeatures;

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

		protected TaskApiCall(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TaskApiCall()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "([Lcom/google/android/gms/common/Feature;ZI)V", "")]
		protected unsafe TaskApiCall(Feature[] p0, bool p1, int p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([Lcom/google/android/gms/common/Feature;ZI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([Lcom/google/android/gms/common/Feature;ZI)V", this, ptr);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(intPtr, p0);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
			}
		}

		[Register("builder", "()Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", "")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "ResultT" })]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/gms/common/api/internal/TaskApiCall$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDoExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler()
		{
			if ((object)cb_doExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ == null)
			{
				cb_doExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_DoExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_));
			}
			return cb_doExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;
		}

		private static void n_DoExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			TaskApiCall taskApiCall = Java.Lang.Object.GetObject<TaskApiCall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			TaskCompletionSource p2 = Java.Lang.Object.GetObject<TaskCompletionSource>(native_p1, JniHandleOwnership.DoNotTransfer);
			taskApiCall.DoExecute(p, p2);
		}

		[Register("doExecute", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetDoExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected abstract void DoExecute(Java.Lang.Object p0, TaskCompletionSource p1);

		private static Delegate GetShouldAutoResolveMissingFeaturesHandler()
		{
			if ((object)cb_shouldAutoResolveMissingFeatures == null)
			{
				cb_shouldAutoResolveMissingFeatures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ShouldAutoResolveMissingFeatures));
			}
			return cb_shouldAutoResolveMissingFeatures;
		}

		private static bool n_ShouldAutoResolveMissingFeatures(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TaskApiCall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldAutoResolveMissingFeatures();
		}

		[Register("shouldAutoResolveMissingFeatures", "()Z", "GetShouldAutoResolveMissingFeaturesHandler")]
		public unsafe virtual bool ShouldAutoResolveMissingFeatures()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldAutoResolveMissingFeatures.()Z", this, null);
		}

		[Register("zaa", "()[Lcom/google/android/gms/common/Feature;", "")]
		public unsafe Feature[] Zaa()
		{
			return (Feature[])JNIEnv.GetArray(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zaa.()[Lcom/google/android/gms/common/Feature;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Feature));
		}

		[Register("zab", "()I", "")]
		public unsafe int Zab()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("zab.()I", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/TaskApiCall", DoNotGenerateAcw = true)]
	internal class TaskApiCallInvoker : TaskApiCall
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/TaskApiCall", typeof(TaskApiCallInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TaskApiCallInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("doExecute", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetDoExecute_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected unsafe override void DoExecute(Java.Lang.Object p0, TaskCompletionSource p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("doExecute.(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/UnregisterListenerMethod", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "L" })]
	public abstract class UnregisterListenerMethod : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/UnregisterListenerMethod", typeof(UnregisterListenerMethod));

		private static Delegate cb_getListenerKey;

		private static Delegate cb_unregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;

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

		public unsafe virtual ListenerHolder.ListenerKey ListenerKey
		{
			[Register("getListenerKey", "()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", "GetGetListenerKeyHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ListenerHolder.ListenerKey>(_members.InstanceMethods.InvokeVirtualObjectMethod("getListenerKey.()Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected UnregisterListenerMethod(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;)V", "")]
		protected unsafe UnregisterListenerMethod(ListenerHolder.ListenerKey p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetListenerKeyHandler()
		{
			if ((object)cb_getListenerKey == null)
			{
				cb_getListenerKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetListenerKey));
			}
			return cb_getListenerKey;
		}

		private static IntPtr n_GetListenerKey(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<UnregisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListenerKey);
		}

		private static Delegate GetUnregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler()
		{
			if ((object)cb_unregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ == null)
			{
				cb_unregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UnregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_));
			}
			return cb_unregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_;
		}

		private static void n_UnregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			UnregisterListenerMethod unregisterListenerMethod = Java.Lang.Object.GetObject<UnregisterListenerMethod>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			TaskCompletionSource p2 = Java.Lang.Object.GetObject<TaskCompletionSource>(native_p1, JniHandleOwnership.DoNotTransfer);
			unregisterListenerMethod.UnregisterListener(p, p2);
		}

		[Register("unregisterListener", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetUnregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected abstract void UnregisterListener(Java.Lang.Object p0, TaskCompletionSource p1);
	}
	[Register("com/google/android/gms/common/api/internal/UnregisterListenerMethod", DoNotGenerateAcw = true)]
	internal class UnregisterListenerMethodInvoker : UnregisterListenerMethod
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/UnregisterListenerMethod", typeof(UnregisterListenerMethodInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public UnregisterListenerMethodInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("unregisterListener", "(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", "GetUnregisterListener_Lcom_google_android_gms_common_api_Api_AnyClient_Lcom_google_android_gms_tasks_TaskCompletionSource_Handler")]
		protected unsafe override void UnregisterListener(Java.Lang.Object p0, TaskCompletionSource p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterListener.(Lcom/google/android/gms/common/api/Api$AnyClient;Lcom/google/android/gms/tasks/TaskCompletionSource;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/zaaa", DoNotGenerateAcw = true)]
	public sealed class Zaaa : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zaaa", typeof(Zaaa));

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

		internal Zaaa(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Zaaa()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("zad", "()V", "")]
		public unsafe void Zad()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zad.()V", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/zabl", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
	public sealed class Zabl : Java.Lang.Object, GoogleApiClient.IConnectionCallbacks, IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable, GoogleApiClient.IOnConnectionFailedListener, IOnConnectionFailedListener, IZat
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zabl", typeof(Zabl));

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

		internal Zabl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/android/gms/common/api/GoogleApi;)V", "")]
		public unsafe Zabl(GoogleApi p0, GoogleApi p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/android/gms/common/api/GoogleApi;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/GoogleApi;Lcom/google/android/gms/common/api/GoogleApi;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("onConnected", "(Landroid/os/Bundle;)V", "")]
		public unsafe void OnConnected(Bundle p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onConnected.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onConnectionFailed", "(Lcom/google/android/gms/common/ConnectionResult;)V", "")]
		public unsafe void OnConnectionFailed(ConnectionResult p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onConnectionFailed.(Lcom/google/android/gms/common/ConnectionResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onConnectionSuspended", "(I)V", "")]
		public unsafe void OnConnectionSuspended(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onConnectionSuspended.(I)V", this, ptr);
		}

		[Register("zaa", "(Lcom/google/android/gms/common/ConnectionResult;Lcom/google/android/gms/common/api/Api;Z)V", "")]
		public unsafe void Zaa(ConnectionResult p0, Android.Gms.Common.Apis.Api p1, bool p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zaa.(Lcom/google/android/gms/common/ConnectionResult;Lcom/google/android/gms/common/api/Api;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zab", "(Lcom/google/android/gms/common/ConnectionResult;)V", "")]
		public unsafe void Zab(ConnectionResult p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zab.(Lcom/google/android/gms/common/ConnectionResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zac", "(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/Exception;)V", "")]
		public unsafe void Zac(ConnectionResult p0, Java.Lang.Exception p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zac.(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zad", "(Lcom/google/android/gms/common/api/internal/zai;)V", "")]
		public unsafe void Zad(Zai p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zad.(Lcom/google/android/gms/common/api/internal/zai;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zae", "()V", "")]
		public unsafe void Zae()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zae.()V", this, null);
		}

		[Register("zaf", "()Lcom/google/android/gms/common/api/Api$Client;", "")]
		public unsafe Android.Gms.Common.Apis.Api.IClient Zaf()
		{
			return Java.Lang.Object.GetObject<Android.Gms.Common.Apis.Api.IClient>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zaf.()Lcom/google/android/gms/common/api/Api$Client;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zag", "()Ljava/util/Map;", "")]
		public unsafe IDictionary Zag()
		{
			return JavaDictionary.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zag.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zah", "()V", "")]
		public unsafe void Zah()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zah.()V", this, null);
		}

		[Register("zai", "()Lcom/google/android/gms/common/ConnectionResult;", "")]
		public unsafe ConnectionResult Zai()
		{
			return Java.Lang.Object.GetObject<ConnectionResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zai.()Lcom/google/android/gms/common/ConnectionResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zaj", "()V", "")]
		public unsafe void Zaj()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zaj.()V", this, null);
		}

		[Register("zak", "()V", "")]
		public unsafe void Zak()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zak.()V", this, null);
		}

		[Register("zal", "()Z", "")]
		public unsafe bool Zal()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("zal.()Z", this, null);
		}

		[Register("zam", "()V", "")]
		public unsafe void Zam()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zam.()V", this, null);
		}

		[Register("zan", "(Lcom/google/android/gms/common/api/internal/zal;)V", "")]
		public unsafe void Zan(Zal p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zan.(Lcom/google/android/gms/common/api/internal/zal;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zap", "()Z", "")]
		public unsafe bool Zap()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("zap.()Z", this, null);
		}

		[Register("zaq", "()I", "")]
		public unsafe int Zaq()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("zaq.()I", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/zabq", DoNotGenerateAcw = true)]
	public abstract class Zabq : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zabq", typeof(Zabq));

		private static Delegate cb_zaa;

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

		protected Zabq(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Zabq()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetZaaHandler()
		{
			if ((object)cb_zaa == null)
			{
				cb_zaa = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Zaa));
			}
			return cb_zaa;
		}

		private static void n_Zaa(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Zabq>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zaa();
		}

		[Register("zaa", "()V", "GetZaaHandler")]
		public abstract void Zaa();
	}
	[Register("com/google/android/gms/common/api/internal/zabq", DoNotGenerateAcw = true)]
	internal class ZabqInvoker : Zabq
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zabq", typeof(ZabqInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ZabqInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("zaa", "()V", "GetZaaHandler")]
		public unsafe override void Zaa()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("zaa.()V", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/zabr", DoNotGenerateAcw = true)]
	public sealed class Zabr : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zabr", typeof(Zabr));

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

		internal Zabr(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/zabq;)V", "")]
		public unsafe Zabr(Zabq p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/zabq;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/zabq;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "")]
		public unsafe sealed override void OnReceive(Context p0, Intent p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zaa", "(Landroid/content/Context;)V", "")]
		public unsafe void Zaa(Context p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zaa.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zab", "()V", "")]
		public unsafe void Zab()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("zab.()V", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/internal/zacv", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result" })]
	public sealed class Zacv : TransformedResult, IResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zacv", typeof(Zacv));

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

		internal Zacv(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/ref/WeakReference;)V", "")]
		public unsafe Zacv(Java.Lang.Ref.WeakReference p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ref/WeakReference;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ref/WeakReference;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("andFinally", "(Lcom/google/android/gms/common/api/ResultCallbacks;)V", "")]
		public unsafe sealed override void AndFinally(ResultCallbacks p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("andFinally.(Lcom/google/android/gms/common/api/ResultCallbacks;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onResult", "(Lcom/google/android/gms/common/api/Result;)V", "")]
		public unsafe void OnResult(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onResult.(Lcom/google/android/gms/common/api/Result;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		[Register("then", "(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", "")]
		[JavaTypeParameters(new string[] { "S extends com.google.android.gms.common.api.Result" })]
		public unsafe sealed override TransformedResult Then(ResultTransform p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransformedResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("then.(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zaa", "(Lcom/google/android/gms/common/api/PendingResult;)V", "")]
		public unsafe void Zaa(PendingResult p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zaa.(Lcom/google/android/gms/common/api/PendingResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/zai", DoNotGenerateAcw = true)]
	public abstract class Zai : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zai", typeof(Zai));

		private static Delegate cb_zac_Lcom_google_android_gms_common_api_Status_;

		private static Delegate cb_zad_Ljava_lang_Exception_;

		private static Delegate cb_zae_Lcom_google_android_gms_common_api_internal_zaaa_Z;

		private static Delegate cb_zaf_Lcom_google_android_gms_common_api_internal_zabl_;

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

		protected Zai(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe Zai(int p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetZac_Lcom_google_android_gms_common_api_Status_Handler()
		{
			if ((object)cb_zac_Lcom_google_android_gms_common_api_Status_ == null)
			{
				cb_zac_Lcom_google_android_gms_common_api_Status_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Zac_Lcom_google_android_gms_common_api_Status_));
			}
			return cb_zac_Lcom_google_android_gms_common_api_Status_;
		}

		private static void n_Zac_Lcom_google_android_gms_common_api_Status_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Zai zai = Java.Lang.Object.GetObject<Zai>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Statuses p = Java.Lang.Object.GetObject<Statuses>(native_p0, JniHandleOwnership.DoNotTransfer);
			zai.Zac(p);
		}

		[Register("zac", "(Lcom/google/android/gms/common/api/Status;)V", "GetZac_Lcom_google_android_gms_common_api_Status_Handler")]
		public abstract void Zac(Statuses p0);

		private static Delegate GetZad_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_zad_Ljava_lang_Exception_ == null)
			{
				cb_zad_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Zad_Ljava_lang_Exception_));
			}
			return cb_zad_Ljava_lang_Exception_;
		}

		private static void n_Zad_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Zai zai = Java.Lang.Object.GetObject<Zai>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception p = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_p0, JniHandleOwnership.DoNotTransfer);
			zai.Zad(p);
		}

		[Register("zad", "(Ljava/lang/Exception;)V", "GetZad_Ljava_lang_Exception_Handler")]
		public abstract void Zad(Java.Lang.Exception p0);

		private static Delegate GetZae_Lcom_google_android_gms_common_api_internal_zaaa_ZHandler()
		{
			if ((object)cb_zae_Lcom_google_android_gms_common_api_internal_zaaa_Z == null)
			{
				cb_zae_Lcom_google_android_gms_common_api_internal_zaaa_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_Zae_Lcom_google_android_gms_common_api_internal_zaaa_Z));
			}
			return cb_zae_Lcom_google_android_gms_common_api_internal_zaaa_Z;
		}

		private static void n_Zae_Lcom_google_android_gms_common_api_internal_zaaa_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			Zai zai = Java.Lang.Object.GetObject<Zai>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Zaaa p2 = Java.Lang.Object.GetObject<Zaaa>(native_p0, JniHandleOwnership.DoNotTransfer);
			zai.Zae(p2, p1);
		}

		[Register("zae", "(Lcom/google/android/gms/common/api/internal/zaaa;Z)V", "GetZae_Lcom_google_android_gms_common_api_internal_zaaa_ZHandler")]
		public abstract void Zae(Zaaa p0, bool p1);

		private static Delegate GetZaf_Lcom_google_android_gms_common_api_internal_zabl_Handler()
		{
			if ((object)cb_zaf_Lcom_google_android_gms_common_api_internal_zabl_ == null)
			{
				cb_zaf_Lcom_google_android_gms_common_api_internal_zabl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Zaf_Lcom_google_android_gms_common_api_internal_zabl_));
			}
			return cb_zaf_Lcom_google_android_gms_common_api_internal_zabl_;
		}

		private static void n_Zaf_Lcom_google_android_gms_common_api_internal_zabl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Zai zai = Java.Lang.Object.GetObject<Zai>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Zabl p = Java.Lang.Object.GetObject<Zabl>(native_p0, JniHandleOwnership.DoNotTransfer);
			zai.Zaf(p);
		}

		[Register("zaf", "(Lcom/google/android/gms/common/api/internal/zabl;)V", "GetZaf_Lcom_google_android_gms_common_api_internal_zabl_Handler")]
		public abstract void Zaf(Zabl p0);
	}
	[Register("com/google/android/gms/common/api/internal/zai", DoNotGenerateAcw = true)]
	internal class ZaiInvoker : Zai
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zai", typeof(ZaiInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ZaiInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("zac", "(Lcom/google/android/gms/common/api/Status;)V", "GetZac_Lcom_google_android_gms_common_api_Status_Handler")]
		public unsafe override void Zac(Statuses p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("zac.(Lcom/google/android/gms/common/api/Status;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zad", "(Ljava/lang/Exception;)V", "GetZad_Ljava_lang_Exception_Handler")]
		public unsafe override void Zad(Java.Lang.Exception p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("zad.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zae", "(Lcom/google/android/gms/common/api/internal/zaaa;Z)V", "GetZae_Lcom_google_android_gms_common_api_internal_zaaa_ZHandler")]
		public unsafe override void Zae(Zaaa p0, bool p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members.InstanceMethods.InvokeAbstractVoidMethod("zae.(Lcom/google/android/gms/common/api/internal/zaaa;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zaf", "(Lcom/google/android/gms/common/api/internal/zabl;)V", "GetZaf_Lcom_google_android_gms_common_api_internal_zabl_Handler")]
		public unsafe override void Zaf(Zabl p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("zaf.(Lcom/google/android/gms/common/api/internal/zabl;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/zal", DoNotGenerateAcw = true)]
	public sealed class Zal : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/zal", typeof(Zal));

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

		internal Zal(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Iterable;)V", "")]
		public unsafe Zal(IIterable p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Iterable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Iterable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("zaa", "()Ljava/util/Set;", "")]
		public unsafe ICollection<ApiKey> Zaa()
		{
			return JavaSet<ApiKey>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zaa.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zab", "()Lcom/google/android/gms/tasks/Task;", "")]
		public unsafe Android.Gms.Tasks.Task Zab()
		{
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zab.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zac", "(Lcom/google/android/gms/common/api/internal/ApiKey;Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;)V", "")]
		public unsafe void Zac(ApiKey p0, ConnectionResult p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("zac.(Lcom/google/android/gms/common/api/internal/ApiKey;Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
}
namespace Android.Gms.Common.Apis
{
	public static class IPendingResultExtensions
	{
		public static TaskAwaiter<IResult> GetAwaiter(this PendingResult pr)
		{
			AwaitableResultCallback<IResult> awaitableResultCallback = new AwaitableResultCallback<IResult>();
			pr.SetResultCallback(awaitableResultCallback);
			return awaitableResultCallback.GetAwaiter();
		}
	}
	[Register("com/google/android/gms/common/api/GoogleApiClient", DoNotGenerateAcw = true)]
	public abstract class GoogleApiClient : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/GoogleApiClient$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApiClient$Builder", typeof(Builder));

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

			public Builder AddConnectionCallbacks(Action<Bundle> connectedCallback, Action<int> connectionSuspendedCallback)
			{
				return AddConnectionCallbacks(new GoogleApiClientConnectionCallbacksImpl(connectedCallback, connectionSuspendedCallback));
			}

			public Builder AddConnectionCallbacks(Action<Bundle> connectedCallback)
			{
				return AddConnectionCallbacks(new GoogleApiClientConnectionCallbacksImpl(connectedCallback, null));
			}

			public Builder AddConnectionCallbacks(Action connectedCallback)
			{
				return AddConnectionCallbacks(new GoogleApiClientConnectionCallbacksImpl(delegate
				{
					connectedCallback();
				}, null));
			}

			public Builder AddOnConnectionFailedListener(Action<ConnectionResult> callback)
			{
				return AddOnConnectionFailedListener(new GoogleApiClientOnConnectionFailedListenerImpl(callback));
			}

			public Builder EnableAutoManage(FragmentActivity fragmentActivity, int clientId, Action<ConnectionResult> unresolvedConnectionFailedHandler)
			{
				return EnableAutoManage(fragmentActivity, clientId, new GoogleApiClientOnConnectionFailedListenerImpl(unresolvedConnectionFailedHandler));
			}

			public Builder EnableAutoManage(FragmentActivity fragmentActivity, Action<ConnectionResult> unresolvedConnectionFailedHandler)
			{
				return EnableAutoManage(fragmentActivity, new GoogleApiClientOnConnectionFailedListenerImpl(unresolvedConnectionFailedHandler));
			}

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;)V", "")]
			public unsafe Builder(Context p0)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", "")]
			public unsafe Builder(Context p0, IConnectionCallbacks p1, IOnConnectionFailedListener p2)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
					ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("addApi", "(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder AddApi(Api p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addApi.(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("addApi", "(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions$HasOptions;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions.HasOptions" })]
			public unsafe Builder AddApi(Api p0, Api.IApiOptionsHasOptions p1)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addApi.(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions$HasOptions;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("addApiIfAvailable", "(Lcom/google/android/gms/common/api/Api;[Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			[JavaTypeParameters(new string[] { "T extends com.google.android.gms.common.api.Api.ApiOptions.NotRequiredOptions" })]
			public unsafe Builder AddApiIfAvailable(Api p0, params Scope[] p1)
			{
				IntPtr intPtr = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addApiIfAvailable.(Lcom/google/android/gms/common/api/Api;[Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr, p1);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("addApiIfAvailable", "(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions$HasOptions;[Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions.HasOptions" })]
			public unsafe Builder AddApiIfAvailable(Api p0, Api.IApiOptionsHasOptions p1, params Scope[] p2)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addApiIfAvailable.(Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions$HasOptions;[Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}

			[Register("addConnectionCallbacks", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder AddConnectionCallbacks(IConnectionCallbacks p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addConnectionCallbacks.(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("addOnConnectionFailedListener", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder AddOnConnectionFailedListener(IOnConnectionFailedListener p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnConnectionFailedListener.(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("addScope", "(Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder AddScope(Scope p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addScope.(Lcom/google/android/gms/common/api/Scope;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("addScopeNames", "([Ljava/lang/String;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder AddScopeNames(string[] p0)
			{
				IntPtr intPtr = JNIEnv.NewArray(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addScopeNames.([Ljava/lang/String;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (p0 != null)
					{
						JNIEnv.CopyArray(intPtr, p0);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(p0);
				}
			}

			[Register("build", "()Lcom/google/android/gms/common/api/GoogleApiClient;", "")]
			public unsafe GoogleApiClient Build()
			{
				return Java.Lang.Object.GetObject<GoogleApiClient>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/gms/common/api/GoogleApiClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("enableAutoManage", "(Landroidx/fragment/app/FragmentActivity;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder EnableAutoManage(FragmentActivity p0, IOnConnectionFailedListener p1)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(((Java.Lang.Object)(object)p0)?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableAutoManage.(Landroidx/fragment/app/FragmentActivity;Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}

			[Register("enableAutoManage", "(Landroidx/fragment/app/FragmentActivity;ILcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder EnableAutoManage(FragmentActivity p0, int p1, IOnConnectionFailedListener p2)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(((Java.Lang.Object)(object)p0)?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(p1);
					ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("enableAutoManage.(Landroidx/fragment/app/FragmentActivity;ILcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}

			[Register("setAccountName", "(Ljava/lang/String;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder SetAccountName(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAccountName.(Ljava/lang/String;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setGravityForPopups", "(I)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder SetGravityForPopups(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setGravityForPopups.(I)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setHandler", "(Landroid/os/Handler;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder SetHandler(Handler p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHandler.(Landroid/os/Handler;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setViewForPopups", "(Landroid/view/View;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder SetViewForPopups(View p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setViewForPopups.(Landroid/view/View;)Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("useDefaultAccount", "()Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", "")]
			public unsafe Builder UseDefaultAccount()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("useDefaultAccount.()Lcom/google/android/gms/common/api/GoogleApiClient$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks", "", "Android.Gms.Common.Apis.GoogleApiClient/IConnectionCallbacksInvoker")]
		public interface IConnectionCallbacks : Android.Gms.Common.Api.Internal.IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks", DoNotGenerateAcw = true)]
		internal class IConnectionCallbacksInvoker : Java.Lang.Object, IConnectionCallbacks, Android.Gms.Common.Api.Internal.IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks", typeof(IConnectionCallbacksInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onConnected_Landroid_os_Bundle_;

			private IntPtr id_onConnected_Landroid_os_Bundle_;

			private static Delegate cb_onConnectionSuspended_I;

			private IntPtr id_onConnectionSuspended_I;

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

			public static IConnectionCallbacks GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IConnectionCallbacks>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.GoogleApiClient.ConnectionCallbacks'.");
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

			public IConnectionCallbacksInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnConnected_Landroid_os_Bundle_Handler()
			{
				if ((object)cb_onConnected_Landroid_os_Bundle_ == null)
				{
					cb_onConnected_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnected_Landroid_os_Bundle_));
				}
				return cb_onConnected_Landroid_os_Bundle_;
			}

			private static void n_OnConnected_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IConnectionCallbacks connectionCallbacks = Java.Lang.Object.GetObject<IConnectionCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
				connectionCallbacks.OnConnected(p);
			}

			public unsafe void OnConnected(Bundle p0)
			{
				if (id_onConnected_Landroid_os_Bundle_ == IntPtr.Zero)
				{
					id_onConnected_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "onConnected", "(Landroid/os/Bundle;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onConnected_Landroid_os_Bundle_, ptr);
			}

			private static Delegate GetOnConnectionSuspended_IHandler()
			{
				if ((object)cb_onConnectionSuspended_I == null)
				{
					cb_onConnectionSuspended_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnConnectionSuspended_I));
				}
				return cb_onConnectionSuspended_I;
			}

			private static void n_OnConnectionSuspended_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Java.Lang.Object.GetObject<IConnectionCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnConnectionSuspended(p0);
			}

			public unsafe void OnConnectionSuspended(int p0)
			{
				if (id_onConnectionSuspended_I == IntPtr.Zero)
				{
					id_onConnectionSuspended_I = JNIEnv.GetMethodID(class_ref, "onConnectionSuspended", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				JNIEnv.CallVoidMethod(base.Handle, id_onConnectionSuspended_I, ptr);
			}
		}

		[Register("com/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener", "", "Android.Gms.Common.Apis.GoogleApiClient/IOnConnectionFailedListenerInvoker")]
		public interface IOnConnectionFailedListener : Android.Gms.Common.Api.Internal.IOnConnectionFailedListener, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener", DoNotGenerateAcw = true)]
		internal class IOnConnectionFailedListenerInvoker : Java.Lang.Object, IOnConnectionFailedListener, Android.Gms.Common.Api.Internal.IOnConnectionFailedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener", typeof(IOnConnectionFailedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;

			private IntPtr id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;

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

			public static IOnConnectionFailedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnConnectionFailedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.GoogleApiClient.OnConnectionFailedListener'.");
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

			public IOnConnectionFailedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_Handler()
			{
				if ((object)cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ == null)
				{
					cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_));
				}
				return cb_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_;
			}

			private static void n_OnConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IOnConnectionFailedListener onConnectionFailedListener = Java.Lang.Object.GetObject<IOnConnectionFailedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConnectionResult p = Java.Lang.Object.GetObject<ConnectionResult>(native_p0, JniHandleOwnership.DoNotTransfer);
				onConnectionFailedListener.OnConnectionFailed(p);
			}

			public unsafe void OnConnectionFailed(ConnectionResult p0)
			{
				if (id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ == IntPtr.Zero)
				{
					id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_ = JNIEnv.GetMethodID(class_ref, "onConnectionFailed", "(Lcom/google/android/gms/common/ConnectionResult;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onConnectionFailed_Lcom_google_android_gms_common_ConnectionResult_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApiClient", typeof(GoogleApiClient));

		private static Delegate cb_getContext;

		private static Delegate cb_isConnected;

		private static Delegate cb_isConnecting;

		private static Delegate cb_getLooper;

		private static Delegate cb_blockingConnect;

		private static Delegate cb_blockingConnect_JLjava_util_concurrent_TimeUnit_;

		private static Delegate cb_clearDefaultAccountAndReconnect;

		private static Delegate cb_connect;

		private static Delegate cb_connect_I;

		private static Delegate cb_disconnect;

		private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

		private static Delegate cb_enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;

		private static Delegate cb_execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;

		private static Delegate cb_getClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_;

		private static Delegate cb_getConnectionResult_Lcom_google_android_gms_common_api_Api_;

		private static Delegate cb_hasApi_Lcom_google_android_gms_common_api_Api_;

		private static Delegate cb_hasConnectedApi_Lcom_google_android_gms_common_api_Api_;

		private static Delegate cb_isConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;

		private static Delegate cb_isConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;

		private static Delegate cb_maybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_;

		private static Delegate cb_maybeSignOut;

		private static Delegate cb_reconnect;

		private static Delegate cb_registerConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;

		private static Delegate cb_registerConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;

		private static Delegate cb_registerListener_Ljava_lang_Object_;

		private static Delegate cb_stopAutoManage_Landroidx_fragment_app_FragmentActivity_;

		private static Delegate cb_unregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;

		private static Delegate cb_unregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;

		private static Delegate cb_zao_Lcom_google_android_gms_common_api_internal_zacv_;

		private static Delegate cb_zap_Lcom_google_android_gms_common_api_internal_zacv_;

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

		public unsafe static ICollection<GoogleApiClient> AllClients
		{
			[Register("getAllClients", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<GoogleApiClient>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getAllClients.()Ljava/util/Set;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public abstract bool IsConnected
		{
			[Register("isConnected", "()Z", "GetIsConnectedHandler")]
			get;
		}

		public abstract bool IsConnecting
		{
			[Register("isConnecting", "()Z", "GetIsConnectingHandler")]
			get;
		}

		public unsafe virtual Looper Looper
		{
			[Register("getLooper", "()Landroid/os/Looper;", "GetGetLooperHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Looper>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLooper.()Landroid/os/Looper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GoogleApiClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GoogleApiClient()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
		}

		private static Delegate GetIsConnectedHandler()
		{
			if ((object)cb_isConnected == null)
			{
				cb_isConnected = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsConnected));
			}
			return cb_isConnected;
		}

		private static bool n_IsConnected(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnected;
		}

		private static Delegate GetIsConnectingHandler()
		{
			if ((object)cb_isConnecting == null)
			{
				cb_isConnecting = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsConnecting));
			}
			return cb_isConnecting;
		}

		private static bool n_IsConnecting(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnecting;
		}

		private static Delegate GetGetLooperHandler()
		{
			if ((object)cb_getLooper == null)
			{
				cb_getLooper = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLooper));
			}
			return cb_getLooper;
		}

		private static IntPtr n_GetLooper(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Looper);
		}

		private static Delegate GetBlockingConnectHandler()
		{
			if ((object)cb_blockingConnect == null)
			{
				cb_blockingConnect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_BlockingConnect));
			}
			return cb_blockingConnect;
		}

		private static IntPtr n_BlockingConnect(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BlockingConnect());
		}

		[Register("blockingConnect", "()Lcom/google/android/gms/common/ConnectionResult;", "GetBlockingConnectHandler")]
		public abstract ConnectionResult BlockingConnect();

		private static Delegate GetBlockingConnect_JLjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_blockingConnect_JLjava_util_concurrent_TimeUnit_ == null)
			{
				cb_blockingConnect_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_BlockingConnect_JLjava_util_concurrent_TimeUnit_));
			}
			return cb_blockingConnect_JLjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_BlockingConnect_JLjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit p1 = Java.Lang.Object.GetObject<TimeUnit>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.BlockingConnect(p0, p1));
		}

		[Register("blockingConnect", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/ConnectionResult;", "GetBlockingConnect_JLjava_util_concurrent_TimeUnit_Handler")]
		public abstract ConnectionResult BlockingConnect(long p0, TimeUnit p1);

		private static Delegate GetClearDefaultAccountAndReconnectHandler()
		{
			if ((object)cb_clearDefaultAccountAndReconnect == null)
			{
				cb_clearDefaultAccountAndReconnect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ClearDefaultAccountAndReconnect));
			}
			return cb_clearDefaultAccountAndReconnect;
		}

		private static IntPtr n_ClearDefaultAccountAndReconnect(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearDefaultAccountAndReconnect());
		}

		[Register("clearDefaultAccountAndReconnect", "()Lcom/google/android/gms/common/api/PendingResult;", "GetClearDefaultAccountAndReconnectHandler")]
		public abstract PendingResult ClearDefaultAccountAndReconnect();

		private static Delegate GetConnectHandler()
		{
			if ((object)cb_connect == null)
			{
				cb_connect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Connect));
			}
			return cb_connect;
		}

		private static void n_Connect(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect();
		}

		[Register("connect", "()V", "GetConnectHandler")]
		public abstract void Connect();

		private static Delegate GetConnect_IHandler()
		{
			if ((object)cb_connect_I == null)
			{
				cb_connect_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Connect_I));
			}
			return cb_connect_I;
		}

		private static void n_Connect_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect(p0);
		}

		[Register("connect", "(I)V", "GetConnect_IHandler")]
		public unsafe virtual void Connect(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(I)V", this, ptr);
		}

		private static Delegate GetDisconnectHandler()
		{
			if ((object)cb_disconnect == null)
			{
				cb_disconnect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Disconnect));
			}
			return cb_disconnect;
		}

		private static void n_Disconnect(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Disconnect();
		}

		[Register("disconnect", "()V", "GetDisconnectHandler")]
		public abstract void Disconnect();

		private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
			{
				cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
			}
			return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
		}

		private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			FileDescriptor p2 = Java.Lang.Object.GetObject<FileDescriptor>(native_p1, JniHandleOwnership.DoNotTransfer);
			PrintWriter p3 = Java.Lang.Object.GetObject<PrintWriter>(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			googleApiClient.Dump(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
			}
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public abstract void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3);

		[Register("dumpAll", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "")]
		public unsafe static void DumpAll(string p0, FileDescriptor p1, PrintWriter p2, string[] p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("dumpAll.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p3 != null)
				{
					JNIEnv.CopyArray(intPtr2, p3);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetEnqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler()
		{
			if ((object)cb_enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ == null)
			{
				cb_enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_));
			}
			return cb_enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;
		}

		private static IntPtr n_Enqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.Enqueue(p));
		}

		[Register("enqueue", "(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", "GetEnqueue_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "R extends com.google.android.gms.common.api.Result", "T extends com.google.android.gms.common.api.internal.BaseImplementation.ApiMethodImpl<R, A>" })]
		public unsafe virtual Java.Lang.Object Enqueue(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("enqueue.(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetExecute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler()
		{
			if ((object)cb_execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ == null)
			{
				cb_execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_));
			}
			return cb_execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;
		}

		private static IntPtr n_Execute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.Execute(p));
		}

		[Register("execute", "(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", "GetExecute_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "T extends com.google.android.gms.common.api.internal.BaseImplementation.ApiMethodImpl<? extends com.google.android.gms.common.api.Result, A>" })]
		public unsafe virtual Java.Lang.Object Execute(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("execute.(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_Handler()
		{
			if ((object)cb_getClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_ == null)
			{
				cb_getClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_));
			}
			return cb_getClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_;
		}

		private static IntPtr n_GetClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Api.AnyClientKey p = Java.Lang.Object.GetObject<Api.AnyClientKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.GetClient(p));
		}

		[Register("getClient", "(Lcom/google/android/gms/common/api/Api$AnyClientKey;)Lcom/google/android/gms/common/api/Api$Client;", "GetGetClient_Lcom_google_android_gms_common_api_Api_AnyClientKey_Handler")]
		[JavaTypeParameters(new string[] { "C extends com.google.android.gms.common.api.Api.Client" })]
		public unsafe virtual Java.Lang.Object GetClient(Api.AnyClientKey p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getClient.(Lcom/google/android/gms/common/api/Api$AnyClientKey;)Lcom/google/android/gms/common/api/Api$Client;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetConnectionResult_Lcom_google_android_gms_common_api_Api_Handler()
		{
			if ((object)cb_getConnectionResult_Lcom_google_android_gms_common_api_Api_ == null)
			{
				cb_getConnectionResult_Lcom_google_android_gms_common_api_Api_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetConnectionResult_Lcom_google_android_gms_common_api_Api_));
			}
			return cb_getConnectionResult_Lcom_google_android_gms_common_api_Api_;
		}

		private static IntPtr n_GetConnectionResult_Lcom_google_android_gms_common_api_Api_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Api p = Java.Lang.Object.GetObject<Api>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.GetConnectionResult(p));
		}

		[Register("getConnectionResult", "(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/ConnectionResult;", "GetGetConnectionResult_Lcom_google_android_gms_common_api_Api_Handler")]
		public abstract ConnectionResult GetConnectionResult(Api p0);

		private static Delegate GetHasApi_Lcom_google_android_gms_common_api_Api_Handler()
		{
			if ((object)cb_hasApi_Lcom_google_android_gms_common_api_Api_ == null)
			{
				cb_hasApi_Lcom_google_android_gms_common_api_Api_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HasApi_Lcom_google_android_gms_common_api_Api_));
			}
			return cb_hasApi_Lcom_google_android_gms_common_api_Api_;
		}

		private static bool n_HasApi_Lcom_google_android_gms_common_api_Api_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Api p = Java.Lang.Object.GetObject<Api>(native_p0, JniHandleOwnership.DoNotTransfer);
			return googleApiClient.HasApi(p);
		}

		[Register("hasApi", "(Lcom/google/android/gms/common/api/Api;)Z", "GetHasApi_Lcom_google_android_gms_common_api_Api_Handler")]
		public unsafe virtual bool HasApi(Api p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasApi.(Lcom/google/android/gms/common/api/Api;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetHasConnectedApi_Lcom_google_android_gms_common_api_Api_Handler()
		{
			if ((object)cb_hasConnectedApi_Lcom_google_android_gms_common_api_Api_ == null)
			{
				cb_hasConnectedApi_Lcom_google_android_gms_common_api_Api_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HasConnectedApi_Lcom_google_android_gms_common_api_Api_));
			}
			return cb_hasConnectedApi_Lcom_google_android_gms_common_api_Api_;
		}

		private static bool n_HasConnectedApi_Lcom_google_android_gms_common_api_Api_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Api p = Java.Lang.Object.GetObject<Api>(native_p0, JniHandleOwnership.DoNotTransfer);
			return googleApiClient.HasConnectedApi(p);
		}

		[Register("hasConnectedApi", "(Lcom/google/android/gms/common/api/Api;)Z", "GetHasConnectedApi_Lcom_google_android_gms_common_api_Api_Handler")]
		public abstract bool HasConnectedApi(Api p0);

		private static Delegate GetIsConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler()
		{
			if ((object)cb_isConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ == null)
			{
				cb_isConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_));
			}
			return cb_isConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;
		}

		private static bool n_IsConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConnectionCallbacks p = Java.Lang.Object.GetObject<IConnectionCallbacks>(native_p0, JniHandleOwnership.DoNotTransfer);
			return googleApiClient.IsConnectionCallbacksRegistered(p);
		}

		[Register("isConnectionCallbacksRegistered", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z", "GetIsConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public abstract bool IsConnectionCallbacksRegistered(IConnectionCallbacks p0);

		private static Delegate GetIsConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler()
		{
			if ((object)cb_isConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ == null)
			{
				cb_isConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_));
			}
			return cb_isConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;
		}

		private static bool n_IsConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnConnectionFailedListener p = Java.Lang.Object.GetObject<IOnConnectionFailedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return googleApiClient.IsConnectionFailedListenerRegistered(p);
		}

		[Register("isConnectionFailedListenerRegistered", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Z", "GetIsConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public abstract bool IsConnectionFailedListenerRegistered(IOnConnectionFailedListener p0);

		private static Delegate GetMaybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_Handler()
		{
			if ((object)cb_maybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_ == null)
			{
				cb_maybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_MaybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_));
			}
			return cb_maybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_;
		}

		private static bool n_MaybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISignInConnectionListener p = Java.Lang.Object.GetObject<ISignInConnectionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return googleApiClient.MaybeSignIn(p);
		}

		[Register("maybeSignIn", "(Lcom/google/android/gms/common/api/internal/SignInConnectionListener;)Z", "GetMaybeSignIn_Lcom_google_android_gms_common_api_internal_SignInConnectionListener_Handler")]
		public unsafe virtual bool MaybeSignIn(ISignInConnectionListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("maybeSignIn.(Lcom/google/android/gms/common/api/internal/SignInConnectionListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetMaybeSignOutHandler()
		{
			if ((object)cb_maybeSignOut == null)
			{
				cb_maybeSignOut = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_MaybeSignOut));
			}
			return cb_maybeSignOut;
		}

		private static void n_MaybeSignOut(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaybeSignOut();
		}

		[Register("maybeSignOut", "()V", "GetMaybeSignOutHandler")]
		public unsafe virtual void MaybeSignOut()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("maybeSignOut.()V", this, null);
		}

		private static Delegate GetReconnectHandler()
		{
			if ((object)cb_reconnect == null)
			{
				cb_reconnect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reconnect));
			}
			return cb_reconnect;
		}

		private static void n_Reconnect(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reconnect();
		}

		[Register("reconnect", "()V", "GetReconnectHandler")]
		public abstract void Reconnect();

		private static Delegate GetRegisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler()
		{
			if ((object)cb_registerConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ == null)
			{
				cb_registerConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_));
			}
			return cb_registerConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;
		}

		private static void n_RegisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConnectionCallbacks p = Java.Lang.Object.GetObject<IConnectionCallbacks>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.RegisterConnectionCallbacks(p);
		}

		[Register("registerConnectionCallbacks", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", "GetRegisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public abstract void RegisterConnectionCallbacks(IConnectionCallbacks p0);

		private static Delegate GetRegisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler()
		{
			if ((object)cb_registerConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ == null)
			{
				cb_registerConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_));
			}
			return cb_registerConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;
		}

		private static void n_RegisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnConnectionFailedListener p = Java.Lang.Object.GetObject<IOnConnectionFailedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.RegisterConnectionFailedListener(p);
		}

		[Register("registerConnectionFailedListener", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", "GetRegisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public abstract void RegisterConnectionFailedListener(IOnConnectionFailedListener p0);

		private static Delegate GetRegisterListener_Ljava_lang_Object_Handler()
		{
			if ((object)cb_registerListener_Ljava_lang_Object_ == null)
			{
				cb_registerListener_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RegisterListener_Ljava_lang_Object_));
			}
			return cb_registerListener_Ljava_lang_Object_;
		}

		private static IntPtr n_RegisterListener_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiClient.RegisterListener(p));
		}

		[Register("registerListener", "(Ljava/lang/Object;)Lcom/google/android/gms/common/api/internal/ListenerHolder;", "GetRegisterListener_Ljava_lang_Object_Handler")]
		[JavaTypeParameters(new string[] { "L" })]
		public unsafe virtual ListenerHolder RegisterListener(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ListenerHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerListener.(Ljava/lang/Object;)Lcom/google/android/gms/common/api/internal/ListenerHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetStopAutoManage_Landroidx_fragment_app_FragmentActivity_Handler()
		{
			if ((object)cb_stopAutoManage_Landroidx_fragment_app_FragmentActivity_ == null)
			{
				cb_stopAutoManage_Landroidx_fragment_app_FragmentActivity_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StopAutoManage_Landroidx_fragment_app_FragmentActivity_));
			}
			return cb_stopAutoManage_Landroidx_fragment_app_FragmentActivity_;
		}

		private static void n_StopAutoManage_Landroidx_fragment_app_FragmentActivity_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FragmentActivity p = Java.Lang.Object.GetObject<FragmentActivity>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.StopAutoManage(p);
		}

		[Register("stopAutoManage", "(Landroidx/fragment/app/FragmentActivity;)V", "GetStopAutoManage_Landroidx_fragment_app_FragmentActivity_Handler")]
		public abstract void StopAutoManage(FragmentActivity p0);

		private static Delegate GetUnregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler()
		{
			if ((object)cb_unregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ == null)
			{
				cb_unregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_));
			}
			return cb_unregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_;
		}

		private static void n_UnregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConnectionCallbacks p = Java.Lang.Object.GetObject<IConnectionCallbacks>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.UnregisterConnectionCallbacks(p);
		}

		[Register("unregisterConnectionCallbacks", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", "GetUnregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public abstract void UnregisterConnectionCallbacks(IConnectionCallbacks p0);

		private static Delegate GetUnregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler()
		{
			if ((object)cb_unregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ == null)
			{
				cb_unregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_));
			}
			return cb_unregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_;
		}

		private static void n_UnregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnConnectionFailedListener p = Java.Lang.Object.GetObject<IOnConnectionFailedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.UnregisterConnectionFailedListener(p);
		}

		[Register("unregisterConnectionFailedListener", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", "GetUnregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public abstract void UnregisterConnectionFailedListener(IOnConnectionFailedListener p0);

		private static Delegate GetZao_Lcom_google_android_gms_common_api_internal_zacv_Handler()
		{
			if ((object)cb_zao_Lcom_google_android_gms_common_api_internal_zacv_ == null)
			{
				cb_zao_Lcom_google_android_gms_common_api_internal_zacv_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Zao_Lcom_google_android_gms_common_api_internal_zacv_));
			}
			return cb_zao_Lcom_google_android_gms_common_api_internal_zacv_;
		}

		private static void n_Zao_Lcom_google_android_gms_common_api_internal_zacv_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Zacv p = Java.Lang.Object.GetObject<Zacv>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.Zao(p);
		}

		[Register("zao", "(Lcom/google/android/gms/common/api/internal/zacv;)V", "GetZao_Lcom_google_android_gms_common_api_internal_zacv_Handler")]
		public unsafe virtual void Zao(Zacv p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("zao.(Lcom/google/android/gms/common/api/internal/zacv;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetZap_Lcom_google_android_gms_common_api_internal_zacv_Handler()
		{
			if ((object)cb_zap_Lcom_google_android_gms_common_api_internal_zacv_ == null)
			{
				cb_zap_Lcom_google_android_gms_common_api_internal_zacv_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Zap_Lcom_google_android_gms_common_api_internal_zacv_));
			}
			return cb_zap_Lcom_google_android_gms_common_api_internal_zacv_;
		}

		private static void n_Zap_Lcom_google_android_gms_common_api_internal_zacv_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApiClient googleApiClient = Java.Lang.Object.GetObject<GoogleApiClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Zacv p = Java.Lang.Object.GetObject<Zacv>(native_p0, JniHandleOwnership.DoNotTransfer);
			googleApiClient.Zap(p);
		}

		[Register("zap", "(Lcom/google/android/gms/common/api/internal/zacv;)V", "GetZap_Lcom_google_android_gms_common_api_internal_zacv_Handler")]
		public unsafe virtual void Zap(Zacv p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("zap.(Lcom/google/android/gms/common/api/internal/zacv;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	internal class GoogleApiClientConnectionCallbacksImpl : Java.Lang.Object, GoogleApiClient.IConnectionCallbacks, IConnectionCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<Bundle> OnConnectedHandler { get; private set; }

		public Action<int> OnConnectionSuspendedHandler { get; private set; }

		public GoogleApiClientConnectionCallbacksImpl(Action<Bundle> onConnectedHandler, Action<int> onConnectionSuspendedHandler)
		{
			OnConnectedHandler = onConnectedHandler;
			OnConnectionSuspendedHandler = onConnectionSuspendedHandler;
		}

		public void OnConnected(Bundle bundle)
		{
			OnConnectedHandler?.Invoke(bundle);
		}

		public void OnConnectionSuspended(int cause)
		{
			OnConnectionSuspendedHandler?.Invoke(cause);
		}
	}
	internal class GoogleApiClientOnConnectionFailedListenerImpl : Java.Lang.Object, GoogleApiClient.IOnConnectionFailedListener, IOnConnectionFailedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action<ConnectionResult> OnConnectionFailedHandler { get; private set; }

		public GoogleApiClientOnConnectionFailedListenerImpl(Action<ConnectionResult> handler)
		{
			OnConnectionFailedHandler = handler;
		}

		public void OnConnectionFailed(ConnectionResult result)
		{
			OnConnectionFailedHandler?.Invoke(result);
		}
	}
	[Register("com/google/android/gms/common/api/Api", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
	public sealed class Api : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/Api$AbstractClientBuilder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "T extends com.google.android.gms.common.api.Api.Client", "O" })]
		public abstract class AbstractClientBuilder : BaseClientBuilder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$AbstractClientBuilder", typeof(AbstractClientBuilder));

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

			protected AbstractClientBuilder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe AbstractClientBuilder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		[Register("com/google/android/gms/common/api/Api$AbstractClientBuilder", DoNotGenerateAcw = true)]
		internal class AbstractClientBuilderInvoker : AbstractClientBuilder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$AbstractClientBuilder", typeof(AbstractClientBuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public AbstractClientBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/google/android/gms/common/api/Api$AnyClient", "", "Android.Gms.Common.Apis.Api/IAnyClientInvoker")]
		public interface IAnyClient : IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/google/android/gms/common/api/Api$AnyClient", DoNotGenerateAcw = true)]
		internal class IAnyClientInvoker : Java.Lang.Object, IAnyClient, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$AnyClient", typeof(IAnyClientInvoker));

			private IntPtr class_ref;

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

			public static IAnyClient GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IAnyClient>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.Api.AnyClient'.");
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

			public IAnyClientInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}
		}

		[Register("com/google/android/gms/common/api/Api$AnyClientKey", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "C extends com.google.android.gms.common.api.Api.AnyClient" })]
		public class AnyClientKey : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$AnyClientKey", typeof(AnyClientKey));

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

			protected AnyClientKey(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe AnyClientKey()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		[Register("com/google/android/gms/common/api/Api$ApiOptions$HasOptions", "", "Android.Gms.Common.Apis.Api/IApiOptionsHasOptionsInvoker")]
		public interface IApiOptionsHasOptions : IApiOptions, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/google/android/gms/common/api/Api$ApiOptions$HasOptions", DoNotGenerateAcw = true)]
		internal class IApiOptionsHasOptionsInvoker : Java.Lang.Object, IApiOptionsHasOptions, IApiOptions, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$ApiOptions$HasOptions", typeof(IApiOptionsHasOptionsInvoker));

			private IntPtr class_ref;

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

			public static IApiOptionsHasOptions GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IApiOptionsHasOptions>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.Api.ApiOptions.HasOptions'.");
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

			public IApiOptionsHasOptionsInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}
		}

		[Register("com/google/android/gms/common/api/Api$ApiOptions", "", "Android.Gms.Common.Apis.Api/IApiOptionsInvoker")]
		public interface IApiOptions : IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/google/android/gms/common/api/Api$ApiOptions", DoNotGenerateAcw = true)]
		internal class IApiOptionsInvoker : Java.Lang.Object, IApiOptions, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$ApiOptions", typeof(IApiOptionsInvoker));

			private IntPtr class_ref;

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

			public static IApiOptions GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IApiOptions>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.Api.ApiOptions'.");
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

			public IApiOptionsInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}
		}

		[Register("com/google/android/gms/common/api/Api$BaseClientBuilder", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "T extends com.google.android.gms.common.api.Api.AnyClient", "O" })]
		public abstract class BaseClientBuilder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$BaseClientBuilder", typeof(BaseClientBuilder));

			private static Delegate cb_getPriority;

			private static Delegate cb_getImpliedScopes_Ljava_lang_Object_;

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

			public unsafe virtual int Priority
			{
				[Register("getPriority", "()I", "GetGetPriorityHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getPriority.()I", this, null);
				}
			}

			protected BaseClientBuilder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe BaseClientBuilder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
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
				return Java.Lang.Object.GetObject<BaseClientBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Priority;
			}

			private static Delegate GetGetImpliedScopes_Ljava_lang_Object_Handler()
			{
				if ((object)cb_getImpliedScopes_Ljava_lang_Object_ == null)
				{
					cb_getImpliedScopes_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetImpliedScopes_Ljava_lang_Object_));
				}
				return cb_getImpliedScopes_Ljava_lang_Object_;
			}

			private static IntPtr n_GetImpliedScopes_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				BaseClientBuilder baseClientBuilder = Java.Lang.Object.GetObject<BaseClientBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JavaList<Scope>.ToLocalJniHandle(baseClientBuilder.GetImpliedScopes(p));
			}

			[Register("getImpliedScopes", "(Ljava/lang/Object;)Ljava/util/List;", "GetGetImpliedScopes_Ljava_lang_Object_Handler")]
			public unsafe virtual IList<Scope> GetImpliedScopes(Java.Lang.Object p0)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return JavaList<Scope>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getImpliedScopes.(Ljava/lang/Object;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
				}
			}
		}

		[Register("com/google/android/gms/common/api/Api$BaseClientBuilder", DoNotGenerateAcw = true)]
		internal class BaseClientBuilderInvoker : BaseClientBuilder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$BaseClientBuilder", typeof(BaseClientBuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BaseClientBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/google/android/gms/common/api/Api$Client", "", "Android.Gms.Common.Apis.Api/IClientInvoker")]
		public interface IClient : IAnyClient, IJavaObject, IDisposable, IJavaPeerable
		{
			string EndpointPackageName
			{
				[Register("getEndpointPackageName", "()Ljava/lang/String;", "GetGetEndpointPackageNameHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			bool IsConnected
			{
				[Register("isConnected", "()Z", "GetIsConnectedHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			bool IsConnecting
			{
				[Register("isConnecting", "()Z", "GetIsConnectingHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			string LastDisconnectMessage
			{
				[Register("getLastDisconnectMessage", "()Ljava/lang/String;", "GetGetLastDisconnectMessageHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			int MinApkVersion
			{
				[Register("getMinApkVersion", "()I", "GetGetMinApkVersionHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			ICollection<Scope> ScopesForConnectionlessNonSignIn
			{
				[Register("getScopesForConnectionlessNonSignIn", "()Ljava/util/Set;", "GetGetScopesForConnectionlessNonSignInHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			IBinder ServiceBrokerBinder
			{
				[Register("getServiceBrokerBinder", "()Landroid/os/IBinder;", "GetGetServiceBrokerBinderHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			Intent SignInIntent
			{
				[Register("getSignInIntent", "()Landroid/content/Intent;", "GetGetSignInIntentHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
				get;
			}

			[Register("disconnect", "()V", "GetDisconnectHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			void Disconnect();

			[Register("disconnect", "(Ljava/lang/String;)V", "GetDisconnect_Ljava_lang_String_Handler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			void Disconnect(string p0);

			[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3);

			[Register("getAvailableFeatures", "()[Lcom/google/android/gms/common/Feature;", "GetGetAvailableFeaturesHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			Feature[] GetAvailableFeatures();

			[Register("getRemoteService", "(Lcom/google/android/gms/common/internal/IAccountAccessor;Ljava/util/Set;)V", "GetGetRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_Handler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			void GetRemoteService(IAccountAccessor p0, ICollection<Scope> p1);

			[Register("getRequiredFeatures", "()[Lcom/google/android/gms/common/Feature;", "GetGetRequiredFeaturesHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			Feature[] GetRequiredFeatures();

			[Register("providesSignIn", "()Z", "GetProvidesSignInHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			bool ProvidesSignIn();

			[Register("requiresAccount", "()Z", "GetRequiresAccountHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			bool RequiresAccount();

			[Register("requiresGooglePlayServices", "()Z", "GetRequiresGooglePlayServicesHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			bool RequiresGooglePlayServices();

			[Register("requiresSignIn", "()Z", "GetRequiresSignInHandler:Android.Gms.Common.Apis.Api/IClientInvoker, Xamarin.GooglePlayServices.Base")]
			bool RequiresSignIn();
		}

		[Register("com/google/android/gms/common/api/Api$Client", DoNotGenerateAcw = true)]
		internal class IClientInvoker : Java.Lang.Object, IClient, IAnyClient, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$Client", typeof(IClientInvoker));

			private IntPtr class_ref;

			private static Delegate cb_getEndpointPackageName;

			private IntPtr id_getEndpointPackageName;

			private static Delegate cb_isConnected;

			private IntPtr id_isConnected;

			private static Delegate cb_isConnecting;

			private IntPtr id_isConnecting;

			private static Delegate cb_getLastDisconnectMessage;

			private IntPtr id_getLastDisconnectMessage;

			private static Delegate cb_getMinApkVersion;

			private IntPtr id_getMinApkVersion;

			private static Delegate cb_getScopesForConnectionlessNonSignIn;

			private IntPtr id_getScopesForConnectionlessNonSignIn;

			private static Delegate cb_getServiceBrokerBinder;

			private IntPtr id_getServiceBrokerBinder;

			private static Delegate cb_getSignInIntent;

			private IntPtr id_getSignInIntent;

			private static Delegate cb_disconnect;

			private IntPtr id_disconnect;

			private static Delegate cb_disconnect_Ljava_lang_String_;

			private IntPtr id_disconnect_Ljava_lang_String_;

			private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

			private IntPtr id_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

			private static Delegate cb_getAvailableFeatures;

			private IntPtr id_getAvailableFeatures;

			private static Delegate cb_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_;

			private IntPtr id_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_;

			private static Delegate cb_getRequiredFeatures;

			private IntPtr id_getRequiredFeatures;

			private static Delegate cb_providesSignIn;

			private IntPtr id_providesSignIn;

			private static Delegate cb_requiresAccount;

			private IntPtr id_requiresAccount;

			private static Delegate cb_requiresGooglePlayServices;

			private IntPtr id_requiresGooglePlayServices;

			private static Delegate cb_requiresSignIn;

			private IntPtr id_requiresSignIn;

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

			public string EndpointPackageName
			{
				get
				{
					if (id_getEndpointPackageName == IntPtr.Zero)
					{
						id_getEndpointPackageName = JNIEnv.GetMethodID(class_ref, "getEndpointPackageName", "()Ljava/lang/String;");
					}
					return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getEndpointPackageName), JniHandleOwnership.TransferLocalRef);
				}
			}

			public bool IsConnected
			{
				get
				{
					if (id_isConnected == IntPtr.Zero)
					{
						id_isConnected = JNIEnv.GetMethodID(class_ref, "isConnected", "()Z");
					}
					return JNIEnv.CallBooleanMethod(base.Handle, id_isConnected);
				}
			}

			public bool IsConnecting
			{
				get
				{
					if (id_isConnecting == IntPtr.Zero)
					{
						id_isConnecting = JNIEnv.GetMethodID(class_ref, "isConnecting", "()Z");
					}
					return JNIEnv.CallBooleanMethod(base.Handle, id_isConnecting);
				}
			}

			public string LastDisconnectMessage
			{
				get
				{
					if (id_getLastDisconnectMessage == IntPtr.Zero)
					{
						id_getLastDisconnectMessage = JNIEnv.GetMethodID(class_ref, "getLastDisconnectMessage", "()Ljava/lang/String;");
					}
					return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getLastDisconnectMessage), JniHandleOwnership.TransferLocalRef);
				}
			}

			public int MinApkVersion
			{
				get
				{
					if (id_getMinApkVersion == IntPtr.Zero)
					{
						id_getMinApkVersion = JNIEnv.GetMethodID(class_ref, "getMinApkVersion", "()I");
					}
					return JNIEnv.CallIntMethod(base.Handle, id_getMinApkVersion);
				}
			}

			public ICollection<Scope> ScopesForConnectionlessNonSignIn
			{
				get
				{
					if (id_getScopesForConnectionlessNonSignIn == IntPtr.Zero)
					{
						id_getScopesForConnectionlessNonSignIn = JNIEnv.GetMethodID(class_ref, "getScopesForConnectionlessNonSignIn", "()Ljava/util/Set;");
					}
					return JavaSet<Scope>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getScopesForConnectionlessNonSignIn), JniHandleOwnership.TransferLocalRef);
				}
			}

			public IBinder ServiceBrokerBinder
			{
				get
				{
					if (id_getServiceBrokerBinder == IntPtr.Zero)
					{
						id_getServiceBrokerBinder = JNIEnv.GetMethodID(class_ref, "getServiceBrokerBinder", "()Landroid/os/IBinder;");
					}
					return Java.Lang.Object.GetObject<IBinder>(JNIEnv.CallObjectMethod(base.Handle, id_getServiceBrokerBinder), JniHandleOwnership.TransferLocalRef);
				}
			}

			public Intent SignInIntent
			{
				get
				{
					if (id_getSignInIntent == IntPtr.Zero)
					{
						id_getSignInIntent = JNIEnv.GetMethodID(class_ref, "getSignInIntent", "()Landroid/content/Intent;");
					}
					return Java.Lang.Object.GetObject<Intent>(JNIEnv.CallObjectMethod(base.Handle, id_getSignInIntent), JniHandleOwnership.TransferLocalRef);
				}
			}

			public static IClient GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IClient>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.Api.Client'.");
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

			public IClientInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGetEndpointPackageNameHandler()
			{
				if ((object)cb_getEndpointPackageName == null)
				{
					cb_getEndpointPackageName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEndpointPackageName));
				}
				return cb_getEndpointPackageName;
			}

			private static IntPtr n_GetEndpointPackageName(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndpointPackageName);
			}

			private static Delegate GetIsConnectedHandler()
			{
				if ((object)cb_isConnected == null)
				{
					cb_isConnected = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsConnected));
				}
				return cb_isConnected;
			}

			private static bool n_IsConnected(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnected;
			}

			private static Delegate GetIsConnectingHandler()
			{
				if ((object)cb_isConnecting == null)
				{
					cb_isConnecting = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsConnecting));
				}
				return cb_isConnecting;
			}

			private static bool n_IsConnecting(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnecting;
			}

			private static Delegate GetGetLastDisconnectMessageHandler()
			{
				if ((object)cb_getLastDisconnectMessage == null)
				{
					cb_getLastDisconnectMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastDisconnectMessage));
				}
				return cb_getLastDisconnectMessage;
			}

			private static IntPtr n_GetLastDisconnectMessage(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastDisconnectMessage);
			}

			private static Delegate GetGetMinApkVersionHandler()
			{
				if ((object)cb_getMinApkVersion == null)
				{
					cb_getMinApkVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinApkVersion));
				}
				return cb_getMinApkVersion;
			}

			private static int n_GetMinApkVersion(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinApkVersion;
			}

			private static Delegate GetGetScopesForConnectionlessNonSignInHandler()
			{
				if ((object)cb_getScopesForConnectionlessNonSignIn == null)
				{
					cb_getScopesForConnectionlessNonSignIn = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetScopesForConnectionlessNonSignIn));
				}
				return cb_getScopesForConnectionlessNonSignIn;
			}

			private static IntPtr n_GetScopesForConnectionlessNonSignIn(IntPtr jnienv, IntPtr native__this)
			{
				return JavaSet<Scope>.ToLocalJniHandle(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScopesForConnectionlessNonSignIn);
			}

			private static Delegate GetGetServiceBrokerBinderHandler()
			{
				if ((object)cb_getServiceBrokerBinder == null)
				{
					cb_getServiceBrokerBinder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetServiceBrokerBinder));
				}
				return cb_getServiceBrokerBinder;
			}

			private static IntPtr n_GetServiceBrokerBinder(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ServiceBrokerBinder);
			}

			private static Delegate GetGetSignInIntentHandler()
			{
				if ((object)cb_getSignInIntent == null)
				{
					cb_getSignInIntent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSignInIntent));
				}
				return cb_getSignInIntent;
			}

			private static IntPtr n_GetSignInIntent(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SignInIntent);
			}

			private static Delegate GetDisconnectHandler()
			{
				if ((object)cb_disconnect == null)
				{
					cb_disconnect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Disconnect));
				}
				return cb_disconnect;
			}

			private static void n_Disconnect(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Disconnect();
			}

			public void Disconnect()
			{
				if (id_disconnect == IntPtr.Zero)
				{
					id_disconnect = JNIEnv.GetMethodID(class_ref, "disconnect", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_disconnect);
			}

			private static Delegate GetDisconnect_Ljava_lang_String_Handler()
			{
				if ((object)cb_disconnect_Ljava_lang_String_ == null)
				{
					cb_disconnect_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Disconnect_Ljava_lang_String_));
				}
				return cb_disconnect_Ljava_lang_String_;
			}

			private static void n_Disconnect_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IClient client = Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				client.Disconnect(p);
			}

			public unsafe void Disconnect(string p0)
			{
				if (id_disconnect_Ljava_lang_String_ == IntPtr.Zero)
				{
					id_disconnect_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "disconnect", "(Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(p0);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_disconnect_Ljava_lang_String_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}

			private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
			{
				if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
				{
					cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
				}
				return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
			}

			private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				IClient client = Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				FileDescriptor p2 = Java.Lang.Object.GetObject<FileDescriptor>(native_p1, JniHandleOwnership.DoNotTransfer);
				PrintWriter p3 = Java.Lang.Object.GetObject<PrintWriter>(native_p2, JniHandleOwnership.DoNotTransfer);
				string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
				client.Dump(p, p2, p3, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p3);
				}
			}

			public unsafe void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3)
			{
				if (id_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == IntPtr.Zero)
				{
					id_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p3);
				JValue* ptr = stackalloc JValue[4];
				*ptr = new JValue(intPtr);
				ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JValue(intPtr2);
				JNIEnv.CallVoidMethod(base.Handle, id_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
				if (p3 != null)
				{
					JNIEnv.CopyArray(intPtr2, p3);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			private static Delegate GetGetAvailableFeaturesHandler()
			{
				if ((object)cb_getAvailableFeatures == null)
				{
					cb_getAvailableFeatures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAvailableFeatures));
				}
				return cb_getAvailableFeatures;
			}

			private static IntPtr n_GetAvailableFeatures(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewArray(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAvailableFeatures());
			}

			public Feature[] GetAvailableFeatures()
			{
				if (id_getAvailableFeatures == IntPtr.Zero)
				{
					id_getAvailableFeatures = JNIEnv.GetMethodID(class_ref, "getAvailableFeatures", "()[Lcom/google/android/gms/common/Feature;");
				}
				return (Feature[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_getAvailableFeatures), JniHandleOwnership.TransferLocalRef, typeof(Feature));
			}

			private static Delegate GetGetRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_Handler()
			{
				if ((object)cb_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_ == null)
				{
					cb_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_GetRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_));
				}
				return cb_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_;
			}

			private static void n_GetRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				IClient client = Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IAccountAccessor p = Java.Lang.Object.GetObject<IAccountAccessor>(native_p0, JniHandleOwnership.DoNotTransfer);
				ICollection<Scope> p2 = JavaSet<Scope>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
				client.GetRemoteService(p, p2);
			}

			public unsafe void GetRemoteService(IAccountAccessor p0, ICollection<Scope> p1)
			{
				if (id_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_ == IntPtr.Zero)
				{
					id_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_ = JNIEnv.GetMethodID(class_ref, "getRemoteService", "(Lcom/google/android/gms/common/internal/IAccountAccessor;Ljava/util/Set;)V");
				}
				IntPtr intPtr = JavaSet<Scope>.ToLocalJniHandle(p1);
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_getRemoteService_Lcom_google_android_gms_common_internal_IAccountAccessor_Ljava_util_Set_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}

			private static Delegate GetGetRequiredFeaturesHandler()
			{
				if ((object)cb_getRequiredFeatures == null)
				{
					cb_getRequiredFeatures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRequiredFeatures));
				}
				return cb_getRequiredFeatures;
			}

			private static IntPtr n_GetRequiredFeatures(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.NewArray(Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRequiredFeatures());
			}

			public Feature[] GetRequiredFeatures()
			{
				if (id_getRequiredFeatures == IntPtr.Zero)
				{
					id_getRequiredFeatures = JNIEnv.GetMethodID(class_ref, "getRequiredFeatures", "()[Lcom/google/android/gms/common/Feature;");
				}
				return (Feature[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_getRequiredFeatures), JniHandleOwnership.TransferLocalRef, typeof(Feature));
			}

			private static Delegate GetProvidesSignInHandler()
			{
				if ((object)cb_providesSignIn == null)
				{
					cb_providesSignIn = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ProvidesSignIn));
				}
				return cb_providesSignIn;
			}

			private static bool n_ProvidesSignIn(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProvidesSignIn();
			}

			public bool ProvidesSignIn()
			{
				if (id_providesSignIn == IntPtr.Zero)
				{
					id_providesSignIn = JNIEnv.GetMethodID(class_ref, "providesSignIn", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_providesSignIn);
			}

			private static Delegate GetRequiresAccountHandler()
			{
				if ((object)cb_requiresAccount == null)
				{
					cb_requiresAccount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_RequiresAccount));
				}
				return cb_requiresAccount;
			}

			private static bool n_RequiresAccount(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequiresAccount();
			}

			public bool RequiresAccount()
			{
				if (id_requiresAccount == IntPtr.Zero)
				{
					id_requiresAccount = JNIEnv.GetMethodID(class_ref, "requiresAccount", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_requiresAccount);
			}

			private static Delegate GetRequiresGooglePlayServicesHandler()
			{
				if ((object)cb_requiresGooglePlayServices == null)
				{
					cb_requiresGooglePlayServices = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_RequiresGooglePlayServices));
				}
				return cb_requiresGooglePlayServices;
			}

			private static bool n_RequiresGooglePlayServices(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequiresGooglePlayServices();
			}

			public bool RequiresGooglePlayServices()
			{
				if (id_requiresGooglePlayServices == IntPtr.Zero)
				{
					id_requiresGooglePlayServices = JNIEnv.GetMethodID(class_ref, "requiresGooglePlayServices", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_requiresGooglePlayServices);
			}

			private static Delegate GetRequiresSignInHandler()
			{
				if ((object)cb_requiresSignIn == null)
				{
					cb_requiresSignIn = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_RequiresSignIn));
				}
				return cb_requiresSignIn;
			}

			private static bool n_RequiresSignIn(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequiresSignIn();
			}

			public bool RequiresSignIn()
			{
				if (id_requiresSignIn == IntPtr.Zero)
				{
					id_requiresSignIn = JNIEnv.GetMethodID(class_ref, "requiresSignIn", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_requiresSignIn);
			}
		}

		[Register("com/google/android/gms/common/api/Api$ClientKey", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "C extends com.google.android.gms.common.api.Api.Client" })]
		public sealed class ClientKey : AnyClientKey
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api$ClientKey", typeof(ClientKey));

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

			internal ClientKey(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe ClientKey()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Api", typeof(Api));

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

		internal Api(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/google/android/gms/common/api/Api$AbstractClientBuilder;Lcom/google/android/gms/common/api/Api$ClientKey;)V", "")]
		public unsafe Api(string p0, AbstractClientBuilder p1, ClientKey p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/google/android/gms/common/api/Api$AbstractClientBuilder;Lcom/google/android/gms/common/api/Api$ClientKey;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/google/android/gms/common/api/Api$AbstractClientBuilder;Lcom/google/android/gms/common/api/Api$ClientKey;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("zaa", "()Lcom/google/android/gms/common/api/Api$BaseClientBuilder;", "")]
		public unsafe BaseClientBuilder Zaa()
		{
			return Java.Lang.Object.GetObject<BaseClientBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zaa.()Lcom/google/android/gms/common/api/Api$BaseClientBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zab", "()Lcom/google/android/gms/common/api/Api$AbstractClientBuilder;", "")]
		public unsafe AbstractClientBuilder Zab()
		{
			return Java.Lang.Object.GetObject<AbstractClientBuilder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zab.()Lcom/google/android/gms/common/api/Api$AbstractClientBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zac", "()Lcom/google/android/gms/common/api/Api$AnyClientKey;", "")]
		public unsafe AnyClientKey Zac()
		{
			return Java.Lang.Object.GetObject<AnyClientKey>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zac.()Lcom/google/android/gms/common/api/Api$AnyClientKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zad", "()Ljava/lang/String;", "")]
		public unsafe string Zad()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zad.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/common/api/GoogleApi", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
	public abstract class GoogleApi : Java.Lang.Object, IHasApiKey, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/google/android/gms/common/api/GoogleApi$Settings", DoNotGenerateAcw = true)]
		public class Settings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApi$Settings", typeof(Settings));

			[Register("DEFAULT_SETTINGS")]
			public static Settings DefaultSettings => Java.Lang.Object.GetObject<Settings>(_members.StaticFields.GetObjectValue("DEFAULT_SETTINGS.Lcom/google/android/gms/common/api/GoogleApi$Settings;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("zaa")]
			public IStatusExceptionMapper Zaa
			{
				get
				{
					return Java.Lang.Object.GetObject<IStatusExceptionMapper>(_members.InstanceFields.GetObjectValue("zaa.Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("zaa.Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("zab")]
			public Looper Zab
			{
				get
				{
					return Java.Lang.Object.GetObject<Looper>(_members.InstanceFields.GetObjectValue("zab.Landroid/os/Looper;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("zab.Landroid/os/Looper;", this, new JniObjectReference(jobject));
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

			protected Settings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApi", typeof(GoogleApi));

		private static Delegate cb_getApiOptions;

		private static Delegate cb_getApplicationContext;

		private static Delegate cb_getContextAttributionTag;

		private static Delegate cb_getContextFeatureId;

		private static Delegate cb_getLooper;

		private static Delegate cb_asGoogleApiClient;

		private static Delegate cb_disconnectService;

		private static Delegate cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_;

		private static Delegate cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;

		private static Delegate cb_doRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_;

		private static Delegate cb_doRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;

		private static Delegate cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_;

		private static Delegate cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_;

		private static Delegate cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_;

		private static Delegate cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I;

		private static Delegate cb_doWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_;

		private static Delegate cb_doWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;

		private static Delegate cb_registerListener_Ljava_lang_Object_Ljava_lang_String_;

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

		public unsafe ApiKey ApiKey
		{
			[Register("getApiKey", "()Lcom/google/android/gms/common/api/internal/ApiKey;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ApiKey>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getApiKey.()Lcom/google/android/gms/common/api/internal/ApiKey;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Java.Lang.Object ApiOptions
		{
			[Register("getApiOptions", "()Lcom/google/android/gms/common/api/Api$ApiOptions;", "GetGetApiOptionsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApiOptions.()Lcom/google/android/gms/common/api/Api$ApiOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Context ApplicationContext
		{
			[Register("getApplicationContext", "()Landroid/content/Context;", "GetGetApplicationContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual string ContextAttributionTag
		{
			[Register("getContextAttributionTag", "()Ljava/lang/String;", "GetGetContextAttributionTagHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getContextAttributionTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual string ContextFeatureId
		{
			[Register("getContextFeatureId", "()Ljava/lang/String;", "GetGetContextFeatureIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getContextFeatureId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Looper Looper
		{
			[Register("getLooper", "()Landroid/os/Looper;", "GetGetLooperHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Looper>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLooper.()Landroid/os/Looper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GoogleApi(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", "")]
		public unsafe GoogleApi(Activity p0, Api p1, Java.Lang.Object p2, Settings p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register(".ctor", "(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", "")]
		public unsafe GoogleApi(Activity p0, Api p1, Java.Lang.Object p2, IStatusExceptionMapper p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Landroid/os/Looper;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", "")]
		public unsafe GoogleApi(Context p0, Api p1, Java.Lang.Object p2, Looper p3, IStatusExceptionMapper p4)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue((p4 == null) ? IntPtr.Zero : ((Java.Lang.Object)p4).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Landroid/os/Looper;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Landroid/os/Looper;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
				GC.KeepAlive(p4);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", "")]
		public unsafe GoogleApi(Context p0, Api p1, Java.Lang.Object p2, Settings p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/GoogleApi$Settings;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", "")]
		public unsafe GoogleApi(Context p0, Api p1, Java.Lang.Object p2, IStatusExceptionMapper p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/gms/common/api/Api;Lcom/google/android/gms/common/api/Api$ApiOptions;Lcom/google/android/gms/common/api/internal/StatusExceptionMapper;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetGetApiOptionsHandler()
		{
			if ((object)cb_getApiOptions == null)
			{
				cb_getApiOptions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApiOptions));
			}
			return cb_getApiOptions;
		}

		private static IntPtr n_GetApiOptions(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApiOptions);
		}

		private static Delegate GetGetApplicationContextHandler()
		{
			if ((object)cb_getApplicationContext == null)
			{
				cb_getApplicationContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplicationContext));
			}
			return cb_getApplicationContext;
		}

		private static IntPtr n_GetApplicationContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationContext);
		}

		private static Delegate GetGetContextAttributionTagHandler()
		{
			if ((object)cb_getContextAttributionTag == null)
			{
				cb_getContextAttributionTag = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContextAttributionTag));
			}
			return cb_getContextAttributionTag;
		}

		private static IntPtr n_GetContextAttributionTag(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContextAttributionTag);
		}

		private static Delegate GetGetContextFeatureIdHandler()
		{
			if ((object)cb_getContextFeatureId == null)
			{
				cb_getContextFeatureId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContextFeatureId));
			}
			return cb_getContextFeatureId;
		}

		private static IntPtr n_GetContextFeatureId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContextFeatureId);
		}

		private static Delegate GetGetLooperHandler()
		{
			if ((object)cb_getLooper == null)
			{
				cb_getLooper = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLooper));
			}
			return cb_getLooper;
		}

		private static IntPtr n_GetLooper(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Looper);
		}

		private static Delegate GetAsGoogleApiClientHandler()
		{
			if ((object)cb_asGoogleApiClient == null)
			{
				cb_asGoogleApiClient = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AsGoogleApiClient));
			}
			return cb_asGoogleApiClient;
		}

		private static IntPtr n_AsGoogleApiClient(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsGoogleApiClient());
		}

		[Register("asGoogleApiClient", "()Lcom/google/android/gms/common/api/GoogleApiClient;", "GetAsGoogleApiClientHandler")]
		public unsafe virtual GoogleApiClient AsGoogleApiClient()
		{
			return Java.Lang.Object.GetObject<GoogleApiClient>(_members.InstanceMethods.InvokeVirtualObjectMethod("asGoogleApiClient.()Lcom/google/android/gms/common/api/GoogleApiClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDisconnectServiceHandler()
		{
			if ((object)cb_disconnectService == null)
			{
				cb_disconnectService = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DisconnectService));
			}
			return cb_disconnectService;
		}

		private static IntPtr n_DisconnectService(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisconnectService());
		}

		[Register("disconnectService", "()Lcom/google/android/gms/tasks/Task;", "GetDisconnectServiceHandler")]
		protected unsafe virtual Android.Gms.Tasks.Task DisconnectService()
		{
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("disconnectService.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDoBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler()
		{
			if ((object)cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_ == null)
			{
				cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_));
			}
			return cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_;
		}

		private static IntPtr n_DoBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TaskApiCall p = Java.Lang.Object.GetObject<TaskApiCall>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoBestEffortWrite(p));
		}

		[Register("doBestEffortWrite", "(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", "GetDoBestEffortWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler")]
		[JavaTypeParameters(new string[] { "TResult", "A extends com.google.android.gms.common.api.Api.AnyClient" })]
		public unsafe virtual Android.Gms.Tasks.Task DoBestEffortWrite(TaskApiCall p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doBestEffortWrite.(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler()
		{
			if ((object)cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ == null)
			{
				cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_));
			}
			return cb_doBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;
		}

		private static IntPtr n_DoBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoBestEffortWrite(p));
		}

		[Register("doBestEffortWrite", "(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", "GetDoBestEffortWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "T extends com.google.android.gms.common.api.internal.BaseImplementation.ApiMethodImpl<? extends com.google.android.gms.common.api.Result, A>" })]
		public unsafe virtual Java.Lang.Object DoBestEffortWrite(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("doBestEffortWrite.(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler()
		{
			if ((object)cb_doRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_ == null)
			{
				cb_doRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_));
			}
			return cb_doRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_;
		}

		private static IntPtr n_DoRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TaskApiCall p = Java.Lang.Object.GetObject<TaskApiCall>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoRead(p));
		}

		[Register("doRead", "(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", "GetDoRead_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler")]
		[JavaTypeParameters(new string[] { "TResult", "A extends com.google.android.gms.common.api.Api.AnyClient" })]
		public unsafe virtual Android.Gms.Tasks.Task DoRead(TaskApiCall p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doRead.(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler()
		{
			if ((object)cb_doRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ == null)
			{
				cb_doRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_));
			}
			return cb_doRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;
		}

		private static IntPtr n_DoRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoRead(p));
		}

		[Register("doRead", "(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", "GetDoRead_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "T extends com.google.android.gms.common.api.internal.BaseImplementation.ApiMethodImpl<? extends com.google.android.gms.common.api.Result, A>" })]
		public unsafe virtual Java.Lang.Object DoRead(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("doRead.(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_Handler()
		{
			if ((object)cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_ == null)
			{
				cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_));
			}
			return cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_;
		}

		private static IntPtr n_DoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RegistrationMethods p = Java.Lang.Object.GetObject<RegistrationMethods>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoRegisterEventListener(p));
		}

		[Register("doRegisterEventListener", "(Lcom/google/android/gms/common/api/internal/RegistrationMethods;)Lcom/google/android/gms/tasks/Task;", "GetDoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegistrationMethods_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient" })]
		public unsafe virtual Android.Gms.Tasks.Task DoRegisterEventListener(RegistrationMethods p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doRegisterEventListener.(Lcom/google/android/gms/common/api/internal/RegistrationMethods;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_Handler()
		{
			if ((object)cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_ == null)
			{
				cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_DoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_));
			}
			return cb_doRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_;
		}

		private static IntPtr n_DoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoRegisterEventListener(p, p2));
		}

		[Register("doRegisterEventListener", "(Lcom/google/android/gms/common/api/internal/RegisterListenerMethod;Lcom/google/android/gms/common/api/internal/UnregisterListenerMethod;)Lcom/google/android/gms/tasks/Task;", "GetDoRegisterEventListener_Lcom_google_android_gms_common_api_internal_RegisterListenerMethod_Lcom_google_android_gms_common_api_internal_UnregisterListenerMethod_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "T extends com.google.android.gms.common.api.internal.RegisterListenerMethod<A, ?>", "U extends com.google.android.gms.common.api.internal.UnregisterListenerMethod<A, ?>" })]
		public unsafe virtual Android.Gms.Tasks.Task DoRegisterEventListener(Java.Lang.Object p0, Java.Lang.Object p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doRegisterEventListener.(Lcom/google/android/gms/common/api/internal/RegisterListenerMethod;Lcom/google/android/gms/common/api/internal/UnregisterListenerMethod;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetDoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_Handler()
		{
			if ((object)cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_ == null)
			{
				cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_));
			}
			return cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_;
		}

		private static IntPtr n_DoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ListenerHolder.ListenerKey p = Java.Lang.Object.GetObject<ListenerHolder.ListenerKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoUnregisterEventListener(p));
		}

		[Register("doUnregisterEventListener", "(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;)Lcom/google/android/gms/tasks/Task;", "GetDoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_Handler")]
		public unsafe virtual Android.Gms.Tasks.Task DoUnregisterEventListener(ListenerHolder.ListenerKey p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doUnregisterEventListener.(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_IHandler()
		{
			if ((object)cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I == null)
			{
				cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_DoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I));
			}
			return cb_doUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I;
		}

		private static IntPtr n_DoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ListenerHolder.ListenerKey p2 = Java.Lang.Object.GetObject<ListenerHolder.ListenerKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoUnregisterEventListener(p2, p1));
		}

		[Register("doUnregisterEventListener", "(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;I)Lcom/google/android/gms/tasks/Task;", "GetDoUnregisterEventListener_Lcom_google_android_gms_common_api_internal_ListenerHolder_ListenerKey_IHandler")]
		public unsafe virtual Android.Gms.Tasks.Task DoUnregisterEventListener(ListenerHolder.ListenerKey p0, int p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doUnregisterEventListener.(Lcom/google/android/gms/common/api/internal/ListenerHolder$ListenerKey;I)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler()
		{
			if ((object)cb_doWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_ == null)
			{
				cb_doWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_));
			}
			return cb_doWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_;
		}

		private static IntPtr n_DoWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TaskApiCall p = Java.Lang.Object.GetObject<TaskApiCall>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoWrite(p));
		}

		[Register("doWrite", "(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", "GetDoWrite_Lcom_google_android_gms_common_api_internal_TaskApiCall_Handler")]
		[JavaTypeParameters(new string[] { "TResult", "A extends com.google.android.gms.common.api.Api.AnyClient" })]
		public unsafe virtual Android.Gms.Tasks.Task DoWrite(TaskApiCall p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("doWrite.(Lcom/google/android/gms/common/api/internal/TaskApiCall;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetDoWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler()
		{
			if ((object)cb_doWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ == null)
			{
				cb_doWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DoWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_));
			}
			return cb_doWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_;
		}

		private static IntPtr n_DoWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.DoWrite(p));
		}

		[Register("doWrite", "(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", "GetDoWrite_Lcom_google_android_gms_common_api_internal_BaseImplementation_ApiMethodImpl_Handler")]
		[JavaTypeParameters(new string[] { "A extends com.google.android.gms.common.api.Api.AnyClient", "T extends com.google.android.gms.common.api.internal.BaseImplementation.ApiMethodImpl<? extends com.google.android.gms.common.api.Result, A>" })]
		public unsafe virtual Java.Lang.Object DoWrite(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("doWrite.(Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;)Lcom/google/android/gms/common/api/internal/BaseImplementation$ApiMethodImpl;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetRegisterListener_Ljava_lang_Object_Ljava_lang_String_Handler()
		{
			if ((object)cb_registerListener_Ljava_lang_Object_Ljava_lang_String_ == null)
			{
				cb_registerListener_Ljava_lang_Object_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RegisterListener_Ljava_lang_Object_Ljava_lang_String_));
			}
			return cb_registerListener_Ljava_lang_Object_Ljava_lang_String_;
		}

		private static IntPtr n_RegisterListener_Ljava_lang_Object_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			GoogleApi googleApi = Java.Lang.Object.GetObject<GoogleApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApi.RegisterListener(p, p2));
		}

		[Register("registerListener", "(Ljava/lang/Object;Ljava/lang/String;)Lcom/google/android/gms/common/api/internal/ListenerHolder;", "GetRegisterListener_Ljava_lang_Object_Ljava_lang_String_Handler")]
		[JavaTypeParameters(new string[] { "L" })]
		public unsafe virtual ListenerHolder RegisterListener(Java.Lang.Object p0, string p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<ListenerHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerListener.(Ljava/lang/Object;Ljava/lang/String;)Lcom/google/android/gms/common/api/internal/ListenerHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
			}
		}

		[Register("zaa", "(Landroid/os/Looper;Lcom/google/android/gms/common/api/internal/zabl;)Lcom/google/android/gms/common/api/Api$Client;", "")]
		public unsafe Api.IClient Zaa(Looper p0, Zabl p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Api.IClient>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("zaa.(Landroid/os/Looper;Lcom/google/android/gms/common/api/internal/zabl;)Lcom/google/android/gms/common/api/Api$Client;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("zab", "()I", "")]
		public unsafe int Zab()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("zab.()I", this, null);
		}
	}
	[Register("com/google/android/gms/common/api/GoogleApi", DoNotGenerateAcw = true)]
	internal class GoogleApiInvoker : GoogleApi, IHasApiKey, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApi", typeof(GoogleApiInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public GoogleApiInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/gms/common/api/GoogleApiClient", DoNotGenerateAcw = true)]
	internal class GoogleApiClientInvoker : GoogleApiClient
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/GoogleApiClient", typeof(GoogleApiClientInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsConnected
		{
			[Register("isConnected", "()Z", "GetIsConnectedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isConnected.()Z", this, null);
			}
		}

		public unsafe override bool IsConnecting
		{
			[Register("isConnecting", "()Z", "GetIsConnectingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isConnecting.()Z", this, null);
			}
		}

		public GoogleApiClientInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("blockingConnect", "()Lcom/google/android/gms/common/ConnectionResult;", "GetBlockingConnectHandler")]
		public unsafe override ConnectionResult BlockingConnect()
		{
			return Java.Lang.Object.GetObject<ConnectionResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("blockingConnect.()Lcom/google/android/gms/common/ConnectionResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("blockingConnect", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/ConnectionResult;", "GetBlockingConnect_JLjava_util_concurrent_TimeUnit_Handler")]
		public unsafe override ConnectionResult BlockingConnect(long p0, TimeUnit p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ConnectionResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("blockingConnect.(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/ConnectionResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
			}
		}

		[Register("clearDefaultAccountAndReconnect", "()Lcom/google/android/gms/common/api/PendingResult;", "GetClearDefaultAccountAndReconnectHandler")]
		public unsafe override PendingResult ClearDefaultAccountAndReconnect()
		{
			return Java.Lang.Object.GetObject<PendingResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("clearDefaultAccountAndReconnect.()Lcom/google/android/gms/common/api/PendingResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("connect", "()V", "GetConnectHandler")]
		public unsafe override void Connect()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("connect.()V", this, null);
		}

		[Register("disconnect", "()V", "GetDisconnectHandler")]
		public unsafe override void Disconnect()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("disconnect.()V", this, null);
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public unsafe override void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p3 != null)
				{
					JNIEnv.CopyArray(intPtr2, p3);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register("getConnectionResult", "(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/ConnectionResult;", "GetGetConnectionResult_Lcom_google_android_gms_common_api_Api_Handler")]
		public unsafe override ConnectionResult GetConnectionResult(Api p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ConnectionResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConnectionResult.(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/ConnectionResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("hasConnectedApi", "(Lcom/google/android/gms/common/api/Api;)Z", "GetHasConnectedApi_Lcom_google_android_gms_common_api_Api_Handler")]
		public unsafe override bool HasConnectedApi(Api p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasConnectedApi.(Lcom/google/android/gms/common/api/Api;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("isConnectionCallbacksRegistered", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z", "GetIsConnectionCallbacksRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public unsafe override bool IsConnectionCallbacksRegistered(IConnectionCallbacks p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isConnectionCallbacksRegistered.(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("isConnectionFailedListenerRegistered", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Z", "GetIsConnectionFailedListenerRegistered_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public unsafe override bool IsConnectionFailedListenerRegistered(IOnConnectionFailedListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isConnectionFailedListenerRegistered.(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("reconnect", "()V", "GetReconnectHandler")]
		public unsafe override void Reconnect()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("reconnect.()V", this, null);
		}

		[Register("registerConnectionCallbacks", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", "GetRegisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public unsafe override void RegisterConnectionCallbacks(IConnectionCallbacks p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("registerConnectionCallbacks.(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("registerConnectionFailedListener", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", "GetRegisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public unsafe override void RegisterConnectionFailedListener(IOnConnectionFailedListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("registerConnectionFailedListener.(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("stopAutoManage", "(Landroidx/fragment/app/FragmentActivity;)V", "GetStopAutoManage_Landroidx_fragment_app_FragmentActivity_Handler")]
		public unsafe override void StopAutoManage(FragmentActivity p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(((Java.Lang.Object)(object)p0)?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("stopAutoManage.(Landroidx/fragment/app/FragmentActivity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("unregisterConnectionCallbacks", "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", "GetUnregisterConnectionCallbacks_Lcom_google_android_gms_common_api_GoogleApiClient_ConnectionCallbacks_Handler")]
		public unsafe override void UnregisterConnectionCallbacks(IConnectionCallbacks p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterConnectionCallbacks.(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("unregisterConnectionFailedListener", "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", "GetUnregisterConnectionFailedListener_Lcom_google_android_gms_common_api_GoogleApiClient_OnConnectionFailedListener_Handler")]
		public unsafe override void UnregisterConnectionFailedListener(IOnConnectionFailedListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterConnectionFailedListener.(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/HasApiKey", "", "Android.Gms.Common.Apis.IHasApiKeyInvoker")]
	[JavaTypeParameters(new string[] { "O extends com.google.android.gms.common.api.Api.ApiOptions" })]
	public interface IHasApiKey : IJavaObject, IDisposable, IJavaPeerable
	{
		ApiKey ApiKey
		{
			[Register("getApiKey", "()Lcom/google/android/gms/common/api/internal/ApiKey;", "GetGetApiKeyHandler:Android.Gms.Common.Apis.IHasApiKeyInvoker, Xamarin.GooglePlayServices.Base")]
			get;
		}
	}
	[Register("com/google/android/gms/common/api/HasApiKey", DoNotGenerateAcw = true)]
	internal class IHasApiKeyInvoker : Java.Lang.Object, IHasApiKey, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/HasApiKey", typeof(IHasApiKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getApiKey;

		private IntPtr id_getApiKey;

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

		public ApiKey ApiKey
		{
			get
			{
				if (id_getApiKey == IntPtr.Zero)
				{
					id_getApiKey = JNIEnv.GetMethodID(class_ref, "getApiKey", "()Lcom/google/android/gms/common/api/internal/ApiKey;");
				}
				return Java.Lang.Object.GetObject<ApiKey>(JNIEnv.CallObjectMethod(base.Handle, id_getApiKey), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IHasApiKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHasApiKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.HasApiKey'.");
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

		public IHasApiKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetApiKeyHandler()
		{
			if ((object)cb_getApiKey == null)
			{
				cb_getApiKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApiKey));
			}
			return cb_getApiKey;
		}

		private static IntPtr n_GetApiKey(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHasApiKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApiKey);
		}
	}
	[Register("com/google/android/gms/common/api/PendingResult", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result" })]
	public abstract class PendingResult : Java.Lang.Object
	{
		[Register("com/google/android/gms/common/api/PendingResult$StatusListener", "", "Android.Gms.Common.Apis.PendingResult/IStatusListenerInvoker")]
		public interface IStatusListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onComplete", "(Lcom/google/android/gms/common/api/Status;)V", "GetOnComplete_Lcom_google_android_gms_common_api_Status_Handler:Android.Gms.Common.Apis.PendingResult/IStatusListenerInvoker, Xamarin.GooglePlayServices.Base")]
			void OnComplete(Statuses p0);
		}

		[Register("com/google/android/gms/common/api/PendingResult$StatusListener", DoNotGenerateAcw = true)]
		internal class IStatusListenerInvoker : Java.Lang.Object, IStatusListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/PendingResult$StatusListener", typeof(IStatusListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onComplete_Lcom_google_android_gms_common_api_Status_;

			private IntPtr id_onComplete_Lcom_google_android_gms_common_api_Status_;

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

			public static IStatusListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IStatusListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.PendingResult.StatusListener'.");
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

			public IStatusListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnComplete_Lcom_google_android_gms_common_api_Status_Handler()
			{
				if ((object)cb_onComplete_Lcom_google_android_gms_common_api_Status_ == null)
				{
					cb_onComplete_Lcom_google_android_gms_common_api_Status_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnComplete_Lcom_google_android_gms_common_api_Status_));
				}
				return cb_onComplete_Lcom_google_android_gms_common_api_Status_;
			}

			private static void n_OnComplete_Lcom_google_android_gms_common_api_Status_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IStatusListener statusListener = Java.Lang.Object.GetObject<IStatusListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Statuses p = Java.Lang.Object.GetObject<Statuses>(native_p0, JniHandleOwnership.DoNotTransfer);
				statusListener.OnComplete(p);
			}

			public unsafe void OnComplete(Statuses p0)
			{
				if (id_onComplete_Lcom_google_android_gms_common_api_Status_ == IntPtr.Zero)
				{
					id_onComplete_Lcom_google_android_gms_common_api_Status_ = JNIEnv.GetMethodID(class_ref, "onComplete", "(Lcom/google/android/gms/common/api/Status;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onComplete_Lcom_google_android_gms_common_api_Status_, ptr);
			}
		}

		public class StatusEventArgs : EventArgs
		{
			private Statuses p0;

			public StatusEventArgs(Statuses p0)
			{
				this.p0 = p0;
			}
		}

		[Register("mono/com/google/android/gms/common/api/PendingResult_StatusListenerImplementor")]
		internal sealed class IStatusListenerImplementor : Java.Lang.Object, IStatusListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<StatusEventArgs> Handler;

			public IStatusListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/common/api/PendingResult_StatusListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnComplete(Statuses p0)
			{
				Handler?.Invoke(sender, new StatusEventArgs(p0));
			}

			internal static bool __IsEmpty(IStatusListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/PendingResult", typeof(PendingResult));

		private static Delegate cb_isCanceled;

		private static Delegate cb_addStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_;

		private static Delegate cb_await;

		private static Delegate cb_await_JLjava_util_concurrent_TimeUnit_;

		private static Delegate cb_cancel;

		private static Delegate cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_;

		private static Delegate cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_;

		private static Delegate cb_then_Lcom_google_android_gms_common_api_ResultTransform_;

		private System.WeakReference weak_implementor_AddStatusListener;

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

		public abstract bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
			get;
		}

		public event EventHandler<StatusEventArgs> Status
		{
			add
			{
				EventHelper.AddEventHandler<IStatusListener, IStatusListenerImplementor>(ref weak_implementor_AddStatusListener, __CreateIStatusListenerImplementor, AddStatusListener, delegate(IStatusListenerImplementor __h)
				{
					__h.Handler = (EventHandler<StatusEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IStatusListener, IStatusListenerImplementor>(ref weak_implementor_AddStatusListener, IStatusListenerImplementor.__IsEmpty, delegate
				{
					throw new NotSupportedException("Cannot unregister from Android.Gms.Common.Apis.PendingResult.IStatusListener.AddStatusListener");
				}, delegate(IStatusListenerImplementor __h)
				{
					__h.Handler = (EventHandler<StatusEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected PendingResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PendingResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsCanceledHandler()
		{
			if ((object)cb_isCanceled == null)
			{
				cb_isCanceled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCanceled));
			}
			return cb_isCanceled;
		}

		private static bool n_IsCanceled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCanceled;
		}

		private static Delegate GetAddStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_Handler()
		{
			if ((object)cb_addStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_ == null)
			{
				cb_addStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_));
			}
			return cb_addStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_;
		}

		private static void n_AddStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			PendingResult pendingResult = Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IStatusListener p = Java.Lang.Object.GetObject<IStatusListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			pendingResult.AddStatusListener(p);
		}

		[Register("addStatusListener", "(Lcom/google/android/gms/common/api/PendingResult$StatusListener;)V", "GetAddStatusListener_Lcom_google_android_gms_common_api_PendingResult_StatusListener_Handler")]
		public unsafe virtual void AddStatusListener(IStatusListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addStatusListener.(Lcom/google/android/gms/common/api/PendingResult$StatusListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetAwaitHandler()
		{
			if ((object)cb_await == null)
			{
				cb_await = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Await));
			}
			return cb_await;
		}

		private static IntPtr n_Await(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Await());
		}

		[Register("await", "()Lcom/google/android/gms/common/api/Result;", "GetAwaitHandler")]
		public abstract Java.Lang.Object Await();

		private static Delegate GetAwait_JLjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_await_JLjava_util_concurrent_TimeUnit_ == null)
			{
				cb_await_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_Await_JLjava_util_concurrent_TimeUnit_));
			}
			return cb_await_JLjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_Await_JLjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			PendingResult pendingResult = Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit p1 = Java.Lang.Object.GetObject<TimeUnit>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pendingResult.Await(p0, p1));
		}

		[Register("await", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", "GetAwait_JLjava_util_concurrent_TimeUnit_Handler")]
		public abstract Java.Lang.Object Await(long p0, TimeUnit p1);

		private static Delegate GetCancelHandler()
		{
			if ((object)cb_cancel == null)
			{
				cb_cancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Cancel));
			}
			return cb_cancel;
		}

		private static void n_Cancel(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public abstract void Cancel();

		private static Delegate GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_Handler()
		{
			if ((object)cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_ == null)
			{
				cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_));
			}
			return cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_;
		}

		private static void n_SetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			PendingResult pendingResult = Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResultCallback resultCallback = Java.Lang.Object.GetObject<IResultCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			pendingResult.SetResultCallback(resultCallback);
		}

		[Register("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;)V", "GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_Handler")]
		public abstract void SetResultCallback(IResultCallback p0);

		private static Delegate GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_ == null)
			{
				cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLJL_V(n_SetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_));
			}
			return cb_setResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_;
		}

		private static void n_SetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1, IntPtr native_p2)
		{
			PendingResult pendingResult = Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResultCallback p2 = Java.Lang.Object.GetObject<IResultCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			TimeUnit p3 = Java.Lang.Object.GetObject<TimeUnit>(native_p2, JniHandleOwnership.DoNotTransfer);
			pendingResult.SetResultCallback(p2, p1, p3);
		}

		[Register("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V", "GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_Handler")]
		public abstract void SetResultCallback(IResultCallback p0, long p1, TimeUnit p2);

		private static Delegate GetThen_Lcom_google_android_gms_common_api_ResultTransform_Handler()
		{
			if ((object)cb_then_Lcom_google_android_gms_common_api_ResultTransform_ == null)
			{
				cb_then_Lcom_google_android_gms_common_api_ResultTransform_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Then_Lcom_google_android_gms_common_api_ResultTransform_));
			}
			return cb_then_Lcom_google_android_gms_common_api_ResultTransform_;
		}

		private static IntPtr n_Then_Lcom_google_android_gms_common_api_ResultTransform_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			PendingResult pendingResult = Java.Lang.Object.GetObject<PendingResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ResultTransform p = Java.Lang.Object.GetObject<ResultTransform>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pendingResult.Then(p));
		}

		[Register("then", "(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", "GetThen_Lcom_google_android_gms_common_api_ResultTransform_Handler")]
		[JavaTypeParameters(new string[] { "S extends com.google.android.gms.common.api.Result" })]
		public unsafe virtual TransformedResult Then(ResultTransform p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransformedResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("then.(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private IStatusListenerImplementor __CreateIStatusListenerImplementor()
		{
			return new IStatusListenerImplementor(this);
		}
	}
	[Register("com/google/android/gms/common/api/PendingResult", DoNotGenerateAcw = true)]
	internal class PendingResultInvoker : PendingResult
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/PendingResult", typeof(PendingResultInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCanceled.()Z", this, null);
			}
		}

		public PendingResultInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("await", "()Lcom/google/android/gms/common/api/Result;", "GetAwaitHandler")]
		public unsafe override Java.Lang.Object Await()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("await.()Lcom/google/android/gms/common/api/Result;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("await", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", "GetAwait_JLjava_util_concurrent_TimeUnit_Handler")]
		public unsafe override Java.Lang.Object Await(long p0, TimeUnit p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("await.(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
			}
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe override void Cancel()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
		}

		[Register("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;)V", "GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_Handler")]
		public unsafe override void SetResultCallback(IResultCallback p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setResultCallback.(Lcom/google/android/gms/common/api/ResultCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V", "GetSetResultCallback_Lcom_google_android_gms_common_api_ResultCallback_JLjava_util_concurrent_TimeUnit_Handler")]
		public unsafe override void SetResultCallback(IResultCallback p0, long p1, TimeUnit p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setResultCallback.(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p2);
			}
		}
	}
	[Register("com/google/android/gms/common/api/ResultTransform", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result", "S extends com.google.android.gms.common.api.Result" })]
	public abstract class ResultTransform : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/ResultTransform", typeof(ResultTransform));

		private static Delegate cb_onFailure_Lcom_google_android_gms_common_api_Status_;

		private static Delegate cb_onSuccess_Lcom_google_android_gms_common_api_Result_;

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

		protected ResultTransform(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ResultTransform()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("createFailedResult", "(Lcom/google/android/gms/common/api/Status;)Lcom/google/android/gms/common/api/PendingResult;", "")]
		public unsafe PendingResult CreateFailedResult(Statuses p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PendingResult>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createFailedResult.(Lcom/google/android/gms/common/api/Status;)Lcom/google/android/gms/common/api/PendingResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnFailure_Lcom_google_android_gms_common_api_Status_Handler()
		{
			if ((object)cb_onFailure_Lcom_google_android_gms_common_api_Status_ == null)
			{
				cb_onFailure_Lcom_google_android_gms_common_api_Status_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnFailure_Lcom_google_android_gms_common_api_Status_));
			}
			return cb_onFailure_Lcom_google_android_gms_common_api_Status_;
		}

		private static IntPtr n_OnFailure_Lcom_google_android_gms_common_api_Status_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ResultTransform resultTransform = Java.Lang.Object.GetObject<ResultTransform>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Statuses p = Java.Lang.Object.GetObject<Statuses>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(resultTransform.OnFailure(p));
		}

		[Register("onFailure", "(Lcom/google/android/gms/common/api/Status;)Lcom/google/android/gms/common/api/Status;", "GetOnFailure_Lcom_google_android_gms_common_api_Status_Handler")]
		public unsafe virtual Statuses OnFailure(Statuses p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Statuses>(_members.InstanceMethods.InvokeVirtualObjectMethod("onFailure.(Lcom/google/android/gms/common/api/Status;)Lcom/google/android/gms/common/api/Status;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler()
		{
			if ((object)cb_onSuccess_Lcom_google_android_gms_common_api_Result_ == null)
			{
				cb_onSuccess_Lcom_google_android_gms_common_api_Result_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnSuccess_Lcom_google_android_gms_common_api_Result_));
			}
			return cb_onSuccess_Lcom_google_android_gms_common_api_Result_;
		}

		private static IntPtr n_OnSuccess_Lcom_google_android_gms_common_api_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ResultTransform resultTransform = Java.Lang.Object.GetObject<ResultTransform>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(resultTransform.OnSuccess(p));
		}

		[Register("onSuccess", "(Lcom/google/android/gms/common/api/Result;)Lcom/google/android/gms/common/api/PendingResult;", "GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler")]
		public abstract PendingResult OnSuccess(Java.Lang.Object p0);
	}
	[Register("com/google/android/gms/common/api/ResultTransform", DoNotGenerateAcw = true)]
	internal class ResultTransformInvoker : ResultTransform
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/ResultTransform", typeof(ResultTransformInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ResultTransformInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onSuccess", "(Lcom/google/android/gms/common/api/Result;)Lcom/google/android/gms/common/api/PendingResult;", "GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler")]
		public unsafe override PendingResult OnSuccess(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PendingResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("onSuccess.(Lcom/google/android/gms/common/api/Result;)Lcom/google/android/gms/common/api/PendingResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/TransformedResult", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result" })]
	public abstract class TransformedResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/TransformedResult", typeof(TransformedResult));

		private static Delegate cb_andFinally_Lcom_google_android_gms_common_api_ResultCallbacks_;

		private static Delegate cb_then_Lcom_google_android_gms_common_api_ResultTransform_;

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

		protected TransformedResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransformedResult()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAndFinally_Lcom_google_android_gms_common_api_ResultCallbacks_Handler()
		{
			if ((object)cb_andFinally_Lcom_google_android_gms_common_api_ResultCallbacks_ == null)
			{
				cb_andFinally_Lcom_google_android_gms_common_api_ResultCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AndFinally_Lcom_google_android_gms_common_api_ResultCallbacks_));
			}
			return cb_andFinally_Lcom_google_android_gms_common_api_ResultCallbacks_;
		}

		private static void n_AndFinally_Lcom_google_android_gms_common_api_ResultCallbacks_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			TransformedResult transformedResult = Java.Lang.Object.GetObject<TransformedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ResultCallbacks p = Java.Lang.Object.GetObject<ResultCallbacks>(native_p0, JniHandleOwnership.DoNotTransfer);
			transformedResult.AndFinally(p);
		}

		[Register("andFinally", "(Lcom/google/android/gms/common/api/ResultCallbacks;)V", "GetAndFinally_Lcom_google_android_gms_common_api_ResultCallbacks_Handler")]
		public abstract void AndFinally(ResultCallbacks p0);

		private static Delegate GetThen_Lcom_google_android_gms_common_api_ResultTransform_Handler()
		{
			if ((object)cb_then_Lcom_google_android_gms_common_api_ResultTransform_ == null)
			{
				cb_then_Lcom_google_android_gms_common_api_ResultTransform_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Then_Lcom_google_android_gms_common_api_ResultTransform_));
			}
			return cb_then_Lcom_google_android_gms_common_api_ResultTransform_;
		}

		private static IntPtr n_Then_Lcom_google_android_gms_common_api_ResultTransform_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			TransformedResult transformedResult = Java.Lang.Object.GetObject<TransformedResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ResultTransform p = Java.Lang.Object.GetObject<ResultTransform>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transformedResult.Then(p));
		}

		[Register("then", "(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", "GetThen_Lcom_google_android_gms_common_api_ResultTransform_Handler")]
		[JavaTypeParameters(new string[] { "S extends com.google.android.gms.common.api.Result" })]
		public abstract TransformedResult Then(ResultTransform p0);
	}
	[Register("com/google/android/gms/common/api/TransformedResult", DoNotGenerateAcw = true)]
	internal class TransformedResultInvoker : TransformedResult
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/TransformedResult", typeof(TransformedResultInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TransformedResultInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("andFinally", "(Lcom/google/android/gms/common/api/ResultCallbacks;)V", "GetAndFinally_Lcom_google_android_gms_common_api_ResultCallbacks_Handler")]
		public unsafe override void AndFinally(ResultCallbacks p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("andFinally.(Lcom/google/android/gms/common/api/ResultCallbacks;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("then", "(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", "GetThen_Lcom_google_android_gms_common_api_ResultTransform_Handler")]
		[JavaTypeParameters(new string[] { "S extends com.google.android.gms.common.api.Result" })]
		public unsafe override TransformedResult Then(ResultTransform p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransformedResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("then.(Lcom/google/android/gms/common/api/ResultTransform;)Lcom/google/android/gms/common/api/TransformedResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
}
