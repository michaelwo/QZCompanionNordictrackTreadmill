using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware.Usb;
using Android.Runtime;
using Sindarin.Core;
using Sindarin.Core.Connection;
using Sindarin.Core.Services.Fatality;
using Sindarin.Core.Usb;
using Sindarin.Core.Util;
using Sindarin.Usb.Android.Permissions;
using Sindarin.Usb.Android.Util;
using iFit.Extensions.Android;
using iFit.Logger;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace Sindarin.Usb.Android
{
	public abstract class BaseAndroidUsbDevice : IUsbDevice, IDisposable
	{
		private const int MaxReconnectAttempts = 20;

		private readonly Subject<bool> _whenConnectionStateChanged = new Subject<bool>();

		private readonly Context context = Application.Context;

		private readonly SemaphoreSlim claimDeviceLock = new SemaphoreSlim(1, 1);

		private readonly Dictionary<int, int> connectionAttemptsPerDevice = new Dictionary<int, int>();

		private readonly RxBroadcastReceiver broadcastReceiver;

		private readonly IDisposable usbDeviceSub;

		private int obtainAttempts;

		private int lastDeviceId;

		private bool isUsbInterfaceDisposed;

		private bool isHeadlessBikeVault;

		private readonly IFatalityService fatalityService;

		private readonly IUsbPermissionService usbPermissionService;

		private readonly TimeSpan usbReconnectTimeout = TimeSpan.FromSeconds(5.0);

		private CancellationTokenSource cancellationTokenSource;

		protected abstract IReadOnlyList<int> ValidProductIds { get; }

		protected abstract int VendorId { get; }

		public UsbProduct ProductId { get; private set; }

		public IObservable<bool> WhenConnectionStateChanged => _whenConnectionStateChanged.AsObservable();

		public bool IsConnected { get; private set; }

		public UsbInterface UsbInterface { get; private set; }

		public UsbDeviceConnection UsbConnection { get; private set; }

		public BaseAndroidUsbDevice(IUsbPermissionService usbPermissionService, IFatalityService fatalityService)
		{
			this.usbPermissionService = usbPermissionService;
			this.fatalityService = fatalityService;
			broadcastReceiver?.Dispose();
			broadcastReceiver = new RxBroadcastReceiver(usbPermissionService.CreateUsbGrantedIntentFilter(), new IntentFilter("android.hardware.usb.action.USB_DEVICE_ATTACHED"), new IntentFilter("android.hardware.usb.action.USB_DEVICE_DETACHED"));
			broadcastReceiver.StartListening(context);
			usbDeviceSub?.Dispose();
			usbDeviceSub = broadcastReceiver.WhenBroadcastReceived.Subscribe(OnReceive);
		}

		public async Task Connect()
		{
			Log("Connecting to device");
			IsConnected = false;
			UsbDevice device = usbPermissionService.GetDevice(VendorId, ValidProductIds);
			if (device == null && (!isHeadlessBikeVault || obtainAttempts < 10))
			{
				Log($"USB device null on connection attempt {++obtainAttempts}");
				await Task.Delay(TimeSpan.FromSeconds(1.0));
				await Connect();
			}
			else if (device != null)
			{
				obtainAttempts = 0;
				if (!usbPermissionService.HasPermission(device))
				{
					Log("Requesting USB Permissions");
					usbPermissionService.RequestPermission(device);
				}
				else
				{
					Log("USB permissions set");
					await SafelyClaimDevice(device);
				}
			}
		}

		public void Connect(bool headlessBike)
		{
			isHeadlessBikeVault = headlessBike;
			Connect();
		}

		public void Disconnect()
		{
			try
			{
				IsConnected = false;
				_whenConnectionStateChanged.OnNext(value: false);
				if (!isUsbInterfaceDisposed)
				{
					UsbConnection?.ReleaseInterface(UsbInterface);
				}
				UsbConnection?.Close();
				if (!isUsbInterfaceDisposed)
				{
					UsbInterface?.Dispose();
				}
				isUsbInterfaceDisposed = true;
			}
			catch (Exception arg)
			{
				Log($"Exception thrown when trying to Disconnect in {GetType()}: {arg}");
			}
		}

		public void Dispose()
		{
			broadcastReceiver?.Dispose();
			usbDeviceSub?.Dispose();
			UsbInterface?.Dispose();
			UsbConnection?.Dispose();
		}

		private async Task SafelyClaimDevice(UsbDevice device)
		{
			await claimDeviceLock.WaitAsync();
			while (CanAttemptClaim(device))
			{
				if (ClaimUsbConnection(device))
				{
					RecoverIfNeeded();
					break;
				}
				await Task.Delay(TimeSpan.FromMilliseconds(500.0));
			}
			claimDeviceLock.Release();
		}

		private bool ClaimUsbConnection(UsbDevice device)
		{
			try
			{
				int valueOrDefault = connectionAttemptsPerDevice.GetValueOrDefault(device.DeviceId);
				Log($"Claiming USB connection to device: {device.DeviceName} after {valueOrDefault} attempts");
				connectionAttemptsPerDevice[device.DeviceId] = valueOrDefault + 1;
				UsbInterface usbInterface = device.GetInterface(0);
				UsbDeviceConnection usbDeviceConnection = usbPermissionService.OpenDevice(device);
				if (usbDeviceConnection != null && usbDeviceConnection.ClaimInterface(usbInterface, force: true))
				{
					Log($"Successfully connected to a USB device {device.DeviceId}");
					UsbConnection = usbDeviceConnection;
					UsbInterface = usbInterface;
					isUsbInterfaceDisposed = false;
					lastDeviceId = device.DeviceId;
					ProductId = (UsbProduct)device.ProductId;
					IsConnected = true;
					_whenConnectionStateChanged.OnNext(value: true);
					return true;
				}
			}
			catch (Exception arg)
			{
				Log($"An error occurred connecting to {device?.DeviceName}: {arg}");
			}
			return false;
		}

		private bool CanAttemptClaim(UsbDevice device)
		{
			if (device == null || device.DeviceName == null)
			{
				Log("Not connecting to device since it doesn't have a name");
				return false;
			}
			if (device.VendorId != VendorId)
			{
				Log("Not connecting to device since it is an invalid vendorId");
				return false;
			}
			if (device.DeviceId < lastDeviceId)
			{
				Log($"Not connecting to {device.DeviceId} since it is an older connection than {lastDeviceId}");
				return false;
			}
			if (connectionAttemptsPerDevice.GetValueOrDefault(device.DeviceId) > 20)
			{
				Log($"Not connecting to {device.DeviceName} since connection attempts exceed {20}");
				return false;
			}
			if (device.InterfaceCount <= 0)
			{
				Log($"Not connecting to {device.DeviceName} since it only has {device.InterfaceCount} interfaces");
				return false;
			}
			return true;
		}

		private void OnReceive(Intent intent)
		{
			string action = intent.Action;
			Log("Received broadcast with action: " + action);
			if (usbPermissionService.PermissionWasGranted(action))
			{
				HandleUsbPermissions(intent);
			}
			else if (action == "android.hardware.usb.action.USB_DEVICE_DETACHED")
			{
				HandleUsbDeviceDetached(intent);
			}
			else if (action == "android.hardware.usb.action.USB_DEVICE_ATTACHED")
			{
				HandleUsbDeviceAttached(intent);
			}
		}

		private void HandleUsbPermissions(Intent intent)
		{
			if (IsConnected)
			{
				return;
			}
			if (intent.HasExtra("device"))
			{
				UsbDevice device = (UsbDevice)intent.GetParcelableExtra("device");
				Log("USB permission received with device " + device?.DeviceName);
				Task.Run(() => SafelyClaimDevice(device));
				PermissionGranted();
			}
			else
			{
				Log("Re-requesting permissions");
				Task.Run((Func<Task>)Connect);
			}
		}

		private void HandleUsbDeviceDetached(Intent intent)
		{
			if (intent.HasExtra("device") && ((UsbDevice)intent.GetParcelableExtra("device"))?.VendorId != VendorId)
			{
				Log($"Device detached is not from our vendor ({VendorId})");
				return;
			}
			Log("Device detached");
			Disconnect();
			Task.Run((Func<Task>)HandleFatalEvent);
		}

		private void HandleUsbDeviceAttached(Intent intent)
		{
			if (((UsbDevice)intent.GetParcelableExtra("device"))?.VendorId != VendorId)
			{
				Log($"Device attached is not from our vendor ({VendorId})");
				return;
			}
			Log("Device attached");
			cancellationTokenSource?.Cancel();
			Task.Run((Func<Task>)Connect);
		}

		protected virtual void Log(string message)
		{
			iFit.Logger.Log.Trace("Usb", message);
		}

		private async Task HandleFatalEvent()
		{
			try
			{
				cancellationTokenSource = new CancellationTokenSource();
				await Task.Delay(usbReconnectTimeout, cancellationTokenSource.Token);
				if (!isHeadlessBikeVault)
				{
					fatalityService?.ReportFatalEvent(new UsbConnectionException());
				}
				else
				{
					iFit.Logger.Log.Trace("Usb", "Headless Bike USB disconnected, not sending fatal report.");
				}
			}
			catch (TaskCanceledException) when (cancellationTokenSource?.IsCancellationRequested ?? false)
			{
				Log("Usb re-attached before reporting fatal report");
			}
			finally
			{
				cancellationTokenSource?.Dispose();
				cancellationTokenSource = null;
			}
		}

		protected virtual void RecoverIfNeeded()
		{
			fatalityService?.RecoverIfNeeded(typeof(UsbConnectionException), "Reconnected to USB device");
		}

		protected virtual void PermissionGranted()
		{
		}
	}
	public class UsbConsoleConnection : RetryingConnection, IClearBuffer
	{
		private const string Tag = "Usb";

		private const int TimeoutMilliseconds = 50;

		private const int MaxReadRetries = 5;

		private const int MaxClearBufferTries = 10;

		private UsbEndpoint writeEndpoint;

		private UsbEndpoint readEndpoint;

		private UsbRequest writeRequest;

		private UsbRequest readRequest;

		private readonly IDisposable connectedSub;

		private readonly ISindarinEventHandler sindarinEventHandler;

		private bool IsConnected
		{
			get
			{
				if (Device?.UsbConnection != null && Device.IsConnected && writeEndpoint != null)
				{
					return readEndpoint != null;
				}
				return false;
			}
		}

		public BaseAndroidUsbDevice Device { get; }

		public override TimeSpan Timeout { get; } = TimeSpan.FromMilliseconds(50.0);

		protected override bool ShouldCheckQueue => Device.IsConnected;

		public UsbConsoleConnection(BaseAndroidUsbDevice device, ISindarinEventHandler sindarinEventHandler)
			: base("Usb")
		{
			Device = device;
			this.sindarinEventHandler = sindarinEventHandler;
			connectedSub = Device.WhenConnectionStateChanged.Subscribe(delegate(bool wasConnected)
			{
				if (wasConnected)
				{
					Connected();
				}
				else
				{
					Disconnected();
				}
			});
			if (Device.IsConnected)
			{
				Connected();
			}
			else
			{
				Task.Run((Func<Task>)Device.Connect);
			}
		}

		public override void Dispose()
		{
			Disconnected();
			connectedSub?.Dispose();
		}

		private void Connected()
		{
			if (writeEndpoint == null)
			{
				writeEndpoint = Device.UsbInterface.GetEndpoint(1);
				readEndpoint = Device.UsbInterface.GetEndpoint(0);
				writeRequest = new UsbRequest();
				writeRequest.Initialize(Device.UsbConnection, writeEndpoint);
				readRequest = new UsbRequest();
				readRequest.Initialize(Device.UsbConnection, readEndpoint);
			}
			Log.Trace("Usb", "UsbConsoleConnection connected");
			base.Initialized = true;
			whenConnectionStateChanged.OnNext(value: true);
			CheckQueue(0);
		}

		private void Disconnected()
		{
			base.Initialized = false;
			whenConnectionStateChanged.OnNext(value: false);
			writeEndpoint?.Dispose();
			writeEndpoint = null;
			writeRequest?.Dispose();
			writeRequest = null;
			readEndpoint?.Dispose();
			readEndpoint = null;
			readRequest?.Dispose();
			readRequest = null;
		}

		public async Task ClearBuffer()
		{
			if (!IsConnected)
			{
				return;
			}
			byte[] emptyBuffer = Enumerable.Range(0, 64).Select((Func<int, byte>)((int _) => 255)).ToArray();
			byte?[] array = ((IEnumerable<byte>)emptyBuffer).Select((Func<byte, byte?>)((byte b) => b)).ToArray();
			array[3] = null;
			byte?[] expectedResponse = array;
			int readAttempts = 0;
			int writeAttempts = 0;
			int consecutiveBuffers = 0;
			int successfulAttempts = 0;
			while (consecutiveBuffers < 2 && readAttempts < 10 && writeAttempts < 10)
			{
				if (!IsConnected)
				{
					return;
				}
				byte[] replyData = new byte[64];
				Log.Trace("Usb", "Sending full buffer of 0xFFs");
				if (await DoBulkWriteAsync(emptyBuffer) > 0)
				{
					Log.Trace("Usb", "0xFFs sent successfully, now trying to read...");
					await DoBulkReadAsync(replyData);
					if (replyData.WildcardSequenceEquals(expectedResponse))
					{
						Log.Trace("Usb", "Read the reply and the sequence was equal to the expected response. Incrementing consecutiveBuffers.");
						consecutiveBuffers++;
						successfulAttempts++;
					}
					else
					{
						consecutiveBuffers = 0;
						readAttempts++;
						Log.Trace("Usb", "Read the reply and the sequence was not equal to the expected response.");
					}
				}
				else
				{
					Log.Trace("Usb", "Failed to write 0xFFs... retrying");
					writeAttempts++;
				}
				await Task.Delay(TimeSpan.FromMilliseconds(500.0));
			}
			if (consecutiveBuffers < 2)
			{
				await sindarinEventHandler.LogSindarinEvent(SindarinEvent.ClearBufferFailed, new Dictionary<string, object> { { "successfulAttempts", successfulAttempts } });
			}
		}

		public override Task<bool> Disconnect()
		{
			Disconnected();
			Device?.Disconnect();
			return Task.FromResult(result: true);
		}

		protected override Task<int> DoBulkWriteAsync(byte[] buffer)
		{
			return DoBulkTransferWrite(writeEndpoint, buffer);
		}

		protected override Task<int> DoBulkReadAsync(byte[] buffer)
		{
			return DoBulkTransferRead(readEndpoint, buffer);
		}

		private async Task<int> DoBulkTransferWrite(UsbEndpoint endpoint, byte[] buffer)
		{
			return await Device.UsbConnection.BulkTransferAsync(endpoint, buffer, buffer.Length, 50);
		}

		private async Task<int> DoBulkTransferRead(UsbEndpoint endpoint, byte[] buffer)
		{
			int result = -1;
			bool flag = false;
			int counter = 0;
			while (counter++ < 5 && !flag)
			{
				result = await Device.UsbConnection.BulkTransferAsync(endpoint, buffer, buffer.Length, 50);
				flag = buffer[0] != 255;
				if (!flag)
				{
					Log.Trace("Usb", $"Read invalid bytes using bulk transfer, retrying.  Count: {counter} | " + "bytes read: " + BitConverter.ToString(buffer));
				}
			}
			return result;
		}
	}
	public class UsbFailedReadException : Exception
	{
		public UsbFailedReadException()
			: base("Failed to read Usb device")
		{
		}
	}
	public class UsbConnectionException : Exception
	{
		public UsbConnectionException()
			: base("Usb connection lost")
		{
		}
	}
	public enum UsbProduct
	{
		Unknown = 0,
		FitPro1 = 2,
		FitPro2 = 3
	}
}
namespace Sindarin.Usb.Android.Util
{
	public class RxBroadcastReceiver : BroadcastReceiver
	{
		private readonly IntentFilter[] filters;

		private readonly Subject<Intent> _whenBroadcastReceived = new Subject<Intent>();

		private readonly HashSet<Context> contexts = new HashSet<Context>();

		public IObservable<Intent> WhenBroadcastReceived => _whenBroadcastReceived.AsObservable();

		public RxBroadcastReceiver(params IntentFilter[] filters)
		{
			this.filters = filters;
		}

		public void StartListening(Context context)
		{
			contexts.Add(context);
			IntentFilter[] array = filters;
			foreach (IntentFilter filter in array)
			{
				context.RegisterReceiver(this, filter);
			}
		}

		public void StopListening(Context context)
		{
			contexts.Remove(context);
			context.SafelyUnregisterReceiver(this);
		}

		public override void OnReceive(Context context, Intent intent)
		{
			_whenBroadcastReceived.OnNext(intent);
		}

		protected override void Dispose(bool disposing)
		{
			foreach (Context context in contexts)
			{
				context?.SafelyUnregisterReceiver(this);
			}
			contexts?.Clear();
			base.Dispose(disposing);
		}
	}
}
namespace Sindarin.Usb.Android.Permissions
{
	public class EruUsbPermissionService : BaseUsbPermissionService
	{
		private const string ActionUsbRequest = "com.ifit.eru.USB_PERMISSION_REQUEST";

		private const string ActionUsbGranted = "com.ifit.eru.USB_PERMISSION_GRANTED";

		public override IntentFilter CreateUsbGrantedIntentFilter()
		{
			return new IntentFilter("com.ifit.eru.USB_PERMISSION_GRANTED");
		}

		public override bool PermissionWasGranted(string intentAction)
		{
			return intentAction == "com.ifit.eru.USB_PERMISSION_GRANTED";
		}

		public override void RequestPermission(UsbDevice device)
		{
			Intent intent = new Intent("com.ifit.eru.USB_PERMISSION_REQUEST");
			intent.PutExtra("device", device);
			context.SendBroadcast(intent);
		}

		public static bool IsSupported()
		{
			try
			{
				PackageInfo packageInfo = Application.Context.PackageManager.GetPackageInfo("com.ifit.eru", (PackageInfoFlags)0);
				if (packageInfo == null)
				{
					return false;
				}
				return Version.Parse("2.0.1") <= Version.Parse(packageInfo.VersionName);
			}
			catch (Exception arg)
			{
				Log.Error("EruUsbPermissionService", $"Failed to compare eru versions: {arg}");
			}
			return false;
		}
	}
	public interface IUsbPermissionService
	{
		IntentFilter CreateUsbGrantedIntentFilter();

		UsbDeviceConnection OpenDevice(UsbDevice device);

		bool PermissionWasGranted(string intentAction);

		bool HasPermission(UsbDevice device);

		void RequestPermission(UsbDevice device);

		UsbDevice GetDevice(int vendorId, IEnumerable<int> validProductIds);
	}
	public abstract class BaseUsbPermissionService : IUsbPermissionService
	{
		protected readonly Context context = Application.Context;

		protected readonly UsbManager usbManager;

		protected BaseUsbPermissionService()
		{
			usbManager = context.GetSystemService("usb").JavaCast<UsbManager>();
		}

		public abstract IntentFilter CreateUsbGrantedIntentFilter();

		public UsbDeviceConnection OpenDevice(UsbDevice device)
		{
			return usbManager.OpenDevice(device);
		}

		public abstract bool PermissionWasGranted(string intentAction);

		public bool HasPermission(UsbDevice device)
		{
			return usbManager?.HasPermission(device) ?? false;
		}

		public abstract void RequestPermission(UsbDevice device);

		public UsbDevice GetDevice(int vendorId, IEnumerable<int> validProductIds)
		{
			return usbManager?.DeviceList.Select((KeyValuePair<string, UsbDevice> x) => x.Value).FirstOrDefault((UsbDevice x) => x.VendorId == vendorId && validProductIds.Contains(x.ProductId));
		}
	}
	public class UsbManagerUsbPermissionService : BaseUsbPermissionService
	{
		private const string ActionUsbPermission = "com.ifit.standalone.USB_PERMISSION";

		public override IntentFilter CreateUsbGrantedIntentFilter()
		{
			return new IntentFilter("com.ifit.standalone.USB_PERMISSION");
		}

		public override bool PermissionWasGranted(string intentAction)
		{
			return intentAction == "com.ifit.standalone.USB_PERMISSION";
		}

		public override void RequestPermission(UsbDevice device)
		{
			usbManager.RequestPermission(device, PendingIntent.GetBroadcast(context, 0, new Intent("com.ifit.standalone.USB_PERMISSION"), (PendingIntentFlags)0));
		}
	}
}
namespace Sindarin.Usb.Android.Firmware
{
	public class BootloaderUsbDevice(IUsbPermissionService usbPermissionService, IFatalityService fatalityService = null) : BaseAndroidUsbDevice(usbPermissionService, fatalityService)
	{
		protected override IReadOnlyList<int> ValidProductIds { get; } = new List<int> { 153 };

		protected override int VendorId { get; } = 8508;
	}
}
