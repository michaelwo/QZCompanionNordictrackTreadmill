using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Java.Net;
using Plugin.Connectivity.Abstractions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Plugin.Connectivity")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Plugin.Connectivity")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("3.2.0")]
[assembly: UsesPermission("android.permission.ACCESS_NETWORK_STATE")]
[assembly: UsesPermission("android.permission.ACCESS_WIFI_STATE")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("3.2.0.0")]
namespace Plugin.Connectivity;

public class CrossConnectivity
{
	private static Lazy<IConnectivity> implementation = new Lazy<IConnectivity>(() => CreateConnectivity(), LazyThreadSafetyMode.PublicationOnly);

	public static bool IsSupported
	{
		get
		{
			if (implementation.Value != null)
			{
				return true;
			}
			return false;
		}
	}

	public static IConnectivity Current => implementation.Value ?? throw NotImplementedInReferenceAssembly();

	private static IConnectivity CreateConnectivity()
	{
		return new ConnectivityImplementation();
	}

	internal static Exception NotImplementedInReferenceAssembly()
	{
		return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
	}

	public static void Dispose()
	{
		Lazy<IConnectivity> lazy = implementation;
		if (lazy != null && lazy.IsValueCreated)
		{
			implementation.Value.Dispose();
			implementation = new Lazy<IConnectivity>(() => CreateConnectivity(), LazyThreadSafetyMode.PublicationOnly);
		}
	}
}
[BroadcastReceiver(Enabled = true, Exported = false, Label = "Connectivity Plugin Broadcast Receiver")]
[Preserve(AllMembers = true)]
public class ConnectivityChangeBroadcastReceiver : BroadcastReceiver
{
	public static Action<ConnectivityChangedEventArgs> ConnectionChanged;

	public static Action<ConnectivityTypeChangedEventArgs> ConnectionTypeChanged;

	private bool isConnected;

	private ConnectivityManager connectivityManager;

	private ConnectivityManager ConnectivityManager
	{
		get
		{
			if (connectivityManager == null || connectivityManager.Handle == IntPtr.Zero)
			{
				connectivityManager = (ConnectivityManager)Application.Context.GetSystemService("connectivity");
			}
			return connectivityManager;
		}
	}

	private bool IsConnected => ConnectivityImplementation.GetIsConnected(ConnectivityManager);

	public ConnectivityChangeBroadcastReceiver()
	{
		isConnected = IsConnected;
	}

	public override async void OnReceive(Context context, Intent intent)
	{
		if (!(intent.Action != "android.net.conn.CONNECTIVITY_CHANGE"))
		{
			await Task.Delay(500);
			Action<ConnectivityChangedEventArgs> connectionChanged = ConnectionChanged;
			bool flag = IsConnected;
			if (connectionChanged != null && flag != isConnected)
			{
				isConnected = flag;
				connectionChanged(new ConnectivityChangedEventArgs
				{
					IsConnected = isConnected
				});
			}
			Action<ConnectivityTypeChangedEventArgs> connectionTypeChanged = ConnectionTypeChanged;
			if (connectionTypeChanged != null)
			{
				IEnumerable<ConnectionType> connectionTypes = ConnectivityImplementation.GetConnectionTypes(ConnectivityManager);
				connectionTypeChanged(new ConnectivityTypeChangedEventArgs
				{
					IsConnected = flag,
					ConnectionTypes = connectionTypes
				});
			}
		}
	}
}
[Preserve(AllMembers = true)]
public class ConnectivityImplementation : BaseConnectivity
{
	private ConnectivityChangeBroadcastReceiver receiver;

	private ConnectivityManager connectivityManager;

	private WifiManager wifiManager;

	private bool disposed;

	private ConnectivityManager ConnectivityManager
	{
		get
		{
			if (connectivityManager == null || connectivityManager.Handle == IntPtr.Zero)
			{
				connectivityManager = (ConnectivityManager)Application.Context.GetSystemService("connectivity");
			}
			return connectivityManager;
		}
	}

	private WifiManager WifiManager
	{
		get
		{
			if (wifiManager == null || wifiManager.Handle == IntPtr.Zero)
			{
				wifiManager = (WifiManager)Application.Context.GetSystemService("wifi");
			}
			return wifiManager;
		}
	}

	public override bool IsConnected => GetIsConnected(ConnectivityManager);

	public override IEnumerable<ConnectionType> ConnectionTypes => GetConnectionTypes(ConnectivityManager);

	public override IEnumerable<ulong> Bandwidths
	{
		get
		{
			try
			{
				if (ConnectionTypes.Contains(ConnectionType.WiFi))
				{
					return new ulong[1] { (ulong)WifiManager.ConnectionInfo.LinkSpeed * 1000000uL };
				}
			}
			catch (Exception)
			{
			}
			return new ulong[0];
		}
	}

	public ConnectivityImplementation()
	{
		ConnectivityChangeBroadcastReceiver.ConnectionChanged = OnConnectivityChanged;
		ConnectivityChangeBroadcastReceiver.ConnectionTypeChanged = OnConnectivityTypeChanged;
		receiver = new ConnectivityChangeBroadcastReceiver();
		Application.Context.RegisterReceiver(receiver, new IntentFilter("android.net.conn.CONNECTIVITY_CHANGE"));
	}

	public static bool GetIsConnected(ConnectivityManager manager)
	{
		try
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				Network[] allNetworks = manager.GetAllNetworks();
				foreach (Network network in allNetworks)
				{
					try
					{
						NetworkCapabilities networkCapabilities = manager.GetNetworkCapabilities(network);
						if (networkCapabilities != null && networkCapabilities.HasCapability(NetCapability.Internet))
						{
							NetworkInfo networkInfo = manager.GetNetworkInfo(network);
							if (networkInfo != null && networkInfo.IsAvailable && networkInfo.IsConnected)
							{
								return true;
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
				NetworkInfo[] allNetworkInfo = manager.GetAllNetworkInfo();
				foreach (NetworkInfo networkInfo2 in allNetworkInfo)
				{
					if (networkInfo2 != null && networkInfo2.IsAvailable && networkInfo2.IsConnected)
					{
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public override async Task<bool> IsReachable(string host, int msTimeout = 5000)
	{
		if (string.IsNullOrEmpty(host))
		{
			throw new ArgumentNullException("host");
		}
		if (!IsConnected)
		{
			return false;
		}
		return await Task.Run(delegate
		{
			try
			{
				return InetAddress.GetByName(host).IsReachable(msTimeout);
			}
			catch (UnknownHostException)
			{
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		});
	}

	public override async Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000)
	{
		if (string.IsNullOrEmpty(host))
		{
			throw new ArgumentNullException("host");
		}
		if (!IsConnected)
		{
			return false;
		}
		host = host.Replace("http://www.", string.Empty).Replace("http://", string.Empty).Replace("https://www.", string.Empty)
			.Replace("https://", string.Empty)
			.TrimEnd(new char[1] { '/' });
		return await Task.Run(async delegate
		{
			_ = 1;
			try
			{
				TaskCompletionSource<InetSocketAddress> tcs = new TaskCompletionSource<InetSocketAddress>();
				new Thread((ThreadStart)delegate
				{
					InetSocketAddress result = new InetSocketAddress(host, port);
					if (!tcs.Task.IsCompleted)
					{
						tcs.TrySetResult(result);
					}
				}).Start();
				Task.Run(async delegate
				{
					await Task.Delay(msTimeout);
					if (!tcs.Task.IsCompleted)
					{
						tcs.TrySetResult(null);
					}
				});
				InetSocketAddress inetSocketAddress = await tcs.Task;
				if (inetSocketAddress == null)
				{
					return false;
				}
				using Socket sock = new Socket();
				await sock.ConnectAsync(inetSocketAddress, msTimeout);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		});
	}

	public static IEnumerable<ConnectionType> GetConnectionTypes(ConnectivityManager manager)
	{
		if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
		{
			Network[] allNetworks = manager.GetAllNetworks();
			foreach (Network network in allNetworks)
			{
				NetworkInfo networkInfo = null;
				try
				{
					networkInfo = manager.GetNetworkInfo(network);
				}
				catch
				{
				}
				if (networkInfo != null && networkInfo.IsAvailable)
				{
					yield return GetConnectionType(networkInfo.Type, networkInfo.TypeName);
				}
			}
			yield break;
		}
		NetworkInfo[] allNetworkInfo = manager.GetAllNetworkInfo();
		foreach (NetworkInfo networkInfo2 in allNetworkInfo)
		{
			if (networkInfo2 != null && networkInfo2.IsAvailable)
			{
				yield return GetConnectionType(networkInfo2.Type, networkInfo2.TypeName);
			}
		}
	}

	public static ConnectionType GetConnectionType(ConnectivityType connectivityType, string typeName)
	{
		switch (connectivityType)
		{
		case ConnectivityType.Ethernet:
			return ConnectionType.Desktop;
		case ConnectivityType.Wimax:
			return ConnectionType.Wimax;
		case ConnectivityType.Wifi:
			return ConnectionType.WiFi;
		case ConnectivityType.Bluetooth:
			return ConnectionType.Bluetooth;
		case ConnectivityType.Mobile:
		case ConnectivityType.MobileMms:
		case ConnectivityType.MobileDun:
		case ConnectivityType.MobileHipri:
			return ConnectionType.Cellular;
		case ConnectivityType.Dummy:
			return ConnectionType.Other;
		default:
		{
			if (string.IsNullOrWhiteSpace(typeName))
			{
				return ConnectionType.Other;
			}
			string text = typeName.ToLowerInvariant();
			if (text.Contains("mobile"))
			{
				return ConnectionType.Cellular;
			}
			if (text.Contains("wifi"))
			{
				return ConnectionType.WiFi;
			}
			if (text.Contains("wimax"))
			{
				return ConnectionType.Wimax;
			}
			if (text.Contains("ethernet"))
			{
				return ConnectionType.Desktop;
			}
			if (text.Contains("bluetooth"))
			{
				return ConnectionType.Bluetooth;
			}
			return ConnectionType.Other;
		}
		}
	}

	public override void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				if (receiver != null)
				{
					Application.Context.UnregisterReceiver(receiver);
				}
				ConnectivityChangeBroadcastReceiver.ConnectionChanged = null;
				if (wifiManager != null)
				{
					wifiManager.Dispose();
					wifiManager = null;
				}
				if (connectivityManager != null)
				{
					connectivityManager.Dispose();
					connectivityManager = null;
				}
			}
			disposed = true;
		}
		base.Dispose(disposing);
	}
}
