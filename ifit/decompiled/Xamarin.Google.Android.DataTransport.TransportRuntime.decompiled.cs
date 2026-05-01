using System;
using System.Collections;
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
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Java.Util;
using Java.Util.Concurrent;
using Xamarin.Google.Android.DataTransport.Runtime.Backends;
using Xamarin.Google.Android.DataTransport.Runtime.Persistence;
using Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling;
using Xamarin.Google.Android.DataTransport.Runtime.Synchronization;
using Xamarin.Google.Android.DataTransport.Runtime.Time;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime", Managed = "Xamarin.Google.Android.DataTransport.Runtime")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.backends", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Backends")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.dagger", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Dagger")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.dagger.internal", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.dagger.multibindings", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.logging", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Logging")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.retries", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Retries")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.scheduling", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Scheduling")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.scheduling.jobscheduling", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.scheduling.persistence", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Persistence")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.synchronization", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Synchronization")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.time", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Time")]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport.runtime.util", Managed = "Xamarin.Google.Android.DataTransport.Runtime.Util")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Android.DataTransport.TransportRuntime")]
[assembly: AssemblyTitle("Xamarin.Google.Android.DataTransport.TransportRuntime")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate long _JniMarshal_PPL_J(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLIZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, bool p2);
internal delegate void _JniMarshal_PPLJ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate long _JniMarshal_PPLJI_J(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1, int p2);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLJI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, long p2, int p3);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
namespace Xamarin.Google.Android.DataTransport.Runtime
{
	[Register("com/google/android/datatransport/runtime/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "com.google.android.datatransport.runtime";

		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("FLAVOR")]
		public const string Flavor = "";

		[Register("VERSION_CODE")]
		public const int VersionCode = -1;

		[Register("VERSION_NAME")]
		public const string VersionName = "";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/BuildConfig", typeof(BuildConfig));

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
	[Register("com/google/android/datatransport/runtime/EncodedPayload", DoNotGenerateAcw = true)]
	public sealed class EncodedPayload : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EncodedPayload", typeof(EncodedPayload));

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

		public unsafe Encoding Encoding
		{
			[Register("getEncoding", "()Lcom/google/android/datatransport/Encoding;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Encoding>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEncoding.()Lcom/google/android/datatransport/Encoding;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal EncodedPayload(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/datatransport/Encoding;[B)V", "")]
		public unsafe EncodedPayload(Encoding encoding, byte[] bytes)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(bytes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(encoding?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/datatransport/Encoding;[B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/datatransport/Encoding;[B)V", this, ptr);
			}
			finally
			{
				if (bytes != null)
				{
					JNIEnv.CopyArray(intPtr, bytes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(encoding);
				GC.KeepAlive(bytes);
			}
		}

		[Register("getBytes", "()[B", "")]
		public unsafe byte[] GetBytes()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/runtime/EventInternal", DoNotGenerateAcw = true)]
	public abstract class EventInternal : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/runtime/EventInternal$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EventInternal$Builder", typeof(Builder));

			private static Delegate cb_getAutoMetadata;

			private static Delegate cb_build;

			private static Delegate cb_setAutoMetadata_Ljava_util_Map_;

			private static Delegate cb_setCode_Ljava_lang_Integer_;

			private static Delegate cb_setEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_;

			private static Delegate cb_setEventMillis_J;

			private static Delegate cb_setTransportName_Ljava_lang_String_;

			private static Delegate cb_setUptimeMillis_J;

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

			protected abstract IDictionary<string, string> AutoMetadata
			{
				[Register("getAutoMetadata", "()Ljava/util/Map;", "GetGetAutoMetadataHandler")]
				get;
			}

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

			private static Delegate GetGetAutoMetadataHandler()
			{
				if ((object)cb_getAutoMetadata == null)
				{
					cb_getAutoMetadata = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAutoMetadata));
				}
				return cb_getAutoMetadata;
			}

			private static IntPtr n_GetAutoMetadata(IntPtr jnienv, IntPtr native__this)
			{
				return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoMetadata);
			}

			[Register("addMetadata", "(Ljava/lang/String;I)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "")]
			public unsafe Builder AddMetadata(string key, int value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMetadata.(Ljava/lang/String;I)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("addMetadata", "(Ljava/lang/String;Ljava/lang/String;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "")]
			public unsafe Builder AddMetadata(string key, string value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				IntPtr intPtr2 = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMetadata.(Ljava/lang/String;Ljava/lang/String;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
			}

			[Register("addMetadata", "(Ljava/lang/String;J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "")]
			public unsafe Builder AddMetadata(string key, long value)
			{
				IntPtr intPtr = JNIEnv.NewString(key);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(value);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMetadata.(Ljava/lang/String;J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
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

			[Register("build", "()Lcom/google/android/datatransport/runtime/EventInternal;", "GetBuildHandler")]
			public abstract EventInternal Build();

			private static Delegate GetSetAutoMetadata_Ljava_util_Map_Handler()
			{
				if ((object)cb_setAutoMetadata_Ljava_util_Map_ == null)
				{
					cb_setAutoMetadata_Ljava_util_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetAutoMetadata_Ljava_util_Map_));
				}
				return cb_setAutoMetadata_Ljava_util_Map_;
			}

			private static IntPtr n_SetAutoMetadata_Ljava_util_Map_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IDictionary<string, string> autoMetadata = JavaDictionary<string, string>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetAutoMetadata(autoMetadata));
			}

			[Register("setAutoMetadata", "(Ljava/util/Map;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetAutoMetadata_Ljava_util_Map_Handler")]
			protected abstract Builder SetAutoMetadata(IDictionary<string, string> p0);

			private static Delegate GetSetCode_Ljava_lang_Integer_Handler()
			{
				if ((object)cb_setCode_Ljava_lang_Integer_ == null)
				{
					cb_setCode_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetCode_Ljava_lang_Integer_));
				}
				return cb_setCode_Ljava_lang_Integer_;
			}

			private static IntPtr n_SetCode_Ljava_lang_Integer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Integer code = Java.Lang.Object.GetObject<Integer>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetCode(code));
			}

			[Register("setCode", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetCode_Ljava_lang_Integer_Handler")]
			public abstract Builder SetCode(Integer p0);

			private static Delegate GetSetEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_Handler()
			{
				if ((object)cb_setEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_ == null)
				{
					cb_setEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_));
				}
				return cb_setEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_;
			}

			private static IntPtr n_SetEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				EncodedPayload encodedPayload = Java.Lang.Object.GetObject<EncodedPayload>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetEncodedPayload(encodedPayload));
			}

			[Register("setEncodedPayload", "(Lcom/google/android/datatransport/runtime/EncodedPayload;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_Handler")]
			public abstract Builder SetEncodedPayload(EncodedPayload p0);

			private static Delegate GetSetEventMillis_JHandler()
			{
				if ((object)cb_setEventMillis_J == null)
				{
					cb_setEventMillis_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetEventMillis_J));
				}
				return cb_setEventMillis_J;
			}

			private static IntPtr n_SetEventMillis_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEventMillis(p0));
			}

			[Register("setEventMillis", "(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetEventMillis_JHandler")]
			public abstract Builder SetEventMillis(long p0);

			private static Delegate GetSetTransportName_Ljava_lang_String_Handler()
			{
				if ((object)cb_setTransportName_Ljava_lang_String_ == null)
				{
					cb_setTransportName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetTransportName_Ljava_lang_String_));
				}
				return cb_setTransportName_Ljava_lang_String_;
			}

			private static IntPtr n_SetTransportName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string transportName = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetTransportName(transportName));
			}

			[Register("setTransportName", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetTransportName_Ljava_lang_String_Handler")]
			public abstract Builder SetTransportName(string p0);

			private static Delegate GetSetUptimeMillis_JHandler()
			{
				if ((object)cb_setUptimeMillis_J == null)
				{
					cb_setUptimeMillis_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetUptimeMillis_J));
				}
				return cb_setUptimeMillis_J;
			}

			private static IntPtr n_SetUptimeMillis_J(IntPtr jnienv, IntPtr native__this, long p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetUptimeMillis(p0));
			}

			[Register("setUptimeMillis", "(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetUptimeMillis_JHandler")]
			public abstract Builder SetUptimeMillis(long p0);
		}

		[Register("com/google/android/datatransport/runtime/EventInternal$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EventInternal$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected unsafe override IDictionary<string, string> AutoMetadata
			{
				[Register("getAutoMetadata", "()Ljava/util/Map;", "GetGetAutoMetadataHandler")]
				get
				{
					return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAutoMetadata.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public BuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Lcom/google/android/datatransport/runtime/EventInternal;", "GetBuildHandler")]
			public unsafe override EventInternal Build()
			{
				return Java.Lang.Object.GetObject<EventInternal>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/runtime/EventInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setAutoMetadata", "(Ljava/util/Map;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetAutoMetadata_Ljava_util_Map_Handler")]
			protected unsafe override Builder SetAutoMetadata(IDictionary<string, string> p0)
			{
				IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAutoMetadata.(Ljava/util/Map;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
				}
			}

			[Register("setCode", "(Ljava/lang/Integer;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetCode_Ljava_lang_Integer_Handler")]
			public unsafe override Builder SetCode(Integer p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCode.(Ljava/lang/Integer;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setEncodedPayload", "(Lcom/google/android/datatransport/runtime/EncodedPayload;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetEncodedPayload_Lcom_google_android_datatransport_runtime_EncodedPayload_Handler")]
			public unsafe override Builder SetEncodedPayload(EncodedPayload p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEncodedPayload.(Lcom/google/android/datatransport/runtime/EncodedPayload;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setEventMillis", "(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetEventMillis_JHandler")]
			public unsafe override Builder SetEventMillis(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEventMillis.(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setTransportName", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetTransportName_Ljava_lang_String_Handler")]
			public unsafe override Builder SetTransportName(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTransportName.(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setUptimeMillis", "(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetSetUptimeMillis_JHandler")]
			public unsafe override Builder SetUptimeMillis(long p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setUptimeMillis.(J)Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EventInternal", typeof(EventInternal));

		private static Delegate cb_getAutoMetadata;

		private static Delegate cb_getCode;

		private static Delegate cb_getEncodedPayload;

		private static Delegate cb_getEventMillis;

		private static Delegate cb_getTransportName;

		private static Delegate cb_getUptimeMillis;

		private static Delegate cb_getPayload;

		private static Delegate cb_toBuilder;

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

		protected abstract IDictionary<string, string> AutoMetadata
		{
			[Register("getAutoMetadata", "()Ljava/util/Map;", "GetGetAutoMetadataHandler")]
			get;
		}

		public abstract Integer Code
		{
			[Register("getCode", "()Ljava/lang/Integer;", "GetGetCodeHandler")]
			get;
		}

		public abstract EncodedPayload EncodedPayload
		{
			[Register("getEncodedPayload", "()Lcom/google/android/datatransport/runtime/EncodedPayload;", "GetGetEncodedPayloadHandler")]
			get;
		}

		public abstract long EventMillis
		{
			[Register("getEventMillis", "()J", "GetGetEventMillisHandler")]
			get;
		}

		public unsafe IDictionary<string, string> Metadata
		{
			[Register("getMetadata", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMetadata.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public abstract string TransportName
		{
			[Register("getTransportName", "()Ljava/lang/String;", "GetGetTransportNameHandler")]
			get;
		}

		public abstract long UptimeMillis
		{
			[Register("getUptimeMillis", "()J", "GetGetUptimeMillisHandler")]
			get;
		}

		protected EventInternal(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EventInternal()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAutoMetadataHandler()
		{
			if ((object)cb_getAutoMetadata == null)
			{
				cb_getAutoMetadata = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAutoMetadata));
			}
			return cb_getAutoMetadata;
		}

		private static IntPtr n_GetAutoMetadata(IntPtr jnienv, IntPtr native__this)
		{
			return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoMetadata);
		}

		private static Delegate GetGetCodeHandler()
		{
			if ((object)cb_getCode == null)
			{
				cb_getCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCode));
			}
			return cb_getCode;
		}

		private static IntPtr n_GetCode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Code);
		}

		private static Delegate GetGetEncodedPayloadHandler()
		{
			if ((object)cb_getEncodedPayload == null)
			{
				cb_getEncodedPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEncodedPayload));
			}
			return cb_getEncodedPayload;
		}

		private static IntPtr n_GetEncodedPayload(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EncodedPayload);
		}

		private static Delegate GetGetEventMillisHandler()
		{
			if ((object)cb_getEventMillis == null)
			{
				cb_getEventMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetEventMillis));
			}
			return cb_getEventMillis;
		}

		private static long n_GetEventMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EventMillis;
		}

		private static Delegate GetGetTransportNameHandler()
		{
			if ((object)cb_getTransportName == null)
			{
				cb_getTransportName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTransportName));
			}
			return cb_getTransportName;
		}

		private static IntPtr n_GetTransportName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransportName);
		}

		private static Delegate GetGetUptimeMillisHandler()
		{
			if ((object)cb_getUptimeMillis == null)
			{
				cb_getUptimeMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetUptimeMillis));
			}
			return cb_getUptimeMillis;
		}

		private static long n_GetUptimeMillis(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UptimeMillis;
		}

		[Register("builder", "()Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/runtime/EventInternal$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("get", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string Get(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("get.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getInteger", "(Ljava/lang/String;)I", "")]
		public unsafe int GetInteger(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getInteger.(Ljava/lang/String;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getLong", "(Ljava/lang/String;)J", "")]
		public unsafe long GetLong(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("getLong.(Ljava/lang/String;)J", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getOrDefault", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string GetOrDefault(string key, string defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			IntPtr intPtr2 = JNIEnv.NewString(defaultValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOrDefault.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Obsolete]
		private static Delegate GetGetPayloadHandler()
		{
			if ((object)cb_getPayload == null)
			{
				cb_getPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPayload));
			}
			return cb_getPayload;
		}

		[Obsolete]
		private static IntPtr n_GetPayload(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPayload());
		}

		[Obsolete("deprecated")]
		[Register("getPayload", "()[B", "GetGetPayloadHandler")]
		public unsafe virtual byte[] GetPayload()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getPayload.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetToBuilderHandler()
		{
			if ((object)cb_toBuilder == null)
			{
				cb_toBuilder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToBuilder));
			}
			return cb_toBuilder;
		}

		private static IntPtr n_ToBuilder(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<EventInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBuilder());
		}

		[Register("toBuilder", "()Lcom/google/android/datatransport/runtime/EventInternal$Builder;", "GetToBuilderHandler")]
		public unsafe virtual Builder ToBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBuilder.()Lcom/google/android/datatransport/runtime/EventInternal$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/EventInternal", DoNotGenerateAcw = true)]
	internal class EventInternalInvoker : EventInternal
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EventInternal", typeof(EventInternalInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe override IDictionary<string, string> AutoMetadata
		{
			[Register("getAutoMetadata", "()Ljava/util/Map;", "GetGetAutoMetadataHandler")]
			get
			{
				return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getAutoMetadata.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Integer Code
		{
			[Register("getCode", "()Ljava/lang/Integer;", "GetGetCodeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCode.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override EncodedPayload EncodedPayload
		{
			[Register("getEncodedPayload", "()Lcom/google/android/datatransport/runtime/EncodedPayload;", "GetGetEncodedPayloadHandler")]
			get
			{
				return Java.Lang.Object.GetObject<EncodedPayload>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEncodedPayload.()Lcom/google/android/datatransport/runtime/EncodedPayload;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long EventMillis
		{
			[Register("getEventMillis", "()J", "GetGetEventMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getEventMillis.()J", this, null);
			}
		}

		public unsafe override string TransportName
		{
			[Register("getTransportName", "()Ljava/lang/String;", "GetGetTransportNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTransportName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long UptimeMillis
		{
			[Register("getUptimeMillis", "()J", "GetGetUptimeMillisHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getUptimeMillis.()J", this, null);
			}
		}

		public EventInternalInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/Destination", "", "Xamarin.Google.Android.DataTransport.Runtime.IDestinationInvoker")]
	public interface IDestination : IJavaObject, IDisposable, IJavaPeerable
	{
		string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Xamarin.Google.Android.DataTransport.Runtime.IDestinationInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
			get;
		}

		[Register("getExtras", "()[B", "GetGetExtrasHandler:Xamarin.Google.Android.DataTransport.Runtime.IDestinationInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		byte[] GetExtras();
	}
	[Register("com/google/android/datatransport/runtime/Destination", DoNotGenerateAcw = true)]
	internal class IDestinationInvoker : Java.Lang.Object, IDestination, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/Destination", typeof(IDestinationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getName;

		private IntPtr id_getName;

		private static Delegate cb_getExtras;

		private IntPtr id_getExtras;

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

		public string Name
		{
			get
			{
				if (id_getName == IntPtr.Zero)
				{
					id_getName = JNIEnv.GetMethodID(class_ref, "getName", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getName), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IDestination GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDestination>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.Destination'.");
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

		public IDestinationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDestination>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetGetExtrasHandler()
		{
			if ((object)cb_getExtras == null)
			{
				cb_getExtras = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtras));
			}
			return cb_getExtras;
		}

		private static IntPtr n_GetExtras(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IDestination>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetExtras());
		}

		public byte[] GetExtras()
		{
			if (id_getExtras == IntPtr.Zero)
			{
				id_getExtras = JNIEnv.GetMethodID(class_ref, "getExtras", "()[B");
			}
			return (byte[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_getExtras), JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/runtime/EncodedDestination", "", "Xamarin.Google.Android.DataTransport.Runtime.IEncodedDestinationInvoker")]
	public interface IEncodedDestination : IDestination, IJavaObject, IDisposable, IJavaPeerable
	{
		ICollection<Encoding> SupportedEncodings
		{
			[Register("getSupportedEncodings", "()Ljava/util/Set;", "GetGetSupportedEncodingsHandler:Xamarin.Google.Android.DataTransport.Runtime.IEncodedDestinationInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
			get;
		}
	}
	[Register("com/google/android/datatransport/runtime/EncodedDestination", DoNotGenerateAcw = true)]
	internal class IEncodedDestinationInvoker : Java.Lang.Object, IEncodedDestination, IDestination, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/EncodedDestination", typeof(IEncodedDestinationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getSupportedEncodings;

		private IntPtr id_getSupportedEncodings;

		private static Delegate cb_getName;

		private IntPtr id_getName;

		private static Delegate cb_getExtras;

		private IntPtr id_getExtras;

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

		public ICollection<Encoding> SupportedEncodings
		{
			get
			{
				if (id_getSupportedEncodings == IntPtr.Zero)
				{
					id_getSupportedEncodings = JNIEnv.GetMethodID(class_ref, "getSupportedEncodings", "()Ljava/util/Set;");
				}
				return JavaSet<Encoding>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedEncodings), JniHandleOwnership.TransferLocalRef);
			}
		}

		public string Name
		{
			get
			{
				if (id_getName == IntPtr.Zero)
				{
					id_getName = JNIEnv.GetMethodID(class_ref, "getName", "()Ljava/lang/String;");
				}
				return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getName), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IEncodedDestination GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEncodedDestination>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.EncodedDestination'.");
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

		public IEncodedDestinationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetSupportedEncodingsHandler()
		{
			if ((object)cb_getSupportedEncodings == null)
			{
				cb_getSupportedEncodings = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedEncodings));
			}
			return cb_getSupportedEncodings;
		}

		private static IntPtr n_GetSupportedEncodings(IntPtr jnienv, IntPtr native__this)
		{
			return JavaSet<Encoding>.ToLocalJniHandle(Java.Lang.Object.GetObject<IEncodedDestination>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedEncodings);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IEncodedDestination>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetGetExtrasHandler()
		{
			if ((object)cb_getExtras == null)
			{
				cb_getExtras = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtras));
			}
			return cb_getExtras;
		}

		private static IntPtr n_GetExtras(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IEncodedDestination>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetExtras());
		}

		public byte[] GetExtras()
		{
			if (id_getExtras == IntPtr.Zero)
			{
				id_getExtras = JNIEnv.GetMethodID(class_ref, "getExtras", "()[B");
			}
			return (byte[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_getExtras), JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/runtime/TransportContext", DoNotGenerateAcw = true)]
	public abstract class TransportContext : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/runtime/TransportContext$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportContext$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setBackendName_Ljava_lang_String_;

			private static Delegate cb_setExtras_arrayB;

			private static Delegate cb_setPriority_Lcom_google_android_datatransport_Priority_;

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

			[Register("build", "()Lcom/google/android/datatransport/runtime/TransportContext;", "GetBuildHandler")]
			public abstract TransportContext Build();

			private static Delegate GetSetBackendName_Ljava_lang_String_Handler()
			{
				if ((object)cb_setBackendName_Ljava_lang_String_ == null)
				{
					cb_setBackendName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetBackendName_Ljava_lang_String_));
				}
				return cb_setBackendName_Ljava_lang_String_;
			}

			private static IntPtr n_SetBackendName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string backendName = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetBackendName(backendName));
			}

			[Register("setBackendName", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetBackendName_Ljava_lang_String_Handler")]
			public abstract Builder SetBackendName(string p0);

			private static Delegate GetSetExtras_arrayBHandler()
			{
				if ((object)cb_setExtras_arrayB == null)
				{
					cb_setExtras_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExtras_arrayB));
				}
				return cb_setExtras_arrayB;
			}

			private static IntPtr n_SetExtras_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.SetExtras(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p0);
				}
				return result;
			}

			[Register("setExtras", "([B)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetExtras_arrayBHandler")]
			public abstract Builder SetExtras(byte[] p0);

			private static Delegate GetSetPriority_Lcom_google_android_datatransport_Priority_Handler()
			{
				if ((object)cb_setPriority_Lcom_google_android_datatransport_Priority_ == null)
				{
					cb_setPriority_Lcom_google_android_datatransport_Priority_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPriority_Lcom_google_android_datatransport_Priority_));
				}
				return cb_setPriority_Lcom_google_android_datatransport_Priority_;
			}

			private static IntPtr n_SetPriority_Lcom_google_android_datatransport_Priority_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Priority priority = Java.Lang.Object.GetObject<Priority>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetPriority(priority));
			}

			[Register("setPriority", "(Lcom/google/android/datatransport/Priority;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetPriority_Lcom_google_android_datatransport_Priority_Handler")]
			public abstract Builder SetPriority(Priority p0);
		}

		[Register("com/google/android/datatransport/runtime/TransportContext$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportContext$Builder", typeof(BuilderInvoker));

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

			[Register("build", "()Lcom/google/android/datatransport/runtime/TransportContext;", "GetBuildHandler")]
			public unsafe override TransportContext Build()
			{
				return Java.Lang.Object.GetObject<TransportContext>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/runtime/TransportContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setBackendName", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetBackendName_Ljava_lang_String_Handler")]
			public unsafe override Builder SetBackendName(string p0)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBackendName.(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setExtras", "([B)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetExtras_arrayBHandler")]
			public unsafe override Builder SetExtras(byte[] p0)
			{
				IntPtr intPtr = JNIEnv.NewArray(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExtras.([B)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

			[Register("setPriority", "(Lcom/google/android/datatransport/Priority;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "GetSetPriority_Lcom_google_android_datatransport_Priority_Handler")]
			public unsafe override Builder SetPriority(Priority p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(Lcom/google/android/datatransport/Priority;)Lcom/google/android/datatransport/runtime/TransportContext$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportContext", typeof(TransportContext));

		private static Delegate cb_getBackendName;

		private static Delegate cb_getPriority;

		private static Delegate cb_getExtras;

		private static Delegate cb_withPriority_Lcom_google_android_datatransport_Priority_;

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

		public abstract string BackendName
		{
			[Register("getBackendName", "()Ljava/lang/String;", "GetGetBackendNameHandler")]
			get;
		}

		public abstract Priority Priority
		{
			[Register("getPriority", "()Lcom/google/android/datatransport/Priority;", "GetGetPriorityHandler")]
			get;
		}

		protected TransportContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransportContext()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetBackendNameHandler()
		{
			if ((object)cb_getBackendName == null)
			{
				cb_getBackendName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBackendName));
			}
			return cb_getBackendName;
		}

		private static IntPtr n_GetBackendName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<TransportContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackendName);
		}

		private static Delegate GetGetPriorityHandler()
		{
			if ((object)cb_getPriority == null)
			{
				cb_getPriority = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPriority));
			}
			return cb_getPriority;
		}

		private static IntPtr n_GetPriority(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransportContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Priority);
		}

		[Register("builder", "()Lcom/google/android/datatransport/runtime/TransportContext$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/runtime/TransportContext$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetExtrasHandler()
		{
			if ((object)cb_getExtras == null)
			{
				cb_getExtras = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtras));
			}
			return cb_getExtras;
		}

		private static IntPtr n_GetExtras(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<TransportContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetExtras());
		}

		[Register("getExtras", "()[B", "GetGetExtrasHandler")]
		public abstract byte[] GetExtras();

		[Register("toString", "()Ljava/lang/String;", "")]
		public unsafe sealed override string ToString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWithPriority_Lcom_google_android_datatransport_Priority_Handler()
		{
			if ((object)cb_withPriority_Lcom_google_android_datatransport_Priority_ == null)
			{
				cb_withPriority_Lcom_google_android_datatransport_Priority_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithPriority_Lcom_google_android_datatransport_Priority_));
			}
			return cb_withPriority_Lcom_google_android_datatransport_Priority_;
		}

		private static IntPtr n_WithPriority_Lcom_google_android_datatransport_Priority_(IntPtr jnienv, IntPtr native__this, IntPtr native_priority)
		{
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportContext.WithPriority(priority));
		}

		[Register("withPriority", "(Lcom/google/android/datatransport/Priority;)Lcom/google/android/datatransport/runtime/TransportContext;", "GetWithPriority_Lcom_google_android_datatransport_Priority_Handler")]
		public unsafe virtual TransportContext WithPriority(Priority priority)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TransportContext>(_members.InstanceMethods.InvokeVirtualObjectMethod("withPriority.(Lcom/google/android/datatransport/Priority;)Lcom/google/android/datatransport/runtime/TransportContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(priority);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/TransportContext", DoNotGenerateAcw = true)]
	internal class TransportContextInvoker : TransportContext
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportContext", typeof(TransportContextInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override string BackendName
		{
			[Register("getBackendName", "()Ljava/lang/String;", "GetGetBackendNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBackendName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override Priority Priority
		{
			[Register("getPriority", "()Lcom/google/android/datatransport/Priority;", "GetGetPriorityHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Priority>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPriority.()Lcom/google/android/datatransport/Priority;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public TransportContextInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getExtras", "()[B", "GetGetExtrasHandler")]
		public unsafe override byte[] GetExtras()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getExtras.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/runtime/TransportRuntime", DoNotGenerateAcw = true)]
	public class TransportRuntime : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportRuntime", typeof(TransportRuntime));

		private static Delegate cb_getUploader;

		private static Delegate cb_newFactory_Lcom_google_android_datatransport_runtime_Destination_;

		private static Delegate cb_newFactory_Ljava_lang_String_;

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

		public unsafe static TransportRuntime Instance
		{
			[Register("getInstance", "()Lcom/google/android/datatransport/runtime/TransportRuntime;", "")]
			get
			{
				return Java.Lang.Object.GetObject<TransportRuntime>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/android/datatransport/runtime/TransportRuntime;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Uploader Uploader
		{
			[Register("getUploader", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;", "GetGetUploaderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Uploader>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUploader.()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected TransportRuntime(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetUploaderHandler()
		{
			if ((object)cb_getUploader == null)
			{
				cb_getUploader = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUploader));
			}
			return cb_getUploader;
		}

		private static IntPtr n_GetUploader(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransportRuntime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Uploader);
		}

		[Register("initialize", "(Landroid/content/Context;)V", "")]
		public unsafe static void Initialize(Context applicationContext)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("initialize.(Landroid/content/Context;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(applicationContext);
			}
		}

		private static Delegate GetNewFactory_Lcom_google_android_datatransport_runtime_Destination_Handler()
		{
			if ((object)cb_newFactory_Lcom_google_android_datatransport_runtime_Destination_ == null)
			{
				cb_newFactory_Lcom_google_android_datatransport_runtime_Destination_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewFactory_Lcom_google_android_datatransport_runtime_Destination_));
			}
			return cb_newFactory_Lcom_google_android_datatransport_runtime_Destination_;
		}

		private static IntPtr n_NewFactory_Lcom_google_android_datatransport_runtime_Destination_(IntPtr jnienv, IntPtr native__this, IntPtr native_destination)
		{
			TransportRuntime transportRuntime = Java.Lang.Object.GetObject<TransportRuntime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDestination destination = Java.Lang.Object.GetObject<IDestination>(native_destination, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportRuntime.NewFactory(destination));
		}

		[Register("newFactory", "(Lcom/google/android/datatransport/runtime/Destination;)Lcom/google/android/datatransport/TransportFactory;", "GetNewFactory_Lcom_google_android_datatransport_runtime_Destination_Handler")]
		public unsafe virtual ITransportFactory NewFactory(IDestination destination)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((destination == null) ? IntPtr.Zero : ((Java.Lang.Object)destination).Handle);
				return Java.Lang.Object.GetObject<ITransportFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("newFactory.(Lcom/google/android/datatransport/runtime/Destination;)Lcom/google/android/datatransport/TransportFactory;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(destination);
			}
		}

		[Obsolete]
		private static Delegate GetNewFactory_Ljava_lang_String_Handler()
		{
			if ((object)cb_newFactory_Ljava_lang_String_ == null)
			{
				cb_newFactory_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewFactory_Ljava_lang_String_));
			}
			return cb_newFactory_Ljava_lang_String_;
		}

		[Obsolete]
		private static IntPtr n_NewFactory_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_backendName)
		{
			TransportRuntime transportRuntime = Java.Lang.Object.GetObject<TransportRuntime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string backendName = JNIEnv.GetString(native_backendName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportRuntime.NewFactory(backendName));
		}

		[Obsolete("deprecated")]
		[Register("newFactory", "(Ljava/lang/String;)Lcom/google/android/datatransport/TransportFactory;", "GetNewFactory_Ljava_lang_String_Handler")]
		public unsafe virtual ITransportFactory NewFactory(string backendName)
		{
			IntPtr intPtr = JNIEnv.NewString(backendName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ITransportFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("newFactory.(Ljava/lang/String;)Lcom/google/android/datatransport/TransportFactory;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/TransportRuntimeComponent", DoNotGenerateAcw = true)]
	public abstract class TransportRuntimeComponent : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportRuntimeComponent", typeof(TransportRuntimeComponent));

		private static Delegate cb_close;

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

		protected TransportRuntimeComponent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<TransportRuntimeComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}
	}
	[Register("com/google/android/datatransport/runtime/TransportRuntimeComponent", DoNotGenerateAcw = true)]
	internal class TransportRuntimeComponentInvoker : TransportRuntimeComponent
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/TransportRuntimeComponent", typeof(TransportRuntimeComponentInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TransportRuntimeComponentInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Util
{
	[Register("com/google/android/datatransport/runtime/util/PriorityMapping", DoNotGenerateAcw = true)]
	public sealed class PriorityMapping : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/util/PriorityMapping", typeof(PriorityMapping));

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

		internal PriorityMapping(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PriorityMapping()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("toInt", "(Lcom/google/android/datatransport/Priority;)I", "")]
		public unsafe static int ToInt(Priority priority)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeInt32Method("toInt.(Lcom/google/android/datatransport/Priority;)I", ptr);
			}
			finally
			{
				GC.KeepAlive(priority);
			}
		}

		[Register("valueOf", "(I)Lcom/google/android/datatransport/Priority;", "")]
		public unsafe static Priority ValueOf(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<Priority>(_members.StaticMethods.InvokeObjectMethod("valueOf.(I)Lcom/google/android/datatransport/Priority;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Time
{
	[Register("com/google/android/datatransport/runtime/time/Clock", "", "Xamarin.Google.Android.DataTransport.Runtime.Time.IClockInvoker")]
	public interface IClock : IJavaObject, IDisposable, IJavaPeerable
	{
		long Time
		{
			[Register("getTime", "()J", "GetGetTimeHandler:Xamarin.Google.Android.DataTransport.Runtime.Time.IClockInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
			get;
		}
	}
	[Register("com/google/android/datatransport/runtime/time/Clock", DoNotGenerateAcw = true)]
	internal class IClockInvoker : Java.Lang.Object, IClock, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/Clock", typeof(IClockInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getTime;

		private IntPtr id_getTime;

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

		public long Time
		{
			get
			{
				if (id_getTime == IntPtr.Zero)
				{
					id_getTime = JNIEnv.GetMethodID(class_ref, "getTime", "()J");
				}
				return JNIEnv.CallLongMethod(base.Handle, id_getTime);
			}
		}

		public static IClock GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IClock>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.time.Clock'.");
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

		public IClockInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetTimeHandler()
		{
			if ((object)cb_getTime == null)
			{
				cb_getTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTime));
			}
			return cb_getTime;
		}

		private static long n_GetTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Time;
		}
	}
	[Register("com/google/android/datatransport/runtime/time/Monotonic", "", "Xamarin.Google.Android.DataTransport.Runtime.Time.IMonotonicInvoker")]
	public interface IMonotonic : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/time/Monotonic", DoNotGenerateAcw = true)]
	internal class IMonotonicInvoker : Java.Lang.Object, IMonotonic, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/Monotonic", typeof(IMonotonicInvoker));

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

		public static IMonotonic GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMonotonic>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.time.Monotonic'.");
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

		public IMonotonicInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMonotonic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IMonotonic monotonic = Java.Lang.Object.GetObject<IMonotonic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return monotonic.Equals(obj);
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
			return Java.Lang.Object.GetObject<IMonotonic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMonotonic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/time/WallTime", "", "Xamarin.Google.Android.DataTransport.Runtime.Time.IWallTimeInvoker")]
	public interface IWallTime : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/time/WallTime", DoNotGenerateAcw = true)]
	internal class IWallTimeInvoker : Java.Lang.Object, IWallTime, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/WallTime", typeof(IWallTimeInvoker));

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

		public static IWallTime GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IWallTime>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.time.WallTime'.");
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

		public IWallTimeInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWallTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IWallTime wallTime = Java.Lang.Object.GetObject<IWallTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return wallTime.Equals(obj);
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
			return Java.Lang.Object.GetObject<IWallTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IWallTime>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.android.datatransport.runtime.time.Monotonic")]
	public class MonotonicAttribute : Attribute
	{
	}
	[Register("com/google/android/datatransport/runtime/time/TestClock", DoNotGenerateAcw = true)]
	public class TestClock : Java.Lang.Object, IClock, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/TestClock", typeof(TestClock));

		private static Delegate cb_getTime;

		private static Delegate cb_advance_J;

		private static Delegate cb_tick;

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

		public unsafe virtual long Time
		{
			[Register("getTime", "()J", "GetGetTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTime.()J", this, null);
			}
		}

		protected TestClock(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(J)V", "")]
		public unsafe TestClock(long initialTimestamp)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(initialTimestamp);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(J)V", this, ptr);
			}
		}

		private static Delegate GetGetTimeHandler()
		{
			if ((object)cb_getTime == null)
			{
				cb_getTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTime));
			}
			return cb_getTime;
		}

		private static long n_GetTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TestClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Time;
		}

		private static Delegate GetAdvance_JHandler()
		{
			if ((object)cb_advance_J == null)
			{
				cb_advance_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_Advance_J));
			}
			return cb_advance_J;
		}

		private static void n_Advance_J(IntPtr jnienv, IntPtr native__this, long value)
		{
			Java.Lang.Object.GetObject<TestClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Advance(value);
		}

		[Register("advance", "(J)V", "GetAdvance_JHandler")]
		public unsafe virtual void Advance(long value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("advance.(J)V", this, ptr);
		}

		private static Delegate GetTickHandler()
		{
			if ((object)cb_tick == null)
			{
				cb_tick = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Tick));
			}
			return cb_tick;
		}

		private static void n_Tick(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<TestClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tick();
		}

		[Register("tick", "()V", "GetTickHandler")]
		public unsafe virtual void Tick()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("tick.()V", this, null);
		}
	}
	[Register("com/google/android/datatransport/runtime/time/TimeModule", DoNotGenerateAcw = true)]
	public abstract class TimeModule : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/TimeModule", typeof(TimeModule));

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

		protected TimeModule(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TimeModule()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/time/TimeModule", DoNotGenerateAcw = true)]
	internal class TimeModuleInvoker : TimeModule
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/TimeModule", typeof(TimeModuleInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public TimeModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/time/UptimeClock", DoNotGenerateAcw = true)]
	public class UptimeClock : Java.Lang.Object, IClock, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/UptimeClock", typeof(UptimeClock));

		private static Delegate cb_getTime;

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

		public unsafe virtual long Time
		{
			[Register("getTime", "()J", "GetGetTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTime.()J", this, null);
			}
		}

		protected UptimeClock(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe UptimeClock()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetTimeHandler()
		{
			if ((object)cb_getTime == null)
			{
				cb_getTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTime));
			}
			return cb_getTime;
		}

		private static long n_GetTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<UptimeClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Time;
		}
	}
	[Annotation("com.google.android.datatransport.runtime.time.WallTime")]
	public class WallTimeAttribute : Attribute
	{
	}
	[Register("com/google/android/datatransport/runtime/time/WallTimeClock", DoNotGenerateAcw = true)]
	public class WallTimeClock : Java.Lang.Object, IClock, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/time/WallTimeClock", typeof(WallTimeClock));

		private static Delegate cb_getTime;

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

		public unsafe virtual long Time
		{
			[Register("getTime", "()J", "GetGetTimeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTime.()J", this, null);
			}
		}

		protected WallTimeClock(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WallTimeClock()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetTimeHandler()
		{
			if ((object)cb_getTime == null)
			{
				cb_getTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTime));
			}
			return cb_getTime;
		}

		private static long n_GetTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WallTimeClock>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Time;
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Synchronization
{
	[Register("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection", "", "Xamarin.Google.Android.DataTransport.Runtime.Synchronization.ISynchronizationGuardCriticalSectionInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ISynchronizationGuardCriticalSection : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("execute", "()Ljava/lang/Object;", "GetExecuteHandler:Xamarin.Google.Android.DataTransport.Runtime.Synchronization.ISynchronizationGuardCriticalSectionInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Java.Lang.Object Execute();
	}
	[Register("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection", DoNotGenerateAcw = true)]
	internal class ISynchronizationGuardCriticalSectionInvoker : Java.Lang.Object, ISynchronizationGuardCriticalSection, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection", typeof(ISynchronizationGuardCriticalSectionInvoker));

		private IntPtr class_ref;

		private static Delegate cb_execute;

		private IntPtr id_execute;

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

		public static ISynchronizationGuardCriticalSection GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISynchronizationGuardCriticalSection>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.synchronization.SynchronizationGuard.CriticalSection'.");
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

		public ISynchronizationGuardCriticalSectionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetExecuteHandler()
		{
			if ((object)cb_execute == null)
			{
				cb_execute = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Execute));
			}
			return cb_execute;
		}

		private static IntPtr n_Execute(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISynchronizationGuardCriticalSection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Execute());
		}

		public Java.Lang.Object Execute()
		{
			if (id_execute == IntPtr.Zero)
			{
				id_execute = JNIEnv.GetMethodID(class_ref, "execute", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_execute), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard", "", "Xamarin.Google.Android.DataTransport.Runtime.Synchronization.ISynchronizationGuardInvoker")]
	public interface ISynchronizationGuard : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("runCriticalSection", "(Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection;)Ljava/lang/Object;", "GetRunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_Handler:Xamarin.Google.Android.DataTransport.Runtime.Synchronization.ISynchronizationGuardInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		[JavaTypeParameters(new string[] { "T" })]
		Java.Lang.Object RunCriticalSection(ISynchronizationGuardCriticalSection p0);
	}
	[Register("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard", DoNotGenerateAcw = true)]
	internal class ISynchronizationGuardInvoker : Java.Lang.Object, ISynchronizationGuard, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/synchronization/SynchronizationGuard", typeof(ISynchronizationGuardInvoker));

		private IntPtr class_ref;

		private static Delegate cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_;

		private IntPtr id_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_;

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

		public static ISynchronizationGuard GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISynchronizationGuard>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.synchronization.SynchronizationGuard'.");
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

		public ISynchronizationGuardInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetRunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_Handler()
		{
			if ((object)cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ == null)
			{
				cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_));
			}
			return cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_;
		}

		private static IntPtr n_RunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ISynchronizationGuard synchronizationGuard = Java.Lang.Object.GetObject<ISynchronizationGuard>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISynchronizationGuardCriticalSection p = Java.Lang.Object.GetObject<ISynchronizationGuardCriticalSection>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(synchronizationGuard.RunCriticalSection(p));
		}

		public unsafe Java.Lang.Object RunCriticalSection(ISynchronizationGuardCriticalSection p0)
		{
			if (id_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ == IntPtr.Zero)
			{
				id_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ = JNIEnv.GetMethodID(class_ref, "runCriticalSection", "(Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/synchronization/SynchronizationException", DoNotGenerateAcw = true)]
	public class SynchronizationException : RuntimeException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/synchronization/SynchronizationException", typeof(SynchronizationException));

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

		protected SynchronizationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe SynchronizationException(string message, Throwable cause)
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
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Scheduling
{
	[Register("com/google/android/datatransport/runtime/scheduling/DefaultScheduler", DoNotGenerateAcw = true)]
	public class DefaultScheduler : Java.Lang.Object, IScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/DefaultScheduler", typeof(DefaultScheduler));

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_;

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

		protected DefaultScheduler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;)V", "")]
		public unsafe DefaultScheduler(IExecutor executor, IBackendRegistry backendRegistry, IWorkScheduler workScheduler, IEventStore eventStore, ISynchronizationGuard guard)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
				ptr[1] = new JniArgumentValue((backendRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)backendRegistry).Handle);
				ptr[2] = new JniArgumentValue((workScheduler == null) ? IntPtr.Zero : ((Java.Lang.Object)workScheduler).Handle);
				ptr[3] = new JniArgumentValue((eventStore == null) ? IntPtr.Zero : ((Java.Lang.Object)eventStore).Handle);
				ptr[4] = new JniArgumentValue((guard == null) ? IntPtr.Zero : ((Java.Lang.Object)guard).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(executor);
				GC.KeepAlive(backendRegistry);
				GC.KeepAlive(workScheduler);
				GC.KeepAlive(eventStore);
				GC.KeepAlive(guard);
			}
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_Handler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, IntPtr native_e, IntPtr native__callback)
		{
			DefaultScheduler defaultScheduler = Java.Lang.Object.GetObject<DefaultScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			EventInternal e = Java.Lang.Object.GetObject<EventInternal>(native_e, JniHandleOwnership.DoNotTransfer);
			ITransportScheduleCallback callback = Java.Lang.Object.GetObject<ITransportScheduleCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			defaultScheduler.Schedule(transportContext, e, callback);
		}

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;Lcom/google/android/datatransport/TransportScheduleCallback;)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_Handler")]
		public unsafe virtual void Schedule(TransportContext transportContext, EventInternal e, ITransportScheduleCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("schedule.(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;Lcom/google/android/datatransport/TransportScheduleCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
				GC.KeepAlive(e);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/Scheduler", "", "Xamarin.Google.Android.DataTransport.Runtime.Scheduling.ISchedulerInvoker")]
	public interface IScheduler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;Lcom/google/android/datatransport/TransportScheduleCallback;)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_Handler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.ISchedulerInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void Schedule(TransportContext p0, EventInternal p1, ITransportScheduleCallback p2);
	}
	[Register("com/google/android/datatransport/runtime/scheduling/Scheduler", DoNotGenerateAcw = true)]
	internal class ISchedulerInvoker : Java.Lang.Object, IScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/Scheduler", typeof(ISchedulerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_;

		private IntPtr id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_;

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

		public static IScheduler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IScheduler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.scheduling.Scheduler'.");
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

		public ISchedulerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_Handler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			IScheduler scheduler = Java.Lang.Object.GetObject<IScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			EventInternal p2 = Java.Lang.Object.GetObject<EventInternal>(native_p1, JniHandleOwnership.DoNotTransfer);
			ITransportScheduleCallback p3 = Java.Lang.Object.GetObject<ITransportScheduleCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
			scheduler.Schedule(p, p2, p3);
		}

		public unsafe void Schedule(TransportContext p0, EventInternal p1, ITransportScheduleCallback p2)
		{
			if (id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ == IntPtr.Zero)
			{
				id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_ = JNIEnv.GetMethodID(class_ref, "schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;Lcom/google/android/datatransport/TransportScheduleCallback;)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Lcom_google_android_datatransport_TransportScheduleCallback_, ptr);
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/SchedulingConfigModule", DoNotGenerateAcw = true)]
	public abstract class SchedulingConfigModule : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/SchedulingConfigModule", typeof(SchedulingConfigModule));

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

		protected SchedulingConfigModule(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SchedulingConfigModule()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/SchedulingConfigModule", DoNotGenerateAcw = true)]
	internal class SchedulingConfigModuleInvoker : SchedulingConfigModule
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/SchedulingConfigModule", typeof(SchedulingConfigModuleInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SchedulingConfigModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/SchedulingModule", DoNotGenerateAcw = true)]
	public abstract class SchedulingModule : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/SchedulingModule", typeof(SchedulingModule));

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

		protected SchedulingModule(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SchedulingModule()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/SchedulingModule", DoNotGenerateAcw = true)]
	internal class SchedulingModuleInvoker : SchedulingModule
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/SchedulingModule", typeof(SchedulingModuleInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SchedulingModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling
{
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerScheduler", DoNotGenerateAcw = true)]
	public class AlarmManagerScheduler : Java.Lang.Object, IWorkScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerScheduler", typeof(AlarmManagerScheduler));

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;

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

		protected AlarmManagerScheduler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", "")]
		public unsafe AlarmManagerScheduler(Context applicationContext, IEventStore eventStore, IClock clock, SchedulerConfig config)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((eventStore == null) ? IntPtr.Zero : ((Java.Lang.Object)eventStore).Handle);
				ptr[2] = new JniArgumentValue((clock == null) ? IntPtr.Zero : ((Java.Lang.Object)clock).Handle);
				ptr[3] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(applicationContext);
				GC.KeepAlive(eventStore);
				GC.KeepAlive(clock);
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, int attemptNumber)
		{
			AlarmManagerScheduler alarmManagerScheduler = Java.Lang.Object.GetObject<AlarmManagerScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			alarmManagerScheduler.Schedule(transportContext, attemptNumber);
		}

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;I)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler")]
		public unsafe virtual void Schedule(TransportContext transportContext, int attemptNumber)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(attemptNumber);
				_members.InstanceMethods.InvokeVirtualVoidMethod("schedule.(Lcom/google/android/datatransport/runtime/TransportContext;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIZ_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, int attemptNumber, bool force)
		{
			AlarmManagerScheduler alarmManagerScheduler = Java.Lang.Object.GetObject<AlarmManagerScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			alarmManagerScheduler.Schedule(transportContext, attemptNumber, force);
		}

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler")]
		public unsafe virtual void Schedule(TransportContext transportContext, int attemptNumber, bool force)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(attemptNumber);
				ptr[2] = new JniArgumentValue(force);
				_members.InstanceMethods.InvokeVirtualVoidMethod("schedule.(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerSchedulerBroadcastReceiver", DoNotGenerateAcw = true)]
	public class AlarmManagerSchedulerBroadcastReceiver : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerSchedulerBroadcastReceiver", typeof(AlarmManagerSchedulerBroadcastReceiver));

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

		protected AlarmManagerSchedulerBroadcastReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AlarmManagerSchedulerBroadcastReceiver()
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
			AlarmManagerSchedulerBroadcastReceiver alarmManagerSchedulerBroadcastReceiver = Java.Lang.Object.GetObject<AlarmManagerSchedulerBroadcastReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			alarmManagerSchedulerBroadcastReceiver.OnReceive(context, intent);
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
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler", "", "Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.IWorkSchedulerInvoker")]
	public interface IWorkScheduler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;I)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.IWorkSchedulerInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void Schedule(TransportContext p0, int p1);

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.IWorkSchedulerInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void Schedule(TransportContext p0, int p1, bool p2);
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler", DoNotGenerateAcw = true)]
	internal class IWorkSchedulerInvoker : Java.Lang.Object, IWorkScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler", typeof(IWorkSchedulerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;

		private IntPtr id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;

		private IntPtr id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;

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

		public static IWorkScheduler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IWorkScheduler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.scheduling.jobscheduling.WorkScheduler'.");
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

		public IWorkSchedulerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			IWorkScheduler workScheduler = Java.Lang.Object.GetObject<IWorkScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p2 = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			workScheduler.Schedule(p2, p1);
		}

		public unsafe void Schedule(TransportContext p0, int p1)
		{
			if (id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I == IntPtr.Zero)
			{
				id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I = JNIEnv.GetMethodID(class_ref, "schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;I)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I, ptr);
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIZ_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, bool p2)
		{
			IWorkScheduler workScheduler = Java.Lang.Object.GetObject<IWorkScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p3 = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			workScheduler.Schedule(p3, p1, p2);
		}

		public unsafe void Schedule(TransportContext p0, int p1, bool p2)
		{
			if (id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ == IntPtr.Zero)
			{
				id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ = JNIEnv.GetMethodID(class_ref, "schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1);
			ptr[2] = new JValue(p2);
			JNIEnv.CallVoidMethod(base.Handle, id_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ, ptr);
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoScheduler", DoNotGenerateAcw = true)]
	public class JobInfoScheduler : Java.Lang.Object, IWorkScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoScheduler", typeof(JobInfoScheduler));

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;

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

		protected JobInfoScheduler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", "")]
		public unsafe JobInfoScheduler(Context applicationContext, IEventStore eventStore, SchedulerConfig config)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((eventStore == null) ? IntPtr.Zero : ((Java.Lang.Object)eventStore).Handle);
				ptr[2] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(applicationContext);
				GC.KeepAlive(eventStore);
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_I;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_I(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, int attemptNumber)
		{
			JobInfoScheduler jobInfoScheduler = Java.Lang.Object.GetObject<JobInfoScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			jobInfoScheduler.Schedule(transportContext, attemptNumber);
		}

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;I)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IHandler")]
		public unsafe virtual void Schedule(TransportContext transportContext, int attemptNumber)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(attemptNumber);
				_members.InstanceMethods.InvokeVirtualVoidMethod("schedule.(Lcom/google/android/datatransport/runtime/TransportContext;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIZ_V(n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ));
			}
			return cb_schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_runtime_TransportContext_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, int attemptNumber, bool force)
		{
			JobInfoScheduler jobInfoScheduler = Java.Lang.Object.GetObject<JobInfoScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			jobInfoScheduler.Schedule(transportContext, attemptNumber, force);
		}

		[Register("schedule", "(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V", "GetSchedule_Lcom_google_android_datatransport_runtime_TransportContext_IZHandler")]
		public unsafe virtual void Schedule(TransportContext transportContext, int attemptNumber, bool force)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(attemptNumber);
				ptr[2] = new JniArgumentValue(force);
				_members.InstanceMethods.InvokeVirtualVoidMethod("schedule.(Lcom/google/android/datatransport/runtime/TransportContext;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoSchedulerService", DoNotGenerateAcw = true)]
	public class JobInfoSchedulerService : JobService
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoSchedulerService", typeof(JobInfoSchedulerService));

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

		protected JobInfoSchedulerService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe JobInfoSchedulerService()
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

		private static bool n_OnStartJob_Landroid_app_job_JobParameters_(IntPtr jnienv, IntPtr native__this, IntPtr native__params)
		{
			JobInfoSchedulerService jobInfoSchedulerService = Java.Lang.Object.GetObject<JobInfoSchedulerService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JobParameters jobParameters = Java.Lang.Object.GetObject<JobParameters>(native__params, JniHandleOwnership.DoNotTransfer);
			return jobInfoSchedulerService.OnStartJob(jobParameters);
		}

		[Register("onStartJob", "(Landroid/app/job/JobParameters;)Z", "GetOnStartJob_Landroid_app_job_JobParameters_Handler")]
		public unsafe override bool OnStartJob(JobParameters @params)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartJob.(Landroid/app/job/JobParameters;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@params);
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

		private static bool n_OnStopJob_Landroid_app_job_JobParameters_(IntPtr jnienv, IntPtr native__this, IntPtr native__params)
		{
			JobInfoSchedulerService jobInfoSchedulerService = Java.Lang.Object.GetObject<JobInfoSchedulerService>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JobParameters jobParameters = Java.Lang.Object.GetObject<JobParameters>(native__params, JniHandleOwnership.DoNotTransfer);
			return jobInfoSchedulerService.OnStopJob(jobParameters);
		}

		[Register("onStopJob", "(Landroid/app/job/JobParameters;)Z", "GetOnStopJob_Landroid_app_job_JobParameters_Handler")]
		public unsafe override bool OnStopJob(JobParameters @params)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStopJob.(Landroid/app/job/JobParameters;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig", DoNotGenerateAcw = true)]
	public abstract class SchedulerConfig : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder", typeof(Builder));

			private static Delegate cb_addConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_;

			private static Delegate cb_build;

			private static Delegate cb_setClock_Lcom_google_android_datatransport_runtime_time_Clock_;

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

			private static Delegate GetAddConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_Handler()
			{
				if ((object)cb_addConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_ == null)
				{
					cb_addConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_));
				}
				return cb_addConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_;
			}

			private static IntPtr n_AddConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_(IntPtr jnienv, IntPtr native__this, IntPtr native_priority, IntPtr native_value)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
				ConfigValue value = Java.Lang.Object.GetObject<ConfigValue>(native_value, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.AddConfig(priority, value));
			}

			[Register("addConfig", "(Lcom/google/android/datatransport/Priority;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", "GetAddConfig_Lcom_google_android_datatransport_Priority_Lcom_google_android_datatransport_runtime_scheduling_jobscheduling_SchedulerConfig_ConfigValue_Handler")]
			public unsafe virtual Builder AddConfig(Priority priority, ConfigValue value)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addConfig.(Lcom/google/android/datatransport/Priority;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(priority);
					GC.KeepAlive(value);
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

			[Register("build", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;", "GetBuildHandler")]
			public unsafe virtual SchedulerConfig Build()
			{
				return Java.Lang.Object.GetObject<SchedulerConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetClock_Lcom_google_android_datatransport_runtime_time_Clock_Handler()
			{
				if ((object)cb_setClock_Lcom_google_android_datatransport_runtime_time_Clock_ == null)
				{
					cb_setClock_Lcom_google_android_datatransport_runtime_time_Clock_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetClock_Lcom_google_android_datatransport_runtime_time_Clock_));
				}
				return cb_setClock_Lcom_google_android_datatransport_runtime_time_Clock_;
			}

			private static IntPtr n_SetClock_Lcom_google_android_datatransport_runtime_time_Clock_(IntPtr jnienv, IntPtr native__this, IntPtr native_clock)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IClock clock = Java.Lang.Object.GetObject<IClock>(native_clock, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetClock(clock));
			}

			[Register("setClock", "(Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", "GetSetClock_Lcom_google_android_datatransport_runtime_time_Clock_Handler")]
			public unsafe virtual Builder SetClock(IClock clock)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((clock == null) ? IntPtr.Zero : ((Java.Lang.Object)clock).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setClock.(Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(clock);
				}
			}
		}

		[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue", DoNotGenerateAcw = true)]
		public abstract class ConfigValue : Java.Lang.Object
		{
			[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder", DoNotGenerateAcw = true)]
			public abstract class Builder : Java.Lang.Object
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder", typeof(Builder));

				private static Delegate cb_build;

				private static Delegate cb_setDelta_J;

				private static Delegate cb_setFlags_Ljava_util_Set_;

				private static Delegate cb_setMaxAllowedDelay_J;

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

				[Register("build", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue;", "GetBuildHandler")]
				public abstract ConfigValue Build();

				private static Delegate GetSetDelta_JHandler()
				{
					if ((object)cb_setDelta_J == null)
					{
						cb_setDelta_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetDelta_J));
					}
					return cb_setDelta_J;
				}

				private static IntPtr n_SetDelta_J(IntPtr jnienv, IntPtr native__this, long p0)
				{
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDelta(p0));
				}

				[Register("setDelta", "(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetDelta_JHandler")]
				public abstract Builder SetDelta(long p0);

				private static Delegate GetSetFlags_Ljava_util_Set_Handler()
				{
					if ((object)cb_setFlags_Ljava_util_Set_ == null)
					{
						cb_setFlags_Ljava_util_Set_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetFlags_Ljava_util_Set_));
					}
					return cb_setFlags_Ljava_util_Set_;
				}

				private static IntPtr n_SetFlags_Ljava_util_Set_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
				{
					Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ICollection<Flag> flags = JavaSet<Flag>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetFlags(flags));
				}

				[Register("setFlags", "(Ljava/util/Set;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetFlags_Ljava_util_Set_Handler")]
				public abstract Builder SetFlags(ICollection<Flag> p0);

				private static Delegate GetSetMaxAllowedDelay_JHandler()
				{
					if ((object)cb_setMaxAllowedDelay_J == null)
					{
						cb_setMaxAllowedDelay_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_SetMaxAllowedDelay_J));
					}
					return cb_setMaxAllowedDelay_J;
				}

				private static IntPtr n_SetMaxAllowedDelay_J(IntPtr jnienv, IntPtr native__this, long p0)
				{
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxAllowedDelay(p0));
				}

				[Register("setMaxAllowedDelay", "(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetMaxAllowedDelay_JHandler")]
				public abstract Builder SetMaxAllowedDelay(long p0);
			}

			[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder", DoNotGenerateAcw = true)]
			internal class BuilderInvoker : Builder
			{
				private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder", typeof(BuilderInvoker));

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

				[Register("build", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue;", "GetBuildHandler")]
				public unsafe override ConfigValue Build()
				{
					return Java.Lang.Object.GetObject<ConfigValue>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}

				[Register("setDelta", "(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetDelta_JHandler")]
				public unsafe override Builder SetDelta(long p0)
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDelta.(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}

				[Register("setFlags", "(Ljava/util/Set;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetFlags_Ljava_util_Set_Handler")]
				public unsafe override Builder SetFlags(ICollection<Flag> p0)
				{
					IntPtr intPtr = JavaSet<Flag>.ToLocalJniHandle(p0);
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(intPtr);
						return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFlags.(Ljava/util/Set;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
					}
					finally
					{
						JNIEnv.DeleteLocalRef(intPtr);
						GC.KeepAlive(p0);
					}
				}

				[Register("setMaxAllowedDelay", "(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "GetSetMaxAllowedDelay_JHandler")]
				public unsafe override Builder SetMaxAllowedDelay(long p0)
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMaxAllowedDelay.(J)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue", typeof(ConfigValue));

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

			protected ConfigValue(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe ConfigValue()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register("builder", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", "")]
			public unsafe static Builder InvokeBuilder()
			{
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue", DoNotGenerateAcw = true)]
		internal class ConfigValueInvoker : ConfigValue
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue", typeof(ConfigValueInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public ConfigValueInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag", DoNotGenerateAcw = true)]
		public sealed class Flag : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag", typeof(Flag));

			[Register("DEVICE_CHARGING")]
			public static Flag DeviceCharging => Java.Lang.Object.GetObject<Flag>(_members.StaticFields.GetObjectValue("DEVICE_CHARGING.Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("DEVICE_IDLE")]
			public static Flag DeviceIdle => Java.Lang.Object.GetObject<Flag>(_members.StaticFields.GetObjectValue("DEVICE_IDLE.Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NETWORK_UNMETERED")]
			public static Flag NetworkUnmetered => Java.Lang.Object.GetObject<Flag>(_members.StaticFields.GetObjectValue("NETWORK_UNMETERED.Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Flag(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;", "")]
			public unsafe static Flag ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Flag>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;", "")]
			public unsafe static Flag[] Values()
			{
				return (Flag[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Flag));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig", typeof(SchedulerConfig));

		private static Delegate cb_configureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI;

		private static Delegate cb_getFlags_Lcom_google_android_datatransport_Priority_;

		private static Delegate cb_getScheduleDelay_Lcom_google_android_datatransport_Priority_JI;

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

		protected SchedulerConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SchedulerConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("builder", "()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetConfigureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JIHandler()
		{
			if ((object)cb_configureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI == null)
			{
				cb_configureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLJI_L(n_ConfigureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI));
			}
			return cb_configureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI;
		}

		private static IntPtr n_ConfigureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JI(IntPtr jnienv, IntPtr native__this, IntPtr native_builder, IntPtr native_priority, long minimumTimestamp, int attemptNumber)
		{
			SchedulerConfig schedulerConfig = Java.Lang.Object.GetObject<SchedulerConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JobInfo.Builder builder = Java.Lang.Object.GetObject<JobInfo.Builder>(native_builder, JniHandleOwnership.DoNotTransfer);
			Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(schedulerConfig.ConfigureJob(builder, priority, minimumTimestamp, attemptNumber));
		}

		[Register("configureJob", "(Landroid/app/job/JobInfo$Builder;Lcom/google/android/datatransport/Priority;JI)Landroid/app/job/JobInfo$Builder;", "GetConfigureJob_Landroid_app_job_JobInfo_Builder_Lcom_google_android_datatransport_Priority_JIHandler")]
		public unsafe virtual JobInfo.Builder ConfigureJob(JobInfo.Builder builder, Priority priority, long minimumTimestamp, int attemptNumber)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(minimumTimestamp);
				ptr[3] = new JniArgumentValue(attemptNumber);
				return Java.Lang.Object.GetObject<JobInfo.Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("configureJob.(Landroid/app/job/JobInfo$Builder;Lcom/google/android/datatransport/Priority;JI)Landroid/app/job/JobInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(priority);
			}
		}

		[Register("getDefault", "(Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;", "")]
		public unsafe static SchedulerConfig GetDefault(IClock clock)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((clock == null) ? IntPtr.Zero : ((Java.Lang.Object)clock).Handle);
				return Java.Lang.Object.GetObject<SchedulerConfig>(_members.StaticMethods.InvokeObjectMethod("getDefault.(Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(clock);
			}
		}

		private static Delegate GetGetFlags_Lcom_google_android_datatransport_Priority_Handler()
		{
			if ((object)cb_getFlags_Lcom_google_android_datatransport_Priority_ == null)
			{
				cb_getFlags_Lcom_google_android_datatransport_Priority_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetFlags_Lcom_google_android_datatransport_Priority_));
			}
			return cb_getFlags_Lcom_google_android_datatransport_Priority_;
		}

		private static IntPtr n_GetFlags_Lcom_google_android_datatransport_Priority_(IntPtr jnienv, IntPtr native__this, IntPtr native_priority)
		{
			SchedulerConfig schedulerConfig = Java.Lang.Object.GetObject<SchedulerConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
			return JavaSet<Flag>.ToLocalJniHandle(schedulerConfig.GetFlags(priority));
		}

		[Register("getFlags", "(Lcom/google/android/datatransport/Priority;)Ljava/util/Set;", "GetGetFlags_Lcom_google_android_datatransport_Priority_Handler")]
		public unsafe virtual ICollection<Flag> GetFlags(Priority priority)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
				return JavaSet<Flag>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFlags.(Lcom/google/android/datatransport/Priority;)Ljava/util/Set;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(priority);
			}
		}

		private static Delegate GetGetScheduleDelay_Lcom_google_android_datatransport_Priority_JIHandler()
		{
			if ((object)cb_getScheduleDelay_Lcom_google_android_datatransport_Priority_JI == null)
			{
				cb_getScheduleDelay_Lcom_google_android_datatransport_Priority_JI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLJI_J(n_GetScheduleDelay_Lcom_google_android_datatransport_Priority_JI));
			}
			return cb_getScheduleDelay_Lcom_google_android_datatransport_Priority_JI;
		}

		private static long n_GetScheduleDelay_Lcom_google_android_datatransport_Priority_JI(IntPtr jnienv, IntPtr native__this, IntPtr native_priority, long minTimestamp, int attemptNumber)
		{
			SchedulerConfig schedulerConfig = Java.Lang.Object.GetObject<SchedulerConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Priority priority = Java.Lang.Object.GetObject<Priority>(native_priority, JniHandleOwnership.DoNotTransfer);
			return schedulerConfig.GetScheduleDelay(priority, minTimestamp, attemptNumber);
		}

		[Register("getScheduleDelay", "(Lcom/google/android/datatransport/Priority;JI)J", "GetGetScheduleDelay_Lcom_google_android_datatransport_Priority_JIHandler")]
		public unsafe virtual long GetScheduleDelay(Priority priority, long minTimestamp, int attemptNumber)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(minTimestamp);
				ptr[2] = new JniArgumentValue(attemptNumber);
				return _members.InstanceMethods.InvokeVirtualInt64Method("getScheduleDelay.(Lcom/google/android/datatransport/Priority;JI)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(priority);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig", DoNotGenerateAcw = true)]
	internal class SchedulerConfigInvoker : SchedulerConfig
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig", typeof(SchedulerConfigInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SchedulerConfigInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader", DoNotGenerateAcw = true)]
	public class Uploader : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader", typeof(Uploader));

		private static Delegate cb_upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_;

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

		protected Uploader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;Lcom/google/android/datatransport/runtime/time/Clock;)V", "")]
		public unsafe Uploader(Context context, IBackendRegistry backendRegistry, IEventStore eventStore, IWorkScheduler workScheduler, IExecutor executor, ISynchronizationGuard guard, IClock clock)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((backendRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)backendRegistry).Handle);
				ptr[2] = new JniArgumentValue((eventStore == null) ? IntPtr.Zero : ((Java.Lang.Object)eventStore).Handle);
				ptr[3] = new JniArgumentValue((workScheduler == null) ? IntPtr.Zero : ((Java.Lang.Object)workScheduler).Handle);
				ptr[4] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
				ptr[5] = new JniArgumentValue((guard == null) ? IntPtr.Zero : ((Java.Lang.Object)guard).Handle);
				ptr[6] = new JniArgumentValue((clock == null) ? IntPtr.Zero : ((Java.Lang.Object)clock).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;Lcom/google/android/datatransport/runtime/time/Clock;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/google/android/datatransport/runtime/backends/BackendRegistry;Lcom/google/android/datatransport/runtime/scheduling/persistence/EventStore;Lcom/google/android/datatransport/runtime/scheduling/jobscheduling/WorkScheduler;Ljava/util/concurrent/Executor;Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard;Lcom/google/android/datatransport/runtime/time/Clock;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(backendRegistry);
				GC.KeepAlive(eventStore);
				GC.KeepAlive(workScheduler);
				GC.KeepAlive(executor);
				GC.KeepAlive(guard);
				GC.KeepAlive(clock);
			}
		}

		private static Delegate GetUpload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_Handler()
		{
			if ((object)cb_upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_ == null)
			{
				cb_upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_Upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_));
			}
			return cb_upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_;
		}

		private static void n_Upload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, int attemptNumber, IntPtr native__callback)
		{
			Uploader uploader = Java.Lang.Object.GetObject<Uploader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			IRunnable callback = Java.Lang.Object.GetObject<IRunnable>(native__callback, JniHandleOwnership.DoNotTransfer);
			uploader.Upload(transportContext, attemptNumber, callback);
		}

		[Register("upload", "(Lcom/google/android/datatransport/runtime/TransportContext;ILjava/lang/Runnable;)V", "GetUpload_Lcom_google_android_datatransport_runtime_TransportContext_ILjava_lang_Runnable_Handler")]
		public unsafe virtual void Upload(TransportContext transportContext, int attemptNumber, IRunnable callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(attemptNumber);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("upload.(Lcom/google/android/datatransport/runtime/TransportContext;ILjava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer", DoNotGenerateAcw = true)]
	public class WorkInitializer : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer", typeof(WorkInitializer));

		private static Delegate cb_ensureContextsScheduled;

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

		protected WorkInitializer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetEnsureContextsScheduledHandler()
		{
			if ((object)cb_ensureContextsScheduled == null)
			{
				cb_ensureContextsScheduled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EnsureContextsScheduled));
			}
			return cb_ensureContextsScheduled;
		}

		private static void n_EnsureContextsScheduled(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<WorkInitializer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnsureContextsScheduled();
		}

		[Register("ensureContextsScheduled", "()V", "GetEnsureContextsScheduledHandler")]
		public unsafe virtual void EnsureContextsScheduled()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("ensureContextsScheduled.()V", this, null);
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Retries
{
	[Register("com/google/android/datatransport/runtime/retries/Function", "", "Xamarin.Google.Android.DataTransport.Runtime.Retries.IFunctionInvoker")]
	[JavaTypeParameters(new string[] { "TInput", "TResult", "TException extends java.lang.Throwable" })]
	public interface IFunction : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("apply", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetApply_Ljava_lang_Object_Handler:Xamarin.Google.Android.DataTransport.Runtime.Retries.IFunctionInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Java.Lang.Object Apply(Java.Lang.Object p0);
	}
	[Register("com/google/android/datatransport/runtime/retries/Function", DoNotGenerateAcw = true)]
	internal class IFunctionInvoker : Java.Lang.Object, IFunction, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/retries/Function", typeof(IFunctionInvoker));

		private IntPtr class_ref;

		private static Delegate cb_apply_Ljava_lang_Object_;

		private IntPtr id_apply_Ljava_lang_Object_;

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

		public static IFunction GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFunction>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.retries.Function'.");
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

		public IFunctionInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetApply_Ljava_lang_Object_Handler()
		{
			if ((object)cb_apply_Ljava_lang_Object_ == null)
			{
				cb_apply_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Apply_Ljava_lang_Object_));
			}
			return cb_apply_Ljava_lang_Object_;
		}

		private static IntPtr n_Apply_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IFunction function = Java.Lang.Object.GetObject<IFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(function.Apply(p));
		}

		public unsafe Java.Lang.Object Apply(Java.Lang.Object p0)
		{
			if (id_apply_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_apply_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "apply", "(Ljava/lang/Object;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_apply_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("com/google/android/datatransport/runtime/retries/RetryStrategy", "", "Xamarin.Google.Android.DataTransport.Runtime.Retries.IRetryStrategyInvoker")]
	[JavaTypeParameters(new string[] { "TInput", "TResult" })]
	public interface IRetryStrategy : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("shouldRetry", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;", "GetShouldRetry_Ljava_lang_Object_Ljava_lang_Object_Handler:Xamarin.Google.Android.DataTransport.Runtime.Retries.IRetryStrategyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Java.Lang.Object ShouldRetry(Java.Lang.Object p0, Java.Lang.Object p1);
	}
	[Register("com/google/android/datatransport/runtime/retries/RetryStrategy", DoNotGenerateAcw = true)]
	internal class IRetryStrategyInvoker : Java.Lang.Object, IRetryStrategy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/retries/RetryStrategy", typeof(IRetryStrategyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_;

		private IntPtr id_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_;

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

		public static IRetryStrategy GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRetryStrategy>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.retries.RetryStrategy'.");
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

		public IRetryStrategyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetShouldRetry_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ShouldRetry_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static IntPtr n_ShouldRetry_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IRetryStrategy retryStrategy = Java.Lang.Object.GetObject<IRetryStrategy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(retryStrategy.ShouldRetry(p, p2));
		}

		public unsafe Java.Lang.Object ShouldRetry(Java.Lang.Object p0, Java.Lang.Object p1)
		{
			if (id_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "shouldRetry", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_shouldRetry_Ljava_lang_Object_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}
	}
	[Register("com/google/android/datatransport/runtime/retries/Retries", DoNotGenerateAcw = true)]
	public sealed class Retries : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/retries/Retries", typeof(Retries));

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

		internal Retries(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("retry", "(ILjava/lang/Object;Lcom/google/android/datatransport/runtime/retries/Function;Lcom/google/android/datatransport/runtime/retries/RetryStrategy;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "TInput", "TResult", "TException extends java.lang.Throwable" })]
		public unsafe static Java.Lang.Object Retry(int maxAttempts, Java.Lang.Object input, IFunction function, IRetryStrategy retryStrategy)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(maxAttempts);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((function == null) ? IntPtr.Zero : ((Java.Lang.Object)function).Handle);
				ptr[3] = new JniArgumentValue((retryStrategy == null) ? IntPtr.Zero : ((Java.Lang.Object)retryStrategy).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("retry.(ILjava/lang/Object;Lcom/google/android/datatransport/runtime/retries/Function;Lcom/google/android/datatransport/runtime/retries/RetryStrategy;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(input);
				GC.KeepAlive(function);
				GC.KeepAlive(retryStrategy);
			}
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Persistence
{
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule", DoNotGenerateAcw = true)]
	public abstract class EventStoreModule : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule", typeof(EventStoreModule));

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

		protected EventStoreModule(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EventStoreModule()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule", DoNotGenerateAcw = true)]
	internal class EventStoreModuleInvoker : EventStoreModule
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule", typeof(EventStoreModuleInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public EventStoreModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/EventStore", "", "Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker")]
	public interface IEventStore : ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("cleanUp", "()I", "GetCleanUpHandler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		int CleanUp();

		[Register("getNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;)J", "GetGetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		long GetNextCallTime(TransportContext p0);

		[Register("hasPendingEventsFor", "(Lcom/google/android/datatransport/runtime/TransportContext;)Z", "GetHasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		bool HasPendingEventsFor(TransportContext p0);

		[Register("loadActiveContexts", "()Ljava/lang/Iterable;", "GetLoadActiveContextsHandler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		IIterable LoadActiveContexts();

		[Register("loadBatch", "(Lcom/google/android/datatransport/runtime/TransportContext;)Ljava/lang/Iterable;", "GetLoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		IIterable LoadBatch(TransportContext p0);

		[Register("persist", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;", "GetPersist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		PersistedEvent Persist(TransportContext p0, EventInternal p1);

		[Register("recordFailure", "(Ljava/lang/Iterable;)V", "GetRecordFailure_Ljava_lang_Iterable_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void RecordFailure(IIterable p0);

		[Register("recordNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;J)V", "GetRecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_JHandler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void RecordNextCallTime(TransportContext p0, long p1);

		[Register("recordSuccess", "(Ljava/lang/Iterable;)V", "GetRecordSuccess_Ljava_lang_Iterable_Handler:Xamarin.Google.Android.DataTransport.Runtime.Persistence.IEventStoreInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void RecordSuccess(IIterable p0);
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/EventStore", DoNotGenerateAcw = true)]
	internal class IEventStoreInvoker : Java.Lang.Object, IEventStore, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/EventStore", typeof(IEventStoreInvoker));

		private IntPtr class_ref;

		private static Delegate cb_cleanUp;

		private IntPtr id_cleanUp;

		private static Delegate cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_;

		private IntPtr id_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_;

		private IntPtr id_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_loadActiveContexts;

		private IntPtr id_loadActiveContexts;

		private static Delegate cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_;

		private IntPtr id_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_;

		private IntPtr id_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_;

		private static Delegate cb_recordFailure_Ljava_lang_Iterable_;

		private IntPtr id_recordFailure_Ljava_lang_Iterable_;

		private static Delegate cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J;

		private IntPtr id_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J;

		private static Delegate cb_recordSuccess_Ljava_lang_Iterable_;

		private IntPtr id_recordSuccess_Ljava_lang_Iterable_;

		private static Delegate cb_close;

		private IntPtr id_close;

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

		public static IEventStore GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEventStore>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.scheduling.persistence.EventStore'.");
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

		public IEventStoreInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCleanUpHandler()
		{
			if ((object)cb_cleanUp == null)
			{
				cb_cleanUp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_CleanUp));
			}
			return cb_cleanUp;
		}

		private static int n_CleanUp(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CleanUp();
		}

		public int CleanUp()
		{
			if (id_cleanUp == IntPtr.Zero)
			{
				id_cleanUp = JNIEnv.GetMethodID(class_ref, "cleanUp", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_cleanUp);
		}

		private static Delegate GetGetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_GetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static long n_GetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return eventStore.GetNextCallTime(p);
		}

		public unsafe long GetNextCallTime(TransportContext p0)
		{
			if (id_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ == IntPtr.Zero)
			{
				id_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ = JNIEnv.GetMethodID(class_ref, "getNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallLongMethod(base.Handle, id_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_, ptr);
		}

		private static Delegate GetHasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static bool n_HasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return eventStore.HasPendingEventsFor(p);
		}

		public unsafe bool HasPendingEventsFor(TransportContext p0)
		{
			if (id_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ == IntPtr.Zero)
			{
				id_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ = JNIEnv.GetMethodID(class_ref, "hasPendingEventsFor", "(Lcom/google/android/datatransport/runtime/TransportContext;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_, ptr);
		}

		private static Delegate GetLoadActiveContextsHandler()
		{
			if ((object)cb_loadActiveContexts == null)
			{
				cb_loadActiveContexts = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_LoadActiveContexts));
			}
			return cb_loadActiveContexts;
		}

		private static IntPtr n_LoadActiveContexts(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoadActiveContexts());
		}

		public IIterable LoadActiveContexts()
		{
			if (id_loadActiveContexts == IntPtr.Zero)
			{
				id_loadActiveContexts = JNIEnv.GetMethodID(class_ref, "loadActiveContexts", "()Ljava/lang/Iterable;");
			}
			return Java.Lang.Object.GetObject<IIterable>(JNIEnv.CallObjectMethod(base.Handle, id_loadActiveContexts), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetLoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static IntPtr n_LoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(eventStore.LoadBatch(p));
		}

		public unsafe IIterable LoadBatch(TransportContext p0)
		{
			if (id_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ == IntPtr.Zero)
			{
				id_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ = JNIEnv.GetMethodID(class_ref, "loadBatch", "(Lcom/google/android/datatransport/runtime/TransportContext;)Ljava/lang/Iterable;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IIterable>(JNIEnv.CallObjectMethod(base.Handle, id_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPersist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Handler()
		{
			if ((object)cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ == null)
			{
				cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_));
			}
			return cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_;
		}

		private static IntPtr n_Persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			EventInternal p2 = Java.Lang.Object.GetObject<EventInternal>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(eventStore.Persist(p, p2));
		}

		public unsafe PersistedEvent Persist(TransportContext p0, EventInternal p1)
		{
			if (id_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ == IntPtr.Zero)
			{
				id_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ = JNIEnv.GetMethodID(class_ref, "persist", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PersistedEvent>(JNIEnv.CallObjectMethod(base.Handle, id_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRecordFailure_Ljava_lang_Iterable_Handler()
		{
			if ((object)cb_recordFailure_Ljava_lang_Iterable_ == null)
			{
				cb_recordFailure_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RecordFailure_Ljava_lang_Iterable_));
			}
			return cb_recordFailure_Ljava_lang_Iterable_;
		}

		private static void n_RecordFailure_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIterable p = Java.Lang.Object.GetObject<IIterable>(native_p0, JniHandleOwnership.DoNotTransfer);
			eventStore.RecordFailure(p);
		}

		public unsafe void RecordFailure(IIterable p0)
		{
			if (id_recordFailure_Ljava_lang_Iterable_ == IntPtr.Zero)
			{
				id_recordFailure_Ljava_lang_Iterable_ = JNIEnv.GetMethodID(class_ref, "recordFailure", "(Ljava/lang/Iterable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_recordFailure_Ljava_lang_Iterable_, ptr);
		}

		private static Delegate GetRecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_JHandler()
		{
			if ((object)cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J == null)
			{
				cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_RecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J));
			}
			return cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J;
		}

		private static void n_RecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext p2 = Java.Lang.Object.GetObject<TransportContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			eventStore.RecordNextCallTime(p2, p1);
		}

		public unsafe void RecordNextCallTime(TransportContext p0, long p1)
		{
			if (id_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J == IntPtr.Zero)
			{
				id_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J = JNIEnv.GetMethodID(class_ref, "recordNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;J)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J, ptr);
		}

		private static Delegate GetRecordSuccess_Ljava_lang_Iterable_Handler()
		{
			if ((object)cb_recordSuccess_Ljava_lang_Iterable_ == null)
			{
				cb_recordSuccess_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RecordSuccess_Ljava_lang_Iterable_));
			}
			return cb_recordSuccess_Ljava_lang_Iterable_;
		}

		private static void n_RecordSuccess_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IEventStore eventStore = Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIterable p = Java.Lang.Object.GetObject<IIterable>(native_p0, JniHandleOwnership.DoNotTransfer);
			eventStore.RecordSuccess(p);
		}

		public unsafe void RecordSuccess(IIterable p0)
		{
			if (id_recordSuccess_Ljava_lang_Iterable_ == IntPtr.Zero)
			{
				id_recordSuccess_Ljava_lang_Iterable_ = JNIEnv.GetMethodID(class_ref, "recordSuccess", "(Ljava/lang/Iterable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_recordSuccess_Ljava_lang_Iterable_, ptr);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent", DoNotGenerateAcw = true)]
	public abstract class PersistedEvent : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent", typeof(PersistedEvent));

		private static Delegate cb_getEvent;

		private static Delegate cb_getId;

		private static Delegate cb_getTransportContext;

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

		public abstract EventInternal Event
		{
			[Register("getEvent", "()Lcom/google/android/datatransport/runtime/EventInternal;", "GetGetEventHandler")]
			get;
		}

		public abstract long Id
		{
			[Register("getId", "()J", "GetGetIdHandler")]
			get;
		}

		public abstract TransportContext TransportContext
		{
			[Register("getTransportContext", "()Lcom/google/android/datatransport/runtime/TransportContext;", "GetGetTransportContextHandler")]
			get;
		}

		protected PersistedEvent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PersistedEvent()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetEventHandler()
		{
			if ((object)cb_getEvent == null)
			{
				cb_getEvent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEvent));
			}
			return cb_getEvent;
		}

		private static IntPtr n_GetEvent(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PersistedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Event);
		}

		private static Delegate GetGetIdHandler()
		{
			if ((object)cb_getId == null)
			{
				cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetId));
			}
			return cb_getId;
		}

		private static long n_GetId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<PersistedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
		}

		private static Delegate GetGetTransportContextHandler()
		{
			if ((object)cb_getTransportContext == null)
			{
				cb_getTransportContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTransportContext));
			}
			return cb_getTransportContext;
		}

		private static IntPtr n_GetTransportContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PersistedEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TransportContext);
		}

		[Register("create", "(JLcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;", "")]
		public unsafe static PersistedEvent Create(long id, TransportContext transportContext, EventInternal @object)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PersistedEvent>(_members.StaticMethods.InvokeObjectMethod("create.(JLcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(transportContext);
				GC.KeepAlive(@object);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent", DoNotGenerateAcw = true)]
	internal class PersistedEventInvoker : PersistedEvent
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent", typeof(PersistedEventInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override EventInternal Event
		{
			[Register("getEvent", "()Lcom/google/android/datatransport/runtime/EventInternal;", "GetGetEventHandler")]
			get
			{
				return Java.Lang.Object.GetObject<EventInternal>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEvent.()Lcom/google/android/datatransport/runtime/EventInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override long Id
		{
			[Register("getId", "()J", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getId.()J", this, null);
			}
		}

		public unsafe override TransportContext TransportContext
		{
			[Register("getTransportContext", "()Lcom/google/android/datatransport/runtime/TransportContext;", "GetGetTransportContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<TransportContext>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTransportContext.()Lcom/google/android/datatransport/runtime/TransportContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public PersistedEventInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/scheduling/persistence/SQLiteEventStore", DoNotGenerateAcw = true)]
	public class SQLiteEventStore : Java.Lang.Object, IEventStore, ICloseable, IJavaObject, IDisposable, IJavaPeerable, ISynchronizationGuard
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/scheduling/persistence/SQLiteEventStore", typeof(SQLiteEventStore));

		private static Delegate cb_cleanUp;

		private static Delegate cb_clearDb;

		private static Delegate cb_close;

		private static Delegate cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_loadActiveContexts;

		private static Delegate cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_;

		private static Delegate cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_;

		private static Delegate cb_recordFailure_Ljava_lang_Iterable_;

		private static Delegate cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J;

		private static Delegate cb_recordSuccess_Ljava_lang_Iterable_;

		private static Delegate cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_;

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

		protected SQLiteEventStore(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetCleanUpHandler()
		{
			if ((object)cb_cleanUp == null)
			{
				cb_cleanUp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_CleanUp));
			}
			return cb_cleanUp;
		}

		private static int n_CleanUp(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CleanUp();
		}

		[Register("cleanUp", "()I", "GetCleanUpHandler")]
		public unsafe virtual int CleanUp()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("cleanUp.()I", this, null);
		}

		private static Delegate GetClearDbHandler()
		{
			if ((object)cb_clearDb == null)
			{
				cb_clearDb = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ClearDb));
			}
			return cb_clearDb;
		}

		private static void n_ClearDb(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearDb();
		}

		[Register("clearDb", "()V", "GetClearDbHandler")]
		public unsafe virtual void ClearDb()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearDb.()V", this, null);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetGetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_GetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_getNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static long n_GetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			return sQLiteEventStore.GetNextCallTime(transportContext);
		}

		[Register("getNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;)J", "GetGetNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_Handler")]
		public unsafe virtual long GetNextCallTime(TransportContext transportContext)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt64Method("getNextCallTime.(Lcom/google/android/datatransport/runtime/TransportContext;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetHasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_hasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static bool n_HasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			return sQLiteEventStore.HasPendingEventsFor(transportContext);
		}

		[Register("hasPendingEventsFor", "(Lcom/google/android/datatransport/runtime/TransportContext;)Z", "GetHasPendingEventsFor_Lcom_google_android_datatransport_runtime_TransportContext_Handler")]
		public unsafe virtual bool HasPendingEventsFor(TransportContext transportContext)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPendingEventsFor.(Lcom/google/android/datatransport/runtime/TransportContext;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetLoadActiveContextsHandler()
		{
			if ((object)cb_loadActiveContexts == null)
			{
				cb_loadActiveContexts = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_LoadActiveContexts));
			}
			return cb_loadActiveContexts;
		}

		private static IntPtr n_LoadActiveContexts(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoadActiveContexts());
		}

		[Register("loadActiveContexts", "()Ljava/lang/Iterable;", "GetLoadActiveContextsHandler")]
		public unsafe virtual IIterable LoadActiveContexts()
		{
			return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("loadActiveContexts.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetLoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_Handler()
		{
			if ((object)cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ == null)
			{
				cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_LoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_));
			}
			return cb_loadBatch_Lcom_google_android_datatransport_runtime_TransportContext_;
		}

		private static IntPtr n_LoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sQLiteEventStore.LoadBatch(transportContext));
		}

		[Register("loadBatch", "(Lcom/google/android/datatransport/runtime/TransportContext;)Ljava/lang/Iterable;", "GetLoadBatch_Lcom_google_android_datatransport_runtime_TransportContext_Handler")]
		public unsafe virtual IIterable LoadBatch(TransportContext transportContext)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeVirtualObjectMethod("loadBatch.(Lcom/google/android/datatransport/runtime/TransportContext;)Ljava/lang/Iterable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetPersist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Handler()
		{
			if ((object)cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ == null)
			{
				cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_));
			}
			return cb_persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_;
		}

		private static IntPtr n_Persist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, IntPtr native_e)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			EventInternal e = Java.Lang.Object.GetObject<EventInternal>(native_e, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sQLiteEventStore.Persist(transportContext, e));
		}

		[Register("persist", "(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;", "GetPersist_Lcom_google_android_datatransport_runtime_TransportContext_Lcom_google_android_datatransport_runtime_EventInternal_Handler")]
		public unsafe virtual PersistedEvent Persist(TransportContext transportContext, EventInternal e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PersistedEvent>(_members.InstanceMethods.InvokeVirtualObjectMethod("persist.(Lcom/google/android/datatransport/runtime/TransportContext;Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(transportContext);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetRecordFailure_Ljava_lang_Iterable_Handler()
		{
			if ((object)cb_recordFailure_Ljava_lang_Iterable_ == null)
			{
				cb_recordFailure_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RecordFailure_Ljava_lang_Iterable_));
			}
			return cb_recordFailure_Ljava_lang_Iterable_;
		}

		private static void n_RecordFailure_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_events)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIterable events = Java.Lang.Object.GetObject<IIterable>(native_events, JniHandleOwnership.DoNotTransfer);
			sQLiteEventStore.RecordFailure(events);
		}

		[Register("recordFailure", "(Ljava/lang/Iterable;)V", "GetRecordFailure_Ljava_lang_Iterable_Handler")]
		public unsafe virtual void RecordFailure(IIterable events)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((events == null) ? IntPtr.Zero : ((Java.Lang.Object)events).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("recordFailure.(Ljava/lang/Iterable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(events);
			}
		}

		private static Delegate GetRecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_JHandler()
		{
			if ((object)cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J == null)
			{
				cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_RecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J));
			}
			return cb_recordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J;
		}

		private static void n_RecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_J(IntPtr jnienv, IntPtr native__this, IntPtr native_transportContext, long timestampMs)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransportContext transportContext = Java.Lang.Object.GetObject<TransportContext>(native_transportContext, JniHandleOwnership.DoNotTransfer);
			sQLiteEventStore.RecordNextCallTime(transportContext, timestampMs);
		}

		[Register("recordNextCallTime", "(Lcom/google/android/datatransport/runtime/TransportContext;J)V", "GetRecordNextCallTime_Lcom_google_android_datatransport_runtime_TransportContext_JHandler")]
		public unsafe virtual void RecordNextCallTime(TransportContext transportContext, long timestampMs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(transportContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(timestampMs);
				_members.InstanceMethods.InvokeVirtualVoidMethod("recordNextCallTime.(Lcom/google/android/datatransport/runtime/TransportContext;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(transportContext);
			}
		}

		private static Delegate GetRecordSuccess_Ljava_lang_Iterable_Handler()
		{
			if ((object)cb_recordSuccess_Ljava_lang_Iterable_ == null)
			{
				cb_recordSuccess_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RecordSuccess_Ljava_lang_Iterable_));
			}
			return cb_recordSuccess_Ljava_lang_Iterable_;
		}

		private static void n_RecordSuccess_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_events)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIterable events = Java.Lang.Object.GetObject<IIterable>(native_events, JniHandleOwnership.DoNotTransfer);
			sQLiteEventStore.RecordSuccess(events);
		}

		[Register("recordSuccess", "(Ljava/lang/Iterable;)V", "GetRecordSuccess_Ljava_lang_Iterable_Handler")]
		public unsafe virtual void RecordSuccess(IIterable events)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((events == null) ? IntPtr.Zero : ((Java.Lang.Object)events).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("recordSuccess.(Ljava/lang/Iterable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(events);
			}
		}

		private static Delegate GetRunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_Handler()
		{
			if ((object)cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ == null)
			{
				cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_));
			}
			return cb_runCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_;
		}

		private static IntPtr n_RunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_(IntPtr jnienv, IntPtr native__this, IntPtr native_criticalSection)
		{
			SQLiteEventStore sQLiteEventStore = Java.Lang.Object.GetObject<SQLiteEventStore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISynchronizationGuardCriticalSection criticalSection = Java.Lang.Object.GetObject<ISynchronizationGuardCriticalSection>(native_criticalSection, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sQLiteEventStore.RunCriticalSection(criticalSection));
		}

		[Register("runCriticalSection", "(Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection;)Ljava/lang/Object;", "GetRunCriticalSection_Lcom_google_android_datatransport_runtime_synchronization_SynchronizationGuard_CriticalSection_Handler")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe virtual Java.Lang.Object RunCriticalSection(ISynchronizationGuardCriticalSection criticalSection)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((criticalSection == null) ? IntPtr.Zero : ((Java.Lang.Object)criticalSection).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("runCriticalSection.(Lcom/google/android/datatransport/runtime/synchronization/SynchronizationGuard$CriticalSection;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(criticalSection);
			}
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Logging
{
	[Register("com/google/android/datatransport/runtime/logging/Logging", DoNotGenerateAcw = true)]
	public sealed class Logging : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/logging/Logging", typeof(Logging));

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

		internal Logging(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("d", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void D(string tag, string message)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("d", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe static void D(string tag, string message, Java.Lang.Object arg1)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(arg1?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(arg1);
			}
		}

		[Register("d", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", "")]
		public unsafe static void D(string tag, string message, Java.Lang.Object arg1, Java.Lang.Object arg2)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(arg1?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(arg2?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(arg1);
				GC.KeepAlive(arg2);
			}
		}

		[Register("d", "(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void D(string tag, string message, params Java.Lang.Object[] args)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			IntPtr intPtr3 = JNIEnv.NewArray(args);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(intPtr3);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/String;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				if (args != null)
				{
					JNIEnv.CopyArray(intPtr3, args);
					JNIEnv.DeleteLocalRef(intPtr3);
				}
				GC.KeepAlive(args);
			}
		}

		[Register("e", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe static void E(string tag, string message, Throwable e)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("e.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(e);
			}
		}

		[Register("i", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void I(string tag, string message)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("i.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("w", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe static void W(string tag, string message, Java.Lang.Object arg1)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			IntPtr intPtr2 = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(arg1?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("w.(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(arg1);
			}
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Dagger
{
	[Annotation("com.google.android.datatransport.runtime.dagger.Binds")]
	public class BindsAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.BindsInstance")]
	public class BindsInstanceAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.BindsOptionalOf")]
	public class BindsOptionalOfAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.Component")]
	public class ComponentAttribute : Attribute
	{
		[Register("dependencies")]
		public Class[] Dependencies { get; set; }

		[Register("modules")]
		public Class[] Modules { get; set; }
	}
	[Register("com/google/android/datatransport/runtime/dagger/Binds", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IBindsInvoker")]
	public interface IBinds : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Binds", DoNotGenerateAcw = true)]
	internal class IBindsInvoker : Java.Lang.Object, IBinds, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Binds", typeof(IBindsInvoker));

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

		public static IBinds GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBinds>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Binds'.");
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

		public IBindsInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IBinds binds = Java.Lang.Object.GetObject<IBinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return binds.Equals(obj);
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
			return Java.Lang.Object.GetObject<IBinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/BindsInstance", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IBindsInstanceInvoker")]
	public interface IBindsInstance : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/BindsInstance", DoNotGenerateAcw = true)]
	internal class IBindsInstanceInvoker : Java.Lang.Object, IBindsInstance, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/BindsInstance", typeof(IBindsInstanceInvoker));

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

		public static IBindsInstance GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBindsInstance>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.BindsInstance'.");
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

		public IBindsInstanceInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBindsInstance>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IBindsInstance bindsInstance = Java.Lang.Object.GetObject<IBindsInstance>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return bindsInstance.Equals(obj);
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
			return Java.Lang.Object.GetObject<IBindsInstance>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBindsInstance>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/BindsOptionalOf", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IBindsOptionalOfInvoker")]
	public interface IBindsOptionalOf : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/BindsOptionalOf", DoNotGenerateAcw = true)]
	internal class IBindsOptionalOfInvoker : Java.Lang.Object, IBindsOptionalOf, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/BindsOptionalOf", typeof(IBindsOptionalOfInvoker));

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

		public static IBindsOptionalOf GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBindsOptionalOf>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.BindsOptionalOf'.");
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

		public IBindsOptionalOfInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBindsOptionalOf>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IBindsOptionalOf bindsOptionalOf = Java.Lang.Object.GetObject<IBindsOptionalOf>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return bindsOptionalOf.Equals(obj);
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
			return Java.Lang.Object.GetObject<IBindsOptionalOf>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBindsOptionalOf>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Component$Builder", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IComponentBuilderInvoker")]
	public interface IComponentBuilder : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Component$Builder", DoNotGenerateAcw = true)]
	internal class IComponentBuilderInvoker : Java.Lang.Object, IComponentBuilder, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Component$Builder", typeof(IComponentBuilderInvoker));

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

		public static IComponentBuilder GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IComponentBuilder>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Component.Builder'.");
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

		public IComponentBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IComponentBuilder componentBuilder = Java.Lang.Object.GetObject<IComponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return componentBuilder.Equals(obj);
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
			return Java.Lang.Object.GetObject<IComponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IComponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Component$Factory", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IComponentFactoryInvoker")]
	public interface IComponentFactory : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Component$Factory", DoNotGenerateAcw = true)]
	internal class IComponentFactoryInvoker : Java.Lang.Object, IComponentFactory, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Component$Factory", typeof(IComponentFactoryInvoker));

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

		public static IComponentFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IComponentFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Component.Factory'.");
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

		public IComponentFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IComponentFactory componentFactory = Java.Lang.Object.GetObject<IComponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return componentFactory.Equals(obj);
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
			return Java.Lang.Object.GetObject<IComponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IComponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Component", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IComponentInvoker")]
	public interface IComponent : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("dependencies", "()[Ljava/lang/Class;", "GetDependenciesHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IComponentInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class[] Dependencies();

		[Register("modules", "()[Ljava/lang/Class;", "GetModulesHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IComponentInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class[] Modules();
	}
	[Register("com/google/android/datatransport/runtime/dagger/Component", DoNotGenerateAcw = true)]
	internal class IComponentInvoker : Java.Lang.Object, IComponent, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Component", typeof(IComponentInvoker));

		private IntPtr class_ref;

		private static Delegate cb_dependencies;

		private IntPtr id_dependencies;

		private static Delegate cb_modules;

		private IntPtr id_modules;

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

		public static IComponent GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IComponent>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Component'.");
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

		public IComponentInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDependenciesHandler()
		{
			if ((object)cb_dependencies == null)
			{
				cb_dependencies = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Dependencies));
			}
			return cb_dependencies;
		}

		private static IntPtr n_Dependencies(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dependencies());
		}

		public Class[] Dependencies()
		{
			if (id_dependencies == IntPtr.Zero)
			{
				id_dependencies = JNIEnv.GetMethodID(class_ref, "dependencies", "()[Ljava/lang/Class;");
			}
			return (Class[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_dependencies), JniHandleOwnership.TransferLocalRef, typeof(Class));
		}

		private static Delegate GetModulesHandler()
		{
			if ((object)cb_modules == null)
			{
				cb_modules = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Modules));
			}
			return cb_modules;
		}

		private static IntPtr n_Modules(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Modules());
		}

		public Class[] Modules()
		{
			if (id_modules == IntPtr.Zero)
			{
				id_modules = JNIEnv.GetMethodID(class_ref, "modules", "()[Ljava/lang/Class;");
			}
			return (Class[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_modules), JniHandleOwnership.TransferLocalRef, typeof(Class));
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IComponent component = Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return component.Equals(obj);
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
			return Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IComponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Lazy", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.ILazyInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ILazy : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("get", "()Ljava/lang/Object;", "GetGetHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.ILazyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Java.Lang.Object Get();
	}
	[Register("com/google/android/datatransport/runtime/dagger/Lazy", DoNotGenerateAcw = true)]
	internal class ILazyInvoker : Java.Lang.Object, ILazy, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Lazy", typeof(ILazyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_get;

		private IntPtr id_get;

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

		public static ILazy GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILazy>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Lazy'.");
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

		public ILazyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetHandler()
		{
			if ((object)cb_get == null)
			{
				cb_get = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Get));
			}
			return cb_get;
		}

		private static IntPtr n_Get(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILazy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
		}

		public Java.Lang.Object Get()
		{
			if (id_get == IntPtr.Zero)
			{
				id_get = JNIEnv.GetMethodID(class_ref, "get", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/MapKey", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IMapKeyInvoker")]
	public interface IMapKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("unwrapValue", "()Z", "GetUnwrapValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IMapKeyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		bool UnwrapValue();
	}
	[Register("com/google/android/datatransport/runtime/dagger/MapKey", DoNotGenerateAcw = true)]
	internal class IMapKeyInvoker : Java.Lang.Object, IMapKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/MapKey", typeof(IMapKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_unwrapValue;

		private IntPtr id_unwrapValue;

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

		public static IMapKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMapKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.MapKey'.");
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

		public IMapKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUnwrapValueHandler()
		{
			if ((object)cb_unwrapValue == null)
			{
				cb_unwrapValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_UnwrapValue));
			}
			return cb_unwrapValue;
		}

		private static bool n_UnwrapValue(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IMapKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UnwrapValue();
		}

		public bool UnwrapValue()
		{
			if (id_unwrapValue == IntPtr.Zero)
			{
				id_unwrapValue = JNIEnv.GetMethodID(class_ref, "unwrapValue", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_unwrapValue);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IMapKey mapKey = Java.Lang.Object.GetObject<IMapKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return mapKey.Equals(obj);
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
			return Java.Lang.Object.GetObject<IMapKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMapKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/MembersInjector", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IMembersInjectorInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IMembersInjector : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("injectMembers", "(Ljava/lang/Object;)V", "GetInjectMembers_Ljava_lang_Object_Handler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IMembersInjectorInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		void InjectMembers(Java.Lang.Object p0);
	}
	[Register("com/google/android/datatransport/runtime/dagger/MembersInjector", DoNotGenerateAcw = true)]
	internal class IMembersInjectorInvoker : Java.Lang.Object, IMembersInjector, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/MembersInjector", typeof(IMembersInjectorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_injectMembers_Ljava_lang_Object_;

		private IntPtr id_injectMembers_Ljava_lang_Object_;

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

		public static IMembersInjector GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMembersInjector>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.MembersInjector'.");
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

		public IMembersInjectorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetInjectMembers_Ljava_lang_Object_Handler()
		{
			if ((object)cb_injectMembers_Ljava_lang_Object_ == null)
			{
				cb_injectMembers_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_InjectMembers_Ljava_lang_Object_));
			}
			return cb_injectMembers_Ljava_lang_Object_;
		}

		private static void n_InjectMembers_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IMembersInjector membersInjector = Java.Lang.Object.GetObject<IMembersInjector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			membersInjector.InjectMembers(p);
		}

		public unsafe void InjectMembers(Java.Lang.Object p0)
		{
			if (id_injectMembers_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_injectMembers_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "injectMembers", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_injectMembers_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/Module", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IModuleInvoker")]
	public interface IModule : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("includes", "()[Ljava/lang/Class;", "GetIncludesHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IModuleInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class[] Includes();

		[Register("subcomponents", "()[Ljava/lang/Class;", "GetSubcomponentsHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.IModuleInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class[] Subcomponents();
	}
	[Register("com/google/android/datatransport/runtime/dagger/Module", DoNotGenerateAcw = true)]
	internal class IModuleInvoker : Java.Lang.Object, IModule, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Module", typeof(IModuleInvoker));

		private IntPtr class_ref;

		private static Delegate cb_includes;

		private IntPtr id_includes;

		private static Delegate cb_subcomponents;

		private IntPtr id_subcomponents;

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

		public static IModule GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IModule>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Module'.");
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

		public IModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIncludesHandler()
		{
			if ((object)cb_includes == null)
			{
				cb_includes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Includes));
			}
			return cb_includes;
		}

		private static IntPtr n_Includes(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Includes());
		}

		public Class[] Includes()
		{
			if (id_includes == IntPtr.Zero)
			{
				id_includes = JNIEnv.GetMethodID(class_ref, "includes", "()[Ljava/lang/Class;");
			}
			return (Class[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_includes), JniHandleOwnership.TransferLocalRef, typeof(Class));
		}

		private static Delegate GetSubcomponentsHandler()
		{
			if ((object)cb_subcomponents == null)
			{
				cb_subcomponents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Subcomponents));
			}
			return cb_subcomponents;
		}

		private static IntPtr n_Subcomponents(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Subcomponents());
		}

		public Class[] Subcomponents()
		{
			if (id_subcomponents == IntPtr.Zero)
			{
				id_subcomponents = JNIEnv.GetMethodID(class_ref, "subcomponents", "()[Ljava/lang/Class;");
			}
			return (Class[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_subcomponents), JniHandleOwnership.TransferLocalRef, typeof(Class));
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IModule module = Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return module.Equals(obj);
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
			return Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IModule>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Provides", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IProvidesInvoker")]
	public interface IProvides : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Provides", DoNotGenerateAcw = true)]
	internal class IProvidesInvoker : Java.Lang.Object, IProvides, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Provides", typeof(IProvidesInvoker));

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

		public static IProvides GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IProvides>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Provides'.");
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

		public IProvidesInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IProvides>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IProvides provides = Java.Lang.Object.GetObject<IProvides>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return provides.Equals(obj);
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
			return Java.Lang.Object.GetObject<IProvides>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IProvides>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Reusable", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.IReusableInvoker")]
	public interface IReusable : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Reusable", DoNotGenerateAcw = true)]
	internal class IReusableInvoker : Java.Lang.Object, IReusable, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Reusable", typeof(IReusableInvoker));

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

		public static IReusable GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IReusable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Reusable'.");
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

		public IReusableInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IReusable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IReusable reusable = Java.Lang.Object.GetObject<IReusable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return reusable.Equals(obj);
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
			return Java.Lang.Object.GetObject<IReusable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IReusable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent$Builder", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.ISubcomponentBuilderInvoker")]
	public interface ISubcomponentBuilder : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent$Builder", DoNotGenerateAcw = true)]
	internal class ISubcomponentBuilderInvoker : Java.Lang.Object, ISubcomponentBuilder, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Subcomponent$Builder", typeof(ISubcomponentBuilderInvoker));

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

		public static ISubcomponentBuilder GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISubcomponentBuilder>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Subcomponent.Builder'.");
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

		public ISubcomponentBuilderInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubcomponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ISubcomponentBuilder subcomponentBuilder = Java.Lang.Object.GetObject<ISubcomponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return subcomponentBuilder.Equals(obj);
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
			return Java.Lang.Object.GetObject<ISubcomponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISubcomponentBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent$Factory", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.ISubcomponentFactoryInvoker")]
	public interface ISubcomponentFactory : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent$Factory", DoNotGenerateAcw = true)]
	internal class ISubcomponentFactoryInvoker : Java.Lang.Object, ISubcomponentFactory, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Subcomponent$Factory", typeof(ISubcomponentFactoryInvoker));

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

		public static ISubcomponentFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISubcomponentFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Subcomponent.Factory'.");
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

		public ISubcomponentFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubcomponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ISubcomponentFactory subcomponentFactory = Java.Lang.Object.GetObject<ISubcomponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return subcomponentFactory.Equals(obj);
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
			return Java.Lang.Object.GetObject<ISubcomponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISubcomponentFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.ISubcomponentInvoker")]
	public interface ISubcomponent : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("modules", "()[Ljava/lang/Class;", "GetModulesHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.ISubcomponentInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class[] Modules();
	}
	[Register("com/google/android/datatransport/runtime/dagger/Subcomponent", DoNotGenerateAcw = true)]
	internal class ISubcomponentInvoker : Java.Lang.Object, ISubcomponent, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/Subcomponent", typeof(ISubcomponentInvoker));

		private IntPtr class_ref;

		private static Delegate cb_modules;

		private IntPtr id_modules;

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

		public static ISubcomponent GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISubcomponent>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.Subcomponent'.");
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

		public ISubcomponentInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetModulesHandler()
		{
			if ((object)cb_modules == null)
			{
				cb_modules = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Modules));
			}
			return cb_modules;
		}

		private static IntPtr n_Modules(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISubcomponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Modules());
		}

		public Class[] Modules()
		{
			if (id_modules == IntPtr.Zero)
			{
				id_modules = JNIEnv.GetMethodID(class_ref, "modules", "()[Ljava/lang/Class;");
			}
			return (Class[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_modules), JniHandleOwnership.TransferLocalRef, typeof(Class));
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubcomponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ISubcomponent subcomponent = Java.Lang.Object.GetObject<ISubcomponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return subcomponent.Equals(obj);
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
			return Java.Lang.Object.GetObject<ISubcomponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISubcomponent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.android.datatransport.runtime.dagger.MapKey")]
	public class MapKeyAttribute : Attribute
	{
		[Register("unwrapValue")]
		public bool UnwrapValue { get; set; }
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.Module")]
	public class ModuleAttribute : Attribute
	{
		[Register("includes")]
		public Class[] Includes { get; set; }

		[Register("subcomponents")]
		public Class[] Subcomponents { get; set; }
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.Provides")]
	public class ProvidesAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.Reusable")]
	public class ReusableAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.Subcomponent")]
	public class SubcomponentAttribute : Attribute
	{
		[Register("modules")]
		public Class[] Modules { get; set; }
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings
{
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.ClassKey")]
	public class ClassKeyAttribute : Attribute
	{
		[Register("value")]
		public Class Value { get; set; }
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.ElementsIntoSet")]
	public class ElementsIntoSetAttribute : Attribute
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/ClassKey", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IClassKeyInvoker")]
	public interface IClassKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/Class;", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IClassKeyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/ClassKey", DoNotGenerateAcw = true)]
	internal class IClassKeyInvoker : Java.Lang.Object, IClassKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/ClassKey", typeof(IClassKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static IClassKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IClassKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.ClassKey'.");
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

		public IClassKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IClassKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public Class Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IClassKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IClassKey classKey = Java.Lang.Object.GetObject<IClassKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return classKey.Equals(obj);
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
			return Java.Lang.Object.GetObject<IClassKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IClassKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/ElementsIntoSet", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IElementsIntoSetInvoker")]
	public interface IElementsIntoSet : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/ElementsIntoSet", DoNotGenerateAcw = true)]
	internal class IElementsIntoSetInvoker : Java.Lang.Object, IElementsIntoSet, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/ElementsIntoSet", typeof(IElementsIntoSetInvoker));

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

		public static IElementsIntoSet GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IElementsIntoSet>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.ElementsIntoSet'.");
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

		public IElementsIntoSetInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IElementsIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IElementsIntoSet elementsIntoSet = Java.Lang.Object.GetObject<IElementsIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return elementsIntoSet.Equals(obj);
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
			return Java.Lang.Object.GetObject<IElementsIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IElementsIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntKey", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IIntKeyInvoker")]
	public interface IIntKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()I", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IIntKeyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		int Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntKey", DoNotGenerateAcw = true)]
	internal class IIntKeyInvoker : Java.Lang.Object, IIntKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/IntKey", typeof(IIntKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static IIntKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IIntKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.IntKey'.");
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

		public IIntKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Value));
			}
			return cb_value;
		}

		private static int n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IIntKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value();
		}

		public int Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_value);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIntKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IIntKey intKey = Java.Lang.Object.GetObject<IIntKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return intKey.Equals(obj);
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
			return Java.Lang.Object.GetObject<IIntKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IIntKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntoMap", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IIntoMapInvoker")]
	public interface IIntoMap : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntoMap", DoNotGenerateAcw = true)]
	internal class IIntoMapInvoker : Java.Lang.Object, IIntoMap, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/IntoMap", typeof(IIntoMapInvoker));

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

		public static IIntoMap GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IIntoMap>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.IntoMap'.");
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

		public IIntoMapInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIntoMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IIntoMap intoMap = Java.Lang.Object.GetObject<IIntoMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return intoMap.Equals(obj);
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
			return Java.Lang.Object.GetObject<IIntoMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IIntoMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntoSet", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IIntoSetInvoker")]
	public interface IIntoSet : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/IntoSet", DoNotGenerateAcw = true)]
	internal class IIntoSetInvoker : Java.Lang.Object, IIntoSet, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/IntoSet", typeof(IIntoSetInvoker));

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

		public static IIntoSet GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IIntoSet>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.IntoSet'.");
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

		public IIntoSetInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IIntoSet intoSet = Java.Lang.Object.GetObject<IIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return intoSet.Equals(obj);
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
			return Java.Lang.Object.GetObject<IIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IIntoSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/LongKey", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.ILongKeyInvoker")]
	public interface ILongKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()J", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.ILongKeyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		long Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/LongKey", DoNotGenerateAcw = true)]
	internal class ILongKeyInvoker : Java.Lang.Object, ILongKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/LongKey", typeof(ILongKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static ILongKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILongKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.LongKey'.");
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

		public ILongKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_Value));
			}
			return cb_value;
		}

		private static long n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ILongKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value();
		}

		public long Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_value);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILongKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ILongKey longKey = Java.Lang.Object.GetObject<ILongKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return longKey.Equals(obj);
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
			return Java.Lang.Object.GetObject<ILongKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ILongKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/Multibinds", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IMultibindsInvoker")]
	public interface IMultibinds : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/Multibinds", DoNotGenerateAcw = true)]
	internal class IMultibindsInvoker : Java.Lang.Object, IMultibinds, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/Multibinds", typeof(IMultibindsInvoker));

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

		public static IMultibinds GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMultibinds>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.Multibinds'.");
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

		public IMultibindsInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMultibinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IMultibinds multibinds = Java.Lang.Object.GetObject<IMultibinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return multibinds.Equals(obj);
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
			return Java.Lang.Object.GetObject<IMultibinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMultibinds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.IntKey")]
	public class IntKeyAttribute : Attribute
	{
		[Register("value")]
		public int Value { get; set; }
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.IntoMap")]
	public class IntoMapAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.IntoSet")]
	public class IntoSetAttribute : Attribute
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/StringKey", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IStringKeyInvoker")]
	public interface IStringKey : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.MultiBindings.IStringKeyInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		string Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/multibindings/StringKey", DoNotGenerateAcw = true)]
	internal class IStringKeyInvoker : Java.Lang.Object, IStringKey, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/multibindings/StringKey", typeof(IStringKeyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static IStringKey GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStringKey>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.multibindings.StringKey'.");
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

		public IStringKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IStringKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IStringKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IStringKey stringKey = Java.Lang.Object.GetObject<IStringKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return stringKey.Equals(obj);
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
			return Java.Lang.Object.GetObject<IStringKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IStringKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.LongKey")]
	public class LongKeyAttribute : Attribute
	{
		[Register("value")]
		public long Value { get; set; }
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.Multibinds")]
	public class MultibindsAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.multibindings.StringKey")]
	public class StringKeyAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal
{
	[Annotation("com.google.android.datatransport.runtime.dagger.internal.Beta")]
	public class BetaAttribute : Attribute
	{
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.internal.ComponentDefinitionType")]
	public class ComponentDefinitionTypeAttribute : Attribute
	{
		[Register("value")]
		public Class Value { get; set; }
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/DaggerCollections", DoNotGenerateAcw = true)]
	public sealed class DaggerCollections : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/DaggerCollections", typeof(DaggerCollections));

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

		internal DaggerCollections(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("hasDuplicates", "(Ljava/util/List;)Z", "")]
		public unsafe static bool HasDuplicates(IList<object> list)
		{
			IntPtr intPtr = JavaList<object>.ToLocalJniHandle(list);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("hasDuplicates.(Ljava/util/List;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(list);
			}
		}

		[Register("newLinkedHashMapWithExpectedSize", "(I)Ljava/util/LinkedHashMap;", "")]
		[JavaTypeParameters(new string[] { "K", "V" })]
		public unsafe static LinkedHashMap NewLinkedHashMapWithExpectedSize(int expectedSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(expectedSize);
			return Java.Lang.Object.GetObject<LinkedHashMap>(_members.StaticMethods.InvokeObjectMethod("newLinkedHashMapWithExpectedSize.(I)Ljava/util/LinkedHashMap;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("presizedList", "(I)Ljava/util/List;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static System.Collections.IList PresizedList(int size)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(size);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("presizedList.(I)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Annotation("com.google.android.datatransport.runtime.dagger.internal.GwtIncompatible")]
	public class GwtIncompatibleAttribute : Attribute
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/Beta", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IBetaInvoker")]
	public interface IBeta : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/Beta", DoNotGenerateAcw = true)]
	internal class IBetaInvoker : Java.Lang.Object, IBeta, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/Beta", typeof(IBetaInvoker));

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

		public static IBeta GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBeta>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.internal.Beta'.");
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

		public IBetaInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBeta>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IBeta beta = Java.Lang.Object.GetObject<IBeta>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return beta.Equals(obj);
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
			return Java.Lang.Object.GetObject<IBeta>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBeta>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/internal/ComponentDefinitionType", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IComponentDefinitionTypeInvoker")]
	public interface IComponentDefinitionType : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/Class;", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IComponentDefinitionTypeInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		Class Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/ComponentDefinitionType", DoNotGenerateAcw = true)]
	internal class IComponentDefinitionTypeInvoker : Java.Lang.Object, IComponentDefinitionType, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/ComponentDefinitionType", typeof(IComponentDefinitionTypeInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static IComponentDefinitionType GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IComponentDefinitionType>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.internal.ComponentDefinitionType'.");
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

		public IComponentDefinitionTypeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComponentDefinitionType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public Class Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IComponentDefinitionType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IComponentDefinitionType componentDefinitionType = Java.Lang.Object.GetObject<IComponentDefinitionType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return componentDefinitionType.Equals(obj);
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
			return Java.Lang.Object.GetObject<IComponentDefinitionType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IComponentDefinitionType>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/internal/GwtIncompatible", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IGwtIncompatibleInvoker")]
	public interface IGwtIncompatible : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/GwtIncompatible", DoNotGenerateAcw = true)]
	internal class IGwtIncompatibleInvoker : Java.Lang.Object, IGwtIncompatible, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/GwtIncompatible", typeof(IGwtIncompatibleInvoker));

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

		public static IGwtIncompatible GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IGwtIncompatible>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.internal.GwtIncompatible'.");
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

		public IGwtIncompatibleInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IGwtIncompatible>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IGwtIncompatible gwtIncompatible = Java.Lang.Object.GetObject<IGwtIncompatible>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return gwtIncompatible.Equals(obj);
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
			return Java.Lang.Object.GetObject<IGwtIncompatible>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IGwtIncompatible>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("com/google/android/datatransport/runtime/dagger/internal/InjectedFieldSignature", "", "Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IInjectedFieldSignatureInvoker")]
	public interface IInjectedFieldSignature : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.IInjectedFieldSignatureInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		string Value();
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/InjectedFieldSignature", DoNotGenerateAcw = true)]
	internal class IInjectedFieldSignatureInvoker : Java.Lang.Object, IInjectedFieldSignature, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/InjectedFieldSignature", typeof(IInjectedFieldSignatureInvoker));

		private IntPtr class_ref;

		private static Delegate cb_value;

		private IntPtr id_value;

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

		public static IInjectedFieldSignature GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInjectedFieldSignature>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.dagger.internal.InjectedFieldSignature'.");
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

		public IInjectedFieldSignatureInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetValueHandler()
		{
			if ((object)cb_value == null)
			{
				cb_value = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Value));
			}
			return cb_value;
		}

		private static IntPtr n_Value(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IInjectedFieldSignature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInjectedFieldSignature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IInjectedFieldSignature injectedFieldSignature = Java.Lang.Object.GetObject<IInjectedFieldSignature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return injectedFieldSignature.Equals(obj);
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
			return Java.Lang.Object.GetObject<IInjectedFieldSignature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IInjectedFieldSignature>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("com.google.android.datatransport.runtime.dagger.internal.InjectedFieldSignature")]
	public class InjectedFieldSignatureAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/MapBuilder", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "K", "V" })]
	public sealed class MapBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/MapBuilder", typeof(MapBuilder));

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

		internal MapBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("build", "()Ljava/util/Map;", "")]
		public unsafe IDictionary Build()
		{
			return JavaDictionary.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newMapBuilder", "(I)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", "")]
		[JavaTypeParameters(new string[] { "K", "V" })]
		public unsafe static MapBuilder NewMapBuilder(int size)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(size);
			return Java.Lang.Object.GetObject<MapBuilder>(_members.StaticMethods.InvokeObjectMethod("newMapBuilder.(I)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("put", "(Ljava/lang/Object;Ljava/lang/Object;)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", "")]
		public unsafe MapBuilder Put(Java.Lang.Object key, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(key);
			IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<MapBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("put.(Ljava/lang/Object;Ljava/lang/Object;)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(key);
				GC.KeepAlive(value);
			}
		}

		[Register("putAll", "(Ljava/util/Map;)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", "")]
		public unsafe MapBuilder PutAll(IDictionary map)
		{
			IntPtr intPtr = JavaDictionary.ToLocalJniHandle(map);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MapBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("putAll.(Ljava/util/Map;)Lcom/google/android/datatransport/runtime/dagger/internal/MapBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(map);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/MembersInjectors", DoNotGenerateAcw = true)]
	public sealed class MembersInjectors : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/MembersInjectors", typeof(MembersInjectors));

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

		internal MembersInjectors(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("noOp", "()Lcom/google/android/datatransport/runtime/dagger/MembersInjector;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IMembersInjector NoOp()
		{
			return Java.Lang.Object.GetObject<IMembersInjector>(_members.StaticMethods.InvokeObjectMethod("noOp.()Lcom/google/android/datatransport/runtime/dagger/MembersInjector;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/MemoizedSentinel", DoNotGenerateAcw = true)]
	public sealed class MemoizedSentinel : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/MemoizedSentinel", typeof(MemoizedSentinel));

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

		internal MemoizedSentinel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MemoizedSentinel()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/Preconditions", DoNotGenerateAcw = true)]
	public sealed class Preconditions : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/Preconditions", typeof(Preconditions));

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

		internal Preconditions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("checkBuilderRequirement", "(Ljava/lang/Object;Ljava/lang/Class;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void CheckBuilderRequirement(Java.Lang.Object requirement, Class clazz)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(requirement);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(clazz?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("checkBuilderRequirement.(Ljava/lang/Object;Ljava/lang/Class;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(requirement);
				GC.KeepAlive(clazz);
			}
		}

		[Register("checkNotNull", "(Ljava/lang/Object;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object CheckNotNull(Java.Lang.Object reference)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(reference);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("checkNotNull.(Ljava/lang/Object;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(reference);
			}
		}

		[Register("checkNotNull", "(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object CheckNotNull(Java.Lang.Object reference, string errorMessage)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(reference);
			IntPtr intPtr2 = JNIEnv.NewString(errorMessage);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("checkNotNull.(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(reference);
			}
		}

		[Register("checkNotNull", "(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object CheckNotNull(Java.Lang.Object reference, string errorMessageTemplate, Java.Lang.Object errorMessageArg)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(reference);
			IntPtr intPtr2 = JNIEnv.NewString(errorMessageTemplate);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(errorMessageArg?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("checkNotNull.(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(reference);
				GC.KeepAlive(errorMessageArg);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/dagger/internal/SetBuilder", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public sealed class SetBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/dagger/internal/SetBuilder", typeof(SetBuilder));

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

		internal SetBuilder(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("add", "(Ljava/lang/Object;)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", "")]
		public unsafe SetBuilder Add(Java.Lang.Object t)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(t);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SetBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/Object;)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(t);
			}
		}

		[Register("addAll", "(Ljava/util/Collection;)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", "")]
		public unsafe SetBuilder AddAll(System.Collections.ICollection collection)
		{
			IntPtr intPtr = JavaCollection.ToLocalJniHandle(collection);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SetBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addAll.(Ljava/util/Collection;)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(collection);
			}
		}

		[Register("build", "()Ljava/util/Set;", "")]
		public unsafe System.Collections.ICollection Build()
		{
			return JavaSet.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newSetBuilder", "(I)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static SetBuilder NewSetBuilder(int estimatedSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(estimatedSize);
			return Java.Lang.Object.GetObject<SetBuilder>(_members.StaticMethods.InvokeObjectMethod("newSetBuilder.(I)Lcom/google/android/datatransport/runtime/dagger/internal/SetBuilder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Xamarin.Google.Android.DataTransport.Runtime.Backends
{
	[Register("com/google/android/datatransport/runtime/backends/BackendRegistryModule", DoNotGenerateAcw = true)]
	public abstract class BackendRegistryModule : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRegistryModule", typeof(BackendRegistryModule));

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

		protected BackendRegistryModule(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BackendRegistryModule()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendRegistryModule", DoNotGenerateAcw = true)]
	internal class BackendRegistryModuleInvoker : BackendRegistryModule
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRegistryModule", typeof(BackendRegistryModuleInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public BackendRegistryModuleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendRequest", DoNotGenerateAcw = true)]
	public abstract class BackendRequest : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/runtime/backends/BackendRequest$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRequest$Builder", typeof(Builder));

			private static Delegate cb_build;

			private static Delegate cb_setEvents_Ljava_lang_Iterable_;

			private static Delegate cb_setExtras_arrayB;

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

			[Register("build", "()Lcom/google/android/datatransport/runtime/backends/BackendRequest;", "GetBuildHandler")]
			public abstract BackendRequest Build();

			private static Delegate GetSetEvents_Ljava_lang_Iterable_Handler()
			{
				if ((object)cb_setEvents_Ljava_lang_Iterable_ == null)
				{
					cb_setEvents_Ljava_lang_Iterable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetEvents_Ljava_lang_Iterable_));
				}
				return cb_setEvents_Ljava_lang_Iterable_;
			}

			private static IntPtr n_SetEvents_Ljava_lang_Iterable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IIterable events = Java.Lang.Object.GetObject<IIterable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetEvents(events));
			}

			[Register("setEvents", "(Ljava/lang/Iterable;)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", "GetSetEvents_Ljava_lang_Iterable_Handler")]
			public abstract Builder SetEvents(IIterable p0);

			private static Delegate GetSetExtras_arrayBHandler()
			{
				if ((object)cb_setExtras_arrayB == null)
				{
					cb_setExtras_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExtras_arrayB));
				}
				return cb_setExtras_arrayB;
			}

			private static IntPtr n_SetExtras_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Builder builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
				IntPtr result = JNIEnv.ToLocalJniHandle(builder.SetExtras(array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p0);
				}
				return result;
			}

			[Register("setExtras", "([B)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", "GetSetExtras_arrayBHandler")]
			public abstract Builder SetExtras(byte[] p0);
		}

		[Register("com/google/android/datatransport/runtime/backends/BackendRequest$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRequest$Builder", typeof(BuilderInvoker));

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

			[Register("build", "()Lcom/google/android/datatransport/runtime/backends/BackendRequest;", "GetBuildHandler")]
			public unsafe override BackendRequest Build()
			{
				return Java.Lang.Object.GetObject<BackendRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/datatransport/runtime/backends/BackendRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setEvents", "(Ljava/lang/Iterable;)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", "GetSetEvents_Ljava_lang_Iterable_Handler")]
			public unsafe override Builder SetEvents(IIterable p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEvents.(Ljava/lang/Iterable;)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setExtras", "([B)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", "GetSetExtras_arrayBHandler")]
			public unsafe override Builder SetExtras(byte[] p0)
			{
				IntPtr intPtr = JNIEnv.NewArray(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExtras.([B)Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRequest", typeof(BackendRequest));

		private static Delegate cb_getEvents;

		private static Delegate cb_getExtras;

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

		public abstract IIterable Events
		{
			[Register("getEvents", "()Ljava/lang/Iterable;", "GetGetEventsHandler")]
			get;
		}

		protected BackendRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BackendRequest()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetEventsHandler()
		{
			if ((object)cb_getEvents == null)
			{
				cb_getEvents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEvents));
			}
			return cb_getEvents;
		}

		private static IntPtr n_GetEvents(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BackendRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Events);
		}

		[Register("builder", "()Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/datatransport/runtime/backends/BackendRequest$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("create", "(Ljava/lang/Iterable;)Lcom/google/android/datatransport/runtime/backends/BackendRequest;", "")]
		public unsafe static BackendRequest Create(IIterable events)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((events == null) ? IntPtr.Zero : ((Java.Lang.Object)events).Handle);
				return Java.Lang.Object.GetObject<BackendRequest>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/Iterable;)Lcom/google/android/datatransport/runtime/backends/BackendRequest;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(events);
			}
		}

		private static Delegate GetGetExtrasHandler()
		{
			if ((object)cb_getExtras == null)
			{
				cb_getExtras = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtras));
			}
			return cb_getExtras;
		}

		private static IntPtr n_GetExtras(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<BackendRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetExtras());
		}

		[Register("getExtras", "()[B", "GetGetExtrasHandler")]
		public abstract byte[] GetExtras();
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendRequest", DoNotGenerateAcw = true)]
	internal class BackendRequestInvoker : BackendRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRequest", typeof(BackendRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IIterable Events
		{
			[Register("getEvents", "()Ljava/lang/Iterable;", "GetGetEventsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IIterable>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEvents.()Ljava/lang/Iterable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public BackendRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getExtras", "()[B", "GetGetExtrasHandler")]
		public unsafe override byte[] GetExtras()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getExtras.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendResponse", DoNotGenerateAcw = true)]
	public abstract class BackendResponse : Java.Lang.Object
	{
		[Register("com/google/android/datatransport/runtime/backends/BackendResponse$Status", DoNotGenerateAcw = true)]
		public sealed class Status : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendResponse$Status", typeof(Status));

			[Register("FATAL_ERROR")]
			public static Status FatalError => Java.Lang.Object.GetObject<Status>(_members.StaticFields.GetObjectValue("FATAL_ERROR.Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("OK")]
			public static Status Ok => Java.Lang.Object.GetObject<Status>(_members.StaticFields.GetObjectValue("OK.Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("TRANSIENT_ERROR")]
			public static Status TransientError => Java.Lang.Object.GetObject<Status>(_members.StaticFields.GetObjectValue("TRANSIENT_ERROR.Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal Status(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", "")]
			public unsafe static Status ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Status>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", "")]
			public unsafe static Status[] Values()
			{
				return (Status[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Status));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendResponse", typeof(BackendResponse));

		private static Delegate cb_getNextRequestWaitMillis;

		private static Delegate cb_getStatus;

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

		protected BackendResponse(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BackendResponse()
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
			return Java.Lang.Object.GetObject<BackendResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextRequestWaitMillis;
		}

		[Register("fatalError", "()Lcom/google/android/datatransport/runtime/backends/BackendResponse;", "")]
		public unsafe static BackendResponse FatalError()
		{
			return Java.Lang.Object.GetObject<BackendResponse>(_members.StaticMethods.InvokeObjectMethod("fatalError.()Lcom/google/android/datatransport/runtime/backends/BackendResponse;", null).Handle, JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BackendResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetStatus());
		}

		[Register("getStatus", "()Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", "GetGetStatusHandler")]
		public abstract Status GetStatus();

		[Register("ok", "(J)Lcom/google/android/datatransport/runtime/backends/BackendResponse;", "")]
		public unsafe static BackendResponse Ok(long nextRequestWaitMillis)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(nextRequestWaitMillis);
			return Java.Lang.Object.GetObject<BackendResponse>(_members.StaticMethods.InvokeObjectMethod("ok.(J)Lcom/google/android/datatransport/runtime/backends/BackendResponse;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("transientError", "()Lcom/google/android/datatransport/runtime/backends/BackendResponse;", "")]
		public unsafe static BackendResponse TransientError()
		{
			return Java.Lang.Object.GetObject<BackendResponse>(_members.StaticMethods.InvokeObjectMethod("transientError.()Lcom/google/android/datatransport/runtime/backends/BackendResponse;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendResponse", DoNotGenerateAcw = true)]
	internal class BackendResponseInvoker : BackendResponse
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendResponse", typeof(BackendResponseInvoker));

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

		public BackendResponseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getStatus", "()Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", "GetGetStatusHandler")]
		public unsafe override Status GetStatus()
		{
			return Java.Lang.Object.GetObject<Status>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStatus.()Lcom/google/android/datatransport/runtime/backends/BackendResponse$Status;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/CreationContext", DoNotGenerateAcw = true)]
	public abstract class CreationContext : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/CreationContext", typeof(CreationContext));

		private static Delegate cb_getApplicationContext;

		private static Delegate cb_getBackendName;

		private static Delegate cb_getMonotonicClock;

		private static Delegate cb_getWallClock;

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

		public abstract Context ApplicationContext
		{
			[Register("getApplicationContext", "()Landroid/content/Context;", "GetGetApplicationContextHandler")]
			get;
		}

		public abstract string BackendName
		{
			[Register("getBackendName", "()Ljava/lang/String;", "GetGetBackendNameHandler")]
			get;
		}

		public abstract IClock MonotonicClock
		{
			[Register("getMonotonicClock", "()Lcom/google/android/datatransport/runtime/time/Clock;", "GetGetMonotonicClockHandler")]
			get;
		}

		public abstract IClock WallClock
		{
			[Register("getWallClock", "()Lcom/google/android/datatransport/runtime/time/Clock;", "GetGetWallClockHandler")]
			get;
		}

		protected CreationContext(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CreationContext()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CreationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationContext);
		}

		private static Delegate GetGetBackendNameHandler()
		{
			if ((object)cb_getBackendName == null)
			{
				cb_getBackendName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBackendName));
			}
			return cb_getBackendName;
		}

		private static IntPtr n_GetBackendName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CreationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackendName);
		}

		private static Delegate GetGetMonotonicClockHandler()
		{
			if ((object)cb_getMonotonicClock == null)
			{
				cb_getMonotonicClock = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMonotonicClock));
			}
			return cb_getMonotonicClock;
		}

		private static IntPtr n_GetMonotonicClock(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CreationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MonotonicClock);
		}

		private static Delegate GetGetWallClockHandler()
		{
			if ((object)cb_getWallClock == null)
			{
				cb_getWallClock = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWallClock));
			}
			return cb_getWallClock;
		}

		private static IntPtr n_GetWallClock(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CreationContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WallClock);
		}

		[Register("create", "(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/backends/CreationContext;", "")]
		public unsafe static CreationContext Create(Context applicationContext, IClock wallClock, IClock monotonicClock)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((wallClock == null) ? IntPtr.Zero : ((Java.Lang.Object)wallClock).Handle);
				ptr[2] = new JniArgumentValue((monotonicClock == null) ? IntPtr.Zero : ((Java.Lang.Object)monotonicClock).Handle);
				return Java.Lang.Object.GetObject<CreationContext>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;)Lcom/google/android/datatransport/runtime/backends/CreationContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(applicationContext);
				GC.KeepAlive(wallClock);
				GC.KeepAlive(monotonicClock);
			}
		}

		[Register("create", "(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/CreationContext;", "")]
		public unsafe static CreationContext Create(Context applicationContext, IClock wallClock, IClock monotonicClock, string backendName)
		{
			IntPtr intPtr = JNIEnv.NewString(backendName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((wallClock == null) ? IntPtr.Zero : ((Java.Lang.Object)wallClock).Handle);
				ptr[2] = new JniArgumentValue((monotonicClock == null) ? IntPtr.Zero : ((Java.Lang.Object)monotonicClock).Handle);
				ptr[3] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CreationContext>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;Lcom/google/android/datatransport/runtime/time/Clock;Lcom/google/android/datatransport/runtime/time/Clock;Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/CreationContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(applicationContext);
				GC.KeepAlive(wallClock);
				GC.KeepAlive(monotonicClock);
			}
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/CreationContext", DoNotGenerateAcw = true)]
	internal class CreationContextInvoker : CreationContext
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/CreationContext", typeof(CreationContextInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Context ApplicationContext
		{
			[Register("getApplicationContext", "()Landroid/content/Context;", "GetGetApplicationContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override string BackendName
		{
			[Register("getBackendName", "()Ljava/lang/String;", "GetGetBackendNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getBackendName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IClock MonotonicClock
		{
			[Register("getMonotonicClock", "()Lcom/google/android/datatransport/runtime/time/Clock;", "GetGetMonotonicClockHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IClock>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMonotonicClock.()Lcom/google/android/datatransport/runtime/time/Clock;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IClock WallClock
		{
			[Register("getWallClock", "()Lcom/google/android/datatransport/runtime/time/Clock;", "GetGetWallClockHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IClock>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWallClock.()Lcom/google/android/datatransport/runtime/time/Clock;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public CreationContextInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendFactory", "", "Xamarin.Google.Android.DataTransport.Runtime.Backends.IBackendFactoryInvoker")]
	public interface IBackendFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("create", "(Lcom/google/android/datatransport/runtime/backends/CreationContext;)Lcom/google/android/datatransport/runtime/backends/TransportBackend;", "GetCreate_Lcom_google_android_datatransport_runtime_backends_CreationContext_Handler:Xamarin.Google.Android.DataTransport.Runtime.Backends.IBackendFactoryInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		ITransportBackend Create(CreationContext p0);
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendFactory", DoNotGenerateAcw = true)]
	internal class IBackendFactoryInvoker : Java.Lang.Object, IBackendFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendFactory", typeof(IBackendFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_;

		private IntPtr id_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_;

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

		public static IBackendFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBackendFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.backends.BackendFactory'.");
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

		public IBackendFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCreate_Lcom_google_android_datatransport_runtime_backends_CreationContext_Handler()
		{
			if ((object)cb_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_ == null)
			{
				cb_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Create_Lcom_google_android_datatransport_runtime_backends_CreationContext_));
			}
			return cb_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_;
		}

		private static IntPtr n_Create_Lcom_google_android_datatransport_runtime_backends_CreationContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBackendFactory backendFactory = Java.Lang.Object.GetObject<IBackendFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CreationContext p = Java.Lang.Object.GetObject<CreationContext>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(backendFactory.Create(p));
		}

		public unsafe ITransportBackend Create(CreationContext p0)
		{
			if (id_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_ == IntPtr.Zero)
			{
				id_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_ = JNIEnv.GetMethodID(class_ref, "create", "(Lcom/google/android/datatransport/runtime/backends/CreationContext;)Lcom/google/android/datatransport/runtime/backends/TransportBackend;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ITransportBackend>(JNIEnv.CallObjectMethod(base.Handle, id_create_Lcom_google_android_datatransport_runtime_backends_CreationContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendRegistry", "", "Xamarin.Google.Android.DataTransport.Runtime.Backends.IBackendRegistryInvoker")]
	public interface IBackendRegistry : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("get", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/TransportBackend;", "GetGet_Ljava_lang_String_Handler:Xamarin.Google.Android.DataTransport.Runtime.Backends.IBackendRegistryInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		ITransportBackend Get(string p0);
	}
	[Register("com/google/android/datatransport/runtime/backends/BackendRegistry", DoNotGenerateAcw = true)]
	internal class IBackendRegistryInvoker : Java.Lang.Object, IBackendRegistry, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/BackendRegistry", typeof(IBackendRegistryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_get_Ljava_lang_String_;

		private IntPtr id_get_Ljava_lang_String_;

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

		public static IBackendRegistry GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBackendRegistry>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.backends.BackendRegistry'.");
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

		public IBackendRegistryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGet_Ljava_lang_String_Handler()
		{
			if ((object)cb_get_Ljava_lang_String_ == null)
			{
				cb_get_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_String_));
			}
			return cb_get_Ljava_lang_String_;
		}

		private static IntPtr n_Get_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IBackendRegistry backendRegistry = Java.Lang.Object.GetObject<IBackendRegistry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(backendRegistry.Get(p));
		}

		public unsafe ITransportBackend Get(string p0)
		{
			if (id_get_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_get_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "get", "(Ljava/lang/String;)Lcom/google/android/datatransport/runtime/backends/TransportBackend;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			ITransportBackend result = Java.Lang.Object.GetObject<ITransportBackend>(JNIEnv.CallObjectMethod(base.Handle, id_get_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/TransportBackend", "", "Xamarin.Google.Android.DataTransport.Runtime.Backends.ITransportBackendInvoker")]
	public interface ITransportBackend : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("decorate", "(Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/EventInternal;", "GetDecorate_Lcom_google_android_datatransport_runtime_EventInternal_Handler:Xamarin.Google.Android.DataTransport.Runtime.Backends.ITransportBackendInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		EventInternal Decorate(EventInternal p0);

		[Register("send", "(Lcom/google/android/datatransport/runtime/backends/BackendRequest;)Lcom/google/android/datatransport/runtime/backends/BackendResponse;", "GetSend_Lcom_google_android_datatransport_runtime_backends_BackendRequest_Handler:Xamarin.Google.Android.DataTransport.Runtime.Backends.ITransportBackendInvoker, Xamarin.Google.Android.DataTransport.TransportRuntime")]
		BackendResponse Send(BackendRequest p0);
	}
	[Register("com/google/android/datatransport/runtime/backends/TransportBackend", DoNotGenerateAcw = true)]
	internal class ITransportBackendInvoker : Java.Lang.Object, ITransportBackend, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/TransportBackend", typeof(ITransportBackendInvoker));

		private IntPtr class_ref;

		private static Delegate cb_decorate_Lcom_google_android_datatransport_runtime_EventInternal_;

		private IntPtr id_decorate_Lcom_google_android_datatransport_runtime_EventInternal_;

		private static Delegate cb_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_;

		private IntPtr id_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_;

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

		public static ITransportBackend GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransportBackend>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.runtime.backends.TransportBackend'.");
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

		public ITransportBackendInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDecorate_Lcom_google_android_datatransport_runtime_EventInternal_Handler()
		{
			if ((object)cb_decorate_Lcom_google_android_datatransport_runtime_EventInternal_ == null)
			{
				cb_decorate_Lcom_google_android_datatransport_runtime_EventInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Decorate_Lcom_google_android_datatransport_runtime_EventInternal_));
			}
			return cb_decorate_Lcom_google_android_datatransport_runtime_EventInternal_;
		}

		private static IntPtr n_Decorate_Lcom_google_android_datatransport_runtime_EventInternal_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ITransportBackend transportBackend = Java.Lang.Object.GetObject<ITransportBackend>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EventInternal p = Java.Lang.Object.GetObject<EventInternal>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportBackend.Decorate(p));
		}

		public unsafe EventInternal Decorate(EventInternal p0)
		{
			if (id_decorate_Lcom_google_android_datatransport_runtime_EventInternal_ == IntPtr.Zero)
			{
				id_decorate_Lcom_google_android_datatransport_runtime_EventInternal_ = JNIEnv.GetMethodID(class_ref, "decorate", "(Lcom/google/android/datatransport/runtime/EventInternal;)Lcom/google/android/datatransport/runtime/EventInternal;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<EventInternal>(JNIEnv.CallObjectMethod(base.Handle, id_decorate_Lcom_google_android_datatransport_runtime_EventInternal_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSend_Lcom_google_android_datatransport_runtime_backends_BackendRequest_Handler()
		{
			if ((object)cb_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_ == null)
			{
				cb_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_));
			}
			return cb_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_;
		}

		private static IntPtr n_Send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ITransportBackend transportBackend = Java.Lang.Object.GetObject<ITransportBackend>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BackendRequest p = Java.Lang.Object.GetObject<BackendRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportBackend.Send(p));
		}

		public unsafe BackendResponse Send(BackendRequest p0)
		{
			if (id_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_ == IntPtr.Zero)
			{
				id_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_ = JNIEnv.GetMethodID(class_ref, "send", "(Lcom/google/android/datatransport/runtime/backends/BackendRequest;)Lcom/google/android/datatransport/runtime/backends/BackendResponse;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<BackendResponse>(JNIEnv.CallObjectMethod(base.Handle, id_send_Lcom_google_android_datatransport_runtime_backends_BackendRequest_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/datatransport/runtime/backends/TransportBackendDiscovery", DoNotGenerateAcw = true)]
	public class TransportBackendDiscovery : Service
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/runtime/backends/TransportBackendDiscovery", typeof(TransportBackendDiscovery));

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

		protected TransportBackendDiscovery(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TransportBackendDiscovery()
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
			TransportBackendDiscovery transportBackendDiscovery = Java.Lang.Object.GetObject<TransportBackendDiscovery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportBackendDiscovery.OnBind(intent));
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
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_google_android_datatransport_runtime_backends_mappings;

		private static string[] package_com_google_android_datatransport_runtime_mappings;

		private static string[] package_com_google_android_datatransport_runtime_dagger_internal_mappings;

		private static string[] package_com_google_android_datatransport_runtime_logging_mappings;

		private static string[] package_com_google_android_datatransport_runtime_retries_mappings;

		private static string[] package_com_google_android_datatransport_runtime_scheduling_mappings;

		private static string[] package_com_google_android_datatransport_runtime_scheduling_jobscheduling_mappings;

		private static string[] package_com_google_android_datatransport_runtime_scheduling_persistence_mappings;

		private static string[] package_com_google_android_datatransport_runtime_synchronization_mappings;

		private static string[] package_com_google_android_datatransport_runtime_time_mappings;

		private static string[] package_com_google_android_datatransport_runtime_util_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[11]
			{
				"com/google/android/datatransport/runtime/backends", "com/google/android/datatransport/runtime", "com/google/android/datatransport/runtime/dagger/internal", "com/google/android/datatransport/runtime/logging", "com/google/android/datatransport/runtime/retries", "com/google/android/datatransport/runtime/scheduling", "com/google/android/datatransport/runtime/scheduling/jobscheduling", "com/google/android/datatransport/runtime/scheduling/persistence", "com/google/android/datatransport/runtime/synchronization", "com/google/android/datatransport/runtime/time",
				"com/google/android/datatransport/runtime/util"
			}, new Converter<string, Type>[11]
			{
				lookup_com_google_android_datatransport_runtime_backends_package, lookup_com_google_android_datatransport_runtime_package, lookup_com_google_android_datatransport_runtime_dagger_internal_package, lookup_com_google_android_datatransport_runtime_logging_package, lookup_com_google_android_datatransport_runtime_retries_package, lookup_com_google_android_datatransport_runtime_scheduling_package, lookup_com_google_android_datatransport_runtime_scheduling_jobscheduling_package, lookup_com_google_android_datatransport_runtime_scheduling_persistence_package, lookup_com_google_android_datatransport_runtime_synchronization_package, lookup_com_google_android_datatransport_runtime_time_package,
				lookup_com_google_android_datatransport_runtime_util_package
			});
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

		private static Type lookup_com_google_android_datatransport_runtime_backends_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_backends_mappings == null)
			{
				package_com_google_android_datatransport_runtime_backends_mappings = new string[7] { "com/google/android/datatransport/runtime/backends/BackendRegistryModule:Xamarin.Google.Android.DataTransport.Runtime.Backends.BackendRegistryModule", "com/google/android/datatransport/runtime/backends/BackendRequest:Xamarin.Google.Android.DataTransport.Runtime.Backends.BackendRequest", "com/google/android/datatransport/runtime/backends/BackendRequest$Builder:Xamarin.Google.Android.DataTransport.Runtime.Backends.BackendRequest/Builder", "com/google/android/datatransport/runtime/backends/BackendResponse:Xamarin.Google.Android.DataTransport.Runtime.Backends.BackendResponse", "com/google/android/datatransport/runtime/backends/BackendResponse$Status:Xamarin.Google.Android.DataTransport.Runtime.Backends.BackendResponse/Status", "com/google/android/datatransport/runtime/backends/CreationContext:Xamarin.Google.Android.DataTransport.Runtime.Backends.CreationContext", "com/google/android/datatransport/runtime/backends/TransportBackendDiscovery:Xamarin.Google.Android.DataTransport.Runtime.Backends.TransportBackendDiscovery" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_backends_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_mappings == null)
			{
				package_com_google_android_datatransport_runtime_mappings = new string[8] { "com/google/android/datatransport/runtime/BuildConfig:Xamarin.Google.Android.DataTransport.Runtime.BuildConfig", "com/google/android/datatransport/runtime/EncodedPayload:Xamarin.Google.Android.DataTransport.Runtime.EncodedPayload", "com/google/android/datatransport/runtime/EventInternal:Xamarin.Google.Android.DataTransport.Runtime.EventInternal", "com/google/android/datatransport/runtime/EventInternal$Builder:Xamarin.Google.Android.DataTransport.Runtime.EventInternal/Builder", "com/google/android/datatransport/runtime/TransportContext:Xamarin.Google.Android.DataTransport.Runtime.TransportContext", "com/google/android/datatransport/runtime/TransportContext$Builder:Xamarin.Google.Android.DataTransport.Runtime.TransportContext/Builder", "com/google/android/datatransport/runtime/TransportRuntime:Xamarin.Google.Android.DataTransport.Runtime.TransportRuntime", "com/google/android/datatransport/runtime/TransportRuntimeComponent:Xamarin.Google.Android.DataTransport.Runtime.TransportRuntimeComponent" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_dagger_internal_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_dagger_internal_mappings == null)
			{
				package_com_google_android_datatransport_runtime_dagger_internal_mappings = new string[6] { "com/google/android/datatransport/runtime/dagger/internal/DaggerCollections:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.DaggerCollections", "com/google/android/datatransport/runtime/dagger/internal/MapBuilder:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.MapBuilder", "com/google/android/datatransport/runtime/dagger/internal/MembersInjectors:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.MembersInjectors", "com/google/android/datatransport/runtime/dagger/internal/MemoizedSentinel:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.MemoizedSentinel", "com/google/android/datatransport/runtime/dagger/internal/Preconditions:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.Preconditions", "com/google/android/datatransport/runtime/dagger/internal/SetBuilder:Xamarin.Google.Android.DataTransport.Runtime.Dagger.Internal.SetBuilder" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_dagger_internal_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_logging_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_logging_mappings == null)
			{
				package_com_google_android_datatransport_runtime_logging_mappings = new string[1] { "com/google/android/datatransport/runtime/logging/Logging:Xamarin.Google.Android.DataTransport.Runtime.Logging.Logging" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_logging_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_retries_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_retries_mappings == null)
			{
				package_com_google_android_datatransport_runtime_retries_mappings = new string[1] { "com/google/android/datatransport/runtime/retries/Retries:Xamarin.Google.Android.DataTransport.Runtime.Retries.Retries" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_retries_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_scheduling_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_scheduling_mappings == null)
			{
				package_com_google_android_datatransport_runtime_scheduling_mappings = new string[3] { "com/google/android/datatransport/runtime/scheduling/DefaultScheduler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.DefaultScheduler", "com/google/android/datatransport/runtime/scheduling/SchedulingConfigModule:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.SchedulingConfigModule", "com/google/android/datatransport/runtime/scheduling/SchedulingModule:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.SchedulingModule" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_scheduling_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_scheduling_jobscheduling_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_scheduling_jobscheduling_mappings == null)
			{
				package_com_google_android_datatransport_runtime_scheduling_jobscheduling_mappings = new string[11]
				{
					"com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerScheduler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.AlarmManagerScheduler", "com/google/android/datatransport/runtime/scheduling/jobscheduling/AlarmManagerSchedulerBroadcastReceiver:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.AlarmManagerSchedulerBroadcastReceiver", "com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoScheduler:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.JobInfoScheduler", "com/google/android/datatransport/runtime/scheduling/jobscheduling/JobInfoSchedulerService:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.JobInfoSchedulerService", "com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.SchedulerConfig", "com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Builder:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.SchedulerConfig/Builder", "com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.SchedulerConfig/ConfigValue", "com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$ConfigValue$Builder:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.SchedulerConfig/ConfigValue/Builder", "com/google/android/datatransport/runtime/scheduling/jobscheduling/SchedulerConfig$Flag:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.SchedulerConfig/Flag", "com/google/android/datatransport/runtime/scheduling/jobscheduling/Uploader:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.Uploader",
					"com/google/android/datatransport/runtime/scheduling/jobscheduling/WorkInitializer:Xamarin.Google.Android.DataTransport.Runtime.Scheduling.JobScheduling.WorkInitializer"
				};
			}
			return Lookup(package_com_google_android_datatransport_runtime_scheduling_jobscheduling_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_scheduling_persistence_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_scheduling_persistence_mappings == null)
			{
				package_com_google_android_datatransport_runtime_scheduling_persistence_mappings = new string[3] { "com/google/android/datatransport/runtime/scheduling/persistence/EventStoreModule:Xamarin.Google.Android.DataTransport.Runtime.Persistence.EventStoreModule", "com/google/android/datatransport/runtime/scheduling/persistence/PersistedEvent:Xamarin.Google.Android.DataTransport.Runtime.Persistence.PersistedEvent", "com/google/android/datatransport/runtime/scheduling/persistence/SQLiteEventStore:Xamarin.Google.Android.DataTransport.Runtime.Persistence.SQLiteEventStore" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_scheduling_persistence_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_synchronization_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_synchronization_mappings == null)
			{
				package_com_google_android_datatransport_runtime_synchronization_mappings = new string[1] { "com/google/android/datatransport/runtime/synchronization/SynchronizationException:Xamarin.Google.Android.DataTransport.Runtime.Synchronization.SynchronizationException" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_synchronization_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_time_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_time_mappings == null)
			{
				package_com_google_android_datatransport_runtime_time_mappings = new string[4] { "com/google/android/datatransport/runtime/time/TestClock:Xamarin.Google.Android.DataTransport.Runtime.Time.TestClock", "com/google/android/datatransport/runtime/time/TimeModule:Xamarin.Google.Android.DataTransport.Runtime.Time.TimeModule", "com/google/android/datatransport/runtime/time/UptimeClock:Xamarin.Google.Android.DataTransport.Runtime.Time.UptimeClock", "com/google/android/datatransport/runtime/time/WallTimeClock:Xamarin.Google.Android.DataTransport.Runtime.Time.WallTimeClock" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_time_mappings, klass);
		}

		private static Type lookup_com_google_android_datatransport_runtime_util_package(string klass)
		{
			if (package_com_google_android_datatransport_runtime_util_mappings == null)
			{
				package_com_google_android_datatransport_runtime_util_mappings = new string[1] { "com/google/android/datatransport/runtime/util/PriorityMapping:Xamarin.Google.Android.DataTransport.Runtime.Util.PriorityMapping" };
			}
			return Lookup(package_com_google_android_datatransport_runtime_util_mappings, klass);
		}
	}
}
