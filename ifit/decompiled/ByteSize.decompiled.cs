using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v1.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Omar Khudeira")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright © Omar Khudeira 2013-2020")]
[assembly: AssemblyDescription("ByteSize is a utility class that makes byte size representation in code easier by removing ambiguity of the value being represented. ByteSize is to bytes what System.TimeSpan is to time.")]
[assembly: AssemblyFileVersion("2.0.0")]
[assembly: AssemblyInformationalVersion("2.0.0")]
[assembly: AssemblyProduct("ByteSize")]
[assembly: AssemblyTitle("ByteSize")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("2.0.0.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class IsReadOnlyAttribute : Attribute
	{
	}
}
namespace ByteSizeLib
{
	public struct ByteSize : IComparable<ByteSize>, IEquatable<ByteSize>
	{
		public const long BytesInKibiByte = 1024L;

		public const long BytesInMebiByte = 1048576L;

		public const long BytesInGibiByte = 1073741824L;

		public const long BytesInTebiByte = 1099511627776L;

		public const long BytesInPebiByte = 1125899906842624L;

		public const string KibiByteSymbol = "KiB";

		public const string MebiByteSymbol = "MiB";

		public const string GibiByteSymbol = "GiB";

		public const string TebiByteSymbol = "TiB";

		public const string PebiByteSymbol = "PiB";

		public static readonly ByteSize MinValue = FromBits(-9223372036854775808L);

		public static readonly ByteSize MaxValue = FromBits(9223372036854775807L);

		public const long BitsInByte = 8L;

		public const string BitSymbol = "b";

		public const string ByteSymbol = "B";

		public const long BytesInKiloByte = 1000L;

		public const long BytesInMegaByte = 1000000L;

		public const long BytesInGigaByte = 1000000000L;

		public const long BytesInTeraByte = 1000000000000L;

		public const long BytesInPetaByte = 1000000000000000L;

		public const string KiloByteSymbol = "KB";

		public const string MegaByteSymbol = "MB";

		public const string GigaByteSymbol = "GB";

		public const string TeraByteSymbol = "TB";

		public const string PetaByteSymbol = "PB";

		public double KibiBytes => Bytes / 1024.0;

		public double MebiBytes => Bytes / 1048576.0;

		public double GibiBytes => Bytes / 1073741824.0;

		public double TebiBytes => Bytes / 1099511627776.0;

		public double PebiBytes => Bytes / 1125899906842624.0;

		public long Bits { get; private set; }

		public double Bytes { get; private set; }

		public string LargestWholeNumberBinarySymbol
		{
			get
			{
				if (Math.Abs(PebiBytes) >= 1.0)
				{
					return "PiB";
				}
				if (Math.Abs(TebiBytes) >= 1.0)
				{
					return "TiB";
				}
				if (Math.Abs(GibiBytes) >= 1.0)
				{
					return "GiB";
				}
				if (Math.Abs(MebiBytes) >= 1.0)
				{
					return "MiB";
				}
				if (Math.Abs(KibiBytes) >= 1.0)
				{
					return "KiB";
				}
				if (Math.Abs(Bytes) >= 1.0)
				{
					return "B";
				}
				return "b";
			}
		}

		public string LargestWholeNumberDecimalSymbol
		{
			get
			{
				if (Math.Abs(PetaBytes) >= 1.0)
				{
					return "PB";
				}
				if (Math.Abs(TeraBytes) >= 1.0)
				{
					return "TB";
				}
				if (Math.Abs(GigaBytes) >= 1.0)
				{
					return "GB";
				}
				if (Math.Abs(MegaBytes) >= 1.0)
				{
					return "MB";
				}
				if (Math.Abs(KiloBytes) >= 1.0)
				{
					return "KB";
				}
				if (Math.Abs(Bytes) >= 1.0)
				{
					return "B";
				}
				return "b";
			}
		}

		public double LargestWholeNumberBinaryValue
		{
			get
			{
				if (Math.Abs(PebiBytes) >= 1.0)
				{
					return PebiBytes;
				}
				if (Math.Abs(TebiBytes) >= 1.0)
				{
					return TebiBytes;
				}
				if (Math.Abs(GibiBytes) >= 1.0)
				{
					return GibiBytes;
				}
				if (Math.Abs(MebiBytes) >= 1.0)
				{
					return MebiBytes;
				}
				if (Math.Abs(KibiBytes) >= 1.0)
				{
					return KibiBytes;
				}
				if (Math.Abs(Bytes) >= 1.0)
				{
					return Bytes;
				}
				return Bits;
			}
		}

		public double LargestWholeNumberDecimalValue
		{
			get
			{
				if (Math.Abs(PetaBytes) >= 1.0)
				{
					return PetaBytes;
				}
				if (Math.Abs(TeraBytes) >= 1.0)
				{
					return TeraBytes;
				}
				if (Math.Abs(GigaBytes) >= 1.0)
				{
					return GigaBytes;
				}
				if (Math.Abs(MegaBytes) >= 1.0)
				{
					return MegaBytes;
				}
				if (Math.Abs(KiloBytes) >= 1.0)
				{
					return KiloBytes;
				}
				if (Math.Abs(Bytes) >= 1.0)
				{
					return Bytes;
				}
				return Bits;
			}
		}

		public double KiloBytes => Bytes / 1000.0;

		public double MegaBytes => Bytes / 1000000.0;

		public double GigaBytes => Bytes / 1000000000.0;

		public double TeraBytes => Bytes / 1000000000000.0;

		public double PetaBytes => Bytes / 1000000000000000.0;

		public static ByteSize FromKibiBytes(double value)
		{
			return new ByteSize(value * 1024.0);
		}

		public static ByteSize FromMebiBytes(double value)
		{
			return new ByteSize(value * 1048576.0);
		}

		public static ByteSize FromGibiBytes(double value)
		{
			return new ByteSize(value * 1073741824.0);
		}

		public static ByteSize FromTebiBytes(double value)
		{
			return new ByteSize(value * 1099511627776.0);
		}

		public static ByteSize FromPebiBytes(double value)
		{
			return new ByteSize(value * 1125899906842624.0);
		}

		public ByteSize AddKibiBytes(double value)
		{
			return this + FromKibiBytes(value);
		}

		public ByteSize AddMebiBytes(double value)
		{
			return this + FromMebiBytes(value);
		}

		public ByteSize AddGibiBytes(double value)
		{
			return this + FromGibiBytes(value);
		}

		public ByteSize AddTebiBytes(double value)
		{
			return this + FromTebiBytes(value);
		}

		public ByteSize AddPebiBytes(double value)
		{
			return this + FromPebiBytes(value);
		}

		public string ToBinaryString()
		{
			return ToString("0.##", CultureInfo.CurrentCulture, useBinaryByte: true);
		}

		public ByteSize(long bits)
		{
			this = default(ByteSize);
			Bits = bits;
			Bytes = bits / 8;
		}

		public ByteSize(double bytes)
		{
			this = default(ByteSize);
			Bits = (long)Math.Ceiling(bytes * 8.0);
			Bytes = bytes;
		}

		public static ByteSize FromBits(long value)
		{
			return new ByteSize(value);
		}

		public static ByteSize FromBytes(double value)
		{
			return new ByteSize(value);
		}

		public override string ToString()
		{
			return ToString("0.##", CultureInfo.CurrentCulture);
		}

		public string ToString(string format)
		{
			return ToString(format, CultureInfo.CurrentCulture);
		}

		public string ToString(string format, IFormatProvider provider, bool useBinaryByte = false)
		{
			if (!format.Contains("#") && !format.Contains("0"))
			{
				format = "0.## " + format;
			}
			if (provider == null)
			{
				provider = CultureInfo.CurrentCulture;
			}
			Func<string, bool> func = (string s) => format.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1;
			Func<double, string> func2 = (double n) => n.ToString(format, provider);
			if (func("PiB"))
			{
				return func2(PebiBytes);
			}
			if (func("TiB"))
			{
				return func2(TebiBytes);
			}
			if (func("GiB"))
			{
				return func2(GibiBytes);
			}
			if (func("MiB"))
			{
				return func2(MebiBytes);
			}
			if (func("KiB"))
			{
				return func2(KibiBytes);
			}
			if (func("PB"))
			{
				return func2(PetaBytes);
			}
			if (func("TB"))
			{
				return func2(TeraBytes);
			}
			if (func("GB"))
			{
				return func2(GigaBytes);
			}
			if (func("MB"))
			{
				return func2(MegaBytes);
			}
			if (func("KB"))
			{
				return func2(KiloBytes);
			}
			if (format.IndexOf("B") != -1)
			{
				return func2(Bytes);
			}
			if (format.IndexOf("b") != -1)
			{
				return func2(Bits);
			}
			if (useBinaryByte)
			{
				return string.Format("{0} {1}", new object[2]
				{
					LargestWholeNumberBinaryValue.ToString(format, provider),
					LargestWholeNumberBinarySymbol
				});
			}
			return string.Format("{0} {1}", new object[2]
			{
				LargestWholeNumberDecimalValue.ToString(format, provider),
				LargestWholeNumberDecimalSymbol
			});
		}

		public override bool Equals(object value)
		{
			if (value == null)
			{
				return false;
			}
			if (!(value is ByteSize value2))
			{
				return false;
			}
			return Equals(value2);
		}

		public bool Equals(ByteSize value)
		{
			return Bits == value.Bits;
		}

		public override int GetHashCode()
		{
			return Bits.GetHashCode();
		}

		public int CompareTo(ByteSize other)
		{
			return Bits.CompareTo(other.Bits);
		}

		public ByteSize Add(ByteSize bs)
		{
			return new ByteSize(Bytes + bs.Bytes);
		}

		public ByteSize AddBits(long value)
		{
			return this + FromBits(value);
		}

		public ByteSize AddBytes(double value)
		{
			return this + FromBytes(value);
		}

		public ByteSize Subtract(ByteSize bs)
		{
			return new ByteSize(Bytes - bs.Bytes);
		}

		public static ByteSize operator +(ByteSize b1, ByteSize b2)
		{
			return new ByteSize(b1.Bytes + b2.Bytes);
		}

		public static ByteSize operator ++(ByteSize b)
		{
			return new ByteSize(b.Bytes + 1.0);
		}

		public static ByteSize operator -(ByteSize b)
		{
			return new ByteSize(0.0 - b.Bytes);
		}

		public static ByteSize operator -(ByteSize b1, ByteSize b2)
		{
			return new ByteSize(b1.Bytes - b2.Bytes);
		}

		public static ByteSize operator --(ByteSize b)
		{
			return new ByteSize(b.Bytes - 1.0);
		}

		public static bool operator ==(ByteSize b1, ByteSize b2)
		{
			return b1.Bits == b2.Bits;
		}

		public static bool operator !=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits != b2.Bits;
		}

		public static bool operator <(ByteSize b1, ByteSize b2)
		{
			return b1.Bits < b2.Bits;
		}

		public static bool operator <=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits <= b2.Bits;
		}

		public static bool operator >(ByteSize b1, ByteSize b2)
		{
			return b1.Bits > b2.Bits;
		}

		public static bool operator >=(ByteSize b1, ByteSize b2)
		{
			return b1.Bits >= b2.Bits;
		}

		public static ByteSize Parse(string s)
		{
			return Parse(s, NumberFormatInfo.CurrentInfo);
		}

		public static ByteSize Parse(string s, IFormatProvider formatProvider)
		{
			return Parse(s, NumberStyles.Float | NumberStyles.AllowThousands, formatProvider);
		}

		public static ByteSize Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				throw new ArgumentNullException("s", "String is null or whitespace");
			}
			s = s.TrimStart(new char[0]);
			int num = 0;
			bool flag = false;
			NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
			char c = Convert.ToChar(instance.NumberDecimalSeparator);
			char c2 = Convert.ToChar(instance.NumberGroupSeparator);
			for (num = 0; num < s.Length; num++)
			{
				if (!char.IsDigit(s[num]) && s[num] != c && s[num] != c2)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new FormatException("No byte indicator found in value '" + s + "'.");
			}
			int num2 = num;
			string s2 = s.Substring(0, num2).Trim();
			string text = s.Substring(num2, s.Length - num2).Trim();
			if (!double.TryParse(s2, numberStyles, formatProvider, out var result))
			{
				throw new FormatException("No number found in value '" + s + "'.");
			}
			switch (text)
			{
			case "b":
				if (result % 1.0 != 0.0)
				{
					throw new FormatException("Can't have partial bits for value '" + s + "'.");
				}
				return FromBits((long)result);
			case "B":
				return FromBytes(result);
			default:
				return text.ToLowerInvariant() switch
				{
					"kib" => FromKibiBytes(result), 
					"mib" => FromMebiBytes(result), 
					"gib" => FromGibiBytes(result), 
					"tib" => FromTebiBytes(result), 
					"pib" => FromPebiBytes(result), 
					"kb" => FromKiloBytes(result), 
					"mb" => FromMegaBytes(result), 
					"gb" => FromGigaBytes(result), 
					"tb" => FromTeraBytes(result), 
					"pb" => FromPetaBytes(result), 
					_ => throw new FormatException("Bytes of magnitude '" + text + "' is not supported."), 
				};
			}
		}

		public static bool TryParse(string s, out ByteSize result)
		{
			try
			{
				result = Parse(s);
				return true;
			}
			catch
			{
				result = default(ByteSize);
				return false;
			}
		}

		public static bool TryParse(string s, NumberStyles numberStyles, IFormatProvider formatProvider, out ByteSize result)
		{
			try
			{
				result = Parse(s, numberStyles, formatProvider);
				return true;
			}
			catch
			{
				result = default(ByteSize);
				return false;
			}
		}

		public static ByteSize FromKiloBytes(double value)
		{
			return new ByteSize(value * 1000.0);
		}

		public static ByteSize FromMegaBytes(double value)
		{
			return new ByteSize(value * 1000000.0);
		}

		public static ByteSize FromGigaBytes(double value)
		{
			return new ByteSize(value * 1000000000.0);
		}

		public static ByteSize FromTeraBytes(double value)
		{
			return new ByteSize(value * 1000000000000.0);
		}

		public static ByteSize FromPetaBytes(double value)
		{
			return new ByteSize(value * 1000000000000000.0);
		}

		public ByteSize AddKiloBytes(double value)
		{
			return this + FromKiloBytes(value);
		}

		public ByteSize AddMegaBytes(double value)
		{
			return this + FromMegaBytes(value);
		}

		public ByteSize AddGigaBytes(double value)
		{
			return this + FromGigaBytes(value);
		}

		public ByteSize AddTeraBytes(double value)
		{
			return this + FromTeraBytes(value);
		}

		public ByteSize AddPetaBytes(double value)
		{
			return this + FromPetaBytes(value);
		}
	}
}
