using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "com.google.common.util.concurrent", Managed = "Google.Common.Util.Concurrent")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "Xamarin.Android v5.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Guava.ListenableFuture")]
[assembly: AssemblyTitle("Xamarin.Google.Guava.ListenableFuture")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
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
namespace Google.Common.Util.Concurrent
{
	[Register("com/google/common/util/concurrent/ListenableFuture", "", "Google.Common.Util.Concurrent.IListenableFutureInvoker")]
	[JavaTypeParameters(new string[] { "V" })]
	public interface IListenableFuture : IFuture, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("addListener", "(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V", "GetAddListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_Handler:Google.Common.Util.Concurrent.IListenableFutureInvoker, Xamarin.Google.Guava.ListenableFuture")]
		void AddListener(IRunnable p0, IExecutor p1);
	}
	[Register("com/google/common/util/concurrent/ListenableFuture", DoNotGenerateAcw = true)]
	internal class IListenableFutureInvoker : Java.Lang.Object, IListenableFuture, IFuture, IJavaObject, IDisposable, IJavaPeerable
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/common/util/concurrent/ListenableFuture", typeof(IListenableFutureInvoker));

		private IntPtr class_ref;

		private static Delegate cb_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_;

		private IntPtr id_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_;

		private static Delegate cb_isCancelled;

		private IntPtr id_isCancelled;

		private static Delegate cb_isDone;

		private IntPtr id_isDone;

		private static Delegate cb_cancel_Z;

		private IntPtr id_cancel_Z;

		private static Delegate cb_get;

		private IntPtr id_get;

		private static Delegate cb_get_JLjava_util_concurrent_TimeUnit_;

		private IntPtr id_get_JLjava_util_concurrent_TimeUnit_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public bool IsCancelled
		{
			get
			{
				if (id_isCancelled == IntPtr.Zero)
				{
					id_isCancelled = JNIEnv.GetMethodID(class_ref, "isCancelled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCancelled);
			}
		}

		public bool IsDone
		{
			get
			{
				if (id_isDone == IntPtr.Zero)
				{
					id_isDone = JNIEnv.GetMethodID(class_ref, "isDone", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isDone);
			}
		}

		public static IListenableFuture GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.common.util.concurrent.ListenableFuture"));
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

		public IListenableFutureInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAddListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_Handler()
		{
			if ((object)cb_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_ == null)
			{
				cb_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_AddListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_));
			}
			return cb_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_;
		}

		private static void n_AddListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IListenableFuture listenableFuture = Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable p = Java.Lang.Object.GetObject<IRunnable>(native_p0, JniHandleOwnership.DoNotTransfer);
			IExecutor p2 = Java.Lang.Object.GetObject<IExecutor>(native_p1, JniHandleOwnership.DoNotTransfer);
			listenableFuture.AddListener(p, p2);
		}

		public unsafe void AddListener(IRunnable p0, IExecutor p1)
		{
			if (id_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
			{
				id_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID(class_ref, "addListener", "(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_addListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_, ptr);
		}

		private static Delegate GetIsCancelledHandler()
		{
			if ((object)cb_isCancelled == null)
			{
				cb_isCancelled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsCancelled));
			}
			return cb_isCancelled;
		}

		private static bool n_IsCancelled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancelled;
		}

		private static Delegate GetIsDoneHandler()
		{
			if ((object)cb_isDone == null)
			{
				cb_isDone = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsDone));
			}
			return cb_isDone;
		}

		private static bool n_IsDone(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDone;
		}

		private static Delegate GetCancel_ZHandler()
		{
			if ((object)cb_cancel_Z == null)
			{
				cb_cancel_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_Cancel_Z));
			}
			return cb_cancel_Z;
		}

		private static bool n_Cancel_Z(IntPtr jnienv, IntPtr native__this, bool mayInterruptIfRunning)
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel(mayInterruptIfRunning);
		}

		public unsafe bool Cancel(bool mayInterruptIfRunning)
		{
			if (id_cancel_Z == IntPtr.Zero)
			{
				id_cancel_Z = JNIEnv.GetMethodID(class_ref, "cancel", "(Z)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(mayInterruptIfRunning);
			return JNIEnv.CallBooleanMethod(base.Handle, id_cancel_Z, ptr);
		}

		private static Delegate GetGetHandler()
		{
			if ((object)cb_get == null)
			{
				cb_get = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_Get));
			}
			return cb_get;
		}

		private static IntPtr n_Get(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
		}

		public Java.Lang.Object Get()
		{
			if (id_get == IntPtr.Zero)
			{
				id_get = JNIEnv.GetMethodID(class_ref, "get", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGet_JLjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_get_JLjava_util_concurrent_TimeUnit_ == null)
			{
				cb_get_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long, IntPtr, IntPtr>(n_Get_JLjava_util_concurrent_TimeUnit_));
			}
			return cb_get_JLjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_Get_JLjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, long timeout, IntPtr native_unit)
		{
			IListenableFuture listenableFuture = Java.Lang.Object.GetObject<IListenableFuture>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(listenableFuture.Get(timeout, unit));
		}

		public unsafe Java.Lang.Object Get(long timeout, TimeUnit unit)
		{
			if (id_get_JLjava_util_concurrent_TimeUnit_ == IntPtr.Zero)
			{
				id_get_JLjava_util_concurrent_TimeUnit_ = JNIEnv.GetMethodID(class_ref, "get", "(JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(timeout);
			ptr[1] = new JValue(unit?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get_JLjava_util_concurrent_TimeUnit_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
}
