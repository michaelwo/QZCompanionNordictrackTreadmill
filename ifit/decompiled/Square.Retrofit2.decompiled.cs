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
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Java.Lang.Reflect;
using Java.Net;
using Java.Util.Concurrent;
using Kotlin.Coroutines;
using Square.OkHttp3;
using Square.OkIO;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "retrofit2", Managed = "Square.Retrofit2")]
[assembly: NamespaceMapping(Java = "retrofit2.http", Managed = "Square.Retrofit2.Http")]
[assembly: NamespaceMapping(Java = "retrofit2.internal", Managed = "Retrofit2.Internal")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("A type-safe HTTP client for Android and Java.")]
[assembly: AssemblyFileVersion("2.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Square.Retrofit2")]
[assembly: AssemblyTitle("Square.Retrofit2")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
namespace Square.Retrofit2
{
	[Register("retrofit2/HttpException", DoNotGenerateAcw = true)]
	public class HttpException : RuntimeException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/HttpException", typeof(HttpException));

		private static Delegate cb_code;

		private static Delegate cb_message;

		private static Delegate cb_response;

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

		protected HttpException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lretrofit2/Response;)V", "")]
		public unsafe HttpException(Response response)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(response?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lretrofit2/Response;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lretrofit2/Response;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(response);
			}
		}

		private static Delegate GetCodeHandler()
		{
			if ((object)cb_code == null)
			{
				cb_code = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Code));
			}
			return cb_code;
		}

		private static int n_Code(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<HttpException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Code();
		}

		[Register("code", "()I", "GetCodeHandler")]
		public unsafe virtual int Code()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("code.()I", this, null);
		}

		private static Delegate GetInvokeMessageHandler()
		{
			if ((object)cb_message == null)
			{
				cb_message = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_InvokeMessage));
			}
			return cb_message;
		}

		private static IntPtr n_InvokeMessage(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<HttpException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeMessage());
		}

		[Register("message", "()Ljava/lang/String;", "GetInvokeMessageHandler")]
		public unsafe virtual string InvokeMessage()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("message.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetResponseHandler()
		{
			if ((object)cb_response == null)
			{
				cb_response = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Response));
			}
			return cb_response;
		}

		private static IntPtr n_Response(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<HttpException>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Response());
		}

		[Register("response", "()Lretrofit2/Response;", "GetResponseHandler")]
		public unsafe virtual Response Response()
		{
			return Java.Lang.Object.GetObject<Response>(_members.InstanceMethods.InvokeVirtualObjectMethod("response.()Lretrofit2/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("retrofit2/Call", "", "Square.Retrofit2.ICallInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ICall : Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
			get;
		}

		bool IsExecuted
		{
			[Register("isExecuted", "()Z", "GetIsExecutedHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
			get;
		}

		[Register("cancel", "()V", "GetCancelHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		void Cancel();

		[Register("clone", "()Lretrofit2/Call;", "GetCloneHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		ICall Clone();

		[Register("enqueue", "(Lretrofit2/Callback;)V", "GetEnqueue_Lretrofit2_Callback_Handler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		void Enqueue(ICallback p0);

		[Register("execute", "()Lretrofit2/Response;", "GetExecuteHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		Response Execute();

		[Register("request", "()Lokhttp3/Request;", "GetRequestHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		Request Request();

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler:Square.Retrofit2.ICallInvoker, Square.Retrofit2")]
		Timeout Timeout();
	}
	[Register("retrofit2/Call", DoNotGenerateAcw = true)]
	internal class ICallInvoker : Java.Lang.Object, ICall, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Call", typeof(ICallInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isCanceled;

		private IntPtr id_isCanceled;

		private static Delegate cb_isExecuted;

		private IntPtr id_isExecuted;

		private static Delegate cb_cancel;

		private IntPtr id_cancel;

		private static Delegate cb_clone;

		private IntPtr id_clone;

		private static Delegate cb_enqueue_Lretrofit2_Callback_;

		private IntPtr id_enqueue_Lretrofit2_Callback_;

		private static Delegate cb_execute;

		private IntPtr id_execute;

		private static Delegate cb_request;

		private IntPtr id_request;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

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

		public bool IsCanceled
		{
			get
			{
				if (id_isCanceled == IntPtr.Zero)
				{
					id_isCanceled = JNIEnv.GetMethodID(class_ref, "isCanceled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCanceled);
			}
		}

		public bool IsExecuted
		{
			get
			{
				if (id_isExecuted == IntPtr.Zero)
				{
					id_isExecuted = JNIEnv.GetMethodID(class_ref, "isExecuted", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isExecuted);
			}
		}

		public static ICall GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICall>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.Call'.");
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

		public ICallInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			return Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCanceled;
		}

		private static Delegate GetIsExecutedHandler()
		{
			if ((object)cb_isExecuted == null)
			{
				cb_isExecuted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsExecuted));
			}
			return cb_isExecuted;
		}

		private static bool n_IsExecuted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExecuted;
		}

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
			Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}

		public void Cancel()
		{
			if (id_cancel == IntPtr.Zero)
			{
				id_cancel = JNIEnv.GetMethodID(class_ref, "cancel", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_cancel);
		}

		private static Delegate GetCloneHandler()
		{
			if ((object)cb_clone == null)
			{
				cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
			}
			return cb_clone;
		}

		private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
		}

		public new ICall Clone()
		{
			if (id_clone == IntPtr.Zero)
			{
				id_clone = JNIEnv.GetMethodID(class_ref, "clone", "()Lretrofit2/Call;");
			}
			return Java.Lang.Object.GetObject<ICall>(JNIEnv.CallObjectMethod(base.Handle, id_clone), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEnqueue_Lretrofit2_Callback_Handler()
		{
			if ((object)cb_enqueue_Lretrofit2_Callback_ == null)
			{
				cb_enqueue_Lretrofit2_Callback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Enqueue_Lretrofit2_Callback_));
			}
			return cb_enqueue_Lretrofit2_Callback_;
		}

		private static void n_Enqueue_Lretrofit2_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICall call = Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallback p = Java.Lang.Object.GetObject<ICallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			call.Enqueue(p);
		}

		public unsafe void Enqueue(ICallback p0)
		{
			if (id_enqueue_Lretrofit2_Callback_ == IntPtr.Zero)
			{
				id_enqueue_Lretrofit2_Callback_ = JNIEnv.GetMethodID(class_ref, "enqueue", "(Lretrofit2/Callback;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_enqueue_Lretrofit2_Callback_, ptr);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Execute());
		}

		public Response Execute()
		{
			if (id_execute == IntPtr.Zero)
			{
				id_execute = JNIEnv.GetMethodID(class_ref, "execute", "()Lretrofit2/Response;");
			}
			return Java.Lang.Object.GetObject<Response>(JNIEnv.CallObjectMethod(base.Handle, id_execute), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRequestHandler()
		{
			if ((object)cb_request == null)
			{
				cb_request = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Request));
			}
			return cb_request;
		}

		private static IntPtr n_Request(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request());
		}

		public Request Request()
		{
			if (id_request == IntPtr.Zero)
			{
				id_request = JNIEnv.GetMethodID(class_ref, "request", "()Lokhttp3/Request;");
			}
			return Java.Lang.Object.GetObject<Request>(JNIEnv.CallObjectMethod(base.Handle, id_request), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICall>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("retrofit2/CallAdapter$Factory", DoNotGenerateAcw = true)]
	public abstract class CallAdapterFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/CallAdapter$Factory", typeof(CallAdapterFactory));

		private static Delegate cb_get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;

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

		protected CallAdapterFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CallAdapterFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGet_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler()
		{
			if ((object)cb_get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ == null)
			{
				cb_get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_Get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_));
			}
			return cb_get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;
		}

		private static IntPtr n_Get_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			CallAdapterFactory callAdapterFactory = Java.Lang.Object.GetObject<CallAdapterFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IType p = Java.Lang.Object.GetObject<IType>(native_p0, JniHandleOwnership.DoNotTransfer);
			IAnnotation[] array = (IAnnotation[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(IAnnotation));
			Retrofit p2 = Java.Lang.Object.GetObject<Retrofit>(native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(callAdapterFactory.Get(p, array, p2));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
			return result;
		}

		[Register("get", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/CallAdapter;", "GetGet_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler")]
		public abstract ICallAdapter Get(IType p0, IAnnotation[] p1, Retrofit p2);

		[Register("getParameterUpperBound", "(ILjava/lang/reflect/ParameterizedType;)Ljava/lang/reflect/Type;", "")]
		protected unsafe static IType GetParameterUpperBound(int index, IParameterizedType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<IType>(_members.StaticMethods.InvokeObjectMethod("getParameterUpperBound.(ILjava/lang/reflect/ParameterizedType;)Ljava/lang/reflect/Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("getRawType", "(Ljava/lang/reflect/Type;)Ljava/lang/Class;", "")]
		protected unsafe static Class GetRawType(IType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<Class>(_members.StaticMethods.InvokeObjectMethod("getRawType.(Ljava/lang/reflect/Type;)Ljava/lang/Class;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}
	}
	[Register("retrofit2/CallAdapter$Factory", DoNotGenerateAcw = true)]
	internal class CallAdapterFactoryInvoker : CallAdapterFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/CallAdapter$Factory", typeof(CallAdapterFactoryInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CallAdapterFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("get", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/CallAdapter;", "GetGet_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler")]
		public unsafe override ICallAdapter Get(IType p0, IAnnotation[] p1, Retrofit p2)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ICallAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/CallAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
				GC.KeepAlive(p2);
			}
		}
	}
	[Register("retrofit2/CallAdapter", "", "Square.Retrofit2.ICallAdapterInvoker")]
	[JavaTypeParameters(new string[] { "R", "T" })]
	public interface ICallAdapter : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("adapt", "(Lretrofit2/Call;)Ljava/lang/Object;", "GetAdapt_Lretrofit2_Call_Handler:Square.Retrofit2.ICallAdapterInvoker, Square.Retrofit2")]
		Java.Lang.Object Adapt(ICall p0);

		[Register("responseType", "()Ljava/lang/reflect/Type;", "GetResponseTypeHandler:Square.Retrofit2.ICallAdapterInvoker, Square.Retrofit2")]
		IType ResponseType();
	}
	[Register("retrofit2/CallAdapter", DoNotGenerateAcw = true)]
	internal class ICallAdapterInvoker : Java.Lang.Object, ICallAdapter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/CallAdapter", typeof(ICallAdapterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_adapt_Lretrofit2_Call_;

		private IntPtr id_adapt_Lretrofit2_Call_;

		private static Delegate cb_responseType;

		private IntPtr id_responseType;

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

		public static ICallAdapter GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICallAdapter>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.CallAdapter'.");
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

		public ICallAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAdapt_Lretrofit2_Call_Handler()
		{
			if ((object)cb_adapt_Lretrofit2_Call_ == null)
			{
				cb_adapt_Lretrofit2_Call_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Adapt_Lretrofit2_Call_));
			}
			return cb_adapt_Lretrofit2_Call_;
		}

		private static IntPtr n_Adapt_Lretrofit2_Call_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ICallAdapter callAdapter = Java.Lang.Object.GetObject<ICallAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall p = Java.Lang.Object.GetObject<ICall>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(callAdapter.Adapt(p));
		}

		public unsafe Java.Lang.Object Adapt(ICall p0)
		{
			if (id_adapt_Lretrofit2_Call_ == IntPtr.Zero)
			{
				id_adapt_Lretrofit2_Call_ = JNIEnv.GetMethodID(class_ref, "adapt", "(Lretrofit2/Call;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_adapt_Lretrofit2_Call_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetResponseTypeHandler()
		{
			if ((object)cb_responseType == null)
			{
				cb_responseType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ResponseType));
			}
			return cb_responseType;
		}

		private static IntPtr n_ResponseType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICallAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResponseType());
		}

		public IType ResponseType()
		{
			if (id_responseType == IntPtr.Zero)
			{
				id_responseType = JNIEnv.GetMethodID(class_ref, "responseType", "()Ljava/lang/reflect/Type;");
			}
			return Java.Lang.Object.GetObject<IType>(JNIEnv.CallObjectMethod(base.Handle, id_responseType), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("retrofit2/Callback", "", "Square.Retrofit2.ICallbackInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFailure", "(Lretrofit2/Call;Ljava/lang/Throwable;)V", "GetOnFailure_Lretrofit2_Call_Ljava_lang_Throwable_Handler:Square.Retrofit2.ICallbackInvoker, Square.Retrofit2")]
		void OnFailure(ICall p0, Throwable p1);

		[Register("onResponse", "(Lretrofit2/Call;Lretrofit2/Response;)V", "GetOnResponse_Lretrofit2_Call_Lretrofit2_Response_Handler:Square.Retrofit2.ICallbackInvoker, Square.Retrofit2")]
		void OnResponse(ICall p0, Response p1);
	}
	[Register("retrofit2/Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Callback", typeof(ICallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_;

		private IntPtr id_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_;

		private static Delegate cb_onResponse_Lretrofit2_Call_Lretrofit2_Response_;

		private IntPtr id_onResponse_Lretrofit2_Call_Lretrofit2_Response_;

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

		public static ICallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.Callback'.");
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

		public ICallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnFailure_Lretrofit2_Call_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_ == null)
			{
				cb_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnFailure_Lretrofit2_Call_Ljava_lang_Throwable_));
			}
			return cb_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_;
		}

		private static void n_OnFailure_Lretrofit2_Call_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall p = Java.Lang.Object.GetObject<ICall>(native_p0, JniHandleOwnership.DoNotTransfer);
			Throwable p2 = Java.Lang.Object.GetObject<Throwable>(native_p1, JniHandleOwnership.DoNotTransfer);
			callback.OnFailure(p, p2);
		}

		public unsafe void OnFailure(ICall p0, Throwable p1)
		{
			if (id_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Lretrofit2/Call;Ljava/lang/Throwable;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Lretrofit2_Call_Ljava_lang_Throwable_, ptr);
		}

		private static Delegate GetOnResponse_Lretrofit2_Call_Lretrofit2_Response_Handler()
		{
			if ((object)cb_onResponse_Lretrofit2_Call_Lretrofit2_Response_ == null)
			{
				cb_onResponse_Lretrofit2_Call_Lretrofit2_Response_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnResponse_Lretrofit2_Call_Lretrofit2_Response_));
			}
			return cb_onResponse_Lretrofit2_Call_Lretrofit2_Response_;
		}

		private static void n_OnResponse_Lretrofit2_Call_Lretrofit2_Response_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			ICallback callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICall p = Java.Lang.Object.GetObject<ICall>(native_p0, JniHandleOwnership.DoNotTransfer);
			Response p2 = Java.Lang.Object.GetObject<Response>(native_p1, JniHandleOwnership.DoNotTransfer);
			callback.OnResponse(p, p2);
		}

		public unsafe void OnResponse(ICall p0, Response p1)
		{
			if (id_onResponse_Lretrofit2_Call_Lretrofit2_Response_ == IntPtr.Zero)
			{
				id_onResponse_Lretrofit2_Call_Lretrofit2_Response_ = JNIEnv.GetMethodID(class_ref, "onResponse", "(Lretrofit2/Call;Lretrofit2/Response;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onResponse_Lretrofit2_Call_Lretrofit2_Response_, ptr);
		}
	}
	[Register("retrofit2/Converter$Factory", DoNotGenerateAcw = true)]
	public abstract class ConverterFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Converter$Factory", typeof(ConverterFactory));

		private static Delegate cb_requestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;

		private static Delegate cb_responseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;

		private static Delegate cb_stringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;

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

		protected ConverterFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConverterFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("getParameterUpperBound", "(ILjava/lang/reflect/ParameterizedType;)Ljava/lang/reflect/Type;", "")]
		protected unsafe static IType GetParameterUpperBound(int index, IParameterizedType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<IType>(_members.StaticMethods.InvokeObjectMethod("getParameterUpperBound.(ILjava/lang/reflect/ParameterizedType;)Ljava/lang/reflect/Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		[Register("getRawType", "(Ljava/lang/reflect/Type;)Ljava/lang/Class;", "")]
		protected unsafe static Class GetRawType(IType type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				return Java.Lang.Object.GetObject<Class>(_members.StaticMethods.InvokeObjectMethod("getRawType.(Ljava/lang/reflect/Type;)Ljava/lang/Class;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetRequestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler()
		{
			if ((object)cb_requestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ == null)
			{
				cb_requestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_RequestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_));
			}
			return cb_requestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;
		}

		private static IntPtr n_RequestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_parameterAnnotations, IntPtr native_methodAnnotations, IntPtr native_retrofit)
		{
			ConverterFactory converterFactory = Java.Lang.Object.GetObject<ConverterFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IType type = Java.Lang.Object.GetObject<IType>(native_type, JniHandleOwnership.DoNotTransfer);
			IAnnotation[] array = (IAnnotation[])JNIEnv.GetArray(native_parameterAnnotations, JniHandleOwnership.DoNotTransfer, typeof(IAnnotation));
			IAnnotation[] array2 = (IAnnotation[])JNIEnv.GetArray(native_methodAnnotations, JniHandleOwnership.DoNotTransfer, typeof(IAnnotation));
			Retrofit retrofit = Java.Lang.Object.GetObject<Retrofit>(native_retrofit, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(converterFactory.RequestBodyConverter(type, array, array2, retrofit));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_parameterAnnotations);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_methodAnnotations);
			}
			return result;
		}

		[Register("requestBodyConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", "GetRequestBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler")]
		public unsafe virtual IConverter RequestBodyConverter(IType type, IAnnotation[] parameterAnnotations, IAnnotation[] methodAnnotations, Retrofit retrofit)
		{
			IntPtr intPtr = JNIEnv.NewArray(parameterAnnotations);
			IntPtr intPtr2 = JNIEnv.NewArray(methodAnnotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(retrofit?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeVirtualObjectMethod("requestBodyConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (parameterAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr, parameterAnnotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (methodAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr2, methodAnnotations);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(parameterAnnotations);
				GC.KeepAlive(methodAnnotations);
				GC.KeepAlive(retrofit);
			}
		}

		private static Delegate GetResponseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler()
		{
			if ((object)cb_responseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ == null)
			{
				cb_responseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_ResponseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_));
			}
			return cb_responseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;
		}

		private static IntPtr n_ResponseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_annotations, IntPtr native_retrofit)
		{
			ConverterFactory converterFactory = Java.Lang.Object.GetObject<ConverterFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IType type = Java.Lang.Object.GetObject<IType>(native_type, JniHandleOwnership.DoNotTransfer);
			IAnnotation[] array = (IAnnotation[])JNIEnv.GetArray(native_annotations, JniHandleOwnership.DoNotTransfer, typeof(IAnnotation));
			Retrofit retrofit = Java.Lang.Object.GetObject<Retrofit>(native_retrofit, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(converterFactory.ResponseBodyConverter(type, array, retrofit));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_annotations);
			}
			return result;
		}

		[Register("responseBodyConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", "GetResponseBodyConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler")]
		public unsafe virtual IConverter ResponseBodyConverter(IType type, IAnnotation[] annotations, Retrofit retrofit)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(retrofit?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeVirtualObjectMethod("responseBodyConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(annotations);
				GC.KeepAlive(retrofit);
			}
		}

		private static Delegate GetStringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler()
		{
			if ((object)cb_stringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ == null)
			{
				cb_stringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_StringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_));
			}
			return cb_stringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_;
		}

		private static IntPtr n_StringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_annotations, IntPtr native_retrofit)
		{
			ConverterFactory converterFactory = Java.Lang.Object.GetObject<ConverterFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IType type = Java.Lang.Object.GetObject<IType>(native_type, JniHandleOwnership.DoNotTransfer);
			IAnnotation[] array = (IAnnotation[])JNIEnv.GetArray(native_annotations, JniHandleOwnership.DoNotTransfer, typeof(IAnnotation));
			Retrofit retrofit = Java.Lang.Object.GetObject<Retrofit>(native_retrofit, JniHandleOwnership.DoNotTransfer);
			IntPtr result = JNIEnv.ToLocalJniHandle(converterFactory.StringConverter(type, array, retrofit));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_annotations);
			}
			return result;
		}

		[Register("stringConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", "GetStringConverter_Ljava_lang_reflect_Type_arrayLjava_lang_annotation_Annotation_Lretrofit2_Retrofit_Handler")]
		public unsafe virtual IConverter StringConverter(IType type, IAnnotation[] annotations, Retrofit retrofit)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(retrofit?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeVirtualObjectMethod("stringConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;Lretrofit2/Retrofit;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(annotations);
				GC.KeepAlive(retrofit);
			}
		}
	}
	[Register("retrofit2/Converter$Factory", DoNotGenerateAcw = true)]
	internal class ConverterFactoryInvoker : ConverterFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Converter$Factory", typeof(ConverterFactoryInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ConverterFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("retrofit2/Converter", "", "Square.Retrofit2.IConverterInvoker")]
	[JavaTypeParameters(new string[] { "F", "T" })]
	public interface IConverter : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("convert", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetConvert_Ljava_lang_Object_Handler:Square.Retrofit2.IConverterInvoker, Square.Retrofit2")]
		Java.Lang.Object Convert(Java.Lang.Object p0);
	}
	[Register("retrofit2/Converter", DoNotGenerateAcw = true)]
	internal class IConverterInvoker : Java.Lang.Object, IConverter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Converter", typeof(IConverterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_convert_Ljava_lang_Object_;

		private IntPtr id_convert_Ljava_lang_Object_;

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

		public static IConverter GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IConverter>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.Converter'.");
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

		public IConverterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetConvert_Ljava_lang_Object_Handler()
		{
			if ((object)cb_convert_Ljava_lang_Object_ == null)
			{
				cb_convert_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Convert_Ljava_lang_Object_));
			}
			return cb_convert_Ljava_lang_Object_;
		}

		private static IntPtr n_Convert_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IConverter converter = Java.Lang.Object.GetObject<IConverter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(converter.Convert(p));
		}

		public unsafe Java.Lang.Object Convert(Java.Lang.Object p0)
		{
			if (id_convert_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_convert_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "convert", "(Ljava/lang/Object;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_convert_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("retrofit2/Invocation", DoNotGenerateAcw = true)]
	public sealed class Invocation : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Invocation", typeof(Invocation));

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

		internal Invocation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("arguments", "()Ljava/util/List;", "")]
		public unsafe IList<object> Arguments()
		{
			return JavaList<object>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("arguments.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("method", "()Ljava/lang/reflect/Method;", "")]
		public unsafe Method Method()
		{
			return Java.Lang.Object.GetObject<Method>(_members.InstanceMethods.InvokeAbstractObjectMethod("method.()Ljava/lang/reflect/Method;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "(Ljava/lang/reflect/Method;Ljava/util/List;)Lretrofit2/Invocation;", "")]
		public unsafe static Invocation Of(Method method, IList<object> arguments)
		{
			IntPtr intPtr = JavaList<object>.ToLocalJniHandle(arguments);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(method?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Invocation>(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/reflect/Method;Ljava/util/List;)Lretrofit2/Invocation;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(method);
				GC.KeepAlive(arguments);
			}
		}
	}
	[Register("retrofit2/SkipCallbackExecutor", "", "Square.Retrofit2.ISkipCallbackExecutorInvoker")]
	public interface ISkipCallbackExecutor : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/SkipCallbackExecutor", DoNotGenerateAcw = true)]
	internal class ISkipCallbackExecutorInvoker : Java.Lang.Object, ISkipCallbackExecutor, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/SkipCallbackExecutor", typeof(ISkipCallbackExecutorInvoker));

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

		public static ISkipCallbackExecutor GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISkipCallbackExecutor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.SkipCallbackExecutor'.");
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

		public ISkipCallbackExecutorInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISkipCallbackExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ISkipCallbackExecutor skipCallbackExecutor = Java.Lang.Object.GetObject<ISkipCallbackExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return skipCallbackExecutor.Equals(obj);
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
			return Java.Lang.Object.GetObject<ISkipCallbackExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISkipCallbackExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/KotlinExtensions", DoNotGenerateAcw = true)]
	public sealed class KotlinExtensions : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/KotlinExtensions", typeof(KotlinExtensions));

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

		internal KotlinExtensions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("await", "(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object Await(ICall obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("await.(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}

		[Register("awaitNullable", "(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object AwaitNullable(ICall obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("awaitNullable.(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}

		[Register("awaitResponse", "(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object AwaitResponse(ICall obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("awaitResponse.(Lretrofit2/Call;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}

		[Register("suspendAndThrow", "(Ljava/lang/Exception;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object SuspendAndThrow(Java.Lang.Exception obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("suspendAndThrow.(Ljava/lang/Exception;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("retrofit2/Response", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public sealed class Response : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Response", typeof(Response));

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

		public unsafe bool IsSuccessful
		{
			[Register("isSuccessful", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSuccessful.()Z", this, null);
			}
		}

		internal Response(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("body", "()Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object Body()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("body.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("code", "()I", "")]
		public unsafe int Code()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("code.()I", this, null);
		}

		[Register("error", "(ILokhttp3/ResponseBody;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Error(int code, ResponseBody body)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("error.(ILokhttp3/ResponseBody;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(body);
			}
		}

		[Register("error", "(Lokhttp3/ResponseBody;Lokhttp3/Response;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Error(ResponseBody body, Square.OkHttp3.Response rawResponse)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(body?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(rawResponse?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("error.(Lokhttp3/ResponseBody;Lokhttp3/Response;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(body);
				GC.KeepAlive(rawResponse);
			}
		}

		[Register("errorBody", "()Lokhttp3/ResponseBody;", "")]
		public unsafe ResponseBody ErrorBody()
		{
			return Java.Lang.Object.GetObject<ResponseBody>(_members.InstanceMethods.InvokeAbstractObjectMethod("errorBody.()Lokhttp3/ResponseBody;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("headers", "()Lokhttp3/Headers;", "")]
		public unsafe Headers Headers()
		{
			return Java.Lang.Object.GetObject<Headers>(_members.InstanceMethods.InvokeAbstractObjectMethod("headers.()Lokhttp3/Headers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("message", "()Ljava/lang/String;", "")]
		public unsafe string Message()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("message.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("raw", "()Lokhttp3/Response;", "")]
		public unsafe Square.OkHttp3.Response Raw()
		{
			return Java.Lang.Object.GetObject<Square.OkHttp3.Response>(_members.InstanceMethods.InvokeAbstractObjectMethod("raw.()Lokhttp3/Response;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("success", "(ILjava/lang/Object;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Success(int code, Java.Lang.Object body)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(code);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("success.(ILjava/lang/Object;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(body);
			}
		}

		[Register("success", "(Ljava/lang/Object;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Success(Java.Lang.Object body)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("success.(Ljava/lang/Object;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(body);
			}
		}

		[Register("success", "(Ljava/lang/Object;Lokhttp3/Headers;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Success(Java.Lang.Object body, Headers headers)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(headers?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("success.(Ljava/lang/Object;Lokhttp3/Headers;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(body);
				GC.KeepAlive(headers);
			}
		}

		[Register("success", "(Ljava/lang/Object;Lokhttp3/Response;)Lretrofit2/Response;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Response Success(Java.Lang.Object body, Square.OkHttp3.Response rawResponse)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(body);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(rawResponse?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Response>(_members.StaticMethods.InvokeObjectMethod("success.(Ljava/lang/Object;Lokhttp3/Response;)Lretrofit2/Response;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(body);
				GC.KeepAlive(rawResponse);
			}
		}
	}
	[Register("retrofit2/Retrofit", DoNotGenerateAcw = true)]
	public sealed class Retrofit : Java.Lang.Object
	{
		[Register("retrofit2/Retrofit$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Retrofit$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
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

			[Register("addCallAdapterFactory", "(Lretrofit2/CallAdapter$Factory;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder AddCallAdapterFactory(CallAdapterFactory factory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(factory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addCallAdapterFactory.(Lretrofit2/CallAdapter$Factory;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(factory);
				}
			}

			[Register("addConverterFactory", "(Lretrofit2/Converter$Factory;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder AddConverterFactory(ConverterFactory factory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(factory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addConverterFactory.(Lretrofit2/Converter$Factory;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(factory);
				}
			}

			[Register("baseUrl", "(Ljava/lang/String;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder BaseUrl(string baseUrl)
			{
				IntPtr intPtr = JNIEnv.NewString(baseUrl);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("baseUrl.(Ljava/lang/String;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("baseUrl", "(Ljava/net/URL;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder BaseUrl(URL baseUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(baseUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("baseUrl.(Ljava/net/URL;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(baseUrl);
				}
			}

			[Register("baseUrl", "(Lokhttp3/HttpUrl;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder BaseUrl(HttpUrl baseUrl)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(baseUrl?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("baseUrl.(Lokhttp3/HttpUrl;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(baseUrl);
				}
			}

			[Register("build", "()Lretrofit2/Retrofit;", "")]
			public unsafe Retrofit Build()
			{
				return Java.Lang.Object.GetObject<Retrofit>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lretrofit2/Retrofit;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("callAdapterFactories", "()Ljava/util/List;", "")]
			public unsafe IList<CallAdapterFactory> CallAdapterFactories()
			{
				return JavaList<CallAdapterFactory>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("callAdapterFactories.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("callFactory", "(Lokhttp3/Call$Factory;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder CallFactory(ICallFactory factory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("callFactory.(Lokhttp3/Call$Factory;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(factory);
				}
			}

			[Register("callbackExecutor", "(Ljava/util/concurrent/Executor;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder CallbackExecutor(IExecutor executor)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("callbackExecutor.(Ljava/util/concurrent/Executor;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(executor);
				}
			}

			[Register("client", "(Lokhttp3/OkHttpClient;)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder Client(OkHttpClient client)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(client?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("client.(Lokhttp3/OkHttpClient;)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(client);
				}
			}

			[Register("converterFactories", "()Ljava/util/List;", "")]
			public unsafe IList<ConverterFactory> ConverterFactories()
			{
				return JavaList<ConverterFactory>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("converterFactories.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("validateEagerly", "(Z)Lretrofit2/Retrofit$Builder;", "")]
			public unsafe Builder ValidateEagerly(bool validateEagerly)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(validateEagerly);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("validateEagerly.(Z)Lretrofit2/Retrofit$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/Retrofit", typeof(Retrofit));

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

		internal Retrofit(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("baseUrl", "()Lokhttp3/HttpUrl;", "")]
		public unsafe HttpUrl BaseUrl()
		{
			return Java.Lang.Object.GetObject<HttpUrl>(_members.InstanceMethods.InvokeAbstractObjectMethod("baseUrl.()Lokhttp3/HttpUrl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("callAdapter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/CallAdapter;", "")]
		public unsafe ICallAdapter CallAdapter(IType returnType, IAnnotation[] annotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((returnType == null) ? IntPtr.Zero : ((Java.Lang.Object)returnType).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICallAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("callAdapter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/CallAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(returnType);
				GC.KeepAlive(annotations);
			}
		}

		[Register("callAdapterFactories", "()Ljava/util/List;", "")]
		public unsafe IList<CallAdapterFactory> CallAdapterFactories()
		{
			return JavaList<CallAdapterFactory>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("callAdapterFactories.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("callFactory", "()Lokhttp3/Call$Factory;", "")]
		public unsafe ICallFactory CallFactory()
		{
			return Java.Lang.Object.GetObject<ICallFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("callFactory.()Lokhttp3/Call$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("callbackExecutor", "()Ljava/util/concurrent/Executor;", "")]
		public unsafe IExecutor CallbackExecutor()
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("callbackExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("converterFactories", "()Ljava/util/List;", "")]
		public unsafe IList<ConverterFactory> ConverterFactories()
		{
			return JavaList<ConverterFactory>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("converterFactories.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("create", "(Ljava/lang/Class;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object Create(Class service)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(service?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("create.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(service);
			}
		}

		[Register("newBuilder", "()Lretrofit2/Retrofit$Builder;", "")]
		public unsafe Builder NewBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("newBuilder.()Lretrofit2/Retrofit$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("nextCallAdapter", "(Lretrofit2/CallAdapter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/CallAdapter;", "")]
		public unsafe ICallAdapter NextCallAdapter(CallAdapterFactory skipPast, IType returnType, IAnnotation[] annotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(skipPast?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((returnType == null) ? IntPtr.Zero : ((Java.Lang.Object)returnType).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICallAdapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("nextCallAdapter.(Lretrofit2/CallAdapter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/CallAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(skipPast);
				GC.KeepAlive(returnType);
				GC.KeepAlive(annotations);
			}
		}

		[Register("nextRequestBodyConverter", "(Lretrofit2/Converter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IConverter NextRequestBodyConverter(ConverterFactory skipPast, IType type, IAnnotation[] parameterAnnotations, IAnnotation[] methodAnnotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(parameterAnnotations);
			IntPtr intPtr2 = JNIEnv.NewArray(methodAnnotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(skipPast?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeAbstractObjectMethod("nextRequestBodyConverter.(Lretrofit2/Converter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (parameterAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr, parameterAnnotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (methodAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr2, methodAnnotations);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(skipPast);
				GC.KeepAlive(type);
				GC.KeepAlive(parameterAnnotations);
				GC.KeepAlive(methodAnnotations);
			}
		}

		[Register("nextResponseBodyConverter", "(Lretrofit2/Converter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IConverter NextResponseBodyConverter(ConverterFactory skipPast, IType type, IAnnotation[] annotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(skipPast?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[2] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeAbstractObjectMethod("nextResponseBodyConverter.(Lretrofit2/Converter$Factory;Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(skipPast);
				GC.KeepAlive(type);
				GC.KeepAlive(annotations);
			}
		}

		[Register("requestBodyConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IConverter RequestBodyConverter(IType type, IAnnotation[] parameterAnnotations, IAnnotation[] methodAnnotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(parameterAnnotations);
			IntPtr intPtr2 = JNIEnv.NewArray(methodAnnotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeAbstractObjectMethod("requestBodyConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (parameterAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr, parameterAnnotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				if (methodAnnotations != null)
				{
					JNIEnv.CopyArray(intPtr2, methodAnnotations);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(parameterAnnotations);
				GC.KeepAlive(methodAnnotations);
			}
		}

		[Register("responseBodyConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IConverter ResponseBodyConverter(IType type, IAnnotation[] annotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeAbstractObjectMethod("responseBodyConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(annotations);
			}
		}

		[Register("stringConverter", "(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IConverter StringConverter(IType type, IAnnotation[] annotations)
		{
			IntPtr intPtr = JNIEnv.NewArray(annotations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((type == null) ? IntPtr.Zero : ((Java.Lang.Object)type).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IConverter>(_members.InstanceMethods.InvokeAbstractObjectMethod("stringConverter.(Ljava/lang/reflect/Type;[Ljava/lang/annotation/Annotation;)Lretrofit2/Converter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (annotations != null)
				{
					JNIEnv.CopyArray(intPtr, annotations);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(type);
				GC.KeepAlive(annotations);
			}
		}
	}
	[Annotation("retrofit2.SkipCallbackExecutor")]
	public class SkipCallbackExecutorAttribute : Attribute
	{
	}
}
namespace Square.Retrofit2.Http
{
	[Annotation("retrofit2.http.Body")]
	public class BodyAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.DELETE")]
	public class DELETEAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.Field")]
	public class FieldAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }

		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.FieldMap")]
	public class FieldMapAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }
	}
	[Annotation("retrofit2.http.FormUrlEncoded")]
	public class FormUrlEncodedAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.GET")]
	public class GETAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.HEAD")]
	public class HEADAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.Header")]
	public class HeaderAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.HeaderMap")]
	public class HeaderMapAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.Headers")]
	public class HeadersAttribute : Attribute
	{
		[Register("value")]
		public string[] Value { get; set; }
	}
	[Annotation("retrofit2.http.HTTP")]
	public class HTTPAttribute : Attribute
	{
		[Register("method")]
		public string Method { get; set; }

		[Register("path")]
		public string Path { get; set; }
	}
	[Register("retrofit2/http/Body", "", "Square.Retrofit2.Http.IBodyInvoker")]
	public interface IBody : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/Body", DoNotGenerateAcw = true)]
	internal class IBodyInvoker : Java.Lang.Object, IBody, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Body", typeof(IBodyInvoker));

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

		public static IBody GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBody>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Body'.");
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

		public IBodyInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IBody body = Java.Lang.Object.GetObject<IBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return body.Equals(obj);
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
			return Java.Lang.Object.GetObject<IBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBody>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/DELETE", "", "Square.Retrofit2.Http.IDELETEInvoker")]
	public interface IDELETE : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IDELETEInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/DELETE", DoNotGenerateAcw = true)]
	internal class IDELETEInvoker : Java.Lang.Object, IDELETE, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/DELETE", typeof(IDELETEInvoker));

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

		public static IDELETE GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDELETE>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.DELETE'.");
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

		public IDELETEInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDELETE>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDELETE>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IDELETE iDELETE = Java.Lang.Object.GetObject<IDELETE>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iDELETE.Equals(obj);
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
			return Java.Lang.Object.GetObject<IDELETE>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDELETE>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Field", "", "Square.Retrofit2.Http.IFieldInvoker")]
	public interface IField : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IFieldInvoker, Square.Retrofit2")]
		bool Encoded();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IFieldInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/Field", DoNotGenerateAcw = true)]
	internal class IFieldInvoker : Java.Lang.Object, IField, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Field", typeof(IFieldInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IField GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IField>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Field'.");
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

		public IFieldInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IField field = Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return field.Equals(obj);
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
			return Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IField>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/FieldMap", "", "Square.Retrofit2.Http.IFieldMapInvoker")]
	public interface IFieldMap : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IFieldMapInvoker, Square.Retrofit2")]
		bool Encoded();
	}
	[Register("retrofit2/http/FieldMap", DoNotGenerateAcw = true)]
	internal class IFieldMapInvoker : Java.Lang.Object, IFieldMap, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/FieldMap", typeof(IFieldMapInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IFieldMap GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFieldMap>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.FieldMap'.");
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

		public IFieldMapInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IFieldMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFieldMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IFieldMap fieldMap = Java.Lang.Object.GetObject<IFieldMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return fieldMap.Equals(obj);
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
			return Java.Lang.Object.GetObject<IFieldMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFieldMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/FormUrlEncoded", "", "Square.Retrofit2.Http.IFormUrlEncodedInvoker")]
	public interface IFormUrlEncoded : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/FormUrlEncoded", DoNotGenerateAcw = true)]
	internal class IFormUrlEncodedInvoker : Java.Lang.Object, IFormUrlEncoded, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/FormUrlEncoded", typeof(IFormUrlEncodedInvoker));

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

		public static IFormUrlEncoded GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFormUrlEncoded>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.FormUrlEncoded'.");
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

		public IFormUrlEncodedInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFormUrlEncoded>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IFormUrlEncoded formUrlEncoded = Java.Lang.Object.GetObject<IFormUrlEncoded>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return formUrlEncoded.Equals(obj);
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
			return Java.Lang.Object.GetObject<IFormUrlEncoded>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFormUrlEncoded>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/GET", "", "Square.Retrofit2.Http.IGETInvoker")]
	public interface IGET : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IGETInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/GET", DoNotGenerateAcw = true)]
	internal class IGETInvoker : Java.Lang.Object, IGET, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/GET", typeof(IGETInvoker));

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

		public static IGET GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IGET>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.GET'.");
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

		public IGETInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IGET>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IGET>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IGET iGET = Java.Lang.Object.GetObject<IGET>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iGET.Equals(obj);
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
			return Java.Lang.Object.GetObject<IGET>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IGET>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/HEAD", "", "Square.Retrofit2.Http.IHEADInvoker")]
	public interface IHEAD : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IHEADInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/HEAD", DoNotGenerateAcw = true)]
	internal class IHEADInvoker : Java.Lang.Object, IHEAD, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/HEAD", typeof(IHEADInvoker));

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

		public static IHEAD GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHEAD>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.HEAD'.");
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

		public IHEADInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHEAD>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHEAD>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IHEAD iHEAD = Java.Lang.Object.GetObject<IHEAD>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iHEAD.Equals(obj);
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
			return Java.Lang.Object.GetObject<IHEAD>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHEAD>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Header", "", "Square.Retrofit2.Http.IHeaderInvoker")]
	public interface IHeader : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IHeaderInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/Header", DoNotGenerateAcw = true)]
	internal class IHeaderInvoker : Java.Lang.Object, IHeader, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Header", typeof(IHeaderInvoker));

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

		public static IHeader GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHeader>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Header'.");
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

		public IHeaderInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHeader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHeader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IHeader header = Java.Lang.Object.GetObject<IHeader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return header.Equals(obj);
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
			return Java.Lang.Object.GetObject<IHeader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHeader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/HeaderMap", "", "Square.Retrofit2.Http.IHeaderMapInvoker")]
	public interface IHeaderMap : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/HeaderMap", DoNotGenerateAcw = true)]
	internal class IHeaderMapInvoker : Java.Lang.Object, IHeaderMap, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/HeaderMap", typeof(IHeaderMapInvoker));

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

		public static IHeaderMap GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHeaderMap>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.HeaderMap'.");
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

		public IHeaderMapInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHeaderMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IHeaderMap headerMap = Java.Lang.Object.GetObject<IHeaderMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return headerMap.Equals(obj);
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
			return Java.Lang.Object.GetObject<IHeaderMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHeaderMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Headers", "", "Square.Retrofit2.Http.IHeadersInvoker")]
	public interface IHeaders : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()[Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IHeadersInvoker, Square.Retrofit2")]
		string[] Value();
	}
	[Register("retrofit2/http/Headers", DoNotGenerateAcw = true)]
	internal class IHeadersInvoker : Java.Lang.Object, IHeaders, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Headers", typeof(IHeadersInvoker));

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

		public static IHeaders GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHeaders>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Headers'.");
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

		public IHeadersInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
		}

		public string[] Value()
		{
			if (id_value == IntPtr.Zero)
			{
				id_value = JNIEnv.GetMethodID(class_ref, "value", "()[Ljava/lang/String;");
			}
			return (string[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_value), JniHandleOwnership.TransferLocalRef, typeof(string));
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IHeaders headers = Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return headers.Equals(obj);
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
			return Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/HTTP", "", "Square.Retrofit2.Http.IHTTPInvoker")]
	public interface IHTTP : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		bool HasBody
		{
			[Register("hasBody", "()Z", "GetHasBodyHandler:Square.Retrofit2.Http.IHTTPInvoker, Square.Retrofit2")]
			get;
		}

		[Register("method", "()Ljava/lang/String;", "GetMethodHandler:Square.Retrofit2.Http.IHTTPInvoker, Square.Retrofit2")]
		string Method();

		[Register("path", "()Ljava/lang/String;", "GetPathHandler:Square.Retrofit2.Http.IHTTPInvoker, Square.Retrofit2")]
		string Path();
	}
	[Register("retrofit2/http/HTTP", DoNotGenerateAcw = true)]
	internal class IHTTPInvoker : Java.Lang.Object, IHTTP, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/HTTP", typeof(IHTTPInvoker));

		private IntPtr class_ref;

		private static Delegate cb_hasBody;

		private IntPtr id_hasBody;

		private static Delegate cb_method;

		private IntPtr id_method;

		private static Delegate cb_path;

		private IntPtr id_path;

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

		public bool HasBody
		{
			get
			{
				if (id_hasBody == IntPtr.Zero)
				{
					id_hasBody = JNIEnv.GetMethodID(class_ref, "hasBody", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_hasBody);
			}
		}

		public static IHTTP GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHTTP>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.HTTP'.");
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

		public IHTTPInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetHasBodyHandler()
		{
			if ((object)cb_hasBody == null)
			{
				cb_hasBody = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasBody));
			}
			return cb_hasBody;
		}

		private static bool n_HasBody(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBody;
		}

		private static Delegate GetMethodHandler()
		{
			if ((object)cb_method == null)
			{
				cb_method = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Method));
			}
			return cb_method;
		}

		private static IntPtr n_Method(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Method());
		}

		public string Method()
		{
			if (id_method == IntPtr.Zero)
			{
				id_method = JNIEnv.GetMethodID(class_ref, "method", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_method), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPathHandler()
		{
			if ((object)cb_path == null)
			{
				cb_path = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Path));
			}
			return cb_path;
		}

		private static IntPtr n_Path(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Path());
		}

		public string Path()
		{
			if (id_path == IntPtr.Zero)
			{
				id_path = JNIEnv.GetMethodID(class_ref, "path", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_path), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IHTTP iHTTP = Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iHTTP.Equals(obj);
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
			return Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IHTTP>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Multipart", "", "Square.Retrofit2.Http.IMultipartInvoker")]
	public interface IMultipart : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/Multipart", DoNotGenerateAcw = true)]
	internal class IMultipartInvoker : Java.Lang.Object, IMultipart, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Multipart", typeof(IMultipartInvoker));

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

		public static IMultipart GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMultipart>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Multipart'.");
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

		public IMultipartInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMultipart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IMultipart multipart = Java.Lang.Object.GetObject<IMultipart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return multipart.Equals(obj);
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
			return Java.Lang.Object.GetObject<IMultipart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IMultipart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/OPTIONS", "", "Square.Retrofit2.Http.IOPTIONSInvoker")]
	public interface IOPTIONS : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IOPTIONSInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/OPTIONS", DoNotGenerateAcw = true)]
	internal class IOPTIONSInvoker : Java.Lang.Object, IOPTIONS, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/OPTIONS", typeof(IOPTIONSInvoker));

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

		public static IOPTIONS GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOPTIONS>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.OPTIONS'.");
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

		public IOPTIONSInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IOPTIONS>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOPTIONS>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IOPTIONS iOPTIONS = Java.Lang.Object.GetObject<IOPTIONS>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iOPTIONS.Equals(obj);
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
			return Java.Lang.Object.GetObject<IOPTIONS>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IOPTIONS>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Part", "", "Square.Retrofit2.Http.IPartInvoker")]
	public interface IPart : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoding", "()Ljava/lang/String;", "GetEncodingHandler:Square.Retrofit2.Http.IPartInvoker, Square.Retrofit2")]
		string Encoding();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IPartInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/Part", DoNotGenerateAcw = true)]
	internal class IPartInvoker : Java.Lang.Object, IPart, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Part", typeof(IPartInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoding;

		private IntPtr id_encoding;

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

		public static IPart GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPart>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Part'.");
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

		public IPartInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodingHandler()
		{
			if ((object)cb_encoding == null)
			{
				cb_encoding = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Encoding));
			}
			return cb_encoding;
		}

		private static IntPtr n_Encoding(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoding());
		}

		public string Encoding()
		{
			if (id_encoding == IntPtr.Zero)
			{
				id_encoding = JNIEnv.GetMethodID(class_ref, "encoding", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_encoding), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPart part = Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return part.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPart>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/PartMap", "", "Square.Retrofit2.Http.IPartMapInvoker")]
	public interface IPartMap : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoding", "()Ljava/lang/String;", "GetEncodingHandler:Square.Retrofit2.Http.IPartMapInvoker, Square.Retrofit2")]
		string Encoding();
	}
	[Register("retrofit2/http/PartMap", DoNotGenerateAcw = true)]
	internal class IPartMapInvoker : Java.Lang.Object, IPartMap, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/PartMap", typeof(IPartMapInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoding;

		private IntPtr id_encoding;

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

		public static IPartMap GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPartMap>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.PartMap'.");
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

		public IPartMapInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodingHandler()
		{
			if ((object)cb_encoding == null)
			{
				cb_encoding = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Encoding));
			}
			return cb_encoding;
		}

		private static IntPtr n_Encoding(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPartMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoding());
		}

		public string Encoding()
		{
			if (id_encoding == IntPtr.Zero)
			{
				id_encoding = JNIEnv.GetMethodID(class_ref, "encoding", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_encoding), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPartMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPartMap partMap = Java.Lang.Object.GetObject<IPartMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return partMap.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPartMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPartMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/PATCH", "", "Square.Retrofit2.Http.IPATCHInvoker")]
	public interface IPATCH : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IPATCHInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/PATCH", DoNotGenerateAcw = true)]
	internal class IPATCHInvoker : Java.Lang.Object, IPATCH, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/PATCH", typeof(IPATCHInvoker));

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

		public static IPATCH GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPATCH>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.PATCH'.");
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

		public IPATCHInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPATCH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPATCH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPATCH iPATCH = Java.Lang.Object.GetObject<IPATCH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iPATCH.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPATCH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPATCH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Path", "", "Square.Retrofit2.Http.IPathInvoker")]
	public interface IPath : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IPathInvoker, Square.Retrofit2")]
		bool Encoded();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IPathInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/Path", DoNotGenerateAcw = true)]
	internal class IPathInvoker : Java.Lang.Object, IPath, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Path", typeof(IPathInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IPath GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPath>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Path'.");
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

		public IPathInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPath path = Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return path.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPath>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/POST", "", "Square.Retrofit2.Http.IPOSTInvoker")]
	public interface IPOST : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IPOSTInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/POST", DoNotGenerateAcw = true)]
	internal class IPOSTInvoker : Java.Lang.Object, IPOST, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/POST", typeof(IPOSTInvoker));

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

		public static IPOST GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPOST>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.POST'.");
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

		public IPOSTInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPOST>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPOST>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPOST iPOST = Java.Lang.Object.GetObject<IPOST>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iPOST.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPOST>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPOST>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/PUT", "", "Square.Retrofit2.Http.IPUTInvoker")]
	public interface IPUT : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IPUTInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/PUT", DoNotGenerateAcw = true)]
	internal class IPUTInvoker : Java.Lang.Object, IPUT, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/PUT", typeof(IPUTInvoker));

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

		public static IPUT GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IPUT>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.PUT'.");
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

		public IPUTInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPUT>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPUT>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IPUT iPUT = Java.Lang.Object.GetObject<IPUT>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return iPUT.Equals(obj);
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
			return Java.Lang.Object.GetObject<IPUT>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IPUT>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Query", "", "Square.Retrofit2.Http.IQueryInvoker")]
	public interface IQuery : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IQueryInvoker, Square.Retrofit2")]
		bool Encoded();

		[Register("value", "()Ljava/lang/String;", "GetValueHandler:Square.Retrofit2.Http.IQueryInvoker, Square.Retrofit2")]
		string Value();
	}
	[Register("retrofit2/http/Query", DoNotGenerateAcw = true)]
	internal class IQueryInvoker : Java.Lang.Object, IQuery, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Query", typeof(IQueryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IQuery GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IQuery>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Query'.");
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

		public IQueryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value());
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IQuery query = Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return query.Equals(obj);
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
			return Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IQuery>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/QueryMap", "", "Square.Retrofit2.Http.IQueryMapInvoker")]
	public interface IQueryMap : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IQueryMapInvoker, Square.Retrofit2")]
		bool Encoded();
	}
	[Register("retrofit2/http/QueryMap", DoNotGenerateAcw = true)]
	internal class IQueryMapInvoker : Java.Lang.Object, IQueryMap, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/QueryMap", typeof(IQueryMapInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IQueryMap GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IQueryMap>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.QueryMap'.");
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

		public IQueryMapInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IQueryMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IQueryMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IQueryMap queryMap = Java.Lang.Object.GetObject<IQueryMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return queryMap.Equals(obj);
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
			return Java.Lang.Object.GetObject<IQueryMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IQueryMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/QueryName", "", "Square.Retrofit2.Http.IQueryNameInvoker")]
	public interface IQueryName : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("encoded", "()Z", "GetEncodedHandler:Square.Retrofit2.Http.IQueryNameInvoker, Square.Retrofit2")]
		bool Encoded();
	}
	[Register("retrofit2/http/QueryName", DoNotGenerateAcw = true)]
	internal class IQueryNameInvoker : Java.Lang.Object, IQueryName, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/QueryName", typeof(IQueryNameInvoker));

		private IntPtr class_ref;

		private static Delegate cb_encoded;

		private IntPtr id_encoded;

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

		public static IQueryName GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IQueryName>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.QueryName'.");
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

		public IQueryNameInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEncodedHandler()
		{
			if ((object)cb_encoded == null)
			{
				cb_encoded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Encoded));
			}
			return cb_encoded;
		}

		private static bool n_Encoded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IQueryName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Encoded();
		}

		public bool Encoded()
		{
			if (id_encoded == IntPtr.Zero)
			{
				id_encoded = JNIEnv.GetMethodID(class_ref, "encoded", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_encoded);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IQueryName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IQueryName queryName = Java.Lang.Object.GetObject<IQueryName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return queryName.Equals(obj);
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
			return Java.Lang.Object.GetObject<IQueryName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IQueryName>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Streaming", "", "Square.Retrofit2.Http.IStreamingInvoker")]
	public interface IStreaming : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/Streaming", DoNotGenerateAcw = true)]
	internal class IStreamingInvoker : Java.Lang.Object, IStreaming, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Streaming", typeof(IStreamingInvoker));

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

		public static IStreaming GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStreaming>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Streaming'.");
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

		public IStreamingInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IStreaming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IStreaming streaming = Java.Lang.Object.GetObject<IStreaming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return streaming.Equals(obj);
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
			return Java.Lang.Object.GetObject<IStreaming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IStreaming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Tag", "", "Square.Retrofit2.Http.ITagInvoker")]
	public interface ITag : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/Tag", DoNotGenerateAcw = true)]
	internal class ITagInvoker : Java.Lang.Object, ITag, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Tag", typeof(ITagInvoker));

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

		public static ITag GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITag>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Tag'.");
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

		public ITagInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			ITag tag = Java.Lang.Object.GetObject<ITag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return tag.Equals(obj);
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
			return Java.Lang.Object.GetObject<ITag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ITag>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Register("retrofit2/http/Url", "", "Square.Retrofit2.Http.IUrlInvoker")]
	public interface IUrl : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/http/Url", DoNotGenerateAcw = true)]
	internal class IUrlInvoker : Java.Lang.Object, IUrl, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/http/Url", typeof(IUrlInvoker));

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

		public static IUrl GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IUrl>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.http.Url'.");
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

		public IUrlInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IUrl url = Java.Lang.Object.GetObject<IUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return url.Equals(obj);
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
			return Java.Lang.Object.GetObject<IUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	[Annotation("retrofit2.http.Multipart")]
	public class MultipartAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.OPTIONS")]
	public class OPTIONSAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.Part")]
	public class PartAttribute : Attribute
	{
		[Register("encoding")]
		public string Encoding { get; set; }

		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.PartMap")]
	public class PartMapAttribute : Attribute
	{
		[Register("encoding")]
		public string Encoding { get; set; }
	}
	[Annotation("retrofit2.http.PATCH")]
	public class PATCHAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.Path")]
	public class PathAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }

		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.POST")]
	public class POSTAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.PUT")]
	public class PUTAttribute : Attribute
	{
		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.Query")]
	public class QueryAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }

		[Register("value")]
		public string Value { get; set; }
	}
	[Annotation("retrofit2.http.QueryMap")]
	public class QueryMapAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }
	}
	[Annotation("retrofit2.http.QueryName")]
	public class QueryNameAttribute : Attribute
	{
		[Register("encoded")]
		public bool Encoded { get; set; }
	}
	[Annotation("retrofit2.http.Streaming")]
	public class StreamingAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.Tag")]
	public class TagAttribute : Attribute
	{
	}
	[Annotation("retrofit2.http.Url")]
	public class UrlAttribute : Attribute
	{
	}
}
namespace Retrofit2.Internal
{
	[Annotation("retrofit2.internal.EverythingIsNonNull")]
	public class EverythingIsNonNullAttribute : Attribute
	{
	}
	[Register("retrofit2/internal/EverythingIsNonNull", "", "Retrofit2.Internal.IEverythingIsNonNullInvoker")]
	public interface IEverythingIsNonNull : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("retrofit2/internal/EverythingIsNonNull", DoNotGenerateAcw = true)]
	internal class IEverythingIsNonNullInvoker : Java.Lang.Object, IEverythingIsNonNull, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/internal/EverythingIsNonNull", typeof(IEverythingIsNonNullInvoker));

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

		public static IEverythingIsNonNull GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IEverythingIsNonNull>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'retrofit2.internal.EverythingIsNonNull'.");
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

		public IEverythingIsNonNullInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEverythingIsNonNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
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
			IEverythingIsNonNull everythingIsNonNull = Java.Lang.Object.GetObject<IEverythingIsNonNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return everythingIsNonNull.Equals(obj);
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
			return Java.Lang.Object.GetObject<IEverythingIsNonNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IEverythingIsNonNull>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_retrofit2_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "retrofit2" }, new Converter<string, Type>[1] { lookup_retrofit2_package });
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

		private static Type lookup_retrofit2_package(string klass)
		{
			if (package_retrofit2_mappings == null)
			{
				package_retrofit2_mappings = new string[8] { "retrofit2/CallAdapter$Factory:Square.Retrofit2.CallAdapterFactory", "retrofit2/Converter$Factory:Square.Retrofit2.ConverterFactory", "retrofit2/HttpException:Square.Retrofit2.HttpException", "retrofit2/Invocation:Square.Retrofit2.Invocation", "retrofit2/KotlinExtensions:Square.Retrofit2.KotlinExtensions", "retrofit2/Response:Square.Retrofit2.Response", "retrofit2/Retrofit:Square.Retrofit2.Retrofit", "retrofit2/Retrofit$Builder:Square.Retrofit2.Retrofit/Builder" };
			}
			return Lookup(package_retrofit2_mappings, klass);
		}
	}
}
