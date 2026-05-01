using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit Mobile Formatters")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Formatters")]
[assembly: AssemblyTitle("iFit.Formatters")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Formatters;

public static class FileSizeFormatter
{
	private const long bytesInKb = 1024L;

	private const long bytesInMb = 1048576L;

	private const long bytesInGb = 1073741824L;

	public static string FormatDownloadProgress(long bytesReceived, long bytesTotal)
	{
		string text = FormatToSize(bytesReceived);
		string text2 = FormatToSize(bytesTotal);
		return text + " of " + text2;
	}

	public static string FormatToSize(double bytes)
	{
		if (bytes < 1048576.0)
		{
			return Math.Round(bytes / 1024.0, 1) + "kb";
		}
		if (bytes < 1073741824.0)
		{
			return Math.Round(bytes / 1048576.0, 1) + "mb";
		}
		return Math.Round(bytes / 1073741824.0, 1) + "gb";
	}

	public static string FormatToSize(long bytes)
	{
		return FormatToSize((double)bytes);
	}
}
public interface IValueFormatter
{
	string BlankValue { get; }

	string Format(double value, int decimalPlaces = 0);
}
public static class ValueFormatters
{
	public static IValueFormatter SecondsFormatter { get; set; } = new SecondsValueFormatter();

	public static IValueFormatter AbbreviatedTimeFormatter { get; set; } = new AbbreviatedTimeFormatter();

	public static IValueFormatter IntegerFormatter { get; set; } = new IntegerValueFormatter();

	public static IValueFormatter DecimalFormatter { get; set; } = new DecimalValueFormatter();

	public static IValueFormatter DecimalPercentFormatter { get; set; } = new DecimalPercentValueFormatter();
}
public class SecondsValueFormatter : IValueFormatter
{
	private const string BlankString = "--:--";

	private const int SecondsInHour = 3600;

	private const int SecondsInMinute = 60;

	public string BlankValue => "--:--";

	public string Format(double value, int decimalPlaces = 0)
	{
		return FormatTimeSeconds((int)value, decimalPlaces);
	}

	private string FormatTimeSeconds(int elapsedSeconds, int decimalPlaces = 0)
	{
		long num = 0L;
		long num2 = 0L;
		if (elapsedSeconds >= 3600)
		{
			num = elapsedSeconds / 3600;
			elapsedSeconds -= (int)num * 3600;
		}
		if (elapsedSeconds >= 60)
		{
			num2 = elapsedSeconds / 60;
			elapsedSeconds -= (int)num2 * 60;
		}
		int num3 = elapsedSeconds;
		return StringFromTime(num, num2, num3, decimalPlaces);
	}

	protected virtual string StringFromTime(long hours, long minutes, long seconds, int decimalPlaces = 0)
	{
		if (hours > 0)
		{
			return $"{hours}:{minutes:00}:{seconds:00}";
		}
		if (minutes < 10)
		{
			return $"{minutes}:{seconds:00}";
		}
		return $"{minutes:00}:{seconds:00}";
	}
}
public class AbbreviatedTimeFormatter : SecondsValueFormatter
{
	protected override string StringFromTime(long hours, long minutes, long seconds, int decimalPlaces = 10)
	{
		if (hours >= decimalPlaces)
		{
			return $"{hours}:{minutes:00}";
		}
		return base.StringFromTime(hours, minutes, seconds, decimalPlaces);
	}
}
internal class IntegerValueFormatter : IValueFormatter
{
	private const string BlankString = "-";

	public string BlankValue => "-";

	public string Format(double value, int decimalPlaces = 0)
	{
		return ((long)value).ToString();
	}
}
internal class DecimalValueFormatter : IValueFormatter
{
	private const string BlankString = "-.-";

	private const string BaseFormat = "0.{0}";

	private const string ZeroPlacesFormat = "0";

	private readonly Dictionary<int, string> decimalPlaceFormatLookup = new Dictionary<int, string>();

	protected virtual string IntFormat => "0";

	protected virtual string BaseValueFormat => "0.{0}";

	public virtual string BlankValue => "-.-";

	public string Format(double value, int decimalPlaces = 0)
	{
		value = (double.IsNaN(value) ? 0.0 : value);
		return value.ToString(SaveOrRetrieveFormat(decimalPlaces));
	}

	private string SaveOrRetrieveFormat(int decimalPlaces)
	{
		if (!decimalPlaceFormatLookup.ContainsKey(decimalPlaces))
		{
			string value = ((decimalPlaces == 0) ? IntFormat : string.Format(BaseValueFormat, new string('0', decimalPlaces)));
			decimalPlaceFormatLookup[decimalPlaces] = value;
		}
		return decimalPlaceFormatLookup[decimalPlaces];
	}
}
internal class DecimalPercentValueFormatter : DecimalValueFormatter
{
	private const string BlankString = "-.-%";

	private const string BaseFormat = "0.{0}\\%";

	private const string ZeroPlacesFormat = "0\\%";

	protected override string IntFormat => "0\\%";

	protected override string BaseValueFormat => "0.{0}\\%";

	public override string BlankValue => "-.-%";
}
