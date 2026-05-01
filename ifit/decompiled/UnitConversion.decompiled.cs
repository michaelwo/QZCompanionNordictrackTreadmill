using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MathNet.Numerics;
using MvvmCross.FieldBinding;
using MvvmCross.Platform.Converters;
using iFit.Mathematics;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("UnitConversion")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("UnitConversion")]
[assembly: AssemblyTitle("UnitConversion")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace UnitConversion;

public static class Defaults
{
	public const double WeightKgs = 83.91;

	public const double UserAge = 35.0;

	public const bool UserMale = true;

	public const double Kph = 2.0;

	public const double Mph = 1.0;

	public const double KphInMps = 0.555556;

	public const double MphInMps = 0.44704;

	public const double MinIncline = -5.0;

	public const double MaxIncline = 20.0;

	public const double Incline = 0.0;

	public const double Resistance = 1.0;

	public const int Gear = 1;

	public const double MaxKph = 20.0;

	public const double MaxMph = 12.0;

	public const double MaxKphInMps = 5.55555;

	public const double MaxMphInMps = 5.36447;

	public const double MinResistance = 1.0;

	public const double MaxResistance = 26.0;

	public const double MaxWeightKg = 136.078;

	public const double MinWeightKg = 45.36;

	public const double WorkoutEstimateKph = 10.0;

	public const double WorkoutEstimateMph = 6.0;

	public const double WorkoutBikeEstimateKph = 22.5;

	public const double WorkoutBikeEstimateMph = 14.0;

	public const double CooldownMps = 0.89408;

	public const int MinGear = 1;

	public const int MaxGear = 26;

	public const double MinimumExpectedResistance = 1.0;

	public const double MaximumExpectedResistance = 26.0;

	public const double HeightMeters = 1.778;
}
public enum DistanceUnit
{
	Mi,
	Km,
	M,
	Ft,
	In
}
public static class DistanceUnitExtensions
{
	private static double GetConversionValue(this DistanceUnit DistanceUnit)
	{
		return DistanceUnit switch
		{
			DistanceUnit.Mi => 1.0, 
			DistanceUnit.Km => 0.621371192, 
			DistanceUnit.M => 0.000621371192, 
			DistanceUnit.Ft => 0.000189393939, 
			DistanceUnit.In => 1.578282E-05, 
			_ => 1.0, 
		};
	}

	public static double Convert(this DistanceUnit from, DistanceUnit to, double value)
	{
		if (from == to)
		{
			return value;
		}
		double num = value * from.GetConversionValue();
		if (to != DistanceUnit.Mi)
		{
			return num / to.GetConversionValue();
		}
		return num;
	}
}
public static class InclineResistanceUtil
{
	public static double InclineToResistanceRatio(double incline)
	{
		return (3.3333333333333335 * incline + 0.3).Clamp(0.0, 1.0);
	}

	public static double ResistanceToInclineRatio(double resistanceRatio)
	{
		resistanceRatio = resistanceRatio.Clamp(0.0, 1.0);
		return 3.0 * (resistanceRatio - 0.3) / 10.0;
	}

	public static double InclineToResistance(double incline, double minResistance, double maxResistance, bool roundResult)
	{
		double num = InclineToResistanceRatio(incline) * maxResistance;
		if (roundResult)
		{
			num = Math.Round(num);
		}
		return num.Clamp(minResistance, maxResistance);
	}

	public static double ResistanceToIncline(double resistance, double maxResistance, double minIncline, double maxIncline)
	{
		return ResistanceToInclineRatio(maxResistance.AlmostEqual(0.0) ? 0.0 : (resistance / maxResistance).Clamp(0.0, 1.0)).Clamp(minIncline, maxIncline);
	}
}
public static class ResistanceRelativeResistanceUtil
{
	public static double ResistanceToRelativeResistanceRatio(double resistance, double minRes = 1.0, double maxRes = 26.0)
	{
		return (resistance.Clamp(minRes, maxRes) - minRes) / (maxRes - minRes);
	}

	public static double ResistanceToRelativeResistance(double resistance, double minRes = 1.0, double maxRes = 26.0)
	{
		maxRes = (maxRes.AlmostEqual(0.0) ? 26.0 : maxRes);
		return ResistanceToRelativeResistanceRatio(resistance, minRes, maxRes) * 100.0;
	}

	public static double RelativeResistanceToResistance(double relativeResistance, double minResistance = 1.0, double maxResistance = 26.0, bool round = false)
	{
		double num = MathUtils.Lerp(minResistance, maxResistance, relativeResistance / 100.0);
		if (round)
		{
			num = (int)Math.Round(num, MidpointRounding.AwayFromZero);
		}
		return num;
	}
}
public enum SpeedUnit
{
	Mph,
	Kph,
	Mps
}
public static class SpeedUnitExtensions
{
	private static double GetConversionValue(this SpeedUnit speedUnit)
	{
		return speedUnit switch
		{
			SpeedUnit.Mph => 1.0, 
			SpeedUnit.Kph => 0.621371192, 
			SpeedUnit.Mps => 2.236936292, 
			_ => 1.0, 
		};
	}

	public static double Convert(this SpeedUnit from, SpeedUnit to, double value)
	{
		if (from == to)
		{
			return value;
		}
		switch (from)
		{
		case SpeedUnit.Mph:
			if (to == SpeedUnit.Kph)
			{
				return value / SpeedUnit.Kph.GetConversionValue();
			}
			return value / SpeedUnit.Mps.GetConversionValue();
		case SpeedUnit.Kph:
			if (to == SpeedUnit.Mph)
			{
				return value * SpeedUnit.Kph.GetConversionValue();
			}
			return value * SpeedUnit.Kph.GetConversionValue() / SpeedUnit.Mps.GetConversionValue();
		case SpeedUnit.Mps:
			if (to == SpeedUnit.Mph)
			{
				return value * SpeedUnit.Mps.GetConversionValue();
			}
			return value * SpeedUnit.Mps.GetConversionValue() / SpeedUnit.Kph.GetConversionValue();
		default:
			return -1.0;
		}
	}
}
public static class TypeResolver
{
	public static bool GetBool(object obj, bool defaultValue = false)
	{
		bool result = defaultValue;
		if (obj is NC<bool> nC)
		{
			result = nC.Value;
		}
		else if (obj is bool flag)
		{
			result = flag;
		}
		else if (obj != null)
		{
			result = Convert.ToBoolean(obj);
		}
		return result;
	}
}
public abstract class MetricConverter<TFrom, TTo> : MvxValueConverter<TFrom, TTo>
{
	protected override TTo Convert(TFrom value, Type targetType, object parameter, CultureInfo culture)
	{
		bool isMetric = TypeResolver.GetBool(parameter);
		return ConvertInternal(value, isMetric);
	}

	protected abstract TTo ConvertInternal(TFrom value, bool isMetric);

	protected override TFrom ConvertBack(TTo value, Type targetType, object parameter, CultureInfo culture)
	{
		bool isMetric = TypeResolver.GetBool(parameter);
		return ConvertBackInternal(value, isMetric);
	}

	protected virtual TFrom ConvertBackInternal(TTo value, bool isMetric)
	{
		return default(TFrom);
	}
}
public class MpsToSpeedConverter : MetricConverter<double, string>
{
	protected override string ConvertInternal(double value, bool isMetric)
	{
		return UnitUtil.Ensure(SpeedUnit.Mps, isMetric ? SpeedUnit.Kph : SpeedUnit.Mph, 1.0).ToString();
	}
}
public class MpsToPaceConverter : MetricConverter<double, int>
{
	protected override int ConvertInternal(double value, bool isMetric)
	{
		SpeedUnit speedUnit = UnitUtil.GetSpeedUnit(isMetric);
		double speed = UnitUtil.Ensure(SpeedUnit.Mps, speedUnit, value);
		return UnitUtil.PaceSecondsPerDistanceFromSpeed(speedUnit, speed);
	}
}
public class MetersToDistanceConverter : MetricConverter<double, double>
{
	protected override double ConvertInternal(double value, bool isMetric)
	{
		return UnitUtil.Ensure(DistanceUnit.M, UnitUtil.GetDistanceUnit(isMetric), value, 2);
	}

	protected override double ConvertBackInternal(double value, bool isMetric)
	{
		return UnitUtil.EnsureMeters(UnitUtil.GetDistanceUnit(isMetric), value);
	}
}
public class MetersToSmallDistanceConverter : MetricConverter<double, double>
{
	protected override double ConvertInternal(double value, bool isMetric)
	{
		return UnitUtil.Ensure(DistanceUnit.M, UnitUtil.GetSmallDistanceUnit(isMetric), value, 2);
	}

	protected override double ConvertBackInternal(double value, bool isMetric)
	{
		return UnitUtil.EnsureMeters(UnitUtil.GetSmallDistanceUnit(isMetric), value);
	}
}
public class SecondsToHoursMinutesConverter : MvxValueConverter<int, string>
{
	protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
	{
		return TimeSpan.FromSeconds(value).ToString("hh\\:mm");
	}
}
public static class UnitUtil
{
	private const int DefaultRoundingDigits = -1;

	public static double Ensure(SpeedUnit from, SpeedUnit to, double value, int digits = -1)
	{
		return Round(from.Convert(to, value), digits);
	}

	public static double Ensure(WeightUnit from, WeightUnit to, double value, int digits = -1)
	{
		return Round(from.Convert(to, value), digits);
	}

	public static double Ensure(DistanceUnit from, DistanceUnit to, double value, int digits = -1)
	{
		return Round(from.Convert(to, value), digits);
	}

	public static double EnsureKph(SpeedUnit from, double value, int digits = -1)
	{
		return Ensure(from, SpeedUnit.Kph, value, digits);
	}

	public static double EnsureMph(SpeedUnit from, double value, int digits = -1)
	{
		return Ensure(from, SpeedUnit.Mph, value, digits);
	}

	public static double EnsureMps(SpeedUnit from, double value, int digits = -1)
	{
		return Ensure(from, SpeedUnit.Mps, value, digits);
	}

	public static double EnsureMps(bool isMetric, double value, int digits = -1)
	{
		return Ensure(GetSpeedUnit(isMetric), SpeedUnit.Mps, value, digits);
	}

	public static double EnsureLbs(WeightUnit from, double value, int digits = -1)
	{
		return Ensure(from, WeightUnit.Lb, value, digits);
	}

	public static double EnsureKgs(WeightUnit from, double value, int digits = -1)
	{
		return Ensure(from, WeightUnit.Kg, value, digits);
	}

	public static double EnsureMiles(DistanceUnit from, double value, int digits = -1)
	{
		return Ensure(from, DistanceUnit.Mi, value, digits);
	}

	public static double EnsureKilometers(DistanceUnit from, double value, int digits = -1)
	{
		return Ensure(from, DistanceUnit.Km, value, digits);
	}

	public static double EnsureMeters(DistanceUnit from, double value, int digits = -1)
	{
		return Ensure(from, DistanceUnit.M, value, digits);
	}

	public static double EnsureFeet(DistanceUnit from, double value, int digits = -1)
	{
		return Ensure(from, DistanceUnit.Ft, value, digits);
	}

	public static double EnsureInches(DistanceUnit from, double value, int digits = -1)
	{
		return Ensure(from, DistanceUnit.In, value, digits);
	}

	public static double Round(double value, int digits)
	{
		if (double.IsNaN(value) || double.IsInfinity(value))
		{
			return 0.0;
		}
		return digits switch
		{
			-1 => value, 
			0 => (int)Math.Round(value), 
			_ => Math.Round(value, digits), 
		};
	}

	public static double Truncate(double value, int digits)
	{
		if (double.IsNaN(value) || double.IsInfinity(value))
		{
			return 0.0;
		}
		switch (digits)
		{
		case -1:
			return value;
		case 0:
			return (int)Math.Truncate(value);
		default:
			value *= Math.Pow(10.0, digits);
			value = Math.Truncate(value);
			value /= Math.Pow(10.0, digits);
			return value;
		}
	}

	public static double RoundToNearestHalf(double value)
	{
		value *= 2.0;
		value = Math.Round(value, MidpointRounding.AwayFromZero);
		value /= 2.0;
		return value;
	}

	public static int PaceSecondsPerDistanceFromSpeed(SpeedUnit unit, double speed)
	{
		if (Math.Abs(speed) < 0.01)
		{
			return 0;
		}
		if ((uint)unit <= 1u)
		{
			double num = 1.0 / speed;
			return (int)Round(3600.0 * num, 0);
		}
		throw new ArgumentException("You shouldn't ever be expecting anything other than seconds/minutes/hours per mile/km!");
	}

	public static SpeedUnit GetSpeedUnit(bool isMetric)
	{
		if (!isMetric)
		{
			return SpeedUnit.Mph;
		}
		return SpeedUnit.Kph;
	}

	public static WeightUnit GetWeightUnit(bool isMetric)
	{
		if (!isMetric)
		{
			return WeightUnit.Lb;
		}
		return WeightUnit.Kg;
	}

	public static DistanceUnit GetDistanceUnit(bool isMetric)
	{
		if (!isMetric)
		{
			return DistanceUnit.Mi;
		}
		return DistanceUnit.Km;
	}

	public static DistanceUnit GetSmallDistanceUnit(bool isMetric)
	{
		if (!isMetric)
		{
			return DistanceUnit.Ft;
		}
		return DistanceUnit.M;
	}

	public static double MpsToMphOrKph(double mps, bool isMetric, int digits = -1)
	{
		return Ensure(SpeedUnit.Mps, isMetric ? SpeedUnit.Kph : SpeedUnit.Mph, mps, digits);
	}
}
public enum WeightUnit
{
	Lb,
	Kg
}
public static class WeightUnitExtensions
{
	private static double GetConversionValue(this WeightUnit speedUnit)
	{
		return speedUnit switch
		{
			WeightUnit.Lb => 1.0, 
			WeightUnit.Kg => 2.20462262185, 
			_ => 1.0, 
		};
	}

	public static double Convert(this WeightUnit from, WeightUnit to, double value)
	{
		if (from == to)
		{
			return value;
		}
		if (from == WeightUnit.Lb && to == WeightUnit.Kg)
		{
			return value / WeightUnit.Kg.GetConversionValue();
		}
		if (from == WeightUnit.Kg && to == WeightUnit.Lb)
		{
			return value * WeightUnit.Kg.GetConversionValue();
		}
		return -1.0;
	}

	public static double KgToLb(this double value)
	{
		return WeightUnit.Kg.Convert(WeightUnit.Lb, value);
	}

	public static double LbToKg(this double value)
	{
		return WeightUnit.Lb.Convert(WeightUnit.Kg, value);
	}
}
