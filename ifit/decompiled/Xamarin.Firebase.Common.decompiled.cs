using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "1766705fdc7606e438de5489db239dbbdfd81f96")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220916.5")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "9/16/2022 9:57:55 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.firebase.components", Managed = "Firebase.Components")]
[assembly: NamespaceMapping(Java = "com.google.firebase", Managed = "Firebase")]
[assembly: NamespaceMapping(Java = "com.google.firebase.annotations", Managed = "Firebase.Annotations")]
[assembly: NamespaceMapping(Java = "com.google.firebase.emulators", Managed = "Firebase.Emulators")]
[assembly: NamespaceMapping(Java = "com.google.firebase.heartbeatinfo", Managed = "Firebase.HeartBeatInfo")]
[assembly: NamespaceMapping(Java = "com.google.firebase.internal", Managed = "Firebase.Internal")]
[assembly: NamespaceMapping(Java = "com.google.firebase.platforminfo", Managed = "Firebase.PlatformInfo")]
[assembly: NamespaceMapping(Java = "com.google.firebase.provider", Managed = "Firebase.Provider")]
[assembly: NamespaceMapping(Java = "com.google.firebase.tracing", Managed = "Firebase.Tracing")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\n        Xamarin.Android Bindings for Google Play Services - Xamarin.Firebase.Common 120.1.2 artifact=com.google.firebase:firebase-common artifact_versioned=com.google.firebase:firebase-common:20.1.2\n\n        \n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Firebase.Common")]
[assembly: AssemblyTitle("Xamarin.Firebase.Common")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace Firebase;

[Register("com/google/firebase/FirebaseApp", DoNotGenerateAcw = true)]
public class FirebaseApp : Java.Lang.Object
{
	[Register("com/google/firebase/FirebaseApp$BackgroundStateChangeListener", "", "Firebase.FirebaseApp/IBackgroundStateChangeListenerInvoker")]
	public interface IBackgroundStateChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onBackgroundStateChanged", "(Z)V", "GetOnBackgroundStateChanged_ZHandler:Firebase.FirebaseApp/IBackgroundStateChangeListenerInvoker, Xamarin.Firebase.Common")]
		void OnBackgroundStateChanged(bool p0);
	}

	[Register("com/google/firebase/FirebaseApp$BackgroundStateChangeListener", DoNotGenerateAcw = true)]
	internal class IBackgroundStateChangeListenerInvoker : Java.Lang.Object, IBackgroundStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/FirebaseApp$BackgroundStateChangeListener", typeof(IBackgroundStateChangeListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onBackgroundStateChanged_Z;

		private IntPtr id_onBackgroundStateChanged_Z;

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

		public static IBackgroundStateChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBackgroundStateChangeListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.firebase.FirebaseApp.BackgroundStateChangeListener'.");
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

		public IBackgroundStateChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnBackgroundStateChanged_ZHandler()
		{
			if ((object)cb_onBackgroundStateChanged_Z == null)
			{
				cb_onBackgroundStateChanged_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnBackgroundStateChanged_Z));
			}
			return cb_onBackgroundStateChanged_Z;
		}

		private static void n_OnBackgroundStateChanged_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			Java.Lang.Object.GetObject<IBackgroundStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackgroundStateChanged(p0);
		}

		public unsafe void OnBackgroundStateChanged(bool p0)
		{
			if (id_onBackgroundStateChanged_Z == IntPtr.Zero)
			{
				id_onBackgroundStateChanged_Z = JNIEnv.GetMethodID(class_ref, "onBackgroundStateChanged", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_onBackgroundStateChanged_Z, ptr);
		}
	}

	public class BackgroundStateChangeEventArgs : EventArgs
	{
		private bool p0;

		public BackgroundStateChangeEventArgs(bool p0)
		{
			this.p0 = p0;
		}
	}

	[Register("mono/com/google/firebase/FirebaseApp_BackgroundStateChangeListenerImplementor")]
	internal sealed class IBackgroundStateChangeListenerImplementor : Java.Lang.Object, IBackgroundStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object sender;

		public EventHandler<BackgroundStateChangeEventArgs> Handler;

		public IBackgroundStateChangeListenerImplementor(object sender)
			: base(JNIEnv.StartCreateInstance("mono/com/google/firebase/FirebaseApp_BackgroundStateChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			this.sender = sender;
		}

		public void OnBackgroundStateChanged(bool p0)
		{
			Handler?.Invoke(sender, new BackgroundStateChangeEventArgs(p0));
		}

		internal static bool __IsEmpty(IBackgroundStateChangeListenerImplementor value)
		{
			return value.Handler == null;
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/FirebaseApp", typeof(FirebaseApp));

	private static Delegate cb_getApplicationContext;

	private static Delegate cb_isDataCollectionDefaultEnabled;

	private static Delegate cb_setDataCollectionDefaultEnabled_Z;

	private static Delegate cb_isDefaultApp;

	private static Delegate cb_getName;

	private static Delegate cb_getOptions;

	private static Delegate cb_getPersistenceKey;

	private static Delegate cb_addBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_;

	private static Delegate cb_addLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_;

	private static Delegate cb_delete;

	private static Delegate cb_get_Ljava_lang_Class_;

	private static Delegate cb_removeBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_;

	private static Delegate cb_removeLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_;

	private static Delegate cb_setAutomaticResourceManagementEnabled_Z;

	private static Delegate cb_setDataCollectionDefaultEnabled_Ljava_lang_Boolean_;

	private WeakReference weak_implementor_AddBackgroundStateChangeListener;

	private WeakReference weak_implementor_AddLifecycleEventListener;

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

	public unsafe virtual Context ApplicationContext
	{
		[Register("getApplicationContext", "()Landroid/content/Context;", "GetGetApplicationContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool DataCollectionDefaultEnabled
	{
		[Register("isDataCollectionDefaultEnabled", "()Z", "GetIsDataCollectionDefaultEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDataCollectionDefaultEnabled.()Z", this, null);
		}
		[Register("setDataCollectionDefaultEnabled", "(Z)V", "GetSetDataCollectionDefaultEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDataCollectionDefaultEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe static FirebaseApp Instance
	{
		[Register("getInstance", "()Lcom/google/firebase/FirebaseApp;", "")]
		get
		{
			return Java.Lang.Object.GetObject<FirebaseApp>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Lcom/google/firebase/FirebaseApp;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDefaultApp
	{
		[Register("isDefaultApp", "()Z", "GetIsDefaultAppHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDefaultApp.()Z", this, null);
		}
	}

	public unsafe virtual string Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual FirebaseOptions Options
	{
		[Register("getOptions", "()Lcom/google/firebase/FirebaseOptions;", "GetGetOptionsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FirebaseOptions>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOptions.()Lcom/google/firebase/FirebaseOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string PersistenceKey
	{
		[Register("getPersistenceKey", "()Ljava/lang/String;", "GetGetPersistenceKeyHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getPersistenceKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<BackgroundStateChangeEventArgs> BackgroundStateChange
	{
		add
		{
			EventHelper.AddEventHandler<IBackgroundStateChangeListener, IBackgroundStateChangeListenerImplementor>(ref weak_implementor_AddBackgroundStateChangeListener, __CreateIBackgroundStateChangeListenerImplementor, AddBackgroundStateChangeListener, delegate(IBackgroundStateChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<BackgroundStateChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddBackgroundStateChangeListener, IBackgroundStateChangeListenerImplementor.__IsEmpty, delegate(IBackgroundStateChangeListener __v)
			{
				RemoveBackgroundStateChangeListener(__v);
			}, delegate(IBackgroundStateChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<BackgroundStateChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<FirebaseAppLifecycleEventArgs> LifecycleEvent
	{
		add
		{
			EventHelper.AddEventHandler<IFirebaseAppLifecycleListener, IFirebaseAppLifecycleListenerImplementor>(ref weak_implementor_AddLifecycleEventListener, __CreateIFirebaseAppLifecycleListenerImplementor, AddLifecycleEventListener, delegate(IFirebaseAppLifecycleListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FirebaseAppLifecycleEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddLifecycleEventListener, IFirebaseAppLifecycleListenerImplementor.__IsEmpty, delegate(IFirebaseAppLifecycleListener __v)
			{
				RemoveLifecycleEventListener(__v);
			}, delegate(IFirebaseAppLifecycleListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FirebaseAppLifecycleEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected FirebaseApp(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)V", "")]
	protected unsafe FirebaseApp(Context applicationContext, string name, FirebaseOptions options)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(applicationContext?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(applicationContext);
			GC.KeepAlive(options);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationContext);
	}

	private static Delegate GetIsDataCollectionDefaultEnabledHandler()
	{
		if ((object)cb_isDataCollectionDefaultEnabled == null)
		{
			cb_isDataCollectionDefaultEnabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDataCollectionDefaultEnabled));
		}
		return cb_isDataCollectionDefaultEnabled;
	}

	private static bool n_IsDataCollectionDefaultEnabled(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataCollectionDefaultEnabled;
	}

	private static Delegate GetSetDataCollectionDefaultEnabled_ZHandler()
	{
		if ((object)cb_setDataCollectionDefaultEnabled_Z == null)
		{
			cb_setDataCollectionDefaultEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetDataCollectionDefaultEnabled_Z));
		}
		return cb_setDataCollectionDefaultEnabled_Z;
	}

	private static void n_SetDataCollectionDefaultEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataCollectionDefaultEnabled = enabled;
	}

	private static Delegate GetIsDefaultAppHandler()
	{
		if ((object)cb_isDefaultApp == null)
		{
			cb_isDefaultApp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDefaultApp));
		}
		return cb_isDefaultApp;
	}

	private static bool n_IsDefaultApp(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDefaultApp;
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
	}

	private static Delegate GetGetOptionsHandler()
	{
		if ((object)cb_getOptions == null)
		{
			cb_getOptions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOptions));
		}
		return cb_getOptions;
	}

	private static IntPtr n_GetOptions(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Options);
	}

	private static Delegate GetGetPersistenceKeyHandler()
	{
		if ((object)cb_getPersistenceKey == null)
		{
			cb_getPersistenceKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPersistenceKey));
		}
		return cb_getPersistenceKey;
	}

	private static IntPtr n_GetPersistenceKey(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PersistenceKey);
	}

	private static Delegate GetAddBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_Handler()
	{
		if ((object)cb_addBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_ == null)
		{
			cb_addBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_));
		}
		return cb_addBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_;
	}

	private static void n_AddBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IBackgroundStateChangeListener listener = Java.Lang.Object.GetObject<IBackgroundStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		firebaseApp.AddBackgroundStateChangeListener(listener);
	}

	[Register("addBackgroundStateChangeListener", "(Lcom/google/firebase/FirebaseApp$BackgroundStateChangeListener;)V", "GetAddBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_Handler")]
	public unsafe virtual void AddBackgroundStateChangeListener(IBackgroundStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addBackgroundStateChangeListener.(Lcom/google/firebase/FirebaseApp$BackgroundStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_Handler()
	{
		if ((object)cb_addLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_ == null)
		{
			cb_addLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_));
		}
		return cb_addLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_;
	}

	private static void n_AddLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IFirebaseAppLifecycleListener listener = Java.Lang.Object.GetObject<IFirebaseAppLifecycleListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		firebaseApp.AddLifecycleEventListener(listener);
	}

	[Register("addLifecycleEventListener", "(Lcom/google/firebase/FirebaseAppLifecycleListener;)V", "GetAddLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_Handler")]
	public unsafe virtual void AddLifecycleEventListener(IFirebaseAppLifecycleListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLifecycleEventListener.(Lcom/google/firebase/FirebaseAppLifecycleListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("clearInstancesForTest", "()V", "")]
	public unsafe static void ClearInstancesForTest()
	{
		_members.StaticMethods.InvokeVoidMethod("clearInstancesForTest.()V", null);
	}

	private static Delegate GetDeleteHandler()
	{
		if ((object)cb_delete == null)
		{
			cb_delete = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Delete));
		}
		return cb_delete;
	}

	private static void n_Delete(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delete();
	}

	[Register("delete", "()V", "GetDeleteHandler")]
	public unsafe virtual void Delete()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("delete.()V", this, null);
	}

	private static Delegate GetGet_Ljava_lang_Class_Handler()
	{
		if ((object)cb_get_Ljava_lang_Class_ == null)
		{
			cb_get_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_Class_));
		}
		return cb_get_Ljava_lang_Class_;
	}

	private static IntPtr n_Get_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_anInterface)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class anInterface = Java.Lang.Object.GetObject<Class>(native_anInterface, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(firebaseApp.Get(anInterface));
	}

	[Register("get", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGet_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe virtual Java.Lang.Object Get(Class anInterface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anInterface?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anInterface);
		}
	}

	[Register("getApps", "(Landroid/content/Context;)Ljava/util/List;", "")]
	public unsafe static IList<FirebaseApp> GetApps(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return JavaList<FirebaseApp>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getApps.(Landroid/content/Context;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getInstance", "(Ljava/lang/String;)Lcom/google/firebase/FirebaseApp;", "")]
	public unsafe static FirebaseApp GetInstance(string name)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FirebaseApp>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Lcom/google/firebase/FirebaseApp;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
		}
	}

	[Register("getPersistenceKey", "(Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)Ljava/lang/String;", "")]
	public unsafe static string GetPersistenceKey(string name, FirebaseOptions options)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intPtr);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getPersistenceKey.(Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(options);
		}
	}

	[Register("initializeApp", "(Landroid/content/Context;)Lcom/google/firebase/FirebaseApp;", "")]
	public unsafe static FirebaseApp InitializeApp(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FirebaseApp>(_members.StaticMethods.InvokeObjectMethod("initializeApp.(Landroid/content/Context;)Lcom/google/firebase/FirebaseApp;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("initializeApp", "(Landroid/content/Context;Lcom/google/firebase/FirebaseOptions;)Lcom/google/firebase/FirebaseApp;", "")]
	public unsafe static FirebaseApp InitializeApp(Context context, FirebaseOptions options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FirebaseApp>(_members.StaticMethods.InvokeObjectMethod("initializeApp.(Landroid/content/Context;Lcom/google/firebase/FirebaseOptions;)Lcom/google/firebase/FirebaseApp;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(options);
		}
	}

	[Register("initializeApp", "(Landroid/content/Context;Lcom/google/firebase/FirebaseOptions;Ljava/lang/String;)Lcom/google/firebase/FirebaseApp;", "")]
	public unsafe static FirebaseApp InitializeApp(Context context, FirebaseOptions options, string name)
	{
		IntPtr intPtr = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<FirebaseApp>(_members.StaticMethods.InvokeObjectMethod("initializeApp.(Landroid/content/Context;Lcom/google/firebase/FirebaseOptions;Ljava/lang/String;)Lcom/google/firebase/FirebaseApp;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(context);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetRemoveBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_Handler()
	{
		if ((object)cb_removeBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_ == null)
		{
			cb_removeBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_));
		}
		return cb_removeBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_;
	}

	private static void n_RemoveBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IBackgroundStateChangeListener listener = Java.Lang.Object.GetObject<IBackgroundStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		firebaseApp.RemoveBackgroundStateChangeListener(listener);
	}

	[Register("removeBackgroundStateChangeListener", "(Lcom/google/firebase/FirebaseApp$BackgroundStateChangeListener;)V", "GetRemoveBackgroundStateChangeListener_Lcom_google_firebase_FirebaseApp_BackgroundStateChangeListener_Handler")]
	public unsafe virtual void RemoveBackgroundStateChangeListener(IBackgroundStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeBackgroundStateChangeListener.(Lcom/google/firebase/FirebaseApp$BackgroundStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_Handler()
	{
		if ((object)cb_removeLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_ == null)
		{
			cb_removeLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_));
		}
		return cb_removeLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_;
	}

	private static void n_RemoveLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IFirebaseAppLifecycleListener listener = Java.Lang.Object.GetObject<IFirebaseAppLifecycleListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		firebaseApp.RemoveLifecycleEventListener(listener);
	}

	[Register("removeLifecycleEventListener", "(Lcom/google/firebase/FirebaseAppLifecycleListener;)V", "GetRemoveLifecycleEventListener_Lcom_google_firebase_FirebaseAppLifecycleListener_Handler")]
	public unsafe virtual void RemoveLifecycleEventListener(IFirebaseAppLifecycleListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeLifecycleEventListener.(Lcom/google/firebase/FirebaseAppLifecycleListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetAutomaticResourceManagementEnabled_ZHandler()
	{
		if ((object)cb_setAutomaticResourceManagementEnabled_Z == null)
		{
			cb_setAutomaticResourceManagementEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetAutomaticResourceManagementEnabled_Z));
		}
		return cb_setAutomaticResourceManagementEnabled_Z;
	}

	private static void n_SetAutomaticResourceManagementEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
	{
		Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAutomaticResourceManagementEnabled(enabled);
	}

	[Register("setAutomaticResourceManagementEnabled", "(Z)V", "GetSetAutomaticResourceManagementEnabled_ZHandler")]
	public unsafe virtual void SetAutomaticResourceManagementEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAutomaticResourceManagementEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetDataCollectionDefaultEnabled_Ljava_lang_Boolean_Handler()
	{
		if ((object)cb_setDataCollectionDefaultEnabled_Ljava_lang_Boolean_ == null)
		{
			cb_setDataCollectionDefaultEnabled_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDataCollectionDefaultEnabled_Ljava_lang_Boolean_));
		}
		return cb_setDataCollectionDefaultEnabled_Ljava_lang_Boolean_;
	}

	private static void n_SetDataCollectionDefaultEnabled_Ljava_lang_Boolean_(IntPtr jnienv, IntPtr native__this, IntPtr native_enabled)
	{
		FirebaseApp firebaseApp = Java.Lang.Object.GetObject<FirebaseApp>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Boolean dataCollectionDefaultEnabled = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_enabled, JniHandleOwnership.DoNotTransfer);
		firebaseApp.SetDataCollectionDefaultEnabled(dataCollectionDefaultEnabled);
	}

	[Register("setDataCollectionDefaultEnabled", "(Ljava/lang/Boolean;)V", "GetSetDataCollectionDefaultEnabled_Ljava_lang_Boolean_Handler")]
	public unsafe virtual void SetDataCollectionDefaultEnabled(Java.Lang.Boolean enabled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDataCollectionDefaultEnabled.(Ljava/lang/Boolean;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(enabled);
		}
	}

	private IBackgroundStateChangeListenerImplementor __CreateIBackgroundStateChangeListenerImplementor()
	{
		return new IBackgroundStateChangeListenerImplementor(this);
	}

	private IFirebaseAppLifecycleListenerImplementor __CreateIFirebaseAppLifecycleListenerImplementor()
	{
		return new IFirebaseAppLifecycleListenerImplementor(this);
	}
}
[Register("com/google/firebase/FirebaseOptions", DoNotGenerateAcw = true)]
public sealed class FirebaseOptions : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/FirebaseOptions", typeof(FirebaseOptions));

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

	public unsafe string ApiKey
	{
		[Register("getApiKey", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getApiKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string ApplicationId
	{
		[Register("getApplicationId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getApplicationId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string DatabaseUrl
	{
		[Register("getDatabaseUrl", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDatabaseUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string GaTrackingId
	{
		[Register("getGaTrackingId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getGaTrackingId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string GcmSenderId
	{
		[Register("getGcmSenderId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getGcmSenderId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string ProjectId
	{
		[Register("getProjectId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProjectId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string StorageBucket
	{
		[Register("getStorageBucket", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getStorageBucket.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal FirebaseOptions(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("fromResource", "(Landroid/content/Context;)Lcom/google/firebase/FirebaseOptions;", "")]
	public unsafe static FirebaseOptions FromResource(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FirebaseOptions>(_members.StaticMethods.InvokeObjectMethod("fromResource.(Landroid/content/Context;)Lcom/google/firebase/FirebaseOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
[Register("com/google/firebase/FirebaseAppLifecycleListener", "", "Firebase.IFirebaseAppLifecycleListenerInvoker")]
public interface IFirebaseAppLifecycleListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDeleted", "(Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)V", "GetOnDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_Handler:Firebase.IFirebaseAppLifecycleListenerInvoker, Xamarin.Firebase.Common")]
	void OnDeleted(string p0, FirebaseOptions p1);
}
[Register("com/google/firebase/FirebaseAppLifecycleListener", DoNotGenerateAcw = true)]
internal class IFirebaseAppLifecycleListenerInvoker : Java.Lang.Object, IFirebaseAppLifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/FirebaseAppLifecycleListener", typeof(IFirebaseAppLifecycleListenerInvoker));

	private IntPtr class_ref;

	private static Delegate cb_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_;

	private IntPtr id_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_;

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

	public static IFirebaseAppLifecycleListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFirebaseAppLifecycleListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.firebase.FirebaseAppLifecycleListener'.");
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

	public IFirebaseAppLifecycleListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_Handler()
	{
		if ((object)cb_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_ == null)
		{
			cb_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_));
		}
		return cb_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_;
	}

	private static void n_OnDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
	{
		IFirebaseAppLifecycleListener firebaseAppLifecycleListener = Java.Lang.Object.GetObject<IFirebaseAppLifecycleListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		FirebaseOptions p2 = Java.Lang.Object.GetObject<FirebaseOptions>(native_p1, JniHandleOwnership.DoNotTransfer);
		firebaseAppLifecycleListener.OnDeleted(p, p2);
	}

	public unsafe void OnDeleted(string p0, FirebaseOptions p1)
	{
		if (id_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_ == IntPtr.Zero)
		{
			id_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_ = JNIEnv.GetMethodID(class_ref, "onDeleted", "(Ljava/lang/String;Lcom/google/firebase/FirebaseOptions;)V");
		}
		IntPtr intPtr = JNIEnv.NewString(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(intPtr);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onDeleted_Ljava_lang_String_Lcom_google_firebase_FirebaseOptions_, ptr);
		JNIEnv.DeleteLocalRef(intPtr);
	}
}
public class FirebaseAppLifecycleEventArgs : EventArgs
{
	private string p0;

	private FirebaseOptions p1;

	public FirebaseAppLifecycleEventArgs(string p0, FirebaseOptions p1)
	{
		this.p0 = p0;
		this.p1 = p1;
	}
}
[Register("mono/com/google/firebase/FirebaseAppLifecycleListenerImplementor")]
internal sealed class IFirebaseAppLifecycleListenerImplementor : Java.Lang.Object, IFirebaseAppLifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
	private object sender;

	public EventHandler<FirebaseAppLifecycleEventArgs> Handler;

	public IFirebaseAppLifecycleListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/google/firebase/FirebaseAppLifecycleListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnDeleted(string p0, FirebaseOptions p1)
	{
		Handler?.Invoke(sender, new FirebaseAppLifecycleEventArgs(p0, p1));
	}

	internal static bool __IsEmpty(IFirebaseAppLifecycleListenerImplementor value)
	{
		return value.Handler == null;
	}
}
