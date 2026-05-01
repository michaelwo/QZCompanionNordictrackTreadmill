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
using Android.Gms.Tasks;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a0fa1472deb92370c554f5762558eb29933bf602")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220811.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "8/11/2022 10:05:08 AM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.android.gms.tasks", Managed = "Android.Gms.Tasks")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\n        Xamarin.Android Bindings for Google Play Services - Tasks 118.0.2 artifact=com.google.android.gms:play-services-tasks artifact_versioned=com.google.android.gms:play-services-tasks:18.0.2\n\n        \n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Tasks")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Tasks")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
namespace Android.Gms.Tasks
{
	[Register("com/google/android/gms/tasks/Task", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "TResult" })]
	public abstract class Task : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/Task", typeof(Task));

		private static Delegate cb_getException;

		private static Delegate cb_isCanceled;

		private static Delegate cb_isComplete;

		private static Delegate cb_isSuccessful;

		private static Delegate cb_getResult;

		private static Delegate cb_addOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_;

		private static Delegate cb_addOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_;

		private static Delegate cb_addOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_;

		private static Delegate cb_addOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_;

		private static Delegate cb_addOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_;

		private static Delegate cb_addOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_;

		private static Delegate cb_addOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_;

		private static Delegate cb_addOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_;

		private static Delegate cb_addOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_;

		private static Delegate cb_addOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_;

		private static Delegate cb_addOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_;

		private static Delegate cb_addOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_;

		private static Delegate cb_continueWith_Lcom_google_android_gms_tasks_Continuation_;

		private static Delegate cb_continueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_;

		private static Delegate cb_continueWithTask_Lcom_google_android_gms_tasks_Continuation_;

		private static Delegate cb_continueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_;

		private static Delegate cb_getResult_Ljava_lang_Class_;

		private static Delegate cb_onSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_;

		private static Delegate cb_onSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_;

		public virtual Java.Lang.Object Result => RawResult;

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

		public abstract Java.Lang.Exception Exception
		{
			[Register("getException", "()Ljava/lang/Exception;", "GetGetExceptionHandler")]
			get;
		}

		public abstract bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
			get;
		}

		public abstract bool IsComplete
		{
			[Register("isComplete", "()Z", "GetIsCompleteHandler")]
			get;
		}

		public abstract bool IsSuccessful
		{
			[Register("isSuccessful", "()Z", "GetIsSuccessfulHandler")]
			get;
		}

		protected abstract Java.Lang.Object RawResult
		{
			[Register("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
			get;
		}

		protected Task(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Task()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetExceptionHandler()
		{
			if ((object)cb_getException == null)
			{
				cb_getException = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetException));
			}
			return cb_getException;
		}

		private static IntPtr n_GetException(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exception);
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
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCanceled;
		}

		private static Delegate GetIsCompleteHandler()
		{
			if ((object)cb_isComplete == null)
			{
				cb_isComplete = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsComplete));
			}
			return cb_isComplete;
		}

		private static bool n_IsComplete(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsComplete;
		}

		private static Delegate GetIsSuccessfulHandler()
		{
			if ((object)cb_isSuccessful == null)
			{
				cb_isSuccessful = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSuccessful));
			}
			return cb_isSuccessful;
		}

		private static bool n_IsSuccessful(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSuccessful;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RawResult);
		}

		private static Delegate GetAddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
		{
			if ((object)cb_addOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_ == null)
			{
				cb_addOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_));
			}
			return cb_addOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_;
		}

		private static IntPtr n_AddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p2 = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p, p2));
		}

		[Register("addOnCanceledListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
		public unsafe virtual Task AddOnCanceledListener(Activity p0, IOnCanceledListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetAddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
		{
			if ((object)cb_addOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_ == null)
			{
				cb_addOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_));
			}
			return cb_addOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_;
		}

		private static IntPtr n_AddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p));
		}

		[Register("addOnCanceledListener", "(Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
		public unsafe virtual Task AddOnCanceledListener(IOnCanceledListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetAddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
		{
			if ((object)cb_addOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_ == null)
			{
				cb_addOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_));
			}
			return cb_addOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_;
		}

		private static IntPtr n_AddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p2 = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p, p2));
		}

		[Register("addOnCanceledListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
		public unsafe virtual Task AddOnCanceledListener(IExecutor p0, IOnCanceledListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetAddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
		{
			if ((object)cb_addOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_ == null)
			{
				cb_addOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_));
			}
			return cb_addOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_;
		}

		private static IntPtr n_AddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p2 = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p, p2));
		}

		[Register("addOnCompleteListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
		public unsafe virtual Task AddOnCompleteListener(Activity p0, IOnCompleteListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetAddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
		{
			if ((object)cb_addOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_ == null)
			{
				cb_addOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_));
			}
			return cb_addOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_;
		}

		private static IntPtr n_AddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p));
		}

		[Register("addOnCompleteListener", "(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
		public unsafe virtual Task AddOnCompleteListener(IOnCompleteListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetAddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
		{
			if ((object)cb_addOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_ == null)
			{
				cb_addOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_));
			}
			return cb_addOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_;
		}

		private static IntPtr n_AddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p2 = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p, p2));
		}

		[Register("addOnCompleteListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
		public unsafe virtual Task AddOnCompleteListener(IExecutor p0, IOnCompleteListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
		{
			if ((object)cb_addOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_ == null)
			{
				cb_addOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_));
			}
			return cb_addOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_;
		}

		private static IntPtr n_AddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p2 = Java.Lang.Object.GetObject<IOnFailureListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p, p2));
		}

		[Register("addOnFailureListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public abstract Task AddOnFailureListener(Activity p0, IOnFailureListener p1);

		private static Delegate GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
		{
			if ((object)cb_addOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_ == null)
			{
				cb_addOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_));
			}
			return cb_addOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_;
		}

		private static IntPtr n_AddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p = Java.Lang.Object.GetObject<IOnFailureListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p));
		}

		[Register("addOnFailureListener", "(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public abstract Task AddOnFailureListener(IOnFailureListener p0);

		private static Delegate GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
		{
			if ((object)cb_addOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_ == null)
			{
				cb_addOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_));
			}
			return cb_addOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_;
		}

		private static IntPtr n_AddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p2 = Java.Lang.Object.GetObject<IOnFailureListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p, p2));
		}

		[Register("addOnFailureListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public abstract Task AddOnFailureListener(IExecutor p0, IOnFailureListener p1);

		private static Delegate GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
		{
			if ((object)cb_addOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_ == null)
			{
				cb_addOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_));
			}
			return cb_addOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_;
		}

		private static IntPtr n_AddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p2 = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p, p2));
		}

		[Register("addOnSuccessListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public abstract Task AddOnSuccessListener(Activity p0, IOnSuccessListener p1);

		private static Delegate GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
		{
			if ((object)cb_addOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_ == null)
			{
				cb_addOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_));
			}
			return cb_addOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_;
		}

		private static IntPtr n_AddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p));
		}

		[Register("addOnSuccessListener", "(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public abstract Task AddOnSuccessListener(IOnSuccessListener p0);

		private static Delegate GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
		{
			if ((object)cb_addOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_ == null)
			{
				cb_addOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_));
			}
			return cb_addOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_;
		}

		private static IntPtr n_AddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p2 = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p, p2));
		}

		[Register("addOnSuccessListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public abstract Task AddOnSuccessListener(IExecutor p0, IOnSuccessListener p1);

		private static Delegate GetContinueWith_Lcom_google_android_gms_tasks_Continuation_Handler()
		{
			if ((object)cb_continueWith_Lcom_google_android_gms_tasks_Continuation_ == null)
			{
				cb_continueWith_Lcom_google_android_gms_tasks_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ContinueWith_Lcom_google_android_gms_tasks_Continuation_));
			}
			return cb_continueWith_Lcom_google_android_gms_tasks_Continuation_;
		}

		private static IntPtr n_ContinueWith_Lcom_google_android_gms_tasks_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWith(p));
		}

		[Register("continueWith", "(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWith_Lcom_google_android_gms_tasks_Continuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task ContinueWith(IContinuation p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWith.(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler()
		{
			if ((object)cb_continueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_ == null)
			{
				cb_continueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_));
			}
			return cb_continueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_;
		}

		private static IntPtr n_ContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IContinuation p2 = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWith(p, p2));
		}

		[Register("continueWith", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task ContinueWith(IExecutor p0, IContinuation p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWith.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetContinueWithTask_Lcom_google_android_gms_tasks_Continuation_Handler()
		{
			if ((object)cb_continueWithTask_Lcom_google_android_gms_tasks_Continuation_ == null)
			{
				cb_continueWithTask_Lcom_google_android_gms_tasks_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ContinueWithTask_Lcom_google_android_gms_tasks_Continuation_));
			}
			return cb_continueWithTask_Lcom_google_android_gms_tasks_Continuation_;
		}

		private static IntPtr n_ContinueWithTask_Lcom_google_android_gms_tasks_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWithTask(p));
		}

		[Register("continueWithTask", "(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWithTask_Lcom_google_android_gms_tasks_Continuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task ContinueWithTask(IContinuation p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWithTask.(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler()
		{
			if ((object)cb_continueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_ == null)
			{
				cb_continueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_ContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_));
			}
			return cb_continueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_;
		}

		private static IntPtr n_ContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IContinuation p2 = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWithTask(p, p2));
		}

		[Register("continueWithTask", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task ContinueWithTask(IExecutor p0, IContinuation p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWithTask.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetGetResult_Ljava_lang_Class_Handler()
		{
			if ((object)cb_getResult_Ljava_lang_Class_ == null)
			{
				cb_getResult_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetResult_Ljava_lang_Class_));
			}
			return cb_getResult_Ljava_lang_Class_;
		}

		private static IntPtr n_GetResult_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class p = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.GetResult(p));
		}

		[Register("getResult", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGetResult_Ljava_lang_Class_Handler")]
		[JavaTypeParameters(new string[] { "X extends java.lang.Throwable" })]
		public abstract Java.Lang.Object GetResult(Class p0);

		private static Delegate GetOnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_Handler()
		{
			if ((object)cb_onSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_ == null)
			{
				cb_onSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_));
			}
			return cb_onSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_;
		}

		private static IntPtr n_OnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISuccessContinuation p = Java.Lang.Object.GetObject<ISuccessContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.OnSuccessTask(p));
		}

		[Register("onSuccessTask", "(Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", "GetOnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task OnSuccessTask(ISuccessContinuation p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuccessTask.(Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetOnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_Handler()
		{
			if ((object)cb_onSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_ == null)
			{
				cb_onSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_OnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_));
			}
			return cb_onSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_;
		}

		private static IntPtr n_OnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			Task task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			ISuccessContinuation p2 = Java.Lang.Object.GetObject<ISuccessContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.OnSuccessTask(p, p2));
		}

		[Register("onSuccessTask", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", "GetOnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_Handler")]
		[JavaTypeParameters(new string[] { "TContinuationResult" })]
		public unsafe virtual Task OnSuccessTask(IExecutor p0, ISuccessContinuation p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuccessTask.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}
	}
	[Register("com/google/android/gms/tasks/TaskCompletionSource", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "TResult" })]
	public class TaskCompletionSource : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/TaskCompletionSource", typeof(TaskCompletionSource));

		private static Delegate cb_getTask;

		private static Delegate cb_setException_Ljava_lang_Exception_;

		private static Delegate cb_setResult_Ljava_lang_Object_;

		private static Delegate cb_trySetException_Ljava_lang_Exception_;

		private static Delegate cb_trySetResult_Ljava_lang_Object_;

		public virtual Task Task => GetTask();

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

		protected TaskCompletionSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TaskCompletionSource()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lcom/google/android/gms/tasks/CancellationToken;)V", "")]
		public unsafe TaskCompletionSource(CancellationToken cancellationToken)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cancellationToken?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/tasks/CancellationToken;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/tasks/CancellationToken;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cancellationToken);
			}
		}

		private static Delegate GetGetTaskHandler()
		{
			if ((object)cb_getTask == null)
			{
				cb_getTask = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTask));
			}
			return cb_getTask;
		}

		private static IntPtr n_GetTask(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTask());
		}

		[Register("getTask", "()Lcom/google/android/gms/tasks/Task;", "GetGetTaskHandler")]
		public unsafe virtual Task GetTask()
		{
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTask.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetException_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_setException_Ljava_lang_Exception_ == null)
			{
				cb_setException_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetException_Ljava_lang_Exception_));
			}
			return cb_setException_Ljava_lang_Exception_;
		}

		private static void n_SetException_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			TaskCompletionSource taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception exception = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			taskCompletionSource.SetException(exception);
		}

		[Register("setException", "(Ljava/lang/Exception;)V", "GetSetException_Ljava_lang_Exception_Handler")]
		public unsafe virtual void SetException(Java.Lang.Exception e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setException.(Ljava/lang/Exception;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetSetResult_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setResult_Ljava_lang_Object_ == null)
			{
				cb_setResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetResult_Ljava_lang_Object_));
			}
			return cb_setResult_Ljava_lang_Object_;
		}

		private static void n_SetResult_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			TaskCompletionSource taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			taskCompletionSource.SetResult(result);
		}

		[Register("setResult", "(Ljava/lang/Object;)V", "GetSetResult_Ljava_lang_Object_Handler")]
		public unsafe virtual void SetResult(Java.Lang.Object result)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setResult.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetTrySetException_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_trySetException_Ljava_lang_Exception_ == null)
			{
				cb_trySetException_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_TrySetException_Ljava_lang_Exception_));
			}
			return cb_trySetException_Ljava_lang_Exception_;
		}

		private static bool n_TrySetException_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			TaskCompletionSource taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			return taskCompletionSource.TrySetException(e);
		}

		[Register("trySetException", "(Ljava/lang/Exception;)Z", "GetTrySetException_Ljava_lang_Exception_Handler")]
		public unsafe virtual bool TrySetException(Java.Lang.Exception e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("trySetException.(Ljava/lang/Exception;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetTrySetResult_Ljava_lang_Object_Handler()
		{
			if ((object)cb_trySetResult_Ljava_lang_Object_ == null)
			{
				cb_trySetResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_TrySetResult_Ljava_lang_Object_));
			}
			return cb_trySetResult_Ljava_lang_Object_;
		}

		private static bool n_TrySetResult_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			TaskCompletionSource taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			return taskCompletionSource.TrySetResult(result);
		}

		[Register("trySetResult", "(Ljava/lang/Object;)Z", "GetTrySetResult_Ljava_lang_Object_Handler")]
		public unsafe virtual bool TrySetResult(Java.Lang.Object result)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("trySetResult.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}
	}
	[Register("com/google/android/gms/tasks/CancellationToken", DoNotGenerateAcw = true)]
	public abstract class CancellationToken : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/CancellationToken", typeof(CancellationToken));

		private static Delegate cb_isCancellationRequested;

		private static Delegate cb_onCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_;

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

		public abstract bool IsCancellationRequested
		{
			[Register("isCancellationRequested", "()Z", "GetIsCancellationRequestedHandler")]
			get;
		}

		protected CancellationToken(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CancellationToken()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsCancellationRequestedHandler()
		{
			if ((object)cb_isCancellationRequested == null)
			{
				cb_isCancellationRequested = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCancellationRequested));
			}
			return cb_isCancellationRequested;
		}

		private static bool n_IsCancellationRequested(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<CancellationToken>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancellationRequested;
		}

		private static Delegate GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler()
		{
			if ((object)cb_onCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_ == null)
			{
				cb_onCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_OnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_));
			}
			return cb_onCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_;
		}

		private static IntPtr n_OnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			CancellationToken cancellationToken = Java.Lang.Object.GetObject<CancellationToken>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTokenCanceledListener p = Java.Lang.Object.GetObject<IOnTokenCanceledListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cancellationToken.OnCanceledRequested(p));
		}

		[Register("onCanceledRequested", "(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", "GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler")]
		public abstract CancellationToken OnCanceledRequested(IOnTokenCanceledListener p0);
	}
	[Register("com/google/android/gms/tasks/CancellationToken", DoNotGenerateAcw = true)]
	internal class CancellationTokenInvoker : CancellationToken
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/CancellationToken", typeof(CancellationTokenInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsCancellationRequested
		{
			[Register("isCancellationRequested", "()Z", "GetIsCancellationRequestedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCancellationRequested.()Z", this, null);
			}
		}

		public CancellationTokenInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onCanceledRequested", "(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", "GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler")]
		public unsafe override CancellationToken OnCanceledRequested(IOnTokenCanceledListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<CancellationToken>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCanceledRequested.(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/google/android/gms/tasks/Continuation", "", "Android.Gms.Tasks.IContinuationInvoker")]
	[JavaTypeParameters(new string[] { "TResult", "TContinuationResult" })]
	public interface IContinuation : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("then", "(Lcom/google/android/gms/tasks/Task;)Ljava/lang/Object;", "GetThen_Lcom_google_android_gms_tasks_Task_Handler:Android.Gms.Tasks.IContinuationInvoker, Xamarin.GooglePlayServices.Tasks")]
		Java.Lang.Object Then(Task task);
	}
	[Register("com/google/android/gms/tasks/Continuation", DoNotGenerateAcw = true)]
	internal class IContinuationInvoker : Java.Lang.Object, IContinuation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/Continuation", typeof(IContinuationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_then_Lcom_google_android_gms_tasks_Task_;

		private IntPtr id_then_Lcom_google_android_gms_tasks_Task_;

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

		public static IContinuation GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IContinuation>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.Continuation'.");
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

		public IContinuationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetThen_Lcom_google_android_gms_tasks_Task_Handler()
		{
			if ((object)cb_then_Lcom_google_android_gms_tasks_Task_ == null)
			{
				cb_then_Lcom_google_android_gms_tasks_Task_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Then_Lcom_google_android_gms_tasks_Task_));
			}
			return cb_then_Lcom_google_android_gms_tasks_Task_;
		}

		private static IntPtr n_Then_Lcom_google_android_gms_tasks_Task_(IntPtr jnienv, IntPtr native__this, IntPtr native_task)
		{
			IContinuation continuation = Java.Lang.Object.GetObject<IContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Task task = Java.Lang.Object.GetObject<Task>(native_task, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(continuation.Then(task));
		}

		public unsafe Java.Lang.Object Then(Task task)
		{
			if (id_then_Lcom_google_android_gms_tasks_Task_ == IntPtr.Zero)
			{
				id_then_Lcom_google_android_gms_tasks_Task_ = JNIEnv.GetMethodID(class_ref, "then", "(Lcom/google/android/gms/tasks/Task;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(task?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_then_Lcom_google_android_gms_tasks_Task_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/tasks/OnCanceledListener", "", "Android.Gms.Tasks.IOnCanceledListenerInvoker")]
	public interface IOnCanceledListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCanceled", "()V", "GetOnCanceledHandler:Android.Gms.Tasks.IOnCanceledListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
		void OnCanceled();
	}
	[Register("com/google/android/gms/tasks/OnCanceledListener", DoNotGenerateAcw = true)]
	internal class IOnCanceledListenerInvoker : Java.Lang.Object, IOnCanceledListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/OnCanceledListener", typeof(IOnCanceledListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCanceled;

		private IntPtr id_onCanceled;

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

		public static IOnCanceledListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnCanceledListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.OnCanceledListener'.");
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

		public IOnCanceledListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCanceledHandler()
		{
			if ((object)cb_onCanceled == null)
			{
				cb_onCanceled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCanceled));
			}
			return cb_onCanceled;
		}

		private static void n_OnCanceled(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IOnCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCanceled();
		}

		public void OnCanceled()
		{
			if (id_onCanceled == IntPtr.Zero)
			{
				id_onCanceled = JNIEnv.GetMethodID(class_ref, "onCanceled", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onCanceled);
		}
	}
	[Register("com/google/android/gms/tasks/OnCompleteListener", "", "Android.Gms.Tasks.IOnCompleteListenerInvoker")]
	[JavaTypeParameters(new string[] { "TResult" })]
	public interface IOnCompleteListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onComplete", "(Lcom/google/android/gms/tasks/Task;)V", "GetOnComplete_Lcom_google_android_gms_tasks_Task_Handler:Android.Gms.Tasks.IOnCompleteListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
		void OnComplete(Task task);
	}
	[Register("com/google/android/gms/tasks/OnCompleteListener", DoNotGenerateAcw = true)]
	internal class IOnCompleteListenerInvoker : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/OnCompleteListener", typeof(IOnCompleteListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onComplete_Lcom_google_android_gms_tasks_Task_;

		private IntPtr id_onComplete_Lcom_google_android_gms_tasks_Task_;

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

		public static IOnCompleteListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnCompleteListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.OnCompleteListener'.");
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

		public IOnCompleteListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnComplete_Lcom_google_android_gms_tasks_Task_Handler()
		{
			if ((object)cb_onComplete_Lcom_google_android_gms_tasks_Task_ == null)
			{
				cb_onComplete_Lcom_google_android_gms_tasks_Task_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnComplete_Lcom_google_android_gms_tasks_Task_));
			}
			return cb_onComplete_Lcom_google_android_gms_tasks_Task_;
		}

		private static void n_OnComplete_Lcom_google_android_gms_tasks_Task_(IntPtr jnienv, IntPtr native__this, IntPtr native_task)
		{
			IOnCompleteListener onCompleteListener = Java.Lang.Object.GetObject<IOnCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Task task = Java.Lang.Object.GetObject<Task>(native_task, JniHandleOwnership.DoNotTransfer);
			onCompleteListener.OnComplete(task);
		}

		public unsafe void OnComplete(Task task)
		{
			if (id_onComplete_Lcom_google_android_gms_tasks_Task_ == IntPtr.Zero)
			{
				id_onComplete_Lcom_google_android_gms_tasks_Task_ = JNIEnv.GetMethodID(class_ref, "onComplete", "(Lcom/google/android/gms/tasks/Task;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(task?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onComplete_Lcom_google_android_gms_tasks_Task_, ptr);
		}
	}
	[Register("com/google/android/gms/tasks/OnFailureListener", "", "Android.Gms.Tasks.IOnFailureListenerInvoker")]
	public interface IOnFailureListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFailure", "(Ljava/lang/Exception;)V", "GetOnFailure_Ljava_lang_Exception_Handler:Android.Gms.Tasks.IOnFailureListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
		void OnFailure(Java.Lang.Exception e);
	}
	[Register("com/google/android/gms/tasks/OnFailureListener", DoNotGenerateAcw = true)]
	internal class IOnFailureListenerInvoker : Java.Lang.Object, IOnFailureListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/OnFailureListener", typeof(IOnFailureListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onFailure_Ljava_lang_Exception_;

		private IntPtr id_onFailure_Ljava_lang_Exception_;

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

		public static IOnFailureListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnFailureListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.OnFailureListener'.");
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

		public IOnFailureListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnFailure_Ljava_lang_Exception_Handler()
		{
			if ((object)cb_onFailure_Ljava_lang_Exception_ == null)
			{
				cb_onFailure_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnFailure_Ljava_lang_Exception_));
			}
			return cb_onFailure_Ljava_lang_Exception_;
		}

		private static void n_OnFailure_Ljava_lang_Exception_(IntPtr jnienv, IntPtr native__this, IntPtr native_e)
		{
			IOnFailureListener onFailureListener = Java.Lang.Object.GetObject<IOnFailureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			onFailureListener.OnFailure(e);
		}

		public unsafe void OnFailure(Java.Lang.Exception e)
		{
			if (id_onFailure_Ljava_lang_Exception_ == IntPtr.Zero)
			{
				id_onFailure_Ljava_lang_Exception_ = JNIEnv.GetMethodID(class_ref, "onFailure", "(Ljava/lang/Exception;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(e?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onFailure_Ljava_lang_Exception_, ptr);
		}
	}
	[Register("com/google/android/gms/tasks/OnSuccessListener", "", "Android.Gms.Tasks.IOnSuccessListenerInvoker")]
	[JavaTypeParameters(new string[] { "TResult" })]
	public interface IOnSuccessListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSuccess", "(Ljava/lang/Object;)V", "GetOnSuccess_Ljava_lang_Object_Handler:Android.Gms.Tasks.IOnSuccessListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
		void OnSuccess(Java.Lang.Object result);
	}
	[Register("com/google/android/gms/tasks/OnSuccessListener", DoNotGenerateAcw = true)]
	internal class IOnSuccessListenerInvoker : Java.Lang.Object, IOnSuccessListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/OnSuccessListener", typeof(IOnSuccessListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onSuccess_Ljava_lang_Object_;

		private IntPtr id_onSuccess_Ljava_lang_Object_;

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

		public static IOnSuccessListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnSuccessListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.OnSuccessListener'.");
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

		public IOnSuccessListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnSuccess_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onSuccess_Ljava_lang_Object_ == null)
			{
				cb_onSuccess_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSuccess_Ljava_lang_Object_));
			}
			return cb_onSuccess_Ljava_lang_Object_;
		}

		private static void n_OnSuccess_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			IOnSuccessListener onSuccessListener = Java.Lang.Object.GetObject<IOnSuccessListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			onSuccessListener.OnSuccess(result);
		}

		public unsafe void OnSuccess(Java.Lang.Object result)
		{
			if (id_onSuccess_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_onSuccess_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onSuccess_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("com/google/android/gms/tasks/OnTokenCanceledListener", "", "Android.Gms.Tasks.IOnTokenCanceledListenerInvoker")]
	public interface IOnTokenCanceledListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCanceled", "()V", "GetOnCanceledHandler:Android.Gms.Tasks.IOnTokenCanceledListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
		void OnCanceled();
	}
	[Register("com/google/android/gms/tasks/OnTokenCanceledListener", DoNotGenerateAcw = true)]
	internal class IOnTokenCanceledListenerInvoker : Java.Lang.Object, IOnTokenCanceledListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/OnTokenCanceledListener", typeof(IOnTokenCanceledListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onCanceled;

		private IntPtr id_onCanceled;

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

		public static IOnTokenCanceledListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnTokenCanceledListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.OnTokenCanceledListener'.");
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

		public IOnTokenCanceledListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCanceledHandler()
		{
			if ((object)cb_onCanceled == null)
			{
				cb_onCanceled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCanceled));
			}
			return cb_onCanceled;
		}

		private static void n_OnCanceled(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IOnTokenCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCanceled();
		}

		public void OnCanceled()
		{
			if (id_onCanceled == IntPtr.Zero)
			{
				id_onCanceled = JNIEnv.GetMethodID(class_ref, "onCanceled", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onCanceled);
		}
	}
	[Register("com/google/android/gms/tasks/SuccessContinuation", "", "Android.Gms.Tasks.ISuccessContinuationInvoker")]
	[JavaTypeParameters(new string[] { "TResult", "TContinuationResult" })]
	public interface ISuccessContinuation : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("then", "(Ljava/lang/Object;)Lcom/google/android/gms/tasks/Task;", "GetThen_Ljava_lang_Object_Handler:Android.Gms.Tasks.ISuccessContinuationInvoker, Xamarin.GooglePlayServices.Tasks")]
		Task Then(Java.Lang.Object result);
	}
	[Register("com/google/android/gms/tasks/SuccessContinuation", DoNotGenerateAcw = true)]
	internal class ISuccessContinuationInvoker : Java.Lang.Object, ISuccessContinuation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/SuccessContinuation", typeof(ISuccessContinuationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_then_Ljava_lang_Object_;

		private IntPtr id_then_Ljava_lang_Object_;

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

		public static ISuccessContinuation GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISuccessContinuation>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.tasks.SuccessContinuation'.");
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

		public ISuccessContinuationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetThen_Ljava_lang_Object_Handler()
		{
			if ((object)cb_then_Ljava_lang_Object_ == null)
			{
				cb_then_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Then_Ljava_lang_Object_));
			}
			return cb_then_Ljava_lang_Object_;
		}

		private static IntPtr n_Then_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			ISuccessContinuation successContinuation = Java.Lang.Object.GetObject<ISuccessContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(successContinuation.Then(result));
		}

		public unsafe Task Then(Java.Lang.Object result)
		{
			if (id_then_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_then_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "then", "(Ljava/lang/Object;)Lcom/google/android/gms/tasks/Task;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			Task result2 = Java.Lang.Object.GetObject<Task>(JNIEnv.CallObjectMethod(base.Handle, id_then_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result2;
		}
	}
	[Register("com/google/android/gms/tasks/Task", DoNotGenerateAcw = true)]
	internal class TaskInvoker : Task
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/Task", typeof(TaskInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Java.Lang.Exception Exception
		{
			[Register("getException", "()Ljava/lang/Exception;", "GetGetExceptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Exception>(_members.InstanceMethods.InvokeAbstractObjectMethod("getException.()Ljava/lang/Exception;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override bool IsCanceled
		{
			[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCanceled.()Z", this, null);
			}
		}

		public unsafe override bool IsComplete
		{
			[Register("isComplete", "()Z", "GetIsCompleteHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isComplete.()Z", this, null);
			}
		}

		public unsafe override bool IsSuccessful
		{
			[Register("isSuccessful", "()Z", "GetIsSuccessfulHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSuccessful.()Z", this, null);
			}
		}

		protected unsafe override Java.Lang.Object RawResult
		{
			[Register("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResult.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public TaskInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("addOnFailureListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public unsafe override Task AddOnFailureListener(Activity p0, IOnFailureListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("addOnFailureListener", "(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public unsafe override Task AddOnFailureListener(IOnFailureListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("addOnFailureListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
		public unsafe override Task AddOnFailureListener(IExecutor p0, IOnFailureListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("addOnSuccessListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public unsafe override Task AddOnSuccessListener(Activity p0, IOnSuccessListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("addOnSuccessListener", "(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public unsafe override Task AddOnSuccessListener(IOnSuccessListener p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("addOnSuccessListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
		public unsafe override Task AddOnSuccessListener(IExecutor p0, IOnSuccessListener p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		[Register("getResult", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGetResult_Ljava_lang_Class_Handler")]
		[JavaTypeParameters(new string[] { "X extends java.lang.Throwable" })]
		public unsafe override Java.Lang.Object GetResult(Class p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResult.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}
	}
}
namespace Android.Gms.Extensions
{
	public static class TasksExtensions
	{
		public static Task<TResult> AsAsync<TResult>(this Android.Gms.Tasks.Task task) where TResult : class, IJavaObject
		{
			AwaitableTaskCompleteListener<TResult> awaitableTaskCompleteListener = new AwaitableTaskCompleteListener<TResult>();
			task.AddOnCompleteListener(awaitableTaskCompleteListener);
			return awaitableTaskCompleteListener.AwaitAsync();
		}

		public static System.Threading.Tasks.Task AsAsync(this Android.Gms.Tasks.Task task)
		{
			AwaitableTaskCompleteListener<Java.Lang.Object> awaitableTaskCompleteListener = new AwaitableTaskCompleteListener<Java.Lang.Object>();
			task.AddOnCompleteListener(awaitableTaskCompleteListener);
			return awaitableTaskCompleteListener.AwaitAsync();
		}
	}
	internal class AwaitableTaskCompleteListener<TResult> : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable where TResult : class, IJavaObject
	{
		private TaskCompletionSource<TResult> taskCompletionSource;

		public AwaitableTaskCompleteListener()
		{
			taskCompletionSource = new TaskCompletionSource<TResult>();
		}

		public void OnComplete(Android.Gms.Tasks.Task task)
		{
			if (task.IsSuccessful)
			{
				TaskCompletionSource<TResult> obj = taskCompletionSource;
				object result;
				if (task == null)
				{
					result = null;
				}
				else
				{
					Java.Lang.Object result2 = task.Result;
					result = ((result2 != null) ? Android.Runtime.Extensions.JavaCast<TResult>(result2) : null);
				}
				obj.SetResult((TResult)result);
			}
			else
			{
				taskCompletionSource.SetException(task.Exception);
			}
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
}
