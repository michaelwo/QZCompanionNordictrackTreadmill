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
[assembly: NamespaceMapping(Java = "androidx.arch.core.internal", Managed = "AndroidX.Arch.Core.Internal")]
[assembly: NamespaceMapping(Java = "androidx.arch.core.util", Managed = "AndroidX.Arch.Core.Util")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - core-common")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Arch.Core.Common")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Arch.Core.Common")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
namespace AndroidX.Arch.Core.Util;

[Register("androidx/arch/core/util/Function", "", "AndroidX.Arch.Core.Util.IFunctionInvoker")]
[JavaTypeParameters(new string[] { "I", "O" })]
public interface IFunction : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("apply", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetApply_Ljava_lang_Object_Handler:AndroidX.Arch.Core.Util.IFunctionInvoker, Xamarin.AndroidX.Arch.Core.Common")]
	Java.Lang.Object Apply(Java.Lang.Object p0);
}
[Register("androidx/arch/core/util/Function", DoNotGenerateAcw = true)]
internal class IFunctionInvoker : Java.Lang.Object, IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/arch/core/util/Function", typeof(IFunctionInvoker));

	private IntPtr class_ref;

	private static Delegate cb_apply_Ljava_lang_Object_;

	private IntPtr id_apply_Ljava_lang_Object_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IFunction GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFunction>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.arch.core.util.Function"));
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

	public IFunctionInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetApply_Ljava_lang_Object_Handler()
	{
		if ((object)cb_apply_Ljava_lang_Object_ == null)
		{
			cb_apply_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Apply_Ljava_lang_Object_));
		}
		return cb_apply_Ljava_lang_Object_;
	}

	private static IntPtr n_Apply_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		IFunction function = Java.Lang.Object.GetObject<IFunction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(function.Apply(p));
	}

	public unsafe Java.Lang.Object Apply(Java.Lang.Object p0)
	{
		if (id_apply_Ljava_lang_Object_ == IntPtr.Zero)
		{
			id_apply_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "apply", "(Ljava/lang/Object;)Ljava/lang/Object;");
		}
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(intPtr);
		Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_apply_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(intPtr);
		return result;
	}
}
