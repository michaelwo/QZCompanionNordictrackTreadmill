using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Sindarin.Core;
using Sindarin.Core.Ble.Connection;
using Sindarin.Core.Ble.Connection.Characteristic;
using Sindarin.Core.Ble.Connection.Service;
using Sindarin.Core.Ble.KnownTypes;
using Sindarin.Core.Ble.Service;
using Sindarin.Core.Communication.Logging;
using Sindarin.Core.Connection;
using Sindarin.Core.Console;
using Sindarin.Core.Services.Fatality;
using Sindarin.Core.Util;
using Sindarin.FitPro1.Ble.Connection;
using Sindarin.FitPro1.Communication;
using iFit.Collections;
using iFit.Logger;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Sindarin.FitPro1.Ble")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Sindarin.FitPro1.Ble")]
[assembly: AssemblyTitle("Sindarin.FitPro1.Ble")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Sindarin.FitPro1.Ble
{
	public static class BleFitnessConsoleFactory
	{
		public static IFitnessConsole GetConsole(IBleDevice device, IBleRadioStatusService bluetoothStatusService, ISindarinEventHandler sindarinEventHandler, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
		{
			return new FitPro1Console(new FitProBleConsoleCommunicationAdapter(new FitProConsoleConnection(device, bluetoothStatusService), fatalityService), sindarinEventHandler, fatalityService, fitProBytesLogger);
		}
	}
}
namespace Sindarin.FitPro1.Ble.Connection
{
	public class FitProBleConsoleCommunicationAdapter : FitProCommunicationAdapter
	{
		public override ConnectionType ConnectionType { get; } = ConnectionType.BLE;

		public override TimeSpan DefaultTimeout => base.Connection.Timeout;

		protected override int maxItemLostBeforeFatality => 2147483647;

		protected override TimeSpan rateOfItemLostDecay => TimeSpan.FromSeconds(2.0);

		public FitProBleConsoleCommunicationAdapter(IDeviceConnection connection, IFatalityService fatalityService)
			: base(connection, fatalityService)
		{
		}

		protected override IDisposable CreateDataChangedSubscriber()
		{
			return base.Connection.WhenValueUpdated.Timeout(base.CurrentQueueItem.Timeout).SubscribeAsync(DataReceived, base.DataResponseError);
		}

		protected override async Task DataReceived(byte[] bytes)
		{
			await base.DataReceived(bytes);
			if (CheckResponseComplete(base.CurrentQueueItemGroup))
			{
				await CommGroupResponseComplete();
			}
		}

		protected bool CheckResponseComplete(FitProCommunicationGroup commGroup)
		{
			if ((commGroup?.ResponsePackets?.Count).GetValueOrDefault() == 0)
			{
				return false;
			}
			byte[] array = commGroup.ResponsePackets.FirstOrDefault();
			byte[] array2 = commGroup.ResponsePackets.LastOrDefault();
			if (array.CountSafe() == 0 || array2.CountSafe() == 0)
			{
				return false;
			}
			bool num = array[0] == 254;
			bool flag = array2[0] == 255;
			return num && flag;
		}
	}
	public abstract class FitProConnection : PersistentConnection, IDeviceConnection, IDisposable
	{
		private const string LogTag = "Connection";

		protected ICharacteristic deviceRx;

		protected ICharacteristic deviceTx;

		protected IDisposable valueUpdatedSub;

		public TimeSpan Timeout { get; } = TimeSpan.FromMilliseconds(500.0);

		protected FitProConnection(IBleDevice device, IBleRadioStatusService bluetoothStatusService)
			: base(device, bluetoothStatusService)
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			valueUpdatedSub?.Dispose();
			valueUpdatedSub = null;
			deviceRx?.Dispose();
			deviceRx = null;
			deviceTx?.Dispose();
			deviceTx = null;
		}

		protected override async Task Connected()
		{
			if (base.Device == null)
			{
				ConnectionFailed("FitPro device is null in Connected method");
				return;
			}
			Log.Trace("Connection", "successfully connected to a FitPro device");
			List<IService> services;
			try
			{
				services = await base.Device.GetServices();
			}
			catch (Exception ex)
			{
				ConnectionFailed($"Could not get FitPro device services: {ex}", ex);
				return;
			}
			await InitFitProService(services);
			Log.Trace("Connection", "successfully configured the FitPro device");
			await base.Connected();
		}

		private async Task InitFitProService(List<IService> services)
		{
			Log.Trace("Connection", "initializing fitpro service");
			IList<ICharacteristic> list = await TryGetServiceCharacteristics(services, KnownServices.FitPro.Id);
			Log.Trace("Connection", $"Got {list?.Count} characteristics for service {KnownServices.FitPro.Id}.");
			if (list == null)
			{
				ConnectionFailed("Could not get FitPro service characteristics");
				return;
			}
			deviceRx?.Dispose();
			deviceRx = list.FirstOrDefault((ICharacteristic x) => x.Id.Equals(KnownCharacteristics.DeviceRx.Id));
			if (deviceRx == null)
			{
				ConnectionFailed("Could not get FitPro device Rx characteristic");
				return;
			}
			deviceTx?.Dispose();
			deviceTx = list.FirstOrDefault((ICharacteristic x) => x.Id.Equals(KnownCharacteristics.DeviceTx.Id));
			if (deviceTx == null)
			{
				ConnectionFailed("Could not get FitPro device Tx characteristic");
				return;
			}
			await deviceTx.StartUpdates();
			Log.Trace("Connection", "started updates");
			valueUpdatedSub?.Dispose();
			valueUpdatedSub = deviceTx.WhenDataChanged.Subscribe(delegate(byte[] x)
			{
				whenValueUpdated.OnNext(x);
			});
		}

		protected async Task<IList<ICharacteristic>> TryGetServiceCharacteristics(List<IService> services, Guid serviceId)
		{
			IService service = services?.FirstOrDefault((IService x) => x?.Id.Equals(serviceId) == true);
			if (service == null)
			{
				ConnectionFailed($"Could not find service with Id {serviceId}");
				return null;
			}
			try
			{
				return await service.GetCharacteristics();
			}
			catch (Exception ex)
			{
				ConnectionFailed($"Could not get service characteristics: {ex}", ex);
				return null;
			}
		}

		protected void ConnectionFailed(string message, Exception ex = null)
		{
			Log.Trace("Connection", message);
			throw new ConnectionException(message, ex);
		}

		public async Task SendBytes(byte[] bytes)
		{
			if (base.Device.State == DeviceState.Connected && deviceRx != null)
			{
				await deviceRx.WriteAsync(bytes);
			}
		}

		public async Task SendBytesWithReadDelay(byte[] bytes, TimeSpan delay)
		{
			await SendBytes(bytes);
		}

		public async Task<bool> Disconnect()
		{
			Log.Trace("Connection", "Requesting connection disconnect");
			valueUpdatedSub?.Dispose();
			valueUpdatedSub = null;
			if (base.Device != null)
			{
				return await base.Device.Disconnect();
			}
			return true;
		}

		public async Task ReadBytesWithDelay(TimeSpan delay)
		{
		}
	}
	public class FitProConsoleConnection : FitProConnection
	{
		public FitProConsoleConnection(IBleDevice device, IBleRadioStatusService bluetoothStatusService)
			: base(device, bluetoothStatusService)
		{
		}

		protected override async Task Connected()
		{
			await base.Connected();
			base.Initialized = true;
		}
	}
}
