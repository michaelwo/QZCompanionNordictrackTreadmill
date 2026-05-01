using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;
using Android.OS;
using Java.Lang.Reflect;
using Java.Util;
using MvvmCross.Platform;
using Polly;
using Sindarin.Core.Ble.Connection;
using Sindarin.Core.Ble.Connection.Characteristic;
using Sindarin.Core.Ble.Connection.Descriptor;
using Sindarin.Core.Ble.Connection.Service;
using Sindarin.Core.Ble.KnownTypes;
using Sindarin.Core.Ble.Scan;
using Sindarin.Core.Ble.Service;
using Sindarin.Usb.Android.Util;
using iFit.Collections;
using iFit.CrashReporter;
using iFit.Logger;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace Sindarin.Ble.Android.Connection;

public static class AdvertisementDataParser
{
	public static List<AdvertisementRecord> ParseScanRecord(ScanRecord scanRecord)
	{
		List<AdvertisementRecord> list = new List<AdvertisementRecord>();
		TryAddManufacturerData(scanRecord, list);
		return list;
	}

	private static void TryAddManufacturerData(ScanRecord scanRecord, List<AdvertisementRecord> records)
	{
		if (scanRecord?.ManufacturerSpecificData == null)
		{
			return;
		}
		for (int i = 0; i < scanRecord.ManufacturerSpecificData.Size(); i++)
		{
			int manufacturerId = scanRecord.ManufacturerSpecificData.KeyAt(i);
			byte[] manufacturerSpecificData = scanRecord.GetManufacturerSpecificData(manufacturerId);
			if (manufacturerSpecificData != null && manufacturerSpecificData.Length >= 2)
			{
				records.Add(new AdvertisementRecord(AdvertisementRecordType.ManufacturerSpecificData, manufacturerSpecificData));
			}
		}
	}
}
public class BleDeviceUnbondHelper : IDisposable
{
	protected static Method RemoveBondMethod;

	private readonly global::Android.Content.Context context;

	private const string LogTag = "Ble";

	private RxBroadcastReceiver broadcastReceiver;

	private IDisposable broadcastReceiverSub;

	private Subject<BluetoothDevice> onBondStateChange = new Subject<BluetoothDevice>();

	protected virtual TimeSpan BondUnbondTimeout => TimeSpan.FromSeconds(15.0);

	public static async Task<bool> RemoveBond(global::Android.Content.Context context, BluetoothDevice device, CancellationToken token)
	{
		using BleDeviceUnbondHelper unbonder = new BleDeviceUnbondHelper(context);
		return await unbonder.UnbondWithDevice(device, token);
	}

	protected static Method GetRemoveBondMethod(BluetoothDevice device)
	{
		if (RemoveBondMethod != null)
		{
			return RemoveBondMethod;
		}
		RemoveBondMethod = device?.Class?.GetMethod("removeBond");
		return RemoveBondMethod;
	}

	protected BleDeviceUnbondHelper(global::Android.Content.Context context)
	{
		this.context = context;
		CreateBroadcastReceiver();
	}

	private void CreateBroadcastReceiver()
	{
		IntentFilter intentFilter = new IntentFilter("android.bluetooth.device.action.BOND_STATE_CHANGED");
		broadcastReceiver = new RxBroadcastReceiver(intentFilter);
		broadcastReceiverSub = broadcastReceiver.WhenBroadcastReceived.Subscribe(OnBroadcastReceived);
		broadcastReceiver.StartListening(context);
	}

	private void OnBroadcastReceived(Intent intent)
	{
		string action = intent.Action;
		if (!(intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE") is BluetoothDevice value))
		{
			Log.Error("Ble", "OnBroadcastReceived could not parse BluetoothDevice from intent");
		}
		else if (action == "android.bluetooth.device.action.BOND_STATE_CHANGED")
		{
			onBondStateChange?.OnNext(value);
		}
	}

	protected async Task<bool> UnbondWithDevice(BluetoothDevice device, CancellationToken cancellationToken)
	{
		if (device == null)
		{
			Log.Error("Ble", "UnbondWithDevice called on null device");
			return true;
		}
		Method removeBondMethod = GetRemoveBondMethod(device);
		if (removeBondMethod == null)
		{
			return true;
		}
		if (broadcastReceiver == null)
		{
			Log.Trace("Ble", "Not receiving broadcasts when attempting to UnbondWithDevice.");
			return true;
		}
		Log.Trace("Ble", $"Unbonding with {device}");
		Task<BluetoothDevice> task = (from x in onBondStateChange
			where x.BondState == Bond.None
			where x == device
			select x).Timeout(BondUnbondTimeout).FirstAsync().ToTask(cancellationToken);
		removeBondMethod.Invoke(device);
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (System.OperationCanceledException exception)
		{
			Log.Trace("Ble", $"UnbondWithDevice {device} - cancelled", exception);
			return false;
		}
		catch (TimeoutException exception2)
		{
			Log.Error("Ble", $"UnbondWithDevice: {device} did not disconnect within {BondUnbondTimeout}", exception2);
			return false;
		}
		Log.Trace("Ble", $"Unbonding with {device} successful");
		return true;
	}

	public void Dispose()
	{
		broadcastReceiver?.Dispose();
		broadcastReceiverSub?.Dispose();
		onBondStateChange?.Dispose();
	}
}
public class Characteristic : CharacteristicBase
{
	private const string LogTag = "Ble";

	private IDisposable dataChangedSub;

	private IDisposable readNativeDataChangedSub;

	public override Guid Id => Guid.Parse(NativeCharacteristic.Uuid.ToString());

	public override int PropertiesRaw => (int)NativeCharacteristic.Properties;

	public override CharacteristicPropertyType Properties => (CharacteristicPropertyType)NativeCharacteristic.Properties;

	public override string Uuid => NativeCharacteristic.Uuid.ToString();

	public Service Service { get; }

	public BluetoothGattCharacteristic NativeCharacteristic { get; }

	public Characteristic(Service service, BluetoothGattCharacteristic nativeCharacteristic)
	{
		Service = service;
		NativeCharacteristic = nativeCharacteristic;
		SetupDataChangedSub();
		Log.Trace("Ble", "Initializing Characteristic " + Uuid);
	}

	private void SetupDataChangedSub()
	{
		if (dataChangedSub == null)
		{
			dataChangedSub?.Dispose();
			dataChangedSub = Service.PlatformDevice.GattCallback.WhenDataChanged.Where((DataPacket x) => x.Uuid == Uuid).Subscribe(delegate(DataPacket x)
			{
				whenDataChanged.OnNext(x.Bytes);
			});
		}
	}

	public override void Dispose()
	{
		Log.Trace("Ble", "Disposing Characteristic " + Uuid);
		dataChangedSub?.Dispose();
		dataChangedSub = null;
		readNativeDataChangedSub?.Dispose();
	}

	protected override Task<byte[]> ReadNative()
	{
		TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
		Application.SynchronizationContext.Post(delegate
		{
			if (!Service.PlatformDevice.BtGatt.ReadCharacteristic(NativeCharacteristic))
			{
				tcs.SetException(new ReadFailedException());
			}
			else
			{
				readNativeDataChangedSub?.Dispose();
				readNativeDataChangedSub = Service.PlatformDevice.GattCallback.WhenDataChanged.Where((DataPacket x) => x.Type == DataPacket.CommType.CharacteristicRead && x.Uuid == Uuid).Take(1).Timeout(TimeSpan.FromSeconds(3.0))
					.Subscribe((Action<DataPacket>)delegate(DataPacket x)
					{
						tcs.SetResult(x.Bytes);
					}, (Action<Exception>)delegate
					{
						tcs.SetException(new TimeoutException("read bytes timed out"));
					});
			}
		}, null);
		return tcs.Task;
	}

	protected override async Task StartUpdatesNative()
	{
		await SetUpdates(enabled: true, BluetoothGattDescriptor.EnableNotificationValue.ToArray());
	}

	protected override async Task StopUpdatesNative()
	{
		await SetUpdates(enabled: false, BluetoothGattDescriptor.DisableNotificationValue.ToArray());
	}

	private async Task SetUpdates(bool enabled, byte[] bytes)
	{
		TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
		Service.PlatformDevice.GattCallback.WhenDataChanged.Where((DataPacket d) => d.Type == DataPacket.CommType.DescriptorWrite && d.Uuid == NativeCharacteristic.Uuid.ToString()).Take(1).Timeout(TimeSpan.FromSeconds(10.0))
			.Subscribe((Action<DataPacket>)delegate(DataPacket o)
			{
				Log.Trace("Ble", "Set the notifications for " + Uuid + " to " + (enabled ? "enabled" : "disabled"));
				tcs.TrySetResult(o);
			}, (Action<Exception>)delegate
			{
				if (Service.Id.Equals(KnownServices.HeartRate.Id))
				{
					tcs.TrySetException(new TimeoutException("Set the notifications for heart rate timed out"));
				}
				else
				{
					tcs.TrySetException(new TimeoutException("set updates timed out"));
				}
			});
		Application.SynchronizationContext.Post(delegate
		{
			try
			{
				Service.PlatformDevice.BtGatt.SetCharacteristicNotification(NativeCharacteristic, enabled);
				BluetoothGattDescriptor descriptor = NativeCharacteristic.GetDescriptor(UUID.FromString(KnownDescriptors.ClientCharacteristicConfiguration.Id.ToString()));
				if (descriptor != null)
				{
					descriptor.SetValue(bytes);
					Service.PlatformDevice.BtGatt.WriteDescriptor(descriptor);
				}
			}
			catch (Exception ex)
			{
				Log.Error("Ble", ex.ToString());
			}
		}, null);
		await tcs.Task;
	}

	protected override void WriteNative(byte[] data)
	{
		SetupDataChangedSub();
		Service.PlatformDevice.Write(this, data);
	}

	protected override async Task<bool> WriteNativeAsync(byte[] data, bool withResponse = true)
	{
		return await Service.PlatformDevice.WriteAsync(this, data, withResponse);
	}
}
public class Descriptor : DescriptorBase
{
	public override Guid Id => Guid.ParseExact(NativeDescriptor.Uuid.ToString(), "d");

	public Characteristic Characteristic { get; }

	public BluetoothGattDescriptor NativeDescriptor { get; }

	public Descriptor(Characteristic characteristic, BluetoothGattDescriptor nativeDescriptor)
	{
		Characteristic = characteristic;
		NativeDescriptor = nativeDescriptor;
	}
}
public class Device : DeviceBase
{
	public class BondStateReceiver : BroadcastReceiver
	{
		private Device device;

		private bool isDisposed;

		public BondStateReceiver(Device device)
		{
			this.device = device;
		}

		protected override void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				device = null;
				isDisposed = true;
			}
			base.Dispose(disposing);
		}

		public override void OnReceive(global::Android.Content.Context context, Intent intent)
		{
			string action = intent.Action;
			BluetoothDevice bluetoothDevice = (BluetoothDevice)intent.GetParcelableExtra("android.bluetooth.device.extra.DEVICE");
			if (device?.BtGatt?.Device?.Address == null)
			{
				Log.Trace("Ble", "BondReceiver Gatt Device Address null");
			}
			else if (device?.BtGatt?.Device?.Address != bluetoothDevice.Address)
			{
				Log.Trace("Ble", "BondReceiver device didn't match intent device");
			}
			else if (action != null && action == "android.bluetooth.device.action.BOND_STATE_CHANGED")
			{
				Bond intExtra = (Bond)intent.GetIntExtra("android.bluetooth.device.extra.BOND_STATE", -2147483648);
				switch (intExtra)
				{
				case Bond.Bonded:
					Log.Trace("Ble", "Device " + device.Name + " succesfully bonded, updating connection state");
					device.OnBonded();
					device = null;
					break;
				case Bond.Bonding:
					Log.Trace("Ble", "Device " + device.Name + " bonding");
					break;
				default:
					Log.Trace("Ble", $"Device {device.Name} bonding state {intExtra}");
					break;
				}
			}
		}
	}

	private const string LogTag = "Ble";

	private const int DefaultCommTimeoutSeconds = 5;

	private readonly bool supportBonding;

	private BondStateReceiver bondStateReceiver;

	private IDisposable whenDisconnectedSub;

	private bool connectedAtLeastOnce;

	private IDisposable receiveDataSub;

	private bool _bondStateReceiverCleaned;

	public DeviceGattCallback GattCallback { get; set; }

	public BluetoothGatt BtGatt { get; private set; }

	public Device(IPlatformDevice device, int rssi, List<AdvertisementRecord> advertisementRecords, HashSet<KnownService> supportedServices, bool supportBonding = false)
		: base(device, rssi, advertisementRecords, supportedServices)
	{
		this.supportBonding = supportBonding;
	}

	private void SetupGattCallback()
	{
		if (GattCallback == null)
		{
			DeviceGattCallback deviceGattCallback = (GattCallback = new DeviceGattCallback());
		}
		whenDisconnectedSub?.Dispose();
		whenDisconnectedSub = GattCallback.WhenDisconnected.Subscribe(delegate
		{
			WasDisconnected();
		});
	}

	public override void Dispose()
	{
		base.Dispose();
		CleanUpDevice();
	}

	private void CleanUpDevice()
	{
		BtGatt?.Close();
		BtGatt = null;
		whenDisconnectedSub?.Dispose();
		whenDisconnectedSub = null;
		receiveDataSub?.Dispose();
		receiveDataSub = null;
	}

	public override Task<bool> Connect()
	{
		return Connect(TimeSpan.Zero);
	}

	public override async Task<bool> Connect(TimeSpan additionalTimeout)
	{
		InitializeBondStateReceiver();
		base.Connect(additionalTimeout).Wait();
		SetupGattCallback();
		if (connectedAtLeastOnce && BtGatt != null)
		{
			BtGatt.Connect();
			await ConnectCallback(additionalTimeout);
		}
		if (base.State != DeviceState.Connected)
		{
			(base.PlatformDevice as PlatformDevice)?.BluetoothDevice?.ConnectGatt(Application.Context, autoConnect: false, GattCallback);
			await ConnectCallback(additionalTimeout);
		}
		return base.State == DeviceState.Connected;
	}

	private void InitializeBondStateReceiver()
	{
		if (supportBonding)
		{
			CleanBondStateReceiver();
			Log.Trace("Ble", "Registering receiver for " + base.Name);
			bondStateReceiver = new BondStateReceiver(this);
			Application.Context.RegisterReceiver(bondStateReceiver, new IntentFilter("android.bluetooth.device.action.BOND_STATE_CHANGED"));
			_bondStateReceiverCleaned = false;
		}
	}

	private void CleanBondStateReceiver()
	{
		if (supportBonding && bondStateReceiver != null && !_bondStateReceiverCleaned)
		{
			_bondStateReceiverCleaned = true;
			Application.Context.UnregisterReceiver(bondStateReceiver);
			bondStateReceiver.Dispose();
			bondStateReceiver = null;
		}
	}

	private async Task<bool> ConnectCallback(TimeSpan additionalTimeout)
	{
		base.State = DeviceState.Connecting;
		try
		{
			BluetoothGatt bluetoothGatt = await GattCallback.WhenConnected.Timeout(TimeSpan.FromSeconds(30.0).Add(additionalTimeout)).Take(1).ToTask();
			if (bluetoothGatt != null)
			{
				connectedAtLeastOnce = true;
				if (bluetoothGatt != BtGatt)
				{
					BtGatt?.Close();
				}
				BtGatt = bluetoothGatt;
				if (supportBonding && bluetoothGatt.Device.BondState == Bond.Bonding)
				{
					Log.Trace("Ble", "Bonding to device, delaying device connection");
				}
				else
				{
					CleanBondStateReceiver();
					base.State = DeviceState.Connected;
				}
				return true;
			}
		}
		catch (TimeoutException)
		{
		}
		catch (Exception exception)
		{
			Log.Error("Ble", "Failed to connect to device due to", exception);
		}
		base.State = DeviceState.Disconnected;
		return false;
	}

	public void OnBonded()
	{
		CleanBondStateReceiver();
		base.State = DeviceState.Connected;
	}

	public void OnBondFailed()
	{
		CleanBondStateReceiver();
		base.State = DeviceState.Disconnected;
	}

	public override void Connected()
	{
		receiveDataSub = GattCallback.WhenDataChanged.Subscribe(delegate
		{
			_whenDataChanged.OnNext(default(Unit));
		});
	}

	protected override void DisconnectWasCalled()
	{
		BtGatt?.Disconnect();
		receiveDataSub?.Dispose();
		base.DisconnectWasCalled();
	}

	protected override async Task<List<IService>> GetServicesNative()
	{
		return await Policy.Handle<TimeoutException>().RetryAsync(3, delegate(Exception exception, int attempts)
		{
			Log.Trace("Ble", $"Failed to get services. Attempted {attempts} times");
		}).ExecuteAsync(GetServicesWithRetry);
		async Task<List<IService>> GetServicesWithRetry()
		{
			BtGatt.DiscoverServices();
			BluetoothGatt bluetoothGatt = await GattCallback.WhenServicesDiscovered.Take(1).Timeout(TimeSpan.FromSeconds(5.0)).ToTask();
			if (bluetoothGatt != null && bluetoothGatt.Services.CountSafe() > 0)
			{
				return ((IEnumerable<BluetoothGattService>)bluetoothGatt.Services).Select((Func<BluetoothGattService, IService>)((BluetoothGattService x) => new Service(this, x))).ToList();
			}
			throw new TimeoutException("Failed to get services.");
		}
	}

	protected override void WriteNative(PendingWrite item)
	{
		GattCallback.WhenDataChanged.Where((DataPacket x) => x.Type == DataPacket.CommType.CharacteristicWrite).Timeout(TimeSpan.FromSeconds(5.0)).Take(1)
			.Subscribe((Action<DataPacket>)delegate
			{
				WriteBytesCompleted();
			}, (Action<Exception>)delegate
			{
				WriteBytesCompleted();
			});
		BluetoothGattCharacteristic nativeCharacteristic = (item?.Characteristic as Characteristic)?.NativeCharacteristic;
		if (nativeCharacteristic == null)
		{
			return;
		}
		Application.SynchronizationContext.Post(delegate
		{
			try
			{
				nativeCharacteristic.SetValue(item.Bytes);
				BtGatt?.WriteCharacteristic(nativeCharacteristic);
				Log.Trace("Ble", $"Sent bytes to {item.Characteristic.Id} bytes: {BitConverter.ToString(item.Bytes)}");
			}
			catch (Exception ex)
			{
				Log.Error("Ble", ex.ToString());
			}
		}, null);
	}

	protected override async Task<bool> WriteNativeAsync(ICharacteristic characteristic, byte[] bytes, bool withResponse = true)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		GattCallback.WhenDataChanged.Where((DataPacket x) => x.Type == DataPacket.CommType.CharacteristicWrite && Enumerable.SequenceEqual(x.Bytes, bytes)).Timeout(TimeSpan.FromSeconds(5.0)).Take(1)
			.Subscribe((Action<DataPacket>)delegate
			{
				tcs.TrySetResult(result: true);
			}, (Action<Exception>)delegate
			{
				tcs.TrySetResult(result: false);
			});
		if (BtGatt == null)
		{
			await Connect();
		}
		BluetoothGattCharacteristic nativeCharacteristic = (characteristic as Characteristic)?.NativeCharacteristic;
		if (nativeCharacteristic == null)
		{
			return false;
		}
		Application.SynchronizationContext.Post(delegate
		{
			try
			{
				nativeCharacteristic.SetValue(bytes);
				BtGatt?.WriteCharacteristic(nativeCharacteristic);
				Log.Trace("Ble", $"Sent bytes to {characteristic.Id} bytes: {BitConverter.ToString(bytes)}");
			}
			catch (Exception ex)
			{
				tcs.TrySetResult(result: false);
				Log.Error("Ble", ex.ToString());
			}
		}, null);
		return await tcs.Task;
	}

	public override async Task<bool> RemoveBond()
	{
		return await BleDeviceUnbondHelper.RemoveBond(Application.Context, (base.PlatformDevice as PlatformDevice)?.BluetoothDevice, CancellationToken.None);
	}

	public override object Clone()
	{
		return new Device(base.PlatformDevice, base.Rssi, base.AdvertisementRecords, base.SupportedServices, supportBonding);
	}
}
public class DeviceGattCallback : BluetoothGattCallback
{
	private const string LogTag = "Ble";

	private const string LogTagData = "BleData";

	protected readonly Subject<BluetoothGatt> whenConnected = new Subject<BluetoothGatt>();

	protected readonly Subject<BluetoothGatt> whenDisconnected = new Subject<BluetoothGatt>();

	protected readonly Subject<BluetoothGatt> whenServicesDiscovered = new Subject<BluetoothGatt>();

	protected readonly Subject<DataPacket> whenDataChanged = new Subject<DataPacket>();

	public IObservable<BluetoothGatt> WhenConnected => whenConnected;

	public IObservable<BluetoothGatt> WhenDisconnected => whenDisconnected;

	public IObservable<BluetoothGatt> WhenServicesDiscovered => whenServicesDiscovered;

	public IObservable<DataPacket> WhenDataChanged => whenDataChanged;

	public override void OnConnectionStateChange(BluetoothGatt gatt, GattStatus status, ProfileState newState)
	{
		switch (((BluetoothManager)Application.Context.GetSystemService("bluetooth")).GetConnectionState(gatt.Device, ProfileType.GattServer))
		{
		case ProfileState.Connected:
			Log.Trace("Ble", "Connected to device");
			whenConnected.OnNext(gatt);
			break;
		case ProfileState.Disconnected:
			Log.Trace("Ble", "Disconnected from device");
			whenDisconnected.OnNext(gatt);
			break;
		}
	}

	public override void OnServicesDiscovered(BluetoothGatt gatt, GattStatus status)
	{
		Log.Trace("Ble", $"OnServicesDiscovered status: {status}");
		if (status == GattStatus.Success)
		{
			whenServicesDiscovered.OnNext(gatt);
		}
	}

	public override void OnCharacteristicChanged(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic)
	{
		try
		{
			string text = characteristic.Uuid.ToString();
			byte[] value = characteristic.GetValue();
			Log.Trace("BleData", "OnCharacteristicChanged " + text + " " + ByteString(value));
			DataPacket value2 = new DataPacket(DataPacket.CommType.CharacteristicChange, value, text);
			whenDataChanged.OnNext(value2);
		}
		catch (Exception ex) when (ex is ObjectDisposedException || ex is ArgumentException)
		{
		}
	}

	public override void OnCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, GattStatus status)
	{
		string uuid = characteristic.Uuid.ToString();
		byte[] value = characteristic.GetValue();
		Log.Trace("BleData", string.Format("OnCharacteristicRead {0} {1} {2}", (status == GattStatus.Success) ? "Succeded " : "Failed ", characteristic.Uuid, ByteString(value)));
		DataPacket value2 = new DataPacket(DataPacket.CommType.CharacteristicRead, value, uuid);
		whenDataChanged.OnNext(value2);
	}

	public override void OnCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, GattStatus status)
	{
		Log.Trace("BleData", string.Format("OnCharacteristicWrite {0} {1} {2}", (status == GattStatus.Success) ? "Succeded " : "Failed ", characteristic.Uuid, ByteString(characteristic.GetValue())));
		string uuid = characteristic.Uuid.ToString();
		byte[] value = characteristic.GetValue();
		DataPacket value2 = new DataPacket(DataPacket.CommType.CharacteristicWrite, value, uuid);
		whenDataChanged.OnNext(value2);
	}

	public override void OnDescriptorWrite(BluetoothGatt gatt, BluetoothGattDescriptor descriptor, GattStatus status)
	{
		Log.Trace("BleData", string.Format("OnDescriptorWrite  {0} {1} {2}", (status == GattStatus.Success) ? "Succeded " : "Failed ", descriptor.Characteristic.Uuid, ByteString(descriptor.GetValue())));
		DataPacket value = new DataPacket(DataPacket.CommType.DescriptorWrite, descriptor.GetValue(), descriptor.Characteristic.Uuid.ToString());
		whenDataChanged.OnNext(value);
	}

	public override void OnDescriptorRead(BluetoothGatt gatt, BluetoothGattDescriptor descriptor, GattStatus status)
	{
		Log.Trace("BleData", $"OnDescriptorRead {descriptor.Uuid}");
	}

	protected string ByteString(byte[] bytes)
	{
		if (bytes != null)
		{
			return BitConverter.ToString(bytes);
		}
		return "null";
	}
}
public interface IScannerFlags
{
	bool IsBondedHrMonitorEnabled();
}
public class PlatformDevice : IPlatformDevice
{
	public BluetoothDevice BluetoothDevice { get; }

	public object NativeDevice => BluetoothDevice;

	public string Name => BluetoothDevice.Name;

	public string CommonIdentifier => BluetoothDevice.Address;

	public string ShortIdentifier => CommonIdentifier;

	public PlatformDevice(BluetoothDevice device)
	{
		BluetoothDevice = device;
	}
}
public class Scanner : ScannerBase
{
	private class ScanCallbackHandler : ScanCallback
	{
		private readonly Scanner scanner;

		private readonly IBleRadioStatusService bleRadioService;

		private readonly ICrashReporter crashReporter;

		public ScanCallbackHandler(Scanner scanner, IBleRadioStatusService bleRadioService, ICrashReporter crashReporter)
		{
			this.scanner = scanner;
			this.bleRadioService = bleRadioService;
			this.crashReporter = crashReporter;
		}

		public override async void OnScanResult(ScanCallbackType callbackType, ScanResult result)
		{
			try
			{
				await scanner.OnScanResult(result).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				Log.Error("Scanner", "Exception processing bluetooth scan result", ex);
				if (crashReporter != null)
				{
					await crashReporter.ReportError(ex.Message, ex, new Dictionary<string, object>
					{
						{ "ScanCallbackType", callbackType },
						{ "ScanResult", result }
					});
				}
			}
		}

		public override void OnScanFailed(ScanFailure errorCode)
		{
			ConnectionException exception = new ConnectionException(errorCode.ToString());
			scanner.ScannerError(exception);
			if (errorCode != ScanFailure.ApplicationRegistrationFailed)
			{
				return;
			}
			if (crashReporter != null)
			{
				Task.Run(async delegate
				{
					await Task.Delay(TimeSpan.FromSeconds(15.0));
					crashReporter.ReportError("Scanner Error:" + errorCode, exception, null);
				});
			}
			bleRadioService?.CycleBluetoothRadio();
		}
	}

	private const string Tag = "Scanner";

	private readonly List<ScanResult> uniqueScanResults = new List<ScanResult>();

	private BluetoothAdapter btAdapter;

	private ScanCallbackHandler callback;

	private readonly IScannerFlags flags;

	public Scanner(IScannerFlags flags)
	{
		this.flags = flags;
		InitScanner();
	}

	private void InitScanner()
	{
		try
		{
			btAdapter = BluetoothAdapter.DefaultAdapter;
			Mvx.TryResolve<IBleRadioStatusService>(out var service);
			Mvx.TryResolve<ICrashReporter>(out var service2);
			callback = new ScanCallbackHandler(this, service, service2);
		}
		catch (Exception ex)
		{
			Log.Error("Scanner", "Problem finding Bluetooth Adapter when initializing Scanner " + ex.Message);
		}
	}

	public override async Task WarmUpScanner()
	{
		if (btAdapter == null)
		{
			InitScanner();
		}
		BluetoothAdapter bluetoothAdapter = btAdapter;
		if (bluetoothAdapter != null && bluetoothAdapter.State == State.On)
		{
			btAdapter.StartDiscovery();
			Log.Trace("Scanner", "Warming up scanner");
			await Task.Delay(1000);
			btAdapter.CancelDiscovery();
		}
	}

	protected override void ScanNative()
	{
		if (btAdapter == null)
		{
			InitScanner();
		}
		BluetoothAdapter bluetoothAdapter = btAdapter;
		if (bluetoothAdapter != null && bluetoothAdapter.State == State.On)
		{
			StartScan();
		}
		else
		{
			base.CurrentState = ScanState.NoBluetooth;
		}
	}

	protected virtual void StartScan()
	{
		lock (uniqueScanResults)
		{
			uniqueScanResults.Clear();
		}
		btAdapter.BluetoothLeScanner?.StartScan(callback);
		base.CurrentState = ScanState.Scanning;
	}

	protected override void StopScanNative()
	{
		BluetoothAdapter bluetoothAdapter = btAdapter;
		if (bluetoothAdapter != null && bluetoothAdapter.State == State.On)
		{
			DoStopScanNative();
		}
		else
		{
			base.CurrentState = ScanState.NoBluetooth;
		}
	}

	protected virtual void DoStopScanNative()
	{
		btAdapter.BluetoothLeScanner?.StopScan(callback);
		base.CurrentState = ScanState.Idle;
		lock (uniqueScanResults)
		{
			uniqueScanResults.Clear();
		}
	}

	private Task OnScanResult(ScanResult result)
	{
		lock (uniqueScanResults)
		{
			if (string.IsNullOrWhiteSpace(result?.Device?.Address) || uniqueScanResults.Exists((ScanResult x) => x?.Device?.Address == result.Device.Address))
			{
				return Task.CompletedTask;
			}
			uniqueScanResults.Add(result);
		}
		return Task.Run(delegate
		{
			bool supportBonding = flags.IsBondedHrMonitorEnabled();
			Device device = new Device(new PlatformDevice(result.Device), advertisementRecords: AdvertisementDataParser.ParseScanRecord(result.ScanRecord), supportedServices: ParseServices(result.ScanRecord?.ServiceUuids), rssi: result.Rssi, supportBonding: supportBonding);
			OnDeviceFound(device);
		});
	}

	private HashSet<KnownService> ParseServices(IList<ParcelUuid> peripheralServices)
	{
		HashSet<KnownService> hashSet = new HashSet<KnownService>();
		ParcelUuid[] array = peripheralServices?.ExcludingNulls().ToArray();
		if (array == null || array.Length < 1)
		{
			return hashSet;
		}
		ParcelUuid[] array2 = array;
		foreach (ParcelUuid peripheralService in array2)
		{
			KnownService knownService = KnownServiceFromPeripheral(peripheralService);
			if (knownService != null)
			{
				hashSet.Add(knownService);
			}
		}
		return hashSet;
	}

	private KnownService KnownServiceFromPeripheral(ParcelUuid peripheralService)
	{
		if (peripheralService == null)
		{
			return null;
		}
		string text = peripheralService.Uuid?.ToString();
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		KnownService knownService = KnownServices.PartialLookup(text);
		if (knownService != null)
		{
			return knownService;
		}
		if (!Guid.TryParse(text, out var result))
		{
			return null;
		}
		return KnownServices.Lookup(result);
	}
}
public class Service : ServiceBase
{
	public override Guid Id => Guid.ParseExact(NativeService.Uuid.ToString(), "d");

	public override bool IsPrimary => NativeService.Type == GattServiceType.Primary;

	public Device PlatformDevice { get; }

	public BluetoothGattService NativeService { get; }

	public Service(Device device, BluetoothGattService nativeService)
		: base(device)
	{
		PlatformDevice = device;
		NativeService = nativeService;
	}

	protected override Task<List<ICharacteristic>> GetCharacteristicsNative()
	{
		return Task.FromResult(((IEnumerable<BluetoothGattCharacteristic>)NativeService.Characteristics).Select((Func<BluetoothGattCharacteristic, ICharacteristic>)((BluetoothGattCharacteristic x) => new Characteristic(this, x))).ToList());
	}
}
