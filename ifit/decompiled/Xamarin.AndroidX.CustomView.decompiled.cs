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
[assembly: NamespaceMapping(Java = "androidx.customview.view", Managed = "AndroidX.CustomView.View")]
[assembly: NamespaceMapping(Java = "androidx.customview.widget", Managed = "AndroidX.CustomView.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.customview:customview'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.CustomView")]
[assembly: AssemblyTitle("Xamarin.AndroidX.CustomView")]
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
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
namespace AndroidX.CustomView.Widget
{
	[Register("androidx/customview/widget/Openable", "", "AndroidX.CustomView.Widget.IOpenableInvoker")]
	public interface IOpenable : IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsOpen
		{
			[Register("isOpen", "()Z", "GetIsOpenHandler:AndroidX.CustomView.Widget.IOpenableInvoker, Xamarin.AndroidX.CustomView")]
			get;
		}

		[Register("close", "()V", "GetCloseHandler:AndroidX.CustomView.Widget.IOpenableInvoker, Xamarin.AndroidX.CustomView")]
		void Close();

		[Register("open", "()V", "GetOpenHandler:AndroidX.CustomView.Widget.IOpenableInvoker, Xamarin.AndroidX.CustomView")]
		void Open();
	}
	[Register("androidx/customview/widget/Openable", DoNotGenerateAcw = true)]
	internal class IOpenableInvoker : Java.Lang.Object, IOpenable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/customview/widget/Openable", typeof(IOpenableInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isOpen;

		private IntPtr id_isOpen;

		private static Delegate cb_close;

		private IntPtr id_close;

		private static Delegate cb_open;

		private IntPtr id_open;

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

		public bool IsOpen
		{
			get
			{
				if (id_isOpen == IntPtr.Zero)
				{
					id_isOpen = JNIEnv.GetMethodID(class_ref, "isOpen", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isOpen);
			}
		}

		public static IOpenable GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOpenable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.customview.widget.Openable'.");
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

		public IOpenableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsOpenHandler()
		{
			if ((object)cb_isOpen == null)
			{
				cb_isOpen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOpen));
			}
			return cb_isOpen;
		}

		private static bool n_IsOpen(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IOpenable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen;
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IOpenable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}

		private static Delegate GetOpenHandler()
		{
			if ((object)cb_open == null)
			{
				cb_open = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Open));
			}
			return cb_open;
		}

		private static void n_Open(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IOpenable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Open();
		}

		public void Open()
		{
			if (id_open == IntPtr.Zero)
			{
				id_open = JNIEnv.GetMethodID(class_ref, "open", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_open);
		}
	}
}
