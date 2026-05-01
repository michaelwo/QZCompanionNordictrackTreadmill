using System;
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
using Android.Gms.Common.Internal.SafeParcel;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a0fa1472deb92370c554f5762558eb29933bf602")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220811.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "8/11/2022 10:05:08 AM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.android.gms.actions", Managed = "Android.Gms.Actions")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common", Managed = "Android.Gms.Common")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.annotation", Managed = "Android.Gms.Common.Annotations")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.api", Managed = "Android.Gms.Common.Apis")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.api.internal", Managed = "Android.Gms.Common.Apis.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.config", Managed = "Android.Gms.Common.Config")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.internal", Managed = "Android.Gms.Common.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.internal.constants", Managed = "Android.Gms.Internal.Constants")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.internal.safeparcel", Managed = "Android.Gms.Common.Internal.SafeParcel")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.logging", Managed = "Android.Gms.Common.Logging")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.providers", Managed = "Android.Gms.Common.Providers")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.sqlite", Managed = "Android.Gms.Common.SqlLite")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.stats", Managed = "Android.Gms.Common.Stats")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.util", Managed = "Android.Gms.Common.Util")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.util.concurrent", Managed = "Android.Gms.Common.Util.Concurrent")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.common.wrappers", Managed = "Android.Gms.Common.Util.Wrappers")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.dynamic", Managed = "Android.Gms.Dynamic")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.dynamite", Managed = "Android.Gms.Dynamite")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.security", Managed = "Android.Gms.Security")]
[assembly: NamespaceMapping(Java = "com.google.firebase", Managed = "Firebase")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\n        Xamarin.Android Bindings for Google Play Services - Basement 118.1.0 artifact=com.google.android.gms:play-services-basement artifact_versioned=com.google.android.gms:play-services-basement:18.1.0\n\n         - do not install directly\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Basement")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Basement")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPIIL_V(IntPtr jnienv, IntPtr klass, int p0, int p1, IntPtr p2);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate int _JniMarshal_PPLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate bool _JniMarshal_PPLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLIIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
namespace Android.Gms.Common
{
	[Register("com/google/android/gms/common/ConnectionResult", DoNotGenerateAcw = true)]
	public sealed class ConnectionResult : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/ConnectionResult", typeof(ConnectionResult));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_SUCCESS")]
		public static ConnectionResult ResultSuccess => Java.Lang.Object.GetObject<ConnectionResult>(_members.StaticFields.GetObjectValue("RESULT_SUCCESS.Lcom/google/android/gms/common/ConnectionResult;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe int ErrorCode
		{
			[Register("getErrorCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getErrorCode.()I", this, null);
			}
		}

		public unsafe string ErrorMessage
		{
			[Register("getErrorMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool HasResolution
		{
			[Register("hasResolution", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasResolution.()Z", this, null);
			}
		}

		public unsafe bool IsSuccess
		{
			[Register("isSuccess", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSuccess.()Z", this, null);
			}
		}

		public unsafe PendingIntent Resolution
		{
			[Register("getResolution", "()Landroid/app/PendingIntent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolution.()Landroid/app/PendingIntent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ConnectionResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe ConnectionResult(int statusCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(statusCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(ILandroid/app/PendingIntent;)V", "")]
		public unsafe ConnectionResult(int statusCode, PendingIntent pendingIntent)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(statusCode);
				ptr[1] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroid/app/PendingIntent;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILandroid/app/PendingIntent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register(".ctor", "(ILandroid/app/PendingIntent;Ljava/lang/String;)V", "")]
		public unsafe ConnectionResult(int statusCode, PendingIntent pendingIntent, string message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(statusCode);
				ptr[1] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroid/app/PendingIntent;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILandroid/app/PendingIntent;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("startResolutionForResult", "(Landroid/app/Activity;I)V", "")]
		public unsafe void StartResolutionForResult(Activity activity, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startResolutionForResult.(Landroid/app/Activity;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/common/Feature", DoNotGenerateAcw = true)]
	public class Feature : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/Feature", typeof(Feature));

		private static Delegate cb_getName;

		private static Delegate cb_getVersion;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long Version
		{
			[Register("getVersion", "()J", "GetGetVersionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getVersion.()J", this, null);
			}
		}

		protected Feature(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;IJ)V", "")]
		public unsafe Feature(string p0, int p1, long p2)
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
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IJ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;J)V", "")]
		public unsafe Feature(string name, long version)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(version);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;J)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Feature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetGetVersionHandler()
		{
			if ((object)cb_getVersion == null)
			{
				cb_getVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetVersion));
			}
			return cb_getVersion;
		}

		private static long n_GetVersion(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Feature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Version;
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

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe sealed override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}
	[Register("com/google/android/gms/common/GoogleApiAvailabilityLight", DoNotGenerateAcw = true)]
	public class GoogleApiAvailabilityLight : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/GoogleApiAvailabilityLight", typeof(GoogleApiAvailabilityLight));

		private static Delegate cb_cancelAvailabilityErrorNotifications_Landroid_content_Context_;

		private static Delegate cb_getApkVersion_Landroid_content_Context_;

		private static Delegate cb_getClientVersion_Landroid_content_Context_;

		private static Delegate cb_getErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_;

		private static Delegate cb_getErrorResolutionIntent_I;

		private static Delegate cb_getErrorResolutionPendingIntent_Landroid_content_Context_II;

		private static Delegate cb_getErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_;

		private static Delegate cb_getErrorString_I;

		private static Delegate cb_isGooglePlayServicesAvailable_Landroid_content_Context_;

		private static Delegate cb_isGooglePlayServicesAvailable_Landroid_content_Context_I;

		private static Delegate cb_isPlayServicesPossiblyUpdating_Landroid_content_Context_I;

		private static Delegate cb_isPlayStorePossiblyUpdating_Landroid_content_Context_I;

		private static Delegate cb_isUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_;

		private static Delegate cb_isUserResolvableError_I;

		private static Delegate cb_verifyGooglePlayServicesIsAvailable_Landroid_content_Context_I;

		[Register("GOOGLE_PLAY_SERVICES_VERSION_CODE")]
		public static int GooglePlayServicesVersionCode => _members.StaticFields.GetInt32Value("GOOGLE_PLAY_SERVICES_VERSION_CODE.I");

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

		public unsafe static GoogleApiAvailabilityLight Instance
		{
			[Register("getInstance", "()Lcom/google/android/gms/common/GoogleApiAvailabilityLight;", "")]
			get
			{
				return Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/android/gms/common/GoogleApiAvailabilityLight;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected GoogleApiAvailabilityLight(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetCancelAvailabilityErrorNotifications_Landroid_content_Context_Handler()
		{
			if ((object)cb_cancelAvailabilityErrorNotifications_Landroid_content_Context_ == null)
			{
				cb_cancelAvailabilityErrorNotifications_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CancelAvailabilityErrorNotifications_Landroid_content_Context_));
			}
			return cb_cancelAvailabilityErrorNotifications_Landroid_content_Context_;
		}

		private static void n_CancelAvailabilityErrorNotifications_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			googleApiAvailabilityLight.CancelAvailabilityErrorNotifications(context);
		}

		[Register("cancelAvailabilityErrorNotifications", "(Landroid/content/Context;)V", "GetCancelAvailabilityErrorNotifications_Landroid_content_Context_Handler")]
		public unsafe virtual void CancelAvailabilityErrorNotifications(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cancelAvailabilityErrorNotifications.(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetApkVersion_Landroid_content_Context_Handler()
		{
			if ((object)cb_getApkVersion_Landroid_content_Context_ == null)
			{
				cb_getApkVersion_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetApkVersion_Landroid_content_Context_));
			}
			return cb_getApkVersion_Landroid_content_Context_;
		}

		private static int n_GetApkVersion_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.GetApkVersion(context);
		}

		[Register("getApkVersion", "(Landroid/content/Context;)I", "GetGetApkVersion_Landroid_content_Context_Handler")]
		public unsafe virtual int GetApkVersion(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getApkVersion.(Landroid/content/Context;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetClientVersion_Landroid_content_Context_Handler()
		{
			if ((object)cb_getClientVersion_Landroid_content_Context_ == null)
			{
				cb_getClientVersion_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetClientVersion_Landroid_content_Context_));
			}
			return cb_getClientVersion_Landroid_content_Context_;
		}

		private static int n_GetClientVersion_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.GetClientVersion(context);
		}

		[Register("getClientVersion", "(Landroid/content/Context;)I", "GetGetClientVersion_Landroid_content_Context_Handler")]
		public unsafe virtual int GetClientVersion(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getClientVersion.(Landroid/content/Context;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_Handler()
		{
			if ((object)cb_getErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_ == null)
			{
				cb_getErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_L(n_GetErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_));
			}
			return cb_getErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_;
		}

		private static IntPtr n_GetErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode, IntPtr native_trackingSource)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string trackingSource = JNIEnv.GetString(native_trackingSource, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailabilityLight.GetErrorResolutionIntent(context, errorCode, trackingSource));
		}

		[Register("getErrorResolutionIntent", "(Landroid/content/Context;ILjava/lang/String;)Landroid/content/Intent;", "GetGetErrorResolutionIntent_Landroid_content_Context_ILjava_lang_String_Handler")]
		public unsafe virtual Intent GetErrorResolutionIntent(Context context, int errorCode, string trackingSource)
		{
			IntPtr intPtr = JNIEnv.NewString(trackingSource);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorResolutionIntent.(Landroid/content/Context;ILjava/lang/String;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetErrorResolutionIntent_IHandler()
		{
			if ((object)cb_getErrorResolutionIntent_I == null)
			{
				cb_getErrorResolutionIntent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetErrorResolutionIntent_I));
			}
			return cb_getErrorResolutionIntent_I;
		}

		private static IntPtr n_GetErrorResolutionIntent_I(IntPtr jnienv, IntPtr native__this, int errorCode)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetErrorResolutionIntent(errorCode));
		}

		[Register("getErrorResolutionIntent", "(I)Landroid/content/Intent;", "GetGetErrorResolutionIntent_IHandler")]
		public unsafe virtual Intent GetErrorResolutionIntent(int errorCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorCode);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorResolutionIntent.(I)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetErrorResolutionPendingIntent_Landroid_content_Context_IIHandler()
		{
			if ((object)cb_getErrorResolutionPendingIntent_Landroid_content_Context_II == null)
			{
				cb_getErrorResolutionPendingIntent_Landroid_content_Context_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_GetErrorResolutionPendingIntent_Landroid_content_Context_II));
			}
			return cb_getErrorResolutionPendingIntent_Landroid_content_Context_II;
		}

		private static IntPtr n_GetErrorResolutionPendingIntent_Landroid_content_Context_II(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode, int requestCode)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailabilityLight.GetErrorResolutionPendingIntent(context, errorCode, requestCode));
		}

		[Register("getErrorResolutionPendingIntent", "(Landroid/content/Context;II)Landroid/app/PendingIntent;", "GetGetErrorResolutionPendingIntent_Landroid_content_Context_IIHandler")]
		public unsafe virtual PendingIntent GetErrorResolutionPendingIntent(Context context, int errorCode, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorResolutionPendingIntent.(Landroid/content/Context;II)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_Handler()
		{
			if ((object)cb_getErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_ == null)
			{
				cb_getErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIL_L(n_GetErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_));
			}
			return cb_getErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_;
		}

		private static IntPtr n_GetErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode, int requestCode, IntPtr native_trackingSource)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string trackingSource = JNIEnv.GetString(native_trackingSource, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(googleApiAvailabilityLight.GetErrorResolutionPendingIntent(context, errorCode, requestCode, trackingSource));
		}

		[Register("getErrorResolutionPendingIntent", "(Landroid/content/Context;IILjava/lang/String;)Landroid/app/PendingIntent;", "GetGetErrorResolutionPendingIntent_Landroid_content_Context_IILjava_lang_String_Handler")]
		public unsafe virtual PendingIntent GetErrorResolutionPendingIntent(Context context, int errorCode, int requestCode, string trackingSource)
		{
			IntPtr intPtr = JNIEnv.NewString(trackingSource);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				ptr[2] = new JniArgumentValue(requestCode);
				ptr[3] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorResolutionPendingIntent.(Landroid/content/Context;IILjava/lang/String;)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetErrorString_IHandler()
		{
			if ((object)cb_getErrorString_I == null)
			{
				cb_getErrorString_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetErrorString_I));
			}
			return cb_getErrorString_I;
		}

		private static IntPtr n_GetErrorString_I(IntPtr jnienv, IntPtr native__this, int errorCode)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetErrorString(errorCode));
		}

		[Register("getErrorString", "(I)Ljava/lang/String;", "GetGetErrorString_IHandler")]
		public unsafe virtual string GetErrorString(int errorCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorCode);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetIsGooglePlayServicesAvailable_Landroid_content_Context_Handler()
		{
			if ((object)cb_isGooglePlayServicesAvailable_Landroid_content_Context_ == null)
			{
				cb_isGooglePlayServicesAvailable_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_IsGooglePlayServicesAvailable_Landroid_content_Context_));
			}
			return cb_isGooglePlayServicesAvailable_Landroid_content_Context_;
		}

		private static int n_IsGooglePlayServicesAvailable_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.IsGooglePlayServicesAvailable(context);
		}

		[Register("isGooglePlayServicesAvailable", "(Landroid/content/Context;)I", "GetIsGooglePlayServicesAvailable_Landroid_content_Context_Handler")]
		public unsafe virtual int IsGooglePlayServicesAvailable(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("isGooglePlayServicesAvailable.(Landroid/content/Context;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsGooglePlayServicesAvailable_Landroid_content_Context_IHandler()
		{
			if ((object)cb_isGooglePlayServicesAvailable_Landroid_content_Context_I == null)
			{
				cb_isGooglePlayServicesAvailable_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_IsGooglePlayServicesAvailable_Landroid_content_Context_I));
			}
			return cb_isGooglePlayServicesAvailable_Landroid_content_Context_I;
		}

		private static int n_IsGooglePlayServicesAvailable_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int minApkVersion)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.IsGooglePlayServicesAvailable(context, minApkVersion);
		}

		[Register("isGooglePlayServicesAvailable", "(Landroid/content/Context;I)I", "GetIsGooglePlayServicesAvailable_Landroid_content_Context_IHandler")]
		public unsafe virtual int IsGooglePlayServicesAvailable(Context context, int minApkVersion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(minApkVersion);
				return _members.InstanceMethods.InvokeVirtualInt32Method("isGooglePlayServicesAvailable.(Landroid/content/Context;I)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsPlayServicesPossiblyUpdating_Landroid_content_Context_IHandler()
		{
			if ((object)cb_isPlayServicesPossiblyUpdating_Landroid_content_Context_I == null)
			{
				cb_isPlayServicesPossiblyUpdating_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_Z(n_IsPlayServicesPossiblyUpdating_Landroid_content_Context_I));
			}
			return cb_isPlayServicesPossiblyUpdating_Landroid_content_Context_I;
		}

		private static bool n_IsPlayServicesPossiblyUpdating_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.IsPlayServicesPossiblyUpdating(context, errorCode);
		}

		[Register("isPlayServicesPossiblyUpdating", "(Landroid/content/Context;I)Z", "GetIsPlayServicesPossiblyUpdating_Landroid_content_Context_IHandler")]
		public unsafe virtual bool IsPlayServicesPossiblyUpdating(Context context, int errorCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPlayServicesPossiblyUpdating.(Landroid/content/Context;I)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsPlayStorePossiblyUpdating_Landroid_content_Context_IHandler()
		{
			if ((object)cb_isPlayStorePossiblyUpdating_Landroid_content_Context_I == null)
			{
				cb_isPlayStorePossiblyUpdating_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_Z(n_IsPlayStorePossiblyUpdating_Landroid_content_Context_I));
			}
			return cb_isPlayStorePossiblyUpdating_Landroid_content_Context_I;
		}

		private static bool n_IsPlayStorePossiblyUpdating_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int errorCode)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.IsPlayStorePossiblyUpdating(context, errorCode);
		}

		[Register("isPlayStorePossiblyUpdating", "(Landroid/content/Context;I)Z", "GetIsPlayStorePossiblyUpdating_Landroid_content_Context_IHandler")]
		public unsafe virtual bool IsPlayStorePossiblyUpdating(Context context, int errorCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(errorCode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPlayStorePossiblyUpdating.(Landroid/content/Context;I)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_Handler()
		{
			if ((object)cb_isUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_ == null)
			{
				cb_isUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_));
			}
			return cb_isUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_;
		}

		private static bool n_IsUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_packageName)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string packageName = JNIEnv.GetString(native_packageName, JniHandleOwnership.DoNotTransfer);
			return googleApiAvailabilityLight.IsUninstalledAppPossiblyUpdating(context, packageName);
		}

		[Register("isUninstalledAppPossiblyUpdating", "(Landroid/content/Context;Ljava/lang/String;)Z", "GetIsUninstalledAppPossiblyUpdating_Landroid_content_Context_Ljava_lang_String_Handler")]
		public unsafe virtual bool IsUninstalledAppPossiblyUpdating(Context context, string packageName)
		{
			IntPtr intPtr = JNIEnv.NewString(packageName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUninstalledAppPossiblyUpdating.(Landroid/content/Context;Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsUserResolvableError_IHandler()
		{
			if ((object)cb_isUserResolvableError_I == null)
			{
				cb_isUserResolvableError_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_IsUserResolvableError_I));
			}
			return cb_isUserResolvableError_I;
		}

		private static bool n_IsUserResolvableError_I(IntPtr jnienv, IntPtr native__this, int errorCode)
		{
			return Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsUserResolvableError(errorCode);
		}

		[Register("isUserResolvableError", "(I)Z", "GetIsUserResolvableError_IHandler")]
		public unsafe virtual bool IsUserResolvableError(int errorCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorCode);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUserResolvableError.(I)Z", this, ptr);
		}

		private static Delegate GetVerifyGooglePlayServicesIsAvailable_Landroid_content_Context_IHandler()
		{
			if ((object)cb_verifyGooglePlayServicesIsAvailable_Landroid_content_Context_I == null)
			{
				cb_verifyGooglePlayServicesIsAvailable_Landroid_content_Context_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_VerifyGooglePlayServicesIsAvailable_Landroid_content_Context_I));
			}
			return cb_verifyGooglePlayServicesIsAvailable_Landroid_content_Context_I;
		}

		private static void n_VerifyGooglePlayServicesIsAvailable_Landroid_content_Context_I(IntPtr jnienv, IntPtr native__this, IntPtr native_context, int minApkVersion)
		{
			GoogleApiAvailabilityLight googleApiAvailabilityLight = Java.Lang.Object.GetObject<GoogleApiAvailabilityLight>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			googleApiAvailabilityLight.VerifyGooglePlayServicesIsAvailable(context, minApkVersion);
		}

		[Register("verifyGooglePlayServicesIsAvailable", "(Landroid/content/Context;I)V", "GetVerifyGooglePlayServicesIsAvailable_Landroid_content_Context_IHandler")]
		public unsafe virtual void VerifyGooglePlayServicesIsAvailable(Context context, int minApkVersion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(minApkVersion);
				_members.InstanceMethods.InvokeVirtualVoidMethod("verifyGooglePlayServicesIsAvailable.(Landroid/content/Context;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}
	}
}
namespace Android.Gms.Common.Util
{
	[Register("com/google/android/gms/common/util/BiConsumer", "", "Android.Gms.Common.Util.IBiConsumerInvoker")]
	[JavaTypeParameters(new string[] { "T", "U" })]
	public interface IBiConsumer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("accept", "(Ljava/lang/Object;Ljava/lang/Object;)V", "GetAccept_Ljava_lang_Object_Ljava_lang_Object_Handler:Android.Gms.Common.Util.IBiConsumerInvoker, Xamarin.GooglePlayServices.Basement")]
		void Accept(Java.Lang.Object p0, Java.Lang.Object p1);
	}
	[Register("com/google/android/gms/common/util/BiConsumer", DoNotGenerateAcw = true)]
	internal class IBiConsumerInvoker : Java.Lang.Object, IBiConsumer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/util/BiConsumer", typeof(IBiConsumerInvoker));

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

		public static IBiConsumer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBiConsumer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.util.BiConsumer'.");
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

		public IBiConsumerInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			IBiConsumer biConsumer = Java.Lang.Object.GetObject<IBiConsumer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			biConsumer.Accept(p, p2);
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
}
namespace Android.Gms.Common.Internal
{
	[Register("com/google/android/gms/common/internal/IAccountAccessor", "", "Android.Gms.Common.Internal.IAccountAccessorInvoker")]
	public interface IAccountAccessor : IInterface, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/gms/common/internal/IAccountAccessor", DoNotGenerateAcw = true)]
	internal class IAccountAccessorInvoker : Java.Lang.Object, IAccountAccessor, IInterface, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/internal/IAccountAccessor", typeof(IAccountAccessorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_asBinder;

		private IntPtr id_asBinder;

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

		public static IAccountAccessor GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAccountAccessor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.internal.IAccountAccessor'.");
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

		public IAccountAccessorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAsBinderHandler()
		{
			if ((object)cb_asBinder == null)
			{
				cb_asBinder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AsBinder));
			}
			return cb_asBinder;
		}

		private static IntPtr n_AsBinder(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAccountAccessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBinder());
		}

		public IBinder AsBinder()
		{
			if (id_asBinder == IntPtr.Zero)
			{
				id_asBinder = JNIEnv.GetMethodID(class_ref, "asBinder", "()Landroid/os/IBinder;");
			}
			return Java.Lang.Object.GetObject<IBinder>(JNIEnv.CallObjectMethod(base.Handle, id_asBinder), JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Android.Gms.Common.Internal.SafeParcel
{
	[Register("com/google/android/gms/common/internal/safeparcel/AbstractSafeParcelable", DoNotGenerateAcw = true)]
	public abstract class AbstractSafeParcelable : Java.Lang.Object, ISafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/internal/safeparcel/AbstractSafeParcelable", typeof(AbstractSafeParcelable));

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

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

		protected AbstractSafeParcelable(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AbstractSafeParcelable()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("describeContents", "()I", "")]
		public unsafe int DescribeContents()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("describeContents.()I", this, null);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dest, int native_flags)
		{
			AbstractSafeParcelable abstractSafeParcelable = Java.Lang.Object.GetObject<AbstractSafeParcelable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			abstractSafeParcelable.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public abstract void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags);
	}
	[Register("com/google/android/gms/common/internal/safeparcel/AbstractSafeParcelable", DoNotGenerateAcw = true)]
	internal class AbstractSafeParcelableInvoker : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/internal/safeparcel/AbstractSafeParcelable", typeof(AbstractSafeParcelableInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AbstractSafeParcelableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}
	[Register("com/google/android/gms/common/internal/safeparcel/SafeParcelable", "", "Android.Gms.Common.Internal.SafeParcel.ISafeParcelableInvoker")]
	public interface ISafeParcelable : IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/gms/common/internal/safeparcel/SafeParcelable", DoNotGenerateAcw = true)]
	internal class ISafeParcelableInvoker : Java.Lang.Object, ISafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/internal/safeparcel/SafeParcelable", typeof(ISafeParcelableInvoker));

		private IntPtr class_ref;

		private static Delegate cb_describeContents;

		private IntPtr id_describeContents;

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		private IntPtr id_writeToParcel_Landroid_os_Parcel_I;

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

		public static ISafeParcelable GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISafeParcelable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.internal.safeparcel.SafeParcelable'.");
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

		public ISafeParcelableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDescribeContentsHandler()
		{
			if ((object)cb_describeContents == null)
			{
				cb_describeContents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_DescribeContents));
			}
			return cb_describeContents;
		}

		private static int n_DescribeContents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISafeParcelable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescribeContents();
		}

		public int DescribeContents()
		{
			if (id_describeContents == IntPtr.Zero)
			{
				id_describeContents = JNIEnv.GetMethodID(class_ref, "describeContents", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_describeContents);
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dest, int native_flags)
		{
			ISafeParcelable safeParcelable = Java.Lang.Object.GetObject<ISafeParcelable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
			safeParcelable.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		public unsafe void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			if (id_writeToParcel_Landroid_os_Parcel_I == IntPtr.Zero)
			{
				id_writeToParcel_Landroid_os_Parcel_I = JNIEnv.GetMethodID(class_ref, "writeToParcel", "(Landroid/os/Parcel;I)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((int)flags);
			JNIEnv.CallVoidMethod(base.Handle, id_writeToParcel_Landroid_os_Parcel_I, ptr);
		}
	}
}
namespace Android.Gms.Common.Apis
{
	public class AwaitableResultCallback<TResult> : Java.Lang.Object, IResultCallback, IJavaObject, IDisposable, IJavaPeerable where TResult : class, IResult
	{
		private TaskCompletionSource<TResult> taskCompletionSource;

		public AwaitableResultCallback()
		{
			taskCompletionSource = new TaskCompletionSource<TResult>();
		}

		public void OnResult(Java.Lang.Object result)
		{
			TResult result2 = Extensions.JavaCast<TResult>(result);
			taskCompletionSource.SetResult(result2);
		}

		public Task<TResult> AwaitAsync()
		{
			return taskCompletionSource.Task;
		}

		public TaskAwaiter<TResult> GetAwaiter()
		{
			return taskCompletionSource.Task.GetAwaiter();
		}
	}
	[Register("com/google/android/gms/common/api/Result", "", "Android.Gms.Common.Apis.IResultInvoker")]
	public interface IResult : IJavaObject, IDisposable, IJavaPeerable
	{
		Statuses Status
		{
			[Register("getStatus", "()Lcom/google/android/gms/common/api/Status;", "GetGetStatusHandler:Android.Gms.Common.Apis.IResultInvoker, Xamarin.GooglePlayServices.Basement")]
			get;
		}
	}
	[Register("com/google/android/gms/common/api/Result", DoNotGenerateAcw = true)]
	internal class IResultInvoker : Java.Lang.Object, IResult, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Result", typeof(IResultInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getStatus;

		private IntPtr id_getStatus;

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

		public Statuses Status
		{
			get
			{
				if (id_getStatus == IntPtr.Zero)
				{
					id_getStatus = JNIEnv.GetMethodID(class_ref, "getStatus", "()Lcom/google/android/gms/common/api/Status;");
				}
				return Java.Lang.Object.GetObject<Statuses>(JNIEnv.CallObjectMethod(base.Handle, id_getStatus), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IResult GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IResult>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.Result'.");
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

		public IResultInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetStatusHandler()
		{
			if ((object)cb_getStatus == null)
			{
				cb_getStatus = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStatus));
			}
			return cb_getStatus;
		}

		private static IntPtr n_GetStatus(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Status);
		}
	}
	[Register("com/google/android/gms/common/api/ResultCallback", "", "Android.Gms.Common.Apis.IResultCallbackInvoker")]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result" })]
	public interface IResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onResult", "(Lcom/google/android/gms/common/api/Result;)V", "GetOnResult_Lcom_google_android_gms_common_api_Result_Handler:Android.Gms.Common.Apis.IResultCallbackInvoker, Xamarin.GooglePlayServices.Basement")]
		void OnResult(Java.Lang.Object result);
	}
	[Register("com/google/android/gms/common/api/ResultCallback", DoNotGenerateAcw = true)]
	internal class IResultCallbackInvoker : Java.Lang.Object, IResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/ResultCallback", typeof(IResultCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onResult_Lcom_google_android_gms_common_api_Result_;

		private IntPtr id_onResult_Lcom_google_android_gms_common_api_Result_;

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

		public static IResultCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IResultCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.ResultCallback'.");
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

		public IResultCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnResult_Lcom_google_android_gms_common_api_Result_Handler()
		{
			if ((object)cb_onResult_Lcom_google_android_gms_common_api_Result_ == null)
			{
				cb_onResult_Lcom_google_android_gms_common_api_Result_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnResult_Lcom_google_android_gms_common_api_Result_));
			}
			return cb_onResult_Lcom_google_android_gms_common_api_Result_;
		}

		private static void n_OnResult_Lcom_google_android_gms_common_api_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			IResultCallback resultCallback = Java.Lang.Object.GetObject<IResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			resultCallback.OnResult(result);
		}

		public unsafe void OnResult(Java.Lang.Object result)
		{
			if (id_onResult_Lcom_google_android_gms_common_api_Result_ == IntPtr.Zero)
			{
				id_onResult_Lcom_google_android_gms_common_api_Result_ = JNIEnv.GetMethodID(class_ref, "onResult", "(Lcom/google/android/gms/common/api/Result;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onResult_Lcom_google_android_gms_common_api_Result_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/google/android/gms/common/api/Response", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T extends com.google.android.gms.common.api.Result" })]
	public class Response : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Response", typeof(Response));

		private static Delegate cb_getResult;

		private static Delegate cb_setResult_Lcom_google_android_gms_common_api_Result_;

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

		protected unsafe virtual Java.Lang.Object Result
		{
			[Register("getResult", "()Lcom/google/android/gms/common/api/Result;", "GetGetResultHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResult.()Lcom/google/android/gms/common/api/Result;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Response(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Response()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/Result;)V", "")]
		protected unsafe Response(Java.Lang.Object result)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/Result;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/Result;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetGetResultHandler()
		{
			if ((object)cb_getResult == null)
			{
				cb_getResult = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResult));
			}
			return cb_getResult;
		}

		private static IntPtr n_GetResult(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Response>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Result);
		}

		private static Delegate GetSetResult_Lcom_google_android_gms_common_api_Result_Handler()
		{
			if ((object)cb_setResult_Lcom_google_android_gms_common_api_Result_ == null)
			{
				cb_setResult_Lcom_google_android_gms_common_api_Result_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetResult_Lcom_google_android_gms_common_api_Result_));
			}
			return cb_setResult_Lcom_google_android_gms_common_api_Result_;
		}

		private static void n_SetResult_Lcom_google_android_gms_common_api_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			Response response = Java.Lang.Object.GetObject<Response>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			response.SetResult(result);
		}

		[Register("setResult", "(Lcom/google/android/gms/common/api/Result;)V", "GetSetResult_Lcom_google_android_gms_common_api_Result_Handler")]
		public unsafe virtual void SetResult(Java.Lang.Object result)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setResult.(Lcom/google/android/gms/common/api/Result;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}
	}
	[Register("com/google/android/gms/common/api/ResultCallbacks", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "R extends com.google.android.gms.common.api.Result" })]
	public abstract class ResultCallbacks : Java.Lang.Object, IResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/ResultCallbacks", typeof(ResultCallbacks));

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

		protected ResultCallbacks(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ResultCallbacks()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnFailure_Lcom_google_android_gms_common_api_Status_Handler()
		{
			if ((object)cb_onFailure_Lcom_google_android_gms_common_api_Status_ == null)
			{
				cb_onFailure_Lcom_google_android_gms_common_api_Status_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Lcom_google_android_gms_common_api_Status_));
			}
			return cb_onFailure_Lcom_google_android_gms_common_api_Status_;
		}

		private static void n_OnFailure_Lcom_google_android_gms_common_api_Status_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ResultCallbacks resultCallbacks = Java.Lang.Object.GetObject<ResultCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Statuses p = Java.Lang.Object.GetObject<Statuses>(native_p0, JniHandleOwnership.DoNotTransfer);
			resultCallbacks.OnFailure(p);
		}

		[Register("onFailure", "(Lcom/google/android/gms/common/api/Status;)V", "GetOnFailure_Lcom_google_android_gms_common_api_Status_Handler")]
		public abstract void OnFailure(Statuses p0);

		[Register("onResult", "(Lcom/google/android/gms/common/api/Result;)V", "")]
		public unsafe void OnResult(Java.Lang.Object result)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onResult.(Lcom/google/android/gms/common/api/Result;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler()
		{
			if ((object)cb_onSuccess_Lcom_google_android_gms_common_api_Result_ == null)
			{
				cb_onSuccess_Lcom_google_android_gms_common_api_Result_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Lcom_google_android_gms_common_api_Result_));
			}
			return cb_onSuccess_Lcom_google_android_gms_common_api_Result_;
		}

		private static void n_OnSuccess_Lcom_google_android_gms_common_api_Result_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ResultCallbacks resultCallbacks = Java.Lang.Object.GetObject<ResultCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			resultCallbacks.OnSuccess(p);
		}

		[Register("onSuccess", "(Lcom/google/android/gms/common/api/Result;)V", "GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler")]
		public abstract void OnSuccess(Java.Lang.Object p0);
	}
	[Register("com/google/android/gms/common/api/ResultCallbacks", DoNotGenerateAcw = true)]
	internal class ResultCallbacksInvoker : ResultCallbacks, IResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/ResultCallbacks", typeof(ResultCallbacksInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ResultCallbacksInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onFailure", "(Lcom/google/android/gms/common/api/Status;)V", "GetOnFailure_Lcom_google_android_gms_common_api_Status_Handler")]
		public unsafe override void OnFailure(Statuses p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onFailure.(Lcom/google/android/gms/common/api/Status;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("onSuccess", "(Lcom/google/android/gms/common/api/Result;)V", "GetOnSuccess_Lcom_google_android_gms_common_api_Result_Handler")]
		public unsafe override void OnSuccess(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onSuccess.(Lcom/google/android/gms/common/api/Result;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/Scope", DoNotGenerateAcw = true)]
	public sealed class Scope : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Scope", typeof(Scope));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string ScopeUri
		{
			[Register("getScopeUri", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getScopeUri.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Scope(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Scope(string scopeUri)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(scopeUri);
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

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}
	}
	[Register("com/google/android/gms/common/api/Status", DoNotGenerateAcw = true)]
	public sealed class Statuses : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/Status", typeof(Statuses));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_CANCELED")]
		public static Statuses ResultCanceled => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_CANCELED.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_DEAD_CLIENT")]
		public static Statuses ResultDeadClient => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_DEAD_CLIENT.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_INTERNAL_ERROR")]
		public static Statuses ResultInternalError => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_INTERNAL_ERROR.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_INTERRUPTED")]
		public static Statuses ResultInterrupted => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_INTERRUPTED.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_SUCCESS")]
		public static Statuses ResultSuccess => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_SUCCESS.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_SUCCESS_CACHE")]
		public static Statuses ResultSuccessCache => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_SUCCESS_CACHE.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESULT_TIMEOUT")]
		public static Statuses ResultTimeout => Java.Lang.Object.GetObject<Statuses>(_members.StaticFields.GetObjectValue("RESULT_TIMEOUT.Lcom/google/android/gms/common/api/Status;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe ConnectionResult ConnectionResult
		{
			[Register("getConnectionResult", "()Lcom/google/android/gms/common/ConnectionResult;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ConnectionResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConnectionResult.()Lcom/google/android/gms/common/ConnectionResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool HasResolution
		{
			[Register("hasResolution", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasResolution.()Z", this, null);
			}
		}

		public unsafe bool IsCanceled
		{
			[Register("isCanceled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCanceled.()Z", this, null);
			}
		}

		public unsafe bool IsInterrupted
		{
			[Register("isInterrupted", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isInterrupted.()Z", this, null);
			}
		}

		public unsafe bool IsSuccess
		{
			[Register("isSuccess", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSuccess.()Z", this, null);
			}
		}

		public unsafe PendingIntent Resolution
		{
			[Register("getResolution", "()Landroid/app/PendingIntent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolution.()Landroid/app/PendingIntent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Statuses Status
		{
			[Register("getStatus", "()Lcom/google/android/gms/common/api/Status;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Statuses>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStatus.()Lcom/google/android/gms/common/api/Status;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int StatusCode
		{
			[Register("getStatusCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStatusCode.()I", this, null);
			}
		}

		public unsafe string StatusMessage
		{
			[Register("getStatusMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getStatusMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Statuses(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;)V", "")]
		public unsafe Statuses(ConnectionResult connectionResult, string statusMessage)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(statusMessage);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(connectionResult?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(connectionResult);
			}
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;I)V", "")]
		public unsafe Statuses(ConnectionResult connectionResult, string statusMessage, int statusCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(statusMessage);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(connectionResult?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(statusCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/ConnectionResult;Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(connectionResult);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe Statuses(int statusCode)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(statusCode);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		[Register(".ctor", "(ILjava/lang/String;)V", "")]
		public unsafe Statuses(int statusCode, string statusMessage)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(statusMessage);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(statusCode);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(ILjava/lang/String;Landroid/app/PendingIntent;)V", "")]
		public unsafe Statuses(int statusCode, string statusMessage, PendingIntent pendingIntent)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(statusMessage);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(statusCode);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/String;Landroid/app/PendingIntent;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/String;Landroid/app/PendingIntent;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(pendingIntent);
			}
		}

		[Register("startResolutionForResult", "(Landroid/app/Activity;I)V", "")]
		public unsafe void StartResolutionForResult(Activity activity, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startResolutionForResult.(Landroid/app/Activity;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe void WriteToParcel(Parcel @out, int flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
}
namespace Android.Gms.Common.Apis.Internal
{
	[Register("com/google/android/gms/common/api/internal/LifecycleFragment", "", "Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker")]
	public interface ILifecycleFragment : IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsCreated
		{
			[Register("isCreated", "()Z", "GetIsCreatedHandler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
			get;
		}

		bool IsStarted
		{
			[Register("isStarted", "()Z", "GetIsStartedHandler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
			get;
		}

		Activity LifecycleActivity
		{
			[Register("getLifecycleActivity", "()Landroid/app/Activity;", "GetGetLifecycleActivityHandler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
			get;
		}

		[Register("addCallback", "(Ljava/lang/String;Lcom/google/android/gms/common/api/internal/LifecycleCallback;)V", "GetAddCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_Handler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
		void AddCallback(string p0, LifecycleCallback p1);

		[Register("getCallbackOrNull", "(Ljava/lang/String;Ljava/lang/Class;)Lcom/google/android/gms/common/api/internal/LifecycleCallback;", "GetGetCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_Handler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
		[JavaTypeParameters(new string[] { "T extends com.google.android.gms.common.api.internal.LifecycleCallback" })]
		Java.Lang.Object GetCallbackOrNull(string p0, Class p1);

		[Register("startActivityForResult", "(Landroid/content/Intent;I)V", "GetStartActivityForResult_Landroid_content_Intent_IHandler:Android.Gms.Common.Apis.Internal.ILifecycleFragmentInvoker, Xamarin.GooglePlayServices.Basement")]
		void StartActivityForResult(Intent p0, int p1);
	}
	[Register("com/google/android/gms/common/api/internal/LifecycleFragment", DoNotGenerateAcw = true)]
	internal class ILifecycleFragmentInvoker : Java.Lang.Object, ILifecycleFragment, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/LifecycleFragment", typeof(ILifecycleFragmentInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isCreated;

		private IntPtr id_isCreated;

		private static Delegate cb_isStarted;

		private IntPtr id_isStarted;

		private static Delegate cb_getLifecycleActivity;

		private IntPtr id_getLifecycleActivity;

		private static Delegate cb_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_;

		private IntPtr id_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_;

		private static Delegate cb_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_;

		private IntPtr id_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_;

		private static Delegate cb_startActivityForResult_Landroid_content_Intent_I;

		private IntPtr id_startActivityForResult_Landroid_content_Intent_I;

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

		public bool IsCreated
		{
			get
			{
				if (id_isCreated == IntPtr.Zero)
				{
					id_isCreated = JNIEnv.GetMethodID(class_ref, "isCreated", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCreated);
			}
		}

		public bool IsStarted
		{
			get
			{
				if (id_isStarted == IntPtr.Zero)
				{
					id_isStarted = JNIEnv.GetMethodID(class_ref, "isStarted", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isStarted);
			}
		}

		public Activity LifecycleActivity
		{
			get
			{
				if (id_getLifecycleActivity == IntPtr.Zero)
				{
					id_getLifecycleActivity = JNIEnv.GetMethodID(class_ref, "getLifecycleActivity", "()Landroid/app/Activity;");
				}
				return Java.Lang.Object.GetObject<Activity>(JNIEnv.CallObjectMethod(base.Handle, id_getLifecycleActivity), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ILifecycleFragment GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILifecycleFragment>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.LifecycleFragment'.");
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

		public ILifecycleFragmentInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsCreatedHandler()
		{
			if ((object)cb_isCreated == null)
			{
				cb_isCreated = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCreated));
			}
			return cb_isCreated;
		}

		private static bool n_IsCreated(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCreated;
		}

		private static Delegate GetIsStartedHandler()
		{
			if ((object)cb_isStarted == null)
			{
				cb_isStarted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStarted));
			}
			return cb_isStarted;
		}

		private static bool n_IsStarted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStarted;
		}

		private static Delegate GetGetLifecycleActivityHandler()
		{
			if ((object)cb_getLifecycleActivity == null)
			{
				cb_getLifecycleActivity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLifecycleActivity));
			}
			return cb_getLifecycleActivity;
		}

		private static IntPtr n_GetLifecycleActivity(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LifecycleActivity);
		}

		private static Delegate GetAddCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_Handler()
		{
			if ((object)cb_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_ == null)
			{
				cb_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_));
			}
			return cb_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_;
		}

		private static void n_AddCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILifecycleFragment lifecycleFragment = Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			LifecycleCallback p2 = Java.Lang.Object.GetObject<LifecycleCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			lifecycleFragment.AddCallback(p, p2);
		}

		public unsafe void AddCallback(string p0, LifecycleCallback p1)
		{
			if (id_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_ == IntPtr.Zero)
			{
				id_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_ = JNIEnv.GetMethodID(class_ref, "addCallback", "(Ljava/lang/String;Lcom/google/android/gms/common/api/internal/LifecycleCallback;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_addCallback_Ljava_lang_String_Lcom_google_android_gms_common_api_internal_LifecycleCallback_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetGetCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_Handler()
		{
			if ((object)cb_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_ == null)
			{
				cb_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_));
			}
			return cb_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_;
		}

		private static IntPtr n_GetCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ILifecycleFragment lifecycleFragment = Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Class p2 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(lifecycleFragment.GetCallbackOrNull(p, p2));
		}

		public unsafe Java.Lang.Object GetCallbackOrNull(string p0, Class p1)
		{
			if (id_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_ == IntPtr.Zero)
			{
				id_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_ = JNIEnv.GetMethodID(class_ref, "getCallbackOrNull", "(Ljava/lang/String;Ljava/lang/Class;)Lcom/google/android/gms/common/api/internal/LifecycleCallback;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getCallbackOrNull_Ljava_lang_String_Ljava_lang_Class_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetStartActivityForResult_Landroid_content_Intent_IHandler()
		{
			if ((object)cb_startActivityForResult_Landroid_content_Intent_I == null)
			{
				cb_startActivityForResult_Landroid_content_Intent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_StartActivityForResult_Landroid_content_Intent_I));
			}
			return cb_startActivityForResult_Landroid_content_Intent_I;
		}

		private static void n_StartActivityForResult_Landroid_content_Intent_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			ILifecycleFragment lifecycleFragment = Java.Lang.Object.GetObject<ILifecycleFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent p2 = Java.Lang.Object.GetObject<Intent>(native_p0, JniHandleOwnership.DoNotTransfer);
			lifecycleFragment.StartActivityForResult(p2, p1);
		}

		public unsafe void StartActivityForResult(Intent p0, int p1)
		{
			if (id_startActivityForResult_Landroid_content_Intent_I == IntPtr.Zero)
			{
				id_startActivityForResult_Landroid_content_Intent_I = JNIEnv.GetMethodID(class_ref, "startActivityForResult", "(Landroid/content/Intent;I)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_startActivityForResult_Landroid_content_Intent_I, ptr);
		}
	}
	[Register("com/google/android/gms/common/api/internal/StatusExceptionMapper", "", "Android.Gms.Common.Apis.Internal.IStatusExceptionMapperInvoker")]
	public interface IStatusExceptionMapper : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("getException", "(Lcom/google/android/gms/common/api/Status;)Ljava/lang/Exception;", "GetGetException_Lcom_google_android_gms_common_api_Status_Handler:Android.Gms.Common.Apis.Internal.IStatusExceptionMapperInvoker, Xamarin.GooglePlayServices.Basement")]
		Java.Lang.Exception GetException(Statuses p0);
	}
	[Register("com/google/android/gms/common/api/internal/StatusExceptionMapper", DoNotGenerateAcw = true)]
	internal class IStatusExceptionMapperInvoker : Java.Lang.Object, IStatusExceptionMapper, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/StatusExceptionMapper", typeof(IStatusExceptionMapperInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getException_Lcom_google_android_gms_common_api_Status_;

		private IntPtr id_getException_Lcom_google_android_gms_common_api_Status_;

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

		public static IStatusExceptionMapper GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStatusExceptionMapper>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.common.api.internal.StatusExceptionMapper'.");
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

		public IStatusExceptionMapperInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetException_Lcom_google_android_gms_common_api_Status_Handler()
		{
			if ((object)cb_getException_Lcom_google_android_gms_common_api_Status_ == null)
			{
				cb_getException_Lcom_google_android_gms_common_api_Status_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetException_Lcom_google_android_gms_common_api_Status_));
			}
			return cb_getException_Lcom_google_android_gms_common_api_Status_;
		}

		private static IntPtr n_GetException_Lcom_google_android_gms_common_api_Status_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IStatusExceptionMapper statusExceptionMapper = Java.Lang.Object.GetObject<IStatusExceptionMapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Statuses p = Java.Lang.Object.GetObject<Statuses>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(statusExceptionMapper.GetException(p));
		}

		public unsafe Java.Lang.Exception GetException(Statuses p0)
		{
			if (id_getException_Lcom_google_android_gms_common_api_Status_ == IntPtr.Zero)
			{
				id_getException_Lcom_google_android_gms_common_api_Status_ = JNIEnv.GetMethodID(class_ref, "getException", "(Lcom/google/android/gms/common/api/Status;)Ljava/lang/Exception;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Exception>(JNIEnv.CallObjectMethod(base.Handle, id_getException_Lcom_google_android_gms_common_api_Status_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/common/api/internal/LifecycleActivity", DoNotGenerateAcw = true)]
	public class LifecycleActivity : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/LifecycleActivity", typeof(LifecycleActivity));

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

		protected LifecycleActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe LifecycleActivity(Activity p0)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register(".ctor", "(Landroid/content/ContextWrapper;)V", "")]
		public unsafe LifecycleActivity(ContextWrapper p0)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/ContextWrapper;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/ContextWrapper;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/common/api/internal/LifecycleCallback", DoNotGenerateAcw = true)]
	public class LifecycleCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/common/api/internal/LifecycleCallback", typeof(LifecycleCallback));

		private static Delegate cb_getActivity;

		private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

		private static Delegate cb_onActivityResult_IILandroid_content_Intent_;

		private static Delegate cb_onCreate_Landroid_os_Bundle_;

		private static Delegate cb_onDestroy;

		private static Delegate cb_onResume;

		private static Delegate cb_onSaveInstanceState_Landroid_os_Bundle_;

		private static Delegate cb_onStart;

		private static Delegate cb_onStop;

		[Register("mLifecycleFragment")]
		protected ILifecycleFragment MLifecycleFragment
		{
			get
			{
				return Java.Lang.Object.GetObject<ILifecycleFragment>(_members.InstanceFields.GetObjectValue("mLifecycleFragment.Lcom/google/android/gms/common/api/internal/LifecycleFragment;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mLifecycleFragment.Lcom/google/android/gms/common/api/internal/LifecycleFragment;", this, new JniObjectReference(jobject));
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

		public unsafe virtual Activity Activity
		{
			[Register("getActivity", "()Landroid/app/Activity;", "GetGetActivityHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Activity>(_members.InstanceMethods.InvokeVirtualObjectMethod("getActivity.()Landroid/app/Activity;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LifecycleCallback(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/common/api/internal/LifecycleFragment;)V", "")]
		protected unsafe LifecycleCallback(ILifecycleFragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((fragment == null) ? IntPtr.Zero : ((Java.Lang.Object)fragment).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/internal/LifecycleFragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/internal/LifecycleFragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		private static Delegate GetGetActivityHandler()
		{
			if ((object)cb_getActivity == null)
			{
				cb_getActivity = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActivity));
			}
			return cb_getActivity;
		}

		private static IntPtr n_GetActivity(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Activity);
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
			LifecycleCallback lifecycleCallback = Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			FileDescriptor p2 = Java.Lang.Object.GetObject<FileDescriptor>(native_p1, JniHandleOwnership.DoNotTransfer);
			PrintWriter p3 = Java.Lang.Object.GetObject<PrintWriter>(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			lifecycleCallback.Dump(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
			}
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public unsafe virtual void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3)
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
				_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
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

		[Register("getFragment", "(Landroid/app/Activity;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", "")]
		public unsafe static ILifecycleFragment GetFragment(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ILifecycleFragment>(_members.StaticMethods.InvokeObjectMethod("getFragment.(Landroid/app/Activity;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register("getFragment", "(Landroid/content/ContextWrapper;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", "")]
		public unsafe static ILifecycleFragment GetFragment(ContextWrapper p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ILifecycleFragment>(_members.StaticMethods.InvokeObjectMethod("getFragment.(Landroid/content/ContextWrapper;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("getFragment", "(Lcom/google/android/gms/common/api/internal/LifecycleActivity;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", "")]
		protected unsafe static ILifecycleFragment GetFragment(LifecycleActivity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ILifecycleFragment>(_members.StaticMethods.InvokeObjectMethod("getFragment.(Lcom/google/android/gms/common/api/internal/LifecycleActivity;)Lcom/google/android/gms/common/api/internal/LifecycleFragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		private static Delegate GetOnActivityResult_IILandroid_content_Intent_Handler()
		{
			if ((object)cb_onActivityResult_IILandroid_content_Intent_ == null)
			{
				cb_onActivityResult_IILandroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIL_V(n_OnActivityResult_IILandroid_content_Intent_));
			}
			return cb_onActivityResult_IILandroid_content_Intent_;
		}

		private static void n_OnActivityResult_IILandroid_content_Intent_(IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2)
		{
			LifecycleCallback lifecycleCallback = Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent p2 = Java.Lang.Object.GetObject<Intent>(native_p2, JniHandleOwnership.DoNotTransfer);
			lifecycleCallback.OnActivityResult(p0, p1, p2);
		}

		[Register("onActivityResult", "(IILandroid/content/Intent;)V", "GetOnActivityResult_IILandroid_content_Intent_Handler")]
		public unsafe virtual void OnActivityResult(int p0, int p1, Intent p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityResult.(IILandroid/content/Intent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetOnCreate_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onCreate_Landroid_os_Bundle_ == null)
			{
				cb_onCreate_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCreate_Landroid_os_Bundle_));
			}
			return cb_onCreate_Landroid_os_Bundle_;
		}

		private static void n_OnCreate_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			LifecycleCallback lifecycleCallback = Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
			lifecycleCallback.OnCreate(p);
		}

		[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnCreate(Bundle p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
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
			Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
		}

		[Register("onDestroy", "()V", "GetOnDestroyHandler")]
		public unsafe virtual void OnDestroy()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.()V", this, null);
		}

		private static Delegate GetOnResumeHandler()
		{
			if ((object)cb_onResume == null)
			{
				cb_onResume = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnResume));
			}
			return cb_onResume;
		}

		private static void n_OnResume(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResume();
		}

		[Register("onResume", "()V", "GetOnResumeHandler")]
		public unsafe virtual void OnResume()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onResume.()V", this, null);
		}

		private static Delegate GetOnSaveInstanceState_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_onSaveInstanceState_Landroid_os_Bundle_ == null)
			{
				cb_onSaveInstanceState_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSaveInstanceState_Landroid_os_Bundle_));
			}
			return cb_onSaveInstanceState_Landroid_os_Bundle_;
		}

		private static void n_OnSaveInstanceState_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			LifecycleCallback lifecycleCallback = Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
			lifecycleCallback.OnSaveInstanceState(p);
		}

		[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "GetOnSaveInstanceState_Landroid_os_Bundle_Handler")]
		public unsafe virtual void OnSaveInstanceState(Bundle p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnStartHandler()
		{
			if ((object)cb_onStart == null)
			{
				cb_onStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStart));
			}
			return cb_onStart;
		}

		private static void n_OnStart(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		public unsafe virtual void OnStart()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
		}

		private static Delegate GetOnStopHandler()
		{
			if ((object)cb_onStop == null)
			{
				cb_onStop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStop));
			}
			return cb_onStop;
		}

		private static void n_OnStop(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LifecycleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
		}

		[Register("onStop", "()V", "GetOnStopHandler")]
		public unsafe virtual void OnStop()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.()V", this, null);
		}
	}
}
