using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.backend.cct", Managed = "Xamarin.Google.Android.DataTransport.Backend.Cct")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.cct", Managed = "Xamarin.Google.Android.DataTransport.Cct")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.cct.internal", Managed = "Xamarin.Google.Android.DataTransport.Cct.Internal")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Android.DataTransport.TransportBackendCct")]
[assembly: AssemblyTitle("Xamarin.Google.Android.DataTransport.TransportBackendCct")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
namespace Xamarin.Google.Android.DataTransport.Cct
{
	[Register("com/google/android/datatransport/cct/StringMerger", DoNotGenerateAcw = true)]
	public sealed class StringMerger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/StringMerger", typeof(StringMerger));

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

		internal StringMerger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe StringMerger()
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
namespace Xamarin.Google.Android.DataTransport.Cct.Internal
{
	[Register("com/google/android/datatransport/cct/internal/AndroidClientInfo", DoNotGenerateAcw = true)]
	public abstract class AndroidClientInfo : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/cct/internal/AndroidClientInfo$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/AndroidClientInfo$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setApplicationBuild_Ljava_lang_String_;

			private static Delegate cb_setCountry_Ljava_lang_String_;

			private static Delegate cb_setDevice_Ljava_lang_String_;

			private static Delegate cb_setFingerprint_Ljava_lang_String_;

			private static Delegate cb_setHardware_Ljava_lang_String_;

			private static Delegate cb_setLocale_Ljava_lang_String_;

			private static Delegate cb_setManufacturer_Ljava_lang_String_;

			private static Delegate cb_setMccMnc_Ljava_lang_String_;

			private static Delegate cb_setModel_Ljava_lang_String_;

			private static Delegate cb_setOsBuild_Ljava_lang_String_;

			private static Delegate cb_setProduct_Ljava_lang_String_;

			private static Delegate cb_setSdkVersion_Ljava_lang_Integer_;

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

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", "GetBuildHandler")]
			public abstract AndroidClientInfo Build();

			private static Delegate GetSetApplicationBuild_Ljava_lang_String_Handler()
			{
				if ((object)cb_setApplicationBuild_Ljava_lang_String_ == null)
				{
					cb_setApplicationBuild_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetApplicationBuild_Ljava_lang_String_));
				}
				return cb_setApplicationBuild_Ljava_lang_String_;
			}

			private static IntPtr n_SetApplicationBuild_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string applicationBuild = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetApplicationBuild(applicationBuild));
			}

			[Register("setApplicationBuild", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetApplicationBuild_Ljava_lang_String_Handler")]
			public abstract Builder SetApplicationBuild(string p0);

			private static Delegate GetSetCountry_Ljava_lang_String_Handler()
			{
				if ((object)cb_setCountry_Ljava_lang_String_ == null)
				{
					cb_setCountry_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCountry_Ljava_lang_String_));
				}
				return cb_setCountry_Ljava_lang_String_;
			}

			private static IntPtr n_SetCountry_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string country = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetCountry(country));
			}

			[Register("setCountry", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetCountry_Ljava_lang_String_Handler")]
			public abstract Builder SetCountry(string p0);

			private static Delegate GetSetDevice_Ljava_lang_String_Handler()
			{
				if ((object)cb_setDevice_Ljava_lang_String_ == null)
				{
					cb_setDevice_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDevice_Ljava_lang_String_));
				}
				return cb_setDevice_Ljava_lang_String_;
			}

			private static IntPtr n_SetDevice_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string device = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetDevice(device));
			}

			[Register("setDevice", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetDevice_Ljava_lang_String_Handler")]
			public abstract Builder SetDevice(string p0);

			private static Delegate GetSetFingerprint_Ljava_lang_String_Handler()
			{
				if ((object)cb_setFingerprint_Ljava_lang_String_ == null)
				{
					cb_setFingerprint_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFingerprint_Ljava_lang_String_));
				}
				return cb_setFingerprint_Ljava_lang_String_;
			}

			private static IntPtr n_SetFingerprint_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string fingerprint = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetFingerprint(fingerprint));
			}

			[Register("setFingerprint", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetFingerprint_Ljava_lang_String_Handler")]
			public abstract Builder SetFingerprint(string p0);

			private static Delegate GetSetHardware_Ljava_lang_String_Handler()
			{
				if ((object)cb_setHardware_Ljava_lang_String_ == null)
				{
					cb_setHardware_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetHardware_Ljava_lang_String_));
				}
				return cb_setHardware_Ljava_lang_String_;
			}

			private static IntPtr n_SetHardware_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string hardware = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetHardware(hardware));
			}

			[Register("setHardware", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetHardware_Ljava_lang_String_Handler")]
			public abstract Builder SetHardware(string p0);

			private static Delegate GetSetLocale_Ljava_lang_String_Handler()
			{
				if ((object)cb_setLocale_Ljava_lang_String_ == null)
				{
					cb_setLocale_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLocale_Ljava_lang_String_));
				}
				return cb_setLocale_Ljava_lang_String_;
			}

			private static IntPtr n_SetLocale_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string locale = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetLocale(locale));
			}

			[Register("setLocale", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetLocale_Ljava_lang_String_Handler")]
			public abstract Builder SetLocale(string p0);

			private static Delegate GetSetManufacturer_Ljava_lang_String_Handler()
			{
				if ((object)cb_setManufacturer_Ljava_lang_String_ == null)
				{
					cb_setManufacturer_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetManufacturer_Ljava_lang_String_));
				}
				return cb_setManufacturer_Ljava_lang_String_;
			}

			private static IntPtr n_SetManufacturer_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string manufacturer = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetManufacturer(manufacturer));
			}

			[Register("setManufacturer", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetManufacturer_Ljava_lang_String_Handler")]
			public abstract Builder SetManufacturer(string p0);

			private static Delegate GetSetMccMnc_Ljava_lang_String_Handler()
			{
				if ((object)cb_setMccMnc_Ljava_lang_String_ == null)
				{
					cb_setMccMnc_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMccMnc_Ljava_lang_String_));
				}
				return cb_setMccMnc_Ljava_lang_String_;
			}

			private static IntPtr n_SetMccMnc_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string mccMnc = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMccMnc(mccMnc));
			}

			[Register("setMccMnc", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetMccMnc_Ljava_lang_String_Handler")]
			public abstract Builder SetMccMnc(string p0);

			private static Delegate GetSetModel_Ljava_lang_String_Handler()
			{
				if ((object)cb_setModel_Ljava_lang_String_ == null)
				{
					cb_setModel_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetModel_Ljava_lang_String_));
				}
				return cb_setModel_Ljava_lang_String_;
			}

			private static IntPtr n_SetModel_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string model = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetModel(model));
			}

			[Register("setModel", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetModel_Ljava_lang_String_Handler")]
			public abstract Builder SetModel(string p0);

			private static Delegate GetSetOsBuild_Ljava_lang_String_Handler()
			{
				if ((object)cb_setOsBuild_Ljava_lang_String_ == null)
				{
					cb_setOsBuild_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetOsBuild_Ljava_lang_String_));
				}
				return cb_setOsBuild_Ljava_lang_String_;
			}

			private static IntPtr n_SetOsBuild_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string osBuild = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetOsBuild(osBuild));
			}

			[Register("setOsBuild", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetOsBuild_Ljava_lang_String_Handler")]
			public abstract Builder SetOsBuild(string p0);

			private static Delegate GetSetProduct_Ljava_lang_String_Handler()
			{
				if ((object)cb_setProduct_Ljava_lang_String_ == null)
				{
					cb_setProduct_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetProduct_Ljava_lang_String_));
				}
				return cb_setProduct_Ljava_lang_String_;
			}

			private static IntPtr n_SetProduct_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string product = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetProduct(product));
			}

			[Register("setProduct", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetProduct_Ljava_lang_String_Handler")]
			public abstract Builder SetProduct(string p0);

			private static Delegate GetSetSdkVersion_Ljava_lang_Integer_Handler()
			{
				if ((object)cb_setSdkVersion_Ljava_lang_Integer_ == null)
				{
					cb_setSdkVersion_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSdkVersion_Ljava_lang_Integer_));
				}
				return cb_setSdkVersion_Ljava_lang_Integer_;
			}

			private static IntPtr n_SetSdkVersion_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Integer sdkVersion = Java.Lang.Object.GetObject<Integer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSdkVersion(sdkVersion));
			}

			[Register("setSdkVersion", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetSdkVersion_Ljava_lang_Integer_Handler")]
			public abstract Builder SetSdkVersion(Integer p0);
		}

		[Register("com/google/android/datatransport/cct/internal/AndroidClientInfo$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/AndroidClientInfo$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", "GetBuildHandler")]
			public unsafe override AndroidClientInfo Build()
			{
				return Java.Lang.Object.GetObject<AndroidClientInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setApplicationBuild", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetApplicationBuild_Ljava_lang_String_Handler")]
			public unsafe override Builder SetApplicationBuild(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setApplicationBuild.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setCountry", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetCountry_Ljava_lang_String_Handler")]
			public unsafe override Builder SetCountry(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCountry.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setDevice", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetDevice_Ljava_lang_String_Handler")]
			public unsafe override Builder SetDevice(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDevice.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setFingerprint", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetFingerprint_Ljava_lang_String_Handler")]
			public unsafe override Builder SetFingerprint(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFingerprint.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setHardware", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetHardware_Ljava_lang_String_Handler")]
			public unsafe override Builder SetHardware(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHardware.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setLocale", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetLocale_Ljava_lang_String_Handler")]
			public unsafe override Builder SetLocale(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLocale.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setManufacturer", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetManufacturer_Ljava_lang_String_Handler")]
			public unsafe override Builder SetManufacturer(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setManufacturer.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setMccMnc", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetMccMnc_Ljava_lang_String_Handler")]
			public unsafe override Builder SetMccMnc(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMccMnc.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setModel", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetModel_Ljava_lang_String_Handler")]
			public unsafe override Builder SetModel(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setModel.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setOsBuild", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetOsBuild_Ljava_lang_String_Handler")]
			public unsafe override Builder SetOsBuild(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOsBuild.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setProduct", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetProduct_Ljava_lang_String_Handler")]
			public unsafe override Builder SetProduct(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setProduct.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setSdkVersion", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "GetSetSdkVersion_Ljava_lang_Integer_Handler")]
			public unsafe override Builder SetSdkVersion(Integer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSdkVersion.(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/AndroidClientInfo", typeof(AndroidClientInfo));

		private static Delegate cb_getApplicationBuild;

		private static Delegate cb_getCountry;

		private static Delegate cb_getDevice;

		private static Delegate cb_getFingerprint;

		private static Delegate cb_getHardware;

		private static Delegate cb_getLocale;

		private static Delegate cb_getManufacturer;

		private static Delegate cb_getMccMnc;

		private static Delegate cb_getModel;

		private static Delegate cb_getOsBuild;

		private static Delegate cb_getProduct;

		private static Delegate cb_getSdkVersion;

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

		public abstract string ApplicationBuild
		{
			[Register("getApplicationBuild", "()Ljava/lang/String;", "GetGetApplicationBuildHandler")]
			get;
		}

		public abstract string Country
		{
			[Register("getCountry", "()Ljava/lang/String;", "GetGetCountryHandler")]
			get;
		}

		public abstract string Device
		{
			[Register("getDevice", "()Ljava/lang/String;", "GetGetDeviceHandler")]
			get;
		}

		public abstract string Fingerprint
		{
			[Register("getFingerprint", "()Ljava/lang/String;", "GetGetFingerprintHandler")]
			get;
		}

		public abstract string Hardware
		{
			[Register("getHardware", "()Ljava/lang/String;", "GetGetHardwareHandler")]
			get;
		}

		public abstract string Locale
		{
			[Register("getLocale", "()Ljava/lang/String;", "GetGetLocaleHandler")]
			get;
		}

		public abstract string Manufacturer
		{
			[Register("getManufacturer", "()Ljava/lang/String;", "GetGetManufacturerHandler")]
			get;
		}

		public abstract string MccMnc
		{
			[Register("getMccMnc", "()Ljava/lang/String;", "GetGetMccMncHandler")]
			get;
		}

		public abstract string Model
		{
			[Register("getModel", "()Ljava/lang/String;", "GetGetModelHandler")]
			get;
		}

		public abstract string OsBuild
		{
			[Register("getOsBuild", "()Ljava/lang/String;", "GetGetOsBuildHandler")]
			get;
		}

		public abstract string Product
		{
			[Register("getProduct", "()Ljava/lang/String;", "GetGetProductHandler")]
			get;
		}

		public abstract Integer SdkVersion
		{
			[Register("getSdkVersion", "()Ljava/lang/Integer;", "GetGetSdkVersionHandler")]
			get;
		}

		protected AndroidClientInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AndroidClientInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetApplicationBuildHandler()
		{
			if ((object)cb_getApplicationBuild == null)
			{
				cb_getApplicationBuild = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetApplicationBuild));
			}
			return cb_getApplicationBuild;
		}

		private static IntPtr n_GetApplicationBuild(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationBuild);
		}

		private static Delegate GetGetCountryHandler()
		{
			if ((object)cb_getCountry == null)
			{
				cb_getCountry = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCountry));
			}
			return cb_getCountry;
		}

		private static IntPtr n_GetCountry(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Country);
		}

		private static Delegate GetGetDeviceHandler()
		{
			if ((object)cb_getDevice == null)
			{
				cb_getDevice = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDevice));
			}
			return cb_getDevice;
		}

		private static IntPtr n_GetDevice(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Device);
		}

		private static Delegate GetGetFingerprintHandler()
		{
			if ((object)cb_getFingerprint == null)
			{
				cb_getFingerprint = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFingerprint));
			}
			return cb_getFingerprint;
		}

		private static IntPtr n_GetFingerprint(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fingerprint);
		}

		private static Delegate GetGetHardwareHandler()
		{
			if ((object)cb_getHardware == null)
			{
				cb_getHardware = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHardware));
			}
			return cb_getHardware;
		}

		private static IntPtr n_GetHardware(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hardware);
		}

		private static Delegate GetGetLocaleHandler()
		{
			if ((object)cb_getLocale == null)
			{
				cb_getLocale = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLocale));
			}
			return cb_getLocale;
		}

		private static IntPtr n_GetLocale(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Locale);
		}

		private static Delegate GetGetManufacturerHandler()
		{
			if ((object)cb_getManufacturer == null)
			{
				cb_getManufacturer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetManufacturer));
			}
			return cb_getManufacturer;
		}

		private static IntPtr n_GetManufacturer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Manufacturer);
		}

		private static Delegate GetGetMccMncHandler()
		{
			if ((object)cb_getMccMnc == null)
			{
				cb_getMccMnc = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMccMnc));
			}
			return cb_getMccMnc;
		}

		private static IntPtr n_GetMccMnc(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MccMnc);
		}

		private static Delegate GetGetModelHandler()
		{
			if ((object)cb_getModel == null)
			{
				cb_getModel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetModel));
			}
			return cb_getModel;
		}

		private static IntPtr n_GetModel(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Model);
		}

		private static Delegate GetGetOsBuildHandler()
		{
			if ((object)cb_getOsBuild == null)
			{
				cb_getOsBuild = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOsBuild));
			}
			return cb_getOsBuild;
		}

		private static IntPtr n_GetOsBuild(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OsBuild);
		}

		private static Delegate GetGetProductHandler()
		{
			if ((object)cb_getProduct == null)
			{
				cb_getProduct = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetProduct));
			}
			return cb_getProduct;
		}

		private static IntPtr n_GetProduct(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Product);
		}

		private static Delegate GetGetSdkVersionHandler()
		{
			if ((object)cb_getSdkVersion == null)
			{
				cb_getSdkVersion = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSdkVersion));
			}
			return cb_getSdkVersion;
		}

		private static IntPtr n_GetSdkVersion(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AndroidClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SdkVersion);
		}

		[Register("builder", "()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/cct/internal/AndroidClientInfo", DoNotGenerateAcw = true)]
	internal class AndroidClientInfoInvoker : AndroidClientInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/AndroidClientInfo", typeof(AndroidClientInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string ApplicationBuild
		{
			[Register("getApplicationBuild", "()Ljava/lang/String;", "GetGetApplicationBuildHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationBuild.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Country
		{
			[Register("getCountry", "()Ljava/lang/String;", "GetGetCountryHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getCountry.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Device
		{
			[Register("getDevice", "()Ljava/lang/String;", "GetGetDeviceHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDevice.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Fingerprint
		{
			[Register("getFingerprint", "()Ljava/lang/String;", "GetGetFingerprintHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getFingerprint.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Hardware
		{
			[Register("getHardware", "()Ljava/lang/String;", "GetGetHardwareHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getHardware.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Locale
		{
			[Register("getLocale", "()Ljava/lang/String;", "GetGetLocaleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocale.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Manufacturer
		{
			[Register("getManufacturer", "()Ljava/lang/String;", "GetGetManufacturerHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getManufacturer.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string MccMnc
		{
			[Register("getMccMnc", "()Ljava/lang/String;", "GetGetMccMncHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMccMnc.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Model
		{
			[Register("getModel", "()Ljava/lang/String;", "GetGetModelHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getModel.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string OsBuild
		{
			[Register("getOsBuild", "()Ljava/lang/String;", "GetGetOsBuildHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getOsBuild.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string Product
		{
			[Register("getProduct", "()Ljava/lang/String;", "GetGetProductHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProduct.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Integer SdkVersion
		{
			[Register("getSdkVersion", "()Ljava/lang/Integer;", "GetGetSdkVersionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSdkVersion.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public AndroidClientInfoInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/cct/internal/BatchedLogRequest", DoNotGenerateAcw = true)]
	public abstract class BatchedLogRequest : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/BatchedLogRequest", typeof(BatchedLogRequest));

		private static Delegate cb_getLogRequests;

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

		public abstract IList<LogRequest> LogRequests
		{
			[Register("getLogRequests", "()Ljava/util/List;", "GetGetLogRequestsHandler")]
			get;
		}

		protected BatchedLogRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BatchedLogRequest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetLogRequestsHandler()
		{
			if ((object)cb_getLogRequests == null)
			{
				cb_getLogRequests = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLogRequests));
			}
			return cb_getLogRequests;
		}

		private static IntPtr n_GetLogRequests(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<LogRequest>.ToLocalJniHandle(Java.Lang.Object.GetObject<BatchedLogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogRequests);
		}

		[Register("create", "(Ljava/util/List;)Lcom/google/android/datatransport/cct/internal/BatchedLogRequest;", "")]
		public unsafe static BatchedLogRequest Create(IList<LogRequest> logRequests)
		{
			IntPtr intPtr = JavaList<LogRequest>.ToLocalJniHandle(logRequests);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BatchedLogRequest>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/util/List;)Lcom/google/android/datatransport/cct/internal/BatchedLogRequest;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(logRequests);
			}
		}
	}
	[Register("com/google/android/datatransport/cct/internal/BatchedLogRequest", DoNotGenerateAcw = true)]
	internal class BatchedLogRequestInvoker : BatchedLogRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/BatchedLogRequest", typeof(BatchedLogRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IList<LogRequest> LogRequests
		{
			[Register("getLogRequests", "()Ljava/util/List;", "GetGetLogRequestsHandler")]
			get
			{
				return JavaList<LogRequest>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getLogRequests.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public BatchedLogRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/cct/internal/ClientInfo", DoNotGenerateAcw = true)]
	public abstract class ClientInfo : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/cct/internal/ClientInfo$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/ClientInfo$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_;

			private static Delegate cb_setClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_;

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

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/ClientInfo;", "GetBuildHandler")]
			public abstract ClientInfo Build();

			private static Delegate GetSetAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_Handler()
			{
				if ((object)cb_setAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_ == null)
				{
					cb_setAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_));
				}
				return cb_setAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_;
			}

			private static IntPtr n_SetAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AndroidClientInfo androidClientInfo = Java.Lang.Object.GetObject<AndroidClientInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetAndroidClientInfo(androidClientInfo));
			}

			[Register("setAndroidClientInfo", "(Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", "GetSetAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_Handler")]
			public abstract Builder SetAndroidClientInfo(AndroidClientInfo p0);

			private static Delegate GetSetClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_Handler()
			{
				if ((object)cb_setClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_ == null)
				{
					cb_setClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_));
				}
				return cb_setClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_;
			}

			private static IntPtr n_SetClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ClientType clientType = Java.Lang.Object.GetObject<ClientType>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetClientType(clientType));
			}

			[Register("setClientType", "(Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", "GetSetClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_Handler")]
			public abstract Builder SetClientType(ClientType p0);
		}

		[Register("com/google/android/datatransport/cct/internal/ClientInfo$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/ClientInfo$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/ClientInfo;", "GetBuildHandler")]
			public unsafe override ClientInfo Build()
			{
				return Java.Lang.Object.GetObject<ClientInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/cct/internal/ClientInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setAndroidClientInfo", "(Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", "GetSetAndroidClientInfo_Lcom_google_android_datatransport_cct_internal_AndroidClientInfo_Handler")]
			public unsafe override Builder SetAndroidClientInfo(AndroidClientInfo p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAndroidClientInfo.(Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setClientType", "(Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", "GetSetClientType_Lcom_google_android_datatransport_cct_internal_ClientInfo_ClientType_Handler")]
			public unsafe override Builder SetClientType(ClientType p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setClientType.(Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;)Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		[Register("com/google/android/datatransport/cct/internal/ClientInfo$ClientType", DoNotGenerateAcw = true)]
		public sealed class ClientType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/ClientInfo$ClientType", typeof(ClientType));

			[Register("ANDROID_FIREBASE")]
			public static ClientType AndroidFirebase => Java.Lang.Object.GetObject<ClientType>(_members.StaticFields.GetObjectValue("ANDROID_FIREBASE.Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNKNOWN")]
			public static ClientType Unknown => Java.Lang.Object.GetObject<ClientType>(_members.StaticFields.GetObjectValue("UNKNOWN.Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal ClientType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", "")]
			public unsafe static ClientType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ClientType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", "")]
			public unsafe static ClientType[] Values()
			{
				return (ClientType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ClientType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/ClientInfo", typeof(ClientInfo));

		private static Delegate cb_getAndroidClientInfo;

		private static Delegate cb_getClientType;

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

		public abstract AndroidClientInfo AndroidClientInfo
		{
			[Register("getAndroidClientInfo", "()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", "GetGetAndroidClientInfoHandler")]
			get;
		}

		protected ClientInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ClientInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAndroidClientInfoHandler()
		{
			if ((object)cb_getAndroidClientInfo == null)
			{
				cb_getAndroidClientInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAndroidClientInfo));
			}
			return cb_getAndroidClientInfo;
		}

		private static IntPtr n_GetAndroidClientInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AndroidClientInfo);
		}

		[Register("builder", "()Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/cct/internal/ClientInfo$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetClientTypeHandler()
		{
			if ((object)cb_getClientType == null)
			{
				cb_getClientType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClientType));
			}
			return cb_getClientType;
		}

		private static IntPtr n_GetClientType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ClientInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetClientType());
		}

		[Register("getClientType", "()Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", "GetGetClientTypeHandler")]
		public abstract ClientType GetClientType();
	}
	[Register("com/google/android/datatransport/cct/internal/ClientInfo", DoNotGenerateAcw = true)]
	internal class ClientInfoInvoker : ClientInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/ClientInfo", typeof(ClientInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override AndroidClientInfo AndroidClientInfo
		{
			[Register("getAndroidClientInfo", "()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", "GetGetAndroidClientInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<AndroidClientInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAndroidClientInfo.()Lcom/google/android/datatransport/cct/internal/AndroidClientInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ClientInfoInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getClientType", "()Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", "GetGetClientTypeHandler")]
		public unsafe override ClientType GetClientType()
		{
			return Java.Lang.Object.GetObject<ClientType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getClientType.()Lcom/google/android/datatransport/cct/internal/ClientInfo$ClientType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogEvent", DoNotGenerateAcw = true)]
	public abstract class LogEvent : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/cct/internal/LogEvent$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogEvent$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setEventCode_Ljava_lang_Integer_;

			private static Delegate cb_setEventTimeMs_J;

			private static Delegate cb_setEventUptimeMs_J;

			private static Delegate cb_setNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_;

			private static Delegate cb_setTimezoneOffsetSeconds_J;

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

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/LogEvent;", "GetBuildHandler")]
			public abstract LogEvent Build();

			private static Delegate GetSetEventCode_Ljava_lang_Integer_Handler()
			{
				if ((object)cb_setEventCode_Ljava_lang_Integer_ == null)
				{
					cb_setEventCode_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetEventCode_Ljava_lang_Integer_));
				}
				return cb_setEventCode_Ljava_lang_Integer_;
			}

			private static IntPtr n_SetEventCode_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Integer eventCode = Java.Lang.Object.GetObject<Integer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetEventCode(eventCode));
			}

			[Register("setEventCode", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventCode_Ljava_lang_Integer_Handler")]
			public abstract Builder SetEventCode(Integer p0);

			private static Delegate GetSetEventTimeMs_JHandler()
			{
				if ((object)cb_setEventTimeMs_J == null)
				{
					cb_setEventTimeMs_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetEventTimeMs_J));
				}
				return cb_setEventTimeMs_J;
			}

			private static IntPtr n_SetEventTimeMs_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEventTimeMs(p0));
			}

			[Register("setEventTimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventTimeMs_JHandler")]
			public abstract Builder SetEventTimeMs(long p0);

			private static Delegate GetSetEventUptimeMs_JHandler()
			{
				if ((object)cb_setEventUptimeMs_J == null)
				{
					cb_setEventUptimeMs_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetEventUptimeMs_J));
				}
				return cb_setEventUptimeMs_J;
			}

			private static IntPtr n_SetEventUptimeMs_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEventUptimeMs(p0));
			}

			[Register("setEventUptimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventUptimeMs_JHandler")]
			public abstract Builder SetEventUptimeMs(long p0);

			private static Delegate GetSetNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_Handler()
			{
				if ((object)cb_setNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_ == null)
				{
					cb_setNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_));
				}
				return cb_setNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_;
			}

			private static IntPtr n_SetNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				NetworkConnectionInfo networkConnectionInfo = Java.Lang.Object.GetObject<NetworkConnectionInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNetworkConnectionInfo(networkConnectionInfo));
			}

			[Register("setNetworkConnectionInfo", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_Handler")]
			public abstract Builder SetNetworkConnectionInfo(NetworkConnectionInfo p0);

			private static Delegate GetSetTimezoneOffsetSeconds_JHandler()
			{
				if ((object)cb_setTimezoneOffsetSeconds_J == null)
				{
					cb_setTimezoneOffsetSeconds_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetTimezoneOffsetSeconds_J));
				}
				return cb_setTimezoneOffsetSeconds_J;
			}

			private static IntPtr n_SetTimezoneOffsetSeconds_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTimezoneOffsetSeconds(p0));
			}

			[Register("setTimezoneOffsetSeconds", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetTimezoneOffsetSeconds_JHandler")]
			public abstract Builder SetTimezoneOffsetSeconds(long p0);
		}

		[Register("com/google/android/datatransport/cct/internal/LogEvent$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogEvent$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/LogEvent;", "GetBuildHandler")]
			public unsafe override LogEvent Build()
			{
				return Java.Lang.Object.GetObject<LogEvent>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/cct/internal/LogEvent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setEventCode", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventCode_Ljava_lang_Integer_Handler")]
			public unsafe override Builder SetEventCode(Integer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEventCode.(Ljava/lang/Integer;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setEventTimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventTimeMs_JHandler")]
			public unsafe override Builder SetEventTimeMs(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEventTimeMs.(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setEventUptimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetEventUptimeMs_JHandler")]
			public unsafe override Builder SetEventUptimeMs(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEventUptimeMs.(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setNetworkConnectionInfo", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetNetworkConnectionInfo_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_Handler")]
			public unsafe override Builder SetNetworkConnectionInfo(NetworkConnectionInfo p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNetworkConnectionInfo.(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setTimezoneOffsetSeconds", "(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "GetSetTimezoneOffsetSeconds_JHandler")]
			public unsafe override Builder SetTimezoneOffsetSeconds(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTimezoneOffsetSeconds.(J)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogEvent", typeof(LogEvent));

		private static Delegate cb_getEventCode;

		private static Delegate cb_getEventTimeMs;

		private static Delegate cb_getEventUptimeMs;

		private static Delegate cb_getNetworkConnectionInfo;

		private static Delegate cb_getSourceExtensionJsonProto3;

		private static Delegate cb_getTimezoneOffsetSeconds;

		private static Delegate cb_getSourceExtension;

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

		public abstract Integer EventCode
		{
			[Register("getEventCode", "()Ljava/lang/Integer;", "GetGetEventCodeHandler")]
			get;
		}

		public abstract long EventTimeMs
		{
			[Register("getEventTimeMs", "()J", "GetGetEventTimeMsHandler")]
			get;
		}

		public abstract long EventUptimeMs
		{
			[Register("getEventUptimeMs", "()J", "GetGetEventUptimeMsHandler")]
			get;
		}

		public abstract NetworkConnectionInfo NetworkConnectionInfo
		{
			[Register("getNetworkConnectionInfo", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", "GetGetNetworkConnectionInfoHandler")]
			get;
		}

		public abstract string SourceExtensionJsonProto3
		{
			[Register("getSourceExtensionJsonProto3", "()Ljava/lang/String;", "GetGetSourceExtensionJsonProto3Handler")]
			get;
		}

		public abstract long TimezoneOffsetSeconds
		{
			[Register("getTimezoneOffsetSeconds", "()J", "GetGetTimezoneOffsetSecondsHandler")]
			get;
		}

		protected LogEvent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LogEvent()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetEventCodeHandler()
		{
			if ((object)cb_getEventCode == null)
			{
				cb_getEventCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEventCode));
			}
			return cb_getEventCode;
		}

		private static IntPtr n_GetEventCode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EventCode);
		}

		private static Delegate GetGetEventTimeMsHandler()
		{
			if ((object)cb_getEventTimeMs == null)
			{
				cb_getEventTimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetEventTimeMs));
			}
			return cb_getEventTimeMs;
		}

		private static long n_GetEventTimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EventTimeMs;
		}

		private static Delegate GetGetEventUptimeMsHandler()
		{
			if ((object)cb_getEventUptimeMs == null)
			{
				cb_getEventUptimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetEventUptimeMs));
			}
			return cb_getEventUptimeMs;
		}

		private static long n_GetEventUptimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EventUptimeMs;
		}

		private static Delegate GetGetNetworkConnectionInfoHandler()
		{
			if ((object)cb_getNetworkConnectionInfo == null)
			{
				cb_getNetworkConnectionInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNetworkConnectionInfo));
			}
			return cb_getNetworkConnectionInfo;
		}

		private static IntPtr n_GetNetworkConnectionInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NetworkConnectionInfo);
		}

		private static Delegate GetGetSourceExtensionJsonProto3Handler()
		{
			if ((object)cb_getSourceExtensionJsonProto3 == null)
			{
				cb_getSourceExtensionJsonProto3 = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSourceExtensionJsonProto3));
			}
			return cb_getSourceExtensionJsonProto3;
		}

		private static IntPtr n_GetSourceExtensionJsonProto3(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SourceExtensionJsonProto3);
		}

		private static Delegate GetGetTimezoneOffsetSecondsHandler()
		{
			if ((object)cb_getTimezoneOffsetSeconds == null)
			{
				cb_getTimezoneOffsetSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTimezoneOffsetSeconds));
			}
			return cb_getTimezoneOffsetSeconds;
		}

		private static long n_GetTimezoneOffsetSeconds(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TimezoneOffsetSeconds;
		}

		private static Delegate GetGetSourceExtensionHandler()
		{
			if ((object)cb_getSourceExtension == null)
			{
				cb_getSourceExtension = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSourceExtension));
			}
			return cb_getSourceExtension;
		}

		private static IntPtr n_GetSourceExtension(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<LogEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSourceExtension());
		}

		[Register("getSourceExtension", "()[B", "GetGetSourceExtensionHandler")]
		public abstract byte[] GetSourceExtension();

		[Register("jsonBuilder", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "")]
		public unsafe static Builder JsonBuilder(string sourceJsonExtension)
		{
			IntPtr intPtr = JNIEnv.NewString(sourceJsonExtension);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("jsonBuilder.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("protoBuilder", "([B)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", "")]
		public unsafe static Builder ProtoBuilder(byte[] sourceExtension)
		{
			IntPtr intPtr = JNIEnv.NewArray(sourceExtension);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("protoBuilder.([B)Lcom/google/android/datatransport/cct/internal/LogEvent$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (sourceExtension != null)
				{
					JNIEnv.CopyArray(intPtr, sourceExtension);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(sourceExtension);
			}
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogEvent", DoNotGenerateAcw = true)]
	internal class LogEventInvoker : LogEvent
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogEvent", typeof(LogEventInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Integer EventCode
		{
			[Register("getEventCode", "()Ljava/lang/Integer;", "GetGetEventCodeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEventCode.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long EventTimeMs
		{
			[Register("getEventTimeMs", "()J", "GetGetEventTimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getEventTimeMs.()J", this, null);
			}
		}

		public unsafe override long EventUptimeMs
		{
			[Register("getEventUptimeMs", "()J", "GetGetEventUptimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getEventUptimeMs.()J", this, null);
			}
		}

		public unsafe override NetworkConnectionInfo NetworkConnectionInfo
		{
			[Register("getNetworkConnectionInfo", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", "GetGetNetworkConnectionInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<NetworkConnectionInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getNetworkConnectionInfo.()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string SourceExtensionJsonProto3
		{
			[Register("getSourceExtensionJsonProto3", "()Ljava/lang/String;", "GetGetSourceExtensionJsonProto3Handler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSourceExtensionJsonProto3.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long TimezoneOffsetSeconds
		{
			[Register("getTimezoneOffsetSeconds", "()J", "GetGetTimezoneOffsetSecondsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getTimezoneOffsetSeconds.()J", this, null);
			}
		}

		public LogEventInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getSourceExtension", "()[B", "GetGetSourceExtensionHandler")]
		public unsafe override byte[] GetSourceExtension()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getSourceExtension.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogRequest", DoNotGenerateAcw = true)]
	public abstract class LogRequest : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/cct/internal/LogRequest$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogRequest$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_;

			private static Delegate cb_setLogEvents_Ljava_util_List_;

			private static Delegate cb_setQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_;

			private static Delegate cb_setRequestTimeMs_J;

			private static Delegate cb_setRequestUptimeMs_J;

			private static Delegate cb_setSource_I;

			private static Delegate cb_setSource_Ljava_lang_String_;

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

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/LogRequest;", "GetBuildHandler")]
			public abstract LogRequest Build();

			private static Delegate GetSetClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_Handler()
			{
				if ((object)cb_setClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_ == null)
				{
					cb_setClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_));
				}
				return cb_setClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_;
			}

			private static IntPtr n_SetClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ClientInfo clientInfo = Java.Lang.Object.GetObject<ClientInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetClientInfo(clientInfo));
			}

			[Register("setClientInfo", "(Lcom/google/android/datatransport/cct/internal/ClientInfo;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_Handler")]
			public abstract Builder SetClientInfo(ClientInfo p0);

			private static Delegate GetSetLogEvents_Ljava_util_List_Handler()
			{
				if ((object)cb_setLogEvents_Ljava_util_List_ == null)
				{
					cb_setLogEvents_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetLogEvents_Ljava_util_List_));
				}
				return cb_setLogEvents_Ljava_util_List_;
			}

			private static IntPtr n_SetLogEvents_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<LogEvent> logEvents = JavaList<LogEvent>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetLogEvents(logEvents));
			}

			[Register("setLogEvents", "(Ljava/util/List;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetLogEvents_Ljava_util_List_Handler")]
			public abstract Builder SetLogEvents(IList<LogEvent> p0);

			private static Delegate GetSetQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_Handler()
			{
				if ((object)cb_setQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_ == null)
				{
					cb_setQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_));
				}
				return cb_setQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_;
			}

			private static IntPtr n_SetQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				QosTier qosTier = Java.Lang.Object.GetObject<QosTier>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetQosTier(qosTier));
			}

			[Register("setQosTier", "(Lcom/google/android/datatransport/cct/internal/QosTier;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_Handler")]
			public abstract Builder SetQosTier(QosTier p0);

			private static Delegate GetSetRequestTimeMs_JHandler()
			{
				if ((object)cb_setRequestTimeMs_J == null)
				{
					cb_setRequestTimeMs_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetRequestTimeMs_J));
				}
				return cb_setRequestTimeMs_J;
			}

			private static IntPtr n_SetRequestTimeMs_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRequestTimeMs(p0));
			}

			[Register("setRequestTimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetRequestTimeMs_JHandler")]
			public abstract Builder SetRequestTimeMs(long p0);

			private static Delegate GetSetRequestUptimeMs_JHandler()
			{
				if ((object)cb_setRequestUptimeMs_J == null)
				{
					cb_setRequestUptimeMs_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetRequestUptimeMs_J));
				}
				return cb_setRequestUptimeMs_J;
			}

			private static IntPtr n_SetRequestUptimeMs_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRequestUptimeMs(p0));
			}

			[Register("setRequestUptimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetRequestUptimeMs_JHandler")]
			public abstract Builder SetRequestUptimeMs(long p0);

			private static Delegate GetSetSource_IHandler()
			{
				if ((object)cb_setSource_I == null)
				{
					cb_setSource_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetSource_I));
				}
				return cb_setSource_I;
			}

			private static IntPtr n_SetSource_I(IntPtr jnienv, IntPtr native__this, int value)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSource(value));
			}

			[Register("setSource", "(I)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetSource_IHandler")]
			public unsafe virtual Builder SetSource(int value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSource.(I)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetSource_Ljava_lang_String_Handler()
			{
				if ((object)cb_setSource_Ljava_lang_String_ == null)
				{
					cb_setSource_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSource_Ljava_lang_String_));
				}
				return cb_setSource_Ljava_lang_String_;
			}

			private static IntPtr n_SetSource_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string source = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSource(source));
			}

			[Register("setSource", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetSource_Ljava_lang_String_Handler")]
			public unsafe virtual Builder SetSource(string value)
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSource.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("com/google/android/datatransport/cct/internal/LogRequest$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogRequest$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/LogRequest;", "GetBuildHandler")]
			public unsafe override LogRequest Build()
			{
				return Java.Lang.Object.GetObject<LogRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/cct/internal/LogRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setClientInfo", "(Lcom/google/android/datatransport/cct/internal/ClientInfo;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetClientInfo_Lcom_google_android_datatransport_cct_internal_ClientInfo_Handler")]
			public unsafe override Builder SetClientInfo(ClientInfo p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setClientInfo.(Lcom/google/android/datatransport/cct/internal/ClientInfo;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setLogEvents", "(Ljava/util/List;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetLogEvents_Ljava_util_List_Handler")]
			public unsafe override Builder SetLogEvents(IList<LogEvent> p0)
			{
				IntPtr intPtr = JavaList<LogEvent>.ToLocalJniHandle(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLogEvents.(Ljava/util/List;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
				}
			}

			[Register("setQosTier", "(Lcom/google/android/datatransport/cct/internal/QosTier;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetQosTier_Lcom_google_android_datatransport_cct_internal_QosTier_Handler")]
			public unsafe override Builder SetQosTier(QosTier p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setQosTier.(Lcom/google/android/datatransport/cct/internal/QosTier;)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setRequestTimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetRequestTimeMs_JHandler")]
			public unsafe override Builder SetRequestTimeMs(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRequestTimeMs.(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setRequestUptimeMs", "(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "GetSetRequestUptimeMs_JHandler")]
			public unsafe override Builder SetRequestUptimeMs(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRequestUptimeMs.(J)Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogRequest", typeof(LogRequest));

		private static Delegate cb_getClientInfo;

		private static Delegate cb_getLogEvents;

		private static Delegate cb_getLogSource;

		private static Delegate cb_getLogSourceName;

		private static Delegate cb_getQosTier;

		private static Delegate cb_getRequestTimeMs;

		private static Delegate cb_getRequestUptimeMs;

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

		public abstract ClientInfo ClientInfo
		{
			[Register("getClientInfo", "()Lcom/google/android/datatransport/cct/internal/ClientInfo;", "GetGetClientInfoHandler")]
			get;
		}

		public abstract IList<LogEvent> LogEvents
		{
			[Register("getLogEvents", "()Ljava/util/List;", "GetGetLogEventsHandler")]
			get;
		}

		public abstract Integer LogSource
		{
			[Register("getLogSource", "()Ljava/lang/Integer;", "GetGetLogSourceHandler")]
			get;
		}

		public abstract string LogSourceName
		{
			[Register("getLogSourceName", "()Ljava/lang/String;", "GetGetLogSourceNameHandler")]
			get;
		}

		public abstract QosTier QosTier
		{
			[Register("getQosTier", "()Lcom/google/android/datatransport/cct/internal/QosTier;", "GetGetQosTierHandler")]
			get;
		}

		public abstract long RequestTimeMs
		{
			[Register("getRequestTimeMs", "()J", "GetGetRequestTimeMsHandler")]
			get;
		}

		public abstract long RequestUptimeMs
		{
			[Register("getRequestUptimeMs", "()J", "GetGetRequestUptimeMsHandler")]
			get;
		}

		protected LogRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LogRequest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetClientInfoHandler()
		{
			if ((object)cb_getClientInfo == null)
			{
				cb_getClientInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetClientInfo));
			}
			return cb_getClientInfo;
		}

		private static IntPtr n_GetClientInfo(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClientInfo);
		}

		private static Delegate GetGetLogEventsHandler()
		{
			if ((object)cb_getLogEvents == null)
			{
				cb_getLogEvents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLogEvents));
			}
			return cb_getLogEvents;
		}

		private static IntPtr n_GetLogEvents(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<LogEvent>.ToLocalJniHandle(Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogEvents);
		}

		private static Delegate GetGetLogSourceHandler()
		{
			if ((object)cb_getLogSource == null)
			{
				cb_getLogSource = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLogSource));
			}
			return cb_getLogSource;
		}

		private static IntPtr n_GetLogSource(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogSource);
		}

		private static Delegate GetGetLogSourceNameHandler()
		{
			if ((object)cb_getLogSourceName == null)
			{
				cb_getLogSourceName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLogSourceName));
			}
			return cb_getLogSourceName;
		}

		private static IntPtr n_GetLogSourceName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogSourceName);
		}

		private static Delegate GetGetQosTierHandler()
		{
			if ((object)cb_getQosTier == null)
			{
				cb_getQosTier = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetQosTier));
			}
			return cb_getQosTier;
		}

		private static IntPtr n_GetQosTier(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QosTier);
		}

		private static Delegate GetGetRequestTimeMsHandler()
		{
			if ((object)cb_getRequestTimeMs == null)
			{
				cb_getRequestTimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetRequestTimeMs));
			}
			return cb_getRequestTimeMs;
		}

		private static long n_GetRequestTimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestTimeMs;
		}

		private static Delegate GetGetRequestUptimeMsHandler()
		{
			if ((object)cb_getRequestUptimeMs == null)
			{
				cb_getRequestUptimeMs = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetRequestUptimeMs));
			}
			return cb_getRequestUptimeMs;
		}

		private static long n_GetRequestUptimeMs(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestUptimeMs;
		}

		[Register("builder", "()Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/cct/internal/LogRequest$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogRequest", DoNotGenerateAcw = true)]
	internal class LogRequestInvoker : LogRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogRequest", typeof(LogRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ClientInfo ClientInfo
		{
			[Register("getClientInfo", "()Lcom/google/android/datatransport/cct/internal/ClientInfo;", "GetGetClientInfoHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ClientInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getClientInfo.()Lcom/google/android/datatransport/cct/internal/ClientInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IList<LogEvent> LogEvents
		{
			[Register("getLogEvents", "()Ljava/util/List;", "GetGetLogEventsHandler")]
			get
			{
				return JavaList<LogEvent>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getLogEvents.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Integer LogSource
		{
			[Register("getLogSource", "()Ljava/lang/Integer;", "GetGetLogSourceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLogSource.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string LogSourceName
		{
			[Register("getLogSourceName", "()Ljava/lang/String;", "GetGetLogSourceNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getLogSourceName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override QosTier QosTier
		{
			[Register("getQosTier", "()Lcom/google/android/datatransport/cct/internal/QosTier;", "GetGetQosTierHandler")]
			get
			{
				return Java.Lang.Object.GetObject<QosTier>(_members.InstanceMethods.InvokeAbstractObjectMethod("getQosTier.()Lcom/google/android/datatransport/cct/internal/QosTier;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long RequestTimeMs
		{
			[Register("getRequestTimeMs", "()J", "GetGetRequestTimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getRequestTimeMs.()J", this, null);
			}
		}

		public unsafe override long RequestUptimeMs
		{
			[Register("getRequestUptimeMs", "()J", "GetGetRequestUptimeMsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getRequestUptimeMs.()J", this, null);
			}
		}

		public LogRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogResponse", DoNotGenerateAcw = true)]
	public abstract class LogResponse : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogResponse", typeof(LogResponse));

		private static Delegate cb_getNextRequestWaitMillis;

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

		public abstract long NextRequestWaitMillis
		{
			[Register("getNextRequestWaitMillis", "()J", "GetGetNextRequestWaitMillisHandler")]
			get;
		}

		protected LogResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LogResponse()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetNextRequestWaitMillisHandler()
		{
			if ((object)cb_getNextRequestWaitMillis == null)
			{
				cb_getNextRequestWaitMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetNextRequestWaitMillis));
			}
			return cb_getNextRequestWaitMillis;
		}

		private static long n_GetNextRequestWaitMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LogResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextRequestWaitMillis;
		}

		[Register("fromJson", "(Ljava/io/Reader;)Lcom/google/android/datatransport/cct/internal/LogResponse;", "")]
		public unsafe static LogResponse FromJson(Reader reader)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reader?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LogResponse>(_members.StaticMethods.InvokeObjectMethod("fromJson.(Ljava/io/Reader;)Lcom/google/android/datatransport/cct/internal/LogResponse;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(reader);
			}
		}
	}
	[Register("com/google/android/datatransport/cct/internal/LogResponse", DoNotGenerateAcw = true)]
	internal class LogResponseInvoker : LogResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/LogResponse", typeof(LogResponseInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override long NextRequestWaitMillis
		{
			[Register("getNextRequestWaitMillis", "()J", "GetGetNextRequestWaitMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getNextRequestWaitMillis.()J", this, null);
			}
		}

		public LogResponseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo", DoNotGenerateAcw = true)]
	public abstract class NetworkConnectionInfo : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_;

			private static Delegate cb_setNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_;

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

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", "GetBuildHandler")]
			public abstract NetworkConnectionInfo Build();

			private static Delegate GetSetMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_Handler()
			{
				if ((object)cb_setMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_ == null)
				{
					cb_setMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_));
				}
				return cb_setMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_;
			}

			private static IntPtr n_SetMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MobileSubtype mobileSubtype = Java.Lang.Object.GetObject<MobileSubtype>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetMobileSubtype(mobileSubtype));
			}

			[Register("setMobileSubtype", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", "GetSetMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_Handler")]
			public abstract Builder SetMobileSubtype(MobileSubtype p0);

			private static Delegate GetSetNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_Handler()
			{
				if ((object)cb_setNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_ == null)
				{
					cb_setNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_));
				}
				return cb_setNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_;
			}

			private static IntPtr n_SetNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				NetworkType networkType = Java.Lang.Object.GetObject<NetworkType>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetNetworkType(networkType));
			}

			[Register("setNetworkType", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", "GetSetNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_Handler")]
			public abstract Builder SetNetworkType(NetworkType p0);
		}

		[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", "GetBuildHandler")]
			public unsafe override NetworkConnectionInfo Build()
			{
				return Java.Lang.Object.GetObject<NetworkConnectionInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setMobileSubtype", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", "GetSetMobileSubtype_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_MobileSubtype_Handler")]
			public unsafe override Builder SetMobileSubtype(MobileSubtype p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMobileSubtype.(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setNetworkType", "(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", "GetSetNetworkType_Lcom_google_android_datatransport_cct_internal_NetworkConnectionInfo_NetworkType_Handler")]
			public unsafe override Builder SetNetworkType(NetworkType p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNetworkType.(Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype", DoNotGenerateAcw = true)]
		public sealed class MobileSubtype : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype", typeof(MobileSubtype));

			[Register("CDMA")]
			public static MobileSubtype Cdma => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("CDMA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("COMBINED")]
			public static MobileSubtype Combined => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("COMBINED.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EDGE")]
			public static MobileSubtype Edge => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("EDGE.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EHRPD")]
			public static MobileSubtype Ehrpd => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("EHRPD.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EVDO_0")]
			public static MobileSubtype Evdo0 => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("EVDO_0.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EVDO_A")]
			public static MobileSubtype EvdoA => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("EVDO_A.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("EVDO_B")]
			public static MobileSubtype EvdoB => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("EVDO_B.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("GPRS")]
			public static MobileSubtype Gprs => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("GPRS.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("GSM")]
			public static MobileSubtype Gsm => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("GSM.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("HSDPA")]
			public static MobileSubtype Hsdpa => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("HSDPA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("HSPA")]
			public static MobileSubtype Hspa => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("HSPA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("HSPAP")]
			public static MobileSubtype Hspap => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("HSPAP.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("HSUPA")]
			public static MobileSubtype Hsupa => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("HSUPA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("IDEN")]
			public static MobileSubtype Iden => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("IDEN.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("IWLAN")]
			public static MobileSubtype Iwlan => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("IWLAN.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("LTE")]
			public static MobileSubtype Lte => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("LTE.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("LTE_CA")]
			public static MobileSubtype LteCa => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("LTE_CA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("RTT")]
			public static MobileSubtype Rtt => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("RTT.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("TD_SCDMA")]
			public static MobileSubtype TdScdma => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("TD_SCDMA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UMTS")]
			public static MobileSubtype Umts => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("UMTS.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNKNOWN_MOBILE_SUBTYPE")]
			public static MobileSubtype UnknownMobileSubtype => Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticFields.GetObjectValue("UNKNOWN_MOBILE_SUBTYPE.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal MobileSubtype(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("forNumber", "(I)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", "")]
			public unsafe static MobileSubtype ForNumber(int value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticMethods.InvokeObjectMethod("forNumber.(I)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", "")]
			public unsafe static MobileSubtype ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<MobileSubtype>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", "")]
			public unsafe static MobileSubtype[] Values()
			{
				return (MobileSubtype[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MobileSubtype));
			}
		}

		[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType", DoNotGenerateAcw = true)]
		public sealed class NetworkType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType", typeof(NetworkType));

			[Register("BLUETOOTH")]
			public static NetworkType Bluetooth => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("BLUETOOTH.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("DUMMY")]
			public static NetworkType Dummy => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("DUMMY.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("ETHERNET")]
			public static NetworkType Ethernet => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("ETHERNET.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE")]
			public static NetworkType Mobile => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_CBS")]
			public static NetworkType MobileCbs => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_CBS.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_DUN")]
			public static NetworkType MobileDun => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_DUN.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_EMERGENCY")]
			public static NetworkType MobileEmergency => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_EMERGENCY.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_FOTA")]
			public static NetworkType MobileFota => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_FOTA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_HIPRI")]
			public static NetworkType MobileHipri => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_HIPRI.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_IA")]
			public static NetworkType MobileIa => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_IA.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_IMS")]
			public static NetworkType MobileIms => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_IMS.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_MMS")]
			public static NetworkType MobileMms => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_MMS.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MOBILE_SUPL")]
			public static NetworkType MobileSupl => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("MOBILE_SUPL.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NONE")]
			public static NetworkType None => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("NONE.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("PROXY")]
			public static NetworkType Proxy => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("PROXY.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("VPN")]
			public static NetworkType Vpn => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("VPN.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WIFI")]
			public static NetworkType Wifi => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("WIFI.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WIFI_P2P")]
			public static NetworkType WifiP2p => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("WIFI_P2P.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WIMAX")]
			public static NetworkType Wimax => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("WIMAX.Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal NetworkType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("forNumber", "(I)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", "")]
			public unsafe static NetworkType ForNumber(int value)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<NetworkType>(_members.StaticMethods.InvokeObjectMethod("forNumber.(I)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", "")]
			public unsafe static NetworkType ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<NetworkType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", "")]
			public unsafe static NetworkType[] Values()
			{
				return (NetworkType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(NetworkType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo", typeof(NetworkConnectionInfo));

		private static Delegate cb_getMobileSubtype;

		private static Delegate cb_getNetworkType;

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

		protected NetworkConnectionInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe NetworkConnectionInfo()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("builder", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetMobileSubtypeHandler()
		{
			if ((object)cb_getMobileSubtype == null)
			{
				cb_getMobileSubtype = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMobileSubtype));
			}
			return cb_getMobileSubtype;
		}

		private static IntPtr n_GetMobileSubtype(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NetworkConnectionInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetMobileSubtype());
		}

		[Register("getMobileSubtype", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", "GetGetMobileSubtypeHandler")]
		public abstract MobileSubtype GetMobileSubtype();

		private static Delegate GetGetNetworkTypeHandler()
		{
			if ((object)cb_getNetworkType == null)
			{
				cb_getNetworkType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNetworkType));
			}
			return cb_getNetworkType;
		}

		private static IntPtr n_GetNetworkType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NetworkConnectionInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNetworkType());
		}

		[Register("getNetworkType", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", "GetGetNetworkTypeHandler")]
		public abstract NetworkType GetNetworkType();
	}
	[Register("com/google/android/datatransport/cct/internal/NetworkConnectionInfo", DoNotGenerateAcw = true)]
	internal class NetworkConnectionInfoInvoker : NetworkConnectionInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/NetworkConnectionInfo", typeof(NetworkConnectionInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public NetworkConnectionInfoInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getMobileSubtype", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", "GetGetMobileSubtypeHandler")]
		public unsafe override MobileSubtype GetMobileSubtype()
		{
			return Java.Lang.Object.GetObject<MobileSubtype>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMobileSubtype.()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getNetworkType", "()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", "GetGetNetworkTypeHandler")]
		public unsafe override NetworkType GetNetworkType()
		{
			return Java.Lang.Object.GetObject<NetworkType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getNetworkType.()Lcom/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/cct/internal/QosTier", DoNotGenerateAcw = true)]
	public sealed class QosTier : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/cct/internal/QosTier", typeof(QosTier));

		[Register("DEFAULT")]
		public static QosTier Default => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FAST_IF_RADIO_AWAKE")]
		public static QosTier FastIfRadioAwake => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("FAST_IF_RADIO_AWAKE.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NEVER")]
		public static QosTier Never => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("NEVER.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNMETERED_ONLY")]
		public static QosTier UnmeteredOnly => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("UNMETERED_ONLY.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNMETERED_OR_DAILY")]
		public static QosTier UnmeteredOrDaily => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("UNMETERED_OR_DAILY.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNRECOGNIZED")]
		public static QosTier Unrecognized => Java.Lang.Object.GetObject<QosTier>(_members.StaticFields.GetObjectValue("UNRECOGNIZED.Lcom/google/android/datatransport/cct/internal/QosTier;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe int Number
		{
			[Register("getNumber", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getNumber.()I", this, null);
			}
		}

		internal QosTier(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("forNumber", "(I)Lcom/google/android/datatransport/cct/internal/QosTier;", "")]
		public unsafe static QosTier ForNumber(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<QosTier>(_members.StaticMethods.InvokeObjectMethod("forNumber.(I)Lcom/google/android/datatransport/cct/internal/QosTier;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/QosTier;", "")]
		public unsafe static QosTier ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<QosTier>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/cct/internal/QosTier;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/android/datatransport/cct/internal/QosTier;", "")]
		public unsafe static QosTier[] Values()
		{
			return (QosTier[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/cct/internal/QosTier;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(QosTier));
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Backend.Cct
{
	[Register("com/google/android/datatransport/backend/cct/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "com.google.android.datatransport.backend.cct";

		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("FLAVOR")]
		public const string Flavor = "";

		[Register("VERSION_CODE")]
		public const int VersionCode = -1;

		[Register("VERSION_NAME")]
		public const string VersionName = "3.0.0";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/backend/cct/BuildConfig", typeof(BuildConfig));

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
		private static string[] package_com_google_android_datatransport_backend_cct_mappings;

		private static string[] package_com_google_android_datatransport_cct_internal_mappings;

		private static string[] package_com_google_android_datatransport_cct_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[3] { "com/google/android/datatransport/backend/cct", "com/google/android/datatransport/cct/internal", "com/google/android/datatransport/cct" }, new Converter<string, Type>[3] { lookup_com_google_android_datatransport_backend_cct_package, lookup_com_google_android_datatransport_cct_internal_package, lookup_com_google_android_datatransport_cct_package });
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

		private static Type lookup_com_google_android_datatransport_backend_cct_package(string klass)
		{
			if (package_com_google_android_datatransport_backend_cct_mappings == null)
			{
				package_com_google_android_datatransport_backend_cct_mappings = new string[1] { "com/google/android/datatransport/backend/cct/BuildConfig:Xamarin.Google.Android.DataTransport.Backend.Cct.BuildConfig" };
			}
			return Lookup(package_com_google_android_datatransport_backend_cct_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_cct_internal_package(string klass)
		{
			if (package_com_google_android_datatransport_cct_internal_mappings == null)
			{
				package_com_google_android_datatransport_cct_internal_mappings = new string[16]
				{
					"com/google/android/datatransport/cct/internal/AndroidClientInfo:Xamarin.Google.Android.DataTransport.Cct.Internal.AndroidClientInfo", "com/google/android/datatransport/cct/internal/AndroidClientInfo$Builder:Xamarin.Google.Android.DataTransport.Cct.Internal.AndroidClientInfo/Builder", "com/google/android/datatransport/cct/internal/BatchedLogRequest:Xamarin.Google.Android.DataTransport.Cct.Internal.BatchedLogRequest", "com/google/android/datatransport/cct/internal/ClientInfo:Xamarin.Google.Android.DataTransport.Cct.Internal.ClientInfo", "com/google/android/datatransport/cct/internal/ClientInfo$Builder:Xamarin.Google.Android.DataTransport.Cct.Internal.ClientInfo/Builder", "com/google/android/datatransport/cct/internal/ClientInfo$ClientType:Xamarin.Google.Android.DataTransport.Cct.Internal.ClientInfo/ClientType", "com/google/android/datatransport/cct/internal/LogEvent:Xamarin.Google.Android.DataTransport.Cct.Internal.LogEvent", "com/google/android/datatransport/cct/internal/LogEvent$Builder:Xamarin.Google.Android.DataTransport.Cct.Internal.LogEvent/Builder", "com/google/android/datatransport/cct/internal/LogRequest:Xamarin.Google.Android.DataTransport.Cct.Internal.LogRequest", "com/google/android/datatransport/cct/internal/LogRequest$Builder:Xamarin.Google.Android.DataTransport.Cct.Internal.LogRequest/Builder",
					"com/google/android/datatransport/cct/internal/LogResponse:Xamarin.Google.Android.DataTransport.Cct.Internal.LogResponse", "com/google/android/datatransport/cct/internal/NetworkConnectionInfo:Xamarin.Google.Android.DataTransport.Cct.Internal.NetworkConnectionInfo", "com/google/android/datatransport/cct/internal/NetworkConnectionInfo$Builder:Xamarin.Google.Android.DataTransport.Cct.Internal.NetworkConnectionInfo/Builder", "com/google/android/datatransport/cct/internal/NetworkConnectionInfo$MobileSubtype:Xamarin.Google.Android.DataTransport.Cct.Internal.NetworkConnectionInfo/MobileSubtype", "com/google/android/datatransport/cct/internal/NetworkConnectionInfo$NetworkType:Xamarin.Google.Android.DataTransport.Cct.Internal.NetworkConnectionInfo/NetworkType", "com/google/android/datatransport/cct/internal/QosTier:Xamarin.Google.Android.DataTransport.Cct.Internal.QosTier"
				};
			}
			return Lookup(package_com_google_android_datatransport_cct_internal_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_cct_package(string klass)
		{
			if (package_com_google_android_datatransport_cct_mappings == null)
			{
				package_com_google_android_datatransport_cct_mappings = new string[1] { "com/google/android/datatransport/cct/StringMerger:Xamarin.Google.Android.DataTransport.Cct.StringMerger" };
			}
			return Lookup(package_com_google_android_datatransport_cct_mappings, klass);
		}
	}
}
