using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "fb4985bc40adce1eed066f366d7905c21957aac8")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220414.6")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "4/14/2022 7:04:25 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.android.gms.ads.identifier", Managed = "Google.Ads.Identifier")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Ads.Identifier 117.0.1.5 artifact=com.google.android.gms:play-services-ads-identifier artifact_versioned=com.google.android.gms:play-services-ads-identifier:17.0.1\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Ads.Identifier")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Ads.Identifier")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
namespace Google.Ads.Identifier;

[Register("com/google/android/gms/ads/identifier/AdvertisingIdClient", DoNotGenerateAcw = true)]
public class AdvertisingIdClient : Java.Lang.Object
{
	[Register("com/google/android/gms/ads/identifier/AdvertisingIdClient$Info", DoNotGenerateAcw = true)]
	public sealed class Info : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/ads/identifier/AdvertisingIdClient$Info", typeof(Info));

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

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsLimitAdTrackingEnabled
		{
			[Register("isLimitAdTrackingEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isLimitAdTrackingEnabled.()Z", this, null);
			}
		}

		internal Info(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Z)V", "")]
		public unsafe Info(string advertisingId, bool limitAdTrackingEnabled)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(advertisingId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(limitAdTrackingEnabled);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Z)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/ads/identifier/AdvertisingIdClient", typeof(AdvertisingIdClient));

	private static Delegate cb_getInfo;

	private static Delegate cb_start;

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

	protected AdvertisingIdClient(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe AdvertisingIdClient(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;JZZ)V", "")]
	public unsafe AdvertisingIdClient(Context p0, long p1, bool p2, bool p3)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;JZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;JZZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("getAdvertisingIdInfo", "(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;", "")]
	public unsafe static Info GetAdvertisingIdInfo(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Info>(_members.StaticMethods.InvokeObjectMethod("getAdvertisingIdInfo.(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetInfoHandler()
	{
		if ((object)cb_getInfo == null)
		{
			cb_getInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInfo));
		}
		return cb_getInfo;
	}

	private static IntPtr n_GetInfo(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AdvertisingIdClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInfo());
	}

	[Register("getInfo", "()Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;", "GetGetInfoHandler")]
	public unsafe virtual Info GetInfo()
	{
		return Java.Lang.Object.GetObject<Info>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInfo.()Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getIsAdIdFakeForDebugLogging", "(Landroid/content/Context;)Z", "")]
	public unsafe static bool GetIsAdIdFakeForDebugLogging(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("getIsAdIdFakeForDebugLogging.(Landroid/content/Context;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("setShouldSkipGmsCoreVersionCheck", "(Z)V", "")]
	public unsafe static void SetShouldSkipGmsCoreVersionCheck(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.StaticMethods.InvokeVoidMethod("setShouldSkipGmsCoreVersionCheck.(Z)V", ptr);
	}

	private static Delegate GetStartHandler()
	{
		if ((object)cb_start == null)
		{
			cb_start = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Start));
		}
		return cb_start;
	}

	private static void n_Start(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<AdvertisingIdClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
	}

	[Register("start", "()V", "GetStartHandler")]
	public unsafe virtual void Start()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("start.()V", this, null);
	}

	[Register("zza", "()V", "")]
	public unsafe void Zza()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("zza.()V", this, null);
	}

	[Register("zzb", "(Z)V", "")]
	protected unsafe void Zzb(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("zzb.(Z)V", this, ptr);
	}
}
