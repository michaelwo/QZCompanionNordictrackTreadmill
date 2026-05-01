using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Xamarin.Android.Binding.InstallReferrer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Xamarin.Android.Binding.InstallReferrer")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: NamespaceMapping(Java = "com.android.installreferrer.api", Managed = "Com.Android.Installreferrer.Api")]
[assembly: NamespaceMapping(Java = "com.android.installreferrer.commons", Managed = "Com.Android.Installreferrer.Commons")]
[assembly: NamespaceMapping(Java = "com.google.android.finsky.externalreferrer", Managed = "Com.Google.Android.Finsky.Externalreferrer")]
[assembly: TargetFramework("MonoAndroid,Version=v11.0", FrameworkDisplayName = "Xamarin.Android v11.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
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
namespace Com.Google.Android.Finsky.Externalreferrer
{
	[Register("com/google/android/finsky/externalreferrer/IGetInstallReferrerService", "", "Com.Google.Android.Finsky.Externalreferrer.IGetInstallReferrerServiceInvoker")]
	public interface IGetInstallReferrerService : IInterface, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("c", "(Landroid/os/Bundle;)Landroid/os/Bundle;", "GetC_Landroid_os_Bundle_Handler:Com.Google.Android.Finsky.Externalreferrer.IGetInstallReferrerServiceInvoker, Xamarin.Android.Binding.InstallReferrer")]
		Bundle C(Bundle p0);
	}
	[Register("com/google/android/finsky/externalreferrer/IGetInstallReferrerService", DoNotGenerateAcw = true)]
	internal class IGetInstallReferrerServiceInvoker : Java.Lang.Object, IGetInstallReferrerService, IInterface, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/finsky/externalreferrer/IGetInstallReferrerService", typeof(IGetInstallReferrerServiceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_c_Landroid_os_Bundle_;

		private IntPtr id_c_Landroid_os_Bundle_;

		private static Delegate cb_asBinder;

		private IntPtr id_asBinder;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IGetInstallReferrerService GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IGetInstallReferrerService>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.finsky.externalreferrer.IGetInstallReferrerService"));
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

		public IGetInstallReferrerServiceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetC_Landroid_os_Bundle_Handler()
		{
			if ((object)cb_c_Landroid_os_Bundle_ == null)
			{
				cb_c_Landroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_C_Landroid_os_Bundle_));
			}
			return cb_c_Landroid_os_Bundle_;
		}

		private static IntPtr n_C_Landroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IGetInstallReferrerService getInstallReferrerService = Java.Lang.Object.GetObject<IGetInstallReferrerService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p = Java.Lang.Object.GetObject<Bundle>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(getInstallReferrerService.C(p));
		}

		public unsafe Bundle C(Bundle p0)
		{
			if (id_c_Landroid_os_Bundle_ == IntPtr.Zero)
			{
				id_c_Landroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "c", "(Landroid/os/Bundle;)Landroid/os/Bundle;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Bundle>(JNIEnv.CallObjectMethod(base.Handle, id_c_Landroid_os_Bundle_, ptr), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IGetInstallReferrerService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsBinder());
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
namespace Com.Android.Installreferrer.Commons
{
	[Register("com/android/installreferrer/commons/InstallReferrerCommons", DoNotGenerateAcw = true)]
	public sealed class InstallReferrerCommons : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/commons/InstallReferrerCommons", typeof(InstallReferrerCommons));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal InstallReferrerCommons(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InstallReferrerCommons()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("logVerbose", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void LogVerbose(string p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("logVerbose.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("logWarn", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void LogWarn(string p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("logWarn.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
}
namespace Com.Android.Installreferrer.Api
{
	[Register("com/android/installreferrer/api/InstallReferrerStateListener", "", "Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker")]
	public interface IInstallReferrerStateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onInstallReferrerServiceDisconnected", "()V", "GetOnInstallReferrerServiceDisconnectedHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer")]
		void OnInstallReferrerServiceDisconnected();

		[Register("onInstallReferrerSetupFinished", "(I)V", "GetOnInstallReferrerSetupFinished_IHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer")]
		void OnInstallReferrerSetupFinished(int p0);
	}
	[Register("com/android/installreferrer/api/InstallReferrerStateListener", DoNotGenerateAcw = true)]
	internal class IInstallReferrerStateListenerInvoker : Java.Lang.Object, IInstallReferrerStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/InstallReferrerStateListener", typeof(IInstallReferrerStateListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onInstallReferrerServiceDisconnected;

		private IntPtr id_onInstallReferrerServiceDisconnected;

		private static Delegate cb_onInstallReferrerSetupFinished_I;

		private IntPtr id_onInstallReferrerSetupFinished_I;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IInstallReferrerStateListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInstallReferrerStateListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.android.installreferrer.api.InstallReferrerStateListener"));
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

		public IInstallReferrerStateListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnInstallReferrerServiceDisconnectedHandler()
		{
			if ((object)cb_onInstallReferrerServiceDisconnected == null)
			{
				cb_onInstallReferrerServiceDisconnected = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnInstallReferrerServiceDisconnected));
			}
			return cb_onInstallReferrerServiceDisconnected;
		}

		private static void n_OnInstallReferrerServiceDisconnected(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IInstallReferrerStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnInstallReferrerServiceDisconnected();
		}

		public void OnInstallReferrerServiceDisconnected()
		{
			if (id_onInstallReferrerServiceDisconnected == IntPtr.Zero)
			{
				id_onInstallReferrerServiceDisconnected = JNIEnv.GetMethodID(class_ref, "onInstallReferrerServiceDisconnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onInstallReferrerServiceDisconnected);
		}

		private static Delegate GetOnInstallReferrerSetupFinished_IHandler()
		{
			if ((object)cb_onInstallReferrerSetupFinished_I == null)
			{
				cb_onInstallReferrerSetupFinished_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnInstallReferrerSetupFinished_I));
			}
			return cb_onInstallReferrerSetupFinished_I;
		}

		private static void n_OnInstallReferrerSetupFinished_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<IInstallReferrerStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnInstallReferrerSetupFinished(p0);
		}

		public unsafe void OnInstallReferrerSetupFinished(int p0)
		{
			if (id_onInstallReferrerSetupFinished_I == IntPtr.Zero)
			{
				id_onInstallReferrerSetupFinished_I = JNIEnv.GetMethodID(class_ref, "onInstallReferrerSetupFinished", "(I)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_onInstallReferrerSetupFinished_I, ptr);
		}
	}
	public class InstallReferrerSetupFinishedEventArgs : EventArgs
	{
		private int p0;

		public int P0 => p0;

		public InstallReferrerSetupFinishedEventArgs(int p0)
		{
			this.p0 = p0;
		}
	}
	[Register("mono/com/android/installreferrer/api/InstallReferrerStateListenerImplementor")]
	internal sealed class IInstallReferrerStateListenerImplementor : Java.Lang.Object, IInstallReferrerStateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler OnInstallReferrerServiceDisconnectedHandler;

		public EventHandler<InstallReferrerSetupFinishedEventArgs> OnInstallReferrerSetupFinishedHandler;

		public IInstallReferrerStateListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/android/installreferrer/api/InstallReferrerStateListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnInstallReferrerServiceDisconnected()
		{
			OnInstallReferrerServiceDisconnectedHandler?.Invoke(sender, new EventArgs());
		}

		public void OnInstallReferrerSetupFinished(int p0)
		{
			OnInstallReferrerSetupFinishedHandler?.Invoke(sender, new InstallReferrerSetupFinishedEventArgs(p0));
		}

		internal static bool __IsEmpty(IInstallReferrerStateListenerImplementor value)
		{
			if (value.OnInstallReferrerServiceDisconnectedHandler == null)
			{
				return value.OnInstallReferrerSetupFinishedHandler == null;
			}
			return false;
		}
	}
	[Register("com/android/installreferrer/api/InstallReferrerClient", DoNotGenerateAcw = true)]
	public abstract class InstallReferrerClient : Java.Lang.Object
	{
		[Register("com/android/installreferrer/api/InstallReferrerClient$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/InstallReferrerClient$Builder", typeof(Builder));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("build", "()Lcom/android/installreferrer/api/InstallReferrerClient;", "")]
			public unsafe InstallReferrerClient Build()
			{
				return Java.Lang.Object.GetObject<InstallReferrerClient>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/android/installreferrer/api/InstallReferrerClient;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/android/installreferrer/api/InstallReferrerClient$InstallReferrerResponse", DoNotGenerateAcw = true)]
		public abstract class InstallReferrerResponse : Java.Lang.Object
		{
			[Register("DEVELOPER_ERROR")]
			public const int DeveloperError = 3;

			[Register("FEATURE_NOT_SUPPORTED")]
			public const int FeatureNotSupported = 2;

			[Register("OK")]
			public const int Ok = 0;

			[Register("PERMISSION_ERROR")]
			public const int PermissionError = 4;

			[Register("SERVICE_DISCONNECTED")]
			public const int ServiceDisconnected = -1;

			[Register("SERVICE_UNAVAILABLE")]
			public const int ServiceUnavailable = 1;

			internal InstallReferrerResponse()
			{
			}
		}

		[Register("com/android/installreferrer/api/InstallReferrerClient$InstallReferrerResponse", DoNotGenerateAcw = true)]
		[Obsolete("Use the 'InstallReferrerResponse' type. This type will be removed in a future release.", true)]
		public abstract class InstallReferrerResponseConsts : InstallReferrerResponse
		{
			private InstallReferrerResponseConsts()
			{
			}
		}

		[Register("com/android/installreferrer/api/InstallReferrerClient$InstallReferrerResponse", "", "Com.Android.Installreferrer.Api.InstallReferrerClient/IInstallReferrerResponseInvoker")]
		public interface IInstallReferrerResponse : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("com/android/installreferrer/api/InstallReferrerClient$InstallReferrerResponse", DoNotGenerateAcw = true)]
		internal class IInstallReferrerResponseInvoker : Java.Lang.Object, IInstallReferrerResponse, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/InstallReferrerClient$InstallReferrerResponse", typeof(IInstallReferrerResponseInvoker));

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

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IInstallReferrerResponse GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IInstallReferrerResponse>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.android.installreferrer.api.InstallReferrerClient.InstallReferrerResponse"));
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

			public IInstallReferrerResponseInvoker(IntPtr handle, JniHandleOwnership transfer)
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInstallReferrerResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
				IInstallReferrerResponse installReferrerResponse = Java.Lang.Object.GetObject<IInstallReferrerResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
				return installReferrerResponse.Equals(obj);
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
				return Java.Lang.Object.GetObject<IInstallReferrerResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
				return JNIEnv.NewString(Java.Lang.Object.GetObject<IInstallReferrerResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/InstallReferrerClient", typeof(InstallReferrerClient));

		private static Delegate cb_getInstallReferrer;

		private static Delegate cb_isReady;

		private static Delegate cb_endConnection;

		private static Delegate cb_startConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract ReferrerDetails InstallReferrer
		{
			[Register("getInstallReferrer", "()Lcom/android/installreferrer/api/ReferrerDetails;", "GetGetInstallReferrerHandler")]
			get;
		}

		public abstract bool IsReady
		{
			[Register("isReady", "()Z", "GetIsReadyHandler")]
			get;
		}

		protected InstallReferrerClient(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InstallReferrerClient()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetInstallReferrerHandler()
		{
			if ((object)cb_getInstallReferrer == null)
			{
				cb_getInstallReferrer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInstallReferrer));
			}
			return cb_getInstallReferrer;
		}

		private static IntPtr n_GetInstallReferrer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<InstallReferrerClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallReferrer);
		}

		private static Delegate GetIsReadyHandler()
		{
			if ((object)cb_isReady == null)
			{
				cb_isReady = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsReady));
			}
			return cb_isReady;
		}

		private static bool n_IsReady(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<InstallReferrerClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReady;
		}

		private static Delegate GetEndConnectionHandler()
		{
			if ((object)cb_endConnection == null)
			{
				cb_endConnection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EndConnection));
			}
			return cb_endConnection;
		}

		private static void n_EndConnection(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<InstallReferrerClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndConnection();
		}

		[Register("endConnection", "()V", "GetEndConnectionHandler")]
		public abstract void EndConnection();

		[Register("newBuilder", "(Landroid/content/Context;)Lcom/android/installreferrer/api/InstallReferrerClient$Builder;", "")]
		public unsafe static Builder NewBuilder(Context p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("newBuilder.(Landroid/content/Context;)Lcom/android/installreferrer/api/InstallReferrerClient$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetStartConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_Handler()
		{
			if ((object)cb_startConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_ == null)
			{
				cb_startConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_));
			}
			return cb_startConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_;
		}

		private static void n_StartConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			InstallReferrerClient installReferrerClient = Java.Lang.Object.GetObject<InstallReferrerClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInstallReferrerStateListener p = Java.Lang.Object.GetObject<IInstallReferrerStateListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			installReferrerClient.StartConnection(p);
		}

		[Register("startConnection", "(Lcom/android/installreferrer/api/InstallReferrerStateListener;)V", "GetStartConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_Handler")]
		public abstract void StartConnection(IInstallReferrerStateListener p0);
	}
	[Register("com/android/installreferrer/api/InstallReferrerClient", DoNotGenerateAcw = true)]
	internal class InstallReferrerClientInvoker : InstallReferrerClient
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/InstallReferrerClient", typeof(InstallReferrerClientInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ReferrerDetails InstallReferrer
		{
			[Register("getInstallReferrer", "()Lcom/android/installreferrer/api/ReferrerDetails;", "GetGetInstallReferrerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ReferrerDetails>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInstallReferrer.()Lcom/android/installreferrer/api/ReferrerDetails;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override bool IsReady
		{
			[Register("isReady", "()Z", "GetIsReadyHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReady.()Z", this, null);
			}
		}

		public InstallReferrerClientInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("endConnection", "()V", "GetEndConnectionHandler")]
		public unsafe override void EndConnection()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("endConnection.()V", this, null);
		}

		[Register("startConnection", "(Lcom/android/installreferrer/api/InstallReferrerStateListener;)V", "GetStartConnection_Lcom_android_installreferrer_api_InstallReferrerStateListener_Handler")]
		public unsafe override void StartConnection(IInstallReferrerStateListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("startConnection.(Lcom/android/installreferrer/api/InstallReferrerStateListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/android/installreferrer/api/ReferrerDetails", DoNotGenerateAcw = true)]
	public class ReferrerDetails : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/android/installreferrer/api/ReferrerDetails", typeof(ReferrerDetails));

		private static Delegate cb_getGooglePlayInstantParam;

		private static Delegate cb_getInstallBeginTimestampSeconds;

		private static Delegate cb_getInstallBeginTimestampServerSeconds;

		private static Delegate cb_getInstallReferrer;

		private static Delegate cb_getInstallVersion;

		private static Delegate cb_getReferrerClickTimestampSeconds;

		private static Delegate cb_getReferrerClickTimestampServerSeconds;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool GooglePlayInstantParam
		{
			[Register("getGooglePlayInstantParam", "()Z", "GetGetGooglePlayInstantParamHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getGooglePlayInstantParam.()Z", this, null);
			}
		}

		public unsafe virtual long InstallBeginTimestampSeconds
		{
			[Register("getInstallBeginTimestampSeconds", "()J", "GetGetInstallBeginTimestampSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getInstallBeginTimestampSeconds.()J", this, null);
			}
		}

		public unsafe virtual long InstallBeginTimestampServerSeconds
		{
			[Register("getInstallBeginTimestampServerSeconds", "()J", "GetGetInstallBeginTimestampServerSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getInstallBeginTimestampServerSeconds.()J", this, null);
			}
		}

		public unsafe virtual string InstallReferrer
		{
			[Register("getInstallReferrer", "()Ljava/lang/String;", "GetGetInstallReferrerHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getInstallReferrer.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string InstallVersion
		{
			[Register("getInstallVersion", "()Ljava/lang/String;", "GetGetInstallVersionHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getInstallVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual long ReferrerClickTimestampSeconds
		{
			[Register("getReferrerClickTimestampSeconds", "()J", "GetGetReferrerClickTimestampSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getReferrerClickTimestampSeconds.()J", this, null);
			}
		}

		public unsafe virtual long ReferrerClickTimestampServerSeconds
		{
			[Register("getReferrerClickTimestampServerSeconds", "()J", "GetGetReferrerClickTimestampServerSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getReferrerClickTimestampServerSeconds.()J", this, null);
			}
		}

		protected ReferrerDetails(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/os/Bundle;)V", "")]
		public unsafe ReferrerDetails(Bundle p0)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Bundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetGooglePlayInstantParamHandler()
		{
			if ((object)cb_getGooglePlayInstantParam == null)
			{
				cb_getGooglePlayInstantParam = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetGooglePlayInstantParam));
			}
			return cb_getGooglePlayInstantParam;
		}

		private static bool n_GetGooglePlayInstantParam(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GooglePlayInstantParam;
		}

		private static Delegate GetGetInstallBeginTimestampSecondsHandler()
		{
			if ((object)cb_getInstallBeginTimestampSeconds == null)
			{
				cb_getInstallBeginTimestampSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetInstallBeginTimestampSeconds));
			}
			return cb_getInstallBeginTimestampSeconds;
		}

		private static long n_GetInstallBeginTimestampSeconds(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallBeginTimestampSeconds;
		}

		private static Delegate GetGetInstallBeginTimestampServerSecondsHandler()
		{
			if ((object)cb_getInstallBeginTimestampServerSeconds == null)
			{
				cb_getInstallBeginTimestampServerSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetInstallBeginTimestampServerSeconds));
			}
			return cb_getInstallBeginTimestampServerSeconds;
		}

		private static long n_GetInstallBeginTimestampServerSeconds(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallBeginTimestampServerSeconds;
		}

		private static Delegate GetGetInstallReferrerHandler()
		{
			if ((object)cb_getInstallReferrer == null)
			{
				cb_getInstallReferrer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInstallReferrer));
			}
			return cb_getInstallReferrer;
		}

		private static IntPtr n_GetInstallReferrer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallReferrer);
		}

		private static Delegate GetGetInstallVersionHandler()
		{
			if ((object)cb_getInstallVersion == null)
			{
				cb_getInstallVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInstallVersion));
			}
			return cb_getInstallVersion;
		}

		private static IntPtr n_GetInstallVersion(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallVersion);
		}

		private static Delegate GetGetReferrerClickTimestampSecondsHandler()
		{
			if ((object)cb_getReferrerClickTimestampSeconds == null)
			{
				cb_getReferrerClickTimestampSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetReferrerClickTimestampSeconds));
			}
			return cb_getReferrerClickTimestampSeconds;
		}

		private static long n_GetReferrerClickTimestampSeconds(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReferrerClickTimestampSeconds;
		}

		private static Delegate GetGetReferrerClickTimestampServerSecondsHandler()
		{
			if ((object)cb_getReferrerClickTimestampServerSeconds == null)
			{
				cb_getReferrerClickTimestampServerSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetReferrerClickTimestampServerSeconds));
			}
			return cb_getReferrerClickTimestampServerSeconds;
		}

		private static long n_GetReferrerClickTimestampServerSeconds(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ReferrerDetails>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReferrerClickTimestampServerSeconds;
		}
	}
}
