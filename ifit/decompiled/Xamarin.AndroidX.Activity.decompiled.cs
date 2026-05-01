using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Activity.ContextAware;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using AndroidX.Lifecycle;
using AndroidX.SavedState;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "2745617fc1c67dcad1708d6bed95381625e22ca2")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210805.3")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "8/5/2021 9:03:13 AM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.activity", Managed = "AndroidX.Activity")]
[assembly: NamespaceMapping(Java = "androidx.activity.contextaware", Managed = "AndroidX.Activity.ContextAware")]
[assembly: NamespaceMapping(Java = "androidx.activity.result", Managed = "AndroidX.Activity.Result")]
[assembly: NamespaceMapping(Java = "androidx.activity.result.contract", Managed = "AndroidX.Activity.Result.Contract")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - activity  artifact=androidx.activity:activity artifact_versioned=androidx.activity:activity:1.3.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Activity")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Activity")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPILLL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
namespace AndroidX.Activity
{
	[Register("androidx/activity/ComponentActivity", DoNotGenerateAcw = true)]
	public class ComponentActivity : AndroidX.Core.App.ComponentActivity, IOnBackPressedDispatcherOwner, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable, IContextAware, IActivityResultCaller, IActivityResultRegistryOwner, IHasDefaultViewModelProviderFactory, IViewModelStoreOwner, ISavedStateRegistryOwner
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/ComponentActivity", typeof(ComponentActivity));

		private static Delegate cb_getDefaultViewModelProviderFactory;

		private static Delegate cb_getLastCustomNonConfigurationInstance;

		private static Delegate cb_getViewModelStore;

		private static Delegate cb_onRetainCustomNonConfigurationInstance;

		private static Delegate cb_peekAvailableContext;

		private WeakReference weak_implementor_AddOnContextAvailableListener;

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

		public unsafe ActivityResultRegistry ActivityResultRegistry
		{
			[Register("getActivityResultRegistry", "()Landroidx/activity/result/ActivityResultRegistry;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ActivityResultRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivityResultRegistry.()Landroidx/activity/result/ActivityResultRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ViewModelProvider.IFactory DefaultViewModelProviderFactory
		{
			[Register("getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;", "GetGetDefaultViewModelProviderFactoryHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ViewModelProvider.IFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelProviderFactory.()Landroidx/lifecycle/ViewModelProvider$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Java.Lang.Object LastCustomNonConfigurationInstance
		{
			[Register("getLastCustomNonConfigurationInstance", "()Ljava/lang/Object;", "GetGetLastCustomNonConfigurationInstanceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLastCustomNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe OnBackPressedDispatcher OnBackPressedDispatcher
		{
			[Register("getOnBackPressedDispatcher", "()Landroidx/activity/OnBackPressedDispatcher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OnBackPressedDispatcher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOnBackPressedDispatcher.()Landroidx/activity/OnBackPressedDispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe SavedStateRegistry SavedStateRegistry
		{
			[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "")]
			get
			{
				return Java.Lang.Object.GetObject<SavedStateRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSavedStateRegistry.()Landroidx/savedstate/SavedStateRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ViewModelStore ViewModelStore
		{
			[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ViewModelStore>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewModelStore.()Landroidx/lifecycle/ViewModelStore;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public event EventHandler<ContextAvailableEventArgs> ContextAvailable
		{
			add
			{
				EventHelper.AddEventHandler<IOnContextAvailableListener, IOnContextAvailableListenerImplementor>(ref weak_implementor_AddOnContextAvailableListener, __CreateIOnContextAvailableListenerImplementor, AddOnContextAvailableListener, delegate(IOnContextAvailableListenerImplementor __h)
				{
					__h.Handler = (EventHandler<ContextAvailableEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnContextAvailableListener, IOnContextAvailableListenerImplementor.__IsEmpty, delegate(IOnContextAvailableListener __v)
				{
					RemoveOnContextAvailableListener(__v);
				}, delegate(IOnContextAvailableListenerImplementor __h)
				{
					__h.Handler = (EventHandler<ContextAvailableEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected ComponentActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ComponentActivity()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe ComponentActivity(int contentLayoutId)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(contentLayoutId);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetGetDefaultViewModelProviderFactoryHandler()
		{
			if ((object)cb_getDefaultViewModelProviderFactory == null)
			{
				cb_getDefaultViewModelProviderFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultViewModelProviderFactory));
			}
			return cb_getDefaultViewModelProviderFactory;
		}

		private static IntPtr n_GetDefaultViewModelProviderFactory(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelProviderFactory);
		}

		private static Delegate GetGetLastCustomNonConfigurationInstanceHandler()
		{
			if ((object)cb_getLastCustomNonConfigurationInstance == null)
			{
				cb_getLastCustomNonConfigurationInstance = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastCustomNonConfigurationInstance));
			}
			return cb_getLastCustomNonConfigurationInstance;
		}

		private static IntPtr n_GetLastCustomNonConfigurationInstance(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastCustomNonConfigurationInstance);
		}

		private static Delegate GetGetViewModelStoreHandler()
		{
			if ((object)cb_getViewModelStore == null)
			{
				cb_getViewModelStore = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetViewModelStore));
			}
			return cb_getViewModelStore;
		}

		private static IntPtr n_GetViewModelStore(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
		}

		[Register("addOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "")]
		public unsafe void AddOnContextAvailableListener(IOnContextAvailableListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnContextAvailableListener.(Landroidx/activity/contextaware/OnContextAvailableListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetOnRetainCustomNonConfigurationInstanceHandler()
		{
			if ((object)cb_onRetainCustomNonConfigurationInstance == null)
			{
				cb_onRetainCustomNonConfigurationInstance = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_OnRetainCustomNonConfigurationInstance));
			}
			return cb_onRetainCustomNonConfigurationInstance;
		}

		private static IntPtr n_OnRetainCustomNonConfigurationInstance(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRetainCustomNonConfigurationInstance());
		}

		[Register("onRetainCustomNonConfigurationInstance", "()Ljava/lang/Object;", "GetOnRetainCustomNonConfigurationInstanceHandler")]
		public unsafe virtual Java.Lang.Object OnRetainCustomNonConfigurationInstance()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("onRetainCustomNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("onRetainNonConfigurationInstance", "()Ljava/lang/Object;", "")]
		public unsafe sealed override Java.Lang.Object OnRetainNonConfigurationInstance()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("onRetainNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPeekAvailableContextHandler()
		{
			if ((object)cb_peekAvailableContext == null)
			{
				cb_peekAvailableContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PeekAvailableContext));
			}
			return cb_peekAvailableContext;
		}

		private static IntPtr n_PeekAvailableContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekAvailableContext());
		}

		[Register("peekAvailableContext", "()Landroid/content/Context;", "GetPeekAvailableContextHandler")]
		public unsafe virtual Context PeekAvailableContext()
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("peekAvailableContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contract);
				GC.KeepAlive(callback);
			}
		}

		[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(contract);
				GC.KeepAlive(registry);
				GC.KeepAlive(callback);
			}
		}

		[Register("removeOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "")]
		public unsafe void RemoveOnContextAvailableListener(IOnContextAvailableListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnContextAvailableListener.(Landroidx/activity/contextaware/OnContextAvailableListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private IOnContextAvailableListenerImplementor __CreateIOnContextAvailableListenerImplementor()
		{
			return new IOnContextAvailableListenerImplementor(this);
		}
	}
	[Register("androidx/activity/OnBackPressedDispatcherOwner", "", "AndroidX.Activity.IOnBackPressedDispatcherOwnerInvoker")]
	public interface IOnBackPressedDispatcherOwner : ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
	{
		OnBackPressedDispatcher OnBackPressedDispatcher
		{
			[Register("getOnBackPressedDispatcher", "()Landroidx/activity/OnBackPressedDispatcher;", "GetGetOnBackPressedDispatcherHandler:AndroidX.Activity.IOnBackPressedDispatcherOwnerInvoker, Xamarin.AndroidX.Activity")]
			get;
		}
	}
	[Register("androidx/activity/OnBackPressedDispatcherOwner", DoNotGenerateAcw = true)]
	internal class IOnBackPressedDispatcherOwnerInvoker : Java.Lang.Object, IOnBackPressedDispatcherOwner, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedDispatcherOwner", typeof(IOnBackPressedDispatcherOwnerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getOnBackPressedDispatcher;

		private IntPtr id_getOnBackPressedDispatcher;

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

		public OnBackPressedDispatcher OnBackPressedDispatcher
		{
			get
			{
				if (id_getOnBackPressedDispatcher == IntPtr.Zero)
				{
					id_getOnBackPressedDispatcher = JNIEnv.GetMethodID(class_ref, "getOnBackPressedDispatcher", "()Landroidx/activity/OnBackPressedDispatcher;");
				}
				return Java.Lang.Object.GetObject<OnBackPressedDispatcher>(JNIEnv.CallObjectMethod(base.Handle, id_getOnBackPressedDispatcher), JniHandleOwnership.TransferLocalRef);
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

		public static IOnBackPressedDispatcherOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnBackPressedDispatcherOwner>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.OnBackPressedDispatcherOwner'.");
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

		public IOnBackPressedDispatcherOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetOnBackPressedDispatcherHandler()
		{
			if ((object)cb_getOnBackPressedDispatcher == null)
			{
				cb_getOnBackPressedDispatcher = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOnBackPressedDispatcher));
			}
			return cb_getOnBackPressedDispatcher;
		}

		private static IntPtr n_GetOnBackPressedDispatcher(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOnBackPressedDispatcherOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackPressedDispatcher);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOnBackPressedDispatcherOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
		}
	}
	[Register("androidx/activity/OnBackPressedCallback", DoNotGenerateAcw = true)]
	public abstract class OnBackPressedCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedCallback", typeof(OnBackPressedCallback));

		private static Delegate cb_handleOnBackPressed;

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

		public unsafe bool Enabled
		{
			[Register("isEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isEnabled.()Z", this, null);
			}
			[Register("setEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setEnabled.(Z)V", this, ptr);
			}
		}

		protected OnBackPressedCallback(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Z)V", "")]
		public unsafe OnBackPressedCallback(bool enabled)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(enabled);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
			}
		}

		private static Delegate GetHandleOnBackPressedHandler()
		{
			if ((object)cb_handleOnBackPressed == null)
			{
				cb_handleOnBackPressed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_HandleOnBackPressed));
			}
			return cb_handleOnBackPressed;
		}

		private static void n_HandleOnBackPressed(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<OnBackPressedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleOnBackPressed();
		}

		[Register("handleOnBackPressed", "()V", "GetHandleOnBackPressedHandler")]
		public abstract void HandleOnBackPressed();

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("remove.()V", this, null);
		}
	}
	[Register("androidx/activity/OnBackPressedCallback", DoNotGenerateAcw = true)]
	internal class OnBackPressedCallbackInvoker : OnBackPressedCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedCallback", typeof(OnBackPressedCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnBackPressedCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("handleOnBackPressed", "()V", "GetHandleOnBackPressedHandler")]
		public unsafe override void HandleOnBackPressed()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("handleOnBackPressed.()V", this, null);
		}
	}
	[Register("androidx/activity/OnBackPressedDispatcher", DoNotGenerateAcw = true)]
	public sealed class OnBackPressedDispatcher : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/OnBackPressedDispatcher", typeof(OnBackPressedDispatcher));

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

		public unsafe bool HasEnabledCallbacks
		{
			[Register("hasEnabledCallbacks", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasEnabledCallbacks.()Z", this, null);
			}
		}

		internal OnBackPressedDispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnBackPressedDispatcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/Runnable;)V", "")]
		public unsafe OnBackPressedDispatcher(IRunnable fallbackOnBackPressed)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((fallbackOnBackPressed == null) ? IntPtr.Zero : ((Java.Lang.Object)fallbackOnBackPressed).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fallbackOnBackPressed);
			}
		}

		[Register("addCallback", "(Landroidx/activity/OnBackPressedCallback;)V", "")]
		public unsafe void AddCallback(OnBackPressedCallback onBackPressedCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(onBackPressedCallback?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addCallback.(Landroidx/activity/OnBackPressedCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(onBackPressedCallback);
			}
		}

		[Register("addCallback", "(Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/OnBackPressedCallback;)V", "")]
		public unsafe void AddCallback(ILifecycleOwner owner, OnBackPressedCallback onBackPressedCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
				ptr[1] = new JniArgumentValue(onBackPressedCallback?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addCallback.(Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/OnBackPressedCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
				GC.KeepAlive(onBackPressedCallback);
			}
		}

		[Register("onBackPressed", "()V", "")]
		public unsafe void OnBackPressed()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onBackPressed.()V", this, null);
		}
	}
}
namespace AndroidX.Activity.ContextAware
{
	[Register("androidx/activity/contextaware/ContextAware", "", "AndroidX.Activity.ContextAware.IContextAwareInvoker")]
	public interface IContextAware : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("addOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "GetAddOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_Handler:AndroidX.Activity.ContextAware.IContextAwareInvoker, Xamarin.AndroidX.Activity")]
		void AddOnContextAvailableListener(IOnContextAvailableListener listener);

		[Register("peekAvailableContext", "()Landroid/content/Context;", "GetPeekAvailableContextHandler:AndroidX.Activity.ContextAware.IContextAwareInvoker, Xamarin.AndroidX.Activity")]
		Context PeekAvailableContext();

		[Register("removeOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "GetRemoveOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_Handler:AndroidX.Activity.ContextAware.IContextAwareInvoker, Xamarin.AndroidX.Activity")]
		void RemoveOnContextAvailableListener(IOnContextAvailableListener listener);
	}
	[Register("androidx/activity/contextaware/ContextAware", DoNotGenerateAcw = true)]
	internal class IContextAwareInvoker : Java.Lang.Object, IContextAware, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/contextaware/ContextAware", typeof(IContextAwareInvoker));

		private IntPtr class_ref;

		private static Delegate cb_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;

		private IntPtr id_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;

		private static Delegate cb_peekAvailableContext;

		private IntPtr id_peekAvailableContext;

		private static Delegate cb_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;

		private IntPtr id_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;

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

		public static IContextAware GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IContextAware>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.contextaware.ContextAware'.");
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

		public IContextAwareInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAddOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_Handler()
		{
			if ((object)cb_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ == null)
			{
				cb_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_));
			}
			return cb_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;
		}

		private static void n_AddOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			IContextAware contextAware = Java.Lang.Object.GetObject<IContextAware>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnContextAvailableListener listener = Java.Lang.Object.GetObject<IOnContextAvailableListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			contextAware.AddOnContextAvailableListener(listener);
		}

		public unsafe void AddOnContextAvailableListener(IOnContextAvailableListener listener)
		{
			if (id_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ == IntPtr.Zero)
			{
				id_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ = JNIEnv.GetMethodID(class_ref, "addOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_addOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_, ptr);
		}

		private static Delegate GetPeekAvailableContextHandler()
		{
			if ((object)cb_peekAvailableContext == null)
			{
				cb_peekAvailableContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PeekAvailableContext));
			}
			return cb_peekAvailableContext;
		}

		private static IntPtr n_PeekAvailableContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IContextAware>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekAvailableContext());
		}

		public Context PeekAvailableContext()
		{
			if (id_peekAvailableContext == IntPtr.Zero)
			{
				id_peekAvailableContext = JNIEnv.GetMethodID(class_ref, "peekAvailableContext", "()Landroid/content/Context;");
			}
			return Java.Lang.Object.GetObject<Context>(JNIEnv.CallObjectMethod(base.Handle, id_peekAvailableContext), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRemoveOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_Handler()
		{
			if ((object)cb_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ == null)
			{
				cb_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_));
			}
			return cb_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_;
		}

		private static void n_RemoveOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			IContextAware contextAware = Java.Lang.Object.GetObject<IContextAware>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnContextAvailableListener listener = Java.Lang.Object.GetObject<IOnContextAvailableListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			contextAware.RemoveOnContextAvailableListener(listener);
		}

		public unsafe void RemoveOnContextAvailableListener(IOnContextAvailableListener listener)
		{
			if (id_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ == IntPtr.Zero)
			{
				id_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_ = JNIEnv.GetMethodID(class_ref, "removeOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_removeOnContextAvailableListener_Landroidx_activity_contextaware_OnContextAvailableListener_, ptr);
		}
	}
	[Register("androidx/activity/contextaware/OnContextAvailableListener", "", "AndroidX.Activity.ContextAware.IOnContextAvailableListenerInvoker")]
	public interface IOnContextAvailableListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onContextAvailable", "(Landroid/content/Context;)V", "GetOnContextAvailable_Landroid_content_Context_Handler:AndroidX.Activity.ContextAware.IOnContextAvailableListenerInvoker, Xamarin.AndroidX.Activity")]
		void OnContextAvailable(Context context);
	}
	[Register("androidx/activity/contextaware/OnContextAvailableListener", DoNotGenerateAcw = true)]
	internal class IOnContextAvailableListenerInvoker : Java.Lang.Object, IOnContextAvailableListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/contextaware/OnContextAvailableListener", typeof(IOnContextAvailableListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onContextAvailable_Landroid_content_Context_;

		private IntPtr id_onContextAvailable_Landroid_content_Context_;

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

		public static IOnContextAvailableListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnContextAvailableListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.contextaware.OnContextAvailableListener'.");
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

		public IOnContextAvailableListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnContextAvailable_Landroid_content_Context_Handler()
		{
			if ((object)cb_onContextAvailable_Landroid_content_Context_ == null)
			{
				cb_onContextAvailable_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnContextAvailable_Landroid_content_Context_));
			}
			return cb_onContextAvailable_Landroid_content_Context_;
		}

		private static void n_OnContextAvailable_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			IOnContextAvailableListener onContextAvailableListener = Java.Lang.Object.GetObject<IOnContextAvailableListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			onContextAvailableListener.OnContextAvailable(context);
		}

		public unsafe void OnContextAvailable(Context context)
		{
			if (id_onContextAvailable_Landroid_content_Context_ == IntPtr.Zero)
			{
				id_onContextAvailable_Landroid_content_Context_ = JNIEnv.GetMethodID(class_ref, "onContextAvailable", "(Landroid/content/Context;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(context?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onContextAvailable_Landroid_content_Context_, ptr);
		}
	}
	public class ContextAvailableEventArgs : EventArgs
	{
		private Context context;

		public ContextAvailableEventArgs(Context context)
		{
			this.context = context;
		}
	}
	[Register("mono/androidx/activity/contextaware/OnContextAvailableListenerImplementor")]
	internal sealed class IOnContextAvailableListenerImplementor : Java.Lang.Object, IOnContextAvailableListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<ContextAvailableEventArgs> Handler;

		public IOnContextAvailableListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/androidx/activity/contextaware/OnContextAvailableListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnContextAvailable(Context context)
		{
			Handler?.Invoke(sender, new ContextAvailableEventArgs(context));
		}

		internal static bool __IsEmpty(IOnContextAvailableListenerImplementor value)
		{
			return value.Handler == null;
		}
	}
}
namespace AndroidX.Activity.Result
{
	[Register("androidx/activity/result/ActivityResultLauncher", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "I" })]
	public abstract class ActivityResultLauncher : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultLauncher", typeof(ActivityResultLauncher));

		private static Delegate cb_getContract;

		private static Delegate cb_launch_Ljava_lang_Object_;

		private static Delegate cb_launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_;

		private static Delegate cb_unregister;

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

		protected abstract ActivityResultContract RawContract
		{
			[Register("getContract", "()Landroidx/activity/result/contract/ActivityResultContract;", "GetGetContractHandler")]
			get;
		}

		protected ActivityResultLauncher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ActivityResultLauncher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetContractHandler()
		{
			if ((object)cb_getContract == null)
			{
				cb_getContract = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContract));
			}
			return cb_getContract;
		}

		private static IntPtr n_GetContract(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RawContract);
		}

		private static Delegate GetLaunch_Ljava_lang_Object_Handler()
		{
			if ((object)cb_launch_Ljava_lang_Object_ == null)
			{
				cb_launch_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Launch_Ljava_lang_Object_));
			}
			return cb_launch_Ljava_lang_Object_;
		}

		private static void n_Launch_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_input)
		{
			ActivityResultLauncher activityResultLauncher = Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			activityResultLauncher.Launch(input);
		}

		[Register("launch", "(Ljava/lang/Object;)V", "GetLaunch_Ljava_lang_Object_Handler")]
		public unsafe virtual void Launch(Java.Lang.Object input)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("launch.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(input);
			}
		}

		private static Delegate GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler()
		{
			if ((object)cb_launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_ == null)
			{
				cb_launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_));
			}
			return cb_launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_;
		}

		private static void n_Launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_(IntPtr jnienv, IntPtr native__this, IntPtr native_input, IntPtr native_options)
		{
			ActivityResultLauncher activityResultLauncher = Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			ActivityOptionsCompat options = Java.Lang.Object.GetObject<ActivityOptionsCompat>(native_options, JniHandleOwnership.DoNotTransfer);
			activityResultLauncher.Launch(input, options);
		}

		[Register("launch", "(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
		public abstract void Launch(Java.Lang.Object input, ActivityOptionsCompat options);

		private static Delegate GetUnregisterHandler()
		{
			if ((object)cb_unregister == null)
			{
				cb_unregister = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Unregister));
			}
			return cb_unregister;
		}

		private static void n_Unregister(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Unregister();
		}

		[Register("unregister", "()V", "GetUnregisterHandler")]
		public abstract void Unregister();
	}
	[Register("androidx/activity/result/ActivityResultLauncher", DoNotGenerateAcw = true)]
	internal class ActivityResultLauncherInvoker : ActivityResultLauncher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultLauncher", typeof(ActivityResultLauncherInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe override ActivityResultContract RawContract
		{
			[Register("getContract", "()Landroidx/activity/result/contract/ActivityResultContract;", "GetGetContractHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ActivityResultContract>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContract.()Landroidx/activity/result/contract/ActivityResultContract;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ActivityResultLauncherInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("launch", "(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
		public unsafe override void Launch(Java.Lang.Object input, ActivityOptionsCompat options)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("launch.(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(input);
				GC.KeepAlive(options);
			}
		}

		[Register("unregister", "()V", "GetUnregisterHandler")]
		public unsafe override void Unregister()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("unregister.()V", this, null);
		}
	}
	[Register("androidx/activity/result/ActivityResultRegistry", DoNotGenerateAcw = true)]
	public abstract class ActivityResultRegistry : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultRegistry", typeof(ActivityResultRegistry));

		private static Delegate cb_onLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_;

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

		protected ActivityResultRegistry(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ActivityResultRegistry()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("dispatchResult", "(IILandroid/content/Intent;)Z", "")]
		public unsafe bool DispatchResult(int requestCode, int resultCode, Intent data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(resultCode);
				ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("dispatchResult.(IILandroid/content/Intent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		[Register("dispatchResult", "(ILjava/lang/Object;)Z", "")]
		[JavaTypeParameters(new string[] { "O" })]
		public unsafe bool DispatchResult(int requestCode, Java.Lang.Object result)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("dispatchResult.(ILjava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(result);
			}
		}

		private static Delegate GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler()
		{
			if ((object)cb_onLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_ == null)
			{
				cb_onLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILLL_V(n_OnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_));
			}
			return cb_onLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_;
		}

		private static void n_OnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_(IntPtr jnienv, IntPtr native__this, int requestCode, IntPtr native_contract, IntPtr native_input, IntPtr native_options)
		{
			ActivityResultRegistry activityResultRegistry = Java.Lang.Object.GetObject<ActivityResultRegistry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActivityResultContract contract = Java.Lang.Object.GetObject<ActivityResultContract>(native_contract, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			ActivityOptionsCompat options = Java.Lang.Object.GetObject<ActivityOptionsCompat>(native_options, JniHandleOwnership.DoNotTransfer);
			activityResultRegistry.OnLaunch(requestCode, contract, input, options);
		}

		[Register("onLaunch", "(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public abstract void OnLaunch(int requestCode, ActivityResultContract contract, Java.Lang.Object input, ActivityOptionsCompat options);

		[Register("onRestoreInstanceState", "(Landroid/os/Bundle;)V", "")]
		public unsafe void OnRestoreInstanceState(Bundle savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(savedInstanceState);
			}
		}

		[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "")]
		public unsafe void OnSaveInstanceState(Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outState);
			}
		}

		[Register("register", "(Ljava/lang/String;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public unsafe ActivityResultLauncher Register(string key, ActivityResultContract contract, IActivityResultCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("register.(Ljava/lang/String;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contract);
				GC.KeepAlive(callback);
			}
		}

		[Register("register", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public unsafe ActivityResultLauncher Register(string key, ILifecycleOwner lifecycleOwner, ActivityResultContract contract, IActivityResultCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((lifecycleOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycleOwner).Handle);
				ptr[2] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("register.(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(lifecycleOwner);
				GC.KeepAlive(contract);
				GC.KeepAlive(callback);
			}
		}
	}
	[Register("androidx/activity/result/ActivityResultRegistry", DoNotGenerateAcw = true)]
	internal class ActivityResultRegistryInvoker : ActivityResultRegistry
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultRegistry", typeof(ActivityResultRegistryInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ActivityResultRegistryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onLaunch", "(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		public unsafe override void OnLaunch(int requestCode, ActivityResultContract contract, Java.Lang.Object input, ActivityOptionsCompat options)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(requestCode);
				ptr[1] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onLaunch.(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(contract);
				GC.KeepAlive(input);
				GC.KeepAlive(options);
			}
		}
	}
	[Register("androidx/activity/result/ActivityResultCallback", "", "AndroidX.Activity.Result.IActivityResultCallbackInvoker")]
	[JavaTypeParameters(new string[] { "O" })]
	public interface IActivityResultCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onActivityResult", "(Ljava/lang/Object;)V", "GetOnActivityResult_Ljava_lang_Object_Handler:AndroidX.Activity.Result.IActivityResultCallbackInvoker, Xamarin.AndroidX.Activity")]
		void OnActivityResult(Java.Lang.Object result);
	}
	[Register("androidx/activity/result/ActivityResultCallback", DoNotGenerateAcw = true)]
	internal class IActivityResultCallbackInvoker : Java.Lang.Object, IActivityResultCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultCallback", typeof(IActivityResultCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onActivityResult_Ljava_lang_Object_;

		private IntPtr id_onActivityResult_Ljava_lang_Object_;

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

		public static IActivityResultCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IActivityResultCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.result.ActivityResultCallback'.");
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

		public IActivityResultCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnActivityResult_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onActivityResult_Ljava_lang_Object_ == null)
			{
				cb_onActivityResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnActivityResult_Ljava_lang_Object_));
			}
			return cb_onActivityResult_Ljava_lang_Object_;
		}

		private static void n_OnActivityResult_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			IActivityResultCallback activityResultCallback = Java.Lang.Object.GetObject<IActivityResultCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			activityResultCallback.OnActivityResult(result);
		}

		public unsafe void OnActivityResult(Java.Lang.Object result)
		{
			if (id_onActivityResult_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_onActivityResult_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onActivityResult", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(result);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onActivityResult_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("androidx/activity/result/ActivityResultCaller", "", "AndroidX.Activity.Result.IActivityResultCallerInvoker")]
	public interface IActivityResultCaller : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "GetRegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_Handler:AndroidX.Activity.Result.IActivityResultCallerInvoker, Xamarin.AndroidX.Activity")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback);

		[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "GetRegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_Handler:AndroidX.Activity.Result.IActivityResultCallerInvoker, Xamarin.AndroidX.Activity")]
		[JavaTypeParameters(new string[] { "I", "O" })]
		ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback);
	}
	[Register("androidx/activity/result/ActivityResultCaller", DoNotGenerateAcw = true)]
	internal class IActivityResultCallerInvoker : Java.Lang.Object, IActivityResultCaller, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultCaller", typeof(IActivityResultCallerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_;

		private IntPtr id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_;

		private static Delegate cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_;

		private IntPtr id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_;

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

		public static IActivityResultCaller GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IActivityResultCaller>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.result.ActivityResultCaller'.");
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

		public IActivityResultCallerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetRegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_Handler()
		{
			if ((object)cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_ == null)
			{
				cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_));
			}
			return cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_;
		}

		private static IntPtr n_RegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_contract, IntPtr native__callback)
		{
			IActivityResultCaller activityResultCaller = Java.Lang.Object.GetObject<IActivityResultCaller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActivityResultContract contract = Java.Lang.Object.GetObject<ActivityResultContract>(native_contract, JniHandleOwnership.DoNotTransfer);
			IActivityResultCallback callback = Java.Lang.Object.GetObject<IActivityResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultCaller.RegisterForActivityResult(contract, callback));
		}

		public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback)
		{
			if (id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_ == IntPtr.Zero)
			{
				id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_ = JNIEnv.GetMethodID(class_ref, "registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(JNIEnv.CallObjectMethod(base.Handle, id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultCallback_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_Handler()
		{
			if ((object)cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_ == null)
			{
				cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_RegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_));
			}
			return cb_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_;
		}

		private static IntPtr n_RegisterForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_contract, IntPtr native_registry, IntPtr native__callback)
		{
			IActivityResultCaller activityResultCaller = Java.Lang.Object.GetObject<IActivityResultCaller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActivityResultContract contract = Java.Lang.Object.GetObject<ActivityResultContract>(native_contract, JniHandleOwnership.DoNotTransfer);
			ActivityResultRegistry registry = Java.Lang.Object.GetObject<ActivityResultRegistry>(native_registry, JniHandleOwnership.DoNotTransfer);
			IActivityResultCallback callback = Java.Lang.Object.GetObject<IActivityResultCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultCaller.RegisterForActivityResult(contract, registry, callback));
		}

		public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback)
		{
			if (id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_ == IntPtr.Zero)
			{
				id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_ = JNIEnv.GetMethodID(class_ref, "registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(registry?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(JNIEnv.CallObjectMethod(base.Handle, id_registerForActivityResult_Landroidx_activity_result_contract_ActivityResultContract_Landroidx_activity_result_ActivityResultRegistry_Landroidx_activity_result_ActivityResultCallback_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/activity/result/ActivityResultRegistryOwner", "", "AndroidX.Activity.Result.IActivityResultRegistryOwnerInvoker")]
	public interface IActivityResultRegistryOwner : IJavaObject, IDisposable, IJavaPeerable
	{
		ActivityResultRegistry ActivityResultRegistry
		{
			[Register("getActivityResultRegistry", "()Landroidx/activity/result/ActivityResultRegistry;", "GetGetActivityResultRegistryHandler:AndroidX.Activity.Result.IActivityResultRegistryOwnerInvoker, Xamarin.AndroidX.Activity")]
			get;
		}
	}
	[Register("androidx/activity/result/ActivityResultRegistryOwner", DoNotGenerateAcw = true)]
	internal class IActivityResultRegistryOwnerInvoker : Java.Lang.Object, IActivityResultRegistryOwner, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultRegistryOwner", typeof(IActivityResultRegistryOwnerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getActivityResultRegistry;

		private IntPtr id_getActivityResultRegistry;

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

		public ActivityResultRegistry ActivityResultRegistry
		{
			get
			{
				if (id_getActivityResultRegistry == IntPtr.Zero)
				{
					id_getActivityResultRegistry = JNIEnv.GetMethodID(class_ref, "getActivityResultRegistry", "()Landroidx/activity/result/ActivityResultRegistry;");
				}
				return Java.Lang.Object.GetObject<ActivityResultRegistry>(JNIEnv.CallObjectMethod(base.Handle, id_getActivityResultRegistry), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IActivityResultRegistryOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IActivityResultRegistryOwner>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.activity.result.ActivityResultRegistryOwner'.");
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

		public IActivityResultRegistryOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetActivityResultRegistryHandler()
		{
			if ((object)cb_getActivityResultRegistry == null)
			{
				cb_getActivityResultRegistry = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetActivityResultRegistry));
			}
			return cb_getActivityResultRegistry;
		}

		private static IntPtr n_GetActivityResultRegistry(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IActivityResultRegistryOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActivityResultRegistry);
		}
	}
}
namespace AndroidX.Activity.Result.Contract
{
	internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
	[Register("androidx/activity/result/contract/ActivityResultContract", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public abstract class ActivityResultContract : Java.Lang.Object
	{
		[Register("androidx/activity/result/contract/ActivityResultContract$SynchronousResult", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "T" })]
		public sealed class SynchronousResult : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract$SynchronousResult", typeof(SynchronousResult));

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

			public unsafe Java.Lang.Object Value
			{
				[Register("getValue", "()Ljava/lang/Object;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal SynchronousResult(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Ljava/lang/Object;)V", "")]
			public unsafe SynchronousResult(Java.Lang.Object value)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract", typeof(ActivityResultContract));

		private static Delegate cb_createIntent_Landroid_content_Context_Ljava_lang_Object_;

		private static Delegate cb_getSynchronousResult_Landroid_content_Context_Ljava_lang_Object_;

		private static Delegate cb_parseResult_ILandroid_content_Intent_;

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

		protected ActivityResultContract(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ActivityResultContract()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler()
		{
			if ((object)cb_createIntent_Landroid_content_Context_Ljava_lang_Object_ == null)
			{
				cb_createIntent_Landroid_content_Context_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLL_L(n_CreateIntent_Landroid_content_Context_Ljava_lang_Object_));
			}
			return cb_createIntent_Landroid_content_Context_Ljava_lang_Object_;
		}

		private static IntPtr n_CreateIntent_Landroid_content_Context_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_input)
		{
			ActivityResultContract activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.CreateIntent(context, input));
		}

		[Register("createIntent", "(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler")]
		public abstract Intent CreateIntent(Context context, Java.Lang.Object input);

		private static Delegate GetGetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_Handler()
		{
			if ((object)cb_getSynchronousResult_Landroid_content_Context_Ljava_lang_Object_ == null)
			{
				cb_getSynchronousResult_Landroid_content_Context_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLL_L(n_GetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_));
			}
			return cb_getSynchronousResult_Landroid_content_Context_Ljava_lang_Object_;
		}

		private static IntPtr n_GetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_input)
		{
			ActivityResultContract activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.GetSynchronousResult(context, input));
		}

		[Register("getSynchronousResult", "(Landroid/content/Context;Ljava/lang/Object;)Landroidx/activity/result/contract/ActivityResultContract$SynchronousResult;", "GetGetSynchronousResult_Landroid_content_Context_Ljava_lang_Object_Handler")]
		public unsafe virtual SynchronousResult GetSynchronousResult(Context context, Java.Lang.Object input)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SynchronousResult>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSynchronousResult.(Landroid/content/Context;Ljava/lang/Object;)Landroidx/activity/result/contract/ActivityResultContract$SynchronousResult;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(input);
			}
		}

		private static Delegate GetParseResult_ILandroid_content_Intent_Handler()
		{
			if ((object)cb_parseResult_ILandroid_content_Intent_ == null)
			{
				cb_parseResult_ILandroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_ParseResult_ILandroid_content_Intent_));
			}
			return cb_parseResult_ILandroid_content_Intent_;
		}

		private static IntPtr n_ParseResult_ILandroid_content_Intent_(IntPtr jnienv, IntPtr native__this, int resultCode, IntPtr native_intent)
		{
			ActivityResultContract activityResultContract = Java.Lang.Object.GetObject<ActivityResultContract>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(activityResultContract.ParseResult(resultCode, intent));
		}

		[Register("parseResult", "(ILandroid/content/Intent;)Ljava/lang/Object;", "GetParseResult_ILandroid_content_Intent_Handler")]
		public abstract Java.Lang.Object ParseResult(int resultCode, Intent intent);
	}
	[Register("androidx/activity/result/contract/ActivityResultContract", DoNotGenerateAcw = true)]
	internal class ActivityResultContractInvoker : ActivityResultContract
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract", typeof(ActivityResultContractInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ActivityResultContractInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createIntent", "(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler")]
		public unsafe override Intent CreateIntent(Context context, Java.Lang.Object input)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(input);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("createIntent.(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(context);
				GC.KeepAlive(input);
			}
		}

		[Register("parseResult", "(ILandroid/content/Intent;)Ljava/lang/Object;", "GetParseResult_ILandroid_content_Intent_Handler")]
		public unsafe override Java.Lang.Object ParseResult(int resultCode, Intent intent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(resultCode);
				ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("parseResult.(ILandroid/content/Intent;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(intent);
			}
		}
	}
}
