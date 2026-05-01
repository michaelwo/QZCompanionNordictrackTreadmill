using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics;
using MoreLinq;
using MvvmCross.Platform;
using Newtonsoft.Json;
using Sindarin.Core;
using Sindarin.Core.Communication;
using Sindarin.Core.Communication.Logging;
using Sindarin.Core.Connection;
using Sindarin.Core.Console;
using Sindarin.Core.DataObjects;
using Sindarin.Core.Services;
using Sindarin.Core.Services.Fatality;
using Sindarin.Core.Util;
using Sindarin.FitPro1.Bits;
using Sindarin.FitPro1.Bits.Converters;
using Sindarin.FitPro1.Commands;
using Sindarin.FitPro1.Communication;
using Sindarin.FitPro1.Console;
using Sindarin.FitPro1.DataObjects;
using Sindarin.FitPro1.Equipment;
using Sindarin.FitPro1.Equipment.Communication;
using Sindarin.FitPro1.Util;
using Sindarin.FitPro1.Utils;
using iFit.Collections;
using iFit.Extensions;
using iFit.Logger;
using iFit.Mathematics;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: InternalsVisibleTo("Sindarin.FitPro1.Tests")]
[assembly: InternalsVisibleTo("Sindarin.Core.Ble")]
[assembly: InternalsVisibleTo("Sindarin.FitPro1.Ble")]
[assembly: InternalsVisibleTo("Sindarin.FitPro1.Tcp")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: AssemblyCompany("Sindarin.FitPro1.Core")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Sindarin.FitPro1.Core")]
[assembly: AssemblyTitle("Sindarin.FitPro1.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Sindarin.FitPro1
{
	internal static class EquipmentUtil
	{
		public static string LogTag = "FitPro";

		public const int MaxMsgLength = 64;

		public static byte GetCheckSum(byte[] bytes)
		{
			byte b = 0;
			byte b2 = bytes[1];
			for (int i = 0; i < b2 - 1; i++)
			{
				b += bytes[i];
			}
			return b;
		}

		public static byte[] CalculateSecurityHash(int serialNumber, int partNumber, int modelNumber)
		{
			byte[] array = new byte[32];
			for (byte b = 0; b < 32; b++)
			{
				array[b] = (byte)(b + 1);
				if (((serialNumber >> (int)b) & 1) == 1)
				{
					if (b < 16)
					{
						array[b] ^= (byte)(((partNumber << 16) | (partNumber >> 16)) >> (int)b);
					}
					else
					{
						array[b] ^= (byte)(partNumber >> (int)b);
					}
				}
				else
				{
					array[b] ^= (byte)(array[b] * (b + modelNumber));
				}
			}
			return array;
		}

		public static byte GetHeaderDataBitBytesForSection(IEnumerable<int> ids)
		{
			byte b = 0;
			foreach (int item in ids.Select((int x) => x % 8))
			{
				b |= (byte)(1 << item);
			}
			return b;
		}

		public static bool IsValidCommandResponse(byte[] bytes, Command id, bool expectResponse)
		{
			if (!expectResponse)
			{
				return true;
			}
			if (bytes == null)
			{
				Log.Error(LogTag, $"FitPro invalid command response.  Reason: 'bytes == null'. Command id: {id}");
				return false;
			}
			if (bytes.Length < 3)
			{
				Log.Error(LogTag, $"FitPro invalid command response.  Reason: 'bytes.Length < 3'. Command id: {id}, bytes: {BitConverter.ToString(bytes)}");
				return false;
			}
			if (bytes[0] == 0)
			{
				Log.Error(LogTag, $"FitPro invalid command response.  Reason: 'bytes [0] == 0'. Command id: {id}, bytes[0] == 0");
				return false;
			}
			if (bytes[1] > 64)
			{
				Log.Error(LogTag, $"FitPro invalid command response,  Reason: exceeds MaxMsgLength, {64}.  Command id: {id}, bytes: {BitConverter.ToString(bytes)}");
				return false;
			}
			if ((Command)bytes[2] != id)
			{
				Log.Error(LogTag, $"FitPro invalid command response.  Reason: command ID mismatch. Command id: {id}, bytes: {BitConverter.ToString(bytes)}");
				return false;
			}
			try
			{
				if (bytes[bytes[1] - 1] != GetCheckSum(bytes))
				{
					Log.Error(LogTag, $"FitPro invalid command response. Reason: CheckSum invalid.  Command id: {id}, bytes: {BitConverter.ToString(bytes)}");
					return false;
				}
			}
			catch (IndexOutOfRangeException)
			{
				Log.Error(LogTag, string.Format($"Invalid command response.  Index {bytes[1] - 1} for byte array of length {bytes.Length}.  Command id: {id}, bytes: {BitConverter.ToString(bytes)}"));
				return false;
			}
			return true;
		}

		public static byte[] CleanResponse(byte[] bytes, List<IBitFieldCommItem> readComms)
		{
			if (bytes == null || bytes.Length < 5)
			{
				Log.Trace(LogTag, $"Response Bytes Length == {bytes?.Length}");
				return bytes;
			}
			int fitProCommandLength = bytes.GetFitProCommandLength();
			if (fitProCommandLength == -1)
			{
				throw new ArgumentException("Invalid command length in response: " + BitConverter.ToString(bytes));
			}
			bytes = bytes.Take(fitProCommandLength).ToArray();
			if (readComms == null)
			{
				return bytes;
			}
			byte[] array = new byte[fitProCommandLength];
			array[0] = (byte)bytes.GetFitProDevice();
			array[1] = (byte)fitProCommandLength;
			array[2] = (byte)bytes.GetFitProCommandId();
			array[3] = (byte)bytes.GetFitProCommandStatus();
			int num = 4;
			for (int i = 0; i < readComms.Count; i++)
			{
				if (num >= fitProCommandLength - 1)
				{
					break;
				}
				int size = readComms[i].BitField.GetConverter().Size;
				int num2 = 0;
				while (num2 < size && num < fitProCommandLength - 1)
				{
					array[num] = bytes[num];
					num2++;
					num++;
				}
			}
			array[fitProCommandLength - 1] = bytes[fitProCommandLength - 1];
			return array;
		}
	}
	public static class FitProByteExtensions
	{
		public static int GetFitProCommandLength(this byte[] bytes)
		{
			if (bytes == null || bytes.Length < 5)
			{
				return -1;
			}
			return bytes[1];
		}

		public static Device GetFitProDevice(this byte[] bytes)
		{
			if (bytes == null || bytes.Length < 5)
			{
				return Device.None;
			}
			return (Device)bytes[0];
		}

		public static Command GetFitProCommandId(this byte[] bytes)
		{
			if (bytes == null || bytes.Length < 5)
			{
				return Command.None;
			}
			return (Command)bytes[2];
		}

		internal static CmdStatus GetFitProCommandStatus(this byte[] bytes)
		{
			if (bytes == null || bytes.Length < 5)
			{
				return CmdStatus.UnknownFailure;
			}
			return (CmdStatus)bytes[3];
		}
	}
	internal interface IFitPro1Console : IFitnessConsole, ICalibrateIncline, IDisposable, IForceClubUnit, IQueueManagerAdapter
	{
		Device DeviceType { get; }
	}
	internal class FitPro1Console : FitnessConsoleBase, IFitPro1Console, IFitnessConsole, ICalibrateIncline, IDisposable, IForceClubUnit, IQueueManagerAdapter
	{
		private const int PeriodicDataTimeoutMillis = 3000;

		private ReadOnlyCollection<BitField> periodicBitFields;

		private List<IBitFieldCommItem> cachedCollectionOfBitFieldCommItems;

		private IDisposable sendIntervalSub;

		private readonly TimeSpan sendInterval;

		private IDisposable calibrationSub;

		private bool inclineCalibrationInProgress;

		private int estimatedTime;

		private IDisposable tickSub;

		private FitProCommunicationAdapter _adapter;

		private IFitProCommTimeoutMonitoringService fitProCommTimeoutMonitoringService;

		private IDisposable unlockedToIdleSub;

		private IDisposable commLossSub;

		private IDisposable connectionStateChangeSub;

		private int commandsProcessing;

		public IQueueManager QueueManager { get; private set; }

		public SystemDeviceInfo SystemDeviceInfo { get; private set; }

		public DeviceInfo PrimaryDevice { get; protected set; }

		public VersionInfo VersionInfo { get; private set; }

		public string BrainboardSerialNumber { get; private set; }

		public DateTime LastHeartBeat { get; set; }

		public bool PeriodicDataEnabled { get; set; }

		public Device DeviceType { get; private set; }

		public override ConnectionType ConnectionType => adapter.ConnectionType;

		public override TimeSpan DefaultTimeout => adapter.DefaultTimeout;

		private FitProCommunicationAdapter Adapter => _adapter ?? (_adapter = adapter as FitProCommunicationAdapter);

		public FitPro1Console(IFitProCommunicationAdapter adapter, ISindarinEventHandler sindarinEventHandler, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger, int sendIntervalMillis = 100)
			: base(adapter)
		{
			FitPro1Console fitPro1Console = this;
			sendInterval = TimeSpan.FromMilliseconds(sendIntervalMillis);
			QueueManager = new QueueManager(this, base.LatestBasicInfo, sindarinEventHandler, fatalityService, fitProBytesLogger);
			connectionStateChangeSub = adapter.Connection.WhenConnectionStateChanged.Where((bool connected) => !connected).SubscribeWithErrorLogging(delegate
			{
				fitPro1Console.OnDisconnect();
				BitFieldExtensions.Clear();
				Log.Trace("FitnessConsole", "Disconnected. trying to reinitialize");
				fitPro1Console.InitializeConnection();
			});
			unlockedToIdleSub = base.WhenStateChanged.Where((StateChange x) => x.Current == ConsoleState.Locked && adapter.Connection.Initialized).SubscribeWithErrorLogging(delegate
			{
				fitPro1Console.Unlock();
			});
			InitializeConnection();
		}

		protected override void OnDisconnect()
		{
			if (base.LatestBasicInfo.CurrentState == ConsoleState.Workout || base.LatestBasicInfo.CurrentState == ConsoleState.WarmUp || base.LatestBasicInfo.CurrentState == ConsoleState.CoolDown || base.LatestBasicInfo.CurrentState == ConsoleState.PauseOverride)
			{
				Log.Debug("EquipmentConsole", "Brainboard disconnected, starting timer");
				QueueManager?.ClearQueue();
				estimatedTime = base.LatestBasicInfo.CurrentTime;
				tickSub = Observable.Interval(TimeSpan.FromSeconds(1.0)).SubscribeWithErrorLogging(delegate
				{
					OnTimerTick();
				});
			}
		}

		protected override void OnReconnect()
		{
			tickSub?.Dispose();
			tickSub = null;
		}

		public override bool FitnessValueSupported(FitnessValue value)
		{
			BitField? bitField = value.ToBitField();
			if (bitField.HasValue)
			{
				return IsBitFieldSupported(bitField.Value);
			}
			return false;
		}

		protected override async Task Shutdown()
		{
			await base.Shutdown();
			PeriodicDataEnabled = false;
			await QueueManager.Shutdown();
		}

		public override async Task InitializeConsole()
		{
			if (!base.Initialized)
			{
				connectionInitializedSub?.Dispose();
				connectionInitializedSub = null;
				Log.Trace("FitnessConsole", "OnInitChanged");
				commLossSub?.Dispose();
				commLossSub = adapter.WhenCommsFailed.Where((bool x) => x).SubscribeWithErrorLogging(delegate
				{
					Shutdown();
				});
				CommandCommItem<DeviceInfo> commandCommItem = new CommandCommItem<DeviceInfo>(new DeviceInfoCmd(Device.Main));
				QueueManager.Enqueue(commandCommItem);
				PrimaryDevice = await commandCommItem.Tcs.Task;
				await GetDeviceTree(PrimaryDevice);
				QueueManager.PrimaryDevice = PrimaryDevice;
				CommandCommItem<SystemDeviceInfo> systemInfoCmd = new CommandCommItem<SystemDeviceInfo>(new SystemInfoCmd());
				CommandCommItem<VersionInfo> versionInfoCmd = new CommandCommItem<VersionInfo>(new VersionInfoCmd());
				CommandCommItem<string> brainboardSerialNumberCmd = new CommandCommItem<string>(new SerialNumberCmd());
				Dictionary<Command, Func<Task>> dictionary = new Dictionary<Command, Func<Task>>
				{
					{
						Command.SystemInfo,
						async delegate
						{
							SystemDeviceInfo systemDeviceInfo = await PerformInitialCommand(systemInfoCmd);
							SystemDeviceInfo = systemDeviceInfo;
						}
					},
					{
						Command.VersionInfo,
						async delegate
						{
							VersionInfo versionInfo = await PerformInitialCommand(versionInfoCmd);
							VersionInfo = versionInfo;
						}
					},
					{
						Command.SerialNumber,
						async delegate
						{
							string brainboardSerialNumber = await PerformInitialCommand(brainboardSerialNumberCmd);
							BrainboardSerialNumber = brainboardSerialNumber;
						}
					}
				};
				foreach (KeyValuePair<Command, Func<Task>> item in dictionary)
				{
					if (PrimaryDevice.SupportedCommands.Contains(item.Key))
					{
						await item.Value();
					}
				}
				InitPeriodicBitFields();
				if (PrimaryDevice.SoftwareVersion > 75)
				{
					await Unlock();
				}
				DeviceType = PrimaryDevice.Device;
				base.ConsoleInfo = new ConsoleInfo(this, PrimaryDevice, SystemDeviceInfo, VersionInfo, BrainboardSerialNumber);
				base.LatestBasicInfo = new ConsoleBasicInfo(SupportsPauseOverride);
				base.FitnessValueChangeManager.BasicInfo = base.LatestBasicInfo;
				QueueManager.ValueUpdater = base.LatestBasicInfo;
				base.Initialized = true;
				Log.Trace("FitnessConsole", "Console Initialized");
				_whenConsoleInitialized.OnNext(base.ConsoleInfo);
				ConverterMap.UpdateConsole(this);
				base.ReadableTypes = PrimaryDevice.SupportedBitFields.Select((BitField x) => x.ToFitnessValue()).WhereNotNull().ToList();
				base.WritableTypes = (from x in PrimaryDevice.SupportedBitFields
					where !x.IsReadOnly()
					select x.ToFitnessValue()).WhereNotNull().ToList();
				bool flag = IsBitFieldSupported(BitField.RequireStartRequested);
				SetRequireStartRequested(flag);
				bool idleModeLockout = !flag || !PrimaryDevice.Device.IsBeltBasedMachine();
				SetIdleModeLockout(idleModeLockout);
				base.StartKeyEnabled = PrimaryDevice.SupportedBitFields.Contains(BitField.RequireStartRequested);
				await ReadStartupData();
				PeriodicDataEnabled = true;
				StartPeriodicData();
			}
			else
			{
				OnReconnect();
			}
		}

		private async Task GetDeviceTree(DeviceInfo info)
		{
			CommandCommItem<List<Device>> commandCommItem = new CommandCommItem<List<Device>>(new SupportedDevicesCmd(info.Device));
			CommandCommItem<HashSet<Command>> supportedCommandsCmd = new CommandCommItem<HashSet<Command>>(new SupportedCommandsCmd(info.Device));
			QueueManager.Enqueue(new List<ICommItem> { commandCommItem, supportedCommandsCmd });
			DeviceInfo deviceInfo = info;
			deviceInfo.SubDevices = await commandCommItem.Tcs.Task;
			deviceInfo = info;
			deviceInfo.SupportedCommands = await supportedCommandsCmd.Tcs.Task;
		}

		protected void InitPeriodicBitFields()
		{
			if (periodicBitFields != null && cachedCollectionOfBitFieldCommItems != null)
			{
				return;
			}
			if (periodicBitFields == null)
			{
				periodicBitFields = new ReadOnlyCollection<BitField>(Defaults.PeriodicFields.Where(IsBitFieldSupported).ToList());
			}
			if (cachedCollectionOfBitFieldCommItems == null)
			{
				cachedCollectionOfBitFieldCommItems = new List<IBitFieldCommItem>(((IEnumerable<BitField>)periodicBitFields).Select((Func<BitField, IBitFieldCommItem>)((BitField x) => new BitFieldCommItem(x))).ToList());
			}
		}

		private bool IsBitFieldSupported(BitField bitField)
		{
			return PrimaryDevice.SupportedBitFields.Contains(bitField);
		}

		private async Task<TResult> PerformInitialCommand<TResult>(CommandCommItem<TResult> command)
		{
			QueueManager.Enqueue(command);
			return await command.Tcs.Task;
		}

		public async Task Unlock()
		{
			byte[] securityHash = EquipmentUtil.CalculateSecurityHash(PrimaryDevice.SerialNumber, SystemDeviceInfo.PartNumber, SystemDeviceInfo.Model);
			CommandCommItem<SecurityInfo> commandCommItem = new CommandCommItem<SecurityInfo>(new VerifySecurityCmd(PrimaryDevice.Device, securityHash, VersionInfo.MasterLibraryVersion));
			QueueManager.Enqueue(commandCommItem);
			await commandCommItem.Tcs.Task;
		}

		private async Task ReadStartupData()
		{
			List<IBitFieldCommItem> list = Defaults.StartupFields.Where(IsBitFieldSupported).Select((Func<BitField, IBitFieldCommItem>)((BitField x) => new BitFieldCommItem(x))).ToList();
			QueueManager.Enqueue(list);
			await Task.WhenAll(list.Select((IBitFieldCommItem x) => x.Tcs.Task).ToList());
		}

		private async Task Timeout(CancellationTokenSource timeoutCancellationToken)
		{
			await Task.Delay(3000, timeoutCancellationToken.Token);
			if (fitProCommTimeoutMonitoringService == null && Mvx.TryResolve<IFitProCommTimeoutMonitoringService>(out var service))
			{
				fitProCommTimeoutMonitoringService = service;
			}
			Log.Trace("StartPeriodicData", $"Timeout count: {fitProCommTimeoutMonitoringService?.TimeoutCount}");
			fitProCommTimeoutMonitoringService?.TimeoutOccurred();
		}

		protected async void StartPeriodicData()
		{
			while (PeriodicDataEnabled && periodicBitFields != null)
			{
				object obj = null;
				try
				{
					try
					{
						_whenDataTimerChanged.OnNext(value: true);
						ResetBitFieldsForQueueManager(cachedCollectionOfBitFieldCommItems);
						QueueManager.Enqueue(cachedCollectionOfBitFieldCommItems);
						if (commandsProcessing == 0)
						{
							DetectControlValueChangedOnConsole();
						}
						else
						{
							Log.Trace("FitnessConsole", $"StartPeriodicData skipping DetectControlValueChangedOnConsole because commandsProcessing = {commandsProcessing}");
						}
						CancellationTokenSource timeoutCancellationToken = new CancellationTokenSource();
						Task task = Timeout(timeoutCancellationToken);
						Task<object[]> task2 = Task.WhenAll(cachedCollectionOfBitFieldCommItems.Select((IBitFieldCommItem x) => x.Tcs.Task));
						await Task.WhenAny(task2, task);
						timeoutCancellationToken.Cancel();
					}
					catch (Exception ex)
					{
						TaskContinueWithException.LogThreadException(ex);
					}
				}
				catch (object obj2)
				{
					obj = obj2;
				}
				_whenDataTimerChanged.OnNext(value: false);
				LastHeartBeat = DateTime.Now;
				await Task.Delay(sendInterval);
				object obj3 = obj;
				if (obj3 != null)
				{
					ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
				}
			}
		}

		public void ReadBasicValues(params FitnessValue[] fields)
		{
			List<BitFieldCommItem> list = (from x in (from x in fields
					select x.ToBitField() into x
					where x.HasValue
					select x.Value).Where(IsBitFieldSupported)
				select new BitFieldCommItem(x)).ToList();
			if (list.Count != 0)
			{
				CommandCommItem<bool> commandCommItem = new CommandCommItem<bool>(new ReadWriteDataCmd(PrimaryDevice.Device, base.LatestBasicInfo, list));
				QueueManager.Enqueue(commandCommItem);
			}
		}

		protected override async Task<bool> SetValidatedValuesAsync((FitnessValue, object)[] values)
		{
			_ = 4;
			try
			{
				await Timers.SendValueTimer.StartAsync().ConfigureAwait(continueOnCapturedContext: false);
				List<IBitFieldCommItem> list = new List<IBitFieldCommItem>();
				for (int i = 0; i < values.Length; i++)
				{
					(FitnessValue, object) tuple = values[i];
					ProcessFitnessValue(tuple.Item1, tuple.Item2, list);
				}
				if (list.Count == 0)
				{
					Log.Trace("FitnessConsole", "nothing to send; returning");
					return false;
				}
				Log.Trace("FitnessConsole", $"Queuing ReadWriteDataCmd with {list.Count} comms");
				ReadWriteDataCmd command = new ReadWriteDataCmd(PrimaryDevice.Device, base.LatestBasicInfo, null, list);
				CommandCommItem<bool> comm = new CommandCommItem<bool>(command);
				QueueManager.Enqueue(comm);
				commandsProcessing++;
				bool success = await comm.Tcs.Task.ConfigureAwait(continueOnCapturedContext: false);
				Log.Trace("FitnessConsole", $"ReadWriteDataCmd completed with success = {success}");
				lastKphValue = base.LatestBasicInfo.Kph;
				lastGradeValue = base.LatestBasicInfo.Grade;
				lastResistanceValue = base.LatestBasicInfo.Resistance;
				lastGearValue = base.LatestBasicInfo.Gear?.CurrentGear;
				commandsProcessing = Math.Max(commandsProcessing - 1, 0);
				if (success)
				{
					await Timers.SendValueTimer.EndAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await Timers.SendValueTimer.AbortAsync().ConfigureAwait(continueOnCapturedContext: false);
					CommandBase<bool> command2 = comm.Command;
					if (command2 != null && command2.Status == CmdStatus.SecurityBlock)
					{
						Log.Trace("FitnessConsole", "Unlocking again");
						await Unlock().ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				return success;
			}
			catch (Exception ex)
			{
				if (values == null)
				{
					Log.Error("FitnessConsole", "Values is null");
				}
				Log.Error("FitnessConsole", "Couldn't set values in IFitPro1Console.SetValidatedValuesAsync: " + ex.Message);
				Log.Error("FitnessConsole", ex.StackTrace);
				return false;
			}
		}

		protected void ProcessFitnessValue(FitnessValue fv, object value, List<IBitFieldCommItem> comms)
		{
			if (fv == FitnessValue.Gear && value.IsNumber())
			{
				int valueOrDefault = (base.LatestBasicInfo?.Gear?.MaxGear).GetValueOrDefault();
				int valueOrDefault2 = (base.LatestBasicInfo?.Gear?.GearOption).GetValueOrDefault();
				Gear value2 = new Gear((int)value, valueOrDefault2, valueOrDefault);
				SafelyAddBitFieldWriteItem(comms, BitField.Gear, value2);
				return;
			}
			switch (fv)
			{
			case FitnessValue.Pulse:
			{
				int? num = base.LatestBasicInfo?.CurrentPulse?.UserPulse;
				if (value is Pulse { UserPulse: var userPulse } pulse && userPulse != num)
				{
					SafelyAddBitFieldWriteItem(comms, BitField.Pulse, pulse);
				}
				else if (value.IsNumber() && (int)value != num)
				{
					Pulse value3 = new Pulse((int)value, 0, 0, Pulse.Source.Ble);
					SafelyAddBitFieldWriteItem(comms, BitField.Pulse, value3);
				}
				break;
			}
			case FitnessValue.WorkoutMode:
			{
				WorkoutMode workoutMode = ((ConsoleState)value).ToWorkoutMode();
				SafelyAddBitFieldWriteItem(comms, BitField.WorkoutMode, workoutMode);
				break;
			}
			case FitnessValue.Weight:
			{
				double num2 = (double)value;
				Log.Trace("FitnessConsole", $"SetWeight {num2}");
				double b = base.ConsoleInfo?.MaxWeight ?? 136.078;
				double num3 = num2.Clamp(45.36, b);
				if (!num3.AlmostEqual(num2))
				{
					Log.Trace("FitnessConsole", $"SetWeight - Weight was clamped to: {num3}");
				}
				BitField? bitField2 = fv.ToBitField();
				if (bitField2.HasValue)
				{
					SafelyAddBitFieldWriteItem(comms, bitField2.Value, value);
				}
				break;
			}
			default:
			{
				BitField? bitField = fv.ToBitField();
				if (bitField.HasValue)
				{
					SafelyAddBitFieldWriteItem(comms, bitField.Value, value);
				}
				break;
			}
			}
		}

		public override async Task<object> GetValueAsync(FitnessValue type)
		{
			try
			{
				ConfiguredTaskAwaitable<AnyFitnessValueChange> configuredTaskAwaitable = base.FitnessValueChangeManager.WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => x.Type == type).Take(1).Timeout(DefaultTimeout)
					.ToTask()
					.ConfigureAwait(continueOnCapturedContext: false);
				ReadBasicValues(type);
				return (await configuredTaskAwaitable).Current;
			}
			catch (Exception exception)
			{
				Log.Error("FitnessConsole", $"Failed to get value {type}", exception);
			}
			return null;
		}

		private void SafelyAddBitFieldWriteItem(List<IBitFieldCommItem> comms, BitField bitField, object value)
		{
			if (base.WritableTypes == null || base.WritableTypes.Count == 0 || !bitField.ToFitnessValue().HasValue || !base.WritableTypes.Contains(bitField.ToFitnessValue().Value) || value == null)
			{
				Log.Trace("FitnessConsole", "IFitPro1Concole.SafelyAddBitFieldWriteItem not adding bitField and value to comms");
				return;
			}
			Log.Trace("FitnessConsole", $"List<IBitFieldCommItem>: {string.Join(',', comms)}\nBitField: {bitField}\nFitnessValue: {bitField.ToFitnessValue().Value}\nobject: {value}");
			comms.Add(new BitFieldCommItem(bitField, value));
		}

		public override void CalibrateIncline()
		{
			calibrationSub?.Dispose();
			calibrationSub = Observable.Interval(TimeSpan.FromSeconds(4.0)).Timeout(DateTimeOffset.Now + TimeSpan.FromMinutes(4.0)).SubscribeAsync((long _) => DoCalibrateIncline(), HandleInclineCalibrationException, StopCalibrationMonitoring);
		}

		private async Task DoCalibrateIncline()
		{
			CalibrateInclineState calibrateInclineState = await StartInclineCalibration();
			switch (calibrateInclineState)
			{
			case CalibrateInclineState.Done:
				if (inclineCalibrationInProgress)
				{
					StopCalibrationMonitoring();
					_whenCalibrationStatusChanged.OnNext(calibrateInclineState);
				}
				break;
			case CalibrateInclineState.Failed:
				_whenCalibrationStatusChanged.OnNext(calibrateInclineState);
				StopCalibrationMonitoring();
				break;
			case CalibrateInclineState.InProgress:
				inclineCalibrationInProgress = true;
				_whenCalibrationStatusChanged.OnNext(calibrateInclineState);
				break;
			}
			Log.Trace("FitnessConsole", "Incline calibration current state => `" + Enum.GetName(typeof(CalibrateInclineState), calibrateInclineState) + "`");
		}

		private async Task<CalibrateInclineState> StartInclineCalibration()
		{
			CommandCommItem<CmdStatus> commandCommItem = new CommandCommItem<CmdStatus>(new CalibrateCmd(Device.Grade));
			QueueManager.Enqueue(commandCommItem);
			return (await commandCommItem.Tcs.Task).ToCalibrateInclineState();
		}

		private void HandleInclineCalibrationException(Exception ex)
		{
			CalibrateInclineState value;
			if (ex is TimeoutException)
			{
				Log.Trace("FitnessConsole", "Incline calibration completed by timeout");
				value = CalibrateInclineState.Done;
			}
			else
			{
				Log.Trace("FitnessConsole", "Incline calibration failed with exception => `" + ex.Message + "`");
				value = CalibrateInclineState.Failed;
			}
			_whenCalibrationStatusChanged.OnNext(value);
		}

		private void StopCalibrationMonitoring()
		{
			calibrationSub?.Dispose();
			calibrationSub = null;
			Log.Trace("FitnessConsole", "Called stop incline calibration monitoring.");
		}

		public async Task ResetBrainboard()
		{
			CommandCommItem<NoCmd> commandCommItem = new CommandCommItem<NoCmd>(new ResetCmd());
			QueueManager.Enqueue(commandCommItem);
			await Shutdown();
		}

		private static void ResetBitFieldsForQueueManager(List<IBitFieldCommItem> collectionOfBitFieldCommItems)
		{
			foreach (IBitFieldCommItem collectionOfBitFieldCommItem in collectionOfBitFieldCommItems)
			{
				collectionOfBitFieldCommItem.Recycle();
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			base.Initialized = false;
			PeriodicDataEnabled = false;
			QueueManager?.Dispose();
			QueueManager = null;
			_adapter?.Dispose();
			_adapter = null;
			unlockedToIdleSub?.Dispose();
			unlockedToIdleSub = null;
			connectionStateChangeSub?.Dispose();
			connectionStateChangeSub = null;
			calibrationSub?.Dispose();
			calibrationSub = null;
			fitProCommTimeoutMonitoringService = null;
			tickSub?.Dispose();
			tickSub = null;
		}

		public async Task<byte[]> SendBytes(byte[] bytes, bool expectResponse, CommunicationDelayAndTimeout? delayAndTimeout)
		{
			FitProCommunication comm = new FitProCommunication(bytes)
			{
				AdditionalDelay = (delayAndTimeout?.Timeout ?? default(TimeSpan)),
				ReadDelay = (delayAndTimeout?.ReadDelay ?? default(TimeSpan))
			};
			IFitProCommunication fitProCommunication = await Adapter.Fetch(comm);
			if (expectResponse)
			{
				return fitProCommunication.FormattedBytes;
			}
			return null;
		}

		public void ToggleClubStatus()
		{
			bool isClub = base.ConsoleInfo.IsClub;
			base.LatestBasicInfo.SetValue(FitnessValue.IsClubUnit, !isClub);
			SystemDeviceInfo.IsMarketTypeClub = isClub;
		}

		private void OnTimerTick()
		{
			if (base.LatestBasicInfo.CurrentState == ConsoleState.WarmUp || base.LatestBasicInfo.CurrentState == ConsoleState.CoolDown)
			{
				estimatedTime--;
			}
			else
			{
				estimatedTime++;
			}
			Log.Debug("EquipmentConsole", $"Incrementing time to {estimatedTime}");
			base.LatestBasicInfo.BeginBatchUpdate();
			try
			{
				base.LatestBasicInfo.SetValue(FitnessValue.CurrentTime, estimatedTime);
				base.LatestBasicInfo.SetValue(GetTimeBitFieldFromState(), estimatedTime);
			}
			finally
			{
				base.LatestBasicInfo.EndBatchUpdate();
			}
		}

		private FitnessValue GetTimeBitFieldFromState()
		{
			return base.LatestBasicInfo.CurrentState switch
			{
				ConsoleState.WarmUp => FitnessValue.WarmupTimeout, 
				ConsoleState.CoolDown => FitnessValue.CoolDownTimeout, 
				_ => FitnessValue.RunningTime, 
			};
		}

		public void SetTachOverrideMode(bool overrideTach, int rpms, int kph, int timeBetweenTachs)
		{
			CommandCommItem<bool> commandCommItem = new CommandCommItem<bool>(new SetTachOverrideCmd(Device.Main, overrideTach, rpms, kph, timeBetweenTachs));
			QueueManager.Enqueue(commandCommItem);
		}

		public void SetStrokesOverrideMode(int strokesPerMinute)
		{
			CommandCommItem<bool> commandCommItem = new CommandCommItem<bool>(new SetStrokesPerMinuteCmd(Device.Main, strokesPerMinute));
			QueueManager.Enqueue(commandCommItem);
		}
	}
}
namespace Sindarin.FitPro1.Util
{
	public static class CmdStatusExtensions
	{
		internal static CalibrateInclineState ToCalibrateInclineState(this CmdStatus status)
		{
			return status switch
			{
				CmdStatus.Done => CalibrateInclineState.Done, 
				CmdStatus.InProgress => CalibrateInclineState.InProgress, 
				_ => CalibrateInclineState.Failed, 
			};
		}
	}
}
namespace Sindarin.FitPro1.Utils
{
	public static class ByteUtils
	{
		public static byte[] GetBytesFromString(string s)
		{
			string[] array = s.Split('-');
			byte[] array2 = new byte[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Convert.ToByte(array[i], 16);
			}
			return array2;
		}

		public static int GetIntFromBytes(byte[] bytes, int index, int length, bool reversed = true)
		{
			length = Math.Min(length, 4);
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				int num2 = bytes[index + i];
				if (reversed)
				{
					num += num2 << 8 * i;
					continue;
				}
				for (int j = 0; j < length - i - 1; j++)
				{
					num2 *= 256;
				}
				num += num2;
			}
			return num;
		}

		public static int GetSignedIntFromBytes(byte[] bytes, int index, int length, bool reversed = true)
		{
			int num = (int)Math.Pow(2.0, length * 8) / 2 - 1;
			int num2 = GetIntFromBytes(bytes, index, length, reversed);
			if (num2 > num)
			{
				num2 -= (int)Math.Pow(2.0, length * 8);
			}
			return num2;
		}

		public static void SetInt(int value, int index, int length, byte[] bytes)
		{
			length = Math.Min(length, 4);
			for (int i = 0; i < length; i++)
			{
				int num = (value >> (length - i - 1) * 8) % 256;
				bytes[index + i] = (byte)num;
			}
		}

		public static bool GetBit(this byte b, int pos)
		{
			return (b & (1 << pos)) != 0;
		}
	}
	public static class DeviceExtensions
	{
		public static bool IsBeltBasedMachine(this Device device)
		{
			if (device != Device.Treadmill)
			{
				return device == Device.InclineTrainer;
			}
			return true;
		}
	}
	internal static class FitnessValueExtensions
	{
		private static Dictionary<FitnessValue, BitField> ConversionCache;

		static FitnessValueExtensions()
		{
			ConversionCache = new Dictionary<FitnessValue, BitField>();
			((FitnessValue[])Enum.GetValues(typeof(FitnessValue))).DoForEach(delegate(FitnessValue x)
			{
				x.ToBitField();
			});
		}

		public static BitField? ToBitField(this FitnessValue value)
		{
			if (!ConversionCache.ContainsKey(value) && Enum.TryParse<BitField>(value.ToString(), out var result))
			{
				ConversionCache.Add(value, result);
			}
			if (ConversionCache.ContainsKey(value))
			{
				return ConversionCache[value];
			}
			return null;
		}
	}
	public class Timers
	{
		public static readonly AverageTimer ReadTimer = new AverageTimer("ReadTimer", 100);

		public static readonly AverageTimer SendValueTimer = new AverageTimer("SendValueTimer", 25);

		public static readonly AverageTimer UpdateFirmwareTimer = new AverageTimer("UpdateFirmwareTimer", 1);
	}
	public class AverageTimer
	{
		private const string Tag = "Benchmark";

		private readonly string label;

		private readonly int logFrequency;

		private readonly SemaphoreSlim ss = new SemaphoreSlim(1, 1);

		private DateTime? startTime;

		public Average Average { get; private set; }

		public AverageTimer(string label, int logFrequency)
		{
			this.label = label;
			this.logFrequency = logFrequency;
			Average = new Average();
		}

		public async Task StartAsync()
		{
			await ss.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			startTime = DateTime.UtcNow;
			ss.Release();
		}

		public void Start()
		{
			ss.Wait();
			startTime = DateTime.UtcNow;
			ss.Release();
		}

		public async Task AbortAsync()
		{
			await ss.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			startTime = null;
			ss.Release();
		}

		public async Task EndAsync(string addition = null)
		{
			if (!startTime.HasValue)
			{
				return;
			}
			await ss.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				EndTimer(addition);
			}
			finally
			{
				ss.Release();
			}
		}

		public void End(string addition = null)
		{
			if (!startTime.HasValue)
			{
				return;
			}
			ss.Wait();
			try
			{
				EndTimer(addition);
			}
			finally
			{
				ss.Release();
			}
		}

		private void EndTimer(string addition)
		{
			double totalMilliseconds = (DateTime.UtcNow - startTime.Value).TotalMilliseconds;
			Average.AddSample(totalMilliseconds);
			if (Average.NumberOfSamplings % logFrequency == 0)
			{
				Log(addition);
			}
			startTime = null;
		}

		public void Log(string addition = null)
		{
			iFit.Logger.Log.Trace("Benchmark", $"AverageTimer \"{label}\": {Average.CurrentAverage:0.00} millis over {Average.NumberOfSamplings} samples. {addition}");
		}
	}
}
namespace Sindarin.FitPro1.Core
{
	public static class FitPro1UsbConsoleFactory
	{
		public static IFitnessConsole Create(RetryingConnection connection, ISindarinEventHandler sindarinEventHandler, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
		{
			return new FitPro1Console(new FitProUsbConsoleCommunicationAdapter(connection, fatalityService), sindarinEventHandler, fatalityService, fitProBytesLogger);
		}
	}
}
namespace Sindarin.FitPro1.Equipment
{
	internal static class Defaults
	{
		public static List<BitField> StartupFields = new List<BitField>
		{
			BitField.SystemUnits,
			BitField.MaxKph,
			BitField.MinKph,
			BitField.MaxGrade,
			BitField.MinGrade,
			BitField.MaxWeight,
			BitField.IdleTimeout,
			BitField.PauseTimeout,
			BitField.CoolDownTimeout,
			BitField.WarmupTimeout,
			BitField.MaxResistanceLevel,
			BitField.Gear,
			BitField.WorkoutMode,
			BitField.ActivationLock,
			BitField.IsClubUnit,
			BitField.MotorTotalDistance,
			BitField.TotalTime
		};

		public static List<BitField> PeriodicFields = new List<BitField>
		{
			BitField.WorkoutMode,
			BitField.Grade,
			BitField.CurrentTime,
			BitField.CurrentDistance,
			BitField.CurrentCalories,
			BitField.Resistance,
			BitField.Gear,
			BitField.Rpm,
			BitField.LapTime,
			BitField.AverageGrade,
			BitField.Watts,
			BitField.AverageWatts,
			BitField.VerticalMeterNet,
			BitField.VerticalMeterGain,
			BitField.Pulse,
			BitField.WarmupTimeout,
			BitField.CoolDownTimeout,
			BitField.Kph,
			BitField.ActualKph,
			BitField.StartRequested,
			BitField.FanState,
			BitField.Volume,
			BitField.PausedTime,
			BitField.RunningTime,
			BitField.Strokes,
			BitField.StrokesPerMin,
			BitField.FiveHundredSplit,
			BitField.AvgFiveHundredSplit,
			BitField.GoalTime,
			BitField.KeyObject,
			BitField.IsReadyToDisconnect
		};
	}
}
namespace Sindarin.FitPro1.Equipment.Communication
{
	internal class EmptyCommsException : Exception
	{
		private EmptyCommsException(string message)
			: base(message)
		{
		}

		private EmptyCommsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public static EmptyCommsException Create(List<ICommItem> queue, IEnumerable<IBitFieldCommItem> bitFieldComms, bool sendingWriteFields, List<IBitFieldCommItem> targetComms, List<IBitFieldCommItem> commsThatFit, List<IBitFieldCommItem> readComms, List<IBitFieldCommItem> writeComms)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "queue", queue?.Count));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "bitFieldComms", bitFieldComms?.Count()));
				stringBuilder.AppendLine(string.Format("{0}: {1}", "sendingWriteFields", sendingWriteFields));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "targetComms", targetComms?.Count));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "commsThatFit", commsThatFit?.Count));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "readComms", readComms?.Count));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "writeComms", writeComms?.Count));
				return new EmptyCommsException(stringBuilder.ToString());
			}
			catch (Exception innerException)
			{
				return new EmptyCommsException("Failed to generate EmptyCommsException message.", innerException);
			}
		}
	}
	internal class InvalidPacketSizeException : Exception
	{
		private InvalidPacketSizeException(string message)
			: base(message)
		{
		}

		private InvalidPacketSizeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public static InvalidPacketSizeException Create(int sections, int maxSize, int responseSize, int itemSize, List<ICommItem> source, List<IBitFieldCommItem> comms, IBitFieldCommItem failedComm)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine(string.Format("{0}: {1}", "sections", sections));
				stringBuilder.AppendLine(string.Format("{0}: {1}", "maxSize", maxSize));
				stringBuilder.AppendLine(string.Format("{0}: {1}", "responseSize", responseSize));
				stringBuilder.AppendLine(string.Format("{0}: {1}", "itemSize", itemSize));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "source", source?.Count));
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "comms", comms?.Count));
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("failedComm: " + failedComm.ToString());
				stringBuilder.AppendLine();
				List<IBitFieldCommItem> list = comms.SkipWhile((IBitFieldCommItem x) => x == failedComm).ToList();
				stringBuilder.AppendLine(string.Format("{0}.Count: {1}", "nextComms", list?.Count));
				foreach (IBitFieldCommItem item in list)
				{
					stringBuilder.AppendLine(item.ToString());
				}
				return new InvalidPacketSizeException(stringBuilder.ToString());
			}
			catch (Exception innerException)
			{
				return new InvalidPacketSizeException("Failed to generate InvalidPacketSizeException message.", innerException);
			}
		}
	}
	internal interface IQueueManager : IDisposable
	{
		IFitnessValueUpdater ValueUpdater { get; set; }

		DeviceInfo PrimaryDevice { get; set; }

		void Enqueue(params ICommItem[] items);

		void Enqueue(IEnumerable<ICommItem> items);

		Task Shutdown();

		void ClearQueue();
	}
	internal class QueueManager : IQueueManager, IDisposable
	{
		public const string LogTag = "FitPro";

		private const int MaxPacketResponseSize = 58;

		private const int MaxMismatchCountThreshold = 20;

		public static readonly TimeSpan ShutdownDelayTimeSpan = TimeSpan.FromMilliseconds(200.0);

		private readonly DynamicDelay delay = new DynamicDelay(10, 150);

		public static readonly List<Command> AlwaysApprovedCommands = new List<Command>
		{
			Command.SystemInfo,
			Command.DeviceInfo,
			Command.SupportedDevices,
			Command.SupportedCommands,
			Command.ReadWriteData,
			Command.VerifySecurity,
			Command.Calibrate
		};

		private readonly List<Tuple<byte[], DateTime>> unmatchedResponses = new List<Tuple<byte[], DateTime>>();

		private readonly List<ICommItem> queue = new List<ICommItem>();

		private readonly List<ICommItem> pendingResponse = new List<ICommItem>();

		private readonly SemaphoreSlim ioSemaphore = new SemaphoreSlim(1, 1);

		public readonly Subject<long> failedResponses = new Subject<long>();

		private long previousMismatchCount;

		private long currentMismatchCount;

		private readonly IDisposable mismatchSampleSub;

		private readonly IQueueManagerAdapter adapter;

		private readonly ISindarinEventHandler sindarinEventHandler;

		private readonly IFatalityService fatalityService;

		private readonly IFitProBytesLogger fitProBytesLogger;

		private bool enabled = true;

		private bool shuttingDown;

		private int retryCount;

		private int count;

		public DeviceInfo PrimaryDevice { get; set; }

		private Device Device => PrimaryDevice?.Device ?? Device.Main;

		public IFitnessValueUpdater ValueUpdater { get; set; }

		public QueueManager(IQueueManagerAdapter adapter, IFitnessValueUpdater basicInfo, ISindarinEventHandler sindarinEventHandler, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
		{
			this.adapter = adapter;
			ValueUpdater = basicInfo;
			this.sindarinEventHandler = sindarinEventHandler;
			this.fatalityService = fatalityService;
			this.fitProBytesLogger = fitProBytesLogger;
			mismatchSampleSub = failedResponses.Sample(TimeSpan.FromSeconds(10.0)).Subscribe(HandleMismatchCount);
		}

		public void Dispose()
		{
			enabled = false;
			ClearQueue();
		}

		public void ClearQueue()
		{
			lock (queue)
			{
				lock (pendingResponse)
				{
					queue.Clear();
					pendingResponse.Clear();
				}
			}
		}

		public void Enqueue(IEnumerable<ICommItem> items)
		{
			if (shuttingDown)
			{
				return;
			}
			lock (queue)
			{
				IEnumerable<ICommItem> enumerable = items?.Where((ICommItem x) => ValidateAndArrangeQueue(x, queue, PrimaryDevice));
				if (enumerable == null || !enumerable.Any())
				{
					return;
				}
				queue.AddRange(enumerable);
			}
			SendBatch();
		}

		public void Enqueue(params ICommItem[] items)
		{
			Enqueue((IEnumerable<ICommItem>)items);
		}

		public async Task Shutdown()
		{
			Log.Trace("FitPro", "Shutting down queue manager.");
			shuttingDown = true;
			while (true)
			{
				await Task.Delay(ShutdownDelayTimeSpan).ConfigureAwait(continueOnCapturedContext: false);
				lock (queue)
				{
					if (!queue.Any())
					{
						Dispose();
						break;
					}
				}
			}
		}

		public static int CalculateExpectedResponseLength(ReadWriteDataCmd cmd)
		{
			int num = 5;
			List<IBitFieldCommItem> readComms = cmd.ReadComms;
			if (readComms != null)
			{
				foreach (IBitFieldCommItem item in readComms)
				{
					num += item.BitField.GetConverter().Size;
				}
			}
			return num;
		}

		private async Task SendBatch()
		{
			ICommandCommItem cmd = null;
			try
			{
				await ioSemaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
				lock (queue)
				{
					lock (pendingResponse)
					{
						if (!queue.Any() || pendingResponse.Any() || !enabled)
						{
							return;
						}
					}
				}
				CreateRequest();
				lock (pendingResponse)
				{
					cmd = pendingResponse.FirstOrDefault((ICommItem x) => x is ICommandCommItem) as ICommandCommItem;
					if (cmd == null)
					{
						return;
					}
				}
				byte[] request = cmd.GetRequestBytes();
				double num = ((retryCount == 0) ? 0.0 : (Math.Pow(2.0, retryCount) * 500.0));
				CommunicationDelayAndTimeout value = new CommunicationDelayAndTimeout(TimeSpan.FromMilliseconds(cmd.UntypedCommand.ReadDelayMs), TimeSpan.FromMilliseconds((double)cmd.UntypedCommand.ResponseTimeoutMs + num));
				byte[] response = await adapter.SendBytes(request, cmd.UntypedCommand.ExpectResponse, value).ConfigureAwait(continueOnCapturedContext: false);
				bool flag = HandleBatchResponse(response, request, cmd);
				byte[] array = null;
				if (!flag)
				{
					failedResponses.OnNext(++currentMismatchCount);
					Log.Trace("FitPro", "Failed to match response: " + ((response == null) ? "null" : BitConverter.ToString(response)));
					delay.IncreaseIfBelowMaximum(count);
					lock (unmatchedResponses)
					{
						foreach (Tuple<byte[], DateTime> item in unmatchedResponses.Where(delegate(Tuple<byte[], DateTime> tuple)
						{
							if (tuple != null)
							{
								byte[] array2 = response;
								if (array2 == null)
								{
									return false;
								}
								return !Enumerable.SequenceEqual(array2, tuple.Item1);
							}
							return false;
						}).ToList())
						{
							Log.Trace("FitPro", "Trying to match using response " + BitConverter.ToString(item.Item1));
							flag = HandleBatchResponse(item.Item1, request, cmd, isCleanedResponse: true);
							if (flag)
							{
								array = item.Item1;
								break;
							}
						}
					}
				}
				if (flag)
				{
					if (array != null)
					{
						Log.Trace("FitPro", "WE WOULD MISMATCH HERE. Received " + BitConverter.ToString(response) + " but used " + BitConverter.ToString(array));
					}
					delay.DecreaseIfAboveMinimum(count);
					await Task.Delay(delay.CurrentDelay).ConfigureAwait(continueOnCapturedContext: false);
					retryCount = 0;
					fatalityService.RecoverIfNeeded(typeof(EquipmentException), "SendBatch.QueueManager is communicating correctly");
				}
				else if (retryCount >= 4)
				{
					retryCount = 0;
					fatalityService.ReportFatalEvent(new EquipmentException("Command failed too many retries"), null, isPermanent: false, null, analytics: true);
				}
				else
				{
					retryCount++;
					lock (queue)
					{
						queue.Insert(0, cmd);
					}
				}
			}
			catch (Exception ex)
			{
				lock (queue)
				{
					if (!shuttingDown)
					{
						lock (pendingResponse)
						{
							queue.AddRange(pendingResponse);
						}
						TaskContinueWithException.LogThreadException(ex);
					}
					else
					{
						queue.Clear();
					}
				}
			}
			finally
			{
				if (enabled)
				{
					lock (pendingResponse)
					{
						pendingResponse.Remove(cmd);
					}
				}
				ioSemaphore.Release();
				if (enabled)
				{
					count++;
					if (count % 25 == 0)
					{
						Log.Trace("FitPro", $"Commands sent: {count}");
					}
					lock (queue)
					{
						if (queue.Any())
						{
							SendBatch();
						}
					}
				}
			}
		}

		private void HandleMismatchCount(long mismatchCount)
		{
			long num = mismatchCount - previousMismatchCount;
			previousMismatchCount = mismatchCount;
			if (num > 20)
			{
				bool isPermanent = (adapter as FitPro1Console)?.ConsoleInfo?.MachineType.IsBeltBasedMachine() ?? true;
				fatalityService.ReportFatalEvent(new EquipmentException("Communication error. Please power cycle your machine."), "Mismatches exceed threshold", isPermanent, "HandleMismatchCount", analytics: true);
			}
		}

		public bool HandleBatchResponse(byte[] response, byte[] request, ICommandCommItem cmd, bool isCleanedResponse = false)
		{
			fitProBytesLogger?.LogBytes(request, PacketType.Request);
			fitProBytesLogger?.LogBytes(response, PacketType.Response);
			bool flag = true;
			ReadWriteDataCmd readWriteDataCmd = cmd.UntypedCommand as ReadWriteDataCmd;
			if (readWriteDataCmd != null)
			{
				int num = CalculateExpectedResponseLength(readWriteDataCmd);
				response = (isCleanedResponse ? response : EquipmentUtil.CleanResponse(response, readWriteDataCmd.ReadComms));
				CleanOldResponses(response);
				flag = response != null && response.Length == num;
				if (!flag)
				{
					Log.Trace("FitPro", $"response length [{response?.Length}] doesn't match expected [{num}], will retry");
					lock (unmatchedResponses)
					{
						unmatchedResponses.Add(new Tuple<byte[], DateTime>(response, DateTime.UtcNow));
					}
				}
			}
			string text = ((request == null) ? "(null)" : BitConverter.ToString(request));
			string text2 = ((response == null) ? "(null)" : BitConverter.ToString(response));
			if (!flag || !EquipmentUtil.IsValidCommandResponse(response, cmd.UntypedCommand.Id, cmd.UntypedCommand.ExpectResponse))
			{
				Log.Trace("FitPro", $"Cmd failed, retry #: {retryCount} reqBytes: {text} responseBytes: {text2}");
				return false;
			}
			if (cmd.UntypedCommand.ExpectResponse)
			{
				cmd.SetResponseBytes(response);
				if (readWriteDataCmd != null)
				{
					LogFitProEvent(readWriteDataCmd, text, text2);
				}
			}
			retryCount = 0;
			fatalityService.RecoverIfNeeded(typeof(EquipmentException), "SendBatch.QueueManager is communicating correctly");
			return true;
		}

		private void LogFitProEvent(ReadWriteDataCmd readWriteCmd, string reqBytesString, string resBytesString)
		{
			bool flag = default(bool);
			int num;
			if (readWriteCmd.UpdatedBitFields.TryGetValue(BitField.StartRequested, out var value))
			{
				if (value is bool)
				{
					flag = (bool)value;
					num = 1;
				}
				else
				{
					num = 0;
				}
			}
			else
			{
				num = 0;
			}
			if (((uint)num & (flag ? 1u : 0u)) != 0)
			{
				sindarinEventHandler.LogSindarinEvent(SindarinEvent.StartRequested, new Dictionary<string, object>
				{
					{ "request", reqBytesString },
					{ "response", resBytesString }
				});
			}
		}

		private void CleanOldResponses(byte[] response = null)
		{
			DateTime now = DateTime.UtcNow;
			lock (unmatchedResponses)
			{
				unmatchedResponses.RemoveAll(delegate(Tuple<byte[], DateTime> tuple)
				{
					byte[] array = response;
					return (array != null && Enumerable.SequenceEqual(array, tuple.Item1)) || now - tuple.Item2 >= TimeSpan.FromSeconds(5.0);
				});
			}
		}

		private void CreateRequest()
		{
			lock (queue)
			{
				lock (pendingResponse)
				{
					ICommItem commItem = queue.FirstOrDefault((ICommItem x) => x?.IsCmd ?? false);
					if (commItem != null)
					{
						queue.Remove(commItem);
						pendingResponse.Add(commItem);
					}
					else
					{
						CreateBitFieldComm();
					}
				}
			}
		}

		private void CreateBitFieldComm()
		{
			List<IBitFieldCommItem> list = null;
			lock (queue)
			{
				lock (pendingResponse)
				{
					try
					{
						IEnumerable<IBitFieldCommItem> enumerable = queue.OfType<IBitFieldCommItem>();
						bool flag = enumerable.Any((IBitFieldCommItem x) => x.IsWrite);
						List<IBitFieldCommItem> list2 = (flag ? enumerable.Where((IBitFieldCommItem x) => x.IsWrite) : enumerable).ToList();
						list = SelectAndRemoveCommsThatFitPacketSize(queue, list2);
						List<IBitFieldCommItem> list3 = (flag ? list : null);
						List<IBitFieldCommItem> list4 = (flag ? null : list);
						if (list4.IsNullOrEmpty() && list3.IsNullOrEmpty())
						{
							pendingResponse.Clear();
							queue.Clear();
							throw EmptyCommsException.Create(queue, enumerable, flag, list2, list, list3, list4);
						}
						CommandCommItem<bool> item = new CommandCommItem<bool>(new ReadWriteDataCmd(Device, ValueUpdater, list4, list3));
						pendingResponse.Insert(0, item);
					}
					catch (Exception)
					{
						if (list != null && list.Any())
						{
							queue.AddRange(list);
						}
						throw;
					}
				}
			}
		}

		public static List<IBitFieldCommItem> SelectAndRemoveCommsThatFitPacketSize(List<ICommItem> source, List<IBitFieldCommItem> comms)
		{
			List<IBitFieldCommItem> list = new List<IBitFieldCommItem>();
			try
			{
				if (!comms.Any())
				{
					return list;
				}
				int num = 0;
				int num2 = (int)comms.MaxBy((IBitFieldCommItem x) => x.BitField).FirstOrDefault().BitField / 8;
				if (comms.Any())
				{
					num2++;
				}
				int num3 = 58 - num2;
				foreach (IBitFieldCommItem comm in comms)
				{
					int size = comm.BitField.GetConverter().Size;
					if (size + num < num3)
					{
						num += size;
						source.Remove(comm);
						list.Add(comm);
						continue;
					}
					if (!list.Any())
					{
						throw InvalidPacketSizeException.Create(num2, num3, num, size, source, comms, comm);
					}
					break;
				}
			}
			catch (Exception ex)
			{
				TaskContinueWithException.LogThreadException(ex);
			}
			return list;
		}

		public static bool ValidateAndArrangeQueue(ICommItem comm, List<ICommItem> source, DeviceInfo primary)
		{
			try
			{
				if (comm is ICommandCommItem commandCommItem)
				{
					IFitProCommand cmd = commandCommItem.UntypedCommand;
					if (cmd.Device == Device.Main || AlwaysApprovedCommands.Any((Command x) => x == cmd.Id))
					{
						return true;
					}
					Device device = primary?.Device ?? Device.Main;
					return ((cmd.Device == device) ? primary : primary?.SubDeviceInfos.FirstOrDefault((DeviceInfo x) => x.Device == cmd.Device))?.SupportedCommands.Contains(cmd.Id) ?? false;
				}
				IBitFieldCommItem bitComm = comm as IBitFieldCommItem;
				if (bitComm != null)
				{
					if (!primary.SupportedBitFields.Contains(bitComm.BitField))
					{
						bitComm.SetResponseBytes(null);
						return false;
					}
					if (!bitComm.IsWrite && source.OfType<IBitFieldCommItem>().Any((IBitFieldCommItem x) => !x.IsWrite && x.BitField == bitComm.BitField))
					{
						bitComm.SetResponseBytes(null);
						return false;
					}
					IEnumerable<IBitFieldCommItem> enumerable = from x in source.OfType<IBitFieldCommItem>()
						where x.BitField == bitComm.BitField && x.IsWrite
						select x;
					if (bitComm.IsWrite && enumerable.Any())
					{
						enumerable.ForEach(delegate(IBitFieldCommItem x)
						{
							x.SetResponseBytes(null);
						});
						source.RemoveAll(((IEnumerable<ICommItem>)enumerable).Contains<ICommItem>);
						return true;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				comm.SetResponseBytes(null);
				TaskContinueWithException.LogThreadException(ex);
			}
			Log.Trace("FitPro", $"ValidateAndArrangeQueue filtering unrecognized comm {comm}");
			return false;
		}
	}
}
namespace Sindarin.FitPro1.DataObjects
{
	internal class BasicEquipmentValues
	{
		public ActivationLockState? ActivationLockState { get; set; }

		public int? Gear { get; set; }

		public int? GearOption { get; set; }

		public bool? IdleModeLockout { get; set; }

		public double? Incline { get; set; }

		public double? Kph { get; set; }

		public int? MaxGear { get; set; }

		public bool? RequireStartRequested { get; set; }

		public double? Resistance { get; set; }

		public bool? SleepTimerState { get; set; }

		public WorkoutMode? State { get; set; }

		public int? StrapPulse { get; set; }

		public bool UserInitiated { get; set; }

		public int? VolumePercentage { get; set; }

		public int? GoalTime { get; set; }

		public int? GoalWatts { get; set; }

		public bool? ToggleConstantWattsMode { get; set; }
	}
	public enum Device
	{
		None = 0,
		MultipleDevices = 1,
		Main = 2,
		Portal = 3,
		Treadmill = 4,
		InclineTrainer = 5,
		Elliptical = 6,
		FitnessBike = 7,
		SpinBike = 8,
		VerticalElliptical = 9,
		Vibration = 10,
		StairClimber = 11,
		Skier = 12,
		FitnessWeightMachine = 13,
		DoubleStackWeightMachine = 14,
		DumbBellWeightHolder = 15,
		SingleJoinPlateWeightMachine = 16,
		DoubleJoinPlateWeightMachine = 17,
		FreeOlympicWeightMachine = 18,
		FreeStrider = 19,
		Rower = 20,
		AudioControl = 48,
		BikePower = 49,
		BikeSpeedAndCandence = 50,
		BloodPressure = 51,
		Environment = 52,
		FitnessEquipmentDevice = 53,
		Geocache = 54,
		HeartRateMonitor = 55,
		LightElectricVehicle = 56,
		MultiSportSpeedDistance = 57,
		StrideBasedSpeedDistance = 40,
		WeightScale = 41,
		Audio = 64,
		Speed = 65,
		Grade = 66,
		Watts = 67,
		Torque = 68,
		Resistance = 69,
		Pulse = 70,
		KeyPress = 71,
		BikeGear = 72,
		Stride = 73,
		Fan = 74,
		Safety = 75,
		Mode = 76,
		Distance = 77,
		UserTime = 78,
		UserData = 79,
		WorkoutControl = 81,
		Reps = 83,
		BurnRate = 84,
		Equipmentless = 85,
		Mirror = 86
	}
	internal class DeviceInfo : IDisposable
	{
		public Device Device { get; set; }

		public int SoftwareVersion { get; set; }

		public int HardwareVersion { get; set; }

		public int SerialNumber { get; set; }

		public Manufacturer Manufacturer { get; set; }

		public int Sections { get; set; }

		public List<BitField> SupportedBitFields { get; set; } = new List<BitField>();

		public List<Device> SubDevices { get; set; } = new List<Device>();

		public List<DeviceInfo> SubDeviceInfos { get; set; } = new List<DeviceInfo>();

		public HashSet<Command> SupportedCommands { get; set; } = new HashSet<Command>();

		public void Dispose()
		{
			SubDevices.Clear();
			SupportedCommands.Clear();
		}
	}
	public class SecurityInfo
	{
		public int UnlockedKey { get; set; }

		public bool IsUnlocked { get; set; }
	}
	public class SystemDeviceInfo
	{
		public enum SystemConfiguration
		{
			Slave,
			Master,
			MultiMaster,
			SingleMaster,
			PortalToSlave,
			PortalToMaster
		}

		public enum SystemLanguage
		{
			None,
			German,
			English,
			Spanish,
			French,
			Italian,
			Dutch,
			Russian,
			Portuguese,
			Chinese,
			Japanese
		}

		public SystemConfiguration Configuration { get; set; }

		public int ConfigSize { get; set; }

		public int Model { get; set; }

		public int PartNumber { get; set; }

		public double CpuUse { get; set; }

		public int NumberOfTasks { get; set; }

		public int IntervalTime { get; set; }

		public int CpuFrequency { get; set; }

		public int PollingFrequency { get; set; }

		public bool IsUnitMetricDefault { get; set; }

		public bool IsMarketTypeClub { get; set; }

		public int FitProConfigLibVersion { get; set; }

		public SystemLanguage DefaultLanguage { get; set; }

		public string McuName { get; set; } = "";

		public string ConsoleName { get; set; } = "";
	}
	public class VersionInfo
	{
		public int MasterLibraryVersion { get; set; }

		public int MasterLibraryBuild { get; set; }

		public int ConfigToolVersion { get; set; }

		public int BleSdkVersion { get; set; }

		public string IconBleLibVersion { get; set; }
	}
	internal enum WorkoutMode
	{
		Unknown = 0,
		Idle = 1,
		Running = 2,
		Pause = 3,
		Results = 4,
		Debug = 5,
		Log = 6,
		Maintenance = 7,
		Dmk = 8,
		Demo = 9,
		WarmUp = 10,
		CoolDown = 11,
		Sleep = 12,
		Resume = 13,
		Locked = 14,
		PauseOverride = 20
	}
	internal static class WorkoutModeExtensions
	{
		internal static ConsoleState ToConsoleState(this WorkoutMode mode)
		{
			return mode switch
			{
				WorkoutMode.CoolDown => ConsoleState.CoolDown, 
				WorkoutMode.WarmUp => ConsoleState.WarmUp, 
				WorkoutMode.Debug => ConsoleState.Unknown, 
				WorkoutMode.Demo => ConsoleState.Unknown, 
				WorkoutMode.Dmk => ConsoleState.SafetyKeyRemoved, 
				WorkoutMode.Idle => ConsoleState.Idle, 
				WorkoutMode.Locked => ConsoleState.Locked, 
				WorkoutMode.Unknown => ConsoleState.Unknown, 
				WorkoutMode.Log => ConsoleState.Unknown, 
				WorkoutMode.Maintenance => ConsoleState.Unknown, 
				WorkoutMode.Pause => ConsoleState.Paused, 
				WorkoutMode.PauseOverride => ConsoleState.PauseOverride, 
				WorkoutMode.Results => ConsoleState.WorkoutResults, 
				WorkoutMode.Resume => ConsoleState.Resume, 
				WorkoutMode.Running => ConsoleState.Workout, 
				WorkoutMode.Sleep => ConsoleState.Unknown, 
				_ => ConsoleState.Unknown, 
			};
		}

		internal static WorkoutMode ToWorkoutMode(this ConsoleState state)
		{
			return state switch
			{
				ConsoleState.Unknown => WorkoutMode.Unknown, 
				ConsoleState.Idle => WorkoutMode.Idle, 
				ConsoleState.Workout => WorkoutMode.Running, 
				ConsoleState.Paused => WorkoutMode.Pause, 
				ConsoleState.WorkoutResults => WorkoutMode.Results, 
				ConsoleState.SafetyKeyRemoved => WorkoutMode.Dmk, 
				ConsoleState.WarmUp => WorkoutMode.WarmUp, 
				ConsoleState.CoolDown => WorkoutMode.CoolDown, 
				ConsoleState.Resume => WorkoutMode.Resume, 
				ConsoleState.PauseOverride => WorkoutMode.PauseOverride, 
				ConsoleState.Locked => WorkoutMode.Locked, 
				ConsoleState.Demo => WorkoutMode.Demo, 
				ConsoleState.Sleep => WorkoutMode.Sleep, 
				_ => WorkoutMode.Unknown, 
			};
		}
	}
}
namespace Sindarin.FitPro1.Console
{
	internal class ConsoleInfo : ConsoleInfoBase
	{
		private readonly SystemDeviceInfo systemDeviceInfo;

		private readonly DeviceInfo primaryDeviceInfo;

		private readonly VersionInfo versionInfo;

		public override int ModelNumber => systemDeviceInfo.Model;

		public override int PartNumber => systemDeviceInfo.PartNumber;

		public override bool IsSystemMarketTypeClub => systemDeviceInfo.IsMarketTypeClub;

		public override int SoftwareVersion => primaryDeviceInfo.SoftwareVersion;

		public override int HardwareVersion => primaryDeviceInfo.HardwareVersion;

		public override string FirmwareVersion => $"{MasterLibraryVersion}.{MasterLibraryBuild}";

		public override int SerialNumber => primaryDeviceInfo.SerialNumber;

		public override Manufacturer ManufacturerId => primaryDeviceInfo.Manufacturer;

		public override ConsoleType MachineType => DeviceToConsoleType();

		public override string Name => systemDeviceInfo.ConsoleName;

		public override string BrainboardSerialNumber { get; }

		public override int MasterLibraryVersion => versionInfo.MasterLibraryVersion;

		public override int MasterLibraryBuild => versionInfo.MasterLibraryBuild;

		public override bool CanSetKph
		{
			get
			{
				if ((!primaryDeviceInfo.SupportedBitFields.Contains(BitField.Rpm) || !primaryDeviceInfo.SupportedBitFields.Contains(BitField.Gear)) && primaryDeviceInfo.SupportedBitFields.Contains(BitField.Kph))
				{
					return base.MaxKph > base.MinKph;
				}
				return false;
			}
		}

		public override bool CanSetIncline
		{
			get
			{
				if (primaryDeviceInfo.SupportedBitFields.Contains(BitField.Grade))
				{
					return base.MaxIncline > base.MinIncline;
				}
				return false;
			}
		}

		public override bool CanSetResistance
		{
			get
			{
				if (primaryDeviceInfo.SupportedBitFields.Contains(BitField.Resistance))
				{
					return base.Console.LatestBasicInfo.MaxResistanceLevel >= 2.0;
				}
				return false;
			}
		}

		public override bool CanSetActivationLock => primaryDeviceInfo.SupportedBitFields.Contains(BitField.ActivationLock);

		public override bool CanSetGear
		{
			get
			{
				if (primaryDeviceInfo.SupportedBitFields.Contains(BitField.Gear))
				{
					return (base.Console.LatestBasicInfo.Gear?.MaxGear ?? 0) > 1;
				}
				return false;
			}
		}

		public override bool SupportsVerticalGain
		{
			get
			{
				if (primaryDeviceInfo.SupportedBitFields.Contains(BitField.VerticalMeterGain))
				{
					return primaryDeviceInfo.SupportedBitFields.Contains(BitField.Grade);
				}
				return false;
			}
		}

		public override bool SupportsVerticalNet
		{
			get
			{
				if (primaryDeviceInfo.SupportedBitFields.Contains(BitField.VerticalMeterNet))
				{
					return primaryDeviceInfo.SupportedBitFields.Contains(BitField.Grade);
				}
				return false;
			}
		}

		public override bool SupportsStartRequested => primaryDeviceInfo.SupportedBitFields.Contains(BitField.StartRequested);

		public override bool SupportsRequireStartRequested => primaryDeviceInfo.SupportedBitFields.Contains(BitField.RequireStartRequested);

		public override bool SupportsKeyPressObserved => primaryDeviceInfo.SupportedBitFields.Contains(BitField.KeyObject);

		public override bool SupportsPulse => primaryDeviceInfo.SupportedBitFields.Contains(BitField.Pulse);

		public override bool SupportsConstantWatts => primaryDeviceInfo.SupportedBitFields.Contains(BitField.IsConstantWattsMode);

		public ConsoleInfo(IFitnessConsole console, DeviceInfo primaryDeviceInfo, SystemDeviceInfo systemDeviceInfo, VersionInfo versionInfo, string serialNumber)
			: base(console)
		{
			this.primaryDeviceInfo = primaryDeviceInfo;
			this.systemDeviceInfo = systemDeviceInfo;
			this.versionInfo = versionInfo;
			BrainboardSerialNumber = ConvertBrainboardSerialNumberFromHex(serialNumber);
		}

		private string ConvertBrainboardSerialNumberFromHex(string serialNumber)
		{
			if (serialNumber == null)
			{
				return "N/A";
			}
			string[] array = serialNumber.Split('-');
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string value = char.ConvertFromUtf32(Convert.ToInt32(array2[i], 16));
					stringBuilder.Append(value);
				}
				return stringBuilder.ToString();
			}
			catch (Exception exception)
			{
				Log.Error("FitPro", "Error converting Brainboard serial number from hex", exception);
				return "N/A";
			}
		}

		public ConsoleType DeviceToConsoleType()
		{
			return primaryDeviceInfo.Device switch
			{
				Device.Treadmill => ConsoleType.Treadmill, 
				Device.InclineTrainer => ConsoleType.InclineTrainer, 
				Device.Elliptical => ConsoleType.Elliptical, 
				Device.FitnessBike => ConsoleType.Bike, 
				Device.SpinBike => ConsoleType.SpinBike, 
				Device.VerticalElliptical => ConsoleType.VerticalElliptical, 
				Device.FreeStrider => ConsoleType.FreeStrider, 
				Device.Rower => ConsoleType.Rower, 
				Device.Mirror => ConsoleType.Mirror, 
				_ => ConsoleType.None, 
			};
		}
	}
	public class ConsoleInfoFromJson : IConsoleInfo
	{
		public int ModelNumber { get; set; }

		public int PartNumber { get; set; }

		public bool IsSystemMarketTypeClub { get; set; }

		public int SoftwareVersion { get; set; }

		public int HardwareVersion { get; set; }

		public string FirmwareVersion { get; set; }

		public int SerialNumber { get; set; }

		public Manufacturer ManufacturerId { get; set; }

		public ConsoleType MachineType { get; set; }

		public string Name { get; set; }

		public string BrainboardSerialNumber { get; set; }

		public int MasterLibraryVersion { get; set; }

		public int MasterLibraryBuild { get; set; }

		public bool SystemUnits { get; set; }

		public double MaxKph { get; set; }

		public double MinKph { get; set; }

		public double MaxIncline { get; set; }

		public double MinIncline { get; set; }

		public int GearOption { get; set; }

		public int MinGear { get; set; }

		public int MaxGear { get; set; }

		public double MaxResistanceLevel { get; set; }

		public double MaxWeight { get; set; }

		public bool CanSetKph { get; set; }

		public bool CanSetActivationLock { get; set; }

		public bool CanSetIncline { get; set; }

		public bool CanSetResistance { get; set; }

		public bool CanSetGear { get; set; }

		public bool SupportsVerticalGain { get; set; }

		public bool SupportsVerticalNet { get; set; }

		public bool SupportsStartRequested { get; set; }

		public bool SupportsRequireStartRequested { get; set; }

		public bool SupportsKeyPressObserved { get; set; }

		public bool SupportsPulse { get; set; }

		public double TotalTime { get; set; }

		public int WarmUpTimeoutSeconds { get; set; }

		public int CoolDownTimeoutSeconds { get; set; }

		public int PauseTimeoutSeconds { get; set; }

		public int IdleTimeoutSeconds { get; set; }

		public double TotalMeters { get; set; }

		public bool IsClubUnit { get; set; }

		public bool IsClub { get; set; }

		public bool SupportsConstantWatts { get; set; }

		public double Weight { get; set; }

		[JsonIgnore]
		public double MinResistanceLevel => 1.0;

		public static ConsoleInfoFromJson ConsoleInfoToConsoleInfoJson(IConsoleInfo console)
		{
			return new ConsoleInfoFromJson
			{
				ModelNumber = console.ModelNumber,
				PartNumber = console.PartNumber,
				IsSystemMarketTypeClub = console.IsSystemMarketTypeClub,
				SoftwareVersion = console.SoftwareVersion,
				HardwareVersion = console.HardwareVersion,
				FirmwareVersion = console.FirmwareVersion,
				SerialNumber = console.SerialNumber,
				ManufacturerId = console.ManufacturerId,
				MachineType = console.MachineType,
				Name = console.Name,
				BrainboardSerialNumber = console.BrainboardSerialNumber,
				MasterLibraryVersion = console.MasterLibraryVersion,
				MasterLibraryBuild = console.MasterLibraryBuild,
				SystemUnits = console.SystemUnits,
				MaxKph = console.MaxKph,
				MinKph = console.MinKph,
				MaxIncline = console.MaxIncline,
				MinIncline = console.MinIncline,
				GearOption = console.GearOption,
				MinGear = console.MinGear,
				MaxGear = console.MaxGear,
				MaxResistanceLevel = console.MaxResistanceLevel,
				MaxWeight = console.MaxWeight,
				CanSetKph = console.CanSetKph,
				CanSetActivationLock = console.CanSetActivationLock,
				CanSetIncline = console.CanSetIncline,
				SupportsVerticalGain = console.SupportsVerticalGain,
				SupportsVerticalNet = console.SupportsVerticalNet,
				SupportsStartRequested = console.SupportsStartRequested,
				SupportsRequireStartRequested = console.SupportsRequireStartRequested,
				SupportsKeyPressObserved = console.SupportsKeyPressObserved,
				SupportsPulse = console.SupportsPulse,
				CanSetResistance = console.CanSetResistance,
				CanSetGear = console.CanSetGear,
				TotalTime = console.TotalTime,
				WarmUpTimeoutSeconds = console.WarmUpTimeoutSeconds,
				CoolDownTimeoutSeconds = console.CoolDownTimeoutSeconds,
				PauseTimeoutSeconds = console.PauseTimeoutSeconds,
				IdleTimeoutSeconds = console.IdleTimeoutSeconds,
				TotalMeters = console.TotalMeters,
				IsClubUnit = console.IsClubUnit,
				IsClub = console.IsClub,
				SupportsConstantWatts = console.SupportsConstantWatts,
				Weight = console.Weight
			};
		}
	}
}
namespace Sindarin.FitPro1.Communication
{
	public interface ICommItem
	{
		bool IsCmd { get; }

		byte[] GetRequestBytes();

		void SetResponseBytes(byte[] bytes);
	}
	internal interface IBitFieldCommItem : ICommItem
	{
		BitField BitField { get; }

		object RequestData { get; }

		bool IsWrite { get; }

		TaskCompletionSource<object> Tcs { get; }

		void Recycle();
	}
	internal class BitFieldCommItem : IBitFieldCommItem, ICommItem
	{
		public BitField BitField { get; }

		public object RequestData { get; }

		public bool IsCmd => false;

		public bool IsWrite
		{
			get
			{
				if (!BitField.IsReadOnly())
				{
					return RequestData != null;
				}
				return false;
			}
		}

		public TaskCompletionSource<object> Tcs { get; private set; } = new TaskCompletionSource<object>();

		public BitFieldCommItem(BitField bitField)
		{
			BitField = bitField;
		}

		public BitFieldCommItem(BitField bitField, object requestData)
			: this(bitField)
		{
			if (bitField.IsReadOnly())
			{
				throw new NotSupportedException($"trying to write to a read only field {bitField}");
			}
			RequestData = requestData;
		}

		public byte[] GetRequestBytes()
		{
			if (RequestData == null)
			{
				return new byte[0];
			}
			try
			{
				return BitField.GetConverter().DataToBytes(RequestData);
			}
			catch (Exception exception)
			{
				Log.Error("FitPro", $"Failed to convert {BitField} value of {RequestData} to bytes", exception);
				throw;
			}
		}

		public void SetResponseBytes(byte[] bytes)
		{
			Tcs.TrySetResult(null);
		}

		public void Recycle()
		{
			Tcs = new TaskCompletionSource<object>();
		}

		public override string ToString()
		{
			return $"[BitFieldCommItem: BitField={BitField}, RequestData={RequestData}, IsCmd={IsCmd}, IsWrite={IsWrite}, Tcs={Tcs}]";
		}
	}
	internal interface ICommandCommItem : ICommItem
	{
		IFitProCommand UntypedCommand { get; }
	}
	internal class CommandCommItem<T> : ICommandCommItem, ICommItem
	{
		public CommandBase<T> Command { get; }

		public byte[] ResultBytes { get; protected set; }

		public T RequestData { get; }

		public TaskCompletionSource<T> Tcs { get; } = new TaskCompletionSource<T>();

		public bool IsCmd => true;

		public IFitProCommand UntypedCommand => Command;

		public bool UserInitiated { get; }

		public CommandCommItem(CommandBase<T> command, bool userInitiated = false)
		{
			Command = command;
			UserInitiated = userInitiated;
		}

		public byte[] GetRequestBytes()
		{
			return Command.GetRequestBytes();
		}

		public void SetResponseBytes(byte[] bytes)
		{
			T result = Command.SetResponseBytes(bytes);
			Tcs.TrySetResult(result);
		}
	}
	internal class CommandCommItemResult
	{
		public bool Successful { get; set; }

		public bool UserInitiated { get; set; }

		public List<BitField> BitsChanged { get; set; }
	}
	public readonly struct CommunicationDelayAndTimeout
	{
		public TimeSpan ReadDelay { get; }

		public TimeSpan Timeout { get; }

		public CommunicationDelayAndTimeout(TimeSpan readDelay, TimeSpan timeout)
		{
			ReadDelay = readDelay;
			Timeout = timeout;
		}

		public override string ToString()
		{
			return $"[CommunicationDelayAndTimeout: ReadDelay={ReadDelay}, Timeout={Timeout}]";
		}
	}
	public class FitProCommunication : IFitProCommunication, ICommunication, IMarkdown
	{
		public const int BytesPerRequestLimit = 64;

		private const int DefaultPacketSize = 44;

		private const int DefaultBleTimeoutSeconds = 2;

		private const int DefaultUsbTimeoutSeconds = 1;

		private readonly int fileIndex;

		private readonly int startIndex;

		private readonly int requestLength;

		private readonly bool isRead;

		private readonly bool isRawBytes;

		private DateTime startTime;

		private byte[] requestBytes;

		private TimeSpan _additionalDelay;

		private TimeSpan _timeout;

		private ConnectionType _format = ConnectionType.BLE;

		private byte[] _cleanResponseBytes;

		public TimeSpan Duration { get; set; }

		public bool IsComplete { get; private set; }

		public int ShouldRetryCount { get; set; } = 3;

		public TimeSpan ReadDelay { get; set; }

		public TimeSpan AdditionalDelay
		{
			get
			{
				if (_additionalDelay == default(TimeSpan))
				{
					_additionalDelay = TimeSpan.Zero;
				}
				return _additionalDelay;
			}
			set
			{
				_additionalDelay = value;
			}
		}

		public TimeSpan Timeout
		{
			get
			{
				if (_timeout == default(TimeSpan))
				{
					_timeout = TimeSpan.FromSeconds((Format != ConnectionType.BLE) ? 1 : 2);
				}
				return _timeout + AdditionalDelay;
			}
			set
			{
				_timeout = value;
			}
		}

		public List<FitProCommunicationGroup> Groups { get; set; } = new List<FitProCommunicationGroup>();

		public TaskCompletionSource<IFitProCommunication> TCS { get; } = new TaskCompletionSource<IFitProCommunication>();

		public ConnectionType Format
		{
			get
			{
				return _format;
			}
			set
			{
				if (value != _format)
				{
					_format = value;
					if (_format != ConnectionType.BLE)
					{
						requestBytes = RemoveBleBytes(requestBytes);
					}
				}
			}
		}

		public byte[] ResponseBytes => Sindarin.Core.Util.ByteUtils.MergeByteList(Groups.Select((FitProCommunicationGroup x) => x.ResponseBytes));

		public byte[] ResponseBytesClean
		{
			get
			{
				if (_cleanResponseBytes != null)
				{
					return _cleanResponseBytes;
				}
				_cleanResponseBytes = Sindarin.Core.Util.ByteUtils.MergeByteList(Groups.Select((FitProCommunicationGroup x) => x.ResponseBytesClean));
				return _cleanResponseBytes;
			}
		}

		public byte[] FormattedBytes
		{
			get
			{
				if (Format == ConnectionType.BLE)
				{
					return ResponseBytesClean;
				}
				return Sindarin.Core.Util.ByteUtils.MergeByteList(Groups.Select((FitProCommunicationGroup x) => x.ResponseBytes));
			}
		}

		public FitProCommunication(byte[] requestBytes = null)
		{
			byte b = (byte)((requestBytes != null) ? ((uint)requestBytes.Length) : 0u);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.WriteByte(2);
				memoryStream.WriteByte(4);
				memoryStream.WriteByte(2);
				memoryStream.WriteByte(b);
				memoryStream.Write(requestBytes, 0, b);
				this.requestBytes = memoryStream.ToArray();
			}
			isRawBytes = true;
		}

		private byte[] RemoveBleBytes(byte[] source)
		{
			byte[] array = new byte[source.Length - 4];
			Array.Copy(source, 4, array, 0, array.Length);
			return array;
		}

		public void CreateRequest()
		{
			startTime = DateTime.Now;
			if (isRawBytes)
			{
				CreateRawRequest();
			}
			else if (isRead)
			{
				CreateReadRequest();
			}
			else
			{
				CreateWriteRequest();
			}
		}

		protected void CreateRawRequest()
		{
			FitProCommunicationGroup item = new FitProCommunicationGroup(requestBytes);
			Groups.Add(item);
		}

		protected void CreateWriteRequest()
		{
			FitProCommunicationGroup item = new FitProCommunicationGroup(isRead, fileIndex, startIndex, requestLength, requestBytes);
			Groups.Add(item);
		}

		protected void CreateReadRequest()
		{
			int num = requestLength;
			int num2 = (int)Math.Ceiling((double)requestLength / 64.0);
			int num3 = startIndex;
			for (int i = 0; i < num2; i++)
			{
				int num4 = (i + 1) * 64;
				FitProCommunicationGroup item = new FitProCommunicationGroup(requestLength: Math.Min(num, 64), isRead: isRead, fileIndex: fileIndex, startIndex: num3);
				Groups.Add(item);
				num3 = num4;
				num -= 64;
			}
		}

		public virtual void ReceiveComplete()
		{
			Duration = DateTime.Now - startTime;
			IsComplete = true;
			TCS.TrySetResult(this);
		}

		public virtual void ReceiveFailed()
		{
			Duration = DateTime.Now - startTime;
			TCS.TrySetException(new Exception("timed out"));
		}

		public byte GetByteAtIndex(int index)
		{
			return ResponseBytesClean[index];
		}

		public int GetIntAtIndex(int index, int length)
		{
			length = Math.Min(length, 4);
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				int num2 = GetByteAtIndex(index + i);
				for (int j = 0; j < length - i - 1; j++)
				{
					num2 *= 256;
				}
				num += num2;
			}
			return num;
		}

		public int GetSignedIntAtIndex(int index, int length)
		{
			int num = (int)Math.Pow(2.0, length * 8) / 2 - 1;
			int num2 = GetIntAtIndex(index, length);
			if (num2 > num)
			{
				num2 -= (int)Math.Pow(2.0, length * 8);
			}
			return num2;
		}

		public string Markdown()
		{
			string seed = "### Communications:\n\nDuration (ms): " + Duration.TotalMilliseconds;
			return Groups.Aggregate(seed, (string current, FitProCommunicationGroup group) => current + group.Markdown());
		}
	}
	public abstract class FitProCommunicationAdapter : IFitProCommunicationAdapter, ICommunicationAdapter<IFitProCommunication, IFitProCommunication>, ICommunicationAdapter, IDisposable
	{
		private enum AdjustmentType
		{
			Read,
			Write,
			Remove,
			Clear
		}

		protected const string Tag = "CommAdapter";

		private readonly SemaphoreSlim queueLock = new SemaphoreSlim(1, 1);

		private readonly SemaphoreSlim sendNextItemLock = new SemaphoreSlim(1, 1);

		private readonly SemaphoreSlim sendNextItemGroupLock = new SemaphoreSlim(1, 1);

		private readonly List<IFitProCommunication> itemQueue = new List<IFitProCommunication>();

		private List<FitProCommunicationGroup> itemGroupQueue;

		protected readonly IFatalityService fatalityService;

		protected IDisposable whenDataChangedSubscriber;

		protected IDisposable decayTimer;

		protected bool itemInProgress;

		protected bool itemGroupInProgress;

		protected int itemsRecentlyLost;

		protected readonly Subject<bool> _whenCommsFailed = new Subject<bool>();

		private DateTime mostRecentFatalityTime;

		private readonly IDisposable initializedSub;

		public IDeviceConnection Connection { get; protected set; }

		protected IFitProCommunication CurrentQueueItem { get; private set; }

		protected FitProCommunicationGroup CurrentQueueItemGroup { get; private set; }

		protected abstract int maxItemLostBeforeFatality { get; }

		protected abstract TimeSpan rateOfItemLostDecay { get; }

		public abstract ConnectionType ConnectionType { get; }

		public abstract TimeSpan DefaultTimeout { get; }

		public IObservable<bool> WhenCommsFailed => _whenCommsFailed.AsObservable();

		protected FitProCommunicationAdapter(IDeviceConnection connection, IFatalityService fatalityService)
		{
			FitProCommunicationAdapter fitProCommunicationAdapter = this;
			Connection = connection;
			this.fatalityService = fatalityService;
			if (connection.Initialized)
			{
				Task.Run(async delegate
				{
					await fitProCommunicationAdapter.StartCommunication(connection);
				}).Wait();
				return;
			}
			initializedSub = Connection.WhenInitialized.Where((bool x) => x).SubscribeAsync(async delegate
			{
				await fitProCommunicationAdapter.StartCommunication(connection);
			});
		}

		private async Task StartCommunication(IDeviceConnection connection)
		{
			if (connection is IClearBuffer clearBuffer)
			{
				await clearBuffer.ClearBuffer();
			}
			await SendNextItem();
		}

		public virtual void Dispose()
		{
			whenDataChangedSubscriber?.Dispose();
			initializedSub?.Dispose();
			AdjustItemQueue(AdjustmentType.Clear);
			CurrentQueueItem = null;
			CurrentQueueItemGroup = null;
		}

		private async Task AdjustItemQueue(AdjustmentType action, int index = -1, IFitProCommunication comm = null)
		{
			await queueLock.WaitAsync();
			switch (action)
			{
			case AdjustmentType.Read:
				CurrentQueueItem = itemQueue.ToList().First();
				break;
			case AdjustmentType.Clear:
				itemQueue?.Clear();
				itemGroupQueue?.Clear();
				break;
			case AdjustmentType.Write:
				WriteToItemQueue(comm, index);
				break;
			case AdjustmentType.Remove:
				RemoveFromItemQueue(index);
				break;
			}
			queueLock.Release();
		}

		private void WriteToItemQueue(IFitProCommunication comm, int index)
		{
			if (comm != null)
			{
				if (index != -1 && itemQueue.Count > index)
				{
					itemQueue.Insert(index, comm);
				}
				else
				{
					itemQueue.Add(comm);
				}
			}
		}

		private void RemoveFromItemQueue(int index)
		{
			if (index != -1 && index < itemQueue.Count)
			{
				itemQueue.RemoveAt(index);
			}
		}

		public virtual async Task<IFitProCommunication> Fetch(IFitProCommunication comm)
		{
			await AdjustItemQueue(AdjustmentType.Write, -1, comm);
			await SendNextItem();
			return await comm.TCS.Task;
		}

		private async Task SendNextItem()
		{
			await sendNextItemLock.WaitAsync();
			try
			{
				if (itemQueue.Count == 0 || itemInProgress)
				{
					return;
				}
				itemInProgress = true;
				await AdjustItemQueue(AdjustmentType.Read);
				await AdjustItemQueue(AdjustmentType.Remove, 0);
				if (CurrentQueueItem == null)
				{
					Log.Trace("CommAdapter", "Current Queue Item Is Null, Class Has Been Disposed");
					return;
				}
				itemGroupQueue = new List<FitProCommunicationGroup>();
				CurrentQueueItem.CreateRequest();
				foreach (FitProCommunicationGroup item in CurrentQueueItem.Groups.ToList())
				{
					itemGroupQueue.Add(item);
				}
				await SendNextItemGroup();
			}
			finally
			{
				sendNextItemLock.Release();
			}
		}

		protected async Task ItemFinished()
		{
			itemInProgress = false;
			CurrentQueueItem.ReceiveComplete();
			await SendNextItem();
		}

		private async Task SendNextItemGroup()
		{
			await sendNextItemGroupLock.WaitAsync();
			try
			{
				if (CurrentQueueItem == null)
				{
					Log.Warn("CommAdapter", "SendNextItemGroup not sending, CurrentQueueItem is null, instance has been Disposed");
					return;
				}
				if (itemGroupQueue.Count == 0 || itemGroupInProgress)
				{
					Log.Warn("CommAdapter", $"SendNextItemGroup not sending, itemGroupQueue.Count={itemGroupQueue.Count} itemGroupInProgress={itemGroupInProgress}");
					return;
				}
				itemGroupInProgress = true;
				whenDataChangedSubscriber?.Dispose();
				whenDataChangedSubscriber = CreateDataChangedSubscriber();
				await TimedSendNextItemGroup();
			}
			finally
			{
				sendNextItemGroupLock.Release();
			}
		}

		private async Task TimedSendNextItemGroup()
		{
			IDeviceConnection connection = Connection;
			if (connection == null || !connection.Initialized)
			{
				itemGroupInProgress = false;
				Log.Warn("CommAdapter", $"SendNextItemGroup not sending, Connection?.Initialized={Connection?.Initialized}");
				return;
			}
			TimeSpan delay = CurrentQueueItem?.ReadDelay ?? default(TimeSpan);
			CurrentQueueItemGroup = itemGroupQueue.ToList().First();
			itemGroupQueue.RemoveAt(0);
			await SendBytes(CurrentQueueItemGroup, delay);
		}

		protected virtual async Task SendBytes(FitProCommunicationGroup commGroup, TimeSpan delay = default(TimeSpan))
		{
			List<byte[]> list = commGroup.RequestBytes.ToList();
			foreach (byte[] item in list)
			{
				await Connection.SendBytesWithReadDelay(item, delay);
			}
		}

		protected abstract IDisposable CreateDataChangedSubscriber();

		protected virtual async Task DataReceived(byte[] bytes)
		{
			CurrentQueueItemGroup.ResponsePackets.Add(bytes);
		}

		protected async Task CommGroupResponseComplete()
		{
			whenDataChangedSubscriber.Dispose();
			itemGroupInProgress = false;
			if (itemGroupQueue.Count == 0)
			{
				await ItemFinished();
			}
			else
			{
				await SendNextItemGroup();
			}
		}

		protected void DataResponseError(Exception _)
		{
			whenDataChangedSubscriber?.Dispose();
			if (CurrentQueueItem == null || CurrentQueueItemGroup == null)
			{
				Log.Trace("CommAdapter", "Current Queue Item Or Item Group Is Null, Class Has Been Disposed");
				return;
			}
			itemGroupInProgress = false;
			if (CurrentQueueItemGroup.Retries < CurrentQueueItem.ShouldRetryCount)
			{
				CurrentQueueItemGroup.ResetForRetry();
				Log.Trace("CommAdapter", "group responses timed out, starting retry #" + CurrentQueueItemGroup.Retries);
				itemGroupQueue.Insert(0, CurrentQueueItemGroup);
				Task.Run((Func<Task>)SendNextItemGroup);
			}
			else
			{
				Log.Trace("CommAdapter", "group responses timed out, failing entire item and moving on");
				itemInProgress = false;
				IncrementItemsRecentlyLost();
				CurrentQueueItem.ReceiveFailed();
				Task.Run((Func<Task>)SendNextItem);
			}
		}

		protected virtual void IncrementItemsRecentlyLost()
		{
			if (decayTimer == null)
			{
				decayTimer = Observable.Interval(rateOfItemLostDecay).Subscribe(DecrementItemsRecentlyLost);
			}
			if (itemsRecentlyLost < maxItemLostBeforeFatality)
			{
				itemsRecentlyLost++;
			}
			else
			{
				OnFatality();
			}
		}

		protected virtual void DecrementItemsRecentlyLost(long x)
		{
			itemsRecentlyLost--;
			Log.Trace("CommAdapter", $"Decremented itemsRecentlyLost to {itemsRecentlyLost}");
			if (itemsRecentlyLost < 1)
			{
				itemsRecentlyLost = 0;
				decayTimer?.Dispose();
				decayTimer = null;
				fatalityService.RecoverIfNeeded(typeof(EquipmentException), "Group Response are no longer failing.");
			}
		}

		protected virtual void OnFatality()
		{
			SubmitFatality(isPermanent: false);
		}

		protected void SubmitFatality(bool isPermanent)
		{
			EquipmentException ex = new EquipmentException($"Too Many Items were dropped: {itemsRecentlyLost} within {rateOfItemLostDecay.TotalSeconds} seconds");
			SubmitFatality(isPermanent, ex);
		}

		protected void SubmitFatality(bool isPermanent, Exception ex, string displayMessage = null, string caller = null)
		{
			bool num = DateTime.UtcNow.Subtract(mostRecentFatalityTime) < TimeSpan.FromSeconds(10.0);
			bool flag = ex is EquipmentException;
			if (!(num && flag))
			{
				fatalityService.ReportFatalEvent(ex, displayMessage, isPermanent, caller);
				mostRecentFatalityTime = DateTime.UtcNow;
			}
		}
	}
	public class FitProCommunicationGroup : IMarkdown
	{
		public const int DefaultReadNumResponsePackets = 6;

		public const int DefaultWriteNumResponsePackets = 11;

		private const int MaxTotalMessageSize = 74;

		private const int MsgPayloadStartIndex = 2;

		private const byte MsgPayloadSize = 18;

		private const int MsgSizeIndex = 1;

		private const byte SerialSizeManagerInitialMsg = 254;

		private const byte SerialSizeManagerMsgCmp = 255;

		private const byte FileAccessRead = 2;

		private const byte FileAccessWrite = 1;

		private const byte ManagedMessageSize = 20;

		private const int MsgNumberIndex = 0;

		private const byte InfoMessagePayloadSize = 2;

		private const int NumBytesOverheadWearable = 9;

		private const int NumBytesOverheadConsole = 4;

		private const int NumTailingBytesOverheadWearable = 17;

		private const int NumTailingBytesOverheadConsole = -1;

		private const int NumPacketsToSkip = 1;

		private const int NumBytesPerPacket = 18;

		private const int InitMsgSize = 10;

		private readonly int numUpfrontOverheadBytes;

		private readonly int numTailingOverheadBytes;

		public int Retries { get; set; }

		public byte[] OriginalBytes { get; private set; }

		public List<byte[]> RequestBytes { get; set; }

		public List<byte[]> ResponsePackets { get; set; } = new List<byte[]>();

		public byte[] ResponseBytes => Sindarin.Core.Util.ByteUtils.MergeByteList(ResponsePackets);

		public byte[] ResponseBytesClean
		{
			get
			{
				List<byte> list = ResponseBytes.ToList();
				list.RemoveRange(0, 22 + numUpfrontOverheadBytes);
				for (int i = 18 - numUpfrontOverheadBytes; i < list.Count; i += 18)
				{
					list.RemoveRange(i, 2);
				}
				int num = numTailingOverheadBytes;
				if (numTailingOverheadBytes == -1)
				{
					num = 18 - Convert.ToInt32(ResponsePackets.Last()[1]);
				}
				list.RemoveRange(list.Count - num, num);
				return list.ToArray();
			}
		}

		public FitProCommunicationGroup(bool isRead, int fileIndex, int startIndex, int requestLength, byte[] origBytes = null)
		{
			OriginalBytes = origBytes;
			numUpfrontOverheadBytes = 9;
			numTailingOverheadBytes = 17;
			byte[] orig = InitMessage(isRead, fileIndex, startIndex, requestLength, origBytes);
			RequestBytes = CreateMessages(orig);
		}

		public FitProCommunicationGroup(byte[] origBytes = null)
		{
			OriginalBytes = origBytes;
			numUpfrontOverheadBytes = 4;
			numTailingOverheadBytes = -1;
			RequestBytes = CreateMessages(origBytes);
		}

		public void ResetForRetry()
		{
			ResponsePackets.Clear();
			Retries++;
		}

		protected static byte[] InitMessage(bool isRead, int fileIndex, int startIndex, int length, byte[] origBytes = null)
		{
			byte b = (byte)((!isRead) ? 1 : 2);
			int num = (isRead ? 6 : 11);
			byte[] array = new byte[isRead ? 10 : (10 + length)];
			array[0] = 2;
			array[1] = b;
			array[2] = 2;
			array[3] = (byte)num;
			array[4] = (byte)fileIndex;
			array[5] = (byte)(startIndex % 256);
			array[6] = (byte)((startIndex >> 8) % 256);
			array[7] = (byte)((startIndex >> 16) % 256);
			array[8] = (byte)((startIndex >> 24) % 256);
			array[9] = (byte)length;
			if (!isRead && origBytes != null)
			{
				Buffer.BlockCopy(origBytes, 0, array, 10, origBytes.Length);
			}
			return array;
		}

		protected static List<byte[]> CreateMessages(byte[] orig)
		{
			List<byte[]> list = new List<byte[]> { CreateInitMessage(orig) };
			if (orig == null || orig.Length == 0)
			{
				return list;
			}
			int num = TotalMessageCount(orig);
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				byte[] array = new byte[20];
				array[1] = (byte)((orig.Length - num3 >= 18) ? 18 : ((byte)(orig.Length - num3)));
				array[0] = (byte)num2;
				Buffer.BlockCopy(orig, num3, array, 2, array[1]);
				num2++;
				num3 += array[1];
				if (num3 >= orig.Length)
				{
					array[0] = 255;
				}
				list.Add(array);
			}
			return list;
		}

		protected static byte[] CreateInitMessage(byte[] orig)
		{
			return new byte[4]
			{
				254,
				2,
				(byte)orig.Length,
				(byte)(TotalMessageCount(orig) + 1)
			};
		}

		protected static int TotalMessageCount(byte[] orig)
		{
			if ((byte)orig.Length > 18)
			{
				return (int)Math.Ceiling((double)orig.Length / 18.0);
			}
			return 1;
		}

		public string Markdown()
		{
			string seed = RequestBytes.Aggregate("\n\n<sub>", (string current, byte[] b) => current + "\n\n**Sent:** " + BitConverter.ToString(b));
			seed = ResponsePackets.Aggregate(seed, (string current, byte[] b) => current + "\n\n**Rcvd:** " + BitConverter.ToString(b));
			return seed + "</sub>";
		}
	}
	public class FitProUsbConsoleCommunicationAdapter : FitProCommunicationAdapter
	{
		private bool fatalityTriggered;

		protected override int maxItemLostBeforeFatality => 5;

		protected override TimeSpan rateOfItemLostDecay => TimeSpan.FromSeconds(2.0);

		public override ConnectionType ConnectionType => ConnectionType.USB;

		public override TimeSpan DefaultTimeout { get; } = TimeSpan.FromSeconds(1.0);

		public FitProUsbConsoleCommunicationAdapter(IDeviceConnection connection, IFatalityService fatalityService)
			: base(connection, fatalityService)
		{
		}

		public override Task<IFitProCommunication> Fetch(IFitProCommunication comm)
		{
			comm.Format = ConnectionType.USB;
			return base.Fetch(comm);
		}

		protected override IDisposable CreateDataChangedSubscriber()
		{
			return base.Connection.WhenValueUpdated.Timeout(base.CurrentQueueItem.Timeout).SubscribeAsync(DataReceived, base.DataResponseError);
		}

		protected override async Task SendBytes(FitProCommunicationGroup commGroup, TimeSpan delay)
		{
			await base.Connection.SendBytesWithReadDelay(commGroup.OriginalBytes, delay);
		}

		protected override async Task DataReceived(byte[] bytes)
		{
			await base.DataReceived(bytes);
			await CommGroupResponseComplete();
		}

		protected override void IncrementItemsRecentlyLost()
		{
			if (!fatalityTriggered)
			{
				base.IncrementItemsRecentlyLost();
				if (fatalityTriggered)
				{
					decayTimer?.Dispose();
					decayTimer = null;
				}
			}
		}

		protected override void OnFatality()
		{
			fatalityTriggered = true;
			_whenCommsFailed.OnNext(value: true);
			SubmitFatality(isPermanent: true);
		}
	}
	public interface IFitProCommunication : ICommunication
	{
		TimeSpan Duration { get; set; }

		TimeSpan AdditionalDelay { get; set; }

		List<FitProCommunicationGroup> Groups { get; set; }

		TaskCompletionSource<IFitProCommunication> TCS { get; }

		byte[] ResponseBytes { get; }

		byte[] ResponseBytesClean { get; }

		byte[] FormattedBytes { get; }

		void CreateRequest();

		byte GetByteAtIndex(int index);

		int GetIntAtIndex(int index, int length);

		int GetSignedIntAtIndex(int index, int length);

		string Markdown();
	}
	public interface IFitProCommunicationAdapter : ICommunicationAdapter<IFitProCommunication, IFitProCommunication>, ICommunicationAdapter, IDisposable
	{
	}
	public interface IQueueManagerAdapter
	{
		Task<byte[]> SendBytes(byte[] bytes, bool expectResponse, CommunicationDelayAndTimeout? delayAndTimeout);
	}
}
namespace Sindarin.FitPro1.Commands
{
	internal class CalibrateCmd : CommandBase<CmdStatus>
	{
		private readonly int calibrationType;

		public override Command Id => Command.Calibrate;

		public override int ContentLength => 1;

		public CalibrateCmd(Device device, int calibrationType = 0)
			: base(device)
		{
			this.calibrationType = calibrationType;
		}

		protected override byte[] RequestContentBytes()
		{
			return new byte[1] { (byte)calibrationType };
		}

		public override CmdStatus SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			return base.Status;
		}
	}
	public enum CmdStatus
	{
		DevNotSupported = 0,
		CmdNotSupported = 1,
		Done = 2,
		InProgress = 3,
		Failed = 4,
		TimeLeft = 5,
		UnknownFailure = 7,
		SecurityBlock = 8,
		CommFailed = 9
	}
	public enum Command
	{
		None = 0,
		Raw = 255,
		PortalDevListen = 1,
		ReadWriteData = 2,
		Test = 3,
		Connect = 4,
		Disconnect = 5,
		Calibrate = 6,
		Update = 9,
		EnterBootloader = 56,
		SetTestingKey = 112,
		SetTestingTach = 113,
		SupportedDevices = 128,
		DeviceInfo = 129,
		SystemInfo = 130,
		TaskInfo = 131,
		VersionInfo = 132,
		ModeHistory = 134,
		SupportedCommands = 136,
		ReadConfig = 137,
		VerifySecurity = 144,
		ProtocolData = 145,
		SpeedGradeLimit = 146,
		SerialNumber = 149
	}
	internal interface IFitProCommand
	{
		Command Id { get; }

		int Length { get; }

		Device Device { get; }

		CmdStatus Status { get; }

		bool ExpectResponse { get; }

		int ResponseTimeoutMs { get; }

		int ReadDelayMs { get; }

		byte[] GetRequestBytes();
	}
	internal interface IFitProCommand<T> : IFitProCommand
	{
		T SetResponseBytes(byte[] bytes);
	}
	internal abstract class CommandBase<T> : IFitProCommand<T>, IFitProCommand
	{
		public const int CmdResponseOverheadSize = 4;

		public int Length => ContentLength + 4;

		public Device Device { get; protected set; }

		public CmdStatus Status { get; protected set; }

		public abstract Command Id { get; }

		public abstract int ContentLength { get; }

		public virtual bool ExpectResponse { get; } = true;

		protected int ResponseLength { get; set; }

		public virtual int ResponseTimeoutMs { get; } = 2500;

		public virtual int ReadDelayMs { get; } = 400;

		public string Sent { get; protected set; }

		public string Received { get; protected set; }

		protected CommandBase(Device device = Device.Main)
		{
			Device = device;
		}

		protected virtual byte[] RequestContentBytes()
		{
			return new byte[0];
		}

		public virtual byte[] GetRequestBytes()
		{
			byte[] array = RequestContentBytes();
			byte[] array2 = new byte[Length];
			array2[0] = (byte)Device;
			array2[1] = (byte)Length;
			array2[2] = (byte)Id;
			array.CopyTo(array2, 3);
			array2[Length - 1] = EquipmentUtil.GetCheckSum(array2);
			Sent = BitConverter.ToString(array2);
			return array2;
		}

		public virtual T SetResponseBytes(byte[] bytes)
		{
			Device = (Device)bytes[0];
			ResponseLength = bytes[1];
			Status = (CmdStatus)bytes[3];
			return default(T);
		}
	}
	internal class ConnectCmd : NoCmdBase
	{
		public override Command Id => Command.Connect;

		public ConnectCmd(Device device)
			: base(device)
		{
		}
	}
	internal class DeviceInfoCmd : CommandBase<DeviceInfo>
	{
		public override Command Id => Command.DeviceInfo;

		public override int ContentLength => 0;

		public override int ResponseTimeoutMs => 1000;

		public override int ReadDelayMs => 300;

		public DeviceInfoCmd(Device device)
			: base(device)
		{
		}

		public override DeviceInfo SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			DeviceInfo deviceInfo = new DeviceInfo
			{
				Device = base.Device
			};
			binaryReader.ReadBytes(4);
			deviceInfo.SoftwareVersion = binaryReader.ReadByte();
			deviceInfo.HardwareVersion = binaryReader.ReadByte();
			deviceInfo.SerialNumber = (int)binaryReader.ReadUInt32();
			int num = binaryReader.ReadUInt16();
			if (Enum.IsDefined(typeof(Manufacturer), num))
			{
				deviceInfo.Manufacturer = (Manufacturer)num;
			}
			deviceInfo.Sections = binaryReader.ReadByte();
			for (int i = 0; i < deviceInfo.Sections; i++)
			{
				byte b = binaryReader.ReadByte();
				for (int j = 0; j < 8; j++)
				{
					if ((b & (1 << j)) != 0)
					{
						int num2 = i * 8 + j;
						if (Enum.IsDefined(typeof(BitField), num2))
						{
							deviceInfo.SupportedBitFields.Add((BitField)num2);
						}
					}
				}
			}
			return deviceInfo;
		}
	}
	internal class DisconnectCmd : NoCmdBase
	{
		public override Command Id => Command.Disconnect;

		public DisconnectCmd(Device device)
			: base(device)
		{
		}
	}
	internal class EnterBootloaderCmd : NoCmdBase
	{
		public override Command Id => Command.EnterBootloader;

		public EnterBootloaderCmd(Device device)
			: base(device)
		{
		}
	}
	internal class NoCmd : NoCmdBase
	{
		public override Command Id => Command.None;

		public NoCmd(Device device)
			: base(device)
		{
		}
	}
	internal abstract class NoCmdBase : CommandBase<object>
	{
		public override int ContentLength => 0;

		public override bool ExpectResponse => false;

		protected NoCmdBase(Device device)
			: base(device)
		{
		}
	}
	internal class ReadWriteDataCmd : CommandBase<bool>
	{
		public const string LogTag = "FitPro";

		public const int StaticReadDelayMs = 80;

		private readonly IFitnessValueUpdater fitnessValueUpdater;

		private int _contentLength;

		public override int ReadDelayMs => 80;

		public override int ResponseTimeoutMs => 1000;

		public override int ContentLength => _contentLength;

		public override Command Id => Command.ReadWriteData;

		public virtual List<IBitFieldCommItem> ReadComms { get; }

		public List<IBitFieldCommItem> WriteComms { get; }

		public Dictionary<BitField, object> UpdatedBitFields { get; } = new Dictionary<BitField, object>();

		public ReadWriteDataCmd(Device device, IFitnessValueUpdater fitnessValueUpdater, IEnumerable<IBitFieldCommItem> readFields = null, IEnumerable<IBitFieldCommItem> writeFields = null)
			: base(device)
		{
			this.fitnessValueUpdater = fitnessValueUpdater;
			ReadComms = readFields?.OrderBy((IBitFieldCommItem x) => (int)x.BitField).ToList();
			WriteComms = (from x in writeFields?.Where((IBitFieldCommItem x) => !x.BitField.IsReadOnly())
				orderby (int)x.BitField
				select x).ToList();
			if (!ReadComms.IsNullOrEmpty())
			{
				Timers.ReadTimer.Start();
			}
		}

		protected override byte[] RequestContentBytes()
		{
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			using MemoryStream memoryStream2 = GetBytesForReadWriteValues(WriteComms, isWrite: true);
			using MemoryStream memoryStream3 = GetBytesForReadWriteValues(ReadComms);
			binaryWriter.Write(memoryStream2.ToArray());
			binaryWriter.Write(memoryStream3.ToArray());
			byte[] array = memoryStream.ToArray();
			_contentLength = array.Length;
			return array;
		}

		private MemoryStream GetBytesForReadWriteValues(List<IBitFieldCommItem> comms, bool isWrite = false)
		{
			MemoryStream stream = new MemoryStream();
			if (comms.IsNullOrEmpty())
			{
				stream.WriteByte(0);
				return stream;
			}
			IExtremaEnumerable<IBitFieldCommItem> extremaEnumerable = comms.MaxBy((IBitFieldCommItem x) => x.BitField);
			int num = ((extremaEnumerable != null) ? ((int)extremaEnumerable.FirstOrDefault().BitField / 8 + 1) : 0);
			stream.WriteByte((byte)num);
			int i;
			for (i = 0; i < num; i++)
			{
				byte headerDataBitBytesForSection = EquipmentUtil.GetHeaderDataBitBytesForSection(from x in comms
					where (int)x.BitField / 8 == i
					select (int)x.BitField);
				stream.WriteByte(headerDataBitBytesForSection);
			}
			if (isWrite)
			{
				foreach (IBitFieldCommItem comm in comms)
				{
					comm.GetRequestBytes().ForEach(delegate(byte x)
					{
						stream.WriteByte(x);
					});
				}
			}
			return stream;
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			base.Received = BitConverter.ToString(bytes);
			ReadComms?.ForEach(delegate(IBitFieldCommItem x)
			{
				x.SetResponseBytes(null);
			});
			WriteComms?.ForEach(delegate(IBitFieldCommItem x)
			{
				x.SetResponseBytes(null);
			});
			if (base.Status != CmdStatus.Done)
			{
				Log.Trace("FitPro", $"Read/Write was not successful: {base.Status}");
				return false;
			}
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.ReadBytes(4);
			fitnessValueUpdater.BeginBatchUpdate();
			try
			{
				if (ReadComms != null)
				{
					foreach (IBitFieldCommItem readComm in ReadComms)
					{
						try
						{
							ProcessBitFieldCommItem(readComm, binaryReader);
						}
						catch
						{
							return false;
						}
					}
					Timers.ReadTimer.End();
				}
				if (WriteComms != null && base.Status == CmdStatus.Done)
				{
					foreach (IBitFieldCommItem writeComm in WriteComms)
					{
						ProcessBitFieldWriteComm(writeComm);
					}
				}
			}
			finally
			{
				fitnessValueUpdater.EndBatchUpdate();
			}
			return true;
		}

		private void ProcessBitFieldWriteComm(IBitFieldCommItem writeComm)
		{
			try
			{
				if (writeComm.RequestData == null || (writeComm.BitField == BitField.WorkoutMode && writeComm.RequestData as WorkoutMode? == WorkoutMode.Resume))
				{
					return;
				}
				if (writeComm.BitField == BitField.WorkoutMode)
				{
					if (writeComm.RequestData is WorkoutMode mode)
					{
						fitnessValueUpdater.SetValue(writeComm.BitField.ToFitnessValue().Value, mode.ToConsoleState());
					}
				}
				else
				{
					fitnessValueUpdater.SetValue(writeComm.BitField.ToFitnessValue().Value, writeComm.RequestData);
				}
			}
			catch (Exception exception)
			{
				Log.Error("FitPro", "Error thrown setting bit field value", exception);
			}
		}

		private void ProcessBitFieldCommItem(IBitFieldCommItem comm, BinaryReader reader)
		{
			IBitFieldConverter converter = comm.BitField.GetConverter();
			byte[] array = reader.ReadBytes(converter.Size);
			try
			{
				object obj = converter.BytesToData(array);
				if (comm.BitField == BitField.WorkoutMode && obj is WorkoutMode mode)
				{
					obj = mode.ToConsoleState();
				}
				if (comm.BitField.ToFitnessValue().HasValue && fitnessValueUpdater.SetValue(comm.BitField.ToFitnessValue().Value, obj))
				{
					UpdatedBitFields[comm.BitField] = obj;
				}
			}
			catch (FitnessValueArgumentOutOfRangeException ex)
			{
				Log.Error("FitPro", ex.Message);
				throw;
			}
			catch (FitnessValueArgumentTypeException ex2)
			{
				Log.Error("FitPro", ex2.Message);
				throw;
			}
			catch (ArgumentOutOfRangeException)
			{
				Log.Error("FitPro", $"{converter.GetType()} conversion failed, size {converter.Size}, byte data {BitConverter.ToString(array)}, bit field {comm.BitField}");
				throw;
			}
			catch (Exception arg)
			{
				Log.Error("FitPro", $"{comm.BitField}: Failed to SetResponseBytes due to {arg}");
				throw;
			}
		}
	}
	internal class ResetCmd : CommandBase<NoCmd>
	{
		public override Command Id => Command.Update;

		public override int ContentLength => 0;

		public override bool ExpectResponse => false;

		public ResetCmd()
			: base(Device.Main)
		{
		}
	}
	internal class SerialNumberCmd : CommandBase<string>
	{
		public override Command Id => Command.SerialNumber;

		public override int ContentLength => 0;

		public SerialNumberCmd(Device device = Device.Main)
			: base(device)
		{
		}

		public override string SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.ReadBytes(4);
			byte b = binaryReader.ReadByte();
			byte[] buffer = new byte[b];
			for (int i = 0; i < b; i++)
			{
				buffer[i] = binaryReader.ReadByte();
			}
			return ((buffer[0] == 255 || buffer[0] == 0) && buffer.ToList().All((byte x) => x == buffer[0])) ? null : BitConverter.ToString(buffer);
		}
	}
	internal class SetStrokesPerMinuteCmd : CommandBase<bool>
	{
		private int _contentLength;

		private readonly byte strokesPerMin;

		public override Command Id => Command.ReadWriteData;

		public override int ContentLength => _contentLength;

		public SetStrokesPerMinuteCmd(Device device, int strokesPerMin)
			: base(device)
		{
			this.strokesPerMin = (byte)strokesPerMin.Clamp(0, 255);
		}

		protected override byte[] RequestContentBytes()
		{
			using MemoryStream memoryStream = new MemoryStream();
			int num = 14;
			memoryStream.WriteByte((byte)num);
			for (int i = 0; i < num - 1; i++)
			{
				memoryStream.WriteByte(0);
			}
			byte headerDataBitBytesForSection = EquipmentUtil.GetHeaderDataBitBytesForSection(new List<int> { 110 });
			memoryStream.WriteByte(headerDataBitBytesForSection);
			memoryStream.WriteByte(strokesPerMin);
			memoryStream.WriteByte(0);
			byte[] array = memoryStream.ToArray();
			_contentLength = array.Length;
			return array;
		}
	}
	internal class SetTachOverrideCmd : CommandBase<bool>
	{
		private readonly bool enableTachOverride;

		private readonly int rpms;

		private readonly int kph;

		private readonly int timeBetweenTach;

		public override Command Id => Command.SetTestingTach;

		public override int ContentLength => 7;

		public SetTachOverrideCmd(Device device, bool enableTachOverride, int rpms, int kph, int timeBetweenTach)
			: base(device)
		{
			this.enableTachOverride = enableTachOverride;
			this.rpms = rpms;
			this.kph = kph;
			this.timeBetweenTach = timeBetweenTach;
		}

		protected override byte[] RequestContentBytes()
		{
			byte[] array = new byte[7];
			byte[] array2 = BitConverter.GetBytes(rpms).Take(2).ToArray();
			byte[] array3 = BitConverter.GetBytes(timeBetweenTach).Take(2).ToArray();
			byte[] array4 = BitConverter.GetBytes(kph).Take(2).ToArray();
			array[0] = (byte)(enableTachOverride ? 1 : 0);
			array[1] = array2[0];
			array[2] = array2[1];
			array[3] = array3[0];
			array[4] = array3[1];
			array[5] = array4[0];
			array[6] = array4[1];
			return array;
		}
	}
	internal class SupportedCommandsCmd : CommandBase<HashSet<Command>>
	{
		public override Command Id => Command.SupportedCommands;

		public override int ContentLength => 0;

		public override int ResponseTimeoutMs => 1000;

		public override int ReadDelayMs => 300;

		public SupportedCommandsCmd(Device device)
			: base(device)
		{
		}

		public override HashSet<Command> SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.ReadBytes(4);
			HashSet<Command> hashSet = new HashSet<Command>();
			int num = base.ResponseLength - 4 - 1;
			for (int i = 0; i < num; i++)
			{
				hashSet.Add((Command)binaryReader.ReadByte());
			}
			return hashSet;
		}
	}
	internal class SupportedDevicesCmd : CommandBase<List<Device>>
	{
		public override Command Id => Command.SupportedDevices;

		public override int ContentLength => 0;

		public override int ResponseTimeoutMs => 1000;

		public override int ReadDelayMs => 300;

		public SupportedDevicesCmd(Device device)
			: base(device)
		{
		}

		public override List<Device> SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.ReadBytes(4);
			List<Device> list = new List<Device>();
			int num = binaryReader.ReadByte();
			for (int i = 0; i < num; i++)
			{
				list.Add((Device)binaryReader.ReadByte());
			}
			return list;
		}
	}
	internal class SystemInfoCmd : CommandBase<SystemDeviceInfo>
	{
		public enum MarketType
		{
			Home,
			Club
		}

		private readonly bool fetchMcuName;

		public override Command Id => Command.SystemInfo;

		public override int ContentLength => 2;

		public override int ResponseTimeoutMs => 1000;

		public override int ReadDelayMs => 300;

		public SystemInfoCmd(Device device = Device.Main, bool fetchMcuName = false)
			: base(device)
		{
			this.fetchMcuName = fetchMcuName;
		}

		protected override byte[] RequestContentBytes()
		{
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)(fetchMcuName ? 1u : 0u));
			memoryStream.WriteByte(0);
			return memoryStream.ToArray();
		}

		public override SystemDeviceInfo SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			SystemDeviceInfo systemDeviceInfo = new SystemDeviceInfo();
			binaryReader.ReadBytes(4);
			systemDeviceInfo.ConfigSize = binaryReader.ReadUInt16();
			systemDeviceInfo.Configuration = (SystemDeviceInfo.SystemConfiguration)binaryReader.ReadByte();
			systemDeviceInfo.Model = (int)binaryReader.ReadUInt32();
			systemDeviceInfo.PartNumber = (int)binaryReader.ReadUInt32();
			systemDeviceInfo.CpuUse = (double)(int)binaryReader.ReadUInt16() / 1000.0;
			systemDeviceInfo.NumberOfTasks = binaryReader.ReadByte();
			systemDeviceInfo.IntervalTime = binaryReader.ReadUInt16();
			systemDeviceInfo.CpuFrequency = (int)binaryReader.ReadUInt32();
			systemDeviceInfo.PollingFrequency = binaryReader.ReadUInt16();
			systemDeviceInfo.IsUnitMetricDefault = binaryReader.ReadBoolean();
			systemDeviceInfo.IsMarketTypeClub = binaryReader.ReadByte() == 1;
			systemDeviceInfo.FitProConfigLibVersion = binaryReader.ReadByte();
			systemDeviceInfo.DefaultLanguage = (SystemDeviceInfo.SystemLanguage)binaryReader.ReadByte();
			byte b = binaryReader.ReadByte();
			for (int i = 0; i < b; i++)
			{
				systemDeviceInfo.McuName += binaryReader.ReadByte();
			}
			byte b2 = binaryReader.ReadByte();
			for (int j = 0; j < b2; j++)
			{
				systemDeviceInfo.ConsoleName += binaryReader.ReadByte();
			}
			if (systemDeviceInfo.PartNumber == 370357 && systemDeviceInfo.Model == 39915)
			{
				systemDeviceInfo.PartNumber = 374677;
			}
			return systemDeviceInfo;
		}
	}
	internal class TestCmd : NoCmdBase
	{
		public override Command Id => Command.Test;

		public TestCmd(Device device)
			: base(device)
		{
		}
	}
	internal class VerifySecurityCmd : CommandBase<SecurityInfo>
	{
		private const int MinorVersion = 8;

		private readonly byte[] securityHash;

		private readonly int secretKey;

		public override Command Id => Command.VerifySecurity;

		public override int ContentLength => 36;

		public VerifySecurityCmd(Device device, byte[] securityHash, int masterLibraryVersion)
			: base(device)
		{
			this.securityHash = securityHash;
			secretKey = 8 * masterLibraryVersion;
		}

		protected override byte[] RequestContentBytes()
		{
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(securityHash);
			binaryWriter.Write(secretKey);
			return memoryStream.ToArray();
		}

		public override SecurityInfo SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			SecurityInfo securityInfo = new SecurityInfo();
			binaryReader.ReadBytes(4);
			securityInfo.UnlockedKey = binaryReader.ReadByte();
			securityInfo.IsUnlocked = base.Status == CmdStatus.Done;
			return securityInfo;
		}
	}
	internal class VersionInfoCmd : CommandBase<VersionInfo>
	{
		private readonly bool fetchMcuName;

		private readonly bool fetchConsoleName;

		public override Command Id => Command.VersionInfo;

		public override int ContentLength => 2;

		public VersionInfoCmd(Device device = Device.Main, bool fetchMcuName = false, bool fetchConsoleName = false)
			: base(device)
		{
			this.fetchMcuName = fetchMcuName;
			this.fetchConsoleName = fetchConsoleName;
		}

		protected override byte[] RequestContentBytes()
		{
			return new byte[2]
			{
				(byte)(fetchMcuName ? 1 : 0),
				(byte)(fetchConsoleName ? 1 : 0)
			};
		}

		public override VersionInfo SetResponseBytes(byte[] bytes)
		{
			base.SetResponseBytes(bytes);
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			VersionInfo versionInfo = new VersionInfo();
			binaryReader.ReadBytes(4);
			versionInfo.MasterLibraryVersion = binaryReader.ReadByte();
			versionInfo.MasterLibraryBuild = binaryReader.ReadUInt16();
			byte[] array = new byte[17];
			binaryReader.Read(array, 0, 17);
			versionInfo.IconBleLibVersion = ((array[0] != 0) ? Encoding.UTF8.GetString(array, 0, 17) : "NO BLE");
			versionInfo.ConfigToolVersion = binaryReader.ReadByte();
			versionInfo.BleSdkVersion = binaryReader.ReadUInt16();
			return versionInfo;
		}
	}
}
namespace Sindarin.FitPro1.Bits
{
	internal enum BitField
	{
		[BitFieldInfo(typeof(SpeedConverter), false)]
		Kph = 0,
		[BitFieldInfo(typeof(GradeConverter), false)]
		Grade = 1,
		[BitFieldInfo(typeof(ResistanceConverter), false)]
		Resistance = 2,
		[BitFieldInfo(typeof(ShortConverter), true)]
		Watts = 3,
		[BitFieldInfo(typeof(IntConverter), true)]
		CurrentDistance = 4,
		[BitFieldInfo(typeof(ShortConverter), true)]
		Rpm = 5,
		[BitFieldInfo(typeof(IntConverter), true)]
		Distance = 6,
		[BitFieldInfo(typeof(KeyObjConverter), true)]
		KeyObject = 7,
		[BitFieldInfo(typeof(ByteConverter), false)]
		FanSpeed = 8,
		[BitFieldInfo(typeof(ByteConverter), false)]
		Volume = 9,
		[BitFieldInfo(typeof(PulseConverter), false)]
		Pulse = 10,
		[BitFieldInfo(typeof(IntConverter), true)]
		RunningTime = 11,
		[BitFieldInfo(typeof(ModeConverter), false)]
		WorkoutMode = 12,
		[BitFieldInfo(typeof(CaloriesConverter), true)]
		Calories = 13,
		[BitFieldInfo(typeof(AudioSourceConverter), false)]
		AudioSource = 14,
		[BitFieldInfo(typeof(ShortConverter), true)]
		LapTime = 15,
		[BitFieldInfo(typeof(SpeedConverter), true)]
		ActualKph = 16,
		[BitFieldInfo(typeof(GradeConverter), true)]
		ActualIncline = 17,
		[BitFieldInfo(typeof(ResistanceConverter), true)]
		ActualResistance = 18,
		[BitFieldInfo(typeof(IntConverter), true)]
		ActualDistance = 19,
		[BitFieldInfo(typeof(IntConverter), true)]
		CurrentTime = 20,
		[BitFieldInfo(typeof(CaloriesConverter), true)]
		CurrentCalories = 21,
		[BitFieldInfo(typeof(IntConverter), false)]
		GoalTime = 22,
		[BitFieldInfo(typeof(IntervalDoubleConverter), true)]
		IntervalKph = 23,
		[BitFieldInfo(typeof(ByteConverter), false)]
		Age = 24,
		[BitFieldInfo(typeof(DoubleConverter), false)]
		Weight = 25,
		[BitFieldInfo(typeof(GearConverter), false)]
		Gear = 26,
		[BitFieldInfo(typeof(GradeConverter), true)]
		MaxGrade = 27,
		[BitFieldInfo(typeof(GradeConverter), true)]
		MinGrade = 28,
		[BitFieldInfo(typeof(ShortConverter), false)]
		TransMax = 29,
		[BitFieldInfo(typeof(SpeedConverter), true)]
		MaxKph = 30,
		[BitFieldInfo(typeof(SpeedConverter), true)]
		MinKph = 31,
		[BitFieldInfo(typeof(ShortConverter), false)]
		IdleTimeout = 34,
		[BitFieldInfo(typeof(ShortConverter), false)]
		PauseTimeout = 35,
		[BitFieldInfo(typeof(BoolConverter), false)]
		SystemUnits = 36,
		[BitFieldInfo(typeof(BoolConverter), false)]
		Gender = 37,
		[BitFieldInfo(typeof(StringConverter), false)]
		FirstName = 38,
		[BitFieldInfo(typeof(StringConverter), false)]
		LastName = 39,
		[BitFieldInfo(typeof(StringConverter), false)]
		UserName = 40,
		[BitFieldInfo(typeof(ShortConverter), false)]
		Height = 41,
		[BitFieldInfo(typeof(ByteConverter), true)]
		MaxResistanceLevel = 42,
		[BitFieldInfo(typeof(DoubleConverter), true)]
		MaxWeight = 43,
		[BitFieldInfo(typeof(IntConverter), true)]
		WarmupDistance = 44,
		[BitFieldInfo(typeof(ShortConverter), true)]
		WarmupTime = 45,
		[BitFieldInfo(typeof(ShortConverter), false)]
		WarmupTimeout = 46,
		[BitFieldInfo(typeof(CaloriesConverter), true)]
		WarmupCalories = 47,
		[BitFieldInfo(typeof(DoubleConverter), true)]
		IntervalGrade = 48,
		[BitFieldInfo(typeof(ByteConverter), true)]
		MaxPulse = 49,
		[BitFieldInfo(typeof(SpeedConverter), true)]
		WtMaxKph = 51,
		[BitFieldInfo(typeof(GradeConverter), true)]
		AverageGrade = 52,
		[BitFieldInfo(typeof(GradeConverter), true)]
		WtMaxGrade = 53,
		[BitFieldInfo(typeof(ShortConverter), true)]
		AverageWatts = 54,
		[BitFieldInfo(typeof(ShortConverter), true)]
		MaxWatts = 55,
		[BitFieldInfo(typeof(ShortConverter), true)]
		AverageRpm = 56,
		[BitFieldInfo(typeof(ShortConverter), true)]
		MaxRpm = 57,
		[BitFieldInfo(typeof(SpeedConverter), false)]
		KphGoal = 58,
		[BitFieldInfo(typeof(GradeConverter), false)]
		GradeGoal = 59,
		[BitFieldInfo(typeof(ResistanceConverter), false)]
		ResistanceGoal = 60,
		[BitFieldInfo(typeof(ShortConverter), false)]
		WattGoal = 61,
		[BitFieldInfo(typeof(ShortConverter), false)]
		RpmGoal = 63,
		[BitFieldInfo(typeof(IntConverter), false)]
		DistanceGoal = 64,
		[BitFieldInfo(typeof(ByteConverter), false)]
		PulseGoal = 65,
		[BitFieldInfo(typeof(IntConverter), true)]
		StartUpTime = 66,
		[BitFieldInfo(typeof(IntConverter), true)]
		BeltTotalTime = 67,
		[BitFieldInfo(typeof(IntConverter), true)]
		BeltTotalMeters = 68,
		[BitFieldInfo(typeof(IntConverter), true)]
		MotorTotalDistance = 69,
		[BitFieldInfo(typeof(IntConverter), true)]
		TotalTime = 70,
		[BitFieldInfo(typeof(ShortConverter), false)]
		CoolDownTimeout = 71,
		[BitFieldInfo(typeof(ShortConverter), true)]
		CoolDownTime = 72,
		[BitFieldInfo(typeof(IntConverter), true)]
		CoolDownDistance = 73,
		[BitFieldInfo(typeof(CaloriesConverter), true)]
		CoolDownCalories = 74,
		[BitFieldInfo(typeof(VerticalMeterConverter), true)]
		VerticalMeterNet = 75,
		[BitFieldInfo(typeof(VerticalMeterConverter), true)]
		VerticalMeterGain = 76,
		[BitFieldInfo(typeof(ShortConverter), true)]
		Reps = 77,
		[BitFieldInfo(typeof(ShortConverter), true)]
		LeftReps = 78,
		[BitFieldInfo(typeof(ShortConverter), true)]
		RightReps = 79,
		[BitFieldInfo(typeof(ShortConverter), true)]
		RepLength = 80,
		[BitFieldInfo(typeof(ShortConverter), true)]
		RepLeftLength = 81,
		[BitFieldInfo(typeof(ShortConverter), true)]
		RepRightLength = 82,
		[BitFieldInfo(typeof(BurnRateConverter), false)]
		BurnRate = 83,
		[BitFieldInfo(typeof(BurnRateConverter), true)]
		AvgBurnRate = 84,
		[BitFieldInfo(typeof(BurnRateConverter), true)]
		MaxBurnRate = 85,
		[BitFieldInfo(typeof(IntervalIntConverter), true)]
		IntervalRpm = 86,
		[BitFieldInfo(typeof(IntervalIntConverter), true)]
		IntervalResistance = 87,
		[BitFieldInfo(typeof(CaloriesConverter), false)]
		GoalCalories = 94,
		[BitFieldInfo(typeof(BoolConverter), false)]
		IdleModeLockout = 95,
		[BitFieldInfo(typeof(BoolConverter), false)]
		SleepTimerState = 107,
		[BitFieldInfo(typeof(BoolConverter), true)]
		StartRequested = 96,
		[BitFieldInfo(typeof(FanStateConverter), false)]
		FanState = 98,
		[BitFieldInfo(typeof(ByteConverter), false)]
		ActivationLock = 100,
		[BitFieldInfo(typeof(IntConverter), true)]
		PausedTime = 103,
		[BitFieldInfo(typeof(BoolConverter), false)]
		RequireStartRequested = 108,
		[BitFieldInfo(typeof(ShortConverter), true)]
		Strokes = 109,
		[BitFieldInfo(typeof(ByteConverter), true)]
		StrokesPerMin = 110,
		[BitFieldInfo(typeof(ShortConverter), true)]
		FiveHundredSplit = 111,
		[BitFieldInfo(typeof(ShortConverter), true)]
		AvgFiveHundredSplit = 112,
		[BitFieldInfo(typeof(BoolConverter), true)]
		IsClubUnit = 115,
		[BitFieldInfo(typeof(BoolConverter), true)]
		IsReadyToDisconnect = 116,
		[BitFieldInfo(typeof(BoolConverter), false)]
		IsConstantWattsMode = 119
	}
	public class BitFieldInfo : Attribute
	{
		public IBitFieldConverter Converter { get; }

		public Type ConverterType { get; }

		public bool ReadOnly { get; }

		public BitFieldInfo(Type converterType, bool readOnly = false)
		{
			ConverterType = converterType;
			Converter = ConverterMap.Entries[converterType];
			ReadOnly = readOnly;
		}
	}
	internal static class BitFieldExtensions
	{
		private static readonly SemaphoreSlim threadLock = new SemaphoreSlim(1);

		private static readonly Dictionary<BitField, BitFieldInfo> BitFieldInfoMapping = new Dictionary<BitField, BitFieldInfo>();

		public static IBitFieldConverter GetConverter(this BitField item)
		{
			return GetOrFetch(item).Converter;
		}

		public static bool IsReadOnly(this BitField item)
		{
			try
			{
				return GetOrFetch(item).ReadOnly;
			}
			catch (Exception)
			{
				Log.Error("BitField", $"Failed to retrieve BitField {item}");
			}
			return true;
		}

		public static void Clear()
		{
			threadLock.Wait();
			try
			{
				BitFieldInfoMapping.Clear();
			}
			finally
			{
				threadLock.Release();
			}
		}

		private static BitFieldInfo GetOrFetch(BitField item)
		{
			threadLock.Wait();
			try
			{
				if (!BitFieldInfoMapping.ContainsKey(item))
				{
					BitFieldInfoMapping[item] = item.GetAttribute<BitFieldInfo>();
				}
			}
			finally
			{
				threadLock.Release();
			}
			return BitFieldInfoMapping[item];
		}

		public static FitnessValue? ToFitnessValue(this BitField item)
		{
			if (Enum.TryParse<FitnessValue>(item.ToString(), out var result) && Enum.IsDefined(typeof(FitnessValue), result))
			{
				return result;
			}
			Log.Error("BitField", $"Failed to convert BitField {item}");
			return null;
		}
	}
}
namespace Sindarin.FitPro1.Bits.Converters
{
	internal class AudioSourceConverter : ConverterBase<AudioSource>
	{
		public AudioSourceConverter()
			: base(3)
		{
		}

		public override AudioSource Convert(byte[] bytes)
		{
			byte current = bytes[0];
			List<AudioSource.Source> available = (from x in bytes.Skip(1)
				select (AudioSource.Source)x).ToList();
			return new AudioSource((AudioSource.Source)current, available);
		}

		public override byte[] Convert(AudioSource data)
		{
			byte[] array = new byte[base.Size];
			array[0] = (byte)data.Current;
			return array;
		}
	}
	internal class BoolConverter : ConverterBase<bool>
	{
		public BoolConverter()
			: base(1)
		{
		}

		public override byte[] Convert(bool data)
		{
			return BitConverter.GetBytes(data);
		}

		public override bool Convert(byte[] bytes)
		{
			return BitConverter.ToBoolean(bytes, 0);
		}
	}
	internal class BurnRateConverter : ConverterBase<double>
	{
		public BurnRateConverter()
			: base(2)
		{
		}

		public override byte[] Convert(double data)
		{
			data *= 1000.0;
			return BitConverter.GetBytes((int)data).Take(2).ToArray();
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(short)BitConverter.ToUInt16(bytes, 0) / 1000.0;
		}
	}
	internal class CaloriesConverter : ConverterBase<double>
	{
		public CaloriesConverter()
			: base(4)
		{
		}

		public override byte[] Convert(double data)
		{
			data *= 100000000.0;
			data /= 1024.0;
			return BitConverter.GetBytes((int)data);
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(int)BitConverter.ToUInt32(bytes, 0) * 1024.0 / 100000000.0;
		}
	}
	internal abstract class ConverterBase<T> : IBitFieldConverter<T>, IBitFieldConverter
	{
		public int Size { get; }

		public Type DataType { get; }

		public abstract T Convert(byte[] bytes);

		public abstract byte[] Convert(T data);

		protected ConverterBase(int size)
		{
			Size = size;
			DataType = typeof(T);
		}

		public byte[] DataToBytes(object data)
		{
			return Convert((T)data);
		}

		public object BytesToData(byte[] bytes)
		{
			return Convert(bytes);
		}
	}
	internal static class ConverterMap
	{
		private static readonly Dictionary<Type, IBitFieldConverter> _entries;

		public static IDictionary<Type, IBitFieldConverter> Entries;

		static ConverterMap()
		{
			_entries = new Dictionary<Type, IBitFieldConverter>
			{
				{
					typeof(AudioSourceConverter),
					new AudioSourceConverter()
				},
				{
					typeof(BoolConverter),
					new BoolConverter()
				},
				{
					typeof(BurnRateConverter),
					new BurnRateConverter()
				},
				{
					typeof(CaloriesConverter),
					new CaloriesConverter()
				},
				{
					typeof(DoubleConverter),
					new DoubleConverter()
				},
				{
					typeof(GradeConverter),
					new GradeConverter()
				},
				{
					typeof(ByteConverter),
					new ByteConverter()
				},
				{
					typeof(ShortConverter),
					new ShortConverter()
				},
				{
					typeof(IntConverter),
					new IntConverter()
				},
				{
					typeof(IntervalIntConverter),
					new IntervalIntConverter()
				},
				{
					typeof(IntervalDoubleConverter),
					new IntervalDoubleConverter()
				},
				{
					typeof(KeyObjConverter),
					new KeyObjConverter()
				},
				{
					typeof(ModeConverter),
					new ModeConverter()
				},
				{
					typeof(PulseConverter),
					new PulseConverter()
				},
				{
					typeof(SpeedConverter),
					new SpeedConverter()
				},
				{
					typeof(StringConverter),
					new StringConverter()
				},
				{
					typeof(VerticalMeterConverter),
					new VerticalMeterConverter()
				},
				{
					typeof(FanStateConverter),
					new FanStateConverter()
				}
			};
			Entries = new ReadOnlyDictionary<Type, IBitFieldConverter>(_entries);
		}

		public static void UpdateConsole(IFitPro1Console console)
		{
			_entries[typeof(ResistanceConverter)] = new ResistanceConverter(console.LatestBasicInfo, console.DeviceType);
			_entries[typeof(GearConverter)] = new GearConverter(console.LatestBasicInfo);
		}
	}
	internal class DoubleConverter : ConverterBase<double>
	{
		public DoubleConverter()
			: base(2)
		{
		}

		public override byte[] Convert(double data)
		{
			return BitConverter.GetBytes((int)(data * 100.0)).Take(2).ToArray();
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(int)BitConverter.ToUInt16(bytes, 0) / 100.0;
		}
	}
	internal class FanStateConverter : ConverterBase<FanState>
	{
		public FanStateConverter()
			: base(1)
		{
		}

		public override byte[] Convert(FanState data)
		{
			return new byte[1] { (byte)data };
		}

		public override FanState Convert(byte[] bytes)
		{
			int num = bytes[0];
			if (!Enum.IsDefined(typeof(FanState), num))
			{
				return FanState.Unknown;
			}
			return (FanState)num;
		}
	}
	internal class GearConverter : ConverterBase<Gear>
	{
		private readonly IConsoleBasicInfo basicInfo;

		public GearConverter(IConsoleBasicInfo basicInfo)
			: base(8)
		{
			this.basicInfo = basicInfo;
		}

		public override byte[] Convert(Gear data)
		{
			byte[] array = new byte[base.Size];
			array[4] = (byte)data.CurrentGear;
			array[5] = (byte)data.GearOption;
			array[7] = (byte)(data.MaxGear + 1);
			return array;
		}

		public override Gear Convert(byte[] bytes)
		{
			byte b = bytes[4];
			byte gearOption = bytes[5];
			int num = bytes[7] - 1;
			if (num < 1 || num < b)
			{
				num = (byte)basicInfo.Gear.MaxGear;
			}
			return new Gear(b, gearOption, num);
		}
	}
	internal class GradeConverter : ConverterBase<double>
	{
		public GradeConverter()
			: base(2)
		{
		}

		public override byte[] Convert(double data)
		{
			return BitConverter.GetBytes((int)(data * 100.0)).Take(2).ToArray();
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(short)BitConverter.ToUInt16(bytes, 0) / 100.0;
		}
	}
	public interface IBitFieldConverter
	{
		int Size { get; }

		Type DataType { get; }

		byte[] DataToBytes(object data);

		object BytesToData(byte[] bytes);
	}
	public interface IBitFieldConverter<T> : IBitFieldConverter
	{
		T Convert(byte[] bytes);

		byte[] Convert(T data);
	}
	internal class IntConverter : ConverterBase<int>
	{
		public IntConverter()
			: this(4)
		{
		}

		internal IntConverter(int size)
			: base(size)
		{
		}

		public override byte[] Convert(int data)
		{
			return BitConverter.GetBytes(data).Take(base.Size).ToArray();
		}

		public override int Convert(byte[] bytes)
		{
			int val = bytes.Length;
			return Math.Min(base.Size, val) switch
			{
				1 => bytes[0], 
				2 => BitConverter.ToUInt16(bytes, 0), 
				4 => (int)BitConverter.ToUInt32(bytes, 0), 
				_ => throw new NotSupportedException("int size not supported"), 
			};
		}
	}
	internal class ByteConverter : IntConverter
	{
		public ByteConverter()
			: base(1)
		{
		}
	}
	internal class ShortConverter : IntConverter
	{
		public ShortConverter()
			: base(2)
		{
		}
	}
	internal abstract class IntervalConverter : ConverterBase<Interval>
	{
		private readonly bool divideToHundredths;

		protected IntervalConverter(bool divideToHundredths)
			: base(4)
		{
			this.divideToHundredths = divideToHundredths;
		}

		public override byte[] Convert(Interval data)
		{
			double num = (divideToHundredths ? (data.Recovery * 100.0) : data.Recovery);
			double num2 = (divideToHundredths ? (data.Work * 100.0) : data.Work);
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes((int)num), 0, 2);
			memoryStream.Write(BitConverter.GetBytes((int)num2), 0, 2);
			return memoryStream.ToArray();
		}

		public override Interval Convert(byte[] bytes)
		{
			double num = (int)BitConverter.ToUInt16(bytes, 0);
			double num2 = (int)BitConverter.ToUInt16(bytes, 2);
			if (divideToHundredths)
			{
				num /= 100.0;
				num2 /= 100.0;
			}
			return new Interval(num, num2);
		}
	}
	internal class IntervalIntConverter : IntervalConverter
	{
		public IntervalIntConverter()
			: base(divideToHundredths: true)
		{
		}
	}
	internal class IntervalDoubleConverter : IntervalConverter
	{
		public IntervalDoubleConverter()
			: base(divideToHundredths: false)
		{
		}
	}
	internal class KeyObjConverter : ConverterBase<KeyObj>
	{
		public KeyObjConverter()
			: base(14)
		{
		}

		public override byte[] Convert(KeyObj data)
		{
			throw new NotSupportedException();
		}

		public override KeyObj Convert(byte[] bytes)
		{
			using MemoryStream input = new MemoryStream(bytes);
			using BinaryReader binaryReader = new BinaryReader(input);
			ushort code = binaryReader.ReadUInt16();
			ulong rawKey = binaryReader.ReadUInt64();
			ushort timePressed = binaryReader.ReadUInt16();
			ushort timeHeld = binaryReader.ReadUInt16();
			return new KeyObj(code, rawKey, timePressed, timeHeld);
		}
	}
	internal class ModeConverter : ConverterBase<WorkoutMode>
	{
		public ModeConverter()
			: base(1)
		{
		}

		public override byte[] Convert(WorkoutMode data)
		{
			return new byte[1] { (byte)data };
		}

		public override WorkoutMode Convert(byte[] bytes)
		{
			int num = bytes[0];
			if (!Enum.IsDefined(typeof(WorkoutMode), num))
			{
				return WorkoutMode.Unknown;
			}
			return (WorkoutMode)num;
		}
	}
	internal class PulseConverter : ConverterBase<Pulse>
	{
		public PulseConverter()
			: base(4)
		{
		}

		public override byte[] Convert(Pulse data)
		{
			byte[] array = new byte[base.Size];
			array[0] = (byte)data.UserPulse;
			array[3] = (byte)data.PulseSource;
			return array;
		}

		public override Pulse Convert(byte[] bytes)
		{
			byte userPulse = bytes[0];
			byte average = bytes[1];
			byte count = bytes[2];
			Pulse.Source source = (Pulse.Source)bytes[3];
			return new Pulse(userPulse, average, count, source);
		}
	}
	internal class ResistanceConverter : ConverterBase<double>
	{
		public static readonly List<Device> DevicesThatRequirePlusOneOnResponse = new List<Device> { Device.FitnessWeightMachine };

		private readonly IConsoleBasicInfo basicInfo;

		private readonly Device deviceType;

		private double stepSize => 10000.0 / basicInfo.MaxResistanceLevel;

		public ResistanceConverter(IConsoleBasicInfo basicInfo, Device deviceType)
			: base(2)
		{
			this.basicInfo = basicInfo;
			this.deviceType = deviceType;
		}

		public override byte[] Convert(double data)
		{
			int num = (int)(data * stepSize);
			return BitConverter.GetBytes((int)Math.Max(0.0, (double)num - stepSize * 0.1)).Take(2).ToArray();
		}

		public override double Convert(byte[] bytes)
		{
			double num = (double)(int)BitConverter.ToUInt16(bytes, 0) / stepSize;
			if (DevicesThatRequirePlusOneOnResponse.Contains(deviceType))
			{
				num += 1.0;
			}
			return Math.Round(num);
		}
	}
	internal class SpeedConverter : ConverterBase<double>
	{
		public SpeedConverter()
			: base(2)
		{
		}

		public override byte[] Convert(double data)
		{
			return BitConverter.GetBytes((int)(data * 100.0)).Take(2).ToArray();
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(int)BitConverter.ToUInt16(bytes, 0) / 100.0;
		}
	}
	internal class StringConverter : ConverterBase<string>
	{
		public StringConverter()
			: base(45)
		{
		}

		public override byte[] Convert(string data)
		{
			return Encoding.UTF8.GetBytes(data);
		}

		public override string Convert(byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes, 0, bytes.Length).Trim();
		}
	}
	internal class VerticalMeterConverter : ConverterBase<double>
	{
		public VerticalMeterConverter()
			: base(4)
		{
		}

		public override byte[] Convert(double data)
		{
			return BitConverter.GetBytes((int)(data * 10000.0));
		}

		public override double Convert(byte[] bytes)
		{
			return (double)(int)BitConverter.ToUInt32(bytes, 0) / 10000.0;
		}
	}
}
