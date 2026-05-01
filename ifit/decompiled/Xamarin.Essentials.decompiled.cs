using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Locations;
using Android.Net;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using AndroidX.Browser.CustomTabs;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using AndroidX.Core.Content.PM;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("XamarinEssentialsTests")]
[assembly: InternalsVisibleTo("XamarinEssentialsDeviceTestsAndroid")]
[assembly: InternalsVisibleTo("XamarinEssentialsDeviceTestsUWP")]
[assembly: InternalsVisibleTo("XamarinEssentialsDeviceTestsShared")]
[assembly: InternalsVisibleTo("XamarinEssentialsDeviceTestsiOS")]
[assembly: LinkerSafe]
[assembly: ResourceDesigner("Xamarin.Essentials.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v10.0", FrameworkDisplayName = "Xamarin.Android v10.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Essentials: a kit of essential API's for your apps")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+e054b7e19b7fb8f1787af41c95ce4447660422ed")]
[assembly: AssemblyProduct("Xamarin.Essentials (MonoAndroid10.0)")]
[assembly: AssemblyTitle("Xamarin.Essentials")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/Essentials")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Xamarin.Essentials;

public static class AppInfo
{
	public static string PackageName => PlatformGetPackageName();

	public static string VersionString => PlatformGetVersionString();

	public static string BuildString => PlatformGetBuild();

	private static string PlatformGetPackageName()
	{
		return Platform.AppContext.PackageName;
	}

	private static string PlatformGetVersionString()
	{
		PackageManager packageManager = Platform.AppContext.PackageManager;
		string packageName = Platform.AppContext.PackageName;
		using PackageInfo packageInfo = packageManager.GetPackageInfo(packageName, PackageInfoFlags.MetaData);
		return packageInfo.VersionName;
	}

	private static string PlatformGetBuild()
	{
		PackageManager packageManager = Platform.AppContext.PackageManager;
		string packageName = Platform.AppContext.PackageName;
		using PackageInfo info = packageManager.GetPackageInfo(packageName, PackageInfoFlags.MetaData);
		return PackageInfoCompat.GetLongVersionCode(info).ToString(CultureInfo.InvariantCulture);
	}
}
public static class Browser
{
	public static Task OpenAsync(string uri)
	{
		return OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
	}

	public static Task OpenAsync(string uri, BrowserLaunchMode launchMode)
	{
		return OpenAsync(uri, new BrowserLaunchOptions
		{
			LaunchMode = launchMode
		});
	}

	public static Task OpenAsync(string uri, BrowserLaunchOptions options)
	{
		if (string.IsNullOrWhiteSpace(uri))
		{
			throw new ArgumentNullException("uri", "Uri cannot be empty.");
		}
		return OpenAsync(new System.Uri(uri), options);
	}

	public static Task<bool> OpenAsync(System.Uri uri, BrowserLaunchOptions options)
	{
		return PlatformOpenAsync(EscapeUri(uri), options);
	}

	internal static System.Uri EscapeUri(System.Uri uri)
	{
		if (uri == null)
		{
			throw new ArgumentNullException("uri");
		}
		IdnMapping idnMapping = new IdnMapping();
		return new System.Uri(uri.Scheme + "://" + idnMapping.GetAscii(uri.Authority) + uri.PathAndQuery + uri.Fragment);
	}

	private static Task<bool> PlatformOpenAsync(System.Uri uri, BrowserLaunchOptions options)
	{
		Android.Net.Uri uri2 = Android.Net.Uri.Parse(uri.AbsoluteUri);
		switch (options.LaunchMode)
		{
		case BrowserLaunchMode.SystemPreferred:
		{
			CustomTabsIntent.Builder builder = new CustomTabsIntent.Builder();
			builder.SetShowTitle(showTitle: true);
			if (options.PreferredToolbarColor.HasValue)
			{
				builder.SetToolbarColor(options.PreferredToolbarColor.Value.ToInt());
			}
			if (options.TitleMode != BrowserTitleMode.Default)
			{
				builder.SetShowTitle(options.TitleMode == BrowserTitleMode.Show);
			}
			CustomTabsIntent customTabsIntent = builder.Build();
			ActivityFlags? activityFlags2 = null;
			Context context = Platform.GetCurrentActivity(throwOnNull: false);
			if (context == null)
			{
				context = Platform.AppContext;
				activityFlags2 = ActivityFlags.ClearTop | ActivityFlags.NewTask;
			}
			if (Platform.HasApiLevelN && options.HasFlag(BrowserLaunchFlags.LaunchAdjacent))
			{
				activityFlags2 = (ActivityFlags?)((!activityFlags2.HasValue) ? ((ValueType)new ActivityFlags?(ActivityFlags.LaunchAdjacent | ActivityFlags.NewTask)) : ((ValueType)((uint?)activityFlags2 | 0x10001000u)));
			}
			if (activityFlags2.HasValue)
			{
				customTabsIntent.Intent.SetFlags(activityFlags2.Value);
			}
			customTabsIntent.LaunchUrl(context, uri2);
			break;
		}
		case BrowserLaunchMode.External:
		{
			Intent intent = new Intent("android.intent.action.VIEW", uri2);
			ActivityFlags activityFlags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
			if (Platform.HasApiLevelN && options.HasFlag(BrowserLaunchFlags.LaunchAdjacent))
			{
				activityFlags |= ActivityFlags.LaunchAdjacent;
			}
			intent.SetFlags(activityFlags);
			if (!Platform.IsIntentSupported(intent))
			{
				throw new FeatureNotSupportedException();
			}
			Platform.AppContext.StartActivity(intent);
			break;
		}
		}
		return Task.FromResult(result: true);
	}
}
public enum BrowserLaunchMode
{
	SystemPreferred,
	External
}
public class BrowserLaunchOptions
{
	public Color? PreferredToolbarColor { get; }

	public BrowserLaunchMode LaunchMode { get; set; }

	public BrowserTitleMode TitleMode { get; }

	public BrowserLaunchFlags Flags { get; }

	internal bool HasFlag(BrowserLaunchFlags flag)
	{
		return Flags.HasFlag(flag);
	}
}
[Flags]
public enum BrowserLaunchFlags
{
	None = 0,
	LaunchAdjacent = 1,
	PresentAsPageSheet = 2,
	PresentAsFormSheet = 4
}
public enum BrowserTitleMode
{
	Default,
	Show,
	Hide
}
public static class Connectivity
{
	public static NetworkAccess NetworkAccess => PlatformNetworkAccess;

	private static NetworkAccess PlatformNetworkAccess
	{
		get
		{
			Permissions.EnsureDeclared<Permissions.NetworkState>();
			try
			{
				NetworkAccess currentAccess = NetworkAccess.None;
				ConnectivityManager manager = Platform.ConnectivityManager;
				if (Platform.HasApiLevel(BuildVersionCodes.Lollipop))
				{
					Network[] allNetworks = manager.GetAllNetworks();
					if (allNetworks.Length == 0 && Build.VERSION.SdkInt < BuildVersionCodes.M)
					{
						ProcessAllNetworkInfo();
						return currentAccess;
					}
					Network[] array = allNetworks;
					foreach (Network network in array)
					{
						try
						{
							NetworkCapabilities networkCapabilities = manager.GetNetworkCapabilities(network);
							if (networkCapabilities == null)
							{
								continue;
							}
							NetworkInfo networkInfo = manager.GetNetworkInfo(network);
							if (networkInfo != null && networkInfo.IsAvailable)
							{
								if (!networkCapabilities.HasCapability(NetCapability.Internet))
								{
									currentAccess = IsBetterAccess(currentAccess, NetworkAccess.Local);
								}
								else
								{
									ProcessNetworkInfo(networkInfo);
								}
							}
						}
						catch
						{
						}
					}
				}
				else
				{
					ProcessAllNetworkInfo();
				}
				return currentAccess;
				void ProcessAllNetworkInfo()
				{
					NetworkInfo[] allNetworkInfo = manager.GetAllNetworkInfo();
					for (int j = 0; j < allNetworkInfo.Length; j++)
					{
						ProcessNetworkInfo(allNetworkInfo[j]);
					}
				}
				void ProcessNetworkInfo(NetworkInfo info)
				{
					if (info != null && info.IsAvailable)
					{
						if (info.IsConnected)
						{
							currentAccess = IsBetterAccess(currentAccess, NetworkAccess.Internet);
						}
						else if (info.IsConnectedOrConnecting)
						{
							currentAccess = IsBetterAccess(currentAccess, NetworkAccess.ConstrainedInternet);
						}
					}
				}
			}
			catch (System.Exception)
			{
				return NetworkAccess.Unknown;
			}
		}
	}

	private static NetworkAccess IsBetterAccess(NetworkAccess currentAccess, NetworkAccess newAccess)
	{
		if (newAccess <= currentAccess)
		{
			return currentAccess;
		}
		return newAccess;
	}
}
public static class DeviceInfo
{
	public static DevicePlatform Platform => GetPlatform();

	public static DeviceIdiom Idiom => GetIdiom();

	private static DevicePlatform GetPlatform()
	{
		return DevicePlatform.Android;
	}

	private static DeviceIdiom GetIdiom()
	{
		DeviceIdiom deviceIdiom = DeviceIdiom.Unknown;
		using UiModeManager uiModeManager = UiModeManager.FromContext(Xamarin.Essentials.Platform.AppContext);
		try
		{
			deviceIdiom = DetectIdiom(uiModeManager?.CurrentModeType ?? UiMode.NightUndefined);
		}
		catch (System.Exception)
		{
		}
		if (deviceIdiom == DeviceIdiom.Unknown)
		{
			Configuration configuration = Xamarin.Essentials.Platform.AppContext.Resources?.Configuration;
			if (configuration != null)
			{
				deviceIdiom = ((configuration.SmallestScreenWidthDp >= 600) ? DeviceIdiom.Tablet : DeviceIdiom.Phone);
			}
			else
			{
				using DisplayMetrics displayMetrics = Xamarin.Essentials.Platform.AppContext.Resources?.DisplayMetrics;
				if (displayMetrics != null)
				{
					deviceIdiom = (((float)System.Math.Min(displayMetrics.WidthPixels, displayMetrics.HeightPixels) * displayMetrics.Density >= 600f) ? DeviceIdiom.Tablet : DeviceIdiom.Phone);
				}
			}
		}
		return deviceIdiom;
	}

	private static DeviceIdiom DetectIdiom(UiMode uiMode)
	{
		switch (uiMode)
		{
		case UiMode.TypeNormal:
			return DeviceIdiom.Unknown;
		case UiMode.TypeTelevision:
			return DeviceIdiom.TV;
		case UiMode.TypeDesk:
			return DeviceIdiom.Desktop;
		default:
			if (Xamarin.Essentials.Platform.HasApiLevel(BuildVersionCodes.KitkatWatch) && uiMode == UiMode.TypeWatch)
			{
				return DeviceIdiom.Watch;
			}
			return DeviceIdiom.Unknown;
		}
	}
}
public static class Geolocation
{
	private static readonly string[] ignoredProviders = new string[2] { "passive", "local_database" };

	public static Task<Location> GetLastKnownLocationAsync()
	{
		return PlatformLastKnownLocationAsync();
	}

	public static Task<Location> GetLocationAsync(GeolocationRequest request)
	{
		return PlatformLocationAsync(request ?? new GeolocationRequest(), default(CancellationToken));
	}

	private static async Task<Location> PlatformLastKnownLocationAsync()
	{
		await Permissions.EnsureGrantedOrRestrictedAsync<Permissions.LocationWhenInUse>();
		LocationManager locationManager = Platform.LocationManager;
		Android.Locations.Location location = null;
		foreach (string provider in locationManager.GetProviders(enabledOnly: true))
		{
			Android.Locations.Location lastKnownLocation = locationManager.GetLastKnownLocation(provider);
			if (lastKnownLocation != null && IsBetterLocation(lastKnownLocation, location))
			{
				location = lastKnownLocation;
			}
		}
		return location?.ToLocation();
	}

	private static async Task<Location> PlatformLocationAsync(GeolocationRequest request, CancellationToken cancellationToken)
	{
		await Permissions.EnsureGrantedOrRestrictedAsync<Permissions.LocationWhenInUse>();
		LocationManager locationManager = Platform.LocationManager;
		if (!locationManager.GetProviders(enabledOnly: true).Any((string p) => !ignoredProviders.Contains(p)))
		{
			throw new FeatureNotEnabledException("Location services are not enabled on device.");
		}
		(string, float) bestProvider = GetBestProvider(locationManager, request.DesiredAccuracy);
		if (string.IsNullOrEmpty(bestProvider.Item1))
		{
			return await GetLastKnownLocationAsync();
		}
		TaskCompletionSource<Android.Locations.Location> tcs = new TaskCompletionSource<Android.Locations.Location>();
		IList<string> providers = locationManager.GetProviders(enabledOnly: false);
		List<string> providers2 = new List<string>();
		if (providers.Contains("gps"))
		{
			providers2.Add("gps");
		}
		if (providers.Contains("network"))
		{
			providers2.Add("network");
		}
		if (providers2.Count == 0)
		{
			providers2.Add(bestProvider.Item1);
		}
		SingleLocationListener listener = new SingleLocationListener(locationManager, bestProvider.Item2, providers2);
		listener.LocationHandler = HandleLocation;
		cancellationToken = Utils.TimeoutToken(cancellationToken, request.Timeout);
		cancellationToken.Register(Cancel);
		Looper looper = Looper.MyLooper() ?? Looper.MainLooper;
		foreach (string item in providers2)
		{
			locationManager.RequestLocationUpdates(item, 0L, 0f, listener, looper);
		}
		return (await tcs.Task)?.ToLocation();
		void Cancel()
		{
			RemoveUpdates();
			tcs.TrySetResult(listener.BestLocation);
		}
		void HandleLocation(Android.Locations.Location location)
		{
			RemoveUpdates();
			tcs.TrySetResult(location);
		}
		void RemoveUpdates()
		{
			for (int i = 0; i < providers2.Count; i++)
			{
				locationManager.RemoveUpdates(listener);
			}
		}
	}

	private static (string Provider, float Accuracy) GetBestProvider(LocationManager locationManager, GeolocationAccuracy accuracy)
	{
		Criteria criteria = new Criteria
		{
			BearingRequired = false,
			AltitudeRequired = false,
			SpeedRequired = false
		};
		int num = 100;
		switch (accuracy)
		{
		case GeolocationAccuracy.Lowest:
			criteria.Accuracy = Accuracy.NoRequirement;
			criteria.HorizontalAccuracy = Accuracy.NoRequirement;
			criteria.PowerRequirement = Power.NoRequirement;
			num = 500;
			break;
		case GeolocationAccuracy.Low:
			criteria.Accuracy = Accuracy.Coarse;
			criteria.HorizontalAccuracy = Accuracy.Fine;
			criteria.PowerRequirement = Power.Low;
			num = 500;
			break;
		case GeolocationAccuracy.Default:
		case GeolocationAccuracy.Medium:
			criteria.Accuracy = Accuracy.Coarse;
			criteria.HorizontalAccuracy = Accuracy.Coarse;
			criteria.PowerRequirement = Power.Medium;
			num = 250;
			break;
		case GeolocationAccuracy.High:
			criteria.Accuracy = Accuracy.Fine;
			criteria.HorizontalAccuracy = Accuracy.High;
			criteria.PowerRequirement = Power.High;
			num = 100;
			break;
		case GeolocationAccuracy.Best:
			criteria.Accuracy = Accuracy.Fine;
			criteria.HorizontalAccuracy = Accuracy.High;
			criteria.PowerRequirement = Power.High;
			num = 50;
			break;
		}
		return (Provider: locationManager.GetBestProvider(criteria, enabledOnly: true) ?? locationManager.GetProviders(enabledOnly: true).FirstOrDefault(), Accuracy: num);
	}

	internal static bool IsBetterLocation(Android.Locations.Location location, Android.Locations.Location bestLocation)
	{
		if (bestLocation == null)
		{
			return true;
		}
		long num = location.Time - bestLocation.Time;
		bool flag = num > 120000;
		bool flag2 = num < -120000;
		bool flag3 = num > 0;
		if (flag)
		{
			return true;
		}
		if (flag2)
		{
			return false;
		}
		int num2 = (int)(location.Accuracy - bestLocation.Accuracy);
		bool flag4 = num2 > 0;
		bool flag5 = num2 < 0;
		bool flag6 = num2 > 200;
		bool valueOrDefault = location?.Provider?.Equals(bestLocation?.Provider, StringComparison.OrdinalIgnoreCase) == true;
		if (flag5)
		{
			return true;
		}
		if (flag3 && !flag4)
		{
			return true;
		}
		if (flag3 && !flag6 && valueOrDefault)
		{
			return true;
		}
		return false;
	}
}
public enum GeolocationAccuracy
{
	Default,
	Lowest,
	Low,
	Medium,
	High,
	Best
}
public class GeolocationRequest
{
	public TimeSpan Timeout { get; set; }

	public GeolocationAccuracy DesiredAccuracy { get; set; }

	public GeolocationRequest()
	{
		Timeout = TimeSpan.Zero;
		DesiredAccuracy = GeolocationAccuracy.Default;
	}

	public GeolocationRequest(GeolocationAccuracy accuracy)
	{
		Timeout = TimeSpan.Zero;
		DesiredAccuracy = accuracy;
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "DesiredAccuracy", DesiredAccuracy, "Timeout", Timeout);
	}
}
public static class MainThread
{
	private static volatile Handler handler;

	public static bool IsMainThread => PlatformIsMainThread;

	private static bool PlatformIsMainThread
	{
		get
		{
			if (Platform.HasApiLevel(BuildVersionCodes.M))
			{
				return Looper.MainLooper.IsCurrentThread;
			}
			return Looper.MyLooper() == Looper.MainLooper;
		}
	}

	public static void BeginInvokeOnMainThread(Action action)
	{
		if (IsMainThread)
		{
			action();
		}
		else
		{
			PlatformBeginInvokeOnMainThread(action);
		}
	}

	public static Task InvokeOnMainThreadAsync(Action action)
	{
		if (IsMainThread)
		{
			action();
			return Task.CompletedTask;
		}
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		BeginInvokeOnMainThread(delegate
		{
			try
			{
				action();
				tcs.TrySetResult(result: true);
			}
			catch (System.Exception exception)
			{
				tcs.TrySetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task<T> InvokeOnMainThreadAsync<T>(Func<T> func)
	{
		if (IsMainThread)
		{
			return Task.FromResult(func());
		}
		TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
		BeginInvokeOnMainThread(delegate
		{
			try
			{
				T result = func();
				tcs.TrySetResult(result);
			}
			catch (System.Exception exception)
			{
				tcs.TrySetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task InvokeOnMainThreadAsync(Func<Task> funcTask)
	{
		if (IsMainThread)
		{
			return funcTask();
		}
		TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
		BeginInvokeOnMainThread(async delegate
		{
			try
			{
				await funcTask().ConfigureAwait(continueOnCapturedContext: false);
				tcs.SetResult(null);
			}
			catch (System.Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> funcTask)
	{
		if (IsMainThread)
		{
			return funcTask();
		}
		TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
		BeginInvokeOnMainThread(async delegate
		{
			try
			{
				T result = await funcTask().ConfigureAwait(continueOnCapturedContext: false);
				tcs.SetResult(result);
			}
			catch (System.Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return tcs.Task;
	}

	public static async Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync()
	{
		SynchronizationContext ret = null;
		await InvokeOnMainThreadAsync(() => ret = SynchronizationContext.Current).ConfigureAwait(continueOnCapturedContext: false);
		return ret;
	}

	private static void PlatformBeginInvokeOnMainThread(Action action)
	{
		if (handler?.Looper != Looper.MainLooper)
		{
			handler = new Handler(Looper.MainLooper);
		}
		handler.Post(action);
	}
}
public static class Permissions
{
	public abstract class BasePermission
	{
		public BasePermission()
		{
		}

		public abstract Task<PermissionStatus> CheckStatusAsync();

		public abstract Task<PermissionStatus> RequestAsync();

		public abstract void EnsureDeclared();
	}

	public class LocationWhenInUse : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new(string, bool)[2]
		{
			("android.permission.ACCESS_COARSE_LOCATION", true),
			("android.permission.ACCESS_FINE_LOCATION", true)
		};

		public override Task<PermissionStatus> CheckStatusAsync()
		{
			if (DoCheck("android.permission.ACCESS_FINE_LOCATION") == PermissionStatus.Granted)
			{
				return Task.FromResult(PermissionStatus.Granted);
			}
			if (DoCheck("android.permission.ACCESS_COARSE_LOCATION") == PermissionStatus.Granted)
			{
				return Task.FromResult(PermissionStatus.Restricted);
			}
			return Task.FromResult(PermissionStatus.Denied);
		}

		public override async Task<PermissionStatus> RequestAsync()
		{
			if (await CheckStatusAsync() == PermissionStatus.Granted)
			{
				return PermissionStatus.Granted;
			}
			return (await DoRequest(new string[2] { "android.permission.ACCESS_COARSE_LOCATION", "android.permission.ACCESS_FINE_LOCATION" })).GrantResults.Count((Permission x) => x == Permission.Granted) switch
			{
				2 => PermissionStatus.Granted, 
				1 => PermissionStatus.Restricted, 
				_ => PermissionStatus.Denied, 
			};
		}
	}

	public class NetworkState : BasePlatformPermission
	{
		public override (string androidPermission, bool isRuntime)[] RequiredPermissions
		{
			get
			{
				List<(string, bool)> list = new List<(string, bool)> { ("android.permission.ACCESS_NETWORK_STATE", false) };
				if (IsDeclaredInManifest("android.permission.CHANGE_NETWORK_STATE"))
				{
					list.Add(("android.permission.CHANGE_NETWORK_STATE", true));
				}
				return list.ToArray();
			}
		}
	}

	public class PermissionResult
	{
		public Permission[] GrantResults { get; }
	}

	public abstract class BasePlatformPermission : BasePermission
	{
		private static readonly Dictionary<int, TaskCompletionSource<PermissionResult>> requests = new Dictionary<int, TaskCompletionSource<PermissionResult>>();

		private static readonly object locker = new object();

		private static int requestCode;

		public virtual (string androidPermission, bool isRuntime)[] RequiredPermissions { get; }

		public override Task<PermissionStatus> CheckStatusAsync()
		{
			if (RequiredPermissions == null || RequiredPermissions.Length == 0)
			{
				return Task.FromResult(PermissionStatus.Granted);
			}
			(string, bool)[] requiredPermissions = RequiredPermissions;
			for (int i = 0; i < requiredPermissions.Length; i++)
			{
				string item = requiredPermissions[i].Item1;
				string text = item;
				if (!IsDeclaredInManifest(text))
				{
					throw new PermissionException("You need to declare using the permission: `" + item + "` in your AndroidManifest.xml");
				}
				if (DoCheck(text) != PermissionStatus.Granted)
				{
					return Task.FromResult(PermissionStatus.Denied);
				}
			}
			return Task.FromResult(PermissionStatus.Granted);
		}

		public override async Task<PermissionStatus> RequestAsync()
		{
			if (await CheckStatusAsync() == PermissionStatus.Granted)
			{
				return PermissionStatus.Granted;
			}
			string[] array = RequiredPermissions.Where(((string androidPermission, bool isRuntime) p) => p.isRuntime)?.Select(((string androidPermission, bool isRuntime) p) => p.androidPermission)?.ToArray();
			if (array == null || !array.Any())
			{
				return PermissionStatus.Granted;
			}
			if ((await DoRequest(array)).GrantResults.Any((Permission g) => g == Permission.Denied))
			{
				return PermissionStatus.Denied;
			}
			return PermissionStatus.Granted;
		}

		protected virtual PermissionStatus DoCheck(string androidPermission)
		{
			Context appContext = Platform.AppContext;
			bool num = appContext.ApplicationInfo.TargetSdkVersion >= BuildVersionCodes.M;
			if (!IsDeclaredInManifest(androidPermission))
			{
				throw new PermissionException("You need to declare using the permission: `" + androidPermission + "` in your AndroidManifest.xml");
			}
			PermissionStatus permissionStatus = PermissionStatus.Granted;
			if (num)
			{
				return ContextCompat.CheckSelfPermission(appContext, androidPermission) switch
				{
					Permission.Granted => PermissionStatus.Granted, 
					Permission.Denied => PermissionStatus.Denied, 
					_ => PermissionStatus.Unknown, 
				};
			}
			return PermissionChecker.CheckSelfPermission(appContext, androidPermission) switch
			{
				0 => PermissionStatus.Granted, 
				-1 => PermissionStatus.Denied, 
				-2 => PermissionStatus.Denied, 
				_ => PermissionStatus.Unknown, 
			};
		}

		protected virtual async Task<PermissionResult> DoRequest(string[] permissions)
		{
			TaskCompletionSource<PermissionResult> taskCompletionSource;
			lock (locker)
			{
				taskCompletionSource = new TaskCompletionSource<PermissionResult>();
				requestCode = Platform.NextRequestCode();
				requests.Add(requestCode, taskCompletionSource);
			}
			if (!MainThread.IsMainThread)
			{
				throw new PermissionException("Permission request must be invoked on main thread.");
			}
			ActivityCompat.RequestPermissions(Platform.GetCurrentActivity(throwOnNull: true), permissions.ToArray(), requestCode);
			return await taskCompletionSource.Task;
		}

		public override void EnsureDeclared()
		{
			if (RequiredPermissions == null || RequiredPermissions.Length == 0)
			{
				return;
			}
			(string, bool)[] requiredPermissions = RequiredPermissions;
			for (int i = 0; i < requiredPermissions.Length; i++)
			{
				string item = requiredPermissions[i].Item1;
				if (!IsDeclaredInManifest(item))
				{
					throw new PermissionException("You need to declare using the permission: `" + item + "` in your AndroidManifest.xml");
				}
			}
		}
	}

	public static Task<PermissionStatus> RequestAsync<TPermission>() where TPermission : BasePermission, new()
	{
		return new TPermission().RequestAsync();
	}

	internal static void EnsureDeclared<TPermission>() where TPermission : BasePermission, new()
	{
		new TPermission().EnsureDeclared();
	}

	internal static async Task EnsureGrantedOrRestrictedAsync<TPermission>() where TPermission : BasePermission, new()
	{
		PermissionStatus permissionStatus = await RequestAsync<TPermission>();
		if (permissionStatus != PermissionStatus.Granted && permissionStatus != PermissionStatus.Restricted)
		{
			throw new PermissionException($"{typeof(TPermission).Name} permission was not granted or restricted: {permissionStatus}");
		}
	}

	public static bool IsDeclaredInManifest(string permission)
	{
		Context appContext = Platform.AppContext;
		return (appContext.PackageManager.GetPackageInfo(appContext.PackageName, PackageInfoFlags.Permissions)?.RequestedPermissions)?.Any((string r) => r.Equals(permission, StringComparison.OrdinalIgnoreCase)) ?? false;
	}
}
public static class Platform
{
	private static ActivityLifecycleContextListener lifecycleListener;

	private static int requestCode = 12000;

	private static int? sdkInt;

	public static Context AppContext => Application.Context;

	public static Activity CurrentActivity => lifecycleListener?.Activity;

	internal static bool HasApiLevelN => HasApiLevel(24);

	internal static bool HasApiLevelO => HasApiLevel(26);

	internal static int SdkInt
	{
		get
		{
			int valueOrDefault = sdkInt.GetValueOrDefault();
			if (!sdkInt.HasValue)
			{
				valueOrDefault = (int)Build.VERSION.SdkInt;
				sdkInt = valueOrDefault;
				return valueOrDefault;
			}
			return valueOrDefault;
		}
	}

	internal static ConnectivityManager ConnectivityManager => AppContext.GetSystemService("connectivity") as ConnectivityManager;

	internal static LocationManager LocationManager => AppContext.GetSystemService("location") as LocationManager;

	public static event EventHandler<ActivityStateChangedEventArgs> ActivityStateChanged;

	internal static int NextRequestCode()
	{
		if (++requestCode >= 12999)
		{
			requestCode = 12000;
		}
		return requestCode;
	}

	internal static void OnActivityStateChanged(Activity activity, ActivityState ev)
	{
		Platform.ActivityStateChanged?.Invoke(null, new ActivityStateChangedEventArgs(activity, ev));
	}

	internal static Activity GetCurrentActivity(bool throwOnNull)
	{
		Activity activity = lifecycleListener?.Activity;
		if (throwOnNull && activity == null)
		{
			throw new NullReferenceException("The current Activity can not be detected. Ensure that you have called Init in your Activity or Application class.");
		}
		return activity;
	}

	public static void Init(Application application)
	{
		lifecycleListener = new ActivityLifecycleContextListener();
		application.RegisterActivityLifecycleCallbacks(lifecycleListener);
	}

	public static void Init(Activity activity, Bundle bundle)
	{
		Init(activity.Application);
		lifecycleListener.Activity = activity;
	}

	internal static bool IsIntentSupported(Intent intent)
	{
		return intent.ResolveActivity(AppContext.PackageManager) != null;
	}

	internal static bool IsIntentSupported(Intent intent, string expectedPackageName)
	{
		ComponentName componentName = intent.ResolveActivity(AppContext.PackageManager);
		if (componentName != null)
		{
			return componentName.PackageName == expectedPackageName;
		}
		return false;
	}

	internal static bool HasApiLevel(BuildVersionCodes versionCode)
	{
		return SdkInt >= (int)versionCode;
	}

	internal static bool HasApiLevel(int apiLevel)
	{
		return SdkInt >= apiLevel;
	}
}
public static class Preferences
{
	private static readonly object locker = new object();

	internal static string GetPrivatePreferencesSharedName(string feature)
	{
		return AppInfo.PackageName + ".xamarinessentials." + feature;
	}

	public static bool ContainsKey(string key, string sharedName)
	{
		return PlatformContainsKey(key, sharedName);
	}

	public static string Get(string key, string defaultValue, string sharedName)
	{
		return PlatformGet(key, defaultValue, sharedName);
	}

	public static void Set(string key, string value, string sharedName)
	{
		PlatformSet(key, value, sharedName);
	}

	private static bool PlatformContainsKey(string key, string sharedName)
	{
		lock (locker)
		{
			using ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName);
			return sharedPreferences.Contains(key);
		}
	}

	private static void PlatformSet<T>(string key, T value, string sharedName)
	{
		lock (locker)
		{
			using ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName);
			using ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit();
			if (value == null)
			{
				sharedPreferencesEditor.Remove(key);
			}
			else if (!(value is string value2))
			{
				if (!(value is int value3))
				{
					if (!(value is bool value4))
					{
						if (!(value is long value5))
						{
							if (!(value is double))
							{
								if (value is float value6)
								{
									sharedPreferencesEditor.PutFloat(key, value6);
								}
							}
							else
							{
								string value7 = Convert.ToString(value, CultureInfo.InvariantCulture);
								sharedPreferencesEditor.PutString(key, value7);
							}
						}
						else
						{
							sharedPreferencesEditor.PutLong(key, value5);
						}
					}
					else
					{
						sharedPreferencesEditor.PutBoolean(key, value4);
					}
				}
				else
				{
					sharedPreferencesEditor.PutInt(key, value3);
				}
			}
			else
			{
				sharedPreferencesEditor.PutString(key, value2);
			}
			sharedPreferencesEditor.Apply();
		}
	}

	private static T PlatformGet<T>(string key, T defaultValue, string sharedName)
	{
		lock (locker)
		{
			object obj = null;
			using (ISharedPreferences sharedPreferences = GetSharedPreferences(sharedName))
			{
				if (defaultValue == null)
				{
					obj = sharedPreferences.GetString(key, null);
				}
				else if (!(defaultValue is int defValue))
				{
					if (!(defaultValue is bool defValue2))
					{
						if (!(defaultValue is long defValue3))
						{
							if (!(defaultValue is double))
							{
								if (!(defaultValue is float defValue4))
								{
									if (defaultValue is string defValue5)
									{
										obj = sharedPreferences.GetString(key, defValue5);
									}
								}
								else
								{
									obj = sharedPreferences.GetFloat(key, defValue4);
								}
							}
							else
							{
								string text = sharedPreferences.GetString(key, null);
								if (string.IsNullOrWhiteSpace(text))
								{
									obj = defaultValue;
								}
								else
								{
									if (!double.TryParse(text, NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out var result))
									{
										string value = Convert.ToString(1.7976931348623157E+308, CultureInfo.InvariantCulture);
										result = (text.Equals(value) ? 1.7976931348623157E+308 : (-1.7976931348623157E+308));
									}
									obj = result;
								}
							}
						}
						else
						{
							obj = sharedPreferences.GetLong(key, defValue3);
						}
					}
					else
					{
						obj = sharedPreferences.GetBoolean(key, defValue2);
					}
				}
				else
				{
					obj = sharedPreferences.GetInt(key, defValue);
				}
			}
			return (T)obj;
		}
	}

	private static ISharedPreferences GetSharedPreferences(string sharedName)
	{
		Context context = Application.Context;
		if (!string.IsNullOrWhiteSpace(sharedName))
		{
			return context.GetSharedPreferences(sharedName, FileCreationMode.Private);
		}
		return PreferenceManager.GetDefaultSharedPreferences(context);
	}
}
public static class Share
{
	public static Task RequestAsync(ShareTextRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (string.IsNullOrEmpty(request.Text) && string.IsNullOrEmpty(request.Uri))
		{
			throw new ArgumentException("Both the Text and Uri are invalid. Make sure to include at least one of them in the request.");
		}
		return PlatformRequestAsync(request);
	}

	private static Task PlatformRequestAsync(ShareTextRequest request)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(request.Text))
		{
			list.Add(request.Text);
		}
		if (!string.IsNullOrWhiteSpace(request.Uri))
		{
			list.Add(request.Uri);
		}
		Intent intent = new Intent("android.intent.action.SEND");
		intent.SetType("text/plain");
		intent.PutExtra("android.intent.extra.TEXT", string.Join(System.Environment.NewLine, list));
		if (!string.IsNullOrWhiteSpace(request.Subject))
		{
			intent.PutExtra("android.intent.extra.SUBJECT", request.Subject);
		}
		Intent intent2 = Intent.CreateChooser(intent, request.Title ?? string.Empty);
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent2.SetFlags(flags);
		Platform.AppContext.StartActivity(intent2);
		return Task.CompletedTask;
	}
}
public abstract class ShareRequestBase
{
	[CompilerGenerated]
	private Rectangle <PresentationSourceBounds>k__BackingField = Rectangle.Empty;

	public string Title { get; }

	public Rectangle PresentationSourceBounds
	{
		[CompilerGenerated]
		set
		{
			<PresentationSourceBounds>k__BackingField = value;
		}
	}
}
public class ShareTextRequest : ShareRequestBase
{
	public string Subject { get; }

	public string Text { get; set; }

	public string Uri { get; set; }
}
public readonly struct DeviceIdiom : IEquatable<DeviceIdiom>
{
	private readonly string deviceIdiom;

	public static DeviceIdiom Phone { get; } = new DeviceIdiom("Phone");

	public static DeviceIdiom Tablet { get; } = new DeviceIdiom("Tablet");

	public static DeviceIdiom Desktop { get; } = new DeviceIdiom("Desktop");

	public static DeviceIdiom TV { get; } = new DeviceIdiom("TV");

	public static DeviceIdiom Watch { get; } = new DeviceIdiom("Watch");

	public static DeviceIdiom Unknown { get; } = new DeviceIdiom("Unknown");

	private DeviceIdiom(string deviceIdiom)
	{
		if (deviceIdiom == null)
		{
			throw new ArgumentNullException("deviceIdiom");
		}
		if (deviceIdiom.Length == 0)
		{
			throw new ArgumentException("deviceIdiom");
		}
		this.deviceIdiom = deviceIdiom;
	}

	public bool Equals(DeviceIdiom other)
	{
		return Equals(other.deviceIdiom);
	}

	internal bool Equals(string other)
	{
		return string.Equals(deviceIdiom, other, StringComparison.Ordinal);
	}

	public override bool Equals(object obj)
	{
		if (obj is DeviceIdiom)
		{
			return Equals((DeviceIdiom)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (deviceIdiom != null)
		{
			return deviceIdiom.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		return deviceIdiom ?? string.Empty;
	}

	public static bool operator ==(DeviceIdiom left, DeviceIdiom right)
	{
		return left.Equals(right);
	}
}
public readonly struct DevicePlatform : IEquatable<DevicePlatform>
{
	private readonly string devicePlatform;

	[CompilerGenerated]
	private static readonly DevicePlatform <macOS>k__BackingField = new DevicePlatform("macOS");

	[CompilerGenerated]
	private static readonly DevicePlatform <tvOS>k__BackingField = new DevicePlatform("tvOS");

	[CompilerGenerated]
	private static readonly DevicePlatform <Tizen>k__BackingField = new DevicePlatform("Tizen");

	[CompilerGenerated]
	private static readonly DevicePlatform <UWP>k__BackingField = new DevicePlatform("UWP");

	[CompilerGenerated]
	private static readonly DevicePlatform <watchOS>k__BackingField = new DevicePlatform("watchOS");

	[CompilerGenerated]
	private static readonly DevicePlatform <Unknown>k__BackingField = new DevicePlatform("Unknown");

	public static DevicePlatform Android { get; } = new DevicePlatform("Android");

	public static DevicePlatform iOS { get; } = new DevicePlatform("iOS");

	private DevicePlatform(string devicePlatform)
	{
		if (devicePlatform == null)
		{
			throw new ArgumentNullException("devicePlatform");
		}
		if (devicePlatform.Length == 0)
		{
			throw new ArgumentException("devicePlatform");
		}
		this.devicePlatform = devicePlatform;
	}

	public bool Equals(DevicePlatform other)
	{
		return Equals(other.devicePlatform);
	}

	internal bool Equals(string other)
	{
		return string.Equals(devicePlatform, other, StringComparison.Ordinal);
	}

	public override bool Equals(object obj)
	{
		if (obj is DevicePlatform)
		{
			return Equals((DevicePlatform)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (devicePlatform != null)
		{
			return devicePlatform.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		return devicePlatform ?? string.Empty;
	}

	public static bool operator ==(DevicePlatform left, DevicePlatform right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DevicePlatform left, DevicePlatform right)
	{
		return !left.Equals(right);
	}
}
public readonly struct DisplayInfo : IEquatable<DisplayInfo>
{
	public double Width { get; }

	public double Height { get; }

	public double Density { get; }

	public DisplayOrientation Orientation { get; }

	public DisplayRotation Rotation { get; }

	public float RefreshRate { get; }

	public DisplayInfo(double width, double height, double density, DisplayOrientation orientation, DisplayRotation rotation)
	{
		Width = width;
		Height = height;
		Density = density;
		Orientation = orientation;
		Rotation = rotation;
		RefreshRate = 0f;
	}

	public DisplayInfo(double width, double height, double density, DisplayOrientation orientation, DisplayRotation rotation, float rate)
	{
		Width = width;
		Height = height;
		Density = density;
		Orientation = orientation;
		Rotation = rotation;
		RefreshRate = rate;
	}

	public static bool operator ==(DisplayInfo left, DisplayInfo right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DisplayInfo left, DisplayInfo right)
	{
		return !left.Equals(right);
	}

	public override bool Equals(object obj)
	{
		if (obj is DisplayInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(DisplayInfo other)
	{
		if (Width.Equals(other.Width) && Height.Equals(other.Height) && Density.Equals(other.Density) && Orientation.Equals(other.Orientation))
		{
			return Rotation.Equals(other.Rotation);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Height, Width, Density, Orientation, Rotation).GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}, ", "Height", Height, "Width", Width) + string.Format("{0}: {1}, {2}: {3}, ", "Density", Density, "Orientation", Orientation) + string.Format("{0}: {1}", "Rotation", Rotation);
	}
}
public enum DisplayOrientation
{
	Unknown,
	Portrait,
	Landscape
}
public enum DisplayRotation
{
	Unknown,
	Rotation0,
	Rotation90,
	Rotation180,
	Rotation270
}
public enum AltitudeReferenceSystem
{
	Unspecified,
	Terrain,
	Ellipsoid,
	Geoid,
	Surface
}
public class Location
{
	[CompilerGenerated]
	private bool <IsFromMockProvider>k__BackingField;

	[CompilerGenerated]
	private AltitudeReferenceSystem <AltitudeReferenceSystem>k__BackingField;

	public DateTimeOffset Timestamp { get; set; }

	public double Latitude { get; set; }

	public double Longitude { get; set; }

	public double? Altitude { get; set; }

	public double? Accuracy { get; set; }

	public double? VerticalAccuracy { get; set; }

	public double? Speed { get; set; }

	public double? Course { get; set; }

	public bool IsFromMockProvider
	{
		[CompilerGenerated]
		set
		{
			<IsFromMockProvider>k__BackingField = value;
		}
	}

	public AltitudeReferenceSystem AltitudeReferenceSystem
	{
		[CompilerGenerated]
		set
		{
			<AltitudeReferenceSystem>k__BackingField = value;
		}
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, ", "Latitude", Latitude) + string.Format("{0}: {1}, ", "Longitude", Longitude) + string.Format("{0}: {1}, ", "Altitude", Altitude) + string.Format("{0}: {1}, ", "Accuracy", Accuracy) + string.Format("{0}: {1}, ", "VerticalAccuracy", VerticalAccuracy) + string.Format("{0}: {1}, ", "Speed", Speed) + string.Format("{0}: {1}, ", "Course", Course) + string.Format("{0}: {1}", "Timestamp", Timestamp);
	}
}
public static class LocationExtensions
{
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	internal static Location ToLocation(this Android.Locations.Location location)
	{
		return new Location
		{
			Latitude = location.Latitude,
			Longitude = location.Longitude,
			Altitude = (location.HasAltitude ? new double?(location.Altitude) : ((double?)null)),
			Timestamp = location.GetTimestamp().ToUniversalTime(),
			Accuracy = (location.HasAccuracy ? new float?(location.Accuracy) : ((float?)null)),
			VerticalAccuracy = ((Platform.HasApiLevelO && location.HasVerticalAccuracy) ? new float?(location.VerticalAccuracyMeters) : ((float?)null)),
			Course = (location.HasBearing ? new double?(location.Bearing) : ((double?)null)),
			Speed = (location.HasSpeed ? new double?(location.Speed) : ((double?)null)),
			IsFromMockProvider = (Platform.HasApiLevel(BuildVersionCodes.JellyBeanMr2) && location.IsFromMockProvider),
			AltitudeReferenceSystem = AltitudeReferenceSystem.Ellipsoid
		};
	}

	internal static DateTimeOffset GetTimestamp(this Android.Locations.Location location)
	{
		try
		{
			return new DateTimeOffset(epoch.AddMilliseconds(location.Time));
		}
		catch (System.Exception)
		{
			return new DateTimeOffset(epoch);
		}
	}
}
public static class ColorExtensions
{
	public static int ToInt(this Color color)
	{
		return (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;
	}
}
public class PermissionException : UnauthorizedAccessException
{
	public PermissionException(string message)
		: base(message)
	{
	}
}
public class FeatureNotSupportedException : NotSupportedException
{
}
public class FeatureNotEnabledException : InvalidOperationException
{
	public FeatureNotEnabledException(string message)
		: base(message)
	{
	}
}
internal static class Utils
{
	internal static CancellationToken TimeoutToken(CancellationToken cancellationToken, TimeSpan timeout)
	{
		CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		if (timeout > TimeSpan.Zero)
		{
			cancellationTokenSource.CancelAfter(timeout);
		}
		return cancellationTokenSource.Token;
	}
}
internal static class WebUtils
{
	internal static IDictionary<string, string> ParseQueryString(string url)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (string.IsNullOrWhiteSpace(url) || (!url.Contains("?") && !url.Contains("#")))
		{
			return dictionary;
		}
		int num = url.IndexOf('?');
		if (num < 0)
		{
			num = url.IndexOf('#');
		}
		if (url.Length - 1 < num + 1)
		{
			return dictionary;
		}
		string[] array = url.Substring(num + 1).Split('&');
		if (array == null || !array.Any())
		{
			return dictionary;
		}
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(new char[1] { '=' }, 2);
			if (array3 != null && array3.Length == 2)
			{
				dictionary[array3[0]] = array3[1];
			}
		}
		return dictionary;
	}

	internal static bool CanHandleCallback(System.Uri expectedUrl, System.Uri callbackUrl)
	{
		if (!callbackUrl.Scheme.Equals(expectedUrl.Scheme, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(expectedUrl.Host) && !callbackUrl.Host.Equals(expectedUrl.Host, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		return true;
	}
}
public static class VersionTracking
{
	private static readonly string sharedName;

	private static Dictionary<string, List<string>> versionTrail;

	public static bool IsFirstLaunchEver { get; private set; }

	public static bool IsFirstLaunchForCurrentVersion { get; private set; }

	public static bool IsFirstLaunchForCurrentBuild { get; private set; }

	public static string CurrentVersion => AppInfo.VersionString;

	public static string CurrentBuild => AppInfo.BuildString;

	private static string LastInstalledVersion => versionTrail["VersionTracking.Versions"].LastOrDefault();

	private static string LastInstalledBuild => versionTrail["VersionTracking.Builds"].LastOrDefault();

	static VersionTracking()
	{
		sharedName = Preferences.GetPrivatePreferencesSharedName("versiontracking");
		InitVersionTracking();
	}

	internal static void InitVersionTracking()
	{
		IsFirstLaunchEver = !Preferences.ContainsKey("VersionTracking.Versions", sharedName) || !Preferences.ContainsKey("VersionTracking.Builds", sharedName);
		if (IsFirstLaunchEver)
		{
			versionTrail = new Dictionary<string, List<string>>
			{
				{
					"VersionTracking.Versions",
					new List<string>()
				},
				{
					"VersionTracking.Builds",
					new List<string>()
				}
			};
		}
		else
		{
			versionTrail = new Dictionary<string, List<string>>
			{
				{
					"VersionTracking.Versions",
					ReadHistory("VersionTracking.Versions").ToList()
				},
				{
					"VersionTracking.Builds",
					ReadHistory("VersionTracking.Builds").ToList()
				}
			};
		}
		IsFirstLaunchForCurrentVersion = !versionTrail["VersionTracking.Versions"].Contains(CurrentVersion) || CurrentVersion != LastInstalledVersion;
		if (IsFirstLaunchForCurrentVersion)
		{
			versionTrail["VersionTracking.Versions"].RemoveAll((string v) => v == CurrentVersion);
			versionTrail["VersionTracking.Versions"].Add(CurrentVersion);
		}
		IsFirstLaunchForCurrentBuild = !versionTrail["VersionTracking.Builds"].Contains(CurrentBuild) || CurrentBuild != LastInstalledBuild;
		if (IsFirstLaunchForCurrentBuild)
		{
			versionTrail["VersionTracking.Builds"].RemoveAll((string b) => b == CurrentBuild);
			versionTrail["VersionTracking.Builds"].Add(CurrentBuild);
		}
		if (IsFirstLaunchForCurrentVersion || IsFirstLaunchForCurrentBuild)
		{
			WriteHistory("VersionTracking.Versions", versionTrail["VersionTracking.Versions"]);
			WriteHistory("VersionTracking.Builds", versionTrail["VersionTracking.Builds"]);
		}
	}

	public static void Track()
	{
	}

	private static string[] ReadHistory(string key)
	{
		return Preferences.Get(key, null, sharedName)?.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
	}

	private static void WriteHistory(string key, IEnumerable<string> history)
	{
		Preferences.Set(key, string.Join("|", history), sharedName);
	}
}
public static class WebAuthenticator
{
	private static TaskCompletionSource<WebAuthenticatorResult> tcsResponse;

	private static System.Uri currentRedirectUri;

	public static Task<WebAuthenticatorResult> AuthenticateAsync(System.Uri url, System.Uri callbackUrl)
	{
		return PlatformAuthenticateAsync(new WebAuthenticatorOptions
		{
			Url = url,
			CallbackUrl = callbackUrl
		});
	}

	internal static bool OnResume(Intent intent)
	{
		if (tcsResponse?.Task?.IsCompleted ?? true)
		{
			return false;
		}
		if (intent?.Data == null)
		{
			tcsResponse.TrySetCanceled();
			return false;
		}
		try
		{
			System.Uri uri = new System.Uri(intent.Data.ToString());
			if (!WebUtils.CanHandleCallback(currentRedirectUri, uri))
			{
				tcsResponse.TrySetException(new InvalidOperationException($"Invalid Redirect URI, detected `{uri}` but expected a URI in the format of `{currentRedirectUri}`"));
				return false;
			}
			tcsResponse?.TrySetResult(new WebAuthenticatorResult(uri));
			return true;
		}
		catch (System.Exception exception)
		{
			tcsResponse.TrySetException(exception);
			return false;
		}
	}

	private static async Task<WebAuthenticatorResult> PlatformAuthenticateAsync(WebAuthenticatorOptions webAuthenticatorOptions)
	{
		System.Uri url = webAuthenticatorOptions?.Url;
		System.Uri uri = webAuthenticatorOptions?.CallbackUrl;
		string packageName = Platform.AppContext.PackageName;
		Intent intent = new Intent("android.intent.action.VIEW");
		intent.AddCategory("android.intent.category.BROWSABLE");
		intent.AddCategory("android.intent.category.DEFAULT");
		intent.SetPackage(packageName);
		intent.SetData(Android.Net.Uri.Parse(uri.OriginalString));
		if (!Platform.IsIntentSupported(intent, packageName))
		{
			throw new InvalidOperationException("You must subclass the `WebAuthenticatorCallbackActivity` and create an IntentFilter for it which matches your `callbackUrl`.");
		}
		if (tcsResponse?.Task != null && !tcsResponse.Task.IsCompleted)
		{
			tcsResponse.TrySetCanceled();
		}
		tcsResponse = new TaskCompletionSource<WebAuthenticatorResult>();
		currentRedirectUri = uri;
		if (!(await StartCustomTabsActivity(url)))
		{
			string originalString = url.OriginalString;
			Intent intent2 = new Intent("android.intent.action.VIEW", Android.Net.Uri.Parse(originalString));
			Platform.CurrentActivity.StartActivity(intent2);
		}
		return await tcsResponse.Task;
	}

	private static async Task<bool> StartCustomTabsActivity(System.Uri url)
	{
		bool success = false;
		Activity parentActivity = Platform.GetCurrentActivity(throwOnNull: true);
		CustomTabsActivityManager customTabsActivityManager = CustomTabsActivityManager.From(parentActivity);
		try
		{
			if (await BindServiceAsync(customTabsActivityManager))
			{
				CustomTabsIntent customTabsIntent = new CustomTabsIntent.Builder(customTabsActivityManager.Session).SetShowTitle(showTitle: true).Build();
				customTabsIntent.Intent.SetData(Android.Net.Uri.Parse(url.OriginalString));
				if (customTabsIntent.Intent.ResolveActivity(parentActivity.PackageManager) != null)
				{
					WebAuthenticatorIntermediateActivity.StartActivity(parentActivity, customTabsIntent.Intent);
					success = true;
				}
			}
		}
		finally
		{
			customTabsActivityManager.Client?.Dispose();
		}
		return success;
	}

	private static Task<bool> BindServiceAsync(CustomTabsActivityManager manager)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		manager.CustomTabsServiceConnected += OnCustomTabsServiceConnected;
		if (!manager.BindService())
		{
			manager.CustomTabsServiceConnected -= OnCustomTabsServiceConnected;
			tcs.TrySetResult(result: false);
		}
		return tcs.Task;
		void OnCustomTabsServiceConnected(ComponentName name, CustomTabsClient client)
		{
			manager.CustomTabsServiceConnected -= OnCustomTabsServiceConnected;
			tcs.TrySetResult(result: true);
		}
	}
}
public class WebAuthenticatorOptions
{
	public System.Uri Url { get; set; }

	public System.Uri CallbackUrl { get; set; }
}
public class WebAuthenticatorResult
{
	[CompilerGenerated]
	private DateTimeOffset <Timestamp>k__BackingField = new DateTimeOffset(DateTime.UtcNow);

	public Dictionary<string, string> Properties { get; } = new Dictionary<string, string>();

	public WebAuthenticatorResult(System.Uri uri)
	{
		foreach (KeyValuePair<string, string> item in WebUtils.ParseQueryString(uri.ToString()))
		{
			Properties[item.Key] = item.Value;
		}
	}
}
public enum NetworkAccess
{
	Unknown,
	None,
	Local,
	ConstrainedInternet,
	Internet
}
public enum PermissionStatus
{
	Unknown,
	Denied,
	Disabled,
	Granted,
	Restricted
}
internal class SingleLocationListener : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly object locationSync = new object();

	private float desiredAccuracy;

	private HashSet<string> activeProviders = new HashSet<string>();

	private bool wasRaised;

	internal Android.Locations.Location BestLocation { get; set; }

	internal Action<Android.Locations.Location> LocationHandler { get; set; }

	internal SingleLocationListener(LocationManager manager, float desiredAccuracy, IEnumerable<string> activeProviders)
	{
		this.desiredAccuracy = desiredAccuracy;
		this.activeProviders = new HashSet<string>(activeProviders);
		foreach (string activeProvider in activeProviders)
		{
			Android.Locations.Location lastKnownLocation = manager.GetLastKnownLocation(activeProvider);
			if (lastKnownLocation != null && Geolocation.IsBetterLocation(lastKnownLocation, BestLocation))
			{
				BestLocation = lastKnownLocation;
			}
		}
	}

	void ILocationListener.OnLocationChanged(Android.Locations.Location location)
	{
		if (location.Accuracy <= desiredAccuracy)
		{
			if (!wasRaised)
			{
				wasRaised = true;
				LocationHandler?.Invoke(location);
			}
			return;
		}
		lock (locationSync)
		{
			if (Geolocation.IsBetterLocation(location, BestLocation))
			{
				BestLocation = location;
			}
		}
	}

	void ILocationListener.OnProviderDisabled(string provider)
	{
		lock (activeProviders)
		{
			activeProviders.Remove(provider);
		}
	}

	void ILocationListener.OnProviderEnabled(string provider)
	{
		lock (activeProviders)
		{
			activeProviders.Add(provider);
		}
	}

	void ILocationListener.OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
	{
		switch (status)
		{
		case Availability.Available:
			((ILocationListener)this).OnProviderEnabled(provider);
			break;
		case Availability.OutOfService:
			((ILocationListener)this).OnProviderDisabled(provider);
			break;
		}
	}
}
public enum ActivityState
{
	Created,
	Resumed,
	Paused,
	Destroyed,
	SaveInstanceState,
	Started,
	Stopped
}
public class ActivityStateChangedEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly Activity <Activity>k__BackingField;

	public ActivityState State { get; }

	internal ActivityStateChangedEventArgs(Activity activity, ActivityState ev)
	{
		State = ev;
		<Activity>k__BackingField = activity;
	}
}
internal class ActivityLifecycleContextListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable, IJavaPeerable
{
	private WeakReference<Activity> currentActivity = new WeakReference<Activity>(null);

	internal Context Context => Activity ?? Application.Context;

	internal Activity Activity
	{
		get
		{
			if (!currentActivity.TryGetTarget(out var target))
			{
				return null;
			}
			return target;
		}
		set
		{
			currentActivity.SetTarget(value);
		}
	}

	void Application.IActivityLifecycleCallbacks.OnActivityCreated(Activity activity, Bundle savedInstanceState)
	{
		Activity = activity;
		Platform.OnActivityStateChanged(activity, ActivityState.Created);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityDestroyed(Activity activity)
	{
		Platform.OnActivityStateChanged(activity, ActivityState.Destroyed);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityPaused(Activity activity)
	{
		Activity = activity;
		Platform.OnActivityStateChanged(activity, ActivityState.Paused);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityResumed(Activity activity)
	{
		Activity = activity;
		Platform.OnActivityStateChanged(activity, ActivityState.Resumed);
	}

	void Application.IActivityLifecycleCallbacks.OnActivitySaveInstanceState(Activity activity, Bundle outState)
	{
		Platform.OnActivityStateChanged(activity, ActivityState.SaveInstanceState);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityStarted(Activity activity)
	{
		Platform.OnActivityStateChanged(activity, ActivityState.Started);
	}

	void Application.IActivityLifecycleCallbacks.OnActivityStopped(Activity activity)
	{
		Platform.OnActivityStateChanged(activity, ActivityState.Stopped);
	}
}
public abstract class WebAuthenticatorCallbackActivity : Activity
{
	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Intent intent = new Intent(this, typeof(WebAuthenticatorIntermediateActivity));
		intent.SetData(Intent.Data);
		intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
		StartActivity(intent);
		Finish();
	}
}
[Activity(ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize))]
internal class WebAuthenticatorIntermediateActivity : Activity
{
	private bool launched;

	private Intent actualIntent;

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Bundle bundle = savedInstanceState ?? Intent.Extras;
		launched = bundle?.GetBoolean("launched", defaultValue: false) ?? false;
		actualIntent = bundle?.GetParcelable("actual_intent") as Intent;
	}

	protected override void OnResume()
	{
		base.OnResume();
		if (actualIntent != null && !launched)
		{
			StartActivity(actualIntent);
			launched = true;
		}
		else
		{
			WebAuthenticator.OnResume(Intent);
			Finish();
		}
	}

	protected override void OnNewIntent(Intent intent)
	{
		base.OnNewIntent(intent);
		Intent = intent;
	}

	protected override void OnSaveInstanceState(Bundle outState)
	{
		outState.PutBoolean("launched", launched);
		outState.PutParcelable("actual_intent", actualIntent);
		base.OnSaveInstanceState(outState);
	}

	public static void StartActivity(Activity activity, Intent intent)
	{
		Intent intent2 = new Intent(activity, typeof(WebAuthenticatorIntermediateActivity));
		intent2.PutExtra("actual_intent", intent);
		activity.StartActivity(intent2);
	}
}
[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
public class Resource
{
	public class Attribute
	{
		public static int alpha;

		public static int font;

		public static int fontProviderAuthority;

		public static int fontProviderCerts;

		public static int fontProviderFetchStrategy;

		public static int fontProviderFetchTimeout;

		public static int fontProviderPackage;

		public static int fontProviderQuery;

		public static int fontStyle;

		public static int fontVariationSettings;

		public static int fontWeight;

		public static int ttcIndex;

		static Attribute()
		{
			alpha = 2130771968;
			font = 2130771969;
			fontProviderAuthority = 2130771970;
			fontProviderCerts = 2130771971;
			fontProviderFetchStrategy = 2130771972;
			fontProviderFetchTimeout = 2130771973;
			fontProviderPackage = 2130771974;
			fontProviderQuery = 2130771975;
			fontStyle = 2130771976;
			fontVariationSettings = 2130771977;
			fontWeight = 2130771978;
			ttcIndex = 2130771979;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Color
	{
		public static int androidx_core_ripple_material_light;

		public static int androidx_core_secondary_text_default_material_light;

		public static int browser_actions_bg_grey;

		public static int browser_actions_divider_color;

		public static int browser_actions_text_color;

		public static int browser_actions_title_color;

		public static int notification_action_color_filter;

		public static int notification_icon_bg_color;

		static Color()
		{
			androidx_core_ripple_material_light = 2130837504;
			androidx_core_secondary_text_default_material_light = 2130837505;
			browser_actions_bg_grey = 2130837506;
			browser_actions_divider_color = 2130837507;
			browser_actions_text_color = 2130837508;
			browser_actions_title_color = 2130837509;
			notification_action_color_filter = 2130837510;
			notification_icon_bg_color = 2130837511;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Dimension
	{
		public static int browser_actions_context_menu_max_width;

		public static int browser_actions_context_menu_min_padding;

		public static int compat_button_inset_horizontal_material;

		public static int compat_button_inset_vertical_material;

		public static int compat_button_padding_horizontal_material;

		public static int compat_button_padding_vertical_material;

		public static int compat_control_corner_material;

		public static int compat_notification_large_icon_max_height;

		public static int compat_notification_large_icon_max_width;

		public static int notification_action_icon_size;

		public static int notification_action_text_size;

		public static int notification_big_circle_margin;

		public static int notification_content_margin_start;

		public static int notification_large_icon_height;

		public static int notification_large_icon_width;

		public static int notification_main_column_padding_top;

		public static int notification_media_narrow_margin;

		public static int notification_right_icon_size;

		public static int notification_right_side_padding_top;

		public static int notification_small_icon_background_padding;

		public static int notification_small_icon_size_as_large;

		public static int notification_subtext_size;

		public static int notification_top_pad;

		public static int notification_top_pad_large_text;

		static Dimension()
		{
			browser_actions_context_menu_max_width = 2130903040;
			browser_actions_context_menu_min_padding = 2130903041;
			compat_button_inset_horizontal_material = 2130903042;
			compat_button_inset_vertical_material = 2130903043;
			compat_button_padding_horizontal_material = 2130903044;
			compat_button_padding_vertical_material = 2130903045;
			compat_control_corner_material = 2130903046;
			compat_notification_large_icon_max_height = 2130903047;
			compat_notification_large_icon_max_width = 2130903048;
			notification_action_icon_size = 2130903049;
			notification_action_text_size = 2130903050;
			notification_big_circle_margin = 2130903051;
			notification_content_margin_start = 2130903052;
			notification_large_icon_height = 2130903053;
			notification_large_icon_width = 2130903054;
			notification_main_column_padding_top = 2130903055;
			notification_media_narrow_margin = 2130903056;
			notification_right_icon_size = 2130903057;
			notification_right_side_padding_top = 2130903058;
			notification_small_icon_background_padding = 2130903059;
			notification_small_icon_size_as_large = 2130903060;
			notification_subtext_size = 2130903061;
			notification_top_pad = 2130903062;
			notification_top_pad_large_text = 2130903063;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Drawable
	{
		public static int notification_action_background;

		public static int notification_bg;

		public static int notification_bg_low;

		public static int notification_bg_low_normal;

		public static int notification_bg_low_pressed;

		public static int notification_bg_normal;

		public static int notification_bg_normal_pressed;

		public static int notification_icon_background;

		public static int notification_template_icon_bg;

		public static int notification_template_icon_low_bg;

		public static int notification_tile_bg;

		public static int notify_panel_notification_icon_bg;

		static Drawable()
		{
			notification_action_background = 2130968576;
			notification_bg = 2130968577;
			notification_bg_low = 2130968578;
			notification_bg_low_normal = 2130968579;
			notification_bg_low_pressed = 2130968580;
			notification_bg_normal = 2130968581;
			notification_bg_normal_pressed = 2130968582;
			notification_icon_background = 2130968583;
			notification_template_icon_bg = 2130968584;
			notification_template_icon_low_bg = 2130968585;
			notification_tile_bg = 2130968586;
			notify_panel_notification_icon_bg = 2130968587;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Id
	{
		public static int accessibility_action_clickable_span;

		public static int accessibility_custom_action_0;

		public static int accessibility_custom_action_1;

		public static int accessibility_custom_action_10;

		public static int accessibility_custom_action_11;

		public static int accessibility_custom_action_12;

		public static int accessibility_custom_action_13;

		public static int accessibility_custom_action_14;

		public static int accessibility_custom_action_15;

		public static int accessibility_custom_action_16;

		public static int accessibility_custom_action_17;

		public static int accessibility_custom_action_18;

		public static int accessibility_custom_action_19;

		public static int accessibility_custom_action_2;

		public static int accessibility_custom_action_20;

		public static int accessibility_custom_action_21;

		public static int accessibility_custom_action_22;

		public static int accessibility_custom_action_23;

		public static int accessibility_custom_action_24;

		public static int accessibility_custom_action_25;

		public static int accessibility_custom_action_26;

		public static int accessibility_custom_action_27;

		public static int accessibility_custom_action_28;

		public static int accessibility_custom_action_29;

		public static int accessibility_custom_action_3;

		public static int accessibility_custom_action_30;

		public static int accessibility_custom_action_31;

		public static int accessibility_custom_action_4;

		public static int accessibility_custom_action_5;

		public static int accessibility_custom_action_6;

		public static int accessibility_custom_action_7;

		public static int accessibility_custom_action_8;

		public static int accessibility_custom_action_9;

		public static int actions;

		public static int action_container;

		public static int action_divider;

		public static int action_image;

		public static int action_text;

		public static int async;

		public static int blocking;

		public static int browser_actions_header_text;

		public static int browser_actions_menu_items;

		public static int browser_actions_menu_item_icon;

		public static int browser_actions_menu_item_text;

		public static int browser_actions_menu_view;

		public static int chronometer;

		public static int dialog_button;

		public static int forever;

		public static int icon;

		public static int icon_group;

		public static int info;

		public static int italic;

		public static int line1;

		public static int line3;

		public static int normal;

		public static int notification_background;

		public static int notification_main_column;

		public static int notification_main_column_container;

		public static int right_icon;

		public static int right_side;

		public static int tag_accessibility_actions;

		public static int tag_accessibility_clickable_spans;

		public static int tag_accessibility_heading;

		public static int tag_accessibility_pane_title;

		public static int tag_screen_reader_focusable;

		public static int tag_transition_group;

		public static int tag_unhandled_key_event_manager;

		public static int tag_unhandled_key_listeners;

		public static int text;

		public static int text2;

		public static int time;

		public static int title;

		public static int view_tree_lifecycle_owner;

		static Id()
		{
			accessibility_action_clickable_span = 2131034112;
			accessibility_custom_action_0 = 2131034113;
			accessibility_custom_action_1 = 2131034114;
			accessibility_custom_action_10 = 2131034115;
			accessibility_custom_action_11 = 2131034116;
			accessibility_custom_action_12 = 2131034117;
			accessibility_custom_action_13 = 2131034118;
			accessibility_custom_action_14 = 2131034119;
			accessibility_custom_action_15 = 2131034120;
			accessibility_custom_action_16 = 2131034121;
			accessibility_custom_action_17 = 2131034122;
			accessibility_custom_action_18 = 2131034123;
			accessibility_custom_action_19 = 2131034124;
			accessibility_custom_action_2 = 2131034125;
			accessibility_custom_action_20 = 2131034126;
			accessibility_custom_action_21 = 2131034127;
			accessibility_custom_action_22 = 2131034128;
			accessibility_custom_action_23 = 2131034129;
			accessibility_custom_action_24 = 2131034130;
			accessibility_custom_action_25 = 2131034131;
			accessibility_custom_action_26 = 2131034132;
			accessibility_custom_action_27 = 2131034133;
			accessibility_custom_action_28 = 2131034134;
			accessibility_custom_action_29 = 2131034135;
			accessibility_custom_action_3 = 2131034136;
			accessibility_custom_action_30 = 2131034137;
			accessibility_custom_action_31 = 2131034138;
			accessibility_custom_action_4 = 2131034139;
			accessibility_custom_action_5 = 2131034140;
			accessibility_custom_action_6 = 2131034141;
			accessibility_custom_action_7 = 2131034142;
			accessibility_custom_action_8 = 2131034143;
			accessibility_custom_action_9 = 2131034144;
			actions = 2131034149;
			action_container = 2131034145;
			action_divider = 2131034146;
			action_image = 2131034147;
			action_text = 2131034148;
			async = 2131034150;
			blocking = 2131034151;
			browser_actions_header_text = 2131034152;
			browser_actions_menu_items = 2131034155;
			browser_actions_menu_item_icon = 2131034153;
			browser_actions_menu_item_text = 2131034154;
			browser_actions_menu_view = 2131034156;
			chronometer = 2131034157;
			dialog_button = 2131034158;
			forever = 2131034159;
			icon = 2131034160;
			icon_group = 2131034161;
			info = 2131034162;
			italic = 2131034163;
			line1 = 2131034164;
			line3 = 2131034165;
			normal = 2131034166;
			notification_background = 2131034167;
			notification_main_column = 2131034168;
			notification_main_column_container = 2131034169;
			right_icon = 2131034170;
			right_side = 2131034171;
			tag_accessibility_actions = 2131034172;
			tag_accessibility_clickable_spans = 2131034173;
			tag_accessibility_heading = 2131034174;
			tag_accessibility_pane_title = 2131034175;
			tag_screen_reader_focusable = 2131034176;
			tag_transition_group = 2131034177;
			tag_unhandled_key_event_manager = 2131034178;
			tag_unhandled_key_listeners = 2131034179;
			text = 2131034180;
			text2 = 2131034181;
			time = 2131034182;
			title = 2131034183;
			view_tree_lifecycle_owner = 2131034184;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Integer
	{
		public static int status_bar_notification_info_maxnum;

		static Integer()
		{
			status_bar_notification_info_maxnum = 2131099648;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Layout
	{
		public static int browser_actions_context_menu_page;

		public static int browser_actions_context_menu_row;

		public static int custom_dialog;

		public static int notification_action;

		public static int notification_action_tombstone;

		public static int notification_template_custom_big;

		public static int notification_template_icon_group;

		public static int notification_template_part_chronometer;

		public static int notification_template_part_time;

		static Layout()
		{
			browser_actions_context_menu_page = 2131165184;
			browser_actions_context_menu_row = 2131165185;
			custom_dialog = 2131165186;
			notification_action = 2131165187;
			notification_action_tombstone = 2131165188;
			notification_template_custom_big = 2131165189;
			notification_template_icon_group = 2131165190;
			notification_template_part_chronometer = 2131165191;
			notification_template_part_time = 2131165192;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class String
	{
		public static int copy_toast_msg;

		public static int fallback_menu_item_copy_link;

		public static int fallback_menu_item_open_in_browser;

		public static int fallback_menu_item_share_link;

		public static int status_bar_notification_info_overflow;

		static String()
		{
			copy_toast_msg = 2131230720;
			fallback_menu_item_copy_link = 2131230721;
			fallback_menu_item_open_in_browser = 2131230722;
			fallback_menu_item_share_link = 2131230723;
			status_bar_notification_info_overflow = 2131230724;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Style
	{
		public static int TextAppearance_Compat_Notification;

		public static int TextAppearance_Compat_Notification_Info;

		public static int TextAppearance_Compat_Notification_Line2;

		public static int TextAppearance_Compat_Notification_Time;

		public static int TextAppearance_Compat_Notification_Title;

		public static int Widget_Compat_NotificationActionContainer;

		public static int Widget_Compat_NotificationActionText;

		static Style()
		{
			TextAppearance_Compat_Notification = 2131296256;
			TextAppearance_Compat_Notification_Info = 2131296257;
			TextAppearance_Compat_Notification_Line2 = 2131296258;
			TextAppearance_Compat_Notification_Time = 2131296259;
			TextAppearance_Compat_Notification_Title = 2131296260;
			Widget_Compat_NotificationActionContainer = 2131296261;
			Widget_Compat_NotificationActionText = 2131296262;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Styleable
	{
		public static int[] ColorStateListItem;

		public static int ColorStateListItem_alpha;

		public static int ColorStateListItem_android_alpha;

		public static int ColorStateListItem_android_color;

		public static int[] FontFamily;

		public static int[] FontFamilyFont;

		public static int FontFamilyFont_android_font;

		public static int FontFamilyFont_android_fontStyle;

		public static int FontFamilyFont_android_fontVariationSettings;

		public static int FontFamilyFont_android_fontWeight;

		public static int FontFamilyFont_android_ttcIndex;

		public static int FontFamilyFont_font;

		public static int FontFamilyFont_fontStyle;

		public static int FontFamilyFont_fontVariationSettings;

		public static int FontFamilyFont_fontWeight;

		public static int FontFamilyFont_ttcIndex;

		public static int FontFamily_fontProviderAuthority;

		public static int FontFamily_fontProviderCerts;

		public static int FontFamily_fontProviderFetchStrategy;

		public static int FontFamily_fontProviderFetchTimeout;

		public static int FontFamily_fontProviderPackage;

		public static int FontFamily_fontProviderQuery;

		public static int[] GradientColor;

		public static int[] GradientColorItem;

		public static int GradientColorItem_android_color;

		public static int GradientColorItem_android_offset;

		public static int GradientColor_android_centerColor;

		public static int GradientColor_android_centerX;

		public static int GradientColor_android_centerY;

		public static int GradientColor_android_endColor;

		public static int GradientColor_android_endX;

		public static int GradientColor_android_endY;

		public static int GradientColor_android_gradientRadius;

		public static int GradientColor_android_startColor;

		public static int GradientColor_android_startX;

		public static int GradientColor_android_startY;

		public static int GradientColor_android_tileMode;

		public static int GradientColor_android_type;

		static Styleable()
		{
			ColorStateListItem = new int[3] { 16843173, 16843551, 2130771968 };
			ColorStateListItem_alpha = 2;
			ColorStateListItem_android_alpha = 1;
			ColorStateListItem_android_color = 0;
			FontFamily = new int[6] { 2130771970, 2130771971, 2130771972, 2130771973, 2130771974, 2130771975 };
			FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130771969, 2130771976, 2130771977, 2130771978, 2130771979 };
			FontFamilyFont_android_font = 0;
			FontFamilyFont_android_fontStyle = 2;
			FontFamilyFont_android_fontVariationSettings = 4;
			FontFamilyFont_android_fontWeight = 1;
			FontFamilyFont_android_ttcIndex = 3;
			FontFamilyFont_font = 5;
			FontFamilyFont_fontStyle = 6;
			FontFamilyFont_fontVariationSettings = 7;
			FontFamilyFont_fontWeight = 8;
			FontFamilyFont_ttcIndex = 9;
			FontFamily_fontProviderAuthority = 0;
			FontFamily_fontProviderCerts = 1;
			FontFamily_fontProviderFetchStrategy = 2;
			FontFamily_fontProviderFetchTimeout = 3;
			FontFamily_fontProviderPackage = 4;
			FontFamily_fontProviderQuery = 5;
			GradientColor = new int[12]
			{
				16843165, 16843166, 16843169, 16843170, 16843171, 16843172, 16843265, 16843275, 16844048, 16844049,
				16844050, 16844051
			};
			GradientColorItem = new int[2] { 16843173, 16844052 };
			GradientColorItem_android_color = 0;
			GradientColorItem_android_offset = 1;
			GradientColor_android_centerColor = 7;
			GradientColor_android_centerX = 3;
			GradientColor_android_centerY = 4;
			GradientColor_android_endColor = 1;
			GradientColor_android_endX = 10;
			GradientColor_android_endY = 11;
			GradientColor_android_gradientRadius = 5;
			GradientColor_android_startColor = 0;
			GradientColor_android_startX = 8;
			GradientColor_android_startY = 9;
			GradientColor_android_tileMode = 6;
			GradientColor_android_type = 2;
			ResourceIdManager.UpdateIdValues();
		}
	}

	public class Xml
	{
		public static int image_share_filepaths;

		public static int xamarin_essentials_fileprovider_file_paths;

		static Xml()
		{
			image_share_filepaths = 2131427328;
			xamarin_essentials_fileprovider_file_paths = 2131427329;
			ResourceIdManager.UpdateIdValues();
		}
	}

	static Resource()
	{
		ResourceIdManager.UpdateIdValues();
	}
}
