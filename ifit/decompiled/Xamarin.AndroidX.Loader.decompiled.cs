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
using AndroidX.Loader.Content;
using Java.IO;
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
[assembly: NamespaceMapping(Java = "androidx.loader.app", Managed = "AndroidX.Loader.App")]
[assembly: NamespaceMapping(Java = "androidx.loader.content", Managed = "AndroidX.Loader.Content")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.loader:loader'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Loader")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Loader")]
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
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPILL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
namespace AndroidX.Loader.Content
{
	[Register("androidx/loader/content/Loader", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "D" })]
	public class Loader : Java.Lang.Object
	{
		[Register("androidx/loader/content/Loader$OnLoadCanceledListener", "", "AndroidX.Loader.Content.Loader/IOnLoadCanceledListenerInvoker")]
		[JavaTypeParameters(new string[] { "D" })]
		public interface IOnLoadCanceledListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onLoadCanceled", "(Landroidx/loader/content/Loader;)V", "GetOnLoadCanceled_Landroidx_loader_content_Loader_Handler:AndroidX.Loader.Content.Loader/IOnLoadCanceledListenerInvoker, Xamarin.AndroidX.Loader")]
			void OnLoadCanceled(Loader loader);
		}

		[Register("androidx/loader/content/Loader$OnLoadCanceledListener", DoNotGenerateAcw = true)]
		internal class IOnLoadCanceledListenerInvoker : Java.Lang.Object, IOnLoadCanceledListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/content/Loader$OnLoadCanceledListener", typeof(IOnLoadCanceledListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onLoadCanceled_Landroidx_loader_content_Loader_;

			private IntPtr id_onLoadCanceled_Landroidx_loader_content_Loader_;

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

			public static IOnLoadCanceledListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnLoadCanceledListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.loader.content.Loader.OnLoadCanceledListener'.");
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

			public IOnLoadCanceledListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnLoadCanceled_Landroidx_loader_content_Loader_Handler()
			{
				if ((object)cb_onLoadCanceled_Landroidx_loader_content_Loader_ == null)
				{
					cb_onLoadCanceled_Landroidx_loader_content_Loader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLoadCanceled_Landroidx_loader_content_Loader_));
				}
				return cb_onLoadCanceled_Landroidx_loader_content_Loader_;
			}

			private static void n_OnLoadCanceled_Landroidx_loader_content_Loader_(IntPtr jnienv, IntPtr native__this, IntPtr native_loader)
			{
				IOnLoadCanceledListener onLoadCanceledListener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Loader loader = Java.Lang.Object.GetObject<Loader>(native_loader, JniHandleOwnership.DoNotTransfer);
				onLoadCanceledListener.OnLoadCanceled(loader);
			}

			public unsafe void OnLoadCanceled(Loader loader)
			{
				if (id_onLoadCanceled_Landroidx_loader_content_Loader_ == IntPtr.Zero)
				{
					id_onLoadCanceled_Landroidx_loader_content_Loader_ = JNIEnv.GetMethodID(class_ref, "onLoadCanceled", "(Landroidx/loader/content/Loader;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(loader?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onLoadCanceled_Landroidx_loader_content_Loader_, ptr);
			}
		}

		[Register("androidx/loader/content/Loader$OnLoadCompleteListener", "", "AndroidX.Loader.Content.Loader/IOnLoadCompleteListenerInvoker")]
		[JavaTypeParameters(new string[] { "D" })]
		public interface IOnLoadCompleteListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onLoadComplete", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", "GetOnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler:AndroidX.Loader.Content.Loader/IOnLoadCompleteListenerInvoker, Xamarin.AndroidX.Loader")]
			void OnLoadComplete(Loader loader, Java.Lang.Object data);
		}

		[Register("androidx/loader/content/Loader$OnLoadCompleteListener", DoNotGenerateAcw = true)]
		internal class IOnLoadCompleteListenerInvoker : Java.Lang.Object, IOnLoadCompleteListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/content/Loader$OnLoadCompleteListener", typeof(IOnLoadCompleteListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_;

			private IntPtr id_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_;

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

			public static IOnLoadCompleteListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnLoadCompleteListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.loader.content.Loader.OnLoadCompleteListener'.");
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

			public IOnLoadCompleteListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler()
			{
				if ((object)cb_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_ == null)
				{
					cb_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_));
				}
				return cb_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_;
			}

			private static void n_OnLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_loader, IntPtr native_data)
			{
				IOnLoadCompleteListener onLoadCompleteListener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Loader loader = Java.Lang.Object.GetObject<Loader>(native_loader, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
				onLoadCompleteListener.OnLoadComplete(loader, data);
			}

			public unsafe void OnLoadComplete(Loader loader, Java.Lang.Object data)
			{
				if (id_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onLoadComplete", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(data);
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(loader?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_onLoadComplete_Landroidx_loader_content_Loader_Ljava_lang_Object_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/content/Loader", typeof(Loader));

		private static Delegate cb_getContext;

		private static Delegate cb_getId;

		private static Delegate cb_isAbandoned;

		private static Delegate cb_isReset;

		private static Delegate cb_isStarted;

		private static Delegate cb_abandon;

		private static Delegate cb_cancelLoad;

		private static Delegate cb_commitContentChanged;

		private static Delegate cb_dataToString_Ljava_lang_Object_;

		private static Delegate cb_deliverCancellation;

		private static Delegate cb_deliverResult_Ljava_lang_Object_;

		private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

		private static Delegate cb_forceLoad;

		private static Delegate cb_onAbandon;

		private static Delegate cb_onCancelLoad;

		private static Delegate cb_onContentChanged;

		private static Delegate cb_onForceLoad;

		private static Delegate cb_onReset;

		private static Delegate cb_onStartLoading;

		private static Delegate cb_onStopLoading;

		private static Delegate cb_registerListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_;

		private static Delegate cb_registerOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_;

		private static Delegate cb_reset;

		private static Delegate cb_rollbackContentChanged;

		private static Delegate cb_stopLoading;

		private static Delegate cb_takeContentChanged;

		private static Delegate cb_unregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_;

		private static Delegate cb_unregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_;

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

		public unsafe virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Id
		{
			[Register("getId", "()I", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
			}
		}

		public unsafe virtual bool IsAbandoned
		{
			[Register("isAbandoned", "()Z", "GetIsAbandonedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAbandoned.()Z", this, null);
			}
		}

		public unsafe virtual bool IsReset
		{
			[Register("isReset", "()Z", "GetIsResetHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isReset.()Z", this, null);
			}
		}

		public unsafe virtual bool IsStarted
		{
			[Register("isStarted", "()Z", "GetIsStartedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStarted.()Z", this, null);
			}
		}

		protected Loader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Loader(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetContextHandler()
		{
			if ((object)cb_getContext == null)
			{
				cb_getContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContext));
			}
			return cb_getContext;
		}

		private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
		}

		private static Delegate GetGetIdHandler()
		{
			if ((object)cb_getId == null)
			{
				cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetId));
			}
			return cb_getId;
		}

		private static int n_GetId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
		}

		private static Delegate GetIsAbandonedHandler()
		{
			if ((object)cb_isAbandoned == null)
			{
				cb_isAbandoned = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAbandoned));
			}
			return cb_isAbandoned;
		}

		private static bool n_IsAbandoned(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAbandoned;
		}

		private static Delegate GetIsResetHandler()
		{
			if ((object)cb_isReset == null)
			{
				cb_isReset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsReset));
			}
			return cb_isReset;
		}

		private static bool n_IsReset(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReset;
		}

		private static Delegate GetIsStartedHandler()
		{
			if ((object)cb_isStarted == null)
			{
				cb_isStarted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStarted));
			}
			return cb_isStarted;
		}

		private static bool n_IsStarted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStarted;
		}

		private static Delegate GetAbandonHandler()
		{
			if ((object)cb_abandon == null)
			{
				cb_abandon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Abandon));
			}
			return cb_abandon;
		}

		private static void n_Abandon(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Abandon();
		}

		[Register("abandon", "()V", "GetAbandonHandler")]
		public unsafe virtual void Abandon()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("abandon.()V", this, null);
		}

		private static Delegate GetCancelLoadHandler()
		{
			if ((object)cb_cancelLoad == null)
			{
				cb_cancelLoad = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CancelLoad));
			}
			return cb_cancelLoad;
		}

		private static bool n_CancelLoad(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelLoad();
		}

		[Register("cancelLoad", "()Z", "GetCancelLoadHandler")]
		public unsafe virtual bool CancelLoad()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("cancelLoad.()Z", this, null);
		}

		private static Delegate GetCommitContentChangedHandler()
		{
			if ((object)cb_commitContentChanged == null)
			{
				cb_commitContentChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CommitContentChanged));
			}
			return cb_commitContentChanged;
		}

		private static void n_CommitContentChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitContentChanged();
		}

		[Register("commitContentChanged", "()V", "GetCommitContentChangedHandler")]
		public unsafe virtual void CommitContentChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("commitContentChanged.()V", this, null);
		}

		private static Delegate GetDataToString_Ljava_lang_Object_Handler()
		{
			if ((object)cb_dataToString_Ljava_lang_Object_ == null)
			{
				cb_dataToString_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_DataToString_Ljava_lang_Object_));
			}
			return cb_dataToString_Ljava_lang_Object_;
		}

		private static IntPtr n_DataToString_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_data)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(loader.DataToString(data));
		}

		[Register("dataToString", "(Ljava/lang/Object;)Ljava/lang/String;", "GetDataToString_Ljava_lang_Object_Handler")]
		public unsafe virtual string DataToString(Java.Lang.Object data)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("dataToString.(Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetDeliverCancellationHandler()
		{
			if ((object)cb_deliverCancellation == null)
			{
				cb_deliverCancellation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DeliverCancellation));
			}
			return cb_deliverCancellation;
		}

		private static void n_DeliverCancellation(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeliverCancellation();
		}

		[Register("deliverCancellation", "()V", "GetDeliverCancellationHandler")]
		public unsafe virtual void DeliverCancellation()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("deliverCancellation.()V", this, null);
		}

		private static Delegate GetDeliverResult_Ljava_lang_Object_Handler()
		{
			if ((object)cb_deliverResult_Ljava_lang_Object_ == null)
			{
				cb_deliverResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DeliverResult_Ljava_lang_Object_));
			}
			return cb_deliverResult_Ljava_lang_Object_;
		}

		private static void n_DeliverResult_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_data)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
			loader.DeliverResult(data);
		}

		[Register("deliverResult", "(Ljava/lang/Object;)V", "GetDeliverResult_Ljava_lang_Object_Handler")]
		public unsafe virtual void DeliverResult(Java.Lang.Object data)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("deliverResult.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
			{
				cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
			}
			return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
		}

		private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_prefix, IntPtr native_fd, IntPtr native_writer, IntPtr native_args)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			FileDescriptor fd = Java.Lang.Object.GetObject<FileDescriptor>(native_fd, JniHandleOwnership.DoNotTransfer);
			PrintWriter writer = Java.Lang.Object.GetObject<PrintWriter>(native_writer, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(string));
			loader.Dump(prefix, fd, writer, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_args);
			}
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public unsafe virtual void Dump(string prefix, FileDescriptor fd, PrintWriter writer, string[] args)
		{
			IntPtr intPtr = JNIEnv.NewString(prefix);
			IntPtr intPtr2 = JNIEnv.NewArray(args);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(fd?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (args != null)
				{
					JNIEnv.CopyArray(intPtr2, args);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(fd);
				GC.KeepAlive(writer);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetForceLoadHandler()
		{
			if ((object)cb_forceLoad == null)
			{
				cb_forceLoad = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ForceLoad));
			}
			return cb_forceLoad;
		}

		private static void n_ForceLoad(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForceLoad();
		}

		[Register("forceLoad", "()V", "GetForceLoadHandler")]
		public unsafe virtual void ForceLoad()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("forceLoad.()V", this, null);
		}

		private static Delegate GetOnAbandonHandler()
		{
			if ((object)cb_onAbandon == null)
			{
				cb_onAbandon = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnAbandon));
			}
			return cb_onAbandon;
		}

		private static void n_OnAbandon(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAbandon();
		}

		[Register("onAbandon", "()V", "GetOnAbandonHandler")]
		protected unsafe virtual void OnAbandon()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAbandon.()V", this, null);
		}

		private static Delegate GetOnCancelLoadHandler()
		{
			if ((object)cb_onCancelLoad == null)
			{
				cb_onCancelLoad = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_OnCancelLoad));
			}
			return cb_onCancelLoad;
		}

		private static bool n_OnCancelLoad(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancelLoad();
		}

		[Register("onCancelLoad", "()Z", "GetOnCancelLoadHandler")]
		protected unsafe virtual bool OnCancelLoad()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onCancelLoad.()Z", this, null);
		}

		private static Delegate GetOnContentChangedHandler()
		{
			if ((object)cb_onContentChanged == null)
			{
				cb_onContentChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnContentChanged));
			}
			return cb_onContentChanged;
		}

		private static void n_OnContentChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
		}

		[Register("onContentChanged", "()V", "GetOnContentChangedHandler")]
		public unsafe virtual void OnContentChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
		}

		private static Delegate GetOnForceLoadHandler()
		{
			if ((object)cb_onForceLoad == null)
			{
				cb_onForceLoad = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnForceLoad));
			}
			return cb_onForceLoad;
		}

		private static void n_OnForceLoad(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnForceLoad();
		}

		[Register("onForceLoad", "()V", "GetOnForceLoadHandler")]
		protected unsafe virtual void OnForceLoad()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onForceLoad.()V", this, null);
		}

		private static Delegate GetOnResetHandler()
		{
			if ((object)cb_onReset == null)
			{
				cb_onReset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnReset));
			}
			return cb_onReset;
		}

		private static void n_OnReset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnReset();
		}

		[Register("onReset", "()V", "GetOnResetHandler")]
		protected unsafe virtual void OnReset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onReset.()V", this, null);
		}

		private static Delegate GetOnStartLoadingHandler()
		{
			if ((object)cb_onStartLoading == null)
			{
				cb_onStartLoading = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStartLoading));
			}
			return cb_onStartLoading;
		}

		private static void n_OnStartLoading(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStartLoading();
		}

		[Register("onStartLoading", "()V", "GetOnStartLoadingHandler")]
		protected unsafe virtual void OnStartLoading()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStartLoading.()V", this, null);
		}

		private static Delegate GetOnStopLoadingHandler()
		{
			if ((object)cb_onStopLoading == null)
			{
				cb_onStopLoading = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStopLoading));
			}
			return cb_onStopLoading;
		}

		private static void n_OnStopLoading(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStopLoading();
		}

		[Register("onStopLoading", "()V", "GetOnStopLoadingHandler")]
		protected unsafe virtual void OnStopLoading()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopLoading.()V", this, null);
		}

		private static Delegate GetRegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_Handler()
		{
			if ((object)cb_registerListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_ == null)
			{
				cb_registerListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_RegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_));
			}
			return cb_registerListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_;
		}

		private static void n_RegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_(IntPtr jnienv, IntPtr native__this, int id, IntPtr native_listener)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCompleteListener listener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.RegisterListener(id, listener);
		}

		[Register("registerListener", "(ILandroidx/loader/content/Loader$OnLoadCompleteListener;)V", "GetRegisterListener_ILandroidx_loader_content_Loader_OnLoadCompleteListener_Handler")]
		public unsafe virtual void RegisterListener(int id, IOnLoadCompleteListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerListener.(ILandroidx/loader/content/Loader$OnLoadCompleteListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetRegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler()
		{
			if ((object)cb_registerOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_ == null)
			{
				cb_registerOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_));
			}
			return cb_registerOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_;
		}

		private static void n_RegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCanceledListener listener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.RegisterOnLoadCanceledListener(listener);
		}

		[Register("registerOnLoadCanceledListener", "(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", "GetRegisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler")]
		public unsafe virtual void RegisterOnLoadCanceledListener(IOnLoadCanceledListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerOnLoadCanceledListener.(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetRollbackContentChangedHandler()
		{
			if ((object)cb_rollbackContentChanged == null)
			{
				cb_rollbackContentChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RollbackContentChanged));
			}
			return cb_rollbackContentChanged;
		}

		private static void n_RollbackContentChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RollbackContentChanged();
		}

		[Register("rollbackContentChanged", "()V", "GetRollbackContentChangedHandler")]
		public unsafe virtual void RollbackContentChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("rollbackContentChanged.()V", this, null);
		}

		[Register("startLoading", "()V", "")]
		public unsafe void StartLoading()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("startLoading.()V", this, null);
		}

		private static Delegate GetStopLoadingHandler()
		{
			if ((object)cb_stopLoading == null)
			{
				cb_stopLoading = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopLoading));
			}
			return cb_stopLoading;
		}

		private static void n_StopLoading(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopLoading();
		}

		[Register("stopLoading", "()V", "GetStopLoadingHandler")]
		public unsafe virtual void StopLoading()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("stopLoading.()V", this, null);
		}

		private static Delegate GetTakeContentChangedHandler()
		{
			if ((object)cb_takeContentChanged == null)
			{
				cb_takeContentChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_TakeContentChanged));
			}
			return cb_takeContentChanged;
		}

		private static bool n_TakeContentChanged(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TakeContentChanged();
		}

		[Register("takeContentChanged", "()Z", "GetTakeContentChangedHandler")]
		public unsafe virtual bool TakeContentChanged()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("takeContentChanged.()Z", this, null);
		}

		private static Delegate GetUnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_Handler()
		{
			if ((object)cb_unregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_ == null)
			{
				cb_unregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_));
			}
			return cb_unregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_;
		}

		private static void n_UnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCompleteListener listener = Java.Lang.Object.GetObject<IOnLoadCompleteListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.UnregisterListener(listener);
		}

		[Register("unregisterListener", "(Landroidx/loader/content/Loader$OnLoadCompleteListener;)V", "GetUnregisterListener_Landroidx_loader_content_Loader_OnLoadCompleteListener_Handler")]
		public unsafe virtual void UnregisterListener(IOnLoadCompleteListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterListener.(Landroidx/loader/content/Loader$OnLoadCompleteListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetUnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler()
		{
			if ((object)cb_unregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_ == null)
			{
				cb_unregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_));
			}
			return cb_unregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_;
		}

		private static void n_UnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			Loader loader = Java.Lang.Object.GetObject<Loader>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLoadCanceledListener listener = Java.Lang.Object.GetObject<IOnLoadCanceledListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			loader.UnregisterOnLoadCanceledListener(listener);
		}

		[Register("unregisterOnLoadCanceledListener", "(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", "GetUnregisterOnLoadCanceledListener_Landroidx_loader_content_Loader_OnLoadCanceledListener_Handler")]
		public unsafe virtual void UnregisterOnLoadCanceledListener(IOnLoadCanceledListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterOnLoadCanceledListener.(Landroidx/loader/content/Loader$OnLoadCanceledListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}
	}
}
namespace AndroidX.Loader.App
{
	[Register("androidx/loader/app/LoaderManager", DoNotGenerateAcw = true)]
	public abstract class LoaderManager : Java.Lang.Object
	{
		[Register("androidx/loader/app/LoaderManager$LoaderCallbacks", "", "AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker")]
		[JavaTypeParameters(new string[] { "D" })]
		public interface ILoaderCallbacks : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCreateLoader", "(ILandroid/os/Bundle;)Landroidx/loader/content/Loader;", "GetOnCreateLoader_ILandroid_os_Bundle_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
			AndroidX.Loader.Content.Loader OnCreateLoader(int p0, Bundle p1);

			[Register("onLoadFinished", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V", "GetOnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
			void OnLoadFinished(AndroidX.Loader.Content.Loader p0, Java.Lang.Object p1);

			[Register("onLoaderReset", "(Landroidx/loader/content/Loader;)V", "GetOnLoaderReset_Landroidx_loader_content_Loader_Handler:AndroidX.Loader.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.AndroidX.Loader")]
			void OnLoaderReset(AndroidX.Loader.Content.Loader p0);
		}

		[Register("androidx/loader/app/LoaderManager$LoaderCallbacks", DoNotGenerateAcw = true)]
		internal class ILoaderCallbacksInvoker : Java.Lang.Object, ILoaderCallbacks, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/app/LoaderManager$LoaderCallbacks", typeof(ILoaderCallbacksInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCreateLoader_ILandroid_os_Bundle_;

			private IntPtr id_onCreateLoader_ILandroid_os_Bundle_;

			private static Delegate cb_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_;

			private IntPtr id_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_;

			private static Delegate cb_onLoaderReset_Landroidx_loader_content_Loader_;

			private IntPtr id_onLoaderReset_Landroidx_loader_content_Loader_;

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

			public static ILoaderCallbacks GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ILoaderCallbacks>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.loader.app.LoaderManager.LoaderCallbacks'.");
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

			public ILoaderCallbacksInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCreateLoader_ILandroid_os_Bundle_Handler()
			{
				if ((object)cb_onCreateLoader_ILandroid_os_Bundle_ == null)
				{
					cb_onCreateLoader_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_OnCreateLoader_ILandroid_os_Bundle_));
				}
				return cb_onCreateLoader_ILandroid_os_Bundle_;
			}

			private static IntPtr n_OnCreateLoader_ILandroid_os_Bundle_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
			{
				ILoaderCallbacks loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(loaderCallbacks.OnCreateLoader(p0, p1));
			}

			public unsafe AndroidX.Loader.Content.Loader OnCreateLoader(int p0, Bundle p1)
			{
				if (id_onCreateLoader_ILandroid_os_Bundle_ == IntPtr.Zero)
				{
					id_onCreateLoader_ILandroid_os_Bundle_ = JNIEnv.GetMethodID(class_ref, "onCreateLoader", "(ILandroid/os/Bundle;)Landroidx/loader/content/Loader;");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(JNIEnv.CallObjectMethod(base.Handle, id_onCreateLoader_ILandroid_os_Bundle_, ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetOnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_Handler()
			{
				if ((object)cb_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_ == null)
				{
					cb_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_));
				}
				return cb_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_;
			}

			private static void n_OnLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				ILoaderCallbacks loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AndroidX.Loader.Content.Loader p = Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
				loaderCallbacks.OnLoadFinished(p, p2);
			}

			public unsafe void OnLoadFinished(AndroidX.Loader.Content.Loader p0, Java.Lang.Object p1)
			{
				if (id_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onLoadFinished", "(Landroidx/loader/content/Loader;Ljava/lang/Object;)V");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_onLoadFinished_Landroidx_loader_content_Loader_Ljava_lang_Object_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}

			private static Delegate GetOnLoaderReset_Landroidx_loader_content_Loader_Handler()
			{
				if ((object)cb_onLoaderReset_Landroidx_loader_content_Loader_ == null)
				{
					cb_onLoaderReset_Landroidx_loader_content_Loader_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLoaderReset_Landroidx_loader_content_Loader_));
				}
				return cb_onLoaderReset_Landroidx_loader_content_Loader_;
			}

			private static void n_OnLoaderReset_Landroidx_loader_content_Loader_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				ILoaderCallbacks loaderCallbacks = Java.Lang.Object.GetObject<ILoaderCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AndroidX.Loader.Content.Loader p = Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(native_p0, JniHandleOwnership.DoNotTransfer);
				loaderCallbacks.OnLoaderReset(p);
			}

			public unsafe void OnLoaderReset(AndroidX.Loader.Content.Loader p0)
			{
				if (id_onLoaderReset_Landroidx_loader_content_Loader_ == IntPtr.Zero)
				{
					id_onLoaderReset_Landroidx_loader_content_Loader_ = JNIEnv.GetMethodID(class_ref, "onLoaderReset", "(Landroidx/loader/content/Loader;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onLoaderReset_Landroidx_loader_content_Loader_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/app/LoaderManager", typeof(LoaderManager));

		private static Delegate cb_hasRunningLoaders;

		private static Delegate cb_destroyLoader_I;

		private static Delegate cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;

		private static Delegate cb_getLoader_I;

		private static Delegate cb_initLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_;

		private static Delegate cb_markForRedelivery;

		private static Delegate cb_restartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_;

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

		public unsafe virtual bool HasRunningLoaders
		{
			[Register("hasRunningLoaders", "()Z", "GetHasRunningLoadersHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasRunningLoaders.()Z", this, null);
			}
		}

		protected LoaderManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LoaderManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetHasRunningLoadersHandler()
		{
			if ((object)cb_hasRunningLoaders == null)
			{
				cb_hasRunningLoaders = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasRunningLoaders));
			}
			return cb_hasRunningLoaders;
		}

		private static bool n_HasRunningLoaders(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasRunningLoaders;
		}

		private static Delegate GetDestroyLoader_IHandler()
		{
			if ((object)cb_destroyLoader_I == null)
			{
				cb_destroyLoader_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_DestroyLoader_I));
			}
			return cb_destroyLoader_I;
		}

		private static void n_DestroyLoader_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DestroyLoader(p0);
		}

		[Register("destroyLoader", "(I)V", "GetDestroyLoader_IHandler")]
		public abstract void DestroyLoader(int p0);

		private static Delegate GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler()
		{
			if ((object)cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ == null)
			{
				cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_V(n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_));
			}
			return cb_dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_;
		}

		private static void n_Dump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			LoaderManager loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			FileDescriptor p2 = Java.Lang.Object.GetObject<FileDescriptor>(native_p1, JniHandleOwnership.DoNotTransfer);
			PrintWriter p3 = Java.Lang.Object.GetObject<PrintWriter>(native_p2, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(string));
			loaderManager.Dump(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
			}
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public abstract void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3);

		[Register("enableDebugLogging", "(Z)V", "")]
		public unsafe static void EnableDebugLogging(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			_members.StaticMethods.InvokeVoidMethod("enableDebugLogging.(Z)V", ptr);
		}

		[Register("getInstance", "(Landroidx/lifecycle/LifecycleOwner;)Landroidx/loader/app/LoaderManager;", "")]
		[JavaTypeParameters(new string[] { "T extends androidx.lifecycle.LifecycleOwner & androidx.lifecycle.ViewModelStoreOwner" })]
		public unsafe static LoaderManager GetInstance(Java.Lang.Object owner)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(owner);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LoaderManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroidx/lifecycle/LifecycleOwner;)Landroidx/loader/app/LoaderManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(owner);
			}
		}

		private static Delegate GetGetLoader_IHandler()
		{
			if ((object)cb_getLoader_I == null)
			{
				cb_getLoader_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetLoader_I));
			}
			return cb_getLoader_I;
		}

		private static IntPtr n_GetLoader_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLoader(p0));
		}

		[Register("getLoader", "(I)Landroidx/loader/content/Loader;", "GetGetLoader_IHandler")]
		[JavaTypeParameters(new string[] { "D" })]
		public abstract AndroidX.Loader.Content.Loader GetLoader(int p0);

		private static Delegate GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler()
		{
			if ((object)cb_initLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_ == null)
			{
				cb_initLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_InitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_));
			}
			return cb_initLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_;
		}

		private static IntPtr n_InitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			LoaderManager loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
			ILoaderCallbacks p2 = Java.Lang.Object.GetObject<ILoaderCallbacks>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loaderManager.InitLoader(p0, p1, p2));
		}

		[Register("initLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
		[JavaTypeParameters(new string[] { "D" })]
		public abstract AndroidX.Loader.Content.Loader InitLoader(int p0, Bundle p1, ILoaderCallbacks p2);

		private static Delegate GetMarkForRedeliveryHandler()
		{
			if ((object)cb_markForRedelivery == null)
			{
				cb_markForRedelivery = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_MarkForRedelivery));
			}
			return cb_markForRedelivery;
		}

		private static void n_MarkForRedelivery(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MarkForRedelivery();
		}

		[Register("markForRedelivery", "()V", "GetMarkForRedeliveryHandler")]
		public abstract void MarkForRedelivery();

		private static Delegate GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler()
		{
			if ((object)cb_restartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_ == null)
			{
				cb_restartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_RestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_));
			}
			return cb_restartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_;
		}

		private static IntPtr n_RestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			LoaderManager loaderManager = Java.Lang.Object.GetObject<LoaderManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle p1 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
			ILoaderCallbacks p2 = Java.Lang.Object.GetObject<ILoaderCallbacks>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(loaderManager.RestartLoader(p0, p1, p2));
		}

		[Register("restartLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
		[JavaTypeParameters(new string[] { "D" })]
		public abstract AndroidX.Loader.Content.Loader RestartLoader(int p0, Bundle p1, ILoaderCallbacks p2);
	}
	[Register("androidx/loader/app/LoaderManager", DoNotGenerateAcw = true)]
	internal class LoaderManagerInvoker : LoaderManager
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/app/LoaderManager", typeof(LoaderManagerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LoaderManagerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("destroyLoader", "(I)V", "GetDestroyLoader_IHandler")]
		public unsafe override void DestroyLoader(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeAbstractVoidMethod("destroyLoader.(I)V", this, ptr);
		}

		[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
		public unsafe override void Dump(string p0, FileDescriptor p1, PrintWriter p2, string[] p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeAbstractVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p3 != null)
				{
					JNIEnv.CopyArray(intPtr2, p3);
					JNIEnv.DeleteLocalRef(intPtr2);
				}
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register("getLoader", "(I)Landroidx/loader/content/Loader;", "GetGetLoader_IHandler")]
		[JavaTypeParameters(new string[] { "D" })]
		public unsafe override AndroidX.Loader.Content.Loader GetLoader(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLoader.(I)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("initLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
		[JavaTypeParameters(new string[] { "D" })]
		public unsafe override AndroidX.Loader.Content.Loader InitLoader(int p0, Bundle p1, ILoaderCallbacks p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("initLoader.(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("markForRedelivery", "()V", "GetMarkForRedeliveryHandler")]
		public unsafe override void MarkForRedelivery()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("markForRedelivery.()V", this, null);
		}

		[Register("restartLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
		[JavaTypeParameters(new string[] { "D" })]
		public unsafe override AndroidX.Loader.Content.Loader RestartLoader(int p0, Bundle p1, ILoaderCallbacks p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("restartLoader.(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}
	}
}
