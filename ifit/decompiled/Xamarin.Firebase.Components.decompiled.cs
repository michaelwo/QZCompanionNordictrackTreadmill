using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
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
[assembly: NamespaceMapping(Java = "com.google.firebase.dynamicloading", Managed = "Firebase.DynamicLoading")]
[assembly: NamespaceMapping(Java = "com.google.firebase.events", Managed = "Firebase.Events")]
[assembly: NamespaceMapping(Java = "com.google.firebase.inject", Managed = "Firebase.Inject")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\n        Xamarin.Android Bindings for Google Play Services - Xamarin.Firebase.Components 117.0.1 artifact=com.google.firebase:firebase-components artifact_versioned=com.google.firebase:firebase-components:17.0.1\n\n        N/A\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Firebase.Components")]
[assembly: AssemblyTitle("Xamarin.Firebase.Components")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
namespace Firebase.Inject;

[Register("com/google/firebase/inject/Provider", "", "Firebase.Inject.IProviderInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("get", "()Ljava/lang/Object;", "GetGetHandler:Firebase.Inject.IProviderInvoker, Xamarin.Firebase.Components")]
	Java.Lang.Object Get();
}
[Register("com/google/firebase/inject/Provider", DoNotGenerateAcw = true)]
internal class IProviderInvoker : Java.Lang.Object, IProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/firebase/inject/Provider", typeof(IProviderInvoker));

	private IntPtr class_ref;

	private static Delegate cb_get;

	private IntPtr id_get;

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

	public static IProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IProvider>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.firebase.inject.Provider'.");
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

	public IProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetHandler()
	{
		if ((object)cb_get == null)
		{
			cb_get = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Get));
		}
		return cb_get;
	}

	private static IntPtr n_Get(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get());
	}

	public Java.Lang.Object Get()
	{
		if (id_get == IntPtr.Zero)
		{
			id_get = JNIEnv.GetMethodID(class_ref, "get", "()Ljava/lang/Object;");
		}
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get), JniHandleOwnership.TransferLocalRef);
	}
}
