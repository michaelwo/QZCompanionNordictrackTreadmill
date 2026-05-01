using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Animation;
using Android.Runtime;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "791ebe2cb9b9b044bb1d30e9bd4c6097326f4bbe")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20230120.4")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "1/20/2023 8:31:40 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.interpolator.view.animation", Managed = "AndroidX.Interpolator.View.Animation")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.interpolator:interpolator'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Interpolator")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Interpolator")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PPF_F(IntPtr jnienv, IntPtr klass, float p0);
namespace AndroidX.Interpolator.View.Animation;

[Register("androidx/interpolator/view/animation/FastOutSlowInInterpolator", DoNotGenerateAcw = true)]
public class FastOutSlowInInterpolator : LookupTableInterpolator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/interpolator/view/animation/FastOutSlowInInterpolator", typeof(FastOutSlowInInterpolator));

	private static Delegate cb_getInterpolation_F;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FastOutSlowInInterpolator(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FastOutSlowInInterpolator()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetInterpolation_FHandler()
	{
		if ((object)cb_getInterpolation_F == null)
		{
			cb_getInterpolation_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_GetInterpolation_F));
		}
		return cb_getInterpolation_F;
	}

	private static float n_GetInterpolation_F(IntPtr jnienv, IntPtr native__this, float input)
	{
		return Java.Lang.Object.GetObject<FastOutSlowInInterpolator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInterpolation(input);
	}

	[Register("getInterpolation", "(F)F", "GetGetInterpolation_FHandler")]
	public unsafe override float GetInterpolation(float input)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(input);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getInterpolation.(F)F", this, ptr);
	}
}
[Register("androidx/interpolator/view/animation/LookupTableInterpolator", DoNotGenerateAcw = true)]
public abstract class LookupTableInterpolator : Java.Lang.Object, IInterpolator, ITimeInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/interpolator/view/animation/LookupTableInterpolator", typeof(LookupTableInterpolator));

	private static Delegate cb_getInterpolation_F;

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

	protected LookupTableInterpolator(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "([F)V", "")]
	protected unsafe LookupTableInterpolator(float[] values)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		IntPtr intPtr = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("([F)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("([F)V", this, ptr);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(intPtr, values);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetGetInterpolation_FHandler()
	{
		if ((object)cb_getInterpolation_F == null)
		{
			cb_getInterpolation_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_F(n_GetInterpolation_F));
		}
		return cb_getInterpolation_F;
	}

	private static float n_GetInterpolation_F(IntPtr jnienv, IntPtr native__this, float input)
	{
		return Java.Lang.Object.GetObject<LookupTableInterpolator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInterpolation(input);
	}

	[Register("getInterpolation", "(F)F", "GetGetInterpolation_FHandler")]
	public unsafe virtual float GetInterpolation(float input)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(input);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getInterpolation.(F)F", this, ptr);
	}
}
[Register("androidx/interpolator/view/animation/LookupTableInterpolator", DoNotGenerateAcw = true)]
internal class LookupTableInterpolatorInvoker : LookupTableInterpolator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/interpolator/view/animation/LookupTableInterpolator", typeof(LookupTableInterpolatorInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public LookupTableInterpolatorInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
