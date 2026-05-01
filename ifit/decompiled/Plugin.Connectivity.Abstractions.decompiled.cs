using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v1.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Plugin.Connectivity.Abstractions")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("3.2.0")]
[assembly: AssemblyInformationalVersion("3.2.0")]
[assembly: AssemblyProduct("Plugin.Connectivity.Abstractions")]
[assembly: AssemblyTitle("Plugin.Connectivity.Abstractions")]
[assembly: AssemblyVersion("3.2.0.0")]
namespace Plugin.Connectivity.Abstractions;

public abstract class BaseConnectivity : IConnectivity, IDisposable
{
	private bool disposed;

	public abstract bool IsConnected { get; }

	public abstract IEnumerable<ConnectionType> ConnectionTypes { get; }

	public abstract IEnumerable<ulong> Bandwidths { get; }

	public event ConnectivityChangedEventHandler ConnectivityChanged;

	public event ConnectivityTypeChangedEventHandler ConnectivityTypeChanged;

	public abstract Task<bool> IsReachable(string host, int msTimeout = 5000);

	public abstract Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000);

	protected virtual void OnConnectivityChanged(ConnectivityChangedEventArgs e)
	{
		this.ConnectivityChanged?.Invoke(this, e);
	}

	protected virtual void OnConnectivityTypeChanged(ConnectivityTypeChangedEventArgs e)
	{
		this.ConnectivityTypeChanged?.Invoke(this, e);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~BaseConnectivity()
	{
		Dispose(disposing: false);
	}

	public virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			disposed = true;
		}
	}
}
public enum ConnectionType
{
	Cellular,
	WiFi,
	Desktop,
	Wimax,
	Other,
	Bluetooth
}
public interface IConnectivity : IDisposable
{
	bool IsConnected { get; }

	IEnumerable<ConnectionType> ConnectionTypes { get; }

	IEnumerable<ulong> Bandwidths { get; }

	event ConnectivityChangedEventHandler ConnectivityChanged;

	event ConnectivityTypeChangedEventHandler ConnectivityTypeChanged;

	Task<bool> IsReachable(string host, int msTimeout = 5000);

	Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000);
}
public class ConnectivityChangedEventArgs : EventArgs
{
	public bool IsConnected { get; set; }
}
public class ConnectivityTypeChangedEventArgs : EventArgs
{
	public bool IsConnected { get; set; }

	public IEnumerable<ConnectionType> ConnectionTypes { get; set; }
}
public delegate void ConnectivityChangedEventHandler(object sender, ConnectivityChangedEventArgs e);
public delegate void ConnectivityTypeChangedEventHandler(object sender, ConnectivityTypeChangedEventArgs e);
