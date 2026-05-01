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
[assembly: NamespaceMapping(Java = "androidx.versionedparcelable", Managed = "AndroidX.VersionedParcelable")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - versionedparcelable")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.VersionedParcelable")]
[assembly: AssemblyTitle("Xamarin.AndroidX.VersionedParcelable")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace AndroidX.VersionedParcelable;

[Register("androidx/versionedparcelable/CustomVersionedParcelable", DoNotGenerateAcw = true)]
public abstract class CustomVersionedParcelable : Java.Lang.Object, IVersionedParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/versionedparcelable/CustomVersionedParcelable", typeof(CustomVersionedParcelable));

	private static Delegate cb_onPostParceling;

	private static Delegate cb_onPreParceling_Z;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected CustomVersionedParcelable(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CustomVersionedParcelable()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetOnPostParcelingHandler()
	{
		if ((object)cb_onPostParceling == null)
		{
			cb_onPostParceling = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnPostParceling));
		}
		return cb_onPostParceling;
	}

	private static void n_OnPostParceling(IntPtr jnienv, IntPtr native__this)
	{
		Java.Lang.Object.GetObject<CustomVersionedParcelable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPostParceling();
	}

	[Register("onPostParceling", "()V", "GetOnPostParcelingHandler")]
	public unsafe virtual void OnPostParceling()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPostParceling.()V", this, null);
	}

	private static Delegate GetOnPreParceling_ZHandler()
	{
		if ((object)cb_onPreParceling_Z == null)
		{
			cb_onPreParceling_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_OnPreParceling_Z));
		}
		return cb_onPreParceling_Z;
	}

	private static void n_OnPreParceling_Z(IntPtr jnienv, IntPtr native__this, bool isStream)
	{
		Java.Lang.Object.GetObject<CustomVersionedParcelable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPreParceling(isStream);
	}

	[Register("onPreParceling", "(Z)V", "GetOnPreParceling_ZHandler")]
	public unsafe virtual void OnPreParceling(bool isStream)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isStream);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPreParceling.(Z)V", this, ptr);
	}
}
[Register("androidx/versionedparcelable/CustomVersionedParcelable", DoNotGenerateAcw = true)]
internal class CustomVersionedParcelableInvoker : CustomVersionedParcelable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/versionedparcelable/CustomVersionedParcelable", typeof(CustomVersionedParcelableInvoker));

	public override JniPeerMembers JniPeerMembers => _members;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public CustomVersionedParcelableInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
[Register("androidx/versionedparcelable/VersionedParcelable", "", "AndroidX.VersionedParcelable.IVersionedParcelableInvoker")]
public interface IVersionedParcelable : IJavaObject, IDisposable, IJavaPeerable
{
}
[Register("androidx/versionedparcelable/VersionedParcelable", DoNotGenerateAcw = true)]
internal class IVersionedParcelableInvoker : Java.Lang.Object, IVersionedParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/versionedparcelable/VersionedParcelable", typeof(IVersionedParcelableInvoker));

	private IntPtr class_ref;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IVersionedParcelable GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IVersionedParcelable>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.versionedparcelable.VersionedParcelable"));
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

	public IVersionedParcelableInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}
}
