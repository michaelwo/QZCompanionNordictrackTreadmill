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
using Android.Gms.Common.Internal.SafeParcel;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "fb4985bc40adce1eed066f366d7905c21957aac8")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20220414.6")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "4/14/2022 7:04:25 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: UsesLibrary("org.apache.http.legacy", Required = false)]
[assembly: NamespaceMapping(Java = "com.google.android.gms.maps", Managed = "Android.Gms.Maps")]
[assembly: NamespaceMapping(Java = "com.google.android.gms.maps.model", Managed = "Android.Gms.Maps.Model")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Maps 117.0.1.5 artifact=com.google.android.gms:play-services-maps artifact_versioned=com.google.android.gms:play-services-maps:17.0.1\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Maps")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Maps")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPIII_L(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
namespace Android.Gms.Maps
{
	[Register("com/google/android/gms/maps/CameraUpdate", DoNotGenerateAcw = true)]
	public sealed class CameraUpdate : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/CameraUpdate", typeof(CameraUpdate));

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

		internal CameraUpdate(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/android/gms/maps/CameraUpdateFactory", DoNotGenerateAcw = true)]
	public sealed class CameraUpdateFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/CameraUpdateFactory", typeof(CameraUpdateFactory));

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

		internal CameraUpdateFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newCameraPosition", "(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate NewCameraPosition(CameraPosition cameraPosition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraPosition?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("newCameraPosition.(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cameraPosition);
			}
		}

		[Register("newLatLng", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate NewLatLng(LatLng latLng)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(latLng?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("newLatLng.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(latLng);
			}
		}

		[Register("newLatLngBounds", "(Lcom/google/android/gms/maps/model/LatLngBounds;I)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate NewLatLngBounds(LatLngBounds bounds, int padding)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(padding);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("newLatLngBounds.(Lcom/google/android/gms/maps/model/LatLngBounds;I)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}

		[Register("newLatLngBounds", "(Lcom/google/android/gms/maps/model/LatLngBounds;III)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate NewLatLngBounds(LatLngBounds bounds, int width, int height, int padding)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				ptr[3] = new JniArgumentValue(padding);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("newLatLngBounds.(Lcom/google/android/gms/maps/model/LatLngBounds;III)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}

		[Register("newLatLngZoom", "(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate NewLatLngZoom(LatLng latLng, float zoom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(latLng?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(zoom);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("newLatLngZoom.(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(latLng);
			}
		}

		[Register("scrollBy", "(FF)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ScrollBy(float xPixel, float yPixel)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(xPixel);
			ptr[1] = new JniArgumentValue(yPixel);
			return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("scrollBy.(FF)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomBy", "(F)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ZoomBy(float amount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(amount);
			return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("zoomBy.(F)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomBy", "(FLandroid/graphics/Point;)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ZoomBy(float amount, Point focus)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(amount);
				ptr[1] = new JniArgumentValue(focus?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("zoomBy.(FLandroid/graphics/Point;)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(focus);
			}
		}

		[Register("zoomIn", "()Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ZoomIn()
		{
			return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("zoomIn.()Lcom/google/android/gms/maps/CameraUpdate;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomOut", "()Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ZoomOut()
		{
			return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("zoomOut.()Lcom/google/android/gms/maps/CameraUpdate;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomTo", "(F)Lcom/google/android/gms/maps/CameraUpdate;", "")]
		public unsafe static CameraUpdate ZoomTo(float zoom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zoom);
			return Java.Lang.Object.GetObject<CameraUpdate>(_members.StaticMethods.InvokeObjectMethod("zoomTo.(F)Lcom/google/android/gms/maps/CameraUpdate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/GoogleMap", DoNotGenerateAcw = true)]
	public class GoogleMap : Java.Lang.Object
	{
		[Register("com/google/android/gms/maps/GoogleMap$CancelableCallback", "", "Android.Gms.Maps.GoogleMap/ICancelableCallbackInvoker")]
		public interface ICancelableCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCancel", "()V", "GetOnCancelHandler:Android.Gms.Maps.GoogleMap/ICancelableCallbackInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCancel();

			[Register("onFinish", "()V", "GetOnFinishHandler:Android.Gms.Maps.GoogleMap/ICancelableCallbackInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnFinish();
		}

		[Register("com/google/android/gms/maps/GoogleMap$CancelableCallback", DoNotGenerateAcw = true)]
		internal class ICancelableCallbackInvoker : Java.Lang.Object, ICancelableCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$CancelableCallback", typeof(ICancelableCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCancel;

			private IntPtr id_onCancel;

			private static Delegate cb_onFinish;

			private IntPtr id_onFinish;

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

			public static ICancelableCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ICancelableCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.CancelableCallback'.");
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

			public ICancelableCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCancelHandler()
			{
				if ((object)cb_onCancel == null)
				{
					cb_onCancel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCancel));
				}
				return cb_onCancel;
			}

			private static void n_OnCancel(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<ICancelableCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCancel();
			}

			public void OnCancel()
			{
				if (id_onCancel == IntPtr.Zero)
				{
					id_onCancel = JNIEnv.GetMethodID(class_ref, "onCancel", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onCancel);
			}

			private static Delegate GetOnFinishHandler()
			{
				if ((object)cb_onFinish == null)
				{
					cb_onFinish = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnFinish));
				}
				return cb_onFinish;
			}

			private static void n_OnFinish(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<ICancelableCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFinish();
			}

			public void OnFinish()
			{
				if (id_onFinish == IntPtr.Zero)
				{
					id_onFinish = JNIEnv.GetMethodID(class_ref, "onFinish", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onFinish);
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$InfoWindowAdapter", "", "Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker")]
		public interface IInfoWindowAdapter : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("getInfoContents", "(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;", "GetGetInfoContents_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps")]
			View GetInfoContents(Marker marker);

			[Register("getInfoWindow", "(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;", "GetGetInfoWindow_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps")]
			View GetInfoWindow(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$InfoWindowAdapter", DoNotGenerateAcw = true)]
		internal class IInfoWindowAdapterInvoker : Java.Lang.Object, IInfoWindowAdapter, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$InfoWindowAdapter", typeof(IInfoWindowAdapterInvoker));

			private IntPtr class_ref;

			private static Delegate cb_getInfoContents_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_getInfoContents_Lcom_google_android_gms_maps_model_Marker_;

			private static Delegate cb_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IInfoWindowAdapter GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IInfoWindowAdapter>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.InfoWindowAdapter'.");
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

			public IInfoWindowAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGetInfoContents_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_getInfoContents_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_getInfoContents_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetInfoContents_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_getInfoContents_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static IntPtr n_GetInfoContents_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IInfoWindowAdapter infoWindowAdapter = Java.Lang.Object.GetObject<IInfoWindowAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(infoWindowAdapter.GetInfoContents(marker));
			}

			public unsafe View GetInfoContents(Marker marker)
			{
				if (id_getInfoContents_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_getInfoContents_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "getInfoContents", "(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(JNIEnv.CallObjectMethod(base.Handle, id_getInfoContents_Lcom_google_android_gms_maps_model_Marker_, ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetGetInfoWindow_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetInfoWindow_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static IntPtr n_GetInfoWindow_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IInfoWindowAdapter infoWindowAdapter = Java.Lang.Object.GetObject<IInfoWindowAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(infoWindowAdapter.GetInfoWindow(marker));
			}

			public unsafe View GetInfoWindow(Marker marker)
			{
				if (id_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "getInfoWindow", "(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(JNIEnv.CallObjectMethod(base.Handle, id_getInfoWindow_Lcom_google_android_gms_maps_model_Marker_, ptr), JniHandleOwnership.TransferLocalRef);
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraChangeListener", "", "Android.Gms.Maps.GoogleMap/IOnCameraChangeListenerInvoker")]
		public interface IOnCameraChangeListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCameraChange", "(Lcom/google/android/gms/maps/model/CameraPosition;)V", "GetOnCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_Handler:Android.Gms.Maps.GoogleMap/IOnCameraChangeListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCameraChange(CameraPosition position);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraChangeListener", DoNotGenerateAcw = true)]
		internal class IOnCameraChangeListenerInvoker : Java.Lang.Object, IOnCameraChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCameraChangeListener", typeof(IOnCameraChangeListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_;

			private IntPtr id_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_;

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

			public static IOnCameraChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCameraChangeListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCameraChangeListener'.");
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

			public IOnCameraChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_Handler()
			{
				if ((object)cb_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_ == null)
				{
					cb_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_));
				}
				return cb_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_;
			}

			private static void n_OnCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_(IntPtr jnienv, IntPtr native__this, IntPtr native_position)
			{
				IOnCameraChangeListener onCameraChangeListener = Java.Lang.Object.GetObject<IOnCameraChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CameraPosition position = Java.Lang.Object.GetObject<CameraPosition>(native_position, JniHandleOwnership.DoNotTransfer);
				onCameraChangeListener.OnCameraChange(position);
			}

			public unsafe void OnCameraChange(CameraPosition position)
			{
				if (id_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_ == IntPtr.Zero)
				{
					id_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_ = JNIEnv.GetMethodID(class_ref, "onCameraChange", "(Lcom/google/android/gms/maps/model/CameraPosition;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(position?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onCameraChange_Lcom_google_android_gms_maps_model_CameraPosition_, ptr);
			}
		}

		public class CameraChangeEventArgs : EventArgs
		{
			private CameraPosition position;

			public CameraChangeEventArgs(CameraPosition position)
			{
				this.position = position;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCameraChangeListenerImplementor")]
		internal sealed class IOnCameraChangeListenerImplementor : Java.Lang.Object, IOnCameraChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CameraChangeEventArgs> Handler;

			public IOnCameraChangeListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCameraChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCameraChange(CameraPosition position)
			{
				Handler?.Invoke(sender, new CameraChangeEventArgs(position));
			}

			internal static bool __IsEmpty(IOnCameraChangeListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraIdleListener", "", "Android.Gms.Maps.GoogleMap/IOnCameraIdleListenerInvoker")]
		public interface IOnCameraIdleListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCameraIdle", "()V", "GetOnCameraIdleHandler:Android.Gms.Maps.GoogleMap/IOnCameraIdleListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCameraIdle();
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraIdleListener", DoNotGenerateAcw = true)]
		internal class IOnCameraIdleListenerInvoker : Java.Lang.Object, IOnCameraIdleListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCameraIdleListener", typeof(IOnCameraIdleListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCameraIdle;

			private IntPtr id_onCameraIdle;

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

			public static IOnCameraIdleListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCameraIdleListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCameraIdleListener'.");
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

			public IOnCameraIdleListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCameraIdleHandler()
			{
				if ((object)cb_onCameraIdle == null)
				{
					cb_onCameraIdle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCameraIdle));
				}
				return cb_onCameraIdle;
			}

			private static void n_OnCameraIdle(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnCameraIdleListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCameraIdle();
			}

			public void OnCameraIdle()
			{
				if (id_onCameraIdle == IntPtr.Zero)
				{
					id_onCameraIdle = JNIEnv.GetMethodID(class_ref, "onCameraIdle", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onCameraIdle);
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCameraIdleListenerImplementor")]
		internal sealed class IOnCameraIdleListenerImplementor : Java.Lang.Object, IOnCameraIdleListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler Handler;

			public IOnCameraIdleListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCameraIdleListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCameraIdle()
			{
				Handler?.Invoke(sender, new EventArgs());
			}

			internal static bool __IsEmpty(IOnCameraIdleListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveCanceledListener", "", "Android.Gms.Maps.GoogleMap/IOnCameraMoveCanceledListenerInvoker")]
		public interface IOnCameraMoveCanceledListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCameraMoveCanceled", "()V", "GetOnCameraMoveCanceledHandler:Android.Gms.Maps.GoogleMap/IOnCameraMoveCanceledListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCameraMoveCanceled();
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveCanceledListener", DoNotGenerateAcw = true)]
		internal class IOnCameraMoveCanceledListenerInvoker : Java.Lang.Object, IOnCameraMoveCanceledListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCameraMoveCanceledListener", typeof(IOnCameraMoveCanceledListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCameraMoveCanceled;

			private IntPtr id_onCameraMoveCanceled;

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

			public static IOnCameraMoveCanceledListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCameraMoveCanceledListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCameraMoveCanceledListener'.");
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

			public IOnCameraMoveCanceledListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCameraMoveCanceledHandler()
			{
				if ((object)cb_onCameraMoveCanceled == null)
				{
					cb_onCameraMoveCanceled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCameraMoveCanceled));
				}
				return cb_onCameraMoveCanceled;
			}

			private static void n_OnCameraMoveCanceled(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnCameraMoveCanceledListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCameraMoveCanceled();
			}

			public void OnCameraMoveCanceled()
			{
				if (id_onCameraMoveCanceled == IntPtr.Zero)
				{
					id_onCameraMoveCanceled = JNIEnv.GetMethodID(class_ref, "onCameraMoveCanceled", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onCameraMoveCanceled);
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveCanceledListenerImplementor")]
		internal sealed class IOnCameraMoveCanceledListenerImplementor : Java.Lang.Object, IOnCameraMoveCanceledListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler Handler;

			public IOnCameraMoveCanceledListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveCanceledListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCameraMoveCanceled()
			{
				Handler?.Invoke(sender, new EventArgs());
			}

			internal static bool __IsEmpty(IOnCameraMoveCanceledListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveListener", "", "Android.Gms.Maps.GoogleMap/IOnCameraMoveListenerInvoker")]
		public interface IOnCameraMoveListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCameraMove", "()V", "GetOnCameraMoveHandler:Android.Gms.Maps.GoogleMap/IOnCameraMoveListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCameraMove();
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveListener", DoNotGenerateAcw = true)]
		internal class IOnCameraMoveListenerInvoker : Java.Lang.Object, IOnCameraMoveListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCameraMoveListener", typeof(IOnCameraMoveListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCameraMove;

			private IntPtr id_onCameraMove;

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

			public static IOnCameraMoveListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCameraMoveListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCameraMoveListener'.");
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

			public IOnCameraMoveListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCameraMoveHandler()
			{
				if ((object)cb_onCameraMove == null)
				{
					cb_onCameraMove = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCameraMove));
				}
				return cb_onCameraMove;
			}

			private static void n_OnCameraMove(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnCameraMoveListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCameraMove();
			}

			public void OnCameraMove()
			{
				if (id_onCameraMove == IntPtr.Zero)
				{
					id_onCameraMove = JNIEnv.GetMethodID(class_ref, "onCameraMove", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onCameraMove);
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveListenerImplementor")]
		internal sealed class IOnCameraMoveListenerImplementor : Java.Lang.Object, IOnCameraMoveListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler Handler;

			public IOnCameraMoveListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCameraMove()
			{
				Handler?.Invoke(sender, new EventArgs());
			}

			internal static bool __IsEmpty(IOnCameraMoveListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveStartedListener", "", "Android.Gms.Maps.GoogleMap/IOnCameraMoveStartedListenerInvoker")]
		public interface IOnCameraMoveStartedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCameraMoveStarted", "(I)V", "GetOnCameraMoveStarted_IHandler:Android.Gms.Maps.GoogleMap/IOnCameraMoveStartedListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCameraMoveStarted(int reason);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCameraMoveStartedListener", DoNotGenerateAcw = true)]
		internal class IOnCameraMoveStartedListenerInvoker : Java.Lang.Object, IOnCameraMoveStartedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCameraMoveStartedListener", typeof(IOnCameraMoveStartedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCameraMoveStarted_I;

			private IntPtr id_onCameraMoveStarted_I;

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

			public static IOnCameraMoveStartedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCameraMoveStartedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCameraMoveStartedListener'.");
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

			public IOnCameraMoveStartedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCameraMoveStarted_IHandler()
			{
				if ((object)cb_onCameraMoveStarted_I == null)
				{
					cb_onCameraMoveStarted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCameraMoveStarted_I));
				}
				return cb_onCameraMoveStarted_I;
			}

			private static void n_OnCameraMoveStarted_I(IntPtr jnienv, IntPtr native__this, int reason)
			{
				Java.Lang.Object.GetObject<IOnCameraMoveStartedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCameraMoveStarted(reason);
			}

			public unsafe void OnCameraMoveStarted(int reason)
			{
				if (id_onCameraMoveStarted_I == IntPtr.Zero)
				{
					id_onCameraMoveStarted_I = JNIEnv.GetMethodID(class_ref, "onCameraMoveStarted", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(reason);
				JNIEnv.CallVoidMethod(base.Handle, id_onCameraMoveStarted_I, ptr);
			}
		}

		public class CameraMoveStartedEventArgs : EventArgs
		{
			private int reason;

			public CameraMoveStartedEventArgs(int reason)
			{
				this.reason = reason;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveStartedListenerImplementor")]
		internal sealed class IOnCameraMoveStartedListenerImplementor : Java.Lang.Object, IOnCameraMoveStartedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CameraMoveStartedEventArgs> Handler;

			public IOnCameraMoveStartedListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCameraMoveStartedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCameraMoveStarted(int reason)
			{
				Handler?.Invoke(sender, new CameraMoveStartedEventArgs(reason));
			}

			internal static bool __IsEmpty(IOnCameraMoveStartedListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCircleClickListener", "", "Android.Gms.Maps.GoogleMap/IOnCircleClickListenerInvoker")]
		public interface IOnCircleClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onCircleClick", "(Lcom/google/android/gms/maps/model/Circle;)V", "GetOnCircleClick_Lcom_google_android_gms_maps_model_Circle_Handler:Android.Gms.Maps.GoogleMap/IOnCircleClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnCircleClick(Circle circle);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnCircleClickListener", DoNotGenerateAcw = true)]
		internal class IOnCircleClickListenerInvoker : Java.Lang.Object, IOnCircleClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnCircleClickListener", typeof(IOnCircleClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onCircleClick_Lcom_google_android_gms_maps_model_Circle_;

			private IntPtr id_onCircleClick_Lcom_google_android_gms_maps_model_Circle_;

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

			public static IOnCircleClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnCircleClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnCircleClickListener'.");
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

			public IOnCircleClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnCircleClick_Lcom_google_android_gms_maps_model_Circle_Handler()
			{
				if ((object)cb_onCircleClick_Lcom_google_android_gms_maps_model_Circle_ == null)
				{
					cb_onCircleClick_Lcom_google_android_gms_maps_model_Circle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCircleClick_Lcom_google_android_gms_maps_model_Circle_));
				}
				return cb_onCircleClick_Lcom_google_android_gms_maps_model_Circle_;
			}

			private static void n_OnCircleClick_Lcom_google_android_gms_maps_model_Circle_(IntPtr jnienv, IntPtr native__this, IntPtr native_circle)
			{
				IOnCircleClickListener onCircleClickListener = Java.Lang.Object.GetObject<IOnCircleClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Circle circle = Java.Lang.Object.GetObject<Circle>(native_circle, JniHandleOwnership.DoNotTransfer);
				onCircleClickListener.OnCircleClick(circle);
			}

			public unsafe void OnCircleClick(Circle circle)
			{
				if (id_onCircleClick_Lcom_google_android_gms_maps_model_Circle_ == IntPtr.Zero)
				{
					id_onCircleClick_Lcom_google_android_gms_maps_model_Circle_ = JNIEnv.GetMethodID(class_ref, "onCircleClick", "(Lcom/google/android/gms/maps/model/Circle;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(circle?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onCircleClick_Lcom_google_android_gms_maps_model_Circle_, ptr);
			}
		}

		public class CircleClickEventArgs : EventArgs
		{
			private Circle circle;

			public CircleClickEventArgs(Circle circle)
			{
				this.circle = circle;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnCircleClickListenerImplementor")]
		internal sealed class IOnCircleClickListenerImplementor : Java.Lang.Object, IOnCircleClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<CircleClickEventArgs> Handler;

			public IOnCircleClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnCircleClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnCircleClick(Circle circle)
			{
				Handler?.Invoke(sender, new CircleClickEventArgs(circle));
			}

			internal static bool __IsEmpty(IOnCircleClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnGroundOverlayClickListener", "", "Android.Gms.Maps.GoogleMap/IOnGroundOverlayClickListenerInvoker")]
		public interface IOnGroundOverlayClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onGroundOverlayClick", "(Lcom/google/android/gms/maps/model/GroundOverlay;)V", "GetOnGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_Handler:Android.Gms.Maps.GoogleMap/IOnGroundOverlayClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnGroundOverlayClick(GroundOverlay groundOverlay);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnGroundOverlayClickListener", DoNotGenerateAcw = true)]
		internal class IOnGroundOverlayClickListenerInvoker : Java.Lang.Object, IOnGroundOverlayClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnGroundOverlayClickListener", typeof(IOnGroundOverlayClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_;

			private IntPtr id_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_;

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

			public static IOnGroundOverlayClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnGroundOverlayClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnGroundOverlayClickListener'.");
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

			public IOnGroundOverlayClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_Handler()
			{
				if ((object)cb_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_ == null)
				{
					cb_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_));
				}
				return cb_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_;
			}

			private static void n_OnGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_(IntPtr jnienv, IntPtr native__this, IntPtr native_groundOverlay)
			{
				IOnGroundOverlayClickListener onGroundOverlayClickListener = Java.Lang.Object.GetObject<IOnGroundOverlayClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				GroundOverlay groundOverlay = Java.Lang.Object.GetObject<GroundOverlay>(native_groundOverlay, JniHandleOwnership.DoNotTransfer);
				onGroundOverlayClickListener.OnGroundOverlayClick(groundOverlay);
			}

			public unsafe void OnGroundOverlayClick(GroundOverlay groundOverlay)
			{
				if (id_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_ == IntPtr.Zero)
				{
					id_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_ = JNIEnv.GetMethodID(class_ref, "onGroundOverlayClick", "(Lcom/google/android/gms/maps/model/GroundOverlay;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(groundOverlay?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onGroundOverlayClick_Lcom_google_android_gms_maps_model_GroundOverlay_, ptr);
			}
		}

		public class GroundOverlayClickEventArgs : EventArgs
		{
			private GroundOverlay groundOverlay;

			public GroundOverlayClickEventArgs(GroundOverlay groundOverlay)
			{
				this.groundOverlay = groundOverlay;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnGroundOverlayClickListenerImplementor")]
		internal sealed class IOnGroundOverlayClickListenerImplementor : Java.Lang.Object, IOnGroundOverlayClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<GroundOverlayClickEventArgs> Handler;

			public IOnGroundOverlayClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnGroundOverlayClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnGroundOverlayClick(GroundOverlay groundOverlay)
			{
				Handler?.Invoke(sender, new GroundOverlayClickEventArgs(groundOverlay));
			}

			internal static bool __IsEmpty(IOnGroundOverlayClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnIndoorStateChangeListener", "", "Android.Gms.Maps.GoogleMap/IOnIndoorStateChangeListenerInvoker")]
		public interface IOnIndoorStateChangeListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onIndoorBuildingFocused", "()V", "GetOnIndoorBuildingFocusedHandler:Android.Gms.Maps.GoogleMap/IOnIndoorStateChangeListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnIndoorBuildingFocused();

			[Register("onIndoorLevelActivated", "(Lcom/google/android/gms/maps/model/IndoorBuilding;)V", "GetOnIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_Handler:Android.Gms.Maps.GoogleMap/IOnIndoorStateChangeListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnIndoorLevelActivated(IndoorBuilding building);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnIndoorStateChangeListener", DoNotGenerateAcw = true)]
		internal class IOnIndoorStateChangeListenerInvoker : Java.Lang.Object, IOnIndoorStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnIndoorStateChangeListener", typeof(IOnIndoorStateChangeListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onIndoorBuildingFocused;

			private IntPtr id_onIndoorBuildingFocused;

			private static Delegate cb_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_;

			private IntPtr id_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_;

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

			public static IOnIndoorStateChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnIndoorStateChangeListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnIndoorStateChangeListener'.");
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

			public IOnIndoorStateChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnIndoorBuildingFocusedHandler()
			{
				if ((object)cb_onIndoorBuildingFocused == null)
				{
					cb_onIndoorBuildingFocused = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnIndoorBuildingFocused));
				}
				return cb_onIndoorBuildingFocused;
			}

			private static void n_OnIndoorBuildingFocused(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnIndoorStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnIndoorBuildingFocused();
			}

			public void OnIndoorBuildingFocused()
			{
				if (id_onIndoorBuildingFocused == IntPtr.Zero)
				{
					id_onIndoorBuildingFocused = JNIEnv.GetMethodID(class_ref, "onIndoorBuildingFocused", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onIndoorBuildingFocused);
			}

			private static Delegate GetOnIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_Handler()
			{
				if ((object)cb_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_ == null)
				{
					cb_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_));
				}
				return cb_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_;
			}

			private static void n_OnIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_(IntPtr jnienv, IntPtr native__this, IntPtr native_building)
			{
				IOnIndoorStateChangeListener onIndoorStateChangeListener = Java.Lang.Object.GetObject<IOnIndoorStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IndoorBuilding building = Java.Lang.Object.GetObject<IndoorBuilding>(native_building, JniHandleOwnership.DoNotTransfer);
				onIndoorStateChangeListener.OnIndoorLevelActivated(building);
			}

			public unsafe void OnIndoorLevelActivated(IndoorBuilding building)
			{
				if (id_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_ == IntPtr.Zero)
				{
					id_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_ = JNIEnv.GetMethodID(class_ref, "onIndoorLevelActivated", "(Lcom/google/android/gms/maps/model/IndoorBuilding;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(building?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onIndoorLevelActivated_Lcom_google_android_gms_maps_model_IndoorBuilding_, ptr);
			}
		}

		public class IndoorLevelActivatedEventArgs : EventArgs
		{
			private IndoorBuilding building;

			public IndoorLevelActivatedEventArgs(IndoorBuilding building)
			{
				this.building = building;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnIndoorStateChangeListenerImplementor")]
		internal sealed class IOnIndoorStateChangeListenerImplementor : Java.Lang.Object, IOnIndoorStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler OnIndoorBuildingFocusedHandler;

			public EventHandler<IndoorLevelActivatedEventArgs> OnIndoorLevelActivatedHandler;

			public IOnIndoorStateChangeListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnIndoorStateChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnIndoorBuildingFocused()
			{
				OnIndoorBuildingFocusedHandler?.Invoke(sender, new EventArgs());
			}

			public void OnIndoorLevelActivated(IndoorBuilding building)
			{
				OnIndoorLevelActivatedHandler?.Invoke(sender, new IndoorLevelActivatedEventArgs(building));
			}

			internal static bool __IsEmpty(IOnIndoorStateChangeListenerImplementor value)
			{
				if (value.OnIndoorBuildingFocusedHandler == null)
				{
					return value.OnIndoorLevelActivatedHandler == null;
				}
				return false;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowClickListener", "", "Android.Gms.Maps.GoogleMap/IOnInfoWindowClickListenerInvoker")]
		public interface IOnInfoWindowClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onInfoWindowClick", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnInfoWindowClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnInfoWindowClick(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowClickListener", DoNotGenerateAcw = true)]
		internal class IOnInfoWindowClickListenerInvoker : Java.Lang.Object, IOnInfoWindowClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnInfoWindowClickListener", typeof(IOnInfoWindowClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IOnInfoWindowClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnInfoWindowClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnInfoWindowClickListener'.");
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

			public IOnInfoWindowClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnInfoWindowClickListener onInfoWindowClickListener = Java.Lang.Object.GetObject<IOnInfoWindowClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onInfoWindowClickListener.OnInfoWindowClick(marker);
			}

			public unsafe void OnInfoWindowClick(Marker marker)
			{
				if (id_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onInfoWindowClick", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}
		}

		public class InfoWindowClickEventArgs : EventArgs
		{
			private Marker marker;

			public InfoWindowClickEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowClickListenerImplementor")]
		internal sealed class IOnInfoWindowClickListenerImplementor : Java.Lang.Object, IOnInfoWindowClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<InfoWindowClickEventArgs> Handler;

			public IOnInfoWindowClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnInfoWindowClick(Marker marker)
			{
				Handler?.Invoke(sender, new InfoWindowClickEventArgs(marker));
			}

			internal static bool __IsEmpty(IOnInfoWindowClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowCloseListener", "", "Android.Gms.Maps.GoogleMap/IOnInfoWindowCloseListenerInvoker")]
		public interface IOnInfoWindowCloseListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onInfoWindowClose", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnInfoWindowCloseListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnInfoWindowClose(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowCloseListener", DoNotGenerateAcw = true)]
		internal class IOnInfoWindowCloseListenerInvoker : Java.Lang.Object, IOnInfoWindowCloseListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnInfoWindowCloseListener", typeof(IOnInfoWindowCloseListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IOnInfoWindowCloseListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnInfoWindowCloseListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnInfoWindowCloseListener'.");
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

			public IOnInfoWindowCloseListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnInfoWindowCloseListener onInfoWindowCloseListener = Java.Lang.Object.GetObject<IOnInfoWindowCloseListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onInfoWindowCloseListener.OnInfoWindowClose(marker);
			}

			public unsafe void OnInfoWindowClose(Marker marker)
			{
				if (id_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onInfoWindowClose", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onInfoWindowClose_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}
		}

		public class InfoWindowCloseEventArgs : EventArgs
		{
			private Marker marker;

			public InfoWindowCloseEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowCloseListenerImplementor")]
		internal sealed class IOnInfoWindowCloseListenerImplementor : Java.Lang.Object, IOnInfoWindowCloseListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<InfoWindowCloseEventArgs> Handler;

			public IOnInfoWindowCloseListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowCloseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnInfoWindowClose(Marker marker)
			{
				Handler?.Invoke(sender, new InfoWindowCloseEventArgs(marker));
			}

			internal static bool __IsEmpty(IOnInfoWindowCloseListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowLongClickListener", "", "Android.Gms.Maps.GoogleMap/IOnInfoWindowLongClickListenerInvoker")]
		public interface IOnInfoWindowLongClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onInfoWindowLongClick", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnInfoWindowLongClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnInfoWindowLongClick(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnInfoWindowLongClickListener", DoNotGenerateAcw = true)]
		internal class IOnInfoWindowLongClickListenerInvoker : Java.Lang.Object, IOnInfoWindowLongClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnInfoWindowLongClickListener", typeof(IOnInfoWindowLongClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IOnInfoWindowLongClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnInfoWindowLongClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnInfoWindowLongClickListener'.");
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

			public IOnInfoWindowLongClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnInfoWindowLongClickListener onInfoWindowLongClickListener = Java.Lang.Object.GetObject<IOnInfoWindowLongClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onInfoWindowLongClickListener.OnInfoWindowLongClick(marker);
			}

			public unsafe void OnInfoWindowLongClick(Marker marker)
			{
				if (id_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onInfoWindowLongClick", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onInfoWindowLongClick_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}
		}

		public class InfoWindowLongClickEventArgs : EventArgs
		{
			private Marker marker;

			public InfoWindowLongClickEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowLongClickListenerImplementor")]
		internal sealed class IOnInfoWindowLongClickListenerImplementor : Java.Lang.Object, IOnInfoWindowLongClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<InfoWindowLongClickEventArgs> Handler;

			public IOnInfoWindowLongClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnInfoWindowLongClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnInfoWindowLongClick(Marker marker)
			{
				Handler?.Invoke(sender, new InfoWindowLongClickEventArgs(marker));
			}

			internal static bool __IsEmpty(IOnInfoWindowLongClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapClickListener", "", "Android.Gms.Maps.GoogleMap/IOnMapClickListenerInvoker")]
		public interface IOnMapClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMapClick", "(Lcom/google/android/gms/maps/model/LatLng;)V", "GetOnMapClick_Lcom_google_android_gms_maps_model_LatLng_Handler:Android.Gms.Maps.GoogleMap/IOnMapClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMapClick(LatLng point);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapClickListener", DoNotGenerateAcw = true)]
		internal class IOnMapClickListenerInvoker : Java.Lang.Object, IOnMapClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMapClickListener", typeof(IOnMapClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMapClick_Lcom_google_android_gms_maps_model_LatLng_;

			private IntPtr id_onMapClick_Lcom_google_android_gms_maps_model_LatLng_;

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

			public static IOnMapClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMapClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMapClickListener'.");
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

			public IOnMapClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMapClick_Lcom_google_android_gms_maps_model_LatLng_Handler()
			{
				if ((object)cb_onMapClick_Lcom_google_android_gms_maps_model_LatLng_ == null)
				{
					cb_onMapClick_Lcom_google_android_gms_maps_model_LatLng_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapClick_Lcom_google_android_gms_maps_model_LatLng_));
				}
				return cb_onMapClick_Lcom_google_android_gms_maps_model_LatLng_;
			}

			private static void n_OnMapClick_Lcom_google_android_gms_maps_model_LatLng_(IntPtr jnienv, IntPtr native__this, IntPtr native_point)
			{
				IOnMapClickListener onMapClickListener = Java.Lang.Object.GetObject<IOnMapClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LatLng point = Java.Lang.Object.GetObject<LatLng>(native_point, JniHandleOwnership.DoNotTransfer);
				onMapClickListener.OnMapClick(point);
			}

			public unsafe void OnMapClick(LatLng point)
			{
				if (id_onMapClick_Lcom_google_android_gms_maps_model_LatLng_ == IntPtr.Zero)
				{
					id_onMapClick_Lcom_google_android_gms_maps_model_LatLng_ = JNIEnv.GetMethodID(class_ref, "onMapClick", "(Lcom/google/android/gms/maps/model/LatLng;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(point?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMapClick_Lcom_google_android_gms_maps_model_LatLng_, ptr);
			}
		}

		public class MapClickEventArgs : EventArgs
		{
			private LatLng point;

			public MapClickEventArgs(LatLng point)
			{
				this.point = point;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMapClickListenerImplementor")]
		internal sealed class IOnMapClickListenerImplementor : Java.Lang.Object, IOnMapClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MapClickEventArgs> Handler;

			public IOnMapClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMapClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMapClick(LatLng point)
			{
				Handler?.Invoke(sender, new MapClickEventArgs(point));
			}

			internal static bool __IsEmpty(IOnMapClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapLoadedCallback", "", "Android.Gms.Maps.GoogleMap/IOnMapLoadedCallbackInvoker")]
		public interface IOnMapLoadedCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMapLoaded", "()V", "GetOnMapLoadedHandler:Android.Gms.Maps.GoogleMap/IOnMapLoadedCallbackInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMapLoaded();
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapLoadedCallback", DoNotGenerateAcw = true)]
		internal class IOnMapLoadedCallbackInvoker : Java.Lang.Object, IOnMapLoadedCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMapLoadedCallback", typeof(IOnMapLoadedCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMapLoaded;

			private IntPtr id_onMapLoaded;

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

			public static IOnMapLoadedCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMapLoadedCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMapLoadedCallback'.");
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

			public IOnMapLoadedCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMapLoadedHandler()
			{
				if ((object)cb_onMapLoaded == null)
				{
					cb_onMapLoaded = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnMapLoaded));
				}
				return cb_onMapLoaded;
			}

			private static void n_OnMapLoaded(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IOnMapLoadedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMapLoaded();
			}

			public void OnMapLoaded()
			{
				if (id_onMapLoaded == IntPtr.Zero)
				{
					id_onMapLoaded = JNIEnv.GetMethodID(class_ref, "onMapLoaded", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_onMapLoaded);
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapLongClickListener", "", "Android.Gms.Maps.GoogleMap/IOnMapLongClickListenerInvoker")]
		public interface IOnMapLongClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMapLongClick", "(Lcom/google/android/gms/maps/model/LatLng;)V", "GetOnMapLongClick_Lcom_google_android_gms_maps_model_LatLng_Handler:Android.Gms.Maps.GoogleMap/IOnMapLongClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMapLongClick(LatLng point);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMapLongClickListener", DoNotGenerateAcw = true)]
		internal class IOnMapLongClickListenerInvoker : Java.Lang.Object, IOnMapLongClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMapLongClickListener", typeof(IOnMapLongClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_;

			private IntPtr id_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_;

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

			public static IOnMapLongClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMapLongClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMapLongClickListener'.");
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

			public IOnMapLongClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMapLongClick_Lcom_google_android_gms_maps_model_LatLng_Handler()
			{
				if ((object)cb_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_ == null)
				{
					cb_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapLongClick_Lcom_google_android_gms_maps_model_LatLng_));
				}
				return cb_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_;
			}

			private static void n_OnMapLongClick_Lcom_google_android_gms_maps_model_LatLng_(IntPtr jnienv, IntPtr native__this, IntPtr native_point)
			{
				IOnMapLongClickListener onMapLongClickListener = Java.Lang.Object.GetObject<IOnMapLongClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LatLng point = Java.Lang.Object.GetObject<LatLng>(native_point, JniHandleOwnership.DoNotTransfer);
				onMapLongClickListener.OnMapLongClick(point);
			}

			public unsafe void OnMapLongClick(LatLng point)
			{
				if (id_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_ == IntPtr.Zero)
				{
					id_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_ = JNIEnv.GetMethodID(class_ref, "onMapLongClick", "(Lcom/google/android/gms/maps/model/LatLng;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(point?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMapLongClick_Lcom_google_android_gms_maps_model_LatLng_, ptr);
			}
		}

		public class MapLongClickEventArgs : EventArgs
		{
			private LatLng point;

			public MapLongClickEventArgs(LatLng point)
			{
				this.point = point;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMapLongClickListenerImplementor")]
		internal sealed class IOnMapLongClickListenerImplementor : Java.Lang.Object, IOnMapLongClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MapLongClickEventArgs> Handler;

			public IOnMapLongClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMapLongClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMapLongClick(LatLng point)
			{
				Handler?.Invoke(sender, new MapLongClickEventArgs(point));
			}

			internal static bool __IsEmpty(IOnMapLongClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMarkerClickListener", "", "Android.Gms.Maps.GoogleMap/IOnMarkerClickListenerInvoker")]
		public interface IOnMarkerClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMarkerClick", "(Lcom/google/android/gms/maps/model/Marker;)Z", "GetOnMarkerClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			bool OnMarkerClick(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMarkerClickListener", DoNotGenerateAcw = true)]
		internal class IOnMarkerClickListenerInvoker : Java.Lang.Object, IOnMarkerClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMarkerClickListener", typeof(IOnMarkerClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IOnMarkerClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMarkerClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMarkerClickListener'.");
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

			public IOnMarkerClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMarkerClick_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnMarkerClick_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static bool n_OnMarkerClick_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnMarkerClickListener onMarkerClickListener = Java.Lang.Object.GetObject<IOnMarkerClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				return onMarkerClickListener.OnMarkerClick(marker);
			}

			public unsafe bool OnMarkerClick(Marker marker)
			{
				if (id_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onMarkerClick", "(Lcom/google/android/gms/maps/model/Marker;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_onMarkerClick_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}
		}

		public class MarkerClickEventArgs : EventArgs
		{
			private bool handled;

			private Marker marker;

			public bool Handled => handled;

			public MarkerClickEventArgs(bool handled, Marker marker)
			{
				this.handled = handled;
				this.marker = marker;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMarkerClickListenerImplementor")]
		internal sealed class IOnMarkerClickListenerImplementor : Java.Lang.Object, IOnMarkerClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MarkerClickEventArgs> Handler;

			public IOnMarkerClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMarkerClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public bool OnMarkerClick(Marker marker)
			{
				EventHandler<MarkerClickEventArgs> handler = Handler;
				if (handler == null)
				{
					return false;
				}
				MarkerClickEventArgs e = new MarkerClickEventArgs(handled: true, marker);
				handler(sender, e);
				return e.Handled;
			}

			internal static bool __IsEmpty(IOnMarkerClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMarkerDragListener", "", "Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker")]
		public interface IOnMarkerDragListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMarkerDrag", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnMarkerDrag_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMarkerDrag(Marker marker);

			[Register("onMarkerDragEnd", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMarkerDragEnd(Marker marker);

			[Register("onMarkerDragStart", "(Lcom/google/android/gms/maps/model/Marker;)V", "GetOnMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnMarkerDragListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMarkerDragStart(Marker marker);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMarkerDragListener", DoNotGenerateAcw = true)]
		internal class IOnMarkerDragListenerInvoker : Java.Lang.Object, IOnMarkerDragListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMarkerDragListener", typeof(IOnMarkerDragListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_;

			private static Delegate cb_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_;

			private static Delegate cb_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_;

			private IntPtr id_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_;

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

			public static IOnMarkerDragListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMarkerDragListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMarkerDragListener'.");
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

			public IOnMarkerDragListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMarkerDrag_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMarkerDrag_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnMarkerDrag_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnMarkerDragListener onMarkerDragListener = Java.Lang.Object.GetObject<IOnMarkerDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onMarkerDragListener.OnMarkerDrag(marker);
			}

			public unsafe void OnMarkerDrag(Marker marker)
			{
				if (id_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onMarkerDrag", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMarkerDrag_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}

			private static Delegate GetOnMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnMarkerDragListener onMarkerDragListener = Java.Lang.Object.GetObject<IOnMarkerDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onMarkerDragListener.OnMarkerDragEnd(marker);
			}

			public unsafe void OnMarkerDragEnd(Marker marker)
			{
				if (id_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onMarkerDragEnd", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMarkerDragEnd_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}

			private static Delegate GetOnMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_Handler()
			{
				if ((object)cb_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_ == null)
				{
					cb_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_));
				}
				return cb_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_;
			}

			private static void n_OnMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_(IntPtr jnienv, IntPtr native__this, IntPtr native_marker)
			{
				IOnMarkerDragListener onMarkerDragListener = Java.Lang.Object.GetObject<IOnMarkerDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Marker marker = Java.Lang.Object.GetObject<Marker>(native_marker, JniHandleOwnership.DoNotTransfer);
				onMarkerDragListener.OnMarkerDragStart(marker);
			}

			public unsafe void OnMarkerDragStart(Marker marker)
			{
				if (id_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_ == IntPtr.Zero)
				{
					id_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_ = JNIEnv.GetMethodID(class_ref, "onMarkerDragStart", "(Lcom/google/android/gms/maps/model/Marker;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(marker?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMarkerDragStart_Lcom_google_android_gms_maps_model_Marker_, ptr);
			}
		}

		public class MarkerDragEventArgs : EventArgs
		{
			private Marker marker;

			public MarkerDragEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		public class MarkerDragEndEventArgs : EventArgs
		{
			private Marker marker;

			public MarkerDragEndEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		public class MarkerDragStartEventArgs : EventArgs
		{
			private Marker marker;

			public MarkerDragStartEventArgs(Marker marker)
			{
				this.marker = marker;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMarkerDragListenerImplementor")]
		internal sealed class IOnMarkerDragListenerImplementor : Java.Lang.Object, IOnMarkerDragListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MarkerDragEventArgs> OnMarkerDragHandler;

			public EventHandler<MarkerDragEndEventArgs> OnMarkerDragEndHandler;

			public EventHandler<MarkerDragStartEventArgs> OnMarkerDragStartHandler;

			public IOnMarkerDragListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMarkerDragListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMarkerDrag(Marker marker)
			{
				OnMarkerDragHandler?.Invoke(sender, new MarkerDragEventArgs(marker));
			}

			public void OnMarkerDragEnd(Marker marker)
			{
				OnMarkerDragEndHandler?.Invoke(sender, new MarkerDragEndEventArgs(marker));
			}

			public void OnMarkerDragStart(Marker marker)
			{
				OnMarkerDragStartHandler?.Invoke(sender, new MarkerDragStartEventArgs(marker));
			}

			internal static bool __IsEmpty(IOnMarkerDragListenerImplementor value)
			{
				if (value.OnMarkerDragHandler == null && value.OnMarkerDragEndHandler == null)
				{
					return value.OnMarkerDragStartHandler == null;
				}
				return false;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationButtonClickListener", "", "Android.Gms.Maps.GoogleMap/IOnMyLocationButtonClickListenerInvoker")]
		public interface IOnMyLocationButtonClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMyLocationButtonClick", "()Z", "GetOnMyLocationButtonClickHandler:Android.Gms.Maps.GoogleMap/IOnMyLocationButtonClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			bool OnMyLocationButtonClick();
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationButtonClickListener", DoNotGenerateAcw = true)]
		internal class IOnMyLocationButtonClickListenerInvoker : Java.Lang.Object, IOnMyLocationButtonClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMyLocationButtonClickListener", typeof(IOnMyLocationButtonClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMyLocationButtonClick;

			private IntPtr id_onMyLocationButtonClick;

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

			public static IOnMyLocationButtonClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMyLocationButtonClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMyLocationButtonClickListener'.");
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

			public IOnMyLocationButtonClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMyLocationButtonClickHandler()
			{
				if ((object)cb_onMyLocationButtonClick == null)
				{
					cb_onMyLocationButtonClick = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_OnMyLocationButtonClick));
				}
				return cb_onMyLocationButtonClick;
			}

			private static bool n_OnMyLocationButtonClick(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IOnMyLocationButtonClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMyLocationButtonClick();
			}

			public bool OnMyLocationButtonClick()
			{
				if (id_onMyLocationButtonClick == IntPtr.Zero)
				{
					id_onMyLocationButtonClick = JNIEnv.GetMethodID(class_ref, "onMyLocationButtonClick", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_onMyLocationButtonClick);
			}
		}

		public class MyLocationButtonClickEventArgs : EventArgs
		{
			private bool handled;

			public bool Handled => handled;

			public MyLocationButtonClickEventArgs(bool handled)
			{
				this.handled = handled;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationButtonClickListenerImplementor")]
		internal sealed class IOnMyLocationButtonClickListenerImplementor : Java.Lang.Object, IOnMyLocationButtonClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MyLocationButtonClickEventArgs> Handler;

			public IOnMyLocationButtonClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationButtonClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public bool OnMyLocationButtonClick()
			{
				EventHandler<MyLocationButtonClickEventArgs> handler = Handler;
				if (handler == null)
				{
					return false;
				}
				MyLocationButtonClickEventArgs e = new MyLocationButtonClickEventArgs(handled: true);
				handler(sender, e);
				return e.Handled;
			}

			internal static bool __IsEmpty(IOnMyLocationButtonClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationChangeListener", "", "Android.Gms.Maps.GoogleMap/IOnMyLocationChangeListenerInvoker")]
		public interface IOnMyLocationChangeListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMyLocationChange", "(Landroid/location/Location;)V", "GetOnMyLocationChange_Landroid_location_Location_Handler:Android.Gms.Maps.GoogleMap/IOnMyLocationChangeListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMyLocationChange(Location location);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationChangeListener", DoNotGenerateAcw = true)]
		internal class IOnMyLocationChangeListenerInvoker : Java.Lang.Object, IOnMyLocationChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMyLocationChangeListener", typeof(IOnMyLocationChangeListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMyLocationChange_Landroid_location_Location_;

			private IntPtr id_onMyLocationChange_Landroid_location_Location_;

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

			public static IOnMyLocationChangeListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMyLocationChangeListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMyLocationChangeListener'.");
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

			public IOnMyLocationChangeListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMyLocationChange_Landroid_location_Location_Handler()
			{
				if ((object)cb_onMyLocationChange_Landroid_location_Location_ == null)
				{
					cb_onMyLocationChange_Landroid_location_Location_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMyLocationChange_Landroid_location_Location_));
				}
				return cb_onMyLocationChange_Landroid_location_Location_;
			}

			private static void n_OnMyLocationChange_Landroid_location_Location_(IntPtr jnienv, IntPtr native__this, IntPtr native_location)
			{
				IOnMyLocationChangeListener onMyLocationChangeListener = Java.Lang.Object.GetObject<IOnMyLocationChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Location location = Java.Lang.Object.GetObject<Location>(native_location, JniHandleOwnership.DoNotTransfer);
				onMyLocationChangeListener.OnMyLocationChange(location);
			}

			public unsafe void OnMyLocationChange(Location location)
			{
				if (id_onMyLocationChange_Landroid_location_Location_ == IntPtr.Zero)
				{
					id_onMyLocationChange_Landroid_location_Location_ = JNIEnv.GetMethodID(class_ref, "onMyLocationChange", "(Landroid/location/Location;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(location?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMyLocationChange_Landroid_location_Location_, ptr);
			}
		}

		public class MyLocationChangeEventArgs : EventArgs
		{
			private Location location;

			public MyLocationChangeEventArgs(Location location)
			{
				this.location = location;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationChangeListenerImplementor")]
		internal sealed class IOnMyLocationChangeListenerImplementor : Java.Lang.Object, IOnMyLocationChangeListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MyLocationChangeEventArgs> Handler;

			public IOnMyLocationChangeListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationChangeListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMyLocationChange(Location location)
			{
				Handler?.Invoke(sender, new MyLocationChangeEventArgs(location));
			}

			internal static bool __IsEmpty(IOnMyLocationChangeListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationClickListener", "", "Android.Gms.Maps.GoogleMap/IOnMyLocationClickListenerInvoker")]
		public interface IOnMyLocationClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onMyLocationClick", "(Landroid/location/Location;)V", "GetOnMyLocationClick_Landroid_location_Location_Handler:Android.Gms.Maps.GoogleMap/IOnMyLocationClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnMyLocationClick(Location location);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnMyLocationClickListener", DoNotGenerateAcw = true)]
		internal class IOnMyLocationClickListenerInvoker : Java.Lang.Object, IOnMyLocationClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnMyLocationClickListener", typeof(IOnMyLocationClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onMyLocationClick_Landroid_location_Location_;

			private IntPtr id_onMyLocationClick_Landroid_location_Location_;

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

			public static IOnMyLocationClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMyLocationClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnMyLocationClickListener'.");
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

			public IOnMyLocationClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnMyLocationClick_Landroid_location_Location_Handler()
			{
				if ((object)cb_onMyLocationClick_Landroid_location_Location_ == null)
				{
					cb_onMyLocationClick_Landroid_location_Location_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMyLocationClick_Landroid_location_Location_));
				}
				return cb_onMyLocationClick_Landroid_location_Location_;
			}

			private static void n_OnMyLocationClick_Landroid_location_Location_(IntPtr jnienv, IntPtr native__this, IntPtr native_location)
			{
				IOnMyLocationClickListener onMyLocationClickListener = Java.Lang.Object.GetObject<IOnMyLocationClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Location location = Java.Lang.Object.GetObject<Location>(native_location, JniHandleOwnership.DoNotTransfer);
				onMyLocationClickListener.OnMyLocationClick(location);
			}

			public unsafe void OnMyLocationClick(Location location)
			{
				if (id_onMyLocationClick_Landroid_location_Location_ == IntPtr.Zero)
				{
					id_onMyLocationClick_Landroid_location_Location_ = JNIEnv.GetMethodID(class_ref, "onMyLocationClick", "(Landroid/location/Location;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(location?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onMyLocationClick_Landroid_location_Location_, ptr);
			}
		}

		public class MyLocationClickEventArgs : EventArgs
		{
			private Location location;

			public MyLocationClickEventArgs(Location location)
			{
				this.location = location;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationClickListenerImplementor")]
		internal sealed class IOnMyLocationClickListenerImplementor : Java.Lang.Object, IOnMyLocationClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<MyLocationClickEventArgs> Handler;

			public IOnMyLocationClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnMyLocationClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMyLocationClick(Location location)
			{
				Handler?.Invoke(sender, new MyLocationClickEventArgs(location));
			}

			internal static bool __IsEmpty(IOnMyLocationClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPoiClickListener", "", "Android.Gms.Maps.GoogleMap/IOnPoiClickListenerInvoker")]
		public interface IOnPoiClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPoiClick", "(Lcom/google/android/gms/maps/model/PointOfInterest;)V", "GetOnPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_Handler:Android.Gms.Maps.GoogleMap/IOnPoiClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnPoiClick(PointOfInterest poi);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPoiClickListener", DoNotGenerateAcw = true)]
		internal class IOnPoiClickListenerInvoker : Java.Lang.Object, IOnPoiClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnPoiClickListener", typeof(IOnPoiClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_;

			private IntPtr id_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_;

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

			public static IOnPoiClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnPoiClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnPoiClickListener'.");
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

			public IOnPoiClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_Handler()
			{
				if ((object)cb_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_ == null)
				{
					cb_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_));
				}
				return cb_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_;
			}

			private static void n_OnPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_(IntPtr jnienv, IntPtr native__this, IntPtr native_poi)
			{
				IOnPoiClickListener onPoiClickListener = Java.Lang.Object.GetObject<IOnPoiClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				PointOfInterest poi = Java.Lang.Object.GetObject<PointOfInterest>(native_poi, JniHandleOwnership.DoNotTransfer);
				onPoiClickListener.OnPoiClick(poi);
			}

			public unsafe void OnPoiClick(PointOfInterest poi)
			{
				if (id_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_ == IntPtr.Zero)
				{
					id_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_ = JNIEnv.GetMethodID(class_ref, "onPoiClick", "(Lcom/google/android/gms/maps/model/PointOfInterest;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(poi?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPoiClick_Lcom_google_android_gms_maps_model_PointOfInterest_, ptr);
			}
		}

		public class PoiClickEventArgs : EventArgs
		{
			private PointOfInterest poi;

			public PoiClickEventArgs(PointOfInterest poi)
			{
				this.poi = poi;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnPoiClickListenerImplementor")]
		internal sealed class IOnPoiClickListenerImplementor : Java.Lang.Object, IOnPoiClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<PoiClickEventArgs> Handler;

			public IOnPoiClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnPoiClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPoiClick(PointOfInterest poi)
			{
				Handler?.Invoke(sender, new PoiClickEventArgs(poi));
			}

			internal static bool __IsEmpty(IOnPoiClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPolygonClickListener", "", "Android.Gms.Maps.GoogleMap/IOnPolygonClickListenerInvoker")]
		public interface IOnPolygonClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPolygonClick", "(Lcom/google/android/gms/maps/model/Polygon;)V", "GetOnPolygonClick_Lcom_google_android_gms_maps_model_Polygon_Handler:Android.Gms.Maps.GoogleMap/IOnPolygonClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnPolygonClick(Polygon polygon);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPolygonClickListener", DoNotGenerateAcw = true)]
		internal class IOnPolygonClickListenerInvoker : Java.Lang.Object, IOnPolygonClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnPolygonClickListener", typeof(IOnPolygonClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_;

			private IntPtr id_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_;

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

			public static IOnPolygonClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnPolygonClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnPolygonClickListener'.");
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

			public IOnPolygonClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPolygonClick_Lcom_google_android_gms_maps_model_Polygon_Handler()
			{
				if ((object)cb_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_ == null)
				{
					cb_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPolygonClick_Lcom_google_android_gms_maps_model_Polygon_));
				}
				return cb_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_;
			}

			private static void n_OnPolygonClick_Lcom_google_android_gms_maps_model_Polygon_(IntPtr jnienv, IntPtr native__this, IntPtr native_polygon)
			{
				IOnPolygonClickListener onPolygonClickListener = Java.Lang.Object.GetObject<IOnPolygonClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Polygon polygon = Java.Lang.Object.GetObject<Polygon>(native_polygon, JniHandleOwnership.DoNotTransfer);
				onPolygonClickListener.OnPolygonClick(polygon);
			}

			public unsafe void OnPolygonClick(Polygon polygon)
			{
				if (id_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_ == IntPtr.Zero)
				{
					id_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_ = JNIEnv.GetMethodID(class_ref, "onPolygonClick", "(Lcom/google/android/gms/maps/model/Polygon;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(polygon?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPolygonClick_Lcom_google_android_gms_maps_model_Polygon_, ptr);
			}
		}

		public class PolygonClickEventArgs : EventArgs
		{
			private Polygon polygon;

			public PolygonClickEventArgs(Polygon polygon)
			{
				this.polygon = polygon;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnPolygonClickListenerImplementor")]
		internal sealed class IOnPolygonClickListenerImplementor : Java.Lang.Object, IOnPolygonClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<PolygonClickEventArgs> Handler;

			public IOnPolygonClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnPolygonClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPolygonClick(Polygon polygon)
			{
				Handler?.Invoke(sender, new PolygonClickEventArgs(polygon));
			}

			internal static bool __IsEmpty(IOnPolygonClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPolylineClickListener", "", "Android.Gms.Maps.GoogleMap/IOnPolylineClickListenerInvoker")]
		public interface IOnPolylineClickListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPolylineClick", "(Lcom/google/android/gms/maps/model/Polyline;)V", "GetOnPolylineClick_Lcom_google_android_gms_maps_model_Polyline_Handler:Android.Gms.Maps.GoogleMap/IOnPolylineClickListenerInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnPolylineClick(Polyline polyline);
		}

		[Register("com/google/android/gms/maps/GoogleMap$OnPolylineClickListener", DoNotGenerateAcw = true)]
		internal class IOnPolylineClickListenerInvoker : Java.Lang.Object, IOnPolylineClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$OnPolylineClickListener", typeof(IOnPolylineClickListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_;

			private IntPtr id_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_;

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

			public static IOnPolylineClickListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnPolylineClickListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.OnPolylineClickListener'.");
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

			public IOnPolylineClickListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPolylineClick_Lcom_google_android_gms_maps_model_Polyline_Handler()
			{
				if ((object)cb_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_ == null)
				{
					cb_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPolylineClick_Lcom_google_android_gms_maps_model_Polyline_));
				}
				return cb_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_;
			}

			private static void n_OnPolylineClick_Lcom_google_android_gms_maps_model_Polyline_(IntPtr jnienv, IntPtr native__this, IntPtr native_polyline)
			{
				IOnPolylineClickListener onPolylineClickListener = Java.Lang.Object.GetObject<IOnPolylineClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Polyline polyline = Java.Lang.Object.GetObject<Polyline>(native_polyline, JniHandleOwnership.DoNotTransfer);
				onPolylineClickListener.OnPolylineClick(polyline);
			}

			public unsafe void OnPolylineClick(Polyline polyline)
			{
				if (id_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_ == IntPtr.Zero)
				{
					id_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_ = JNIEnv.GetMethodID(class_ref, "onPolylineClick", "(Lcom/google/android/gms/maps/model/Polyline;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(polyline?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPolylineClick_Lcom_google_android_gms_maps_model_Polyline_, ptr);
			}
		}

		public class PolylineClickEventArgs : EventArgs
		{
			private Polyline polyline;

			public PolylineClickEventArgs(Polyline polyline)
			{
				this.polyline = polyline;
			}
		}

		[Register("mono/com/google/android/gms/maps/GoogleMap_OnPolylineClickListenerImplementor")]
		internal sealed class IOnPolylineClickListenerImplementor : Java.Lang.Object, IOnPolylineClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<PolylineClickEventArgs> Handler;

			public IOnPolylineClickListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/gms/maps/GoogleMap_OnPolylineClickListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPolylineClick(Polyline polyline)
			{
				Handler?.Invoke(sender, new PolylineClickEventArgs(polyline));
			}

			internal static bool __IsEmpty(IOnPolylineClickListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		[Register("com/google/android/gms/maps/GoogleMap$SnapshotReadyCallback", "", "Android.Gms.Maps.GoogleMap/ISnapshotReadyCallbackInvoker")]
		public interface ISnapshotReadyCallback : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onSnapshotReady", "(Landroid/graphics/Bitmap;)V", "GetOnSnapshotReady_Landroid_graphics_Bitmap_Handler:Android.Gms.Maps.GoogleMap/ISnapshotReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps")]
			void OnSnapshotReady(Bitmap snapshot);
		}

		[Register("com/google/android/gms/maps/GoogleMap$SnapshotReadyCallback", DoNotGenerateAcw = true)]
		internal class ISnapshotReadyCallbackInvoker : Java.Lang.Object, ISnapshotReadyCallback, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap$SnapshotReadyCallback", typeof(ISnapshotReadyCallbackInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onSnapshotReady_Landroid_graphics_Bitmap_;

			private IntPtr id_onSnapshotReady_Landroid_graphics_Bitmap_;

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

			public static ISnapshotReadyCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<ISnapshotReadyCallback>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.GoogleMap.SnapshotReadyCallback'.");
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

			public ISnapshotReadyCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnSnapshotReady_Landroid_graphics_Bitmap_Handler()
			{
				if ((object)cb_onSnapshotReady_Landroid_graphics_Bitmap_ == null)
				{
					cb_onSnapshotReady_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSnapshotReady_Landroid_graphics_Bitmap_));
				}
				return cb_onSnapshotReady_Landroid_graphics_Bitmap_;
			}

			private static void n_OnSnapshotReady_Landroid_graphics_Bitmap_(IntPtr jnienv, IntPtr native__this, IntPtr native_snapshot)
			{
				ISnapshotReadyCallback snapshotReadyCallback = Java.Lang.Object.GetObject<ISnapshotReadyCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Bitmap snapshot = Java.Lang.Object.GetObject<Bitmap>(native_snapshot, JniHandleOwnership.DoNotTransfer);
				snapshotReadyCallback.OnSnapshotReady(snapshot);
			}

			public unsafe void OnSnapshotReady(Bitmap snapshot)
			{
				if (id_onSnapshotReady_Landroid_graphics_Bitmap_ == IntPtr.Zero)
				{
					id_onSnapshotReady_Landroid_graphics_Bitmap_ = JNIEnv.GetMethodID(class_ref, "onSnapshotReady", "(Landroid/graphics/Bitmap;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(snapshot?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onSnapshotReady_Landroid_graphics_Bitmap_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMap", typeof(GoogleMap));

		private static Delegate cb_getFocusedBuilding;

		private static Delegate cb_resetMinMaxZoomPreference;

		private static Delegate cb_setLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_;

		private static Delegate cb_setMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_;

		private static Delegate cb_setMaxZoomPreference_F;

		private static Delegate cb_setMinZoomPreference_F;

		private static Delegate cb_setOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_;

		private WeakReference weak_implementor_SetOnCameraChangeListener;

		private WeakReference weak_implementor_SetOnCameraIdleListener;

		private WeakReference weak_implementor_SetOnCameraMoveCanceledListener;

		private WeakReference weak_implementor_SetOnCameraMoveListener;

		private WeakReference weak_implementor_SetOnCameraMoveStartedListener;

		private WeakReference weak_implementor_SetOnCircleClickListener;

		private WeakReference weak_implementor_SetOnGroundOverlayClickListener;

		private WeakReference weak_implementor_SetOnIndoorStateChangeListener;

		private WeakReference weak_implementor_SetOnInfoWindowClickListener;

		private WeakReference weak_implementor_SetOnInfoWindowCloseListener;

		private WeakReference weak_implementor_SetOnInfoWindowLongClickListener;

		private WeakReference weak_implementor_SetOnMapClickListener;

		private WeakReference weak_implementor_SetOnMapLongClickListener;

		private WeakReference weak_implementor_SetOnMarkerClickListener;

		private WeakReference weak_implementor_SetOnMarkerDragListener;

		private WeakReference weak_implementor_SetOnMyLocationButtonClickListener;

		private WeakReference weak_implementor_SetOnMyLocationChangeListener;

		private WeakReference weak_implementor_SetOnMyLocationClickListener;

		private WeakReference weak_implementor_SetOnPoiClickListener;

		private WeakReference weak_implementor_SetOnPolygonClickListener;

		private WeakReference weak_implementor_SetOnPolylineClickListener;

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

		public unsafe bool BuildingsEnabled
		{
			[Register("isBuildingsEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isBuildingsEnabled.()Z", this, null);
			}
			[Register("setBuildingsEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setBuildingsEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe CameraPosition CameraPosition
		{
			[Register("getCameraPosition", "()Lcom/google/android/gms/maps/model/CameraPosition;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CameraPosition>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCameraPosition.()Lcom/google/android/gms/maps/model/CameraPosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IndoorBuilding FocusedBuilding
		{
			[Register("getFocusedBuilding", "()Lcom/google/android/gms/maps/model/IndoorBuilding;", "GetGetFocusedBuildingHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IndoorBuilding>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFocusedBuilding.()Lcom/google/android/gms/maps/model/IndoorBuilding;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsIndoorEnabled
		{
			[Register("isIndoorEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isIndoorEnabled.()Z", this, null);
			}
		}

		public unsafe int MapType
		{
			[Register("getMapType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMapType.()I", this, null);
			}
			[Register("setMapType", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMapType.(I)V", this, ptr);
			}
		}

		public unsafe float MaxZoomLevel
		{
			[Register("getMaxZoomLevel", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getMaxZoomLevel.()F", this, null);
			}
		}

		public unsafe float MinZoomLevel
		{
			[Register("getMinZoomLevel", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getMinZoomLevel.()F", this, null);
			}
		}

		public unsafe Location MyLocation
		{
			[Register("getMyLocation", "()Landroid/location/Location;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Location>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getMyLocation.()Landroid/location/Location;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool MyLocationEnabled
		{
			[Register("isMyLocationEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isMyLocationEnabled.()Z", this, null);
			}
			[Register("setMyLocationEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMyLocationEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe Projection Projection
		{
			[Register("getProjection", "()Lcom/google/android/gms/maps/Projection;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Projection>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getProjection.()Lcom/google/android/gms/maps/Projection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool TrafficEnabled
		{
			[Register("isTrafficEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isTrafficEnabled.()Z", this, null);
			}
			[Register("setTrafficEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTrafficEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe UiSettings UiSettings
		{
			[Register("getUiSettings", "()Lcom/google/android/gms/maps/UiSettings;", "")]
			get
			{
				return Java.Lang.Object.GetObject<UiSettings>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getUiSettings.()Lcom/google/android/gms/maps/UiSettings;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public event EventHandler<CameraChangeEventArgs> CameraChange
		{
			add
			{
				EventHelper.AddEventHandler<IOnCameraChangeListener, IOnCameraChangeListenerImplementor>(ref weak_implementor_SetOnCameraChangeListener, __CreateIOnCameraChangeListenerImplementor, SetOnCameraChangeListener, delegate(IOnCameraChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CameraChangeEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCameraChangeListener, IOnCameraChangeListenerImplementor>(ref weak_implementor_SetOnCameraChangeListener, IOnCameraChangeListenerImplementor.__IsEmpty, delegate
				{
					SetOnCameraChangeListener(null);
				}, delegate(IOnCameraChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CameraChangeEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler CameraIdle
		{
			add
			{
				EventHelper.AddEventHandler<IOnCameraIdleListener, IOnCameraIdleListenerImplementor>(ref weak_implementor_SetOnCameraIdleListener, __CreateIOnCameraIdleListenerImplementor, SetOnCameraIdleListener, delegate(IOnCameraIdleListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCameraIdleListener, IOnCameraIdleListenerImplementor>(ref weak_implementor_SetOnCameraIdleListener, IOnCameraIdleListenerImplementor.__IsEmpty, delegate
				{
					SetOnCameraIdleListener(null);
				}, delegate(IOnCameraIdleListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler CameraMoveCanceled
		{
			add
			{
				EventHelper.AddEventHandler<IOnCameraMoveCanceledListener, IOnCameraMoveCanceledListenerImplementor>(ref weak_implementor_SetOnCameraMoveCanceledListener, __CreateIOnCameraMoveCanceledListenerImplementor, SetOnCameraMoveCanceledListener, delegate(IOnCameraMoveCanceledListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCameraMoveCanceledListener, IOnCameraMoveCanceledListenerImplementor>(ref weak_implementor_SetOnCameraMoveCanceledListener, IOnCameraMoveCanceledListenerImplementor.__IsEmpty, delegate
				{
					SetOnCameraMoveCanceledListener(null);
				}, delegate(IOnCameraMoveCanceledListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler CameraMove
		{
			add
			{
				EventHelper.AddEventHandler<IOnCameraMoveListener, IOnCameraMoveListenerImplementor>(ref weak_implementor_SetOnCameraMoveListener, __CreateIOnCameraMoveListenerImplementor, SetOnCameraMoveListener, delegate(IOnCameraMoveListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCameraMoveListener, IOnCameraMoveListenerImplementor>(ref weak_implementor_SetOnCameraMoveListener, IOnCameraMoveListenerImplementor.__IsEmpty, delegate
				{
					SetOnCameraMoveListener(null);
				}, delegate(IOnCameraMoveListenerImplementor __h)
				{
					__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<CameraMoveStartedEventArgs> CameraMoveStarted
		{
			add
			{
				EventHelper.AddEventHandler<IOnCameraMoveStartedListener, IOnCameraMoveStartedListenerImplementor>(ref weak_implementor_SetOnCameraMoveStartedListener, __CreateIOnCameraMoveStartedListenerImplementor, SetOnCameraMoveStartedListener, delegate(IOnCameraMoveStartedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CameraMoveStartedEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCameraMoveStartedListener, IOnCameraMoveStartedListenerImplementor>(ref weak_implementor_SetOnCameraMoveStartedListener, IOnCameraMoveStartedListenerImplementor.__IsEmpty, delegate
				{
					SetOnCameraMoveStartedListener(null);
				}, delegate(IOnCameraMoveStartedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CameraMoveStartedEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<CircleClickEventArgs> CircleClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnCircleClickListener, IOnCircleClickListenerImplementor>(ref weak_implementor_SetOnCircleClickListener, __CreateIOnCircleClickListenerImplementor, SetOnCircleClickListener, delegate(IOnCircleClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CircleClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnCircleClickListener, IOnCircleClickListenerImplementor>(ref weak_implementor_SetOnCircleClickListener, IOnCircleClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnCircleClickListener(null);
				}, delegate(IOnCircleClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<CircleClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<GroundOverlayClickEventArgs> GroundOverlayClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnGroundOverlayClickListener, IOnGroundOverlayClickListenerImplementor>(ref weak_implementor_SetOnGroundOverlayClickListener, __CreateIOnGroundOverlayClickListenerImplementor, SetOnGroundOverlayClickListener, delegate(IOnGroundOverlayClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<GroundOverlayClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnGroundOverlayClickListener, IOnGroundOverlayClickListenerImplementor>(ref weak_implementor_SetOnGroundOverlayClickListener, IOnGroundOverlayClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnGroundOverlayClickListener(null);
				}, delegate(IOnGroundOverlayClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<GroundOverlayClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler IndoorBuildingFocused
		{
			add
			{
				EventHelper.AddEventHandler<IOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor>(ref weak_implementor_SetOnIndoorStateChangeListener, __CreateIOnIndoorStateChangeListenerImplementor, SetOnIndoorStateChangeListener, delegate(IOnIndoorStateChangeListenerImplementor __h)
				{
					__h.OnIndoorBuildingFocusedHandler = (EventHandler)Delegate.Combine(__h.OnIndoorBuildingFocusedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor>(ref weak_implementor_SetOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor.__IsEmpty, delegate
				{
					SetOnIndoorStateChangeListener(null);
				}, delegate(IOnIndoorStateChangeListenerImplementor __h)
				{
					__h.OnIndoorBuildingFocusedHandler = (EventHandler)Delegate.Remove(__h.OnIndoorBuildingFocusedHandler, value);
				});
			}
		}

		public event EventHandler<IndoorLevelActivatedEventArgs> IndoorLevelActivated
		{
			add
			{
				EventHelper.AddEventHandler<IOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor>(ref weak_implementor_SetOnIndoorStateChangeListener, __CreateIOnIndoorStateChangeListenerImplementor, SetOnIndoorStateChangeListener, delegate(IOnIndoorStateChangeListenerImplementor __h)
				{
					__h.OnIndoorLevelActivatedHandler = (EventHandler<IndoorLevelActivatedEventArgs>)Delegate.Combine(__h.OnIndoorLevelActivatedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor>(ref weak_implementor_SetOnIndoorStateChangeListener, IOnIndoorStateChangeListenerImplementor.__IsEmpty, delegate
				{
					SetOnIndoorStateChangeListener(null);
				}, delegate(IOnIndoorStateChangeListenerImplementor __h)
				{
					__h.OnIndoorLevelActivatedHandler = (EventHandler<IndoorLevelActivatedEventArgs>)Delegate.Remove(__h.OnIndoorLevelActivatedHandler, value);
				});
			}
		}

		public event EventHandler<InfoWindowClickEventArgs> InfoWindowClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnInfoWindowClickListener, IOnInfoWindowClickListenerImplementor>(ref weak_implementor_SetOnInfoWindowClickListener, __CreateIOnInfoWindowClickListenerImplementor, SetOnInfoWindowClickListener, delegate(IOnInfoWindowClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnInfoWindowClickListener, IOnInfoWindowClickListenerImplementor>(ref weak_implementor_SetOnInfoWindowClickListener, IOnInfoWindowClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnInfoWindowClickListener(null);
				}, delegate(IOnInfoWindowClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<InfoWindowCloseEventArgs> InfoWindowClose
		{
			add
			{
				EventHelper.AddEventHandler<IOnInfoWindowCloseListener, IOnInfoWindowCloseListenerImplementor>(ref weak_implementor_SetOnInfoWindowCloseListener, __CreateIOnInfoWindowCloseListenerImplementor, SetOnInfoWindowCloseListener, delegate(IOnInfoWindowCloseListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowCloseEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnInfoWindowCloseListener, IOnInfoWindowCloseListenerImplementor>(ref weak_implementor_SetOnInfoWindowCloseListener, IOnInfoWindowCloseListenerImplementor.__IsEmpty, delegate
				{
					SetOnInfoWindowCloseListener(null);
				}, delegate(IOnInfoWindowCloseListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowCloseEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<InfoWindowLongClickEventArgs> InfoWindowLongClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnInfoWindowLongClickListener, IOnInfoWindowLongClickListenerImplementor>(ref weak_implementor_SetOnInfoWindowLongClickListener, __CreateIOnInfoWindowLongClickListenerImplementor, SetOnInfoWindowLongClickListener, delegate(IOnInfoWindowLongClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowLongClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnInfoWindowLongClickListener, IOnInfoWindowLongClickListenerImplementor>(ref weak_implementor_SetOnInfoWindowLongClickListener, IOnInfoWindowLongClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnInfoWindowLongClickListener(null);
				}, delegate(IOnInfoWindowLongClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<InfoWindowLongClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MapClickEventArgs> MapClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnMapClickListener, IOnMapClickListenerImplementor>(ref weak_implementor_SetOnMapClickListener, __CreateIOnMapClickListenerImplementor, SetOnMapClickListener, delegate(IOnMapClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MapClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMapClickListener, IOnMapClickListenerImplementor>(ref weak_implementor_SetOnMapClickListener, IOnMapClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnMapClickListener(null);
				}, delegate(IOnMapClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MapClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MapLongClickEventArgs> MapLongClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnMapLongClickListener, IOnMapLongClickListenerImplementor>(ref weak_implementor_SetOnMapLongClickListener, __CreateIOnMapLongClickListenerImplementor, SetOnMapLongClickListener, delegate(IOnMapLongClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MapLongClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMapLongClickListener, IOnMapLongClickListenerImplementor>(ref weak_implementor_SetOnMapLongClickListener, IOnMapLongClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnMapLongClickListener(null);
				}, delegate(IOnMapLongClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MapLongClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MarkerClickEventArgs> MarkerClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnMarkerClickListener, IOnMarkerClickListenerImplementor>(ref weak_implementor_SetOnMarkerClickListener, __CreateIOnMarkerClickListenerImplementor, SetOnMarkerClickListener, delegate(IOnMarkerClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MarkerClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMarkerClickListener, IOnMarkerClickListenerImplementor>(ref weak_implementor_SetOnMarkerClickListener, IOnMarkerClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnMarkerClickListener(null);
				}, delegate(IOnMarkerClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MarkerClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MarkerDragEventArgs> MarkerDrag
		{
			add
			{
				EventHelper.AddEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, __CreateIOnMarkerDragListenerImplementor, SetOnMarkerDragListener, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragHandler = (EventHandler<MarkerDragEventArgs>)Delegate.Combine(__h.OnMarkerDragHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, IOnMarkerDragListenerImplementor.__IsEmpty, delegate
				{
					SetOnMarkerDragListener(null);
				}, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragHandler = (EventHandler<MarkerDragEventArgs>)Delegate.Remove(__h.OnMarkerDragHandler, value);
				});
			}
		}

		public event EventHandler<MarkerDragEndEventArgs> MarkerDragEnd
		{
			add
			{
				EventHelper.AddEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, __CreateIOnMarkerDragListenerImplementor, SetOnMarkerDragListener, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragEndHandler = (EventHandler<MarkerDragEndEventArgs>)Delegate.Combine(__h.OnMarkerDragEndHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, IOnMarkerDragListenerImplementor.__IsEmpty, delegate
				{
					SetOnMarkerDragListener(null);
				}, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragEndHandler = (EventHandler<MarkerDragEndEventArgs>)Delegate.Remove(__h.OnMarkerDragEndHandler, value);
				});
			}
		}

		public event EventHandler<MarkerDragStartEventArgs> MarkerDragStart
		{
			add
			{
				EventHelper.AddEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, __CreateIOnMarkerDragListenerImplementor, SetOnMarkerDragListener, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragStartHandler = (EventHandler<MarkerDragStartEventArgs>)Delegate.Combine(__h.OnMarkerDragStartHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMarkerDragListener, IOnMarkerDragListenerImplementor>(ref weak_implementor_SetOnMarkerDragListener, IOnMarkerDragListenerImplementor.__IsEmpty, delegate
				{
					SetOnMarkerDragListener(null);
				}, delegate(IOnMarkerDragListenerImplementor __h)
				{
					__h.OnMarkerDragStartHandler = (EventHandler<MarkerDragStartEventArgs>)Delegate.Remove(__h.OnMarkerDragStartHandler, value);
				});
			}
		}

		public event EventHandler<MyLocationButtonClickEventArgs> MyLocationButtonClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnMyLocationButtonClickListener, IOnMyLocationButtonClickListenerImplementor>(ref weak_implementor_SetOnMyLocationButtonClickListener, __CreateIOnMyLocationButtonClickListenerImplementor, SetOnMyLocationButtonClickListener, delegate(IOnMyLocationButtonClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationButtonClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMyLocationButtonClickListener, IOnMyLocationButtonClickListenerImplementor>(ref weak_implementor_SetOnMyLocationButtonClickListener, IOnMyLocationButtonClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnMyLocationButtonClickListener(null);
				}, delegate(IOnMyLocationButtonClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationButtonClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MyLocationChangeEventArgs> MyLocationChange
		{
			add
			{
				EventHelper.AddEventHandler<IOnMyLocationChangeListener, IOnMyLocationChangeListenerImplementor>(ref weak_implementor_SetOnMyLocationChangeListener, __CreateIOnMyLocationChangeListenerImplementor, SetOnMyLocationChangeListener, delegate(IOnMyLocationChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationChangeEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMyLocationChangeListener, IOnMyLocationChangeListenerImplementor>(ref weak_implementor_SetOnMyLocationChangeListener, IOnMyLocationChangeListenerImplementor.__IsEmpty, delegate
				{
					SetOnMyLocationChangeListener(null);
				}, delegate(IOnMyLocationChangeListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationChangeEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<MyLocationClickEventArgs> MyLocationClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnMyLocationClickListener, IOnMyLocationClickListenerImplementor>(ref weak_implementor_SetOnMyLocationClickListener, __CreateIOnMyLocationClickListenerImplementor, SetOnMyLocationClickListener, delegate(IOnMyLocationClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMyLocationClickListener, IOnMyLocationClickListenerImplementor>(ref weak_implementor_SetOnMyLocationClickListener, IOnMyLocationClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnMyLocationClickListener(null);
				}, delegate(IOnMyLocationClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MyLocationClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<PoiClickEventArgs> PoiClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnPoiClickListener, IOnPoiClickListenerImplementor>(ref weak_implementor_SetOnPoiClickListener, __CreateIOnPoiClickListenerImplementor, SetOnPoiClickListener, delegate(IOnPoiClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PoiClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnPoiClickListener, IOnPoiClickListenerImplementor>(ref weak_implementor_SetOnPoiClickListener, IOnPoiClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnPoiClickListener(null);
				}, delegate(IOnPoiClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PoiClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<PolygonClickEventArgs> PolygonClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnPolygonClickListener, IOnPolygonClickListenerImplementor>(ref weak_implementor_SetOnPolygonClickListener, __CreateIOnPolygonClickListenerImplementor, SetOnPolygonClickListener, delegate(IOnPolygonClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PolygonClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnPolygonClickListener, IOnPolygonClickListenerImplementor>(ref weak_implementor_SetOnPolygonClickListener, IOnPolygonClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnPolygonClickListener(null);
				}, delegate(IOnPolygonClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PolygonClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		public event EventHandler<PolylineClickEventArgs> PolylineClick
		{
			add
			{
				EventHelper.AddEventHandler<IOnPolylineClickListener, IOnPolylineClickListenerImplementor>(ref weak_implementor_SetOnPolylineClickListener, __CreateIOnPolylineClickListenerImplementor, SetOnPolylineClickListener, delegate(IOnPolylineClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PolylineClickEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnPolylineClickListener, IOnPolylineClickListenerImplementor>(ref weak_implementor_SetOnPolylineClickListener, IOnPolylineClickListenerImplementor.__IsEmpty, delegate
				{
					SetOnPolylineClickListener(null);
				}, delegate(IOnPolylineClickListenerImplementor __h)
				{
					__h.Handler = (EventHandler<PolylineClickEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected GoogleMap(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetFocusedBuildingHandler()
		{
			if ((object)cb_getFocusedBuilding == null)
			{
				cb_getFocusedBuilding = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFocusedBuilding));
			}
			return cb_getFocusedBuilding;
		}

		private static IntPtr n_GetFocusedBuilding(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusedBuilding);
		}

		[Register("addCircle", "(Lcom/google/android/gms/maps/model/CircleOptions;)Lcom/google/android/gms/maps/model/Circle;", "")]
		public unsafe Circle AddCircle(CircleOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Circle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addCircle.(Lcom/google/android/gms/maps/model/CircleOptions;)Lcom/google/android/gms/maps/model/Circle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("addGroundOverlay", "(Lcom/google/android/gms/maps/model/GroundOverlayOptions;)Lcom/google/android/gms/maps/model/GroundOverlay;", "")]
		public unsafe GroundOverlay AddGroundOverlay(GroundOverlayOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GroundOverlay>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addGroundOverlay.(Lcom/google/android/gms/maps/model/GroundOverlayOptions;)Lcom/google/android/gms/maps/model/GroundOverlay;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("addMarker", "(Lcom/google/android/gms/maps/model/MarkerOptions;)Lcom/google/android/gms/maps/model/Marker;", "")]
		public unsafe Marker AddMarker(MarkerOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Marker>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addMarker.(Lcom/google/android/gms/maps/model/MarkerOptions;)Lcom/google/android/gms/maps/model/Marker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("addPolygon", "(Lcom/google/android/gms/maps/model/PolygonOptions;)Lcom/google/android/gms/maps/model/Polygon;", "")]
		public unsafe Polygon AddPolygon(PolygonOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Polygon>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPolygon.(Lcom/google/android/gms/maps/model/PolygonOptions;)Lcom/google/android/gms/maps/model/Polygon;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("addPolyline", "(Lcom/google/android/gms/maps/model/PolylineOptions;)Lcom/google/android/gms/maps/model/Polyline;", "")]
		public unsafe Polyline AddPolyline(PolylineOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Polyline>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addPolyline.(Lcom/google/android/gms/maps/model/PolylineOptions;)Lcom/google/android/gms/maps/model/Polyline;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("addTileOverlay", "(Lcom/google/android/gms/maps/model/TileOverlayOptions;)Lcom/google/android/gms/maps/model/TileOverlay;", "")]
		public unsafe TileOverlay AddTileOverlay(TileOverlayOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<TileOverlay>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("addTileOverlay.(Lcom/google/android/gms/maps/model/TileOverlayOptions;)Lcom/google/android/gms/maps/model/TileOverlay;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("animateCamera", "(Lcom/google/android/gms/maps/CameraUpdate;)V", "")]
		public unsafe void AnimateCamera(CameraUpdate update)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(update?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("animateCamera.(Lcom/google/android/gms/maps/CameraUpdate;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(update);
			}
		}

		[Register("animateCamera", "(Lcom/google/android/gms/maps/CameraUpdate;Lcom/google/android/gms/maps/GoogleMap$CancelableCallback;)V", "")]
		public unsafe void AnimateCamera(CameraUpdate update, ICancelableCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(update?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("animateCamera.(Lcom/google/android/gms/maps/CameraUpdate;Lcom/google/android/gms/maps/GoogleMap$CancelableCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(update);
				GC.KeepAlive(callback);
			}
		}

		[Register("animateCamera", "(Lcom/google/android/gms/maps/CameraUpdate;ILcom/google/android/gms/maps/GoogleMap$CancelableCallback;)V", "")]
		public unsafe void AnimateCamera(CameraUpdate update, int durationMs, ICancelableCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(update?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(durationMs);
				ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("animateCamera.(Lcom/google/android/gms/maps/CameraUpdate;ILcom/google/android/gms/maps/GoogleMap$CancelableCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(update);
				GC.KeepAlive(callback);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clear.()V", this, null);
		}

		[Register("moveCamera", "(Lcom/google/android/gms/maps/CameraUpdate;)V", "")]
		public unsafe void MoveCamera(CameraUpdate update)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(update?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("moveCamera.(Lcom/google/android/gms/maps/CameraUpdate;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(update);
			}
		}

		private static Delegate GetResetMinMaxZoomPreferenceHandler()
		{
			if ((object)cb_resetMinMaxZoomPreference == null)
			{
				cb_resetMinMaxZoomPreference = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetMinMaxZoomPreference));
			}
			return cb_resetMinMaxZoomPreference;
		}

		private static void n_ResetMinMaxZoomPreference(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetMinMaxZoomPreference();
		}

		[Register("resetMinMaxZoomPreference", "()V", "GetResetMinMaxZoomPreferenceHandler")]
		public unsafe virtual void ResetMinMaxZoomPreference()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetMinMaxZoomPreference.()V", this, null);
		}

		[Register("setContentDescription", "(Ljava/lang/String;)V", "")]
		public unsafe void SetContentDescription(string description)
		{
			IntPtr intPtr = JNIEnv.NewString(description);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setContentDescription.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("setIndoorEnabled", "(Z)Z", "")]
		public unsafe bool SetIndoorEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("setIndoorEnabled.(Z)Z", this, ptr);
		}

		[Register("setInfoWindowAdapter", "(Lcom/google/android/gms/maps/GoogleMap$InfoWindowAdapter;)V", "")]
		public unsafe void SetInfoWindowAdapter(IInfoWindowAdapter adapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setInfoWindowAdapter.(Lcom/google/android/gms/maps/GoogleMap$InfoWindowAdapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(adapter);
			}
		}

		private static Delegate GetSetLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_Handler()
		{
			if ((object)cb_setLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_ == null)
			{
				cb_setLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_));
			}
			return cb_setLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_;
		}

		private static void n_SetLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_(IntPtr jnienv, IntPtr native__this, IntPtr native_bounds)
		{
			GoogleMap googleMap = Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LatLngBounds latLngBoundsForCameraTarget = Java.Lang.Object.GetObject<LatLngBounds>(native_bounds, JniHandleOwnership.DoNotTransfer);
			googleMap.SetLatLngBoundsForCameraTarget(latLngBoundsForCameraTarget);
		}

		[Register("setLatLngBoundsForCameraTarget", "(Lcom/google/android/gms/maps/model/LatLngBounds;)V", "GetSetLatLngBoundsForCameraTarget_Lcom_google_android_gms_maps_model_LatLngBounds_Handler")]
		public unsafe virtual void SetLatLngBoundsForCameraTarget(LatLngBounds bounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLatLngBoundsForCameraTarget.(Lcom/google/android/gms/maps/model/LatLngBounds;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}

		[Register("setLocationSource", "(Lcom/google/android/gms/maps/LocationSource;)V", "")]
		public unsafe void SetLocationSource(ILocationSource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLocationSource.(Lcom/google/android/gms/maps/LocationSource;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		private static Delegate GetSetMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_Handler()
		{
			if ((object)cb_setMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_ == null)
			{
				cb_setMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_SetMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_));
			}
			return cb_setMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_;
		}

		private static bool n_SetMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_(IntPtr jnienv, IntPtr native__this, IntPtr native_style)
		{
			GoogleMap googleMap = Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MapStyleOptions mapStyle = Java.Lang.Object.GetObject<MapStyleOptions>(native_style, JniHandleOwnership.DoNotTransfer);
			return googleMap.SetMapStyle(mapStyle);
		}

		[Register("setMapStyle", "(Lcom/google/android/gms/maps/model/MapStyleOptions;)Z", "GetSetMapStyle_Lcom_google_android_gms_maps_model_MapStyleOptions_Handler")]
		public unsafe virtual bool SetMapStyle(MapStyleOptions style)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(style?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("setMapStyle.(Lcom/google/android/gms/maps/model/MapStyleOptions;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(style);
			}
		}

		private static Delegate GetSetMaxZoomPreference_FHandler()
		{
			if ((object)cb_setMaxZoomPreference_F == null)
			{
				cb_setMaxZoomPreference_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMaxZoomPreference_F));
			}
			return cb_setMaxZoomPreference_F;
		}

		private static void n_SetMaxZoomPreference_F(IntPtr jnienv, IntPtr native__this, float maxZoomPreference)
		{
			Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxZoomPreference(maxZoomPreference);
		}

		[Register("setMaxZoomPreference", "(F)V", "GetSetMaxZoomPreference_FHandler")]
		public unsafe virtual void SetMaxZoomPreference(float maxZoomPreference)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxZoomPreference);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxZoomPreference.(F)V", this, ptr);
		}

		private static Delegate GetSetMinZoomPreference_FHandler()
		{
			if ((object)cb_setMinZoomPreference_F == null)
			{
				cb_setMinZoomPreference_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMinZoomPreference_F));
			}
			return cb_setMinZoomPreference_F;
		}

		private static void n_SetMinZoomPreference_F(IntPtr jnienv, IntPtr native__this, float minZoomPreference)
		{
			Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinZoomPreference(minZoomPreference);
		}

		[Register("setMinZoomPreference", "(F)V", "GetSetMinZoomPreference_FHandler")]
		public unsafe virtual void SetMinZoomPreference(float minZoomPreference)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(minZoomPreference);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinZoomPreference.(F)V", this, ptr);
		}

		[Register("setOnCameraChangeListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCameraChangeListener;)V", "")]
		public unsafe void SetOnCameraChangeListener(IOnCameraChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCameraChangeListener.(Lcom/google/android/gms/maps/GoogleMap$OnCameraChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnCameraIdleListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCameraIdleListener;)V", "")]
		public unsafe void SetOnCameraIdleListener(IOnCameraIdleListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCameraIdleListener.(Lcom/google/android/gms/maps/GoogleMap$OnCameraIdleListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnCameraMoveCanceledListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveCanceledListener;)V", "")]
		public unsafe void SetOnCameraMoveCanceledListener(IOnCameraMoveCanceledListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCameraMoveCanceledListener.(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveCanceledListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnCameraMoveListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveListener;)V", "")]
		public unsafe void SetOnCameraMoveListener(IOnCameraMoveListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCameraMoveListener.(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnCameraMoveStartedListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveStartedListener;)V", "")]
		public unsafe void SetOnCameraMoveStartedListener(IOnCameraMoveStartedListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCameraMoveStartedListener.(Lcom/google/android/gms/maps/GoogleMap$OnCameraMoveStartedListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnCircleClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnCircleClickListener;)V", "")]
		public unsafe void SetOnCircleClickListener(IOnCircleClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnCircleClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnCircleClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnGroundOverlayClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnGroundOverlayClickListener;)V", "")]
		public unsafe void SetOnGroundOverlayClickListener(IOnGroundOverlayClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnGroundOverlayClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnGroundOverlayClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnIndoorStateChangeListener", "(Lcom/google/android/gms/maps/GoogleMap$OnIndoorStateChangeListener;)V", "")]
		public unsafe void SetOnIndoorStateChangeListener(IOnIndoorStateChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnIndoorStateChangeListener.(Lcom/google/android/gms/maps/GoogleMap$OnIndoorStateChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnInfoWindowClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowClickListener;)V", "")]
		public unsafe void SetOnInfoWindowClickListener(IOnInfoWindowClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnInfoWindowClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnInfoWindowCloseListener", "(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowCloseListener;)V", "")]
		public unsafe void SetOnInfoWindowCloseListener(IOnInfoWindowCloseListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnInfoWindowCloseListener.(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowCloseListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnInfoWindowLongClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowLongClickListener;)V", "")]
		public unsafe void SetOnInfoWindowLongClickListener(IOnInfoWindowLongClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnInfoWindowLongClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnInfoWindowLongClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMapClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMapClickListener;)V", "")]
		public unsafe void SetOnMapClickListener(IOnMapClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMapClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnMapClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_Handler()
		{
			if ((object)cb_setOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_ == null)
			{
				cb_setOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_));
			}
			return cb_setOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_;
		}

		private static void n_SetOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			GoogleMap googleMap = Java.Lang.Object.GetObject<GoogleMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMapLoadedCallback onMapLoadedCallback = Java.Lang.Object.GetObject<IOnMapLoadedCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			googleMap.SetOnMapLoadedCallback(onMapLoadedCallback);
		}

		[Register("setOnMapLoadedCallback", "(Lcom/google/android/gms/maps/GoogleMap$OnMapLoadedCallback;)V", "GetSetOnMapLoadedCallback_Lcom_google_android_gms_maps_GoogleMap_OnMapLoadedCallback_Handler")]
		public unsafe virtual void SetOnMapLoadedCallback(IOnMapLoadedCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnMapLoadedCallback.(Lcom/google/android/gms/maps/GoogleMap$OnMapLoadedCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("setOnMapLongClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMapLongClickListener;)V", "")]
		public unsafe void SetOnMapLongClickListener(IOnMapLongClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMapLongClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnMapLongClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMarkerClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMarkerClickListener;)V", "")]
		public unsafe void SetOnMarkerClickListener(IOnMarkerClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMarkerClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnMarkerClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMarkerDragListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMarkerDragListener;)V", "")]
		public unsafe void SetOnMarkerDragListener(IOnMarkerDragListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMarkerDragListener.(Lcom/google/android/gms/maps/GoogleMap$OnMarkerDragListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMyLocationButtonClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationButtonClickListener;)V", "")]
		public unsafe void SetOnMyLocationButtonClickListener(IOnMyLocationButtonClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMyLocationButtonClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationButtonClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMyLocationChangeListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationChangeListener;)V", "")]
		public unsafe void SetOnMyLocationChangeListener(IOnMyLocationChangeListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMyLocationChangeListener.(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnMyLocationClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationClickListener;)V", "")]
		public unsafe void SetOnMyLocationClickListener(IOnMyLocationClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnMyLocationClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnMyLocationClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnPoiClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnPoiClickListener;)V", "")]
		public unsafe void SetOnPoiClickListener(IOnPoiClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnPoiClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnPoiClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnPolygonClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnPolygonClickListener;)V", "")]
		public unsafe void SetOnPolygonClickListener(IOnPolygonClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnPolygonClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnPolygonClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setOnPolylineClickListener", "(Lcom/google/android/gms/maps/GoogleMap$OnPolylineClickListener;)V", "")]
		public unsafe void SetOnPolylineClickListener(IOnPolylineClickListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setOnPolylineClickListener.(Lcom/google/android/gms/maps/GoogleMap$OnPolylineClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		[Register("setPadding", "(IIII)V", "")]
		public unsafe void SetPadding(int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setPadding.(IIII)V", this, ptr);
		}

		[Register("snapshot", "(Lcom/google/android/gms/maps/GoogleMap$SnapshotReadyCallback;)V", "")]
		public unsafe void Snapshot(ISnapshotReadyCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("snapshot.(Lcom/google/android/gms/maps/GoogleMap$SnapshotReadyCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("snapshot", "(Lcom/google/android/gms/maps/GoogleMap$SnapshotReadyCallback;Landroid/graphics/Bitmap;)V", "")]
		public unsafe void Snapshot(ISnapshotReadyCallback callback, Bitmap bitmap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				ptr[1] = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("snapshot.(Lcom/google/android/gms/maps/GoogleMap$SnapshotReadyCallback;Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
				GC.KeepAlive(bitmap);
			}
		}

		[Register("stopAnimation", "()V", "")]
		public unsafe void StopAnimation()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stopAnimation.()V", this, null);
		}

		private IOnCameraChangeListenerImplementor __CreateIOnCameraChangeListenerImplementor()
		{
			return new IOnCameraChangeListenerImplementor(this);
		}

		private IOnCameraIdleListenerImplementor __CreateIOnCameraIdleListenerImplementor()
		{
			return new IOnCameraIdleListenerImplementor(this);
		}

		private IOnCameraMoveCanceledListenerImplementor __CreateIOnCameraMoveCanceledListenerImplementor()
		{
			return new IOnCameraMoveCanceledListenerImplementor(this);
		}

		private IOnCameraMoveListenerImplementor __CreateIOnCameraMoveListenerImplementor()
		{
			return new IOnCameraMoveListenerImplementor(this);
		}

		private IOnCameraMoveStartedListenerImplementor __CreateIOnCameraMoveStartedListenerImplementor()
		{
			return new IOnCameraMoveStartedListenerImplementor(this);
		}

		private IOnCircleClickListenerImplementor __CreateIOnCircleClickListenerImplementor()
		{
			return new IOnCircleClickListenerImplementor(this);
		}

		private IOnGroundOverlayClickListenerImplementor __CreateIOnGroundOverlayClickListenerImplementor()
		{
			return new IOnGroundOverlayClickListenerImplementor(this);
		}

		private IOnIndoorStateChangeListenerImplementor __CreateIOnIndoorStateChangeListenerImplementor()
		{
			return new IOnIndoorStateChangeListenerImplementor(this);
		}

		private IOnInfoWindowClickListenerImplementor __CreateIOnInfoWindowClickListenerImplementor()
		{
			return new IOnInfoWindowClickListenerImplementor(this);
		}

		private IOnInfoWindowCloseListenerImplementor __CreateIOnInfoWindowCloseListenerImplementor()
		{
			return new IOnInfoWindowCloseListenerImplementor(this);
		}

		private IOnInfoWindowLongClickListenerImplementor __CreateIOnInfoWindowLongClickListenerImplementor()
		{
			return new IOnInfoWindowLongClickListenerImplementor(this);
		}

		private IOnMapClickListenerImplementor __CreateIOnMapClickListenerImplementor()
		{
			return new IOnMapClickListenerImplementor(this);
		}

		private IOnMapLongClickListenerImplementor __CreateIOnMapLongClickListenerImplementor()
		{
			return new IOnMapLongClickListenerImplementor(this);
		}

		private IOnMarkerClickListenerImplementor __CreateIOnMarkerClickListenerImplementor()
		{
			return new IOnMarkerClickListenerImplementor(this);
		}

		private IOnMarkerDragListenerImplementor __CreateIOnMarkerDragListenerImplementor()
		{
			return new IOnMarkerDragListenerImplementor(this);
		}

		private IOnMyLocationButtonClickListenerImplementor __CreateIOnMyLocationButtonClickListenerImplementor()
		{
			return new IOnMyLocationButtonClickListenerImplementor(this);
		}

		private IOnMyLocationChangeListenerImplementor __CreateIOnMyLocationChangeListenerImplementor()
		{
			return new IOnMyLocationChangeListenerImplementor(this);
		}

		private IOnMyLocationClickListenerImplementor __CreateIOnMyLocationClickListenerImplementor()
		{
			return new IOnMyLocationClickListenerImplementor(this);
		}

		private IOnPoiClickListenerImplementor __CreateIOnPoiClickListenerImplementor()
		{
			return new IOnPoiClickListenerImplementor(this);
		}

		private IOnPolygonClickListenerImplementor __CreateIOnPolygonClickListenerImplementor()
		{
			return new IOnPolygonClickListenerImplementor(this);
		}

		private IOnPolylineClickListenerImplementor __CreateIOnPolylineClickListenerImplementor()
		{
			return new IOnPolylineClickListenerImplementor(this);
		}
	}
	[Register("com/google/android/gms/maps/GoogleMapOptions", DoNotGenerateAcw = true)]
	public sealed class GoogleMapOptions : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/GoogleMapOptions", typeof(GoogleMapOptions));

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

		public unsafe Java.Lang.Boolean AmbientEnabled
		{
			[Register("getAmbientEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAmbientEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe CameraPosition Camera
		{
			[Register("getCamera", "()Lcom/google/android/gms/maps/model/CameraPosition;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CameraPosition>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCamera.()Lcom/google/android/gms/maps/model/CameraPosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean CompassEnabled
		{
			[Register("getCompassEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCompassEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe LatLngBounds LatLngBoundsForCameraTarget
		{
			[Register("getLatLngBoundsForCameraTarget", "()Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLatLngBoundsForCameraTarget.()Lcom/google/android/gms/maps/model/LatLngBounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean LiteMode
		{
			[Register("getLiteMode", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLiteMode.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean MapToolbarEnabled
		{
			[Register("getMapToolbarEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMapToolbarEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int MapType
		{
			[Register("getMapType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMapType.()I", this, null);
			}
		}

		public unsafe Float MaxZoomPreference
		{
			[Register("getMaxZoomPreference", "()Ljava/lang/Float;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMaxZoomPreference.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Float MinZoomPreference
		{
			[Register("getMinZoomPreference", "()Ljava/lang/Float;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMinZoomPreference.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean RotateGesturesEnabled
		{
			[Register("getRotateGesturesEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRotateGesturesEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean ScrollGesturesEnabled
		{
			[Register("getScrollGesturesEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScrollGesturesEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean ScrollGesturesEnabledDuringRotateOrZoom
		{
			[Register("getScrollGesturesEnabledDuringRotateOrZoom", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScrollGesturesEnabledDuringRotateOrZoom.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean TiltGesturesEnabled
		{
			[Register("getTiltGesturesEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTiltGesturesEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean UseViewLifecycleInFragment
		{
			[Register("getUseViewLifecycleInFragment", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUseViewLifecycleInFragment.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean ZOrderOnTop
		{
			[Register("getZOrderOnTop", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getZOrderOnTop.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean ZoomControlsEnabled
		{
			[Register("getZoomControlsEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getZoomControlsEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Boolean ZoomGesturesEnabled
		{
			[Register("getZoomGesturesEnabled", "()Ljava/lang/Boolean;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getZoomGesturesEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal GoogleMapOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GoogleMapOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("ambientEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeAmbientEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("ambientEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("camera", "(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeCamera(CameraPosition camera)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(camera?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("camera.(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(camera);
			}
		}

		[Register("compassEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeCompassEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("compassEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("createFromAttributes", "(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe static GoogleMapOptions CreateFromAttributes(Context context, IAttributeSet attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.StaticMethods.InvokeObjectMethod("createFromAttributes.(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/GoogleMapOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register("latLngBoundsForCameraTarget", "(Lcom/google/android/gms/maps/model/LatLngBounds;)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeLatLngBoundsForCameraTarget(LatLngBounds llbounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(llbounds?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("latLngBoundsForCameraTarget.(Lcom/google/android/gms/maps/model/LatLngBounds;)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(llbounds);
			}
		}

		[Register("liteMode", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeLiteMode(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("liteMode.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("mapToolbarEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeMapToolbarEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("mapToolbarEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("mapType", "(I)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeMapType(int mapType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mapType);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("mapType.(I)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("maxZoomPreference", "(F)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeMaxZoomPreference(float maxZoomPreference)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(maxZoomPreference);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("maxZoomPreference.(F)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("minZoomPreference", "(F)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeMinZoomPreference(float minZoomPreference)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(minZoomPreference);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("minZoomPreference.(F)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("rotateGesturesEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeRotateGesturesEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotateGesturesEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("scrollGesturesEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeScrollGesturesEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("scrollGesturesEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("scrollGesturesEnabledDuringRotateOrZoom", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeScrollGesturesEnabledDuringRotateOrZoom(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("scrollGesturesEnabledDuringRotateOrZoom.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("tiltGesturesEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeTiltGesturesEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("tiltGesturesEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("useViewLifecycleInFragment", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeUseViewLifecycleInFragment(bool useViewLifecycleInFragment)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(useViewLifecycleInFragment);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("useViewLifecycleInFragment.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zOrderOnTop", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeZOrderOnTop(bool zOrderOnTop)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zOrderOnTop);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zOrderOnTop.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomControlsEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeZoomControlsEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zoomControlsEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("zoomGesturesEnabled", "(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", "")]
		public unsafe GoogleMapOptions InvokeZoomGesturesEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			return Java.Lang.Object.GetObject<GoogleMapOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zoomGesturesEnabled.(Z)Lcom/google/android/gms/maps/GoogleMapOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/LocationSource$OnLocationChangedListener", "", "Android.Gms.Maps.ILocationSourceOnLocationChangedListenerInvoker")]
	public interface ILocationSourceOnLocationChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLocationChanged", "(Landroid/location/Location;)V", "GetOnLocationChanged_Landroid_location_Location_Handler:Android.Gms.Maps.ILocationSourceOnLocationChangedListenerInvoker, Xamarin.GooglePlayServices.Maps")]
		void OnLocationChanged(Location location);
	}
	[Register("com/google/android/gms/maps/LocationSource$OnLocationChangedListener", DoNotGenerateAcw = true)]
	internal class ILocationSourceOnLocationChangedListenerInvoker : Java.Lang.Object, ILocationSourceOnLocationChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/LocationSource$OnLocationChangedListener", typeof(ILocationSourceOnLocationChangedListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onLocationChanged_Landroid_location_Location_;

		private IntPtr id_onLocationChanged_Landroid_location_Location_;

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

		public static ILocationSourceOnLocationChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILocationSourceOnLocationChangedListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.LocationSource.OnLocationChangedListener'.");
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

		public ILocationSourceOnLocationChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnLocationChanged_Landroid_location_Location_Handler()
		{
			if ((object)cb_onLocationChanged_Landroid_location_Location_ == null)
			{
				cb_onLocationChanged_Landroid_location_Location_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLocationChanged_Landroid_location_Location_));
			}
			return cb_onLocationChanged_Landroid_location_Location_;
		}

		private static void n_OnLocationChanged_Landroid_location_Location_(IntPtr jnienv, IntPtr native__this, IntPtr native_location)
		{
			ILocationSourceOnLocationChangedListener locationSourceOnLocationChangedListener = Java.Lang.Object.GetObject<ILocationSourceOnLocationChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Location location = Java.Lang.Object.GetObject<Location>(native_location, JniHandleOwnership.DoNotTransfer);
			locationSourceOnLocationChangedListener.OnLocationChanged(location);
		}

		public unsafe void OnLocationChanged(Location location)
		{
			if (id_onLocationChanged_Landroid_location_Location_ == IntPtr.Zero)
			{
				id_onLocationChanged_Landroid_location_Location_ = JNIEnv.GetMethodID(class_ref, "onLocationChanged", "(Landroid/location/Location;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(location?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onLocationChanged_Landroid_location_Location_, ptr);
		}
	}
	[Register("com/google/android/gms/maps/LocationSource", "", "Android.Gms.Maps.ILocationSourceInvoker")]
	public interface ILocationSource : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("activate", "(Lcom/google/android/gms/maps/LocationSource$OnLocationChangedListener;)V", "GetActivate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_Handler:Android.Gms.Maps.ILocationSourceInvoker, Xamarin.GooglePlayServices.Maps")]
		void Activate(ILocationSourceOnLocationChangedListener listener);

		[Register("deactivate", "()V", "GetDeactivateHandler:Android.Gms.Maps.ILocationSourceInvoker, Xamarin.GooglePlayServices.Maps")]
		void Deactivate();
	}
	[Register("com/google/android/gms/maps/LocationSource", DoNotGenerateAcw = true)]
	internal class ILocationSourceInvoker : Java.Lang.Object, ILocationSource, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/LocationSource", typeof(ILocationSourceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_;

		private IntPtr id_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_;

		private static Delegate cb_deactivate;

		private IntPtr id_deactivate;

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

		public static ILocationSource GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ILocationSource>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.LocationSource'.");
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

		public ILocationSourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetActivate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_Handler()
		{
			if ((object)cb_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_ == null)
			{
				cb_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_));
			}
			return cb_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_;
		}

		private static void n_Activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			ILocationSource locationSource = Java.Lang.Object.GetObject<ILocationSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILocationSourceOnLocationChangedListener listener = Java.Lang.Object.GetObject<ILocationSourceOnLocationChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			locationSource.Activate(listener);
		}

		public unsafe void Activate(ILocationSourceOnLocationChangedListener listener)
		{
			if (id_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_ == IntPtr.Zero)
			{
				id_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_ = JNIEnv.GetMethodID(class_ref, "activate", "(Lcom/google/android/gms/maps/LocationSource$OnLocationChangedListener;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_activate_Lcom_google_android_gms_maps_LocationSource_OnLocationChangedListener_, ptr);
		}

		private static Delegate GetDeactivateHandler()
		{
			if ((object)cb_deactivate == null)
			{
				cb_deactivate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Deactivate));
			}
			return cb_deactivate;
		}

		private static void n_Deactivate(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ILocationSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Deactivate();
		}

		public void Deactivate()
		{
			if (id_deactivate == IntPtr.Zero)
			{
				id_deactivate = JNIEnv.GetMethodID(class_ref, "deactivate", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_deactivate);
		}
	}
	[Register("com/google/android/gms/maps/OnMapReadyCallback", "", "Android.Gms.Maps.IOnMapReadyCallbackInvoker")]
	public interface IOnMapReadyCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMapReady", "(Lcom/google/android/gms/maps/GoogleMap;)V", "GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler:Android.Gms.Maps.IOnMapReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps")]
		void OnMapReady(GoogleMap googleMap);
	}
	[Register("com/google/android/gms/maps/OnMapReadyCallback", DoNotGenerateAcw = true)]
	internal class IOnMapReadyCallbackInvoker : Java.Lang.Object, IOnMapReadyCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/OnMapReadyCallback", typeof(IOnMapReadyCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onMapReady_Lcom_google_android_gms_maps_GoogleMap_;

		private IntPtr id_onMapReady_Lcom_google_android_gms_maps_GoogleMap_;

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

		public static IOnMapReadyCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnMapReadyCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.OnMapReadyCallback'.");
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

		public IOnMapReadyCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler()
		{
			if ((object)cb_onMapReady_Lcom_google_android_gms_maps_GoogleMap_ == null)
			{
				cb_onMapReady_Lcom_google_android_gms_maps_GoogleMap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapReady_Lcom_google_android_gms_maps_GoogleMap_));
			}
			return cb_onMapReady_Lcom_google_android_gms_maps_GoogleMap_;
		}

		private static void n_OnMapReady_Lcom_google_android_gms_maps_GoogleMap_(IntPtr jnienv, IntPtr native__this, IntPtr native_googleMap)
		{
			IOnMapReadyCallback onMapReadyCallback = Java.Lang.Object.GetObject<IOnMapReadyCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			GoogleMap googleMap = Java.Lang.Object.GetObject<GoogleMap>(native_googleMap, JniHandleOwnership.DoNotTransfer);
			onMapReadyCallback.OnMapReady(googleMap);
		}

		public unsafe void OnMapReady(GoogleMap googleMap)
		{
			if (id_onMapReady_Lcom_google_android_gms_maps_GoogleMap_ == IntPtr.Zero)
			{
				id_onMapReady_Lcom_google_android_gms_maps_GoogleMap_ = JNIEnv.GetMethodID(class_ref, "onMapReady", "(Lcom/google/android/gms/maps/GoogleMap;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(googleMap?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onMapReady_Lcom_google_android_gms_maps_GoogleMap_, ptr);
		}
	}
	[Register("com/google/android/gms/maps/MapFragment", DoNotGenerateAcw = true)]
	public class MapFragment : Fragment
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/MapFragment", typeof(MapFragment));

		private static Delegate cb_getMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_;

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

		protected MapFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MapFragment()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_Handler()
		{
			if ((object)cb_getMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_ == null)
			{
				cb_getMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_GetMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_));
			}
			return cb_getMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_;
		}

		private static void n_GetMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			MapFragment mapFragment = Java.Lang.Object.GetObject<MapFragment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMapReadyCallback callback = Java.Lang.Object.GetObject<IOnMapReadyCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			mapFragment.GetMapAsync(callback);
		}

		[Register("getMapAsync", "(Lcom/google/android/gms/maps/OnMapReadyCallback;)V", "GetGetMapAsync_Lcom_google_android_gms_maps_OnMapReadyCallback_Handler")]
		public unsafe virtual void GetMapAsync(IOnMapReadyCallback callback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getMapAsync.(Lcom/google/android/gms/maps/OnMapReadyCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(callback);
			}
		}

		[Register("newInstance", "()Lcom/google/android/gms/maps/MapFragment;", "")]
		public unsafe static MapFragment NewInstance()
		{
			return Java.Lang.Object.GetObject<MapFragment>(_members.StaticMethods.InvokeObjectMethod("newInstance.()Lcom/google/android/gms/maps/MapFragment;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("newInstance", "(Lcom/google/android/gms/maps/GoogleMapOptions;)Lcom/google/android/gms/maps/MapFragment;", "")]
		public unsafe static MapFragment NewInstance(GoogleMapOptions options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<MapFragment>(_members.StaticMethods.InvokeObjectMethod("newInstance.(Lcom/google/android/gms/maps/GoogleMapOptions;)Lcom/google/android/gms/maps/MapFragment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("onEnterAmbient", "(Landroid/os/Bundle;)V", "")]
		public unsafe void OnEnterAmbient(Bundle ambientDetails)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(ambientDetails?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("onEnterAmbient.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(ambientDetails);
			}
		}

		[Register("onExitAmbient", "()V", "")]
		public unsafe void OnExitAmbient()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onExitAmbient.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/Projection", DoNotGenerateAcw = true)]
	public sealed class Projection : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/Projection", typeof(Projection));

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

		public unsafe VisibleRegion VisibleRegion
		{
			[Register("getVisibleRegion", "()Lcom/google/android/gms/maps/model/VisibleRegion;", "")]
			get
			{
				return Java.Lang.Object.GetObject<VisibleRegion>(_members.InstanceMethods.InvokeAbstractObjectMethod("getVisibleRegion.()Lcom/google/android/gms/maps/model/VisibleRegion;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Projection(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fromScreenLocation", "(Landroid/graphics/Point;)Lcom/google/android/gms/maps/model/LatLng;", "")]
		public unsafe LatLng FromScreenLocation(Point point)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("fromScreenLocation.(Landroid/graphics/Point;)Lcom/google/android/gms/maps/model/LatLng;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(point);
			}
		}

		[Register("toScreenLocation", "(Lcom/google/android/gms/maps/model/LatLng;)Landroid/graphics/Point;", "")]
		public unsafe Point ToScreenLocation(LatLng location)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeAbstractObjectMethod("toScreenLocation.(Lcom/google/android/gms/maps/model/LatLng;)Landroid/graphics/Point;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(location);
			}
		}
	}
	[Register("com/google/android/gms/maps/UiSettings", DoNotGenerateAcw = true)]
	public sealed class UiSettings : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/UiSettings", typeof(UiSettings));

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

		public unsafe bool CompassEnabled
		{
			[Register("isCompassEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCompassEnabled.()Z", this, null);
			}
			[Register("setCompassEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCompassEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool IndoorLevelPickerEnabled
		{
			[Register("isIndoorLevelPickerEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isIndoorLevelPickerEnabled.()Z", this, null);
			}
			[Register("setIndoorLevelPickerEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setIndoorLevelPickerEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool MapToolbarEnabled
		{
			[Register("isMapToolbarEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isMapToolbarEnabled.()Z", this, null);
			}
			[Register("setMapToolbarEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMapToolbarEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool MyLocationButtonEnabled
		{
			[Register("isMyLocationButtonEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isMyLocationButtonEnabled.()Z", this, null);
			}
			[Register("setMyLocationButtonEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setMyLocationButtonEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool RotateGesturesEnabled
		{
			[Register("isRotateGesturesEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRotateGesturesEnabled.()Z", this, null);
			}
			[Register("setRotateGesturesEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setRotateGesturesEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool ScrollGesturesEnabled
		{
			[Register("isScrollGesturesEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isScrollGesturesEnabled.()Z", this, null);
			}
			[Register("setScrollGesturesEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setScrollGesturesEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool ScrollGesturesEnabledDuringRotateOrZoom
		{
			[Register("isScrollGesturesEnabledDuringRotateOrZoom", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isScrollGesturesEnabledDuringRotateOrZoom.()Z", this, null);
			}
			[Register("setScrollGesturesEnabledDuringRotateOrZoom", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setScrollGesturesEnabledDuringRotateOrZoom.(Z)V", this, ptr);
			}
		}

		public unsafe bool TiltGesturesEnabled
		{
			[Register("isTiltGesturesEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isTiltGesturesEnabled.()Z", this, null);
			}
			[Register("setTiltGesturesEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTiltGesturesEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool ZoomControlsEnabled
		{
			[Register("isZoomControlsEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isZoomControlsEnabled.()Z", this, null);
			}
			[Register("setZoomControlsEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZoomControlsEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe bool ZoomGesturesEnabled
		{
			[Register("isZoomGesturesEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isZoomGesturesEnabled.()Z", this, null);
			}
			[Register("setZoomGesturesEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZoomGesturesEnabled.(Z)V", this, ptr);
			}
		}

		internal UiSettings(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("setAllGesturesEnabled", "(Z)V", "")]
		public unsafe void SetAllGesturesEnabled(bool enabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(enabled);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAllGesturesEnabled.(Z)V", this, ptr);
		}
	}
}
namespace Android.Gms.Maps.Model
{
	[Register("com/google/android/gms/maps/model/Polygon", DoNotGenerateAcw = true)]
	public sealed class Polygon : Java.Lang.Object
	{
		private static IntPtr id_setHoles_Ljava_util_List_;

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Polygon", typeof(Polygon));

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

		public unsafe bool Clickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
			[Register("setClickable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setClickable.(Z)V", this, ptr);
			}
		}

		public unsafe int FillColor
		{
			[Register("getFillColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getFillColor.()I", this, null);
			}
			[Register("setFillColor", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setFillColor.(I)V", this, ptr);
			}
		}

		public unsafe bool Geodesic
		{
			[Register("isGeodesic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGeodesic.()Z", this, null);
			}
			[Register("setGeodesic", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setGeodesic.(Z)V", this, ptr);
			}
		}

		public unsafe IList<IList<LatLng>> Holes
		{
			[Register("getHoles", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<IList<LatLng>>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getHoles.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<LatLng> Points
		{
			[Register("getPoints", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<LatLng>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPoints.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPoints", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<LatLng>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setPoints.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe int StrokeColor
		{
			[Register("getStrokeColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeColor.()I", this, null);
			}
			[Register("setStrokeColor", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokeColor.(I)V", this, ptr);
			}
		}

		public unsafe int StrokeJointType
		{
			[Register("getStrokeJointType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeJointType.()I", this, null);
			}
			[Register("setStrokeJointType", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokeJointType.(I)V", this, ptr);
			}
		}

		public unsafe IList<PatternItem> StrokePattern
		{
			[Register("getStrokePattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getStrokePattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStrokePattern", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokePattern.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float StrokeWidth
		{
			[Register("getStrokeWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
			}
			[Register("setStrokeWidth", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokeWidth.(F)V", this, ptr);
			}
		}

		public unsafe Java.Lang.Object Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTag", "(Ljava/lang/Object;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		[Register("setHoles", "(Ljava/util/List;)V", "")]
		public unsafe void SetHoles(IList<IList<LatLng>> holes)
		{
			if (id_setHoles_Ljava_util_List_ == IntPtr.Zero)
			{
				id_setHoles_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "setHoles", "(Ljava/util/List;)V");
			}
			IntPtr intPtr = JavaList<IList<LatLng>>.ToLocalJniHandle(holes);
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_setHoles_Ljava_util_List_, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(holes);
			}
		}

		internal Polygon(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/MarkerOptions", DoNotGenerateAcw = true)]
	public sealed class MarkerOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/MarkerOptions", typeof(MarkerOptions));

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

		public unsafe float Alpha
		{
			[Register("getAlpha", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAlpha.()F", this, null);
			}
		}

		public unsafe float AnchorU
		{
			[Register("getAnchorU", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAnchorU.()F", this, null);
			}
		}

		public unsafe float AnchorV
		{
			[Register("getAnchorV", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAnchorV.()F", this, null);
			}
		}

		public unsafe BitmapDescriptor Icon
		{
			[Register("getIcon", "()Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIcon.()Lcom/google/android/gms/maps/model/BitmapDescriptor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float InfoWindowAnchorU
		{
			[Register("getInfoWindowAnchorU", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getInfoWindowAnchorU.()F", this, null);
			}
		}

		public unsafe float InfoWindowAnchorV
		{
			[Register("getInfoWindowAnchorV", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getInfoWindowAnchorV.()F", this, null);
			}
		}

		public unsafe bool IsDraggable
		{
			[Register("isDraggable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDraggable.()Z", this, null);
			}
		}

		public unsafe bool IsFlat
		{
			[Register("isFlat", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFlat.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe LatLng Position
		{
			[Register("getPosition", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPosition.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Rotation
		{
			[Register("getRotation", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getRotation.()F", this, null);
			}
		}

		public unsafe string Snippet
		{
			[Register("getSnippet", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSnippet.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		public MarkerOptions InvokeAlpha(float alpha)
		{
			return SetAlpha(alpha);
		}

		public MarkerOptions InvokeRotation(float rotation)
		{
			return SetRotation(rotation);
		}

		public MarkerOptions InvokeIcon(BitmapDescriptor icon)
		{
			return SetIcon(icon);
		}

		internal MarkerOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MarkerOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("alpha", "(F)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetAlpha(float alpha)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(alpha);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("alpha.(F)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("anchor", "(FF)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions Anchor(float u, float v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(u);
			ptr[1] = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("anchor.(FF)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("draggable", "(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions Draggable(bool draggable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(draggable);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("draggable.(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("flat", "(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions Flat(bool flat)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flat);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("flat.(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("icon", "(Lcom/google/android/gms/maps/model/BitmapDescriptor;)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetIcon(BitmapDescriptor iconDescriptor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(iconDescriptor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("icon.(Lcom/google/android/gms/maps/model/BitmapDescriptor;)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(iconDescriptor);
			}
		}

		[Register("infoWindowAnchor", "(FF)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions InfoWindowAnchor(float u, float v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(u);
			ptr[1] = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("infoWindowAnchor.(FF)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("position", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetPosition(LatLng latlng)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(latlng?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("position.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(latlng);
			}
		}

		[Register("rotation", "(F)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetRotation(float rotation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rotation);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("rotation.(F)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("snippet", "(Ljava/lang/String;)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetSnippet(string snippet)
		{
			IntPtr intPtr = JNIEnv.NewString(snippet);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("snippet.(Ljava/lang/String;)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("title", "(Ljava/lang/String;)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions SetTitle(string title)
		{
			IntPtr intPtr = JNIEnv.NewString(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("title.(Ljava/lang/String;)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/MarkerOptions;", "")]
		public unsafe MarkerOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<MarkerOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/MarkerOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/BitmapDescriptor", DoNotGenerateAcw = true)]
	public sealed class BitmapDescriptor : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/BitmapDescriptor", typeof(BitmapDescriptor));

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

		internal BitmapDescriptor(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/android/gms/maps/model/BitmapDescriptorFactory", DoNotGenerateAcw = true)]
	public sealed class BitmapDescriptorFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/BitmapDescriptorFactory", typeof(BitmapDescriptorFactory));

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

		internal BitmapDescriptorFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("defaultMarker", "()Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor DefaultMarker()
		{
			return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("defaultMarker.()Lcom/google/android/gms/maps/model/BitmapDescriptor;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("defaultMarker", "(F)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor DefaultMarker(float hue)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(hue);
			return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("defaultMarker.(F)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fromAsset", "(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor FromAsset(string assetName)
		{
			IntPtr intPtr = JNIEnv.NewString(assetName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("fromAsset.(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("fromBitmap", "(Landroid/graphics/Bitmap;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor FromBitmap(Bitmap image)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("fromBitmap.(Landroid/graphics/Bitmap;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(image);
			}
		}

		[Register("fromFile", "(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor FromFile(string fileName)
		{
			IntPtr intPtr = JNIEnv.NewString(fileName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("fromFile.(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("fromPath", "(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor FromPath(string absolutePath)
		{
			IntPtr intPtr = JNIEnv.NewString(absolutePath);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("fromPath.(Ljava/lang/String;)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("fromResource", "(I)Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
		public unsafe static BitmapDescriptor FromResource(int resourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.StaticMethods.InvokeObjectMethod("fromResource.(I)Lcom/google/android/gms/maps/model/BitmapDescriptor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/CameraPosition", DoNotGenerateAcw = true)]
	public sealed class CameraPosition : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/google/android/gms/maps/model/CameraPosition$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/CameraPosition$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register(".ctor", "(Lcom/google/android/gms/maps/model/CameraPosition;)V", "")]
			public unsafe Builder(CameraPosition previous)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(previous?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/CameraPosition;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/CameraPosition;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(previous);
				}
			}

			[Register("bearing", "(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
			public unsafe Builder Bearing(float bearing)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bearing);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("bearing.(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("build", "()Lcom/google/android/gms/maps/model/CameraPosition;", "")]
			public unsafe CameraPosition Build()
			{
				return Java.Lang.Object.GetObject<CameraPosition>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/gms/maps/model/CameraPosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("target", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
			public unsafe Builder Target(LatLng location)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("target.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(location);
				}
			}

			[Register("tilt", "(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
			public unsafe Builder Tilt(float tilt)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tilt);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("tilt.(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("zoom", "(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
			public unsafe Builder Zoom(float zoom)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(zoom);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("zoom.(F)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/CameraPosition", typeof(CameraPosition));

		[Register("bearing")]
		public float Bearing
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("bearing.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bearing.F", this, value);
			}
		}

		[Register("target")]
		public LatLng Target
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("target.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("target.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("tilt")]
		public float Tilt
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("tilt.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("tilt.F", this, value);
			}
		}

		[Register("zoom")]
		public float Zoom
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("zoom.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("zoom.F", this, value);
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

		internal CameraPosition(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/maps/model/LatLng;FFF)V", "")]
		public unsafe CameraPosition(LatLng target, float zoom, float tilt, float bearing)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(zoom);
				ptr[2] = new JniArgumentValue(tilt);
				ptr[3] = new JniArgumentValue(bearing);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;FFF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;FFF)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		[Register("builder", "()Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/gms/maps/model/CameraPosition$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("builder", "(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", "")]
		public unsafe static Builder InvokeBuilder(CameraPosition camera)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(camera?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Lcom/google/android/gms/maps/model/CameraPosition;)Lcom/google/android/gms/maps/model/CameraPosition$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(camera);
			}
		}

		[Register("createFromAttributes", "(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/model/CameraPosition;", "")]
		public unsafe static CameraPosition CreateFromAttributes(Context context, IAttributeSet attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				return Java.Lang.Object.GetObject<CameraPosition>(_members.StaticMethods.InvokeObjectMethod("createFromAttributes.(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/model/CameraPosition;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register("fromLatLngZoom", "(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/model/CameraPosition;", "")]
		public unsafe static CameraPosition FromLatLngZoom(LatLng target, float zoom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(zoom);
				return Java.Lang.Object.GetObject<CameraPosition>(_members.StaticMethods.InvokeObjectMethod("fromLatLngZoom.(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/model/CameraPosition;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/Cap", DoNotGenerateAcw = true)]
	public class Cap : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Cap", typeof(Cap));

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected Cap(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/maps/model/BitmapDescriptor;F)V", "")]
		protected unsafe Cap(BitmapDescriptor bitmapDescriptor, float bitmapRefWidth)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bitmapDescriptor?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(bitmapRefWidth);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/BitmapDescriptor;F)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/BitmapDescriptor;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bitmapDescriptor);
			}
		}

		[Register(".ctor", "(I)V", "")]
		protected unsafe Cap(int p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native__out, int native_flags)
		{
			Cap cap = Java.Lang.Object.GetObject<Cap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			cap.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/Circle", DoNotGenerateAcw = true)]
	public sealed class Circle : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Circle", typeof(Circle));

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

		public unsafe LatLng Center
		{
			[Register("getCenter", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCenter.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCenter", "(Lcom/google/android/gms/maps/model/LatLng;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setCenter.(Lcom/google/android/gms/maps/model/LatLng;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool Clickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
			[Register("setClickable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setClickable.(Z)V", this, ptr);
			}
		}

		public unsafe int FillColor
		{
			[Register("getFillColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getFillColor.()I", this, null);
			}
			[Register("setFillColor", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setFillColor.(I)V", this, ptr);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe double Radius
		{
			[Register("getRadius", "()D", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getRadius.()D", this, null);
			}
			[Register("setRadius", "(D)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setRadius.(D)V", this, ptr);
			}
		}

		public unsafe int StrokeColor
		{
			[Register("getStrokeColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeColor.()I", this, null);
			}
			[Register("setStrokeColor", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokeColor.(I)V", this, ptr);
			}
		}

		public unsafe IList<PatternItem> StrokePattern
		{
			[Register("getStrokePattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getStrokePattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStrokePattern", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokePattern.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float StrokeWidth
		{
			[Register("getStrokeWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
			}
			[Register("setStrokeWidth", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setStrokeWidth.(F)V", this, ptr);
			}
		}

		public unsafe Java.Lang.Object Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTag", "(Ljava/lang/Object;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		internal Circle(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("equals", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Equals(Java.Lang.Object p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("hashCode", "()I", "")]
		public unsafe sealed override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/CircleOptions", DoNotGenerateAcw = true)]
	public sealed class CircleOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/CircleOptions", typeof(CircleOptions));

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

		public unsafe LatLng Center
		{
			[Register("getCenter", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCenter.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int FillColor
		{
			[Register("getFillColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getFillColor.()I", this, null);
			}
		}

		public unsafe bool IsClickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe double Radius
		{
			[Register("getRadius", "()D", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getRadius.()D", this, null);
			}
		}

		public unsafe int StrokeColor
		{
			[Register("getStrokeColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeColor.()I", this, null);
			}
		}

		public unsafe IList<PatternItem> StrokePattern
		{
			[Register("getStrokePattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getStrokePattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float StrokeWidth
		{
			[Register("getStrokeWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		internal CircleOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CircleOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("center", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeCenter(LatLng center)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(center?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("center.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(center);
			}
		}

		[Register("clickable", "(Z)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions Clickable(bool clickable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clickable);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("clickable.(Z)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fillColor", "(I)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeFillColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("fillColor.(I)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("radius", "(D)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeRadius(double radius)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(radius);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("radius.(D)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("strokeColor", "(I)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeStrokeColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokeColor.(I)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("strokePattern", "(Ljava/util/List;)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeStrokePattern(IList<PatternItem> pattern)
		{
			IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokePattern.(Ljava/util/List;)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(pattern);
			}
		}

		[Register("strokeWidth", "(F)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeStrokeWidth(float width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(width);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokeWidth.(F)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe sealed override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dest);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/CircleOptions;", "")]
		public unsafe CircleOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<CircleOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/CircleOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/GroundOverlay", DoNotGenerateAcw = true)]
	public sealed class GroundOverlay : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/GroundOverlay", typeof(GroundOverlay));

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

		public unsafe float Bearing
		{
			[Register("getBearing", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getBearing.()F", this, null);
			}
			[Register("setBearing", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setBearing.(F)V", this, ptr);
			}
		}

		public unsafe LatLngBounds Bounds
		{
			[Register("getBounds", "()Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBounds.()Lcom/google/android/gms/maps/model/LatLngBounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool Clickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
			[Register("setClickable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setClickable.(Z)V", this, ptr);
			}
		}

		public unsafe float Height
		{
			[Register("getHeight", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getHeight.()F", this, null);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe LatLng Position
		{
			[Register("getPosition", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPosition.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPosition", "(Lcom/google/android/gms/maps/model/LatLng;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setPosition.(Lcom/google/android/gms/maps/model/LatLng;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Java.Lang.Object Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTag", "(Ljava/lang/Object;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float Transparency
		{
			[Register("getTransparency", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getTransparency.()F", this, null);
			}
			[Register("setTransparency", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTransparency.(F)V", this, ptr);
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float Width
		{
			[Register("getWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getWidth.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		internal GroundOverlay(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}

		[Register("setDimensions", "(F)V", "")]
		public unsafe void SetDimensions(float width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(width);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDimensions.(F)V", this, ptr);
		}

		[Register("setDimensions", "(FF)V", "")]
		public unsafe void SetDimensions(float width, float height)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDimensions.(FF)V", this, ptr);
		}

		[Register("setImage", "(Lcom/google/android/gms/maps/model/BitmapDescriptor;)V", "")]
		public unsafe void SetImage(BitmapDescriptor imageDescriptor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(imageDescriptor?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setImage.(Lcom/google/android/gms/maps/model/BitmapDescriptor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(imageDescriptor);
			}
		}

		[Register("setPositionFromBounds", "(Lcom/google/android/gms/maps/model/LatLngBounds;)V", "")]
		public unsafe void SetPositionFromBounds(LatLngBounds bounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setPositionFromBounds.(Lcom/google/android/gms/maps/model/LatLngBounds;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/GroundOverlayOptions", DoNotGenerateAcw = true)]
	public sealed class GroundOverlayOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/GroundOverlayOptions", typeof(GroundOverlayOptions));

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

		public unsafe float AnchorU
		{
			[Register("getAnchorU", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAnchorU.()F", this, null);
			}
		}

		public unsafe float AnchorV
		{
			[Register("getAnchorV", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAnchorV.()F", this, null);
			}
		}

		public unsafe float Bearing
		{
			[Register("getBearing", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getBearing.()F", this, null);
			}
		}

		public unsafe LatLngBounds Bounds
		{
			[Register("getBounds", "()Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBounds.()Lcom/google/android/gms/maps/model/LatLngBounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Height
		{
			[Register("getHeight", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getHeight.()F", this, null);
			}
		}

		public unsafe BitmapDescriptor Image
		{
			[Register("getImage", "()Lcom/google/android/gms/maps/model/BitmapDescriptor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<BitmapDescriptor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImage.()Lcom/google/android/gms/maps/model/BitmapDescriptor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsClickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe LatLng Location
		{
			[Register("getLocation", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocation.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Transparency
		{
			[Register("getTransparency", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getTransparency.()F", this, null);
			}
		}

		public unsafe float Width
		{
			[Register("getWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getWidth.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		internal GroundOverlayOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe GroundOverlayOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("anchor", "(FF)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions Anchor(float u, float v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(u);
			ptr[1] = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("anchor.(FF)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("bearing", "(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions InvokeBearing(float bearing)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bearing);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("bearing.(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("clickable", "(Z)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions Clickable(bool clickable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clickable);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("clickable.(Z)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("image", "(Lcom/google/android/gms/maps/model/BitmapDescriptor;)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions InvokeImage(BitmapDescriptor imageDescriptor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(imageDescriptor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("image.(Lcom/google/android/gms/maps/model/BitmapDescriptor;)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(imageDescriptor);
			}
		}

		[Register("position", "(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions Position(LatLng location, float width)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(width);
				return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("position.(Lcom/google/android/gms/maps/model/LatLng;F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(location);
			}
		}

		[Register("position", "(Lcom/google/android/gms/maps/model/LatLng;FF)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions Position(LatLng location, float width, float height)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("position.(Lcom/google/android/gms/maps/model/LatLng;FF)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(location);
			}
		}

		[Register("positionFromBounds", "(Lcom/google/android/gms/maps/model/LatLngBounds;)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions PositionFromBounds(LatLngBounds bounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("positionFromBounds.(Lcom/google/android/gms/maps/model/LatLngBounds;)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bounds);
			}
		}

		[Register("transparency", "(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions InvokeTransparency(float transparency)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transparency);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("transparency.(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", "")]
		public unsafe GroundOverlayOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<GroundOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/GroundOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/IndoorBuilding", DoNotGenerateAcw = true)]
	public sealed class IndoorBuilding : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/IndoorBuilding", typeof(IndoorBuilding));

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

		public unsafe int ActiveLevelIndex
		{
			[Register("getActiveLevelIndex", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getActiveLevelIndex.()I", this, null);
			}
		}

		public unsafe int DefaultLevelIndex
		{
			[Register("getDefaultLevelIndex", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getDefaultLevelIndex.()I", this, null);
			}
		}

		public unsafe bool IsUnderground
		{
			[Register("isUnderground", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUnderground.()Z", this, null);
			}
		}

		public unsafe IList<IndoorLevel> Levels
		{
			[Register("getLevels", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<IndoorLevel>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getLevels.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal IndoorBuilding(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("com/google/android/gms/maps/model/IndoorLevel", DoNotGenerateAcw = true)]
	public sealed class IndoorLevel : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/IndoorLevel", typeof(IndoorLevel));

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

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe string ShortName
		{
			[Register("getShortName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getShortName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal IndoorLevel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("activate", "()V", "")]
		public unsafe void Activate()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("activate.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/TileProvider", "", "Android.Gms.Maps.Model.ITileProviderInvoker")]
	public interface ITileProvider : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("getTile", "(III)Lcom/google/android/gms/maps/model/Tile;", "GetGetTile_IIIHandler:Android.Gms.Maps.Model.ITileProviderInvoker, Xamarin.GooglePlayServices.Maps")]
		Tile GetTile(int x, int y, int zoom);
	}
	[Register("com/google/android/gms/maps/model/TileProvider", DoNotGenerateAcw = true)]
	internal class ITileProviderInvoker : Java.Lang.Object, ITileProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/TileProvider", typeof(ITileProviderInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getTile_III;

		private IntPtr id_getTile_III;

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

		public static ITileProvider GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITileProvider>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.maps.model.TileProvider'.");
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

		public ITileProviderInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetTile_IIIHandler()
		{
			if ((object)cb_getTile_III == null)
			{
				cb_getTile_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_L(n_GetTile_III));
			}
			return cb_getTile_III;
		}

		private static IntPtr n_GetTile_III(IntPtr jnienv, IntPtr native__this, int x, int y, int zoom)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTile(x, y, zoom));
		}

		public unsafe Tile GetTile(int x, int y, int zoom)
		{
			if (id_getTile_III == IntPtr.Zero)
			{
				id_getTile_III = JNIEnv.GetMethodID(class_ref, "getTile", "(III)Lcom/google/android/gms/maps/model/Tile;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(x);
			ptr[1] = new JValue(y);
			ptr[2] = new JValue(zoom);
			return Java.Lang.Object.GetObject<Tile>(JNIEnv.CallObjectMethod(base.Handle, id_getTile_III, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/LatLng", DoNotGenerateAcw = true)]
	public sealed class LatLng : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/LatLng", typeof(LatLng));

		[Register("latitude")]
		public double Latitude
		{
			get
			{
				return _members.InstanceFields.GetDoubleValue("latitude.D", this);
			}
			set
			{
				_members.InstanceFields.SetValue("latitude.D", this, value);
			}
		}

		[Register("longitude")]
		public double Longitude
		{
			get
			{
				return _members.InstanceFields.GetDoubleValue("longitude.D", this);
			}
			set
			{
				_members.InstanceFields.SetValue("longitude.D", this, value);
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

		internal LatLng(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(DD)V", "")]
		public unsafe LatLng(double latitude, double longitude)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(latitude);
				ptr[1] = new JniArgumentValue(longitude);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(DD)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(DD)V", this, ptr);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/LatLngBounds", DoNotGenerateAcw = true)]
	public sealed class LatLngBounds : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("com/google/android/gms/maps/model/LatLngBounds$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/LatLngBounds$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register("build", "()Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
			public unsafe LatLngBounds Build()
			{
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/gms/maps/model/LatLngBounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("include", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/LatLngBounds$Builder;", "")]
			public unsafe Builder Include(LatLng point)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("include.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/LatLngBounds$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(point);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/LatLngBounds", typeof(LatLngBounds));

		[Register("northeast")]
		public LatLng Northeast
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("northeast.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("northeast.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("southwest")]
		public LatLng Southwest
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("southwest.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("southwest.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
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

		public unsafe LatLng Center
		{
			[Register("getCenter", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCenter.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal LatLngBounds(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;)V", "")]
		public unsafe LatLngBounds(LatLng southwest, LatLng northeast)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(southwest?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(northeast?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(southwest);
				GC.KeepAlive(northeast);
			}
		}

		[Register("builder", "()Lcom/google/android/gms/maps/model/LatLngBounds$Builder;", "")]
		public unsafe static Builder InvokeBuilder()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/gms/maps/model/LatLngBounds$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("contains", "(Lcom/google/android/gms/maps/model/LatLng;)Z", "")]
		public unsafe bool Contains(LatLng point)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Lcom/google/android/gms/maps/model/LatLng;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(point);
			}
		}

		[Register("createFromAttributes", "(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
		public unsafe static LatLngBounds CreateFromAttributes(Context context, IAttributeSet attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.StaticMethods.InvokeObjectMethod("createFromAttributes.(Landroid/content/Context;Landroid/util/AttributeSet;)Lcom/google/android/gms/maps/model/LatLngBounds;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register("including", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/LatLngBounds;", "")]
		public unsafe LatLngBounds Including(LatLng point)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceMethods.InvokeAbstractObjectMethod("including.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/LatLngBounds;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(point);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/MapStyleOptions", DoNotGenerateAcw = true)]
	public sealed class MapStyleOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/MapStyleOptions", typeof(MapStyleOptions));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal MapStyleOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe MapStyleOptions(string json)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(json);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("loadRawResourceStyle", "(Landroid/content/Context;I)Lcom/google/android/gms/maps/model/MapStyleOptions;", "")]
		public unsafe static MapStyleOptions LoadRawResourceStyle(Context clientContext, int resourceId)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(clientContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(resourceId);
				return Java.Lang.Object.GetObject<MapStyleOptions>(_members.StaticMethods.InvokeObjectMethod("loadRawResourceStyle.(Landroid/content/Context;I)Lcom/google/android/gms/maps/model/MapStyleOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(clientContext);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/Marker", DoNotGenerateAcw = true)]
	public sealed class Marker : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Marker", typeof(Marker));

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

		public unsafe float Alpha
		{
			[Register("getAlpha", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getAlpha.()F", this, null);
			}
			[Register("setAlpha", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setAlpha.(F)V", this, ptr);
			}
		}

		public unsafe bool Draggable
		{
			[Register("isDraggable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isDraggable.()Z", this, null);
			}
			[Register("setDraggable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setDraggable.(Z)V", this, ptr);
			}
		}

		public unsafe bool Flat
		{
			[Register("isFlat", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFlat.()Z", this, null);
			}
			[Register("setFlat", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setFlat.(Z)V", this, ptr);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsInfoWindowShown
		{
			[Register("isInfoWindowShown", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isInfoWindowShown.()Z", this, null);
			}
		}

		public unsafe LatLng Position
		{
			[Register("getPosition", "()Lcom/google/android/gms/maps/model/LatLng;", "")]
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPosition.()Lcom/google/android/gms/maps/model/LatLng;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPosition", "(Lcom/google/android/gms/maps/model/LatLng;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setPosition.(Lcom/google/android/gms/maps/model/LatLng;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe float Rotation
		{
			[Register("getRotation", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getRotation.()F", this, null);
			}
			[Register("setRotation", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setRotation.(F)V", this, ptr);
			}
		}

		public unsafe string Snippet
		{
			[Register("getSnippet", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getSnippet.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSnippet", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setSnippet.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe Java.Lang.Object Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTag", "(Ljava/lang/Object;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe string Title
		{
			[Register("getTitle", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTitle", "(Ljava/lang/String;)V", "")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		internal Marker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("hideInfoWindow", "()V", "")]
		public unsafe void HideInfoWindow()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("hideInfoWindow.()V", this, null);
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}

		[Register("setAnchor", "(FF)V", "")]
		public unsafe void SetAnchor(float anchorU, float anchorV)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(anchorU);
			ptr[1] = new JniArgumentValue(anchorV);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAnchor.(FF)V", this, ptr);
		}

		[Register("setIcon", "(Lcom/google/android/gms/maps/model/BitmapDescriptor;)V", "")]
		public unsafe void SetIcon(BitmapDescriptor iconDescriptor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(iconDescriptor?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/google/android/gms/maps/model/BitmapDescriptor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(iconDescriptor);
			}
		}

		[Register("setInfoWindowAnchor", "(FF)V", "")]
		public unsafe void SetInfoWindowAnchor(float anchorU, float anchorV)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(anchorU);
			ptr[1] = new JniArgumentValue(anchorV);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setInfoWindowAnchor.(FF)V", this, ptr);
		}

		[Register("showInfoWindow", "()V", "")]
		public unsafe void ShowInfoWindow()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("showInfoWindow.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/PatternItem", DoNotGenerateAcw = true)]
	public class PatternItem : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/PatternItem", typeof(PatternItem));

		private static Delegate cb_writeToParcel_Landroid_os_Parcel_I;

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

		protected PatternItem(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ILjava/lang/Float;)V", "")]
		public unsafe PatternItem(int p0, Float p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/Float;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/Float;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
		{
			if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
			{
				cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
			}
			return cb_writeToParcel_Landroid_os_Parcel_I;
		}

		private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native__out, int native_flags)
		{
			PatternItem patternItem = Java.Lang.Object.GetObject<PatternItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Parcel dest = Java.Lang.Object.GetObject<Parcel>(native__out, JniHandleOwnership.DoNotTransfer);
			patternItem.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/PointOfInterest", DoNotGenerateAcw = true)]
	public sealed class PointOfInterest : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/PointOfInterest", typeof(PointOfInterest));

		[Register("CREATOR")]
		public static IParcelableCreator Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("latLng")]
		public LatLng LatLng
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("latLng.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("latLng.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("name")]
		public string Name
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("name.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("name.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("placeId")]
		public string PlaceId
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("placeId.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("placeId.Ljava/lang/String;", this, new JniObjectReference(jobject));
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

		internal PointOfInterest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/maps/model/LatLng;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe PointOfInterest(LatLng latLng, string placeId, string name)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(placeId);
			IntPtr intPtr2 = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(latLng?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(latLng);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/PolygonOptions", DoNotGenerateAcw = true)]
	public sealed class PolygonOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/PolygonOptions", typeof(PolygonOptions));

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

		public unsafe int FillColor
		{
			[Register("getFillColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getFillColor.()I", this, null);
			}
		}

		public unsafe IList<IList<LatLng>> Holes
		{
			[Register("getHoles", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<IList<LatLng>>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getHoles.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsClickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
		}

		public unsafe bool IsGeodesic
		{
			[Register("isGeodesic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGeodesic.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe IList<LatLng> Points
		{
			[Register("getPoints", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<LatLng>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPoints.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int StrokeColor
		{
			[Register("getStrokeColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeColor.()I", this, null);
			}
		}

		public unsafe int StrokeJointType
		{
			[Register("getStrokeJointType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getStrokeJointType.()I", this, null);
			}
		}

		public unsafe IList<PatternItem> StrokePattern
		{
			[Register("getStrokePattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getStrokePattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float StrokeWidth
		{
			[Register("getStrokeWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		internal PolygonOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PolygonOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("add", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions Add(LatLng point)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(point);
			}
		}

		[Register("add", "([Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions Add(params LatLng[] points)
		{
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.([Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(points);
			}
		}

		[Register("addAll", "(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions AddAll(IIterable points)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((points == null) ? IntPtr.Zero : ((Java.Lang.Object)points).Handle);
				return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("addAll.(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(points);
			}
		}

		[Register("addHole", "(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions AddHole(IIterable points)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((points == null) ? IntPtr.Zero : ((Java.Lang.Object)points).Handle);
				return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("addHole.(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(points);
			}
		}

		[Register("clickable", "(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions Clickable(bool clickable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clickable);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("clickable.(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("fillColor", "(I)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeFillColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("fillColor.(I)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("geodesic", "(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions Geodesic(bool geodesic)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(geodesic);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("geodesic.(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("strokeColor", "(I)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeStrokeColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokeColor.(I)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("strokeJointType", "(I)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeStrokeJointType(int jointType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(jointType);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokeJointType.(I)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("strokePattern", "(Ljava/util/List;)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeStrokePattern(IList<PatternItem> pattern)
		{
			IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokePattern.(Ljava/util/List;)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(pattern);
			}
		}

		[Register("strokeWidth", "(F)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeStrokeWidth(float width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(width);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("strokeWidth.(F)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/PolygonOptions;", "")]
		public unsafe PolygonOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<PolygonOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/PolygonOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/Polyline", DoNotGenerateAcw = true)]
	public sealed class Polyline : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Polyline", typeof(Polyline));

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

		public unsafe bool Clickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
			[Register("setClickable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setClickable.(Z)V", this, ptr);
			}
		}

		public unsafe int Color
		{
			[Register("getColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getColor.()I", this, null);
			}
			[Register("setColor", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setColor.(I)V", this, ptr);
			}
		}

		public unsafe Cap EndCap
		{
			[Register("getEndCap", "()Lcom/google/android/gms/maps/model/Cap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEndCap.()Lcom/google/android/gms/maps/model/Cap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setEndCap", "(Lcom/google/android/gms/maps/model/Cap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setEndCap.(Lcom/google/android/gms/maps/model/Cap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool Geodesic
		{
			[Register("isGeodesic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGeodesic.()Z", this, null);
			}
			[Register("setGeodesic", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setGeodesic.(Z)V", this, ptr);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int JointType
		{
			[Register("getJointType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getJointType.()I", this, null);
			}
			[Register("setJointType", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setJointType.(I)V", this, ptr);
			}
		}

		public unsafe IList<PatternItem> Pattern
		{
			[Register("getPattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPattern", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setPattern.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IList<LatLng> Points
		{
			[Register("getPoints", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<LatLng>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPoints.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPoints", "(Ljava/util/List;)V", "")]
			set
			{
				IntPtr intPtr = JavaList<LatLng>.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setPoints.(Ljava/util/List;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Cap StartCap
		{
			[Register("getStartCap", "()Lcom/google/android/gms/maps/model/Cap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStartCap.()Lcom/google/android/gms/maps/model/Cap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStartCap", "(Lcom/google/android/gms/maps/model/Cap;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setStartCap.(Lcom/google/android/gms/maps/model/Cap;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe Java.Lang.Object Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTag", "(Ljava/lang/Object;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setTag.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float Width
		{
			[Register("getWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getWidth.()F", this, null);
			}
			[Register("setWidth", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setWidth.(F)V", this, ptr);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		internal Polyline(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/PolylineOptions", DoNotGenerateAcw = true)]
	public sealed class PolylineOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/PolylineOptions", typeof(PolylineOptions));

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

		public unsafe int Color
		{
			[Register("getColor", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getColor.()I", this, null);
			}
		}

		public unsafe Cap EndCap
		{
			[Register("getEndCap", "()Lcom/google/android/gms/maps/model/Cap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getEndCap.()Lcom/google/android/gms/maps/model/Cap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsClickable
		{
			[Register("isClickable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClickable.()Z", this, null);
			}
		}

		public unsafe bool IsGeodesic
		{
			[Register("isGeodesic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGeodesic.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe int JointType
		{
			[Register("getJointType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getJointType.()I", this, null);
			}
		}

		public unsafe IList<PatternItem> Pattern
		{
			[Register("getPattern", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<PatternItem>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPattern.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<LatLng> Points
		{
			[Register("getPoints", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<LatLng>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getPoints.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Cap StartCap
		{
			[Register("getStartCap", "()Lcom/google/android/gms/maps/model/Cap;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStartCap.()Lcom/google/android/gms/maps/model/Cap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Width
		{
			[Register("getWidth", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getWidth.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		internal PolylineOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PolylineOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("add", "(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions Add(LatLng point)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.(Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(point);
			}
		}

		[Register("add", "([Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions Add(params LatLng[] points)
		{
			IntPtr intPtr = JNIEnv.NewArray(points);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("add.([Lcom/google/android/gms/maps/model/LatLng;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (points != null)
				{
					JNIEnv.CopyArray(intPtr, points);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(points);
			}
		}

		[Register("addAll", "(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions AddAll(IIterable points)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((points == null) ? IntPtr.Zero : ((Java.Lang.Object)points).Handle);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("addAll.(Ljava/lang/Iterable;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(points);
			}
		}

		[Register("clickable", "(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions Clickable(bool clickable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(clickable);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("clickable.(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("color", "(I)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("color.(I)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("endCap", "(Lcom/google/android/gms/maps/model/Cap;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeEndCap(Cap endCap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(endCap?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("endCap.(Lcom/google/android/gms/maps/model/Cap;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(endCap);
			}
		}

		[Register("geodesic", "(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions Geodesic(bool geodesic)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(geodesic);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("geodesic.(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("jointType", "(I)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeJointType(int jointType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(jointType);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("jointType.(I)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("pattern", "(Ljava/util/List;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokePattern(IList<PatternItem> pattern)
		{
			IntPtr intPtr = JavaList<PatternItem>.ToLocalJniHandle(pattern);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("pattern.(Ljava/util/List;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(pattern);
			}
		}

		[Register("startCap", "(Lcom/google/android/gms/maps/model/Cap;)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeStartCap(Cap startCap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(startCap?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("startCap.(Lcom/google/android/gms/maps/model/Cap;)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(startCap);
			}
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("width", "(F)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeWidth(float width)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(width);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("width.(F)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/PolylineOptions;", "")]
		public unsafe PolylineOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<PolylineOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/PolylineOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/Tile", DoNotGenerateAcw = true)]
	public sealed class Tile : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/Tile", typeof(Tile));

		[Register("data")]
		public IList<byte> Data
		{
			get
			{
				return Android.Runtime.JavaArray<byte>.FromJniHandle(_members.InstanceFields.GetObjectValue("data.[B", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<byte>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("data.[B", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("height")]
		public int Height
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("height.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("height.I", this, value);
			}
		}

		[Register("width")]
		public int Width
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("width.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("width.I", this, value);
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

		internal Tile(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(II[B)V", "")]
		public unsafe Tile(int width, int height, byte[] data)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewArray(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II[B)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II[B)V", this, ptr);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(data);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("com/google/android/gms/maps/model/TileOverlay", DoNotGenerateAcw = true)]
	public sealed class TileOverlay : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/TileOverlay", typeof(TileOverlay));

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

		public unsafe bool FadeIn
		{
			[Register("getFadeIn", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("getFadeIn.()Z", this, null);
			}
			[Register("setFadeIn", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setFadeIn.(Z)V", this, ptr);
			}
		}

		public unsafe string Id
		{
			[Register("getId", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Transparency
		{
			[Register("getTransparency", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getTransparency.()F", this, null);
			}
			[Register("setTransparency", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTransparency.(F)V", this, ptr);
			}
		}

		public unsafe bool Visible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
			[Register("setVisible", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
			[Register("setZIndex", "(F)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
			}
		}

		internal TileOverlay(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("clearTileCache", "()V", "")]
		public unsafe void ClearTileCache()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clearTileCache.()V", this, null);
		}

		[Register("remove", "()V", "")]
		public unsafe void Remove()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
		}
	}
	[Register("com/google/android/gms/maps/model/TileOverlayOptions", DoNotGenerateAcw = true)]
	public sealed class TileOverlayOptions : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/TileOverlayOptions", typeof(TileOverlayOptions));

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

		public unsafe bool FadeIn
		{
			[Register("getFadeIn", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("getFadeIn.()Z", this, null);
			}
		}

		public unsafe bool IsVisible
		{
			[Register("isVisible", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
			}
		}

		public unsafe ITileProvider TileProvider
		{
			[Register("getTileProvider", "()Lcom/google/android/gms/maps/model/TileProvider;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ITileProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTileProvider.()Lcom/google/android/gms/maps/model/TileProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe float Transparency
		{
			[Register("getTransparency", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getTransparency.()F", this, null);
			}
		}

		public unsafe float ZIndex
		{
			[Register("getZIndex", "()F", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
			}
		}

		internal TileOverlayOptions(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe TileOverlayOptions()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("fadeIn", "(Z)Lcom/google/android/gms/maps/model/TileOverlayOptions;", "")]
		public unsafe TileOverlayOptions InvokeFadeIn(bool fadeIn)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fadeIn);
			return Java.Lang.Object.GetObject<TileOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("fadeIn.(Z)Lcom/google/android/gms/maps/model/TileOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("tileProvider", "(Lcom/google/android/gms/maps/model/TileProvider;)Lcom/google/android/gms/maps/model/TileOverlayOptions;", "")]
		public unsafe TileOverlayOptions InvokeTileProvider(ITileProvider tileProvider)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((tileProvider == null) ? IntPtr.Zero : ((Java.Lang.Object)tileProvider).Handle);
				return Java.Lang.Object.GetObject<TileOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("tileProvider.(Lcom/google/android/gms/maps/model/TileProvider;)Lcom/google/android/gms/maps/model/TileOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(tileProvider);
			}
		}

		[Register("transparency", "(F)Lcom/google/android/gms/maps/model/TileOverlayOptions;", "")]
		public unsafe TileOverlayOptions InvokeTransparency(float transparency)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transparency);
			return Java.Lang.Object.GetObject<TileOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("transparency.(F)Lcom/google/android/gms/maps/model/TileOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("visible", "(Z)Lcom/google/android/gms/maps/model/TileOverlayOptions;", "")]
		public unsafe TileOverlayOptions Visible(bool visible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible);
			return Java.Lang.Object.GetObject<TileOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("visible.(Z)Lcom/google/android/gms/maps/model/TileOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("zIndex", "(F)Lcom/google/android/gms/maps/model/TileOverlayOptions;", "")]
		public unsafe TileOverlayOptions InvokeZIndex(float zIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex);
			return Java.Lang.Object.GetObject<TileOverlayOptions>(_members.InstanceMethods.InvokeAbstractObjectMethod("zIndex.(F)Lcom/google/android/gms/maps/model/TileOverlayOptions;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/android/gms/maps/model/VisibleRegion", DoNotGenerateAcw = true)]
	public sealed class VisibleRegion : AbstractSafeParcelable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/maps/model/VisibleRegion", typeof(VisibleRegion));

		[Register("farLeft")]
		public LatLng FarLeft
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("farLeft.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("farLeft.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("farRight")]
		public LatLng FarRight
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("farRight.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("farRight.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("latLngBounds")]
		public LatLngBounds LatLngBounds
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLngBounds>(_members.InstanceFields.GetObjectValue("latLngBounds.Lcom/google/android/gms/maps/model/LatLngBounds;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("latLngBounds.Lcom/google/android/gms/maps/model/LatLngBounds;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("nearLeft")]
		public LatLng NearLeft
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("nearLeft.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("nearLeft.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("nearRight")]
		public LatLng NearRight
		{
			get
			{
				return Java.Lang.Object.GetObject<LatLng>(_members.InstanceFields.GetObjectValue("nearRight.Lcom/google/android/gms/maps/model/LatLng;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("nearRight.Lcom/google/android/gms/maps/model/LatLng;", this, new JniObjectReference(jobject));
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

		internal VisibleRegion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLngBounds;)V", "")]
		public unsafe VisibleRegion(LatLng nearLeft, LatLng nearRight, LatLng farLeft, LatLng farRight, LatLngBounds latLngBounds)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(nearLeft?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(nearRight?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(farLeft?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(farRight?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(latLngBounds?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLngBounds;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLng;Lcom/google/android/gms/maps/model/LatLngBounds;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(nearLeft);
				GC.KeepAlive(nearRight);
				GC.KeepAlive(farLeft);
				GC.KeepAlive(farRight);
				GC.KeepAlive(latLngBounds);
			}
		}

		[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
		public unsafe override void WriteToParcel(Parcel @out, [GeneratedEnum] ParcelableWriteFlags flags)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)flags);
				_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}
	}
}
