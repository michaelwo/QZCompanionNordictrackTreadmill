using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.android.datatransport", Managed = "Xamarin.Google.Android.DataTransport")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Android.DataTransport.TransportApi")]
[assembly: AssemblyTitle("Xamarin.Google.Android.DataTransport.TransportApi")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
namespace Xamarin.Google.Android.DataTransport
{
	[Register("com/google/android/datatransport/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("APPLICATION_ID")]
		public const string ApplicationId = "com.google.android.datatransport";

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

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/BuildConfig", typeof(BuildConfig));

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
	[Register("com/google/android/datatransport/Encoding", DoNotGenerateAcw = true)]
	public sealed class Encoding : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Encoding", typeof(Encoding));

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

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Encoding(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("of", "(Ljava/lang/String;)Lcom/google/android/datatransport/Encoding;", "")]
		public unsafe static Encoding Of(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Encoding>(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/String;)Lcom/google/android/datatransport/Encoding;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/google/android/datatransport/Event", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public abstract class Event : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Event", typeof(Event));

		private static Delegate cb_getCode;

		private static Delegate cb_getPriority;

		private static Delegate cb_getPayload;

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

		public abstract Integer Code
		{
			[Register("getCode", "()Ljava/lang/Integer;", "GetGetCodeHandler")]
			get;
		}

		public abstract Priority Priority
		{
			[Register("getPriority", "()Lcom/google/android/datatransport/Priority;", "GetGetPriorityHandler")]
			get;
		}

		protected abstract Java.Lang.Object RawPayload
		{
			[Register("getPayload", "()Ljava/lang/Object;", "GetGetPayloadHandler")]
			get;
		}

		protected Event(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Event()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Event>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Code);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Event>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Priority);
		}

		private static Delegate GetGetPayloadHandler()
		{
			if ((object)cb_getPayload == null)
			{
				cb_getPayload = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPayload));
			}
			return cb_getPayload;
		}

		private static IntPtr n_GetPayload(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Event>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RawPayload);
		}

		[Register("ofData", "(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfData(int code, Java.Lang.Object payload)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofData.(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(payload);
			}
		}

		[Register("ofData", "(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfData(Java.Lang.Object payload)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(payload);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofData.(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(payload);
			}
		}

		[Register("ofTelemetry", "(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfTelemetry(int code, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofTelemetry.(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("ofTelemetry", "(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfTelemetry(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofTelemetry.(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("ofUrgent", "(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfUrgent(int code, Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofUrgent.(ILjava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("ofUrgent", "(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Event OfUrgent(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Event>(_members.StaticMethods.InvokeObjectMethod("ofUrgent.(Ljava/lang/Object;)Lcom/google/android/datatransport/Event;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}
	}
	[Register("com/google/android/datatransport/Event", DoNotGenerateAcw = true)]
	internal class EventInvoker : Event
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Event", typeof(EventInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Integer Code
		{
			[Register("getCode", "()Ljava/lang/Integer;", "GetGetCodeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCode.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

		protected unsafe override Java.Lang.Object RawPayload
		{
			[Register("getPayload", "()Ljava/lang/Object;", "GetGetPayloadHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPayload.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public EventInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/datatransport/Transformer", "", "Xamarin.Google.Android.DataTransport.ITransformerInvoker")]
	[JavaTypeParameters(new string[] { "T", "U" })]
	public interface ITransformer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("apply", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetApply_Ljava_lang_Object_Handler:Xamarin.Google.Android.DataTransport.ITransformerInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		Java.Lang.Object Apply(Java.Lang.Object p0);
	}
	[Register("com/google/android/datatransport/Transformer", DoNotGenerateAcw = true)]
	internal class ITransformerInvoker : Java.Lang.Object, ITransformer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Transformer", typeof(ITransformerInvoker));

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

		public static ITransformer GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransformer>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.Transformer'.");
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

		public ITransformerInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			ITransformer transformer = Java.Lang.Object.GetObject<ITransformer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transformer.Apply(p));
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
	[Register("com/google/android/datatransport/Transport", "", "Xamarin.Google.Android.DataTransport.ITransportInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ITransport : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("schedule", "(Lcom/google/android/datatransport/Event;Lcom/google/android/datatransport/TransportScheduleCallback;)V", "GetSchedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_Handler:Xamarin.Google.Android.DataTransport.ITransportInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		void Schedule(Event p0, ITransportScheduleCallback p1);

		[Register("send", "(Lcom/google/android/datatransport/Event;)V", "GetSend_Lcom_google_android_datatransport_Event_Handler:Xamarin.Google.Android.DataTransport.ITransportInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		void Send(Event p0);
	}
	[Register("com/google/android/datatransport/Transport", DoNotGenerateAcw = true)]
	internal class ITransportInvoker : Java.Lang.Object, ITransport, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Transport", typeof(ITransportInvoker));

		private IntPtr class_ref;

		private static Delegate cb_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_;

		private IntPtr id_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_;

		private static Delegate cb_send_Lcom_google_android_datatransport_Event_;

		private IntPtr id_send_Lcom_google_android_datatransport_Event_;

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

		public static ITransport GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransport>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.Transport'.");
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

		public ITransportInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSchedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_Handler()
		{
			if ((object)cb_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_ == null)
			{
				cb_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_));
			}
			return cb_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_;
		}

		private static void n_Schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ITransport transport = Java.Lang.Object.GetObject<ITransport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Event p = Java.Lang.Object.GetObject<Event>(native_p0, JniHandleOwnership.DoNotTransfer);
			ITransportScheduleCallback p2 = Java.Lang.Object.GetObject<ITransportScheduleCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			transport.Schedule(p, p2);
		}

		public unsafe void Schedule(Event p0, ITransportScheduleCallback p1)
		{
			if (id_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_ == IntPtr.Zero)
			{
				id_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_ = JNIEnv.GetMethodID(class_ref, "schedule", "(Lcom/google/android/datatransport/Event;Lcom/google/android/datatransport/TransportScheduleCallback;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_schedule_Lcom_google_android_datatransport_Event_Lcom_google_android_datatransport_TransportScheduleCallback_, ptr);
		}

		private static Delegate GetSend_Lcom_google_android_datatransport_Event_Handler()
		{
			if ((object)cb_send_Lcom_google_android_datatransport_Event_ == null)
			{
				cb_send_Lcom_google_android_datatransport_Event_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Send_Lcom_google_android_datatransport_Event_));
			}
			return cb_send_Lcom_google_android_datatransport_Event_;
		}

		private static void n_Send_Lcom_google_android_datatransport_Event_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ITransport transport = Java.Lang.Object.GetObject<ITransport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Event p = Java.Lang.Object.GetObject<Event>(native_p0, JniHandleOwnership.DoNotTransfer);
			transport.Send(p);
		}

		public unsafe void Send(Event p0)
		{
			if (id_send_Lcom_google_android_datatransport_Event_ == IntPtr.Zero)
			{
				id_send_Lcom_google_android_datatransport_Event_ = JNIEnv.GetMethodID(class_ref, "send", "(Lcom/google/android/datatransport/Event;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_send_Lcom_google_android_datatransport_Event_, ptr);
		}
	}
	[Register("com/google/android/datatransport/TransportFactory", "", "Xamarin.Google.Android.DataTransport.ITransportFactoryInvoker")]
	public interface ITransportFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("getTransport", "(Ljava/lang/String;Ljava/lang/Class;Lcom/google/android/datatransport/Encoding;Lcom/google/android/datatransport/Transformer;)Lcom/google/android/datatransport/Transport;", "GetGetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_Handler:Xamarin.Google.Android.DataTransport.ITransportFactoryInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		[JavaTypeParameters(new string[] { "T" })]
		ITransport GetTransport(string p0, Class p1, Encoding p2, ITransformer p3);

		[Obsolete("deprecated")]
		[Register("getTransport", "(Ljava/lang/String;Ljava/lang/Class;Lcom/google/android/datatransport/Transformer;)Lcom/google/android/datatransport/Transport;", "GetGetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_Handler:Xamarin.Google.Android.DataTransport.ITransportFactoryInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		[JavaTypeParameters(new string[] { "T" })]
		ITransport GetTransport(string p0, Class p1, ITransformer p2);
	}
	[Register("com/google/android/datatransport/TransportFactory", DoNotGenerateAcw = true)]
	internal class ITransportFactoryInvoker : Java.Lang.Object, ITransportFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/TransportFactory", typeof(ITransportFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_;

		private IntPtr id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_;

		private static Delegate cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_;

		private IntPtr id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_;

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

		public static ITransportFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransportFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.TransportFactory'.");
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

		public ITransportFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_Handler()
		{
			if ((object)cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_ == null)
			{
				cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_GetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_));
			}
			return cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_;
		}

		private static IntPtr n_GetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			ITransportFactory transportFactory = Java.Lang.Object.GetObject<ITransportFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Class p2 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			Encoding p3 = Java.Lang.Object.GetObject<Encoding>(native_p2, JniHandleOwnership.DoNotTransfer);
			ITransformer p4 = Java.Lang.Object.GetObject<ITransformer>(native_p3, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportFactory.GetTransport(p, p2, p3, p4));
		}

		public unsafe ITransport GetTransport(string p0, Class p1, Encoding p2, ITransformer p3)
		{
			if (id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_ == IntPtr.Zero)
			{
				id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_ = JNIEnv.GetMethodID(class_ref, "getTransport", "(Ljava/lang/String;Ljava/lang/Class;Lcom/google/android/datatransport/Encoding;Lcom/google/android/datatransport/Transformer;)Lcom/google/android/datatransport/Transport;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JValue((p3 == null) ? IntPtr.Zero : ((Java.Lang.Object)p3).Handle);
			ITransport result = Java.Lang.Object.GetObject<ITransport>(JNIEnv.CallObjectMethod(base.Handle, id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Encoding_Lcom_google_android_datatransport_Transformer_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		[Obsolete]
		private static Delegate GetGetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_Handler()
		{
			if ((object)cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_ == null)
			{
				cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_GetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_));
			}
			return cb_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_;
		}

		[Obsolete]
		private static IntPtr n_GetTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			ITransportFactory transportFactory = Java.Lang.Object.GetObject<ITransportFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Class p2 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			ITransformer p3 = Java.Lang.Object.GetObject<ITransformer>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(transportFactory.GetTransport(p, p2, p3));
		}

		public unsafe ITransport GetTransport(string p0, Class p1, ITransformer p2)
		{
			if (id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_ == IntPtr.Zero)
			{
				id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_ = JNIEnv.GetMethodID(class_ref, "getTransport", "(Ljava/lang/String;Ljava/lang/Class;Lcom/google/android/datatransport/Transformer;)Lcom/google/android/datatransport/Transport;");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			ITransport result = Java.Lang.Object.GetObject<ITransport>(JNIEnv.CallObjectMethod(base.Handle, id_getTransport_Ljava_lang_String_Ljava_lang_Class_Lcom_google_android_datatransport_Transformer_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("com/google/android/datatransport/TransportScheduleCallback", "", "Xamarin.Google.Android.DataTransport.ITransportScheduleCallbackInvoker")]
	public interface ITransportScheduleCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSchedule", "(Ljava/lang/Exception;)V", "GetOnSchedule_Ljava_lang_Exception_Handler:Xamarin.Google.Android.DataTransport.ITransportScheduleCallbackInvoker, Xamarin.Google.Android.DataTransport.TransportApi")]
		void OnSchedule(Java.Lang.Exception p0);
	}
	[Register("com/google/android/datatransport/TransportScheduleCallback", DoNotGenerateAcw = true)]
	internal class ITransportScheduleCallbackInvoker : Java.Lang.Object, ITransportScheduleCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/TransportScheduleCallback", typeof(ITransportScheduleCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onSchedule_Ljava_lang_Exception_;

		private IntPtr id_onSchedule_Ljava_lang_Exception_;

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

		public static ITransportScheduleCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransportScheduleCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.datatransport.TransportScheduleCallback'.");
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

		public ITransportScheduleCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnSchedule_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onSchedule_Ljava_lang_Exception_ == null)
			{
				cb_onSchedule_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSchedule_Ljava_lang_Exception_));
			}
			return cb_onSchedule_Ljava_lang_Exception_;
		}

		private static void n_OnSchedule_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ITransportScheduleCallback transportScheduleCallback = Java.Lang.Object.GetObject<ITransportScheduleCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception p = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_p0, JniHandleOwnership.DoNotTransfer);
			transportScheduleCallback.OnSchedule(p);
		}

		public unsafe void OnSchedule(Java.Lang.Exception p0)
		{
			if (id_onSchedule_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onSchedule_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onSchedule", "(Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onSchedule_Ljava_lang_Exception_, ptr);
		}
	}
	[Register("com/google/android/datatransport/Priority", DoNotGenerateAcw = true)]
	public sealed class Priority : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/datatransport/Priority", typeof(Priority));

		[Register("DEFAULT")]
		public static Priority Default => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/google/android/datatransport/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("HIGHEST")]
		public static Priority Highest => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("HIGHEST.Lcom/google/android/datatransport/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VERY_LOW")]
		public static Priority VeryLow => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("VERY_LOW.Lcom/google/android/datatransport/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal Priority(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/google/android/datatransport/Priority;", "")]
		public unsafe static Priority ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Priority>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/android/datatransport/Priority;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/google/android/datatransport/Priority;", "")]
		public unsafe static Priority[] Values()
		{
			return (Priority[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/android/datatransport/Priority;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Priority));
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_google_android_datatransport_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/google/android/datatransport" }, new Converter<string, Type>[1] { lookup_com_google_android_datatransport_package });
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

		private static Type lookup_com_google_android_datatransport_package(string klass)
		{
			if (package_com_google_android_datatransport_mappings == null)
			{
				package_com_google_android_datatransport_mappings = new string[4] { "com/google/android/datatransport/BuildConfig:Xamarin.Google.Android.DataTransport.BuildConfig", "com/google/android/datatransport/Encoding:Xamarin.Google.Android.DataTransport.Encoding", "com/google/android/datatransport/Event:Xamarin.Google.Android.DataTransport.Event", "com/google/android/datatransport/Priority:Xamarin.Google.Android.DataTransport.Priority" };
			}
			return Lookup(package_com_google_android_datatransport_mappings, klass);
		}
	}
}
