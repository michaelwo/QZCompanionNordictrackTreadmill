using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Acr;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Util;
using Android.Views;
using Java.IO;
using Java.Lang;
using Java.Util;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v8.0", FrameworkDisplayName = "Xamarin.Android v8.0 Support")]
[assembly: AssemblyCompany("aritchie")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("\r\nACR Device Info Plugin Information Plugin for Xamarin and Windows\r\n\r\nSupported Platforms\r\n* .NET Standard\r\n* Android\r\n* iOS\r\n* macOS\r\n* UWP\r\n        ")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("ACR Device Info Plugin (MonoAndroid80)")]
[assembly: AssemblyTitle("Plugin.DeviceInfo")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Plugin.DeviceInfo;

public abstract class AbstractApp : IApp
{
	public abstract string BundleName { get; }

	public abstract string Version { get; }

	public abstract string ShortVersion { get; }

	public virtual CultureInfo CurrentCulture => CultureInfo.CurrentCulture;

	public virtual bool IsBackgrounded => false;

	public virtual bool IsIdleTimerEnabled => true;

	public virtual IObservable<CultureInfo> WhenCultureChanged()
	{
		return Observable.Return(CultureInfo.CurrentCulture);
	}

	public virtual IObservable<AppState> WhenStateChanged()
	{
		return Observable.Empty<AppState>();
	}

	public virtual IObservable<Unit> EnableIdleTimer(bool enabled)
	{
		return Observable.Empty<Unit>();
	}
}
public abstract class AbstractNetwork : INetwork
{
	public virtual NetworkType InternetNetworkType => NetworkType.Unknown;

	public virtual string CellularNetworkCarrier => null;

	public virtual string IpAddress => null;

	public virtual string WifiSsid => null;

	public virtual IObservable<NetworkType> WhenNetworkTypeChanged()
	{
		return Observable.Empty<NetworkType>();
	}
}
public abstract class AbstractPowerState : IPowerState
{
	public virtual IObservable<int> WhenBatteryPercentageChanged()
	{
		return Observable.Empty<int>();
	}

	public virtual IObservable<PowerStatus> WhenPowerStatusChanged()
	{
		return Observable.Return(PowerStatus.Unknown);
	}
}
public enum AppState
{
	Foreground,
	Background
}
public static class CrossDevice
{
	private const string ERROR = "[Plugin.DeviceInfo] Platform implementation not found.  Have you added a nuget reference to your platform project?";

	private static IApp app;

	private static IPowerState powerState;

	private static INetwork network;

	private static IDevice device;

	public static IApp App
	{
		get
		{
			if (app == null)
			{
				throw new System.Exception("[Plugin.DeviceInfo] Platform implementation not found.  Have you added a nuget reference to your platform project?");
			}
			return app;
		}
		set
		{
			app = value;
		}
	}

	public static IPowerState PowerState
	{
		get
		{
			if (powerState == null)
			{
				throw new System.Exception("[Plugin.DeviceInfo] Platform implementation not found.  Have you added a nuget reference to your platform project?");
			}
			return powerState;
		}
		set
		{
			powerState = value;
		}
	}

	public static INetwork Network
	{
		get
		{
			if (network == null)
			{
				throw new System.Exception("[Plugin.DeviceInfo] Platform implementation not found.  Have you added a nuget reference to your platform project?");
			}
			return network;
		}
		set
		{
			network = value;
		}
	}

	public static IDevice Device
	{
		get
		{
			if (device == null)
			{
				throw new System.Exception("[Plugin.DeviceInfo] Platform implementation not found.  Have you added a nuget reference to your platform project?");
			}
			return device;
		}
		set
		{
			device = value;
		}
	}

	static CrossDevice()
	{
		App = new AppImpl();
		Device = new DeviceImpl();
		Network = new NetworkImpl();
		PowerState = new PowerStateImpl();
	}
}
public static class Extensions
{
	public static bool IsConnected(this INetwork network)
	{
		return network.InternetNetworkType != NetworkType.NotReachable;
	}

	public static IObservable<Unit> WhenEnteringForeground(this IApp app)
	{
		return from _ in app.WhenStateChanged()
			where _ == AppState.Foreground
			select Unit.Default;
	}

	public static IObservable<Unit> WhenEnteringBackground(this IApp app)
	{
		return from _ in app.WhenStateChanged()
			where _ == AppState.Background
			select Unit.Default;
	}

	public static IObservable<Unit> WhenConnected(this INetwork network)
	{
		return from _ in network.WhenNetworkTypeChanged()
			where _ != NetworkType.NotReachable
			select Unit.Default;
	}

	public static IObservable<Unit> WhenDisconnected(this INetwork network)
	{
		return from _ in network.WhenNetworkTypeChanged()
			where _ == NetworkType.NotReachable
			select Unit.Default;
	}

	public static Task<int> ReadPercentage(this IPowerState power)
	{
		return power.WhenBatteryPercentageChanged().Take(1).ToTask();
	}

	public static Task<PowerStatus> ReadPowerStatus(this IPowerState power)
	{
		return power.WhenPowerStatusChanged().Take(1).ToTask();
	}
}
public interface IApp
{
	string BundleName { get; }

	string Version { get; }

	string ShortVersion { get; }

	CultureInfo CurrentCulture { get; }

	bool IsBackgrounded { get; }

	bool IsIdleTimerEnabled { get; }

	IObservable<CultureInfo> WhenCultureChanged();

	IObservable<AppState> WhenStateChanged();

	IObservable<Unit> EnableIdleTimer(bool enabled);
}
public interface IDevice
{
	bool IsJailBreakDetected { get; }

	int ScreenHeight { get; }

	int ScreenWidth { get; }

	string DeviceId { get; }

	string Manufacturer { get; }

	string Model { get; }

	string OperatingSystem { get; }

	string OperatingSystemVersion { get; }

	bool IsSimulator { get; }

	bool IsTablet { get; }
}
public interface INetwork
{
	NetworkType InternetNetworkType { get; }

	string CellularNetworkCarrier { get; }

	string IpAddress { get; }

	string WifiSsid { get; }

	IObservable<NetworkType> WhenNetworkTypeChanged();
}
public interface IPowerState
{
	IObservable<int> WhenBatteryPercentageChanged();

	IObservable<PowerStatus> WhenPowerStatusChanged();
}
public enum NetworkType
{
	Unknown,
	NotReachable,
	Cellular,
	Wifi,
	Other
}
public enum PowerStatus
{
	Unknown,
	Charging,
	Charged,
	NoBattery,
	Discharging
}
public class AppImpl : IApp
{
	private readonly AppStateLifecyle appState;

	private PowerManager.WakeLock wakeLock;

	public CultureInfo CurrentCulture => GetCurrentCulture();

	public bool IsIdleTimerEnabled => wakeLock != null;

	public string BundleName => GetPackage().PackageName;

	public string Version => GetPackage().VersionName;

	public string ShortVersion => GetPackage().VersionCode.ToString();

	public bool IsBackgrounded => !appState.IsActive;

	public AppImpl()
	{
		appState = new AppStateLifecyle();
		Application obj = (Application.Context.ApplicationContext as Application) ?? throw new ApplicationException("Invalid application context");
		obj.RegisterActivityLifecycleCallbacks(appState);
		obj.RegisterComponentCallbacks(appState);
	}

	public IObservable<CultureInfo> WhenCultureChanged()
	{
		return from x in AndroidObservables.WhenIntentReceived("android.intent.action.LOCALE_CHANGED")
			select GetCurrentCulture();
	}

	public IObservable<AppState> WhenStateChanged()
	{
		return Observable.Create(delegate(IObserver<AppState> ob)
		{
			EventHandler handler = delegate
			{
				AppState value = ((!appState.IsActive) ? AppState.Background : AppState.Foreground);
				ob.OnNext(value);
			};
			AppStateLifecyle appStateLifecyle = appState;
			appStateLifecyle.StatusChanged = (EventHandler)Delegate.Combine(appStateLifecyle.StatusChanged, handler);
			return delegate
			{
				AppStateLifecyle appStateLifecyle2 = appState;
				appStateLifecyle2.StatusChanged = (EventHandler)Delegate.Remove(appStateLifecyle2.StatusChanged, handler);
			};
		});
	}

	public IObservable<Unit> EnableIdleTimer(bool enabled)
	{
		PowerManager powerManager = (PowerManager)Application.Context.GetSystemService("power");
		if (enabled)
		{
			if (wakeLock == null)
			{
				wakeLock = powerManager.NewWakeLock(WakeLockFlags.LocationModeGpsDisabledWhenScreenOff, GetType().FullName);
				wakeLock.Acquire();
			}
		}
		else
		{
			wakeLock?.Release();
			wakeLock = null;
		}
		return Observable.Return(Unit.Default);
	}

	private static PackageInfo GetPackage()
	{
		return Application.Context.ApplicationContext.PackageManager.GetPackageInfo(Application.Context.PackageName, (PackageInfoFlags)0);
	}

	protected virtual CultureInfo GetCurrentCulture()
	{
		return new CultureInfo(Locale.Default.ToString().Replace("_", "-"));
	}
}
public class AppStateLifecyle : Java.Lang.Object, Application.IActivityLifecycleCallbacks, IJavaObject, IDisposable, IComponentCallbacks2, IComponentCallbacks
{
	public EventHandler StatusChanged;

	public bool IsActive { get; private set; } = true;

	public void OnActivityResumed(Activity activity)
	{
		if (!IsActive)
		{
			IsActive = true;
			StatusChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public void OnTrimMemory([GeneratedEnum] TrimMemory level)
	{
		if (level == TrimMemory.UiHidden)
		{
			IsActive = false;
			StatusChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
	{
	}

	public void OnActivityDestroyed(Activity activity)
	{
	}

	public void OnActivityPaused(Activity activity)
	{
	}

	public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
	{
	}

	public void OnActivityStarted(Activity activity)
	{
	}

	public void OnActivityStopped(Activity activity)
	{
	}

	public void OnConfigurationChanged(Configuration newConfig)
	{
	}

	public void OnLowMemory()
	{
	}
}
public class DeviceImpl : IDevice
{
	private bool? jailbreak;

	private static readonly string[] checks = new string[10] { "/system/app/Superuser.apk", "/sbin/su", "/system/bin/su", "/system/xbin/su", "/data/local/xbin/su", "/data/local/bin/su", "/system/sd/xbin/su", "/system/bin/failsafe/su", "/data/local/su", "/su/bin/su" };

	public bool IsJailBreakDetected
	{
		get
		{
			jailbreak = jailbreak ?? IsJailBroken();
			return jailbreak.Value;
		}
	}

	public int ScreenHeight { get; }

	public int ScreenWidth { get; }

	public string DeviceId => Settings.Secure.GetString(Application.Context.ApplicationContext.ContentResolver, "android_id");

	public string Manufacturer { get; } = Build.Manufacturer;

	public string Model { get; } = Build.Model;

	public string OperatingSystem { get; } = Build.VERSION.Release;

	public string OperatingSystemVersion { get; } = Build.VERSION.SdkInt.ToString();

	public bool IsSimulator { get; } = Build.Product.Equals("google_sdk", StringComparison.InvariantCultureIgnoreCase) || Build.Model.Contains("Emulator") || Build.Model.Contains("Android SDK built for x86");

	public bool IsTablet => ((TelephonyManager)Application.Context.ApplicationContext.GetSystemService("phone")).PhoneType == PhoneType.None;

	public DeviceImpl()
	{
		IWindowManager windowManager = Application.Context.GetSystemService("window").JavaCast<IWindowManager>();
		if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
		{
			Point point = new Point();
			try
			{
				windowManager.DefaultDisplay.GetRealSize(point);
				ScreenHeight = point.Y;
				ScreenWidth = point.X;
				return;
			}
			catch (NoSuchMethodError)
			{
				ScreenHeight = windowManager.DefaultDisplay.Height;
				ScreenWidth = windowManager.DefaultDisplay.Width;
				return;
			}
		}
		DisplayMetrics displayMetrics = new DisplayMetrics();
		windowManager.DefaultDisplay.GetMetrics(displayMetrics);
		ScreenHeight = displayMetrics.HeightPixels;
		ScreenWidth = displayMetrics.WidthPixels;
	}

	protected virtual bool IsJailBroken()
	{
		if (checks.Any(System.IO.File.Exists))
		{
			return true;
		}
		string tags = Build.Tags;
		if (tags != null && tags.Contains("test-keys"))
		{
			return true;
		}
		if (CheckJailBreakProcess())
		{
			return true;
		}
		return false;
	}

	protected virtual bool CheckJailBreakProcess()
	{
		try
		{
			using (Java.Lang.Process process = Runtime.GetRuntime().Exec("/system/xbin/which", new string[1] { "su" }))
			{
				using BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(process.InputStream));
				if (bufferedReader.ReadLine() != null)
				{
					return true;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
public class NetworkImpl : INetwork
{
	private WifiManager wifiMgr;

	private TelephonyManager telMgr;

	private ConnectivityManager connectivityMgr;

	public NetworkType InternetNetworkType
	{
		get
		{
			NetworkInfo activeNetworkInfo = Connectivity.ActiveNetworkInfo;
			if (activeNetworkInfo == null || !activeNetworkInfo.IsConnected)
			{
				return NetworkType.NotReachable;
			}
			switch (activeNetworkInfo.Type)
			{
			case ConnectivityType.Wifi:
			case ConnectivityType.Wimax:
				return NetworkType.Wifi;
			case ConnectivityType.Mobile:
				return NetworkType.Cellular;
			default:
				return NetworkType.Other;
			}
		}
	}

	public string CellularNetworkCarrier => Tel.NetworkOperatorName;

	public string IpAddress => Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault((IPAddress x) => x.AddressFamily == AddressFamily.InterNetwork || x.AddressFamily == AddressFamily.InterNetworkV6)?.ToString();

	public string WifiSsid => Wifi.ConnectionInfo?.SSID;

	private WifiManager Wifi
	{
		get
		{
			if (wifiMgr == null || wifiMgr.Handle == IntPtr.Zero)
			{
				wifiMgr = (WifiManager)Application.Context.GetSystemService("wifi");
			}
			return wifiMgr;
		}
	}

	private TelephonyManager Tel
	{
		get
		{
			if (telMgr == null || telMgr.Handle == IntPtr.Zero)
			{
				telMgr = (TelephonyManager)Application.Context.ApplicationContext.GetSystemService("phone");
			}
			return telMgr;
		}
	}

	private ConnectivityManager Connectivity
	{
		get
		{
			if (connectivityMgr == null || connectivityMgr.Handle == IntPtr.Zero)
			{
				connectivityMgr = (ConnectivityManager)Application.Context.GetSystemService("connectivity");
			}
			return connectivityMgr;
		}
	}

	public IObservable<NetworkType> WhenNetworkTypeChanged()
	{
		return from intent in AndroidObservables.WhenIntentReceived("android.net.conn.CONNECTIVITY_CHANGE")
			select InternetNetworkType;
	}
}
public class PowerStateImpl : IPowerState
{
	public IObservable<int> WhenBatteryPercentageChanged()
	{
		return AndroidObservables.WhenIntentReceived("android.intent.action.BATTERY_CHANGED").Select(delegate(Intent intent)
		{
			int intExtra = intent.GetIntExtra("level", -1);
			int intExtra2 = intent.GetIntExtra("scale", -1);
			return (int)System.Math.Floor((double)intExtra * 100.0 / (double)intExtra2);
		});
	}

	public IObservable<PowerStatus> WhenPowerStatusChanged()
	{
		return AndroidObservables.WhenIntentReceived("android.intent.action.BATTERY_CHANGED").Select(delegate(Intent intent)
		{
			switch ((BatteryStatus)intent.GetIntExtra("status", -1))
			{
			case BatteryStatus.Discharging:
			case BatteryStatus.NotCharging:
				return PowerStatus.Discharging;
			case BatteryStatus.Charging:
				return PowerStatus.Charging;
			case BatteryStatus.Full:
				return PowerStatus.Charged;
			default:
				return PowerStatus.Unknown;
			}
		});
	}
}
