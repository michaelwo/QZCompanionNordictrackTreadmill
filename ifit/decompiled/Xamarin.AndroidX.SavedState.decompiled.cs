using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.OS;
using Android.Runtime;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a20a123cdd47b7bbbca548c168e77d65cb3632f0")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210729.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "7/29/2021 5:20:29 AM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.savedstate", Managed = "AndroidX.SavedState")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - savedstate  artifact=androidx.savedstate:savedstate artifact_versioned=androidx.savedstate:savedstate:1.1.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.SavedState")]
[assembly: AssemblyTitle("Xamarin.AndroidX.SavedState")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
namespace AndroidX.SavedState;

[Register("androidx/savedstate/SavedStateRegistryOwner", "", "AndroidX.SavedState.ISavedStateRegistryOwnerInvoker")]
public interface ISavedStateRegistryOwner : ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	SavedStateRegistry SavedStateRegistry
	{
		[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "GetGetSavedStateRegistryHandler:AndroidX.SavedState.ISavedStateRegistryOwnerInvoker, Xamarin.AndroidX.SavedState")]
		get;
	}
}
[Register("androidx/savedstate/SavedStateRegistryOwner", DoNotGenerateAcw = true)]
internal class ISavedStateRegistryOwnerInvoker : Java.Lang.Object, ISavedStateRegistryOwner, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/savedstate/SavedStateRegistryOwner", typeof(ISavedStateRegistryOwnerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_getSavedStateRegistry;

	private IntPtr id_getSavedStateRegistry;

	private static Delegate cb_getLifecycle;

	private IntPtr id_getLifecycle;

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

	public SavedStateRegistry SavedStateRegistry
	{
		get
		{
			if (id_getSavedStateRegistry == IntPtr.Zero)
			{
				id_getSavedStateRegistry = JNIEnv.GetMethodID(class_ref, "getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;");
			}
			return Java.Lang.Object.GetObject<SavedStateRegistry>(JNIEnv.CallObjectMethod(base.Handle, id_getSavedStateRegistry), JniHandleOwnership.TransferLocalRef);
		}
	}

	public AndroidX.Lifecycle.Lifecycle Lifecycle
	{
		get
		{
			if (id_getLifecycle == IntPtr.Zero)
			{
				id_getLifecycle = JNIEnv.GetMethodID(class_ref, "getLifecycle", "()Landroidx/lifecycle/Lifecycle;");
			}
			return Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle>(JNIEnv.CallObjectMethod(base.Handle, id_getLifecycle), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ISavedStateRegistryOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ISavedStateRegistryOwner>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.savedstate.SavedStateRegistryOwner'.");
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

	public ISavedStateRegistryOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetSavedStateRegistryHandler()
	{
		if ((object)cb_getSavedStateRegistry == null)
		{
			cb_getSavedStateRegistry = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSavedStateRegistry));
		}
		return cb_getSavedStateRegistry;
	}

	private static IntPtr n_GetSavedStateRegistry(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISavedStateRegistryOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SavedStateRegistry);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISavedStateRegistryOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
	}
}
[Register("androidx/savedstate/SavedStateRegistry", DoNotGenerateAcw = true)]
public sealed class SavedStateRegistry : Java.Lang.Object
{
	[Register("androidx/savedstate/SavedStateRegistry$SavedStateProvider", "", "AndroidX.SavedState.SavedStateRegistry/ISavedStateProviderInvoker")]
	public interface ISavedStateProvider : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("saveState", "()Landroid/os/Bundle;", "GetSaveStateHandler:AndroidX.SavedState.SavedStateRegistry/ISavedStateProviderInvoker, Xamarin.AndroidX.SavedState")]
		Bundle SaveState();
	}

	[Register("androidx/savedstate/SavedStateRegistry$SavedStateProvider", DoNotGenerateAcw = true)]
	internal class ISavedStateProviderInvoker : Java.Lang.Object, ISavedStateProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/savedstate/SavedStateRegistry$SavedStateProvider", typeof(ISavedStateProviderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_saveState;

		private IntPtr id_saveState;

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

		public static ISavedStateProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISavedStateProvider>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.savedstate.SavedStateRegistry.SavedStateProvider'.");
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

		public ISavedStateProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSaveStateHandler()
		{
			if ((object)cb_saveState == null)
			{
				cb_saveState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_SaveState));
			}
			return cb_saveState;
		}

		private static IntPtr n_SaveState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISavedStateProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveState());
		}

		public Bundle SaveState()
		{
			if (id_saveState == IntPtr.Zero)
			{
				id_saveState = JNIEnv.GetMethodID(class_ref, "saveState", "()Landroid/os/Bundle;");
			}
			return Java.Lang.Object.GetObject<Bundle>(JNIEnv.CallObjectMethod(base.Handle, id_saveState), JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/savedstate/SavedStateRegistry", typeof(SavedStateRegistry));

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

	public unsafe bool IsRestored
	{
		[Register("isRestored", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRestored.()Z", this, null);
		}
	}

	internal SavedStateRegistry(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("consumeRestoredStateForKey", "(Ljava/lang/String;)Landroid/os/Bundle;", "")]
	public unsafe Bundle ConsumeRestoredStateForKey(string key)
	{
		IntPtr intPtr = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeAbstractObjectMethod("consumeRestoredStateForKey.(Ljava/lang/String;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("registerSavedStateProvider", "(Ljava/lang/String;Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;)V", "")]
	public unsafe void RegisterSavedStateProvider(string key, ISavedStateProvider provider)
	{
		IntPtr intPtr = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("registerSavedStateProvider.(Ljava/lang/String;Landroidx/savedstate/SavedStateRegistry$SavedStateProvider;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(provider);
		}
	}

	[Register("runOnNextRecreation", "(Ljava/lang/Class;)V", "")]
	public unsafe void RunOnNextRecreation(Class clazz)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clazz?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("runOnNextRecreation.(Ljava/lang/Class;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(clazz);
		}
	}

	[Register("unregisterSavedStateProvider", "(Ljava/lang/String;)V", "")]
	public unsafe void UnregisterSavedStateProvider(string key)
	{
		IntPtr intPtr = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterSavedStateProvider.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
}
