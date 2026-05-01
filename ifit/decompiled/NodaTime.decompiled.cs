using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using JetBrains.Annotations;
using NodaTime.Annotations;
using NodaTime.Calendars;
using NodaTime.Extensions;
using NodaTime.Fields;
using NodaTime.Globalization;
using NodaTime.Text;
using NodaTime.Text.Patterns;
using NodaTime.TimeZones;
using NodaTime.TimeZones.Cldr;
using NodaTime.TimeZones.IO;
using NodaTime.Utility;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: InternalsVisibleTo("NodaTime.Benchmarks,PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5")]
[assembly: InternalsVisibleTo("NodaTime.Test,PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5")]
[assembly: InternalsVisibleTo("NodaTime.NzdPrinter,PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5")]
[assembly: InternalsVisibleTo("NodaTime.TzdbCompiler,PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5")]
[assembly: InternalsVisibleTo("NodaTime.TzdbCompiler.Test,PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Jon Skeet")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Noda Time is a date and time API acting as an alternative to the built-in DateTime/DateTimeOffset etc types built into the .NET framework.")]
[assembly: AssemblyFileVersion("2.4.7.0")]
[assembly: AssemblyInformationalVersion("2.4.7")]
[assembly: AssemblyProduct("NodaTime")]
[assembly: AssemblyTitle("Noda Time")]
[assembly: AssemblyVersion("2.4.7.0")]
namespace JetBrains.Annotations
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
	internal sealed class CanBeNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
	internal sealed class NotNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	internal sealed class StringFormatMethodAttribute : Attribute
	{
		public string FormatParameterName { get; private set; }

		public StringFormatMethodAttribute(string formatParameterName)
		{
			FormatParameterName = formatParameterName;
		}
	}
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	internal sealed class InvokerParameterNameAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	internal sealed class ContractAnnotationAttribute : Attribute
	{
		public string Contract { get; private set; }

		public bool ForceFullStates { get; private set; }

		public ContractAnnotationAttribute([NotNull] string contract)
			: this(contract, forceFullStates: false)
		{
		}

		public ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates)
		{
			Preconditions.CheckNotNull(contract, "contract");
			Contract = contract;
			ForceFullStates = forceFullStates;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	internal sealed class LocalizationRequiredAttribute : Attribute
	{
		public bool Required { get; private set; }

		public LocalizationRequiredAttribute()
			: this(required: true)
		{
		}

		public LocalizationRequiredAttribute(bool required)
		{
			Required = required;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	internal sealed class UsedImplicitlyAttribute : Attribute
	{
		public ImplicitUseKindFlags UseKindFlags { get; private set; }

		public ImplicitUseTargetFlags TargetFlags { get; private set; }

		public UsedImplicitlyAttribute()
			: this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
		{
		}

		public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
			: this(useKindFlags, ImplicitUseTargetFlags.Default)
		{
		}

		public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
			: this(ImplicitUseKindFlags.Default, targetFlags)
		{
		}

		public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
		{
			UseKindFlags = useKindFlags;
			TargetFlags = targetFlags;
		}
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	internal sealed class MeansImplicitUseAttribute : Attribute
	{
		[UsedImplicitly]
		public ImplicitUseKindFlags UseKindFlags { get; private set; }

		[UsedImplicitly]
		public ImplicitUseTargetFlags TargetFlags { get; private set; }

		public MeansImplicitUseAttribute()
			: this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
		{
		}

		public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
			: this(useKindFlags, ImplicitUseTargetFlags.Default)
		{
		}

		public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
			: this(ImplicitUseKindFlags.Default, targetFlags)
		{
		}

		public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
		{
			UseKindFlags = useKindFlags;
			TargetFlags = targetFlags;
		}
	}
	[Flags]
	internal enum ImplicitUseKindFlags
	{
		Default = 7,
		Access = 1,
		Assign = 2,
		InstantiatedWithFixedConstructorSignature = 4,
		InstantiatedNoFixedConstructorSignature = 8
	}
	[Flags]
	internal enum ImplicitUseTargetFlags
	{
		Default = 1,
		Itself = 1,
		Members = 2,
		WithMembers = 3
	}
	[AttributeUsage(AttributeTargets.Parameter, Inherited = true)]
	internal sealed class InstantHandleAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Method, Inherited = true)]
	internal sealed class PureAttribute : Attribute
	{
	}
}
namespace NodaTime
{
	[Mutable]
	public sealed class AmbiguousTimeException : ArgumentOutOfRangeException
	{
		internal LocalDateTime LocalDateTime => EarlierMapping.LocalDateTime;

		[NotNull]
		public DateTimeZone Zone => EarlierMapping.Zone;

		public ZonedDateTime EarlierMapping { get; }

		public ZonedDateTime LaterMapping { get; }

		public AmbiguousTimeException(ZonedDateTime earlierMapping, ZonedDateTime laterMapping)
			: base(string.Concat("Local time ", earlierMapping.LocalDateTime, " is ambiguous in time zone ", earlierMapping.Zone.Id))
		{
			EarlierMapping = earlierMapping;
			LaterMapping = laterMapping;
			Preconditions.CheckArgument(earlierMapping.Zone == laterMapping.Zone, "laterMapping", "Ambiguous possible values must use the same time zone");
			Preconditions.CheckArgument(earlierMapping.LocalDateTime == laterMapping.LocalDateTime, "laterMapping", "Ambiguous possible values must have the same local date/time");
		}
	}
	public struct AnnualDate : IEquatable<AnnualDate>, IComparable<AnnualDate>, IFormattable
	{
		private readonly YearMonthDay value;

		public int Month => value.Month;

		public int Day => value.Day;

		public AnnualDate(int month, int day)
		{
			GregorianYearMonthDayCalculator.ValidateGregorianYearMonthDay(2000, month, day);
			value = new YearMonthDay(1, month, day);
		}

		[Pure]
		public LocalDate InYear(int year)
		{
			Preconditions.CheckArgumentRange("year", year, -9998, 9999);
			return new LocalDate(CalendarSystem.Iso.YearMonthDayCalculator.SetYear(value, year).WithCalendarOrdinal(CalendarOrdinal.Iso));
		}

		[Pure]
		public bool IsValidYear(int year)
		{
			if (Month == 2 && Day == 29)
			{
				return CalendarSystem.Iso.IsLeapYear(year);
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is AnnualDate)
			{
				return Equals((AnnualDate)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		public override string ToString()
		{
			return AnnualDatePattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return AnnualDatePattern.BclSupport.Format(this, patternText, formatProvider);
		}

		public bool Equals(AnnualDate other)
		{
			return value == other.value;
		}

		public int CompareTo(AnnualDate other)
		{
			return value.CompareTo(other.value);
		}

		public static bool operator ==(AnnualDate lhs, AnnualDate rhs)
		{
			return lhs.value == rhs.value;
		}

		public static bool operator !=(AnnualDate lhs, AnnualDate rhs)
		{
			return !(lhs == rhs);
		}

		public static bool operator <(AnnualDate lhs, AnnualDate rhs)
		{
			return lhs.CompareTo(rhs) < 0;
		}

		public static bool operator <=(AnnualDate lhs, AnnualDate rhs)
		{
			return lhs.CompareTo(rhs) <= 0;
		}

		public static bool operator >(AnnualDate lhs, AnnualDate rhs)
		{
			return lhs.CompareTo(rhs) > 0;
		}

		public static bool operator >=(AnnualDate lhs, AnnualDate rhs)
		{
			return lhs.CompareTo(rhs) >= 0;
		}
	}
	internal enum CalendarOrdinal
	{
		Iso,
		Gregorian,
		Julian,
		Coptic,
		HebrewCivil,
		HebrewScriptural,
		PersianSimple,
		PersianArithmetic,
		PersianAstronomical,
		IslamicAstronomicalBase15,
		IslamicAstronomicalBase16,
		IslamicAstronomicalIndian,
		IslamicAstronomicalHabashAlHasib,
		IslamicCivilBase15,
		IslamicCivilBase16,
		IslamicCivilIndian,
		IslamicCivilHabashAlHasib,
		UmAlQura,
		Badi,
		Size
	}
	[Immutable]
	public sealed class CalendarSystem
	{
		private static class PersianCalendars
		{
			internal static readonly CalendarSystem Simple;

			internal static readonly CalendarSystem Arithmetic;

			internal static readonly CalendarSystem Astronomical;

			static PersianCalendars()
			{
				Simple = new CalendarSystem(CalendarOrdinal.PersianSimple, "Persian Simple", "Persian", new PersianYearMonthDayCalculator.Simple(), Era.AnnoPersico);
				Arithmetic = new CalendarSystem(CalendarOrdinal.PersianArithmetic, "Persian Arithmetic", "Persian", new PersianYearMonthDayCalculator.Arithmetic(), Era.AnnoPersico);
				Astronomical = new CalendarSystem(CalendarOrdinal.PersianAstronomical, "Persian Algorithmic", "Persian", new PersianYearMonthDayCalculator.Astronomical(), Era.AnnoPersico);
			}
		}

		private static class IslamicCalendars
		{
			internal static readonly CalendarSystem[,] ByLeapYearPatterAndEpoch;

			static IslamicCalendars()
			{
				ByLeapYearPatterAndEpoch = new CalendarSystem[4, 2];
				checked
				{
					for (int i = 1; i <= 4; i++)
					{
						for (int j = 1; j <= 2; j++)
						{
							IslamicLeapYearPattern leapYearPattern;
							IslamicEpoch epoch;
							IslamicYearMonthDayCalculator yearMonthDayCalculator;
							CalendarOrdinal ordinal;
							unchecked
							{
								leapYearPattern = (IslamicLeapYearPattern)i;
								epoch = (IslamicEpoch)j;
								yearMonthDayCalculator = new IslamicYearMonthDayCalculator((IslamicLeapYearPattern)i, (IslamicEpoch)j);
								ordinal = (CalendarOrdinal)checked(9 + (i - 1) + (j - 1) * 4);
							}
							ByLeapYearPatterAndEpoch[i - 1, j - 1] = new CalendarSystem(ordinal, GetIslamicId(leapYearPattern, epoch), "Hijri", yearMonthDayCalculator, Era.AnnoHegirae);
						}
					}
				}
			}
		}

		private static class MiscellaneousCalendars
		{
			internal static readonly CalendarSystem Coptic;

			internal static readonly CalendarSystem UmAlQura;

			internal static readonly CalendarSystem Badi;

			static MiscellaneousCalendars()
			{
				Coptic = new CalendarSystem(CalendarOrdinal.Coptic, "Coptic", "Coptic", new CopticYearMonthDayCalculator(), Era.AnnoMartyrum);
				UmAlQura = new CalendarSystem(CalendarOrdinal.UmAlQura, "Um Al Qura", "Um Al Qura", new UmAlQuraYearMonthDayCalculator(), Era.AnnoHegirae);
				Badi = new CalendarSystem(CalendarOrdinal.Badi, "Badi", "Badi", new BadiYearMonthDayCalculator(), Era.Bahai);
			}
		}

		private static class GregorianJulianCalendars
		{
			internal static readonly CalendarSystem Gregorian;

			internal static readonly CalendarSystem Julian;

			static GregorianJulianCalendars()
			{
				JulianYearMonthDayCalculator julianYearMonthDayCalculator = new JulianYearMonthDayCalculator();
				Julian = new CalendarSystem(CalendarOrdinal.Julian, "Julian", "Julian", julianYearMonthDayCalculator, new GJEraCalculator(julianYearMonthDayCalculator));
				Gregorian = new CalendarSystem(CalendarOrdinal.Gregorian, "Gregorian", "Gregorian", IsoCalendarSystem.YearMonthDayCalculator, IsoCalendarSystem.eraCalculator);
			}
		}

		private static class HebrewCalendars
		{
			internal static readonly CalendarSystem[] ByMonthNumbering;

			static HebrewCalendars()
			{
				ByMonthNumbering = new CalendarSystem[2]
				{
					new CalendarSystem(CalendarOrdinal.HebrewCivil, "Hebrew Civil", "Hebrew", new HebrewYearMonthDayCalculator(HebrewMonthNumbering.Civil), Era.AnnoMundi),
					new CalendarSystem(CalendarOrdinal.HebrewScriptural, "Hebrew Scriptural", "Hebrew", new HebrewYearMonthDayCalculator(HebrewMonthNumbering.Scriptural), Era.AnnoMundi)
				};
			}
		}

		private const string GregorianName = "Gregorian";

		private const string GregorianId = "Gregorian";

		private const string IsoName = "ISO";

		private const string IsoId = "ISO";

		private const string CopticName = "Coptic";

		private const string CopticId = "Coptic";

		private const string BadiName = "Badi";

		private const string BadiId = "Badi";

		private const string JulianName = "Julian";

		private const string JulianId = "Julian";

		private const string IslamicName = "Hijri";

		private const string IslamicIdBase = "Hijri";

		private const string PersianName = "Persian";

		private const string PersianIdBase = "Persian";

		private const string PersianSimpleId = "Persian Simple";

		private const string PersianAstronomicalId = "Persian Algorithmic";

		private const string PersianArithmeticId = "Persian Arithmetic";

		private const string HebrewName = "Hebrew";

		private const string HebrewIdBase = "Hebrew";

		private const string HebrewCivilId = "Hebrew Civil";

		private const string HebrewScripturalId = "Hebrew Scriptural";

		private const string UmAlQuraName = "Um Al Qura";

		private const string UmAlQuraId = "Um Al Qura";

		private static readonly CalendarSystem IsoCalendarSystem;

		private static readonly CalendarSystem[] CalendarByOrdinal;

		private static readonly Dictionary<string, Func<CalendarSystem>> IdToFactoryMap;

		private readonly EraCalculator eraCalculator;

		[NotNull]
		public static IEnumerable<string> Ids => IdToFactoryMap.Keys;

		[NotNull]
		public static CalendarSystem Iso => IsoCalendarSystem;

		[NotNull]
		public static CalendarSystem Badi => MiscellaneousCalendars.Badi;

		[NotNull]
		public string Id { get; }

		[NotNull]
		public string Name { get; }

		public int MinYear { get; }

		public int MaxYear { get; }

		internal int MinDays { get; }

		internal int MaxDays { get; }

		internal CalendarOrdinal Ordinal { get; }

		[NotNull]
		public IList<Era> Eras => eraCalculator.Eras;

		internal YearMonthDayCalculator YearMonthDayCalculator { get; }

		[NotNull]
		public static CalendarSystem Gregorian => GregorianJulianCalendars.Gregorian;

		[NotNull]
		public static CalendarSystem Julian => GregorianJulianCalendars.Julian;

		[NotNull]
		public static CalendarSystem Coptic => MiscellaneousCalendars.Coptic;

		[NotNull]
		public static CalendarSystem IslamicBcl => GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Astronomical);

		[NotNull]
		public static CalendarSystem PersianSimple => PersianCalendars.Simple;

		[NotNull]
		public static CalendarSystem PersianArithmetic => PersianCalendars.Arithmetic;

		[NotNull]
		public static CalendarSystem PersianAstronomical => PersianCalendars.Astronomical;

		[NotNull]
		public static CalendarSystem HebrewCivil => GetHebrewCalendar(HebrewMonthNumbering.Civil);

		[NotNull]
		public static CalendarSystem HebrewScriptural => GetHebrewCalendar(HebrewMonthNumbering.Scriptural);

		[NotNull]
		public static CalendarSystem UmAlQura => MiscellaneousCalendars.UmAlQura;

		internal static string GetIslamicId(IslamicLeapYearPattern leapYearPattern, IslamicEpoch epoch)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} {1}-{2}", "Hijri", epoch, leapYearPattern);
		}

		static CalendarSystem()
		{
			CalendarByOrdinal = new CalendarSystem[19];
			IdToFactoryMap = new Dictionary<string, Func<CalendarSystem>>
			{
				{
					"ISO",
					() => Iso
				},
				{
					"Persian Simple",
					() => PersianSimple
				},
				{
					"Persian Arithmetic",
					() => PersianArithmetic
				},
				{
					"Persian Algorithmic",
					() => PersianAstronomical
				},
				{
					"Hebrew Civil",
					() => GetHebrewCalendar(HebrewMonthNumbering.Civil)
				},
				{
					"Hebrew Scriptural",
					() => GetHebrewCalendar(HebrewMonthNumbering.Scriptural)
				},
				{
					"Gregorian",
					() => Gregorian
				},
				{
					"Coptic",
					() => Coptic
				},
				{
					"Badi",
					() => Badi
				},
				{
					"Julian",
					() => Julian
				},
				{
					"Um Al Qura",
					() => UmAlQura
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Indian, IslamicEpoch.Civil),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Indian, IslamicEpoch.Civil)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Base15, IslamicEpoch.Civil),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Base15, IslamicEpoch.Civil)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Base16, IslamicEpoch.Civil),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Civil)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Civil),
					() => GetIslamicCalendar(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Civil)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Indian, IslamicEpoch.Astronomical),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Indian, IslamicEpoch.Astronomical)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Base15, IslamicEpoch.Astronomical),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Base15, IslamicEpoch.Astronomical)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.Base16, IslamicEpoch.Astronomical),
					() => GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Astronomical)
				},
				{
					GetIslamicId(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Astronomical),
					() => GetIslamicCalendar(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Astronomical)
				}
			};
			GregorianYearMonthDayCalculator gregorianYearMonthDayCalculator = new GregorianYearMonthDayCalculator();
			GJEraCalculator gJEraCalculator = new GJEraCalculator(gregorianYearMonthDayCalculator);
			IsoCalendarSystem = new CalendarSystem(CalendarOrdinal.Iso, "ISO", "ISO", gregorianYearMonthDayCalculator, gJEraCalculator);
		}

		[NotNull]
		public static CalendarSystem ForId([NotNull] string id)
		{
			Preconditions.CheckNotNull(id, "id");
			if (!IdToFactoryMap.TryGetValue(id, out var value))
			{
				throw new KeyNotFoundException($"No calendar system for ID {id} exists");
			}
			return value();
		}

		[NotNull]
		internal static CalendarSystem ForOrdinal([Trusted] CalendarOrdinal ordinal)
		{
			if (ordinal == CalendarOrdinal.Iso)
			{
				return IsoCalendarSystem;
			}
			CalendarSystem calendarSystem = CalendarByOrdinal[(int)ordinal];
			if (calendarSystem != null)
			{
				return calendarSystem;
			}
			return ForOrdinalUncached(ordinal);
		}

		[VisibleForTesting]
		internal static CalendarSystem ForOrdinalUncached([Trusted] CalendarOrdinal ordinal)
		{
			return ordinal switch
			{
				CalendarOrdinal.Iso => Iso, 
				CalendarOrdinal.Gregorian => Gregorian, 
				CalendarOrdinal.Julian => Julian, 
				CalendarOrdinal.Coptic => Coptic, 
				CalendarOrdinal.Badi => Badi, 
				CalendarOrdinal.HebrewCivil => HebrewCivil, 
				CalendarOrdinal.HebrewScriptural => HebrewScriptural, 
				CalendarOrdinal.PersianSimple => PersianSimple, 
				CalendarOrdinal.PersianArithmetic => PersianArithmetic, 
				CalendarOrdinal.PersianAstronomical => PersianAstronomical, 
				CalendarOrdinal.IslamicAstronomicalBase15 => GetIslamicCalendar(IslamicLeapYearPattern.Base15, IslamicEpoch.Astronomical), 
				CalendarOrdinal.IslamicAstronomicalBase16 => GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Astronomical), 
				CalendarOrdinal.IslamicAstronomicalIndian => GetIslamicCalendar(IslamicLeapYearPattern.Indian, IslamicEpoch.Astronomical), 
				CalendarOrdinal.IslamicAstronomicalHabashAlHasib => GetIslamicCalendar(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Astronomical), 
				CalendarOrdinal.IslamicCivilBase15 => GetIslamicCalendar(IslamicLeapYearPattern.Base15, IslamicEpoch.Civil), 
				CalendarOrdinal.IslamicCivilBase16 => GetIslamicCalendar(IslamicLeapYearPattern.Base16, IslamicEpoch.Civil), 
				CalendarOrdinal.IslamicCivilIndian => GetIslamicCalendar(IslamicLeapYearPattern.Indian, IslamicEpoch.Civil), 
				CalendarOrdinal.IslamicCivilHabashAlHasib => GetIslamicCalendar(IslamicLeapYearPattern.HabashAlHasib, IslamicEpoch.Civil), 
				CalendarOrdinal.UmAlQura => UmAlQura, 
				_ => throw new InvalidOperationException($"Bug in Noda Time: calendar ordinal {ordinal} missing from switch in CalendarSystem.ForOrdinal."), 
			};
		}

		[NotNull]
		public static CalendarSystem GetHebrewCalendar(HebrewMonthNumbering monthNumbering)
		{
			Preconditions.CheckArgumentRange("monthNumbering", (int)monthNumbering, 1, 2);
			return HebrewCalendars.ByMonthNumbering[(int)checked(monthNumbering - 1)];
		}

		[NotNull]
		public static CalendarSystem GetIslamicCalendar(IslamicLeapYearPattern leapYearPattern, IslamicEpoch epoch)
		{
			Preconditions.CheckArgumentRange("leapYearPattern", (int)leapYearPattern, 1, 4);
			Preconditions.CheckArgumentRange("epoch", (int)epoch, 1, 2);
			return IslamicCalendars.ByLeapYearPatterAndEpoch[(int)checked(leapYearPattern - 1), (int)checked(epoch - 1)];
		}

		private CalendarSystem(CalendarOrdinal ordinal, string id, string name, YearMonthDayCalculator yearMonthDayCalculator, Era singleEra)
			: this(ordinal, id, name, yearMonthDayCalculator, new SingleEraCalculator(singleEra, yearMonthDayCalculator))
		{
		}

		private CalendarSystem(CalendarOrdinal ordinal, string id, string name, YearMonthDayCalculator yearMonthDayCalculator, EraCalculator eraCalculator)
		{
			Ordinal = ordinal;
			Id = id;
			Name = name;
			YearMonthDayCalculator = yearMonthDayCalculator;
			MinYear = yearMonthDayCalculator.MinYear;
			MaxYear = yearMonthDayCalculator.MaxYear;
			MinDays = yearMonthDayCalculator.GetStartOfYearInDays(MinYear);
			MaxDays = checked(yearMonthDayCalculator.GetStartOfYearInDays(MaxYear + 1) - 1);
			this.eraCalculator = eraCalculator;
			CalendarByOrdinal[(int)ordinal] = this;
		}

		public int GetAbsoluteYear(int yearOfEra, [NotNull] Era era)
		{
			return eraCalculator.GetAbsoluteYear(yearOfEra, era);
		}

		public int GetMaxYearOfEra([NotNull] Era era)
		{
			return eraCalculator.GetMaxYearOfEra(era);
		}

		public int GetMinYearOfEra([NotNull] Era era)
		{
			return eraCalculator.GetMinYearOfEra(era);
		}

		internal YearMonthDayCalendar GetYearMonthDayCalendarFromDaysSinceEpoch(int daysSinceEpoch)
		{
			Preconditions.CheckArgumentRange("daysSinceEpoch", daysSinceEpoch, MinDays, MaxDays);
			return YearMonthDayCalculator.GetYearMonthDay(daysSinceEpoch).WithCalendarOrdinal(Ordinal);
		}

		public override string ToString()
		{
			return Id;
		}

		internal int GetDaysSinceEpoch([Trusted] YearMonthDay yearMonthDay)
		{
			return YearMonthDayCalculator.GetDaysSinceEpoch(yearMonthDay);
		}

		internal IsoDayOfWeek GetDayOfWeek([Trusted] YearMonthDay yearMonthDay)
		{
			int daysSinceEpoch = YearMonthDayCalculator.GetDaysSinceEpoch(yearMonthDay);
			if (daysSinceEpoch < -3)
			{
				return (IsoDayOfWeek)(7 + (daysSinceEpoch + 4) % 7);
			}
			return (IsoDayOfWeek)(1 + (daysSinceEpoch + 3) % 7);
		}

		public int GetDaysInYear(int year)
		{
			Preconditions.CheckArgumentRange("year", year, MinYear, MaxYear);
			return YearMonthDayCalculator.GetDaysInYear(year);
		}

		public int GetDaysInMonth(int year, int month)
		{
			ValidateYearMonthDay(year, month, 1);
			return YearMonthDayCalculator.GetDaysInMonth(year, month);
		}

		public bool IsLeapYear(int year)
		{
			Preconditions.CheckArgumentRange("year", year, MinYear, MaxYear);
			return YearMonthDayCalculator.IsLeapYear(year);
		}

		public int GetMonthsInYear(int year)
		{
			Preconditions.CheckArgumentRange("year", year, MinYear, MaxYear);
			return YearMonthDayCalculator.GetMonthsInYear(year);
		}

		internal void ValidateYearMonthDay(int year, int month, int day)
		{
			YearMonthDayCalculator.ValidateYearMonthDay(year, month, day);
		}

		internal int Compare([Trusted] YearMonthDay lhs, [Trusted] YearMonthDay rhs)
		{
			return YearMonthDayCalculator.Compare(lhs, rhs);
		}

		internal int GetDayOfYear([Trusted] YearMonthDay yearMonthDay)
		{
			return YearMonthDayCalculator.GetDayOfYear(yearMonthDay);
		}

		internal int GetYearOfEra([Trusted] int absoluteYear)
		{
			return eraCalculator.GetYearOfEra(absoluteYear);
		}

		internal Era GetEra([Trusted] int absoluteYear)
		{
			return eraCalculator.GetEra(absoluteYear);
		}

		[Conditional("DEBUG")]
		internal void DebugValidateYearMonthDay(YearMonthDay yearMonthDay)
		{
		}
	}
	public static class DateAdjusters
	{
		[NotNull]
		public static Func<LocalDate, LocalDate> StartOfMonth { get; } = (LocalDate date) => new LocalDate(date.Year, date.Month, 1, date.Calendar);

		[NotNull]
		public static Func<LocalDate, LocalDate> EndOfMonth { get; } = (LocalDate date) => new LocalDate(date.Year, date.Month, date.Calendar.GetDaysInMonth(date.Year, date.Month), date.Calendar);

		[NotNull]
		public static Func<LocalDate, LocalDate> DayOfMonth(int day)
		{
			return (LocalDate date) => new LocalDate(date.Year, date.Month, day, date.Calendar);
		}

		[NotNull]
		public static Func<LocalDate, LocalDate> Month(int month)
		{
			return (LocalDate date) => new LocalDate(date.Year, month, date.Day, date.Calendar);
		}

		[NotNull]
		public static Func<LocalDate, LocalDate> NextOrSame(IsoDayOfWeek dayOfWeek)
		{
			if (dayOfWeek < IsoDayOfWeek.Monday || dayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("dayOfWeek");
			}
			return (LocalDate date) => (date.DayOfWeek != dayOfWeek) ? date.Next(dayOfWeek) : date;
		}

		[NotNull]
		public static Func<LocalDate, LocalDate> PreviousOrSame(IsoDayOfWeek dayOfWeek)
		{
			if (dayOfWeek < IsoDayOfWeek.Monday || dayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("dayOfWeek");
			}
			return (LocalDate date) => (date.DayOfWeek != dayOfWeek) ? date.Previous(dayOfWeek) : date;
		}

		[NotNull]
		public static Func<LocalDate, LocalDate> Next(IsoDayOfWeek dayOfWeek)
		{
			if (dayOfWeek < IsoDayOfWeek.Monday || dayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("dayOfWeek");
			}
			return (LocalDate date) => date.Next(dayOfWeek);
		}

		[NotNull]
		public static Func<LocalDate, LocalDate> Previous(IsoDayOfWeek dayOfWeek)
		{
			if (dayOfWeek < IsoDayOfWeek.Monday || dayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("dayOfWeek");
			}
			return (LocalDate date) => date.Previous(dayOfWeek);
		}
	}
	[Immutable]
	public sealed class DateInterval : IEquatable<DateInterval>, IEnumerable<LocalDate>, IEnumerable
	{
		public LocalDate Start { get; }

		public LocalDate End { get; }

		public int Length => checked(Period.DaysBetween(Start, End) + 1);

		[NotNull]
		public CalendarSystem Calendar => Start.Calendar;

		public DateInterval(LocalDate start, LocalDate end)
		{
			Preconditions.CheckArgument(start.Calendar.Equals(end.Calendar), "end", "Calendars of start and end dates must be the same.");
			Preconditions.CheckArgument(!(end < start), "end", "End date must not be earlier than the start date");
			Start = start;
			End = end;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Initialize().Hash(Start).Hash(End)
				.Value;
		}

		public static bool operator ==(DateInterval lhs, DateInterval rhs)
		{
			if ((object)lhs == rhs)
			{
				return true;
			}
			if ((object)lhs == null || (object)rhs == null)
			{
				return false;
			}
			if (lhs.Start == rhs.Start)
			{
				return lhs.End == rhs.End;
			}
			return false;
		}

		public static bool operator !=(DateInterval lhs, DateInterval rhs)
		{
			return !(lhs == rhs);
		}

		public bool Equals(DateInterval other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			return this == obj as DateInterval;
		}

		public bool Contains(LocalDate date)
		{
			Preconditions.CheckArgument(date.Calendar.Equals(Start.Calendar), "date", "The date to check must be in the same calendar as the start and end dates");
			if (Start <= date)
			{
				return date <= End;
			}
			return false;
		}

		public bool Contains([NotNull] DateInterval interval)
		{
			ValidateInterval(interval);
			if (Contains(interval.Start))
			{
				return Contains(interval.End);
			}
			return false;
		}

		public override string ToString()
		{
			string arg = LocalDatePattern.Iso.Format(Start);
			string arg2 = LocalDatePattern.Iso.Format(End);
			return $"[{arg}, {arg2}]";
		}

		public void Deconstruct(out LocalDate start, out LocalDate end)
		{
			start = Start;
			end = End;
		}

		[CanBeNull]
		public DateInterval Intersection([NotNull] DateInterval interval)
		{
			if (!Contains(interval))
			{
				if (!interval.Contains(this))
				{
					if (!interval.Contains(Start))
					{
						if (!interval.Contains(End))
						{
							return null;
						}
						return new DateInterval(interval.Start, End);
					}
					return new DateInterval(Start, interval.End);
				}
				return this;
			}
			return interval;
		}

		[CanBeNull]
		public DateInterval Union([NotNull] DateInterval interval)
		{
			ValidateInterval(interval);
			LocalDate start = LocalDate.Min(Start, interval.Start);
			LocalDate end = LocalDate.Max(End, interval.End);
			if (Period.DaysBetween(start, end) < checked(Length + interval.Length))
			{
				return new DateInterval(start, end);
			}
			return null;
		}

		private void ValidateInterval(DateInterval interval)
		{
			Preconditions.CheckNotNull(interval, "interval");
			Preconditions.CheckArgument(interval.Calendar.Equals(Start.Calendar), "interval", "The specified interval uses a different calendar system to this one");
		}

		[NotNull]
		public IEnumerator<LocalDate> GetEnumerator()
		{
			LocalDate date = Start;
			while (date != End)
			{
				yield return date;
				date = date.PlusDays(1);
			}
			yield return End;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	[Immutable]
	public abstract class DateTimeZone : IZoneIntervalMapWithMinMax, IZoneIntervalMap
	{
		internal const string UtcId = "UTC";

		private const int FixedZoneCacheGranularitySeconds = 1800;

		private const int FixedZoneCacheMinimumSeconds = -43200;

		private const int FixedZoneCacheSize = 55;

		private static readonly DateTimeZone[] FixedZoneCache = BuildFixedZoneCache();

		[NotNull]
		public static DateTimeZone Utc { get; } = new FixedDateTimeZone(Offset.Zero);

		[NotNull]
		public string Id { get; }

		internal bool IsFixed { get; }

		public Offset MinOffset { get; }

		public Offset MaxOffset { get; }

		[NotNull]
		public static DateTimeZone ForOffset(Offset offset)
		{
			int seconds = offset.Seconds;
			if (seconds % 1800 != 0)
			{
				return new FixedDateTimeZone(offset);
			}
			int num = checked(seconds - -43200) / 1800;
			if (num < 0 || num >= 55)
			{
				return new FixedDateTimeZone(offset);
			}
			return FixedZoneCache[num];
		}

		protected DateTimeZone([NotNull] string id, bool isFixed, Offset minOffset, Offset maxOffset)
		{
			Id = Preconditions.CheckNotNull(id, "id");
			IsFixed = isFixed;
			MinOffset = minOffset;
			MaxOffset = maxOffset;
		}

		public virtual Offset GetUtcOffset(Instant instant)
		{
			return GetZoneInterval(instant).WallOffset;
		}

		[NotNull]
		public abstract ZoneInterval GetZoneInterval(Instant instant);

		[NotNull]
		public virtual ZoneLocalMapping MapLocal(LocalDateTime localDateTime)
		{
			LocalInstant localInstant = localDateTime.ToLocalInstant();
			Instant instant = localInstant.MinusZeroOffset();
			ZoneInterval zoneInterval = GetZoneInterval(instant);
			if (zoneInterval.Contains(localInstant))
			{
				ZoneInterval earlierMatchingInterval = GetEarlierMatchingInterval(zoneInterval, localInstant);
				if (earlierMatchingInterval != null)
				{
					return new ZoneLocalMapping(this, localDateTime, earlierMatchingInterval, zoneInterval, 2);
				}
				ZoneInterval laterMatchingInterval = GetLaterMatchingInterval(zoneInterval, localInstant);
				if (laterMatchingInterval != null)
				{
					return new ZoneLocalMapping(this, localDateTime, zoneInterval, laterMatchingInterval, 2);
				}
				return new ZoneLocalMapping(this, localDateTime, zoneInterval, zoneInterval, 1);
			}
			ZoneInterval earlierMatchingInterval2 = GetEarlierMatchingInterval(zoneInterval, localInstant);
			if (earlierMatchingInterval2 != null)
			{
				return new ZoneLocalMapping(this, localDateTime, earlierMatchingInterval2, earlierMatchingInterval2, 1);
			}
			ZoneInterval laterMatchingInterval2 = GetLaterMatchingInterval(zoneInterval, localInstant);
			if (laterMatchingInterval2 != null)
			{
				return new ZoneLocalMapping(this, localDateTime, laterMatchingInterval2, laterMatchingInterval2, 1);
			}
			return new ZoneLocalMapping(this, localDateTime, GetIntervalBeforeGap(localInstant), GetIntervalAfterGap(localInstant), 0);
		}

		public ZonedDateTime AtStartOfDay(LocalDate date)
		{
			LocalDateTime localDateTime = date.AtMidnight();
			ZoneLocalMapping zoneLocalMapping = MapLocal(localDateTime);
			switch (zoneLocalMapping.Count)
			{
			case 0:
			{
				ZoneInterval lateInterval = zoneLocalMapping.LateInterval;
				OffsetDateTime offsetDateTime = new OffsetDateTime(lateInterval.Start, lateInterval.WallOffset, date.Calendar);
				if (offsetDateTime.YearMonthDay != date.YearMonthDay)
				{
					throw new SkippedTimeException(localDateTime, this);
				}
				return new ZonedDateTime(offsetDateTime, this);
			}
			case 1:
			case 2:
				return new ZonedDateTime(localDateTime.WithOffset(zoneLocalMapping.EarlyInterval.WallOffset), this);
			default:
				throw new InvalidOperationException("This won't happen.");
			}
		}

		public ZonedDateTime ResolveLocal(LocalDateTime localDateTime, [NotNull] ZoneLocalMappingResolver resolver)
		{
			Preconditions.CheckNotNull(resolver, "resolver");
			return resolver(MapLocal(localDateTime));
		}

		public ZonedDateTime AtStrictly(LocalDateTime localDateTime)
		{
			return ResolveLocal(localDateTime, Resolvers.StrictResolver);
		}

		public ZonedDateTime AtLeniently(LocalDateTime localDateTime)
		{
			return ResolveLocal(localDateTime, Resolvers.LenientResolver);
		}

		private ZoneInterval GetEarlierMatchingInterval(ZoneInterval interval, LocalInstant localInstant)
		{
			Instant rawStart = interval.RawStart;
			if (localInstant.DaysSinceEpoch <= checked(rawStart.DaysSinceEpoch + 1))
			{
				ZoneInterval zoneInterval = GetZoneInterval(rawStart - Duration.Epsilon);
				if (zoneInterval.Contains(localInstant))
				{
					return zoneInterval;
				}
			}
			return null;
		}

		private ZoneInterval GetLaterMatchingInterval(ZoneInterval interval, LocalInstant localInstant)
		{
			Instant rawEnd = interval.RawEnd;
			if (localInstant.DaysSinceEpoch >= checked(rawEnd.DaysSinceEpoch - 1))
			{
				ZoneInterval zoneInterval = GetZoneInterval(rawEnd);
				if (zoneInterval.Contains(localInstant))
				{
					return zoneInterval;
				}
			}
			return null;
		}

		private ZoneInterval GetIntervalBeforeGap(LocalInstant localInstant)
		{
			Instant instant = localInstant.MinusZeroOffset();
			ZoneInterval zoneInterval = GetZoneInterval(instant);
			if (localInstant.Minus(zoneInterval.WallOffset) < zoneInterval.RawStart)
			{
				return GetZoneInterval(zoneInterval.Start - Duration.Epsilon);
			}
			return zoneInterval;
		}

		private ZoneInterval GetIntervalAfterGap(LocalInstant localInstant)
		{
			Instant instant = localInstant.MinusZeroOffset();
			ZoneInterval zoneInterval = GetZoneInterval(instant);
			if (localInstant.Minus(zoneInterval.WallOffset) < zoneInterval.RawStart)
			{
				return zoneInterval;
			}
			return GetZoneInterval(zoneInterval.End);
		}

		public override string ToString()
		{
			return Id;
		}

		[NotNull]
		private static DateTimeZone[] BuildFixedZoneCache()
		{
			DateTimeZone[] array = new DateTimeZone[55];
			checked
			{
				for (int i = 0; i < 55; i++)
				{
					int seconds = i * 1800 + -43200;
					array[i] = new FixedDateTimeZone(Offset.FromSeconds(seconds));
				}
				array[24] = Utc;
				return array;
			}
		}

		[NotNull]
		public IEnumerable<ZoneInterval> GetZoneIntervals(Instant start, Instant end)
		{
			return GetZoneIntervals(new Interval(start, end));
		}

		[NotNull]
		public IEnumerable<ZoneInterval> GetZoneIntervals(Interval interval)
		{
			Instant instant = (interval.HasStart ? interval.Start : Instant.MinValue);
			Instant end = interval.RawEnd;
			while (instant < end)
			{
				ZoneInterval zoneInterval = GetZoneInterval(instant);
				yield return zoneInterval;
				instant = zoneInterval.RawEnd;
			}
		}

		[NotNull]
		public IEnumerable<ZoneInterval> GetZoneIntervals(Interval interval, ZoneEqualityComparer.Options options)
		{
			if ((options & ~ZoneEqualityComparer.Options.StrictestMatch) != ZoneEqualityComparer.Options.OnlyMatchWallOffset)
			{
				throw new ArgumentOutOfRangeException("options", $"The value {options} is not defined within ZoneEqualityComparer.Options");
			}
			ZoneEqualityComparer.ZoneIntervalEqualityComparer zoneIntervalEqualityComparer = new ZoneEqualityComparer.ZoneIntervalEqualityComparer(options, interval);
			IEnumerable<ZoneInterval> zoneIntervals = GetZoneIntervals(interval);
			return zoneIntervalEqualityComparer.CoalesceIntervals(zoneIntervals);
		}
	}
	public static class DateTimeZoneProviders
	{
		private static class TzdbHolder
		{
			internal static readonly DateTimeZoneCache TzdbImpl;

			static TzdbHolder()
			{
				TzdbImpl = new DateTimeZoneCache(TzdbDateTimeZoneSource.Default);
			}
		}

		private static readonly object SerializationProviderLock = new object();

		private static IDateTimeZoneProvider serializationProvider;

		[NotNull]
		public static IDateTimeZoneProvider Tzdb => TzdbHolder.TzdbImpl;

		[NotNull]
		public static IDateTimeZoneProvider Serialization
		{
			get
			{
				lock (SerializationProviderLock)
				{
					return serializationProvider ?? (serializationProvider = Tzdb);
				}
			}
			set
			{
				lock (SerializationProviderLock)
				{
					serializationProvider = Preconditions.CheckNotNull(value, "value");
				}
			}
		}
	}
	public struct Duration : IEquatable<Duration>, IComparable<Duration>, IComparable, IXmlSerializable, IFormattable
	{
		internal const int MaxDays = 16777215;

		internal const int MinDays = -16777216;

		internal static readonly BigInteger MinNanoseconds = (BigInteger)(-16777216) * (BigInteger)86400000000000L;

		internal static readonly BigInteger MaxNanoseconds = (16777215 + BigInteger.One) * 86400000000000L - BigInteger.One;

		internal static readonly decimal MinDecimalNanoseconds = (decimal)MinNanoseconds;

		internal static readonly decimal MaxDecimalNanoseconds = (decimal)MaxNanoseconds;

		private static readonly double MinDoubleNanoseconds = (double)MinNanoseconds;

		private static readonly double MaxDoubleNanoseconds = (double)MaxNanoseconds;

		private const long MaxDaysForLongNanos = 106750L;

		private const long MinDaysForLongNanos = -106751L;

		private readonly int days;

		private readonly long nanoOfDay;

		public static Duration Zero => new Duration(0, 0L);

		public static Duration Epsilon => new Duration(0, 1L);

		public static Duration MaxValue => new Duration(16777215, 86399999999999L);

		public static Duration MinValue => new Duration(-16777216, 0L);

		internal static Duration OneWeek => new Duration(7, 0L);

		internal static Duration OneDay => new Duration(1, 0L);

		internal int FloorDays => days;

		internal long NanosecondOfFloorDay => nanoOfDay;

		public int Days
		{
			get
			{
				if (days < 0 && nanoOfDay != 0L)
				{
					return checked(days + 1);
				}
				return days;
			}
		}

		public long NanosecondOfDay
		{
			get
			{
				if (days < 0)
				{
					if (nanoOfDay != 0L)
					{
						return checked(nanoOfDay - 86400000000000L);
					}
					return 0L;
				}
				return nanoOfDay;
			}
		}

		public int Hours => (int)(NanosecondOfDay / 3600000000000L);

		public int Minutes => (int)(NanosecondOfDay / 60000000000L % 60);

		public int Seconds => (int)(NanosecondOfDay / 1000000000 % 60);

		public int Milliseconds => (int)(NanosecondOfDay / 1000000 % 1000);

		public int SubsecondTicks => (int)(NanosecondOfDay / 100 % 10000000);

		public int SubsecondNanoseconds => (int)(NanosecondOfDay % 1000000000);

		public long BclCompatibleTicks
		{
			get
			{
				long num = TickArithmetic.DaysAndTickOfDayToTicks(days, nanoOfDay / 100);
				if (days < 0 && nanoOfDay % 100 != 0L)
				{
					num = checked(num + 1);
				}
				return num;
			}
		}

		public double TotalDays => (double)days + (double)nanoOfDay / 86400000000000.0;

		public double TotalHours => (double)days * 24.0 + (double)nanoOfDay / 3600000000000.0;

		public double TotalMinutes => (double)days * 1440.0 + (double)nanoOfDay / 60000000000.0;

		public double TotalSeconds => (double)days * 86400.0 + (double)nanoOfDay / 1000000000.0;

		public double TotalMilliseconds => (double)days * 86400000.0 + (double)nanoOfDay / 1000000.0;

		public double TotalTicks => (double)days * 864000000000.0 + (double)nanoOfDay / 100.0;

		public double TotalNanoseconds => (double)days * 86400000000000.0 + (double)nanoOfDay;

		internal bool IsInt64Representable
		{
			get
			{
				if ((long)days >= -106751L)
				{
					return (long)days <= 106750L;
				}
				return false;
			}
		}

		private Duration(long units, string paramName, long minValue, long maxValue, long unitsPerDay, long nanosPerUnit)
		{
			Preconditions.CheckArgumentRange(paramName, units, minValue, maxValue);
			days = (int)(units / unitsPerDay);
			long num = units - unitsPerDay * days;
			if (num < 0)
			{
				days--;
				num += unitsPerDay;
			}
			nanoOfDay = num * nanosPerUnit;
		}

		internal Duration(int days, [Trusted] long nanoOfDay)
		{
			if (days < -16777216 || days > 16777215)
			{
				Preconditions.CheckArgumentRange("days", days, -16777216, 16777215);
			}
			this.days = days;
			this.nanoOfDay = nanoOfDay;
		}

		[Pure]
		internal Duration PlusSmallNanoseconds([Trusted] long smallNanos)
		{
			int num = days;
			long num2 = nanoOfDay + smallNanos;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
			}
			else if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
			}
			return new Duration(num, num2);
		}

		[Pure]
		internal Duration MinusSmallNanoseconds(long smallNanos)
		{
			int num = days;
			long num2 = nanoOfDay - smallNanos;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
			}
			else if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
			}
			return new Duration(num, num2);
		}

		public override bool Equals(object obj)
		{
			if (obj is Duration)
			{
				return Equals((Duration)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = days;
			long num2 = nanoOfDay;
			return num ^ num2.GetHashCode();
		}

		public override string ToString()
		{
			return DurationPattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return DurationPattern.BclSupport.Format(this, patternText, formatProvider);
		}

		public static Duration operator +(Duration left, Duration right)
		{
			int num = left.days + right.days;
			long num2 = left.nanoOfDay + right.nanoOfDay;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
			}
			return new Duration(num, num2);
		}

		public static Duration Add(Duration left, Duration right)
		{
			return left + right;
		}

		[Pure]
		public Duration Plus(Duration other)
		{
			return this + other;
		}

		public static Duration operator -(Duration left, Duration right)
		{
			int num = left.days - right.days;
			long num2 = left.nanoOfDay - right.nanoOfDay;
			if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
			}
			return new Duration(num, num2);
		}

		public static Duration Subtract(Duration left, Duration right)
		{
			return left - right;
		}

		[Pure]
		public Duration Minus(Duration other)
		{
			return this - other;
		}

		public static Duration operator /(Duration left, long right)
		{
			int num = left.days;
			if (num == 0 && right > 0)
			{
				return new Duration(0, left.nanoOfDay / right);
			}
			if ((long)num >= -106751L && (long)num <= 106750L)
			{
				return FromNanoseconds(left.ToInt64Nanoseconds() / right);
			}
			return FromNanoseconds(left.ToDecimalNanoseconds() / (decimal)right);
		}

		public static Duration operator /(Duration left, double right)
		{
			Preconditions.CheckArgumentRange("right", right, -1.7976931348623157E+308, 1.7976931348623157E+308);
			if (right == 0.0)
			{
				throw new DivideByZeroException("Attempt to divide a duration by zero.");
			}
			return FromNanoseconds(left.TotalNanoseconds / right);
		}

		public static double operator /(Duration left, Duration right)
		{
			double totalNanoseconds = right.TotalNanoseconds;
			if (totalNanoseconds == 0.0)
			{
				throw new DivideByZeroException("Attempt to divide by a zero duration.");
			}
			return left.TotalNanoseconds / totalNanoseconds;
		}

		public static Duration Divide(Duration left, long right)
		{
			return left / right;
		}

		public static Duration Divide(Duration left, double right)
		{
			return left / right;
		}

		public static double Divide(Duration left, Duration right)
		{
			return left / right;
		}

		public static Duration operator *(Duration left, double right)
		{
			Preconditions.CheckArgumentRange("right", right, -1.7976931348623157E+308, 1.7976931348623157E+308);
			return FromNanoseconds(left.TotalNanoseconds * right);
		}

		public static Duration operator *(Duration left, long right)
		{
			if (right == 0L || left == Zero)
			{
				return Zero;
			}
			if (right == 1)
			{
				return left;
			}
			if (left.days >= -100 && left.days < 100 && right > -1067 && right < 1067)
			{
				return FromNanoseconds(left.ToInt64NanosecondsUnchecked() * right);
			}
			return FromNanoseconds(left.ToDecimalNanoseconds() * (decimal)right);
		}

		public static Duration operator *(long left, Duration right)
		{
			return right * left;
		}

		public static Duration Multiply(Duration left, long right)
		{
			return left * right;
		}

		public static Duration Multiply(Duration left, double right)
		{
			return left * right;
		}

		public static Duration Multiply(long left, Duration right)
		{
			return left * right;
		}

		public static bool operator ==(Duration left, Duration right)
		{
			if (left.days == right.days)
			{
				return left.nanoOfDay == right.nanoOfDay;
			}
			return false;
		}

		public static bool operator !=(Duration left, Duration right)
		{
			return !(left == right);
		}

		public static bool operator <(Duration left, Duration right)
		{
			if (left.days >= right.days)
			{
				if (left.days == right.days)
				{
					return left.nanoOfDay < right.nanoOfDay;
				}
				return false;
			}
			return true;
		}

		public static bool operator <=(Duration left, Duration right)
		{
			if (left.days >= right.days)
			{
				if (left.days == right.days)
				{
					return left.nanoOfDay <= right.nanoOfDay;
				}
				return false;
			}
			return true;
		}

		public static bool operator >(Duration left, Duration right)
		{
			if (left.days <= right.days)
			{
				if (left.days == right.days)
				{
					return left.nanoOfDay > right.nanoOfDay;
				}
				return false;
			}
			return true;
		}

		public static bool operator >=(Duration left, Duration right)
		{
			if (left.days <= right.days)
			{
				if (left.days == right.days)
				{
					return left.nanoOfDay >= right.nanoOfDay;
				}
				return false;
			}
			return true;
		}

		public static Duration operator -(Duration duration)
		{
			int num = duration.days;
			long num2 = duration.nanoOfDay;
			checked
			{
				if (num2 == 0L)
				{
					return new Duration(-num, 0L);
				}
				long num3 = 86400000000000L - num2;
				return new Duration(-num - 1, num3);
			}
		}

		public static Duration Negate(Duration duration)
		{
			return -duration;
		}

		public int CompareTo(Duration other)
		{
			int num = days;
			int num2 = num.CompareTo(other.days);
			if (num2 == 0)
			{
				long num3 = nanoOfDay;
				return num3.CompareTo(other.nanoOfDay);
			}
			return num2;
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is Duration, "obj", "Object must be of type NodaTime.Duration.");
			return CompareTo((Duration)obj);
		}

		public bool Equals(Duration other)
		{
			return this == other;
		}

		public static Duration FromDays(int days)
		{
			return new Duration(days, 0L);
		}

		public static Duration FromDays(double days)
		{
			Preconditions.CheckArgumentRange("days", days, -16777216.0, 16777215.0);
			return FromNanoseconds(days * 86400000000000.0);
		}

		public static Duration FromHours(int hours)
		{
			return new Duration(hours, "hours", -402653184L, 402653183L, 24L, 3600000000000L);
		}

		public static Duration FromHours(double hours)
		{
			Preconditions.CheckArgumentRange("hours", hours, -402653184.0, 402653183.0);
			return FromNanoseconds(hours * 3600000000000.0);
		}

		public static Duration FromMinutes(long minutes)
		{
			return new Duration(minutes, "minutes", -24159191040L, 24159191039L, 1440L, 60000000000L);
		}

		public static Duration FromMinutes(double minutes)
		{
			Preconditions.CheckArgumentRange("minutes", minutes, -24159191040.0, 24159191039.0);
			return FromNanoseconds(minutes * 60000000000.0);
		}

		public static Duration FromSeconds(long seconds)
		{
			return new Duration(seconds, "seconds", -1449551462400L, 1449551462399L, 86400L, 1000000000L);
		}

		public static Duration FromSeconds(double seconds)
		{
			Preconditions.CheckArgumentRange("seconds", seconds, -1449551462400.0, 1449551462399.0);
			return FromNanoseconds(seconds * 1000000000.0);
		}

		public static Duration FromMilliseconds(long milliseconds)
		{
			return new Duration(milliseconds, "milliseconds", -1449551462400000L, 1449551462399999L, 86400000L, 1000000L);
		}

		public static Duration FromMilliseconds(double milliseconds)
		{
			Preconditions.CheckArgumentRange("milliseconds", milliseconds, -1449551462400000.0, 1449551462399999.0);
			return FromNanoseconds(milliseconds * 1000000.0);
		}

		public static Duration FromTicks(long ticks)
		{
			long tickOfDay;
			return new Duration(TickArithmetic.TicksToDaysAndTickOfDay(ticks, out tickOfDay), checked(tickOfDay * 100));
		}

		public static Duration FromTicks(double ticks)
		{
			Preconditions.CheckArgumentRange("ticks", ticks, -1.4495514624E+19, 1.4495514624E+19);
			return FromNanoseconds(ticks * 100.0);
		}

		public static Duration FromNanoseconds(long nanoseconds)
		{
			checked
			{
				int num = ((nanoseconds >= 0) ? ((int)unchecked(nanoseconds / 86400000000000L)) : ((int)unchecked(checked(nanoseconds + 1) / 86400000000000L) - 1));
				long num2 = ((nanoseconds >= -9223285636854775808L) ? (nanoseconds - num * 86400000000000L) : (nanoseconds - (num + 1) * 86400000000000L + 86400000000000L));
				return new Duration(num, num2);
			}
		}

		public static Duration FromNanoseconds(double nanoseconds)
		{
			Preconditions.CheckArgumentRange("nanoseconds", nanoseconds, MinDoubleNanoseconds, MaxDoubleNanoseconds);
			if (!(nanoseconds >= -9.223372036854776E+18) || !(nanoseconds <= 9.223372036854776E+18))
			{
				return FromNanoseconds((BigInteger)nanoseconds);
			}
			return FromNanoseconds(checked((long)nanoseconds));
		}

		public static Duration FromNanoseconds(BigInteger nanoseconds)
		{
			if (nanoseconds < MinNanoseconds || nanoseconds > MaxNanoseconds)
			{
				throw new ArgumentOutOfRangeException("nanoseconds", $"Value should be in range [{MinNanoseconds}-{MaxNanoseconds}]");
			}
			int num = ((nanoseconds >= 0L) ? ((int)(nanoseconds / 86400000000000L)) : checked((int)((nanoseconds + 1) / 86400000000000L) - 1));
			long num2 = (long)(nanoseconds - (BigInteger)num * (BigInteger)86400000000000L);
			return new Duration(num, num2);
		}

		internal static Duration FromNanoseconds(decimal nanoseconds)
		{
			if (nanoseconds < MinDecimalNanoseconds || nanoseconds > MaxDecimalNanoseconds)
			{
				throw new ArgumentOutOfRangeException("nanoseconds", $"Value should be in range [{MinNanoseconds}-{MaxNanoseconds}]");
			}
			int num = ((nanoseconds >= 0m) ? ((int)(nanoseconds / 86400000000000m)) : checked((int)((nanoseconds + 1m) / 86400000000000m) - 1));
			long num2 = (long)(nanoseconds - (decimal)num * 86400000000000m);
			return new Duration(num, num2);
		}

		public static Duration FromTimeSpan(TimeSpan timeSpan)
		{
			return FromTicks(timeSpan.Ticks);
		}

		[Pure]
		public TimeSpan ToTimeSpan()
		{
			return new TimeSpan(BclCompatibleTicks);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			DurationPattern roundtrip = DurationPattern.Roundtrip;
			string text = reader.ReadElementContentAsString();
			this = roundtrip.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteString(DurationPattern.Roundtrip.Format(this));
		}

		[Pure]
		public long ToInt64Nanoseconds()
		{
			checked
			{
				if (!IsInt64Representable)
				{
					if (days >= 0)
					{
						return days * 86400000000000L + nanoOfDay;
					}
					return (days + 1) * 86400000000000L + nanoOfDay - 86400000000000L;
				}
				return ToInt64NanosecondsUnchecked();
			}
		}

		[Pure]
		private long ToInt64NanosecondsUnchecked()
		{
			return days * 86400000000000L + nanoOfDay;
		}

		[Pure]
		public BigInteger ToBigIntegerNanoseconds()
		{
			if (!IsInt64Representable)
			{
				return (BigInteger)days * (BigInteger)86400000000000L + nanoOfDay;
			}
			return ToInt64NanosecondsUnchecked();
		}

		[Pure]
		internal decimal ToDecimalNanoseconds()
		{
			if (!IsInt64Representable)
			{
				return (decimal)days * 86400000000000m + (decimal)nanoOfDay;
			}
			return ToInt64NanosecondsUnchecked();
		}

		public static Duration Max(Duration x, Duration y)
		{
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static Duration Min(Duration x, Duration y)
		{
			if (!(x < y))
			{
				return y;
			}
			return x;
		}
	}
	public interface IClock
	{
		Instant GetCurrentInstant();
	}
	public interface IDateTimeZoneProvider
	{
		[NotNull]
		string VersionId { get; }

		[NotNull]
		ReadOnlyCollection<string> Ids { get; }

		[NotNull]
		DateTimeZone this[[NotNull] string id] { get; }

		[NotNull]
		DateTimeZone GetSystemDefault();

		[CanBeNull]
		DateTimeZone GetZoneOrNull([NotNull] string id);
	}
	public struct Instant : IEquatable<Instant>, IComparable<Instant>, IFormattable, IComparable, IXmlSerializable
	{
		internal const int MinDays = -4371222;

		internal const int MaxDays = 2932896;

		private const long MinTicks = -3776735808000000000L;

		private const long MaxTicks = 2534023007999999999L;

		private const long MinMilliseconds = -377673580800000L;

		private const long MaxMilliseconds = 253402300799999L;

		private const long MinSeconds = -377673580800L;

		private const long MaxSeconds = 253402300799L;

		internal static readonly Instant BeforeMinValue;

		internal static readonly Instant AfterMaxValue;

		[ReadWriteForEfficiency]
		private Duration duration;

		public static Instant MinValue { get; }

		public static Instant MaxValue { get; }

		internal bool IsValid
		{
			get
			{
				if (DaysSinceEpoch >= -4371222)
				{
					return DaysSinceEpoch <= 2932896;
				}
				return false;
			}
		}

		internal Duration TimeSinceEpoch => duration;

		internal int DaysSinceEpoch => duration.FloorDays;

		internal long NanosecondOfDay => duration.NanosecondOfFloorDay;

		private Instant([Trusted] int days, bool deliberatelyInvalid)
		{
			duration = new Duration(days, 0L);
		}

		private Instant([Trusted] Duration duration)
		{
			this.duration = duration;
		}

		internal Instant([Trusted] int days, [Trusted] long nanoOfDay)
		{
			duration = new Duration(days, nanoOfDay);
		}

		internal static Instant FromTrustedDuration([Trusted] Duration duration)
		{
			return new Instant(duration);
		}

		internal static Instant FromUntrustedDuration(Duration duration)
		{
			int floorDays = duration.FloorDays;
			if (floorDays < -4371222 || floorDays > 2932896)
			{
				throw new OverflowException("Operation would overflow range of Instant");
			}
			return new Instant(duration);
		}

		public int CompareTo(Instant other)
		{
			return duration.CompareTo(other.duration);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is Instant, "obj", "Object must be of type NodaTime.Instant.");
			return CompareTo((Instant)obj);
		}

		public override bool Equals(object obj)
		{
			if (obj is Instant)
			{
				return Equals((Instant)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return duration.GetHashCode();
		}

		[Pure]
		public Instant PlusTicks(long ticks)
		{
			return FromUntrustedDuration(duration + Duration.FromTicks(ticks));
		}

		[Pure]
		public Instant PlusNanoseconds(long nanoseconds)
		{
			return FromUntrustedDuration(duration + Duration.FromNanoseconds(nanoseconds));
		}

		public static Instant operator +(Instant left, Duration right)
		{
			return FromUntrustedDuration(left.duration + right);
		}

		[Pure]
		internal LocalInstant Plus(Offset offset)
		{
			return new LocalInstant(duration.PlusSmallNanoseconds(offset.Nanoseconds));
		}

		internal LocalInstant SafePlus(Offset offset)
		{
			int floorDays = duration.FloorDays;
			if (floorDays > -4371222 && floorDays < 2932896)
			{
				return Plus(offset);
			}
			if (floorDays < -4371222)
			{
				return LocalInstant.BeforeMinValue;
			}
			if (floorDays > 2932896)
			{
				return LocalInstant.AfterMaxValue;
			}
			Duration nanoseconds = duration.PlusSmallNanoseconds(offset.Nanoseconds);
			if (nanoseconds.FloorDays < -4371222)
			{
				return LocalInstant.BeforeMinValue;
			}
			if (nanoseconds.FloorDays > 2932896)
			{
				return LocalInstant.AfterMaxValue;
			}
			return new LocalInstant(nanoseconds);
		}

		public static Instant Add(Instant left, Duration right)
		{
			return left + right;
		}

		[Pure]
		public Instant Plus(Duration duration)
		{
			return this + duration;
		}

		public static Duration operator -(Instant left, Instant right)
		{
			return left.duration - right.duration;
		}

		public static Instant operator -(Instant left, Duration right)
		{
			return FromUntrustedDuration(left.duration - right);
		}

		public static Duration Subtract(Instant left, Instant right)
		{
			return left - right;
		}

		[Pure]
		public Duration Minus(Instant other)
		{
			return this - other;
		}

		[Pure]
		public static Instant Subtract(Instant left, Duration right)
		{
			return left - right;
		}

		[Pure]
		public Instant Minus(Duration duration)
		{
			return this - duration;
		}

		public static bool operator ==(Instant left, Instant right)
		{
			return left.duration == right.duration;
		}

		public static bool operator !=(Instant left, Instant right)
		{
			return !(left == right);
		}

		public static bool operator <(Instant left, Instant right)
		{
			return left.duration < right.duration;
		}

		public static bool operator <=(Instant left, Instant right)
		{
			return left.duration <= right.duration;
		}

		public static bool operator >(Instant left, Instant right)
		{
			return left.duration > right.duration;
		}

		public static bool operator >=(Instant left, Instant right)
		{
			return left.duration >= right.duration;
		}

		public static Instant FromUtc(int year, int monthOfYear, int dayOfMonth, int hourOfDay, int minuteOfHour)
		{
			int daysSinceEpoch = new LocalDate(year, monthOfYear, dayOfMonth).DaysSinceEpoch;
			long nanosecondOfDay = new LocalTime(hourOfDay, minuteOfHour).NanosecondOfDay;
			return new Instant(daysSinceEpoch, nanosecondOfDay);
		}

		public static Instant FromUtc(int year, int monthOfYear, int dayOfMonth, int hourOfDay, int minuteOfHour, int secondOfMinute)
		{
			int daysSinceEpoch = new LocalDate(year, monthOfYear, dayOfMonth).DaysSinceEpoch;
			long nanosecondOfDay = new LocalTime(hourOfDay, minuteOfHour, secondOfMinute).NanosecondOfDay;
			return new Instant(daysSinceEpoch, nanosecondOfDay);
		}

		public static Instant Max(Instant x, Instant y)
		{
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static Instant Min(Instant x, Instant y)
		{
			if (!(x < y))
			{
				return y;
			}
			return x;
		}

		public override string ToString()
		{
			return InstantPattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return InstantPattern.BclSupport.Format(this, patternText, formatProvider);
		}

		public bool Equals(Instant other)
		{
			return this == other;
		}

		[Pure]
		[TestExemption(TestExemptionCategory.ConversionName, null)]
		public double ToJulianDate()
		{
			return (this - NodaConstants.JulianEpoch).TotalDays;
		}

		[Pure]
		public DateTime ToDateTimeUtc()
		{
			if (this < NodaConstants.BclEpoch)
			{
				throw new InvalidOperationException("Instant out of range for DateTime");
			}
			return new DateTime(checked(NodaConstants.BclTicksAtUnixEpoch + ToUnixTimeTicks()), DateTimeKind.Utc);
		}

		[Pure]
		public DateTimeOffset ToDateTimeOffset()
		{
			if (this < NodaConstants.BclEpoch)
			{
				throw new InvalidOperationException("Instant out of range for DateTimeOffset");
			}
			return new DateTimeOffset(checked(NodaConstants.BclTicksAtUnixEpoch + ToUnixTimeTicks()), TimeSpan.Zero);
		}

		public static Instant FromDateTimeOffset(DateTimeOffset dateTimeOffset)
		{
			return NodaConstants.BclEpoch.PlusTicks(checked(dateTimeOffset.Ticks - dateTimeOffset.Offset.Ticks));
		}

		public static Instant FromJulianDate(double julianDate)
		{
			return NodaConstants.JulianEpoch + Duration.FromDays(julianDate);
		}

		public static Instant FromDateTimeUtc(DateTime dateTime)
		{
			Preconditions.CheckArgument(dateTime.Kind == DateTimeKind.Utc, "dateTime", "Invalid DateTime.Kind for Instant.FromDateTimeUtc");
			return NodaConstants.BclEpoch.PlusTicks(dateTime.Ticks);
		}

		public static Instant FromUnixTimeSeconds(long seconds)
		{
			Preconditions.CheckArgumentRange("seconds", seconds, -377673580800L, 253402300799L);
			return FromTrustedDuration(Duration.FromSeconds(seconds));
		}

		public static Instant FromUnixTimeMilliseconds(long milliseconds)
		{
			Preconditions.CheckArgumentRange("milliseconds", milliseconds, -377673580800000L, 253402300799999L);
			return FromTrustedDuration(Duration.FromMilliseconds(milliseconds));
		}

		public static Instant FromUnixTimeTicks(long ticks)
		{
			Preconditions.CheckArgumentRange("ticks", ticks, -3776735808000000000L, 2534023007999999999L);
			return FromTrustedDuration(Duration.FromTicks(ticks));
		}

		[Pure]
		[TestExemption(TestExemptionCategory.ConversionName, null)]
		public long ToUnixTimeSeconds()
		{
			checked
			{
				return unchecked((long)duration.FloorDays) * 86400L + unchecked(duration.NanosecondOfFloorDay / 1000000000);
			}
		}

		[Pure]
		[TestExemption(TestExemptionCategory.ConversionName, null)]
		public long ToUnixTimeMilliseconds()
		{
			checked
			{
				return unchecked((long)duration.FloorDays) * 86400000L + unchecked(duration.NanosecondOfFloorDay / 1000000);
			}
		}

		[Pure]
		[TestExemption(TestExemptionCategory.ConversionName, null)]
		public long ToUnixTimeTicks()
		{
			return TickArithmetic.BoundedDaysAndTickOfDayToTicks(duration.FloorDays, duration.NanosecondOfFloorDay / 100);
		}

		[Pure]
		public ZonedDateTime InUtc()
		{
			YearMonthDayCalendar gregorianYearMonthDayCalendarFromDaysSinceEpoch = GregorianYearMonthDayCalculator.GetGregorianYearMonthDayCalendarFromDaysSinceEpoch(duration.FloorDays);
			return new ZonedDateTime(new OffsetDateTime(gregorianYearMonthDayCalendarFromDaysSinceEpoch, duration.NanosecondOfFloorDay), DateTimeZone.Utc);
		}

		[Pure]
		public ZonedDateTime InZone([NotNull] DateTimeZone zone)
		{
			return new ZonedDateTime(this, zone);
		}

		[Pure]
		public ZonedDateTime InZone([NotNull] DateTimeZone zone, [NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(calendar, "calendar");
			return new ZonedDateTime(this, zone, calendar);
		}

		[Pure]
		public OffsetDateTime WithOffset(Offset offset)
		{
			return new OffsetDateTime(this, offset);
		}

		[Pure]
		public OffsetDateTime WithOffset(Offset offset, [NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			return new OffsetDateTime(this, offset, calendar);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			InstantPattern extendedIso = InstantPattern.ExtendedIso;
			string text = reader.ReadElementContentAsString();
			this = extendedIso.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteString(InstantPattern.ExtendedIso.Format(this));
		}

		static Instant()
		{
			MinValue = new Instant(-4371222, 0L);
			MaxValue = new Instant(2932896, 86399999999999L);
			BeforeMinValue = new Instant(-16777216, deliberatelyInvalid: true);
			AfterMaxValue = new Instant(16777215, deliberatelyInvalid: true);
		}
	}
	public struct Interval : IEquatable<Interval>, IXmlSerializable
	{
		private readonly Instant start;

		private readonly Instant end;

		public Instant Start
		{
			get
			{
				Preconditions.CheckState(start.IsValid, "Interval extends to start of time");
				return start;
			}
		}

		public bool HasStart => start.IsValid;

		public Instant End
		{
			get
			{
				Preconditions.CheckState(end.IsValid, "Interval extends to end of time");
				return end;
			}
		}

		internal Instant RawEnd => end;

		public bool HasEnd => end.IsValid;

		public Duration Duration => End - Start;

		public Interval(Instant start, Instant end)
		{
			if (end < start)
			{
				throw new ArgumentOutOfRangeException("end", "The end parameter must be equal to or later than the start parameter");
			}
			this.start = start;
			this.end = end;
		}

		public Interval(Instant? start, Instant? end)
		{
			this.start = start ?? Instant.BeforeMinValue;
			this.end = end ?? Instant.AfterMaxValue;
			if (end < start)
			{
				throw new ArgumentOutOfRangeException("end", "The end parameter must be equal to or later than the start parameter");
			}
		}

		[Pure]
		public bool Contains(Instant instant)
		{
			if (instant >= start)
			{
				return instant < end;
			}
			return false;
		}

		[Pure]
		public void Deconstruct(out Instant? start, out Instant? end)
		{
			start = (this.start.IsValid ? new Instant?(Start) : ((Instant?)null));
			end = (this.end.IsValid ? new Instant?(End) : ((Instant?)null));
		}

		public bool Equals(Interval other)
		{
			if (start == other.start)
			{
				return end == other.end;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Interval)
			{
				return Equals((Interval)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(start, end);
		}

		public override string ToString()
		{
			InstantPattern extendedIso = InstantPattern.ExtendedIso;
			return extendedIso.Format(start) + "/" + extendedIso.Format(end);
		}

		public static bool operator ==(Interval left, Interval right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Interval left, Interval right)
		{
			return !(left == right);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			InstantPattern extendedIso = InstantPattern.ExtendedIso;
			Instant instant = (reader.MoveToAttribute("start") ? extendedIso.Parse(reader.Value).Value : Instant.BeforeMinValue);
			Instant instant2 = (reader.MoveToAttribute("end") ? extendedIso.Parse(reader.Value).Value : Instant.AfterMaxValue);
			this = new Interval(instant, instant2);
			reader.Skip();
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			InstantPattern extendedIso = InstantPattern.ExtendedIso;
			if (HasStart)
			{
				writer.WriteAttributeString("start", extendedIso.Format(start));
			}
			if (HasEnd)
			{
				writer.WriteAttributeString("end", extendedIso.Format(end));
			}
		}
	}
	public enum IsoDayOfWeek
	{
		None,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}
	public struct LocalDate : IEquatable<LocalDate>, IComparable<LocalDate>, IComparable, IFormattable, IXmlSerializable
	{
		[ReadWriteForEfficiency]
		private YearMonthDayCalendar yearMonthDayCalendar;

		public static LocalDate MaxIsoValue => new LocalDate(new YearMonthDayCalendar(9999, 12, 31, CalendarOrdinal.Iso));

		public static LocalDate MinIsoValue => new LocalDate(new YearMonthDayCalendar(-9998, 1, 1, CalendarOrdinal.Iso));

		[NotNull]
		public CalendarSystem Calendar => CalendarSystem.ForOrdinal(yearMonthDayCalendar.CalendarOrdinal);

		public int Year => yearMonthDayCalendar.Year;

		public int Month => yearMonthDayCalendar.Month;

		public int Day => yearMonthDayCalendar.Day;

		internal int DaysSinceEpoch => Calendar.GetDaysSinceEpoch(yearMonthDayCalendar.ToYearMonthDay());

		public IsoDayOfWeek DayOfWeek => Calendar.GetDayOfWeek(yearMonthDayCalendar.ToYearMonthDay());

		public int YearOfEra => Calendar.GetYearOfEra(yearMonthDayCalendar.Year);

		[NotNull]
		public Era Era => Calendar.GetEra(yearMonthDayCalendar.Year);

		public int DayOfYear => Calendar.GetDayOfYear(yearMonthDayCalendar.ToYearMonthDay());

		internal YearMonthDay YearMonthDay => yearMonthDayCalendar.ToYearMonthDay();

		internal YearMonthDayCalendar YearMonthDayCalendar => yearMonthDayCalendar;

		internal LocalDate([Trusted] YearMonthDayCalendar yearMonthDayCalendar)
		{
			this.yearMonthDayCalendar = yearMonthDayCalendar;
		}

		internal LocalDate([Trusted] int daysSinceEpoch)
		{
			yearMonthDayCalendar = GregorianYearMonthDayCalculator.GetGregorianYearMonthDayCalendarFromDaysSinceEpoch(daysSinceEpoch);
		}

		internal LocalDate(int daysSinceEpoch, [Trusted][NotNull] CalendarSystem calendar)
		{
			yearMonthDayCalendar = calendar.GetYearMonthDayCalendarFromDaysSinceEpoch(daysSinceEpoch);
		}

		public LocalDate(int year, int month, int day)
		{
			GregorianYearMonthDayCalculator.ValidateGregorianYearMonthDay(year, month, day);
			yearMonthDayCalendar = new YearMonthDayCalendar(year, month, day, CalendarOrdinal.Iso);
		}

		public LocalDate(int year, int month, int day, [NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			calendar.ValidateYearMonthDay(year, month, day);
			yearMonthDayCalendar = new YearMonthDayCalendar(year, month, day, calendar.Ordinal);
		}

		public LocalDate([NotNull] Era era, int yearOfEra, int month, int day)
		{
			this = new LocalDate(era, yearOfEra, month, day, CalendarSystem.Iso);
		}

		public LocalDate([NotNull] Era era, int yearOfEra, int month, int day, [NotNull] CalendarSystem calendar)
		{
			this = new LocalDate(Preconditions.CheckNotNull(calendar, "calendar").GetAbsoluteYear(yearOfEra, era), month, day, calendar);
		}

		[Pure]
		public LocalDateTime AtMidnight()
		{
			return new LocalDateTime(this, LocalTime.Midnight);
		}

		[Pure]
		public DateTime ToDateTimeUnspecified()
		{
			return new DateTime(checked(DaysSinceEpoch * 864000000000L + NodaConstants.BclTicksAtUnixEpoch), DateTimeKind.Unspecified);
		}

		private static int NonNegativeTicksToDays(long ticks)
		{
			return (int)((ticks >> 14) / 52734375);
		}

		public static LocalDate FromDateTime(DateTime dateTime)
		{
			return new LocalDate(checked(NonNegativeTicksToDays(dateTime.Ticks) - NodaConstants.BclDaysAtUnixEpoch));
		}

		public static LocalDate FromDateTime(DateTime dateTime, [NotNull] CalendarSystem calendar)
		{
			return new LocalDate(checked(NonNegativeTicksToDays(dateTime.Ticks) - NodaConstants.BclDaysAtUnixEpoch), calendar);
		}

		public static LocalDate FromWeekYearWeekAndDay(int weekYear, int weekOfWeekYear, IsoDayOfWeek dayOfWeek)
		{
			return WeekYearRules.Iso.GetLocalDate(weekYear, weekOfWeekYear, dayOfWeek, CalendarSystem.Iso);
		}

		public static LocalDate FromYearMonthWeekAndDay(int year, int month, int occurrence, IsoDayOfWeek dayOfWeek)
		{
			LocalDate localDate = new LocalDate(year, month, 1);
			Preconditions.CheckArgumentRange("occurrence", occurrence, 1, 5);
			Preconditions.CheckArgumentRange("dayOfWeek", (int)dayOfWeek, 1, 7);
			checked
			{
				int num = dayOfWeek - localDate.DayOfWeek + 1;
				if (num <= 0)
				{
					num += 7;
				}
				int num2 = num + (occurrence - 1) * 7;
				if (num2 > CalendarSystem.Iso.GetDaysInMonth(year, month))
				{
					num2 -= 7;
				}
				return new LocalDate(year, month, num2);
			}
		}

		public static LocalDate operator +(LocalDate date, [NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			Preconditions.CheckArgument(!period.HasTimeComponent, "period", "Cannot add a period with a time component to a date");
			return period.AddTo(date, 1);
		}

		public static LocalDate Add(LocalDate date, [NotNull] Period period)
		{
			return date + period;
		}

		[Pure]
		public LocalDate Plus([NotNull] Period period)
		{
			return this + period;
		}

		public static LocalDateTime operator +(LocalDate date, LocalTime time)
		{
			return new LocalDateTime(date, time);
		}

		public static LocalDate operator -(LocalDate date, [NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			Preconditions.CheckArgument(!period.HasTimeComponent, "period", "Cannot subtract a period with a time component from a date");
			return period.AddTo(date, -1);
		}

		public static LocalDate Subtract(LocalDate date, [NotNull] Period period)
		{
			return date - period;
		}

		[Pure]
		public LocalDate Minus([NotNull] Period period)
		{
			return this - period;
		}

		[NotNull]
		public static Period operator -(LocalDate lhs, LocalDate rhs)
		{
			return Period.Between(rhs, lhs);
		}

		[NotNull]
		public static Period Subtract(LocalDate lhs, LocalDate rhs)
		{
			return lhs - rhs;
		}

		[Pure]
		[NotNull]
		public Period Minus(LocalDate date)
		{
			return this - date;
		}

		public static bool operator ==(LocalDate lhs, LocalDate rhs)
		{
			return lhs.yearMonthDayCalendar == rhs.yearMonthDayCalendar;
		}

		public static bool operator !=(LocalDate lhs, LocalDate rhs)
		{
			return !(lhs == rhs);
		}

		public static bool operator <(LocalDate lhs, LocalDate rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) < 0;
		}

		public static bool operator <=(LocalDate lhs, LocalDate rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) <= 0;
		}

		public static bool operator >(LocalDate lhs, LocalDate rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) > 0;
		}

		public static bool operator >=(LocalDate lhs, LocalDate rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) >= 0;
		}

		public int CompareTo(LocalDate other)
		{
			Preconditions.CheckArgument(Calendar.Equals(other.Calendar), "other", "Only values with the same calendar system can be compared");
			return Calendar.Compare(YearMonthDay, other.YearMonthDay);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is LocalDate, "obj", "Object must be of type NodaTime.LocalDate.");
			return CompareTo((LocalDate)obj);
		}

		public static LocalDate Max(LocalDate x, LocalDate y)
		{
			Preconditions.CheckArgument(x.Calendar.Equals(y.Calendar), "y", "Only values with the same calendar system can be compared");
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static LocalDate Min(LocalDate x, LocalDate y)
		{
			Preconditions.CheckArgument(x.Calendar.Equals(y.Calendar), "y", "Only values with the same calendar system can be compared");
			if (!(x < y))
			{
				return y;
			}
			return x;
		}

		public override int GetHashCode()
		{
			return yearMonthDayCalendar.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is LocalDate)
			{
				return this == (LocalDate)obj;
			}
			return false;
		}

		public bool Equals(LocalDate other)
		{
			return this == other;
		}

		[Pure]
		public ZonedDateTime AtStartOfDayInZone([NotNull] DateTimeZone zone)
		{
			Preconditions.CheckNotNull(zone, "zone");
			return zone.AtStartOfDay(this);
		}

		[Pure]
		public LocalDate WithCalendar([NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			return new LocalDate(DaysSinceEpoch, calendar);
		}

		[Pure]
		public LocalDate PlusYears(int years)
		{
			return DatePeriodFields.YearsField.Add(this, years);
		}

		[Pure]
		public LocalDate PlusMonths(int months)
		{
			return DatePeriodFields.MonthsField.Add(this, months);
		}

		[Pure]
		public LocalDate PlusDays(int days)
		{
			return DatePeriodFields.DaysField.Add(this, days);
		}

		[Pure]
		public LocalDate PlusWeeks(int weeks)
		{
			return DatePeriodFields.WeeksField.Add(this, weeks);
		}

		[Pure]
		public LocalDate Next(IsoDayOfWeek targetDayOfWeek)
		{
			if (targetDayOfWeek < IsoDayOfWeek.Monday || targetDayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("targetDayOfWeek");
			}
			IsoDayOfWeek dayOfWeek = DayOfWeek;
			checked
			{
				int num = targetDayOfWeek - dayOfWeek;
				if (num <= 0)
				{
					num += 7;
				}
				return PlusDays(num);
			}
		}

		[Pure]
		public LocalDate Previous(IsoDayOfWeek targetDayOfWeek)
		{
			if (targetDayOfWeek < IsoDayOfWeek.Monday || targetDayOfWeek > IsoDayOfWeek.Sunday)
			{
				throw new ArgumentOutOfRangeException("targetDayOfWeek");
			}
			IsoDayOfWeek dayOfWeek = DayOfWeek;
			checked
			{
				int num = targetDayOfWeek - dayOfWeek;
				if (num >= 0)
				{
					num -= 7;
				}
				return PlusDays(num);
			}
		}

		[Pure]
		public OffsetDate WithOffset(Offset offset)
		{
			return new OffsetDate(this, offset);
		}

		[Pure]
		public LocalDateTime At(LocalTime time)
		{
			return this + time;
		}

		[Pure]
		public LocalDate With([NotNull] Func<LocalDate, LocalDate> adjuster)
		{
			return Preconditions.CheckNotNull(adjuster, "adjuster")(this);
		}

		[Pure]
		public void Deconstruct(out int year, out int month, out int day)
		{
			year = Year;
			month = Month;
			day = Day;
		}

		[Pure]
		public void Deconstruct(out int year, out int month, out int day, [NotNull] out CalendarSystem calendar)
		{
			year = Year;
			month = Month;
			day = Day;
			calendar = Calendar;
		}

		public override string ToString()
		{
			return LocalDatePattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return LocalDatePattern.BclSupport.Format(this, patternText, formatProvider);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			LocalDatePattern localDatePattern = LocalDatePattern.Iso;
			if (reader.MoveToAttribute("calendar"))
			{
				CalendarSystem calendar = CalendarSystem.ForId(reader.Value);
				LocalDate newTemplateValue = localDatePattern.TemplateValue.WithCalendar(calendar);
				localDatePattern = localDatePattern.WithTemplateValue(newTemplateValue);
				reader.MoveToElement();
			}
			string text = reader.ReadElementContentAsString();
			this = localDatePattern.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			if (Calendar != CalendarSystem.Iso)
			{
				writer.WriteAttributeString("calendar", Calendar.Id);
			}
			writer.WriteString(LocalDatePattern.Iso.Format(this));
		}
	}
	public struct LocalDateTime : IEquatable<LocalDateTime>, IComparable<LocalDateTime>, IComparable, IFormattable, IXmlSerializable
	{
		[ReadWriteForEfficiency]
		private LocalDate date;

		[ReadWriteForEfficiency]
		private LocalTime time;

		[NotNull]
		public CalendarSystem Calendar => date.Calendar;

		public int Year => date.Year;

		public int YearOfEra => date.YearOfEra;

		[NotNull]
		public Era Era => date.Era;

		public int Month => date.Month;

		public int DayOfYear => date.DayOfYear;

		public int Day => date.Day;

		public IsoDayOfWeek DayOfWeek => date.DayOfWeek;

		public int Hour => time.Hour;

		public int ClockHourOfHalfDay => time.ClockHourOfHalfDay;

		public int Minute => time.Minute;

		public int Second => time.Second;

		public int Millisecond => time.Millisecond;

		public int TickOfSecond => time.TickOfSecond;

		public long TickOfDay => time.TickOfDay;

		public int NanosecondOfSecond => time.NanosecondOfSecond;

		public long NanosecondOfDay => time.NanosecondOfDay;

		public LocalTime TimeOfDay => time;

		public LocalDate Date => date;

		internal LocalDateTime([Trusted] LocalInstant localInstant)
		{
			date = new LocalDate(localInstant.DaysSinceEpoch);
			time = new LocalTime(localInstant.NanosecondOfDay);
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute)
		{
			this = new LocalDateTime(new LocalDate(year, month, day), new LocalTime(hour, minute));
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute, [NotNull] CalendarSystem calendar)
		{
			this = new LocalDateTime(new LocalDate(year, month, day, calendar), new LocalTime(hour, minute));
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute, int second)
		{
			this = new LocalDateTime(new LocalDate(year, month, day), new LocalTime(hour, minute, second));
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute, int second, [NotNull] CalendarSystem calendar)
		{
			this = new LocalDateTime(new LocalDate(year, month, day, calendar), new LocalTime(hour, minute, second));
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
		{
			this = new LocalDateTime(new LocalDate(year, month, day), new LocalTime(hour, minute, second, millisecond));
		}

		public LocalDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, [NotNull] CalendarSystem calendar)
		{
			this = new LocalDateTime(new LocalDate(year, month, day, calendar), new LocalTime(hour, minute, second, millisecond));
		}

		internal LocalDateTime(LocalDate date, LocalTime time)
		{
			this.date = date;
			this.time = time;
		}

		[Pure]
		public DateTime ToDateTimeUnspecified()
		{
			long num = checked(TickArithmetic.BoundedDaysAndTickOfDayToTicks(date.DaysSinceEpoch, time.TickOfDay) + NodaConstants.BclTicksAtUnixEpoch);
			if (num < 0)
			{
				throw new InvalidOperationException("LocalDateTime out of range of DateTime");
			}
			return new DateTime(num, DateTimeKind.Unspecified);
		}

		[Pure]
		internal LocalInstant ToLocalInstant()
		{
			return new LocalInstant(date.DaysSinceEpoch, time.NanosecondOfDay);
		}

		public static LocalDateTime FromDateTime(DateTime dateTime)
		{
			long tickOfDay;
			return new LocalDateTime(new LocalDate(checked(TickArithmetic.NonNegativeTicksToDaysAndTickOfDay(dateTime.Ticks, out tickOfDay) - NodaConstants.BclDaysAtUnixEpoch)), new LocalTime(tickOfDay * 100));
		}

		public static LocalDateTime FromDateTime(DateTime dateTime, [NotNull] CalendarSystem calendar)
		{
			long tickOfDay;
			return new LocalDateTime(new LocalDate(checked(TickArithmetic.NonNegativeTicksToDaysAndTickOfDay(dateTime.Ticks, out tickOfDay) - NodaConstants.BclDaysAtUnixEpoch), calendar), new LocalTime(tickOfDay * 100));
		}

		public bool Equals(LocalDateTime other)
		{
			if (date == other.date)
			{
				return time == other.time;
			}
			return false;
		}

		public static bool operator ==(LocalDateTime left, LocalDateTime right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(LocalDateTime left, LocalDateTime right)
		{
			return !(left == right);
		}

		public static bool operator <(LocalDateTime lhs, LocalDateTime rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) < 0;
		}

		public static bool operator <=(LocalDateTime lhs, LocalDateTime rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) <= 0;
		}

		public static bool operator >(LocalDateTime lhs, LocalDateTime rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) > 0;
		}

		public static bool operator >=(LocalDateTime lhs, LocalDateTime rhs)
		{
			Preconditions.CheckArgument(lhs.Calendar.Equals(rhs.Calendar), "rhs", "Only values in the same calendar can be compared");
			return lhs.CompareTo(rhs) >= 0;
		}

		public int CompareTo(LocalDateTime other)
		{
			int num = date.CompareTo(other.date);
			if (num != 0)
			{
				return num;
			}
			return time.CompareTo(other.time);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is LocalDateTime, "obj", "Object must be of type NodaTime.LocalDateTime.");
			return CompareTo((LocalDateTime)obj);
		}

		public static LocalDateTime operator +(LocalDateTime localDateTime, [NotNull] Period period)
		{
			return localDateTime.Plus(period);
		}

		public static LocalDateTime Add(LocalDateTime localDateTime, [NotNull] Period period)
		{
			return localDateTime.Plus(period);
		}

		[Pure]
		public LocalDateTime Plus([NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			return period.AddTo(date, time, 1);
		}

		public static LocalDateTime operator -(LocalDateTime localDateTime, [NotNull] Period period)
		{
			return localDateTime.Minus(period);
		}

		public static LocalDateTime Subtract(LocalDateTime localDateTime, [NotNull] Period period)
		{
			return localDateTime.Minus(period);
		}

		[Pure]
		public LocalDateTime Minus([NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			return period.AddTo(date, time, -1);
		}

		[NotNull]
		public static Period operator -(LocalDateTime lhs, LocalDateTime rhs)
		{
			return Period.Between(rhs, lhs);
		}

		[NotNull]
		public static Period Subtract(LocalDateTime lhs, LocalDateTime rhs)
		{
			return lhs - rhs;
		}

		[Pure]
		[NotNull]
		public Period Minus(LocalDateTime localDateTime)
		{
			return this - localDateTime;
		}

		public override bool Equals(object obj)
		{
			if (obj is LocalDateTime)
			{
				return Equals((LocalDateTime)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(date, time, Calendar);
		}

		[Pure]
		public LocalDateTime With([NotNull] Func<LocalDate, LocalDate> adjuster)
		{
			return date.With(adjuster) + time;
		}

		[Pure]
		public LocalDateTime With([NotNull] Func<LocalTime, LocalTime> adjuster)
		{
			return date + time.With(adjuster);
		}

		[Pure]
		public LocalDateTime WithCalendar([NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			return new LocalDateTime(date.WithCalendar(calendar), time);
		}

		[Pure]
		public LocalDateTime PlusYears(int years)
		{
			return new LocalDateTime(date.PlusYears(years), time);
		}

		[Pure]
		public LocalDateTime PlusMonths(int months)
		{
			return new LocalDateTime(date.PlusMonths(months), time);
		}

		[Pure]
		public LocalDateTime PlusDays(int days)
		{
			return new LocalDateTime(date.PlusDays(days), time);
		}

		[Pure]
		public LocalDateTime PlusWeeks(int weeks)
		{
			return new LocalDateTime(date.PlusWeeks(weeks), time);
		}

		[Pure]
		public LocalDateTime PlusHours(long hours)
		{
			return TimePeriodField.Hours.Add(this, hours);
		}

		[Pure]
		public LocalDateTime PlusMinutes(long minutes)
		{
			return TimePeriodField.Minutes.Add(this, minutes);
		}

		[Pure]
		public LocalDateTime PlusSeconds(long seconds)
		{
			return TimePeriodField.Seconds.Add(this, seconds);
		}

		[Pure]
		public LocalDateTime PlusMilliseconds(long milliseconds)
		{
			return TimePeriodField.Milliseconds.Add(this, milliseconds);
		}

		[Pure]
		public LocalDateTime PlusTicks(long ticks)
		{
			return TimePeriodField.Ticks.Add(this, ticks);
		}

		[Pure]
		public LocalDateTime PlusNanoseconds(long nanoseconds)
		{
			return TimePeriodField.Nanoseconds.Add(this, nanoseconds);
		}

		[Pure]
		public LocalDateTime Next(IsoDayOfWeek targetDayOfWeek)
		{
			return new LocalDateTime(date.Next(targetDayOfWeek), time);
		}

		[Pure]
		public LocalDateTime Previous(IsoDayOfWeek targetDayOfWeek)
		{
			return new LocalDateTime(date.Previous(targetDayOfWeek), time);
		}

		[Pure]
		public OffsetDateTime WithOffset(Offset offset)
		{
			return new OffsetDateTime(date.YearMonthDayCalendar, time, offset);
		}

		[Pure]
		public ZonedDateTime InUtc()
		{
			return new ZonedDateTime(new OffsetDateTime(date.YearMonthDayCalendar, time.NanosecondOfDay), DateTimeZone.Utc);
		}

		[Pure]
		public ZonedDateTime InZoneStrictly([NotNull] DateTimeZone zone)
		{
			Preconditions.CheckNotNull(zone, "zone");
			return zone.AtStrictly(this);
		}

		[Pure]
		public ZonedDateTime InZoneLeniently([NotNull] DateTimeZone zone)
		{
			Preconditions.CheckNotNull(zone, "zone");
			return zone.AtLeniently(this);
		}

		[Pure]
		public ZonedDateTime InZone([NotNull] DateTimeZone zone, [NotNull] ZoneLocalMappingResolver resolver)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(resolver, "resolver");
			return zone.ResolveLocal(this, resolver);
		}

		[Pure]
		public void Deconstruct(out LocalDate date, out LocalTime time)
		{
			date = Date;
			time = TimeOfDay;
		}

		public static LocalDateTime Max(LocalDateTime x, LocalDateTime y)
		{
			Preconditions.CheckArgument(x.Calendar.Equals(y.Calendar), "y", "Only values with the same calendar system can be compared");
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static LocalDateTime Min(LocalDateTime x, LocalDateTime y)
		{
			Preconditions.CheckArgument(x.Calendar.Equals(y.Calendar), "y", "Only values with the same calendar system can be compared");
			if (!(x < y))
			{
				return y;
			}
			return x;
		}

		public override string ToString()
		{
			return LocalDateTimePattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return LocalDateTimePattern.BclSupport.Format(this, patternText, formatProvider);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			LocalDateTimePattern localDateTimePattern = LocalDateTimePattern.ExtendedIso;
			if (reader.MoveToAttribute("calendar"))
			{
				CalendarSystem calendar = CalendarSystem.ForId(reader.Value);
				LocalDateTime newTemplateValue = localDateTimePattern.TemplateValue.WithCalendar(calendar);
				localDateTimePattern = localDateTimePattern.WithTemplateValue(newTemplateValue);
				reader.MoveToElement();
			}
			string text = reader.ReadElementContentAsString();
			this = localDateTimePattern.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			if (Calendar != CalendarSystem.Iso)
			{
				writer.WriteAttributeString("calendar", Calendar.Id);
			}
			writer.WriteString(LocalDateTimePattern.ExtendedIso.Format(this));
		}
	}
	internal struct LocalInstant : IEquatable<LocalInstant>
	{
		public static readonly LocalInstant BeforeMinValue;

		public static readonly LocalInstant AfterMaxValue;

		[ReadWriteForEfficiency]
		private Duration duration;

		internal bool IsValid
		{
			get
			{
				if (DaysSinceEpoch >= -4371222)
				{
					return DaysSinceEpoch <= 2932896;
				}
				return false;
			}
		}

		internal Duration TimeSinceLocalEpoch => duration;

		internal int DaysSinceEpoch => duration.FloorDays;

		internal long NanosecondOfDay => duration.NanosecondOfFloorDay;

		private LocalInstant([Trusted] int days, bool deliberatelyInvalid)
		{
			duration = new Duration(days, 0L);
		}

		internal LocalInstant(Duration nanoseconds)
		{
			int floorDays = nanoseconds.FloorDays;
			if (floorDays < -4371222 || floorDays > 2932896)
			{
				throw new OverflowException("Operation would overflow bounds of local date/time");
			}
			duration = nanoseconds;
		}

		internal LocalInstant([Trusted] int days, [Trusted] long nanoOfDay)
		{
			duration = new Duration(days, nanoOfDay);
		}

		internal Instant MinusZeroOffset()
		{
			return Instant.FromTrustedDuration(duration);
		}

		public Instant Minus(Offset offset)
		{
			return Instant.FromUntrustedDuration(duration.MinusSmallNanoseconds(offset.Nanoseconds));
		}

		public static bool operator ==(LocalInstant left, LocalInstant right)
		{
			return left.duration == right.duration;
		}

		internal Instant SafeMinus(Offset offset)
		{
			int floorDays = this.duration.FloorDays;
			if (floorDays > -4371222 && floorDays < 2932896)
			{
				return Minus(offset);
			}
			if (floorDays < -4371222)
			{
				return Instant.BeforeMinValue;
			}
			if (floorDays > 2932896)
			{
				return Instant.AfterMaxValue;
			}
			Duration duration = this.duration.MinusSmallNanoseconds(offset.Nanoseconds);
			if (duration.FloorDays < -4371222)
			{
				return Instant.BeforeMinValue;
			}
			if (duration.FloorDays > 2932896)
			{
				return Instant.AfterMaxValue;
			}
			return Instant.FromTrustedDuration(duration);
		}

		public static bool operator !=(LocalInstant left, LocalInstant right)
		{
			return !(left == right);
		}

		public static bool operator <(LocalInstant left, LocalInstant right)
		{
			return left.duration < right.duration;
		}

		public static bool operator <=(LocalInstant left, LocalInstant right)
		{
			return left.duration <= right.duration;
		}

		public static bool operator >(LocalInstant left, LocalInstant right)
		{
			return left.duration > right.duration;
		}

		public static bool operator >=(LocalInstant left, LocalInstant right)
		{
			return left.duration >= right.duration;
		}

		public override bool Equals(object obj)
		{
			if (obj is LocalInstant)
			{
				return Equals((LocalInstant)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return duration.GetHashCode();
		}

		public override string ToString()
		{
			if (this == BeforeMinValue)
			{
				return "StartOfTime";
			}
			if (this == AfterMaxValue)
			{
				return "EndOfTime";
			}
			LocalDate date = new LocalDate(duration.FloorDays);
			LocalDateTimePattern localDateTimePattern = LocalDateTimePattern.CreateWithInvariantCulture("uuuu-MM-ddTHH:mm:ss.FFFFFFFFF 'LOC'");
			LocalDateTime value = new LocalDateTime(date, LocalTime.FromNanosecondsSinceMidnight(duration.NanosecondOfFloorDay));
			return localDateTimePattern.Format(value);
		}

		public bool Equals(LocalInstant other)
		{
			return this == other;
		}

		static LocalInstant()
		{
			BeforeMinValue = new LocalInstant(Instant.BeforeMinValue.DaysSinceEpoch, deliberatelyInvalid: true);
			AfterMaxValue = new LocalInstant(Instant.AfterMaxValue.DaysSinceEpoch, deliberatelyInvalid: true);
		}
	}
	public struct LocalTime : IEquatable<LocalTime>, IComparable<LocalTime>, IFormattable, IComparable, IXmlSerializable
	{
		private readonly long nanoseconds;

		public static LocalTime Midnight { get; } = new LocalTime(0, 0, 0);

		public static LocalTime MinValue => Midnight;

		public static LocalTime Noon { get; } = new LocalTime(12, 0, 0);

		public static LocalTime MaxValue { get; } = new LocalTime(86399999999999L);

		public int Hour
		{
			get
			{
				checked
				{
					return (int)unchecked((nanoseconds >> 13) / 439453125);
				}
			}
		}

		public int ClockHourOfHalfDay
		{
			get
			{
				int hourOfHalfDay = HourOfHalfDay;
				if (hourOfHalfDay != 0)
				{
					return hourOfHalfDay;
				}
				return 12;
			}
		}

		internal int HourOfHalfDay => Hour % 12;

		public int Minute => (int)((nanoseconds >> 11) / 29296875) % 60;

		public int Second => (int)(nanoseconds / 1000000000) % 60;

		public int Millisecond => (int)(nanoseconds / 1000000 % 1000);

		public int TickOfSecond => (int)(TickOfDay % 10000000);

		public long TickOfDay => nanoseconds / 100;

		public int NanosecondOfSecond => (int)(nanoseconds % 1000000000);

		public long NanosecondOfDay => nanoseconds;

		public LocalTime(int hour, int minute)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
			}
			nanoseconds = hour * 3600000000000L + minute * 60000000000L;
		}

		public LocalTime(int hour, int minute, int second)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
				Preconditions.CheckArgumentRange("second", second, 0, 59);
			}
			nanoseconds = hour * 3600000000000L + minute * 60000000000L + (long)second * 1000000000L;
		}

		public LocalTime(int hour, int minute, int second, int millisecond)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59 || millisecond < 0 || millisecond > 999)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
				Preconditions.CheckArgumentRange("second", second, 0, 59);
				Preconditions.CheckArgumentRange("millisecond", millisecond, 0, 999);
			}
			nanoseconds = hour * 3600000000000L + minute * 60000000000L + (long)second * 1000000000L + (long)millisecond * 1000000L;
		}

		public static LocalTime FromHourMinuteSecondMillisecondTick(int hour, int minute, int second, int millisecond, int tickWithinMillisecond)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59 || millisecond < 0 || millisecond > 999 || tickWithinMillisecond < 0 || (long)tickWithinMillisecond > 9999L)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
				Preconditions.CheckArgumentRange("second", second, 0, 59);
				Preconditions.CheckArgumentRange("millisecond", millisecond, 0, 999);
				Preconditions.CheckArgumentRange("tickWithinMillisecond", tickWithinMillisecond, 0L, 9999L);
			}
			return new LocalTime(hour * 3600000000000L + minute * 60000000000L + (long)second * 1000000000L + (long)millisecond * 1000000L + (long)tickWithinMillisecond * 100L);
		}

		public static LocalTime FromHourMinuteSecondTick(int hour, int minute, int second, int tickWithinSecond)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59 || tickWithinSecond < 0 || (long)tickWithinSecond > 9999999L)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
				Preconditions.CheckArgumentRange("second", second, 0, 59);
				Preconditions.CheckArgumentRange("tickWithinSecond", tickWithinSecond, 0L, 9999999L);
			}
			return new LocalTime(hour * 3600000000000L + minute * 60000000000L + (long)second * 1000000000L + (long)tickWithinSecond * 100L);
		}

		public static LocalTime FromHourMinuteSecondNanosecond(int hour, int minute, int second, long nanosecondWithinSecond)
		{
			if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59 || nanosecondWithinSecond < 0 || nanosecondWithinSecond > 999999999)
			{
				Preconditions.CheckArgumentRange("hour", hour, 0, 23);
				Preconditions.CheckArgumentRange("minute", minute, 0, 59);
				Preconditions.CheckArgumentRange("second", second, 0, 59);
				Preconditions.CheckArgumentRange("nanosecondWithinSecond", nanosecondWithinSecond, 0L, 999999999L);
			}
			return new LocalTime(hour * 3600000000000L + minute * 60000000000L + (long)second * 1000000000L + nanosecondWithinSecond);
		}

		internal LocalTime([Trusted] long nanoseconds)
		{
			this.nanoseconds = nanoseconds;
		}

		internal static LocalTime FromNanosecondsSinceMidnight(long nanoseconds)
		{
			if (nanoseconds < 0 || nanoseconds > 86399999999999L)
			{
				Preconditions.CheckArgumentRange("nanoseconds", nanoseconds, 0L, 86399999999999L);
			}
			return new LocalTime(nanoseconds);
		}

		public static LocalTime FromTicksSinceMidnight(long ticks)
		{
			if (ticks < 0 || ticks > 863999999999L)
			{
				Preconditions.CheckArgumentRange("ticks", ticks, 0L, 863999999999L);
			}
			return new LocalTime(ticks * 100);
		}

		public static LocalTime FromMillisecondsSinceMidnight(int milliseconds)
		{
			if (milliseconds < 0 || milliseconds > 86399999)
			{
				Preconditions.CheckArgumentRange("milliseconds", milliseconds, 0, 86399999);
			}
			return new LocalTime((long)milliseconds * 1000000L);
		}

		public static LocalTime FromSecondsSinceMidnight(int seconds)
		{
			if (seconds < 0 || seconds > 86399)
			{
				Preconditions.CheckArgumentRange("seconds", seconds, 0, 86399);
			}
			return new LocalTime((long)seconds * 1000000000L);
		}

		public static LocalTime operator +(LocalTime time, [NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			Preconditions.CheckArgument(!period.HasDateComponent, "period", "Cannot add a period with a date component to a time");
			return period.AddTo(time, 1);
		}

		public static LocalTime Add(LocalTime time, [NotNull] Period period)
		{
			return time + period;
		}

		[Pure]
		public LocalTime Plus([NotNull] Period period)
		{
			return this + period;
		}

		public static LocalTime operator -(LocalTime time, [NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			Preconditions.CheckArgument(!period.HasDateComponent, "period", "Cannot subtract a period with a date component from a time");
			return period.AddTo(time, -1);
		}

		public static LocalTime Subtract(LocalTime time, [NotNull] Period period)
		{
			return time - period;
		}

		[Pure]
		public LocalTime Minus([NotNull] Period period)
		{
			return this - period;
		}

		[NotNull]
		public static Period operator -(LocalTime lhs, LocalTime rhs)
		{
			return Period.Between(rhs, lhs);
		}

		[NotNull]
		public static Period Subtract(LocalTime lhs, LocalTime rhs)
		{
			return lhs - rhs;
		}

		[Pure]
		[NotNull]
		public Period Minus(LocalTime time)
		{
			return this - time;
		}

		public static bool operator ==(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds == rhs.nanoseconds;
		}

		public static bool operator !=(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds != rhs.nanoseconds;
		}

		public static bool operator <(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds < rhs.nanoseconds;
		}

		public static bool operator <=(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds <= rhs.nanoseconds;
		}

		public static bool operator >(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds > rhs.nanoseconds;
		}

		public static bool operator >=(LocalTime lhs, LocalTime rhs)
		{
			return lhs.nanoseconds >= rhs.nanoseconds;
		}

		public int CompareTo(LocalTime other)
		{
			long num = nanoseconds;
			return num.CompareTo(other.nanoseconds);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is LocalTime, "obj", "Object must be of type NodaTime.LocalTime.");
			return CompareTo((LocalTime)obj);
		}

		public override int GetHashCode()
		{
			long num = nanoseconds;
			return num.GetHashCode();
		}

		public bool Equals(LocalTime other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			if (obj is LocalTime)
			{
				return this == (LocalTime)obj;
			}
			return false;
		}

		[Pure]
		public LocalTime PlusHours(long hours)
		{
			return TimePeriodField.Hours.Add(this, hours);
		}

		[Pure]
		public LocalTime PlusMinutes(long minutes)
		{
			return TimePeriodField.Minutes.Add(this, minutes);
		}

		[Pure]
		public LocalTime PlusSeconds(long seconds)
		{
			return TimePeriodField.Seconds.Add(this, seconds);
		}

		[Pure]
		public LocalTime PlusMilliseconds(long milliseconds)
		{
			return TimePeriodField.Milliseconds.Add(this, milliseconds);
		}

		[Pure]
		public LocalTime PlusTicks(long ticks)
		{
			return TimePeriodField.Ticks.Add(this, ticks);
		}

		[Pure]
		public LocalTime PlusNanoseconds(long nanoseconds)
		{
			return TimePeriodField.Nanoseconds.Add(this, nanoseconds);
		}

		[Pure]
		public LocalTime With([NotNull] Func<LocalTime, LocalTime> adjuster)
		{
			return Preconditions.CheckNotNull(adjuster, "adjuster")(this);
		}

		[Pure]
		public OffsetTime WithOffset(Offset offset)
		{
			return new OffsetTime(this, offset);
		}

		[Pure]
		public LocalDateTime On(LocalDate date)
		{
			return date + this;
		}

		[Pure]
		public void Deconstruct(out int hour, out int minute, out int second)
		{
			hour = Hour;
			minute = Minute;
			second = Second;
		}

		public static LocalTime Max(LocalTime x, LocalTime y)
		{
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static LocalTime Min(LocalTime x, LocalTime y)
		{
			if (!(x < y))
			{
				return y;
			}
			return x;
		}

		public override string ToString()
		{
			return LocalTimePattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return LocalTimePattern.BclSupport.Format(this, patternText, formatProvider);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			LocalTimePattern extendedIso = LocalTimePattern.ExtendedIso;
			string text = reader.ReadElementContentAsString();
			this = extendedIso.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteString(LocalTimePattern.ExtendedIso.Format(this));
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	public static class NodaConstants
	{
		public const long NanosecondsPerTick = 100L;

		public const long NanosecondsPerMillisecond = 1000000L;

		public const long NanosecondsPerSecond = 1000000000L;

		public const long NanosecondsPerMinute = 60000000000L;

		public const long NanosecondsPerHour = 3600000000000L;

		public const long NanosecondsPerDay = 86400000000000L;

		public const long NanosecondsPerWeek = 604800000000000L;

		public const long TicksPerMillisecond = 10000L;

		public const long TicksPerSecond = 10000000L;

		public const long TicksPerMinute = 600000000L;

		public const long TicksPerHour = 36000000000L;

		public const long TicksPerDay = 864000000000L;

		public const long TicksPerWeek = 6048000000000L;

		public const int MillisecondsPerSecond = 1000;

		public const int MillisecondsPerMinute = 60000;

		public const int MillisecondsPerHour = 3600000;

		public const int MillisecondsPerDay = 86400000;

		public const int MillisecondsPerWeek = 604800000;

		public const int SecondsPerMinute = 60;

		public const int SecondsPerHour = 3600;

		public const int SecondsPerDay = 86400;

		public const int SecondsPerWeek = 604800;

		public const int MinutesPerHour = 60;

		public const int MinutesPerDay = 1440;

		public const int MinutesPerWeek = 10080;

		public const int HoursPerDay = 24;

		public const int HoursPerWeek = 168;

		public const int DaysPerWeek = 7;

		internal static readonly long BclTicksAtUnixEpoch = 621355968000000000L;

		internal static readonly int BclDaysAtUnixEpoch = 719162;

		public static Instant UnixEpoch { get; } = Instant.FromUnixTimeTicks(0L);

		public static Instant BclEpoch { get; } = Instant.FromUtc(1, 1, 1, 0, 0);

		public static Instant JulianEpoch { get; } = Instant.FromUtc(-4713, 11, 24, 12, 0);
	}
	public struct Offset([Trusted] int seconds) : IEquatable<Offset>, IComparable<Offset>, IFormattable, IComparable, IXmlSerializable
	{
		public static readonly Offset Zero = FromSeconds(0);

		public static readonly Offset MinValue = FromHours(-18);

		public static readonly Offset MaxValue = FromHours(18);

		private const int MinHours = -18;

		private const int MaxHours = 18;

		internal const int MinSeconds = -64800;

		internal const int MaxSeconds = 64800;

		private const int MinMilliseconds = -64800000;

		private const int MaxMilliseconds = 64800000;

		private const long MinTicks = -648000000000L;

		private const long MaxTicks = 648000000000L;

		private const long MinNanoseconds = -64800000000000L;

		private const long MaxNanoseconds = 64800000000000L;

		private readonly int seconds = seconds;

		public int Seconds => seconds;

		public int Milliseconds => seconds * 1000;

		public long Ticks => (long)seconds * 10000000L;

		public long Nanoseconds => (long)seconds * 1000000000L;

		public static Offset Max(Offset x, Offset y)
		{
			if (!(x > y))
			{
				return y;
			}
			return x;
		}

		public static Offset Min(Offset x, Offset y)
		{
			if (!(x < y))
			{
				return y;
			}
			return x;
		}

		public static Offset operator -(Offset offset)
		{
			return new Offset(checked(-offset.Seconds));
		}

		public static Offset Negate(Offset offset)
		{
			return -offset;
		}

		public static Offset operator +(Offset offset)
		{
			return offset;
		}

		public static Offset operator +(Offset left, Offset right)
		{
			return FromSeconds(checked(left.Seconds + right.Seconds));
		}

		public static Offset Add(Offset left, Offset right)
		{
			return left + right;
		}

		[Pure]
		public Offset Plus(Offset other)
		{
			return this + other;
		}

		public static Offset operator -(Offset minuend, Offset subtrahend)
		{
			return FromSeconds(checked(minuend.Seconds - subtrahend.Seconds));
		}

		public static Offset Subtract(Offset minuend, Offset subtrahend)
		{
			return minuend - subtrahend;
		}

		[Pure]
		public Offset Minus(Offset other)
		{
			return this - other;
		}

		public static bool operator ==(Offset left, Offset right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Offset left, Offset right)
		{
			return !(left == right);
		}

		public static bool operator <(Offset left, Offset right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Offset left, Offset right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Offset left, Offset right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Offset left, Offset right)
		{
			return left.CompareTo(right) >= 0;
		}

		public int CompareTo(Offset other)
		{
			return Seconds.CompareTo(other.Seconds);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Preconditions.CheckArgument(obj is Offset, "obj", "Object must be of type NodaTime.Offset.");
			return CompareTo((Offset)obj);
		}

		public bool Equals(Offset other)
		{
			return Seconds == other.Seconds;
		}

		public override bool Equals(object obj)
		{
			if (obj is Offset)
			{
				return Equals((Offset)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Seconds.GetHashCode();
		}

		public override string ToString()
		{
			return OffsetPattern.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return OffsetPattern.BclSupport.Format(this, patternText, formatProvider);
		}

		public static Offset FromSeconds(int seconds)
		{
			Preconditions.CheckArgumentRange("seconds", seconds, -64800, 64800);
			return new Offset(seconds);
		}

		public static Offset FromMilliseconds(int milliseconds)
		{
			Preconditions.CheckArgumentRange("milliseconds", milliseconds, -64800000, 64800000);
			return new Offset(milliseconds / 1000);
		}

		public static Offset FromTicks(long ticks)
		{
			Preconditions.CheckArgumentRange("ticks", ticks, -648000000000L, 648000000000L);
			checked
			{
				return new Offset((int)unchecked(ticks / 10000000));
			}
		}

		public static Offset FromNanoseconds(long nanoseconds)
		{
			Preconditions.CheckArgumentRange("nanoseconds", nanoseconds, -64800000000000L, 64800000000000L);
			checked
			{
				return new Offset((int)unchecked(nanoseconds / 1000000000));
			}
		}

		public static Offset FromHours(int hours)
		{
			Preconditions.CheckArgumentRange("hours", hours, -18, 18);
			return new Offset(checked(hours * 3600));
		}

		public static Offset FromHoursAndMinutes(int hours, int minutes)
		{
			return FromSeconds(checked(hours * 3600 + minutes * 60));
		}

		[Pure]
		public TimeSpan ToTimeSpan()
		{
			return TimeSpan.FromSeconds(seconds);
		}

		public static Offset FromTimeSpan(TimeSpan timeSpan)
		{
			long ticks = timeSpan.Ticks;
			Preconditions.CheckArgumentRange("timeSpan", ticks, -648000000000L, 648000000000L);
			return FromTicks(ticks);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			OffsetPattern generalInvariant = OffsetPattern.GeneralInvariant;
			string text = reader.ReadElementContentAsString();
			this = generalInvariant.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteString(OffsetPattern.GeneralInvariant.Format(this));
		}
	}
	public struct OffsetDate(LocalDate date, Offset offset) : IEquatable<OffsetDate>, IXmlSerializable, IFormattable
	{
		[ReadWriteForEfficiency]
		private LocalDate date = date;

		[ReadWriteForEfficiency]
		private Offset offset = offset;

		public LocalDate Date => date;

		public Offset Offset => offset;

		[NotNull]
		public CalendarSystem Calendar => Date.Calendar;

		public int Year => Date.Year;

		public int Month => Date.Month;

		public int Day => Date.Day;

		public IsoDayOfWeek DayOfWeek => Date.DayOfWeek;

		public int YearOfEra => Date.YearOfEra;

		[NotNull]
		public Era Era => Date.Era;

		public int DayOfYear => Date.DayOfYear;

		[Pure]
		public OffsetDate WithOffset(Offset offset)
		{
			return new OffsetDate(date, offset);
		}

		[Pure]
		public OffsetDate With([NotNull] Func<LocalDate, LocalDate> adjuster)
		{
			return new OffsetDate(Date.With(adjuster), offset);
		}

		[Pure]
		public OffsetDate WithCalendar([NotNull] CalendarSystem calendar)
		{
			return new OffsetDate(Date.WithCalendar(calendar), offset);
		}

		[Pure]
		public OffsetDateTime At(LocalTime time)
		{
			return new OffsetDateTime(Date.At(time), Offset);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(Date, Offset);
		}

		public override bool Equals(object obj)
		{
			if (obj is OffsetDate other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(OffsetDate other)
		{
			if (Date == other.Date)
			{
				return Offset == other.Offset;
			}
			return false;
		}

		public static bool operator ==(OffsetDate left, OffsetDate right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(OffsetDate left, OffsetDate right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return OffsetDatePattern.Patterns.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return OffsetDatePattern.Patterns.BclSupport.Format(this, patternText, formatProvider);
		}

		[Pure]
		public void Deconstruct(out LocalDate localDate, out Offset offset)
		{
			localDate = Date;
			offset = Offset;
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			OffsetDatePattern offsetDatePattern = OffsetDatePattern.GeneralIso;
			if (reader.MoveToAttribute("calendar"))
			{
				CalendarSystem calendar = CalendarSystem.ForId(reader.Value);
				OffsetDate newTemplateValue = offsetDatePattern.TemplateValue.WithCalendar(calendar);
				offsetDatePattern = offsetDatePattern.WithTemplateValue(newTemplateValue);
				reader.MoveToElement();
			}
			string text = reader.ReadElementContentAsString();
			this = offsetDatePattern.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			if (Calendar != CalendarSystem.Iso)
			{
				writer.WriteAttributeString("calendar", Calendar.Id);
			}
			writer.WriteString(OffsetDatePattern.GeneralIso.Format(this));
		}
	}
	public struct OffsetDateTime : IEquatable<OffsetDateTime>, IFormattable, IXmlSerializable
	{
		[Immutable]
		public abstract class Comparer : IComparer<OffsetDateTime>, IEqualityComparer<OffsetDateTime>
		{
			[NotNull]
			public static Comparer Local => LocalComparer.Instance;

			[NotNull]
			public static Comparer Instant => InstantComparer.Instance;

			internal Comparer()
			{
			}

			public abstract int Compare(OffsetDateTime x, OffsetDateTime y);

			public abstract bool Equals(OffsetDateTime x, OffsetDateTime y);

			public abstract int GetHashCode(OffsetDateTime obj);
		}

		private sealed class LocalComparer : Comparer
		{
			internal static readonly Comparer Instance = new LocalComparer();

			private LocalComparer()
			{
			}

			public override int Compare(OffsetDateTime x, OffsetDateTime y)
			{
				Preconditions.CheckArgument(x.Calendar.Equals(y.Calendar), "y", "Only values with the same calendar system can be compared");
				int num = x.Calendar.Compare(x.YearMonthDay, y.YearMonthDay);
				if (num != 0)
				{
					return num;
				}
				return x.NanosecondOfDay.CompareTo(y.NanosecondOfDay);
			}

			public override bool Equals(OffsetDateTime x, OffsetDateTime y)
			{
				if (x.yearMonthDayCalendar == y.yearMonthDayCalendar)
				{
					return x.NanosecondOfDay == y.NanosecondOfDay;
				}
				return false;
			}

			public override int GetHashCode(OffsetDateTime obj)
			{
				return HashCodeHelper.Hash(obj.yearMonthDayCalendar, obj.NanosecondOfDay);
			}
		}

		private sealed class InstantComparer : Comparer
		{
			internal static readonly Comparer Instance = new InstantComparer();

			private InstantComparer()
			{
			}

			public override int Compare(OffsetDateTime x, OffsetDateTime y)
			{
				return x.ToElapsedTimeSinceEpoch().CompareTo(y.ToElapsedTimeSinceEpoch());
			}

			public override bool Equals(OffsetDateTime x, OffsetDateTime y)
			{
				return x.ToElapsedTimeSinceEpoch() == y.ToElapsedTimeSinceEpoch();
			}

			public override int GetHashCode(OffsetDateTime obj)
			{
				return obj.ToElapsedTimeSinceEpoch().GetHashCode();
			}
		}

		private const int NanosecondsBits = 47;

		private const long NanosecondsMask = 140737488355327L;

		private const long OffsetMask = -140737488355328L;

		private const int MinBclOffsetMinutes = -840;

		private const int MaxBclOffsetMinutes = 840;

		[ReadWriteForEfficiency]
		private YearMonthDayCalendar yearMonthDayCalendar;

		private readonly long nanosecondsAndOffset;

		[NotNull]
		public CalendarSystem Calendar => CalendarSystem.ForOrdinal(yearMonthDayCalendar.CalendarOrdinal);

		public int Year => yearMonthDayCalendar.Year;

		public int Month => yearMonthDayCalendar.Month;

		public int Day => yearMonthDayCalendar.Day;

		internal YearMonthDay YearMonthDay => yearMonthDayCalendar.ToYearMonthDay();

		public IsoDayOfWeek DayOfWeek => Calendar.GetDayOfWeek(yearMonthDayCalendar.ToYearMonthDay());

		public int YearOfEra => Calendar.GetYearOfEra(yearMonthDayCalendar.Year);

		[NotNull]
		public Era Era => Calendar.GetEra(yearMonthDayCalendar.Year);

		public int DayOfYear => Calendar.GetDayOfYear(yearMonthDayCalendar.ToYearMonthDay());

		public int Hour
		{
			get
			{
				checked
				{
					return (int)unchecked((NanosecondOfDay >> 13) / 439453125);
				}
			}
		}

		public int ClockHourOfHalfDay
		{
			get
			{
				int hourOfHalfDay = HourOfHalfDay;
				if (hourOfHalfDay != 0)
				{
					return hourOfHalfDay;
				}
				return 12;
			}
		}

		internal int HourOfHalfDay => Hour % 12;

		public int Minute => (int)((NanosecondOfDay >> 11) / 29296875) % 60;

		public int Second => (int)(NanosecondOfDay / 1000000000) % 60;

		public int Millisecond => (int)(NanosecondOfDay / 1000000 % 1000);

		public int TickOfSecond => (int)(TickOfDay % 10000000);

		public long TickOfDay => NanosecondOfDay / 100;

		public int NanosecondOfSecond => (int)(NanosecondOfDay % 1000000000);

		public long NanosecondOfDay => nanosecondsAndOffset & 0x7FFFFFFFFFFFL;

		public LocalDateTime LocalDateTime => new LocalDateTime(Date, TimeOfDay);

		public LocalDate Date => new LocalDate(yearMonthDayCalendar);

		public LocalTime TimeOfDay => new LocalTime(NanosecondOfDay);

		public Offset Offset => new Offset(checked((int)(nanosecondsAndOffset >> 47)));

		private long OffsetNanoseconds => checked((nanosecondsAndOffset >> 47) * 1000000000);

		internal OffsetDateTime([Trusted] YearMonthDayCalendar yearMonthDayCalendar, [Trusted] long nanosecondsAndOffset)
		{
			this.yearMonthDayCalendar = yearMonthDayCalendar;
			this.nanosecondsAndOffset = nanosecondsAndOffset;
		}

		internal OffsetDateTime([Trusted] YearMonthDayCalendar yearMonthDayCalendar, LocalTime time, Offset offset)
		{
			this.yearMonthDayCalendar = yearMonthDayCalendar;
			nanosecondsAndOffset = CombineNanoOfDayAndOffset(time.NanosecondOfDay, offset);
		}

		internal OffsetDateTime(Instant instant, Offset offset)
		{
			int num = instant.DaysSinceEpoch;
			long num2 = instant.NanosecondOfDay + offset.Nanoseconds;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
			}
			else if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
			}
			yearMonthDayCalendar = GregorianYearMonthDayCalculator.GetGregorianYearMonthDayCalendarFromDaysSinceEpoch(num);
			nanosecondsAndOffset = CombineNanoOfDayAndOffset(num2, offset);
		}

		internal OffsetDateTime(Instant instant, Offset offset, CalendarSystem calendar)
		{
			int num = instant.DaysSinceEpoch;
			long num2 = instant.NanosecondOfDay + offset.Nanoseconds;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
			}
			else if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
			}
			yearMonthDayCalendar = calendar.GetYearMonthDayCalendarFromDaysSinceEpoch(num);
			nanosecondsAndOffset = CombineNanoOfDayAndOffset(num2, offset);
		}

		public OffsetDateTime(LocalDateTime localDateTime, Offset offset)
		{
			this = new OffsetDateTime(localDateTime.Date.YearMonthDayCalendar, CombineNanoOfDayAndOffset(localDateTime.NanosecondOfDay, offset));
		}

		private static long CombineNanoOfDayAndOffset(long nanoOfDay, Offset offset)
		{
			return nanoOfDay | ((long)offset.Seconds << 47);
		}

		[Pure]
		public Instant ToInstant()
		{
			return Instant.FromUntrustedDuration(ToElapsedTimeSinceEpoch());
		}

		private Duration ToElapsedTimeSinceEpoch()
		{
			return new Duration(Calendar.GetDaysSinceEpoch(yearMonthDayCalendar.ToYearMonthDay()), NanosecondOfDay).MinusSmallNanoseconds(OffsetNanoseconds);
		}

		[Pure]
		public ZonedDateTime InFixedZone()
		{
			return new ZonedDateTime(this, DateTimeZone.ForOffset(Offset));
		}

		[Pure]
		public ZonedDateTime InZone([NotNull] DateTimeZone zone)
		{
			Preconditions.CheckNotNull(zone, "zone");
			return ToInstant().InZone(zone);
		}

		[Pure]
		public DateTimeOffset ToDateTimeOffset()
		{
			int num = Offset.Seconds / 60;
			if (num < -840 || num > 840)
			{
				throw new InvalidOperationException("Offset out of range for DateTimeOffset");
			}
			return new DateTimeOffset(LocalDateTime.ToDateTimeUnspecified(), TimeSpan.FromMinutes(num));
		}

		[Pure]
		public static OffsetDateTime FromDateTimeOffset(DateTimeOffset dateTimeOffset)
		{
			return new OffsetDateTime(LocalDateTime.FromDateTime(dateTimeOffset.DateTime), Offset.FromTimeSpan(dateTimeOffset.Offset));
		}

		[Pure]
		public OffsetDateTime WithCalendar([NotNull] CalendarSystem calendar)
		{
			return new OffsetDateTime(Date.WithCalendar(calendar).YearMonthDayCalendar, nanosecondsAndOffset);
		}

		[Pure]
		public OffsetDateTime With([NotNull] Func<LocalDate, LocalDate> adjuster)
		{
			return new OffsetDateTime(Date.With(adjuster).YearMonthDayCalendar, nanosecondsAndOffset);
		}

		[Pure]
		public OffsetDateTime With([NotNull] Func<LocalTime, LocalTime> adjuster)
		{
			LocalTime localTime = TimeOfDay.With(adjuster);
			return new OffsetDateTime(yearMonthDayCalendar, (nanosecondsAndOffset & -140737488355328L) | localTime.NanosecondOfDay);
		}

		[Pure]
		public OffsetDateTime WithOffset(Offset offset)
		{
			int num = 0;
			long num2 = (nanosecondsAndOffset & 0x7FFFFFFFFFFFL) + offset.Nanoseconds - OffsetNanoseconds;
			if (num2 >= 86400000000000L)
			{
				num++;
				num2 -= 86400000000000L;
				if (num2 >= 86400000000000L)
				{
					num++;
					num2 -= 86400000000000L;
				}
			}
			else if (num2 < 0)
			{
				num--;
				num2 += 86400000000000L;
				if (num2 < 0)
				{
					num--;
					num2 += 86400000000000L;
				}
			}
			return new OffsetDateTime((num == 0) ? yearMonthDayCalendar : Date.PlusDays(num).YearMonthDayCalendar, CombineNanoOfDayAndOffset(num2, offset));
		}

		[Pure]
		public OffsetDate ToOffsetDate()
		{
			return new OffsetDate(Date, Offset);
		}

		[Pure]
		public OffsetTime ToOffsetTime()
		{
			return new OffsetTime(TimeOfDay, Offset);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(LocalDateTime, Offset);
		}

		public override bool Equals(object obj)
		{
			if (obj is OffsetDateTime)
			{
				return this == (OffsetDateTime)obj;
			}
			return false;
		}

		public bool Equals(OffsetDateTime other)
		{
			if (yearMonthDayCalendar == other.yearMonthDayCalendar)
			{
				return nanosecondsAndOffset == other.nanosecondsAndOffset;
			}
			return false;
		}

		[Pure]
		public void Deconstruct(out LocalDateTime localDateTime, out Offset offset)
		{
			localDateTime = LocalDateTime;
			offset = Offset;
		}

		[Pure]
		public void Deconstruct(out LocalDate localDate, out LocalTime localTime, out Offset offset)
		{
			localDate = LocalDateTime.Date;
			localTime = LocalDateTime.TimeOfDay;
			offset = Offset;
		}

		public override string ToString()
		{
			return OffsetDateTimePattern.Patterns.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return OffsetDateTimePattern.Patterns.BclSupport.Format(this, patternText, formatProvider);
		}

		public static OffsetDateTime Add(OffsetDateTime offsetDateTime, Duration duration)
		{
			return offsetDateTime + duration;
		}

		[Pure]
		public OffsetDateTime Plus(Duration duration)
		{
			return this + duration;
		}

		[Pure]
		public OffsetDateTime PlusHours(int hours)
		{
			return this + Duration.FromHours(hours);
		}

		[Pure]
		public OffsetDateTime PlusMinutes(int minutes)
		{
			return this + Duration.FromMinutes(minutes);
		}

		[Pure]
		public OffsetDateTime PlusSeconds(long seconds)
		{
			return this + Duration.FromSeconds(seconds);
		}

		[Pure]
		public OffsetDateTime PlusMilliseconds(long milliseconds)
		{
			return this + Duration.FromMilliseconds(milliseconds);
		}

		[Pure]
		public OffsetDateTime PlusTicks(long ticks)
		{
			return this + Duration.FromTicks(ticks);
		}

		[Pure]
		public OffsetDateTime PlusNanoseconds(long nanoseconds)
		{
			return this + Duration.FromNanoseconds(nanoseconds);
		}

		public static OffsetDateTime operator +(OffsetDateTime offsetDateTime, Duration duration)
		{
			return new OffsetDateTime(offsetDateTime.ToInstant() + duration, offsetDateTime.Offset);
		}

		public static OffsetDateTime Subtract(OffsetDateTime offsetDateTime, Duration duration)
		{
			return offsetDateTime - duration;
		}

		[Pure]
		public OffsetDateTime Minus(Duration duration)
		{
			return this - duration;
		}

		public static OffsetDateTime operator -(OffsetDateTime offsetDateTime, Duration duration)
		{
			return new OffsetDateTime(offsetDateTime.ToInstant() - duration, offsetDateTime.Offset);
		}

		public static Duration Subtract(OffsetDateTime end, OffsetDateTime start)
		{
			return end - start;
		}

		[Pure]
		public Duration Minus(OffsetDateTime other)
		{
			return this - other;
		}

		public static Duration operator -(OffsetDateTime end, OffsetDateTime start)
		{
			return end.ToInstant() - start.ToInstant();
		}

		public static bool operator ==(OffsetDateTime left, OffsetDateTime right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(OffsetDateTime left, OffsetDateTime right)
		{
			return !(left == right);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			OffsetDateTimePattern offsetDateTimePattern = OffsetDateTimePattern.Rfc3339;
			if (reader.MoveToAttribute("calendar"))
			{
				CalendarSystem calendar = CalendarSystem.ForId(reader.Value);
				OffsetDateTime newTemplateValue = offsetDateTimePattern.TemplateValue.WithCalendar(calendar);
				offsetDateTimePattern = offsetDateTimePattern.WithTemplateValue(newTemplateValue);
				reader.MoveToElement();
			}
			string text = reader.ReadElementContentAsString();
			this = offsetDateTimePattern.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			if (Calendar != CalendarSystem.Iso)
			{
				writer.WriteAttributeString("calendar", Calendar.Id);
			}
			writer.WriteString(OffsetDateTimePattern.Rfc3339.Format(this));
		}
	}
	public struct OffsetTime(LocalTime time, Offset offset) : IEquatable<OffsetTime>, IXmlSerializable, IFormattable
	{
		[ReadWriteForEfficiency]
		private LocalTime time = time;

		[ReadWriteForEfficiency]
		private Offset offset = offset;

		public LocalTime TimeOfDay => time;

		public Offset Offset => offset;

		public int Hour => time.Hour;

		public int ClockHourOfHalfDay => time.ClockHourOfHalfDay;

		internal int HourOfHalfDay => time.HourOfHalfDay;

		public int Minute => time.Minute;

		public int Second => time.Second;

		public int Millisecond => time.Millisecond;

		public int TickOfSecond => time.TickOfSecond;

		public long TickOfDay => time.TickOfDay;

		public int NanosecondOfSecond => time.NanosecondOfSecond;

		public long NanosecondOfDay => time.NanosecondOfDay;

		[Pure]
		public OffsetTime WithOffset(Offset offset)
		{
			return new OffsetTime(time, offset);
		}

		[Pure]
		public OffsetTime With([NotNull] Func<LocalTime, LocalTime> adjuster)
		{
			return new OffsetTime(TimeOfDay.With(adjuster), offset);
		}

		[Pure]
		public OffsetDateTime On(LocalDate date)
		{
			return new OffsetDateTime(date.At(time), Offset);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(TimeOfDay, Offset);
		}

		public override bool Equals(object obj)
		{
			if (obj is OffsetTime other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(OffsetTime other)
		{
			if (TimeOfDay == other.TimeOfDay)
			{
				return Offset == other.Offset;
			}
			return false;
		}

		public static bool operator ==(OffsetTime left, OffsetTime right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(OffsetTime left, OffsetTime right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return OffsetTimePattern.Patterns.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return OffsetTimePattern.Patterns.BclSupport.Format(this, patternText, formatProvider);
		}

		[Pure]
		public void Deconstruct(out LocalTime localTime, out Offset offset)
		{
			localTime = TimeOfDay;
			offset = Offset;
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			string text = reader.ReadElementContentAsString();
			this = OffsetTimePattern.ExtendedIso.Parse(text).Value;
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteString(OffsetTimePattern.ExtendedIso.Format(this));
		}
	}
	[Immutable]
	public sealed class Period : IEquatable<Period>
	{
		private sealed class NormalizingPeriodEqualityComparer : EqualityComparer<Period>
		{
			internal static readonly NormalizingPeriodEqualityComparer Instance = new NormalizingPeriodEqualityComparer();

			private NormalizingPeriodEqualityComparer()
			{
			}

			public override bool Equals(Period x, Period y)
			{
				if (x == y)
				{
					return true;
				}
				if (x == null || y == null)
				{
					return false;
				}
				return x.Normalize().Equals(y.Normalize());
			}

			public override int GetHashCode([NotNull] Period obj)
			{
				return Preconditions.CheckNotNull(obj, "obj").Normalize().GetHashCode();
			}
		}

		private sealed class PeriodComparer : Comparer<Period>
		{
			private readonly LocalDateTime baseDateTime;

			internal PeriodComparer(LocalDateTime baseDateTime)
			{
				this.baseDateTime = baseDateTime;
			}

			public override int Compare(Period x, Period y)
			{
				if (x == y)
				{
					return 0;
				}
				if (x == null)
				{
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				if (x.Months == 0 && y.Months == 0 && x.Years == 0 && y.Years == 0)
				{
					return x.ToDuration().CompareTo(y.ToDuration());
				}
				return (baseDateTime + x).CompareTo(baseDateTime + y);
			}
		}

		[NotNull]
		public static Period Zero { get; } = new Period(0, 0, 0, 0);

		[NotNull]
		public static IEqualityComparer<Period> NormalizingEqualityComparer => NormalizingPeriodEqualityComparer.Instance;

		public long Nanoseconds { get; }

		public long Ticks { get; }

		public long Milliseconds { get; }

		public long Seconds { get; }

		public long Minutes { get; }

		public long Hours { get; }

		public int Days { get; }

		public int Weeks { get; }

		public int Months { get; }

		public int Years { get; }

		public bool HasTimeComponent
		{
			get
			{
				if (Hours == 0L && Minutes == 0L && Seconds == 0L && Milliseconds == 0L && Ticks == 0L)
				{
					return Nanoseconds != 0;
				}
				return true;
			}
		}

		public bool HasDateComponent
		{
			get
			{
				if (Years == 0 && Months == 0 && Weeks == 0)
				{
					return Days != 0;
				}
				return true;
			}
		}

		private long TotalNanoseconds => checked(Nanoseconds + Ticks * 100 + Milliseconds * 1000000 + Seconds * 1000000000 + Minutes * 60000000000L + Hours * 3600000000000L + Days * 86400000000000L + Weeks * 604800000000000L);

		private Period(int years, int months, int weeks, int days)
		{
			Years = years;
			Months = months;
			Weeks = weeks;
			Days = days;
		}

		private Period(long hours, long minutes, long seconds, long milliseconds, long ticks, long nanoseconds)
		{
			Hours = hours;
			Minutes = minutes;
			Seconds = seconds;
			Milliseconds = milliseconds;
			Ticks = ticks;
			Nanoseconds = nanoseconds;
		}

		internal Period(int years, int months, int weeks, int days, long hours, long minutes, long seconds, long milliseconds, long ticks, long nanoseconds)
		{
			Years = years;
			Months = months;
			Weeks = weeks;
			Days = days;
			Hours = hours;
			Minutes = minutes;
			Seconds = seconds;
			Milliseconds = milliseconds;
			Ticks = ticks;
			Nanoseconds = nanoseconds;
		}

		[NotNull]
		public static Period FromYears(int years)
		{
			return new Period(years, 0, 0, 0);
		}

		[NotNull]
		public static Period FromMonths(int months)
		{
			return new Period(0, months, 0, 0);
		}

		[NotNull]
		public static Period FromWeeks(int weeks)
		{
			return new Period(0, 0, weeks, 0);
		}

		[NotNull]
		public static Period FromDays(int days)
		{
			return new Period(0, 0, 0, days);
		}

		[NotNull]
		public static Period FromHours(long hours)
		{
			return new Period(hours, 0L, 0L, 0L, 0L, 0L);
		}

		[NotNull]
		public static Period FromMinutes(long minutes)
		{
			return new Period(0L, minutes, 0L, 0L, 0L, 0L);
		}

		[NotNull]
		public static Period FromSeconds(long seconds)
		{
			return new Period(0L, 0L, seconds, 0L, 0L, 0L);
		}

		[NotNull]
		public static Period FromMilliseconds(long milliseconds)
		{
			return new Period(0L, 0L, 0L, milliseconds, 0L, 0L);
		}

		[NotNull]
		public static Period FromTicks(long ticks)
		{
			return new Period(0L, 0L, 0L, 0L, ticks, 0L);
		}

		[NotNull]
		public static Period FromNanoseconds(long nanoseconds)
		{
			return new Period(0L, 0L, 0L, 0L, 0L, nanoseconds);
		}

		[NotNull]
		public static Period operator +([NotNull] Period left, [NotNull] Period right)
		{
			Preconditions.CheckNotNull(left, "left");
			Preconditions.CheckNotNull(right, "right");
			return checked(new Period(left.Years + right.Years, left.Months + right.Months, left.Weeks + right.Weeks, left.Days + right.Days, left.Hours + right.Hours, left.Minutes + right.Minutes, left.Seconds + right.Seconds, left.Milliseconds + right.Milliseconds, left.Ticks + right.Ticks, left.Nanoseconds + right.Nanoseconds));
		}

		[NotNull]
		public static IComparer<Period> CreateComparer(LocalDateTime baseDateTime)
		{
			return new PeriodComparer(baseDateTime);
		}

		[NotNull]
		public static Period operator -([NotNull] Period minuend, [NotNull] Period subtrahend)
		{
			Preconditions.CheckNotNull(minuend, "minuend");
			Preconditions.CheckNotNull(subtrahend, "subtrahend");
			return checked(new Period(minuend.Years - subtrahend.Years, minuend.Months - subtrahend.Months, minuend.Weeks - subtrahend.Weeks, minuend.Days - subtrahend.Days, minuend.Hours - subtrahend.Hours, minuend.Minutes - subtrahend.Minutes, minuend.Seconds - subtrahend.Seconds, minuend.Milliseconds - subtrahend.Milliseconds, minuend.Ticks - subtrahend.Ticks, minuend.Nanoseconds - subtrahend.Nanoseconds));
		}

		[NotNull]
		public static Period Between(LocalDateTime start, LocalDateTime end, PeriodUnits units)
		{
			Preconditions.CheckArgument(units != PeriodUnits.None, "units", "Units must not be empty");
			Preconditions.CheckArgument((units & ~PeriodUnits.AllUnits) == 0, "units", "Units contains an unknown value: {0}", units);
			Preconditions.CheckArgument(start.Calendar.Equals(end.Calendar), "end", "start and end must use the same calendar system");
			if (start == end)
			{
				return Zero;
			}
			LocalDate end2 = end.Date;
			if (start < end)
			{
				if (start.TimeOfDay > end.TimeOfDay)
				{
					end2 = end2.PlusDays(-1);
				}
			}
			else if (start > end && start.TimeOfDay < end.TimeOfDay)
			{
				end2 = end2.PlusDays(1);
			}
			Duration duration;
			switch (units)
			{
			case PeriodUnits.Years:
				return FromYears(DatePeriodFields.YearsField.UnitsBetween(start.Date, end2));
			case PeriodUnits.Months:
				return FromMonths(DatePeriodFields.MonthsField.UnitsBetween(start.Date, end2));
			case PeriodUnits.Weeks:
				return FromWeeks(DatePeriodFields.WeeksField.UnitsBetween(start.Date, end2));
			case PeriodUnits.Days:
				return FromDays(DaysBetween(start.Date, end2));
			case PeriodUnits.Hours:
				return FromHours(TimePeriodField.Hours.UnitsBetween(start, end));
			case PeriodUnits.Minutes:
				return FromMinutes(TimePeriodField.Minutes.UnitsBetween(start, end));
			case PeriodUnits.Seconds:
				return FromSeconds(TimePeriodField.Seconds.UnitsBetween(start, end));
			case PeriodUnits.Milliseconds:
				return FromMilliseconds(TimePeriodField.Milliseconds.UnitsBetween(start, end));
			case PeriodUnits.Ticks:
				return FromTicks(TimePeriodField.Ticks.UnitsBetween(start, end));
			case PeriodUnits.Nanoseconds:
				return FromNanoseconds(TimePeriodField.Nanoseconds.UnitsBetween(start, end));
			default:
			{
				LocalDateTime localDateTime = start;
				int years = 0;
				int months = 0;
				int weeks = 0;
				int days = 0;
				if ((units & PeriodUnits.AllDateUnits) != PeriodUnits.None)
				{
					LocalDate date = DateComponentsBetween(start.Date, end2, units, out years, out months, out weeks, out days);
					localDateTime = new LocalDateTime(date, start.TimeOfDay);
				}
				if ((units & PeriodUnits.AllTimeUnits) == 0)
				{
					return new Period(years, months, weeks, days);
				}
				duration = end.ToLocalInstant().TimeSinceLocalEpoch - localDateTime.ToLocalInstant().TimeSinceLocalEpoch;
				long hours;
				long minutes;
				long seconds;
				long milliseconds;
				long ticks;
				long nanoseconds;
				if (duration.IsInt64Representable)
				{
					TimeComponentsBetween(duration.ToInt64Nanoseconds(), units, out hours, out minutes, out seconds, out milliseconds, out ticks, out nanoseconds);
				}
				else
				{
					hours = UnitsBetween(PeriodUnits.Hours, TimePeriodField.Hours);
					minutes = UnitsBetween(PeriodUnits.Minutes, TimePeriodField.Minutes);
					seconds = UnitsBetween(PeriodUnits.Seconds, TimePeriodField.Seconds);
					milliseconds = UnitsBetween(PeriodUnits.Milliseconds, TimePeriodField.Milliseconds);
					ticks = UnitsBetween(PeriodUnits.Ticks, TimePeriodField.Ticks);
					nanoseconds = UnitsBetween(PeriodUnits.Ticks, TimePeriodField.Nanoseconds);
				}
				return new Period(years, months, weeks, days, hours, minutes, seconds, milliseconds, ticks, nanoseconds);
			}
			}
			long UnitsBetween(PeriodUnits mask, TimePeriodField timeField)
			{
				if ((mask & units) == 0)
				{
					return 0L;
				}
				long unitsInDuration = timeField.GetUnitsInDuration(duration);
				duration -= timeField.ToDuration(unitsInDuration);
				return unitsInDuration;
			}
		}

		private static LocalDate DateComponentsBetween(LocalDate start, LocalDate end, PeriodUnits units, out int years, out int months, out int weeks, out int days)
		{
			LocalDate startDate = start;
			years = UnitsBetween(units & PeriodUnits.Years, ref startDate, end, DatePeriodFields.YearsField);
			months = UnitsBetween(units & PeriodUnits.Months, ref startDate, end, DatePeriodFields.MonthsField);
			weeks = UnitsBetween(units & PeriodUnits.Weeks, ref startDate, end, DatePeriodFields.WeeksField);
			days = UnitsBetween(units & PeriodUnits.Days, ref startDate, end, DatePeriodFields.DaysField);
			return startDate;
			static int UnitsBetween(PeriodUnits maskedUnits, ref LocalDate reference, LocalDate endDate, IDatePeriodField dateField)
			{
				if (maskedUnits == PeriodUnits.None)
				{
					return 0;
				}
				int num = dateField.UnitsBetween(reference, endDate);
				reference = dateField.Add(reference, num);
				return num;
			}
		}

		private static void TimeComponentsBetween(long totalNanoseconds, PeriodUnits units, out long hours, out long minutes, out long seconds, out long milliseconds, out long ticks, out long nanoseconds)
		{
			hours = UnitsBetween(PeriodUnits.Hours, 3600000000000L);
			minutes = UnitsBetween(PeriodUnits.Minutes, 60000000000L);
			seconds = UnitsBetween(PeriodUnits.Seconds, 1000000000L);
			milliseconds = UnitsBetween(PeriodUnits.Milliseconds, 1000000L);
			ticks = UnitsBetween(PeriodUnits.Ticks, 100L);
			nanoseconds = UnitsBetween(PeriodUnits.Nanoseconds, 1L);
			long UnitsBetween(PeriodUnits mask, long nanosecondsPerUnit)
			{
				if ((mask & units) == 0)
				{
					return 0L;
				}
				long num = totalNanoseconds / nanosecondsPerUnit;
				totalNanoseconds -= num * nanosecondsPerUnit;
				return num;
			}
		}

		[Pure]
		internal LocalTime AddTo(LocalTime time, int scalar)
		{
			return checked(time.PlusHours(Hours * scalar).PlusMinutes(Minutes * scalar).PlusSeconds(Seconds * scalar)
				.PlusMilliseconds(Milliseconds * scalar)
				.PlusTicks(Ticks * scalar)
				.PlusNanoseconds(Nanoseconds * scalar));
		}

		[Pure]
		internal LocalDate AddTo(LocalDate date, int scalar)
		{
			return checked(date.PlusYears(Years * scalar).PlusMonths(Months * scalar).PlusWeeks(Weeks * scalar)
				.PlusDays(Days * scalar));
		}

		internal LocalDateTime AddTo(LocalDate date, LocalTime time, int scalar)
		{
			date = AddTo(date, scalar);
			int extraDays = 0;
			checked
			{
				time = TimePeriodField.Hours.Add(time, Hours * scalar, ref extraDays);
				time = TimePeriodField.Minutes.Add(time, Minutes * scalar, ref extraDays);
				time = TimePeriodField.Seconds.Add(time, Seconds * scalar, ref extraDays);
				time = TimePeriodField.Milliseconds.Add(time, Milliseconds * scalar, ref extraDays);
				time = TimePeriodField.Ticks.Add(time, Ticks * scalar, ref extraDays);
				time = TimePeriodField.Nanoseconds.Add(time, Nanoseconds * scalar, ref extraDays);
				return new LocalDateTime(date.PlusDays(extraDays), time);
			}
		}

		[Pure]
		[NotNull]
		public static Period Between(LocalDateTime start, LocalDateTime end)
		{
			return Between(start, end, PeriodUnits.DateAndTime);
		}

		[Pure]
		[NotNull]
		public static Period Between(LocalDate start, LocalDate end, PeriodUnits units)
		{
			Preconditions.CheckArgument((units & PeriodUnits.AllTimeUnits) == 0, "units", "Units contains time units: {0}", units);
			Preconditions.CheckArgument(units != PeriodUnits.None, "units", "Units must not be empty");
			Preconditions.CheckArgument((units & ~PeriodUnits.AllUnits) == 0, "units", "Units contains an unknown value: {0}", units);
			Preconditions.CheckArgument(start.Calendar.Equals(end.Calendar), "end", "start and end must use the same calendar system");
			if (start == end)
			{
				return Zero;
			}
			switch (units)
			{
			case PeriodUnits.Years:
				return FromYears(DatePeriodFields.YearsField.UnitsBetween(start, end));
			case PeriodUnits.Months:
				return FromMonths(DatePeriodFields.MonthsField.UnitsBetween(start, end));
			case PeriodUnits.Weeks:
				return FromWeeks(DatePeriodFields.WeeksField.UnitsBetween(start, end));
			case PeriodUnits.Days:
				return FromDays(DaysBetween(start, end));
			default:
			{
				DateComponentsBetween(start, end, units, out var years, out var months, out var weeks, out var days);
				return new Period(years, months, weeks, days);
			}
			}
		}

		[Pure]
		[NotNull]
		public static Period Between(LocalDate start, LocalDate end)
		{
			return Between(start, end, PeriodUnits.YearMonthDay);
		}

		[Pure]
		[NotNull]
		public static Period Between(LocalTime start, LocalTime end, PeriodUnits units)
		{
			Preconditions.CheckArgument((units & PeriodUnits.AllDateUnits) == 0, "units", "Units contains date units: {0}", units);
			Preconditions.CheckArgument(units != PeriodUnits.None, "units", "Units must not be empty");
			Preconditions.CheckArgument((units & ~PeriodUnits.AllUnits) == 0, "units", "Units contains an unknown value: {0}", units);
			long num = end.NanosecondOfDay - start.NanosecondOfDay;
			switch (units)
			{
			case PeriodUnits.Hours:
				return FromHours(num / 3600000000000L);
			case PeriodUnits.Minutes:
				return FromMinutes(num / 60000000000L);
			case PeriodUnits.Seconds:
				return FromSeconds(num / 1000000000);
			case PeriodUnits.Milliseconds:
				return FromMilliseconds(num / 1000000);
			case PeriodUnits.Ticks:
				return FromTicks(num / 100);
			case PeriodUnits.Nanoseconds:
				return FromNanoseconds(num);
			default:
			{
				TimeComponentsBetween(num, units, out var hours, out var minutes, out var seconds, out var milliseconds, out var ticks, out var nanoseconds);
				return new Period(hours, minutes, seconds, milliseconds, ticks, nanoseconds);
			}
			}
		}

		[Pure]
		[NotNull]
		public static Period Between(LocalTime start, LocalTime end)
		{
			return Between(start, end, PeriodUnits.AllTimeUnits);
		}

		internal static int DaysBetween(LocalDate start, LocalDate end)
		{
			if (start.YearMonthDay == end.YearMonthDay)
			{
				return 0;
			}
			int daysSinceEpoch = start.DaysSinceEpoch;
			return checked(end.DaysSinceEpoch - daysSinceEpoch);
		}

		[Pure]
		public Duration ToDuration()
		{
			if (Months != 0 || Years != 0)
			{
				throw new InvalidOperationException("Cannot construct duration of period with non-zero months or years.");
			}
			return Duration.FromNanoseconds(TotalNanoseconds);
		}

		[Pure]
		[NotNull]
		[TestExemption(TestExemptionCategory.ConversionName, null)]
		public PeriodBuilder ToBuilder()
		{
			return new PeriodBuilder(this);
		}

		[Pure]
		[NotNull]
		public Period Normalize()
		{
			long totalNanoseconds = TotalNanoseconds;
			int days;
			checked
			{
				days = (int)unchecked(totalNanoseconds / 86400000000000L);
			}
			long hours = totalNanoseconds / 3600000000000L % 24;
			long minutes = totalNanoseconds / 60000000000L % 60;
			long seconds = totalNanoseconds / 1000000000 % 60;
			long milliseconds = totalNanoseconds / 1000000 % 1000;
			long nanoseconds = totalNanoseconds % 1000000;
			return new Period(Years, Months, 0, days, hours, minutes, seconds, milliseconds, 0L, nanoseconds);
		}

		public override string ToString()
		{
			return PeriodPattern.Roundtrip.Format(this);
		}

		public override bool Equals(object other)
		{
			return Equals(other as Period);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Initialize().Hash(Years).Hash(Months)
				.Hash(Weeks)
				.Hash(Days)
				.Hash(Hours)
				.Hash(Minutes)
				.Hash(Seconds)
				.Hash(Milliseconds)
				.Hash(Ticks)
				.Hash(Nanoseconds)
				.Value;
		}

		public bool Equals(Period other)
		{
			if (other != null && Years == other.Years && Months == other.Months && Weeks == other.Weeks && Days == other.Days && Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds && Milliseconds == other.Milliseconds && Ticks == other.Ticks)
			{
				return Nanoseconds == other.Nanoseconds;
			}
			return false;
		}
	}
	[Mutable]
	public sealed class PeriodBuilder : IXmlSerializable
	{
		public int Years { get; set; }

		public int Months { get; set; }

		public int Weeks { get; set; }

		public int Days { get; set; }

		public long Hours { get; set; }

		public long Minutes { get; set; }

		public long Seconds { get; set; }

		public long Milliseconds { get; set; }

		public long Ticks { get; set; }

		public long Nanoseconds { get; set; }

		public long this[PeriodUnits unit]
		{
			get
			{
				return unit switch
				{
					PeriodUnits.Years => Years, 
					PeriodUnits.Months => Months, 
					PeriodUnits.Weeks => Weeks, 
					PeriodUnits.Days => Days, 
					PeriodUnits.Hours => Hours, 
					PeriodUnits.Minutes => Minutes, 
					PeriodUnits.Seconds => Seconds, 
					PeriodUnits.Milliseconds => Milliseconds, 
					PeriodUnits.Ticks => Ticks, 
					PeriodUnits.Nanoseconds => Nanoseconds, 
					_ => throw new ArgumentOutOfRangeException("unit", "Indexer for PeriodBuilder only takes a single unit"), 
				};
			}
			set
			{
				if ((unit & PeriodUnits.AllDateUnits) != PeriodUnits.None)
				{
					Preconditions.CheckArgumentRange("value", value, -2147483648L, 2147483647L);
				}
				checked
				{
					switch (unit)
					{
					case PeriodUnits.Years:
						Years = (int)value;
						break;
					case PeriodUnits.Months:
						Months = (int)value;
						break;
					case PeriodUnits.Weeks:
						Weeks = (int)value;
						break;
					case PeriodUnits.Days:
						Days = (int)value;
						break;
					case PeriodUnits.Hours:
						Hours = value;
						break;
					case PeriodUnits.Minutes:
						Minutes = value;
						break;
					case PeriodUnits.Seconds:
						Seconds = value;
						break;
					case PeriodUnits.Milliseconds:
						Milliseconds = value;
						break;
					case PeriodUnits.Ticks:
						Ticks = value;
						break;
					case PeriodUnits.Nanoseconds:
						Nanoseconds = value;
						break;
					default:
						throw new ArgumentOutOfRangeException("unit", "Indexer for PeriodBuilder only takes a single unit");
					}
				}
			}
		}

		public PeriodBuilder()
		{
		}

		public PeriodBuilder([NotNull] Period period)
		{
			Preconditions.CheckNotNull(period, "period");
			Years = period.Years;
			Months = period.Months;
			Weeks = period.Weeks;
			Days = period.Days;
			Hours = period.Hours;
			Minutes = period.Minutes;
			Seconds = period.Seconds;
			Milliseconds = period.Milliseconds;
			Ticks = period.Ticks;
			Nanoseconds = period.Nanoseconds;
		}

		[NotNull]
		public Period Build()
		{
			return new Period(Years, Months, Weeks, Days, Hours, Minutes, Seconds, Milliseconds, Ticks, Nanoseconds);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			string text = reader.ReadElementContentAsString();
			Period value = PeriodPattern.Roundtrip.Parse(text).Value;
			Years = value.Years;
			Months = value.Months;
			Weeks = value.Weeks;
			Days = value.Days;
			Hours = value.Hours;
			Minutes = value.Minutes;
			Seconds = value.Seconds;
			Milliseconds = value.Milliseconds;
			Ticks = value.Ticks;
			Nanoseconds = value.Nanoseconds;
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			writer.WriteString(PeriodPattern.Roundtrip.Format(Build()));
		}
	}
	[Flags]
	public enum PeriodUnits
	{
		None = 0,
		Years = 1,
		Months = 2,
		Weeks = 4,
		Days = 8,
		AllDateUnits = 0xF,
		YearMonthDay = 0xB,
		Hours = 0x10,
		Minutes = 0x20,
		Seconds = 0x40,
		Milliseconds = 0x80,
		Ticks = 0x100,
		Nanoseconds = 0x200,
		HourMinuteSecond = 0x70,
		AllTimeUnits = 0x3F0,
		DateAndTime = 0x3FB,
		AllUnits = 0x3FF
	}
	[Mutable]
	public sealed class SkippedTimeException : ArgumentOutOfRangeException
	{
		public LocalDateTime LocalDateTime { get; }

		[NotNull]
		public DateTimeZone Zone { get; }

		public SkippedTimeException(LocalDateTime localDateTime, [NotNull] DateTimeZone zone)
			: base(string.Concat("Local time ", localDateTime, " is invalid in time zone ", Preconditions.CheckNotNull(zone, "zone").Id))
		{
			LocalDateTime = localDateTime;
			Zone = zone;
		}
	}
	[Immutable]
	public sealed class SystemClock : IClock
	{
		[NotNull]
		public static SystemClock Instance { get; } = new SystemClock();

		private SystemClock()
		{
		}

		public Instant GetCurrentInstant()
		{
			return NodaConstants.BclEpoch.PlusTicks(DateTime.UtcNow.Ticks);
		}
	}
	public static class TimeAdjusters
	{
		[NotNull]
		public static Func<LocalTime, LocalTime> TruncateToSecond { get; } = (LocalTime time) => new LocalTime(time.Hour, time.Minute, time.Second);

		[NotNull]
		public static Func<LocalTime, LocalTime> TruncateToMinute { get; } = (LocalTime time) => new LocalTime(time.Hour, time.Minute);

		[NotNull]
		public static Func<LocalTime, LocalTime> TruncateToHour { get; } = (LocalTime time) => new LocalTime(time.Hour, 0);
	}
	internal struct YearMonthDay : IComparable<YearMonthDay>, IEquatable<YearMonthDay>
	{
		private const int DayMask = 63;

		private const int MonthMask = 1984;

		private readonly int value;

		internal int Year => (value >> 11) + 1;

		internal int Month => ((value & 0x7C0) >> 6) + 1;

		internal int Day => (value & 0x3F) + 1;

		internal YearMonthDay(int rawValue)
		{
			value = rawValue;
		}

		internal YearMonthDay(int year, int month, int day)
		{
			value = (year - 1 << 11) | (month - 1 << 6) | (day - 1);
		}

		internal static YearMonthDay Parse(string text)
		{
			if (text.StartsWith("-"))
			{
				YearMonthDay yearMonthDay = Parse(text.Substring(1));
				return new YearMonthDay(checked(-yearMonthDay.Year), yearMonthDay.Month, yearMonthDay.Day);
			}
			string[] array = text.Split(new char[1] { '-' });
			return new YearMonthDay(int.Parse(array[0], CultureInfo.InvariantCulture), int.Parse(array[1], CultureInfo.InvariantCulture), int.Parse(array[2], CultureInfo.InvariantCulture));
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0000}-{1:00}-{2:00}", Year, Month, Day);
		}

		internal YearMonthDayCalendar WithCalendar([CanBeNull] CalendarSystem calendar)
		{
			return new YearMonthDayCalendar(value, calendar?.Ordinal ?? CalendarOrdinal.Iso);
		}

		internal YearMonthDayCalendar WithCalendarOrdinal(CalendarOrdinal calendarOrdinal)
		{
			return new YearMonthDayCalendar(value, calendarOrdinal);
		}

		public int CompareTo(YearMonthDay other)
		{
			int num = value;
			return num.CompareTo(other.value);
		}

		public bool Equals(YearMonthDay other)
		{
			return value == other.value;
		}

		public override bool Equals(object other)
		{
			if (other is YearMonthDay)
			{
				return Equals((YearMonthDay)other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return value;
		}

		public static bool operator ==(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value == rhs.value;
		}

		public static bool operator !=(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value != rhs.value;
		}

		public static bool operator <(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value < rhs.value;
		}

		public static bool operator <=(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value <= rhs.value;
		}

		public static bool operator >(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value > rhs.value;
		}

		public static bool operator >=(YearMonthDay lhs, YearMonthDay rhs)
		{
			return lhs.value >= rhs.value;
		}
	}
	internal struct YearMonthDayCalendar : IEquatable<YearMonthDayCalendar>
	{
		internal const int CalendarBits = 6;

		internal const int DayBits = 6;

		internal const int MonthBits = 5;

		internal const int YearBits = 15;

		private const int CalendarDayBits = 12;

		private const int CalendarDayMonthBits = 17;

		private const int CalendarMask = 63;

		private const int DayMask = 4032;

		private const int MonthMask = 126976;

		private const int YearMask = -131072;

		private readonly int value;

		internal CalendarOrdinal CalendarOrdinal => (CalendarOrdinal)(value & 0x3F);

		internal int Year => ((value & -131072) >> 17) + 1;

		internal int Month => ((value & 0x1F000) >> 12) + 1;

		internal int Day => ((value & 0xFC0) >> 6) + 1;

		internal YearMonthDayCalendar(int yearMonthDay, CalendarOrdinal calendarOrdinal)
		{
			value = (yearMonthDay << 6) | (int)calendarOrdinal;
		}

		internal YearMonthDayCalendar(int year, int month, int day, CalendarOrdinal calendarOrdinal)
		{
			value = (year - 1 << 17) | (month - 1 << 12) | (day - 1 << 6) | (int)calendarOrdinal;
		}

		[VisibleForTesting]
		internal static YearMonthDayCalendar Parse(string text)
		{
			if (text.StartsWith("-"))
			{
				YearMonthDayCalendar yearMonthDayCalendar = Parse(text.Substring(1));
				return new YearMonthDayCalendar(checked(-yearMonthDayCalendar.Year), yearMonthDayCalendar.Month, yearMonthDayCalendar.Day, yearMonthDayCalendar.CalendarOrdinal);
			}
			string[] array = text.Split(new char[1] { '-' });
			return new YearMonthDayCalendar(int.Parse(array[0], CultureInfo.InvariantCulture), int.Parse(array[1], CultureInfo.InvariantCulture), int.Parse(array[2], CultureInfo.InvariantCulture), (CalendarOrdinal)Enum.Parse(typeof(CalendarOrdinal), array[3], ignoreCase: false));
		}

		internal YearMonthDay ToYearMonthDay()
		{
			return new YearMonthDay(value >> 6);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0000}-{1:00}-{2:00}-{3}", Year, Month, Day, CalendarOrdinal);
		}

		public static bool operator ==(YearMonthDayCalendar lhs, YearMonthDayCalendar rhs)
		{
			return lhs.value == rhs.value;
		}

		public static bool operator !=(YearMonthDayCalendar lhs, YearMonthDayCalendar rhs)
		{
			return lhs.value != rhs.value;
		}

		public bool Equals(YearMonthDayCalendar other)
		{
			return value == other.value;
		}

		public override bool Equals(object other)
		{
			if (other is YearMonthDayCalendar)
			{
				return Equals((YearMonthDayCalendar)other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return value;
		}
	}
	[Immutable]
	public sealed class ZonedClock : IClock
	{
		private readonly IClock clock;

		private readonly DateTimeZone zone;

		private readonly CalendarSystem calendar;

		public ZonedClock([NotNull] IClock clock, [NotNull] DateTimeZone zone, [NotNull] CalendarSystem calendar)
		{
			this.clock = Preconditions.CheckNotNull(clock, "clock");
			this.zone = Preconditions.CheckNotNull(zone, "zone");
			this.calendar = Preconditions.CheckNotNull(calendar, "calendar");
		}

		public Instant GetCurrentInstant()
		{
			return clock.GetCurrentInstant();
		}

		[Pure]
		public ZonedDateTime GetCurrentZonedDateTime()
		{
			return GetCurrentInstant().InZone(zone, calendar);
		}

		[Pure]
		public LocalDateTime GetCurrentLocalDateTime()
		{
			return GetCurrentZonedDateTime().LocalDateTime;
		}

		[Pure]
		public OffsetDateTime GetCurrentOffsetDateTime()
		{
			return GetCurrentZonedDateTime().ToOffsetDateTime();
		}

		[Pure]
		public LocalDate GetCurrentDate()
		{
			return GetCurrentZonedDateTime().Date;
		}

		[Pure]
		public LocalTime GetCurrentTimeOfDay()
		{
			return GetCurrentZonedDateTime().TimeOfDay;
		}
	}
	public struct ZonedDateTime : IEquatable<ZonedDateTime>, IFormattable, IXmlSerializable
	{
		[Immutable]
		public abstract class Comparer : IComparer<ZonedDateTime>, IEqualityComparer<ZonedDateTime>
		{
			[NotNull]
			public static Comparer Local => LocalComparer.Instance;

			[NotNull]
			public static Comparer Instant => InstantComparer.Instance;

			internal Comparer()
			{
			}

			public abstract int Compare(ZonedDateTime x, ZonedDateTime y);

			public abstract bool Equals(ZonedDateTime x, ZonedDateTime y);

			public abstract int GetHashCode(ZonedDateTime obj);
		}

		private sealed class LocalComparer : Comparer
		{
			internal static readonly Comparer Instance = new LocalComparer();

			private LocalComparer()
			{
			}

			public override int Compare(ZonedDateTime x, ZonedDateTime y)
			{
				return OffsetDateTime.Comparer.Local.Compare(x.offsetDateTime, y.offsetDateTime);
			}

			public override bool Equals(ZonedDateTime x, ZonedDateTime y)
			{
				return OffsetDateTime.Comparer.Local.Equals(x.offsetDateTime, y.offsetDateTime);
			}

			public override int GetHashCode(ZonedDateTime obj)
			{
				return OffsetDateTime.Comparer.Local.GetHashCode(obj.offsetDateTime);
			}
		}

		private sealed class InstantComparer : Comparer
		{
			internal static readonly Comparer Instance = new InstantComparer();

			private InstantComparer()
			{
			}

			public override int Compare(ZonedDateTime x, ZonedDateTime y)
			{
				return OffsetDateTime.Comparer.Instant.Compare(x.offsetDateTime, y.offsetDateTime);
			}

			public override bool Equals(ZonedDateTime x, ZonedDateTime y)
			{
				return OffsetDateTime.Comparer.Instant.Equals(x.offsetDateTime, y.offsetDateTime);
			}

			public override int GetHashCode(ZonedDateTime obj)
			{
				return OffsetDateTime.Comparer.Instant.GetHashCode(obj.offsetDateTime);
			}
		}

		[ReadWriteForEfficiency]
		private OffsetDateTime offsetDateTime;

		private readonly DateTimeZone zone;

		public Offset Offset => offsetDateTime.Offset;

		[NotNull]
		public DateTimeZone Zone => zone ?? DateTimeZone.Utc;

		public LocalDateTime LocalDateTime => offsetDateTime.LocalDateTime;

		[NotNull]
		public CalendarSystem Calendar => offsetDateTime.Calendar;

		public LocalDate Date => offsetDateTime.Date;

		public LocalTime TimeOfDay => offsetDateTime.TimeOfDay;

		[NotNull]
		public Era Era => offsetDateTime.Era;

		public int Year => offsetDateTime.Year;

		public int YearOfEra => offsetDateTime.YearOfEra;

		public int Month => offsetDateTime.Month;

		public int DayOfYear => offsetDateTime.DayOfYear;

		public int Day => offsetDateTime.Day;

		public IsoDayOfWeek DayOfWeek => offsetDateTime.DayOfWeek;

		public int Hour => offsetDateTime.Hour;

		public int ClockHourOfHalfDay => offsetDateTime.ClockHourOfHalfDay;

		public int Minute => offsetDateTime.Minute;

		public int Second => offsetDateTime.Second;

		public int Millisecond => offsetDateTime.Millisecond;

		public int TickOfSecond => offsetDateTime.TickOfSecond;

		public long TickOfDay => offsetDateTime.TickOfDay;

		public int NanosecondOfSecond => offsetDateTime.NanosecondOfSecond;

		public long NanosecondOfDay => offsetDateTime.NanosecondOfDay;

		internal ZonedDateTime(OffsetDateTime offsetDateTime, DateTimeZone zone)
		{
			this.offsetDateTime = offsetDateTime;
			this.zone = zone;
		}

		public ZonedDateTime(Instant instant, [NotNull] DateTimeZone zone, [NotNull] CalendarSystem calendar)
		{
			this.zone = Preconditions.CheckNotNull(zone, "zone");
			offsetDateTime = new OffsetDateTime(instant, zone.GetUtcOffset(instant), Preconditions.CheckNotNull(calendar, "calendar"));
		}

		public ZonedDateTime(Instant instant, [NotNull] DateTimeZone zone)
		{
			this.zone = Preconditions.CheckNotNull(zone, "zone");
			offsetDateTime = new OffsetDateTime(instant, zone.GetUtcOffset(instant));
		}

		public ZonedDateTime(LocalDateTime localDateTime, [NotNull] DateTimeZone zone, Offset offset)
		{
			this.zone = Preconditions.CheckNotNull(zone, "zone");
			Instant instant = localDateTime.ToLocalInstant().Minus(offset);
			if (zone.GetUtcOffset(instant) != offset)
			{
				throw new ArgumentException(string.Concat("Offset ", offset, " is invalid for local date and time ", localDateTime, " in time zone ", zone.Id), "offset");
			}
			offsetDateTime = new OffsetDateTime(localDateTime, offset);
		}

		[Pure]
		public Instant ToInstant()
		{
			return offsetDateTime.ToInstant();
		}

		[Pure]
		public ZonedDateTime WithZone([NotNull] DateTimeZone targetZone)
		{
			Preconditions.CheckNotNull(targetZone, "targetZone");
			return new ZonedDateTime(ToInstant(), targetZone, Calendar);
		}

		[Pure]
		public ZonedDateTime WithCalendar([NotNull] CalendarSystem calendar)
		{
			return new ZonedDateTime(offsetDateTime.WithCalendar(calendar), zone);
		}

		public bool Equals(ZonedDateTime other)
		{
			if (offsetDateTime == other.offsetDateTime)
			{
				return Zone.Equals(other.Zone);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ZonedDateTime)
			{
				return Equals((ZonedDateTime)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(offsetDateTime, Zone);
		}

		public static bool operator ==(ZonedDateTime left, ZonedDateTime right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ZonedDateTime left, ZonedDateTime right)
		{
			return !(left == right);
		}

		public static ZonedDateTime Add(ZonedDateTime zonedDateTime, Duration duration)
		{
			return zonedDateTime + duration;
		}

		[Pure]
		public ZonedDateTime Plus(Duration duration)
		{
			return this + duration;
		}

		[Pure]
		public ZonedDateTime PlusHours(int hours)
		{
			return this + Duration.FromHours(hours);
		}

		[Pure]
		public ZonedDateTime PlusMinutes(int minutes)
		{
			return this + Duration.FromMinutes(minutes);
		}

		[Pure]
		public ZonedDateTime PlusSeconds(long seconds)
		{
			return this + Duration.FromSeconds(seconds);
		}

		[Pure]
		public ZonedDateTime PlusMilliseconds(long milliseconds)
		{
			return this + Duration.FromMilliseconds(milliseconds);
		}

		[Pure]
		public ZonedDateTime PlusTicks(long ticks)
		{
			return this + Duration.FromTicks(ticks);
		}

		[Pure]
		public ZonedDateTime PlusNanoseconds(long nanoseconds)
		{
			return this + Duration.FromNanoseconds(nanoseconds);
		}

		public static ZonedDateTime operator +(ZonedDateTime zonedDateTime, Duration duration)
		{
			return new ZonedDateTime(zonedDateTime.ToInstant() + duration, zonedDateTime.Zone, zonedDateTime.Calendar);
		}

		public static ZonedDateTime Subtract(ZonedDateTime zonedDateTime, Duration duration)
		{
			return zonedDateTime - duration;
		}

		[Pure]
		public ZonedDateTime Minus(Duration duration)
		{
			return this - duration;
		}

		public static ZonedDateTime operator -(ZonedDateTime zonedDateTime, Duration duration)
		{
			return new ZonedDateTime(zonedDateTime.ToInstant() - duration, zonedDateTime.Zone, zonedDateTime.Calendar);
		}

		public static Duration Subtract(ZonedDateTime end, ZonedDateTime start)
		{
			return end - start;
		}

		[Pure]
		public Duration Minus(ZonedDateTime other)
		{
			return this - other;
		}

		public static Duration operator -(ZonedDateTime end, ZonedDateTime start)
		{
			return end.ToInstant() - start.ToInstant();
		}

		[Pure]
		[NotNull]
		public ZoneInterval GetZoneInterval()
		{
			return Zone.GetZoneInterval(ToInstant());
		}

		[Pure]
		public bool IsDaylightSavingTime()
		{
			return GetZoneInterval().Savings != Offset.Zero;
		}

		public override string ToString()
		{
			return ZonedDateTimePattern.Patterns.BclSupport.Format(this, null, CultureInfo.CurrentCulture);
		}

		public string ToString(string patternText, IFormatProvider formatProvider)
		{
			return ZonedDateTimePattern.Patterns.BclSupport.Format(this, patternText, formatProvider);
		}

		[Pure]
		public DateTimeOffset ToDateTimeOffset()
		{
			return offsetDateTime.ToDateTimeOffset();
		}

		public static ZonedDateTime FromDateTimeOffset(DateTimeOffset dateTimeOffset)
		{
			return new ZonedDateTime(Instant.FromDateTimeOffset(dateTimeOffset), new FixedDateTimeZone(Offset.FromTimeSpan(dateTimeOffset.Offset)));
		}

		[Pure]
		public DateTime ToDateTimeUtc()
		{
			return ToInstant().ToDateTimeUtc();
		}

		[Pure]
		public DateTime ToDateTimeUnspecified()
		{
			return LocalDateTime.ToDateTimeUnspecified();
		}

		[Pure]
		public OffsetDateTime ToOffsetDateTime()
		{
			return offsetDateTime;
		}

		[Pure]
		public void Deconstruct(out LocalDateTime localDateTime, [NotNull] out DateTimeZone dateTimeZone, out Offset offset)
		{
			localDateTime = LocalDateTime;
			dateTimeZone = Zone;
			offset = Offset;
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml([NotNull] XmlReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			OffsetDateTimePattern offsetDateTimePattern = OffsetDateTimePattern.ExtendedIso;
			if (!reader.MoveToAttribute("zone"))
			{
				throw new ArgumentException("No zone specified in XML for ZonedDateTime");
			}
			DateTimeZone dateTimeZone = DateTimeZoneProviders.Serialization[reader.Value];
			if (reader.MoveToAttribute("calendar"))
			{
				CalendarSystem calendar = CalendarSystem.ForId(reader.Value);
				OffsetDateTime newTemplateValue = offsetDateTimePattern.TemplateValue.WithCalendar(calendar);
				offsetDateTimePattern = offsetDateTimePattern.WithTemplateValue(newTemplateValue);
			}
			reader.MoveToElement();
			string text = reader.ReadElementContentAsString();
			OffsetDateTime value = offsetDateTimePattern.Parse(text).Value;
			if (dateTimeZone.GetUtcOffset(value.ToInstant()) != value.Offset)
			{
				ParseResult<ZonedDateTime>.InvalidOffset(text).GetValueOrThrow();
			}
			this = new ZonedDateTime(value, dateTimeZone);
		}

		void IXmlSerializable.WriteXml([NotNull] XmlWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteAttributeString("zone", Zone.Id);
			if (Calendar != CalendarSystem.Iso)
			{
				writer.WriteAttributeString("calendar", Calendar.Id);
			}
			writer.WriteString(OffsetDateTimePattern.ExtendedIso.Format(ToOffsetDateTime()));
		}
	}
}
namespace NodaTime.Utility
{
	public static class BclConversions
	{
		public static DayOfWeek ToDayOfWeek(IsoDayOfWeek isoDayOfWeek)
		{
			switch (isoDayOfWeek)
			{
			default:
				throw new ArgumentOutOfRangeException("isoDayOfWeek");
			case IsoDayOfWeek.Monday:
			case IsoDayOfWeek.Tuesday:
			case IsoDayOfWeek.Wednesday:
			case IsoDayOfWeek.Thursday:
			case IsoDayOfWeek.Friday:
			case IsoDayOfWeek.Saturday:
				return (DayOfWeek)isoDayOfWeek;
			case IsoDayOfWeek.Sunday:
				return DayOfWeek.Sunday;
			}
		}

		public static IsoDayOfWeek ToIsoDayOfWeek(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
			default:
				throw new ArgumentOutOfRangeException("dayOfWeek");
			case DayOfWeek.Monday:
			case DayOfWeek.Tuesday:
			case DayOfWeek.Wednesday:
			case DayOfWeek.Thursday:
			case DayOfWeek.Friday:
			case DayOfWeek.Saturday:
				return (IsoDayOfWeek)dayOfWeek;
			case DayOfWeek.Sunday:
				return IsoDayOfWeek.Sunday;
			}
		}
	}
	internal sealed class Cache<TKey, TValue>
	{
		private readonly int size;

		private readonly Func<TKey, TValue> valueFactory;

		private readonly ConcurrentQueue<TKey> keyList;

		private readonly ConcurrentDictionary<TKey, TValue> dictionary;

		internal int Count => dictionary.Count;

		internal List<TKey> Keys => (from pair in dictionary.ToArray()
			select pair.Key).ToList();

		internal Cache(int size, Func<TKey, TValue> valueFactory, IEqualityComparer<TKey> keyComparer)
		{
			this.size = size;
			this.valueFactory = valueFactory;
			dictionary = new ConcurrentDictionary<TKey, TValue>(keyComparer);
			keyList = new ConcurrentQueue<TKey>();
		}

		internal TValue GetOrAdd(TKey key)
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				return value;
			}
			keyList.Enqueue(key);
			value = dictionary.GetOrAdd(key, valueFactory);
			TKey result;
			while (dictionary.Count > size && keyList.TryDequeue(out result))
			{
				dictionary.TryRemove(result, out var _);
			}
			return value;
		}

		internal void Clear()
		{
			TKey result;
			while (keyList.TryDequeue(out result))
			{
			}
			dictionary.Clear();
		}
	}
	internal struct HashCodeHelper
	{
		private const int HashCodeMultiplier = 37;

		private const int HashCodeInitializer = 17;

		public int Value { get; }

		internal HashCodeHelper(int value)
		{
			Value = value;
		}

		internal static int Hash<T1, T2>(T1 t1, T2 t2)
		{
			return (17 * 37 + (t1?.GetHashCode() ?? 0)) * 37 + (t2?.GetHashCode() ?? 0);
		}

		internal static int Hash<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
		{
			return ((17 * 37 + (t1?.GetHashCode() ?? 0)) * 37 + (t2?.GetHashCode() ?? 0)) * 37 + (t3?.GetHashCode() ?? 0);
		}

		internal static HashCodeHelper Initialize()
		{
			return new HashCodeHelper(17);
		}

		internal HashCodeHelper Hash<T>(T value)
		{
			return new HashCodeHelper(Value * 37 + (value?.GetHashCode() ?? 0));
		}
	}
	[Mutable]
	public sealed class InvalidNodaDataException : Exception
	{
		public InvalidNodaDataException(string message)
			: base(message)
		{
		}

		public InvalidNodaDataException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	internal sealed class NodaReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly IDictionary<TKey, TValue> original;

		public ICollection<TKey> Keys => original.Keys;

		public ICollection<TValue> Values => original.Values;

		public TValue this[TKey key]
		{
			get
			{
				return original[key];
			}
			set
			{
				throw new NotSupportedException("Cannot set a value in a read-only dictionary");
			}
		}

		public int Count => original.Count;

		public bool IsReadOnly => true;

		internal NodaReadOnlyDictionary([NotNull] IDictionary<TKey, TValue> original)
		{
			this.original = Preconditions.CheckNotNull(original, "original");
		}

		public bool ContainsKey(TKey key)
		{
			return original.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return original.TryGetValue(key, out value);
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return original.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			original.CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return original.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
			throw new NotSupportedException("Cannot add to a read-only dictionary");
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException("Cannot add to a read-only dictionary");
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			throw new NotSupportedException("Cannot remove from a read-only dictionary");
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException("Cannot remove from a read-only dictionary");
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
			throw new NotSupportedException("Cannot clear a read-only dictionary");
		}
	}
	internal static class Preconditions
	{
		[ContractAnnotation("argument:null => halt")]
		internal static T CheckNotNull<T>(T argument, [InvokerParameterName] string paramName) where T : class
		{
			if (argument == null)
			{
				throw new ArgumentNullException(paramName);
			}
			return argument;
		}

		[Conditional("DEBUG")]
		[ContractAnnotation("argument:null => halt")]
		internal static void DebugCheckNotNull<T>(T argument, [InvokerParameterName] string paramName) where T : class
		{
		}

		internal static void CheckArgumentRange([InvokerParameterName] string paramName, int value, int minInclusive, int maxInclusive)
		{
			if (value < minInclusive || value > maxInclusive)
			{
				ThrowArgumentOutOfRangeException(paramName, value, minInclusive, maxInclusive);
			}
		}

		internal static void CheckArgumentRange([InvokerParameterName] string paramName, long value, long minInclusive, long maxInclusive)
		{
			if (value < minInclusive || value > maxInclusive)
			{
				ThrowArgumentOutOfRangeException(paramName, value, minInclusive, maxInclusive);
			}
		}

		internal static void CheckArgumentRange([InvokerParameterName] string paramName, double value, double minInclusive, double maxInclusive)
		{
			if (value < minInclusive || value > maxInclusive || double.IsNaN(value))
			{
				ThrowArgumentOutOfRangeException(paramName, value, minInclusive, maxInclusive);
			}
		}

		private static void ThrowArgumentOutOfRangeException<T>([InvokerParameterName] string paramName, T value, T minInclusive, T maxInclusive)
		{
			throw new ArgumentOutOfRangeException(paramName, value, $"Value should be in range [{minInclusive}-{maxInclusive}]");
		}

		[Conditional("DEBUG")]
		internal static void DebugCheckArgumentRange([InvokerParameterName] string paramName, int value, int minInclusive, int maxInclusive)
		{
		}

		[Conditional("DEBUG")]
		internal static void DebugCheckArgumentRange([InvokerParameterName] string paramName, long value, long minInclusive, long maxInclusive)
		{
		}

		[ContractAnnotation("expression:false => halt")]
		[Conditional("DEBUG")]
		internal static void DebugCheckArgument(bool expression, [InvokerParameterName] string parameter, string messageFormat, params object[] messageArgs)
		{
		}

		[ContractAnnotation("expression:false => halt")]
		internal static void CheckArgument(bool expression, [InvokerParameterName] string parameter, string message)
		{
			if (!expression)
			{
				throw new ArgumentException(message, parameter);
			}
		}

		[ContractAnnotation("expression:false => halt")]
		[StringFormatMethod("messageFormat")]
		internal static void CheckArgument<T>(bool expression, [InvokerParameterName] string parameter, string messageFormat, T messageArg)
		{
			if (!expression)
			{
				throw new ArgumentException(string.Format(messageFormat, messageArg), parameter);
			}
		}

		[ContractAnnotation("expression:false => halt")]
		[StringFormatMethod("messageFormat")]
		internal static void CheckArgument<T1, T2>(bool expression, string parameter, string messageFormat, T1 messageArg1, T2 messageArg2)
		{
			if (!expression)
			{
				throw new ArgumentException(string.Format(messageFormat, messageArg1, messageArg2), parameter);
			}
		}

		internal static void CheckState(bool expression, string message)
		{
			if (!expression)
			{
				throw new InvalidOperationException(message);
			}
		}

		[ContractAnnotation("expression:false => halt")]
		[Conditional("DEBUG")]
		internal static void DebugCheckState(bool expression, string message)
		{
		}
	}
	internal sealed class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
	{
		public bool Equals(T first, T second)
		{
			return first == second;
		}

		public int GetHashCode(T value)
		{
			if (value != null)
			{
				return RuntimeHelpers.GetHashCode(value);
			}
			return 0;
		}
	}
	internal static class TickArithmetic
	{
		internal static int TicksToDaysAndTickOfDay(long ticks, out long tickOfDay)
		{
			if (ticks >= 0)
			{
				int num = (int)((ticks >> 14) / 52734375);
				tickOfDay = ticks - num * 864000000000L;
				return num;
			}
			int num2 = (int)((ticks + 1) / 864000000000L) - 1;
			tickOfDay = ticks - (num2 + 1) * 864000000000L + 864000000000L;
			return num2;
		}

		internal static int NonNegativeTicksToDaysAndTickOfDay([Trusted] long ticks, out long tickOfDay)
		{
			int num = (int)((ticks >> 14) / 52734375);
			tickOfDay = ticks - num * 864000000000L;
			return num;
		}

		internal static long DaysAndTickOfDayToTicks(int days, long tickOfDay)
		{
			checked
			{
				if (days < -10675199)
				{
					return (days + 1) * 864000000000L + tickOfDay - 864000000000L;
				}
				return days * 864000000000L + tickOfDay;
			}
		}

		internal static long BoundedDaysAndTickOfDayToTicks([Trusted] int days, [Trusted] long tickOfDay)
		{
			return days * 864000000000L + tickOfDay;
		}
	}
}
namespace NodaTime.TimeZones
{
	internal sealed class CachedDateTimeZone : DateTimeZone
	{
		private readonly IZoneIntervalMap map;

		internal DateTimeZone TimeZone { get; }

		private CachedDateTimeZone(DateTimeZone timeZone, IZoneIntervalMap map)
			: base(timeZone.Id, isFixed: false, timeZone.MinOffset, timeZone.MaxOffset)
		{
			TimeZone = timeZone;
			this.map = map;
		}

		internal static DateTimeZone ForZone([NotNull] DateTimeZone timeZone)
		{
			Preconditions.CheckNotNull(timeZone, "timeZone");
			if (timeZone is CachedDateTimeZone || timeZone.IsFixed)
			{
				return timeZone;
			}
			return new CachedDateTimeZone(timeZone, CachingZoneIntervalMap.CacheMap(timeZone));
		}

		public override ZoneInterval GetZoneInterval(Instant instant)
		{
			return map.GetZoneInterval(instant);
		}
	}
	internal static class CachingZoneIntervalMap
	{
		private sealed class HashArrayCache : IZoneIntervalMap
		{
			private sealed class HashCacheNode
			{
				internal ZoneInterval Interval { get; }

				internal int Period { get; }

				internal HashCacheNode Previous { get; }

				internal static HashCacheNode CreateNode(int period, IZoneIntervalMap map)
				{
					int num = period << 5;
					Instant instant = Instant.FromTrustedDuration(new Duration(Math.Max(num, -4371222), 0L));
					int num2 = checked(num + 32);
					ZoneInterval zoneInterval = map.GetZoneInterval(instant);
					HashCacheNode hashCacheNode = new HashCacheNode(zoneInterval, period, null);
					while (zoneInterval.RawEnd.DaysSinceEpoch < num2)
					{
						zoneInterval = map.GetZoneInterval(zoneInterval.End);
						hashCacheNode = new HashCacheNode(zoneInterval, period, hashCacheNode);
					}
					return hashCacheNode;
				}

				private HashCacheNode(ZoneInterval interval, int period, HashCacheNode previous)
				{
					Period = period;
					Interval = interval;
					Previous = previous;
				}
			}

			private const int CacheSize = 512;

			private const int CachePeriodMask = 511;

			private const int PeriodShift = 5;

			private readonly HashCacheNode[] instantCache;

			private readonly IZoneIntervalMap map;

			internal HashArrayCache([NotNull] IZoneIntervalMap map)
			{
				this.map = Preconditions.CheckNotNull(map, "map");
				instantCache = new HashCacheNode[512];
			}

			public ZoneInterval GetZoneInterval(Instant instant)
			{
				int num = instant.DaysSinceEpoch >> 5;
				int num2 = num & 0x1FF;
				HashCacheNode hashCacheNode = instantCache[num2];
				if (hashCacheNode == null || hashCacheNode.Period != num)
				{
					hashCacheNode = HashCacheNode.CreateNode(num, map);
					instantCache[num2] = hashCacheNode;
				}
				while (hashCacheNode.Previous != null && hashCacheNode.Interval.RawStart > instant)
				{
					hashCacheNode = hashCacheNode.Previous;
				}
				return hashCacheNode.Interval;
			}
		}

		internal static IZoneIntervalMap CacheMap([NotNull] IZoneIntervalMap map)
		{
			return new HashArrayCache(map);
		}
	}
	[Immutable]
	public sealed class DateTimeZoneCache : IDateTimeZoneProvider
	{
		private readonly IDateTimeZoneSource source;

		private readonly ConcurrentDictionary<string, DateTimeZone> timeZoneMap = new ConcurrentDictionary<string, DateTimeZone>();

		[NotNull]
		public string VersionId { get; }

		[NotNull]
		public ReadOnlyCollection<string> Ids { get; }

		[NotNull]
		public DateTimeZone this[[NotNull] string id] => GetZoneOrNull(id) ?? throw new DateTimeZoneNotFoundException($"Time zone {id} is unknown to source {VersionId}");

		public DateTimeZoneCache([NotNull] IDateTimeZoneSource source)
		{
			this.source = Preconditions.CheckNotNull(source, "source");
			VersionId = source.VersionId;
			if (VersionId == null)
			{
				throw new InvalidDateTimeZoneSourceException("Source-returned version ID was null");
			}
			List<string> list = new List<string>(source.GetIds() ?? throw new InvalidDateTimeZoneSourceException("Source-returned ID sequence was null"));
			list.Sort(StringComparer.Ordinal);
			Ids = new ReadOnlyCollection<string>(list);
			foreach (string id in Ids)
			{
				if (id == null)
				{
					throw new InvalidDateTimeZoneSourceException("Source-returned ID sequence contained a null reference");
				}
				timeZoneMap[id] = null;
			}
		}

		[NotNull]
		public DateTimeZone GetSystemDefault()
		{
			string systemDefaultId = source.GetSystemDefaultId();
			if (systemDefaultId == null)
			{
				throw new DateTimeZoneNotFoundException($"System default time zone is unknown to source {VersionId}");
			}
			return this[systemDefaultId];
		}

		[CanBeNull]
		public DateTimeZone GetZoneOrNull([NotNull] string id)
		{
			Preconditions.CheckNotNull(id, "id");
			return GetZoneFromSourceOrNull(id) ?? FixedDateTimeZone.GetFixedZoneOrNull(id);
		}

		private DateTimeZone GetZoneFromSourceOrNull(string id)
		{
			if (!timeZoneMap.TryGetValue(id, out var value))
			{
				return null;
			}
			if (value == null)
			{
				value = source.ForId(id);
				if (value == null)
				{
					throw new InvalidDateTimeZoneSourceException($"Time zone {id} is supported by source {VersionId} but not returned");
				}
				if (!timeZoneMap.TryUpdate(id, value, null))
				{
					return timeZoneMap[id];
				}
				return value;
			}
			return value;
		}
	}
	[Mutable]
	public sealed class DateTimeZoneNotFoundException : Exception
	{
		public DateTimeZoneNotFoundException(string message)
			: base(message)
		{
		}
	}
	public delegate ZonedDateTime AmbiguousTimeResolver(ZonedDateTime earlier, ZonedDateTime later);
	public delegate ZonedDateTime SkippedTimeResolver(LocalDateTime localDateTime, [NotNull] DateTimeZone zone, [NotNull] ZoneInterval intervalBefore, [NotNull] ZoneInterval intervalAfter);
	public delegate ZonedDateTime ZoneLocalMappingResolver([NotNull] ZoneLocalMapping mapping);
	internal sealed class FixedDateTimeZone : DateTimeZone, IEquatable<FixedDateTimeZone>
	{
		private readonly ZoneInterval interval;

		public Offset Offset => base.MaxOffset;

		public string Name => interval.Name;

		internal FixedDateTimeZone(Offset offset)
			: this(MakeId(offset), offset)
		{
		}

		internal FixedDateTimeZone([NotNull] string id, Offset offset)
			: this(id, offset, id)
		{
		}

		internal FixedDateTimeZone([NotNull] string id, Offset offset, [NotNull] string name)
			: base(id, isFixed: true, offset, offset)
		{
			interval = new ZoneInterval(name, Instant.BeforeMinValue, Instant.AfterMaxValue, offset, Offset.Zero);
		}

		private static string MakeId(Offset offset)
		{
			if (offset == Offset.Zero)
			{
				return "UTC";
			}
			return "UTC" + OffsetPattern.GeneralInvariant.Format(offset);
		}

		internal static DateTimeZone GetFixedZoneOrNull(string id)
		{
			if (!id.StartsWith("UTC"))
			{
				return null;
			}
			if (id == "UTC")
			{
				return DateTimeZone.Utc;
			}
			ParseResult<Offset> parseResult = OffsetPattern.GeneralInvariant.Parse(id.Substring("UTC".Length));
			if (!parseResult.Success)
			{
				return null;
			}
			return DateTimeZone.ForOffset(parseResult.Value);
		}

		public override ZoneInterval GetZoneInterval(Instant instant)
		{
			return interval;
		}

		public override ZoneLocalMapping MapLocal(LocalDateTime localDateTime)
		{
			return new ZoneLocalMapping(this, localDateTime, interval, interval, 1);
		}

		public override Offset GetUtcOffset(Instant instant)
		{
			return base.MaxOffset;
		}

		internal void Write([NotNull] IDateTimeZoneWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteOffset(Offset);
			writer.WriteString(Name);
		}

		public static DateTimeZone Read([NotNull] IDateTimeZoneReader reader, [NotNull] string id)
		{
			Preconditions.CheckNotNull(reader, "reader");
			Preconditions.CheckNotNull(id, "id");
			Offset offset = reader.ReadOffset();
			string name = (reader.HasMoreData ? reader.ReadString() : id);
			return new FixedDateTimeZone(id, offset, name);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as FixedDateTimeZone);
		}

		public bool Equals(FixedDateTimeZone other)
		{
			if (other != null && Offset == other.Offset && base.Id == other.Id)
			{
				return Name == other.Name;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(Offset, base.Id, Name);
		}

		public override string ToString()
		{
			return base.Id;
		}
	}
	public interface IDateTimeZoneSource
	{
		[NotNull]
		string VersionId { get; }

		[NotNull]
		IEnumerable<string> GetIds();

		[NotNull]
		DateTimeZone ForId([NotNull] string id);

		[CanBeNull]
		string GetSystemDefaultId();
	}
	[Mutable]
	public sealed class InvalidDateTimeZoneSourceException : Exception
	{
		public InvalidDateTimeZoneSourceException(string message)
			: base(message)
		{
		}
	}
	internal interface IZoneIntervalMap
	{
		ZoneInterval GetZoneInterval(Instant instant);
	}
	internal interface IZoneIntervalMapWithMinMax : IZoneIntervalMap
	{
		Offset MinOffset { get; }

		Offset MaxOffset { get; }
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	internal sealed class PartialZoneIntervalMap
	{
		private class CombinedPartialZoneIntervalMap : IZoneIntervalMap
		{
			private readonly PartialZoneIntervalMap[] partialMaps;

			internal CombinedPartialZoneIntervalMap(PartialZoneIntervalMap[] partialMaps)
			{
				this.partialMaps = partialMaps;
			}

			public ZoneInterval GetZoneInterval(Instant instant)
			{
				PartialZoneIntervalMap[] array = partialMaps;
				foreach (PartialZoneIntervalMap partialZoneIntervalMap in array)
				{
					if (instant < partialZoneIntervalMap.End)
					{
						return partialZoneIntervalMap.GetZoneInterval(instant);
					}
				}
				throw new InvalidOperationException("Instant not contained in any map");
			}
		}

		private readonly IZoneIntervalMap map;

		internal Instant Start { get; }

		internal Instant End { get; }

		private bool IsSingleInterval => map.GetZoneInterval(Start).RawEnd >= End;

		internal PartialZoneIntervalMap(Instant start, Instant end, IZoneIntervalMap map)
		{
			Start = start;
			End = end;
			this.map = map;
		}

		internal static PartialZoneIntervalMap ForZoneInterval(string name, Instant start, Instant end, Offset wallOffset, Offset savings)
		{
			return ForZoneInterval(new ZoneInterval(name, start, end, wallOffset, savings));
		}

		internal static PartialZoneIntervalMap ForZoneInterval(ZoneInterval interval)
		{
			return new PartialZoneIntervalMap(interval.RawStart, interval.RawEnd, new SingleZoneIntervalMap(interval));
		}

		internal ZoneInterval GetZoneInterval(Instant instant)
		{
			ZoneInterval zoneInterval = map.GetZoneInterval(instant);
			if (zoneInterval.RawStart < Start)
			{
				zoneInterval = zoneInterval.WithStart(Start);
			}
			if (zoneInterval.RawEnd > End)
			{
				zoneInterval = zoneInterval.WithEnd(End);
			}
			return zoneInterval;
		}

		internal PartialZoneIntervalMap WithStart(Instant start)
		{
			return new PartialZoneIntervalMap(start, End, map);
		}

		internal PartialZoneIntervalMap WithEnd(Instant end)
		{
			return new PartialZoneIntervalMap(Start, end, map);
		}

		internal static IZoneIntervalMap ConvertToFullMap(IEnumerable<PartialZoneIntervalMap> maps)
		{
			List<PartialZoneIntervalMap> list = new List<PartialZoneIntervalMap>();
			PartialZoneIntervalMap partialZoneIntervalMap = null;
			foreach (PartialZoneIntervalMap map in maps)
			{
				if (partialZoneIntervalMap == null)
				{
					partialZoneIntervalMap = map;
				}
				else if (!(map.Start == map.End))
				{
					ZoneInterval zoneInterval = partialZoneIntervalMap.GetZoneInterval(partialZoneIntervalMap.End - Duration.Epsilon);
					ZoneInterval zoneInterval2 = map.GetZoneInterval(map.Start);
					if (!zoneInterval.EqualIgnoreBounds(zoneInterval2))
					{
						list.Add(partialZoneIntervalMap);
						partialZoneIntervalMap = map;
					}
					else if (partialZoneIntervalMap.IsSingleInterval && map.IsSingleInterval)
					{
						partialZoneIntervalMap = ForZoneInterval(zoneInterval.WithEnd(map.End));
					}
					else if (partialZoneIntervalMap.IsSingleInterval)
					{
						list.Add(ForZoneInterval(zoneInterval.WithEnd(zoneInterval2.End)));
						partialZoneIntervalMap = map.WithStart(zoneInterval2.End);
					}
					else if (map.IsSingleInterval)
					{
						list.Add(partialZoneIntervalMap.WithEnd(zoneInterval.Start));
						partialZoneIntervalMap = ForZoneInterval(zoneInterval2.WithStart(zoneInterval.Start));
					}
					else
					{
						list.Add(partialZoneIntervalMap.WithEnd(zoneInterval.Start));
						list.Add(ForZoneInterval(zoneInterval.WithEnd(zoneInterval2.End)));
						partialZoneIntervalMap = map.WithStart(zoneInterval2.End);
					}
				}
			}
			list.Add(partialZoneIntervalMap);
			return new CombinedPartialZoneIntervalMap(list.ToArray());
		}
	}
	internal sealed class PrecalculatedDateTimeZone : DateTimeZone
	{
		private delegate Offset OffsetAggregator(Offset x, Offset y);

		private delegate Offset OffsetExtractor<in T>(T input);

		private readonly ZoneInterval[] periods;

		private readonly IZoneIntervalMapWithMinMax tailZone;

		private readonly Instant tailZoneStart;

		private readonly ZoneInterval firstTailZoneInterval;

		[VisibleForTesting]
		internal PrecalculatedDateTimeZone([NotNull] string id, [NotNull] ZoneInterval[] intervals, IZoneIntervalMapWithMinMax tailZone)
			: base(id, isFixed: false, ComputeOffset(intervals, tailZone, Offset.Min), ComputeOffset(intervals, tailZone, Offset.Max))
		{
			periods = intervals;
			this.tailZone = tailZone;
			tailZoneStart = intervals[checked(intervals.Length - 1)].RawEnd;
			if (tailZone != null)
			{
				firstTailZoneInterval = tailZone.GetZoneInterval(tailZoneStart).WithStart(tailZoneStart);
			}
			ValidatePeriods(intervals, tailZone);
		}

		internal static void ValidatePeriods(ZoneInterval[] periods, IZoneIntervalMap tailZone)
		{
			Preconditions.CheckArgument(periods.Length != 0, "periods", "No periods specified in precalculated time zone");
			Preconditions.CheckArgument(!periods[0].HasStart, "periods", "Periods in precalculated time zone must start with the beginning of time");
			checked
			{
				for (int i = 0; i < periods.Length - 1; i++)
				{
					Preconditions.CheckArgument(periods[i].End == periods[i + 1].Start, "periods", "Non-adjoining ZoneIntervals for precalculated time zone");
				}
				Preconditions.CheckArgument(tailZone != null || periods[periods.Length - 1].RawEnd == Instant.AfterMaxValue, "tailZone", "Null tail zone given but periods don't cover all of time");
			}
		}

		public override ZoneInterval GetZoneInterval(Instant instant)
		{
			if (tailZone != null && instant >= tailZoneStart)
			{
				ZoneInterval zoneInterval = tailZone.GetZoneInterval(instant);
				if (!(zoneInterval.RawStart < tailZoneStart))
				{
					return zoneInterval;
				}
				return firstTailZoneInterval;
			}
			int num = 0;
			int num2 = periods.Length;
			while (num < num2)
			{
				int num3 = checked(num + num2) / 2;
				ZoneInterval zoneInterval2 = periods[num3];
				if (zoneInterval2.RawStart > instant)
				{
					num2 = num3;
					continue;
				}
				if (zoneInterval2.RawEnd <= instant)
				{
					num = checked(num3 + 1);
					continue;
				}
				return zoneInterval2;
			}
			throw new InvalidOperationException($"Instant {instant} did not exist in time zone {base.Id}");
		}

		internal void Write([NotNull] IDateTimeZoneWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteCount(periods.Length);
			Instant? instant = null;
			ZoneInterval[] array = periods;
			foreach (ZoneInterval zoneInterval in array)
			{
				Instant? previous = instant;
				instant = zoneInterval.RawStart;
				Instant? instant2 = instant;
				writer.WriteZoneIntervalTransition(previous, instant2.Value);
				writer.WriteString(zoneInterval.Name);
				writer.WriteOffset(zoneInterval.WallOffset);
				writer.WriteOffset(zoneInterval.Savings);
			}
			writer.WriteZoneIntervalTransition(instant, tailZoneStart);
			writer.WriteByte(checked((byte)((tailZone != null) ? 1 : 0)));
			if (tailZone != null)
			{
				((StandardDaylightAlternatingMap)tailZone).Write(writer);
			}
		}

		internal static DateTimeZone Read([Trusted][NotNull] IDateTimeZoneReader reader, [Trusted][NotNull] string id)
		{
			int num = reader.ReadCount();
			ZoneInterval[] array = new ZoneInterval[num];
			Instant instant = reader.ReadZoneIntervalTransition(null);
			for (int i = 0; i < num; i = checked(i + 1))
			{
				string name = reader.ReadString();
				Offset wallOffset = reader.ReadOffset();
				Offset savings = reader.ReadOffset();
				Instant instant2 = reader.ReadZoneIntervalTransition(instant);
				array[i] = new ZoneInterval(name, instant, instant2, wallOffset, savings);
				instant = instant2;
			}
			StandardDaylightAlternatingMap standardDaylightAlternatingMap = ((reader.ReadByte() == 1) ? StandardDaylightAlternatingMap.Read(reader) : null);
			return new PrecalculatedDateTimeZone(id, array, standardDaylightAlternatingMap);
		}

		private static Offset ComputeOffset([NotNull] ZoneInterval[] intervals, IZoneIntervalMapWithMinMax tailZone, OffsetAggregator aggregator)
		{
			Preconditions.CheckNotNull(intervals, "intervals");
			Preconditions.CheckArgument(intervals.Length != 0, "intervals", "No intervals specified");
			Offset offset = intervals[0].WallOffset;
			for (int i = 1; i < intervals.Length; i = checked(i + 1))
			{
				offset = aggregator(offset, intervals[i].WallOffset);
			}
			if (tailZone != null)
			{
				Offset y = aggregator(tailZone.MinOffset, tailZone.MaxOffset);
				offset = aggregator(offset, y);
			}
			return offset;
		}
	}
	public static class Resolvers
	{
		[NotNull]
		public static AmbiguousTimeResolver ReturnEarlier { get; } = (ZonedDateTime earlier, ZonedDateTime later) => earlier;

		[NotNull]
		public static AmbiguousTimeResolver ReturnLater { get; } = (ZonedDateTime earlier, ZonedDateTime later) => later;

		[NotNull]
		public static AmbiguousTimeResolver ThrowWhenAmbiguous { get; } = delegate(ZonedDateTime earlier, ZonedDateTime later)
		{
			throw new AmbiguousTimeException(earlier, later);
		};

		[NotNull]
		public static SkippedTimeResolver ReturnEndOfIntervalBefore { get; } = delegate(LocalDateTime local, DateTimeZone zone, ZoneInterval before, ZoneInterval after)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(before, "before");
			Preconditions.CheckNotNull(after, "after");
			return new ZonedDateTime(before.End - Duration.Epsilon, zone, local.Calendar);
		};

		[NotNull]
		public static SkippedTimeResolver ReturnStartOfIntervalAfter { get; } = delegate(LocalDateTime local, DateTimeZone zone, ZoneInterval before, ZoneInterval after)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(before, "before");
			Preconditions.CheckNotNull(after, "after");
			return new ZonedDateTime(after.Start, zone, local.Calendar);
		};

		[NotNull]
		public static SkippedTimeResolver ReturnForwardShifted { get; } = delegate(LocalDateTime local, DateTimeZone zone, ZoneInterval before, ZoneInterval after)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(before, "before");
			Preconditions.CheckNotNull(after, "after");
			return new ZonedDateTime(new OffsetDateTime(local, before.WallOffset).WithOffset(after.WallOffset), zone);
		};

		[NotNull]
		public static SkippedTimeResolver ThrowWhenSkipped { get; } = delegate(LocalDateTime local, DateTimeZone zone, ZoneInterval before, ZoneInterval after)
		{
			Preconditions.CheckNotNull(zone, "zone");
			Preconditions.CheckNotNull(before, "before");
			Preconditions.CheckNotNull(after, "after");
			throw new SkippedTimeException(local, zone);
		};

		[NotNull]
		public static ZoneLocalMappingResolver StrictResolver { get; } = CreateMappingResolver(ThrowWhenAmbiguous, ThrowWhenSkipped);

		[NotNull]
		public static ZoneLocalMappingResolver LenientResolver { get; } = CreateMappingResolver(ReturnEarlier, ReturnForwardShifted);

		[NotNull]
		public static ZoneLocalMappingResolver CreateMappingResolver([NotNull] AmbiguousTimeResolver ambiguousTimeResolver, [NotNull] SkippedTimeResolver skippedTimeResolver)
		{
			Preconditions.CheckNotNull(ambiguousTimeResolver, "ambiguousTimeResolver");
			Preconditions.CheckNotNull(skippedTimeResolver, "skippedTimeResolver");
			return delegate(ZoneLocalMapping mapping)
			{
				Preconditions.CheckNotNull(mapping, "mapping");
				return mapping.Count switch
				{
					0 => skippedTimeResolver(mapping.LocalDateTime, mapping.Zone, mapping.EarlyInterval, mapping.LateInterval), 
					1 => mapping.First(), 
					2 => ambiguousTimeResolver(mapping.First(), mapping.Last()), 
					_ => throw new InvalidOperationException("Mapping has count outside range 0-2; should not happen."), 
				};
			};
		}
	}
	internal sealed class SingleZoneIntervalMap : IZoneIntervalMap
	{
		private readonly ZoneInterval interval;

		internal SingleZoneIntervalMap(ZoneInterval interval)
		{
			this.interval = interval;
		}

		public ZoneInterval GetZoneInterval(Instant instant)
		{
			return interval;
		}
	}
	internal sealed class StandardDaylightAlternatingMap : IEquatable<StandardDaylightAlternatingMap>, IZoneIntervalMapWithMinMax, IZoneIntervalMap
	{
		private readonly Offset standardOffset;

		private readonly ZoneRecurrence standardRecurrence;

		private readonly ZoneRecurrence dstRecurrence;

		public Offset MinOffset => Offset.Min(standardOffset, standardOffset + dstRecurrence.Savings);

		public Offset MaxOffset => Offset.Max(standardOffset, standardOffset + dstRecurrence.Savings);

		internal StandardDaylightAlternatingMap(Offset standardOffset, ZoneRecurrence startRecurrence, ZoneRecurrence endRecurrence)
		{
			this.standardOffset = standardOffset;
			startRecurrence = startRecurrence.ToStartOfTime();
			endRecurrence = endRecurrence.ToStartOfTime();
			Preconditions.CheckArgument(startRecurrence.IsInfinite, "startRecurrence", "Start recurrence must extend to the end of time");
			Preconditions.CheckArgument(endRecurrence.IsInfinite, "endRecurrence", "End recurrence must extend to the end of time");
			ZoneRecurrence zoneRecurrence = startRecurrence;
			ZoneRecurrence zoneRecurrence2 = endRecurrence;
			if (startRecurrence.Savings == Offset.Zero)
			{
				zoneRecurrence = endRecurrence;
				zoneRecurrence2 = startRecurrence;
			}
			Preconditions.CheckArgument(zoneRecurrence2.Savings == Offset.Zero, "startRecurrence", "At least one recurrence must not have savings applied");
			dstRecurrence = zoneRecurrence;
			standardRecurrence = zoneRecurrence2;
		}

		public override bool Equals(object other)
		{
			return Equals(other as StandardDaylightAlternatingMap);
		}

		public bool Equals(StandardDaylightAlternatingMap other)
		{
			if (other != null && standardOffset == other.standardOffset && dstRecurrence.Equals(other.dstRecurrence))
			{
				return standardRecurrence.Equals(other.standardRecurrence);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Initialize().Hash(standardOffset).Hash(dstRecurrence)
				.Hash(standardRecurrence)
				.Value;
		}

		public ZoneInterval GetZoneInterval(Instant instant)
		{
			ZoneRecurrence recurrence;
			Transition transition = NextTransition(instant, out recurrence);
			Offset previousSavings = ((recurrence == standardRecurrence) ? dstRecurrence.Savings : Offset.Zero);
			Transition transition2 = recurrence.PreviousOrSameOrFail(instant, standardOffset, previousSavings);
			return new ZoneInterval(recurrence.Name, transition2.Instant, transition.Instant, standardOffset + recurrence.Savings, recurrence.Savings);
		}

		private Transition NextTransition(Instant instant, out ZoneRecurrence recurrence)
		{
			Transition result = dstRecurrence.NextOrFail(instant, standardOffset, Offset.Zero);
			Transition result2 = standardRecurrence.NextOrFail(instant, standardOffset, dstRecurrence.Savings);
			Instant instant2 = result2.Instant;
			Instant instant3 = result.Instant;
			if (instant2 < instant3)
			{
				recurrence = dstRecurrence;
				return result2;
			}
			if (instant2 > instant3)
			{
				recurrence = standardRecurrence;
				return result;
			}
			if (instant2.IsValid)
			{
				throw new InvalidOperationException("Zone recurrence rules have identical transitions. This time zone is broken.");
			}
			Transition transition = dstRecurrence.PreviousOrSameOrFail(instant, standardOffset, Offset.Zero);
			Transition transition2 = standardRecurrence.PreviousOrSameOrFail(instant, standardOffset, dstRecurrence.Savings);
			if (transition.Instant > transition2.Instant)
			{
				recurrence = dstRecurrence;
				return result2;
			}
			recurrence = standardRecurrence;
			return result;
		}

		internal void Write([NotNull] IDateTimeZoneWriter writer)
		{
			Preconditions.CheckNotNull(writer, "writer");
			writer.WriteOffset(standardOffset);
			writer.WriteString(standardRecurrence.Name);
			standardRecurrence.YearOffset.Write(writer);
			writer.WriteString(dstRecurrence.Name);
			dstRecurrence.YearOffset.Write(writer);
			writer.WriteOffset(dstRecurrence.Savings);
		}

		internal static StandardDaylightAlternatingMap Read([NotNull] IDateTimeZoneReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			Offset offset = reader.ReadOffset();
			string name = reader.ReadString();
			ZoneYearOffset yearOffset = ZoneYearOffset.Read(reader);
			string name2 = reader.ReadString();
			ZoneYearOffset yearOffset2 = ZoneYearOffset.Read(reader);
			Offset savings = reader.ReadOffset();
			ZoneRecurrence startRecurrence = new ZoneRecurrence(name, Offset.Zero, yearOffset, -2147483648, 2147483647);
			ZoneRecurrence endRecurrence = new ZoneRecurrence(name2, savings, yearOffset2, -2147483648, 2147483647);
			return new StandardDaylightAlternatingMap(offset, startRecurrence, endRecurrence);
		}
	}
	internal static class TimeZoneInfoInterceptor
	{
		internal interface ITimeZoneInfoShim
		{
			TimeZoneInfo Local { get; }

			TimeZoneInfo FindSystemTimeZoneById(string id);

			ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();
		}

		private class BclShim : ITimeZoneInfoShim
		{
			public TimeZoneInfo Local => TimeZoneInfo.Local;

			public TimeZoneInfo FindSystemTimeZoneById(string id)
			{
				return TimeZoneInfo.FindSystemTimeZoneById(id);
			}

			public ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
			{
				return TimeZoneInfo.GetSystemTimeZones();
			}
		}

		internal static ITimeZoneInfoShim Shim { get; set; } = new BclShim();

		internal static TimeZoneInfo Local => Shim.Local;

		internal static TimeZoneInfo FindSystemTimeZoneById(string id)
		{
			return Shim.FindSystemTimeZoneById(id);
		}

		internal static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
		{
			return Shim.GetSystemTimeZones();
		}
	}
	internal struct Transition : IEquatable<Transition>
	{
		internal Instant Instant { get; }

		internal Offset NewOffset { get; }

		internal Transition(Instant instant, Offset newOffset)
		{
			this = default(Transition);
			Instant = instant;
			NewOffset = newOffset;
		}

		public bool Equals(Transition other)
		{
			if (Instant == other.Instant)
			{
				return NewOffset == other.NewOffset;
			}
			return false;
		}

		public static bool operator ==(Transition left, Transition right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Transition left, Transition right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (obj is Transition)
			{
				return Equals((Transition)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (23 * 31 + Instant.GetHashCode()) * 31 + NewOffset.GetHashCode();
		}

		public override string ToString()
		{
			return string.Concat("Transition to ", NewOffset, " at ", Instant);
		}
	}
	internal enum TransitionMode
	{
		Utc,
		Wall,
		Standard
	}
	[Immutable]
	public sealed class TzdbDateTimeZoneSource : IDateTimeZoneSource
	{
		private static class DefaultHolder
		{
			internal static readonly TzdbDateTimeZoneSource builtin;

			static DefaultHolder()
			{
				builtin = new TzdbDateTimeZoneSource(LoadDefaultDataSource());
			}

			private static TzdbStreamData LoadDefaultDataSource()
			{
				using Stream stream = typeof(DefaultHolder).GetTypeInfo().Assembly.GetManifestResourceStream("NodaTime.TimeZones.Tzdb.nzd");
				return TzdbStreamData.FromStream(stream);
			}
		}

		private readonly TzdbStreamData source;

		private readonly string version;

		private readonly ConcurrentDictionary<string, string> guesses = new ConcurrentDictionary<string, string>();

		[NotNull]
		public static TzdbDateTimeZoneSource Default => DefaultHolder.builtin;

		[NotNull]
		public ILookup<string, string> Aliases { get; }

		[NotNull]
		public IDictionary<string, string> CanonicalIdMap { get; }

		[CanBeNull]
		public IList<TzdbZoneLocation> ZoneLocations { get; }

		[CanBeNull]
		public IList<TzdbZone1970Location> Zone1970Locations { get; }

		[NotNull]
		public string VersionId => "TZDB: " + version;

		[NotNull]
		public string TzdbVersion => source.TzdbVersion;

		[NotNull]
		public WindowsZones WindowsMapping => source.WindowsMapping;

		[NotNull]
		public static TzdbDateTimeZoneSource FromStream([NotNull] Stream stream)
		{
			Preconditions.CheckNotNull(stream, "stream");
			return new TzdbDateTimeZoneSource(TzdbStreamData.FromStream(stream));
		}

		private TzdbDateTimeZoneSource([NotNull] TzdbStreamData source)
		{
			Preconditions.CheckNotNull(source, "source");
			this.source = source;
			CanonicalIdMap = new NodaReadOnlyDictionary<string, string>(source.TzdbIdMap);
			Aliases = CanonicalIdMap.Where((KeyValuePair<string, string> pair) => pair.Key != pair.Value).OrderBy((KeyValuePair<string, string> pair) => pair.Key, StringComparer.Ordinal).ToLookup((KeyValuePair<string, string> pair) => pair.Value, (KeyValuePair<string, string> pair) => pair.Key);
			version = source.TzdbVersion + " (mapping: " + source.WindowsMapping.Version + ")";
			IList<TzdbZoneLocation> zoneLocations = source.ZoneLocations;
			ZoneLocations = ((zoneLocations == null) ? null : new ReadOnlyCollection<TzdbZoneLocation>(zoneLocations));
			IList<TzdbZone1970Location> zone1970Locations = source.Zone1970Locations;
			Zone1970Locations = ((zone1970Locations == null) ? null : new ReadOnlyCollection<TzdbZone1970Location>(zone1970Locations));
		}

		[NotNull]
		public DateTimeZone ForId([NotNull] string id)
		{
			if (!CanonicalIdMap.TryGetValue(Preconditions.CheckNotNull(id, "id"), out var value))
			{
				throw new ArgumentException("Time zone with ID " + id + " not found in source " + version, "id");
			}
			return source.CreateZone(id, value);
		}

		[DebuggerStepThrough]
		[NotNull]
		public IEnumerable<string> GetIds()
		{
			return CanonicalIdMap.Keys;
		}

		[CanBeNull]
		public string GetSystemDefaultId()
		{
			return MapTimeZoneInfoId(TimeZoneInfoInterceptor.Local);
		}

		[VisibleForTesting]
		[CanBeNull]
		internal string MapTimeZoneInfoId([CanBeNull] TimeZoneInfo timeZone)
		{
			if (timeZone == null)
			{
				return null;
			}
			string id = timeZone.Id;
			if (source.WindowsMapping.PrimaryMapping.TryGetValue(id, out var value))
			{
				return value;
			}
			if (CanonicalIdMap.Keys.Contains(id))
			{
				return id;
			}
			return GuessZoneIdByTransitions(timeZone);
		}

		private string GuessZoneIdByTransitions(TimeZoneInfo zone)
		{
			return guesses.GetOrAdd(zone.StandardName, delegate
			{
				List<DateTimeZone> candidates = CanonicalIdMap.Values.Select(ForId).ToList();
				return GuessZoneIdByTransitionsUncached(zone, candidates);
			});
		}

		internal string GuessZoneIdByTransitionsUncached(TimeZoneInfo zone, List<DateTimeZone> candidates)
		{
			int year = SystemClock.Instance.GetCurrentInstant().InUtc().Year;
			Instant startOfThisYear = Instant.FromUtc(year, 1, 1, 0, 0);
			Instant startOfNextYear = Instant.FromUtc(checked(year + 5), 1, 1, 0, 0);
			List<Instant> list = (from zi in candidates.SelectMany((DateTimeZone z) => z.GetZoneIntervals(startOfThisYear, startOfNextYear))
				select Instant.Max(zi.RawStart, startOfThisYear)).Distinct().ToList();
			List<Offset> list2 = list.Select((Instant instant) => Offset.FromTimeSpan(zone.GetUtcOffset(instant.ToDateTimeUtc()))).ToList();
			int num = checked(list.Count * 30) / 100;
			DateTimeZone dateTimeZone = null;
			checked
			{
				foreach (DateTimeZone candidate in candidates)
				{
					int num2 = 0;
					for (int num3 = 0; num3 < list.Count; num3++)
					{
						if (candidate.GetUtcOffset(list[num3]) != list2[num3])
						{
							num2++;
							if (num2 == num)
							{
								break;
							}
						}
					}
					if (num2 < num)
					{
						num = num2;
						dateTimeZone = candidate;
					}
				}
				return dateTimeZone?.Id;
			}
		}

		public void Validate()
		{
			foreach (KeyValuePair<string, string> item in CanonicalIdMap)
			{
				if (!CanonicalIdMap.TryGetValue(item.Value, out var value))
				{
					throw new InvalidNodaDataException("Mapping for entry {entry.Key} ({entry.Value}) is missing");
				}
				if (item.Value != value)
				{
					throw new InvalidNodaDataException("Mapping for entry {entry.Key} ({entry.Value}) is not canonical ({entry.Value} maps to {canonical}");
				}
			}
			foreach (MapZone mapZone in source.WindowsMapping.MapZones)
			{
				if (!source.WindowsMapping.PrimaryMapping.ContainsKey(mapZone.WindowsId))
				{
					throw new InvalidNodaDataException($"Windows mapping for standard ID {mapZone.WindowsId} has no primary territory");
				}
			}
			foreach (MapZone mapZone2 in source.WindowsMapping.MapZones)
			{
				foreach (string tzdbId in mapZone2.TzdbIds)
				{
					if (!CanonicalIdMap.ContainsKey(tzdbId))
					{
						throw new InvalidNodaDataException($"Windows mapping uses canonical ID {tzdbId} which is missing");
					}
				}
			}
			if (ZoneLocations != null)
			{
				foreach (TzdbZoneLocation zoneLocation in ZoneLocations)
				{
					if (!CanonicalIdMap.ContainsKey(zoneLocation.ZoneId))
					{
						throw new InvalidNodaDataException($"Zone location {zoneLocation.CountryName} uses zone ID {zoneLocation.ZoneId} which is missing");
					}
				}
			}
			if (Zone1970Locations == null)
			{
				return;
			}
			foreach (TzdbZone1970Location zone1970Location in Zone1970Locations)
			{
				if (!CanonicalIdMap.ContainsKey(zone1970Location.ZoneId))
				{
					throw new InvalidNodaDataException($"Zone 1970 location {zone1970Location.Countries[0].Name} uses zone ID {zone1970Location.ZoneId} which is missing");
				}
			}
		}
	}
	[Immutable]
	public sealed class TzdbZone1970Location
	{
		[Immutable]
		public sealed class Country : IEquatable<Country>
		{
			[NotNull]
			public string Name { get; }

			[NotNull]
			public string Code { get; }

			public Country([NotNull] string name, [NotNull] string code)
			{
				Name = Preconditions.CheckNotNull(name, "name");
				Code = Preconditions.CheckNotNull(code, "code");
				Preconditions.CheckArgument(Name.Length > 0, "name", "Country name cannot be empty");
				Preconditions.CheckArgument(Code.Length == 2, "code", "Country code must be two characters");
			}

			public bool Equals(Country other)
			{
				if (other != null && other.Code == Code)
				{
					return other.Name == Name;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				return Equals(obj as Country);
			}

			public override int GetHashCode()
			{
				return HashCodeHelper.Hash(Name, Code);
			}

			public override string ToString()
			{
				return $"{Code} ({Name})";
			}
		}

		private readonly int latitudeSeconds;

		private readonly int longitudeSeconds;

		public double Latitude => (double)latitudeSeconds / 3600.0;

		public double Longitude => (double)longitudeSeconds / 3600.0;

		[NotNull]
		public IList<Country> Countries { get; }

		[NotNull]
		public string ZoneId { get; }

		[NotNull]
		public string Comment { get; }

		public TzdbZone1970Location(int latitudeSeconds, int longitudeSeconds, [NotNull] IEnumerable<Country> countries, [NotNull] string zoneId, [NotNull] string comment)
		{
			Preconditions.CheckArgumentRange("latitudeSeconds", latitudeSeconds, -324000, 324000);
			Preconditions.CheckArgumentRange("longitudeSeconds", longitudeSeconds, -648000, 648000);
			this.latitudeSeconds = latitudeSeconds;
			this.longitudeSeconds = longitudeSeconds;
			Countries = new ReadOnlyCollection<Country>(Preconditions.CheckNotNull(countries, "countries").ToList());
			Preconditions.CheckArgument(Countries.Count > 0, "countries", "Collection must contain at least one entry");
			foreach (Country country in Countries)
			{
				Preconditions.CheckArgument(country != null, "countries", "Collection must not contain null entries");
			}
			ZoneId = Preconditions.CheckNotNull(zoneId, "zoneId");
			Comment = Preconditions.CheckNotNull(comment, "comment");
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			writer.WriteSignedCount(latitudeSeconds);
			writer.WriteSignedCount(longitudeSeconds);
			writer.WriteCount(Countries.Count);
			foreach (Country country in Countries)
			{
				writer.WriteString(country.Name);
				writer.WriteString(country.Code);
			}
			writer.WriteString(ZoneId);
			writer.WriteString(Comment);
		}

		internal static TzdbZone1970Location Read(IDateTimeZoneReader reader)
		{
			int num = reader.ReadSignedCount();
			int num2 = reader.ReadSignedCount();
			int num3 = reader.ReadCount();
			List<Country> list = new List<Country>();
			for (int i = 0; i < num3; i = checked(i + 1))
			{
				string name = reader.ReadString();
				string text = reader.ReadString();
				string code = text;
				list.Add(new Country(name, code));
			}
			string zoneId = reader.ReadString();
			string comment = reader.ReadString();
			try
			{
				return new TzdbZone1970Location(num, num2, list, zoneId, comment);
			}
			catch (ArgumentException innerException)
			{
				throw new InvalidNodaDataException("Invalid zone location data in stream", innerException);
			}
		}
	}
	[Immutable]
	public sealed class TzdbZoneLocation
	{
		private readonly int latitudeSeconds;

		private readonly int longitudeSeconds;

		public double Latitude => (double)latitudeSeconds / 3600.0;

		public double Longitude => (double)longitudeSeconds / 3600.0;

		[NotNull]
		public string CountryName { get; }

		[NotNull]
		public string CountryCode { get; }

		[NotNull]
		public string ZoneId { get; }

		[NotNull]
		public string Comment { get; }

		public TzdbZoneLocation(int latitudeSeconds, int longitudeSeconds, [NotNull] string countryName, [NotNull] string countryCode, [NotNull] string zoneId, [NotNull] string comment)
		{
			Preconditions.CheckArgumentRange("latitudeSeconds", latitudeSeconds, -324000, 324000);
			Preconditions.CheckArgumentRange("longitudeSeconds", longitudeSeconds, -648000, 648000);
			this.latitudeSeconds = latitudeSeconds;
			this.longitudeSeconds = longitudeSeconds;
			CountryName = Preconditions.CheckNotNull(countryName, "countryName");
			CountryCode = Preconditions.CheckNotNull(countryCode, "countryCode");
			Preconditions.CheckArgument(CountryName.Length > 0, "countryName", "Country name cannot be empty");
			Preconditions.CheckArgument(CountryCode.Length == 2, "countryCode", "Country code must be two characters");
			ZoneId = Preconditions.CheckNotNull(zoneId, "zoneId");
			Comment = Preconditions.CheckNotNull(comment, "comment");
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			writer.WriteSignedCount(latitudeSeconds);
			writer.WriteSignedCount(longitudeSeconds);
			writer.WriteString(CountryName);
			writer.WriteString(CountryCode);
			writer.WriteString(ZoneId);
			writer.WriteString(Comment);
		}

		internal static TzdbZoneLocation Read(IDateTimeZoneReader reader)
		{
			int num = reader.ReadSignedCount();
			int num2 = reader.ReadSignedCount();
			string countryName = reader.ReadString();
			string countryCode = reader.ReadString();
			string zoneId = reader.ReadString();
			string comment = reader.ReadString();
			try
			{
				return new TzdbZoneLocation(num, num2, countryName, countryCode, zoneId, comment);
			}
			catch (ArgumentException innerException)
			{
				throw new InvalidNodaDataException("Invalid zone location data in stream", innerException);
			}
		}
	}
	[Immutable]
	public sealed class ZoneEqualityComparer : IEqualityComparer<DateTimeZone>
	{
		[Flags]
		public enum Options
		{
			OnlyMatchWallOffset = 0,
			MatchOffsetComponents = 1,
			MatchNames = 2,
			MatchAllTransitions = 4,
			MatchStartAndEndTransitions = 8,
			StrictestMatch = 0xF
		}

		internal sealed class ZoneIntervalEqualityComparer : IEqualityComparer<ZoneInterval>
		{
			private readonly Options options;

			private readonly Interval interval;

			internal ZoneIntervalEqualityComparer(Options options, Interval interval)
			{
				this.options = options;
				this.interval = interval;
			}

			internal IEnumerable<ZoneInterval> CoalesceIntervals(IEnumerable<ZoneInterval> zoneIntervals)
			{
				ZoneInterval zoneInterval = null;
				foreach (ZoneInterval zoneInterval2 in zoneIntervals)
				{
					if (zoneInterval == null)
					{
						zoneInterval = zoneInterval2;
						continue;
					}
					if (EqualExceptStartAndEnd(zoneInterval, zoneInterval2))
					{
						zoneInterval = zoneInterval.WithEnd(zoneInterval2.RawEnd);
						continue;
					}
					yield return zoneInterval;
					zoneInterval = zoneInterval2;
				}
				if (zoneInterval != null)
				{
					yield return zoneInterval;
				}
			}

			public bool Equals(ZoneInterval x, ZoneInterval y)
			{
				if (!EqualExceptStartAndEnd(x, y))
				{
					return false;
				}
				if (GetEffectiveStart(x) == GetEffectiveStart(y))
				{
					return GetEffectiveEnd(x) == GetEffectiveEnd(y);
				}
				return false;
			}

			public int GetHashCode(ZoneInterval obj)
			{
				HashCodeHelper hashCodeHelper = HashCodeHelper.Initialize();
				hashCodeHelper = ((!CheckOption(options, Options.MatchOffsetComponents)) ? hashCodeHelper.Hash(obj.WallOffset) : hashCodeHelper.Hash(obj.StandardOffset).Hash(obj.Savings));
				if (CheckOption(options, Options.MatchNames))
				{
					hashCodeHelper = hashCodeHelper.Hash(obj.Name);
				}
				return hashCodeHelper.Hash(GetEffectiveStart(obj)).Hash(GetEffectiveEnd(obj)).Value;
			}

			private Instant GetEffectiveStart(ZoneInterval zoneInterval)
			{
				if (!CheckOption(options, Options.MatchStartAndEndTransitions))
				{
					return Instant.Max(zoneInterval.RawStart, interval.Start);
				}
				return zoneInterval.RawStart;
			}

			private Instant GetEffectiveEnd(ZoneInterval zoneInterval)
			{
				if (!CheckOption(options, Options.MatchStartAndEndTransitions))
				{
					return Instant.Min(zoneInterval.RawEnd, interval.End);
				}
				return zoneInterval.RawEnd;
			}

			private bool EqualExceptStartAndEnd(ZoneInterval x, ZoneInterval y)
			{
				if (x.WallOffset != y.WallOffset)
				{
					return false;
				}
				if (CheckOption(options, Options.MatchOffsetComponents) && x.Savings != y.Savings)
				{
					return false;
				}
				if (CheckOption(options, Options.MatchNames) && x.Name != y.Name)
				{
					return false;
				}
				return true;
			}
		}

		private readonly Interval interval;

		private readonly Options options;

		private readonly ZoneIntervalEqualityComparer zoneIntervalComparer;

		[VisibleForTesting]
		internal Interval IntervalForTest => interval;

		[VisibleForTesting]
		internal Options OptionsForTest => options;

		private static bool CheckOption(Options options, Options candidate)
		{
			return (options & candidate) != 0;
		}

		private ZoneEqualityComparer(Interval interval, Options options)
		{
			this.interval = interval;
			this.options = options;
			if ((options & ~Options.StrictestMatch) != Options.OnlyMatchWallOffset)
			{
				throw new ArgumentOutOfRangeException("options", $"The value {options} is not defined within ZoneEqualityComparer.Options");
			}
			zoneIntervalComparer = new ZoneIntervalEqualityComparer(options, interval);
		}

		[NotNull]
		public static ZoneEqualityComparer ForInterval(Interval interval)
		{
			Preconditions.CheckArgument(interval.HasStart && interval.HasEnd, "interval", "The interval must have both a start and an end.");
			return new ZoneEqualityComparer(interval, Options.OnlyMatchWallOffset);
		}

		[NotNull]
		public ZoneEqualityComparer WithOptions(Options options)
		{
			if (this.options != options)
			{
				return new ZoneEqualityComparer(interval, options);
			}
			return this;
		}

		public bool Equals(DateTimeZone x, DateTimeZone y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			return GetIntervals(x).SequenceEqual(GetIntervals(y), zoneIntervalComparer);
		}

		public int GetHashCode([NotNull] DateTimeZone obj)
		{
			Preconditions.CheckNotNull(obj, "obj");
			int num = 19;
			foreach (ZoneInterval interval in GetIntervals(obj))
			{
				num = num * 31 + zoneIntervalComparer.GetHashCode(interval);
			}
			return num;
		}

		private IEnumerable<ZoneInterval> GetIntervals(DateTimeZone zone)
		{
			IEnumerable<ZoneInterval> zoneIntervals = zone.GetZoneIntervals(interval.Start, interval.End);
			if (!CheckOption(options, Options.MatchAllTransitions))
			{
				return zoneIntervalComparer.CoalesceIntervals(zoneIntervals);
			}
			return zoneIntervals;
		}
	}
	[Immutable]
	public sealed class ZoneInterval : IEquatable<ZoneInterval>
	{
		private readonly LocalInstant localStart;

		private readonly LocalInstant localEnd;

		internal Instant RawStart { get; }

		internal Instant RawEnd { get; }

		public Offset StandardOffset
		{
			[DebuggerStepThrough]
			get
			{
				return WallOffset - Savings;
			}
		}

		public Duration Duration
		{
			[DebuggerStepThrough]
			get
			{
				return End - Start;
			}
		}

		public bool HasStart => RawStart.IsValid;

		public Instant End
		{
			[DebuggerStepThrough]
			get
			{
				Preconditions.CheckState(RawEnd.IsValid, "Zone interval extends to the end of time");
				return RawEnd;
			}
		}

		public bool HasEnd => RawEnd.IsValid;

		public LocalDateTime IsoLocalStart
		{
			[DebuggerStepThrough]
			get
			{
				return new LocalDateTime(Start.Plus(WallOffset));
			}
		}

		public LocalDateTime IsoLocalEnd
		{
			[DebuggerStepThrough]
			get
			{
				return new LocalDateTime(End.Plus(WallOffset));
			}
		}

		[NotNull]
		public string Name
		{
			[DebuggerStepThrough]
			get;
		}

		public Offset WallOffset
		{
			[DebuggerStepThrough]
			get;
		}

		public Offset Savings
		{
			[DebuggerStepThrough]
			get;
		}

		public Instant Start
		{
			[DebuggerStepThrough]
			get
			{
				Preconditions.CheckState(RawStart.IsValid, "Zone interval extends to the beginning of time");
				return RawStart;
			}
		}

		public ZoneInterval([NotNull] string name, Instant? start, Instant? end, Offset wallOffset, Offset savings)
			: this(name, start ?? Instant.BeforeMinValue, end ?? Instant.AfterMaxValue, wallOffset, savings)
		{
		}

		internal ZoneInterval([NotNull] string name, Instant start, Instant end, Offset wallOffset, Offset savings)
		{
			Preconditions.CheckNotNull(name, "name");
			Preconditions.CheckArgument(start < end, "start", "The start Instant must be less than the end Instant");
			Name = name;
			RawStart = start;
			RawEnd = end;
			WallOffset = wallOffset;
			Savings = savings;
			localStart = start.SafePlus(wallOffset);
			localEnd = end.SafePlus(wallOffset);
		}

		internal ZoneInterval WithStart(Instant newStart)
		{
			return new ZoneInterval(Name, newStart, RawEnd, WallOffset, Savings);
		}

		internal ZoneInterval WithEnd(Instant newEnd)
		{
			return new ZoneInterval(Name, RawStart, newEnd, WallOffset, Savings);
		}

		[DebuggerStepThrough]
		public bool Contains(Instant instant)
		{
			if (RawStart <= instant)
			{
				return instant < RawEnd;
			}
			return false;
		}

		[DebuggerStepThrough]
		internal bool Contains(LocalInstant localInstant)
		{
			if (localStart <= localInstant)
			{
				return localInstant < localEnd;
			}
			return false;
		}

		internal bool EqualIgnoreBounds([NotNull][Trusted] ZoneInterval other)
		{
			if (other.WallOffset == WallOffset && other.Savings == Savings)
			{
				return other.Name == Name;
			}
			return false;
		}

		[DebuggerStepThrough]
		public bool Equals(ZoneInterval other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (Name == other.Name && RawStart == other.RawStart && RawEnd == other.RawEnd && WallOffset == other.WallOffset)
			{
				return Savings == other.Savings;
			}
			return false;
		}

		[DebuggerStepThrough]
		public override bool Equals(object obj)
		{
			return Equals(obj as ZoneInterval);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Initialize().Hash(Name).Hash(RawStart)
				.Hash(RawEnd)
				.Hash(WallOffset)
				.Hash(Savings)
				.Value;
		}

		public override string ToString()
		{
			return $"{Name}: [{RawStart}, {RawEnd}) {WallOffset} ({Savings})";
		}
	}
	[Immutable]
	public sealed class ZoneLocalMapping
	{
		[NotNull]
		public DateTimeZone Zone { get; }

		public LocalDateTime LocalDateTime { get; }

		[NotNull]
		public ZoneInterval EarlyInterval { get; }

		[NotNull]
		public ZoneInterval LateInterval { get; }

		public int Count { get; }

		internal ZoneLocalMapping([Trusted][NotNull] DateTimeZone zone, LocalDateTime localDateTime, [Trusted][NotNull] ZoneInterval earlyInterval, [Trusted][NotNull] ZoneInterval lateInterval, int count)
		{
			Zone = zone;
			EarlyInterval = earlyInterval;
			LateInterval = lateInterval;
			LocalDateTime = localDateTime;
			Count = count;
		}

		public ZonedDateTime Single()
		{
			return Count switch
			{
				0 => throw new SkippedTimeException(LocalDateTime, Zone), 
				1 => BuildZonedDateTime(EarlyInterval), 
				2 => throw new AmbiguousTimeException(BuildZonedDateTime(EarlyInterval), BuildZonedDateTime(LateInterval)), 
				_ => throw new InvalidOperationException("Can't happen"), 
			};
		}

		public ZonedDateTime First()
		{
			switch (Count)
			{
			case 0:
				throw new SkippedTimeException(LocalDateTime, Zone);
			case 1:
			case 2:
				return BuildZonedDateTime(EarlyInterval);
			default:
				throw new InvalidOperationException("Can't happen");
			}
		}

		public ZonedDateTime Last()
		{
			return Count switch
			{
				0 => throw new SkippedTimeException(LocalDateTime, Zone), 
				1 => BuildZonedDateTime(EarlyInterval), 
				2 => BuildZonedDateTime(LateInterval), 
				_ => throw new InvalidOperationException("Can't happen"), 
			};
		}

		private ZonedDateTime BuildZonedDateTime(ZoneInterval interval)
		{
			return new ZonedDateTime(LocalDateTime.WithOffset(interval.WallOffset), Zone);
		}
	}
	internal sealed class ZoneRecurrence : IEquatable<ZoneRecurrence>
	{
		private readonly LocalInstant maxLocalInstant;

		private readonly LocalInstant minLocalInstant;

		public string Name { get; }

		public Offset Savings { get; }

		public ZoneYearOffset YearOffset { get; }

		public int FromYear { get; }

		public int ToYear { get; }

		public bool IsInfinite => ToYear == 2147483647;

		public ZoneRecurrence([NotNull] string name, Offset savings, [NotNull] ZoneYearOffset yearOffset, int fromYear, int toYear)
		{
			Preconditions.CheckNotNull(name, "name");
			Preconditions.CheckNotNull(yearOffset, "yearOffset");
			Preconditions.CheckArgument(fromYear == -2147483648 || (fromYear >= -9998 && fromYear <= 9999), "fromYear", "fromYear must be in the range [-9998, 9999] or Int32.MinValue");
			Preconditions.CheckArgument(toYear == 2147483647 || (toYear >= -9998 && toYear <= 9999), "toYear", "toYear must be in the range [-9998, 9999] or Int32.MaxValue");
			Name = name;
			Savings = savings;
			YearOffset = yearOffset;
			FromYear = fromYear;
			ToYear = toYear;
			minLocalInstant = ((fromYear == -2147483648) ? LocalInstant.BeforeMinValue : yearOffset.GetOccurrenceForYear(fromYear));
			maxLocalInstant = ((toYear == 2147483647) ? LocalInstant.AfterMaxValue : yearOffset.GetOccurrenceForYear(toYear));
		}

		internal ZoneRecurrence WithName([NotNull] string name)
		{
			return new ZoneRecurrence(name, Savings, YearOffset, FromYear, ToYear);
		}

		internal ZoneRecurrence ForSingleYear(int year)
		{
			return new ZoneRecurrence(Name, Savings, YearOffset, year, year);
		}

		public bool Equals(ZoneRecurrence other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (Savings == other.Savings && FromYear == other.FromYear && ToYear == other.ToYear && Name == other.Name)
			{
				return YearOffset.Equals(other.YearOffset);
			}
			return false;
		}

		internal Transition? Next(Instant instant, Offset standardOffset, Offset previousSavings)
		{
			Offset ruleOffset = YearOffset.GetRuleOffset(standardOffset, previousSavings);
			Offset newOffset = standardOffset + Savings;
			LocalInstant localInstant = instant.SafePlus(ruleOffset);
			int num;
			if (localInstant < minLocalInstant)
			{
				num = FromYear;
			}
			else
			{
				if (localInstant >= maxLocalInstant)
				{
					if (!(maxLocalInstant == LocalInstant.AfterMaxValue))
					{
						return null;
					}
					return new Transition(Instant.AfterMaxValue, newOffset);
				}
				num = ((!(localInstant == LocalInstant.BeforeMinValue)) ? CalendarSystem.Iso.YearMonthDayCalculator.GetYear(localInstant.DaysSinceEpoch, out var _) : (-9998));
			}
			Instant instant2 = YearOffset.GetOccurrenceForYear(num).SafeMinus(ruleOffset);
			if (instant2 > instant)
			{
				return new Transition(instant2, newOffset);
			}
			num = checked(num + 1);
			if (num > 9999)
			{
				return new Transition(Instant.AfterMaxValue, newOffset);
			}
			instant2 = YearOffset.GetOccurrenceForYear(num).SafeMinus(ruleOffset);
			return new Transition(instant2, newOffset);
		}

		internal Transition? PreviousOrSame(Instant instant, Offset standardOffset, Offset previousSavings)
		{
			Offset ruleOffset = YearOffset.GetRuleOffset(standardOffset, previousSavings);
			Offset newOffset = standardOffset + Savings;
			LocalInstant localInstant = instant.SafePlus(ruleOffset);
			int num;
			if (localInstant > maxLocalInstant)
			{
				num = ToYear;
			}
			else
			{
				if (localInstant < minLocalInstant)
				{
					return null;
				}
				if (!localInstant.IsValid)
				{
					if (localInstant == LocalInstant.BeforeMinValue)
					{
						return new Transition(Instant.BeforeMinValue, newOffset);
					}
					num = 9999;
				}
				else
				{
					num = CalendarSystem.Iso.YearMonthDayCalculator.GetYear(localInstant.DaysSinceEpoch, out var _);
				}
			}
			Instant instant2 = YearOffset.GetOccurrenceForYear(num).SafeMinus(ruleOffset);
			if (instant2 <= instant)
			{
				return new Transition(instant2, newOffset);
			}
			num = checked(num - 1);
			if (num < -9998)
			{
				return new Transition(Instant.BeforeMinValue, newOffset);
			}
			instant2 = YearOffset.GetOccurrenceForYear(num).SafeMinus(ruleOffset);
			return new Transition(instant2, newOffset);
		}

		internal Transition NextOrFail(Instant instant, Offset standardOffset, Offset previousSavings)
		{
			Transition? transition = Next(instant, standardOffset, previousSavings);
			if (!transition.HasValue)
			{
				throw new InvalidOperationException($"Noda Time bug or bad data: Expected a transition later than {instant}; standard offset = {standardOffset}; previousSavings = {previousSavings}; recurrence = {this}");
			}
			return transition.Value;
		}

		internal Transition PreviousOrSameOrFail(Instant instant, Offset standardOffset, Offset previousSavings)
		{
			Transition? transition = PreviousOrSame(instant, standardOffset, previousSavings);
			if (!transition.HasValue)
			{
				throw new InvalidOperationException($"Noda Time bug or bad data: Expected a transition earlier than {instant}; standard offset = {standardOffset}; previousSavings = {previousSavings}; recurrence = {this}");
			}
			return transition.Value;
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			writer.WriteString(Name);
			writer.WriteOffset(Savings);
			YearOffset.Write(writer);
			writer.WriteCount(Math.Max(FromYear, 0));
			writer.WriteCount(ToYear);
		}

		public static ZoneRecurrence Read([NotNull] IDateTimeZoneReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			string name = reader.ReadString();
			Offset savings = reader.ReadOffset();
			ZoneYearOffset yearOffset = ZoneYearOffset.Read(reader);
			int num = reader.ReadCount();
			if (num == 0)
			{
				num = -2147483648;
			}
			int toYear = reader.ReadCount();
			return new ZoneRecurrence(name, savings, yearOffset, num, toYear);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ZoneRecurrence);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Hash(Savings, Name, YearOffset);
		}

		public override string ToString()
		{
			return $"{Name} {Savings} {YearOffset} [{FromYear}-{ToYear}]";
		}

		internal ZoneRecurrence ToStartOfTime()
		{
			if (FromYear != -2147483648)
			{
				return new ZoneRecurrence(Name, Savings, YearOffset, -2147483648, ToYear);
			}
			return this;
		}
	}
	internal sealed class ZoneYearOffset : IEquatable<ZoneYearOffset>
	{
		internal static readonly ZoneYearOffset StartOfYear = new ZoneYearOffset(TransitionMode.Wall, 1, 1, 0, advance: false, LocalTime.Midnight);

		private readonly int dayOfMonth;

		private readonly int dayOfWeek;

		private readonly int monthOfYear;

		private readonly bool addDay;

		public TransitionMode Mode { get; }

		public bool AdvanceDayOfWeek { get; }

		public LocalTime TimeOfDay { get; }

		internal ZoneYearOffset(TransitionMode mode, int monthOfYear, int dayOfMonth, int dayOfWeek, bool advance, LocalTime timeOfDay)
			: this(mode, monthOfYear, dayOfMonth, dayOfWeek, advance, timeOfDay, addDay: false)
		{
		}

		internal ZoneYearOffset(TransitionMode mode, int monthOfYear, int dayOfMonth, int dayOfWeek, bool advance, LocalTime timeOfDay, bool addDay)
		{
			VerifyFieldValue(1L, 12L, "monthOfYear", monthOfYear, allowNegated: false);
			VerifyFieldValue(1L, 31L, "dayOfMonth", dayOfMonth, allowNegated: true);
			if (dayOfWeek != 0)
			{
				VerifyFieldValue(1L, 7L, "dayOfWeek", dayOfWeek, allowNegated: false);
			}
			Mode = mode;
			this.monthOfYear = monthOfYear;
			this.dayOfMonth = dayOfMonth;
			this.dayOfWeek = dayOfWeek;
			AdvanceDayOfWeek = advance;
			TimeOfDay = timeOfDay;
			this.addDay = addDay;
		}

		private static void VerifyFieldValue(long minimum, long maximum, string name, long value, bool allowNegated)
		{
			bool flag = false;
			checked
			{
				if (allowNegated && value < 0)
				{
					if (value < -maximum || -minimum < value)
					{
						flag = true;
					}
				}
				else if (value < minimum || maximum < value)
				{
					flag = true;
				}
				if (flag)
				{
					string arg = (allowNegated ? $"[{minimum}, {maximum}] or [{-maximum}, {-minimum}]" : $"[{minimum}, {maximum}]");
					throw new ArgumentOutOfRangeException(name, $"{name} is not in the valid range: {arg}");
				}
			}
		}

		public bool Equals(ZoneYearOffset other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (Mode == other.Mode && monthOfYear == other.monthOfYear && dayOfMonth == other.dayOfMonth && dayOfWeek == other.dayOfWeek && AdvanceDayOfWeek == other.AdvanceDayOfWeek && TimeOfDay == other.TimeOfDay)
			{
				return addDay == other.addDay;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "ZoneYearOffset[mode:{0} monthOfYear:{1} dayOfMonth:{2} dayOfWeek:{3} advance:{4} timeOfDay:{5:r} addDay:{6}]", Mode, monthOfYear, dayOfMonth, dayOfWeek, AdvanceDayOfWeek, TimeOfDay, addDay);
		}

		internal LocalInstant GetOccurrenceForYear(int year)
		{
			int day = ((dayOfMonth > 0) ? dayOfMonth : (CalendarSystem.Iso.GetDaysInMonth(year, monthOfYear) + dayOfMonth + 1));
			if (monthOfYear == 2 && dayOfMonth == 29 && !CalendarSystem.Iso.IsLeapYear(year))
			{
				day = 28;
			}
			LocalDate localDate = new LocalDate(year, monthOfYear, day);
			if (dayOfWeek != 0)
			{
				int num = (int)localDate.DayOfWeek;
				if (num != dayOfWeek)
				{
					int num2 = dayOfWeek - num;
					if (num2 > 0)
					{
						if (!AdvanceDayOfWeek)
						{
							num2 -= 7;
						}
					}
					else if (AdvanceDayOfWeek)
					{
						num2 += 7;
					}
					localDate = localDate.PlusDays(num2);
				}
			}
			if (addDay)
			{
				if (year == 9999 && localDate.Month == 12 && localDate.Day == 31)
				{
					return LocalInstant.AfterMaxValue;
				}
				localDate = localDate.PlusDays(1);
			}
			return (localDate + TimeOfDay).ToLocalInstant();
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			int num = ((int)Mode << 5) | (dayOfWeek << 2) | (AdvanceDayOfWeek ? 2 : 0) | (addDay ? 1 : 0);
			checked
			{
				writer.WriteByte((byte)num);
				writer.WriteCount(monthOfYear);
				writer.WriteSignedCount(dayOfMonth);
				writer.WriteMilliseconds((int)unchecked(TimeOfDay.TickOfDay / 10000));
			}
		}

		public static ZoneYearOffset Read([NotNull] IDateTimeZoneReader reader)
		{
			Preconditions.CheckNotNull(reader, "reader");
			byte num = reader.ReadByte();
			TransitionMode mode = (TransitionMode)(num >> 5);
			int num2 = (num >> 2) & 7;
			bool advance = (num & 2) != 0;
			bool flag = (num & 1) != 0;
			int num3 = reader.ReadCount();
			int num4 = reader.ReadSignedCount();
			LocalTime timeOfDay = LocalTime.FromMillisecondsSinceMidnight(reader.ReadMilliseconds());
			return new ZoneYearOffset(mode, num3, num4, num2, advance, timeOfDay, flag);
		}

		internal Offset GetRuleOffset(Offset standardOffset, Offset savings)
		{
			return Mode switch
			{
				TransitionMode.Wall => standardOffset + savings, 
				TransitionMode.Standard => standardOffset, 
				_ => Offset.Zero, 
			};
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ZoneYearOffset);
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.Initialize().Hash(Mode).Hash(monthOfYear)
				.Hash(dayOfMonth)
				.Hash(dayOfWeek)
				.Hash(AdvanceDayOfWeek)
				.Hash(TimeOfDay)
				.Hash(addDay)
				.Value;
		}
	}
}
namespace NodaTime.TimeZones.IO
{
	internal sealed class DateTimeZoneReader : IDateTimeZoneReader
	{
		private readonly Stream input;

		private readonly IList<string> stringPool;

		private byte? bufferedByte;

		public bool HasMoreData
		{
			get
			{
				if (bufferedByte.HasValue)
				{
					return true;
				}
				int num = input.ReadByte();
				if (num == -1)
				{
					return false;
				}
				bufferedByte = checked((byte)num);
				return true;
			}
		}

		internal DateTimeZoneReader(Stream input, IList<string> stringPool)
		{
			this.input = input;
			this.stringPool = stringPool;
		}

		public int ReadCount()
		{
			uint num = ReadVarint();
			if (num > 2147483647)
			{
				throw new InvalidNodaDataException("Count value greater than Int32.MaxValue");
			}
			return checked((int)num);
		}

		public int ReadSignedCount()
		{
			uint num = ReadVarint();
			return checked((int)(num >> 1) ^ -(int)(num & 1));
		}

		private uint ReadVarint()
		{
			uint num = 0u;
			int num2 = 0;
			byte b;
			do
			{
				b = ReadByte();
				num += (uint)((b & 0x7F) << num2);
				num2 += 7;
			}
			while (b >= 128);
			return num;
		}

		public int ReadMilliseconds()
		{
			byte b = ReadByte();
			int num;
			if ((b & 0x80) == 0)
			{
				num = b * 1800000;
			}
			else
			{
				int num2 = b & 0xE0;
				int num3 = b & 0x1F;
				num = num2 switch
				{
					128 => ((num3 << 8) + ReadByte()) * 60000, 
					160 => ((num3 << 16) + (ReadInt16() & 0xFFFF)) * 1000, 
					192 => (num3 << 24) + (ReadByte() << 16) + (ReadInt16() & 0xFFFF), 
					_ => throw new InvalidNodaDataException("Invalid flag in offset: " + num2.ToString("x2")), 
				};
			}
			return num - 86400000;
		}

		public Offset ReadOffset()
		{
			return Offset.FromMilliseconds(ReadMilliseconds());
		}

		public IDictionary<string, string> ReadDictionary()
		{
			IDictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = ReadCount();
			for (int i = 0; i < num; i = checked(i + 1))
			{
				string key = ReadString();
				string value = ReadString();
				dictionary.Add(key, value);
			}
			return dictionary;
		}

		public Instant ReadZoneIntervalTransition(Instant? previous)
		{
			int num = ReadCount();
			if (num < 128)
			{
				return num switch
				{
					0 => Instant.BeforeMinValue, 
					1 => Instant.AfterMaxValue, 
					2 => Instant.FromUnixTimeTicks(ReadInt64()), 
					_ => throw new InvalidNodaDataException("Unrecognised marker value: " + num), 
				};
			}
			if (num < 2097152)
			{
				if (!previous.HasValue)
				{
					throw new InvalidNodaDataException("No previous value, so can't interpret value encoded as delta-since-previous: " + num);
				}
				return previous.Value + Duration.FromHours(num);
			}
			return DateTimeZoneWriter.ZoneIntervalConstants.EpochForMinutesSinceEpoch + Duration.FromMinutes(num);
		}

		public string ReadString()
		{
			checked
			{
				if (stringPool == null)
				{
					int num = ReadCount();
					byte[] array = new byte[num];
					int num2;
					for (int i = 0; i < num; i += num2)
					{
						num2 = input.Read(array, i, num - i);
						if (num2 <= 0)
						{
							throw new InvalidNodaDataException("Unexpectedly reached end of data with " + (num - i) + " bytes still to read");
						}
					}
					return Encoding.UTF8.GetString(array, 0, num);
				}
				int index = ReadCount();
				return stringPool[index];
			}
		}

		private int ReadInt16()
		{
			byte num = ReadByte();
			int num2 = ReadByte();
			return (num << 8) | num2;
		}

		private int ReadInt32()
		{
			int num = ReadInt16() & 0xFFFF;
			int num2 = ReadInt16() & 0xFFFF;
			return (num << 16) | num2;
		}

		private long ReadInt64()
		{
			long num = ReadInt32() & 0xFFFFFFFFu;
			long num2 = ReadInt32() & 0xFFFFFFFFu;
			return (num << 32) | num2;
		}

		public byte ReadByte()
		{
			if (bufferedByte.HasValue)
			{
				byte value = bufferedByte.Value;
				bufferedByte = null;
				return value;
			}
			int num = input.ReadByte();
			if (num == -1)
			{
				throw new InvalidNodaDataException("Unexpected end of data stream");
			}
			return checked((byte)num);
		}
	}
	internal sealed class DateTimeZoneWriter : IDateTimeZoneWriter
	{
		internal enum DateTimeZoneType : byte
		{
			Fixed = 1,
			Precalculated
		}

		internal static class ZoneIntervalConstants
		{
			internal static readonly Instant EpochForMinutesSinceEpoch = Instant.FromUtc(1800, 1, 1, 0, 0);

			internal const int MarkerMinValue = 0;

			internal const int MarkerMaxValue = 1;

			internal const int MarkerRaw = 2;

			internal const int MinValueForHoursSincePrevious = 128;

			internal const int MinValueForMinutesSinceEpoch = 2097152;
		}

		private readonly Stream output;

		private readonly IList<string> stringPool;

		internal DateTimeZoneWriter(Stream output, IList<string> stringPool)
		{
			this.output = output;
			this.stringPool = stringPool;
		}

		public void WriteCount(int value)
		{
			Preconditions.CheckArgumentRange("value", value, 0, 2147483647);
			WriteVarint(checked((uint)value));
		}

		public void WriteSignedCount(int count)
		{
			WriteVarint((uint)((count >> 31) ^ (count << 1)));
		}

		private void WriteVarint(uint value)
		{
			while (value > 127)
			{
				output.WriteByte((byte)(0x80 | (value & 0x7F)));
				value >>= 7;
			}
			output.WriteByte((byte)(value & 0x7F));
		}

		public void WriteMilliseconds(int millis)
		{
			Preconditions.CheckArgumentRange("millis", millis, -86399999, 86399999);
			millis = checked(millis + 86400000);
			if (millis % 1800000 == 0)
			{
				int num = millis / 1800000;
				WriteByte((byte)num);
			}
			else if (millis % 60000 == 0)
			{
				int num2 = millis / 60000;
				WriteByte((byte)(0x80 | (num2 >> 8)));
				WriteByte((byte)(num2 & 0xFF));
			}
			else if (millis % 1000 == 0)
			{
				int num3 = millis / 1000;
				WriteByte((byte)(0xA0 | (byte)(num3 >> 16)));
				WriteInt16((short)(num3 & 0xFFFF));
			}
			else
			{
				WriteInt32(-1073741824 | millis);
			}
		}

		public void WriteOffset(Offset offset)
		{
			WriteMilliseconds(offset.Milliseconds);
		}

		public void WriteDictionary([NotNull] IDictionary<string, string> dictionary)
		{
			Preconditions.CheckNotNull(dictionary, "dictionary");
			WriteCount(dictionary.Count);
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				WriteString(item.Key);
				WriteString(item.Value);
			}
		}

		public void WriteZoneIntervalTransition(Instant? previous, Instant value)
		{
			if (previous.HasValue)
			{
				Preconditions.CheckArgument(value >= previous.Value, "value", "Transition must move forward in time");
			}
			if (value == Instant.BeforeMinValue)
			{
				WriteCount(0);
				return;
			}
			if (value == Instant.AfterMaxValue)
			{
				WriteCount(1);
				return;
			}
			if (previous.HasValue && previous.Value != Instant.BeforeMinValue)
			{
				ulong num = (ulong)(value.ToUnixTimeTicks() - previous.Value.ToUnixTimeTicks());
				if (num % 36000000000L == 0L)
				{
					ulong num2 = num / 36000000000L;
					if (128 <= num2 && num2 < 2097152)
					{
						WriteCount((int)num2);
						return;
					}
				}
			}
			if (value >= ZoneIntervalConstants.EpochForMinutesSinceEpoch)
			{
				ulong num3 = (ulong)(value.ToUnixTimeTicks() - ZoneIntervalConstants.EpochForMinutesSinceEpoch.ToUnixTimeTicks());
				if (num3 % 600000000 == 0L)
				{
					ulong num4 = num3 / 600000000;
					if (2097152 < num4 && num4 <= 2147483647)
					{
						WriteCount((int)num4);
						return;
					}
				}
			}
			WriteCount(2);
			WriteInt64(value.ToUnixTimeTicks());
		}

		public void WriteString(string value)
		{
			if (stringPool == null)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value);
				int value2 = bytes.Length;
				WriteCount(value2);
				output.Write(bytes, 0, bytes.Length);
				return;
			}
			int num = stringPool.IndexOf(value);
			if (num == -1)
			{
				num = stringPool.Count;
				stringPool.Add(value);
			}
			WriteCount(num);
		}

		private void WriteInt16(short value)
		{
			WriteByte((byte)((value >> 8) & 0xFF));
			WriteByte((byte)(value & 0xFF));
		}

		private void WriteInt32(int value)
		{
			WriteInt16((short)(value >> 16));
			WriteInt16((short)value);
		}

		private void WriteInt64(long value)
		{
			WriteInt32((int)(value >> 32));
			WriteInt32((int)value);
		}

		public void WriteByte(byte value)
		{
			output.WriteByte(value);
		}
	}
	internal interface IDateTimeZoneReader
	{
		bool HasMoreData { get; }

		int ReadCount();

		int ReadSignedCount();

		string ReadString();

		byte ReadByte();

		int ReadMilliseconds();

		Offset ReadOffset();

		Instant ReadZoneIntervalTransition(Instant? previous);

		IDictionary<string, string> ReadDictionary();
	}
	internal interface IDateTimeZoneWriter
	{
		void WriteCount(int count);

		void WriteSignedCount(int count);

		void WriteString([NotNull] string value);

		void WriteMilliseconds(int millis);

		void WriteOffset(Offset offset);

		void WriteZoneIntervalTransition(Instant? previous, Instant value);

		void WriteDictionary([NotNull] IDictionary<string, string> dictionary);

		void WriteByte(byte value);
	}
	internal sealed class TzdbStreamData
	{
		private class Builder
		{
			internal IList<string> stringPool;

			internal string tzdbVersion;

			internal IDictionary<string, string> tzdbIdMap;

			internal IList<TzdbZoneLocation> zoneLocations;

			internal IList<TzdbZone1970Location> zone1970Locations;

			internal WindowsZones windowsMapping;

			internal readonly IDictionary<string, TzdbStreamField> zoneFields = new Dictionary<string, TzdbStreamField>();

			internal void HandleStringPoolField(TzdbStreamField field)
			{
				CheckSingleField(field, stringPool);
				using Stream input = field.CreateStream();
				DateTimeZoneReader dateTimeZoneReader = new DateTimeZoneReader(input, null);
				int num = dateTimeZoneReader.ReadCount();
				stringPool = new string[num];
				for (int i = 0; i < num; i = checked(i + 1))
				{
					stringPool[i] = dateTimeZoneReader.ReadString();
				}
			}

			internal void HandleZoneField(TzdbStreamField field)
			{
				CheckStringPoolPresence(field);
				using Stream input = field.CreateStream();
				string text = new DateTimeZoneReader(input, stringPool).ReadString();
				if (zoneFields.ContainsKey(text))
				{
					throw new InvalidNodaDataException("Multiple definitions for zone " + text);
				}
				zoneFields[text] = field;
			}

			internal void HandleTzdbVersionField(TzdbStreamField field)
			{
				CheckSingleField(field, tzdbVersion);
				tzdbVersion = field.ExtractSingleValue((DateTimeZoneReader reader) => reader.ReadString(), null);
			}

			internal void HandleTzdbIdMapField(TzdbStreamField field)
			{
				CheckSingleField(field, tzdbIdMap);
				tzdbIdMap = field.ExtractSingleValue((DateTimeZoneReader reader) => reader.ReadDictionary(), stringPool);
			}

			internal void HandleSupplementalWindowsZonesField(TzdbStreamField field)
			{
				CheckSingleField(field, windowsMapping);
				windowsMapping = field.ExtractSingleValue(WindowsZones.Read, stringPool);
			}

			internal void HandleZoneLocationsField(TzdbStreamField field)
			{
				CheckSingleField(field, zoneLocations);
				CheckStringPoolPresence(field);
				using Stream input = field.CreateStream();
				DateTimeZoneReader dateTimeZoneReader = new DateTimeZoneReader(input, stringPool);
				int num = dateTimeZoneReader.ReadCount();
				TzdbZoneLocation[] array = new TzdbZoneLocation[num];
				for (int i = 0; i < num; i = checked(i + 1))
				{
					array[i] = TzdbZoneLocation.Read(dateTimeZoneReader);
				}
				zoneLocations = array;
			}

			internal void HandleZone1970LocationsField(TzdbStreamField field)
			{
				CheckSingleField(field, zone1970Locations);
				CheckStringPoolPresence(field);
				using Stream input = field.CreateStream();
				DateTimeZoneReader dateTimeZoneReader = new DateTimeZoneReader(input, stringPool);
				int num = dateTimeZoneReader.ReadCount();
				TzdbZone1970Location[] array = new TzdbZone1970Location[num];
				for (int i = 0; i < num; i = checked(i + 1))
				{
					array[i] = TzdbZone1970Location.Read(dateTimeZoneReader);
				}
				zone1970Locations = array;
			}

			private void CheckSingleField(TzdbStreamField field, object expectedNullField)
			{
				if (expectedNullField != null)
				{
					throw new InvalidNodaDataException("Multiple fields of ID " + field.Id);
				}
			}

			private void CheckStringPoolPresence(TzdbStreamField field)
			{
				if (stringPool == null)
				{
					throw new InvalidNodaDataException("String pool must be present before field " + field.Id);
				}
			}
		}

		private static readonly Dictionary<TzdbStreamFieldId, Action<Builder, TzdbStreamField>> FieldHandlers = new Dictionary<TzdbStreamFieldId, Action<Builder, TzdbStreamField>>
		{
			[TzdbStreamFieldId.StringPool] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleStringPoolField(field);
			},
			[TzdbStreamFieldId.TimeZone] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleZoneField(field);
			},
			[TzdbStreamFieldId.TzdbIdMap] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleTzdbIdMapField(field);
			},
			[TzdbStreamFieldId.TzdbVersion] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleTzdbVersionField(field);
			},
			[TzdbStreamFieldId.CldrSupplementalWindowsZones] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleSupplementalWindowsZonesField(field);
			},
			[TzdbStreamFieldId.ZoneLocations] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleZoneLocationsField(field);
			},
			[TzdbStreamFieldId.Zone1970Locations] = delegate(Builder builder, TzdbStreamField field)
			{
				builder.HandleZone1970LocationsField(field);
			}
		};

		private const int AcceptedVersion = 0;

		private readonly IList<string> stringPool;

		private readonly IDictionary<string, TzdbStreamField> zoneFields;

		[NotNull]
		public string TzdbVersion { get; }

		[NotNull]
		public IDictionary<string, string> TzdbIdMap { get; }

		[NotNull]
		public WindowsZones WindowsMapping { get; }

		public IList<TzdbZoneLocation> ZoneLocations { get; }

		public IList<TzdbZone1970Location> Zone1970Locations { get; }

		private TzdbStreamData(Builder builder)
		{
			stringPool = CheckNotNull(builder.stringPool, "string pool");
			TzdbIdMap = CheckNotNull(builder.tzdbIdMap, "TZDB alias map");
			TzdbVersion = CheckNotNull(builder.tzdbVersion, "TZDB version");
			WindowsMapping = CheckNotNull(builder.windowsMapping, "CLDR Supplemental Windows Zones");
			zoneFields = builder.zoneFields;
			ZoneLocations = builder.zoneLocations;
			Zone1970Locations = builder.zone1970Locations;
			foreach (string key in zoneFields.Keys)
			{
				TzdbIdMap[key] = key;
			}
		}

		public DateTimeZone CreateZone([NotNull] string id, [NotNull] string canonicalId)
		{
			Preconditions.CheckNotNull(id, "id");
			Preconditions.CheckNotNull(canonicalId, "canonicalId");
			using Stream input = zoneFields[canonicalId].CreateStream();
			DateTimeZoneReader dateTimeZoneReader = new DateTimeZoneReader(input, stringPool);
			dateTimeZoneReader.ReadString();
			DateTimeZoneWriter.DateTimeZoneType dateTimeZoneType = (DateTimeZoneWriter.DateTimeZoneType)dateTimeZoneReader.ReadByte();
			return dateTimeZoneType switch
			{
				DateTimeZoneWriter.DateTimeZoneType.Fixed => FixedDateTimeZone.Read(dateTimeZoneReader, id), 
				DateTimeZoneWriter.DateTimeZoneType.Precalculated => CachedDateTimeZone.ForZone(PrecalculatedDateTimeZone.Read(dateTimeZoneReader, id)), 
				_ => throw new InvalidNodaDataException("Unknown time zone type " + dateTimeZoneType), 
			};
		}

		private static T CheckNotNull<T>(T input, string name) where T : class
		{
			if (input == null)
			{
				throw new InvalidNodaDataException("Incomplete TZDB data. Missing field: " + name);
			}
			return input;
		}

		internal static TzdbStreamData FromStream([NotNull] Stream stream)
		{
			Preconditions.CheckNotNull(stream, "stream");
			int num = new BinaryReader(stream).ReadInt32();
			if (num != 0)
			{
				throw new InvalidNodaDataException("Unable to read stream with version " + num);
			}
			Builder builder = new Builder();
			foreach (TzdbStreamField item in TzdbStreamField.ReadFields(stream))
			{
				if (FieldHandlers.TryGetValue(item.Id, out var value))
				{
					value(builder, item);
				}
			}
			return new TzdbStreamData(builder);
		}
	}
	internal sealed class TzdbStreamField
	{
		private readonly byte[] data;

		internal TzdbStreamFieldId Id { get; }

		private TzdbStreamField(TzdbStreamFieldId id, byte[] data)
		{
			Id = id;
			this.data = data;
		}

		internal Stream CreateStream()
		{
			return new MemoryStream(data, writable: false);
		}

		internal T ExtractSingleValue<T>(Func<DateTimeZoneReader, T> readerFunction, IList<string> stringPool)
		{
			using Stream input = CreateStream();
			return readerFunction(new DateTimeZoneReader(input, stringPool));
		}

		internal static IEnumerable<TzdbStreamField> ReadFields(Stream input)
		{
			while (true)
			{
				int num = input.ReadByte();
				if (num == -1)
				{
					break;
				}
				TzdbStreamFieldId id = (TzdbStreamFieldId)checked((byte)num);
				byte[] array = new byte[new DateTimeZoneReader(input, null).ReadCount()];
				checked
				{
					int num2;
					for (int i = 0; i < array.Length; i += num2)
					{
						num2 = input.Read(array, i, array.Length - i);
						if (num2 == 0)
						{
							throw new InvalidNodaDataException("Stream ended after reading " + i + " bytes out of " + array.Length);
						}
					}
					yield return new TzdbStreamField(id, array);
				}
			}
		}
	}
	internal enum TzdbStreamFieldId : byte
	{
		StringPool,
		TimeZone,
		TzdbVersion,
		TzdbIdMap,
		CldrSupplementalWindowsZones,
		WindowsAdditionalStandardNameToIdMapping,
		ZoneLocations,
		Zone1970Locations
	}
}
namespace NodaTime.TimeZones.Cldr
{
	[Immutable]
	public sealed class MapZone : IEquatable<MapZone>
	{
		public const string PrimaryTerritory = "001";

		public const string FixedOffsetTerritory = "ZZ";

		[NotNull]
		public string WindowsId { get; }

		[NotNull]
		public string Territory { get; }

		[NotNull]
		public IList<string> TzdbIds { get; }

		public MapZone([NotNull] string windowsId, [NotNull] string territory, [NotNull] IList<string> tzdbIds)
			: this(Preconditions.CheckNotNull(windowsId, "windowsId"), Preconditions.CheckNotNull(territory, "territory"), new ReadOnlyCollection<string>(new List<string>(Preconditions.CheckNotNull(tzdbIds, "tzdbIds"))))
		{
		}

		private MapZone(string windowsId, string territory, ReadOnlyCollection<string> tzdbIds)
		{
			WindowsId = windowsId;
			Territory = territory;
			TzdbIds = tzdbIds;
		}

		internal static MapZone Read(IDateTimeZoneReader reader)
		{
			string windowsId = reader.ReadString();
			string territory = reader.ReadString();
			int num = reader.ReadCount();
			string[] array = new string[num];
			for (int i = 0; i < num; i = checked(i + 1))
			{
				array[i] = reader.ReadString();
			}
			return new MapZone(windowsId, territory, new ReadOnlyCollection<string>(array));
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			writer.WriteString(WindowsId);
			writer.WriteString(Territory);
			writer.WriteCount(TzdbIds.Count);
			foreach (string tzdbId in TzdbIds)
			{
				writer.WriteString(tzdbId);
			}
		}

		public bool Equals(MapZone other)
		{
			if (other != null && WindowsId == other.WindowsId && Territory == other.Territory)
			{
				return TzdbIds.SequenceEqual(other.TzdbIds);
			}
			return false;
		}

		public override int GetHashCode()
		{
			HashCodeHelper hashCodeHelper = HashCodeHelper.Initialize().Hash(WindowsId).Hash(Territory);
			foreach (string tzdbId in TzdbIds)
			{
				hashCodeHelper = hashCodeHelper.Hash(tzdbId);
			}
			return hashCodeHelper.Value;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as MapZone);
		}

		public override string ToString()
		{
			return string.Format("Windows ID: {0}; Territory: {1}; TzdbIds: {2}", WindowsId, Territory, string.Join(" ", TzdbIds));
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	[Immutable]
	public sealed class WindowsZones
	{
		[NotNull]
		public string Version { get; }

		[NotNull]
		public string TzdbVersion { get; }

		[NotNull]
		public string WindowsVersion { get; }

		[NotNull]
		public IList<MapZone> MapZones { get; }

		[NotNull]
		public IDictionary<string, string> PrimaryMapping { get; }

		internal WindowsZones([NotNull] string version, [NotNull] string tzdbVersion, [NotNull] string windowsVersion, [NotNull] IList<MapZone> mapZones)
			: this(Preconditions.CheckNotNull(version, "version"), Preconditions.CheckNotNull(tzdbVersion, "tzdbVersion"), Preconditions.CheckNotNull(windowsVersion, "windowsVersion"), new ReadOnlyCollection<MapZone>(new List<MapZone>(Preconditions.CheckNotNull(mapZones, "mapZones"))))
		{
		}

		private WindowsZones(string version, string tzdbVersion, string windowsVersion, ReadOnlyCollection<MapZone> mapZones)
		{
			Version = version;
			TzdbVersion = tzdbVersion;
			WindowsVersion = windowsVersion;
			MapZones = mapZones;
			PrimaryMapping = new NodaReadOnlyDictionary<string, string>(mapZones.Where((MapZone z) => z.Territory == "001").ToDictionary((MapZone z) => z.WindowsId, (MapZone z) => z.TzdbIds.Single()));
		}

		internal static WindowsZones Read(IDateTimeZoneReader reader)
		{
			string version = reader.ReadString();
			string tzdbVersion = reader.ReadString();
			string windowsVersion = reader.ReadString();
			int num = reader.ReadCount();
			MapZone[] array = new MapZone[num];
			for (int i = 0; i < num; i = checked(i + 1))
			{
				array[i] = MapZone.Read(reader);
			}
			return new WindowsZones(version, tzdbVersion, windowsVersion, new ReadOnlyCollection<MapZone>(array));
		}

		internal void Write(IDateTimeZoneWriter writer)
		{
			writer.WriteString(Version);
			writer.WriteString(TzdbVersion);
			writer.WriteString(WindowsVersion);
			writer.WriteCount(MapZones.Count);
			foreach (MapZone mapZone in MapZones)
			{
				mapZone.Write(writer);
			}
		}
	}
}
namespace NodaTime.Text
{
	[Immutable]
	public sealed class AnnualDatePattern : IPattern<AnnualDate>
	{
		private static class Patterns
		{
			internal static readonly AnnualDatePattern IsoPatternImpl = CreateWithInvariantCulture("MM'-'dd");
		}

		internal static readonly AnnualDate DefaultTemplateValue = new AnnualDate(1, 1);

		private const string DefaultFormatPattern = "G";

		internal static readonly PatternBclSupport<AnnualDate> BclSupport = new PatternBclSupport<AnnualDate>("G", (NodaFormatInfo fi) => fi.AnnualDatePatternParser);

		[NotNull]
		public static AnnualDatePattern Iso => Patterns.IsoPatternImpl;

		internal IPartialPattern<AnnualDate> UnderlyingPattern { get; }

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public AnnualDate TemplateValue { get; }

		private AnnualDatePattern(string patternText, NodaFormatInfo formatInfo, AnnualDate templateValue, IPartialPattern<AnnualDate> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			UnderlyingPattern = pattern;
		}

		[NotNull]
		public ParseResult<AnnualDate> Parse([SpecialNullHandling] string text)
		{
			return UnderlyingPattern.Parse(text);
		}

		[NotNull]
		public string Format(AnnualDate value)
		{
			return UnderlyingPattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(AnnualDate value, [NotNull] StringBuilder builder)
		{
			return UnderlyingPattern.AppendFormat(value, builder);
		}

		internal static AnnualDatePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, AnnualDate templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<AnnualDate> pattern = ((templateValue == DefaultTemplateValue) ? formatInfo.AnnualDatePatternParser.ParsePattern(patternText) : new AnnualDatePatternParser(templateValue).ParsePattern(patternText, formatInfo));
			IPattern<AnnualDate> pattern2 = (pattern as AnnualDatePattern)?.UnderlyingPattern;
			pattern = pattern2 ?? pattern;
			IPartialPattern<AnnualDate> pattern3 = (IPartialPattern<AnnualDate>)pattern;
			return new AnnualDatePattern(patternText, formatInfo, templateValue, pattern3);
		}

		[NotNull]
		public static AnnualDatePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, AnnualDate templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static AnnualDatePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, cultureInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static AnnualDatePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static AnnualDatePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		private AnnualDatePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public AnnualDatePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public AnnualDatePattern WithTemplateValue(AnnualDate newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}
	}
	internal sealed class AnnualDatePatternParser : IPatternParser<AnnualDate>
	{
		internal sealed class AnnualDateParseBucket : ParseBucket<AnnualDate>
		{
			internal readonly AnnualDate TemplateValue;

			internal int MonthOfYearNumeric;

			internal int MonthOfYearText;

			internal int DayOfMonth;

			internal AnnualDateParseBucket(AnnualDate templateValue)
			{
				TemplateValue = templateValue;
			}

			internal override ParseResult<AnnualDate> CalculateValue(PatternFields usedFields, string text)
			{
				ParseResult<AnnualDate> parseResult = DetermineMonth(usedFields, text);
				if (parseResult != null)
				{
					return parseResult;
				}
				int num = (usedFields.HasAny(PatternFields.DayOfMonth) ? DayOfMonth : TemplateValue.Day);
				if (num > CalendarSystem.Iso.GetDaysInMonth(2000, MonthOfYearNumeric))
				{
					return ParseResult<AnnualDate>.DayOfMonthOutOfRangeNoYear(text, num, MonthOfYearNumeric);
				}
				return ParseResult<AnnualDate>.ForValue(new AnnualDate(MonthOfYearNumeric, num));
			}

			private ParseResult<AnnualDate> DetermineMonth(PatternFields usedFields, string text)
			{
				switch (usedFields & (PatternFields.MonthOfYearNumeric | PatternFields.MonthOfYearText))
				{
				case PatternFields.MonthOfYearText:
					MonthOfYearNumeric = MonthOfYearText;
					break;
				case PatternFields.MonthOfYearNumeric | PatternFields.MonthOfYearText:
					if (MonthOfYearNumeric != MonthOfYearText)
					{
						return ParseResult<AnnualDate>.InconsistentMonthValues(text);
					}
					break;
				case PatternFields.None:
					MonthOfYearNumeric = TemplateValue.Month;
					break;
				}
				if (MonthOfYearNumeric > CalendarSystem.Iso.GetMonthsInYear(2000))
				{
					return ParseResult<AnnualDate>.IsoMonthOutOfRange(text, MonthOfYearNumeric);
				}
				return null;
			}
		}

		private readonly AnnualDate templateValue;

		private static readonly Dictionary<char, CharacterHandler<AnnualDate, AnnualDateParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<AnnualDate, AnnualDateParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<AnnualDate>.DateSeparatorMismatch);
				}
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((AnnualDate value) => value.Month, delegate(AnnualDateParseBucket bucket, int value)
				{
					bucket.MonthOfYearText = value;
				}, delegate(AnnualDateParseBucket bucket, int value)
				{
					bucket.MonthOfYearNumeric = value;
				})
			},
			{ 'd', HandleDayOfMonth }
		};

		internal AnnualDatePatternParser(AnnualDate templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<AnnualDate> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				char c = patternText[0];
				if (c == 'G')
				{
					return AnnualDatePattern.Iso;
				}
				throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(AnnualDate));
			}
			SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket>(formatInfo, () => new AnnualDateParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private static void HandleDayOfMonth(PatternCursor pattern, SteppedPatternBuilder<AnnualDate, AnnualDateParseBucket> builder)
		{
			int repeatCount = pattern.GetRepeatCount(2);
			if ((uint)(repeatCount - 1) <= 1u)
			{
				PatternFields field = PatternFields.DayOfMonth;
				builder.AddParseValueAction(repeatCount, 2, pattern.Current, 1, 99, delegate(AnnualDateParseBucket bucket, int value)
				{
					bucket.DayOfMonth = value;
				});
				builder.AddFormatLeftPad(repeatCount, (AnnualDate value) => value.Day, assumeNonNegative: true, repeatCount == 2);
				builder.AddField(field, pattern.Current);
				return;
			}
			throw new InvalidOperationException("Invalid count!");
		}
	}
	[Mutable]
	public sealed class CompositePatternBuilder<T> : IEnumerable<IPattern<T>>, IEnumerable
	{
		private sealed class CompositePattern : IPartialPattern<T>, IPattern<T>
		{
			private readonly IPattern<T>[] patterns;

			private readonly Func<T, bool>[] formatPredicates;

			internal CompositePattern(List<IPattern<T>> patterns, List<Func<T, bool>> formatPredicates)
			{
				this.patterns = patterns.ToArray();
				this.formatPredicates = formatPredicates.ToArray();
			}

			public ParseResult<T> Parse([SpecialNullHandling] string text)
			{
				IPattern<T>[] array = patterns;
				for (int i = 0; i < array.Length; i++)
				{
					ParseResult<T> parseResult = array[i].Parse(text);
					if (parseResult.Success || !parseResult.ContinueAfterErrorWithMultipleFormats)
					{
						return parseResult;
					}
				}
				return ParseResult<T>.NoMatchingFormat(new ValueCursor(text));
			}

			public ParseResult<T> ParsePartial(ValueCursor cursor)
			{
				int index = cursor.Index;
				IPattern<T>[] array = patterns;
				for (int i = 0; i < array.Length; i++)
				{
					IPartialPattern<T> obj = (IPartialPattern<T>)array[i];
					cursor.Move(index);
					ParseResult<T> parseResult = obj.ParsePartial(cursor);
					if (parseResult.Success || !parseResult.ContinueAfterErrorWithMultipleFormats)
					{
						return parseResult;
					}
				}
				cursor.Move(index);
				return ParseResult<T>.NoMatchingFormat(cursor);
			}

			public string Format(T value)
			{
				return FindFormatPattern(value).Format(value);
			}

			public StringBuilder AppendFormat(T value, [NotNull] StringBuilder builder)
			{
				return FindFormatPattern(value).AppendFormat(value, builder);
			}

			private IPattern<T> FindFormatPattern(T value)
			{
				checked
				{
					for (int num = formatPredicates.Length - 1; num >= 0; num--)
					{
						if (formatPredicates[num](value))
						{
							return patterns[num];
						}
					}
					throw new FormatException("Composite pattern was unable to format value using any of the provided patterns.");
				}
			}
		}

		private readonly List<IPattern<T>> patterns = new List<IPattern<T>>();

		private readonly List<Func<T, bool>> formatPredicates = new List<Func<T, bool>>();

		public void Add([NotNull] IPattern<T> pattern, [NotNull] Func<T, bool> formatPredicate)
		{
			patterns.Add(Preconditions.CheckNotNull(pattern, "pattern"));
			formatPredicates.Add(Preconditions.CheckNotNull(formatPredicate, "formatPredicate"));
		}

		[NotNull]
		public IPattern<T> Build()
		{
			Preconditions.CheckState(patterns.Count != 0, "A composite pattern must have at least one component pattern.");
			return new CompositePattern(patterns, formatPredicates);
		}

		internal IPartialPattern<T> BuildAsPartial()
		{
			return (IPartialPattern<T>)Build();
		}

		IEnumerator<IPattern<T>> IEnumerable<IPattern<T>>.GetEnumerator()
		{
			return patterns.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return patterns.GetEnumerator();
		}
	}
	internal delegate void CharacterHandler<TResult, TBucket>(PatternCursor patternCursor, SteppedPatternBuilder<TResult, TBucket> patternBuilder) where TBucket : ParseBucket<TResult>;
	[Immutable]
	public sealed class DurationPattern : IPattern<Duration>
	{
		internal static class Patterns
		{
			internal static readonly DurationPattern RoundtripPatternImpl = CreateWithInvariantCulture("-D:hh:mm:ss.FFFFFFFFF");
		}

		internal static readonly PatternBclSupport<Duration> BclSupport = new PatternBclSupport<Duration>("o", (NodaFormatInfo fi) => fi.DurationPatternParser);

		private readonly IPattern<Duration> pattern;

		[NotNull]
		public static DurationPattern Roundtrip => Patterns.RoundtripPatternImpl;

		[NotNull]
		public string PatternText { get; }

		private DurationPattern(string patternText, IPattern<Duration> pattern)
		{
			PatternText = patternText;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<Duration> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(Duration value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(Duration value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static DurationPattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<Duration> pattern = formatInfo.DurationPatternParser.ParsePattern(patternText);
			return new DurationPattern(patternText, pattern);
		}

		[NotNull]
		public static DurationPattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public static DurationPattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo);
		}

		[NotNull]
		public static DurationPattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo);
		}

		[NotNull]
		public DurationPattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return Create(PatternText, NodaFormatInfo.GetFormatInfo(cultureInfo));
		}
	}
	internal sealed class DurationPatternParser : IPatternParser<Duration>
	{
		[DebuggerStepThrough]
		private sealed class DurationParseBucket : ParseBucket<Duration>
		{
			private static readonly BigInteger BigIntegerNanosecondsPerDay = 86400000000000L;

			private BigInteger currentNanos;

			internal bool IsNegative { get; set; }

			internal void AddNanoseconds(long nanoseconds)
			{
				currentNanos += (BigInteger)nanoseconds;
			}

			internal void AddDays(int days)
			{
				currentNanos += days * BigIntegerNanosecondsPerDay;
			}

			internal void AddUnits(long units, BigInteger nanosecondsPerUnit)
			{
				currentNanos += units * nanosecondsPerUnit;
			}

			internal override ParseResult<Duration> CalculateValue(PatternFields usedFields, string text)
			{
				if (IsNegative)
				{
					currentNanos = -currentNanos;
				}
				if (currentNanos < Duration.MinNanoseconds || currentNanos > Duration.MaxNanoseconds)
				{
					return ParseResult<Duration>.ForInvalidValuePostParse(text, "Value is out of the legal range for the {0} type.", typeof(Duration));
				}
				return ParseResult<Duration>.ForValue(Duration.FromNanoseconds(currentNanos));
			}
		}

		private static readonly Dictionary<char, CharacterHandler<Duration, DurationParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<Duration, DurationParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<Duration, DurationParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<Duration, DurationParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<Duration, DurationParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<Duration, DurationParseBucket>.HandleBackslash
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler<Duration, DurationParseBucket>(9, GetPositiveNanosecondOfSecond, delegate(DurationParseBucket bucket, int value)
				{
					bucket.AddNanoseconds(value);
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<Duration>.TimeSeparatorMismatch);
				}
			},
			{
				'D',
				CreateDayHandler()
			},
			{
				'H',
				CreateTotalHandler(PatternFields.Hours24, 3600000000000L, 24, 402653184L)
			},
			{
				'h',
				CreatePartialHandler(PatternFields.Hours24, 3600000000000L, 24)
			},
			{
				'M',
				CreateTotalHandler(PatternFields.Minutes, 60000000000L, 1440, 24159191040L)
			},
			{
				'm',
				CreatePartialHandler(PatternFields.Minutes, 60000000000L, 60)
			},
			{
				'S',
				CreateTotalHandler(PatternFields.Seconds, 1000000000L, 86400, 1449551462400L)
			},
			{
				's',
				CreatePartialHandler(PatternFields.Seconds, 1000000000L, 60)
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler<Duration, DurationParseBucket>(9, GetPositiveNanosecondOfSecond, delegate(DurationParseBucket bucket, int value)
				{
					bucket.AddNanoseconds(value);
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler<Duration, DurationParseBucket>(9, GetPositiveNanosecondOfSecond, delegate(DurationParseBucket bucket, int value)
				{
					bucket.AddNanoseconds(value);
				})
			},
			{ '+', HandlePlus },
			{ '-', HandleMinus }
		};

		public IPattern<Duration> ParsePattern([NotNull] string patternText, NodaFormatInfo formatInfo)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				char c = patternText[0];
				if (c == 'o')
				{
					return DurationPattern.Patterns.RoundtripPatternImpl;
				}
				throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(Duration));
			}
			SteppedPatternBuilder<Duration, DurationParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<Duration, DurationParseBucket>(formatInfo, () => new DurationParseBucket());
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			return steppedPatternBuilder.Build(Duration.FromHours(1) + Duration.FromMinutes(30L) + Duration.FromSeconds(5L) + Duration.FromMilliseconds(500L));
		}

		private static int GetPositiveNanosecondOfSecond(Duration duration)
		{
			checked
			{
				return (int)unchecked(Math.Abs(duration.NanosecondOfDay) % 1000000000);
			}
		}

		private static CharacterHandler<Duration, DurationParseBucket> CreateTotalHandler(PatternFields field, long nanosecondsPerUnit, int unitsPerDay, long maxValue)
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
			{
				int count = pattern.GetRepeatCount(13);
				if ((builder.UsedFields & PatternFields.TotalDuration) != PatternFields.None)
				{
					throw new InvalidPatternException("Only one of \"D\", \"H\", \"M\" or \"S\" can occur in a duration format string.");
				}
				builder.AddField(field, pattern.Current);
				builder.AddField(PatternFields.TotalDuration, pattern.Current);
				builder.AddParseInt64ValueAction(count, 13, pattern.Current, 0L, maxValue, delegate(DurationParseBucket bucket, long value)
				{
					bucket.AddUnits(value, nanosecondsPerUnit);
				});
				builder.AddFormatAction(delegate(Duration value, StringBuilder sb)
				{
					FormatHelper.LeftPadNonNegativeInt64(GetPositiveNanosecondUnits(value, nanosecondsPerUnit, unitsPerDay), count, sb);
				});
			};
		}

		private static CharacterHandler<Duration, DurationParseBucket> CreateDayHandler()
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(8);
				if ((builder.UsedFields & PatternFields.TotalDuration) != PatternFields.None)
				{
					throw new InvalidPatternException("Only one of \"D\", \"H\", \"M\" or \"S\" can occur in a duration format string.");
				}
				builder.AddField(PatternFields.DayOfMonth, pattern.Current);
				builder.AddField(PatternFields.TotalDuration, pattern.Current);
				builder.AddParseValueAction(repeatCount, 8, pattern.Current, 0, 16777216, delegate(DurationParseBucket bucket, int value)
				{
					bucket.AddDays(value);
				});
				builder.AddFormatLeftPad(repeatCount, delegate(Duration duration)
				{
					int floorDays = duration.FloorDays;
					if (floorDays >= 0)
					{
						return floorDays;
					}
					return checked((duration.NanosecondOfFloorDay != 0L) ? (-(floorDays + 1)) : (-floorDays));
				}, assumeNonNegative: true, assumeFitsInCount: false);
			};
		}

		private static CharacterHandler<Duration, DurationParseBucket> CreatePartialHandler(PatternFields field, long nanosecondsPerUnit, int unitsPerContainer)
		{
			checked
			{
				return delegate(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
				{
					int repeatCount = pattern.GetRepeatCount(2);
					builder.AddField(field, pattern.Current);
					builder.AddParseValueAction(repeatCount, 2, pattern.Current, 0, unitsPerContainer - 1, delegate(DurationParseBucket bucket, int value)
					{
						bucket.AddUnits(value, nanosecondsPerUnit);
					});
					builder.AddFormatLeftPad(repeatCount, (Duration duration) => (int)unchecked(Math.Abs(duration.NanosecondOfDay) / nanosecondsPerUnit % unitsPerContainer), assumeNonNegative: true, repeatCount == 2);
				};
			}
		}

		private static void HandlePlus(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
		{
			builder.AddField(PatternFields.Sign, pattern.Current);
			builder.AddRequiredSign(delegate(DurationParseBucket bucket, bool positive)
			{
				bucket.IsNegative = !positive;
			}, (Duration duration) => duration.FloorDays >= 0);
		}

		private static void HandleMinus(PatternCursor pattern, SteppedPatternBuilder<Duration, DurationParseBucket> builder)
		{
			builder.AddField(PatternFields.Sign, pattern.Current);
			builder.AddNegativeOnlySign(delegate(DurationParseBucket bucket, bool positive)
			{
				bucket.IsNegative = !positive;
			}, (Duration duration) => duration.FloorDays >= 0);
		}

		private static long GetPositiveNanosecondUnits(Duration duration, long nanosecondsPerUnit, int unitsPerDay)
		{
			long num = duration.FloorDays;
			checked
			{
				if (num >= 0)
				{
					return num * unitsPerDay + unchecked(duration.NanosecondOfFloorDay / nanosecondsPerUnit);
				}
				long nanosecondOfDay = duration.NanosecondOfDay;
				long num2 = ((nanosecondOfDay == 0L) ? (num * unitsPerDay) : ((num + 1) * unitsPerDay + unchecked(nanosecondOfDay / nanosecondsPerUnit)));
				return -num2;
			}
		}
	}
	internal sealed class FixedFormatInfoPatternParser<T>
	{
		private const int CacheSize = 50;

		private readonly Cache<string, IPattern<T>> cache;

		internal FixedFormatInfoPatternParser(IPatternParser<T> patternParser, NodaFormatInfo formatInfo)
		{
			cache = new Cache<string, IPattern<T>>(50, (string patternText) => patternParser.ParsePattern(patternText, formatInfo), StringComparer.Ordinal);
		}

		internal IPattern<T> ParsePattern(string pattern)
		{
			return cache.GetOrAdd(pattern);
		}
	}
	internal static class FormatHelper
	{
		private const int MaximumPaddingLength = 16;

		private const int MaximumInt64Length = 19;

		internal static void Format2DigitsNonNegative([Trusted] int value, StringBuilder outputBuffer)
		{
			outputBuffer.Append((char)(48 + value / 10));
			outputBuffer.Append((char)(48 + value % 10));
		}

		internal static void Format4DigitsValueFits([Trusted] int value, StringBuilder outputBuffer)
		{
			if (value < 0)
			{
				value = -value;
				outputBuffer.Append('-');
			}
			outputBuffer.Append((char)(48 + value / 1000));
			outputBuffer.Append((char)(48 + value / 100 % 10));
			outputBuffer.Append((char)(48 + value / 10 % 10));
			outputBuffer.Append((char)(48 + value % 10));
		}

		internal static void LeftPad(int value, [Trusted] int length, StringBuilder outputBuffer)
		{
			if (value >= 0)
			{
				LeftPadNonNegative(value, length, outputBuffer);
				return;
			}
			outputBuffer.Append('-');
			if (value == -2147483648)
			{
				if (length > 10)
				{
					outputBuffer.Append("000000".Substring(16 - length));
				}
				outputBuffer.Append("2147483648");
			}
			else
			{
				LeftPadNonNegative(-value, length, outputBuffer);
			}
		}

		internal static void LeftPadNonNegative(int value, [Trusted] int length, StringBuilder outputBuffer)
		{
			if (length == 1)
			{
				if (value < 10)
				{
					outputBuffer.Append((char)(48 + value));
					return;
				}
				if (value < 100)
				{
					char value2 = (char)(48 + value / 10);
					char value3 = (char)(48 + value % 10);
					outputBuffer.Append(value2).Append(value3);
					return;
				}
			}
			if (length == 2 && value < 100)
			{
				char value4 = (char)(48 + value / 10);
				char value5 = (char)(48 + value % 10);
				outputBuffer.Append(value4).Append(value5);
				return;
			}
			if (length == 3 && value < 1000)
			{
				char value6 = (char)(48 + value / 100 % 10);
				char value7 = (char)(48 + value / 10 % 10);
				char value8 = (char)(48 + value % 10);
				outputBuffer.Append(value6).Append(value7).Append(value8);
				return;
			}
			if (length == 4 && value < 10000)
			{
				char value9 = (char)(48 + value / 1000);
				char value10 = (char)(48 + value / 100 % 10);
				char value11 = (char)(48 + value / 10 % 10);
				char value12 = (char)(48 + value % 10);
				outputBuffer.Append(value9).Append(value10).Append(value11)
					.Append(value12);
				return;
			}
			if (length == 5 && value < 100000)
			{
				char value13 = (char)(48 + value / 10000);
				char value14 = (char)(48 + value / 1000 % 10);
				char value15 = (char)(48 + value / 100 % 10);
				char value16 = (char)(48 + value / 10 % 10);
				char value17 = (char)(48 + value % 10);
				outputBuffer.Append(value13).Append(value14).Append(value15)
					.Append(value16)
					.Append(value17);
				return;
			}
			char[] array = new char[16];
			int num = 16;
			do
			{
				array[--num] = (char)(48 + value % 10);
				value /= 10;
			}
			while (value != 0 && num > 0);
			while (16 - num < length)
			{
				array[--num] = '0';
			}
			outputBuffer.Append(array, num, 16 - num);
		}

		internal static void LeftPadNonNegativeInt64(long value, [Trusted] int length, StringBuilder outputBuffer)
		{
			if (length == 1)
			{
				if (value < 10)
				{
					outputBuffer.Append((char)(48 + value));
					return;
				}
				if (value < 100)
				{
					char value2 = (char)(48 + value / 10);
					char value3 = (char)(48 + value % 10);
					outputBuffer.Append(value2).Append(value3);
					return;
				}
			}
			if (length == 2 && value < 100)
			{
				char value4 = (char)(48 + value / 10);
				char value5 = (char)(48 + value % 10);
				outputBuffer.Append(value4).Append(value5);
				return;
			}
			if (length == 3 && value < 1000)
			{
				char value6 = (char)(48 + value / 100 % 10);
				char value7 = (char)(48 + value / 10 % 10);
				char value8 = (char)(48 + value % 10);
				outputBuffer.Append(value6).Append(value7).Append(value8);
				return;
			}
			if (length == 4 && value < 10000)
			{
				char value9 = (char)(48 + value / 1000);
				char value10 = (char)(48 + value / 100 % 10);
				char value11 = (char)(48 + value / 10 % 10);
				char value12 = (char)(48 + value % 10);
				outputBuffer.Append(value9).Append(value10).Append(value11)
					.Append(value12);
				return;
			}
			if (length == 5 && value < 100000)
			{
				char value13 = (char)(48 + value / 10000);
				char value14 = (char)(48 + value / 1000 % 10);
				char value15 = (char)(48 + value / 100 % 10);
				char value16 = (char)(48 + value / 10 % 10);
				char value17 = (char)(48 + value % 10);
				outputBuffer.Append(value13).Append(value14).Append(value15)
					.Append(value16)
					.Append(value17);
				return;
			}
			char[] array = new char[16];
			int num = 16;
			do
			{
				array[--num] = (char)(48 + value % 10);
				value /= 10;
			}
			while (value != 0L && num > 0);
			while (16 - num < length)
			{
				array[--num] = '0';
			}
			outputBuffer.Append(array, num, 16 - num);
		}

		internal static void AppendFraction(int value, int length, int scale, StringBuilder outputBuffer)
		{
			int num = value;
			while (scale > length)
			{
				num /= 10;
				scale = checked(scale - 1);
			}
			outputBuffer.Append('0', length);
			int num2 = checked(outputBuffer.Length - 1);
			while (num > 0)
			{
				outputBuffer[checked(num2--)] = (char)checked((ushort)(48 + unchecked(num % 10)));
				num /= 10;
			}
		}

		internal static void AppendFractionTruncate(int value, int length, int scale, StringBuilder outputBuffer)
		{
			int num = value;
			while (scale > length)
			{
				num /= 10;
				scale = checked(scale - 1);
			}
			int num2 = length;
			while (num2 > 0 && (long)num % 10L == 0L)
			{
				num /= 10;
				num2 = checked(num2 - 1);
			}
			checked
			{
				if (num2 > 0)
				{
					outputBuffer.Append('0', num2);
					int num3 = outputBuffer.Length - 1;
					unchecked
					{
						while (num > 0)
						{
							outputBuffer[checked(num3--)] = (char)checked((ushort)(48 + unchecked(num % 10)));
							num /= 10;
						}
					}
				}
				else if (outputBuffer.Length > 0 && outputBuffer[outputBuffer.Length - 1] == '.')
				{
					outputBuffer.Length--;
				}
			}
		}

		internal static void FormatInvariant(long value, StringBuilder outputBuffer)
		{
			if (value <= 0)
			{
				switch (value)
				{
				case 0L:
					outputBuffer.Append('0');
					break;
				case -9223372036854775808L:
					outputBuffer.Append("-9223372036854775808");
					break;
				default:
					outputBuffer.Append('-');
					FormatInvariant(-value, outputBuffer);
					break;
				}
			}
			else if (value < 10)
			{
				outputBuffer.Append((char)(48 + value));
			}
			else if (value < 100)
			{
				char value2 = (char)(48 + value / 10);
				char value3 = (char)(48 + value % 10);
				outputBuffer.Append(value2).Append(value3);
			}
			else if (value < 1000)
			{
				char value4 = (char)(48 + value / 100 % 10);
				char value5 = (char)(48 + value / 10 % 10);
				char value6 = (char)(48 + value % 10);
				outputBuffer.Append(value4).Append(value5).Append(value6);
			}
			else
			{
				char[] array = new char[19];
				int num = 19;
				do
				{
					array[--num] = (char)(48 + value % 10);
					value /= 10;
				}
				while (value != 0L);
				outputBuffer.Append(array, num, 19 - num);
			}
		}
	}
	[Immutable]
	public sealed class InstantPattern : IPattern<Instant>
	{
		private static class Patterns
		{
			internal static readonly InstantPattern ExtendedIsoPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFF'Z'");

			internal static readonly InstantPattern GeneralPatternImpl = CreateWithInvariantCulture("uuuu-MM-ddTHH:mm:ss'Z'");
		}

		private const string DefaultFormatPattern = "g";

		internal static readonly PatternBclSupport<Instant> BclSupport = new PatternBclSupport<Instant>("g", (NodaFormatInfo fi) => fi.InstantPatternParser);

		private readonly IPattern<Instant> pattern;

		[NotNull]
		public static InstantPattern General => Patterns.GeneralPatternImpl;

		[NotNull]
		public static InstantPattern ExtendedIso => Patterns.ExtendedIsoPatternImpl;

		[NotNull]
		public string PatternText { get; }

		private InstantPattern(string patternText, IPattern<Instant> pattern)
		{
			PatternText = patternText;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<Instant> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(Instant value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(Instant value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static InstantPattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<Instant> pattern = formatInfo.InstantPatternParser.ParsePattern(patternText);
			return new InstantPattern(patternText, pattern);
		}

		[NotNull]
		public static InstantPattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public static InstantPattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo);
		}

		[NotNull]
		public static InstantPattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo);
		}

		private InstantPattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo);
		}

		[NotNull]
		public InstantPattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}
	}
	internal sealed class InstantPatternParser : IPatternParser<Instant>
	{
		private sealed class LocalDateTimePatternAdapter : IPattern<Instant>
		{
			private readonly IPattern<LocalDateTime> pattern;

			internal LocalDateTimePatternAdapter(IPattern<LocalDateTime> pattern)
			{
				this.pattern = pattern;
			}

			public string Format(Instant value)
			{
				if (!value.IsValid)
				{
					if (!(value == Instant.BeforeMinValue))
					{
						return "EndOfTime";
					}
					return "StartOfTime";
				}
				return pattern.Format(value.InUtc().LocalDateTime);
			}

			public StringBuilder AppendFormat(Instant value, [NotNull] StringBuilder builder)
			{
				return pattern.AppendFormat(value.InUtc().LocalDateTime, builder);
			}

			public ParseResult<Instant> Parse(string text)
			{
				return pattern.Parse(text).Convert((LocalDateTime local) => new Instant(local.Date.DaysSinceEpoch, local.NanosecondOfDay));
			}
		}

		private const string GeneralPatternText = "uuuu'-'MM'-'dd'T'HH':'mm':'ss'Z'";

		internal const string BeforeMinValueText = "StartOfTime";

		internal const string AfterMaxValueText = "EndOfTime";

		public IPattern<Instant> ParsePattern([NotNull] string patternText, NodaFormatInfo formatInfo)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				if (!(patternText == "g"))
				{
					throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText, typeof(Instant));
				}
				patternText = "uuuu'-'MM'-'dd'T'HH':'mm':'ss'Z'";
			}
			return new LocalDateTimePatternAdapter(formatInfo.LocalDateTimePatternParser.ParsePattern(patternText));
		}
	}
	[Mutable]
	public sealed class InvalidPatternException : FormatException
	{
		public InvalidPatternException()
		{
		}

		public InvalidPatternException(string message)
			: base(message)
		{
		}

		internal InvalidPatternException(string formatString, params object[] parameters)
			: this(string.Format(CultureInfo.CurrentCulture, formatString, parameters))
		{
		}
	}
	internal interface IPartialPattern<T> : IPattern<T>
	{
		ParseResult<T> ParsePartial(ValueCursor cursor);
	}
	public interface IPattern<T>
	{
		[NotNull]
		ParseResult<T> Parse([SpecialNullHandling] string text);

		[NotNull]
		string Format(T value);

		[NotNull]
		StringBuilder AppendFormat(T value, [NotNull] StringBuilder builder);
	}
	[Immutable]
	public sealed class LocalDatePattern : IPattern<LocalDate>
	{
		private static class Patterns
		{
			internal static readonly LocalDatePattern IsoPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd");
		}

		internal static readonly LocalDate DefaultTemplateValue = new LocalDate(2000, 1, 1);

		private const string DefaultFormatPattern = "D";

		internal static readonly PatternBclSupport<LocalDate> BclSupport = new PatternBclSupport<LocalDate>("D", (NodaFormatInfo fi) => fi.LocalDatePatternParser);

		[NotNull]
		public static LocalDatePattern Iso => Patterns.IsoPatternImpl;

		internal IPartialPattern<LocalDate> UnderlyingPattern { get; }

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public LocalDate TemplateValue { get; }

		private LocalDatePattern(string patternText, NodaFormatInfo formatInfo, LocalDate templateValue, IPartialPattern<LocalDate> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			UnderlyingPattern = pattern;
		}

		[NotNull]
		public ParseResult<LocalDate> Parse([SpecialNullHandling] string text)
		{
			return UnderlyingPattern.Parse(text);
		}

		[NotNull]
		public string Format(LocalDate value)
		{
			return UnderlyingPattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(LocalDate value, [NotNull] StringBuilder builder)
		{
			return UnderlyingPattern.AppendFormat(value, builder);
		}

		internal static LocalDatePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, LocalDate templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<LocalDate> pattern = ((templateValue == DefaultTemplateValue) ? formatInfo.LocalDatePatternParser.ParsePattern(patternText) : new LocalDatePatternParser(templateValue).ParsePattern(patternText, formatInfo));
			IPattern<LocalDate> pattern2 = (pattern as LocalDatePattern)?.UnderlyingPattern;
			pattern = pattern2 ?? pattern;
			IPartialPattern<LocalDate> pattern3 = (IPartialPattern<LocalDate>)pattern;
			return new LocalDatePattern(patternText, formatInfo, templateValue, pattern3);
		}

		[NotNull]
		public static LocalDatePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, LocalDate templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static LocalDatePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, cultureInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static LocalDatePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static LocalDatePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		private LocalDatePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public LocalDatePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public LocalDatePattern WithTemplateValue(LocalDate newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}

		[NotNull]
		public LocalDatePattern WithCalendar([NotNull] CalendarSystem calendar)
		{
			return WithTemplateValue(TemplateValue.WithCalendar(calendar));
		}
	}
	internal sealed class LocalDatePatternParser : IPatternParser<LocalDate>
	{
		internal sealed class LocalDateParseBucket : ParseBucket<LocalDate>
		{
			internal readonly LocalDate TemplateValue;

			internal CalendarSystem Calendar;

			internal int Year;

			private Era Era;

			internal int YearOfEra;

			internal int MonthOfYearNumeric;

			internal int MonthOfYearText;

			internal int DayOfMonth;

			internal int DayOfWeek;

			internal LocalDateParseBucket(LocalDate templateValue)
			{
				TemplateValue = templateValue;
				Calendar = templateValue.Calendar;
			}

			internal ParseResult<TResult> ParseEra<TResult>(NodaFormatInfo formatInfo, ValueCursor cursor)
			{
				CompareInfo compareInfo = formatInfo.CompareInfo;
				foreach (Era era in Calendar.Eras)
				{
					foreach (string eraName in formatInfo.GetEraNames(era))
					{
						if (cursor.MatchCaseInsensitive(eraName, compareInfo, moveOnSuccess: true))
						{
							Era = era;
							return null;
						}
					}
				}
				return ParseResult<TResult>.MismatchedText(cursor, 'g');
			}

			internal override ParseResult<LocalDate> CalculateValue(PatternFields usedFields, string text)
			{
				if (usedFields.HasAny(PatternFields.EmbeddedDate))
				{
					return ParseResult<LocalDate>.ForValue(new LocalDate(Year, MonthOfYearNumeric, DayOfMonth, Calendar));
				}
				ParseResult<LocalDate> parseResult = DetermineYear(usedFields, text);
				if (parseResult != null)
				{
					return parseResult;
				}
				parseResult = DetermineMonth(usedFields, text);
				if (parseResult != null)
				{
					return parseResult;
				}
				int num = (usedFields.HasAny(PatternFields.DayOfMonth) ? DayOfMonth : TemplateValue.Day);
				if (num > Calendar.GetDaysInMonth(Year, MonthOfYearNumeric))
				{
					return ParseResult<LocalDate>.DayOfMonthOutOfRange(text, num, MonthOfYearNumeric, Year);
				}
				LocalDate value = new LocalDate(Year, MonthOfYearNumeric, num, Calendar);
				if (usedFields.HasAny(PatternFields.DayOfWeek) && DayOfWeek != (int)value.DayOfWeek)
				{
					return ParseResult<LocalDate>.InconsistentDayOfWeekTextValue(text);
				}
				return ParseResult<LocalDate>.ForValue(value);
			}

			private ParseResult<LocalDate> DetermineYear(PatternFields usedFields, string text)
			{
				if (usedFields.HasAny(PatternFields.Year))
				{
					if (Year > Calendar.MaxYear || Year < Calendar.MinYear)
					{
						return ParseResult<LocalDate>.FieldValueOutOfRangePostParse(text, Year, 'u');
					}
					if (usedFields.HasAny(PatternFields.Era) && Era != Calendar.GetEra(Year))
					{
						return ParseResult<LocalDate>.InconsistentValues(text, 'g', 'u');
					}
					if (usedFields.HasAny(PatternFields.YearOfEra))
					{
						int num = Calendar.GetYearOfEra(Year);
						if (usedFields.HasAny(PatternFields.YearTwoDigits))
						{
							num %= 100;
						}
						if (num != YearOfEra)
						{
							return ParseResult<LocalDate>.InconsistentValues(text, 'y', 'u');
						}
					}
					return null;
				}
				if (!usedFields.HasAny(PatternFields.YearOfEra))
				{
					Year = TemplateValue.Year;
					if (!usedFields.HasAny(PatternFields.Era) || Era == Calendar.GetEra(Year))
					{
						return null;
					}
					return ParseResult<LocalDate>.InconsistentValues(text, 'g', 'u');
				}
				if (!usedFields.HasAny(PatternFields.Era))
				{
					Era = TemplateValue.Era;
				}
				if (usedFields.HasAny(PatternFields.YearTwoDigits))
				{
					int num2 = TemplateValue.YearOfEra / 100;
					checked
					{
						if (YearOfEra > 30 && num2 > 1)
						{
							num2--;
						}
						YearOfEra += num2 * 100;
					}
				}
				if (YearOfEra < Calendar.GetMinYearOfEra(Era) || YearOfEra > Calendar.GetMaxYearOfEra(Era))
				{
					return ParseResult<LocalDate>.YearOfEraOutOfRange(text, YearOfEra, Era, Calendar);
				}
				Year = Calendar.GetAbsoluteYear(YearOfEra, Era);
				return null;
			}

			private ParseResult<LocalDate> DetermineMonth(PatternFields usedFields, string text)
			{
				switch (usedFields & (PatternFields.MonthOfYearNumeric | PatternFields.MonthOfYearText))
				{
				case PatternFields.MonthOfYearText:
					MonthOfYearNumeric = MonthOfYearText;
					break;
				case PatternFields.MonthOfYearNumeric | PatternFields.MonthOfYearText:
					if (MonthOfYearNumeric != MonthOfYearText)
					{
						return ParseResult<LocalDate>.InconsistentMonthValues(text);
					}
					break;
				case PatternFields.None:
					MonthOfYearNumeric = TemplateValue.Month;
					break;
				}
				if (MonthOfYearNumeric > Calendar.GetMonthsInYear(Year))
				{
					return ParseResult<LocalDate>.MonthOutOfRange(text, MonthOfYearNumeric, Year);
				}
				return null;
			}
		}

		private readonly LocalDate templateValue;

		private const int TwoDigitYearMax = 30;

		private static readonly Dictionary<char, CharacterHandler<LocalDate, LocalDateParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<LocalDate, LocalDateParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<LocalDate, LocalDateParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<LocalDate, LocalDateParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<LocalDate, LocalDateParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<LocalDate, LocalDateParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<LocalDate, LocalDateParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<LocalDate>.DateSeparatorMismatch);
				}
			},
			{
				'y',
				DatePatternHelper.CreateYearOfEraHandler((LocalDate value) => value.YearOfEra, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.YearOfEra = value;
				})
			},
			{
				'u',
				SteppedPatternBuilder<LocalDate, LocalDateParseBucket>.HandlePaddedField(4, PatternFields.Year, -9999, 9999, (LocalDate value) => value.Year, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.Year = value;
				})
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((LocalDate value) => value.Month, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.MonthOfYearText = value;
				}, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.MonthOfYearNumeric = value;
				})
			},
			{
				'd',
				DatePatternHelper.CreateDayHandler((LocalDate value) => value.Day, (LocalDate value) => (int)value.DayOfWeek, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.DayOfMonth = value;
				}, delegate(LocalDateParseBucket bucket, int value)
				{
					bucket.DayOfWeek = value;
				})
			},
			{
				'c',
				DatePatternHelper.CreateCalendarHandler((LocalDate value) => value.Calendar, delegate(LocalDateParseBucket bucket, CalendarSystem value)
				{
					bucket.Calendar = value;
				})
			},
			{
				'g',
				DatePatternHelper.CreateEraHandler((LocalDate date) => date.Era, (LocalDateParseBucket bucket) => bucket)
			}
		};

		internal LocalDatePatternParser(LocalDate templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<LocalDate> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				char c = patternText[0];
				patternText = ExpandStandardFormatPattern(c, formatInfo);
				if (patternText == null)
				{
					throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", c, typeof(LocalDate));
				}
			}
			SteppedPatternBuilder<LocalDate, LocalDateParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<LocalDate, LocalDateParseBucket>(formatInfo, () => new LocalDateParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private string ExpandStandardFormatPattern(char patternCharacter, NodaFormatInfo formatInfo)
		{
			return patternCharacter switch
			{
				'd' => formatInfo.DateTimeFormat.ShortDatePattern, 
				'D' => formatInfo.DateTimeFormat.LongDatePattern, 
				_ => null, 
			};
		}
	}
	[Immutable]
	public sealed class LocalDateTimePattern : IPattern<LocalDateTime>
	{
		internal static class Patterns
		{
			internal static readonly LocalDateTimePattern GeneralIsoPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss");

			internal static readonly LocalDateTimePattern ExtendedIsoPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFF");

			internal static readonly LocalDateTimePattern BclRoundtripPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff");

			internal static readonly LocalDateTimePattern FullRoundtripWithoutCalendarImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffff");

			internal static readonly LocalDateTimePattern FullRoundtripPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffff '('c')'");
		}

		internal static readonly LocalDateTime DefaultTemplateValue = new LocalDateTime(2000, 1, 1, 0, 0);

		private const string DefaultFormatPattern = "G";

		internal static readonly PatternBclSupport<LocalDateTime> BclSupport = new PatternBclSupport<LocalDateTime>("G", (NodaFormatInfo fi) => fi.LocalDateTimePatternParser);

		[NotNull]
		public static LocalDateTimePattern GeneralIso => Patterns.GeneralIsoPatternImpl;

		[NotNull]
		public static LocalDateTimePattern ExtendedIso => Patterns.ExtendedIsoPatternImpl;

		[NotNull]
		public static LocalDateTimePattern BclRoundtrip => Patterns.BclRoundtripPatternImpl;

		[NotNull]
		public static LocalDateTimePattern FullRoundtripWithoutCalendar => Patterns.FullRoundtripWithoutCalendarImpl;

		[NotNull]
		public static LocalDateTimePattern FullRoundtrip => Patterns.FullRoundtripPatternImpl;

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public LocalDateTime TemplateValue { get; }

		internal IPartialPattern<LocalDateTime> UnderlyingPattern { get; }

		private LocalDateTimePattern(string patternText, NodaFormatInfo formatInfo, LocalDateTime templateValue, IPartialPattern<LocalDateTime> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			UnderlyingPattern = pattern;
			TemplateValue = templateValue;
		}

		[NotNull]
		public ParseResult<LocalDateTime> Parse([SpecialNullHandling] string text)
		{
			return UnderlyingPattern.Parse(text);
		}

		[NotNull]
		public string Format(LocalDateTime value)
		{
			return UnderlyingPattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(LocalDateTime value, [NotNull] StringBuilder builder)
		{
			return UnderlyingPattern.AppendFormat(value, builder);
		}

		internal static LocalDateTimePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, LocalDateTime templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<LocalDateTime> pattern = ((templateValue == DefaultTemplateValue) ? formatInfo.LocalDateTimePatternParser.ParsePattern(patternText) : new LocalDateTimePatternParser(templateValue).ParsePattern(patternText, formatInfo));
			IPattern<LocalDateTime> pattern2 = (pattern as LocalDateTimePattern)?.UnderlyingPattern;
			pattern = pattern2 ?? pattern;
			IPartialPattern<LocalDateTime> pattern3 = (IPartialPattern<LocalDateTime>)pattern;
			return new LocalDateTimePattern(patternText, formatInfo, templateValue, pattern3);
		}

		[NotNull]
		public static LocalDateTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, LocalDateTime templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static LocalDateTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, cultureInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static LocalDateTimePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static LocalDateTimePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		private LocalDateTimePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public LocalDateTimePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public LocalDateTimePattern WithTemplateValue(LocalDateTime newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}

		[NotNull]
		public LocalDateTimePattern WithCalendar([NotNull] CalendarSystem calendar)
		{
			return WithTemplateValue(TemplateValue.WithCalendar(calendar));
		}
	}
	internal sealed class LocalDateTimePatternParser : IPatternParser<LocalDateTime>
	{
		internal sealed class LocalDateTimeParseBucket : ParseBucket<LocalDateTime>
		{
			internal readonly LocalDatePatternParser.LocalDateParseBucket Date;

			internal readonly LocalTimePatternParser.LocalTimeParseBucket Time;

			internal LocalDateTimeParseBucket(LocalDate templateValueDate, LocalTime templateValueTime)
			{
				Date = new LocalDatePatternParser.LocalDateParseBucket(templateValueDate);
				Time = new LocalTimePatternParser.LocalTimeParseBucket(templateValueTime);
			}

			internal static ParseResult<LocalDateTime> CombineBuckets(PatternFields usedFields, LocalDatePatternParser.LocalDateParseBucket dateBucket, LocalTimePatternParser.LocalTimeParseBucket timeBucket, string text)
			{
				bool flag = false;
				if (timeBucket.Hours24 == 24)
				{
					timeBucket.Hours24 = 0;
					flag = true;
				}
				ParseResult<LocalDate> parseResult = dateBucket.CalculateValue(usedFields & PatternFields.AllDateFields, text);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<LocalDateTime>();
				}
				ParseResult<LocalTime> parseResult2 = timeBucket.CalculateValue(usedFields & PatternFields.AllTimeFields, text);
				if (!parseResult2.Success)
				{
					return parseResult2.ConvertError<LocalDateTime>();
				}
				LocalDate localDate = parseResult.Value;
				LocalTime value = parseResult2.Value;
				if (flag)
				{
					if (value != LocalTime.Midnight)
					{
						return ParseResult<LocalDateTime>.InvalidHour24(text);
					}
					localDate = localDate.PlusDays(1);
				}
				return ParseResult<LocalDateTime>.ForValue(localDate + value);
			}

			internal override ParseResult<LocalDateTime> CalculateValue(PatternFields usedFields, string text)
			{
				return CombineBuckets(usedFields, Date, Time, text);
			}
		}

		private readonly LocalDate templateValueDate;

		private readonly LocalTime templateValueTime;

		private static readonly Dictionary<char, CharacterHandler<LocalDateTime, LocalDateTimeParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<LocalDateTime, LocalDateTimeParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<LocalDateTime>.DateSeparatorMismatch);
				}
			},
			{
				'T',
				delegate(PatternCursor pattern, SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket> builder)
				{
					builder.AddLiteral('T', ParseResult<LocalDateTime>.MismatchedCharacter);
				}
			},
			{
				'y',
				DatePatternHelper.CreateYearOfEraHandler((LocalDateTime value) => value.YearOfEra, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.YearOfEra = value;
				})
			},
			{
				'u',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePaddedField(4, PatternFields.Year, -9999, 9999, (LocalDateTime value) => value.Year, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.Year = value;
				})
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((LocalDateTime value) => value.Month, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearText = value;
				}, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearNumeric = value;
				})
			},
			{
				'd',
				DatePatternHelper.CreateDayHandler((LocalDateTime value) => value.Day, (LocalDateTime value) => (int)value.DayOfWeek, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfMonth = value;
				}, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfWeek = value;
				})
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler(9, (LocalDateTime value) => value.NanosecondOfSecond, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				';',
				TimePatternHelper.CreateCommaDotHandler(9, (LocalDateTime value) => value.NanosecondOfSecond, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<LocalDateTime>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours12, 1, 12, (LocalDateTime value) => value.ClockHourOfHalfDay, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours12 = value;
				})
			},
			{
				'H',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 24, (LocalDateTime value) => value.Hour, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours24 = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, (LocalDateTime value) => value.Minute, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, (LocalDateTime value) => value.Second, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Seconds = value;
				})
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler(9, (LocalDateTime value) => value.NanosecondOfSecond, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler(9, (LocalDateTime value) => value.NanosecondOfSecond, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				't',
				TimePatternHelper.CreateAmPmHandler((LocalDateTime time) => time.Hour, delegate(LocalDateTimeParseBucket bucket, int value)
				{
					bucket.Time.AmPm = value;
				})
			},
			{
				'c',
				DatePatternHelper.CreateCalendarHandler((LocalDateTime value) => value.Calendar, delegate(LocalDateTimeParseBucket bucket, CalendarSystem value)
				{
					bucket.Date.Calendar = value;
				})
			},
			{
				'g',
				DatePatternHelper.CreateEraHandler((LocalDateTime value) => value.Era, (LocalDateTimeParseBucket bucket) => bucket.Date)
			},
			{
				'l',
				delegate(PatternCursor cursor, SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket> builder)
				{
					builder.AddEmbeddedLocalPartial(cursor, (LocalDateTimeParseBucket bucket) => bucket.Date, (LocalDateTimeParseBucket bucket) => bucket.Time, (LocalDateTime value) => value.Date, (LocalDateTime value) => value.TimeOfDay, null);
				}
			}
		};

		internal LocalDateTimePatternParser(LocalDateTime templateValue)
		{
			templateValueDate = templateValue.Date;
			templateValueTime = templateValue.TimeOfDay;
		}

		public IPattern<LocalDateTime> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				char c = patternText[0];
				switch (c)
				{
				case 'O':
				case 'o':
					return LocalDateTimePattern.Patterns.BclRoundtripPatternImpl;
				case 'r':
					return LocalDateTimePattern.Patterns.FullRoundtripPatternImpl;
				case 'R':
					return LocalDateTimePattern.Patterns.FullRoundtripWithoutCalendarImpl;
				case 's':
					return LocalDateTimePattern.Patterns.GeneralIsoPatternImpl;
				}
				patternText = ExpandStandardFormatPattern(c, formatInfo);
				if (patternText == null)
				{
					throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", c, typeof(LocalDateTime));
				}
			}
			SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<LocalDateTime, LocalDateTimeParseBucket>(formatInfo, () => new LocalDateTimeParseBucket(templateValueDate, templateValueTime));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValueDate.At(templateValueTime));
		}

		private string ExpandStandardFormatPattern(char patternCharacter, NodaFormatInfo formatInfo)
		{
			return patternCharacter switch
			{
				'f' => formatInfo.DateTimeFormat.LongDatePattern + " " + formatInfo.DateTimeFormat.ShortTimePattern, 
				'F' => formatInfo.DateTimeFormat.FullDateTimePattern, 
				'g' => formatInfo.DateTimeFormat.ShortDatePattern + " " + formatInfo.DateTimeFormat.ShortTimePattern, 
				'G' => formatInfo.DateTimeFormat.ShortDatePattern + " " + formatInfo.DateTimeFormat.LongTimePattern, 
				_ => null, 
			};
		}
	}
	[Immutable]
	public sealed class LocalTimePattern : IPattern<LocalTime>
	{
		private static class Patterns
		{
			internal static readonly LocalTimePattern ExtendedIsoPatternImpl = CreateWithInvariantCulture("HH':'mm':'ss;FFFFFFFFF");
		}

		private const string DefaultFormatPattern = "T";

		internal static readonly PatternBclSupport<LocalTime> BclSupport = new PatternBclSupport<LocalTime>("T", (NodaFormatInfo fi) => fi.LocalTimePatternParser);

		[NotNull]
		public static LocalTimePattern ExtendedIso => Patterns.ExtendedIsoPatternImpl;

		internal IPartialPattern<LocalTime> UnderlyingPattern { get; }

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public LocalTime TemplateValue { get; }

		private LocalTimePattern(string patternText, NodaFormatInfo formatInfo, LocalTime templateValue, IPartialPattern<LocalTime> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			UnderlyingPattern = pattern;
		}

		[NotNull]
		public ParseResult<LocalTime> Parse([SpecialNullHandling] string text)
		{
			return UnderlyingPattern.Parse(text);
		}

		[NotNull]
		public string Format(LocalTime value)
		{
			return UnderlyingPattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(LocalTime value, [NotNull] StringBuilder builder)
		{
			return UnderlyingPattern.AppendFormat(value, builder);
		}

		internal static LocalTimePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, LocalTime templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<LocalTime> pattern = ((templateValue == LocalTime.Midnight) ? formatInfo.LocalTimePatternParser.ParsePattern(patternText) : new LocalTimePatternParser(templateValue).ParsePattern(patternText, formatInfo));
			IPattern<LocalTime> pattern2 = (pattern as LocalTimePattern)?.UnderlyingPattern;
			pattern = pattern2 ?? pattern;
			IPartialPattern<LocalTime> pattern3 = (IPartialPattern<LocalTime>)pattern;
			return new LocalTimePattern(patternText, formatInfo, templateValue, pattern3);
		}

		[NotNull]
		public static LocalTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, LocalTime templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static LocalTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, cultureInfo, LocalTime.Midnight);
		}

		[NotNull]
		public static LocalTimePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, LocalTime.Midnight);
		}

		[NotNull]
		public static LocalTimePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, LocalTime.Midnight);
		}

		private LocalTimePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public LocalTimePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public LocalTimePattern WithTemplateValue(LocalTime newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}
	}
	internal sealed class LocalTimePatternParser : IPatternParser<LocalTime>
	{
		internal sealed class LocalTimeParseBucket : ParseBucket<LocalTime>
		{
			internal readonly LocalTime TemplateValue;

			internal int FractionalSeconds;

			internal int Hours24;

			internal int Hours12;

			internal int Minutes;

			internal int Seconds;

			internal int AmPm;

			internal LocalTimeParseBucket(LocalTime templateValue)
			{
				TemplateValue = templateValue;
			}

			internal override ParseResult<LocalTime> CalculateValue(PatternFields usedFields, string text)
			{
				if (usedFields.HasAny(PatternFields.EmbeddedTime))
				{
					return ParseResult<LocalTime>.ForValue(LocalTime.FromHourMinuteSecondNanosecond(Hours24, Minutes, Seconds, FractionalSeconds));
				}
				if (AmPm == 2)
				{
					AmPm = TemplateValue.Hour / 12;
				}
				int hour;
				ParseResult<LocalTime> parseResult = DetermineHour(usedFields, text, out hour);
				if (parseResult != null)
				{
					return parseResult;
				}
				int minute = (usedFields.HasAny(PatternFields.Minutes) ? Minutes : TemplateValue.Minute);
				int second = (usedFields.HasAny(PatternFields.Seconds) ? Seconds : TemplateValue.Second);
				int num = (usedFields.HasAny(PatternFields.FractionalSeconds) ? FractionalSeconds : TemplateValue.NanosecondOfSecond);
				return ParseResult<LocalTime>.ForValue(LocalTime.FromHourMinuteSecondNanosecond(hour, minute, second, num));
			}

			private ParseResult<LocalTime> DetermineHour(PatternFields usedFields, string text, out int hour)
			{
				hour = 0;
				if (usedFields.HasAny(PatternFields.Hours24))
				{
					if (usedFields.HasAll(PatternFields.Hours12 | PatternFields.Hours24) && Hours12 % 12 != Hours24 % 12)
					{
						return ParseResult<LocalTime>.InconsistentValues(text, 'H', 'h');
					}
					if (usedFields.HasAny(PatternFields.AmPm) && Hours24 / 12 != AmPm)
					{
						return ParseResult<LocalTime>.InconsistentValues(text, 'H', 't');
					}
					hour = Hours24;
					return null;
				}
				checked
				{
					switch (usedFields & (PatternFields.Hours12 | PatternFields.AmPm))
					{
					case PatternFields.Hours12 | PatternFields.AmPm:
						hour = unchecked(Hours12 % 12) + AmPm * 12;
						break;
					case PatternFields.Hours12:
						hour = unchecked(Hours12 % 12) + unchecked(TemplateValue.Hour / 12) * 12;
						break;
					case PatternFields.AmPm:
						hour = unchecked(TemplateValue.Hour % 12) + AmPm * 12;
						break;
					case PatternFields.None:
						hour = TemplateValue.Hour;
						break;
					}
					return null;
				}
			}
		}

		private readonly LocalTime templateValue;

		private static readonly Dictionary<char, CharacterHandler<LocalTime, LocalTimeParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<LocalTime, LocalTimeParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandleBackslash
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler(9, (LocalTime value) => value.NanosecondOfSecond, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.FractionalSeconds = value;
				})
			},
			{
				';',
				TimePatternHelper.CreateCommaDotHandler(9, (LocalTime value) => value.NanosecondOfSecond, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.FractionalSeconds = value;
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<LocalTime, LocalTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<LocalTime>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours12, 1, 12, (LocalTime value) => value.ClockHourOfHalfDay, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.Hours12 = value;
				})
			},
			{
				'H',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 23, (LocalTime value) => value.Hour, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.Hours24 = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, (LocalTime value) => value.Minute, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, (LocalTime value) => value.Second, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.Seconds = value;
				})
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler(9, (LocalTime value) => value.NanosecondOfSecond, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.FractionalSeconds = value;
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler(9, (LocalTime value) => value.NanosecondOfSecond, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.FractionalSeconds = value;
				})
			},
			{
				't',
				TimePatternHelper.CreateAmPmHandler((LocalTime time) => time.Hour, delegate(LocalTimeParseBucket bucket, int value)
				{
					bucket.AmPm = value;
				})
			}
		};

		public LocalTimePatternParser(LocalTime templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<LocalTime> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				char c = patternText[0];
				patternText = ExpandStandardFormatPattern(c, formatInfo);
				if (patternText == null)
				{
					throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", c, typeof(LocalTime));
				}
			}
			SteppedPatternBuilder<LocalTime, LocalTimeParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<LocalTime, LocalTimeParseBucket>(formatInfo, () => new LocalTimeParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private string ExpandStandardFormatPattern(char patternCharacter, NodaFormatInfo formatInfo)
		{
			return patternCharacter switch
			{
				't' => formatInfo.DateTimeFormat.ShortTimePattern, 
				'T' => formatInfo.DateTimeFormat.LongTimePattern, 
				'r' => "HH:mm:ss.FFFFFFFFF", 
				_ => null, 
			};
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	[Immutable]
	public sealed class OffsetDatePattern : IPattern<OffsetDate>
	{
		internal static class Patterns
		{
			internal static readonly OffsetDatePattern GeneralIsoPatternImpl = Create("uuuu'-'MM'-'ddo<G>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetDatePattern FullRoundtripPatternImpl = Create("uuuu'-'MM'-'ddo<G> '('c')'", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly PatternBclSupport<OffsetDate> BclSupport = new PatternBclSupport<OffsetDate>("G", (NodaFormatInfo fi) => fi.OffsetDatePatternParser);
		}

		internal static readonly OffsetDate DefaultTemplateValue = new LocalDate(2000, 1, 1).WithOffset(Offset.Zero);

		private readonly IPattern<OffsetDate> pattern;

		[NotNull]
		public static OffsetDatePattern GeneralIso => Patterns.GeneralIsoPatternImpl;

		[NotNull]
		public static OffsetDatePattern FullRoundtrip => Patterns.FullRoundtripPatternImpl;

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public OffsetDate TemplateValue { get; }

		private OffsetDatePattern(string patternText, NodaFormatInfo formatInfo, OffsetDate templateValue, IPattern<OffsetDate> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<OffsetDate> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(OffsetDate value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(OffsetDate value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static OffsetDatePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, OffsetDate templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<OffsetDate> pattern = new OffsetDatePatternParser(templateValue).ParsePattern(patternText, formatInfo);
			return new OffsetDatePattern(patternText, formatInfo, templateValue, pattern);
		}

		[NotNull]
		public static OffsetDatePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, OffsetDate templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static OffsetDatePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static OffsetDatePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public OffsetDatePattern WithPatternText([NotNull] string patternText)
		{
			return Create(patternText, FormatInfo, TemplateValue);
		}

		private OffsetDatePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public OffsetDatePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public OffsetDatePattern WithTemplateValue(OffsetDate newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}

		[NotNull]
		public OffsetDatePattern WithCalendar([NotNull] CalendarSystem calendar)
		{
			return WithTemplateValue(TemplateValue.WithCalendar(calendar));
		}
	}
	internal sealed class OffsetDatePatternParser : IPatternParser<OffsetDate>
	{
		private sealed class OffsetDateParseBucket : ParseBucket<OffsetDate>
		{
			internal readonly LocalDatePatternParser.LocalDateParseBucket Date;

			internal Offset Offset;

			internal OffsetDateParseBucket(OffsetDate templateValue)
			{
				Date = new LocalDatePatternParser.LocalDateParseBucket(templateValue.Date);
				Offset = templateValue.Offset;
			}

			internal override ParseResult<OffsetDate> CalculateValue(PatternFields usedFields, string text)
			{
				ParseResult<LocalDate> parseResult = Date.CalculateValue(usedFields & PatternFields.AllDateFields, text);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<OffsetDate>();
				}
				return ParseResult<OffsetDate>.ForValue(parseResult.Value.WithOffset(Offset));
			}
		}

		private readonly OffsetDate templateValue;

		private static readonly Dictionary<char, CharacterHandler<OffsetDate, OffsetDateParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<OffsetDate, OffsetDateParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<OffsetDate>.DateSeparatorMismatch);
				}
			},
			{
				'y',
				DatePatternHelper.CreateYearOfEraHandler((OffsetDate value) => value.YearOfEra, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.YearOfEra = value;
				})
			},
			{
				'u',
				SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>.HandlePaddedField(4, PatternFields.Year, -9999, 9999, (OffsetDate value) => value.Year, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.Year = value;
				})
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((OffsetDate value) => value.Month, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearText = value;
				}, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearNumeric = value;
				})
			},
			{
				'd',
				DatePatternHelper.CreateDayHandler((OffsetDate value) => value.Day, (OffsetDate value) => (int)value.DayOfWeek, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.DayOfMonth = value;
				}, delegate(OffsetDateParseBucket bucket, int value)
				{
					bucket.Date.DayOfWeek = value;
				})
			},
			{
				'c',
				DatePatternHelper.CreateCalendarHandler((OffsetDate value) => value.Date.Calendar, delegate(OffsetDateParseBucket bucket, CalendarSystem value)
				{
					bucket.Date.Calendar = value;
				})
			},
			{
				'g',
				DatePatternHelper.CreateEraHandler((OffsetDate value) => value.Era, (OffsetDateParseBucket bucket) => bucket.Date)
			},
			{ 'o', HandleOffset },
			{
				'l',
				delegate(PatternCursor cursor, SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket> builder)
				{
					builder.AddEmbeddedDatePattern(cursor.Current, cursor.GetEmbeddedPattern(), (OffsetDateParseBucket bucket) => bucket.Date, (OffsetDate value) => value.Date);
				}
			}
		};

		internal OffsetDatePatternParser(OffsetDate templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<OffsetDate> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				return patternText[0] switch
				{
					'G' => OffsetDatePattern.Patterns.GeneralIsoPatternImpl, 
					'r' => OffsetDatePattern.Patterns.FullRoundtripPatternImpl, 
					_ => throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(OffsetDate)), 
				};
			}
			SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket>(formatInfo, () => new OffsetDateParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private static void HandleOffset(PatternCursor pattern, SteppedPatternBuilder<OffsetDate, OffsetDateParseBucket> builder)
		{
			builder.AddField(PatternFields.EmbeddedOffset, pattern.Current);
			IPartialPattern<Offset> underlyingPattern = OffsetPattern.Create(pattern.GetEmbeddedPattern(), builder.FormatInfo).UnderlyingPattern;
			builder.AddEmbeddedPattern(underlyingPattern, delegate(OffsetDateParseBucket bucket, Offset offset)
			{
				bucket.Offset = offset;
			}, (OffsetDate zdt) => zdt.Offset);
		}
	}
	[Immutable]
	public sealed class OffsetDateTimePattern : IPattern<OffsetDateTime>
	{
		internal static class Patterns
		{
			internal static readonly OffsetDateTimePattern GeneralIsoPatternImpl = Create("uuuu'-'MM'-'dd'T'HH':'mm':'sso<G>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetDateTimePattern ExtendedIsoPatternImpl = Create("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFFo<G>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetDateTimePattern Rfc3339PatternImpl = Create("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFFo<Z+HH:mm>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetDateTimePattern FullRoundtripPatternImpl = Create("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFFo<G> '('c')'", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly PatternBclSupport<OffsetDateTime> BclSupport = new PatternBclSupport<OffsetDateTime>("G", (NodaFormatInfo fi) => fi.OffsetDateTimePatternParser);
		}

		internal static readonly OffsetDateTime DefaultTemplateValue = new LocalDateTime(2000, 1, 1, 0, 0).WithOffset(Offset.Zero);

		private readonly IPattern<OffsetDateTime> pattern;

		[NotNull]
		public static OffsetDateTimePattern GeneralIso => Patterns.GeneralIsoPatternImpl;

		[NotNull]
		public static OffsetDateTimePattern ExtendedIso => Patterns.ExtendedIsoPatternImpl;

		[NotNull]
		public static OffsetDateTimePattern Rfc3339 => Patterns.Rfc3339PatternImpl;

		[NotNull]
		public static OffsetDateTimePattern FullRoundtrip => Patterns.FullRoundtripPatternImpl;

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public OffsetDateTime TemplateValue { get; }

		private OffsetDateTimePattern(string patternText, NodaFormatInfo formatInfo, OffsetDateTime templateValue, IPattern<OffsetDateTime> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<OffsetDateTime> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(OffsetDateTime value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(OffsetDateTime value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static OffsetDateTimePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, OffsetDateTime templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<OffsetDateTime> pattern = new OffsetDateTimePatternParser(templateValue).ParsePattern(patternText, formatInfo);
			return new OffsetDateTimePattern(patternText, formatInfo, templateValue, pattern);
		}

		[NotNull]
		public static OffsetDateTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, OffsetDateTime templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static OffsetDateTimePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static OffsetDateTimePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public OffsetDateTimePattern WithPatternText([NotNull] string patternText)
		{
			return Create(patternText, FormatInfo, TemplateValue);
		}

		private OffsetDateTimePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public OffsetDateTimePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public OffsetDateTimePattern WithTemplateValue(OffsetDateTime newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}

		[NotNull]
		public OffsetDateTimePattern WithCalendar([NotNull] CalendarSystem calendar)
		{
			return WithTemplateValue(TemplateValue.WithCalendar(calendar));
		}
	}
	internal sealed class OffsetDateTimePatternParser : IPatternParser<OffsetDateTime>
	{
		private sealed class OffsetDateTimeParseBucket : ParseBucket<OffsetDateTime>
		{
			internal readonly LocalDatePatternParser.LocalDateParseBucket Date;

			internal readonly LocalTimePatternParser.LocalTimeParseBucket Time;

			internal Offset Offset;

			internal OffsetDateTimeParseBucket(OffsetDateTime templateValue)
			{
				Date = new LocalDatePatternParser.LocalDateParseBucket(templateValue.Date);
				Time = new LocalTimePatternParser.LocalTimeParseBucket(templateValue.TimeOfDay);
				Offset = templateValue.Offset;
			}

			internal override ParseResult<OffsetDateTime> CalculateValue(PatternFields usedFields, string text)
			{
				ParseResult<LocalDateTime> parseResult = LocalDateTimePatternParser.LocalDateTimeParseBucket.CombineBuckets(usedFields, Date, Time, text);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<OffsetDateTime>();
				}
				return ParseResult<OffsetDateTime>.ForValue(parseResult.Value.WithOffset(Offset));
			}
		}

		private readonly OffsetDateTime templateValue;

		private static readonly Dictionary<char, CharacterHandler<OffsetDateTime, OffsetDateTimeParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<OffsetDateTime, OffsetDateTimeParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<OffsetDateTime>.DateSeparatorMismatch);
				}
			},
			{
				'T',
				delegate(PatternCursor pattern, SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> builder)
				{
					builder.AddLiteral('T', ParseResult<OffsetDateTime>.MismatchedCharacter);
				}
			},
			{
				'y',
				DatePatternHelper.CreateYearOfEraHandler((OffsetDateTime value) => value.YearOfEra, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.YearOfEra = value;
				})
			},
			{
				'u',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePaddedField(4, PatternFields.Year, -9999, 9999, (OffsetDateTime value) => value.Year, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.Year = value;
				})
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((OffsetDateTime value) => value.Month, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearText = value;
				}, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearNumeric = value;
				})
			},
			{
				'd',
				DatePatternHelper.CreateDayHandler((OffsetDateTime value) => value.Day, (OffsetDateTime value) => (int)value.DayOfWeek, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfMonth = value;
				}, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfWeek = value;
				})
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler(9, (OffsetDateTime value) => value.NanosecondOfSecond, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				';',
				TimePatternHelper.CreateCommaDotHandler(9, (OffsetDateTime value) => value.NanosecondOfSecond, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<OffsetDateTime>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours12, 1, 12, (OffsetDateTime value) => value.ClockHourOfHalfDay, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours12 = value;
				})
			},
			{
				'H',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 24, (OffsetDateTime value) => value.Hour, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours24 = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, (OffsetDateTime value) => value.Minute, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, (OffsetDateTime value) => value.Second, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Seconds = value;
				})
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler(9, (OffsetDateTime value) => value.NanosecondOfSecond, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler(9, (OffsetDateTime value) => value.NanosecondOfSecond, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				't',
				TimePatternHelper.CreateAmPmHandler((OffsetDateTime time) => time.Hour, delegate(OffsetDateTimeParseBucket bucket, int value)
				{
					bucket.Time.AmPm = value;
				})
			},
			{
				'c',
				DatePatternHelper.CreateCalendarHandler((OffsetDateTime value) => value.LocalDateTime.Calendar, delegate(OffsetDateTimeParseBucket bucket, CalendarSystem value)
				{
					bucket.Date.Calendar = value;
				})
			},
			{
				'g',
				DatePatternHelper.CreateEraHandler((OffsetDateTime value) => value.Era, (OffsetDateTimeParseBucket bucket) => bucket.Date)
			},
			{ 'o', HandleOffset },
			{
				'l',
				delegate(PatternCursor cursor, SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> builder)
				{
					builder.AddEmbeddedLocalPartial(cursor, (OffsetDateTimeParseBucket bucket) => bucket.Date, (OffsetDateTimeParseBucket bucket) => bucket.Time, (OffsetDateTime value) => value.Date, (OffsetDateTime value) => value.TimeOfDay, (OffsetDateTime value) => value.LocalDateTime);
				}
			}
		};

		internal OffsetDateTimePatternParser(OffsetDateTime templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<OffsetDateTime> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				return patternText[0] switch
				{
					'G' => OffsetDateTimePattern.Patterns.GeneralIsoPatternImpl, 
					'o' => OffsetDateTimePattern.Patterns.ExtendedIsoPatternImpl, 
					'r' => OffsetDateTimePattern.Patterns.FullRoundtripPatternImpl, 
					_ => throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(OffsetDateTime)), 
				};
			}
			SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket>(formatInfo, () => new OffsetDateTimeParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private static void HandleOffset(PatternCursor pattern, SteppedPatternBuilder<OffsetDateTime, OffsetDateTimeParseBucket> builder)
		{
			builder.AddField(PatternFields.EmbeddedOffset, pattern.Current);
			IPartialPattern<Offset> underlyingPattern = OffsetPattern.Create(pattern.GetEmbeddedPattern(), builder.FormatInfo).UnderlyingPattern;
			builder.AddEmbeddedPattern(underlyingPattern, delegate(OffsetDateTimeParseBucket bucket, Offset offset)
			{
				bucket.Offset = offset;
			}, (OffsetDateTime zdt) => zdt.Offset);
		}
	}
	[Immutable]
	public sealed class OffsetPattern : IPattern<Offset>
	{
		private const string DefaultFormatPattern = "g";

		internal static readonly PatternBclSupport<Offset> BclSupport = new PatternBclSupport<Offset>("g", (NodaFormatInfo fi) => fi.OffsetPatternParser);

		[NotNull]
		public static OffsetPattern GeneralInvariant { get; } = CreateWithInvariantCulture("g");

		[NotNull]
		public static OffsetPattern GeneralInvariantWithZ { get; } = CreateWithInvariantCulture("G");

		[NotNull]
		public string PatternText { get; }

		internal IPartialPattern<Offset> UnderlyingPattern { get; }

		private OffsetPattern(string patternText, IPartialPattern<Offset> pattern)
		{
			PatternText = patternText;
			UnderlyingPattern = pattern;
		}

		[NotNull]
		public ParseResult<Offset> Parse([SpecialNullHandling] string text)
		{
			return UnderlyingPattern.Parse(text);
		}

		[NotNull]
		public string Format(Offset value)
		{
			return UnderlyingPattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(Offset value, [NotNull] StringBuilder builder)
		{
			return UnderlyingPattern.AppendFormat(value, builder);
		}

		internal static OffsetPattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPartialPattern<Offset> pattern = (IPartialPattern<Offset>)formatInfo.OffsetPatternParser.ParsePattern(patternText);
			return new OffsetPattern(patternText, pattern);
		}

		[NotNull]
		public static OffsetPattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public static OffsetPattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo);
		}

		[NotNull]
		public static OffsetPattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo);
		}

		[NotNull]
		public OffsetPattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return Create(PatternText, NodaFormatInfo.GetFormatInfo(cultureInfo));
		}
	}
	internal sealed class OffsetPatternParser : IPatternParser<Offset>
	{
		private sealed class ZPrefixPattern : IPartialPattern<Offset>, IPattern<Offset>
		{
			private readonly IPartialPattern<Offset> fullPattern;

			internal ZPrefixPattern(IPartialPattern<Offset> fullPattern)
			{
				this.fullPattern = fullPattern;
			}

			public ParseResult<Offset> Parse(string text)
			{
				if (!(text == "Z"))
				{
					return fullPattern.Parse(text);
				}
				return ParseResult<Offset>.ForValue(Offset.Zero);
			}

			public string Format(Offset value)
			{
				if (!(value == Offset.Zero))
				{
					return fullPattern.Format(value);
				}
				return "Z";
			}

			public ParseResult<Offset> ParsePartial(ValueCursor cursor)
			{
				if (cursor.Current == 'Z')
				{
					cursor.MoveNext();
					return ParseResult<Offset>.ForValue(Offset.Zero);
				}
				return fullPattern.ParsePartial(cursor);
			}

			public StringBuilder AppendFormat(Offset value, [NotNull] StringBuilder builder)
			{
				Preconditions.CheckNotNull(builder, "builder");
				if (!(value == Offset.Zero))
				{
					return fullPattern.AppendFormat(value, builder);
				}
				return builder.Append("Z");
			}
		}

		[DebuggerStepThrough]
		private sealed class OffsetParseBucket : ParseBucket<Offset>
		{
			internal int Hours;

			internal int Minutes;

			internal int Seconds;

			public bool IsNegative;

			internal override ParseResult<Offset> CalculateValue(PatternFields usedFields, string text)
			{
				checked
				{
					int num = Hours * 3600 + Minutes * 60 + Seconds;
					if (IsNegative)
					{
						num = -num;
					}
					return ParseResult<Offset>.ForValue(Offset.FromSeconds(num));
				}
			}
		}

		private static readonly Dictionary<char, CharacterHandler<Offset, OffsetParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<Offset, OffsetParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandleBackslash
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<Offset, OffsetParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<Offset>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				delegate
				{
					throw new InvalidPatternException("The 'h' pattern flag (12 hour format) is not supported by the {0} type.", typeof(Offset));
				}
			},
			{
				'H',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 23, GetPositiveHours, delegate(OffsetParseBucket bucket, int value)
				{
					bucket.Hours = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, GetPositiveMinutes, delegate(OffsetParseBucket bucket, int value)
				{
					bucket.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<Offset, OffsetParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, GetPositiveSeconds, delegate(OffsetParseBucket bucket, int value)
				{
					bucket.Seconds = value;
				})
			},
			{ '+', HandlePlus },
			{ '-', HandleMinus },
			{
				'Z',
				delegate
				{
					throw new InvalidPatternException("The Z prefix for an Offset pattern must occur at the beginning of the pattern.");
				}
			}
		};

		private static int GetPositiveHours(Offset offset)
		{
			return Math.Abs(offset.Milliseconds) / 3600000;
		}

		private static int GetPositiveMinutes(Offset offset)
		{
			return Math.Abs(offset.Milliseconds) % 3600000 / 60000;
		}

		private static int GetPositiveSeconds(Offset offset)
		{
			return Math.Abs(offset.Milliseconds) % 60000 / 1000;
		}

		public IPattern<Offset> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			return ParsePartialPattern(patternText, formatInfo);
		}

		private IPartialPattern<Offset> ParsePartialPattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				switch (patternText)
				{
				case "g":
					return new CompositePatternBuilder<Offset>
					{
						{
							ParsePartialPattern(formatInfo.OffsetPatternLong, formatInfo),
							(Offset offset) => true
						},
						{
							ParsePartialPattern(formatInfo.OffsetPatternMedium, formatInfo),
							HasZeroSeconds
						},
						{
							ParsePartialPattern(formatInfo.OffsetPatternShort, formatInfo),
							HasZeroSecondsAndMinutes
						}
					}.BuildAsPartial();
				case "G":
					return new ZPrefixPattern(ParsePartialPattern("g", formatInfo));
				case "i":
					return new CompositePatternBuilder<Offset>
					{
						{
							ParsePartialPattern(formatInfo.OffsetPatternLongNoPunctuation, formatInfo),
							(Offset offset) => true
						},
						{
							ParsePartialPattern(formatInfo.OffsetPatternMediumNoPunctuation, formatInfo),
							HasZeroSeconds
						},
						{
							ParsePartialPattern(formatInfo.OffsetPatternShortNoPunctuation, formatInfo),
							HasZeroSecondsAndMinutes
						}
					}.BuildAsPartial();
				case "I":
					return new ZPrefixPattern(ParsePartialPattern("i", formatInfo));
				case "l":
					patternText = formatInfo.OffsetPatternLong;
					break;
				case "m":
					patternText = formatInfo.OffsetPatternMedium;
					break;
				case "s":
					patternText = formatInfo.OffsetPatternShort;
					break;
				case "L":
					patternText = formatInfo.OffsetPatternLongNoPunctuation;
					break;
				case "M":
					patternText = formatInfo.OffsetPatternMediumNoPunctuation;
					break;
				case "S":
					patternText = formatInfo.OffsetPatternShortNoPunctuation;
					break;
				default:
					throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText, typeof(Offset));
				}
			}
			if (patternText == "%Z")
			{
				throw new InvalidPatternException("The Z prefix for an Offset pattern must be followed by a custom pattern.");
			}
			bool flag = patternText.StartsWith("Z");
			SteppedPatternBuilder<Offset, OffsetParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<Offset, OffsetParseBucket>(formatInfo, () => new OffsetParseBucket());
			steppedPatternBuilder.ParseCustomPattern(flag ? patternText.Substring(1) : patternText, PatternCharacterHandlers);
			IPartialPattern<Offset> partialPattern = steppedPatternBuilder.Build(Offset.FromHoursAndMinutes(5, 30));
			if (!flag)
			{
				return partialPattern;
			}
			return new ZPrefixPattern(partialPattern);
		}

		private static bool HasZeroSeconds(Offset offset)
		{
			return offset.Seconds % 60 == 0;
		}

		private static bool HasZeroSecondsAndMinutes(Offset offset)
		{
			return offset.Seconds % 3600 == 0;
		}

		private static void HandlePlus(PatternCursor pattern, SteppedPatternBuilder<Offset, OffsetParseBucket> builder)
		{
			builder.AddField(PatternFields.Sign, pattern.Current);
			builder.AddRequiredSign(delegate(OffsetParseBucket bucket, bool positive)
			{
				bucket.IsNegative = !positive;
			}, (Offset offset) => offset.Milliseconds >= 0);
		}

		private static void HandleMinus(PatternCursor pattern, SteppedPatternBuilder<Offset, OffsetParseBucket> builder)
		{
			builder.AddField(PatternFields.Sign, pattern.Current);
			builder.AddNegativeOnlySign(delegate(OffsetParseBucket bucket, bool positive)
			{
				bucket.IsNegative = !positive;
			}, (Offset offset) => offset.Milliseconds >= 0);
		}
	}
	[Immutable]
	public sealed class OffsetTimePattern : IPattern<OffsetTime>
	{
		internal static class Patterns
		{
			internal static readonly OffsetTimePattern GeneralIsoPatternImpl = Create("HH':'mm':'sso<G>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetTimePattern ExtendedIsoPatternImpl = Create("HH':'mm':'ss;FFFFFFFFFo<G>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly OffsetTimePattern Rfc3339PatternImpl = Create("HH':'mm':'ss;FFFFFFFFFo<Z+HH:mm>", NodaFormatInfo.InvariantInfo, DefaultTemplateValue);

			internal static readonly PatternBclSupport<OffsetTime> BclSupport = new PatternBclSupport<OffsetTime>("G", (NodaFormatInfo fi) => fi.OffsetTimePatternParser);
		}

		internal static readonly OffsetTime DefaultTemplateValue = LocalTime.Midnight.WithOffset(Offset.Zero);

		private readonly IPattern<OffsetTime> pattern;

		[NotNull]
		public static OffsetTimePattern GeneralIso => Patterns.GeneralIsoPatternImpl;

		[NotNull]
		public static OffsetTimePattern ExtendedIso => Patterns.ExtendedIsoPatternImpl;

		[NotNull]
		public static OffsetTimePattern Rfc3339 => Patterns.Rfc3339PatternImpl;

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public OffsetTime TemplateValue { get; }

		private OffsetTimePattern(string patternText, NodaFormatInfo formatInfo, OffsetTime templateValue, IPattern<OffsetTime> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<OffsetTime> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(OffsetTime value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(OffsetTime value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static OffsetTimePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, OffsetTime templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<OffsetTime> pattern = new OffsetTimePatternParser(templateValue).ParsePattern(patternText, formatInfo);
			return new OffsetTimePattern(patternText, formatInfo, templateValue, pattern);
		}

		[NotNull]
		public static OffsetTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, OffsetTime templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), templateValue);
		}

		[NotNull]
		public static OffsetTimePattern CreateWithInvariantCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, DefaultTemplateValue);
		}

		[NotNull]
		public static OffsetTimePattern CreateWithCurrentCulture([NotNull] string patternText)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, DefaultTemplateValue);
		}

		[NotNull]
		public OffsetTimePattern WithPatternText([NotNull] string patternText)
		{
			return Create(patternText, FormatInfo, TemplateValue);
		}

		private OffsetTimePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, TemplateValue);
		}

		[NotNull]
		public OffsetTimePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public OffsetTimePattern WithTemplateValue(OffsetTime newTemplateValue)
		{
			return Create(PatternText, FormatInfo, newTemplateValue);
		}
	}
	internal sealed class OffsetTimePatternParser : IPatternParser<OffsetTime>
	{
		private sealed class OffsetTimeParseBucket : ParseBucket<OffsetTime>
		{
			internal readonly LocalTimePatternParser.LocalTimeParseBucket Time;

			internal Offset Offset;

			internal OffsetTimeParseBucket(OffsetTime templateValue)
			{
				Time = new LocalTimePatternParser.LocalTimeParseBucket(templateValue.TimeOfDay);
				Offset = templateValue.Offset;
			}

			internal override ParseResult<OffsetTime> CalculateValue(PatternFields usedFields, string text)
			{
				ParseResult<LocalTime> parseResult = Time.CalculateValue(usedFields & PatternFields.AllTimeFields, text);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<OffsetTime>();
				}
				return ParseResult<OffsetTime>.ForValue(parseResult.Value.WithOffset(Offset));
			}
		}

		private readonly OffsetTime templateValue;

		private static readonly Dictionary<char, CharacterHandler<OffsetTime, OffsetTimeParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<OffsetTime, OffsetTimeParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandleBackslash
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler(9, (OffsetTime value) => value.NanosecondOfSecond, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				';',
				TimePatternHelper.CreateCommaDotHandler(9, (OffsetTime value) => value.NanosecondOfSecond, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<OffsetTime>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours12, 1, 12, (OffsetTime value) => value.ClockHourOfHalfDay, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours12 = value;
				})
			},
			{
				'H',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 24, (OffsetTime value) => value.Hour, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours24 = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, (OffsetTime value) => value.Minute, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, (OffsetTime value) => value.Second, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.Seconds = value;
				})
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler(9, (OffsetTime value) => value.NanosecondOfSecond, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler(9, (OffsetTime value) => value.NanosecondOfSecond, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				't',
				TimePatternHelper.CreateAmPmHandler((OffsetTime time) => time.Hour, delegate(OffsetTimeParseBucket bucket, int value)
				{
					bucket.Time.AmPm = value;
				})
			},
			{ 'o', HandleOffset },
			{
				'l',
				delegate(PatternCursor cursor, SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket> builder)
				{
					builder.AddEmbeddedTimePattern(cursor.Current, cursor.GetEmbeddedPattern(), (OffsetTimeParseBucket bucket) => bucket.Time, (OffsetTime value) => value.TimeOfDay);
				}
			}
		};

		internal OffsetTimePatternParser(OffsetTime templateValue)
		{
			this.templateValue = templateValue;
		}

		public IPattern<OffsetTime> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				return patternText[0] switch
				{
					'G' => OffsetTimePattern.Patterns.GeneralIsoPatternImpl, 
					'o' => OffsetTimePattern.Patterns.ExtendedIsoPatternImpl, 
					_ => throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(OffsetTime)), 
				};
			}
			SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket>(formatInfo, () => new OffsetTimeParseBucket(templateValue));
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private static void HandleOffset(PatternCursor pattern, SteppedPatternBuilder<OffsetTime, OffsetTimeParseBucket> builder)
		{
			builder.AddField(PatternFields.EmbeddedOffset, pattern.Current);
			IPartialPattern<Offset> underlyingPattern = OffsetPattern.Create(pattern.GetEmbeddedPattern(), builder.FormatInfo).UnderlyingPattern;
			builder.AddEmbeddedPattern(underlyingPattern, delegate(OffsetTimeParseBucket bucket, Offset offset)
			{
				bucket.Offset = offset;
			}, (OffsetTime zdt) => zdt.Offset);
		}
	}
	internal abstract class ParseBucket<T>
	{
		internal abstract ParseResult<T> CalculateValue(PatternFields usedFields, string value);
	}
	[Immutable]
	public sealed class ParseResult<T>
	{
		private readonly T value;

		private readonly Func<Exception> exceptionProvider;

		internal static readonly ParseResult<T> ValueStringEmpty = new ParseResult<T>(() => new UnparsableValueException(string.Format(CultureInfo.CurrentCulture, "The value string is empty.")), continueWithMultiple: false);

		internal static readonly ParseResult<T> FormatOnlyPattern = new ParseResult<T>(() => new UnparsableValueException(string.Format(CultureInfo.CurrentCulture, "This pattern is only capable of formatting, not parsing.")), continueWithMultiple: true);

		internal bool ContinueAfterErrorWithMultipleFormats { get; }

		public T Value => GetValueOrThrow();

		[NotNull]
		public Exception Exception
		{
			get
			{
				if (exceptionProvider == null)
				{
					throw new InvalidOperationException("Parse operation succeeded, so no exception is available");
				}
				return exceptionProvider();
			}
		}

		public bool Success => exceptionProvider == null;

		private ParseResult(Func<Exception> exceptionProvider, bool continueWithMultiple)
		{
			this.exceptionProvider = exceptionProvider;
			ContinueAfterErrorWithMultipleFormats = continueWithMultiple;
		}

		private ParseResult(T value)
		{
			this.value = value;
		}

		public T GetValueOrThrow()
		{
			if (exceptionProvider == null)
			{
				return value;
			}
			throw exceptionProvider();
		}

		public bool TryGetValue(T failureValue, out T result)
		{
			bool flag = exceptionProvider == null;
			result = (flag ? value : failureValue);
			return flag;
		}

		[NotNull]
		public ParseResult<TTarget> Convert<TTarget>([NotNull] Func<T, TTarget> projection)
		{
			Preconditions.CheckNotNull(projection, "projection");
			if (!Success)
			{
				return new ParseResult<TTarget>(exceptionProvider, ContinueAfterErrorWithMultipleFormats);
			}
			return ParseResult<TTarget>.ForValue(projection(Value));
		}

		[NotNull]
		public ParseResult<TTarget> ConvertError<TTarget>()
		{
			if (Success)
			{
				throw new InvalidOperationException("ConvertError should not be called on a successful parse result");
			}
			return new ParseResult<TTarget>(exceptionProvider, ContinueAfterErrorWithMultipleFormats);
		}

		[NotNull]
		public static ParseResult<T> ForValue(T value)
		{
			return new ParseResult<T>(value);
		}

		[NotNull]
		public static ParseResult<T> ForException([NotNull] Func<Exception> exceptionProvider)
		{
			return new ParseResult<T>(Preconditions.CheckNotNull(exceptionProvider, "exceptionProvider"), continueWithMultiple: false);
		}

		internal static ParseResult<T> ForInvalidValue(ValueCursor cursor, string formatString, params object[] parameters)
		{
			return ForInvalidValue(delegate
			{
				string arg = string.Format(CultureInfo.CurrentCulture, formatString, parameters);
				return new UnparsableValueException(string.Format(CultureInfo.CurrentCulture, "{0} Value being parsed: '{1}'. (^ indicates error position.)", arg, cursor));
			});
		}

		internal static ParseResult<T> ForInvalidValuePostParse(string text, string formatString, params object[] parameters)
		{
			return ForInvalidValue(delegate
			{
				string arg = string.Format(CultureInfo.CurrentCulture, formatString, parameters);
				return new UnparsableValueException(string.Format(CultureInfo.CurrentCulture, "{0} Value being parsed: '{1}'.", arg, text));
			});
		}

		private static ParseResult<T> ForInvalidValue(Func<Exception> exceptionProvider)
		{
			return new ParseResult<T>(exceptionProvider, continueWithMultiple: true);
		}

		internal static ParseResult<T> ArgumentNull(string parameter)
		{
			return new ParseResult<T>(() => new ArgumentNullException(parameter), continueWithMultiple: false);
		}

		internal static ParseResult<T> PositiveSignInvalid(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "A positive value sign is not valid at this point.");
		}

		internal static ParseResult<T> ExtraValueCharacters(ValueCursor cursor, string remainder)
		{
			return ForInvalidValue(cursor, "The format matches a prefix of the value string but not the entire string. Part not matching: \"{0}\".", remainder);
		}

		internal static ParseResult<T> QuotedStringMismatch(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string does not match a quoted string in the pattern.");
		}

		internal static ParseResult<T> EscapedCharacterMismatch(ValueCursor cursor, char patternCharacter)
		{
			return ForInvalidValue(cursor, "The value string does not match an escaped character in the format string: \"{0}\"", patternCharacter);
		}

		internal static ParseResult<T> EndOfString(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "Input string ended unexpectedly early.");
		}

		internal static ParseResult<T> TimeSeparatorMismatch(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string does not match a time separator in the format string.");
		}

		internal static ParseResult<T> DateSeparatorMismatch(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string does not match a date separator in the format string.");
		}

		internal static ParseResult<T> MissingNumber(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string does not include a number in the expected position.");
		}

		internal static ParseResult<T> UnexpectedNegative(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string includes a negative value where only a non-negative one is allowed.");
		}

		internal static ParseResult<T> MismatchedNumber(ValueCursor cursor, string pattern)
		{
			return ForInvalidValue(cursor, "The value string does not match the required number from the format string \"{0}\".", pattern);
		}

		internal static ParseResult<T> MismatchedCharacter(ValueCursor cursor, char patternCharacter)
		{
			return ForInvalidValue(cursor, "The value string does not match a simple character in the format string \"{0}\".", patternCharacter);
		}

		internal static ParseResult<T> MismatchedText(ValueCursor cursor, char field)
		{
			return ForInvalidValue(cursor, "The value string does not match the text-based field '{0}'.", field);
		}

		internal static ParseResult<T> NoMatchingFormat(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "None of the specified formats matches the given value string.");
		}

		internal static ParseResult<T> ValueOutOfRange(ValueCursor cursor, object value)
		{
			return ForInvalidValue(cursor, "The value {0} is out of the legal range for the {1} type.", value, typeof(T));
		}

		internal static ParseResult<T> MissingSign(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The required value sign is missing.");
		}

		internal static ParseResult<T> MissingAmPmDesignator(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The value string does not match the AM or PM designator for the culture at the required place.");
		}

		internal static ParseResult<T> NoMatchingCalendarSystem(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The specified calendar id is not recognized.");
		}

		internal static ParseResult<T> NoMatchingZoneId(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "The specified time zone identifier is not recognized.");
		}

		internal static ParseResult<T> InvalidHour24(string text)
		{
			return ForInvalidValuePostParse(text, "24 is only valid as an hour number when the units smaller than hours are all 0.");
		}

		internal static ParseResult<T> FieldValueOutOfRange(ValueCursor cursor, int value, char field)
		{
			return ForInvalidValue(cursor, "The value {0} is out of range for the field '{1}' in the {2} type.", value, field, typeof(T));
		}

		internal static ParseResult<T> FieldValueOutOfRange(ValueCursor cursor, long value, char field)
		{
			return ForInvalidValue(cursor, "The value {0} is out of range for the field '{1}' in the {2} type.", value, field, typeof(T));
		}

		internal static ParseResult<T> FieldValueOutOfRangePostParse(string text, int value, char field)
		{
			return ForInvalidValuePostParse(text, "The value {0} is out of range for the field '{1}' in the {2} type.", value, field, typeof(T));
		}

		internal static ParseResult<T> InconsistentValues(string text, char field1, char field2)
		{
			return ForInvalidValuePostParse(text, "The individual values for the fields '{0}' and '{1}' created an inconsistency in the {2} type.", field1, field2, typeof(T));
		}

		internal static ParseResult<T> InconsistentMonthValues(string text)
		{
			return ForInvalidValuePostParse(text, "The month values specified as text and numbers are inconsistent.");
		}

		internal static ParseResult<T> InconsistentDayOfWeekTextValue(string text)
		{
			return ForInvalidValuePostParse(text, "The specified day of the week does not matched the computed value.");
		}

		internal static ParseResult<T> ExpectedEndOfString(ValueCursor cursor)
		{
			return ForInvalidValue(cursor, "Expected end of input, but more data remains.");
		}

		internal static ParseResult<T> YearOfEraOutOfRange(string text, int value, Era era, CalendarSystem calendar)
		{
			return ForInvalidValuePostParse(text, "The year {0} is out of range for the {1} era in the {2} calendar.", value, era.Name, calendar.Name);
		}

		internal static ParseResult<T> MonthOutOfRange(string text, int month, int year)
		{
			return ForInvalidValuePostParse(text, "The month {0} is out of range in year {1}.", month, year);
		}

		internal static ParseResult<T> IsoMonthOutOfRange(string text, int month)
		{
			return ForInvalidValuePostParse(text, "The month {0} is out of range in the ISO calendar.", month);
		}

		internal static ParseResult<T> DayOfMonthOutOfRange(string text, int day, int month, int year)
		{
			return ForInvalidValuePostParse(text, "The day {0} is out of range in month {1} of year {2}.", day, month, year);
		}

		internal static ParseResult<T> DayOfMonthOutOfRangeNoYear(string text, int day, int month)
		{
			return ForInvalidValuePostParse(text, "The day {0} is out of range in month {1}.", day, month);
		}

		internal static ParseResult<T> InvalidOffset(string text)
		{
			return ForInvalidValuePostParse(text, "The specified offset is invalid for the given date/time.");
		}

		internal static ParseResult<T> SkippedLocalTime(string text)
		{
			return ForInvalidValuePostParse(text, "The local date/time is skipped in the target time zone.");
		}

		internal static ParseResult<T> AmbiguousLocalTime(string text)
		{
			return ForInvalidValuePostParse(text, "The local date/time is ambiguous in the target time zone.");
		}
	}
	[Immutable]
	public sealed class PeriodPattern : IPattern<Period>
	{
		private sealed class RoundtripPatternImpl : IPattern<Period>
		{
			public ParseResult<Period> Parse(string text)
			{
				if (text == null)
				{
					return ParseResult<Period>.ArgumentNull("text");
				}
				if (text.Length == 0)
				{
					return ParseResult<Period>.ValueStringEmpty;
				}
				ValueCursor valueCursor = new ValueCursor(text);
				valueCursor.MoveNext();
				if (valueCursor.Current != 'P')
				{
					return ParseResult<Period>.MismatchedCharacter(valueCursor, 'P');
				}
				bool flag = true;
				PeriodBuilder periodBuilder = new PeriodBuilder();
				PeriodUnits periodUnits = PeriodUnits.None;
				while (valueCursor.MoveNext())
				{
					if (flag && valueCursor.Current == 'T')
					{
						flag = false;
						continue;
					}
					long result;
					ParseResult<Period> parseResult = valueCursor.ParseInt64<Period>(out result);
					if (parseResult != null)
					{
						return parseResult;
					}
					if (valueCursor.Length == valueCursor.Index)
					{
						return ParseResult<Period>.EndOfString(valueCursor);
					}
					PeriodUnits periodUnits2;
					switch (valueCursor.Current)
					{
					case 'Y':
						periodUnits2 = PeriodUnits.Years;
						break;
					case 'M':
						periodUnits2 = (flag ? PeriodUnits.Months : PeriodUnits.Minutes);
						break;
					case 'W':
						periodUnits2 = PeriodUnits.Weeks;
						break;
					case 'D':
						periodUnits2 = PeriodUnits.Days;
						break;
					case 'H':
						periodUnits2 = PeriodUnits.Hours;
						break;
					case 'S':
						periodUnits2 = PeriodUnits.Seconds;
						break;
					case 's':
						periodUnits2 = PeriodUnits.Milliseconds;
						break;
					case 't':
						periodUnits2 = PeriodUnits.Ticks;
						break;
					case 'n':
						periodUnits2 = PeriodUnits.Nanoseconds;
						break;
					default:
						return InvalidUnit(valueCursor, valueCursor.Current);
					}
					if ((periodUnits2 & periodUnits) != PeriodUnits.None)
					{
						return RepeatedUnit(valueCursor, valueCursor.Current);
					}
					if (periodUnits2 < periodUnits)
					{
						return MisplacedUnit(valueCursor, valueCursor.Current);
					}
					if ((periodUnits2 & PeriodUnits.AllTimeUnits) == 0 != flag)
					{
						return MisplacedUnit(valueCursor, valueCursor.Current);
					}
					periodBuilder[periodUnits2] = result;
					periodUnits |= periodUnits2;
				}
				return ParseResult<Period>.ForValue(periodBuilder.Build());
			}

			public string Format([NotNull] Period value)
			{
				return AppendFormat(value, new StringBuilder()).ToString();
			}

			public StringBuilder AppendFormat([NotNull] Period value, [NotNull] StringBuilder builder)
			{
				Preconditions.CheckNotNull(value, "value");
				Preconditions.CheckNotNull(builder, "builder");
				builder.Append("P");
				AppendValue(builder, value.Years, "Y");
				AppendValue(builder, value.Months, "M");
				AppendValue(builder, value.Weeks, "W");
				AppendValue(builder, value.Days, "D");
				if (value.HasTimeComponent)
				{
					builder.Append("T");
					AppendValue(builder, value.Hours, "H");
					AppendValue(builder, value.Minutes, "M");
					AppendValue(builder, value.Seconds, "S");
					AppendValue(builder, value.Milliseconds, "s");
					AppendValue(builder, value.Ticks, "t");
					AppendValue(builder, value.Nanoseconds, "n");
				}
				return builder;
			}
		}

		private sealed class NormalizingIsoPatternImpl : IPattern<Period>
		{
			public ParseResult<Period> Parse(string text)
			{
				if (text == null)
				{
					return ParseResult<Period>.ArgumentNull("text");
				}
				if (text.Length == 0)
				{
					return ParseResult<Period>.ValueStringEmpty;
				}
				ValueCursor valueCursor = new ValueCursor(text);
				valueCursor.MoveNext();
				if (valueCursor.Current != 'P')
				{
					return ParseResult<Period>.MismatchedCharacter(valueCursor, 'P');
				}
				bool flag = true;
				PeriodBuilder periodBuilder = new PeriodBuilder();
				PeriodUnits periodUnits = PeriodUnits.None;
				while (valueCursor.MoveNext())
				{
					if (flag && valueCursor.Current == 'T')
					{
						flag = false;
						continue;
					}
					bool flag2 = valueCursor.Current == '-';
					long result;
					ParseResult<Period> parseResult = valueCursor.ParseInt64<Period>(out result);
					if (parseResult != null)
					{
						return parseResult;
					}
					if (valueCursor.Length == valueCursor.Index)
					{
						return ParseResult<Period>.EndOfString(valueCursor);
					}
					PeriodUnits periodUnits2;
					switch (valueCursor.Current)
					{
					case 'Y':
						periodUnits2 = PeriodUnits.Years;
						break;
					case 'M':
						periodUnits2 = (flag ? PeriodUnits.Months : PeriodUnits.Minutes);
						break;
					case 'W':
						periodUnits2 = PeriodUnits.Weeks;
						break;
					case 'D':
						periodUnits2 = PeriodUnits.Days;
						break;
					case 'H':
						periodUnits2 = PeriodUnits.Hours;
						break;
					case 'S':
						periodUnits2 = PeriodUnits.Seconds;
						break;
					case ',':
					case '.':
						periodUnits2 = PeriodUnits.Nanoseconds;
						break;
					default:
						return InvalidUnit(valueCursor, valueCursor.Current);
					}
					if ((periodUnits2 & periodUnits) != PeriodUnits.None)
					{
						return RepeatedUnit(valueCursor, valueCursor.Current);
					}
					if (periodUnits2 < periodUnits)
					{
						return MisplacedUnit(valueCursor, valueCursor.Current);
					}
					if ((periodUnits2 & PeriodUnits.AllTimeUnits) == 0 != flag)
					{
						return MisplacedUnit(valueCursor, valueCursor.Current);
					}
					if (periodUnits2 == PeriodUnits.Nanoseconds)
					{
						if ((periodUnits & PeriodUnits.Seconds) != PeriodUnits.None)
						{
							return MisplacedUnit(valueCursor, valueCursor.Current);
						}
						periodBuilder.Seconds = result;
						if (!valueCursor.MoveNext())
						{
							return ParseResult<Period>.MissingNumber(valueCursor);
						}
						if (!valueCursor.ParseFraction(9, 9, out var result2, 1))
						{
							return ParseResult<Period>.MissingNumber(valueCursor);
						}
						if (flag2)
						{
							result2 = checked(-result2);
						}
						periodBuilder.Milliseconds = (long)result2 / 1000000L % 1000;
						periodBuilder.Ticks = (long)result2 / 100L % 10000;
						periodBuilder.Nanoseconds = (long)result2 % 100L;
						if (valueCursor.Current != 'S')
						{
							return ParseResult<Period>.MismatchedCharacter(valueCursor, 'S');
						}
						if (valueCursor.MoveNext())
						{
							return ParseResult<Period>.ExpectedEndOfString(valueCursor);
						}
						return ParseResult<Period>.ForValue(periodBuilder.Build());
					}
					periodBuilder[periodUnits2] = result;
					periodUnits |= periodUnits2;
				}
				if (periodUnits == PeriodUnits.None)
				{
					return ParseResult<Period>.ForInvalidValue(valueCursor, "The specified period was empty.");
				}
				return ParseResult<Period>.ForValue(periodBuilder.Build());
			}

			public string Format([NotNull] Period value)
			{
				return AppendFormat(value, new StringBuilder()).ToString();
			}

			public StringBuilder AppendFormat([NotNull] Period value, [NotNull] StringBuilder builder)
			{
				Preconditions.CheckNotNull(value, "value");
				Preconditions.CheckNotNull(builder, "builder");
				value = value.Normalize();
				if (value.Equals(Period.Zero))
				{
					builder.Append("P0D");
					return builder;
				}
				builder.Append("P");
				AppendValue(builder, value.Years, "Y");
				AppendValue(builder, value.Months, "M");
				AppendValue(builder, value.Weeks, "W");
				AppendValue(builder, value.Days, "D");
				checked
				{
					if (value.HasTimeComponent)
					{
						builder.Append("T");
						AppendValue(builder, value.Hours, "H");
						AppendValue(builder, value.Minutes, "M");
						long num = value.Milliseconds * 1000000 + value.Ticks * 100 + value.Nanoseconds;
						long num2 = value.Seconds;
						if (num != 0L || num2 != 0L)
						{
							if (num < 0 || num2 < 0)
							{
								builder.Append("-");
								num = -num;
								num2 = -num2;
							}
							FormatHelper.FormatInvariant(num2, builder);
							if (num != 0L)
							{
								builder.Append(".");
								FormatHelper.AppendFractionTruncate((int)num, 9, 9, builder);
							}
							builder.Append("S");
						}
					}
					return builder;
				}
			}
		}

		private readonly IPattern<Period> pattern;

		[NotNull]
		public static PeriodPattern Roundtrip { get; } = new PeriodPattern(new RoundtripPatternImpl());

		[NotNull]
		public static PeriodPattern NormalizingIso { get; } = new PeriodPattern(new NormalizingIsoPatternImpl());

		private PeriodPattern([NotNull] IPattern<Period> pattern)
		{
			this.pattern = Preconditions.CheckNotNull(pattern, "pattern");
		}

		[NotNull]
		public ParseResult<Period> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format([NotNull] Period value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat([NotNull] Period value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static void AppendValue(StringBuilder builder, long value, string suffix)
		{
			if (value != 0L)
			{
				FormatHelper.FormatInvariant(value, builder);
				builder.Append(suffix);
			}
		}

		private static ParseResult<Period> InvalidUnit(ValueCursor cursor, char unitCharacter)
		{
			return ParseResult<Period>.ForInvalidValue(cursor, "The period unit specifier '{0}' is invalid.", unitCharacter);
		}

		private static ParseResult<Period> RepeatedUnit(ValueCursor cursor, char unitCharacter)
		{
			return ParseResult<Period>.ForInvalidValue(cursor, "The period unit specifier '{0}' appears multiple times in the input string.", unitCharacter);
		}

		private static ParseResult<Period> MisplacedUnit(ValueCursor cursor, char unitCharacter)
		{
			return ParseResult<Period>.ForInvalidValue(cursor, "The period unit specifier '{0}' appears at the wrong place in the input string.", unitCharacter);
		}
	}
	[DebuggerStepThrough]
	internal abstract class TextCursor
	{
		internal const char Nul = '\0';

		internal int Length { get; }

		internal string Value { get; }

		internal char Current { get; private set; }

		internal bool HasMoreCharacters => Index + 1 < Length;

		internal int Index { get; private set; }

		internal string Remainder => Value.Substring(Index);

		protected TextCursor(string value)
		{
			Value = value;
			Length = value.Length;
			Move(-1);
		}

		public override string ToString()
		{
			if (Index > 0)
			{
				if (Index < Length)
				{
					return Value.Insert(Index, "^");
				}
				return Value + "^";
			}
			return "^" + Value;
		}

		internal char PeekNext()
		{
			if (!HasMoreCharacters)
			{
				return '\0';
			}
			return Value[Index + 1];
		}

		internal bool Move(int targetIndex)
		{
			if (targetIndex >= 0)
			{
				if (targetIndex < Length)
				{
					Index = targetIndex;
					Current = Value[Index];
					return true;
				}
				Current = '\0';
				Index = Length;
				return false;
			}
			Current = '\0';
			Index = -1;
			return false;
		}

		internal bool MoveNext()
		{
			int num = Index + 1;
			if (num < Length)
			{
				Index = num;
				Current = Value[Index];
				return true;
			}
			Current = '\0';
			Index = Length;
			return false;
		}

		internal bool MovePrevious()
		{
			if (Index > 0)
			{
				Index--;
				Current = Value[Index];
				return true;
			}
			Current = '\0';
			Index = -1;
			return false;
		}
	}
	internal static class TextErrorMessages
	{
		internal const string AmbiguousLocalTime = "The local date/time is ambiguous in the target time zone.";

		internal const string CalendarAndEra = "The era specifier cannot be specified in the same pattern as the calendar specifier.";

		internal const string DateFieldAndEmbeddedDate = "Custom date specifiers cannot be specified in the same pattern as an embedded date specifier";

		internal const string DateSeparatorMismatch = "The value string does not match a date separator in the format string.";

		internal const string DayOfMonthOutOfRange = "The day {0} is out of range in month {1} of year {2}.";

		internal const string DayOfMonthOutOfRangeNoYear = "The day {0} is out of range in month {1}.";

		internal const string EmptyPeriod = "The specified period was empty.";

		internal const string EmptyZPrefixedOffsetPattern = "The Z prefix for an Offset pattern must be followed by a custom pattern.";

		internal const string EndOfString = "Input string ended unexpectedly early.";

		internal const string EraWithoutYearOfEra = "The era specifier cannot be used without the \"year of era\" specifier.";

		internal const string EscapeAtEndOfString = "The format string has an escape character (backslash '') at the end of the string.";

		internal const string EscapedCharacterMismatch = "The value string does not match an escaped character in the format string: \"{0}\"";

		internal const string ExpectedEndOfString = "Expected end of input, but more data remains.";

		internal const string ExtraValueCharacters = "The format matches a prefix of the value string but not the entire string. Part not matching: \"{0}\".";

		internal const string FieldValueOutOfRange = "The value {0} is out of range for the field '{1}' in the {2} type.";

		internal const string FormatOnlyPattern = "This pattern is only capable of formatting, not parsing.";

		internal const string FormatStringEmpty = "The format string is empty.";

		internal const string Hour12PatternNotSupported = "The 'h' pattern flag (12 hour format) is not supported by the {0} type.";

		internal const string InconsistentDayOfWeekTextValue = "The specified day of the week does not matched the computed value.";

		internal const string InconsistentMonthTextValue = "The month values specified as text and numbers are inconsistent.";

		internal const string InconsistentValues2 = "The individual values for the fields '{0}' and '{1}' created an inconsistency in the {2} type.";

		internal const string InvalidEmbeddedPatternType = "The type of embedded pattern is not supported for this type.";

		internal const string InvalidHour24 = "24 is only valid as an hour number when the units smaller than hours are all 0.";

		internal const string InvalidOffset = "The specified offset is invalid for the given date/time.";

		internal const string InvalidRepeatCount = "The number of consecutive copies of the pattern character \"{0}\" in the format string ({1}) is invalid.";

		internal const string InvalidUnitSpecifier = "The period unit specifier '{0}' is invalid.";

		internal const string IsoMonthOutOfRange = "The month {0} is out of range in the ISO calendar.";

		internal const string MismatchedCharacter = "The value string does not match a simple character in the format string \"{0}\".";

		internal const string MismatchedNumber = "The value string does not match the required number from the format string \"{0}\".";

		internal const string MismatchedText = "The value string does not match the text-based field '{0}'.";

		internal const string MisplacedUnitSpecifier = "The period unit specifier '{0}' appears at the wrong place in the input string.";

		internal const string MissingAmPmDesignator = "The value string does not match the AM or PM designator for the culture at the required place.";

		internal const string MissingEmbeddedPatternEnd = "The pattern has an embedded pattern which is missing its closing character ('{0}').";

		internal const string MissingEmbeddedPatternStart = "The pattern has an embedded pattern which is missing its opening character ('{0}').";

		internal const string MissingEndQuote = "The format string is missing the end quote character \"{0}\".";

		internal const string MissingNumber = "The value string does not include a number in the expected position.";

		internal const string MissingSign = "The required value sign is missing.";

		internal const string MonthOutOfRange = "The month {0} is out of range in year {1}.";

		internal const string MultipleCapitalDurationFields = "Only one of \"D\", \"H\", \"M\" or \"S\" can occur in a duration format string.";

		internal const string NoMatchingCalendarSystem = "The specified calendar id is not recognized.";

		internal const string NoMatchingFormat = "None of the specified formats matches the given value string.";

		internal const string NoMatchingZoneId = "The specified time zone identifier is not recognized.";

		internal const string OverallValueOutOfRange = "Value is out of the legal range for the {0} type.";

		internal const string PercentAtEndOfString = "A percent sign (%) appears at the end of the format string.";

		internal const string PercentDoubled = "A percent sign (%) is followed by another percent sign in the format string.";

		internal const string PositiveSignInvalid = "A positive value sign is not valid at this point.";

		internal const string QuotedStringMismatch = "The value string does not match a quoted string in the pattern.";

		internal const string RepeatCountExceeded = "There were more consecutive copies of the pattern character \"{0}\" than the maximum allowed ({1}) in the format string.";

		internal const string RepeatedFieldInPattern = "The field \"{0}\" is specified multiple times in the pattern.";

		internal const string RepeatedUnitSpecifier = "The period unit specifier '{0}' appears multiple times in the input string.";

		internal const string SkippedLocalTime = "The local date/time is skipped in the target time zone.";

		internal const string TimeFieldAndEmbeddedTime = "Custom time specifiers cannot be specified in the same pattern as an embedded time specifier";

		internal const string TimeSeparatorMismatch = "The value string does not match a time separator in the format string.";

		internal const string UnexpectedNegative = "The value string includes a negative value where only a non-negative one is allowed.";

		internal const string UnknownStandardFormat = "The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".";

		internal const string UnparsableValue = "{0} Value being parsed: '{1}'. (^ indicates error position.)";

		internal const string UnparsableValuePostParse = "{0} Value being parsed: '{1}'.";

		internal const string UnquotedLiteral = "The character {0} is not a format specifier, and should be quoted to act as a literal.";

		internal const string ValueOutOfRange = "The value {0} is out of the legal range for the {1} type.";

		internal const string ValueStringEmpty = "The value string is empty.";

		internal const string YearOfEraOutOfRange = "The year {0} is out of range for the {1} era in the {2} calendar.";

		internal const string ZPrefixNotAtStartOfPattern = "The Z prefix for an Offset pattern must occur at the beginning of the pattern.";
	}
	[Mutable]
	public sealed class UnparsableValueException : FormatException
	{
		public UnparsableValueException()
		{
		}

		public UnparsableValueException(string message)
			: base(message)
		{
		}
	}
	internal sealed class ValueCursor : TextCursor
	{
		internal ValueCursor(string value)
			: base(value)
		{
		}

		internal bool Match(char character)
		{
			if (base.Current == character)
			{
				MoveNext();
				return true;
			}
			return false;
		}

		internal bool Match(string match)
		{
			if (string.CompareOrdinal(base.Value, base.Index, match, 0, match.Length) == 0)
			{
				Move(base.Index + match.Length);
				return true;
			}
			return false;
		}

		internal bool MatchCaseInsensitive(string match, CompareInfo compareInfo, bool moveOnSuccess)
		{
			if (match.Length > base.Value.Length - base.Index)
			{
				return false;
			}
			if (compareInfo.Compare(base.Value, base.Index, match.Length, match, 0, match.Length, CompareOptions.IgnoreCase) == 0)
			{
				if (moveOnSuccess)
				{
					Move(base.Index + match.Length);
				}
				return true;
			}
			return false;
		}

		internal int CompareOrdinal(string match)
		{
			int num = checked(base.Value.Length - base.Index);
			if (match.Length > num)
			{
				int num2 = string.CompareOrdinal(base.Value, base.Index, match, 0, num);
				if (num2 != 0)
				{
					return num2;
				}
				return -1;
			}
			return string.CompareOrdinal(base.Value, base.Index, match, 0, match.Length);
		}

		internal ParseResult<T> ParseInt64<T>(out long result)
		{
			result = 0L;
			int index = base.Index;
			bool flag = base.Current == '-';
			if (flag && !MoveNext())
			{
				Move(index);
				return ParseResult<T>.EndOfString(this);
			}
			int num = 0;
			int digit;
			while (result < 922337203685477580L && (digit = GetDigit()) != -1)
			{
				result = result * 10 + digit;
				num++;
				if (!MoveNext())
				{
					break;
				}
			}
			if (num == 0)
			{
				Move(index);
				return ParseResult<T>.MissingNumber(this);
			}
			if (result >= 922337203685477580L && (digit = GetDigit()) != -1)
			{
				if (result > 922337203685477580L)
				{
					return BuildNumberOutOfRangeResult<T>(index);
				}
				if (flag && digit == 8)
				{
					MoveNext();
					result = -9223372036854775808L;
					return null;
				}
				if (digit > 7)
				{
					return BuildNumberOutOfRangeResult<T>(index);
				}
				result = result * 10 + digit;
				MoveNext();
				if (GetDigit() != -1)
				{
					return BuildNumberOutOfRangeResult<T>(index);
				}
			}
			if (flag)
			{
				result = -result;
			}
			return null;
		}

		private ParseResult<T> BuildNumberOutOfRangeResult<T>(int startIndex)
		{
			Move(startIndex);
			if (base.Current == '-')
			{
				MoveNext();
			}
			while (GetDigit() != -1)
			{
				MoveNext();
			}
			string value = base.Value.Substring(startIndex, checked(base.Index - startIndex));
			Move(startIndex);
			return ParseResult<T>.ValueOutOfRange(this, value);
		}

		internal bool ParseInt64Digits(int minimumDigits, int maximumDigits, out long result)
		{
			result = 0L;
			int i = base.Index;
			int num = i + maximumDigits;
			if (num >= base.Length)
			{
				num = base.Length;
			}
			for (; i < num; i++)
			{
				int num2 = base.Value[i] - 48;
				if (num2 < 0 || num2 > 9)
				{
					break;
				}
				result = result * 10 + num2;
			}
			if (i - base.Index < minimumDigits)
			{
				return false;
			}
			Move(i);
			return true;
		}

		internal bool ParseDigits(int minimumDigits, int maximumDigits, out int result)
		{
			result = 0;
			int i = base.Index;
			int num = i + maximumDigits;
			if (num >= base.Length)
			{
				num = base.Length;
			}
			for (; i < num; i++)
			{
				int num2 = base.Value[i] - 48;
				if (num2 < 0 || num2 > 9)
				{
					break;
				}
				result = result * 10 + num2;
			}
			if (i - base.Index < minimumDigits)
			{
				return false;
			}
			Move(i);
			return true;
		}

		internal bool ParseFraction([Trusted] int maximumDigits, int scale, out int result, int minimumDigits)
		{
			result = 0;
			int i = base.Index;
			if (i + minimumDigits > base.Length)
			{
				return false;
			}
			for (int num = Math.Min(i + maximumDigits, base.Length); i < num; i++)
			{
				int num2 = base.Value[i] - 48;
				if (num2 < 0 || num2 > 9)
				{
					break;
				}
				result = result * 10 + num2;
			}
			int num3 = i - base.Index;
			if (num3 < minimumDigits)
			{
				return false;
			}
			result = (int)((double)result * Math.Pow(10.0, scale - num3));
			Move(i);
			return true;
		}

		private int GetDigit()
		{
			int current = base.Current;
			if (current >= 48 && current <= 57)
			{
				return current - 48;
			}
			return -1;
		}
	}
	[Immutable]
	public sealed class ZonedDateTimePattern : IPattern<ZonedDateTime>
	{
		internal static class Patterns
		{
			internal static readonly ZonedDateTimePattern GeneralFormatOnlyPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss z '('o<g>')'", null);

			internal static readonly ZonedDateTimePattern ExtendedFormatOnlyPatternImpl = CreateWithInvariantCulture("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFF z '('o<g>')'", null);

			internal static readonly PatternBclSupport<ZonedDateTime> BclSupport = new PatternBclSupport<ZonedDateTime>("G", (NodaFormatInfo fi) => fi.ZonedDateTimePatternParser);
		}

		private readonly IPattern<ZonedDateTime> pattern;

		internal static ZonedDateTime DefaultTemplateValue { get; } = new LocalDateTime(2000, 1, 1, 0, 0).InUtc();

		[NotNull]
		public static ZonedDateTimePattern GeneralFormatOnlyIso => Patterns.GeneralFormatOnlyPatternImpl;

		[NotNull]
		public static ZonedDateTimePattern ExtendedFormatOnlyIso => Patterns.ExtendedFormatOnlyPatternImpl;

		[NotNull]
		public string PatternText { get; }

		internal NodaFormatInfo FormatInfo { get; }

		public ZonedDateTime TemplateValue { get; }

		[CanBeNull]
		public ZoneLocalMappingResolver Resolver { get; }

		[CanBeNull]
		public IDateTimeZoneProvider ZoneProvider { get; }

		private ZonedDateTimePattern(string patternText, NodaFormatInfo formatInfo, ZonedDateTime templateValue, ZoneLocalMappingResolver resolver, IDateTimeZoneProvider zoneProvider, IPattern<ZonedDateTime> pattern)
		{
			PatternText = patternText;
			FormatInfo = formatInfo;
			TemplateValue = templateValue;
			Resolver = resolver;
			ZoneProvider = zoneProvider;
			this.pattern = pattern;
		}

		[NotNull]
		public ParseResult<ZonedDateTime> Parse([SpecialNullHandling] string text)
		{
			return pattern.Parse(text);
		}

		[NotNull]
		public string Format(ZonedDateTime value)
		{
			return pattern.Format(value);
		}

		[NotNull]
		public StringBuilder AppendFormat(ZonedDateTime value, [NotNull] StringBuilder builder)
		{
			return pattern.AppendFormat(value, builder);
		}

		private static ZonedDateTimePattern Create([NotNull] string patternText, [NotNull] NodaFormatInfo formatInfo, [NotNull] ZoneLocalMappingResolver resolver, IDateTimeZoneProvider zoneProvider, ZonedDateTime templateValue)
		{
			Preconditions.CheckNotNull(patternText, "patternText");
			Preconditions.CheckNotNull(formatInfo, "formatInfo");
			IPattern<ZonedDateTime> pattern = new ZonedDateTimePatternParser(templateValue, resolver, zoneProvider).ParsePattern(patternText, formatInfo);
			return new ZonedDateTimePattern(patternText, formatInfo, templateValue, resolver, zoneProvider, pattern);
		}

		[NotNull]
		public static ZonedDateTimePattern Create([NotNull] string patternText, [NotNull] CultureInfo cultureInfo, [CanBeNull] ZoneLocalMappingResolver resolver, [CanBeNull] IDateTimeZoneProvider zoneProvider, ZonedDateTime templateValue)
		{
			return Create(patternText, NodaFormatInfo.GetFormatInfo(cultureInfo), resolver, zoneProvider, templateValue);
		}

		[NotNull]
		public static ZonedDateTimePattern CreateWithInvariantCulture([NotNull] string patternText, [CanBeNull] IDateTimeZoneProvider zoneProvider)
		{
			return Create(patternText, NodaFormatInfo.InvariantInfo, Resolvers.StrictResolver, zoneProvider, DefaultTemplateValue);
		}

		[NotNull]
		public static ZonedDateTimePattern CreateWithCurrentCulture([NotNull] string patternText, [CanBeNull] IDateTimeZoneProvider zoneProvider)
		{
			return Create(patternText, NodaFormatInfo.CurrentInfo, Resolvers.StrictResolver, zoneProvider, DefaultTemplateValue);
		}

		[NotNull]
		public ZonedDateTimePattern WithPatternText([NotNull] string patternText)
		{
			return Create(patternText, FormatInfo, Resolver, ZoneProvider, TemplateValue);
		}

		private ZonedDateTimePattern WithFormatInfo([NotNull] NodaFormatInfo formatInfo)
		{
			return Create(PatternText, formatInfo, Resolver, ZoneProvider, TemplateValue);
		}

		[NotNull]
		public ZonedDateTimePattern WithCulture([NotNull] CultureInfo cultureInfo)
		{
			return WithFormatInfo(NodaFormatInfo.GetFormatInfo(cultureInfo));
		}

		[NotNull]
		public ZonedDateTimePattern WithResolver([CanBeNull] ZoneLocalMappingResolver resolver)
		{
			if (Resolver != resolver)
			{
				return Create(PatternText, FormatInfo, resolver, ZoneProvider, TemplateValue);
			}
			return this;
		}

		[NotNull]
		public ZonedDateTimePattern WithZoneProvider([CanBeNull] IDateTimeZoneProvider newZoneProvider)
		{
			if (newZoneProvider != ZoneProvider)
			{
				return Create(PatternText, FormatInfo, Resolver, newZoneProvider, TemplateValue);
			}
			return this;
		}

		[NotNull]
		public ZonedDateTimePattern WithTemplateValue(ZonedDateTime newTemplateValue)
		{
			if (!(newTemplateValue == TemplateValue))
			{
				return Create(PatternText, FormatInfo, Resolver, ZoneProvider, newTemplateValue);
			}
			return this;
		}

		[NotNull]
		public ZonedDateTimePattern WithCalendar([NotNull] CalendarSystem calendar)
		{
			return WithTemplateValue(TemplateValue.WithCalendar(calendar));
		}
	}
	internal sealed class ZonedDateTimePatternParser : IPatternParser<ZonedDateTime>
	{
		private sealed class ZonedDateTimeParseBucket : ParseBucket<ZonedDateTime>
		{
			internal readonly LocalDatePatternParser.LocalDateParseBucket Date;

			internal readonly LocalTimePatternParser.LocalTimeParseBucket Time;

			private DateTimeZone Zone;

			internal Offset Offset;

			private readonly ZoneLocalMappingResolver resolver;

			private readonly IDateTimeZoneProvider zoneProvider;

			internal ZonedDateTimeParseBucket(ZonedDateTime templateValue, ZoneLocalMappingResolver resolver, IDateTimeZoneProvider zoneProvider)
			{
				Date = new LocalDatePatternParser.LocalDateParseBucket(templateValue.Date);
				Time = new LocalTimePatternParser.LocalTimeParseBucket(templateValue.TimeOfDay);
				Zone = templateValue.Zone;
				this.resolver = resolver;
				this.zoneProvider = zoneProvider;
			}

			internal ParseResult<ZonedDateTime> ParseZone(ValueCursor value)
			{
				DateTimeZone dateTimeZone = TryParseFixedZone(value) ?? TryParseProviderZone(value);
				if (dateTimeZone == null)
				{
					return ParseResult<ZonedDateTime>.NoMatchingZoneId(value);
				}
				Zone = dateTimeZone;
				return null;
			}

			private DateTimeZone TryParseFixedZone(ValueCursor value)
			{
				if (value.CompareOrdinal("UTC") != 0)
				{
					return null;
				}
				value.Move(checked(value.Index + 3));
				ParseResult<Offset> parseResult = OffsetPattern.GeneralInvariant.UnderlyingPattern.ParsePartial(value);
				if (!parseResult.Success)
				{
					return DateTimeZone.Utc;
				}
				return DateTimeZone.ForOffset(parseResult.Value);
			}

			private DateTimeZone TryParseProviderZone(ValueCursor value)
			{
				ReadOnlyCollection<string> ids = zoneProvider.Ids;
				int num = 0;
				int num2 = ids.Count;
				while (num < num2)
				{
					int num3 = checked(num + num2) / 2;
					int num4 = value.CompareOrdinal(ids[num3]);
					if (num4 < 0)
					{
						num2 = num3;
						continue;
					}
					checked
					{
						if (num4 > 0)
						{
							num = num3 + 1;
							continue;
						}
						string text = ids[num3];
						for (int i = num3 + 1; i < num2; i++)
						{
							string text2 = ids[i];
							if (text2.Length < text.Length || string.CompareOrdinal(text, 0, text2, 0, text.Length) != 0)
							{
								break;
							}
							if (value.CompareOrdinal(text2) == 0)
							{
								text = text2;
							}
						}
						value.Move(value.Index + text.Length);
						return zoneProvider[text];
					}
				}
				return null;
			}

			internal override ParseResult<ZonedDateTime> CalculateValue(PatternFields usedFields, string text)
			{
				ParseResult<LocalDateTime> parseResult = LocalDateTimePatternParser.LocalDateTimeParseBucket.CombineBuckets(usedFields, Date, Time, text);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<ZonedDateTime>();
				}
				LocalDateTime value = parseResult.Value;
				if ((usedFields & PatternFields.EmbeddedOffset) == 0)
				{
					try
					{
						return ParseResult<ZonedDateTime>.ForValue(Zone.ResolveLocal(value, resolver));
					}
					catch (SkippedTimeException)
					{
						return ParseResult<ZonedDateTime>.SkippedLocalTime(text);
					}
					catch (AmbiguousTimeException)
					{
						return ParseResult<ZonedDateTime>.AmbiguousLocalTime(text);
					}
				}
				ZoneLocalMapping zoneLocalMapping = Zone.MapLocal(value);
				ZonedDateTime value2;
				switch (zoneLocalMapping.Count)
				{
				case 0:
					return ParseResult<ZonedDateTime>.InvalidOffset(text);
				case 1:
					value2 = zoneLocalMapping.First();
					break;
				case 2:
					value2 = ((zoneLocalMapping.First().Offset == Offset) ? zoneLocalMapping.First() : zoneLocalMapping.Last());
					break;
				default:
					throw new InvalidOperationException("Mapping has count outside range 0-2; should not happen.");
				}
				if (value2.Offset != Offset)
				{
					return ParseResult<ZonedDateTime>.InvalidOffset(text);
				}
				return ParseResult<ZonedDateTime>.ForValue(value2);
			}
		}

		private readonly ZonedDateTime templateValue;

		private readonly IDateTimeZoneProvider zoneProvider;

		private readonly ZoneLocalMappingResolver resolver;

		private static readonly Dictionary<char, CharacterHandler<ZonedDateTime, ZonedDateTimeParseBucket>> PatternCharacterHandlers = new Dictionary<char, CharacterHandler<ZonedDateTime, ZonedDateTimeParseBucket>>
		{
			{
				'%',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePercent
			},
			{
				'\'',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandleQuote
			},
			{
				'"',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandleQuote
			},
			{
				'\\',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandleBackslash
			},
			{
				'/',
				delegate(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.DateSeparator, ParseResult<ZonedDateTime>.DateSeparatorMismatch);
				}
			},
			{
				'T',
				delegate(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
				{
					builder.AddLiteral('T', ParseResult<ZonedDateTime>.MismatchedCharacter);
				}
			},
			{
				'y',
				DatePatternHelper.CreateYearOfEraHandler((ZonedDateTime value) => value.YearOfEra, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.YearOfEra = value;
				})
			},
			{
				'u',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePaddedField(4, PatternFields.Year, -9999, 9999, (ZonedDateTime value) => value.Year, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.Year = value;
				})
			},
			{
				'M',
				DatePatternHelper.CreateMonthOfYearHandler((ZonedDateTime value) => value.Month, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearText = value;
				}, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.MonthOfYearNumeric = value;
				})
			},
			{
				'd',
				DatePatternHelper.CreateDayHandler((ZonedDateTime value) => value.Day, (ZonedDateTime value) => (int)value.DayOfWeek, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfMonth = value;
				}, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Date.DayOfWeek = value;
				})
			},
			{
				'.',
				TimePatternHelper.CreatePeriodHandler(9, (ZonedDateTime value) => value.NanosecondOfSecond, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				';',
				TimePatternHelper.CreateCommaDotHandler(9, (ZonedDateTime value) => value.NanosecondOfSecond, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				':',
				delegate(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
				{
					builder.AddLiteral(builder.FormatInfo.TimeSeparator, ParseResult<ZonedDateTime>.TimeSeparatorMismatch);
				}
			},
			{
				'h',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours12, 1, 12, (ZonedDateTime value) => value.ClockHourOfHalfDay, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours12 = value;
				})
			},
			{
				'H',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Hours24, 0, 24, (ZonedDateTime value) => value.Hour, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Hours24 = value;
				})
			},
			{
				'm',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Minutes, 0, 59, (ZonedDateTime value) => value.Minute, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Minutes = value;
				})
			},
			{
				's',
				SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>.HandlePaddedField(2, PatternFields.Seconds, 0, 59, (ZonedDateTime value) => value.Second, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.Seconds = value;
				})
			},
			{
				'f',
				TimePatternHelper.CreateFractionHandler(9, (ZonedDateTime value) => value.NanosecondOfSecond, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				'F',
				TimePatternHelper.CreateFractionHandler(9, (ZonedDateTime value) => value.NanosecondOfSecond, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.FractionalSeconds = value;
				})
			},
			{
				't',
				TimePatternHelper.CreateAmPmHandler((ZonedDateTime time) => time.Hour, delegate(ZonedDateTimeParseBucket bucket, int value)
				{
					bucket.Time.AmPm = value;
				})
			},
			{
				'c',
				DatePatternHelper.CreateCalendarHandler((ZonedDateTime value) => value.LocalDateTime.Calendar, delegate(ZonedDateTimeParseBucket bucket, CalendarSystem value)
				{
					bucket.Date.Calendar = value;
				})
			},
			{
				'g',
				DatePatternHelper.CreateEraHandler((ZonedDateTime value) => value.Era, (ZonedDateTimeParseBucket bucket) => bucket.Date)
			},
			{ 'z', HandleZone },
			{ 'x', HandleZoneAbbreviation },
			{ 'o', HandleOffset },
			{
				'l',
				delegate(PatternCursor cursor, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
				{
					builder.AddEmbeddedLocalPartial(cursor, (ZonedDateTimeParseBucket bucket) => bucket.Date, (ZonedDateTimeParseBucket bucket) => bucket.Time, (ZonedDateTime value) => value.Date, (ZonedDateTime value) => value.TimeOfDay, (ZonedDateTime value) => value.LocalDateTime);
				}
			}
		};

		internal ZonedDateTimePatternParser(ZonedDateTime templateValue, ZoneLocalMappingResolver resolver, IDateTimeZoneProvider zoneProvider)
		{
			this.templateValue = templateValue;
			this.resolver = resolver;
			this.zoneProvider = zoneProvider;
		}

		public IPattern<ZonedDateTime> ParsePattern(string patternText, NodaFormatInfo formatInfo)
		{
			if (patternText.Length == 0)
			{
				throw new InvalidPatternException("The format string is empty.");
			}
			if (patternText.Length == 1)
			{
				return patternText[0] switch
				{
					'G' => ZonedDateTimePattern.Patterns.GeneralFormatOnlyPatternImpl.WithZoneProvider(zoneProvider).WithResolver(resolver), 
					'F' => ZonedDateTimePattern.Patterns.ExtendedFormatOnlyPatternImpl.WithZoneProvider(zoneProvider).WithResolver(resolver), 
					_ => throw new InvalidPatternException("The standard format \"{0}\" is not valid for the {1} type. If the pattern was intended to be a custom format, escape it with a percent sign: \"%{0}\".", patternText[0], typeof(ZonedDateTime)), 
				};
			}
			SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> steppedPatternBuilder = new SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket>(formatInfo, () => new ZonedDateTimeParseBucket(templateValue, resolver, zoneProvider));
			if (zoneProvider == null || resolver == null)
			{
				steppedPatternBuilder.SetFormatOnly();
			}
			steppedPatternBuilder.ParseCustomPattern(patternText, PatternCharacterHandlers);
			steppedPatternBuilder.ValidateUsedFields();
			return steppedPatternBuilder.Build(templateValue);
		}

		private static void HandleZone(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
		{
			builder.AddField(PatternFields.Zone, pattern.Current);
			builder.AddParseAction(ParseZone);
			builder.AddFormatAction(delegate(ZonedDateTime value, StringBuilder sb)
			{
				sb.Append(value.Zone.Id);
			});
		}

		private static void HandleZoneAbbreviation(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
		{
			builder.AddField(PatternFields.ZoneAbbreviation, pattern.Current);
			builder.SetFormatOnly();
			builder.AddFormatAction(delegate(ZonedDateTime value, StringBuilder sb)
			{
				sb.Append(value.GetZoneInterval().Name);
			});
		}

		private static void HandleOffset(PatternCursor pattern, SteppedPatternBuilder<ZonedDateTime, ZonedDateTimeParseBucket> builder)
		{
			builder.AddField(PatternFields.EmbeddedOffset, pattern.Current);
			IPartialPattern<Offset> underlyingPattern = OffsetPattern.Create(pattern.GetEmbeddedPattern(), builder.FormatInfo).UnderlyingPattern;
			builder.AddEmbeddedPattern(underlyingPattern, delegate(ZonedDateTimeParseBucket bucket, Offset offset)
			{
				bucket.Offset = offset;
			}, (ZonedDateTime zdt) => zdt.Offset);
		}

		private static ParseResult<ZonedDateTime> ParseZone(ValueCursor value, ZonedDateTimeParseBucket bucket)
		{
			return bucket.ParseZone(value);
		}
	}
}
namespace NodaTime.Text.Patterns
{
	internal static class DatePatternHelper
	{
		private sealed class MonthFormatActionHolder<TResult, TBucket> : SteppedPatternBuilder<TResult, TBucket>.IPostPatternParseFormatAction where TBucket : ParseBucket<TResult>
		{
			private readonly int count;

			private readonly NodaFormatInfo formatInfo;

			private readonly Func<TResult, int> getter;

			internal MonthFormatActionHolder(NodaFormatInfo formatInfo, int count, Func<TResult, int> getter)
			{
				this.count = count;
				this.formatInfo = formatInfo;
				this.getter = getter;
			}

			internal void DummyMethod(TResult value, StringBuilder builder)
			{
				throw new InvalidOperationException("This method should never be called");
			}

			public Action<TResult, StringBuilder> BuildFormatAction(PatternFields finalFields)
			{
				bool flag = (finalFields & PatternFields.DayOfMonth) != 0;
				IList<string> textValues = ((count != 3) ? (flag ? formatInfo.LongMonthGenitiveNames : formatInfo.LongMonthNames) : (flag ? formatInfo.ShortMonthGenitiveNames : formatInfo.ShortMonthNames));
				return delegate(TResult value, StringBuilder sb)
				{
					sb.Append(textValues[getter(value)]);
				};
			}
		}

		internal static CharacterHandler<TResult, TBucket> CreateYearOfEraHandler<TResult, TBucket>(Func<TResult, int> yearGetter, Action<TBucket, int> setter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(4);
				builder.AddField(PatternFields.YearOfEra, pattern.Current);
				switch (repeatCount)
				{
				case 2:
					builder.AddParseValueAction(2, 2, 'y', 0, 99, setter);
					builder.AddFormatLeftPad(2, (TResult value) => checked(unchecked(yearGetter(value) % 100) + 100) % 100, assumeNonNegative: true, assumeFitsInCount: true);
					builder.AddField(PatternFields.YearTwoDigits, pattern.Current);
					break;
				case 4:
					builder.AddParseValueAction(4, 4, 'y', 1, 9999, setter);
					builder.AddFormatLeftPad(4, yearGetter, assumeNonNegative: false, assumeFitsInCount: true);
					break;
				default:
					throw new InvalidPatternException("The number of consecutive copies of the pattern character \"{0}\" in the format string ({1}) is invalid.", pattern.Current, repeatCount);
				}
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateMonthOfYearHandler<TResult, TBucket>(Func<TResult, int> numberGetter, Action<TBucket, int> textSetter, Action<TBucket, int> numberSetter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(4);
				PatternFields field;
				switch (repeatCount)
				{
				case 1:
				case 2:
					field = PatternFields.MonthOfYearNumeric;
					builder.AddParseValueAction(repeatCount, 2, pattern.Current, 1, 99, numberSetter);
					builder.AddFormatLeftPad(repeatCount, numberGetter, assumeNonNegative: true, repeatCount == 2);
					break;
				case 3:
				case 4:
				{
					field = PatternFields.MonthOfYearText;
					NodaFormatInfo formatInfo = builder.FormatInfo;
					IList<string> list = ((repeatCount == 3) ? formatInfo.ShortMonthNames : formatInfo.LongMonthNames);
					IList<string> list2 = ((repeatCount == 3) ? formatInfo.ShortMonthGenitiveNames : formatInfo.LongMonthGenitiveNames);
					if (list == list2)
					{
						builder.AddParseLongestTextAction(pattern.Current, textSetter, formatInfo.CompareInfo, list);
					}
					else
					{
						builder.AddParseLongestTextAction(pattern.Current, textSetter, formatInfo.CompareInfo, list2, list);
					}
					builder.AddFormatAction(new MonthFormatActionHolder<TResult, TBucket>(formatInfo, repeatCount, numberGetter).DummyMethod);
					break;
				}
				default:
					throw new InvalidOperationException("Invalid count!");
				}
				builder.AddField(field, pattern.Current);
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateDayHandler<TResult, TBucket>(Func<TResult, int> dayOfMonthGetter, Func<TResult, int> dayOfWeekGetter, Action<TBucket, int> dayOfMonthSetter, Action<TBucket, int> dayOfWeekSetter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(4);
				PatternFields field;
				switch (repeatCount)
				{
				case 1:
				case 2:
					field = PatternFields.DayOfMonth;
					builder.AddParseValueAction(repeatCount, 2, pattern.Current, 1, 99, dayOfMonthSetter);
					builder.AddFormatLeftPad(repeatCount, dayOfMonthGetter, assumeNonNegative: true, repeatCount == 2);
					break;
				case 3:
				case 4:
				{
					field = PatternFields.DayOfWeek;
					NodaFormatInfo formatInfo = builder.FormatInfo;
					IList<string> textValues = ((repeatCount == 3) ? formatInfo.ShortDayNames : formatInfo.LongDayNames);
					builder.AddParseLongestTextAction(pattern.Current, dayOfWeekSetter, formatInfo.CompareInfo, textValues);
					builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
					{
						sb.Append(textValues[dayOfWeekGetter(value)]);
					});
					break;
				}
				default:
					throw new InvalidOperationException("Invalid count!");
				}
				builder.AddField(field, pattern.Current);
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateEraHandler<TResult, TBucket>(Func<TResult, Era> eraFromValue, Func<TBucket, LocalDatePatternParser.LocalDateParseBucket> dateBucketFromBucket) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				pattern.GetRepeatCount(2);
				builder.AddField(PatternFields.Era, pattern.Current);
				NodaFormatInfo formatInfo = builder.FormatInfo;
				builder.AddParseAction((ValueCursor cursor, TBucket bucket) => dateBucketFromBucket(bucket).ParseEra<TResult>(formatInfo, cursor));
				builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					sb.Append(formatInfo.GetEraPrimaryName(eraFromValue(value)));
				});
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateCalendarHandler<TResult, TBucket>(Func<TResult, CalendarSystem> getter, Action<TBucket, CalendarSystem> setter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				builder.AddField(PatternFields.Calendar, pattern.Current);
				builder.AddParseAction(delegate(ValueCursor cursor, TBucket bucket)
				{
					foreach (string id in CalendarSystem.Ids)
					{
						if (cursor.Match(id))
						{
							setter(bucket, CalendarSystem.ForId(id));
							return (ParseResult<TResult>)null;
						}
					}
					return ParseResult<TResult>.NoMatchingCalendarSystem(cursor);
				});
				builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					sb.Append(getter(value).Id);
				});
			};
		}
	}
	internal interface IPatternParser<T>
	{
		IPattern<T> ParsePattern(string pattern, NodaFormatInfo formatInfo);
	}
	internal sealed class PatternBclSupport<T>
	{
		private readonly Func<NodaFormatInfo, FixedFormatInfoPatternParser<T>> patternParser;

		private readonly string defaultFormatPattern;

		internal PatternBclSupport(string defaultFormatPattern, Func<NodaFormatInfo, FixedFormatInfoPatternParser<T>> patternParser)
		{
			this.patternParser = patternParser;
			this.defaultFormatPattern = defaultFormatPattern;
		}

		internal string Format(T value, string patternText, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(patternText))
			{
				patternText = defaultFormatPattern;
			}
			NodaFormatInfo instance = NodaFormatInfo.GetInstance(formatProvider);
			return patternParser(instance).ParsePattern(patternText).Format(value);
		}
	}
	internal sealed class PatternCursor : TextCursor
	{
		internal const char EmbeddedPatternStart = '<';

		internal const char EmbeddedPatternEnd = '>';

		internal PatternCursor(string pattern)
			: base(pattern)
		{
		}

		internal string GetQuotedString(char closeQuote)
		{
			StringBuilder stringBuilder = new StringBuilder(checked(base.Length - base.Index));
			bool flag = false;
			while (MoveNext())
			{
				if (base.Current == closeQuote)
				{
					MoveNext();
					flag = true;
					break;
				}
				if (base.Current == '\\' && !MoveNext())
				{
					throw new InvalidPatternException("The format string has an escape character (backslash '') at the end of the string.");
				}
				stringBuilder.Append(base.Current);
			}
			if (!flag)
			{
				throw new InvalidPatternException("The format string is missing the end quote character \"{0}\".", closeQuote);
			}
			MovePrevious();
			return stringBuilder.ToString();
		}

		internal int GetRepeatCount(int maximumCount)
		{
			char current = base.Current;
			int index = base.Index;
			while (MoveNext() && base.Current == current)
			{
			}
			int num = checked(base.Index - index);
			MovePrevious();
			if (num > maximumCount)
			{
				throw new InvalidPatternException("There were more consecutive copies of the pattern character \"{0}\" than the maximum allowed ({1}) in the format string.", current, maximumCount);
			}
			return num;
		}

		internal string GetEmbeddedPattern()
		{
			if (!MoveNext() || base.Current != '<')
			{
				throw new InvalidPatternException($"The pattern has an embedded pattern which is missing its opening character ('{'<'}').");
			}
			checked
			{
				int num = base.Index + 1;
				int num2 = 1;
				while (MoveNext())
				{
					char current = base.Current;
					switch (current)
					{
					case '>':
						num2--;
						if (num2 == 0)
						{
							return base.Value.Substring(num, base.Index - num);
						}
						break;
					case '<':
						num2++;
						break;
					case '\\':
						if (!MoveNext())
						{
							throw new InvalidPatternException("The format string has an escape character (backslash '') at the end of the string.");
						}
						break;
					case '"':
					case '\'':
						GetQuotedString(current);
						break;
					}
				}
				throw new InvalidPatternException($"The pattern has an embedded pattern which is missing its closing character ('{'>'}').");
			}
		}
	}
	[Flags]
	internal enum PatternFields
	{
		None = 0,
		Sign = 1,
		Hours12 = 2,
		Hours24 = 4,
		Minutes = 8,
		Seconds = 0x10,
		FractionalSeconds = 0x20,
		AmPm = 0x40,
		Year = 0x80,
		YearTwoDigits = 0x100,
		YearOfEra = 0x200,
		MonthOfYearNumeric = 0x400,
		MonthOfYearText = 0x800,
		DayOfMonth = 0x1000,
		DayOfWeek = 0x2000,
		Era = 0x4000,
		Calendar = 0x8000,
		Zone = 0x10000,
		ZoneAbbreviation = 0x20000,
		EmbeddedOffset = 0x40000,
		TotalDuration = 0x80000,
		EmbeddedDate = 0x100000,
		EmbeddedTime = 0x200000,
		AllTimeFields = 0x20007E,
		AllDateFields = 0x10FF80
	}
	internal static class PatternFieldsExtensions
	{
		internal static bool HasAny(this PatternFields fields, PatternFields target)
		{
			return (fields & target) != 0;
		}

		internal static bool HasAll(this PatternFields fields, PatternFields target)
		{
			return (fields & target) == target;
		}
	}
	internal sealed class SteppedPatternBuilder<TResult, TBucket> where TBucket : ParseBucket<TResult>
	{
		internal delegate ParseResult<TResult> ParseAction(ValueCursor cursor, TBucket bucket);

		internal interface IPostPatternParseFormatAction
		{
			Action<TResult, StringBuilder> BuildFormatAction(PatternFields finalFields);
		}

		private sealed class SteppedPattern : IPartialPattern<TResult>, IPattern<TResult>
		{
			private readonly Action<TResult, StringBuilder> formatActions;

			private readonly ParseAction[] parseActions;

			private readonly Func<TBucket> bucketProvider;

			private readonly PatternFields usedFields;

			private readonly int expectedLength;

			public SteppedPattern(Action<TResult, StringBuilder> formatActions, ParseAction[] parseActions, Func<TBucket> bucketProvider, PatternFields usedFields, TResult sample)
			{
				this.formatActions = formatActions;
				this.parseActions = parseActions;
				this.bucketProvider = bucketProvider;
				this.usedFields = usedFields;
				StringBuilder stringBuilder = new StringBuilder();
				formatActions(sample, stringBuilder);
				expectedLength = stringBuilder.Length;
			}

			public ParseResult<TResult> Parse(string text)
			{
				if (parseActions == null)
				{
					return ParseResult<TResult>.FormatOnlyPattern;
				}
				if (text == null)
				{
					return ParseResult<TResult>.ArgumentNull("text");
				}
				if (text.Length == 0)
				{
					return ParseResult<TResult>.ValueStringEmpty;
				}
				ValueCursor valueCursor = new ValueCursor(text);
				valueCursor.MoveNext();
				ParseResult<TResult> parseResult = ParsePartial(valueCursor);
				if (!parseResult.Success)
				{
					return parseResult;
				}
				if (valueCursor.Current != 0)
				{
					return ParseResult<TResult>.ExtraValueCharacters(valueCursor, valueCursor.Remainder);
				}
				return parseResult;
			}

			public string Format(TResult value)
			{
				StringBuilder stringBuilder = new StringBuilder(expectedLength);
				formatActions(value, stringBuilder);
				return stringBuilder.ToString();
			}

			public ParseResult<TResult> ParsePartial(ValueCursor cursor)
			{
				TBucket val = bucketProvider();
				ParseAction[] array = parseActions;
				for (int i = 0; i < array.Length; i++)
				{
					ParseResult<TResult> parseResult = array[i](cursor, val);
					if (parseResult != null)
					{
						return parseResult;
					}
				}
				return val.CalculateValue(usedFields, cursor.Value);
			}

			public StringBuilder AppendFormat(TResult value, [NotNull] StringBuilder builder)
			{
				Preconditions.CheckNotNull(builder, "builder");
				formatActions(value, builder);
				return builder;
			}
		}

		private readonly List<Action<TResult, StringBuilder>> formatActions;

		private readonly List<ParseAction> parseActions;

		private readonly Func<TBucket> bucketProvider;

		private PatternFields usedFields;

		private bool formatOnly;

		internal NodaFormatInfo FormatInfo { get; }

		internal PatternFields UsedFields => usedFields;

		internal SteppedPatternBuilder(NodaFormatInfo formatInfo, Func<TBucket> bucketProvider)
		{
			FormatInfo = formatInfo;
			formatActions = new List<Action<TResult, StringBuilder>>();
			parseActions = new List<ParseAction>();
			this.bucketProvider = bucketProvider;
		}

		internal TBucket CreateSampleBucket()
		{
			return bucketProvider();
		}

		internal void SetFormatOnly()
		{
			formatOnly = true;
		}

		internal void ParseCustomPattern(string patternText, Dictionary<char, CharacterHandler<TResult, TBucket>> characterHandlers)
		{
			PatternCursor patternCursor = new PatternCursor(patternText);
			while (patternCursor.MoveNext())
			{
				if (characterHandlers.TryGetValue(patternCursor.Current, out var value))
				{
					value(patternCursor, this);
					continue;
				}
				char current = patternCursor.Current;
				if ((current >= 'A' && current <= 'Z') || (current >= 'a' && current <= 'z') || current == '<' || current == '>')
				{
					throw new InvalidPatternException("The character {0} is not a format specifier, and should be quoted to act as a literal.", current);
				}
				AddLiteral(patternCursor.Current, ParseResult<TResult>.MismatchedCharacter);
			}
		}

		internal void ValidateUsedFields()
		{
			if ((usedFields & (PatternFields.YearOfEra | PatternFields.Era)) == PatternFields.Era)
			{
				throw new InvalidPatternException("The era specifier cannot be used without the \"year of era\" specifier.");
			}
			if ((usedFields & (PatternFields.Era | PatternFields.Calendar)) == (PatternFields.Era | PatternFields.Calendar))
			{
				throw new InvalidPatternException("The era specifier cannot be specified in the same pattern as the calendar specifier.");
			}
		}

		internal IPartialPattern<TResult> Build(TResult sample)
		{
			if (usedFields.HasAny(PatternFields.EmbeddedDate) && usedFields.HasAny(PatternFields.Year | PatternFields.YearTwoDigits | PatternFields.YearOfEra | PatternFields.MonthOfYearNumeric | PatternFields.MonthOfYearText | PatternFields.DayOfMonth | PatternFields.DayOfWeek | PatternFields.Era | PatternFields.Calendar))
			{
				throw new InvalidPatternException("Custom date specifiers cannot be specified in the same pattern as an embedded date specifier");
			}
			if (usedFields.HasAny(PatternFields.EmbeddedTime) && usedFields.HasAny(PatternFields.Hours12 | PatternFields.Hours24 | PatternFields.Minutes | PatternFields.Seconds | PatternFields.FractionalSeconds | PatternFields.AmPm))
			{
				throw new InvalidPatternException("Custom time specifiers cannot be specified in the same pattern as an embedded time specifier");
			}
			Action<TResult, StringBuilder> a = null;
			foreach (Action<TResult, StringBuilder> formatAction in formatActions)
			{
				IPostPatternParseFormatAction postPatternParseFormatAction = formatAction.Target as IPostPatternParseFormatAction;
				a = (Action<TResult, StringBuilder>)Delegate.Combine(a, (postPatternParseFormatAction == null) ? formatAction : postPatternParseFormatAction.BuildFormatAction(usedFields));
			}
			return new SteppedPattern(a, formatOnly ? null : parseActions.ToArray(), bucketProvider, usedFields, sample);
		}

		internal void AddField(PatternFields field, char characterInPattern)
		{
			PatternFields patternFields = usedFields | field;
			if (patternFields == usedFields)
			{
				throw new InvalidPatternException("The field \"{0}\" is specified multiple times in the pattern.", characterInPattern);
			}
			usedFields = patternFields;
		}

		internal void AddParseAction(ParseAction parseAction)
		{
			parseActions.Add(parseAction);
		}

		internal void AddFormatAction(Action<TResult, StringBuilder> formatAction)
		{
			formatActions.Add(formatAction);
		}

		internal void AddParseInt64ValueAction(int minimumDigits, int maximumDigits, char patternChar, long minimumValue, long maximumValue, Action<TBucket, long> valueSetter)
		{
			AddParseAction(delegate(ValueCursor cursor, TBucket bucket)
			{
				int index = cursor.Index;
				if (!cursor.ParseInt64Digits(minimumDigits, maximumDigits, out var result))
				{
					cursor.Move(index);
					return ParseResult<TResult>.MismatchedNumber(cursor, new string(patternChar, minimumDigits));
				}
				if (result < minimumValue || result > maximumValue)
				{
					cursor.Move(index);
					return ParseResult<TResult>.FieldValueOutOfRange(cursor, result, patternChar);
				}
				valueSetter(bucket, result);
				return (ParseResult<TResult>)null;
			});
		}

		internal void AddParseValueAction(int minimumDigits, int maximumDigits, char patternChar, int minimumValue, int maximumValue, Action<TBucket, int> valueSetter)
		{
			AddParseAction(delegate(ValueCursor cursor, TBucket bucket)
			{
				int index = cursor.Index;
				bool flag = cursor.Match('-');
				if (flag && minimumValue >= 0)
				{
					cursor.Move(index);
					return ParseResult<TResult>.UnexpectedNegative(cursor);
				}
				if (!cursor.ParseDigits(minimumDigits, maximumDigits, out var result))
				{
					cursor.Move(index);
					return ParseResult<TResult>.MismatchedNumber(cursor, new string(patternChar, minimumDigits));
				}
				if (flag)
				{
					result = checked(-result);
				}
				if (result < minimumValue || result > maximumValue)
				{
					cursor.Move(index);
					return ParseResult<TResult>.FieldValueOutOfRange(cursor, result, patternChar);
				}
				valueSetter(bucket, result);
				return (ParseResult<TResult>)null;
			});
		}

		internal void AddLiteral(string expectedText, Func<ValueCursor, ParseResult<TResult>> failure)
		{
			if (expectedText.Length == 1)
			{
				char expectedChar = expectedText[0];
				AddParseAction((ValueCursor str, TBucket bucket) => (!str.Match(expectedChar)) ? failure(str) : null);
				AddFormatAction(delegate(TResult value, StringBuilder builder)
				{
					builder.Append(expectedChar);
				});
			}
			else
			{
				AddParseAction((ValueCursor str, TBucket bucket) => (!str.Match(expectedText)) ? failure(str) : null);
				AddFormatAction(delegate(TResult value, StringBuilder builder)
				{
					builder.Append(expectedText);
				});
			}
		}

		internal static void HandleQuote(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
		{
			string quotedString = pattern.GetQuotedString(pattern.Current);
			builder.AddLiteral(quotedString, ParseResult<TResult>.QuotedStringMismatch);
		}

		internal static void HandleBackslash(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
		{
			if (!pattern.MoveNext())
			{
				throw new InvalidPatternException("The format string has an escape character (backslash '') at the end of the string.");
			}
			builder.AddLiteral(pattern.Current, ParseResult<TResult>.EscapedCharacterMismatch);
		}

		internal static void HandlePercent(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
		{
			if (pattern.HasMoreCharacters)
			{
				if (pattern.PeekNext() != '%')
				{
					return;
				}
				throw new InvalidPatternException("A percent sign (%) is followed by another percent sign in the format string.");
			}
			throw new InvalidPatternException("A percent sign (%) appears at the end of the format string.");
		}

		internal static CharacterHandler<TResult, TBucket> HandlePaddedField(int maxCount, PatternFields field, int minValue, int maxValue, Func<TResult, int> getter, Action<TBucket, int> setter)
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(maxCount);
				builder.AddField(field, pattern.Current);
				builder.AddParseValueAction(repeatCount, maxCount, pattern.Current, minValue, maxValue, setter);
				builder.AddFormatLeftPad(repeatCount, getter, minValue >= 0, repeatCount == maxCount);
			};
		}

		internal void AddLiteral(char expectedChar, Func<ValueCursor, char, ParseResult<TResult>> failureSelector)
		{
			AddParseAction((ValueCursor str, TBucket bucket) => (!str.Match(expectedChar)) ? failureSelector(str, expectedChar) : null);
			AddFormatAction(delegate(TResult value, StringBuilder builder)
			{
				builder.Append(expectedChar);
			});
		}

		internal void AddParseLongestTextAction(char field, Action<TBucket, int> setter, CompareInfo compareInfo, IList<string> textValues)
		{
			AddParseAction(delegate(ValueCursor str, TBucket bucket)
			{
				int bestIndex = -1;
				int longestMatch = 0;
				FindLongestMatch(compareInfo, str, textValues, ref bestIndex, ref longestMatch);
				if (bestIndex != -1)
				{
					setter(bucket, bestIndex);
					str.Move(checked(str.Index + longestMatch));
					return (ParseResult<TResult>)null;
				}
				return ParseResult<TResult>.MismatchedText(str, field);
			});
		}

		internal void AddParseLongestTextAction(char field, Action<TBucket, int> setter, CompareInfo compareInfo, IList<string> textValues1, IList<string> textValues2)
		{
			AddParseAction(delegate(ValueCursor str, TBucket bucket)
			{
				int bestIndex = -1;
				int longestMatch = 0;
				FindLongestMatch(compareInfo, str, textValues1, ref bestIndex, ref longestMatch);
				FindLongestMatch(compareInfo, str, textValues2, ref bestIndex, ref longestMatch);
				if (bestIndex != -1)
				{
					setter(bucket, bestIndex);
					str.Move(checked(str.Index + longestMatch));
					return (ParseResult<TResult>)null;
				}
				return ParseResult<TResult>.MismatchedText(str, field);
			});
		}

		private static void FindLongestMatch(CompareInfo compareInfo, ValueCursor cursor, IList<string> values, ref int bestIndex, ref int longestMatch)
		{
			for (int i = 0; i < values.Count; i = checked(i + 1))
			{
				string text = values[i];
				if (text != null && text.Length > longestMatch && cursor.MatchCaseInsensitive(text, compareInfo, moveOnSuccess: false))
				{
					bestIndex = i;
					longestMatch = text.Length;
				}
			}
		}

		public void AddRequiredSign(Action<TBucket, bool> signSetter, Func<TResult, bool> nonNegativePredicate)
		{
			AddParseAction(delegate(ValueCursor str, TBucket bucket)
			{
				if (str.Match("-"))
				{
					signSetter(bucket, arg2: false);
					return (ParseResult<TResult>)null;
				}
				if (str.Match("+"))
				{
					signSetter(bucket, arg2: true);
					return (ParseResult<TResult>)null;
				}
				return ParseResult<TResult>.MissingSign(str);
			});
			AddFormatAction(delegate(TResult value, StringBuilder sb)
			{
				sb.Append(nonNegativePredicate(value) ? "+" : "-");
			});
		}

		public void AddNegativeOnlySign(Action<TBucket, bool> signSetter, Func<TResult, bool> nonNegativePredicate)
		{
			AddParseAction(delegate(ValueCursor str, TBucket bucket)
			{
				if (str.Match("-"))
				{
					signSetter(bucket, arg2: false);
					return (ParseResult<TResult>)null;
				}
				if (str.Match("+"))
				{
					return ParseResult<TResult>.PositiveSignInvalid(str);
				}
				signSetter(bucket, arg2: true);
				return (ParseResult<TResult>)null;
			});
			AddFormatAction(delegate(TResult value, StringBuilder builder)
			{
				if (!nonNegativePredicate(value))
				{
					builder.Append("-");
				}
			});
		}

		internal void AddFormatLeftPad(int count, Func<TResult, int> selector, bool assumeNonNegative, bool assumeFitsInCount)
		{
			if (count == 2 && assumeNonNegative && assumeFitsInCount)
			{
				AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					FormatHelper.Format2DigitsNonNegative(selector(value), sb);
				});
			}
			else if (count == 4 && assumeFitsInCount)
			{
				AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					FormatHelper.Format4DigitsValueFits(selector(value), sb);
				});
			}
			else if (assumeNonNegative)
			{
				AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					FormatHelper.LeftPadNonNegative(selector(value), count, sb);
				});
			}
			else
			{
				AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					FormatHelper.LeftPad(selector(value), count, sb);
				});
			}
		}

		internal void AddFormatFraction(int width, int scale, Func<TResult, int> selector)
		{
			AddFormatAction(delegate(TResult value, StringBuilder sb)
			{
				FormatHelper.AppendFraction(selector(value), width, scale, sb);
			});
		}

		internal void AddFormatFractionTruncate(int width, int scale, Func<TResult, int> selector)
		{
			AddFormatAction(delegate(TResult value, StringBuilder sb)
			{
				FormatHelper.AppendFractionTruncate(selector(value), width, scale, sb);
			});
		}

		internal void AddEmbeddedLocalPartial(PatternCursor pattern, Func<TBucket, LocalDatePatternParser.LocalDateParseBucket> dateBucketExtractor, Func<TBucket, LocalTimePatternParser.LocalTimeParseBucket> timeBucketExtractor, Func<TResult, LocalDate> dateExtractor, Func<TResult, LocalTime> timeExtractor, Func<TResult, LocalDateTime> dateTimeExtractor)
		{
			char c = pattern.PeekNext();
			if (c == 'd' || c == 't')
			{
				pattern.MoveNext();
			}
			string embeddedPattern = pattern.GetEmbeddedPattern();
			switch (c)
			{
			case '<':
			{
				TBucket arg = CreateSampleBucket();
				LocalTime templateValue = timeBucketExtractor(arg).TemplateValue;
				LocalDate templateValue2 = dateBucketExtractor(arg).TemplateValue;
				if (dateTimeExtractor == null)
				{
					throw new InvalidPatternException("The type of embedded pattern is not supported for this type.");
				}
				AddField(PatternFields.EmbeddedDate, 'l');
				AddField(PatternFields.EmbeddedTime, 'l');
				AddEmbeddedPattern(LocalDateTimePattern.Create(embeddedPattern, FormatInfo, templateValue2 + templateValue).UnderlyingPattern, delegate(TBucket bucket, LocalDateTime value)
				{
					LocalDatePatternParser.LocalDateParseBucket localDateParseBucket = dateBucketExtractor(bucket);
					LocalTimePatternParser.LocalTimeParseBucket localTimeParseBucket = timeBucketExtractor(bucket);
					localDateParseBucket.Calendar = value.Calendar;
					localDateParseBucket.Year = value.Year;
					localDateParseBucket.MonthOfYearNumeric = value.Month;
					localDateParseBucket.DayOfMonth = value.Day;
					localTimeParseBucket.Hours24 = value.Hour;
					localTimeParseBucket.Minutes = value.Minute;
					localTimeParseBucket.Seconds = value.Second;
					localTimeParseBucket.FractionalSeconds = value.NanosecondOfSecond;
				}, dateTimeExtractor);
				break;
			}
			case 'd':
				AddEmbeddedDatePattern('l', embeddedPattern, dateBucketExtractor, dateExtractor);
				break;
			case 't':
				AddEmbeddedTimePattern('l', embeddedPattern, timeBucketExtractor, timeExtractor);
				break;
			default:
				throw new InvalidOperationException("Bug in Noda Time: embedded pattern type wasn't date, time, or date+time");
			}
		}

		internal void AddEmbeddedDatePattern(char characterInPattern, string embeddedPatternText, Func<TBucket, LocalDatePatternParser.LocalDateParseBucket> dateBucketExtractor, Func<TResult, LocalDate> dateExtractor)
		{
			LocalDate templateValue = dateBucketExtractor(CreateSampleBucket()).TemplateValue;
			AddField(PatternFields.EmbeddedDate, characterInPattern);
			AddEmbeddedPattern(LocalDatePattern.Create(embeddedPatternText, FormatInfo, templateValue).UnderlyingPattern, delegate(TBucket bucket, LocalDate value)
			{
				LocalDatePatternParser.LocalDateParseBucket localDateParseBucket = dateBucketExtractor(bucket);
				localDateParseBucket.Calendar = value.Calendar;
				localDateParseBucket.Year = value.Year;
				localDateParseBucket.MonthOfYearNumeric = value.Month;
				localDateParseBucket.DayOfMonth = value.Day;
			}, dateExtractor);
		}

		internal void AddEmbeddedTimePattern(char characterInPattern, string embeddedPatternText, Func<TBucket, LocalTimePatternParser.LocalTimeParseBucket> timeBucketExtractor, Func<TResult, LocalTime> timeExtractor)
		{
			LocalTime templateValue = timeBucketExtractor(CreateSampleBucket()).TemplateValue;
			AddField(PatternFields.EmbeddedTime, characterInPattern);
			AddEmbeddedPattern(LocalTimePattern.Create(embeddedPatternText, FormatInfo, templateValue).UnderlyingPattern, delegate(TBucket bucket, LocalTime value)
			{
				LocalTimePatternParser.LocalTimeParseBucket localTimeParseBucket = timeBucketExtractor(bucket);
				localTimeParseBucket.Hours24 = value.Hour;
				localTimeParseBucket.Minutes = value.Minute;
				localTimeParseBucket.Seconds = value.Second;
				localTimeParseBucket.FractionalSeconds = value.NanosecondOfSecond;
			}, timeExtractor);
		}

		internal void AddEmbeddedPattern<TEmbedded>(IPartialPattern<TEmbedded> embeddedPattern, Action<TBucket, TEmbedded> parseAction, Func<TResult, TEmbedded> valueExtractor)
		{
			AddParseAction(delegate(ValueCursor value, TBucket bucket)
			{
				ParseResult<TEmbedded> parseResult = embeddedPattern.ParsePartial(value);
				if (!parseResult.Success)
				{
					return parseResult.ConvertError<TResult>();
				}
				parseAction(bucket, parseResult.Value);
				return (ParseResult<TResult>)null;
			});
			AddFormatAction(delegate(TResult value, StringBuilder sb)
			{
				embeddedPattern.AppendFormat(valueExtractor(value), sb);
			});
		}
	}
	internal static class TimePatternHelper
	{
		internal static CharacterHandler<TResult, TBucket> CreatePeriodHandler<TResult, TBucket>(int maxCount, Func<TResult, int> getter, Action<TBucket, int> setter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				if (pattern.PeekNext() == 'F')
				{
					pattern.MoveNext();
					int count = pattern.GetRepeatCount(maxCount);
					builder.AddField(PatternFields.FractionalSeconds, pattern.Current);
					builder.AddParseAction(delegate(ValueCursor valueCursor, TBucket bucket)
					{
						if (!valueCursor.Match('.'))
						{
							return (ParseResult<TResult>)null;
						}
						if (!valueCursor.ParseFraction(count, maxCount, out var result, 1))
						{
							return ParseResult<TResult>.MismatchedNumber(valueCursor, new string('F', count));
						}
						setter(bucket, result);
						return (ParseResult<TResult>)null;
					});
					builder.AddFormatAction(delegate(TResult localTime, StringBuilder sb)
					{
						sb.Append('.');
					});
					builder.AddFormatFractionTruncate(count, maxCount, getter);
				}
				else
				{
					builder.AddLiteral('.', ParseResult<TResult>.MismatchedCharacter);
				}
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateCommaDotHandler<TResult, TBucket>(int maxCount, Func<TResult, int> getter, Action<TBucket, int> setter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				if (pattern.PeekNext() == 'F')
				{
					pattern.MoveNext();
					int count = pattern.GetRepeatCount(maxCount);
					builder.AddField(PatternFields.FractionalSeconds, pattern.Current);
					builder.AddParseAction(delegate(ValueCursor valueCursor, TBucket bucket)
					{
						if (!valueCursor.Match('.') && !valueCursor.Match(','))
						{
							return (ParseResult<TResult>)null;
						}
						if (!valueCursor.ParseFraction(count, maxCount, out var result, 1))
						{
							return ParseResult<TResult>.MismatchedNumber(valueCursor, new string('F', count));
						}
						setter(bucket, result);
						return (ParseResult<TResult>)null;
					});
					builder.AddFormatAction(delegate(TResult localTime, StringBuilder sb)
					{
						sb.Append('.');
					});
					builder.AddFormatFractionTruncate(count, maxCount, getter);
				}
				else
				{
					builder.AddParseAction((ValueCursor str, TBucket bucket) => (!str.Match('.') && !str.Match(',')) ? ParseResult<TResult>.MismatchedCharacter(str, ';') : null);
					builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
					{
						sb.Append('.');
					});
				}
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateFractionHandler<TResult, TBucket>(int maxCount, Func<TResult, int> getter, Action<TBucket, int> setter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				char patternCharacter = pattern.Current;
				int count = pattern.GetRepeatCount(maxCount);
				builder.AddField(PatternFields.FractionalSeconds, pattern.Current);
				builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
				{
					if (!str.ParseFraction(count, maxCount, out var result, (patternCharacter == 'f') ? count : 0))
					{
						return ParseResult<TResult>.MismatchedNumber(str, new string(patternCharacter, count));
					}
					setter(bucket, result);
					return (ParseResult<TResult>)null;
				});
				if (patternCharacter == 'f')
				{
					builder.AddFormatFraction(count, maxCount, getter);
				}
				else
				{
					builder.AddFormatFractionTruncate(count, maxCount, getter);
				}
			};
		}

		internal static CharacterHandler<TResult, TBucket> CreateAmPmHandler<TResult, TBucket>(Func<TResult, int> hourOfDayGetter, Action<TBucket, int> amPmSetter) where TBucket : ParseBucket<TResult>
		{
			return delegate(PatternCursor pattern, SteppedPatternBuilder<TResult, TBucket> builder)
			{
				int repeatCount = pattern.GetRepeatCount(2);
				builder.AddField(PatternFields.AmPm, pattern.Current);
				string amDesignator = builder.FormatInfo.AMDesignator;
				string pmDesignator = builder.FormatInfo.PMDesignator;
				if (amDesignator == "" && pmDesignator == "")
				{
					builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
					{
						amPmSetter(bucket, 2);
						return (ParseResult<TResult>)null;
					});
				}
				else if (amDesignator == "" || pmDesignator == "")
				{
					int num = ((amDesignator == "") ? 1 : 0);
					string specifiedDesignator = ((num == 1) ? pmDesignator : amDesignator);
					HandleHalfAmPmDesignator(repeatCount, specifiedDesignator, num, hourOfDayGetter, amPmSetter, builder);
				}
				else
				{
					CompareInfo compareInfo = builder.FormatInfo.CompareInfo;
					if (repeatCount == 1)
					{
						string amFirst = amDesignator.Substring(0, 1);
						string pmFirst = pmDesignator.Substring(0, 1);
						builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
						{
							if (str.MatchCaseInsensitive(amFirst, compareInfo, moveOnSuccess: true))
							{
								amPmSetter(bucket, 0);
								return (ParseResult<TResult>)null;
							}
							if (str.MatchCaseInsensitive(pmFirst, compareInfo, moveOnSuccess: true))
							{
								amPmSetter(bucket, 1);
								return (ParseResult<TResult>)null;
							}
							return ParseResult<TResult>.MissingAmPmDesignator(str);
						});
						builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
						{
							sb.Append((hourOfDayGetter(value) > 11) ? pmDesignator[0] : amDesignator[0]);
						});
					}
					else
					{
						builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
						{
							bool num2 = pmDesignator.Length > amDesignator.Length;
							string match = (num2 ? pmDesignator : amDesignator);
							string match2 = (num2 ? amDesignator : pmDesignator);
							int num3 = (num2 ? 1 : 0);
							if (str.MatchCaseInsensitive(match, compareInfo, moveOnSuccess: true))
							{
								amPmSetter(bucket, num3);
								return (ParseResult<TResult>)null;
							}
							if (str.MatchCaseInsensitive(match2, compareInfo, moveOnSuccess: true))
							{
								amPmSetter(bucket, checked(1 - num3));
								return (ParseResult<TResult>)null;
							}
							return ParseResult<TResult>.MissingAmPmDesignator(str);
						});
						builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
						{
							sb.Append((hourOfDayGetter(value) > 11) ? pmDesignator : amDesignator);
						});
					}
				}
			};
		}

		private static void HandleHalfAmPmDesignator<TResult, TBucket>(int count, string specifiedDesignator, int specifiedDesignatorValue, Func<TResult, int> hourOfDayGetter, Action<TBucket, int> amPmSetter, SteppedPatternBuilder<TResult, TBucket> builder) where TBucket : ParseBucket<TResult>
		{
			CompareInfo compareInfo = builder.FormatInfo.CompareInfo;
			if (count == 1)
			{
				string abbreviation = specifiedDesignator.Substring(0, 1);
				builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
				{
					int arg = (str.MatchCaseInsensitive(abbreviation, compareInfo, moveOnSuccess: true) ? specifiedDesignatorValue : checked(1 - specifiedDesignatorValue));
					amPmSetter(bucket, arg);
					return (ParseResult<TResult>)null;
				});
				builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
				{
					if (hourOfDayGetter(value) / 12 == specifiedDesignatorValue)
					{
						sb.Append(specifiedDesignator[0]);
					}
				});
				return;
			}
			builder.AddParseAction(delegate(ValueCursor str, TBucket bucket)
			{
				int arg = (str.MatchCaseInsensitive(specifiedDesignator, compareInfo, moveOnSuccess: true) ? specifiedDesignatorValue : checked(1 - specifiedDesignatorValue));
				amPmSetter(bucket, arg);
				return (ParseResult<TResult>)null;
			});
			builder.AddFormatAction(delegate(TResult value, StringBuilder sb)
			{
				if (hourOfDayGetter(value) / 12 == specifiedDesignatorValue)
				{
					sb.Append(specifiedDesignator);
				}
			});
		}
	}
}
namespace NodaTime.Globalization
{
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	internal sealed class NodaFormatInfo
	{
		private class EraDescription
		{
			internal string PrimaryName { get; }

			internal ReadOnlyCollection<string> AllNames { get; }

			private EraDescription(string primaryName, ReadOnlyCollection<string> allNames)
			{
				PrimaryName = primaryName;
				AllNames = allNames;
			}

			internal static EraDescription ForEra(Era era, CultureInfo cultureInfo)
			{
				string text = PatternResources.ResourceManager.GetString(era.ResourceIdentifier, cultureInfo);
				string[] array;
				string primaryName;
				if (text == null)
				{
					array = new string[0];
					primaryName = "";
				}
				else
				{
					string eraNameFromBcl = GetEraNameFromBcl(era, cultureInfo);
					if (eraNameFromBcl != null && !text.StartsWith(eraNameFromBcl + "|"))
					{
						text = eraNameFromBcl + "|" + text;
					}
					array = text.Split(new char[1] { '|' });
					primaryName = array[0];
					Array.Sort(array, (string x, string y) => y.Length.CompareTo(x.Length));
				}
				return new EraDescription(primaryName, new ReadOnlyCollection<string>(array));
			}

			private static string GetEraNameFromBcl(Era era, CultureInfo culture)
			{
				string fullName = culture.DateTimeFormat.Calendar.GetType().FullName;
				if ((era != Era.Common || !(fullName == "System.Globalization.GregorianCalendar")) && (era != Era.AnnoPersico || !(fullName == "System.Globalization.PersianCalendar")) && (era != Era.AnnoHegirae || (!(fullName == "System.Globalization.HijriCalendar") && !(fullName == "System.Globalization.UmAlQuraCalendar"))))
				{
					return null;
				}
				return culture.DateTimeFormat.GetEraName(1);
			}
		}

		private static readonly string[] ShortInvariantMonthNames = (string[])CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames.Clone();

		private static readonly string[] LongInvariantMonthNames = (string[])CultureInfo.InvariantCulture.DateTimeFormat.MonthNames.Clone();

		private readonly object fieldLock = new object();

		private FixedFormatInfoPatternParser<Duration> durationPatternParser;

		private FixedFormatInfoPatternParser<Offset> offsetPatternParser;

		private FixedFormatInfoPatternParser<Instant> instantPatternParser;

		private FixedFormatInfoPatternParser<LocalTime> localTimePatternParser;

		private FixedFormatInfoPatternParser<LocalDate> localDatePatternParser;

		private FixedFormatInfoPatternParser<LocalDateTime> localDateTimePatternParser;

		private FixedFormatInfoPatternParser<OffsetDateTime> offsetDateTimePatternParser;

		private FixedFormatInfoPatternParser<OffsetDate> offsetDatePatternParser;

		private FixedFormatInfoPatternParser<OffsetTime> offsetTimePatternParser;

		private FixedFormatInfoPatternParser<ZonedDateTime> zonedDateTimePatternParser;

		private FixedFormatInfoPatternParser<AnnualDate> annualDatePatternParser;

		public static readonly NodaFormatInfo InvariantInfo = new NodaFormatInfo(CultureInfo.InvariantCulture);

		private static readonly Cache<CultureInfo, NodaFormatInfo> Cache = new Cache<CultureInfo, NodaFormatInfo>(500, (CultureInfo culture) => new NodaFormatInfo(culture), new ReferenceEqualityComparer<CultureInfo>());

		private readonly string dateSeparator;

		private readonly string timeSeparator;

		private IList<string> longMonthNames;

		private IList<string> longMonthGenitiveNames;

		private IList<string> longDayNames;

		private IList<string> shortMonthNames;

		private IList<string> shortMonthGenitiveNames;

		private IList<string> shortDayNames;

		private readonly ConcurrentDictionary<Era, EraDescription> eraDescriptions;

		public CultureInfo CultureInfo { get; }

		public CompareInfo CompareInfo => CultureInfo.CompareInfo;

		internal FixedFormatInfoPatternParser<Duration> DurationPatternParser => EnsureFixedFormatInitialized(ref durationPatternParser, () => new DurationPatternParser());

		internal FixedFormatInfoPatternParser<Offset> OffsetPatternParser => EnsureFixedFormatInitialized(ref offsetPatternParser, () => new OffsetPatternParser());

		internal FixedFormatInfoPatternParser<Instant> InstantPatternParser => EnsureFixedFormatInitialized(ref instantPatternParser, () => new InstantPatternParser());

		internal FixedFormatInfoPatternParser<LocalTime> LocalTimePatternParser => EnsureFixedFormatInitialized(ref localTimePatternParser, () => new LocalTimePatternParser(LocalTime.Midnight));

		internal FixedFormatInfoPatternParser<LocalDate> LocalDatePatternParser => EnsureFixedFormatInitialized(ref localDatePatternParser, () => new LocalDatePatternParser(LocalDatePattern.DefaultTemplateValue));

		internal FixedFormatInfoPatternParser<LocalDateTime> LocalDateTimePatternParser => EnsureFixedFormatInitialized(ref localDateTimePatternParser, () => new LocalDateTimePatternParser(LocalDateTimePattern.DefaultTemplateValue));

		internal FixedFormatInfoPatternParser<OffsetDateTime> OffsetDateTimePatternParser => EnsureFixedFormatInitialized(ref offsetDateTimePatternParser, () => new OffsetDateTimePatternParser(OffsetDateTimePattern.DefaultTemplateValue));

		internal FixedFormatInfoPatternParser<OffsetDate> OffsetDatePatternParser => EnsureFixedFormatInitialized(ref offsetDatePatternParser, () => new OffsetDatePatternParser(OffsetDatePattern.DefaultTemplateValue));

		internal FixedFormatInfoPatternParser<OffsetTime> OffsetTimePatternParser => EnsureFixedFormatInitialized(ref offsetTimePatternParser, () => new OffsetTimePatternParser(OffsetTimePattern.DefaultTemplateValue));

		internal FixedFormatInfoPatternParser<ZonedDateTime> ZonedDateTimePatternParser => EnsureFixedFormatInitialized(ref zonedDateTimePatternParser, () => new ZonedDateTimePatternParser(ZonedDateTimePattern.DefaultTemplateValue, Resolvers.StrictResolver, null));

		internal FixedFormatInfoPatternParser<AnnualDate> AnnualDatePatternParser => EnsureFixedFormatInitialized(ref annualDatePatternParser, () => new AnnualDatePatternParser(AnnualDatePattern.DefaultTemplateValue));

		public IList<string> LongMonthNames
		{
			get
			{
				EnsureMonthsInitialized();
				return longMonthNames;
			}
		}

		public IList<string> ShortMonthNames
		{
			get
			{
				EnsureMonthsInitialized();
				return shortMonthNames;
			}
		}

		public IList<string> LongMonthGenitiveNames
		{
			get
			{
				EnsureMonthsInitialized();
				return longMonthGenitiveNames;
			}
		}

		public IList<string> ShortMonthGenitiveNames
		{
			get
			{
				EnsureMonthsInitialized();
				return shortMonthGenitiveNames;
			}
		}

		public IList<string> LongDayNames
		{
			get
			{
				EnsureDaysInitialized();
				return longDayNames;
			}
		}

		public IList<string> ShortDayNames
		{
			get
			{
				EnsureDaysInitialized();
				return shortDayNames;
			}
		}

		public DateTimeFormatInfo DateTimeFormat { get; }

		public string TimeSeparator => timeSeparator;

		public string DateSeparator => dateSeparator;

		public string AMDesignator => DateTimeFormat.AMDesignator;

		public string PMDesignator => DateTimeFormat.PMDesignator;

		public static NodaFormatInfo CurrentInfo => GetInstance(CultureInfo.CurrentCulture);

		public string OffsetPatternLong => PatternResources.ResourceManager.GetString("OffsetPatternLong", CultureInfo);

		public string OffsetPatternMedium => PatternResources.ResourceManager.GetString("OffsetPatternMedium", CultureInfo);

		public string OffsetPatternShort => PatternResources.ResourceManager.GetString("OffsetPatternShort", CultureInfo);

		public string OffsetPatternLongNoPunctuation => PatternResources.ResourceManager.GetString("OffsetPatternLongNoPunctuation", CultureInfo);

		public string OffsetPatternMediumNoPunctuation => PatternResources.ResourceManager.GetString("OffsetPatternMediumNoPunctuation", CultureInfo);

		public string OffsetPatternShortNoPunctuation => PatternResources.ResourceManager.GetString("OffsetPatternShortNoPunctuation", CultureInfo);

		[VisibleForTesting]
		internal NodaFormatInfo([NotNull] CultureInfo cultureInfo)
			: this(cultureInfo, cultureInfo?.DateTimeFormat)
		{
		}

		[VisibleForTesting]
		internal NodaFormatInfo([NotNull] CultureInfo cultureInfo, [NotNull] DateTimeFormatInfo dateTimeFormat)
		{
			Preconditions.CheckNotNull(cultureInfo, "cultureInfo");
			Preconditions.CheckNotNull(dateTimeFormat, "dateTimeFormat");
			CultureInfo = cultureInfo;
			DateTimeFormat = dateTimeFormat;
			eraDescriptions = new ConcurrentDictionary<Era, EraDescription>();
			DateTime minValue = DateTime.MinValue;
			dateSeparator = minValue.ToString("%/", cultureInfo);
			minValue = DateTime.MinValue;
			timeSeparator = minValue.ToString("%:", cultureInfo);
		}

		private void EnsureMonthsInitialized()
		{
			lock (fieldLock)
			{
				if (longMonthNames == null)
				{
					longMonthNames = ConvertMonthArray(DateTimeFormat.MonthNames);
					shortMonthNames = ConvertMonthArray(DateTimeFormat.AbbreviatedMonthNames);
					longMonthGenitiveNames = ConvertGenitiveMonthArray(longMonthNames, DateTimeFormat.MonthGenitiveNames, LongInvariantMonthNames);
					shortMonthGenitiveNames = ConvertGenitiveMonthArray(shortMonthNames, DateTimeFormat.AbbreviatedMonthGenitiveNames, ShortInvariantMonthNames);
				}
			}
		}

		private static IList<string> ConvertMonthArray(string[] monthNames)
		{
			List<string> list = new List<string>(monthNames);
			list.Insert(0, null);
			return new ReadOnlyCollection<string>(list);
		}

		private void EnsureDaysInitialized()
		{
			lock (fieldLock)
			{
				if (longDayNames == null)
				{
					longDayNames = ConvertDayArray(DateTimeFormat.DayNames);
					shortDayNames = ConvertDayArray(DateTimeFormat.AbbreviatedDayNames);
				}
			}
		}

		private static IList<string> ConvertDayArray(string[] dayNames)
		{
			List<string> list = new List<string>(dayNames);
			list.Add(dayNames[0]);
			list[0] = null;
			return new ReadOnlyCollection<string>(list);
		}

		private IList<string> ConvertGenitiveMonthArray(IList<string> nonGenitiveNames, string[] bclNames, string[] invariantNames)
		{
			if (int.TryParse(bclNames[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var _))
			{
				return nonGenitiveNames;
			}
			checked
			{
				for (int i = 0; i < bclNames.Length; i++)
				{
					if (bclNames[i] != nonGenitiveNames[i + 1] && bclNames[i] != invariantNames[i])
					{
						return ConvertMonthArray(bclNames);
					}
				}
				return nonGenitiveNames;
			}
		}

		private FixedFormatInfoPatternParser<T> EnsureFixedFormatInitialized<T>(ref FixedFormatInfoPatternParser<T> field, Func<IPatternParser<T>> patternParserFactory)
		{
			lock (fieldLock)
			{
				if (field != null)
				{
					return field;
				}
			}
			FixedFormatInfoPatternParser<T> fixedFormatInfoPatternParser = new FixedFormatInfoPatternParser<T>(patternParserFactory(), this);
			lock (fieldLock)
			{
				if (field == null)
				{
					field = fixedFormatInfoPatternParser;
				}
				return field;
			}
		}

		public IList<string> GetEraNames([NotNull] Era era)
		{
			Preconditions.CheckNotNull(era, "era");
			return GetEraDescription(era).AllNames;
		}

		public string GetEraPrimaryName([NotNull] Era era)
		{
			Preconditions.CheckNotNull(era, "era");
			return GetEraDescription(era).PrimaryName;
		}

		private EraDescription GetEraDescription(Era era)
		{
			return eraDescriptions.GetOrAdd(era, (Era key) => EraDescription.ForEra(key, CultureInfo));
		}

		internal static void ClearCache()
		{
			Cache.Clear();
		}

		internal static NodaFormatInfo GetFormatInfo([NotNull] CultureInfo cultureInfo)
		{
			Preconditions.CheckNotNull(cultureInfo, "cultureInfo");
			if (cultureInfo == CultureInfo.InvariantCulture)
			{
				return InvariantInfo;
			}
			if (!cultureInfo.IsReadOnly)
			{
				return new NodaFormatInfo(cultureInfo);
			}
			return Cache.GetOrAdd(cultureInfo);
		}

		public static NodaFormatInfo GetInstance(IFormatProvider provider)
		{
			if (provider != null)
			{
				if (!(provider is CultureInfo cultureInfo))
				{
					if (provider is DateTimeFormatInfo dateTimeFormatInfo)
					{
						DateTimeFormatInfo dateTimeFormat = dateTimeFormatInfo;
						return new NodaFormatInfo(CultureInfo.InvariantCulture, dateTimeFormat);
					}
					throw new ArgumentException($"Cannot use provider of type {provider.GetType().FullName} in Noda Time", "provider");
				}
				return GetFormatInfo(cultureInfo);
			}
			return GetFormatInfo(CurrentInfo.CultureInfo);
		}

		public override string ToString()
		{
			return "NodaFormatInfo[" + CultureInfo.Name + "]";
		}
	}
	internal static class PatternResources
	{
		internal static ResourceManager ResourceManager { get; } = new ResourceManager(typeof(PatternResources).FullName, typeof(PatternResources).GetTypeInfo().Assembly);
	}
}
namespace NodaTime.Fields
{
	internal static class DatePeriodFields
	{
		internal static readonly IDatePeriodField DaysField = new FixedLengthDatePeriodField(1);

		internal static readonly IDatePeriodField WeeksField = new FixedLengthDatePeriodField(7);

		internal static readonly IDatePeriodField MonthsField = new MonthsPeriodField();

		internal static readonly IDatePeriodField YearsField = new YearsPeriodField();
	}
	internal sealed class FixedLengthDatePeriodField : IDatePeriodField
	{
		private readonly int unitDays;

		internal FixedLengthDatePeriodField(int unitDays)
		{
			this.unitDays = unitDays;
		}

		public LocalDate Add(LocalDate localDate, int value)
		{
			if (value == 0)
			{
				return localDate;
			}
			checked
			{
				int num = value * unitDays;
				CalendarSystem calendar = localDate.Calendar;
				if (num < 300 && num > -300)
				{
					YearMonthDayCalculator yearMonthDayCalculator = calendar.YearMonthDayCalculator;
					YearMonthDay yearMonthDay = localDate.YearMonthDay;
					int num2 = yearMonthDay.Year;
					int month = yearMonthDay.Month;
					int num3 = yearMonthDay.Day + num;
					if (1 <= num3 && num3 <= yearMonthDayCalculator.GetDaysInMonth(num2, month))
					{
						return new LocalDate(new YearMonthDayCalendar(num2, month, num3, calendar.Ordinal));
					}
					int num4 = yearMonthDayCalculator.GetDayOfYear(yearMonthDay) + num;
					if (num4 < 1)
					{
						num4 += yearMonthDayCalculator.GetDaysInYear(num2 - 1);
						num2--;
						if (num2 < yearMonthDayCalculator.MinYear)
						{
							throw new OverflowException("Date computation would underflow the minimum year of the calendar");
						}
					}
					else
					{
						int daysInYear = yearMonthDayCalculator.GetDaysInYear(num2);
						if (num4 > daysInYear)
						{
							num4 -= daysInYear;
							num2++;
							if (num2 > yearMonthDayCalculator.MaxYear)
							{
								throw new OverflowException("Date computation would overflow the maximum year of the calendar");
							}
						}
					}
					return new LocalDate(yearMonthDayCalculator.GetYearMonthDay(num2, num4).WithCalendarOrdinal(calendar.Ordinal));
				}
				return new LocalDate(localDate.DaysSinceEpoch + num, calendar);
			}
		}

		public int UnitsBetween(LocalDate start, LocalDate end)
		{
			return Period.DaysBetween(start, end) / unitDays;
		}
	}
	internal interface IDatePeriodField
	{
		LocalDate Add(LocalDate localDate, int value);

		int UnitsBetween(LocalDate start, LocalDate end);
	}
	internal sealed class MonthsPeriodField : IDatePeriodField
	{
		internal MonthsPeriodField()
		{
		}

		public LocalDate Add(LocalDate localDate, int value)
		{
			CalendarSystem calendar = localDate.Calendar;
			return new LocalDate(calendar.YearMonthDayCalculator.AddMonths(localDate.YearMonthDay, value).WithCalendar(calendar));
		}

		public int UnitsBetween(LocalDate start, LocalDate end)
		{
			return start.Calendar.YearMonthDayCalculator.MonthsBetween(start.YearMonthDay, end.YearMonthDay);
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	internal sealed class TimePeriodField
	{
		internal static readonly TimePeriodField Nanoseconds = new TimePeriodField(1L);

		internal static readonly TimePeriodField Ticks = new TimePeriodField(100L);

		internal static readonly TimePeriodField Milliseconds = new TimePeriodField(1000000L);

		internal static readonly TimePeriodField Seconds = new TimePeriodField(1000000000L);

		internal static readonly TimePeriodField Minutes = new TimePeriodField(60000000000L);

		internal static readonly TimePeriodField Hours = new TimePeriodField(3600000000000L);

		private readonly long unitNanoseconds;

		private readonly long maxLongUnits;

		private readonly long unitsPerDay;

		private TimePeriodField(long unitNanoseconds)
		{
			this.unitNanoseconds = unitNanoseconds;
			maxLongUnits = 9223372036854775807L / unitNanoseconds;
			unitsPerDay = 86400000000000L / unitNanoseconds;
		}

		internal LocalDateTime Add(LocalDateTime start, long units)
		{
			int extraDays = 0;
			LocalTime time = Add(start.TimeOfDay, units, ref extraDays);
			return new LocalDateTime((extraDays == 0) ? start.Date : start.Date.PlusDays(extraDays), time);
		}

		internal LocalTime Add(LocalTime localTime, long value)
		{
			if (value >= 0)
			{
				if (value >= unitsPerDay)
				{
					value %= unitsPerDay;
				}
				long num = value * unitNanoseconds;
				long num2 = localTime.NanosecondOfDay + num;
				if (num2 >= 86400000000000L)
				{
					num2 -= 86400000000000L;
				}
				return new LocalTime(num2);
			}
			if (value <= -unitsPerDay)
			{
				value %= unitsPerDay;
			}
			long num3 = value * unitNanoseconds;
			long num4 = localTime.NanosecondOfDay + num3;
			if (num4 < 0)
			{
				num4 += 86400000000000L;
			}
			return new LocalTime(num4);
		}

		internal LocalTime Add(LocalTime localTime, long value, ref int extraDays)
		{
			if (value == 0L)
			{
				return localTime;
			}
			int num = 0;
			if (value >= 0)
			{
				if (value >= unitsPerDay)
				{
					checked
					{
						num = (int)unchecked(value / unitsPerDay);
					}
					value %= unitsPerDay;
				}
				long num2 = value * unitNanoseconds;
				long num3 = localTime.NanosecondOfDay + num2;
				if (num3 >= 86400000000000L)
				{
					num3 -= 86400000000000L;
					num = checked(num + 1);
				}
				checked
				{
					extraDays += num;
					return new LocalTime(num3);
				}
			}
			if (value <= -unitsPerDay)
			{
				checked
				{
					num = (int)unchecked(value / unitsPerDay);
				}
				value %= unitsPerDay;
			}
			long num4 = value * unitNanoseconds;
			long num5 = localTime.NanosecondOfDay + num4;
			if (num5 < 0)
			{
				num5 += 86400000000000L;
				num = checked(num - 1);
			}
			extraDays = checked(num + extraDays);
			return new LocalTime(num5);
		}

		internal long UnitsBetween(LocalDateTime start, LocalDateTime end)
		{
			LocalInstant localInstant = start.ToLocalInstant();
			Duration duration = end.ToLocalInstant().TimeSinceLocalEpoch - localInstant.TimeSinceLocalEpoch;
			return GetUnitsInDuration(duration);
		}

		internal long GetUnitsInDuration(Duration duration)
		{
			if (!duration.IsInt64Representable)
			{
				return (long)(duration.ToDecimalNanoseconds() / (decimal)unitNanoseconds);
			}
			return duration.ToInt64Nanoseconds() / unitNanoseconds;
		}

		internal Duration ToDuration(long units)
		{
			checked
			{
				if (units < -maxLongUnits || units > maxLongUnits)
				{
					return Duration.FromNanoseconds((decimal)units * (decimal)unitNanoseconds);
				}
				return Duration.FromNanoseconds(units * unitNanoseconds);
			}
		}
	}
	internal sealed class YearsPeriodField : IDatePeriodField
	{
		internal YearsPeriodField()
		{
		}

		public LocalDate Add(LocalDate localDate, int value)
		{
			if (value == 0)
			{
				return localDate;
			}
			YearMonthDay yearMonthDay = localDate.YearMonthDay;
			CalendarSystem calendar = localDate.Calendar;
			YearMonthDayCalculator yearMonthDayCalculator = calendar.YearMonthDayCalculator;
			int year = yearMonthDay.Year;
			checked
			{
				Preconditions.CheckArgumentRange("value", value, yearMonthDayCalculator.MinYear - year, yearMonthDayCalculator.MaxYear - year);
				return new LocalDate(yearMonthDayCalculator.SetYear(yearMonthDay, year + value).WithCalendarOrdinal(calendar.Ordinal));
			}
		}

		public int UnitsBetween(LocalDate start, LocalDate end)
		{
			checked
			{
				int num = end.Year - start.Year;
				LocalDate localDate = Add(start, num);
				if (start <= end)
				{
					if (!(localDate <= end))
					{
						return num - 1;
					}
					return num;
				}
				if (!(localDate >= end))
				{
					return num + 1;
				}
				return num;
			}
		}
	}
}
namespace NodaTime.Extensions
{
	public static class ClockExtensions
	{
		[NotNull]
		public static ZonedClock InZone([NotNull] this IClock clock, [NotNull] DateTimeZone zone)
		{
			return clock.InZone(zone, CalendarSystem.Iso);
		}

		[NotNull]
		public static ZonedClock InZone([NotNull] this IClock clock, [NotNull] DateTimeZone zone, [NotNull] CalendarSystem calendar)
		{
			return new ZonedClock(clock, zone, calendar);
		}

		[NotNull]
		public static ZonedClock InUtc([NotNull] this IClock clock)
		{
			return new ZonedClock(clock, DateTimeZone.Utc, CalendarSystem.Iso);
		}

		[NotNull]
		public static ZonedClock InTzdbSystemDefaultZone([NotNull] this IClock clock)
		{
			DateTimeZone systemDefault = DateTimeZoneProviders.Tzdb.GetSystemDefault();
			return new ZonedClock(clock, systemDefault, CalendarSystem.Iso);
		}
	}
	public static class DateTimeExtensions
	{
		public static LocalDateTime ToLocalDateTime(this DateTime dateTime)
		{
			return LocalDateTime.FromDateTime(dateTime);
		}

		public static Instant ToInstant(this DateTime dateTime)
		{
			return Instant.FromDateTimeUtc(dateTime);
		}
	}
	public static class DateTimeOffsetExtensions
	{
		public static OffsetDateTime ToOffsetDateTime(this DateTimeOffset dateTimeOffset)
		{
			return OffsetDateTime.FromDateTimeOffset(dateTimeOffset);
		}

		public static ZonedDateTime ToZonedDateTime(this DateTimeOffset dateTimeOffset)
		{
			return ZonedDateTime.FromDateTimeOffset(dateTimeOffset);
		}

		public static Instant ToInstant(this DateTimeOffset dateTimeOffset)
		{
			return Instant.FromDateTimeOffset(dateTimeOffset);
		}
	}
	public static class DateTimeZoneProviderExtensions
	{
		[NotNull]
		public static IEnumerable<DateTimeZone> GetAllZones([NotNull] this IDateTimeZoneProvider provider)
		{
			Preconditions.CheckNotNull(provider, "provider");
			return provider.Ids.Select((string id) => provider[id]);
		}
	}
	public static class DayOfWeekExtensions
	{
		public static IsoDayOfWeek ToIsoDayOfWeek(this DayOfWeek dayOfWeek)
		{
			return BclConversions.ToIsoDayOfWeek(dayOfWeek);
		}
	}
	public static class IsoDayOfWeekExtensions
	{
		[Obsolete("This method was incorrectly named. Use ToDayOfWeek instead")]
		[TestExemption(TestExemptionCategory.ConversionName, "Released in 2.0 :(")]
		public static DayOfWeek ToIsoDayOfWeek(this IsoDayOfWeek isoDayOfWeek)
		{
			return isoDayOfWeek.ToDayOfWeek();
		}

		public static DayOfWeek ToDayOfWeek(this IsoDayOfWeek isoDayOfWeek)
		{
			return BclConversions.ToDayOfWeek(isoDayOfWeek);
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	public static class StopwatchExtensions
	{
		public static Duration ElapsedDuration([NotNull] this Stopwatch stopwatch)
		{
			Preconditions.CheckNotNull(stopwatch, "stopwatch");
			return stopwatch.Elapsed.ToDuration();
		}
	}
	public static class TimeSpanExtensions
	{
		public static Duration ToDuration(this TimeSpan timeSpan)
		{
			return Duration.FromTimeSpan(timeSpan);
		}

		public static Offset ToOffset(this TimeSpan timeSpan)
		{
			return Offset.FromTimeSpan(timeSpan);
		}
	}
}
namespace NodaTime.Calendars
{
	internal sealed class BadiYearMonthDayCalculator : YearMonthDayCalculator
	{
		private const int AverageDaysPer10Years = 3652;

		private const int DaysInAyyamiHaInLeapYear = 5;

		private const int DaysInAyyamiHaInNormalYear = 4;

		internal const int DaysInMonth = 19;

		private const int FirstYearOfStandardizedCalendar = 172;

		private const int GregorianYearOfFirstBadiYear = 1844;

		internal const int Month18 = 18;

		private const int Month19 = 19;

		private const int MonthsInYear = 19;

		private const int UnixEpochDayAtStartOfYear1 = -45941;

		private const int BadiMaxYear = 1000;

		private const int BadiMinYear = 1;

		private static byte[] YearInfoRaw;

		static BadiYearMonthDayCalculator()
		{
			YearInfoRaw = Convert.FromBase64String("AgELAgIBCwICAQsCAgEBCwIBAQsCAQELAgEBCwIBAQsCAQELAgEBCwIBAQELAQEBCwEBAQsBAQELAQEBCwEBAQsBAQELAQEBCwEBAQEKAQEBCgEBAQsCAgILAgICCwICAgsCAgILAgICCwICAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQELAgEBCwIBAQsCAQELAgEBCwIBAQsCAQELAgEBCwIBAQELAQEBCwEBAQsCAgIMAgICDAICAgwCAgIMAgICDAICAgILAgICCwICAgsCAgILAgICCwICAgsCAgILAgICCwICAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQELAgEBCwIBAQsCAgIMAwICDAMCAgwDAgIMAwICDAMCAgIMAgICDAICAgwCAgIMAgICDAICAgwCAgIMAgICDAICAgILAgICCwICAgsCAgILAgICCwICAgsCAgILAgICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQELAgEBCwIBAQsCAQELAgEBCwIBAQsCAQELAgEBCwIBAQELAQEBCwEBAQsBAQELAQEBCwEBAQsBAQELAQEBCwEBAQEKAQEBCgEBAQoBAQELAgICCwICAgsCAgILAgICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBAQsCAQELAgEBCwIBAQsCAQELAgEBCwIBAQsCAQELAgEBAQsBAQELAQEBCwEBAQsBAQELAgICDAICAgwCAgIMAgICAgsCAgILAgICCwICAgsCAgILAgICCwICAgsCAgILAgICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBAQsCAQELAgEBCwIBAQsCAQELAgICDAMCAgwDAgIMAwICAgwCAgIMAgICDAICAgwCAgIMAgICDAICAgwCAgIMAgICAgsCAgILAgICCwICAgsCAgILAgICCwICAgsCAgILAgICAQsCAgELAgIBCwICAQsCAgELAgIBCwICAQsCAgELAgIBAQsCAQELAgEBCwIBAQsCAQELAgEBCwIBAQsCAQELAg==");
		}

		internal BadiYearMonthDayCalculator()
			: base(1, 999, 3652, -45941)
		{
		}

		internal static int GetDaysInAyyamiHa(int year)
		{
			Preconditions.CheckArgumentRange("year", year, 1, 1000);
			checked
			{
				if (year < 172)
				{
					if (!CalendarSystem.Iso.YearMonthDayCalculator.IsLeapYear(year + 1844))
					{
						return 4;
					}
					return 5;
				}
				if (YearInfoRaw[year - 172] <= 10)
				{
					return 4;
				}
				return 5;
			}
		}

		private static int GetNawRuzDayInMarch(int year)
		{
			Preconditions.CheckArgumentRange("year", year, 1, 1000);
			if (year < 172)
			{
				return 21;
			}
			checked
			{
				int num = YearInfoRaw[year - 172];
				return 19 + unchecked(num % 10);
			}
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			Preconditions.CheckArgumentRange("year", year, 1, 1000);
			int year2 = checked(year + 1844 - 1);
			return new LocalDate(year2, 3, GetNawRuzDayInMarch(year)).DaysSinceEpoch;
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			checked
			{
				int num = 19 * (month - 1);
				if (month == 19)
				{
					num += GetDaysInAyyamiHa(year);
				}
				return num;
			}
		}

		internal override YearMonthDay AddMonths(YearMonthDay start, int months)
		{
			if (months == 0)
			{
				return start;
			}
			bool flag = months < 0;
			int num = start.Month;
			int year = start.Year;
			int day = start.Day;
			int day2 = day;
			checked
			{
				if (IsInAyyamiHa(start))
				{
					day2 = day - 19;
					if (flag)
					{
						num++;
					}
				}
				int num2 = year;
				int num3 = num + months;
				if (num3 > 19)
				{
					num2 = year + unchecked(num3 / 19);
					num3 = unchecked(num3 % 19);
				}
				else if (num3 < 1)
				{
					num3 = 19 - num3;
					num2 = year - unchecked(num3 / 19);
					num3 = 19 - unchecked(num3 % 19);
				}
				if (num2 < base.MinYear || num2 > base.MaxYear)
				{
					throw new OverflowException("Date computation would overflow calendar bounds.");
				}
				return new YearMonthDay(num2, num3, day2);
			}
		}

		internal override int GetDaysInMonth(int year, int month)
		{
			Preconditions.CheckArgumentRange("year", year, 1, 1000);
			if (month != 18)
			{
				return 19;
			}
			return checked(19 + GetDaysInAyyamiHa(year));
		}

		internal override int GetDaysInYear(int year)
		{
			return checked(361 + GetDaysInAyyamiHa(year));
		}

		internal override int GetDaysSinceEpoch(YearMonthDay target)
		{
			int month = target.Month;
			int year = target.Year;
			checked
			{
				int num = CalculateStartOfYearDays(year) - 1 + (month - 1) * 19 + target.Day;
				if (month == 19)
				{
					num += GetDaysInAyyamiHa(year);
				}
				return num;
			}
		}

		internal override int GetMonthsInYear(int year)
		{
			return 19;
		}

		internal override YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			Preconditions.CheckArgumentRange("dayOfYear", dayOfYear, 1, GetDaysInYear(year));
			checked
			{
				int num = 343 + GetDaysInAyyamiHa(year);
				if (dayOfYear >= num)
				{
					return new YearMonthDay(year, 19, dayOfYear - num + 1);
				}
				int num2 = Math.Min(1 + unchecked(checked(dayOfYear - 1) / 19), 18);
				int day = dayOfYear - (num2 - 1) * 19;
				return new YearMonthDay(year, num2, day);
			}
		}

		internal bool IsInAyyamiHa(YearMonthDay ymd)
		{
			if (ymd.Month == 18)
			{
				return ymd.Day > 19;
			}
			return false;
		}

		internal override bool IsLeapYear(int year)
		{
			return GetDaysInAyyamiHa(year) != 4;
		}

		internal override int MonthsBetween(YearMonthDay start, YearMonthDay end)
		{
			int month = start.Month;
			int year = start.Year;
			int month2 = end.Month;
			checked
			{
				int num = (end.Year - year) * 19 + month2 - month;
				YearMonthDay yearMonthDay = AddMonths(start, num);
				if (start <= end)
				{
					if (!(yearMonthDay <= end))
					{
						return num - 1;
					}
					return num;
				}
				if (!(yearMonthDay >= end))
				{
					return num + 1;
				}
				return num;
			}
		}

		internal override YearMonthDay SetYear(YearMonthDay start, int newYear)
		{
			Preconditions.CheckArgumentRange("newYear", newYear, 1, 1000);
			int month = start.Month;
			int day = start.Day;
			if (IsInAyyamiHa(start))
			{
				int daysInAyyamiHa = GetDaysInAyyamiHa(newYear);
				return new YearMonthDay(newYear, month, Math.Min(day, checked(19 + daysInAyyamiHa)));
			}
			return new YearMonthDay(newYear, month, day);
		}

		internal override void ValidateYearMonthDay(int year, int month, int day)
		{
			Preconditions.CheckArgumentRange("year", year, 1, 1000);
			Preconditions.CheckArgumentRange("month", month, 1, 19);
			int maxInclusive = ((month == 18) ? checked(19 + GetDaysInAyyamiHa(year)) : 19);
			Preconditions.CheckArgumentRange("day", day, 1, maxInclusive);
		}
	}
	internal sealed class CopticYearMonthDayCalculator : FixedMonthYearMonthDayCalculator
	{
		internal CopticYearMonthDayCalculator()
			: base(1, 9715, -615558)
		{
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			checked
			{
				int num = year - 1687;
				int num2;
				if (num <= 0)
				{
					num2 = num + 3 >> 2;
				}
				else
				{
					num2 = num >> 2;
					if (!IsLeapYear(year))
					{
						num2++;
					}
				}
				return num * 365 + num2 + 253;
			}
		}
	}
	[Immutable]
	public sealed class Era
	{
		[NotNull]
		public static Era Common { get; } = new Era("CE", "Eras_Common");

		[NotNull]
		public static Era BeforeCommon { get; } = new Era("BCE", "Eras_BeforeCommon");

		[NotNull]
		public static Era AnnoMartyrum { get; } = new Era("AM", "Eras_AnnoMartyrum");

		[NotNull]
		public static Era AnnoHegirae { get; } = new Era("EH", "Eras_AnnoHegirae");

		[NotNull]
		public static Era AnnoMundi { get; } = new Era("AM", "Eras_AnnoMundi");

		[NotNull]
		public static Era AnnoPersico { get; } = new Era("AP", "Eras_AnnoPersico");

		[NotNull]
		public static Era Bahai { get; } = new Era("BE", "Eras_Bahai");

		internal string ResourceIdentifier { get; }

		[NotNull]
		public string Name { get; }

		internal Era(string name, string resourceIdentifier)
		{
			Name = name;
			ResourceIdentifier = resourceIdentifier;
		}

		public override string ToString()
		{
			return Name;
		}
	}
	internal abstract class EraCalculator
	{
		internal IList<Era> Eras { get; }

		protected EraCalculator(params Era[] eras)
		{
			Eras = new ReadOnlyCollection<Era>(eras);
		}

		internal abstract int GetMinYearOfEra([NotNull] Era era);

		internal abstract int GetMaxYearOfEra([NotNull] Era era);

		internal abstract Era GetEra(int absoluteYear);

		internal abstract int GetYearOfEra(int absoluteYear);

		internal abstract int GetAbsoluteYear(int yearOfEra, [NotNull] Era era);
	}
	internal abstract class FixedMonthYearMonthDayCalculator : RegularYearMonthDayCalculator
	{
		private const int DaysInMonth = 30;

		private const int AverageDaysPer10Years = 3653;

		protected FixedMonthYearMonthDayCalculator(int minYear, int maxYear, int daysAtStartOfYear1)
			: base(minYear, maxYear, 13, 3653, daysAtStartOfYear1)
		{
		}

		internal override int GetDaysSinceEpoch(YearMonthDay yearMonthDay)
		{
			return checked(GetStartOfYearInDays(yearMonthDay.Year) + (yearMonthDay.Month - 1) * 30 + (yearMonthDay.Day - 1));
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			return checked((month - 1) * 30);
		}

		internal override bool IsLeapYear(int year)
		{
			return (year & 3) == 3;
		}

		internal override int GetDaysInYear(int year)
		{
			if (!IsLeapYear(year))
			{
				return 365;
			}
			return 366;
		}

		internal override int GetDaysInMonth(int year, int month)
		{
			if (month == 13)
			{
				if (!IsLeapYear(year))
				{
					return 5;
				}
				return 6;
			}
			return 30;
		}

		internal override YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			checked
			{
				int num = dayOfYear - 1;
				int month = unchecked(num / 30) + 1;
				int day = unchecked(num % 30) + 1;
				return new YearMonthDay(year, month, day);
			}
		}
	}
	internal sealed class GJEraCalculator : EraCalculator
	{
		private readonly int maxYearOfBc;

		private readonly int maxYearOfAd;

		internal GJEraCalculator(YearMonthDayCalculator ymdCalculator)
			: base(Era.BeforeCommon, Era.Common)
		{
			maxYearOfBc = checked(1 - ymdCalculator.MinYear);
			maxYearOfAd = ymdCalculator.MaxYear;
		}

		private void ValidateEra([NotNull] Era era)
		{
			if (era != Era.Common && era != Era.BeforeCommon)
			{
				Preconditions.CheckNotNull(era, "era");
				Preconditions.CheckArgument(expression: false, "era", "Era {0} is not supported by this calendar; only BC and AD are supported", era.Name);
			}
		}

		internal override int GetAbsoluteYear(int yearOfEra, [NotNull] Era era)
		{
			ValidateEra(era);
			if (era == Era.Common)
			{
				Preconditions.CheckArgumentRange("yearOfEra", yearOfEra, 1, maxYearOfAd);
				return yearOfEra;
			}
			Preconditions.CheckArgumentRange("yearOfEra", yearOfEra, 1, maxYearOfBc);
			return checked(1 - yearOfEra);
		}

		internal override int GetYearOfEra(int absoluteYear)
		{
			if (absoluteYear <= 0)
			{
				return checked(1 - absoluteYear);
			}
			return absoluteYear;
		}

		internal override Era GetEra(int absoluteYear)
		{
			if (absoluteYear <= 0)
			{
				return Era.BeforeCommon;
			}
			return Era.Common;
		}

		internal override int GetMinYearOfEra([NotNull] Era era)
		{
			ValidateEra(era);
			return 1;
		}

		internal override int GetMaxYearOfEra([NotNull] Era era)
		{
			ValidateEra(era);
			if (era != Era.Common)
			{
				return maxYearOfBc;
			}
			return maxYearOfAd;
		}
	}
	internal abstract class GJYearMonthDayCalculator : RegularYearMonthDayCalculator
	{
		protected static readonly int[] MinDaysPerMonth;

		protected static readonly int[] MaxDaysPerMonth;

		private static readonly int[] MinTotalDaysByMonth;

		private static readonly int[] MaxTotalDaysByMonth;

		static GJYearMonthDayCalculator()
		{
			MinDaysPerMonth = new int[12]
			{
				31, 28, 31, 30, 31, 30, 31, 31, 30, 31,
				30, 31
			};
			MaxDaysPerMonth = new int[12]
			{
				31, 29, 31, 30, 31, 30, 31, 31, 30, 31,
				30, 31
			};
			MinTotalDaysByMonth = new int[12];
			MaxTotalDaysByMonth = new int[12];
			int num = 0;
			int num2 = 0;
			checked
			{
				for (int i = 0; i < 11; i++)
				{
					num += MinDaysPerMonth[i];
					num2 += MaxDaysPerMonth[i];
					MinTotalDaysByMonth[i + 1] = num;
					MaxTotalDaysByMonth[i + 1] = num2;
				}
			}
		}

		protected GJYearMonthDayCalculator(int minYear, int maxYear, int averageDaysPer10Years, int daysAtStartOfYear1)
			: base(minYear, maxYear, 12, averageDaysPer10Years, daysAtStartOfYear1)
		{
		}

		internal override YearMonthDay GetYearMonthDay([Trusted] int year, int d)
		{
			int num = ((!IsLeapYear(year)) ? ((d >= 182) ? ((d >= 274) ? ((d < 305) ? 273 : ((d < 335) ? 304 : 334)) : ((d < 213) ? 181 : ((d < 244) ? 212 : 243))) : ((d >= 91) ? ((d < 121) ? 90 : ((d < 152) ? 120 : 151)) : ((d >= 32) ? ((d < 60) ? 31 : 59) : 0))) : ((d >= 183) ? ((d >= 275) ? ((d < 306) ? 274 : ((d < 336) ? 305 : 335)) : ((d < 214) ? 182 : ((d < 245) ? 213 : 244))) : ((d >= 92) ? ((d < 122) ? 91 : ((d < 153) ? 121 : 152)) : ((d >= 32) ? ((d < 61) ? 31 : 60) : 0))));
			checked
			{
				int day = d - num;
				return new YearMonthDay(year, unchecked(num / 29) + 1, day);
			}
		}

		internal override int GetDaysInYear([Trusted] int year)
		{
			if (!IsLeapYear(year))
			{
				return 365;
			}
			return 366;
		}

		internal sealed override int GetDaysInMonth([Trusted] int year, [Trusted] int month)
		{
			checked
			{
				if (month != 2 || !IsLeapYear(year))
				{
					return MinDaysPerMonth[month - 1];
				}
				return MaxDaysPerMonth[month - 1];
			}
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth([Trusted] int year, [Trusted] int month)
		{
			checked
			{
				if (!IsLeapYear(year))
				{
					return MinTotalDaysByMonth[month - 1];
				}
				return MaxTotalDaysByMonth[month - 1];
			}
		}
	}
	internal sealed class GregorianYearMonthDayCalculator : GJYearMonthDayCalculator
	{
		internal const int MinGregorianYear = -9998;

		internal const int MaxGregorianYear = 9999;

		private const int FirstOptimizedYear = 1900;

		private const int LastOptimizedYear = 2100;

		private const int FirstOptimizedDay = -25567;

		private const int LastOptimizedDay = 47846;

		private static readonly int[] MonthStartDays;

		private static readonly int[] YearStartDays;

		private const int DaysFrom0000To1970 = 719527;

		private const int AverageDaysPer10Years = 3652;

		static GregorianYearMonthDayCalculator()
		{
			MonthStartDays = new int[2413];
			YearStartDays = new int[201];
			GregorianYearMonthDayCalculator gregorianYearMonthDayCalculator = new GregorianYearMonthDayCalculator();
			checked
			{
				for (int i = 1900; i <= 2100; i++)
				{
					int num = gregorianYearMonthDayCalculator.CalculateStartOfYearDays(i);
					YearStartDays[i - 1900] = num;
					int num2 = num - 1;
					int num3 = (i - 1900) * 12;
					for (int j = 1; j <= 12; j++)
					{
						num3++;
						int daysInMonth = gregorianYearMonthDayCalculator.GetDaysInMonth(i, j);
						MonthStartDays[num3] = num2;
						num2 += daysInMonth;
					}
				}
			}
		}

		internal static YearMonthDayCalendar GetGregorianYearMonthDayCalendarFromDaysSinceEpoch(int daysSinceEpoch)
		{
			if (daysSinceEpoch < -25567 || daysSinceEpoch > 47846)
			{
				return CalendarSystem.Iso.GetYearMonthDayCalendarFromDaysSinceEpoch(daysSinceEpoch);
			}
			int num = (daysSinceEpoch - -25567) / 366;
			int num2 = YearStartDays[num];
			int num3 = daysSinceEpoch - num2;
			int num4 = num + 1900;
			bool flag = IsGregorianLeapYear(num4);
			int num5 = (flag ? 366 : 365);
			if (num3 >= num5)
			{
				num4++;
				num3 -= num5;
				flag = IsGregorianLeapYear(num4);
			}
			int num6 = ((!flag) ? ((num3 >= 181) ? ((num3 >= 273) ? ((num3 < 304) ? 272 : ((num3 < 334) ? 303 : 333)) : ((num3 < 212) ? 180 : ((num3 < 243) ? 211 : 242))) : ((num3 >= 90) ? ((num3 < 120) ? 89 : ((num3 < 151) ? 119 : 150)) : ((num3 < 31) ? (-1) : ((num3 < 59) ? 30 : 58)))) : ((num3 >= 182) ? ((num3 >= 274) ? ((num3 < 305) ? 273 : ((num3 < 335) ? 304 : 334)) : ((num3 < 213) ? 181 : ((num3 < 244) ? 212 : 243))) : ((num3 >= 91) ? ((num3 < 121) ? 90 : ((num3 < 152) ? 120 : 151)) : ((num3 < 31) ? (-1) : ((num3 < 60) ? 30 : 59)))));
			int month = num6 / 29 + 1;
			int day = num3 - num6;
			return new YearMonthDayCalendar(num4, month, day, CalendarOrdinal.Iso);
		}

		internal GregorianYearMonthDayCalculator()
			: base(-9998, 9999, 3652, -719162)
		{
		}

		internal override int GetStartOfYearInDays(int year)
		{
			if (year < 1900 || year > 2100)
			{
				return base.GetStartOfYearInDays(year);
			}
			return YearStartDays[checked(year - 1900)];
		}

		internal override int GetDaysSinceEpoch([Trusted] YearMonthDay yearMonthDay)
		{
			int year = yearMonthDay.Year;
			int month = yearMonthDay.Month;
			int day = yearMonthDay.Day;
			int num = (year - 1900) * 12 + month;
			if (year < 1900 || year > 2099)
			{
				return base.GetDaysSinceEpoch(yearMonthDay);
			}
			return MonthStartDays[num] + day;
		}

		internal override void ValidateYearMonthDay(int year, int month, int day)
		{
			ValidateGregorianYearMonthDay(year, month, day);
		}

		internal static void ValidateGregorianYearMonthDay(int year, int month, int day)
		{
			if (year < -9998 || year > 9999 || month < 1 || month > 12)
			{
				Preconditions.CheckArgumentRange("year", year, -9998, 9999);
				Preconditions.CheckArgumentRange("month", month, 1, 12);
			}
			if (day < 1 || day > 28)
			{
				int num = checked((month == 2 && IsGregorianLeapYear(year)) ? GJYearMonthDayCalculator.MaxDaysPerMonth[month - 1] : GJYearMonthDayCalculator.MinDaysPerMonth[month - 1]);
				if (day < 1 || day > num)
				{
					Preconditions.CheckArgumentRange("day", day, 1, num);
				}
			}
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			int num = year / 100;
			checked
			{
				if (year < 0)
				{
					num = (year + 3 >> 2) - num + (num + 3 >> 2) - 1;
				}
				else
				{
					num = (year >> 2) - num + (num >> 2);
					if (IsLeapYear(year))
					{
						num--;
					}
				}
				return year * 365 + (num - 719527);
			}
		}

		internal override int GetDaysInYear(int year)
		{
			if (!IsGregorianLeapYear(year))
			{
				return 365;
			}
			return 366;
		}

		internal override bool IsLeapYear(int year)
		{
			return IsGregorianLeapYear(year);
		}

		private static bool IsGregorianLeapYear(int year)
		{
			if ((year & 3) == 0)
			{
				if (year % 100 == 0)
				{
					return year % 400 == 0;
				}
				return true;
			}
			return false;
		}
	}
	internal static class HebrewMonthConverter
	{
		internal static int CivilToScriptural(int year, int month)
		{
			checked
			{
				if (month < 7)
				{
					return month + 6;
				}
				bool flag = HebrewScripturalCalculator.IsLeapYear(year);
				if (month == 7)
				{
					if (!flag)
					{
						return 1;
					}
					return 13;
				}
				if (!flag)
				{
					return month - 6;
				}
				return month - 7;
			}
		}

		internal static int ScripturalToCivil(int year, int month)
		{
			checked
			{
				if (month >= 7)
				{
					return month - 6;
				}
				if (!HebrewScripturalCalculator.IsLeapYear(year))
				{
					return month + 6;
				}
				return month + 7;
			}
		}
	}
	public enum HebrewMonthNumbering
	{
		Civil = 1,
		Scriptural
	}
	internal static class HebrewScripturalCalculator
	{
		internal const int MaxYear = 9999;

		internal const int MinYear = 1;

		private const int IsHeshvanLongCacheBit = 1;

		private const int IsKislevShortCacheBit = 2;

		private const int ElapsedDaysCacheShift = 2;

		private static readonly YearStartCacheEntry[] YearCache = YearStartCacheEntry.CreateCache();

		internal static bool IsLeapYear(int year)
		{
			return checked(year * 7 + 1) % 19 < 7;
		}

		internal static YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			int orPopulateCache = GetOrPopulateCache(year);
			int num = (((orPopulateCache & 1) != 0) ? 30 : 29);
			int num2 = (((orPopulateCache & 2) != 0) ? 29 : 30);
			bool flag = IsLeapYear(year);
			int num3 = (flag ? 30 : 29);
			if (dayOfYear < 31)
			{
				return new YearMonthDay(year, 7, dayOfYear);
			}
			if (dayOfYear < 31 + num)
			{
				return new YearMonthDay(year, 8, dayOfYear - 30);
			}
			dayOfYear -= num;
			if (dayOfYear < 31 + num2)
			{
				return new YearMonthDay(year, 9, dayOfYear - 30);
			}
			dayOfYear -= num2;
			if (dayOfYear < 60)
			{
				return new YearMonthDay(year, 10, dayOfYear - 30);
			}
			if (dayOfYear < 90)
			{
				return new YearMonthDay(year, 11, dayOfYear - 59);
			}
			if (dayOfYear < 90 + num3)
			{
				return new YearMonthDay(year, 12, dayOfYear - 89);
			}
			dayOfYear -= num3;
			if (flag)
			{
				if (dayOfYear < 119)
				{
					return new YearMonthDay(year, 13, dayOfYear - 89);
				}
				dayOfYear -= 29;
			}
			if (dayOfYear < 120)
			{
				return new YearMonthDay(year, 1, dayOfYear - 89);
			}
			if (dayOfYear < 149)
			{
				return new YearMonthDay(year, 2, dayOfYear - 119);
			}
			if (dayOfYear < 179)
			{
				return new YearMonthDay(year, 3, dayOfYear - 148);
			}
			if (dayOfYear < 208)
			{
				return new YearMonthDay(year, 4, dayOfYear - 178);
			}
			if (dayOfYear < 238)
			{
				return new YearMonthDay(year, 5, dayOfYear - 207);
			}
			return new YearMonthDay(year, 6, dayOfYear - 237);
		}

		internal static int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			int orPopulateCache = GetOrPopulateCache(year);
			int num = (((orPopulateCache & 1) != 0) ? 30 : 29);
			int num2 = (((orPopulateCache & 2) != 0) ? 29 : 30);
			bool num3 = IsLeapYear(year);
			int num4 = (num3 ? 30 : 29);
			int num5 = (num3 ? 29 : 0);
			switch (month)
			{
			case 1:
				return 30 + num + num2 + 59 + num4 + num5;
			case 2:
				return 30 + num + num2 + 59 + num4 + num5 + 30;
			case 3:
				return 30 + num + num2 + 59 + num4 + num5 + 59;
			case 4:
				return 30 + num + num2 + 59 + num4 + num5 + 89;
			case 5:
				return 30 + num + num2 + 59 + num4 + num5 + 118;
			case 6:
				return 30 + num + num2 + 59 + num4 + num5 + 148;
			case 7:
				return 0;
			case 8:
				return 30;
			case 9:
				return 30 + num;
			case 10:
				return 30 + num + num2;
			case 11:
				return 30 + num + num2 + 29;
			case 12:
				return 30 + num + num2 + 29 + 30;
			case 13:
				return 30 + num + num2 + 29 + 30 + num4;
			default:
				Preconditions.CheckArgumentRange("month", month, 1, 13);
				throw new InvalidOperationException("CheckArgumentRange should have thrown...");
			}
		}

		internal static int DaysInMonth(int year, int month)
		{
			switch (month)
			{
			case 2:
			case 4:
			case 6:
			case 10:
			case 13:
				return 29;
			case 8:
				if (!IsHeshvanLong(year))
				{
					return 29;
				}
				return 30;
			case 9:
				if (!IsKislevShort(year))
				{
					return 30;
				}
				return 29;
			case 12:
				if (!IsLeapYear(year))
				{
					return 29;
				}
				return 30;
			default:
				return 30;
			}
		}

		private static bool IsHeshvanLong(int year)
		{
			return (GetOrPopulateCache(year) & 1) != 0;
		}

		private static bool IsKislevShort(int year)
		{
			return (GetOrPopulateCache(year) & 2) != 0;
		}

		internal static int ElapsedDays(int year)
		{
			return GetOrPopulateCache(year) >> 2;
		}

		private static int ElapsedDaysNoCache(int year)
		{
			checked
			{
				int num = 235 * unchecked(checked(year - 1) / 19) + 12 * unchecked(checked(year - 1) % 19) + unchecked(checked(unchecked(checked(year - 1) % 19) * 7 + 1) / 19);
				int num2 = 204 + 793 * unchecked(num % 1080);
				int num3 = 5 + 12 * num + 793 * unchecked(num / 1080) + unchecked(num2 / 1080);
				int num4 = 1 + 29 * num + unchecked(num3 / 24);
				int num5 = unchecked(num3 % 24) * 1080 + unchecked(num2 % 1080);
				int num6 = ((num5 >= 19440 || (unchecked(num4 % 7) == 2 && num5 >= 9924 && !IsLeapYear(year)) || (unchecked(num4 % 7) == 1 && num5 >= 16789 && IsLeapYear(year - 1))) ? (1 + num4) : num4);
				int num7 = unchecked(num6 % 7);
				if (num7 != 0 && num7 != 3 && num7 != 5)
				{
					return num6;
				}
				return num6 + 1;
			}
		}

		private static int GetOrPopulateCache(int year)
		{
			if (year < 1 || year > 9999)
			{
				return ComputeCacheEntry(year);
			}
			int cacheIndex = YearStartCacheEntry.GetCacheIndex(year);
			YearStartCacheEntry yearStartCacheEntry = YearCache[cacheIndex];
			if (!yearStartCacheEntry.IsValidForYear(year))
			{
				int days = ComputeCacheEntry(year);
				yearStartCacheEntry = new YearStartCacheEntry(year, days);
				YearCache[cacheIndex] = yearStartCacheEntry;
			}
			return yearStartCacheEntry.StartOfYearDays;
		}

		private static int ComputeCacheEntry(int year)
		{
			int num = ElapsedDaysNoCache(year);
			int num4;
			checked
			{
				int num2 = year + 1;
				int num3;
				if (num2 <= 9999)
				{
					int cacheIndex = YearStartCacheEntry.GetCacheIndex(num2);
					YearStartCacheEntry yearStartCacheEntry = YearCache[cacheIndex];
					num3 = (yearStartCacheEntry.IsValidForYear(num2) ? (yearStartCacheEntry.StartOfYearDays >> 2) : ElapsedDaysNoCache(num2));
				}
				else
				{
					num3 = ElapsedDaysNoCache(year + 1);
				}
				num4 = num3 - num;
			}
			bool flag = num4 % 10 == 5;
			bool flag2 = num4 % 10 == 3;
			return (num << 2) | (flag ? 1 : 0) | (flag2 ? 2 : 0);
		}

		internal static int DaysInYear(int year)
		{
			return checked(ElapsedDays(year + 1) - ElapsedDays(year));
		}
	}
	internal sealed class HebrewYearMonthDayCalculator : YearMonthDayCalculator
	{
		private const int UnixEpochDayAtStartOfYear1 = -2092590;

		private const int MonthsPerLeapCycle = 235;

		private const int YearsPerLeapCycle = 19;

		private readonly HebrewMonthNumbering monthNumbering;

		internal HebrewYearMonthDayCalculator(HebrewMonthNumbering monthNumbering)
			: base(1, 9999, 3654, -2092590)
		{
			this.monthNumbering = monthNumbering;
		}

		private int CalendarToCivilMonth(int year, int month)
		{
			if (monthNumbering != HebrewMonthNumbering.Civil)
			{
				return HebrewMonthConverter.ScripturalToCivil(year, month);
			}
			return month;
		}

		private int CalendarToScripturalMonth(int year, int month)
		{
			if (monthNumbering != HebrewMonthNumbering.Scriptural)
			{
				return HebrewMonthConverter.CivilToScriptural(year, month);
			}
			return month;
		}

		private int CivilToCalendarMonth(int year, int month)
		{
			if (monthNumbering != HebrewMonthNumbering.Civil)
			{
				return HebrewMonthConverter.CivilToScriptural(year, month);
			}
			return month;
		}

		private int ScripturalToCalendarMonth(int year, int month)
		{
			if (monthNumbering != HebrewMonthNumbering.Scriptural)
			{
				return HebrewMonthConverter.ScripturalToCivil(year, month);
			}
			return month;
		}

		internal override bool IsLeapYear(int year)
		{
			return HebrewScripturalCalculator.IsLeapYear(year);
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			int month2 = CalendarToScripturalMonth(year, month);
			return HebrewScripturalCalculator.GetDaysFromStartOfYearToStartOfMonth(year, month2);
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			return checked(HebrewScripturalCalculator.ElapsedDays(year) - 1 + -2092590);
		}

		internal override YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			YearMonthDay yearMonthDay = HebrewScripturalCalculator.GetYearMonthDay(year, dayOfYear);
			if (monthNumbering != HebrewMonthNumbering.Scriptural)
			{
				return new YearMonthDay(year, HebrewMonthConverter.ScripturalToCivil(year, yearMonthDay.Month), yearMonthDay.Day);
			}
			return yearMonthDay;
		}

		internal override int GetDaysInYear(int year)
		{
			return HebrewScripturalCalculator.DaysInYear(year);
		}

		internal override int GetMonthsInYear(int year)
		{
			if (!IsLeapYear(year))
			{
				return 12;
			}
			return 13;
		}

		internal override YearMonthDay SetYear(YearMonthDay yearMonthDay, int year)
		{
			int year2 = yearMonthDay.Year;
			int month = yearMonthDay.Month;
			int num = yearMonthDay.Day;
			int num2 = CalendarToScripturalMonth(year2, month);
			if (num2 == 13 && !IsLeapYear(year))
			{
				num2 = 12;
			}
			else if (num2 == 12 && IsLeapYear(year) && !IsLeapYear(year2))
			{
				num2 = 13;
			}
			if (num == 30 && (num2 == 8 || num2 == 9 || num2 == 12) && HebrewScripturalCalculator.DaysInMonth(year, num2) != 30)
			{
				num = 1;
				num2 = checked(num2 + 1);
				if (num2 == 13)
				{
					num2 = 1;
				}
			}
			int month2 = ScripturalToCalendarMonth(year, num2);
			return new YearMonthDay(year, month2, num);
		}

		internal override int GetDaysInMonth(int year, int month)
		{
			return HebrewScripturalCalculator.DaysInMonth(year, CalendarToScripturalMonth(year, month));
		}

		internal override YearMonthDay AddMonths(YearMonthDay yearMonthDay, int months)
		{
			if (months == 0)
			{
				return yearMonthDay;
			}
			int year = yearMonthDay.Year;
			int num = CalendarToCivilMonth(year, yearMonthDay.Month);
			checked
			{
				year += unchecked(months / 235) * 19;
				months = unchecked(months % 235);
				if (months > 0)
				{
					for (months += num - 1; months >= GetMonthsInYear(year); year++)
					{
						months -= GetMonthsInYear(year);
					}
					num = months + 1;
				}
				else
				{
					months -= GetMonthsInYear(year) - num;
					while (months + GetMonthsInYear(year) <= 0)
					{
						months += GetMonthsInYear(year);
						year--;
					}
					num = GetMonthsInYear(year) + months;
				}
				num = CivilToCalendarMonth(year, num);
				int day = Math.Min(GetDaysInMonth(year, num), yearMonthDay.Day);
				if (year < base.MinYear || year > base.MaxYear)
				{
					throw new OverflowException("Date computation would overflow calendar bounds.");
				}
				return new YearMonthDay(year, num, day);
			}
		}

		internal override int MonthsBetween(YearMonthDay start, YearMonthDay end)
		{
			checked
			{
				double num = (double)CalendarToCivilMonth(start.Year, start.Month) + (double)(start.Year * 235) / 19.0;
				int i = (int)((double)CalendarToCivilMonth(end.Year, end.Month) + (double)(end.Year * 235) / 19.0 - num);
				if (Compare(start, end) <= 0)
				{
					while (Compare(AddMonths(start, i), end) > 0)
					{
						i--;
					}
					for (; Compare(AddMonths(start, i), end) <= 0; i++)
					{
					}
					return i - 1;
				}
				for (; Compare(AddMonths(start, i), end) < 0; i++)
				{
				}
				while (Compare(AddMonths(start, i), end) >= 0)
				{
					i--;
				}
				return i + 1;
			}
		}

		public override int Compare(YearMonthDay lhs, YearMonthDay rhs)
		{
			if (monthNumbering == HebrewMonthNumbering.Civil)
			{
				return lhs.CompareTo(rhs);
			}
			int num = lhs.Year.CompareTo(rhs.Year);
			if (num != 0)
			{
				return num;
			}
			int num2 = CalendarToCivilMonth(lhs.Year, lhs.Month);
			int value = CalendarToCivilMonth(rhs.Year, rhs.Month);
			int num3 = num2.CompareTo(value);
			if (num3 != 0)
			{
				return num3;
			}
			return lhs.Day.CompareTo(rhs.Day);
		}
	}
	public enum IslamicEpoch
	{
		Astronomical = 1,
		Civil
	}
	public enum IslamicLeapYearPattern
	{
		Base15 = 1,
		Base16,
		Indian,
		HabashAlHasib
	}
	internal sealed class IslamicYearMonthDayCalculator : RegularYearMonthDayCalculator
	{
		private const int MonthPairLength = 59;

		private const int LongMonthLength = 30;

		private const int ShortMonthLength = 29;

		private const int AverageDaysPer10Years = 3544;

		private const int DaysPerNonLeapYear = 354;

		private const int DaysPerLeapYear = 355;

		private const int DaysAtCivilEpoch = -492148;

		private const int DaysAtAstronomicalEpoch = -492149;

		private const int LeapYearCycleLength = 30;

		private const int DaysPerLeapCycle = 10631;

		private readonly int leapYearPatternBits;

		private static readonly int[] TotalDaysByMonth;

		static IslamicYearMonthDayCalculator()
		{
			int num = 0;
			TotalDaysByMonth = new int[12];
			checked
			{
				for (int i = 0; i < 12; i++)
				{
					TotalDaysByMonth[i] = num;
					int num2 = (((i & 1) == 0) ? 30 : 29);
					num += num2;
				}
			}
		}

		internal IslamicYearMonthDayCalculator(IslamicLeapYearPattern leapYearPattern, IslamicEpoch epoch)
			: base(1, 9665, 12, 3544, GetYear1Days(epoch))
		{
			leapYearPatternBits = GetLeapYearPatternBits(leapYearPattern);
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			return TotalDaysByMonth[checked(month - 1)];
		}

		internal override YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			checked
			{
				int month;
				int day;
				if (dayOfYear == 355)
				{
					month = 12;
					day = 30;
				}
				else
				{
					int num = dayOfYear - 1;
					month = unchecked(checked(num * 2) / 59) + 1;
					day = unchecked(num % 59 % 30) + 1;
				}
				return new YearMonthDay(year, month, day);
			}
		}

		internal override bool IsLeapYear(int year)
		{
			int num = ((year >= 0) ? (year % 30) : checked(unchecked(year % 30) + 30));
			int num2 = 1 << num;
			return (leapYearPatternBits & num2) > 0;
		}

		internal override int GetDaysInYear(int year)
		{
			if (!IsLeapYear(year))
			{
				return 354;
			}
			return 355;
		}

		internal override int GetDaysInMonth(int year, int month)
		{
			if (month == 12 && IsLeapYear(year))
			{
				return 30;
			}
			if ((month & 1) != 0)
			{
				return 30;
			}
			return 29;
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			int num = ((year > 0) ? (checked(year - 1) / 30) : (checked(year - 30) / 30));
			checked
			{
				int num2 = num * 30 + 1;
				int num3 = base.DaysAtStartOfYear1 + num * 10631;
				for (int i = num2; i < year; i++)
				{
					num3 += GetDaysInYear(i);
				}
				return num3;
			}
		}

		private static int GetLeapYearPatternBits(IslamicLeapYearPattern leapYearPattern)
		{
			return leapYearPattern switch
			{
				IslamicLeapYearPattern.Base15 => 623158436, 
				IslamicLeapYearPattern.Base16 => 623191204, 
				IslamicLeapYearPattern.Indian => 690562340, 
				IslamicLeapYearPattern.HabashAlHasib => 153692453, 
				_ => throw new ArgumentOutOfRangeException("leapYearPattern"), 
			};
		}

		private static int GetYear1Days(IslamicEpoch epoch)
		{
			return epoch switch
			{
				IslamicEpoch.Astronomical => -492149, 
				IslamicEpoch.Civil => -492148, 
				_ => throw new ArgumentOutOfRangeException("epoch"), 
			};
		}
	}
	public interface IWeekYearRule
	{
		LocalDate GetLocalDate(int weekYear, int weekOfWeekYear, IsoDayOfWeek dayOfWeek, [NotNull] CalendarSystem calendar);

		int GetWeekYear(LocalDate date);

		int GetWeekOfWeekYear(LocalDate date);

		int GetWeeksInWeekYear(int weekYear, [NotNull] CalendarSystem calendar);
	}
	public static class WeekYearRuleExtensions
	{
		public static LocalDate GetLocalDate([NotNull] this IWeekYearRule rule, int weekYear, int weekOfWeekYear, IsoDayOfWeek dayOfWeek)
		{
			return Preconditions.CheckNotNull(rule, "rule").GetLocalDate(weekYear, weekOfWeekYear, dayOfWeek, CalendarSystem.Iso);
		}

		public static int GetWeeksInWeekYear([NotNull] this IWeekYearRule rule, int weekYear)
		{
			return Preconditions.CheckNotNull(rule, "rule").GetWeeksInWeekYear(weekYear, CalendarSystem.Iso);
		}
	}
	internal sealed class JulianYearMonthDayCalculator : GJYearMonthDayCalculator
	{
		private const int AverageDaysPer10JulianYears = 3653;

		internal JulianYearMonthDayCalculator()
			: base(-9997, 9998, 3653, -719164)
		{
		}

		internal override bool IsLeapYear(int year)
		{
			return (year & 3) == 0;
		}

		protected override int CalculateStartOfYearDays(int year)
		{
			checked
			{
				int num = year - 1968;
				int num2;
				if (num <= 0)
				{
					num2 = num + 3 >> 2;
				}
				else
				{
					num2 = num >> 2;
					if (!IsLeapYear(year))
					{
						num2++;
					}
				}
				return num * 365 + num2 - 718;
			}
		}
	}
	[CompilerGenerated]
	internal static class NamespaceDoc
	{
	}
	internal abstract class PersianYearMonthDayCalculator : RegularYearMonthDayCalculator
	{
		internal class Simple : PersianYearMonthDayCalculator
		{
			private const long LeapYearPatternBits = 1145184802L;

			private const int LeapYearCycleLength = 33;

			private const int DaysPerLeapCycle = 12053;

			private const int DaysAtStartOfYear1Constant = -492268;

			internal Simple()
				: base(-492268)
			{
			}

			internal override bool IsLeapYear(int year)
			{
				int num = ((year >= 0) ? (year % 33) : checked(unchecked(year % 33) + 33));
				long num2 = 1L << num;
				return (0x44422222 & num2) > 0;
			}
		}

		internal class Arithmetic : PersianYearMonthDayCalculator
		{
			internal Arithmetic()
				: base(-492267)
			{
			}

			internal override bool IsLeapYear(int year)
			{
				return checked((unchecked(checked((year > 0) ? (year - 474) : (year - 473)) % 2820) + 474 + 38) * 31) % 128 < 31;
			}
		}

		internal class Astronomical : PersianYearMonthDayCalculator
		{
			private static readonly byte[] AstronomicalLeapYearBits = Convert.FromBase64String("ICIiIkJERESEiIiICBEREREiIiJCREREhIiIiAgRERERIiIiIkRERISIiIiIEBERESEiIiJEREREiIiIiBAREREhIiIiQkRERISIiIgIERERESIiIkJERESEiIiICBEREREiIiIiRERERIiIiIgQERERISIiIkJERESEiIiICBEREREiIiIiREREhIiIiAgRERERISIiIkRERESIiIiIEBERESEiIiJCREREhIiIiAgRERERIiIiIkRERISIiIgIERERESEiIiJEREREiIiIiBAREREhIiIiQkRERISIiIgIERERESIiIiJEREREiIiIiBAREREhIiIiQkRERIiIiIgQERERISIiIiJERESEiIiICBEREREiIiIiRERERIiIiIgQERERISIiIkJERESEiIiICBEREREiIiIiRERERIiIiAgRERERIiIiIkJERESEiIiIEBERESEiIiJCRERERIiIiAgRERERIiIiIkRERESIiIiIEBERESEiIiJCREREhIiIiAgREREhIiIiIkRERESIiIiIEBERESIiIiJEREREiIiIiBAREREhIiIiQkRERISIiIgIERERESIiIiJEREREiIiIiBAREREiIiIiRERERIiIiIgQERERISIiIkJERESEiIiICBERESEiIiJCREREhIiIiAgRERERIiIiIkRERESIiIiIEBERESIiIiJEREREiIiIiBAREREhIiIiQkRERISIiIgIERERISIiIkJERESEiIiICBEREREiIiIiRERERIiIiAgRERERIiIiIkRERESIiIgIERERESIiIiJEREREiIiIiBAREREhIiIiQkRERIiIiIgQERERISIiIkJERESIiIiIEBERESEiIiJCREREiIiIiBAREREhIiIiQkRERIiIiIgQERERISIiIkRERESIiIiIEBERESIiIiJEREREiIiIiBAREREiIiIiRERERIiIiAgRERERIiIiIkRERISIiIgIERERESIiIkJERESEiIiIEBERESEiIiJEREREiIiIiBAREREiIiIiRERERIiIiAgRERERIiIiIkRERISIiIgQERERISIiIkJERESIiIiIEBERESEiIiJERESEiIiICBERESEiIiJCREREhIiIiBAREREhIiIiREREhIiIiAgRERERIiIiQkRERIiIiIgQERERIiIiIkRERISIiIgQERERISIiIkRERESIiIgIERERISIiIkJERESIiIiIEBERESIiIkJERESIiIiIEBERESIiIiJERESEiIiIEBERESEiIiJERESEiIiICBERESEiIiJEREREiIiICBERESEiIiJERESEiIiICBERESEiIiJEREREiIiICBERESEiIiJERESEiIiICBERESEiIiJERESEiIiICBERESEiIiJERESEiIiIEBERESIiIiJERESEiIiIEBERESIiIkJERESIiIgIERERISIiIkRERESIiIgIERERISIiIkRERISIiIgQERERIiIiQkRERIiIiAgREREhIiIiREREhIiIiBAREREiIiJCREREiIiICBERESEC");

			internal Astronomical()
				: base(-492267)
			{
			}

			internal override bool IsLeapYear(int year)
			{
				return (AstronomicalLeapYearBits[year >> 3] & (1 << (year & 7))) != 0;
			}
		}

		private const int DaysPerNonLeapYear = 365;

		private const int DaysPerLeapYear = 366;

		private const int AverageDaysPer10Years = 3652;

		internal const int MaxPersianYear = 9377;

		private static readonly int[] TotalDaysByMonth;

		private readonly int[] startOfYearInDaysCache;

		static PersianYearMonthDayCalculator()
		{
			int num = 0;
			TotalDaysByMonth = new int[13];
			checked
			{
				for (int i = 1; i <= 12; i++)
				{
					TotalDaysByMonth[i] = num;
					int num2 = ((i <= 6) ? 31 : 30);
					num += num2;
				}
			}
		}

		private PersianYearMonthDayCalculator(int daysAtStartOfYear1)
			: base(1, 9377, 12, 3652, daysAtStartOfYear1)
		{
			checked
			{
				startOfYearInDaysCache = new int[base.MaxYear + 2];
				int num = base.DaysAtStartOfYear1 - GetDaysInYear(0);
				for (int i = 0; i <= base.MaxYear + 1; i++)
				{
					startOfYearInDaysCache[i] = num;
					num += GetDaysInYear(i);
				}
			}
		}

		protected sealed override int GetDaysFromStartOfYearToStartOfMonth(int year, int month)
		{
			return TotalDaysByMonth[month];
		}

		internal sealed override int GetStartOfYearInDays(int year)
		{
			return startOfYearInDaysCache[year];
		}

		protected sealed override int CalculateStartOfYearDays(int year)
		{
			throw new NotImplementedException();
		}

		internal sealed override YearMonthDay GetYearMonthDay(int year, int dayOfYear)
		{
			checked
			{
				int num = dayOfYear - 1;
				int month;
				int day;
				if (dayOfYear == 366)
				{
					month = 12;
					day = 30;
				}
				else if (num < 186)
				{
					month = unchecked(num / 31) + 1;
					day = unchecked(num % 31) + 1;
				}
				else
				{
					int num2 = num - 186;
					month = unchecked(num2 / 30) + 7;
					day = unchecked(num2 % 30) + 1;
				}
				return new YearMonthDay(year, month, day);
			}
		}

		internal sealed override int GetDaysInMonth(int year, int month)
		{
			if (month >= 7)
			{
				if (month >= 12)
				{
					if (!IsLeapYear(year))
					{
						return 29;
					}
					return 30;
				}
				return 30;
			}
			return 31;
		}

		internal sealed override int GetDaysInYear(int year)
		{
			if (!IsLeapYear(year))
			{
				return 365;
			}
			return 366;
		}
	}
	internal abstract class RegularYearMonthDayCalculator : YearMonthDayCalculator
	{
		private readonly int monthsInYear;

		protected RegularYearMonthDayCalculator(int minYear, int maxYear, int monthsInYear, int averageDaysPer10Years, int daysAtStartOfYear1)
			: base(minYear, maxYear, averageDaysPer10Years, daysAtStartOfYear1)
		{
			this.monthsInYear = monthsInYear;
		}

		internal override int GetMonthsInYear([Trusted] int year)
		{
			return monthsInYear;
		}

		internal override YearMonthDay SetYear(YearMonthDay yearMonthDay, [Trusted] int year)
		{
			int month = yearMonthDay.Month;
			int day = yearMonthDay.Day;
			int daysInMonth = GetDaysInMonth(year, month);
			return new YearMonthDay(year, month, Math.Min(day, daysInMonth));
		}

		internal override YearMonthDay AddMonths(YearMonthDay yearMonthDay, int months)
		{
			if (months == 0)
			{
				return yearMonthDay;
			}
			int year = yearMonthDay.Year;
			checked
			{
				int num = yearMonthDay.Month - 1 + months;
				int num2;
				if (num >= 0)
				{
					num2 = year + unchecked(num / monthsInYear);
					num = unchecked(num % monthsInYear) + 1;
				}
				else
				{
					num2 = year + unchecked(num / monthsInYear) - 1;
					num = Math.Abs(num);
					int num3 = unchecked(num % monthsInYear);
					if (num3 == 0)
					{
						num3 = monthsInYear;
					}
					num = monthsInYear - num3 + 1;
					if (num == 1)
					{
						num2++;
					}
				}
				int day = yearMonthDay.Day;
				int daysInMonth = GetDaysInMonth(num2, num);
				day = Math.Min(day, daysInMonth);
				if (num2 < base.MinYear || num2 > base.MaxYear)
				{
					throw new OverflowException("Date computation would overflow calendar bounds.");
				}
				return new YearMonthDay(num2, num, day);
			}
		}

		internal override int MonthsBetween(YearMonthDay start, YearMonthDay end)
		{
			int month = start.Month;
			int year = start.Year;
			int month2 = end.Month;
			checked
			{
				int num = (end.Year - year) * monthsInYear + month2 - month;
				YearMonthDay yearMonthDay = AddMonths(start, num);
				if (start <= end)
				{
					if (!(yearMonthDay <= end))
					{
						return num - 1;
					}
					return num;
				}
				if (!(yearMonthDay >= end))
				{
					return num + 1;
				}
				return num;
			}
		}
	}
	[Immutable]
	internal sealed class SimpleWeekYearRule : IWeekYearRule
	{
		private readonly int minDaysInFirstWeek;

		private readonly IsoDayOfWeek firstDayOfWeek;

		private readonly bool irregularWeeks;

		internal SimpleWeekYearRule(int minDaysInFirstWeek, IsoDayOfWeek firstDayOfWeek, bool irregularWeeks)
		{
			Preconditions.CheckArgumentRange("firstDayOfWeek", (int)firstDayOfWeek, 1, 7);
			this.minDaysInFirstWeek = minDaysInFirstWeek;
			this.firstDayOfWeek = firstDayOfWeek;
			this.irregularWeeks = irregularWeeks;
		}

		public LocalDate GetLocalDate(int weekYear, int weekOfWeekYear, IsoDayOfWeek dayOfWeek, [NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			ValidateWeekYear(weekYear, calendar);
			Preconditions.CheckArgumentRange("dayOfWeek", (int)dayOfWeek, 1, 7);
			YearMonthDayCalculator yearMonthDayCalculator = calendar.YearMonthDayCalculator;
			int weeksInWeekYear = GetWeeksInWeekYear(weekYear, calendar);
			if (weekOfWeekYear < 1 || weekOfWeekYear > weeksInWeekYear)
			{
				throw new ArgumentOutOfRangeException("weekOfWeekYear");
			}
			int weekYearDaysSinceEpoch = GetWeekYearDaysSinceEpoch(yearMonthDayCalculator, weekYear);
			int num = (dayOfWeek - firstDayOfWeek + 7) % 7;
			int num2 = weekYearDaysSinceEpoch + (weekOfWeekYear - 1) * 7 + num;
			if (num2 < calendar.MinDays || num2 > calendar.MaxDays)
			{
				throw new ArgumentOutOfRangeException("weekYear", string.Format("The combination of {0}, {1} and {2} is invalid", "weekYear", "weekOfWeekYear", "dayOfWeek"));
			}
			LocalDate localDate = new LocalDate(yearMonthDayCalculator.GetYearMonthDay(num2).WithCalendar(calendar));
			if (irregularWeeks && weekYear != localDate.Year && GetWeekYear(localDate) != weekYear)
			{
				throw new ArgumentOutOfRangeException("weekYear", string.Format("The combination of {0}, {1} and {2} is invalid", "weekYear", "weekOfWeekYear", "dayOfWeek"));
			}
			return localDate;
		}

		public int GetWeekOfWeekYear(LocalDate date)
		{
			YearMonthDay yearMonthDay = date.YearMonthDay;
			YearMonthDayCalculator yearMonthDayCalculator = date.Calendar.YearMonthDayCalculator;
			int weekYear = GetWeekYear(date);
			int weekYearDaysSinceEpoch = GetWeekYearDaysSinceEpoch(yearMonthDayCalculator, weekYear);
			checked
			{
				return unchecked(checked(yearMonthDayCalculator.GetDaysSinceEpoch(yearMonthDay) - weekYearDaysSinceEpoch) / 7) + 1;
			}
		}

		public int GetWeeksInWeekYear(int weekYear, [NotNull] CalendarSystem calendar)
		{
			Preconditions.CheckNotNull(calendar, "calendar");
			YearMonthDayCalculator yearMonthDayCalculator = calendar.YearMonthDayCalculator;
			ValidateWeekYear(weekYear, calendar);
			int weekYearDaysSinceEpoch = GetWeekYearDaysSinceEpoch(yearMonthDayCalculator, weekYear);
			int num = yearMonthDayCalculator.GetStartOfYearInDays(weekYear) - weekYearDaysSinceEpoch;
			int num2 = (irregularWeeks ? 6 : (minDaysInFirstWeek - 1));
			return (yearMonthDayCalculator.GetDaysInYear(weekYear) + num + num2) / 7;
		}

		public int GetWeekYear(LocalDate date)
		{
			YearMonthDay yearMonthDay = date.YearMonthDay;
			YearMonthDayCalculator yearMonthDayCalculator = date.Calendar.YearMonthDayCalculator;
			int year = yearMonthDay.Year;
			int weekYearDaysSinceEpoch = GetWeekYearDaysSinceEpoch(yearMonthDayCalculator, year);
			int daysSinceEpoch = yearMonthDayCalculator.GetDaysSinceEpoch(yearMonthDay);
			if (daysSinceEpoch < weekYearDaysSinceEpoch)
			{
				return year - 1;
			}
			if (irregularWeeks)
			{
				return year;
			}
			int weeksInWeekYear = GetWeeksInWeekYear(year, date.Calendar);
			int num = weekYearDaysSinceEpoch + weeksInWeekYear * 7;
			if (daysSinceEpoch >= num)
			{
				return year + 1;
			}
			return year;
		}

		private void ValidateWeekYear(int weekYear, CalendarSystem calendar)
		{
			checked
			{
				if (weekYear <= calendar.MinYear || weekYear >= calendar.MaxYear)
				{
					int minInclusive = ((GetWeekYearDaysSinceEpoch(calendar.YearMonthDayCalculator, calendar.MinYear) > calendar.MinDays) ? (calendar.MinYear - 1) : calendar.MinYear);
					int weekYearDaysSinceEpoch = GetWeekYearDaysSinceEpoch(calendar.YearMonthDayCalculator, calendar.MaxYear + 1);
					int maxInclusive = ((irregularWeeks || weekYearDaysSinceEpoch > calendar.MaxDays) ? calendar.MaxYear : (calendar.MaxYear + 1));
					Preconditions.CheckArgumentRange("weekYear", weekYear, minInclusive, maxInclusive);
				}
			}
		}

		private int GetWeekYearDaysSinceEpoch(YearMonthDayCalculator yearMonthDayCalculator, [Trusted] int weekYear)
		{
			int startOfYearInDays = yearMonthDayCalculator.GetStartOfYearInDays(weekYear);
			int num = (int)(((startOfYearInDays >= -3) ? (1 + (startOfYearInDays + 3) % 7) : (7 + (startOfYearInDays + 4) % 7)) - firstDayOfWeek + 7) % 7;
			int num2 = startOfYearInDays - num;
			if (7 - num < minDaysInFirstWeek)
			{
				return num2 + 7;
			}
			return num2;
		}
	}
	internal sealed class SingleEraCalculator : EraCalculator
	{
		private readonly Era era;

		private readonly int minYear;

		private readonly int maxYear;

		internal SingleEraCalculator(Era era, YearMonthDayCalculator ymdCalculator)
			: base(era)
		{
			minYear = ymdCalculator.MinYear;
			maxYear = ymdCalculator.MaxYear;
			this.era = era;
		}

		private void ValidateEra([NotNull] Era era)
		{
			if (era != this.era)
			{
				Preconditions.CheckNotNull(era, "era");
				Preconditions.CheckArgument(era == this.era, "era", "Only supported era is {0}; requested era was {1}", this.era.Name, era.Name);
			}
		}

		internal override int GetAbsoluteYear(int yearOfEra, [NotNull] Era era)
		{
			ValidateEra(era);
			Preconditions.CheckArgumentRange("yearOfEra", yearOfEra, minYear, maxYear);
			return yearOfEra;
		}

		internal override int GetYearOfEra(int absoluteYear)
		{
			return absoluteYear;
		}

		internal override int GetMinYearOfEra([NotNull] Era era)
		{
			ValidateEra(era);
			return minYear;
		}

		internal override int GetMaxYearOfEra([NotNull] Era era)
		{
			ValidateEra(era);
			return maxYear;
		}

		internal override Era GetEra(int absoluteYear)
		{
			return era;
		}
	}
	internal sealed class UmAlQuraYearMonthDayCalculator : RegularYearMonthDayCalculator
	{
		private const int AverageDaysPer10Years = 3544;

		private const int ComputedMinYear = 1318;

		private const int ComputedMaxYear = 1500;

		private const int ComputedDaysAtStartOfMinYear = -25448;

		private const string GeneratedData = "AAAF1A3SHaQdSBqUFSwKbBVqG1QXSBaSFSYKVhSuCWwVagtUGqoaVBSsCVwSugXYDaoNVAqqCVYStgV0CuoXZA7IDpIMqgVWCrYVtA2oHZIbJBpKFJoFWgraFtQWpBVKFJYJLhJuBWwK6hrUGqQVLBJaBLoJuhW0C6gbUhqkFVQJrBNsBugO0g6kDUoKlhVWCrQVqhukG0gakhUqCloUugq0FaoNVA0qClYUrglcEuwK2BaqFVQUqglaEroFtAuyG2QXSBaUFKoFagrqFtQXpBeIFxIVKgpaC1oW1A2oG5IbJBVMEqwFXAraBtQWqhVUEpoJOhK6BXQLagtUGqoVNBJcBNwKuhW0DagNSgqWFS4KnBVcC1gXUhskFkoMlhlWCrQWqg2kHUoclBUqCloVWgbYDrINpA0qCloUtgl0E3QHaBbSFqQVTAlsEtoF2A2yHWQaqBpUFKwJXBLaGtQWqBZSFSYKVhSuCmwVag1UHSYAAA==";

		private const int ComputedDaysAtStartOfYear1 = -492192;

		private static readonly int[] YearLengths;

		private static readonly ushort[] MonthLengths;

		private static readonly int[] YearStartDays;

		static UmAlQuraYearMonthDayCalculator()
		{
			byte[] array = Convert.FromBase64String("AAAF1A3SHaQdSBqUFSwKbBVqG1QXSBaSFSYKVhSuCWwVagtUGqoaVBSsCVwSugXYDaoNVAqqCVYStgV0CuoXZA7IDpIMqgVWCrYVtA2oHZIbJBpKFJoFWgraFtQWpBVKFJYJLhJuBWwK6hrUGqQVLBJaBLoJuhW0C6gbUhqkFVQJrBNsBugO0g6kDUoKlhVWCrQVqhukG0gakhUqCloUugq0FaoNVA0qClYUrglcEuwK2BaqFVQUqglaEroFtAuyG2QXSBaUFKoFagrqFtQXpBeIFxIVKgpaC1oW1A2oG5IbJBVMEqwFXAraBtQWqhVUEpoJOhK6BXQLagtUGqoVNBJcBNwKuhW0DagNSgqWFS4KnBVcC1gXUhskFkoMlhlWCrQWqg2kHUoclBUqCloVWgbYDrINpA0qCloUtgl0E3QHaBbSFqQVTAlsEtoF2A2yHWQaqBpUFKwJXBLaGtQWqBZSFSYKVhSuCmwVag1UHSYAAA==");
			MonthLengths = new ushort[array.Length / 2];
			checked
			{
				for (int i = 0; i < MonthLengths.Length; i++)
				{
					MonthLengths[i] = (ushort)((array[i * 2] << 8) | array[i * 2 + 1]);
				}
				YearLengths = new int[MonthLengths.Length];
				YearStartDays = new int[MonthLengths.Length];
				int num = 0;
				for (int j = 1; j < YearLengths.Length - 1; j++)
				{
					YearStartDays[j] = -25448 + num;
					int num2 = MonthLengths[j];
					int num3 = 348;
					for (int k = 1; k <= 12; k++)
					{
						num3 += (num2 >> k) & 1;
					}
					YearLengths[j] = num3;
					num += num3;
				}
				YearStartDays[0] = -25802;
				YearStartDays[YearStartDays.Length - 1] = -25448 + num;
				YearLengths[0] = 354;
				YearLengths[YearStartDays.Length - 1] = 354;
			}
		}

		internal UmAlQuraYearMonthDayCalculator()
			: base(1318, 1500, 12, 3544, -492192)
		{
		}

		internal override int GetStartOfYearInDays([Trusted] int year)
		{
			return YearStartDays[checked(year - 1318 + 1)];
		}

		protected override int CalculateStartOfYearDays([Trusted] int year)
		{
			throw new NotImplementedException();
		}

		protected override int GetDaysFromStartOfYearToStartOfMonth([Trusted] int year, [Trusted] int month)
		{
			checked
			{
				int num = MonthLengths[year - 1318 + 1];
				int num2 = 0;
				for (int i = 1; i < month; i++)
				{
					num2 += (num >> i) & 1;
				}
				return (month - 1) * 29 + num2;
			}
		}

		internal override int GetDaysInMonth([Trusted] int year, int month)
		{
			checked
			{
				int num = MonthLengths[year - 1318 + 1];
				return 29 + ((num >> month) & 1);
			}
		}

		internal override int GetDaysInYear([Trusted] int year)
		{
			return YearLengths[checked(year - 1318 + 1)];
		}

		internal override YearMonthDay GetYearMonthDay([Trusted] int year, [Trusted] int dayOfYear)
		{
			int num = dayOfYear;
			checked
			{
				int num2 = MonthLengths[year - 1318 + 1];
				for (int i = 1; i <= 12; i++)
				{
					int num3 = 29 + ((num2 >> i) & 1);
					if (num <= num3)
					{
						return new YearMonthDay(year, i, num);
					}
					num -= num3;
				}
				Preconditions.CheckArgumentRange("dayOfYear", dayOfYear, 1, GetDaysInYear(year));
				throw new InvalidOperationException("Bug in Noda Time: year " + year + " has " + GetDaysInYear(year) + " days but " + dayOfYear + " isn't valid");
			}
		}

		internal override bool IsLeapYear([Trusted] int year)
		{
			return YearLengths[checked(year - 1318 + 1)] == 355;
		}
	}
	public static class WeekYearRules
	{
		[NotNull]
		public static IWeekYearRule Iso { get; } = new SimpleWeekYearRule(4, IsoDayOfWeek.Monday, irregularWeeks: false);

		[NotNull]
		public static IWeekYearRule ForMinDaysInFirstWeek(int minDaysInFirstWeek)
		{
			return ForMinDaysInFirstWeek(minDaysInFirstWeek, IsoDayOfWeek.Monday);
		}

		[NotNull]
		public static IWeekYearRule ForMinDaysInFirstWeek(int minDaysInFirstWeek, IsoDayOfWeek firstDayOfWeek)
		{
			return new SimpleWeekYearRule(minDaysInFirstWeek, firstDayOfWeek, irregularWeeks: false);
		}

		[NotNull]
		public static IWeekYearRule FromCalendarWeekRule(CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
		{
			return new SimpleWeekYearRule(calendarWeekRule switch
			{
				CalendarWeekRule.FirstDay => 1, 
				CalendarWeekRule.FirstFourDayWeek => 4, 
				CalendarWeekRule.FirstFullWeek => 7, 
				_ => throw new ArgumentException($"Unsupported CalendarWeekRule: {calendarWeekRule}", "calendarWeekRule"), 
			}, firstDayOfWeek.ToIsoDayOfWeek(), irregularWeeks: true);
		}
	}
	internal abstract class YearMonthDayCalculator : IComparer<YearMonthDay>
	{
		private readonly YearStartCacheEntry[] yearCache = YearStartCacheEntry.CreateCache();

		private readonly int averageDaysPer10Years;

		internal int MinYear { get; }

		internal int MaxYear { get; }

		[VisibleForTesting]
		internal int DaysAtStartOfYear1 { get; }

		protected YearMonthDayCalculator(int minYear, int maxYear, int averageDaysPer10Years, int daysAtStartOfYear1)
		{
			Preconditions.CheckArgument(maxYear < 64512, "maxYear", "Calendar year range would invalidate caching.");
			MinYear = minYear;
			MaxYear = maxYear;
			this.averageDaysPer10Years = checked(averageDaysPer10Years + 1);
			DaysAtStartOfYear1 = daysAtStartOfYear1;
		}

		protected abstract int GetDaysFromStartOfYearToStartOfMonth([Trusted] int year, [Trusted] int month);

		protected abstract int CalculateStartOfYearDays([Trusted] int year);

		internal abstract int GetMonthsInYear([Trusted] int year);

		internal abstract int GetDaysInMonth([Trusted] int year, int month);

		internal abstract bool IsLeapYear([Trusted] int year);

		internal abstract YearMonthDay AddMonths([Trusted] YearMonthDay yearMonthDay, int months);

		internal abstract YearMonthDay GetYearMonthDay([Trusted] int year, [Trusted] int dayOfYear);

		internal abstract int GetDaysInYear([Trusted] int year);

		internal abstract int MonthsBetween([Trusted] YearMonthDay start, [Trusted] YearMonthDay end);

		internal abstract YearMonthDay SetYear(YearMonthDay yearMonthDay, [Trusted] int year);

		internal virtual int GetDaysSinceEpoch([Trusted] YearMonthDay yearMonthDay)
		{
			int year = yearMonthDay.Year;
			return checked(GetStartOfYearInDays(year) + GetDaysFromStartOfYearToStartOfMonth(year, yearMonthDay.Month) + yearMonthDay.Day - 1);
		}

		internal virtual int GetStartOfYearInDays([Trusted] int year)
		{
			int cacheIndex = YearStartCacheEntry.GetCacheIndex(year);
			YearStartCacheEntry yearStartCacheEntry = yearCache[cacheIndex];
			if (!yearStartCacheEntry.IsValidForYear(year))
			{
				int days = CalculateStartOfYearDays(year);
				yearStartCacheEntry = new YearStartCacheEntry(year, days);
				yearCache[cacheIndex] = yearStartCacheEntry;
			}
			return yearStartCacheEntry.StartOfYearDays;
		}

		public virtual int Compare([Trusted] YearMonthDay lhs, [Trusted] YearMonthDay rhs)
		{
			return lhs.CompareTo(rhs);
		}

		internal virtual void ValidateYearMonthDay(int year, int month, int day)
		{
			Preconditions.CheckArgumentRange("year", year, MinYear, MaxYear);
			Preconditions.CheckArgumentRange("month", month, 1, GetMonthsInYear(year));
			Preconditions.CheckArgumentRange("day", day, 1, GetDaysInMonth(year, month));
		}

		internal int GetDayOfYear([Trusted] YearMonthDay yearMonthDay)
		{
			return checked(GetDaysFromStartOfYearToStartOfMonth(yearMonthDay.Year, yearMonthDay.Month) + yearMonthDay.Day);
		}

		internal YearMonthDay GetYearMonthDay([Trusted] int daysSinceEpoch)
		{
			int zeroBasedDayOfYear;
			int year = GetYear(daysSinceEpoch, out zeroBasedDayOfYear);
			return GetYearMonthDay(year, checked(zeroBasedDayOfYear + 1));
		}

		[VisibleForTesting]
		internal int GetYear([Trusted] int daysSinceEpoch, out int zeroBasedDayOfYear)
		{
			checked
			{
				int num = unchecked(checked((daysSinceEpoch - DaysAtStartOfYear1) * 10) / averageDaysPer10Years) + 1;
				int startOfYearInDays = GetStartOfYearInDays(num);
				int num2 = daysSinceEpoch - startOfYearInDays;
				if (num2 < 0)
				{
					do
					{
						num--;
						num2 += GetDaysInYear(num);
					}
					while (num2 < 0);
					zeroBasedDayOfYear = num2;
					return num;
				}
				int daysInYear = GetDaysInYear(num);
				while (num2 >= daysInYear)
				{
					num++;
					num2 -= daysInYear;
					daysInYear = GetDaysInYear(num);
				}
				zeroBasedDayOfYear = num2;
				return num;
			}
		}
	}
	internal struct YearStartCacheEntry(int year, int days)
	{
		private const int CacheIndexBits = 10;

		private const int CacheIndexMask = 1023;

		private const int EntryValidationBits = 7;

		private const int EntryValidationMask = 127;

		private const int CacheSize = 1024;

		internal const int InvalidEntryYear = 64512;

		private static readonly YearStartCacheEntry Invalid = new YearStartCacheEntry(64512, 0);

		private readonly int value = (days << 7) | GetValidator(year);

		internal int StartOfYearDays => value >> 7;

		internal static YearStartCacheEntry[] CreateCache()
		{
			YearStartCacheEntry[] array = new YearStartCacheEntry[1024];
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				array[i] = Invalid;
			}
			return array;
		}

		private static int GetValidator(int year)
		{
			return (year >> 10) & 0x7F;
		}

		internal static int GetCacheIndex(int year)
		{
			return year & 0x3FF;
		}

		internal bool IsValidForYear(int year)
		{
			return GetValidator(year) == (value & 0x7F);
		}
	}
}
namespace NodaTime.Properties
{
	internal static class AssemblyInfo
	{
		internal const string PublicKeySuffix = ",PublicKey=0024000004800000940000000602000000240000525341310004000001000100d335797ef2bff74db7c046f874523c553f88d3f8e0c2ba769820c54f0e64a11b47198b544c74abb487f8d3b6466908ae2ac6fced4738e46a75e5661d5ac03fb29c7e26b13a220400cb9df95134e85716203f83b96fab661135c39b10f33e1c467a6750d8af331c602351b09a7bf5dd3a8943712d676481c5054c803184f77ed5";
	}
}
namespace NodaTime.Annotations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	internal sealed class ImmutableAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	internal sealed class MutableAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class ReadWriteForEfficiencyAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	internal sealed class SpecialNullHandlingAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All)]
	internal sealed class TestExemptionAttribute : Attribute
	{
		internal TestExemptionCategory Category { get; }

		internal TestExemptionAttribute(TestExemptionCategory category, string message = null)
		{
			Category = category;
		}
	}
	internal enum TestExemptionCategory
	{
		ConversionName = 1
	}
	[AttributeUsage(AttributeTargets.Parameter)]
	internal sealed class TrustedAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
	internal class VisibleForTestingAttribute : Attribute
	{
	}
}
