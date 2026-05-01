using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MathNet.Numerics;
using MvvmCross.Platform;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Utilities.Net;
using Polly;
using Polly.Retry;
using Shire.Core.Ble.HeartRate;
using Sindarin.Core.Ble;
using Sindarin.Core.Ble.Connection;
using Sindarin.Core.Ble.Connection.Characteristic;
using Sindarin.Core.Ble.Connection.Service;
using Sindarin.Core.Ble.Filter;
using Sindarin.Core.Ble.KnownTypes;
using Sindarin.Core.Ble.Scan;
using Sindarin.Core.Ble.Service;
using Sindarin.Core.Ble.Utils;
using Sindarin.Core.Communication;
using Sindarin.Core.Connection;
using Sindarin.Core.Console;
using Sindarin.Core.Console.Decorators;
using Sindarin.Core.Console.Equipmentless;
using Sindarin.Core.Console.Filters;
using Sindarin.Core.Console.FitnessValues;
using Sindarin.Core.Console.Substitutes;
using Sindarin.Core.DataObjects;
using Sindarin.Core.Facades;
using Sindarin.Core.Facades.Distance;
using Sindarin.Core.Facades.Resistance;
using Sindarin.Core.Facades.Speed;
using Sindarin.Core.HeartRate;
using Sindarin.Core.Mock;
using Sindarin.Core.Mock.Nonconnected;
using Sindarin.Core.Services;
using Sindarin.Core.Util;
using Sindarin.Core.Util.Calories;
using UnitConversion;
using iFit.Collections;
using iFit.Extensions;
using iFit.Logger;
using iFit.Mathematics;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: InternalsVisibleTo("Sindarin.Tests")]
[assembly: InternalsVisibleTo("Sindarin.FitPro2.Tests")]
[assembly: InternalsVisibleTo("Shire.Tests")]
[assembly: InternalsVisibleTo("Wolf.Tests")]
[assembly: AssemblyCompany("Sindarin.Core")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Sindarin.Core")]
[assembly: AssemblyTitle("Sindarin.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.CrashReporter
{
	public interface ICrashReporter : IDisposable
	{
		Task ReportError(IList<string> tag, string message, Exception exception, bool includeLogFiles, bool isManualLog);

		Task PersistError(string tag, string message, Exception exception);

		Task ReportError(string message, Exception exception, IDictionary<string, object> customData, bool includeLogFiles = true);
	}
}
namespace Shire.Core.Ble.HeartRate
{
	public interface IHeartRateScanner
	{
		IObservable<IBleDevice> OnFoundDevice { get; }

		IObservable<bool> OnScanning { get; }

		Task BeginScanning(TimeSpan scanTimeout = default(TimeSpan));

		void StopScanning();
	}
	public class HeartRateScanner : IHeartRateScanner
	{
		private readonly Subject<IBleDevice> onFoundDevice = new Subject<IBleDevice>();

		private readonly Subject<bool> onScanning = new Subject<bool>();

		private IDisposable scannerDevicesSub;

		private readonly SemaphoreSlim scannerLock = new SemaphoreSlim(1, 1);

		protected static readonly TimeSpan defaultScanTimeout = TimeSpan.FromSeconds(15.0);

		private CancellationTokenSource stopScanningCts;

		private const string LogTag = "HeartRateScanner";

		private readonly IHeartRateHelperFlags heartRateHelperFlags;

		private readonly IScanner scanner;

		public IObservable<IBleDevice> OnFoundDevice => onFoundDevice;

		public IObservable<bool> OnScanning => onScanning;

		public HeartRateScanner(IHeartRateHelperFlags heartRateHelperFlags, IScanner scanner)
		{
			this.heartRateHelperFlags = heartRateHelperFlags;
			this.scanner = scanner;
		}

		public async Task BeginScanning(TimeSpan scanTimeout = default(TimeSpan))
		{
			if (!(await scannerLock.WaitAsync(0).ConfigureAwait(continueOnCapturedContext: false)))
			{
				Log.Trace("HeartRateScanner", "Scan for HRMs already in progress");
				return;
			}
			stopScanningCts = new CancellationTokenSource();
			onScanning.OnNext(value: true);
			if (scanTimeout == default(TimeSpan))
			{
				scanTimeout = defaultScanTimeout;
			}
			if (scanTimeout.TotalMilliseconds > 2147483647.0)
			{
				scanTimeout = TimeSpan.FromMilliseconds(2147483647.0);
			}
			Log.Trace("HeartRateScanner", $"Scanning for heart rate devices (will timeout in {scanTimeout.TotalSeconds}) seconds...");
			if (heartRateHelperFlags.IsBondedHrMonitorEnabled())
			{
				await scanner.WarmUpScanner().ConfigureAwait(continueOnCapturedContext: false);
			}
			scannerDevicesSub?.Dispose();
			scannerDevicesSub = null;
			try
			{
				scannerDevicesSub = scanner.ScanWithFilter(new HeartRateDeviceFilter(), (int)scanTimeout.TotalSeconds).Subscribe(delegate(IBleDevice x)
				{
					onFoundDevice.OnNext(x);
				});
				await Task.Delay(scanTimeout, stopScanningCts.Token).ConfigureAwait(continueOnCapturedContext: false);
				Log.Trace("HeartRateScanner", "Scanning timed out");
				StopScanningAndCleanup();
			}
			catch (TaskCanceledException exception)
			{
				Log.Trace("HeartRateScanner", "Scanning cancelled", exception);
			}
			catch (Exception exception2)
			{
				Log.Trace("HeartRateScanner", "Scanning for HRM failed with unknown error", exception2);
				StopScanningAndCleanup();
			}
		}

		public void StopScanning()
		{
			if (stopScanningCts != null)
			{
				stopScanningCts?.Cancel();
				StopScanningAndCleanup();
			}
		}

		private void StopScanningAndCleanup()
		{
			scannerDevicesSub?.Dispose();
			scannerDevicesSub = null;
			scanner.StopScan();
			stopScanningCts?.Dispose();
			stopScanningCts = null;
			scannerLock.Release();
			onScanning.OnNext(value: false);
			Log.Trace("HeartRateScanner", "Scan stopped");
		}
	}
}
namespace Sindarin.Core
{
	public static class CommonSindarinAppSetup
	{
		public static IFitnessConsoleManager RegisterSindarinDependencies()
		{
			IFitnessConsoleManager result = RegisterFitnessConsoleManager();
			RegisterFacades();
			return result;
		}

		private static IFitnessConsoleManager RegisterFitnessConsoleManager()
		{
			FitnessConsoleManager fitnessConsoleManager = new FitnessConsoleManager();
			Mvx.RegisterSingleton((IFitnessConsoleManager)fitnessConsoleManager);
			return fitnessConsoleManager;
		}

		private static void RegisterFacades()
		{
			Mvx.LazyConstructAndRegisterSingleton<IConsoleControlValuesFacade, ConsoleControlValuesFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IWorkoutFacade, WorkoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IKphFacade, KphFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IAvgSpeedFacade, AvgSpeedFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IGradeFacade, GradeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IResistanceFacade, ResistanceFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IWattsFacade, WattsFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ICurrentDistanceFacade, CurrentDistanceFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IRpmFacade, RpmFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IKeyObjectFacade, KeyObjectFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IVolumeFacade, VolumeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IPulseFacade, PulseFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IRunningTimeFacade, RunningTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IConsoleStateFacade, ConsoleStateFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ILapTimeFacade, LapTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IActualKphFacade, ActualKphFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IActualInclineFacade, ActualInclineFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ICurrentTimeFacade, CurrentTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ICaloriesFacade, CaloriesFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IGoalTimeFacade, GoalTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IWeightFacade, WeightFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IGearFacade, GearFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxGradeFacade, MaxGradeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMinGradeFacade, MinGradeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxKphFacade, MaxKphFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMinKphFacade, MinKphFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IIdleTimeoutFacade, IdleTimeoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IPauseTimeoutFacade, PauseTimeoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ISystemUnitsFacade, SystemUnitsFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxResistanceLevelFacade, MaxResistanceLevelFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxWeightFacade, MaxWeightFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IWarmupTimeoutFacade, WarmupTimeoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ICoolDownTimeoutFacade, CoolDownTimeoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxPulseFacade, MaxPulseFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IAverageWattsFacade, AverageWattsFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IWattGoalFacade, WattGoalFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IDistanceGoalFacade, DistanceGoalFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMotorTotalDistanceFacade, MotorTotalDistanceFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ITotalTimeFacade, TotalTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IVerticalMeterNetFacade, VerticalMeterNetFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IVerticalMeterGainFacade, VerticalMeterGainFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IIdleModeLockoutFacade, IdleModeLockoutFacade>();
			Mvx.LazyConstructAndRegisterSingleton<ISleepTimerStateFacade, SleepTimerStateFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IStartRequestedFacade, StartRequestedFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IFanStateFacade, FanStateFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IActivationLockFacade, ActivationLockFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IPausedTimeFacade, PausedTimeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IRequireStartRequestedFacade, RequireStartRequestedFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IStrokesFacade, StrokesFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IStrokesPerMinFacade, StrokesPerMinFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IFiveHundredSplitFacade, FiveHundredSplitFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IFiveHundredSplitDecimalFacade, FiveHundredSplitDecimalFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IAvgFiveHundredSplitFacade, AvgFiveHundredSplitFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IIsClubUnitFacade, IsClubUnitFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IIsReadyToDisconnectFacade, IsReadyToDisconnectFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IIsConstantWattsModeFacade, IsConstantWattsModeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IMaxRpmFacade, MaxRpmFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IAverageGradeFacade, AverageGradeFacade>();
			Mvx.LazyConstructAndRegisterSingleton<IReadWriteFacadeFactoryDependencies, ReadWriteFacadeFactoryDependencies>();
		}
	}
	public enum ConsoleType
	{
		Treadmill,
		InclineTrainer,
		Elliptical,
		Bike,
		Strider,
		FreeStrider,
		VerticalElliptical,
		SpinBike,
		Rower,
		Equipmentless,
		Mirror,
		None
	}
	public enum FitnessValue
	{
		Kph,
		AvgSpeedKph,
		Grade,
		AverageGrade,
		Resistance,
		Watts,
		CurrentDistance,
		Rpm,
		KeyObject,
		Volume,
		Pulse,
		RunningTime,
		WorkoutMode,
		LapTime,
		ActualKph,
		ActualIncline,
		CurrentTime,
		CurrentCalories,
		GoalTime,
		Weight,
		Gear,
		MaxGrade,
		MinGrade,
		MaxKph,
		MinKph,
		IdleTimeout,
		PauseTimeout,
		SystemUnits,
		MaxResistanceLevel,
		MaxWeight,
		WarmupTimeout,
		CoolDownTimeout,
		MaxPulse,
		MaxRpm,
		AverageWatts,
		WattGoal,
		DistanceGoal,
		MotorTotalDistance,
		TotalTime,
		VerticalMeterNet,
		VerticalMeterGain,
		IdleModeLockout,
		SleepTimerState,
		StartRequested,
		FanState,
		ActivationLock,
		PausedTime,
		RequireStartRequested,
		Strokes,
		StrokesPerMin,
		FiveHundredSplit,
		AvgFiveHundredSplit,
		IsClubUnit,
		IsReadyToDisconnect,
		IsConstantWattsMode,
		FiveHundredSplitDecimal,
		DeviceType,
		EffortScore
	}
	public class FitnessValueChange<T>
	{
		public FitnessValue Type { get; protected set; }

		public T Old { get; protected set; }

		public T Current { get; protected set; }

		public FitnessValueChange(FitnessValue type, T old, T current)
		{
			Type = type;
			Old = old;
			Current = current;
		}

		protected FitnessValueChange()
		{
		}
	}
	public class StateChange : FitnessValueChange<ConsoleState>
	{
		public StateChange(ConsoleState old, ConsoleState current)
			: base(FitnessValue.WorkoutMode, old, current)
		{
		}
	}
	public class AnyFitnessValueChange : FitnessValueChange<object>
	{
		public AnyFitnessValueChange(FitnessValue type, object old, object current)
			: base(type, old, current)
		{
		}

		public AnyFitnessValueChange()
		{
		}

		public AnyFitnessValueChange Update(FitnessValue type, object old, object current)
		{
			base.Type = type;
			base.Old = old;
			base.Current = current;
			return this;
		}
	}
	public class SindarinEvent
	{
		public static readonly SindarinEvent StartRequested = new SindarinEvent("Start Requested");

		public static readonly SindarinEvent ClearBufferFailed = new SindarinEvent("Failed To Clear USB Buffer");

		public string Name { get; }

		private SindarinEvent(string name)
		{
			Name = name;
		}
	}
	public interface ISindarinEventHandler
	{
		Task LogSindarinEvent(SindarinEvent sindarinEvent, IDictionary<string, object> properties);

		Task LogFatalEvent(Exception exception);
	}
}
namespace Sindarin.Core.Util
{
	public static class ByteExtensions
	{
		public static bool WildcardSequenceEquals(this byte[] bytes, byte?[] sequence)
		{
			if (bytes == null || sequence == null || bytes.Length != sequence.Length)
			{
				return false;
			}
			for (long num = 0L; num < bytes.Length; num++)
			{
				byte b = bytes[num];
				byte? b2 = sequence[num];
				if (b2.HasValue && b != b2.Value)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsValid(this byte[] bytes)
		{
			if (bytes != null)
			{
				return bytes.Length != 0;
			}
			return false;
		}
	}
	public static class ByteUtils
	{
		public static byte[] MergeByteList(IEnumerable<byte[]> byteList)
		{
			byte[] array = new byte[0];
			foreach (byte[] @byte in byteList)
			{
				byte[] array2 = new byte[array.Length + @byte.Length];
				Buffer.BlockCopy(array, 0, array2, 0, array.Length);
				Buffer.BlockCopy(@byte, 0, array2, array.Length, @byte.Length);
				array = array2;
			}
			return array;
		}
	}
	public static class ConsoleExtensions
	{
		public static bool InWarmupCooldown(this IConsoleBasicInfo info)
		{
			if (info.CurrentState != ConsoleState.CoolDown)
			{
				return info.CurrentState == ConsoleState.WarmUp;
			}
			return true;
		}

		public static bool IsInState(this IConsoleBasicInfo info, params ConsoleState[] states)
		{
			return states.Any((ConsoleState x) => x == info.CurrentState);
		}

		public static bool IsInRecoverableWorkout(this IConsoleBasicInfo info)
		{
			return new List<ConsoleState>
			{
				ConsoleState.WarmUp,
				ConsoleState.Workout,
				ConsoleState.CoolDown,
				ConsoleState.Paused
			}.Any((ConsoleState x) => x == info.CurrentState);
		}

		public static bool IsMock(this IFitnessConsole console)
		{
			return console is MockFitnessConsoleBase;
		}

		public static bool ReadyToStart(this IFitnessConsole console)
		{
			bool num = !(console?.ConsoleInfo?.MachineType.IsBeltBasedMachine() ?? false);
			ConsoleState consoleState = console?.LatestBasicInfo?.CurrentState ?? ConsoleState.Unknown;
			if (num)
			{
				if (consoleState != ConsoleState.Idle && consoleState != ConsoleState.WarmUp)
				{
					return consoleState == ConsoleState.Workout;
				}
				return true;
			}
			if (consoleState != ConsoleState.Idle)
			{
				return consoleState == ConsoleState.WarmUp;
			}
			return true;
		}

		public static bool IsRunningState(this ConsoleState state)
		{
			if (state == ConsoleState.Workout || state == ConsoleState.PauseOverride)
			{
				return true;
			}
			return false;
		}

		public static bool IsHybridMachine(this IFitnessConsole console)
		{
			if (console?.ConsoleInfo == null)
			{
				return false;
			}
			return SoftwareNumbers.HybridSoftwareNumbers.Contains(console.ConsoleInfo.PartNumber);
		}

		public static string ToMachineTypeLegalString(this IFitnessConsole console)
		{
			if (console?.ConsoleInfo == null)
			{
				return null;
			}
			if (console is INonconnectedFitnessConsole { MockType: var mockType })
			{
				return mockType.ToString();
			}
			if (console.IsHybridMachine())
			{
				return "HybridTrainer";
			}
			if (console.ConsoleInfo.MachineType == ConsoleType.SpinBike)
			{
				return "StudioBike";
			}
			return console.ConsoleInfo.MachineType.ToString();
		}

		public static ConsoleType ToLaunchDarklyMachineType(this IFitnessConsole console)
		{
			if (!(console is NonconnectedStrengthFitnessConsole))
			{
				return console.ConsoleInfo.MachineType;
			}
			return ConsoleType.Equipmentless;
		}

		public static bool IsNonconnectedConsole(this IFitnessConsole console)
		{
			return console is INonconnectedFitnessConsole;
		}

		public static bool IsEquipmentlessConsole(this IFitnessConsole console)
		{
			return console is IEquipmentlessConsole;
		}
	}
	public static class ConsoleTypeExtensions
	{
		public static bool IsBike(this ConsoleType type)
		{
			if (type != ConsoleType.Bike)
			{
				return type == ConsoleType.SpinBike;
			}
			return true;
		}

		public static bool IsRower(this ConsoleType type)
		{
			return type == ConsoleType.Rower;
		}

		public static bool IsElliptical(this ConsoleType type)
		{
			if (type != ConsoleType.Elliptical)
			{
				return type == ConsoleType.VerticalElliptical;
			}
			return true;
		}

		public static bool IsHiit(this ConsoleType type)
		{
			if (type != ConsoleType.Strider)
			{
				return type == ConsoleType.VerticalElliptical;
			}
			return true;
		}

		public static bool IsBeltBasedMachine(this ConsoleType consoleType)
		{
			if (consoleType != ConsoleType.Treadmill)
			{
				return consoleType == ConsoleType.InclineTrainer;
			}
			return true;
		}

		public static bool IsAerobicMachine(this ConsoleType consoleType)
		{
			return !consoleType.IsBeltBasedMachine();
		}

		public static double EstimateWorkoutSpeed(this ConsoleType type, bool isMetric)
		{
			if (isMetric)
			{
				return EstimateKph(type);
			}
			return EstimateMph(type);
		}

		private static double EstimateKph(ConsoleType type)
		{
			if (type.IsBike())
			{
				return 22.5;
			}
			return 10.0;
		}

		private static double EstimateMph(ConsoleType type)
		{
			if (type.IsBike())
			{
				return 14.0;
			}
			return 6.0;
		}

		public static string ToLegalString(this ConsoleType value)
		{
			if (value == ConsoleType.SpinBike)
			{
				return "StudioBike";
			}
			return value.ToString();
		}

		public static bool SupportsPauseOverride(this ConsoleType value)
		{
			return !value.IsBeltBasedMachine();
		}

		public static bool ConsoleTypeAllowsPauseOverrideForAllWorkoutTypes(this ConsoleType value)
		{
			if (value == ConsoleType.Rower)
			{
				return true;
			}
			return false;
		}

		public static bool IsEquipmentless(this ConsoleType value)
		{
			return value == ConsoleType.Equipmentless;
		}
	}
	public class FacadeFitnessTypeAttribute : Attribute
	{
		public FitnessValue FitnessValue { get; }

		public FacadeFitnessTypeAttribute(FitnessValue fitnessValue)
		{
			FitnessValue = fitnessValue;
		}
	}
	public class FacadeFitnessValueCache
	{
		private static readonly Dictionary<Type, FitnessValue> Cache = new Dictionary<Type, FitnessValue>();

		private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

		public bool HasEntryForType(Type facadeType)
		{
			return Cache.ContainsKey(facadeType);
		}

		public FitnessValue GetFitnessValue(Type facadeType)
		{
			try
			{
				Locker.EnterReadLock();
				return Cache[facadeType];
			}
			catch (KeyNotFoundException)
			{
				throw new ArgumentNullException($"Could not find fitness value in FacadeFitnessValueCache for {facadeType}");
			}
			finally
			{
				Locker.ExitReadLock();
			}
		}

		public void AddFitnessValue(Type facadeType, FitnessValue value)
		{
			try
			{
				Locker.EnterWriteLock();
				Cache[facadeType] = value;
			}
			finally
			{
				Locker.ExitWriteLock();
			}
		}
	}
	public class FitnessTypePropertyCache
	{
		private static readonly Dictionary<Type, Dictionary<FitnessValue, PropertyInfo>> FitnessTypePropertyMap = new Dictionary<Type, Dictionary<FitnessValue, PropertyInfo>>();

		private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

		public Dictionary<FitnessValue, PropertyInfo> RetrieveMapForType(Type type)
		{
			try
			{
				Locker.EnterUpgradeableReadLock();
				if (!FitnessTypePropertyMap.ContainsKey(type))
				{
					try
					{
						Locker.EnterWriteLock();
						FitnessTypePropertyMap.Add(type, new Dictionary<FitnessValue, PropertyInfo>());
					}
					finally
					{
						Locker.ExitWriteLock();
					}
				}
				return FitnessTypePropertyMap[type];
			}
			finally
			{
				Locker.ExitUpgradeableReadLock();
			}
		}
	}
	public interface IFitnessTypePropertyRetriever
	{
		PropertyInfo RetrieveProperty<TStateValues>(TStateValues stateValues, IReadOnlyValueFacade facade);

		FitnessValue GetFitnessValueOfFacadeType(Type type);
	}
	public class FitnessTypePropertyRetriever : IFitnessTypePropertyRetriever
	{
		private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

		private readonly FacadeFitnessValueCache facadeFitnessValueCache;

		private readonly FitnessTypePropertyCache fitnessTypePropertyCache;

		public FitnessTypePropertyRetriever(FacadeFitnessValueCache facadeFitnessValueCache, FitnessTypePropertyCache fitnessTypePropertyCache)
		{
			this.facadeFitnessValueCache = facadeFitnessValueCache;
			this.fitnessTypePropertyCache = fitnessTypePropertyCache;
		}

		public PropertyInfo RetrieveProperty<TStateValues>(TStateValues stateValues, IReadOnlyValueFacade facade)
		{
			FitnessValue fitnessValueOfFacade = GetFitnessValueOfFacade(facade);
			Dictionary<FitnessValue, PropertyInfo> map = fitnessTypePropertyCache.RetrieveMapForType(stateValues.GetType());
			return GetPropertyForFitnessType(stateValues, fitnessValueOfFacade, map);
		}

		public FitnessValue GetFitnessValueOfFacadeType(Type type)
		{
			if (!facadeFitnessValueCache.HasEntryForType(type))
			{
				FacadeFitnessTypeAttribute facadeFitnessTypeAttribute = type.GetTypeInfo().GetCustomAttributes(typeof(FacadeFitnessTypeAttribute), inherit: false).OfType<FacadeFitnessTypeAttribute>()
					.FirstOrDefault();
				if (facadeFitnessTypeAttribute == null)
				{
					throw new ArgumentNullException(string.Format("Facade type {0} does not have a {1}", type, "fitnessTypeAttributeForFacade"));
				}
				facadeFitnessValueCache.AddFitnessValue(type, facadeFitnessTypeAttribute.FitnessValue);
			}
			return facadeFitnessValueCache.GetFitnessValue(type);
		}

		private FitnessValue GetFitnessValueOfFacade(IReadOnlyValueFacade facade)
		{
			Type type = facade.GetType();
			return GetFitnessValueOfFacadeType(type);
		}

		private PropertyInfo GetPropertyForFitnessType<TStateValues>(TStateValues stateValues, FitnessValue facadeFitnessType, Dictionary<FitnessValue, PropertyInfo> map)
		{
			try
			{
				Locker.EnterUpgradeableReadLock();
				if (!map.ContainsKey(facadeFitnessType))
				{
					PropertyInfo propertyInfo = (from x in (from x in stateValues.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
							where x.GetCustomAttributes().Any((Attribute y) => y.GetType() == typeof(FitnessValueProperty))
							select x).ToDictionary((PropertyInfo x) => x, (PropertyInfo x) => x.GetCustomAttribute<FitnessValueProperty>())
						where x.Value.FitnessValue == facadeFitnessType
						select x.Key).FirstOrDefault();
					if (propertyInfo == null)
					{
						throw new ArgumentNullException($"ConsoleStateStats does not contain property to map {facadeFitnessType}");
					}
					try
					{
						Locker.EnterWriteLock();
						map.Add(facadeFitnessType, propertyInfo);
					}
					finally
					{
						Locker.ExitWriteLock();
					}
				}
				return map[facadeFitnessType];
			}
			finally
			{
				Locker.ExitUpgradeableReadLock();
			}
		}
	}
	public static class FitnessValueChangeExtensions
	{
		public static bool ChangedToState(this StateChange change, params ConsoleState[] states)
		{
			return states.Any((ConsoleState x) => x == change.Current);
		}

		public static bool ChangedFromState(this StateChange change, params ConsoleState[] states)
		{
			return states.Any((ConsoleState x) => x == change.Old);
		}

		public static bool ChangedToOrFromState(this StateChange change, params ConsoleState[] states)
		{
			bool num = states.Any((ConsoleState x) => change.ChangedToState(x));
			bool flag = states.Any((ConsoleState x) => change.ChangedFromState(x));
			return num || flag;
		}
	}
	public static class IEnumerableExtensions
	{
		private class ChunkedEnumerable<T> : IEnumerable<T>, IEnumerable
		{
			private class ChildEnumerator : IEnumerator<T>, IEnumerator, IDisposable
			{
				private ChunkedEnumerable<T> parent;

				private int position;

				private bool done;

				private T current;

				public T Current
				{
					get
					{
						if (position == -1 || done)
						{
							throw new InvalidOperationException();
						}
						return current;
					}
				}

				object IEnumerator.Current => Current;

				public ChildEnumerator(ChunkedEnumerable<T> parent)
				{
					this.parent = parent;
					position = -1;
					parent.wrapper.AddRef();
				}

				public void Dispose()
				{
					if (!done)
					{
						done = true;
						parent.wrapper.RemoveRef();
					}
				}

				public bool MoveNext()
				{
					position++;
					if (position + 1 > parent.chunkSize)
					{
						done = true;
					}
					if (!done)
					{
						done = !parent.wrapper.Get(position + parent.start, out current);
					}
					return !done;
				}

				public void Reset()
				{
					throw new NotSupportedException();
				}
			}

			private EnumeratorWrapper<T> wrapper;

			private int chunkSize;

			private int start;

			public ChunkedEnumerable(EnumeratorWrapper<T> wrapper, int chunkSize, int start)
			{
				this.wrapper = wrapper;
				this.chunkSize = chunkSize;
				this.start = start;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return new ChildEnumerator(this);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class EnumeratorWrapper<T>
		{
			private class Enumeration
			{
				public IEnumerator<T> Source { get; set; }

				public int Position { get; set; }

				public bool AtEnd { get; set; }
			}

			private Enumeration currentEnumeration;

			private int refs;

			private IEnumerable<T> SourceEnumerable { get; set; }

			public EnumeratorWrapper(IEnumerable<T> source)
			{
				SourceEnumerable = source;
			}

			public bool Get(int pos, out T item)
			{
				if (currentEnumeration != null && currentEnumeration.Position > pos)
				{
					currentEnumeration.Source.Dispose();
					currentEnumeration = null;
				}
				if (currentEnumeration == null)
				{
					currentEnumeration = new Enumeration
					{
						Position = -1,
						Source = SourceEnumerable.GetEnumerator(),
						AtEnd = false
					};
				}
				item = default(T);
				if (currentEnumeration.AtEnd)
				{
					return false;
				}
				while (currentEnumeration.Position < pos)
				{
					currentEnumeration.AtEnd = !currentEnumeration.Source.MoveNext();
					currentEnumeration.Position++;
					if (currentEnumeration.AtEnd)
					{
						return false;
					}
				}
				item = currentEnumeration.Source.Current;
				return true;
			}

			public void AddRef()
			{
				refs++;
			}

			public void RemoveRef()
			{
				refs--;
				if (refs == 0 && currentEnumeration != null)
				{
					Enumeration enumeration = currentEnumeration;
					currentEnumeration = null;
					enumeration.Source.Dispose();
				}
			}
		}

		public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
		{
			if (chunkSize < 1)
			{
				throw new InvalidOperationException();
			}
			EnumeratorWrapper<T> wrapper = new EnumeratorWrapper<T>(source);
			int currentPos = 0;
			try
			{
				wrapper.AddRef();
				T item;
				for (; wrapper.Get(currentPos, out item); currentPos += chunkSize)
				{
					yield return new ChunkedEnumerable<T>(wrapper, chunkSize, currentPos);
				}
			}
			finally
			{
				wrapper.RemoveRef();
			}
		}

		public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : struct
		{
			return from i in source
				where i.HasValue
				select i.Value;
		}
	}
	public interface IMultiReadResultSetter
	{
		void SetResultForFacade<TStateValues>(IReadOnlyValueFacade facade, AnyFitnessValueChange change, TStateValues stateValues);
	}
	public class MultiReadResultSetter : IMultiReadResultSetter
	{
		private readonly IFitnessTypePropertyRetriever propertyRetriever;

		private readonly IPropertySetterRetriever propertySetterRetriever;

		public MultiReadResultSetter(IFitnessTypePropertyRetriever propertyRetriever, IPropertySetterRetriever propertySetterRetriever)
		{
			this.propertyRetriever = propertyRetriever;
			this.propertySetterRetriever = propertySetterRetriever;
		}

		public void SetResultForFacade<TStateValues>(IReadOnlyValueFacade facade, AnyFitnessValueChange change, TStateValues stateValues)
		{
			PropertyInfo propertyInfo = propertyRetriever.RetrieveProperty(stateValues, facade);
			if (change.Current != null)
			{
				SetStateValues(facade, propertyInfo, stateValues, change);
			}
		}

		private void SetStateValues<TStateValues>(IReadOnlyValueFacade facade, PropertyInfo propertyInfo, TStateValues stateValues, AnyFitnessValueChange change)
		{
			propertySetterRetriever.RetrieveSetter<TStateValues>(propertyInfo, facade)(stateValues, facade, change.Current);
		}
	}
	public class NonGenericSubject
	{
		private readonly NonGenericObservable obs;

		public Subject<object> ReactiveSubject { get; }

		public NonGenericSubject()
		{
			ReactiveSubject = new Subject<object>();
			obs = new NonGenericObservable(ReactiveSubject);
		}

		public void OnNext()
		{
			ReactiveSubject.OnNext(null);
		}

		public static implicit operator NonGenericObservable(NonGenericSubject sub)
		{
			return sub.obs;
		}
	}
	public class NonGenericObservable : IObservable<object>
	{
		private readonly Subject<object> sub;

		internal NonGenericObservable(Subject<object> sub)
		{
			this.sub = sub;
		}

		public IDisposable Subscribe(IObserver<object> observer)
		{
			return sub.Subscribe(observer);
		}
	}
	public static class ObjectExtensions
	{
		public static bool IsNumber(this object value)
		{
			if (!(value is sbyte) && !(value is byte) && !(value is short) && !(value is ushort) && !(value is int) && !(value is uint) && !(value is long) && !(value is ulong) && !(value is float) && !(value is double))
			{
				return value is decimal;
			}
			return true;
		}
	}
	public static class ObservableExtensions
	{
		private const string Tag = "Observable";

		public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action<Exception> onError, Action onCompleted)
		{
			return observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onError, onCompleted);
		}

		public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action<Exception> onError)
		{
			return observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onError);
		}

		public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action onCompleted)
		{
			return observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onCompleted);
		}

		public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext)
		{
			return observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe();
		}

		public static void SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action<Exception> onError, Action onCompleted, CancellationToken token)
		{
			observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onError, onCompleted, token);
		}

		public static void SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action<Exception> onError, CancellationToken token)
		{
			observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onError, token);
		}

		public static void SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action onCompleted, CancellationToken token)
		{
			observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, onCompleted, token);
		}

		public static void SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, CancellationToken token)
		{
			observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, token);
		}

		private static void EmptyAction(object obj = null)
		{
		}

		public static void SubscribeOrInvoke<T>(this IObservable<T> whenObjChanged, T obj, Action<T> action, ref IDisposable subRef)
		{
			if (!EqualityComparer<T>.Default.Equals(obj, default(T)))
			{
				action(obj);
				return;
			}
			subRef?.Dispose();
			subRef = whenObjChanged.Subscribe(action);
		}

		public static void SubscribeAndInvoke<T>(this IObservable<T> whenObjChanged, T obj, Action<T> action, ref IDisposable subRef)
		{
			if (!EqualityComparer<T>.Default.Equals(obj, default(T)))
			{
				action(obj);
			}
			subRef?.Dispose();
			subRef = whenObjChanged.Subscribe(action);
		}

		public static IDisposable SubscribeWithErrorLogging<T>(this IObservable<T> obs, Action<T> onNext)
		{
			return obs.Subscribe(onNext, delegate(Exception ex)
			{
				Log.Error("Observable", $"{ex}");
			});
		}

		public static IDisposable SubscribeWithErrorLogging<T>(this IObservable<T> obs, Action<T> onNext, Action onCompleted)
		{
			return obs.Subscribe(onNext, delegate(Exception ex)
			{
				Log.Error("Observable", $"{ex}");
			}, onCompleted);
		}

		public static IDisposable SubscribeAsyncWithErrorLogging<T>(this IObservable<T> observable, Func<T, Task> onNext)
		{
			return observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, delegate(Exception ex)
			{
				Log.Error("Observable", $"{ex}");
			});
		}

		public static IDisposable SubscribeAsyncWithErrorLogging<T>(this IObservable<T> obs, Func<T, Task> onNext, Action onCompleted)
		{
			return obs.SubscribeAsync(onNext, delegate(Exception ex)
			{
				Log.Error("Observable", $"{ex}");
			}, onCompleted);
		}

		public static void SubscribeAsyncWithErrorLogging<T>(this IObservable<T> observable, Func<T, Task> onNext, CancellationToken token)
		{
			observable.Select((Func<T, Task>)async delegate(T x)
			{
				await onNext(x);
			}).Subscribe(EmptyAction, delegate(Exception ex)
			{
				Log.Error("Observable", $"{ex}");
			}, token);
		}

		public static IDisposable SubscribeWithAsyncErrorHandler<T>(this IObservable<T> obs, Action<T> onNext, Func<Exception, Task> onError)
		{
			return obs.Subscribe(onNext, delegate(Exception ex)
			{
				Task.Run(async delegate
				{
					await onError(ex);
				});
			});
		}

		public static IObservable<T> SampleFirst<T>(this IObservable<T> source, TimeSpan sampleDuration, IScheduler scheduler = null)
		{
			scheduler = scheduler ?? Scheduler.Default;
			return source.Publish((IObservable<T> ps) => ps.Window(() => ps.Delay(sampleDuration, scheduler)).SelectMany((IObservable<T> x) => x.Take(1)));
		}
	}
	public interface IPropertySetterRetriever
	{
		Action<object, IReadOnlyValueFacade, object> RetrieveSetter<TStateValues>(PropertyInfo property, IReadOnlyValueFacade facade);
	}
	public class PropertySetterRetriever : IPropertySetterRetriever
	{
		private static readonly Dictionary<Type, Dictionary<PropertyInfo, Action<object, IReadOnlyValueFacade, object>>> TypePropertySetters = new Dictionary<Type, Dictionary<PropertyInfo, Action<object, IReadOnlyValueFacade, object>>>();

		private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

		public Action<object, IReadOnlyValueFacade, object> RetrieveSetter<TStateValues>(PropertyInfo property, IReadOnlyValueFacade facade)
		{
			Type typeFromHandle = typeof(TStateValues);
			try
			{
				Locker.EnterUpgradeableReadLock();
				if (!TypePropertySetters.ContainsKey(typeFromHandle))
				{
					try
					{
						Locker.EnterWriteLock();
						TypePropertySetters[typeFromHandle] = new Dictionary<PropertyInfo, Action<object, IReadOnlyValueFacade, object>>();
					}
					finally
					{
						Locker.ExitWriteLock();
					}
				}
				Dictionary<PropertyInfo, Action<object, IReadOnlyValueFacade, object>> dictionary = TypePropertySetters[typeFromHandle];
				if (!dictionary.ContainsKey(property))
				{
					AddSetterToCache<TStateValues>(facade, property);
				}
				return dictionary[property];
			}
			finally
			{
				Locker.ExitUpgradeableReadLock();
			}
		}

		private void AddSetterToCache<TStateValues>(IReadOnlyValueFacade facade, PropertyInfo propertyInfo)
		{
			Dictionary<PropertyInfo, Action<object, IReadOnlyValueFacade, object>> dictionary = TypePropertySetters[typeof(TStateValues)];
			Type type = facade.GetType();
			Type type2 = type.GetTypeInfo()?.BaseType?.GetGenericArguments()?.FirstOrDefault();
			if (type2 == null)
			{
				throw new ArgumentNullException($"Could not get generic type arguments for {type}");
			}
			Type genericFacadeType = typeof(ReadOnlyValueFacade<>).MakeGenericType(type2);
			Action<object, IReadOnlyValueFacade, object> value = CreateSetDelegate(type2, typeof(TStateValues), genericFacadeType, propertyInfo);
			try
			{
				Locker.EnterWriteLock();
				dictionary.Add(propertyInfo, value);
			}
			finally
			{
				Locker.ExitWriteLock();
			}
		}

		private Action<object, IReadOnlyValueFacade, object> CreateSetDelegate(Type propertyType, Type stateValueType, Type genericFacadeType, PropertyInfo property)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "stateValues");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(IReadOnlyValueFacade), "facade");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(object), "changeValue");
			UnaryExpression expression = Expression.Convert(parameterExpression, stateValueType);
			MethodInfo methodInfo = genericFacadeType.GetMethods().FirstOrDefault((MethodInfo x) => x.Name == "Convert");
			if (methodInfo == null)
			{
				throw new ArgumentNullException($"Could not find Convert method from type {genericFacadeType}");
			}
			MethodCallExpression methodCallExpression = Expression.Call(Expression.Convert(parameterExpression2, genericFacadeType), methodInfo, parameterExpression3);
			MemberExpression left = Expression.Property(expression, property);
			BinaryExpression body;
			if (propertyType != property.PropertyType)
			{
				UnaryExpression right = Expression.Convert(methodCallExpression, property.PropertyType);
				body = Expression.Assign(left, right);
			}
			else
			{
				body = Expression.Assign(left, methodCallExpression);
			}
			return Expression.Lambda<Action<object, IReadOnlyValueFacade, object>>(body, new ParameterExpression[3] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
		}
	}
	public static class RowerEstimator
	{
		public static double CalculateEstimatedStrokeCount(double spm, double seconds)
		{
			return spm * seconds / 60.0;
		}

		public static double CalculateEstimatedDistance(double estimatedStrokeCount, double height)
		{
			return estimatedStrokeCount * 8.0 * height / 1.75;
		}

		public static double CalculateEstimatedDistance(double spm, double seconds, double height)
		{
			return CalculateEstimatedDistance(CalculateEstimatedStrokeCount(spm, seconds), height);
		}
	}
	public static class SoftwareNumbers
	{
		public const int NonConnectedTreadmill = 424110;

		public const int NonConnectedBike = 424111;

		public const int NonConnectedHeadlessBike = 438701;

		public const int NonConnectedRower = 424112;

		public const int NonConnectedElliptical = 424113;

		public const int NonConnectedStrength = 424992;

		public const int NonConnectedYoga = 433917;

		public const int NonConnectedMind = 433918;

		public const int NonConnectedNutrition = 433946;

		public const int NonConnectedCore = 433947;

		public const int NonConnectedSleep = 433948;

		public const int NonConnectedStretch = 433949;

		public static readonly ReadOnlyCollection<int> HybridSoftwareNumbers = new ReadOnlyCollection<int>(new List<int> { 391991, 371895, 371897 });

		public static readonly ReadOnlyCollection<int> NonConnectedSoftwareNumbers = new ReadOnlyCollection<int>(new List<int>
		{
			424110, 424111, 424112, 424113, 424992, 433917, 433918, 433946, 433947, 433948,
			433949
		});
	}
	public static class TaskContinueWithException
	{
		private const string Tag = "FatalUnhandledThreadException";

		public static string FlattenException(Exception exception)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (exception != null)
			{
				stringBuilder.AppendLine(exception.Message);
				stringBuilder.AppendLine(exception.StackTrace);
				exception = exception.InnerException;
			}
			return stringBuilder.ToString();
		}

		public static void LogThreadException(Exception ex)
		{
			Log.Error("FatalUnhandledThreadException", FlattenException(ex));
		}

		public static void LogEx(Task t)
		{
			t.Exception.Handle(delegate(Exception ex)
			{
				LogThreadException(ex);
				return false;
			});
		}
	}
	public static class TypeExtensions
	{
		public static FitnessValue[] GetFitnessValuesForPropertyAttributes(this Type type)
		{
			return (from x in type.GetTypeInfo().DeclaredProperties
				select (x.GetCustomAttribute(typeof(FitnessValueProperty)) as FitnessValueProperty)?.FitnessValue into x
				where x.HasValue
				select x.Value).ToArray();
		}
	}
	public class WorkoutSegment
	{
		public delegate WorkoutSegment Builder(double incline, double relativeResistance, double mps, double atValueDifference, double spm, double estimatedBpm = 0.0);

		public double ElevationChange => Incline / 100.0 * Meters;

		public double Incline { get; private set; }

		public double Meters { get; private set; }

		public double Mps { get; private set; }

		public double RelativeResistance { get; private set; }

		public double Seconds { get; private set; }

		public double Spm { get; private set; }

		public double EstimatedBpm { get; private set; }

		private WorkoutSegment(double incline, double mps, double meters, double relativeResistance, double seconds, double spm, double estimatedBpm = 0.0)
		{
			Incline = incline;
			Mps = mps;
			Meters = meters;
			RelativeResistance = relativeResistance;
			Seconds = seconds;
			Spm = spm;
			EstimatedBpm = estimatedBpm;
		}

		public static WorkoutSegment FromMeters(double incline, double relativeResistance, double mps, double meters, double spm, double estimatedBpm = 0.0)
		{
			mps = mps.Clamp(0.0, 1.7976931348623157E+308);
			meters = meters.Clamp(0.0, 1.7976931348623157E+308);
			double seconds = (mps.Equals(0.0) ? 0.0 : (meters / mps));
			spm = spm.Clamp(0.0, 1.7976931348623157E+308);
			return new WorkoutSegment(incline, mps, meters, relativeResistance, seconds, spm, estimatedBpm);
		}

		public static WorkoutSegment FromSeconds(double incline, double relativeResistance, double mps, double seconds, double spm, double estimatedBpm = 0.0)
		{
			mps = mps.Clamp(0.0, 1.7976931348623157E+308);
			seconds = seconds.Clamp(0.0, 1.7976931348623157E+308);
			double meters = mps * seconds;
			spm = spm.Clamp(0.0, 1.7976931348623157E+308);
			return new WorkoutSegment(incline, mps, meters, relativeResistance, seconds, spm, estimatedBpm);
		}

		public override string ToString()
		{
			return string.Format("[WorkoutSegment: {0}={1:0.0#####}, {2}={3:0.0#####}, {4}={5:0.0#####}, {6}={7:0.0#####}, {8}={9:0.0#####}, {10}={11:0.0#####}, {12}={13:0.0#####}, {14}={15:0.0#####}]", "Meters", Meters, "Mps", Mps, "Seconds", Seconds, "RelativeResistance", RelativeResistance, "Incline", Incline, "ElevationChange", ElevationChange, "Spm", Spm, "EstimatedBpm", EstimatedBpm);
		}

		public override int GetHashCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(typeof(WorkoutSegment).FullName + ":");
			stringBuilder.Append(Incline.ToString("e") + ",");
			stringBuilder.Append(Meters.ToString("e") + ",");
			stringBuilder.Append(Mps.ToString("e") + ",");
			stringBuilder.Append(RelativeResistance.ToString("e") + ",");
			stringBuilder.Append(Seconds.ToString("e") + ",");
			stringBuilder.Append(Spm.ToString("e") + ",");
			stringBuilder.Append(EstimatedBpm.ToString("e") + ",");
			return stringBuilder.ToString().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj == this)
			{
				return true;
			}
			if (obj is WorkoutSegment workoutSegment)
			{
				return GetHashCode().Equals(workoutSegment.GetHashCode());
			}
			return false;
		}
	}
	public static class WorkoutSegmentExtensions
	{
		private static readonly Dictionary<ConsoleType, CalorieFormulas.FormulaDelegate> ConsoleTypeCalorieEstimators = new Dictionary<ConsoleType, CalorieFormulas.FormulaDelegate>
		{
			{
				ConsoleType.Treadmill,
				CalorieFormulas.Running
			},
			{
				ConsoleType.InclineTrainer,
				CalorieFormulas.Running
			},
			{
				ConsoleType.Bike,
				CalorieFormulas.Bike
			},
			{
				ConsoleType.SpinBike,
				CalorieFormulas.Bike
			},
			{
				ConsoleType.Rower,
				CalorieFormulas.Rower
			},
			{
				ConsoleType.Elliptical,
				CalorieFormulas.Elliptical
			},
			{
				ConsoleType.FreeStrider,
				CalorieFormulas.Elliptical
			},
			{
				ConsoleType.Strider,
				CalorieFormulas.Elliptical
			},
			{
				ConsoleType.VerticalElliptical,
				CalorieFormulas.VerticalElliptical
			}
		};

		public static double EstimateCalories(this WorkoutSegment segment, ConsoleType type, double userKg, double userHeight, double userAge, bool userMale, AerobicWatts.Table? table = null)
		{
			if (type == ConsoleType.Equipmentless)
			{
				return segment.EstimateCaloriesByEstimatedHeartRate(userKg, userAge, userMale);
			}
			if (!ConsoleTypeCalorieEstimators.ContainsKey(type))
			{
				throw new ArgumentException($"Unsupported console type: {type}", "type");
			}
			if (type.IsRower())
			{
				return ConsoleTypeCalorieEstimators[type](userHeight, segment.Seconds, segment.Spm, segment.RelativeResistance, null);
			}
			double inclineOrRelativeResistance = (table.HasValue ? segment.RelativeResistance : segment.Incline);
			return ConsoleTypeCalorieEstimators[type](userKg, segment.Seconds, segment.Mps, inclineOrRelativeResistance, table);
		}

		public static double EstimateCaloriesByEstimatedHeartRate(this WorkoutSegment segment, double userKg, double userAge, bool userMale)
		{
			return CalorieFormulas.HeartRate(segment.Seconds, segment.EstimatedBpm, userKg, userAge, userMale);
		}
	}
}
namespace Sindarin.Core.Util.Calories
{
	public static class AerobicWatts
	{
		public struct Table(string consoleName, double mph, int partNumber, IList<int> rrs, IList<double> watts)
		{
			public readonly string ConsoleName = consoleName;

			public readonly double SpeedMph = mph;

			public readonly int PartNumber = partNumber;

			public readonly IList<int> RelativeResistances = rrs;

			public readonly IList<double> Wattages = watts;
		}

		public static readonly IReadOnlyDictionary<int, Table> Tables = new ReadOnlyDictionary<int, Table>(new Dictionary<int, Table>
		{
			{
				373430,
				new Table("EBPF01215", 14.0, 373430, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					31.0, 38.0, 47.0, 66.0, 91.0, 129.0, 183.0, 252.0, 342.0, 451.0,
					570.0
				})
			},
			{
				390827,
				new Table("EBPF01215v1", 14.0, 390827, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					31.0, 38.0, 47.0, 66.0, 91.0, 129.0, 183.0, 252.0, 342.0, 451.0,
					570.0
				})
			},
			{
				397861,
				new Table("EBPF01418", 14.0, 397861, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.0, 36.0, 45.0, 72.0, 115.0, 192.0, 341.0, 496.0, 645.0, 791.0,
					850.0
				})
			},
			{
				392570,
				new Table("EBNT02117", 14.0, 392570, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					9.0, 14.0, 29.0, 59.0, 128.0, 221.0, 342.0, 501.0, 667.0, 850.0,
					989.0
				})
			},
			{
				394629,
				new Table("EBNT05117", 14.0, 394629, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					9.0, 14.0, 29.0, 59.0, 128.0, 221.0, 342.0, 501.0, 667.0, 850.0,
					989.0
				})
			},
			{
				396909,
				new Table("EBNT70417", 14.0, 396909, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					65.0, 76.0, 88.0, 102.0, 118.0, 145.0, 175.0, 212.0, 254.0, 300.0,
					317.0
				})
			},
			{
				396913,
				new Table("EBNT71017", 14.0, 396913, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					65.0, 76.0, 88.0, 102.0, 118.0, 145.0, 175.0, 212.0, 254.0, 300.0,
					317.0
				})
			},
			{
				381158,
				new Table("EBPE71316", 14.0, 381158, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					31.0, 38.0, 47.0, 66.0, 91.0, 129.0, 183.0, 252.0, 342.0, 451.0,
					570.0
				})
			},
			{
				392860,
				new Table("ELS012916V1", 6.0, 392860, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				396917,
				new Table("ELPF01415V1", 6.0, 396917, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				392864,
				new Table("ELS014914V2", 6.0, 392864, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				371918,
				new Table("ELPF01715", 6.0, 371918, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					57.2, 61.0, 68.4, 77.8, 90.8, 106.8, 128.4, 158.4, 195.4, 244.8,
					296.6
				})
			},
			{
				391987,
				new Table("ELPF01717", 6.0, 391987, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				386344,
				new Table("ELPF02916", 6.0, 386344, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.4, 27.2, 29.0, 32.8, 38.4, 46.8, 55.0, 65.4, 83.0, 90.4,
					102.8
				})
			},
			{
				391991,
				new Table("ELPF03717", 6.0, 391991, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					20.8, 22.6, 23.6, 27.4, 30.2, 36.8, 44.4, 55.0, 67.6, 84.2,
					100.8
				})
			},
			{
				392731,
				new Table("ELS039917", 6.0, 392731, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				375138,
				new Table("ELPF04915", 6.0, 375138, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.4, 27.2, 29.0, 32.8, 38.4, 46.8, 55.0, 65.4, 83.0, 90.4,
					102.8
				})
			},
			{
				385948,
				new Table("ELPF04916", 6.0, 385948, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					78.6, 83.6, 104.0, 124.4, 133.6, 172.8, 187.4, 229.8, 313.4, 346.6,
					418.4
				})
			},
			{
				382723,
				new Table("ELS059916", 6.0, 382723, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				392911,
				new Table("ELS059917", 6.0, 392911, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				385885,
				new Table("ELPF06916", 6.0, 385885, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					78.6, 83.6, 104.0, 124.4, 133.6, 172.8, 187.4, 229.8, 313.4, 346.6,
					418.4
				})
			},
			{
				392996,
				new Table("ELS069917", 6.0, 392996, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				375774,
				new Table("ELNT07915", 6.0, 375774, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				382721,
				new Table("ELS079816", 6.0, 382721, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				393749,
				new Table("ELS079915V1", 6.0, 393749, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				382719,
				new Table("ELS079916", 6.0, 382719, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				397496,
				new Table("ELPF08916V1", 6.0, 397496, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				395689,
				new Table("ELNT09717", 6.0, 395689, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				375142,
				new Table("ELPF09915", 6.0, 375142, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					31.4, 32.2, 38.8, 55.6, 87.8, 146.6, 220.0, 306.2, 393.6, 456.0,
					498.2
				})
			},
			{
				397832,
				new Table("ELPE10716", 6.0, 397832, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					57.2, 61.0, 68.4, 77.8, 90.8, 106.8, 128.4, 158.4, 195.4, 244.8,
					296.6
				})
			},
			{
				382603,
				new Table("ELNE13016", 6.0, 382603, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				397536,
				new Table("ELNT14416V1", 6.0, 397536, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				385025,
				new Table("ELPF31016", 6.0, 385025, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				397460,
				new Table("ELPF31115V1", 6.0, 397460, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				386076,
				new Table("ELPE39616", 6.0, 386076, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					29.0, 31.0, 35.6, 41.2, 50.4, 61.8, 76.8, 94.4, 117.6, 140.2,
					159.6
				})
			},
			{
				380084,
				new Table("ELPE39716", 6.0, 380084, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					24.4, 26.2, 29.0, 33.6, 38.2, 45.8, 54.2, 66.2, 82.0, 98.0,
					110.2
				})
			},
			{
				388957,
				new Table("ELPE39717", 6.0, 388957, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.4, 27.2, 29.0, 32.8, 38.4, 46.8, 55.0, 65.4, 83.0, 90.4,
					102.8
				})
			},
			{
				379075,
				new Table("ELNI49416", 6.0, 379075, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				379257,
				new Table("ELPE49716", 6.0, 379257, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					47.8, 52.4, 60.0, 71.0, 86.0, 107.4, 129.0, 159.0, 194.6, 228.4,
					247.0
				})
			},
			{
				388959,
				new Table("ELPE49717", 6.0, 388959, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.4, 27.2, 29.0, 32.8, 38.4, 46.8, 55.0, 65.4, 83.0, 90.4,
					102.8
				})
			},
			{
				397169,
				new Table("ELPF51016V1", 6.0, 397169, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				395884,
				new Table("ELPF51517", 6.0, 395884, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				384481,
				new Table("ELPF55916", 6.0, 384481, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				384483,
				new Table("ELPF57916", 6.0, 384483, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				397918,
				new Table("ELPF59718", 6.0, 397918, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				390574,
				new Table("ELPE60717", 6.0, 390574, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					78.6, 83.6, 104.0, 124.4, 133.6, 172.8, 187.4, 229.8, 313.4, 346.6,
					418.4
				})
			},
			{
				370439,
				new Table("ELGG62915", 6.0, 370439, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				370721,
				new Table("ELGG63915", 6.0, 370721, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					25.4, 27.2, 29.0, 32.8, 38.4, 46.8, 55.0, 65.4, 83.0, 90.4,
					102.8
				})
			},
			{
				386707,
				new Table("ELNI69016", 6.0, 386707, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				379259,
				new Table("ELPE69716", 6.0, 379259, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				382457,
				new Table("ELNE69816", 6.0, 382457, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				381156,
				new Table("ELPE71216", 6.0, 381156, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					31.4, 32.2, 38.8, 55.6, 87.8, 146.6, 220.0, 306.2, 393.6, 456.0,
					498.2
				})
			},
			{
				396818,
				new Table("ELNT71218", 6.0, 396818, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				374145,
				new Table("ELNT71315", 6.0, 374145, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					129.4, 136.2, 153.8, 174.4, 206.0, 241.6, 289.4, 357.0, 441.4, 552.4,
					669.6
				})
			},
			{
				395369,
				new Table("ELNT71317", 6.0, 395369, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					129.4, 136.2, 153.8, 174.4, 206.0, 241.6, 289.4, 357.0, 441.4, 552.4,
					669.6
				})
			},
			{
				397239,
				new Table("ELNT71318", 6.0, 397239, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				396822,
				new Table("ELNT71418", 6.0, 396822, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				396213,
				new Table("ELNT71518", 6.0, 396213, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				395365,
				new Table("ELNT71617", 6.0, 395365, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					129.4, 136.2, 153.8, 174.4, 206.0, 241.6, 289.4, 357.0, 441.4, 552.4,
					669.6
				})
			},
			{
				397243,
				new Table("ELNT71618", 6.0, 397243, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				397490,
				new Table("ELNT71817", 6.0, 397490, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					42.0, 44.8, 51.4, 60.8, 72.8, 87.6, 106.4, 132.4, 157.6, 176.4,
					198.0
				})
			},
			{
				383429,
				new Table("ELNT79916", 6.0, 383429, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				397246,
				new Table("ELNT79918", 6.0, 397246, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				390576,
				new Table("ELPE80717", 6.0, 390576, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					78.6, 83.6, 104.0, 124.4, 133.6, 172.8, 187.4, 229.8, 313.4, 346.6,
					418.4
				})
			},
			{
				400173,
				new Table("ELFM84418", 6.0, 400173, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				379857,
				new Table("ELPE89716", 6.0, 379857, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				382453,
				new Table("ELNE89816", 6.0, 382453, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				385116,
				new Table("ELNT99416", 6.0, 385116, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					48.8, 63.8, 76.8, 94.4, 117.2, 145.0, 167.6, 187.2, 197.6, 209.4,
					217.0
				})
			},
			{
				382727,
				new Table("EBS029916", 14.0, 382727, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				392994,
				new Table("EBS029917", 14.0, 392994, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				371895,
				new Table("ELPF03815", 14.0, 371895, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					33.0, 36.0, 40.0, 45.0, 52.0, 62.0, 76.0, 96.0, 118.0, 145.0,
					175.0
				})
			},
			{
				382725,
				new Table("EBS039916", 14.0, 382725, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				371897,
				new Table("ELPF05815", 14.0, 371897, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					33.0, 36.0, 40.0, 45.0, 52.0, 62.0, 76.0, 96.0, 118.0, 145.0,
					175.0
				})
			},
			{
				383730,
				new Table("EBPF11916", 14.0, 383730, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					17.0, 19.0, 27.0, 37.0, 51.0, 65.0, 79.0, 96.0, 115.0, 141.0,
					162.0
				})
			},
			{
				394675,
				new Table("EBPF14817", 14.0, 394675, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				394677,
				new Table("EBPF15917", 14.0, 394677, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				373116,
				new Table("EBPF52915", 14.0, 373116, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					89.0, 95.0, 111.0, 139.0, 153.0, 197.0, 241.0, 281.0, 341.0, 400.0,
					443.0
				})
			},
			{
				373118,
				new Table("EBPF53915", 14.0, 373118, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					150.0, 158.0, 197.0, 236.0, 252.0, 329.0, 356.0, 435.0, 587.0, 644.0,
					778.0
				})
			},
			{
				386705,
				new Table("EBNI59016", 14.0, 386705, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				370357,
				new Table("EBGG61615", 14.0, 370357, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				370425,
				new Table("EBGG61715", 14.0, 370425, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				388355,
				new Table("EBPE71917", 14.0, 388355, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					17.0, 19.0, 27.0, 37.0, 51.0, 65.0, 79.0, 96.0, 115.0, 141.0,
					162.0
				})
			},
			{
				381384,
				new Table("EBPE72916", 14.0, 381384, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					83.0, 88.0, 103.0, 124.0, 152.0, 192.0, 240.0, 285.0, 320.0, 331.0,
					341.0
				})
			},
			{
				388955,
				new Table("EBPE73017", 14.0, 388955, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					79.0, 86.0, 99.0, 117.0, 140.0, 169.0, 207.0, 257.0, 303.0, 340.0,
					378.0
				})
			},
			{
				381386,
				new Table("EBPE73916", 14.0, 381386, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					58.0, 62.0, 74.0, 89.0, 112.0, 160.0, 180.0, 215.0, 243.0, 268.0,
					295.0
				})
			},
			{
				381704,
				new Table("EBPE74016", 14.0, 381704, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					54.0, 57.0, 67.0, 79.0, 96.0, 119.0, 149.0, 182.0, 226.0, 270.0,
					303.0
				})
			},
			{
				381706,
				new Table("EBPE74916", 14.0, 381706, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					71.0, 73.0, 83.0, 98.0, 114.0, 136.0, 164.0, 201.0, 241.0, 286.0,
					330.0
				})
			},
			{
				386464,
				new Table("EBNT75016", 14.0, 386464, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				390167,
				new Table("EBNE75017", 14.0, 390167, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					70.0, 75.0, 88.0, 102.0, 120.0, 141.0, 166.0, 200.0, 241.0, 287.0,
					324.0
				})
			},
			{
				386466,
				new Table("EBNT76016", 14.0, 386466, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				390578,
				new Table("EBNE76017", 14.0, 390578, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					69.0, 76.0, 86.0, 100.0, 115.0, 137.0, 164.0, 198.0, 242.0, 296.0,
					347.0
				})
			},
			{
				396472,
				new Table("EBNT76918", 14.0, 396472, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					79.0, 86.0, 99.0, 117.0, 140.0, 169.0, 207.0, 257.0, 303.0, 340.0,
					378.0
				})
			},
			{
				399044,
				new Table("EBPF78918", 14.0, 399044, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				379077,
				new Table("EBNI83016", 14.0, 379077, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				381388,
				new Table("EBNE83916", 14.0, 381388, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					54.0, 57.0, 67.0, 79.0, 96.0, 119.0, 149.0, 182.0, 226.0, 270.0,
					303.0
				})
			},
			{
				393760,
				new Table("EBNT84017", 14.0, 393760, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					90.0, 120.0, 143.0, 177.0, 219.0, 271.0, 311.0, 351.0, 369.0, 386.0,
					399.0
				})
			},
			{
				381389,
				new Table("EBNE84916", 14.0, 381389, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					71.0, 73.0, 83.0, 98.0, 114.0, 136.0, 164.0, 201.0, 241.0, 286.0,
					330.0
				})
			},
			{
				396475,
				new Table("EBNT89918", 14.0, 396475, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					79.0, 86.0, 99.0, 117.0, 140.0, 169.0, 207.0, 257.0, 303.0, 340.0,
					378.0
				})
			},
			{
				397922,
				new Table("EBPF99718", 14.0, 397922, new int[11]
				{
					0, 10, 20, 30, 40, 50, 60, 70, 80, 90,
					100
				}, new double[11]
				{
					62.0, 68.0, 79.0, 92.0, 110.0, 135.0, 163.0, 211.0, 271.0, 400.0,
					575.0
				})
			}
		});
	}
	public static class CalorieFormulas
	{
		public delegate double FormulaDelegate(double kg, double seconds, double mps, double inclineOrRelativeResistance, AerobicWatts.Table? table);

		public const double DefaultHeartRate = 125.0;

		public static double Running(double kg, double seconds, double mps, double avgGrade, AerobicWatts.Table? table = null)
		{
			if (avgGrade == -6.0)
			{
				avgGrade = -5.5;
			}
			avgGrade /= 100.0;
			double num = 0.0;
			double num2 = 0.1 * mps + 1.8 * mps * avgGrade + 0.058333;
			double num3 = 0.2 * mps + 0.9 * mps * avgGrade + 0.058333;
			num = ((mps < 1.6) ? num2 : ((!(mps > 2.0)) ? MathUtils.Lerp(num2, num3, (mps - 1.6) / 0.3999999999999999) : num3));
			return OxygenConsumedToCalories(num, kg, seconds);
		}

		public static double Bike(double kg, double seconds, double mps, double inclineOrRelativeResistance, AerobicWatts.Table? table)
		{
			double watts = EstimateCyclicalWatts(kg, mps, inclineOrRelativeResistance, table);
			return Bike(kg, seconds, watts);
		}

		public static double Bike(double kg, double seconds, double watts)
		{
			return OxygenConsumedToCalories(10.8 * watts / (60.0 * kg) + 0.11666, kg, seconds);
		}

		public static double Elliptical(double kg, double seconds, double mps, double inclineOrRelativeResistance, AerobicWatts.Table? table)
		{
			double watts = EstimateCyclicalWatts(kg, mps, inclineOrRelativeResistance, table);
			return Elliptical(kg, seconds, watts);
		}

		public static double Elliptical(double kg, double seconds, double watts)
		{
			return OxygenConsumedToCalories(1.15 * (10.8 * watts / (60.0 * kg) + 0.11666), kg, seconds);
		}

		public static double VerticalElliptical(double kg, double seconds, double mps, double inclineOrRelativeResistance)
		{
			return VerticalElliptical(kg, seconds, mps, inclineOrRelativeResistance, null);
		}

		public static double VerticalElliptical(double kg, double seconds, double mps, double inclineOrRelativeResistance, AerobicWatts.Table? table)
		{
			double watts = EstimateCyclicalWatts(kg, mps, inclineOrRelativeResistance, table);
			return VerticalElliptical(kg, seconds, watts);
		}

		public static double VerticalElliptical(double kg, double seconds, double watts)
		{
			return OxygenConsumedToCaloriesForVerticalElliptical(10.8 * watts / (60.0 * kg) + 0.11666, kg, seconds);
		}

		public static double EstimateCyclicalWatts(double kg, double mps, double inclineOrResistance, AerobicWatts.Table? table)
		{
			if (table.HasValue)
			{
				IList<int> relativeResistances = table.Value.RelativeResistances;
				IList<double> wattages = table.Value.Wattages;
				if (wattages.Count() >= relativeResistances.Count())
				{
					for (int i = 0; i < relativeResistances.Count(); i++)
					{
						if (i == relativeResistances.Count - 1)
						{
							return wattages[i];
						}
						int num = relativeResistances[i + 1];
						if (!(inclineOrResistance >= (double)num))
						{
							int num2 = relativeResistances[i];
							int num3 = num - num2;
							double ratio = ((num3 > 0) ? ((inclineOrResistance - (double)num2) / (double)num3) : 0.0);
							double left = wattages[i];
							double right = wattages[i + 1];
							return MathUtils.Lerp(left, right, ratio);
						}
					}
				}
			}
			double num4 = inclineOrResistance / 100.0;
			return Math.Max(0.0, 9.8067 * mps * (kg + 10.0) * (0.0053 + num4) + 0.185 * Math.Pow(mps, 3.0));
		}

		public static double OxygenConsumedToCaloriesForVerticalElliptical(double vo2, double kg, double seconds)
		{
			return 0.0289 * vo2 * Math.Pow(kg, 2.0) / 1000.0 * 5.0 * seconds;
		}

		public static double OxygenConsumedToCalories(double vo2, double kg, double seconds)
		{
			return vo2 * kg / 1000.0 * 5.0 * seconds;
		}

		public static double Rower(double height, double seconds, double spm, double resistance, AerobicWatts.Table? table = null)
		{
			double watts = EstimateRowerPower(resistance, spm, height);
			return Rower(seconds, watts);
		}

		public static double Rower(double seconds, double watts)
		{
			return CalculateRowerVo2(watts) * seconds / 200.0;
		}

		private static double EstimateRowerPower(double resistance, double spm, double height)
		{
			double num = resistance * 0.01;
			return (num + (1.0 - num) * 0.25) * spm * height * 5.0;
		}

		private static double CalculateRowerVo2(double power)
		{
			return 0.20833 * power + 6.92;
		}

		public static double HeartRate(double seconds, double heartRateBpm, double userKg, double userAge, bool userMale)
		{
			if (seconds <= 0.0)
			{
				return 0.0;
			}
			double val = (userMale ? ((-55.0969 + 0.6309 * heartRateBpm + 0.1988 * userKg + 0.2017 * userAge) * 0.239005736 * (seconds / 60.0)) : ((-20.4022 + 0.4472 * heartRateBpm - 0.1263 * userKg + 0.074 * userAge) * 0.239005736 * (seconds / 60.0)));
			double val2 = 0.0002916 * userKg * seconds;
			return Math.Max(val, val2);
		}
	}
	public static class CalorieMultiplierCalculator
	{
		public const double OffEquipmentValue = 0.10303;

		public static double CalculateOffEquipmentAerobicCaloriesDelta(int lastTime, int currentTime, double massKg, List<CalorieMultiplierEvent> events)
		{
			double num = 0.0;
			for (int i = lastTime + 1; i <= currentTime; i++)
			{
				num += CalculateOffEquipmentAerobicCalories(i, massKg, 1.0, events);
			}
			return num;
		}

		public static double CalculateOffEquipmentAerobicCalories(int currentTime, double massKg, double seconds, List<CalorieMultiplierEvent> events)
		{
			double result = 0.0;
			CalorieMultiplierEvent calorieEventForTime = GetCalorieEventForTime(events, currentTime);
			if (calorieEventForTime != null)
			{
				result = CalculateAerobicCalories(0.10303 * calorieEventForTime.Multiplier, massKg, seconds);
			}
			return result;
		}

		public static CalorieMultiplierEvent GetCalorieEventForTime(List<CalorieMultiplierEvent> calorieMultiplierEvents, int time)
		{
			return calorieMultiplierEvents?.FirstOrDefault((CalorieMultiplierEvent x) => time > x.Start && time <= x.End);
		}

		public static double CalculateAerobicCalories(double vo2, double kg, double seconds = 1.0)
		{
			return CalorieFormulas.OxygenConsumedToCalories(vo2, kg, seconds);
		}

		public static double CalculateOffEquipmentBeltMachineCalories(int currentTime, double newRawCalories, double previousRawCalories, double previousDecoratedCalories, List<CalorieMultiplierEvent> events, double kph)
		{
			CalorieMultiplierEvent calorieEventForTime = GetCalorieEventForTime(events, currentTime);
			double num = newRawCalories - previousRawCalories;
			if (calorieEventForTime != null && UnitUtil.EnsureMph(SpeedUnit.Kph, kph, 1).AlmostEqual(1.0, 1))
			{
				return previousDecoratedCalories + num * calorieEventForTime.Multiplier;
			}
			return previousDecoratedCalories + num;
		}
	}
	public class CalorieMultiplierEvent : IDeepCloneable<CalorieMultiplierEvent>, IDeepCloneable
	{
		public int Start { get; set; }

		public int End { get; set; }

		public double Multiplier { get; set; }

		public CalorieMultiplierEvent DeepClone()
		{
			return new CalorieMultiplierEvent
			{
				Start = Start,
				End = End,
				Multiplier = Multiplier
			};
		}

		object IDeepCloneable.DeepClone()
		{
			return DeepClone();
		}
	}
	public class CalorieMultiplierRecoveryInfo
	{
		public double PreviousRawCalories { get; set; }

		public double PreviousDecoratedCalories { get; set; }

		public double TotalCalorieDelta { get; set; }

		public int LastTime { get; set; }
	}
	public interface ICalorieMultiplierRecoverable
	{
		CalorieMultiplierRecoveryInfo GetRecoveryInfo();

		void Recover(CalorieMultiplierRecoveryInfo calorieMultiplierRecoveryInfo);
	}
}
namespace Sindarin.Core.Usb
{
	public interface IUsbDevice : IDisposable
	{
		IObservable<bool> WhenConnectionStateChanged { get; }

		bool IsConnected { get; }

		Task Connect();

		void Connect(bool headlessBike);

		void Disconnect();
	}
}
namespace Sindarin.Core.Tcp
{
	public class FitProTcpConnection : BaseConnection, IDeviceConnection, IDisposable
	{
		private const string Tag = "TcpConnection";

		private TcpClient tcpClient;

		private readonly IBleDevice device;

		private readonly string ipAddress;

		private readonly int port;

		private object lockObject = new object();

		private bool disposedValue;

		public TimeSpan Timeout => TimeSpan.FromMilliseconds(500.0);

		public FitProTcpConnection(IBleDevice device)
		{
			this.device = device;
			AdvertisementRecord advertisementRecord = device.AdvertisementRecords.First((AdvertisementRecord r) => r.Type == AdvertisementRecordType.DeviceAddress);
			if (advertisementRecord == null)
			{
				throw new ArgumentException("The device has no address record");
			}
			string text = Encoding.UTF8.GetString(advertisementRecord.Data, 0, advertisementRecord.Data.Length);
			string text2 = IsAddressValid(text);
			if (text2 != "")
			{
				throw new ArgumentException("Invalid device address. $" + text2);
			}
			if (text.Contains(":"))
			{
				string[] array = text.Split(':');
				ipAddress = array[0];
				port = int.Parse(array[1]);
			}
			else
			{
				ipAddress = text;
				port = 34567;
			}
			tcpClient = new TcpClient();
			Task.Run(async delegate
			{
				await DoConnection();
			});
		}

		public static string IsAddressValid(string addr)
		{
			if (addr.Contains(":"))
			{
				string[] array = addr.Split(':');
				if (array.Length != 2)
				{
					return "Must be address:port";
				}
				if (!ushort.TryParse(array[1], out var _))
				{
					return "Invalid port number";
				}
				if (!IPAddress.IsValid(array[0]))
				{
					return "Invalid IP address";
				}
			}
			else if (!IPAddress.IsValid(addr))
			{
				return "Invalid IP address";
			}
			return "";
		}

		private string FormatBytes(byte[] bytes)
		{
			string text = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				text += $"{bytes[i]:X2}";
				if (i < bytes.Length - 1)
				{
					text += "-";
				}
			}
			return text;
		}

		public Task SendBytes(byte[] bytes)
		{
			lock (lockObject)
			{
				Log.Trace("TcpConnection", "SendBytes: " + FormatBytes(bytes));
				byte[] array = new byte[bytes.Length + 3];
				array[0] = 190;
				array[1] = 206;
				array[2] = (byte)bytes.Length;
				Array.Copy(bytes, 0, array, 3, bytes.Length);
				Log.Trace("TcpConnection", "TCP Message: " + FormatBytes(array));
				try
				{
					tcpClient.GetStream().Write(array, 0, array.Length);
					tcpClient.GetStream().Flush();
				}
				catch (Exception ex)
				{
					Log.Trace("TcpConnection", "Failed to send bytes via TCP/IP: #" + ex.Message);
					device.Disconnect(forced: true);
					tcpClient.Client.Disconnect(reuseSocket: true);
				}
			}
			return Task.CompletedTask;
		}

		public async Task SendBytesWithReadDelay(byte[] bytes, TimeSpan delay)
		{
			await SendBytes(bytes);
		}

		public Task<bool> Disconnect()
		{
			tcpClient.Client.Disconnect(reuseSocket: true);
			return Task.FromResult(result: true);
		}

		public Task ReadBytesWithDelay(TimeSpan delay)
		{
			return Task.CompletedTask;
		}

		private async Task DoConnection()
		{
			bool connected = false;
			for (int attemptsRemaining = 10; attemptsRemaining > 0; attemptsRemaining--)
			{
				try
				{
					await tcpClient.ConnectAsync(ipAddress, port);
					connected = true;
				}
				catch (SocketException ex)
				{
					Log.Trace("TcpConnection", "TCP console connection failed: " + ex.Message);
					await Task.Delay(5000);
					continue;
				}
				break;
			}
			if (connected)
			{
				await Task.Delay(3000);
				base.Initialized = true;
				Task.Run((Action)DoReadLoop);
			}
		}

		private void DoReadLoop()
		{
			byte[] array = new byte[3];
			byte[] array2 = new byte[20];
			while (true)
			{
				try
				{
					tcpClient.GetStream().Read(array, 0, 3);
					_ = array[2];
					array2 = new byte[20];
					int num = tcpClient.GetStream().Read(array2, 0, array2.Length);
					if (num > 0)
					{
						byte[] array3 = new byte[num];
						Array.Copy(array2, array3, num);
						Log.Trace("TcpConnection", "Received bytes: " + FormatBytes(array3));
						whenValueUpdated.OnNext(array3);
					}
				}
				catch (IOException)
				{
					break;
				}
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					tcpClient?.Dispose();
					tcpClient = null;
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
	public class TcpPlatformDevice : IPlatformDevice
	{
		public string CommonIdentifier => "5A63C50B-1784-4BE2-977A-6F88475AD74B";

		public string Name => "Virtual Console";

		public object NativeDevice { get; }

		public string ShortIdentifier => CommonIdentifier;
	}
	public class TcpDevice : DeviceBase
	{
		public const string TcpDeviceId = "5A63C50B-1784-4BE2-977A-6F88475AD74B";

		private static TcpDevice _theDevice;

		public override bool IsMock => true;

		public static TcpDevice SharedDevice
		{
			get
			{
				if (_theDevice == null)
				{
					TcpPlatformDevice device = new TcpPlatformDevice();
					AdvertisementRecord item = new AdvertisementRecord(AdvertisementRecordType.ManufacturerSpecificData, new byte[0]);
					_theDevice = new TcpDevice(device, 100, new List<AdvertisementRecord> { item }, "VIRT");
				}
				return _theDevice;
			}
		}

		public TcpDevice(IPlatformDevice device, int rssi, List<AdvertisementRecord> advertisementRecords, string pairKey)
			: base(device, rssi, advertisementRecords, new HashSet<KnownService> { KnownServices.FitPro })
		{
			_pairKey = pairKey;
		}

		public override void Connected()
		{
		}

		protected override async Task<List<IService>> GetServicesNative()
		{
			await Task.Delay(1);
			return new List<IService>();
		}

		protected override void WriteNative(PendingWrite item)
		{
		}

		protected override Task<bool> WriteNativeAsync(ICharacteristic characteristic, byte[] bytes, bool withResponse = true)
		{
			return Task.FromResult(result: true);
		}

		public override object Clone()
		{
			return new TcpDevice(base.PlatformDevice, base.Rssi, base.AdvertisementRecords, base.PairKey);
		}
	}
}
namespace Sindarin.Core.Services
{
	public interface IFacadeRepository
	{
		IReadOnlyValueFacade GetFacade(FitnessValue value);

		IObservable<FitnessValueChange<double>> ObserveMetricChanges(FitnessValue value);
	}
	public class FacadeRepository : IFacadeRepository
	{
		private readonly SemaphoreSlim facadesLock = new SemaphoreSlim(1, 1);

		private readonly Dictionary<FitnessValue, IReadOnlyValueFacade> fitnessValueFacadeMapping = new Dictionary<FitnessValue, IReadOnlyValueFacade>();

		private readonly IReadWriteFacadeFactoryDependencies facadeFactoryDependencies;

		public FacadeRepository()
		{
			facadeFactoryDependencies = Mvx.Resolve<IReadWriteFacadeFactoryDependencies>();
		}

		public IReadOnlyValueFacade GetFacade(FitnessValue value)
		{
			try
			{
				facadesLock.Wait();
				if (!fitnessValueFacadeMapping.ContainsKey(value))
				{
					fitnessValueFacadeMapping[value] = CreateFacade(value);
				}
				return fitnessValueFacadeMapping[value];
			}
			finally
			{
				facadesLock.Release();
			}
		}

		public IObservable<FitnessValueChange<double>> ObserveMetricChanges(FitnessValue value)
		{
			IReadOnlyValueFacade facade = GetFacade(value);
			if (facade is IReadOnlyValueFacade<double> readOnlyValueFacade)
			{
				return readOnlyValueFacade.ObserveChanges();
			}
			if (facade is IReadOnlyValueFacade<int> readOnlyValueFacade2)
			{
				return from x in readOnlyValueFacade2.ObserveChanges()
					select new FitnessValueChange<double>(x.Type, x.Old, x.Current);
			}
			if (facade is IPulseFacade pulseFacade)
			{
				return from x in pulseFacade.ObservePulseChanges()
					select new FitnessValueChange<double>(x.Type, x.Old.UserPulse, x.Current.UserPulse);
			}
			if (facade is IGearFacade gearFacade)
			{
				return from x in gearFacade.ObserveGearChanges()
					select new FitnessValueChange<double>(x.Type, x.Old.CurrentGear, x.Current.CurrentGear);
			}
			throw new ArgumentException($"Unable to get double result from {facade.GetType()} with FitnessValue of {value}");
		}

		private IReadOnlyValueFacade CreateFacade(FitnessValue value)
		{
			return value switch
			{
				FitnessValue.Kph => facadeFactoryDependencies.KphFacade, 
				FitnessValue.AvgSpeedKph => facadeFactoryDependencies.AvgSpeedFacade, 
				FitnessValue.Grade => facadeFactoryDependencies.GradeFacade, 
				FitnessValue.Resistance => facadeFactoryDependencies.ResistanceFacade, 
				FitnessValue.Watts => facadeFactoryDependencies.WattsFacade, 
				FitnessValue.CurrentDistance => facadeFactoryDependencies.CurrentDistanceFacade, 
				FitnessValue.Rpm => facadeFactoryDependencies.RpmFacade, 
				FitnessValue.KeyObject => facadeFactoryDependencies.KeyObjectFacade, 
				FitnessValue.Volume => facadeFactoryDependencies.VolumeFacade, 
				FitnessValue.Pulse => facadeFactoryDependencies.PulseFacade, 
				FitnessValue.RunningTime => facadeFactoryDependencies.RunningTimeFacade, 
				FitnessValue.WorkoutMode => facadeFactoryDependencies.ConsoleStateFacade, 
				FitnessValue.LapTime => facadeFactoryDependencies.LapTimeFacade, 
				FitnessValue.ActualKph => facadeFactoryDependencies.ActualKphFacade, 
				FitnessValue.ActualIncline => facadeFactoryDependencies.ActualInclineFacade, 
				FitnessValue.CurrentTime => facadeFactoryDependencies.CurrentTimeFacade, 
				FitnessValue.CurrentCalories => facadeFactoryDependencies.CaloriesFacade, 
				FitnessValue.GoalTime => facadeFactoryDependencies.GoalTimeFacade, 
				FitnessValue.Weight => facadeFactoryDependencies.WeightFacade, 
				FitnessValue.Gear => facadeFactoryDependencies.GearFacade, 
				FitnessValue.MaxGrade => facadeFactoryDependencies.MaxGradeFacade, 
				FitnessValue.MinGrade => facadeFactoryDependencies.MinGradeFacade, 
				FitnessValue.MaxKph => facadeFactoryDependencies.MaxKphFacade, 
				FitnessValue.MinKph => facadeFactoryDependencies.MinKphFacade, 
				FitnessValue.IdleTimeout => facadeFactoryDependencies.IdleTimeoutFacade, 
				FitnessValue.PauseTimeout => facadeFactoryDependencies.PauseTimeoutFacade, 
				FitnessValue.SystemUnits => facadeFactoryDependencies.SystemUnitsFacade, 
				FitnessValue.MaxResistanceLevel => facadeFactoryDependencies.MaxResistanceLevelFacade, 
				FitnessValue.MaxWeight => facadeFactoryDependencies.MaxWeightFacade, 
				FitnessValue.WarmupTimeout => facadeFactoryDependencies.WarmupTimeoutFacade, 
				FitnessValue.CoolDownTimeout => facadeFactoryDependencies.CoolDownTimeoutFacade, 
				FitnessValue.MaxPulse => facadeFactoryDependencies.MaxPulseFacade, 
				FitnessValue.AverageWatts => facadeFactoryDependencies.AverageWattsFacade, 
				FitnessValue.WattGoal => facadeFactoryDependencies.WattGoalFacade, 
				FitnessValue.DistanceGoal => facadeFactoryDependencies.DistanceGoalFacade, 
				FitnessValue.MotorTotalDistance => facadeFactoryDependencies.MotorTotalDistanceFacade, 
				FitnessValue.TotalTime => facadeFactoryDependencies.TotalTimeFacade, 
				FitnessValue.VerticalMeterNet => facadeFactoryDependencies.VerticalMeterNetFacade, 
				FitnessValue.VerticalMeterGain => facadeFactoryDependencies.VerticalMeterGainFacade, 
				FitnessValue.IdleModeLockout => facadeFactoryDependencies.IdleModeLockoutFacade, 
				FitnessValue.SleepTimerState => facadeFactoryDependencies.SleepTimerStateFacade, 
				FitnessValue.StartRequested => facadeFactoryDependencies.StartRequestedFacade, 
				FitnessValue.FanState => facadeFactoryDependencies.FanStateFacade, 
				FitnessValue.ActivationLock => facadeFactoryDependencies.ActivationLockFacade, 
				FitnessValue.PausedTime => facadeFactoryDependencies.PausedTimeFacade, 
				FitnessValue.RequireStartRequested => facadeFactoryDependencies.RequireStartRequestedFacade, 
				FitnessValue.Strokes => facadeFactoryDependencies.StrokesFacade, 
				FitnessValue.StrokesPerMin => facadeFactoryDependencies.StrokesPerMinFacade, 
				FitnessValue.FiveHundredSplit => facadeFactoryDependencies.FiveHundredSplitFacade, 
				FitnessValue.FiveHundredSplitDecimal => facadeFactoryDependencies.FiveHundredSplitDecimalFacade, 
				FitnessValue.AvgFiveHundredSplit => facadeFactoryDependencies.AvgFiveHundredSplitFacade, 
				FitnessValue.IsClubUnit => facadeFactoryDependencies.IsClubUnitFacade, 
				FitnessValue.IsReadyToDisconnect => facadeFactoryDependencies.IsReadyToDisconnectFacade, 
				FitnessValue.IsConstantWattsMode => facadeFactoryDependencies.IsConstantWattsModeFacade, 
				_ => throw new ArgumentOutOfRangeException("value", value, $"No facade found for FitnessValue \"{value}\""), 
			};
		}
	}
	public interface IFitProCommTimeoutMonitoringService
	{
		int TimeoutCount { get; }

		void TimeoutOccurred();
	}
}
namespace Sindarin.Core.Services.Fatality
{
	public class FatalEvent
	{
		public string Message { get; set; }

		public Type ExceptionType { get; }

		public bool IsPermanent { get; }

		public FatalEvent(string message, Type exceptionType, bool isPermanent)
		{
			Message = message;
			ExceptionType = exceptionType;
			IsPermanent = isPermanent;
		}
	}
	public interface IFatalityService
	{
		IObservable<FatalRecovery> WhenFatalityRecovered { get; }

		IObservable<FatalEvent> WhenFatalityHappened { get; }

		bool InFatalState { get; }

		void ReportFatalEvent(Exception exception, string displayMessage = null, bool isPermanent = false, string caller = null, bool analytics = false);

		void RecoverIfNeeded(Type exceptionType, string message, string caller = null);
	}
	public class FatalityService : IFatalityService
	{
		private const string Tag = "FatalityService";

		private readonly Subject<FatalEvent> whenFatalityHappened = new Subject<FatalEvent>();

		private readonly Subject<FatalRecovery> whenFatalityRecovered = new Subject<FatalRecovery>();

		private readonly Dictionary<Type, FatalEvent> fatalEvents = new Dictionary<Type, FatalEvent>();

		private readonly ISindarinEventHandler eventHandler;

		public IObservable<FatalEvent> WhenFatalityHappened => whenFatalityHappened;

		public IObservable<FatalRecovery> WhenFatalityRecovered => whenFatalityRecovered;

		public bool InFatalState => fatalEvents.Count != 0;

		public FatalityService(ISindarinEventHandler eventHandler)
		{
			this.eventHandler = eventHandler;
		}

		public void ReportFatalEvent(Exception exception, string displayMessage = null, bool isPermanent = false, [CallerMemberName] string caller = null, bool sendToAnalytics = false)
		{
			Type type = exception.GetType();
			if (!fatalEvents.TryGetValue(type, out var value) || !value.IsPermanent)
			{
				FatalEvent value2 = new FatalEvent(displayMessage, type, isPermanent);
				fatalEvents[type] = value2;
				if (sendToAnalytics)
				{
					Log.Error("FatalityService", $"At {DateTime.Now} FatalityService.ReportFatalEvent from {caller}", exception);
					eventHandler.LogFatalEvent(exception);
				}
				else
				{
					Log.Fatal("FatalityService", $"At {DateTime.Now} FatalityService.ReportFatalEvent from {caller}", exception);
				}
				whenFatalityHappened.OnNext(value2);
			}
		}

		public void RecoverIfNeeded(Type exceptionTypeToRecover, string message, [CallerMemberName] string caller = null)
		{
			if (InFatalState && !fatalEvents.Any((KeyValuePair<Type, FatalEvent> x) => x.Value.IsPermanent) && fatalEvents.ContainsKey(exceptionTypeToRecover))
			{
				Log.Trace("FatalityService", $"At {DateTime.Now} FatalityService.RecoverFromFatalityEvent from {caller}, Message: {message}");
				fatalEvents.Remove(exceptionTypeToRecover);
				whenFatalityRecovered.OnNext(new FatalRecovery(exceptionTypeToRecover, message));
			}
		}
	}
	public class FatalRecovery
	{
		public string Message { get; }

		public Type ExceptionTypeToRecover { get; }

		public FatalRecovery(Type exceptionTypeToRecover, string message)
		{
			ExceptionTypeToRecover = exceptionTypeToRecover;
			Message = message;
		}
	}
}
namespace Sindarin.Core.Mock
{
	public abstract class MockAerobicFitnessConsoleBase : MockFitnessConsoleBase
	{
		private const int TargetRpmValue = 50;

		private int maxRpms;

		protected readonly Average AvgWatts = new Average();

		protected readonly Average AvgRpms = new Average();

		public int? Rpm { get; set; }

		protected MockAerobicFitnessConsoleBase(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override async Task WorkoutTick()
		{
			if (base.LatestBasicInfo.CurrentState == ConsoleState.Workout)
			{
				UpdateWatts(saveAvgs: true);
			}
			await base.WorkoutTick();
		}

		protected virtual int GetMockWatts()
		{
			double num = ((base.LatestBasicInfo.Gear != null && FitnessValueSupported(FitnessValue.Gear)) ? ((double)base.LatestBasicInfo.Gear.CurrentGear) : base.LatestBasicInfo.Resistance);
			return (int)Math.Round((double)base.LatestBasicInfo.Rpm * num);
		}

		private void UpdateWatts(bool saveAvgs)
		{
			int mockWatts = GetMockWatts();
			base.LatestBasicInfo.SetValue(FitnessValue.Watts, mockWatts);
			if (saveAvgs)
			{
				AvgWatts.AddSample(mockWatts);
				base.LatestBasicInfo.SetValue(FitnessValue.AverageWatts, (int)AvgWatts.CurrentAverage);
			}
		}

		protected override void UpdateInfo(bool saveAvgs)
		{
			if (!options.RandomSpeed)
			{
				base.LatestBasicInfo.SetValue(FitnessValue.Rpm, random.Next(49, 51));
			}
			if (base.LatestBasicInfo.Kph < 5E-324 || options.ShouldChangeSpeed)
			{
				SetKph(random.Next(2, 8));
			}
			if (this is MockRowerFitnessConsole)
			{
				double num = RowerEstimator.CalculateEstimatedDistance(base.LatestBasicInfo.Strokes, 1.75);
				double val = ((base.LatestBasicInfo.RunningTime > 0) ? (num / 1000.0 / ((double)base.LatestBasicInfo.RunningTime / 3600.0)) : 0.0);
				SetKph(Math.Min(val, base.LatestBasicInfo.MaxKph));
			}
			else
			{
				SetKphBasedOnGearAndResistance();
			}
			base.UpdateInfo(saveAvgs);
		}

		public override async Task<bool> SetValueAsync(FitnessValue type, object value)
		{
			bool result = await base.SetValueAsync(type, value);
			if (type == FitnessValue.Gear || type == FitnessValue.Resistance)
			{
				SetKphBasedOnGearAndResistance();
			}
			return result;
		}

		protected override void UpdateRpms(bool saveAvgs)
		{
		}

		protected override void ResetAverages()
		{
			AvgWatts.Reset();
			base.ResetAverages();
		}

		public override void SetTargetWatts(int target)
		{
			base.LatestBasicInfo.SetValue(FitnessValue.WattGoal, target);
		}

		public override void ToggleConstantWattsMode(bool enabled)
		{
			base.LatestBasicInfo.SetValue(FitnessValue.IsConstantWattsMode, enabled);
		}

		public override void SetKph(double kph)
		{
			SetValue(FitnessValue.Kph, kph);
			SetValue(FitnessValue.ActualKph, kph);
		}

		private void SetKphBasedOnGearAndResistance()
		{
			double num = 0.001 * (base.ConsoleInfo.CanSetGear ? ((double)base.LatestBasicInfo.Gear.CurrentGear) : base.LatestBasicInfo.Resistance.Clamp(1.0, base.ConsoleInfo.MaxResistanceLevel));
			int num2 = (int)Math.Round((double)base.LatestBasicInfo.Rpm * num * 60.0);
			SetKph(Math.Min(num2, base.LatestBasicInfo.MaxKph));
		}
	}
	public class MockBikeFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockBikeFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Rpm,
				FitnessValue.Grade
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.NordicTrack,
				MachineType = ConsoleType.Bike,
				ModelNumber = 123,
				PartNumber = 388955,
				IsSystemMarketTypeClub = false,
				Name = "Mock Bike",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetResistance = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-BIKE";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}

		protected override double DeltaCalories()
		{
			return CalorieFormulas.Bike(base.LatestBasicInfo.Weight, 1.0, base.LatestBasicInfo.Watts);
		}
	}
	public class MockConsoleInfo : IConsoleInfo
	{
		private readonly IFitnessConsole console;

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

		public bool SystemUnits => console.LatestBasicInfo.IsMetric;

		public double MaxKph => console.LatestBasicInfo.MaxKph;

		public double MinKph => console.LatestBasicInfo.MinKph;

		public double MaxIncline => console.LatestBasicInfo.MaxGrade;

		public double MinIncline => console.LatestBasicInfo.MinGrade;

		public int GearOption => console.LatestBasicInfo.Gear?.GearOption ?? 0;

		public int MinGear
		{
			get
			{
				if (!CanSetGear)
				{
					return 0;
				}
				return 1;
			}
		}

		public int MaxGear
		{
			get
			{
				if (!CanSetGear)
				{
					return 0;
				}
				return console.LatestBasicInfo.Gear.MaxGear;
			}
		}

		public double MinResistanceLevel => 1.0;

		public double MaxResistanceLevel => console.LatestBasicInfo.MaxResistanceLevel;

		public double MaxWeight
		{
			get
			{
				if (!(console.LatestBasicInfo.MaxWeight > 0.0))
				{
					return 136.078;
				}
				return console.LatestBasicInfo.MaxWeight;
			}
		}

		public bool CanSetKph { get; set; }

		public bool CanSetActivationLock { get; set; }

		public bool CanSetIncline { get; set; }

		public bool SupportsVerticalGain { get; set; }

		public bool SupportsVerticalNet { get; set; }

		public bool SupportsStartRequested { get; set; }

		public bool SupportsRequireStartRequested { get; set; }

		public bool SupportsKeyPressObserved { get; set; }

		public bool SupportsPulse { get; set; }

		public bool CanSetResistance { get; set; }

		public bool CanSetGear { get; set; }

		public double TotalTime => console.LatestBasicInfo.TotalTime;

		public int WarmUpTimeoutSeconds => console.LatestBasicInfo.WarmUpTimeoutSeconds;

		public int CoolDownTimeoutSeconds => console.LatestBasicInfo.CoolDownTimeoutSeconds;

		public int PauseTimeoutSeconds => console.LatestBasicInfo.PauseTimeoutSeconds;

		public int IdleTimeoutSeconds => console.LatestBasicInfo.IdleTimeoutSeconds;

		public double TotalMeters => console.LatestBasicInfo.MotorTotalDistance;

		public bool IsClubUnit => console.LatestBasicInfo.IsClubUnit;

		public bool IsClub
		{
			get
			{
				if (!IsClubUnit)
				{
					return IsSystemMarketTypeClub;
				}
				return true;
			}
		}

		public bool SupportsConstantWatts { get; set; }

		public double Weight => console.LatestBasicInfo.Weight;

		public MockConsoleInfo(IFitnessConsole console)
		{
			this.console = console;
		}
	}
	public class MockEllipticalFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockEllipticalFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.FreeMotion,
				MachineType = ConsoleType.Elliptical,
				ModelNumber = 123,
				PartNumber = 375138,
				IsSystemMarketTypeClub = false,
				Name = "Mock Elliptical",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetResistance = true,
				CanSetIncline = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-ELLIPTICAL";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, false),
				(FitnessValue.MaxGrade, 10),
				(FitnessValue.MinGrade, 0),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}

		protected override double DeltaCalories()
		{
			return CalorieFormulas.Elliptical(base.LatestBasicInfo.Weight, 1.0, base.LatestBasicInfo.Watts);
		}
	}
	public abstract class MockFitnessConsoleBase : IFitnessConsole, ICalibrateIncline, IDisposable, IForceClubUnit
	{
		private readonly SemaphoreSlim setValueLock = new SemaphoreSlim(1, 1);

		protected readonly MockFitnessConsoleOptions options;

		private const string LogTag = "MockFitPro";

		protected const int MetersPerLap = 400;

		private const double ResultsIdleIncline = 0.0;

		protected readonly Random random = new Random();

		private IDisposable connectionInitializedSub;

		private IDisposable resultsToIdleSub;

		private IDisposable unlockedToIdleSub;

		private IDisposable activationUnlockIfNeededSub;

		private IDisposable commLossSub;

		private IDisposable calibrationSub;

		private IDisposable idleStartRequestedSub;

		private IDisposable workoutEndingSub;

		private ConsoleState? lastStateBeforeDmk;

		private IDisposable dmkToggleSub;

		protected ConsoleState? lastStateBeforePause;

		protected readonly Average AvgGrade = new Average();

		protected readonly Average AvgPulse = new Average();

		protected readonly Average AvgLapTime = new Average();

		protected double totalDistance;

		protected readonly Subject<CalibrateInclineState> whenCalibrationStatusChanged = new Subject<CalibrateInclineState>();

		protected readonly ReplaySubject<bool> _whenCalibrationStarted = new ReplaySubject<bool>(1);

		protected readonly ReplaySubject<IConsoleInfo> whenConsoleInitialized = new ReplaySubject<IConsoleInfo>(1);

		protected readonly Subject<bool> _detectOnBytesBeingSent = new Subject<bool>();

		private readonly Subject<FitnessValue> _whenControlValueChangedOnConsole = new Subject<FitnessValue>();

		private readonly Subject<StateChange> consoleStateChanged = new Subject<StateChange>();

		private bool _pauseOverrideEnabled;

		protected readonly Subject<object> whenWorkoutEnding = new Subject<object>();

		private bool pausedFromApp;

		public static readonly List<ConsoleState> WorkoutStates = new List<ConsoleState>
		{
			ConsoleState.WarmUp,
			ConsoleState.Workout,
			ConsoleState.CoolDown,
			ConsoleState.Paused,
			ConsoleState.PauseOverride
		};

		private IDisposable secondTick;

		private IDisposable stateChangeSub;

		private int remainingPauseTimeoutSeconds;

		private bool hasWorkoutInitialized;

		private bool hasWarmupInitialized;

		protected readonly IReadWriteFacadeFactoryDependencies facadeFactoryDependencies;

		protected readonly IWorkoutFacade workoutFacade;

		private SemaphoreSlim stateLock = new SemaphoreSlim(1, 1);

		private IFitnessValueChangeManager FitnessValueChangeManager { get; } = new FitnessValueChangeManager();

		public IObservable<int> WhenPausedTimeRemainingChanged => FitnessValueChangeManager.WhenPauseRemainingChanged;

		public IDeviceConnection Connection { get; } = new MockConnection();

		public IObservable<CalibrateInclineState> WhenCalibrationStatusChanged => whenCalibrationStatusChanged;

		public IObservable<bool> WhenCalibrationStarted => _whenCalibrationStarted.AsObservable();

		public TimeSpan DefaultTimeout { get; }

		public List<FitnessValue> ReadableTypes { get; protected set; }

		public List<FitnessValue> WritableTypes { get; protected set; }

		public IConsoleInfo ConsoleInfo { get; protected set; }

		public IConsoleBasicInfo LatestBasicInfo { get; protected set; }

		public IFacadeRepository FacadeRepository { get; }

		public IObservable<IConsoleInfo> WhenConsoleInitialized => whenConsoleInitialized.AsObservable();

		public IObservable<bool> WhenDataTimerChanged { get; } = new Subject<bool>();

		public IObservable<bool> DetectOnBytesBeingSent => _detectOnBytesBeingSent.AsObservable();

		public IObservable<FitnessValue> WhenControlValueChangedOnConsole => _whenControlValueChangedOnConsole.AsObservable();

		public IObservable<StateChange> WhenStateChanged => consoleStateChanged;

		public IChangeManager ChangeManager => FitnessValueChangeManager;

		public bool StartKeyEnabled { get; set; }

		public bool PauseOverrideEnabled
		{
			get
			{
				return _pauseOverrideEnabled;
			}
			set
			{
				_pauseOverrideEnabled = value && SupportsPauseOverride;
				FitnessValueChangeManager.PauseOverrideEnabled = _pauseOverrideEnabled;
				LatestBasicInfo.PauseOverrideEnabled = _pauseOverrideEnabled;
			}
		}

		public IObservable<object> WhenWorkoutEnding => whenWorkoutEnding;

		public int PauseTimeoutSecondsRemaining => FitnessValueChangeManager.PauseTimeoutRemaining;

		public bool SupportsPauseOverride { get; }

		public bool Initialized { get; protected set; }

		public int PauseOverrideTime => FitnessValueChangeManager.PauseOverrideTime;

		public ConnectionType ConnectionType { get; }

		public bool IsTogglingDmk
		{
			get
			{
				return dmkToggleSub != null;
			}
			set
			{
				if (value == IsTogglingDmk)
				{
					return;
				}
				if (value)
				{
					dmkToggleSub = Observable.Interval(TimeSpan.FromSeconds(20.0)).Subscribe(delegate
					{
						ToggleDMK();
					});
					Log.Trace("MockFitPro", $"Starting mock DMK timer, will toggle key in {20} seconds...");
					return;
				}
				dmkToggleSub.Dispose();
				dmkToggleSub = null;
				if (LatestBasicInfo.CurrentState == ConsoleState.SafetyKeyRemoved)
				{
					ToggleDMK();
				}
				Log.Trace("MockFitPro", "Disabled mock DMK timer.");
			}
		}

		protected MockFitnessConsoleBase(MockFitnessConsoleOptions options)
		{
			this.options = options;
			facadeFactoryDependencies = Mvx.Resolve<IReadWriteFacadeFactoryDependencies>();
			workoutFacade = Mvx.Resolve<IWorkoutFacade>();
			stateChangeSub = (from x in ObserveValue(FitnessValue.WorkoutMode)
				select new StateChange((ConsoleState)x.Old, (ConsoleState)x.Current)).Subscribe(StateChangeFilter);
			FacadeRepository = new FacadeRepository();
			resultsToIdleSub = WhenStateChanged.Where((StateChange x) => x.Current == ConsoleState.WorkoutResults).Delay(TimeSpan.FromMilliseconds(200.0)).SubscribeWithErrorLogging(delegate
			{
				CleanUpWorkout();
			});
			unlockedToIdleSub = WhenStateChanged.Where((StateChange x) => x.Current == ConsoleState.Locked).SubscribeWithErrorLogging(delegate
			{
				Unlock();
			});
			workoutEndingSub?.Dispose();
			workoutEndingSub = (from x in WhenStateChanged.CombineLatest(facadeFactoryDependencies.CurrentTimeFacade.ObserveCurrentTimeChanges(), (StateChange state, FitnessValueChange<int> metric) => new Tuple<StateChange, FitnessValueChange<int>>(state, metric))
				where x.Item1.Current == ConsoleState.CoolDown && x.Item2.Current < 3 && x.Item2.Current > 0
				select x).SubscribeWithErrorLogging(delegate
			{
				whenWorkoutEnding.OnNext(null);
			});
			Initialize();
		}

		protected abstract IConsoleInfo GetDefaultDeviceInfo();

		protected abstract string GetDefaultSerialNumber();

		protected abstract List<(FitnessValue, object)> GetDefaultFitnessValues();

		public void StartCalibrateIncline()
		{
			Task.Run(async delegate
			{
				await Task.Delay(2000);
				whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Done);
			});
		}

		protected void Initialize()
		{
			Reset();
			Observable.Interval(TimeSpan.FromMilliseconds(1.0)).Take(1).Subscribe(delegate
			{
				Initialized = true;
				whenConsoleInitialized.OnNext(ConsoleInfo);
			});
		}

		protected void Reset()
		{
			totalDistance = 0.0;
			LatestBasicInfo?.Dispose();
			LatestBasicInfo = new ConsoleBasicInfo();
			ConsoleInfo = GetDefaultDeviceInfo();
			secondTick?.Dispose();
			secondTick = null;
			ResetAverages();
			hasWarmupInitialized = false;
			hasWorkoutInitialized = false;
			foreach (var defaultFitnessValue in GetDefaultFitnessValues())
			{
				LatestBasicInfo.SetValue(defaultFitnessValue.Item1, defaultFitnessValue.Item2);
			}
			FitnessValueChangeManager.BasicInfo = LatestBasicInfo;
		}

		private void StopTick()
		{
			secondTick?.Dispose();
			secondTick = null;
		}

		private void StartTick()
		{
			if (secondTick == null)
			{
				secondTick = Observable.Interval(options.TickTimeSpan).SubscribeAsync((long x) => WorkoutTick());
			}
		}

		protected virtual async Task WorkoutTick()
		{
			options.RecordTick();
			if (LatestBasicInfo.CurrentState == ConsoleState.Paused)
			{
				remainingPauseTimeoutSeconds--;
				if (remainingPauseTimeoutSeconds <= 0)
				{
					Log.Trace("MockFitPro", "Pause timeout reached. Stopping workout.");
					await workoutFacade.EndWorkoutAsync();
				}
				return;
			}
			switch (LatestBasicInfo.CurrentState)
			{
			case ConsoleState.Workout:
				UpdateRunningValues();
				UpdateInfo(saveAvgs: true);
				break;
			case ConsoleState.WarmUp:
				UpdatePrePostValues();
				UpdateInfo(saveAvgs: false);
				break;
			case ConsoleState.CoolDown:
				UpdatePrePostValues();
				UpdateInfo(saveAvgs: false);
				break;
			case ConsoleState.SafetyKeyRemoved:
			case ConsoleState.Demo:
				if (Math.Abs(LatestBasicInfo.Kph) > 0.001)
				{
					facadeFactoryDependencies.KphFacade.SetKph(0.0);
				}
				break;
			}
			await CheckForStateChange();
			if (!hasWorkoutInitialized && LatestBasicInfo.CurrentState.IsRunningState())
			{
				Task.Run(() => hasWorkoutInitialized = true);
			}
		}

		protected virtual void ResetAverages()
		{
			AvgPulse.Reset();
			AvgGrade.Reset();
			AvgLapTime.Reset();
		}

		public abstract void SetTargetWatts(int target);

		public abstract void ToggleConstantWattsMode(bool enabled);

		protected async Task CheckForStateChange()
		{
			await stateLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (LatestBasicInfo.CurrentState == ConsoleState.WarmUp && LatestBasicInfo.TimeSeconds <= 0 && hasWarmupInitialized)
			{
				await workoutFacade.StartWorkoutAsync(LatestBasicInfo.Kph, LatestBasicInfo.Grade, LatestBasicInfo.Resistance, (LatestBasicInfo.Gear?.CurrentGear).GetValueOrDefault());
			}
			if (LatestBasicInfo.CurrentState == ConsoleState.CoolDown && LatestBasicInfo.TimeSeconds <= 0)
			{
				await workoutFacade.EndWorkoutAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			if (LatestBasicInfo.CurrentState == ConsoleState.Workout && LatestBasicInfo.GoalTime > 0 && LatestBasicInfo.TimeSeconds >= LatestBasicInfo.GoalTime && hasWorkoutInitialized)
			{
				await workoutFacade.StartCoolDownAsync(LatestBasicInfo.Kph, LatestBasicInfo.Grade, LatestBasicInfo.Resistance, (LatestBasicInfo.Gear?.CurrentGear).GetValueOrDefault());
			}
			if (LatestBasicInfo.CurrentState == ConsoleState.Workout && LatestBasicInfo.DistanceGoal > 0.0 && LatestBasicInfo.DistanceMeters >= LatestBasicInfo.DistanceGoal && hasWorkoutInitialized)
			{
				await workoutFacade.StartCoolDownAsync(LatestBasicInfo.Kph, LatestBasicInfo.Grade, LatestBasicInfo.Resistance, (LatestBasicInfo.Gear?.CurrentGear).GetValueOrDefault());
			}
			stateLock.Release();
		}

		protected virtual void UpdatePrePostValues()
		{
			if (LatestBasicInfo.TimeSeconds > 0 && LatestBasicInfo.CurrentState == ConsoleState.WarmUp && !hasWarmupInitialized)
			{
				hasWarmupInitialized = true;
			}
			LatestBasicInfo.SetValue(FitnessValue.CurrentTime, LatestBasicInfo.CurrentTime - 1);
			if (options.RandomPulse)
			{
				facadeFactoryDependencies.PulseFacade.SetPulse(new Pulse(random.Next(80, 150), 0, 0, Pulse.Source.Ble));
			}
		}

		protected virtual void UpdateInfo(bool saveAvgs)
		{
			UpdatePulse(saveAvgs);
			UpdateGrade(saveAvgs);
			UpdateDistance(saveAvgs);
			UpdateRpms(saveAvgs);
			UpdateLap(saveAvgs);
		}

		protected virtual void UpdatePulse(bool saveAvgs)
		{
			IConsoleBasicInfo latestBasicInfo = LatestBasicInfo;
			if (latestBasicInfo == null)
			{
				return;
			}
			Pulse currentPulse = latestBasicInfo.CurrentPulse;
			if (currentPulse == null)
			{
				return;
			}
			_ = currentPulse.UserPulse;
			if (true)
			{
				int userPulse = LatestBasicInfo.CurrentPulse.UserPulse;
				if (saveAvgs)
				{
					AvgPulse.AddSample(userPulse);
				}
				LatestBasicInfo.SetValue(FitnessValue.MaxPulse, Math.Max(userPulse, LatestBasicInfo.MaxPulse));
			}
		}

		protected virtual void UpdateGrade(bool saveAvgs)
		{
			if (saveAvgs)
			{
				AvgGrade.AddSample(LatestBasicInfo.Grade);
			}
			LatestBasicInfo.SetValue(FitnessValue.AverageGrade, AvgGrade.CurrentAverage);
			double num = UnitUtil.EnsureMps(SpeedUnit.Kph, LatestBasicInfo.Kph) * (LatestBasicInfo.Grade / 100.0);
			if (ConsoleInfo.SupportsVerticalNet && ConsoleInfo.MachineType != ConsoleType.Elliptical)
			{
				LatestBasicInfo.SetValue(FitnessValue.VerticalMeterNet, LatestBasicInfo.VerticalMetersNet + num);
			}
			if (num > 0.0 && ConsoleInfo.SupportsVerticalGain && ConsoleInfo.MachineType != ConsoleType.Elliptical)
			{
				LatestBasicInfo.SetValue(FitnessValue.VerticalMeterGain, LatestBasicInfo.VerticalMetersGain + num);
			}
		}

		protected virtual void UpdateDistance(bool saveAvgs)
		{
			double num = UnitUtil.EnsureMps(SpeedUnit.Kph, LatestBasicInfo.Kph);
			totalDistance += num;
			SetDistanceMeters(totalDistance);
		}

		protected void SetDistanceMeters(double m)
		{
			LatestBasicInfo.SetValue(FitnessValue.CurrentDistance, m);
		}

		protected virtual void UpdateRpms(bool saveAvgs)
		{
			double num = UnitUtil.EnsureMps(SpeedUnit.Kph, LatestBasicInfo.Kph);
			LatestBasicInfo.SetValue(FitnessValue.Rpm, (int)(num * 10.0));
		}

		protected virtual void UpdateLap(bool saveAvgs)
		{
			double num = (double)LatestBasicInfo.TimeSeconds - AvgLapTime.CurrentAverage * (double)AvgLapTime.NumberOfSamplings;
			LatestBasicInfo.SetValue(FitnessValue.LapTime, (int)num);
			if (saveAvgs && LatestBasicInfo.DistanceMeters > 400.0 && (double)AvgLapTime.NumberOfSamplings < Math.Floor(LatestBasicInfo.DistanceMeters / 400.0))
			{
				AvgLapTime.AddSample(num);
			}
		}

		protected virtual double DeltaCalories()
		{
			return 0.1;
		}

		protected virtual void UpdateRunningValues()
		{
			LatestBasicInfo.SetValue(FitnessValue.CurrentTime, LatestBasicInfo.CurrentTime + 1);
			LatestBasicInfo.SetValue(FitnessValue.RunningTime, LatestBasicInfo.RunningTime + 1);
			LatestBasicInfo.SetValue(FitnessValue.LapTime, LatestBasicInfo.LapTimeSeconds + 1);
			LatestBasicInfo.SetValue(FitnessValue.CurrentCalories, LatestBasicInfo.Calories + DeltaCalories());
			if (ConsoleInfo.CanSetIncline && options.ShouldChangeIncline)
			{
				int minValue = (int)Math.Max(ConsoleInfo.MinIncline, LatestBasicInfo.Grade - 3.0);
				int maxValue = (int)Math.Min(ConsoleInfo.MaxIncline, LatestBasicInfo.Grade + 3.0);
				facadeFactoryDependencies.GradeFacade.SetGrade(random.Next(minValue, maxValue));
			}
			if (ConsoleInfo.CanSetGear && options.ShouldChangeGear)
			{
				facadeFactoryDependencies.GearFacade.SetGear(new Gear(random.Next(ConsoleInfo.MinGear, ConsoleInfo.MaxGear)));
			}
			if (ConsoleInfo.CanSetKph && options.ShouldChangeSpeed)
			{
				int minValue2 = (int)Math.Max(1.0, LatestBasicInfo.Kph - 3.0);
				int maxValue2 = (int)Math.Min(ConsoleInfo.MaxKph, LatestBasicInfo.Kph + 3.0);
				facadeFactoryDependencies.KphFacade.SetKph(random.Next(minValue2, maxValue2));
			}
			if (ConsoleInfo.CanSetResistance && options.ShouldChangeResistance)
			{
				int minValue3 = (int)Math.Max(1.0, LatestBasicInfo.Resistance - 3.0);
				int maxValue3 = (int)Math.Min(ConsoleInfo.MaxResistanceLevel, LatestBasicInfo.Resistance + 3.0);
				facadeFactoryDependencies.ResistanceFacade.SetResistance(random.Next(minValue3, maxValue3));
			}
			if (options.RandomPulse)
			{
				facadeFactoryDependencies.PulseFacade.SetPulse(new Pulse(random.Next(80, 150), 0, 0, Pulse.Source.Ble));
			}
		}

		private void Unlock()
		{
		}

		private void StateChangeFilter(StateChange change)
		{
			if (change.Current != change.Old)
			{
				CheckLockedState(change);
				IConsoleInfo consoleInfo = ConsoleInfo;
				if (consoleInfo != null && consoleInfo.MachineType.IsAerobicMachine() && WorkoutStates.Contains(change.Old) && !WorkoutStates.Contains(change.Current))
				{
					SetIdleModeLockout(locked: true);
				}
				if (change.Current == ConsoleState.WarmUp)
				{
					SetDistanceMeters(0.0);
					LatestBasicInfo.SetValue(FitnessValue.CurrentTime, ConsoleInfo.WarmUpTimeoutSeconds);
				}
				else if (change.Current == ConsoleState.Workout)
				{
					StopTick();
					SetDistanceMeters(0.0);
					LatestBasicInfo.SetValue(FitnessValue.CurrentTime, 0);
				}
				else if (change.Current == ConsoleState.CoolDown)
				{
					StopTick();
					SetDistanceMeters(0.0);
					LatestBasicInfo.SetValue(FitnessValue.CurrentTime, ConsoleInfo.CoolDownTimeoutSeconds);
				}
				if (change.Current == ConsoleState.Workout || change.Current == ConsoleState.WarmUp || change.Current == ConsoleState.CoolDown)
				{
					StartTick();
				}
				if (change.Current == ConsoleState.Resume)
				{
					StopPauseTimer();
					facadeFactoryDependencies.ConsoleStateFacade.SetConsoleState(ConsoleState.Workout);
				}
				if (change.Current == ConsoleState.Paused)
				{
					StartPauseTimer();
					ConsoleState current = ((SupportsPauseOverride && PauseOverrideEnabled && !pausedFromApp) ? ConsoleState.PauseOverride : ConsoleState.Paused);
					consoleStateChanged.OnNext(new StateChange(change.Old, current));
					pausedFromApp = false;
				}
				else
				{
					StopPauseTimer();
					consoleStateChanged.OnNext(change);
				}
			}
		}

		public void SetIdleModeLockout(bool locked)
		{
			SetValue(FitnessValue.IdleModeLockout, locked);
		}

		private void CheckLockedState(StateChange change)
		{
			if (change.Current == ConsoleState.Locked || change.Old == ConsoleState.Locked)
			{
				_whenCalibrationStarted.OnNext(change.Current == ConsoleState.Locked);
			}
		}

		public void StartPauseTimer()
		{
			bool emulatePausedTime = SupportsPauseOverride && PauseOverrideEnabled;
			FitnessValueChangeManager.StartPauseOverrideProcessing(emulatePausedTime);
		}

		public void StopPauseTimer()
		{
			FitnessValueChangeManager.StopPauseOverrideProcessing();
		}

		private void CleanUpWorkout()
		{
			IConsoleBasicInfo latestBasicInfo = LatestBasicInfo;
			if (latestBasicInfo == null || latestBasicInfo.CurrentState != ConsoleState.Idle)
			{
				Log.Trace("MockFitPro", "CleanUpWorkout");
				(FitnessValue, object)[] values = new(FitnessValue, object)[2]
				{
					(FitnessValue.WorkoutMode, ConsoleState.Idle),
					(FitnessValue.Grade, 0.0)
				};
				SetValues(values);
				FitnessValueChangeManager.Reinitialize();
				Reset();
			}
		}

		public void SetValues(params (FitnessValue, object)[] values)
		{
			Task.Run(async () => await SetValuesAsync(values));
		}

		public async Task<bool> SetValuesAsync(params (FitnessValue, object)[] values)
		{
			List<Task<bool>> tasks = values.Select(((FitnessValue, object) x) => SetValueAsync(x.Item1, x.Item2)).ToList();
			await Task.WhenAll(tasks);
			return tasks.All((Task<bool> x) => x.Result);
		}

		public void SetValue(FitnessValue type, object value)
		{
			Task.Run(async () => await SetValueAsync(type, value));
		}

		public object GetMostRecentValue(FitnessValue type)
		{
			return LatestBasicInfo.GetValue(type);
		}

		public virtual async Task<bool> SetValueAsync(FitnessValue type, object value)
		{
			try
			{
				await setValueLock.WaitAsync();
				if (type == FitnessValue.WorkoutMode && value is ConsoleState consoleState)
				{
					switch (consoleState)
					{
					case ConsoleState.Paused:
						lastStateBeforePause = LatestBasicInfo.CurrentState;
						remainingPauseTimeoutSeconds = LatestBasicInfo.PauseTimeoutSeconds;
						break;
					case ConsoleState.Resume:
					{
						ConsoleState consoleState2 = lastStateBeforePause ?? ConsoleState.Workout;
						value = consoleState2;
						lastStateBeforePause = null;
						break;
					}
					}
				}
				return LatestBasicInfo.SetValue(type, value);
			}
			finally
			{
				setValueLock.Release();
			}
		}

		public Task<object> GetValueAsync(FitnessValue type)
		{
			return Task.FromResult(LatestBasicInfo.GetValue(type));
		}

		public IObservable<AnyFitnessValueChange> ObserveValue(FitnessValue type)
		{
			return FitnessValueChangeManager.WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => x.Type == type);
		}

		public IObservable<AnyFitnessValueChange> ObserveValues(List<FitnessValue> types)
		{
			return FitnessValueChangeManager.WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => types.Contains(x.Type) && x.Old != x.Current);
		}

		public bool FitnessValueSupported(FitnessValue value)
		{
			if (!ReadableTypes.Contains(value))
			{
				return WritableTypes.Contains(value);
			}
			return true;
		}

		public void ReinitializeFitnessValues(int extraTime, int pausedTime)
		{
			ChangeManager.Reinitialize(extraTime, pausedTime);
		}

		public Task SetSubscribed(bool subscribed, FitnessValue fitnessValue)
		{
			return Task.CompletedTask;
		}

		public Task InitializeConsole()
		{
			return Task.FromResult(0);
		}

		public virtual void SetKph(double kph)
		{
			facadeFactoryDependencies.KphFacade.SetKph(kph);
		}

		public void SimulateDetectOnBytesBeingSent()
		{
			_detectOnBytesBeingSent.OnNext(value: true);
		}

		public void Dispose()
		{
			secondTick?.Dispose();
			secondTick = null;
			stateChangeSub?.Dispose();
			stateChangeSub = null;
			connectionInitializedSub?.Dispose();
			connectionInitializedSub = null;
			resultsToIdleSub?.Dispose();
			resultsToIdleSub = null;
			unlockedToIdleSub?.Dispose();
			unlockedToIdleSub = null;
			activationUnlockIfNeededSub?.Dispose();
			activationUnlockIfNeededSub = null;
			commLossSub?.Dispose();
			commLossSub = null;
			calibrationSub?.Dispose();
			calibrationSub = null;
			idleStartRequestedSub?.Dispose();
			idleStartRequestedSub = null;
			workoutEndingSub?.Dispose();
			workoutEndingSub = null;
			secondTick?.Dispose();
			secondTick = null;
		}

		public void CalibrateIncline()
		{
		}

		public Task<IConsoleError> GetConsoleErrorAsync()
		{
			return Task.FromResult<IConsoleError>(null);
		}

		public void ToggleClubStatus()
		{
			bool isClub = ConsoleInfo.IsClub;
			LatestBasicInfo.SetValue(FitnessValue.IsClubUnit, !isClub);
		}

		private void SetDmk()
		{
			(FitnessValue, object)[] values = new(FitnessValue, object)[1] { (FitnessValue.WorkoutMode, ConsoleState.SafetyKeyRemoved) };
			SetValues(values);
		}

		public void ToggleDMK()
		{
			if (LatestBasicInfo.CurrentState != ConsoleState.SafetyKeyRemoved)
			{
				Log.Trace("MockFitPro", $"toggling DMK state from {LatestBasicInfo.CurrentState} to {ConsoleState.SafetyKeyRemoved} ");
				lastStateBeforeDmk = LatestBasicInfo.CurrentState;
				SetDmk();
				return;
			}
			ConsoleState consoleState = lastStateBeforeDmk ?? ConsoleState.Idle;
			Log.Trace("MockFitPro", $"toggling DMK state from {LatestBasicInfo.CurrentState} to {consoleState} ");
			(FitnessValue, object)[] values = new(FitnessValue, object)[1] { (FitnessValue.WorkoutMode, consoleState) };
			SetValues(values);
			lastStateBeforeDmk = null;
		}
	}
	public static class MockFitnessConsoleFactory
	{
		public static IFitnessConsole GetMockConsole(MockType type, MockFitnessConsoleOptions options)
		{
			return type switch
			{
				MockType.Treadmill => new MockTreadmillFitnessConsole(options), 
				MockType.Bike => new MockBikeFitnessConsole(options), 
				MockType.Elliptical => new MockEllipticalFitnessConsole(options), 
				MockType.VerticalElliptical => new MockHiitFitnessConsole(options), 
				MockType.FreeStrider => new MockFreeStriderFitnessConsole(options), 
				MockType.SpinBike => new MockSpinBikeFitnessConsole(options), 
				MockType.InclineBike => new MockInclineBikeFitnessConsole(options), 
				MockType.Rower => new MockRowerFitnessConsole(options), 
				MockType.Hybrid => new MockHybridFitnessConsole(options), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
	public class MockFitnessConsoleOptions
	{
		private int ticks;

		public TimeSpan TickTimeSpan { get; set; } = TimeSpan.FromSeconds(1.0);

		public TimeSpan BufferDelay { get; set; } = TimeSpan.FromMilliseconds(10.0);

		public int TicksBetweenRandomization { get; set; } = 30;

		public bool RandomSpeed { get; set; }

		public bool RandomIncline { get; set; }

		public bool RandomResistence { get; set; }

		public bool RandomGear { get; set; }

		public bool RandomPulse { get; set; }

		public bool AllRandomValues
		{
			get
			{
				if (RandomSpeed && RandomIncline && RandomResistence)
				{
					return RandomPulse;
				}
				return false;
			}
			set
			{
				RandomSpeed = value;
				RandomIncline = value;
				RandomResistence = value;
				RandomPulse = value;
				RandomGear = value;
			}
		}

		public bool ShouldChangeSpeed
		{
			get
			{
				if (RandomSpeed)
				{
					return ticks == 0;
				}
				return false;
			}
		}

		public bool ShouldChangeIncline
		{
			get
			{
				if (RandomIncline)
				{
					return ticks == 0;
				}
				return false;
			}
		}

		public bool ShouldChangeResistance
		{
			get
			{
				if (RandomResistence)
				{
					return ticks == 0;
				}
				return false;
			}
		}

		public bool ShouldChangeGear
		{
			get
			{
				if (RandomGear)
				{
					return ticks == 0;
				}
				return false;
			}
		}

		public void RecordTick()
		{
			ticks = (ticks + 1) % TicksBetweenRandomization;
		}
	}
	public class MockFreeStriderFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockFreeStriderFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.NordicTrack,
				MachineType = ConsoleType.FreeStrider,
				ModelNumber = 123,
				PartNumber = 374145,
				IsSystemMarketTypeClub = false,
				Name = "Mock FreeStrider",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetResistance = true,
				CanSetIncline = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-FREESTRIDER";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 30),
				(FitnessValue.MinGrade, -6),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}
	}
	public class MockHiitFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockHiitFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.ProForm,
				MachineType = ConsoleType.VerticalElliptical,
				ModelNumber = 123,
				PartNumber = 396917,
				IsSystemMarketTypeClub = false,
				Name = "Mock VerticalElliptical",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetIncline = true,
				CanSetResistance = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-VERTICALELLIPTICAL";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 5),
				(FitnessValue.MinGrade, 5),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}
	}
	public class MockHybridFitnessConsole : MockFitnessConsoleBase
	{
		public MockHybridFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Kph,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Grade,
				FitnessValue.Kph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.ProForm,
				MachineType = ConsoleType.Bike,
				ModelNumber = 123,
				PartNumber = 391991,
				IsSystemMarketTypeClub = false,
				Name = "Mock Hybrid Trainer",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetIncline = true,
				CanSetKph = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-HYBRIDTRAINER";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 12),
				(FitnessValue.MinGrade, -3),
				(FitnessValue.MaxKph, 20),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600),
				(FitnessValue.SleepTimerState, false)
			};
		}

		public override void SetTargetWatts(int target)
		{
		}

		public override void ToggleConstantWattsMode(bool enabled)
		{
		}
	}
	public class MockInclineBikeFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockInclineBikeFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm,
				FitnessValue.Gear
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Grade,
				FitnessValue.Gear,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.NordicTrack,
				MachineType = ConsoleType.SpinBike,
				ModelNumber = 123,
				PartNumber = 392570,
				IsSystemMarketTypeClub = false,
				Name = "Mock Incline Bike",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetGear = true,
				CanSetIncline = true,
				CanSetResistance = true,
				SupportsVerticalGain = true,
				SupportsVerticalNet = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-INCLINEBIKE";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 20),
				(FitnessValue.MinGrade, -20),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.Gear, new Gear(1, 1, 24)),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}

		public override Task<bool> SetValueAsync(FitnessValue type, object value)
		{
			if (type == FitnessValue.Resistance && value is double a)
			{
				facadeFactoryDependencies.GearFacade.SetGear(new Gear((int)Math.Round(a), 1, 24));
			}
			return base.SetValueAsync(type, value);
		}
	}
	public class MockRowerFitnessConsole : MockAerobicFitnessConsoleBase
	{
		protected Average AvgFiveHundredSplit = new Average();

		public MockRowerFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Rpm,
				FitnessValue.Watts,
				FitnessValue.AvgFiveHundredSplit,
				FitnessValue.Strokes,
				FitnessValue.StrokesPerMin
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Resistance,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.NordicTrack,
				MachineType = ConsoleType.Rower,
				ModelNumber = 123,
				PartNumber = 398233,
				IsSystemMarketTypeClub = false,
				Name = "Mock Rower",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetResistance = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-ROWER";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxResistanceLevel, 16),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}

		protected override void ResetAverages()
		{
			AvgFiveHundredSplit.Reset();
			base.ResetAverages();
		}

		protected override double DeltaCalories()
		{
			return CalorieFormulas.Rower(1.0, base.LatestBasicInfo.Watts);
		}

		protected override void UpdateRunningValues()
		{
			UpdateFiveHundredSplitValues();
			UpdateStrokeValues();
			base.UpdateRunningValues();
		}

		protected override int GetMockWatts()
		{
			double num = base.LatestBasicInfo.Resistance / base.LatestBasicInfo.MaxResistanceLevel;
			int num2 = random.Next(25, 27);
			return (int)Math.Round((num + (1.0 - num) * 0.25) * 1.75 * (double)num2 * 5.0);
		}

		private void UpdateFiveHundredSplitValues()
		{
			double num = RowerEstimator.CalculateEstimatedDistance(base.LatestBasicInfo.Strokes, 1.75);
			if (!(num <= 0.0))
			{
				int num2 = (int)Math.Round((double)base.LatestBasicInfo.RunningTime / (num / 500.0));
				base.LatestBasicInfo.SetValue(FitnessValue.FiveHundredSplit, num2);
				AvgFiveHundredSplit.AddSample(num2);
				base.LatestBasicInfo.SetValue(FitnessValue.AvgFiveHundredSplit, (int)AvgFiveHundredSplit.CurrentAverage);
			}
		}

		private void UpdateStrokeValues()
		{
			int num = random.Next(25, 27);
			int num2 = (int)RowerEstimator.CalculateEstimatedStrokeCount(26.0, base.LatestBasicInfo.RunningTime);
			base.LatestBasicInfo.SetValue(FitnessValue.Strokes, num2);
			base.LatestBasicInfo.SetValue(FitnessValue.StrokesPerMin, num);
		}
	}
	public class MockSpinBikeFitnessConsole : MockAerobicFitnessConsoleBase
	{
		public MockSpinBikeFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Gear,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain,
				FitnessValue.Rpm
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Grade,
				FitnessValue.Gear,
				FitnessValue.Resistance,
				FitnessValue.Rpm,
				FitnessValue.ActualKph,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.NordicTrack,
				MachineType = ConsoleType.SpinBike,
				ModelNumber = 123,
				PartNumber = 303142,
				IsSystemMarketTypeClub = false,
				Name = "Mock TDF",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetIncline = true,
				CanSetGear = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-TDF";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 20),
				(FitnessValue.MinGrade, -20),
				(FitnessValue.MaxKph, 48),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.Gear, new Gear(1, 1, 24)),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600)
			};
		}
	}
	public class MockTreadmillFitnessConsole : MockFitnessConsoleBase
	{
		public MockTreadmillFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
			base.ReadableTypes = new List<FitnessValue>
			{
				FitnessValue.Kph,
				FitnessValue.Grade,
				FitnessValue.VerticalMeterNet,
				FitnessValue.VerticalMeterGain
			};
			base.WritableTypes = new List<FitnessValue>
			{
				FitnessValue.Grade,
				FitnessValue.Kph,
				FitnessValue.WorkoutMode,
				FitnessValue.Resistance,
				FitnessValue.Pulse
			};
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			return new MockConsoleInfo(this)
			{
				SoftwareVersion = 76,
				HardwareVersion = 1,
				SerialNumber = 1000,
				ManufacturerId = Manufacturer.ProForm,
				MachineType = ConsoleType.Treadmill,
				ModelNumber = 123,
				PartNumber = 310042,
				IsSystemMarketTypeClub = false,
				Name = "Mock Treadmill",
				MasterLibraryVersion = 1,
				MasterLibraryBuild = 1,
				CanSetIncline = true,
				CanSetKph = true
			};
		}

		protected override string GetDefaultSerialNumber()
		{
			return "MOCKCONSOLE-TREADMILL";
		}

		protected override List<(FitnessValue, object)> GetDefaultFitnessValues()
		{
			return new List<(FitnessValue, object)>
			{
				(FitnessValue.WorkoutMode, ConsoleState.Idle),
				(FitnessValue.SystemUnits, true),
				(FitnessValue.MaxGrade, 12),
				(FitnessValue.MinGrade, -3),
				(FitnessValue.MaxKph, 20),
				(FitnessValue.MinKph, 0),
				(FitnessValue.MaxWeight, 136),
				(FitnessValue.WarmupTimeout, 180),
				(FitnessValue.CoolDownTimeout, 180),
				(FitnessValue.PauseTimeout, 600),
				(FitnessValue.IdleTimeout, 600),
				(FitnessValue.SleepTimerState, false)
			};
		}

		public override void SetTargetWatts(int target)
		{
		}

		public override void ToggleConstantWattsMode(bool enabled)
		{
		}

		protected override double DeltaCalories()
		{
			return CalorieFormulas.Running(base.LatestBasicInfo.Weight, 1.0, UnitUtil.EnsureMps(SpeedUnit.Kph, base.LatestBasicInfo.Kph), base.LatestBasicInfo.Grade);
		}
	}
}
namespace Sindarin.Core.Mock.Nonconnected
{
	public interface INonconnectedFitnessConsole : IFitnessConsole, ICalibrateIncline, IDisposable
	{
		MockType MockType { get; }
	}
	public class NonconnectedBikeFitnessConsole : MockBikeFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Bike;

		public NonconnectedBikeFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424111;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Bike";
			return obj;
		}
	}
	public class NonconnectedCoreFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Core;

		public NonconnectedCoreFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433947;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Core";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-CORE";
		}
	}
	public class NonconnectedEllipticalFitnessConsole : MockEllipticalFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Elliptical;

		public NonconnectedEllipticalFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424113;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Elliptical";
			return obj;
		}
	}
	public static class NonconnectedFitnessConsoleFactory
	{
		public static INonconnectedFitnessConsole GetMockConsole(MockType type, MockFitnessConsoleOptions options)
		{
			return type switch
			{
				MockType.Treadmill => new NonconnectedTreadmillFitnessConsole(options), 
				MockType.Bike => new NonconnectedBikeFitnessConsole(options), 
				MockType.HeadlessBike => new NonconnectedFitnessHeadlessBikeConsole(options), 
				MockType.Elliptical => new NonconnectedEllipticalFitnessConsole(options), 
				MockType.Rower => new NonconnectedRowerFitnessConsole(options), 
				MockType.Strength => new NonconnectedStrengthFitnessConsole(options), 
				MockType.Yoga => new NonconnectedYogaFitnessConsole(options), 
				MockType.Mind => new NonconnectedMindFitnessConsole(options), 
				MockType.Nutrition => new NonconnectedNutritionFitnessConsole(options), 
				MockType.Core => new NonconnectedCoreFitnessConsole(options), 
				MockType.Sleep => new NonconnectedSleepFitnessConsole(options), 
				MockType.Stretch => new NonconnectedStretchFitnessConsole(options), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
	public class NonconnectedFitnessHeadlessBikeConsole : MockBikeFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Bike;

		public NonconnectedFitnessHeadlessBikeConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 438701;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Headless Bike";
			return obj;
		}
	}
	public class NonconnectedMindFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Mind;

		public NonconnectedMindFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433918;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Mind";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-MIND";
		}
	}
	public class NonconnectedMirrorFitnessConsole : NonconnectedStrengthFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public NonconnectedMirrorFitnessConsole(MockFitnessConsoleOptions options, int partNumber, string name)
			: base(options)
		{
			MockConsoleInfo obj = base.ConsoleInfo as MockConsoleInfo;
			obj.Name = name;
			obj.PartNumber = partNumber;
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424992;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Mirror";
			obj.MachineType = ConsoleType.Mirror;
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-MIRROR";
		}
	}
	public class NonconnectedNutritionFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Nutrition;

		public NonconnectedNutritionFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433946;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Nutrition";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-NUTRITION";
		}
	}
	public class NonconnectedRowerFitnessConsole : MockRowerFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Rower;

		public NonconnectedRowerFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424112;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Rower";
			return obj;
		}
	}
	public class NonconnectedSleepFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Sleep;

		public NonconnectedSleepFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433948;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Sleep";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-SLEEP";
		}
	}
	public class NonconnectedStrengthFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Strength;

		public NonconnectedStrengthFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424992;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Strength";
			obj.MachineType = ConsoleType.Equipmentless;
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-STRENGTH";
		}
	}
	public class NonconnectedStretchFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Stretch;

		public NonconnectedStretchFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433949;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Stretch";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-STRETCH";
		}
	}
	public class NonconnectedTreadmillFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Treadmill;

		public NonconnectedTreadmillFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 424110;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Treadmill";
			return obj;
		}
	}
	public class NonconnectedYogaFitnessConsole : MockTreadmillFitnessConsole, INonconnectedFitnessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		public MockType MockType => MockType.Yoga;

		public NonconnectedYogaFitnessConsole(MockFitnessConsoleOptions options)
			: base(options)
		{
		}

		protected override IConsoleInfo GetDefaultDeviceInfo()
		{
			MockConsoleInfo obj = (base.GetDefaultDeviceInfo() as MockConsoleInfo) ?? new MockConsoleInfo(this);
			obj.ModelNumber = 123;
			obj.PartNumber = 433917;
			obj.IsSystemMarketTypeClub = false;
			obj.Name = "Nonconnected Yoga";
			return obj;
		}

		protected override string GetDefaultSerialNumber()
		{
			return "NONCONNECTED-YOGA";
		}
	}
}
namespace Sindarin.Core.Facades
{
	public interface IActivationLockFacade : IReadOnlyValueFacade<ActivationLockState>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<ActivationLockState>> ObserveActivationLockChanges();

		ActivationLockState GetMostRecentActivationLock();

		Task<ActivationLockState> GetActivationLockAsync();

		void SetActivationLock(ActivationLockState activationLock);

		Task<bool> SetActivationLockAsync(ActivationLockState activationLock);
	}
	[FacadeFitnessType(FitnessValue.ActivationLock)]
	public class ActivationLockFacade : ReadWriteValueFacade<ActivationLockState>, IActivationLockFacade, IReadOnlyValueFacade<ActivationLockState>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.ActivationLock;

		public override ActivationLockState Convert(object raw)
		{
			if (raw.IsNumber() && Enum.IsDefined(typeof(ActivationLockState), System.Convert.ToInt32(raw)))
			{
				return (ActivationLockState)System.Convert.ToInt32(raw);
			}
			if (raw is bool)
			{
				raw = (((bool)raw) ? ActivationLockState.Locked : ActivationLockState.Unknown);
			}
			if (raw is ActivationLockState)
			{
				return (ActivationLockState)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to ActivationLock");
		}

		public IObservable<FitnessValueChange<ActivationLockState>> ObserveActivationLockChanges()
		{
			return ObserveChanges();
		}

		public ActivationLockState GetMostRecentActivationLock()
		{
			return GetMostRecentValue();
		}

		public async Task<ActivationLockState> GetActivationLockAsync()
		{
			return await GetValueAsync();
		}

		public void SetActivationLock(ActivationLockState activationLock)
		{
			SetValue(activationLock);
		}

		public async Task<bool> SetActivationLockAsync(ActivationLockState activationLock)
		{
			return await SetValueAsync(activationLock);
		}

		public ActivationLockFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IActualInclineFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveActualInclineChanges();

		double GetMostRecentActualIncline();

		Task<double> GetActualInclineAsync();
	}
	[FacadeFitnessType(FitnessValue.ActualIncline)]
	public class ActualInclineFacade : ReadOnlyValueFacade<double>, IActualInclineFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.ActualIncline;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to ActualIncline");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveActualInclineChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentActualIncline()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetActualInclineAsync()
		{
			return await GetValueAsync();
		}

		public ActualInclineFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IAverageGradeFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveAverageGradeChanges();

		double GetMostRecentAverageGrade();

		Task<double> GetAverageGradeAsync();
	}
	[FacadeFitnessType(FitnessValue.AverageGrade)]
	public class AverageGradeFacade : ReadOnlyValueFacade<double>, IAverageGradeFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.AverageGrade;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to avg grade");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveAverageGradeChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentAverageGrade()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetAverageGradeAsync()
		{
			return await GetValueAsync();
		}

		public AverageGradeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IAverageWattsFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveAverageWattsChanges();

		int GetMostRecentAverageWatts();

		Task<int> GetAverageWattsAsync();
	}
	[FacadeFitnessType(FitnessValue.AverageWatts)]
	public class AverageWattsFacade : ReadOnlyValueFacade<int>, IAverageWattsFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.AverageWatts;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to AverageWatts");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveAverageWattsChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentAverageWatts()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetAverageWattsAsync()
		{
			return await GetValueAsync();
		}

		public AverageWattsFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IAvgFiveHundredSplitFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveAvgFiveHundredSplitChanges();

		int GetMostRecentAvgFiveHundredSplit();

		Task<int> GetAvgFiveHundredSplitAsync();
	}
	[FacadeFitnessType(FitnessValue.AvgFiveHundredSplit)]
	public class AvgFiveHundredSplitFacade : ReadOnlyValueFacade<int>, IAvgFiveHundredSplitFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.AvgFiveHundredSplit;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to AvgFiveHundredSplit");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveAvgFiveHundredSplitChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentAvgFiveHundredSplit()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetAvgFiveHundredSplitAsync()
		{
			return await GetValueAsync();
		}

		public AvgFiveHundredSplitFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ICaloriesFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveCalorieChanges();

		double GetMostRecentCalories();

		Task<double> GetCaloriesAsync();
	}
	[FacadeFitnessType(FitnessValue.CurrentCalories)]
	public class CaloriesFacade : ReadOnlyValueFacade<double>, ICaloriesFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.CurrentCalories;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Calories");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveCalorieChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentCalories()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetCaloriesAsync()
		{
			return await GetValueAsync();
		}

		public CaloriesFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IConsoleControlValuesFacade
	{
		void SetControlValues(ConsoleControlValues cv);
	}
	public class ConsoleControlValuesFacade : IConsoleControlValuesFacade
	{
		private readonly IFitnessConsoleManager fitnessConsoleManager;

		public ConsoleControlValuesFacade(IFitnessConsoleManager fitnessConsoleManager)
		{
			this.fitnessConsoleManager = fitnessConsoleManager;
		}

		public void SetControlValues(ConsoleControlValues cv)
		{
			Log.Trace("ConsoleControlValueFacade", $"ConsoleControlValues: {cv}");
			fitnessConsoleManager.CurrentConsole?.SetValues((FitnessValue.Kph, cv.Kph), (FitnessValue.Grade, cv.Incline), (FitnessValue.Resistance, cv.Resistance), (FitnessValue.Gear, cv.Gear));
		}
	}
	public class ConsoleControlValues
	{
		public double? Kph { get; set; }

		public double? Incline { get; set; }

		public double? Resistance { get; set; }

		public int? Gear { get; set; }

		public override string ToString()
		{
			return $"Kph is {Kph}, Incline is {Incline}, Resistance is {Resistance}, Gear is {Gear}";
		}
	}
	public interface IConsoleStateFacade : IReadOnlyValueFacade<ConsoleState>, IReadOnlyValueFacade
	{
		IObservable<StateChange> ObserveConsoleStateChanges();

		void SetConsoleState(ConsoleState state);

		Task<bool> SetConsoleStateAsync(ConsoleState state);

		ConsoleState GetMostRecentConsoleState();

		Task<ConsoleState> GetConsoleStateAsync();
	}
	[FacadeFitnessType(FitnessValue.WorkoutMode)]
	public class ConsoleStateFacade : ReadWriteValueFacade<ConsoleState>, IConsoleStateFacade, IReadOnlyValueFacade<ConsoleState>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.WorkoutMode;

		public override ConsoleState Convert(object raw)
		{
			if (raw is ConsoleState)
			{
				return (ConsoleState)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to WorkoutMode");
		}

		public IObservable<StateChange> ObserveConsoleStateChanges()
		{
			return from x in ObserveChanges()
				select new StateChange(x.Old, x.Current);
		}

		public void SetConsoleState(ConsoleState state)
		{
			SetValue(state);
		}

		public async Task<bool> SetConsoleStateAsync(ConsoleState state)
		{
			return await SetValueAsync(state);
		}

		public ConsoleState GetMostRecentConsoleState()
		{
			return GetMostRecentValue();
		}

		public async Task<ConsoleState> GetConsoleStateAsync()
		{
			return await GetValueAsync();
		}

		public ConsoleStateFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public class ConsoleStateStatsFacade : MultiReadFacade<ConsoleStateValues>
	{
		private readonly IMultiReadResultSetter resultSetter;

		public ConsoleStateStatsFacade(IMultiReadResultSetter resultSetter, IFacadeRepository repository, IFitnessConsoleManager fitnessConsoleManager)
			: base(repository, fitnessConsoleManager)
		{
			this.resultSetter = resultSetter;
		}

		protected override ConsoleStateValues Convert(IReadOnlyValueFacade facade, AnyFitnessValueChange change)
		{
			ConsoleStateValues consoleStateValues = new ConsoleStateValues();
			resultSetter.SetResultForFacade(facade, change, consoleStateValues);
			return consoleStateValues;
		}
	}
	public class ConsoleStateValues : IDeepCloneable<ConsoleStateValues>, IDeepCloneable
	{
		[FitnessValueProperty(FitnessValue.ActualKph)]
		public double? ActualKph { get; internal set; }

		[FitnessValueProperty(FitnessValue.Kph)]
		public double? Kph { get; internal set; }

		[FitnessValueProperty(FitnessValue.Grade)]
		public double? Grade { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentDistance)]
		public double? CurrentDistanceMeters { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentTime)]
		public int? CurrentTimeSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentCalories)]
		public double? Calories { get; internal set; }

		[FitnessValueProperty(FitnessValue.Watts)]
		public int? Watts { get; internal set; }

		[FitnessValueProperty(FitnessValue.Resistance)]
		public double? Resistance { get; internal set; }

		[FitnessValueProperty(FitnessValue.Gear)]
		public Gear Gear { get; internal set; }

		[FitnessValueProperty(FitnessValue.Rpm)]
		public int? Rpm { get; internal set; }

		[FitnessValueProperty(FitnessValue.VerticalMeterGain)]
		public double? VerticalMetersGain { get; internal set; }

		[FitnessValueProperty(FitnessValue.VerticalMeterNet)]
		public double? VerticalMetersNet { get; internal set; }

		[FitnessValueProperty(FitnessValue.Pulse)]
		public Pulse Pulse { get; internal set; }

		[FitnessValueProperty(FitnessValue.Strokes)]
		public int? Strokes { get; internal set; }

		[FitnessValueProperty(FitnessValue.StrokesPerMin)]
		public int? StrokesPerMin { get; internal set; }

		[FitnessValueProperty(FitnessValue.FiveHundredSplit)]
		public int? FiveHundredSplit { get; internal set; }

		[FitnessValueProperty(FitnessValue.FiveHundredSplitDecimal)]
		public int? FiveHundredSplitDecimal { get; internal set; }

		[FitnessValueProperty(FitnessValue.AvgFiveHundredSplit)]
		public int? AvgFiveHundredSplit { get; internal set; }

		public ConsoleStateValues DeepClone()
		{
			return new ConsoleStateValues
			{
				ActualKph = ActualKph,
				Kph = Kph,
				Grade = Grade,
				CurrentDistanceMeters = CurrentDistanceMeters,
				CurrentTimeSeconds = CurrentTimeSeconds,
				Calories = Calories,
				Watts = Watts,
				Resistance = Resistance,
				Gear = Gear,
				Rpm = Rpm,
				VerticalMetersGain = VerticalMetersGain,
				VerticalMetersNet = VerticalMetersNet,
				Pulse = Pulse,
				Strokes = Strokes,
				StrokesPerMin = StrokesPerMin,
				FiveHundredSplit = FiveHundredSplit,
				AvgFiveHundredSplit = AvgFiveHundredSplit
			};
		}

		object IDeepCloneable.DeepClone()
		{
			return DeepClone();
		}
	}
	public interface ICoolDownTimeoutFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveCoolDownTimeoutChanges();

		int GetMostRecentCoolDownTimeout();

		Task<int> GetCoolDownTimeoutAsync();

		void SetCoolDownTimeout(int coolDownTimeout);

		Task<bool> SetCoolDownTimeoutAsync(int coolDownTimeout);
	}
	[FacadeFitnessType(FitnessValue.CoolDownTimeout)]
	public class CoolDownTimeoutFacade : ReadWriteValueFacade<int>, ICoolDownTimeoutFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.CoolDownTimeout;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to CoolDownTimeout");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveCoolDownTimeoutChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentCoolDownTimeout()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetCoolDownTimeoutAsync()
		{
			return await GetValueAsync();
		}

		public void SetCoolDownTimeout(int coolDownTimeout)
		{
			SetValue(coolDownTimeout);
		}

		public async Task<bool> SetCoolDownTimeoutAsync(int coolDownTimeout)
		{
			return await SetValueAsync(coolDownTimeout);
		}

		public CoolDownTimeoutFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ICurrentTimeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveCurrentTimeChanges();

		int GetMostRecentCurrentTime();

		Task<int> GetCurrentTimeAsync();
	}
	[FacadeFitnessType(FitnessValue.CurrentTime)]
	public class CurrentTimeFacade : ReadOnlyValueFacade<int>, ICurrentTimeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.CurrentTime;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to CurrentTime");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveCurrentTimeChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentCurrentTime()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetCurrentTimeAsync()
		{
			return await GetValueAsync();
		}

		public CurrentTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IReadWriteFacadeFactoryDependencies
	{
		IKphFacade KphFacade { get; }

		IAvgSpeedFacade AvgSpeedFacade { get; }

		IGradeFacade GradeFacade { get; }

		IResistanceFacade ResistanceFacade { get; }

		IWattsFacade WattsFacade { get; }

		ICurrentDistanceFacade CurrentDistanceFacade { get; }

		IRpmFacade RpmFacade { get; }

		IKeyObjectFacade KeyObjectFacade { get; }

		IVolumeFacade VolumeFacade { get; }

		IPulseFacade PulseFacade { get; }

		IRunningTimeFacade RunningTimeFacade { get; }

		IConsoleStateFacade ConsoleStateFacade { get; }

		ILapTimeFacade LapTimeFacade { get; }

		IActualKphFacade ActualKphFacade { get; }

		IActualInclineFacade ActualInclineFacade { get; }

		ICurrentTimeFacade CurrentTimeFacade { get; }

		ICaloriesFacade CaloriesFacade { get; }

		IGoalTimeFacade GoalTimeFacade { get; }

		IWeightFacade WeightFacade { get; }

		IGearFacade GearFacade { get; }

		IMaxGradeFacade MaxGradeFacade { get; }

		IMinGradeFacade MinGradeFacade { get; }

		IMaxKphFacade MaxKphFacade { get; }

		IMinKphFacade MinKphFacade { get; }

		IIdleTimeoutFacade IdleTimeoutFacade { get; }

		IPauseTimeoutFacade PauseTimeoutFacade { get; }

		ISystemUnitsFacade SystemUnitsFacade { get; }

		IMaxResistanceLevelFacade MaxResistanceLevelFacade { get; }

		IMaxWeightFacade MaxWeightFacade { get; }

		IWarmupTimeoutFacade WarmupTimeoutFacade { get; }

		ICoolDownTimeoutFacade CoolDownTimeoutFacade { get; }

		IMaxPulseFacade MaxPulseFacade { get; }

		IAverageWattsFacade AverageWattsFacade { get; }

		IWattGoalFacade WattGoalFacade { get; }

		IDistanceGoalFacade DistanceGoalFacade { get; }

		IMotorTotalDistanceFacade MotorTotalDistanceFacade { get; }

		ITotalTimeFacade TotalTimeFacade { get; }

		IVerticalMeterNetFacade VerticalMeterNetFacade { get; }

		IVerticalMeterGainFacade VerticalMeterGainFacade { get; }

		IIdleModeLockoutFacade IdleModeLockoutFacade { get; }

		ISleepTimerStateFacade SleepTimerStateFacade { get; }

		IStartRequestedFacade StartRequestedFacade { get; }

		IFanStateFacade FanStateFacade { get; }

		IActivationLockFacade ActivationLockFacade { get; }

		IPausedTimeFacade PausedTimeFacade { get; }

		IRequireStartRequestedFacade RequireStartRequestedFacade { get; }

		IStrokesFacade StrokesFacade { get; }

		IStrokesPerMinFacade StrokesPerMinFacade { get; }

		IFiveHundredSplitFacade FiveHundredSplitFacade { get; }

		IFiveHundredSplitDecimalFacade FiveHundredSplitDecimalFacade { get; }

		IAvgFiveHundredSplitFacade AvgFiveHundredSplitFacade { get; }

		IIsClubUnitFacade IsClubUnitFacade { get; }

		IIsReadyToDisconnectFacade IsReadyToDisconnectFacade { get; }

		IIsConstantWattsModeFacade IsConstantWattsModeFacade { get; }

		IMaxRpmFacade MaxRpmFacade { get; }

		IAverageGradeFacade AverageGradeFacade { get; }
	}
	public class ReadWriteFacadeFactoryDependencies : IReadWriteFacadeFactoryDependencies
	{
		public IKphFacade KphFacade { get; }

		public IAvgSpeedFacade AvgSpeedFacade { get; }

		public IGradeFacade GradeFacade { get; }

		public IResistanceFacade ResistanceFacade { get; }

		public IWattsFacade WattsFacade { get; }

		public ICurrentDistanceFacade CurrentDistanceFacade { get; }

		public IRpmFacade RpmFacade { get; }

		public IKeyObjectFacade KeyObjectFacade { get; }

		public IVolumeFacade VolumeFacade { get; }

		public IPulseFacade PulseFacade { get; }

		public IRunningTimeFacade RunningTimeFacade { get; }

		public IConsoleStateFacade ConsoleStateFacade { get; }

		public ILapTimeFacade LapTimeFacade { get; }

		public IActualKphFacade ActualKphFacade { get; }

		public IActualInclineFacade ActualInclineFacade { get; }

		public ICurrentTimeFacade CurrentTimeFacade { get; }

		public ICaloriesFacade CaloriesFacade { get; }

		public IGoalTimeFacade GoalTimeFacade { get; }

		public IWeightFacade WeightFacade { get; }

		public IGearFacade GearFacade { get; }

		public IMaxGradeFacade MaxGradeFacade { get; }

		public IMinGradeFacade MinGradeFacade { get; }

		public IMaxKphFacade MaxKphFacade { get; }

		public IMinKphFacade MinKphFacade { get; }

		public IIdleTimeoutFacade IdleTimeoutFacade { get; }

		public IPauseTimeoutFacade PauseTimeoutFacade { get; }

		public ISystemUnitsFacade SystemUnitsFacade { get; }

		public IMaxResistanceLevelFacade MaxResistanceLevelFacade { get; }

		public IMaxWeightFacade MaxWeightFacade { get; }

		public IWarmupTimeoutFacade WarmupTimeoutFacade { get; }

		public ICoolDownTimeoutFacade CoolDownTimeoutFacade { get; }

		public IMaxPulseFacade MaxPulseFacade { get; }

		public IAverageWattsFacade AverageWattsFacade { get; }

		public IWattGoalFacade WattGoalFacade { get; }

		public IDistanceGoalFacade DistanceGoalFacade { get; }

		public IMotorTotalDistanceFacade MotorTotalDistanceFacade { get; }

		public ITotalTimeFacade TotalTimeFacade { get; }

		public IVerticalMeterNetFacade VerticalMeterNetFacade { get; }

		public IVerticalMeterGainFacade VerticalMeterGainFacade { get; }

		public IIdleModeLockoutFacade IdleModeLockoutFacade { get; }

		public ISleepTimerStateFacade SleepTimerStateFacade { get; }

		public IStartRequestedFacade StartRequestedFacade { get; }

		public IFanStateFacade FanStateFacade { get; }

		public IActivationLockFacade ActivationLockFacade { get; }

		public IPausedTimeFacade PausedTimeFacade { get; }

		public IRequireStartRequestedFacade RequireStartRequestedFacade { get; }

		public IStrokesFacade StrokesFacade { get; }

		public IStrokesPerMinFacade StrokesPerMinFacade { get; }

		public IFiveHundredSplitFacade FiveHundredSplitFacade { get; }

		public IFiveHundredSplitDecimalFacade FiveHundredSplitDecimalFacade { get; }

		public IAvgFiveHundredSplitFacade AvgFiveHundredSplitFacade { get; }

		public IIsClubUnitFacade IsClubUnitFacade { get; }

		public IIsReadyToDisconnectFacade IsReadyToDisconnectFacade { get; }

		public IIsConstantWattsModeFacade IsConstantWattsModeFacade { get; }

		public IMaxRpmFacade MaxRpmFacade { get; }

		public IAverageGradeFacade AverageGradeFacade { get; }

		public ReadWriteFacadeFactoryDependencies(IKphFacade kphFacade = null, IAvgSpeedFacade avgSpeedFacade = null, IGradeFacade gradeFacade = null, IResistanceFacade resistanceFacade = null, IWattsFacade wattsFacade = null, ICurrentDistanceFacade currentDistanceFacade = null, IRpmFacade rpmFacade = null, IKeyObjectFacade keyObjectFacade = null, IVolumeFacade volumeFacade = null, IPulseFacade pulseFacade = null, IRunningTimeFacade runningTimeFacade = null, IConsoleStateFacade consoleStateFacade = null, ILapTimeFacade lapTimeFacade = null, IActualKphFacade actualKphFacade = null, IActualInclineFacade actualInclineFacade = null, ICurrentTimeFacade currentTimeFacade = null, ICaloriesFacade caloriesFacade = null, IGoalTimeFacade goalTimeFacade = null, IWeightFacade weightFacade = null, IGearFacade gearFacade = null, IMaxGradeFacade maxGradeFacade = null, IMinGradeFacade minGradeFacade = null, IMaxKphFacade maxKphFacade = null, IMinKphFacade minKphFacade = null, IIdleTimeoutFacade idleTimeoutFacade = null, IPauseTimeoutFacade pauseTimeoutFacade = null, ISystemUnitsFacade systemUnitsFacade = null, IMaxResistanceLevelFacade maxResistanceLevelFacade = null, IMaxWeightFacade maxWeightFacade = null, IWarmupTimeoutFacade warmupTimeoutFacade = null, ICoolDownTimeoutFacade coolDownTimeoutFacade = null, IMaxPulseFacade maxPulseFacade = null, IAverageWattsFacade averageWattsFacade = null, IWattGoalFacade wattGoalFacade = null, IDistanceGoalFacade distanceGoalFacade = null, IMotorTotalDistanceFacade motorTotalDistanceFacade = null, ITotalTimeFacade totalTimeFacade = null, IVerticalMeterNetFacade verticalMeterNetFacade = null, IVerticalMeterGainFacade verticalMeterGainFacade = null, IIdleModeLockoutFacade idleModeLockoutFacade = null, ISleepTimerStateFacade sleepTimerStateFacade = null, IStartRequestedFacade startRequestedFacade = null, IFanStateFacade fanStateFacade = null, IActivationLockFacade activationLockFacade = null, IPausedTimeFacade pausedTimeFacade = null, IRequireStartRequestedFacade requireStartRequestedFacade = null, IStrokesFacade strokesFacade = null, IStrokesPerMinFacade strokesPerMinFacade = null, IFiveHundredSplitFacade fiveHundredSplitFacade = null, IFiveHundredSplitDecimalFacade fiveHundredSplitDecimalFacade = null, IAvgFiveHundredSplitFacade avgFiveHundredSplitFacade = null, IIsClubUnitFacade isClubUnitFacade = null, IIsReadyToDisconnectFacade isReadyToDisconnectFacade = null, IIsConstantWattsModeFacade isConstantWattsModeFacade = null, IMaxRpmFacade maxRpmFacade = null, IAverageGradeFacade averageGradeFacade = null)
		{
			KphFacade = kphFacade;
			AvgSpeedFacade = avgSpeedFacade;
			GradeFacade = gradeFacade;
			ResistanceFacade = resistanceFacade;
			WattsFacade = wattsFacade;
			CurrentDistanceFacade = currentDistanceFacade;
			RpmFacade = rpmFacade;
			KeyObjectFacade = keyObjectFacade;
			VolumeFacade = volumeFacade;
			PulseFacade = pulseFacade;
			RunningTimeFacade = runningTimeFacade;
			ConsoleStateFacade = consoleStateFacade;
			LapTimeFacade = lapTimeFacade;
			ActualKphFacade = actualKphFacade;
			ActualInclineFacade = actualInclineFacade;
			CurrentTimeFacade = currentTimeFacade;
			CaloriesFacade = caloriesFacade;
			GoalTimeFacade = goalTimeFacade;
			WeightFacade = weightFacade;
			GearFacade = gearFacade;
			MaxGradeFacade = maxGradeFacade;
			MinGradeFacade = minGradeFacade;
			MaxKphFacade = maxKphFacade;
			MinKphFacade = minKphFacade;
			IdleTimeoutFacade = idleTimeoutFacade;
			PauseTimeoutFacade = pauseTimeoutFacade;
			SystemUnitsFacade = systemUnitsFacade;
			MaxResistanceLevelFacade = maxResistanceLevelFacade;
			MaxWeightFacade = maxWeightFacade;
			WarmupTimeoutFacade = warmupTimeoutFacade;
			CoolDownTimeoutFacade = coolDownTimeoutFacade;
			MaxPulseFacade = maxPulseFacade;
			AverageWattsFacade = averageWattsFacade;
			WattGoalFacade = wattGoalFacade;
			DistanceGoalFacade = distanceGoalFacade;
			MotorTotalDistanceFacade = motorTotalDistanceFacade;
			TotalTimeFacade = totalTimeFacade;
			VerticalMeterNetFacade = verticalMeterNetFacade;
			VerticalMeterGainFacade = verticalMeterGainFacade;
			IdleModeLockoutFacade = idleModeLockoutFacade;
			SleepTimerStateFacade = sleepTimerStateFacade;
			StartRequestedFacade = startRequestedFacade;
			FanStateFacade = fanStateFacade;
			ActivationLockFacade = activationLockFacade;
			PausedTimeFacade = pausedTimeFacade;
			RequireStartRequestedFacade = requireStartRequestedFacade;
			StrokesFacade = strokesFacade;
			StrokesPerMinFacade = strokesPerMinFacade;
			FiveHundredSplitFacade = fiveHundredSplitFacade;
			FiveHundredSplitDecimalFacade = fiveHundredSplitDecimalFacade;
			AvgFiveHundredSplitFacade = avgFiveHundredSplitFacade;
			IsClubUnitFacade = isClubUnitFacade;
			IsReadyToDisconnectFacade = isReadyToDisconnectFacade;
			IsConstantWattsModeFacade = isConstantWattsModeFacade;
			MaxRpmFacade = maxRpmFacade;
			AverageGradeFacade = averageGradeFacade;
		}
	}
	public interface IFanStateFacade : IReadOnlyValueFacade<FanState>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<FanState>> ObserveFanStateChanges();

		FanState GetMostRecentFanState();

		Task<FanState> GetFanStateAsync();

		void SetFanState(FanState fanState);

		Task<bool> SetFanStateAsync(FanState fanState);
	}
	[FacadeFitnessType(FitnessValue.FanState)]
	public class FanStateFacade : ReadWriteValueFacade<FanState>, IFanStateFacade, IReadOnlyValueFacade<FanState>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.FanState;

		public override FanState Convert(object raw)
		{
			if (raw is FanState)
			{
				return (FanState)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to FanState");
		}

		public IObservable<FitnessValueChange<FanState>> ObserveFanStateChanges()
		{
			return ObserveChanges();
		}

		public FanState GetMostRecentFanState()
		{
			return GetMostRecentValue();
		}

		public async Task<FanState> GetFanStateAsync()
		{
			return await GetValueAsync();
		}

		public void SetFanState(FanState fanState)
		{
			SetValue(fanState);
		}

		public async Task<bool> SetFanStateAsync(FanState fanState)
		{
			return await SetValueAsync(fanState);
		}

		public FanStateFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class FitnessValueProperty : Attribute
	{
		public FitnessValue FitnessValue { get; }

		public FitnessValueProperty(FitnessValue fitnessValue)
		{
			FitnessValue = fitnessValue;
		}
	}
	public interface IFiveHundredSplitDecimalFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveFiveHundredDecimalSplitChanges();

		int GetMostRecentFiveHundredDecimalSplit();

		Task<int> GetFiveHundredSplitDecimalAsync();
	}
	[FacadeFitnessType(FitnessValue.FiveHundredSplitDecimal)]
	public class FiveHundredSplitDecimalFacade : ReadOnlyValueFacade<int>, IFiveHundredSplitDecimalFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.FiveHundredSplitDecimal;

		public FiveHundredSplitDecimalFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to FiveHundredSplit");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveFiveHundredDecimalSplitChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentFiveHundredDecimalSplit()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetFiveHundredSplitDecimalAsync()
		{
			return await GetValueAsync();
		}
	}
	public interface IFiveHundredSplitFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveFiveHundredSplitChanges();

		int GetMostRecentFiveHundredSplit();

		Task<int> GetFiveHundredSplitAsync();
	}
	[FacadeFitnessType(FitnessValue.FiveHundredSplit)]
	public class FiveHundredSplitFacade : ReadOnlyValueFacade<int>, IFiveHundredSplitFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.FiveHundredSplit;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to FiveHundredSplit");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveFiveHundredSplitChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentFiveHundredSplit()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetFiveHundredSplitAsync()
		{
			return await GetValueAsync();
		}

		public FiveHundredSplitFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IGearFacade : IReadOnlyValueFacade<Gear>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<Gear>> ObserveGearChanges();

		Gear GetMostRecentGear();

		Task<Gear> GetGearAsync();

		void SetGear(Gear gear);

		Task<bool> SetGearAsync(Gear gear);
	}
	[FacadeFitnessType(FitnessValue.Gear)]
	public class GearFacade : ReadWriteValueFacade<Gear>, IGearFacade, IReadOnlyValueFacade<Gear>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Gear;

		public GearFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override Gear Convert(object raw)
		{
			if (raw.IsNumber())
			{
				raw = new Gear(System.Convert.ToInt32(raw));
			}
			return (raw as Gear) ?? throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Gear");
		}

		public IObservable<FitnessValueChange<Gear>> ObserveGearChanges()
		{
			return ObserveChanges();
		}

		public Gear GetMostRecentGear()
		{
			return GetMostRecentValue();
		}

		public async Task<Gear> GetGearAsync()
		{
			return await GetValueAsync();
		}

		public void SetGear(Gear gear)
		{
			SetValue(gear);
		}

		public async Task<bool> SetGearAsync(Gear gear)
		{
			return await SetValueAsync(gear);
		}
	}
	public interface IGoalTimeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveGoalTimeChanges();

		int GetMostRecentGoalTime();

		Task<int> GetGoalTimeAsync();

		void SetGoalTime(int goalTime);

		Task<bool> SetGoalTimeAsync(int goalTime);
	}
	[FacadeFitnessType(FitnessValue.GoalTime)]
	public class GoalTimeFacade : ReadWriteValueFacade<int>, IGoalTimeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.GoalTime;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to GoalTime");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveGoalTimeChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentGoalTime()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetGoalTimeAsync()
		{
			return await GetValueAsync();
		}

		public void SetGoalTime(int goalTime)
		{
			SetValue(goalTime);
		}

		public async Task<bool> SetGoalTimeAsync(int goalTime)
		{
			return await SetValueAsync(goalTime);
		}

		public GoalTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IGradeFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveGradeChanges();

		void SetGrade(double grade);

		Task<bool> SetGradeAsync(double grade);

		double GetMostRecentGrade();

		Task<double> GetGradeAsync();
	}
	[FacadeFitnessType(FitnessValue.Grade)]
	public class GradeFacade : ReadWriteValueFacade<double>, IGradeFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Grade;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to grade");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveGradeChanges()
		{
			return ObserveChanges();
		}

		public void SetGrade(double grade)
		{
			SetValue(grade);
		}

		public async Task<bool> SetGradeAsync(double grade)
		{
			Log.Trace("Tests", $"Setting grade to {grade} for console {FitnessConsole.GetHashCode()}");
			return await SetValueAsync(grade);
		}

		public double GetMostRecentGrade()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetGradeAsync()
		{
			return await GetValueAsync();
		}

		public GradeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IIdleModeLockoutFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveIdleModeLockoutChanges();

		bool GetMostRecentIdleModeLockout();

		Task<bool> GetIdleModeLockoutAsync();

		void SetIdleModeLockout(bool idleModeLockout);

		Task<bool> SetIdleModeLockoutAsync(bool idleModeLockout);
	}
	[FacadeFitnessType(FitnessValue.IdleModeLockout)]
	public class IdleModeLockoutFacade : ReadWriteValueFacade<bool>, IIdleModeLockoutFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.IdleModeLockout;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to IdleModeLockout");
		}

		public IObservable<FitnessValueChange<bool>> ObserveIdleModeLockoutChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentIdleModeLockout()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetIdleModeLockoutAsync()
		{
			return await GetValueAsync();
		}

		public void SetIdleModeLockout(bool idleModeLockout)
		{
			SetValue(idleModeLockout);
		}

		public async Task<bool> SetIdleModeLockoutAsync(bool idleModeLockout)
		{
			return await SetValueAsync(idleModeLockout);
		}

		public IdleModeLockoutFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IIdleTimeoutFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveIdleTimeoutChanges();

		int GetMostRecentIdleTimeout();

		Task<int> GetIdleTimeoutAsync();

		void SetIdleTimeout(int idleTimeout);

		Task<bool> SetIdleTimeoutAsync(int idleTimeout);
	}
	[FacadeFitnessType(FitnessValue.IdleTimeout)]
	public class IdleTimeoutFacade : ReadWriteValueFacade<int>, IIdleTimeoutFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.IdleTimeout;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to IdleTimeout");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveIdleTimeoutChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentIdleTimeout()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetIdleTimeoutAsync()
		{
			return await GetValueAsync();
		}

		public void SetIdleTimeout(int idleTimeout)
		{
			SetValue(idleTimeout);
		}

		public async Task<bool> SetIdleTimeoutAsync(int idleTimeout)
		{
			return await SetValueAsync(idleTimeout);
		}

		public IdleTimeoutFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IIsClubUnitFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveIsClubUnitChanges();

		bool GetMostRecentIsClubUnit();

		Task<bool> GetIsClubUnitAsync();
	}
	[FacadeFitnessType(FitnessValue.IsClubUnit)]
	public class IsClubUnitFacade : ReadOnlyValueFacade<bool>, IIsClubUnitFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.IsClubUnit;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to IsClubUnit");
		}

		public IObservable<FitnessValueChange<bool>> ObserveIsClubUnitChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentIsClubUnit()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetIsClubUnitAsync()
		{
			return await GetValueAsync();
		}

		public IsClubUnitFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IIsConstantWattsModeFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveIsConstantWattsModeChanges();

		bool GetMostRecentIsConstantWattsMode();

		Task<bool> GetIsConstantWattsModeAsync();

		void SetIsConstantWattsMode(bool isConstantWattsMode);

		Task<bool> SetIsConstantWattsModeAsync(bool isConstantWattsMode);
	}
	[FacadeFitnessType(FitnessValue.IsConstantWattsMode)]
	public class IsConstantWattsModeFacade : ReadWriteValueFacade<bool>, IIsConstantWattsModeFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.IsConstantWattsMode;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to IsConstantWattsMode");
		}

		public IObservable<FitnessValueChange<bool>> ObserveIsConstantWattsModeChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentIsConstantWattsMode()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetIsConstantWattsModeAsync()
		{
			return await GetValueAsync();
		}

		public void SetIsConstantWattsMode(bool isConstantWattsMode)
		{
			SetValue(isConstantWattsMode);
		}

		public async Task<bool> SetIsConstantWattsModeAsync(bool isConstantWattsMode)
		{
			return await SetValueAsync(isConstantWattsMode);
		}

		public IsConstantWattsModeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IIsReadyToDisconnectFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveIsReadyToDisconnectChanges();

		bool GetMostRecentIsReadyToDisconnect();

		Task<bool> GetIsReadyToDisconnectAsync();
	}
	[FacadeFitnessType(FitnessValue.IsReadyToDisconnect)]
	public class IsReadyToDisconnectFacade : ReadOnlyValueFacade<bool>, IIsReadyToDisconnectFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.IsReadyToDisconnect;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to IsReadyToDisconnect");
		}

		public IObservable<FitnessValueChange<bool>> ObserveIsReadyToDisconnectChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentIsReadyToDisconnect()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetIsReadyToDisconnectAsync()
		{
			return await GetValueAsync();
		}

		public IsReadyToDisconnectFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IKeyObjectFacade : IReadOnlyValueFacade<KeyObj>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<KeyObj>> ObserveKeyObjectChanges();

		KeyObj GetMostRecentKeyObj();

		Task<KeyObj> GetKeyObjAsync();
	}
	[FacadeFitnessType(FitnessValue.KeyObject)]
	public class KeyObjectFacade : ReadOnlyValueFacade<KeyObj>, IKeyObjectFacade, IReadOnlyValueFacade<KeyObj>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.KeyObject;

		public override KeyObj Convert(object raw)
		{
			if (raw == null)
			{
				return null;
			}
			return (raw as KeyObj) ?? throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to KeyObject");
		}

		public IObservable<FitnessValueChange<KeyObj>> ObserveKeyObjectChanges()
		{
			return ObserveChanges();
		}

		public KeyObj GetMostRecentKeyObj()
		{
			return GetMostRecentValue();
		}

		public async Task<KeyObj> GetKeyObjAsync()
		{
			return await GetValueAsync();
		}

		public KeyObjectFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ILapTimeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveLapTimeChanges();

		int GetMostRecentLapTime();

		Task<int> GetLapTimeAsync();
	}
	[FacadeFitnessType(FitnessValue.LapTime)]
	public class LapTimeFacade : ReadOnlyValueFacade<int>, ILapTimeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.LapTime;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Lap Time");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveLapTimeChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentLapTime()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetLapTimeAsync()
		{
			return await GetValueAsync();
		}

		public LapTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMaxGradeFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMaxGradeChanges();

		double GetMostRecentMaxGrade();

		Task<double> GetMaxGradeAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxGrade)]
	public class MaxGradeFacade : ReadOnlyValueFacade<double>, IMaxGradeFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxGrade;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxGrade");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxGradeChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentMaxGrade()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetMaxGradeAsync()
		{
			return await GetValueAsync();
		}

		public MaxGradeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMaxPulseFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveMaxPulseChanges();

		int GetMostRecentMaxPulse();

		Task<int> GetMaxPulseAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxPulse)]
	public class MaxPulseFacade : ReadOnlyValueFacade<int>, IMaxPulseFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxPulse;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxPulse");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveMaxPulseChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentMaxPulse()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetMaxPulseAsync()
		{
			return await GetValueAsync();
		}

		public MaxPulseFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMaxRpmFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveMaxRpmChanges();

		int GetMostRecentMaxRpm();

		Task<int> GetMaxRpmAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxRpm)]
	public class MaxRpmFacade : ReadOnlyValueFacade<int>, IMaxRpmFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxPulse;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxRpm");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveMaxRpmChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentMaxRpm()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetMaxRpmAsync()
		{
			return await GetValueAsync();
		}

		public MaxRpmFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMaxWeightFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMaxWeightKgChanges();

		IObservable<FitnessValueChange<double>> ObserveMaxWeightLbChanges();

		double GetMostRecentMaxWeightKg();

		double GetMostRecentMaxWeightLb();

		Task<double> GetMaxWeightKgAsync();

		Task<double> GetMaxWeightLbAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxWeight)]
	public class MaxWeightFacade : ReadOnlyValueFacade<double>, IMaxWeightFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxWeight;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxWeight");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxWeightKgChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxWeightLbChanges()
		{
			return from x in ObserveMaxWeightKgChanges()
				select new FitnessValueChange<double>(Type, x.Old.KgToLb(), x.Current.KgToLb());
		}

		public double GetMostRecentMaxWeightKg()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentMaxWeightLb()
		{
			return GetMostRecentMaxWeightKg().KgToLb();
		}

		public async Task<double> GetMaxWeightKgAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetMaxWeightLbAsync()
		{
			return (await GetMaxWeightKgAsync()).KgToLb();
		}

		public MaxWeightFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMinGradeFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMinGradeChanges();

		double GetMostRecentMinGrade();

		Task<double> GetMinGradeAsync();
	}
	[FacadeFitnessType(FitnessValue.MinGrade)]
	public class MinGradeFacade : ReadOnlyValueFacade<double>, IMinGradeFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MinGrade;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MinGrade");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMinGradeChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentMinGrade()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetMinGradeAsync()
		{
			return await GetValueAsync();
		}

		public MinGradeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMotorTotalDistanceFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMotorTotalDistanceChanges();

		double GetMostRecentMotorTotalDistance();

		Task<double> GetMotorTotalDistanceAsync();
	}
	[FacadeFitnessType(FitnessValue.MotorTotalDistance)]
	public class MotorTotalDistanceFacade : ReadOnlyValueFacade<double>, IMotorTotalDistanceFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MotorTotalDistance;

		public override double Convert(object raw)
		{
			if (raw == null)
			{
				return 0.0;
			}
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MotorTotalDistance");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMotorTotalDistanceChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentMotorTotalDistance()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetMotorTotalDistanceAsync()
		{
			return await GetValueAsync();
		}

		public MotorTotalDistanceFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMultiReadFacade
	{
	}
	public abstract class MultiReadFacade<T> : IMultiReadFacade where T : class, IDeepCloneable<T>
	{
		private readonly IFacadeRepository repository;

		private readonly FitnessValue[] fitnessValues;

		private readonly IFitnessConsoleManager fitnessConsoleManager;

		protected T old;

		protected MultiReadFacade(IFacadeRepository repository, IFitnessConsoleManager fitnessConsoleManager)
		{
			this.repository = repository;
			this.fitnessConsoleManager = fitnessConsoleManager;
			fitnessValues = typeof(T).GetFitnessValuesForPropertyAttributes();
		}

		public virtual IObservable<FitnessValueChange<T>> ObserveChanges()
		{
			return fitnessConsoleManager.ObserveValues(fitnessValues).Select(delegate(AnyFitnessValueChange x)
			{
				IReadOnlyValueFacade facade = repository.GetFacade(x.Type);
				T val = Convert(facade, x);
				try
				{
					return new FitnessValueChange<T>(x.Type, old, val);
				}
				finally
				{
					old = val.DeepClone();
				}
			});
		}

		protected abstract T Convert(IReadOnlyValueFacade facade, AnyFitnessValueChange change);
	}
	public interface IPausedTimeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObservePausedTimeChanges();

		int GetMostRecentPausedTime();

		Task<int> GetPausedTimeAsync();
	}
	[FacadeFitnessType(FitnessValue.PausedTime)]
	public class PausedTimeFacade : ReadOnlyValueFacade<int>, IPausedTimeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.PausedTime;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to PausedTime");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObservePausedTimeChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentPausedTime()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetPausedTimeAsync()
		{
			return await GetValueAsync();
		}

		public PausedTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IPauseTimeoutFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObservePauseTimeoutChanges();

		int GetMostRecentPauseTimeout();

		Task<int> GetPauseTimeoutAsync();

		void SetPauseTimeout(int pauseTimeout);

		Task<bool> SetPauseTimeoutAsync(int pauseTimeout);
	}
	[FacadeFitnessType(FitnessValue.PauseTimeout)]
	public class PauseTimeoutFacade : ReadWriteValueFacade<int>, IPauseTimeoutFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.PauseTimeout;

		public PauseTimeoutFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to PauseTimeout");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObservePauseTimeoutChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentPauseTimeout()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetPauseTimeoutAsync()
		{
			return await GetValueAsync();
		}

		public void SetPauseTimeout(int pauseTimeout)
		{
			SetValue(pauseTimeout);
		}

		public async Task<bool> SetPauseTimeoutAsync(int pauseTimeout)
		{
			return await SetValueAsync(pauseTimeout);
		}
	}
	public interface IPulseFacade : IReadOnlyValueFacade<Pulse>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<Pulse>> ObservePulseChanges();

		void SetPulse(Pulse pulse);

		Task<bool> SetPulseAsync(Pulse pulse);

		Pulse GetMostRecentPulse();

		Task<Pulse> GetPulseAsync();
	}
	[FacadeFitnessType(FitnessValue.Pulse)]
	public class PulseFacade : ReadWriteValueFacade<Pulse>, IPulseFacade, IReadOnlyValueFacade<Pulse>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Pulse;

		public PulseFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override Pulse Convert(object raw)
		{
			if (raw.IsNumber())
			{
				int num = System.Convert.ToInt32(raw);
				raw = new Pulse(num, num, 1, Pulse.Source.Hand);
			}
			return (raw as Pulse) ?? throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Pulse");
		}

		public IObservable<FitnessValueChange<Pulse>> ObservePulseChanges()
		{
			return ObserveChanges();
		}

		public void SetPulse(Pulse pulse)
		{
			SetValue(pulse);
		}

		public async Task<bool> SetPulseAsync(Pulse pulse)
		{
			return await SetValueAsync(pulse);
		}

		public Pulse GetMostRecentPulse()
		{
			return GetMostRecentValue();
		}

		public async Task<Pulse> GetPulseAsync()
		{
			return await GetValueAsync();
		}
	}
	public interface IReadOnlyValueFacade
	{
		FitnessValue Type { get; }
	}
	public interface IReadOnlyValueFacade<T> : IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<T>> ObserveChanges();

		T Convert(object raw);

		Task<T> GetValueAsync();

		T GetMostRecentValue();
	}
	public abstract class ReadOnlyValueFacade<T> : IReadOnlyValueFacade<T>, IReadOnlyValueFacade
	{
		protected readonly IFitnessConsoleManager fitnessConsoleManager;

		protected readonly SemaphoreSlim readWriteLock = new SemaphoreSlim(1, 1);

		public abstract FitnessValue Type { get; }

		protected virtual IFitnessConsole FitnessConsole => fitnessConsoleManager.CurrentConsole;

		protected ReadOnlyValueFacade(IFitnessConsoleManager fitnessConsoleManager)
		{
			this.fitnessConsoleManager = fitnessConsoleManager;
		}

		public IObservable<FitnessValueChange<T>> ObserveChanges()
		{
			try
			{
				readWriteLock.Wait();
				return from x in fitnessConsoleManager.ObserveValue(Type)
					select new FitnessValueChange<T>(Type, Convert(x.Old), Convert(x.Current));
			}
			finally
			{
				readWriteLock.Release();
			}
		}

		public async Task<T> GetValueAsync()
		{
			if (!CanRead())
			{
				return default(T);
			}
			try
			{
				await readWriteLock.WaitAsync();
				return Convert(await FitnessConsole.GetValueAsync(Type));
			}
			catch (Exception ex)
			{
				Log.Error(GetType().Name, "Exception msg: " + ex.Message);
				return default(T);
			}
			finally
			{
				readWriteLock.Release();
			}
		}

		public T GetMostRecentValue()
		{
			if (!CanRead())
			{
				return default(T);
			}
			try
			{
				readWriteLock.Wait();
				return Convert(FitnessConsole.GetMostRecentValue(Type));
			}
			catch (Exception ex)
			{
				Log.Error(GetType().Name, "Exception msg: " + ex.Message);
				return default(T);
			}
			finally
			{
				readWriteLock.Release();
			}
		}

		public abstract T Convert(object raw);

		private bool CanRead()
		{
			bool valueOrDefault = FitnessConsole?.ReadableTypes?.Contains(Type) == true;
			if (!valueOrDefault)
			{
				Log.Error(GetType().Name, "Unsupported read call to type " + Type);
			}
			return valueOrDefault;
		}
	}
	public abstract class ReadWriteValueFacade<T> : ReadOnlyValueFacade<T>
	{
		protected ReadWriteValueFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public bool CanWrite()
		{
			bool valueOrDefault = FitnessConsole?.WritableTypes?.Contains(Type) == true;
			if (!valueOrDefault)
			{
				Log.Error(GetType().Name, "Unsupported write call to type " + Type);
			}
			return valueOrDefault;
		}

		protected async Task<bool> SetValueAsync(T value)
		{
			if (!CanWrite())
			{
				return false;
			}
			try
			{
				await readWriteLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
				return await FitnessConsole.SetValueAsync(Type, value).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				Log.Error(GetType().Name, "Exception msg: " + ex.Message);
				return false;
			}
			finally
			{
				readWriteLock.Release();
			}
		}

		protected void SetValue(T value)
		{
			if (!CanWrite())
			{
				return;
			}
			try
			{
				readWriteLock.Wait();
				FitnessConsole.SetValue(Type, value);
			}
			catch (Exception ex)
			{
				Log.Error(GetType().Name, "Exception msg: " + ex.Message);
			}
			finally
			{
				readWriteLock.Release();
			}
		}
	}
	public interface IRequireStartRequestedFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveRequireStartRequestedChanges();

		bool GetMostRecentRequireStartRequested();

		Task<bool> GetRequireStartRequestedAsync();

		void SetRequireStartRequested(bool requireStartRequested);

		Task<bool> SetRequireStartRequestedAsync(bool requireStartRequested);
	}
	[FacadeFitnessType(FitnessValue.RequireStartRequested)]
	public class RequireStartRequestedFacade : ReadWriteValueFacade<bool>, IRequireStartRequestedFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.RequireStartRequested;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to RequireStartRequested");
		}

		public IObservable<FitnessValueChange<bool>> ObserveRequireStartRequestedChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentRequireStartRequested()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetRequireStartRequestedAsync()
		{
			return await GetValueAsync();
		}

		public void SetRequireStartRequested(bool requireStartRequested)
		{
			SetValue(requireStartRequested);
		}

		public async Task<bool> SetRequireStartRequestedAsync(bool requireStartRequested)
		{
			return await SetValueAsync(requireStartRequested);
		}

		public RequireStartRequestedFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IRpmFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveRpmChanges();

		int GetMostRecentRpm();

		Task<int> GetRpmAsync();

		void SetRpm(int rpm);

		Task SetRpmAsync(int rpm);
	}
	[FacadeFitnessType(FitnessValue.Rpm)]
	public class RpmFacade : ReadWriteValueFacade<int>, IRpmFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Rpm;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to current distance");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveRpmChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentRpm()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetRpmAsync()
		{
			return await GetValueAsync();
		}

		public void SetRpm(int rpm)
		{
			SetValue(rpm);
		}

		public async Task SetRpmAsync(int rpm)
		{
			await SetValueAsync(rpm);
		}

		public RpmFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IRunningTimeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveRunningTimeChanges();

		int GetMostRecentRunningTime();

		Task<int> GetRunningTimeAsync();
	}
	[FacadeFitnessType(FitnessValue.RunningTime)]
	public class RunningTimeFacade : ReadOnlyValueFacade<int>, IRunningTimeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.RunningTime;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to RunningTime");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveRunningTimeChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentRunningTime()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetRunningTimeAsync()
		{
			return await GetValueAsync();
		}

		public RunningTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ISleepTimerStateFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveSleepTimerStateChanges();

		bool GetMostRecentSleepTimerState();

		Task<bool> GetSleepTimerStateAsync();

		void SetSleepTimerState(bool sleepTimerState);

		Task<bool> SetSleepTimerStateAsync(bool sleepTimerState);
	}
	[FacadeFitnessType(FitnessValue.SleepTimerState)]
	public class SleepTimerStateFacade : ReadWriteValueFacade<bool>, ISleepTimerStateFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.SleepTimerState;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to SleepTimerState");
		}

		public IObservable<FitnessValueChange<bool>> ObserveSleepTimerStateChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentSleepTimerState()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetSleepTimerStateAsync()
		{
			return await GetValueAsync();
		}

		public void SetSleepTimerState(bool sleepTimerState)
		{
			SetValue(sleepTimerState);
		}

		public async Task<bool> SetSleepTimerStateAsync(bool sleepTimerState)
		{
			return await SetValueAsync(sleepTimerState);
		}

		public SleepTimerStateFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IStartRequestedFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveStartRequestedChanges();

		bool GetMostRecentStartRequested();

		Task<bool> GetStartRequestedAsync();
	}
	[FacadeFitnessType(FitnessValue.StartRequested)]
	public class StartRequestedFacade : ReadOnlyValueFacade<bool>, IStartRequestedFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.StartRequested;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to StartRequested");
		}

		public IObservable<FitnessValueChange<bool>> ObserveStartRequestedChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentStartRequested()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetStartRequestedAsync()
		{
			return await GetValueAsync();
		}

		public StartRequestedFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IStrokesFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveStrokesChanges();

		int GetMostRecentStrokes();

		Task<int> GetStrokesAsync();
	}
	[FacadeFitnessType(FitnessValue.Strokes)]
	public class StrokesFacade : ReadOnlyValueFacade<int>, IStrokesFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Strokes;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Strokes");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveStrokesChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentStrokes()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetStrokesAsync()
		{
			return await GetValueAsync();
		}

		public StrokesFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IStrokesPerMinFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveStrokesPerMinChanges();

		int GetMostRecentStrokesPerMin();

		Task<int> GetStrokesPerMinAsync();
	}
	[FacadeFitnessType(FitnessValue.StrokesPerMin)]
	public class StrokesPerMinFacade : ReadOnlyValueFacade<int>, IStrokesPerMinFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.StrokesPerMin;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to StrokesPerMin");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveStrokesPerMinChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentStrokesPerMin()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetStrokesPerMinAsync()
		{
			return await GetValueAsync();
		}

		public StrokesPerMinFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ISystemUnitsFacade : IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<bool>> ObserveSystemUnitsChanges();

		bool GetMostRecentSystemUnits();

		Task<bool> GetSystemUnitsAsync();

		void SetSystemUnits(bool systemUnits);

		Task<bool> SetSystemUnitsAsync(bool systemUnits);
	}
	[FacadeFitnessType(FitnessValue.SystemUnits)]
	public class SystemUnitsFacade : ReadWriteValueFacade<bool>, ISystemUnitsFacade, IReadOnlyValueFacade<bool>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.SystemUnits;

		public override bool Convert(object raw)
		{
			if (raw is bool)
			{
				return (bool)raw;
			}
			throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to SystemUnits");
		}

		public IObservable<FitnessValueChange<bool>> ObserveSystemUnitsChanges()
		{
			return ObserveChanges();
		}

		public bool GetMostRecentSystemUnits()
		{
			return GetMostRecentValue();
		}

		public async Task<bool> GetSystemUnitsAsync()
		{
			return await GetValueAsync();
		}

		public void SetSystemUnits(bool systemUnits)
		{
			SetValue(systemUnits);
		}

		public async Task<bool> SetSystemUnitsAsync(bool systemUnits)
		{
			return await SetValueAsync(systemUnits);
		}

		public SystemUnitsFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface ITotalTimeFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveTotalTimeChanges();

		double GetMostRecentTotalTime();

		Task<double> GetTotalTimeAsync();
	}
	[FacadeFitnessType(FitnessValue.TotalTime)]
	public class TotalTimeFacade : ReadOnlyValueFacade<double>, ITotalTimeFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.TotalTime;

		public override double Convert(object raw)
		{
			if (raw == null)
			{
				return 0.0;
			}
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to TotalTime");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveTotalTimeChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentTotalTime()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetTotalTimeAsync()
		{
			return await GetValueAsync();
		}

		public TotalTimeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IVerticalMeterGainFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveVerticalMeterGainChanges();

		double GetMostRecentVerticalMeterGain();

		Task<double> GetVerticalMeterGainAsync();
	}
	[FacadeFitnessType(FitnessValue.VerticalMeterGain)]
	public class VerticalMeterGainFacade : ReadOnlyValueFacade<double>, IVerticalMeterGainFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.VerticalMeterGain;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to VerticalMeterGain");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveVerticalMeterGainChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentVerticalMeterGain()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetVerticalMeterGainAsync()
		{
			return await GetValueAsync();
		}

		public VerticalMeterGainFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IVerticalMeterNetFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveVerticalMeterNetChanges();

		double GetMostRecentVerticalMeterNet();

		Task<double> GetVerticalMeterNetAsync();
	}
	[FacadeFitnessType(FitnessValue.VerticalMeterNet)]
	public class VerticalMeterNetFacade : ReadOnlyValueFacade<double>, IVerticalMeterNetFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.VerticalMeterNet;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to VerticalMeterNet");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveVerticalMeterNetChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentVerticalMeterNet()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetVerticalMeterNetAsync()
		{
			return await GetValueAsync();
		}

		public VerticalMeterNetFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IVolumeFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveVolumeChanges();

		void SetVolume(int volume);

		Task<bool> SetVolumeAsync(int volume);

		int GetMostRecentVolume();

		Task<int> GetVolumeAsync();

		bool CanWrite();
	}
	[FacadeFitnessType(FitnessValue.Volume)]
	public class VolumeFacade : ReadWriteValueFacade<int>, IVolumeFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		protected IDisposable physicalConsoleVolumeSub;

		public override FitnessValue Type => FitnessValue.Volume;

		protected override IFitnessConsole FitnessConsole
		{
			get
			{
				if (fitnessConsoleManager.CurrentConsole == fitnessConsoleManager.PhysicalConsole)
				{
					return base.FitnessConsole;
				}
				return fitnessConsoleManager.PhysicalConsole;
			}
		}

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to volume");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveVolumeChanges()
		{
			physicalConsoleVolumeSub?.Dispose();
			physicalConsoleVolumeSub = null;
			if (fitnessConsoleManager.CurrentConsole != fitnessConsoleManager.PhysicalConsole)
			{
				physicalConsoleVolumeSub = fitnessConsoleManager.PhysicalConsole?.ObserveValue(FitnessValue.Volume)?.Subscribe(fitnessConsoleManager.WhenFitnessValueChanged.OnNext);
			}
			return ObserveChanges();
		}

		public void SetVolume(int volume)
		{
			SetValue(volume);
		}

		public async Task<bool> SetVolumeAsync(int volume)
		{
			return await SetValueAsync(volume).ConfigureAwait(continueOnCapturedContext: false);
		}

		public int GetMostRecentVolume()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetVolumeAsync()
		{
			return await GetValueAsync();
		}

		public VolumeFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IWarmupTimeoutFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveWarmupTimeoutChanges();

		int GetMostRecentWarmupTimeout();

		Task<int> GetWarmupTimeoutAsync();

		void SetWarmupTimeout(int warmupTimeout);

		Task<bool> SetWarmupTimeoutAsync(int warmupTimeout);
	}
	[FacadeFitnessType(FitnessValue.WarmupTimeout)]
	public class WarmupTimeoutFacade : ReadWriteValueFacade<int>, IWarmupTimeoutFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.WarmupTimeout;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to WarmupTimeout");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveWarmupTimeoutChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentWarmupTimeout()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetWarmupTimeoutAsync()
		{
			return await GetValueAsync();
		}

		public void SetWarmupTimeout(int warmupTimeout)
		{
			SetValue(warmupTimeout);
		}

		public async Task<bool> SetWarmupTimeoutAsync(int warmupTimeout)
		{
			return await SetValueAsync(warmupTimeout);
		}

		public WarmupTimeoutFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IWattGoalFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveWattGoalChanges();

		int GetMostRecentWattGoal();

		Task<int> GetWattGoalAsync();

		void SetWattGoal(int wattGoal);

		Task<bool> SetWattGoalAsync(int wattGoal);
	}
	[FacadeFitnessType(FitnessValue.WattGoal)]
	public class WattGoalFacade : ReadWriteValueFacade<int>, IWattGoalFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.WattGoal;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to WattGoal");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveWattGoalChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentWattGoal()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetWattGoalAsync()
		{
			return await GetValueAsync();
		}

		public void SetWattGoal(int wattGoal)
		{
			SetValue(wattGoal);
		}

		public async Task<bool> SetWattGoalAsync(int wattGoal)
		{
			return await SetValueAsync(wattGoal);
		}

		public WattGoalFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IWattsFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveWattChanges();

		int GetMostRecentWatts();

		Task<int> GetWattsAsync();
	}
	[FacadeFitnessType(FitnessValue.Watts)]
	public class WattsFacade : ReadOnlyValueFacade<int>, IWattsFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Watts;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to watts");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveWattChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentWatts()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetWattsAsync()
		{
			return await GetValueAsync();
		}

		public WattsFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IWeightFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveWeightChanges();

		double GetMostRecentWeight();

		Task<double> GetWeightAsync();

		void SetWeight(double weight);

		Task<bool> SetWeightAsync(double weight);
	}
	[FacadeFitnessType(FitnessValue.Weight)]
	public class WeightFacade : ReadWriteValueFacade<double>, IWeightFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Weight;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to Weight");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveWeightChanges()
		{
			return ObserveChanges();
		}

		public double GetMostRecentWeight()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetWeightAsync()
		{
			return await GetValueAsync();
		}

		public void SetWeight(double weight)
		{
			SetValue(weight);
		}

		public async Task<bool> SetWeightAsync(double weight)
		{
			return await SetValueAsync(weight);
		}

		public WeightFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IWorkoutFacade
	{
		Task SetPreWorkoutInfoAsync(bool isMetric, double userWeightKgs, int targetValue, WorkoutGoal goalType, int warmUpTimeoutSeconds, int coolDownTimeoutSeconds, int pauseTimeoutSeconds);

		void PauseWorkout();

		void ResumeWorkout();

		Task EndWorkoutAsync();

		Task<bool> StartWarmUpAsync(double initialKph, double initialIncline, double initialResistance, int initialGear);

		Task<bool> StartWorkoutAsync(double initialKph, double initialIncline, double initialResistance, int initialGear, bool isWorkoutAlreadyStarted = false);

		Task<bool> StartCoolDownAsync(double initialKph, double initialIncline, double initialResistance, int initialGear);
	}
	public class WorkoutFacade : IWorkoutFacade
	{
		private readonly IFitnessConsoleManager fitnessConsoleManager;

		private IFitnessConsole Console => fitnessConsoleManager.CurrentConsole;

		public WorkoutFacade(IFitnessConsoleManager fitnessConsoleManager)
		{
			this.fitnessConsoleManager = fitnessConsoleManager;
		}

		public async Task SetPreWorkoutInfoAsync(bool isMetric, double userWeightKgs, int targetValue, WorkoutGoal goalType, int warmUpTimeoutSeconds, int coolDownTimeoutSeconds, int pauseTimeoutSeconds)
		{
			if (Console != null)
			{
				FitnessValue item = ((goalType == WorkoutGoal.Meters) ? FitnessValue.DistanceGoal : FitnessValue.GoalTime);
				await Console.SetValuesAsync((FitnessValue.SystemUnits, isMetric), (FitnessValue.Weight, userWeightKgs), (FitnessValue.WarmupTimeout, warmUpTimeoutSeconds), (FitnessValue.CoolDownTimeout, coolDownTimeoutSeconds), (FitnessValue.PauseTimeout, pauseTimeoutSeconds), (item, targetValue));
			}
		}

		public void PauseWorkout()
		{
			Console?.SetValue(FitnessValue.WorkoutMode, ConsoleState.Paused);
		}

		public void ResumeWorkout()
		{
			if (Console != null)
			{
				Console.PauseOverrideEnabled = true;
				Console.SetValue(FitnessValue.WorkoutMode, ConsoleState.Resume);
			}
		}

		public async Task EndWorkoutAsync()
		{
			if (Console != null)
			{
				await Console.SetValueAsync(FitnessValue.WorkoutMode, ConsoleState.WorkoutResults);
			}
		}

		public async Task<bool> StartWarmUpAsync(double initialKph, double initialIncline, double initialResistance, int initialGear)
		{
			if (Console == null)
			{
				return false;
			}
			return await Console.SetValuesAsync((FitnessValue.WorkoutMode, ConsoleState.WarmUp), (FitnessValue.Kph, initialKph), (FitnessValue.Grade, initialIncline), (FitnessValue.Resistance, initialResistance), (FitnessValue.Gear, new Gear(initialGear, 0, Console.ConsoleInfo.MaxGear))).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<bool> StartWorkoutAsync(double initialKph, double initialIncline, double initialResistance, int initialGear, bool isWorkoutAlreadyStarted = false)
		{
			if (Console == null)
			{
				return false;
			}
			List<(FitnessValue, object)> list = new List<(FitnessValue, object)>
			{
				(FitnessValue.Kph, initialKph),
				(FitnessValue.Grade, initialIncline),
				(FitnessValue.Resistance, initialResistance),
				(FitnessValue.Gear, new Gear(initialGear, 0, Console.ConsoleInfo.MaxGear))
			};
			if (!isWorkoutAlreadyStarted)
			{
				list.Insert(0, (FitnessValue.WorkoutMode, ConsoleState.Workout));
			}
			return await Console.SetValuesAsync(list.ToArray());
		}

		public async Task<bool> StartCoolDownAsync(double initialKph, double initialIncline, double initialResistance, int initialGear)
		{
			if (Console == null)
			{
				return false;
			}
			return await Console.SetValuesAsync((FitnessValue.WorkoutMode, ConsoleState.CoolDown), (FitnessValue.Kph, initialKph), (FitnessValue.Grade, initialIncline), (FitnessValue.Resistance, initialResistance), (FitnessValue.Gear, new Gear(initialGear, 0, Console.ConsoleInfo.MaxGear)));
		}
	}
}
namespace Sindarin.Core.Facades.Speed
{
	public interface IActualKphFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveActualKphChanges();

		IObservable<FitnessValueChange<double>> ObserveActualMphChanges();

		IObservable<FitnessValueChange<double>> ObserveActualMpsChanges();

		double GetMostRecentActualKph();

		double GetMostRecentActualMph();

		Task<double> GetActualKphAsync();

		Task<double> GetActualMphAsync();
	}
	[FacadeFitnessType(FitnessValue.ActualKph)]
	public class ActualKphFacade : ReadOnlyValueFacade<double>, IActualKphFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.ActualKph;

		public ActualKphFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to ActualKph");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveActualKphChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveActualMphChanges()
		{
			return from x in ObserveActualKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMph(), x.Current.KphToMph());
		}

		public IObservable<FitnessValueChange<double>> ObserveActualMpsChanges()
		{
			return from x in ObserveActualKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMps(), x.Current.KphToMps());
		}

		public double GetMostRecentActualKph()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentActualMph()
		{
			return GetMostRecentActualKph().KphToMph();
		}

		public async Task<double> GetActualKphAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetActualMphAsync()
		{
			return (await GetActualKphAsync()).KphToMph();
		}
	}
	public interface IAvgSpeedFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveAvgKphChanges();

		IObservable<FitnessValueChange<double>> ObserveAvgMphChanges();

		IObservable<FitnessValueChange<double>> ObserveAvgMpsChanges();

		double GetMostRecentAvgKph();

		double GetMostRecentAvgMpg();

		Task<double> GetAvgKphAsync();

		Task<double> GetAvgMphAsync();
	}
	[FacadeFitnessType(FitnessValue.AvgSpeedKph)]
	public class AvgSpeedFacade : ReadOnlyValueFacade<double>, IAvgSpeedFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.AvgSpeedKph;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to avg speed");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveAvgKphChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveAvgMphChanges()
		{
			return from x in ObserveAvgKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMph(), x.Current.KphToMph());
		}

		public IObservable<FitnessValueChange<double>> ObserveAvgMpsChanges()
		{
			return from x in ObserveAvgKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMps(), x.Current.KphToMps());
		}

		public double GetMostRecentAvgKph()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentAvgMpg()
		{
			return GetMostRecentAvgKph().KphToMph();
		}

		public async Task<double> GetAvgKphAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetAvgMphAsync()
		{
			return (await GetAvgKphAsync()).KphToMph();
		}

		public AvgSpeedFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IKphFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveKphChanges();

		IObservable<FitnessValueChange<double>> ObserveMphChanges();

		IObservable<FitnessValueChange<double>> ObserveMpsChanges();

		void SetKph(double kph);

		void SetMph(double mph);

		void SetMps(double mps);

		Task<bool> SetKphAsync(double kph);

		Task<bool> SetMphAsync(double mph);

		Task<bool> SetMpsAsync(double mps);

		double GetMostRecentKph();

		double GetMostRecentMph();

		double GetMostRecentMps();

		Task<double> GetKphAsync();

		Task<double> GetMphAsync();

		Task<double> GetMpsAsync();
	}
	[FacadeFitnessType(FitnessValue.Kph)]
	public class KphFacade : ReadWriteValueFacade<double>, IKphFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Kph;

		public KphFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to speed");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveKphChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveMphChanges()
		{
			return from x in ObserveKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMph(), x.Current.KphToMph());
		}

		public IObservable<FitnessValueChange<double>> ObserveMpsChanges()
		{
			return from x in ObserveKphChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.KphToMps(), x.Current.KphToMps());
		}

		public void SetKph(double kph)
		{
			SetValue(kph);
		}

		public void SetMph(double mph)
		{
			SetKph(mph.MphToKph());
		}

		public void SetMps(double mps)
		{
			SetKph(mps.MpsToKph());
		}

		public async Task<bool> SetKphAsync(double kph)
		{
			return await SetValueAsync(kph);
		}

		public async Task<bool> SetMphAsync(double mph)
		{
			return await SetKphAsync(mph.MphToKph());
		}

		public async Task<bool> SetMpsAsync(double mps)
		{
			return await SetKphAsync(mps.MpsToKph());
		}

		public double GetMostRecentKph()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentMph()
		{
			return GetMostRecentKph().KphToMph();
		}

		public double GetMostRecentMps()
		{
			return GetMostRecentKph().KphToMps();
		}

		public async Task<double> GetKphAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetMphAsync()
		{
			return (await GetKphAsync()).KphToMph();
		}

		public async Task<double> GetMpsAsync()
		{
			return (await GetKphAsync()).KphToMps();
		}
	}
	public interface IMaxKphFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMaxKphChanges();

		IObservable<FitnessValueChange<double>> ObserveMaxMphChanges();

		IObservable<FitnessValueChange<double>> ObserveMaxMpsChanges();

		double GetMostRecentMaxKph();

		double GetMostRecentMaxMph();

		double GetMostRecentMaxMps();

		Task<double> GetMaxKphAsync();

		Task<double> GetMaxMphAsync();

		Task<double> GetMaxMpsAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxKph)]
	public class MaxKphFacade : ReadOnlyValueFacade<double>, IMaxKphFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxKph;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxKph");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxKphChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxMphChanges()
		{
			return from x in ObserveMaxKphChanges()
				select new FitnessValueChange<double>(Type, x.Old.KphToMph(), x.Current.KphToMph());
		}

		public IObservable<FitnessValueChange<double>> ObserveMaxMpsChanges()
		{
			return from x in ObserveMaxKphChanges()
				select new FitnessValueChange<double>(Type, x.Old.KphToMps(), x.Current.KphToMps());
		}

		public double GetMostRecentMaxKph()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentMaxMph()
		{
			return GetMostRecentMaxKph().KphToMph();
		}

		public double GetMostRecentMaxMps()
		{
			return GetMostRecentMaxKph().KphToMps();
		}

		public async Task<double> GetMaxKphAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetMaxMphAsync()
		{
			return (await GetMaxKphAsync()).KphToMph();
		}

		public async Task<double> GetMaxMpsAsync()
		{
			return (await GetMaxKphAsync()).KphToMps();
		}

		public MaxKphFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IMinKphFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMinKphChanges();

		IObservable<FitnessValueChange<double>> ObserveMinMphChanges();

		IObservable<FitnessValueChange<double>> ObserveMinMpsChanges();

		double GetMostRecentMinKph();

		double GetMostRecentMinMph();

		double GetMostRecentMinMps();

		Task<double> GetMinKphAsync();

		Task<double> GetMinMphAsync();

		Task<double> GetMinMpsAsync();
	}
	[FacadeFitnessType(FitnessValue.MinKph)]
	public class MinKphFacade : ReadOnlyValueFacade<double>, IMinKphFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MinKph;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MinKph");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMinKphChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveMinMphChanges()
		{
			return from x in ObserveMinKphChanges()
				select new FitnessValueChange<double>(Type, x.Old.KphToMph(), x.Current.KphToMph());
		}

		public IObservable<FitnessValueChange<double>> ObserveMinMpsChanges()
		{
			return from x in ObserveMinKphChanges()
				select new FitnessValueChange<double>(Type, x.Old.KphToMps(), x.Current.KphToMps());
		}

		public double GetMostRecentMinKph()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentMinMph()
		{
			return GetMostRecentMinKph().KphToMph();
		}

		public double GetMostRecentMinMps()
		{
			return GetMostRecentMinKph().KphToMps();
		}

		public async Task<double> GetMinKphAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetMinMphAsync()
		{
			return (await GetMinKphAsync()).KphToMph();
		}

		public async Task<double> GetMinMpsAsync()
		{
			return (await GetMinKphAsync()).KphToMps();
		}

		public MinKphFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	internal static class SpeedExtensions
	{
		internal static double MphToKph(this double mph)
		{
			return UnitUtil.EnsureKph(SpeedUnit.Mph, mph);
		}

		internal static double KphToMph(this double kph)
		{
			return UnitUtil.EnsureMph(SpeedUnit.Kph, kph);
		}

		internal static double MpsToKph(this double mps)
		{
			return UnitUtil.EnsureKph(SpeedUnit.Mps, mps);
		}

		internal static double KphToMps(this double kph)
		{
			return UnitUtil.EnsureMps(SpeedUnit.Kph, kph);
		}
	}
}
namespace Sindarin.Core.Facades.Resistance
{
	public interface IMaxResistanceLevelFacade : IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<int>> ObserveMaxResistanceLevelChanges();

		int GetMostRecentMaxResistanceLevel();

		Task<int> GetMaxResistanceLevelAsync();
	}
	[FacadeFitnessType(FitnessValue.MaxResistanceLevel)]
	public class MaxResistanceLevelFacade : ReadOnlyValueFacade<int>, IMaxResistanceLevelFacade, IReadOnlyValueFacade<int>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.MaxResistanceLevel;

		public override int Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to MaxResistanceLevel");
			}
			return System.Convert.ToInt32(raw);
		}

		public IObservable<FitnessValueChange<int>> ObserveMaxResistanceLevelChanges()
		{
			return ObserveChanges();
		}

		public int GetMostRecentMaxResistanceLevel()
		{
			return GetMostRecentValue();
		}

		public async Task<int> GetMaxResistanceLevelAsync()
		{
			return await GetValueAsync();
		}

		public MaxResistanceLevelFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	public interface IResistanceFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveResistanceChanges();

		void SetResistance(double resistance);

		Task<bool> SetResistanceAsync(double resistance);

		double GetMostRecentResistance();

		Task<double> GetResistanceAsync();
	}
	[FacadeFitnessType(FitnessValue.Resistance)]
	public class ResistanceFacade : ReadWriteValueFacade<double>, IResistanceFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.Resistance;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to resistance");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveResistanceChanges()
		{
			return ObserveChanges();
		}

		public void SetResistance(double resistance)
		{
			SetValue(resistance);
		}

		public async Task<bool> SetResistanceAsync(double resistance)
		{
			return await SetValueAsync(resistance);
		}

		public double GetMostRecentResistance()
		{
			return GetMostRecentValue();
		}

		public async Task<double> GetResistanceAsync()
		{
			return await GetValueAsync();
		}

		public ResistanceFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
}
namespace Sindarin.Core.Facades.Distance
{
	public interface ICurrentDistanceFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveMeterChanges();

		IObservable<FitnessValueChange<double>> ObserveMileChanges();

		double GetMostRecentKm();

		double GetMostRecentMile();

		Task<double> GetKmAsync();

		Task<double> GetMileAsync();
	}
	[FacadeFitnessType(FitnessValue.CurrentDistance)]
	public class CurrentDistanceFacade : ReadOnlyValueFacade<double>, ICurrentDistanceFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.CurrentDistance;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to current distance");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveMeterChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveMileChanges()
		{
			return from x in ObserveMeterChanges()
				select new FitnessValueChange<double>(x.Type, x.Old.MetersToMiles(), x.Current.MetersToMiles());
		}

		public double GetMostRecentKm()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentMile()
		{
			return GetMostRecentKm().MetersToMiles();
		}

		public async Task<double> GetKmAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetMileAsync()
		{
			return (await GetKmAsync()).MetersToMiles();
		}

		public CurrentDistanceFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
	internal static class DistanceExtensions
	{
		internal static double MetersToKm(this double meters)
		{
			return UnitUtil.EnsureKilometers(DistanceUnit.M, meters);
		}

		internal static double MetersToMiles(this double meters)
		{
			return UnitUtil.EnsureMiles(DistanceUnit.M, meters);
		}

		internal static double MilesToMeters(this double miles)
		{
			return UnitUtil.EnsureMeters(DistanceUnit.Mi, miles);
		}

		internal static double KmToMeters(this double km)
		{
			return UnitUtil.EnsureMeters(DistanceUnit.Km, km);
		}
	}
	public interface IDistanceGoalFacade : IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		IObservable<FitnessValueChange<double>> ObserveDistanceGoalMeterChanges();

		IObservable<FitnessValueChange<double>> ObserveDistanceGoalMileChanges();

		IObservable<FitnessValueChange<double>> ObserveDistanceGoalKmChanges();

		double GetMostRecentDistanceMeterGoal();

		double GetMostRecentDistanceMileGoal();

		double GetMostRecentDistanceKmGoal();

		Task<double> GetDistanceGoalMeterAsync();

		Task<double> GetDistanceGoalMileAsync();

		Task<double> GetDistanceGoalKmAsync();

		void SetDistanceGoalMeter(double distanceGoal);

		void SetDistanceGoalMile(double distanceGoal);

		void SetDistanceGoalKm(double distanceGoal);

		Task<bool> SetDistanceGoalMeterAsync(double distanceGoal);

		Task<bool> SetDistanceGoalMileAsync(double distanceGoal);

		Task<bool> SetDistanceGoalKmAsync(double distanceGoal);
	}
	[FacadeFitnessType(FitnessValue.DistanceGoal)]
	public class DistanceGoalFacade : ReadWriteValueFacade<double>, IDistanceGoalFacade, IReadOnlyValueFacade<double>, IReadOnlyValueFacade
	{
		public override FitnessValue Type => FitnessValue.DistanceGoal;

		public override double Convert(object raw)
		{
			if (!raw.IsNumber())
			{
				throw new ArgumentException($"Cannot convert value {raw} with type {raw.GetType()} to DistanceGoal");
			}
			return System.Convert.ToDouble(raw);
		}

		public IObservable<FitnessValueChange<double>> ObserveDistanceGoalMeterChanges()
		{
			return ObserveChanges();
		}

		public IObservable<FitnessValueChange<double>> ObserveDistanceGoalMileChanges()
		{
			return from x in ObserveDistanceGoalMeterChanges()
				select new FitnessValueChange<double>(Type, x.Old.MetersToMiles(), x.Current.MetersToMiles());
		}

		public IObservable<FitnessValueChange<double>> ObserveDistanceGoalKmChanges()
		{
			return from x in ObserveDistanceGoalMeterChanges()
				select new FitnessValueChange<double>(Type, x.Old.MetersToKm(), x.Current.MetersToKm());
		}

		public double GetMostRecentDistanceMeterGoal()
		{
			return GetMostRecentValue();
		}

		public double GetMostRecentDistanceMileGoal()
		{
			return GetMostRecentDistanceMeterGoal().MetersToMiles();
		}

		public double GetMostRecentDistanceKmGoal()
		{
			return GetMostRecentDistanceMeterGoal().MetersToKm();
		}

		public async Task<double> GetDistanceGoalMeterAsync()
		{
			return await GetValueAsync();
		}

		public async Task<double> GetDistanceGoalMileAsync()
		{
			return (await GetDistanceGoalMeterAsync()).MetersToMiles();
		}

		public async Task<double> GetDistanceGoalKmAsync()
		{
			return (await GetDistanceGoalMeterAsync()).MetersToKm();
		}

		public void SetDistanceGoalMeter(double distanceGoal)
		{
			SetValue(distanceGoal);
		}

		public void SetDistanceGoalMile(double distanceGoal)
		{
			SetDistanceGoalMeter(distanceGoal.MilesToMeters());
		}

		public void SetDistanceGoalKm(double distanceGoal)
		{
			SetDistanceGoalMeter(distanceGoal.KmToMeters());
		}

		public async Task<bool> SetDistanceGoalMeterAsync(double distanceGoal)
		{
			return await SetValueAsync(distanceGoal);
		}

		public async Task<bool> SetDistanceGoalMileAsync(double distanceGoal)
		{
			return await SetDistanceGoalMeterAsync(distanceGoal.MilesToMeters());
		}

		public async Task<bool> SetDistanceGoalKmAsync(double distanceGoal)
		{
			return await SetDistanceGoalMeterAsync(distanceGoal.KmToMeters());
		}

		public DistanceGoalFacade(IFitnessConsoleManager fitnessConsoleManager)
			: base(fitnessConsoleManager)
		{
		}
	}
}
namespace Sindarin.Core.DataObjects
{
	public enum ActivationLockState
	{
		Unlocked,
		Locked,
		Unknown
	}
	public class AudioSource
	{
		public enum Source
		{
			None,
			PC,
			Brainboard,
			Mp3,
			Ipod,
			TV,
			FM
		}

		public Source Current { get; }

		public List<Source> Available { get; }

		public AudioSource(Source current, List<Source> available)
		{
			Current = current;
			Available = available;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return Current == ((AudioSource)obj).Current;
		}

		public override int GetHashCode()
		{
			return (int)Current;
		}
	}
	public enum BuiltInType
	{
		NA,
		Argon,
		BCM,
		Classic,
		MTKArgon,
		SamsungArgon
	}
	public static class BuiltInTypeExtensions
	{
		public static string ToFriendlyString(this BuiltInType type)
		{
			return type switch
			{
				BuiltInType.NA => "Not Available", 
				BuiltInType.MTKArgon => "Argon - MTK", 
				BuiltInType.SamsungArgon => "Argon - Samsung", 
				_ => type.ToString(), 
			};
		}
	}
	public enum CalibrateInclineState
	{
		Done,
		Failed,
		InProgress
	}
	public enum FanState
	{
		Off,
		Low,
		Medium,
		High,
		Auto,
		Unknown
	}
	public class Gear
	{
		public int CurrentGear { get; }

		public int GearOption { get; }

		public int MaxGear { get; }

		public Gear(int currentGear, int gearOption, int maxGear)
		{
			CurrentGear = currentGear;
			GearOption = gearOption;
			MaxGear = maxGear;
		}

		public Gear(int currentGear)
		{
			CurrentGear = currentGear;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (!(obj is Gear gear))
			{
				return false;
			}
			if (gear.CurrentGear == CurrentGear && gear.GearOption == GearOption)
			{
				return gear.MaxGear == MaxGear;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return $"[Gear: CurrentGear={CurrentGear}, GearOption={GearOption}, MaxGear={MaxGear}]";
		}
	}
	public interface IMarkdown
	{
		string Markdown();
	}
	public class Interval
	{
		public double Recovery { get; set; }

		public double Work { get; set; }

		public Interval(double recovery, double work)
		{
			Recovery = recovery;
			Work = work;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			if (Recovery == ((Interval)obj).Recovery)
			{
				return Work == ((Interval)obj).Work;
			}
			return false;
		}
	}
	public enum KeyCode
	{
		NoKey = 0,
		Stop = 1,
		Start = 2,
		SpeedUp = 3,
		SpeedDown = 4,
		InclineUp = 5,
		InclineDown = 6,
		ResistanceUp = 7,
		ResistanceDown = 8,
		GearUp = 9,
		GearDown = 10,
		WeightUp = 11,
		WeightDown = 12,
		AgeUp = 13,
		AgeDown = 14,
		SpeedResume = 15,
		GradeResume = 16,
		BleKey = 17,
		OnReset = 18,
		PriorityDisplay = 19,
		BurnrateUp = 20,
		BurnrateDown = 21,
		Recovery = 22,
		Work = 23,
		StartStop = 24,
		PowerOnoff = 25,
		FanUp = 50,
		FanDown = 51,
		FanOff = 52,
		FanManual = 53,
		FanAuto = 54,
		Fan1 = 55,
		Fan2 = 56,
		Fan3 = 57,
		Fan4 = 58,
		Fan5 = 59,
		PcBack = 100,
		PcMenu = 101,
		PcHome = 102,
		Keypad = 103,
		Display = 104,
		Enter = 105,
		Up = 106,
		Down = 107,
		Left = 108,
		Right = 109,
		TvPower = 120,
		TvChannelUp = 121,
		TvChannelDown = 122,
		TvRecall = 123,
		TvMenu = 124,
		TvSource = 125,
		TvSeek = 126,
		TvCloseCaption = 127,
		TvVolumeUp = 128,
		TvVolumeDown = 129,
		TvMute = 130,
		RightGearUp = 150,
		RightGearDown = 151,
		LeftGearUp = 152,
		LeftGearDown = 153,
		AudioVolumeUp = 200,
		AudioVolumeDown = 201,
		AudioMute = 202,
		AudioEqualizer = 203,
		AudioSource = 204,
		NumberPad0 = 300,
		NumberPad1 = 301,
		NumberPad2 = 302,
		NumberPad3 = 303,
		NumberPad4 = 304,
		NumberPad5 = 305,
		NumberPad6 = 306,
		NumberPad7 = 307,
		NumberPad8 = 308,
		NumberPad9 = 309,
		NumberPadStar = 310,
		NumberPadDot = 311,
		NumberPadHash = 312,
		NumberPadOk = 313,
		NumberPadEnter = 314,
		ErgofitTiltForward = 400,
		ErgofitTiltBack = 401,
		ErgofitUprightUp = 402,
		ErgofitUprightDown = 403,
		ErgofitMemory = 404,
		ErgofitUser1 = 405,
		ErgofitUser2 = 406,
		ErgofitUser3 = 407,
		ErgofitUser4 = 408,
		SetToShip = 500,
		DebugMode = 501,
		LogMode = 502,
		Settings = 503,
		GradeDisplay = 600,
		PulseDisplay = 601,
		WattsDisplay = 602,
		SpeedDisplay = 603,
		TimeDisplay = 604,
		PaceDisplay = 605,
		CaloriesDisplay = 606,
		DistanceDisplay = 607,
		ScanDisplay = 608,
		Mph1 = 1000,
		Mph2 = 1001,
		Mph3 = 1002,
		Mph4 = 1003,
		Mph5 = 1004,
		Mph6 = 1005,
		Mph7 = 1006,
		Mph8 = 1007,
		Mph9 = 1008,
		Mph10 = 1009,
		Mph11 = 1010,
		Mph12 = 1011,
		Mph13 = 1012,
		Mph14 = 1013,
		Mph15 = 1014,
		Kph1 = 1100,
		Kph2 = 1101,
		Kph3 = 1102,
		Kph4 = 1103,
		Kph5 = 1104,
		Kph6 = 1105,
		Kph7 = 1106,
		Kph8 = 1107,
		Kph9 = 1108,
		Kph10 = 1109,
		Kph11 = 1110,
		Kph12 = 1111,
		Kph13 = 1112,
		Kph14 = 1113,
		Kph15 = 1114,
		Kph16 = 1115,
		Kph17 = 1116,
		Kph18 = 1117,
		Kph19 = 1118,
		Kph20 = 1119,
		Kph21 = 1120,
		Kph22 = 1121,
		Kph23 = 1122,
		Kph24 = 1123,
		InclineNeg30 = 1200,
		InclineNeg29 = 1201,
		InclineNeg28 = 1202,
		InclineNeg27 = 1203,
		InclineNeg26 = 1204,
		InclineNeg25 = 1205,
		InclineNeg24 = 1206,
		InclineNeg23 = 1207,
		InclineNeg22 = 1208,
		InclineNeg21 = 1209,
		InclineNeg20 = 1210,
		InclineNeg19 = 1211,
		InclineNeg18 = 1212,
		InclineNeg17 = 1213,
		InclineNeg16 = 1214,
		InclineNeg15 = 1215,
		InclineNeg14 = 1216,
		InclineNeg13 = 1217,
		InclineNeg12 = 1218,
		InclineNeg11 = 1219,
		InclineNeg10 = 1220,
		InclineNeg9 = 1221,
		InclineNeg8 = 1222,
		InclineNeg7 = 1223,
		InclineNeg6 = 1224,
		InclineNeg5 = 1225,
		InclineNeg4 = 1226,
		InclineNeg3 = 1227,
		InclineNeg2 = 1228,
		InclineNeg1 = 1229,
		Incline0 = 1230,
		Incline1 = 1231,
		Incline2 = 1232,
		Incline3 = 1233,
		Incline4 = 1234,
		Incline5 = 1235,
		Incline6 = 1236,
		Incline7 = 1237,
		Incline8 = 1238,
		Incline9 = 1239,
		Incline10 = 1240,
		Incline11 = 1241,
		Incline12 = 1242,
		Incline13 = 1243,
		Incline14 = 1244,
		Incline15 = 1245,
		Incline16 = 1246,
		Incline17 = 1247,
		Incline18 = 1248,
		Incline19 = 1249,
		Incline20 = 1250,
		Incline21 = 1251,
		Incline22 = 1252,
		Incline23 = 1253,
		Incline24 = 1254,
		Incline25 = 1255,
		Incline26 = 1256,
		Incline27 = 1257,
		Incline28 = 1258,
		Incline29 = 1259,
		Incline30 = 1260,
		Incline31 = 1261,
		Incline32 = 1262,
		Incline33 = 1263,
		Incline34 = 1264,
		Incline35 = 1265,
		Incline36 = 1266,
		Incline37 = 1267,
		Incline38 = 1268,
		Incline39 = 1269,
		Incline40 = 1270,
		Incline41 = 1271,
		Incline42 = 1272,
		Incline43 = 1273,
		Incline44 = 1274,
		Incline45 = 1275,
		Incline46 = 1276,
		Incline47 = 1277,
		Incline48 = 1278,
		Incline49 = 1279,
		Incline50 = 1280,
		Resistance0 = 1300,
		Resistance1 = 1301,
		Resistance2 = 1302,
		Resistance3 = 1303,
		Resistance4 = 1304,
		Resistance5 = 1305,
		Resistance6 = 1306,
		Resistance7 = 1307,
		Resistance8 = 1308,
		Resistance9 = 1309,
		Resistance10 = 1310,
		Resistance11 = 1311,
		Resistance12 = 1312,
		Resistance13 = 1313,
		Resistance14 = 1314,
		Resistance15 = 1315,
		Resistance16 = 1316,
		Resistance17 = 1317,
		Resistance18 = 1318,
		Resistance19 = 1319,
		Resistance20 = 1320,
		Resistance21 = 1321,
		Resistance22 = 1322,
		Resistance23 = 1323,
		Resistance24 = 1324,
		Resistance25 = 1325,
		Resistance26 = 1326,
		Resistance27 = 1327,
		Resistance28 = 1328,
		Resistance29 = 1329,
		Resistance30 = 1330,
		ManualWorkout = 11000,
		MapWorkout = 11001,
		TrainWorkout = 11002,
		CompeteWOrkout = 11003,
		TrackWorkout = 11004,
		SetAGoalWorkout = 11005,
		VideoWorkout = 11006,
		LoseWtWorkout = 11007,
		CaloriesWorkout = 11008,
		IntensityWorkout = 11009,
		InclineWorkout = 11010,
		SpeedWorkout = 11011,
		PulseWorkout = 11012,
		PerformanceWOrkout = 11013,
		DayWorkout = 11014,
		WeekWorkout = 11015,
		MonthWorkout = 11016,
		IntervalWorkout = 11017,
		TempWorkout = 11018,
		DummyWorkout1 = 11100,
		DummyWorkout2 = 11101,
		DummyWorkout3 = 11102,
		DummyWorkout4 = 11103,
		DummyWorkout5 = 11104,
		DummyWorkout6 = 11105,
		DummyWorkout7 = 11106,
		DummyWorkout8 = 11107,
		DummyWorkout9 = 11108,
		DummyWorkout10 = 11109,
		CaloriesWorkout0 = 12000,
		CaloriesWSorkout999 = 12999,
		TimeWorkout0 = 1300,
		TimeWorkout99 = 13099,
		Dummy = 9999
	}
	public class KeyObj
	{
		public KeyCode Code { get; set; }

		public ulong RawKeyCode { get; set; }

		public int TimePressed { get; set; }

		public int TimeHeld { get; set; }

		public KeyObj(int code, ulong rawKey, int timePressed, int timeHeld)
		{
			Code = (KeyCode)code;
			RawKeyCode = rawKey;
			TimePressed = timePressed;
			TimeHeld = timeHeld;
		}

		public override string ToString()
		{
			return string.Format("[KeyObj {0}:{1}, {2}:{3}, {4}:{5}, {6}:{7}]", "Code", Code, "RawKeyCode", RawKeyCode, "TimePressed", TimePressed, "TimeHeld", TimeHeld);
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is KeyObj keyObj))
			{
				return false;
			}
			if (keyObj.Code == Code && keyObj.RawKeyCode == RawKeyCode && keyObj.TimePressed == TimePressed)
			{
				return keyObj.TimeHeld == TimeHeld;
			}
			return false;
		}
	}
	public class Pulse
	{
		public enum Source
		{
			None,
			Hand,
			Polar,
			Ant,
			Ble
		}

		public int UserPulse { get; internal set; }

		public int Average { get; internal set; }

		public int Count { get; internal set; }

		public Source PulseSource { get; }

		public Pulse(int userPulse, int average, int count, Source source)
		{
			UserPulse = userPulse;
			Average = average;
			Count = count;
			PulseSource = source;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return UserPulse == ((Pulse)obj).UserPulse;
		}

		public override int GetHashCode()
		{
			return UserPulse;
		}

		public override string ToString()
		{
			return $"[Pulse: User={UserPulse}, Ave={Average}, Count={Count}, Source={PulseSource}]";
		}
	}
	public enum WorkoutGoal
	{
		Meters,
		Seconds
	}
}
namespace Sindarin.Core.Console
{
	public class ConsoleBasicInfo : IConsoleBasicInfo, IFitnessValueUpdater, IDisposable
	{
		protected const string Tag = "ConsoleBasicInfo";

		private ConsoleState _currentState;

		protected Subject<IList<FitnessValue>> _whenFitnessValuesChanged = new Subject<IList<FitnessValue>>();

		private readonly Dictionary<FitnessValue, PropertyInfo> propertyMap = new Dictionary<FitnessValue, PropertyInfo>();

		private readonly FitnessValueValidator validator;

		private IDisposable timeChangedSub;

		private readonly TimeSpan timeChangedDelay = TimeSpan.FromMilliseconds(35.0);

		private const int TimeStatesToRemember = 3;

		private readonly TimeStateList timeStates = new TimeStateList(3);

		private bool updatingBatch;

		private readonly ConcurrentList<FitnessValue> updatedFitnessValues = new ConcurrentList<FitnessValue>();

		private readonly List<FitnessValue> priorityFitnessValues = new List<FitnessValue>
		{
			FitnessValue.CurrentTime,
			FitnessValue.RunningTime,
			FitnessValue.PausedTime
		};

		private bool disposedValue;

		[FitnessValueProperty(FitnessValue.Kph)]
		public double Kph { get; internal set; }

		[FitnessValueProperty(FitnessValue.ActualKph)]
		public double ActualKph { get; internal set; }

		[FitnessValueProperty(FitnessValue.MaxKph)]
		public double MaxKph { get; internal set; }

		[FitnessValueProperty(FitnessValue.MinKph)]
		public double MinKph { get; internal set; }

		[FitnessValueProperty(FitnessValue.Grade)]
		public double Grade { get; internal set; }

		[FitnessValueProperty(FitnessValue.ActualIncline)]
		public double ActualGrade { get; internal set; }

		[FitnessValueProperty(FitnessValue.MaxGrade)]
		public double MaxGrade { get; internal set; }

		[FitnessValueProperty(FitnessValue.MinGrade)]
		public double MinGrade { get; internal set; }

		[FitnessValueProperty(FitnessValue.AverageGrade)]
		public double AvgGrade { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentDistance)]
		public double DistanceMeters { get; internal set; }

		[FitnessValueProperty(FitnessValue.MotorTotalDistance)]
		public double MotorTotalDistance { get; internal set; }

		public int TimeSeconds => ReportedCurrentTime;

		[FitnessValueProperty(FitnessValue.RunningTime)]
		public int RunningTime { get; internal set; }

		[FitnessValueProperty(FitnessValue.PausedTime)]
		public int PausedTime { get; internal set; }

		[FitnessValueProperty(FitnessValue.TotalTime)]
		public double TotalTime { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentCalories)]
		public double Calories { get; internal set; }

		[FitnessValueProperty(FitnessValue.LapTime)]
		public int LapTimeSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.Watts)]
		public int Watts { get; internal set; }

		[FitnessValueProperty(FitnessValue.AverageWatts)]
		public double AvgWatts { get; internal set; }

		[FitnessValueProperty(FitnessValue.Resistance)]
		public double Resistance { get; internal set; }

		[FitnessValueProperty(FitnessValue.MaxResistanceLevel)]
		public double MaxResistanceLevel { get; protected internal set; }

		[FitnessValueProperty(FitnessValue.Gear)]
		public Gear Gear { get; internal set; }

		[FitnessValueProperty(FitnessValue.Rpm)]
		public int Rpm { get; internal set; }

		[FitnessValueProperty(FitnessValue.VerticalMeterGain)]
		public double VerticalMetersGain { get; internal set; }

		[FitnessValueProperty(FitnessValue.VerticalMeterNet)]
		public double VerticalMetersNet { get; internal set; }

		[FitnessValueProperty(FitnessValue.Pulse)]
		public Pulse CurrentPulse { get; internal set; }

		[FitnessValueProperty(FitnessValue.IdleModeLockout)]
		public bool? IdleModeLockout { get; internal set; }

		public int PauseOverrideTime { get; set; }

		public DateTime StartRequestedAt { get; internal set; }

		[FitnessValueProperty(FitnessValue.StartRequested)]
		public bool StartRequested { get; internal set; }

		[FitnessValueProperty(FitnessValue.RequireStartRequested)]
		public bool? RequireStartRequested { get; internal set; }

		public double AvgPulse => CurrentPulse.Average;

		[FitnessValueProperty(FitnessValue.MaxPulse)]
		public int MaxPulse { get; internal set; }

		[FitnessValueProperty(FitnessValue.WarmupTimeout)]
		public int WarmUpTimeoutSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.CoolDownTimeout)]
		public int CoolDownTimeoutSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.PauseTimeout)]
		public int PauseTimeoutSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.IdleTimeout)]
		public int IdleTimeoutSeconds { get; internal set; }

		[FitnessValueProperty(FitnessValue.Volume)]
		public int Volume { get; internal set; }

		[FitnessValueProperty(FitnessValue.KeyObject)]
		public KeyObj KeyObject { get; internal set; }

		[FitnessValueProperty(FitnessValue.FanState)]
		public FanState FanState { get; internal set; }

		[FitnessValueProperty(FitnessValue.ActivationLock)]
		public ActivationLockState ActivationLock { get; internal set; } = ActivationLockState.Unknown;

		[FitnessValueProperty(FitnessValue.WorkoutMode)]
		public ConsoleState CurrentState
		{
			get
			{
				if (_currentState == ConsoleState.Paused && SupportsPauseOverride && PauseOverrideEnabled)
				{
					return ConsoleState.PauseOverride;
				}
				return _currentState;
			}
			internal set
			{
				_currentState = value;
			}
		}

		public bool SupportsPauseOverride { get; set; }

		public bool PauseOverrideEnabled { get; set; }

		[FitnessValueProperty(FitnessValue.Strokes)]
		public int Strokes { get; internal set; }

		[FitnessValueProperty(FitnessValue.StrokesPerMin)]
		public int StrokesPerMin { get; internal set; }

		[FitnessValueProperty(FitnessValue.FiveHundredSplit)]
		public int FiveHundredSplit { get; internal set; }

		[FitnessValueProperty(FitnessValue.AvgFiveHundredSplit)]
		public int AvgFiveHundredSplit { get; internal set; }

		[FitnessValueProperty(FitnessValue.GoalTime)]
		public int GoalTime { get; internal set; }

		[FitnessValueProperty(FitnessValue.WattGoal)]
		public int WattGoal { get; internal set; }

		[FitnessValueProperty(FitnessValue.SystemUnits)]
		public bool IsMetric { get; internal set; }

		[FitnessValueProperty(FitnessValue.IsClubUnit)]
		public bool IsClubUnit { get; internal set; }

		[FitnessValueProperty(FitnessValue.IsReadyToDisconnect)]
		public bool IsReadyToDisconnect { get; internal set; }

		[FitnessValueProperty(FitnessValue.IsConstantWattsMode)]
		public bool IsConstantWattsMode { get; internal set; }

		[FitnessValueProperty(FitnessValue.MaxWeight)]
		public double MaxWeight { get; internal set; }

		[FitnessValueProperty(FitnessValue.Weight)]
		public double Weight { get; internal set; }

		[FitnessValueProperty(FitnessValue.CurrentTime)]
		public int CurrentTime { get; internal set; }

		[FitnessValueProperty(FitnessValue.DistanceGoal)]
		public double DistanceGoal { get; internal set; }

		[FitnessValueProperty(FitnessValue.SleepTimerState)]
		public bool SleepTimerState { get; internal set; }

		public int ReportedCurrentTime { get; set; }

		public bool TimeTrendMatchesState => timeStates.TimeTrendMatchesState;

		public IObservable<IList<FitnessValue>> WhenFitnessValuesChanged { get; protected set; }

		public ConsoleBasicInfo(bool supportsPauseOverride = false)
		{
			WhenFitnessValuesChanged = _whenFitnessValuesChanged.AsObservable();
			validator = new FitnessValueValidator();
			SupportsPauseOverride = supportsPauseOverride;
			Type typeFromHandle = typeof(ConsoleBasicInfo);
			AddProperties(typeFromHandle);
			WatchTimeChanges();
		}

		protected void WatchTimeChanges()
		{
			timeChangedSub?.Dispose();
			timeChangedSub = WhenFitnessValuesChanged?.Where((IList<FitnessValue> x) => x.Contains(FitnessValue.CurrentTime) || x.Contains(FitnessValue.RunningTime)).Subscribe(delegate
			{
				timeStates.WhenTimeChanged(TimeSeconds, CurrentState);
			});
		}

		protected void AddProperties(Type consoleInfoType)
		{
			foreach (PropertyInfo item in consoleInfoType.GetTypeInfo().DeclaredProperties.Where((PropertyInfo x) => x.GetCustomAttribute<FitnessValueProperty>() != null))
			{
				FitnessValueProperty customAttribute = item.GetCustomAttribute<FitnessValueProperty>();
				propertyMap.Add(customAttribute.FitnessValue, item);
			}
		}

		public bool SetValue(FitnessValue fitnessValue, object value)
		{
			try
			{
				validator.Validate(fitnessValue, value);
				PropertyInfo propertyInfo = propertyMap[fitnessValue];
				object value2 = propertyInfo.GetValue(this);
				if (value != null && value.Equals(value2))
				{
					return false;
				}
				propertyInfo.SetValue(this, value);
				if (updatingBatch)
				{
					updatedFitnessValues.Add(fitnessValue);
				}
				else
				{
					List<FitnessValue> value3 = new List<FitnessValue> { fitnessValue };
					_whenFitnessValuesChanged.OnNext(value3);
				}
				if (value is ConsoleState consoleState && consoleState == ConsoleState.Paused && SupportsPauseOverride && PauseOverrideEnabled)
				{
					propertyInfo.SetValue(this, ConsoleState.PauseOverride);
				}
			}
			catch (Exception ex)
			{
				Log.Error("ConsoleBasicInfo", $"Couldn't set type {fitnessValue} with value {value} and type {value?.GetType()}", ex);
				Log.Error("ConsoleBasicInfo", ex.StackTrace);
				return false;
			}
			return true;
		}

		public void BeginBatchUpdate()
		{
			updatedFitnessValues.Clear();
			updatingBatch = true;
		}

		public void EndBatchUpdate()
		{
			updatingBatch = false;
			UpdatePriorityFitnessValues();
			_whenFitnessValuesChanged.OnNext(updatedFitnessValues);
			updatedFitnessValues.Clear();
		}

		public void UpdatePriorityFitnessValues()
		{
			foreach (FitnessValue priorityFitnessValue in priorityFitnessValues)
			{
				if (updatedFitnessValues.Contains(priorityFitnessValue))
				{
					_whenFitnessValuesChanged.OnNext(new List<FitnessValue> { priorityFitnessValue });
					updatedFitnessValues.Remove(priorityFitnessValue);
				}
			}
		}

		public object GetValue(FitnessValue fitnessValue)
		{
			return propertyMap[fitnessValue].GetValue(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					timeChangedSub?.Dispose();
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
	public enum ConsoleState
	{
		Unknown,
		Idle,
		Workout,
		Paused,
		WorkoutResults,
		SafetyKeyRemoved,
		WarmUp,
		CoolDown,
		Resume,
		PauseOverride,
		Locked,
		Demo,
		Sleep,
		Error
	}
	public abstract class FitnessConsoleBase : IFitnessConsole, ICalibrateIncline, IDisposable
	{
		protected const string LogTag = "FitnessConsole";

		private const double ResultsIdleIncline = 0.0;

		protected readonly Subject<IConsoleInfo> _whenConsoleInitialized = new Subject<IConsoleInfo>();

		protected readonly Subject<CalibrateInclineState> _whenCalibrationStatusChanged = new Subject<CalibrateInclineState>();

		protected readonly Subject<FitnessValue> _whenControlValueChangedOnConsole = new Subject<FitnessValue>();

		protected readonly Subject<object> whenWorkoutEnding = new Subject<object>();

		protected readonly Subject<StateChange> consoleStateChanged = new Subject<StateChange>();

		protected readonly Subject<bool> _whenDataTimerChanged = new Subject<bool>();

		protected readonly Subject<bool> _detectOnBytesBeingSent = new Subject<bool>();

		private readonly bool isBuiltIn;

		private bool _startKeyEnabled;

		private bool _pauseOverrideEnabled;

		protected readonly ReplaySubject<bool> _whenCalibrationStarted = new ReplaySubject<bool>(1);

		protected readonly ICommunicationAdapter adapter;

		protected double? lastKphValue;

		protected double? lastGradeValue;

		protected double? lastResistanceValue;

		protected int? lastGearValue;

		protected IDisposable connectionInitializedSub;

		private IDisposable idleStartRequestedSub;

		private IDisposable resultsToIdleSub;

		private IDisposable workoutEndingSub;

		private IDisposable activationUnlockIfNeededSub;

		private IDisposable stateChangeFilterSub;

		private bool pausedFromApp;

		public static readonly List<ConsoleState> WorkoutStates = new List<ConsoleState>
		{
			ConsoleState.WarmUp,
			ConsoleState.Workout,
			ConsoleState.CoolDown,
			ConsoleState.Paused,
			ConsoleState.PauseOverride
		};

		public abstract TimeSpan DefaultTimeout { get; }

		public List<FitnessValue> ReadableTypes { get; protected set; }

		public List<FitnessValue> WritableTypes { get; protected set; }

		public IConsoleInfo ConsoleInfo { get; protected set; }

		public IConsoleBasicInfo LatestBasicInfo { get; protected set; }

		public IFacadeRepository FacadeRepository { get; }

		public IObservable<IConsoleInfo> WhenConsoleInitialized => _whenConsoleInitialized.AsObservable();

		public IObservable<CalibrateInclineState> WhenCalibrationStatusChanged => _whenCalibrationStatusChanged.AsObservable();

		public IObservable<FitnessValue> WhenControlValueChangedOnConsole => _whenControlValueChangedOnConsole.AsObservable();

		public IObservable<object> WhenWorkoutEnding => whenWorkoutEnding.AsObservable();

		public IObservable<StateChange> WhenStateChanged => consoleStateChanged.AsObservable();

		public IObservable<bool> WhenDataTimerChanged => _whenDataTimerChanged.AsObservable();

		public IObservable<bool> DetectOnBytesBeingSent => _detectOnBytesBeingSent.AsObservable();

		public IObservable<int> WhenPausedTimeRemainingChanged => FitnessValueChangeManager.WhenPauseRemainingChanged;

		public IChangeManager ChangeManager => FitnessValueChangeManager;

		public IDeviceConnection Connection => adapter?.Connection;

		public bool Initialized { get; protected set; }

		public bool StartKeyEnabled
		{
			get
			{
				return _startKeyEnabled;
			}
			set
			{
				if (_startKeyEnabled == value)
				{
					return;
				}
				_startKeyEnabled = value;
				if (!isBuiltIn)
				{
					IConsoleInfo consoleInfo = ConsoleInfo;
					if (consoleInfo == null || consoleInfo.MachineType.IsBeltBasedMachine())
					{
						Log.Trace("FitnessConsole", $"Ignoring start key change to {_startKeyEnabled} idle lockout change for BLE treadmills");
						return;
					}
				}
				SetValue(FitnessValue.IdleModeLockout, !_startKeyEnabled);
				Log.Trace("FitnessConsole", "Start key enabled set to: " + _startKeyEnabled);
			}
		}

		public int PauseOverrideTime => FitnessValueChangeManager.PauseOverrideTime;

		public abstract ConnectionType ConnectionType { get; }

		public int PauseTimeoutSecondsRemaining => FitnessValueChangeManager.PauseTimeoutRemaining;

		public virtual bool SupportsPauseOverride => ConsoleInfo?.MachineType.SupportsPauseOverride() ?? false;

		public bool PauseOverrideEnabled
		{
			get
			{
				return _pauseOverrideEnabled;
			}
			set
			{
				_pauseOverrideEnabled = value && SupportsPauseOverride;
				FitnessValueChangeManager.PauseOverrideEnabled = _pauseOverrideEnabled;
				LatestBasicInfo.PauseOverrideEnabled = _pauseOverrideEnabled;
			}
		}

		public IObservable<bool> WhenCalibrationStarted => _whenCalibrationStarted.AsObservable();

		protected IFitnessValueChangeManager FitnessValueChangeManager { get; } = new FitnessValueChangeManager();

		protected FitnessConsoleBase(ICommunicationAdapter adapter)
		{
			FacadeRepository = new FacadeRepository();
			this.adapter = adapter;
			isBuiltIn = adapter.ConnectionType == ConnectionType.USB;
			IReadWriteFacadeFactoryDependencies readWriteFacadeFactoryDependencies = Mvx.Resolve<IReadWriteFacadeFactoryDependencies>();
			FitnessValueChangeManager.Filters.Add(new MaxValueFitnessValueFilter(new FitnessValue[2]
			{
				FitnessValue.Watts,
				FitnessValue.AverageWatts
			}, 5000.0));
			stateChangeFilterSub = (from x in ObserveValue(FitnessValue.WorkoutMode)
				select new StateChange((ConsoleState)x.Old, (ConsoleState)x.Current)).Subscribe(StateChangeFilter);
			ReplaySubject<bool> whenCalibrationStarted = _whenCalibrationStarted;
			IFitnessValueChangeManager fitnessValueChangeManager = FitnessValueChangeManager;
			whenCalibrationStarted.OnNext(fitnessValueChangeManager != null && fitnessValueChangeManager.BasicInfo?.CurrentState == ConsoleState.Locked);
			idleStartRequestedSub = (from change in readWriteFacadeFactoryDependencies.StartRequestedFacade.ObserveStartRequestedChanges()
				where !change.Current && LatestBasicInfo.CurrentState == ConsoleState.Idle
				select change).Subscribe(delegate
			{
				SetValue(FitnessValue.WorkoutMode, ConsoleState.Idle);
			});
			resultsToIdleSub = WhenStateChanged.Where((StateChange x) => x.Current == ConsoleState.WorkoutResults).Delay(TimeSpan.FromMilliseconds(200.0)).SubscribeWithErrorLogging(delegate
			{
				CleanUpWorkout();
			});
			workoutEndingSub?.Dispose();
			workoutEndingSub = (from x in WhenStateChanged.CombineLatest(readWriteFacadeFactoryDependencies.CurrentTimeFacade.ObserveCurrentTimeChanges(), (StateChange state, FitnessValueChange<int> metric) => new Tuple<StateChange, FitnessValueChange<int>>(state, metric))
				where x.Item1.Current == ConsoleState.CoolDown && x.Item2.Type == FitnessValue.RunningTime && x.Item2.Current < 3 && x.Item2.Current > 0
				select x).SubscribeWithErrorLogging(delegate
			{
				whenWorkoutEnding.OnNext(null);
			});
			activationUnlockIfNeededSub?.Dispose();
			activationUnlockIfNeededSub = readWriteFacadeFactoryDependencies.ActivationLockFacade.ObserveActivationLockChanges().SubscribeWithErrorLogging(UnlockIfNeeded);
		}

		protected void InitializeConnection()
		{
			if (adapter.Connection.Initialized)
			{
				Log.Trace("FitnessConsole", $"### {GetType()}: connection initialized");
				Task.Run((Func<Task>)InitializeConsole);
				return;
			}
			Log.Trace("FitnessConsole", $"### {GetType()}: connection not initialized. Subscribing.");
			connectionInitializedSub?.Dispose();
			connectionInitializedSub = adapter.Connection.WhenInitialized.Where((bool x) => x).SubscribeAsyncWithErrorLogging(delegate
			{
				Log.Trace("FitnessConsole", $"### {GetType()}: whenInitialized emitted a result.");
				if (Initialized)
				{
					OnReconnect();
					return Task.CompletedTask;
				}
				return InitializeConsole();
			});
		}

		public abstract Task InitializeConsole();

		private void CleanUpWorkout()
		{
			IConsoleBasicInfo latestBasicInfo = LatestBasicInfo;
			if (latestBasicInfo == null || latestBasicInfo.CurrentState != ConsoleState.Idle)
			{
				Log.Trace("FitnessConsole", "CleanUpWorkout");
				(FitnessValue, object)[] values = new(FitnessValue, object)[2]
				{
					(FitnessValue.WorkoutMode, ConsoleState.Idle),
					(FitnessValue.Grade, 0.0)
				};
				SetValues(values);
				FitnessValueChangeManager.Reinitialize();
			}
		}

		private void StateChangeFilter(StateChange change)
		{
			if (change.Current != change.Old)
			{
				CheckLockedState(change);
				IConsoleInfo consoleInfo = ConsoleInfo;
				if (consoleInfo != null && consoleInfo.MachineType.IsAerobicMachine() && WorkoutStates.Contains(change.Old) && !WorkoutStates.Contains(change.Current))
				{
					SetIdleModeLockout(locked: true);
				}
				if (change.Current == ConsoleState.Paused)
				{
					StartPauseTimer();
					ConsoleState current = ((SupportsPauseOverride && PauseOverrideEnabled && !pausedFromApp) ? ConsoleState.PauseOverride : ConsoleState.Paused);
					consoleStateChanged.OnNext(new StateChange(change.Old, current));
					pausedFromApp = false;
				}
				else
				{
					StopPauseTimer();
					consoleStateChanged.OnNext(change);
				}
			}
		}

		private void CheckLockedState(StateChange change)
		{
			if (change.Current == ConsoleState.Locked || change.Old == ConsoleState.Locked)
			{
				_whenCalibrationStarted.OnNext(change.Current == ConsoleState.Locked);
			}
		}

		public void SetIdleModeLockout(bool locked)
		{
			SetValue(FitnessValue.IdleModeLockout, locked);
		}

		public void StopPauseTimer()
		{
			FitnessValueChangeManager.StopPauseOverrideProcessing();
		}

		public void StartPauseTimer()
		{
			bool emulatePausedTime = SupportsPauseOverride && PauseOverrideEnabled && !FitnessValueSupported(FitnessValue.PausedTime);
			FitnessValueChangeManager.StartPauseOverrideProcessing(emulatePausedTime);
		}

		private void UnlockIfNeeded(FitnessValueChange<ActivationLockState> state)
		{
			activationUnlockIfNeededSub?.Dispose();
			activationUnlockIfNeededSub = null;
			if (state.Current == ActivationLockState.Unlocked)
			{
				Log.Trace("FitnessConsole", "ActivationLockState was not locked, doing nothing");
				return;
			}
			Log.Trace("FitnessConsole", "ActivationLockState was locked, unlocking");
			ChangeActivationLock(ActivationLockState.Unlocked);
		}

		public void ChangeActivationLock(ActivationLockState lockState)
		{
			SetValue(FitnessValue.ActivationLock, lockState);
		}

		protected void DetectControlValueChangedOnConsole()
		{
			DetectKphChangedOnConsole();
			DetectGradeChangedOnConsole();
			DetectResistanceChangedOnConsole();
			DetectGearChangedOnConsole();
		}

		protected void DetectKphChangedOnConsole()
		{
			if (!lastKphValue.HasValue || !lastKphValue.Value.AlmostEqual(LatestBasicInfo.Kph, 1))
			{
				Log.Trace("FitnessConsole", $"Kph changed from {lastKphValue} to {LatestBasicInfo.Kph}");
				_whenControlValueChangedOnConsole.OnNext(FitnessValue.Kph);
			}
			else if (!lastKphValue.Value.AlmostEqual(LatestBasicInfo.Kph, 2))
			{
				Log.Trace("FitnessConsole", $"Kph changed from {lastKphValue} to {LatestBasicInfo.Kph}, not enough to trigger a change notification.");
			}
			lastKphValue = LatestBasicInfo.Kph;
		}

		protected void DetectGradeChangedOnConsole()
		{
			if (!lastGradeValue.HasValue || !lastGradeValue.Value.AlmostEqual(LatestBasicInfo.Grade, 1))
			{
				Log.Trace("FitnessConsole", $"Grade changed from {lastGradeValue} to {LatestBasicInfo.Grade}");
				_whenControlValueChangedOnConsole.OnNext(FitnessValue.Grade);
			}
			else if (!lastGradeValue.Value.AlmostEqual(LatestBasicInfo.Grade, 2))
			{
				Log.Trace("FitnessConsole", $"Grade changed from {lastGradeValue} to {LatestBasicInfo.Grade}, not enough to trigger a change notification.");
			}
			lastGradeValue = LatestBasicInfo.Grade;
		}

		protected void DetectResistanceChangedOnConsole()
		{
			if (!lastResistanceValue.HasValue || !lastResistanceValue.Value.AlmostEqual(LatestBasicInfo.Resistance, 1))
			{
				Log.Trace("FitnessConsole", $"Resistance changed from {lastResistanceValue} to {LatestBasicInfo.Resistance}");
				_whenControlValueChangedOnConsole.OnNext(FitnessValue.Resistance);
			}
			else if (!lastResistanceValue.Value.AlmostEqual(LatestBasicInfo.Resistance, 2))
			{
				Log.Trace("FitnessConsole", $"Resistance changed from {lastResistanceValue} to {LatestBasicInfo.Resistance}, not enough to trigger a change notification.");
			}
			lastResistanceValue = LatestBasicInfo.Resistance;
		}

		protected void DetectGearChangedOnConsole()
		{
			if (LatestBasicInfo.Gear != null && (!lastGearValue.HasValue || !lastGearValue.Equals(LatestBasicInfo.Gear.CurrentGear)))
			{
				Log.Trace("FitnessConsole", $"Gear changed from {lastGearValue} to {LatestBasicInfo.Gear}");
				_whenControlValueChangedOnConsole.OnNext(FitnessValue.Gear);
			}
			lastGearValue = LatestBasicInfo.Gear?.CurrentGear;
		}

		protected virtual Task Shutdown()
		{
			SetRequireStartRequested(required: false);
			return Task.CompletedTask;
		}

		protected void SetRequireStartRequested(bool required)
		{
			SetValue(FitnessValue.RequireStartRequested, required);
		}

		public void ReinitializeFitnessValues(int extraTime, int pausedTime)
		{
			ChangeManager.Reinitialize(extraTime, pausedTime);
		}

		public virtual Task SetSubscribed(bool subscribed, FitnessValue fitnessValue)
		{
			return Task.CompletedTask;
		}

		public void SetValues(params (FitnessValue, object)[] values)
		{
			Task.Run(async () => await SetValuesAsync(values)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public void SetValue(FitnessValue type, object value)
		{
			Task.Run(async () => await SetValueAsync(type, value)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<bool> SetValueAsync(FitnessValue type, object value)
		{
			return await SetValuesAsync((type, value)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public Task<bool> SetValuesAsync(params (FitnessValue, object)[] values)
		{
			IEnumerable<(FitnessValue, object)> source = values.Where(IsSettable);
			source = source.Select(Clamp);
			return SetValidatedValuesAsync(source.ToArray());
		}

		private bool IsSettable((FitnessValue, object) tuple)
		{
			if (ConsoleInfo == null)
			{
				return true;
			}
			bool flag = true;
			var (fitnessValue, _) = tuple;
			try
			{
				switch (fitnessValue)
				{
				case FitnessValue.Grade:
					flag = ConsoleInfo.CanSetIncline;
					break;
				case FitnessValue.Resistance:
					flag = ConsoleInfo.CanSetResistance;
					break;
				case FitnessValue.Kph:
					flag = ConsoleInfo.CanSetKph;
					break;
				case FitnessValue.Gear:
					flag = ConsoleInfo.CanSetGear;
					break;
				}
				if (!flag)
				{
					Log.Trace("FitnessConsole", $"Filtered {fitnessValue} because it's not settable.");
				}
			}
			catch (Exception exception)
			{
				Log.Error("FitnessConsole", $"Error filtering {fitnessValue}.", exception);
			}
			return flag;
		}

		private (FitnessValue, object) Clamp((FitnessValue, object) tuple)
		{
			if (ConsoleInfo == null)
			{
				return tuple;
			}
			if (tuple.Item2 == null)
			{
				return tuple;
			}
			(FitnessValue, object) result = tuple;
			try
			{
				switch (tuple.Item1)
				{
				case FitnessValue.Grade:
				{
					double num4 = ((double)tuple.Item2).Clamp(ConsoleInfo.MinIncline, ConsoleInfo.MaxIncline);
					result.Item2 = num4;
					break;
				}
				case FitnessValue.Resistance:
				{
					double num5 = ((double)tuple.Item2).Clamp(ConsoleInfo.MinResistanceLevel, ConsoleInfo.MaxResistanceLevel);
					result.Item2 = num5;
					break;
				}
				case FitnessValue.Kph:
				{
					double num3 = ((double)tuple.Item2).Clamp(ConsoleInfo.MinKph, ConsoleInfo.MaxKph);
					result.Item2 = num3;
					break;
				}
				case FitnessValue.Gear:
				{
					object item = tuple.Item2;
					if (!(item is int val))
					{
						if (item is Gear gear)
						{
							int num = gear.CurrentGear.Clamp(ConsoleInfo.MinGear, ConsoleInfo.MaxGear);
							if (num != gear.CurrentGear)
							{
								result.Item2 = new Gear(num, gear.GearOption, gear.MaxGear);
							}
						}
					}
					else
					{
						int num2 = val.Clamp(ConsoleInfo.MinGear, ConsoleInfo.MaxGear);
						result.Item2 = num2;
					}
					break;
				}
				}
				if (tuple.Item2 != result.Item2)
				{
					Log.Trace("FitnessConsole", $"Clamped {tuple.Item1} from {tuple.Item2} to {result.Item2}.");
				}
			}
			catch (Exception exception)
			{
				Log.Error("FitnessConsole", $"Error clamping ({tuple.Item1}, {tuple.Item2}).", exception);
			}
			return result;
		}

		protected abstract Task<bool> SetValidatedValuesAsync((FitnessValue, object)[] values);

		public object GetMostRecentValue(FitnessValue type)
		{
			return LatestBasicInfo.GetValue(type);
		}

		public IObservable<AnyFitnessValueChange> ObserveValue(FitnessValue type)
		{
			return FitnessValueChangeManager.WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => x.Type == type);
		}

		public IObservable<AnyFitnessValueChange> ObserveValues(List<FitnessValue> types)
		{
			return FitnessValueChangeManager.WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => types.Contains(x.Type) && x.Old != x.Current);
		}

		public abstract bool FitnessValueSupported(FitnessValue value);

		public abstract Task<object> GetValueAsync(FitnessValue type);

		public abstract void CalibrateIncline();

		public virtual void Dispose()
		{
			stateChangeFilterSub?.Dispose();
			stateChangeFilterSub = null;
			connectionInitializedSub?.Dispose();
			connectionInitializedSub = null;
			resultsToIdleSub?.Dispose();
			resultsToIdleSub = null;
			idleStartRequestedSub?.Dispose();
			idleStartRequestedSub = null;
			workoutEndingSub?.Dispose();
			workoutEndingSub = null;
			activationUnlockIfNeededSub?.Dispose();
			activationUnlockIfNeededSub = null;
		}

		public virtual Task<IConsoleError> GetConsoleErrorAsync()
		{
			return Task.FromResult<IConsoleError>(null);
		}

		protected virtual void OnDisconnect()
		{
		}

		protected virtual void OnReconnect()
		{
		}
	}
	public interface IFitnessConsoleManager
	{
		IObservable<IFitnessConsole> WhenConsoleChanged { get; }

		IFitnessConsole PhysicalConsole { get; }

		IFitnessConsole CurrentConsole { get; set; }

		Subject<AnyFitnessValueChange> WhenFitnessValueChanged { get; }

		IObservable<AnyFitnessValueChange> ObserveValue(FitnessValue type);

		IObservable<AnyFitnessValueChange> ObserveValues(params FitnessValue[] types);
	}
	public class FitnessConsoleManager : IFitnessConsoleManager
	{
		private readonly Subject<IFitnessConsole> whenConsoleChanged = new Subject<IFitnessConsole>();

		private readonly List<FitnessValue> observedFitnessValues = new List<FitnessValue>();

		private readonly SemaphoreSlim subLock = new SemaphoreSlim(1, 1);

		private IFitnessConsole _currentConsole;

		private IDisposable realFitnessValueChangedSub;

		public Subject<AnyFitnessValueChange> WhenFitnessValueChanged { get; } = new Subject<AnyFitnessValueChange>();

		public IObservable<IFitnessConsole> WhenConsoleChanged => whenConsoleChanged.AsObservable();

		public IFitnessConsole PhysicalConsole { get; private set; }

		public IFitnessConsole CurrentConsole
		{
			get
			{
				return _currentConsole;
			}
			set
			{
				if (value == null || value != _currentConsole)
				{
					_currentConsole = value;
					if (!(value is EquipmentlessConsoleBase))
					{
						PhysicalConsole = value;
					}
					UpdateSubs();
					whenConsoleChanged.OnNext(value);
				}
			}
		}

		public IObservable<AnyFitnessValueChange> ObserveValue(FitnessValue type)
		{
			try
			{
				subLock.Wait();
				if (!observedFitnessValues.Contains(type))
				{
					observedFitnessValues.Add(type);
					CreateValuesChangeSub();
				}
			}
			finally
			{
				subLock.Release();
			}
			return WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => x.Type == type);
		}

		public IObservable<AnyFitnessValueChange> ObserveValues(params FitnessValue[] types)
		{
			try
			{
				subLock.Wait();
				types.DoForEach(delegate(FitnessValue type)
				{
					if (!observedFitnessValues.Contains(type))
					{
						observedFitnessValues.Add(type);
					}
				});
				CreateValuesChangeSub();
			}
			finally
			{
				subLock.Release();
			}
			return WhenFitnessValueChanged.Where((AnyFitnessValueChange x) => Enumerable.Contains(types, x.Type));
		}

		private void UpdateSubs()
		{
			try
			{
				subLock.Wait();
				realFitnessValueChangedSub?.Dispose();
				if (CurrentConsole == null)
				{
					observedFitnessValues.Clear();
				}
				CreateValuesChangeSub();
			}
			finally
			{
				subLock.Release();
			}
		}

		private void CreateValuesChangeSub()
		{
			realFitnessValueChangedSub?.Dispose();
			realFitnessValueChangedSub = CurrentConsole?.ObserveValues(observedFitnessValues)?.Subscribe(WhenFitnessValueChanged.OnNext);
		}
	}
	public sealed class FitnessValueArgumentOutOfRangeException : ArgumentOutOfRangeException
	{
		public FitnessValueArgumentOutOfRangeException(FitnessValue fv, object value, object min, object max)
			: base(fv.ToString(), $"{fv}: \"{value}\" ({value.GetType()}) out of range {min}-{max}")
		{
		}
	}
	public sealed class FitnessValueArgumentTypeException : ArgumentException
	{
		public FitnessValueArgumentTypeException(FitnessValue fv, string expectedType, object value)
			: base(fv.ToString(), $"Expected {fv} to be {expectedType} but it is {value.GetType()}")
		{
		}
	}
	public sealed class FitnessValueValidator
	{
		public bool Validate(FitnessValue fv, object value)
		{
			switch (fv)
			{
			case FitnessValue.Kph:
				CheckValueBounds<double, double>(fv, value, 0.0, 100.0, IsWithinRange);
				break;
			case FitnessValue.Grade:
				CheckValueBounds<double, double>(fv, value, -20.0, 40.0, IsWithinRange);
				break;
			case FitnessValue.Resistance:
				try
				{
					CheckValueBounds<double, double>(fv, value, 0.0, 26.0, IsWithinRange);
				}
				catch (FitnessValueArgumentTypeException)
				{
					CheckValueBounds<int, double>(fv, value, 0.0, 26.0, IsWithinRange);
				}
				break;
			case FitnessValue.Gear:
				CheckValueBounds<Gear, int>(fv, value, 1, 26, IsWithinRange);
				break;
			case FitnessValue.Pulse:
				CheckValueBounds<Pulse, double>(fv, value, 0.0, 255.0, IsWithinRange);
				break;
			case FitnessValue.WorkoutMode:
				CheckValueBounds<ConsoleState, ConsoleState>(fv, value, FitnessValueValidationDefaults.MinState, FitnessValueValidationDefaults.MaxState, IsWithinRange);
				break;
			case FitnessValue.ActivationLock:
				CheckValueBounds<ActivationLockState, ActivationLockState>(fv, (ActivationLockState)value, FitnessValueValidationDefaults.MinActivationLockState, FitnessValueValidationDefaults.MaxActivationLockState, IsWithinRange);
				break;
			case FitnessValue.IdleModeLockout:
			case FitnessValue.SleepTimerState:
			case FitnessValue.RequireStartRequested:
				CheckValueBounds(fv, value);
				break;
			case FitnessValue.Volume:
				CheckValueBounds<int, int>(fv, value, 0, 100, IsWithinRange);
				break;
			}
			return true;
		}

		private void CheckValueBounds<TConverted, T>(FitnessValue fv, object rawValue, T min, T max, Func<TConverted, T, T, bool> isInRange)
		{
			if (!(rawValue is TConverted arg))
			{
				throw new FitnessValueArgumentTypeException(fv, typeof(TConverted).Name, rawValue);
			}
			if (!isInRange(arg, min, max))
			{
				throw new FitnessValueArgumentOutOfRangeException(fv, rawValue, min, max);
			}
		}

		private void CheckValueBounds(FitnessValue fv, object rawValue)
		{
			if (!(rawValue is bool))
			{
				throw new FitnessValueArgumentTypeException(fv, "bool", rawValue);
			}
		}

		private bool IsWithinRange(int value, int min, int max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}

		private bool IsWithinRange(int value, double min, double max)
		{
			if ((double)value >= min)
			{
				return (double)value <= max;
			}
			return false;
		}

		private bool IsWithinRange(double value, double min, double max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}

		private bool IsWithinRange(Gear value, int min, int max)
		{
			if (value.CurrentGear >= min)
			{
				return value.CurrentGear <= max;
			}
			return false;
		}

		private bool IsWithinRange(Pulse value, double min, double max)
		{
			if ((double)value.UserPulse >= min)
			{
				return (double)value.UserPulse <= max;
			}
			return false;
		}

		private bool IsWithinRange(ConsoleState value, ConsoleState min, ConsoleState max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}

		private bool IsWithinRange(ActivationLockState value, ActivationLockState min, ActivationLockState max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}
	}
	internal static class FitnessValueValidationDefaults
	{
		public const int Zero = 0;

		public const double MaxKph = 100.0;

		public const double MinIncline = -20.0;

		public const double MaxIncline = 40.0;

		public const double MaxResistance = 26.0;

		public const int MinGear = 1;

		public const int MaxGear = 26;

		public const int MaxPulse = 255;

		public const int MaxVolume = 100;

		public static readonly ConsoleState MinState;

		public static readonly ConsoleState MaxState;

		public static readonly ActivationLockState MinActivationLockState;

		public static readonly ActivationLockState MaxActivationLockState;

		static FitnessValueValidationDefaults()
		{
			ConsoleState[] source = (ConsoleState[])Enum.GetValues(typeof(ConsoleState));
			MinState = source.First();
			MaxState = source.Last();
			ActivationLockState[] source2 = (ActivationLockState[])Enum.GetValues(typeof(ActivationLockState));
			MinActivationLockState = source2.First();
			MaxActivationLockState = source2.Last();
		}
	}
	public interface ICalibrateIncline
	{
		IObservable<CalibrateInclineState> WhenCalibrationStatusChanged { get; }

		IObservable<bool> WhenCalibrationStarted { get; }

		void CalibrateIncline();
	}
	public interface IChangeManager
	{
		List<IFitnessValueDecorator> Decorators { get; }

		List<IFitnessValueFilter> Filters { get; }

		List<IFitnessValueSubstitute> Substitutes { get; }

		void RetriggerCurrentStateChange();

		void Reinitialize(int extraTime = 0, int pausedTime = 0);
	}
	public interface IConsoleBasicInfo : IFitnessValueUpdater, IDisposable
	{
		IObservable<IList<FitnessValue>> WhenFitnessValuesChanged { get; }

		double Kph { get; }

		double ActualKph { get; }

		double MaxKph { get; }

		double MinKph { get; }

		double Grade { get; }

		double ActualGrade { get; }

		double MaxGrade { get; }

		double MinGrade { get; }

		double AvgGrade { get; }

		double DistanceMeters { get; }

		double MotorTotalDistance { get; }

		int TimeSeconds { get; }

		int RunningTime { get; }

		int PausedTime { get; }

		double TotalTime { get; }

		double Calories { get; }

		int LapTimeSeconds { get; }

		int Watts { get; }

		double AvgWatts { get; }

		double Resistance { get; }

		double MaxResistanceLevel { get; }

		Gear Gear { get; }

		int Rpm { get; }

		double VerticalMetersGain { get; }

		double VerticalMetersNet { get; }

		Pulse CurrentPulse { get; }

		bool? IdleModeLockout { get; }

		DateTime StartRequestedAt { get; }

		bool StartRequested { get; }

		bool? RequireStartRequested { get; }

		double AvgPulse { get; }

		int MaxPulse { get; }

		int WarmUpTimeoutSeconds { get; }

		int CoolDownTimeoutSeconds { get; }

		int PauseTimeoutSeconds { get; }

		int IdleTimeoutSeconds { get; }

		int Volume { get; }

		KeyObj KeyObject { get; }

		FanState FanState { get; }

		ActivationLockState ActivationLock { get; }

		ConsoleState CurrentState { get; }

		bool SupportsPauseOverride { get; set; }

		bool PauseOverrideEnabled { get; set; }

		int Strokes { get; }

		int StrokesPerMin { get; }

		int FiveHundredSplit { get; }

		int AvgFiveHundredSplit { get; }

		int GoalTime { get; }

		int WattGoal { get; }

		double DistanceGoal { get; }

		bool IsMetric { get; }

		bool IsClubUnit { get; }

		bool IsReadyToDisconnect { get; }

		bool IsConstantWattsMode { get; }

		double MaxWeight { get; }

		double Weight { get; }

		int CurrentTime { get; }

		int PauseOverrideTime { get; set; }

		int ReportedCurrentTime { get; set; }

		bool TimeTrendMatchesState { get; }
	}
	public interface IConsoleConnection
	{
		IFitnessConsole Console { get; }
	}
	public interface IConsoleDescriptor
	{
		ConnectionType ConnectionType { get; }
	}
	public interface IConsoleError
	{
		string UserFriendlyLocalizedDescription { get; }
	}
	public interface ITimedError
	{
		IObservable<TimeSpan> Timeout { get; }
	}
	public interface IConsoleInfo
	{
		const string DefaultSerialNumber = "N/A";

		int ModelNumber { get; }

		int PartNumber { get; }

		bool IsSystemMarketTypeClub { get; }

		int SoftwareVersion { get; }

		int HardwareVersion { get; }

		string FirmwareVersion { get; }

		int SerialNumber { get; }

		Manufacturer ManufacturerId { get; }

		ConsoleType MachineType { get; }

		string Name { get; }

		string BrainboardSerialNumber { get; }

		int MasterLibraryVersion { get; }

		int MasterLibraryBuild { get; }

		bool SystemUnits { get; }

		double MaxKph { get; }

		double MinKph { get; }

		double MaxIncline { get; }

		double MinIncline { get; }

		int GearOption { get; }

		int MinGear { get; }

		int MaxGear { get; }

		double MinResistanceLevel { get; }

		double MaxResistanceLevel { get; }

		double MaxWeight { get; }

		bool CanSetKph { get; }

		bool CanSetActivationLock { get; }

		bool CanSetIncline { get; }

		bool SupportsVerticalGain { get; }

		bool SupportsVerticalNet { get; }

		bool SupportsStartRequested { get; }

		bool SupportsRequireStartRequested { get; }

		bool SupportsKeyPressObserved { get; }

		bool SupportsPulse { get; }

		bool CanSetResistance { get; }

		bool CanSetGear { get; }

		double TotalTime { get; }

		int WarmUpTimeoutSeconds { get; }

		int CoolDownTimeoutSeconds { get; }

		int PauseTimeoutSeconds { get; }

		int IdleTimeoutSeconds { get; }

		double TotalMeters { get; }

		bool IsClubUnit { get; }

		bool IsClub { get; }

		bool SupportsConstantWatts { get; }

		double Weight { get; }
	}
	public abstract class ConsoleInfoBase : IConsoleInfo
	{
		public abstract int ModelNumber { get; }

		public abstract int PartNumber { get; }

		public abstract bool IsSystemMarketTypeClub { get; }

		public abstract int SoftwareVersion { get; }

		public abstract int HardwareVersion { get; }

		public abstract string FirmwareVersion { get; }

		public abstract int SerialNumber { get; }

		public abstract Manufacturer ManufacturerId { get; }

		public abstract ConsoleType MachineType { get; }

		public abstract string Name { get; }

		public abstract string BrainboardSerialNumber { get; }

		public abstract int MasterLibraryVersion { get; }

		public abstract int MasterLibraryBuild { get; }

		public bool SystemUnits => Console.LatestBasicInfo.IsMetric;

		public double MaxKph => Console.LatestBasicInfo.MaxKph;

		public double MinKph => Console.LatestBasicInfo.MinKph;

		public double MaxIncline => Console.LatestBasicInfo.MaxGrade;

		public double MinIncline => Console.LatestBasicInfo.MinGrade;

		public int GearOption => Console.LatestBasicInfo.Gear?.GearOption ?? 0;

		public int MaxGear
		{
			get
			{
				if (!CanSetGear)
				{
					return 0;
				}
				return Console.LatestBasicInfo.Gear.MaxGear;
			}
		}

		public int MinGear
		{
			get
			{
				if (!CanSetGear)
				{
					return 0;
				}
				return 1;
			}
		}

		public double MaxResistanceLevel => Console.LatestBasicInfo.MaxResistanceLevel;

		public double MinResistanceLevel => 1.0;

		public double MaxWeight
		{
			get
			{
				if (!(Console.LatestBasicInfo.MaxWeight > 0.0))
				{
					return 136.078;
				}
				return Console.LatestBasicInfo.MaxWeight;
			}
		}

		public abstract bool CanSetKph { get; }

		public abstract bool CanSetActivationLock { get; }

		public abstract bool CanSetIncline { get; }

		public abstract bool SupportsVerticalGain { get; }

		public abstract bool SupportsVerticalNet { get; }

		public abstract bool SupportsStartRequested { get; }

		public abstract bool SupportsRequireStartRequested { get; }

		public abstract bool SupportsKeyPressObserved { get; }

		public abstract bool SupportsPulse { get; }

		public abstract bool CanSetResistance { get; }

		public abstract bool CanSetGear { get; }

		public int CoolDownTimeoutSeconds => Console.LatestBasicInfo.CoolDownTimeoutSeconds;

		public double TotalTime => Console.LatestBasicInfo.TotalTime;

		public int WarmUpTimeoutSeconds => Console.LatestBasicInfo.WarmUpTimeoutSeconds;

		public int PauseTimeoutSeconds => Console.LatestBasicInfo.PauseTimeoutSeconds;

		public int IdleTimeoutSeconds => Console.LatestBasicInfo.IdleTimeoutSeconds;

		public double TotalMeters => Console.LatestBasicInfo.MotorTotalDistance;

		public bool IsClubUnit => Console.LatestBasicInfo.IsClubUnit;

		public bool IsClub
		{
			get
			{
				if (!IsClubUnit)
				{
					return IsSystemMarketTypeClub;
				}
				return true;
			}
		}

		public abstract bool SupportsConstantWatts { get; }

		public double Weight => Console.LatestBasicInfo.Weight;

		protected IFitnessConsole Console { get; }

		protected ConsoleInfoBase(IFitnessConsole console)
		{
			Console = console;
		}

		public static string GetMachineTypeCode(ConsoleType machine)
		{
			switch (machine)
			{
			case ConsoleType.Bike:
			case ConsoleType.SpinBike:
				return "EB";
			case ConsoleType.Elliptical:
			case ConsoleType.FreeStrider:
			case ConsoleType.VerticalElliptical:
				return "EL";
			case ConsoleType.Strider:
				return "ES";
			case ConsoleType.Rower:
				return "RW";
			case ConsoleType.Treadmill:
			case ConsoleType.InclineTrainer:
				return "ET";
			default:
				return "";
			}
		}

		public static string GetManufacturerCode(Manufacturer manufacturer)
		{
			return manufacturer switch
			{
				Manufacturer.NordicTrack => "NT", 
				Manufacturer.ProForm => "PF", 
				Manufacturer.FreeMotion => "FM", 
				Manufacturer.GoldsGym => "GG", 
				Manufacturer.HealthRider => "HR", 
				Manufacturer.Weslo => "WL", 
				Manufacturer.WorkoutWarehouse => "WW", 
				_ => "", 
			};
		}
	}
	public interface IConsoleScanner
	{
		IReadOnlyList<IConsoleDescriptor> FoundConsoles { get; }

		IObservable<IConsoleDescriptor> StartScanning(TimeSpan timeout);

		void StopScanning();

		Task<IConsoleConnection> Connect(IConsoleDescriptor descriptor);
	}
	public abstract class BaseConsoleScanner : IConsoleScanner
	{
		private SemaphoreSlim scanLock = new SemaphoreSlim(1, 1);

		protected bool isScanning;

		protected Subject<IConsoleDescriptor> whenConsoleFound = new Subject<IConsoleDescriptor>();

		protected List<IConsoleDescriptor> _foundConsoles = new List<IConsoleDescriptor>();

		public IReadOnlyList<IConsoleDescriptor> FoundConsoles => _foundConsoles;

		public async Task<IConsoleConnection> Connect(IConsoleDescriptor descriptor)
		{
			StopScanning();
			return await DoConnect(descriptor);
		}

		public IObservable<IConsoleDescriptor> StartScanning(TimeSpan timeout)
		{
			scanLock.Wait();
			isScanning = true;
			_foundConsoles.Clear();
			Task.Run(async delegate
			{
				DoStartScan();
				await Task.Delay(timeout);
				StopScanning();
			});
			return whenConsoleFound;
		}

		public void StopScanning()
		{
			DoStopScan();
			isScanning = false;
			if (scanLock.CurrentCount < 1)
			{
				scanLock.Release();
			}
		}

		protected abstract Task<IConsoleConnection> DoConnect(IConsoleDescriptor descriptor);

		protected abstract void DoStartScan();

		protected abstract void DoStopScan();
	}
	public interface IFitnessConsole : ICalibrateIncline, IDisposable
	{
		TimeSpan DefaultTimeout { get; }

		List<FitnessValue> ReadableTypes { get; }

		List<FitnessValue> WritableTypes { get; }

		IConsoleInfo ConsoleInfo { get; }

		IConsoleBasicInfo LatestBasicInfo { get; }

		IFacadeRepository FacadeRepository { get; }

		IObservable<IConsoleInfo> WhenConsoleInitialized { get; }

		IObservable<int> WhenPausedTimeRemainingChanged { get; }

		IDeviceConnection Connection { get; }

		IObservable<FitnessValue> WhenControlValueChangedOnConsole { get; }

		IObservable<StateChange> WhenStateChanged { get; }

		IObservable<bool> WhenDataTimerChanged { get; }

		IObservable<bool> DetectOnBytesBeingSent { get; }

		IChangeManager ChangeManager { get; }

		bool StartKeyEnabled { get; set; }

		bool PauseOverrideEnabled { get; set; }

		IObservable<object> WhenWorkoutEnding { get; }

		int PauseTimeoutSecondsRemaining { get; }

		bool SupportsPauseOverride { get; }

		bool Initialized { get; }

		int PauseOverrideTime { get; }

		ConnectionType ConnectionType { get; }

		void SetValues(params (FitnessValue, object)[] values);

		Task<bool> SetValuesAsync(params (FitnessValue, object)[] values);

		void SetValue(FitnessValue type, object value);

		object GetMostRecentValue(FitnessValue type);

		Task<bool> SetValueAsync(FitnessValue type, object value);

		Task<object> GetValueAsync(FitnessValue type);

		IObservable<AnyFitnessValueChange> ObserveValue(FitnessValue type);

		IObservable<AnyFitnessValueChange> ObserveValues(List<FitnessValue> types);

		bool FitnessValueSupported(FitnessValue value);

		void ReinitializeFitnessValues(int extraTime, int pausedTime);

		Task SetSubscribed(bool subscribed, FitnessValue fitnessValue);

		Task InitializeConsole();

		Task<IConsoleError> GetConsoleErrorAsync();
	}
	public interface IFitnessValueUpdater
	{
		bool SetValue(FitnessValue fitnessValue, object value);

		object GetValue(FitnessValue fitnessValue);

		void BeginBatchUpdate();

		void EndBatchUpdate();
	}
	public interface IForceClubUnit
	{
		void ToggleClubStatus();
	}
	public enum Manufacturer
	{
		None,
		Icon,
		FreeMotion,
		ProForm,
		NordicTrack,
		Weider,
		HealthRider,
		Reebok,
		WorkoutWarehouse,
		Weslo,
		Uts,
		Rip60,
		GoldsGym,
		Ifit,
		Altra,
		Sears
	}
	public class TimeStateList
	{
		public int[] times;

		public ConsoleState[] states;

		public int addIndex;

		private readonly object lockObject = new object();

		private readonly List<ConsoleState> pauseStates = new List<ConsoleState>
		{
			ConsoleState.Paused,
			ConsoleState.PauseOverride,
			ConsoleState.SafetyKeyRemoved,
			ConsoleState.Error
		};

		private ConsoleState lastNonPauseState;

		public int Size
		{
			get
			{
				int[] array = times;
				if (array == null)
				{
					return 0;
				}
				return array.Length;
			}
		}

		public bool TimeTrendMatchesState { get; private set; }

		public int LastTime { get; private set; }

		public ConsoleState LastWorkoutMode { get; private set; }

		public bool AllAscending
		{
			get
			{
				lock (lockObject)
				{
					for (int i = 1; i < Size; i++)
					{
						if (times[i] < times[i - 1])
						{
							return false;
						}
					}
					return StateIsConsistent();
				}
			}
		}

		public bool AllDescending
		{
			get
			{
				lock (lockObject)
				{
					for (int i = 1; i < Size; i++)
					{
						if (times[i] > times[i - 1])
						{
							return false;
						}
					}
					return StateIsConsistent();
				}
			}
		}

		public bool IsTrustworthy(ConsoleState state)
		{
			switch (state)
			{
			case ConsoleState.WarmUp:
			case ConsoleState.CoolDown:
				return AllDescending;
			case ConsoleState.Workout:
				return AllAscending;
			default:
				return false;
			}
		}

		public void WhenTimeChanged(int timeSeconds, ConsoleState currentState)
		{
			Add(timeSeconds, currentState);
			switch (currentState)
			{
			case ConsoleState.Unknown:
			case ConsoleState.Idle:
			case ConsoleState.WorkoutResults:
			case ConsoleState.Resume:
				TimeTrendMatchesState = false;
				break;
			case ConsoleState.Workout:
			case ConsoleState.WarmUp:
			case ConsoleState.CoolDown:
				lastNonPauseState = currentState;
				TimeTrendMatchesState = IsTrustworthy(currentState);
				break;
			case ConsoleState.Paused:
			case ConsoleState.SafetyKeyRemoved:
			case ConsoleState.PauseOverride:
			case ConsoleState.Error:
				TimeTrendMatchesState = IsTrustworthy(lastNonPauseState);
				break;
			}
			if (!TimeTrendMatchesState)
			{
				Log.Trace("TimeState", "UNTRUSTED time change: " + ToString());
			}
		}

		public TimeStateList(int size)
		{
			times = new int[size];
			states = new ConsoleState[size];
		}

		public void Add(int time, ConsoleState state)
		{
			lock (lockObject)
			{
				if (time == LastTime && state == LastWorkoutMode)
				{
					return;
				}
				if (addIndex < Size)
				{
					times[addIndex] = time;
					states[addIndex] = state;
					addIndex++;
				}
				else
				{
					for (int i = 0; i < Size - 1; i++)
					{
						times[i] = times[i + 1];
						states[i] = states[i + 1];
					}
					times[Size - 1] = time;
					states[Size - 1] = state;
				}
				LastTime = time;
				LastWorkoutMode = state;
			}
		}

		private bool StateIsConsistent()
		{
			ConsoleState consoleState = ConsoleState.Unknown;
			for (int i = 0; i < Size; i++)
			{
				if (!pauseStates.Contains(states[i]))
				{
					if (consoleState == ConsoleState.Unknown)
					{
						consoleState = states[i];
					}
					if (states[i] == ConsoleState.Unknown)
					{
						return false;
					}
					if (states[i] != consoleState)
					{
						return false;
					}
				}
			}
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("TimeStateList: [");
			lock (lockObject)
			{
				for (int i = 0; i < Size; i++)
				{
					stringBuilder.Append("(").Append(times[i]).Append(",")
						.Append(states[i])
						.Append(")");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
namespace Sindarin.Core.Console.Substitutes
{
	public class AerobicCalorieMultiplierSubstitute : IFitnessValueSubstitute, IFitnessValueDecorator, ICalorieMultiplierRecoverable
	{
		private readonly List<CalorieMultiplierEvent> calorieMultiplierEvents;

		private readonly double massKg;

		protected int lastTime;

		protected double totalDelta;

		public AerobicCalorieMultiplierSubstitute(List<CalorieMultiplierEvent> calorieMultiplierEvents, double massKg)
		{
			this.massKg = massKg;
			this.calorieMultiplierEvents = calorieMultiplierEvents;
		}

		public bool CanSubstitute(FitnessValue value, double newValue, IConsoleBasicInfo currentInfo)
		{
			CalorieMultiplierEvent calorieEvent = GetCalorieEvent(currentInfo);
			int num;
			if (value == FitnessValue.CurrentTime && currentInfo.CurrentState == ConsoleState.Workout && calorieEvent != null)
			{
				num = ((currentInfo.Rpm == 0) ? 1 : 0);
				if (num != 0)
				{
					goto IL_0042;
				}
			}
			else
			{
				num = 0;
			}
			if (value == FitnessValue.CurrentTime && currentInfo.CurrentState == ConsoleState.Workout)
			{
				lastTime = currentInfo.TimeSeconds;
			}
			goto IL_0042;
			IL_0042:
			return (byte)num != 0;
		}

		public FitnessValue GetSubstituteFitnessValue()
		{
			return FitnessValue.CurrentCalories;
		}

		public double Substitute(FitnessValue value, double newValue, IConsoleBasicInfo currentInfo)
		{
			double num = CalorieMultiplierCalculator.CalculateOffEquipmentAerobicCaloriesDelta(lastTime, currentInfo.TimeSeconds, massKg, calorieMultiplierEvents);
			totalDelta += num;
			lastTime = currentInfo.TimeSeconds;
			return currentInfo.Calories + totalDelta;
		}

		public bool CanDecorate(FitnessValue value, double newValue, IConsoleBasicInfo info)
		{
			if (value == FitnessValue.CurrentCalories)
			{
				return info.CurrentState == ConsoleState.Workout;
			}
			return false;
		}

		public double DecorateChange(FitnessValue value, double newValue, IConsoleBasicInfo info)
		{
			return newValue + totalDelta;
		}

		protected CalorieMultiplierEvent GetCalorieEvent(IConsoleBasicInfo info)
		{
			return CalorieMultiplierCalculator.GetCalorieEventForTime(calorieMultiplierEvents, info.TimeSeconds);
		}

		public CalorieMultiplierRecoveryInfo GetRecoveryInfo()
		{
			return new CalorieMultiplierRecoveryInfo
			{
				LastTime = lastTime,
				TotalCalorieDelta = totalDelta
			};
		}

		public void Recover(CalorieMultiplierRecoveryInfo calorieMultiplierRecoveryInfo)
		{
			lastTime = calorieMultiplierRecoveryInfo.LastTime;
			totalDelta = calorieMultiplierRecoveryInfo.TotalCalorieDelta;
		}
	}
	public interface IFitnessValueSubstitute
	{
		bool CanSubstitute(FitnessValue value, double newValue, IConsoleBasicInfo currentInfo);

		FitnessValue GetSubstituteFitnessValue();

		double Substitute(FitnessValue value, double newValue, IConsoleBasicInfo currentInfo);
	}
}
namespace Sindarin.Core.Console.FitnessValues
{
	public interface IFitnessValueChangeManager : IChangeManager, IDisposable
	{
		bool PauseOverrideEnabled { get; set; }

		int PauseOverrideTime { get; }

		int LastPausedTime { get; }

		double PauseOverrideCalories { get; }

		int PauseTimeoutRemaining { get; }

		IObservable<AnyFitnessValueChange> WhenFitnessValueChanged { get; }

		IObservable<int> WhenPauseRemainingChanged { get; }

		TimeSpan BufferDelay { get; set; }

		IConsoleBasicInfo BasicInfo { get; set; }

		void StartPauseOverrideProcessing(bool emulatePausedTime = false);

		void StopPauseOverrideProcessing();

		object GetLatestValue(FitnessValue fitnessValue);
	}
	public class FitnessValueChangeManager : IFitnessValueChangeManager, IChangeManager, IDisposable
	{
		public const string LogTag = "FitPro";

		private const double PauseOverrideCalorieRate = 0.0412148;

		private readonly Subject<AnyFitnessValueChange> _whenFitnessValueChanged = new Subject<AnyFitnessValueChange>();

		private Subject<int> _whenPauseRemainingChanged = new Subject<int>();

		private IConsoleBasicInfo _basicInfo;

		private readonly Dictionary<FitnessValue, object> recentValues = new Dictionary<FitnessValue, object>();

		private readonly Dictionary<FitnessValue, double> recentMetrics = new Dictionary<FitnessValue, double>();

		private ConsoleState latestState;

		private FanState latestFanState = FanState.Unknown;

		private ActivationLockState latestActivationState = ActivationLockState.Unknown;

		private int lastAdjustedRunningTimeSeconds;

		private IDisposable basicInfoChangeSub;

		private IDisposable pauseOverrideTimer;

		private IDisposable recentValueSub;

		private DateTime PauseTimeUtc;

		private bool isInPauseOverride;

		private bool emulatePausedTime;

		private bool isDisposed;

		private int previousTime;

		private AnyFitnessValueChange fitnessValueChange = new AnyFitnessValueChange();

		public bool PauseOverrideEnabled { get; set; }

		public IObservable<AnyFitnessValueChange> WhenFitnessValueChanged => _whenFitnessValueChanged;

		public IObservable<int> WhenPauseRemainingChanged => _whenPauseRemainingChanged;

		public TimeSpan BufferDelay { get; set; } = TimeSpan.FromMilliseconds(50.0);

		public List<IFitnessValueDecorator> Decorators { get; } = new List<IFitnessValueDecorator>();

		public List<IFitnessValueFilter> Filters { get; } = new List<IFitnessValueFilter>();

		public List<IFitnessValueSubstitute> Substitutes { get; } = new List<IFitnessValueSubstitute>();

		public IConsoleBasicInfo BasicInfo
		{
			get
			{
				return _basicInfo;
			}
			set
			{
				_basicInfo = value;
				basicInfoChangeSub?.Dispose();
				basicInfoChangeSub = (from x in _basicInfo?.WhenFitnessValuesChanged
					where x.Count > 0
					select x.Distinct().ToList()).Subscribe(WhenValueChanged);
			}
		}

		public int PauseOverrideTime
		{
			get
			{
				return BasicInfo.PauseOverrideTime;
			}
			protected set
			{
				BasicInfo.PauseOverrideTime = value;
			}
		}

		public int LastPausedTime { get; protected set; }

		public double PauseOverrideCalories { get; protected set; }

		public int PauseTimeoutRemaining { get; protected set; }

		private bool SuppressMetricPaused
		{
			get
			{
				if (latestState != ConsoleState.Paused)
				{
					return latestState == ConsoleState.PauseOverride;
				}
				return true;
			}
		}

		public FitnessValueChangeManager()
		{
			recentValueSub = WhenFitnessValueChanged.Subscribe(delegate(AnyFitnessValueChange x)
			{
				recentValues[x.Type] = x.Current;
			});
		}

		public void Dispose()
		{
			Log.Trace(GetType().Name, "Dispose called");
			if (!isDisposed)
			{
				isDisposed = true;
				basicInfoChangeSub?.Dispose();
				pauseOverrideTimer?.Dispose();
				recentValueSub?.Dispose();
			}
		}

		public void Reinitialize(int extraTime = 0, int pausedTime = 0)
		{
			if (!isDisposed)
			{
				isInPauseOverride = false;
				PauseOverrideTime = extraTime;
				emulatePausedTime = false;
				LastPausedTime = pausedTime;
				lastAdjustedRunningTimeSeconds = PauseOverrideTime;
			}
		}

		public void StartPauseOverrideProcessing(bool emulatePausedTime = false)
		{
			if (!isDisposed)
			{
				pauseOverrideTimer?.Dispose();
				this.emulatePausedTime = emulatePausedTime;
				PauseTimeoutRemaining = BasicInfo.PauseTimeoutSeconds;
				if (emulatePausedTime)
				{
					LastPausedTime = 0;
				}
				PauseTimeUtc = DateTime.UtcNow;
				pauseOverrideTimer = Observable.Interval(TimeSpan.FromSeconds(1.0), Scheduler.Default).Subscribe(ProcessPauseTimerUpdate);
			}
		}

		private void ProcessPauseTimerUpdate(long timeUpdate)
		{
			if (!isDisposed)
			{
				int num = (int)(DateTime.UtcNow - PauseTimeUtc).TotalSeconds;
				PauseTimeoutRemaining = BasicInfo.PauseTimeoutSeconds - num;
				_whenPauseRemainingChanged.OnNext(PauseTimeoutRemaining);
				if (emulatePausedTime && PauseOverrideEnabled)
				{
					UpdatePauseOverrideTime(num);
				}
			}
		}

		public void StopPauseOverrideProcessing()
		{
			pauseOverrideTimer?.Dispose();
			pauseOverrideTimer = null;
		}

		public object GetLatestValue(FitnessValue fitnessValue)
		{
			return recentValues.GetValueSafely(fitnessValue);
		}

		public void RetriggerCurrentStateChange()
		{
			if (!isDisposed)
			{
				if (BasicInfo.CurrentState == ConsoleState.Workout)
				{
					_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.WorkoutMode, ConsoleState.WarmUp, ConsoleState.Workout));
				}
				else if (BasicInfo.CurrentState == ConsoleState.CoolDown)
				{
					_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.WorkoutMode, ConsoleState.Workout, ConsoleState.CoolDown));
				}
			}
		}

		private void WhenValueChanged(IList<FitnessValue> changes)
		{
			if (isDisposed)
			{
				return;
			}
			isInPauseOverride = PauseOverrideEnabled && BasicInfo.CurrentState == ConsoleState.Paused;
			if (changes.Contains(FitnessValue.WorkoutMode))
			{
				ConsoleState consoleState = latestState;
				latestState = BasicInfo.CurrentState;
				Log.Trace("FitPro", $"Changed state from: {consoleState} to: {latestState}");
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.WorkoutMode, consoleState, latestState));
			}
			if (changes.Contains(FitnessValue.StartRequested) && BasicInfo.StartRequested)
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.StartRequested, !BasicInfo.StartRequested, BasicInfo.StartRequested));
				Log.Trace("FitPro", $"Start requested: {BasicInfo.StartRequested}");
			}
			if (changes.Contains(FitnessValue.RequireStartRequested))
			{
				Log.Trace("FitPro", $"RequireStartRequested: {BasicInfo.RequireStartRequested}");
			}
			if (changes.Contains(FitnessValue.FanState))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.FanState, latestFanState, BasicInfo.FanState));
				Log.Trace("FitPro", "Changed FanState from: " + latestFanState.ToString() + " to: " + BasicInfo.FanState);
				latestFanState = BasicInfo.FanState;
			}
			if (changes.Contains(FitnessValue.ActivationLock))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.ActivationLock, latestActivationState, BasicInfo.ActivationLock));
				Log.Trace("FitPro", $"Activation lock changed from {latestActivationState} to {BasicInfo.ActivationLock}");
				latestActivationState = BasicInfo.ActivationLock;
			}
			if (changes.Contains(FitnessValue.KeyObject))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.KeyObject, null, BasicInfo.KeyObject));
				Log.Trace("FitPro", $"KeyCode observed: {BasicInfo.KeyObject}");
			}
			if (changes.Contains(FitnessValue.IsReadyToDisconnect))
			{
				if (BasicInfo.IsClubUnit)
				{
					_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.IsReadyToDisconnect, !BasicInfo.IsReadyToDisconnect, BasicInfo.IsReadyToDisconnect));
				}
				Log.Trace("FitPro", $"IsReadyToDisconnect changed to {BasicInfo.IsReadyToDisconnect}");
			}
			if (changes.Contains(FitnessValue.IsClubUnit))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.IsClubUnit, !BasicInfo.IsClubUnit, BasicInfo.IsClubUnit));
				Log.Trace("FitPro", $"IsClubUnit changed to {BasicInfo.IsClubUnit}");
			}
			if (changes.Contains(FitnessValue.IsConstantWattsMode))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.IsConstantWattsMode, !BasicInfo.IsConstantWattsMode, BasicInfo.IsConstantWattsMode));
				Log.Trace("FitPro", $"IsConstantWattsMode changed to {BasicInfo.IsConstantWattsMode}");
			}
			if (changes.Contains(FitnessValue.WattGoal))
			{
				_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(FitnessValue.WattGoal, 0, BasicInfo.WattGoal));
				Log.Trace("FitPro", $"WattGoal changed to {BasicInfo.WattGoal}");
			}
			foreach (FitnessValue change in changes)
			{
				switch (change)
				{
				case FitnessValue.Kph:
					DoMetricChange(change, FitnessValue.Kph, BasicInfo.Kph);
					Log.Trace("FitPro", "Changed KPH to: " + BasicInfo.Kph);
					break;
				case FitnessValue.ActualKph:
					DoMetricChange(change, FitnessValue.ActualKph, BasicInfo.ActualKph);
					Log.Trace("FitPro", "Changed Actual KPH to: " + BasicInfo.ActualKph);
					break;
				case FitnessValue.Grade:
					DoMetricChange(change, FitnessValue.Grade, BasicInfo.Grade);
					Log.Trace("FitPro", "Changed Grade to: " + BasicInfo.Grade);
					break;
				case FitnessValue.ActualIncline:
					DoMetricChange(change, FitnessValue.ActualIncline, BasicInfo.ActualGrade);
					Log.Trace("FitPro", "Changed Actual Incline to: " + BasicInfo.ActualGrade);
					break;
				case FitnessValue.AverageGrade:
					DoMetricChange(change, FitnessValue.AverageGrade, BasicInfo.AvgGrade);
					break;
				case FitnessValue.LapTime:
					DoMetricChange(change, FitnessValue.LapTime, BasicInfo.LapTimeSeconds);
					break;
				case FitnessValue.Resistance:
					DoMetricChange(change, FitnessValue.Resistance, BasicInfo.Resistance);
					Log.Trace("FitPro", "Changed Resistance to: " + BasicInfo.Resistance);
					break;
				case FitnessValue.Gear:
					DoMetricChange(change, FitnessValue.Gear, BasicInfo.Gear.CurrentGear);
					Log.Trace("FitPro", "Changed CurrentGear to: " + BasicInfo.Gear.CurrentGear);
					Log.Trace("FitPro", "Changed MaxGear to: " + BasicInfo.Gear.MaxGear);
					Log.Trace("FitPro", "Changed GearOption to: " + BasicInfo.Gear.GearOption);
					break;
				case FitnessValue.Rpm:
					DoMetricChange(change, FitnessValue.Rpm, BasicInfo.Rpm);
					Log.Trace("FitPro", "Changed RPM to: " + BasicInfo.Rpm);
					break;
				case FitnessValue.VerticalMeterGain:
					DoMetricChange(change, FitnessValue.VerticalMeterGain, BasicInfo.VerticalMetersGain);
					break;
				case FitnessValue.VerticalMeterNet:
					DoMetricChange(change, FitnessValue.VerticalMeterNet, BasicInfo.VerticalMetersNet);
					break;
				case FitnessValue.Pulse:
					DoMetricChange(change, FitnessValue.Pulse, BasicInfo.CurrentPulse?.UserPulse ?? 0);
					break;
				case FitnessValue.MaxPulse:
					DoMetricChange(change, FitnessValue.MaxPulse, BasicInfo.MaxPulse);
					break;
				case FitnessValue.Volume:
					DoMetricChange(change, FitnessValue.Volume, BasicInfo.Volume);
					Log.Trace("FitPro", "Changed Volume to: " + BasicInfo.Volume);
					break;
				case FitnessValue.Watts:
					DoMetricChange(change, FitnessValue.Watts, BasicInfo.Watts);
					Log.Trace("FitPro", "Changed Watts to: " + BasicInfo.Watts);
					break;
				case FitnessValue.AverageWatts:
					DoMetricChange(change, FitnessValue.AverageWatts, BasicInfo.AvgWatts);
					break;
				case FitnessValue.Strokes:
					DoMetricChange(change, FitnessValue.Strokes, BasicInfo.Strokes);
					break;
				case FitnessValue.StrokesPerMin:
					if (!SuppressMetricPaused)
					{
						DoMetricChange(change, FitnessValue.StrokesPerMin, BasicInfo.StrokesPerMin);
					}
					break;
				case FitnessValue.FiveHundredSplit:
					DoMetricChange(change, FitnessValue.FiveHundredSplit, BasicInfo.FiveHundredSplit);
					DoMetricChange(change, FitnessValue.FiveHundredSplitDecimal, (double)BasicInfo.FiveHundredSplit / 60.0);
					break;
				case FitnessValue.AvgFiveHundredSplit:
					DoMetricChange(change, FitnessValue.AvgFiveHundredSplit, BasicInfo.AvgFiveHundredSplit);
					break;
				case FitnessValue.MotorTotalDistance:
					DoMetricChange(change, FitnessValue.MotorTotalDistance, BasicInfo.MotorTotalDistance);
					break;
				case FitnessValue.TotalTime:
					DoMetricChange(change, FitnessValue.TotalTime, BasicInfo.TotalTime);
					break;
				case FitnessValue.CurrentCalories:
					if (!SuppressMetricPaused)
					{
						DoMetricChange(change, FitnessValue.CurrentCalories, BasicInfo.Calories);
					}
					break;
				case FitnessValue.CurrentDistance:
					if (!SuppressMetricPaused)
					{
						DoMetricChange(change, FitnessValue.CurrentDistance, BasicInfo.DistanceMeters);
					}
					break;
				case FitnessValue.RunningTime:
					if (latestState != ConsoleState.WarmUp && latestState != ConsoleState.CoolDown)
					{
						int num2 = PauseOverrideTime + BasicInfo.RunningTime;
						Log.Trace("Workout", $"Set current time (r) to {num2} from RunningTime {BasicInfo.RunningTime} and PauseOverrideTime {PauseOverrideTime}");
						if (num2 - lastAdjustedRunningTimeSeconds > 1)
						{
							Log.Warn("FitPro", $"New current time has delta={num2 - lastAdjustedRunningTimeSeconds}, greater than 1");
						}
						lastAdjustedRunningTimeSeconds = num2;
						BasicInfo.ReportedCurrentTime = num2;
						DoMetricChange(FitnessValue.CurrentTime, FitnessValue.CurrentTime, num2);
					}
					else
					{
						Log.Trace("FitPro", $"Ignoring RunningTime because in {latestState} mode");
					}
					break;
				case FitnessValue.PausedTime:
				{
					if (isInPauseOverride)
					{
						UpdatePauseOverrideTime(BasicInfo.PausedTime);
						break;
					}
					int num = BasicInfo.PausedTime - PauseOverrideTime;
					LastPausedTime = BasicInfo.PausedTime;
					DoMetricChange(change, FitnessValue.PausedTime, num);
					break;
				}
				case FitnessValue.CurrentTime:
					if (latestState == ConsoleState.WarmUp || latestState == ConsoleState.CoolDown)
					{
						if (BasicInfo.CurrentTime == 0 && previousTime != 1)
						{
							return;
						}
						previousTime = BasicInfo.CurrentTime;
						BasicInfo.ReportedCurrentTime = BasicInfo.CurrentTime;
						DoMetricChange(change, FitnessValue.CurrentTime, BasicInfo.CurrentTime);
						Log.Trace("FitPro", "Changed CurrentTime to: " + BasicInfo.CurrentTime);
					}
					break;
				}
			}
		}

		private void UpdatePauseOverrideTime(int pausedTime)
		{
			if (!isDisposed)
			{
				int num = pausedTime - LastPausedTime;
				LastPausedTime = pausedTime;
				PauseOverrideTime += num;
				int num2 = PauseOverrideTime + BasicInfo.RunningTime;
				BasicInfo.ReportedCurrentTime = num2;
				DoMetricChange(FitnessValue.CurrentTime, FitnessValue.RunningTime, num2);
			}
		}

		private void DoMetricChange(FitnessValue fv, FitnessValue metricType, double newValue)
		{
			double doubleForFitnessValue = GetDoubleForFitnessValue(fv);
			foreach (IFitnessValueDecorator decorator in Decorators)
			{
				if (decorator != null && decorator.CanDecorate(fv, newValue, BasicInfo))
				{
					newValue = decorator.DecorateChange(fv, newValue, BasicInfo);
				}
			}
			foreach (IFitnessValueFilter filter in Filters)
			{
				if (filter != null && filter.ShouldDiscard(fv, newValue))
				{
					return;
				}
			}
			foreach (IFitnessValueSubstitute substitute in Substitutes)
			{
				if (substitute != null && substitute.CanSubstitute(fv, newValue, BasicInfo))
				{
					FitnessValue substituteFitnessValue = substitute.GetSubstituteFitnessValue();
					double num = substitute.Substitute(fv, newValue, BasicInfo);
					double doubleForFitnessValue2 = GetDoubleForFitnessValue(fv);
					_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(substituteFitnessValue, doubleForFitnessValue2, num));
				}
			}
			recentMetrics[fv] = newValue;
			_whenFitnessValueChanged?.OnNext(fitnessValueChange.Update(metricType, doubleForFitnessValue, newValue));
		}

		private double GetDoubleForFitnessValue(FitnessValue fv)
		{
			if (!recentMetrics.ContainsKey(fv))
			{
				recentMetrics[fv] = 0.0;
			}
			return recentMetrics[fv];
		}
	}
}
namespace Sindarin.Core.Console.Filters
{
	public interface IFitnessValueFilter
	{
		bool ShouldDiscard(FitnessValue bit, double newValue);
	}
	public class MaxValueFitnessValueFilter : IFitnessValueFilter
	{
		public IEnumerable<FitnessValue> FitnessValues { get; private set; }

		public double MaxValue { get; private set; }

		public MaxValueFitnessValueFilter(IEnumerable<FitnessValue> fitnessValues, double maxValue)
		{
			FitnessValues = fitnessValues;
			MaxValue = maxValue;
		}

		public MaxValueFitnessValueFilter(FitnessValue fitnessValue, double maxValue)
			: this(new List<FitnessValue> { fitnessValue }, maxValue)
		{
		}

		public virtual bool ShouldDiscard(FitnessValue value, double newValue)
		{
			if (FitnessValues?.Contains(value) == true)
			{
				return newValue > MaxValue;
			}
			return false;
		}
	}
}
namespace Sindarin.Core.Console.Equipmentless
{
	public class EquipmentlessCommunicationAdapter : ICommunicationAdapter, IDisposable
	{
		public ConnectionType ConnectionType => ConnectionType.None;

		public TimeSpan DefaultTimeout => TimeSpan.FromMilliseconds(50.0);

		public IObservable<bool> WhenCommsFailed { get; } = new Subject<bool>();

		public IDeviceConnection Connection { get; } = new MockConnection();

		public void Dispose()
		{
		}
	}
	public interface IEquipmentlessConsole : IFitnessConsole, ICalibrateIncline, IDisposable
	{
		IHeartRateHelper HeartRateHelper { set; }
	}
	public class EquipmentlessConsoleBase : FitnessConsoleBase, IEquipmentlessConsole, IFitnessConsole, ICalibrateIncline, IDisposable
	{
		private bool isDisposed;

		private IEquipmentlessFitnessValueManager equipmentlessFitnessValueManager;

		public IHeartRateHelper HeartRateHelper
		{
			get
			{
				return equipmentlessFitnessValueManager?.HeartRateHelper;
			}
			set
			{
				if (equipmentlessFitnessValueManager != null)
				{
					equipmentlessFitnessValueManager.HeartRateHelper = value;
				}
			}
		}

		public override TimeSpan DefaultTimeout => adapter.DefaultTimeout;

		public override ConnectionType ConnectionType => adapter.ConnectionType;

		protected EquipmentlessConsoleBase(IEquipmentlessWorkoutCalorieBurnEstimator calorieBurnEstimator)
			: base(new EquipmentlessCommunicationAdapter())
		{
			equipmentlessFitnessValueManager = new EquipmentlessFitnessValueManager(calorieBurnEstimator);
			base.ConsoleInfo = new EquipmentlessConsoleInfo();
			base.LatestBasicInfo = equipmentlessFitnessValueManager.CurrentValues;
		}

		public override bool FitnessValueSupported(FitnessValue value)
		{
			return true;
		}

		protected override Task<bool> SetValidatedValuesAsync((FitnessValue, object)[] values)
		{
			int? num = null;
			int? num2 = null;
			int? num3 = null;
			WorkoutGoal? workoutGoal = null;
			for (int i = 0; i < values.Length; i++)
			{
				var (fitnessValue, obj) = values[i];
				switch (fitnessValue)
				{
				case FitnessValue.WorkoutMode:
					switch ((ConsoleState)obj)
					{
					case ConsoleState.CoolDown:
						equipmentlessFitnessValueManager?.SkipToCooldown();
						break;
					case ConsoleState.WarmUp:
						equipmentlessFitnessValueManager?.Start();
						break;
					case ConsoleState.Workout:
						equipmentlessFitnessValueManager?.SkipWarmup();
						break;
					case ConsoleState.Paused:
						equipmentlessFitnessValueManager?.Pause();
						break;
					case ConsoleState.Resume:
						equipmentlessFitnessValueManager?.Resume();
						break;
					case ConsoleState.WorkoutResults:
						equipmentlessFitnessValueManager?.ForceEndWorkout();
						break;
					}
					break;
				case FitnessValue.GoalTime:
					num = (int)obj;
					workoutGoal = WorkoutGoal.Seconds;
					equipmentlessFitnessValueManager?.SetTargetTime(num.Value);
					break;
				case FitnessValue.CoolDownTimeout:
					num2 = (int)obj;
					equipmentlessFitnessValueManager?.SetCooldownTimeout(num2.Value);
					break;
				case FitnessValue.WarmupTimeout:
					num3 = (int)obj;
					break;
				case FitnessValue.DistanceGoal:
					workoutGoal = WorkoutGoal.Meters;
					break;
				}
			}
			if (workoutGoal.HasValue && workoutGoal.Value != WorkoutGoal.Seconds)
			{
				throw new ArgumentException($"Target type must be {WorkoutGoal.Seconds} to use equipmentless console.", "targetType");
			}
			if (num.HasValue && num2.HasValue && num3.HasValue)
			{
				equipmentlessFitnessValueManager?.SetWorkoutTimes(num3.Value, num.Value, num2.Value);
			}
			return Task.FromResult(result: true);
		}

		public override Task<object> GetValueAsync(FitnessValue type)
		{
			return Task.FromResult(base.LatestBasicInfo.GetValue(type));
		}

		public override void CalibrateIncline()
		{
			_whenCalibrationStatusChanged.OnNext(CalibrateInclineState.Done);
		}

		public override async Task InitializeConsole()
		{
			base.FitnessValueChangeManager.BasicInfo = equipmentlessFitnessValueManager.CurrentValues;
			base.Initialized = true;
		}

		public void CleanUpWorkout()
		{
			equipmentlessFitnessValueManager?.ForceEndWorkout();
			equipmentlessFitnessValueManager?.Dispose();
			equipmentlessFitnessValueManager = null;
		}

		protected override async Task Shutdown()
		{
			await base.Shutdown();
			CleanUpWorkout();
		}

		public override void Dispose()
		{
			if (!isDisposed)
			{
				equipmentlessFitnessValueManager?.Dispose();
				equipmentlessFitnessValueManager = null;
				base.Dispose();
				isDisposed = true;
			}
		}
	}
	public class EquipmentlessConsoleBasicInfo : ConsoleBasicInfo
	{
		private const ConsoleState DefaultWorkoutMode = ConsoleState.Idle;

		public static EquipmentlessConsoleBasicInfo CreateDefaultsWithFieldChangedObservable(IObservable<IList<FitnessValue>> whenFitnessValueChanged)
		{
			EquipmentlessConsoleBasicInfo equipmentlessConsoleBasicInfo = new EquipmentlessConsoleBasicInfo();
			equipmentlessConsoleBasicInfo.CurrentState = ConsoleState.Idle;
			equipmentlessConsoleBasicInfo.Kph = 0.0;
			equipmentlessConsoleBasicInfo.Grade = 0.0;
			equipmentlessConsoleBasicInfo.Resistance = 0.0;
			equipmentlessConsoleBasicInfo.Gear = null;
			equipmentlessConsoleBasicInfo.Watts = 0;
			equipmentlessConsoleBasicInfo.DistanceMeters = 0.0;
			equipmentlessConsoleBasicInfo.Rpm = 0;
			equipmentlessConsoleBasicInfo.KeyObject = null;
			equipmentlessConsoleBasicInfo.FanState = FanState.Unknown;
			equipmentlessConsoleBasicInfo.ActivationLock = ActivationLockState.Unlocked;
			equipmentlessConsoleBasicInfo.Volume = 0;
			equipmentlessConsoleBasicInfo.LapTimeSeconds = 0;
			equipmentlessConsoleBasicInfo.ActualKph = 0.0;
			equipmentlessConsoleBasicInfo.ActualGrade = 0.0;
			equipmentlessConsoleBasicInfo.MaxGrade = 0.0;
			equipmentlessConsoleBasicInfo.MinGrade = 0.0;
			equipmentlessConsoleBasicInfo.MaxKph = 0.0;
			equipmentlessConsoleBasicInfo.MinKph = 0.0;
			equipmentlessConsoleBasicInfo.IdleTimeoutSeconds = 0;
			equipmentlessConsoleBasicInfo.PauseTimeoutSeconds = 600;
			equipmentlessConsoleBasicInfo.MaxResistanceLevel = 0.0;
			equipmentlessConsoleBasicInfo.MaxWeight = 0.0;
			equipmentlessConsoleBasicInfo.MaxPulse = 0;
			equipmentlessConsoleBasicInfo.AvgGrade = 0.0;
			equipmentlessConsoleBasicInfo.AvgWatts = 0.0;
			equipmentlessConsoleBasicInfo.WattGoal = 0;
			equipmentlessConsoleBasicInfo.DistanceGoal = 0.0;
			equipmentlessConsoleBasicInfo.MotorTotalDistance = 0.0;
			equipmentlessConsoleBasicInfo.VerticalMetersNet = 0.0;
			equipmentlessConsoleBasicInfo.VerticalMetersGain = 0.0;
			equipmentlessConsoleBasicInfo.IdleModeLockout = null;
			equipmentlessConsoleBasicInfo.StartRequestedAt = DateTime.MinValue;
			equipmentlessConsoleBasicInfo.StartRequested = false;
			equipmentlessConsoleBasicInfo.RequireStartRequested = null;
			equipmentlessConsoleBasicInfo.Strokes = 0;
			equipmentlessConsoleBasicInfo.StrokesPerMin = 0;
			equipmentlessConsoleBasicInfo.FiveHundredSplit = 0;
			equipmentlessConsoleBasicInfo.AvgFiveHundredSplit = 0;
			equipmentlessConsoleBasicInfo.IsClubUnit = false;
			equipmentlessConsoleBasicInfo.IsReadyToDisconnect = false;
			equipmentlessConsoleBasicInfo.IsConstantWattsMode = false;
			equipmentlessConsoleBasicInfo.WhenFitnessValuesChanged = whenFitnessValueChanged;
			equipmentlessConsoleBasicInfo.WatchTimeChanges();
			return equipmentlessConsoleBasicInfo;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.WhenFitnessValuesChanged = null;
			}
			base.Dispose(disposing);
		}
	}
	public class EquipmentlessConsoleInfo : IConsoleInfo
	{
		public virtual int ModelNumber => 424992;

		public virtual int PartNumber => 424992;

		public virtual bool IsClubUnit => false;

		public virtual bool IsSystemMarketTypeClub => false;

		public virtual bool IsClub => false;

		public virtual int SoftwareVersion => 424992;

		public virtual int HardwareVersion => 424992;

		public virtual string FirmwareVersion => "Equipmentless";

		public virtual int SerialNumber => 424992;

		public virtual Manufacturer ManufacturerId => Manufacturer.Ifit;

		public virtual ConsoleType MachineType => ConsoleType.Equipmentless;

		public virtual string Name => "Equipmentless";

		public virtual string BrainboardSerialNumber => "Equipmentless";

		public virtual int MasterLibraryVersion => 424992;

		public virtual int MasterLibraryBuild => 424992;

		public virtual bool SupportsConstantWatts => false;

		public virtual bool SystemUnits => false;

		public virtual double MaxKph => 0.0;

		public virtual double MinKph => 0.0;

		public virtual double MaxIncline => 0.0;

		public virtual double MinIncline => 0.0;

		public virtual int GearOption => 0;

		public virtual int MinGear => 0;

		public virtual int MaxGear => 0;

		public virtual double MinResistanceLevel => 0.0;

		public virtual double MaxResistanceLevel => 0.0;

		public virtual double MaxWeight => 1.7976931348623157E+308;

		public virtual bool CanSetKph => false;

		public virtual bool CanSetActivationLock => false;

		public virtual bool CanSetIncline => false;

		public virtual bool SupportsVerticalGain => false;

		public virtual bool SupportsVerticalNet => false;

		public virtual bool SupportsStartRequested => false;

		public virtual bool SupportsRequireStartRequested => false;

		public virtual bool SupportsKeyPressObserved => false;

		public virtual bool SupportsPulse => false;

		public virtual bool CanSetResistance => false;

		public virtual bool CanSetGear => false;

		public virtual int WarmUpTimeoutSeconds => 0;

		public virtual int CoolDownTimeoutSeconds => 0;

		public virtual int PauseTimeoutSeconds => 0;

		public virtual int IdleTimeoutSeconds => 0;

		public virtual double TotalMeters => 0.0;

		public virtual double TotalTime => 0.0;

		public virtual double Weight => 0.0;
	}
	public static class EquipmentlessDeviceConstants
	{
		public const Manufacturer EquipmentlessDeviceManufacturer = Manufacturer.Ifit;

		public const ConsoleType EquipmentlessConsoleType = ConsoleType.Equipmentless;

		public const int EquipmentlessDeviceIdentifierNumber = 424992;

		public const string EquipmentlessDeviceIdentifierString = "Equipmentless";

		public const int EquipmentlessDevicePauseTimeout = 600;
	}
	public interface IEquipmentlessFitnessValueManager : IDisposable
	{
		IConsoleBasicInfo CurrentValues { get; }

		ConsoleState CurrentState { get; }

		bool IsPaused { get; }

		NonGenericObservable WhenWorkoutStarted { get; }

		NonGenericObservable WhenWorkoutEnded { get; }

		NonGenericObservable WhenWorkoutPaused { get; }

		NonGenericObservable WhenWorkoutResumed { get; }

		IObservable<IConsoleBasicInfo> WhenValuesUpdated { get; }

		IHeartRateHelper HeartRateHelper { get; set; }

		void Start();

		void Pause();

		void Resume();

		void SetWorkoutTimes(int warmupSeconds, int runningSeconds, int cooldownSeconds);

		void SetCooldownTimeout(int seconds);

		void ForceEndWorkout();

		void SkipWarmup();

		void SkipToCooldown();

		void SetTargetTime(int targetTimeSeconds);
	}
	public class EquipmentlessFitnessValueManager : IEquipmentlessFitnessValueManager, IDisposable
	{
		private const string Tag = "EquipmentlessConsole";

		private readonly IEquipmentlessWorkoutCalorieBurnEstimator calorieBurnEstimator;

		private bool isDisposed;

		private int pauseTimeoutSeconds;

		private double cumulativeBurnedCals;

		private bool isUsingHeartRateStrap;

		private Pulse pulse;

		private IList<double> estimatedCalorieBreakdown;

		private IDisposable timerSub;

		private IDisposable heartRateConnectionGainedSub;

		private IDisposable heartRateConnectionLostSub;

		private IDisposable heartRateConnectionChangedSub;

		private IDisposable heartRateUpdateSub;

		private EquipmentlessConsoleBasicInfo _currentValues;

		private Subject<IList<FitnessValue>> whenFitnessValueChanged;

		private readonly Subject<IConsoleBasicInfo> _whenValuesUpdated = new Subject<IConsoleBasicInfo>();

		private readonly NonGenericSubject _whenWorkoutStarted = new NonGenericSubject();

		private readonly NonGenericSubject _whenWorkoutEnded = new NonGenericSubject();

		private readonly NonGenericSubject _whenWorkoutPaused = new NonGenericSubject();

		private readonly NonGenericSubject _whenWorkoutResumed = new NonGenericSubject();

		private IHeartRateHelper _heartRateHelper;

		private ConsoleState currentState;

		private int currentSeconds;

		private Dictionary<ConsoleState, int> stateDurations;

		public IConsoleBasicInfo CurrentValues => _currentValues;

		private bool CountDownwards
		{
			get
			{
				if (currentState != ConsoleState.WarmUp)
				{
					return currentState == ConsoleState.CoolDown;
				}
				return true;
			}
		}

		public ConsoleState CurrentState
		{
			get
			{
				if (!isDisposed)
				{
					if (!IsPaused)
					{
						return currentState;
					}
					return ConsoleState.Paused;
				}
				return ConsoleState.Unknown;
			}
		}

		public bool IsPaused { get; private set; }

		public IObservable<IConsoleBasicInfo> WhenValuesUpdated => _whenValuesUpdated?.AsObservable();

		public NonGenericObservable WhenWorkoutStarted => _whenWorkoutStarted;

		public NonGenericObservable WhenWorkoutEnded => _whenWorkoutEnded;

		public NonGenericObservable WhenWorkoutPaused => _whenWorkoutPaused;

		public NonGenericObservable WhenWorkoutResumed => _whenWorkoutResumed;

		public IHeartRateHelper HeartRateHelper
		{
			get
			{
				return _heartRateHelper;
			}
			set
			{
				_heartRateHelper = value;
				ResetHeartRateHelperSubscribers(value);
			}
		}

		public EquipmentlessFitnessValueManager(IEquipmentlessWorkoutCalorieBurnEstimator calorieBurnEstimator)
		{
			this.calorieBurnEstimator = calorieBurnEstimator;
			estimatedCalorieBreakdown = GenerateEstimatedCalorieBreakdown();
			stateDurations = new Dictionary<ConsoleState, int>();
			whenFitnessValueChanged = new Subject<IList<FitnessValue>>();
			_currentValues = CreateDefaultValues(whenFitnessValueChanged.AsObservable());
			currentState = ConsoleState.Idle;
			_currentValues.CurrentState = currentState;
		}

		private IList<double> GenerateEstimatedCalorieBreakdown()
		{
			int num = Convert.ToInt32(Math.Ceiling(calorieBurnEstimator.WorkoutDuration));
			List<double> list = new List<double>(num);
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				double num3 = calorieBurnEstimator.CaloriesBurnedAt(i + 1) - num2;
				num2 += num3;
				list.Add(num3);
			}
			return list;
		}

		private EquipmentlessConsoleBasicInfo CreateDefaultValues(IObservable<IList<FitnessValue>> whenBitFieldChangedObservable)
		{
			return EquipmentlessConsoleBasicInfo.CreateDefaultsWithFieldChangedObservable(whenBitFieldChangedObservable);
		}

		public void SetWorkoutTimes(int warmupSeconds, int runningSeconds, int cooldownSeconds)
		{
			if (!isDisposed)
			{
				stateDurations.Clear();
				stateDurations.Add(ConsoleState.WarmUp, warmupSeconds);
				_currentValues.WarmUpTimeoutSeconds = warmupSeconds;
				stateDurations.Add(ConsoleState.WorkoutResults, runningSeconds);
				_currentValues.GoalTime = runningSeconds;
				stateDurations.Add(ConsoleState.CoolDown, cooldownSeconds);
				_currentValues.CoolDownTimeoutSeconds = cooldownSeconds;
				pauseTimeoutSeconds = 600;
			}
		}

		public void SetCooldownTimeout(int seconds)
		{
			if (stateDurations.ContainsKey(ConsoleState.CoolDown))
			{
				stateDurations[ConsoleState.CoolDown] = seconds;
			}
			else
			{
				stateDurations.Add(ConsoleState.CoolDown, seconds);
			}
			_currentValues.CoolDownTimeoutSeconds = seconds;
		}

		public void Start()
		{
			if (!isDisposed)
			{
				if (currentState != ConsoleState.Idle)
				{
					Log.Warn("EquipmentlessConsole", "Could not start EquipmentlessFitnessValueManager workout in non-idle state.");
					return;
				}
				cumulativeBurnedCals = 0.0;
				AdvanceToNextStateOrEnd();
			}
		}

		public void Pause()
		{
			if (!isDisposed && !IsPaused)
			{
				if (!stateDurations.ContainsKey(ConsoleState.Paused))
				{
					stateDurations.Add(ConsoleState.Paused, pauseTimeoutSeconds);
				}
				else
				{
					stateDurations[ConsoleState.Paused] = pauseTimeoutSeconds;
				}
				IsPaused = true;
				UpdateCurrentValues();
				_whenWorkoutPaused.OnNext();
			}
		}

		public void Resume()
		{
			if (!isDisposed && IsPaused)
			{
				IsPaused = false;
				UpdateCurrentValues();
				_whenWorkoutResumed.OnNext();
			}
		}

		private void InitiateStateChange(ConsoleState newState, IEnumerable<ConsoleState> acceptableCurrentStates, bool startTimer)
		{
			if (isDisposed)
			{
				return;
			}
			if (acceptableCurrentStates == null || !acceptableCurrentStates.Contains(currentState))
			{
				Log.Warn("EquipmentlessConsole", string.Format("Tried to move to state {0}, but the {1} was in unacceptable state {2}.", newState, "EquipmentlessFitnessValueManager", currentState));
				return;
			}
			currentState = newState;
			currentSeconds = 0;
			UpdateCurrentValues();
			timerSub?.Dispose();
			if (startTimer)
			{
				timerSub = GenerateTimerTickObservable()?.SubscribeWithErrorLogging(OnTimerTicked);
			}
		}

		protected virtual IObservable<long> GenerateTimerTickObservable()
		{
			return Observable.Timer(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0));
		}

		private void OnTimerTicked(long timerTime)
		{
			if (isDisposed)
			{
				return;
			}
			if (IsPaused)
			{
				stateDurations[ConsoleState.Paused]--;
				if (stateDurations[ConsoleState.Paused] <= 0)
				{
					ForceEndWorkout();
				}
				return;
			}
			currentSeconds++;
			UpdateCurrentValues();
			if (stateDurations.ContainsKey(currentState))
			{
				stateDurations[currentState]--;
				if (stateDurations[currentState] <= 0)
				{
					AdvanceToNextStateOrEnd();
				}
			}
		}

		public void ForceEndWorkout()
		{
			if (!isDisposed)
			{
				ResetStateToIdle();
				_whenWorkoutEnded?.OnNext();
			}
		}

		public void SkipWarmup()
		{
			if (!isDisposed)
			{
				InitiateStateChange(ConsoleState.Workout, new ConsoleState[1] { ConsoleState.WarmUp }, startTimer: true);
			}
		}

		public void SkipToCooldown()
		{
			if (!isDisposed)
			{
				InitiateStateChange(ConsoleState.CoolDown, new ConsoleState[1] { ConsoleState.Workout }, startTimer: true);
			}
		}

		public void SetTargetTime(int targetTimeSeconds)
		{
			if (_currentValues != null)
			{
				_currentValues.GoalTime = targetTimeSeconds;
			}
		}

		private void ResetStateToIdle()
		{
			timerSub?.Dispose();
			timerSub = null;
			currentSeconds = 0;
			currentState = ConsoleState.Idle;
			IsPaused = false;
			UpdateCurrentValues();
		}

		private void AdvanceToNextStateOrEnd()
		{
			if (!isDisposed)
			{
				switch (currentState)
				{
				case ConsoleState.Idle:
					InitiateStateChange(ConsoleState.WarmUp, new ConsoleState[1] { ConsoleState.Idle }, startTimer: true);
					_whenWorkoutStarted?.OnNext();
					break;
				case ConsoleState.WarmUp:
					SkipWarmup();
					break;
				case ConsoleState.Workout:
					SkipToCooldown();
					break;
				case ConsoleState.CoolDown:
					ResetStateToIdle();
					break;
				case ConsoleState.Paused:
				case ConsoleState.WorkoutResults:
				case ConsoleState.SafetyKeyRemoved:
					break;
				}
			}
		}

		private void UpdateCurrentValues()
		{
			if (!isDisposed)
			{
				if (_currentValues != null && _currentValues.CurrentState != CurrentState)
				{
					_currentValues.CurrentState = CurrentState;
					whenFitnessValueChanged?.OnNext(new List<FitnessValue> { FitnessValue.WorkoutMode });
				}
				int valueSafely = currentSeconds;
				if (CountDownwards)
				{
					valueSafely = stateDurations.GetValueSafely(currentState, 0);
				}
				if (_currentValues != null && _currentValues.CurrentTime != valueSafely)
				{
					_currentValues.CurrentTime = valueSafely;
					whenFitnessValueChanged?.OnNext(new List<FitnessValue> { FitnessValue.CurrentTime });
				}
				if (pulse != null && _currentValues != null)
				{
					_currentValues.CurrentPulse = pulse;
					whenFitnessValueChanged?.OnNext(new List<FitnessValue> { FitnessValue.Pulse });
				}
				UpdateCalorieBurnBitFieldByState();
				UpdateTimeBitFieldByState();
				_whenValuesUpdated?.OnNext(_currentValues);
			}
		}

		private void UpdateCalorieBurnBitFieldByState()
		{
			double calories = 0.0;
			if (CurrentState == ConsoleState.Workout)
			{
				cumulativeBurnedCals += CalsBurnedLastSecond();
				calories = cumulativeBurnedCals;
			}
			if (_currentValues != null)
			{
				_currentValues.Calories = calories;
			}
			whenFitnessValueChanged?.OnNext(new List<FitnessValue> { FitnessValue.CurrentCalories });
		}

		private double CalsBurnedLastSecond()
		{
			if (currentSeconds < 1)
			{
				return 0.0;
			}
			if (isUsingHeartRateStrap)
			{
				Pulse obj = pulse;
				if (obj != null && obj.UserPulse > 0)
				{
					return CalorieFormulas.HeartRate(1.0, pulse.UserPulse, calorieBurnEstimator.UserWeightKg, calorieBurnEstimator.UserAge, calorieBurnEstimator.UserMale);
				}
			}
			try
			{
				return estimatedCalorieBreakdown[currentSeconds - 1];
			}
			catch (Exception exception)
			{
				Log.Error("EquipmentlessConsole", "Could not look up estimated caloric burn.", exception);
			}
			return 0.0;
		}

		private void UpdateTimeBitFieldByState()
		{
			switch (currentState)
			{
			case ConsoleState.WarmUp:
				_currentValues.CurrentTime = stateDurations.GetValueSafely(ConsoleState.WarmUp, 0);
				whenFitnessValueChanged.OnNext(new List<FitnessValue> { FitnessValue.CurrentTime });
				break;
			case ConsoleState.Workout:
				_currentValues.RunningTime = currentSeconds;
				whenFitnessValueChanged.OnNext(new List<FitnessValue> { FitnessValue.RunningTime });
				break;
			case ConsoleState.CoolDown:
				_currentValues.CurrentTime = stateDurations.GetValueSafely(ConsoleState.CoolDown, 0);
				whenFitnessValueChanged.OnNext(new List<FitnessValue> { FitnessValue.CurrentTime });
				break;
			}
		}

		private void ResetHeartRateHelperSubscribers(IHeartRateHelper heartRateHelper)
		{
			DisposeHeartRateHelperSubscribers();
			if (heartRateHelper == null)
			{
				return;
			}
			heartRateConnectionGainedSub = heartRateHelper.WhenConnectionChanged.Where((bool connected) => connected).Take(1).SubscribeWithErrorLogging(delegate
			{
				heartRateUpdateSub = heartRateHelper.WhenStrapHeartRateUpdated.Where((int y) => y > 0).SubscribeWithErrorLogging(delegate
				{
					HandleHeartRateConnectionEstablished(_: true);
				});
			});
			heartRateConnectionLostSub = heartRateHelper.WhenConnectionChanged.Where((bool connected) => !connected).Subscribe(delegate
			{
				HandleHeartRateConnectionLost(_: true);
			});
			heartRateConnectionChangedSub = heartRateHelper.WhenStrapHeartRateUpdated.SubscribeWithErrorLogging(HandleHeartRateConnectionUpdated);
		}

		private void HandleHeartRateConnectionUpdated(int newBpm)
		{
			if (newBpm > 0)
			{
				if (pulse == null)
				{
					pulse = new Pulse(newBpm, newBpm, 1, Pulse.Source.Ble);
					return;
				}
				pulse.Count++;
				pulse.UserPulse = newBpm;
				pulse.Average = Convert.ToInt32(Math.Round(1.0 * (double)pulse.Average * (double)(pulse.Count - 1) / (double)pulse.Count + 1.0 * (double)newBpm / (double)pulse.Count));
			}
		}

		private void HandleHeartRateConnectionEstablished(bool _)
		{
			isUsingHeartRateStrap = true;
		}

		private void HandleHeartRateConnectionLost(bool _)
		{
			isUsingHeartRateStrap = false;
			pulse = null;
			_currentValues.CurrentPulse = null;
			whenFitnessValueChanged.OnNext(new List<FitnessValue> { FitnessValue.Pulse });
		}

		private void DisposeHeartRateHelperSubscribers()
		{
			heartRateConnectionGainedSub?.Dispose();
			heartRateConnectionGainedSub = null;
			heartRateConnectionLostSub?.Dispose();
			heartRateConnectionLostSub = null;
			heartRateConnectionChangedSub?.Dispose();
			heartRateConnectionChangedSub = null;
			heartRateUpdateSub?.Dispose();
			heartRateUpdateSub = null;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				ResetStateToIdle();
				if (disposing)
				{
					stateDurations?.Clear();
					stateDurations = null;
					estimatedCalorieBreakdown?.Clear();
					estimatedCalorieBreakdown = null;
					whenFitnessValueChanged?.Dispose();
					whenFitnessValueChanged = null;
					DisposeHeartRateHelperSubscribers();
					_heartRateHelper = null;
					_currentValues?.Dispose();
					_currentValues = null;
				}
				isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
	public interface IEquipmentlessWorkoutCalorieBurnEstimator
	{
		double WorkoutDuration { get; }

		double AverageWorkoutHeartRate { get; }

		double UserWeightKg { get; }

		double UserAge { get; }

		bool UserMale { get; }

		double CaloriesBurnedAt(double seconds);
	}
	public class StrengthWorkoutCalorieBurnEstimator : IEquipmentlessWorkoutCalorieBurnEstimator, IDisposable
	{
		private bool isDisposed;

		public IReadOnlyList<WorkoutSegment> WorkoutSegments { get; private set; }

		public double WorkoutDuration { get; private set; }

		public double AverageWorkoutHeartRate { get; private set; } = 125.0;

		public double UserWeightKg { get; private set; } = 83.91;

		public double UserAge { get; private set; } = 35.0;

		public bool UserMale { get; private set; } = true;

		protected StrengthWorkoutCalorieBurnEstimator()
		{
		}

		public static StrengthWorkoutCalorieBurnEstimator FromWorkout(bool isStrength, bool isTimeGoal, IList<WorkoutSegment> segments, double userKg, double userAge, bool userMale, double? averageHeartRate)
		{
			if (!isStrength || !isTimeGoal)
			{
				throw new ArgumentException("Provided workout was not a Strength type workout.", "isStrength");
			}
			List<WorkoutSegment> list = segments.ToList();
			return new StrengthWorkoutCalorieBurnEstimator
			{
				AverageWorkoutHeartRate = (averageHeartRate ?? 125.0),
				WorkoutSegments = list,
				WorkoutDuration = list.Sum((WorkoutSegment x) => x.Seconds),
				UserWeightKg = userKg,
				UserAge = userAge,
				UserMale = userMale
			};
		}

		public double CaloriesBurnedAt(double seconds)
		{
			if (isDisposed)
			{
				return 0.0;
			}
			if (seconds <= 0.0)
			{
				return 0.0;
			}
			if (seconds >= WorkoutDuration)
			{
				return WorkoutSegments.Sum((WorkoutSegment x) => x.EstimateCaloriesByEstimatedHeartRate(UserWeightKg, UserAge, UserMale));
			}
			double num = 0.0;
			double num2 = 0.0;
			foreach (WorkoutSegment workoutSegment in WorkoutSegments)
			{
				if (seconds < num)
				{
					break;
				}
				double num3 = num + workoutSegment.Seconds;
				if (!(num3 <= num))
				{
					double num4 = workoutSegment.EstimateCaloriesByEstimatedHeartRate(UserWeightKg, UserAge, UserMale);
					double num5 = 1.0;
					if (seconds >= num && seconds <= num3)
					{
						num5 = ((seconds - num) / workoutSegment.Seconds).Clamp(0.0, 1.0);
					}
					num2 += num5 * num4;
					num = num3;
				}
			}
			return num2;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				WorkoutSegments = null;
				isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
	public class StrengthWorkoutEquipmentlessConsole : EquipmentlessConsoleBase
	{
		public StrengthWorkoutEquipmentlessConsole(StrengthWorkoutCalorieBurnEstimator calorieBurnEstimator)
			: base(calorieBurnEstimator)
		{
		}
	}
}
namespace Sindarin.Core.Console.Decorators
{
	public class CalorieMultiplierDecorator : IFitnessValueDecorator, ICalorieMultiplierRecoverable
	{
		private readonly List<CalorieMultiplierEvent> calorieMultiplierEvents;

		private double previousSecondRawCalories;

		private double previousSecondDecoratedCalories;

		public CalorieMultiplierDecorator(List<CalorieMultiplierEvent> calorieMultiplierEvents)
		{
			this.calorieMultiplierEvents = calorieMultiplierEvents;
		}

		public bool CanDecorate(FitnessValue value, double newValue, IConsoleBasicInfo info)
		{
			if (value == FitnessValue.CurrentCalories)
			{
				return info.CurrentState == ConsoleState.Workout;
			}
			return false;
		}

		public double DecorateChange(FitnessValue value, double newValue, IConsoleBasicInfo info)
		{
			double result = CalorieMultiplierCalculator.CalculateOffEquipmentBeltMachineCalories(info.TimeSeconds, newValue, previousSecondRawCalories, previousSecondDecoratedCalories, calorieMultiplierEvents, info.Kph);
			previousSecondRawCalories = newValue;
			previousSecondDecoratedCalories = result;
			return result;
		}

		public CalorieMultiplierRecoveryInfo GetRecoveryInfo()
		{
			return new CalorieMultiplierRecoveryInfo
			{
				PreviousRawCalories = previousSecondRawCalories,
				PreviousDecoratedCalories = previousSecondDecoratedCalories
			};
		}

		public void Recover(CalorieMultiplierRecoveryInfo recoveryInfo)
		{
			previousSecondRawCalories = recoveryInfo.PreviousRawCalories;
			previousSecondDecoratedCalories = recoveryInfo.PreviousDecoratedCalories;
		}
	}
	public interface IFitnessValueDecorator
	{
		bool CanDecorate(FitnessValue value, double newValue, IConsoleBasicInfo info);

		double DecorateChange(FitnessValue value, double newValue, IConsoleBasicInfo info);
	}
}
namespace Sindarin.Core.Connection
{
	public abstract class BaseConnection
	{
		protected readonly Subject<byte[]> whenValueUpdated = new Subject<byte[]>();

		protected readonly Subject<bool> whenConnectionStateChanged = new Subject<bool>();

		protected readonly Subject<bool> whenInitialized = new Subject<bool>();

		private bool _initialized;

		public IObservable<byte[]> WhenValueUpdated => whenValueUpdated;

		public IObservable<bool> WhenConnectionStateChanged => whenConnectionStateChanged.AsObservable();

		public IObservable<bool> WhenInitialized => whenInitialized;

		public bool Initialized
		{
			get
			{
				return _initialized;
			}
			protected set
			{
				_initialized = value;
				Log.Trace("Connection", $"Connection initialized: {value}");
				whenInitialized.OnNext(_initialized);
			}
		}
	}
	public enum ConnectionType
	{
		USB,
		BLE,
		TCP,
		IoT,
		None
	}
	public interface IClearBuffer
	{
		Task ClearBuffer();
	}
	public interface IDeviceConnection : IDisposable
	{
		TimeSpan Timeout { get; }

		bool Initialized { get; }

		IObservable<bool> WhenInitialized { get; }

		IObservable<byte[]> WhenValueUpdated { get; }

		IObservable<bool> WhenConnectionStateChanged { get; }

		Task SendBytes(byte[] bytes);

		Task SendBytesWithReadDelay(byte[] bytes, TimeSpan delay);

		Task<bool> Disconnect();

		Task ReadBytesWithDelay(TimeSpan delay);
	}
	public enum MockType
	{
		Wearable,
		Treadmill,
		Bike,
		HeadlessBike,
		Elliptical,
		VerticalElliptical,
		FreeStrider,
		SpinBike,
		InclineBike,
		Rower,
		Hybrid,
		Strength,
		Yoga,
		Mind,
		Nutrition,
		Core,
		Sleep,
		Stretch
	}
	public class MockConnection : BaseConnection, IDeviceConnection, IDisposable
	{
		private readonly Subject<byte[]> whenSentBytesWithReadDelay = new Subject<byte[]>();

		public IObservable<byte[]> WhenSentBytesWithReadDelay => whenSentBytesWithReadDelay;

		public TimeSpan Timeout { get; } = TimeSpan.FromMilliseconds(100.0);

		public MockConnection()
		{
			base.Initialized = true;
		}

		public async Task<bool> Disconnect()
		{
			return await Task.FromResult(result: true);
		}

		public async Task ReadBytesWithDelay(TimeSpan delay)
		{
			await Task.Delay(0);
		}

		public async Task SendBytes(byte[] bytes)
		{
			await Task.Delay(0);
		}

		public void Dispose()
		{
		}

		public Task SendBytesWithReadDelay(byte[] bytes, TimeSpan delay)
		{
			whenSentBytesWithReadDelay.OnNext(bytes);
			return Task.CompletedTask;
		}

		public void WhenValueUpdated_OnNext(byte[] value)
		{
			whenValueUpdated.OnNext(value);
		}
	}
	public abstract class RetryingConnection : BaseConnection, IDeviceConnection, IDisposable
	{
		private class RetryingConnectionReadException : Exception
		{
			public RetryingConnectionReadException()
				: base("Failed to read from device")
			{
			}
		}

		protected const int MaxBytesPerRequest = 64;

		private const int MaxReadAttempts = 10;

		private const int MaxWriteAttempts = 50;

		private int failedWriteCount;

		private readonly Queue<SendPacket> PendingWrites = new Queue<SendPacket>();

		private readonly string logTag;

		private readonly AsyncRetryPolicy sendAndReadRetryPolicy;

		private bool isWriting;

		private long successfulReads;

		public int PendingWriteCount => PendingWrites.Count;

		public abstract TimeSpan Timeout { get; }

		protected abstract bool ShouldCheckQueue { get; }

		protected RetryingConnection(string logTag)
		{
			this.logTag = logTag;
			sendAndReadRetryPolicy = Policy.Handle<RetryingConnectionReadException>().RetryAsync(10, delegate(Exception exception, int attempts)
			{
				if (attempts > 3)
				{
					Log.Trace(logTag, $"Failed to read device. Attempted {attempts} times");
				}
			});
		}

		public abstract Task<bool> Disconnect();

		public abstract void Dispose();

		public Task SendBytes(byte[] bytes)
		{
			return SendBytesWithReadDelay(bytes, default(TimeSpan));
		}

		public async Task SendBytesWithReadDelay(byte[] bytes, TimeSpan delay)
		{
			SendPacket(new SendPacket(bytes, reply: true, delay));
		}

		public async Task ReadBytesWithDelay(TimeSpan delay)
		{
			byte[] replyData = new byte[64];
			await Task.Delay(delay);
			await DoBulkReadAsync(replyData);
			whenValueUpdated.OnNext(replyData);
		}

		public void SendPacket(SendPacket packet)
		{
			if (packet == null)
			{
				throw new ArgumentNullException("packet", "Do not waste RetryingConnection's time with nonsense.");
			}
			PendingWrites.Enqueue(packet);
			CheckQueue(0);
		}

		protected void CheckQueue(int retryCount)
		{
			if (ShouldCheckQueue && base.Initialized && !isWriting && PendingWrites.Count != 0)
			{
				isWriting = true;
				SendAndReadWithRetry(retryCount);
			}
		}

		private async Task SendAndReadWithRetry(int retryCount)
		{
			SendPacket sendPacket = PendingWrites.Peek();
			try
			{
				if (sendPacket != null && sendPacket.Bytes.IsValid())
				{
					await sendAndReadRetryPolicy.ExecuteAsync(async () => await ReadWrite(sendPacket));
				}
				else
				{
					Log.Error(logTag, "To send data, there must first be some data, instead Bytes is " + ((sendPacket?.Bytes == null) ? "null" : "empty"));
					DequeuePacket();
				}
				retryCount = 0;
			}
			catch (RetryingConnectionReadException)
			{
				string arg = ((sendPacket?.Bytes == null) ? "null" : BitConverter.ToString(sendPacket.Bytes));
				Log.Error(logTag, $"Got {10} failures reading bulk reply, giving up. Bytes sent={arg}");
				DequeuePacket();
				retryCount = 0;
			}
			catch (Exception ex2)
			{
				Log.Error(logTag, ex2.Message);
				Log.Error(logTag, ex2.StackTrace);
				retryCount++;
			}
			finally
			{
				isWriting = false;
				if (retryCount < 10)
				{
					CheckQueue(retryCount);
				}
			}
		}

		private void DequeuePacket()
		{
			if (PendingWrites.Count > 0)
			{
				PendingWrites.Dequeue();
			}
		}

		private async Task<byte[]> ReadWrite(SendPacket packet)
		{
			if (await SendWriteRequest(packet.Bytes))
			{
				failedWriteCount = 0;
				if (packet.GetReply)
				{
					if (packet.ReadDelay > TimeSpan.Zero)
					{
						await Task.Delay(packet.ReadDelay);
					}
					byte[] array = await SendReadRequest();
					if (array != null && array.Length != 0)
					{
						if (++successfulReads % 25 == 0L)
						{
							Log.Trace(logTag, $"Successful Read Requests: {successfulReads}");
						}
						DequeuePacket();
						whenValueUpdated.OnNext(array);
						return array;
					}
				}
				else
				{
					DequeuePacket();
				}
			}
			else if (++failedWriteCount >= 50)
			{
				Log.Error(logTag, "Write request failed, request bytes: " + BitConverter.ToString(packet.Bytes));
				failedWriteCount = 0;
			}
			return null;
		}

		protected abstract Task<int> DoBulkWriteAsync(byte[] buffer);

		private async Task<bool> SendWriteRequest(byte[] bytes)
		{
			if (!bytes.IsValid())
			{
				return false;
			}
			return await DoBulkWriteAsync(bytes) >= 0;
		}

		protected abstract Task<int> DoBulkReadAsync(byte[] buffer);

		private async Task<byte[]> SendReadRequest()
		{
			byte[] replyData = new byte[64];
			if (await DoBulkReadAsync(replyData) == -1)
			{
				throw new RetryingConnectionReadException();
			}
			return replyData;
		}
	}
	public class SendPacket
	{
		public byte[] Bytes { get; }

		public bool GetReply { get; }

		public TimeSpan ReadDelay { get; }

		public SendPacket(byte[] bytes, bool reply, TimeSpan readDelay)
		{
			Bytes = bytes;
			GetReply = reply;
			ReadDelay = readDelay;
		}
	}
}
namespace Sindarin.Core.Communication
{
	public class DynamicDelay
	{
		private const string Tag = "CommunicationDelay";

		private const int DefaultWindow = 100;

		private readonly int window;

		private readonly TimeSpan adjustment;

		private readonly TimeSpan maximumDelay;

		private int currentMinimumDelay;

		private int windowProgress;

		public TimeSpan CurrentDelay { get; private set; }

		public DynamicDelay(int adjustmentMillis, int maxDelayMillis, int window = 100)
		{
			adjustment = TimeSpan.FromMilliseconds(adjustmentMillis);
			maximumDelay = TimeSpan.FromMilliseconds(maxDelayMillis);
			CurrentDelay = maximumDelay;
			this.window = window;
		}

		public void IncreaseIfBelowMaximum(int currentCount)
		{
			windowProgress = currentCount;
			if (!(CurrentDelay >= maximumDelay))
			{
				CurrentDelay = CurrentDelay.Add(adjustment);
				currentMinimumDelay = CurrentDelay.Milliseconds;
				Log.Trace("CommunicationDelay", $"Updating delay to {CurrentDelay.Milliseconds}ms");
			}
		}

		public void DecreaseIfAboveMinimum(int currentCount)
		{
			if (currentCount > windowProgress + window && CurrentDelay.Milliseconds > currentMinimumDelay)
			{
				CurrentDelay = CurrentDelay.Subtract(adjustment);
				windowProgress = currentCount;
				Log.Trace("CommunicationDelay", $"Updating delay to {CurrentDelay.Milliseconds}ms");
			}
		}
	}
	public interface ICommunication
	{
		bool IsComplete { get; }

		int ShouldRetryCount { get; }

		TimeSpan Timeout { get; set; }

		TimeSpan ReadDelay { get; }

		ConnectionType Format { get; set; }

		void ReceiveComplete();

		void ReceiveFailed();
	}
	public interface ICommunicationAdapter : IDisposable
	{
		ConnectionType ConnectionType { get; }

		TimeSpan DefaultTimeout { get; }

		IObservable<bool> WhenCommsFailed { get; }

		IDeviceConnection Connection { get; }
	}
	public interface ICommunicationAdapter<TResult, TComm> : ICommunicationAdapter, IDisposable
	{
		Task<TResult> Fetch(TComm comm);
	}
	public class EquipmentException : Exception
	{
		public EquipmentException(string message)
			: base(message)
		{
		}
	}
}
namespace Sindarin.Core.Communication.Logging
{
	public interface IFitProBytesLogger
	{
		void LogBytes(byte[] bytes, PacketType packetType);
	}
	public enum PacketType
	{
		Request,
		Response
	}
}
namespace Sindarin.Core.HeartRate
{
	public enum HeartRateBodyLocation
	{
		Other,
		Chest,
		Wrist,
		Finger,
		Hand,
		Ear,
		Foot
	}
	public interface IHeartRateConnection : IDisposable
	{
		HeartRateBodyLocation BodyLocation { get; }

		IObservable<int> WhenHeartRateChange { get; }

		bool Initialized { get; }

		IObservable<bool> WhenInitialized { get; }

		IBleDevice Device { get; }
	}
	public class HeartRateConnection : BaseConnection, IHeartRateConnection, IDisposable
	{
		private const string Tag = "HeartRateConnection";

		private const string ConnectionTag = "BleConnection";

		private const int MaxServiceRetries = 5;

		protected readonly Subject<int> whenHeartRateChange = new Subject<int>();

		private ICharacteristic hrDataCharacteristic;

		private IDisposable hrSub;

		private IDisposable connectedSub;

		private int connectedCount;

		private int lastHeartRate;

		private bool disposedValue;

		private bool receivedHeartRateUpdateAfterConnecting;

		public IObservable<int> WhenHeartRateChange => whenHeartRateChange;

		public HeartRateBodyLocation BodyLocation { get; private set; }

		public IBleDevice Device { get; set; }

		public HeartRateConnection(IBleDevice device, IBleRadioStatusService bluetoothStatusService)
		{
			HeartRateConnection heartRateConnection = this;
			Device = device;
			connectedSub = Device.WhenStateChanged.Where((DeviceState x) => x == DeviceState.Connected || x == DeviceState.LostConnection).Publish((IObservable<DeviceState> p) => p.Take(1).Concat(p.Throttle(TimeSpan.FromMilliseconds(50.0)))).SubscribeAsync(HandleConnectedAsync);
			if (device.State == DeviceState.Connected)
			{
				Task.Run(async delegate
				{
					await heartRateConnection.HandleConnectedAsync(device.State);
				});
			}
			else
			{
				Device.Connect();
			}
		}

		private async Task HandleConnectedAsync(DeviceState state)
		{
			try
			{
				if (state == DeviceState.LostConnection)
				{
					Log.Warn("BleConnection", "Device " + Device?.Name + " initialization failed because device lost connection");
					Device?.Disconnect();
					base.Initialized = false;
					return;
				}
				await Connected();
			}
			catch (Exception ex) when (ex is TimeoutException || ex is ReadFailedException || ex is ConnectionException)
			{
				Log.Error("BleConnection", "Device " + Device?.Name + " Reconnect exception: " + ex.Message);
				bool flag = Device != null;
				if (flag)
				{
					flag = !(await Device.Disconnect());
				}
				if (flag)
				{
					Log.Error("BleConnection", "Device " + Device?.Name + " recovery disconnect operation timed out");
				}
			}
			catch (Exception exception)
			{
				Log.Error("BleConnection", "Device " + Device?.Name + " Exception initializing console", exception);
				throw;
			}
		}

		protected async Task Connected()
		{
			if (++connectedCount > 1)
			{
				if (Device != null)
				{
					Log.Trace("HeartRateConnection", "Disconnecting on connect because already connected");
					await Device.Disconnect();
				}
				return;
			}
			List<IService> services = null;
			int i = 1;
			while (services == null && i <= 5)
			{
				try
				{
					services = await Device.GetServices();
				}
				catch (Exception e)
				{
					string text = ((i + 1 <= 5) ? $"Attemps: {i}" : "Failed too many times, aborting.");
					Log.Trace("HeartRateConnection", "Getting heart rate services failed due to " + e.ToConciseString() + ". " + text);
				}
				i++;
			}
			receivedHeartRateUpdateAfterConnecting = false;
			if (IsNull(services, "services are null"))
			{
				return;
			}
			try
			{
				IService service = services.FirstOrDefault((IService x) => x.Id.Equals(KnownServices.HeartRate.Id));
				if (IsNull(service, "heartRateService is null"))
				{
					return;
				}
				List<ICharacteristic> list = await service.GetCharacteristics();
				if (IsNull(list, "characteristics are null"))
				{
					return;
				}
				ICharacteristic characteristic = list.FirstOrDefault((ICharacteristic x) => x.Id.Equals(KnownCharacteristics.BodySensorLocation.Id));
				if (characteristic != null)
				{
					BodyLocation = (HeartRateBodyLocation)characteristic.PropertiesRaw;
				}
				hrDataCharacteristic = list.FirstOrDefault((ICharacteristic x) => x.Id.Equals(KnownCharacteristics.HeartRateMeasurement.Id));
				if (IsNull(hrDataCharacteristic, "hrDataCharacteristic is null"))
				{
					return;
				}
				hrSub?.Dispose();
				hrSub = hrDataCharacteristic.WhenDataChanged.Subscribe(HeartRateDataUpdate);
				try
				{
					await hrDataCharacteristic.StartUpdates();
				}
				catch (TimeoutException exception)
				{
					if (!receivedHeartRateUpdateAfterConnecting)
					{
						Log.Error("HeartRateConnection", "hrDataCharacteristic.StartUpdates() timed out without receiving a heart rate", exception);
						return;
					}
					Log.Trace("HeartRateConnection", "hrDataCharacteristic.StartUpdates() but we received a heart rate");
				}
				base.Initialized = true;
			}
			catch (Exception e2)
			{
				Device?.Disconnect();
				Log.Error("HeartRateConnection", "Error in HeartRateConnection.Connected(): " + e2.ToConciseString());
			}
			bool IsNull(object something, string reason)
			{
				if (something != null)
				{
					return false;
				}
				Device?.Disconnect(forced: true);
				Log.Error("HeartRateConnection", "Failed to connect in HeartRateConnection.Connected(): " + reason);
				return true;
			}
		}

		private void HeartRateDataUpdate(byte[] bytes)
		{
			if (bytes != null && bytes.Length > 1)
			{
				int num = bytes[1];
				if (lastHeartRate != num || lastHeartRate != 0)
				{
					receivedHeartRateUpdateAfterConnecting = true;
					lastHeartRate = num;
					Log.Trace("HeartRateConnection", $"HeartRateConnection.HeartRateDataUpdate heart rate value changed. Value: {num} Device: {Device?.Name}");
					whenHeartRateChange.OnNext(num);
				}
			}
			else
			{
				Log.Error("HeartRateConnection", "Error in HeartRateConnection.HeartRateDataUpdate(), heart rate was not passed in correctly");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					hrSub?.Dispose();
					Log.Trace("BleConnection", "Disconnecting device " + Device?.Name + " in HeartRateConnection on Dispose");
					Device?.Disconnect();
					Device = null;
					connectedSub?.Dispose();
					connectedSub = null;
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class HeartRateDeviceFilter : BaseDeviceFilter
	{
		protected override bool SatisfiesAdditionalConditions(IBleDevice device)
		{
			return device.SupportedServices.Contains(KnownServices.HeartRate);
		}
	}
	public interface IHeartRateHelper : IDisposable
	{
		IFitnessConsole Console { get; set; }

		IBleDevice CurrentlyConnectedDevice { get; }

		IHeartRateConnection HeartRateConnection { get; }

		IObservable<bool> WhenConnectionChanged { get; }

		IObservable<int> WhenStrapHeartRateUpdated { get; }

		IObservable<int> MaxHeartRateChanged { get; }

		bool IsConnected { get; }

		int MaxHeartRate { get; }

		bool IsScanning { get; }

		bool ReconnectOnLostConnection { get; set; }

		void Manage(IHeartRateConnection connection);

		Task ScanAndConnectToHeartRateDevice(bool delayScan = false, TimeSpan scanTimeout = default(TimeSpan));

		void StopScanning();

		void ForceHeartRateDisconnect();

		Task<bool> RemoveBond();
	}
	public interface IHeartRateHelperFlags
	{
		bool IsBondedHrMonitorEnabled();
	}
	public abstract class HeartRateHelperBase : IHeartRateHelper, IDisposable
	{
		protected const string Tag = "HeartRateHelper";

		protected static readonly TimeSpan DefaultHeartRateScanTimeout = TimeSpan.FromSeconds(15.0);

		protected static readonly TimeSpan DefaultDelayBetweenScans = TimeSpan.FromSeconds(45.0);

		protected static readonly TimeSpan OnDisconnectStartScanDelay = TimeSpan.FromSeconds(5.0);

		protected readonly TimeSpan delayBetweenScans;

		private static readonly TimeSpan minIntervalBetweenSendingPulseThroughFacade = TimeSpan.FromSeconds(1.0);

		private DateTime lastPulseSentThroughFacadeTimestamp = DateTime.MinValue;

		protected readonly BehaviorSubject<bool> _whenConnectionChanged = new BehaviorSubject<bool>(value: false);

		protected readonly Subject<int> _whenStrapHeartRateUpdated = new Subject<int>();

		private readonly Subject<int> _maxHeartRateChanged = new Subject<int>();

		protected readonly IPulseFacade pulseFacade;

		protected bool isDisposed;

		protected bool bleConnected;

		private int _lastPulse;

		public IObservable<bool> WhenConnectionChanged => _whenConnectionChanged;

		public IObservable<int> WhenStrapHeartRateUpdated => _whenStrapHeartRateUpdated;

		public IObservable<int> MaxHeartRateChanged => _maxHeartRateChanged;

		public int MaxHeartRate { get; private set; }

		public bool IsScanning { get; protected set; }

		protected int LastPulse
		{
			get
			{
				return _lastPulse;
			}
			set
			{
				if (value == _lastPulse)
				{
					return;
				}
				if (DateTime.Now - lastPulseSentThroughFacadeTimestamp < minIntervalBetweenSendingPulseThroughFacade)
				{
					Log.Trace("HeartRateHelper", $"Ignoring attempt to set Pulse value ({value}). Too many values");
					return;
				}
				if (bleConnected || (value == 0 && _lastPulse != 0))
				{
					Pulse pulse = new Pulse(value, 0, 0, Pulse.Source.Ble);
					pulseFacade.SetPulse(pulse);
					lastPulseSentThroughFacadeTimestamp = DateTime.Now;
				}
				_whenStrapHeartRateUpdated.OnNext(value);
				_lastPulse = value;
				if (_lastPulse > MaxHeartRate)
				{
					MaxHeartRate = _lastPulse;
					_maxHeartRateChanged.OnNext(MaxHeartRate);
				}
			}
		}

		public virtual IFitnessConsole Console { get; set; }

		public virtual IBleDevice CurrentlyConnectedDevice { get; }

		public virtual IHeartRateConnection HeartRateConnection { get; set; }

		public virtual bool IsConnected { get; }

		public virtual bool ReconnectOnLostConnection { get; set; }

		protected HeartRateHelperBase(IFitnessConsole console, IPulseFacade pulseFacade, TimeSpan delayBetweenScans = default(TimeSpan))
		{
			Console = console;
			this.pulseFacade = pulseFacade;
			this.delayBetweenScans = ((delayBetweenScans == default(TimeSpan)) ? DefaultDelayBetweenScans : delayBetweenScans);
		}

		public abstract void Manage(IHeartRateConnection connection);

		public abstract Task ScanAndConnectToHeartRateDevice(bool delayScan = false, TimeSpan scanTimeout = default(TimeSpan));

		public abstract void StopScanning();

		public abstract void ForceHeartRateDisconnect();

		public abstract Task<bool> RemoveBond();

		protected void SafelySendZeroPulse()
		{
			if (LastPulse != 0)
			{
				Log.Trace("HeartRateHelper", "setting heart rate to 0");
				LastPulse = 0;
			}
		}

		public virtual void Dispose()
		{
			ForceHeartRateDisconnect();
			isDisposed = true;
		}
	}
	public class HeartRateHelper : HeartRateHelperBase
	{
		private readonly IHeartRateScanner hrScanner;

		private readonly IBleRadioStatusService bluetoothStatusService;

		private readonly IPersistentBluetoothDevices persistentBluetoothDevices;

		public static readonly TimeSpan DefaultConnectionInitTimeout = TimeSpan.FromSeconds(45.0);

		private IHeartRateConnection _heartRateConnection;

		private IDisposable heartRateUpdateSub;

		private IDisposable heartRateConnectionLostSub;

		private IDisposable heartRateDisconnectedSub;

		private readonly IDisposable whenMetricChangedSub;

		private IDisposable delayBetweenScansTimerSub;

		private string pairKey;

		private bool connected;

		private bool isAlreadyScheduledForRescan;

		private CancellationTokenSource scanningCts;

		public override IHeartRateConnection HeartRateConnection
		{
			get
			{
				return _heartRateConnection;
			}
			set
			{
				_heartRateConnection = value;
				if (value != null)
				{
					SetupHeartRateSubs();
					pairKey = _heartRateConnection.Device.PairKey;
					bleConnected = true;
					UpdateConnectionIfNeeded(shouldBeConnected: true);
				}
			}
		}

		public override bool IsConnected
		{
			get
			{
				IHeartRateConnection heartRateConnection = HeartRateConnection;
				if (heartRateConnection == null)
				{
					return false;
				}
				return heartRateConnection.Device?.State == DeviceState.Connected;
			}
		}

		public override IBleDevice CurrentlyConnectedDevice => HeartRateConnection?.Device;

		public HeartRateHelper(IHeartRateScanner hrScanner, IFitnessConsole console, IBleRadioStatusService bluetoothStatusService, IPulseFacade pulseFacade, IPersistentBluetoothDevices persistentBluetoothDevices = null, TimeSpan delayBetweenScans = default(TimeSpan))
			: base(console, pulseFacade, delayBetweenScans)
		{
			this.hrScanner = hrScanner;
			this.bluetoothStatusService = bluetoothStatusService;
			this.persistentBluetoothDevices = persistentBluetoothDevices;
			ReconnectOnLostConnection = true;
			whenMetricChangedSub = pulseFacade.ObservePulseChanges().Subscribe(OnMetricChange);
		}

		private void OnMetricChange(FitnessValueChange<Pulse> metric)
		{
			if (Console.LatestBasicInfo.CurrentPulse != null && !bleConnected)
			{
				Pulse.Source pulseSource = Console.LatestBasicInfo.CurrentPulse.PulseSource;
				if (pulseSource != Pulse.Source.None && pulseSource != Pulse.Source.Hand)
				{
					Log.Debug("HeartRateHelper", "Updating LastPulse from OnMetricChange");
					UpdateConnectionIfNeeded(shouldBeConnected: true);
					base.LastPulse = metric.Current.UserPulse;
				}
				else
				{
					UpdateConnectionIfNeeded(shouldBeConnected: false);
				}
			}
		}

		private void UpdateConnectionIfNeeded(bool shouldBeConnected)
		{
			if (shouldBeConnected != connected)
			{
				connected = shouldBeConnected;
				_whenConnectionChanged.OnNext(connected);
			}
		}

		public override void Manage(IHeartRateConnection connection)
		{
			if (connection != null && connection.Initialized && connection != null && connection.Device.State == DeviceState.Connected)
			{
				ForceHeartRateDisconnect();
				persistentBluetoothDevices?.SaveBondedHrm(connection.Device.Id);
				Log.Trace("HeartRateHelper", $"Managing new HRM connection (Device.Id: {connection.Device.Id})");
				HeartRateConnection = connection;
			}
		}

		public override async Task ScanAndConnectToHeartRateDevice(bool delayScan = false, TimeSpan scanTimeout = default(TimeSpan))
		{
			if (base.IsScanning)
			{
				Log.Trace("HeartRateHelper", "Not starting to scan and connect to HRMs; Already scanning.");
				return;
			}
			scanningCts?.Dispose();
			scanningCts = null;
			scanningCts = InitScanningCts();
			if (delayScan)
			{
				Log.Info("HeartRateHelper", $"Delaying scan for HRMs by {HeartRateHelperBase.OnDisconnectStartScanDelay.Seconds} seconds.");
				try
				{
					await Task.Delay(HeartRateHelperBase.OnDisconnectStartScanDelay, scanningCts.Token);
				}
				catch (TaskCanceledException)
				{
					scanningCts.Dispose();
					scanningCts = null;
					return;
				}
			}
			if (scanTimeout == default(TimeSpan))
			{
				scanTimeout = HeartRateHelperBase.DefaultHeartRateScanTimeout;
			}
			base.IsScanning = true;
			await ScanAndConnectToHeartRateDeviceInternal(scanTimeout);
		}

		private async Task ScanAndConnectToHeartRateDeviceInternal(TimeSpan scanTimeout)
		{
			if (isDisposed)
			{
				Log.Trace("HeartRateHelper", $"Stopping scan for HRM because {GetType()} was disposed of");
				base.IsScanning = false;
				return;
			}
			if (scanningCts.IsCancellationRequested)
			{
				Log.Trace("HeartRateHelper", "Scanning for HRM cancelled");
				scanningCts.Dispose();
				scanningCts = null;
				return;
			}
			CancelScheduledRescan();
			Log.Trace("HeartRateHelper", $"Scanning for HRM with intervals of {scanTimeout.TotalSeconds} seconds");
			DeviceState? deviceState = HeartRateConnection?.Device?.State;
			if (deviceState == DeviceState.Connected || deviceState == DeviceState.Connecting)
			{
				Log.Trace("HeartRateHelper", "Already connected to a device");
				base.IsScanning = false;
				return;
			}
			IDisposable onFoundDeviceSub = null;
			IBleDevice bleDevice;
			try
			{
				List<IBleDevice> devices = new List<IBleDevice>();
				onFoundDeviceSub?.Dispose();
				onFoundDeviceSub = hrScanner.OnFoundDevice.Where((IBleDevice x) => pairKey == null || pairKey.Equals(x.PairKey, StringComparison.OrdinalIgnoreCase)).Subscribe(delegate(IBleDevice x)
				{
					devices.Add(x);
				});
				hrScanner.StopScanning();
				await hrScanner.BeginScanning(scanTimeout).ConfigureAwait(continueOnCapturedContext: false);
				if (devices.Count == 0)
				{
					Log.Error("HeartRateHelper", "Failed to find heart rate device.");
					ScheduleRescanForHRM(scanTimeout);
					return;
				}
				devices.Sort((IBleDevice x, IBleDevice y) => x.StrengthPercentage.CompareTo(y.StrengthPercentage));
				bleDevice = devices.Last();
				for (int num = 0; num < devices.Count - 1; num++)
				{
					devices[num].Dispose();
				}
			}
			catch (Exception exception)
			{
				Log.Error("HeartRateHelper", "Failed to find heart rate device", exception);
				ScheduleRescanForHRM(scanTimeout);
				return;
			}
			finally
			{
				onFoundDeviceSub?.Dispose();
			}
			if (scanningCts.IsCancellationRequested)
			{
				Log.Trace("HeartRateHelper", "Creating HeartRateConnection for Device (" + bleDevice.Name + " " + bleDevice.PairKey + ") was cancelled");
				bleDevice?.Dispose();
				scanningCts.Dispose();
				scanningCts = null;
			}
			else
			{
				Log.Trace("HeartRateHelper", $"Found device, creating HRC object. Device {bleDevice.Name} ({bleDevice.PairKey}) \"{bleDevice.PlatformDevice.CommonIdentifier}\" id={bleDevice.Id} strength={bleDevice.StrengthPercentage}");
				if (!(await InitHeartRateConnection(bleDevice).ConfigureAwait(continueOnCapturedContext: false)))
				{
					ScheduleRescanForHRM(scanTimeout);
				}
				else
				{
					base.IsScanning = false;
				}
			}
		}

		private void CancelScheduledRescan()
		{
			delayBetweenScansTimerSub?.Dispose();
			isAlreadyScheduledForRescan = false;
		}

		private void ScheduleRescanForHRM(TimeSpan scanTimeout)
		{
			if (isAlreadyScheduledForRescan)
			{
				Log.Trace("HeartRateHelper", "Already scheduled for a rescan; not scheduling another one");
				return;
			}
			Log.Trace("HeartRateHelper", $"Scheduling another scan for HRMs in {delayBetweenScans} seconds");
			delayBetweenScansTimerSub?.Dispose();
			delayBetweenScansTimerSub = Observable.Timer(delayBetweenScans).SubscribeAsync(async delegate
			{
				isAlreadyScheduledForRescan = false;
				await ScanAndConnectToHeartRateDeviceInternal(scanTimeout);
			});
			isAlreadyScheduledForRescan = true;
		}

		private async Task<bool> InitHeartRateConnection(IBleDevice hrDevice, TimeSpan? timeout = null)
		{
			IHeartRateConnection connection = null;
			try
			{
				connection = CreateHeartRateConnection(hrDevice);
				bool flag = await connection.WhenInitialized.Timeout(timeout.GetValueOrDefault(DefaultConnectionInitTimeout)).Take(1).ToTask();
				if (!flag)
				{
					InitializationFailed("\u00af\\_(ツ)_/\u00af");
					return flag;
				}
				HeartRateConnection = connection;
				Log.Trace("HeartRateHelper", "HRC Initialized");
				return flag;
			}
			catch (Exception ex)
			{
				InitializationFailed(ex.ToString());
				return false;
			}
			void InitializationFailed(string error)
			{
				Log.Trace("HeartRateHelper", "Failed to initialize heart rate device due to: " + error);
				connection?.Dispose();
			}
		}

		public override void StopScanning()
		{
			scanningCts?.Cancel();
		}

		private CancellationTokenSource InitScanningCts()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			cancellationTokenSource.Token.Register(delegate
			{
				hrScanner.StopScanning();
				base.IsScanning = false;
			});
			return cancellationTokenSource;
		}

		public override void ForceHeartRateDisconnect()
		{
			Log.Trace("HeartRateHelper", "Disconnecting HRM");
			bleConnected = false;
			UpdateConnectionIfNeeded(shouldBeConnected: false);
			SafelySendZeroPulse();
			heartRateDisconnectedSub?.Dispose();
			HeartRateConnection?.Device?.Disconnect();
			HeartRateConnection?.Dispose();
			HeartRateConnection = null;
		}

		public override async Task<bool> RemoveBond()
		{
			try
			{
				using IBleDevice device = HeartRateConnection?.Device;
				if (device == null)
				{
					Log.Error("HeartRateHelper", "RemoveBond could not get BluetoothDevice from heart rate connection");
					return true;
				}
				Log.Trace("HeartRateHelper", string.Format("{0} attempting to unbond from {1}", "RemoveBond", device));
				await device.RemoveBond();
				return true;
			}
			catch (Exception exception)
			{
				Log.Error("HeartRateHelper", "RemoveBond failed", exception);
				return false;
			}
		}

		private void SetupHeartRateSubs()
		{
			Log.Trace("HeartRateHelper", "Setting up HRM subscriptions (device: " + HeartRateConnection?.Device?.Name + ")");
			heartRateConnectionLostSub?.Dispose();
			heartRateConnectionLostSub = HeartRateConnection?.Device?.WhenStateChanged?.Where((DeviceState state) => state == DeviceState.LostConnection).Take(1).Subscribe(delegate
			{
				OnHeartRateConnectionLost();
			});
			SetupHeartRateValueSub();
		}

		private void SetupHeartRateValueSub()
		{
			heartRateUpdateSub?.Dispose();
			heartRateUpdateSub = HeartRateConnection?.WhenHeartRateChange.Where((int hr) => hr > 0).Subscribe((Action<int>)delegate(int hr)
			{
				base.LastPulse = hr;
			}, (Action<Exception>)delegate
			{
				OnHeartRateConnectionLost();
			});
		}

		protected async Task OnHeartRateDisconnected()
		{
			Log.Trace("HeartRateHelper", "HRC Disconnected");
			SafelySendZeroPulse();
			ForceHeartRateDisconnect();
			await ScanAndConnectToHeartRateDevice(delayScan: true);
		}

		private void OnHeartRateConnectionLost()
		{
			Log.Trace("HeartRateHelper", "HRC Lost with Device");
			bleConnected = false;
			UpdateConnectionIfNeeded(shouldBeConnected: false);
			if (!ReconnectOnLostConnection)
			{
				Log.Trace("HeartRateHelper", "Not attempting to reconnect to HRM (ReconnectOnLostConnection value is: False)");
				HeartRateConnection?.Device?.Disconnect();
				SafelySendZeroPulse();
				ForceHeartRateDisconnect();
				return;
			}
			if (!bluetoothStatusService.IsBluetoothRadioEnabled())
			{
				Log.Trace("HeartRateHelper", "Waiting for BT to be on to try to reconnect");
				Task<bool> task = bluetoothStatusService.WhenBluetoothRadioEnabledChanged.Where((bool isEnabled) => isEnabled).Timeout(TimeSpan.FromSeconds(30.0)).FirstAsync()
					.ToTask();
				try
				{
					task.Wait();
					OnHeartRateDisconnected();
					return;
				}
				catch (AggregateException exception)
				{
					Log.Error("HeartRateHelper", "BT radio took too long to restart, not restarting scan", exception);
					return;
				}
			}
			HeartRateConnection?.Device?.Disconnect();
			OnHeartRateDisconnected();
		}

		protected virtual IHeartRateConnection CreateHeartRateConnection(IBleDevice device)
		{
			return new HeartRateConnection(device, bluetoothStatusService);
		}

		public override void Dispose()
		{
			heartRateConnectionLostSub?.Dispose();
			heartRateDisconnectedSub?.Dispose();
			heartRateUpdateSub?.Dispose();
			whenMetricChangedSub?.Dispose();
			delayBetweenScansTimerSub?.Dispose();
			base.Dispose();
		}
	}
	public class MockHeartRateHelper : HeartRateHelperBase
	{
		private const string LogTag = "MockHeartRateHelper";

		private const int HeartRateSinRange = 5;

		private const double RadianStep = 0.1;

		private int heartRateBase;

		private double currentRadians;

		private IDisposable mockPulseSub;

		public int HeartRateBase
		{
			get
			{
				return heartRateBase;
			}
			set
			{
				heartRateBase = value;
				bleConnected = true;
			}
		}

		public bool IsRunning => mockPulseSub != null;

		public MockHeartRateHelper(IFitnessConsole console, IPulseFacade pulseFacade)
			: base(console, pulseFacade)
		{
		}

		public override void ForceHeartRateDisconnect()
		{
			bleConnected = false;
			mockPulseSub?.Dispose();
			mockPulseSub = null;
			SafelySendZeroPulse();
			_whenConnectionChanged.OnNext(value: false);
		}

		public override Task<bool> RemoveBond()
		{
			return Task.FromResult(result: true);
		}

		public override void Manage(IHeartRateConnection connection)
		{
			Log.Trace("MockHeartRateHelper", "Attempting to have MockHeartRateHelper manage a HRM connection. Creating a mock pulse instead");
			CreateMockPulse();
		}

		public override Task ScanAndConnectToHeartRateDevice(bool delayScan = false, TimeSpan scanTimeout = default(TimeSpan))
		{
			CreateMockPulse();
			return Task.FromResult(0);
		}

		public override void StopScanning()
		{
		}

		private void CreateMockPulse()
		{
			if (mockPulseSub != null)
			{
				ForceHeartRateDisconnect();
			}
			currentRadians = 0.0;
			mockPulseSub = Observable.Interval(TimeSpan.FromSeconds(1.0)).Subscribe(delegate
			{
				if (HeartRateBase > 0)
				{
					base.LastPulse = GetCurrentPulse();
				}
			});
			_whenConnectionChanged.OnNext(value: true);
		}

		private int GetCurrentPulse()
		{
			int num = (int)(Math.Sin(currentRadians) * 5.0);
			currentRadians += 0.1;
			return HeartRateBase + num;
		}
	}
}
namespace Sindarin.Core.Ble
{
	public class BleHardwareTypeInfo
	{
		public byte[] DeviceHardwareType { get; private set; }

		public byte RevisionByte { get; private set; }

		public byte DeviceTypeByte { get; private set; }

		public BleHardwareTypeInfo(byte[] deviceHardwareType, byte revisionByte, byte deviceTypeByte)
		{
			DeviceHardwareType = deviceHardwareType;
			RevisionByte = revisionByte;
			DeviceTypeByte = deviceTypeByte;
		}
	}
	public interface IPersistentBluetoothDevices
	{
		Task SaveDevice(Guid deviceId);

		Task DeleteDevice(Guid deviceId);

		bool IsDeviceSaved(Guid deviceId);

		Task SaveBondedHrm(Guid deviceId);

		Task DeleteBondedHrm(Guid deviceId);

		bool IsBondedDeviceAnHrm(Guid deviceId);
	}
}
namespace Sindarin.Core.Ble.Utils
{
	public static class ManufacturerDataParser
	{
		private const int PairKeySize = 2;

		private const string LogTag = "Ble";

		private static void ParsePairKeyAndHardwareTypeSequences(IBleDevice device, out byte[] pairKeyBytes, out byte[] hardwareTypeBytes)
		{
			if (device == null)
			{
				pairKeyBytes = null;
				hardwareTypeBytes = null;
				return;
			}
			if (!string.IsNullOrWhiteSpace(device.Name) && device.Name.Contains("VIRTUAL CONSOLE"))
			{
				pairKeyBytes = GetVirtualConsolePairKey(device.Name);
				hardwareTypeBytes = null;
				return;
			}
			AdvertisementRecord advertisementRecord = device.AdvertisementRecords?.FirstOrDefault((AdvertisementRecord d) => d.Type == AdvertisementRecordType.ManufacturerSpecificData);
			if (advertisementRecord == null)
			{
				Log.Error("Ble", "Unable to parse pairKey and hardwareType - device has null " + ((device.AdvertisementRecords == null) ? "AdvertisementRecords" : "ManufacturerSpecificData"));
				pairKeyBytes = null;
				hardwareTypeBytes = null;
				return;
			}
			if (advertisementRecord.Data == null || advertisementRecord.Data.Length < 2)
			{
				Log.Error("Ble", "Unable to parse pairKey and hardwareType - device has " + ((advertisementRecord.Data == null) ? "null" : "insufficient") + " DataRecord");
				pairKeyBytes = null;
				hardwareTypeBytes = null;
				return;
			}
			IEnumerable<byte> source = advertisementRecord.Data.ToList();
			if (source.First() == 165)
			{
				source = source.Skip(1);
			}
			if (source.First() == 1)
			{
				source = source.Skip(1);
			}
			if (source.Count() > 2 && source.First() == 2)
			{
				source = source.Skip(1);
			}
			if (source.Take(8).ToArray().WildcardSequenceEquals(new byte?[8] { 204, null, null, null, null, 221, null, null }))
			{
				hardwareTypeBytes = source.Skip(1).Take(4).ToArray();
				pairKeyBytes = source.Skip(6).Take(2).ToArray();
			}
			else if (source.Take(8).ToArray().WildcardSequenceEquals(new byte?[8] { 221, null, null, 204, null, null, null, null }))
			{
				pairKeyBytes = source.Skip(1).Take(2).ToArray();
				hardwareTypeBytes = source.Skip(4).Take(4).ToArray();
			}
			else if (source.Take(3).ToArray().WildcardSequenceEquals(new byte?[3] { 221, null, null }))
			{
				pairKeyBytes = source.Skip(1).Take(2).ToArray();
				hardwareTypeBytes = null;
			}
			else if (source.Take(5).ToArray().WildcardSequenceEquals(new byte?[5] { 204, null, null, null, null }))
			{
				hardwareTypeBytes = source.Skip(1).Take(4).ToArray();
				pairKeyBytes = null;
			}
			else if (source.Count() == 2)
			{
				hardwareTypeBytes = null;
				pairKeyBytes = source.Take(2).ToArray();
			}
			else
			{
				pairKeyBytes = null;
				hardwareTypeBytes = null;
			}
			if (hardwareTypeBytes?.Length != 4)
			{
				hardwareTypeBytes = null;
			}
			if (pairKeyBytes?.Length != 2)
			{
				pairKeyBytes = null;
			}
		}

		private static byte[] GetVirtualConsolePairKey(string deviceName)
		{
			Match match = new Regex("\\[.*?\\]").Match(deviceName);
			if (match.Success)
			{
				string text = match.Value.Replace('[', ' ').Replace(']', ' ').Trim();
				int length = text.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
				}
				return new byte[2]
				{
					array[1],
					array[0]
				};
			}
			return new byte[2] { 55, 19 };
		}

		public static string GetManufacturerDataPairKey(this IBleDevice device)
		{
			try
			{
				ParsePairKeyAndHardwareTypeSequences(device, out var pairKeyBytes, out var _);
				return (pairKeyBytes == null) ? null : $"{pairKeyBytes[1]:X2}{pairKeyBytes[0]:X2}";
			}
			catch (Exception exception)
			{
				Log.Error("Ble", "Failed to get pair key", exception);
				return null;
			}
		}

		public static BleHardwareTypeInfo GetHardwareTypeInfo(this IBleDevice device)
		{
			ParsePairKeyAndHardwareTypeSequences(device, out var _, out var hardwareTypeBytes);
			if (hardwareTypeBytes == null)
			{
				return null;
			}
			byte[] deviceHardwareType = new byte[2]
			{
				hardwareTypeBytes[1],
				hardwareTypeBytes[0]
			};
			byte revisionByte = hardwareTypeBytes[2];
			byte deviceTypeByte = hardwareTypeBytes[3];
			return new BleHardwareTypeInfo(deviceHardwareType, revisionByte, deviceTypeByte);
		}
	}
}
namespace Sindarin.Core.Ble.Service
{
	public interface IBleRadioStatusService : IDisposable
	{
		IObservable<bool> WhenBluetoothRadioEnabledChanged { get; }

		bool IsBluetoothRadioEnabled();

		void RequestEnableBluetooth(bool notifyIfCannotEnable, string currentScreen = null, Action onCancel = null);

		bool CheckAndRequestBluetooth(bool notifyIfCannotEnable, string currentScreen = null, Action onCancel = null);

		void CycleBluetoothRadio();

		void EnableBleRadio();

		void DisableBleRadio();
	}
}
namespace Sindarin.Core.Ble.Scan
{
	public enum AdvertisementRecordType
	{
		Flags = 1,
		UuidsIncomple16Bit = 2,
		UuidsComplete16Bit = 3,
		UuidsIncomplete32Bit = 4,
		UuidCom32Bit = 5,
		UuidsIncomplete128Bit = 6,
		UuidsComplete128Bit = 7,
		ShortLocalName = 8,
		CompleteLocalName = 9,
		TxPowerLevel = 10,
		Deviceclass = 13,
		SimplePairingHash = 14,
		SimplePairingRandomizer = 15,
		DeviceId = 16,
		SecurityManager = 17,
		SlaveConnectionInterval = 18,
		SsUuids16Bit = 20,
		SsUuids128Bit = 21,
		ServiceData = 22,
		PublicTargetAddress = 23,
		RandomTargetAddress = 24,
		Appearance = 25,
		DeviceAddress = 27,
		LeRole = 28,
		PairingHash = 29,
		PairingRandomizer = 30,
		SsUuids32Bit = 31,
		ServiceDataUuid32Bit = 32,
		ServiceData128Bit = 33,
		SecureConnectionsConfirmationValue = 34,
		SecureConnectionsRandomValue = 35,
		Information3DData = 61,
		ManufacturerSpecificData = 255
	}
	public class AdvertisementRecord
	{
		public AdvertisementRecordType Type { get; }

		public byte[] Data { get; }

		public AdvertisementRecord(AdvertisementRecordType type, byte[] data)
		{
			Type = type;
			Data = data;
		}

		public override string ToString()
		{
			return $"Adv rec [Type {Type}; Data {BitConverter.ToString(Data)}]";
		}
	}
	public interface IScanner : IDisposable
	{
		ScanState CurrentState { get; }

		IObservable<ScanState> WhenCurrentStateChanged { get; }

		IObservable<IBleDevice> ScanWithFilter(BaseDeviceFilter filter, int requestedScanSeconds = 45);

		Task WarmUpScanner();

		void StopScan();
	}
	public abstract class ScannerBase : IScanner, IDisposable
	{
		private const string LogTag = "Ble";

		internal const int DefaultScanSeconds = 45;

		private ScanState _currentState = ScanState.Idle;

		private readonly Subject<ScanState> _whenCurrentStateChanged = new Subject<ScanState>();

		private readonly Subject<IBleDevice> _whenDeviceFound = new Subject<IBleDevice>();

		private IDisposable scanTimeoutSub;

		private int scanSeconds;

		public ScanState CurrentState
		{
			get
			{
				return _currentState;
			}
			protected set
			{
				if (_currentState != value)
				{
					_currentState = value;
					_whenCurrentStateChanged.OnNext(_currentState);
				}
			}
		}

		public IObservable<ScanState> WhenCurrentStateChanged => _whenCurrentStateChanged;

		public IObservable<IBleDevice> ScanWithFilter(BaseDeviceFilter filter, int requestedScanSeconds = 45)
		{
			UpdateScanSeconds(requestedScanSeconds);
			scanTimeoutSub?.Dispose();
			scanTimeoutSub = Observable.Timer(TimeSpan.FromSeconds(scanSeconds)).Subscribe(delegate
			{
				StopScan();
			});
			StopScanNative();
			Log.Trace("Ble", $"Scanning for {scanSeconds} seconds");
			ScanNative();
			return _whenDeviceFound.Where(filter.IsDeviceValid);
		}

		private void UpdateScanSeconds(int requestedScanSeconds)
		{
			scanSeconds = ((_currentState == ScanState.Idle) ? requestedScanSeconds : Math.Max(scanSeconds, requestedScanSeconds));
		}

		public virtual void StopScan()
		{
			Log.Trace("Ble", "Stopping scanning");
			scanTimeoutSub?.Dispose();
			scanTimeoutSub = null;
			StopScanNative();
		}

		protected abstract void StopScanNative();

		protected abstract void ScanNative();

		public abstract Task WarmUpScanner();

		protected void OnDeviceFound(IBleDevice device)
		{
			_whenDeviceFound.OnNext(device);
		}

		public virtual void Dispose()
		{
			StopScan();
		}

		protected void ScannerError(Exception e)
		{
			Log.Error("Ble", "Scanner Error", e);
		}
	}
	public enum ScanState
	{
		Scanning,
		Idle,
		NoBluetooth
	}
}
namespace Sindarin.Core.Ble.KnownTypes
{
	public class KnownCharacteristic : NamedGuid
	{
		public KnownCharacteristic(string name, Guid id)
			: base(name, id)
		{
		}
	}
	public static class KnownCharacteristics
	{
		private static Dictionary<Guid, KnownCharacteristic> LookupTable;

		public static readonly KnownCharacteristic DeviceTx;

		public static readonly KnownCharacteristic DeviceRx;

		public static readonly KnownCharacteristic DfuVersion;

		public static readonly KnownCharacteristic DfuControlPoint;

		public static readonly KnownCharacteristic DfuPacket;

		public static readonly KnownCharacteristic DfuPulseOnPacket;

		public static readonly KnownCharacteristic AccelleromaterStream;

		public static readonly KnownCharacteristic AlertCategoryId;

		public static readonly KnownCharacteristic AlertCategoryIdBitMask;

		public static readonly KnownCharacteristic AlertLevel;

		public static readonly KnownCharacteristic AlertNotifcationControlPoint;

		public static readonly KnownCharacteristic AlertStatus;

		public static readonly KnownCharacteristic Appearance;

		public static readonly KnownCharacteristic BatteryLevel;

		public static readonly KnownCharacteristic BloodPressureFeature;

		public static readonly KnownCharacteristic BloodPressureMeasurement;

		public static readonly KnownCharacteristic BodySensorLocation;

		public static readonly KnownCharacteristic BootKeyboardInputReport;

		public static readonly KnownCharacteristic BootKeyboardOutputReport;

		public static readonly KnownCharacteristic BootMouseInputReport;

		public static readonly KnownCharacteristic CSCFeature;

		public static readonly KnownCharacteristic CSCMeasurement;

		public static readonly KnownCharacteristic CurrentTime;

		public static readonly KnownCharacteristic CyclingPowerControlPoint;

		public static readonly KnownCharacteristic CyclingPowerFeature;

		public static readonly KnownCharacteristic CyclingPowerMeasurement;

		public static readonly KnownCharacteristic CyclingPowerVector;

		public static readonly KnownCharacteristic DateTime;

		public static readonly KnownCharacteristic DayDateTime;

		public static readonly KnownCharacteristic DayOfWeek;

		public static readonly KnownCharacteristic DeviceName;

		public static readonly KnownCharacteristic DSTOffset;

		public static readonly KnownCharacteristic ExactTime;

		public static readonly KnownCharacteristic FirmwareRevisionString;

		public static readonly KnownCharacteristic GlucoseFeature;

		public static readonly KnownCharacteristic GlucoseMeasurement;

		public static readonly KnownCharacteristic GlucoseMeasureContext;

		public static readonly KnownCharacteristic HardwareRevisionString;

		public static readonly KnownCharacteristic HeartRateControlPoint;

		public static readonly KnownCharacteristic HeartRateMeasurement;

		public static readonly KnownCharacteristic HIDControlPoint;

		public static readonly KnownCharacteristic HIDInformation;

		public static readonly KnownCharacteristic CertDataList;

		public static readonly KnownCharacteristic CuffPressure;

		public static readonly KnownCharacteristic IntermediateTemp;

		public static readonly KnownCharacteristic LNControlPoint;

		public static readonly KnownCharacteristic LNFeature;

		public static readonly KnownCharacteristic LocalTimeInformation;

		public static readonly KnownCharacteristic LocationAndSpeed;

		public static readonly KnownCharacteristic ManufacturerNameString;

		public static readonly KnownCharacteristic MeasurementInterval;

		public static readonly KnownCharacteristic ModelNumberString;

		public static readonly KnownCharacteristic Navigation;

		public static readonly KnownCharacteristic NewAlert;

		public static readonly KnownCharacteristic PeripheralPreferredConnectionParams;

		public static readonly KnownCharacteristic PeripheralPrivacyFlag;

		public static readonly KnownCharacteristic PnPId;

		public static readonly KnownCharacteristic PositionQuality;

		public static readonly KnownCharacteristic ProtocolMode;

		public static readonly KnownCharacteristic ReconnectionAddress;

		public static readonly KnownCharacteristic RecordAccessControlPoint;

		public static readonly KnownCharacteristic ReferenceTimeInfo;

		public static readonly KnownCharacteristic Report;

		public static readonly KnownCharacteristic ReportMap;

		public static readonly KnownCharacteristic RingerControlPoint;

		public static readonly KnownCharacteristic RingerSetting;

		public static readonly KnownCharacteristic RSCFeature;

		public static readonly KnownCharacteristic RSCMeasurement;

		public static readonly KnownCharacteristic SCControlPoint;

		public static readonly KnownCharacteristic ScanIntervalWindow;

		public static readonly KnownCharacteristic ScanRefresh;

		public static readonly KnownCharacteristic SensorLocation;

		public static readonly KnownCharacteristic SerialNumberString;

		public static readonly KnownCharacteristic ServiceChanged;

		public static readonly KnownCharacteristic SoftwareRevisionString;

		public static readonly KnownCharacteristic SupportedNewAlertCategory;

		public static readonly KnownCharacteristic SUpportedUnreadAlertCategory;

		public static readonly KnownCharacteristic SystemId;

		public static readonly KnownCharacteristic TemperatureMeasurement;

		public static readonly KnownCharacteristic TempType;

		public static readonly KnownCharacteristic TimeAccuracy;

		public static readonly KnownCharacteristic TimeSource;

		public static readonly KnownCharacteristic TimeUpdateControlPoint;

		public static readonly KnownCharacteristic TimeUpdateState;

		public static readonly KnownCharacteristic TimeWithDst;

		public static readonly KnownCharacteristic TimeZone;

		public static readonly KnownCharacteristic TxPowerLevel;

		public static readonly KnownCharacteristic UnreadAlertStatus;

		public static readonly KnownCharacteristic AerobicHeartRateLowerLimit;

		public static readonly KnownCharacteristic AerobicHeartRateUpperLimit;

		public static readonly KnownCharacteristic Age;

		public static readonly KnownCharacteristic AggregateInput;

		public static readonly KnownCharacteristic AnaerobicHeartRateLowerLimit;

		public static readonly KnownCharacteristic AnaerobicHeartRateUpperLimit;

		public static readonly KnownCharacteristic AnaerobicThreshold;

		public static readonly KnownCharacteristic AnalongInput;

		public static readonly KnownCharacteristic FatBurnHeartRateUpperLimit;

		public static readonly KnownCharacteristic ApparentWindDirection;

		public static readonly KnownCharacteristic ApparentWindSpeed;

		public static readonly KnownCharacteristic BodyCompositionFeature;

		public static readonly KnownCharacteristic BodyCompositionMeasurement;

		public static readonly KnownCharacteristic DatabaseChagneIncrement;

		public static readonly KnownCharacteristic DateOfBirth;

		public static readonly KnownCharacteristic DateOfThresholdAssesment;

		public static readonly KnownCharacteristic DescriptorValueChange;

		public static readonly KnownCharacteristic DewPoint;

		public static readonly KnownCharacteristic DigitalInput;

		public static readonly KnownCharacteristic DigitalOutput;

		public static readonly KnownCharacteristic Elevation;

		public static readonly KnownCharacteristic EmailAddress;

		public static readonly KnownCharacteristic ExactTime100;

		public static readonly KnownCharacteristic FatBurnheartRateLowerLimit;

		public static readonly KnownCharacteristic Firstname;

		public static readonly KnownCharacteristic FiveZoneHeartRateLimits;

		public static readonly KnownCharacteristic Gender;

		public static readonly KnownCharacteristic GustFactor;

		public static readonly KnownCharacteristic HeartRatemax;

		public static readonly KnownCharacteristic HeatIndex;

		public static readonly KnownCharacteristic Height;

		public static readonly KnownCharacteristic CipCircumference;

		public static readonly KnownCharacteristic Humidity;

		public static readonly KnownCharacteristic Irradiance;

		public static readonly KnownCharacteristic LastName;

		public static readonly KnownCharacteristic MaxRecommededHeartRate;

		public static readonly KnownCharacteristic NetworkAvailability;

		public static readonly KnownCharacteristic PollenConcentration;

		public static readonly KnownCharacteristic Pressure;

		public static readonly KnownCharacteristic Rainfall;

		public static readonly KnownCharacteristic RestingHeartRate;

		public static readonly KnownCharacteristic ScientificTemperatureInCelsius;

		public static readonly KnownCharacteristic SecondaryTimeZone;

		public static readonly KnownCharacteristic SportTypeForAerobicAndAnaerobicThresholds;

		public static readonly KnownCharacteristic String;

		public static readonly KnownCharacteristic Temperature;

		public static readonly KnownCharacteristic TemperatureInCelsius;

		public static readonly KnownCharacteristic TemperatureFahrenheit;

		public static readonly KnownCharacteristic ThreeZoneHeartRateLimits;

		public static readonly KnownCharacteristic TimeBroadcast;

		public static readonly KnownCharacteristic Trend;

		public static readonly KnownCharacteristic TrueWindDirection;

		public static readonly KnownCharacteristic TrueWindSpeed;

		public static readonly KnownCharacteristic TwoZoneHeartRateLimit;

		public static readonly KnownCharacteristic UserControlPoint;

		public static readonly KnownCharacteristic UserIndex;

		public static readonly KnownCharacteristic UvIndex;

		public static readonly KnownCharacteristic VO2Max;

		public static readonly KnownCharacteristic WaistCircumference;

		public static readonly KnownCharacteristic Weight;

		public static readonly KnownCharacteristic WeightMeasurement;

		public static readonly KnownCharacteristic WeightScaleFeature;

		public static readonly KnownCharacteristic WindChill;

		public static readonly KnownCharacteristic BatteryLevelState;

		public static readonly KnownCharacteristic BatteryPowerState;

		public static readonly KnownCharacteristic Latitude;

		public static readonly KnownCharacteristic Longitude;

		public static readonly KnownCharacteristic Position2d;

		public static readonly KnownCharacteristic Position3d;

		public static readonly KnownCharacteristic PulseOximetryContinuousMeasurement;

		public static readonly KnownCharacteristic PulseOximetryControlPoint;

		public static readonly KnownCharacteristic ASDF;

		public static readonly KnownCharacteristic PulseOximetryFeatures;

		public static readonly KnownCharacteristic PulseOximetrySpotCheckMeasurement;

		public static readonly KnownCharacteristic Removable;

		public static readonly KnownCharacteristic ServiceRequired;

		public static readonly KnownCharacteristic TIKeysData;

		public static readonly KnownCharacteristic TIInfraredTempData;

		public static readonly KnownCharacteristic TIInfraredTempDataOnOff;

		public static readonly KnownCharacteristic TIInfraredTempDataSamplerate;

		public static readonly KnownCharacteristic TIAccelerometerData;

		public static readonly KnownCharacteristic TIAccelerometerOnoff;

		public static readonly KnownCharacteristic TIAccelerometerSampleRate;

		public static readonly KnownCharacteristic TIHumidityData;

		public static readonly KnownCharacteristic TIHumidityOnOff;

		public static readonly KnownCharacteristic TIHumiditySampleRate;

		public static readonly KnownCharacteristic TIMagnometerData;

		public static readonly KnownCharacteristic TIMagnometerOnOff;

		public static readonly KnownCharacteristic TIMagnometerSamplerate;

		public static readonly KnownCharacteristic TIBarometerData;

		public static readonly KnownCharacteristic TIBarometerOnoff;

		public static readonly KnownCharacteristic TIBarometerCalibration;

		public static readonly KnownCharacteristic TIBarometerSampleRate;

		public static readonly KnownCharacteristic TIGyroscopeData;

		public static readonly KnownCharacteristic TIGyroscopeOnOff;

		public static readonly KnownCharacteristic TIGyroscopeSampleRate;

		public static readonly KnownCharacteristic TITestData;

		public static readonly KnownCharacteristic TITestConfig;

		public static readonly KnownCharacteristic TIConnectionParams;

		public static readonly KnownCharacteristic TIConnectionRequestParams;

		public static readonly KnownCharacteristic TiConnectionRequestDisconnect;

		public static readonly KnownCharacteristic TIImageIdentify;

		public static readonly KnownCharacteristic TIImageBlock;

		private static readonly List<KnownCharacteristic> Characteristics;

		static KnownCharacteristics()
		{
			DeviceTx = new KnownCharacteristic("Device Tx", Guid.ParseExact("00001535-1412-efde-1523-785feabcd123", "d"));
			DeviceRx = new KnownCharacteristic("Device Rx", Guid.ParseExact("00001534-1412-efde-1523-785feabcd123", "d"));
			DfuVersion = new KnownCharacteristic("Dfu Version", Guid.ParseExact("00001534-1212-EFDE-1523-785FEABCD123", "d"));
			DfuControlPoint = new KnownCharacteristic("Dfu Control Point", Guid.ParseExact("00001531-1212-EFDE-1523-785FEABCD123", "d"));
			DfuPacket = new KnownCharacteristic("Dfu Packet", Guid.ParseExact("00001532-1212-EFDE-1523-785FEABCD123", "d"));
			DfuPulseOnPacket = new KnownCharacteristic("Dfu Pulse On Packet", Guid.ParseExact("0000C168-3A98-1AAB-9C40-A068750DF195", "d"));
			AccelleromaterStream = new KnownCharacteristic("Accelleromater Stream", Guid.ParseExact("000043de-100a-f596-ea4f-4c04fd0eae68", "d"));
			AlertCategoryId = new KnownCharacteristic("Alert Category ID", Guid.ParseExact("00002a43-0000-1000-8000-00805f9b34fb", "d"));
			AlertCategoryIdBitMask = new KnownCharacteristic("Alert Category ID Bit Mask", Guid.ParseExact("00002a42-0000-1000-8000-00805f9b34fb", "d"));
			AlertLevel = new KnownCharacteristic("Alert Level", Guid.ParseExact("00002a06-0000-1000-8000-00805f9b34fb", "d"));
			AlertNotifcationControlPoint = new KnownCharacteristic("Alert Notification Control Point", Guid.ParseExact("00002a44-0000-1000-8000-00805f9b34fb", "d"));
			AlertStatus = new KnownCharacteristic("Alert Status", Guid.ParseExact("00002a3f-0000-1000-8000-00805f9b34fb", "d"));
			Appearance = new KnownCharacteristic("Appearance", Guid.ParseExact("00002a01-0000-1000-8000-00805f9b34fb", "d"));
			BatteryLevel = new KnownCharacteristic("Battery Level", Guid.ParseExact("00002a19-0000-1000-8000-00805f9b34fb", "d"));
			BloodPressureFeature = new KnownCharacteristic("Blood Pressure Feature", Guid.ParseExact("00002a49-0000-1000-8000-00805f9b34fb", "d"));
			BloodPressureMeasurement = new KnownCharacteristic("Blood Pressure Measurement", Guid.ParseExact("00002a35-0000-1000-8000-00805f9b34fb", "d"));
			BodySensorLocation = new KnownCharacteristic("Body Sensor Location", Guid.ParseExact("00002a38-0000-1000-8000-00805f9b34fb", "d"));
			BootKeyboardInputReport = new KnownCharacteristic("Boot Keyboard Input Report", Guid.ParseExact("00002a22-0000-1000-8000-00805f9b34fb", "d"));
			BootKeyboardOutputReport = new KnownCharacteristic("Boot Keyboard Output Report", Guid.ParseExact("00002a32-0000-1000-8000-00805f9b34fb", "d"));
			BootMouseInputReport = new KnownCharacteristic("Boot Mouse Input Report", Guid.ParseExact("00002a33-0000-1000-8000-00805f9b34fb", "d"));
			CSCFeature = new KnownCharacteristic("CSC Feature", Guid.ParseExact("00002a5c-0000-1000-8000-00805f9b34fb", "d"));
			CSCMeasurement = new KnownCharacteristic("CSC Measurement", Guid.ParseExact("00002a5b-0000-1000-8000-00805f9b34fb", "d"));
			CurrentTime = new KnownCharacteristic("Current Time", Guid.ParseExact("00002a2b-0000-1000-8000-00805f9b34fb", "d"));
			CyclingPowerControlPoint = new KnownCharacteristic("Cycling Power Control Point", Guid.ParseExact("00002a66-0000-1000-8000-00805f9b34fb", "d"));
			CyclingPowerFeature = new KnownCharacteristic("Cycling Power Feature", Guid.ParseExact("00002a65-0000-1000-8000-00805f9b34fb", "d"));
			CyclingPowerMeasurement = new KnownCharacteristic("Cycling Power Measurement", Guid.ParseExact("00002a63-0000-1000-8000-00805f9b34fb", "d"));
			CyclingPowerVector = new KnownCharacteristic("Cycling Power Vector", Guid.ParseExact("00002a64-0000-1000-8000-00805f9b34fb", "d"));
			DateTime = new KnownCharacteristic("Date Time", Guid.ParseExact("00002a08-0000-1000-8000-00805f9b34fb", "d"));
			DayDateTime = new KnownCharacteristic("Day Date Time", Guid.ParseExact("00002a0a-0000-1000-8000-00805f9b34fb", "d"));
			DayOfWeek = new KnownCharacteristic("Day of Week", Guid.ParseExact("00002a09-0000-1000-8000-00805f9b34fb", "d"));
			DeviceName = new KnownCharacteristic("Device Name", Guid.ParseExact("00002a00-0000-1000-8000-00805f9b34fb", "d"));
			DSTOffset = new KnownCharacteristic("DST Offset", Guid.ParseExact("00002a0d-0000-1000-8000-00805f9b34fb", "d"));
			ExactTime = new KnownCharacteristic("Exact Time 256", Guid.ParseExact("00002a0c-0000-1000-8000-00805f9b34fb", "d"));
			FirmwareRevisionString = new KnownCharacteristic("Firmware Revision String", Guid.ParseExact("00002a26-0000-1000-8000-00805f9b34fb", "d"));
			GlucoseFeature = new KnownCharacteristic("Glucose Feature", Guid.ParseExact("00002a51-0000-1000-8000-00805f9b34fb", "d"));
			GlucoseMeasurement = new KnownCharacteristic("Glucose Measurement", Guid.ParseExact("00002a18-0000-1000-8000-00805f9b34fb", "d"));
			GlucoseMeasureContext = new KnownCharacteristic("Glucose Measure Context", Guid.ParseExact("00002a34-0000-1000-8000-00805f9b34fb", "d"));
			HardwareRevisionString = new KnownCharacteristic("Hardware Revision String", Guid.ParseExact("00002a27-0000-1000-8000-00805f9b34fb", "d"));
			HeartRateControlPoint = new KnownCharacteristic("Heart Rate Control Point", Guid.ParseExact("00002a39-0000-1000-8000-00805f9b34fb", "d"));
			HeartRateMeasurement = new KnownCharacteristic("Heart Rate Measurement", Guid.ParseExact("00002a37-0000-1000-8000-00805f9b34fb", "d"));
			HIDControlPoint = new KnownCharacteristic("HID Control Point", Guid.ParseExact("00002a4c-0000-1000-8000-00805f9b34fb", "d"));
			HIDInformation = new KnownCharacteristic("HID Information", Guid.ParseExact("00002a4a-0000-1000-8000-00805f9b34fb", "d"));
			CertDataList = new KnownCharacteristic("IEEE 11073-20601 Regulatory Certification Data List", Guid.ParseExact("00002a2a-0000-1000-8000-00805f9b34fb", "d"));
			CuffPressure = new KnownCharacteristic("Intermediate Cuff Pressure", Guid.ParseExact("00002a36-0000-1000-8000-00805f9b34fb", "d"));
			IntermediateTemp = new KnownCharacteristic("Intermediate Temperature", Guid.ParseExact("00002a1e-0000-1000-8000-00805f9b34fb", "d"));
			LNControlPoint = new KnownCharacteristic("LN Control Point", Guid.ParseExact("00002a6b-0000-1000-8000-00805f9b34fb", "d"));
			LNFeature = new KnownCharacteristic("LN Feature", Guid.ParseExact("00002a6a-0000-1000-8000-00805f9b34fb", "d"));
			LocalTimeInformation = new KnownCharacteristic("Local Time Information", Guid.ParseExact("00002a0f-0000-1000-8000-00805f9b34fb", "d"));
			LocationAndSpeed = new KnownCharacteristic("Location And Speed", Guid.ParseExact("00002a67-0000-1000-8000-00805f9b34fb", "d"));
			ManufacturerNameString = new KnownCharacteristic("Manufacturer Name String", Guid.ParseExact("00002a29-0000-1000-8000-00805f9b34fb", "d"));
			MeasurementInterval = new KnownCharacteristic("Measurement Interval", Guid.ParseExact("00002a21-0000-1000-8000-00805f9b34fb", "d"));
			ModelNumberString = new KnownCharacteristic("Model Number String", Guid.ParseExact("00002a24-0000-1000-8000-00805f9b34fb", "d"));
			Navigation = new KnownCharacteristic("Navigation", Guid.ParseExact("00002a68-0000-1000-8000-00805f9b34fb", "d"));
			NewAlert = new KnownCharacteristic("New Alert", Guid.ParseExact("00002a46-0000-1000-8000-00805f9b34fb", "d"));
			PeripheralPreferredConnectionParams = new KnownCharacteristic("Peripheral Preferred Connection Parameters", Guid.ParseExact("00002a04-0000-1000-8000-00805f9b34fb", "d"));
			PeripheralPrivacyFlag = new KnownCharacteristic("Peripheral Privacy Flag", Guid.ParseExact("00002a02-0000-1000-8000-00805f9b34fb", "d"));
			PnPId = new KnownCharacteristic("PnP ID", Guid.ParseExact("00002a50-0000-1000-8000-00805f9b34fb", "d"));
			PositionQuality = new KnownCharacteristic("Position Quality", Guid.ParseExact("00002a69-0000-1000-8000-00805f9b34fb", "d"));
			ProtocolMode = new KnownCharacteristic("Protocol Mode", Guid.ParseExact("00002a4e-0000-1000-8000-00805f9b34fb", "d"));
			ReconnectionAddress = new KnownCharacteristic("Reconnection Address", Guid.ParseExact("00002a03-0000-1000-8000-00805f9b34fb", "d"));
			RecordAccessControlPoint = new KnownCharacteristic("Record Access Control Point (Test Version)", Guid.ParseExact("00002a52-0000-1000-8000-00805f9b34fb", "d"));
			ReferenceTimeInfo = new KnownCharacteristic("Reference Time Information", Guid.ParseExact("00002a14-0000-1000-8000-00805f9b34fb", "d"));
			Report = new KnownCharacteristic("Report", Guid.ParseExact("00002a4d-0000-1000-8000-00805f9b34fb", "d"));
			ReportMap = new KnownCharacteristic("Report Map", Guid.ParseExact("00002a4b-0000-1000-8000-00805f9b34fb", "d"));
			RingerControlPoint = new KnownCharacteristic("Ringer Control Point", Guid.ParseExact("00002a40-0000-1000-8000-00805f9b34fb", "d"));
			RingerSetting = new KnownCharacteristic("Ringer Setting", Guid.ParseExact("00002a41-0000-1000-8000-00805f9b34fb", "d"));
			RSCFeature = new KnownCharacteristic("RSC Feature", Guid.ParseExact("00002a54-0000-1000-8000-00805f9b34fb", "d"));
			RSCMeasurement = new KnownCharacteristic("RSC Measurement", Guid.ParseExact("00002a53-0000-1000-8000-00805f9b34fb", "d"));
			SCControlPoint = new KnownCharacteristic("SC Control Point", Guid.ParseExact("00002a55-0000-1000-8000-00805f9b34fb", "d"));
			ScanIntervalWindow = new KnownCharacteristic("Scan Interval Window", Guid.ParseExact("00002a4f-0000-1000-8000-00805f9b34fb", "d"));
			ScanRefresh = new KnownCharacteristic("Scan Refresh", Guid.ParseExact("00002a31-0000-1000-8000-00805f9b34fb", "d"));
			SensorLocation = new KnownCharacteristic("Sensor Location", Guid.ParseExact("00002a5d-0000-1000-8000-00805f9b34fb", "d"));
			SerialNumberString = new KnownCharacteristic("Serial Number String", Guid.ParseExact("00002a25-0000-1000-8000-00805f9b34fb", "d"));
			ServiceChanged = new KnownCharacteristic("Service Changed", Guid.ParseExact("00002a05-0000-1000-8000-00805f9b34fb", "d"));
			SoftwareRevisionString = new KnownCharacteristic("Software Revision String", Guid.ParseExact("00002a28-0000-1000-8000-00805f9b34fb", "d"));
			SupportedNewAlertCategory = new KnownCharacteristic("Supported New Alert Category", Guid.ParseExact("00002a47-0000-1000-8000-00805f9b34fb", "d"));
			SUpportedUnreadAlertCategory = new KnownCharacteristic("Supported Unread Alert Category", Guid.ParseExact("00002a48-0000-1000-8000-00805f9b34fb", "d"));
			SystemId = new KnownCharacteristic("System ID", Guid.ParseExact("00002a23-0000-1000-8000-00805f9b34fb", "d"));
			TemperatureMeasurement = new KnownCharacteristic("Temperature Measurement", Guid.ParseExact("00002a1c-0000-1000-8000-00805f9b34fb", "d"));
			TempType = new KnownCharacteristic("Temperature Type", Guid.ParseExact("00002a1d-0000-1000-8000-00805f9b34fb", "d"));
			TimeAccuracy = new KnownCharacteristic("Time Accuracy", Guid.ParseExact("00002a12-0000-1000-8000-00805f9b34fb", "d"));
			TimeSource = new KnownCharacteristic("Time Source", Guid.ParseExact("00002a13-0000-1000-8000-00805f9b34fb", "d"));
			TimeUpdateControlPoint = new KnownCharacteristic("Time Update Control Point", Guid.ParseExact("00002a16-0000-1000-8000-00805f9b34fb", "d"));
			TimeUpdateState = new KnownCharacteristic("Time Update State", Guid.ParseExact("00002a17-0000-1000-8000-00805f9b34fb", "d"));
			TimeWithDst = new KnownCharacteristic("Time with DST", Guid.ParseExact("00002a11-0000-1000-8000-00805f9b34fb", "d"));
			TimeZone = new KnownCharacteristic("Time Zone", Guid.ParseExact("00002a0e-0000-1000-8000-00805f9b34fb", "d"));
			TxPowerLevel = new KnownCharacteristic("Tx Power Level", Guid.ParseExact("00002a07-0000-1000-8000-00805f9b34fb", "d"));
			UnreadAlertStatus = new KnownCharacteristic("Unread Alert Status", Guid.ParseExact("00002a45-0000-1000-8000-00805f9b34fb", "d"));
			AerobicHeartRateLowerLimit = new KnownCharacteristic("Aerobic Heart Rate Lower Limit", Guid.ParseExact("00002a7e-0000-1000-8000-00805f9b34fb", "d"));
			AerobicHeartRateUpperLimit = new KnownCharacteristic("Aerobic Heart Rate Uppoer Limit", Guid.ParseExact("00002a84-0000-1000-8000-00805f9b34fb", "d"));
			Age = new KnownCharacteristic("Age", Guid.ParseExact("00002a80-0000-1000-8000-00805f9b34fb", "d"));
			AggregateInput = new KnownCharacteristic("Aggregate Input", Guid.ParseExact("00002a5a-0000-1000-8000-00805f9b34fb", "d"));
			AnaerobicHeartRateLowerLimit = new KnownCharacteristic("Anaerobic Heart Rate Lower Limit", Guid.ParseExact("00002a81-0000-1000-8000-00805f9b34fb", "d"));
			AnaerobicHeartRateUpperLimit = new KnownCharacteristic("Anaerobic Heart Rate Upper Limit", Guid.ParseExact("00002a82-0000-1000-8000-00805f9b34fb", "d"));
			AnaerobicThreshold = new KnownCharacteristic("Anaerobic Threshold", Guid.ParseExact("00002a83-0000-1000-8000-00805f9b34fb", "d"));
			AnalongInput = new KnownCharacteristic("Analog Input", Guid.ParseExact("00002a58-0000-1000-8000-00805f9b34fb", "d"));
			FatBurnHeartRateUpperLimit = new KnownCharacteristic("Fat Burn Heart Rate Upper Limit", Guid.ParseExact("00002a89-0000-1000-8000-00805f9b34fb", "d"));
			ApparentWindDirection = new KnownCharacteristic("Apparent Wind Direction", Guid.ParseExact("00002a73-0000-1000-8000-00805f9b34fb", "d"));
			ApparentWindSpeed = new KnownCharacteristic("Apparent Wind Speed", Guid.ParseExact("00002a72-0000-1000-8000-00805f9b34fb", "d"));
			BodyCompositionFeature = new KnownCharacteristic("Body Composition Feature", Guid.ParseExact("00002a9b-0000-1000-8000-00805f9b34fb", "d"));
			BodyCompositionMeasurement = new KnownCharacteristic("Body Composition Measurement", Guid.ParseExact("00002a9c-0000-1000-8000-00805f9b34fb", "d"));
			DatabaseChagneIncrement = new KnownCharacteristic("Database Change Increment", Guid.ParseExact("00002a99-0000-1000-8000-00805f9b34fb", "d"));
			DateOfBirth = new KnownCharacteristic("Date of Birth", Guid.ParseExact("00002a85-0000-1000-8000-00805f9b34fb", "d"));
			DateOfThresholdAssesment = new KnownCharacteristic("Date of Threshold Assessment", Guid.ParseExact("00002a86-0000-1000-8000-00805f9b34fb", "d"));
			DescriptorValueChange = new KnownCharacteristic("Descriptor Value Changed", Guid.ParseExact("00002a7d-0000-1000-8000-00805f9b34fb", "d"));
			DewPoint = new KnownCharacteristic("Dew Point", Guid.ParseExact("00002a7b-0000-1000-8000-00805f9b34fb", "d"));
			DigitalInput = new KnownCharacteristic("Digital Input", Guid.ParseExact("00002a56-0000-1000-8000-00805f9b34fb", "d"));
			DigitalOutput = new KnownCharacteristic("Digital Output", Guid.ParseExact("00002a57-0000-1000-8000-00805f9b34fb", "d"));
			Elevation = new KnownCharacteristic("Elevation", Guid.ParseExact("00002a6c-0000-1000-8000-00805f9b34fb", "d"));
			EmailAddress = new KnownCharacteristic("Email Address", Guid.ParseExact("00002a87-0000-1000-8000-00805f9b34fb", "d"));
			ExactTime100 = new KnownCharacteristic("Exact Time 100", Guid.ParseExact("00002a0b-0000-1000-8000-00805f9b34fb", "d"));
			FatBurnheartRateLowerLimit = new KnownCharacteristic("Fat Burn Heart Rate Lower Limit", Guid.ParseExact("00002a88-0000-1000-8000-00805f9b34fb", "d"));
			Firstname = new KnownCharacteristic("First Name", Guid.ParseExact("00002a8a-0000-1000-8000-00805f9b34fb", "d"));
			FiveZoneHeartRateLimits = new KnownCharacteristic("Five Zone Heart Rate Limits", Guid.ParseExact("00002a8b-0000-1000-8000-00805f9b34fb", "d"));
			Gender = new KnownCharacteristic("Gender", Guid.ParseExact("00002a8c-0000-1000-8000-00805f9b34fb", "d"));
			GustFactor = new KnownCharacteristic("Gust Factor", Guid.ParseExact("00002a74-0000-1000-8000-00805f9b34fb", "d"));
			HeartRatemax = new KnownCharacteristic("Heart Rate Max", Guid.ParseExact("00002a8d-0000-1000-8000-00805f9b34fb", "d"));
			HeatIndex = new KnownCharacteristic("Heat Index", Guid.ParseExact("00002a7a-0000-1000-8000-00805f9b34fb", "d"));
			Height = new KnownCharacteristic("Height", Guid.ParseExact("00002a8e-0000-1000-8000-00805f9b34fb", "d"));
			CipCircumference = new KnownCharacteristic("Hip Circumference", Guid.ParseExact("00002a8f-0000-1000-8000-00805f9b34fb", "d"));
			Humidity = new KnownCharacteristic("Humidity", Guid.ParseExact("00002a6f-0000-1000-8000-00805f9b34fb", "d"));
			Irradiance = new KnownCharacteristic("Irradiance", Guid.ParseExact("00002a77-0000-1000-8000-00805f9b34fb", "d"));
			LastName = new KnownCharacteristic("Last Name", Guid.ParseExact("00002a90-0000-1000-8000-00805f9b34fb", "d"));
			MaxRecommededHeartRate = new KnownCharacteristic("Maximum Recommended Heart Rate", Guid.ParseExact("00002a91-0000-1000-8000-00805f9b34fb", "d"));
			NetworkAvailability = new KnownCharacteristic("Network Availability", Guid.ParseExact("00002a3e-0000-1000-8000-00805f9b34fb", "d"));
			PollenConcentration = new KnownCharacteristic("Pollen Concentration", Guid.ParseExact("00002a75-0000-1000-8000-00805f9b34fb", "d"));
			Pressure = new KnownCharacteristic("Pressure", Guid.ParseExact("00002a6d-0000-1000-8000-00805f9b34fb", "d"));
			Rainfall = new KnownCharacteristic("Rainfall", Guid.ParseExact("00002a78-0000-1000-8000-00805f9b34fb", "d"));
			RestingHeartRate = new KnownCharacteristic("Resting Heart Rate", Guid.ParseExact("00002a92-0000-1000-8000-00805f9b34fb", "d"));
			ScientificTemperatureInCelsius = new KnownCharacteristic("Scientific Temperature in Celsius", Guid.ParseExact("00002a3c-0000-1000-8000-00805f9b34fb", "d"));
			SecondaryTimeZone = new KnownCharacteristic("Secondary Time Zone", Guid.ParseExact("00002a10-0000-1000-8000-00805f9b34fb", "d"));
			SportTypeForAerobicAndAnaerobicThresholds = new KnownCharacteristic("Sport Type for Aerobic and Anaerobic Thresholds", Guid.ParseExact("00002a93-0000-1000-8000-00805f9b34fb", "d"));
			String = new KnownCharacteristic("String", Guid.ParseExact("00002a3d-0000-1000-8000-00805f9b34fb", "d"));
			Temperature = new KnownCharacteristic("Temperature", Guid.ParseExact("00002a6e-0000-1000-8000-00805f9b34fb", "d"));
			TemperatureInCelsius = new KnownCharacteristic("Temperature in Celsius", Guid.ParseExact("00002a1f-0000-1000-8000-00805f9b34fb", "d"));
			TemperatureFahrenheit = new KnownCharacteristic("Temperature in Fahrenheit", Guid.ParseExact("00002a20-0000-1000-8000-00805f9b34fb", "d"));
			ThreeZoneHeartRateLimits = new KnownCharacteristic("Three Zone Heart Rate Limits", Guid.ParseExact("00002a94-0000-1000-8000-00805f9b34fb", "d"));
			TimeBroadcast = new KnownCharacteristic("Time Broadcast", Guid.ParseExact("00002a15-0000-1000-8000-00805f9b34fb", "d"));
			Trend = new KnownCharacteristic("Trend", Guid.ParseExact("00002a7c-0000-1000-8000-00805f9b34fb", "d"));
			TrueWindDirection = new KnownCharacteristic("True Wind Direction", Guid.ParseExact("00002a71-0000-1000-8000-00805f9b34fb", "d"));
			TrueWindSpeed = new KnownCharacteristic("True Wind Speed", Guid.ParseExact("00002a70-0000-1000-8000-00805f9b34fb", "d"));
			TwoZoneHeartRateLimit = new KnownCharacteristic("Two Zone Heart Rate Limit", Guid.ParseExact("00002a95-0000-1000-8000-00805f9b34fb", "d"));
			UserControlPoint = new KnownCharacteristic("User Control Point", Guid.ParseExact("00002a9f-0000-1000-8000-00805f9b34fb", "d"));
			UserIndex = new KnownCharacteristic("User Index", Guid.ParseExact("00002a9a-0000-1000-8000-00805f9b34fb", "d"));
			UvIndex = new KnownCharacteristic("UV Index", Guid.ParseExact("00002a76-0000-1000-8000-00805f9b34fb", "d"));
			VO2Max = new KnownCharacteristic("VO2 Max", Guid.ParseExact("00002a96-0000-1000-8000-00805f9b34fb", "d"));
			WaistCircumference = new KnownCharacteristic("Waist Circumference", Guid.ParseExact("00002a97-0000-1000-8000-00805f9b34fb", "d"));
			Weight = new KnownCharacteristic("Weight", Guid.ParseExact("00002a98-0000-1000-8000-00805f9b34fb", "d"));
			WeightMeasurement = new KnownCharacteristic("Weight Measurement", Guid.ParseExact("00002a9d-0000-1000-8000-00805f9b34fb", "d"));
			WeightScaleFeature = new KnownCharacteristic("Weight Scale Feature", Guid.ParseExact("00002a9e-0000-1000-8000-00805f9b34fb", "d"));
			WindChill = new KnownCharacteristic("Wind Chill", Guid.ParseExact("00002a79-0000-1000-8000-00805f9b34fb", "d"));
			BatteryLevelState = new KnownCharacteristic("Battery Level State", Guid.ParseExact("00002a1b-0000-1000-8000-00805f9b34fb", "d"));
			BatteryPowerState = new KnownCharacteristic("Battery Power State", Guid.ParseExact("00002a1a-0000-1000-8000-00805f9b34fb", "d"));
			Latitude = new KnownCharacteristic("Latitude", Guid.ParseExact("00002a2d-0000-1000-8000-00805f9b34fb", "d"));
			Longitude = new KnownCharacteristic("Longitude", Guid.ParseExact("00002a2e-0000-1000-8000-00805f9b34fb", "d"));
			Position2d = new KnownCharacteristic("Position 2D", Guid.ParseExact("00002a2f-0000-1000-8000-00805f9b34fb", "d"));
			Position3d = new KnownCharacteristic("Position 3D", Guid.ParseExact("00002a30-0000-1000-8000-00805f9b34fb", "d"));
			PulseOximetryContinuousMeasurement = new KnownCharacteristic("Pulse Oximetry Continuous Measurement", Guid.ParseExact("00002a5f-0000-1000-8000-00805f9b34fb", "d"));
			PulseOximetryControlPoint = new KnownCharacteristic("Pulse Oximetry Control Point", Guid.ParseExact("00002a62-0000-1000-8000-00805f9b34fb", "d"));
			ASDF = new KnownCharacteristic("Pulse Oximetry Features", Guid.ParseExact("00002a61-0000-1000-8000-00805f9b34fb", "d"));
			PulseOximetryFeatures = new KnownCharacteristic("Pulse Oximetry Pulsatile Event", Guid.ParseExact("00002a60-0000-1000-8000-00805f9b34fb", "d"));
			PulseOximetrySpotCheckMeasurement = new KnownCharacteristic("Pulse Oximetry Spot-Check Measurement", Guid.ParseExact("00002a5e-0000-1000-8000-00805f9b34fb", "d"));
			Removable = new KnownCharacteristic("Removable", Guid.ParseExact("00002a3a-0000-1000-8000-00805f9b34fb", "d"));
			ServiceRequired = new KnownCharacteristic("Service Required", Guid.ParseExact("00002a3b-0000-1000-8000-00805f9b34fb", "d"));
			TIKeysData = new KnownCharacteristic("TI SensorTag Keys Data", Guid.ParseExact("0000ffe1-0000-1000-8000-00805f9b34fb", "d"));
			TIInfraredTempData = new KnownCharacteristic("TI SensorTag Infrared Temperature Data", Guid.ParseExact("f000aa01-0451-4000-b000-000000000000", "d"));
			TIInfraredTempDataOnOff = new KnownCharacteristic("TI SensorTag Infrared Temperature On/Off", Guid.ParseExact("f000aa02-0451-4000-b000-000000000000", "d"));
			TIInfraredTempDataSamplerate = new KnownCharacteristic("TI SensorTag Infrared Temperature Sample Rate", Guid.ParseExact("f000aa03-0451-4000-b000-000000000000", "d"));
			TIAccelerometerData = new KnownCharacteristic("TI SensorTag Accelerometer Data", Guid.ParseExact("f000aa11-0451-4000-b000-000000000000", "d"));
			TIAccelerometerOnoff = new KnownCharacteristic("TI SensorTag Accelerometer On/Off", Guid.ParseExact("f000aa12-0451-4000-b000-000000000000", "d"));
			TIAccelerometerSampleRate = new KnownCharacteristic("TI SensorTag Accelerometer Sample Rate", Guid.ParseExact("f000aa13-0451-4000-b000-000000000000", "d"));
			TIHumidityData = new KnownCharacteristic("TI SensorTag Humidity Data", Guid.ParseExact("f000aa21-0451-4000-b000-000000000000", "d"));
			TIHumidityOnOff = new KnownCharacteristic("TI SensorTag Humidity On/Off", Guid.ParseExact("f000aa22-0451-4000-b000-000000000000", "d"));
			TIHumiditySampleRate = new KnownCharacteristic("TI SensorTag Humidity Sample Rate", Guid.ParseExact("f000aa23-0451-4000-b000-000000000000", "d"));
			TIMagnometerData = new KnownCharacteristic("TI SensorTag Magnometer Data", Guid.ParseExact("f000aa31-0451-4000-b000-000000000000", "d"));
			TIMagnometerOnOff = new KnownCharacteristic("TI SensorTag Magnometer On/Off", Guid.ParseExact("f000aa32-0451-4000-b000-000000000000", "d"));
			TIMagnometerSamplerate = new KnownCharacteristic("TI SensorTag Magnometer Sample Rate", Guid.ParseExact("f000aa33-0451-4000-b000-000000000000", "d"));
			TIBarometerData = new KnownCharacteristic("TI SensorTag Barometer Data", Guid.ParseExact("f000aa41-0451-4000-b000-000000000000", "d"));
			TIBarometerOnoff = new KnownCharacteristic("TI SensorTag Barometer On/Off", Guid.ParseExact("f000aa42-0451-4000-b000-000000000000", "d"));
			TIBarometerCalibration = new KnownCharacteristic("TI SensorTag Barometer Calibration", Guid.ParseExact("f000aa43-0451-4000-b000-000000000000", "d"));
			TIBarometerSampleRate = new KnownCharacteristic("TI SensorTag Barometer Sample Rate", Guid.ParseExact("f000aa44-0451-4000-b000-000000000000", "d"));
			TIGyroscopeData = new KnownCharacteristic("TI SensorTag Gyroscope Data", Guid.ParseExact("f000aa51-0451-4000-b000-000000000000", "d"));
			TIGyroscopeOnOff = new KnownCharacteristic("TI SensorTag Gyroscope On/Off", Guid.ParseExact("f000aa52-0451-4000-b000-000000000000", "d"));
			TIGyroscopeSampleRate = new KnownCharacteristic("TI SensorTag Gyroscope Sample Rate", Guid.ParseExact("f000aa53-0451-4000-b000-000000000000", "d"));
			TITestData = new KnownCharacteristic("TI SensorTag Test Data", Guid.ParseExact("f000aa61-0451-4000-b000-000000000000", "d"));
			TITestConfig = new KnownCharacteristic("TI SensorTag Test Configuration", Guid.ParseExact("f000aa62-0451-4000-b000-000000000000", "d"));
			TIConnectionParams = new KnownCharacteristic("TI SensorTag Connection Parameters", Guid.ParseExact("f000ccc1-0451-4000-b000-000000000000", "d"));
			TIConnectionRequestParams = new KnownCharacteristic("TI SensorTag Connection Request Parameters", Guid.ParseExact("f000ccc2-0451-4000-b000-000000000000", "d"));
			TiConnectionRequestDisconnect = new KnownCharacteristic("TI SensorTag Connection Request Disconnect", Guid.ParseExact("f000ccc3-0451-4000-b000-000000000000", "d"));
			TIImageIdentify = new KnownCharacteristic("TI SensorTag OAD Image Identify", Guid.ParseExact("f000ffc1-0451-4000-b000-000000000000", "d"));
			TIImageBlock = new KnownCharacteristic("TI SensorTag OAD Image Block", Guid.ParseExact("f000ffc2-0451-4000-b000-000000000000", "d"));
			Characteristics = new List<KnownCharacteristic>
			{
				DeviceTx, DeviceRx, DfuVersion, DfuControlPoint, DfuPacket, DfuPulseOnPacket, AccelleromaterStream, AlertCategoryId, AlertCategoryIdBitMask, AlertLevel,
				AlertNotifcationControlPoint, AlertStatus, Appearance, BatteryLevel, BloodPressureFeature, BloodPressureMeasurement, BodySensorLocation, BootKeyboardInputReport, BootKeyboardOutputReport, BootMouseInputReport,
				CSCFeature, CSCMeasurement, CurrentTime, CyclingPowerControlPoint, CyclingPowerFeature, CyclingPowerMeasurement, CyclingPowerVector, DateTime, DayDateTime, DayOfWeek,
				DeviceName, DSTOffset, ExactTime, FirmwareRevisionString, GlucoseFeature, GlucoseMeasurement, GlucoseMeasureContext, HardwareRevisionString, HeartRateControlPoint, HeartRateMeasurement,
				HIDControlPoint, HIDInformation, CertDataList, CuffPressure, IntermediateTemp, LNControlPoint, LNFeature, LocalTimeInformation, LocationAndSpeed, ManufacturerNameString,
				MeasurementInterval, ModelNumberString, Navigation, NewAlert, PeripheralPreferredConnectionParams, PeripheralPrivacyFlag, PnPId, PositionQuality, ProtocolMode, ReconnectionAddress,
				RecordAccessControlPoint, ReferenceTimeInfo, Report, ReportMap, RingerControlPoint, RingerSetting, RSCFeature, RSCMeasurement, SCControlPoint, ScanIntervalWindow,
				ScanRefresh, SensorLocation, SerialNumberString, ServiceChanged, SoftwareRevisionString, SupportedNewAlertCategory, SUpportedUnreadAlertCategory, SystemId, TemperatureMeasurement, TempType,
				TimeAccuracy, TimeSource, TimeUpdateControlPoint, TimeUpdateState, TimeWithDst, TimeZone, TxPowerLevel, UnreadAlertStatus, AerobicHeartRateLowerLimit, AerobicHeartRateUpperLimit,
				Age, AggregateInput, AnaerobicHeartRateLowerLimit, AnaerobicHeartRateUpperLimit, AnaerobicThreshold, AnalongInput, FatBurnHeartRateUpperLimit, ApparentWindDirection, ApparentWindSpeed, BodyCompositionFeature,
				BodyCompositionMeasurement, DatabaseChagneIncrement, DateOfBirth, DateOfThresholdAssesment, DescriptorValueChange, DewPoint, DigitalInput, DigitalOutput, Elevation, EmailAddress,
				ExactTime100, FatBurnheartRateLowerLimit, Firstname, FiveZoneHeartRateLimits, Gender, GustFactor, HeartRatemax, HeatIndex, Height, CipCircumference,
				Humidity, Irradiance, LastName, MaxRecommededHeartRate, NetworkAvailability, PollenConcentration, Pressure, Rainfall, RestingHeartRate, ScientificTemperatureInCelsius,
				SecondaryTimeZone, SportTypeForAerobicAndAnaerobicThresholds, String, Temperature, TemperatureInCelsius, TemperatureFahrenheit, ThreeZoneHeartRateLimits, TimeBroadcast, Trend, TrueWindDirection,
				TrueWindSpeed, TwoZoneHeartRateLimit, UserControlPoint, UserIndex, UvIndex, VO2Max, WaistCircumference, Weight, WeightMeasurement, WeightScaleFeature,
				WindChill, BatteryLevelState, BatteryPowerState, Latitude, Longitude, Position2d, Position3d, PulseOximetryContinuousMeasurement, PulseOximetryControlPoint, ASDF,
				PulseOximetryFeatures, PulseOximetrySpotCheckMeasurement, Removable, ServiceRequired, TIKeysData, TIInfraredTempData, TIInfraredTempDataOnOff, TIInfraredTempDataSamplerate, TIAccelerometerData, TIAccelerometerOnoff,
				TIAccelerometerSampleRate, TIHumidityData, TIHumidityOnOff, TIHumiditySampleRate, TIMagnometerData, TIMagnometerOnOff, TIMagnometerSamplerate, TIBarometerData, TIBarometerOnoff, TIBarometerCalibration,
				TIBarometerSampleRate, TIGyroscopeData, TIGyroscopeOnOff, TIGyroscopeSampleRate, TITestData, TITestConfig, TIConnectionParams, TIConnectionRequestParams, TiConnectionRequestDisconnect, TIImageIdentify,
				TIImageBlock
			};
			UpdateDictionary();
		}

		public static KnownCharacteristic Lookup(Guid id)
		{
			if (!LookupTable.ContainsKey(id))
			{
				return null;
			}
			return LookupTable[id];
		}

		public static void AddKnownCharacteristic(KnownCharacteristic characteristic)
		{
			Characteristics.Add(characteristic);
			UpdateDictionary();
		}

		private static void UpdateDictionary()
		{
			LookupTable = Characteristics.ToDictionary((KnownCharacteristic c) => c.Id, (KnownCharacteristic c) => c);
		}
	}
	public class KnownDescriptor : NamedGuid
	{
		public KnownDescriptor(string name, Guid id)
			: base(name, id)
		{
		}
	}
	public static class KnownDescriptors
	{
		private static Dictionary<Guid, KnownDescriptor> LookupTable;

		public static readonly KnownDescriptor CharacteristicExtendedProperties;

		public static readonly KnownDescriptor CharacteristicUserDescription;

		public static readonly KnownDescriptor ClientCharacteristicConfiguration;

		public static readonly KnownDescriptor ServerCharacteristicConfiguration;

		public static readonly KnownDescriptor CharacteristicPresentationFormat;

		public static readonly KnownDescriptor CharacteristicAggregateFormat;

		public static readonly KnownDescriptor ValidRange;

		public static readonly KnownDescriptor ExternalReportReference;

		public static readonly KnownDescriptor ExportReference;

		private static readonly IList<KnownDescriptor> Descriptors;

		static KnownDescriptors()
		{
			CharacteristicExtendedProperties = new KnownDescriptor("Characteristic Extended Properties", Guid.ParseExact("00002900-0000-1000-8000-00805f9b34fb", "d"));
			CharacteristicUserDescription = new KnownDescriptor("Characteristic User Description", Guid.ParseExact("00002901-0000-1000-8000-00805f9b34fb", "d"));
			ClientCharacteristicConfiguration = new KnownDescriptor("Client Characteristic Configuration", Guid.ParseExact("00002902-0000-1000-8000-00805f9b34fb", "d"));
			ServerCharacteristicConfiguration = new KnownDescriptor("Server Characteristic Configuration", Guid.ParseExact("00002903-0000-1000-8000-00805f9b34fb", "d"));
			CharacteristicPresentationFormat = new KnownDescriptor("Characteristic Presentation Format", Guid.ParseExact("00002904-0000-1000-8000-00805f9b34fb", "d"));
			CharacteristicAggregateFormat = new KnownDescriptor("Characteristic Aggregate Format", Guid.ParseExact("00002905-0000-1000-8000-00805f9b34fb", "d"));
			ValidRange = new KnownDescriptor("Valid Range", Guid.ParseExact("00002906-0000-1000-8000-00805f9b34fb", "d"));
			ExternalReportReference = new KnownDescriptor("External Report Reference", Guid.ParseExact("00002907-0000-1000-8000-00805f9b34fb", "d"));
			ExportReference = new KnownDescriptor("Export Reference", Guid.ParseExact("00002908-0000-1000-8000-00805f9b34fb", "d"));
			Descriptors = new List<KnownDescriptor> { CharacteristicExtendedProperties, CharacteristicUserDescription, ClientCharacteristicConfiguration, ServerCharacteristicConfiguration, CharacteristicPresentationFormat, CharacteristicAggregateFormat, ValidRange, ExternalReportReference, ExportReference };
			UpdateDictionary();
		}

		public static KnownDescriptor Lookup(Guid id)
		{
			if (!LookupTable.ContainsKey(id))
			{
				return null;
			}
			return LookupTable[id];
		}

		public static void AddKnownDescriptor(KnownDescriptor descriptor)
		{
			Descriptors.Add(descriptor);
			UpdateDictionary();
		}

		private static void UpdateDictionary()
		{
			LookupTable = Descriptors.ToDictionary((KnownDescriptor s) => s.Id, (KnownDescriptor s) => s);
		}
	}
	public class KnownDevice : NamedGuid
	{
		public KnownDevice(string name, Guid id)
			: base(name, id)
		{
		}
	}
	public class KnownService : NamedGuid
	{
		public KnownService(string name, Guid id)
			: base(name, id)
		{
		}
	}
	public static class KnownServices
	{
		private const int PartialServiceIdLength = 4;

		private const int PartialServiceIdOffset = 4;

		private static Dictionary<Guid, KnownService> LookupTable;

		public static readonly KnownService AccellerometerStream;

		public static readonly KnownService FitPro;

		public static readonly KnownService Dfu;

		public static readonly KnownService PulseOn;

		public static readonly KnownService AlertNotifcationService;

		public static readonly KnownService BatteryService;

		public static readonly KnownService BloodPressure;

		public static readonly KnownService CurrentTimeService;

		public static readonly KnownService CyclingPower;

		public static readonly KnownService CyclignSpeedAndCadence;

		public static readonly KnownService DeviceInformation;

		public static readonly KnownService GenericAccess;

		public static readonly KnownService GenericAttribute;

		public static readonly KnownService Glucose;

		public static readonly KnownService HealthThermometer;

		public static readonly KnownService HeartRate;

		public static readonly KnownService HID;

		public static readonly KnownService ImmediateAlert;

		public static readonly KnownService LinkLoss;

		public static readonly KnownService LocationAndNavigation;

		public static readonly KnownService NextDSTChange;

		public static readonly KnownService PhoneAlertStatus;

		public static readonly KnownService ReferenceTimeUpdate;

		public static readonly KnownService RunningSpeedAndCadence;

		public static readonly KnownService ScanParameters;

		public static readonly KnownService TXPower;

		public static readonly KnownService TISmartKeys;

		public static readonly KnownService TIInfraredThermometer;

		public static readonly KnownService TIAccelerometer;

		public static readonly KnownService TIHumidity;

		public static readonly KnownService TIMagnometer;

		public static readonly KnownService TIBarometer;

		public static readonly KnownService TIGyroscope;

		public static readonly KnownService TITest;

		public static readonly KnownService TIConnectionControl;

		public static readonly KnownService TIOTA;

		private static readonly IList<KnownService> Services;

		static KnownServices()
		{
			AccellerometerStream = new KnownService("Accellerometer Stream", Guid.ParseExact("000043dd-100a-f596-ea4f-4c04fd0eae68", "d"));
			FitPro = new KnownService("Fit Pro", Guid.ParseExact("00001533-1412-efde-1523-785feabcd123", "d"));
			Dfu = new KnownService("Dfu", Guid.ParseExact("00001530-1212-efde-1523-785feabcd123", "d"));
			PulseOn = new KnownService("Pulse On", Guid.ParseExact("0000c167-3a98-1aab-9c40-a068750df195", "d"));
			AlertNotifcationService = new KnownService("Alert Notification Service", Guid.ParseExact("00001811-0000-1000-8000-00805f9b34fb", "d"));
			BatteryService = new KnownService("Battery Service", Guid.ParseExact("0000180f-0000-1000-8000-00805f9b34fb", "d"));
			BloodPressure = new KnownService("Blood Pressure", Guid.ParseExact("00001810-0000-1000-8000-00805f9b34fb", "d"));
			CurrentTimeService = new KnownService("Current Time Service", Guid.ParseExact("00001805-0000-1000-8000-00805f9b34fb", "d"));
			CyclingPower = new KnownService("Cycling Power", Guid.ParseExact("00001818-0000-1000-8000-00805f9b34fb", "d"));
			CyclignSpeedAndCadence = new KnownService("Cycling Speed and Cadence", Guid.ParseExact("00001816-0000-1000-8000-00805f9b34fb", "d"));
			DeviceInformation = new KnownService("Device Information", Guid.ParseExact("0000180a-0000-1000-8000-00805f9b34fb", "d"));
			GenericAccess = new KnownService("Generic Access", Guid.ParseExact("00001800-0000-1000-8000-00805f9b34fb", "d"));
			GenericAttribute = new KnownService("Generic Attribute", Guid.ParseExact("00001801-0000-1000-8000-00805f9b34fb", "d"));
			Glucose = new KnownService("Glucose", Guid.ParseExact("00001808-0000-1000-8000-00805f9b34fb", "d"));
			HealthThermometer = new KnownService("Health Thermometer", Guid.ParseExact("00001809-0000-1000-8000-00805f9b34fb", "d"));
			HeartRate = new KnownService("Heart Rate", Guid.ParseExact("0000180d-0000-1000-8000-00805f9b34fb", "d"));
			HID = new KnownService("Human Interface Device", Guid.ParseExact("00001812-0000-1000-8000-00805f9b34fb", "d"));
			ImmediateAlert = new KnownService("Immediate Alert", Guid.ParseExact("00001802-0000-1000-8000-00805f9b34fb", "d"));
			LinkLoss = new KnownService("Link Loss", Guid.ParseExact("00001803-0000-1000-8000-00805f9b34fb", "d"));
			LocationAndNavigation = new KnownService("Location and Navigation", Guid.ParseExact("00001819-0000-1000-8000-00805f9b34fb", "d"));
			NextDSTChange = new KnownService("Next DST Change", Guid.ParseExact("00001807-0000-1000-8000-00805f9b34fb", "d"));
			PhoneAlertStatus = new KnownService("Phone Alert Status", Guid.ParseExact("0000180e-0000-1000-8000-00805f9b34fb", "d"));
			ReferenceTimeUpdate = new KnownService("Reference Time Update", Guid.ParseExact("00001806-0000-1000-8000-00805f9b34fb", "d"));
			RunningSpeedAndCadence = new KnownService("Running Speed and Cadence", Guid.ParseExact("00001814-0000-1000-8000-00805f9b34fb", "d"));
			ScanParameters = new KnownService("Scan Parameters", Guid.ParseExact("00001813-0000-1000-8000-00805f9b34fb", "d"));
			TXPower = new KnownService("TX Power", Guid.ParseExact("00001804-0000-1000-8000-00805f9b34fb", "d"));
			TISmartKeys = new KnownService("TI SensorTag Smart Keys", Guid.ParseExact("0000ffe0-0000-1000-8000-00805f9b34fb", "d"));
			TIInfraredThermometer = new KnownService("TI SensorTag Infrared Thermometer", Guid.ParseExact("f000aa00-0451-4000-b000-000000000000", "d"));
			TIAccelerometer = new KnownService("TI SensorTag Accelerometer", Guid.ParseExact("f000aa10-0451-4000-b000-000000000000", "d"));
			TIHumidity = new KnownService("TI SensorTag Humidity", Guid.ParseExact("f000aa20-0451-4000-b000-000000000000", "d"));
			TIMagnometer = new KnownService("TI SensorTag Magnometer", Guid.ParseExact("f000aa30-0451-4000-b000-000000000000", "d"));
			TIBarometer = new KnownService("TI SensorTag Barometer", Guid.ParseExact("f000aa40-0451-4000-b000-000000000000", "d"));
			TIGyroscope = new KnownService("TI SensorTag Gyroscope", Guid.ParseExact("f000aa50-0451-4000-b000-000000000000", "d"));
			TITest = new KnownService("TI SensorTag Test", Guid.ParseExact("f000aa60-0451-4000-b000-000000000000", "d"));
			TIConnectionControl = new KnownService("TI SensorTag Connection Control", Guid.ParseExact("f000ccc0-0451-4000-b000-000000000000", "d"));
			TIOTA = new KnownService("TI SensorTag OvertheAir Download", Guid.ParseExact("f000ffc0-0451-4000-b000-000000000000", "d"));
			Services = new List<KnownService>
			{
				AccellerometerStream, FitPro, Dfu, PulseOn, AlertNotifcationService, BatteryService, BloodPressure, CurrentTimeService, CyclingPower, CyclignSpeedAndCadence,
				DeviceInformation, GenericAccess, GenericAttribute, Glucose, HealthThermometer, HeartRate, HID, ImmediateAlert, LinkLoss, LocationAndNavigation,
				NextDSTChange, PhoneAlertStatus, ReferenceTimeUpdate, RunningSpeedAndCadence, ScanParameters, TXPower, TISmartKeys, TIInfraredThermometer, TIAccelerometer, TIHumidity,
				TIMagnometer, TIBarometer, TIGyroscope, TITest, TIConnectionControl, TIOTA
			};
			UpdateDictionary();
		}

		public static KnownService Lookup(Guid id)
		{
			if (!LookupTable.ContainsKey(id))
			{
				return null;
			}
			return LookupTable[id];
		}

		public static KnownService PartialLookup(string partialId)
		{
			partialId = partialId?.Trim();
			if (partialId == null || partialId.Length != 4)
			{
				return null;
			}
			foreach (KnownService service in Services)
			{
				if (service != null)
				{
					_ = service.Id;
					if (service.Id.ToString().Substring(4, 4).Equals(partialId, StringComparison.OrdinalIgnoreCase))
					{
						return service;
					}
				}
			}
			return null;
		}

		public static void AddKnownService(KnownService service)
		{
			Services.Add(service);
			UpdateDictionary();
		}

		private static void UpdateDictionary()
		{
			LookupTable = Services.ToDictionary((KnownService s) => s.Id, (KnownService s) => s);
		}
	}
	public class NamedGuid
	{
		public string Name { get; private set; }

		public Guid Id { get; private set; }

		public NamedGuid(string name, Guid id)
		{
			Name = name;
			Id = id;
		}

		public override int GetHashCode()
		{
			return $"{GetType().FullName}: {Id}".GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj == this)
			{
				return true;
			}
			if (GetType() != obj.GetType())
			{
				return false;
			}
			if (obj is NamedGuid namedGuid)
			{
				return namedGuid.Id == Id;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("[{0} {1}: {2}, {3}: {4}]", GetType().Name, "Id", Id, "Name", Name ?? "<null>");
		}

		public bool IsUnknown()
		{
			return Id == Guid.Empty;
		}
	}
}
namespace Sindarin.Core.Ble.Update
{
	public class DfuDeviceFilter : BaseDeviceFilter
	{
		private readonly HashSet<KnownService> validServices = new HashSet<KnownService> { KnownServices.Dfu };

		public DfuDeviceFilter(bool allowsFitPro = false)
		{
			if (allowsFitPro)
			{
				validServices.Add(KnownServices.FitPro);
			}
		}

		protected override bool IsNameValid(IBleDevice device)
		{
			if (base.IsNameValid(device) && FitProConsoleDeviceFilterUtil.HasValidDeviceName(device))
			{
				return !string.IsNullOrWhiteSpace(device.PairKey);
			}
			return false;
		}

		protected override bool SatisfiesAdditionalConditions(IBleDevice device)
		{
			if (FitProConsoleDeviceFilterUtil.HasValidDfuDeviceName(device) && validServices.Contains(KnownServices.Dfu))
			{
				return true;
			}
			if (FitProConsoleDeviceFilterUtil.HasValidFitProDeviceName(device) && validServices.Contains(KnownServices.FitPro))
			{
				return true;
			}
			if (FitProConsoleDeviceFilterUtil.HasValidOldDeviceName(device) && validServices.Contains(KnownServices.FitPro))
			{
				return true;
			}
			return false;
		}
	}
}
namespace Sindarin.Core.Ble.Filter
{
	public abstract class BaseDeviceFilter
	{
		private const string LogTag = "Ble";

		private readonly string filterName;

		protected BaseDeviceFilter()
		{
			filterName = GetType().Name;
		}

		public bool IsDeviceValid(IBleDevice device)
		{
			if (device == null)
			{
				return false;
			}
			if (!IsNameValid(device))
			{
				device.Dispose();
				return false;
			}
			if (!SatisfiesAdditionalConditions(device))
			{
				device.Dispose();
				return false;
			}
			Log.Trace("Ble", GetType().Name + ": Found device " + device.Name + " using " + filterName);
			return true;
		}

		protected virtual bool IsNameValid(IBleDevice device)
		{
			return !string.IsNullOrWhiteSpace(device?.Name);
		}

		protected virtual bool SatisfiesAdditionalConditions(IBleDevice device)
		{
			return true;
		}
	}
	public static class FitProConsoleDeviceFilterUtil
	{
		private const string OldDeviceName = "IFIT";

		private static readonly string[] ValidFitProDeviceNames = new string[13]
		{
			"ELLIP", "TREAD", "BIKE", "STRIDE", "I_TL", "I_EB", "I_SB", "I_EL", "I_VE", "I_IT",
			"I_FS", "I_RW", "FITPRO SUPPORTED"
		};

		private static readonly string[] InvalidFitProDeviceNames = new string[15]
		{
			"ACT", "CRACKER", "ACTIVE", "GPS", "CLASSIC", "VUE", "LINK", "DUO", "AXIS", "ANTRA",
			"EXEC", "RIDGE", "SLEEP", "IFIT HRM", "IFIT ARM HR"
		};

		private static readonly string[] ValidDfuDeviceNames = new string[3] { "DFU", "IFIT UD", "I_UD" };

		public static bool HasValidDeviceName(IBleDevice device)
		{
			string nameUpper = device.Name.ToUpperInvariant();
			if (!HasValidOldDeviceName(device) && !ValidFitProDeviceNames.Any((string s) => s.Equals(nameUpper)) && !ValidDfuDeviceNames.Any((string s) => nameUpper.Contains(s)))
			{
				return nameUpper.Contains("VIRTUAL CONSOLE");
			}
			return true;
		}

		public static bool HasValidFitProDeviceName(IBleDevice device)
		{
			string nameUpper = device.Name.ToUpperInvariant();
			return ValidFitProDeviceNames.Any((string s) => nameUpper.Contains(s));
		}

		public static bool HasValidDfuDeviceName(IBleDevice device)
		{
			if (device == null || device.Name == null)
			{
				return false;
			}
			string nameUpper = device.Name.ToUpperInvariant();
			return ValidDfuDeviceNames.Any((string s) => nameUpper.Contains(s));
		}

		public static bool HasValidOldDeviceName(IBleDevice device)
		{
			string nameUpper = device.Name.ToUpperInvariant();
			if (nameUpper.Contains("IFIT"))
			{
				return !InvalidFitProDeviceNames.Any((string s) => nameUpper.Contains(s));
			}
			return false;
		}
	}
}
namespace Sindarin.Core.Ble.Connection
{
	public class ConnectionException : Exception
	{
		public ConnectionException()
		{
		}

		public ConnectionException(string msg)
			: base(msg)
		{
		}

		public ConnectionException(string msg, Exception inner)
			: base(msg, inner)
		{
		}
	}
	public class ConnectionStatus
	{
		public enum StatusType
		{
			Connecting,
			Connected,
			Disconnecting,
			Disconnected,
			Failed,
			ServicesDiscovered
		}

		public StatusType Status { get; private set; }

		public string ErrorMessage { get; private set; }

		public ConnectionStatus(StatusType status)
		{
			Status = status;
		}
	}
	public class DataPacket
	{
		public enum CommType
		{
			CharacteristicChange,
			CharacteristicRead,
			CharacteristicWrite,
			DescriptorWrite,
			DescriptorRead
		}

		public byte[] Bytes;

		public string Uuid;

		public CommType Type;

		public DataPacket(CommType type, byte[] bytes, string uuid)
		{
			Type = type;
			Bytes = bytes;
			Uuid = uuid;
		}
	}
	public abstract class DeviceBase : IBleDevice, IDisposable, ICloneable
	{
		protected class PendingWrite
		{
			public ICharacteristic Characteristic { get; }

			public byte[] Bytes { get; }

			public PendingWrite(ICharacteristic characteristic, byte[] bytes)
			{
				Characteristic = characteristic;
				Bytes = bytes;
			}
		}

		private const string BleLogTag = "Ble";

		private SemaphoreSlim deviceLock = new SemaphoreSlim(1);

		protected const int MinimumConnectTimeoutSeconds = 30;

		protected string _pairKey;

		private DeviceState _state;

		private readonly Subject<DeviceState> _whenStateChanged = new Subject<DeviceState>();

		protected readonly Subject<Unit> _whenDataChanged = new Subject<Unit>();

		protected TaskCompletionSource<bool> disconnectedTcs;

		private readonly Queue<PendingWrite> PendingWrites = new Queue<PendingWrite>();

		private bool IsWriting;

		public Guid Id { get; }

		public int Rssi { get; set; }

		public HashSet<KnownService> SupportedServices { get; }

		public string Name => PlatformDevice.Name;

		public string PairKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_pairKey))
				{
					_pairKey = this.GetManufacturerDataPairKey();
				}
				return _pairKey;
			}
		}

		public int StrengthPercentage => (140 + Rssi).Clamp(0, 100);

		public DeviceState State
		{
			get
			{
				return _state;
			}
			set
			{
				if (_state != value)
				{
					_state = value;
					_whenStateChanged.OnNext(_state);
				}
			}
		}

		public virtual bool IsMock => false;

		public IObservable<DeviceState> WhenStateChanged => _whenStateChanged;

		public IObservable<Unit> WhenDataChanged => _whenDataChanged;

		public IPlatformDevice PlatformDevice { get; }

		public List<AdvertisementRecord> AdvertisementRecords { get; }

		public bool RequestedDisconnect { get; private set; }

		public abstract void Connected();

		protected DeviceBase(IPlatformDevice device, int rssi, List<AdvertisementRecord> advertisementRecords, HashSet<KnownService> supportedServices)
		{
			PlatformDevice = device;
			Rssi = rssi;
			Id = ParseDeviceId(PlatformDevice.CommonIdentifier);
			AdvertisementRecords = advertisementRecords;
			SupportedServices = supportedServices;
		}

		protected abstract Task<List<IService>> GetServicesNative();

		protected abstract void WriteNative(PendingWrite item);

		protected abstract Task<bool> WriteNativeAsync(ICharacteristic characteristic, byte[] bytes, bool withResponse = true);

		public virtual Task<bool> Connect()
		{
			return Connect(TimeSpan.Zero);
		}

		public virtual Task<bool> Connect(TimeSpan additionalTimeout)
		{
			RequestedDisconnect = false;
			return Task.FromResult(result: true);
		}

		public virtual async Task<bool> Disconnect(bool forced = false)
		{
			Log.Trace("Ble", $"Disconnect requested from {Name}, forced={forced}, State={State}");
			RequestedDisconnect = true;
			bool disconnected = false;
			if (!(await deviceLock.WaitAsync(TimeSpan.FromSeconds(10.0))))
			{
				Log.Trace("Ble", $"Semaphore \"deviceLock\" timed out from {Name}, forced={forced}, State={State}");
				return disconnected;
			}
			Log.Trace("Ble", "Semaphore \"deviceLock\" successfully entered.");
			try
			{
				if (State == DeviceState.Disconnected)
				{
					Log.Trace("Ble", "Already disconnected from " + Name + ", doing nothing");
					return true;
				}
				if (State == DeviceState.LostConnection)
				{
					State = DeviceState.Disconnected;
					disconnected = true;
				}
				else
				{
					disconnectedTcs = new TaskCompletionSource<bool>();
					DisconnectWasCalled();
					bool flag = !forced;
					if (flag)
					{
						flag = await disconnectedTcs.Task;
					}
					disconnected = flag;
				}
			}
			catch (Exception ex)
			{
				Log.Error("Ble", "Error disconnecting from " + Name + ": " + ex.Message);
			}
			finally
			{
				if (forced || disconnected)
				{
					Dispose();
				}
				deviceLock.Release();
				Log.Trace("Ble", "Semaphore \"deviceLock\" successfully released.");
				Log.Trace("Ble", $"Disconnect result from {Name}, forced={forced}, State={State}");
			}
			return disconnected;
		}

		public void WasDisconnected()
		{
			Log.Trace("Ble", $"Device {Name} was disconnected, State={State}, requestedDisconnect={RequestedDisconnect}");
			_ = State;
			if (RequestedDisconnect)
			{
				State = DeviceState.Disconnected;
				disconnectedTcs?.TrySetResult(result: true);
			}
			else
			{
				State = DeviceState.LostConnection;
			}
			Log.Trace("Ble", $"Device {Name} disconnected, State={State}");
		}

		protected virtual void DisconnectWasCalled()
		{
			Observable.Timer(TimeSpan.FromSeconds(10.0)).Subscribe(delegate
			{
				disconnectedTcs?.TrySetResult(result: false);
			});
		}

		public void Write(ICharacteristic characteristic, byte[] bytes)
		{
			PendingWrite item = new PendingWrite(characteristic, bytes);
			PendingWrites.Enqueue(item);
			CheckQueue();
		}

		public virtual Task<bool> RemoveBond()
		{
			return Task.FromResult(result: true);
		}

		public async Task<bool> WriteAsync(ICharacteristic characteristic, byte[] bytes, bool withResponse = true)
		{
			return await WriteNativeAsync(characteristic, bytes, withResponse);
		}

		protected void WriteBytesCompleted()
		{
			IsWriting = false;
			CheckQueue();
		}

		private void CheckQueue()
		{
			if (!IsWriting && PendingWrites.Count != 0)
			{
				IsWriting = true;
				PendingWrite pendingWrite = PendingWrites.Dequeue();
				if (pendingWrite == null)
				{
					PendingWrites.Clear();
					IsWriting = false;
				}
				else
				{
					WriteNative(pendingWrite);
				}
			}
		}

		public async Task<List<IService>> GetServices()
		{
			return await GetServicesNative();
		}

		public static Guid ParseDeviceId(string address)
		{
			if (Guid.TryParse(address, out var result))
			{
				return result;
			}
			byte[] bytes = new UTF8Encoding().GetBytes(address);
			HMac hMac = new HMac(new Sha1Digest());
			hMac.BlockUpdate(bytes, 0, bytes.Length);
			byte[] array = new byte[hMac.GetMacSize()];
			hMac.DoFinal(array, 0);
			byte[] array2 = new byte[16];
			Array.Copy(array, array2, array2.Length);
			return new Guid(array2);
		}

		public override string ToString()
		{
			return Name;
		}

		public virtual void Dispose()
		{
			disconnectedTcs?.TrySetResult(result: false);
			disconnectedTcs = null;
		}

		public abstract object Clone();
	}
	public enum DeviceState
	{
		Disconnected,
		Connecting,
		Connected,
		LostConnection
	}
	public interface IBleDevice : IDisposable, ICloneable
	{
		bool RequestedDisconnect { get; }

		int Rssi { get; set; }

		int StrengthPercentage { get; }

		string Name { get; }

		string PairKey { get; }

		bool IsMock { get; }

		Guid Id { get; }

		DeviceState State { get; }

		IPlatformDevice PlatformDevice { get; }

		List<AdvertisementRecord> AdvertisementRecords { get; }

		IObservable<DeviceState> WhenStateChanged { get; }

		IObservable<Unit> WhenDataChanged { get; }

		HashSet<KnownService> SupportedServices { get; }

		Task<List<IService>> GetServices();

		Task<bool> Connect();

		Task<bool> Disconnect(bool forced = false);

		Task<bool> Connect(TimeSpan additionalTimeout);

		void WasDisconnected();

		void Connected();

		void Write(ICharacteristic characteristic, byte[] bytes);

		Task<bool> RemoveBond();
	}
	public interface IPlatformDevice
	{
		object NativeDevice { get; }

		string Name { get; }

		string CommonIdentifier { get; }

		string ShortIdentifier { get; }
	}
	public abstract class PersistentConnection : BaseConnection, IDisposable
	{
		private const string BleTag = "ble";

		private const string ConnectionTag = "BleConnection";

		public Func<int, TimeSpan> BackoffFunction = ConsoleBackoff;

		private static readonly int[] wearableBackoffs = new int[5] { 10, 30, 60, 120, 240 };

		private CancellationTokenSource reconnectCts;

		private IDisposable connLostSub;

		private IDisposable connectedSub;

		private IDisposable connectionCycleSub;

		private int retryCount;

		private int cycleConnectionCount;

		private readonly IBleRadioStatusService bluetoothStatusService;

		public IBleDevice Device { get; protected set; }

		protected virtual int MaxRetries => 4;

		protected virtual TimeSpan RetryDelay => BackoffFunction(retryCount);

		public bool ShouldReconnect { get; set; } = true;

		protected PersistentConnection(IBleDevice device, IBleRadioStatusService bluetoothStatusService)
		{
			PersistentConnection persistentConnection = this;
			Device = device;
			this.bluetoothStatusService = bluetoothStatusService;
			connectedSub = Device.WhenStateChanged.Where((DeviceState x) => x == DeviceState.Connected).Publish((IObservable<DeviceState> p) => p.Take(1).Concat(p.Throttle(TimeSpan.FromMilliseconds(50.0)))).SubscribeAsync(HandleConnectedAsync);
			connLostSub = Device.WhenStateChanged.Where((DeviceState x) => x == DeviceState.LostConnection && persistentConnection.ShouldReconnect).SubscribeAsync(delegate
			{
				Log.Trace("ble", "Lost persistent connection to " + persistentConnection.Device?.Name);
				persistentConnection.Initialized = false;
				return persistentConnection.ReconnectLostConnection();
			});
			if (device.State == DeviceState.Connected)
			{
				Task.Run(async delegate
				{
					await persistentConnection.HandleConnectedAsync(device.State);
				});
			}
			else
			{
				Device.Connect();
			}
		}

		public virtual void Dispose()
		{
			Log.Trace("BleConnection", "Disconnecting device " + Device?.Name + " in PersistentDevice on Dispose");
			Device?.Disconnect();
			connectedSub?.Dispose();
			connectedSub = null;
			connLostSub?.Dispose();
			connLostSub = null;
			connectionCycleSub?.Dispose();
			connectionCycleSub = null;
		}

		protected virtual async Task Connected()
		{
			Device.Connected();
			retryCount = 0;
		}

		private async Task HandleConnectedAsync(DeviceState state)
		{
			try
			{
				retryCount = 0;
				await Connected();
				cycleConnectionCount = 0;
			}
			catch (Exception ex) when (ex is TimeoutException || ex is ReadFailedException || ex is ConnectionException)
			{
				Log.Error("BleConnection", "Device " + Device?.Name + " Reconnect exception: " + ex.Message);
				connectionCycleSub?.Dispose();
				connectionCycleSub = null;
				connectionCycleSub = Device.WhenStateChanged.Where((DeviceState x) => x == DeviceState.Disconnected).Delay(TimeSpan.FromMilliseconds(2000.0)).Take(1)
					.Subscribe(CycleConnectionReconnect, CycleConnectionReconnectError);
				bool flag = Device != null;
				if (flag)
				{
					flag = !(await Device.Disconnect());
				}
				if (flag)
				{
					Log.Error("BleConnection", "Device " + Device?.Name + " recovery disconnect operation timed out");
				}
			}
			catch (Exception exception)
			{
				Log.Error("BleConnection", "Device " + Device?.Name + " Exception initializing console", exception);
				throw;
			}
		}

		protected void CycleConnectionReconnect(DeviceState x)
		{
			connectionCycleSub?.Dispose();
			connectionCycleSub = null;
			if (cycleConnectionCount < MaxRetries)
			{
				cycleConnectionCount++;
				Device?.Connect();
			}
		}

		protected void CycleConnectionReconnectError(Exception error)
		{
			Log.Trace("BleConnection", $"Device {Device?.Name} Reconnection attempts failed: {error}");
		}

		private async Task ReconnectLostConnection()
		{
			CancellationToken? previousCtsToken = reconnectCts?.Token;
			if (reconnectCts != null)
			{
				reconnectCts.Cancel();
				Log.Trace("ble", "Device " + Device.Name + " Already attempting to reconnect lost connection, so cancelling previous one.");
			}
			reconnectCts = new CancellationTokenSource();
			while (retryCount++ <= MaxRetries)
			{
				Log.Trace("BleConnection", $"Device {Device?.Name} Trying to reconnect, attempt #{retryCount}, additional delay (s): {RetryDelay.TotalSeconds}");
				bool shouldTryConnect = true;
				if (Device == null)
				{
					Log.Trace("BleConnection", "Device " + Device?.Name + " Not trying to reconnect to device because it was null");
					return;
				}
				if (Device?.RequestedDisconnect ?? false)
				{
					Log.Trace("ble", "Device " + Device?.Name + " Not trying to reconnect because a disconnected was requested!");
					shouldTryConnect = false;
				}
				IBleDevice device = Device;
				if (device == null || device.State != DeviceState.Connected)
				{
					IBleDevice device2 = Device;
					if (device2 == null || device2.State != DeviceState.Connecting)
					{
						goto IL_01b9;
					}
				}
				Log.Trace("ble", $"Device {Device?.Name} Not trying to reconnect because we are now {Device.State}");
				shouldTryConnect = false;
				goto IL_01b9;
				IL_01b9:
				if (bluetoothStatusService != null && !bluetoothStatusService.IsBluetoothRadioEnabled())
				{
					Log.Trace("ble", "Device " + Device?.Name + " Not trying to reconnect to the device because BT is off");
					shouldTryConnect = false;
				}
				if (shouldTryConnect)
				{
					try
					{
						Log.Trace("ble", "Attempting reconnect to " + Device?.Name);
						await Device.Connect(RetryDelay);
					}
					catch (Exception arg)
					{
						Log.Trace("BleConnection", $"Could not reconnect to device {Device?.Name}: {arg}");
					}
				}
				if (previousCtsToken?.IsCancellationRequested ?? false)
				{
					return;
				}
				if (shouldTryConnect)
				{
					IBleDevice device3 = Device;
					if (device3 == null || device3.State != DeviceState.Connected)
					{
						continue;
					}
				}
				reconnectCts = null;
				retryCount = 0;
				return;
			}
			Log.Trace("ble", "Not trying to reconnect to device " + Device?.Name + " because max retries have been exceeded");
			retryCount = 0;
			reconnectCts = null;
		}

		public static TimeSpan ConsoleBackoff(int count)
		{
			return TimeSpan.FromSeconds(Math.Pow(count, 2.0));
		}

		public static TimeSpan WearableBackoff(int count)
		{
			return TimeSpan.FromSeconds(wearableBackoffs[count.Clamp(0, wearableBackoffs.Length - 1)]);
		}
	}
	public class ReadFailedException : Exception
	{
		public ReadFailedException()
		{
		}

		public ReadFailedException(string msg)
			: base(msg)
		{
		}

		public ReadFailedException(string msg, Exception inner)
			: base(msg, inner)
		{
		}
	}
}
namespace Sindarin.Core.Ble.Connection.Service
{
	public interface IService : IDisposable
	{
		Guid Id { get; }

		IBleDevice Device { get; }

		string Name { get; }

		bool IsPrimary { get; }

		Task<List<ICharacteristic>> GetCharacteristics();
	}
	public abstract class ServiceBase : IService, IDisposable
	{
		public string Name => KnownServices.Lookup(Id)?.Name;

		public IBleDevice Device { get; }

		public abstract Guid Id { get; }

		public abstract bool IsPrimary { get; }

		protected ServiceBase(IBleDevice device)
		{
			Device = device;
		}

		public virtual void Dispose()
		{
		}

		protected abstract Task<List<ICharacteristic>> GetCharacteristicsNative();

		public async Task<List<ICharacteristic>> GetCharacteristics()
		{
			return await GetCharacteristicsNative();
		}
	}
}
namespace Sindarin.Core.Ble.Connection.Mocks
{
	public class MockDevice : DeviceBase
	{
		protected virtual int MockConnectTimespanMs => 2000;

		protected virtual int MockDisconnectTimespanMs => 200;

		protected virtual int MockGetServicesTimespanMs => 1;

		public MockType Type { get; set; }

		public override bool IsMock => true;

		public MockDevice(IPlatformDevice device, int rssi, List<AdvertisementRecord> advertisementRecords, string pairKey)
			: base(device, rssi, advertisementRecords, new HashSet<KnownService> { KnownServices.FitPro })
		{
			_pairKey = pairKey;
		}

		public override async Task<bool> Connect()
		{
			return await Connect(TimeSpan.Zero).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override async Task<bool> Connect(TimeSpan additionalTimeout)
		{
			base.State = DeviceState.Connecting;
			await Task.Delay(MockConnectTimespanMs + Convert.ToInt32(additionalTimeout.TotalMilliseconds)).ConfigureAwait(continueOnCapturedContext: false);
			base.State = DeviceState.Connected;
			return true;
		}

		public override void Connected()
		{
		}

		public override async Task<bool> Disconnect(bool forced = false)
		{
			await Task.Delay(MockDisconnectTimespanMs).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		public override void Dispose()
		{
		}

		protected override async Task<List<IService>> GetServicesNative()
		{
			await Task.Delay(MockGetServicesTimespanMs).ConfigureAwait(continueOnCapturedContext: false);
			return new List<IService>();
		}

		protected override void WriteNative(PendingWrite item)
		{
		}

		protected override async Task<bool> WriteNativeAsync(ICharacteristic characteristic, byte[] bytes, bool withResponse = true)
		{
			return true;
		}

		public static MockDevice MockDeviceFactory(string name, MockType type, string pairKey)
		{
			MockPlatformDevice device = new MockPlatformDevice(name, type);
			AdvertisementRecord item = new AdvertisementRecord(AdvertisementRecordType.ManufacturerSpecificData, new byte[0]);
			return new MockDevice(device, 100, new List<AdvertisementRecord> { item }, pairKey)
			{
				Type = type
			};
		}

		public static MockDevice MockBikeFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Bike", MockType.Bike, pairKey);
		}

		public static MockDevice MockEllipticalFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Elliptical", MockType.Elliptical, pairKey);
		}

		public static MockDevice MockTreadmillFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Treadmill", MockType.Treadmill, pairKey);
		}

		public static MockDevice MockVerticalEllipticalFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Vertical Elliptical", MockType.VerticalElliptical, pairKey);
		}

		public static MockDevice MockFreeStriderFactory(string pairKey)
		{
			return MockDeviceFactory("Mock FreeStrider", MockType.FreeStrider, pairKey);
		}

		public static MockDevice MockSpinBikeFactory(string pairKey)
		{
			return MockDeviceFactory("Mock TDF", MockType.SpinBike, pairKey);
		}

		public static MockDevice MockInclineBikeFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Incline Bike", MockType.InclineBike, pairKey);
		}

		public static MockDevice MockRowerFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Rower", MockType.Rower, pairKey);
		}

		public static MockDevice MockHybridFactory(string pairKey)
		{
			return MockDeviceFactory("Mock Hybrid", MockType.Hybrid, pairKey);
		}

		public override object Clone()
		{
			return new MockDevice(base.PlatformDevice, base.Rssi, base.AdvertisementRecords, base.PairKey);
		}
	}
	public static class MockDeviceUtil
	{
		private const string LogTag = "Ble";

		private static MockDevice[] GetMockDevices()
		{
			return new MockDevice[9]
			{
				MockDevice.MockTreadmillFactory("R2D2"),
				MockDevice.MockBikeFactory("C3PO"),
				MockDevice.MockEllipticalFactory("BB-8"),
				MockDevice.MockVerticalEllipticalFactory("K2SO"),
				MockDevice.MockFreeStriderFactory("HL9K"),
				MockDevice.MockSpinBikeFactory("CHPE"),
				MockDevice.MockInclineBikeFactory("BNDR"),
				MockDevice.MockRowerFactory("DD13"),
				MockDevice.MockHybridFactory("DALK")
			};
		}

		private static NonConnectedMockDevice[] GetNonConnectedDevices()
		{
			return new NonConnectedMockDevice[11]
			{
				NonConnectedMockDevice.NonConnectedMockTreadmillFactory("NOTR"),
				NonConnectedMockDevice.NonConnectedMockBikeFactory("NOBI"),
				NonConnectedMockDevice.NonConnectedMockRowerFactory("NORO"),
				NonConnectedMockDevice.NonConnectedMockEllipticalFactory("NOEL"),
				NonConnectedMockDevice.NonConnectedMockStrengthFactory("NOST"),
				NonConnectedMockDevice.NonConnectedMockYogaFactory("NOYO"),
				NonConnectedMockDevice.NonConnectedMockMindFactory("NOMI"),
				NonConnectedMockDevice.NonConnectedMockNutritionFactory("NONU"),
				NonConnectedMockDevice.NonConnectedMockCoreFactory("NOCO"),
				NonConnectedMockDevice.NonConnectedMockSleepFactory("NOSL"),
				NonConnectedMockDevice.NonConnectedMockStretchFactory("NOSH")
			};
		}

		public static NonConnectedMockDevice GetNonConnectedMockDevice(MockType type)
		{
			return GetNonConnectedDevices().FirstOrDefault((NonConnectedMockDevice x) => x.Type == type);
		}

		public static void AddMockDevices(ObservableCollection<IBleDevice> devices)
		{
			MockDevice[] mockDevices = GetMockDevices();
			foreach (MockDevice device in mockDevices)
			{
				SafelyAddDevice(devices, device);
			}
		}

		private static void SafelyAddDevice(ObservableCollection<IBleDevice> devices, MockDevice device)
		{
			try
			{
				if (!devices.Any((IBleDevice x) => x.Id.Equals(device.Id)))
				{
					devices.Add(device);
				}
			}
			catch (Exception arg)
			{
				Log.Error("Ble", $"MockExtensions.SafelyAddDevice => {arg}");
			}
		}

		public static bool TryGetMockDevice(Guid deviceGuid, out MockDevice mockDevice)
		{
			MockDevice[] mockDevices = GetMockDevices();
			NonConnectedMockDevice[] nonConnectedDevices = GetNonConnectedDevices();
			foreach (MockDevice item in mockDevices.Concat(nonConnectedDevices))
			{
				if (deviceGuid.Equals(item.Id))
				{
					mockDevice = item;
					return true;
				}
			}
			mockDevice = null;
			return false;
		}
	}
	public class MockPlatformDevice : IPlatformDevice
	{
		public string CommonIdentifier { get; }

		public string Name { get; }

		public object NativeDevice { get; }

		public string ShortIdentifier => CommonIdentifier;

		public MockPlatformDevice(string name, MockType type)
		{
			Name = name;
			CommonIdentifier = new Guid((int)type, 0, 0, new byte[8]).ToString();
		}
	}
	public class NonConnectedMockDevice : MockDevice
	{
		protected override int MockConnectTimespanMs => 1;

		protected override int MockDisconnectTimespanMs => 1;

		public NonConnectedMockDevice(IPlatformDevice device, int rssi, List<AdvertisementRecord> advertisementRecords, string pairKey)
			: base(device, rssi, advertisementRecords, pairKey)
		{
		}

		public static NonConnectedMockDevice NonConnectedMockDeviceFactory(string name, MockType type, string pairKey)
		{
			NonConnectedMockPlatformDevice device = new NonConnectedMockPlatformDevice(name, type);
			AdvertisementRecord item = new AdvertisementRecord(AdvertisementRecordType.ManufacturerSpecificData, new byte[0]);
			return new NonConnectedMockDevice(device, 100, new List<AdvertisementRecord> { item }, pairKey)
			{
				Type = type
			};
		}

		public static NonConnectedMockDevice NonConnectedMockBikeFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Bike", MockType.Bike, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockEllipticalFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Elliptical", MockType.Elliptical, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockTreadmillFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Treadmill", MockType.Treadmill, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockRowerFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Rower", MockType.Rower, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockStrengthFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Strength", MockType.Strength, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockYogaFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Yoga", MockType.Yoga, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockMindFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Mind", MockType.Mind, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockNutritionFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Nutrition", MockType.Nutrition, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockCoreFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Core", MockType.Core, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockSleepFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Sleep", MockType.Sleep, pairKey);
		}

		public static NonConnectedMockDevice NonConnectedMockStretchFactory(string pairKey)
		{
			return NonConnectedMockDeviceFactory("Nonconnected Stretch", MockType.Stretch, pairKey);
		}
	}
	public class NonConnectedMockPlatformDevice : IPlatformDevice
	{
		public string CommonIdentifier { get; }

		public string Name { get; }

		public object NativeDevice { get; }

		public string ShortIdentifier => CommonIdentifier;

		public NonConnectedMockPlatformDevice(string name, MockType type)
		{
			Name = name;
			CommonIdentifier = new Guid((int)type, 1, 0, new byte[8]).ToString();
		}
	}
}
namespace Sindarin.Core.Ble.Connection.Descriptor
{
	public abstract class DescriptorBase : IDescriptor
	{
		public abstract Guid Id { get; }

		public string Name => KnownDescriptors.Lookup(Id)?.Name;
	}
	public interface IDescriptor
	{
		Guid Id { get; }

		string Name { get; }
	}
}
namespace Sindarin.Core.Ble.Connection.Characteristic
{
	public abstract class CharacteristicBase : ICharacteristic, IDisposable
	{
		protected readonly Subject<byte[]> whenDataChanged = new Subject<byte[]>();

		public string Name => KnownCharacteristics.Lookup(Id)?.Name;

		public IObservable<byte[]> WhenDataChanged => whenDataChanged;

		public bool CanRead => Properties.HasFlag(CharacteristicPropertyType.Read);

		public bool CanUpdate => Properties.HasFlag(CharacteristicPropertyType.Notify);

		public bool CanWrite => Properties.HasFlag(CharacteristicPropertyType.WriteWithoutResponse) | Properties.HasFlag(CharacteristicPropertyType.AppleWriteWithoutResponse);

		public abstract Guid Id { get; }

		public abstract string Uuid { get; }

		public abstract int PropertiesRaw { get; }

		public abstract CharacteristicPropertyType Properties { get; }

		public abstract void Dispose();

		protected abstract Task<byte[]> ReadNative();

		protected abstract void WriteNative(byte[] data);

		protected abstract Task<bool> WriteNativeAsync(byte[] data, bool withResponse = true);

		protected abstract Task StartUpdatesNative();

		protected abstract Task StopUpdatesNative();

		public async Task<byte[]> Read()
		{
			if (!CanRead)
			{
				throw new InvalidOperationException("Characteristic does not support read.");
			}
			return await ReadNative();
		}

		public async Task<bool> WriteAsync(byte[] data, bool withResponse = true)
		{
			if (!CanWrite)
			{
				throw new InvalidOperationException("Characteristic does not support write.");
			}
			return await WriteNativeAsync(data, withResponse);
		}

		public async Task StartUpdates()
		{
			if (!CanUpdate)
			{
				throw new InvalidOperationException("Characteristic does not support update.");
			}
			await StartUpdatesNative();
		}

		public async Task StopUpdates()
		{
			if (CanUpdate)
			{
				await StopUpdatesNative();
			}
		}
	}
	[Flags]
	public enum CharacteristicPropertyType
	{
		Broadcast = 1,
		Read = 2,
		AppleWriteWithoutResponse = 4,
		WriteWithoutResponse = 8,
		Notify = 0x10,
		Indicate = 0x20,
		AuthenticatedSignedWrites = 0x40,
		ExtendedProperties = 0x80,
		NotifyEncryptionRequired = 0x100,
		IndicateEncryptionRequired = 0x200
	}
	public interface ICharacteristic : IDisposable
	{
		Guid Id { get; }

		string Uuid { get; }

		string Name { get; }

		int PropertiesRaw { get; }

		CharacteristicPropertyType Properties { get; }

		bool CanRead { get; }

		bool CanWrite { get; }

		bool CanUpdate { get; }

		IObservable<byte[]> WhenDataChanged { get; }

		Task<byte[]> Read();

		Task<bool> WriteAsync(byte[] data, bool withResponse = true);

		Task StartUpdates();

		Task StopUpdates();
	}
}
