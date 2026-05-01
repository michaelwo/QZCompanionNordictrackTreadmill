using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Fragment.App;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Xamarin.Facebook.Internal;
using Xamarin.Facebook.Share.Model;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]
[assembly: NamespaceMapping(Java = "com.facebook.internal", Managed = "Xamarin.Facebook.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.share", Managed = "Xamarin.Facebook.Share")]
[assembly: NamespaceMapping(Java = "com.facebook.share.internal", Managed = "Xamarin.Facebook.Share.Internal")]
[assembly: NamespaceMapping(Java = "com.facebook.share.widget", Managed = "Xamarin.Facebook.Share.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for Facebook Android - Share")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Facebook.Share.Android")]
[assembly: AssemblyTitle("Xamarin.Facebook.Share.Android")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
namespace System.Runtime.Versioning
{
	[Conditional("NEVER")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
	internal sealed class SupportedOSPlatformAttribute : Attribute
	{
		public SupportedOSPlatformAttribute(string platformName)
		{
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_facebook_internal_mappings;

		private static string[] package_com_facebook_share_mappings;

		private static string[] package_com_facebook_share_internal_mappings;

		private static string[] package_com_facebook_share_widget_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[4] { "com/facebook/internal", "com/facebook/share", "com/facebook/share/internal", "com/facebook/share/widget" }, new Converter<string, Type>[4] { lookup_com_facebook_internal_package, lookup_com_facebook_share_package, lookup_com_facebook_share_internal_package, lookup_com_facebook_share_widget_package });
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_com_facebook_internal_package(string klass)
		{
			if (package_com_facebook_internal_mappings == null)
			{
				package_com_facebook_internal_mappings = new string[2] { "com/facebook/internal/CollectionMapper:Xamarin.Facebook.Internal.CollectionMapper", "com/facebook/internal/Mutable:Xamarin.Facebook.Internal.Mutable" };
			}
			return Lookup(package_com_facebook_internal_mappings, klass);
		}

		private static Type lookup_com_facebook_share_package(string klass)
		{
			if (package_com_facebook_share_mappings == null)
			{
				package_com_facebook_share_mappings = new string[3] { "com/facebook/share/BuildConfig:Xamarin.Facebook.Share.BuildConfig", "com/facebook/share/Share:Xamarin.Facebook.Share.Share", "com/facebook/share/ShareApi:Xamarin.Facebook.Share.ShareApi" };
			}
			return Lookup(package_com_facebook_share_mappings, klass);
		}

		private static Type lookup_com_facebook_share_internal_package(string klass)
		{
			if (package_com_facebook_share_internal_mappings == null)
			{
				package_com_facebook_share_internal_mappings = new string[5] { "com/facebook/share/internal/AppInviteDialogFeature:Xamarin.Facebook.Share.Internal.AppInviteDialogFeature", "com/facebook/share/internal/GameRequestValidation:Xamarin.Facebook.Share.Internal.GameRequestValidation", "com/facebook/share/internal/MessageDialogFeature:Xamarin.Facebook.Share.Internal.MessageDialogFeature", "com/facebook/share/internal/OpenGraphMessageDialogFeature:Xamarin.Facebook.Share.Internal.OpenGraphMessageDialogFeature", "com/facebook/share/internal/VideoUploader:Xamarin.Facebook.Share.Internal.VideoUploader" };
			}
			return Lookup(package_com_facebook_share_internal_mappings, klass);
		}

		private static Type lookup_com_facebook_share_widget_package(string klass)
		{
			if (package_com_facebook_share_widget_mappings == null)
			{
				package_com_facebook_share_widget_mappings = new string[6] { "com/facebook/share/widget/GameRequestDialog:Xamarin.Facebook.Share.Widget.GameRequestDialog", "com/facebook/share/widget/GameRequestDialog$Result:Xamarin.Facebook.Share.Widget.GameRequestDialog/Result", "com/facebook/share/widget/MessageDialog:Xamarin.Facebook.Share.Widget.MessageDialog", "com/facebook/share/widget/SendButton:Xamarin.Facebook.Share.Widget.SendButton", "com/facebook/share/widget/ShareButton:Xamarin.Facebook.Share.Widget.ShareButton", "com/facebook/share/widget/ShareButtonBase:Xamarin.Facebook.Share.Widget.ShareButtonBase" };
			}
			return Lookup(package_com_facebook_share_widget_mappings, klass);
		}
	}
}
namespace Xamarin.Facebook.Internal
{
	[Register("com/facebook/internal/CollectionMapper", DoNotGenerateAcw = true)]
	public class CollectionMapper : Java.Lang.Object
	{
		[Register("com/facebook/internal/CollectionMapper$Collection", "", "Xamarin.Facebook.Internal.CollectionMapper/ICollectionInvoker")]
		[JavaTypeParameters(new string[] { "T" })]
		public interface ICollection : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("get", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetGet_Ljava_lang_Object_Handler:Xamarin.Facebook.Internal.CollectionMapper/ICollectionInvoker, Xamarin.Facebook.Share.Android")]
			Java.Lang.Object Get(Java.Lang.Object key);

			[Register("keyIterator", "()Ljava/util/Iterator;", "GetKeyIteratorHandler:Xamarin.Facebook.Internal.CollectionMapper/ICollectionInvoker, Xamarin.Facebook.Share.Android")]
			IIterator KeyIterator();

			[Register("set", "(Ljava/lang/Object;Ljava/lang/Object;Lcom/facebook/internal/CollectionMapper$OnErrorListener;)V", "GetSet_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_Handler:Xamarin.Facebook.Internal.CollectionMapper/ICollectionInvoker, Xamarin.Facebook.Share.Android")]
			void Set(Java.Lang.Object key, Java.Lang.Object value, IOnErrorListener onErrorListener);
		}

		[Register("com/facebook/internal/CollectionMapper$Collection", DoNotGenerateAcw = true)]
		internal class ICollectionInvoker : Java.Lang.Object, ICollection, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper$Collection", typeof(ICollectionInvoker));

			private IntPtr class_ref;

			private static Delegate cb_get_Ljava_lang_Object_;

			private IntPtr id_get_Ljava_lang_Object_;

			private static Delegate cb_keyIterator;

			private IntPtr id_keyIterator;

			private static Delegate cb_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_;

			private IntPtr id_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_;

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

			public static ICollection GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICollection>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.CollectionMapper.Collection'.");
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

			public ICollectionInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGet_Ljava_lang_Object_Handler()
			{
				if ((object)cb_get_Ljava_lang_Object_ == null)
				{
					cb_get_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Ljava_lang_Object_));
				}
				return cb_get_Ljava_lang_Object_;
			}

			private static IntPtr n_Get_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
			{
				ICollection collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object key = Java.Lang.Object.GetObject<Java.Lang.Object>(native_key, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(collection.Get(key));
			}

			public unsafe Java.Lang.Object Get(Java.Lang.Object key)
			{
				if (id_get_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_get_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "get", "(Ljava/lang/Object;)Ljava/lang/Object;");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(key);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.DeleteLocalRef(intPtr);
				return result;
			}

			private static Delegate GetKeyIteratorHandler()
			{
				if ((object)cb_keyIterator == null)
				{
					cb_keyIterator = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_KeyIterator));
				}
				return cb_keyIterator;
			}

			private static IntPtr n_KeyIterator(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyIterator());
			}

			public IIterator KeyIterator()
			{
				if (id_keyIterator == IntPtr.Zero)
				{
					id_keyIterator = JNIEnv.GetMethodID(class_ref, "keyIterator", "()Ljava/util/Iterator;");
				}
				return Java.Lang.Object.GetObject<IIterator>(JNIEnv.CallObjectMethod(base.Handle, id_keyIterator), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSet_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_Handler()
			{
				if ((object)cb_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_ == null)
				{
					cb_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_));
				}
				return cb_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_;
			}

			private static void n_Set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_key, IntPtr native_value, IntPtr native_onErrorListener)
			{
				ICollection collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object key = Java.Lang.Object.GetObject<Java.Lang.Object>(native_key, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
				IOnErrorListener onErrorListener = Java.Lang.Object.GetObject<IOnErrorListener>(native_onErrorListener, JniHandleOwnership.DoNotTransfer);
				collection.Set(key, value, onErrorListener);
			}

			public unsafe void Set(Java.Lang.Object key, Java.Lang.Object value, IOnErrorListener onErrorListener)
			{
				if (id_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_ == IntPtr.Zero)
				{
					id_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_ = JNIEnv.GetMethodID(class_ref, "set", "(Ljava/lang/Object;Ljava/lang/Object;Lcom/facebook/internal/CollectionMapper$OnErrorListener;)V");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(key);
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(intPtr);
				ptr[1] = new JValue(value?.Handle ?? IntPtr.Zero);
				ptr[2] = new JValue((onErrorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onErrorListener).Handle);
				JNIEnv.CallVoidMethod(base.Handle, id_set_Ljava_lang_Object_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnErrorListener_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("com/facebook/internal/CollectionMapper$OnErrorListener", "", "Xamarin.Facebook.Internal.CollectionMapper/IOnErrorListenerInvoker")]
		public interface IOnErrorListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onError", "(Lcom/facebook/FacebookException;)V", "GetOnError_Lcom_facebook_FacebookException_Handler:Xamarin.Facebook.Internal.CollectionMapper/IOnErrorListenerInvoker, Xamarin.Facebook.Share.Android")]
			void OnError(FacebookException exception);
		}

		[Register("com/facebook/internal/CollectionMapper$OnErrorListener", DoNotGenerateAcw = true)]
		internal class IOnErrorListenerInvoker : Java.Lang.Object, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper$OnErrorListener", typeof(IOnErrorListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onError_Lcom_facebook_FacebookException_;

			private IntPtr id_onError_Lcom_facebook_FacebookException_;

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

			public static IOnErrorListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnErrorListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.CollectionMapper.OnErrorListener'.");
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

			public IOnErrorListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
			{
				if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
				{
					cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
				}
				return cb_onError_Lcom_facebook_FacebookException_;
			}

			private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
			{
				IOnErrorListener onErrorListener = Java.Lang.Object.GetObject<IOnErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FacebookException exception = Java.Lang.Object.GetObject<FacebookException>(native_exception, JniHandleOwnership.DoNotTransfer);
				onErrorListener.OnError(exception);
			}

			public unsafe void OnError(FacebookException exception)
			{
				if (id_onError_Lcom_facebook_FacebookException_ == IntPtr.Zero)
				{
					id_onError_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Lcom/facebook/FacebookException;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(exception?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onError_Lcom_facebook_FacebookException_, ptr);
			}
		}

		public class ErrorEventArgs : EventArgs
		{
			private FacebookException exception;

			public FacebookException Exception => exception;

			public ErrorEventArgs(FacebookException exception)
			{
				this.exception = exception;
			}
		}

		[Register("mono/com/facebook/internal/CollectionMapper_OnErrorListenerImplementor")]
		internal sealed class IOnErrorListenerImplementor : Java.Lang.Object, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<ErrorEventArgs> Handler;

			public IOnErrorListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/facebook/internal/CollectionMapper_OnErrorListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnError(FacebookException exception)
			{
				Handler?.Invoke(sender, new ErrorEventArgs(exception));
			}

			internal static bool __IsEmpty(IOnErrorListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/facebook/internal/CollectionMapper$OnMapperCompleteListener", "", "Xamarin.Facebook.Internal.CollectionMapper/IOnMapperCompleteListenerInvoker")]
		public interface IOnMapperCompleteListener : IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onComplete", "()V", "GetOnCompleteHandler:Xamarin.Facebook.Internal.CollectionMapper/IOnMapperCompleteListenerInvoker, Xamarin.Facebook.Share.Android")]
			void OnComplete();
		}

		[Register("com/facebook/internal/CollectionMapper$OnMapperCompleteListener", DoNotGenerateAcw = true)]
		internal class IOnMapperCompleteListenerInvoker : Java.Lang.Object, IOnMapperCompleteListener, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper$OnMapperCompleteListener", typeof(IOnMapperCompleteListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onComplete;

			private IntPtr id_onComplete;

			private static Delegate cb_onError_Lcom_facebook_FacebookException_;

			private IntPtr id_onError_Lcom_facebook_FacebookException_;

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

			public static IOnMapperCompleteListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMapperCompleteListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.CollectionMapper.OnMapperCompleteListener'.");
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

			public IOnMapperCompleteListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCompleteHandler()
			{
				if ((object)cb_onComplete == null)
				{
					cb_onComplete = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnComplete));
				}
				return cb_onComplete;
			}

			private static void n_OnComplete(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnMapperCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnComplete();
			}

			public void OnComplete()
			{
				if (id_onComplete == IntPtr.Zero)
				{
					id_onComplete = JNIEnv.GetMethodID(class_ref, "onComplete", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onComplete);
			}

			private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
			{
				if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
				{
					cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
				}
				return cb_onError_Lcom_facebook_FacebookException_;
			}

			private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
			{
				IOnMapperCompleteListener onMapperCompleteListener = Java.Lang.Object.GetObject<IOnMapperCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FacebookException exception = Java.Lang.Object.GetObject<FacebookException>(native_exception, JniHandleOwnership.DoNotTransfer);
				onMapperCompleteListener.OnError(exception);
			}

			public unsafe void OnError(FacebookException exception)
			{
				if (id_onError_Lcom_facebook_FacebookException_ == IntPtr.Zero)
				{
					id_onError_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Lcom/facebook/FacebookException;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(exception?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onError_Lcom_facebook_FacebookException_, ptr);
			}
		}

		[Register("com/facebook/internal/CollectionMapper$OnMapValueCompleteListener", "", "Xamarin.Facebook.Internal.CollectionMapper/IOnMapValueCompleteListenerInvoker")]
		public interface IOnMapValueCompleteListener : IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onComplete", "(Ljava/lang/Object;)V", "GetOnComplete_Ljava_lang_Object_Handler:Xamarin.Facebook.Internal.CollectionMapper/IOnMapValueCompleteListenerInvoker, Xamarin.Facebook.Share.Android")]
			void OnComplete(Java.Lang.Object mappedValue);
		}

		[Register("com/facebook/internal/CollectionMapper$OnMapValueCompleteListener", DoNotGenerateAcw = true)]
		internal class IOnMapValueCompleteListenerInvoker : Java.Lang.Object, IOnMapValueCompleteListener, IOnErrorListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper$OnMapValueCompleteListener", typeof(IOnMapValueCompleteListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onComplete_Ljava_lang_Object_;

			private IntPtr id_onComplete_Ljava_lang_Object_;

			private static Delegate cb_onError_Lcom_facebook_FacebookException_;

			private IntPtr id_onError_Lcom_facebook_FacebookException_;

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

			public static IOnMapValueCompleteListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMapValueCompleteListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.CollectionMapper.OnMapValueCompleteListener'.");
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

			public IOnMapValueCompleteListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnComplete_Ljava_lang_Object_Handler()
			{
				if ((object)cb_onComplete_Ljava_lang_Object_ == null)
				{
					cb_onComplete_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnComplete_Ljava_lang_Object_));
				}
				return cb_onComplete_Ljava_lang_Object_;
			}

			private static void n_OnComplete_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_mappedValue)
			{
				IOnMapValueCompleteListener onMapValueCompleteListener = Java.Lang.Object.GetObject<IOnMapValueCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object mappedValue = Java.Lang.Object.GetObject<Java.Lang.Object>(native_mappedValue, JniHandleOwnership.DoNotTransfer);
				onMapValueCompleteListener.OnComplete(mappedValue);
			}

			public unsafe void OnComplete(Java.Lang.Object mappedValue)
			{
				if (id_onComplete_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_onComplete_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onComplete", "(Ljava/lang/Object;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(mappedValue?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onComplete_Ljava_lang_Object_, ptr);
			}

			private static Delegate GetOnError_Lcom_facebook_FacebookException_Handler()
			{
				if ((object)cb_onError_Lcom_facebook_FacebookException_ == null)
				{
					cb_onError_Lcom_facebook_FacebookException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Lcom_facebook_FacebookException_));
				}
				return cb_onError_Lcom_facebook_FacebookException_;
			}

			private static void n_OnError_Lcom_facebook_FacebookException_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
			{
				IOnMapValueCompleteListener onMapValueCompleteListener = Java.Lang.Object.GetObject<IOnMapValueCompleteListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FacebookException exception = Java.Lang.Object.GetObject<FacebookException>(native_exception, JniHandleOwnership.DoNotTransfer);
				onMapValueCompleteListener.OnError(exception);
			}

			public unsafe void OnError(FacebookException exception)
			{
				if (id_onError_Lcom_facebook_FacebookException_ == IntPtr.Zero)
				{
					id_onError_Lcom_facebook_FacebookException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Lcom/facebook/FacebookException;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(exception?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onError_Lcom_facebook_FacebookException_, ptr);
			}
		}

		[Register("com/facebook/internal/CollectionMapper$ValueMapper", "", "Xamarin.Facebook.Internal.CollectionMapper/IValueMapperInvoker")]
		public interface IValueMapper : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("mapValue", "(Ljava/lang/Object;Lcom/facebook/internal/CollectionMapper$OnMapValueCompleteListener;)V", "GetMapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_Handler:Xamarin.Facebook.Internal.CollectionMapper/IValueMapperInvoker, Xamarin.Facebook.Share.Android")]
			void MapValue(Java.Lang.Object value, IOnMapValueCompleteListener onMapValueCompleteListener);
		}

		[Register("com/facebook/internal/CollectionMapper$ValueMapper", DoNotGenerateAcw = true)]
		internal class IValueMapperInvoker : Java.Lang.Object, IValueMapper, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper$ValueMapper", typeof(IValueMapperInvoker));

			private IntPtr class_ref;

			private static Delegate cb_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_;

			private IntPtr id_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_;

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

			public static IValueMapper GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IValueMapper>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.facebook.internal.CollectionMapper.ValueMapper'.");
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

			public IValueMapperInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetMapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_Handler()
			{
				if ((object)cb_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_ == null)
				{
					cb_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_MapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_));
				}
				return cb_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_;
			}

			private static void n_MapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_onMapValueCompleteListener)
			{
				IValueMapper valueMapper = Java.Lang.Object.GetObject<IValueMapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
				IOnMapValueCompleteListener onMapValueCompleteListener = Java.Lang.Object.GetObject<IOnMapValueCompleteListener>(native_onMapValueCompleteListener, JniHandleOwnership.DoNotTransfer);
				valueMapper.MapValue(value, onMapValueCompleteListener);
			}

			public unsafe void MapValue(Java.Lang.Object value, IOnMapValueCompleteListener onMapValueCompleteListener)
			{
				if (id_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_ == IntPtr.Zero)
				{
					id_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_ = JNIEnv.GetMethodID(class_ref, "mapValue", "(Ljava/lang/Object;Lcom/facebook/internal/CollectionMapper$OnMapValueCompleteListener;)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(value?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue((onMapValueCompleteListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onMapValueCompleteListener).Handle);
				JNIEnv.CallVoidMethod(base.Handle, id_mapValue_Ljava_lang_Object_Lcom_facebook_internal_CollectionMapper_OnMapValueCompleteListener_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/CollectionMapper", typeof(CollectionMapper));

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

		protected CollectionMapper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("iterate", "(Lcom/facebook/internal/CollectionMapper$Collection;Lcom/facebook/internal/CollectionMapper$ValueMapper;Lcom/facebook/internal/CollectionMapper$OnMapperCompleteListener;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void Iterate(ICollection collection, IValueMapper valueMapper, IOnMapperCompleteListener onMapperCompleteListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((collection == null) ? IntPtr.Zero : ((Java.Lang.Object)collection).Handle);
				ptr[1] = new JniArgumentValue((valueMapper == null) ? IntPtr.Zero : ((Java.Lang.Object)valueMapper).Handle);
				ptr[2] = new JniArgumentValue((onMapperCompleteListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onMapperCompleteListener).Handle);
				_members.StaticMethods.InvokeVoidMethod("iterate.(Lcom/facebook/internal/CollectionMapper$Collection;Lcom/facebook/internal/CollectionMapper$ValueMapper;Lcom/facebook/internal/CollectionMapper$OnMapperCompleteListener;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(collection);
				GC.KeepAlive(valueMapper);
				GC.KeepAlive(onMapperCompleteListener);
			}
		}
	}
	[Register("com/facebook/internal/Mutable", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public class Mutable : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/internal/Mutable", typeof(Mutable));

		[Register("value")]
		public Java.Lang.Object Value
		{
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceFields.GetObjectValue("value.Ljava/lang/Object;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("value.Ljava/lang/Object;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

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

		protected Mutable(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/Object;)V", "")]
		public unsafe Mutable(Java.Lang.Object value)
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
}
namespace Xamarin.Facebook.Share
{
	public class DeviceShareDialog
	{
	}
	[Register("com/facebook/share/BuildConfig", DoNotGenerateAcw = true)]
	public sealed class BuildConfig : Java.Lang.Object
	{
		[Register("BUILD_TYPE")]
		public const string BuildType = "release";

		[Register("DEBUG")]
		public const bool Debug = false;

		[Register("LIBRARY_PACKAGE_NAME")]
		public const string LibraryPackageName = "com.facebook.share";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/BuildConfig", typeof(BuildConfig));

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

		internal BuildConfig(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe BuildConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/share/Share", DoNotGenerateAcw = true)]
	public class Share : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/Share", typeof(Share));

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

		protected Share(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Share()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("com/facebook/share/ShareApi", DoNotGenerateAcw = true)]
	public sealed class ShareApi : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/ShareApi", typeof(ShareApi));

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

		public unsafe string GraphNode
		{
			[Register("getGraphNode", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getGraphNode.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setGraphNode", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setGraphNode.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe string Message
		{
			[Register("getMessage", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMessage", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setMessage.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe ShareContent ShareContent
		{
			[Register("getShareContent", "()Lcom/facebook/share/model/ShareContent;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareContent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getShareContent.()Lcom/facebook/share/model/ShareContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareApi(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/facebook/share/model/ShareContent;)V", "")]
		public unsafe ShareApi(ShareContent shareContent)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/facebook/share/model/ShareContent;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/facebook/share/model/ShareContent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(shareContent);
			}
		}

		[Register("canShare", "()Z", "")]
		public unsafe bool CanShare()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("canShare.()Z", this, null);
		}

		[Register("share", "(Lcom/facebook/FacebookCallback;)V", "")]
		public unsafe void Share(IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("share.(Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("share", "(Lcom/facebook/share/model/ShareContent;Lcom/facebook/FacebookCallback;)V", "")]
		public unsafe static void Share(ShareContent shareContent, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("share.(Lcom/facebook/share/model/ShareContent;Lcom/facebook/FacebookCallback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(shareContent);
				GC.KeepAlive(callback);
			}
		}
	}
}
namespace Xamarin.Facebook.Share.Internal
{
	[Register("com/facebook/share/internal/AppInviteDialogFeature", DoNotGenerateAcw = true)]
	public sealed class AppInviteDialogFeature : Java.Lang.Enum, IDialogFeature, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/internal/AppInviteDialogFeature", typeof(AppInviteDialogFeature));

		[Register("APP_INVITES_DIALOG")]
		public static AppInviteDialogFeature AppInvitesDialog => Java.Lang.Object.GetObject<AppInviteDialogFeature>(_members.StaticFields.GetObjectValue("APP_INVITES_DIALOG.Lcom/facebook/share/internal/AppInviteDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string Action
		{
			[Register("getAction", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getAction.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int MinVersion
		{
			[Register("getMinVersion", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinVersion.()I", this, null);
			}
		}

		internal AppInviteDialogFeature(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/internal/AppInviteDialogFeature;", "")]
		public unsafe static AppInviteDialogFeature ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<AppInviteDialogFeature>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/internal/AppInviteDialogFeature;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/share/internal/AppInviteDialogFeature;", "")]
		public unsafe static AppInviteDialogFeature[] Values()
		{
			return (AppInviteDialogFeature[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/internal/AppInviteDialogFeature;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AppInviteDialogFeature));
		}
	}
	[Register("com/facebook/share/internal/GameRequestValidation", DoNotGenerateAcw = true)]
	public class GameRequestValidation : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/internal/GameRequestValidation", typeof(GameRequestValidation));

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

		protected GameRequestValidation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GameRequestValidation()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("validate", "(Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Validate(GameRequestContent content)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("validate.(Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(content);
			}
		}
	}
	[Register("com/facebook/share/internal/MessageDialogFeature", DoNotGenerateAcw = true)]
	public sealed class MessageDialogFeature : Java.Lang.Enum, IDialogFeature, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/internal/MessageDialogFeature", typeof(MessageDialogFeature));

		[Register("MESSAGE_DIALOG")]
		public static MessageDialogFeature MessageDialog => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("MESSAGE_DIALOG.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MESSENGER_GENERIC_TEMPLATE")]
		public static MessageDialogFeature MessengerGenericTemplate => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("MESSENGER_GENERIC_TEMPLATE.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MESSENGER_MEDIA_TEMPLATE")]
		public static MessageDialogFeature MessengerMediaTemplate => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("MESSENGER_MEDIA_TEMPLATE.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MESSENGER_OPEN_GRAPH_MUSIC_TEMPLATE")]
		public static MessageDialogFeature MessengerOpenGraphMusicTemplate => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("MESSENGER_OPEN_GRAPH_MUSIC_TEMPLATE.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PHOTOS")]
		public static MessageDialogFeature Photos => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("PHOTOS.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("VIDEO")]
		public static MessageDialogFeature Video => Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticFields.GetObjectValue("VIDEO.Lcom/facebook/share/internal/MessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string Action
		{
			[Register("getAction", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getAction.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int MinVersion
		{
			[Register("getMinVersion", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinVersion.()I", this, null);
			}
		}

		internal MessageDialogFeature(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/internal/MessageDialogFeature;", "")]
		public unsafe static MessageDialogFeature ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MessageDialogFeature>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/internal/MessageDialogFeature;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/share/internal/MessageDialogFeature;", "")]
		public unsafe static MessageDialogFeature[] Values()
		{
			return (MessageDialogFeature[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/internal/MessageDialogFeature;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MessageDialogFeature));
		}
	}
	[Register("com/facebook/share/internal/OpenGraphMessageDialogFeature", DoNotGenerateAcw = true)]
	public sealed class OpenGraphMessageDialogFeature : Java.Lang.Enum, IDialogFeature, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/internal/OpenGraphMessageDialogFeature", typeof(OpenGraphMessageDialogFeature));

		[Register("OG_MESSAGE_DIALOG")]
		public static OpenGraphMessageDialogFeature OgMessageDialog => Java.Lang.Object.GetObject<OpenGraphMessageDialogFeature>(_members.StaticFields.GetObjectValue("OG_MESSAGE_DIALOG.Lcom/facebook/share/internal/OpenGraphMessageDialogFeature;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string Action
		{
			[Register("getAction", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getAction.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int MinVersion
		{
			[Register("getMinVersion", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinVersion.()I", this, null);
			}
		}

		internal OpenGraphMessageDialogFeature(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/facebook/share/internal/OpenGraphMessageDialogFeature;", "")]
		public unsafe static OpenGraphMessageDialogFeature ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OpenGraphMessageDialogFeature>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/facebook/share/internal/OpenGraphMessageDialogFeature;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lcom/facebook/share/internal/OpenGraphMessageDialogFeature;", "")]
		public unsafe static OpenGraphMessageDialogFeature[] Values()
		{
			return (OpenGraphMessageDialogFeature[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/facebook/share/internal/OpenGraphMessageDialogFeature;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OpenGraphMessageDialogFeature));
		}
	}
	[Register("com/facebook/share/internal/VideoUploader", DoNotGenerateAcw = true)]
	public class VideoUploader : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/internal/VideoUploader", typeof(VideoUploader));

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

		protected VideoUploader(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe VideoUploader()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("uploadAsync", "(Lcom/facebook/share/model/ShareVideoContent;Ljava/lang/String;Lcom/facebook/FacebookCallback;)V", "")]
		public unsafe static void UploadAsync(ShareVideoContent videoContent, string graphNode, IFacebookCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(graphNode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(videoContent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadAsync.(Lcom/facebook/share/model/ShareVideoContent;Ljava/lang/String;Lcom/facebook/FacebookCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(videoContent);
				GC.KeepAlive(callback);
			}
		}

		[Register("uploadAsyncWithProgressCallback", "(Lcom/facebook/share/model/ShareVideoContent;Lcom/facebook/GraphRequest$OnProgressCallback;)V", "")]
		public unsafe static void UploadAsyncWithProgressCallback(ShareVideoContent videoContent, GraphRequest.IOnProgressCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(videoContent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadAsyncWithProgressCallback.(Lcom/facebook/share/model/ShareVideoContent;Lcom/facebook/GraphRequest$OnProgressCallback;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(videoContent);
				GC.KeepAlive(callback);
			}
		}

		[Register("uploadAsyncWithProgressCallback", "(Lcom/facebook/share/model/ShareVideoContent;Ljava/lang/String;Lcom/facebook/GraphRequest$OnProgressCallback;)V", "")]
		public unsafe static void UploadAsyncWithProgressCallback(ShareVideoContent videoContent, string graphNode, GraphRequest.IOnProgressCallback callback)
		{
			IntPtr intPtr = JNIEnv.NewString(graphNode);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(videoContent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.StaticMethods.InvokeVoidMethod("uploadAsyncWithProgressCallback.(Lcom/facebook/share/model/ShareVideoContent;Ljava/lang/String;Lcom/facebook/GraphRequest$OnProgressCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(videoContent);
				GC.KeepAlive(callback);
			}
		}
	}
}
namespace Xamarin.Facebook.Share.Widget
{
	[Register("com/facebook/share/widget/ShareButtonBase", DoNotGenerateAcw = true)]
	public abstract class ShareButtonBase : FacebookButtonBase
	{
		private static Delegate cb_setEnabled_Z;

		private static IntPtr id_setEnabled_Z;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareButtonBase", typeof(ShareButtonBase));

		private static Delegate cb_getCallbackManager;

		private static Delegate cb_getDialog;

		private static Delegate cb_getShareContent;

		private static Delegate cb_setShareContent_Lcom_facebook_share_model_ShareContent_;

		private static Delegate cb_getShareOnClickListener;

		private static Delegate cb_canShare;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;

		private static Delegate cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;

		private static Delegate cb_setRequestCode_I;

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

		protected unsafe virtual ICallbackManager CallbackManager
		{
			[Register("getCallbackManager", "()Lcom/facebook/CallbackManager;", "GetGetCallbackManagerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICallbackManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCallbackManager.()Lcom/facebook/CallbackManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected abstract ShareDialog Dialog
		{
			[Register("getDialog", "()Lcom/facebook/share/widget/ShareDialog;", "GetGetDialogHandler")]
			get;
		}

		public unsafe virtual ShareContent ShareContent
		{
			[Register("getShareContent", "()Lcom/facebook/share/model/ShareContent;", "GetGetShareContentHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ShareContent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShareContent.()Lcom/facebook/share/model/ShareContent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setShareContent", "(Lcom/facebook/share/model/ShareContent;)V", "GetSetShareContent_Lcom_facebook_share_model_ShareContent_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setShareContent.(Lcom/facebook/share/model/ShareContent;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected unsafe virtual IOnClickListener ShareOnClickListener
		{
			[Register("getShareOnClickListener", "()Landroid/view/View$OnClickListener;", "GetGetShareOnClickListenerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IOnClickListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShareOnClickListener.()Landroid/view/View$OnClickListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static Delegate GetSetEnabled_ZHandler()
		{
			if ((object)cb_setEnabled_Z == null)
			{
				cb_setEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetEnabled_Z));
			}
			return cb_setEnabled_Z;
		}

		private static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEnabled(enabled);
		}

		[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
		public unsafe void SetEnabled(bool enabled)
		{
			if (id_setEnabled_Z == IntPtr.Zero)
			{
				id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(enabled);
			if (GetType() == ThresholdType)
			{
				JNIEnv.CallVoidMethod(base.Handle, id_setEnabled_Z, ptr);
			}
			else
			{
				JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setEnabled", "(Z)V"), ptr);
			}
		}

		protected ShareButtonBase(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;ILjava/lang/String;Ljava/lang/String;)V", "")]
		protected unsafe ShareButtonBase(Context context, IAttributeSet attrs, int defStyleAttr, string analyticsButtonCreatedEventName, string analyticsButtonTappedEventName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(analyticsButtonCreatedEventName);
			IntPtr intPtr2 = JNIEnv.NewString(analyticsButtonTappedEventName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(intPtr);
				ptr[4] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;ILjava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;ILjava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetCallbackManagerHandler()
		{
			if ((object)cb_getCallbackManager == null)
			{
				cb_getCallbackManager = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCallbackManager));
			}
			return cb_getCallbackManager;
		}

		private static IntPtr n_GetCallbackManager(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CallbackManager);
		}

		private static Delegate GetGetDialogHandler()
		{
			if ((object)cb_getDialog == null)
			{
				cb_getDialog = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDialog));
			}
			return cb_getDialog;
		}

		private static IntPtr n_GetDialog(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dialog);
		}

		private static Delegate GetGetShareContentHandler()
		{
			if ((object)cb_getShareContent == null)
			{
				cb_getShareContent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetShareContent));
			}
			return cb_getShareContent;
		}

		private static IntPtr n_GetShareContent(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShareContent);
		}

		private static Delegate GetSetShareContent_Lcom_facebook_share_model_ShareContent_Handler()
		{
			if ((object)cb_setShareContent_Lcom_facebook_share_model_ShareContent_ == null)
			{
				cb_setShareContent_Lcom_facebook_share_model_ShareContent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetShareContent_Lcom_facebook_share_model_ShareContent_));
			}
			return cb_setShareContent_Lcom_facebook_share_model_ShareContent_;
		}

		private static void n_SetShareContent_Lcom_facebook_share_model_ShareContent_(IntPtr jnienv, IntPtr native__this, IntPtr native_shareContent)
		{
			ShareButtonBase shareButtonBase = Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShareContent shareContent = Java.Lang.Object.GetObject<ShareContent>(native_shareContent, JniHandleOwnership.DoNotTransfer);
			shareButtonBase.ShareContent = shareContent;
		}

		private static Delegate GetGetShareOnClickListenerHandler()
		{
			if ((object)cb_getShareOnClickListener == null)
			{
				cb_getShareOnClickListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetShareOnClickListener));
			}
			return cb_getShareOnClickListener;
		}

		private static IntPtr n_GetShareOnClickListener(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShareOnClickListener);
		}

		private static Delegate GetCanShareHandler()
		{
			if ((object)cb_canShare == null)
			{
				cb_canShare = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanShare));
			}
			return cb_canShare;
		}

		private static bool n_CanShare(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanShare();
		}

		[Register("canShare", "()Z", "GetCanShareHandler")]
		protected unsafe virtual bool CanShare()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShare.()Z", this, null);
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			ShareButtonBase shareButtonBase = Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			shareButtonBase.RegisterCallback(callbackManager, callback);
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_Handler")]
		public unsafe virtual void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler()
		{
			if ((object)cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I == null)
			{
				cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I));
			}
			return cb_registerCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I;
		}

		private static void n_RegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_I(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback, int requestCode)
		{
			ShareButtonBase shareButtonBase = Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallbackManager callbackManager = Java.Lang.Object.GetObject<ICallbackManager>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			shareButtonBase.RegisterCallback(callbackManager, callback, requestCode);
		}

		[Register("registerCallback", "(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V", "GetRegisterCallback_Lcom_facebook_CallbackManager_Lcom_facebook_FacebookCallback_IHandler")]
		public unsafe virtual void RegisterCallback(ICallbackManager callbackManager, IFacebookCallback callback, int requestCode)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((callbackManager == null) ? IntPtr.Zero : ((Java.Lang.Object)callbackManager).Handle);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[2] = new JniArgumentValue(requestCode);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallback.(Lcom/facebook/CallbackManager;Lcom/facebook/FacebookCallback;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		private static Delegate GetSetRequestCode_IHandler()
		{
			if ((object)cb_setRequestCode_I == null)
			{
				cb_setRequestCode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetRequestCode_I));
			}
			return cb_setRequestCode_I;
		}

		private static void n_SetRequestCode_I(IntPtr jnienv, IntPtr native__this, int requestCode)
		{
			Java.Lang.Object.GetObject<ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRequestCode(requestCode);
		}

		[Register("setRequestCode", "(I)V", "GetSetRequestCode_IHandler")]
		protected unsafe virtual void SetRequestCode(int requestCode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRequestCode.(I)V", this, ptr);
		}
	}
	public class AppInviteDialog
	{
	}
	public class CreateAppGroupDialog
	{
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/facebook/share/widget/GameRequestDialog", DoNotGenerateAcw = true)]
	public class GameRequestDialog : FacebookDialogBase
	{
		[Register("com/facebook/share/widget/GameRequestDialog$Result", DoNotGenerateAcw = true)]
		public sealed class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/GameRequestDialog$Result", typeof(Result));

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

			public unsafe string RequestId
			{
				[Register("getRequestId", "()Ljava/lang/String;", "")]
				get
				{
					return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public unsafe IList<string> RequestRecipients
			{
				[Register("getRequestRecipients", "()Ljava/util/List;", "")]
				get
				{
					return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequestRecipients.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/GameRequestDialog", typeof(GameRequestDialog));

		private static Delegate cb_getOrderedModeHandlers;

		private static Delegate cb_createBaseAppCall;

		private static Delegate cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;

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

		protected unsafe virtual IList<FacebookDialogBase> OrderedModeHandlers
		{
			[Register("getOrderedModeHandlers", "()Ljava/util/List;", "GetGetOrderedModeHandlersHandler")]
			get
			{
				return JavaList<FacebookDialogBase>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrderedModeHandlers.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected override System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		protected GameRequestDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe GameRequestDialog(Activity activity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe GameRequestDialog(Android.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe GameRequestDialog(AndroidX.Fragment.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		private static Delegate GetGetOrderedModeHandlersHandler()
		{
			if ((object)cb_getOrderedModeHandlers == null)
			{
				cb_getOrderedModeHandlers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOrderedModeHandlers));
			}
			return cb_getOrderedModeHandlers;
		}

		private static IntPtr n_GetOrderedModeHandlers(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<FacebookDialogBase>.ToLocalJniHandle(Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrderedModeHandlers);
		}

		[Register("canShow", "()Z", "")]
		public unsafe static bool CanShow()
		{
			return _members.StaticMethods.InvokeBooleanMethod("canShow.()Z", null);
		}

		private static Delegate GetCreateBaseAppCallHandler()
		{
			if ((object)cb_createBaseAppCall == null)
			{
				cb_createBaseAppCall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateBaseAppCall));
			}
			return cb_createBaseAppCall;
		}

		private static IntPtr n_CreateBaseAppCall(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateBaseAppCall());
		}

		[Register("createBaseAppCall", "()Lcom/facebook/internal/AppCall;", "GetCreateBaseAppCallHandler")]
		protected unsafe override AppCall CreateBaseAppCall()
		{
			return Java.Lang.Object.GetObject<AppCall>(_members.InstanceMethods.InvokeVirtualObjectMethod("createBaseAppCall.()Lcom/facebook/internal/AppCall;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler()
		{
			if ((object)cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ == null)
			{
				cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_));
			}
			return cb_registerCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_;
		}

		private static void n_RegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackManager, IntPtr native__callback)
		{
			GameRequestDialog gameRequestDialog = Java.Lang.Object.GetObject<GameRequestDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CallbackManagerImpl callbackManager = Java.Lang.Object.GetObject<CallbackManagerImpl>(native_callbackManager, JniHandleOwnership.DoNotTransfer);
			IFacebookCallback callback = Java.Lang.Object.GetObject<IFacebookCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			gameRequestDialog.RegisterCallbackImpl(callbackManager, callback);
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "GetRegisterCallbackImpl_Lcom_facebook_internal_CallbackManagerImpl_Lcom_facebook_FacebookCallback_Handler")]
		protected unsafe override void RegisterCallbackImpl(CallbackManagerImpl callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callbackManager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerCallbackImpl.(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		[Register("show", "(Landroid/app/Activity;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(Activity activity, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Activity;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(gameRequestContent);
			}
		}

		[Register("show", "(Landroid/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(Android.App.Fragment fragment, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(gameRequestContent);
			}
		}

		[Register("show", "(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", "")]
		public unsafe static void Show(AndroidX.Fragment.App.Fragment fragment, GameRequestContent gameRequestContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gameRequestContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/GameRequestContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(gameRequestContent);
			}
		}
	}
	public class JoinAppGroupDialog
	{
	}
	[Register("com/facebook/share/widget/MessageDialog", DoNotGenerateAcw = true)]
	public sealed class MessageDialog : ShareDialog, ISharer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/MessageDialog", typeof(MessageDialog));

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

		protected override System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}

		internal MessageDialog(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe MessageDialog(Activity activity)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[Register(".ctor", "(Landroid/app/Fragment;)V", "")]
		public unsafe MessageDialog(Android.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register(".ctor", "(Landroidx/fragment/app/Fragment;)V", "")]
		public unsafe MessageDialog(AndroidX.Fragment.App.Fragment fragment)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
			}
		}

		[Register("canShow", "(Ljava/lang/Class;)Z", "")]
		public new unsafe static bool CanShow(Class contentType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(contentType?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("canShow.(Ljava/lang/Class;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(contentType);
			}
		}

		[Register("registerCallbackImpl", "(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", "")]
		protected unsafe override void RegisterCallbackImpl(CallbackManagerImpl callbackManager, IFacebookCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(callbackManager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("registerCallbackImpl.(Lcom/facebook/internal/CallbackManagerImpl;Lcom/facebook/FacebookCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callbackManager);
				GC.KeepAlive(callback);
			}
		}

		[Register("show", "(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", "")]
		public new unsafe static void Show(Activity activity, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Activity;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(shareContent);
			}
		}

		[Register("show", "(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
		public new unsafe static void Show(Android.App.Fragment fragment, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroid/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(shareContent);
			}
		}

		[Register("show", "(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", "")]
		public new unsafe static void Show(AndroidX.Fragment.App.Fragment fragment, ShareContent shareContent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(shareContent?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("show.(Landroidx/fragment/app/Fragment;Lcom/facebook/share/model/ShareContent;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(fragment);
				GC.KeepAlive(shareContent);
			}
		}
	}
	[Register("com/facebook/share/widget/SendButton", DoNotGenerateAcw = true)]
	public sealed class SendButton : ShareButtonBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/SendButton", typeof(SendButton));

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

		protected unsafe override int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDefaultRequestCode.()I", this, null);
			}
		}

		protected unsafe override ShareDialog Dialog
		{
			[Register("getDialog", "()Lcom/facebook/share/widget/ShareDialog;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareDialog>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDialog.()Lcom/facebook/share/widget/ShareDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SendButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SendButton(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe SendButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe SendButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}
	}
	[Register("com/facebook/share/widget/ShareButton", DoNotGenerateAcw = true)]
	public sealed class ShareButton : ShareButtonBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareButton", typeof(ShareButton));

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

		protected unsafe override int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDefaultRequestCode.()I", this, null);
			}
		}

		protected unsafe override ShareDialog Dialog
		{
			[Register("getDialog", "()Lcom/facebook/share/widget/ShareDialog;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ShareDialog>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDialog.()Lcom/facebook/share/widget/ShareDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ShareButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ShareButton(Context context)
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

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe ShareButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe ShareButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}
	}
	[Register("com/facebook/share/widget/ShareButtonBase", DoNotGenerateAcw = true)]
	internal class ShareButtonBaseInvoker : ShareButtonBase
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/facebook/share/widget/ShareButtonBase", typeof(ShareButtonBaseInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected unsafe override ShareDialog Dialog
		{
			[Register("getDialog", "()Lcom/facebook/share/widget/ShareDialog;", "GetGetDialogHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ShareDialog>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDialog.()Lcom/facebook/share/widget/ShareDialog;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe override int DefaultRequestCode
		{
			[Register("getDefaultRequestCode", "()I", "GetGetDefaultRequestCodeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDefaultRequestCode.()I", this, null);
			}
		}

		public ShareButtonBaseInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
namespace Xamarin.Facebook.Share.Model
{
	public class AppInviteContent
	{
		private static IntPtr id_readFrom_Landroid_os_Parcel_;
	}
}
