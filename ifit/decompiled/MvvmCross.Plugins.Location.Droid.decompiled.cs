using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Java.Lang;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.Location.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.Location.Droid")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "Xamarin.Android v5.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins.Location.Droid;

public interface IMvxLocationReceiver
{
	void OnLocationChanged(Android.Locations.Location location);

	void OnProviderDisabled(string provider);

	void OnProviderEnabled(string provider);

	void OnStatusChanged(string provider, Availability status, Bundle extras);
}
[Preserve(AllMembers = true)]
public sealed class MvxAndroidLocationWatcher : MvxLocationWatcher, IMvxLocationReceiver
{
	private Context _context;

	private LocationManager _locationManager;

	private readonly MvxLocationListener _locationListener;

	private string _bestProvider;

	private Context Context => _context ?? (_context = Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext);

	public override MvxGeoLocation CurrentLocation
	{
		get
		{
			if (_locationManager == null || _bestProvider == null)
			{
				throw new MvxException("Location Manager not started");
			}
			Android.Locations.Location lastKnownLocation = _locationManager.GetLastKnownLocation(_bestProvider);
			if (lastKnownLocation == null)
			{
				return null;
			}
			return CreateLocation(lastKnownLocation);
		}
	}

	public MvxAndroidLocationWatcher()
	{
		EnsureStopped();
		_locationListener = new MvxLocationListener(this);
	}

	protected override void PlatformSpecificStart(MvxLocationOptions options)
	{
		if (_locationManager != null)
		{
			throw new MvxException("You cannot start the MvxLocation service more than once");
		}
		_locationManager = (LocationManager)Context.GetSystemService("location");
		if (_locationManager == null)
		{
			MvxTrace.Warning("Location Service Manager unavailable - returned null");
			SendError(MvxLocationErrorCode.ServiceUnavailable);
			return;
		}
		Criteria criteria = new Criteria
		{
			Accuracy = ((options.Accuracy == MvxLocationAccuracy.Fine) ? Accuracy.Fine : Accuracy.Coarse)
		};
		_bestProvider = _locationManager.GetBestProvider(criteria, enabledOnly: true);
		if (_bestProvider == null)
		{
			MvxTrace.Warning("Location Service Provider unavailable - returned null");
			SendError(MvxLocationErrorCode.ServiceUnavailable);
		}
		else
		{
			_locationManager.RequestLocationUpdates(_bestProvider, (long)options.TimeBetweenUpdates.TotalMilliseconds, options.MovementThresholdInM, _locationListener);
			base.Permission = ((!_locationManager.IsProviderEnabled(_bestProvider)) ? MvxLocationPermission.Denied : MvxLocationPermission.Granted);
		}
	}

	protected override void PlatformSpecificStop()
	{
		EnsureStopped();
	}

	private void EnsureStopped()
	{
		if (_locationManager != null)
		{
			_locationManager.RemoveUpdates(_locationListener);
			_locationManager = null;
			_bestProvider = null;
		}
	}

	private static MvxGeoLocation CreateLocation(Android.Locations.Location androidLocation)
	{
		MvxGeoLocation obj = new MvxGeoLocation
		{
			Timestamp = androidLocation.Time.FromMillisecondsUnixTimeToUtc()
		};
		MvxCoordinates coordinates = obj.Coordinates;
		if (androidLocation.HasAltitude)
		{
			coordinates.Altitude = androidLocation.Altitude;
		}
		if (androidLocation.HasBearing)
		{
			coordinates.Heading = androidLocation.Bearing;
		}
		coordinates.Latitude = androidLocation.Latitude;
		coordinates.Longitude = androidLocation.Longitude;
		if (androidLocation.HasSpeed)
		{
			coordinates.Speed = androidLocation.Speed;
		}
		if (androidLocation.HasAccuracy)
		{
			coordinates.Accuracy = androidLocation.Accuracy;
		}
		return obj;
	}

	public void OnLocationChanged(Android.Locations.Location androidLocation)
	{
		if (androidLocation == null)
		{
			MvxTrace.Trace("Android: Null location seen");
			return;
		}
		if (androidLocation.Latitude == 1.7976931348623157E+308 || androidLocation.Longitude == 1.7976931348623157E+308)
		{
			MvxTrace.Trace("Android: Invalid location seen");
			return;
		}
		MvxGeoLocation location;
		try
		{
			location = CreateLocation(androidLocation);
		}
		catch (ThreadAbortException)
		{
			throw;
		}
		catch (System.Exception exception)
		{
			MvxTrace.Trace("Android: Exception seen in converting location " + exception.ToLongString());
			return;
		}
		SendLocation(location);
	}

	public void OnProviderDisabled(string provider)
	{
		base.Permission = MvxLocationPermission.Denied;
		SendError(MvxLocationErrorCode.ServiceUnavailable);
	}

	public void OnProviderEnabled(string provider)
	{
		base.Permission = MvxLocationPermission.Granted;
	}

	public void OnStatusChanged(string provider, Availability status, Bundle extras)
	{
		switch (status)
		{
		case Availability.OutOfService:
			SendError(MvxLocationErrorCode.ServiceUnavailable);
			break;
		case Availability.TemporarilyUnavailable:
			SendError(MvxLocationErrorCode.PositionUnavailable);
			break;
		default:
			throw new ArgumentOutOfRangeException("status");
		case Availability.Available:
			break;
		}
	}
}
[Preserve(AllMembers = true)]
public class MvxLocationListener : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable
{
	private readonly IMvxLocationReceiver _owner;

	public MvxLocationListener(IMvxLocationReceiver owner)
	{
		_owner = owner;
	}

	public void OnLocationChanged(Android.Locations.Location location)
	{
		_owner.OnLocationChanged(location);
	}

	public void OnProviderDisabled(string provider)
	{
		_owner.OnProviderDisabled(provider);
	}

	public void OnProviderEnabled(string provider)
	{
		_owner.OnProviderEnabled(provider);
	}

	public void OnStatusChanged(string provider, Availability status, Bundle extras)
	{
		_owner.OnStatusChanged(provider, status, extras);
	}
}
[Preserve(AllMembers = true)]
public class Plugin : IMvxPlugin
{
	public void Load()
	{
		Mvx.RegisterSingleton((Func<IMvxLocationWatcher>)(() => new MvxAndroidLocationWatcher()));
	}
}
