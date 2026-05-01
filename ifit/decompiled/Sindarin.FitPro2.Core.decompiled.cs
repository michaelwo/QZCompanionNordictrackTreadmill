using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Sindarin.Core;
using Sindarin.Core.Communication;
using Sindarin.Core.Communication.Logging;
using Sindarin.Core.Connection;
using Sindarin.Core.Console;
using Sindarin.Core.DataObjects;
using Sindarin.Core.Facades;
using Sindarin.Core.Services.Fatality;
using Sindarin.Core.Util;
using Sindarin.FitPro2.Communication;
using Sindarin.FitPro2.Core;
using Sindarin.FitPro2.Core.Commands;
using Sindarin.FitPro2.Core.Communication;
using Sindarin.FitPro2.Core.DataObjects;
using Sindarin.FitPro2.Core.Features;
using Sindarin.FitPro2.Core.Features.Converters;
using Sindarin.FitPro2.Core.Resources;
using Sindarin.FitPro2.Core.Responses;
using Sindarin.FitPro2.Core.Responses.DataObjects;
using Sindarin.FitPro2.Core.Utils;
using iFit.Collections;
using iFit.Extensions;
using iFit.Logger;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: InternalsVisibleTo("Sindarin.FitPro2.Tests")]
[assembly: InternalsVisibleTo("Sindarin.FitPro2.Parser")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: AssemblyCompany("Sindarin.FitPro2.Core")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Sindarin.FitPro2.Core")]
[assembly: AssemblyTitle("Sindarin.FitPro2.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Sindarin.FitPro2.Communication
{
	internal abstract class FitProCommunicationAdapter : ICommunicationAdapter<object, IFitProCommunication>, ICommunicationAdapter, IDisposable
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

		private readonly List<IFitProCommunication> itemQueue = new List<IFitProCommunication>();

		protected readonly IFatalityService fatalityService;

		protected IDisposable decayTimer;

		private int itemsRecentlyLost;

		private SemaphoreSlim readWriteLock = new SemaphoreSlim(1, 1);

		protected readonly Subject<bool> _whenCommsFailed = new Subject<bool>();

		private readonly Subject<FeatureValue> _whenFeatureValueChanged = new Subject<FeatureValue>();

		private DateTime mostRecentFatalityTime;

		private readonly IDisposable initializedSub;

		private IDisposable eventSub;

		private IFitPro2ConsoleBasicInfo consoleBasicInfo;

		private readonly IFitProBytesLogger fitProBytesLogger;

		private readonly FeatureId[] privateFeatureIds = new FeatureId[2]
		{
			FeatureId.DriveMotorErrorCode,
			FeatureId.DriveMotorErrorTimeout
		};

		public IDeviceConnection Connection { get; protected set; }

		protected IFitProCommunication CurrentQueueItem { get; private set; }

		protected abstract int maxItemLostBeforeFatality { get; }

		protected abstract TimeSpan rateOfItemLostDecay { get; }

		protected abstract bool requiresPolling { get; }

		protected abstract TimeSpan defaultReadDelay { get; }

		public abstract ConnectionType ConnectionType { get; }

		public abstract TimeSpan DefaultTimeout { get; }

		public IObservable<bool> WhenCommsFailed => _whenCommsFailed.AsObservable();

		internal virtual IObservable<FeatureValue> WhenFeatureValueChanged => _whenFeatureValueChanged.AsObservable();

		internal event EventHandler OnBytesBeingSent;

		protected FitProCommunicationAdapter(IFitPro2ConsoleBasicInfo consoleBasicInfo, IDeviceConnection connection, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
		{
			this.consoleBasicInfo = consoleBasicInfo;
			Connection = connection;
			this.fatalityService = fatalityService;
			this.fitProBytesLogger = fitProBytesLogger;
			if (connection.Initialized)
			{
				Task.Run(async delegate
				{
					await StartCommunication();
				});
			}
			initializedSub = Connection.WhenInitialized.Where((bool x) => x).SubscribeAsyncWithErrorLogging(async delegate
			{
				await StartCommunication();
			});
		}

		private async Task StartCommunication()
		{
			eventSub?.Dispose();
			eventSub = Connection.WhenValueUpdated.Where((byte[] x) => x.IsValid()).SubscribeAsyncWithErrorLogging(HandleEvent);
			while (Connection.Initialized)
			{
				object obj = null;
				int num = 0;
				try
				{
					try
					{
						await readWriteLock.WaitAsync();
						if (itemQueue.Count != 0)
						{
							await AdjustItemQueue(AdjustmentType.Read);
							await AdjustItemQueue(AdjustmentType.Remove, 0);
							if (CurrentQueueItem == null)
							{
								Log.Trace("CommAdapter", "Current Queue Item Is Null, Class Has Been Disposed");
								goto IL_054a;
							}
							TimeSpan readDelay = CurrentQueueItem.ReadDelay;
							SendBytes(CurrentQueueItem, readDelay);
							await Task.Delay(readDelay);
							DateTime startTime = DateTime.UtcNow;
							DateTime utcNow = DateTime.UtcNow;
							while (requiresPolling && !CurrentQueueItem.IsComplete && utcNow - startTime < CurrentQueueItem.Timeout)
							{
								await Connection.ReadBytesWithDelay(defaultReadDelay);
								utcNow = DateTime.UtcNow;
							}
							if (utcNow - startTime >= CurrentQueueItem.Timeout && !CurrentQueueItem.IsComplete)
							{
								throw new TimeoutException("Timed out writing bytes: " + BitConverter.ToString(CurrentQueueItem.Request.GetRequestBytes()));
							}
						}
						else if (requiresPolling)
						{
							await Connection.ReadBytesWithDelay(defaultReadDelay);
						}
					}
					catch (Exception ex)
					{
						Log.Error("CommAdapter", $"Failed to send bytes: {ex}");
						if (CurrentQueueItem != null)
						{
							if (CurrentQueueItem.Retries < CurrentQueueItem.ShouldRetryCount && Connection.Initialized)
							{
								CurrentQueueItem.ResetForRetry();
								Log.Trace("CommAdapter", $"group responses timed out, starting retry #{CurrentQueueItem.Retries} {ex}");
								await AdjustItemQueue(AdjustmentType.Write, 0, CurrentQueueItem);
							}
							else
							{
								Log.Trace("CommAdapter", "group responses timed out, failing entire item and moving on " + BitConverter.ToString(CurrentQueueItem.Request.GetRequestBytes()));
								IncrementItemsRecentlyLost();
								CurrentQueueItem.ReceiveFailed();
							}
						}
					}
					goto end_IL_008f;
					IL_054a:
					num = 1;
					end_IL_008f:;
				}
				catch (object obj2)
				{
					obj = obj2;
				}
				readWriteLock.Release();
				await Task.Delay(defaultReadDelay);
				object obj3 = obj;
				if (obj3 != null)
				{
					ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
				}
				if (num == 1)
				{
				}
			}
		}

		private async Task HandleEvent(byte[] bytes)
		{
			if (!bytes.Any((byte b) => b != 0))
			{
				return;
			}
			this.OnBytesBeingSent?.Invoke(this, EventArgs.Empty);
			fitProBytesLogger?.LogBytes(bytes, PacketType.Response);
			if (ResponseFactory.Create(bytes) is EventResponse eventResponse)
			{
				FeatureId featureId = eventResponse.Payload.FeatureId;
				object value = eventResponse.Payload.Value;
				FitnessValue? fitnessValue = featureId.ToFitnessValue();
				if (fitnessValue.HasValue)
				{
					consoleBasicInfo.SetValue(featureId, fitnessValue.Value, value);
				}
				else if (!Enumerable.Contains(privateFeatureIds, featureId))
				{
					Log.Trace("CommAdapter", $"Unable to update ConsoleBasicInfo with {featureId} ({value}) as there is no valid FitnessValue");
				}
				if (_whenFeatureValueChanged.HasObservers)
				{
					FeatureValue value2 = new FeatureValue(featureId, value);
					_whenFeatureValueChanged.OnNext(value2);
				}
			}
			if (await DataReceived(bytes))
			{
				CurrentQueueItem?.ReceiveComplete();
			}
		}

		public virtual void Dispose()
		{
			eventSub?.Dispose();
			initializedSub?.Dispose();
			AdjustItemQueue(AdjustmentType.Clear);
			CurrentQueueItem = null;
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

		public virtual async Task<object> Fetch(IFitProCommunication comm)
		{
			AdjustItemQueue(AdjustmentType.Write, -1, comm);
			return await comm.Request.Tcs.Task;
		}

		private async Task SendBytes(IFitProCommunication comm, TimeSpan delay = default(TimeSpan))
		{
			this.OnBytesBeingSent?.Invoke(this, EventArgs.Empty);
			byte[] requestBytes = comm.Request.GetRequestBytes();
			fitProBytesLogger?.LogBytes(requestBytes, PacketType.Request);
			await Connection.SendBytesWithReadDelay(requestBytes, delay);
		}

		protected virtual async Task<bool> DataReceived(byte[] bytes)
		{
			return CurrentQueueItem?.Request?.SetResponseBytes(bytes) == true;
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
	internal readonly struct FeatureValue(FeatureId featureId, object value)
	{
		internal readonly FeatureId featureId = featureId;

		internal readonly object value = value;
	}
}
namespace Sindarin.FitPro2.Core
{
	internal enum Device : byte
	{
		App = 0,
		Console = 16,
		Controller1 = 32,
		Controller2 = 48
	}
	internal class ConsoleInfo : ConsoleInfoBase
	{
		private const string NoSerialNumber = "NO_SERIAL_NUMBER";

		public override int ModelNumber { get; }

		public override int PartNumber { get; }

		internal bool OverrideSystemMarketTypeClub { get; set; }

		public override bool IsSystemMarketTypeClub => OverrideSystemMarketTypeClub;

		public override int SoftwareVersion { get; }

		public override int HardwareVersion { get; }

		public override string FirmwareVersion { get; }

		public override int SerialNumber { get; }

		public override Manufacturer ManufacturerId { get; }

		public override ConsoleType MachineType { get; }

		public override string Name { get; }

		public override string BrainboardSerialNumber { get; }

		public override int MasterLibraryVersion { get; }

		public override int MasterLibraryBuild { get; }

		public override bool CanSetKph { get; }

		public override bool CanSetActivationLock { get; }

		public override bool CanSetIncline { get; }

		public override bool SupportsVerticalGain { get; }

		public override bool SupportsVerticalNet { get; }

		public override bool SupportsStartRequested { get; }

		public override bool SupportsRequireStartRequested { get; }

		public override bool SupportsKeyPressObserved { get; }

		public override bool SupportsPulse { get; }

		public override bool CanSetResistance { get; }

		public override bool CanSetGear { get; }

		public override bool SupportsConstantWatts { get; }

		public ConsoleInfo(IFitPro2Console console, ProductInfo productInfo)
			: base(console)
		{
			if (!(console.LatestBasicInfo is IFitPro2ConsoleBasicInfo fitPro2ConsoleBasicInfo))
			{
				throw new Exception(string.Format("LatestBasicInfo should have been {0} but was {1}", "IFitPro2ConsoleBasicInfo", console.LatestBasicInfo.GetType()));
			}
			if (int.TryParse(Regex.Replace(productInfo.ModelName, "[\\D]", string.Empty), out var result))
			{
				ModelNumber = result;
			}
			PartNumber = productInfo.SoftwarePartNumber;
			OverrideSystemMarketTypeClub = fitPro2ConsoleBasicInfo.IsClubUnit;
			SoftwareVersion = 0;
			HardwareVersion = 0;
			FirmwareVersion = productInfo.SoftwareVersion;
			SerialNumber = 0;
			ManufacturerId = Manufacturer.None;
			ConsoleType consoleType = (MachineType = fitPro2ConsoleBasicInfo.DeviceType.ToConsoleType());
			Name = productInfo.ModelName;
			if (productInfo.SerialNumber == null || productInfo.SerialNumber == "NO_SERIAL_NUMBER")
			{
				BrainboardSerialNumber = "N/A";
			}
			else
			{
				BrainboardSerialNumber = productInfo.SerialNumber;
			}
			MasterLibraryVersion = 0;
			MasterLibraryBuild = 0;
			CanSetKph = console.FeatureIdSupported(FeatureId.TargetKph) && fitPro2ConsoleBasicInfo.MaxKph > fitPro2ConsoleBasicInfo.MinKph && !consoleType.IsAerobicMachine();
			CanSetIncline = console.FeatureIdSupported(FeatureId.TargetGradePercent) && fitPro2ConsoleBasicInfo.MaxGrade > fitPro2ConsoleBasicInfo.MinGrade;
			CanSetResistance = console.FeatureIdSupported(FeatureId.TargetResistanceLevel) && fitPro2ConsoleBasicInfo.MaxResistanceLevel > 2.0;
			CanSetActivationLock = console.FeatureIdSupported(FeatureId.Activation);
			CanSetGear = console.FeatureIdSupported(FeatureId.Gear) && (fitPro2ConsoleBasicInfo.Gear?.MaxGear ?? 0) > 1;
			SupportsVerticalGain = console.FeatureIdSupported(FeatureId.VerticalMetersGain) && console.FeatureIdSupported(FeatureId.TargetGradePercent);
			SupportsVerticalNet = console.FeatureIdSupported(FeatureId.VerticalMetersNet) && console.FeatureIdSupported(FeatureId.TargetGradePercent);
			SupportsStartRequested = console.FeatureIdSupported(FeatureId.StartRequested);
			SupportsRequireStartRequested = console.FeatureIdSupported(FeatureId.StartRequested);
			SupportsConstantWatts = console.FeatureIdSupported(FeatureId.GoalWatts);
			SupportsKeyPressObserved = console.FeatureIdSupported(FeatureId.KeyCooked);
			SupportsPulse = console.FeatureIdSupported(FeatureId.Pulse);
		}
	}
	public class DriveMotorError : IConsoleError, ITimedError
	{
		public string UserFriendlyLocalizedDescription => FitPro2Strings.drive_motor_error_description.Replace("{errorCode}", $"{(int)ErrorCode}").Replace("{errorName}", $"{ErrorCode}");

		public DriveMotorErrorCode ErrorCode { get; }

		public IObservable<TimeSpan> Timeout { get; }

		public DriveMotorError(DriveMotorErrorCode errorCode, IObservable<TimeSpan> timeout)
		{
			ErrorCode = errorCode;
			Timeout = timeout;
		}
	}
	internal interface IFitPro2ConsoleBasicInfo : IConsoleBasicInfo, IFitnessValueUpdater, IDisposable
	{
		DeviceType DeviceType { get; }

		WorkoutState? LatestWorkoutState { get; }

		bool HasReceivedValueForFeatureId(FeatureId featureId);

		bool SetValue(FeatureId featureId, FitnessValue fitnessValue, object value);
	}
	internal class FitPro2ConsoleBasicInfo : ConsoleBasicInfo, IFitPro2ConsoleBasicInfo, IConsoleBasicInfo, IFitnessValueUpdater, IDisposable
	{
		private readonly HashSet<WorkoutState> validWorkoutStates = new HashSet<WorkoutState>(new WorkoutState[3]
		{
			WorkoutState.WarmUp,
			WorkoutState.Running,
			WorkoutState.CoolDown
		});

		private readonly HashSet<FeatureId> receivedFeatureIds = new HashSet<FeatureId>();

		private ConsoleType consoleType = ConsoleType.None;

		[FitnessValueProperty(FitnessValue.DeviceType)]
		public DeviceType DeviceType { get; internal set; }

		public WorkoutState? LatestWorkoutState { get; private set; }

		public FitPro2ConsoleBasicInfo(bool supportsPauseOverride = false)
			: base(supportsPauseOverride)
		{
			AddProperties(typeof(FitPro2ConsoleBasicInfo));
		}

		public bool HasReceivedValueForFeatureId(FeatureId featureId)
		{
			return receivedFeatureIds.Contains(featureId);
		}

		public bool SetValue(FeatureId featureId, FitnessValue fitnessValue, object value)
		{
			receivedFeatureIds.Add(featureId);
			try
			{
				if (featureId == FeatureId.SystemMode)
				{
					SystemMode num = (SystemMode)value;
					if (num == SystemMode.Idle)
					{
						SetValue(FitnessValue.StartRequested, false);
					}
					value = num.ToConsoleState();
					if ((ConsoleState)value == ConsoleState.Workout)
					{
						if (base.CurrentState != ConsoleState.SafetyKeyRemoved && base.CurrentState != ConsoleState.Error)
						{
							Log.Info("ConsoleBasicInfo", $"Not setting ConsoleState to {value} since we handle workout state using FeatureId.WorkoutState");
							return true;
						}
						value = ConsoleState.Paused;
					}
				}
				else if (featureId == FeatureId.WorkoutState)
				{
					WorkoutState workoutState = (WorkoutState)value;
					switch (workoutState)
					{
					case WorkoutState.None:
						Log.Info("ConsoleBasicInfo", "Received WorkoutState: None. Ignoring this");
						return true;
					case WorkoutState.ReadyToStart:
						Log.Info("ConsoleBasicInfo", "Received WorkoutState: ReadyToStart. Handling StartRequested elsewhere");
						return SetValue(FitnessValue.StartRequested, true);
					}
					if (validWorkoutStates.Contains(workoutState))
					{
						LatestWorkoutState = workoutState;
					}
					value = ((base.CurrentState == ConsoleState.SafetyKeyRemoved && workoutState == WorkoutState.Paused) ? ((object)ConsoleState.SafetyKeyRemoved) : ((base.CurrentState != ConsoleState.Error || workoutState != WorkoutState.Paused) ? ((object)workoutState.ToConsoleState()) : ((object)ConsoleState.Error)));
				}
				else if (featureId == FeatureId.KeyCooked)
				{
					KeyCode keyCode = (KeyCode)value;
					value = new KeyObj((int)keyCode, (ulong)keyCode, 0, 0);
				}
				else if (featureId == FeatureId.Pulse)
				{
					value = new Pulse(Convert.ToInt32(value), -1, 0, Pulse.Source.Hand);
				}
				else if (featureId == FeatureId.AveragePulse)
				{
					int average = Convert.ToInt32(value);
					value = new Pulse(-1, average, 1, Pulse.Source.Hand);
				}
				else if (featureId == FeatureId.Watts)
				{
					value = Convert.ToInt32(value);
				}
				else
				{
					if (featureId == FeatureId.SystemError)
					{
						return true;
					}
					if (featureId == FeatureId.DeviceType)
					{
						if (value is DeviceType deviceType)
						{
							consoleType = deviceType.ToConsoleType();
						}
					}
					else if (featureId == FeatureId.TargetKph && consoleType.IsAerobicMachine())
					{
						SetValue(FitnessValue.ActualKph, value);
					}
					else if (featureId == FeatureId.GoalWatts)
					{
						int num2 = Convert.ToInt32(value);
						SetValue(FitnessValue.IsConstantWattsMode, num2 > 0);
					}
				}
				return SetValue(fitnessValue, value);
			}
			catch (Exception arg)
			{
				Log.Error("FitPro2ConsoleBasicInfo", $"Failed to set {featureId} to {value.GetType()}: {arg}");
			}
			return false;
		}
	}
	public static class FitPro2UsbConsoleFactory
	{
		public static IFitnessConsole Create(RetryingConnection connection, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger, IFitnessConsoleManager fitnessConsoleManager)
		{
			FitPro2ConsoleBasicInfo fitPro2ConsoleBasicInfo = new FitPro2ConsoleBasicInfo();
			return new FitPro2Console(new FitProUsbConsoleCommunicationAdapter(fitPro2ConsoleBasicInfo, connection, fatalityService, fitProBytesLogger), fitPro2ConsoleBasicInfo, fitnessConsoleManager);
		}
	}
	internal interface IFitPro2Console : IFitnessConsole, ICalibrateIncline, IDisposable, IForceClubUnit
	{
		bool FeatureIdSupported(FeatureId featureId);
	}
	internal class FitPro2Console : FitnessConsoleBase, IFitPro2Console, IFitnessConsole, ICalibrateIncline, IDisposable, IForceClubUnit
	{
		private const string Tag = "FitPro2";

		private const string ConsoleErrorTag = "ConsoleError";

		private readonly IFitnessConsoleManager fitnessConsoleManager;

		private IDisposable commLossSub;

		private IDisposable driveMotorErrorSub;

		private IDisposable connectionStateChangeSub;

		private HashSet<FeatureId> supportedFeatures;

		private HashSet<FitnessValue> supportedFitnessValues;

		private readonly SemaphoreSlim subscribeLock = new SemaphoreSlim(1, 1);

		private HashSet<FeatureId> subscribedFeatures;

		private int commandsProcessing;

		private IFitPro2ConsoleBasicInfo fitPro2ConsoleBasicInfo;

		private FitProCommunicationAdapter _adapter;

		private readonly IScheduler _scheduler;

		private DriveMotorErrorCode? cachedDriveMotorErrorCode;

		private IDisposable calibrationSub;

		public override ConnectionType ConnectionType => adapter.ConnectionType;

		public override TimeSpan DefaultTimeout => adapter.DefaultTimeout;

		private FitProCommunicationAdapter Adapter => _adapter ?? (_adapter = adapter as FitProCommunicationAdapter);

		public FitPro2Console(ICommunicationAdapter adapter, IFitPro2ConsoleBasicInfo basicInfo, IFitnessConsoleManager fitnessConsoleManager, IScheduler scheduler = null)
			: base(adapter)
		{
			base.LatestBasicInfo = basicInfo;
			fitPro2ConsoleBasicInfo = basicInfo;
			base.FitnessValueChangeManager.BasicInfo = base.LatestBasicInfo;
			this.fitnessConsoleManager = fitnessConsoleManager;
			_scheduler = scheduler ?? DefaultScheduler.Instance;
			InitializeConnection();
			connectionStateChangeSub?.Dispose();
			connectionStateChangeSub = adapter.Connection.WhenConnectionStateChanged.Select((bool connected) => !connected).SubscribeWithErrorLogging(delegate
			{
				Log.Trace("FitnessConsole", "Disconnected. trying to reinitialize");
				InitializeConnection();
			});
		}

		public override async Task InitializeConsole()
		{
			connectionInitializedSub?.Dispose();
			connectionInitializedSub = null;
			Log.Trace("FitnessConsole", "OnInitChanged");
			Log.Trace("FitnessConsole", $"Base adapter isn't null: {adapter != null}");
			Log.Trace("FitnessConsole", $"FitProCommunicationAdapter isn't null: {Adapter != null}");
			commLossSub?.Dispose();
			commLossSub = adapter?.WhenCommsFailed.Where((bool x) => x).SubscribeAsyncWithErrorLogging((bool _) => Shutdown());
			supportedFeatures = await SendCommandAsync<HashSet<FeatureId>>(new SupportedFeaturesCommand());
			supportedFitnessValues = new HashSet<FitnessValue>();
			base.WritableTypes = new List<FitnessValue>();
			base.ReadableTypes = new List<FitnessValue>();
			Log.Trace("FitnessConsole", $"SupportedFeatures count {supportedFeatures?.Count ?? 0}");
			supportedFeatures.DoForEach(delegate(FeatureId x)
			{
				FitnessValue? fitnessValue = x.ToFitnessValue();
				if (fitnessValue.HasValue)
				{
					supportedFitnessValues.Add(fitnessValue.Value);
					base.ReadableTypes.Add(fitnessValue.Value);
					if (!x.IsReadOnly())
					{
						base.WritableTypes.Add(fitnessValue.Value);
					}
				}
			});
			subscribedFeatures?.Clear();
			subscribedFeatures = new HashSet<FeatureId>();
			ProductInfo productInfo = await SendCommandAsync<ProductInfo>(new ExtendedInfoCommand(ExtendedInfoType.ProductInfo));
			await SendCommandAsync<IFitProResponse>(SubscribeCommand.CreateClearSubscriptionsCommand());
			Log.Trace("FitnessConsole", $"ProductInfo isn't null: {productInfo != null}");
			List<FeatureId> source = Defaults.SubscribedFields.ToList();
			string softwareVersion = productInfo.SoftwareVersion;
			if (Version.Parse(softwareVersion.Substring(0, softwareVersion.LastIndexOf('.'))) < new Version(0, 60))
			{
				supportedFeatures.Remove(FeatureId.DriveMotorErrorCode);
				supportedFeatures.Remove(FeatureId.DriveMotorErrorTimeout);
			}
			else
			{
				driveMotorErrorSub?.Dispose();
				driveMotorErrorSub = (from featureValue in Adapter.WhenFeatureValueChanged
					where featureValue.featureId == FeatureId.DriveMotorErrorCode
					select (DriveMotorErrorCode)featureValue.value).Subscribe(delegate(DriveMotorErrorCode errorCode)
				{
					Log.Debug("ConsoleError", $"Error code {errorCode} received");
					cachedDriveMotorErrorCode = errorCode;
				});
			}
			await SubscribeIfNeeded(source.Where(supportedFeatures.Contains).ToArray());
			await WaitForInitialValues();
			base.ConsoleInfo = new ConsoleInfo(this, productInfo);
			bool idleModeLockout = !base.ConsoleInfo.SupportsRequireStartRequested || !base.ConsoleInfo.MachineType.IsBeltBasedMachine();
			SetIdleModeLockout(idleModeLockout);
			base.StartKeyEnabled = base.ConsoleInfo.SupportsRequireStartRequested;
			Adapter.OnBytesBeingSent -= HandleBytesBeingSent;
			Adapter.OnBytesBeingSent += HandleBytesBeingSent;
			if (base.ConsoleInfo.SupportsConstantWatts)
			{
				base.WritableTypes.Add(FitnessValue.IsConstantWattsMode);
				supportedFeatures.Add(FeatureId.Ignored);
			}
			Log.Trace("FitnessConsole", "Console Initialized");
			base.Initialized = true;
			fitnessConsoleManager.CurrentConsole = this;
			_whenConsoleInitialized.OnNext(base.ConsoleInfo);
		}

		protected void HandleBytesBeingSent(object sender, EventArgs e)
		{
			if (commandsProcessing == 0)
			{
				DetectControlValueChangedOnConsole();
				_detectOnBytesBeingSent.OnNext(value: true);
			}
		}

		public override async Task<IConsoleError> GetConsoleErrorAsync()
		{
			if (!supportedFeatures.Contains(FeatureId.DriveMotorErrorCode))
			{
				Log.Debug("ConsoleError", "GetConsoleErrorAsync: FeatureId.DriveMotorErrorCode is not supported");
				return null;
			}
			DriveMotorErrorCode driveMotorErrorCode = await GetDriveMotorErrorCodeAsync();
			Log.Debug("ConsoleError", $"Error code is {driveMotorErrorCode}");
			IObservable<TimeSpan> driveMotorErrorTimeoutObservable = GetDriveMotorErrorTimeoutObservable();
			return new DriveMotorError(driveMotorErrorCode, driveMotorErrorTimeoutObservable);
		}

		protected async Task<DriveMotorErrorCode> GetDriveMotorErrorCodeAsync()
		{
			if (!supportedFeatures.Contains(FeatureId.DriveMotorErrorCode))
			{
				Log.Debug("ConsoleError", "GetDriveMotorErrorCode: FeatureId.DriveMotorErrorCode is not supported");
				return DriveMotorErrorCode.Unknown;
			}
			bool num = fitPro2ConsoleBasicInfo.CurrentState == ConsoleState.Error;
			bool flag = cachedDriveMotorErrorCode.HasValue && cachedDriveMotorErrorCode != DriveMotorErrorCode.None;
			if (num && flag)
			{
				Log.Debug("ConsoleError", $"GetDriveMotorErrorCode: current state = {fitPro2ConsoleBasicInfo.CurrentState}, cached error code = {cachedDriveMotorErrorCode}");
				return cachedDriveMotorErrorCode ?? DriveMotorErrorCode.Unknown;
			}
			try
			{
				TimeSpan timeout = TimeSpan.FromSeconds(2.5);
				DriveMotorErrorCode driveMotorErrorCode = await GetNextValueAsync<DriveMotorErrorCode>(FeatureId.DriveMotorErrorCode, timeout).ConfigureAwait(continueOnCapturedContext: false);
				Log.Debug("ConsoleError", $"GetDriveMotorErrorCode: received error code {driveMotorErrorCode}");
				return driveMotorErrorCode;
			}
			catch (TimeoutException)
			{
				Log.Debug("ConsoleError", "GetDriveMotorErrorCode: timeout");
				return cachedDriveMotorErrorCode ?? DriveMotorErrorCode.Unknown;
			}
		}

		private Task<TValue> GetNextValueAsync<TValue>(FeatureId featureId, TimeSpan timeout)
		{
			return (from featureValue in Adapter.WhenFeatureValueChanged
				where featureValue.featureId == featureId
				select (TValue)featureValue.value).Take(1).Timeout(timeout, _scheduler).ToTask();
		}

		protected IObservable<TimeSpan> GetDriveMotorErrorTimeoutObservable()
		{
			if (!supportedFeatures.Contains(FeatureId.DriveMotorErrorTimeout))
			{
				Log.Debug("ConsoleError", "GetDriveMotorErrorTimeoutObservable: FeatureId.DriveMotorErrorTimeout is not supported");
				return null;
			}
			TimeSpan dueTime = TimeSpan.FromSeconds(2.5);
			return (from featureValue in Adapter.WhenFeatureValueChanged.Where((FeatureValue featureValue) => featureValue.featureId == FeatureId.DriveMotorErrorTimeout).DistinctUntilChanged()
				select TimeSpan.FromSeconds((int)featureValue.value)).Timeout(dueTime, _scheduler).Do(delegate(TimeSpan value)
			{
				Log.Debug("ConsoleError", $"GetDriveMotorErrorTimeoutObservable: observed value {value}");
			});
		}

		private async Task WaitForInitialValues()
		{
			HashSet<FeatureId> pendingFeatureValues = new HashSet<FeatureId>(subscribedFeatures.Where((FeatureId f) => f.ToFitnessValue().HasValue));
			while (!ContainsPendingFeatureValues())
			{
				pendingFeatureValues.RemoveWhere(fitPro2ConsoleBasicInfo.HasReceivedValueForFeatureId);
				await Task.Delay(TimeSpan.FromMilliseconds(50.0));
			}
			bool ContainsPendingFeatureValues()
			{
				return pendingFeatureValues.All(fitPro2ConsoleBasicInfo.HasReceivedValueForFeatureId);
			}
		}

		private async Task<object> SubscribeIfNeeded(params FeatureId[] featureIds)
		{
			_ = 1;
			try
			{
				await subscribeLock.WaitAsync();
				FeatureId[] newFeatures = featureIds.Where((FeatureId x) => supportedFeatures.Contains(x) && !subscribedFeatures.Contains(x)).ToArray();
				if (newFeatures.Length == 0)
				{
					return null;
				}
				List<SubscribeCommand> list = SubscribeCommand.CreateSubscribeCommands(newFeatures);
				List<IFitProResponse> results = new List<IFitProResponse>();
				foreach (SubscribeCommand item in list)
				{
					results.Add(await SendCommandAsync<IFitProResponse>(item));
				}
				if (results.All((IFitProResponse x) => x is EventResponse))
				{
					subscribedFeatures.UnionWith(newFeatures);
				}
				if (results.FirstOrDefault() is EventResponse eventResponse)
				{
					return eventResponse.Payload.Value;
				}
			}
			finally
			{
				subscribeLock.Release();
			}
			return null;
		}

		private async Task Unsubscribe(FeatureId featureId)
		{
			SubscribeCommand command = SubscribeCommand.CreateUnsubscribeCommands(featureId).Single();
			if (!((await SendCommandAsync<IFitProResponse>(command)) is ErrorResponse))
			{
				subscribedFeatures.Remove(featureId);
			}
		}

		protected virtual async Task<T> SendCommandAsync<T>(CommandBase command) where T : class
		{
			return (await Adapter.Fetch(new FitProCommunication(command, ConnectionType))) as T;
		}

		public override bool FitnessValueSupported(FitnessValue value)
		{
			return supportedFitnessValues.Contains(value);
		}

		public bool FeatureIdSupported(FeatureId featureId)
		{
			return supportedFeatures.Contains(featureId);
		}

		protected override async Task<bool> SetValidatedValuesAsync((FitnessValue, object)[] values)
		{
			bool success = false;
			try
			{
				for (int i = 0; i < values.Length; i++)
				{
					(FitnessValue, object) tuple = values[i];
					success = await ProcessFitnessValue(tuple.Item1, tuple.Item2);
				}
			}
			catch (Exception ex)
			{
				Log.Warn("FitPro2", $"Failed to send values: {ex.InnerException}");
				commandsProcessing = Math.Max(commandsProcessing - 1, 0);
			}
			return success;
		}

		private async Task<bool> ProcessFitnessValue(FitnessValue fitnessValue, object value)
		{
			FeatureId? featureId = fitnessValue.ToFeatureId();
			if (!featureId.HasValue)
			{
				Log.Warn("FitPro2", $"Could not set {fitnessValue} to {value}. No corresponding mapping to FeatureId");
				return false;
			}
			if (value == null)
			{
				Log.Warn("FitPro2", $"Could not set {fitnessValue}. value is null");
				return false;
			}
			if (!FeatureIdSupported(featureId.Value))
			{
				Log.Info("FitPro2", $"Could not set {fitnessValue} to {value}. \"{featureId}\" not supported on this machine.");
				return false;
			}
			FeatureId featureId2 = featureId.Value;
			string arg = value?.ToString();
			HandleSpecialCases(fitnessValue, ref featureId2, ref value);
			if (value == null)
			{
				Log.Warn("FitPro2", $"Could not set {fitnessValue} {arg}");
				return false;
			}
			commandsProcessing++;
			bool success = false;
			IFitProResponse fitProResponse = await SendCommandAsync<IFitProResponse>(new WriteCommand(fitPro2ConsoleBasicInfo, featureId2, value));
			if (fitProResponse is ErrorResponse errorResponse)
			{
				Log.Error("FitPro2", $"Could not set {fitnessValue} to {value}. {errorResponse.Payload}");
			}
			else if (fitProResponse is AcknowledgeResponse)
			{
				success = true;
				switch (featureId2)
				{
				case FeatureId.TargetKph:
					lastKphValue = base.LatestBasicInfo.Kph;
					break;
				case FeatureId.TargetGradePercent:
					lastGradeValue = base.LatestBasicInfo.Grade;
					break;
				case FeatureId.TargetResistanceLevel:
					lastResistanceValue = base.LatestBasicInfo.Resistance;
					break;
				case FeatureId.Gear:
					lastGearValue = base.LatestBasicInfo.Gear?.CurrentGear;
					break;
				}
			}
			commandsProcessing = Math.Max(commandsProcessing - 1, 0);
			return success;
		}

		private void HandleSpecialCases(FitnessValue fitnessValue, ref FeatureId featureId, ref object value)
		{
			if (featureId == FeatureId.TargetResistancePercent)
			{
				value = null;
				return;
			}
			if (fitnessValue == FitnessValue.IsConstantWattsMode)
			{
				if ((bool)value)
				{
					value = null;
					return;
				}
				featureId = FeatureId.GoalWatts;
				value = 0;
			}
			if (fitnessValue == FitnessValue.WorkoutMode)
			{
				featureId = FeatureId.WorkoutState;
				if (value is ConsoleState consoleState)
				{
					if (consoleState == ConsoleState.Resume)
					{
						if (fitPro2ConsoleBasicInfo.LatestWorkoutState.HasValue)
						{
							value = fitPro2ConsoleBasicInfo.LatestWorkoutState.Value;
						}
						else
						{
							value = null;
						}
					}
					else
					{
						value = consoleState.ToWorkoutState();
					}
					return;
				}
				value = null;
			}
			if (fitnessValue == FitnessValue.Kph && value != null && (double)value < 0.5)
			{
				value = null;
			}
		}

		public override async Task SetSubscribed(bool subscribe, FitnessValue type)
		{
			FeatureId? featureId = type.ToFeatureId();
			if (featureId.HasValue)
			{
				if (subscribe)
				{
					await SubscribeIfNeeded(featureId.Value);
				}
				else
				{
					await Unsubscribe(featureId.Value);
				}
			}
		}

		public override async Task<object> GetValueAsync(FitnessValue type)
		{
			FeatureId? featureId = type.ToFeatureId();
			if (featureId.HasValue)
			{
				object result = await SubscribeIfNeeded(featureId.Value);
				if (result != null)
				{
					await Unsubscribe(featureId.Value);
					return result;
				}
			}
			else
			{
				Log.Info("FitPro2", "Failed to convert " + type);
			}
			return base.FitnessValueChangeManager.GetLatestValue(type);
		}

		public override async void CalibrateIncline()
		{
			_ = 1;
			try
			{
				await SubscribeIfNeeded(FeatureId.CalibrateGrade);
				calibrationSub?.Dispose();
				calibrationSub = (from featureValue in Adapter.WhenFeatureValueChanged
					where featureValue.featureId == FeatureId.CalibrateGrade
					select (CalibrationState)featureValue.value).Timeout(TimeSpan.FromMinutes(4.0)).Subscribe(HandleNextCalibrationState, HandleCalibrationStateException, HandleCalibrationStateComplete);
				WriteCommand command = new WriteCommand(fitPro2ConsoleBasicInfo, FeatureId.CalibrateGrade, CalibrationState.Start);
				if (await SendCommandAsync<IFitProResponse>(command) is ErrorResponse errorResponse)
				{
					Log.Warn("FitPro2", $"Failed to start incline calibration: {errorResponse.Payload}");
					DisposeCalibrationStateSubscription();
					_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Failed);
				}
				else
				{
					_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.InProgress);
				}
			}
			catch (Exception arg)
			{
				Log.Warn("FitPro2", $"Failed to start incline calibration: {arg}");
				DisposeCalibrationStateSubscription();
			}
		}

		private void HandleNextCalibrationState(CalibrationState state)
		{
			switch (state)
			{
			case CalibrationState.Success:
				_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Done);
				DisposeCalibrationStateSubscription();
				break;
			case CalibrationState.Failure:
				_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Failed);
				DisposeCalibrationStateSubscription();
				break;
			}
		}

		private void HandleCalibrationStateException(Exception exception)
		{
			if (exception is TimeoutException)
			{
				Log.Trace("FitnessConsole", "Incline calibration completed by timeout");
				_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Done);
			}
			else
			{
				Log.Trace("FitnessConsole", "Incline calibration failed with exception => `" + exception.Message + "`");
				_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Failed);
			}
			DisposeCalibrationStateSubscription();
		}

		private void HandleCalibrationStateComplete()
		{
			DisposeCalibrationStateSubscription();
		}

		private void DisposeCalibrationStateSubscription()
		{
			calibrationSub?.Dispose();
			calibrationSub = null;
		}

		public override void Dispose()
		{
			base.Dispose();
			driveMotorErrorSub?.Dispose();
			driveMotorErrorSub = null;
			connectionStateChangeSub?.Dispose();
			connectionStateChangeSub = null;
			DisposeCalibrationStateSubscription();
		}

		public void ToggleClubStatus()
		{
			bool isClub = base.ConsoleInfo.IsClub;
			base.LatestBasicInfo.SetValue(FitnessValue.IsClubUnit, !isClub);
			if (base.ConsoleInfo is ConsoleInfo consoleInfo)
			{
				consoleInfo.OverrideSystemMarketTypeClub = isClub;
			}
		}

		protected override async Task Shutdown()
		{
			await base.Shutdown();
		}
	}
}
namespace Sindarin.FitPro2.Core.Utils
{
	internal static class DeviceCommandExtensions
	{
		public static byte WithDevice(this Command command, Device device)
		{
			return (byte)((uint)command | (uint)device);
		}

		public static byte WithCommand(this Device device, Command command)
		{
			return (byte)((uint)command | (uint)device);
		}

		public static (Device Device, Command Command) ToDeviceCommand(this byte raw)
		{
			byte item = (byte)(raw & 0xF0);
			byte item2 = (byte)(raw & 0xF);
			return (Device: (Device)item, Command: (Command)item2);
		}
	}
	internal static class DeviceResponseExtensions
	{
		public static byte WithDevice(this Response response, Device device)
		{
			return (byte)((uint)response | (uint)device);
		}

		public static byte WithResponse(this Device device, Response response)
		{
			return (byte)((uint)response | (uint)device);
		}

		public static (Device Device, Response Response) ToDeviceResponse(this byte raw)
		{
			byte item = (byte)(raw & 0xF0);
			byte item2 = (byte)(raw & 0xF);
			return (Device: (Device)item, Response: (Response)item2);
		}
	}
	internal static class FitnessValueExtensions
	{
		private const string Tag = "FitnessValue";

		public static FeatureId? ToFeatureId(this FitnessValue value)
		{
			switch (value)
			{
			case FitnessValue.Kph:
				return FeatureId.TargetKph;
			case FitnessValue.Grade:
				return FeatureId.TargetGradePercent;
			case FitnessValue.AverageGrade:
				return FeatureId.AverageGradePercent;
			case FitnessValue.Resistance:
				return FeatureId.TargetResistanceLevel;
			case FitnessValue.Watts:
				return FeatureId.Watts;
			case FitnessValue.WattGoal:
				return FeatureId.GoalWatts;
			case FitnessValue.CurrentDistance:
				return FeatureId.Distance;
			case FitnessValue.Rpm:
				return FeatureId.Rpm;
			case FitnessValue.KeyObject:
				return FeatureId.KeyCooked;
			case FitnessValue.Volume:
				return FeatureId.VolumePercent;
			case FitnessValue.Pulse:
				return FeatureId.Pulse;
			case FitnessValue.RunningTime:
				return FeatureId.RunningTime;
			case FitnessValue.WorkoutMode:
				return FeatureId.WorkoutState;
			case FitnessValue.ActualKph:
				return FeatureId.CurrentKph;
			case FitnessValue.ActualIncline:
				return FeatureId.CurrentGradePercent;
			case FitnessValue.CurrentTime:
				return FeatureId.RunningTime;
			case FitnessValue.CurrentCalories:
				return FeatureId.CurrentCalories;
			case FitnessValue.GoalTime:
				return FeatureId.GoalTime;
			case FitnessValue.Weight:
				return FeatureId.UserWeightKg;
			case FitnessValue.Gear:
				return FeatureId.Gear;
			case FitnessValue.MaxGrade:
				return FeatureId.MaxGradePercent;
			case FitnessValue.MinGrade:
				return FeatureId.MinGradePercent;
			case FitnessValue.MaxKph:
				return FeatureId.MaxKph;
			case FitnessValue.MinKph:
				return FeatureId.MinKph;
			case FitnessValue.PauseTimeout:
				return FeatureId.PauseTimeout;
			case FitnessValue.SystemUnits:
				return FeatureId.DisplayUnits;
			case FitnessValue.MaxResistanceLevel:
				return FeatureId.MaxResistance;
			case FitnessValue.MaxWeight:
				return FeatureId.MaxUserWeightKg;
			case FitnessValue.WarmupTimeout:
				return FeatureId.WarmUpTimeout;
			case FitnessValue.CoolDownTimeout:
				return FeatureId.CoolDownTimeout;
			case FitnessValue.MaxPulse:
				return FeatureId.MaxPulse;
			case FitnessValue.AverageWatts:
				return FeatureId.AverageWatts;
			case FitnessValue.DistanceGoal:
				return FeatureId.DistanceGoal;
			case FitnessValue.MotorTotalDistance:
				return FeatureId.TotalMachineDistance;
			case FitnessValue.TotalTime:
				return FeatureId.TotalInUseTimeSeconds;
			case FitnessValue.VerticalMeterNet:
				return FeatureId.VerticalMetersNet;
			case FitnessValue.VerticalMeterGain:
				return FeatureId.VerticalMetersGain;
			case FitnessValue.IdleModeLockout:
				return FeatureId.IdleSystemModeLock;
			case FitnessValue.StartRequested:
				return FeatureId.StartRequested;
			case FitnessValue.FanState:
				return FeatureId.FanState;
			case FitnessValue.ActivationLock:
				return FeatureId.Activation;
			case FitnessValue.PausedTime:
				return FeatureId.PauseCountdown;
			case FitnessValue.Strokes:
				return FeatureId.RowerTotalStrokes;
			case FitnessValue.StrokesPerMin:
				return FeatureId.RowerStrokesPerMin;
			case FitnessValue.FiveHundredSplit:
				return FeatureId.Rower500Split;
			case FitnessValue.AvgFiveHundredSplit:
				return FeatureId.RowerAverage500Split;
			case FitnessValue.IsClubUnit:
				return FeatureId.ClubUnit;
			case FitnessValue.IsReadyToDisconnect:
				return FeatureId.RequestDisconnect;
			case FitnessValue.MaxRpm:
				return FeatureId.MaxRpm;
			case FitnessValue.IsConstantWattsMode:
				return FeatureId.Ignored;
			case FitnessValue.FiveHundredSplitDecimal:
				return FeatureId.Rower500Split;
			default:
				Log.Error("FitnessValue", $"No mapped FeatureId for FitnessValue {value}");
				return null;
			}
		}
	}
}
namespace Sindarin.FitPro2.Core.Responses
{
	internal class AcknowledgeResponse : ResponseBase<Command>
	{
		protected override int MinPayloadLength => 1;

		public AcknowledgeResponse(Device device, byte payloadLength, byte[] payload)
			: base(device, Response.Acknowledge, payloadLength, payload)
		{
		}

		protected override Command ParsePayload(byte[] bytes)
		{
			return bytes[0].ToDeviceCommand().Command;
		}
	}
	internal class ErrorResponse : ResponseBase<ErrorData>
	{
		protected override int MinPayloadLength => 2;

		public ErrorResponse(Device device, byte payloadLength, byte[] payload)
			: base(device, Response.Error, payloadLength, payload)
		{
		}

		protected override ErrorData ParsePayload(byte[] bytes)
		{
			return ErrorData.FromPayload(bytes, payloadLength);
		}

		public override string ToString()
		{
			return $"{base.Device}:{base.Response} - {base.Payload}";
		}
	}
	internal class EventResponse : ResponseBase<EventData>
	{
		protected override int MinPayloadLength => 6;

		public EventResponse(Device device, byte payloadLength, byte[] payload)
			: base(device, Response.Event, payloadLength, payload)
		{
		}

		protected override EventData ParsePayload(byte[] bytes)
		{
			return EventData.FromBytes(bytes);
		}
	}
	internal class ExtendedResponse : ResponseBase<ExtendedData>
	{
		protected override int MinPayloadLength => 2;

		public ExtendedResponse(Device device, byte payloadLength, byte[] payload)
			: base(device, Response.Extended, payloadLength, payload)
		{
		}

		protected override ExtendedData ParsePayload(byte[] bytes)
		{
			return ExtendedData.FromPayload(bytes);
		}
	}
	internal class FeaturesResponse : ResponseBase<List<FeatureId>>
	{
		protected override int MinPayloadLength => 0;

		public FeaturesResponse(Device device, byte payloadLength, byte[] payload)
			: base(device, Response.Features, payloadLength, payload)
		{
		}

		protected override void VerifyPayload(byte[] bytes)
		{
			base.VerifyPayload(bytes);
			if (payloadLength % 2 != 0)
			{
				throw new ArgumentException($"{GetType()} should have an evenly-sized payload, but payload was {payloadLength} bytes");
			}
		}

		protected override List<FeatureId> ParsePayload(byte[] bytes)
		{
			List<FeatureId> list = new List<FeatureId>();
			for (int i = 0; i < payloadLength; i += 2)
			{
				FeatureId item = FeatureIdHelper.FromBytes(bytes[i], bytes[i + 1]);
				list.Add(item);
			}
			return list;
		}

		public override string ToString()
		{
			return string.Format("{0}:{1} - {2}", base.Device, base.Response, (base.Payload.Count == 0) ? "End of List" : string.Join(", ", base.Payload));
		}
	}
	[Flags]
	internal enum Response : byte
	{
		Features = 1,
		Acknowledge = 3,
		Error = 4,
		Event = 5,
		Extended = 0xE
	}
	internal interface IFitProResponse
	{
		Device Device { get; }

		Response Response { get; }
	}
	internal interface IFitProResponse<T> : IFitProResponse
	{
		T Payload { get; }
	}
	internal abstract class ResponseBase<T> : IFitProResponse<T>, IFitProResponse
	{
		protected readonly byte payloadLength;

		public Device Device { get; }

		public Response Response { get; }

		public T Payload { get; }

		protected abstract int MinPayloadLength { get; }

		internal ResponseBase(Device device, Response response, byte payloadLength, byte[] payload)
		{
			Device = device;
			Response = response;
			this.payloadLength = payloadLength;
			VerifyPayload(payload);
			Payload = ParsePayload(payload);
		}

		protected virtual void VerifyPayload(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentException($"Unable to parse payload of {GetType()} since it is null");
			}
			if (bytes.Length < MinPayloadLength)
			{
				throw new ArgumentException($"Unable to parse payload of {GetType()} since its length is less than {MinPayloadLength}");
			}
		}

		protected abstract T ParsePayload(byte[] bytes);

		public override string ToString()
		{
			return $"{Device}:{Response} - {Payload}";
		}
	}
	internal static class ResponseFactory
	{
		private const int ResponseOverhead = 3;

		public static IFitProResponse Create(byte[] bytes)
		{
			if (bytes == null || bytes.Length < 3)
			{
				throw new ArgumentException("Unable to create IFitProResponse from bytes", "bytes");
			}
			_ = bytes[0];
			(Device Device, Response Response) tuple = bytes[1].ToDeviceResponse();
			Device item = tuple.Device;
			Response item2 = tuple.Response;
			byte b = bytes[2];
			byte[] payload = bytes.Skip(3).Take(b).ToArray();
			return item2 switch
			{
				Response.Features => new FeaturesResponse(item, b, payload), 
				Response.Acknowledge => new AcknowledgeResponse(item, b, payload), 
				Response.Error => new ErrorResponse(item, b, payload), 
				Response.Event => new EventResponse(item, b, payload), 
				Response.Extended => new ExtendedResponse(item, b, payload), 
				_ => throw new IndexOutOfRangeException($"Could not create response with Response ID of {item2} {BitConverter.ToString(bytes)}"), 
			};
		}
	}
}
namespace Sindarin.FitPro2.Core.Responses.DataObjects
{
	internal enum ErrorType
	{
		NoError,
		Unassigned,
		Framing,
		FeaturesNotSupported,
		WriteNotSupported,
		DataOutOfRange,
		CommandNotSupported,
		WriteValueNotAllowed
	}
	internal class ErrorData
	{
		public Command ErroneousCommand { get; }

		public ErrorType ErrorValue { get; }

		public IErrorInfo ErrorInfo { get; }

		private ErrorData(Command erroneousCommand, ErrorType errorValue, IErrorInfo errorInfo)
		{
			ErroneousCommand = erroneousCommand;
			ErrorValue = errorValue;
			ErrorInfo = errorInfo;
		}

		public static ErrorData FromPayload(byte[] bytes, int payloadLength)
		{
			Command item = bytes[0].ToDeviceCommand().Command;
			ErrorType errorType = (ErrorType)bytes[1];
			IErrorInfo errorInfo = GetErrorInfo(errorType, bytes.Skip(2).Take(payloadLength - 2).ToArray());
			return new ErrorData(item, errorType, errorInfo);
		}

		private static IErrorInfo GetErrorInfo(ErrorType errorType, byte[] payload)
		{
			switch (errorType)
			{
			case ErrorType.NoError:
			case ErrorType.Unassigned:
			case ErrorType.Framing:
			case ErrorType.CommandNotSupported:
				return new NoErrorInfo();
			case ErrorType.FeaturesNotSupported:
				return new UnsupportedFeatureInfo(payload);
			case ErrorType.WriteNotSupported:
				return new WriteNotSupported(payload);
			case ErrorType.DataOutOfRange:
				return new OutOfRangeInfo(payload);
			case ErrorType.WriteValueNotAllowed:
				return new WriteValueNotAllowedInfo(payload);
			default:
				throw new ArgumentOutOfRangeException($"Unable to get error info from ErrorType {errorType}");
			}
		}

		public override string ToString()
		{
			return $"Command: {ErroneousCommand}, Value: {ErrorValue}, Info: {ErrorInfo}";
		}
	}
	internal interface IErrorInfo
	{
	}
	internal interface IFeatureIdErrorInfo : IErrorInfo
	{
		FeatureId? FeatureId { get; }
	}
	internal class NoErrorInfo : IErrorInfo
	{
		public override string ToString()
		{
			return "None";
		}
	}
	internal class UnsupportedFeatureInfo : IErrorInfo
	{
		public List<FeatureId> UnsupportedFeatures { get; }

		public UnsupportedFeatureInfo(byte[] bytes)
		{
			List<FeatureId> list = new List<FeatureId>();
			for (int i = 0; i < bytes.Length; i += 2)
			{
				FeatureId item = FeatureIdHelper.FromBytes(bytes[i], bytes[i + 1]);
				list.Add(item);
			}
			UnsupportedFeatures = list;
		}

		public override string ToString()
		{
			return string.Join(", ", UnsupportedFeatures.Select((FeatureId x) => x.ToString())) ?? "";
		}
	}
	internal class WriteNotSupported : IFeatureIdErrorInfo, IErrorInfo
	{
		public FeatureId? FeatureId { get; }

		public WriteNotSupported(byte[] bytes)
		{
			FeatureId = FeatureIdHelper.FromBytes(bytes[0], bytes[1]);
		}

		public override string ToString()
		{
			return $"{FeatureId}";
		}
	}
	internal class OutOfRangeInfo : IFeatureIdErrorInfo, IErrorInfo
	{
		public FeatureId? FeatureId { get; }

		public float ExceededValue { get; }

		public OutOfRangeInfo(byte[] bytes)
		{
			FeatureId = FeatureIdHelper.FromBytes(bytes[0], bytes[1]);
			ExceededValue = BitConverter.ToSingle(bytes, 2);
		}

		public override string ToString()
		{
			return $"Feature Id written to: {FeatureId}, Exceeded value: {ExceededValue}";
		}
	}
	internal class WriteValueNotAllowedInfo : IFeatureIdErrorInfo, IErrorInfo
	{
		public FeatureId? FeatureId { get; }

		public float? NotAllowedValue { get; }

		public WriteValueNotAllowedInfo(byte[] bytes)
		{
			if (bytes.Length >= 2)
			{
				FeatureId = FeatureIdHelper.FromBytes(bytes[0], bytes[1]);
				if (bytes.Length >= 3)
				{
					NotAllowedValue = BitConverter.ToSingle(bytes, 2);
				}
			}
		}

		public override string ToString()
		{
			return $"Feature Id written to: {FeatureId}, Value was not allowed: {NotAllowedValue}";
		}
	}
	internal class EventData
	{
		public FeatureId FeatureId { get; }

		public float Raw { get; }

		public object Value { get; }

		private EventData(FeatureId featureId, float raw, object value)
		{
			FeatureId = featureId;
			Raw = raw;
			Value = value;
		}

		public override string ToString()
		{
			return $"{FeatureId}: ({Value})";
		}

		public static EventData FromBytes(byte[] bytes)
		{
			FeatureId featureId = FeatureIdHelper.FromBytes(bytes[0], bytes[1]);
			float num = BitConverter.ToSingle(bytes, 2);
			object value = num;
			if (Enum.IsDefined(typeof(FeatureId), featureId))
			{
				value = featureId.GetConverter().FloatToData(num);
			}
			else
			{
				Log.Warn("EventResponse", $"No FeatureId defined: {featureId}, value: {num}");
			}
			return new EventData(featureId, num, value);
		}
	}
	internal class ExtendedData
	{
		public ExtendedInfoType ExtendedInfoType { get; }

		public IExtendedInfo ExtendedInfo { get; }

		private ExtendedData(ExtendedInfoType extendedInfoType, IExtendedInfo extendedInfo)
		{
			ExtendedInfoType = extendedInfoType;
			ExtendedInfo = extendedInfo;
		}

		public override string ToString()
		{
			return $"{ExtendedInfoType}:{ExtendedInfo}";
		}

		public static ExtendedData FromPayload(byte[] bytes)
		{
			byte num = bytes[0];
			IExtendedInfo extendedInfo = GetExtendedInfo((ExtendedInfoType)num, bytes.Skip(1).ToArray());
			return new ExtendedData((ExtendedInfoType)num, extendedInfo);
		}

		private static IExtendedInfo GetExtendedInfo(ExtendedInfoType infoType, byte[] payload)
		{
			switch (infoType)
			{
			case ExtendedInfoType.Unknown:
			case ExtendedInfoType.FileSystem:
				return new NoExtendedInfo();
			case ExtendedInfoType.ProductInfo:
				return new ExtendedProductInfo(payload);
			default:
				throw new ArgumentOutOfRangeException($"Unable to get extended info from ExtendedInfo {infoType}");
			}
		}
	}
	internal interface IExtendedInfo
	{
	}
	internal class NoExtendedInfo : IExtendedInfo
	{
	}
	internal class ExtendedProductInfo : IExtendedInfo
	{
		public ProductInfoType InfoType { get; }

		public string Info { get; }

		public ExtendedProductInfo(byte[] payload)
		{
			InfoType = (ProductInfoType)payload[0];
			Info = Encoding.UTF8.GetString(payload, 1, payload.Length - 1);
		}

		public override string ToString()
		{
			return $"{InfoType}:{Info}";
		}
	}
	internal enum ProductInfoType
	{
		EndOfList,
		SoftwareVersion,
		SoftwarePartNumber,
		HardwarePartNumber,
		ModelName,
		SerialNumber,
		DisplayType,
		AntPlusDeviceNumber,
		AntPlusDeviceType,
		MotorControllerVersion,
		MotorControllerParametersChecksum,
		AntPlusRelaySoftwareVersion,
		AntPlusRelayBootloaderVersion
	}
}
namespace Sindarin.FitPro2.Core.Features
{
	public enum DriveMotorErrorCode
	{
		None = 0,
		SafetyKeyTimeout = 21,
		NoResponse = 100,
		Crc = 101,
		Partial = 102,
		Unknown = 103,
		ParameterCrc = 110
	}
	internal static class FeatureExtensions
	{
		private const string Tag = "FitPro2";

		private static readonly SemaphoreSlim threadLock = new SemaphoreSlim(1);

		private static readonly Dictionary<FeatureId, FeatureInfo> FeatureInfoMapping = new Dictionary<FeatureId, FeatureInfo>();

		public static IFeatureConverter GetConverter(this FeatureId item)
		{
			return GetOrFetch(item).Converter;
		}

		public static bool IsReadOnly(this FeatureId item)
		{
			try
			{
				return GetOrFetch(item).ReadOnly;
			}
			catch (Exception)
			{
				Log.Error("FitPro2", $"Failed to retrieve Feature {item}");
			}
			return true;
		}

		public static void Clear()
		{
			threadLock.Wait();
			try
			{
				FeatureInfoMapping.Clear();
			}
			finally
			{
				threadLock.Release();
			}
		}

		private static FeatureInfo GetOrFetch(FeatureId item)
		{
			threadLock.Wait();
			try
			{
				if (!FeatureInfoMapping.ContainsKey(item))
				{
					FeatureInfoMapping[item] = item.GetAttribute<FeatureInfo>();
				}
			}
			finally
			{
				threadLock.Release();
			}
			return FeatureInfoMapping[item];
		}

		public static FitnessValue? ToFitnessValue(this FeatureId item)
		{
			switch (item)
			{
			case FeatureId.SoftwareMajorVersion:
			case FeatureId.SoftwareMinorVersion:
			case FeatureId.SoftwarePatchVersion:
			case FeatureId.HardwarePartNumber:
			case FeatureId.SoftwarePartNumber:
			case FeatureId.UsbHostBoardVersion:
			case FeatureId.UserAgeYears:
			case FeatureId.HoursTimeSinceStartup:
			case FeatureId.CsafeMaster:
			case FeatureId.USBHostBoardVersion:
			case FeatureId.TabletConnectionStatus:
			case FeatureId.FanLevelPercent:
			case FeatureId.FanAutoSupport:
			case FeatureId.FanDefaultPercentOnStart:
			case FeatureId.BleAdvertising:
			case FeatureId.CommSuccessRatePercent:
			case FeatureId.DisplayLanguage:
			case FeatureId.KeyArray1:
			case FeatureId.KeyArray2:
			case FeatureId.KeyArray3:
			case FeatureId.KeyArray4:
			case FeatureId.KeyArray5:
			case FeatureId.KeyArray6:
			case FeatureId.KeyArray7:
			case FeatureId.KeyArray8:
			case FeatureId.CaloriesGoal:
			case FeatureId.PulseGoal:
			case FeatureId.PairHrm:
			case FeatureId.Hrm1Id:
			case FeatureId.Hrm1SignalStrength:
			case FeatureId.Hrm2Id:
			case FeatureId.Hrm2SignalStrength:
			case FeatureId.Hrm3Id:
			case FeatureId.Hrm3SignalStrength:
			case FeatureId.Hrm4Id:
			case FeatureId.Hrm4SignalStrength:
			case FeatureId.Hrm5Id:
			case FeatureId.Hrm5SignalStrength:
			case FeatureId.BeltTotalHours:
			case FeatureId.BeltTotalMeters:
			case FeatureId.BeltReplaced:
			case FeatureId.DistanceDriveMotorTotalHours:
			case FeatureId.DriveMotorTotalMeters:
			case FeatureId.MotorReplaced:
			case FeatureId.WorkoutMaxKph:
			case FeatureId.PedalPosition:
			case FeatureId.AverageRpm:
			case FeatureId.RpmGoal:
			case FeatureId.PhysicalMinPercent:
			case FeatureId.PhysicalMaxPercent:
			case FeatureId.WorkoutMaxGradePercent:
			case FeatureId.VerticalClimbGoalMeters:
			case FeatureId.CalibrateGrade:
			case FeatureId.GradeFeedbackRange:
			case FeatureId.GradeMotorHours:
			case FeatureId.GradeMotorReplaced:
			case FeatureId.TargetResistancePercent:
			case FeatureId.CurrentResistancePercent:
			case FeatureId.MaxWatts:
			case FeatureId.GoalType:
			case FeatureId.WarmUpTime:
			case FeatureId.CoolDownTime:
			case FeatureId.OffMachineTime:
			case FeatureId.ExitWorkoutRequested:
			case FeatureId.ResultsTimeout:
			case FeatureId.OffMachineTimeout:
			case FeatureId.ResultsCountdown:
			case FeatureId.WorkoutCountdown:
			case FeatureId.DriveMotorErrorCode:
			case FeatureId.DriveMotorErrorTimeout:
				return null;
			case FeatureId.MaxRpm:
				return FitnessValue.MaxRpm;
			case FeatureId.CurrentKph:
				return FitnessValue.ActualKph;
			case FeatureId.AverageKph:
				return FitnessValue.AvgSpeedKph;
			case FeatureId.CurrentGradePercent:
				return FitnessValue.ActualIncline;
			case FeatureId.ClubUnit:
				return FitnessValue.IsClubUnit;
			case FeatureId.DeviceType:
				return FitnessValue.DeviceType;
			case FeatureId.SystemMode:
				return FitnessValue.WorkoutMode;
			case FeatureId.IdleSystemModeLock:
				return FitnessValue.IdleModeLockout;
			case FeatureId.UserWeightKg:
				return FitnessValue.Weight;
			case FeatureId.MaxUserWeightKg:
				return FitnessValue.MaxWeight;
			case FeatureId.KeyCooked:
				return FitnessValue.KeyObject;
			case FeatureId.VolumePercent:
				return FitnessValue.Volume;
			case FeatureId.TotalInUseTimeSeconds:
				return FitnessValue.TotalTime;
			case FeatureId.Activation:
				return FitnessValue.ActivationLock;
			case FeatureId.RequestDisconnect:
				return FitnessValue.IsReadyToDisconnect;
			case FeatureId.FanState:
				return FitnessValue.FanState;
			case FeatureId.DisplayUnits:
				return FitnessValue.SystemUnits;
			case FeatureId.CurrentCalories:
			case FeatureId.WarmUpCalories:
			case FeatureId.RunningCalories:
			case FeatureId.CoolDownCalories:
				return FitnessValue.CurrentCalories;
			case FeatureId.Pulse:
			case FeatureId.AveragePulse:
				return FitnessValue.Pulse;
			case FeatureId.MaxPulse:
				return FitnessValue.MaxPulse;
			case FeatureId.Distance:
			case FeatureId.WarmUpDistance:
			case FeatureId.RunningDistance:
			case FeatureId.CoolDownDistance:
				return FitnessValue.CurrentDistance;
			case FeatureId.TotalMachineDistance:
				return FitnessValue.MotorTotalDistance;
			case FeatureId.DistanceGoal:
				return FitnessValue.DistanceGoal;
			case FeatureId.TargetKph:
				return FitnessValue.Kph;
			case FeatureId.MinKph:
				return FitnessValue.MinKph;
			case FeatureId.MaxKph:
				return FitnessValue.MaxKph;
			case FeatureId.Rpm:
				return FitnessValue.Rpm;
			case FeatureId.Gear:
				return FitnessValue.Gear;
			case FeatureId.RowerTotalStrokes:
				return FitnessValue.Strokes;
			case FeatureId.RowerStrokesPerMin:
				return FitnessValue.StrokesPerMin;
			case FeatureId.Rower500Split:
				return FitnessValue.FiveHundredSplit;
			case FeatureId.RowerAverage500Split:
				return FitnessValue.AvgFiveHundredSplit;
			case FeatureId.TargetGradePercent:
				return FitnessValue.Grade;
			case FeatureId.MinGradePercent:
				return FitnessValue.MinGrade;
			case FeatureId.MaxGradePercent:
				return FitnessValue.MaxGrade;
			case FeatureId.AverageGradePercent:
				return FitnessValue.AverageGrade;
			case FeatureId.VerticalMetersNet:
				return FitnessValue.VerticalMeterNet;
			case FeatureId.VerticalMetersGain:
				return FitnessValue.VerticalMeterGain;
			case FeatureId.TargetResistanceLevel:
				return FitnessValue.Resistance;
			case FeatureId.MaxResistance:
				return FitnessValue.MaxResistanceLevel;
			case FeatureId.Watts:
				return FitnessValue.Watts;
			case FeatureId.GoalWatts:
				return FitnessValue.WattGoal;
			case FeatureId.AverageWatts:
				return FitnessValue.AverageWatts;
			case FeatureId.WorkoutState:
				return FitnessValue.WorkoutMode;
			case FeatureId.WarmUpCountdown:
			case FeatureId.CoolDownCountdown:
				return FitnessValue.CurrentTime;
			case FeatureId.RunningTime:
				return FitnessValue.RunningTime;
			case FeatureId.GoalTime:
				return FitnessValue.GoalTime;
			case FeatureId.StartRequested:
				return FitnessValue.StartRequested;
			case FeatureId.WarmUpTimeout:
				return FitnessValue.WarmupTimeout;
			case FeatureId.WorkoutTimeout:
				return FitnessValue.GoalTime;
			case FeatureId.CoolDownTimeout:
				return FitnessValue.CoolDownTimeout;
			case FeatureId.PauseTimeout:
				return FitnessValue.PauseTimeout;
			case FeatureId.PauseCountdown:
				return FitnessValue.PausedTime;
			default:
				Log.Error("FitPro2", $"Could not find FitnessValue for FeatureId {item}");
				return null;
			}
		}
	}
	internal enum FeatureId
	{
		[FeatureInfo(typeof(IntValueConverter), true)]
		SoftwareMajorVersion = 1,
		[FeatureInfo(typeof(IntValueConverter), true)]
		SoftwareMinorVersion = 2,
		[FeatureInfo(typeof(IntValueConverter), true)]
		SoftwarePatchVersion = 3,
		[FeatureInfo(typeof(IntValueConverter), true)]
		HardwarePartNumber = 4,
		[FeatureInfo(typeof(IntValueConverter), true)]
		SoftwarePartNumber = 5,
		[FeatureInfo(typeof(IntValueConverter), false)]
		UsbHostBoardVersion = 6,
		[FeatureInfo(typeof(IntValueConverter), true)]
		SystemError = 8,
		[FeatureInfo(typeof(BooleanValueConverter), true)]
		ClubUnit = 9,
		[FeatureInfo(typeof(DeviceTypeConverter), true)]
		DeviceType = 10,
		[FeatureInfo(typeof(SystemModeConverter), false)]
		SystemMode = 102,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		IdleSystemModeLock = 103,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		UserWeightKg = 105,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MaxUserWeightKg = 106,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		UserAgeYears = 107,
		[FeatureInfo(typeof(KeyCodeConverter), true)]
		KeyCooked = 109,
		[FeatureInfo(typeof(IntValueConverter), false)]
		VolumePercent = 111,
		[FeatureInfo(typeof(IntValueConverter), true)]
		TotalInUseTimeSeconds = 113,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		HoursTimeSinceStartup = 114,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		Activation = 119,
		[FeatureInfo(typeof(BooleanValueConverter), true)]
		CsafeMaster = 120,
		[FeatureInfo(typeof(BlankConverter), true)]
		USBHostBoardVersion = 121,
		[FeatureInfo(typeof(BlankConverter), false)]
		TabletConnectionStatus = 122,
		[FeatureInfo(typeof(BooleanValueConverter), true)]
		RequestDisconnect = 123,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		FanLevelPercent = 126,
		[FeatureInfo(typeof(BooleanValueConverter), true)]
		FanAutoSupport = 127,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		FanDefaultPercentOnStart = 128,
		[FeatureInfo(typeof(FanStateConverter), false)]
		FanState = 129,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		BleAdvertising = 130,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CommSuccessRatePercent = 132,
		[FeatureInfo(typeof(UnitsConverter), false)]
		DisplayUnits = 140,
		[FeatureInfo(typeof(LanguageConverter), true)]
		DisplayLanguage = 141,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray1 = 150,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray2 = 151,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray3 = 152,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray4 = 153,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray5 = 154,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray6 = 155,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray7 = 156,
		[FeatureInfo(typeof(BlankConverter), true)]
		KeyArray8 = 157,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CurrentCalories = 202,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		WarmUpCalories = 203,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		RunningCalories = 204,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CoolDownCalories = 205,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		OffMachineCalories = 206,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		CaloriesGoal = 210,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		Pulse = 222,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		AveragePulse = 227,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MaxPulse = 228,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		PulseGoal = 230,
		[FeatureInfo(typeof(IntValueConverter), false)]
		PairHrm = 231,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm1Id = 235,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm1SignalStrength = 236,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm2Id = 237,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm2SignalStrength = 238,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm3Id = 239,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm3SignalStrength = 240,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm4Id = 241,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm4SignalStrength = 242,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm5Id = 243,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Hrm5SignalStrength = 244,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		Distance = 252,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		WarmUpDistance = 253,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		RunningDistance = 254,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CoolDownDistance = 255,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		TotalMachineDistance = 256,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		DistanceGoal = 260,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		BeltTotalHours = 265,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		BeltTotalMeters = 266,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		BeltReplaced = 267,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		DistanceDriveMotorTotalHours = 270,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		DriveMotorTotalMeters = 271,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		MotorReplaced = 272,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		TargetKph = 301,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CurrentKph = 302,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MinKph = 303,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MaxKph = 304,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		AverageKph = 307,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		WorkoutMaxKph = 308,
		[FeatureInfo(typeof(IntValueConverter), false)]
		Rpm = 322,
		[FeatureInfo(typeof(IntValueConverter), false)]
		Gear = 324,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		PedalPosition = 325,
		[FeatureInfo(typeof(IntValueConverter), true)]
		AverageRpm = 327,
		[FeatureInfo(typeof(IntValueConverter), true)]
		MaxRpm = 328,
		[FeatureInfo(typeof(IntValueConverter), false)]
		RpmGoal = 330,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		RowerTotalStrokes = 343,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		RowerStrokesPerMin = 344,
		[FeatureInfo(typeof(IntValueConverter), true)]
		Rower500Split = 345,
		[FeatureInfo(typeof(IntValueConverter), true)]
		RowerAverage500Split = 346,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		TargetGradePercent = 401,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CurrentGradePercent = 402,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MinGradePercent = 403,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MaxGradePercent = 404,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		PhysicalMinPercent = 405,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		PhysicalMaxPercent = 406,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		AverageGradePercent = 407,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		WorkoutMaxGradePercent = 408,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		VerticalClimbGoalMeters = 410,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		VerticalMetersNet = 411,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		VerticalMetersGain = 412,
		[FeatureInfo(typeof(CalibrationStateConverter), false)]
		CalibrateGrade = 415,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		GradeFeedbackRange = 416,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		GradeMotorHours = 418,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		GradeMotorReplaced = 419,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		TargetResistancePercent = 501,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		CurrentResistancePercent = 502,
		[FeatureInfo(typeof(FloatValueConverter), false)]
		TargetResistanceLevel = 503,
		[FeatureInfo(typeof(IntValueConverter), true)]
		MaxResistance = 504,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		Watts = 522,
		[FeatureInfo(typeof(IntValueConverter), false)]
		GoalWatts = 523,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		AverageWatts = 527,
		[FeatureInfo(typeof(FloatValueConverter), true)]
		MaxWatts = 528,
		[FeatureInfo(typeof(IntValueConverter), false)]
		GoalType = 601,
		[FeatureInfo(typeof(WorkoutStateConverter), false)]
		WorkoutState = 602,
		[FeatureInfo(typeof(IntValueConverter), true)]
		WarmUpTime = 603,
		[FeatureInfo(typeof(IntValueConverter), true)]
		RunningTime = 604,
		[FeatureInfo(typeof(IntValueConverter), true)]
		CoolDownTime = 605,
		[FeatureInfo(typeof(IntValueConverter), true)]
		OffMachineTime = 606,
		[FeatureInfo(typeof(IntValueConverter), false)]
		GoalTime = 610,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		StartRequested = 612,
		[FeatureInfo(typeof(BooleanValueConverter), false)]
		ExitWorkoutRequested = 613,
		[FeatureInfo(typeof(IntValueConverter), false)]
		WarmUpTimeout = 615,
		[FeatureInfo(typeof(IntValueConverter), false)]
		WorkoutTimeout = 616,
		[FeatureInfo(typeof(IntValueConverter), false)]
		CoolDownTimeout = 617,
		[FeatureInfo(typeof(IntValueConverter), false)]
		ResultsTimeout = 618,
		[FeatureInfo(typeof(IntValueConverter), false)]
		PauseTimeout = 619,
		[FeatureInfo(typeof(IntValueConverter), false)]
		OffMachineTimeout = 620,
		[FeatureInfo(typeof(IntValueConverter), false)]
		ResultsCountdown = 621,
		[FeatureInfo(typeof(IntValueConverter), false)]
		PauseCountdown = 622,
		[FeatureInfo(typeof(IntValueConverter), false)]
		WarmUpCountdown = 623,
		[FeatureInfo(typeof(IntValueConverter), false)]
		WorkoutCountdown = 624,
		[FeatureInfo(typeof(IntValueConverter), false)]
		CoolDownCountdown = 625,
		[FeatureInfo(typeof(DriveMotorErrorCodeConverter), true)]
		DriveMotorErrorCode = 2380,
		[FeatureInfo(typeof(IntValueConverter), true)]
		DriveMotorErrorTimeout = 2385,
		[FeatureInfo(typeof(BlankConverter), false)]
		Ignored = 9999
	}
	internal static class FeatureIdHelper
	{
		public static FeatureId FromBytes(byte msb, byte lsb)
		{
			return (FeatureId)(msb | (lsb << 8));
		}

		public static byte[] ToBytes(this FeatureId featureId)
		{
			byte[] bytes = BitConverter.GetBytes((int)featureId);
			return new byte[2]
			{
				bytes[0],
				bytes[1]
			};
		}
	}
	internal class FeatureInfo : Attribute
	{
		public IFeatureConverter Converter { get; }

		public Type ConverterType { get; }

		public bool ReadOnly { get; }

		public FeatureInfo(Type converterType, bool readOnly = false)
		{
			ConverterType = converterType;
			Converter = ConverterMap.Entries[converterType];
			ReadOnly = readOnly;
		}
	}
}
namespace Sindarin.FitPro2.Core.Features.Converters
{
	internal class BlankConverter : ConverterBase<object>
	{
		public override object ConvertFromFloat(float raw)
		{
			return 0;
		}

		public override float ConvertToFloat(object data)
		{
			return 0f;
		}
	}
	internal class BooleanValueConverter : ConverterBase<bool>
	{
		private const float Tolerance = 0.0001f;

		public override bool ConvertFromFloat(float raw)
		{
			return Math.Abs(raw) > 0.0001f;
		}

		public override float ConvertToFloat(bool data)
		{
			if (!data)
			{
				return 0f;
			}
			return 1f;
		}
	}
	internal class CalibrationStateConverter : ConverterBase<CalibrationState>
	{
		public override CalibrationState ConvertFromFloat(float raw)
		{
			return (CalibrationState)raw;
		}

		public override float ConvertToFloat(CalibrationState data)
		{
			return (float)data;
		}
	}
	internal abstract class ConverterBase<T> : IFeatureConverter<T>, IFeatureConverter
	{
		public Type DataType { get; }

		public abstract T ConvertFromFloat(float raw);

		public abstract float ConvertToFloat(T data);

		protected ConverterBase()
		{
			DataType = typeof(T);
		}

		public float DataToFloat(object data)
		{
			return ConvertToFloat((T)data);
		}

		public object FloatToData(float raw)
		{
			return ConvertFromFloat(raw);
		}
	}
	internal static class ConverterMap
	{
		private static readonly Dictionary<Type, IFeatureConverter> _entries;

		public static IDictionary<Type, IFeatureConverter> Entries;

		static ConverterMap()
		{
			_entries = new Dictionary<Type, IFeatureConverter>
			{
				{
					typeof(BlankConverter),
					new BlankConverter()
				},
				{
					typeof(BooleanValueConverter),
					new BooleanValueConverter()
				},
				{
					typeof(CalibrationStateConverter),
					new CalibrationStateConverter()
				},
				{
					typeof(FloatValueConverter),
					new FloatValueConverter()
				},
				{
					typeof(IntValueConverter),
					new IntValueConverter()
				},
				{
					typeof(KeyCodeConverter),
					new KeyCodeConverter()
				},
				{
					typeof(LanguageConverter),
					new LanguageConverter()
				},
				{
					typeof(SystemModeConverter),
					new SystemModeConverter()
				},
				{
					typeof(UnitsConverter),
					new UnitsConverter()
				},
				{
					typeof(WorkoutStateConverter),
					new WorkoutStateConverter()
				},
				{
					typeof(FanStateConverter),
					new FanStateConverter()
				},
				{
					typeof(DeviceTypeConverter),
					new DeviceTypeConverter()
				},
				{
					typeof(DriveMotorErrorCodeConverter),
					new DriveMotorErrorCodeConverter()
				}
			};
			Entries = new ReadOnlyDictionary<Type, IFeatureConverter>(_entries);
		}
	}
	internal class DeviceTypeConverter : ConverterBase<DeviceType>
	{
		public override DeviceType ConvertFromFloat(float raw)
		{
			return (DeviceType)raw;
		}

		public override float ConvertToFloat(DeviceType data)
		{
			return (float)data;
		}
	}
	internal class DriveMotorErrorCodeConverter : ConverterBase<DriveMotorErrorCode>
	{
		public override DriveMotorErrorCode ConvertFromFloat(float raw)
		{
			return (DriveMotorErrorCode)raw;
		}

		public override float ConvertToFloat(DriveMotorErrorCode data)
		{
			return (float)data;
		}
	}
	internal class FanStateConverter : ConverterBase<FanState>
	{
		public override FanState ConvertFromFloat(float raw)
		{
			return (FanState)raw;
		}

		public override float ConvertToFloat(FanState data)
		{
			return (float)data;
		}
	}
	internal class FloatValueConverter : ConverterBase<double>
	{
		public override double ConvertFromFloat(float raw)
		{
			return raw;
		}

		public override float ConvertToFloat(double data)
		{
			return Convert.ToSingle(data);
		}
	}
	internal interface IFeatureConverter
	{
		Type DataType { get; }

		float DataToFloat(object data);

		object FloatToData(float raw);
	}
	internal interface IFeatureConverter<T> : IFeatureConverter
	{
		T ConvertFromFloat(float raw);

		float ConvertToFloat(T data);
	}
	internal class IntValueConverter : ConverterBase<int>
	{
		public override int ConvertFromFloat(float raw)
		{
			return (int)raw;
		}

		public override float ConvertToFloat(int data)
		{
			return data;
		}
	}
	internal class KeyCodeConverter : ConverterBase<KeyCode>
	{
		public override KeyCode ConvertFromFloat(float raw)
		{
			return (KeyCode)raw;
		}

		public override float ConvertToFloat(KeyCode data)
		{
			return (float)data;
		}
	}
	internal class LanguageConverter : ConverterBase<Language>
	{
		public override Language ConvertFromFloat(float raw)
		{
			return (Language)raw;
		}

		public override float ConvertToFloat(Language data)
		{
			return (float)data;
		}
	}
	internal class SystemModeConverter : ConverterBase<SystemMode>
	{
		public override SystemMode ConvertFromFloat(float raw)
		{
			return (SystemMode)raw;
		}

		public override float ConvertToFloat(SystemMode data)
		{
			return (float)data;
		}
	}
	internal class UnitsConverter : ConverterBase<bool>
	{
		private const float Tolerance = 0.0001f;

		public override bool ConvertFromFloat(float raw)
		{
			return Math.Abs(raw) > 0.0001f;
		}

		public override float ConvertToFloat(bool isMetric)
		{
			if (!isMetric)
			{
				return 0f;
			}
			return 1f;
		}
	}
	internal class WorkoutStateConverter : ConverterBase<WorkoutState>
	{
		public override WorkoutState ConvertFromFloat(float raw)
		{
			return (WorkoutState)raw;
		}

		public override float ConvertToFloat(WorkoutState data)
		{
			return (float)data;
		}
	}
}
namespace Sindarin.FitPro2.Core.DataObjects
{
	public enum CalibrationState
	{
		NotRun = 1,
		Start,
		InProgress,
		Success,
		Failure
	}
	internal enum DeviceType : short
	{
		WristWornWearable = 0,
		ShoeWornWearable = 1,
		ControllerType = 3,
		Treadmill = 4,
		InclineTrainer = 5,
		Elliptical = 6,
		ExerciseBike = 7,
		SpinBike = 8,
		VerticalElliptical = 9,
		VibrationExerciseMachine = 10,
		StairClimber = 11,
		Skier = 12,
		FitnessWeightMachine = 13,
		DoubleStackWeightMachine = 14,
		DumbbellWeightHolder = 15,
		SingleJointWeightMachine = 16,
		DoubleJointWeightMachine = 17,
		FreeOlympicWeightMachine = 18,
		FreeStrider = 19,
		Rower = 20,
		Bed = 21,
		PowerBoard = 22
	}
	internal static class DeviceTypeExtension
	{
		internal static ConsoleType ToConsoleType(this DeviceType deviceType)
		{
			switch (deviceType)
			{
			case DeviceType.WristWornWearable:
			case DeviceType.ShoeWornWearable:
			case DeviceType.ControllerType:
			case DeviceType.VibrationExerciseMachine:
			case DeviceType.StairClimber:
			case DeviceType.Skier:
			case DeviceType.FitnessWeightMachine:
			case DeviceType.DoubleStackWeightMachine:
			case DeviceType.DumbbellWeightHolder:
			case DeviceType.SingleJointWeightMachine:
			case DeviceType.DoubleJointWeightMachine:
			case DeviceType.FreeOlympicWeightMachine:
			case DeviceType.Bed:
			case DeviceType.PowerBoard:
				return ConsoleType.None;
			case DeviceType.Treadmill:
				return ConsoleType.Treadmill;
			case DeviceType.InclineTrainer:
				return ConsoleType.InclineTrainer;
			case DeviceType.Elliptical:
				return ConsoleType.Elliptical;
			case DeviceType.ExerciseBike:
				return ConsoleType.Bike;
			case DeviceType.SpinBike:
				return ConsoleType.SpinBike;
			case DeviceType.VerticalElliptical:
				return ConsoleType.VerticalElliptical;
			case DeviceType.FreeStrider:
				return ConsoleType.FreeStrider;
			case DeviceType.Rower:
				return ConsoleType.Rower;
			default:
				throw new ArgumentOutOfRangeException("deviceType", deviceType, null);
			}
		}
	}
	public enum ExtendedInfoType
	{
		Unknown,
		FileSystem,
		ProductInfo
	}
	public enum Language
	{
		Unknown,
		English
	}
	public class ProductInfo
	{
		public string SoftwareVersion { get; internal set; }

		public int SoftwarePartNumber { get; internal set; }

		public int HardwarePartNumber { get; internal set; }

		public string ModelName { get; internal set; }

		public string SerialNumber { get; internal set; }

		public string DisplayType { get; internal set; }

		public string AntPlusDeviceNumber { get; internal set; }

		public string AntPlusDeviceType { get; internal set; }

		public string MotorControllerVersion { get; internal set; }

		public string MotorControllerParametersChecksum { get; internal set; }

		public string AntPlusRelaySoftwareVersion { get; internal set; }

		public string AntPlusRelayBootloaderVersion { get; internal set; }
	}
	internal enum SystemMode
	{
		BootUp,
		Idle,
		Dmk,
		Workout,
		Maintenance,
		Error
	}
	internal static class SystemModeExtensions
	{
		public static ConsoleState ToConsoleState(this SystemMode mode)
		{
			switch (mode)
			{
			case SystemMode.BootUp:
			case SystemMode.Maintenance:
				return ConsoleState.Unknown;
			case SystemMode.Idle:
				return ConsoleState.Idle;
			case SystemMode.Workout:
				return ConsoleState.Workout;
			case SystemMode.Dmk:
				return ConsoleState.SafetyKeyRemoved;
			case SystemMode.Error:
				return ConsoleState.Error;
			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
			}
		}
	}
	public enum WorkoutState
	{
		None,
		ReadyToStart,
		WarmUp,
		Running,
		CoolDown,
		Paused,
		Results,
		OffMachine
	}
	internal static class WorkoutStateExtensions
	{
		public static WorkoutState? ToWorkoutState(this ConsoleState state)
		{
			switch (state)
			{
			case ConsoleState.Unknown:
			case ConsoleState.SafetyKeyRemoved:
			case ConsoleState.Resume:
			case ConsoleState.PauseOverride:
			case ConsoleState.Locked:
			case ConsoleState.Demo:
			case ConsoleState.Sleep:
			case ConsoleState.Error:
				return null;
			case ConsoleState.Idle:
				return WorkoutState.None;
			case ConsoleState.Workout:
				return WorkoutState.Running;
			case ConsoleState.Paused:
				return WorkoutState.Paused;
			case ConsoleState.WorkoutResults:
				return WorkoutState.Results;
			case ConsoleState.WarmUp:
				return WorkoutState.WarmUp;
			case ConsoleState.CoolDown:
				return WorkoutState.CoolDown;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
		}

		public static ConsoleState ToConsoleState(this WorkoutState mode)
		{
			return mode switch
			{
				WorkoutState.None => ConsoleState.Idle, 
				WorkoutState.WarmUp => ConsoleState.WarmUp, 
				WorkoutState.Running => ConsoleState.Workout, 
				WorkoutState.CoolDown => ConsoleState.CoolDown, 
				WorkoutState.Paused => ConsoleState.Paused, 
				WorkoutState.Results => ConsoleState.WorkoutResults, 
				_ => throw new ArgumentOutOfRangeException("mode", mode, null), 
			};
		}
	}
}
namespace Sindarin.FitPro2.Core.Communication
{
	public enum CommunicationType : byte
	{
		FileSystem = 1,
		FitPro2
	}
	internal static class Defaults
	{
		public static readonly FeatureId[] SubscribedFields = new FeatureId[52]
		{
			FeatureId.SystemError,
			FeatureId.UserWeightKg,
			FeatureId.DisplayUnits,
			FeatureId.MaxKph,
			FeatureId.MinKph,
			FeatureId.MaxGradePercent,
			FeatureId.MinGradePercent,
			FeatureId.MaxUserWeightKg,
			FeatureId.PauseTimeout,
			FeatureId.CoolDownTimeout,
			FeatureId.WarmUpTimeout,
			FeatureId.MaxResistance,
			FeatureId.Gear,
			FeatureId.WorkoutState,
			FeatureId.SystemMode,
			FeatureId.Activation,
			FeatureId.ClubUnit,
			FeatureId.DeviceType,
			FeatureId.IdleSystemModeLock,
			FeatureId.TargetGradePercent,
			FeatureId.WarmUpCountdown,
			FeatureId.CoolDownCountdown,
			FeatureId.RunningTime,
			FeatureId.WarmUpDistance,
			FeatureId.CoolDownDistance,
			FeatureId.RunningDistance,
			FeatureId.WarmUpCalories,
			FeatureId.RunningCalories,
			FeatureId.CoolDownCalories,
			FeatureId.TargetResistanceLevel,
			FeatureId.Rpm,
			FeatureId.AverageGradePercent,
			FeatureId.Watts,
			FeatureId.GoalWatts,
			FeatureId.AverageWatts,
			FeatureId.VerticalMetersNet,
			FeatureId.VerticalMetersGain,
			FeatureId.Pulse,
			FeatureId.TargetKph,
			FeatureId.StartRequested,
			FeatureId.FanState,
			FeatureId.VolumePercent,
			FeatureId.PauseCountdown,
			FeatureId.RowerTotalStrokes,
			FeatureId.RowerStrokesPerMin,
			FeatureId.Rower500Split,
			FeatureId.RowerAverage500Split,
			FeatureId.GoalTime,
			FeatureId.KeyCooked,
			FeatureId.RequestDisconnect,
			FeatureId.DriveMotorErrorCode,
			FeatureId.DriveMotorErrorTimeout
		};
	}
	internal class FitProUsbConsoleCommunicationAdapter : FitProCommunicationAdapter
	{
		private bool fatalityTriggered;

		protected override int maxItemLostBeforeFatality { get; } = 5;

		protected override TimeSpan rateOfItemLostDecay { get; } = TimeSpan.FromSeconds(2.0);

		protected override bool requiresPolling { get; } = true;

		protected override TimeSpan defaultReadDelay { get; } = TimeSpan.FromMilliseconds(50.0);

		public override ConnectionType ConnectionType { get; }

		public override TimeSpan DefaultTimeout { get; } = TimeSpan.FromMilliseconds(200.0);

		public FitProUsbConsoleCommunicationAdapter(IFitPro2ConsoleBasicInfo consoleBasicInfo, IDeviceConnection connection, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
			: base(consoleBasicInfo, connection, fatalityService, fitProBytesLogger)
		{
		}

		protected override async Task<bool> DataReceived(byte[] bytes)
		{
			if (await base.DataReceived(bytes))
			{
				return true;
			}
			return false;
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
	internal interface IFitProCommunication : ICommunication
	{
		IFitProCommand Request { get; }

		IFitProResponse Response { get; }

		int Retries { get; }

		void ResetForRetry();
	}
	internal class FitProCommunication : IFitProCommunication, ICommunication
	{
		private static readonly TimeSpan UsbDelay = TimeSpan.FromMilliseconds(25.0);

		private static readonly TimeSpan DefaultDelay = TimeSpan.FromMilliseconds(400.0);

		private static readonly TimeSpan UsbShortTimeout = TimeSpan.FromSeconds(1.0);

		private static readonly TimeSpan UsbLongTimeout = TimeSpan.FromSeconds(4.0);

		private static readonly TimeSpan DefaultShortTimeout = TimeSpan.FromSeconds(2.0);

		private static readonly TimeSpan DefaultLongTimeout = TimeSpan.FromSeconds(8.0);

		private static readonly HashSet<Command> LongCommands = new HashSet<Command>(new Command[2]
		{
			Command.Extended,
			Command.SupportedFeatures
		});

		public IFitProCommand Request { get; }

		public IFitProResponse Response { get; }

		public bool IsComplete { get; private set; }

		public int ShouldRetryCount { get; } = 3;

		public TimeSpan Timeout { get; set; }

		public int Retries { get; set; }

		public TimeSpan ReadDelay { get; }

		public ConnectionType Format { get; set; }

		public FitProCommunication(IFitProCommand request, ConnectionType format)
		{
			Request = request;
			Format = format;
			ReadDelay = ((format == ConnectionType.USB) ? UsbDelay : DefaultDelay);
			if (LongCommands.Contains(request.Command))
			{
				Timeout = ((format == ConnectionType.USB) ? UsbLongTimeout : DefaultLongTimeout);
			}
			else
			{
				Timeout = ((format == ConnectionType.USB) ? UsbShortTimeout : DefaultShortTimeout);
			}
		}

		public void ReceiveComplete()
		{
			IsComplete = true;
		}

		public void ReceiveFailed()
		{
		}

		public void ResetForRetry()
		{
			Retries++;
		}
	}
}
namespace Sindarin.FitPro2.Core.Commands
{
	internal class BootloaderCommand : EmptyCommand
	{
		public BootloaderCommand()
			: base(Command.Bootloader)
		{
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			base.Tcs.TrySetResult(ResponseFactory.Create(bytes));
			return true;
		}
	}
	[Flags]
	internal enum Command : byte
	{
		Unknown = 0,
		Subscribe = 1,
		Write = 2,
		SupportedFeatures = 6,
		Unsubscribe = 7,
		Bootloader = 9,
		Extended = 0xE
	}
	internal interface IFitProCommand
	{
		CommunicationType CommunicationType { get; }

		Device Device { get; }

		Command Command { get; }

		int Length { get; }

		TaskCompletionSource<object> Tcs { get; }

		byte[] GetRequestBytes();

		bool SetResponseBytes(byte[] bytes);
	}
	internal abstract class CommandBase : IFitProCommand
	{
		private const int RequestOverhead = 3;

		public int Length => 3 + PayloadLength;

		public CommunicationType CommunicationType { get; } = CommunicationType.FitPro2;

		public Device Device { get; protected set; }

		public Command Command { get; protected set; }

		protected abstract byte PayloadLength { get; }

		public TaskCompletionSource<object> Tcs { get; } = new TaskCompletionSource<object>();

		internal CommandBase(Command command)
		{
			Command = command;
		}

		protected abstract byte[] GetPayloadBytes();

		public byte[] GetRequestBytes()
		{
			byte[] payloadBytes = GetPayloadBytes();
			byte[] array = new byte[Length];
			array[0] = (byte)CommunicationType;
			array[1] = Device.WithCommand(Command);
			array[2] = PayloadLength;
			payloadBytes?.CopyTo(array, 3);
			return array;
		}

		public abstract bool SetResponseBytes(byte[] bytes);
	}
	internal abstract class EmptyCommand : CommandBase
	{
		protected override byte PayloadLength => 0;

		protected override byte[] GetPayloadBytes()
		{
			return null;
		}

		protected EmptyCommand(Command command)
			: base(command)
		{
		}
	}
	internal class ExtendedInfoCommand : CommandBase
	{
		private const string Tag = "ExtendedInfo";

		private ProductInfo pendingProductInfo;

		public ExtendedInfoType ExtendedInfoType { get; }

		protected override byte PayloadLength => 1;

		public ExtendedInfoCommand(ExtendedInfoType extendedInfoType)
			: base(Command.Extended)
		{
			ExtendedInfoType = extendedInfoType;
		}

		protected override byte[] GetPayloadBytes()
		{
			return new byte[1] { (byte)ExtendedInfoType };
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			if (pendingProductInfo == null)
			{
				pendingProductInfo = new ProductInfo();
			}
			if (ResponseFactory.Create(bytes) is ExtendedResponse extendedResponse)
			{
				ExtendedInfoType extendedInfoType = extendedResponse.Payload.ExtendedInfoType;
				IExtendedInfo extendedInfo = extendedResponse.Payload.ExtendedInfo;
				if (extendedInfoType == ExtendedInfoType.ProductInfo)
				{
					if (extendedInfo is ExtendedProductInfo extendedProductInfo)
					{
						switch (extendedProductInfo.InfoType)
						{
						case ProductInfoType.EndOfList:
							base.Tcs.TrySetResult(pendingProductInfo);
							return true;
						case ProductInfoType.SoftwareVersion:
							pendingProductInfo.SoftwareVersion = extendedProductInfo.Info;
							break;
						case ProductInfoType.SoftwarePartNumber:
						{
							if (int.TryParse(extendedProductInfo.Info, out var result2))
							{
								pendingProductInfo.SoftwarePartNumber = result2;
							}
							break;
						}
						case ProductInfoType.HardwarePartNumber:
						{
							if (int.TryParse(extendedProductInfo.Info, out var result))
							{
								pendingProductInfo.HardwarePartNumber = result;
							}
							break;
						}
						case ProductInfoType.ModelName:
							pendingProductInfo.ModelName = extendedProductInfo.Info;
							break;
						case ProductInfoType.SerialNumber:
							pendingProductInfo.SerialNumber = extendedProductInfo.Info;
							break;
						case ProductInfoType.DisplayType:
							pendingProductInfo.DisplayType = extendedProductInfo.Info;
							break;
						case ProductInfoType.AntPlusDeviceNumber:
							pendingProductInfo.AntPlusDeviceNumber = extendedProductInfo.Info;
							break;
						case ProductInfoType.AntPlusDeviceType:
							pendingProductInfo.AntPlusDeviceType = extendedProductInfo.Info;
							break;
						case ProductInfoType.MotorControllerVersion:
							pendingProductInfo.MotorControllerVersion = extendedProductInfo.Info;
							break;
						case ProductInfoType.MotorControllerParametersChecksum:
							pendingProductInfo.MotorControllerParametersChecksum = extendedProductInfo.Info;
							break;
						case ProductInfoType.AntPlusRelaySoftwareVersion:
							pendingProductInfo.AntPlusRelaySoftwareVersion = extendedProductInfo.Info;
							break;
						case ProductInfoType.AntPlusRelayBootloaderVersion:
							pendingProductInfo.AntPlusRelayBootloaderVersion = extendedProductInfo.Info;
							break;
						default:
							Log.Error("ExtendedInfo", $"ExtendedProductInfo doesn't support InfoType {extendedProductInfo.InfoType} with value {extendedProductInfo.Info}");
							break;
						}
					}
				}
				else
				{
					Log.Warn("ExtendedInfo", $"Unsupported message type: {extendedInfoType}");
				}
			}
			return false;
		}
	}
	internal class SubscribeCommand : CommandBase
	{
		private HashSet<FeatureId> requestedFeatures;

		public FeatureId[] Features { get; }

		protected override byte PayloadLength
		{
			get
			{
				FeatureId[] features = Features;
				return (byte)(((features != null) ? features.Length : 0) * 2);
			}
		}

		private SubscribeCommand(bool subscribe, params FeatureId[] features)
			: base(subscribe ? Command.Subscribe : Command.Unsubscribe)
		{
			Features = features;
			requestedFeatures = new HashSet<FeatureId>(Features);
		}

		protected override byte[] GetPayloadBytes()
		{
			return Features.SelectMany(FeatureIdHelper.ToBytes).ToArray();
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			IFitProResponse fitProResponse = ResponseFactory.Create(bytes);
			if (base.Command == Command.Subscribe && fitProResponse is EventResponse eventResponse)
			{
				FeatureId featureId = eventResponse.Payload.FeatureId;
				if (!requestedFeatures.Contains(featureId))
				{
					return false;
				}
				requestedFeatures.Remove(featureId);
				if (requestedFeatures.Count != 0)
				{
					return false;
				}
				base.Tcs.TrySetResult(fitProResponse);
				return true;
			}
			if (base.Command == Command.Unsubscribe && (fitProResponse is AcknowledgeResponse || fitProResponse is ErrorResponse))
			{
				base.Tcs.TrySetResult(fitProResponse);
				return true;
			}
			return false;
		}

		private static List<SubscribeCommand> CreateCommands(bool subscribe, params FeatureId[] features)
		{
			return (from x in features.Chunk(8)
				select new SubscribeCommand(subscribe, x.ToArray())).ToList();
		}

		public static List<SubscribeCommand> CreateSubscribeCommands(params FeatureId[] features)
		{
			return CreateCommands(subscribe: true, features);
		}

		public static List<SubscribeCommand> CreateUnsubscribeCommands(params FeatureId[] features)
		{
			return CreateCommands(subscribe: false, features);
		}

		public static SubscribeCommand CreateClearSubscriptionsCommand()
		{
			return new SubscribeCommand(false);
		}
	}
	internal class SupportedFeaturesCommand : EmptyCommand
	{
		private readonly HashSet<FeatureId> pendingFeatures = new HashSet<FeatureId>();

		public SupportedFeaturesCommand()
			: base(Command.SupportedFeatures)
		{
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			if (ResponseFactory.Create(bytes) is FeaturesResponse featuresResponse)
			{
				int count = featuresResponse.Payload.Count;
				lock (pendingFeatures)
				{
					if (count != 0)
					{
						pendingFeatures.UnionWith(featuresResponse.Payload);
					}
					else if (pendingFeatures.Count != 0)
					{
						base.Tcs.TrySetResult(pendingFeatures);
						return true;
					}
				}
			}
			return false;
		}
	}
	internal class WriteCommand : CommandBase
	{
		private const string Tag = "WriteCommand";

		private IFitPro2ConsoleBasicInfo consoleBasicInfo;

		public FeatureId Feature { get; }

		public object Value { get; }

		protected override byte PayloadLength => 6;

		public WriteCommand(IFitPro2ConsoleBasicInfo consoleBasicInfo, FeatureId feature, object value)
			: base(Command.Write)
		{
			this.consoleBasicInfo = consoleBasicInfo;
			Feature = feature;
			Value = value;
		}

		protected override byte[] GetPayloadBytes()
		{
			byte[] first = Feature.ToBytes();
			byte[] bytes = BitConverter.GetBytes(Feature.GetConverter().DataToFloat(Value));
			return first.Concat(bytes).ToArray();
		}

		public override bool SetResponseBytes(byte[] bytes)
		{
			if (bytes.All((byte b) => b == 0))
			{
				return false;
			}
			IFitProResponse fitProResponse = ResponseFactory.Create(bytes);
			if (fitProResponse is AcknowledgeResponse acknowledgeResponse && base.Command == acknowledgeResponse.Payload)
			{
				if (acknowledgeResponse.Payload == Command.Write)
				{
					FeatureId feature = Feature;
					FitnessValue? fitnessValue = feature.ToFitnessValue();
					if (fitnessValue.HasValue)
					{
						consoleBasicInfo.SetValue(feature, fitnessValue.Value, Value);
					}
					else
					{
						string text = $"Could not set {feature} to {Value} since it does not have a corresponding FitnessValue";
						Log.Error("WriteCommand", text);
					}
				}
				base.Tcs.TrySetResult(acknowledgeResponse);
				return true;
			}
			if (fitProResponse is ErrorResponse errorResponse)
			{
				if (!(errorResponse.Payload.ErrorInfo is IFeatureIdErrorInfo { FeatureId: var featureId } featureIdErrorInfo))
				{
					base.Tcs.TrySetResult(errorResponse);
					Log.Error("WriteCommand", $"Error in request \"{BitConverter.ToString(GetRequestBytes())}\": {errorResponse}");
					return true;
				}
				if (featureId.HasValue && featureIdErrorInfo.FeatureId.Value == Feature)
				{
					base.Tcs.TrySetResult(errorResponse);
					Log.Error("WriteCommand", $"Error in request \"{BitConverter.ToString(GetRequestBytes())}\": {errorResponse}");
					return true;
				}
			}
			return false;
		}
	}
}
namespace Sindarin.FitPro2.Core.Resources
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class FitPro2Strings
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.Equals(null, resourceMan))
				{
					resourceMan = new ResourceManager("Sindarin.FitPro2.Core.Resources.FitPro2Strings", typeof(FitPro2Strings).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static string drive_motor_error_description => ResourceManager.GetString("drive_motor_error_description", resourceCulture);

		internal FitPro2Strings()
		{
		}
	}
}
