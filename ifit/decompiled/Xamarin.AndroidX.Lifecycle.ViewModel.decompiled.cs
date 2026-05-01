using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Runtime;
using AndroidX.Lifecycle.ViewModels;
using Java.Interop;
using Java.Lang;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "791ebe2cb9b9b044bb1d30e9bd4c6097326f4bbe")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20230120.4")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "1/20/2023 8:31:40 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.lifecycle", Managed = "AndroidX.Lifecycle")]
[assembly: NamespaceMapping(Java = "androidx.lifecycle.viewmodel", Managed = "AndroidX.Lifecycle.ViewModels")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.lifecycle:lifecycle-viewmodel'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Lifecycle.ViewModel")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Lifecycle.ViewModel")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}
	}
}
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
namespace AndroidX.Lifecycle
{
	[Register("androidx/lifecycle/HasDefaultViewModelProviderFactory", "", "AndroidX.Lifecycle.IHasDefaultViewModelProviderFactoryInvoker")]
	public interface IHasDefaultViewModelProviderFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		ViewModelProvider.IFactory DefaultViewModelProviderFactory
		{
			[Register("getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;", "GetGetDefaultViewModelProviderFactoryHandler:AndroidX.Lifecycle.IHasDefaultViewModelProviderFactoryInvoker, Xamarin.AndroidX.Lifecycle.ViewModel")]
			get;
		}
	}
	[Register("androidx/lifecycle/HasDefaultViewModelProviderFactory", DoNotGenerateAcw = true)]
	internal class IHasDefaultViewModelProviderFactoryInvoker : Java.Lang.Object, IHasDefaultViewModelProviderFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/HasDefaultViewModelProviderFactory", typeof(IHasDefaultViewModelProviderFactoryInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getDefaultViewModelProviderFactory;

		private IntPtr id_getDefaultViewModelProviderFactory;

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

		public ViewModelProvider.IFactory DefaultViewModelProviderFactory
		{
			get
			{
				if (id_getDefaultViewModelProviderFactory == IntPtr.Zero)
				{
					id_getDefaultViewModelProviderFactory = JNIEnv.GetMethodID(class_ref, "getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;");
				}
				return Java.Lang.Object.GetObject<ViewModelProvider.IFactory>(JNIEnv.CallObjectMethod(base.Handle, id_getDefaultViewModelProviderFactory), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IHasDefaultViewModelProviderFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHasDefaultViewModelProviderFactory>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.lifecycle.HasDefaultViewModelProviderFactory'.");
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

		public IHasDefaultViewModelProviderFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IHasDefaultViewModelProviderFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelProviderFactory);
		}
	}
	[Register("androidx/lifecycle/ViewModelStoreOwner", "", "AndroidX.Lifecycle.IViewModelStoreOwnerInvoker")]
	public interface IViewModelStoreOwner : IJavaObject, IDisposable, IJavaPeerable
	{
		ViewModelStore ViewModelStore
		{
			[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler:AndroidX.Lifecycle.IViewModelStoreOwnerInvoker, Xamarin.AndroidX.Lifecycle.ViewModel")]
			get;
		}
	}
	[Register("androidx/lifecycle/ViewModelStoreOwner", DoNotGenerateAcw = true)]
	internal class IViewModelStoreOwnerInvoker : Java.Lang.Object, IViewModelStoreOwner, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelStoreOwner", typeof(IViewModelStoreOwnerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getViewModelStore;

		private IntPtr id_getViewModelStore;

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

		public ViewModelStore ViewModelStore
		{
			get
			{
				if (id_getViewModelStore == IntPtr.Zero)
				{
					id_getViewModelStore = JNIEnv.GetMethodID(class_ref, "getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;");
				}
				return Java.Lang.Object.GetObject<ViewModelStore>(JNIEnv.CallObjectMethod(base.Handle, id_getViewModelStore), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IViewModelStoreOwner GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IViewModelStoreOwner>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.lifecycle.ViewModelStoreOwner'.");
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

		public IViewModelStoreOwnerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IViewModelStoreOwner>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
		}
	}
	[Register("androidx/lifecycle/ViewModelProvider", DoNotGenerateAcw = true)]
	public class ViewModelProvider : Java.Lang.Object
	{
		[Register("androidx/lifecycle/ViewModelProvider$Factory", "", "AndroidX.Lifecycle.ViewModelProvider/IFactoryInvoker")]
		public interface IFactory : IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("androidx/lifecycle/ViewModelProvider$Factory", DoNotGenerateAcw = true)]
		internal class IFactoryInvoker : Java.Lang.Object, IFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider$Factory", typeof(IFactoryInvoker));

			private IntPtr class_ref;

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

			public static IFactory GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IFactory>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.lifecycle.ViewModelProvider.Factory'.");
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

			public IFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelProvider", typeof(ViewModelProvider));

		private static Delegate cb_get_Ljava_lang_Class_;

		private static Delegate cb_get_Ljava_lang_String_Ljava_lang_Class_;

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

		protected ViewModelProvider(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", "")]
		public unsafe ViewModelProvider(ViewModelStore store, IFactory factory)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(store?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(store);
				GC.KeepAlive(factory);
			}
		}

		[Register(".ctor", "(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", "")]
		public unsafe ViewModelProvider(ViewModelStore store, IFactory factory, CreationExtras defaultCreationExtras)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(store?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				ptr[2] = new JniArgumentValue(defaultCreationExtras?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStore;Landroidx/lifecycle/ViewModelProvider$Factory;Landroidx/lifecycle/viewmodel/CreationExtras;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(store);
				GC.KeepAlive(factory);
				GC.KeepAlive(defaultCreationExtras);
			}
		}

		[Register(".ctor", "(Landroidx/lifecycle/ViewModelStoreOwner;)V", "")]
		public unsafe ViewModelProvider(IViewModelStoreOwner owner)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
			}
		}

		[Register(".ctor", "(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", "")]
		public unsafe ViewModelProvider(IViewModelStoreOwner owner, IFactory factory)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
				ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/lifecycle/ViewModelStoreOwner;Landroidx/lifecycle/ViewModelProvider$Factory;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
				GC.KeepAlive(factory);
			}
		}

		private static Delegate GetGet_Ljava_lang_Class_Handler()
		{
			if ((object)cb_get_Ljava_lang_Class_ == null)
			{
				cb_get_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_Class_));
			}
			return cb_get_Ljava_lang_Class_;
		}

		private static IntPtr n_Get_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_modelClass)
		{
			ViewModelProvider viewModelProvider = Java.Lang.Object.GetObject<ViewModelProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewModelProvider.Get(modelClass));
		}

		[Register("get", "(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetGet_Ljava_lang_Class_Handler")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		public unsafe virtual Java.Lang.Object Get(Class modelClass)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(modelClass);
			}
		}

		private static Delegate GetGet_Ljava_lang_String_Ljava_lang_Class_Handler()
		{
			if ((object)cb_get_Ljava_lang_String_Ljava_lang_Class_ == null)
			{
				cb_get_Ljava_lang_String_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Get_Ljava_lang_String_Ljava_lang_Class_));
			}
			return cb_get_Ljava_lang_String_Ljava_lang_Class_;
		}

		private static IntPtr n_Get_Ljava_lang_String_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_modelClass)
		{
			ViewModelProvider viewModelProvider = Java.Lang.Object.GetObject<ViewModelProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Class modelClass = Java.Lang.Object.GetObject<Class>(native_modelClass, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewModelProvider.Get(key, modelClass));
		}

		[Register("get", "(Ljava/lang/String;Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", "GetGet_Ljava_lang_String_Ljava_lang_Class_Handler")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.ViewModel" })]
		public unsafe virtual Java.Lang.Object Get(string key, Class modelClass)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(modelClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/String;Ljava/lang/Class;)Landroidx/lifecycle/ViewModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(modelClass);
			}
		}
	}
	[Register("androidx/lifecycle/ViewModelStore", DoNotGenerateAcw = true)]
	public class ViewModelStore : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModelStore", typeof(ViewModelStore));

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

		protected ViewModelStore(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ViewModelStore()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clear.()V", this, null);
		}
	}
}
namespace AndroidX.Lifecycle.ViewModels
{
	[Register("androidx/lifecycle/viewmodel/CreationExtras", DoNotGenerateAcw = true)]
	public abstract class CreationExtras : Java.Lang.Object
	{
		[Register("androidx/lifecycle/viewmodel/CreationExtras$Key", "", "AndroidX.Lifecycle.ViewModels.CreationExtras/IKeyInvoker")]
		[JavaTypeParameters(new string[] { "T" })]
		public interface IKey : IJavaObject, IDisposable, IJavaPeerable
		{
		}

		[Register("androidx/lifecycle/viewmodel/CreationExtras$Key", DoNotGenerateAcw = true)]
		internal class IKeyInvoker : Java.Lang.Object, IKey, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras$Key", typeof(IKeyInvoker));

			private IntPtr class_ref;

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

			public static IKey GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IKey>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.lifecycle.viewmodel.CreationExtras.Key'.");
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

			public IKeyInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras", typeof(CreationExtras));

		private static Delegate cb_get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_;

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

		protected CreationExtras(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler()
		{
			if ((object)cb_get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_ == null)
			{
				cb_get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_));
			}
			return cb_get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_;
		}

		private static IntPtr n_Get_Landroidx_lifecycle_viewmodel_CreationExtras_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			CreationExtras creationExtras = Java.Lang.Object.GetObject<CreationExtras>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey key = Java.Lang.Object.GetObject<IKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(creationExtras.Get(key));
		}

		[Register("get", "(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", "GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler")]
		[JavaTypeParameters(new string[] { "T" })]
		public abstract Java.Lang.Object Get(IKey key);
	}
	[Register("androidx/lifecycle/viewmodel/CreationExtras", DoNotGenerateAcw = true)]
	internal class CreationExtrasInvoker : CreationExtras
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras", typeof(CreationExtrasInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CreationExtrasInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("get", "(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", "GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe override Java.Lang.Object Get(IKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}
	}
}
