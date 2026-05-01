using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Common.Internal.SafeParcel;
using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Android.Locations;
using Android.OS;
using Android.Runtime;
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
[assembly: NamespaceMapping(Java = "com.google.android.gms.location", Managed = "Android.Gms.Location")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("\r\n        Xamarin.Android Bindings for Google Play Services - Location 118.0.0.5 artifact=com.google.android.gms:play-services-location artifact_versioned=com.google.android.gms:play-services-location:18.0.0\r\n\r\n        \r\n    ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.GooglePlayServices.Location")]
[assembly: AssemblyTitle("Xamarin.GooglePlayServices.Location")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/GooglePlayServicesComponents.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3);
internal delegate IntPtr _JniMarshal_PPLZ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate IntPtr _JniMarshal_PPZ_L(IntPtr jnienv, IntPtr klass, bool p0);
namespace Android.Gms.Location;

[Register("com/google/android/gms/location/LocationServices", DoNotGenerateAcw = true)]
public class LocationServices : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationServices", typeof(LocationServices));

	public static Api Api => API;

	[Register("API")]
	public static Api API => Java.Lang.Object.GetObject<Api>(_members.StaticFields.GetObjectValue("API.Lcom/google/android/gms/common/api/Api;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FusedLocationApi")]
	public static IFusedLocationProviderApi FusedLocationApi => Java.Lang.Object.GetObject<IFusedLocationProviderApi>(_members.StaticFields.GetObjectValue("FusedLocationApi.Lcom/google/android/gms/location/FusedLocationProviderApi;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("GeofencingApi")]
	public static IGeofencingApi GeofencingApi => Java.Lang.Object.GetObject<IGeofencingApi>(_members.StaticFields.GetObjectValue("GeofencingApi.Lcom/google/android/gms/location/GeofencingApi;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SettingsApi")]
	public static ISettingsApi SettingsApi => Java.Lang.Object.GetObject<ISettingsApi>(_members.StaticFields.GetObjectValue("SettingsApi.Lcom/google/android/gms/location/SettingsApi;").Handle, JniHandleOwnership.TransferLocalRef);

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

	protected LocationServices(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getFusedLocationProviderClient", "(Landroid/app/Activity;)Lcom/google/android/gms/location/FusedLocationProviderClient;", "")]
	public unsafe static FusedLocationProviderClient GetFusedLocationProviderClient(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FusedLocationProviderClient>(_members.StaticMethods.InvokeObjectMethod("getFusedLocationProviderClient.(Landroid/app/Activity;)Lcom/google/android/gms/location/FusedLocationProviderClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("getFusedLocationProviderClient", "(Landroid/content/Context;)Lcom/google/android/gms/location/FusedLocationProviderClient;", "")]
	public unsafe static FusedLocationProviderClient GetFusedLocationProviderClient(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FusedLocationProviderClient>(_members.StaticMethods.InvokeObjectMethod("getFusedLocationProviderClient.(Landroid/content/Context;)Lcom/google/android/gms/location/FusedLocationProviderClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getGeofencingClient", "(Landroid/app/Activity;)Lcom/google/android/gms/location/GeofencingClient;", "")]
	public unsafe static GeofencingClient GetGeofencingClient(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GeofencingClient>(_members.StaticMethods.InvokeObjectMethod("getGeofencingClient.(Landroid/app/Activity;)Lcom/google/android/gms/location/GeofencingClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("getGeofencingClient", "(Landroid/content/Context;)Lcom/google/android/gms/location/GeofencingClient;", "")]
	public unsafe static GeofencingClient GetGeofencingClient(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GeofencingClient>(_members.StaticMethods.InvokeObjectMethod("getGeofencingClient.(Landroid/content/Context;)Lcom/google/android/gms/location/GeofencingClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getSettingsClient", "(Landroid/app/Activity;)Lcom/google/android/gms/location/SettingsClient;", "")]
	public unsafe static SettingsClient GetSettingsClient(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SettingsClient>(_members.StaticMethods.InvokeObjectMethod("getSettingsClient.(Landroid/app/Activity;)Lcom/google/android/gms/location/SettingsClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Register("getSettingsClient", "(Landroid/content/Context;)Lcom/google/android/gms/location/SettingsClient;", "")]
	public unsafe static SettingsClient GetSettingsClient(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<SettingsClient>(_members.StaticMethods.InvokeObjectMethod("getSettingsClient.(Landroid/content/Context;)Lcom/google/android/gms/location/SettingsClient;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
public class LocationCallbackResultEventArgs : EventArgs
{
	[CompilerGenerated]
	private LocationResult <Result>k__BackingField;

	private LocationResult Result
	{
		[CompilerGenerated]
		set
		{
			<Result>k__BackingField = value;
		}
	}

	public LocationCallbackResultEventArgs(LocationResult result)
	{
		Result = result;
	}
}
public class LocationCallbackAvailabilityEventArgs : EventArgs
{
	[CompilerGenerated]
	private LocationAvailability <Availability>k__BackingField;

	private LocationAvailability Availability
	{
		[CompilerGenerated]
		set
		{
			<Availability>k__BackingField = value;
		}
	}

	public LocationCallbackAvailabilityEventArgs(LocationAvailability availability)
	{
		Availability = availability;
	}
}
public class LocationCallback : LocationCallbackBase
{
	public event EventHandler<LocationCallbackResultEventArgs> LocationResult;

	public event EventHandler<LocationCallbackAvailabilityEventArgs> LocationAvailability;

	public override void OnLocationResult(LocationResult result)
	{
		base.OnLocationResult(result);
		this.LocationResult?.Invoke(this, new LocationCallbackResultEventArgs(result));
	}

	public override void OnLocationAvailability(LocationAvailability locationAvailability)
	{
		base.OnLocationAvailability(locationAvailability);
		this.LocationAvailability?.Invoke(this, new LocationCallbackAvailabilityEventArgs(locationAvailability));
	}
}
public static class ISettingsApiExtensions
{
	public static async Task<LocationSettingsResult> CheckLocationSettingsAsync(this ISettingsApi api, GoogleApiClient client, LocationSettingsRequest request)
	{
		return Android.Runtime.Extensions.JavaCast<LocationSettingsResult>(await api.CheckLocationSettings(client, request));
	}
}
[Register("com/google/android/gms/location/FusedLocationProviderClient", DoNotGenerateAcw = true)]
public class FusedLocationProviderClient : GoogleApi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/FusedLocationProviderClient", typeof(FusedLocationProviderClient));

	private static Delegate cb_flushLocations;

	private static Delegate cb_getCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_;

	private static Delegate cb_getLastLocation;

	private static Delegate cb_getLocationAvailability;

	private static Delegate cb_removeLocationUpdates_Landroid_app_PendingIntent_;

	private static Delegate cb_removeLocationUpdates_Lcom_google_android_gms_location_LocationCallback_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_;

	private static Delegate cb_setMockLocation_Landroid_location_Location_;

	private static Delegate cb_setMockMode_Z;

	public Android.Gms.Tasks.Task LastLocation => GetLastLocation();

	public Android.Gms.Tasks.Task LocationAvailability => GetLocationAvailability();

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

	public Task<Android.Locations.Location> GetLastLocationAsync()
	{
		return GetLastLocation().AsAsync<Android.Locations.Location>();
	}

	public Task<LocationAvailability> GetLocationAvailabilityAsync()
	{
		return GetLocationAvailability().AsAsync<LocationAvailability>();
	}

	public System.Threading.Tasks.Task FlushLocationsAsync()
	{
		return FlushLocations().AsAsync();
	}

	public System.Threading.Tasks.Task RemoveLocationUpdatesAsync(LocationCallback callback)
	{
		return RemoveLocationUpdates(callback).AsAsync();
	}

	public System.Threading.Tasks.Task RemoveLocationUpdatesAsync(PendingIntent pendingIntent)
	{
		return RemoveLocationUpdates(pendingIntent).AsAsync();
	}

	public System.Threading.Tasks.Task RequestLocationUpdatesAsync(LocationRequest locationRequest, LocationCallback callback, Looper looper = null)
	{
		return RequestLocationUpdates(locationRequest, callback, looper).AsAsync();
	}

	public System.Threading.Tasks.Task RequestLocationUpdatesAsync(LocationRequest locationRequest, PendingIntent pendingIntent)
	{
		return RequestLocationUpdates(locationRequest, pendingIntent).AsAsync();
	}

	public System.Threading.Tasks.Task SetMockLocationAsync(Android.Locations.Location location)
	{
		return SetMockLocation(location).AsAsync();
	}

	public System.Threading.Tasks.Task SetMockModeAsync(bool mock)
	{
		return SetMockMode(mock).AsAsync();
	}

	protected FusedLocationProviderClient(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/app/Activity;)V", "")]
	public unsafe FusedLocationProviderClient(Activity p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe FusedLocationProviderClient(Context p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetFlushLocationsHandler()
	{
		if ((object)cb_flushLocations == null)
		{
			cb_flushLocations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_FlushLocations));
		}
		return cb_flushLocations;
	}

	private static IntPtr n_FlushLocations(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlushLocations());
	}

	[Register("flushLocations", "()Lcom/google/android/gms/tasks/Task;", "GetFlushLocationsHandler")]
	public unsafe virtual Android.Gms.Tasks.Task FlushLocations()
	{
		return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("flushLocations.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_Handler()
	{
		if ((object)cb_getCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_ == null)
		{
			cb_getCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_GetCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_));
		}
		return cb_getCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_;
	}

	private static IntPtr n_GetCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CancellationToken p1 = Java.Lang.Object.GetObject<CancellationToken>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.GetCurrentLocation(p0, p1));
	}

	[Register("getCurrentLocation", "(ILcom/google/android/gms/tasks/CancellationToken;)Lcom/google/android/gms/tasks/Task;", "GetGetCurrentLocation_ILcom_google_android_gms_tasks_CancellationToken_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task GetCurrentLocation(int p0, CancellationToken p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentLocation.(ILcom/google/android/gms/tasks/CancellationToken;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetLastLocationHandler()
	{
		if ((object)cb_getLastLocation == null)
		{
			cb_getLastLocation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastLocation));
		}
		return cb_getLastLocation;
	}

	private static IntPtr n_GetLastLocation(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLastLocation());
	}

	[Register("getLastLocation", "()Lcom/google/android/gms/tasks/Task;", "GetGetLastLocationHandler")]
	public unsafe virtual Android.Gms.Tasks.Task GetLastLocation()
	{
		return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLastLocation.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLocationAvailabilityHandler()
	{
		if ((object)cb_getLocationAvailability == null)
		{
			cb_getLocationAvailability = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLocationAvailability));
		}
		return cb_getLocationAvailability;
	}

	private static IntPtr n_GetLocationAvailability(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLocationAvailability());
	}

	[Register("getLocationAvailability", "()Lcom/google/android/gms/tasks/Task;", "GetGetLocationAvailabilityHandler")]
	public unsafe virtual Android.Gms.Tasks.Task GetLocationAvailability()
	{
		return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLocationAvailability.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveLocationUpdates_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_removeLocationUpdates_Landroid_app_PendingIntent_ == null)
		{
			cb_removeLocationUpdates_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveLocationUpdates_Landroid_app_PendingIntent_));
		}
		return cb_removeLocationUpdates_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RemoveLocationUpdates_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_callbackIntent)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PendingIntent callbackIntent = Java.Lang.Object.GetObject<PendingIntent>(native_callbackIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.RemoveLocationUpdates(callbackIntent));
	}

	[Register("removeLocationUpdates", "(Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", "GetRemoveLocationUpdates_Landroid_app_PendingIntent_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RemoveLocationUpdates(PendingIntent callbackIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callbackIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeLocationUpdates.(Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callbackIntent);
		}
	}

	private static Delegate GetRemoveLocationUpdates_Lcom_google_android_gms_location_LocationCallback_Handler()
	{
		if ((object)cb_removeLocationUpdates_Lcom_google_android_gms_location_LocationCallback_ == null)
		{
			cb_removeLocationUpdates_Lcom_google_android_gms_location_LocationCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveLocationUpdates_Lcom_google_android_gms_location_LocationCallback_));
		}
		return cb_removeLocationUpdates_Lcom_google_android_gms_location_LocationCallback_;
	}

	private static IntPtr n_RemoveLocationUpdates_Lcom_google_android_gms_location_LocationCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationCallbackBase callback = Java.Lang.Object.GetObject<LocationCallbackBase>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.RemoveLocationUpdates(callback));
	}

	[Register("removeLocationUpdates", "(Lcom/google/android/gms/location/LocationCallback;)Lcom/google/android/gms/tasks/Task;", "GetRemoveLocationUpdates_Lcom_google_android_gms_location_LocationCallback_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RemoveLocationUpdates(LocationCallbackBase callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeLocationUpdates.(Lcom/google/android/gms/location/LocationCallback;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native_callbackIntent)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		PendingIntent callbackIntent = Java.Lang.Object.GetObject<PendingIntent>(native_callbackIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.RequestLocationUpdates(request, callbackIntent));
	}

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/location/LocationRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", "GetRequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RequestLocationUpdates(LocationRequest request, PendingIntent callbackIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callbackIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("requestLocationUpdates.(Lcom/google/android/gms/location/LocationRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(callbackIntent);
		}
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_(IntPtr jnienv, IntPtr native__this, IntPtr native_request, IntPtr native__callback, IntPtr native_looper)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		LocationCallbackBase callback = Java.Lang.Object.GetObject<LocationCallbackBase>(native__callback, JniHandleOwnership.DoNotTransfer);
		Looper looper = Java.Lang.Object.GetObject<Looper>(native_looper, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.RequestLocationUpdates(request, callback, looper));
	}

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationCallback;Landroid/os/Looper;)Lcom/google/android/gms/tasks/Task;", "GetRequestLocationUpdates_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RequestLocationUpdates(LocationRequest request, LocationCallbackBase callback, Looper looper)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(request?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(looper?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("requestLocationUpdates.(Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationCallback;Landroid/os/Looper;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(callback);
			GC.KeepAlive(looper);
		}
	}

	private static Delegate GetSetMockLocation_Landroid_location_Location_Handler()
	{
		if ((object)cb_setMockLocation_Landroid_location_Location_ == null)
		{
			cb_setMockLocation_Landroid_location_Location_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetMockLocation_Landroid_location_Location_));
		}
		return cb_setMockLocation_Landroid_location_Location_;
	}

	private static IntPtr n_SetMockLocation_Landroid_location_Location_(IntPtr jnienv, IntPtr native__this, IntPtr native_mockLocation)
	{
		FusedLocationProviderClient fusedLocationProviderClient = Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.Locations.Location mockLocation = Java.Lang.Object.GetObject<Android.Locations.Location>(native_mockLocation, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderClient.SetMockLocation(mockLocation));
	}

	[Register("setMockLocation", "(Landroid/location/Location;)Lcom/google/android/gms/tasks/Task;", "GetSetMockLocation_Landroid_location_Location_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task SetMockLocation(Android.Locations.Location mockLocation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mockLocation?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMockLocation.(Landroid/location/Location;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(mockLocation);
		}
	}

	private static Delegate GetSetMockMode_ZHandler()
	{
		if ((object)cb_setMockMode_Z == null)
		{
			cb_setMockMode_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_L(n_SetMockMode_Z));
		}
		return cb_setMockMode_Z;
	}

	private static IntPtr n_SetMockMode_Z(IntPtr jnienv, IntPtr native__this, bool isMockMode)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FusedLocationProviderClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMockMode(isMockMode));
	}

	[Register("setMockMode", "(Z)Lcom/google/android/gms/tasks/Task;", "GetSetMockMode_ZHandler")]
	public unsafe virtual Android.Gms.Tasks.Task SetMockMode(bool isMockMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isMockMode);
		return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMockMode.(Z)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
[Register("com/google/android/gms/location/GeofencingClient", DoNotGenerateAcw = true)]
public class GeofencingClient : GoogleApi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/GeofencingClient", typeof(GeofencingClient));

	private static Delegate cb_addGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_;

	private static Delegate cb_removeGeofences_Landroid_app_PendingIntent_;

	private static Delegate cb_removeGeofences_Ljava_util_List_;

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

	public System.Threading.Tasks.Task AddGeofencesAsync(GeofencingRequest geofenceRequest, PendingIntent pendingIntent)
	{
		return AddGeofences(geofenceRequest, pendingIntent).AsAsync();
	}

	public System.Threading.Tasks.Task RemoveGeofencesAsync(PendingIntent pendingIntent)
	{
		return RemoveGeofences(pendingIntent).AsAsync();
	}

	public System.Threading.Tasks.Task RemoveGeofencesAsync(IList<string> geofenceRequestIds)
	{
		return RemoveGeofences(geofenceRequestIds).AsAsync();
	}

	protected GeofencingClient(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/app/Activity;)V", "")]
	public unsafe GeofencingClient(Activity p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe GeofencingClient(Context p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_addGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ == null)
		{
			cb_addGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_));
		}
		return cb_addGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_AddGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_geofencingRequest, IntPtr native_pendingIntent)
	{
		GeofencingClient geofencingClient = Java.Lang.Object.GetObject<GeofencingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GeofencingRequest geofencingRequest = Java.Lang.Object.GetObject<GeofencingRequest>(native_geofencingRequest, JniHandleOwnership.DoNotTransfer);
		PendingIntent pendingIntent = Java.Lang.Object.GetObject<PendingIntent>(native_pendingIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingClient.AddGeofences(geofencingRequest, pendingIntent));
	}

	[Register("addGeofences", "(Lcom/google/android/gms/location/GeofencingRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", "GetAddGeofences_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task AddGeofences(GeofencingRequest geofencingRequest, PendingIntent pendingIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(geofencingRequest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addGeofences.(Lcom/google/android/gms/location/GeofencingRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(geofencingRequest);
			GC.KeepAlive(pendingIntent);
		}
	}

	private static Delegate GetRemoveGeofences_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_removeGeofences_Landroid_app_PendingIntent_ == null)
		{
			cb_removeGeofences_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveGeofences_Landroid_app_PendingIntent_));
		}
		return cb_removeGeofences_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RemoveGeofences_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_pendingIntent)
	{
		GeofencingClient geofencingClient = Java.Lang.Object.GetObject<GeofencingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PendingIntent pendingIntent = Java.Lang.Object.GetObject<PendingIntent>(native_pendingIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingClient.RemoveGeofences(pendingIntent));
	}

	[Register("removeGeofences", "(Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", "GetRemoveGeofences_Landroid_app_PendingIntent_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RemoveGeofences(PendingIntent pendingIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pendingIntent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeGeofences.(Landroid/app/PendingIntent;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(pendingIntent);
		}
	}

	private static Delegate GetRemoveGeofences_Ljava_util_List_Handler()
	{
		if ((object)cb_removeGeofences_Ljava_util_List_ == null)
		{
			cb_removeGeofences_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveGeofences_Ljava_util_List_));
		}
		return cb_removeGeofences_Ljava_util_List_;
	}

	private static IntPtr n_RemoveGeofences_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_geofenceRequestIds)
	{
		GeofencingClient geofencingClient = Java.Lang.Object.GetObject<GeofencingClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<string> geofenceRequestIds = JavaList<string>.FromJniHandle(native_geofenceRequestIds, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingClient.RemoveGeofences(geofenceRequestIds));
	}

	[Register("removeGeofences", "(Ljava/util/List;)Lcom/google/android/gms/tasks/Task;", "GetRemoveGeofences_Ljava_util_List_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task RemoveGeofences(IList<string> geofenceRequestIds)
	{
		IntPtr intPtr = JavaList<string>.ToLocalJniHandle(geofenceRequestIds);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeGeofences.(Ljava/util/List;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(geofenceRequestIds);
		}
	}
}
[Register("com/google/android/gms/location/SettingsClient", DoNotGenerateAcw = true)]
public class SettingsClient : GoogleApi
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/SettingsClient", typeof(SettingsClient));

	private static Delegate cb_checkLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_;

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

	public Task<LocationSettingsResponse> CheckLocationSettingsAsync(LocationSettingsRequest locationSettings)
	{
		return CheckLocationSettings(locationSettings).AsAsync<LocationSettingsResponse>();
	}

	protected SettingsClient(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/app/Activity;)V", "")]
	public unsafe SettingsClient(Activity p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe SettingsClient(Context p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetCheckLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_Handler()
	{
		if ((object)cb_checkLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_ == null)
		{
			cb_checkLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CheckLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_));
		}
		return cb_checkLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_;
	}

	private static IntPtr n_CheckLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_(IntPtr jnienv, IntPtr native__this, IntPtr native_locationSettingsRequest)
	{
		SettingsClient settingsClient = Java.Lang.Object.GetObject<SettingsClient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationSettingsRequest locationSettingsRequest = Java.Lang.Object.GetObject<LocationSettingsRequest>(native_locationSettingsRequest, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(settingsClient.CheckLocationSettings(locationSettingsRequest));
	}

	[Register("checkLocationSettings", "(Lcom/google/android/gms/location/LocationSettingsRequest;)Lcom/google/android/gms/tasks/Task;", "GetCheckLocationSettings_Lcom_google_android_gms_location_LocationSettingsRequest_Handler")]
	public unsafe virtual Android.Gms.Tasks.Task CheckLocationSettings(LocationSettingsRequest locationSettingsRequest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationSettingsRequest?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Gms.Tasks.Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("checkLocationSettings.(Lcom/google/android/gms/location/LocationSettingsRequest;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(locationSettingsRequest);
		}
	}
}
[Register("com/google/android/gms/location/GeofencingRequest", DoNotGenerateAcw = true)]
public class GeofencingRequest : AbstractSafeParcelable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/GeofencingRequest", typeof(GeofencingRequest));

	private static Delegate cb_getGeofences;

	private static Delegate cb_getInitialTrigger;

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

	public unsafe virtual IList<IGeofence> Geofences
	{
		[Register("getGeofences", "()Ljava/util/List;", "GetGetGeofencesHandler")]
		get
		{
			return JavaList<IGeofence>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getGeofences.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int InitialTrigger
	{
		[Register("getInitialTrigger", "()I", "GetGetInitialTriggerHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInitialTrigger.()I", this, null);
		}
	}

	protected GeofencingRequest(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetGeofencesHandler()
	{
		if ((object)cb_getGeofences == null)
		{
			cb_getGeofences = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeofences));
		}
		return cb_getGeofences;
	}

	private static IntPtr n_GetGeofences(IntPtr jnienv, IntPtr native__this)
	{
		return JavaList<IGeofence>.ToLocalJniHandle(Java.Lang.Object.GetObject<GeofencingRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Geofences);
	}

	private static Delegate GetGetInitialTriggerHandler()
	{
		if ((object)cb_getInitialTrigger == null)
		{
			cb_getInitialTrigger = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetInitialTrigger));
		}
		return cb_getInitialTrigger;
	}

	private static int n_GetInitialTrigger(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<GeofencingRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitialTrigger;
	}

	private static Delegate GetWriteToParcel_Landroid_os_Parcel_IHandler()
	{
		if ((object)cb_writeToParcel_Landroid_os_Parcel_I == null)
		{
			cb_writeToParcel_Landroid_os_Parcel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_WriteToParcel_Landroid_os_Parcel_I));
		}
		return cb_writeToParcel_Landroid_os_Parcel_I;
	}

	private static void n_WriteToParcel_Landroid_os_Parcel_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dest, int native_flags)
	{
		GeofencingRequest geofencingRequest = Java.Lang.Object.GetObject<GeofencingRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Parcel dest = Java.Lang.Object.GetObject<Parcel>(native_dest, JniHandleOwnership.DoNotTransfer);
		geofencingRequest.WriteToParcel(dest, (ParcelableWriteFlags)native_flags);
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}
[Register("com/google/android/gms/location/FusedLocationProviderApi", "", "Android.Gms.Location.IFusedLocationProviderApiInvoker")]
public interface IFusedLocationProviderApi : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("flushLocations", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;", "GetFlushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult FlushLocations(GoogleApiClient client);

	[Register("getLastLocation", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Landroid/location/Location;", "GetGetLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	Android.Locations.Location GetLastLocation(GoogleApiClient client);

	[Register("getLocationAvailability", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/location/LocationAvailability;", "GetGetLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	LocationAvailability GetLocationAvailability(GoogleApiClient client);

	[Register("removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;", "GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RemoveLocationUpdates(GoogleApiClient client, PendingIntent callbackIntent);

	[Register("removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationCallback;)Lcom/google/android/gms/common/api/PendingResult;", "GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RemoveLocationUpdates(GoogleApiClient client, LocationCallbackBase callback);

	[Register("removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationListener;)Lcom/google/android/gms/common/api/PendingResult;", "GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RemoveLocationUpdates(GoogleApiClient client, ILocationListener listener);

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;", "GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, PendingIntent callbackIntent);

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationCallback;Landroid/os/Looper;)Lcom/google/android/gms/common/api/PendingResult;", "GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, LocationCallbackBase callback, Looper looper);

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationListener;)Lcom/google/android/gms/common/api/PendingResult;", "GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, ILocationListener listener);

	[Register("requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationListener;Landroid/os/Looper;)Lcom/google/android/gms/common/api/PendingResult;", "GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, ILocationListener listener, Looper looper);

	[Register("setMockLocation", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/location/Location;)Lcom/google/android/gms/common/api/PendingResult;", "GetSetMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_Handler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult SetMockLocation(GoogleApiClient client, Android.Locations.Location mockLocation);

	[Register("setMockMode", "(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;", "GetSetMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_ZHandler:Android.Gms.Location.IFusedLocationProviderApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult SetMockMode(GoogleApiClient client, bool isMockMode);
}
[Register("com/google/android/gms/location/FusedLocationProviderApi", DoNotGenerateAcw = true)]
internal class IFusedLocationProviderApiInvoker : Java.Lang.Object, IFusedLocationProviderApi, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/FusedLocationProviderApi", typeof(IFusedLocationProviderApiInvoker));

	private IntPtr class_ref;

	private static Delegate cb_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private IntPtr id_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private static Delegate cb_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private IntPtr id_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private static Delegate cb_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private IntPtr id_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_;

	private static Delegate cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;

	private IntPtr id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;

	private static Delegate cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_;

	private IntPtr id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_;

	private static Delegate cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_;

	private IntPtr id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_;

	private IntPtr id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_;

	private IntPtr id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_;

	private IntPtr id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_;

	private static Delegate cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_;

	private IntPtr id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_;

	private static Delegate cb_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_;

	private IntPtr id_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_;

	private static Delegate cb_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z;

	private IntPtr id_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z;

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

	public static IFusedLocationProviderApi GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IFusedLocationProviderApi>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.location.FusedLocationProviderApi'.");
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

	public IFusedLocationProviderApiInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetFlushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_Handler()
	{
		if ((object)cb_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_ == null)
		{
			cb_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_FlushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_));
		}
		return cb_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_;
	}

	private static IntPtr n_FlushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_(IntPtr jnienv, IntPtr native__this, IntPtr native_client)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.FlushLocations(client));
	}

	public unsafe PendingResult FlushLocations(GoogleApiClient client)
	{
		if (id_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_ == IntPtr.Zero)
		{
			id_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNIEnv.GetMethodID(class_ref, "flushLocations", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_flushLocations_Lcom_google_android_gms_common_api_GoogleApiClient_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Handler()
	{
		if ((object)cb_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_ == null)
		{
			cb_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_));
		}
		return cb_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_;
	}

	private static IntPtr n_GetLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_(IntPtr jnienv, IntPtr native__this, IntPtr native_client)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.GetLastLocation(client));
	}

	public unsafe Android.Locations.Location GetLastLocation(GoogleApiClient client)
	{
		if (id_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_ == IntPtr.Zero)
		{
			id_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNIEnv.GetMethodID(class_ref, "getLastLocation", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Landroid/location/Location;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Android.Locations.Location>(JNIEnv.CallObjectMethod(base.Handle, id_getLastLocation_Lcom_google_android_gms_common_api_GoogleApiClient_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_Handler()
	{
		if ((object)cb_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_ == null)
		{
			cb_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_));
		}
		return cb_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_;
	}

	private static IntPtr n_GetLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_(IntPtr jnienv, IntPtr native__this, IntPtr native_client)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.GetLocationAvailability(client));
	}

	public unsafe LocationAvailability GetLocationAvailability(GoogleApiClient client)
	{
		if (id_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_ == IntPtr.Zero)
		{
			id_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_ = JNIEnv.GetMethodID(class_ref, "getLocationAvailability", "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/location/LocationAvailability;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<LocationAvailability>(JNIEnv.CallObjectMethod(base.Handle, id_getLocationAvailability_Lcom_google_android_gms_common_api_GoogleApiClient_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ == null)
		{
			cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_));
		}
		return cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_callbackIntent)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		PendingIntent callbackIntent = Java.Lang.Object.GetObject<PendingIntent>(native_callbackIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RemoveLocationUpdates(client, callbackIntent));
	}

	public unsafe PendingResult RemoveLocationUpdates(GoogleApiClient client, PendingIntent callbackIntent)
	{
		if (id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ == IntPtr.Zero)
		{
			id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ = JNIEnv.GetMethodID(class_ref, "removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(callbackIntent?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_Handler()
	{
		if ((object)cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_ == null)
		{
			cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_));
		}
		return cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_;
	}

	private static IntPtr n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native__callback)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationCallbackBase callback = Java.Lang.Object.GetObject<LocationCallbackBase>(native__callback, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RemoveLocationUpdates(client, callback));
	}

	public unsafe PendingResult RemoveLocationUpdates(GoogleApiClient client, LocationCallbackBase callback)
	{
		if (id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_ == IntPtr.Zero)
		{
			id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_ = JNIEnv.GetMethodID(class_ref, "removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationCallback;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(callback?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationCallback_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_Handler()
	{
		if ((object)cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_ == null)
		{
			cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_));
		}
		return cb_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_;
	}

	private static IntPtr n_RemoveLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_listener)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		ILocationListener listener = Java.Lang.Object.GetObject<ILocationListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RemoveLocationUpdates(client, listener));
	}

	public unsafe PendingResult RemoveLocationUpdates(GoogleApiClient client, ILocationListener listener)
	{
		if (id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_ == IntPtr.Zero)
		{
			id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_ = JNIEnv.GetMethodID(class_ref, "removeLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationListener;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_removeLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationListener_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_request, IntPtr native_callbackIntent)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		PendingIntent callbackIntent = Java.Lang.Object.GetObject<PendingIntent>(native_callbackIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RequestLocationUpdates(client, request, callbackIntent));
	}

	public unsafe PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, PendingIntent callbackIntent)
	{
		if (id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ == IntPtr.Zero)
		{
			id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_ = JNIEnv.GetMethodID(class_ref, "requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(request?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(callbackIntent?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Landroid_app_PendingIntent_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_request, IntPtr native__callback, IntPtr native_looper)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		LocationCallbackBase callback = Java.Lang.Object.GetObject<LocationCallbackBase>(native__callback, JniHandleOwnership.DoNotTransfer);
		Looper looper = Java.Lang.Object.GetObject<Looper>(native_looper, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RequestLocationUpdates(client, request, callback, looper));
	}

	public unsafe PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, LocationCallbackBase callback, Looper looper)
	{
		if (id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ == IntPtr.Zero)
		{
			id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_ = JNIEnv.GetMethodID(class_ref, "requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationCallback;Landroid/os/Looper;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[4];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(request?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(callback?.Handle ?? IntPtr.Zero);
		ptr[3] = new JValue(looper?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationCallback_Landroid_os_Looper_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_request, IntPtr native_listener)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		ILocationListener listener = Java.Lang.Object.GetObject<ILocationListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RequestLocationUpdates(client, request, listener));
	}

	public unsafe PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, ILocationListener listener)
	{
		if (id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_ == IntPtr.Zero)
		{
			id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_ = JNIEnv.GetMethodID(class_ref, "requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationListener;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(request?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_Handler()
	{
		if ((object)cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_ == null)
		{
			cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_));
		}
		return cb_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_;
	}

	private static IntPtr n_RequestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_request, IntPtr native_listener, IntPtr native_looper)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationRequest request = Java.Lang.Object.GetObject<LocationRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		ILocationListener listener = Java.Lang.Object.GetObject<ILocationListener>(native_listener, JniHandleOwnership.DoNotTransfer);
		Looper looper = Java.Lang.Object.GetObject<Looper>(native_looper, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.RequestLocationUpdates(client, request, listener, looper));
	}

	public unsafe PendingResult RequestLocationUpdates(GoogleApiClient client, LocationRequest request, ILocationListener listener, Looper looper)
	{
		if (id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_ == IntPtr.Zero)
		{
			id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_ = JNIEnv.GetMethodID(class_ref, "requestLocationUpdates", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationRequest;Lcom/google/android/gms/location/LocationListener;Landroid/os/Looper;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[4];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(request?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
		ptr[3] = new JValue(looper?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_requestLocationUpdates_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationRequest_Lcom_google_android_gms_location_LocationListener_Landroid_os_Looper_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_Handler()
	{
		if ((object)cb_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_ == null)
		{
			cb_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_SetMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_));
		}
		return cb_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_;
	}

	private static IntPtr n_SetMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_mockLocation)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		Android.Locations.Location mockLocation = Java.Lang.Object.GetObject<Android.Locations.Location>(native_mockLocation, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.SetMockLocation(client, mockLocation));
	}

	public unsafe PendingResult SetMockLocation(GoogleApiClient client, Android.Locations.Location mockLocation)
	{
		if (id_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_ == IntPtr.Zero)
		{
			id_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_ = JNIEnv.GetMethodID(class_ref, "setMockLocation", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/location/Location;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(mockLocation?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_setMockLocation_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_location_Location_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_ZHandler()
	{
		if ((object)cb_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z == null)
		{
			cb_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_L(n_SetMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z));
		}
		return cb_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z;
	}

	private static IntPtr n_SetMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_client, bool isMockMode)
	{
		IFusedLocationProviderApi fusedLocationProviderApi = Java.Lang.Object.GetObject<IFusedLocationProviderApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fusedLocationProviderApi.SetMockMode(client, isMockMode));
	}

	public unsafe PendingResult SetMockMode(GoogleApiClient client, bool isMockMode)
	{
		if (id_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z == IntPtr.Zero)
		{
			id_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z = JNIEnv.GetMethodID(class_ref, "setMockMode", "(Lcom/google/android/gms/common/api/GoogleApiClient;Z)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(isMockMode);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_setMockMode_Lcom_google_android_gms_common_api_GoogleApiClient_Z, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
[Register("com/google/android/gms/location/Geofence", "", "Android.Gms.Location.IGeofenceInvoker")]
public interface IGeofence : IJavaObject, IDisposable, IJavaPeerable
{
	string RequestId
	{
		[Register("getRequestId", "()Ljava/lang/String;", "GetGetRequestIdHandler:Android.Gms.Location.IGeofenceInvoker, Xamarin.GooglePlayServices.Location")]
		get;
	}
}
[Register("com/google/android/gms/location/Geofence", DoNotGenerateAcw = true)]
internal class IGeofenceInvoker : Java.Lang.Object, IGeofence, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/Geofence", typeof(IGeofenceInvoker));

	private IntPtr class_ref;

	private static Delegate cb_getRequestId;

	private IntPtr id_getRequestId;

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

	public string RequestId
	{
		get
		{
			if (id_getRequestId == IntPtr.Zero)
			{
				id_getRequestId = JNIEnv.GetMethodID(class_ref, "getRequestId", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getRequestId), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IGeofence GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IGeofence>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.location.Geofence'.");
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

	public IGeofenceInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetRequestIdHandler()
	{
		if ((object)cb_getRequestId == null)
		{
			cb_getRequestId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRequestId));
		}
		return cb_getRequestId;
	}

	private static IntPtr n_GetRequestId(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IGeofence>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestId);
	}
}
[Register("com/google/android/gms/location/GeofencingApi", "", "Android.Gms.Location.IGeofencingApiInvoker")]
public interface IGeofencingApi : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/GeofencingRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;", "GetAddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_Handler:Android.Gms.Location.IGeofencingApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult AddGeofences(GoogleApiClient client, GeofencingRequest geofencingRequest, PendingIntent pendingIntent);

	[Register("addGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Ljava/util/List;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;", "GetAddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_Handler:Android.Gms.Location.IGeofencingApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult AddGeofences(GoogleApiClient client, IList<IGeofence> geofences, PendingIntent pendingIntent);

	[Register("removeGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;", "GetRemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_Handler:Android.Gms.Location.IGeofencingApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RemoveGeofences(GoogleApiClient client, PendingIntent pendingIntent);

	[Register("removeGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Ljava/util/List;)Lcom/google/android/gms/common/api/PendingResult;", "GetRemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Handler:Android.Gms.Location.IGeofencingApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult RemoveGeofences(GoogleApiClient client, IList<string> geofenceRequestIds);
}
[Register("com/google/android/gms/location/GeofencingApi", DoNotGenerateAcw = true)]
internal class IGeofencingApiInvoker : Java.Lang.Object, IGeofencingApi, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/GeofencingApi", typeof(IGeofencingApiInvoker));

	private IntPtr class_ref;

	private static Delegate cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_;

	private IntPtr id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_;

	private static Delegate cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_;

	private IntPtr id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_;

	private static Delegate cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;

	private IntPtr id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;

	private static Delegate cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_;

	private IntPtr id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_;

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

	public static IGeofencingApi GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IGeofencingApi>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.location.GeofencingApi'.");
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

	public IGeofencingApiInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetAddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ == null)
		{
			cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_));
		}
		return cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_AddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_geofencingRequest, IntPtr native_pendingIntent)
	{
		IGeofencingApi geofencingApi = Java.Lang.Object.GetObject<IGeofencingApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		GeofencingRequest geofencingRequest = Java.Lang.Object.GetObject<GeofencingRequest>(native_geofencingRequest, JniHandleOwnership.DoNotTransfer);
		PendingIntent pendingIntent = Java.Lang.Object.GetObject<PendingIntent>(native_pendingIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingApi.AddGeofences(client, geofencingRequest, pendingIntent));
	}

	public unsafe PendingResult AddGeofences(GoogleApiClient client, GeofencingRequest geofencingRequest, PendingIntent pendingIntent)
	{
		if (id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ == IntPtr.Zero)
		{
			id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_ = JNIEnv.GetMethodID(class_ref, "addGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/GeofencingRequest;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(geofencingRequest?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(pendingIntent?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_GeofencingRequest_Landroid_app_PendingIntent_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_ == null)
		{
			cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_));
		}
		return cb_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_AddGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_geofences, IntPtr native_pendingIntent)
	{
		IGeofencingApi geofencingApi = Java.Lang.Object.GetObject<IGeofencingApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		IList<IGeofence> geofences = JavaList<IGeofence>.FromJniHandle(native_geofences, JniHandleOwnership.DoNotTransfer);
		PendingIntent pendingIntent = Java.Lang.Object.GetObject<PendingIntent>(native_pendingIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingApi.AddGeofences(client, geofences, pendingIntent));
	}

	public unsafe PendingResult AddGeofences(GoogleApiClient client, IList<IGeofence> geofences, PendingIntent pendingIntent)
	{
		if (id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_ == IntPtr.Zero)
		{
			id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_ = JNIEnv.GetMethodID(class_ref, "addGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Ljava/util/List;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		IntPtr intPtr = JavaList<IGeofence>.ToLocalJniHandle(geofences);
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(intPtr);
		ptr[2] = new JValue(pendingIntent?.Handle ?? IntPtr.Zero);
		PendingResult result = Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_addGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Landroid_app_PendingIntent_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(intPtr);
		return result;
	}

	private static Delegate GetRemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_Handler()
	{
		if ((object)cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ == null)
		{
			cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_));
		}
		return cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_;
	}

	private static IntPtr n_RemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_pendingIntent)
	{
		IGeofencingApi geofencingApi = Java.Lang.Object.GetObject<IGeofencingApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		PendingIntent pendingIntent = Java.Lang.Object.GetObject<PendingIntent>(native_pendingIntent, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingApi.RemoveGeofences(client, pendingIntent));
	}

	public unsafe PendingResult RemoveGeofences(GoogleApiClient client, PendingIntent pendingIntent)
	{
		if (id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ == IntPtr.Zero)
		{
			id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_ = JNIEnv.GetMethodID(class_ref, "removeGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/app/PendingIntent;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(pendingIntent?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Landroid_app_PendingIntent_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_Handler()
	{
		if ((object)cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_ == null)
		{
			cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_RemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_));
		}
		return cb_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_;
	}

	private static IntPtr n_RemoveGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_geofenceRequestIds)
	{
		IGeofencingApi geofencingApi = Java.Lang.Object.GetObject<IGeofencingApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		IList<string> geofenceRequestIds = JavaList<string>.FromJniHandle(native_geofenceRequestIds, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(geofencingApi.RemoveGeofences(client, geofenceRequestIds));
	}

	public unsafe PendingResult RemoveGeofences(GoogleApiClient client, IList<string> geofenceRequestIds)
	{
		if (id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_ == IntPtr.Zero)
		{
			id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_ = JNIEnv.GetMethodID(class_ref, "removeGeofences", "(Lcom/google/android/gms/common/api/GoogleApiClient;Ljava/util/List;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		IntPtr intPtr = JavaList<string>.ToLocalJniHandle(geofenceRequestIds);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(intPtr);
		PendingResult result = Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_removeGeofences_Lcom_google_android_gms_common_api_GoogleApiClient_Ljava_util_List_, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(intPtr);
		return result;
	}
}
[Register("com/google/android/gms/location/LocationListener", "", "Android.Gms.Location.ILocationListenerInvoker")]
public interface ILocationListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onLocationChanged", "(Landroid/location/Location;)V", "GetOnLocationChanged_Landroid_location_Location_Handler:Android.Gms.Location.ILocationListenerInvoker, Xamarin.GooglePlayServices.Location")]
	void OnLocationChanged(Android.Locations.Location location);
}
[Register("com/google/android/gms/location/LocationListener", DoNotGenerateAcw = true)]
internal class ILocationListenerInvoker : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationListener", typeof(ILocationListenerInvoker));

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

	public static ILocationListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ILocationListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.location.LocationListener'.");
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

	public ILocationListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
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
		ILocationListener locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Android.Locations.Location location = Java.Lang.Object.GetObject<Android.Locations.Location>(native_location, JniHandleOwnership.DoNotTransfer);
		locationListener.OnLocationChanged(location);
	}

	public unsafe void OnLocationChanged(Android.Locations.Location location)
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
[Register("com/google/android/gms/location/SettingsApi", "", "Android.Gms.Location.ISettingsApiInvoker")]
public interface ISettingsApi : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("checkLocationSettings", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationSettingsRequest;)Lcom/google/android/gms/common/api/PendingResult;", "GetCheckLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_Handler:Android.Gms.Location.ISettingsApiInvoker, Xamarin.GooglePlayServices.Location")]
	PendingResult CheckLocationSettings(GoogleApiClient client, LocationSettingsRequest locationSettingsRequest);
}
[Register("com/google/android/gms/location/SettingsApi", DoNotGenerateAcw = true)]
internal class ISettingsApiInvoker : Java.Lang.Object, ISettingsApi, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/SettingsApi", typeof(ISettingsApiInvoker));

	private IntPtr class_ref;

	private static Delegate cb_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_;

	private IntPtr id_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_;

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

	public static ISettingsApi GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ISettingsApi>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.gms.location.SettingsApi'.");
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

	public ISettingsApiInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetCheckLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_Handler()
	{
		if ((object)cb_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_ == null)
		{
			cb_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_CheckLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_));
		}
		return cb_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_;
	}

	private static IntPtr n_CheckLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_(IntPtr jnienv, IntPtr native__this, IntPtr native_client, IntPtr native_locationSettingsRequest)
	{
		ISettingsApi settingsApi = Java.Lang.Object.GetObject<ISettingsApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GoogleApiClient client = Java.Lang.Object.GetObject<GoogleApiClient>(native_client, JniHandleOwnership.DoNotTransfer);
		LocationSettingsRequest locationSettingsRequest = Java.Lang.Object.GetObject<LocationSettingsRequest>(native_locationSettingsRequest, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(settingsApi.CheckLocationSettings(client, locationSettingsRequest));
	}

	public unsafe PendingResult CheckLocationSettings(GoogleApiClient client, LocationSettingsRequest locationSettingsRequest)
	{
		if (id_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_ == IntPtr.Zero)
		{
			id_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_ = JNIEnv.GetMethodID(class_ref, "checkLocationSettings", "(Lcom/google/android/gms/common/api/GoogleApiClient;Lcom/google/android/gms/location/LocationSettingsRequest;)Lcom/google/android/gms/common/api/PendingResult;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(client?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(locationSettingsRequest?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<PendingResult>(JNIEnv.CallObjectMethod(base.Handle, id_checkLocationSettings_Lcom_google_android_gms_common_api_GoogleApiClient_Lcom_google_android_gms_location_LocationSettingsRequest_, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
[Register("com/google/android/gms/location/LocationAvailability", DoNotGenerateAcw = true)]
public sealed class LocationAvailability : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationAvailability", typeof(LocationAvailability));

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

	public unsafe bool IsLocationAvailable
	{
		[Register("isLocationAvailable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isLocationAvailable.()Z", this, null);
		}
	}

	internal LocationAvailability(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("extractLocationAvailability", "(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationAvailability;", "")]
	public unsafe static LocationAvailability ExtractLocationAvailability(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationAvailability>(_members.StaticMethods.InvokeObjectMethod("extractLocationAvailability.(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationAvailability;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("hasLocationAvailability", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool HasLocationAvailability(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasLocationAvailability.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel parcel, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parcel);
		}
	}
}
[Register("com/google/android/gms/location/LocationCallback", DoNotGenerateAcw = true)]
public abstract class LocationCallbackBase : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationCallback", typeof(LocationCallbackBase));

	private static Delegate cb_onLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_;

	private static Delegate cb_onLocationResult_Lcom_google_android_gms_location_LocationResult_;

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

	protected LocationCallbackBase(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LocationCallbackBase()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetOnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_Handler()
	{
		if ((object)cb_onLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_ == null)
		{
			cb_onLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_));
		}
		return cb_onLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_;
	}

	private static void n_OnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		LocationCallbackBase locationCallbackBase = Java.Lang.Object.GetObject<LocationCallbackBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationAvailability p = Java.Lang.Object.GetObject<LocationAvailability>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationCallbackBase.OnLocationAvailability(p);
	}

	[Register("onLocationAvailability", "(Lcom/google/android/gms/location/LocationAvailability;)V", "GetOnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_Handler")]
	public unsafe virtual void OnLocationAvailability(LocationAvailability p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLocationAvailability.(Lcom/google/android/gms/location/LocationAvailability;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLocationResult_Lcom_google_android_gms_location_LocationResult_Handler()
	{
		if ((object)cb_onLocationResult_Lcom_google_android_gms_location_LocationResult_ == null)
		{
			cb_onLocationResult_Lcom_google_android_gms_location_LocationResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnLocationResult_Lcom_google_android_gms_location_LocationResult_));
		}
		return cb_onLocationResult_Lcom_google_android_gms_location_LocationResult_;
	}

	private static void n_OnLocationResult_Lcom_google_android_gms_location_LocationResult_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
	{
		LocationCallbackBase locationCallbackBase = Java.Lang.Object.GetObject<LocationCallbackBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LocationResult p = Java.Lang.Object.GetObject<LocationResult>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationCallbackBase.OnLocationResult(p);
	}

	[Register("onLocationResult", "(Lcom/google/android/gms/location/LocationResult;)V", "GetOnLocationResult_Lcom_google_android_gms_location_LocationResult_Handler")]
	public unsafe virtual void OnLocationResult(LocationResult p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLocationResult.(Lcom/google/android/gms/location/LocationResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
[Register("com/google/android/gms/location/LocationCallback", DoNotGenerateAcw = true)]
internal class LocationCallbackBaseInvoker : LocationCallbackBase
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationCallback", typeof(LocationCallbackBaseInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public LocationCallbackBaseInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
[Register("com/google/android/gms/location/LocationRequest", DoNotGenerateAcw = true)]
public sealed class LocationRequest : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationRequest", typeof(LocationRequest));

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

	public unsafe long ExpirationTime
	{
		[Register("getExpirationTime", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getExpirationTime.()J", this, null);
		}
	}

	public unsafe long FastestInterval
	{
		[Register("getFastestInterval", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getFastestInterval.()J", this, null);
		}
	}

	public unsafe long Interval
	{
		[Register("getInterval", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getInterval.()J", this, null);
		}
	}

	public unsafe bool IsFastestIntervalExplicitlySet
	{
		[Register("isFastestIntervalExplicitlySet", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFastestIntervalExplicitlySet.()Z", this, null);
		}
	}

	public unsafe bool IsWaitForAccurateLocation
	{
		[Register("isWaitForAccurateLocation", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isWaitForAccurateLocation.()Z", this, null);
		}
	}

	public unsafe long MaxWaitTime
	{
		[Register("getMaxWaitTime", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getMaxWaitTime.()J", this, null);
		}
	}

	public unsafe int NumUpdates
	{
		[Register("getNumUpdates", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNumUpdates.()I", this, null);
		}
	}

	public unsafe int Priority
	{
		[Register("getPriority", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getPriority.()I", this, null);
		}
	}

	public unsafe float SmallestDisplacement
	{
		[Register("getSmallestDisplacement", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractSingleMethod("getSmallestDisplacement.()F", this, null);
		}
	}

	internal LocationRequest(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LocationRequest()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("create", "()Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe static LocationRequest Create()
	{
		return Java.Lang.Object.GetObject<LocationRequest>(_members.StaticMethods.InvokeObjectMethod("create.()Lcom/google/android/gms/location/LocationRequest;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setExpirationDuration", "(J)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetExpirationDuration(long millis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(millis);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExpirationDuration.(J)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setExpirationTime", "(J)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetExpirationTime(long millis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(millis);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExpirationTime.(J)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setFastestInterval", "(J)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetFastestInterval(long millis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(millis);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFastestInterval.(J)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setInterval", "(J)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetInterval(long millis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(millis);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInterval.(J)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setMaxWaitTime", "(J)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetMaxWaitTime(long millis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(millis);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMaxWaitTime.(J)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setNumUpdates", "(I)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetNumUpdates(int numUpdates)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(numUpdates);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNumUpdates.(I)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setPriority", "(I)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetPriority(int priority)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(priority);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPriority.(I)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setSmallestDisplacement", "(F)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetSmallestDisplacement(float smallestDisplacementMeters)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(smallestDisplacementMeters);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSmallestDisplacement.(F)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setWaitForAccurateLocation", "(Z)Lcom/google/android/gms/location/LocationRequest;", "")]
	public unsafe LocationRequest SetWaitForAccurateLocation(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return Java.Lang.Object.GetObject<LocationRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("setWaitForAccurateLocation.(Z)Lcom/google/android/gms/location/LocationRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel parcel, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parcel);
		}
	}
}
[Register("com/google/android/gms/location/LocationResult", DoNotGenerateAcw = true)]
public sealed class LocationResult : AbstractSafeParcelable, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationResult", typeof(LocationResult));

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

	public unsafe Android.Locations.Location LastLocation
	{
		[Register("getLastLocation", "()Landroid/location/Location;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Locations.Location>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLastLocation.()Landroid/location/Location;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<Android.Locations.Location> Locations
	{
		[Register("getLocations", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Android.Locations.Location>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal LocationResult(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("create", "(Ljava/util/List;)Lcom/google/android/gms/location/LocationResult;", "")]
	public unsafe static LocationResult Create(IList<Android.Locations.Location> locations)
	{
		IntPtr intPtr = JavaList<Android.Locations.Location>.ToLocalJniHandle(locations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<LocationResult>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/util/List;)Lcom/google/android/gms/location/LocationResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(locations);
		}
	}

	[Register("extractResult", "(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationResult;", "")]
	public unsafe static LocationResult ExtractResult(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationResult>(_members.StaticMethods.InvokeObjectMethod("extractResult.(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationResult;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("hasResult", "(Landroid/content/Intent;)Z", "")]
	public unsafe static bool HasResult(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasResult.(Landroid/content/Intent;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel parcel, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(parcel?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parcel);
		}
	}
}
[Register("com/google/android/gms/location/LocationSettingsRequest", DoNotGenerateAcw = true)]
public sealed class LocationSettingsRequest : AbstractSafeParcelable
{
	[Register("com/google/android/gms/location/LocationSettingsRequest$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationSettingsRequest$Builder", typeof(Builder));

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

		[Register("addAllLocationRequests", "(Ljava/util/Collection;)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", "")]
		public unsafe Builder AddAllLocationRequests(ICollection<LocationRequest> p0)
		{
			IntPtr intPtr = JavaCollection<LocationRequest>.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addAllLocationRequests.(Ljava/util/Collection;)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		[Register("addLocationRequest", "(Lcom/google/android/gms/location/LocationRequest;)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", "")]
		public unsafe Builder AddLocationRequest(LocationRequest p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addLocationRequest.(Lcom/google/android/gms/location/LocationRequest;)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("build", "()Lcom/google/android/gms/location/LocationSettingsRequest;", "")]
		public unsafe LocationSettingsRequest Build()
		{
			return Java.Lang.Object.GetObject<LocationSettingsRequest>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/gms/location/LocationSettingsRequest;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setAlwaysShow", "(Z)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", "")]
		public unsafe Builder SetAlwaysShow(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAlwaysShow.(Z)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setNeedBle", "(Z)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", "")]
		public unsafe Builder SetNeedBle(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNeedBle.(Z)Lcom/google/android/gms/location/LocationSettingsRequest$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationSettingsRequest", typeof(LocationSettingsRequest));

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

	internal LocationSettingsRequest(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}
[Register("com/google/android/gms/location/LocationSettingsResponse", DoNotGenerateAcw = true)]
public class LocationSettingsResponse : Response
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationSettingsResponse", typeof(LocationSettingsResponse));

	private static Delegate cb_getLocationSettingsStates;

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

	public unsafe virtual LocationSettingsStates LocationSettingsStates
	{
		[Register("getLocationSettingsStates", "()Lcom/google/android/gms/location/LocationSettingsStates;", "GetGetLocationSettingsStatesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LocationSettingsStates>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLocationSettingsStates.()Lcom/google/android/gms/location/LocationSettingsStates;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected LocationSettingsResponse(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LocationSettingsResponse()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/google/android/gms/location/LocationSettingsResult;)V", "")]
	public unsafe LocationSettingsResponse(LocationSettingsResult p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/location/LocationSettingsResult;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/location/LocationSettingsResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetGetLocationSettingsStatesHandler()
	{
		if ((object)cb_getLocationSettingsStates == null)
		{
			cb_getLocationSettingsStates = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLocationSettingsStates));
		}
		return cb_getLocationSettingsStates;
	}

	private static IntPtr n_GetLocationSettingsStates(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LocationSettingsResponse>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LocationSettingsStates);
	}
}
[Register("com/google/android/gms/location/LocationSettingsResult", DoNotGenerateAcw = true)]
public sealed class LocationSettingsResult : AbstractSafeParcelable, IResult, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationSettingsResult", typeof(LocationSettingsResult));

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

	public unsafe LocationSettingsStates LocationSettingsStates
	{
		[Register("getLocationSettingsStates", "()Lcom/google/android/gms/location/LocationSettingsStates;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocationSettingsStates>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocationSettingsStates.()Lcom/google/android/gms/location/LocationSettingsStates;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Statuses Status
	{
		[Register("getStatus", "()Lcom/google/android/gms/common/api/Status;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Statuses>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStatus.()Lcom/google/android/gms/common/api/Status;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal LocationSettingsResult(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/google/android/gms/common/api/Status;Lcom/google/android/gms/location/LocationSettingsStates;)V", "")]
	public unsafe LocationSettingsResult(Statuses p0, LocationSettingsStates p1)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/common/api/Status;Lcom/google/android/gms/location/LocationSettingsStates;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/common/api/Status;Lcom/google/android/gms/location/LocationSettingsStates;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}
[Register("com/google/android/gms/location/LocationSettingsStates", DoNotGenerateAcw = true)]
public sealed class LocationSettingsStates : AbstractSafeParcelable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/location/LocationSettingsStates", typeof(LocationSettingsStates));

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

	public unsafe bool IsBlePresent
	{
		[Register("isBlePresent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isBlePresent.()Z", this, null);
		}
	}

	public unsafe bool IsBleUsable
	{
		[Register("isBleUsable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isBleUsable.()Z", this, null);
		}
	}

	public unsafe bool IsGpsPresent
	{
		[Register("isGpsPresent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGpsPresent.()Z", this, null);
		}
	}

	public unsafe bool IsGpsUsable
	{
		[Register("isGpsUsable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isGpsUsable.()Z", this, null);
		}
	}

	public unsafe bool IsLocationPresent
	{
		[Register("isLocationPresent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isLocationPresent.()Z", this, null);
		}
	}

	public unsafe bool IsLocationUsable
	{
		[Register("isLocationUsable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isLocationUsable.()Z", this, null);
		}
	}

	public unsafe bool IsNetworkLocationPresent
	{
		[Register("isNetworkLocationPresent", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isNetworkLocationPresent.()Z", this, null);
		}
	}

	public unsafe bool IsNetworkLocationUsable
	{
		[Register("isNetworkLocationUsable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isNetworkLocationUsable.()Z", this, null);
		}
	}

	internal LocationSettingsStates(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(ZZZZZZ)V", "")]
	public unsafe LocationSettingsStates(bool p0, bool p1, bool p2, bool p3, bool p4, bool p5)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3);
			ptr[4] = new JniArgumentValue(p4);
			ptr[5] = new JniArgumentValue(p5);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ZZZZZZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ZZZZZZ)V", this, ptr);
		}
	}

	[Register("fromIntent", "(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationSettingsStates;", "")]
	public unsafe static LocationSettingsStates FromIntent(Intent intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettingsStates>(_members.StaticMethods.InvokeObjectMethod("fromIntent.(Landroid/content/Intent;)Lcom/google/android/gms/location/LocationSettingsStates;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}
