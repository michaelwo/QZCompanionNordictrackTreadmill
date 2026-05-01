using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a0b083e48e5cb48b5f74f95cbf4e400692849c0e")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210223.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "2/23/2021 6:09:48 AM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.lifecycle", Managed = "AndroidX.Lifecycle")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - lifecycle-common")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Lifecycle.Common")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Lifecycle.Common")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/Lifecycle", DoNotGenerateAcw = true)]
public abstract class Lifecycle : Java.Lang.Object
{
	[Register("androidx/lifecycle/Lifecycle$State", DoNotGenerateAcw = true)]
	public sealed class State : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle$State", typeof(State));

		[Register("CREATED")]
		public static State Created => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("CREATED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DESTROYED")]
		public static State Destroyed => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("DESTROYED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INITIALIZED")]
		public static State Initialized => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("INITIALIZED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RESUMED")]
		public static State Resumed => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("RESUMED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STARTED")]
		public static State Started => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("STARTED.Landroidx/lifecycle/Lifecycle$State;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal State(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("isAtLeast", "(Landroidx/lifecycle/Lifecycle$State;)Z", "")]
		public unsafe bool IsAtLeast(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAtLeast.(Landroidx/lifecycle/Lifecycle$State;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$State;", "")]
		public unsafe static State ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<State>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/lifecycle/Lifecycle$State;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/lifecycle/Lifecycle$State;", "")]
		public unsafe static State[] Values()
		{
			return (State[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/lifecycle/Lifecycle$State;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(State));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle", typeof(Lifecycle));

	private static Delegate cb_getCurrentState;

	private static Delegate cb_addObserver_Landroidx_lifecycle_LifecycleObserver_;

	private static Delegate cb_removeObserver_Landroidx_lifecycle_LifecycleObserver_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract State CurrentState
	{
		[Register("getCurrentState", "()Landroidx/lifecycle/Lifecycle$State;", "GetGetCurrentStateHandler")]
		get;
	}

	protected Lifecycle(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Lifecycle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCurrentStateHandler()
	{
		if ((object)cb_getCurrentState == null)
		{
			cb_getCurrentState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCurrentState));
		}
		return cb_getCurrentState;
	}

	private static IntPtr n_GetCurrentState(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentState);
	}

	private static Delegate GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler()
	{
		if ((object)cb_addObserver_Landroidx_lifecycle_LifecycleObserver_ == null)
		{
			cb_addObserver_Landroidx_lifecycle_LifecycleObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddObserver_Landroidx_lifecycle_LifecycleObserver_));
		}
		return cb_addObserver_Landroidx_lifecycle_LifecycleObserver_;
	}

	private static void n_AddObserver_Landroidx_lifecycle_LifecycleObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		Lifecycle lifecycle = Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILifecycleObserver p = Java.Lang.Object.GetObject<ILifecycleObserver>(native_p0, JniHandleOwnership.DoNotTransfer);
		lifecycle.AddObserver(p);
	}

	[Register("addObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public abstract void AddObserver(ILifecycleObserver p0);

	private static Delegate GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler()
	{
		if ((object)cb_removeObserver_Landroidx_lifecycle_LifecycleObserver_ == null)
		{
			cb_removeObserver_Landroidx_lifecycle_LifecycleObserver_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveObserver_Landroidx_lifecycle_LifecycleObserver_));
		}
		return cb_removeObserver_Landroidx_lifecycle_LifecycleObserver_;
	}

	private static void n_RemoveObserver_Landroidx_lifecycle_LifecycleObserver_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		Lifecycle lifecycle = Java.Lang.Object.GetObject<Lifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILifecycleObserver p = Java.Lang.Object.GetObject<ILifecycleObserver>(native_p0, JniHandleOwnership.DoNotTransfer);
		lifecycle.RemoveObserver(p);
	}

	[Register("removeObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public abstract void RemoveObserver(ILifecycleObserver p0);
}
[Register("androidx/lifecycle/LifecycleObserver", "", "AndroidX.Lifecycle.ILifecycleObserverInvoker")]
public interface ILifecycleObserver : IJavaObject, IDisposable, IJavaPeerable
{
}
[Register("androidx/lifecycle/LifecycleObserver", DoNotGenerateAcw = true)]
internal class ILifecycleObserverInvoker : Java.Lang.Object, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LifecycleObserver", typeof(ILifecycleObserverInvoker));

	private IntPtr class_ref;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static ILifecycleObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ILifecycleObserver>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.lifecycle.LifecycleObserver"));
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

	public ILifecycleObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}
}
[Register("androidx/lifecycle/LifecycleOwner", "", "AndroidX.Lifecycle.ILifecycleOwnerInvoker")]
public interface ILifecycleOwner : IJavaObject, IDisposable, IJavaPeerable
{
	Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler:AndroidX.Lifecycle.ILifecycleOwnerInvoker, Xamarin.AndroidX.Lifecycle.Common")]
		get;
	}
}
[Register("androidx/lifecycle/LifecycleOwner", DoNotGenerateAcw = true)]
internal class ILifecycleOwnerInvoker : Java.Lang.Object, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LifecycleOwner", typeof(ILifecycleOwnerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_getLifecycle;

	private IntPtr id_getLifecycle;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public Lifecycle Lifecycle
	{
		get
		{
			if (id_getLifecycle == IntPtr.Zero)
			{
				id_getLifecycle = JNIEnv.GetMethodID(class_ref, "getLifecycle", "()Landroidx/lifecycle/Lifecycle;");
			}
			return Java.Lang.Object.GetObject<Lifecycle>(JNIEnv.CallObjectMethod(base.Handle, id_getLifecycle), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ILifecycleOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ILifecycleOwner>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.lifecycle.LifecycleOwner"));
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

	public ILifecycleOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetLifecycleHandler()
	{
		if ((object)cb_getLifecycle == null)
		{
			cb_getLifecycle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLifecycle));
		}
		return cb_getLifecycle;
	}

	private static IntPtr n_GetLifecycle(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILifecycleOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
	}
}
[Register("androidx/lifecycle/Lifecycle", DoNotGenerateAcw = true)]
internal class LifecycleInvoker : Lifecycle
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle", typeof(LifecycleInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override State CurrentState
	{
		[Register("getCurrentState", "()Landroidx/lifecycle/Lifecycle$State;", "GetGetCurrentStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCurrentState.()Landroidx/lifecycle/Lifecycle$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public LifecycleInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public unsafe override void AddObserver(ILifecycleObserver p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addObserver.(Landroidx/lifecycle/LifecycleObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("removeObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public unsafe override void RemoveObserver(ILifecycleObserver p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeObserver.(Landroidx/lifecycle/LifecycleObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
