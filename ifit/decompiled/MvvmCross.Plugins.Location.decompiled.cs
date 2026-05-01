using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Plugins;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Location")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Location")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	public sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
namespace MvvmCross.Plugins.Location
{
	public interface IMvxLocationWatcher
	{
		bool Started { get; }

		MvxGeoLocation CurrentLocation { get; }

		MvxGeoLocation LastSeenLocation { get; }

		event EventHandler<MvxValueEventArgs<MvxLocationPermission>> OnPermissionChanged;

		void Start(MvxLocationOptions options, Action<MvxGeoLocation> success, Action<MvxLocationError> error);

		void Stop();
	}
	[Preserve(AllMembers = true)]
	public class MvxCoordinates
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public double? Accuracy { get; set; }

		public double? Altitude { get; set; }

		public double? AltitudeAccuracy { get; set; }

		public double? Heading { get; set; }

		public double? HeadingAccuracy { get; set; }

		public double? Speed { get; set; }
	}
	[Preserve(AllMembers = true)]
	public class MvxGeoLocation
	{
		public MvxCoordinates Coordinates { get; set; }

		public DateTimeOffset Timestamp { get; set; }

		public MvxGeoLocation()
		{
			Coordinates = new MvxCoordinates();
		}
	}
	public enum MvxLocationAccuracy
	{
		Fine,
		Coarse
	}
	[Preserve(AllMembers = true)]
	public class MvxLocationError
	{
		public MvxLocationErrorCode Code { get; private set; }

		public MvxLocationError(MvxLocationErrorCode code)
		{
			Code = code;
		}
	}
	public enum MvxLocationErrorCode
	{
		ServiceUnavailable,
		PermissionDenied,
		PositionUnavailable,
		Timeout,
		Network,
		Canceled
	}
	[Preserve(AllMembers = true)]
	public class MvxLocationOptions
	{
		public MvxLocationAccuracy Accuracy { get; set; }

		public TimeSpan TimeBetweenUpdates { get; set; }

		public int MovementThresholdInM { get; set; }

		public MvxLocationTrackingMode TrackingMode { get; set; }
	}
	public abstract class MvxLocationWatcher : IMvxLocationWatcher
	{
		private Action<MvxGeoLocation> _locationCallback;

		private Action<MvxLocationError> _errorCallback;

		private MvxLocationPermission _permission;

		protected MvxLocationPermission Permission
		{
			get
			{
				return _permission;
			}
			set
			{
				if (_permission != value)
				{
					_permission = value;
					this.OnPermissionChanged(this, new MvxValueEventArgs<MvxLocationPermission>(value));
				}
			}
		}

		public bool Started { get; set; }

		public abstract MvxGeoLocation CurrentLocation { get; }

		public MvxGeoLocation LastSeenLocation { get; protected set; }

		public event EventHandler<MvxValueEventArgs<MvxLocationPermission>> OnPermissionChanged = delegate
		{
		};

		public void Start(MvxLocationOptions options, Action<MvxGeoLocation> success, Action<MvxLocationError> error)
		{
			lock (this)
			{
				_locationCallback = success;
				_errorCallback = error;
				PlatformSpecificStart(options);
				Started = true;
			}
		}

		public void Stop()
		{
			lock (this)
			{
				_locationCallback = delegate
				{
				};
				_errorCallback = delegate
				{
				};
				PlatformSpecificStop();
				Started = false;
			}
		}

		protected abstract void PlatformSpecificStart(MvxLocationOptions options);

		protected abstract void PlatformSpecificStop();

		protected virtual void SendLocation(MvxGeoLocation location)
		{
			LastSeenLocation = location;
			_locationCallback?.Invoke(location);
		}

		protected void SendError(MvxLocationErrorCode code)
		{
			SendError(new MvxLocationError(code));
		}

		protected void SendError(MvxLocationError error)
		{
			_errorCallback?.Invoke(error);
		}
	}
	[Preserve(AllMembers = true)]
	public class PluginLoader : IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		public void EnsureLoaded()
		{
			Mvx.Resolve<IMvxPluginManager>().EnsurePlatformAdaptionLoaded<PluginLoader>();
		}
	}
	public enum MvxLocationTrackingMode
	{
		Foreground,
		Background
	}
	public enum MvxLocationPermission
	{
		Unknown,
		Denied,
		Granted
	}
}
