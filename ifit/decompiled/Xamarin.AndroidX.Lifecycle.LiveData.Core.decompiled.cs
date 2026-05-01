using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Runtime;
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
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.lifecycle:lifecycle-livedata-core'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Lifecycle.LiveData.Core")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Lifecycle.LiveData.Core")]
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
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
namespace AndroidX.Lifecycle
{
	[Register("androidx/lifecycle/Observer", "", "AndroidX.Lifecycle.IObserverInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IObserver : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onChanged", "(Ljava/lang/Object;)V", "GetOnChanged_Ljava_lang_Object_Handler:AndroidX.Lifecycle.IObserverInvoker, Xamarin.AndroidX.Lifecycle.LiveData.Core")]
		void OnChanged(Java.Lang.Object p0);
	}
	[Register("androidx/lifecycle/Observer", DoNotGenerateAcw = true)]
	internal class IObserverInvoker : Java.Lang.Object, IObserver, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Observer", typeof(IObserverInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onChanged_Ljava_lang_Object_;

		private IntPtr id_onChanged_Ljava_lang_Object_;

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

		public static IObserver GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IObserver>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.lifecycle.Observer'.");
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

		public IObserverInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnChanged_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onChanged_Ljava_lang_Object_ == null)
			{
				cb_onChanged_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnChanged_Ljava_lang_Object_));
			}
			return cb_onChanged_Ljava_lang_Object_;
		}

		private static void n_OnChanged_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			observer.OnChanged(p);
		}

		public unsafe void OnChanged(Java.Lang.Object p0)
		{
			if (id_onChanged_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_onChanged_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onChanged", "(Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_onChanged_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}
	[Register("androidx/lifecycle/LiveData", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public abstract class LiveData : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LiveData", typeof(LiveData));

		private static Delegate cb_hasActiveObservers;

		private static Delegate cb_hasObservers;

		private static Delegate cb_getValue;

		private static Delegate cb_observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_;

		private static Delegate cb_observeForever_Landroidx_lifecycle_Observer_;

		private static Delegate cb_onActive;

		private static Delegate cb_onInactive;

		private static Delegate cb_postValue_Ljava_lang_Object_;

		private static Delegate cb_removeObserver_Landroidx_lifecycle_Observer_;

		private static Delegate cb_removeObservers_Landroidx_lifecycle_LifecycleOwner_;

		private static Delegate cb_setValue_Ljava_lang_Object_;

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

		public unsafe virtual bool HasActiveObservers
		{
			[Register("hasActiveObservers", "()Z", "GetHasActiveObserversHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasActiveObservers.()Z", this, null);
			}
		}

		public unsafe virtual bool HasObservers
		{
			[Register("hasObservers", "()Z", "GetHasObserversHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasObservers.()Z", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LiveData(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LiveData()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/Object;)V", "")]
		public unsafe LiveData(Java.Lang.Object value)
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

		private static Delegate GetHasActiveObserversHandler()
		{
			if ((object)cb_hasActiveObservers == null)
			{
				cb_hasActiveObservers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasActiveObservers));
			}
			return cb_hasActiveObservers;
		}

		private static bool n_HasActiveObservers(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasActiveObservers;
		}

		private static Delegate GetHasObserversHandler()
		{
			if ((object)cb_hasObservers == null)
			{
				cb_hasObservers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasObservers));
			}
			return cb_hasObservers;
		}

		private static bool n_HasObservers(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasObservers;
		}

		private static Delegate GetGetValueHandler()
		{
			if ((object)cb_getValue == null)
			{
				cb_getValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetValue));
			}
			return cb_getValue;
		}

		private static IntPtr n_GetValue(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
		}

		private static Delegate GetObserve_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_Handler()
		{
			if ((object)cb_observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_ == null)
			{
				cb_observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_));
			}
			return cb_observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_;
		}

		private static void n_Observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_(IntPtr jnienv, IntPtr native__this, IntPtr native_owner, IntPtr native_observer)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.Observe(owner, observer);
		}

		[Register("observe", "(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V", "GetObserve_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_Handler")]
		public unsafe virtual void Observe(ILifecycleOwner owner, IObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
				ptr[1] = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("observe.(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetObserveForever_Landroidx_lifecycle_Observer_Handler()
		{
			if ((object)cb_observeForever_Landroidx_lifecycle_Observer_ == null)
			{
				cb_observeForever_Landroidx_lifecycle_Observer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ObserveForever_Landroidx_lifecycle_Observer_));
			}
			return cb_observeForever_Landroidx_lifecycle_Observer_;
		}

		private static void n_ObserveForever_Landroidx_lifecycle_Observer_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.ObserveForever(observer);
		}

		[Register("observeForever", "(Landroidx/lifecycle/Observer;)V", "GetObserveForever_Landroidx_lifecycle_Observer_Handler")]
		public unsafe virtual void ObserveForever(IObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("observeForever.(Landroidx/lifecycle/Observer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetOnActiveHandler()
		{
			if ((object)cb_onActive == null)
			{
				cb_onActive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnActive));
			}
			return cb_onActive;
		}

		private static void n_OnActive(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnActive();
		}

		[Register("onActive", "()V", "GetOnActiveHandler")]
		protected unsafe virtual void OnActive()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onActive.()V", this, null);
		}

		private static Delegate GetOnInactiveHandler()
		{
			if ((object)cb_onInactive == null)
			{
				cb_onInactive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnInactive));
			}
			return cb_onInactive;
		}

		private static void n_OnInactive(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnInactive();
		}

		[Register("onInactive", "()V", "GetOnInactiveHandler")]
		protected unsafe virtual void OnInactive()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInactive.()V", this, null);
		}

		private static Delegate GetPostValue_Ljava_lang_Object_Handler()
		{
			if ((object)cb_postValue_Ljava_lang_Object_ == null)
			{
				cb_postValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PostValue_Ljava_lang_Object_));
			}
			return cb_postValue_Ljava_lang_Object_;
		}

		private static void n_PostValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			liveData.PostValue(value);
		}

		[Register("postValue", "(Ljava/lang/Object;)V", "GetPostValue_Ljava_lang_Object_Handler")]
		protected unsafe virtual void PostValue(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("postValue.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		private static Delegate GetRemoveObserver_Landroidx_lifecycle_Observer_Handler()
		{
			if ((object)cb_removeObserver_Landroidx_lifecycle_Observer_ == null)
			{
				cb_removeObserver_Landroidx_lifecycle_Observer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveObserver_Landroidx_lifecycle_Observer_));
			}
			return cb_removeObserver_Landroidx_lifecycle_Observer_;
		}

		private static void n_RemoveObserver_Landroidx_lifecycle_Observer_(IntPtr jnienv, IntPtr native__this, IntPtr native_observer)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.RemoveObserver(observer);
		}

		[Register("removeObserver", "(Landroidx/lifecycle/Observer;)V", "GetRemoveObserver_Landroidx_lifecycle_Observer_Handler")]
		public unsafe virtual void RemoveObserver(IObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeObserver.(Landroidx/lifecycle/Observer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetRemoveObservers_Landroidx_lifecycle_LifecycleOwner_Handler()
		{
			if ((object)cb_removeObservers_Landroidx_lifecycle_LifecycleOwner_ == null)
			{
				cb_removeObservers_Landroidx_lifecycle_LifecycleOwner_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveObservers_Landroidx_lifecycle_LifecycleOwner_));
			}
			return cb_removeObservers_Landroidx_lifecycle_LifecycleOwner_;
		}

		private static void n_RemoveObservers_Landroidx_lifecycle_LifecycleOwner_(IntPtr jnienv, IntPtr native__this, IntPtr native_owner)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			liveData.RemoveObservers(owner);
		}

		[Register("removeObservers", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetRemoveObservers_Landroidx_lifecycle_LifecycleOwner_Handler")]
		public unsafe virtual void RemoveObservers(ILifecycleOwner owner)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeObservers.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
			}
		}

		private static Delegate GetSetValue_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setValue_Ljava_lang_Object_ == null)
			{
				cb_setValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetValue_Ljava_lang_Object_));
			}
			return cb_setValue_Ljava_lang_Object_;
		}

		private static void n_SetValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			LiveData liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			liveData.SetValue(value);
		}

		[Register("setValue", "(Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_Object_Handler")]
		protected unsafe virtual void SetValue(Java.Lang.Object value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}
	}
	[Register("androidx/lifecycle/LiveData", DoNotGenerateAcw = true)]
	internal class LiveDataInvoker : LiveData
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LiveData", typeof(LiveDataInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LiveDataInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
