using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Java.Util;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("DfuAndroidLibrary")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("${AuthorCopyright}")]
[assembly: AssemblyTrademark("")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.dfu", Managed = "NO.Nordicsemi.Android.Dfu")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.dfu.internal", Managed = "NO.Nordicsemi.Android.Dfu.Internal")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.dfu.internal.exception", Managed = "NO.Nordicsemi.Android.Dfu.Internal.Exception")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.dfu.internal.manifest", Managed = "NO.Nordicsemi.Android.Dfu.Internal.Manifest")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.dfu.internal.scanner", Managed = "NO.Nordicsemi.Android.Dfu.Internal.Scanner")]
[assembly: NamespaceMapping(Java = "no.nordicsemi.android.error", Managed = "NO.Nordicsemi.Android.Error")]
[assembly: TargetFramework("MonoAndroid,Version=v10.0", FrameworkDisplayName = "Xamarin.Android v10.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.3.0.2")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLIFFII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, float p2, float p3, int p4, int p5);
internal delegate void _JniMarshal_PPLIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLILLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2, IntPtr p3, IntPtr p4);
internal delegate IntPtr _JniMarshal_PPLJ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
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
namespace NO.Nordicsemi.Android.Error
{
	[Register("no/nordicsemi/android/error/GattError", DoNotGenerateAcw = true)]
	public class GattError : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/error/GattError", typeof(GattError));

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

		protected GattError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GattError()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(I)Ljava/lang/String;", "")]
		public unsafe static string Parse(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parse.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parseConnectionError", "(I)Ljava/lang/String;", "")]
		public unsafe static string ParseConnectionError(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parseConnectionError.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parseDfuRemoteError", "(I)Ljava/lang/String;", "")]
		public unsafe static string ParseDfuRemoteError(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parseDfuRemoteError.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("no/nordicsemi/android/error/LegacyDfuError", DoNotGenerateAcw = true)]
	public sealed class LegacyDfuError : Java.Lang.Object
	{
		[Register("CRC_ERROR")]
		public const int CrcError = 5;

		[Register("DATA_SIZE_EXCEEDS_LIMIT")]
		public const int DataSizeExceedsLimit = 4;

		[Register("INVALID_STATE")]
		public const int InvalidState = 2;

		[Register("NOT_SUPPORTED")]
		public const int NotSupported = 3;

		[Register("OPERATION_FAILED")]
		public const int OperationFailed = 6;

		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/error/LegacyDfuError", typeof(LegacyDfuError));

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

		internal LegacyDfuError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LegacyDfuError()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(I)Ljava/lang/String;", "")]
		public unsafe static string Parse(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parse.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("no/nordicsemi/android/error/SecureDfuError", DoNotGenerateAcw = true)]
	public sealed class SecureDfuError : Java.Lang.Object
	{
		[Register("BUTTONLESS_ERROR_OPERATION_FAILED")]
		public const int ButtonlessErrorOperationFailed = 4;

		[Register("BUTTONLESS_ERROR_OP_CODE_NOT_SUPPORTED")]
		public const int ButtonlessErrorOpCodeNotSupported = 2;

		[Register("EXTENDED_ERROR")]
		public const int ExtendedError = 11;

		[Register("EXT_ERROR_FW_VERSION_FAILURE")]
		public const int ExtErrorFwVersionFailure = 5;

		[Register("EXT_ERROR_HASH_FAILED")]
		public const int ExtErrorHashFailed = 10;

		[Register("EXT_ERROR_HW_VERSION_FAILURE")]
		public const int ExtErrorHwVersionFailure = 6;

		[Register("EXT_ERROR_INIT_COMMAND_INVALID")]
		public const int ExtErrorInitCommandInvalid = 4;

		[Register("EXT_ERROR_INSUFFICIENT_SPACE")]
		public const int ExtErrorInsufficientSpace = 13;

		[Register("EXT_ERROR_SD_VERSION_FAILURE")]
		public const int ExtErrorSdVersionFailure = 7;

		[Register("EXT_ERROR_SIGNATURE_MISSING")]
		public const int ExtErrorSignatureMissing = 8;

		[Register("EXT_ERROR_UNKNOWN_COMMAND")]
		public const int ExtErrorUnknownCommand = 3;

		[Register("EXT_ERROR_VERIFICATION_FAILED")]
		public const int ExtErrorVerificationFailed = 12;

		[Register("EXT_ERROR_WRONG_COMMAND_FORMAT")]
		public const int ExtErrorWrongCommandFormat = 2;

		[Register("EXT_ERROR_WRONG_HASH_TYPE")]
		public const int ExtErrorWrongHashType = 9;

		[Register("EXT_ERROR_WRONG_SIGNATURE_TYPE")]
		public const int ExtErrorWrongSignatureType = 11;

		[Register("INSUFFICIENT_RESOURCES")]
		public const int InsufficientResources = 4;

		[Register("INVALID_OBJECT")]
		public const int InvalidObject = 5;

		[Register("INVALID_PARAM")]
		public const int InvalidParam = 3;

		[Register("OPERATION_FAILED")]
		public const int OperationFailed = 10;

		[Register("OPERATION_NOT_PERMITTED")]
		public const int OperationNotPermitted = 8;

		[Register("OP_CODE_NOT_SUPPORTED")]
		public const int OpCodeNotSupported = 2;

		[Register("UNSUPPORTED_TYPE")]
		public const int UnsupportedType = 7;

		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/error/SecureDfuError", typeof(SecureDfuError));

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

		internal SecureDfuError(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SecureDfuError()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("parse", "(I)Ljava/lang/String;", "")]
		public unsafe static string Parse(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parse.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parseButtonlessError", "(I)Ljava/lang/String;", "")]
		public unsafe static string ParseButtonlessError(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parseButtonlessError.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("parseExtendedError", "(I)Ljava/lang/String;", "")]
		public unsafe static string ParseExtendedError(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("parseExtendedError.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace NO.Nordicsemi.Android.Dfu
{
	[Register("no/nordicsemi/android/dfu/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "debug";

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "no.nordicsemi.android.dfu";

		[Register("VERSION_CODE")]
		public const string VersionCode = "232711";

		[Register("VERSION_NAME")]
		public const string VersionName = "debug";

		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/BuildConfig", typeof(BuildConfig));

		[Register("DEBUG")]
		public static bool Debug => _members.StaticFields.GetBooleanValue("DEBUG.Z");

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
	[Register("no/nordicsemi/android/dfu/DfuActivity", DoNotGenerateAcw = true)]
	public class DfuActivity : Activity
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuActivity", typeof(DfuActivity));

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

		protected DfuActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DfuActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuListener", DoNotGenerateAcw = true)]
	public class DfuListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuListener", typeof(DfuListener));

		private static Delegate cb_onStateChanged_Lno_nordicsemi_android_dfu_DfuState_;

		private static Delegate cb_onUploadProgressChanged_I;

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

		protected DfuListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DfuListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnStateChanged_Lno_nordicsemi_android_dfu_DfuState_Handler()
		{
			if ((object)cb_onStateChanged_Lno_nordicsemi_android_dfu_DfuState_ == null)
			{
				cb_onStateChanged_Lno_nordicsemi_android_dfu_DfuState_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnStateChanged_Lno_nordicsemi_android_dfu_DfuState_));
			}
			return cb_onStateChanged_Lno_nordicsemi_android_dfu_DfuState_;
		}

		private static void n_OnStateChanged_Lno_nordicsemi_android_dfu_DfuState_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuListener dfuListener = Java.Lang.Object.GetObject<DfuListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DfuState p = Java.Lang.Object.GetObject<DfuState>(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuListener.OnStateChanged(p);
		}

		[Register("onStateChanged", "(Lno/nordicsemi/android/dfu/DfuState;)V", "GetOnStateChanged_Lno_nordicsemi_android_dfu_DfuState_Handler")]
		public unsafe virtual void OnStateChanged(DfuState p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onStateChanged.(Lno/nordicsemi/android/dfu/DfuState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnUploadProgressChanged_IHandler()
		{
			if ((object)cb_onUploadProgressChanged_I == null)
			{
				cb_onUploadProgressChanged_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnUploadProgressChanged_I));
			}
			return cb_onUploadProgressChanged_I;
		}

		private static void n_OnUploadProgressChanged_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			DfuListener dfuListener = Java.Lang.Object.GetObject<DfuListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuListener.OnUploadProgressChanged(p0);
		}

		[Register("onUploadProgressChanged", "(I)V", "GetOnUploadProgressChanged_IHandler")]
		public unsafe virtual void OnUploadProgressChanged(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onUploadProgressChanged.(I)V", this, ptr);
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuProgressListenerAdapter", DoNotGenerateAcw = true)]
	public class DfuProgressListenerAdapter : Java.Lang.Object, IDfuProgressListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuProgressListenerAdapter", typeof(DfuProgressListenerAdapter));

		private static Delegate cb_onDeviceConnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceConnecting_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnecting_Ljava_lang_String_;

		private static Delegate cb_onDfuAborted_Ljava_lang_String_;

		private static Delegate cb_onDfuCompleted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarting_Ljava_lang_String_;

		private static Delegate cb_onEnablingDfuMode_Ljava_lang_String_;

		private static Delegate cb_onError_Ljava_lang_String_IILjava_lang_String_;

		private static Delegate cb_onFirmwareValidating_Ljava_lang_String_;

		private static Delegate cb_onProgressChanged_Ljava_lang_String_IFFII;

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

		protected DfuProgressListenerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DfuProgressListenerAdapter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnDeviceConnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnected_Ljava_lang_String_));
			}
			return cb_onDeviceConnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDeviceConnected(p);
		}

		[Register("onDeviceConnected", "(Ljava/lang/String;)V", "GetOnDeviceConnected_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceConnected(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceConnected.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceConnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnecting_Ljava_lang_String_));
			}
			return cb_onDeviceConnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDeviceConnecting(p);
		}

		[Register("onDeviceConnecting", "(Ljava/lang/String;)V", "GetOnDeviceConnecting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceConnecting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceConnecting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceDisconnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnected_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDeviceDisconnected(p);
		}

		[Register("onDeviceDisconnected", "(Ljava/lang/String;)V", "GetOnDeviceDisconnected_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceDisconnected(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceDisconnected.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceDisconnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnecting_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDeviceDisconnecting(p);
		}

		[Register("onDeviceDisconnecting", "(Ljava/lang/String;)V", "GetOnDeviceDisconnecting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceDisconnecting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceDisconnecting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuAborted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuAborted_Ljava_lang_String_ == null)
			{
				cb_onDfuAborted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuAborted_Ljava_lang_String_));
			}
			return cb_onDfuAborted_Ljava_lang_String_;
		}

		private static void n_OnDfuAborted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDfuAborted(p);
		}

		[Register("onDfuAborted", "(Ljava/lang/String;)V", "GetOnDfuAborted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuAborted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuAborted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuCompleted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuCompleted_Ljava_lang_String_ == null)
			{
				cb_onDfuCompleted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuCompleted_Ljava_lang_String_));
			}
			return cb_onDfuCompleted_Ljava_lang_String_;
		}

		private static void n_OnDfuCompleted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDfuCompleted(p);
		}

		[Register("onDfuCompleted", "(Ljava/lang/String;)V", "GetOnDfuCompleted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuCompleted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuCompleted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuProcessStarted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarted_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarted_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarted_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDfuProcessStarted(p);
		}

		[Register("onDfuProcessStarted", "(Ljava/lang/String;)V", "GetOnDfuProcessStarted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuProcessStarted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuProcessStarted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuProcessStarting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarting_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarting_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarting_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnDfuProcessStarting(p);
		}

		[Register("onDfuProcessStarting", "(Ljava/lang/String;)V", "GetOnDfuProcessStarting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuProcessStarting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuProcessStarting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnEnablingDfuMode_Ljava_lang_String_Handler()
		{
			if ((object)cb_onEnablingDfuMode_Ljava_lang_String_ == null)
			{
				cb_onEnablingDfuMode_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnEnablingDfuMode_Ljava_lang_String_));
			}
			return cb_onEnablingDfuMode_Ljava_lang_String_;
		}

		private static void n_OnEnablingDfuMode_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnEnablingDfuMode(p);
		}

		[Register("onEnablingDfuMode", "(Ljava/lang/String;)V", "GetOnEnablingDfuMode_Ljava_lang_String_Handler")]
		public unsafe virtual void OnEnablingDfuMode(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onEnablingDfuMode.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnError_Ljava_lang_String_IILjava_lang_String_Handler()
		{
			if ((object)cb_onError_Ljava_lang_String_IILjava_lang_String_ == null)
			{
				cb_onError_Ljava_lang_String_IILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_V(n_OnError_Ljava_lang_String_IILjava_lang_String_));
			}
			return cb_onError_Ljava_lang_String_IILjava_lang_String_;
		}

		private static void n_OnError_Ljava_lang_String_IILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p3, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnError(p3, p1, p2, p4);
		}

		[Register("onError", "(Ljava/lang/String;IILjava/lang/String;)V", "GetOnError_Ljava_lang_String_IILjava_lang_String_Handler")]
		public unsafe virtual void OnError(string p0, int p1, int p2, string p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onError.(Ljava/lang/String;IILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetOnFirmwareValidating_Ljava_lang_String_Handler()
		{
			if ((object)cb_onFirmwareValidating_Ljava_lang_String_ == null)
			{
				cb_onFirmwareValidating_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFirmwareValidating_Ljava_lang_String_));
			}
			return cb_onFirmwareValidating_Ljava_lang_String_;
		}

		private static void n_OnFirmwareValidating_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnFirmwareValidating(p);
		}

		[Register("onFirmwareValidating", "(Ljava/lang/String;)V", "GetOnFirmwareValidating_Ljava_lang_String_Handler")]
		public unsafe virtual void OnFirmwareValidating(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFirmwareValidating.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnProgressChanged_Ljava_lang_String_IFFIIHandler()
		{
			if ((object)cb_onProgressChanged_Ljava_lang_String_IFFII == null)
			{
				cb_onProgressChanged_Ljava_lang_String_IFFII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIFFII_V(n_OnProgressChanged_Ljava_lang_String_IFFII));
			}
			return cb_onProgressChanged_Ljava_lang_String_IFFII;
		}

		private static void n_OnProgressChanged_Ljava_lang_String_IFFII(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, float p2, float p3, int p4, int p5)
		{
			DfuProgressListenerAdapter dfuProgressListenerAdapter = Java.Lang.Object.GetObject<DfuProgressListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p6 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListenerAdapter.OnProgressChanged(p6, p1, p2, p3, p4, p5);
		}

		[Register("onProgressChanged", "(Ljava/lang/String;IFFII)V", "GetOnProgressChanged_Ljava_lang_String_IFFIIHandler")]
		public unsafe virtual void OnProgressChanged(string p0, int p1, float p2, float p3, int p4, int p5)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onProgressChanged.(Ljava/lang/String;IFFII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Annotation("no.nordicsemi.android.dfu.DfuScope")]
	public class DfuScopeAttribute : Attribute
	{
	}
	[Register("no/nordicsemi/android/dfu/DfuServiceController", DoNotGenerateAcw = true)]
	public class DfuServiceController : Java.Lang.Object, IDfuController, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuServiceController", typeof(DfuServiceController));

		private static Delegate cb_isAborted;

		private static Delegate cb_isPaused;

		private static Delegate cb_abort;

		private static Delegate cb_pause;

		private static Delegate cb_resume;

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

		public unsafe virtual bool IsAborted
		{
			[Register("isAborted", "()Z", "GetIsAbortedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAborted.()Z", this, null);
			}
		}

		public unsafe virtual bool IsPaused
		{
			[Register("isPaused", "()Z", "GetIsPausedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPaused.()Z", this, null);
			}
		}

		protected DfuServiceController(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetIsAbortedHandler()
		{
			if ((object)cb_isAborted == null)
			{
				cb_isAborted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAborted));
			}
			return cb_isAborted;
		}

		private static bool n_IsAborted(IntPtr jnienv, IntPtr native__this)
		{
			DfuServiceController dfuServiceController = Java.Lang.Object.GetObject<DfuServiceController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dfuServiceController.IsAborted;
		}

		private static Delegate GetIsPausedHandler()
		{
			if ((object)cb_isPaused == null)
			{
				cb_isPaused = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPaused));
			}
			return cb_isPaused;
		}

		private static bool n_IsPaused(IntPtr jnienv, IntPtr native__this)
		{
			DfuServiceController dfuServiceController = Java.Lang.Object.GetObject<DfuServiceController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dfuServiceController.IsPaused;
		}

		private static Delegate GetAbortHandler()
		{
			if ((object)cb_abort == null)
			{
				cb_abort = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Abort));
			}
			return cb_abort;
		}

		private static void n_Abort(IntPtr jnienv, IntPtr native__this)
		{
			DfuServiceController dfuServiceController = Java.Lang.Object.GetObject<DfuServiceController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuServiceController.Abort();
		}

		[Register("abort", "()V", "GetAbortHandler")]
		public unsafe virtual void Abort()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("abort.()V", this, null);
		}

		private static Delegate GetPauseHandler()
		{
			if ((object)cb_pause == null)
			{
				cb_pause = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Pause));
			}
			return cb_pause;
		}

		private static void n_Pause(IntPtr jnienv, IntPtr native__this)
		{
			DfuServiceController dfuServiceController = Java.Lang.Object.GetObject<DfuServiceController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuServiceController.Pause();
		}

		[Register("pause", "()V", "GetPauseHandler")]
		public unsafe virtual void Pause()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("pause.()V", this, null);
		}

		private static Delegate GetResumeHandler()
		{
			if ((object)cb_resume == null)
			{
				cb_resume = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Resume));
			}
			return cb_resume;
		}

		private static void n_Resume(IntPtr jnienv, IntPtr native__this)
		{
			DfuServiceController dfuServiceController = Java.Lang.Object.GetObject<DfuServiceController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuServiceController.Resume();
		}

		[Register("resume", "()V", "GetResumeHandler")]
		public unsafe virtual void Resume()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resume.()V", this, null);
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuServiceInitiator", DoNotGenerateAcw = true)]
	public sealed class DfuServiceInitiator : Java.Lang.Object
	{
		[Register("DEFAULT_MBR_SIZE")]
		public const int DefaultMbrSize = 4096;

		[Register("DEFAULT_PRN_VALUE")]
		public const int DefaultPrnValue = 12;

		[Register("DEFAULT_SCAN_TIMEOUT")]
		public const long DefaultScanTimeout = 5000L;

		[Register("SCOPE_APPLICATION")]
		public const int ScopeApplication = 2;

		[Register("SCOPE_SYSTEM_COMPONENTS")]
		public const int ScopeSystemComponents = 1;

		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuServiceInitiator", typeof(DfuServiceInitiator));

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

		internal DfuServiceInitiator(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe DfuServiceInitiator(string p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
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

		[Register("createDfuNotificationChannel", "(Landroid/content/Context;)V", "")]
		public unsafe static void CreateDfuNotificationChannel(Context p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("createDfuNotificationChannel.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("disableMtuRequest", "()Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator DisableMtuRequest()
		{
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableMtuRequest.()Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("disableResume", "()Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator DisableResume()
		{
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("disableResume.()Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setBinOrHex", "(ILandroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetBinOrHex([IntDef(Flag = true, Type = "", Fields = new string[] { "", "", "" })] int p0, global::Android.Net.Uri p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBinOrHex.(ILandroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
			}
		}

		[Obsolete("deprecated")]
		[Register("setBinOrHex", "(ILandroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetBinOrHex([IntDef(Flag = true, Type = "", Fields = new string[] { "", "", "" })] int p0, global::Android.Net.Uri p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBinOrHex.(ILandroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}

		[Obsolete("deprecated")]
		[Register("setBinOrHex", "(II)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetBinOrHex([IntDef(Flag = true, Type = "", Fields = new string[] { "", "", "" })] int p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBinOrHex.(II)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setBinOrHex", "(ILjava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetBinOrHex([IntDef(Flag = true, Type = "", Fields = new string[] { "", "", "" })] int p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBinOrHex.(ILjava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setCurrentMtu", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCurrentMtu(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCurrentMtu.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setCustomUuidsForButtonlessDfuWithBondSharing", "(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCustomUuidsForButtonlessDfuWithBondSharing(UUID p0, UUID p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomUuidsForButtonlessDfuWithBondSharing.(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("setCustomUuidsForButtonlessDfuWithoutBondSharing", "(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCustomUuidsForButtonlessDfuWithoutBondSharing(UUID p0, UUID p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomUuidsForButtonlessDfuWithoutBondSharing.(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("setCustomUuidsForExperimentalButtonlessDfu", "(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCustomUuidsForExperimentalButtonlessDfu(UUID p0, UUID p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomUuidsForExperimentalButtonlessDfu.(Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("setCustomUuidsForLegacyDfu", "(Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCustomUuidsForLegacyDfu(UUID p0, UUID p1, UUID p2, UUID p3)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomUuidsForLegacyDfu.(Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register("setCustomUuidsForSecureDfu", "(Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetCustomUuidsForSecureDfu(UUID p0, UUID p1, UUID p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCustomUuidsForSecureDfu.(Ljava/util/UUID;Ljava/util/UUID;Ljava/util/UUID;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("setDeviceName", "(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetDeviceName(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDeviceName.(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setDisableNotification", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetDisableNotification(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDisableNotification.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setForceDfu", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetForceDfu(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setForceDfu.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setForceScanningForNewAddressInLegacyDfu", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetForceScanningForNewAddressInLegacyDfu(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setForceScanningForNewAddressInLegacyDfu.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setForeground", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetForeground(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setForeground.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setInitFile", "(Landroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetInitFile(global::Android.Net.Uri p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitFile.(Landroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Obsolete("deprecated")]
		[Register("setInitFile", "(Landroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetInitFile(global::Android.Net.Uri p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitFile.(Landroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		[Obsolete("deprecated")]
		[Register("setInitFile", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetInitFile(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitFile.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("setInitFile", "(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetInitFile(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitFile.(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setKeepBond", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetKeepBond(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setKeepBond.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setMbrSize", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetMbrSize(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMbrSize.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setMtu", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetMtu(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMtu.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setNumberOfRetries", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetNumberOfRetries(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNumberOfRetries.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPacketsReceiptNotificationsEnabled", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetPacketsReceiptNotificationsEnabled(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPacketsReceiptNotificationsEnabled.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPacketsReceiptNotificationsValue", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetPacketsReceiptNotificationsValue(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPacketsReceiptNotificationsValue.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setPrepareDataObjectDelay", "(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetPrepareDataObjectDelay(long p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPrepareDataObjectDelay.(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setRebootTime", "(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetRebootTime(long p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRebootTime.(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setRestoreBond", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetRestoreBond(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRestoreBond.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setScanTimeout", "(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetScanTimeout(long p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setScanTimeout.(J)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setScope", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetScope([IntDef(Flag = true, Type = "NO.Nordicsemi.Android.Dfu.DfuServiceInitiator", Fields = new string[] { "ScopeSystemComponents", "ScopeApplication" })] int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setScope.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setUnsafeExperimentalButtonlessServiceInSecureDfuEnabled", "(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetUnsafeExperimentalButtonlessServiceInSecureDfuEnabled(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUnsafeExperimentalButtonlessServiceInSecureDfuEnabled.(Z)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setZip", "(Landroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetZip(global::Android.Net.Uri p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZip.(Landroid/net/Uri;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setZip", "(Landroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetZip(global::Android.Net.Uri p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZip.(Landroid/net/Uri;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		[Register("setZip", "(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetZip(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZip.(I)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setZip", "(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", "")]
		public unsafe DfuServiceInitiator SetZip(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceInitiator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZip.(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceInitiator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("start", "(Landroid/content/Context;Ljava/lang/Class;)Lno/nordicsemi/android/dfu/DfuServiceController;", "")]
		public unsafe DfuServiceController Start(Context p0, Class p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DfuServiceController>(_members.InstanceMethods.InvokeAbstractObjectMethod("start.(Landroid/content/Context;Ljava/lang/Class;)Lno/nordicsemi/android/dfu/DfuServiceController;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuServiceListenerHelper", DoNotGenerateAcw = true)]
	public class DfuServiceListenerHelper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuServiceListenerHelper", typeof(DfuServiceListenerHelper));

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

		protected DfuServiceListenerHelper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DfuServiceListenerHelper()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("registerLogListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;)V", "")]
		public unsafe static void RegisterLogListener(Context p0, IDfuLogListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.StaticMethods.InvokeVoidMethod("registerLogListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("registerLogListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;Ljava/lang/String;)V", "")]
		public unsafe static void RegisterLogListener(Context p0, IDfuLogListener p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("registerLogListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("registerProgressListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;)V", "")]
		public unsafe static void RegisterProgressListener(Context p0, IDfuProgressListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.StaticMethods.InvokeVoidMethod("registerProgressListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("registerProgressListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;Ljava/lang/String;)V", "")]
		public unsafe static void RegisterProgressListener(Context p0, IDfuProgressListener p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("registerProgressListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("unregisterLogListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;)V", "")]
		public unsafe static void UnregisterLogListener(Context p0, IDfuLogListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.StaticMethods.InvokeVoidMethod("unregisterLogListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuLogListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("unregisterProgressListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;)V", "")]
		public unsafe static void UnregisterProgressListener(Context p0, IDfuProgressListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				_members.StaticMethods.InvokeVoidMethod("unregisterProgressListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuProgressListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuStarter", DoNotGenerateAcw = true)]
	public class DfuStarter : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuStarter", typeof(DfuStarter));

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

		public unsafe static DfuListener DfuListener
		{
			[Register("getDfuListener", "()Lno/nordicsemi/android/dfu/DfuListener;", "")]
			get
			{
				return Java.Lang.Object.GetObject<DfuListener>(_members.StaticMethods.InvokeObjectMethod("getDfuListener.()Lno/nordicsemi/android/dfu/DfuListener;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected DfuStarter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DfuStarter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("setDfuListener", "(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuListener;)V", "")]
		public unsafe static void SetDfuListener(Context p0, DfuListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setDfuListener.(Landroid/content/Context;Lno/nordicsemi/android/dfu/DfuListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("startDfu", "(Landroid/content/Context;Landroid/bluetooth/BluetoothDevice;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceController;", "")]
		public unsafe static DfuServiceController StartDfu(Context p0, BluetoothDevice p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuServiceController>(_members.StaticMethods.InvokeObjectMethod("startDfu.(Landroid/content/Context;Landroid/bluetooth/BluetoothDevice;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceController;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("startDfu", "(Landroid/content/Context;Landroid/bluetooth/BluetoothDevice;Ljava/lang/String;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceController;", "")]
		public unsafe static DfuServiceController StartDfu(Context p0, BluetoothDevice p1, string p2, string p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<DfuServiceController>(_members.StaticMethods.InvokeObjectMethod("startDfu.(Landroid/content/Context;Landroid/bluetooth/BluetoothDevice;Ljava/lang/String;Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuServiceController;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuState", DoNotGenerateAcw = true)]
	public sealed class DfuState : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuState", typeof(DfuState));

		[Register("DeviceConnected")]
		public static DfuState DeviceConnected => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DeviceConnected.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DeviceConnecting")]
		public static DfuState DeviceConnecting => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DeviceConnecting.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DeviceDisconnected")]
		public static DfuState DeviceDisconnected => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DeviceDisconnected.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DeviceDisconnecting")]
		public static DfuState DeviceDisconnecting => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DeviceDisconnecting.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DfuAborted")]
		public static DfuState DfuAborted => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DfuAborted.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DfuCompleted")]
		public static DfuState DfuCompleted => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DfuCompleted.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DfuProcessStarted")]
		public static DfuState DfuProcessStarted => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DfuProcessStarted.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DfuProcessStarting")]
		public static DfuState DfuProcessStarting => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("DfuProcessStarting.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EnablingDfuMode")]
		public static DfuState EnablingDfuMode => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("EnablingDfuMode.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Error")]
		public static DfuState Error => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("Error.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FirmwareValidating")]
		public static DfuState FirmwareValidating => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("FirmwareValidating.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Idle")]
		public static DfuState Idle => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("Idle.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("Uploading")]
		public static DfuState Uploading => Java.Lang.Object.GetObject<DfuState>(_members.StaticFields.GetObjectValue("Uploading.Lno/nordicsemi/android/dfu/DfuState;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal DfuState(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuState;", "")]
		public unsafe static DfuState ValueOf(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<DfuState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lno/nordicsemi/android/dfu/DfuState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lno/nordicsemi/android/dfu/DfuState;", "")]
		public unsafe static DfuState[] Values()
		{
			return (DfuState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lno/nordicsemi/android/dfu/DfuState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DfuState));
		}
	}
	[Register("no/nordicsemi/android/dfu/DummyListener", DoNotGenerateAcw = true)]
	public class DummyListener : Java.Lang.Object, IDfuProgressListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DummyListener", typeof(DummyListener));

		private static Delegate cb_onDeviceConnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceConnecting_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnecting_Ljava_lang_String_;

		private static Delegate cb_onDfuAborted_Ljava_lang_String_;

		private static Delegate cb_onDfuCompleted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarting_Ljava_lang_String_;

		private static Delegate cb_onEnablingDfuMode_Ljava_lang_String_;

		private static Delegate cb_onError_Ljava_lang_String_IILjava_lang_String_;

		private static Delegate cb_onFirmwareValidating_Ljava_lang_String_;

		private static Delegate cb_onProgressChanged_Ljava_lang_String_IFFII;

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

		protected DummyListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe DummyListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnDeviceConnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnected_Ljava_lang_String_));
			}
			return cb_onDeviceConnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDeviceConnected(p);
		}

		[Register("onDeviceConnected", "(Ljava/lang/String;)V", "GetOnDeviceConnected_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceConnected(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceConnected.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceConnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnecting_Ljava_lang_String_));
			}
			return cb_onDeviceConnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDeviceConnecting(p);
		}

		[Register("onDeviceConnecting", "(Ljava/lang/String;)V", "GetOnDeviceConnecting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceConnecting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceConnecting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceDisconnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnected_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDeviceDisconnected(p);
		}

		[Register("onDeviceDisconnected", "(Ljava/lang/String;)V", "GetOnDeviceDisconnected_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceDisconnected(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceDisconnected.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDeviceDisconnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnecting_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDeviceDisconnecting(p);
		}

		[Register("onDeviceDisconnecting", "(Ljava/lang/String;)V", "GetOnDeviceDisconnecting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDeviceDisconnecting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDeviceDisconnecting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuAborted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuAborted_Ljava_lang_String_ == null)
			{
				cb_onDfuAborted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuAborted_Ljava_lang_String_));
			}
			return cb_onDfuAborted_Ljava_lang_String_;
		}

		private static void n_OnDfuAborted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDfuAborted(p);
		}

		[Register("onDfuAborted", "(Ljava/lang/String;)V", "GetOnDfuAborted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuAborted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuAborted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuCompleted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuCompleted_Ljava_lang_String_ == null)
			{
				cb_onDfuCompleted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuCompleted_Ljava_lang_String_));
			}
			return cb_onDfuCompleted_Ljava_lang_String_;
		}

		private static void n_OnDfuCompleted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDfuCompleted(p);
		}

		[Register("onDfuCompleted", "(Ljava/lang/String;)V", "GetOnDfuCompleted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuCompleted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuCompleted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuProcessStarted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarted_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarted_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarted_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDfuProcessStarted(p);
		}

		[Register("onDfuProcessStarted", "(Ljava/lang/String;)V", "GetOnDfuProcessStarted_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuProcessStarted(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuProcessStarted.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnDfuProcessStarting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarting_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarting_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarting_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnDfuProcessStarting(p);
		}

		[Register("onDfuProcessStarting", "(Ljava/lang/String;)V", "GetOnDfuProcessStarting_Ljava_lang_String_Handler")]
		public unsafe virtual void OnDfuProcessStarting(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDfuProcessStarting.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnEnablingDfuMode_Ljava_lang_String_Handler()
		{
			if ((object)cb_onEnablingDfuMode_Ljava_lang_String_ == null)
			{
				cb_onEnablingDfuMode_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnEnablingDfuMode_Ljava_lang_String_));
			}
			return cb_onEnablingDfuMode_Ljava_lang_String_;
		}

		private static void n_OnEnablingDfuMode_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnEnablingDfuMode(p);
		}

		[Register("onEnablingDfuMode", "(Ljava/lang/String;)V", "GetOnEnablingDfuMode_Ljava_lang_String_Handler")]
		public unsafe virtual void OnEnablingDfuMode(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onEnablingDfuMode.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnError_Ljava_lang_String_IILjava_lang_String_Handler()
		{
			if ((object)cb_onError_Ljava_lang_String_IILjava_lang_String_ == null)
			{
				cb_onError_Ljava_lang_String_IILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_V(n_OnError_Ljava_lang_String_IILjava_lang_String_));
			}
			return cb_onError_Ljava_lang_String_IILjava_lang_String_;
		}

		private static void n_OnError_Ljava_lang_String_IILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p3, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnError(p3, p1, p2, p4);
		}

		[Register("onError", "(Ljava/lang/String;IILjava/lang/String;)V", "GetOnError_Ljava_lang_String_IILjava_lang_String_Handler")]
		public unsafe virtual void OnError(string p0, int p1, int p2, string p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onError.(Ljava/lang/String;IILjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetOnFirmwareValidating_Ljava_lang_String_Handler()
		{
			if ((object)cb_onFirmwareValidating_Ljava_lang_String_ == null)
			{
				cb_onFirmwareValidating_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFirmwareValidating_Ljava_lang_String_));
			}
			return cb_onFirmwareValidating_Ljava_lang_String_;
		}

		private static void n_OnFirmwareValidating_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnFirmwareValidating(p);
		}

		[Register("onFirmwareValidating", "(Ljava/lang/String;)V", "GetOnFirmwareValidating_Ljava_lang_String_Handler")]
		public unsafe virtual void OnFirmwareValidating(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onFirmwareValidating.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetOnProgressChanged_Ljava_lang_String_IFFIIHandler()
		{
			if ((object)cb_onProgressChanged_Ljava_lang_String_IFFII == null)
			{
				cb_onProgressChanged_Ljava_lang_String_IFFII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIFFII_V(n_OnProgressChanged_Ljava_lang_String_IFFII));
			}
			return cb_onProgressChanged_Ljava_lang_String_IFFII;
		}

		private static void n_OnProgressChanged_Ljava_lang_String_IFFII(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, float p2, float p3, int p4, int p5)
		{
			DummyListener dummyListener = Java.Lang.Object.GetObject<DummyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p6 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dummyListener.OnProgressChanged(p6, p1, p2, p3, p4, p5);
		}

		[Register("onProgressChanged", "(Ljava/lang/String;IFFII)V", "GetOnProgressChanged_Ljava_lang_String_IFFIIHandler")]
		public unsafe virtual void OnProgressChanged(string p0, int p1, float p2, float p3, int p4, int p5)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onProgressChanged.(Ljava/lang/String;IFFII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Annotation("no.nordicsemi.android.dfu.FileType")]
	public class FileTypeAttribute : Attribute
	{
	}
	[Register("no/nordicsemi/android/dfu/DfuController", "", "NO.Nordicsemi.Android.Dfu.IDfuControllerInvoker")]
	public interface IDfuController : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("abort", "()V", "GetAbortHandler:NO.Nordicsemi.Android.Dfu.IDfuControllerInvoker, DfuAndroidLibrary")]
		void Abort();

		[Register("pause", "()V", "GetPauseHandler:NO.Nordicsemi.Android.Dfu.IDfuControllerInvoker, DfuAndroidLibrary")]
		void Pause();

		[Register("resume", "()V", "GetResumeHandler:NO.Nordicsemi.Android.Dfu.IDfuControllerInvoker, DfuAndroidLibrary")]
		void Resume();
	}
	[Register("no/nordicsemi/android/dfu/DfuController", DoNotGenerateAcw = true)]
	internal class IDfuControllerInvoker : Java.Lang.Object, IDfuController, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuController", typeof(IDfuControllerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_abort;

		private IntPtr id_abort;

		private static Delegate cb_pause;

		private IntPtr id_pause;

		private static Delegate cb_resume;

		private IntPtr id_resume;

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

		public static IDfuController GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuController>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuController'.");
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

		public IDfuControllerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAbortHandler()
		{
			if ((object)cb_abort == null)
			{
				cb_abort = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Abort));
			}
			return cb_abort;
		}

		private static void n_Abort(IntPtr jnienv, IntPtr native__this)
		{
			IDfuController dfuController = Java.Lang.Object.GetObject<IDfuController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuController.Abort();
		}

		public void Abort()
		{
			if (id_abort == IntPtr.Zero)
			{
				id_abort = JNIEnv.GetMethodID(class_ref, "abort", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_abort);
		}

		private static Delegate GetPauseHandler()
		{
			if ((object)cb_pause == null)
			{
				cb_pause = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Pause));
			}
			return cb_pause;
		}

		private static void n_Pause(IntPtr jnienv, IntPtr native__this)
		{
			IDfuController dfuController = Java.Lang.Object.GetObject<IDfuController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuController.Pause();
		}

		public void Pause()
		{
			if (id_pause == IntPtr.Zero)
			{
				id_pause = JNIEnv.GetMethodID(class_ref, "pause", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_pause);
		}

		private static Delegate GetResumeHandler()
		{
			if ((object)cb_resume == null)
			{
				cb_resume = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Resume));
			}
			return cb_resume;
		}

		private static void n_Resume(IntPtr jnienv, IntPtr native__this)
		{
			IDfuController dfuController = Java.Lang.Object.GetObject<IDfuController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			dfuController.Resume();
		}

		public void Resume()
		{
			if (id_resume == IntPtr.Zero)
			{
				id_resume = JNIEnv.GetMethodID(class_ref, "resume", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_resume);
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuDeviceSelector", "", "NO.Nordicsemi.Android.Dfu.IDfuDeviceSelectorInvoker")]
	public interface IDfuDeviceSelector : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("matches", "(Landroid/bluetooth/BluetoothDevice;I[BLjava/lang/String;Ljava/lang/String;)Z", "GetMatches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuDeviceSelectorInvoker, DfuAndroidLibrary")]
		bool Matches(BluetoothDevice p0, int p1, byte[] p2, string p3, string p4);
	}
	[Register("no/nordicsemi/android/dfu/DfuDeviceSelector", DoNotGenerateAcw = true)]
	internal class IDfuDeviceSelectorInvoker : Java.Lang.Object, IDfuDeviceSelector, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuDeviceSelector", typeof(IDfuDeviceSelectorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_;

		private IntPtr id_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_;

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

		public static IDfuDeviceSelector GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuDeviceSelector>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuDeviceSelector'.");
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

		public IDfuDeviceSelectorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetMatches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_ == null)
			{
				cb_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLILLL_Z(n_Matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_));
			}
			return cb_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_;
		}

		private static bool n_Matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4)
		{
			IDfuDeviceSelector dfuDeviceSelector = Java.Lang.Object.GetObject<IDfuDeviceSelector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BluetoothDevice p2 = Java.Lang.Object.GetObject<BluetoothDevice>(native_p0, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(byte));
			string p3 = JNIEnv.GetString(native_p3, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p4, JniHandleOwnership.DoNotTransfer);
			bool result = dfuDeviceSelector.Matches(p2, p1, array, p3, p4);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p2);
			}
			return result;
		}

		public unsafe bool Matches(BluetoothDevice p0, int p1, byte[] p2, string p3, string p4)
		{
			if (id_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "matches", "(Landroid/bluetooth/BluetoothDevice;I[BLjava/lang/String;Ljava/lang/String;)Z");
			}
			IntPtr intPtr = JNIEnv.NewArray(p2);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			IntPtr intPtr3 = JNIEnv.NewString(p4);
			JValue* ptr = stackalloc JValue[5];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1);
			ptr[2] = new JValue(intPtr);
			ptr[3] = new JValue(intPtr2);
			ptr[4] = new JValue(intPtr3);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_matches_Landroid_bluetooth_BluetoothDevice_IarrayBLjava_lang_String_Ljava_lang_String_, ptr);
			if (p2 != null)
			{
				JNIEnv.CopyArray(intPtr, p2);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			JNIEnv.DeleteLocalRef(intPtr2);
			JNIEnv.DeleteLocalRef(intPtr3);
			return result;
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuLogListener", "", "NO.Nordicsemi.Android.Dfu.IDfuLogListenerInvoker")]
	public interface IDfuLogListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLogEvent", "(Ljava/lang/String;ILjava/lang/String;)V", "GetOnLogEvent_Ljava_lang_String_ILjava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuLogListenerInvoker, DfuAndroidLibrary")]
		void OnLogEvent(string p0, int p1, string p2);
	}
	[Register("no/nordicsemi/android/dfu/DfuLogListener", DoNotGenerateAcw = true)]
	internal class IDfuLogListenerInvoker : Java.Lang.Object, IDfuLogListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuLogListener", typeof(IDfuLogListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onLogEvent_Ljava_lang_String_ILjava_lang_String_;

		private IntPtr id_onLogEvent_Ljava_lang_String_ILjava_lang_String_;

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

		public static IDfuLogListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuLogListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuLogListener'.");
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

		public IDfuLogListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnLogEvent_Ljava_lang_String_ILjava_lang_String_Handler()
		{
			if ((object)cb_onLogEvent_Ljava_lang_String_ILjava_lang_String_ == null)
			{
				cb_onLogEvent_Ljava_lang_String_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnLogEvent_Ljava_lang_String_ILjava_lang_String_));
			}
			return cb_onLogEvent_Ljava_lang_String_ILjava_lang_String_;
		}

		private static void n_OnLogEvent_Ljava_lang_String_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, IntPtr native_p2)
		{
			IDfuLogListener dfuLogListener = Java.Lang.Object.GetObject<IDfuLogListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			dfuLogListener.OnLogEvent(p2, p1, p3);
		}

		public unsafe void OnLogEvent(string p0, int p1, string p2)
		{
			if (id_onLogEvent_Ljava_lang_String_ILjava_lang_String_ == IntPtr.Zero)
			{
				id_onLogEvent_Ljava_lang_String_ILjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onLogEvent", "(Ljava/lang/String;ILjava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			ptr[2] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_onLogEvent_Ljava_lang_String_ILjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}
	}
	public class DfuLogEventArgs : EventArgs
	{
		private string p0;

		private int p1;

		private string p2;

		public string P0 => p0;

		public int P1 => p1;

		public string P2 => p2;

		public DfuLogEventArgs(string p0, int p1, string p2)
		{
			this.p0 = p0;
			this.p1 = p1;
			this.p2 = p2;
		}
	}
	[Register("mono/no/nordicsemi/android/dfu/DfuLogListenerImplementor")]
	internal sealed class IDfuLogListenerImplementor : Java.Lang.Object, IDfuLogListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<DfuLogEventArgs> Handler;

		public IDfuLogListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/no/nordicsemi/android/dfu/DfuLogListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnLogEvent(string p0, int p1, string p2)
		{
			Handler?.Invoke(sender, new DfuLogEventArgs(p0, p1, p2));
		}

		internal static bool __IsEmpty(IDfuLogListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuProgressListener", "", "NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker")]
	public interface IDfuProgressListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDeviceConnected", "(Ljava/lang/String;)V", "GetOnDeviceConnected_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDeviceConnected(string p0);

		[Register("onDeviceConnecting", "(Ljava/lang/String;)V", "GetOnDeviceConnecting_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDeviceConnecting(string p0);

		[Register("onDeviceDisconnected", "(Ljava/lang/String;)V", "GetOnDeviceDisconnected_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDeviceDisconnected(string p0);

		[Register("onDeviceDisconnecting", "(Ljava/lang/String;)V", "GetOnDeviceDisconnecting_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDeviceDisconnecting(string p0);

		[Register("onDfuAborted", "(Ljava/lang/String;)V", "GetOnDfuAborted_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDfuAborted(string p0);

		[Register("onDfuCompleted", "(Ljava/lang/String;)V", "GetOnDfuCompleted_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDfuCompleted(string p0);

		[Register("onDfuProcessStarted", "(Ljava/lang/String;)V", "GetOnDfuProcessStarted_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDfuProcessStarted(string p0);

		[Register("onDfuProcessStarting", "(Ljava/lang/String;)V", "GetOnDfuProcessStarting_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnDfuProcessStarting(string p0);

		[Register("onEnablingDfuMode", "(Ljava/lang/String;)V", "GetOnEnablingDfuMode_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnEnablingDfuMode(string p0);

		[Register("onError", "(Ljava/lang/String;IILjava/lang/String;)V", "GetOnError_Ljava_lang_String_IILjava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnError(string p0, int p1, int p2, string p3);

		[Register("onFirmwareValidating", "(Ljava/lang/String;)V", "GetOnFirmwareValidating_Ljava_lang_String_Handler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnFirmwareValidating(string p0);

		[Register("onProgressChanged", "(Ljava/lang/String;IFFII)V", "GetOnProgressChanged_Ljava_lang_String_IFFIIHandler:NO.Nordicsemi.Android.Dfu.IDfuProgressListenerInvoker, DfuAndroidLibrary")]
		void OnProgressChanged(string p0, int p1, float p2, float p3, int p4, int p5);
	}
	[Register("no/nordicsemi/android/dfu/DfuProgressListener", DoNotGenerateAcw = true)]
	internal class IDfuProgressListenerInvoker : Java.Lang.Object, IDfuProgressListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuProgressListener", typeof(IDfuProgressListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onDeviceConnected_Ljava_lang_String_;

		private IntPtr id_onDeviceConnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceConnecting_Ljava_lang_String_;

		private IntPtr id_onDeviceConnecting_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnected_Ljava_lang_String_;

		private IntPtr id_onDeviceDisconnected_Ljava_lang_String_;

		private static Delegate cb_onDeviceDisconnecting_Ljava_lang_String_;

		private IntPtr id_onDeviceDisconnecting_Ljava_lang_String_;

		private static Delegate cb_onDfuAborted_Ljava_lang_String_;

		private IntPtr id_onDfuAborted_Ljava_lang_String_;

		private static Delegate cb_onDfuCompleted_Ljava_lang_String_;

		private IntPtr id_onDfuCompleted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarted_Ljava_lang_String_;

		private IntPtr id_onDfuProcessStarted_Ljava_lang_String_;

		private static Delegate cb_onDfuProcessStarting_Ljava_lang_String_;

		private IntPtr id_onDfuProcessStarting_Ljava_lang_String_;

		private static Delegate cb_onEnablingDfuMode_Ljava_lang_String_;

		private IntPtr id_onEnablingDfuMode_Ljava_lang_String_;

		private static Delegate cb_onError_Ljava_lang_String_IILjava_lang_String_;

		private IntPtr id_onError_Ljava_lang_String_IILjava_lang_String_;

		private static Delegate cb_onFirmwareValidating_Ljava_lang_String_;

		private IntPtr id_onFirmwareValidating_Ljava_lang_String_;

		private static Delegate cb_onProgressChanged_Ljava_lang_String_IFFII;

		private IntPtr id_onProgressChanged_Ljava_lang_String_IFFII;

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

		public static IDfuProgressListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuProgressListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuProgressListener'.");
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

		public IDfuProgressListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnDeviceConnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnected_Ljava_lang_String_));
			}
			return cb_onDeviceConnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDeviceConnected(p);
		}

		public unsafe void OnDeviceConnected(string p0)
		{
			if (id_onDeviceConnected_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDeviceConnected_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDeviceConnected", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDeviceConnected_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDeviceConnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceConnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceConnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceConnecting_Ljava_lang_String_));
			}
			return cb_onDeviceConnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceConnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDeviceConnecting(p);
		}

		public unsafe void OnDeviceConnecting(string p0)
		{
			if (id_onDeviceConnecting_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDeviceConnecting_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDeviceConnecting", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDeviceConnecting_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDeviceDisconnected_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnected_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnected_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnected_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnected_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnected_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDeviceDisconnected(p);
		}

		public unsafe void OnDeviceDisconnected(string p0)
		{
			if (id_onDeviceDisconnected_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDeviceDisconnected_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDeviceDisconnected", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDeviceDisconnected_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDeviceDisconnecting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDeviceDisconnecting_Ljava_lang_String_ == null)
			{
				cb_onDeviceDisconnecting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDeviceDisconnecting_Ljava_lang_String_));
			}
			return cb_onDeviceDisconnecting_Ljava_lang_String_;
		}

		private static void n_OnDeviceDisconnecting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDeviceDisconnecting(p);
		}

		public unsafe void OnDeviceDisconnecting(string p0)
		{
			if (id_onDeviceDisconnecting_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDeviceDisconnecting_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDeviceDisconnecting", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDeviceDisconnecting_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDfuAborted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuAborted_Ljava_lang_String_ == null)
			{
				cb_onDfuAborted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuAborted_Ljava_lang_String_));
			}
			return cb_onDfuAborted_Ljava_lang_String_;
		}

		private static void n_OnDfuAborted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDfuAborted(p);
		}

		public unsafe void OnDfuAborted(string p0)
		{
			if (id_onDfuAborted_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDfuAborted_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDfuAborted", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDfuAborted_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDfuCompleted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuCompleted_Ljava_lang_String_ == null)
			{
				cb_onDfuCompleted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuCompleted_Ljava_lang_String_));
			}
			return cb_onDfuCompleted_Ljava_lang_String_;
		}

		private static void n_OnDfuCompleted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDfuCompleted(p);
		}

		public unsafe void OnDfuCompleted(string p0)
		{
			if (id_onDfuCompleted_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDfuCompleted_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDfuCompleted", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDfuCompleted_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDfuProcessStarted_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarted_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarted_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarted_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarted_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarted_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDfuProcessStarted(p);
		}

		public unsafe void OnDfuProcessStarted(string p0)
		{
			if (id_onDfuProcessStarted_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDfuProcessStarted_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDfuProcessStarted", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDfuProcessStarted_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnDfuProcessStarting_Ljava_lang_String_Handler()
		{
			if ((object)cb_onDfuProcessStarting_Ljava_lang_String_ == null)
			{
				cb_onDfuProcessStarting_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDfuProcessStarting_Ljava_lang_String_));
			}
			return cb_onDfuProcessStarting_Ljava_lang_String_;
		}

		private static void n_OnDfuProcessStarting_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnDfuProcessStarting(p);
		}

		public unsafe void OnDfuProcessStarting(string p0)
		{
			if (id_onDfuProcessStarting_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onDfuProcessStarting_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onDfuProcessStarting", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onDfuProcessStarting_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnEnablingDfuMode_Ljava_lang_String_Handler()
		{
			if ((object)cb_onEnablingDfuMode_Ljava_lang_String_ == null)
			{
				cb_onEnablingDfuMode_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnEnablingDfuMode_Ljava_lang_String_));
			}
			return cb_onEnablingDfuMode_Ljava_lang_String_;
		}

		private static void n_OnEnablingDfuMode_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnEnablingDfuMode(p);
		}

		public unsafe void OnEnablingDfuMode(string p0)
		{
			if (id_onEnablingDfuMode_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onEnablingDfuMode_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onEnablingDfuMode", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onEnablingDfuMode_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnError_Ljava_lang_String_IILjava_lang_String_Handler()
		{
			if ((object)cb_onError_Ljava_lang_String_IILjava_lang_String_ == null)
			{
				cb_onError_Ljava_lang_String_IILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIL_V(n_OnError_Ljava_lang_String_IILjava_lang_String_));
			}
			return cb_onError_Ljava_lang_String_IILjava_lang_String_;
		}

		private static void n_OnError_Ljava_lang_String_IILjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString(native_p3, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnError(p3, p1, p2, p4);
		}

		public unsafe void OnError(string p0, int p1, int p2, string p3)
		{
			if (id_onError_Ljava_lang_String_IILjava_lang_String_ == IntPtr.Zero)
			{
				id_onError_Ljava_lang_String_IILjava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onError", "(Ljava/lang/String;IILjava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_onError_Ljava_lang_String_IILjava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetOnFirmwareValidating_Ljava_lang_String_Handler()
		{
			if ((object)cb_onFirmwareValidating_Ljava_lang_String_ == null)
			{
				cb_onFirmwareValidating_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFirmwareValidating_Ljava_lang_String_));
			}
			return cb_onFirmwareValidating_Ljava_lang_String_;
		}

		private static void n_OnFirmwareValidating_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnFirmwareValidating(p);
		}

		public unsafe void OnFirmwareValidating(string p0)
		{
			if (id_onFirmwareValidating_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_onFirmwareValidating_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "onFirmwareValidating", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onFirmwareValidating_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetOnProgressChanged_Ljava_lang_String_IFFIIHandler()
		{
			if ((object)cb_onProgressChanged_Ljava_lang_String_IFFII == null)
			{
				cb_onProgressChanged_Ljava_lang_String_IFFII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIFFII_V(n_OnProgressChanged_Ljava_lang_String_IFFII));
			}
			return cb_onProgressChanged_Ljava_lang_String_IFFII;
		}

		private static void n_OnProgressChanged_Ljava_lang_String_IFFII(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, float p2, float p3, int p4, int p5)
		{
			IDfuProgressListener dfuProgressListener = Java.Lang.Object.GetObject<IDfuProgressListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p6 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			dfuProgressListener.OnProgressChanged(p6, p1, p2, p3, p4, p5);
		}

		public unsafe void OnProgressChanged(string p0, int p1, float p2, float p3, int p4, int p5)
		{
			if (id_onProgressChanged_Ljava_lang_String_IFFII == IntPtr.Zero)
			{
				id_onProgressChanged_Ljava_lang_String_IFFII = JNIEnv.GetMethodID(class_ref, "onProgressChanged", "(Ljava/lang/String;IFFII)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[6];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1);
			ptr[2] = new JValue(p2);
			ptr[3] = new JValue(p3);
			ptr[4] = new JValue(p4);
			ptr[5] = new JValue(p5);
			JNIEnv.CallVoidMethod(base.Handle, id_onProgressChanged_Ljava_lang_String_IFFII, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	public class DeviceConnectedEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DeviceConnectedEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DeviceConnectingEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DeviceConnectingEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DeviceDisconnectedEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DeviceDisconnectedEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DeviceDisconnectingEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DeviceDisconnectingEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DfuAbortedEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DfuAbortedEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DfuCompletedEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DfuCompletedEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DfuProcessStartedEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DfuProcessStartedEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class DfuProcessStartingEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public DfuProcessStartingEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class EnablingDfuModeEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public EnablingDfuModeEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class ErrorEventArgs : EventArgs
	{
		private string p0;

		private int p1;

		private int p2;

		private string p3;

		public string P0 => p0;

		public int P1 => p1;

		public int P2 => p2;

		public string P3 => p3;

		public ErrorEventArgs(string p0, int p1, int p2, string p3)
		{
			this.p0 = p0;
			this.p1 = p1;
			this.p2 = p2;
			this.p3 = p3;
		}
	}
	public class FirmwareValidatingEventArgs : EventArgs
	{
		private string p0;

		public string P0 => p0;

		public FirmwareValidatingEventArgs(string p0)
		{
			this.p0 = p0;
		}
	}
	public class ProgressChangedEventArgs : EventArgs
	{
		private string p0;

		private int p1;

		private float p2;

		private float p3;

		private int p4;

		private int p5;

		public string P0 => p0;

		public int P1 => p1;

		public float P2 => p2;

		public float P3 => p3;

		public int P4 => p4;

		public int P5 => p5;

		public ProgressChangedEventArgs(string p0, int p1, float p2, float p3, int p4, int p5)
		{
			this.p0 = p0;
			this.p1 = p1;
			this.p2 = p2;
			this.p3 = p3;
			this.p4 = p4;
			this.p5 = p5;
		}
	}
	[Register("mono/no/nordicsemi/android/dfu/DfuProgressListenerImplementor")]
	internal sealed class IDfuProgressListenerImplementor : Java.Lang.Object, IDfuProgressListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<DeviceConnectedEventArgs> OnDeviceConnectedHandler;

		public EventHandler<DeviceConnectingEventArgs> OnDeviceConnectingHandler;

		public EventHandler<DeviceDisconnectedEventArgs> OnDeviceDisconnectedHandler;

		public EventHandler<DeviceDisconnectingEventArgs> OnDeviceDisconnectingHandler;

		public EventHandler<DfuAbortedEventArgs> OnDfuAbortedHandler;

		public EventHandler<DfuCompletedEventArgs> OnDfuCompletedHandler;

		public EventHandler<DfuProcessStartedEventArgs> OnDfuProcessStartedHandler;

		public EventHandler<DfuProcessStartingEventArgs> OnDfuProcessStartingHandler;

		public EventHandler<EnablingDfuModeEventArgs> OnEnablingDfuModeHandler;

		public EventHandler<ErrorEventArgs> OnErrorHandler;

		public EventHandler<FirmwareValidatingEventArgs> OnFirmwareValidatingHandler;

		public EventHandler<ProgressChangedEventArgs> OnProgressChangedHandler;

		public IDfuProgressListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/no/nordicsemi/android/dfu/DfuProgressListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnDeviceConnected(string p0)
		{
			OnDeviceConnectedHandler?.Invoke(sender, new DeviceConnectedEventArgs(p0));
		}

		public void OnDeviceConnecting(string p0)
		{
			OnDeviceConnectingHandler?.Invoke(sender, new DeviceConnectingEventArgs(p0));
		}

		public void OnDeviceDisconnected(string p0)
		{
			OnDeviceDisconnectedHandler?.Invoke(sender, new DeviceDisconnectedEventArgs(p0));
		}

		public void OnDeviceDisconnecting(string p0)
		{
			OnDeviceDisconnectingHandler?.Invoke(sender, new DeviceDisconnectingEventArgs(p0));
		}

		public void OnDfuAborted(string p0)
		{
			OnDfuAbortedHandler?.Invoke(sender, new DfuAbortedEventArgs(p0));
		}

		public void OnDfuCompleted(string p0)
		{
			OnDfuCompletedHandler?.Invoke(sender, new DfuCompletedEventArgs(p0));
		}

		public void OnDfuProcessStarted(string p0)
		{
			OnDfuProcessStartedHandler?.Invoke(sender, new DfuProcessStartedEventArgs(p0));
		}

		public void OnDfuProcessStarting(string p0)
		{
			OnDfuProcessStartingHandler?.Invoke(sender, new DfuProcessStartingEventArgs(p0));
		}

		public void OnEnablingDfuMode(string p0)
		{
			OnEnablingDfuModeHandler?.Invoke(sender, new EnablingDfuModeEventArgs(p0));
		}

		public void OnError(string p0, int p1, int p2, string p3)
		{
			OnErrorHandler?.Invoke(sender, new ErrorEventArgs(p0, p1, p2, p3));
		}

		public void OnFirmwareValidating(string p0)
		{
			OnFirmwareValidatingHandler?.Invoke(sender, new FirmwareValidatingEventArgs(p0));
		}

		public void OnProgressChanged(string p0, int p1, float p2, float p3, int p4, int p5)
		{
			OnProgressChangedHandler?.Invoke(sender, new ProgressChangedEventArgs(p0, p1, p2, p3, p4, p5));
		}

		internal static bool __IsEmpty(IDfuProgressListenerImplementor value)
		{
			if (value.OnDeviceConnectedHandler == null && value.OnDeviceConnectingHandler == null && value.OnDeviceDisconnectedHandler == null && value.OnDeviceDisconnectingHandler == null && value.OnDfuAbortedHandler == null && value.OnDfuCompletedHandler == null && value.OnDfuProcessStartedHandler == null && value.OnDfuProcessStartingHandler == null && value.OnEnablingDfuModeHandler == null && value.OnErrorHandler == null && value.OnFirmwareValidatingHandler == null)
			{
				return value.OnProgressChangedHandler == null;
			}
			return false;
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuScope", "", "NO.Nordicsemi.Android.Dfu.IDfuScopeInvoker")]
	public interface IDfuScope : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("no/nordicsemi/android/dfu/DfuScope", DoNotGenerateAcw = true)]
	internal class IDfuScopeInvoker : Java.Lang.Object, IDfuScope, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuScope", typeof(IDfuScopeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

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

		public static IDfuScope GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuScope>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuScope'.");
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

		public IDfuScopeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			IDfuScope dfuScope = Java.Lang.Object.GetObject<IDfuScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(dfuScope.AnnotationType());
		}

		public Class AnnotationType()
		{
			if (id_annotationType == IntPtr.Zero)
			{
				id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEquals_Ljava_lang_Object_Handler()
		{
			if ((object)cb_equals_Ljava_lang_Object_ == null)
			{
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IDfuScope dfuScope = Java.Lang.Object.GetObject<IDfuScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return dfuScope.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			IDfuScope dfuScope = Java.Lang.Object.GetObject<IDfuScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return dfuScope.GetHashCode();
		}

		public new int GetHashCode()
		{
			if (id_hashCode == IntPtr.Zero)
			{
				id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
		}

		private static Delegate GetToStringHandler()
		{
			if ((object)cb_toString == null)
			{
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			IDfuScope dfuScope = Java.Lang.Object.GetObject<IDfuScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(dfuScope.ToString());
		}

		public new string ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuSettingsConstants", DoNotGenerateAcw = true)]
	public abstract class DfuSettingsConstants : Java.Lang.Object
	{
		[Register("SETTINGS_ASSUME_DFU_NODE")]
		[Obsolete("deprecated")]
		public const string SettingsAssumeDfuNode = "settings_assume_dfu_mode";

		[Register("SETTINGS_MBR_SIZE")]
		[Obsolete("deprecated")]
		public const string SettingsMbrSize = "settings_mbr_size";

		[Register("SETTINGS_NUMBER_OF_PACKETS")]
		[Obsolete("deprecated")]
		public const string SettingsNumberOfPackets = "settings_number_of_packets";

		[Register("SETTINGS_NUMBER_OF_PACKETS_DEFAULT")]
		[Obsolete("deprecated")]
		public const int SettingsNumberOfPacketsDefault = 12;

		[Register("SETTINGS_PACKET_RECEIPT_NOTIFICATION_ENABLED")]
		[Obsolete("deprecated")]
		public const string SettingsPacketReceiptNotificationEnabled = "settings_packet_receipt_notification_enabled";

		internal DfuSettingsConstants()
		{
		}
	}
	[Register("no/nordicsemi/android/dfu/DfuSettingsConstants", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'DfuSettingsConstants' type. This type will be removed in a future release.", true)]
	public abstract class DfuSettingsConstantsConsts : DfuSettingsConstants
	{
		private DfuSettingsConstantsConsts()
		{
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("no/nordicsemi/android/dfu/DfuSettingsConstants", "", "NO.Nordicsemi.Android.Dfu.IDfuSettingsConstantsInvoker")]
	public interface IDfuSettingsConstants : IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("no/nordicsemi/android/dfu/DfuSettingsConstants", DoNotGenerateAcw = true)]
	internal class IDfuSettingsConstantsInvoker : Java.Lang.Object, IDfuSettingsConstants, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/DfuSettingsConstants", typeof(IDfuSettingsConstantsInvoker));

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

		public static IDfuSettingsConstants GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDfuSettingsConstants>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.DfuSettingsConstants'.");
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

		public IDfuSettingsConstantsInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}
	}
	[Register("no/nordicsemi/android/dfu/FileType", "", "NO.Nordicsemi.Android.Dfu.IFileTypeInvoker")]
	public interface IFileType : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("no/nordicsemi/android/dfu/FileType", DoNotGenerateAcw = true)]
	internal class IFileTypeInvoker : Java.Lang.Object, IFileType, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/FileType", typeof(IFileTypeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

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

		public static IFileType GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFileType>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.FileType'.");
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

		public IFileTypeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			IFileType fileType = Java.Lang.Object.GetObject<IFileType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fileType.AnnotationType());
		}

		public Class AnnotationType()
		{
			if (id_annotationType == IntPtr.Zero)
			{
				id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEquals_Ljava_lang_Object_Handler()
		{
			if ((object)cb_equals_Ljava_lang_Object_ == null)
			{
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IFileType fileType = Java.Lang.Object.GetObject<IFileType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return fileType.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			IFileType fileType = Java.Lang.Object.GetObject<IFileType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return fileType.GetHashCode();
		}

		public new int GetHashCode()
		{
			if (id_hashCode == IntPtr.Zero)
			{
				id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
		}

		private static Delegate GetToStringHandler()
		{
			if ((object)cb_toString == null)
			{
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			IFileType fileType = Java.Lang.Object.GetObject<IFileType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fileType.ToString());
		}

		public new string ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace NO.Nordicsemi.Android.Dfu.Internal
{
	[Register("no/nordicsemi/android/dfu/internal/ArchiveInputStream", DoNotGenerateAcw = true)]
	public class ArchiveInputStream : InputStream
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/ArchiveInputStream", typeof(ArchiveInputStream));

		private static Delegate cb_getBytesRead;

		private static Delegate cb_getContentType;

		private static Delegate cb_getCrc32;

		private static Delegate cb_isSecureDfuRequired;

		private static Delegate cb_applicationImageSize;

		private static Delegate cb_bootloaderImageSize;

		private static Delegate cb_fullReset;

		private static Delegate cb_getApplicationInit;

		private static Delegate cb_getSystemInit;

		private static Delegate cb_read;

		private static Delegate cb_setContentType_I;

		private static Delegate cb_softDeviceImageSize;

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

		public unsafe virtual int BytesRead
		{
			[Register("getBytesRead", "()I", "GetGetBytesReadHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBytesRead.()I", this, null);
			}
		}

		public unsafe virtual int ContentType
		{
			[Register("getContentType", "()I", "GetGetContentTypeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getContentType.()I", this, null);
			}
		}

		public unsafe virtual long Crc32
		{
			[Register("getCrc32", "()J", "GetGetCrc32Handler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getCrc32.()J", this, null);
			}
		}

		public unsafe virtual bool IsSecureDfuRequired
		{
			[Register("isSecureDfuRequired", "()Z", "GetIsSecureDfuRequiredHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSecureDfuRequired.()Z", this, null);
			}
		}

		protected ArchiveInputStream(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/io/InputStream;II)V", "")]
		public unsafe ArchiveInputStream(Stream p0, int p1, int p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/InputStream;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/InputStream;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetBytesReadHandler()
		{
			if ((object)cb_getBytesRead == null)
			{
				cb_getBytesRead = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBytesRead));
			}
			return cb_getBytesRead;
		}

		private static int n_GetBytesRead(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.BytesRead;
		}

		private static Delegate GetGetContentTypeHandler()
		{
			if ((object)cb_getContentType == null)
			{
				cb_getContentType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContentType));
			}
			return cb_getContentType;
		}

		private static int n_GetContentType(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.ContentType;
		}

		private static Delegate GetGetCrc32Handler()
		{
			if ((object)cb_getCrc32 == null)
			{
				cb_getCrc32 = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetCrc32));
			}
			return cb_getCrc32;
		}

		private static long n_GetCrc32(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.Crc32;
		}

		private static Delegate GetIsSecureDfuRequiredHandler()
		{
			if ((object)cb_isSecureDfuRequired == null)
			{
				cb_isSecureDfuRequired = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSecureDfuRequired));
			}
			return cb_isSecureDfuRequired;
		}

		private static bool n_IsSecureDfuRequired(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.IsSecureDfuRequired;
		}

		private static Delegate GetApplicationImageSizeHandler()
		{
			if ((object)cb_applicationImageSize == null)
			{
				cb_applicationImageSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ApplicationImageSize));
			}
			return cb_applicationImageSize;
		}

		private static int n_ApplicationImageSize(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.ApplicationImageSize();
		}

		[Register("applicationImageSize", "()I", "GetApplicationImageSizeHandler")]
		public unsafe virtual int ApplicationImageSize()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("applicationImageSize.()I", this, null);
		}

		private static Delegate GetBootloaderImageSizeHandler()
		{
			if ((object)cb_bootloaderImageSize == null)
			{
				cb_bootloaderImageSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_BootloaderImageSize));
			}
			return cb_bootloaderImageSize;
		}

		private static int n_BootloaderImageSize(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.BootloaderImageSize();
		}

		[Register("bootloaderImageSize", "()I", "GetBootloaderImageSizeHandler")]
		public unsafe virtual int BootloaderImageSize()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("bootloaderImageSize.()I", this, null);
		}

		private static Delegate GetFullResetHandler()
		{
			if ((object)cb_fullReset == null)
			{
				cb_fullReset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_FullReset));
			}
			return cb_fullReset;
		}

		private static void n_FullReset(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			archiveInputStream.FullReset();
		}

		[Register("fullReset", "()V", "GetFullResetHandler")]
		public unsafe virtual void FullReset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("fullReset.()V", this, null);
		}

		private static Delegate GetGetApplicationInitHandler()
		{
			if ((object)cb_getApplicationInit == null)
			{
				cb_getApplicationInit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplicationInit));
			}
			return cb_getApplicationInit;
		}

		private static IntPtr n_GetApplicationInit(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(archiveInputStream.GetApplicationInit());
		}

		[Register("getApplicationInit", "()[B", "GetGetApplicationInitHandler")]
		public unsafe virtual byte[] GetApplicationInit()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationInit.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetGetSystemInitHandler()
		{
			if ((object)cb_getSystemInit == null)
			{
				cb_getSystemInit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSystemInit));
			}
			return cb_getSystemInit;
		}

		private static IntPtr n_GetSystemInit(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(archiveInputStream.GetSystemInit());
		}

		[Register("getSystemInit", "()[B", "GetGetSystemInitHandler")]
		public unsafe virtual byte[] GetSystemInit()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystemInit.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetReadHandler()
		{
			if ((object)cb_read == null)
			{
				cb_read = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Read));
			}
			return cb_read;
		}

		private static int n_Read(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.Read();
		}

		[Register("read", "()I", "GetReadHandler")]
		public unsafe override int Read()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("read.()I", this, null);
		}

		private static Delegate GetSetContentType_IHandler()
		{
			if ((object)cb_setContentType_I == null)
			{
				cb_setContentType_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_SetContentType_I));
			}
			return cb_setContentType_I;
		}

		private static int n_SetContentType_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.SetContentType(p0);
		}

		[Register("setContentType", "(I)I", "GetSetContentType_IHandler")]
		public unsafe virtual int SetContentType(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members.InstanceMethods.InvokeVirtualInt32Method("setContentType.(I)I", this, ptr);
		}

		private static Delegate GetSoftDeviceImageSizeHandler()
		{
			if ((object)cb_softDeviceImageSize == null)
			{
				cb_softDeviceImageSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_SoftDeviceImageSize));
			}
			return cb_softDeviceImageSize;
		}

		private static int n_SoftDeviceImageSize(IntPtr jnienv, IntPtr native__this)
		{
			ArchiveInputStream archiveInputStream = Java.Lang.Object.GetObject<ArchiveInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return archiveInputStream.SoftDeviceImageSize();
		}

		[Register("softDeviceImageSize", "()I", "GetSoftDeviceImageSizeHandler")]
		public unsafe virtual int SoftDeviceImageSize()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("softDeviceImageSize.()I", this, null);
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/HexInputStream", DoNotGenerateAcw = true)]
	public class HexInputStream : FilterInputStream
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/HexInputStream", typeof(HexInputStream));

		private static Delegate cb_readPacket_arrayB;

		private static Delegate cb_sizeInBytes;

		private static Delegate cb_sizeInPackets_I;

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

		protected HexInputStream(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "([BI)V", "")]
		public unsafe HexInputStream(byte[] p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("([BI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("([BI)V", this, ptr);
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

		[Register(".ctor", "(Ljava/io/InputStream;I)V", "")]
		public unsafe HexInputStream(Stream p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/io/InputStream;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/io/InputStream;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetReadPacket_arrayBHandler()
		{
			if ((object)cb_readPacket_arrayB == null)
			{
				cb_readPacket_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_ReadPacket_arrayB));
			}
			return cb_readPacket_arrayB;
		}

		private static int n_ReadPacket_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			HexInputStream hexInputStream = Java.Lang.Object.GetObject<HexInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = hexInputStream.ReadPacket(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p0);
			}
			return result;
		}

		[Register("readPacket", "([B)I", "GetReadPacket_arrayBHandler")]
		public unsafe virtual int ReadPacket(byte[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualInt32Method("readPacket.([B)I", this, ptr);
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

		private static Delegate GetSizeInBytesHandler()
		{
			if ((object)cb_sizeInBytes == null)
			{
				cb_sizeInBytes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_SizeInBytes));
			}
			return cb_sizeInBytes;
		}

		private static int n_SizeInBytes(IntPtr jnienv, IntPtr native__this)
		{
			HexInputStream hexInputStream = Java.Lang.Object.GetObject<HexInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return hexInputStream.SizeInBytes();
		}

		[Register("sizeInBytes", "()I", "GetSizeInBytesHandler")]
		public unsafe virtual int SizeInBytes()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("sizeInBytes.()I", this, null);
		}

		private static Delegate GetSizeInPackets_IHandler()
		{
			if ((object)cb_sizeInPackets_I == null)
			{
				cb_sizeInPackets_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_SizeInPackets_I));
			}
			return cb_sizeInPackets_I;
		}

		private static int n_SizeInPackets_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			HexInputStream hexInputStream = Java.Lang.Object.GetObject<HexInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return hexInputStream.SizeInPackets(p0);
		}

		[Register("sizeInPackets", "(I)I", "GetSizeInPackets_IHandler")]
		public unsafe virtual int SizeInPackets(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return _members.InstanceMethods.InvokeVirtualInt32Method("sizeInPackets.(I)I", this, ptr);
		}
	}
}
namespace NO.Nordicsemi.Android.Dfu.Internal.Scanner
{
	[Register("no/nordicsemi/android/dfu/internal/scanner/BootloaderScannerFactory", DoNotGenerateAcw = true)]
	public sealed class BootloaderScannerFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/scanner/BootloaderScannerFactory", typeof(BootloaderScannerFactory));

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

		internal BootloaderScannerFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getIncrementedAddress", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe static string GetIncrementedAddress(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getIncrementedAddress.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getScanner", "(Ljava/lang/String;)Lno/nordicsemi/android/dfu/internal/scanner/BootloaderScanner;", "")]
		public unsafe static IBootloaderScanner GetScanner(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IBootloaderScanner>(_members.StaticMethods.InvokeObjectMethod("getScanner.(Ljava/lang/String;)Lno/nordicsemi/android/dfu/internal/scanner/BootloaderScanner;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/scanner/BootloaderScannerJB", DoNotGenerateAcw = true)]
	public class BootloaderScannerJB : Java.Lang.Object, BluetoothAdapter.ILeScanCallback, IJavaObject, IDisposable, IJavaPeerable, IBootloaderScanner
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/scanner/BootloaderScannerJB", typeof(BootloaderScannerJB));

		private static Delegate cb_onLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB;

		private static Delegate cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J;

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

		protected BootloaderScannerJB(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetOnLeScan_Landroid_bluetooth_BluetoothDevice_IarrayBHandler()
		{
			if ((object)cb_onLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB == null)
			{
				cb_onLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_OnLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB));
			}
			return cb_onLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB;
		}

		private static void n_OnLeScan_Landroid_bluetooth_BluetoothDevice_IarrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, IntPtr native_p2)
		{
			BootloaderScannerJB bootloaderScannerJB = Java.Lang.Object.GetObject<BootloaderScannerJB>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BluetoothDevice p2 = Java.Lang.Object.GetObject<BluetoothDevice>(native_p0, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(byte));
			bootloaderScannerJB.OnLeScan(p2, p1, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p2);
			}
		}

		[Register("onLeScan", "(Landroid/bluetooth/BluetoothDevice;I[B)V", "GetOnLeScan_Landroid_bluetooth_BluetoothDevice_IarrayBHandler")]
		public unsafe virtual void OnLeScan(BluetoothDevice p0, int p1, byte[] p2)
		{
			IntPtr intPtr = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLeScan.(Landroid/bluetooth/BluetoothDevice;I[B)V", this, ptr);
			}
			finally
			{
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr, p2);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(p0);
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetSearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_JHandler()
		{
			if ((object)cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J == null)
			{
				cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_L(n_SearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J));
			}
			return cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J;
		}

		private static IntPtr n_SearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			BootloaderScannerJB bootloaderScannerJB = Java.Lang.Object.GetObject<BootloaderScannerJB>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDfuDeviceSelector p2 = Java.Lang.Object.GetObject<IDfuDeviceSelector>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(bootloaderScannerJB.SearchUsing(p2, p1));
		}

		[Register("searchUsing", "(Lno/nordicsemi/android/dfu/DfuDeviceSelector;J)Ljava/lang/String;", "GetSearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_JHandler")]
		public unsafe virtual string SearchUsing(IDfuDeviceSelector p0, long p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(p1);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("searchUsing.(Lno/nordicsemi/android/dfu/DfuDeviceSelector;J)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/scanner/BootloaderScanner", "", "NO.Nordicsemi.Android.Dfu.Internal.Scanner.IBootloaderScannerInvoker")]
	public interface IBootloaderScanner : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("searchUsing", "(Lno/nordicsemi/android/dfu/DfuDeviceSelector;J)Ljava/lang/String;", "GetSearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_JHandler:NO.Nordicsemi.Android.Dfu.Internal.Scanner.IBootloaderScannerInvoker, DfuAndroidLibrary")]
		string SearchUsing(IDfuDeviceSelector p0, long p1);
	}
	[Register("no/nordicsemi/android/dfu/internal/scanner/BootloaderScanner", DoNotGenerateAcw = true)]
	internal class IBootloaderScannerInvoker : Java.Lang.Object, IBootloaderScanner, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/scanner/BootloaderScanner", typeof(IBootloaderScannerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J;

		private IntPtr id_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J;

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

		public static IBootloaderScanner GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBootloaderScanner>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'no.nordicsemi.android.dfu.internal.scanner.BootloaderScanner'.");
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

		public IBootloaderScannerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_JHandler()
		{
			if ((object)cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J == null)
			{
				cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_L(n_SearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J));
			}
			return cb_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J;
		}

		private static IntPtr n_SearchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			IBootloaderScanner bootloaderScanner = Java.Lang.Object.GetObject<IBootloaderScanner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDfuDeviceSelector p2 = Java.Lang.Object.GetObject<IDfuDeviceSelector>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(bootloaderScanner.SearchUsing(p2, p1));
		}

		public unsafe string SearchUsing(IDfuDeviceSelector p0, long p1)
		{
			if (id_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J == IntPtr.Zero)
			{
				id_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J = JNIEnv.GetMethodID(class_ref, "searchUsing", "(Lno/nordicsemi/android/dfu/DfuDeviceSelector;J)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JValue(p1);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_searchUsing_Lno_nordicsemi_android_dfu_DfuDeviceSelector_J, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace NO.Nordicsemi.Android.Dfu.Internal.Manifest
{
	[Register("no/nordicsemi/android/dfu/internal/manifest/FileInfo", DoNotGenerateAcw = true)]
	public class FileInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/manifest/FileInfo", typeof(FileInfo));

		private static Delegate cb_getBinFileName;

		private static Delegate cb_getDatFileName;

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

		public unsafe virtual string BinFileName
		{
			[Register("getBinFileName", "()Ljava/lang/String;", "GetGetBinFileNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getBinFileName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string DatFileName
		{
			[Register("getDatFileName", "()Ljava/lang/String;", "GetGetDatFileNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDatFileName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected FileInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe FileInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetBinFileNameHandler()
		{
			if ((object)cb_getBinFileName == null)
			{
				cb_getBinFileName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBinFileName));
			}
			return cb_getBinFileName;
		}

		private static IntPtr n_GetBinFileName(IntPtr jnienv, IntPtr native__this)
		{
			FileInfo fileInfo = Java.Lang.Object.GetObject<FileInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fileInfo.BinFileName);
		}

		private static Delegate GetGetDatFileNameHandler()
		{
			if ((object)cb_getDatFileName == null)
			{
				cb_getDatFileName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDatFileName));
			}
			return cb_getDatFileName;
		}

		private static IntPtr n_GetDatFileName(IntPtr jnienv, IntPtr native__this)
		{
			FileInfo fileInfo = Java.Lang.Object.GetObject<FileInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fileInfo.DatFileName);
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/manifest/Manifest", DoNotGenerateAcw = true)]
	public class Manifest : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/manifest/Manifest", typeof(Manifest));

		private static Delegate cb_getApplicationInfo;

		private static Delegate cb_getBootloaderInfo;

		private static Delegate cb_isSecureDfuRequired;

		private static Delegate cb_getSoftdeviceBootloaderInfo;

		private static Delegate cb_getSoftdeviceInfo;

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

		public unsafe virtual FileInfo ApplicationInfo
		{
			[Register("getApplicationInfo", "()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", "GetGetApplicationInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FileInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationInfo.()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual FileInfo BootloaderInfo
		{
			[Register("getBootloaderInfo", "()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", "GetGetBootloaderInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FileInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBootloaderInfo.()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsSecureDfuRequired
		{
			[Register("isSecureDfuRequired", "()Z", "GetIsSecureDfuRequiredHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSecureDfuRequired.()Z", this, null);
			}
		}

		public unsafe virtual SoftDeviceBootloaderFileInfo SoftdeviceBootloaderInfo
		{
			[Register("getSoftdeviceBootloaderInfo", "()Lno/nordicsemi/android/dfu/internal/manifest/SoftDeviceBootloaderFileInfo;", "GetGetSoftdeviceBootloaderInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SoftDeviceBootloaderFileInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSoftdeviceBootloaderInfo.()Lno/nordicsemi/android/dfu/internal/manifest/SoftDeviceBootloaderFileInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual FileInfo SoftdeviceInfo
		{
			[Register("getSoftdeviceInfo", "()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", "GetGetSoftdeviceInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<FileInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSoftdeviceInfo.()Lno/nordicsemi/android/dfu/internal/manifest/FileInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Manifest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Manifest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetApplicationInfoHandler()
		{
			if ((object)cb_getApplicationInfo == null)
			{
				cb_getApplicationInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplicationInfo));
			}
			return cb_getApplicationInfo;
		}

		private static IntPtr n_GetApplicationInfo(IntPtr jnienv, IntPtr native__this)
		{
			Manifest manifest = Java.Lang.Object.GetObject<Manifest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(manifest.ApplicationInfo);
		}

		private static Delegate GetGetBootloaderInfoHandler()
		{
			if ((object)cb_getBootloaderInfo == null)
			{
				cb_getBootloaderInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBootloaderInfo));
			}
			return cb_getBootloaderInfo;
		}

		private static IntPtr n_GetBootloaderInfo(IntPtr jnienv, IntPtr native__this)
		{
			Manifest manifest = Java.Lang.Object.GetObject<Manifest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(manifest.BootloaderInfo);
		}

		private static Delegate GetIsSecureDfuRequiredHandler()
		{
			if ((object)cb_isSecureDfuRequired == null)
			{
				cb_isSecureDfuRequired = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSecureDfuRequired));
			}
			return cb_isSecureDfuRequired;
		}

		private static bool n_IsSecureDfuRequired(IntPtr jnienv, IntPtr native__this)
		{
			Manifest manifest = Java.Lang.Object.GetObject<Manifest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return manifest.IsSecureDfuRequired;
		}

		private static Delegate GetGetSoftdeviceBootloaderInfoHandler()
		{
			if ((object)cb_getSoftdeviceBootloaderInfo == null)
			{
				cb_getSoftdeviceBootloaderInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSoftdeviceBootloaderInfo));
			}
			return cb_getSoftdeviceBootloaderInfo;
		}

		private static IntPtr n_GetSoftdeviceBootloaderInfo(IntPtr jnienv, IntPtr native__this)
		{
			Manifest manifest = Java.Lang.Object.GetObject<Manifest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(manifest.SoftdeviceBootloaderInfo);
		}

		private static Delegate GetGetSoftdeviceInfoHandler()
		{
			if ((object)cb_getSoftdeviceInfo == null)
			{
				cb_getSoftdeviceInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSoftdeviceInfo));
			}
			return cb_getSoftdeviceInfo;
		}

		private static IntPtr n_GetSoftdeviceInfo(IntPtr jnienv, IntPtr native__this)
		{
			Manifest manifest = Java.Lang.Object.GetObject<Manifest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(manifest.SoftdeviceInfo);
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/manifest/ManifestFile", DoNotGenerateAcw = true)]
	public class ManifestFile : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/manifest/ManifestFile", typeof(ManifestFile));

		private static Delegate cb_getManifest;

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

		public unsafe virtual Manifest Manifest
		{
			[Register("getManifest", "()Lno/nordicsemi/android/dfu/internal/manifest/Manifest;", "GetGetManifestHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Manifest>(_members.InstanceMethods.InvokeVirtualObjectMethod("getManifest.()Lno/nordicsemi/android/dfu/internal/manifest/Manifest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ManifestFile(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ManifestFile()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetManifestHandler()
		{
			if ((object)cb_getManifest == null)
			{
				cb_getManifest = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetManifest));
			}
			return cb_getManifest;
		}

		private static IntPtr n_GetManifest(IntPtr jnienv, IntPtr native__this)
		{
			ManifestFile manifestFile = Java.Lang.Object.GetObject<ManifestFile>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(manifestFile.Manifest);
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/manifest/SoftDeviceBootloaderFileInfo", DoNotGenerateAcw = true)]
	public class SoftDeviceBootloaderFileInfo : FileInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/manifest/SoftDeviceBootloaderFileInfo", typeof(SoftDeviceBootloaderFileInfo));

		private static Delegate cb_getBootloaderSize;

		private static Delegate cb_getSoftdeviceSize;

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

		public unsafe virtual int BootloaderSize
		{
			[Register("getBootloaderSize", "()I", "GetGetBootloaderSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBootloaderSize.()I", this, null);
			}
		}

		public unsafe virtual int SoftdeviceSize
		{
			[Register("getSoftdeviceSize", "()I", "GetGetSoftdeviceSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSoftdeviceSize.()I", this, null);
			}
		}

		protected SoftDeviceBootloaderFileInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SoftDeviceBootloaderFileInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetBootloaderSizeHandler()
		{
			if ((object)cb_getBootloaderSize == null)
			{
				cb_getBootloaderSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBootloaderSize));
			}
			return cb_getBootloaderSize;
		}

		private static int n_GetBootloaderSize(IntPtr jnienv, IntPtr native__this)
		{
			SoftDeviceBootloaderFileInfo softDeviceBootloaderFileInfo = Java.Lang.Object.GetObject<SoftDeviceBootloaderFileInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return softDeviceBootloaderFileInfo.BootloaderSize;
		}

		private static Delegate GetGetSoftdeviceSizeHandler()
		{
			if ((object)cb_getSoftdeviceSize == null)
			{
				cb_getSoftdeviceSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSoftdeviceSize));
			}
			return cb_getSoftdeviceSize;
		}

		private static int n_GetSoftdeviceSize(IntPtr jnienv, IntPtr native__this)
		{
			SoftDeviceBootloaderFileInfo softDeviceBootloaderFileInfo = Java.Lang.Object.GetObject<SoftDeviceBootloaderFileInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return softDeviceBootloaderFileInfo.SoftdeviceSize;
		}
	}
}
namespace NO.Nordicsemi.Android.Dfu.Internal.Exception
{
	[Register("no/nordicsemi/android/dfu/internal/exception/DeviceDisconnectedException", DoNotGenerateAcw = true)]
	public class DeviceDisconnectedException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/DeviceDisconnectedException", typeof(DeviceDisconnectedException));

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

		protected DeviceDisconnectedException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe DeviceDisconnectedException(string p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
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
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/DfuException", DoNotGenerateAcw = true)]
	public class DfuException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/DfuException", typeof(DfuException));

		private static Delegate cb_getErrorNumber;

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

		public unsafe virtual int ErrorNumber
		{
			[Register("getErrorNumber", "()I", "GetGetErrorNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getErrorNumber.()I", this, null);
			}
		}

		protected DfuException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;I)V", "")]
		public unsafe DfuException(string p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetErrorNumberHandler()
		{
			if ((object)cb_getErrorNumber == null)
			{
				cb_getErrorNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetErrorNumber));
			}
			return cb_getErrorNumber;
		}

		private static int n_GetErrorNumber(IntPtr jnienv, IntPtr native__this)
		{
			DfuException ex = Java.Lang.Object.GetObject<DfuException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return ex.ErrorNumber;
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/HexFileValidationException", DoNotGenerateAcw = true)]
	public class HexFileValidationException : Java.IO.IOException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/HexFileValidationException", typeof(HexFileValidationException));

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

		protected HexFileValidationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe HexFileValidationException(string p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
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
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/RemoteDfuException", DoNotGenerateAcw = true)]
	public class RemoteDfuException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/RemoteDfuException", typeof(RemoteDfuException));

		private static Delegate cb_getErrorNumber;

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

		public unsafe virtual int ErrorNumber
		{
			[Register("getErrorNumber", "()I", "GetGetErrorNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getErrorNumber.()I", this, null);
			}
		}

		protected RemoteDfuException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;I)V", "")]
		public unsafe RemoteDfuException(string p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetErrorNumberHandler()
		{
			if ((object)cb_getErrorNumber == null)
			{
				cb_getErrorNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetErrorNumber));
			}
			return cb_getErrorNumber;
		}

		private static int n_GetErrorNumber(IntPtr jnienv, IntPtr native__this)
		{
			RemoteDfuException ex = Java.Lang.Object.GetObject<RemoteDfuException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return ex.ErrorNumber;
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/RemoteDfuExtendedErrorException", DoNotGenerateAcw = true)]
	public class RemoteDfuExtendedErrorException : RemoteDfuException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/RemoteDfuExtendedErrorException", typeof(RemoteDfuExtendedErrorException));

		private static Delegate cb_getExtendedErrorNumber;

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

		public unsafe virtual int ExtendedErrorNumber
		{
			[Register("getExtendedErrorNumber", "()I", "GetGetExtendedErrorNumberHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getExtendedErrorNumber.()I", this, null);
			}
		}

		protected RemoteDfuExtendedErrorException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;I)V", "")]
		public unsafe RemoteDfuExtendedErrorException(string p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetExtendedErrorNumberHandler()
		{
			if ((object)cb_getExtendedErrorNumber == null)
			{
				cb_getExtendedErrorNumber = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetExtendedErrorNumber));
			}
			return cb_getExtendedErrorNumber;
		}

		private static int n_GetExtendedErrorNumber(IntPtr jnienv, IntPtr native__this)
		{
			RemoteDfuExtendedErrorException ex = Java.Lang.Object.GetObject<RemoteDfuExtendedErrorException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return ex.ExtendedErrorNumber;
		}
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/SizeValidationException", DoNotGenerateAcw = true)]
	public class SizeValidationException : Java.IO.IOException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/SizeValidationException", typeof(SizeValidationException));

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

		protected SizeValidationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe SizeValidationException(string p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
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
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/UnknownResponseException", DoNotGenerateAcw = true)]
	public class UnknownResponseException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/UnknownResponseException", typeof(UnknownResponseException));

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

		protected UnknownResponseException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;[BII)V", "")]
		public unsafe UnknownResponseException(string p0, byte[] p1, int p2, int p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;[BII)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;[BII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(p1);
			}
		}

		[Register("bytesToHex", "([BII)Ljava/lang/String;", "")]
		public unsafe static string BytesToHex(byte[] p0, int p1, int p2)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("bytesToHex.([BII)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	}
	[Register("no/nordicsemi/android/dfu/internal/exception/UploadAbortedException", DoNotGenerateAcw = true)]
	public class UploadAbortedException : Java.Lang.Exception
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("no/nordicsemi/android/dfu/internal/exception/UploadAbortedException", typeof(UploadAbortedException));

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

		protected UploadAbortedException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UploadAbortedException()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[0], new Converter<string, Type>[0]);
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
	}
}
