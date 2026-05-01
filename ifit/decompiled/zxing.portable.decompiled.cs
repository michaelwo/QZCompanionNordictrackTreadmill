using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using BigIntegerLibrary;
using ZXing;
using ZXing.Aztec;
using ZXing.Aztec.Internal;
using ZXing.Common;
using ZXing.Common.Detector;
using ZXing.Common.ReedSolomon;
using ZXing.Datamatrix;
using ZXing.Datamatrix.Encoder;
using ZXing.Datamatrix.Internal;
using ZXing.IMB;
using ZXing.Maxicode;
using ZXing.Maxicode.Internal;
using ZXing.Multi;
using ZXing.Multi.QrCode;
using ZXing.Multi.QrCode.Internal;
using ZXing.OneD;
using ZXing.OneD.RSS;
using ZXing.OneD.RSS.Expanded;
using ZXing.OneD.RSS.Expanded.Decoders;
using ZXing.PDF417;
using ZXing.PDF417.Internal;
using ZXing.PDF417.Internal.EC;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyDescription("port of the java based barcode scanning library for .net (java zxing 04.03.2018 22:17:40)")]
[assembly: AssemblyCompany("ZXing.Net Development")]
[assembly: AssemblyProduct("ZXing.Net")]
[assembly: AssemblyCopyright("Copyright © 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("0.16.2.0")]
[assembly: CLSCompliant(true)]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("0.16.2.0")]
namespace System
{
	internal class TimeZoneInfo
	{
		internal static TimeZoneInfo Local;

		internal static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo destinationTimeZone)
		{
			return dateTime;
		}
	}
}
namespace System.ComponentModel
{
	[AttributeUsage(AttributeTargets.All)]
	internal sealed class BrowsableAttribute : Attribute
	{
		public BrowsableAttribute(bool browsable)
		{
		}
	}
}
namespace BigIntegerLibrary
{
	internal sealed class Base10BigInteger
	{
		private class DigitContainer
		{
			private readonly long[][] digits;

			private const int ChunkSize = 32;

			private const int ChunkSizeDivisionShift = 5;

			private const int ChunkCount = 200;

			public long this[int index]
			{
				get
				{
					int num = index >> 5;
					long[] array = digits[num];
					if (array != null)
					{
						return array[index % 32];
					}
					return 0L;
				}
				set
				{
					int num = index >> 5;
					(digits[num] ?? (digits[num] = new long[32]))[index % 32] = value;
				}
			}

			public DigitContainer()
			{
				digits = new long[200][];
			}
		}

		private const long NumberBase = 10L;

		private const int MaxSize = 6400;

		private static readonly Base10BigInteger Zero = new Base10BigInteger();

		private static readonly Base10BigInteger One = new Base10BigInteger(1L);

		private DigitContainer digits;

		private int size;

		private Sign sign;

		internal Sign NumberSign
		{
			set
			{
				sign = value;
			}
		}

		public Base10BigInteger()
		{
			digits = new DigitContainer();
			size = 1;
			digits[size] = 0L;
			sign = Sign.Positive;
		}

		public Base10BigInteger(long n)
		{
			digits = new DigitContainer();
			sign = Sign.Positive;
			if (n == 0L)
			{
				size = 1;
				digits[size] = 0L;
				return;
			}
			if (n < 0)
			{
				n = -n;
				sign = Sign.Negative;
			}
			size = 0;
			while (n > 0)
			{
				digits[size] = n % 10;
				n /= 10;
				size++;
			}
		}

		public Base10BigInteger(Base10BigInteger n)
		{
			digits = new DigitContainer();
			size = n.size;
			sign = n.sign;
			for (int i = 0; i < n.size; i++)
			{
				digits[i] = n.digits[i];
			}
		}

		public bool Equals(Base10BigInteger other)
		{
			if (sign != other.sign)
			{
				return false;
			}
			if (size != other.size)
			{
				return false;
			}
			for (int i = 0; i < size; i++)
			{
				if (digits[i] != other.digits[i])
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object o)
		{
			if (!(o is Base10BigInteger))
			{
				return false;
			}
			return Equals((Base10BigInteger)o);
		}

		public override int GetHashCode()
		{
			int num = 0;
			for (int i = 0; i < size; i++)
			{
				num += (int)digits[i];
			}
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder;
			if (sign == Sign.Negative)
			{
				stringBuilder = new StringBuilder(size + 1);
				stringBuilder.Append('-');
			}
			else
			{
				stringBuilder = new StringBuilder(size);
			}
			for (int num = size - 1; num >= 0; num--)
			{
				stringBuilder.Append(digits[num]);
			}
			return stringBuilder.ToString();
		}

		public static Base10BigInteger Opposite(Base10BigInteger n)
		{
			Base10BigInteger base10BigInteger = new Base10BigInteger(n);
			if (base10BigInteger != Zero)
			{
				if (base10BigInteger.sign == Sign.Positive)
				{
					base10BigInteger.sign = Sign.Negative;
				}
				else
				{
					base10BigInteger.sign = Sign.Positive;
				}
			}
			return base10BigInteger;
		}

		public static bool Greater(Base10BigInteger a, Base10BigInteger b)
		{
			if (a.sign != b.sign)
			{
				if (a.sign == Sign.Negative && b.sign == Sign.Positive)
				{
					return false;
				}
				if (a.sign == Sign.Positive && b.sign == Sign.Negative)
				{
					return true;
				}
			}
			else if (a.sign == Sign.Positive)
			{
				if (a.size > b.size)
				{
					return true;
				}
				if (a.size < b.size)
				{
					return false;
				}
				for (int num = a.size - 1; num >= 0; num--)
				{
					if (a.digits[num] > b.digits[num])
					{
						return true;
					}
					if (a.digits[num] < b.digits[num])
					{
						return false;
					}
				}
			}
			else
			{
				if (a.size < b.size)
				{
					return true;
				}
				if (a.size > b.size)
				{
					return false;
				}
				for (int num2 = a.size - 1; num2 >= 0; num2--)
				{
					if (a.digits[num2] < b.digits[num2])
					{
						return true;
					}
					if (a.digits[num2] > b.digits[num2])
					{
						return false;
					}
				}
			}
			return false;
		}

		public static bool GreaterOrEqual(Base10BigInteger a, Base10BigInteger b)
		{
			if (!Greater(a, b))
			{
				return object.Equals(a, b);
			}
			return true;
		}

		public static bool Smaller(Base10BigInteger a, Base10BigInteger b)
		{
			return !GreaterOrEqual(a, b);
		}

		public static bool SmallerOrEqual(Base10BigInteger a, Base10BigInteger b)
		{
			return !Greater(a, b);
		}

		public static Base10BigInteger Abs(Base10BigInteger n)
		{
			return new Base10BigInteger(n)
			{
				sign = Sign.Positive
			};
		}

		public static Base10BigInteger Addition(Base10BigInteger a, Base10BigInteger b)
		{
			Base10BigInteger base10BigInteger = null;
			if (a.sign == Sign.Positive && b.sign == Sign.Positive)
			{
				base10BigInteger = ((!(a >= b)) ? Add(b, a) : Add(a, b));
				base10BigInteger.sign = Sign.Positive;
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Negative)
			{
				base10BigInteger = ((!(a <= b)) ? Add(-b, -a) : Add(-a, -b));
				base10BigInteger.sign = Sign.Negative;
			}
			if (a.sign == Sign.Positive && b.sign == Sign.Negative)
			{
				if (a >= -b)
				{
					base10BigInteger = Subtract(a, -b);
					base10BigInteger.sign = Sign.Positive;
				}
				else
				{
					base10BigInteger = Subtract(-b, a);
					base10BigInteger.sign = Sign.Negative;
				}
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Positive)
			{
				if (-a <= b)
				{
					base10BigInteger = Subtract(b, -a);
					base10BigInteger.sign = Sign.Positive;
				}
				else
				{
					base10BigInteger = Subtract(-a, b);
					base10BigInteger.sign = Sign.Negative;
				}
			}
			return base10BigInteger;
		}

		public static Base10BigInteger Subtraction(Base10BigInteger a, Base10BigInteger b)
		{
			Base10BigInteger base10BigInteger = null;
			if (a.sign == Sign.Positive && b.sign == Sign.Positive)
			{
				if (a >= b)
				{
					base10BigInteger = Subtract(a, b);
					base10BigInteger.sign = Sign.Positive;
				}
				else
				{
					base10BigInteger = Subtract(b, a);
					base10BigInteger.sign = Sign.Negative;
				}
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Negative)
			{
				if (a <= b)
				{
					base10BigInteger = Subtract(-a, -b);
					base10BigInteger.sign = Sign.Negative;
				}
				else
				{
					base10BigInteger = Subtract(-b, -a);
					base10BigInteger.sign = Sign.Positive;
				}
			}
			if (a.sign == Sign.Positive && b.sign == Sign.Negative)
			{
				base10BigInteger = ((!(a >= -b)) ? Add(-b, a) : Add(a, -b));
				base10BigInteger.sign = Sign.Positive;
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Positive)
			{
				base10BigInteger = ((!(-a >= b)) ? Add(b, -a) : Add(-a, b));
				base10BigInteger.sign = Sign.Negative;
			}
			return base10BigInteger;
		}

		public static Base10BigInteger Multiplication(Base10BigInteger a, Base10BigInteger b)
		{
			if (a == Zero || b == Zero)
			{
				return Zero;
			}
			Base10BigInteger base10BigInteger = Multiply(Abs(a), Abs(b));
			if (a.sign == b.sign)
			{
				base10BigInteger.sign = Sign.Positive;
			}
			else
			{
				base10BigInteger.sign = Sign.Negative;
			}
			return base10BigInteger;
		}

		public static implicit operator Base10BigInteger(long n)
		{
			return new Base10BigInteger(n);
		}

		public static bool operator ==(Base10BigInteger a, Base10BigInteger b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(Base10BigInteger a, Base10BigInteger b)
		{
			return !object.Equals(a, b);
		}

		public static bool operator >(Base10BigInteger a, Base10BigInteger b)
		{
			return Greater(a, b);
		}

		public static bool operator <(Base10BigInteger a, Base10BigInteger b)
		{
			return Smaller(a, b);
		}

		public static bool operator >=(Base10BigInteger a, Base10BigInteger b)
		{
			return GreaterOrEqual(a, b);
		}

		public static bool operator <=(Base10BigInteger a, Base10BigInteger b)
		{
			return SmallerOrEqual(a, b);
		}

		public static Base10BigInteger operator -(Base10BigInteger n)
		{
			return Opposite(n);
		}

		public static Base10BigInteger operator +(Base10BigInteger a, Base10BigInteger b)
		{
			return Addition(a, b);
		}

		public static Base10BigInteger operator -(Base10BigInteger a, Base10BigInteger b)
		{
			return Subtraction(a, b);
		}

		public static Base10BigInteger operator *(Base10BigInteger a, Base10BigInteger b)
		{
			return Multiplication(a, b);
		}

		public static Base10BigInteger operator ++(Base10BigInteger n)
		{
			return n + One;
		}

		public static Base10BigInteger operator --(Base10BigInteger n)
		{
			return n - One;
		}

		private static Base10BigInteger Add(Base10BigInteger a, Base10BigInteger b)
		{
			Base10BigInteger base10BigInteger = new Base10BigInteger(a);
			long num = 0L;
			for (int i = 0; i < b.size; i++)
			{
				long num2 = base10BigInteger.digits[i] + b.digits[i] + num;
				base10BigInteger.digits[i] = num2 % 10;
				num = num2 / 10;
			}
			for (int i = b.size; i < a.size; i++)
			{
				if (num <= 0)
				{
					break;
				}
				long num2 = base10BigInteger.digits[i] + num;
				base10BigInteger.digits[i] = num2 % 10;
				num = num2 / 10;
			}
			if (num > 0)
			{
				base10BigInteger.digits[base10BigInteger.size] = num % 10;
				base10BigInteger.size++;
				num /= 10;
			}
			return base10BigInteger;
		}

		private static Base10BigInteger Subtract(Base10BigInteger a, Base10BigInteger b)
		{
			Base10BigInteger base10BigInteger = new Base10BigInteger(a);
			long num = 0L;
			bool flag = true;
			for (int i = 0; i < b.size; i++)
			{
				long num2 = base10BigInteger.digits[i] - b.digits[i] - num;
				if (num2 < 0)
				{
					num = 1L;
					num2 += 10;
				}
				else
				{
					num = 0L;
				}
				base10BigInteger.digits[i] = num2;
			}
			for (int i = b.size; i < a.size; i++)
			{
				if (num <= 0)
				{
					break;
				}
				long num2 = base10BigInteger.digits[i] - num;
				if (num2 < 0)
				{
					num = 1L;
					num2 += 10;
				}
				else
				{
					num = 0L;
				}
				base10BigInteger.digits[i] = num2;
			}
			while (base10BigInteger.size - 1 > 0 && flag)
			{
				if (base10BigInteger.digits[base10BigInteger.size - 1] == 0L)
				{
					base10BigInteger.size--;
				}
				else
				{
					flag = false;
				}
			}
			return base10BigInteger;
		}

		private static Base10BigInteger Multiply(Base10BigInteger a, Base10BigInteger b)
		{
			long num = 0L;
			Base10BigInteger base10BigInteger = new Base10BigInteger();
			base10BigInteger.size = a.size + b.size - 1;
			for (int i = 0; i < base10BigInteger.size + 1; i++)
			{
				base10BigInteger.digits[i] = 0L;
			}
			for (int i = 0; i < a.size; i++)
			{
				if (a.digits[i] == 0L)
				{
					continue;
				}
				for (int j = 0; j < b.size; j++)
				{
					if (b.digits[j] != 0L)
					{
						base10BigInteger.digits[i + j] += a.digits[i] * b.digits[j];
					}
				}
			}
			for (int i = 0; i < base10BigInteger.size; i++)
			{
				long num2 = base10BigInteger.digits[i] + num;
				base10BigInteger.digits[i] = num2 % 10;
				num = num2 / 10;
			}
			if (num > 0)
			{
				base10BigInteger.digits[base10BigInteger.size] = num % 10;
				base10BigInteger.size++;
				num /= 10;
			}
			return base10BigInteger;
		}
	}
	internal sealed class BigInteger : IEquatable<BigInteger>, IComparable, IComparable<BigInteger>
	{
		private class DigitContainer
		{
			private readonly long[][] digits;

			private const int ChunkSize = 16;

			private const int ChunkSizeDivisionShift = 4;

			private const int ChunkCount = 80;

			public long this[int index]
			{
				get
				{
					int num = index >> 4;
					long[] array = digits[num];
					if (array != null)
					{
						return array[index % 16];
					}
					return 0L;
				}
				set
				{
					int num = index >> 4;
					(digits[num] ?? (digits[num] = new long[16]))[index % 16] = value;
				}
			}

			public DigitContainer()
			{
				digits = new long[80][];
			}
		}

		private const long NumberBase = 65536L;

		internal const int MaxSize = 1280;

		private const int RatioToBinaryDigits = 16;

		public static readonly BigInteger Zero = new BigInteger();

		public static readonly BigInteger One = new BigInteger(1L);

		public static readonly BigInteger Two = new BigInteger(2L);

		public static readonly BigInteger Ten = new BigInteger(10L);

		private DigitContainer digits;

		private int size;

		private Sign sign;

		public BigInteger()
		{
			digits = new DigitContainer();
			size = 1;
			digits[size] = 0L;
			sign = Sign.Positive;
		}

		public BigInteger(long n)
		{
			digits = new DigitContainer();
			sign = Sign.Positive;
			if (n == 0L)
			{
				size = 1;
				digits[size] = 0L;
				return;
			}
			if (n < 0)
			{
				n = -n;
				sign = Sign.Negative;
			}
			size = 0;
			while (n > 0)
			{
				digits[size] = n % 65536;
				n /= 65536;
				size++;
			}
		}

		public BigInteger(BigInteger n)
		{
			digits = new DigitContainer();
			size = n.size;
			sign = n.sign;
			for (int i = 0; i < n.size; i++)
			{
				digits[i] = n.digits[i];
			}
		}

		public BigInteger(string numberString)
		{
			BigInteger bigInteger = new BigInteger();
			Sign sign = Sign.Positive;
			for (int i = 0; i < numberString.Length; i++)
			{
				if (numberString[i] < '0' || numberString[i] > '9')
				{
					if (i != 0 || numberString[i] != '-')
					{
						throw new BigIntegerException("Invalid numeric string.", null);
					}
					sign = Sign.Negative;
				}
				else
				{
					bigInteger = bigInteger * Ten + long.Parse(numberString[i].ToString());
				}
			}
			this.sign = sign;
			digits = new DigitContainer();
			size = bigInteger.size;
			for (int i = 0; i < bigInteger.size; i++)
			{
				digits[i] = bigInteger.digits[i];
			}
		}

		public BigInteger(byte[] byteArray)
		{
			if (byteArray.Length / 4 > 1280)
			{
				throw new BigIntegerException("The byte array's content exceeds the maximum size of a BigInteger.", null);
			}
			digits = new DigitContainer();
			sign = Sign.Positive;
			for (int i = 0; i < byteArray.Length; i += 2)
			{
				int num = byteArray[i];
				if (i + 1 < byteArray.Length)
				{
					num <<= 8;
					num += byteArray[i + 1];
				}
				digits[size++] = num;
			}
			bool flag = true;
			while (size - 1 > 0 && flag)
			{
				if (digits[size - 1] == 0L)
				{
					size--;
				}
				else
				{
					flag = false;
				}
			}
		}

		public bool Equals(BigInteger other)
		{
			if (sign != other.sign)
			{
				return false;
			}
			if (size != other.size)
			{
				return false;
			}
			for (int i = 0; i < size; i++)
			{
				if (digits[i] != other.digits[i])
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object o)
		{
			if (!(o is BigInteger))
			{
				return false;
			}
			return Equals((BigInteger)o);
		}

		public override int GetHashCode()
		{
			int num = 0;
			for (int i = 0; i < size; i++)
			{
				num += (int)digits[i];
			}
			return num;
		}

		public override string ToString()
		{
			Base10BigInteger base10BigInteger = new Base10BigInteger();
			Base10BigInteger base10BigInteger2 = new Base10BigInteger(1L);
			for (int i = 0; i < size; i++)
			{
				base10BigInteger += digits[i] * base10BigInteger2;
				base10BigInteger2 *= (Base10BigInteger)65536L;
			}
			base10BigInteger.NumberSign = sign;
			return base10BigInteger.ToString();
		}

		public static BigInteger Parse(string str)
		{
			return new BigInteger(str);
		}

		public int CompareTo(BigInteger other)
		{
			if (Greater(this, other))
			{
				return 1;
			}
			if (object.Equals(this, other))
			{
				return 0;
			}
			return -1;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is BigInteger))
			{
				throw new ArgumentException("obj is not a BigInteger.");
			}
			return CompareTo((BigInteger)obj);
		}

		public static int SizeInBinaryDigits(BigInteger n)
		{
			return n.size * 16;
		}

		public static BigInteger Opposite(BigInteger n)
		{
			BigInteger bigInteger = new BigInteger(n);
			if (bigInteger != Zero)
			{
				if (bigInteger.sign == Sign.Positive)
				{
					bigInteger.sign = Sign.Negative;
				}
				else
				{
					bigInteger.sign = Sign.Positive;
				}
			}
			return bigInteger;
		}

		public static bool Greater(BigInteger a, BigInteger b)
		{
			if (a.sign != b.sign)
			{
				if (a.sign == Sign.Negative && b.sign == Sign.Positive)
				{
					return false;
				}
				if (a.sign == Sign.Positive && b.sign == Sign.Negative)
				{
					return true;
				}
			}
			else if (a.sign == Sign.Positive)
			{
				if (a.size > b.size)
				{
					return true;
				}
				if (a.size < b.size)
				{
					return false;
				}
				for (int num = a.size - 1; num >= 0; num--)
				{
					if (a.digits[num] > b.digits[num])
					{
						return true;
					}
					if (a.digits[num] < b.digits[num])
					{
						return false;
					}
				}
			}
			else
			{
				if (a.size < b.size)
				{
					return true;
				}
				if (a.size > b.size)
				{
					return false;
				}
				for (int num2 = a.size - 1; num2 >= 0; num2--)
				{
					if (a.digits[num2] < b.digits[num2])
					{
						return true;
					}
					if (a.digits[num2] > b.digits[num2])
					{
						return false;
					}
				}
			}
			return false;
		}

		public static bool GreaterOrEqual(BigInteger a, BigInteger b)
		{
			if (!Greater(a, b))
			{
				return object.Equals(a, b);
			}
			return true;
		}

		public static bool Smaller(BigInteger a, BigInteger b)
		{
			return !GreaterOrEqual(a, b);
		}

		public static bool SmallerOrEqual(BigInteger a, BigInteger b)
		{
			return !Greater(a, b);
		}

		public static BigInteger Abs(BigInteger n)
		{
			return new BigInteger(n)
			{
				sign = Sign.Positive
			};
		}

		public static BigInteger Addition(BigInteger a, BigInteger b)
		{
			BigInteger bigInteger = null;
			if (a.sign == Sign.Positive && b.sign == Sign.Positive)
			{
				bigInteger = ((!(a >= b)) ? Add(b, a) : Add(a, b));
				bigInteger.sign = Sign.Positive;
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Negative)
			{
				bigInteger = ((!(a <= b)) ? Add(-b, -a) : Add(-a, -b));
				bigInteger.sign = Sign.Negative;
			}
			if (a.sign == Sign.Positive && b.sign == Sign.Negative)
			{
				if (a >= -b)
				{
					bigInteger = Subtract(a, -b);
					bigInteger.sign = Sign.Positive;
				}
				else
				{
					bigInteger = Subtract(-b, a);
					bigInteger.sign = Sign.Negative;
				}
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Positive)
			{
				if (-a <= b)
				{
					bigInteger = Subtract(b, -a);
					bigInteger.sign = Sign.Positive;
				}
				else
				{
					bigInteger = Subtract(-a, b);
					bigInteger.sign = Sign.Negative;
				}
			}
			return bigInteger;
		}

		public static BigInteger Subtraction(BigInteger a, BigInteger b)
		{
			BigInteger bigInteger = null;
			if (a.sign == Sign.Positive && b.sign == Sign.Positive)
			{
				if (a >= b)
				{
					bigInteger = Subtract(a, b);
					bigInteger.sign = Sign.Positive;
				}
				else
				{
					bigInteger = Subtract(b, a);
					bigInteger.sign = Sign.Negative;
				}
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Negative)
			{
				if (a <= b)
				{
					bigInteger = Subtract(-a, -b);
					bigInteger.sign = Sign.Negative;
				}
				else
				{
					bigInteger = Subtract(-b, -a);
					bigInteger.sign = Sign.Positive;
				}
			}
			if (a.sign == Sign.Positive && b.sign == Sign.Negative)
			{
				bigInteger = ((!(a >= -b)) ? Add(-b, a) : Add(a, -b));
				bigInteger.sign = Sign.Positive;
			}
			if (a.sign == Sign.Negative && b.sign == Sign.Positive)
			{
				bigInteger = ((!(-a >= b)) ? Add(b, -a) : Add(-a, b));
				bigInteger.sign = Sign.Negative;
			}
			return bigInteger;
		}

		public static BigInteger Multiplication(BigInteger a, BigInteger b)
		{
			if (a == Zero || b == Zero)
			{
				return Zero;
			}
			BigInteger bigInteger = Multiply(Abs(a), Abs(b));
			if (a.sign == b.sign)
			{
				bigInteger.sign = Sign.Positive;
			}
			else
			{
				bigInteger.sign = Sign.Negative;
			}
			return bigInteger;
		}

		public static BigInteger Division(BigInteger a, BigInteger b)
		{
			if (b == Zero)
			{
				throw new BigIntegerException("Cannot divide by zero.", new DivideByZeroException());
			}
			if (a == Zero)
			{
				return Zero;
			}
			if (Abs(a) < Abs(b))
			{
				return Zero;
			}
			BigInteger bigInteger = ((b.size != 1) ? DivideByBigNumber(Abs(a), Abs(b)) : DivideByOneDigitNumber(Abs(a), b.digits[0]));
			if (a.sign == b.sign)
			{
				bigInteger.sign = Sign.Positive;
			}
			else
			{
				bigInteger.sign = Sign.Negative;
			}
			return bigInteger;
		}

		public static BigInteger Modulo(BigInteger a, BigInteger b)
		{
			if (b == Zero)
			{
				throw new BigIntegerException("Cannot divide by zero.", new DivideByZeroException());
			}
			if (Abs(a) < Abs(b))
			{
				return new BigInteger(a);
			}
			return a - a / b * b;
		}

		public static BigInteger Power(BigInteger a, int exponent)
		{
			if (exponent < 0)
			{
				throw new BigIntegerException("Cannot raise an BigInteger to a negative power.", null);
			}
			if (a == Zero)
			{
				return new BigInteger();
			}
			BigInteger result = new BigInteger(1L);
			if (exponent == 0)
			{
				return result;
			}
			BigInteger bigInteger = new BigInteger(a);
			while (exponent > 0)
			{
				if (exponent % 2 == 1)
				{
					result *= bigInteger;
				}
				exponent /= 2;
				if (exponent > 0)
				{
					bigInteger *= bigInteger;
				}
			}
			return result;
		}

		public static BigInteger IntegerSqrt(BigInteger n)
		{
			if (n.sign == Sign.Negative)
			{
				throw new BigIntegerException("Cannot compute the integer square root of a negative number.", null);
			}
			BigInteger bigInteger = new BigInteger(0L);
			BigInteger bigInteger2 = new BigInteger(n);
			while (Abs(bigInteger2 - bigInteger) >= One)
			{
				bigInteger = bigInteger2;
				bigInteger2 = (bigInteger + n / bigInteger) / Two;
			}
			return bigInteger2;
		}

		public static BigInteger Gcd(BigInteger a, BigInteger b)
		{
			if (a.sign == Sign.Negative || b.sign == Sign.Negative)
			{
				throw new BigIntegerException("Cannot compute the Gcd of negative BigIntegers.", null);
			}
			while (b > Zero)
			{
				BigInteger bigInteger = a % b;
				a = b;
				b = bigInteger;
			}
			return a;
		}

		public static BigInteger ExtendedEuclidGcd(BigInteger a, BigInteger b, out BigInteger u, out BigInteger v)
		{
			if (a.sign == Sign.Negative || b.sign == Sign.Negative)
			{
				throw new BigIntegerException("Cannot compute the Gcd of negative BigIntegers.", null);
			}
			BigInteger bigInteger = new BigInteger();
			BigInteger bigInteger2 = new BigInteger(1L);
			BigInteger bigInteger3 = new BigInteger(1L);
			BigInteger bigInteger4 = new BigInteger();
			u = new BigInteger();
			v = new BigInteger();
			while (b > Zero)
			{
				BigInteger bigInteger5 = a / b;
				BigInteger n = a - bigInteger5 * b;
				u = bigInteger2 - bigInteger5 * bigInteger;
				v = bigInteger4 - bigInteger5 * bigInteger3;
				a = new BigInteger(b);
				b = new BigInteger(n);
				bigInteger2 = new BigInteger(bigInteger);
				bigInteger = new BigInteger(u);
				bigInteger4 = new BigInteger(bigInteger3);
				bigInteger3 = new BigInteger(v);
				u = new BigInteger(bigInteger2);
				v = new BigInteger(bigInteger4);
			}
			return a;
		}

		public static BigInteger ModularInverse(BigInteger a, BigInteger n)
		{
			if (n < Two)
			{
				throw new BigIntegerException("Cannot perform a modulo operation against a BigInteger less than 2.", null);
			}
			if (Abs(a) >= n)
			{
				a %= n;
			}
			if (a.sign == Sign.Negative)
			{
				a += n;
			}
			if (a == Zero)
			{
				throw new BigIntegerException("Cannot obtain the modular inverse of 0.", null);
			}
			if (Gcd(a, n) != One)
			{
				throw new BigIntegerException("Cannot obtain the modular inverse of a number that is not coprime with the modulus.", null);
			}
			ExtendedEuclidGcd(n, a, out var _, out var v);
			if (v.sign == Sign.Negative)
			{
				return v + n;
			}
			return v;
		}

		public static BigInteger ModularExponentiation(BigInteger a, BigInteger exponent, BigInteger n)
		{
			if (exponent < 0)
			{
				throw new BigIntegerException("Cannot raise a BigInteger to a negative power.", null);
			}
			if (n < Two)
			{
				throw new BigIntegerException("Cannot perform a modulo operation against a BigInteger less than 2.", null);
			}
			if (Abs(a) >= n)
			{
				a %= n;
			}
			if (a.sign == Sign.Negative)
			{
				a += n;
			}
			if (a == Zero)
			{
				return new BigInteger();
			}
			BigInteger bigInteger = new BigInteger(1L);
			BigInteger bigInteger2 = new BigInteger(a);
			while (exponent > Zero)
			{
				if (exponent % Two == One)
				{
					bigInteger = bigInteger * bigInteger2 % n;
				}
				exponent /= Two;
				bigInteger2 = bigInteger2 * bigInteger2 % n;
			}
			return bigInteger;
		}

		public static implicit operator BigInteger(long n)
		{
			return new BigInteger(n);
		}

		public static implicit operator BigInteger(int n)
		{
			return new BigInteger(n);
		}

		public static explicit operator int(BigInteger value)
		{
			long num = 0L;
			for (int num2 = value.size - 1; num2 >= 0; num2--)
			{
				num *= 65536;
				num += value.digits[num2];
			}
			if (value.sign != Sign.Negative)
			{
				return (int)num;
			}
			return -1 * (int)num;
		}

		public static explicit operator ulong(BigInteger value)
		{
			ulong num = 0uL;
			for (int num2 = value.size - 1; num2 >= 0; num2--)
			{
				num *= 65536;
				num += (ulong)value.digits[num2];
			}
			return num;
		}

		public static bool operator ==(BigInteger a, BigInteger b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(BigInteger a, BigInteger b)
		{
			return !object.Equals(a, b);
		}

		public static bool operator >(BigInteger a, BigInteger b)
		{
			return Greater(a, b);
		}

		public static bool operator <(BigInteger a, BigInteger b)
		{
			return Smaller(a, b);
		}

		public static bool operator >=(BigInteger a, BigInteger b)
		{
			return GreaterOrEqual(a, b);
		}

		public static bool operator <=(BigInteger a, BigInteger b)
		{
			return SmallerOrEqual(a, b);
		}

		public static BigInteger operator -(BigInteger n)
		{
			return Opposite(n);
		}

		public static BigInteger operator +(BigInteger a, BigInteger b)
		{
			return Addition(a, b);
		}

		public static BigInteger operator -(BigInteger a, BigInteger b)
		{
			return Subtraction(a, b);
		}

		public static BigInteger operator *(BigInteger a, BigInteger b)
		{
			return Multiplication(a, b);
		}

		public static BigInteger operator /(BigInteger a, BigInteger b)
		{
			return Division(a, b);
		}

		public static BigInteger operator %(BigInteger a, BigInteger b)
		{
			return Modulo(a, b);
		}

		public static BigInteger operator ++(BigInteger n)
		{
			return n + One;
		}

		public static BigInteger operator --(BigInteger n)
		{
			return n - One;
		}

		private static BigInteger Add(BigInteger a, BigInteger b)
		{
			BigInteger bigInteger = new BigInteger(a);
			long num = 0L;
			for (int i = 0; i < b.size; i++)
			{
				long num2 = bigInteger.digits[i] + b.digits[i] + num;
				bigInteger.digits[i] = num2 % 65536;
				num = num2 / 65536;
			}
			for (int i = b.size; i < a.size; i++)
			{
				if (num <= 0)
				{
					break;
				}
				long num2 = bigInteger.digits[i] + num;
				bigInteger.digits[i] = num2 % 65536;
				num = num2 / 65536;
			}
			if (num > 0)
			{
				bigInteger.digits[bigInteger.size] = num % 65536;
				bigInteger.size++;
				num /= 65536;
			}
			return bigInteger;
		}

		private static BigInteger Subtract(BigInteger a, BigInteger b)
		{
			BigInteger bigInteger = new BigInteger(a);
			long num = 0L;
			bool flag = true;
			for (int i = 0; i < b.size; i++)
			{
				long num2 = bigInteger.digits[i] - b.digits[i] - num;
				if (num2 < 0)
				{
					num = 1L;
					num2 += 65536;
				}
				else
				{
					num = 0L;
				}
				bigInteger.digits[i] = num2;
			}
			for (int i = b.size; i < a.size; i++)
			{
				if (num <= 0)
				{
					break;
				}
				long num2 = bigInteger.digits[i] - num;
				if (num2 < 0)
				{
					num = 1L;
					num2 += 65536;
				}
				else
				{
					num = 0L;
				}
				bigInteger.digits[i] = num2;
			}
			while (bigInteger.size - 1 > 0 && flag)
			{
				if (bigInteger.digits[bigInteger.size - 1] == 0L)
				{
					bigInteger.size--;
				}
				else
				{
					flag = false;
				}
			}
			return bigInteger;
		}

		private static BigInteger Multiply(BigInteger a, BigInteger b)
		{
			long num = 0L;
			BigInteger bigInteger = new BigInteger();
			bigInteger.size = a.size + b.size - 1;
			for (int i = 0; i < bigInteger.size + 1; i++)
			{
				bigInteger.digits[i] = 0L;
			}
			for (int i = 0; i < a.size; i++)
			{
				if (a.digits[i] == 0L)
				{
					continue;
				}
				for (int j = 0; j < b.size; j++)
				{
					if (b.digits[j] != 0L)
					{
						bigInteger.digits[i + j] += a.digits[i] * b.digits[j];
					}
				}
			}
			for (int i = 0; i < bigInteger.size; i++)
			{
				long num2 = bigInteger.digits[i] + num;
				bigInteger.digits[i] = num2 % 65536;
				num = num2 / 65536;
			}
			if (num > 0)
			{
				bigInteger.digits[bigInteger.size] = num % 65536;
				bigInteger.size++;
				num /= 65536;
			}
			return bigInteger;
		}

		private static BigInteger DivideByOneDigitNumber(BigInteger a, long b)
		{
			BigInteger bigInteger = new BigInteger();
			int num = a.size - 1;
			bigInteger.size = a.size;
			long num2 = a.digits[num];
			while (num >= 0)
			{
				bigInteger.digits[num] = num2 / b;
				num2 %= b;
				num--;
				if (num >= 0)
				{
					num2 = num2 * 65536 + a.digits[num];
				}
			}
			if (bigInteger.digits[bigInteger.size - 1] == 0L && bigInteger.size != 1)
			{
				bigInteger.size--;
			}
			return bigInteger;
		}

		private static BigInteger DivideByBigNumber(BigInteger a, BigInteger b)
		{
			int num = a.size;
			int num2 = b.size;
			long num3 = 65536 / (b.digits[num2 - 1] + 1);
			BigInteger bigInteger = new BigInteger();
			BigInteger r = a * num3;
			BigInteger bigInteger2 = b * num3;
			for (int num4 = num - num2; num4 >= 0; num4--)
			{
				long num5 = Trial(r, bigInteger2, num4, num2);
				BigInteger dq = bigInteger2 * num5;
				if (DivideByBigNumberSmaller(r, dq, num4, num2))
				{
					num5--;
					dq = bigInteger2 * num5;
				}
				bigInteger.digits[num4] = num5;
				Difference(r, dq, num4, num2);
			}
			bigInteger.size = num - num2 + 1;
			if (bigInteger.size != 1 && bigInteger.digits[bigInteger.size - 1] == 0L)
			{
				bigInteger.size--;
			}
			return bigInteger;
		}

		private static bool DivideByBigNumberSmaller(BigInteger r, BigInteger dq, int k, int m)
		{
			int num = m;
			int num2 = 0;
			while (num != num2)
			{
				if (r.digits[num + k] != dq.digits[num])
				{
					num2 = num;
				}
				else
				{
					num--;
				}
			}
			if (r.digits[num + k] < dq.digits[num])
			{
				return true;
			}
			return false;
		}

		private static void Difference(BigInteger r, BigInteger dq, int k, int m)
		{
			long num = 0L;
			for (int i = 0; i <= m; i++)
			{
				long num2 = r.digits[i + k] - dq.digits[i] - num + 65536;
				r.digits[i + k] = num2 % 65536;
				num = 1 - num2 / 65536;
			}
		}

		private static long Trial(BigInteger r, BigInteger d, int k, int m)
		{
			int num = k + m;
			long num2 = (r.digits[num] * 65536 + r.digits[num - 1]) * 65536 + r.digits[num - 2];
			long num3 = d.digits[m - 1] * 65536 + d.digits[m - 2];
			long num4 = num2 / num3;
			if (num4 < 65535)
			{
				return (int)num4;
			}
			return 65535L;
		}
	}
	[ZXing.Serializable]
	public sealed class BigIntegerException : Exception
	{
		public BigIntegerException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	internal enum Sign
	{
		Positive,
		Negative
	}
}
namespace ZXing
{
	[Flags]
	public enum BarcodeFormat
	{
		AZTEC = 1,
		CODABAR = 2,
		CODE_39 = 4,
		CODE_93 = 8,
		CODE_128 = 0x10,
		DATA_MATRIX = 0x20,
		EAN_8 = 0x40,
		EAN_13 = 0x80,
		ITF = 0x100,
		MAXICODE = 0x200,
		PDF_417 = 0x400,
		QR_CODE = 0x800,
		RSS_14 = 0x1000,
		RSS_EXPANDED = 0x2000,
		UPC_A = 0x4000,
		UPC_E = 0x8000,
		UPC_EAN_EXTENSION = 0x10000,
		MSI = 0x20000,
		PLESSEY = 0x40000,
		IMB = 0x80000,
		All_1D = 0xF1DE
	}
	public class BarcodeReader : BarcodeReaderGeneric, IBarcodeReader
	{
		private static readonly Func<byte[], LuminanceSource> defaultCreateLuminanceSource = (byte[] data) => (LuminanceSource)null;

		private readonly Func<byte[], LuminanceSource> createLuminanceSource;

		protected Func<byte[], LuminanceSource> CreateLuminanceSource => createLuminanceSource;

		public BarcodeReader()
			: this(new MultiFormatReader(), defaultCreateLuminanceSource, null)
		{
		}

		public BarcodeReader(Reader reader, Func<byte[], LuminanceSource> createLuminanceSource, Func<LuminanceSource, Binarizer> createBinarizer)
			: this(reader, createLuminanceSource, createBinarizer, null)
		{
		}

		public BarcodeReader(Reader reader, Func<byte[], LuminanceSource> createLuminanceSource, Func<LuminanceSource, Binarizer> createBinarizer, Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> createRGBLuminanceSource)
			: base(reader, createBinarizer, createRGBLuminanceSource)
		{
			this.createLuminanceSource = createLuminanceSource ?? defaultCreateLuminanceSource;
		}

		public Result Decode(byte[] barcodeBitmap)
		{
			if (CreateLuminanceSource == null)
			{
				throw new InvalidOperationException("You have to declare a luminance source delegate.");
			}
			if (barcodeBitmap == null)
			{
				throw new ArgumentNullException("barcodeBitmap");
			}
			LuminanceSource luminanceSource = CreateLuminanceSource(barcodeBitmap);
			return Decode(luminanceSource);
		}

		public Result[] DecodeMultiple(byte[] barcodeBitmap)
		{
			if (CreateLuminanceSource == null)
			{
				throw new InvalidOperationException("You have to declare a luminance source delegate.");
			}
			if (barcodeBitmap == null)
			{
				throw new ArgumentNullException("barcodeBitmap");
			}
			LuminanceSource luminanceSource = CreateLuminanceSource(barcodeBitmap);
			return DecodeMultiple(luminanceSource);
		}
	}
	public class BarcodeReader<T> : BarcodeReaderGeneric, IBarcodeReader<T>
	{
		private readonly Func<T, LuminanceSource> createLuminanceSource;

		protected Func<T, LuminanceSource> CreateLuminanceSource => createLuminanceSource;

		public BarcodeReader(Func<T, LuminanceSource> createLuminanceSource)
			: this((Reader)null, createLuminanceSource, (Func<LuminanceSource, Binarizer>)null)
		{
		}

		public BarcodeReader(Reader reader, Func<T, LuminanceSource> createLuminanceSource, Func<LuminanceSource, Binarizer> createBinarizer)
			: this(reader, createLuminanceSource, createBinarizer, (Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource>)null)
		{
		}

		public BarcodeReader(Reader reader, Func<T, LuminanceSource> createLuminanceSource, Func<LuminanceSource, Binarizer> createBinarizer, Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> createRGBLuminanceSource)
			: base(reader, createBinarizer, createRGBLuminanceSource)
		{
			this.createLuminanceSource = createLuminanceSource;
		}

		protected BarcodeReader(Reader reader, Func<LuminanceSource, Binarizer> createBinarizer, Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> createRGBLuminanceSource)
			: base(reader, createBinarizer, createRGBLuminanceSource)
		{
		}

		public Result Decode(T barcodeBitmap)
		{
			if (CreateLuminanceSource == null)
			{
				throw new InvalidOperationException("You have to declare a luminance source delegate.");
			}
			if (barcodeBitmap == null)
			{
				throw new ArgumentNullException("barcodeBitmap");
			}
			LuminanceSource luminanceSource = CreateLuminanceSource(barcodeBitmap);
			return Decode(luminanceSource);
		}

		public Result[] DecodeMultiple(T barcodeBitmap)
		{
			if (CreateLuminanceSource == null)
			{
				throw new InvalidOperationException("You have to declare a luminance source delegate.");
			}
			if (barcodeBitmap == null)
			{
				throw new ArgumentNullException("barcodeBitmap");
			}
			LuminanceSource luminanceSource = CreateLuminanceSource(barcodeBitmap);
			return DecodeMultiple(luminanceSource);
		}
	}
	public class BarcodeReaderGeneric : IBarcodeReaderGeneric
	{
		private static readonly Func<LuminanceSource, Binarizer> defaultCreateBinarizer = (LuminanceSource luminanceSource) => new HybridBinarizer(luminanceSource);

		protected static readonly Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> defaultCreateRGBLuminanceSource = (byte[] rawBytes, int width, int height, RGBLuminanceSource.BitmapFormat format) => new RGBLuminanceSource(rawBytes, width, height, format);

		private Reader reader;

		private readonly Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> createRGBLuminanceSource;

		private readonly Func<LuminanceSource, Binarizer> createBinarizer;

		private bool usePreviousState;

		private DecodingOptions options;

		public DecodingOptions Options
		{
			get
			{
				if (options == null)
				{
					options = new DecodingOptions();
					options.ValueChanged += delegate
					{
						usePreviousState = false;
					};
				}
				return options;
			}
			set
			{
				if (value != null)
				{
					options = value;
					options.ValueChanged += delegate
					{
						usePreviousState = false;
					};
				}
				else
				{
					options = null;
				}
				usePreviousState = false;
			}
		}

		protected Reader Reader => reader ?? (reader = new MultiFormatReader());

		public bool AutoRotate { get; set; }

		public bool TryInverted { get; set; }

		protected Func<LuminanceSource, Binarizer> CreateBinarizer => createBinarizer ?? defaultCreateBinarizer;

		public event Action<ResultPoint> ResultPointFound
		{
			add
			{
				if (!Options.Hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK))
				{
					ResultPointCallback value2 = OnResultPointFound;
					Options.Hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK] = value2;
				}
				explicitResultPointFound += value;
				usePreviousState = false;
			}
			remove
			{
				explicitResultPointFound -= value;
				if (this.explicitResultPointFound == null)
				{
					Options.Hints.Remove(DecodeHintType.NEED_RESULT_POINT_CALLBACK);
				}
				usePreviousState = false;
			}
		}

		private event Action<ResultPoint> explicitResultPointFound;

		public event Action<Result> ResultFound;

		public BarcodeReaderGeneric()
			: this(new MultiFormatReader(), defaultCreateBinarizer, null)
		{
		}

		public BarcodeReaderGeneric(Reader reader, Func<LuminanceSource, Binarizer> createBinarizer, Func<byte[], int, int, RGBLuminanceSource.BitmapFormat, LuminanceSource> createRGBLuminanceSource)
		{
			this.reader = reader ?? new MultiFormatReader();
			this.createBinarizer = createBinarizer ?? defaultCreateBinarizer;
			this.createRGBLuminanceSource = createRGBLuminanceSource ?? defaultCreateRGBLuminanceSource;
			usePreviousState = false;
		}

		public virtual Result Decode(LuminanceSource luminanceSource)
		{
			Result result = null;
			BinaryBitmap image = new BinaryBitmap(CreateBinarizer(luminanceSource));
			MultiFormatReader multiFormatReader = Reader as MultiFormatReader;
			int i = 0;
			int num = 1;
			if (AutoRotate)
			{
				Options.Hints[DecodeHintType.TRY_HARDER_WITHOUT_ROTATION] = true;
				num = 4;
			}
			else if (Options.Hints.ContainsKey(DecodeHintType.TRY_HARDER_WITHOUT_ROTATION))
			{
				Options.Hints.Remove(DecodeHintType.TRY_HARDER_WITHOUT_ROTATION);
			}
			for (; i < num; i++)
			{
				if (usePreviousState && multiFormatReader != null)
				{
					result = multiFormatReader.decodeWithState(image);
				}
				else
				{
					result = Reader.decode(image, Options.Hints);
					usePreviousState = true;
				}
				if (result == null && TryInverted && luminanceSource.InversionSupported)
				{
					image = new BinaryBitmap(CreateBinarizer(luminanceSource.invert()));
					if (usePreviousState && multiFormatReader != null)
					{
						result = multiFormatReader.decodeWithState(image);
					}
					else
					{
						result = Reader.decode(image, Options.Hints);
						usePreviousState = true;
					}
				}
				if (result != null || !luminanceSource.RotateSupported || !AutoRotate)
				{
					break;
				}
				image = new BinaryBitmap(CreateBinarizer(luminanceSource.rotateCounterClockwise()));
			}
			if (result != null)
			{
				if (result.ResultMetadata == null)
				{
					result.putMetadata(ResultMetadataType.ORIENTATION, i * 90);
				}
				else if (!result.ResultMetadata.ContainsKey(ResultMetadataType.ORIENTATION))
				{
					result.ResultMetadata[ResultMetadataType.ORIENTATION] = i * 90;
				}
				else
				{
					result.ResultMetadata[ResultMetadataType.ORIENTATION] = ((int)result.ResultMetadata[ResultMetadataType.ORIENTATION] + i * 90) % 360;
				}
				OnResultFound(result);
			}
			return result;
		}

		public virtual Result[] DecodeMultiple(LuminanceSource luminanceSource)
		{
			Result[] array = null;
			BinaryBitmap image = new BinaryBitmap(CreateBinarizer(luminanceSource));
			int i = 0;
			int num = 1;
			MultipleBarcodeReader multipleBarcodeReader = null;
			if (AutoRotate)
			{
				Options.Hints[DecodeHintType.TRY_HARDER_WITHOUT_ROTATION] = true;
				num = 4;
			}
			IList<BarcodeFormat> possibleFormats = Options.PossibleFormats;
			multipleBarcodeReader = ((possibleFormats == null || possibleFormats.Count != 1 || !possibleFormats.Contains(BarcodeFormat.QR_CODE)) ? ((MultipleBarcodeReader)new GenericMultipleBarcodeReader(Reader)) : ((MultipleBarcodeReader)new QRCodeMultiReader()));
			for (; i < num; i++)
			{
				array = multipleBarcodeReader.decodeMultiple(image, Options.Hints);
				if (array == null && TryInverted && luminanceSource.InversionSupported)
				{
					image = new BinaryBitmap(CreateBinarizer(luminanceSource.invert()));
					array = multipleBarcodeReader.decodeMultiple(image, Options.Hints);
				}
				if (array != null || !luminanceSource.RotateSupported || !AutoRotate)
				{
					break;
				}
				image = new BinaryBitmap(CreateBinarizer(luminanceSource.rotateCounterClockwise()));
			}
			if (array != null)
			{
				Result[] array2 = array;
				foreach (Result result in array2)
				{
					if (result.ResultMetadata == null)
					{
						result.putMetadata(ResultMetadataType.ORIENTATION, i * 90);
					}
					else if (!result.ResultMetadata.ContainsKey(ResultMetadataType.ORIENTATION))
					{
						result.ResultMetadata[ResultMetadataType.ORIENTATION] = i * 90;
					}
					else
					{
						result.ResultMetadata[ResultMetadataType.ORIENTATION] = ((int)result.ResultMetadata[ResultMetadataType.ORIENTATION] + i * 90) % 360;
					}
				}
				OnResultsFound(array);
			}
			return array;
		}

		protected void OnResultsFound(IEnumerable<Result> results)
		{
			if (this.ResultFound == null)
			{
				return;
			}
			foreach (Result result in results)
			{
				this.ResultFound(result);
			}
		}

		protected void OnResultFound(Result result)
		{
			if (this.ResultFound != null)
			{
				this.ResultFound(result);
			}
		}

		protected void OnResultPointFound(ResultPoint resultPoint)
		{
			if (this.explicitResultPointFound != null)
			{
				this.explicitResultPointFound(resultPoint);
			}
		}

		public Result Decode(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format)
		{
			if (rawRGB == null)
			{
				throw new ArgumentNullException("rawRGB");
			}
			LuminanceSource luminanceSource = createRGBLuminanceSource(rawRGB, width, height, format);
			return Decode(luminanceSource);
		}

		public Result[] DecodeMultiple(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format)
		{
			if (rawRGB == null)
			{
				throw new ArgumentNullException("rawRGB");
			}
			LuminanceSource luminanceSource = createRGBLuminanceSource(rawRGB, width, height, format);
			return DecodeMultiple(luminanceSource);
		}
	}
	public class BarcodeWriterPixelData : BarcodeWriter<PixelData>, IBarcodeWriterPixelData
	{
		public BarcodeWriterPixelData()
		{
			base.Renderer = new PixelDataRenderer();
		}
	}
	public class BarcodeWriterSvg : BarcodeWriter<SvgRenderer.SvgImage>, IBarcodeWriterSvg
	{
		public BarcodeWriterSvg()
		{
			base.Renderer = new SvgRenderer();
		}
	}
	public class BarcodeWriter<TOutput> : BarcodeWriterGeneric, IBarcodeWriter<TOutput>
	{
		public IBarcodeRenderer<TOutput> Renderer { get; set; }

		public TOutput Write(string contents)
		{
			if (Renderer == null)
			{
				throw new InvalidOperationException("You have to set a renderer instance.");
			}
			BitMatrix matrix = Encode(contents);
			return Renderer.Render(matrix, base.Format, contents, base.Options);
		}

		public TOutput Write(BitMatrix matrix)
		{
			if (Renderer == null)
			{
				throw new InvalidOperationException("You have to set a renderer instance.");
			}
			return Renderer.Render(matrix, base.Format, null, base.Options);
		}
	}
	public class BarcodeWriterGeneric : IBarcodeWriterGeneric
	{
		private EncodingOptions options;

		public BarcodeFormat Format { get; set; }

		public EncodingOptions Options
		{
			get
			{
				EncodingOptions encodingOptions = options;
				if (encodingOptions == null)
				{
					EncodingOptions obj = new EncodingOptions
					{
						Height = 100,
						Width = 100
					};
					EncodingOptions encodingOptions2 = obj;
					options = obj;
					encodingOptions = encodingOptions2;
				}
				return encodingOptions;
			}
			set
			{
				options = value;
			}
		}

		public Writer Encoder { get; set; }

		public BarcodeWriterGeneric()
		{
		}

		public BarcodeWriterGeneric(Writer encoder)
		{
			Encoder = encoder;
		}

		public BitMatrix Encode(string contents)
		{
			Writer obj = Encoder ?? new MultiFormatWriter();
			EncodingOptions encodingOptions = Options;
			return obj.encode(contents, Format, encodingOptions.Width, encodingOptions.Height, encodingOptions.Hints);
		}
	}
	public abstract class BaseLuminanceSource : LuminanceSource
	{
		protected const int RChannelWeight = 19562;

		protected const int GChannelWeight = 38550;

		protected const int BChannelWeight = 7424;

		protected const int ChannelWeight = 16;

		protected byte[] luminances;

		public override byte[] Matrix => luminances;

		public override bool RotateSupported => true;

		public override bool CropSupported => true;

		public override bool InversionSupported => true;

		protected BaseLuminanceSource(int width, int height)
			: base(width, height)
		{
			luminances = new byte[width * height];
		}

		protected BaseLuminanceSource(byte[] luminanceArray, int width, int height)
			: base(width, height)
		{
			luminances = new byte[width * height];
			Buffer.BlockCopy(luminanceArray, 0, luminances, 0, width * height);
		}

		public override byte[] getRow(int y, byte[] row)
		{
			int num = Width;
			if (row == null || row.Length < num)
			{
				row = new byte[num];
			}
			for (int i = 0; i < num; i++)
			{
				row[i] = luminances[y * num + i];
			}
			return row;
		}

		public override LuminanceSource rotateCounterClockwise()
		{
			byte[] array = new byte[Width * Height];
			int num = Height;
			int num2 = Width;
			byte[] matrix = Matrix;
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					int num3 = num2 - j - 1;
					int num4 = i;
					array[num3 * num + num4] = matrix[i * Width + j];
				}
			}
			return CreateLuminanceSource(array, num, num2);
		}

		public override LuminanceSource rotateCounterClockwise45()
		{
			return base.rotateCounterClockwise45();
		}

		public override LuminanceSource crop(int left, int top, int width, int height)
		{
			if (left + width > Width || top + height > Height)
			{
				throw new ArgumentException("Crop rectangle does not fit within image data.");
			}
			byte[] array = new byte[width * height];
			byte[] matrix = Matrix;
			int num = Width;
			int num2 = left + width;
			int num3 = top + height;
			int num4 = top;
			int num5 = 0;
			while (num4 < num3)
			{
				int num6 = left;
				int num7 = 0;
				while (num6 < num2)
				{
					array[num5 * width + num7] = matrix[num4 * num + num6];
					num6++;
					num7++;
				}
				num4++;
				num5++;
			}
			return CreateLuminanceSource(array, width, height);
		}

		public override LuminanceSource invert()
		{
			return new InvertedLuminanceSource(this);
		}

		protected abstract LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height);
	}
	public abstract class Binarizer
	{
		private readonly LuminanceSource source;

		public virtual LuminanceSource LuminanceSource => source;

		public abstract BitMatrix BlackMatrix { get; }

		public int Width => source.Width;

		public int Height => source.Height;

		protected internal Binarizer(LuminanceSource source)
		{
			if (source == null)
			{
				throw new ArgumentException("Source must be non-null.");
			}
			this.source = source;
		}

		public abstract ZXing.Common.BitArray getBlackRow(int y, ZXing.Common.BitArray row);

		public abstract Binarizer createBinarizer(LuminanceSource source);
	}
	public sealed class BinaryBitmap
	{
		private readonly Binarizer binarizer;

		private BitMatrix matrix;

		public int Width => binarizer.Width;

		public int Height => binarizer.Height;

		public BitMatrix BlackMatrix => matrix ?? (matrix = binarizer.BlackMatrix);

		public bool CropSupported => binarizer.LuminanceSource.CropSupported;

		public bool RotateSupported => binarizer.LuminanceSource.RotateSupported;

		public BinaryBitmap(Binarizer binarizer)
		{
			if (binarizer == null)
			{
				throw new ArgumentException("Binarizer must be non-null.");
			}
			this.binarizer = binarizer;
		}

		internal BinaryBitmap(BitMatrix matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentException("matrix must be non-null.");
			}
			this.matrix = matrix;
		}

		public ZXing.Common.BitArray getBlackRow(int y, ZXing.Common.BitArray row)
		{
			return binarizer.getBlackRow(y, row);
		}

		public BinaryBitmap crop(int left, int top, int width, int height)
		{
			LuminanceSource source = binarizer.LuminanceSource.crop(left, top, width, height);
			return new BinaryBitmap(binarizer.createBinarizer(source));
		}

		public BinaryBitmap rotateCounterClockwise()
		{
			LuminanceSource source = binarizer.LuminanceSource.rotateCounterClockwise();
			return new BinaryBitmap(binarizer.createBinarizer(source));
		}

		public BinaryBitmap rotateCounterClockwise45()
		{
			LuminanceSource source = binarizer.LuminanceSource.rotateCounterClockwise45();
			return new BinaryBitmap(binarizer.createBinarizer(source));
		}

		public override string ToString()
		{
			BitMatrix blackMatrix = BlackMatrix;
			if (blackMatrix == null)
			{
				return string.Empty;
			}
			return blackMatrix.ToString();
		}
	}
	public enum DecodeHintType
	{
		OTHER,
		PURE_BARCODE,
		POSSIBLE_FORMATS,
		TRY_HARDER,
		CHARACTER_SET,
		ALLOWED_LENGTHS,
		ASSUME_CODE_39_CHECK_DIGIT,
		NEED_RESULT_POINT_CALLBACK,
		ASSUME_MSI_CHECK_DIGIT,
		USE_CODE_39_EXTENDED_MODE,
		RELAXED_CODE_39_EXTENDED_MODE,
		TRY_HARDER_WITHOUT_ROTATION,
		ASSUME_GS1,
		RETURN_CODABAR_START_END,
		ALLOWED_EAN_EXTENSIONS
	}
	public sealed class Dimension
	{
		private readonly int width;

		private readonly int height;

		public int Width => width;

		public int Height => height;

		public Dimension(int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new ArgumentException();
			}
			this.width = width;
			this.height = height;
		}

		public override bool Equals(object other)
		{
			if (other is Dimension)
			{
				Dimension dimension = (Dimension)other;
				if (width == dimension.width)
				{
					return height == dimension.height;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return width * 32713 + height;
		}

		public override string ToString()
		{
			return width + "x" + height;
		}
	}
	public enum EncodeHintType
	{
		WIDTH,
		HEIGHT,
		PURE_BARCODE,
		ERROR_CORRECTION,
		CHARACTER_SET,
		MARGIN,
		PDF417_ASPECT_RATIO,
		PDF417_COMPACT,
		PDF417_COMPACTION,
		PDF417_DIMENSIONS,
		DISABLE_ECI,
		DATA_MATRIX_SHAPE,
		MIN_SIZE,
		MAX_SIZE,
		CODE128_FORCE_CODESET_B,
		DATA_MATRIX_DEFAULT_ENCODATION,
		AZTEC_LAYERS,
		QR_VERSION,
		GS1_FORMAT
	}
	[Serializable]
	public sealed class FormatException : ReaderException
	{
		public FormatException()
		{
		}

		public FormatException(string message)
			: base(message)
		{
		}

		public FormatException(Exception innerException)
			: base(innerException)
		{
		}

		public FormatException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public interface IBarcodeReader
	{
		DecodingOptions Options { get; set; }

		event Action<ResultPoint> ResultPointFound;

		event Action<Result> ResultFound;

		Result Decode(byte[] barcodeBitmap);

		Result Decode(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format);

		Result Decode(LuminanceSource luminanceSource);

		Result[] DecodeMultiple(byte[] barcodeBitmap);

		Result[] DecodeMultiple(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format);

		Result[] DecodeMultiple(LuminanceSource luminanceSource);
	}
	public interface IBarcodeReader<T>
	{
		Result Decode(T barcodeBitmap);

		Result[] DecodeMultiple(T barcodeBitmap);
	}
	public interface IBarcodeReaderGeneric
	{
		DecodingOptions Options { get; set; }

		event Action<ResultPoint> ResultPointFound;

		event Action<Result> ResultFound;

		Result Decode(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format);

		Result Decode(LuminanceSource luminanceSource);

		Result[] DecodeMultiple(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format);

		Result[] DecodeMultiple(LuminanceSource luminanceSource);
	}
	public interface IBarcodeWriter
	{
		BarcodeFormat Format { get; set; }

		EncodingOptions Options { get; set; }

		Writer Encoder { get; set; }

		BitMatrix Encode(string contents);
	}
	public interface IBarcodeWriterPixelData
	{
		PixelData Write(string contents);

		PixelData Write(BitMatrix matrix);
	}
	public interface IBarcodeWriterSvg
	{
		SvgRenderer.SvgImage Write(string contents);

		SvgRenderer.SvgImage Write(BitMatrix matrix);
	}
	public interface IBarcodeWriter<out TOutput>
	{
		TOutput Write(string contents);

		TOutput Write(BitMatrix matrix);
	}
	public interface IBarcodeWriterGeneric
	{
		BarcodeFormat Format { get; set; }

		EncodingOptions Options { get; set; }

		Writer Encoder { get; set; }

		BitMatrix Encode(string contents);
	}
	public sealed class InvertedLuminanceSource : LuminanceSource
	{
		private readonly LuminanceSource @delegate;

		private byte[] invertedMatrix;

		public override byte[] Matrix
		{
			get
			{
				if (invertedMatrix == null)
				{
					byte[] matrix = @delegate.Matrix;
					int num = Width * Height;
					invertedMatrix = new byte[num];
					for (int i = 0; i < num; i++)
					{
						invertedMatrix[i] = (byte)(255 - (matrix[i] & 0xFF));
					}
				}
				return invertedMatrix;
			}
		}

		public override bool CropSupported => @delegate.CropSupported;

		public override bool RotateSupported => @delegate.RotateSupported;

		public InvertedLuminanceSource(LuminanceSource @delegate)
			: base(@delegate.Width, @delegate.Height)
		{
			this.@delegate = @delegate;
		}

		public override byte[] getRow(int y, byte[] row)
		{
			row = @delegate.getRow(y, row);
			int num = Width;
			for (int i = 0; i < num; i++)
			{
				row[i] = (byte)(255 - (row[i] & 0xFF));
			}
			return row;
		}

		public override LuminanceSource crop(int left, int top, int width, int height)
		{
			return new InvertedLuminanceSource(@delegate.crop(left, top, width, height));
		}

		public override LuminanceSource invert()
		{
			return @delegate;
		}

		public override LuminanceSource rotateCounterClockwise()
		{
			return new InvertedLuminanceSource(@delegate.rotateCounterClockwise());
		}

		public override LuminanceSource rotateCounterClockwise45()
		{
			return new InvertedLuminanceSource(@delegate.rotateCounterClockwise45());
		}
	}
	public abstract class LuminanceSource
	{
		private int width;

		private int height;

		public abstract byte[] Matrix { get; }

		public virtual int Width
		{
			get
			{
				return width;
			}
			protected set
			{
				width = value;
			}
		}

		public virtual int Height
		{
			get
			{
				return height;
			}
			protected set
			{
				height = value;
			}
		}

		public virtual bool CropSupported => false;

		public virtual bool RotateSupported => false;

		public virtual bool InversionSupported => false;

		protected LuminanceSource(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public abstract byte[] getRow(int y, byte[] row);

		public virtual LuminanceSource crop(int left, int top, int width, int height)
		{
			throw new NotSupportedException("This luminance source does not support cropping.");
		}

		public virtual LuminanceSource rotateCounterClockwise()
		{
			throw new NotSupportedException("This luminance source does not support rotation.");
		}

		public virtual LuminanceSource rotateCounterClockwise45()
		{
			throw new NotSupportedException("This luminance source does not support rotation by 45 degrees.");
		}

		public virtual LuminanceSource invert()
		{
			throw new NotSupportedException("This luminance source does not support inversion.");
		}

		public override string ToString()
		{
			byte[] array = new byte[width];
			StringBuilder stringBuilder = new StringBuilder(height * (width + 1));
			for (int i = 0; i < height; i++)
			{
				array = getRow(i, array);
				for (int j = 0; j < width; j++)
				{
					int num = array[j] & 0xFF;
					char value = ((num >= 64) ? ((num >= 128) ? ((num >= 192) ? ' ' : '.') : '+') : '#');
					stringBuilder.Append(value);
				}
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class MultiFormatReader : Reader
	{
		private IDictionary<DecodeHintType, object> hints;

		private IList<Reader> readers;

		public IDictionary<DecodeHintType, object> Hints
		{
			set
			{
				hints = value;
				bool flag = value?.ContainsKey(DecodeHintType.TRY_HARDER) ?? false;
				IList<BarcodeFormat> list = ((value == null || !value.ContainsKey(DecodeHintType.POSSIBLE_FORMATS)) ? null : ((IList<BarcodeFormat>)value[DecodeHintType.POSSIBLE_FORMATS]));
				if (list != null)
				{
					bool num = list.Contains(BarcodeFormat.All_1D) || list.Contains(BarcodeFormat.UPC_A) || list.Contains(BarcodeFormat.UPC_E) || list.Contains(BarcodeFormat.EAN_13) || list.Contains(BarcodeFormat.EAN_8) || list.Contains(BarcodeFormat.CODABAR) || list.Contains(BarcodeFormat.CODE_39) || list.Contains(BarcodeFormat.CODE_93) || list.Contains(BarcodeFormat.CODE_128) || list.Contains(BarcodeFormat.ITF) || list.Contains(BarcodeFormat.RSS_14) || list.Contains(BarcodeFormat.RSS_EXPANDED);
					readers = new List<Reader>();
					if (num && !flag)
					{
						readers.Add(new MultiFormatOneDReader(value));
					}
					if (list.Contains(BarcodeFormat.QR_CODE))
					{
						readers.Add(new QRCodeReader());
					}
					if (list.Contains(BarcodeFormat.DATA_MATRIX))
					{
						readers.Add(new DataMatrixReader());
					}
					if (list.Contains(BarcodeFormat.AZTEC))
					{
						readers.Add(new AztecReader());
					}
					if (list.Contains(BarcodeFormat.PDF_417))
					{
						readers.Add(new PDF417Reader());
					}
					if (list.Contains(BarcodeFormat.MAXICODE))
					{
						readers.Add(new MaxiCodeReader());
					}
					if (list.Contains(BarcodeFormat.IMB))
					{
						readers.Add(new IMBReader());
					}
					if (num && flag)
					{
						readers.Add(new MultiFormatOneDReader(value));
					}
				}
				if (readers == null || readers.Count == 0)
				{
					readers = readers ?? new List<Reader>();
					if (!flag)
					{
						readers.Add(new MultiFormatOneDReader(value));
					}
					readers.Add(new QRCodeReader());
					readers.Add(new DataMatrixReader());
					readers.Add(new AztecReader());
					readers.Add(new PDF417Reader());
					readers.Add(new MaxiCodeReader());
					if (flag)
					{
						readers.Add(new MultiFormatOneDReader(value));
					}
				}
			}
		}

		public Result decode(BinaryBitmap image)
		{
			Hints = null;
			return decodeInternal(image);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			Hints = hints;
			return decodeInternal(image);
		}

		public Result decodeWithState(BinaryBitmap image)
		{
			if (readers == null)
			{
				Hints = null;
			}
			return decodeInternal(image);
		}

		public void reset()
		{
			if (readers == null)
			{
				return;
			}
			foreach (Reader reader in readers)
			{
				reader.reset();
			}
		}

		private Result decodeInternal(BinaryBitmap image)
		{
			if (readers != null)
			{
				ResultPointCallback resultPointCallback = ((hints != null && hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]) : null);
				for (int i = 0; i < readers.Count; i++)
				{
					Reader reader = readers[i];
					reader.reset();
					Result result = reader.decode(image, hints);
					if (result != null)
					{
						readers.RemoveAt(i);
						readers.Insert(0, reader);
						return result;
					}
					resultPointCallback?.Invoke(null);
				}
			}
			return null;
		}
	}
	public sealed class MultiFormatWriter : Writer
	{
		private static readonly IDictionary<BarcodeFormat, Func<Writer>> formatMap;

		public static ICollection<BarcodeFormat> SupportedWriters => formatMap.Keys;

		static MultiFormatWriter()
		{
			formatMap = new Dictionary<BarcodeFormat, Func<Writer>>
			{
				{
					BarcodeFormat.EAN_8,
					() => new EAN8Writer()
				},
				{
					BarcodeFormat.UPC_E,
					() => new UPCEWriter()
				},
				{
					BarcodeFormat.EAN_13,
					() => new EAN13Writer()
				},
				{
					BarcodeFormat.UPC_A,
					() => new UPCAWriter()
				},
				{
					BarcodeFormat.QR_CODE,
					() => new QRCodeWriter()
				},
				{
					BarcodeFormat.CODE_39,
					() => new Code39Writer()
				},
				{
					BarcodeFormat.CODE_93,
					() => new Code93Writer()
				},
				{
					BarcodeFormat.CODE_128,
					() => new Code128Writer()
				},
				{
					BarcodeFormat.ITF,
					() => new ITFWriter()
				},
				{
					BarcodeFormat.PDF_417,
					() => new PDF417Writer()
				},
				{
					BarcodeFormat.CODABAR,
					() => new CodaBarWriter()
				},
				{
					BarcodeFormat.MSI,
					() => new MSIWriter()
				},
				{
					BarcodeFormat.PLESSEY,
					() => new PlesseyWriter()
				},
				{
					BarcodeFormat.DATA_MATRIX,
					() => new DataMatrixWriter()
				},
				{
					BarcodeFormat.AZTEC,
					() => new AztecWriter()
				}
			};
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (!formatMap.ContainsKey(format))
			{
				throw new ArgumentException("No encoder available for format " + format);
			}
			return formatMap[format]().encode(contents, format, width, height, hints);
		}
	}
	public sealed class PlanarYUVLuminanceSource : BaseLuminanceSource
	{
		private const int THUMBNAIL_SCALE_FACTOR = 2;

		private readonly byte[] yuvData;

		private readonly int dataWidth;

		private readonly int dataHeight;

		private readonly int left;

		private readonly int top;

		public override byte[] Matrix
		{
			get
			{
				int num = Width;
				int num2 = Height;
				if (num == dataWidth && num2 == dataHeight)
				{
					return yuvData;
				}
				int num3 = num * num2;
				byte[] array = new byte[num3];
				int num4 = top * dataWidth + left;
				if (num == dataWidth)
				{
					Array.Copy(yuvData, num4, array, 0, num3);
					return array;
				}
				_ = yuvData;
				for (int i = 0; i < num2; i++)
				{
					int destinationIndex = i * num;
					Array.Copy(yuvData, num4, array, destinationIndex, num);
					num4 += dataWidth;
				}
				return array;
			}
		}

		public override bool CropSupported => true;

		public int ThumbnailWidth => Width / 2;

		public int ThumbnailHeight => Height / 2;

		public PlanarYUVLuminanceSource(byte[] yuvData, int dataWidth, int dataHeight, int left, int top, int width, int height, bool reverseHoriz)
			: base(width, height)
		{
			if (left + width > dataWidth || top + height > dataHeight)
			{
				throw new ArgumentException("Crop rectangle does not fit within image data.");
			}
			this.yuvData = yuvData;
			this.dataWidth = dataWidth;
			this.dataHeight = dataHeight;
			this.left = left;
			this.top = top;
			if (reverseHoriz)
			{
				reverseHorizontal(width, height);
			}
		}

		private PlanarYUVLuminanceSource(byte[] luminances, int width, int height)
			: base(width, height)
		{
			yuvData = luminances;
			base.luminances = luminances;
			dataWidth = width;
			dataHeight = height;
			left = 0;
			top = 0;
		}

		public override byte[] getRow(int y, byte[] row)
		{
			if (y < 0 || y >= Height)
			{
				throw new ArgumentException("Requested row is outside the image: " + y);
			}
			int num = Width;
			if (row == null || row.Length < num)
			{
				row = new byte[num];
			}
			int sourceIndex = (y + top) * dataWidth + left;
			Array.Copy(yuvData, sourceIndex, row, 0, num);
			return row;
		}

		public override LuminanceSource crop(int left, int top, int width, int height)
		{
			return new PlanarYUVLuminanceSource(yuvData, dataWidth, dataHeight, this.left + left, this.top + top, width, height, reverseHoriz: false);
		}

		public int[] renderThumbnail()
		{
			int num = Width / 2;
			int num2 = Height / 2;
			int[] array = new int[num * num2];
			byte[] array2 = yuvData;
			int num3 = top * dataWidth + left;
			for (int i = 0; i < num2; i++)
			{
				int num4 = i * num;
				for (int j = 0; j < num; j++)
				{
					int num5 = array2[num3 + j * 2] & 0xFF;
					array[num4 + j] = -16777216 | (num5 * 65793);
				}
				num3 += dataWidth * 2;
			}
			return array;
		}

		private void reverseHorizontal(int width, int height)
		{
			byte[] array = yuvData;
			int num = 0;
			int num2 = top * dataWidth + left;
			while (num < height)
			{
				int num3 = num2 + width / 2;
				int num4 = num2;
				int num5 = num2 + width - 1;
				while (num4 < num3)
				{
					byte b = array[num4];
					array[num4] = array[num5];
					array[num5] = b;
					num4++;
					num5--;
				}
				num++;
				num2 += dataWidth;
			}
		}

		protected override LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height)
		{
			return new PlanarYUVLuminanceSource(newLuminances, width, height);
		}
	}
	public interface Reader
	{
		Result decode(BinaryBitmap image);

		Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints);

		void reset();
	}
	[Serializable]
	public class ReaderException : Exception
	{
		public ReaderException()
		{
		}

		public ReaderException(string message)
			: base(message)
		{
		}

		public ReaderException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public ReaderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public sealed class Result
	{
		public string Text { get; private set; }

		public byte[] RawBytes { get; private set; }

		public ResultPoint[] ResultPoints { get; private set; }

		public BarcodeFormat BarcodeFormat { get; private set; }

		public IDictionary<ResultMetadataType, object> ResultMetadata { get; private set; }

		public long Timestamp { get; private set; }

		public int NumBits { get; private set; }

		public Result(string text, byte[] rawBytes, ResultPoint[] resultPoints, BarcodeFormat format)
			: this(text, rawBytes, (rawBytes != null) ? (8 * rawBytes.Length) : 0, resultPoints, format, DateTime.Now.Ticks)
		{
		}

		public Result(string text, byte[] rawBytes, int numBits, ResultPoint[] resultPoints, BarcodeFormat format)
			: this(text, rawBytes, numBits, resultPoints, format, DateTime.Now.Ticks)
		{
		}

		public Result(string text, byte[] rawBytes, ResultPoint[] resultPoints, BarcodeFormat format, long timestamp)
			: this(text, rawBytes, (rawBytes != null) ? (8 * rawBytes.Length) : 0, resultPoints, format, timestamp)
		{
		}

		public Result(string text, byte[] rawBytes, int numBits, ResultPoint[] resultPoints, BarcodeFormat format, long timestamp)
		{
			if (text == null && rawBytes == null)
			{
				throw new ArgumentException("Text and bytes are null");
			}
			Text = text;
			RawBytes = rawBytes;
			NumBits = numBits;
			ResultPoints = resultPoints;
			BarcodeFormat = format;
			ResultMetadata = null;
			Timestamp = timestamp;
		}

		public void putMetadata(ResultMetadataType type, object value)
		{
			if (ResultMetadata == null)
			{
				ResultMetadata = new Dictionary<ResultMetadataType, object>();
			}
			ResultMetadata[type] = value;
		}

		public void putAllMetadata(IDictionary<ResultMetadataType, object> metadata)
		{
			if (metadata == null)
			{
				return;
			}
			if (ResultMetadata == null)
			{
				ResultMetadata = metadata;
				return;
			}
			foreach (KeyValuePair<ResultMetadataType, object> item in metadata)
			{
				ResultMetadata[item.Key] = item.Value;
			}
		}

		public void addResultPoints(ResultPoint[] newPoints)
		{
			ResultPoint[] resultPoints = ResultPoints;
			if (resultPoints == null)
			{
				ResultPoints = newPoints;
			}
			else if (newPoints != null && newPoints.Length != 0)
			{
				ResultPoint[] array = new ResultPoint[resultPoints.Length + newPoints.Length];
				Array.Copy(resultPoints, 0, array, 0, resultPoints.Length);
				Array.Copy(newPoints, 0, array, resultPoints.Length, newPoints.Length);
				ResultPoints = array;
			}
		}

		public override string ToString()
		{
			if (Text == null)
			{
				return "[" + RawBytes.Length + " bytes]";
			}
			return Text;
		}
	}
	public enum ResultMetadataType
	{
		OTHER,
		ORIENTATION,
		BYTE_SEGMENTS,
		ERROR_CORRECTION_LEVEL,
		ISSUE_NUMBER,
		SUGGESTED_PRICE,
		POSSIBLE_COUNTRY,
		UPC_EAN_EXTENSION,
		STRUCTURED_APPEND_SEQUENCE,
		STRUCTURED_APPEND_PARITY,
		PDF417_EXTRA_METADATA,
		AZTEC_EXTRA_METADATA
	}
	public class ResultPoint
	{
		private readonly float x;

		private readonly float y;

		private readonly byte[] bytesX;

		private readonly byte[] bytesY;

		private string toString;

		public virtual float X => x;

		public virtual float Y => y;

		public ResultPoint()
		{
		}

		public ResultPoint(float x, float y)
		{
			this.x = x;
			this.y = y;
			bytesX = BitConverter.GetBytes(x);
			bytesY = BitConverter.GetBytes(y);
		}

		public override bool Equals(object other)
		{
			if (!(other is ResultPoint resultPoint))
			{
				return false;
			}
			if (x == resultPoint.x)
			{
				return y == resultPoint.y;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return 31 * ((bytesX[0] << 24) + (bytesX[1] << 16) + (bytesX[2] << 8) + bytesX[3]) + (bytesY[0] << 24) + (bytesY[1] << 16) + (bytesY[2] << 8) + bytesY[3];
		}

		public override string ToString()
		{
			if (toString == null)
			{
				StringBuilder stringBuilder = new StringBuilder(25);
				stringBuilder.AppendFormat(CultureInfo.CurrentUICulture, "({0}, {1})", new object[2] { x, y });
				toString = stringBuilder.ToString();
			}
			return toString;
		}

		public static void orderBestPatterns(ResultPoint[] patterns)
		{
			float num = distance(patterns[0], patterns[1]);
			float num2 = distance(patterns[1], patterns[2]);
			float num3 = distance(patterns[0], patterns[2]);
			ResultPoint resultPoint;
			ResultPoint resultPoint2;
			ResultPoint resultPoint3;
			if (num2 >= num && num2 >= num3)
			{
				resultPoint = patterns[0];
				resultPoint2 = patterns[1];
				resultPoint3 = patterns[2];
			}
			else if (num3 >= num2 && num3 >= num)
			{
				resultPoint = patterns[1];
				resultPoint2 = patterns[0];
				resultPoint3 = patterns[2];
			}
			else
			{
				resultPoint = patterns[2];
				resultPoint2 = patterns[0];
				resultPoint3 = patterns[1];
			}
			if (crossProductZ(resultPoint2, resultPoint, resultPoint3) < 0f)
			{
				ResultPoint resultPoint4 = resultPoint2;
				resultPoint2 = resultPoint3;
				resultPoint3 = resultPoint4;
			}
			patterns[0] = resultPoint2;
			patterns[1] = resultPoint;
			patterns[2] = resultPoint3;
		}

		public static float distance(ResultPoint pattern1, ResultPoint pattern2)
		{
			return MathUtils.distance(pattern1.x, pattern1.y, pattern2.x, pattern2.y);
		}

		private static float crossProductZ(ResultPoint pointA, ResultPoint pointB, ResultPoint pointC)
		{
			float num = pointB.x;
			float num2 = pointB.y;
			return (pointC.x - num) * (pointA.y - num2) - (pointC.y - num2) * (pointA.x - num);
		}
	}
	public delegate void ResultPointCallback(ResultPoint point);
	public class RGBLuminanceSource : BaseLuminanceSource
	{
		public enum BitmapFormat
		{
			Unknown,
			Gray8,
			Gray16,
			RGB24,
			RGB32,
			ARGB32,
			BGR24,
			BGR32,
			BGRA32,
			RGB565,
			RGBA32,
			UYVY,
			YUYV
		}

		protected RGBLuminanceSource(int width, int height)
			: base(width, height)
		{
		}

		public RGBLuminanceSource(byte[] rgbRawBytes, int width, int height)
			: this(rgbRawBytes, width, height, BitmapFormat.RGB24)
		{
		}

		[Obsolete("Use RGBLuminanceSource(luminanceArray, width, height, BitmapFormat.Gray8)")]
		public RGBLuminanceSource(byte[] luminanceArray, int width, int height, bool is8Bit)
			: this(luminanceArray, width, height, BitmapFormat.Gray8)
		{
		}

		public RGBLuminanceSource(byte[] rgbRawBytes, int width, int height, BitmapFormat bitmapFormat)
			: base(width, height)
		{
			CalculateLuminance(rgbRawBytes, bitmapFormat);
		}

		protected override LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height)
		{
			return new RGBLuminanceSource(width, height)
			{
				luminances = newLuminances
			};
		}

		private static BitmapFormat DetermineBitmapFormat(byte[] rgbRawBytes, int width, int height)
		{
			int num = width * height;
			return (rgbRawBytes.Length / num) switch
			{
				1 => BitmapFormat.Gray8, 
				2 => BitmapFormat.RGB565, 
				3 => BitmapFormat.RGB24, 
				4 => BitmapFormat.RGB32, 
				_ => throw new ArgumentException("The bitmap format could not be determined. Please specify the correct value."), 
			};
		}

		protected void CalculateLuminance(byte[] rgbRawBytes, BitmapFormat bitmapFormat)
		{
			if (bitmapFormat == BitmapFormat.Unknown)
			{
				bitmapFormat = DetermineBitmapFormat(rgbRawBytes, Width, Height);
			}
			switch (bitmapFormat)
			{
			case BitmapFormat.Gray8:
				Buffer.BlockCopy(rgbRawBytes, 0, luminances, 0, (rgbRawBytes.Length < luminances.Length) ? rgbRawBytes.Length : luminances.Length);
				break;
			case BitmapFormat.Gray16:
				CalculateLuminanceGray16(rgbRawBytes);
				break;
			case BitmapFormat.RGB24:
				CalculateLuminanceRGB24(rgbRawBytes);
				break;
			case BitmapFormat.BGR24:
				CalculateLuminanceBGR24(rgbRawBytes);
				break;
			case BitmapFormat.RGB32:
				CalculateLuminanceRGB32(rgbRawBytes);
				break;
			case BitmapFormat.BGR32:
				CalculateLuminanceBGR32(rgbRawBytes);
				break;
			case BitmapFormat.RGBA32:
				CalculateLuminanceRGBA32(rgbRawBytes);
				break;
			case BitmapFormat.ARGB32:
				CalculateLuminanceARGB32(rgbRawBytes);
				break;
			case BitmapFormat.BGRA32:
				CalculateLuminanceBGRA32(rgbRawBytes);
				break;
			case BitmapFormat.RGB565:
				CalculateLuminanceRGB565(rgbRawBytes);
				break;
			case BitmapFormat.UYVY:
				CalculateLuminanceUYVY(rgbRawBytes);
				break;
			case BitmapFormat.YUYV:
				CalculateLuminanceYUYV(rgbRawBytes);
				break;
			default:
				throw new ArgumentException("The bitmap format isn't supported.", bitmapFormat.ToString());
			}
		}

		private void CalculateLuminanceRGB565(byte[] rgb565RawData)
		{
			int num = 0;
			int num2 = 0;
			while (num2 < rgb565RawData.Length && num < luminances.Length)
			{
				byte num3 = rgb565RawData[num2];
				byte b = rgb565RawData[num2 + 1];
				int num4 = num3 & 0x1F;
				int num5 = (((num3 & 0xE0) >> 5) | ((b & 3) << 3)) & 0x1F;
				int num6 = ((b >> 2) & 0x1F) * 527 + 23 >> 6;
				int num7 = num5 * 527 + 23 >> 6;
				int num8 = num4 * 527 + 23 >> 6;
				luminances[num] = (byte)(19562 * num6 + 38550 * num7 + 7424 * num8 >> 16);
				num2 += 2;
				num++;
			}
		}

		private void CalculateLuminanceRGB24(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				int num3 = rgbRawBytes[num++];
				int num4 = rgbRawBytes[num++];
				int num5 = rgbRawBytes[num++];
				luminances[num2] = (byte)(19562 * num3 + 38550 * num4 + 7424 * num5 >> 16);
				num2++;
			}
		}

		private void CalculateLuminanceBGR24(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				int num3 = rgbRawBytes[num++];
				int num4 = rgbRawBytes[num++];
				int num5 = rgbRawBytes[num++];
				luminances[num2] = (byte)(19562 * num5 + 38550 * num4 + 7424 * num3 >> 16);
				num2++;
			}
		}

		private void CalculateLuminanceRGB32(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				int num3 = rgbRawBytes[num++];
				int num4 = rgbRawBytes[num++];
				int num5 = rgbRawBytes[num++];
				num++;
				luminances[num2] = (byte)(19562 * num3 + 38550 * num4 + 7424 * num5 >> 16);
				num2++;
			}
		}

		private void CalculateLuminanceBGR32(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				int num3 = rgbRawBytes[num++];
				int num4 = rgbRawBytes[num++];
				int num5 = rgbRawBytes[num++];
				num++;
				luminances[num2] = (byte)(19562 * num5 + 38550 * num4 + 7424 * num3 >> 16);
				num2++;
			}
		}

		private void CalculateLuminanceBGRA32(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				byte b = rgbRawBytes[num++];
				byte b2 = rgbRawBytes[num++];
				byte b3 = rgbRawBytes[num++];
				byte b4 = rgbRawBytes[num++];
				byte b5 = (byte)(19562 * b3 + 38550 * b2 + 7424 * b >> 16);
				luminances[num2] = (byte)((b5 * b4 >> 8) + (255 * (255 - b4) >> 8));
				num2++;
			}
		}

		private void CalculateLuminanceRGBA32(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				byte b = rgbRawBytes[num++];
				byte b2 = rgbRawBytes[num++];
				byte b3 = rgbRawBytes[num++];
				byte b4 = rgbRawBytes[num++];
				byte b5 = (byte)(19562 * b + 38550 * b2 + 7424 * b3 >> 16);
				luminances[num2] = (byte)((b5 * b4 >> 8) + (255 * (255 - b4) >> 8));
				num2++;
			}
		}

		private void CalculateLuminanceARGB32(byte[] rgbRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < rgbRawBytes.Length && num2 < luminances.Length)
			{
				byte b = rgbRawBytes[num++];
				byte b2 = rgbRawBytes[num++];
				byte b3 = rgbRawBytes[num++];
				byte b4 = rgbRawBytes[num++];
				byte b5 = (byte)(19562 * b2 + 38550 * b3 + 7424 * b4 >> 16);
				luminances[num2] = (byte)((b5 * b >> 8) + (255 * (255 - b) >> 8));
				num2++;
			}
		}

		private void CalculateLuminanceUYVY(byte[] uyvyRawBytes)
		{
			int num = 1;
			int num2 = 0;
			while (num < uyvyRawBytes.Length - 3 && num2 < luminances.Length)
			{
				byte b = uyvyRawBytes[num];
				num += 2;
				byte b2 = uyvyRawBytes[num];
				num += 2;
				luminances[num2++] = b;
				luminances[num2++] = b2;
			}
		}

		private void CalculateLuminanceYUYV(byte[] yuyvRawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < yuyvRawBytes.Length - 3 && num2 < luminances.Length)
			{
				byte b = yuyvRawBytes[num];
				num += 2;
				byte b2 = yuyvRawBytes[num];
				num += 2;
				luminances[num2++] = b;
				luminances[num2++] = b2;
			}
		}

		private void CalculateLuminanceGray16(byte[] gray16RawBytes)
		{
			int num = 0;
			int num2 = 0;
			while (num < gray16RawBytes.Length && num2 < luminances.Length)
			{
				byte b = gray16RawBytes[num];
				luminances[num2] = b;
				num += 2;
				num2++;
			}
		}
	}
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	internal class NonSerializedAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
	internal class SerializableAttribute : Attribute
	{
	}
	public static class SupportClass
	{
		public static void GetCharsFromString(string sourceString, int sourceStart, int sourceEnd, char[] destinationArray, int destinationStart)
		{
			int num = sourceStart;
			int num2 = destinationStart;
			while (num < sourceEnd)
			{
				destinationArray[num2] = sourceString[num];
				num++;
				num2++;
			}
		}

		public static void SetCapacity<T>(IList<T> vector, int newCapacity) where T : new()
		{
			while (newCapacity > vector.Count)
			{
				vector.Add(new T());
			}
			while (newCapacity < vector.Count)
			{
				vector.RemoveAt(vector.Count - 1);
			}
		}

		public static string[] toStringArray(ICollection<string> strings)
		{
			string[] array = new string[strings.Count];
			strings.CopyTo(array, 0);
			return array;
		}

		public static string Join<T>(string separator, IEnumerable<T> values)
		{
			StringBuilder stringBuilder = new StringBuilder();
			separator = separator ?? string.Empty;
			if (values != null)
			{
				foreach (T value in values)
				{
					stringBuilder.Append(value);
					stringBuilder.Append(separator);
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Length -= separator.Length;
				}
			}
			return stringBuilder.ToString();
		}

		public static void Fill<T>(T[] array, T value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		public static void Fill<T>(T[] array, int startIndex, int endIndex, T value)
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				array[i] = value;
			}
		}

		public static string ToBinaryString(int x)
		{
			char[] array = new char[32];
			int length = 0;
			while (x != 0)
			{
				array[length++] = (((x & 1) == 1) ? '1' : '0');
				x >>= 1;
			}
			Array.Reverse((Array)array, 0, length);
			return new string(array);
		}

		public static int bitCount(int n)
		{
			int num = 0;
			while (n != 0)
			{
				n &= n - 1;
				num++;
			}
			return num;
		}

		public static T GetValue<T>(IDictionary<DecodeHintType, object> hints, DecodeHintType hintType, T @default)
		{
			if (hints == null)
			{
				return @default;
			}
			if (!hints.ContainsKey(hintType))
			{
				return @default;
			}
			return (T)hints[hintType];
		}
	}
	public interface Writer
	{
		BitMatrix encode(string contents, BarcodeFormat format, int width, int height);

		BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints);
	}
	[Serializable]
	public sealed class WriterException : Exception
	{
		public WriterException()
		{
		}

		public WriterException(string message)
			: base(message)
		{
		}

		public WriterException(string message, Exception innerExc)
			: base(message, innerExc)
		{
		}
	}
}
namespace ZXing.Rendering
{
	public interface IBarcodeRenderer<out TOutput>
	{
		TOutput Render(BitMatrix matrix, BarcodeFormat format, string content);

		TOutput Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options);
	}
	public sealed class PixelData
	{
		public byte[] Pixels { get; private set; }

		public int Width { get; private set; }

		public int Height { get; private set; }

		internal PixelData(int width, int height, byte[] pixels)
		{
			Height = height;
			Width = width;
			Pixels = pixels;
		}
	}
	public sealed class PixelDataRenderer : IBarcodeRenderer<PixelData>
	{
		public struct Color(int color)
		{
			public static Color Black = new Color(-16777216);

			public static Color White = new Color(-1);

			public byte A = (byte)((color & 0xFF000000u) >> 24);

			public byte R = (byte)((color & 0xFF0000) >> 16);

			public byte G = (byte)((color & 0xFF00) >> 8);

			public byte B = (byte)(color & 0xFF);
		}

		[CLSCompliant(false)]
		public Color Foreground { get; set; }

		[CLSCompliant(false)]
		public Color Background { get; set; }

		public PixelDataRenderer()
		{
			Foreground = Color.Black;
			Background = Color.White;
		}

		public PixelData Render(BitMatrix matrix, BarcodeFormat format, string content)
		{
			return Render(matrix, format, content, null);
		}

		public PixelData Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
		{
			int width = matrix.Width;
			int height = matrix.Height;
			int num = (((options == null || !options.PureBarcode) && !string.IsNullOrEmpty(content) && (format == BarcodeFormat.CODE_39 || format == BarcodeFormat.CODE_128 || format == BarcodeFormat.EAN_13 || format == BarcodeFormat.EAN_8 || format == BarcodeFormat.CODABAR || format == BarcodeFormat.ITF || format == BarcodeFormat.UPC_A || format == BarcodeFormat.MSI || format == BarcodeFormat.PLESSEY)) ? 16 : 0);
			int num2 = 1;
			if (options != null)
			{
				if (options.Width > width)
				{
					width = options.Width;
				}
				if (options.Height > height)
				{
					height = options.Height;
				}
				num2 = width / matrix.Width;
				if (num2 > height / matrix.Height)
				{
					num2 = height / matrix.Height;
				}
			}
			if (num < height)
			{
				num = 0;
			}
			byte[] array = new byte[width * height * 4];
			int num3 = 0;
			for (int i = 0; i < matrix.Height - num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					for (int k = 0; k < matrix.Width; k++)
					{
						Color color = (matrix[k, i] ? Foreground : Background);
						for (int l = 0; l < num2; l++)
						{
							array[num3++] = color.B;
							array[num3++] = color.G;
							array[num3++] = color.R;
							array[num3++] = color.A;
						}
					}
					for (int m = num2 * matrix.Width; m < width; m++)
					{
						array[num3++] = Background.B;
						array[num3++] = Background.G;
						array[num3++] = Background.R;
						array[num3++] = Background.A;
					}
				}
			}
			for (int n = matrix.Height * num2 - num; n < height; n++)
			{
				for (int num4 = 0; num4 < width; num4++)
				{
					array[num3++] = Background.B;
					array[num3++] = Background.G;
					array[num3++] = Background.R;
					array[num3++] = Background.A;
				}
			}
			return new PixelData(width, height, array);
		}
	}
	[Obsolete("please use PixelDataRenderer instead")]
	public class RawRenderer : IBarcodeRenderer<byte[]>
	{
		public struct Color(int color)
		{
			public static Color Black = new Color(0);

			public static Color White = new Color(16777215);

			public byte A = (byte)((color & 0xFF000000u) >> 24);

			public byte R = (byte)((color & 0xFF0000) >> 16);

			public byte G = (byte)((color & 0xFF00) >> 8);

			public byte B = (byte)(color & 0xFF);
		}

		public Color Foreground { get; set; }

		public Color Background { get; set; }

		public RawRenderer()
		{
			Foreground = Color.Black;
			Background = Color.White;
		}

		public byte[] Render(BitMatrix matrix, BarcodeFormat format, string content)
		{
			return Render(matrix, format, content, null);
		}

		public virtual byte[] Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
		{
			int width = matrix.Width;
			int height = matrix.Height;
			int num = (((options == null || !options.PureBarcode) && !string.IsNullOrEmpty(content) && (format == BarcodeFormat.CODE_39 || format == BarcodeFormat.CODE_128 || format == BarcodeFormat.EAN_13 || format == BarcodeFormat.EAN_8 || format == BarcodeFormat.CODABAR || format == BarcodeFormat.ITF || format == BarcodeFormat.UPC_A || format == BarcodeFormat.MSI || format == BarcodeFormat.PLESSEY)) ? 16 : 0);
			int num2 = 1;
			if (options != null)
			{
				if (options.Width > width)
				{
					width = options.Width;
				}
				if (options.Height > height)
				{
					height = options.Height;
				}
				num2 = width / matrix.Width;
				if (num2 > height / matrix.Height)
				{
					num2 = height / matrix.Height;
				}
			}
			byte[] array = new byte[width * height * 4];
			int num3 = 0;
			for (int i = 0; i < matrix.Height - num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					for (int k = 0; k < matrix.Width; k++)
					{
						Color color = (matrix[k, i] ? Foreground : Background);
						for (int l = 0; l < num2; l++)
						{
							array[num3++] = color.A;
							array[num3++] = color.R;
							array[num3++] = color.G;
							array[num3++] = color.B;
						}
					}
					for (int m = num2 * matrix.Width; m < width; m++)
					{
						array[num3++] = Background.A;
						array[num3++] = Background.R;
						array[num3++] = Background.G;
						array[num3++] = Background.B;
					}
				}
			}
			for (int n = matrix.Height * num2 - num; n < height; n++)
			{
				for (int num4 = 0; num4 < width; num4++)
				{
					array[num3++] = Background.A;
					array[num3++] = Background.R;
					array[num3++] = Background.G;
					array[num3++] = Background.B;
				}
			}
			return array;
		}
	}
	public class SvgRenderer : IBarcodeRenderer<SvgRenderer.SvgImage>
	{
		public struct Color
		{
			public static Color Black;

			public static Color White;

			public byte A;

			public byte R;

			public byte G;

			public byte B;

			public Color(int color)
			{
				A = (byte)((color & 0xFF000000u) >> 24);
				R = (byte)((color & 0xFF0000) >> 16);
				G = (byte)((color & 0xFF00) >> 8);
				B = (byte)(color & 0xFF);
			}

			public Color(byte alpha, byte red, byte green, byte blue)
			{
				A = alpha;
				R = red;
				G = green;
				B = blue;
			}

			static Color()
			{
				Black = new Color(255, 0, 0, 0);
				White = new Color(255, 255, 255, 255);
			}
		}

		public class SvgImage
		{
			private readonly StringBuilder content;

			public string Content
			{
				get
				{
					return content.ToString();
				}
				set
				{
					content.Length = 0;
					if (value != null)
					{
						content.Append(value);
					}
				}
			}

			public int Height { get; set; }

			public int Width { get; set; }

			public SvgImage()
			{
				content = new StringBuilder();
			}

			public SvgImage(int width, int height)
			{
				content = new StringBuilder();
				Width = width;
				Height = height;
			}

			public SvgImage(string content)
			{
				this.content = new StringBuilder(content);
			}

			public override string ToString()
			{
				return content.ToString();
			}

			internal void AddHeader()
			{
				content.Append("<?xml version=\"1.0\" standalone=\"no\"?>");
				content.Append("<!-- Created with ZXing.Net (http://zxingnet.codeplex.com/) -->");
				content.Append("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">");
			}

			internal void AddEnd()
			{
				content.Append("</svg>");
			}

			internal void AddTag(int displaysizeX, int displaysizeY, int viewboxSizeX, int viewboxSizeY, Color background, Color fill)
			{
				if (displaysizeX <= 0 || displaysizeY <= 0)
				{
					content.Append($"<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.2\" baseProfile=\"tiny\" shape-rendering=\"crispEdges\" viewBox=\"0 0 {viewboxSizeX} {viewboxSizeY}\" viewport-fill=\"rgb({GetColorRgb(background)})\" viewport-fill-opacity=\"{ConvertAlpha(background)}\" fill=\"rgb({GetColorRgb(fill)})\" fill-opacity=\"{ConvertAlpha(fill)}\" {GetBackgroundStyle(background)}>");
				}
				else
				{
					content.Append($"<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.2\" baseProfile=\"tiny\" shape-rendering=\"crispEdges\" viewBox=\"0 0 {viewboxSizeX} {viewboxSizeY}\" viewport-fill=\"rgb({GetColorRgb(background)})\" viewport-fill-opacity=\"{ConvertAlpha(background)}\" fill=\"rgb({GetColorRgb(fill)})\" fill-opacity=\"{ConvertAlpha(fill)}\" {GetBackgroundStyle(background)} width=\"{displaysizeX}\" height=\"{displaysizeY}\">");
				}
			}

			internal void AddText(string text, string fontName, int fontSize)
			{
				content.AppendFormat(CultureInfo.InvariantCulture, "<text x=\"50%\" y=\"98%\" style=\"font-family: {0}; font-size: {1}px\" text-anchor=\"middle\">{2}</text>", fontName, fontSize, text);
			}

			internal void AddRec(int posX, int posY, int width, int height)
			{
				content.AppendFormat(CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"{2}\" height=\"{3}\"/>", posX, posY, width, height);
			}

			internal static double ConvertAlpha(Color alpha)
			{
				return Math.Round((double)(int)alpha.A / 255.0, 2);
			}

			internal static string GetBackgroundStyle(Color color)
			{
				double num = ConvertAlpha(color);
				return $"style=\"background-color:rgb({color.R},{color.G},{color.B});background-color:rgba({num});\"";
			}

			internal static string GetColorRgb(Color color)
			{
				return color.R + "," + color.G + "," + color.B;
			}

			internal static string GetColorRgba(Color color)
			{
				double num = ConvertAlpha(color);
				return color.R + "," + color.G + "," + color.B + "," + num;
			}
		}

		public const string DefaultFontName = "Arial";

		public const int DefaultFontSize = 10;

		[CLSCompliant(false)]
		public Color Foreground { get; set; }

		[CLSCompliant(false)]
		public Color Background { get; set; }

		public string FontName { get; set; }

		public int FontSize { get; set; }

		public SvgRenderer()
		{
			Foreground = Color.Black;
			Background = Color.White;
		}

		public SvgImage Render(BitMatrix matrix, BarcodeFormat format, string content)
		{
			return Render(matrix, format, content, null);
		}

		public SvgImage Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
		{
			SvgImage svgImage = new SvgImage(matrix.Width, matrix.Height);
			Create(svgImage, matrix, format, content, options);
			return svgImage;
		}

		private void Create(SvgImage image, BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
		{
			if (matrix == null)
			{
				return;
			}
			int width = matrix.Width;
			int num = matrix.Height;
			int num2;
			if ((options == null || !options.PureBarcode) && !string.IsNullOrEmpty(content))
			{
				if (format != BarcodeFormat.CODE_39 && format != BarcodeFormat.CODE_93 && format != BarcodeFormat.CODE_128 && format != BarcodeFormat.EAN_13 && format != BarcodeFormat.EAN_8 && format != BarcodeFormat.CODABAR && format != BarcodeFormat.ITF && format != BarcodeFormat.UPC_A && format != BarcodeFormat.UPC_E && format != BarcodeFormat.MSI)
				{
					num2 = ((format == BarcodeFormat.PLESSEY) ? 1 : 0);
					if (num2 == 0)
					{
						goto IL_0091;
					}
				}
				else
				{
					num2 = 1;
				}
				int num3 = ((FontSize < 1) ? 10 : FontSize);
				num += num3 + 3;
			}
			else
			{
				num2 = 0;
			}
			goto IL_0091;
			IL_0091:
			image.AddHeader();
			image.AddTag(0, 0, width, num, Background, Foreground);
			AppendDarkCell(image, matrix, 0, 0);
			if (num2 != 0)
			{
				string fontName = (string.IsNullOrEmpty(FontName) ? "Arial" : FontName);
				int fontSize = ((FontSize < 1) ? 10 : FontSize);
				content = ModifyContentDependingOnBarcodeFormat(format, content);
				image.AddText(content, fontName, fontSize);
			}
			image.AddEnd();
		}

		private string ModifyContentDependingOnBarcodeFormat(BarcodeFormat format, string content)
		{
			switch (format)
			{
			case BarcodeFormat.EAN_8:
				if (content.Length < 8)
				{
					content = OneDimensionalCodeWriter.CalculateChecksumDigitModulo10(content);
				}
				content = content.Insert(4, "   ");
				break;
			case BarcodeFormat.EAN_13:
				if (content.Length < 13)
				{
					content = OneDimensionalCodeWriter.CalculateChecksumDigitModulo10(content);
				}
				content = content.Insert(7, "   ");
				content = content.Insert(1, "   ");
				break;
			}
			return content;
		}

		private static void AppendDarkCell(SvgImage image, BitMatrix matrix, int offsetX, int offSetY)
		{
			if (matrix == null)
			{
				return;
			}
			int width = matrix.Width;
			int height = matrix.Height;
			BitMatrix bitMatrix = new BitMatrix(width, height);
			bool flag = false;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < width; i++)
			{
				int endPosX;
				for (int j = 0; j < height; j++)
				{
					if (bitMatrix[i, j])
					{
						continue;
					}
					bitMatrix[i, j] = true;
					if (matrix[i, j])
					{
						if (!flag)
						{
							num = i;
							num2 = j;
							flag = true;
						}
					}
					else if (flag)
					{
						FindMaximumRectangle(matrix, bitMatrix, num, num2, j, out endPosX);
						image.AddRec(num + offsetX, num2 + offSetY, endPosX - num + 1, j - num2);
						flag = false;
					}
				}
				if (flag)
				{
					FindMaximumRectangle(matrix, bitMatrix, num, num2, height, out endPosX);
					image.AddRec(num + offsetX, num2 + offSetY, endPosX - num + 1, height - num2);
					flag = false;
				}
			}
		}

		private static void FindMaximumRectangle(BitMatrix matrix, BitMatrix processed, int startPosX, int startPosY, int endPosY, out int endPosX)
		{
			endPosX = startPosX;
			for (int i = startPosX + 1; i < matrix.Width; i++)
			{
				for (int j = startPosY; j < endPosY; j++)
				{
					if (!matrix[i, j])
					{
						return;
					}
				}
				endPosX = i;
				for (int k = startPosY; k < endPosY; k++)
				{
					processed[i, k] = true;
				}
			}
		}
	}
}
namespace ZXing.QrCode
{
	[Serializable]
	public class QrCodeEncodingOptions : EncodingOptions
	{
		public ErrorCorrectionLevel ErrorCorrection
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
				{
					return (ErrorCorrectionLevel)base.Hints[EncodeHintType.ERROR_CORRECTION];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					if (base.Hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
					{
						base.Hints.Remove(EncodeHintType.ERROR_CORRECTION);
					}
				}
				else
				{
					base.Hints[EncodeHintType.ERROR_CORRECTION] = value;
				}
			}
		}

		public string CharacterSet
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.CHARACTER_SET))
				{
					return (string)base.Hints[EncodeHintType.CHARACTER_SET];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					if (base.Hints.ContainsKey(EncodeHintType.CHARACTER_SET))
					{
						base.Hints.Remove(EncodeHintType.CHARACTER_SET);
					}
				}
				else
				{
					base.Hints[EncodeHintType.CHARACTER_SET] = value;
				}
			}
		}

		public bool DisableECI
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.DISABLE_ECI))
				{
					return (bool)base.Hints[EncodeHintType.DISABLE_ECI];
				}
				return false;
			}
			set
			{
				base.Hints[EncodeHintType.DISABLE_ECI] = value;
			}
		}

		public int? QrVersion
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.QR_VERSION))
				{
					return (int)base.Hints[EncodeHintType.QR_VERSION];
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					if (base.Hints.ContainsKey(EncodeHintType.QR_VERSION))
					{
						base.Hints.Remove(EncodeHintType.QR_VERSION);
					}
				}
				else
				{
					base.Hints[EncodeHintType.QR_VERSION] = value.Value;
				}
			}
		}
	}
	public class QRCodeReader : Reader
	{
		private static readonly ResultPoint[] NO_POINTS = new ResultPoint[0];

		private readonly ZXing.QrCode.Internal.Decoder decoder = new ZXing.QrCode.Internal.Decoder();

		protected ZXing.QrCode.Internal.Decoder getDecoder()
		{
			return decoder;
		}

		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			if (image == null || image.BlackMatrix == null)
			{
				return null;
			}
			DecoderResult decoderResult;
			ResultPoint[] array;
			if (hints != null && hints.ContainsKey(DecodeHintType.PURE_BARCODE))
			{
				BitMatrix bitMatrix = extractPureBits(image.BlackMatrix);
				if (bitMatrix == null)
				{
					return null;
				}
				decoderResult = decoder.decode(bitMatrix, hints);
				array = NO_POINTS;
			}
			else
			{
				DetectorResult detectorResult = new ZXing.QrCode.Internal.Detector(image.BlackMatrix).detect(hints);
				if (detectorResult == null)
				{
					return null;
				}
				decoderResult = decoder.decode(detectorResult.Bits, hints);
				array = detectorResult.Points;
			}
			if (decoderResult == null)
			{
				return null;
			}
			if (decoderResult.Other is QRCodeDecoderMetaData qRCodeDecoderMetaData)
			{
				qRCodeDecoderMetaData.applyMirroredCorrection(array);
			}
			Result result = new Result(decoderResult.Text, decoderResult.RawBytes, array, BarcodeFormat.QR_CODE);
			IList<byte[]> byteSegments = decoderResult.ByteSegments;
			if (byteSegments != null)
			{
				result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, byteSegments);
			}
			string eCLevel = decoderResult.ECLevel;
			if (eCLevel != null)
			{
				result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, eCLevel);
			}
			if (decoderResult.StructuredAppend)
			{
				result.putMetadata(ResultMetadataType.STRUCTURED_APPEND_SEQUENCE, decoderResult.StructuredAppendSequenceNumber);
				result.putMetadata(ResultMetadataType.STRUCTURED_APPEND_PARITY, decoderResult.StructuredAppendParity);
			}
			return result;
		}

		public void reset()
		{
		}

		private static BitMatrix extractPureBits(BitMatrix image)
		{
			int[] topLeftOnBit = image.getTopLeftOnBit();
			int[] bottomRightOnBit = image.getBottomRightOnBit();
			if (topLeftOnBit == null || bottomRightOnBit == null)
			{
				return null;
			}
			if (!moduleSize(topLeftOnBit, image, out var msize))
			{
				return null;
			}
			int num = topLeftOnBit[1];
			int num2 = bottomRightOnBit[1];
			int num3 = topLeftOnBit[0];
			int num4 = bottomRightOnBit[0];
			if (num3 >= num4 || num >= num2)
			{
				return null;
			}
			if (num2 - num != num4 - num3)
			{
				num4 = num3 + (num2 - num);
				if (num4 >= image.Width)
				{
					return null;
				}
			}
			int num5 = (int)Math.Round((float)(num4 - num3 + 1) / msize);
			int num6 = (int)Math.Round((float)(num2 - num + 1) / msize);
			if (num5 <= 0 || num6 <= 0)
			{
				return null;
			}
			if (num6 != num5)
			{
				return null;
			}
			int num7 = (int)(msize / 2f);
			num += num7;
			num3 += num7;
			int num8 = num3 + (int)((float)(num5 - 1) * msize) - num4;
			if (num8 > 0)
			{
				if (num8 > num7)
				{
					return null;
				}
				num3 -= num8;
			}
			int num9 = num + (int)((float)(num6 - 1) * msize) - num2;
			if (num9 > 0)
			{
				if (num9 > num7)
				{
					return null;
				}
				num -= num9;
			}
			BitMatrix bitMatrix = new BitMatrix(num5, num6);
			for (int i = 0; i < num6; i++)
			{
				int y = num + (int)((float)i * msize);
				for (int j = 0; j < num5; j++)
				{
					if (image[num3 + (int)((float)j * msize), y])
					{
						bitMatrix[j, i] = true;
					}
				}
			}
			return bitMatrix;
		}

		private static bool moduleSize(int[] leftTopBlack, BitMatrix image, out float msize)
		{
			int height = image.Height;
			int width = image.Width;
			int num = leftTopBlack[0];
			int num2 = leftTopBlack[1];
			bool flag = true;
			int num3 = 0;
			while (num < width && num2 < height)
			{
				if (flag != image[num, num2])
				{
					if (++num3 == 5)
					{
						break;
					}
					flag = !flag;
				}
				num++;
				num2++;
			}
			if (num == width || num2 == height)
			{
				msize = 0f;
				return false;
			}
			msize = (float)(num - leftTopBlack[0]) / 7f;
			return true;
		}
	}
	public sealed class QRCodeWriter : Writer
	{
		private const int QUIET_ZONE_SIZE = 4;

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (string.IsNullOrEmpty(contents))
			{
				throw new ArgumentException("Found empty contents");
			}
			if (format != BarcodeFormat.QR_CODE)
			{
				throw new ArgumentException("Can only encode QR_CODE, but got " + format);
			}
			if (width < 0 || height < 0)
			{
				throw new ArgumentException("Requested dimensions are too small: " + width + "x" + height);
			}
			ErrorCorrectionLevel errorCorrectionLevel = ErrorCorrectionLevel.L;
			int quietZone = 4;
			if (hints != null)
			{
				if (hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
				{
					object obj = hints[EncodeHintType.ERROR_CORRECTION];
					if (obj != null)
					{
						errorCorrectionLevel = obj as ErrorCorrectionLevel;
						if (errorCorrectionLevel == null)
						{
							errorCorrectionLevel = obj.ToString().ToUpper() switch
							{
								"L" => ErrorCorrectionLevel.L, 
								"M" => ErrorCorrectionLevel.M, 
								"Q" => ErrorCorrectionLevel.Q, 
								"H" => ErrorCorrectionLevel.H, 
								_ => ErrorCorrectionLevel.L, 
							};
						}
					}
				}
				if (hints.ContainsKey(EncodeHintType.MARGIN))
				{
					object obj2 = hints[EncodeHintType.MARGIN];
					if (obj2 != null)
					{
						quietZone = Convert.ToInt32(obj2.ToString());
					}
				}
			}
			return renderResult(ZXing.QrCode.Internal.Encoder.encode(contents, errorCorrectionLevel, hints), width, height, quietZone);
		}

		private static BitMatrix renderResult(QRCode code, int width, int height, int quietZone)
		{
			ByteMatrix matrix = code.Matrix;
			if (matrix == null)
			{
				throw new InvalidOperationException();
			}
			int width2 = matrix.Width;
			int height2 = matrix.Height;
			int num = width2 + (quietZone << 1);
			int num2 = height2 + (quietZone << 1);
			int num3 = Math.Max(width, num);
			int num4 = Math.Max(height, num2);
			int num5 = Math.Min(num3 / num, num4 / num2);
			int num6 = (num3 - width2 * num5) / 2;
			int num7 = (num4 - height2 * num5) / 2;
			BitMatrix bitMatrix = new BitMatrix(num3, num4);
			int num8 = 0;
			int num9 = num7;
			while (num8 < height2)
			{
				int num10 = 0;
				int num11 = num6;
				while (num10 < width2)
				{
					if (matrix[num10, num8] == 1)
					{
						bitMatrix.setRegion(num11, num9, num5, num5);
					}
					num10++;
					num11 += num5;
				}
				num8++;
				num9 += num5;
			}
			return bitMatrix;
		}
	}
}
namespace ZXing.QrCode.Internal
{
	internal sealed class BitMatrixParser
	{
		private readonly BitMatrix bitMatrix;

		private Version parsedVersion;

		private FormatInformation parsedFormatInfo;

		private bool mirrored;

		internal static BitMatrixParser createBitMatrixParser(BitMatrix bitMatrix)
		{
			int height = bitMatrix.Height;
			if (height < 21 || (height & 3) != 1)
			{
				return null;
			}
			return new BitMatrixParser(bitMatrix);
		}

		private BitMatrixParser(BitMatrix bitMatrix)
		{
			this.bitMatrix = bitMatrix;
		}

		internal FormatInformation readFormatInformation()
		{
			if (parsedFormatInfo != null)
			{
				return parsedFormatInfo;
			}
			int versionBits = 0;
			for (int i = 0; i < 6; i++)
			{
				versionBits = copyBit(i, 8, versionBits);
			}
			versionBits = copyBit(7, 8, versionBits);
			versionBits = copyBit(8, 8, versionBits);
			versionBits = copyBit(8, 7, versionBits);
			for (int num = 5; num >= 0; num--)
			{
				versionBits = copyBit(8, num, versionBits);
			}
			int height = bitMatrix.Height;
			int num2 = 0;
			int num3 = height - 7;
			for (int num4 = height - 1; num4 >= num3; num4--)
			{
				num2 = copyBit(8, num4, num2);
			}
			for (int j = height - 8; j < height; j++)
			{
				num2 = copyBit(j, 8, num2);
			}
			parsedFormatInfo = FormatInformation.decodeFormatInformation(versionBits, num2);
			if (parsedFormatInfo != null)
			{
				return parsedFormatInfo;
			}
			return null;
		}

		internal Version readVersion()
		{
			if (parsedVersion != null)
			{
				return parsedVersion;
			}
			int height = bitMatrix.Height;
			int num = height - 17 >> 2;
			if (num <= 6)
			{
				return Version.getVersionForNumber(num);
			}
			int versionBits = 0;
			int num2 = height - 11;
			for (int num3 = 5; num3 >= 0; num3--)
			{
				for (int num4 = height - 9; num4 >= num2; num4--)
				{
					versionBits = copyBit(num4, num3, versionBits);
				}
			}
			parsedVersion = Version.decodeVersionInformation(versionBits);
			if (parsedVersion != null && parsedVersion.DimensionForVersion == height)
			{
				return parsedVersion;
			}
			versionBits = 0;
			for (int num5 = 5; num5 >= 0; num5--)
			{
				for (int num6 = height - 9; num6 >= num2; num6--)
				{
					versionBits = copyBit(num5, num6, versionBits);
				}
			}
			parsedVersion = Version.decodeVersionInformation(versionBits);
			if (parsedVersion != null && parsedVersion.DimensionForVersion == height)
			{
				return parsedVersion;
			}
			return null;
		}

		private int copyBit(int i, int j, int versionBits)
		{
			if (!(mirrored ? bitMatrix[j, i] : bitMatrix[i, j]))
			{
				return versionBits << 1;
			}
			return (versionBits << 1) | 1;
		}

		internal byte[] readCodewords()
		{
			FormatInformation formatInformation = readFormatInformation();
			if (formatInformation == null)
			{
				return null;
			}
			Version version = readVersion();
			if (version == null)
			{
				return null;
			}
			int height = this.bitMatrix.Height;
			DataMask.unmaskBitMatrix(formatInformation.DataMask, this.bitMatrix, height);
			BitMatrix bitMatrix = version.buildFunctionPattern();
			bool flag = true;
			byte[] array = new byte[version.TotalCodewords];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int num4 = height - 1; num4 > 0; num4 -= 2)
			{
				if (num4 == 6)
				{
					num4--;
				}
				for (int i = 0; i < height; i++)
				{
					int y = (flag ? (height - 1 - i) : i);
					for (int j = 0; j < 2; j++)
					{
						if (!bitMatrix[num4 - j, y])
						{
							num3++;
							num2 <<= 1;
							if (this.bitMatrix[num4 - j, y])
							{
								num2 |= 1;
							}
							if (num3 == 8)
							{
								array[num++] = (byte)num2;
								num3 = 0;
								num2 = 0;
							}
						}
					}
				}
				flag = !flag;
			}
			if (num != version.TotalCodewords)
			{
				return null;
			}
			return array;
		}

		internal void remask()
		{
			if (parsedFormatInfo != null)
			{
				int height = bitMatrix.Height;
				DataMask.unmaskBitMatrix(parsedFormatInfo.DataMask, bitMatrix, height);
			}
		}

		internal void setMirror(bool mirror)
		{
			parsedVersion = null;
			parsedFormatInfo = null;
			mirrored = mirror;
		}

		internal void mirror()
		{
			for (int i = 0; i < bitMatrix.Width; i++)
			{
				for (int j = i + 1; j < bitMatrix.Height; j++)
				{
					if (bitMatrix[i, j] != bitMatrix[j, i])
					{
						bitMatrix.flip(j, i);
						bitMatrix.flip(i, j);
					}
				}
			}
		}
	}
	internal sealed class DataBlock
	{
		private readonly int numDataCodewords;

		private readonly byte[] codewords;

		internal int NumDataCodewords => numDataCodewords;

		internal byte[] Codewords => codewords;

		private DataBlock(int numDataCodewords, byte[] codewords)
		{
			this.numDataCodewords = numDataCodewords;
			this.codewords = codewords;
		}

		internal static DataBlock[] getDataBlocks(byte[] rawCodewords, Version version, ErrorCorrectionLevel ecLevel)
		{
			if (rawCodewords.Length != version.TotalCodewords)
			{
				throw new ArgumentException();
			}
			Version.ECBlocks eCBlocksForLevel = version.getECBlocksForLevel(ecLevel);
			int num = 0;
			Version.ECB[] eCBlocks = eCBlocksForLevel.getECBlocks();
			Version.ECB[] array = eCBlocks;
			foreach (Version.ECB eCB in array)
			{
				num += eCB.Count;
			}
			DataBlock[] array2 = new DataBlock[num];
			int num2 = 0;
			array = eCBlocks;
			foreach (Version.ECB eCB2 in array)
			{
				for (int j = 0; j < eCB2.Count; j++)
				{
					int dataCodewords = eCB2.DataCodewords;
					int num3 = eCBlocksForLevel.ECCodewordsPerBlock + dataCodewords;
					array2[num2++] = new DataBlock(dataCodewords, new byte[num3]);
				}
			}
			int num4 = array2[0].codewords.Length;
			int num5 = array2.Length - 1;
			while (num5 >= 0 && array2[num5].codewords.Length != num4)
			{
				num5--;
			}
			num5++;
			int num6 = num4 - eCBlocksForLevel.ECCodewordsPerBlock;
			int num7 = 0;
			for (int k = 0; k < num6; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					array2[l].codewords[k] = rawCodewords[num7++];
				}
			}
			for (int m = num5; m < num2; m++)
			{
				array2[m].codewords[num6] = rawCodewords[num7++];
			}
			int num8 = array2[0].codewords.Length;
			for (int n = num6; n < num8; n++)
			{
				for (int num9 = 0; num9 < num2; num9++)
				{
					int num10 = ((num9 < num5) ? n : (n + 1));
					array2[num9].codewords[num10] = rawCodewords[num7++];
				}
			}
			return array2;
		}
	}
	internal static class DataMask
	{
		private static readonly Func<int, int, bool>[] DATA_MASKS = new Func<int, int, bool>[8]
		{
			(int i, int j) => ((i + j) & 1) == 0,
			(int i, int j) => (i & 1) == 0,
			(int i, int j) => j % 3 == 0,
			(int i, int j) => (i + j) % 3 == 0,
			(int i, int j) => (((i >>> 1) + j / 3) & 1) == 0,
			(int i, int j) => i * j % 6 == 0,
			(int i, int j) => i * j % 6 < 3,
			(int i, int j) => ((i + j + i * j % 3) & 1) == 0
		};

		internal static void unmaskBitMatrix(int reference, BitMatrix bits, int dimension)
		{
			if (reference < 0 || reference > 7)
			{
				throw new ArgumentException();
			}
			Func<int, int, bool> shouldBeFlipped = DATA_MASKS[reference];
			bits.flipWhen(shouldBeFlipped);
		}
	}
	internal static class DecodedBitStreamParser
	{
		private static readonly char[] ALPHANUMERIC_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:".ToCharArray();

		private const int GB2312_SUBSET = 1;

		internal static DecoderResult decode(byte[] bytes, Version version, ErrorCorrectionLevel ecLevel, IDictionary<DecodeHintType, object> hints)
		{
			BitSource bitSource = new BitSource(bytes);
			StringBuilder stringBuilder = new StringBuilder(50);
			List<byte[]> list = new List<byte[]>(1);
			int saSequence = -1;
			int saParity = -1;
			try
			{
				CharacterSetECI characterSetECI = null;
				bool fc1InEffect = false;
				Mode mode;
				do
				{
					if (bitSource.available() < 4)
					{
						mode = Mode.TERMINATOR;
					}
					else
					{
						try
						{
							mode = Mode.forBits(bitSource.readBits(4));
						}
						catch (ArgumentException)
						{
							return null;
						}
					}
					switch (mode.Name)
					{
					case Mode.Names.FNC1_FIRST_POSITION:
					case Mode.Names.FNC1_SECOND_POSITION:
						fc1InEffect = true;
						continue;
					case Mode.Names.STRUCTURED_APPEND:
						if (bitSource.available() < 16)
						{
							return null;
						}
						saSequence = bitSource.readBits(8);
						saParity = bitSource.readBits(8);
						continue;
					case Mode.Names.ECI:
						characterSetECI = CharacterSetECI.getCharacterSetECIByValue(parseECIValue(bitSource));
						if (characterSetECI == null)
						{
							return null;
						}
						continue;
					case Mode.Names.HANZI:
					{
						int num = bitSource.readBits(4);
						int count = bitSource.readBits(mode.getCharacterCountBits(version));
						if (num == 1 && !decodeHanziSegment(bitSource, stringBuilder, count))
						{
							return null;
						}
						continue;
					}
					case Mode.Names.TERMINATOR:
						continue;
					}
					int count2 = bitSource.readBits(mode.getCharacterCountBits(version));
					switch (mode.Name)
					{
					case Mode.Names.NUMERIC:
						if (!decodeNumericSegment(bitSource, stringBuilder, count2))
						{
							return null;
						}
						break;
					case Mode.Names.ALPHANUMERIC:
						if (!decodeAlphanumericSegment(bitSource, stringBuilder, count2, fc1InEffect))
						{
							return null;
						}
						break;
					case Mode.Names.BYTE:
						if (!decodeByteSegment(bitSource, stringBuilder, count2, characterSetECI, list, hints))
						{
							return null;
						}
						break;
					case Mode.Names.KANJI:
						if (!decodeKanjiSegment(bitSource, stringBuilder, count2))
						{
							return null;
						}
						break;
					default:
						return null;
					}
				}
				while (mode != Mode.TERMINATOR);
			}
			catch (ArgumentException)
			{
				return null;
			}
			string text = stringBuilder.ToString().Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
			return new DecoderResult(bytes, text, (list.Count == 0) ? null : list, ecLevel?.ToString(), saSequence, saParity);
		}

		private static bool decodeHanziSegment(BitSource bits, StringBuilder result, int count)
		{
			if (count * 13 > bits.available())
			{
				return false;
			}
			byte[] array = new byte[2 * count];
			int num = 0;
			while (count > 0)
			{
				int num2 = bits.readBits(13);
				int num3 = (num2 / 96 << 8) | (num2 % 96);
				num3 = ((num3 >= 959) ? (num3 + 42657) : (num3 + 41377));
				array[num] = (byte)((num3 >> 8) & 0xFF);
				array[num + 1] = (byte)(num3 & 0xFF);
				num += 2;
				count--;
			}
			try
			{
				result.Append(Encoding.GetEncoding(StringUtils.GB2312).GetString(array, 0, array.Length));
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private static bool decodeKanjiSegment(BitSource bits, StringBuilder result, int count)
		{
			if (count * 13 > bits.available())
			{
				return false;
			}
			byte[] array = new byte[2 * count];
			int num = 0;
			while (count > 0)
			{
				int num2 = bits.readBits(13);
				int num3 = (num2 / 192 << 8) | (num2 % 192);
				num3 = ((num3 >= 7936) ? (num3 + 49472) : (num3 + 33088));
				array[num] = (byte)(num3 >> 8);
				array[num + 1] = (byte)num3;
				num += 2;
				count--;
			}
			try
			{
				result.Append(Encoding.GetEncoding(StringUtils.SHIFT_JIS).GetString(array, 0, array.Length));
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private static bool decodeByteSegment(BitSource bits, StringBuilder result, int count, CharacterSetECI currentCharacterSetECI, IList<byte[]> byteSegments, IDictionary<DecodeHintType, object> hints)
		{
			if (count << 3 > bits.available())
			{
				return false;
			}
			byte[] array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (byte)bits.readBits(8);
			}
			string name = ((currentCharacterSetECI != null) ? currentCharacterSetECI.EncodingName : StringUtils.guessEncoding(array, hints));
			try
			{
				result.Append(Encoding.GetEncoding(name).GetString(array, 0, array.Length));
			}
			catch (Exception)
			{
				return false;
			}
			byteSegments.Add(array);
			return true;
		}

		private static char toAlphaNumericChar(int value)
		{
			if (value >= ALPHANUMERIC_CHARS.Length)
			{
				throw new FormatException();
			}
			return ALPHANUMERIC_CHARS[value];
		}

		private static bool decodeAlphanumericSegment(BitSource bits, StringBuilder result, int count, bool fc1InEffect)
		{
			int length = result.Length;
			while (count > 1)
			{
				if (bits.available() < 11)
				{
					return false;
				}
				int num = bits.readBits(11);
				result.Append(toAlphaNumericChar(num / 45));
				result.Append(toAlphaNumericChar(num % 45));
				count -= 2;
			}
			if (count == 1)
			{
				if (bits.available() < 6)
				{
					return false;
				}
				result.Append(toAlphaNumericChar(bits.readBits(6)));
			}
			if (fc1InEffect)
			{
				for (int i = length; i < result.Length; i++)
				{
					if (result[i] == '%')
					{
						if (i < result.Length - 1 && result[i + 1] == '%')
						{
							result.Remove(i + 1, 1);
							continue;
						}
						result.Remove(i, 1);
						result.Insert(i, new char[1] { '\u001d' });
					}
				}
			}
			return true;
		}

		private static bool decodeNumericSegment(BitSource bits, StringBuilder result, int count)
		{
			while (count >= 3)
			{
				if (bits.available() < 10)
				{
					return false;
				}
				int num = bits.readBits(10);
				if (num >= 1000)
				{
					return false;
				}
				result.Append(toAlphaNumericChar(num / 100));
				result.Append(toAlphaNumericChar(num / 10 % 10));
				result.Append(toAlphaNumericChar(num % 10));
				count -= 3;
			}
			switch (count)
			{
			case 2:
			{
				if (bits.available() < 7)
				{
					return false;
				}
				int num3 = bits.readBits(7);
				if (num3 >= 100)
				{
					return false;
				}
				result.Append(toAlphaNumericChar(num3 / 10));
				result.Append(toAlphaNumericChar(num3 % 10));
				break;
			}
			case 1:
			{
				if (bits.available() < 4)
				{
					return false;
				}
				int num2 = bits.readBits(4);
				if (num2 >= 10)
				{
					return false;
				}
				result.Append(toAlphaNumericChar(num2));
				break;
			}
			}
			return true;
		}

		private static int parseECIValue(BitSource bits)
		{
			int num = bits.readBits(8);
			if ((num & 0x80) == 0)
			{
				return num & 0x7F;
			}
			if ((num & 0xC0) == 128)
			{
				int num2 = bits.readBits(8);
				return ((num & 0x3F) << 8) | num2;
			}
			if ((num & 0xE0) == 192)
			{
				int num3 = bits.readBits(16);
				return ((num & 0x1F) << 16) | num3;
			}
			throw new ArgumentException("Bad ECI bits starting with byte " + num);
		}
	}
	public sealed class Decoder
	{
		private readonly ReedSolomonDecoder rsDecoder;

		public Decoder()
		{
			rsDecoder = new ReedSolomonDecoder(GenericGF.QR_CODE_FIELD_256);
		}

		public DecoderResult decode(bool[][] image, IDictionary<DecodeHintType, object> hints)
		{
			return decode(BitMatrix.parse(image), hints);
		}

		public DecoderResult decode(BitMatrix bits, IDictionary<DecodeHintType, object> hints)
		{
			BitMatrixParser bitMatrixParser = BitMatrixParser.createBitMatrixParser(bits);
			if (bitMatrixParser == null)
			{
				return null;
			}
			DecoderResult decoderResult = decode(bitMatrixParser, hints);
			if (decoderResult == null)
			{
				bitMatrixParser.remask();
				bitMatrixParser.setMirror(mirror: true);
				if (bitMatrixParser.readVersion() == null)
				{
					return null;
				}
				if (bitMatrixParser.readFormatInformation() == null)
				{
					return null;
				}
				bitMatrixParser.mirror();
				decoderResult = decode(bitMatrixParser, hints);
				if (decoderResult != null)
				{
					decoderResult.Other = new QRCodeDecoderMetaData(mirrored: true);
				}
			}
			return decoderResult;
		}

		private DecoderResult decode(BitMatrixParser parser, IDictionary<DecodeHintType, object> hints)
		{
			Version version = parser.readVersion();
			if (version == null)
			{
				return null;
			}
			FormatInformation formatInformation = parser.readFormatInformation();
			if (formatInformation == null)
			{
				return null;
			}
			ErrorCorrectionLevel errorCorrectionLevel = formatInformation.ErrorCorrectionLevel;
			byte[] array = parser.readCodewords();
			if (array == null)
			{
				return null;
			}
			DataBlock[] dataBlocks = DataBlock.getDataBlocks(array, version, errorCorrectionLevel);
			int num = 0;
			DataBlock[] array2 = dataBlocks;
			foreach (DataBlock dataBlock in array2)
			{
				num += dataBlock.NumDataCodewords;
			}
			byte[] array3 = new byte[num];
			int num2 = 0;
			array2 = dataBlocks;
			foreach (DataBlock obj in array2)
			{
				byte[] codewords = obj.Codewords;
				int numDataCodewords = obj.NumDataCodewords;
				if (!correctErrors(codewords, numDataCodewords))
				{
					return null;
				}
				for (int j = 0; j < numDataCodewords; j++)
				{
					array3[num2++] = codewords[j];
				}
			}
			return DecodedBitStreamParser.decode(array3, version, errorCorrectionLevel, hints);
		}

		private bool correctErrors(byte[] codewordBytes, int numDataCodewords)
		{
			int num = codewordBytes.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = codewordBytes[i] & 0xFF;
			}
			int twoS = codewordBytes.Length - numDataCodewords;
			if (!rsDecoder.decode(array, twoS))
			{
				return false;
			}
			for (int j = 0; j < numDataCodewords; j++)
			{
				codewordBytes[j] = (byte)array[j];
			}
			return true;
		}
	}
	public sealed class ErrorCorrectionLevel
	{
		public static readonly ErrorCorrectionLevel L = new ErrorCorrectionLevel(0, 1, "L");

		public static readonly ErrorCorrectionLevel M = new ErrorCorrectionLevel(1, 0, "M");

		public static readonly ErrorCorrectionLevel Q = new ErrorCorrectionLevel(2, 3, "Q");

		public static readonly ErrorCorrectionLevel H = new ErrorCorrectionLevel(3, 2, "H");

		private static readonly ErrorCorrectionLevel[] FOR_BITS = new ErrorCorrectionLevel[4] { M, L, H, Q };

		private readonly int bits;

		private readonly int ordinal_Renamed_Field;

		private readonly string name;

		public int Bits => bits;

		public string Name => name;

		private ErrorCorrectionLevel(int ordinal, int bits, string name)
		{
			ordinal_Renamed_Field = ordinal;
			this.bits = bits;
			this.name = name;
		}

		public int ordinal()
		{
			return ordinal_Renamed_Field;
		}

		public override string ToString()
		{
			return name;
		}

		public static ErrorCorrectionLevel forBits(int bits)
		{
			if (bits < 0 || bits >= FOR_BITS.Length)
			{
				throw new ArgumentException();
			}
			return FOR_BITS[bits];
		}
	}
	internal sealed class FormatInformation
	{
		private const int FORMAT_INFO_MASK_QR = 21522;

		private static readonly int[][] FORMAT_INFO_DECODE_LOOKUP = new int[32][]
		{
			new int[2] { 21522, 0 },
			new int[2] { 20773, 1 },
			new int[2] { 24188, 2 },
			new int[2] { 23371, 3 },
			new int[2] { 17913, 4 },
			new int[2] { 16590, 5 },
			new int[2] { 20375, 6 },
			new int[2] { 19104, 7 },
			new int[2] { 30660, 8 },
			new int[2] { 29427, 9 },
			new int[2] { 32170, 10 },
			new int[2] { 30877, 11 },
			new int[2] { 26159, 12 },
			new int[2] { 25368, 13 },
			new int[2] { 27713, 14 },
			new int[2] { 26998, 15 },
			new int[2] { 5769, 16 },
			new int[2] { 5054, 17 },
			new int[2] { 7399, 18 },
			new int[2] { 6608, 19 },
			new int[2] { 1890, 20 },
			new int[2] { 597, 21 },
			new int[2] { 3340, 22 },
			new int[2] { 2107, 23 },
			new int[2] { 13663, 24 },
			new int[2] { 12392, 25 },
			new int[2] { 16177, 26 },
			new int[2] { 14854, 27 },
			new int[2] { 9396, 28 },
			new int[2] { 8579, 29 },
			new int[2] { 11994, 30 },
			new int[2] { 11245, 31 }
		};

		private static readonly int[] BITS_SET_IN_HALF_BYTE = new int[16]
		{
			0, 1, 1, 2, 1, 2, 2, 3, 1, 2,
			2, 3, 2, 3, 3, 4
		};

		private readonly ErrorCorrectionLevel errorCorrectionLevel;

		private readonly byte dataMask;

		internal ErrorCorrectionLevel ErrorCorrectionLevel => errorCorrectionLevel;

		internal byte DataMask => dataMask;

		private FormatInformation(int formatInfo)
		{
			errorCorrectionLevel = ErrorCorrectionLevel.forBits((formatInfo >> 3) & 3);
			dataMask = (byte)(formatInfo & 7);
		}

		internal static int numBitsDiffering(int a, int b)
		{
			a ^= b;
			return BITS_SET_IN_HALF_BYTE[a & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 4) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 8) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 12) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 16) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 20) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 24) & 0xF] + BITS_SET_IN_HALF_BYTE[(a >>> 28) & 0xF];
		}

		internal static FormatInformation decodeFormatInformation(int maskedFormatInfo1, int maskedFormatInfo2)
		{
			FormatInformation formatInformation = doDecodeFormatInformation(maskedFormatInfo1, maskedFormatInfo2);
			if (formatInformation != null)
			{
				return formatInformation;
			}
			return doDecodeFormatInformation(maskedFormatInfo1 ^ 0x5412, maskedFormatInfo2 ^ 0x5412);
		}

		private static FormatInformation doDecodeFormatInformation(int maskedFormatInfo1, int maskedFormatInfo2)
		{
			int num = 2147483647;
			int formatInfo = 0;
			int[][] fORMAT_INFO_DECODE_LOOKUP = FORMAT_INFO_DECODE_LOOKUP;
			foreach (int[] array in fORMAT_INFO_DECODE_LOOKUP)
			{
				int num2 = array[0];
				if (num2 == maskedFormatInfo1 || num2 == maskedFormatInfo2)
				{
					return new FormatInformation(array[1]);
				}
				int num3 = numBitsDiffering(maskedFormatInfo1, num2);
				if (num3 < num)
				{
					formatInfo = array[1];
					num = num3;
				}
				if (maskedFormatInfo1 != maskedFormatInfo2)
				{
					num3 = numBitsDiffering(maskedFormatInfo2, num2);
					if (num3 < num)
					{
						formatInfo = array[1];
						num = num3;
					}
				}
			}
			if (num <= 3)
			{
				return new FormatInformation(formatInfo);
			}
			return null;
		}

		public override int GetHashCode()
		{
			return (errorCorrectionLevel.ordinal() << 3) | dataMask;
		}

		public override bool Equals(object o)
		{
			if (!(o is FormatInformation))
			{
				return false;
			}
			FormatInformation formatInformation = (FormatInformation)o;
			if (errorCorrectionLevel == formatInformation.errorCorrectionLevel)
			{
				return dataMask == formatInformation.dataMask;
			}
			return false;
		}
	}
	public sealed class Mode
	{
		public enum Names
		{
			TERMINATOR,
			NUMERIC,
			ALPHANUMERIC,
			STRUCTURED_APPEND,
			BYTE,
			ECI,
			KANJI,
			FNC1_FIRST_POSITION,
			FNC1_SECOND_POSITION,
			HANZI
		}

		public static readonly Mode TERMINATOR = new Mode(new int[3], 0, Names.TERMINATOR);

		public static readonly Mode NUMERIC = new Mode(new int[3] { 10, 12, 14 }, 1, Names.NUMERIC);

		public static readonly Mode ALPHANUMERIC = new Mode(new int[3] { 9, 11, 13 }, 2, Names.ALPHANUMERIC);

		public static readonly Mode STRUCTURED_APPEND = new Mode(new int[3], 3, Names.STRUCTURED_APPEND);

		public static readonly Mode BYTE = new Mode(new int[3] { 8, 16, 16 }, 4, Names.BYTE);

		public static readonly Mode ECI = new Mode(null, 7, Names.ECI);

		public static readonly Mode KANJI = new Mode(new int[3] { 8, 10, 12 }, 8, Names.KANJI);

		public static readonly Mode FNC1_FIRST_POSITION = new Mode(null, 5, Names.FNC1_FIRST_POSITION);

		public static readonly Mode FNC1_SECOND_POSITION = new Mode(null, 9, Names.FNC1_SECOND_POSITION);

		public static readonly Mode HANZI = new Mode(new int[3] { 8, 10, 12 }, 13, Names.HANZI);

		private readonly int[] characterCountBitsForVersions;

		public Names Name { get; private set; }

		public int Bits { get; private set; }

		private Mode(int[] characterCountBitsForVersions, int bits, Names name)
		{
			this.characterCountBitsForVersions = characterCountBitsForVersions;
			Bits = bits;
			Name = name;
		}

		public static Mode forBits(int bits)
		{
			return bits switch
			{
				0 => TERMINATOR, 
				1 => NUMERIC, 
				2 => ALPHANUMERIC, 
				3 => STRUCTURED_APPEND, 
				4 => BYTE, 
				5 => FNC1_FIRST_POSITION, 
				7 => ECI, 
				8 => KANJI, 
				9 => FNC1_SECOND_POSITION, 
				13 => HANZI, 
				_ => throw new ArgumentException(), 
			};
		}

		public int getCharacterCountBits(Version version)
		{
			if (characterCountBitsForVersions == null)
			{
				throw new ArgumentException("Character count doesn't apply to this mode");
			}
			int versionNumber = version.VersionNumber;
			int num = ((versionNumber > 9) ? ((versionNumber <= 26) ? 1 : 2) : 0);
			return characterCountBitsForVersions[num];
		}

		public override string ToString()
		{
			return Name.ToString();
		}
	}
	public sealed class QRCodeDecoderMetaData
	{
		private readonly bool mirrored;

		public bool IsMirrored => mirrored;

		public QRCodeDecoderMetaData(bool mirrored)
		{
			this.mirrored = mirrored;
		}

		public void applyMirroredCorrection(ResultPoint[] points)
		{
			if (mirrored && points != null && points.Length >= 3)
			{
				ResultPoint resultPoint = points[0];
				points[0] = points[2];
				points[2] = resultPoint;
			}
		}
	}
	public sealed class Version
	{
		public sealed class ECBlocks
		{
			private readonly int ecCodewordsPerBlock;

			private readonly ECB[] ecBlocks;

			public int ECCodewordsPerBlock => ecCodewordsPerBlock;

			public int NumBlocks
			{
				get
				{
					int num = 0;
					ECB[] array = ecBlocks;
					foreach (ECB eCB in array)
					{
						num += eCB.Count;
					}
					return num;
				}
			}

			public int TotalECCodewords => ecCodewordsPerBlock * NumBlocks;

			internal ECBlocks(int ecCodewordsPerBlock, params ECB[] ecBlocks)
			{
				this.ecCodewordsPerBlock = ecCodewordsPerBlock;
				this.ecBlocks = ecBlocks;
			}

			public ECB[] getECBlocks()
			{
				return ecBlocks;
			}
		}

		public sealed class ECB
		{
			private readonly int count;

			private readonly int dataCodewords;

			public int Count => count;

			public int DataCodewords => dataCodewords;

			internal ECB(int count, int dataCodewords)
			{
				this.count = count;
				this.dataCodewords = dataCodewords;
			}
		}

		private static readonly int[] VERSION_DECODE_INFO = new int[34]
		{
			31892, 34236, 39577, 42195, 48118, 51042, 55367, 58893, 63784, 68472,
			70749, 76311, 79154, 84390, 87683, 92361, 96236, 102084, 102881, 110507,
			110734, 117786, 119615, 126325, 127568, 133589, 136944, 141498, 145311, 150283,
			152622, 158308, 161089, 167017
		};

		private static readonly Version[] VERSIONS = buildVersions();

		private readonly int versionNumber;

		private readonly int[] alignmentPatternCenters;

		private readonly ECBlocks[] ecBlocks;

		private readonly int totalCodewords;

		public int VersionNumber => versionNumber;

		public int[] AlignmentPatternCenters => alignmentPatternCenters;

		public int TotalCodewords => totalCodewords;

		public int DimensionForVersion => 17 + 4 * versionNumber;

		private Version(int versionNumber, int[] alignmentPatternCenters, params ECBlocks[] ecBlocks)
		{
			this.versionNumber = versionNumber;
			this.alignmentPatternCenters = alignmentPatternCenters;
			this.ecBlocks = ecBlocks;
			int num = 0;
			int eCCodewordsPerBlock = ecBlocks[0].ECCodewordsPerBlock;
			ECB[] eCBlocks = ecBlocks[0].getECBlocks();
			foreach (ECB eCB in eCBlocks)
			{
				num += eCB.Count * (eCB.DataCodewords + eCCodewordsPerBlock);
			}
			totalCodewords = num;
		}

		public ECBlocks getECBlocksForLevel(ErrorCorrectionLevel ecLevel)
		{
			return ecBlocks[ecLevel.ordinal()];
		}

		public static Version getProvisionalVersionForDimension(int dimension)
		{
			if (dimension % 4 != 1)
			{
				return null;
			}
			try
			{
				return getVersionForNumber(dimension - 17 >> 2);
			}
			catch (ArgumentException)
			{
				return null;
			}
		}

		public static Version getVersionForNumber(int versionNumber)
		{
			if (versionNumber < 1 || versionNumber > 40)
			{
				throw new ArgumentException();
			}
			return VERSIONS[versionNumber - 1];
		}

		internal static Version decodeVersionInformation(int versionBits)
		{
			int num = 2147483647;
			int num2 = 0;
			for (int i = 0; i < VERSION_DECODE_INFO.Length; i++)
			{
				int num3 = VERSION_DECODE_INFO[i];
				if (num3 == versionBits)
				{
					return getVersionForNumber(i + 7);
				}
				int num4 = FormatInformation.numBitsDiffering(versionBits, num3);
				if (num4 < num)
				{
					num2 = i + 7;
					num = num4;
				}
			}
			if (num <= 3)
			{
				return getVersionForNumber(num2);
			}
			return null;
		}

		internal BitMatrix buildFunctionPattern()
		{
			int dimensionForVersion = DimensionForVersion;
			BitMatrix bitMatrix = new BitMatrix(dimensionForVersion);
			bitMatrix.setRegion(0, 0, 9, 9);
			bitMatrix.setRegion(dimensionForVersion - 8, 0, 8, 9);
			bitMatrix.setRegion(0, dimensionForVersion - 8, 9, 8);
			int num = alignmentPatternCenters.Length;
			for (int i = 0; i < num; i++)
			{
				int top = alignmentPatternCenters[i] - 2;
				for (int j = 0; j < num; j++)
				{
					if ((i != 0 || (j != 0 && j != num - 1)) && (i != num - 1 || j != 0))
					{
						bitMatrix.setRegion(alignmentPatternCenters[j] - 2, top, 5, 5);
					}
				}
			}
			bitMatrix.setRegion(6, 9, 1, dimensionForVersion - 17);
			bitMatrix.setRegion(9, 6, dimensionForVersion - 17, 1);
			if (versionNumber > 6)
			{
				bitMatrix.setRegion(dimensionForVersion - 11, 0, 3, 6);
				bitMatrix.setRegion(0, dimensionForVersion - 11, 6, 3);
			}
			return bitMatrix;
		}

		public override string ToString()
		{
			return Convert.ToString(versionNumber);
		}

		private static Version[] buildVersions()
		{
			return new Version[40]
			{
				new Version(1, new int[0], new ECBlocks(7, new ECB(1, 19)), new ECBlocks(10, new ECB(1, 16)), new ECBlocks(13, new ECB(1, 13)), new ECBlocks(17, new ECB(1, 9))),
				new Version(2, new int[2] { 6, 18 }, new ECBlocks(10, new ECB(1, 34)), new ECBlocks(16, new ECB(1, 28)), new ECBlocks(22, new ECB(1, 22)), new ECBlocks(28, new ECB(1, 16))),
				new Version(3, new int[2] { 6, 22 }, new ECBlocks(15, new ECB(1, 55)), new ECBlocks(26, new ECB(1, 44)), new ECBlocks(18, new ECB(2, 17)), new ECBlocks(22, new ECB(2, 13))),
				new Version(4, new int[2] { 6, 26 }, new ECBlocks(20, new ECB(1, 80)), new ECBlocks(18, new ECB(2, 32)), new ECBlocks(26, new ECB(2, 24)), new ECBlocks(16, new ECB(4, 9))),
				new Version(5, new int[2] { 6, 30 }, new ECBlocks(26, new ECB(1, 108)), new ECBlocks(24, new ECB(2, 43)), new ECBlocks(18, new ECB(2, 15), new ECB(2, 16)), new ECBlocks(22, new ECB(2, 11), new ECB(2, 12))),
				new Version(6, new int[2] { 6, 34 }, new ECBlocks(18, new ECB(2, 68)), new ECBlocks(16, new ECB(4, 27)), new ECBlocks(24, new ECB(4, 19)), new ECBlocks(28, new ECB(4, 15))),
				new Version(7, new int[3] { 6, 22, 38 }, new ECBlocks(20, new ECB(2, 78)), new ECBlocks(18, new ECB(4, 31)), new ECBlocks(18, new ECB(2, 14), new ECB(4, 15)), new ECBlocks(26, new ECB(4, 13), new ECB(1, 14))),
				new Version(8, new int[3] { 6, 24, 42 }, new ECBlocks(24, new ECB(2, 97)), new ECBlocks(22, new ECB(2, 38), new ECB(2, 39)), new ECBlocks(22, new ECB(4, 18), new ECB(2, 19)), new ECBlocks(26, new ECB(4, 14), new ECB(2, 15))),
				new Version(9, new int[3] { 6, 26, 46 }, new ECBlocks(30, new ECB(2, 116)), new ECBlocks(22, new ECB(3, 36), new ECB(2, 37)), new ECBlocks(20, new ECB(4, 16), new ECB(4, 17)), new ECBlocks(24, new ECB(4, 12), new ECB(4, 13))),
				new Version(10, new int[3] { 6, 28, 50 }, new ECBlocks(18, new ECB(2, 68), new ECB(2, 69)), new ECBlocks(26, new ECB(4, 43), new ECB(1, 44)), new ECBlocks(24, new ECB(6, 19), new ECB(2, 20)), new ECBlocks(28, new ECB(6, 15), new ECB(2, 16))),
				new Version(11, new int[3] { 6, 30, 54 }, new ECBlocks(20, new ECB(4, 81)), new ECBlocks(30, new ECB(1, 50), new ECB(4, 51)), new ECBlocks(28, new ECB(4, 22), new ECB(4, 23)), new ECBlocks(24, new ECB(3, 12), new ECB(8, 13))),
				new Version(12, new int[3] { 6, 32, 58 }, new ECBlocks(24, new ECB(2, 92), new ECB(2, 93)), new ECBlocks(22, new ECB(6, 36), new ECB(2, 37)), new ECBlocks(26, new ECB(4, 20), new ECB(6, 21)), new ECBlocks(28, new ECB(7, 14), new ECB(4, 15))),
				new Version(13, new int[3] { 6, 34, 62 }, new ECBlocks(26, new ECB(4, 107)), new ECBlocks(22, new ECB(8, 37), new ECB(1, 38)), new ECBlocks(24, new ECB(8, 20), new ECB(4, 21)), new ECBlocks(22, new ECB(12, 11), new ECB(4, 12))),
				new Version(14, new int[4] { 6, 26, 46, 66 }, new ECBlocks(30, new ECB(3, 115), new ECB(1, 116)), new ECBlocks(24, new ECB(4, 40), new ECB(5, 41)), new ECBlocks(20, new ECB(11, 16), new ECB(5, 17)), new ECBlocks(24, new ECB(11, 12), new ECB(5, 13))),
				new Version(15, new int[4] { 6, 26, 48, 70 }, new ECBlocks(22, new ECB(5, 87), new ECB(1, 88)), new ECBlocks(24, new ECB(5, 41), new ECB(5, 42)), new ECBlocks(30, new ECB(5, 24), new ECB(7, 25)), new ECBlocks(24, new ECB(11, 12), new ECB(7, 13))),
				new Version(16, new int[4] { 6, 26, 50, 74 }, new ECBlocks(24, new ECB(5, 98), new ECB(1, 99)), new ECBlocks(28, new ECB(7, 45), new ECB(3, 46)), new ECBlocks(24, new ECB(15, 19), new ECB(2, 20)), new ECBlocks(30, new ECB(3, 15), new ECB(13, 16))),
				new Version(17, new int[4] { 6, 30, 54, 78 }, new ECBlocks(28, new ECB(1, 107), new ECB(5, 108)), new ECBlocks(28, new ECB(10, 46), new ECB(1, 47)), new ECBlocks(28, new ECB(1, 22), new ECB(15, 23)), new ECBlocks(28, new ECB(2, 14), new ECB(17, 15))),
				new Version(18, new int[4] { 6, 30, 56, 82 }, new ECBlocks(30, new ECB(5, 120), new ECB(1, 121)), new ECBlocks(26, new ECB(9, 43), new ECB(4, 44)), new ECBlocks(28, new ECB(17, 22), new ECB(1, 23)), new ECBlocks(28, new ECB(2, 14), new ECB(19, 15))),
				new Version(19, new int[4] { 6, 30, 58, 86 }, new ECBlocks(28, new ECB(3, 113), new ECB(4, 114)), new ECBlocks(26, new ECB(3, 44), new ECB(11, 45)), new ECBlocks(26, new ECB(17, 21), new ECB(4, 22)), new ECBlocks(26, new ECB(9, 13), new ECB(16, 14))),
				new Version(20, new int[4] { 6, 34, 62, 90 }, new ECBlocks(28, new ECB(3, 107), new ECB(5, 108)), new ECBlocks(26, new ECB(3, 41), new ECB(13, 42)), new ECBlocks(30, new ECB(15, 24), new ECB(5, 25)), new ECBlocks(28, new ECB(15, 15), new ECB(10, 16))),
				new Version(21, new int[5] { 6, 28, 50, 72, 94 }, new ECBlocks(28, new ECB(4, 116), new ECB(4, 117)), new ECBlocks(26, new ECB(17, 42)), new ECBlocks(28, new ECB(17, 22), new ECB(6, 23)), new ECBlocks(30, new ECB(19, 16), new ECB(6, 17))),
				new Version(22, new int[5] { 6, 26, 50, 74, 98 }, new ECBlocks(28, new ECB(2, 111), new ECB(7, 112)), new ECBlocks(28, new ECB(17, 46)), new ECBlocks(30, new ECB(7, 24), new ECB(16, 25)), new ECBlocks(24, new ECB(34, 13))),
				new Version(23, new int[5] { 6, 30, 54, 78, 102 }, new ECBlocks(30, new ECB(4, 121), new ECB(5, 122)), new ECBlocks(28, new ECB(4, 47), new ECB(14, 48)), new ECBlocks(30, new ECB(11, 24), new ECB(14, 25)), new ECBlocks(30, new ECB(16, 15), new ECB(14, 16))),
				new Version(24, new int[5] { 6, 28, 54, 80, 106 }, new ECBlocks(30, new ECB(6, 117), new ECB(4, 118)), new ECBlocks(28, new ECB(6, 45), new ECB(14, 46)), new ECBlocks(30, new ECB(11, 24), new ECB(16, 25)), new ECBlocks(30, new ECB(30, 16), new ECB(2, 17))),
				new Version(25, new int[5] { 6, 32, 58, 84, 110 }, new ECBlocks(26, new ECB(8, 106), new ECB(4, 107)), new ECBlocks(28, new ECB(8, 47), new ECB(13, 48)), new ECBlocks(30, new ECB(7, 24), new ECB(22, 25)), new ECBlocks(30, new ECB(22, 15), new ECB(13, 16))),
				new Version(26, new int[5] { 6, 30, 58, 86, 114 }, new ECBlocks(28, new ECB(10, 114), new ECB(2, 115)), new ECBlocks(28, new ECB(19, 46), new ECB(4, 47)), new ECBlocks(28, new ECB(28, 22), new ECB(6, 23)), new ECBlocks(30, new ECB(33, 16), new ECB(4, 17))),
				new Version(27, new int[5] { 6, 34, 62, 90, 118 }, new ECBlocks(30, new ECB(8, 122), new ECB(4, 123)), new ECBlocks(28, new ECB(22, 45), new ECB(3, 46)), new ECBlocks(30, new ECB(8, 23), new ECB(26, 24)), new ECBlocks(30, new ECB(12, 15), new ECB(28, 16))),
				new Version(28, new int[6] { 6, 26, 50, 74, 98, 122 }, new ECBlocks(30, new ECB(3, 117), new ECB(10, 118)), new ECBlocks(28, new ECB(3, 45), new ECB(23, 46)), new ECBlocks(30, new ECB(4, 24), new ECB(31, 25)), new ECBlocks(30, new ECB(11, 15), new ECB(31, 16))),
				new Version(29, new int[6] { 6, 30, 54, 78, 102, 126 }, new ECBlocks(30, new ECB(7, 116), new ECB(7, 117)), new ECBlocks(28, new ECB(21, 45), new ECB(7, 46)), new ECBlocks(30, new ECB(1, 23), new ECB(37, 24)), new ECBlocks(30, new ECB(19, 15), new ECB(26, 16))),
				new Version(30, new int[6] { 6, 26, 52, 78, 104, 130 }, new ECBlocks(30, new ECB(5, 115), new ECB(10, 116)), new ECBlocks(28, new ECB(19, 47), new ECB(10, 48)), new ECBlocks(30, new ECB(15, 24), new ECB(25, 25)), new ECBlocks(30, new ECB(23, 15), new ECB(25, 16))),
				new Version(31, new int[6] { 6, 30, 56, 82, 108, 134 }, new ECBlocks(30, new ECB(13, 115), new ECB(3, 116)), new ECBlocks(28, new ECB(2, 46), new ECB(29, 47)), new ECBlocks(30, new ECB(42, 24), new ECB(1, 25)), new ECBlocks(30, new ECB(23, 15), new ECB(28, 16))),
				new Version(32, new int[6] { 6, 34, 60, 86, 112, 138 }, new ECBlocks(30, new ECB(17, 115)), new ECBlocks(28, new ECB(10, 46), new ECB(23, 47)), new ECBlocks(30, new ECB(10, 24), new ECB(35, 25)), new ECBlocks(30, new ECB(19, 15), new ECB(35, 16))),
				new Version(33, new int[6] { 6, 30, 58, 86, 114, 142 }, new ECBlocks(30, new ECB(17, 115), new ECB(1, 116)), new ECBlocks(28, new ECB(14, 46), new ECB(21, 47)), new ECBlocks(30, new ECB(29, 24), new ECB(19, 25)), new ECBlocks(30, new ECB(11, 15), new ECB(46, 16))),
				new Version(34, new int[6] { 6, 34, 62, 90, 118, 146 }, new ECBlocks(30, new ECB(13, 115), new ECB(6, 116)), new ECBlocks(28, new ECB(14, 46), new ECB(23, 47)), new ECBlocks(30, new ECB(44, 24), new ECB(7, 25)), new ECBlocks(30, new ECB(59, 16), new ECB(1, 17))),
				new Version(35, new int[7] { 6, 30, 54, 78, 102, 126, 150 }, new ECBlocks(30, new ECB(12, 121), new ECB(7, 122)), new ECBlocks(28, new ECB(12, 47), new ECB(26, 48)), new ECBlocks(30, new ECB(39, 24), new ECB(14, 25)), new ECBlocks(30, new ECB(22, 15), new ECB(41, 16))),
				new Version(36, new int[7] { 6, 24, 50, 76, 102, 128, 154 }, new ECBlocks(30, new ECB(6, 121), new ECB(14, 122)), new ECBlocks(28, new ECB(6, 47), new ECB(34, 48)), new ECBlocks(30, new ECB(46, 24), new ECB(10, 25)), new ECBlocks(30, new ECB(2, 15), new ECB(64, 16))),
				new Version(37, new int[7] { 6, 28, 54, 80, 106, 132, 158 }, new ECBlocks(30, new ECB(17, 122), new ECB(4, 123)), new ECBlocks(28, new ECB(29, 46), new ECB(14, 47)), new ECBlocks(30, new ECB(49, 24), new ECB(10, 25)), new ECBlocks(30, new ECB(24, 15), new ECB(46, 16))),
				new Version(38, new int[7] { 6, 32, 58, 84, 110, 136, 162 }, new ECBlocks(30, new ECB(4, 122), new ECB(18, 123)), new ECBlocks(28, new ECB(13, 46), new ECB(32, 47)), new ECBlocks(30, new ECB(48, 24), new ECB(14, 25)), new ECBlocks(30, new ECB(42, 15), new ECB(32, 16))),
				new Version(39, new int[7] { 6, 26, 54, 82, 110, 138, 166 }, new ECBlocks(30, new ECB(20, 117), new ECB(4, 118)), new ECBlocks(28, new ECB(40, 47), new ECB(7, 48)), new ECBlocks(30, new ECB(43, 24), new ECB(22, 25)), new ECBlocks(30, new ECB(10, 15), new ECB(67, 16))),
				new Version(40, new int[7] { 6, 30, 58, 86, 114, 142, 170 }, new ECBlocks(30, new ECB(19, 118), new ECB(6, 119)), new ECBlocks(28, new ECB(18, 47), new ECB(31, 48)), new ECBlocks(30, new ECB(34, 24), new ECB(34, 25)), new ECBlocks(30, new ECB(20, 15), new ECB(61, 16)))
			};
		}
	}
	public sealed class AlignmentPattern : ResultPoint
	{
		private float estimatedModuleSize;

		internal AlignmentPattern(float posX, float posY, float estimatedModuleSize)
			: base(posX, posY)
		{
			this.estimatedModuleSize = estimatedModuleSize;
		}

		internal bool aboutEquals(float moduleSize, float i, float j)
		{
			if (Math.Abs(i - Y) <= moduleSize && Math.Abs(j - X) <= moduleSize)
			{
				float num = Math.Abs(moduleSize - estimatedModuleSize);
				if (!(num <= 1f))
				{
					return num <= estimatedModuleSize;
				}
				return true;
			}
			return false;
		}

		internal AlignmentPattern combineEstimate(float i, float j, float newModuleSize)
		{
			float posX = (X + j) / 2f;
			float posY = (Y + i) / 2f;
			float num = (estimatedModuleSize + newModuleSize) / 2f;
			return new AlignmentPattern(posX, posY, num);
		}
	}
	internal sealed class AlignmentPatternFinder
	{
		private readonly BitMatrix image;

		private readonly IList<AlignmentPattern> possibleCenters;

		private readonly int startX;

		private readonly int startY;

		private readonly int width;

		private readonly int height;

		private readonly float moduleSize;

		private readonly int[] crossCheckStateCount;

		private readonly ResultPointCallback resultPointCallback;

		internal AlignmentPatternFinder(BitMatrix image, int startX, int startY, int width, int height, float moduleSize, ResultPointCallback resultPointCallback)
		{
			this.image = image;
			possibleCenters = new List<AlignmentPattern>(5);
			this.startX = startX;
			this.startY = startY;
			this.width = width;
			this.height = height;
			this.moduleSize = moduleSize;
			crossCheckStateCount = new int[3];
			this.resultPointCallback = resultPointCallback;
		}

		internal AlignmentPattern find()
		{
			int num = startX;
			int num2 = height;
			int num3 = num + width;
			int num4 = startY + (num2 >> 1);
			int[] array = new int[3];
			for (int i = 0; i < num2; i++)
			{
				int num5 = num4 + (((i & 1) == 0) ? (i + 1 >> 1) : (-(i + 1 >> 1)));
				array[0] = 0;
				array[1] = 0;
				array[2] = 0;
				int j;
				for (j = num; j < num3 && !image[j, num5]; j++)
				{
				}
				int num6 = 0;
				for (; j < num3; j++)
				{
					if (image[j, num5])
					{
						switch (num6)
						{
						case 1:
							array[1]++;
							break;
						case 2:
							if (foundPatternCross(array))
							{
								AlignmentPattern alignmentPattern = handlePossibleCenter(array, num5, j);
								if (alignmentPattern != null)
								{
									return alignmentPattern;
								}
							}
							array[0] = array[2];
							array[1] = 1;
							array[2] = 0;
							num6 = 1;
							break;
						default:
							array[++num6]++;
							break;
						}
					}
					else
					{
						if (num6 == 1)
						{
							num6++;
						}
						array[num6]++;
					}
				}
				if (foundPatternCross(array))
				{
					AlignmentPattern alignmentPattern2 = handlePossibleCenter(array, num5, num3);
					if (alignmentPattern2 != null)
					{
						return alignmentPattern2;
					}
				}
			}
			if (possibleCenters.Count != 0)
			{
				return possibleCenters[0];
			}
			return null;
		}

		private static float? centerFromEnd(int[] stateCount, int end)
		{
			float num = (float)(end - stateCount[2]) - (float)stateCount[1] / 2f;
			if (float.IsNaN(num))
			{
				return null;
			}
			return num;
		}

		private bool foundPatternCross(int[] stateCount)
		{
			float num = moduleSize / 2f;
			for (int i = 0; i < 3; i++)
			{
				if (Math.Abs(moduleSize - (float)stateCount[i]) >= num)
				{
					return false;
				}
			}
			return true;
		}

		private float? crossCheckVertical(int startI, int centerJ, int maxCount, int originalStateCountTotal)
		{
			int num = image.Height;
			int[] array = crossCheckStateCount;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			int num2 = startI;
			while (num2 >= 0 && image[centerJ, num2] && array[1] <= maxCount)
			{
				array[1]++;
				num2--;
			}
			if (num2 < 0 || array[1] > maxCount)
			{
				return null;
			}
			while (num2 >= 0 && !image[centerJ, num2] && array[0] <= maxCount)
			{
				array[0]++;
				num2--;
			}
			if (array[0] > maxCount)
			{
				return null;
			}
			for (num2 = startI + 1; num2 < num && image[centerJ, num2]; num2++)
			{
				if (array[1] > maxCount)
				{
					break;
				}
				array[1]++;
			}
			if (num2 == num || array[1] > maxCount)
			{
				return null;
			}
			for (; num2 < num && !image[centerJ, num2]; num2++)
			{
				if (array[2] > maxCount)
				{
					break;
				}
				array[2]++;
			}
			if (array[2] > maxCount)
			{
				return null;
			}
			int num3 = array[0] + array[1] + array[2];
			if (5 * Math.Abs(num3 - originalStateCountTotal) >= 2 * originalStateCountTotal)
			{
				return null;
			}
			if (!foundPatternCross(array))
			{
				return null;
			}
			return centerFromEnd(array, num2);
		}

		private AlignmentPattern handlePossibleCenter(int[] stateCount, int i, int j)
		{
			int originalStateCountTotal = stateCount[0] + stateCount[1] + stateCount[2];
			float? num = centerFromEnd(stateCount, j);
			if (!num.HasValue)
			{
				return null;
			}
			float? num2 = crossCheckVertical(i, (int)num.Value, 2 * stateCount[1], originalStateCountTotal);
			if (num2.HasValue)
			{
				float num3 = (float)(stateCount[0] + stateCount[1] + stateCount[2]) / 3f;
				foreach (AlignmentPattern possibleCenter in possibleCenters)
				{
					if (possibleCenter.aboutEquals(num3, num2.Value, num.Value))
					{
						return possibleCenter.combineEstimate(num2.Value, num.Value, num3);
					}
				}
				AlignmentPattern alignmentPattern = new AlignmentPattern(num.Value, num2.Value, num3);
				possibleCenters.Add(alignmentPattern);
				if (resultPointCallback != null)
				{
					resultPointCallback(alignmentPattern);
				}
			}
			return null;
		}
	}
	public class Detector
	{
		private readonly BitMatrix image;

		private ResultPointCallback resultPointCallback;

		protected internal virtual BitMatrix Image => image;

		protected internal virtual ResultPointCallback ResultPointCallback => resultPointCallback;

		public Detector(BitMatrix image)
		{
			this.image = image;
		}

		public virtual DetectorResult detect()
		{
			return detect(null);
		}

		public virtual DetectorResult detect(IDictionary<DecodeHintType, object> hints)
		{
			resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			FinderPatternInfo finderPatternInfo = new FinderPatternFinder(image, resultPointCallback).find(hints);
			if (finderPatternInfo == null)
			{
				return null;
			}
			return processFinderPatternInfo(finderPatternInfo);
		}

		protected internal virtual DetectorResult processFinderPatternInfo(FinderPatternInfo info)
		{
			FinderPattern topLeft = info.TopLeft;
			FinderPattern topRight = info.TopRight;
			FinderPattern bottomLeft = info.BottomLeft;
			float num = calculateModuleSize(topLeft, topRight, bottomLeft);
			if (num < 1f)
			{
				return null;
			}
			if (!computeDimension(topLeft, topRight, bottomLeft, num, out var dimension))
			{
				return null;
			}
			Version provisionalVersionForDimension = Version.getProvisionalVersionForDimension(dimension);
			if (provisionalVersionForDimension == null)
			{
				return null;
			}
			int num2 = provisionalVersionForDimension.DimensionForVersion - 7;
			AlignmentPattern alignmentPattern = null;
			if (provisionalVersionForDimension.AlignmentPatternCenters.Length != 0)
			{
				float num3 = topRight.X - topLeft.X + bottomLeft.X;
				float num4 = topRight.Y - topLeft.Y + bottomLeft.Y;
				float num5 = 1f - 3f / (float)num2;
				int estAlignmentX = (int)(topLeft.X + num5 * (num3 - topLeft.X));
				int estAlignmentY = (int)(topLeft.Y + num5 * (num4 - topLeft.Y));
				for (int num6 = 4; num6 <= 16; num6 <<= 1)
				{
					alignmentPattern = findAlignmentInRegion(num, estAlignmentX, estAlignmentY, num6);
					if (alignmentPattern != null)
					{
						break;
					}
				}
			}
			PerspectiveTransform transform = createTransform(topLeft, topRight, bottomLeft, alignmentPattern, dimension);
			BitMatrix bitMatrix = sampleGrid(image, transform, dimension);
			if (bitMatrix == null)
			{
				return null;
			}
			ResultPoint[] points = ((alignmentPattern != null) ? new ResultPoint[4] { bottomLeft, topLeft, topRight, alignmentPattern } : new ResultPoint[3] { bottomLeft, topLeft, topRight });
			return new DetectorResult(bitMatrix, points);
		}

		private static PerspectiveTransform createTransform(ResultPoint topLeft, ResultPoint topRight, ResultPoint bottomLeft, ResultPoint alignmentPattern, int dimension)
		{
			float num = (float)dimension - 3.5f;
			float x2p;
			float y2p;
			float x;
			float y;
			if (alignmentPattern != null)
			{
				x2p = alignmentPattern.X;
				y2p = alignmentPattern.Y;
				x = (y = num - 3f);
			}
			else
			{
				x2p = topRight.X - topLeft.X + bottomLeft.X;
				y2p = topRight.Y - topLeft.Y + bottomLeft.Y;
				x = (y = num);
			}
			return PerspectiveTransform.quadrilateralToQuadrilateral(3.5f, 3.5f, num, 3.5f, x, y, 3.5f, num, topLeft.X, topLeft.Y, topRight.X, topRight.Y, x2p, y2p, bottomLeft.X, bottomLeft.Y);
		}

		private static BitMatrix sampleGrid(BitMatrix image, PerspectiveTransform transform, int dimension)
		{
			return GridSampler.Instance.sampleGrid(image, dimension, dimension, transform);
		}

		private static bool computeDimension(ResultPoint topLeft, ResultPoint topRight, ResultPoint bottomLeft, float moduleSize, out int dimension)
		{
			int num = MathUtils.round(ResultPoint.distance(topLeft, topRight) / moduleSize);
			int num2 = MathUtils.round(ResultPoint.distance(topLeft, bottomLeft) / moduleSize);
			dimension = (num + num2 >> 1) + 7;
			switch (dimension & 3)
			{
			case 0:
				dimension++;
				break;
			case 2:
				dimension--;
				break;
			case 3:
				return true;
			}
			return true;
		}

		protected internal virtual float calculateModuleSize(ResultPoint topLeft, ResultPoint topRight, ResultPoint bottomLeft)
		{
			return (calculateModuleSizeOneWay(topLeft, topRight) + calculateModuleSizeOneWay(topLeft, bottomLeft)) / 2f;
		}

		private float calculateModuleSizeOneWay(ResultPoint pattern, ResultPoint otherPattern)
		{
			float num = sizeOfBlackWhiteBlackRunBothWays((int)pattern.X, (int)pattern.Y, (int)otherPattern.X, (int)otherPattern.Y);
			float num2 = sizeOfBlackWhiteBlackRunBothWays((int)otherPattern.X, (int)otherPattern.Y, (int)pattern.X, (int)pattern.Y);
			if (float.IsNaN(num))
			{
				return num2 / 7f;
			}
			if (float.IsNaN(num2))
			{
				return num / 7f;
			}
			return (num + num2) / 14f;
		}

		private float sizeOfBlackWhiteBlackRunBothWays(int fromX, int fromY, int toX, int toY)
		{
			float num = sizeOfBlackWhiteBlackRun(fromX, fromY, toX, toY);
			float num2 = 1f;
			int num3 = fromX - (toX - fromX);
			if (num3 < 0)
			{
				num2 = (float)fromX / (float)(fromX - num3);
				num3 = 0;
			}
			else if (num3 >= image.Width)
			{
				num2 = (float)(image.Width - 1 - fromX) / (float)(num3 - fromX);
				num3 = image.Width - 1;
			}
			int num4 = (int)((float)fromY - (float)(toY - fromY) * num2);
			num2 = 1f;
			if (num4 < 0)
			{
				num2 = (float)fromY / (float)(fromY - num4);
				num4 = 0;
			}
			else if (num4 >= image.Height)
			{
				num2 = (float)(image.Height - 1 - fromY) / (float)(num4 - fromY);
				num4 = image.Height - 1;
			}
			num3 = (int)((float)fromX + (float)(num3 - fromX) * num2);
			return num + sizeOfBlackWhiteBlackRun(fromX, fromY, num3, num4) - 1f;
		}

		private float sizeOfBlackWhiteBlackRun(int fromX, int fromY, int toX, int toY)
		{
			bool flag = Math.Abs(toY - fromY) > Math.Abs(toX - fromX);
			if (flag)
			{
				int num = fromX;
				fromX = fromY;
				fromY = num;
				int num2 = toX;
				toX = toY;
				toY = num2;
			}
			int num3 = Math.Abs(toX - fromX);
			int num4 = Math.Abs(toY - fromY);
			int num5 = -num3 >> 1;
			int num6 = ((fromX < toX) ? 1 : (-1));
			int num7 = ((fromY < toY) ? 1 : (-1));
			int num8 = 0;
			int num9 = toX + num6;
			int i = fromX;
			int num10 = fromY;
			for (; i != num9; i += num6)
			{
				int x = (flag ? num10 : i);
				int y = (flag ? i : num10);
				if (num8 == 1 == image[x, y])
				{
					if (num8 == 2)
					{
						return MathUtils.distance(i, num10, fromX, fromY);
					}
					num8++;
				}
				num5 += num4;
				if (num5 > 0)
				{
					if (num10 == toY)
					{
						break;
					}
					num10 += num7;
					num5 -= num3;
				}
			}
			if (num8 == 2)
			{
				return MathUtils.distance(toX + num6, toY, fromX, fromY);
			}
			return 0f / 0f;
		}

		protected AlignmentPattern findAlignmentInRegion(float overallEstModuleSize, int estAlignmentX, int estAlignmentY, float allowanceFactor)
		{
			int num = (int)(allowanceFactor * overallEstModuleSize);
			int num2 = Math.Max(0, estAlignmentX - num);
			int num3 = Math.Min(image.Width - 1, estAlignmentX + num);
			if ((float)(num3 - num2) < overallEstModuleSize * 3f)
			{
				return null;
			}
			int num4 = Math.Max(0, estAlignmentY - num);
			int num5 = Math.Min(image.Height - 1, estAlignmentY + num);
			return new AlignmentPatternFinder(image, num2, num4, num3 - num2, num5 - num4, overallEstModuleSize, resultPointCallback).find();
		}
	}
	public sealed class FinderPattern : ResultPoint
	{
		private readonly float estimatedModuleSize;

		private int count;

		public float EstimatedModuleSize => estimatedModuleSize;

		internal int Count => count;

		internal FinderPattern(float posX, float posY, float estimatedModuleSize)
			: this(posX, posY, estimatedModuleSize, 1)
		{
			this.estimatedModuleSize = estimatedModuleSize;
			count = 1;
		}

		internal FinderPattern(float posX, float posY, float estimatedModuleSize, int count)
			: base(posX, posY)
		{
			this.estimatedModuleSize = estimatedModuleSize;
			this.count = count;
		}

		internal bool aboutEquals(float moduleSize, float i, float j)
		{
			if (Math.Abs(i - Y) <= moduleSize && Math.Abs(j - X) <= moduleSize)
			{
				float num = Math.Abs(moduleSize - estimatedModuleSize);
				if (!(num <= 1f))
				{
					return num <= estimatedModuleSize;
				}
				return true;
			}
			return false;
		}

		internal FinderPattern combineEstimate(float i, float j, float newModuleSize)
		{
			int num = count + 1;
			float posX = ((float)count * X + j) / (float)num;
			float posY = ((float)count * Y + i) / (float)num;
			float num2 = ((float)count * estimatedModuleSize + newModuleSize) / (float)num;
			return new FinderPattern(posX, posY, num2, num);
		}
	}
	public class FinderPatternFinder
	{
		private sealed class FurthestFromAverageComparator : IComparer<FinderPattern>
		{
			private readonly float average;

			public FurthestFromAverageComparator(float f)
			{
				average = f;
			}

			public int Compare(FinderPattern x, FinderPattern y)
			{
				float num = Math.Abs(y.EstimatedModuleSize - average);
				float num2 = Math.Abs(x.EstimatedModuleSize - average);
				if (!(num < num2))
				{
					if (!(num > num2))
					{
						return 0;
					}
					return 1;
				}
				return -1;
			}
		}

		private sealed class CenterComparator : IComparer<FinderPattern>
		{
			private readonly float average;

			public CenterComparator(float f)
			{
				average = f;
			}

			public int Compare(FinderPattern x, FinderPattern y)
			{
				if (y.Count == x.Count)
				{
					float num = Math.Abs(y.EstimatedModuleSize - average);
					float num2 = Math.Abs(x.EstimatedModuleSize - average);
					if (!(num < num2))
					{
						if (!(num > num2))
						{
							return 0;
						}
						return -1;
					}
					return 1;
				}
				return y.Count - x.Count;
			}
		}

		private const int CENTER_QUORUM = 2;

		protected internal const int MIN_SKIP = 3;

		protected internal const int MAX_MODULES = 97;

		private const int INTEGER_MATH_SHIFT = 8;

		private readonly BitMatrix image;

		private List<FinderPattern> possibleCenters;

		private bool hasSkipped;

		private readonly int[] crossCheckStateCount;

		private readonly ResultPointCallback resultPointCallback;

		protected internal virtual BitMatrix Image => image;

		protected internal virtual List<FinderPattern> PossibleCenters => possibleCenters;

		private int[] CrossCheckStateCount
		{
			get
			{
				clearCounts(crossCheckStateCount);
				return crossCheckStateCount;
			}
		}

		public FinderPatternFinder(BitMatrix image)
			: this(image, null)
		{
		}

		public FinderPatternFinder(BitMatrix image, ResultPointCallback resultPointCallback)
		{
			this.image = image;
			possibleCenters = new List<FinderPattern>();
			crossCheckStateCount = new int[5];
			this.resultPointCallback = resultPointCallback;
		}

		internal virtual FinderPatternInfo find(IDictionary<DecodeHintType, object> hints)
		{
			bool flag = hints?.ContainsKey(DecodeHintType.TRY_HARDER) ?? false;
			int height = image.Height;
			int width = image.Width;
			int num = 3 * height / 388;
			if (num < 3 || flag)
			{
				num = 3;
			}
			bool flag2 = false;
			int[] array = new int[5];
			for (int i = num - 1; i < height; i += num)
			{
				if (flag2)
				{
					break;
				}
				clearCounts(array);
				int num2 = 0;
				for (int j = 0; j < width; j++)
				{
					if (image[j, i])
					{
						if ((num2 & 1) == 1)
						{
							num2++;
						}
						array[num2]++;
					}
					else if ((num2 & 1) == 0)
					{
						if (num2 == 4)
						{
							if (foundPatternCross(array))
							{
								if (handlePossibleCenter(array, i, j))
								{
									num = 2;
									if (hasSkipped)
									{
										flag2 = haveMultiplyConfirmedCenters();
									}
									else
									{
										int num3 = findRowSkip();
										if (num3 > array[2])
										{
											i += num3 - array[2] - num;
											j = width - 1;
										}
									}
									num2 = 0;
									clearCounts(array);
								}
								else
								{
									shiftCounts2(array);
									num2 = 3;
								}
							}
							else
							{
								shiftCounts2(array);
								num2 = 3;
							}
						}
						else
						{
							array[++num2]++;
						}
					}
					else
					{
						array[num2]++;
					}
				}
				if (foundPatternCross(array) && handlePossibleCenter(array, i, width))
				{
					num = array[0];
					if (hasSkipped)
					{
						flag2 = haveMultiplyConfirmedCenters();
					}
				}
			}
			FinderPattern[] array2 = selectBestPatterns();
			if (array2 == null)
			{
				return null;
			}
			ResultPoint[] patterns = array2;
			ResultPoint.orderBestPatterns(patterns);
			return new FinderPatternInfo(array2);
		}

		private static float? centerFromEnd(int[] stateCount, int end)
		{
			float num = (float)(end - stateCount[4] - stateCount[3]) - (float)stateCount[2] / 2f;
			if (float.IsNaN(num))
			{
				return null;
			}
			return num;
		}

		protected internal static bool foundPatternCross(int[] stateCount)
		{
			int num = 0;
			for (int i = 0; i < 5; i++)
			{
				int num2 = stateCount[i];
				if (num2 == 0)
				{
					return false;
				}
				num += num2;
			}
			if (num < 7)
			{
				return false;
			}
			int num3 = (num << 8) / 7;
			int num4 = num3 / 2;
			if (Math.Abs(num3 - (stateCount[0] << 8)) < num4 && Math.Abs(num3 - (stateCount[1] << 8)) < num4 && Math.Abs(3 * num3 - (stateCount[2] << 8)) < 3 * num4 && Math.Abs(num3 - (stateCount[3] << 8)) < num4)
			{
				return Math.Abs(num3 - (stateCount[4] << 8)) < num4;
			}
			return false;
		}

		protected static bool foundPatternDiagonal(int[] stateCount)
		{
			int num = 0;
			for (int i = 0; i < 5; i++)
			{
				int num2 = stateCount[i];
				if (num2 == 0)
				{
					return false;
				}
				num += num2;
			}
			if (num < 7)
			{
				return false;
			}
			float num3 = (float)num / 7f;
			float num4 = num3 / 1.333f;
			if (Math.Abs(num3 - (float)stateCount[0]) < num4 && Math.Abs(num3 - (float)stateCount[1]) < num4 && Math.Abs(3f * num3 - (float)stateCount[2]) < 3f * num4 && Math.Abs(num3 - (float)stateCount[3]) < num4)
			{
				return Math.Abs(num3 - (float)stateCount[4]) < num4;
			}
			return false;
		}

		protected void clearCounts(int[] counts)
		{
			for (int i = 0; i < counts.Length; i++)
			{
				counts[i] = 0;
			}
		}

		protected void shiftCounts2(int[] stateCount)
		{
			stateCount[0] = stateCount[2];
			stateCount[1] = stateCount[3];
			stateCount[2] = stateCount[4];
			stateCount[3] = 1;
			stateCount[4] = 0;
		}

		private bool crossCheckDiagonal(int centerI, int centerJ)
		{
			int[] array = CrossCheckStateCount;
			int i;
			for (i = 0; centerI >= i && centerJ >= i && image[centerJ - i, centerI - i]; i++)
			{
				array[2]++;
			}
			if (array[2] == 0)
			{
				return false;
			}
			for (; centerI >= i && centerJ >= i && !image[centerJ - i, centerI - i]; i++)
			{
				array[1]++;
			}
			if (array[1] == 0)
			{
				return false;
			}
			for (; centerI >= i && centerJ >= i && image[centerJ - i, centerI - i]; i++)
			{
				array[0]++;
			}
			if (array[0] == 0)
			{
				return false;
			}
			int height = image.Height;
			int width = image.Width;
			for (i = 1; centerI + i < height && centerJ + i < width && image[centerJ + i, centerI + i]; i++)
			{
				array[2]++;
			}
			for (; centerI + i < height && centerJ + i < width && !image[centerJ + i, centerI + i]; i++)
			{
				array[3]++;
			}
			if (array[3] == 0)
			{
				return false;
			}
			for (; centerI + i < height && centerJ + i < width && image[centerJ + i, centerI + i]; i++)
			{
				array[4]++;
			}
			if (array[4] == 0)
			{
				return false;
			}
			return foundPatternDiagonal(array);
		}

		private float? crossCheckVertical(int startI, int centerJ, int maxCount, int originalStateCountTotal)
		{
			int height = image.Height;
			int[] array = CrossCheckStateCount;
			int num = startI;
			while (num >= 0 && image[centerJ, num])
			{
				array[2]++;
				num--;
			}
			if (num < 0)
			{
				return null;
			}
			while (num >= 0 && !image[centerJ, num] && array[1] <= maxCount)
			{
				array[1]++;
				num--;
			}
			if (num < 0 || array[1] > maxCount)
			{
				return null;
			}
			while (num >= 0 && image[centerJ, num] && array[0] <= maxCount)
			{
				array[0]++;
				num--;
			}
			if (array[0] > maxCount)
			{
				return null;
			}
			for (num = startI + 1; num < height && image[centerJ, num]; num++)
			{
				array[2]++;
			}
			if (num == height)
			{
				return null;
			}
			for (; num < height && !image[centerJ, num]; num++)
			{
				if (array[3] >= maxCount)
				{
					break;
				}
				array[3]++;
			}
			if (num == height || array[3] >= maxCount)
			{
				return null;
			}
			for (; num < height && image[centerJ, num]; num++)
			{
				if (array[4] >= maxCount)
				{
					break;
				}
				array[4]++;
			}
			if (array[4] >= maxCount)
			{
				return null;
			}
			int num2 = array[0] + array[1] + array[2] + array[3] + array[4];
			if (5 * Math.Abs(num2 - originalStateCountTotal) >= 2 * originalStateCountTotal)
			{
				return null;
			}
			if (!foundPatternCross(array))
			{
				return null;
			}
			return centerFromEnd(array, num);
		}

		private float? crossCheckHorizontal(int startJ, int centerI, int maxCount, int originalStateCountTotal)
		{
			int width = image.Width;
			int[] array = CrossCheckStateCount;
			int num = startJ;
			while (num >= 0 && image[num, centerI])
			{
				array[2]++;
				num--;
			}
			if (num < 0)
			{
				return null;
			}
			while (num >= 0 && !image[num, centerI] && array[1] <= maxCount)
			{
				array[1]++;
				num--;
			}
			if (num < 0 || array[1] > maxCount)
			{
				return null;
			}
			while (num >= 0 && image[num, centerI] && array[0] <= maxCount)
			{
				array[0]++;
				num--;
			}
			if (array[0] > maxCount)
			{
				return null;
			}
			for (num = startJ + 1; num < width && image[num, centerI]; num++)
			{
				array[2]++;
			}
			if (num == width)
			{
				return null;
			}
			for (; num < width && !image[num, centerI]; num++)
			{
				if (array[3] >= maxCount)
				{
					break;
				}
				array[3]++;
			}
			if (num == width || array[3] >= maxCount)
			{
				return null;
			}
			for (; num < width && image[num, centerI]; num++)
			{
				if (array[4] >= maxCount)
				{
					break;
				}
				array[4]++;
			}
			if (array[4] >= maxCount)
			{
				return null;
			}
			int num2 = array[0] + array[1] + array[2] + array[3] + array[4];
			if (5 * Math.Abs(num2 - originalStateCountTotal) >= originalStateCountTotal)
			{
				return null;
			}
			if (!foundPatternCross(array))
			{
				return null;
			}
			return centerFromEnd(array, num);
		}

		[Obsolete("only exists for backwards compatibility")]
		protected bool handlePossibleCenter(int[] stateCount, int i, int j, bool pureBarcode)
		{
			return handlePossibleCenter(stateCount, i, j);
		}

		protected bool handlePossibleCenter(int[] stateCount, int i, int j)
		{
			int num = stateCount[0] + stateCount[1] + stateCount[2] + stateCount[3] + stateCount[4];
			float? num2 = centerFromEnd(stateCount, j);
			if (!num2.HasValue)
			{
				return false;
			}
			float? num3 = crossCheckVertical(i, (int)num2.Value, stateCount[2], num);
			if (num3.HasValue)
			{
				num2 = crossCheckHorizontal((int)num2.Value, (int)num3.Value, stateCount[2], num);
				if (num2.HasValue && crossCheckDiagonal((int)num3.Value, (int)num2.Value))
				{
					float num4 = (float)num / 7f;
					bool flag = false;
					for (int k = 0; k < possibleCenters.Count; k++)
					{
						FinderPattern finderPattern = possibleCenters[k];
						if (finderPattern.aboutEquals(num4, num3.Value, num2.Value))
						{
							possibleCenters.RemoveAt(k);
							possibleCenters.Insert(k, finderPattern.combineEstimate(num3.Value, num2.Value, num4));
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						FinderPattern finderPattern2 = new FinderPattern(num2.Value, num3.Value, num4);
						possibleCenters.Add(finderPattern2);
						if (resultPointCallback != null)
						{
							resultPointCallback(finderPattern2);
						}
					}
					return true;
				}
			}
			return false;
		}

		private int findRowSkip()
		{
			if (possibleCenters.Count <= 1)
			{
				return 0;
			}
			ResultPoint resultPoint = null;
			foreach (FinderPattern possibleCenter in possibleCenters)
			{
				if (possibleCenter.Count >= 2)
				{
					if (resultPoint != null)
					{
						hasSkipped = true;
						return (int)(Math.Abs(resultPoint.X - possibleCenter.X) - Math.Abs(resultPoint.Y - possibleCenter.Y)) / 2;
					}
					resultPoint = possibleCenter;
				}
			}
			return 0;
		}

		private bool haveMultiplyConfirmedCenters()
		{
			int num = 0;
			float num2 = 0f;
			int count = possibleCenters.Count;
			foreach (FinderPattern possibleCenter in possibleCenters)
			{
				if (possibleCenter.Count >= 2)
				{
					num++;
					num2 += possibleCenter.EstimatedModuleSize;
				}
			}
			if (num < 3)
			{
				return false;
			}
			float num3 = num2 / (float)count;
			float num4 = 0f;
			for (int i = 0; i < count; i++)
			{
				FinderPattern finderPattern = possibleCenters[i];
				num4 += Math.Abs(finderPattern.EstimatedModuleSize - num3);
			}
			return num4 <= 0.05f * num2;
		}

		private FinderPattern[] selectBestPatterns()
		{
			int count = possibleCenters.Count;
			if (count < 3)
			{
				return null;
			}
			if (count > 3)
			{
				float num = 0f;
				float num2 = 0f;
				foreach (FinderPattern possibleCenter in possibleCenters)
				{
					float estimatedModuleSize = possibleCenter.EstimatedModuleSize;
					num += estimatedModuleSize;
					num2 += estimatedModuleSize * estimatedModuleSize;
				}
				float num3 = num / (float)count;
				float val = (float)Math.Sqrt(num2 / (float)count - num3 * num3);
				possibleCenters.Sort(new FurthestFromAverageComparator(num3));
				float num4 = Math.Max(0.2f * num3, val);
				for (int i = 0; i < possibleCenters.Count; i++)
				{
					if (possibleCenters.Count <= 3)
					{
						break;
					}
					if (Math.Abs(possibleCenters[i].EstimatedModuleSize - num3) > num4)
					{
						possibleCenters.RemoveAt(i);
						i--;
					}
				}
			}
			if (possibleCenters.Count > 3)
			{
				float num5 = 0f;
				foreach (FinderPattern possibleCenter2 in possibleCenters)
				{
					num5 += possibleCenter2.EstimatedModuleSize;
				}
				float f = num5 / (float)possibleCenters.Count;
				possibleCenters.Sort(new CenterComparator(f));
				possibleCenters = possibleCenters.GetRange(0, 3);
			}
			return new FinderPattern[3]
			{
				possibleCenters[0],
				possibleCenters[1],
				possibleCenters[2]
			};
		}
	}
	public sealed class FinderPatternInfo
	{
		private readonly FinderPattern bottomLeft;

		private readonly FinderPattern topLeft;

		private readonly FinderPattern topRight;

		public FinderPattern BottomLeft => bottomLeft;

		public FinderPattern TopLeft => topLeft;

		public FinderPattern TopRight => topRight;

		public FinderPatternInfo(FinderPattern[] patternCenters)
		{
			bottomLeft = patternCenters[0];
			topLeft = patternCenters[1];
			topRight = patternCenters[2];
		}
	}
	internal sealed class BlockPair
	{
		private readonly byte[] dataBytes;

		private readonly byte[] errorCorrectionBytes;

		public byte[] DataBytes => dataBytes;

		public byte[] ErrorCorrectionBytes => errorCorrectionBytes;

		public BlockPair(byte[] data, byte[] errorCorrection)
		{
			dataBytes = data;
			errorCorrectionBytes = errorCorrection;
		}
	}
	public sealed class ByteMatrix
	{
		private readonly byte[][] bytes;

		private readonly int width;

		private readonly int height;

		public int Height => height;

		public int Width => width;

		public int this[int x, int y]
		{
			get
			{
				return bytes[y][x];
			}
			set
			{
				bytes[y][x] = (byte)value;
			}
		}

		public byte[][] Array => bytes;

		public ByteMatrix(int width, int height)
		{
			bytes = new byte[height][];
			for (int i = 0; i < height; i++)
			{
				bytes[i] = new byte[width];
			}
			this.width = width;
			this.height = height;
		}

		public void set(int x, int y, byte value)
		{
			bytes[y][x] = value;
		}

		public void set(int x, int y, bool value)
		{
			bytes[y][x] = (byte)(value ? 1u : 0u);
		}

		public void clear(byte value)
		{
			for (int i = 0; i < height; i++)
			{
				byte[] array = bytes[i];
				for (int j = 0; j < width; j++)
				{
					array[j] = value;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(2 * width * height + 2);
			for (int i = 0; i < height; i++)
			{
				byte[] array = bytes[i];
				for (int j = 0; j < width; j++)
				{
					switch (array[j])
					{
					case 0:
						stringBuilder.Append(" 0");
						break;
					case 1:
						stringBuilder.Append(" 1");
						break;
					default:
						stringBuilder.Append("  ");
						break;
					}
				}
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}
	}
	public static class Encoder
	{
		private static readonly int[] ALPHANUMERIC_TABLE = new int[96]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, 36, -1, -1, -1, 37, 38, -1, -1,
			-1, -1, 39, 40, -1, 41, 42, 43, 0, 1,
			2, 3, 4, 5, 6, 7, 8, 9, 44, -1,
			-1, -1, -1, -1, -1, 10, 11, 12, 13, 14,
			15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
			25, 26, 27, 28, 29, 30, 31, 32, 33, 34,
			35, -1, -1, -1, -1, -1
		};

		internal static string DEFAULT_BYTE_MODE_ENCODING = "ISO-8859-1";

		private static int calculateMaskPenalty(ByteMatrix matrix)
		{
			return MaskUtil.applyMaskPenaltyRule1(matrix) + MaskUtil.applyMaskPenaltyRule2(matrix) + MaskUtil.applyMaskPenaltyRule3(matrix) + MaskUtil.applyMaskPenaltyRule4(matrix);
		}

		public static QRCode encode(string content, ErrorCorrectionLevel ecLevel)
		{
			return encode(content, ecLevel, null);
		}

		public static QRCode encode(string content, ErrorCorrectionLevel ecLevel, IDictionary<EncodeHintType, object> hints)
		{
			bool num = hints?.ContainsKey(EncodeHintType.CHARACTER_SET) ?? false;
			string text = ((hints == null || !hints.ContainsKey(EncodeHintType.CHARACTER_SET)) ? null : ((string)hints[EncodeHintType.CHARACTER_SET]));
			if (text == null)
			{
				text = DEFAULT_BYTE_MODE_ENCODING;
			}
			bool flag = num || !DEFAULT_BYTE_MODE_ENCODING.Equals(text);
			Mode mode = chooseMode(content, text);
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			if (mode == Mode.BYTE && flag)
			{
				CharacterSetECI characterSetECIByName = CharacterSetECI.getCharacterSetECIByName(text);
				if (characterSetECIByName != null && (hints == null || !hints.ContainsKey(EncodeHintType.DISABLE_ECI) || hints[EncodeHintType.DISABLE_ECI] == null || !Convert.ToBoolean(hints[EncodeHintType.DISABLE_ECI].ToString())))
				{
					appendECI(characterSetECIByName, bitArray);
				}
			}
			if (hints != null && hints.ContainsKey(EncodeHintType.GS1_FORMAT) && hints[EncodeHintType.GS1_FORMAT] != null && Convert.ToBoolean(hints[EncodeHintType.GS1_FORMAT].ToString()))
			{
				appendModeInfo(Mode.FNC1_FIRST_POSITION, bitArray);
			}
			appendModeInfo(mode, bitArray);
			ZXing.Common.BitArray bitArray2 = new ZXing.Common.BitArray();
			appendBytes(content, mode, bitArray2, text);
			Version version;
			if (hints != null && hints.ContainsKey(EncodeHintType.QR_VERSION))
			{
				version = Version.getVersionForNumber(int.Parse(hints[EncodeHintType.QR_VERSION].ToString()));
				if (!willFit(calculateBitsNeeded(mode, bitArray, bitArray2, version), version, ecLevel))
				{
					throw new WriterException("Data too big for requested version");
				}
			}
			else
			{
				version = recommendVersion(ecLevel, mode, bitArray, bitArray2);
			}
			ZXing.Common.BitArray bitArray3 = new ZXing.Common.BitArray();
			bitArray3.appendBitArray(bitArray);
			appendLengthInfo((mode == Mode.BYTE) ? bitArray2.SizeInBytes : content.Length, version, mode, bitArray3);
			bitArray3.appendBitArray(bitArray2);
			Version.ECBlocks eCBlocksForLevel = version.getECBlocksForLevel(ecLevel);
			int numDataBytes = version.TotalCodewords - eCBlocksForLevel.TotalECCodewords;
			terminateBits(numDataBytes, bitArray3);
			ZXing.Common.BitArray bitArray4 = interleaveWithECBytes(bitArray3, version.TotalCodewords, numDataBytes, eCBlocksForLevel.NumBlocks);
			QRCode qRCode = new QRCode
			{
				ECLevel = ecLevel,
				Mode = mode,
				Version = version
			};
			int dimensionForVersion = version.DimensionForVersion;
			ByteMatrix matrix = new ByteMatrix(dimensionForVersion, dimensionForVersion);
			int maskPattern = (qRCode.MaskPattern = chooseMaskPattern(bitArray4, ecLevel, version, matrix));
			MatrixUtil.buildMatrix(bitArray4, ecLevel, version, maskPattern, matrix);
			qRCode.Matrix = matrix;
			return qRCode;
		}

		private static Version recommendVersion(ErrorCorrectionLevel ecLevel, Mode mode, ZXing.Common.BitArray headerBits, ZXing.Common.BitArray dataBits)
		{
			Version version = chooseVersion(calculateBitsNeeded(mode, headerBits, dataBits, Version.getVersionForNumber(1)), ecLevel);
			return chooseVersion(calculateBitsNeeded(mode, headerBits, dataBits, version), ecLevel);
		}

		private static int calculateBitsNeeded(Mode mode, ZXing.Common.BitArray headerBits, ZXing.Common.BitArray dataBits, Version version)
		{
			return headerBits.Size + mode.getCharacterCountBits(version) + dataBits.Size;
		}

		internal static int getAlphanumericCode(int code)
		{
			if (code < ALPHANUMERIC_TABLE.Length)
			{
				return ALPHANUMERIC_TABLE[code];
			}
			return -1;
		}

		public static Mode chooseMode(string content)
		{
			return chooseMode(content, null);
		}

		private static Mode chooseMode(string content, string encoding)
		{
			if ("Shift_JIS".Equals(encoding) && isOnlyDoubleByteKanji(content))
			{
				return Mode.KANJI;
			}
			bool flag = false;
			bool flag2 = false;
			foreach (char c in content)
			{
				if (c >= '0' && c <= '9')
				{
					flag = true;
					continue;
				}
				if (getAlphanumericCode(c) != -1)
				{
					flag2 = true;
					continue;
				}
				return Mode.BYTE;
			}
			if (flag2)
			{
				return Mode.ALPHANUMERIC;
			}
			if (flag)
			{
				return Mode.NUMERIC;
			}
			return Mode.BYTE;
		}

		private static bool isOnlyDoubleByteKanji(string content)
		{
			byte[] bytes;
			try
			{
				bytes = Encoding.GetEncoding("Shift_JIS").GetBytes(content);
			}
			catch (Exception)
			{
				return false;
			}
			int num = bytes.Length;
			if (num % 2 != 0)
			{
				return false;
			}
			for (int i = 0; i < num; i += 2)
			{
				int num2 = bytes[i] & 0xFF;
				if ((num2 < 129 || num2 > 159) && (num2 < 224 || num2 > 235))
				{
					return false;
				}
			}
			return true;
		}

		private static int chooseMaskPattern(ZXing.Common.BitArray bits, ErrorCorrectionLevel ecLevel, Version version, ByteMatrix matrix)
		{
			int num = 2147483647;
			int result = -1;
			for (int i = 0; i < QRCode.NUM_MASK_PATTERNS; i++)
			{
				MatrixUtil.buildMatrix(bits, ecLevel, version, i, matrix);
				int num2 = calculateMaskPenalty(matrix);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		private static Version chooseVersion(int numInputBits, ErrorCorrectionLevel ecLevel)
		{
			for (int i = 1; i <= 40; i++)
			{
				Version versionForNumber = Version.getVersionForNumber(i);
				if (willFit(numInputBits, versionForNumber, ecLevel))
				{
					return versionForNumber;
				}
			}
			throw new WriterException("Data too big");
		}

		private static bool willFit(int numInputBits, Version version, ErrorCorrectionLevel ecLevel)
		{
			int totalCodewords = version.TotalCodewords;
			int totalECCodewords = version.getECBlocksForLevel(ecLevel).TotalECCodewords;
			int num = totalCodewords - totalECCodewords;
			int num2 = (numInputBits + 7) / 8;
			return num >= num2;
		}

		internal static void terminateBits(int numDataBytes, ZXing.Common.BitArray bits)
		{
			int num = numDataBytes << 3;
			if (bits.Size > num)
			{
				throw new WriterException("data bits cannot fit in the QR Code" + bits.Size + " > " + num);
			}
			for (int i = 0; i < 4; i++)
			{
				if (bits.Size >= num)
				{
					break;
				}
				bits.appendBit(bit: false);
			}
			int num2 = bits.Size & 7;
			if (num2 > 0)
			{
				for (int j = num2; j < 8; j++)
				{
					bits.appendBit(bit: false);
				}
			}
			int num3 = numDataBytes - bits.SizeInBytes;
			for (int k = 0; k < num3; k++)
			{
				bits.appendBits(((k & 1) == 0) ? 236 : 17, 8);
			}
			if (bits.Size != num)
			{
				throw new WriterException("Bits size does not equal capacity");
			}
		}

		internal static void getNumDataBytesAndNumECBytesForBlockID(int numTotalBytes, int numDataBytes, int numRSBlocks, int blockID, int[] numDataBytesInBlock, int[] numECBytesInBlock)
		{
			if (blockID >= numRSBlocks)
			{
				throw new WriterException("Block ID too large");
			}
			int num = numTotalBytes % numRSBlocks;
			int num2 = numRSBlocks - num;
			int num3 = numTotalBytes / numRSBlocks;
			int num4 = num3 + 1;
			int num5 = numDataBytes / numRSBlocks;
			int num6 = num5 + 1;
			int num7 = num3 - num5;
			int num8 = num4 - num6;
			if (num7 != num8)
			{
				throw new WriterException("EC bytes mismatch");
			}
			if (numRSBlocks != num2 + num)
			{
				throw new WriterException("RS blocks mismatch");
			}
			if (numTotalBytes != (num5 + num7) * num2 + (num6 + num8) * num)
			{
				throw new WriterException("Total bytes mismatch");
			}
			if (blockID < num2)
			{
				numDataBytesInBlock[0] = num5;
				numECBytesInBlock[0] = num7;
			}
			else
			{
				numDataBytesInBlock[0] = num6;
				numECBytesInBlock[0] = num8;
			}
		}

		internal static ZXing.Common.BitArray interleaveWithECBytes(ZXing.Common.BitArray bits, int numTotalBytes, int numDataBytes, int numRSBlocks)
		{
			if (bits.SizeInBytes != numDataBytes)
			{
				throw new WriterException("Number of bits and data bytes does not match");
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			List<BlockPair> list = new List<BlockPair>(numRSBlocks);
			for (int i = 0; i < numRSBlocks; i++)
			{
				int[] array = new int[1];
				int[] array2 = new int[1];
				getNumDataBytesAndNumECBytesForBlockID(numTotalBytes, numDataBytes, numRSBlocks, i, array, array2);
				int num4 = array[0];
				byte[] array3 = new byte[num4];
				bits.toBytes(8 * num, array3, 0, num4);
				byte[] array4 = generateECBytes(array3, array2[0]);
				list.Add(new BlockPair(array3, array4));
				num2 = Math.Max(num2, num4);
				num3 = Math.Max(num3, array4.Length);
				num += array[0];
			}
			if (numDataBytes != num)
			{
				throw new WriterException("Data bytes does not match offset");
			}
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			for (int j = 0; j < num2; j++)
			{
				foreach (BlockPair item in list)
				{
					byte[] dataBytes = item.DataBytes;
					if (j < dataBytes.Length)
					{
						bitArray.appendBits(dataBytes[j], 8);
					}
				}
			}
			for (int k = 0; k < num3; k++)
			{
				foreach (BlockPair item2 in list)
				{
					byte[] errorCorrectionBytes = item2.ErrorCorrectionBytes;
					if (k < errorCorrectionBytes.Length)
					{
						bitArray.appendBits(errorCorrectionBytes[k], 8);
					}
				}
			}
			if (numTotalBytes != bitArray.SizeInBytes)
			{
				throw new WriterException("Interleaving error: " + numTotalBytes + " and " + bitArray.SizeInBytes + " differ.");
			}
			return bitArray;
		}

		internal static byte[] generateECBytes(byte[] dataBytes, int numEcBytesInBlock)
		{
			int num = dataBytes.Length;
			int[] array = new int[num + numEcBytesInBlock];
			for (int i = 0; i < num; i++)
			{
				array[i] = dataBytes[i] & 0xFF;
			}
			new ReedSolomonEncoder(GenericGF.QR_CODE_FIELD_256).encode(array, numEcBytesInBlock);
			byte[] array2 = new byte[numEcBytesInBlock];
			for (int j = 0; j < numEcBytesInBlock; j++)
			{
				array2[j] = (byte)array[num + j];
			}
			return array2;
		}

		internal static void appendModeInfo(Mode mode, ZXing.Common.BitArray bits)
		{
			bits.appendBits(mode.Bits, 4);
		}

		internal static void appendLengthInfo(int numLetters, Version version, Mode mode, ZXing.Common.BitArray bits)
		{
			int characterCountBits = mode.getCharacterCountBits(version);
			if (numLetters >= 1 << characterCountBits)
			{
				throw new WriterException(numLetters + " is bigger than " + ((1 << characterCountBits) - 1));
			}
			bits.appendBits(numLetters, characterCountBits);
		}

		internal static void appendBytes(string content, Mode mode, ZXing.Common.BitArray bits, string encoding)
		{
			if (mode.Equals(Mode.NUMERIC))
			{
				appendNumericBytes(content, bits);
				return;
			}
			if (mode.Equals(Mode.ALPHANUMERIC))
			{
				appendAlphanumericBytes(content, bits);
				return;
			}
			if (mode.Equals(Mode.BYTE))
			{
				append8BitBytes(content, bits, encoding);
				return;
			}
			if (mode.Equals(Mode.KANJI))
			{
				appendKanjiBytes(content, bits);
				return;
			}
			throw new WriterException("Invalid mode: " + mode);
		}

		internal static void appendNumericBytes(string content, ZXing.Common.BitArray bits)
		{
			int length = content.Length;
			int num = 0;
			while (num < length)
			{
				int num2 = content[num] - 48;
				if (num + 2 < length)
				{
					int num3 = content[num + 1] - 48;
					int num4 = content[num + 2] - 48;
					bits.appendBits(num2 * 100 + num3 * 10 + num4, 10);
					num += 3;
				}
				else if (num + 1 < length)
				{
					int num5 = content[num + 1] - 48;
					bits.appendBits(num2 * 10 + num5, 7);
					num += 2;
				}
				else
				{
					bits.appendBits(num2, 4);
					num++;
				}
			}
		}

		internal static void appendAlphanumericBytes(string content, ZXing.Common.BitArray bits)
		{
			int length = content.Length;
			int num = 0;
			while (num < length)
			{
				int alphanumericCode = getAlphanumericCode(content[num]);
				if (alphanumericCode == -1)
				{
					throw new WriterException();
				}
				if (num + 1 < length)
				{
					int alphanumericCode2 = getAlphanumericCode(content[num + 1]);
					if (alphanumericCode2 == -1)
					{
						throw new WriterException();
					}
					bits.appendBits(alphanumericCode * 45 + alphanumericCode2, 11);
					num += 2;
				}
				else
				{
					bits.appendBits(alphanumericCode, 6);
					num++;
				}
			}
		}

		internal static void append8BitBytes(string content, ZXing.Common.BitArray bits, string encoding)
		{
			byte[] bytes;
			try
			{
				bytes = Encoding.GetEncoding(encoding).GetBytes(content);
			}
			catch (Exception ex)
			{
				throw new WriterException(ex.Message, ex);
			}
			byte[] array = bytes;
			foreach (byte value in array)
			{
				bits.appendBits(value, 8);
			}
		}

		internal static void appendKanjiBytes(string content, ZXing.Common.BitArray bits)
		{
			byte[] bytes;
			try
			{
				bytes = Encoding.GetEncoding("Shift_JIS").GetBytes(content);
			}
			catch (Exception ex)
			{
				throw new WriterException(ex.Message, ex);
			}
			int num = bytes.Length;
			for (int i = 0; i < num; i += 2)
			{
				int num2 = bytes[i] & 0xFF;
				int num3 = bytes[i + 1] & 0xFF;
				int num4 = (num2 << 8) | num3;
				int num5 = -1;
				if (num4 >= 33088 && num4 <= 40956)
				{
					num5 = num4 - 33088;
				}
				else if (num4 >= 57408 && num4 <= 60351)
				{
					num5 = num4 - 49472;
				}
				if (num5 == -1)
				{
					throw new WriterException("Invalid byte sequence");
				}
				int value = (num5 >> 8) * 192 + (num5 & 0xFF);
				bits.appendBits(value, 13);
			}
		}

		private static void appendECI(CharacterSetECI eci, ZXing.Common.BitArray bits)
		{
			bits.appendBits(Mode.ECI.Bits, 4);
			bits.appendBits(eci.Value, 8);
		}
	}
	public static class MaskUtil
	{
		private const int N1 = 3;

		private const int N2 = 3;

		private const int N3 = 40;

		private const int N4 = 10;

		public static int applyMaskPenaltyRule1(ByteMatrix matrix)
		{
			return applyMaskPenaltyRule1Internal(matrix, isHorizontal: true) + applyMaskPenaltyRule1Internal(matrix, isHorizontal: false);
		}

		public static int applyMaskPenaltyRule2(ByteMatrix matrix)
		{
			int num = 0;
			byte[][] array = matrix.Array;
			int width = matrix.Width;
			int height = matrix.Height;
			for (int i = 0; i < height - 1; i++)
			{
				byte[] array2 = array[i];
				byte[] array3 = array[i + 1];
				for (int j = 0; j < width - 1; j++)
				{
					int num2 = array2[j];
					if (num2 == array2[j + 1] && num2 == array3[j] && num2 == array3[j + 1])
					{
						num++;
					}
				}
			}
			return 3 * num;
		}

		public static int applyMaskPenaltyRule3(ByteMatrix matrix)
		{
			int num = 0;
			byte[][] array = matrix.Array;
			int width = matrix.Width;
			int height = matrix.Height;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					byte[] array2 = array[i];
					if (j + 6 < width && array2[j] == 1 && array2[j + 1] == 0 && array2[j + 2] == 1 && array2[j + 3] == 1 && array2[j + 4] == 1 && array2[j + 5] == 0 && array2[j + 6] == 1 && (isWhiteHorizontal(array2, j - 4, j) || isWhiteHorizontal(array2, j + 7, j + 11)))
					{
						num++;
					}
					if (i + 6 < height && array[i][j] == 1 && array[i + 1][j] == 0 && array[i + 2][j] == 1 && array[i + 3][j] == 1 && array[i + 4][j] == 1 && array[i + 5][j] == 0 && array[i + 6][j] == 1 && (isWhiteVertical(array, j, i - 4, i) || isWhiteVertical(array, j, i + 7, i + 11)))
					{
						num++;
					}
				}
			}
			return num * 40;
		}

		private static bool isWhiteHorizontal(byte[] rowArray, int from, int to)
		{
			from = Math.Max(from, 0);
			to = Math.Min(to, rowArray.Length);
			for (int i = from; i < to; i++)
			{
				if (rowArray[i] == 1)
				{
					return false;
				}
			}
			return true;
		}

		private static bool isWhiteVertical(byte[][] array, int col, int from, int to)
		{
			from = Math.Max(from, 0);
			to = Math.Min(to, array.Length);
			for (int i = from; i < to; i++)
			{
				if (array[i][col] == 1)
				{
					return false;
				}
			}
			return true;
		}

		public static int applyMaskPenaltyRule4(ByteMatrix matrix)
		{
			int num = 0;
			byte[][] array = matrix.Array;
			int width = matrix.Width;
			int height = matrix.Height;
			for (int i = 0; i < height; i++)
			{
				byte[] array2 = array[i];
				for (int j = 0; j < width; j++)
				{
					if (array2[j] == 1)
					{
						num++;
					}
				}
			}
			int num2 = matrix.Height * matrix.Width;
			return (int)(Math.Abs((double)num / (double)num2 - 0.5) * 20.0) * 10;
		}

		public static bool getDataMaskBit(int maskPattern, int x, int y)
		{
			int num2;
			switch (maskPattern)
			{
			case 0:
				num2 = (y + x) & 1;
				break;
			case 1:
				num2 = y & 1;
				break;
			case 2:
				num2 = x % 3;
				break;
			case 3:
				num2 = (y + x) % 3;
				break;
			case 4:
				num2 = ((y >>> 1) + x / 3) & 1;
				break;
			case 5:
			{
				int num = y * x;
				num2 = (num & 1) + num % 3;
				break;
			}
			case 6:
			{
				int num = y * x;
				num2 = ((num & 1) + num % 3) & 1;
				break;
			}
			case 7:
			{
				int num = y * x;
				num2 = (num % 3 + ((y + x) & 1)) & 1;
				break;
			}
			default:
				throw new ArgumentException("Invalid mask pattern: " + maskPattern);
			}
			return num2 == 0;
		}

		private static int applyMaskPenaltyRule1Internal(ByteMatrix matrix, bool isHorizontal)
		{
			int num = 0;
			int num2 = (isHorizontal ? matrix.Height : matrix.Width);
			int num3 = (isHorizontal ? matrix.Width : matrix.Height);
			byte[][] array = matrix.Array;
			for (int i = 0; i < num2; i++)
			{
				int num4 = 0;
				int num5 = -1;
				for (int j = 0; j < num3; j++)
				{
					int num6 = (isHorizontal ? array[i][j] : array[j][i]);
					if (num6 == num5)
					{
						num4++;
						continue;
					}
					if (num4 >= 5)
					{
						num += 3 + (num4 - 5);
					}
					num4 = 1;
					num5 = num6;
				}
				if (num4 >= 5)
				{
					num += 3 + (num4 - 5);
				}
			}
			return num;
		}
	}
	public static class MatrixUtil
	{
		private static readonly int[][] POSITION_DETECTION_PATTERN = new int[7][]
		{
			new int[7] { 1, 1, 1, 1, 1, 1, 1 },
			new int[7] { 1, 0, 0, 0, 0, 0, 1 },
			new int[7] { 1, 0, 1, 1, 1, 0, 1 },
			new int[7] { 1, 0, 1, 1, 1, 0, 1 },
			new int[7] { 1, 0, 1, 1, 1, 0, 1 },
			new int[7] { 1, 0, 0, 0, 0, 0, 1 },
			new int[7] { 1, 1, 1, 1, 1, 1, 1 }
		};

		private static readonly int[][] POSITION_ADJUSTMENT_PATTERN = new int[5][]
		{
			new int[5] { 1, 1, 1, 1, 1 },
			new int[5] { 1, 0, 0, 0, 1 },
			new int[5] { 1, 0, 1, 0, 1 },
			new int[5] { 1, 0, 0, 0, 1 },
			new int[5] { 1, 1, 1, 1, 1 }
		};

		private static readonly int[][] POSITION_ADJUSTMENT_PATTERN_COORDINATE_TABLE = new int[40][]
		{
			new int[7] { -1, -1, -1, -1, -1, -1, -1 },
			new int[7] { 6, 18, -1, -1, -1, -1, -1 },
			new int[7] { 6, 22, -1, -1, -1, -1, -1 },
			new int[7] { 6, 26, -1, -1, -1, -1, -1 },
			new int[7] { 6, 30, -1, -1, -1, -1, -1 },
			new int[7] { 6, 34, -1, -1, -1, -1, -1 },
			new int[7] { 6, 22, 38, -1, -1, -1, -1 },
			new int[7] { 6, 24, 42, -1, -1, -1, -1 },
			new int[7] { 6, 26, 46, -1, -1, -1, -1 },
			new int[7] { 6, 28, 50, -1, -1, -1, -1 },
			new int[7] { 6, 30, 54, -1, -1, -1, -1 },
			new int[7] { 6, 32, 58, -1, -1, -1, -1 },
			new int[7] { 6, 34, 62, -1, -1, -1, -1 },
			new int[7] { 6, 26, 46, 66, -1, -1, -1 },
			new int[7] { 6, 26, 48, 70, -1, -1, -1 },
			new int[7] { 6, 26, 50, 74, -1, -1, -1 },
			new int[7] { 6, 30, 54, 78, -1, -1, -1 },
			new int[7] { 6, 30, 56, 82, -1, -1, -1 },
			new int[7] { 6, 30, 58, 86, -1, -1, -1 },
			new int[7] { 6, 34, 62, 90, -1, -1, -1 },
			new int[7] { 6, 28, 50, 72, 94, -1, -1 },
			new int[7] { 6, 26, 50, 74, 98, -1, -1 },
			new int[7] { 6, 30, 54, 78, 102, -1, -1 },
			new int[7] { 6, 28, 54, 80, 106, -1, -1 },
			new int[7] { 6, 32, 58, 84, 110, -1, -1 },
			new int[7] { 6, 30, 58, 86, 114, -1, -1 },
			new int[7] { 6, 34, 62, 90, 118, -1, -1 },
			new int[7] { 6, 26, 50, 74, 98, 122, -1 },
			new int[7] { 6, 30, 54, 78, 102, 126, -1 },
			new int[7] { 6, 26, 52, 78, 104, 130, -1 },
			new int[7] { 6, 30, 56, 82, 108, 134, -1 },
			new int[7] { 6, 34, 60, 86, 112, 138, -1 },
			new int[7] { 6, 30, 58, 86, 114, 142, -1 },
			new int[7] { 6, 34, 62, 90, 118, 146, -1 },
			new int[7] { 6, 30, 54, 78, 102, 126, 150 },
			new int[7] { 6, 24, 50, 76, 102, 128, 154 },
			new int[7] { 6, 28, 54, 80, 106, 132, 158 },
			new int[7] { 6, 32, 58, 84, 110, 136, 162 },
			new int[7] { 6, 26, 54, 82, 110, 138, 166 },
			new int[7] { 6, 30, 58, 86, 114, 142, 170 }
		};

		private static readonly int[][] TYPE_INFO_COORDINATES = new int[15][]
		{
			new int[2] { 8, 0 },
			new int[2] { 8, 1 },
			new int[2] { 8, 2 },
			new int[2] { 8, 3 },
			new int[2] { 8, 4 },
			new int[2] { 8, 5 },
			new int[2] { 8, 7 },
			new int[2] { 8, 8 },
			new int[2] { 7, 8 },
			new int[2] { 5, 8 },
			new int[2] { 4, 8 },
			new int[2] { 3, 8 },
			new int[2] { 2, 8 },
			new int[2] { 1, 8 },
			new int[2] { 0, 8 }
		};

		private const int VERSION_INFO_POLY = 7973;

		private const int TYPE_INFO_POLY = 1335;

		private const int TYPE_INFO_MASK_PATTERN = 21522;

		public static void clearMatrix(ByteMatrix matrix)
		{
			matrix.clear(2);
		}

		public static void buildMatrix(ZXing.Common.BitArray dataBits, ErrorCorrectionLevel ecLevel, Version version, int maskPattern, ByteMatrix matrix)
		{
			clearMatrix(matrix);
			embedBasicPatterns(version, matrix);
			embedTypeInfo(ecLevel, maskPattern, matrix);
			maybeEmbedVersionInfo(version, matrix);
			embedDataBits(dataBits, maskPattern, matrix);
		}

		public static void embedBasicPatterns(Version version, ByteMatrix matrix)
		{
			embedPositionDetectionPatternsAndSeparators(matrix);
			embedDarkDotAtLeftBottomCorner(matrix);
			maybeEmbedPositionAdjustmentPatterns(version, matrix);
			embedTimingPatterns(matrix);
		}

		public static void embedTypeInfo(ErrorCorrectionLevel ecLevel, int maskPattern, ByteMatrix matrix)
		{
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			makeTypeInfoBits(ecLevel, maskPattern, bitArray);
			for (int i = 0; i < bitArray.Size; i++)
			{
				int value = (bitArray[bitArray.Size - 1 - i] ? 1 : 0);
				int[] obj = TYPE_INFO_COORDINATES[i];
				int x = obj[0];
				int y = obj[1];
				matrix[x, y] = value;
				if (i < 8)
				{
					int x2 = matrix.Width - i - 1;
					int y2 = 8;
					matrix[x2, y2] = value;
				}
				else
				{
					int x3 = 8;
					int y3 = matrix.Height - 7 + (i - 8);
					matrix[x3, y3] = value;
				}
			}
		}

		public static void maybeEmbedVersionInfo(Version version, ByteMatrix matrix)
		{
			if (version.VersionNumber < 7)
			{
				return;
			}
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			makeVersionInfoBits(version, bitArray);
			int num = 17;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int value = (bitArray[num] ? 1 : 0);
					num--;
					matrix[i, matrix.Height - 11 + j] = value;
					matrix[matrix.Height - 11 + j, i] = value;
				}
			}
		}

		public static void embedDataBits(ZXing.Common.BitArray dataBits, int maskPattern, ByteMatrix matrix)
		{
			int num = 0;
			int num2 = -1;
			int num3 = matrix.Width - 1;
			int i = matrix.Height - 1;
			while (num3 > 0)
			{
				if (num3 == 6)
				{
					num3--;
				}
				for (; i >= 0 && i < matrix.Height; i += num2)
				{
					for (int j = 0; j < 2; j++)
					{
						int x = num3 - j;
						if (isEmpty(matrix[x, i]))
						{
							int num4;
							if (num < dataBits.Size)
							{
								num4 = (dataBits[num] ? 1 : 0);
								num++;
							}
							else
							{
								num4 = 0;
							}
							if (maskPattern != -1 && MaskUtil.getDataMaskBit(maskPattern, x, i))
							{
								num4 ^= 1;
							}
							matrix[x, i] = num4;
						}
					}
				}
				num2 = -num2;
				i += num2;
				num3 -= 2;
			}
			if (num != dataBits.Size)
			{
				throw new WriterException("Not all bits consumed: " + num + "/" + dataBits.Size);
			}
		}

		public static int findMSBSet(int value_Renamed)
		{
			int num = 0;
			while (value_Renamed != 0)
			{
				value_Renamed >>>= 1;
				num++;
			}
			return num;
		}

		public static int calculateBCHCode(int value, int poly)
		{
			if (poly == 0)
			{
				throw new ArgumentException("0 polynominal", "poly");
			}
			int num = findMSBSet(poly);
			value <<= num - 1;
			while (findMSBSet(value) >= num)
			{
				value ^= poly << findMSBSet(value) - num;
			}
			return value;
		}

		public static void makeTypeInfoBits(ErrorCorrectionLevel ecLevel, int maskPattern, ZXing.Common.BitArray bits)
		{
			if (!QRCode.isValidMaskPattern(maskPattern))
			{
				throw new WriterException("Invalid mask pattern");
			}
			int value = (ecLevel.Bits << 3) | maskPattern;
			bits.appendBits(value, 5);
			int value2 = calculateBCHCode(value, 1335);
			bits.appendBits(value2, 10);
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			bitArray.appendBits(21522, 15);
			bits.xor(bitArray);
			if (bits.Size != 15)
			{
				throw new WriterException("should not happen but we got: " + bits.Size);
			}
		}

		public static void makeVersionInfoBits(Version version, ZXing.Common.BitArray bits)
		{
			bits.appendBits(version.VersionNumber, 6);
			int value = calculateBCHCode(version.VersionNumber, 7973);
			bits.appendBits(value, 12);
			if (bits.Size != 18)
			{
				throw new WriterException("should not happen but we got: " + bits.Size);
			}
		}

		private static bool isEmpty(int value)
		{
			return value == 2;
		}

		private static void embedTimingPatterns(ByteMatrix matrix)
		{
			for (int i = 8; i < matrix.Width - 8; i++)
			{
				int value = (i + 1) % 2;
				if (isEmpty(matrix[i, 6]))
				{
					matrix[i, 6] = value;
				}
				if (isEmpty(matrix[6, i]))
				{
					matrix[6, i] = value;
				}
			}
		}

		private static void embedDarkDotAtLeftBottomCorner(ByteMatrix matrix)
		{
			if (matrix[8, matrix.Height - 8] == 0)
			{
				throw new WriterException();
			}
			matrix[8, matrix.Height - 8] = 1;
		}

		private static void embedHorizontalSeparationPattern(int xStart, int yStart, ByteMatrix matrix)
		{
			for (int i = 0; i < 8; i++)
			{
				if (!isEmpty(matrix[xStart + i, yStart]))
				{
					throw new WriterException();
				}
				matrix[xStart + i, yStart] = 0;
			}
		}

		private static void embedVerticalSeparationPattern(int xStart, int yStart, ByteMatrix matrix)
		{
			for (int i = 0; i < 7; i++)
			{
				if (!isEmpty(matrix[xStart, yStart + i]))
				{
					throw new WriterException();
				}
				matrix[xStart, yStart + i] = 0;
			}
		}

		private static void embedPositionAdjustmentPattern(int xStart, int yStart, ByteMatrix matrix)
		{
			for (int i = 0; i < 5; i++)
			{
				int[] array = POSITION_ADJUSTMENT_PATTERN[i];
				for (int j = 0; j < 5; j++)
				{
					matrix[xStart + j, yStart + i] = array[j];
				}
			}
		}

		private static void embedPositionDetectionPattern(int xStart, int yStart, ByteMatrix matrix)
		{
			for (int i = 0; i < 7; i++)
			{
				int[] array = POSITION_DETECTION_PATTERN[i];
				for (int j = 0; j < 7; j++)
				{
					matrix[xStart + j, yStart + i] = array[j];
				}
			}
		}

		private static void embedPositionDetectionPatternsAndSeparators(ByteMatrix matrix)
		{
			int num = POSITION_DETECTION_PATTERN[0].Length;
			embedPositionDetectionPattern(0, 0, matrix);
			embedPositionDetectionPattern(matrix.Width - num, 0, matrix);
			embedPositionDetectionPattern(0, matrix.Width - num, matrix);
			embedHorizontalSeparationPattern(0, 7, matrix);
			embedHorizontalSeparationPattern(matrix.Width - 8, 7, matrix);
			embedHorizontalSeparationPattern(0, matrix.Width - 8, matrix);
			embedVerticalSeparationPattern(7, 0, matrix);
			embedVerticalSeparationPattern(matrix.Height - 7 - 1, 0, matrix);
			embedVerticalSeparationPattern(7, matrix.Height - 7, matrix);
		}

		private static void maybeEmbedPositionAdjustmentPatterns(Version version, ByteMatrix matrix)
		{
			if (version.VersionNumber < 2)
			{
				return;
			}
			int num = version.VersionNumber - 1;
			int[] array = POSITION_ADJUSTMENT_PATTERN_COORDINATE_TABLE[num];
			int[] array2 = array;
			foreach (int num2 in array2)
			{
				if (num2 < 0)
				{
					continue;
				}
				int[] array3 = array;
				foreach (int num3 in array3)
				{
					if (num3 >= 0 && isEmpty(matrix[num3, num2]))
					{
						embedPositionAdjustmentPattern(num3 - 2, num2 - 2, matrix);
					}
				}
			}
		}
	}
	public sealed class QRCode
	{
		public static int NUM_MASK_PATTERNS = 8;

		public Mode Mode { get; set; }

		public ErrorCorrectionLevel ECLevel { get; set; }

		public Version Version { get; set; }

		public int MaskPattern { get; set; }

		public ByteMatrix Matrix { get; set; }

		public QRCode()
		{
			MaskPattern = -1;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(200);
			stringBuilder.Append("<<\n");
			stringBuilder.Append(" mode: ");
			stringBuilder.Append(Mode);
			stringBuilder.Append("\n ecLevel: ");
			stringBuilder.Append(ECLevel);
			stringBuilder.Append("\n version: ");
			if (Version == null)
			{
				stringBuilder.Append("null");
			}
			else
			{
				stringBuilder.Append(Version);
			}
			stringBuilder.Append("\n maskPattern: ");
			stringBuilder.Append(MaskPattern);
			if (Matrix == null)
			{
				stringBuilder.Append("\n matrix: null\n");
			}
			else
			{
				stringBuilder.Append("\n matrix:\n");
				stringBuilder.Append(Matrix.ToString());
			}
			stringBuilder.Append(">>\n");
			return stringBuilder.ToString();
		}

		public static bool isValidMaskPattern(int maskPattern)
		{
			if (maskPattern >= 0)
			{
				return maskPattern < NUM_MASK_PATTERNS;
			}
			return false;
		}
	}
}
namespace ZXing.PDF417
{
	[Serializable]
	public class PDF417EncodingOptions : EncodingOptions
	{
		public bool Compact
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.PDF417_COMPACT))
				{
					return (bool)base.Hints[EncodeHintType.PDF417_COMPACT];
				}
				return false;
			}
			set
			{
				base.Hints[EncodeHintType.PDF417_COMPACT] = value;
			}
		}

		public Compaction Compaction
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.PDF417_COMPACTION))
				{
					return (Compaction)base.Hints[EncodeHintType.PDF417_COMPACTION];
				}
				return Compaction.AUTO;
			}
			set
			{
				base.Hints[EncodeHintType.PDF417_COMPACTION] = value;
			}
		}

		public Dimensions Dimensions
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.PDF417_DIMENSIONS))
				{
					return (Dimensions)base.Hints[EncodeHintType.PDF417_DIMENSIONS];
				}
				return null;
			}
			set
			{
				base.Hints[EncodeHintType.PDF417_DIMENSIONS] = value;
			}
		}

		public PDF417ErrorCorrectionLevel ErrorCorrection
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
				{
					object obj = base.Hints[EncodeHintType.ERROR_CORRECTION];
					if (obj is PDF417ErrorCorrectionLevel)
					{
						return (PDF417ErrorCorrectionLevel)obj;
					}
					if (obj is int)
					{
						return (PDF417ErrorCorrectionLevel)Enum.Parse(typeof(PDF417ErrorCorrectionLevel), obj.ToString(), ignoreCase: true);
					}
				}
				return PDF417ErrorCorrectionLevel.L2;
			}
			set
			{
				base.Hints[EncodeHintType.ERROR_CORRECTION] = value;
			}
		}

		public PDF417AspectRatio AspectRatio
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.PDF417_ASPECT_RATIO))
				{
					object obj = base.Hints[EncodeHintType.PDF417_ASPECT_RATIO];
					if (obj is PDF417AspectRatio)
					{
						return (PDF417AspectRatio)obj;
					}
					if (obj is int)
					{
						return (PDF417AspectRatio)Enum.Parse(typeof(PDF417AspectRatio), obj.ToString(), ignoreCase: true);
					}
				}
				return PDF417AspectRatio.A4;
			}
			set
			{
				base.Hints[EncodeHintType.PDF417_ASPECT_RATIO] = value;
			}
		}

		public string CharacterSet
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.CHARACTER_SET))
				{
					return (string)base.Hints[EncodeHintType.CHARACTER_SET];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					if (base.Hints.ContainsKey(EncodeHintType.CHARACTER_SET))
					{
						base.Hints.Remove(EncodeHintType.CHARACTER_SET);
					}
				}
				else
				{
					base.Hints[EncodeHintType.CHARACTER_SET] = value;
				}
			}
		}

		public bool DisableECI
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.DISABLE_ECI))
				{
					return (bool)base.Hints[EncodeHintType.DISABLE_ECI];
				}
				return false;
			}
			set
			{
				base.Hints[EncodeHintType.DISABLE_ECI] = value;
			}
		}
	}
	internal static class PDF417Common
	{
		public static readonly int INVALID_CODEWORD = -1;

		public static readonly int NUMBER_OF_CODEWORDS = 929;

		public static readonly int MAX_CODEWORDS_IN_BARCODE = NUMBER_OF_CODEWORDS - 1;

		public static readonly int MIN_ROWS_IN_BARCODE = 3;

		public static readonly int MAX_ROWS_IN_BARCODE = 90;

		public static readonly int MODULES_IN_CODEWORD = 17;

		public static readonly int MODULES_IN_STOP_PATTERN = 18;

		public static readonly int BARS_IN_MODULE = 8;

		private static readonly int[] EMPTY_INT_ARRAY = new int[0];

		public static readonly int[] SYMBOL_TABLE = new int[2787]
		{
			66142, 66170, 66206, 66236, 66290, 66292, 66350, 66382, 66396, 66454,
			66470, 66476, 66594, 66600, 66614, 66626, 66628, 66632, 66640, 66654,
			66662, 66668, 66682, 66690, 66718, 66720, 66748, 66758, 66776, 66798,
			66802, 66804, 66820, 66824, 66832, 66846, 66848, 66876, 66880, 66936,
			66950, 66956, 66968, 66992, 67006, 67022, 67036, 67042, 67044, 67048,
			67062, 67118, 67150, 67164, 67214, 67228, 67256, 67294, 67322, 67350,
			67366, 67372, 67398, 67404, 67416, 67438, 67474, 67476, 67490, 67492,
			67496, 67510, 67618, 67624, 67650, 67656, 67664, 67678, 67686, 67692,
			67706, 67714, 67716, 67728, 67742, 67744, 67772, 67782, 67788, 67800,
			67822, 67826, 67828, 67842, 67848, 67870, 67872, 67900, 67904, 67960,
			67974, 67992, 68016, 68030, 68046, 68060, 68066, 68068, 68072, 68086,
			68104, 68112, 68126, 68128, 68156, 68160, 68216, 68336, 68358, 68364,
			68376, 68400, 68414, 68448, 68476, 68494, 68508, 68536, 68546, 68548,
			68552, 68560, 68574, 68582, 68588, 68654, 68686, 68700, 68706, 68708,
			68712, 68726, 68750, 68764, 68792, 68802, 68804, 68808, 68816, 68830,
			68838, 68844, 68858, 68878, 68892, 68920, 68976, 68990, 68994, 68996,
			69000, 69008, 69022, 69024, 69052, 69062, 69068, 69080, 69102, 69106,
			69108, 69142, 69158, 69164, 69190, 69208, 69230, 69254, 69260, 69272,
			69296, 69310, 69326, 69340, 69386, 69394, 69396, 69410, 69416, 69430,
			69442, 69444, 69448, 69456, 69470, 69478, 69484, 69554, 69556, 69666,
			69672, 69698, 69704, 69712, 69726, 69754, 69762, 69764, 69776, 69790,
			69792, 69820, 69830, 69836, 69848, 69870, 69874, 69876, 69890, 69918,
			69920, 69948, 69952, 70008, 70022, 70040, 70064, 70078, 70094, 70108,
			70114, 70116, 70120, 70134, 70152, 70174, 70176, 70264, 70384, 70412,
			70448, 70462, 70496, 70524, 70542, 70556, 70584, 70594, 70600, 70608,
			70622, 70630, 70636, 70664, 70672, 70686, 70688, 70716, 70720, 70776,
			70896, 71136, 71180, 71192, 71216, 71230, 71264, 71292, 71360, 71416,
			71452, 71480, 71536, 71550, 71554, 71556, 71560, 71568, 71582, 71584,
			71612, 71622, 71628, 71640, 71662, 71726, 71732, 71758, 71772, 71778,
			71780, 71784, 71798, 71822, 71836, 71864, 71874, 71880, 71888, 71902,
			71910, 71916, 71930, 71950, 71964, 71992, 72048, 72062, 72066, 72068,
			72080, 72094, 72096, 72124, 72134, 72140, 72152, 72174, 72178, 72180,
			72206, 72220, 72248, 72304, 72318, 72416, 72444, 72456, 72464, 72478,
			72480, 72508, 72512, 72568, 72588, 72600, 72624, 72638, 72654, 72668,
			72674, 72676, 72680, 72694, 72726, 72742, 72748, 72774, 72780, 72792,
			72814, 72838, 72856, 72880, 72894, 72910, 72924, 72930, 72932, 72936,
			72950, 72966, 72972, 72984, 73008, 73022, 73056, 73084, 73102, 73116,
			73144, 73156, 73160, 73168, 73182, 73190, 73196, 73210, 73226, 73234,
			73236, 73250, 73252, 73256, 73270, 73282, 73284, 73296, 73310, 73318,
			73324, 73346, 73348, 73352, 73360, 73374, 73376, 73404, 73414, 73420,
			73432, 73454, 73498, 73518, 73522, 73524, 73550, 73564, 73570, 73572,
			73576, 73590, 73800, 73822, 73858, 73860, 73872, 73886, 73888, 73916,
			73944, 73970, 73972, 73992, 74014, 74016, 74044, 74048, 74104, 74118,
			74136, 74160, 74174, 74210, 74212, 74216, 74230, 74244, 74256, 74270,
			74272, 74360, 74480, 74502, 74508, 74544, 74558, 74592, 74620, 74638,
			74652, 74680, 74690, 74696, 74704, 74726, 74732, 74782, 74784, 74812,
			74992, 75232, 75288, 75326, 75360, 75388, 75456, 75512, 75576, 75632,
			75646, 75650, 75652, 75664, 75678, 75680, 75708, 75718, 75724, 75736,
			75758, 75808, 75836, 75840, 75896, 76016, 76256, 76736, 76824, 76848,
			76862, 76896, 76924, 76992, 77048, 77296, 77340, 77368, 77424, 77438,
			77536, 77564, 77572, 77576, 77584, 77600, 77628, 77632, 77688, 77702,
			77708, 77720, 77744, 77758, 77774, 77788, 77870, 77902, 77916, 77922,
			77928, 77966, 77980, 78008, 78018, 78024, 78032, 78046, 78060, 78074,
			78094, 78136, 78192, 78206, 78210, 78212, 78224, 78238, 78240, 78268,
			78278, 78284, 78296, 78322, 78324, 78350, 78364, 78448, 78462, 78560,
			78588, 78600, 78622, 78624, 78652, 78656, 78712, 78726, 78744, 78768,
			78782, 78798, 78812, 78818, 78820, 78824, 78838, 78862, 78876, 78904,
			78960, 78974, 79072, 79100, 79296, 79352, 79368, 79376, 79390, 79392,
			79420, 79424, 79480, 79600, 79628, 79640, 79664, 79678, 79712, 79740,
			79772, 79800, 79810, 79812, 79816, 79824, 79838, 79846, 79852, 79894,
			79910, 79916, 79942, 79948, 79960, 79982, 79988, 80006, 80024, 80048,
			80062, 80078, 80092, 80098, 80100, 80104, 80134, 80140, 80176, 80190,
			80224, 80252, 80270, 80284, 80312, 80328, 80336, 80350, 80358, 80364,
			80378, 80390, 80396, 80408, 80432, 80446, 80480, 80508, 80576, 80632,
			80654, 80668, 80696, 80752, 80766, 80776, 80784, 80798, 80800, 80828,
			80844, 80856, 80878, 80882, 80884, 80914, 80916, 80930, 80932, 80936,
			80950, 80962, 80968, 80976, 80990, 80998, 81004, 81026, 81028, 81040,
			81054, 81056, 81084, 81094, 81100, 81112, 81134, 81154, 81156, 81160,
			81168, 81182, 81184, 81212, 81216, 81272, 81286, 81292, 81304, 81328,
			81342, 81358, 81372, 81380, 81384, 81398, 81434, 81454, 81458, 81460,
			81486, 81500, 81506, 81508, 81512, 81526, 81550, 81564, 81592, 81602,
			81604, 81608, 81616, 81630, 81638, 81644, 81702, 81708, 81722, 81734,
			81740, 81752, 81774, 81778, 81780, 82050, 82078, 82080, 82108, 82180,
			82184, 82192, 82206, 82208, 82236, 82240, 82296, 82316, 82328, 82352,
			82366, 82402, 82404, 82408, 82440, 82448, 82462, 82464, 82492, 82496,
			82552, 82672, 82694, 82700, 82712, 82736, 82750, 82784, 82812, 82830,
			82882, 82884, 82888, 82896, 82918, 82924, 82952, 82960, 82974, 82976,
			83004, 83008, 83064, 83184, 83424, 83468, 83480, 83504, 83518, 83552,
			83580, 83648, 83704, 83740, 83768, 83824, 83838, 83842, 83844, 83848,
			83856, 83872, 83900, 83910, 83916, 83928, 83950, 83984, 84000, 84028,
			84032, 84088, 84208, 84448, 84928, 85040, 85054, 85088, 85116, 85184,
			85240, 85488, 85560, 85616, 85630, 85728, 85756, 85764, 85768, 85776,
			85790, 85792, 85820, 85824, 85880, 85894, 85900, 85912, 85936, 85966,
			85980, 86048, 86080, 86136, 86256, 86496, 86976, 88160, 88188, 88256,
			88312, 88560, 89056, 89200, 89214, 89312, 89340, 89536, 89592, 89608,
			89616, 89632, 89664, 89720, 89840, 89868, 89880, 89904, 89952, 89980,
			89998, 90012, 90040, 90190, 90204, 90254, 90268, 90296, 90306, 90308,
			90312, 90334, 90382, 90396, 90424, 90480, 90494, 90500, 90504, 90512,
			90526, 90528, 90556, 90566, 90572, 90584, 90610, 90612, 90638, 90652,
			90680, 90736, 90750, 90848, 90876, 90884, 90888, 90896, 90910, 90912,
			90940, 90944, 91000, 91014, 91020, 91032, 91056, 91070, 91086, 91100,
			91106, 91108, 91112, 91126, 91150, 91164, 91192, 91248, 91262, 91360,
			91388, 91584, 91640, 91664, 91678, 91680, 91708, 91712, 91768, 91888,
			91928, 91952, 91966, 92000, 92028, 92046, 92060, 92088, 92098, 92100,
			92104, 92112, 92126, 92134, 92140, 92188, 92216, 92272, 92384, 92412,
			92608, 92664, 93168, 93200, 93214, 93216, 93244, 93248, 93304, 93424,
			93664, 93720, 93744, 93758, 93792, 93820, 93888, 93944, 93980, 94008,
			94064, 94078, 94084, 94088, 94096, 94110, 94112, 94140, 94150, 94156,
			94168, 94246, 94252, 94278, 94284, 94296, 94318, 94342, 94348, 94360,
			94384, 94398, 94414, 94428, 94440, 94470, 94476, 94488, 94512, 94526,
			94560, 94588, 94606, 94620, 94648, 94658, 94660, 94664, 94672, 94686,
			94694, 94700, 94714, 94726, 94732, 94744, 94768, 94782, 94816, 94844,
			94912, 94968, 94990, 95004, 95032, 95088, 95102, 95112, 95120, 95134,
			95136, 95164, 95180, 95192, 95214, 95218, 95220, 95244, 95256, 95280,
			95294, 95328, 95356, 95424, 95480, 95728, 95758, 95772, 95800, 95856,
			95870, 95968, 95996, 96008, 96016, 96030, 96032, 96060, 96064, 96120,
			96152, 96176, 96190, 96220, 96226, 96228, 96232, 96290, 96292, 96296,
			96310, 96322, 96324, 96328, 96336, 96350, 96358, 96364, 96386, 96388,
			96392, 96400, 96414, 96416, 96444, 96454, 96460, 96472, 96494, 96498,
			96500, 96514, 96516, 96520, 96528, 96542, 96544, 96572, 96576, 96632,
			96646, 96652, 96664, 96688, 96702, 96718, 96732, 96738, 96740, 96744,
			96758, 96772, 96776, 96784, 96798, 96800, 96828, 96832, 96888, 97008,
			97030, 97036, 97048, 97072, 97086, 97120, 97148, 97166, 97180, 97208,
			97220, 97224, 97232, 97246, 97254, 97260, 97326, 97330, 97332, 97358,
			97372, 97378, 97380, 97384, 97398, 97422, 97436, 97464, 97474, 97476,
			97480, 97488, 97502, 97510, 97516, 97550, 97564, 97592, 97648, 97666,
			97668, 97672, 97680, 97694, 97696, 97724, 97734, 97740, 97752, 97774,
			97830, 97836, 97850, 97862, 97868, 97880, 97902, 97906, 97908, 97926,
			97932, 97944, 97968, 97998, 98012, 98018, 98020, 98024, 98038, 98618,
			98674, 98676, 98838, 98854, 98874, 98892, 98904, 98926, 98930, 98932,
			98968, 99006, 99042, 99044, 99048, 99062, 99166, 99194, 99246, 99286,
			99350, 99366, 99372, 99386, 99398, 99416, 99438, 99442, 99444, 99462,
			99504, 99518, 99534, 99548, 99554, 99556, 99560, 99574, 99590, 99596,
			99608, 99632, 99646, 99680, 99708, 99726, 99740, 99768, 99778, 99780,
			99784, 99792, 99806, 99814, 99820, 99834, 99858, 99860, 99874, 99880,
			99894, 99906, 99920, 99934, 99962, 99970, 99972, 99976, 99984, 99998,
			100000, 100028, 100038, 100044, 100056, 100078, 100082, 100084, 100142, 100174,
			100188, 100246, 100262, 100268, 100306, 100308, 100390, 100396, 100410, 100422,
			100428, 100440, 100462, 100466, 100468, 100486, 100504, 100528, 100542, 100558,
			100572, 100578, 100580, 100584, 100598, 100620, 100656, 100670, 100704, 100732,
			100750, 100792, 100802, 100808, 100816, 100830, 100838, 100844, 100858, 100888,
			100912, 100926, 100960, 100988, 101056, 101112, 101148, 101176, 101232, 101246,
			101250, 101252, 101256, 101264, 101278, 101280, 101308, 101318, 101324, 101336,
			101358, 101362, 101364, 101410, 101412, 101416, 101430, 101442, 101448, 101456,
			101470, 101478, 101498, 101506, 101508, 101520, 101534, 101536, 101564, 101580,
			101618, 101620, 101636, 101640, 101648, 101662, 101664, 101692, 101696, 101752,
			101766, 101784, 101838, 101858, 101860, 101864, 101934, 101938, 101940, 101966,
			101980, 101986, 101988, 101992, 102030, 102044, 102072, 102082, 102084, 102088,
			102096, 102138, 102166, 102182, 102188, 102214, 102220, 102232, 102254, 102282,
			102290, 102292, 102306, 102308, 102312, 102326, 102444, 102458, 102470, 102476,
			102488, 102514, 102516, 102534, 102552, 102576, 102590, 102606, 102620, 102626,
			102632, 102646, 102662, 102668, 102704, 102718, 102752, 102780, 102798, 102812,
			102840, 102850, 102856, 102864, 102878, 102886, 102892, 102906, 102936, 102974,
			103008, 103036, 103104, 103160, 103224, 103280, 103294, 103298, 103300, 103312,
			103326, 103328, 103356, 103366, 103372, 103384, 103406, 103410, 103412, 103472,
			103486, 103520, 103548, 103616, 103672, 103920, 103992, 104048, 104062, 104160,
			104188, 104194, 104196, 104200, 104208, 104224, 104252, 104256, 104312, 104326,
			104332, 104344, 104368, 104382, 104398, 104412, 104418, 104420, 104424, 104482,
			104484, 104514, 104520, 104528, 104542, 104550, 104570, 104578, 104580, 104592,
			104606, 104608, 104636, 104652, 104690, 104692, 104706, 104712, 104734, 104736,
			104764, 104768, 104824, 104838, 104856, 104910, 104930, 104932, 104936, 104968,
			104976, 104990, 104992, 105020, 105024, 105080, 105200, 105240, 105278, 105312,
			105372, 105410, 105412, 105416, 105424, 105446, 105518, 105524, 105550, 105564,
			105570, 105572, 105576, 105614, 105628, 105656, 105666, 105672, 105680, 105702,
			105722, 105742, 105756, 105784, 105840, 105854, 105858, 105860, 105864, 105872,
			105888, 105932, 105970, 105972, 106006, 106022, 106028, 106054, 106060, 106072,
			106100, 106118, 106124, 106136, 106160, 106174, 106190, 106210, 106212, 106216,
			106250, 106258, 106260, 106274, 106276, 106280, 106306, 106308, 106312, 106320,
			106334, 106348, 106394, 106414, 106418, 106420, 106566, 106572, 106610, 106612,
			106630, 106636, 106648, 106672, 106686, 106722, 106724, 106728, 106742, 106758,
			106764, 106776, 106800, 106814, 106848, 106876, 106894, 106908, 106936, 106946,
			106948, 106952, 106960, 106974, 106982, 106988, 107032, 107056, 107070, 107104,
			107132, 107200, 107256, 107292, 107320, 107376, 107390, 107394, 107396, 107400,
			107408, 107422, 107424, 107452, 107462, 107468, 107480, 107502, 107506, 107508,
			107544, 107568, 107582, 107616, 107644, 107712, 107768, 108016, 108060, 108088,
			108144, 108158, 108256, 108284, 108290, 108292, 108296, 108304, 108318, 108320,
			108348, 108352, 108408, 108422, 108428, 108440, 108464, 108478, 108494, 108508,
			108514, 108516, 108520, 108592, 108640, 108668, 108736, 108792, 109040, 109536,
			109680, 109694, 109792, 109820, 110016, 110072, 110084, 110088, 110096, 110112,
			110140, 110144, 110200, 110320, 110342, 110348, 110360, 110384, 110398, 110432,
			110460, 110478, 110492, 110520, 110532, 110536, 110544, 110558, 110658, 110686,
			110714, 110722, 110724, 110728, 110736, 110750, 110752, 110780, 110796, 110834,
			110836, 110850, 110852, 110856, 110864, 110878, 110880, 110908, 110912, 110968,
			110982, 111000, 111054, 111074, 111076, 111080, 111108, 111112, 111120, 111134,
			111136, 111164, 111168, 111224, 111344, 111372, 111422, 111456, 111516, 111554,
			111556, 111560, 111568, 111590, 111632, 111646, 111648, 111676, 111680, 111736,
			111856, 112096, 112152, 112224, 112252, 112320, 112440, 112514, 112516, 112520,
			112528, 112542, 112544, 112588, 112686, 112718, 112732, 112782, 112796, 112824,
			112834, 112836, 112840, 112848, 112870, 112890, 112910, 112924, 112952, 113008,
			113022, 113026, 113028, 113032, 113040, 113054, 113056, 113100, 113138, 113140,
			113166, 113180, 113208, 113264, 113278, 113376, 113404, 113416, 113424, 113440,
			113468, 113472, 113560, 113614, 113634, 113636, 113640, 113686, 113702, 113708,
			113734, 113740, 113752, 113778, 113780, 113798, 113804, 113816, 113840, 113854,
			113870, 113890, 113892, 113896, 113926, 113932, 113944, 113968, 113982, 114016,
			114044, 114076, 114114, 114116, 114120, 114128, 114150, 114170, 114194, 114196,
			114210, 114212, 114216, 114242, 114244, 114248, 114256, 114270, 114278, 114306,
			114308, 114312, 114320, 114334, 114336, 114364, 114380, 114420, 114458, 114478,
			114482, 114484, 114510, 114524, 114530, 114532, 114536, 114842, 114866, 114868,
			114970, 114994, 114996, 115042, 115044, 115048, 115062, 115130, 115226, 115250,
			115252, 115278, 115292, 115298, 115300, 115304, 115318, 115342, 115394, 115396,
			115400, 115408, 115422, 115430, 115436, 115450, 115478, 115494, 115514, 115526,
			115532, 115570, 115572, 115738, 115758, 115762, 115764, 115790, 115804, 115810,
			115812, 115816, 115830, 115854, 115868, 115896, 115906, 115912, 115920, 115934,
			115942, 115948, 115962, 115996, 116024, 116080, 116094, 116098, 116100, 116104,
			116112, 116126, 116128, 116156, 116166, 116172, 116184, 116206, 116210, 116212,
			116246, 116262, 116268, 116282, 116294, 116300, 116312, 116334, 116338, 116340,
			116358, 116364, 116376, 116400, 116414, 116430, 116444, 116450, 116452, 116456,
			116498, 116500, 116514, 116520, 116534, 116546, 116548, 116552, 116560, 116574,
			116582, 116588, 116602, 116654, 116694, 116714, 116762, 116782, 116786, 116788,
			116814, 116828, 116834, 116836, 116840, 116854, 116878, 116892, 116920, 116930,
			116936, 116944, 116958, 116966, 116972, 116986, 117006, 117048, 117104, 117118,
			117122, 117124, 117136, 117150, 117152, 117180, 117190, 117196, 117208, 117230,
			117234, 117236, 117304, 117360, 117374, 117472, 117500, 117506, 117508, 117512,
			117520, 117536, 117564, 117568, 117624, 117638, 117644, 117656, 117680, 117694,
			117710, 117724, 117730, 117732, 117736, 117750, 117782, 117798, 117804, 117818,
			117830, 117848, 117874, 117876, 117894, 117936, 117950, 117966, 117986, 117988,
			117992, 118022, 118028, 118040, 118064, 118078, 118112, 118140, 118172, 118210,
			118212, 118216, 118224, 118238, 118246, 118266, 118306, 118312, 118338, 118352,
			118366, 118374, 118394, 118402, 118404, 118408, 118416, 118430, 118432, 118460,
			118476, 118514, 118516, 118574, 118578, 118580, 118606, 118620, 118626, 118628,
			118632, 118678, 118694, 118700, 118730, 118738, 118740, 118830, 118834, 118836,
			118862, 118876, 118882, 118884, 118888, 118902, 118926, 118940, 118968, 118978,
			118980, 118984, 118992, 119006, 119014, 119020, 119034, 119068, 119096, 119152,
			119166, 119170, 119172, 119176, 119184, 119198, 119200, 119228, 119238, 119244,
			119256, 119278, 119282, 119284, 119324, 119352, 119408, 119422, 119520, 119548,
			119554, 119556, 119560, 119568, 119582, 119584, 119612, 119616, 119672, 119686,
			119692, 119704, 119728, 119742, 119758, 119772, 119778, 119780, 119784, 119798,
			119920, 119934, 120032, 120060, 120256, 120312, 120324, 120328, 120336, 120352,
			120384, 120440, 120560, 120582, 120588, 120600, 120624, 120638, 120672, 120700,
			120718, 120732, 120760, 120770, 120772, 120776, 120784, 120798, 120806, 120812,
			120870, 120876, 120890, 120902, 120908, 120920, 120946, 120948, 120966, 120972,
			120984, 121008, 121022, 121038, 121058, 121060, 121064, 121078, 121100, 121112,
			121136, 121150, 121184, 121212, 121244, 121282, 121284, 121288, 121296, 121318,
			121338, 121356, 121368, 121392, 121406, 121440, 121468, 121536, 121592, 121656,
			121730, 121732, 121736, 121744, 121758, 121760, 121804, 121842, 121844, 121890,
			121922, 121924, 121928, 121936, 121950, 121958, 121978, 121986, 121988, 121992,
			122000, 122014, 122016, 122044, 122060, 122098, 122100, 122116, 122120, 122128,
			122142, 122144, 122172, 122176, 122232, 122246, 122264, 122318, 122338, 122340,
			122344, 122414, 122418, 122420, 122446, 122460, 122466, 122468, 122472, 122510,
			122524, 122552, 122562, 122564, 122568, 122576, 122598, 122618, 122646, 122662,
			122668, 122694, 122700, 122712, 122738, 122740, 122762, 122770, 122772, 122786,
			122788, 122792, 123018, 123026, 123028, 123042, 123044, 123048, 123062, 123098,
			123146, 123154, 123156, 123170, 123172, 123176, 123190, 123202, 123204, 123208,
			123216, 123238, 123244, 123258, 123290, 123314, 123316, 123402, 123410, 123412,
			123426, 123428, 123432, 123446, 123458, 123464, 123472, 123486, 123494, 123500,
			123514, 123522, 123524, 123528, 123536, 123552, 123580, 123590, 123596, 123608,
			123630, 123634, 123636, 123674, 123698, 123700, 123740, 123746, 123748, 123752,
			123834, 123914, 123922, 123924, 123938, 123944, 123958, 123970, 123976, 123984,
			123998, 124006, 124012, 124026, 124034, 124036, 124048, 124062, 124064, 124092,
			124102, 124108, 124120, 124142, 124146, 124148, 124162, 124164, 124168, 124176,
			124190, 124192, 124220, 124224, 124280, 124294, 124300, 124312, 124336, 124350,
			124366, 124380, 124386, 124388, 124392, 124406, 124442, 124462, 124466, 124468,
			124494, 124508, 124514, 124520, 124558, 124572, 124600, 124610, 124612, 124616,
			124624, 124646, 124666, 124694, 124710, 124716, 124730, 124742, 124748, 124760,
			124786, 124788, 124818, 124820, 124834, 124836, 124840, 124854, 124946, 124948,
			124962, 124964, 124968, 124982, 124994, 124996, 125000, 125008, 125022, 125030,
			125036, 125050, 125058, 125060, 125064, 125072, 125086, 125088, 125116, 125126,
			125132, 125144, 125166, 125170, 125172, 125186, 125188, 125192, 125200, 125216,
			125244, 125248, 125304, 125318, 125324, 125336, 125360, 125374, 125390, 125404,
			125410, 125412, 125416, 125430, 125444, 125448, 125456, 125472, 125504, 125560,
			125680, 125702, 125708, 125720, 125744, 125758, 125792, 125820, 125838, 125852,
			125880, 125890, 125892, 125896, 125904, 125918, 125926, 125932, 125978, 125998,
			126002, 126004, 126030, 126044, 126050, 126052, 126056, 126094, 126108, 126136,
			126146, 126148, 126152, 126160, 126182, 126202, 126222, 126236, 126264, 126320,
			126334, 126338, 126340, 126344, 126352, 126366, 126368, 126412, 126450, 126452,
			126486, 126502, 126508, 126522, 126534, 126540, 126552, 126574, 126578, 126580,
			126598, 126604, 126616, 126640, 126654, 126670, 126684, 126690, 126692, 126696,
			126738, 126754, 126756, 126760, 126774, 126786, 126788, 126792, 126800, 126814,
			126822, 126828, 126842, 126894, 126898, 126900, 126934, 127126, 127142, 127148,
			127162, 127178, 127186, 127188, 127254, 127270, 127276, 127290, 127302, 127308,
			127320, 127342, 127346, 127348, 127370, 127378, 127380, 127394, 127396, 127400,
			127450, 127510, 127526, 127532, 127546, 127558, 127576, 127598, 127602, 127604,
			127622, 127628, 127640, 127664, 127678, 127694, 127708, 127714, 127716, 127720,
			127734, 127754, 127762, 127764, 127778, 127784, 127810, 127812, 127816, 127824,
			127838, 127846, 127866, 127898, 127918, 127922, 127924, 128022, 128038, 128044,
			128058, 128070, 128076, 128088, 128110, 128114, 128116, 128134, 128140, 128152,
			128176, 128190, 128206, 128220, 128226, 128228, 128232, 128246, 128262, 128268,
			128280, 128304, 128318, 128352, 128380, 128398, 128412, 128440, 128450, 128452,
			128456, 128464, 128478, 128486, 128492, 128506, 128522, 128530, 128532, 128546,
			128548, 128552, 128566, 128578, 128580, 128584, 128592, 128606, 128614, 128634,
			128642, 128644, 128648, 128656, 128670, 128672, 128700, 128716, 128754, 128756,
			128794, 128814, 128818, 128820, 128846, 128860, 128866, 128868, 128872, 128886,
			128918, 128934, 128940, 128954, 128978, 128980, 129178, 129198, 129202, 129204,
			129238, 129258, 129306, 129326, 129330, 129332, 129358, 129372, 129378, 129380,
			129384, 129398, 129430, 129446, 129452, 129466, 129482, 129490, 129492, 129562,
			129582, 129586, 129588, 129614, 129628, 129634, 129636, 129640, 129654, 129678,
			129692, 129720, 129730, 129732, 129736, 129744, 129758, 129766, 129772, 129814,
			129830, 129836, 129850, 129862, 129868, 129880, 129902, 129906, 129908, 129930,
			129938, 129940, 129954, 129956, 129960, 129974, 130010
		};

		private static readonly int[] CODEWORD_TABLE = new int[2787]
		{
			2627, 1819, 2622, 2621, 1813, 1812, 2729, 2724, 2723, 2779,
			2774, 2773, 902, 896, 908, 868, 865, 861, 859, 2511,
			873, 871, 1780, 835, 2493, 825, 2491, 842, 837, 844,
			1764, 1762, 811, 810, 809, 2483, 807, 2482, 806, 2480,
			815, 814, 813, 812, 2484, 817, 816, 1745, 1744, 1742,
			1746, 2655, 2637, 2635, 2626, 2625, 2623, 2628, 1820, 2752,
			2739, 2737, 2728, 2727, 2725, 2730, 2785, 2783, 2778, 2777,
			2775, 2780, 787, 781, 747, 739, 736, 2413, 754, 752,
			1719, 692, 689, 681, 2371, 678, 2369, 700, 697, 694,
			703, 1688, 1686, 642, 638, 2343, 631, 2341, 627, 2338,
			651, 646, 643, 2345, 654, 652, 1652, 1650, 1647, 1654,
			601, 599, 2322, 596, 2321, 594, 2319, 2317, 611, 610,
			608, 606, 2324, 603, 2323, 615, 614, 612, 1617, 1616,
			1614, 1612, 616, 1619, 1618, 2575, 2538, 2536, 905, 901,
			898, 909, 2509, 2507, 2504, 870, 867, 864, 860, 2512,
			875, 872, 1781, 2490, 2489, 2487, 2485, 1748, 836, 834,
			832, 830, 2494, 827, 2492, 843, 841, 839, 845, 1765,
			1763, 2701, 2676, 2674, 2653, 2648, 2656, 2634, 2633, 2631,
			2629, 1821, 2638, 2636, 2770, 2763, 2761, 2750, 2745, 2753,
			2736, 2735, 2733, 2731, 1848, 2740, 2738, 2786, 2784, 591,
			588, 576, 569, 566, 2296, 1590, 537, 534, 526, 2276,
			522, 2274, 545, 542, 539, 548, 1572, 1570, 481, 2245,
			466, 2242, 462, 2239, 492, 485, 482, 2249, 496, 494,
			1534, 1531, 1528, 1538, 413, 2196, 406, 2191, 2188, 425,
			419, 2202, 415, 2199, 432, 430, 427, 1472, 1467, 1464,
			433, 1476, 1474, 368, 367, 2160, 365, 2159, 362, 2157,
			2155, 2152, 378, 377, 375, 2166, 372, 2165, 369, 2162,
			383, 381, 379, 2168, 1419, 1418, 1416, 1414, 385, 1411,
			384, 1423, 1422, 1420, 1424, 2461, 802, 2441, 2439, 790,
			786, 783, 794, 2409, 2406, 2403, 750, 742, 738, 2414,
			756, 753, 1720, 2367, 2365, 2362, 2359, 1663, 693, 691,
			684, 2373, 680, 2370, 702, 699, 696, 704, 1690, 1687,
			2337, 2336, 2334, 2332, 1624, 2329, 1622, 640, 637, 2344,
			634, 2342, 630, 2340, 650, 648, 645, 2346, 655, 653,
			1653, 1651, 1649, 1655, 2612, 2597, 2595, 2571, 2568, 2565,
			2576, 2534, 2529, 2526, 1787, 2540, 2537, 907, 904, 900,
			910, 2503, 2502, 2500, 2498, 1768, 2495, 1767, 2510, 2508,
			2506, 869, 866, 863, 2513, 876, 874, 1782, 2720, 2713,
			2711, 2697, 2694, 2691, 2702, 2672, 2670, 2664, 1828, 2678,
			2675, 2647, 2646, 2644, 2642, 1823, 2639, 1822, 2654, 2652,
			2650, 2657, 2771, 1855, 2765, 2762, 1850, 1849, 2751, 2749,
			2747, 2754, 353, 2148, 344, 342, 336, 2142, 332, 2140,
			345, 1375, 1373, 306, 2130, 299, 2128, 295, 2125, 319,
			314, 311, 2132, 1354, 1352, 1349, 1356, 262, 257, 2101,
			253, 2096, 2093, 274, 273, 267, 2107, 263, 2104, 280,
			278, 275, 1316, 1311, 1308, 1320, 1318, 2052, 202, 2050,
			2044, 2040, 219, 2063, 212, 2060, 208, 2055, 224, 221,
			2066, 1260, 1258, 1252, 231, 1248, 229, 1266, 1264, 1261,
			1268, 155, 1998, 153, 1996, 1994, 1991, 1988, 165, 164,
			2007, 162, 2006, 159, 2003, 2000, 172, 171, 169, 2012,
			166, 2010, 1186, 1184, 1182, 1179, 175, 1176, 173, 1192,
			1191, 1189, 1187, 176, 1194, 1193, 2313, 2307, 2305, 592,
			589, 2294, 2292, 2289, 578, 572, 568, 2297, 580, 1591,
			2272, 2267, 2264, 1547, 538, 536, 529, 2278, 525, 2275,
			547, 544, 541, 1574, 1571, 2237, 2235, 2229, 1493, 2225,
			1489, 478, 2247, 470, 2244, 465, 2241, 493, 488, 484,
			2250, 498, 495, 1536, 1533, 1530, 1539, 2187, 2186, 2184,
			2182, 1432, 2179, 1430, 2176, 1427, 414, 412, 2197, 409,
			2195, 405, 2193, 2190, 426, 424, 421, 2203, 418, 2201,
			431, 429, 1473, 1471, 1469, 1466, 434, 1477, 1475, 2478,
			2472, 2470, 2459, 2457, 2454, 2462, 803, 2437, 2432, 2429,
			1726, 2443, 2440, 792, 789, 785, 2401, 2399, 2393, 1702,
			2389, 1699, 2411, 2408, 2405, 745, 741, 2415, 758, 755,
			1721, 2358, 2357, 2355, 2353, 1661, 2350, 1660, 2347, 1657,
			2368, 2366, 2364, 2361, 1666, 690, 687, 2374, 683, 2372,
			701, 698, 705, 1691, 1689, 2619, 2617, 2610, 2608, 2605,
			2613, 2593, 2588, 2585, 1803, 2599, 2596, 2563, 2561, 2555,
			1797, 2551, 1795, 2573, 2570, 2567, 2577, 2525, 2524, 2522,
			2520, 1786, 2517, 1785, 2514, 1783, 2535, 2533, 2531, 2528,
			1788, 2541, 2539, 906, 903, 911, 2721, 1844, 2715, 2712,
			1838, 1836, 2699, 2696, 2693, 2703, 1827, 1826, 1824, 2673,
			2671, 2669, 2666, 1829, 2679, 2677, 1858, 1857, 2772, 1854,
			1853, 1851, 1856, 2766, 2764, 143, 1987, 139, 1986, 135,
			133, 131, 1984, 128, 1983, 125, 1981, 138, 137, 136,
			1985, 1133, 1132, 1130, 112, 110, 1974, 107, 1973, 104,
			1971, 1969, 122, 121, 119, 117, 1977, 114, 1976, 124,
			1115, 1114, 1112, 1110, 1117, 1116, 84, 83, 1953, 81,
			1952, 78, 1950, 1948, 1945, 94, 93, 91, 1959, 88,
			1958, 85, 1955, 99, 97, 95, 1961, 1086, 1085, 1083,
			1081, 1078, 100, 1090, 1089, 1087, 1091, 49, 47, 1917,
			44, 1915, 1913, 1910, 1907, 59, 1926, 56, 1925, 53,
			1922, 1919, 66, 64, 1931, 61, 1929, 1042, 1040, 1038,
			71, 1035, 70, 1032, 68, 1048, 1047, 1045, 1043, 1050,
			1049, 12, 10, 1869, 1867, 1864, 1861, 21, 1880, 19,
			1877, 1874, 1871, 28, 1888, 25, 1886, 22, 1883, 982,
			980, 977, 974, 32, 30, 991, 989, 987, 984, 34,
			995, 994, 992, 2151, 2150, 2147, 2146, 2144, 356, 355,
			354, 2149, 2139, 2138, 2136, 2134, 1359, 343, 341, 338,
			2143, 335, 2141, 348, 347, 346, 1376, 1374, 2124, 2123,
			2121, 2119, 1326, 2116, 1324, 310, 308, 305, 2131, 302,
			2129, 298, 2127, 320, 318, 316, 313, 2133, 322, 321,
			1355, 1353, 1351, 1357, 2092, 2091, 2089, 2087, 1276, 2084,
			1274, 2081, 1271, 259, 2102, 256, 2100, 252, 2098, 2095,
			272, 269, 2108, 266, 2106, 281, 279, 277, 1317, 1315,
			1313, 1310, 282, 1321, 1319, 2039, 2037, 2035, 2032, 1203,
			2029, 1200, 1197, 207, 2053, 205, 2051, 201, 2049, 2046,
			2043, 220, 218, 2064, 215, 2062, 211, 2059, 228, 226,
			223, 2069, 1259, 1257, 1254, 232, 1251, 230, 1267, 1265,
			1263, 2316, 2315, 2312, 2311, 2309, 2314, 2304, 2303, 2301,
			2299, 1593, 2308, 2306, 590, 2288, 2287, 2285, 2283, 1578,
			2280, 1577, 2295, 2293, 2291, 579, 577, 574, 571, 2298,
			582, 581, 1592, 2263, 2262, 2260, 2258, 1545, 2255, 1544,
			2252, 1541, 2273, 2271, 2269, 2266, 1550, 535, 532, 2279,
			528, 2277, 546, 543, 549, 1575, 1573, 2224, 2222, 2220,
			1486, 2217, 1485, 2214, 1482, 1479, 2238, 2236, 2234, 2231,
			1496, 2228, 1492, 480, 477, 2248, 473, 2246, 469, 2243,
			490, 487, 2251, 497, 1537, 1535, 1532, 2477, 2476, 2474,
			2479, 2469, 2468, 2466, 2464, 1730, 2473, 2471, 2453, 2452,
			2450, 2448, 1729, 2445, 1728, 2460, 2458, 2456, 2463, 805,
			804, 2428, 2427, 2425, 2423, 1725, 2420, 1724, 2417, 1722,
			2438, 2436, 2434, 2431, 1727, 2444, 2442, 793, 791, 788,
			795, 2388, 2386, 2384, 1697, 2381, 1696, 2378, 1694, 1692,
			2402, 2400, 2398, 2395, 1703, 2392, 1701, 2412, 2410, 2407,
			751, 748, 744, 2416, 759, 757, 1807, 2620, 2618, 1806,
			1805, 2611, 2609, 2607, 2614, 1802, 1801, 1799, 2594, 2592,
			2590, 2587, 1804, 2600, 2598, 1794, 1793, 1791, 1789, 2564,
			2562, 2560, 2557, 1798, 2554, 1796, 2574, 2572, 2569, 2578,
			1847, 1846, 2722, 1843, 1842, 1840, 1845, 2716, 2714, 1835,
			1834, 1832, 1830, 1839, 1837, 2700, 2698, 2695, 2704, 1817,
			1811, 1810, 897, 862, 1777, 829, 826, 838, 1760, 1758,
			808, 2481, 1741, 1740, 1738, 1743, 2624, 1818, 2726, 2776,
			782, 740, 737, 1715, 686, 679, 695, 1682, 1680, 639,
			628, 2339, 647, 644, 1645, 1643, 1640, 1648, 602, 600,
			597, 595, 2320, 593, 2318, 609, 607, 604, 1611, 1610,
			1608, 1606, 613, 1615, 1613, 2328, 926, 924, 892, 886,
			899, 857, 850, 2505, 1778, 824, 823, 821, 819, 2488,
			818, 2486, 833, 831, 828, 840, 1761, 1759, 2649, 2632,
			2630, 2746, 2734, 2732, 2782, 2781, 570, 567, 1587, 531,
			527, 523, 540, 1566, 1564, 476, 467, 463, 2240, 486,
			483, 1524, 1521, 1518, 1529, 411, 403, 2192, 399, 2189,
			423, 416, 1462, 1457, 1454, 428, 1468, 1465, 2210, 366,
			363, 2158, 360, 2156, 357, 2153, 376, 373, 370, 2163,
			1410, 1409, 1407, 1405, 382, 1402, 380, 1417, 1415, 1412,
			1421, 2175, 2174, 777, 774, 771, 784, 732, 725, 722,
			2404, 743, 1716, 676, 674, 668, 2363, 665, 2360, 685,
			1684, 1681, 626, 624, 622, 2335, 620, 2333, 617, 2330,
			641, 635, 649, 1646, 1644, 1642, 2566, 928, 925, 2530,
			2527, 894, 891, 888, 2501, 2499, 2496, 858, 856, 854,
			851, 1779, 2692, 2668, 2665, 2645, 2643, 2640, 2651, 2768,
			2759, 2757, 2744, 2743, 2741, 2748, 352, 1382, 340, 337,
			333, 1371, 1369, 307, 300, 296, 2126, 315, 312, 1347,
			1342, 1350, 261, 258, 250, 2097, 246, 2094, 271, 268,
			264, 1306, 1301, 1298, 276, 1312, 1309, 2115, 203, 2048,
			195, 2045, 191, 2041, 213, 209, 2056, 1246, 1244, 1238,
			225, 1234, 222, 1256, 1253, 1249, 1262, 2080, 2079, 154,
			1997, 150, 1995, 147, 1992, 1989, 163, 160, 2004, 156,
			2001, 1175, 1174, 1172, 1170, 1167, 170, 1164, 167, 1185,
			1183, 1180, 1177, 174, 1190, 1188, 2025, 2024, 2022, 587,
			586, 564, 559, 556, 2290, 573, 1588, 520, 518, 512,
			2268, 508, 2265, 530, 1568, 1565, 461, 457, 2233, 450,
			2230, 446, 2226, 479, 471, 489, 1526, 1523, 1520, 397,
			395, 2185, 392, 2183, 389, 2180, 2177, 410, 2194, 402,
			422, 1463, 1461, 1459, 1456, 1470, 2455, 799, 2433, 2430,
			779, 776, 773, 2397, 2394, 2390, 734, 728, 724, 746,
			1717, 2356, 2354, 2351, 2348, 1658, 677, 675, 673, 670,
			667, 688, 1685, 1683, 2606, 2589, 2586, 2559, 2556, 2552,
			927, 2523, 2521, 2518, 2515, 1784, 2532, 895, 893, 890,
			2718, 2709, 2707, 2689, 2687, 2684, 2663, 2662, 2660, 2658,
			1825, 2667, 2769, 1852, 2760, 2758, 142, 141, 1139, 1138,
			134, 132, 129, 126, 1982, 1129, 1128, 1126, 1131, 113,
			111, 108, 105, 1972, 101, 1970, 120, 118, 115, 1109,
			1108, 1106, 1104, 123, 1113, 1111, 82, 79, 1951, 75,
			1949, 72, 1946, 92, 89, 86, 1956, 1077, 1076, 1074,
			1072, 98, 1069, 96, 1084, 1082, 1079, 1088, 1968, 1967,
			48, 45, 1916, 42, 1914, 39, 1911, 1908, 60, 57,
			54, 1923, 50, 1920, 1031, 1030, 1028, 1026, 67, 1023,
			65, 1020, 62, 1041, 1039, 1036, 1033, 69, 1046, 1044,
			1944, 1943, 1941, 11, 9, 1868, 7, 1865, 1862, 1859,
			20, 1878, 16, 1875, 13, 1872, 970, 968, 966, 963,
			29, 960, 26, 23, 983, 981, 978, 975, 33, 971,
			31, 990, 988, 985, 1906, 1904, 1902, 993, 351, 2145,
			1383, 331, 330, 328, 326, 2137, 323, 2135, 339, 1372,
			1370, 294, 293, 291, 289, 2122, 286, 2120, 283, 2117,
			309, 303, 317, 1348, 1346, 1344, 245, 244, 242, 2090,
			239, 2088, 236, 2085, 2082, 260, 2099, 249, 270, 1307,
			1305, 1303, 1300, 1314, 189, 2038, 186, 2036, 183, 2033,
			2030, 2026, 206, 198, 2047, 194, 216, 1247, 1245, 1243,
			1240, 227, 1237, 1255, 2310, 2302, 2300, 2286, 2284, 2281,
			565, 563, 561, 558, 575, 1589, 2261, 2259, 2256, 2253,
			1542, 521, 519, 517, 514, 2270, 511, 533, 1569, 1567,
			2223, 2221, 2218, 2215, 1483, 2211, 1480, 459, 456, 453,
			2232, 449, 474, 491, 1527, 1525, 1522, 2475, 2467, 2465,
			2451, 2449, 2446, 801, 800, 2426, 2424, 2421, 2418, 1723,
			2435, 780, 778, 775, 2387, 2385, 2382, 2379, 1695, 2375,
			1693, 2396, 735, 733, 730, 727, 749, 1718, 2616, 2615,
			2604, 2603, 2601, 2584, 2583, 2581, 2579, 1800, 2591, 2550,
			2549, 2547, 2545, 1792, 2542, 1790, 2558, 929, 2719, 1841,
			2710, 2708, 1833, 1831, 2690, 2688, 2686, 1815, 1809, 1808,
			1774, 1756, 1754, 1737, 1736, 1734, 1739, 1816, 1711, 1676,
			1674, 633, 629, 1638, 1636, 1633, 1641, 598, 1605, 1604,
			1602, 1600, 605, 1609, 1607, 2327, 887, 853, 1775, 822,
			820, 1757, 1755, 1584, 524, 1560, 1558, 468, 464, 1514,
			1511, 1508, 1519, 408, 404, 400, 1452, 1447, 1444, 417,
			1458, 1455, 2208, 364, 361, 358, 2154, 1401, 1400, 1398,
			1396, 374, 1393, 371, 1408, 1406, 1403, 1413, 2173, 2172,
			772, 726, 723, 1712, 672, 669, 666, 682, 1678, 1675,
			625, 623, 621, 618, 2331, 636, 632, 1639, 1637, 1635,
			920, 918, 884, 880, 889, 849, 848, 847, 846, 2497,
			855, 852, 1776, 2641, 2742, 2787, 1380, 334, 1367, 1365,
			301, 297, 1340, 1338, 1335, 1343, 255, 251, 247, 1296,
			1291, 1288, 265, 1302, 1299, 2113, 204, 196, 192, 2042,
			1232, 1230, 1224, 214, 1220, 210, 1242, 1239, 1235, 1250,
			2077, 2075, 151, 148, 1993, 144, 1990, 1163, 1162, 1160,
			1158, 1155, 161, 1152, 157, 1173, 1171, 1168, 1165, 168,
			1181, 1178, 2021, 2020, 2018, 2023, 585, 560, 557, 1585,
			516, 509, 1562, 1559, 458, 447, 2227, 472, 1516, 1513,
			1510, 398, 396, 393, 390, 2181, 386, 2178, 407, 1453,
			1451, 1449, 1446, 420, 1460, 2209, 769, 764, 720, 712,
			2391, 729, 1713, 664, 663, 661, 659, 2352, 656, 2349,
			671, 1679, 1677, 2553, 922, 919, 2519, 2516, 885, 883,
			881, 2685, 2661, 2659, 2767, 2756, 2755, 140, 1137, 1136,
			130, 127, 1125, 1124, 1122, 1127, 109, 106, 102, 1103,
			1102, 1100, 1098, 116, 1107, 1105, 1980, 80, 76, 73,
			1947, 1068, 1067, 1065, 1063, 90, 1060, 87, 1075, 1073,
			1070, 1080, 1966, 1965, 46, 43, 40, 1912, 36, 1909,
			1019, 1018, 1016, 1014, 58, 1011, 55, 1008, 51, 1029,
			1027, 1024, 1021, 63, 1037, 1034, 1940, 1939, 1937, 1942,
			8, 1866, 4, 1863, 1, 1860, 956, 954, 952, 949,
			946, 17, 14, 969, 967, 964, 961, 27, 957, 24,
			979, 976, 972, 1901, 1900, 1898, 1896, 986, 1905, 1903,
			350, 349, 1381, 329, 327, 324, 1368, 1366, 292, 290,
			287, 284, 2118, 304, 1341, 1339, 1337, 1345, 243, 240,
			237, 2086, 233, 2083, 254, 1297, 1295, 1293, 1290, 1304,
			2114, 190, 187, 184, 2034, 180, 2031, 177, 2027, 199,
			1233, 1231, 1229, 1226, 217, 1223, 1241, 2078, 2076, 584,
			555, 554, 552, 550, 2282, 562, 1586, 507, 506, 504,
			502, 2257, 499, 2254, 515, 1563, 1561, 445, 443, 441,
			2219, 438, 2216, 435, 2212, 460, 454, 475, 1517, 1515,
			1512, 2447, 798, 797, 2422, 2419, 770, 768, 766, 2383,
			2380, 2376, 721, 719, 717, 714, 731, 1714, 2602, 2582,
			2580, 2548, 2546, 2543, 923, 921, 2717, 2706, 2705, 2683,
			2682, 2680, 1771, 1752, 1750, 1733, 1732, 1731, 1735, 1814,
			1707, 1670, 1668, 1631, 1629, 1626, 1634, 1599, 1598, 1596,
			1594, 1603, 1601, 2326, 1772, 1753, 1751, 1581, 1554, 1552,
			1504, 1501, 1498, 1509, 1442, 1437, 1434, 401, 1448, 1445,
			2206, 1392, 1391, 1389, 1387, 1384, 359, 1399, 1397, 1394,
			1404, 2171, 2170, 1708, 1672, 1669, 619, 1632, 1630, 1628,
			1773, 1378, 1363, 1361, 1333, 1328, 1336, 1286, 1281, 1278,
			248, 1292, 1289, 2111, 1218, 1216, 1210, 197, 1206, 193,
			1228, 1225, 1221, 1236, 2073, 2071, 1151, 1150, 1148, 1146,
			152, 1143, 149, 1140, 145, 1161, 1159, 1156, 1153, 158,
			1169, 1166, 2017, 2016, 2014, 2019, 1582, 510, 1556, 1553,
			452, 448, 1506, 1500, 394, 391, 387, 1443, 1441, 1439,
			1436, 1450, 2207, 765, 716, 713, 1709, 662, 660, 657,
			1673, 1671, 916, 914, 879, 878, 877, 882, 1135, 1134,
			1121, 1120, 1118, 1123, 1097, 1096, 1094, 1092, 103, 1101,
			1099, 1979, 1059, 1058, 1056, 1054, 77, 1051, 74, 1066,
			1064, 1061, 1071, 1964, 1963, 1007, 1006, 1004, 1002, 999,
			41, 996, 37, 1017, 1015, 1012, 1009, 52, 1025, 1022,
			1936, 1935, 1933, 1938, 942, 940, 938, 935, 932, 5,
			2, 955, 953, 950, 947, 18, 943, 15, 965, 962,
			958, 1895, 1894, 1892, 1890, 973, 1899, 1897, 1379, 325,
			1364, 1362, 288, 285, 1334, 1332, 1330, 241, 238, 234,
			1287, 1285, 1283, 1280, 1294, 2112, 188, 185, 181, 178,
			2028, 1219, 1217, 1215, 1212, 200, 1209, 1227, 2074, 2072,
			583, 553, 551, 1583, 505, 503, 500, 513, 1557, 1555,
			444, 442, 439, 436, 2213, 455, 451, 1507, 1505, 1502,
			796, 763, 762, 760, 767, 711, 710, 708, 706, 2377,
			718, 715, 1710, 2544, 917, 915, 2681, 1627, 1597, 1595,
			2325, 1769, 1749, 1747, 1499, 1438, 1435, 2204, 1390, 1388,
			1385, 1395, 2169, 2167, 1704, 1665, 1662, 1625, 1623, 1620,
			1770, 1329, 1282, 1279, 2109, 1214, 1207, 1222, 2068, 2065,
			1149, 1147, 1144, 1141, 146, 1157, 1154, 2013, 2011, 2008,
			2015, 1579, 1549, 1546, 1495, 1487, 1433, 1431, 1428, 1425,
			388, 1440, 2205, 1705, 658, 1667, 1664, 1119, 1095, 1093,
			1978, 1057, 1055, 1052, 1062, 1962, 1960, 1005, 1003, 1000,
			997, 38, 1013, 1010, 1932, 1930, 1927, 1934, 941, 939,
			936, 933, 6, 930, 3, 951, 948, 944, 1889, 1887,
			1884, 1881, 959, 1893, 1891, 35, 1377, 1360, 1358, 1327,
			1325, 1322, 1331, 1277, 1275, 1272, 1269, 235, 1284, 2110,
			1205, 1204, 1201, 1198, 182, 1195, 179, 1213, 2070, 2067,
			1580, 501, 1551, 1548, 440, 437, 1497, 1494, 1490, 1503,
			761, 709, 707, 1706, 913, 912, 2198, 1386, 2164, 2161,
			1621, 1766, 2103, 1208, 2058, 2054, 1145, 1142, 2005, 2002,
			1999, 2009, 1488, 1429, 1426, 2200, 1698, 1659, 1656, 1975,
			1053, 1957, 1954, 1001, 998, 1924, 1921, 1918, 1928, 937,
			934, 931, 1879, 1876, 1873, 1870, 945, 1885, 1882, 1323,
			1273, 1270, 2105, 1202, 1199, 1196, 1211, 2061, 2057, 1576,
			1543, 1540, 1484, 1481, 1478, 1491, 1700
		};

		[Obsolete]
		public static int getBitCountSum(int[] moduleBitCount)
		{
			return MathUtils.sum(moduleBitCount);
		}

		public static int[] toIntArray(ICollection<int> list)
		{
			if (list == null || list.Count == 0)
			{
				return EMPTY_INT_ARRAY;
			}
			int[] array = new int[list.Count];
			int num = 0;
			foreach (int item in list)
			{
				array[num++] = item;
			}
			return array;
		}

		public static int getCodeword(long symbol)
		{
			int num = Array.BinarySearch(SYMBOL_TABLE, (int)(symbol & 0x3FFFF));
			if (num < 0)
			{
				return -1;
			}
			return (CODEWORD_TABLE[num] - 1) % NUMBER_OF_CODEWORDS;
		}
	}
	public sealed class PDF417Reader : Reader, MultipleBarcodeReader
	{
		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			Result[] array = decode(image, hints, multiple: false);
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}

		public Result[] decodeMultiple(BinaryBitmap image)
		{
			return decodeMultiple(image, null);
		}

		public Result[] decodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			return decode(image, hints, multiple: true);
		}

		private static Result[] decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints, bool multiple)
		{
			List<Result> list = new List<Result>();
			PDF417DetectorResult pDF417DetectorResult = ZXing.PDF417.Internal.Detector.detect(image, hints, multiple);
			if (pDF417DetectorResult != null)
			{
				foreach (ResultPoint[] point in pDF417DetectorResult.Points)
				{
					DecoderResult decoderResult = PDF417ScanningDecoder.decode(pDF417DetectorResult.Bits, point[4], point[5], point[6], point[7], getMinCodewordWidth(point), getMaxCodewordWidth(point));
					if (decoderResult != null)
					{
						Result result = new Result(decoderResult.Text, decoderResult.RawBytes, point, BarcodeFormat.PDF_417);
						result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, decoderResult.ECLevel);
						PDF417ResultMetadata pDF417ResultMetadata = (PDF417ResultMetadata)decoderResult.Other;
						if (pDF417ResultMetadata != null)
						{
							result.putMetadata(ResultMetadataType.PDF417_EXTRA_METADATA, pDF417ResultMetadata);
						}
						list.Add(result);
					}
				}
			}
			return list.ToArray();
		}

		private static int getMaxWidth(ResultPoint p1, ResultPoint p2)
		{
			if (p1 == null || p2 == null)
			{
				return 0;
			}
			return (int)Math.Abs(p1.X - p2.X);
		}

		private static int getMinWidth(ResultPoint p1, ResultPoint p2)
		{
			if (p1 == null || p2 == null)
			{
				return 2147483647;
			}
			return (int)Math.Abs(p1.X - p2.X);
		}

		private static int getMaxCodewordWidth(ResultPoint[] p)
		{
			return Math.Max(Math.Max(getMaxWidth(p[0], p[4]), getMaxWidth(p[6], p[2]) * PDF417Common.MODULES_IN_CODEWORD / PDF417Common.MODULES_IN_STOP_PATTERN), Math.Max(getMaxWidth(p[1], p[5]), getMaxWidth(p[7], p[3]) * PDF417Common.MODULES_IN_CODEWORD / PDF417Common.MODULES_IN_STOP_PATTERN));
		}

		private static int getMinCodewordWidth(ResultPoint[] p)
		{
			return Math.Min(Math.Min(getMinWidth(p[0], p[4]), getMinWidth(p[6], p[2]) * PDF417Common.MODULES_IN_CODEWORD / PDF417Common.MODULES_IN_STOP_PATTERN), Math.Min(getMinWidth(p[1], p[5]), getMinWidth(p[7], p[3]) * PDF417Common.MODULES_IN_CODEWORD / PDF417Common.MODULES_IN_STOP_PATTERN));
		}

		public void reset()
		{
		}
	}
	public sealed class PDF417ResultMetadata
	{
		public int SegmentIndex { get; set; }

		public string FileId { get; set; }

		public int[] OptionalData { get; set; }

		public bool IsLastSegment { get; set; }
	}
	public sealed class PDF417Writer : Writer
	{
		private const int WHITE_SPACE = 30;

		private const int DEFAULT_ERROR_CORRECTION_LEVEL = 2;

		private const int DEFAULT_ASPECT_RATIO = 4;

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.PDF_417)
			{
				throw new ArgumentException("Can only encode PDF_417, but got " + format);
			}
			ZXing.PDF417.Internal.PDF417 pDF = new ZXing.PDF417.Internal.PDF417();
			int margin = 30;
			int errorCorrectionLevel = 2;
			int aspectRatio = 4;
			if (hints != null)
			{
				if (hints.ContainsKey(EncodeHintType.PDF417_COMPACT) && hints[EncodeHintType.PDF417_COMPACT] != null)
				{
					pDF.setCompact(Convert.ToBoolean(hints[EncodeHintType.PDF417_COMPACT].ToString()));
				}
				if (hints.ContainsKey(EncodeHintType.PDF417_COMPACTION) && hints[EncodeHintType.PDF417_COMPACTION] != null && Enum.IsDefined(typeof(Compaction), hints[EncodeHintType.PDF417_COMPACTION].ToString()))
				{
					Compaction compaction = (Compaction)Enum.Parse(typeof(Compaction), hints[EncodeHintType.PDF417_COMPACTION].ToString(), ignoreCase: true);
					pDF.setCompaction(compaction);
				}
				if (hints.ContainsKey(EncodeHintType.PDF417_DIMENSIONS))
				{
					Dimensions dimensions = (Dimensions)hints[EncodeHintType.PDF417_DIMENSIONS];
					pDF.setDimensions(dimensions.MaxCols, dimensions.MinCols, dimensions.MaxRows, dimensions.MinRows);
				}
				if (hints.ContainsKey(EncodeHintType.MARGIN) && hints[EncodeHintType.MARGIN] != null)
				{
					margin = Convert.ToInt32(hints[EncodeHintType.MARGIN].ToString());
				}
				if (hints.ContainsKey(EncodeHintType.PDF417_ASPECT_RATIO) && hints[EncodeHintType.PDF417_ASPECT_RATIO] != null)
				{
					object obj = hints[EncodeHintType.PDF417_ASPECT_RATIO];
					if (obj is PDF417AspectRatio || obj is int)
					{
						aspectRatio = (int)obj;
					}
					else if (Enum.IsDefined(typeof(PDF417AspectRatio), obj.ToString()))
					{
						aspectRatio = (int)(PDF417AspectRatio)Enum.Parse(typeof(PDF417AspectRatio), obj.ToString(), ignoreCase: true);
					}
				}
				if (hints.ContainsKey(EncodeHintType.ERROR_CORRECTION) && hints[EncodeHintType.ERROR_CORRECTION] != null)
				{
					object obj2 = hints[EncodeHintType.ERROR_CORRECTION];
					if (obj2 is PDF417ErrorCorrectionLevel || obj2 is int)
					{
						errorCorrectionLevel = (int)obj2;
					}
					else if (Enum.IsDefined(typeof(PDF417ErrorCorrectionLevel), obj2.ToString()))
					{
						errorCorrectionLevel = (int)(PDF417ErrorCorrectionLevel)Enum.Parse(typeof(PDF417ErrorCorrectionLevel), obj2.ToString(), ignoreCase: true);
					}
				}
				if (hints.ContainsKey(EncodeHintType.CHARACTER_SET))
				{
					string text = (string)hints[EncodeHintType.CHARACTER_SET];
					if (text != null)
					{
						pDF.setEncoding(text);
					}
				}
				if (hints.ContainsKey(EncodeHintType.DISABLE_ECI) && hints[EncodeHintType.DISABLE_ECI] != null)
				{
					pDF.setDisableEci(Convert.ToBoolean(hints[EncodeHintType.DISABLE_ECI].ToString()));
				}
			}
			return bitMatrixFromEncoder(pDF, contents, errorCorrectionLevel, width, height, margin, aspectRatio);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		private static BitMatrix bitMatrixFromEncoder(ZXing.PDF417.Internal.PDF417 encoder, string contents, int errorCorrectionLevel, int width, int height, int margin, int aspectRatio)
		{
			if (width >= height)
			{
				encoder.generateBarcodeLogic(contents, errorCorrectionLevel, width, height, ref aspectRatio);
			}
			else
			{
				encoder.generateBarcodeLogic(contents, errorCorrectionLevel, height, width, ref aspectRatio);
			}
			sbyte[][] array = encoder.BarcodeMatrix.getScaledMatrix(1, aspectRatio);
			bool flag = false;
			if (height > width != array[0].Length < array.Length)
			{
				array = rotateArray(array);
				flag = true;
			}
			int num = width / array[0].Length;
			int num2 = height / array.Length;
			int num3 = ((num >= num2) ? num2 : num);
			if (num3 > 1)
			{
				sbyte[][] array2 = encoder.BarcodeMatrix.getScaledMatrix(num3, num3 * aspectRatio);
				if (flag)
				{
					array2 = rotateArray(array2);
				}
				return bitMatrixFromBitArray(array2, margin);
			}
			return bitMatrixFromBitArray(array, margin);
		}

		private static BitMatrix bitMatrixFromBitArray(sbyte[][] input, int margin)
		{
			BitMatrix bitMatrix = new BitMatrix(input[0].Length + 2 * margin, input.Length + 2 * margin);
			int num = bitMatrix.Height - margin - 1;
			int num2 = 0;
			while (num2 < input.Length)
			{
				sbyte[] array = input[num2];
				int num3 = array.Length;
				for (int i = 0; i < num3; i++)
				{
					if (array[i] == 1)
					{
						bitMatrix[i + margin, num] = true;
					}
				}
				num2++;
				num--;
			}
			return bitMatrix;
		}

		private static sbyte[][] rotateArray(sbyte[][] bitarray)
		{
			sbyte[][] array = new sbyte[bitarray[0].Length][];
			for (int i = 0; i < bitarray[0].Length; i++)
			{
				array[i] = new sbyte[bitarray.Length];
			}
			for (int j = 0; j < bitarray.Length; j++)
			{
				int num = bitarray.Length - j - 1;
				for (int k = 0; k < bitarray[0].Length; k++)
				{
					array[k][num] = bitarray[j][k];
				}
			}
			return array;
		}
	}
}
namespace ZXing.PDF417.Internal
{
	public sealed class BarcodeMetadata
	{
		public int ColumnCount { get; private set; }

		public int ErrorCorrectionLevel { get; private set; }

		public int RowCountUpper { get; private set; }

		public int RowCountLower { get; private set; }

		public int RowCount { get; private set; }

		public BarcodeMetadata(int columnCount, int rowCountUpperPart, int rowCountLowerPart, int errorCorrectionLevel)
		{
			ColumnCount = columnCount;
			ErrorCorrectionLevel = errorCorrectionLevel;
			RowCountUpper = rowCountUpperPart;
			RowCountLower = rowCountLowerPart;
			RowCount = rowCountLowerPart + rowCountUpperPart;
		}
	}
	public sealed class BarcodeValue
	{
		private readonly IDictionary<int, int> values = new Dictionary<int, int>();

		public void setValue(int value)
		{
			values.TryGetValue(value, out var value2);
			value2++;
			values[value] = value2;
		}

		public int[] getValue()
		{
			int num = -1;
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, int> value in values)
			{
				if (value.Value > num)
				{
					num = value.Value;
					list.Clear();
					list.Add(value.Key);
				}
				else if (value.Value == num)
				{
					list.Add(value.Key);
				}
			}
			return list.ToArray();
		}

		internal int getConfidence(int barcodeValue)
		{
			if (!values.ContainsKey(barcodeValue))
			{
				return 0;
			}
			return values[barcodeValue];
		}
	}
	public sealed class BoundingBox
	{
		private readonly BitMatrix image;

		public ResultPoint TopLeft { get; private set; }

		public ResultPoint TopRight { get; private set; }

		public ResultPoint BottomLeft { get; private set; }

		public ResultPoint BottomRight { get; private set; }

		public int MinX { get; private set; }

		public int MaxX { get; private set; }

		public int MinY { get; private set; }

		public int MaxY { get; private set; }

		public static BoundingBox Create(BitMatrix image, ResultPoint topLeft, ResultPoint bottomLeft, ResultPoint topRight, ResultPoint bottomRight)
		{
			if ((topLeft == null && topRight == null) || (bottomLeft == null && bottomRight == null) || (topLeft != null && bottomLeft == null) || (topRight != null && bottomRight == null))
			{
				return null;
			}
			return new BoundingBox(image, topLeft, bottomLeft, topRight, bottomRight);
		}

		public static BoundingBox Create(BoundingBox box)
		{
			return new BoundingBox(box.image, box.TopLeft, box.BottomLeft, box.TopRight, box.BottomRight);
		}

		private BoundingBox(BitMatrix image, ResultPoint topLeft, ResultPoint bottomLeft, ResultPoint topRight, ResultPoint bottomRight)
		{
			this.image = image;
			TopLeft = topLeft;
			TopRight = topRight;
			BottomLeft = bottomLeft;
			BottomRight = bottomRight;
			calculateMinMaxValues();
		}

		internal static BoundingBox merge(BoundingBox leftBox, BoundingBox rightBox)
		{
			if (leftBox == null)
			{
				return rightBox;
			}
			if (rightBox == null)
			{
				return leftBox;
			}
			return new BoundingBox(leftBox.image, leftBox.TopLeft, leftBox.BottomLeft, rightBox.TopRight, rightBox.BottomRight);
		}

		public BoundingBox addMissingRows(int missingStartRows, int missingEndRows, bool isLeft)
		{
			ResultPoint topLeft = TopLeft;
			ResultPoint bottomLeft = BottomLeft;
			ResultPoint topRight = TopRight;
			ResultPoint bottomRight = BottomRight;
			if (missingStartRows > 0)
			{
				ResultPoint obj = (isLeft ? TopLeft : TopRight);
				int num = (int)obj.Y - missingStartRows;
				if (num < 0)
				{
					num = 0;
				}
				ResultPoint resultPoint = new ResultPoint(obj.X, num);
				if (isLeft)
				{
					topLeft = resultPoint;
				}
				else
				{
					topRight = resultPoint;
				}
			}
			if (missingEndRows > 0)
			{
				ResultPoint obj2 = (isLeft ? BottomLeft : BottomRight);
				int num2 = (int)obj2.Y + missingEndRows;
				if (num2 >= image.Height)
				{
					num2 = image.Height - 1;
				}
				ResultPoint resultPoint2 = new ResultPoint(obj2.X, num2);
				if (isLeft)
				{
					bottomLeft = resultPoint2;
				}
				else
				{
					bottomRight = resultPoint2;
				}
			}
			calculateMinMaxValues();
			return new BoundingBox(image, topLeft, bottomLeft, topRight, bottomRight);
		}

		private void calculateMinMaxValues()
		{
			if (TopLeft == null)
			{
				TopLeft = new ResultPoint(0f, TopRight.Y);
				BottomLeft = new ResultPoint(0f, BottomRight.Y);
			}
			else if (TopRight == null)
			{
				TopRight = new ResultPoint(image.Width - 1, TopLeft.Y);
				BottomRight = new ResultPoint(image.Width - 1, TopLeft.Y);
			}
			MinX = (int)Math.Min(TopLeft.X, BottomLeft.X);
			MaxX = (int)Math.Max(TopRight.X, BottomRight.X);
			MinY = (int)Math.Min(TopLeft.Y, TopRight.Y);
			MaxY = (int)Math.Max(BottomLeft.Y, BottomRight.Y);
		}

		internal void SetBottomRight(ResultPoint bottomRight)
		{
			BottomRight = bottomRight;
			calculateMinMaxValues();
		}
	}
	public sealed class Codeword
	{
		private static readonly int BARCODE_ROW_UNKNOWN = -1;

		public int StartX { get; private set; }

		public int EndX { get; private set; }

		public int Bucket { get; private set; }

		public int Value { get; private set; }

		public int RowNumber { get; set; }

		public int Width => EndX - StartX;

		public bool HasValidRowNumber => IsValidRowNumber(RowNumber);

		public Codeword(int startX, int endX, int bucket, int value)
		{
			StartX = startX;
			EndX = endX;
			Bucket = bucket;
			Value = value;
			RowNumber = BARCODE_ROW_UNKNOWN;
		}

		public bool IsValidRowNumber(int rowNumber)
		{
			if (rowNumber != BARCODE_ROW_UNKNOWN)
			{
				return Bucket == rowNumber % 3 * 3;
			}
			return false;
		}

		public void setRowNumberAsRowIndicatorColumn()
		{
			RowNumber = Value / 30 * 3 + Bucket / 3;
		}

		public override string ToString()
		{
			return RowNumber + "|" + Value;
		}
	}
	internal static class DecodedBitStreamParser
	{
		private enum Mode
		{
			ALPHA,
			LOWER,
			MIXED,
			PUNCT,
			ALPHA_SHIFT,
			PUNCT_SHIFT
		}

		private const int TEXT_COMPACTION_MODE_LATCH = 900;

		private const int BYTE_COMPACTION_MODE_LATCH = 901;

		private const int NUMERIC_COMPACTION_MODE_LATCH = 902;

		private const int BYTE_COMPACTION_MODE_LATCH_6 = 924;

		private const int ECI_USER_DEFINED = 925;

		private const int ECI_GENERAL_PURPOSE = 926;

		private const int ECI_CHARSET = 927;

		private const int BEGIN_MACRO_PDF417_CONTROL_BLOCK = 928;

		private const int BEGIN_MACRO_PDF417_OPTIONAL_FIELD = 923;

		private const int MACRO_PDF417_TERMINATOR = 922;

		private const int MODE_SHIFT_TO_BYTE_COMPACTION_MODE = 913;

		private const int MAX_NUMERIC_CODEWORDS = 15;

		private const int PL = 25;

		private const int LL = 27;

		private const int AS = 27;

		private const int ML = 28;

		private const int AL = 28;

		private const int PS = 29;

		private const int PAL = 29;

		private static readonly char[] PUNCT_CHARS;

		private static readonly char[] MIXED_CHARS;

		private static readonly BigInteger[] EXP900;

		private const int NUMBER_OF_SEQUENCE_CODEWORDS = 2;

		static DecodedBitStreamParser()
		{
			PUNCT_CHARS = ";<>@[\\]_`~!\r\t,:\n-.$/\"|*()?{}'".ToCharArray();
			MIXED_CHARS = "0123456789&\r\t,:#-.$/+%*=^".ToCharArray();
			EXP900 = new BigInteger[16];
			EXP900[0] = BigInteger.One;
			BigInteger bigInteger = new BigInteger(900L);
			EXP900[1] = bigInteger;
			for (int i = 2; i < EXP900.Length; i++)
			{
				EXP900[i] = BigInteger.Multiplication(EXP900[i - 1], bigInteger);
			}
		}

		internal static DecoderResult decode(int[] codewords, string ecLevel)
		{
			StringBuilder stringBuilder = new StringBuilder(codewords.Length * 2);
			int num = 1;
			int num2 = codewords[num++];
			PDF417ResultMetadata pDF417ResultMetadata = new PDF417ResultMetadata();
			Encoding encoding = null;
			while (num < codewords[0])
			{
				switch (num2)
				{
				case 900:
					num = textCompaction(codewords, num, stringBuilder);
					break;
				case 901:
				case 924:
					num = byteCompaction(num2, codewords, encoding ?? (encoding = getEncoding(PDF417HighLevelEncoder.DEFAULT_ENCODING_NAME)), num, stringBuilder);
					break;
				case 913:
					stringBuilder.Append((char)codewords[num++]);
					break;
				case 902:
					num = numericCompaction(codewords, num, stringBuilder);
					break;
				case 927:
					encoding = getEncoding(CharacterSetECI.getCharacterSetECIByValue(codewords[num++]).EncodingName);
					break;
				case 926:
					num += 2;
					break;
				case 925:
					num++;
					break;
				case 928:
					num = decodeMacroBlock(codewords, num, pDF417ResultMetadata);
					break;
				case 922:
				case 923:
					return null;
				default:
					num--;
					num = textCompaction(codewords, num, stringBuilder);
					break;
				}
				if (num < 0)
				{
					return null;
				}
				if (num < codewords.Length)
				{
					num2 = codewords[num++];
					continue;
				}
				return null;
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return new DecoderResult(null, stringBuilder.ToString(), null, ecLevel)
			{
				Other = pDF417ResultMetadata
			};
		}

		private static Encoding getEncoding(string encodingName)
		{
			Encoding encoding = null;
			try
			{
				return Encoding.GetEncoding(encodingName);
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static int decodeMacroBlock(int[] codewords, int codeIndex, PDF417ResultMetadata resultMetadata)
		{
			if (codeIndex + 2 > codewords[0])
			{
				return -1;
			}
			int[] array = new int[2];
			int num = 0;
			while (num < 2)
			{
				array[num] = codewords[codeIndex];
				num++;
				codeIndex++;
			}
			string text = decodeBase900toBase10(array, 2);
			if (text == null)
			{
				return -1;
			}
			resultMetadata.SegmentIndex = int.Parse(text);
			StringBuilder stringBuilder = new StringBuilder();
			codeIndex = textCompaction(codewords, codeIndex, stringBuilder);
			resultMetadata.FileId = stringBuilder.ToString();
			switch (codewords[codeIndex])
			{
			case 923:
			{
				codeIndex++;
				int[] array2 = new int[codewords[0] - codeIndex];
				int num2 = 0;
				bool flag = false;
				while (codeIndex < codewords[0] && !flag)
				{
					int num3 = codewords[codeIndex++];
					if (num3 < 900)
					{
						array2[num2++] = num3;
						continue;
					}
					if (num3 == 922)
					{
						resultMetadata.IsLastSegment = true;
						codeIndex++;
						flag = true;
						continue;
					}
					return -1;
				}
				resultMetadata.OptionalData = new int[num2];
				Array.Copy(array2, resultMetadata.OptionalData, num2);
				break;
			}
			case 922:
				resultMetadata.IsLastSegment = true;
				codeIndex++;
				break;
			}
			return codeIndex;
		}

		private static int textCompaction(int[] codewords, int codeIndex, StringBuilder result)
		{
			int[] array = new int[codewords[0] - codeIndex << 1];
			int[] array2 = new int[codewords[0] - codeIndex << 1];
			int num = 0;
			bool flag = false;
			while (codeIndex < codewords[0] && !flag)
			{
				int num2 = codewords[codeIndex++];
				if (num2 < 900)
				{
					array[num] = num2 / 30;
					array[num + 1] = num2 % 30;
					num += 2;
					continue;
				}
				switch (num2)
				{
				case 900:
					array[num++] = 900;
					break;
				case 901:
				case 902:
				case 922:
				case 923:
				case 924:
				case 928:
					codeIndex--;
					flag = true;
					break;
				case 913:
					array[num] = 913;
					num2 = codewords[codeIndex++];
					array2[num] = num2;
					num++;
					break;
				}
			}
			decodeTextCompaction(array, array2, num, result);
			return codeIndex;
		}

		private static void decodeTextCompaction(int[] textCompactionData, int[] byteCompactionData, int length, StringBuilder result)
		{
			Mode mode = Mode.ALPHA;
			Mode mode2 = Mode.ALPHA;
			for (int i = 0; i < length; i++)
			{
				int num = textCompactionData[i];
				char? c = null;
				switch (mode)
				{
				case Mode.ALPHA:
					if (num < 26)
					{
						c = (char)(65 + num);
						break;
					}
					switch (num)
					{
					case 26:
						c = ' ';
						break;
					case 27:
						mode = Mode.LOWER;
						break;
					case 28:
						mode = Mode.MIXED;
						break;
					case 29:
						mode2 = mode;
						mode = Mode.PUNCT_SHIFT;
						break;
					case 913:
						result.Append((char)byteCompactionData[i]);
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				case Mode.LOWER:
					if (num < 26)
					{
						c = (char)(97 + num);
						break;
					}
					switch (num)
					{
					case 26:
						c = ' ';
						break;
					case 27:
						mode2 = mode;
						mode = Mode.ALPHA_SHIFT;
						break;
					case 28:
						mode = Mode.MIXED;
						break;
					case 29:
						mode2 = mode;
						mode = Mode.PUNCT_SHIFT;
						break;
					case 913:
						result.Append((char)byteCompactionData[i]);
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				case Mode.MIXED:
					if (num < 25)
					{
						c = MIXED_CHARS[num];
						break;
					}
					switch (num)
					{
					case 25:
						mode = Mode.PUNCT;
						break;
					case 26:
						c = ' ';
						break;
					case 27:
						mode = Mode.LOWER;
						break;
					case 28:
						mode = Mode.ALPHA;
						break;
					case 29:
						mode2 = mode;
						mode = Mode.PUNCT_SHIFT;
						break;
					case 913:
						result.Append((char)byteCompactionData[i]);
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				case Mode.PUNCT:
					if (num < 29)
					{
						c = PUNCT_CHARS[num];
						break;
					}
					switch (num)
					{
					case 29:
						mode = Mode.ALPHA;
						break;
					case 913:
						result.Append((char)byteCompactionData[i]);
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				case Mode.ALPHA_SHIFT:
					mode = mode2;
					if (num < 26)
					{
						c = (char)(65 + num);
						break;
					}
					switch (num)
					{
					case 26:
						c = ' ';
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				case Mode.PUNCT_SHIFT:
					mode = mode2;
					if (num < 29)
					{
						c = PUNCT_CHARS[num];
						break;
					}
					switch (num)
					{
					case 29:
						mode = Mode.ALPHA;
						break;
					case 913:
						result.Append((char)byteCompactionData[i]);
						break;
					case 900:
						mode = Mode.ALPHA;
						break;
					}
					break;
				}
				if (c.HasValue)
				{
					result.Append(c.Value);
				}
			}
		}

		private static int byteCompaction(int mode, int[] codewords, Encoding encoding, int codeIndex, StringBuilder result)
		{
			int num = 0;
			long num2 = 0L;
			bool flag = false;
			using MemoryStream memoryStream = new MemoryStream();
			if (mode != 901)
			{
				if (mode == 924)
				{
					while (codeIndex < codewords[0] && !flag)
					{
						int num3 = codewords[codeIndex++];
						if (num3 < 900)
						{
							num++;
							num2 = 900 * num2 + num3;
						}
						else if ((uint)(num3 - 900) <= 2u || (uint)(num3 - 922) <= 2u || num3 == 928)
						{
							codeIndex--;
							flag = true;
						}
						if (num % 5 == 0 && num > 0)
						{
							for (int i = 0; i < 6; i++)
							{
								memoryStream.WriteByte((byte)(num2 >> 8 * (5 - i)));
							}
							num2 = 0L;
							num = 0;
						}
					}
				}
			}
			else
			{
				int[] array = new int[6];
				int num4 = codewords[codeIndex++];
				while (codeIndex < codewords[0] && !flag)
				{
					array[num++] = num4;
					num2 = 900 * num2 + num4;
					num4 = codewords[codeIndex++];
					if ((uint)(num4 - 900) <= 2u || (uint)(num4 - 922) <= 2u || num4 == 928)
					{
						codeIndex--;
						flag = true;
					}
					else if (num % 5 == 0 && num > 0)
					{
						for (int j = 0; j < 6; j++)
						{
							memoryStream.WriteByte((byte)(num2 >> 8 * (5 - j)));
						}
						num2 = 0L;
						num = 0;
					}
				}
				if (codeIndex == codewords[0] && num4 < 900)
				{
					array[num++] = num4;
				}
				for (int k = 0; k < num; k++)
				{
					memoryStream.WriteByte((byte)array[k]);
				}
			}
			byte[] array2 = memoryStream.ToArray();
			result.Append(encoding.GetString(array2, 0, array2.Length));
			return codeIndex;
		}

		private static int numericCompaction(int[] codewords, int codeIndex, StringBuilder result)
		{
			int num = 0;
			bool flag = false;
			int[] array = new int[15];
			while (codeIndex < codewords[0] && !flag)
			{
				int num2 = codewords[codeIndex++];
				if (codeIndex == codewords[0])
				{
					flag = true;
				}
				if (num2 < 900)
				{
					array[num] = num2;
					num++;
				}
				else if ((uint)(num2 - 900) <= 1u || (uint)(num2 - 922) <= 2u || num2 == 928)
				{
					codeIndex--;
					flag = true;
				}
				if ((num % 15 == 0 || num2 == 902 || flag) && num > 0)
				{
					string text = decodeBase900toBase10(array, num);
					if (text == null)
					{
						return -1;
					}
					result.Append(text);
					num = 0;
				}
			}
			return codeIndex;
		}

		private static string decodeBase900toBase10(int[] codewords, int count)
		{
			BigInteger bigInteger = BigInteger.Zero;
			for (int i = 0; i < count; i++)
			{
				bigInteger = BigInteger.Addition(bigInteger, BigInteger.Multiplication(EXP900[count - i - 1], new BigInteger(codewords[i])));
			}
			string text = bigInteger.ToString();
			if (text[0] != '1')
			{
				return null;
			}
			return text.Substring(1);
		}
	}
	public class DetectionResult
	{
		private const int ADJUST_ROW_NUMBER_SKIP = 2;

		public BarcodeMetadata Metadata { get; private set; }

		public DetectionResultColumn[] DetectionResultColumns { get; set; }

		public BoundingBox Box { get; internal set; }

		public int ColumnCount { get; private set; }

		public int RowCount => Metadata.RowCount;

		public int ErrorCorrectionLevel => Metadata.ErrorCorrectionLevel;

		public DetectionResult(BarcodeMetadata metadata, BoundingBox box)
		{
			Metadata = metadata;
			Box = box;
			ColumnCount = metadata.ColumnCount;
			DetectionResultColumns = new DetectionResultColumn[ColumnCount + 2];
		}

		public DetectionResultColumn[] getDetectionResultColumns()
		{
			adjustIndicatorColumnRowNumbers(DetectionResultColumns[0]);
			adjustIndicatorColumnRowNumbers(DetectionResultColumns[ColumnCount + 1]);
			int num = PDF417Common.MAX_CODEWORDS_IN_BARCODE;
			int num2;
			do
			{
				num2 = num;
				num = adjustRowNumbers();
			}
			while (num > 0 && num < num2);
			return DetectionResultColumns;
		}

		private void adjustIndicatorColumnRowNumbers(DetectionResultColumn detectionResultColumn)
		{
			if (detectionResultColumn != null)
			{
				((DetectionResultRowIndicatorColumn)detectionResultColumn).adjustCompleteIndicatorColumnRowNumbers(Metadata);
			}
		}

		private int adjustRowNumbers()
		{
			int num = adjustRowNumbersByRow();
			if (num == 0)
			{
				return 0;
			}
			for (int i = 1; i < ColumnCount + 1; i++)
			{
				Codeword[] codewords = DetectionResultColumns[i].Codewords;
				for (int j = 0; j < codewords.Length; j++)
				{
					if (codewords[j] != null && !codewords[j].HasValidRowNumber)
					{
						adjustRowNumbers(i, j, codewords);
					}
				}
			}
			return num;
		}

		private int adjustRowNumbersByRow()
		{
			adjustRowNumbersFromBothRI();
			return adjustRowNumbersFromLRI() + adjustRowNumbersFromRRI();
		}

		private void adjustRowNumbersFromBothRI()
		{
			if (DetectionResultColumns[0] == null || DetectionResultColumns[ColumnCount + 1] == null)
			{
				return;
			}
			Codeword[] codewords = DetectionResultColumns[0].Codewords;
			Codeword[] codewords2 = DetectionResultColumns[ColumnCount + 1].Codewords;
			for (int i = 0; i < codewords.Length; i++)
			{
				if (codewords[i] == null || codewords2[i] == null || codewords[i].RowNumber != codewords2[i].RowNumber)
				{
					continue;
				}
				for (int j = 1; j <= ColumnCount; j++)
				{
					Codeword codeword = DetectionResultColumns[j].Codewords[i];
					if (codeword != null)
					{
						codeword.RowNumber = codewords[i].RowNumber;
						if (!codeword.HasValidRowNumber)
						{
							DetectionResultColumns[j].Codewords[i] = null;
						}
					}
				}
			}
		}

		private int adjustRowNumbersFromRRI()
		{
			if (DetectionResultColumns[ColumnCount + 1] == null)
			{
				return 0;
			}
			int num = 0;
			Codeword[] codewords = DetectionResultColumns[ColumnCount + 1].Codewords;
			for (int i = 0; i < codewords.Length; i++)
			{
				if (codewords[i] == null)
				{
					continue;
				}
				int rowNumber = codewords[i].RowNumber;
				int num2 = 0;
				int num3 = ColumnCount + 1;
				while (num3 > 0 && num2 < 2)
				{
					Codeword codeword = DetectionResultColumns[num3].Codewords[i];
					if (codeword != null)
					{
						num2 = adjustRowNumberIfValid(rowNumber, num2, codeword);
						if (!codeword.HasValidRowNumber)
						{
							num++;
						}
					}
					num3--;
				}
			}
			return num;
		}

		private int adjustRowNumbersFromLRI()
		{
			if (DetectionResultColumns[0] == null)
			{
				return 0;
			}
			int num = 0;
			Codeword[] codewords = DetectionResultColumns[0].Codewords;
			for (int i = 0; i < codewords.Length; i++)
			{
				if (codewords[i] == null)
				{
					continue;
				}
				int rowNumber = codewords[i].RowNumber;
				int num2 = 0;
				for (int j = 1; j < ColumnCount + 1; j++)
				{
					if (num2 >= 2)
					{
						break;
					}
					Codeword codeword = DetectionResultColumns[j].Codewords[i];
					if (codeword != null)
					{
						num2 = adjustRowNumberIfValid(rowNumber, num2, codeword);
						if (!codeword.HasValidRowNumber)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		private static int adjustRowNumberIfValid(int rowIndicatorRowNumber, int invalidRowCounts, Codeword codeword)
		{
			if (codeword == null)
			{
				return invalidRowCounts;
			}
			if (!codeword.HasValidRowNumber)
			{
				if (codeword.IsValidRowNumber(rowIndicatorRowNumber))
				{
					codeword.RowNumber = rowIndicatorRowNumber;
					invalidRowCounts = 0;
				}
				else
				{
					invalidRowCounts++;
				}
			}
			return invalidRowCounts;
		}

		private void adjustRowNumbers(int barcodeColumn, int codewordsRow, Codeword[] codewords)
		{
			Codeword codeword = codewords[codewordsRow];
			Codeword[] codewords2 = DetectionResultColumns[barcodeColumn - 1].Codewords;
			Codeword[] array = codewords2;
			if (DetectionResultColumns[barcodeColumn + 1] != null)
			{
				array = DetectionResultColumns[barcodeColumn + 1].Codewords;
			}
			Codeword[] array2 = new Codeword[14]
			{
				null,
				null,
				codewords2[codewordsRow],
				array[codewordsRow],
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			if (codewordsRow > 0)
			{
				array2[0] = codewords[codewordsRow - 1];
				array2[4] = codewords2[codewordsRow - 1];
				array2[5] = array[codewordsRow - 1];
			}
			if (codewordsRow > 1)
			{
				array2[8] = codewords[codewordsRow - 2];
				array2[10] = codewords2[codewordsRow - 2];
				array2[11] = array[codewordsRow - 2];
			}
			if (codewordsRow < codewords.Length - 1)
			{
				array2[1] = codewords[codewordsRow + 1];
				array2[6] = codewords2[codewordsRow + 1];
				array2[7] = array[codewordsRow + 1];
			}
			if (codewordsRow < codewords.Length - 2)
			{
				array2[9] = codewords[codewordsRow + 2];
				array2[12] = codewords2[codewordsRow + 2];
				array2[13] = array[codewordsRow + 2];
			}
			Codeword[] array3 = array2;
			foreach (Codeword otherCodeword in array3)
			{
				if (adjustRowNumber(codeword, otherCodeword))
				{
					break;
				}
			}
		}

		private static bool adjustRowNumber(Codeword codeword, Codeword otherCodeword)
		{
			if (otherCodeword == null)
			{
				return false;
			}
			if (otherCodeword.HasValidRowNumber && otherCodeword.Bucket == codeword.Bucket)
			{
				codeword.RowNumber = otherCodeword.RowNumber;
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			DetectionResultColumn detectionResultColumn = DetectionResultColumns[0];
			if (detectionResultColumn == null)
			{
				detectionResultColumn = DetectionResultColumns[ColumnCount + 1];
			}
			for (int i = 0; i < detectionResultColumn.Codewords.Length; i++)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "CW {0,3}:", new object[1] { i });
				for (int j = 0; j < ColumnCount + 2; j++)
				{
					if (DetectionResultColumns[j] == null)
					{
						stringBuilder.Append("    |   ");
						continue;
					}
					Codeword codeword = DetectionResultColumns[j].Codewords[i];
					if (codeword == null)
					{
						stringBuilder.Append("    |   ");
						continue;
					}
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0,3}|{1,3}", new object[2] { codeword.RowNumber, codeword.Value });
				}
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}
	}
	public class DetectionResultColumn
	{
		private const int MAX_NEARBY_DISTANCE = 5;

		public BoundingBox Box { get; private set; }

		public Codeword[] Codewords { get; set; }

		public DetectionResultColumn(BoundingBox box)
		{
			Box = BoundingBox.Create(box);
			Codewords = new Codeword[Box.MaxY - Box.MinY + 1];
		}

		public int IndexForRow(int imageRow)
		{
			return imageRow - Box.MinY;
		}

		public int RowForIndex(int codewordIndex)
		{
			return Box.MinY + codewordIndex;
		}

		public Codeword getCodeword(int imageRow)
		{
			return Codewords[imageRowToCodewordIndex(imageRow)];
		}

		public Codeword getCodewordNearby(int imageRow)
		{
			Codeword codeword = getCodeword(imageRow);
			if (codeword != null)
			{
				return codeword;
			}
			for (int i = 1; i < 5; i++)
			{
				int num = imageRowToCodewordIndex(imageRow) - i;
				if (num >= 0)
				{
					codeword = Codewords[num];
					if (codeword != null)
					{
						return codeword;
					}
				}
				num = imageRowToCodewordIndex(imageRow) + i;
				if (num < Codewords.Length)
				{
					codeword = Codewords[num];
					if (codeword != null)
					{
						return codeword;
					}
				}
			}
			return null;
		}

		internal int imageRowToCodewordIndex(int imageRow)
		{
			return imageRow - Box.MinY;
		}

		public void setCodeword(int imageRow, Codeword codeword)
		{
			Codewords[IndexForRow(imageRow)] = codeword;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			Codeword[] codewords = Codewords;
			foreach (Codeword codeword in codewords)
			{
				if (codeword == null)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0,3}:    |   \n", new object[1] { num++ });
					continue;
				}
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0,3}: {1,3}|{2,3}\n", num++, codeword.RowNumber, codeword.Value);
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class DetectionResultRowIndicatorColumn : DetectionResultColumn
	{
		public bool IsLeft { get; set; }

		public DetectionResultRowIndicatorColumn(BoundingBox box, bool isLeft)
			: base(box)
		{
			IsLeft = isLeft;
		}

		private void setRowNumbers()
		{
			Codeword[] codewords = base.Codewords;
			for (int i = 0; i < codewords.Length; i++)
			{
				codewords[i]?.setRowNumberAsRowIndicatorColumn();
			}
		}

		public void adjustCompleteIndicatorColumnRowNumbers(BarcodeMetadata metadata)
		{
			Codeword[] codewords = base.Codewords;
			setRowNumbers();
			removeIncorrectCodewords(codewords, metadata);
			ResultPoint resultPoint = (IsLeft ? base.Box.TopLeft : base.Box.TopRight);
			ResultPoint resultPoint2 = (IsLeft ? base.Box.BottomLeft : base.Box.BottomRight);
			int num = imageRowToCodewordIndex((int)resultPoint.Y);
			int num2 = imageRowToCodewordIndex((int)resultPoint2.Y);
			int num3 = -1;
			int num4 = 1;
			int num5 = 0;
			for (int i = num; i < num2; i++)
			{
				Codeword codeword = codewords[i];
				if (codeword == null)
				{
					continue;
				}
				int num6 = codeword.RowNumber - num3;
				if (num6 == 0)
				{
					num5++;
					continue;
				}
				if (num6 == 1)
				{
					num4 = Math.Max(num4, num5);
					num5 = 1;
					num3 = codeword.RowNumber;
					continue;
				}
				if (num6 < 0 || codeword.RowNumber >= metadata.RowCount || num6 > i)
				{
					codewords[i] = null;
					continue;
				}
				int num7 = ((num4 <= 2) ? num6 : ((num4 - 2) * num6));
				bool flag = num7 > i;
				for (int j = 1; j <= num7; j++)
				{
					if (flag)
					{
						break;
					}
					flag = codewords[i - j] != null;
				}
				if (flag)
				{
					codewords[i] = null;
					continue;
				}
				num3 = codeword.RowNumber;
				num5 = 1;
			}
		}

		public int[] getRowHeights()
		{
			BarcodeMetadata barcodeMetadata = getBarcodeMetadata();
			if (barcodeMetadata == null)
			{
				return null;
			}
			adjustIncompleteIndicatorColumnRowNumbers(barcodeMetadata);
			int[] array = new int[barcodeMetadata.RowCount];
			Codeword[] codewords = base.Codewords;
			foreach (Codeword codeword in codewords)
			{
				if (codeword != null)
				{
					int rowNumber = codeword.RowNumber;
					if (rowNumber < array.Length)
					{
						array[rowNumber]++;
					}
				}
			}
			return array;
		}

		private void adjustIncompleteIndicatorColumnRowNumbers(BarcodeMetadata metadata)
		{
			ResultPoint resultPoint = (IsLeft ? base.Box.TopLeft : base.Box.TopRight);
			ResultPoint resultPoint2 = (IsLeft ? base.Box.BottomLeft : base.Box.BottomRight);
			int num = imageRowToCodewordIndex((int)resultPoint.Y);
			int num2 = imageRowToCodewordIndex((int)resultPoint2.Y);
			Codeword[] codewords = base.Codewords;
			int num3 = -1;
			int val = 1;
			int num4 = 0;
			for (int i = num; i < num2; i++)
			{
				Codeword codeword = codewords[i];
				if (codeword == null)
				{
					continue;
				}
				codeword.setRowNumberAsRowIndicatorColumn();
				switch (codeword.RowNumber - num3)
				{
				case 0:
					num4++;
					continue;
				case 1:
					val = Math.Max(val, num4);
					num4 = 1;
					num3 = codeword.RowNumber;
					continue;
				}
				if (codeword.RowNumber > metadata.RowCount)
				{
					base.Codewords[i] = null;
					continue;
				}
				num3 = codeword.RowNumber;
				num4 = 1;
			}
		}

		public BarcodeMetadata getBarcodeMetadata()
		{
			Codeword[] codewords = base.Codewords;
			BarcodeValue barcodeValue = new BarcodeValue();
			BarcodeValue barcodeValue2 = new BarcodeValue();
			BarcodeValue barcodeValue3 = new BarcodeValue();
			BarcodeValue barcodeValue4 = new BarcodeValue();
			Codeword[] array = codewords;
			foreach (Codeword codeword in array)
			{
				if (codeword != null)
				{
					codeword.setRowNumberAsRowIndicatorColumn();
					int num = codeword.Value % 30;
					int num2 = codeword.RowNumber;
					if (!IsLeft)
					{
						num2 += 2;
					}
					switch (num2 % 3)
					{
					case 0:
						barcodeValue2.setValue(num * 3 + 1);
						break;
					case 1:
						barcodeValue4.setValue(num / 3);
						barcodeValue3.setValue(num % 3);
						break;
					case 2:
						barcodeValue.setValue(num + 1);
						break;
					}
				}
			}
			int[] value = barcodeValue.getValue();
			int[] value2 = barcodeValue2.getValue();
			int[] value3 = barcodeValue3.getValue();
			int[] value4 = barcodeValue4.getValue();
			if (value.Length == 0 || value2.Length == 0 || value3.Length == 0 || value4.Length == 0 || value[0] < 1 || value2[0] + value3[0] < PDF417Common.MIN_ROWS_IN_BARCODE || value2[0] + value3[0] > PDF417Common.MAX_ROWS_IN_BARCODE)
			{
				return null;
			}
			BarcodeMetadata barcodeMetadata = new BarcodeMetadata(value[0], value2[0], value3[0], value4[0]);
			removeIncorrectCodewords(codewords, barcodeMetadata);
			return barcodeMetadata;
		}

		private void removeIncorrectCodewords(Codeword[] codewords, BarcodeMetadata metadata)
		{
			for (int i = 0; i < codewords.Length; i++)
			{
				Codeword codeword = codewords[i];
				if (codeword == null)
				{
					continue;
				}
				int num = codeword.Value % 30;
				int num2 = codeword.RowNumber;
				if (num2 >= metadata.RowCount)
				{
					codewords[i] = null;
					continue;
				}
				if (!IsLeft)
				{
					num2 += 2;
				}
				switch (num2 % 3)
				{
				default:
					if (num * 3 + 1 != metadata.RowCountUpper)
					{
						codewords[i] = null;
					}
					break;
				case 1:
					if (num % 3 != metadata.RowCountLower || num / 3 != metadata.ErrorCorrectionLevel)
					{
						codewords[i] = null;
					}
					break;
				case 2:
					if (num + 1 != metadata.ColumnCount)
					{
						codewords[i] = null;
					}
					break;
				}
			}
		}

		public override string ToString()
		{
			return "Is Left: " + IsLeft + " \n" + base.ToString();
		}
	}
	public static class PDF417CodewordDecoder
	{
		private static readonly float[][] RATIOS_TABLE;

		static PDF417CodewordDecoder()
		{
			RATIOS_TABLE = new float[PDF417Common.SYMBOL_TABLE.Length][];
			for (int i = 0; i < RATIOS_TABLE.Length; i++)
			{
				RATIOS_TABLE[i] = new float[PDF417Common.BARS_IN_MODULE];
			}
			for (int j = 0; j < PDF417Common.SYMBOL_TABLE.Length; j++)
			{
				int num = PDF417Common.SYMBOL_TABLE[j];
				int num2 = num & 1;
				for (int k = 0; k < PDF417Common.BARS_IN_MODULE; k++)
				{
					float num3 = 0f;
					while ((num & 1) == num2)
					{
						num3 += 1f;
						num >>= 1;
					}
					num2 = num & 1;
					RATIOS_TABLE[j][PDF417Common.BARS_IN_MODULE - k - 1] = num3 / (float)PDF417Common.MODULES_IN_CODEWORD;
				}
			}
		}

		public static int getDecodedValue(int[] moduleBitCount)
		{
			int decodedCodewordValue = getDecodedCodewordValue(sampleBitCounts(moduleBitCount));
			if (decodedCodewordValue != PDF417Common.INVALID_CODEWORD)
			{
				return decodedCodewordValue;
			}
			return getClosestDecodedValue(moduleBitCount);
		}

		private static int[] sampleBitCounts(int[] moduleBitCount)
		{
			float num = MathUtils.sum(moduleBitCount);
			int[] array = new int[PDF417Common.BARS_IN_MODULE];
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < PDF417Common.MODULES_IN_CODEWORD; i++)
			{
				float num4 = num / (float)(2 * PDF417Common.MODULES_IN_CODEWORD) + (float)i * num / (float)PDF417Common.MODULES_IN_CODEWORD;
				if ((float)(num3 + moduleBitCount[num2]) <= num4)
				{
					num3 += moduleBitCount[num2];
					num2++;
				}
				array[num2]++;
			}
			return array;
		}

		private static int getDecodedCodewordValue(int[] moduleBitCount)
		{
			int bitValue = getBitValue(moduleBitCount);
			if (PDF417Common.getCodeword(bitValue) != PDF417Common.INVALID_CODEWORD)
			{
				return bitValue;
			}
			return PDF417Common.INVALID_CODEWORD;
		}

		private static int getBitValue(int[] moduleBitCount)
		{
			ulong num = 0uL;
			for (ulong num2 = 0uL; num2 < (ulong)moduleBitCount.Length; num2++)
			{
				for (int i = 0; i < moduleBitCount[num2]; i++)
				{
					num = (num << 1) | (ulong)((num2 % 2 == 0L) ? 1 : 0);
				}
			}
			return (int)num;
		}

		private static int getClosestDecodedValue(int[] moduleBitCount)
		{
			int num = MathUtils.sum(moduleBitCount);
			float[] array = new float[PDF417Common.BARS_IN_MODULE];
			if (num > 1)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (float)moduleBitCount[i] / (float)num;
				}
			}
			float num2 = 3.4028235E+38f;
			int result = PDF417Common.INVALID_CODEWORD;
			for (int j = 0; j < RATIOS_TABLE.Length; j++)
			{
				float num3 = 0f;
				float[] array2 = RATIOS_TABLE[j];
				for (int k = 0; k < PDF417Common.BARS_IN_MODULE; k++)
				{
					float num4 = array2[k] - array[k];
					num3 += num4 * num4;
					if (num3 >= num2)
					{
						break;
					}
				}
				if (num3 < num2)
				{
					num2 = num3;
					result = PDF417Common.SYMBOL_TABLE[j];
				}
			}
			return result;
		}
	}
	public static class PDF417ScanningDecoder
	{
		private const int CODEWORD_SKEW_SIZE = 2;

		private const int MAX_ERRORS = 3;

		private const int MAX_EC_CODEWORDS = 512;

		private static readonly ZXing.PDF417.Internal.EC.ErrorCorrection errorCorrection = new ZXing.PDF417.Internal.EC.ErrorCorrection();

		public static DecoderResult decode(BitMatrix image, ResultPoint imageTopLeft, ResultPoint imageBottomLeft, ResultPoint imageTopRight, ResultPoint imageBottomRight, int minCodewordWidth, int maxCodewordWidth)
		{
			BoundingBox boundingBox = BoundingBox.Create(image, imageTopLeft, imageBottomLeft, imageTopRight, imageBottomRight);
			if (boundingBox == null)
			{
				return null;
			}
			DetectionResultRowIndicatorColumn detectionResultRowIndicatorColumn = null;
			DetectionResultRowIndicatorColumn detectionResultRowIndicatorColumn2 = null;
			DetectionResult detectionResult = null;
			for (int i = 0; i < 2; i++)
			{
				if (imageTopLeft != null)
				{
					detectionResultRowIndicatorColumn = getRowIndicatorColumn(image, boundingBox, imageTopLeft, leftToRight: true, minCodewordWidth, maxCodewordWidth);
				}
				if (imageTopRight != null)
				{
					detectionResultRowIndicatorColumn2 = getRowIndicatorColumn(image, boundingBox, imageTopRight, leftToRight: false, minCodewordWidth, maxCodewordWidth);
				}
				detectionResult = merge(detectionResultRowIndicatorColumn, detectionResultRowIndicatorColumn2);
				if (detectionResult == null)
				{
					return null;
				}
				if (i == 0 && detectionResult.Box != null && (detectionResult.Box.MinY < boundingBox.MinY || detectionResult.Box.MaxY > boundingBox.MaxY))
				{
					boundingBox = detectionResult.Box;
					continue;
				}
				detectionResult.Box = boundingBox;
				break;
			}
			int num = detectionResult.ColumnCount + 1;
			detectionResult.DetectionResultColumns[0] = detectionResultRowIndicatorColumn;
			detectionResult.DetectionResultColumns[num] = detectionResultRowIndicatorColumn2;
			bool flag = detectionResultRowIndicatorColumn != null;
			for (int j = 1; j <= num; j++)
			{
				int num2 = (flag ? j : (num - j));
				if (detectionResult.DetectionResultColumns[num2] != null)
				{
					continue;
				}
				DetectionResultColumn detectionResultColumn = ((num2 != 0 && num2 != num) ? new DetectionResultColumn(boundingBox) : new DetectionResultRowIndicatorColumn(boundingBox, num2 == 0));
				detectionResult.DetectionResultColumns[num2] = detectionResultColumn;
				int num3 = -1;
				int num4 = num3;
				for (int k = boundingBox.MinY; k <= boundingBox.MaxY; k++)
				{
					num3 = getStartColumn(detectionResult, num2, k, flag);
					if (num3 < 0 || num3 > boundingBox.MaxX)
					{
						if (num4 == -1)
						{
							continue;
						}
						num3 = num4;
					}
					Codeword codeword = detectCodeword(image, boundingBox.MinX, boundingBox.MaxX, flag, num3, k, minCodewordWidth, maxCodewordWidth);
					if (codeword != null)
					{
						detectionResultColumn.setCodeword(k, codeword);
						num4 = num3;
						minCodewordWidth = Math.Min(minCodewordWidth, codeword.Width);
						maxCodewordWidth = Math.Max(maxCodewordWidth, codeword.Width);
					}
				}
			}
			return createDecoderResult(detectionResult);
		}

		private static DetectionResult merge(DetectionResultRowIndicatorColumn leftRowIndicatorColumn, DetectionResultRowIndicatorColumn rightRowIndicatorColumn)
		{
			if (leftRowIndicatorColumn == null && rightRowIndicatorColumn == null)
			{
				return null;
			}
			BarcodeMetadata barcodeMetadata = getBarcodeMetadata(leftRowIndicatorColumn, rightRowIndicatorColumn);
			if (barcodeMetadata == null)
			{
				return null;
			}
			BoundingBox box = BoundingBox.merge(adjustBoundingBox(leftRowIndicatorColumn), adjustBoundingBox(rightRowIndicatorColumn));
			return new DetectionResult(barcodeMetadata, box);
		}

		private static BoundingBox adjustBoundingBox(DetectionResultRowIndicatorColumn rowIndicatorColumn)
		{
			if (rowIndicatorColumn == null)
			{
				return null;
			}
			int[] rowHeights = rowIndicatorColumn.getRowHeights();
			if (rowHeights == null)
			{
				return null;
			}
			int max = getMax(rowHeights);
			int num = 0;
			int[] array = rowHeights;
			foreach (int num2 in array)
			{
				num += max - num2;
				if (num2 > 0)
				{
					break;
				}
			}
			Codeword[] codewords = rowIndicatorColumn.Codewords;
			int num3 = 0;
			while (num > 0 && codewords[num3] == null)
			{
				num--;
				num3++;
			}
			int num4 = 0;
			for (int num5 = rowHeights.Length - 1; num5 >= 0; num5--)
			{
				num4 += max - rowHeights[num5];
				if (rowHeights[num5] > 0)
				{
					break;
				}
			}
			int num6 = codewords.Length - 1;
			while (num4 > 0 && codewords[num6] == null)
			{
				num4--;
				num6--;
			}
			return rowIndicatorColumn.Box.addMissingRows(num, num4, rowIndicatorColumn.IsLeft);
		}

		private static int getMax(int[] values)
		{
			int num = -1;
			for (int num2 = values.Length - 1; num2 >= 0; num2--)
			{
				num = Math.Max(num, values[num2]);
			}
			return num;
		}

		private static BarcodeMetadata getBarcodeMetadata(DetectionResultRowIndicatorColumn leftRowIndicatorColumn, DetectionResultRowIndicatorColumn rightRowIndicatorColumn)
		{
			BarcodeMetadata barcodeMetadata;
			if (leftRowIndicatorColumn == null || (barcodeMetadata = leftRowIndicatorColumn.getBarcodeMetadata()) == null)
			{
				return rightRowIndicatorColumn?.getBarcodeMetadata();
			}
			BarcodeMetadata barcodeMetadata2;
			if (rightRowIndicatorColumn == null || (barcodeMetadata2 = rightRowIndicatorColumn.getBarcodeMetadata()) == null)
			{
				return barcodeMetadata;
			}
			if (barcodeMetadata.ColumnCount != barcodeMetadata2.ColumnCount && barcodeMetadata.ErrorCorrectionLevel != barcodeMetadata2.ErrorCorrectionLevel && barcodeMetadata.RowCount != barcodeMetadata2.RowCount)
			{
				return null;
			}
			return barcodeMetadata;
		}

		private static DetectionResultRowIndicatorColumn getRowIndicatorColumn(BitMatrix image, BoundingBox boundingBox, ResultPoint startPoint, bool leftToRight, int minCodewordWidth, int maxCodewordWidth)
		{
			DetectionResultRowIndicatorColumn detectionResultRowIndicatorColumn = new DetectionResultRowIndicatorColumn(boundingBox, leftToRight);
			for (int i = 0; i < 2; i++)
			{
				int num = ((i == 0) ? 1 : (-1));
				int startColumn = (int)startPoint.X;
				for (int j = (int)startPoint.Y; j <= boundingBox.MaxY && j >= boundingBox.MinY; j += num)
				{
					Codeword codeword = detectCodeword(image, 0, image.Width, leftToRight, startColumn, j, minCodewordWidth, maxCodewordWidth);
					if (codeword != null)
					{
						detectionResultRowIndicatorColumn.setCodeword(j, codeword);
						startColumn = ((!leftToRight) ? codeword.EndX : codeword.StartX);
					}
				}
			}
			return detectionResultRowIndicatorColumn;
		}

		private static bool adjustCodewordCount(DetectionResult detectionResult, BarcodeValue[][] barcodeMatrix)
		{
			BarcodeValue barcodeValue = barcodeMatrix[0][1];
			int[] value = barcodeValue.getValue();
			int num = detectionResult.ColumnCount * detectionResult.RowCount - getNumberOfECCodeWords(detectionResult.ErrorCorrectionLevel);
			if (value.Length == 0)
			{
				if (num < 1 || num > PDF417Common.MAX_CODEWORDS_IN_BARCODE)
				{
					return false;
				}
				barcodeValue.setValue(num);
			}
			else if (value[0] != num)
			{
				barcodeValue.setValue(num);
			}
			return true;
		}

		private static DecoderResult createDecoderResult(DetectionResult detectionResult)
		{
			BarcodeValue[][] array = createBarcodeMatrix(detectionResult);
			if (array == null)
			{
				return null;
			}
			if (!adjustCodewordCount(detectionResult, array))
			{
				return null;
			}
			List<int> list = new List<int>();
			int[] array2 = new int[detectionResult.RowCount * detectionResult.ColumnCount];
			List<int[]> list2 = new List<int[]>();
			List<int> list3 = new List<int>();
			for (int i = 0; i < detectionResult.RowCount; i++)
			{
				for (int j = 0; j < detectionResult.ColumnCount; j++)
				{
					int[] value = array[i][j + 1].getValue();
					int num = i * detectionResult.ColumnCount + j;
					if (value.Length == 0)
					{
						list.Add(num);
						continue;
					}
					if (value.Length == 1)
					{
						array2[num] = value[0];
						continue;
					}
					list3.Add(num);
					list2.Add(value);
				}
			}
			int[][] array3 = new int[list2.Count][];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = list2[k];
			}
			return createDecoderResultFromAmbiguousValues(detectionResult.ErrorCorrectionLevel, array2, list.ToArray(), list3.ToArray(), array3);
		}

		private static DecoderResult createDecoderResultFromAmbiguousValues(int ecLevel, int[] codewords, int[] erasureArray, int[] ambiguousIndexes, int[][] ambiguousIndexValues)
		{
			int[] array = new int[ambiguousIndexes.Length];
			int num = 100;
			while (num-- > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					codewords[ambiguousIndexes[i]] = ambiguousIndexValues[i][array[i]];
				}
				try
				{
					DecoderResult decoderResult = decodeCodewords(codewords, ecLevel, erasureArray);
					if (decoderResult != null)
					{
						return decoderResult;
					}
				}
				catch (ReaderException)
				{
				}
				if (array.Length == 0)
				{
					return null;
				}
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] < ambiguousIndexValues[j].Length - 1)
					{
						array[j]++;
						break;
					}
					array[j] = 0;
					if (j == array.Length - 1)
					{
						return null;
					}
				}
			}
			return null;
		}

		private static BarcodeValue[][] createBarcodeMatrix(DetectionResult detectionResult)
		{
			BarcodeValue[][] array = new BarcodeValue[detectionResult.RowCount][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new BarcodeValue[detectionResult.ColumnCount + 2];
				for (int j = 0; j < array[i].Length; j++)
				{
					array[i][j] = new BarcodeValue();
				}
			}
			int num = 0;
			DetectionResultColumn[] detectionResultColumns = detectionResult.getDetectionResultColumns();
			foreach (DetectionResultColumn detectionResultColumn in detectionResultColumns)
			{
				if (detectionResultColumn != null)
				{
					Codeword[] codewords = detectionResultColumn.Codewords;
					foreach (Codeword codeword in codewords)
					{
						if (codeword != null)
						{
							int rowNumber = codeword.RowNumber;
							if (rowNumber >= 0 && rowNumber < array.Length)
							{
								array[rowNumber][num].setValue(codeword.Value);
							}
						}
					}
				}
				num++;
			}
			return array;
		}

		private static bool isValidBarcodeColumn(DetectionResult detectionResult, int barcodeColumn)
		{
			if (barcodeColumn >= 0)
			{
				return barcodeColumn < detectionResult.DetectionResultColumns.Length;
			}
			return false;
		}

		private static int getStartColumn(DetectionResult detectionResult, int barcodeColumn, int imageRow, bool leftToRight)
		{
			int num = (leftToRight ? 1 : (-1));
			Codeword codeword = null;
			if (isValidBarcodeColumn(detectionResult, barcodeColumn - num))
			{
				codeword = detectionResult.DetectionResultColumns[barcodeColumn - num].getCodeword(imageRow);
			}
			if (codeword != null)
			{
				if (!leftToRight)
				{
					return codeword.StartX;
				}
				return codeword.EndX;
			}
			codeword = detectionResult.DetectionResultColumns[barcodeColumn].getCodewordNearby(imageRow);
			if (codeword != null)
			{
				if (!leftToRight)
				{
					return codeword.EndX;
				}
				return codeword.StartX;
			}
			if (isValidBarcodeColumn(detectionResult, barcodeColumn - num))
			{
				codeword = detectionResult.DetectionResultColumns[barcodeColumn - num].getCodewordNearby(imageRow);
			}
			if (codeword != null)
			{
				if (!leftToRight)
				{
					return codeword.StartX;
				}
				return codeword.EndX;
			}
			int num2 = 0;
			while (isValidBarcodeColumn(detectionResult, barcodeColumn - num))
			{
				barcodeColumn -= num;
				Codeword[] codewords = detectionResult.DetectionResultColumns[barcodeColumn].Codewords;
				foreach (Codeword codeword2 in codewords)
				{
					if (codeword2 != null)
					{
						return (leftToRight ? codeword2.EndX : codeword2.StartX) + num * num2 * (codeword2.EndX - codeword2.StartX);
					}
				}
				num2++;
			}
			if (!leftToRight)
			{
				return detectionResult.Box.MaxX;
			}
			return detectionResult.Box.MinX;
		}

		private static Codeword detectCodeword(BitMatrix image, int minColumn, int maxColumn, bool leftToRight, int startColumn, int imageRow, int minCodewordWidth, int maxCodewordWidth)
		{
			startColumn = adjustCodewordStartColumn(image, minColumn, maxColumn, leftToRight, startColumn, imageRow);
			int[] moduleBitCount = getModuleBitCount(image, minColumn, maxColumn, leftToRight, startColumn, imageRow);
			if (moduleBitCount == null)
			{
				return null;
			}
			int num = MathUtils.sum(moduleBitCount);
			int num2;
			if (leftToRight)
			{
				num2 = startColumn + num;
			}
			else
			{
				for (int i = 0; i < moduleBitCount.Length >> 1; i++)
				{
					int num3 = moduleBitCount[i];
					moduleBitCount[i] = moduleBitCount[moduleBitCount.Length - 1 - i];
					moduleBitCount[moduleBitCount.Length - 1 - i] = num3;
				}
				num2 = startColumn;
				startColumn = num2 - num;
			}
			if (!checkCodewordSkew(num, minCodewordWidth, maxCodewordWidth))
			{
				return null;
			}
			int decodedValue = PDF417CodewordDecoder.getDecodedValue(moduleBitCount);
			int codeword = PDF417Common.getCodeword(decodedValue);
			if (codeword == -1)
			{
				return null;
			}
			return new Codeword(startColumn, num2, getCodewordBucketNumber(decodedValue), codeword);
		}

		private static int[] getModuleBitCount(BitMatrix image, int minColumn, int maxColumn, bool leftToRight, int startColumn, int imageRow)
		{
			int num = startColumn;
			int[] array = new int[8];
			int num2 = 0;
			int num3 = (leftToRight ? 1 : (-1));
			bool flag = leftToRight;
			while ((leftToRight ? (num < maxColumn) : (num >= minColumn)) && num2 < array.Length)
			{
				if (image[num, imageRow] == flag)
				{
					array[num2]++;
					num += num3;
				}
				else
				{
					num2++;
					flag = !flag;
				}
			}
			if (num2 == array.Length || (num == (leftToRight ? maxColumn : minColumn) && num2 == array.Length - 1))
			{
				return array;
			}
			return null;
		}

		private static int getNumberOfECCodeWords(int barcodeECLevel)
		{
			return 2 << barcodeECLevel;
		}

		private static int adjustCodewordStartColumn(BitMatrix image, int minColumn, int maxColumn, bool leftToRight, int codewordStartColumn, int imageRow)
		{
			int i = codewordStartColumn;
			int num = ((!leftToRight) ? 1 : (-1));
			for (int j = 0; j < 2; j++)
			{
				for (; (leftToRight ? (i >= minColumn) : (i < maxColumn)) && leftToRight == image[i, imageRow]; i += num)
				{
					if (Math.Abs(codewordStartColumn - i) > 2)
					{
						return codewordStartColumn;
					}
				}
				num = -num;
				leftToRight = !leftToRight;
			}
			return i;
		}

		private static bool checkCodewordSkew(int codewordSize, int minCodewordWidth, int maxCodewordWidth)
		{
			if (minCodewordWidth - 2 <= codewordSize)
			{
				return codewordSize <= maxCodewordWidth + 2;
			}
			return false;
		}

		private static DecoderResult decodeCodewords(int[] codewords, int ecLevel, int[] erasures)
		{
			if (codewords.Length == 0)
			{
				return null;
			}
			int numECCodewords = 1 << ecLevel + 1;
			int num = correctErrors(codewords, erasures, numECCodewords);
			if (num < 0)
			{
				return null;
			}
			if (!verifyCodewordCount(codewords, numECCodewords))
			{
				return null;
			}
			DecoderResult decoderResult = DecodedBitStreamParser.decode(codewords, ecLevel.ToString());
			if (decoderResult != null)
			{
				decoderResult.ErrorsCorrected = num;
				decoderResult.Erasures = erasures.Length;
			}
			return decoderResult;
		}

		private static int correctErrors(int[] codewords, int[] erasures, int numECCodewords)
		{
			if ((erasures != null && erasures.Length > numECCodewords / 2 + 3) || numECCodewords < 0 || numECCodewords > 512)
			{
				return -1;
			}
			if (!errorCorrection.decode(codewords, numECCodewords, erasures, out var errorLocationsCount))
			{
				return -1;
			}
			return errorLocationsCount;
		}

		private static bool verifyCodewordCount(int[] codewords, int numECCodewords)
		{
			if (codewords.Length < 4)
			{
				return false;
			}
			int num = codewords[0];
			if (num > codewords.Length)
			{
				return false;
			}
			if (num == 0)
			{
				if (numECCodewords >= codewords.Length)
				{
					return false;
				}
				codewords[0] = codewords.Length - numECCodewords;
			}
			return true;
		}

		private static int[] getBitCountForCodeword(int codeword)
		{
			int[] array = new int[8];
			int num = 0;
			int num2 = array.Length - 1;
			while (true)
			{
				if ((codeword & 1) != num)
				{
					num = codeword & 1;
					num2--;
					if (num2 < 0)
					{
						break;
					}
				}
				array[num2]++;
				codeword >>= 1;
			}
			return array;
		}

		private static int getCodewordBucketNumber(int codeword)
		{
			return getCodewordBucketNumber(getBitCountForCodeword(codeword));
		}

		private static int getCodewordBucketNumber(int[] moduleBitCount)
		{
			return (moduleBitCount[0] - moduleBitCount[2] + moduleBitCount[4] - moduleBitCount[6] + 9) % 9;
		}

		public static string ToString(BarcodeValue[][] barcodeMatrix)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < barcodeMatrix.Length; i++)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Row {0,2}: ", new object[1] { i });
				for (int j = 0; j < barcodeMatrix[i].Length; j++)
				{
					BarcodeValue barcodeValue = barcodeMatrix[i][j];
					int[] value = barcodeValue.getValue();
					if (value.Length == 0)
					{
						stringBuilder.Append("        ");
						continue;
					}
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0,4}({1,2})", new object[2]
					{
						value[0],
						barcodeValue.getConfidence(value[0])
					});
				}
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class Detector
	{
		private static readonly int[] INDEXES_START_PATTERN = new int[4] { 0, 4, 1, 5 };

		private static readonly int[] INDEXES_STOP_PATTERN = new int[4] { 6, 2, 7, 3 };

		private const int INTEGER_MATH_SHIFT = 8;

		private const int PATTERN_MATCH_RESULT_SCALE_FACTOR = 256;

		private const int MAX_AVG_VARIANCE = 107;

		private const int MAX_INDIVIDUAL_VARIANCE = 204;

		private static readonly int[] START_PATTERN = new int[8] { 8, 1, 1, 1, 1, 1, 1, 3 };

		private static readonly int[] STOP_PATTERN = new int[9] { 7, 1, 1, 3, 1, 1, 1, 2, 1 };

		private const int MAX_PIXEL_DRIFT = 3;

		private const int MAX_PATTERN_DRIFT = 5;

		private const int SKIPPED_ROW_COUNT_MAX = 25;

		private const int ROW_STEP = 5;

		private const int BARCODE_MIN_HEIGHT = 10;

		public static PDF417DetectorResult detect(BinaryBitmap image, IDictionary<DecodeHintType, object> hints, bool multiple)
		{
			BitMatrix bitMatrix = image.BlackMatrix;
			if (bitMatrix == null)
			{
				return null;
			}
			List<ResultPoint[]> list = detect(multiple, bitMatrix);
			if (list == null || list.Count == 0)
			{
				bitMatrix = (BitMatrix)bitMatrix.Clone();
				bitMatrix.rotate180();
				list = detect(multiple, bitMatrix);
			}
			return new PDF417DetectorResult(bitMatrix, list);
		}

		private static List<ResultPoint[]> detect(bool multiple, BitMatrix bitMatrix)
		{
			List<ResultPoint[]> list = new List<ResultPoint[]>();
			int num = 0;
			int startColumn = 0;
			bool flag = false;
			while (num < bitMatrix.Height)
			{
				ResultPoint[] array = findVertices(bitMatrix, num, startColumn);
				if (array[0] == null && array[3] == null)
				{
					if (!flag)
					{
						break;
					}
					flag = false;
					startColumn = 0;
					foreach (ResultPoint[] item in list)
					{
						if (item[1] != null)
						{
							num = (int)Math.Max(num, item[1].Y);
						}
						if (item[3] != null)
						{
							num = Math.Max(num, (int)item[3].Y);
						}
					}
					num += 5;
				}
				else
				{
					flag = true;
					list.Add(array);
					if (!multiple)
					{
						break;
					}
					if (array[2] != null)
					{
						startColumn = (int)array[2].X;
						num = (int)array[2].Y;
					}
					else
					{
						startColumn = (int)array[4].X;
						num = (int)array[4].Y;
					}
				}
			}
			return list;
		}

		private static ResultPoint[] findVertices(BitMatrix matrix, int startRow, int startColumn)
		{
			int height = matrix.Height;
			int width = matrix.Width;
			ResultPoint[] array = new ResultPoint[8];
			copyToResult(array, findRowsWithPattern(matrix, height, width, startRow, startColumn, START_PATTERN), INDEXES_START_PATTERN);
			if (array[4] != null)
			{
				startColumn = (int)array[4].X;
				startRow = (int)array[4].Y;
			}
			copyToResult(array, findRowsWithPattern(matrix, height, width, startRow, startColumn, STOP_PATTERN), INDEXES_STOP_PATTERN);
			return array;
		}

		private static void copyToResult(ResultPoint[] result, ResultPoint[] tmpResult, int[] destinationIndexes)
		{
			for (int i = 0; i < destinationIndexes.Length; i++)
			{
				result[destinationIndexes[i]] = tmpResult[i];
			}
		}

		private static ResultPoint[] findRowsWithPattern(BitMatrix matrix, int height, int width, int startRow, int startColumn, int[] pattern)
		{
			ResultPoint[] array = new ResultPoint[4];
			bool flag = false;
			int[] counters = new int[pattern.Length];
			while (startRow < height)
			{
				int[] array2 = findGuardPattern(matrix, startColumn, startRow, width, whiteFirst: false, pattern, counters);
				if (array2 != null)
				{
					while (startRow > 0)
					{
						int[] array3 = findGuardPattern(matrix, startColumn, --startRow, width, whiteFirst: false, pattern, counters);
						if (array3 != null)
						{
							array2 = array3;
							continue;
						}
						startRow++;
						break;
					}
					array[0] = new ResultPoint(array2[0], startRow);
					array[1] = new ResultPoint(array2[1], startRow);
					flag = true;
					break;
				}
				startRow += 5;
			}
			int i = startRow + 1;
			if (flag)
			{
				int num = 0;
				int[] array4 = new int[2]
				{
					(int)array[0].X,
					(int)array[1].X
				};
				for (; i < height; i++)
				{
					int[] array5 = findGuardPattern(matrix, array4[0], i, width, whiteFirst: false, pattern, counters);
					if (array5 != null && Math.Abs(array4[0] - array5[0]) < 5 && Math.Abs(array4[1] - array5[1]) < 5)
					{
						array4 = array5;
						num = 0;
						continue;
					}
					if (num > 25)
					{
						break;
					}
					num++;
				}
				i -= num + 1;
				array[2] = new ResultPoint(array4[0], i);
				array[3] = new ResultPoint(array4[1], i);
			}
			if (i - startRow < 10)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = null;
				}
			}
			return array;
		}

		private static int[] findGuardPattern(BitMatrix matrix, int column, int row, int width, bool whiteFirst, int[] pattern, int[] counters)
		{
			SupportClass.Fill(counters, 0);
			int num = column;
			int num2 = 0;
			while (matrix[num, row] && num > 0 && num2++ < 3)
			{
				num--;
			}
			int i = num;
			int num3 = 0;
			int num4 = pattern.Length;
			bool flag = whiteFirst;
			for (; i < width; i++)
			{
				if (matrix[i, row] != flag)
				{
					counters[num3]++;
					continue;
				}
				if (num3 == num4 - 1)
				{
					if (patternMatchVariance(counters, pattern, 204) < 107)
					{
						return new int[2] { num, i };
					}
					num += counters[0] + counters[1];
					Array.Copy(counters, 2, counters, 0, num3 - 1);
					counters[num3 - 1] = 0;
					counters[num3] = 0;
					num3--;
				}
				else
				{
					num3++;
				}
				counters[num3] = 1;
				flag = !flag;
			}
			if (num3 == num4 - 1 && patternMatchVariance(counters, pattern, 204) < 107)
			{
				return new int[2]
				{
					num,
					i - 1
				};
			}
			return null;
		}

		private static int patternMatchVariance(int[] counters, int[] pattern, int maxIndividualVariance)
		{
			int num = counters.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				num2 += counters[i];
				num3 += pattern[i];
			}
			if (num2 < num3)
			{
				return 2147483647;
			}
			int num4 = (num2 << 8) / num3;
			maxIndividualVariance = maxIndividualVariance * num4 >> 8;
			int num5 = 0;
			for (int j = 0; j < num; j++)
			{
				int num6 = counters[j] << 8;
				int num7 = pattern[j] * num4;
				int num8 = ((num6 > num7) ? (num6 - num7) : (num7 - num6));
				if (num8 > maxIndividualVariance)
				{
					return 2147483647;
				}
				num5 += num8;
			}
			return num5 / num2;
		}
	}
	public sealed class PDF417DetectorResult
	{
		public BitMatrix Bits { get; private set; }

		public List<ResultPoint[]> Points { get; private set; }

		public PDF417DetectorResult(BitMatrix bits, List<ResultPoint[]> points)
		{
			Bits = bits;
			Points = points;
		}
	}
	public enum PDF417AspectRatio
	{
		A1 = 1,
		A2,
		A3,
		A4,
		AUTO
	}
	internal sealed class BarcodeMatrix
	{
		private readonly BarcodeRow[] matrix;

		private int currentRow;

		private readonly int height;

		private readonly int width;

		internal const int COLUMN_WIDTH = 17;

		internal BarcodeMatrix(int height, int width, bool compact)
		{
			matrix = new BarcodeRow[height];
			int i = 0;
			for (int num = matrix.Length; i < num; i++)
			{
				matrix[i] = new BarcodeRow(width * 17 + 34 + ((!compact) ? 2 : 0) * 17 + 1);
			}
			this.width = width * 17;
			this.height = height;
			currentRow = -1;
		}

		internal void set(int x, int y, sbyte value)
		{
			matrix[y][x] = value;
		}

		internal void startRow()
		{
			currentRow++;
		}

		internal BarcodeRow getCurrentRow()
		{
			return matrix[currentRow];
		}

		internal sbyte[][] getMatrix()
		{
			return getScaledMatrix(1, 1);
		}

		internal sbyte[][] getScaledMatrix(int xScale, int yScale)
		{
			sbyte[][] array = new sbyte[height * yScale][];
			for (int i = 0; i < height * yScale; i++)
			{
				array[i] = new sbyte[width * xScale];
			}
			int num = height * yScale;
			for (int j = 0; j < num; j++)
			{
				array[num - j - 1] = matrix[j / yScale].getScaledRow(xScale);
			}
			return array;
		}
	}
	internal sealed class BarcodeRow
	{
		private readonly sbyte[] row;

		private int currentLocation;

		internal sbyte this[int x]
		{
			get
			{
				return row[x];
			}
			set
			{
				row[x] = value;
			}
		}

		internal BarcodeRow(int width)
		{
			row = new sbyte[width];
			currentLocation = 0;
		}

		internal void set(int x, bool black)
		{
			row[x] = (sbyte)(black ? 1 : 0);
		}

		internal void addBar(bool black, int width)
		{
			for (int i = 0; i < width; i++)
			{
				set(currentLocation++, black);
			}
		}

		internal sbyte[] getScaledRow(int scale)
		{
			sbyte[] array = new sbyte[row.Length * scale];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = row[i / scale];
			}
			return array;
		}
	}
	public enum Compaction
	{
		AUTO,
		TEXT,
		BYTE,
		NUMERIC
	}
	public sealed class Dimensions
	{
		private readonly int minCols;

		private readonly int maxCols;

		private readonly int minRows;

		private readonly int maxRows;

		public int MinCols => minCols;

		public int MaxCols => maxCols;

		public int MinRows => minRows;

		public int MaxRows => maxRows;

		public Dimensions(int minCols, int maxCols, int minRows, int maxRows)
		{
			this.minCols = minCols;
			this.maxCols = maxCols;
			this.minRows = minRows;
			this.maxRows = maxRows;
		}
	}
	internal sealed class PDF417
	{
		private const int START_PATTERN = 130728;

		private const int STOP_PATTERN = 260649;

		private static readonly int[][] CODEWORD_TABLE = new int[3][]
		{
			new int[929]
			{
				120256, 125680, 128380, 120032, 125560, 128318, 108736, 119920, 108640, 86080,
				108592, 86048, 110016, 120560, 125820, 109792, 120440, 125758, 88256, 109680,
				88160, 89536, 110320, 120700, 89312, 110200, 120638, 89200, 110140, 89840,
				110460, 89720, 110398, 89980, 128506, 119520, 125304, 128190, 107712, 119408,
				125244, 107616, 119352, 84032, 107568, 119324, 84000, 107544, 83984, 108256,
				119672, 125374, 85184, 108144, 119612, 85088, 108088, 119582, 85040, 108060,
				85728, 108408, 119742, 85616, 108348, 85560, 108318, 85880, 108478, 85820,
				85790, 107200, 119152, 125116, 107104, 119096, 125086, 83008, 107056, 119068,
				82976, 107032, 82960, 82952, 83648, 107376, 119228, 83552, 107320, 119198,
				83504, 107292, 83480, 83468, 83824, 107452, 83768, 107422, 83740, 83900,
				106848, 118968, 125022, 82496, 106800, 118940, 82464, 106776, 118926, 82448,
				106764, 82440, 106758, 82784, 106936, 119006, 82736, 106908, 82712, 106894,
				82700, 82694, 106974, 82830, 82240, 106672, 118876, 82208, 106648, 118862,
				82192, 106636, 82184, 106630, 82180, 82352, 82328, 82316, 82080, 118830,
				106572, 106566, 82050, 117472, 124280, 127678, 103616, 117360, 124220, 103520,
				117304, 124190, 75840, 103472, 75808, 104160, 117624, 124350, 76992, 104048,
				117564, 76896, 103992, 76848, 76824, 77536, 104312, 117694, 77424, 104252,
				77368, 77340, 77688, 104382, 77628, 77758, 121536, 126320, 128700, 121440,
				126264, 128670, 111680, 121392, 126236, 111648, 121368, 126222, 111632, 121356,
				103104, 117104, 124092, 112320, 103008, 117048, 124062, 112224, 121656, 126366,
				93248, 74784, 102936, 117006, 93216, 112152, 93200, 75456, 103280, 117180,
				93888, 75360, 103224, 117150, 93792, 112440, 121758, 93744, 75288, 93720,
				75632, 103356, 94064, 75576, 103326, 94008, 112542, 93980, 75708, 94140,
				75678, 94110, 121184, 126136, 128606, 111168, 121136, 126108, 111136, 121112,
				126094, 111120, 121100, 111112, 111108, 102752, 116920, 123998, 111456, 102704,
				116892, 91712, 74272, 121244, 116878, 91680, 74256, 102668, 91664, 111372,
				102662, 74244, 74592, 102840, 116958, 92000, 74544, 102812, 91952, 111516,
				102798, 91928, 74508, 74502, 74680, 102878, 92088, 74652, 92060, 74638,
				92046, 92126, 110912, 121008, 126044, 110880, 120984, 126030, 110864, 120972,
				110856, 120966, 110852, 110850, 74048, 102576, 116828, 90944, 74016, 102552,
				116814, 90912, 111000, 121038, 90896, 73992, 102534, 90888, 110982, 90884,
				74160, 102620, 91056, 74136, 102606, 91032, 111054, 91020, 74118, 91014,
				91100, 91086, 110752, 120920, 125998, 110736, 120908, 110728, 120902, 110724,
				110722, 73888, 102488, 116782, 90528, 73872, 102476, 90512, 110796, 102470,
				90504, 73860, 90500, 73858, 73944, 90584, 90572, 90566, 120876, 120870,
				110658, 102444, 73800, 90312, 90308, 90306, 101056, 116080, 123580, 100960,
				116024, 70720, 100912, 115996, 70688, 100888, 70672, 70664, 71360, 101232,
				116156, 71264, 101176, 116126, 71216, 101148, 71192, 71180, 71536, 101308,
				71480, 101278, 71452, 71612, 71582, 118112, 124600, 127838, 105024, 118064,
				124572, 104992, 118040, 124558, 104976, 118028, 104968, 118022, 100704, 115896,
				123486, 105312, 100656, 115868, 79424, 70176, 118172, 115854, 79392, 105240,
				100620, 79376, 70152, 79368, 70496, 100792, 115934, 79712, 70448, 118238,
				79664, 105372, 100750, 79640, 70412, 79628, 70584, 100830, 79800, 70556,
				79772, 70542, 70622, 79838, 122176, 126640, 128860, 122144, 126616, 128846,
				122128, 126604, 122120, 126598, 122116, 104768, 117936, 124508, 113472, 104736,
				126684, 124494, 113440, 122264, 126670, 113424, 104712, 117894, 113416, 122246,
				104706, 69952, 100528, 115804, 78656, 69920, 100504, 115790, 96064, 78624,
				104856, 117966, 96032, 113560, 122318, 100486, 96016, 78600, 104838, 96008,
				69890, 70064, 100572, 78768, 70040, 100558, 96176, 78744, 104910, 96152,
				113614, 70022, 78726, 70108, 78812, 70094, 96220, 78798, 122016, 126552,
				128814, 122000, 126540, 121992, 126534, 121988, 121986, 104608, 117848, 124462,
				113056, 104592, 126574, 113040, 122060, 117830, 113032, 104580, 113028, 104578,
				113026, 69792, 100440, 115758, 78240, 69776, 100428, 95136, 78224, 104652,
				100422, 95120, 113100, 69764, 95112, 78212, 69762, 78210, 69848, 100462,
				78296, 69836, 95192, 78284, 69830, 95180, 78278, 69870, 95214, 121936,
				126508, 121928, 126502, 121924, 121922, 104528, 117804, 112848, 104520, 117798,
				112840, 121958, 112836, 104514, 112834, 69712, 100396, 78032, 69704, 100390,
				94672, 78024, 104550, 94664, 112870, 69698, 94660, 78018, 94658, 78060,
				94700, 94694, 126486, 121890, 117782, 104484, 104482, 69672, 77928, 94440,
				69666, 77922, 99680, 68160, 99632, 68128, 99608, 115342, 68112, 99596,
				68104, 99590, 68448, 99768, 115422, 68400, 99740, 68376, 99726, 68364,
				68358, 68536, 99806, 68508, 68494, 68574, 101696, 116400, 123740, 101664,
				116376, 101648, 116364, 101640, 116358, 101636, 67904, 99504, 115292, 72512,
				67872, 116444, 115278, 72480, 101784, 116430, 72464, 67848, 99462, 72456,
				101766, 67842, 68016, 99548, 72624, 67992, 99534, 72600, 101838, 72588,
				67974, 68060, 72668, 68046, 72654, 118432, 124760, 127918, 118416, 124748,
				118408, 124742, 118404, 118402, 101536, 116312, 105888, 101520, 116300, 105872,
				118476, 116294, 105864, 101508, 105860, 101506, 105858, 67744, 99416, 72096,
				67728, 116334, 80800, 72080, 101580, 99398, 80784, 105932, 67716, 80776,
				72068, 67714, 72066, 67800, 99438, 72152, 67788, 80856, 72140, 67782,
				80844, 72134, 67822, 72174, 80878, 126800, 128940, 126792, 128934, 126788,
				126786, 118352, 124716, 122576, 126828, 124710, 122568, 126822, 122564, 118338,
				122562, 101456, 116268, 105680, 101448, 116262, 114128, 105672, 118374, 114120,
				122598, 101442, 114116, 105666, 114114, 67664, 99372, 71888, 67656, 99366,
				80336, 71880, 101478, 97232, 80328, 105702, 67650, 97224, 114150, 71874,
				97220, 67692, 71916, 67686, 80364, 71910, 97260, 80358, 97254, 126760,
				128918, 126756, 126754, 118312, 124694, 122472, 126774, 122468, 118306, 122466,
				101416, 116246, 105576, 101412, 113896, 105572, 101410, 113892, 105570, 113890,
				67624, 99350, 71784, 101430, 80104, 71780, 67618, 96744, 80100, 71778,
				96740, 80098, 96738, 71798, 96758, 126738, 122420, 122418, 105524, 113780,
				113778, 71732, 79988, 96500, 96498, 66880, 66848, 98968, 66832, 66824,
				66820, 66992, 66968, 66956, 66950, 67036, 67022, 100000, 99984, 115532,
				99976, 115526, 99972, 99970, 66720, 98904, 69024, 100056, 98892, 69008,
				100044, 69000, 100038, 68996, 66690, 68994, 66776, 98926, 69080, 100078,
				69068, 66758, 69062, 66798, 69102, 116560, 116552, 116548, 116546, 99920,
				102096, 116588, 115494, 102088, 116582, 102084, 99906, 102082, 66640, 68816,
				66632, 98854, 73168, 68808, 66628, 73160, 68804, 66626, 73156, 68802,
				66668, 68844, 66662, 73196, 68838, 73190, 124840, 124836, 124834, 116520,
				118632, 124854, 118628, 116514, 118626, 99880, 115478, 101992, 116534, 106216,
				101988, 99874, 106212, 101986, 106210, 66600, 98838, 68712, 99894, 72936,
				68708, 66594, 81384, 72932, 68706, 81380, 72930, 66614, 68726, 72950,
				81398, 128980, 128978, 124820, 126900, 124818, 126898, 116500, 118580, 116498,
				122740, 118578, 122738, 99860, 101940, 99858, 106100, 101938, 114420
			},
			new int[929]
			{
				128352, 129720, 125504, 128304, 129692, 125472, 128280, 129678, 125456, 128268,
				125448, 128262, 125444, 125792, 128440, 129758, 120384, 125744, 128412, 120352,
				125720, 128398, 120336, 125708, 120328, 125702, 120324, 120672, 125880, 128478,
				110144, 120624, 125852, 110112, 120600, 125838, 110096, 120588, 110088, 120582,
				110084, 110432, 120760, 125918, 89664, 110384, 120732, 89632, 110360, 120718,
				89616, 110348, 89608, 110342, 89952, 110520, 120798, 89904, 110492, 89880,
				110478, 89868, 90040, 110558, 90012, 89998, 125248, 128176, 129628, 125216,
				128152, 129614, 125200, 128140, 125192, 128134, 125188, 125186, 119616, 125360,
				128220, 119584, 125336, 128206, 119568, 125324, 119560, 125318, 119556, 119554,
				108352, 119728, 125404, 108320, 119704, 125390, 108304, 119692, 108296, 119686,
				108292, 108290, 85824, 108464, 119772, 85792, 108440, 119758, 85776, 108428,
				85768, 108422, 85764, 85936, 108508, 85912, 108494, 85900, 85894, 85980,
				85966, 125088, 128088, 129582, 125072, 128076, 125064, 128070, 125060, 125058,
				119200, 125144, 128110, 119184, 125132, 119176, 125126, 119172, 119170, 107424,
				119256, 125166, 107408, 119244, 107400, 119238, 107396, 107394, 83872, 107480,
				119278, 83856, 107468, 83848, 107462, 83844, 83842, 83928, 107502, 83916,
				83910, 83950, 125008, 128044, 125000, 128038, 124996, 124994, 118992, 125036,
				118984, 125030, 118980, 118978, 106960, 119020, 106952, 119014, 106948, 106946,
				82896, 106988, 82888, 106982, 82884, 82882, 82924, 82918, 124968, 128022,
				124964, 124962, 118888, 124982, 118884, 118882, 106728, 118902, 106724, 106722,
				82408, 106742, 82404, 82402, 124948, 124946, 118836, 118834, 106612, 106610,
				124224, 127664, 129372, 124192, 127640, 129358, 124176, 127628, 124168, 127622,
				124164, 124162, 117568, 124336, 127708, 117536, 124312, 127694, 117520, 124300,
				117512, 124294, 117508, 117506, 104256, 117680, 124380, 104224, 117656, 124366,
				104208, 117644, 104200, 117638, 104196, 104194, 77632, 104368, 117724, 77600,
				104344, 117710, 77584, 104332, 77576, 104326, 77572, 77744, 104412, 77720,
				104398, 77708, 77702, 77788, 77774, 128672, 129880, 93168, 128656, 129868,
				92664, 128648, 129862, 92412, 128644, 128642, 124064, 127576, 129326, 126368,
				124048, 129902, 126352, 128716, 127558, 126344, 124036, 126340, 124034, 126338,
				117152, 124120, 127598, 121760, 117136, 124108, 121744, 126412, 124102, 121736,
				117124, 121732, 117122, 121730, 103328, 117208, 124142, 112544, 103312, 117196,
				112528, 121804, 117190, 112520, 103300, 112516, 103298, 112514, 75680, 103384,
				117230, 94112, 75664, 103372, 94096, 112588, 103366, 94088, 75652, 94084,
				75650, 75736, 103406, 94168, 75724, 94156, 75718, 94150, 75758, 128592,
				129836, 91640, 128584, 129830, 91388, 128580, 91262, 128578, 123984, 127532,
				126160, 123976, 127526, 126152, 128614, 126148, 123970, 126146, 116944, 124012,
				121296, 116936, 124006, 121288, 126182, 121284, 116930, 121282, 102864, 116972,
				111568, 102856, 116966, 111560, 121318, 111556, 102850, 111554, 74704, 102892,
				92112, 74696, 102886, 92104, 111590, 92100, 74690, 92098, 74732, 92140,
				74726, 92134, 128552, 129814, 90876, 128548, 90750, 128546, 123944, 127510,
				126056, 128566, 126052, 123938, 126050, 116840, 123958, 121064, 116836, 121060,
				116834, 121058, 102632, 116854, 111080, 121078, 111076, 102626, 111074, 74216,
				102646, 91112, 74212, 91108, 74210, 91106, 74230, 91126, 128532, 90494,
				128530, 123924, 126004, 123922, 126002, 116788, 120948, 116786, 120946, 102516,
				110836, 102514, 110834, 73972, 90612, 73970, 90610, 128522, 123914, 125978,
				116762, 120890, 102458, 110714, 123552, 127320, 129198, 123536, 127308, 123528,
				127302, 123524, 123522, 116128, 123608, 127342, 116112, 123596, 116104, 123590,
				116100, 116098, 101280, 116184, 123630, 101264, 116172, 101256, 116166, 101252,
				101250, 71584, 101336, 116206, 71568, 101324, 71560, 101318, 71556, 71554,
				71640, 101358, 71628, 71622, 71662, 127824, 129452, 79352, 127816, 129446,
				79100, 127812, 78974, 127810, 123472, 127276, 124624, 123464, 127270, 124616,
				127846, 124612, 123458, 124610, 115920, 123500, 118224, 115912, 123494, 118216,
				124646, 118212, 115906, 118210, 100816, 115948, 105424, 100808, 115942, 105416,
				118246, 105412, 100802, 105410, 70608, 100844, 79824, 70600, 100838, 79816,
				105446, 79812, 70594, 79810, 70636, 79852, 70630, 79846, 129960, 95728,
				113404, 129956, 95480, 113278, 129954, 95356, 95294, 127784, 129430, 78588,
				128872, 129974, 95996, 78462, 128868, 127778, 95870, 128866, 123432, 127254,
				124520, 123428, 126696, 128886, 123426, 126692, 124514, 126690, 115816, 123446,
				117992, 115812, 122344, 117988, 115810, 122340, 117986, 122338, 100584, 115830,
				104936, 100580, 113640, 104932, 100578, 113636, 104930, 113634, 70120, 100598,
				78824, 70116, 96232, 78820, 70114, 96228, 78818, 96226, 70134, 78838,
				129940, 94968, 113022, 129938, 94844, 94782, 127764, 78206, 128820, 127762,
				95102, 128818, 123412, 124468, 123410, 126580, 124466, 126578, 115764, 117876,
				115762, 122100, 117874, 122098, 100468, 104692, 100466, 113140, 104690, 113138,
				69876, 78324, 69874, 95220, 78322, 95218, 129930, 94588, 94526, 127754,
				128794, 123402, 124442, 126522, 115738, 117818, 121978, 100410, 104570, 112890,
				69754, 78074, 94714, 94398, 123216, 127148, 123208, 127142, 123204, 123202,
				115408, 123244, 115400, 123238, 115396, 115394, 99792, 115436, 99784, 115430,
				99780, 99778, 68560, 99820, 68552, 99814, 68548, 68546, 68588, 68582,
				127400, 129238, 72444, 127396, 72318, 127394, 123176, 127126, 123752, 123172,
				123748, 123170, 123746, 115304, 123190, 116456, 115300, 116452, 115298, 116450,
				99560, 115318, 101864, 99556, 101860, 99554, 101858, 68072, 99574, 72680,
				68068, 72676, 68066, 72674, 68086, 72694, 129492, 80632, 105854, 129490,
				80508, 80446, 127380, 72062, 127924, 127378, 80766, 127922, 123156, 123700,
				123154, 124788, 123698, 124786, 115252, 116340, 115250, 118516, 116338, 118514,
				99444, 101620, 99442, 105972, 101618, 105970, 67828, 72180, 67826, 80884,
				72178, 80882, 97008, 114044, 96888, 113982, 96828, 96798, 129482, 80252,
				130010, 97148, 80190, 97086, 127370, 127898, 128954, 123146, 123674, 124730,
				126842, 115226, 116282, 118394, 122618, 99386, 101498, 105722, 114170, 67706,
				71930, 80378, 96632, 113854, 96572, 96542, 80062, 96702, 96444, 96414,
				96350, 123048, 123044, 123042, 115048, 123062, 115044, 115042, 99048, 115062,
				99044, 99042, 67048, 99062, 67044, 67042, 67062, 127188, 68990, 127186,
				123028, 123316, 123026, 123314, 114996, 115572, 114994, 115570, 98932, 100084,
				98930, 100082, 66804, 69108, 66802, 69106, 129258, 73084, 73022, 127178,
				127450, 123018, 123290, 123834, 114970, 115514, 116602, 98874, 99962, 102138,
				66682, 68858, 73210, 81272, 106174, 81212, 81182, 72894, 81342, 97648,
				114364, 97592, 114334, 97564, 97550, 81084, 97724, 81054, 97694, 97464,
				114270, 97436, 97422, 80990, 97502, 97372, 97358, 97326, 114868, 114866,
				98676, 98674, 66292, 66290, 123098, 114842, 115130, 98618, 99194, 66170,
				67322, 69310, 73404, 73374, 81592, 106334, 81564, 81550, 73310, 81630,
				97968, 114524, 97944, 114510, 97932, 97926, 81500, 98012, 81486, 97998,
				97880, 114478, 97868, 97862, 81454, 97902, 97836, 97830, 69470, 73564,
				73550, 81752, 106414, 81740, 81734, 73518, 81774, 81708, 81702
			},
			new int[929]
			{
				109536, 120312, 86976, 109040, 120060, 86496, 108792, 119934, 86256, 108668,
				86136, 129744, 89056, 110072, 129736, 88560, 109820, 129732, 88312, 109694,
				129730, 88188, 128464, 129772, 89592, 128456, 129766, 89340, 128452, 89214,
				128450, 125904, 128492, 125896, 128486, 125892, 125890, 120784, 125932, 120776,
				125926, 120772, 120770, 110544, 120812, 110536, 120806, 110532, 84928, 108016,
				119548, 84448, 107768, 119422, 84208, 107644, 84088, 107582, 84028, 129640,
				85488, 108284, 129636, 85240, 108158, 129634, 85116, 85054, 128232, 129654,
				85756, 128228, 85630, 128226, 125416, 128246, 125412, 125410, 119784, 125430,
				119780, 119778, 108520, 119798, 108516, 108514, 83424, 107256, 119166, 83184,
				107132, 83064, 107070, 83004, 82974, 129588, 83704, 107390, 129586, 83580,
				83518, 128116, 83838, 128114, 125172, 125170, 119284, 119282, 107508, 107506,
				82672, 106876, 82552, 106814, 82492, 82462, 129562, 82812, 82750, 128058,
				125050, 119034, 82296, 106686, 82236, 82206, 82366, 82108, 82078, 76736,
				103920, 117500, 76256, 103672, 117374, 76016, 103548, 75896, 103486, 75836,
				129384, 77296, 104188, 129380, 77048, 104062, 129378, 76924, 76862, 127720,
				129398, 77564, 127716, 77438, 127714, 124392, 127734, 124388, 124386, 117736,
				124406, 117732, 117730, 104424, 117750, 104420, 104418, 112096, 121592, 126334,
				92608, 111856, 121468, 92384, 111736, 121406, 92272, 111676, 92216, 111646,
				92188, 75232, 103160, 117118, 93664, 74992, 103036, 93424, 112252, 102974,
				93304, 74812, 93244, 74782, 93214, 129332, 75512, 103294, 129908, 129330,
				93944, 75388, 129906, 93820, 75326, 93758, 127604, 75646, 128756, 127602,
				94078, 128754, 124148, 126452, 124146, 126450, 117236, 121844, 117234, 121842,
				103412, 103410, 91584, 111344, 121212, 91360, 111224, 121150, 91248, 111164,
				91192, 111134, 91164, 91150, 74480, 102780, 91888, 74360, 102718, 91768,
				111422, 91708, 74270, 91678, 129306, 74620, 129850, 92028, 74558, 91966,
				127546, 128634, 124026, 126202, 116986, 121338, 102906, 90848, 110968, 121022,
				90736, 110908, 90680, 110878, 90652, 90638, 74104, 102590, 91000, 74044,
				90940, 74014, 90910, 74174, 91070, 90480, 110780, 90424, 110750, 90396,
				90382, 73916, 90556, 73886, 90526, 90296, 110686, 90268, 90254, 73822,
				90334, 90204, 90190, 71136, 101112, 116094, 70896, 100988, 70776, 100926,
				70716, 70686, 129204, 71416, 101246, 129202, 71292, 71230, 127348, 71550,
				127346, 123636, 123634, 116212, 116210, 101364, 101362, 79296, 105200, 118140,
				79072, 105080, 118078, 78960, 105020, 78904, 104990, 78876, 78862, 70384,
				100732, 79600, 70264, 100670, 79480, 105278, 79420, 70174, 79390, 129178,
				70524, 129466, 79740, 70462, 79678, 127290, 127866, 123514, 124666, 115962,
				118266, 100858, 113376, 122232, 126654, 95424, 113264, 122172, 95328, 113208,
				122142, 95280, 113180, 95256, 113166, 95244, 78560, 104824, 117950, 95968,
				78448, 104764, 95856, 113468, 104734, 95800, 78364, 95772, 78350, 95758,
				70008, 100542, 78712, 69948, 96120, 78652, 69918, 96060, 78622, 96030,
				70078, 78782, 96190, 94912, 113008, 122044, 94816, 112952, 122014, 94768,
				112924, 94744, 112910, 94732, 94726, 78192, 104636, 95088, 78136, 104606,
				95032, 113054, 95004, 78094, 94990, 69820, 78268, 69790, 95164, 78238,
				95134, 94560, 112824, 121950, 94512, 112796, 94488, 112782, 94476, 94470,
				78008, 104542, 94648, 77980, 94620, 77966, 94606, 69726, 78046, 94686,
				94384, 112732, 94360, 112718, 94348, 94342, 77916, 94428, 77902, 94414,
				94296, 112686, 94284, 94278, 77870, 94318, 94252, 94246, 68336, 99708,
				68216, 99646, 68156, 68126, 68476, 68414, 127162, 123258, 115450, 99834,
				72416, 101752, 116414, 72304, 101692, 72248, 101662, 72220, 72206, 67960,
				99518, 72568, 67900, 72508, 67870, 72478, 68030, 72638, 80576, 105840,
				118460, 80480, 105784, 118430, 80432, 105756, 80408, 105742, 80396, 80390,
				72048, 101564, 80752, 71992, 101534, 80696, 71964, 80668, 71950, 80654,
				67772, 72124, 67742, 80828, 72094, 80798, 114016, 122552, 126814, 96832,
				113968, 122524, 96800, 113944, 122510, 96784, 113932, 96776, 113926, 96772,
				80224, 105656, 118366, 97120, 80176, 105628, 97072, 114076, 105614, 97048,
				80140, 97036, 80134, 97030, 71864, 101470, 80312, 71836, 97208, 80284,
				71822, 97180, 80270, 97166, 67678, 71902, 80350, 97246, 96576, 113840,
				122460, 96544, 113816, 122446, 96528, 113804, 96520, 113798, 96516, 96514,
				80048, 105564, 96688, 80024, 105550, 96664, 113870, 96652, 80006, 96646,
				71772, 80092, 71758, 96732, 80078, 96718, 96416, 113752, 122414, 96400,
				113740, 96392, 113734, 96388, 96386, 79960, 105518, 96472, 79948, 96460,
				79942, 96454, 71726, 79982, 96494, 96336, 113708, 96328, 113702, 96324,
				96322, 79916, 96364, 79910, 96358, 96296, 113686, 96292, 96290, 79894,
				96310, 66936, 99006, 66876, 66846, 67006, 68976, 100028, 68920, 99998,
				68892, 68878, 66748, 69052, 66718, 69022, 73056, 102072, 116574, 73008,
				102044, 72984, 102030, 72972, 72966, 68792, 99934, 73144, 68764, 73116,
				68750, 73102, 66654, 68830, 73182, 81216, 106160, 118620, 81184, 106136,
				118606, 81168, 106124, 81160, 106118, 81156, 81154, 72880, 101980, 81328,
				72856, 101966, 81304, 106190, 81292, 72838, 81286, 68700, 72924, 68686,
				81372, 72910, 81358, 114336, 122712, 126894, 114320, 122700, 114312, 122694,
				114308, 114306, 81056, 106072, 118574, 97696, 81040, 106060, 97680, 114380,
				106054, 97672, 81028, 97668, 81026, 97666, 72792, 101934, 81112, 72780,
				97752, 81100, 72774, 97740, 81094, 97734, 68654, 72814, 81134, 97774,
				114256, 122668, 114248, 122662, 114244, 114242, 80976, 106028, 97488, 80968,
				106022, 97480, 114278, 97476, 80962, 97474, 72748, 81004, 72742, 97516,
				80998, 97510, 114216, 122646, 114212, 114210, 80936, 106006, 97384, 80932,
				97380, 80930, 97378, 72726, 80950, 97398, 114196, 114194, 80916, 97332,
				80914, 97330, 66236, 66206, 67256, 99166, 67228, 67214, 66142, 67294,
				69296, 100188, 69272, 100174, 69260, 69254, 67164, 69340, 67150, 69326,
				73376, 102232, 116654, 73360, 102220, 73352, 102214, 73348, 73346, 69208,
				100142, 73432, 102254, 73420, 69190, 73414, 67118, 69230, 73454, 106320,
				118700, 106312, 118694, 106308, 106306, 73296, 102188, 81616, 106348, 102182,
				81608, 73284, 81604, 73282, 81602, 69164, 73324, 69158, 81644, 73318,
				81638, 122792, 126934, 122788, 122786, 106280, 118678, 114536, 106276, 114532,
				106274, 114530, 73256, 102166, 81512, 73252, 98024, 81508, 73250, 98020,
				81506, 98018, 69142, 73270, 81526, 98038, 122772, 122770, 106260, 114484,
				106258, 114482, 73236, 81460, 73234, 97908, 81458, 97906, 122762, 106250,
				114458, 73226, 81434, 97850, 66396, 66382, 67416, 99246, 67404, 67398,
				66350, 67438, 69456, 100268, 69448, 100262, 69444, 69442, 67372, 69484,
				67366, 69478, 102312, 116694, 102308, 102306, 69416, 100246, 73576, 102326,
				73572, 69410, 73570, 67350, 69430, 73590, 118740, 118738, 102292, 106420,
				102290, 106418, 69396, 73524, 69394, 81780, 73522, 81778, 118730, 102282,
				106394, 69386, 73498, 81722, 66476, 66470, 67496, 99286, 67492, 67490,
				66454, 67510, 100308, 100306, 67476, 69556, 67474, 69554, 116714
			}
		};

		private const float PREFERRED_RATIO = 3f;

		private const float DEFAULT_MODULE_WIDTH = 0.357f;

		private const float HEIGHT = 2f;

		private BarcodeMatrix barcodeMatrix;

		private bool compact;

		private Compaction compaction;

		private Encoding encoding;

		private bool disableEci;

		private int minCols;

		private int maxCols;

		private int maxRows;

		private int minRows;

		internal BarcodeMatrix BarcodeMatrix => barcodeMatrix;

		internal PDF417()
			: this(compact: false)
		{
		}

		internal PDF417(bool compact)
		{
			this.compact = compact;
			compaction = Compaction.AUTO;
			encoding = null;
			disableEci = false;
			minCols = 2;
			maxCols = 30;
			maxRows = 90;
			minRows = 3;
		}

		private static int calculateNumberOfRows(int m, int k, int c)
		{
			int num = (m + 1 + k) / c + 1;
			if (c * num >= m + 1 + k + c)
			{
				num--;
			}
			return num;
		}

		private static int getNumberOfPadCodewords(int m, int k, int c, int r)
		{
			int num = c * r - k;
			if (num <= m + 1)
			{
				return 0;
			}
			return num - m - 1;
		}

		private static void encodeChar(int pattern, int len, BarcodeRow logic)
		{
			int num = 1 << len - 1;
			bool flag = (pattern & num) != 0;
			int num2 = 0;
			for (int i = 0; i < len; i++)
			{
				bool flag2 = (pattern & num) != 0;
				if (flag == flag2)
				{
					num2++;
				}
				else
				{
					logic.addBar(flag, num2);
					flag = flag2;
					num2 = 1;
				}
				num >>= 1;
			}
			logic.addBar(flag, num2);
		}

		private void encodeLowLevel(string fullCodewords, int c, int r, int errorCorrectionLevel, BarcodeMatrix logic)
		{
			int num = 0;
			for (int i = 0; i < r; i++)
			{
				int num2 = i % 3;
				logic.startRow();
				encodeChar(130728, 17, logic.getCurrentRow());
				int num3;
				int num4;
				switch (num2)
				{
				case 0:
					num3 = 30 * (i / 3) + (r - 1) / 3;
					num4 = 30 * (i / 3) + (c - 1);
					break;
				case 1:
					num3 = 30 * (i / 3) + errorCorrectionLevel * 3 + (r - 1) % 3;
					num4 = 30 * (i / 3) + (r - 1) / 3;
					break;
				default:
					num3 = 30 * (i / 3) + (c - 1);
					num4 = 30 * (i / 3) + errorCorrectionLevel * 3 + (r - 1) % 3;
					break;
				}
				encodeChar(CODEWORD_TABLE[num2][num3], 17, logic.getCurrentRow());
				for (int j = 0; j < c; j++)
				{
					encodeChar(CODEWORD_TABLE[num2][(uint)fullCodewords[num]], 17, logic.getCurrentRow());
					num++;
				}
				if (compact)
				{
					encodeChar(260649, 1, logic.getCurrentRow());
					continue;
				}
				encodeChar(CODEWORD_TABLE[num2][num4], 17, logic.getCurrentRow());
				encodeChar(260649, 18, logic.getCurrentRow());
			}
		}

		internal void generateBarcodeLogic(string msg, int errorCorrectionLevel, int longDimension, int shortDimension, ref int aspectRatio)
		{
			string text = PDF417HighLevelEncoder.encodeHighLevel(msg, compaction, encoding, disableEci);
			int length = text.Length;
			errorCorrectionLevel = PDF417ErrorCorrection.getErrorCorrectionLevel(errorCorrectionLevel, length);
			int errorCorrectionCodewordCount = PDF417ErrorCorrection.getErrorCorrectionCodewordCount(errorCorrectionLevel);
			int[] array = determineDimensions(length, errorCorrectionCodewordCount, longDimension, shortDimension, ref aspectRatio);
			int num = array[0];
			int num2 = array[1];
			int numberOfPadCodewords = getNumberOfPadCodewords(length, errorCorrectionCodewordCount, num, num2);
			if (length + errorCorrectionCodewordCount + 1 > 929)
			{
				throw new WriterException("Encoded message contains too many code words, message too big (" + msg.Length + " bytes)");
			}
			int num3 = length + numberOfPadCodewords + 1;
			StringBuilder stringBuilder = new StringBuilder(num3);
			stringBuilder.Append((char)num3);
			stringBuilder.Append(text);
			for (int i = 0; i < numberOfPadCodewords; i++)
			{
				stringBuilder.Append('\u0384');
			}
			string text2 = stringBuilder.ToString();
			string text3 = PDF417ErrorCorrection.generateErrorCorrection(text2, errorCorrectionLevel);
			string fullCodewords = text2 + text3;
			barcodeMatrix = new BarcodeMatrix(num2, num, compact);
			encodeLowLevel(fullCodewords, num, num2, errorCorrectionLevel, barcodeMatrix);
		}

		private int[] determineDimensions(int sourceCodeWords, int errorCorrectionCodeWords, int longDimension, int shortDimension, ref int aspectRatio)
		{
			int num = ((!compact) ? 2 : 0) * 17 + 1;
			int num2 = 34 + num;
			float num3 = 0f;
			int[] array = null;
			int num4 = 0;
			int num5 = 0;
			int num6 = 2147483647;
			bool flag = false;
			if (longDimension >= num2 + 17)
			{
				num5 = Math.Min((longDimension - num2) / 17, maxCols);
				num4 = Math.Min(shortDimension / aspectRatio, maxRows);
				num6 = calculateNumberOfRows(sourceCodeWords, errorCorrectionCodeWords, num5);
				flag = num6 <= num4;
			}
			if (aspectRatio >= 5)
			{
				num4 = Math.Min(shortDimension, maxRows);
				int num7 = 4;
				if (num4 >= num6)
				{
					num7 = Math.Min(num4 / num6, num7);
				}
				aspectRatio = num7;
				num4 = Math.Min(shortDimension / aspectRatio, maxRows);
				flag = num6 <= num4;
			}
			for (int i = minCols; i <= maxCols && (!flag || i <= num5); i++)
			{
				int num8 = calculateNumberOfRows(sourceCodeWords, errorCorrectionCodeWords, i);
				if (num8 < minRows)
				{
					break;
				}
				if (num8 <= maxRows && !(num8 > num4 && flag))
				{
					float num9 = (float)(17 * i + num2) * 0.357f / ((float)num8 * 2f);
					if (array == null || !(Math.Abs(num9 - 3f) > Math.Abs(num3 - 3f)))
					{
						num3 = num9;
						array = new int[2] { i, num8 };
					}
				}
			}
			if (array == null && calculateNumberOfRows(sourceCodeWords, errorCorrectionCodeWords, minCols) < minRows)
			{
				array = new int[2] { minCols, minRows };
			}
			if (array == null)
			{
				throw new WriterException("Unable to fit message in columns");
			}
			return array;
		}

		internal void setDimensions(int maxCols, int minCols, int maxRows, int minRows)
		{
			this.maxCols = maxCols;
			this.minCols = minCols;
			this.maxRows = maxRows;
			this.minRows = minRows;
		}

		internal void setCompaction(Compaction compaction)
		{
			this.compaction = compaction;
		}

		internal void setCompact(bool compact)
		{
			this.compact = compact;
		}

		internal void setEncoding(string encodingname)
		{
			encoding = Encoding.GetEncoding(encodingname);
		}

		internal void setDisableEci(bool disabled)
		{
			disableEci = disabled;
		}
	}
	internal static class PDF417ErrorCorrection
	{
		private static readonly int[][] EC_COEFFICIENTS = new int[9][]
		{
			new int[2] { 27, 917 },
			new int[4] { 522, 568, 723, 809 },
			new int[8] { 237, 308, 436, 284, 646, 653, 428, 379 },
			new int[16]
			{
				274, 562, 232, 755, 599, 524, 801, 132, 295, 116,
				442, 428, 295, 42, 176, 65
			},
			new int[32]
			{
				361, 575, 922, 525, 176, 586, 640, 321, 536, 742,
				677, 742, 687, 284, 193, 517, 273, 494, 263, 147,
				593, 800, 571, 320, 803, 133, 231, 390, 685, 330,
				63, 410
			},
			new int[64]
			{
				539, 422, 6, 93, 862, 771, 453, 106, 610, 287,
				107, 505, 733, 877, 381, 612, 723, 476, 462, 172,
				430, 609, 858, 822, 543, 376, 511, 400, 672, 762,
				283, 184, 440, 35, 519, 31, 460, 594, 225, 535,
				517, 352, 605, 158, 651, 201, 488, 502, 648, 733,
				717, 83, 404, 97, 280, 771, 840, 629, 4, 381,
				843, 623, 264, 543
			},
			new int[128]
			{
				521, 310, 864, 547, 858, 580, 296, 379, 53, 779,
				897, 444, 400, 925, 749, 415, 822, 93, 217, 208,
				928, 244, 583, 620, 246, 148, 447, 631, 292, 908,
				490, 704, 516, 258, 457, 907, 594, 723, 674, 292,
				272, 96, 684, 432, 686, 606, 860, 569, 193, 219,
				129, 186, 236, 287, 192, 775, 278, 173, 40, 379,
				712, 463, 646, 776, 171, 491, 297, 763, 156, 732,
				95, 270, 447, 90, 507, 48, 228, 821, 808, 898,
				784, 663, 627, 378, 382, 262, 380, 602, 754, 336,
				89, 614, 87, 432, 670, 616, 157, 374, 242, 726,
				600, 269, 375, 898, 845, 454, 354, 130, 814, 587,
				804, 34, 211, 330, 539, 297, 827, 865, 37, 517,
				834, 315, 550, 86, 801, 4, 108, 539
			},
			new int[256]
			{
				524, 894, 75, 766, 882, 857, 74, 204, 82, 586,
				708, 250, 905, 786, 138, 720, 858, 194, 311, 913,
				275, 190, 375, 850, 438, 733, 194, 280, 201, 280,
				828, 757, 710, 814, 919, 89, 68, 569, 11, 204,
				796, 605, 540, 913, 801, 700, 799, 137, 439, 418,
				592, 668, 353, 859, 370, 694, 325, 240, 216, 257,
				284, 549, 209, 884, 315, 70, 329, 793, 490, 274,
				877, 162, 749, 812, 684, 461, 334, 376, 849, 521,
				307, 291, 803, 712, 19, 358, 399, 908, 103, 511,
				51, 8, 517, 225, 289, 470, 637, 731, 66, 255,
				917, 269, 463, 830, 730, 433, 848, 585, 136, 538,
				906, 90, 2, 290, 743, 199, 655, 903, 329, 49,
				802, 580, 355, 588, 188, 462, 10, 134, 628, 320,
				479, 130, 739, 71, 263, 318, 374, 601, 192, 605,
				142, 673, 687, 234, 722, 384, 177, 752, 607, 640,
				455, 193, 689, 707, 805, 641, 48, 60, 732, 621,
				895, 544, 261, 852, 655, 309, 697, 755, 756, 60,
				231, 773, 434, 421, 726, 528, 503, 118, 49, 795,
				32, 144, 500, 238, 836, 394, 280, 566, 319, 9,
				647, 550, 73, 914, 342, 126, 32, 681, 331, 792,
				620, 60, 609, 441, 180, 791, 893, 754, 605, 383,
				228, 749, 760, 213, 54, 297, 134, 54, 834, 299,
				922, 191, 910, 532, 609, 829, 189, 20, 167, 29,
				872, 449, 83, 402, 41, 656, 505, 579, 481, 173,
				404, 251, 688, 95, 497, 555, 642, 543, 307, 159,
				924, 558, 648, 55, 497, 10
			},
			new int[512]
			{
				352, 77, 373, 504, 35, 599, 428, 207, 409, 574,
				118, 498, 285, 380, 350, 492, 197, 265, 920, 155,
				914, 299, 229, 643, 294, 871, 306, 88, 87, 193,
				352, 781, 846, 75, 327, 520, 435, 543, 203, 666,
				249, 346, 781, 621, 640, 268, 794, 534, 539, 781,
				408, 390, 644, 102, 476, 499, 290, 632, 545, 37,
				858, 916, 552, 41, 542, 289, 122, 272, 383, 800,
				485, 98, 752, 472, 761, 107, 784, 860, 658, 741,
				290, 204, 681, 407, 855, 85, 99, 62, 482, 180,
				20, 297, 451, 593, 913, 142, 808, 684, 287, 536,
				561, 76, 653, 899, 729, 567, 744, 390, 513, 192,
				516, 258, 240, 518, 794, 395, 768, 848, 51, 610,
				384, 168, 190, 826, 328, 596, 786, 303, 570, 381,
				415, 641, 156, 237, 151, 429, 531, 207, 676, 710,
				89, 168, 304, 402, 40, 708, 575, 162, 864, 229,
				65, 861, 841, 512, 164, 477, 221, 92, 358, 785,
				288, 357, 850, 836, 827, 736, 707, 94, 8, 494,
				114, 521, 2, 499, 851, 543, 152, 729, 771, 95,
				248, 361, 578, 323, 856, 797, 289, 51, 684, 466,
				533, 820, 669, 45, 902, 452, 167, 342, 244, 173,
				35, 463, 651, 51, 699, 591, 452, 578, 37, 124,
				298, 332, 552, 43, 427, 119, 662, 777, 475, 850,
				764, 364, 578, 911, 283, 711, 472, 420, 245, 288,
				594, 394, 511, 327, 589, 777, 699, 688, 43, 408,
				842, 383, 721, 521, 560, 644, 714, 559, 62, 145,
				873, 663, 713, 159, 672, 729, 624, 59, 193, 417,
				158, 209, 563, 564, 343, 693, 109, 608, 563, 365,
				181, 772, 677, 310, 248, 353, 708, 410, 579, 870,
				617, 841, 632, 860, 289, 536, 35, 777, 618, 586,
				424, 833, 77, 597, 346, 269, 757, 632, 695, 751,
				331, 247, 184, 45, 787, 680, 18, 66, 407, 369,
				54, 492, 228, 613, 830, 922, 437, 519, 644, 905,
				789, 420, 305, 441, 207, 300, 892, 827, 141, 537,
				381, 662, 513, 56, 252, 341, 242, 797, 838, 837,
				720, 224, 307, 631, 61, 87, 560, 310, 756, 665,
				397, 808, 851, 309, 473, 795, 378, 31, 647, 915,
				459, 806, 590, 731, 425, 216, 548, 249, 321, 881,
				699, 535, 673, 782, 210, 815, 905, 303, 843, 922,
				281, 73, 469, 791, 660, 162, 498, 308, 155, 422,
				907, 817, 187, 62, 16, 425, 535, 336, 286, 437,
				375, 273, 610, 296, 183, 923, 116, 667, 751, 353,
				62, 366, 691, 379, 687, 842, 37, 357, 720, 742,
				330, 5, 39, 923, 311, 424, 242, 749, 321, 54,
				669, 316, 342, 299, 534, 105, 667, 488, 640, 672,
				576, 540, 316, 486, 721, 610, 46, 656, 447, 171,
				616, 464, 190, 531, 297, 321, 762, 752, 533, 175,
				134, 14, 381, 433, 717, 45, 111, 20, 596, 284,
				736, 138, 646, 411, 877, 669, 141, 919, 45, 780,
				407, 164, 332, 899, 165, 726, 600, 325, 498, 655,
				357, 752, 768, 223, 849, 647, 63, 310, 863, 251,
				366, 304, 282, 738, 675, 410, 389, 244, 31, 121,
				303, 263
			}
		};

		internal static int getErrorCorrectionCodewordCount(int errorCorrectionLevel)
		{
			if (errorCorrectionLevel < 0 || errorCorrectionLevel > 8)
			{
				throw new ArgumentException("Error correction level must be between 0 and 8!");
			}
			return 1 << errorCorrectionLevel + 1;
		}

		internal static int getErrorCorrectionLevel(int errorCorrectionLevel, int sourceCodeWords)
		{
			if (errorCorrectionLevel == 9)
			{
				return getRecommendedMinimumErrorCorrectionLevel(sourceCodeWords);
			}
			return errorCorrectionLevel;
		}

		internal static int getRecommendedMinimumErrorCorrectionLevel(int n)
		{
			if (n <= 40)
			{
				return 2;
			}
			if (n <= 160)
			{
				return 3;
			}
			if (n <= 320)
			{
				return 4;
			}
			if (n <= 863)
			{
				return 5;
			}
			throw new WriterException("No recommendation possible");
		}

		internal static string generateErrorCorrection(string dataCodewords, int errorCorrectionLevel)
		{
			if (errorCorrectionLevel == 9)
			{
				errorCorrectionLevel = getRecommendedMinimumErrorCorrectionLevel(errorCorrectionLevel);
			}
			int errorCorrectionCodewordCount = getErrorCorrectionCodewordCount(errorCorrectionLevel);
			char[] array = new char[errorCorrectionCodewordCount];
			int length = dataCodewords.Length;
			for (int i = 0; i < length; i++)
			{
				int num = (dataCodewords[i] + array[array.Length - 1]) % 929;
				int num3;
				int num4;
				for (int num2 = errorCorrectionCodewordCount - 1; num2 >= 1; num2--)
				{
					num3 = num * EC_COEFFICIENTS[errorCorrectionLevel][num2] % 929;
					num4 = 929 - num3;
					array[num2] = (char)((array[num2 - 1] + num4) % 929);
				}
				num3 = num * EC_COEFFICIENTS[errorCorrectionLevel][0] % 929;
				num4 = 929 - num3;
				array[0] = (char)(num4 % 929);
			}
			StringBuilder stringBuilder = new StringBuilder(errorCorrectionCodewordCount);
			for (int num5 = errorCorrectionCodewordCount - 1; num5 >= 0; num5--)
			{
				if (array[num5] != 0)
				{
					array[num5] = (char)(929 - array[num5]);
				}
				stringBuilder.Append(array[num5]);
			}
			return stringBuilder.ToString();
		}
	}
	public enum PDF417ErrorCorrectionLevel
	{
		L0,
		L1,
		L2,
		L3,
		L4,
		L5,
		L6,
		L7,
		L8,
		AUTO
	}
	internal static class PDF417HighLevelEncoder
	{
		private const int TEXT_COMPACTION = 0;

		private const int BYTE_COMPACTION = 1;

		private const int NUMERIC_COMPACTION = 2;

		private const int SUBMODE_ALPHA = 0;

		private const int SUBMODE_LOWER = 1;

		private const int SUBMODE_MIXED = 2;

		private const int SUBMODE_PUNCTUATION = 3;

		private const int LATCH_TO_TEXT = 900;

		private const int LATCH_TO_BYTE_PADDED = 901;

		private const int LATCH_TO_NUMERIC = 902;

		private const int SHIFT_TO_BYTE = 913;

		private const int LATCH_TO_BYTE = 924;

		private const int ECI_USER_DEFINED = 925;

		private const int ECI_GENERAL_PURPOSE = 926;

		private const int ECI_CHARSET = 927;

		private static readonly sbyte[] TEXT_MIXED_RAW;

		private static readonly sbyte[] TEXT_PUNCTUATION_RAW;

		private static readonly sbyte[] MIXED;

		private static readonly sbyte[] PUNCTUATION;

		internal static string DEFAULT_ENCODING_NAME;

		static PDF417HighLevelEncoder()
		{
			TEXT_MIXED_RAW = new sbyte[30]
			{
				48, 49, 50, 51, 52, 53, 54, 55, 56, 57,
				38, 13, 9, 44, 58, 35, 45, 46, 36, 47,
				43, 37, 42, 61, 94, 0, 32, 0, 0, 0
			};
			TEXT_PUNCTUATION_RAW = new sbyte[30]
			{
				59, 60, 62, 64, 91, 92, 93, 95, 96, 126,
				33, 13, 9, 44, 58, 10, 45, 46, 36, 47,
				34, 124, 42, 40, 41, 63, 123, 125, 39, 0
			};
			MIXED = new sbyte[128];
			PUNCTUATION = new sbyte[128];
			DEFAULT_ENCODING_NAME = "ISO-8859-1";
			for (int i = 0; i < MIXED.Length; i++)
			{
				MIXED[i] = -1;
			}
			for (int j = 0; j < TEXT_MIXED_RAW.Length; j++)
			{
				sbyte b = TEXT_MIXED_RAW[j];
				if (b > 0)
				{
					MIXED[b] = (sbyte)j;
				}
			}
			for (int k = 0; k < PUNCTUATION.Length; k++)
			{
				PUNCTUATION[k] = -1;
			}
			for (int l = 0; l < TEXT_PUNCTUATION_RAW.Length; l++)
			{
				sbyte b2 = TEXT_PUNCTUATION_RAW[l];
				if (b2 > 0)
				{
					PUNCTUATION[b2] = (sbyte)l;
				}
			}
		}

		internal static string encodeHighLevel(string msg, Compaction compaction, Encoding encoding, bool disableEci)
		{
			StringBuilder stringBuilder = new StringBuilder(msg.Length);
			if (encoding != null && !disableEci && string.Compare(DEFAULT_ENCODING_NAME, encoding.WebName, StringComparison.Ordinal) != 0)
			{
				CharacterSetECI characterSetECIByName = CharacterSetECI.getCharacterSetECIByName(encoding.WebName);
				if (characterSetECIByName != null)
				{
					encodingECI(characterSetECIByName.Value, stringBuilder);
				}
			}
			int length = msg.Length;
			int num = 0;
			int initialSubmode = 0;
			switch (compaction)
			{
			case Compaction.TEXT:
				encodeText(msg, num, length, stringBuilder, initialSubmode);
				break;
			case Compaction.BYTE:
			{
				byte[] array2 = toBytes(msg, encoding);
				encodeBinary(array2, num, array2.Length, 1, stringBuilder);
				break;
			}
			case Compaction.NUMERIC:
				stringBuilder.Append('Ά');
				encodeNumeric(msg, num, length, stringBuilder);
				break;
			default:
			{
				int num2 = 0;
				byte[] array = null;
				while (num < length)
				{
					int num3 = determineConsecutiveDigitCount(msg, num);
					if (num3 >= 13)
					{
						stringBuilder.Append('Ά');
						num2 = 2;
						initialSubmode = 0;
						encodeNumeric(msg, num, num3, stringBuilder);
						num += num3;
						continue;
					}
					int num4 = determineConsecutiveTextCount(msg, num);
					if (num4 >= 5 || num3 == length)
					{
						if (num2 != 0)
						{
							stringBuilder.Append('\u0384');
							num2 = 0;
							initialSubmode = 0;
						}
						initialSubmode = encodeText(msg, num, num4, stringBuilder, initialSubmode);
						num += num4;
						continue;
					}
					if (array == null)
					{
						array = toBytes(msg, encoding);
					}
					int num5 = determineConsecutiveBinaryCount(msg, array, num, encoding);
					if (num5 == 0)
					{
						num5 = 1;
					}
					if (num5 == 1 && num2 == 0)
					{
						encodeBinary(array, 0, 1, 0, stringBuilder);
					}
					else
					{
						encodeBinary(array, toBytes(msg.Substring(0, num), encoding).Length, toBytes(msg.Substring(num, num5), encoding).Length, num2, stringBuilder);
						num2 = 1;
						initialSubmode = 0;
					}
					num += num5;
				}
				break;
			}
			}
			return stringBuilder.ToString();
		}

		private static Encoding getEncoder(Encoding encoding)
		{
			if (encoding == null)
			{
				try
				{
					encoding = Encoding.GetEncoding(DEFAULT_ENCODING_NAME);
				}
				catch (Exception)
				{
				}
				if (encoding == null)
				{
					try
					{
						encoding = Encoding.GetEncoding("UTF-8");
					}
					catch (Exception innerExc)
					{
						throw new WriterException("No support for any encoding: " + DEFAULT_ENCODING_NAME, innerExc);
					}
				}
			}
			return encoding;
		}

		private static byte[] toBytes(string msg, Encoding encoding)
		{
			return getEncoder(encoding).GetBytes(msg);
		}

		private static byte[] toBytes(char msg, Encoding encoding)
		{
			return getEncoder(encoding).GetBytes(new char[1] { msg });
		}

		private static int encodeText(string msg, int startpos, int count, StringBuilder sb, int initialSubmode)
		{
			StringBuilder stringBuilder = new StringBuilder(count);
			int num = initialSubmode;
			int num2 = 0;
			do
			{
				IL_000c:
				char c = msg[startpos + num2];
				switch (num)
				{
				case 0:
					if (isAlphaUpper(c))
					{
						if (c == ' ')
						{
							stringBuilder.Append('\u001a');
						}
						else
						{
							stringBuilder.Append((char)(c - 65));
						}
						break;
					}
					if (isAlphaLower(c))
					{
						num = 1;
						stringBuilder.Append('\u001b');
						goto IL_000c;
					}
					if (isMixed(c))
					{
						num = 2;
						stringBuilder.Append('\u001c');
						goto IL_000c;
					}
					stringBuilder.Append('\u001d');
					stringBuilder.Append((char)PUNCTUATION[(uint)c]);
					break;
				case 1:
					if (isAlphaLower(c))
					{
						if (c == ' ')
						{
							stringBuilder.Append('\u001a');
						}
						else
						{
							stringBuilder.Append((char)(c - 97));
						}
						break;
					}
					if (isAlphaUpper(c))
					{
						stringBuilder.Append('\u001b');
						stringBuilder.Append((char)(c - 65));
						break;
					}
					if (isMixed(c))
					{
						num = 2;
						stringBuilder.Append('\u001c');
						goto IL_000c;
					}
					stringBuilder.Append('\u001d');
					stringBuilder.Append((char)PUNCTUATION[(uint)c]);
					break;
				case 2:
					if (isMixed(c))
					{
						stringBuilder.Append((char)MIXED[(uint)c]);
						break;
					}
					if (isAlphaUpper(c))
					{
						num = 0;
						stringBuilder.Append('\u001c');
						goto IL_000c;
					}
					if (isAlphaLower(c))
					{
						num = 1;
						stringBuilder.Append('\u001b');
						goto IL_000c;
					}
					if (startpos + num2 + 1 < count && isPunctuation(msg[startpos + num2 + 1]))
					{
						num = 3;
						stringBuilder.Append('\u0019');
						goto IL_000c;
					}
					stringBuilder.Append('\u001d');
					stringBuilder.Append((char)PUNCTUATION[(uint)c]);
					break;
				default:
					if (isPunctuation(c))
					{
						stringBuilder.Append((char)PUNCTUATION[(uint)c]);
						break;
					}
					num = 0;
					stringBuilder.Append('\u001d');
					goto IL_000c;
				}
				num2++;
			}
			while (num2 < count);
			char c2 = '\0';
			int length = stringBuilder.Length;
			for (int i = 0; i < length; i++)
			{
				if (i % 2 != 0)
				{
					c2 = (char)(c2 * 30 + stringBuilder[i]);
					sb.Append(c2);
				}
				else
				{
					c2 = stringBuilder[i];
				}
			}
			if (length % 2 != 0)
			{
				sb.Append((char)(c2 * 30 + 29));
			}
			return num;
		}

		private static void encodeBinary(byte[] bytes, int startpos, int count, int startmode, StringBuilder sb)
		{
			if (count == 1 && startmode == 0)
			{
				sb.Append('Α');
			}
			else if (count % 6 == 0)
			{
				sb.Append('Μ');
			}
			else
			{
				sb.Append('\u0385');
			}
			int i = startpos;
			if (count >= 6)
			{
				char[] array = new char[5];
				for (; startpos + count - i >= 6; i += 6)
				{
					long num = 0L;
					for (int j = 0; j < 6; j++)
					{
						num <<= 8;
						num += bytes[i + j] & 0xFF;
					}
					for (int k = 0; k < 5; k++)
					{
						array[k] = (char)(num % 900);
						num /= 900;
					}
					for (int num2 = array.Length - 1; num2 >= 0; num2--)
					{
						sb.Append(array[num2]);
					}
				}
			}
			for (int l = i; l < startpos + count; l++)
			{
				int num3 = bytes[l] & 0xFF;
				sb.Append((char)num3);
			}
		}

		private static void encodeNumeric(string msg, int startpos, int count, StringBuilder sb)
		{
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder(count / 3 + 1);
			BigInteger b = new BigInteger(900L);
			BigInteger other = new BigInteger(0L);
			int num;
			for (; i < count - 1; i += num)
			{
				stringBuilder.Length = 0;
				num = Math.Min(44, count - i);
				BigInteger bigInteger = BigInteger.Parse("1" + msg.Substring(startpos + i, num));
				do
				{
					BigInteger bigInteger2 = BigInteger.Modulo(bigInteger, b);
					stringBuilder.Append((char)bigInteger2.GetHashCode());
					bigInteger = BigInteger.Division(bigInteger, b);
				}
				while (!bigInteger.Equals(other));
				for (int num2 = stringBuilder.Length - 1; num2 >= 0; num2--)
				{
					sb.Append(stringBuilder[num2]);
				}
			}
		}

		private static bool isDigit(char ch)
		{
			if (ch >= '0')
			{
				return ch <= '9';
			}
			return false;
		}

		private static bool isAlphaUpper(char ch)
		{
			if (ch != ' ')
			{
				if (ch >= 'A')
				{
					return ch <= 'Z';
				}
				return false;
			}
			return true;
		}

		private static bool isAlphaLower(char ch)
		{
			if (ch != ' ')
			{
				if (ch >= 'a')
				{
					return ch <= 'z';
				}
				return false;
			}
			return true;
		}

		private static bool isMixed(char ch)
		{
			return MIXED[(uint)ch] != -1;
		}

		private static bool isPunctuation(char ch)
		{
			return PUNCTUATION[(uint)ch] != -1;
		}

		private static bool isText(char ch)
		{
			if (ch != '\t' && ch != '\n' && ch != '\r')
			{
				if (ch >= ' ')
				{
					return ch <= '~';
				}
				return false;
			}
			return true;
		}

		private static int determineConsecutiveDigitCount(string msg, int startpos)
		{
			int num = 0;
			int length = msg.Length;
			int num2 = startpos;
			if (num2 < length)
			{
				char ch = msg[num2];
				while (isDigit(ch) && num2 < length)
				{
					num++;
					num2++;
					if (num2 < length)
					{
						ch = msg[num2];
					}
				}
			}
			return num;
		}

		private static int determineConsecutiveTextCount(string msg, int startpos)
		{
			int length = msg.Length;
			int num = startpos;
			while (num < length)
			{
				char ch = msg[num];
				int num2 = 0;
				while (num2 < 13 && isDigit(ch) && num < length)
				{
					num2++;
					num++;
					if (num < length)
					{
						ch = msg[num];
					}
				}
				if (num2 >= 13)
				{
					return num - startpos - num2;
				}
				if (num2 <= 0)
				{
					ch = msg[num];
					if (!isText(ch))
					{
						break;
					}
					num++;
				}
			}
			return num - startpos;
		}

		private static int determineConsecutiveBinaryCount(string msg, byte[] bytes, int startpos, Encoding encoding)
		{
			int length = msg.Length;
			int num = startpos;
			int num2 = num;
			encoding = getEncoder(encoding);
			while (num < length)
			{
				char ch = msg[num];
				int num3 = 0;
				while (num3 < 13 && isDigit(ch))
				{
					num3++;
					int num4 = num + num3;
					if (num4 >= length)
					{
						break;
					}
					ch = msg[num4];
				}
				if (num3 >= 13)
				{
					return num - startpos;
				}
				ch = msg[num];
				if (bytes[num2] == 63 && ch != '?')
				{
					throw new WriterException("Non-encodable character detected: " + ch.ToString() + " (Unicode: " + (int)ch + ")");
				}
				num++;
				num2++;
				if (toBytes(ch, encoding).Length > 1)
				{
					num2++;
				}
			}
			return num - startpos;
		}

		private static void encodingECI(int eci, StringBuilder sb)
		{
			if (eci >= 0 && eci < 900)
			{
				sb.Append('Ο');
				sb.Append((char)eci);
				return;
			}
			if (eci < 810900)
			{
				sb.Append('Ξ');
				sb.Append((char)(eci / 900 - 1));
				sb.Append((char)(eci % 900));
				return;
			}
			if (eci < 811800)
			{
				sb.Append('Ν');
				sb.Append((char)(810900 - eci));
				return;
			}
			throw new WriterException("ECI number not in valid range from 0..811799, but was " + eci);
		}
	}
}
namespace ZXing.PDF417.Internal.EC
{
	public sealed class ErrorCorrection
	{
		private readonly ModulusGF field;

		public ErrorCorrection()
		{
			field = ModulusGF.PDF417_GF;
		}

		public bool decode(int[] received, int numECCodewords, int[] erasures, out int errorLocationsCount)
		{
			ModulusPoly modulusPoly = new ModulusPoly(field, received);
			int[] array = new int[numECCodewords];
			bool flag = false;
			errorLocationsCount = 0;
			for (int num = numECCodewords; num > 0; num--)
			{
				if ((array[numECCodewords - num] = modulusPoly.evaluateAt(field.exp(num))) != 0)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return true;
			}
			ModulusPoly modulusPoly2 = field.One;
			if (erasures != null)
			{
				foreach (int num2 in erasures)
				{
					int b = field.exp(received.Length - 1 - num2);
					ModulusPoly other = new ModulusPoly(field, new int[2]
					{
						field.subtract(0, b),
						1
					});
					modulusPoly2 = modulusPoly2.multiply(other);
				}
			}
			ModulusPoly b2 = new ModulusPoly(field, array);
			ModulusPoly[] array2 = runEuclideanAlgorithm(field.buildMonomial(numECCodewords, 1), b2, numECCodewords);
			if (array2 == null)
			{
				return false;
			}
			ModulusPoly modulusPoly3 = array2[0];
			ModulusPoly modulusPoly4 = array2[1];
			if (modulusPoly3 == null || modulusPoly4 == null)
			{
				return false;
			}
			int[] array3 = findErrorLocations(modulusPoly3);
			if (array3 == null)
			{
				return false;
			}
			int[] array4 = findErrorMagnitudes(modulusPoly4, modulusPoly3, array3);
			for (int j = 0; j < array3.Length; j++)
			{
				int num3 = received.Length - 1 - field.log(array3[j]);
				if (num3 < 0)
				{
					return false;
				}
				received[num3] = field.subtract(received[num3], array4[j]);
			}
			errorLocationsCount = array3.Length;
			return true;
		}

		private ModulusPoly[] runEuclideanAlgorithm(ModulusPoly a, ModulusPoly b, int R)
		{
			if (a.Degree < b.Degree)
			{
				ModulusPoly modulusPoly = a;
				a = b;
				b = modulusPoly;
			}
			ModulusPoly modulusPoly2 = a;
			ModulusPoly modulusPoly3 = b;
			ModulusPoly modulusPoly4 = field.Zero;
			ModulusPoly modulusPoly5 = field.One;
			while (modulusPoly3.Degree >= R / 2)
			{
				ModulusPoly modulusPoly6 = modulusPoly2;
				ModulusPoly other = modulusPoly4;
				modulusPoly2 = modulusPoly3;
				modulusPoly4 = modulusPoly5;
				if (modulusPoly2.isZero)
				{
					return null;
				}
				modulusPoly3 = modulusPoly6;
				ModulusPoly modulusPoly7 = field.Zero;
				int coefficient = modulusPoly2.getCoefficient(modulusPoly2.Degree);
				int b2 = field.inverse(coefficient);
				while (modulusPoly3.Degree >= modulusPoly2.Degree && !modulusPoly3.isZero)
				{
					int degree = modulusPoly3.Degree - modulusPoly2.Degree;
					int coefficient2 = field.multiply(modulusPoly3.getCoefficient(modulusPoly3.Degree), b2);
					modulusPoly7 = modulusPoly7.add(field.buildMonomial(degree, coefficient2));
					modulusPoly3 = modulusPoly3.subtract(modulusPoly2.multiplyByMonomial(degree, coefficient2));
				}
				modulusPoly5 = modulusPoly7.multiply(modulusPoly4).subtract(other).getNegative();
			}
			int coefficient3 = modulusPoly5.getCoefficient(0);
			if (coefficient3 == 0)
			{
				return null;
			}
			int scalar = field.inverse(coefficient3);
			ModulusPoly modulusPoly8 = modulusPoly5.multiply(scalar);
			ModulusPoly modulusPoly9 = modulusPoly3.multiply(scalar);
			return new ModulusPoly[2] { modulusPoly8, modulusPoly9 };
		}

		private int[] findErrorLocations(ModulusPoly errorLocator)
		{
			int degree = errorLocator.Degree;
			int[] array = new int[degree];
			int num = 0;
			for (int i = 1; i < field.Size; i++)
			{
				if (num >= degree)
				{
					break;
				}
				if (errorLocator.evaluateAt(i) == 0)
				{
					array[num] = field.inverse(i);
					num++;
				}
			}
			if (num != degree)
			{
				return null;
			}
			return array;
		}

		private int[] findErrorMagnitudes(ModulusPoly errorEvaluator, ModulusPoly errorLocator, int[] errorLocations)
		{
			int degree = errorLocator.Degree;
			int[] array = new int[degree];
			for (int i = 1; i <= degree; i++)
			{
				array[degree - i] = field.multiply(i, errorLocator.getCoefficient(i));
			}
			ModulusPoly modulusPoly = new ModulusPoly(field, array);
			int num = errorLocations.Length;
			int[] array2 = new int[num];
			for (int j = 0; j < num; j++)
			{
				int a = field.inverse(errorLocations[j]);
				int a2 = field.subtract(0, errorEvaluator.evaluateAt(a));
				int b = field.inverse(modulusPoly.evaluateAt(a));
				array2[j] = field.multiply(a2, b);
			}
			return array2;
		}
	}
	internal sealed class ModulusGF
	{
		public static ModulusGF PDF417_GF = new ModulusGF(PDF417Common.NUMBER_OF_CODEWORDS, 3);

		private readonly int[] expTable;

		private readonly int[] logTable;

		private readonly int modulus;

		public ModulusPoly Zero { get; private set; }

		public ModulusPoly One { get; private set; }

		internal int Size => modulus;

		public ModulusGF(int modulus, int generator)
		{
			this.modulus = modulus;
			expTable = new int[modulus];
			logTable = new int[modulus];
			int num = 1;
			for (int i = 0; i < modulus; i++)
			{
				expTable[i] = num;
				num = num * generator % modulus;
			}
			for (int j = 0; j < modulus - 1; j++)
			{
				logTable[expTable[j]] = j;
			}
			Zero = new ModulusPoly(this, new int[1]);
			One = new ModulusPoly(this, new int[1] { 1 });
		}

		internal ModulusPoly buildMonomial(int degree, int coefficient)
		{
			if (degree < 0)
			{
				throw new ArgumentException();
			}
			if (coefficient == 0)
			{
				return Zero;
			}
			int[] array = new int[degree + 1];
			array[0] = coefficient;
			return new ModulusPoly(this, array);
		}

		internal int add(int a, int b)
		{
			return (a + b) % modulus;
		}

		internal int subtract(int a, int b)
		{
			return (modulus + a - b) % modulus;
		}

		internal int exp(int a)
		{
			return expTable[a];
		}

		internal int log(int a)
		{
			if (a == 0)
			{
				throw new ArgumentException();
			}
			return logTable[a];
		}

		internal int inverse(int a)
		{
			if (a == 0)
			{
				throw new ArithmeticException();
			}
			return expTable[modulus - logTable[a] - 1];
		}

		internal int multiply(int a, int b)
		{
			if (a == 0 || b == 0)
			{
				return 0;
			}
			return expTable[(logTable[a] + logTable[b]) % (modulus - 1)];
		}
	}
	internal sealed class ModulusPoly
	{
		private readonly ModulusGF field;

		private readonly int[] coefficients;

		internal int[] Coefficients => coefficients;

		internal int Degree => coefficients.Length - 1;

		internal bool isZero => coefficients[0] == 0;

		public ModulusPoly(ModulusGF field, int[] coefficients)
		{
			if (coefficients.Length == 0)
			{
				throw new ArgumentException();
			}
			this.field = field;
			int num = coefficients.Length;
			if (num > 1 && coefficients[0] == 0)
			{
				int i;
				for (i = 1; i < num && coefficients[i] == 0; i++)
				{
				}
				if (i == num)
				{
					this.coefficients = new int[1];
					return;
				}
				this.coefficients = new int[num - i];
				Array.Copy(coefficients, i, this.coefficients, 0, this.coefficients.Length);
			}
			else
			{
				this.coefficients = coefficients;
			}
		}

		internal int getCoefficient(int degree)
		{
			return coefficients[coefficients.Length - 1 - degree];
		}

		internal int evaluateAt(int a)
		{
			if (a == 0)
			{
				return getCoefficient(0);
			}
			int num = 0;
			if (a == 1)
			{
				int[] array = coefficients;
				foreach (int b in array)
				{
					num = field.add(num, b);
				}
				return num;
			}
			num = coefficients[0];
			int num2 = coefficients.Length;
			for (int j = 1; j < num2; j++)
			{
				num = field.add(field.multiply(a, num), coefficients[j]);
			}
			return num;
		}

		internal ModulusPoly add(ModulusPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("ModulusPolys do not have same ModulusGF field");
			}
			if (isZero)
			{
				return other;
			}
			if (other.isZero)
			{
				return this;
			}
			int[] array = coefficients;
			int[] array2 = other.coefficients;
			if (array.Length > array2.Length)
			{
				int[] array3 = array;
				array = array2;
				array2 = array3;
			}
			int[] array4 = new int[array2.Length];
			int num = array2.Length - array.Length;
			Array.Copy(array2, 0, array4, 0, num);
			for (int i = num; i < array2.Length; i++)
			{
				array4[i] = field.add(array[i - num], array2[i]);
			}
			return new ModulusPoly(field, array4);
		}

		internal ModulusPoly subtract(ModulusPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("ModulusPolys do not have same ModulusGF field");
			}
			if (other.isZero)
			{
				return this;
			}
			return add(other.getNegative());
		}

		internal ModulusPoly multiply(ModulusPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("ModulusPolys do not have same ModulusGF field");
			}
			if (isZero || other.isZero)
			{
				return field.Zero;
			}
			int[] array = coefficients;
			int num = array.Length;
			int[] array2 = other.coefficients;
			int num2 = array2.Length;
			int[] array3 = new int[num + num2 - 1];
			for (int i = 0; i < num; i++)
			{
				int a = array[i];
				for (int j = 0; j < num2; j++)
				{
					array3[i + j] = field.add(array3[i + j], field.multiply(a, array2[j]));
				}
			}
			return new ModulusPoly(field, array3);
		}

		internal ModulusPoly getNegative()
		{
			int num = coefficients.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = field.subtract(0, coefficients[i]);
			}
			return new ModulusPoly(field, array);
		}

		internal ModulusPoly multiply(int scalar)
		{
			switch (scalar)
			{
			case 0:
				return field.Zero;
			case 1:
				return this;
			default:
			{
				int num = coefficients.Length;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = field.multiply(coefficients[i], scalar);
				}
				return new ModulusPoly(field, array);
			}
			}
		}

		internal ModulusPoly multiplyByMonomial(int degree, int coefficient)
		{
			if (degree < 0)
			{
				throw new ArgumentException();
			}
			if (coefficient == 0)
			{
				return field.Zero;
			}
			int num = coefficients.Length;
			int[] array = new int[num + degree];
			for (int i = 0; i < num; i++)
			{
				array[i] = field.multiply(coefficients[i], coefficient);
			}
			return new ModulusPoly(field, array);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(8 * Degree);
			for (int num = Degree; num >= 0; num--)
			{
				int num2 = getCoefficient(num);
				if (num2 != 0)
				{
					if (num2 < 0)
					{
						stringBuilder.Append(" - ");
						num2 = -num2;
					}
					else if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" + ");
					}
					if (num == 0 || num2 != 1)
					{
						stringBuilder.Append(num2);
					}
					switch (num)
					{
					case 1:
						stringBuilder.Append('x');
						break;
					default:
						stringBuilder.Append("x^");
						stringBuilder.Append(num);
						break;
					case 0:
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
namespace ZXing.OneD
{
	public sealed class CodaBarReader : OneDReader
	{
		private static readonly int MAX_ACCEPTABLE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 2f);

		private static readonly int PADDING = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 1.5f);

		private const string ALPHABET_STRING = "0123456789-$:/.+ABCD";

		internal static readonly char[] ALPHABET = "0123456789-$:/.+ABCD".ToCharArray();

		internal static int[] CHARACTER_ENCODINGS = new int[20]
		{
			3, 6, 9, 96, 18, 66, 33, 36, 48, 72,
			12, 24, 69, 81, 84, 21, 26, 41, 11, 14
		};

		private const int MIN_CHARACTER_LENGTH = 3;

		private static readonly char[] STARTEND_ENCODING = new char[4] { 'A', 'B', 'C', 'D' };

		private readonly StringBuilder decodeRowResult;

		private int[] counters;

		private int counterLength;

		public CodaBarReader()
		{
			decodeRowResult = new StringBuilder(20);
			counters = new int[80];
			counterLength = 0;
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			for (int i = 0; i < counters.Length; i++)
			{
				counters[i] = 0;
			}
			if (!setCounters(row))
			{
				return null;
			}
			int num = findStartPattern();
			if (num < 0)
			{
				return null;
			}
			int num2 = num;
			decodeRowResult.Length = 0;
			int num3;
			do
			{
				num3 = toNarrowWidePattern(num2);
				if (num3 == -1)
				{
					return null;
				}
				decodeRowResult.Append((char)num3);
				num2 += 8;
			}
			while ((decodeRowResult.Length <= 1 || !arrayContains(STARTEND_ENCODING, ALPHABET[num3])) && num2 < counterLength);
			int num4 = counters[num2 - 1];
			int num5 = 0;
			for (int j = -8; j < -1; j++)
			{
				num5 += counters[num2 + j];
			}
			if (num2 < counterLength && num4 < num5 / 2)
			{
				return null;
			}
			if (!validatePattern(num))
			{
				return null;
			}
			for (int k = 0; k < decodeRowResult.Length; k++)
			{
				decodeRowResult[k] = ALPHABET[(uint)decodeRowResult[k]];
			}
			char key = decodeRowResult[0];
			if (!arrayContains(STARTEND_ENCODING, key))
			{
				return null;
			}
			char key2 = decodeRowResult[decodeRowResult.Length - 1];
			if (!arrayContains(STARTEND_ENCODING, key2))
			{
				return null;
			}
			if (decodeRowResult.Length <= 3)
			{
				return null;
			}
			if (!SupportClass.GetValue(hints, DecodeHintType.RETURN_CODABAR_START_END, @default: false))
			{
				decodeRowResult.Remove(decodeRowResult.Length - 1, 1);
				decodeRowResult.Remove(0, 1);
			}
			int num6 = 0;
			for (int l = 0; l < num; l++)
			{
				num6 += counters[l];
			}
			float x = num6;
			for (int m = num; m < num2 - 1; m++)
			{
				num6 += counters[m];
			}
			float x2 = num6;
			ResultPointCallback value = SupportClass.GetValue<ResultPointCallback>(hints, DecodeHintType.NEED_RESULT_POINT_CALLBACK, null);
			if (value != null)
			{
				value(new ResultPoint(x, rowNumber));
				value(new ResultPoint(x2, rowNumber));
			}
			return new Result(decodeRowResult.ToString(), null, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, BarcodeFormat.CODABAR);
		}

		private bool validatePattern(int start)
		{
			int[] array = new int[4];
			int[] array2 = new int[4];
			int num = decodeRowResult.Length - 1;
			int num2 = start;
			int num3 = 0;
			while (true)
			{
				int num4 = CHARACTER_ENCODINGS[(uint)decodeRowResult[num3]];
				for (int num5 = 6; num5 >= 0; num5--)
				{
					int num6 = (num5 & 1) + (num4 & 1) * 2;
					array[num6] += counters[num2 + num5];
					array2[num6]++;
					num4 >>= 1;
				}
				if (num3 >= num)
				{
					break;
				}
				num2 += 8;
				num3++;
			}
			int[] array3 = new int[4];
			int[] array4 = new int[4];
			for (int i = 0; i < 2; i++)
			{
				array4[i] = 0;
				array4[i + 2] = (array[i] << OneDReader.INTEGER_MATH_SHIFT) / array2[i] + (array[i + 2] << OneDReader.INTEGER_MATH_SHIFT) / array2[i + 2] >> 1;
				array3[i] = array4[i + 2];
				array3[i + 2] = (array[i + 2] * MAX_ACCEPTABLE + PADDING) / array2[i + 2];
			}
			num2 = start;
			int num7 = 0;
			while (true)
			{
				int num8 = CHARACTER_ENCODINGS[(uint)decodeRowResult[num7]];
				for (int num9 = 6; num9 >= 0; num9--)
				{
					int num10 = (num9 & 1) + (num8 & 1) * 2;
					int num11 = counters[num2 + num9] << OneDReader.INTEGER_MATH_SHIFT;
					if (num11 < array4[num10] || num11 > array3[num10])
					{
						return false;
					}
					num8 >>= 1;
				}
				if (num7 >= num)
				{
					break;
				}
				num2 += 8;
				num7++;
			}
			return true;
		}

		private bool setCounters(ZXing.Common.BitArray row)
		{
			counterLength = 0;
			int i = row.getNextUnset(0);
			int size = row.Size;
			if (i >= size)
			{
				return false;
			}
			bool flag = true;
			int num = 0;
			for (; i < size; i++)
			{
				if (row[i] != flag)
				{
					num++;
					continue;
				}
				counterAppend(num);
				num = 1;
				flag = !flag;
			}
			counterAppend(num);
			return true;
		}

		private void counterAppend(int e)
		{
			counters[counterLength] = e;
			counterLength++;
			if (counterLength >= counters.Length)
			{
				int[] destinationArray = new int[counterLength * 2];
				Array.Copy(counters, 0, destinationArray, 0, counterLength);
				counters = destinationArray;
			}
		}

		private int findStartPattern()
		{
			for (int i = 1; i < counterLength; i += 2)
			{
				int num = toNarrowWidePattern(i);
				if (num != -1 && arrayContains(STARTEND_ENCODING, ALPHABET[num]))
				{
					int num2 = 0;
					for (int j = i; j < i + 7; j++)
					{
						num2 += counters[j];
					}
					if (i == 1 || counters[i - 1] >= num2 / 2)
					{
						return i;
					}
				}
			}
			return -1;
		}

		internal static bool arrayContains(char[] array, char key)
		{
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == key)
					{
						return true;
					}
				}
			}
			return false;
		}

		private int toNarrowWidePattern(int position)
		{
			int num = position + 7;
			if (num >= counterLength)
			{
				return -1;
			}
			int[] array = counters;
			int num2 = 0;
			int num3 = 2147483647;
			for (int i = position; i < num; i += 2)
			{
				int num4 = array[i];
				if (num4 < num3)
				{
					num3 = num4;
				}
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
			int num5 = (num3 + num2) / 2;
			int num6 = 0;
			int num7 = 2147483647;
			for (int j = position + 1; j < num; j += 2)
			{
				int num8 = array[j];
				if (num8 < num7)
				{
					num7 = num8;
				}
				if (num8 > num6)
				{
					num6 = num8;
				}
			}
			int num9 = (num7 + num6) / 2;
			int num10 = 128;
			int num11 = 0;
			for (int k = 0; k < 7; k++)
			{
				int num12 = (((k & 1) == 0) ? num5 : num9);
				num10 >>= 1;
				if (array[position + k] > num12)
				{
					num11 |= num10;
				}
			}
			for (int l = 0; l < CHARACTER_ENCODINGS.Length; l++)
			{
				if (CHARACTER_ENCODINGS[l] == num11)
				{
					return l;
				}
			}
			return -1;
		}
	}
	public sealed class CodaBarWriter : OneDimensionalCodeWriter
	{
		private static readonly char[] START_END_CHARS = new char[4] { 'A', 'B', 'C', 'D' };

		private static readonly char[] ALT_START_END_CHARS = new char[4] { 'T', 'N', '*', 'E' };

		private static readonly char[] CHARS_WHICH_ARE_TEN_LENGTH_EACH_AFTER_DECODED = new char[4] { '/', ':', '+', '.' };

		private static readonly char DEFAULT_GUARD = START_END_CHARS[0];

		public override bool[] encode(string contents)
		{
			if (contents.Length < 2)
			{
				char dEFAULT_GUARD = DEFAULT_GUARD;
				string text = dEFAULT_GUARD.ToString();
				string text2 = contents;
				dEFAULT_GUARD = DEFAULT_GUARD;
				contents = text + text2 + dEFAULT_GUARD;
			}
			else
			{
				char key = char.ToUpper(contents[0]);
				char key2 = char.ToUpper(contents[contents.Length - 1]);
				bool num = CodaBarReader.arrayContains(START_END_CHARS, key);
				bool flag = CodaBarReader.arrayContains(START_END_CHARS, key2);
				bool flag2 = CodaBarReader.arrayContains(ALT_START_END_CHARS, key);
				bool flag3 = CodaBarReader.arrayContains(ALT_START_END_CHARS, key2);
				if (num)
				{
					if (!flag)
					{
						throw new ArgumentException("Invalid start/end guards: " + contents);
					}
				}
				else if (flag2)
				{
					if (!flag3)
					{
						throw new ArgumentException("Invalid start/end guards: " + contents);
					}
				}
				else
				{
					if (flag || flag3)
					{
						throw new ArgumentException("Invalid start/end guards: " + contents);
					}
					char dEFAULT_GUARD = DEFAULT_GUARD;
					string text3 = dEFAULT_GUARD.ToString();
					string text4 = contents;
					dEFAULT_GUARD = DEFAULT_GUARD;
					contents = text3 + text4 + dEFAULT_GUARD;
				}
			}
			int num2 = 20;
			for (int i = 1; i < contents.Length - 1; i++)
			{
				if (char.IsDigit(contents[i]) || contents[i] == '-' || contents[i] == '$')
				{
					num2 += 9;
					continue;
				}
				if (CodaBarReader.arrayContains(CHARS_WHICH_ARE_TEN_LENGTH_EACH_AFTER_DECODED, contents[i]))
				{
					num2 += 10;
					continue;
				}
				throw new ArgumentException("Cannot encode : '" + contents[i] + "'");
			}
			num2 += contents.Length - 1;
			bool[] array = new bool[num2];
			int num3 = 0;
			for (int j = 0; j < contents.Length; j++)
			{
				char c = char.ToUpper(contents[j]);
				if (j == 0 || j == contents.Length - 1)
				{
					switch (c)
					{
					case 'T':
						c = 'A';
						break;
					case 'N':
						c = 'B';
						break;
					case '*':
						c = 'C';
						break;
					case 'E':
						c = 'D';
						break;
					}
				}
				int num4 = 0;
				for (int k = 0; k < CodaBarReader.ALPHABET.Length; k++)
				{
					if (c == CodaBarReader.ALPHABET[k])
					{
						num4 = CodaBarReader.CHARACTER_ENCODINGS[k];
						break;
					}
				}
				bool flag4 = true;
				int num5 = 0;
				int num6 = 0;
				while (num6 < 7)
				{
					array[num3] = flag4;
					num3++;
					if (((num4 >> 6 - num6) & 1) == 0 || num5 == 1)
					{
						flag4 = !flag4;
						num6++;
						num5 = 0;
					}
					else
					{
						num5++;
					}
				}
				if (j < contents.Length - 1)
				{
					array[num3] = false;
					num3++;
				}
			}
			return array;
		}
	}
	[Serializable]
	public class Code128EncodingOptions : EncodingOptions
	{
		public bool ForceCodesetB
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.CODE128_FORCE_CODESET_B))
				{
					return (bool)base.Hints[EncodeHintType.CODE128_FORCE_CODESET_B];
				}
				return false;
			}
			set
			{
				base.Hints[EncodeHintType.CODE128_FORCE_CODESET_B] = value;
			}
		}
	}
	public sealed class Code128Reader : OneDReader
	{
		internal static int[][] CODE_PATTERNS = new int[107][]
		{
			new int[6] { 2, 1, 2, 2, 2, 2 },
			new int[6] { 2, 2, 2, 1, 2, 2 },
			new int[6] { 2, 2, 2, 2, 2, 1 },
			new int[6] { 1, 2, 1, 2, 2, 3 },
			new int[6] { 1, 2, 1, 3, 2, 2 },
			new int[6] { 1, 3, 1, 2, 2, 2 },
			new int[6] { 1, 2, 2, 2, 1, 3 },
			new int[6] { 1, 2, 2, 3, 1, 2 },
			new int[6] { 1, 3, 2, 2, 1, 2 },
			new int[6] { 2, 2, 1, 2, 1, 3 },
			new int[6] { 2, 2, 1, 3, 1, 2 },
			new int[6] { 2, 3, 1, 2, 1, 2 },
			new int[6] { 1, 1, 2, 2, 3, 2 },
			new int[6] { 1, 2, 2, 1, 3, 2 },
			new int[6] { 1, 2, 2, 2, 3, 1 },
			new int[6] { 1, 1, 3, 2, 2, 2 },
			new int[6] { 1, 2, 3, 1, 2, 2 },
			new int[6] { 1, 2, 3, 2, 2, 1 },
			new int[6] { 2, 2, 3, 2, 1, 1 },
			new int[6] { 2, 2, 1, 1, 3, 2 },
			new int[6] { 2, 2, 1, 2, 3, 1 },
			new int[6] { 2, 1, 3, 2, 1, 2 },
			new int[6] { 2, 2, 3, 1, 1, 2 },
			new int[6] { 3, 1, 2, 1, 3, 1 },
			new int[6] { 3, 1, 1, 2, 2, 2 },
			new int[6] { 3, 2, 1, 1, 2, 2 },
			new int[6] { 3, 2, 1, 2, 2, 1 },
			new int[6] { 3, 1, 2, 2, 1, 2 },
			new int[6] { 3, 2, 2, 1, 1, 2 },
			new int[6] { 3, 2, 2, 2, 1, 1 },
			new int[6] { 2, 1, 2, 1, 2, 3 },
			new int[6] { 2, 1, 2, 3, 2, 1 },
			new int[6] { 2, 3, 2, 1, 2, 1 },
			new int[6] { 1, 1, 1, 3, 2, 3 },
			new int[6] { 1, 3, 1, 1, 2, 3 },
			new int[6] { 1, 3, 1, 3, 2, 1 },
			new int[6] { 1, 1, 2, 3, 1, 3 },
			new int[6] { 1, 3, 2, 1, 1, 3 },
			new int[6] { 1, 3, 2, 3, 1, 1 },
			new int[6] { 2, 1, 1, 3, 1, 3 },
			new int[6] { 2, 3, 1, 1, 1, 3 },
			new int[6] { 2, 3, 1, 3, 1, 1 },
			new int[6] { 1, 1, 2, 1, 3, 3 },
			new int[6] { 1, 1, 2, 3, 3, 1 },
			new int[6] { 1, 3, 2, 1, 3, 1 },
			new int[6] { 1, 1, 3, 1, 2, 3 },
			new int[6] { 1, 1, 3, 3, 2, 1 },
			new int[6] { 1, 3, 3, 1, 2, 1 },
			new int[6] { 3, 1, 3, 1, 2, 1 },
			new int[6] { 2, 1, 1, 3, 3, 1 },
			new int[6] { 2, 3, 1, 1, 3, 1 },
			new int[6] { 2, 1, 3, 1, 1, 3 },
			new int[6] { 2, 1, 3, 3, 1, 1 },
			new int[6] { 2, 1, 3, 1, 3, 1 },
			new int[6] { 3, 1, 1, 1, 2, 3 },
			new int[6] { 3, 1, 1, 3, 2, 1 },
			new int[6] { 3, 3, 1, 1, 2, 1 },
			new int[6] { 3, 1, 2, 1, 1, 3 },
			new int[6] { 3, 1, 2, 3, 1, 1 },
			new int[6] { 3, 3, 2, 1, 1, 1 },
			new int[6] { 3, 1, 4, 1, 1, 1 },
			new int[6] { 2, 2, 1, 4, 1, 1 },
			new int[6] { 4, 3, 1, 1, 1, 1 },
			new int[6] { 1, 1, 1, 2, 2, 4 },
			new int[6] { 1, 1, 1, 4, 2, 2 },
			new int[6] { 1, 2, 1, 1, 2, 4 },
			new int[6] { 1, 2, 1, 4, 2, 1 },
			new int[6] { 1, 4, 1, 1, 2, 2 },
			new int[6] { 1, 4, 1, 2, 2, 1 },
			new int[6] { 1, 1, 2, 2, 1, 4 },
			new int[6] { 1, 1, 2, 4, 1, 2 },
			new int[6] { 1, 2, 2, 1, 1, 4 },
			new int[6] { 1, 2, 2, 4, 1, 1 },
			new int[6] { 1, 4, 2, 1, 1, 2 },
			new int[6] { 1, 4, 2, 2, 1, 1 },
			new int[6] { 2, 4, 1, 2, 1, 1 },
			new int[6] { 2, 2, 1, 1, 1, 4 },
			new int[6] { 4, 1, 3, 1, 1, 1 },
			new int[6] { 2, 4, 1, 1, 1, 2 },
			new int[6] { 1, 3, 4, 1, 1, 1 },
			new int[6] { 1, 1, 1, 2, 4, 2 },
			new int[6] { 1, 2, 1, 1, 4, 2 },
			new int[6] { 1, 2, 1, 2, 4, 1 },
			new int[6] { 1, 1, 4, 2, 1, 2 },
			new int[6] { 1, 2, 4, 1, 1, 2 },
			new int[6] { 1, 2, 4, 2, 1, 1 },
			new int[6] { 4, 1, 1, 2, 1, 2 },
			new int[6] { 4, 2, 1, 1, 1, 2 },
			new int[6] { 4, 2, 1, 2, 1, 1 },
			new int[6] { 2, 1, 2, 1, 4, 1 },
			new int[6] { 2, 1, 4, 1, 2, 1 },
			new int[6] { 4, 1, 2, 1, 2, 1 },
			new int[6] { 1, 1, 1, 1, 4, 3 },
			new int[6] { 1, 1, 1, 3, 4, 1 },
			new int[6] { 1, 3, 1, 1, 4, 1 },
			new int[6] { 1, 1, 4, 1, 1, 3 },
			new int[6] { 1, 1, 4, 3, 1, 1 },
			new int[6] { 4, 1, 1, 1, 1, 3 },
			new int[6] { 4, 1, 1, 3, 1, 1 },
			new int[6] { 1, 1, 3, 1, 4, 1 },
			new int[6] { 1, 1, 4, 1, 3, 1 },
			new int[6] { 3, 1, 1, 1, 4, 1 },
			new int[6] { 4, 1, 1, 1, 3, 1 },
			new int[6] { 2, 1, 1, 4, 1, 2 },
			new int[6] { 2, 1, 1, 2, 1, 4 },
			new int[6] { 2, 1, 1, 2, 3, 2 },
			new int[7] { 2, 3, 3, 1, 1, 1, 2 }
		};

		private static readonly int MAX_AVG_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.25f);

		private static readonly int MAX_INDIVIDUAL_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.7f);

		private const int CODE_SHIFT = 98;

		private const int CODE_CODE_C = 99;

		private const int CODE_CODE_B = 100;

		private const int CODE_CODE_A = 101;

		private const int CODE_FNC_1 = 102;

		private const int CODE_FNC_2 = 97;

		private const int CODE_FNC_3 = 96;

		private const int CODE_FNC_4_A = 101;

		private const int CODE_FNC_4_B = 100;

		private const int CODE_START_A = 103;

		private const int CODE_START_B = 104;

		private const int CODE_START_C = 105;

		private const int CODE_STOP = 106;

		private static int[] findStartPattern(ZXing.Common.BitArray row)
		{
			int size = row.Size;
			int nextSet = row.getNextSet(0);
			int num = 0;
			int[] array = new int[6];
			int num2 = nextSet;
			bool flag = false;
			int num3 = array.Length;
			for (int i = nextSet; i < size; i++)
			{
				if (row[i] != flag)
				{
					array[num]++;
					continue;
				}
				if (num == num3 - 1)
				{
					int num4 = MAX_AVG_VARIANCE;
					int num5 = -1;
					for (int j = 103; j <= 105; j++)
					{
						int num6 = OneDReader.patternMatchVariance(array, CODE_PATTERNS[j], MAX_INDIVIDUAL_VARIANCE);
						if (num6 < num4)
						{
							num4 = num6;
							num5 = j;
						}
					}
					if (num5 >= 0 && row.isRange(Math.Max(0, num2 - (i - num2) / 2), num2, value: false))
					{
						return new int[3] { num2, i, num5 };
					}
					num2 += array[0] + array[1];
					Array.Copy(array, 2, array, 0, num - 1);
					array[num - 1] = 0;
					array[num] = 0;
					num--;
				}
				else
				{
					num++;
				}
				array[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private static bool decodeCode(ZXing.Common.BitArray row, int[] counters, int rowOffset, out int code)
		{
			code = -1;
			if (!OneDReader.recordPattern(row, rowOffset, counters))
			{
				return false;
			}
			int num = MAX_AVG_VARIANCE;
			for (int i = 0; i < CODE_PATTERNS.Length; i++)
			{
				int[] pattern = CODE_PATTERNS[i];
				int num2 = OneDReader.patternMatchVariance(counters, pattern, MAX_INDIVIDUAL_VARIANCE);
				if (num2 < num)
				{
					num = num2;
					code = i;
				}
			}
			return code >= 0;
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			bool flag = hints?.ContainsKey(DecodeHintType.ASSUME_GS1) ?? false;
			int[] array = findStartPattern(row);
			if (array == null)
			{
				return null;
			}
			int num = array[2];
			List<byte> list = new List<byte>(20);
			list.Add((byte)num);
			int num2;
			switch (num)
			{
			case 103:
				num2 = 101;
				break;
			case 104:
				num2 = 100;
				break;
			case 105:
				num2 = 99;
				break;
			default:
				return null;
			}
			bool flag2 = false;
			bool flag3 = false;
			StringBuilder stringBuilder = new StringBuilder(20);
			int num3 = array[0];
			int num4 = array[1];
			int[] array2 = new int[6];
			int num5 = 0;
			int code = 0;
			int num6 = num;
			int num7 = 0;
			bool flag4 = true;
			bool flag5 = false;
			bool flag6 = false;
			while (!flag2)
			{
				bool flag7 = flag3;
				flag3 = false;
				num5 = code;
				if (!decodeCode(row, array2, num4, out code))
				{
					return null;
				}
				list.Add((byte)code);
				if (code != 106)
				{
					flag4 = true;
				}
				if (code != 106)
				{
					num7++;
					num6 += num7 * code;
				}
				num3 = num4;
				int[] array3 = array2;
				foreach (int num8 in array3)
				{
					num4 += num8;
				}
				if ((uint)(code - 103) <= 2u)
				{
					return null;
				}
				switch (num2)
				{
				case 101:
					if (code < 64)
					{
						if (flag6 == flag5)
						{
							stringBuilder.Append((char)(32 + code));
						}
						else
						{
							stringBuilder.Append((char)(32 + code + 128));
						}
						flag6 = false;
						break;
					}
					if (code < 96)
					{
						if (flag6 == flag5)
						{
							stringBuilder.Append((char)(code - 64));
						}
						else
						{
							stringBuilder.Append((char)(code + 64));
						}
						flag6 = false;
						break;
					}
					if (code != 106)
					{
						flag4 = false;
					}
					switch (code)
					{
					case 102:
						if (flag)
						{
							if (stringBuilder.Length == 0)
							{
								stringBuilder.Append("]C1");
							}
							else
							{
								stringBuilder.Append('\u001d');
							}
						}
						break;
					case 101:
						if (!flag5 && flag6)
						{
							flag5 = true;
							flag6 = false;
						}
						else if (flag5 && flag6)
						{
							flag5 = false;
							flag6 = false;
						}
						else
						{
							flag6 = true;
						}
						break;
					case 98:
						flag3 = true;
						num2 = 100;
						break;
					case 100:
						num2 = 100;
						break;
					case 99:
						num2 = 99;
						break;
					case 106:
						flag2 = true;
						break;
					}
					break;
				case 100:
					if (code < 96)
					{
						if (flag6 == flag5)
						{
							stringBuilder.Append((char)(32 + code));
						}
						else
						{
							stringBuilder.Append((char)(32 + code + 128));
						}
						flag6 = false;
						break;
					}
					if (code != 106)
					{
						flag4 = false;
					}
					switch (code)
					{
					case 102:
						if (flag)
						{
							if (stringBuilder.Length == 0)
							{
								stringBuilder.Append("]C1");
							}
							else
							{
								stringBuilder.Append('\u001d');
							}
						}
						break;
					case 100:
						if (!flag5 && flag6)
						{
							flag5 = true;
							flag6 = false;
						}
						else if (flag5 && flag6)
						{
							flag5 = false;
							flag6 = false;
						}
						else
						{
							flag6 = true;
						}
						break;
					case 98:
						flag3 = true;
						num2 = 101;
						break;
					case 101:
						num2 = 101;
						break;
					case 99:
						num2 = 99;
						break;
					case 106:
						flag2 = true;
						break;
					}
					break;
				case 99:
					if (code < 100)
					{
						if (code < 10)
						{
							stringBuilder.Append('0');
						}
						stringBuilder.Append(code);
						break;
					}
					if (code != 106)
					{
						flag4 = false;
					}
					switch (code)
					{
					case 102:
						if (flag)
						{
							if (stringBuilder.Length == 0)
							{
								stringBuilder.Append("]C1");
							}
							else
							{
								stringBuilder.Append('\u001d');
							}
						}
						break;
					case 101:
						num2 = 101;
						break;
					case 100:
						num2 = 100;
						break;
					case 106:
						flag2 = true;
						break;
					}
					break;
				}
				if (flag7)
				{
					num2 = ((num2 == 101) ? 100 : 101);
				}
			}
			int num9 = num4 - num3;
			num4 = row.getNextUnset(num4);
			if (!row.isRange(num4, Math.Min(row.Size, num4 + (num4 - num3) / 2), value: false))
			{
				return null;
			}
			num6 -= num7 * num5;
			if (num6 % 103 != num5)
			{
				return null;
			}
			int length = stringBuilder.Length;
			if (length == 0)
			{
				return null;
			}
			if (length > 0 && flag4)
			{
				if (num2 == 99)
				{
					stringBuilder.Remove(length - 2, 2);
				}
				else
				{
					stringBuilder.Remove(length - 1, 1);
				}
			}
			float x = (float)(array[1] + array[0]) / 2f;
			float x2 = (float)num3 + (float)num9 / 2f;
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(x, rowNumber));
				resultPointCallback(new ResultPoint(x2, rowNumber));
			}
			int count = list.Count;
			byte[] array4 = new byte[count];
			for (int j = 0; j < count; j++)
			{
				array4[j] = list[j];
			}
			return new Result(stringBuilder.ToString(), array4, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, BarcodeFormat.CODE_128);
		}
	}
	public sealed class Code128Writer : OneDimensionalCodeWriter
	{
		private enum CType
		{
			UNCODABLE,
			ONE_DIGIT,
			TWO_DIGITS,
			FNC_1
		}

		private const int CODE_START_A = 103;

		private const int CODE_START_B = 104;

		private const int CODE_START_C = 105;

		private const int CODE_CODE_A = 101;

		private const int CODE_CODE_B = 100;

		private const int CODE_CODE_C = 99;

		private const int CODE_STOP = 106;

		private const char ESCAPE_FNC_1 = 'ñ';

		private const char ESCAPE_FNC_2 = 'ò';

		private const char ESCAPE_FNC_3 = 'ó';

		private const char ESCAPE_FNC_4 = 'ô';

		private const int CODE_FNC_1 = 102;

		private const int CODE_FNC_2 = 97;

		private const int CODE_FNC_3 = 96;

		private const int CODE_FNC_4_A = 101;

		private const int CODE_FNC_4_B = 100;

		private bool forceCodesetB;

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.CODE_128)
			{
				throw new ArgumentException("Can only encode CODE_128, but got " + format);
			}
			forceCodesetB = hints != null && hints.ContainsKey(EncodeHintType.CODE128_FORCE_CODESET_B) && hints[EncodeHintType.CODE128_FORCE_CODESET_B] != null && Convert.ToBoolean(hints[EncodeHintType.CODE128_FORCE_CODESET_B].ToString());
			if (hints != null && hints.ContainsKey(EncodeHintType.GS1_FORMAT) && hints[EncodeHintType.GS1_FORMAT] != null && Convert.ToBoolean(hints[EncodeHintType.GS1_FORMAT].ToString()) && !string.IsNullOrEmpty(contents) && contents[0] != 'ñ')
			{
				contents = "ñ" + contents;
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			if (length < 1 || length > 80)
			{
				throw new ArgumentException("Contents length should be between 1 and 80 characters, but got " + length);
			}
			for (int i = 0; i < length; i++)
			{
				char c = contents[i];
				switch (c)
				{
				case 'ñ':
				case 'ò':
				case 'ó':
				case 'ô':
					continue;
				}
				if (c > '\u007f')
				{
					throw new ArgumentException("Bad character in input: " + c);
				}
			}
			List<int[]> list = new List<int[]>();
			int num = 0;
			int num2 = 1;
			int num3 = 0;
			int num4 = 0;
			while (num4 < length)
			{
				int num5 = chooseCode(contents, num4, num3);
				int num6;
				if (num5 == num3)
				{
					switch (contents[num4])
					{
					case 'ñ':
						num6 = 102;
						break;
					case 'ò':
						num6 = 97;
						break;
					case 'ó':
						num6 = 96;
						break;
					case 'ô':
						num6 = ((num5 != 101) ? 100 : 101);
						break;
					default:
						switch (num3)
						{
						case 101:
							num6 = contents[num4] - 32;
							if (num6 < 0)
							{
								num6 += 96;
							}
							break;
						case 100:
							num6 = contents[num4] - 32;
							break;
						default:
							num6 = int.Parse(contents.Substring(num4, 2));
							num4++;
							break;
						}
						break;
					}
					num4++;
				}
				else
				{
					num6 = ((num3 != 0) ? num5 : (num5 switch
					{
						101 => 103, 
						100 => 104, 
						_ => 105, 
					}));
					num3 = num5;
				}
				list.Add(Code128Reader.CODE_PATTERNS[num6]);
				num += num6 * num2;
				if (num4 != 0)
				{
					num2++;
				}
			}
			num %= 103;
			list.Add(Code128Reader.CODE_PATTERNS[num]);
			list.Add(Code128Reader.CODE_PATTERNS[106]);
			int num7 = 0;
			foreach (int[] item in list)
			{
				foreach (int num8 in item)
				{
					num7 += num8;
				}
			}
			bool[] array = new bool[num7];
			int num9 = 0;
			foreach (int[] item2 in list)
			{
				num9 += OneDimensionalCodeWriter.appendPattern(array, num9, item2, startColor: true);
			}
			return array;
		}

		private static CType findCType(string value, int start)
		{
			int length = value.Length;
			if (start >= length)
			{
				return CType.UNCODABLE;
			}
			switch (value[start])
			{
			case 'ñ':
				return CType.FNC_1;
			default:
				return CType.UNCODABLE;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			{
				if (start + 1 >= length)
				{
					return CType.ONE_DIGIT;
				}
				char c = value[start + 1];
				if (c < '0' || c > '9')
				{
					return CType.ONE_DIGIT;
				}
				return CType.TWO_DIGITS;
			}
			}
		}

		private int chooseCode(string value, int start, int oldCode)
		{
			CType cType = findCType(value, start);
			switch (cType)
			{
			case CType.ONE_DIGIT:
				return 100;
			case CType.UNCODABLE:
				if (start < value.Length)
				{
					char c = value[start];
					if (c < ' ' || (oldCode == 101 && c < '`'))
					{
						return 101;
					}
				}
				return 100;
			default:
				switch (oldCode)
				{
				case 99:
					return 99;
				case 100:
					if (cType == CType.FNC_1)
					{
						return 100;
					}
					switch (findCType(value, start + 2))
					{
					case CType.UNCODABLE:
					case CType.ONE_DIGIT:
						return 100;
					case CType.FNC_1:
						cType = findCType(value, start + 3);
						if (cType == CType.TWO_DIGITS)
						{
							if (!forceCodesetB)
							{
								return 99;
							}
							return 100;
						}
						return 100;
					default:
					{
						int num = start + 4;
						while ((cType = findCType(value, num)) == CType.TWO_DIGITS)
						{
							num += 2;
						}
						if (cType == CType.ONE_DIGIT)
						{
							return 100;
						}
						if (!forceCodesetB)
						{
							return 99;
						}
						return 100;
					}
					}
				default:
					if (cType == CType.FNC_1)
					{
						cType = findCType(value, start + 1);
					}
					if (cType == CType.TWO_DIGITS)
					{
						if (!forceCodesetB)
						{
							return 99;
						}
						return 100;
					}
					return 100;
				}
			}
		}
	}
	public sealed class Code39Reader : OneDReader
	{
		internal static string ALPHABET_STRING = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";

		internal static int[] CHARACTER_ENCODINGS = new int[43]
		{
			52, 289, 97, 352, 49, 304, 112, 37, 292, 100,
			265, 73, 328, 25, 280, 88, 13, 268, 76, 28,
			259, 67, 322, 19, 274, 82, 7, 262, 70, 22,
			385, 193, 448, 145, 400, 208, 133, 388, 196, 168,
			162, 138, 42
		};

		internal static readonly int ASTERISK_ENCODING = 148;

		private readonly bool usingCheckDigit;

		private readonly bool extendedMode;

		private readonly StringBuilder decodeRowResult;

		private readonly int[] counters;

		public static string Alphabet => ALPHABET_STRING;

		public Code39Reader()
			: this(usingCheckDigit: false)
		{
		}

		public Code39Reader(bool usingCheckDigit)
			: this(usingCheckDigit, extendedMode: false)
		{
		}

		public Code39Reader(bool usingCheckDigit, bool extendedMode)
		{
			this.usingCheckDigit = usingCheckDigit;
			this.extendedMode = extendedMode;
			decodeRowResult = new StringBuilder(20);
			counters = new int[9];
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			for (int i = 0; i < counters.Length; i++)
			{
				counters[i] = 0;
			}
			decodeRowResult.Length = 0;
			int[] array = findAsteriskPattern(row, counters);
			if (array == null)
			{
				return null;
			}
			int num = row.getNextSet(array[1]);
			int size = row.Size;
			char c;
			int num3;
			int[] array2;
			do
			{
				if (!OneDReader.recordPattern(row, num, counters))
				{
					return null;
				}
				int num2 = toNarrowWidePattern(counters);
				if (num2 < 0)
				{
					return null;
				}
				if (!patternToChar(num2, out c))
				{
					return null;
				}
				decodeRowResult.Append(c);
				num3 = num;
				array2 = counters;
				foreach (int num4 in array2)
				{
					num += num4;
				}
				num = row.getNextSet(num);
			}
			while (c != '*');
			decodeRowResult.Length -= 1;
			int num5 = 0;
			array2 = counters;
			foreach (int num6 in array2)
			{
				num5 += num6;
			}
			int num7 = num - num3 - num5;
			if (num != size && num7 << 1 < num5)
			{
				return null;
			}
			bool flag = usingCheckDigit;
			if (hints != null && hints.ContainsKey(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT))
			{
				flag = (bool)hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT];
			}
			if (flag)
			{
				int num8 = decodeRowResult.Length - 1;
				int num9 = 0;
				for (int k = 0; k < num8; k++)
				{
					num9 += ALPHABET_STRING.IndexOf(decodeRowResult[k]);
				}
				if (decodeRowResult[num8] != ALPHABET_STRING[num9 % 43])
				{
					return null;
				}
				decodeRowResult.Length = num8;
			}
			if (decodeRowResult.Length == 0)
			{
				return null;
			}
			bool flag2 = extendedMode;
			if (hints != null && hints.ContainsKey(DecodeHintType.USE_CODE_39_EXTENDED_MODE))
			{
				flag2 = (bool)hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE];
			}
			string text;
			if (flag2)
			{
				text = decodeExtended(decodeRowResult.ToString());
				if (text == null)
				{
					if (hints == null || !hints.ContainsKey(DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE) || !Convert.ToBoolean(hints[DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE]))
					{
						return null;
					}
					text = decodeRowResult.ToString();
				}
			}
			else
			{
				text = decodeRowResult.ToString();
			}
			float x = (float)(array[1] + array[0]) / 2f;
			float x2 = (float)num3 + (float)num5 / 2f;
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(x, rowNumber));
				resultPointCallback(new ResultPoint(x2, rowNumber));
			}
			return new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, BarcodeFormat.CODE_39);
		}

		private static int[] findAsteriskPattern(ZXing.Common.BitArray row, int[] counters)
		{
			int size = row.Size;
			int nextSet = row.getNextSet(0);
			int num = 0;
			int num2 = nextSet;
			bool flag = false;
			int num3 = counters.Length;
			for (int i = nextSet; i < size; i++)
			{
				if (row[i] != flag)
				{
					counters[num]++;
					continue;
				}
				if (num == num3 - 1)
				{
					if (toNarrowWidePattern(counters) == ASTERISK_ENCODING && row.isRange(Math.Max(0, num2 - (i - num2 >> 1)), num2, value: false))
					{
						return new int[2] { num2, i };
					}
					num2 += counters[0] + counters[1];
					Array.Copy(counters, 2, counters, 0, num - 1);
					counters[num - 1] = 0;
					counters[num] = 0;
					num--;
				}
				else
				{
					num++;
				}
				counters[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private static int toNarrowWidePattern(int[] counters)
		{
			int num = counters.Length;
			int num2 = 0;
			int num5;
			do
			{
				int num3 = 2147483647;
				foreach (int num4 in counters)
				{
					if (num4 < num3 && num4 > num2)
					{
						num3 = num4;
					}
				}
				num2 = num3;
				num5 = 0;
				int num6 = 0;
				int num7 = 0;
				for (int j = 0; j < num; j++)
				{
					int num8 = counters[j];
					if (num8 > num2)
					{
						num7 |= 1 << num - 1 - j;
						num5++;
						num6 += num8;
					}
				}
				if (num5 != 3)
				{
					continue;
				}
				for (int k = 0; k < num; k++)
				{
					if (num5 <= 0)
					{
						break;
					}
					int num9 = counters[k];
					if (num9 > num2)
					{
						num5--;
						if (num9 << 1 >= num6)
						{
							return -1;
						}
					}
				}
				return num7;
			}
			while (num5 > 3);
			return -1;
		}

		private static bool patternToChar(int pattern, out char c)
		{
			for (int i = 0; i < CHARACTER_ENCODINGS.Length; i++)
			{
				if (CHARACTER_ENCODINGS[i] == pattern)
				{
					c = ALPHABET_STRING[i];
					return true;
				}
			}
			c = '*';
			return pattern == ASTERISK_ENCODING;
		}

		private static string decodeExtended(string encoded)
		{
			int length = encoded.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				char c = encoded[i];
				if (c == '+' || c == '$' || c == '%' || c == '/')
				{
					if (i + 1 >= encoded.Length)
					{
						return null;
					}
					char c2 = encoded[i + 1];
					char value = '\0';
					switch (c)
					{
					case '+':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 + 32);
							break;
						}
						return null;
					case '$':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 - 64);
							break;
						}
						return null;
					case '%':
						if (c2 >= 'A' && c2 <= 'E')
						{
							value = (char)(c2 - 38);
							break;
						}
						if (c2 >= 'F' && c2 <= 'J')
						{
							value = (char)(c2 - 11);
							break;
						}
						if (c2 >= 'K' && c2 <= 'O')
						{
							value = (char)(c2 + 16);
							break;
						}
						if (c2 >= 'P' && c2 <= 'T')
						{
							value = (char)(c2 + 43);
							break;
						}
						switch (c2)
						{
						case 'U':
							value = '\0';
							break;
						case 'V':
							value = '@';
							break;
						case 'W':
							value = '`';
							break;
						case 'X':
						case 'Y':
						case 'Z':
							value = '\u007f';
							break;
						default:
							return null;
						}
						break;
					case '/':
						if (c2 >= 'A' && c2 <= 'O')
						{
							value = (char)(c2 - 32);
							break;
						}
						if (c2 == 'Z')
						{
							value = ':';
							break;
						}
						return null;
					}
					stringBuilder.Append(value);
					i++;
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class Code39Writer : OneDimensionalCodeWriter
	{
		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.CODE_39)
			{
				throw new ArgumentException("Can only encode CODE_39, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			if (length > 80)
			{
				throw new ArgumentException("Requested contents should be less than 80 digits long, but got " + length);
			}
			for (int i = 0; i < length; i++)
			{
				if (Code39Reader.ALPHABET_STRING.IndexOf(contents[i]) < 0)
				{
					char c = contents[i];
					contents = tryToConvertToExtendedMode(contents);
					if (contents == null)
					{
						throw new ArgumentException("Requested content contains a non-encodable character: '" + c + "'");
					}
					length = contents.Length;
					if (length <= 80)
					{
						break;
					}
					throw new ArgumentException("Requested contents should be less than 80 digits long, but got " + length + " (extended full ascii mode)");
				}
			}
			int[] array = new int[9];
			int num = 25 + length;
			for (int j = 0; j < length; j++)
			{
				int num2 = Code39Reader.ALPHABET_STRING.IndexOf(contents[j]);
				toIntArray(Code39Reader.CHARACTER_ENCODINGS[num2], array);
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
			}
			bool[] array3 = new bool[num];
			toIntArray(Code39Reader.ASTERISK_ENCODING, array);
			int num4 = OneDimensionalCodeWriter.appendPattern(array3, 0, array, startColor: true);
			int[] pattern = new int[1] { 1 };
			num4 += OneDimensionalCodeWriter.appendPattern(array3, num4, pattern, startColor: false);
			for (int l = 0; l < length; l++)
			{
				int num5 = Code39Reader.ALPHABET_STRING.IndexOf(contents[l]);
				toIntArray(Code39Reader.CHARACTER_ENCODINGS[num5], array);
				num4 += OneDimensionalCodeWriter.appendPattern(array3, num4, array, startColor: true);
				num4 += OneDimensionalCodeWriter.appendPattern(array3, num4, pattern, startColor: false);
			}
			toIntArray(Code39Reader.ASTERISK_ENCODING, array);
			OneDimensionalCodeWriter.appendPattern(array3, num4, array, startColor: true);
			return array3;
		}

		private static void toIntArray(int a, int[] toReturn)
		{
			for (int i = 0; i < 9; i++)
			{
				int num = a & (1 << 8 - i);
				toReturn[i] = ((num == 0) ? 1 : 2);
			}
		}

		private static string tryToConvertToExtendedMode(string contents)
		{
			int length = contents.Length;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				int num = contents[i];
				switch (num)
				{
				case 0:
					stringBuilder.Append("%U");
					continue;
				case 32:
					stringBuilder.Append(" ");
					continue;
				case 45:
					stringBuilder.Append("-");
					continue;
				case 46:
					stringBuilder.Append(".");
					continue;
				case 64:
					stringBuilder.Append("%V");
					continue;
				case 96:
					stringBuilder.Append("%W");
					continue;
				}
				if (num > 0 && num < 27)
				{
					stringBuilder.Append("$");
					stringBuilder.Append((char)(65 + (num - 1)));
					continue;
				}
				if (num > 26 && num < 32)
				{
					stringBuilder.Append("%");
					stringBuilder.Append((char)(65 + (num - 27)));
					continue;
				}
				if (num <= 32 || num >= 45)
				{
					switch (num)
					{
					case 47:
					case 58:
						break;
					case 48:
					case 49:
					case 50:
					case 51:
					case 52:
					case 53:
					case 54:
					case 55:
					case 56:
					case 57:
						stringBuilder.Append((char)(48 + (num - 48)));
						continue;
					default:
						if (num > 58 && num < 64)
						{
							stringBuilder.Append("%");
							stringBuilder.Append((char)(70 + (num - 59)));
							continue;
						}
						if (num > 64 && num < 91)
						{
							stringBuilder.Append((char)(65 + (num - 65)));
							continue;
						}
						if (num > 90 && num < 96)
						{
							stringBuilder.Append("%");
							stringBuilder.Append((char)(75 + (num - 91)));
							continue;
						}
						if (num > 96 && num < 123)
						{
							stringBuilder.Append("+");
							stringBuilder.Append((char)(65 + (num - 97)));
							continue;
						}
						if (num > 122 && num < 128)
						{
							stringBuilder.Append("%");
							stringBuilder.Append((char)(80 + (num - 123)));
							continue;
						}
						return null;
					}
				}
				stringBuilder.Append("/");
				stringBuilder.Append((char)(65 + (num - 33)));
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class Code93Reader : OneDReader
	{
		internal const string ALPHABET_STRING = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*";

		private static readonly char[] ALPHABET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*".ToCharArray();

		internal static readonly int[] CHARACTER_ENCODINGS = new int[48]
		{
			276, 328, 324, 322, 296, 292, 290, 336, 274, 266,
			424, 420, 418, 404, 402, 394, 360, 356, 354, 308,
			282, 344, 332, 326, 300, 278, 436, 434, 428, 422,
			406, 410, 364, 358, 310, 314, 302, 468, 466, 458,
			366, 374, 430, 294, 474, 470, 306, 350
		};

		private static readonly int ASTERISK_ENCODING = CHARACTER_ENCODINGS[47];

		private readonly StringBuilder decodeRowResult;

		private readonly int[] counters;

		public Code93Reader()
		{
			decodeRowResult = new StringBuilder(20);
			counters = new int[6];
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			for (int i = 0; i < counters.Length; i++)
			{
				counters[i] = 0;
			}
			decodeRowResult.Length = 0;
			int[] array = findAsteriskPattern(row);
			if (array == null)
			{
				return null;
			}
			int num = row.getNextSet(array[1]);
			int size = row.Size;
			char c;
			int num3;
			int[] array2;
			do
			{
				if (!OneDReader.recordPattern(row, num, counters))
				{
					return null;
				}
				int num2 = toPattern(counters);
				if (num2 < 0)
				{
					return null;
				}
				if (!patternToChar(num2, out c))
				{
					return null;
				}
				decodeRowResult.Append(c);
				num3 = num;
				array2 = counters;
				foreach (int num4 in array2)
				{
					num += num4;
				}
				num = row.getNextSet(num);
			}
			while (c != '*');
			decodeRowResult.Remove(decodeRowResult.Length - 1, 1);
			int num5 = 0;
			array2 = counters;
			foreach (int num6 in array2)
			{
				num5 += num6;
			}
			if (num == size || !row[num])
			{
				return null;
			}
			if (decodeRowResult.Length < 2)
			{
				return null;
			}
			if (!checkChecksums(decodeRowResult))
			{
				return null;
			}
			decodeRowResult.Length -= 2;
			string text = decodeExtended(decodeRowResult);
			if (text == null)
			{
				return null;
			}
			float x = (float)(array[1] + array[0]) / 2f;
			float x2 = (float)num3 + (float)num5 / 2f;
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(x, rowNumber));
				resultPointCallback(new ResultPoint(x2, rowNumber));
			}
			return new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, BarcodeFormat.CODE_93);
		}

		private int[] findAsteriskPattern(ZXing.Common.BitArray row)
		{
			int size = row.Size;
			int nextSet = row.getNextSet(0);
			for (int i = 0; i < counters.Length; i++)
			{
				counters[i] = 0;
			}
			int num = 0;
			int num2 = nextSet;
			bool flag = false;
			int num3 = counters.Length;
			for (int j = nextSet; j < size; j++)
			{
				if (row[j] != flag)
				{
					counters[num]++;
					continue;
				}
				if (num == num3 - 1)
				{
					if (toPattern(counters) == ASTERISK_ENCODING)
					{
						return new int[2] { num2, j };
					}
					num2 += counters[0] + counters[1];
					Array.Copy(counters, 2, counters, 0, num - 1);
					counters[num - 1] = 0;
					counters[num] = 0;
					num--;
				}
				else
				{
					num++;
				}
				counters[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private static int toPattern(int[] counters)
		{
			int num = counters.Length;
			int num2 = 0;
			foreach (int num3 in counters)
			{
				num2 += num3;
			}
			int num4 = 0;
			for (int j = 0; j < num; j++)
			{
				int num5 = (counters[j] << OneDReader.INTEGER_MATH_SHIFT) * 9 / num2;
				int num6 = num5 >> OneDReader.INTEGER_MATH_SHIFT;
				if ((num5 & 0xFF) > 127)
				{
					num6++;
				}
				if (num6 < 1 || num6 > 4)
				{
					return -1;
				}
				if ((j & 1) == 0)
				{
					for (int k = 0; k < num6; k++)
					{
						num4 = (num4 << 1) | 1;
					}
				}
				else
				{
					num4 <<= num6;
				}
			}
			return num4;
		}

		private static bool patternToChar(int pattern, out char c)
		{
			for (int i = 0; i < CHARACTER_ENCODINGS.Length; i++)
			{
				if (CHARACTER_ENCODINGS[i] == pattern)
				{
					c = ALPHABET[i];
					return true;
				}
			}
			c = '*';
			return false;
		}

		private static string decodeExtended(StringBuilder encoded)
		{
			int length = encoded.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				char c = encoded[i];
				if (c >= 'a' && c <= 'd')
				{
					if (i >= length - 1)
					{
						return null;
					}
					char c2 = encoded[i + 1];
					char value = '\0';
					switch (c)
					{
					case 'd':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 + 32);
							break;
						}
						return null;
					case 'a':
						if (c2 >= 'A' && c2 <= 'Z')
						{
							value = (char)(c2 - 64);
							break;
						}
						return null;
					case 'b':
						if (c2 >= 'A' && c2 <= 'E')
						{
							value = (char)(c2 - 38);
							break;
						}
						if (c2 >= 'F' && c2 <= 'J')
						{
							value = (char)(c2 - 11);
							break;
						}
						if (c2 >= 'K' && c2 <= 'O')
						{
							value = (char)(c2 + 16);
							break;
						}
						if (c2 >= 'P' && c2 <= 'S')
						{
							value = (char)(c2 + 43);
							break;
						}
						if (c2 >= 'T' && c2 <= 'Z')
						{
							value = '\u007f';
							break;
						}
						return null;
					case 'c':
						if (c2 >= 'A' && c2 <= 'O')
						{
							value = (char)(c2 - 32);
							break;
						}
						if (c2 == 'Z')
						{
							value = ':';
							break;
						}
						return null;
					}
					stringBuilder.Append(value);
					i++;
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		private static bool checkChecksums(StringBuilder result)
		{
			int length = result.Length;
			if (!checkOneChecksum(result, length - 2, 20))
			{
				return false;
			}
			if (!checkOneChecksum(result, length - 1, 15))
			{
				return false;
			}
			return true;
		}

		private static bool checkOneChecksum(StringBuilder result, int checkPosition, int weightMax)
		{
			int num = 1;
			int num2 = 0;
			for (int num3 = checkPosition - 1; num3 >= 0; num3--)
			{
				num2 += num * "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*".IndexOf(result[num3]);
				if (++num > weightMax)
				{
					num = 1;
				}
			}
			if (result[checkPosition] != ALPHABET[num2 % 47])
			{
				return false;
			}
			return true;
		}
	}
	public class Code93Writer : OneDimensionalCodeWriter
	{
		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.CODE_93)
			{
				throw new ArgumentException("Can only encode CODE_93, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			if (length > 80)
			{
				throw new ArgumentException("Requested contents should be less than 80 digits long, but got " + length);
			}
			int[] array = new int[9];
			int num = (contents.Length + 2 + 2) * 9 + 1;
			toIntArray(Code93Reader.CHARACTER_ENCODINGS[47], array);
			bool[] array2 = new bool[num];
			int num2 = appendPattern(array2, 0, array);
			for (int i = 0; i < length; i++)
			{
				int num3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*".IndexOf(contents[i]);
				toIntArray(Code93Reader.CHARACTER_ENCODINGS[num3], array);
				num2 += appendPattern(array2, num2, array);
			}
			int num4 = computeChecksumIndex(contents, 20);
			toIntArray(Code93Reader.CHARACTER_ENCODINGS[num4], array);
			num2 += appendPattern(array2, num2, array);
			contents += "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*"[num4];
			int num5 = computeChecksumIndex(contents, 15);
			toIntArray(Code93Reader.CHARACTER_ENCODINGS[num5], array);
			num2 += appendPattern(array2, num2, array);
			toIntArray(Code93Reader.CHARACTER_ENCODINGS[47], array);
			num2 += appendPattern(array2, num2, array);
			array2[num2] = true;
			return array2;
		}

		private static void toIntArray(int a, int[] toReturn)
		{
			for (int i = 0; i < 9; i++)
			{
				int num = a & (1 << 8 - i);
				toReturn[i] = ((num != 0) ? 1 : 0);
			}
		}

		[Obsolete("without replacement; intended as an internal-only method")]
		protected new static int appendPattern(bool[] target, int pos, int[] pattern, bool startColor)
		{
			return appendPattern(target, pos, pattern);
		}

		private static int appendPattern(bool[] target, int pos, int[] pattern)
		{
			foreach (int num in pattern)
			{
				target[pos++] = num != 0;
			}
			return 9;
		}

		private static int computeChecksumIndex(string contents, int maxWeight)
		{
			int num = 1;
			int num2 = 0;
			for (int num3 = contents.Length - 1; num3 >= 0; num3--)
			{
				int num4 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd*".IndexOf(contents[num3]);
				num2 += num4 * num;
				if (++num > maxWeight)
				{
					num = 1;
				}
			}
			return num2 % 47;
		}
	}
	public sealed class EAN13Reader : UPCEANReader
	{
		internal static int[] FIRST_DIGIT_ENCODINGS = new int[10] { 0, 11, 13, 14, 19, 25, 28, 21, 22, 26 };

		private readonly int[] decodeMiddleCounters;

		internal override BarcodeFormat BarcodeFormat => BarcodeFormat.EAN_13;

		public EAN13Reader()
		{
			decodeMiddleCounters = new int[4];
		}

		protected internal override int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder resultString)
		{
			int[] array = decodeMiddleCounters;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int num = startRange[1];
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_AND_G_PATTERNS, out var digit))
				{
					return -1;
				}
				resultString.Append((char)(48 + digit % 10));
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
				if (digit >= 10)
				{
					num2 |= 1 << 5 - i;
				}
			}
			if (!determineFirstDigit(resultString, num2))
			{
				return -1;
			}
			int[] array3 = UPCEANReader.findGuardPattern(row, num, whiteFirst: true, UPCEANReader.MIDDLE_PATTERN);
			if (array3 == null)
			{
				return -1;
			}
			num = array3[1];
			for (int k = 0; k < 6; k++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_PATTERNS, out var digit2))
				{
					return -1;
				}
				resultString.Append((char)(48 + digit2));
				int[] array2 = array;
				foreach (int num4 in array2)
				{
					num += num4;
				}
			}
			return num;
		}

		private static bool determineFirstDigit(StringBuilder resultString, int lgPatternFound)
		{
			for (int i = 0; i < 10; i++)
			{
				if (lgPatternFound == FIRST_DIGIT_ENCODINGS[i])
				{
					resultString.Insert(0, new char[1] { (char)(48 + i) });
					return true;
				}
			}
			return false;
		}
	}
	public sealed class EAN13Writer : UPCEANWriter
	{
		private const int CODE_WIDTH = 95;

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.EAN_13)
			{
				throw new ArgumentException("Can only encode EAN_13, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			switch (contents.Length)
			{
			case 12:
			{
				int? standardUPCEANChecksum = UPCEANReader.getStandardUPCEANChecksum(contents);
				if (!standardUPCEANChecksum.HasValue)
				{
					throw new ArgumentException("Checksum can't be calculated");
				}
				contents += standardUPCEANChecksum.Value;
				break;
			}
			case 13:
				try
				{
					if (!UPCEANReader.checkStandardUPCEANChecksum(contents))
					{
						throw new ArgumentException("Contents do not pass checksum");
					}
				}
				catch (FormatException innerException)
				{
					throw new ArgumentException("Illegal contents", innerException);
				}
				break;
			default:
				throw new ArgumentException("Requested contents should be 12 (without checksum digit) or 13 digits long, but got " + contents.Length);
			}
			int num = int.Parse(contents.Substring(0, 1));
			int num2 = EAN13Reader.FIRST_DIGIT_ENCODINGS[num];
			bool[] array = new bool[95];
			int num3 = 0;
			num3 += OneDimensionalCodeWriter.appendPattern(array, num3, UPCEANReader.START_END_PATTERN, startColor: true);
			for (int i = 1; i <= 6; i++)
			{
				int num4 = int.Parse(contents.Substring(i, 1));
				if (((num2 >> 6 - i) & 1) == 1)
				{
					num4 += 10;
				}
				num3 += OneDimensionalCodeWriter.appendPattern(array, num3, UPCEANReader.L_AND_G_PATTERNS[num4], startColor: false);
			}
			num3 += OneDimensionalCodeWriter.appendPattern(array, num3, UPCEANReader.MIDDLE_PATTERN, startColor: false);
			for (int j = 7; j <= 12; j++)
			{
				int num5 = int.Parse(contents.Substring(j, 1));
				num3 += OneDimensionalCodeWriter.appendPattern(array, num3, UPCEANReader.L_PATTERNS[num5], startColor: true);
			}
			OneDimensionalCodeWriter.appendPattern(array, num3, UPCEANReader.START_END_PATTERN, startColor: true);
			return array;
		}
	}
	public sealed class EAN8Reader : UPCEANReader
	{
		private readonly int[] decodeMiddleCounters;

		internal override BarcodeFormat BarcodeFormat => BarcodeFormat.EAN_8;

		public EAN8Reader()
		{
			decodeMiddleCounters = new int[4];
		}

		protected internal override int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder result)
		{
			int[] array = decodeMiddleCounters;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int num = startRange[1];
			for (int i = 0; i < 4; i++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_PATTERNS, out var digit))
				{
					return -1;
				}
				result.Append((char)(48 + digit));
				int[] array2 = array;
				foreach (int num2 in array2)
				{
					num += num2;
				}
			}
			int[] array3 = UPCEANReader.findGuardPattern(row, num, whiteFirst: true, UPCEANReader.MIDDLE_PATTERN);
			if (array3 == null)
			{
				return -1;
			}
			num = array3[1];
			for (int k = 0; k < 4; k++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_PATTERNS, out var digit2))
				{
					return -1;
				}
				result.Append((char)(48 + digit2));
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
			}
			return num;
		}
	}
	public sealed class EAN8Writer : UPCEANWriter
	{
		private const int CODE_WIDTH = 67;

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.EAN_8)
			{
				throw new ArgumentException("Can only encode EAN_8, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			switch (contents.Length)
			{
			case 7:
			{
				int? standardUPCEANChecksum = UPCEANReader.getStandardUPCEANChecksum(contents);
				if (!standardUPCEANChecksum.HasValue)
				{
					throw new ArgumentException("Checksum can't be calculated");
				}
				contents += standardUPCEANChecksum.Value;
				break;
			}
			case 8:
				try
				{
					if (!UPCEANReader.checkStandardUPCEANChecksum(contents))
					{
						throw new ArgumentException("Contents do not pass checksum");
					}
				}
				catch (FormatException innerException)
				{
					throw new ArgumentException("Illegal contents", innerException);
				}
				break;
			default:
				throw new ArgumentException("Requested contents should be 7 (without checksum digit) or 8 digits long, but got " + contents.Length);
			}
			bool[] array = new bool[67];
			int num = 0;
			num += OneDimensionalCodeWriter.appendPattern(array, num, UPCEANReader.START_END_PATTERN, startColor: true);
			for (int i = 0; i <= 3; i++)
			{
				int num2 = int.Parse(contents.Substring(i, 1));
				num += OneDimensionalCodeWriter.appendPattern(array, num, UPCEANReader.L_PATTERNS[num2], startColor: false);
			}
			num += OneDimensionalCodeWriter.appendPattern(array, num, UPCEANReader.MIDDLE_PATTERN, startColor: false);
			for (int j = 4; j <= 7; j++)
			{
				int num3 = int.Parse(contents.Substring(j, 1));
				num += OneDimensionalCodeWriter.appendPattern(array, num, UPCEANReader.L_PATTERNS[num3], startColor: true);
			}
			OneDimensionalCodeWriter.appendPattern(array, num, UPCEANReader.START_END_PATTERN, startColor: true);
			return array;
		}
	}
	internal sealed class EANManufacturerOrgSupport
	{
		private List<int[]> ranges = new List<int[]>();

		private List<string> countryIdentifiers = new List<string>();

		internal string lookupCountryIdentifier(string productCode)
		{
			initIfNeeded();
			int num = int.Parse(productCode.Substring(0, 3));
			int count = ranges.Count;
			for (int i = 0; i < count; i++)
			{
				int[] array = ranges[i];
				int num2 = array[0];
				if (num < num2)
				{
					return null;
				}
				int num3 = ((array.Length == 1) ? num2 : array[1]);
				if (num <= num3)
				{
					return countryIdentifiers[i];
				}
			}
			return null;
		}

		private void add(int[] range, string id)
		{
			ranges.Add(range);
			countryIdentifiers.Add(id);
		}

		private void initIfNeeded()
		{
			if (ranges.Count == 0)
			{
				add(new int[2] { 0, 19 }, "US/CA");
				add(new int[2] { 30, 39 }, "US");
				add(new int[2] { 60, 139 }, "US/CA");
				add(new int[2] { 300, 379 }, "FR");
				add(new int[1] { 380 }, "BG");
				add(new int[1] { 383 }, "SI");
				add(new int[1] { 385 }, "HR");
				add(new int[1] { 387 }, "BA");
				add(new int[2] { 400, 440 }, "DE");
				add(new int[2] { 450, 459 }, "JP");
				add(new int[2] { 460, 469 }, "RU");
				add(new int[1] { 471 }, "TW");
				add(new int[1] { 474 }, "EE");
				add(new int[1] { 475 }, "LV");
				add(new int[1] { 476 }, "AZ");
				add(new int[1] { 477 }, "LT");
				add(new int[1] { 478 }, "UZ");
				add(new int[1] { 479 }, "LK");
				add(new int[1] { 480 }, "PH");
				add(new int[1] { 481 }, "BY");
				add(new int[1] { 482 }, "UA");
				add(new int[1] { 484 }, "MD");
				add(new int[1] { 485 }, "AM");
				add(new int[1] { 486 }, "GE");
				add(new int[1] { 487 }, "KZ");
				add(new int[1] { 489 }, "HK");
				add(new int[2] { 490, 499 }, "JP");
				add(new int[2] { 500, 509 }, "GB");
				add(new int[1] { 520 }, "GR");
				add(new int[1] { 528 }, "LB");
				add(new int[1] { 529 }, "CY");
				add(new int[1] { 531 }, "MK");
				add(new int[1] { 535 }, "MT");
				add(new int[1] { 539 }, "IE");
				add(new int[2] { 540, 549 }, "BE/LU");
				add(new int[1] { 560 }, "PT");
				add(new int[1] { 569 }, "IS");
				add(new int[2] { 570, 579 }, "DK");
				add(new int[1] { 590 }, "PL");
				add(new int[1] { 594 }, "RO");
				add(new int[1] { 599 }, "HU");
				add(new int[2] { 600, 601 }, "ZA");
				add(new int[1] { 603 }, "GH");
				add(new int[1] { 608 }, "BH");
				add(new int[1] { 609 }, "MU");
				add(new int[1] { 611 }, "MA");
				add(new int[1] { 613 }, "DZ");
				add(new int[1] { 616 }, "KE");
				add(new int[1] { 618 }, "CI");
				add(new int[1] { 619 }, "TN");
				add(new int[1] { 621 }, "SY");
				add(new int[1] { 622 }, "EG");
				add(new int[1] { 624 }, "LY");
				add(new int[1] { 625 }, "JO");
				add(new int[1] { 626 }, "IR");
				add(new int[1] { 627 }, "KW");
				add(new int[1] { 628 }, "SA");
				add(new int[1] { 629 }, "AE");
				add(new int[2] { 640, 649 }, "FI");
				add(new int[2] { 690, 695 }, "CN");
				add(new int[2] { 700, 709 }, "NO");
				add(new int[1] { 729 }, "IL");
				add(new int[2] { 730, 739 }, "SE");
				add(new int[1] { 740 }, "GT");
				add(new int[1] { 741 }, "SV");
				add(new int[1] { 742 }, "HN");
				add(new int[1] { 743 }, "NI");
				add(new int[1] { 744 }, "CR");
				add(new int[1] { 745 }, "PA");
				add(new int[1] { 746 }, "DO");
				add(new int[1] { 750 }, "MX");
				add(new int[2] { 754, 755 }, "CA");
				add(new int[1] { 759 }, "VE");
				add(new int[2] { 760, 769 }, "CH");
				add(new int[1] { 770 }, "CO");
				add(new int[1] { 773 }, "UY");
				add(new int[1] { 775 }, "PE");
				add(new int[1] { 777 }, "BO");
				add(new int[1] { 779 }, "AR");
				add(new int[1] { 780 }, "CL");
				add(new int[1] { 784 }, "PY");
				add(new int[1] { 785 }, "PE");
				add(new int[1] { 786 }, "EC");
				add(new int[2] { 789, 790 }, "BR");
				add(new int[2] { 800, 839 }, "IT");
				add(new int[2] { 840, 849 }, "ES");
				add(new int[1] { 850 }, "CU");
				add(new int[1] { 858 }, "SK");
				add(new int[1] { 859 }, "CZ");
				add(new int[1] { 860 }, "YU");
				add(new int[1] { 865 }, "MN");
				add(new int[1] { 867 }, "KP");
				add(new int[2] { 868, 869 }, "TR");
				add(new int[2] { 870, 879 }, "NL");
				add(new int[1] { 880 }, "KR");
				add(new int[1] { 885 }, "TH");
				add(new int[1] { 888 }, "SG");
				add(new int[1] { 890 }, "IN");
				add(new int[1] { 893 }, "VN");
				add(new int[1] { 896 }, "PK");
				add(new int[1] { 899 }, "ID");
				add(new int[2] { 900, 919 }, "AT");
				add(new int[2] { 930, 939 }, "AU");
				add(new int[2] { 940, 949 }, "AZ");
				add(new int[1] { 955 }, "MY");
				add(new int[1] { 958 }, "MO");
			}
		}
	}
	public sealed class ITFReader : OneDReader
	{
		private static readonly int MAX_AVG_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.38f);

		private static readonly int MAX_INDIVIDUAL_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.5f);

		private const int W = 3;

		private const int w = 2;

		private const int N = 1;

		private static readonly int[] DEFAULT_ALLOWED_LENGTHS = new int[5] { 6, 8, 10, 12, 14 };

		private const int LARGEST_DEFAULT_ALLOWED_LENGTH = 14;

		private int narrowLineWidth = -1;

		private static readonly int[] START_PATTERN = new int[4] { 1, 1, 1, 1 };

		private static readonly int[][] END_PATTERN_REVERSED = new int[2][]
		{
			new int[3] { 1, 1, 2 },
			new int[3] { 1, 1, 3 }
		};

		internal static int[][] PATTERNS = new int[20][]
		{
			new int[5] { 1, 1, 2, 2, 1 },
			new int[5] { 2, 1, 1, 1, 2 },
			new int[5] { 1, 2, 1, 1, 2 },
			new int[5] { 2, 2, 1, 1, 1 },
			new int[5] { 1, 1, 2, 1, 2 },
			new int[5] { 2, 1, 2, 1, 1 },
			new int[5] { 1, 2, 2, 1, 1 },
			new int[5] { 1, 1, 1, 2, 2 },
			new int[5] { 2, 1, 1, 2, 1 },
			new int[5] { 1, 2, 1, 2, 1 },
			new int[5] { 1, 1, 3, 3, 1 },
			new int[5] { 3, 1, 1, 1, 3 },
			new int[5] { 1, 3, 1, 1, 3 },
			new int[5] { 3, 3, 1, 1, 1 },
			new int[5] { 1, 1, 3, 1, 3 },
			new int[5] { 3, 1, 3, 1, 1 },
			new int[5] { 1, 3, 3, 1, 1 },
			new int[5] { 1, 1, 1, 3, 3 },
			new int[5] { 3, 1, 1, 3, 1 },
			new int[5] { 1, 3, 1, 3, 1 }
		};

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			int[] array = decodeStart(row);
			if (array == null)
			{
				return null;
			}
			int[] array2 = decodeEnd(row);
			if (array2 == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder(20);
			if (!decodeMiddle(row, array[1], array2[0], stringBuilder))
			{
				return null;
			}
			string text = stringBuilder.ToString();
			int[] array3 = null;
			int num = 14;
			if (hints != null && hints.ContainsKey(DecodeHintType.ALLOWED_LENGTHS))
			{
				array3 = (int[])hints[DecodeHintType.ALLOWED_LENGTHS];
				num = 0;
			}
			if (array3 == null)
			{
				array3 = DEFAULT_ALLOWED_LENGTHS;
				num = 14;
			}
			int length = text.Length;
			bool flag = length > 14;
			if (!flag)
			{
				int[] array4 = array3;
				foreach (int num2 in array4)
				{
					if (length == num2)
					{
						flag = true;
						break;
					}
					if (num2 > num)
					{
						num = num2;
					}
				}
				if (!flag && length > num)
				{
					flag = true;
				}
				if (!flag)
				{
					return null;
				}
			}
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(array[1], rowNumber));
				resultPointCallback(new ResultPoint(array2[0], rowNumber));
			}
			return new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint(array[1], rowNumber),
				new ResultPoint(array2[0], rowNumber)
			}, BarcodeFormat.ITF);
		}

		private static bool decodeMiddle(ZXing.Common.BitArray row, int payloadStart, int payloadEnd, StringBuilder resultString)
		{
			int[] array = new int[10];
			int[] array2 = new int[5];
			int[] array3 = new int[5];
			while (payloadStart < payloadEnd)
			{
				if (!OneDReader.recordPattern(row, payloadStart, array))
				{
					return false;
				}
				for (int i = 0; i < 5; i++)
				{
					int num = i << 1;
					array2[i] = array[num];
					array3[i] = array[num + 1];
				}
				if (!decodeDigit(array2, out var bestMatch))
				{
					return false;
				}
				resultString.Append((char)(48 + bestMatch));
				if (!decodeDigit(array3, out bestMatch))
				{
					return false;
				}
				resultString.Append((char)(48 + bestMatch));
				int[] array4 = array;
				foreach (int num2 in array4)
				{
					payloadStart += num2;
				}
			}
			return true;
		}

		private int[] decodeStart(ZXing.Common.BitArray row)
		{
			int num = skipWhiteSpace(row);
			if (num < 0)
			{
				return null;
			}
			int[] array = findGuardPattern(row, num, START_PATTERN);
			if (array == null)
			{
				return null;
			}
			narrowLineWidth = array[1] - array[0] >> 2;
			if (!validateQuietZone(row, array[0]))
			{
				return null;
			}
			return array;
		}

		private bool validateQuietZone(ZXing.Common.BitArray row, int startPattern)
		{
			int num = narrowLineWidth * 10;
			num = ((num < startPattern) ? num : startPattern);
			int num2 = startPattern - 1;
			while (num > 0 && num2 >= 0 && !row[num2])
			{
				num--;
				num2--;
			}
			if (num != 0)
			{
				return false;
			}
			return true;
		}

		private static int skipWhiteSpace(ZXing.Common.BitArray row)
		{
			int size = row.Size;
			int nextSet = row.getNextSet(0);
			if (nextSet == size)
			{
				return -1;
			}
			return nextSet;
		}

		private int[] decodeEnd(ZXing.Common.BitArray row)
		{
			row.reverse();
			int num = skipWhiteSpace(row);
			if (num < 0)
			{
				return null;
			}
			int[] array = findGuardPattern(row, num, END_PATTERN_REVERSED[0]);
			if (array == null)
			{
				array = findGuardPattern(row, num, END_PATTERN_REVERSED[1]);
			}
			if (array == null)
			{
				row.reverse();
				return null;
			}
			if (!validateQuietZone(row, array[0]))
			{
				row.reverse();
				return null;
			}
			int num2 = array[0];
			array[0] = row.Size - array[1];
			array[1] = row.Size - num2;
			row.reverse();
			return array;
		}

		private static int[] findGuardPattern(ZXing.Common.BitArray row, int rowOffset, int[] pattern)
		{
			int num = pattern.Length;
			int[] array = new int[num];
			int size = row.Size;
			bool flag = false;
			int num2 = 0;
			int num3 = rowOffset;
			for (int i = rowOffset; i < size; i++)
			{
				if (row[i] != flag)
				{
					array[num2]++;
					continue;
				}
				if (num2 == num - 1)
				{
					if (OneDReader.patternMatchVariance(array, pattern, MAX_INDIVIDUAL_VARIANCE) < MAX_AVG_VARIANCE)
					{
						return new int[2] { num3, i };
					}
					num3 += array[0] + array[1];
					Array.Copy(array, 2, array, 0, num2 - 1);
					array[num2 - 1] = 0;
					array[num2] = 0;
					num2--;
				}
				else
				{
					num2++;
				}
				array[num2] = 1;
				flag = !flag;
			}
			return null;
		}

		private static bool decodeDigit(int[] counters, out int bestMatch)
		{
			int num = MAX_AVG_VARIANCE;
			bestMatch = -1;
			int num2 = PATTERNS.Length;
			for (int i = 0; i < num2; i++)
			{
				int[] pattern = PATTERNS[i];
				int num3 = OneDReader.patternMatchVariance(counters, pattern, MAX_INDIVIDUAL_VARIANCE);
				if (num3 < num)
				{
					num = num3;
					bestMatch = i;
				}
				else if (num3 == num)
				{
					bestMatch = -1;
				}
			}
			if (bestMatch >= 0)
			{
				bestMatch %= 10;
				return true;
			}
			return false;
		}
	}
	public sealed class ITFWriter : OneDimensionalCodeWriter
	{
		private static readonly int[] START_PATTERN = new int[4] { 1, 1, 1, 1 };

		private static readonly int[] END_PATTERN = new int[3] { 3, 1, 1 };

		private const int W = 3;

		private const int N = 1;

		internal static int[][] PATTERNS = new int[10][]
		{
			new int[5] { 1, 1, 3, 3, 1 },
			new int[5] { 3, 1, 1, 1, 3 },
			new int[5] { 1, 3, 1, 1, 3 },
			new int[5] { 3, 3, 1, 1, 1 },
			new int[5] { 1, 1, 3, 1, 3 },
			new int[5] { 3, 1, 3, 1, 1 },
			new int[5] { 1, 3, 3, 1, 1 },
			new int[5] { 1, 1, 1, 3, 3 },
			new int[5] { 3, 1, 1, 3, 1 },
			new int[5] { 1, 3, 1, 3, 1 }
		};

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.ITF)
			{
				throw new ArgumentException("Can only encode ITF, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			if (length % 2 != 0)
			{
				throw new ArgumentException("The length of the input should be even");
			}
			if (length > 80)
			{
				throw new ArgumentException("Requested contents should be less than 80 digits long, but got " + length);
			}
			for (int i = 0; i < length; i++)
			{
				if (!char.IsDigit(contents[i]))
				{
					throw new ArgumentException("Requested contents should only contain digits, but got '" + contents[i] + "'");
				}
			}
			bool[] array = new bool[9 + 9 * length];
			int num = OneDimensionalCodeWriter.appendPattern(array, 0, START_PATTERN, startColor: true);
			for (int j = 0; j < length; j += 2)
			{
				int num2 = Convert.ToInt32(contents[j].ToString(), 10);
				int num3 = Convert.ToInt32(contents[j + 1].ToString(), 10);
				int[] array2 = new int[10];
				for (int k = 0; k < 5; k++)
				{
					array2[k << 1] = PATTERNS[num2][k];
					array2[(k << 1) + 1] = PATTERNS[num3][k];
				}
				num += OneDimensionalCodeWriter.appendPattern(array, num, array2, startColor: true);
			}
			OneDimensionalCodeWriter.appendPattern(array, num, END_PATTERN, startColor: true);
			return array;
		}
	}
	public sealed class MSIReader : OneDReader
	{
		internal static string ALPHABET_STRING = "0123456789";

		private static readonly char[] ALPHABET = ALPHABET_STRING.ToCharArray();

		internal static int[] CHARACTER_ENCODINGS = new int[10] { 2340, 2342, 2356, 2358, 2468, 2470, 2484, 2486, 3364, 3366 };

		private const int START_ENCODING = 6;

		private const int END_ENCODING = 9;

		private readonly bool usingCheckDigit;

		private readonly StringBuilder decodeRowResult;

		private readonly int[] counters;

		private int averageCounterWidth;

		private static readonly int[] doubleAndCrossSum = new int[10] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

		public MSIReader()
			: this(usingCheckDigit: false)
		{
		}

		public MSIReader(bool usingCheckDigit)
		{
			this.usingCheckDigit = usingCheckDigit;
			decodeRowResult = new StringBuilder(20);
			counters = new int[8];
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			for (int i = 0; i < counters.Length; i++)
			{
				counters[i] = 0;
			}
			decodeRowResult.Length = 0;
			int[] array = findStartPattern(row, counters);
			if (array == null)
			{
				return null;
			}
			int num = row.getNextSet(array[1]);
			int num2 = num;
			char c;
			do
			{
				if (!OneDReader.recordPattern(row, num, counters, 8))
				{
					int[] array2 = findEndPattern(row, num, counters);
					if (array2 == null)
					{
						return null;
					}
					num2 = num;
					num = array2[1];
					break;
				}
				if (!patternToChar(toPattern(counters, 8), out c))
				{
					int[] array3 = findEndPattern(row, num, counters);
					if (array3 == null)
					{
						return null;
					}
					num2 = num;
					num = array3[1];
					break;
				}
				decodeRowResult.Append(c);
				num2 = num;
				int[] array4 = counters;
				foreach (int num3 in array4)
				{
					num += num3;
				}
				num = row.getNextSet(num);
			}
			while (c != '*');
			if (decodeRowResult.Length < 3)
			{
				return null;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(decodeRowResult.ToString());
			string text = decodeRowResult.ToString();
			if (usingCheckDigit)
			{
				string text2 = text.Substring(0, text.Length - 1);
				if ((ushort)(CalculateChecksumLuhn(text2) + 48) != text[text2.Length])
				{
					return null;
				}
			}
			float x = (float)(array[1] + array[0]) / 2f;
			float x2 = (float)(num + num2) / 2f;
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(x, rowNumber));
				resultPointCallback(new ResultPoint(x2, rowNumber));
			}
			return new Result(text, bytes, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, BarcodeFormat.MSI);
		}

		private int[] findStartPattern(ZXing.Common.BitArray row, int[] counters)
		{
			int size = row.Size;
			int nextSet = row.getNextSet(0);
			int num = 0;
			int num2 = nextSet;
			bool flag = false;
			counters[0] = 0;
			counters[1] = 0;
			for (int i = nextSet; i < size; i++)
			{
				if (row[i] ^ flag)
				{
					counters[num]++;
					continue;
				}
				if (num == 1)
				{
					float num3 = (float)counters[0] / (float)counters[1];
					if ((double)num3 >= 1.5 && num3 <= 5f)
					{
						calculateAverageCounterWidth(counters, 2);
						if (toPattern(counters, 2) == 6 && row.isRange(Math.Max(0, num2 - (i - num2 >> 1)), num2, value: false))
						{
							return new int[2] { num2, i };
						}
					}
					num2 += counters[0] + counters[1];
					Array.Copy(counters, 2, counters, 0, 0);
					counters[0] = 0;
					counters[1] = 0;
					num--;
				}
				else
				{
					num++;
				}
				counters[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private int[] findEndPattern(ZXing.Common.BitArray row, int rowOffset, int[] counters)
		{
			int size = row.Size;
			int num = 0;
			bool flag = false;
			counters[0] = 0;
			counters[1] = 0;
			counters[2] = 0;
			for (int i = rowOffset; i < size; i++)
			{
				if (row[i] ^ flag)
				{
					counters[num]++;
					continue;
				}
				if (num == 2)
				{
					float num2 = (float)counters[1] / (float)counters[0];
					if ((double)num2 >= 1.5 && num2 <= 5f && toPattern(counters, 3) == 9)
					{
						int end = Math.Min(row.Size - 1, i + (i - rowOffset >> 1));
						if (row.isRange(i, end, value: false))
						{
							return new int[2] { rowOffset, i };
						}
					}
					return null;
				}
				num++;
				counters[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private void calculateAverageCounterWidth(int[] counters, int patternLength)
		{
			int num = 2147483647;
			int num2 = 0;
			for (int i = 0; i < patternLength; i++)
			{
				int num3 = counters[i];
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			averageCounterWidth = ((num2 << 8) + (num << 8)) / 2;
		}

		private int toPattern(int[] counters, int patternLength)
		{
			int num = 0;
			int num2 = 1;
			int num3 = 3;
			for (int i = 0; i < patternLength; i++)
			{
				num = ((counters[i] << 8 >= averageCounterWidth) ? ((num << 2) | num3) : ((num << 1) | num2));
				num2 ^= 1;
				num3 ^= 3;
			}
			return num;
		}

		private static bool patternToChar(int pattern, out char c)
		{
			for (int i = 0; i < CHARACTER_ENCODINGS.Length; i++)
			{
				if (CHARACTER_ENCODINGS[i] == pattern)
				{
					c = ALPHABET[i];
					return true;
				}
			}
			c = '*';
			return false;
		}

		private static int CalculateChecksumLuhn(string number)
		{
			int num = 0;
			for (int num2 = number.Length - 2; num2 >= 0; num2 -= 2)
			{
				int num3 = number[num2] - 48;
				num += num3;
			}
			for (int num4 = number.Length - 1; num4 >= 0; num4 -= 2)
			{
				int num5 = doubleAndCrossSum[number[num4] - 48];
				num += num5;
			}
			return (10 - num % 10) % 10;
		}
	}
	public sealed class MSIWriter : OneDimensionalCodeWriter
	{
		private static readonly int[] startWidths = new int[2] { 2, 1 };

		private static readonly int[] endWidths = new int[3] { 1, 2, 1 };

		private static readonly int[][] numberWidths = new int[10][]
		{
			new int[8] { 1, 2, 1, 2, 1, 2, 1, 2 },
			new int[8] { 1, 2, 1, 2, 1, 2, 2, 1 },
			new int[8] { 1, 2, 1, 2, 2, 1, 1, 2 },
			new int[8] { 1, 2, 1, 2, 2, 1, 2, 1 },
			new int[8] { 1, 2, 2, 1, 1, 2, 1, 2 },
			new int[8] { 1, 2, 2, 1, 1, 2, 2, 1 },
			new int[8] { 1, 2, 2, 1, 2, 1, 1, 2 },
			new int[8] { 1, 2, 2, 1, 2, 1, 2, 1 },
			new int[8] { 2, 1, 1, 2, 1, 2, 1, 2 },
			new int[8] { 2, 1, 1, 2, 1, 2, 2, 1 }
		};

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.MSI)
			{
				throw new ArgumentException("Can only encode MSI, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			for (int i = 0; i < length; i++)
			{
				if (MSIReader.ALPHABET_STRING.IndexOf(contents[i]) < 0)
				{
					throw new ArgumentException("Requested contents contains a not encodable character: '" + contents[i] + "'");
				}
			}
			bool[] array = new bool[3 + length * 12 + 4];
			int num = OneDimensionalCodeWriter.appendPattern(array, 0, startWidths, startColor: true);
			for (int j = 0; j < length; j++)
			{
				int num2 = MSIReader.ALPHABET_STRING.IndexOf(contents[j]);
				int[] pattern = numberWidths[num2];
				num += OneDimensionalCodeWriter.appendPattern(array, num, pattern, startColor: true);
			}
			OneDimensionalCodeWriter.appendPattern(array, num, endWidths, startColor: true);
			return array;
		}
	}
	public sealed class MultiFormatOneDReader : OneDReader
	{
		private readonly IList<OneDReader> readers;

		public MultiFormatOneDReader(IDictionary<DecodeHintType, object> hints)
		{
			IList<BarcodeFormat> list = ((hints == null || !hints.ContainsKey(DecodeHintType.POSSIBLE_FORMATS)) ? null : ((IList<BarcodeFormat>)hints[DecodeHintType.POSSIBLE_FORMATS]));
			readers = new List<OneDReader>();
			if (list != null)
			{
				if (list.Contains(BarcodeFormat.All_1D) || list.Contains(BarcodeFormat.EAN_13) || list.Contains(BarcodeFormat.UPC_A) || list.Contains(BarcodeFormat.EAN_8) || list.Contains(BarcodeFormat.UPC_E))
				{
					readers.Add(new MultiFormatUPCEANReader(hints));
				}
				if (list.Contains(BarcodeFormat.MSI))
				{
					bool usingCheckDigit = hints.ContainsKey(DecodeHintType.ASSUME_MSI_CHECK_DIGIT) && (bool)hints[DecodeHintType.ASSUME_MSI_CHECK_DIGIT];
					readers.Add(new MSIReader(usingCheckDigit));
				}
				if (list.Contains(BarcodeFormat.CODE_39) || list.Contains(BarcodeFormat.All_1D))
				{
					bool usingCheckDigit2 = hints.ContainsKey(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT) && (bool)hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT];
					bool extendedMode = hints.ContainsKey(DecodeHintType.USE_CODE_39_EXTENDED_MODE) && (bool)hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE];
					readers.Add(new Code39Reader(usingCheckDigit2, extendedMode));
				}
				if (list.Contains(BarcodeFormat.CODE_93) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new Code93Reader());
				}
				if (list.Contains(BarcodeFormat.CODE_128) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new Code128Reader());
				}
				if (list.Contains(BarcodeFormat.ITF) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new ITFReader());
				}
				if (list.Contains(BarcodeFormat.CODABAR) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new CodaBarReader());
				}
				if (list.Contains(BarcodeFormat.RSS_14) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new RSS14Reader());
				}
				if (list.Contains(BarcodeFormat.RSS_EXPANDED) || list.Contains(BarcodeFormat.All_1D))
				{
					readers.Add(new RSSExpandedReader());
				}
			}
			if (readers.Count == 0)
			{
				bool usingCheckDigit3 = hints != null && hints.ContainsKey(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT) && (bool)hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT];
				bool extendedMode2 = hints != null && hints.ContainsKey(DecodeHintType.USE_CODE_39_EXTENDED_MODE) && (bool)hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE];
				readers.Add(new MultiFormatUPCEANReader(hints));
				readers.Add(new Code39Reader(usingCheckDigit3, extendedMode2));
				readers.Add(new CodaBarReader());
				readers.Add(new Code93Reader());
				readers.Add(new Code128Reader());
				readers.Add(new ITFReader());
				readers.Add(new RSS14Reader());
				readers.Add(new RSSExpandedReader());
			}
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			foreach (OneDReader reader in readers)
			{
				Result result = reader.decodeRow(rowNumber, row, hints);
				if (result != null)
				{
					return result;
				}
			}
			return null;
		}

		public override void reset()
		{
			foreach (OneDReader reader in readers)
			{
				((Reader)reader).reset();
			}
		}
	}
	public sealed class MultiFormatUPCEANReader : OneDReader
	{
		private readonly UPCEANReader[] readers;

		public MultiFormatUPCEANReader(IDictionary<DecodeHintType, object> hints)
		{
			IList<BarcodeFormat> list = ((hints == null || !hints.ContainsKey(DecodeHintType.POSSIBLE_FORMATS)) ? null : ((IList<BarcodeFormat>)hints[DecodeHintType.POSSIBLE_FORMATS]));
			List<UPCEANReader> list2 = new List<UPCEANReader>();
			if (list != null)
			{
				if (list.Contains(BarcodeFormat.EAN_13) || list.Contains(BarcodeFormat.All_1D))
				{
					list2.Add(new EAN13Reader());
				}
				else if (list.Contains(BarcodeFormat.UPC_A) || list.Contains(BarcodeFormat.All_1D))
				{
					list2.Add(new UPCAReader());
				}
				if (list.Contains(BarcodeFormat.EAN_8) || list.Contains(BarcodeFormat.All_1D))
				{
					list2.Add(new EAN8Reader());
				}
				if (list.Contains(BarcodeFormat.UPC_E) || list.Contains(BarcodeFormat.All_1D))
				{
					list2.Add(new UPCEReader());
				}
			}
			if (list2.Count == 0)
			{
				list2.Add(new EAN13Reader());
				list2.Add(new EAN8Reader());
				list2.Add(new UPCEReader());
			}
			readers = list2.ToArray();
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			int[] array = UPCEANReader.findStartGuardPattern(row);
			if (array == null)
			{
				return null;
			}
			UPCEANReader[] array2 = readers;
			for (int i = 0; i < array2.Length; i++)
			{
				Result result = array2[i].decodeRow(rowNumber, row, array, hints);
				if (result != null)
				{
					bool num = result.BarcodeFormat == BarcodeFormat.EAN_13 && result.Text[0] == '0';
					IList<BarcodeFormat> list = ((hints == null || !hints.ContainsKey(DecodeHintType.POSSIBLE_FORMATS)) ? null : ((IList<BarcodeFormat>)hints[DecodeHintType.POSSIBLE_FORMATS]));
					bool flag = list == null || list.Contains(BarcodeFormat.UPC_A) || list.Contains(BarcodeFormat.All_1D);
					if (num && flag)
					{
						Result result2 = new Result(result.Text.Substring(1), result.RawBytes, result.ResultPoints, BarcodeFormat.UPC_A);
						result2.putAllMetadata(result.ResultMetadata);
						return result2;
					}
					return result;
				}
			}
			return null;
		}

		public override void reset()
		{
			UPCEANReader[] array = readers;
			for (int i = 0; i < array.Length; i++)
			{
				((Reader)array[i]).reset();
			}
		}
	}
	public abstract class OneDimensionalCodeWriter : Writer
	{
		public virtual int DefaultMargin => 10;

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public virtual BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (string.IsNullOrEmpty(contents))
			{
				throw new ArgumentException("Found empty contents");
			}
			if (width < 0 || height < 0)
			{
				throw new ArgumentException("Negative size is not allowed. Input: " + width + "x" + height);
			}
			int sidesMargin = DefaultMargin;
			if (hints != null)
			{
				object obj = (hints.ContainsKey(EncodeHintType.MARGIN) ? hints[EncodeHintType.MARGIN] : null);
				if (obj != null)
				{
					sidesMargin = Convert.ToInt32(obj);
				}
			}
			return renderResult(encode(contents), width, height, sidesMargin);
		}

		private static BitMatrix renderResult(bool[] code, int width, int height, int sidesMargin)
		{
			int num = code.Length;
			int num2 = num + sidesMargin;
			int num3 = Math.Max(width, num2);
			int height2 = Math.Max(1, height);
			int num4 = num3 / num2;
			int num5 = (num3 - num * num4) / 2;
			BitMatrix bitMatrix = new BitMatrix(num3, height2);
			int num6 = 0;
			int num7 = num5;
			while (num6 < num)
			{
				if (code[num6])
				{
					bitMatrix.setRegion(num7, 0, num4, height2);
				}
				num6++;
				num7 += num4;
			}
			return bitMatrix;
		}

		protected static int appendPattern(bool[] target, int pos, int[] pattern, bool startColor)
		{
			bool flag = startColor;
			int num = 0;
			foreach (int num2 in pattern)
			{
				for (int j = 0; j < num2; j++)
				{
					target[pos++] = flag;
				}
				num += num2;
				flag = !flag;
			}
			return num;
		}

		public abstract bool[] encode(string contents);

		public static string CalculateChecksumDigitModulo10(string contents)
		{
			int num = 0;
			int num2 = 0;
			for (int num3 = contents.Length - 1; num3 >= 0; num3 -= 2)
			{
				num += contents[num3] - 48;
			}
			for (int num4 = contents.Length - 2; num4 >= 0; num4 -= 2)
			{
				num2 += contents[num4] - 48;
			}
			return contents + (10 - (num * 3 + num2) % 10) % 10;
		}
	}
	public abstract class OneDReader : Reader
	{
		protected static int INTEGER_MATH_SHIFT = 8;

		protected static int PATTERN_MATCH_RESULT_SCALE_FACTOR = 1 << INTEGER_MATH_SHIFT;

		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public virtual Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			Result result = doDecode(image, hints);
			if (result == null)
			{
				bool num = hints?.ContainsKey(DecodeHintType.TRY_HARDER) ?? false;
				bool flag = hints?.ContainsKey(DecodeHintType.TRY_HARDER_WITHOUT_ROTATION) ?? false;
				if (num && !flag && image.RotateSupported)
				{
					BinaryBitmap binaryBitmap = image.rotateCounterClockwise();
					result = doDecode(binaryBitmap, hints);
					if (result == null)
					{
						return null;
					}
					IDictionary<ResultMetadataType, object> resultMetadata = result.ResultMetadata;
					int num2 = 270;
					if (resultMetadata != null && resultMetadata.ContainsKey(ResultMetadataType.ORIENTATION))
					{
						num2 = (num2 + (int)resultMetadata[ResultMetadataType.ORIENTATION]) % 360;
					}
					result.putMetadata(ResultMetadataType.ORIENTATION, num2);
					ResultPoint[] resultPoints = result.ResultPoints;
					if (resultPoints != null)
					{
						int height = binaryBitmap.Height;
						for (int i = 0; i < resultPoints.Length; i++)
						{
							resultPoints[i] = new ResultPoint((float)height - resultPoints[i].Y - 1f, resultPoints[i].X);
						}
					}
				}
			}
			return result;
		}

		public virtual void reset()
		{
		}

		protected virtual Result doDecode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			int width = image.Width;
			int height = image.Height;
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray(width);
			bool flag = hints?.ContainsKey(DecodeHintType.TRY_HARDER) ?? false;
			int num = Math.Max(1, height >> (flag ? 8 : 5));
			int num2 = ((!flag) ? 15 : height);
			int num3 = height >> 1;
			for (int i = 0; i < num2; i++)
			{
				int num4 = i + 1 >> 1;
				bool flag2 = (i & 1) == 0;
				int num5 = num3 + num * (flag2 ? num4 : (-num4));
				if (num5 < 0 || num5 >= height)
				{
					break;
				}
				bitArray = image.getBlackRow(num5, bitArray);
				if (bitArray == null)
				{
					continue;
				}
				for (int j = 0; j < 2; j++)
				{
					if (j == 1)
					{
						bitArray.reverse();
						if (hints != null && hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK))
						{
							IDictionary<DecodeHintType, object> dictionary = new Dictionary<DecodeHintType, object>();
							foreach (KeyValuePair<DecodeHintType, object> hint in hints)
							{
								if (hint.Key != DecodeHintType.NEED_RESULT_POINT_CALLBACK)
								{
									dictionary.Add(hint.Key, hint.Value);
								}
							}
							hints = dictionary;
						}
					}
					Result result = decodeRow(num5, bitArray, hints);
					if (result == null)
					{
						continue;
					}
					if (j == 1)
					{
						result.putMetadata(ResultMetadataType.ORIENTATION, 180);
						ResultPoint[] resultPoints = result.ResultPoints;
						if (resultPoints != null)
						{
							resultPoints[0] = new ResultPoint((float)width - resultPoints[0].X - 1f, resultPoints[0].Y);
							resultPoints[1] = new ResultPoint((float)width - resultPoints[1].X - 1f, resultPoints[1].Y);
						}
					}
					return result;
				}
			}
			return null;
		}

		protected static bool recordPattern(ZXing.Common.BitArray row, int start, int[] counters)
		{
			return recordPattern(row, start, counters, counters.Length);
		}

		protected static bool recordPattern(ZXing.Common.BitArray row, int start, int[] counters, int numCounters)
		{
			for (int i = 0; i < numCounters; i++)
			{
				counters[i] = 0;
			}
			int size = row.Size;
			if (start >= size)
			{
				return false;
			}
			bool flag = !row[start];
			int num = 0;
			int j;
			for (j = start; j < size; j++)
			{
				if (row[j] != flag)
				{
					counters[num]++;
					continue;
				}
				num++;
				if (num == numCounters)
				{
					break;
				}
				counters[num] = 1;
				flag = !flag;
			}
			if (num != numCounters)
			{
				if (num == numCounters - 1)
				{
					return j == size;
				}
				return false;
			}
			return true;
		}

		protected static bool recordPatternInReverse(ZXing.Common.BitArray row, int start, int[] counters)
		{
			int num = counters.Length;
			bool flag = row[start];
			while (start > 0 && num >= 0)
			{
				if (row[--start] != flag)
				{
					num--;
					flag = !flag;
				}
			}
			if (num >= 0)
			{
				return false;
			}
			return recordPattern(row, start + 1, counters);
		}

		protected static int patternMatchVariance(int[] counters, int[] pattern, int maxIndividualVariance)
		{
			int num = counters.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				num2 += counters[i];
				num3 += pattern[i];
			}
			if (num2 < num3)
			{
				return 2147483647;
			}
			int num4 = (num2 << INTEGER_MATH_SHIFT) / num3;
			maxIndividualVariance = maxIndividualVariance * num4 >> INTEGER_MATH_SHIFT;
			int num5 = 0;
			for (int j = 0; j < num; j++)
			{
				int num6 = counters[j] << INTEGER_MATH_SHIFT;
				int num7 = pattern[j] * num4;
				int num8 = ((num6 > num7) ? (num6 - num7) : (num7 - num6));
				if (num8 > maxIndividualVariance)
				{
					return 2147483647;
				}
				num5 += num8;
			}
			return num5 / num2;
		}

		public abstract Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints);
	}
	public sealed class PlesseyWriter : OneDimensionalCodeWriter
	{
		private const string ALPHABET_STRING = "0123456789ABCDEF";

		private static readonly int[] startWidths = new int[8] { 14, 11, 14, 11, 5, 20, 14, 11 };

		private static readonly int[] terminationWidths = new int[1] { 25 };

		private static readonly int[] endWidths = new int[8] { 20, 5, 20, 5, 14, 11, 14, 11 };

		private static readonly int[][] numberWidths = new int[16][]
		{
			new int[8] { 5, 20, 5, 20, 5, 20, 5, 20 },
			new int[8] { 14, 11, 5, 20, 5, 20, 5, 20 },
			new int[8] { 5, 20, 14, 11, 5, 20, 5, 20 },
			new int[8] { 14, 11, 14, 11, 5, 20, 5, 20 },
			new int[8] { 5, 20, 5, 20, 14, 11, 5, 20 },
			new int[8] { 14, 11, 5, 20, 14, 11, 5, 20 },
			new int[8] { 5, 20, 14, 11, 14, 11, 5, 20 },
			new int[8] { 14, 11, 14, 11, 14, 11, 5, 20 },
			new int[8] { 5, 20, 5, 20, 5, 20, 14, 11 },
			new int[8] { 14, 11, 5, 20, 5, 20, 14, 11 },
			new int[8] { 5, 20, 14, 11, 5, 20, 14, 11 },
			new int[8] { 14, 11, 14, 11, 5, 20, 14, 11 },
			new int[8] { 5, 20, 5, 20, 14, 11, 14, 11 },
			new int[8] { 14, 11, 5, 20, 14, 11, 14, 11 },
			new int[8] { 5, 20, 14, 11, 14, 11, 14, 11 },
			new int[8] { 14, 11, 14, 11, 14, 11, 14, 11 }
		};

		private static readonly byte[] crcGrid = new byte[9] { 1, 1, 1, 1, 0, 1, 0, 0, 1 };

		private static readonly int[] crc0Widths = new int[2] { 5, 20 };

		private static readonly int[] crc1Widths = new int[2] { 14, 11 };

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.PLESSEY)
			{
				throw new ArgumentException("Can only encode Plessey, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			for (int i = 0; i < length; i++)
			{
				if ("0123456789ABCDEF".IndexOf(contents[i]) < 0)
				{
					throw new ArgumentException("Requested contents contains a not encodable character: '" + contents[i] + "'");
				}
			}
			bool[] array = new bool[200 + length * 100 + 200 + 25 + 100 + 100];
			byte[] array2 = new byte[4 * length + 8];
			int num = 0;
			int num2 = 100;
			num2 += OneDimensionalCodeWriter.appendPattern(array, num2, startWidths, startColor: true);
			for (int j = 0; j < length; j++)
			{
				int num3 = "0123456789ABCDEF".IndexOf(contents[j]);
				int[] pattern = numberWidths[num3];
				num2 += OneDimensionalCodeWriter.appendPattern(array, num2, pattern, startColor: true);
				array2[num++] = (byte)(num3 & 1);
				array2[num++] = (byte)((num3 >> 1) & 1);
				array2[num++] = (byte)((num3 >> 2) & 1);
				array2[num++] = (byte)((num3 >> 3) & 1);
			}
			for (int k = 0; k < 4 * length; k++)
			{
				if (array2[k] != 0)
				{
					for (int l = 0; l < 9; l++)
					{
						array2[k + l] ^= crcGrid[l];
					}
				}
			}
			for (int m = 0; m < 8; m++)
			{
				switch (array2[length * 4 + m])
				{
				case 0:
					num2 += OneDimensionalCodeWriter.appendPattern(array, num2, crc0Widths, startColor: true);
					break;
				case 1:
					num2 += OneDimensionalCodeWriter.appendPattern(array, num2, crc1Widths, startColor: true);
					break;
				}
			}
			num2 += OneDimensionalCodeWriter.appendPattern(array, num2, terminationWidths, startColor: true);
			OneDimensionalCodeWriter.appendPattern(array, num2, endWidths, startColor: false);
			return array;
		}
	}
	public sealed class UPCAReader : UPCEANReader
	{
		private readonly UPCEANReader ean13Reader = new EAN13Reader();

		internal override BarcodeFormat BarcodeFormat => BarcodeFormat.UPC_A;

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, int[] startGuardRange, IDictionary<DecodeHintType, object> hints)
		{
			return maybeReturnResult(ean13Reader.decodeRow(rowNumber, row, startGuardRange, hints));
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			return maybeReturnResult(ean13Reader.decodeRow(rowNumber, row, hints));
		}

		public override Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			return maybeReturnResult(ean13Reader.decode(image, hints));
		}

		protected internal override int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder resultString)
		{
			return ean13Reader.decodeMiddle(row, startRange, resultString);
		}

		private static Result maybeReturnResult(Result result)
		{
			if (result == null)
			{
				return null;
			}
			string text = result.Text;
			if (text[0] == '0')
			{
				return new Result(text.Substring(1), null, result.ResultPoints, BarcodeFormat.UPC_A);
			}
			return null;
		}
	}
	public class UPCAWriter : Writer
	{
		private readonly EAN13Writer subWriter = new EAN13Writer();

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.UPC_A)
			{
				throw new ArgumentException("Can only encode UPC-A, but got " + format);
			}
			return subWriter.encode("0" + contents, BarcodeFormat.EAN_13, width, height, hints);
		}
	}
	internal sealed class UPCEANExtension2Support
	{
		private readonly int[] decodeMiddleCounters = new int[4];

		private readonly StringBuilder decodeRowStringBuffer = new StringBuilder();

		internal Result decodeRow(int rowNumber, ZXing.Common.BitArray row, int[] extensionStartRange)
		{
			StringBuilder stringBuilder = decodeRowStringBuffer;
			stringBuilder.Length = 0;
			int num = decodeMiddle(row, extensionStartRange, stringBuilder);
			if (num < 0)
			{
				return null;
			}
			string text = stringBuilder.ToString();
			IDictionary<ResultMetadataType, object> dictionary = parseExtensionString(text);
			Result result = new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint((float)(extensionStartRange[0] + extensionStartRange[1]) / 2f, rowNumber),
				new ResultPoint(num, rowNumber)
			}, BarcodeFormat.UPC_EAN_EXTENSION);
			if (dictionary != null)
			{
				result.putAllMetadata(dictionary);
			}
			return result;
		}

		private int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder resultString)
		{
			int[] array = decodeMiddleCounters;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int num = startRange[1];
			int num2 = 0;
			for (int i = 0; i < 2; i++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_AND_G_PATTERNS, out var digit))
				{
					return -1;
				}
				resultString.Append((char)(48 + digit % 10));
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
				if (digit >= 10)
				{
					num2 |= 1 << 1 - i;
				}
				if (i != 1)
				{
					num = row.getNextSet(num);
					num = row.getNextUnset(num);
				}
			}
			if (resultString.Length != 2)
			{
				return -1;
			}
			if (int.Parse(resultString.ToString()) % 4 != num2)
			{
				return -1;
			}
			return num;
		}

		private static IDictionary<ResultMetadataType, object> parseExtensionString(string raw)
		{
			if (raw.Length != 2)
			{
				return null;
			}
			return new Dictionary<ResultMetadataType, object> { [ResultMetadataType.ISSUE_NUMBER] = Convert.ToInt32(raw) };
		}
	}
	internal sealed class UPCEANExtension5Support
	{
		private static readonly int[] CHECK_DIGIT_ENCODINGS = new int[10] { 24, 20, 18, 17, 12, 6, 3, 10, 9, 5 };

		private readonly int[] decodeMiddleCounters = new int[4];

		private readonly StringBuilder decodeRowStringBuffer = new StringBuilder();

		internal Result decodeRow(int rowNumber, ZXing.Common.BitArray row, int[] extensionStartRange)
		{
			StringBuilder stringBuilder = decodeRowStringBuffer;
			stringBuilder.Length = 0;
			int num = decodeMiddle(row, extensionStartRange, stringBuilder);
			if (num < 0)
			{
				return null;
			}
			string text = stringBuilder.ToString();
			IDictionary<ResultMetadataType, object> dictionary = parseExtensionString(text);
			Result result = new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint((float)(extensionStartRange[0] + extensionStartRange[1]) / 2f, rowNumber),
				new ResultPoint(num, rowNumber)
			}, BarcodeFormat.UPC_EAN_EXTENSION);
			if (dictionary != null)
			{
				result.putAllMetadata(dictionary);
			}
			return result;
		}

		private int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder resultString)
		{
			int[] array = decodeMiddleCounters;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int num = startRange[1];
			int num2 = 0;
			for (int i = 0; i < 5; i++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_AND_G_PATTERNS, out var digit))
				{
					return -1;
				}
				resultString.Append((char)(48 + digit % 10));
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
				if (digit >= 10)
				{
					num2 |= 1 << 4 - i;
				}
				if (i != 4)
				{
					num = row.getNextSet(num);
					num = row.getNextUnset(num);
				}
			}
			if (resultString.Length != 5)
			{
				return -1;
			}
			if (!determineCheckDigit(num2, out var checkDigit))
			{
				return -1;
			}
			if (extensionChecksum(resultString.ToString()) != checkDigit)
			{
				return -1;
			}
			return num;
		}

		private static int extensionChecksum(string s)
		{
			int length = s.Length;
			int num = 0;
			for (int num2 = length - 2; num2 >= 0; num2 -= 2)
			{
				num += s[num2] - 48;
			}
			num *= 3;
			for (int num3 = length - 1; num3 >= 0; num3 -= 2)
			{
				num += s[num3] - 48;
			}
			num *= 3;
			return num % 10;
		}

		private static bool determineCheckDigit(int lgPatternFound, out int checkDigit)
		{
			for (checkDigit = 0; checkDigit < 10; checkDigit++)
			{
				if (lgPatternFound == CHECK_DIGIT_ENCODINGS[checkDigit])
				{
					return true;
				}
			}
			return false;
		}

		private static IDictionary<ResultMetadataType, object> parseExtensionString(string raw)
		{
			if (raw.Length != 5)
			{
				return null;
			}
			object obj = parseExtension5String(raw);
			if (obj == null)
			{
				return null;
			}
			return new Dictionary<ResultMetadataType, object> { [ResultMetadataType.SUGGESTED_PRICE] = obj };
		}

		private static string parseExtension5String(string raw)
		{
			string text;
			switch (raw[0])
			{
			case '0':
				text = "£";
				break;
			case '5':
				text = "$";
				break;
			case '9':
				if ("90000".Equals(raw))
				{
					return null;
				}
				if ("99991".Equals(raw))
				{
					return "0.00";
				}
				if ("99990".Equals(raw))
				{
					return "Used";
				}
				text = "";
				break;
			default:
				text = "";
				break;
			}
			int num = int.Parse(raw.Substring(1));
			string text2 = (num / 100).ToString();
			int num2 = num % 100;
			string text3 = ((num2 < 10) ? ("0" + num2) : num2.ToString());
			return text + text2 + "." + text3;
		}
	}
	internal sealed class UPCEANExtensionSupport
	{
		private static readonly int[] EXTENSION_START_PATTERN = new int[3] { 1, 1, 2 };

		private readonly UPCEANExtension2Support twoSupport = new UPCEANExtension2Support();

		private readonly UPCEANExtension5Support fiveSupport = new UPCEANExtension5Support();

		internal Result decodeRow(int rowNumber, ZXing.Common.BitArray row, int rowOffset)
		{
			int[] array = UPCEANReader.findGuardPattern(row, rowOffset, whiteFirst: false, EXTENSION_START_PATTERN);
			if (array == null)
			{
				return null;
			}
			Result result = fiveSupport.decodeRow(rowNumber, row, array);
			if (result == null)
			{
				result = twoSupport.decodeRow(rowNumber, row, array);
			}
			return result;
		}
	}
	public abstract class UPCEANReader : OneDReader
	{
		private static readonly int MAX_AVG_VARIANCE;

		private static readonly int MAX_INDIVIDUAL_VARIANCE;

		internal static int[] START_END_PATTERN;

		internal static int[] MIDDLE_PATTERN;

		internal static int[] END_PATTERN;

		internal static int[][] L_PATTERNS;

		internal static int[][] L_AND_G_PATTERNS;

		private readonly StringBuilder decodeRowStringBuffer;

		private readonly UPCEANExtensionSupport extensionReader;

		private readonly EANManufacturerOrgSupport eanManSupport;

		internal abstract BarcodeFormat BarcodeFormat { get; }

		static UPCEANReader()
		{
			MAX_AVG_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.48f);
			MAX_INDIVIDUAL_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.7f);
			START_END_PATTERN = new int[3] { 1, 1, 1 };
			MIDDLE_PATTERN = new int[5] { 1, 1, 1, 1, 1 };
			END_PATTERN = new int[6] { 1, 1, 1, 1, 1, 1 };
			L_PATTERNS = new int[10][]
			{
				new int[4] { 3, 2, 1, 1 },
				new int[4] { 2, 2, 2, 1 },
				new int[4] { 2, 1, 2, 2 },
				new int[4] { 1, 4, 1, 1 },
				new int[4] { 1, 1, 3, 2 },
				new int[4] { 1, 2, 3, 1 },
				new int[4] { 1, 1, 1, 4 },
				new int[4] { 1, 3, 1, 2 },
				new int[4] { 1, 2, 1, 3 },
				new int[4] { 3, 1, 1, 2 }
			};
			L_AND_G_PATTERNS = new int[20][];
			Array.Copy(L_PATTERNS, 0, L_AND_G_PATTERNS, 0, 10);
			for (int i = 10; i < 20; i++)
			{
				int[] array = L_PATTERNS[i - 10];
				int[] array2 = new int[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = array[array.Length - j - 1];
				}
				L_AND_G_PATTERNS[i] = array2;
			}
		}

		protected UPCEANReader()
		{
			decodeRowStringBuffer = new StringBuilder(20);
			extensionReader = new UPCEANExtensionSupport();
			eanManSupport = new EANManufacturerOrgSupport();
		}

		internal static int[] findStartGuardPattern(ZXing.Common.BitArray row)
		{
			bool flag = false;
			int[] array = null;
			int num = 0;
			int[] array2 = new int[START_END_PATTERN.Length];
			while (!flag)
			{
				for (int i = 0; i < START_END_PATTERN.Length; i++)
				{
					array2[i] = 0;
				}
				array = findGuardPattern(row, num, whiteFirst: false, START_END_PATTERN, array2);
				if (array == null)
				{
					return null;
				}
				int num2 = array[0];
				num = array[1];
				int num3 = num2 - (num - num2);
				if (num3 >= 0)
				{
					flag = row.isRange(num3, num2, value: false);
				}
			}
			return array;
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			return decodeRow(rowNumber, row, findStartGuardPattern(row), hints);
		}

		public virtual Result decodeRow(int rowNumber, ZXing.Common.BitArray row, int[] startGuardRange, IDictionary<DecodeHintType, object> hints)
		{
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			resultPointCallback?.Invoke(new ResultPoint((float)(startGuardRange[0] + startGuardRange[1]) / 2f, rowNumber));
			StringBuilder stringBuilder = decodeRowStringBuffer;
			stringBuilder.Length = 0;
			int num = decodeMiddle(row, startGuardRange, stringBuilder);
			if (num < 0)
			{
				return null;
			}
			resultPointCallback?.Invoke(new ResultPoint(num, rowNumber));
			int[] array = decodeEnd(row, num);
			if (array == null)
			{
				return null;
			}
			resultPointCallback?.Invoke(new ResultPoint((float)(array[0] + array[1]) / 2f, rowNumber));
			int num2 = array[1];
			int num3 = num2 + (num2 - array[0]);
			if (num3 >= row.Size || !row.isRange(num2, num3, value: false))
			{
				return null;
			}
			string text = stringBuilder.ToString();
			if (text.Length < 8)
			{
				return null;
			}
			if (!checkChecksum(text))
			{
				return null;
			}
			float x = (float)(startGuardRange[1] + startGuardRange[0]) / 2f;
			float x2 = (float)(array[1] + array[0]) / 2f;
			BarcodeFormat barcodeFormat = BarcodeFormat;
			Result result = new Result(text, null, new ResultPoint[2]
			{
				new ResultPoint(x, rowNumber),
				new ResultPoint(x2, rowNumber)
			}, barcodeFormat);
			Result result2 = extensionReader.decodeRow(rowNumber, row, array[1]);
			if (result2 != null)
			{
				result.putMetadata(ResultMetadataType.UPC_EAN_EXTENSION, result2.Text);
				result.putAllMetadata(result2.ResultMetadata);
				result.addResultPoints(result2.ResultPoints);
				int length = result2.Text.Length;
				int[] array2 = ((hints != null && hints.ContainsKey(DecodeHintType.ALLOWED_EAN_EXTENSIONS)) ? ((int[])hints[DecodeHintType.ALLOWED_EAN_EXTENSIONS]) : null);
				if (array2 != null)
				{
					bool flag = false;
					int[] array3 = array2;
					foreach (int num4 in array3)
					{
						if (length == num4)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return null;
					}
				}
			}
			if (barcodeFormat == BarcodeFormat.EAN_13 || barcodeFormat == BarcodeFormat.UPC_A)
			{
				string text2 = eanManSupport.lookupCountryIdentifier(text);
				if (text2 != null)
				{
					result.putMetadata(ResultMetadataType.POSSIBLE_COUNTRY, text2);
				}
			}
			return result;
		}

		protected virtual bool checkChecksum(string s)
		{
			return checkStandardUPCEANChecksum(s);
		}

		internal static bool checkStandardUPCEANChecksum(string s)
		{
			int length = s.Length;
			if (length == 0)
			{
				return false;
			}
			int num = s[length - 1] - 48;
			return getStandardUPCEANChecksum(s.Substring(0, length - 1)) == num;
		}

		internal static int? getStandardUPCEANChecksum(string s)
		{
			int length = s.Length;
			int num = 0;
			for (int num2 = length - 1; num2 >= 0; num2 -= 2)
			{
				int num3 = s[num2] - 48;
				if (num3 < 0 || num3 > 9)
				{
					throw new ArgumentException("Contents should only contain digits, but got '" + s[num2] + "'");
				}
				num += num3;
			}
			num *= 3;
			for (int num4 = length - 2; num4 >= 0; num4 -= 2)
			{
				int num5 = s[num4] - 48;
				if (num5 < 0 || num5 > 9)
				{
					throw new ArgumentException("Contents should only contain digits, but got '" + s[num4] + "'");
				}
				num += num5;
			}
			return (1000 - num) % 10;
		}

		protected virtual int[] decodeEnd(ZXing.Common.BitArray row, int endStart)
		{
			return findGuardPattern(row, endStart, whiteFirst: false, START_END_PATTERN);
		}

		internal static int[] findGuardPattern(ZXing.Common.BitArray row, int rowOffset, bool whiteFirst, int[] pattern)
		{
			return findGuardPattern(row, rowOffset, whiteFirst, pattern, new int[pattern.Length]);
		}

		internal static int[] findGuardPattern(ZXing.Common.BitArray row, int rowOffset, bool whiteFirst, int[] pattern, int[] counters)
		{
			int num = pattern.Length;
			int size = row.Size;
			bool flag = whiteFirst;
			rowOffset = (whiteFirst ? row.getNextUnset(rowOffset) : row.getNextSet(rowOffset));
			int num2 = 0;
			int num3 = rowOffset;
			for (int i = rowOffset; i < size; i++)
			{
				if (row[i] != flag)
				{
					counters[num2]++;
					continue;
				}
				if (num2 == num - 1)
				{
					if (OneDReader.patternMatchVariance(counters, pattern, MAX_INDIVIDUAL_VARIANCE) < MAX_AVG_VARIANCE)
					{
						return new int[2] { num3, i };
					}
					num3 += counters[0] + counters[1];
					Array.Copy(counters, 2, counters, 0, num2 - 1);
					counters[num2 - 1] = 0;
					counters[num2] = 0;
					num2--;
				}
				else
				{
					num2++;
				}
				counters[num2] = 1;
				flag = !flag;
			}
			return null;
		}

		internal static bool decodeDigit(ZXing.Common.BitArray row, int[] counters, int rowOffset, int[][] patterns, out int digit)
		{
			digit = -1;
			if (!OneDReader.recordPattern(row, rowOffset, counters))
			{
				return false;
			}
			int num = MAX_AVG_VARIANCE;
			int num2 = patterns.Length;
			for (int i = 0; i < num2; i++)
			{
				int[] pattern = patterns[i];
				int num3 = OneDReader.patternMatchVariance(counters, pattern, MAX_INDIVIDUAL_VARIANCE);
				if (num3 < num)
				{
					num = num3;
					digit = i;
				}
			}
			return digit >= 0;
		}

		protected internal abstract int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder resultString);
	}
	public abstract class UPCEANWriter : OneDimensionalCodeWriter
	{
		public override int DefaultMargin => 9;
	}
	public sealed class UPCEReader : UPCEANReader
	{
		private static readonly int[] MIDDLE_END_PATTERN = new int[6] { 1, 1, 1, 1, 1, 1 };

		internal static readonly int[][] NUMSYS_AND_CHECK_DIGIT_PATTERNS = new int[2][]
		{
			new int[10] { 56, 52, 50, 49, 44, 38, 35, 42, 41, 37 },
			new int[10] { 7, 11, 13, 14, 19, 25, 28, 21, 22, 26 }
		};

		private readonly int[] decodeMiddleCounters;

		internal override BarcodeFormat BarcodeFormat => BarcodeFormat.UPC_E;

		public UPCEReader()
		{
			decodeMiddleCounters = new int[4];
		}

		protected internal override int decodeMiddle(ZXing.Common.BitArray row, int[] startRange, StringBuilder result)
		{
			int[] array = decodeMiddleCounters;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int num = startRange[1];
			int num2 = 0;
			for (int i = 0; i < 6; i++)
			{
				if (num >= size)
				{
					break;
				}
				if (!UPCEANReader.decodeDigit(row, array, num, UPCEANReader.L_AND_G_PATTERNS, out var digit))
				{
					return -1;
				}
				result.Append((char)(48 + digit % 10));
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					num += num3;
				}
				if (digit >= 10)
				{
					num2 |= 1 << 5 - i;
				}
			}
			if (!determineNumSysAndCheckDigit(result, num2))
			{
				return -1;
			}
			return num;
		}

		protected override int[] decodeEnd(ZXing.Common.BitArray row, int endStart)
		{
			return UPCEANReader.findGuardPattern(row, endStart, whiteFirst: true, MIDDLE_END_PATTERN);
		}

		protected override bool checkChecksum(string s)
		{
			return base.checkChecksum(convertUPCEtoUPCA(s));
		}

		private static bool determineNumSysAndCheckDigit(StringBuilder resultString, int lgPatternFound)
		{
			for (int i = 0; i <= 1; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (lgPatternFound == NUMSYS_AND_CHECK_DIGIT_PATTERNS[i][j])
					{
						resultString.Insert(0, new char[1] { (char)(48 + i) });
						resultString.Append((char)(48 + j));
						return true;
					}
				}
			}
			return false;
		}

		public static string convertUPCEtoUPCA(string upce)
		{
			string text = upce.Substring(1, 6);
			StringBuilder stringBuilder = new StringBuilder(12);
			stringBuilder.Append(upce[0]);
			char c = text[5];
			switch (c)
			{
			case '0':
			case '1':
			case '2':
				stringBuilder.Append(text, 0, 2);
				stringBuilder.Append(c);
				stringBuilder.Append("0000");
				stringBuilder.Append(text, 2, 3);
				break;
			case '3':
				stringBuilder.Append(text, 0, 3);
				stringBuilder.Append("00000");
				stringBuilder.Append(text, 3, 2);
				break;
			case '4':
				stringBuilder.Append(text, 0, 4);
				stringBuilder.Append("00000");
				stringBuilder.Append(text[4]);
				break;
			default:
				stringBuilder.Append(text, 0, 5);
				stringBuilder.Append("0000");
				stringBuilder.Append(c);
				break;
			}
			if (upce.Length >= 8)
			{
				stringBuilder.Append(upce[7]);
			}
			return stringBuilder.ToString();
		}
	}
	public class UPCEWriter : UPCEANWriter
	{
		private const int CODE_WIDTH = 51;

		public override BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (format != BarcodeFormat.UPC_E)
			{
				throw new ArgumentException("Can only encode UPC_E, but got " + format);
			}
			return base.encode(contents, format, width, height, hints);
		}

		public override bool[] encode(string contents)
		{
			int length = contents.Length;
			switch (length)
			{
			case 7:
			{
				int? standardUPCEANChecksum = UPCEANReader.getStandardUPCEANChecksum(UPCEReader.convertUPCEtoUPCA(contents));
				if (!standardUPCEANChecksum.HasValue)
				{
					throw new ArgumentException("Checksum can't be calculated");
				}
				contents += standardUPCEANChecksum.Value;
				break;
			}
			case 8:
				try
				{
					if (!UPCEANReader.checkStandardUPCEANChecksum(contents))
					{
						throw new ArgumentException("Contents do not pass checksum");
					}
				}
				catch (FormatException innerException)
				{
					throw new ArgumentException("Illegal contents", innerException);
				}
				break;
			default:
				throw new ArgumentException("Requested contents should be 8 digits long, but got " + length);
			}
			int num = int.Parse(contents.Substring(0, 1));
			if (num != 0 && num != 1)
			{
				throw new ArgumentException("Number system must be 0 or 1");
			}
			int num2 = int.Parse(contents.Substring(7, 1));
			int num3 = UPCEReader.NUMSYS_AND_CHECK_DIGIT_PATTERNS[num][num2];
			bool[] array = new bool[51];
			int num4 = 0;
			num4 += OneDimensionalCodeWriter.appendPattern(array, num4, UPCEANReader.START_END_PATTERN, startColor: true);
			for (int i = 1; i <= 6; i++)
			{
				int num5 = int.Parse(contents.Substring(i, 1));
				if (((num3 >> 6 - i) & 1) == 1)
				{
					num5 += 10;
				}
				num4 += OneDimensionalCodeWriter.appendPattern(array, num4, UPCEANReader.L_AND_G_PATTERNS[num5], startColor: false);
			}
			OneDimensionalCodeWriter.appendPattern(array, num4, UPCEANReader.END_PATTERN, startColor: false);
			return array;
		}
	}
}
namespace ZXing.OneD.RSS
{
	public abstract class AbstractRSSReader : OneDReader
	{
		private static readonly int MAX_AVG_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.2f);

		private static readonly int MAX_INDIVIDUAL_VARIANCE = (int)((float)OneDReader.PATTERN_MATCH_RESULT_SCALE_FACTOR * 0.45f);

		private const float MIN_FINDER_PATTERN_RATIO = 19f / 24f;

		private const float MAX_FINDER_PATTERN_RATIO = 25f / 28f;

		private readonly int[] decodeFinderCounters;

		private readonly int[] dataCharacterCounters;

		private readonly float[] oddRoundingErrors;

		private readonly float[] evenRoundingErrors;

		private readonly int[] oddCounts;

		private readonly int[] evenCounts;

		protected AbstractRSSReader()
		{
			decodeFinderCounters = new int[4];
			dataCharacterCounters = new int[8];
			oddRoundingErrors = new float[4];
			evenRoundingErrors = new float[4];
			oddCounts = new int[dataCharacterCounters.Length / 2];
			evenCounts = new int[dataCharacterCounters.Length / 2];
		}

		protected int[] getDecodeFinderCounters()
		{
			return decodeFinderCounters;
		}

		protected int[] getDataCharacterCounters()
		{
			return dataCharacterCounters;
		}

		protected float[] getOddRoundingErrors()
		{
			return oddRoundingErrors;
		}

		protected float[] getEvenRoundingErrors()
		{
			return evenRoundingErrors;
		}

		protected int[] getOddCounts()
		{
			return oddCounts;
		}

		protected int[] getEvenCounts()
		{
			return evenCounts;
		}

		protected static bool parseFinderValue(int[] counters, int[][] finderPatterns, out int value)
		{
			for (value = 0; value < finderPatterns.Length; value++)
			{
				if (OneDReader.patternMatchVariance(counters, finderPatterns[value], MAX_INDIVIDUAL_VARIANCE) < MAX_AVG_VARIANCE)
				{
					return true;
				}
			}
			return false;
		}

		[Obsolete]
		protected static int count(int[] array)
		{
			return MathUtils.sum(array);
		}

		protected static void increment(int[] array, float[] errors)
		{
			int num = 0;
			float num2 = errors[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (errors[i] > num2)
				{
					num2 = errors[i];
					num = i;
				}
			}
			array[num]++;
		}

		protected static void decrement(int[] array, float[] errors)
		{
			int num = 0;
			float num2 = errors[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (errors[i] < num2)
				{
					num2 = errors[i];
					num = i;
				}
			}
			array[num]--;
		}

		protected static bool isFinderPattern(int[] counters)
		{
			int num = counters[0] + counters[1];
			int num2 = num + counters[2] + counters[3];
			float num3 = (float)num / (float)num2;
			if (num3 >= 19f / 24f && num3 <= 25f / 28f)
			{
				int num4 = 2147483647;
				int num5 = -2147483648;
				foreach (int num6 in counters)
				{
					if (num6 > num5)
					{
						num5 = num6;
					}
					if (num6 < num4)
					{
						num4 = num6;
					}
				}
				return num5 < 10 * num4;
			}
			return false;
		}
	}
	public class DataCharacter
	{
		public int Value { get; private set; }

		public int ChecksumPortion { get; private set; }

		public DataCharacter(int value, int checksumPortion)
		{
			Value = value;
			ChecksumPortion = checksumPortion;
		}

		public override string ToString()
		{
			return Value + "(" + ChecksumPortion + ")";
		}

		public override bool Equals(object o)
		{
			if (!(o is DataCharacter))
			{
				return false;
			}
			DataCharacter dataCharacter = (DataCharacter)o;
			if (Value == dataCharacter.Value)
			{
				return ChecksumPortion == dataCharacter.ChecksumPortion;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Value ^ ChecksumPortion;
		}
	}
	public sealed class FinderPattern
	{
		public int Value { get; private set; }

		public int[] StartEnd { get; private set; }

		public ResultPoint[] ResultPoints { get; private set; }

		public FinderPattern(int value, int[] startEnd, int start, int end, int rowNumber)
		{
			Value = value;
			StartEnd = startEnd;
			ResultPoints = new ResultPoint[2]
			{
				new ResultPoint(start, rowNumber),
				new ResultPoint(end, rowNumber)
			};
		}

		public override bool Equals(object o)
		{
			if (!(o is FinderPattern))
			{
				return false;
			}
			FinderPattern finderPattern = (FinderPattern)o;
			return Value == finderPattern.Value;
		}

		public override int GetHashCode()
		{
			return Value;
		}
	}
	internal sealed class Pair : DataCharacter
	{
		public FinderPattern FinderPattern { get; private set; }

		public int Count { get; private set; }

		internal Pair(int value, int checksumPortion, FinderPattern finderPattern)
			: base(value, checksumPortion)
		{
			FinderPattern = finderPattern;
		}

		public void incrementCount()
		{
			Count++;
		}
	}
	public sealed class RSS14Reader : AbstractRSSReader
	{
		private static readonly int[] OUTSIDE_EVEN_TOTAL_SUBSET = new int[5] { 1, 10, 34, 70, 126 };

		private static readonly int[] INSIDE_ODD_TOTAL_SUBSET = new int[4] { 4, 20, 48, 81 };

		private static readonly int[] OUTSIDE_GSUM = new int[5] { 0, 161, 961, 2015, 2715 };

		private static readonly int[] INSIDE_GSUM = new int[4] { 0, 336, 1036, 1516 };

		private static readonly int[] OUTSIDE_ODD_WIDEST = new int[5] { 8, 6, 4, 3, 1 };

		private static readonly int[] INSIDE_ODD_WIDEST = new int[4] { 2, 4, 6, 8 };

		private static readonly int[][] FINDER_PATTERNS = new int[9][]
		{
			new int[4] { 3, 8, 2, 1 },
			new int[4] { 3, 5, 5, 1 },
			new int[4] { 3, 3, 7, 1 },
			new int[4] { 3, 1, 9, 1 },
			new int[4] { 2, 7, 4, 1 },
			new int[4] { 2, 5, 6, 1 },
			new int[4] { 2, 3, 8, 1 },
			new int[4] { 1, 5, 7, 1 },
			new int[4] { 1, 3, 9, 1 }
		};

		private readonly List<Pair> possibleLeftPairs;

		private readonly List<Pair> possibleRightPairs;

		public RSS14Reader()
		{
			possibleLeftPairs = new List<Pair>();
			possibleRightPairs = new List<Pair>();
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			Pair pair = decodePair(row, right: false, rowNumber, hints);
			addOrTally(possibleLeftPairs, pair);
			row.reverse();
			Pair pair2 = decodePair(row, right: true, rowNumber, hints);
			addOrTally(possibleRightPairs, pair2);
			row.reverse();
			int num = possibleLeftPairs.Count;
			for (int i = 0; i < num; i++)
			{
				Pair pair3 = possibleLeftPairs[i];
				if (pair3.Count <= 1)
				{
					continue;
				}
				int num2 = possibleRightPairs.Count;
				for (int j = 0; j < num2; j++)
				{
					Pair pair4 = possibleRightPairs[j];
					if (pair4.Count > 1 && checkChecksum(pair3, pair4))
					{
						return constructResult(pair3, pair4);
					}
				}
			}
			return null;
		}

		private static void addOrTally(IList<Pair> possiblePairs, Pair pair)
		{
			if (pair == null)
			{
				return;
			}
			bool flag = false;
			foreach (Pair possiblePair in possiblePairs)
			{
				if (possiblePair.Value == pair.Value)
				{
					possiblePair.incrementCount();
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				possiblePairs.Add(pair);
			}
		}

		public override void reset()
		{
			possibleLeftPairs.Clear();
			possibleRightPairs.Clear();
		}

		private static Result constructResult(Pair leftPair, Pair rightPair)
		{
			string text = (4537077L * (long)leftPair.Value + rightPair.Value).ToString();
			StringBuilder stringBuilder = new StringBuilder(14);
			for (int num = 13 - text.Length; num > 0; num--)
			{
				stringBuilder.Append('0');
			}
			stringBuilder.Append(text);
			int num2 = 0;
			for (int i = 0; i < 13; i++)
			{
				int num3 = stringBuilder[i] - 48;
				num2 += (((i & 1) == 0) ? (3 * num3) : num3);
			}
			num2 = 10 - num2 % 10;
			if (num2 == 10)
			{
				num2 = 0;
			}
			stringBuilder.Append(num2);
			ResultPoint[] resultPoints = leftPair.FinderPattern.ResultPoints;
			ResultPoint[] resultPoints2 = rightPair.FinderPattern.ResultPoints;
			return new Result(stringBuilder.ToString(), null, new ResultPoint[4]
			{
				resultPoints[0],
				resultPoints[1],
				resultPoints2[0],
				resultPoints2[1]
			}, BarcodeFormat.RSS_14);
		}

		private static bool checkChecksum(Pair leftPair, Pair rightPair)
		{
			int num = (leftPair.ChecksumPortion + 16 * rightPair.ChecksumPortion) % 79;
			int num2 = 9 * leftPair.FinderPattern.Value + rightPair.FinderPattern.Value;
			if (num2 > 72)
			{
				num2--;
			}
			if (num2 > 8)
			{
				num2--;
			}
			return num == num2;
		}

		private Pair decodePair(ZXing.Common.BitArray row, bool right, int rowNumber, IDictionary<DecodeHintType, object> hints)
		{
			int[] array = findFinderPattern(row, right);
			if (array == null)
			{
				return null;
			}
			FinderPattern finderPattern = parseFoundFinderPattern(row, rowNumber, right, array);
			if (finderPattern == null)
			{
				return null;
			}
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				float num = (float)(array[0] + array[1]) / 2f;
				if (right)
				{
					num = (float)(row.Size - 1) - num;
				}
				resultPointCallback(new ResultPoint(num, rowNumber));
			}
			DataCharacter dataCharacter = decodeDataCharacter(row, finderPattern, outsideChar: true);
			if (dataCharacter == null)
			{
				return null;
			}
			DataCharacter dataCharacter2 = decodeDataCharacter(row, finderPattern, outsideChar: false);
			if (dataCharacter2 == null)
			{
				return null;
			}
			return new Pair(1597 * dataCharacter.Value + dataCharacter2.Value, dataCharacter.ChecksumPortion + 4 * dataCharacter2.ChecksumPortion, finderPattern);
		}

		private DataCharacter decodeDataCharacter(ZXing.Common.BitArray row, FinderPattern pattern, bool outsideChar)
		{
			int[] array = getDataCharacterCounters();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0;
			}
			if (outsideChar)
			{
				if (!OneDReader.recordPatternInReverse(row, pattern.StartEnd[0], array))
				{
					return null;
				}
			}
			else
			{
				if (!OneDReader.recordPattern(row, pattern.StartEnd[1] + 1, array))
				{
					return null;
				}
				int num = 0;
				int num2 = array.Length - 1;
				while (num < num2)
				{
					int num3 = array[num];
					array[num] = array[num2];
					array[num2] = num3;
					num++;
					num2--;
				}
			}
			int num4 = (outsideChar ? 16 : 15);
			float num5 = (float)MathUtils.sum(array) / (float)num4;
			int[] array2 = getOddCounts();
			int[] array3 = getEvenCounts();
			float[] array4 = getOddRoundingErrors();
			float[] array5 = getEvenRoundingErrors();
			for (int j = 0; j < array.Length; j++)
			{
				float num6 = (float)array[j] / num5;
				int num7 = (int)(num6 + 0.5f);
				if (num7 < 1)
				{
					num7 = 1;
				}
				else if (num7 > 8)
				{
					num7 = 8;
				}
				int num8 = j >> 1;
				if ((j & 1) == 0)
				{
					array2[num8] = num7;
					array4[num8] = num6 - (float)num7;
				}
				else
				{
					array3[num8] = num7;
					array5[num8] = num6 - (float)num7;
				}
			}
			if (!adjustOddEvenCounts(outsideChar, num4))
			{
				return null;
			}
			int num9 = 0;
			int num10 = 0;
			for (int num11 = array2.Length - 1; num11 >= 0; num11--)
			{
				num10 *= 9;
				num10 += array2[num11];
				num9 += array2[num11];
			}
			int num12 = 0;
			int num13 = 0;
			for (int num14 = array3.Length - 1; num14 >= 0; num14--)
			{
				num12 *= 9;
				num12 += array3[num14];
				num13 += array3[num14];
			}
			int checksumPortion = num10 + 3 * num12;
			if (outsideChar)
			{
				if ((num9 & 1) != 0 || num9 > 12 || num9 < 4)
				{
					return null;
				}
				int num15 = (12 - num9) / 2;
				int num16 = OUTSIDE_ODD_WIDEST[num15];
				int maxWidth = 9 - num16;
				int rSSvalue = RSSUtils.getRSSvalue(array2, num16, noNarrow: false);
				int rSSvalue2 = RSSUtils.getRSSvalue(array3, maxWidth, noNarrow: true);
				int num17 = OUTSIDE_EVEN_TOTAL_SUBSET[num15];
				int num18 = OUTSIDE_GSUM[num15];
				return new DataCharacter(rSSvalue * num17 + rSSvalue2 + num18, checksumPortion);
			}
			if ((num13 & 1) != 0 || num13 > 10 || num13 < 4)
			{
				return null;
			}
			int num19 = (10 - num13) / 2;
			int num20 = INSIDE_ODD_WIDEST[num19];
			int maxWidth2 = 9 - num20;
			int rSSvalue3 = RSSUtils.getRSSvalue(array2, num20, noNarrow: true);
			int rSSvalue4 = RSSUtils.getRSSvalue(array3, maxWidth2, noNarrow: false);
			int num21 = INSIDE_ODD_TOTAL_SUBSET[num19];
			int num22 = INSIDE_GSUM[num19];
			return new DataCharacter(rSSvalue4 * num21 + rSSvalue3 + num22, checksumPortion);
		}

		private int[] findFinderPattern(ZXing.Common.BitArray row, bool rightFinderPattern)
		{
			int[] array = getDecodeFinderCounters();
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			bool flag = false;
			int i;
			for (i = 0; i < size; i++)
			{
				flag = !row[i];
				if (rightFinderPattern == flag)
				{
					break;
				}
			}
			int num = 0;
			int num2 = i;
			for (int j = i; j < size; j++)
			{
				if (row[j] != flag)
				{
					array[num]++;
					continue;
				}
				if (num == 3)
				{
					if (AbstractRSSReader.isFinderPattern(array))
					{
						return new int[2] { num2, j };
					}
					num2 += array[0] + array[1];
					array[0] = array[2];
					array[1] = array[3];
					array[2] = 0;
					array[3] = 0;
					num--;
				}
				else
				{
					num++;
				}
				array[num] = 1;
				flag = !flag;
			}
			return null;
		}

		private FinderPattern parseFoundFinderPattern(ZXing.Common.BitArray row, int rowNumber, bool right, int[] startEnd)
		{
			bool flag = row[startEnd[0]];
			int num = startEnd[0] - 1;
			while (num >= 0 && flag != row[num])
			{
				num--;
			}
			num++;
			int num2 = startEnd[0] - num;
			int[] array = getDecodeFinderCounters();
			Array.Copy(array, 0, array, 1, array.Length - 1);
			array[0] = num2;
			if (!AbstractRSSReader.parseFinderValue(array, FINDER_PATTERNS, out var value))
			{
				return null;
			}
			int num3 = num;
			int num4 = startEnd[1];
			if (right)
			{
				num3 = row.Size - 1 - num3;
				num4 = row.Size - 1 - num4;
			}
			return new FinderPattern(value, new int[2]
			{
				num,
				startEnd[1]
			}, num3, num4, rowNumber);
		}

		private bool adjustOddEvenCounts(bool outsideChar, int numModules)
		{
			int num = MathUtils.sum(getOddCounts());
			int num2 = MathUtils.sum(getEvenCounts());
			int num3 = num + num2 - numModules;
			bool flag = (num & 1) == (outsideChar ? 1 : 0);
			bool flag2 = (num2 & 1) == 1;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			if (outsideChar)
			{
				if (num > 12)
				{
					flag4 = true;
				}
				else if (num < 4)
				{
					flag3 = true;
				}
				if (num2 > 12)
				{
					flag6 = true;
				}
				else if (num2 < 4)
				{
					flag5 = true;
				}
			}
			else
			{
				if (num > 11)
				{
					flag4 = true;
				}
				else if (num < 5)
				{
					flag3 = true;
				}
				if (num2 > 10)
				{
					flag6 = true;
				}
				else if (num2 < 4)
				{
					flag5 = true;
				}
			}
			switch (num3)
			{
			case 1:
				if (flag)
				{
					if (flag2)
					{
						return false;
					}
					flag4 = true;
				}
				else
				{
					if (!flag2)
					{
						return false;
					}
					flag6 = true;
				}
				break;
			case -1:
				if (flag)
				{
					if (flag2)
					{
						return false;
					}
					flag3 = true;
				}
				else
				{
					if (!flag2)
					{
						return false;
					}
					flag5 = true;
				}
				break;
			case 0:
				if (flag)
				{
					if (!flag2)
					{
						return false;
					}
					if (num < num2)
					{
						flag3 = true;
						flag6 = true;
					}
					else
					{
						flag4 = true;
						flag5 = true;
					}
				}
				else if (flag2)
				{
					return false;
				}
				break;
			default:
				return false;
			}
			if (flag3)
			{
				if (flag4)
				{
					return false;
				}
				AbstractRSSReader.increment(getOddCounts(), getOddRoundingErrors());
			}
			if (flag4)
			{
				AbstractRSSReader.decrement(getOddCounts(), getOddRoundingErrors());
			}
			if (flag5)
			{
				if (flag6)
				{
					return false;
				}
				AbstractRSSReader.increment(getEvenCounts(), getOddRoundingErrors());
			}
			if (flag6)
			{
				AbstractRSSReader.decrement(getEvenCounts(), getEvenRoundingErrors());
			}
			return true;
		}
	}
	public static class RSSUtils
	{
		public static int getRSSvalue(int[] widths, int maxWidth, bool noNarrow)
		{
			int num = widths.Length;
			int num2 = 0;
			foreach (int num3 in widths)
			{
				num2 += num3;
			}
			int num4 = 0;
			int num5 = 0;
			for (int j = 0; j < num - 1; j++)
			{
				int num6 = 1;
				num5 |= 1 << j;
				while (num6 < widths[j])
				{
					int num7 = combins(num2 - num6 - 1, num - j - 2);
					if (noNarrow && num5 == 0 && num2 - num6 - (num - j - 1) >= num - j - 1)
					{
						num7 -= combins(num2 - num6 - (num - j), num - j - 2);
					}
					if (num - j - 1 > 1)
					{
						int num8 = 0;
						for (int num9 = num2 - num6 - (num - j - 2); num9 > maxWidth; num9--)
						{
							num8 += combins(num2 - num6 - num9 - 1, num - j - 3);
						}
						num7 -= num8 * (num - 1 - j);
					}
					else if (num2 - num6 > maxWidth)
					{
						num7--;
					}
					num4 += num7;
					num6++;
					num5 &= ~(1 << j);
				}
				num2 -= num6;
			}
			return num4;
		}

		private static int combins(int n, int r)
		{
			int num;
			int num2;
			if (n - r > r)
			{
				num = r;
				num2 = n - r;
			}
			else
			{
				num = n - r;
				num2 = r;
			}
			int num3 = 1;
			int i = 1;
			for (int num4 = n; num4 > num2; num4--)
			{
				num3 *= num4;
				if (i <= num)
				{
					num3 /= i;
					i++;
				}
			}
			for (; i <= num; i++)
			{
				num3 /= i;
			}
			return num3;
		}
	}
}
namespace ZXing.OneD.RSS.Expanded
{
	internal static class BitArrayBuilder
	{
		internal static ZXing.Common.BitArray buildBitArray(List<ExpandedPair> pairs)
		{
			int num = (pairs.Count << 1) - 1;
			if (pairs[pairs.Count - 1].RightChar == null)
			{
				num--;
			}
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray(12 * num);
			int num2 = 0;
			int value = pairs[0].RightChar.Value;
			for (int num3 = 11; num3 >= 0; num3--)
			{
				if ((value & (1 << num3)) != 0)
				{
					bitArray[num2] = true;
				}
				num2++;
			}
			for (int i = 1; i < pairs.Count; i++)
			{
				ExpandedPair expandedPair = pairs[i];
				int value2 = expandedPair.LeftChar.Value;
				for (int num4 = 11; num4 >= 0; num4--)
				{
					if ((value2 & (1 << num4)) != 0)
					{
						bitArray[num2] = true;
					}
					num2++;
				}
				if (expandedPair.RightChar == null)
				{
					continue;
				}
				int value3 = expandedPair.RightChar.Value;
				for (int num5 = 11; num5 >= 0; num5--)
				{
					if ((value3 & (1 << num5)) != 0)
					{
						bitArray[num2] = true;
					}
					num2++;
				}
			}
			return bitArray;
		}
	}
	internal sealed class ExpandedPair
	{
		internal bool MayBeLast { get; private set; }

		internal DataCharacter LeftChar { get; private set; }

		internal DataCharacter RightChar { get; private set; }

		internal FinderPattern FinderPattern { get; private set; }

		public bool MustBeLast => RightChar == null;

		internal ExpandedPair(DataCharacter leftChar, DataCharacter rightChar, FinderPattern finderPattern, bool mayBeLast)
		{
			LeftChar = leftChar;
			RightChar = rightChar;
			FinderPattern = finderPattern;
			MayBeLast = mayBeLast;
		}

		public override string ToString()
		{
			return string.Concat("[ ", LeftChar, " , ", RightChar, " : ", (FinderPattern == null) ? "null" : FinderPattern.Value.ToString(), " ]");
		}

		public override bool Equals(object o)
		{
			if (!(o is ExpandedPair))
			{
				return false;
			}
			ExpandedPair expandedPair = (ExpandedPair)o;
			if (EqualsOrNull(LeftChar, expandedPair.LeftChar) && EqualsOrNull(RightChar, expandedPair.RightChar))
			{
				return EqualsOrNull(FinderPattern, expandedPair.FinderPattern);
			}
			return false;
		}

		private static bool EqualsOrNull(object o1, object o2)
		{
			return o1?.Equals(o2) ?? (o2 == null);
		}

		public override int GetHashCode()
		{
			return hashNotNull(LeftChar) ^ hashNotNull(RightChar) ^ hashNotNull(FinderPattern);
		}

		private static int hashNotNull(object o)
		{
			return o?.GetHashCode() ?? 0;
		}
	}
	internal sealed class ExpandedRow
	{
		internal List<ExpandedPair> Pairs { get; private set; }

		internal int RowNumber { get; private set; }

		internal bool IsReversed { get; private set; }

		internal ExpandedRow(List<ExpandedPair> pairs, int rowNumber, bool wasReversed)
		{
			Pairs = new List<ExpandedPair>(pairs);
			RowNumber = rowNumber;
			IsReversed = wasReversed;
		}

		internal bool IsEquivalent(List<ExpandedPair> otherPairs)
		{
			return Pairs.Equals(otherPairs);
		}

		public override string ToString()
		{
			return string.Concat("{ ", Pairs, " }");
		}

		public override bool Equals(object o)
		{
			if (!(o is ExpandedRow))
			{
				return false;
			}
			ExpandedRow expandedRow = (ExpandedRow)o;
			if (Pairs.Equals(expandedRow.Pairs))
			{
				return IsReversed == expandedRow.IsReversed;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Pairs.GetHashCode() ^ IsReversed.GetHashCode();
		}
	}
	public sealed class RSSExpandedReader : AbstractRSSReader
	{
		private static readonly int[] SYMBOL_WIDEST = new int[5] { 7, 5, 4, 3, 1 };

		private static readonly int[] EVEN_TOTAL_SUBSET = new int[5] { 4, 20, 52, 104, 204 };

		private static readonly int[] GSUM = new int[5] { 0, 348, 1388, 2948, 3988 };

		private static readonly int[][] FINDER_PATTERNS = new int[6][]
		{
			new int[4] { 1, 8, 4, 1 },
			new int[4] { 3, 6, 4, 1 },
			new int[4] { 3, 4, 6, 1 },
			new int[4] { 3, 2, 8, 1 },
			new int[4] { 2, 6, 5, 1 },
			new int[4] { 2, 2, 9, 1 }
		};

		private static readonly int[][] WEIGHTS = new int[23][]
		{
			new int[8] { 1, 3, 9, 27, 81, 32, 96, 77 },
			new int[8] { 20, 60, 180, 118, 143, 7, 21, 63 },
			new int[8] { 189, 145, 13, 39, 117, 140, 209, 205 },
			new int[8] { 193, 157, 49, 147, 19, 57, 171, 91 },
			new int[8] { 62, 186, 136, 197, 169, 85, 44, 132 },
			new int[8] { 185, 133, 188, 142, 4, 12, 36, 108 },
			new int[8] { 113, 128, 173, 97, 80, 29, 87, 50 },
			new int[8] { 150, 28, 84, 41, 123, 158, 52, 156 },
			new int[8] { 46, 138, 203, 187, 139, 206, 196, 166 },
			new int[8] { 76, 17, 51, 153, 37, 111, 122, 155 },
			new int[8] { 43, 129, 176, 106, 107, 110, 119, 146 },
			new int[8] { 16, 48, 144, 10, 30, 90, 59, 177 },
			new int[8] { 109, 116, 137, 200, 178, 112, 125, 164 },
			new int[8] { 70, 210, 208, 202, 184, 130, 179, 115 },
			new int[8] { 134, 191, 151, 31, 93, 68, 204, 190 },
			new int[8] { 148, 22, 66, 198, 172, 94, 71, 2 },
			new int[8] { 6, 18, 54, 162, 64, 192, 154, 40 },
			new int[8] { 120, 149, 25, 75, 14, 42, 126, 167 },
			new int[8] { 79, 26, 78, 23, 69, 207, 199, 175 },
			new int[8] { 103, 98, 83, 38, 114, 131, 182, 124 },
			new int[8] { 161, 61, 183, 127, 170, 88, 53, 159 },
			new int[8] { 55, 165, 73, 8, 24, 72, 5, 15 },
			new int[8] { 45, 135, 194, 160, 58, 174, 100, 89 }
		};

		private const int FINDER_PAT_A = 0;

		private const int FINDER_PAT_B = 1;

		private const int FINDER_PAT_C = 2;

		private const int FINDER_PAT_D = 3;

		private const int FINDER_PAT_E = 4;

		private const int FINDER_PAT_F = 5;

		private static readonly int[][] FINDER_PATTERN_SEQUENCES = new int[10][]
		{
			new int[2],
			new int[3] { 0, 1, 1 },
			new int[4] { 0, 2, 1, 3 },
			new int[5] { 0, 4, 1, 3, 2 },
			new int[6] { 0, 4, 1, 3, 3, 5 },
			new int[7] { 0, 4, 1, 3, 4, 5, 5 },
			new int[8] { 0, 0, 1, 1, 2, 2, 3, 3 },
			new int[9] { 0, 0, 1, 1, 2, 2, 3, 4, 4 },
			new int[10] { 0, 0, 1, 1, 2, 2, 3, 4, 5, 5 },
			new int[11]
			{
				0, 0, 1, 1, 2, 3, 3, 4, 4, 5,
				5
			}
		};

		private const int MAX_PAIRS = 11;

		private readonly List<ExpandedPair> pairs = new List<ExpandedPair>(11);

		private readonly List<ExpandedRow> rows = new List<ExpandedRow>();

		private readonly int[] startEnd = new int[2];

		private bool startFromEven;

		internal List<ExpandedPair> Pairs => pairs;

		internal List<ExpandedRow> Rows => rows;

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			pairs.Clear();
			startFromEven = false;
			if (decodeRow2pairs(rowNumber, row))
			{
				return constructResult(pairs);
			}
			pairs.Clear();
			startFromEven = true;
			if (decodeRow2pairs(rowNumber, row))
			{
				return constructResult(pairs);
			}
			return null;
		}

		public override void reset()
		{
			pairs.Clear();
			rows.Clear();
		}

		internal bool decodeRow2pairs(int rowNumber, ZXing.Common.BitArray row)
		{
			while (true)
			{
				ExpandedPair expandedPair = retrieveNextPair(row, pairs, rowNumber);
				if (expandedPair == null)
				{
					break;
				}
				pairs.Add(expandedPair);
			}
			if (pairs.Count == 0)
			{
				return false;
			}
			if (checkChecksum())
			{
				return true;
			}
			bool num = rows.Count != 0;
			storeRow(rowNumber, wasReversed: false);
			if (num)
			{
				if (checkRows(reverse: false) != null)
				{
					return true;
				}
				if (checkRows(reverse: true) != null)
				{
					return true;
				}
			}
			return false;
		}

		private List<ExpandedPair> checkRows(bool reverse)
		{
			if (rows.Count > 25)
			{
				rows.Clear();
				return null;
			}
			pairs.Clear();
			if (reverse)
			{
				rows.Reverse();
			}
			List<ExpandedPair> result = checkRows(new List<ExpandedRow>(), 0);
			if (reverse)
			{
				rows.Reverse();
			}
			return result;
		}

		private List<ExpandedPair> checkRows(List<ExpandedRow> collectedRows, int currentRow)
		{
			for (int i = currentRow; i < rows.Count; i++)
			{
				ExpandedRow expandedRow = rows[i];
				pairs.Clear();
				int num = collectedRows.Count;
				for (int j = 0; j < num; j++)
				{
					pairs.AddRange(collectedRows[j].Pairs);
				}
				pairs.AddRange(expandedRow.Pairs);
				if (isValidSequence(pairs))
				{
					if (checkChecksum())
					{
						return pairs;
					}
					List<ExpandedRow> list = new List<ExpandedRow>();
					list.AddRange(collectedRows);
					list.Add(expandedRow);
					List<ExpandedPair> list2 = checkRows(list, i + 1);
					if (list2 != null)
					{
						return list2;
					}
				}
			}
			return null;
		}

		private static bool isValidSequence(List<ExpandedPair> pairs)
		{
			int[][] fINDER_PATTERN_SEQUENCES = FINDER_PATTERN_SEQUENCES;
			foreach (int[] array in fINDER_PATTERN_SEQUENCES)
			{
				if (pairs.Count > array.Length)
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < pairs.Count; j++)
				{
					if (pairs[j].FinderPattern.Value != array[j])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		private void storeRow(int rowNumber, bool wasReversed)
		{
			int i = 0;
			bool flag = false;
			bool flag2 = false;
			for (; i < rows.Count; i++)
			{
				ExpandedRow expandedRow = rows[i];
				if (expandedRow.RowNumber > rowNumber)
				{
					flag2 = expandedRow.IsEquivalent(pairs);
					break;
				}
				flag = expandedRow.IsEquivalent(pairs);
			}
			if (!(flag2 || flag) && !isPartialRow(pairs, rows))
			{
				rows.Insert(i, new ExpandedRow(pairs, rowNumber, wasReversed));
				removePartialRows(pairs, rows);
			}
		}

		private static void removePartialRows(List<ExpandedPair> pairs, List<ExpandedRow> rows)
		{
			for (int i = 0; i < rows.Count; i++)
			{
				ExpandedRow expandedRow = rows[i];
				if (expandedRow.Pairs.Count == pairs.Count)
				{
					continue;
				}
				bool flag = true;
				foreach (ExpandedPair pair in expandedRow.Pairs)
				{
					bool flag2 = false;
					foreach (ExpandedPair pair2 in pairs)
					{
						if (pair.Equals(pair2))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					rows.RemoveAt(i);
				}
			}
		}

		private static bool isPartialRow(IEnumerable<ExpandedPair> pairs, IEnumerable<ExpandedRow> rows)
		{
			foreach (ExpandedRow row in rows)
			{
				bool flag = true;
				foreach (ExpandedPair pair in pairs)
				{
					bool flag2 = false;
					foreach (ExpandedPair pair2 in row.Pairs)
					{
						if (pair.Equals(pair2))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		internal static Result constructResult(List<ExpandedPair> pairs)
		{
			string text = AbstractExpandedDecoder.createDecoder(BitArrayBuilder.buildBitArray(pairs)).parseInformation();
			if (text == null)
			{
				return null;
			}
			ResultPoint[] resultPoints = pairs[0].FinderPattern.ResultPoints;
			ResultPoint[] resultPoints2 = pairs[pairs.Count - 1].FinderPattern.ResultPoints;
			return new Result(text, null, new ResultPoint[4]
			{
				resultPoints[0],
				resultPoints[1],
				resultPoints2[0],
				resultPoints2[1]
			}, BarcodeFormat.RSS_EXPANDED);
		}

		private bool checkChecksum()
		{
			ExpandedPair expandedPair = pairs[0];
			DataCharacter leftChar = expandedPair.LeftChar;
			DataCharacter rightChar = expandedPair.RightChar;
			if (rightChar == null)
			{
				return false;
			}
			int num = rightChar.ChecksumPortion;
			int num2 = 2;
			for (int i = 1; i < pairs.Count; i++)
			{
				ExpandedPair expandedPair2 = pairs[i];
				num += expandedPair2.LeftChar.ChecksumPortion;
				num2++;
				DataCharacter rightChar2 = expandedPair2.RightChar;
				if (rightChar2 != null)
				{
					num += rightChar2.ChecksumPortion;
					num2++;
				}
			}
			num %= 211;
			return 211 * (num2 - 4) + num == leftChar.Value;
		}

		private static int getNextSecondBar(ZXing.Common.BitArray row, int initialPos)
		{
			int nextUnset;
			if (row[initialPos])
			{
				nextUnset = row.getNextUnset(initialPos);
				return row.getNextSet(nextUnset);
			}
			nextUnset = row.getNextSet(initialPos);
			return row.getNextUnset(nextUnset);
		}

		internal ExpandedPair retrieveNextPair(ZXing.Common.BitArray row, List<ExpandedPair> previousPairs, int rowNumber)
		{
			bool flag = previousPairs.Count % 2 == 0;
			if (startFromEven)
			{
				flag = !flag;
			}
			bool flag2 = true;
			int forcedOffset = -1;
			FinderPattern finderPattern;
			do
			{
				if (!findNextPair(row, previousPairs, forcedOffset))
				{
					return null;
				}
				finderPattern = parseFoundFinderPattern(row, rowNumber, flag);
				if (finderPattern == null)
				{
					forcedOffset = getNextSecondBar(row, startEnd[0]);
				}
				else
				{
					flag2 = false;
				}
			}
			while (flag2);
			DataCharacter dataCharacter = decodeDataCharacter(row, finderPattern, flag, leftChar: true);
			if (dataCharacter == null)
			{
				return null;
			}
			if (previousPairs.Count != 0 && previousPairs[previousPairs.Count - 1].MustBeLast)
			{
				return null;
			}
			DataCharacter rightChar = decodeDataCharacter(row, finderPattern, flag, leftChar: false);
			return new ExpandedPair(dataCharacter, rightChar, finderPattern, mayBeLast: true);
		}

		private bool findNextPair(ZXing.Common.BitArray row, List<ExpandedPair> previousPairs, int forcedOffset)
		{
			int[] array = getDecodeFinderCounters();
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = 0;
			int size = row.Size;
			int i = ((forcedOffset >= 0) ? forcedOffset : ((previousPairs.Count != 0) ? previousPairs[previousPairs.Count - 1].FinderPattern.StartEnd[1] : 0));
			bool flag = previousPairs.Count % 2 != 0;
			if (startFromEven)
			{
				flag = !flag;
			}
			bool flag2 = false;
			for (; i < size; i++)
			{
				flag2 = !row[i];
				if (!flag2)
				{
					break;
				}
			}
			int num = 0;
			int num2 = i;
			for (int j = i; j < size; j++)
			{
				if (row[j] != flag2)
				{
					array[num]++;
					continue;
				}
				if (num == 3)
				{
					if (flag)
					{
						reverseCounters(array);
					}
					if (AbstractRSSReader.isFinderPattern(array))
					{
						startEnd[0] = num2;
						startEnd[1] = j;
						return true;
					}
					if (flag)
					{
						reverseCounters(array);
					}
					num2 += array[0] + array[1];
					array[0] = array[2];
					array[1] = array[3];
					array[2] = 0;
					array[3] = 0;
					num--;
				}
				else
				{
					num++;
				}
				array[num] = 1;
				flag2 = !flag2;
			}
			return false;
		}

		private static void reverseCounters(int[] counters)
		{
			int num = counters.Length;
			for (int i = 0; i < num / 2; i++)
			{
				int num2 = counters[i];
				counters[i] = counters[num - i - 1];
				counters[num - i - 1] = num2;
			}
		}

		private FinderPattern parseFoundFinderPattern(ZXing.Common.BitArray row, int rowNumber, bool oddPattern)
		{
			int num2;
			int num3;
			int num4;
			if (oddPattern)
			{
				int num = startEnd[0] - 1;
				while (num >= 0 && !row[num])
				{
					num--;
				}
				num++;
				num2 = startEnd[0] - num;
				num3 = num;
				num4 = startEnd[1];
			}
			else
			{
				num3 = startEnd[0];
				num4 = row.getNextUnset(startEnd[1] + 1);
				num2 = num4 - startEnd[1];
			}
			int[] array = getDecodeFinderCounters();
			Array.Copy(array, 0, array, 1, array.Length - 1);
			array[0] = num2;
			if (!AbstractRSSReader.parseFinderValue(array, FINDER_PATTERNS, out var value))
			{
				return null;
			}
			return new FinderPattern(value, new int[2] { num3, num4 }, num3, num4, rowNumber);
		}

		internal DataCharacter decodeDataCharacter(ZXing.Common.BitArray row, FinderPattern pattern, bool isOddPattern, bool leftChar)
		{
			int[] array = getDataCharacterCounters();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0;
			}
			if (leftChar)
			{
				if (!OneDReader.recordPatternInReverse(row, pattern.StartEnd[0], array))
				{
					return null;
				}
			}
			else
			{
				if (!OneDReader.recordPattern(row, pattern.StartEnd[1], array))
				{
					return null;
				}
				int num = 0;
				int num2 = array.Length - 1;
				while (num < num2)
				{
					int num3 = array[num];
					array[num] = array[num2];
					array[num2] = num3;
					num++;
					num2--;
				}
			}
			float num4 = (float)MathUtils.sum(array) / 17f;
			float num5 = (float)(pattern.StartEnd[1] - pattern.StartEnd[0]) / 15f;
			if (Math.Abs(num4 - num5) / num5 > 0.3f)
			{
				return null;
			}
			int[] array2 = getOddCounts();
			int[] array3 = getEvenCounts();
			float[] array4 = getOddRoundingErrors();
			float[] array5 = getEvenRoundingErrors();
			for (int j = 0; j < array.Length; j++)
			{
				float num6 = 1f * (float)array[j] / num4;
				int num7 = (int)(num6 + 0.5f);
				if (num7 < 1)
				{
					if (num6 < 0.3f)
					{
						return null;
					}
					num7 = 1;
				}
				else if (num7 > 8)
				{
					if (num6 > 8.7f)
					{
						return null;
					}
					num7 = 8;
				}
				int num8 = j >> 1;
				if ((j & 1) == 0)
				{
					array2[num8] = num7;
					array4[num8] = num6 - (float)num7;
				}
				else
				{
					array3[num8] = num7;
					array5[num8] = num6 - (float)num7;
				}
			}
			if (!adjustOddEvenCounts(17))
			{
				return null;
			}
			int num9 = 4 * pattern.Value + ((!isOddPattern) ? 2 : 0) + ((!leftChar) ? 1 : 0) - 1;
			int num10 = 0;
			int num11 = 0;
			for (int num12 = array2.Length - 1; num12 >= 0; num12--)
			{
				if (isNotA1left(pattern, isOddPattern, leftChar))
				{
					int num13 = WEIGHTS[num9][2 * num12];
					num11 += array2[num12] * num13;
				}
				num10 += array2[num12];
			}
			int num14 = 0;
			for (int num15 = array3.Length - 1; num15 >= 0; num15--)
			{
				if (isNotA1left(pattern, isOddPattern, leftChar))
				{
					int num16 = WEIGHTS[num9][2 * num15 + 1];
					num14 += array3[num15] * num16;
				}
			}
			int checksumPortion = num11 + num14;
			if ((num10 & 1) != 0 || num10 > 13 || num10 < 4)
			{
				return null;
			}
			int num17 = (13 - num10) / 2;
			int num18 = SYMBOL_WIDEST[num17];
			int maxWidth = 9 - num18;
			int rSSvalue = RSSUtils.getRSSvalue(array2, num18, noNarrow: true);
			int rSSvalue2 = RSSUtils.getRSSvalue(array3, maxWidth, noNarrow: false);
			int num19 = EVEN_TOTAL_SUBSET[num17];
			int num20 = GSUM[num17];
			return new DataCharacter(rSSvalue * num19 + rSSvalue2 + num20, checksumPortion);
		}

		private static bool isNotA1left(FinderPattern pattern, bool isOddPattern, bool leftChar)
		{
			return !(pattern.Value == 0 && isOddPattern && leftChar);
		}

		private bool adjustOddEvenCounts(int numModules)
		{
			int num = MathUtils.sum(getOddCounts());
			int num2 = MathUtils.sum(getEvenCounts());
			int num3 = num + num2 - numModules;
			bool flag = (num & 1) == 1;
			bool flag2 = (num2 & 1) == 0;
			bool flag3 = false;
			bool flag4 = false;
			if (num > 13)
			{
				flag4 = true;
			}
			else if (num < 4)
			{
				flag3 = true;
			}
			bool flag5 = false;
			bool flag6 = false;
			if (num2 > 13)
			{
				flag6 = true;
			}
			else if (num2 < 4)
			{
				flag5 = true;
			}
			switch (num3)
			{
			case 1:
				if (flag)
				{
					if (flag2)
					{
						return false;
					}
					flag4 = true;
				}
				else
				{
					if (!flag2)
					{
						return false;
					}
					flag6 = true;
				}
				break;
			case -1:
				if (flag)
				{
					if (flag2)
					{
						return false;
					}
					flag3 = true;
				}
				else
				{
					if (!flag2)
					{
						return false;
					}
					flag5 = true;
				}
				break;
			case 0:
				if (flag)
				{
					if (!flag2)
					{
						return false;
					}
					if (num < num2)
					{
						flag3 = true;
						flag6 = true;
					}
					else
					{
						flag4 = true;
						flag5 = true;
					}
				}
				else if (flag2)
				{
					return false;
				}
				break;
			default:
				return false;
			}
			if (flag3)
			{
				if (flag4)
				{
					return false;
				}
				AbstractRSSReader.increment(getOddCounts(), getOddRoundingErrors());
			}
			if (flag4)
			{
				AbstractRSSReader.decrement(getOddCounts(), getOddRoundingErrors());
			}
			if (flag5)
			{
				if (flag6)
				{
					return false;
				}
				AbstractRSSReader.increment(getEvenCounts(), getOddRoundingErrors());
			}
			if (flag6)
			{
				AbstractRSSReader.decrement(getEvenCounts(), getEvenRoundingErrors());
			}
			return true;
		}
	}
}
namespace ZXing.OneD.RSS.Expanded.Decoders
{
	public abstract class AbstractExpandedDecoder
	{
		private readonly ZXing.Common.BitArray information;

		private readonly GeneralAppIdDecoder generalDecoder;

		internal AbstractExpandedDecoder(ZXing.Common.BitArray information)
		{
			this.information = information;
			generalDecoder = new GeneralAppIdDecoder(information);
		}

		protected ZXing.Common.BitArray getInformation()
		{
			return information;
		}

		internal GeneralAppIdDecoder getGeneralDecoder()
		{
			return generalDecoder;
		}

		public abstract string parseInformation();

		public static AbstractExpandedDecoder createDecoder(ZXing.Common.BitArray information)
		{
			if (information[1])
			{
				return new AI01AndOtherAIs(information);
			}
			if (!information[2])
			{
				return new AnyAIDecoder(information);
			}
			return GeneralAppIdDecoder.extractNumericValueFromBitArray(information, 1, 4) switch
			{
				4 => new AI013103decoder(information), 
				5 => new AI01320xDecoder(information), 
				_ => GeneralAppIdDecoder.extractNumericValueFromBitArray(information, 1, 5) switch
				{
					12 => new AI01392xDecoder(information), 
					13 => new AI01393xDecoder(information), 
					_ => GeneralAppIdDecoder.extractNumericValueFromBitArray(information, 1, 7) switch
					{
						56 => new AI013x0x1xDecoder(information, "310", "11"), 
						57 => new AI013x0x1xDecoder(information, "320", "11"), 
						58 => new AI013x0x1xDecoder(information, "310", "13"), 
						59 => new AI013x0x1xDecoder(information, "320", "13"), 
						60 => new AI013x0x1xDecoder(information, "310", "15"), 
						61 => new AI013x0x1xDecoder(information, "320", "15"), 
						62 => new AI013x0x1xDecoder(information, "310", "17"), 
						63 => new AI013x0x1xDecoder(information, "320", "17"), 
						_ => throw new InvalidOperationException("unknown decoder: " + information), 
					}, 
				}, 
			};
		}
	}
	internal sealed class AI013103decoder : AI013x0xDecoder
	{
		internal AI013103decoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		protected override void addWeightCode(StringBuilder buf, int weight)
		{
			buf.Append("(3103)");
		}

		protected override int checkWeight(int weight)
		{
			return weight;
		}
	}
	internal sealed class AI01320xDecoder : AI013x0xDecoder
	{
		internal AI01320xDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		protected override void addWeightCode(StringBuilder buf, int weight)
		{
			if (weight < 10000)
			{
				buf.Append("(3202)");
			}
			else
			{
				buf.Append("(3203)");
			}
		}

		protected override int checkWeight(int weight)
		{
			if (weight < 10000)
			{
				return weight;
			}
			return weight - 10000;
		}
	}
	internal sealed class AI01392xDecoder : AI01decoder
	{
		private const int HEADER_SIZE = 8;

		private const int LAST_DIGIT_SIZE = 2;

		internal AI01392xDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		public override string parseInformation()
		{
			if (getInformation().Size < 8 + AI01decoder.GTIN_SIZE)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			encodeCompressedGtin(stringBuilder, 8);
			int value = getGeneralDecoder().extractNumericValueFromBitArray(8 + AI01decoder.GTIN_SIZE, 2);
			stringBuilder.Append("(392");
			stringBuilder.Append(value);
			stringBuilder.Append(')');
			DecodedInformation decodedInformation = getGeneralDecoder().decodeGeneralPurposeField(8 + AI01decoder.GTIN_SIZE + 2, null);
			stringBuilder.Append(decodedInformation.getNewString());
			return stringBuilder.ToString();
		}
	}
	internal sealed class AI01393xDecoder : AI01decoder
	{
		private static int HEADER_SIZE = 8;

		private static int LAST_DIGIT_SIZE = 2;

		private static int FIRST_THREE_DIGITS_SIZE = 10;

		internal AI01393xDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		public override string parseInformation()
		{
			if (getInformation().Size < HEADER_SIZE + AI01decoder.GTIN_SIZE)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			encodeCompressedGtin(stringBuilder, HEADER_SIZE);
			int value = getGeneralDecoder().extractNumericValueFromBitArray(HEADER_SIZE + AI01decoder.GTIN_SIZE, LAST_DIGIT_SIZE);
			stringBuilder.Append("(393");
			stringBuilder.Append(value);
			stringBuilder.Append(')');
			int num = getGeneralDecoder().extractNumericValueFromBitArray(HEADER_SIZE + AI01decoder.GTIN_SIZE + LAST_DIGIT_SIZE, FIRST_THREE_DIGITS_SIZE);
			if (num / 100 == 0)
			{
				stringBuilder.Append('0');
			}
			if (num / 10 == 0)
			{
				stringBuilder.Append('0');
			}
			stringBuilder.Append(num);
			DecodedInformation decodedInformation = getGeneralDecoder().decodeGeneralPurposeField(HEADER_SIZE + AI01decoder.GTIN_SIZE + LAST_DIGIT_SIZE + FIRST_THREE_DIGITS_SIZE, null);
			stringBuilder.Append(decodedInformation.getNewString());
			return stringBuilder.ToString();
		}
	}
	internal sealed class AI013x0x1xDecoder : AI01weightDecoder
	{
		private static int HEADER_SIZE = 8;

		private static int WEIGHT_SIZE = 20;

		private static int DATE_SIZE = 16;

		private string dateCode;

		private string firstAIdigits;

		internal AI013x0x1xDecoder(ZXing.Common.BitArray information, string firstAIdigits, string dateCode)
			: base(information)
		{
			this.dateCode = dateCode;
			this.firstAIdigits = firstAIdigits;
		}

		public override string parseInformation()
		{
			if (getInformation().Size != HEADER_SIZE + AI01decoder.GTIN_SIZE + WEIGHT_SIZE + DATE_SIZE)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			encodeCompressedGtin(stringBuilder, HEADER_SIZE);
			encodeCompressedWeight(stringBuilder, HEADER_SIZE + AI01decoder.GTIN_SIZE, WEIGHT_SIZE);
			encodeCompressedDate(stringBuilder, HEADER_SIZE + AI01decoder.GTIN_SIZE + WEIGHT_SIZE);
			return stringBuilder.ToString();
		}

		private void encodeCompressedDate(StringBuilder buf, int currentPos)
		{
			int num = getGeneralDecoder().extractNumericValueFromBitArray(currentPos, DATE_SIZE);
			if (num != 38400)
			{
				buf.Append('(');
				buf.Append(dateCode);
				buf.Append(')');
				int num2 = num % 32;
				num /= 32;
				int num3 = num % 12 + 1;
				num /= 12;
				int num4 = num;
				if (num4 / 10 == 0)
				{
					buf.Append('0');
				}
				buf.Append(num4);
				if (num3 / 10 == 0)
				{
					buf.Append('0');
				}
				buf.Append(num3);
				if (num2 / 10 == 0)
				{
					buf.Append('0');
				}
				buf.Append(num2);
			}
		}

		protected override void addWeightCode(StringBuilder buf, int weight)
		{
			int value = weight / 100000;
			buf.Append('(');
			buf.Append(firstAIdigits);
			buf.Append(value);
			buf.Append(')');
		}

		protected override int checkWeight(int weight)
		{
			return weight % 100000;
		}
	}
	internal abstract class AI013x0xDecoder : AI01weightDecoder
	{
		private static int HEADER_SIZE = 5;

		private static int WEIGHT_SIZE = 15;

		internal AI013x0xDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		public override string parseInformation()
		{
			if (getInformation().Size != HEADER_SIZE + AI01decoder.GTIN_SIZE + WEIGHT_SIZE)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			encodeCompressedGtin(stringBuilder, HEADER_SIZE);
			encodeCompressedWeight(stringBuilder, HEADER_SIZE + AI01decoder.GTIN_SIZE, WEIGHT_SIZE);
			return stringBuilder.ToString();
		}
	}
	internal sealed class AI01AndOtherAIs : AI01decoder
	{
		private static int HEADER_SIZE = 4;

		internal AI01AndOtherAIs(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		public override string parseInformation()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("(01)");
			int length = stringBuilder.Length;
			int value = getGeneralDecoder().extractNumericValueFromBitArray(HEADER_SIZE, 4);
			stringBuilder.Append(value);
			encodeCompressedGtinWithoutAI(stringBuilder, HEADER_SIZE + 4, length);
			return getGeneralDecoder().decodeAllCodes(stringBuilder, HEADER_SIZE + 44);
		}
	}
	internal abstract class AI01decoder : AbstractExpandedDecoder
	{
		protected static int GTIN_SIZE = 40;

		internal AI01decoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		protected void encodeCompressedGtin(StringBuilder buf, int currentPos)
		{
			buf.Append("(01)");
			int length = buf.Length;
			buf.Append('9');
			encodeCompressedGtinWithoutAI(buf, currentPos, length);
		}

		protected void encodeCompressedGtinWithoutAI(StringBuilder buf, int currentPos, int initialBufferPosition)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = getGeneralDecoder().extractNumericValueFromBitArray(currentPos + 10 * i, 10);
				if (num / 100 == 0)
				{
					buf.Append('0');
				}
				if (num / 10 == 0)
				{
					buf.Append('0');
				}
				buf.Append(num);
			}
			appendCheckDigit(buf, initialBufferPosition);
		}

		private static void appendCheckDigit(StringBuilder buf, int currentPos)
		{
			int num = 0;
			for (int i = 0; i < 13; i++)
			{
				int num2 = buf[i + currentPos] - 48;
				num += (((i & 1) == 0) ? (3 * num2) : num2);
			}
			num = 10 - num % 10;
			if (num == 10)
			{
				num = 0;
			}
			buf.Append(num);
		}
	}
	internal abstract class AI01weightDecoder : AI01decoder
	{
		internal AI01weightDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		protected void encodeCompressedWeight(StringBuilder buf, int currentPos, int weightSize)
		{
			int weight = getGeneralDecoder().extractNumericValueFromBitArray(currentPos, weightSize);
			addWeightCode(buf, weight);
			int num = checkWeight(weight);
			int num2 = 100000;
			for (int i = 0; i < 5; i++)
			{
				if (num / num2 == 0)
				{
					buf.Append('0');
				}
				num2 /= 10;
			}
			buf.Append(num);
		}

		protected abstract void addWeightCode(StringBuilder buf, int weight);

		protected abstract int checkWeight(int weight);
	}
	internal sealed class AnyAIDecoder : AbstractExpandedDecoder
	{
		private static int HEADER_SIZE = 5;

		internal AnyAIDecoder(ZXing.Common.BitArray information)
			: base(information)
		{
		}

		public override string parseInformation()
		{
			StringBuilder buff = new StringBuilder();
			return getGeneralDecoder().decodeAllCodes(buff, HEADER_SIZE);
		}
	}
	internal sealed class BlockParsedResult
	{
		private DecodedInformation decodedInformation;

		private bool finished;

		internal BlockParsedResult(bool finished)
			: this(null, finished)
		{
		}

		internal BlockParsedResult(DecodedInformation information, bool finished)
		{
			this.finished = finished;
			decodedInformation = information;
		}

		internal DecodedInformation getDecodedInformation()
		{
			return decodedInformation;
		}

		internal bool isFinished()
		{
			return finished;
		}
	}
	internal sealed class CurrentParsingState
	{
		private enum State
		{
			NUMERIC,
			ALPHA,
			ISO_IEC_646
		}

		private int position;

		private State encoding;

		internal CurrentParsingState()
		{
			position = 0;
			encoding = State.NUMERIC;
		}

		internal int getPosition()
		{
			return position;
		}

		internal void setPosition(int position)
		{
			this.position = position;
		}

		internal void incrementPosition(int delta)
		{
			position += delta;
		}

		internal bool isAlpha()
		{
			return encoding == State.ALPHA;
		}

		internal bool isNumeric()
		{
			return encoding == State.NUMERIC;
		}

		internal bool isIsoIec646()
		{
			return encoding == State.ISO_IEC_646;
		}

		internal void setNumeric()
		{
			encoding = State.NUMERIC;
		}

		internal void setAlpha()
		{
			encoding = State.ALPHA;
		}

		internal void setIsoIec646()
		{
			encoding = State.ISO_IEC_646;
		}
	}
	internal sealed class DecodedChar : DecodedObject
	{
		private char value;

		internal static char FNC1 = '$';

		internal DecodedChar(int newPosition, char value)
			: base(newPosition)
		{
			this.value = value;
		}

		internal char getValue()
		{
			return value;
		}

		internal bool isFNC1()
		{
			return value == FNC1;
		}
	}
	internal sealed class DecodedInformation : DecodedObject
	{
		private string newString;

		private int remainingValue;

		private bool remaining;

		internal DecodedInformation(int newPosition, string newString)
			: base(newPosition)
		{
			this.newString = newString;
			remaining = false;
			remainingValue = 0;
		}

		internal DecodedInformation(int newPosition, string newString, int remainingValue)
			: base(newPosition)
		{
			remaining = true;
			this.remainingValue = remainingValue;
			this.newString = newString;
		}

		internal string getNewString()
		{
			return newString;
		}

		internal bool isRemaining()
		{
			return remaining;
		}

		internal int getRemainingValue()
		{
			return remainingValue;
		}
	}
	internal sealed class DecodedNumeric : DecodedObject
	{
		private readonly int firstDigit;

		private readonly int secondDigit;

		internal static int FNC1 = 10;

		internal DecodedNumeric(int newPosition, int firstDigit, int secondDigit)
			: base(newPosition)
		{
			if (firstDigit < 0 || firstDigit > 10 || secondDigit < 0 || secondDigit > 10)
			{
				throw new FormatException("digits has to be between 0 and 10");
			}
			this.firstDigit = firstDigit;
			this.secondDigit = secondDigit;
		}

		internal int getFirstDigit()
		{
			return firstDigit;
		}

		internal int getSecondDigit()
		{
			return secondDigit;
		}

		internal int getValue()
		{
			return firstDigit * 10 + secondDigit;
		}

		internal bool isFirstDigitFNC1()
		{
			return firstDigit == FNC1;
		}

		internal bool isSecondDigitFNC1()
		{
			return secondDigit == FNC1;
		}

		internal bool isAnyFNC1()
		{
			if (firstDigit != FNC1)
			{
				return secondDigit == FNC1;
			}
			return true;
		}
	}
	internal abstract class DecodedObject
	{
		internal int NewPosition { get; private set; }

		internal DecodedObject(int newPosition)
		{
			NewPosition = newPosition;
		}
	}
	internal static class FieldParser
	{
		private static readonly object VARIABLE_LENGTH;

		private static readonly IDictionary<string, object[]> TWO_DIGIT_DATA_LENGTH;

		private static readonly IDictionary<string, object[]> THREE_DIGIT_DATA_LENGTH;

		private static readonly IDictionary<string, object[]> THREE_DIGIT_PLUS_DIGIT_DATA_LENGTH;

		private static readonly IDictionary<string, object[]> FOUR_DIGIT_DATA_LENGTH;

		static FieldParser()
		{
			VARIABLE_LENGTH = new object();
			TWO_DIGIT_DATA_LENGTH = new Dictionary<string, object[]>
			{
				{
					"00",
					new object[1] { 18 }
				},
				{
					"01",
					new object[1] { 14 }
				},
				{
					"02",
					new object[1] { 14 }
				},
				{
					"10",
					new object[2] { VARIABLE_LENGTH, 20 }
				},
				{
					"11",
					new object[1] { 6 }
				},
				{
					"12",
					new object[1] { 6 }
				},
				{
					"13",
					new object[1] { 6 }
				},
				{
					"15",
					new object[1] { 6 }
				},
				{
					"17",
					new object[1] { 6 }
				},
				{
					"20",
					new object[1] { 2 }
				},
				{
					"21",
					new object[2] { VARIABLE_LENGTH, 20 }
				},
				{
					"22",
					new object[2] { VARIABLE_LENGTH, 29 }
				},
				{
					"30",
					new object[2] { VARIABLE_LENGTH, 8 }
				},
				{
					"37",
					new object[2] { VARIABLE_LENGTH, 8 }
				},
				{
					"90",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"91",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"92",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"93",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"94",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"95",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"96",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"97",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"98",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"99",
					new object[2] { VARIABLE_LENGTH, 30 }
				}
			};
			THREE_DIGIT_DATA_LENGTH = new Dictionary<string, object[]>
			{
				{
					"240",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"241",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"242",
					new object[2] { VARIABLE_LENGTH, 6 }
				},
				{
					"250",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"251",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"253",
					new object[2] { VARIABLE_LENGTH, 17 }
				},
				{
					"254",
					new object[2] { VARIABLE_LENGTH, 20 }
				},
				{
					"400",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"401",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"402",
					new object[1] { 17 }
				},
				{
					"403",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"410",
					new object[1] { 13 }
				},
				{
					"411",
					new object[1] { 13 }
				},
				{
					"412",
					new object[1] { 13 }
				},
				{
					"413",
					new object[1] { 13 }
				},
				{
					"414",
					new object[1] { 13 }
				},
				{
					"420",
					new object[2] { VARIABLE_LENGTH, 20 }
				},
				{
					"421",
					new object[2] { VARIABLE_LENGTH, 15 }
				},
				{
					"422",
					new object[1] { 3 }
				},
				{
					"423",
					new object[2] { VARIABLE_LENGTH, 15 }
				},
				{
					"424",
					new object[1] { 3 }
				},
				{
					"425",
					new object[1] { 3 }
				},
				{
					"426",
					new object[1] { 3 }
				}
			};
			THREE_DIGIT_PLUS_DIGIT_DATA_LENGTH = new Dictionary<string, object[]>
			{
				{
					"310",
					new object[1] { 6 }
				},
				{
					"311",
					new object[1] { 6 }
				},
				{
					"312",
					new object[1] { 6 }
				},
				{
					"313",
					new object[1] { 6 }
				},
				{
					"314",
					new object[1] { 6 }
				},
				{
					"315",
					new object[1] { 6 }
				},
				{
					"316",
					new object[1] { 6 }
				},
				{
					"320",
					new object[1] { 6 }
				},
				{
					"321",
					new object[1] { 6 }
				},
				{
					"322",
					new object[1] { 6 }
				},
				{
					"323",
					new object[1] { 6 }
				},
				{
					"324",
					new object[1] { 6 }
				},
				{
					"325",
					new object[1] { 6 }
				},
				{
					"326",
					new object[1] { 6 }
				},
				{
					"327",
					new object[1] { 6 }
				},
				{
					"328",
					new object[1] { 6 }
				},
				{
					"329",
					new object[1] { 6 }
				},
				{
					"330",
					new object[1] { 6 }
				},
				{
					"331",
					new object[1] { 6 }
				},
				{
					"332",
					new object[1] { 6 }
				},
				{
					"333",
					new object[1] { 6 }
				},
				{
					"334",
					new object[1] { 6 }
				},
				{
					"335",
					new object[1] { 6 }
				},
				{
					"336",
					new object[1] { 6 }
				},
				{
					"340",
					new object[1] { 6 }
				},
				{
					"341",
					new object[1] { 6 }
				},
				{
					"342",
					new object[1] { 6 }
				},
				{
					"343",
					new object[1] { 6 }
				},
				{
					"344",
					new object[1] { 6 }
				},
				{
					"345",
					new object[1] { 6 }
				},
				{
					"346",
					new object[1] { 6 }
				},
				{
					"347",
					new object[1] { 6 }
				},
				{
					"348",
					new object[1] { 6 }
				},
				{
					"349",
					new object[1] { 6 }
				},
				{
					"350",
					new object[1] { 6 }
				},
				{
					"351",
					new object[1] { 6 }
				},
				{
					"352",
					new object[1] { 6 }
				},
				{
					"353",
					new object[1] { 6 }
				},
				{
					"354",
					new object[1] { 6 }
				},
				{
					"355",
					new object[1] { 6 }
				},
				{
					"356",
					new object[1] { 6 }
				},
				{
					"357",
					new object[1] { 6 }
				},
				{
					"360",
					new object[1] { 6 }
				},
				{
					"361",
					new object[1] { 6 }
				},
				{
					"362",
					new object[1] { 6 }
				},
				{
					"363",
					new object[1] { 6 }
				},
				{
					"364",
					new object[1] { 6 }
				},
				{
					"365",
					new object[1] { 6 }
				},
				{
					"366",
					new object[1] { 6 }
				},
				{
					"367",
					new object[1] { 6 }
				},
				{
					"368",
					new object[1] { 6 }
				},
				{
					"369",
					new object[1] { 6 }
				},
				{
					"390",
					new object[2] { VARIABLE_LENGTH, 15 }
				},
				{
					"391",
					new object[2] { VARIABLE_LENGTH, 18 }
				},
				{
					"392",
					new object[2] { VARIABLE_LENGTH, 15 }
				},
				{
					"393",
					new object[2] { VARIABLE_LENGTH, 18 }
				},
				{
					"703",
					new object[2] { VARIABLE_LENGTH, 30 }
				}
			};
			FOUR_DIGIT_DATA_LENGTH = new Dictionary<string, object[]>
			{
				{
					"7001",
					new object[1] { 13 }
				},
				{
					"7002",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"7003",
					new object[1] { 10 }
				},
				{
					"8001",
					new object[1] { 14 }
				},
				{
					"8002",
					new object[2] { VARIABLE_LENGTH, 20 }
				},
				{
					"8003",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"8004",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"8005",
					new object[1] { 6 }
				},
				{
					"8006",
					new object[1] { 18 }
				},
				{
					"8007",
					new object[2] { VARIABLE_LENGTH, 30 }
				},
				{
					"8008",
					new object[2] { VARIABLE_LENGTH, 12 }
				},
				{
					"8018",
					new object[1] { 18 }
				},
				{
					"8020",
					new object[2] { VARIABLE_LENGTH, 25 }
				},
				{
					"8100",
					new object[1] { 6 }
				},
				{
					"8101",
					new object[1] { 10 }
				},
				{
					"8102",
					new object[1] { 2 }
				},
				{
					"8110",
					new object[2] { VARIABLE_LENGTH, 70 }
				},
				{
					"8200",
					new object[2] { VARIABLE_LENGTH, 70 }
				}
			};
		}

		internal static string parseFieldsInGeneralPurpose(string rawInformation)
		{
			if (string.IsNullOrEmpty(rawInformation))
			{
				return null;
			}
			if (rawInformation.Length < 2)
			{
				return null;
			}
			string key = rawInformation.Substring(0, 2);
			if (TWO_DIGIT_DATA_LENGTH.ContainsKey(key))
			{
				object[] array = TWO_DIGIT_DATA_LENGTH[key];
				if (array[0] == VARIABLE_LENGTH)
				{
					return processVariableAI(2, (int)array[1], rawInformation);
				}
				return processFixedAI(2, (int)array[0], rawInformation);
			}
			if (rawInformation.Length < 3)
			{
				return null;
			}
			string key2 = rawInformation.Substring(0, 3);
			if (THREE_DIGIT_DATA_LENGTH.ContainsKey(key2))
			{
				object[] array2 = THREE_DIGIT_DATA_LENGTH[key2];
				if (array2[0] == VARIABLE_LENGTH)
				{
					return processVariableAI(3, (int)array2[1], rawInformation);
				}
				return processFixedAI(3, (int)array2[0], rawInformation);
			}
			if (THREE_DIGIT_PLUS_DIGIT_DATA_LENGTH.ContainsKey(key2))
			{
				object[] array3 = THREE_DIGIT_PLUS_DIGIT_DATA_LENGTH[key2];
				if (array3[0] == VARIABLE_LENGTH)
				{
					return processVariableAI(4, (int)array3[1], rawInformation);
				}
				return processFixedAI(4, (int)array3[0], rawInformation);
			}
			if (rawInformation.Length < 4)
			{
				return null;
			}
			string key3 = rawInformation.Substring(0, 4);
			if (FOUR_DIGIT_DATA_LENGTH.ContainsKey(key3))
			{
				object[] array4 = FOUR_DIGIT_DATA_LENGTH[key3];
				if (array4[0] == VARIABLE_LENGTH)
				{
					return processVariableAI(4, (int)array4[1], rawInformation);
				}
				return processFixedAI(4, (int)array4[0], rawInformation);
			}
			return null;
		}

		private static string processFixedAI(int aiSize, int fieldSize, string rawInformation)
		{
			if (rawInformation.Length < aiSize)
			{
				return null;
			}
			string text = rawInformation.Substring(0, aiSize);
			if (rawInformation.Length < aiSize + fieldSize)
			{
				return null;
			}
			string text2 = rawInformation.Substring(aiSize, fieldSize);
			string rawInformation2 = rawInformation.Substring(aiSize + fieldSize);
			string text3 = "(" + text + ")" + text2;
			string text4 = parseFieldsInGeneralPurpose(rawInformation2);
			if (text4 != null)
			{
				return text3 + text4;
			}
			return text3;
		}

		private static string processVariableAI(int aiSize, int variableFieldSize, string rawInformation)
		{
			string text = rawInformation.Substring(0, aiSize);
			int num = ((rawInformation.Length >= aiSize + variableFieldSize) ? (aiSize + variableFieldSize) : rawInformation.Length);
			string text2 = rawInformation.Substring(aiSize, num - aiSize);
			string rawInformation2 = rawInformation.Substring(num);
			string text3 = "(" + text + ")" + text2;
			string text4 = parseFieldsInGeneralPurpose(rawInformation2);
			if (text4 != null)
			{
				return text3 + text4;
			}
			return text3;
		}
	}
	internal sealed class GeneralAppIdDecoder
	{
		private ZXing.Common.BitArray information;

		private CurrentParsingState current = new CurrentParsingState();

		private StringBuilder buffer = new StringBuilder();

		internal GeneralAppIdDecoder(ZXing.Common.BitArray information)
		{
			this.information = information;
		}

		internal string decodeAllCodes(StringBuilder buff, int initialPosition)
		{
			int num = initialPosition;
			string remaining = null;
			while (true)
			{
				DecodedInformation decodedInformation = decodeGeneralPurposeField(num, remaining);
				string text = FieldParser.parseFieldsInGeneralPurpose(decodedInformation.getNewString());
				if (text != null)
				{
					buff.Append(text);
				}
				remaining = ((!decodedInformation.isRemaining()) ? null : decodedInformation.getRemainingValue().ToString());
				if (num == decodedInformation.NewPosition)
				{
					break;
				}
				num = decodedInformation.NewPosition;
			}
			return buff.ToString();
		}

		private bool isStillNumeric(int pos)
		{
			if (pos + 7 > information.Size)
			{
				return pos + 4 <= information.Size;
			}
			for (int i = pos; i < pos + 3; i++)
			{
				if (information[i])
				{
					return true;
				}
			}
			return information[pos + 3];
		}

		private DecodedNumeric decodeNumeric(int pos)
		{
			int num;
			if (pos + 7 > information.Size)
			{
				num = extractNumericValueFromBitArray(pos, 4);
				if (num == 0)
				{
					return new DecodedNumeric(information.Size, DecodedNumeric.FNC1, DecodedNumeric.FNC1);
				}
				return new DecodedNumeric(information.Size, num - 1, DecodedNumeric.FNC1);
			}
			num = extractNumericValueFromBitArray(pos, 7);
			int firstDigit = (num - 8) / 11;
			int secondDigit = (num - 8) % 11;
			return new DecodedNumeric(pos + 7, firstDigit, secondDigit);
		}

		internal int extractNumericValueFromBitArray(int pos, int bits)
		{
			return extractNumericValueFromBitArray(information, pos, bits);
		}

		internal static int extractNumericValueFromBitArray(ZXing.Common.BitArray information, int pos, int bits)
		{
			int num = 0;
			for (int i = 0; i < bits; i++)
			{
				if (information[pos + i])
				{
					num |= 1 << bits - i - 1;
				}
			}
			return num;
		}

		internal DecodedInformation decodeGeneralPurposeField(int pos, string remaining)
		{
			buffer.Length = 0;
			if (remaining != null)
			{
				buffer.Append(remaining);
			}
			current.setPosition(pos);
			DecodedInformation decodedInformation = parseBlocks();
			if (decodedInformation != null && decodedInformation.isRemaining())
			{
				return new DecodedInformation(current.getPosition(), buffer.ToString(), decodedInformation.getRemainingValue());
			}
			return new DecodedInformation(current.getPosition(), buffer.ToString());
		}

		private DecodedInformation parseBlocks()
		{
			int position;
			BlockParsedResult blockParsedResult;
			bool flag;
			do
			{
				position = current.getPosition();
				if (current.isAlpha())
				{
					blockParsedResult = parseAlphaBlock();
					flag = blockParsedResult.isFinished();
				}
				else if (current.isIsoIec646())
				{
					blockParsedResult = parseIsoIec646Block();
					flag = blockParsedResult.isFinished();
				}
				else
				{
					blockParsedResult = parseNumericBlock();
					flag = blockParsedResult.isFinished();
				}
			}
			while ((position != current.getPosition() || flag) && !flag);
			return blockParsedResult.getDecodedInformation();
		}

		private BlockParsedResult parseNumericBlock()
		{
			while (isStillNumeric(current.getPosition()))
			{
				DecodedNumeric decodedNumeric = decodeNumeric(current.getPosition());
				current.setPosition(decodedNumeric.NewPosition);
				if (decodedNumeric.isFirstDigitFNC1())
				{
					DecodedInformation decodedInformation = ((!decodedNumeric.isSecondDigitFNC1()) ? new DecodedInformation(current.getPosition(), buffer.ToString(), decodedNumeric.getSecondDigit()) : new DecodedInformation(current.getPosition(), buffer.ToString()));
					return new BlockParsedResult(decodedInformation, finished: true);
				}
				buffer.Append(decodedNumeric.getFirstDigit());
				if (decodedNumeric.isSecondDigitFNC1())
				{
					return new BlockParsedResult(new DecodedInformation(current.getPosition(), buffer.ToString()), finished: true);
				}
				buffer.Append(decodedNumeric.getSecondDigit());
			}
			if (isNumericToAlphaNumericLatch(current.getPosition()))
			{
				current.setAlpha();
				current.incrementPosition(4);
			}
			return new BlockParsedResult(finished: false);
		}

		private BlockParsedResult parseIsoIec646Block()
		{
			while (isStillIsoIec646(current.getPosition()))
			{
				DecodedChar decodedChar = decodeIsoIec646(current.getPosition());
				current.setPosition(decodedChar.NewPosition);
				if (decodedChar.isFNC1())
				{
					return new BlockParsedResult(new DecodedInformation(current.getPosition(), buffer.ToString()), finished: true);
				}
				buffer.Append(decodedChar.getValue());
			}
			if (isAlphaOr646ToNumericLatch(current.getPosition()))
			{
				current.incrementPosition(3);
				current.setNumeric();
			}
			else if (isAlphaTo646ToAlphaLatch(current.getPosition()))
			{
				if (current.getPosition() + 5 < information.Size)
				{
					current.incrementPosition(5);
				}
				else
				{
					current.setPosition(information.Size);
				}
				current.setAlpha();
			}
			return new BlockParsedResult(finished: false);
		}

		private BlockParsedResult parseAlphaBlock()
		{
			while (isStillAlpha(current.getPosition()))
			{
				DecodedChar decodedChar = decodeAlphanumeric(current.getPosition());
				current.setPosition(decodedChar.NewPosition);
				if (decodedChar.isFNC1())
				{
					return new BlockParsedResult(new DecodedInformation(current.getPosition(), buffer.ToString()), finished: true);
				}
				buffer.Append(decodedChar.getValue());
			}
			if (isAlphaOr646ToNumericLatch(current.getPosition()))
			{
				current.incrementPosition(3);
				current.setNumeric();
			}
			else if (isAlphaTo646ToAlphaLatch(current.getPosition()))
			{
				if (current.getPosition() + 5 < information.Size)
				{
					current.incrementPosition(5);
				}
				else
				{
					current.setPosition(information.Size);
				}
				current.setIsoIec646();
			}
			return new BlockParsedResult(finished: false);
		}

		private bool isStillIsoIec646(int pos)
		{
			if (pos + 5 > information.Size)
			{
				return false;
			}
			int num = extractNumericValueFromBitArray(pos, 5);
			if (num >= 5 && num < 16)
			{
				return true;
			}
			if (pos + 7 > information.Size)
			{
				return false;
			}
			int num2 = extractNumericValueFromBitArray(pos, 7);
			if (num2 >= 64 && num2 < 116)
			{
				return true;
			}
			if (pos + 8 > information.Size)
			{
				return false;
			}
			int num3 = extractNumericValueFromBitArray(pos, 8);
			if (num3 >= 232)
			{
				return num3 < 253;
			}
			return false;
		}

		private DecodedChar decodeIsoIec646(int pos)
		{
			int num = extractNumericValueFromBitArray(pos, 5);
			switch (num)
			{
			case 15:
				return new DecodedChar(pos + 5, DecodedChar.FNC1);
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				return new DecodedChar(pos + 5, (char)(48 + num - 5));
			default:
			{
				int num2 = extractNumericValueFromBitArray(pos, 7);
				if (num2 >= 64 && num2 < 90)
				{
					return new DecodedChar(pos + 7, (char)(num2 + 1));
				}
				if (num2 >= 90 && num2 < 116)
				{
					return new DecodedChar(pos + 7, (char)(num2 + 7));
				}
				int num3 = extractNumericValueFromBitArray(pos, 8);
				return new DecodedChar(pos + 8, num3 switch
				{
					232 => '!', 
					233 => '"', 
					234 => '%', 
					235 => '&', 
					236 => '\'', 
					237 => '(', 
					238 => ')', 
					239 => '*', 
					240 => '+', 
					241 => ',', 
					242 => '-', 
					243 => '.', 
					244 => '/', 
					245 => ':', 
					246 => ';', 
					247 => '<', 
					248 => '=', 
					249 => '>', 
					250 => '?', 
					251 => '_', 
					252 => ' ', 
					_ => throw new ArgumentException("Decoding invalid ISO/IEC 646 value: " + num3), 
				});
			}
			}
		}

		private bool isStillAlpha(int pos)
		{
			if (pos + 5 > information.Size)
			{
				return false;
			}
			int num = extractNumericValueFromBitArray(pos, 5);
			if (num >= 5 && num < 16)
			{
				return true;
			}
			if (pos + 6 > information.Size)
			{
				return false;
			}
			int num2 = extractNumericValueFromBitArray(pos, 6);
			if (num2 >= 16)
			{
				return num2 < 63;
			}
			return false;
		}

		private DecodedChar decodeAlphanumeric(int pos)
		{
			int num = extractNumericValueFromBitArray(pos, 5);
			switch (num)
			{
			case 15:
				return new DecodedChar(pos + 5, DecodedChar.FNC1);
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				return new DecodedChar(pos + 5, (char)(48 + num - 5));
			default:
			{
				int num2 = extractNumericValueFromBitArray(pos, 6);
				if (num2 >= 32 && num2 < 58)
				{
					return new DecodedChar(pos + 6, (char)(num2 + 33));
				}
				return new DecodedChar(pos + 6, num2 switch
				{
					58 => '*', 
					59 => ',', 
					60 => '-', 
					61 => '.', 
					62 => '/', 
					_ => throw new InvalidOperationException("Decoding invalid alphanumeric value: " + num2), 
				});
			}
			}
		}

		private bool isAlphaTo646ToAlphaLatch(int pos)
		{
			if (pos + 1 > information.Size)
			{
				return false;
			}
			for (int i = 0; i < 5 && i + pos < information.Size; i++)
			{
				if (i == 2)
				{
					if (!information[pos + 2])
					{
						return false;
					}
				}
				else if (information[pos + i])
				{
					return false;
				}
			}
			return true;
		}

		private bool isAlphaOr646ToNumericLatch(int pos)
		{
			if (pos + 3 > information.Size)
			{
				return false;
			}
			for (int i = pos; i < pos + 3; i++)
			{
				if (information[i])
				{
					return false;
				}
			}
			return true;
		}

		private bool isNumericToAlphaNumericLatch(int pos)
		{
			if (pos + 1 > information.Size)
			{
				return false;
			}
			for (int i = 0; i < 4 && i + pos < information.Size; i++)
			{
				if (information[pos + i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
namespace ZXing.Multi
{
	public sealed class ByQuadrantReader : Reader
	{
		private readonly Reader @delegate;

		public ByQuadrantReader(Reader @delegate)
		{
			this.@delegate = @delegate;
		}

		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			int width = image.Width;
			int height = image.Height;
			int num = width / 2;
			int num2 = height / 2;
			Result result = @delegate.decode(image.crop(0, 0, num, num2), hints);
			if (result != null)
			{
				return result;
			}
			result = @delegate.decode(image.crop(num, 0, num, num2), hints);
			if (result != null)
			{
				makeAbsolute(result.ResultPoints, num, 0);
				return result;
			}
			result = @delegate.decode(image.crop(0, num2, num, num2), hints);
			if (result != null)
			{
				makeAbsolute(result.ResultPoints, 0, num2);
				return result;
			}
			result = @delegate.decode(image.crop(num, num2, num, num2), hints);
			if (result != null)
			{
				makeAbsolute(result.ResultPoints, num, num2);
				return result;
			}
			int num3 = num / 2;
			int num4 = num2 / 2;
			BinaryBitmap image2 = image.crop(num3, num4, num, num2);
			result = @delegate.decode(image2, hints);
			if (result != null)
			{
				makeAbsolute(result.ResultPoints, num3, num4);
			}
			return result;
		}

		public void reset()
		{
			@delegate.reset();
		}

		private static void makeAbsolute(ResultPoint[] points, int leftOffset, int topOffset)
		{
			if (points != null)
			{
				for (int i = 0; i < points.Length; i++)
				{
					ResultPoint resultPoint = points[i];
					points[i] = new ResultPoint(resultPoint.X + (float)leftOffset, resultPoint.Y + (float)topOffset);
				}
			}
		}
	}
	public sealed class GenericMultipleBarcodeReader : MultipleBarcodeReader, Reader
	{
		private const int MIN_DIMENSION_TO_RECUR = 30;

		private const int MAX_DEPTH = 4;

		private readonly Reader _delegate;

		public GenericMultipleBarcodeReader(Reader @delegate)
		{
			_delegate = @delegate;
		}

		public Result[] decodeMultiple(BinaryBitmap image)
		{
			return decodeMultiple(image, null);
		}

		public Result[] decodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			List<Result> list = new List<Result>();
			doDecodeMultiple(image, hints, list, 0, 0, 0);
			if (list.Count == 0)
			{
				return null;
			}
			int count = list.Count;
			Result[] array = new Result[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		private void doDecodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints, IList<Result> results, int xOffset, int yOffset, int currentDepth)
		{
			if (currentDepth > 4)
			{
				return;
			}
			Result result = _delegate.decode(image, hints);
			if (result == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < results.Count; i++)
			{
				if (results[i].Text.Equals(result.Text))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				results.Add(translateResultPoints(result, xOffset, yOffset));
			}
			ResultPoint[] resultPoints = result.ResultPoints;
			if (resultPoints == null || resultPoints.Length == 0)
			{
				return;
			}
			int width = image.Width;
			int height = image.Height;
			float num = width;
			float num2 = height;
			float num3 = 0f;
			float num4 = 0f;
			foreach (ResultPoint resultPoint in resultPoints)
			{
				if (resultPoint != null)
				{
					float x = resultPoint.X;
					float y = resultPoint.Y;
					if (x < num)
					{
						num = x;
					}
					if (y < num2)
					{
						num2 = y;
					}
					if (x > num3)
					{
						num3 = x;
					}
					if (y > num4)
					{
						num4 = y;
					}
				}
			}
			if (num > 30f)
			{
				doDecodeMultiple(image.crop(0, 0, (int)num, height), hints, results, xOffset, yOffset, currentDepth + 1);
			}
			if (num2 > 30f)
			{
				doDecodeMultiple(image.crop(0, 0, width, (int)num2), hints, results, xOffset, yOffset, currentDepth + 1);
			}
			if (num3 < (float)(width - 30))
			{
				doDecodeMultiple(image.crop((int)num3, 0, width - (int)num3, height), hints, results, xOffset + (int)num3, yOffset, currentDepth + 1);
			}
			if (num4 < (float)(height - 30))
			{
				doDecodeMultiple(image.crop(0, (int)num4, width, height - (int)num4), hints, results, xOffset, yOffset + (int)num4, currentDepth + 1);
			}
		}

		private static Result translateResultPoints(Result result, int xOffset, int yOffset)
		{
			ResultPoint[] resultPoints = result.ResultPoints;
			ResultPoint[] array = new ResultPoint[resultPoints.Length];
			for (int i = 0; i < resultPoints.Length; i++)
			{
				ResultPoint resultPoint = resultPoints[i];
				if (resultPoint != null)
				{
					array[i] = new ResultPoint(resultPoint.X + (float)xOffset, resultPoint.Y + (float)yOffset);
				}
			}
			Result result2 = new Result(result.Text, result.RawBytes, result.NumBits, array, result.BarcodeFormat);
			result2.putAllMetadata(result.ResultMetadata);
			return result2;
		}

		public Result decode(BinaryBitmap image)
		{
			return _delegate.decode(image);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			return _delegate.decode(image, hints);
		}

		public void reset()
		{
			_delegate.reset();
		}
	}
	public interface MultipleBarcodeReader
	{
		Result[] decodeMultiple(BinaryBitmap image);

		Result[] decodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints);
	}
}
namespace ZXing.Multi.QrCode
{
	public sealed class QRCodeMultiReader : QRCodeReader, MultipleBarcodeReader
	{
		private static readonly ResultPoint[] NO_POINTS = new ResultPoint[0];

		public Result[] decodeMultiple(BinaryBitmap image)
		{
			return decodeMultiple(image, null);
		}

		public Result[] decodeMultiple(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			List<Result> list = new List<Result>();
			DetectorResult[] array = new MultiDetector(image.BlackMatrix).detectMulti(hints);
			foreach (DetectorResult detectorResult in array)
			{
				DecoderResult decoderResult = getDecoder().decode(detectorResult.Bits, hints);
				if (decoderResult != null)
				{
					ResultPoint[] points = detectorResult.Points;
					if (decoderResult.Other is QRCodeDecoderMetaData qRCodeDecoderMetaData)
					{
						qRCodeDecoderMetaData.applyMirroredCorrection(points);
					}
					Result result = new Result(decoderResult.Text, decoderResult.RawBytes, points, BarcodeFormat.QR_CODE);
					IList<byte[]> byteSegments = decoderResult.ByteSegments;
					if (byteSegments != null)
					{
						result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, byteSegments);
					}
					string eCLevel = decoderResult.ECLevel;
					if (eCLevel != null)
					{
						result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, eCLevel);
					}
					if (decoderResult.StructuredAppend)
					{
						result.putMetadata(ResultMetadataType.STRUCTURED_APPEND_SEQUENCE, decoderResult.StructuredAppendSequenceNumber);
						result.putMetadata(ResultMetadataType.STRUCTURED_APPEND_PARITY, decoderResult.StructuredAppendParity);
					}
					list.Add(result);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			list = ProcessStructuredAppend(list);
			return list.ToArray();
		}

		private List<Result> ProcessStructuredAppend(List<Result> results)
		{
			bool flag = false;
			foreach (Result result2 in results)
			{
				if (result2.ResultMetadata.ContainsKey(ResultMetadataType.STRUCTURED_APPEND_SEQUENCE))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return results;
			}
			List<Result> list = new List<Result>();
			List<Result> list2 = new List<Result>();
			foreach (Result result3 in results)
			{
				list.Add(result3);
				if (result3.ResultMetadata.ContainsKey(ResultMetadataType.STRUCTURED_APPEND_SEQUENCE))
				{
					list2.Add(result3);
				}
			}
			list2.Sort(SaSequenceSort);
			string text = string.Empty;
			int num = 0;
			int num2 = 0;
			foreach (Result item in list2)
			{
				text += item.Text;
				num += item.RawBytes.Length;
				if (!item.ResultMetadata.ContainsKey(ResultMetadataType.BYTE_SEGMENTS))
				{
					continue;
				}
				foreach (byte[] item2 in (IEnumerable<byte[]>)item.ResultMetadata[ResultMetadataType.BYTE_SEGMENTS])
				{
					num2 += item2.Length;
				}
			}
			byte[] array = new byte[num];
			byte[] array2 = new byte[num2];
			int num3 = 0;
			int num4 = 0;
			foreach (Result item3 in list2)
			{
				Array.Copy(item3.RawBytes, 0, array, num3, item3.RawBytes.Length);
				num3 += item3.RawBytes.Length;
				if (!item3.ResultMetadata.ContainsKey(ResultMetadataType.BYTE_SEGMENTS))
				{
					continue;
				}
				foreach (byte[] item4 in (IEnumerable<byte[]>)item3.ResultMetadata[ResultMetadataType.BYTE_SEGMENTS])
				{
					Array.Copy(item4, 0, array2, num4, item4.Length);
					num4 += item4.Length;
				}
			}
			Result result = new Result(text, array, NO_POINTS, BarcodeFormat.QR_CODE);
			if (num2 > 0)
			{
				List<byte[]> list3 = new List<byte[]>();
				list3.Add(array2);
				result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, list3);
			}
			list.Add(result);
			return list;
		}

		private int SaSequenceSort(Result a, Result b)
		{
			int num = (int)a.ResultMetadata[ResultMetadataType.STRUCTURED_APPEND_SEQUENCE];
			int num2 = (int)b.ResultMetadata[ResultMetadataType.STRUCTURED_APPEND_SEQUENCE];
			return num - num2;
		}
	}
}
namespace ZXing.Multi.QrCode.Internal
{
	public sealed class MultiDetector : ZXing.QrCode.Internal.Detector
	{
		private static readonly DetectorResult[] EMPTY_DETECTOR_RESULTS = new DetectorResult[0];

		public MultiDetector(BitMatrix image)
			: base(image)
		{
		}

		public DetectorResult[] detectMulti(IDictionary<DecodeHintType, object> hints)
		{
			BitMatrix bitMatrix = Image;
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			FinderPatternInfo[] array = new MultiFinderPatternFinder(bitMatrix, resultPointCallback).findMulti(hints);
			if (array.Length == 0)
			{
				return EMPTY_DETECTOR_RESULTS;
			}
			List<DetectorResult> list = new List<DetectorResult>();
			FinderPatternInfo[] array2 = array;
			foreach (FinderPatternInfo info in array2)
			{
				DetectorResult detectorResult = processFinderPatternInfo(info);
				if (detectorResult != null)
				{
					list.Add(detectorResult);
				}
			}
			if (list.Count == 0)
			{
				return EMPTY_DETECTOR_RESULTS;
			}
			return list.ToArray();
		}
	}
	internal sealed class MultiFinderPatternFinder : FinderPatternFinder
	{
		private sealed class ModuleSizeComparator : IComparer<ZXing.QrCode.Internal.FinderPattern>
		{
			public int Compare(ZXing.QrCode.Internal.FinderPattern center1, ZXing.QrCode.Internal.FinderPattern center2)
			{
				float num = center2.EstimatedModuleSize - center1.EstimatedModuleSize;
				if (!((double)num < 0.0))
				{
					if (!((double)num > 0.0))
					{
						return 0;
					}
					return 1;
				}
				return -1;
			}
		}

		private static readonly FinderPatternInfo[] EMPTY_RESULT_ARRAY = new FinderPatternInfo[0];

		private static float MAX_MODULE_COUNT_PER_EDGE = 180f;

		private static float MIN_MODULE_COUNT_PER_EDGE = 9f;

		private static float DIFF_MODSIZE_CUTOFF_PERCENT = 0.05f;

		private const float DIFF_MODSIZE_CUTOFF = 0.5f;

		internal MultiFinderPatternFinder(BitMatrix image)
			: base(image)
		{
		}

		internal MultiFinderPatternFinder(BitMatrix image, ResultPointCallback resultPointCallback)
			: base(image, resultPointCallback)
		{
		}

		private ZXing.QrCode.Internal.FinderPattern[][] selectMutipleBestPatterns()
		{
			List<ZXing.QrCode.Internal.FinderPattern> list = PossibleCenters;
			int count = list.Count;
			if (count < 3)
			{
				return null;
			}
			if (count == 3)
			{
				return new ZXing.QrCode.Internal.FinderPattern[1][] { new ZXing.QrCode.Internal.FinderPattern[3]
				{
					list[0],
					list[1],
					list[2]
				} };
			}
			list.Sort(new ModuleSizeComparator());
			List<ZXing.QrCode.Internal.FinderPattern[]> list2 = new List<ZXing.QrCode.Internal.FinderPattern[]>();
			for (int i = 0; i < count - 2; i++)
			{
				ZXing.QrCode.Internal.FinderPattern finderPattern = list[i];
				if (finderPattern == null)
				{
					continue;
				}
				for (int j = i + 1; j < count - 1; j++)
				{
					ZXing.QrCode.Internal.FinderPattern finderPattern2 = list[j];
					if (finderPattern2 == null)
					{
						continue;
					}
					float num = (finderPattern.EstimatedModuleSize - finderPattern2.EstimatedModuleSize) / Math.Min(finderPattern.EstimatedModuleSize, finderPattern2.EstimatedModuleSize);
					if (Math.Abs(finderPattern.EstimatedModuleSize - finderPattern2.EstimatedModuleSize) > 0.5f && num >= DIFF_MODSIZE_CUTOFF_PERCENT)
					{
						break;
					}
					for (int k = j + 1; k < count; k++)
					{
						ZXing.QrCode.Internal.FinderPattern finderPattern3 = list[k];
						if (finderPattern3 == null)
						{
							continue;
						}
						float num2 = (finderPattern2.EstimatedModuleSize - finderPattern3.EstimatedModuleSize) / Math.Min(finderPattern2.EstimatedModuleSize, finderPattern3.EstimatedModuleSize);
						if (Math.Abs(finderPattern2.EstimatedModuleSize - finderPattern3.EstimatedModuleSize) > 0.5f && num2 >= DIFF_MODSIZE_CUTOFF_PERCENT)
						{
							break;
						}
						ZXing.QrCode.Internal.FinderPattern[] array = new ZXing.QrCode.Internal.FinderPattern[3] { finderPattern, finderPattern2, finderPattern3 };
						ResultPoint[] patterns = array;
						ResultPoint.orderBestPatterns(patterns);
						FinderPatternInfo finderPatternInfo = new FinderPatternInfo(array);
						float num3 = ResultPoint.distance(finderPatternInfo.TopLeft, finderPatternInfo.BottomLeft);
						float num4 = ResultPoint.distance(finderPatternInfo.TopRight, finderPatternInfo.BottomLeft);
						float num5 = ResultPoint.distance(finderPatternInfo.TopLeft, finderPatternInfo.TopRight);
						float num6 = (num3 + num5) / (finderPattern.EstimatedModuleSize * 2f);
						if (!(num6 > MAX_MODULE_COUNT_PER_EDGE) && !(num6 < MIN_MODULE_COUNT_PER_EDGE) && !(Math.Abs((num3 - num5) / Math.Min(num3, num5)) >= 0.1f))
						{
							float num7 = (float)Math.Sqrt(num3 * num3 + num5 * num5);
							if (!(Math.Abs((num4 - num7) / Math.Min(num4, num7)) >= 0.1f))
							{
								list2.Add(array);
							}
						}
					}
				}
			}
			if (list2.Count != 0)
			{
				return list2.ToArray();
			}
			return null;
		}

		public FinderPatternInfo[] findMulti(IDictionary<DecodeHintType, object> hints)
		{
			bool flag = hints?.ContainsKey(DecodeHintType.TRY_HARDER) ?? false;
			BitMatrix bitMatrix = Image;
			int height = bitMatrix.Height;
			int width = bitMatrix.Width;
			int num = 3 * height / 388;
			if (num < 3 || flag)
			{
				num = 3;
			}
			int[] array = new int[5];
			for (int i = num - 1; i < height; i += num)
			{
				clearCounts(array);
				int num2 = 0;
				for (int j = 0; j < width; j++)
				{
					if (bitMatrix[j, i])
					{
						if ((num2 & 1) == 1)
						{
							num2++;
						}
						array[num2]++;
					}
					else if ((num2 & 1) == 0)
					{
						if (num2 == 4)
						{
							if (FinderPatternFinder.foundPatternCross(array) && handlePossibleCenter(array, i, j))
							{
								num2 = 0;
								clearCounts(array);
							}
							else
							{
								shiftCounts2(array);
								num2 = 3;
							}
						}
						else
						{
							array[++num2]++;
						}
					}
					else
					{
						array[num2]++;
					}
				}
				if (FinderPatternFinder.foundPatternCross(array))
				{
					handlePossibleCenter(array, i, width);
				}
			}
			ZXing.QrCode.Internal.FinderPattern[][] array2 = selectMutipleBestPatterns();
			if (array2 == null)
			{
				return EMPTY_RESULT_ARRAY;
			}
			List<FinderPatternInfo> list = new List<FinderPatternInfo>();
			ZXing.QrCode.Internal.FinderPattern[][] array3 = array2;
			foreach (ZXing.QrCode.Internal.FinderPattern[] array4 in array3)
			{
				ResultPoint[] patterns = array4;
				ResultPoint.orderBestPatterns(patterns);
				list.Add(new FinderPatternInfo(array4));
			}
			if (list.Count == 0)
			{
				return EMPTY_RESULT_ARRAY;
			}
			return list.ToArray();
		}
	}
}
namespace ZXing.Maxicode
{
	public sealed class MaxiCodeReader : Reader
	{
		private static readonly ResultPoint[] NO_POINTS = new ResultPoint[0];

		private const int MATRIX_WIDTH = 30;

		private const int MATRIX_HEIGHT = 33;

		private readonly ZXing.Maxicode.Internal.Decoder decoder = new ZXing.Maxicode.Internal.Decoder();

		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			if (hints != null && hints.ContainsKey(DecodeHintType.PURE_BARCODE))
			{
				BitMatrix bitMatrix = extractPureBits(image.BlackMatrix);
				if (bitMatrix == null)
				{
					return null;
				}
				DecoderResult decoderResult = decoder.decode(bitMatrix, hints);
				if (decoderResult == null)
				{
					return null;
				}
				Result result = new Result(decoderResult.Text, decoderResult.RawBytes, NO_POINTS, BarcodeFormat.MAXICODE);
				string eCLevel = decoderResult.ECLevel;
				if (eCLevel != null)
				{
					result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, eCLevel);
				}
				return result;
			}
			return null;
		}

		public void reset()
		{
		}

		private static BitMatrix extractPureBits(BitMatrix image)
		{
			int[] enclosingRectangle = image.getEnclosingRectangle();
			if (enclosingRectangle == null)
			{
				return null;
			}
			int num = enclosingRectangle[0];
			int num2 = enclosingRectangle[1];
			int num3 = enclosingRectangle[2];
			int num4 = enclosingRectangle[3];
			BitMatrix bitMatrix = new BitMatrix(30, 33);
			for (int i = 0; i < 33; i++)
			{
				int y = num2 + (i * num4 + num4 / 2) / 33;
				for (int j = 0; j < 30; j++)
				{
					int x = num + (j * num3 + num3 / 2 + (i & 1) * num3 / 2) / 30;
					if (image[x, y])
					{
						bitMatrix[j, i] = true;
					}
				}
			}
			return bitMatrix;
		}
	}
}
namespace ZXing.Maxicode.Internal
{
	internal sealed class BitMatrixParser
	{
		private static readonly int[][] BITNR = new int[33][]
		{
			new int[30]
			{
				121, 120, 127, 126, 133, 132, 139, 138, 145, 144,
				151, 150, 157, 156, 163, 162, 169, 168, 175, 174,
				181, 180, 187, 186, 193, 192, 199, 198, -2, -2
			},
			new int[30]
			{
				123, 122, 129, 128, 135, 134, 141, 140, 147, 146,
				153, 152, 159, 158, 165, 164, 171, 170, 177, 176,
				183, 182, 189, 188, 195, 194, 201, 200, 816, -3
			},
			new int[30]
			{
				125, 124, 131, 130, 137, 136, 143, 142, 149, 148,
				155, 154, 161, 160, 167, 166, 173, 172, 179, 178,
				185, 184, 191, 190, 197, 196, 203, 202, 818, 817
			},
			new int[30]
			{
				283, 282, 277, 276, 271, 270, 265, 264, 259, 258,
				253, 252, 247, 246, 241, 240, 235, 234, 229, 228,
				223, 222, 217, 216, 211, 210, 205, 204, 819, -3
			},
			new int[30]
			{
				285, 284, 279, 278, 273, 272, 267, 266, 261, 260,
				255, 254, 249, 248, 243, 242, 237, 236, 231, 230,
				225, 224, 219, 218, 213, 212, 207, 206, 821, 820
			},
			new int[30]
			{
				287, 286, 281, 280, 275, 274, 269, 268, 263, 262,
				257, 256, 251, 250, 245, 244, 239, 238, 233, 232,
				227, 226, 221, 220, 215, 214, 209, 208, 822, -3
			},
			new int[30]
			{
				289, 288, 295, 294, 301, 300, 307, 306, 313, 312,
				319, 318, 325, 324, 331, 330, 337, 336, 343, 342,
				349, 348, 355, 354, 361, 360, 367, 366, 824, 823
			},
			new int[30]
			{
				291, 290, 297, 296, 303, 302, 309, 308, 315, 314,
				321, 320, 327, 326, 333, 332, 339, 338, 345, 344,
				351, 350, 357, 356, 363, 362, 369, 368, 825, -3
			},
			new int[30]
			{
				293, 292, 299, 298, 305, 304, 311, 310, 317, 316,
				323, 322, 329, 328, 335, 334, 341, 340, 347, 346,
				353, 352, 359, 358, 365, 364, 371, 370, 827, 826
			},
			new int[30]
			{
				409, 408, 403, 402, 397, 396, 391, 390, 79, 78,
				-2, -2, 13, 12, 37, 36, 2, -1, 44, 43,
				109, 108, 385, 384, 379, 378, 373, 372, 828, -3
			},
			new int[30]
			{
				411, 410, 405, 404, 399, 398, 393, 392, 81, 80,
				40, -2, 15, 14, 39, 38, 3, -1, -1, 45,
				111, 110, 387, 386, 381, 380, 375, 374, 830, 829
			},
			new int[30]
			{
				413, 412, 407, 406, 401, 400, 395, 394, 83, 82,
				41, -3, -3, -3, -3, -3, 5, 4, 47, 46,
				113, 112, 389, 388, 383, 382, 377, 376, 831, -3
			},
			new int[30]
			{
				415, 414, 421, 420, 427, 426, 103, 102, 55, 54,
				16, -3, -3, -3, -3, -3, -3, -3, 20, 19,
				85, 84, 433, 432, 439, 438, 445, 444, 833, 832
			},
			new int[30]
			{
				417, 416, 423, 422, 429, 428, 105, 104, 57, 56,
				-3, -3, -3, -3, -3, -3, -3, -3, 22, 21,
				87, 86, 435, 434, 441, 440, 447, 446, 834, -3
			},
			new int[30]
			{
				419, 418, 425, 424, 431, 430, 107, 106, 59, 58,
				-3, -3, -3, -3, -3, -3, -3, -3, -3, 23,
				89, 88, 437, 436, 443, 442, 449, 448, 836, 835
			},
			new int[30]
			{
				481, 480, 475, 474, 469, 468, 48, -2, 30, -3,
				-3, -3, -3, -3, -3, -3, -3, -3, -3, 0,
				53, 52, 463, 462, 457, 456, 451, 450, 837, -3
			},
			new int[30]
			{
				483, 482, 477, 476, 471, 470, 49, -1, -2, -3,
				-3, -3, -3, -3, -3, -3, -3, -3, -3, -3,
				-2, -1, 465, 464, 459, 458, 453, 452, 839, 838
			},
			new int[30]
			{
				485, 484, 479, 478, 473, 472, 51, 50, 31, -3,
				-3, -3, -3, -3, -3, -3, -3, -3, -3, 1,
				-2, 42, 467, 466, 461, 460, 455, 454, 840, -3
			},
			new int[30]
			{
				487, 486, 493, 492, 499, 498, 97, 96, 61, 60,
				-3, -3, -3, -3, -3, -3, -3, -3, -3, 26,
				91, 90, 505, 504, 511, 510, 517, 516, 842, 841
			},
			new int[30]
			{
				489, 488, 495, 494, 501, 500, 99, 98, 63, 62,
				-3, -3, -3, -3, -3, -3, -3, -3, 28, 27,
				93, 92, 507, 506, 513, 512, 519, 518, 843, -3
			},
			new int[30]
			{
				491, 490, 497, 496, 503, 502, 101, 100, 65, 64,
				17, -3, -3, -3, -3, -3, -3, -3, 18, 29,
				95, 94, 509, 508, 515, 514, 521, 520, 845, 844
			},
			new int[30]
			{
				559, 558, 553, 552, 547, 546, 541, 540, 73, 72,
				32, -3, -3, -3, -3, -3, -3, 10, 67, 66,
				115, 114, 535, 534, 529, 528, 523, 522, 846, -3
			},
			new int[30]
			{
				561, 560, 555, 554, 549, 548, 543, 542, 75, 74,
				-2, -1, 7, 6, 35, 34, 11, -2, 69, 68,
				117, 116, 537, 536, 531, 530, 525, 524, 848, 847
			},
			new int[30]
			{
				563, 562, 557, 556, 551, 550, 545, 544, 77, 76,
				-2, 33, 9, 8, 25, 24, -1, -2, 71, 70,
				119, 118, 539, 538, 533, 532, 527, 526, 849, -3
			},
			new int[30]
			{
				565, 564, 571, 570, 577, 576, 583, 582, 589, 588,
				595, 594, 601, 600, 607, 606, 613, 612, 619, 618,
				625, 624, 631, 630, 637, 636, 643, 642, 851, 850
			},
			new int[30]
			{
				567, 566, 573, 572, 579, 578, 585, 584, 591, 590,
				597, 596, 603, 602, 609, 608, 615, 614, 621, 620,
				627, 626, 633, 632, 639, 638, 645, 644, 852, -3
			},
			new int[30]
			{
				569, 568, 575, 574, 581, 580, 587, 586, 593, 592,
				599, 598, 605, 604, 611, 610, 617, 616, 623, 622,
				629, 628, 635, 634, 641, 640, 647, 646, 854, 853
			},
			new int[30]
			{
				727, 726, 721, 720, 715, 714, 709, 708, 703, 702,
				697, 696, 691, 690, 685, 684, 679, 678, 673, 672,
				667, 666, 661, 660, 655, 654, 649, 648, 855, -3
			},
			new int[30]
			{
				729, 728, 723, 722, 717, 716, 711, 710, 705, 704,
				699, 698, 693, 692, 687, 686, 681, 680, 675, 674,
				669, 668, 663, 662, 657, 656, 651, 650, 857, 856
			},
			new int[30]
			{
				731, 730, 725, 724, 719, 718, 713, 712, 707, 706,
				701, 700, 695, 694, 689, 688, 683, 682, 677, 676,
				671, 670, 665, 664, 659, 658, 653, 652, 858, -3
			},
			new int[30]
			{
				733, 732, 739, 738, 745, 744, 751, 750, 757, 756,
				763, 762, 769, 768, 775, 774, 781, 780, 787, 786,
				793, 792, 799, 798, 805, 804, 811, 810, 860, 859
			},
			new int[30]
			{
				735, 734, 741, 740, 747, 746, 753, 752, 759, 758,
				765, 764, 771, 770, 777, 776, 783, 782, 789, 788,
				795, 794, 801, 800, 807, 806, 813, 812, 861, -3
			},
			new int[30]
			{
				737, 736, 743, 742, 749, 748, 755, 754, 761, 760,
				767, 766, 773, 772, 779, 778, 785, 784, 791, 790,
				797, 796, 803, 802, 809, 808, 815, 814, 863, 862
			}
		};

		private readonly BitMatrix bitMatrix;

		internal BitMatrixParser(BitMatrix bitMatrix)
		{
			this.bitMatrix = bitMatrix;
		}

		internal byte[] readCodewords()
		{
			byte[] array = new byte[144];
			int height = bitMatrix.Height;
			int width = bitMatrix.Width;
			for (int i = 0; i < height; i++)
			{
				int[] array2 = BITNR[i];
				for (int j = 0; j < width; j++)
				{
					int num = array2[j];
					if (num >= 0 && bitMatrix[j, i])
					{
						array[num / 6] |= (byte)(1 << 5 - num % 6);
					}
				}
			}
			return array;
		}
	}
	internal static class DecodedBitStreamParser
	{
		private const char SHIFTA = '\ufff0';

		private const char SHIFTB = '\ufff1';

		private const char SHIFTC = '\ufff2';

		private const char SHIFTD = '\ufff3';

		private const char SHIFTE = '\ufff4';

		private const char TWOSHIFTA = '\ufff5';

		private const char THREESHIFTA = '\ufff6';

		private const char LATCHA = '\ufff7';

		private const char LATCHB = '\ufff8';

		private const char LOCK = '\ufff9';

		private const char ECI = '\ufffa';

		private const char NS = '\ufffb';

		private const char PAD = '￼';

		private const char FS = '\u001c';

		private const char GS = '\u001d';

		private const char RS = '\u001e';

		private const string NINE_DIGITS = "000000000";

		private const string THREE_DIGITS = "000";

		private static string[] SETS = new string[6] { "\nABCDEFGHIJKLMNOPQRSTUVWXYZ\ufffa\u001c\u001d\u001e\ufffb ￼\"#$%&'()*+,-./0123456789:\ufff1\ufff2\ufff3\ufff4\ufff8", "`abcdefghijklmnopqrstuvwxyz\ufffa\u001c\u001d\u001e\ufffb{￼}~\u007f;<=>?[\\]^_ ,./:@!|￼\ufff5\ufff6￼\ufff0\ufff2\ufff3\ufff4\ufff7", "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚ\ufffa\u001c\u001d\u001eÛÜÝÞßª¬±²³µ¹º¼½¾\u0080\u0081\u0082\u0083\u0084\u0085\u0086\u0087\u0088\u0089\ufff7 \ufff9\ufff3\ufff4\ufff8", "àáâãäåæçèéêëìíîïðñòóôõö÷øùú\ufffa\u001c\u001d\u001e\ufffbûüýþÿ¡\u00a8«\u00af°\u00b4·\u00b8»¿\u008a\u008b\u008c\u008d\u008e\u008f\u0090\u0091\u0092\u0093\u0094\ufff7 \ufff2\ufff9\ufff4\ufff8", "\0\u0001\u0002\u0003\u0004\u0005\u0006\a\b\t\n\v\f\r\u000e\u000f\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\ufffa￼￼\u001b\ufffb\u001c\u001d\u001e\u001f\u009f\u00a0¢£¤¥¦§©\u00ad®¶\u0095\u0096\u0097\u0098\u0099\u009a\u009b\u009c\u009d\u009e\ufff7 \ufff2\ufff3\ufff9\ufff8", "\0\u0001\u0002\u0003\u0004\u0005\u0006\a\b\t\n\v\f\r\u000e\u000f\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\u001c\u001d\u001e\u001f !\"#$%&'()*+,-./0123456789:;<=>?" };

		internal static DecoderResult decode(byte[] bytes, int mode)
		{
			StringBuilder stringBuilder = new StringBuilder(144);
			string text;
			string text3;
			string text4;
			switch (mode)
			{
			case 2:
			{
				int postCode = getPostCode2(bytes);
				string text2 = "0000000000".Substring(0, getPostCode2Length(bytes));
				text = postCode.ToString(text2);
				goto IL_005a;
			}
			case 3:
				text = getPostCode3(bytes);
				goto IL_005a;
			case 4:
				stringBuilder.Append(getMessage(bytes, 1, 93));
				break;
			case 5:
				{
					stringBuilder.Append(getMessage(bytes, 1, 77));
					break;
				}
				IL_005a:
				text3 = getCountry(bytes).ToString("000");
				text4 = getServiceClass(bytes).ToString("000");
				stringBuilder.Append(getMessage(bytes, 10, 84));
				if (stringBuilder.ToString().StartsWith("[)>\u001e01\u001d"))
				{
					stringBuilder.Insert(9, text + "\u001d" + text3 + "\u001d" + text4 + "\u001d");
				}
				else
				{
					stringBuilder.Insert(0, text + "\u001d" + text3 + "\u001d" + text4 + "\u001d");
				}
				break;
			}
			return new DecoderResult(bytes, stringBuilder.ToString(), null, mode.ToString());
		}

		private static int getBit(int bit, byte[] bytes)
		{
			bit--;
			if ((bytes[bit / 6] & (1 << 5 - bit % 6)) != 0)
			{
				return 1;
			}
			return 0;
		}

		private static int getInt(byte[] bytes, byte[] x)
		{
			if (x.Length == 0)
			{
				throw new ArgumentException("x");
			}
			int num = 0;
			for (int i = 0; i < x.Length; i++)
			{
				num += getBit(x[i], bytes) << x.Length - i - 1;
			}
			return num;
		}

		private static int getCountry(byte[] bytes)
		{
			return getInt(bytes, new byte[10] { 53, 54, 43, 44, 45, 46, 47, 48, 37, 38 });
		}

		private static int getServiceClass(byte[] bytes)
		{
			return getInt(bytes, new byte[10] { 55, 56, 57, 58, 59, 60, 49, 50, 51, 52 });
		}

		private static int getPostCode2Length(byte[] bytes)
		{
			return getInt(bytes, new byte[6] { 39, 40, 41, 42, 31, 32 });
		}

		private static int getPostCode2(byte[] bytes)
		{
			return getInt(bytes, new byte[30]
			{
				33, 34, 35, 36, 25, 26, 27, 28, 29, 30,
				19, 20, 21, 22, 23, 24, 13, 14, 15, 16,
				17, 18, 7, 8, 9, 10, 11, 12, 1, 2
			});
		}

		private static string getPostCode3(byte[] bytes)
		{
			return new string(new char[6]
			{
				SETS[0][getInt(bytes, new byte[6] { 39, 40, 41, 42, 31, 32 })],
				SETS[0][getInt(bytes, new byte[6] { 33, 34, 35, 36, 25, 26 })],
				SETS[0][getInt(bytes, new byte[6] { 27, 28, 29, 30, 19, 20 })],
				SETS[0][getInt(bytes, new byte[6] { 21, 22, 23, 24, 13, 14 })],
				SETS[0][getInt(bytes, new byte[6] { 15, 16, 17, 18, 7, 8 })],
				SETS[0][getInt(bytes, new byte[6] { 9, 10, 11, 12, 1, 2 })]
			});
		}

		private static string getMessage(byte[] bytes, int start, int len)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = -1;
			int num2 = 0;
			int num3 = 0;
			for (int i = start; i < start + len; i++)
			{
				char c = SETS[num2][bytes[i]];
				switch (c)
				{
				case '\ufff7':
					num2 = 0;
					num = -1;
					break;
				case '\ufff8':
					num2 = 1;
					num = -1;
					break;
				case '\ufff0':
				case '\ufff1':
				case '\ufff2':
				case '\ufff3':
				case '\ufff4':
					num3 = num2;
					num2 = c - 65520;
					num = 1;
					break;
				case '\ufff5':
					num3 = num2;
					num2 = 0;
					num = 2;
					break;
				case '\ufff6':
					num3 = num2;
					num2 = 0;
					num = 3;
					break;
				case '\ufffb':
					stringBuilder.Append(((bytes[++i] << 24) + (bytes[++i] << 18) + (bytes[++i] << 12) + (bytes[++i] << 6) + bytes[++i]).ToString("000000000"));
					break;
				case '\ufff9':
					num = -1;
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
				if (num-- == 0)
				{
					num2 = num3;
				}
			}
			while (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == '￼')
			{
				stringBuilder.Length--;
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class Decoder
	{
		private const int ALL = 0;

		private const int EVEN = 1;

		private const int ODD = 2;

		private readonly ReedSolomonDecoder rsDecoder;

		public Decoder()
		{
			rsDecoder = new ReedSolomonDecoder(GenericGF.MAXICODE_FIELD_64);
		}

		public DecoderResult decode(BitMatrix bits)
		{
			return decode(bits, null);
		}

		public DecoderResult decode(BitMatrix bits, IDictionary<DecodeHintType, object> hints)
		{
			byte[] array = new BitMatrixParser(bits).readCodewords();
			if (!correctErrors(array, 0, 10, 10, 0))
			{
				return null;
			}
			int num = array[0] & 0xF;
			byte[] array2;
			switch (num)
			{
			case 2:
			case 3:
			case 4:
				if (!correctErrors(array, 20, 84, 40, 1))
				{
					return null;
				}
				if (!correctErrors(array, 20, 84, 40, 2))
				{
					return null;
				}
				array2 = new byte[94];
				break;
			case 5:
				if (!correctErrors(array, 20, 68, 56, 1))
				{
					return null;
				}
				if (!correctErrors(array, 20, 68, 56, 2))
				{
					return null;
				}
				array2 = new byte[78];
				break;
			default:
				return null;
			}
			Array.Copy(array, 0, array2, 0, 10);
			Array.Copy(array, 20, array2, 10, array2.Length - 10);
			return DecodedBitStreamParser.decode(array2, num);
		}

		private bool correctErrors(byte[] codewordBytes, int start, int dataCodewords, int ecCodewords, int mode)
		{
			int num = dataCodewords + ecCodewords;
			int num2 = ((mode == 0) ? 1 : 2);
			int[] array = new int[num / num2];
			for (int i = 0; i < num; i++)
			{
				if (mode == 0 || i % 2 == mode - 1)
				{
					array[i / num2] = codewordBytes[i + start] & 0xFF;
				}
			}
			if (!rsDecoder.decode(array, ecCodewords / num2))
			{
				return false;
			}
			for (int j = 0; j < dataCodewords; j++)
			{
				if (mode == 0 || j % 2 == mode - 1)
				{
					codewordBytes[j + start] = (byte)array[j / num2];
				}
			}
			return true;
		}
	}
}
namespace ZXing.IMB
{
	public sealed class IMBReader : OneDReader
	{
		private const int NUM_BARS_IMB = 65;

		private static readonly int[] barPosA;

		private static readonly int[] barPosB;

		private static readonly int[] barPosC;

		private static readonly int[] barPosD;

		private static readonly int[] barPosE;

		private static readonly int[] barPosF;

		private static readonly int[] barPosG;

		private static readonly int[] barPosH;

		private static readonly int[] barPosI;

		private static readonly int[] barPosJ;

		private static readonly int[][] barPos;

		private static readonly char[] barTypeA;

		private static readonly char[] barTypeB;

		private static readonly char[] barTypeC;

		private static readonly char[] barTypeD;

		private static readonly char[] barTypeE;

		private static readonly char[] barTypeF;

		private static readonly char[] barTypeG;

		private static readonly char[] barTypeH;

		private static readonly char[] barTypeI;

		private static readonly char[] barTypeJ;

		private static readonly char[][] barType;

		private const int A = 0;

		private const int B = 1;

		private const int C = 2;

		private const int D = 3;

		private const int E = 4;

		private const int F = 5;

		private const int G = 6;

		private const int H = 7;

		private const int I = 8;

		private const int J = 9;

		private static readonly IDictionary<int, int> table1Check;

		private static readonly IDictionary<int, int> table2Check;

		private BinaryBitmap currentBitmap;

		static IMBReader()
		{
			barPosA = new int[13]
			{
				2, 6, 13, 16, 21, 30, 34, 40, 45, 48,
				52, 56, 62
			};
			barPosB = new int[13]
			{
				22, 18, 39, 41, 11, 57, 54, 50, 7, 32,
				2, 62, 26
			};
			barPosC = new int[13]
			{
				40, 35, 57, 52, 49, 7, 24, 17, 3, 63,
				29, 44, 12
			};
			barPosD = new int[13]
			{
				47, 5, 35, 39, 30, 42, 15, 60, 20, 10,
				65, 54, 23
			};
			barPosE = new int[13]
			{
				20, 41, 46, 1, 8, 51, 29, 61, 34, 15,
				25, 37, 58
			};
			barPosF = new int[13]
			{
				51, 25, 19, 64, 56, 4, 44, 31, 28, 36,
				47, 11, 6
			};
			barPosG = new int[13]
			{
				33, 37, 21, 9, 17, 49, 59, 14, 64, 26,
				42, 4, 53
			};
			barPosH = new int[13]
			{
				60, 14, 1, 27, 38, 61, 10, 24, 50, 55,
				19, 32, 45
			};
			barPosI = new int[13]
			{
				27, 46, 65, 59, 31, 12, 16, 43, 55, 5,
				9, 22, 36
			};
			barPosJ = new int[13]
			{
				63, 58, 53, 48, 43, 38, 33, 28, 23, 18,
				13, 8, 3
			};
			barPos = new int[10][] { barPosA, barPosB, barPosC, barPosD, barPosE, barPosF, barPosG, barPosH, barPosI, barPosJ };
			barTypeA = new char[13]
			{
				'A', 'D', 'A', 'D', 'A', 'A', 'D', 'D', 'D', 'A',
				'A', 'A', 'D'
			};
			barTypeB = new char[13]
			{
				'A', 'D', 'A', 'D', 'A', 'D', 'A', 'A', 'A', 'A',
				'D', 'A', 'D'
			};
			barTypeC = new char[13]
			{
				'A', 'D', 'A', 'D', 'A', 'D', 'D', 'A', 'A', 'D',
				'A', 'D', 'A'
			};
			barTypeD = new char[13]
			{
				'A', 'A', 'A', 'D', 'D', 'A', 'D', 'A', 'A', 'D',
				'D', 'D', 'A'
			};
			barTypeE = new char[13]
			{
				'D', 'A', 'D', 'A', 'D', 'A', 'D', 'D', 'A', 'A',
				'A', 'D', 'A'
			};
			barTypeF = new char[13]
			{
				'D', 'D', 'A', 'A', 'D', 'D', 'A', 'A', 'D', 'D',
				'D', 'D', 'A'
			};
			barTypeG = new char[13]
			{
				'D', 'A', 'D', 'D', 'D', 'D', 'A', 'A', 'D', 'A',
				'D', 'A', 'D'
			};
			barTypeH = new char[13]
			{
				'D', 'D', 'D', 'D', 'A', 'A', 'A', 'A', 'D', 'A',
				'D', 'D', 'A'
			};
			barTypeI = new char[13]
			{
				'A', 'A', 'A', 'D', 'D', 'D', 'A', 'D', 'D', 'D',
				'A', 'D', 'A'
			};
			barTypeJ = new char[13]
			{
				'A', 'D', 'A', 'D', 'A', 'D', 'A', 'A', 'D', 'A',
				'D', 'A', 'D'
			};
			barType = new char[10][] { barTypeA, barTypeB, barTypeC, barTypeD, barTypeE, barTypeF, barTypeG, barTypeH, barTypeI, barTypeJ };
			ushort[] array = new ushort[1287]
			{
				31, 7936, 47, 7808, 55, 7552, 59, 7040, 61, 6016,
				62, 3968, 79, 7744, 87, 7488, 91, 6976, 93, 5952,
				94, 3904, 103, 7360, 107, 6848, 109, 5824, 110, 3776,
				115, 6592, 117, 5568, 118, 3520, 121, 5056, 122, 3008,
				124, 1984, 143, 7712, 151, 7456, 155, 6944, 157, 5920,
				158, 3872, 167, 7328, 171, 6816, 173, 5792, 174, 3744,
				179, 6560, 181, 5536, 182, 3488, 185, 5024, 186, 2976,
				188, 1952, 199, 7264, 203, 6752, 205, 5728, 206, 3680,
				211, 6496, 213, 5472, 214, 3424, 217, 4960, 218, 2912,
				220, 1888, 227, 6368, 229, 5344, 230, 3296, 233, 4832,
				234, 2784, 236, 1760, 241, 4576, 242, 2528, 244, 1504,
				248, 992, 271, 7696, 279, 7440, 283, 6928, 285, 5904,
				286, 3856, 295, 7312, 299, 6800, 301, 5776, 302, 3728,
				307, 6544, 309, 5520, 310, 3472, 313, 5008, 314, 2960,
				316, 1936, 327, 7248, 331, 6736, 333, 5712, 334, 3664,
				339, 6480, 341, 5456, 342, 3408, 345, 4944, 346, 2896,
				348, 1872, 355, 6352, 357, 5328, 358, 3280, 361, 4816,
				362, 2768, 364, 1744, 369, 4560, 370, 2512, 372, 1488,
				376, 976, 391, 7216, 395, 6704, 397, 5680, 398, 3632,
				403, 6448, 405, 5424, 406, 3376, 409, 4912, 410, 2864,
				412, 1840, 419, 6320, 421, 5296, 422, 3248, 425, 4784,
				426, 2736, 428, 1712, 433, 4528, 434, 2480, 436, 1456,
				440, 944, 451, 6256, 453, 5232, 454, 3184, 457, 4720,
				458, 2672, 460, 1648, 465, 4464, 466, 2416, 468, 1392,
				472, 880, 481, 4336, 482, 2288, 484, 1264, 488, 752,
				527, 7688, 535, 7432, 539, 6920, 541, 5896, 542, 3848,
				551, 7304, 555, 6792, 557, 5768, 558, 3720, 563, 6536,
				565, 5512, 566, 3464, 569, 5000, 570, 2952, 572, 1928,
				583, 7240, 587, 6728, 589, 5704, 590, 3656, 595, 6472,
				597, 5448, 598, 3400, 601, 4936, 602, 2888, 604, 1864,
				611, 6344, 613, 5320, 614, 3272, 617, 4808, 618, 2760,
				620, 1736, 625, 4552, 626, 2504, 628, 1480, 632, 968,
				647, 7208, 651, 6696, 653, 5672, 654, 3624, 659, 6440,
				661, 5416, 662, 3368, 665, 4904, 666, 2856, 668, 1832,
				675, 6312, 677, 5288, 678, 3240, 681, 4776, 682, 2728,
				684, 1704, 689, 4520, 690, 2472, 692, 1448, 696, 936,
				707, 6248, 709, 5224, 710, 3176, 713, 4712, 714, 2664,
				716, 1640, 721, 4456, 722, 2408, 724, 1384, 728, 872,
				737, 4328, 738, 2280, 740, 1256, 775, 7192, 779, 6680,
				781, 5656, 782, 3608, 787, 6424, 789, 5400, 790, 3352,
				793, 4888, 794, 2840, 796, 1816, 803, 6296, 805, 5272,
				806, 3224, 809, 4760, 810, 2712, 812, 1688, 817, 4504,
				818, 2456, 820, 1432, 824, 920, 835, 6232, 837, 5208,
				838, 3160, 841, 4696, 842, 2648, 844, 1624, 849, 4440,
				850, 2392, 852, 1368, 865, 4312, 866, 2264, 868, 1240,
				899, 6200, 901, 5176, 902, 3128, 905, 4664, 906, 2616,
				908, 1592, 913, 4408, 914, 2360, 916, 1336, 929, 4280,
				930, 2232, 932, 1208, 961, 4216, 962, 2168, 964, 1144,
				1039, 7684, 1047, 7428, 1051, 6916, 1053, 5892, 1054, 3844,
				1063, 7300, 1067, 6788, 1069, 5764, 1070, 3716, 1075, 6532,
				1077, 5508, 1078, 3460, 1081, 4996, 1082, 2948, 1084, 1924,
				1095, 7236, 1099, 6724, 1101, 5700, 1102, 3652, 1107, 6468,
				1109, 5444, 1110, 3396, 1113, 4932, 1114, 2884, 1116, 1860,
				1123, 6340, 1125, 5316, 1126, 3268, 1129, 4804, 1130, 2756,
				1132, 1732, 1137, 4548, 1138, 2500, 1140, 1476, 1159, 7204,
				1163, 6692, 1165, 5668, 1166, 3620, 1171, 6436, 1173, 5412,
				1174, 3364, 1177, 4900, 1178, 2852, 1180, 1828, 1187, 6308,
				1189, 5284, 1190, 3236, 1193, 4772, 1194, 2724, 1196, 1700,
				1201, 4516, 1202, 2468, 1204, 1444, 1219, 6244, 1221, 5220,
				1222, 3172, 1225, 4708, 1226, 2660, 1228, 1636, 1233, 4452,
				1234, 2404, 1236, 1380, 1249, 4324, 1250, 2276, 1287, 7188,
				1291, 6676, 1293, 5652, 1294, 3604, 1299, 6420, 1301, 5396,
				1302, 3348, 1305, 4884, 1306, 2836, 1308, 1812, 1315, 6292,
				1317, 5268, 1318, 3220, 1321, 4756, 1322, 2708, 1324, 1684,
				1329, 4500, 1330, 2452, 1332, 1428, 1347, 6228, 1349, 5204,
				1350, 3156, 1353, 4692, 1354, 2644, 1356, 1620, 1361, 4436,
				1362, 2388, 1377, 4308, 1378, 2260, 1411, 6196, 1413, 5172,
				1414, 3124, 1417, 4660, 1418, 2612, 1420, 1588, 1425, 4404,
				1426, 2356, 1441, 4276, 1442, 2228, 1473, 4212, 1474, 2164,
				1543, 7180, 1547, 6668, 1549, 5644, 1550, 3596, 1555, 6412,
				1557, 5388, 1558, 3340, 1561, 4876, 1562, 2828, 1564, 1804,
				1571, 6284, 1573, 5260, 1574, 3212, 1577, 4748, 1578, 2700,
				1580, 1676, 1585, 4492, 1586, 2444, 1603, 6220, 1605, 5196,
				1606, 3148, 1609, 4684, 1610, 2636, 1617, 4428, 1618, 2380,
				1633, 4300, 1634, 2252, 1667, 6188, 1669, 5164, 1670, 3116,
				1673, 4652, 1674, 2604, 1681, 4396, 1682, 2348, 1697, 4268,
				1698, 2220, 1729, 4204, 1730, 2156, 1795, 6172, 1797, 5148,
				1798, 3100, 1801, 4636, 1802, 2588, 1809, 4380, 1810, 2332,
				1825, 4252, 1826, 2204, 1857, 4188, 1858, 2140, 1921, 4156,
				1922, 2108, 2063, 7682, 2071, 7426, 2075, 6914, 2077, 5890,
				2078, 3842, 2087, 7298, 2091, 6786, 2093, 5762, 2094, 3714,
				2099, 6530, 2101, 5506, 2102, 3458, 2105, 4994, 2106, 2946,
				2119, 7234, 2123, 6722, 2125, 5698, 2126, 3650, 2131, 6466,
				2133, 5442, 2134, 3394, 2137, 4930, 2138, 2882, 2147, 6338,
				2149, 5314, 2150, 3266, 2153, 4802, 2154, 2754, 2161, 4546,
				2162, 2498, 2183, 7202, 2187, 6690, 2189, 5666, 2190, 3618,
				2195, 6434, 2197, 5410, 2198, 3362, 2201, 4898, 2202, 2850,
				2211, 6306, 2213, 5282, 2214, 3234, 2217, 4770, 2218, 2722,
				2225, 4514, 2226, 2466, 2243, 6242, 2245, 5218, 2246, 3170,
				2249, 4706, 2250, 2658, 2257, 4450, 2258, 2402, 2273, 4322,
				2311, 7186, 2315, 6674, 2317, 5650, 2318, 3602, 2323, 6418,
				2325, 5394, 2326, 3346, 2329, 4882, 2330, 2834, 2339, 6290,
				2341, 5266, 2342, 3218, 2345, 4754, 2346, 2706, 2353, 4498,
				2354, 2450, 2371, 6226, 2373, 5202, 2374, 3154, 2377, 4690,
				2378, 2642, 2385, 4434, 2401, 4306, 2435, 6194, 2437, 5170,
				2438, 3122, 2441, 4658, 2442, 2610, 2449, 4402, 2465, 4274,
				2497, 4210, 2567, 7178, 2571, 6666, 2573, 5642, 2574, 3594,
				2579, 6410, 2581, 5386, 2582, 3338, 2585, 4874, 2586, 2826,
				2595, 6282, 2597, 5258, 2598, 3210, 2601, 4746, 2602, 2698,
				2609, 4490, 2627, 6218, 2629, 5194, 2630, 3146, 2633, 4682,
				2641, 4426, 2657, 4298, 2691, 6186, 2693, 5162, 2694, 3114,
				2697, 4650, 2705, 4394, 2721, 4266, 2753, 4202, 2819, 6170,
				2821, 5146, 2822, 3098, 2825, 4634, 2833, 4378, 2849, 4250,
				2881, 4186, 2945, 4154, 3079, 7174, 3083, 6662, 3085, 5638,
				3086, 3590, 3091, 6406, 3093, 5382, 3094, 3334, 3097, 4870,
				3107, 6278, 3109, 5254, 3110, 3206, 3113, 4742, 3121, 4486,
				3139, 6214, 3141, 5190, 3145, 4678, 3153, 4422, 3169, 4294,
				3203, 6182, 3205, 5158, 3209, 4646, 3217, 4390, 3233, 4262,
				3265, 4198, 3331, 6166, 3333, 5142, 3337, 4630, 3345, 4374,
				3361, 4246, 3393, 4182, 3457, 4150, 3587, 6158, 3589, 5134,
				3593, 4622, 3601, 4366, 3617, 4238, 3649, 4174, 3713, 4142,
				3841, 4126, 4111, 7681, 4119, 7425, 4123, 6913, 4125, 5889,
				4135, 7297, 4139, 6785, 4141, 5761, 4147, 6529, 4149, 5505,
				4153, 4993, 4167, 7233, 4171, 6721, 4173, 5697, 4179, 6465,
				4181, 5441, 4185, 4929, 4195, 6337, 4197, 5313, 4201, 4801,
				4209, 4545, 4231, 7201, 4235, 6689, 4237, 5665, 4243, 6433,
				4245, 5409, 4249, 4897, 4259, 6305, 4261, 5281, 4265, 4769,
				4273, 4513, 4291, 6241, 4293, 5217, 4297, 4705, 4305, 4449,
				4359, 7185, 4363, 6673, 4365, 5649, 4371, 6417, 4373, 5393,
				4377, 4881, 4387, 6289, 4389, 5265, 4393, 4753, 4401, 4497,
				4419, 6225, 4421, 5201, 4425, 4689, 4483, 6193, 4485, 5169,
				4489, 4657, 4615, 7177, 4619, 6665, 4621, 5641, 4627, 6409,
				4629, 5385, 4633, 4873, 4643, 6281, 4645, 5257, 4649, 4745,
				4675, 6217, 4677, 5193, 4739, 6185, 4741, 5161, 4867, 6169,
				4869, 5145, 5127, 7173, 5131, 6661, 5133, 5637, 5139, 6405,
				5141, 5381, 5155, 6277, 5157, 5253, 5187, 6213, 5251, 6181,
				5379, 6165, 5635, 6157, 6151, 7171, 6155, 6659, 6163, 6403,
				6179, 6275, 6211, 5189, 4681, 4433, 4321, 3142, 2634, 2386,
				2274, 1612, 1364, 1252, 856, 744, 496
			};
			ushort[] array2 = new ushort[78]
			{
				3, 6144, 5, 5120, 6, 3072, 9, 4608, 10, 2560,
				12, 1536, 17, 4352, 18, 2304, 20, 1280, 24, 768,
				33, 4224, 34, 2176, 36, 1152, 40, 640, 48, 384,
				65, 4160, 66, 2112, 68, 1088, 72, 576, 80, 320,
				96, 192, 129, 4128, 130, 2080, 132, 1056, 136, 544,
				144, 288, 257, 4112, 258, 2064, 260, 1040, 264, 528,
				513, 4104, 514, 2056, 516, 1032, 1025, 4100, 1026, 2052,
				2049, 4098, 4097, 2050, 1028, 520, 272, 160
			};
			table1Check = new Dictionary<int, int>(2000);
			table2Check = new Dictionary<int, int>(200);
			for (int i = 0; i < array.Length; i++)
			{
				table1Check.Add(array[i], i);
			}
			for (int j = 0; j < array2.Length; j++)
			{
				table2Check.Add(array2[j], j);
			}
		}

		protected override Result doDecode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			currentBitmap = image;
			return base.doDecode(image, hints);
		}

		public override void reset()
		{
			base.reset();
			currentBitmap = null;
		}

		private ushort binaryStringToDec(string binary)
		{
			ushort num = (ushort)Math.Pow(2.0, binary.Length - 1);
			ushort num2 = 0;
			for (int i = 0; i < binary.Length; i++)
			{
				if (binary[i] == '1')
				{
					num2 += num;
				}
				num /= 2;
			}
			return num2;
		}

		private string invertedBinaryString(string binary)
		{
			string text = "";
			for (int i = 0; i < binary.Length; i++)
			{
				text = ((binary[i] != '1') ? (text + "1") : (text + "0"));
			}
			return text;
		}

		private bool getCodeWords(out int[] codeWord, string imb, IDictionary<int, int> table1Check, IDictionary<int, int> table2Check, int[][] barPos, char[][] barType)
		{
			StringBuilder[] array = new StringBuilder[10];
			for (int i = 0; i < 10; i++)
			{
				array[i] = new StringBuilder("0000000000000");
			}
			for (int j = 0; j < 65; j++)
			{
				if (imb[j] != 'D' && imb[j] != 'A' && imb[j] != 'F')
				{
					continue;
				}
				int num = j + 1;
				for (int k = 0; k < 10; k++)
				{
					for (int l = 0; l < 13; l++)
					{
						if (barPos[k][l] == num && (barType[k][l] == imb[j] || imb[j] == 'F'))
						{
							array[k][12 - l] = '1';
						}
					}
				}
			}
			ushort[] array2 = new ushort[10];
			for (int m = 0; m < 10; m++)
			{
				array2[m] = binaryStringToDec(array[m].ToString());
			}
			for (int n = 0; n < array2.Length; n++)
			{
				if (!table1Check.ContainsKey(array2[n]) && !table2Check.ContainsKey(array2[n]))
				{
					array[n].Replace(array[n].ToString(), invertedBinaryString(array[n].ToString()));
					array2[n] = binaryStringToDec(array[n].ToString());
				}
			}
			codeWord = new int[10];
			for (int num2 = 0; num2 < 10; num2++)
			{
				if (!table1Check.ContainsKey(array2[num2]))
				{
					if (!table2Check.ContainsKey(array2[num2]))
					{
						return false;
					}
					codeWord[num2] = table2Check[array2[num2]] + 1287;
				}
				else
				{
					codeWord[num2] = table1Check[array2[num2]];
				}
			}
			return true;
		}

		private string getTrackingNumber(string imb)
		{
			if (!getCodeWords(out var codeWord, imb, table1Check, table2Check, barPos, barType))
			{
				StringBuilder stringBuilder = new StringBuilder(imb.Length);
				for (int num = imb.Length - 1; num >= 0; num--)
				{
					if (imb[num] == 'A')
					{
						stringBuilder.Append('D');
					}
					else if (imb[num] == 'D')
					{
						stringBuilder.Append('A');
					}
					else
					{
						stringBuilder.Append(imb[num]);
					}
				}
				if (!getCodeWords(out codeWord, stringBuilder.ToString(), table1Check, table2Check, barPos, barType))
				{
					return null;
				}
			}
			if (codeWord[0] > 658)
			{
				codeWord[0] -= 659;
			}
			codeWord[9] /= 2;
			BigInteger bigInteger = codeWord[0];
			for (int i = 1; i <= 8; i++)
			{
				bigInteger = bigInteger * 1365 + codeWord[i];
			}
			bigInteger = bigInteger * 636 + codeWord[9];
			int[] array = new int[20];
			for (int num2 = 19; num2 >= 2; num2--)
			{
				array[num2] = (int)(bigInteger % 10);
				bigInteger /= (BigInteger)10;
			}
			array[1] = (int)(bigInteger % 5);
			bigInteger /= (BigInteger)5;
			array[0] = (int)(bigInteger % 10);
			bigInteger /= (BigInteger)10;
			string text = "";
			int[] array2 = array;
			foreach (int num3 in array2)
			{
				text += num3;
			}
			if (bigInteger > 1000000000)
			{
				text += ((ulong)(bigInteger - 1000000000 - 100000 - 1)).ToString().PadLeft(11, '0');
			}
			else if (bigInteger > 100000)
			{
				text += ((ulong)(bigInteger - 100000 - 1)).ToString().PadLeft(9, '0');
			}
			else if (bigInteger > 0)
			{
				text += ((ulong)(bigInteger - 1)).ToString().PadLeft(5, '0');
			}
			return text;
		}

		private void fillLists(ZXing.Common.BitArray row, ZXing.Common.BitArray topRow, ZXing.Common.BitArray botRow, ref List<int> listRow, ref List<int> listTop, ref List<int> listBot, int start, int stop)
		{
			bool flag = false;
			for (int i = start; i <= stop; i++)
			{
				if (row[i])
				{
					if (!flag)
					{
						flag = true;
						listRow.Add(1);
						if (topRow[i])
						{
							listTop.Add(1);
						}
						else
						{
							listTop.Add(0);
						}
						if (botRow[i])
						{
							listBot.Add(1);
						}
						else
						{
							listBot.Add(0);
						}
					}
					continue;
				}
				if (flag)
				{
					listRow.Add(0);
					if (topRow[i])
					{
						listTop.Add(1);
					}
					else
					{
						listTop.Add(0);
					}
					if (botRow[i])
					{
						listBot.Add(1);
					}
					else
					{
						listBot.Add(0);
					}
				}
				flag = false;
			}
		}

		private int isIMB(ZXing.Common.BitArray row, ref int pixelStartOffset, ref int pixelStopOffset, ref int pixelBarLength)
		{
			int size = row.Size;
			int num = (pixelStartOffset = row.getNextSet(0));
			int num2 = pixelStartOffset;
			int num3 = 0;
			bool flag = false;
			int num4 = 0;
			int num5 = 0;
			bool flag2 = false;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			for (int i = num; i < size; i++)
			{
				if (row[i])
				{
					flag2 = false;
					if (!flag)
					{
						if (num3 <= 1)
						{
							num8 = num7;
						}
						else if (num8 != num7)
						{
							num6 = 1;
							num8 = num7;
							num3 = 1;
							pixelStartOffset = num2;
						}
						num3++;
						flag = true;
						num2 = i;
					}
					num7 = 0;
					num4++;
					continue;
				}
				flag = false;
				if (!flag2)
				{
					num6++;
					flag2 = true;
					if (num3 <= 1)
					{
						num5 = num4;
					}
					else if (num5 != num4)
					{
						num3 = 1;
						num6 = 1;
						num8 = 0;
						pixelStartOffset = num2;
						num5 = num4;
					}
					else if (num3 == 65)
					{
						pixelStopOffset = i;
						break;
					}
					num4 = 0;
				}
				num7++;
			}
			pixelBarLength = num5;
			return num3;
		}

		private int getNumberBars(ZXing.Common.BitArray row, int start, int stop, int barWidth)
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			for (int i = start; i <= stop; i++)
			{
				if (row[i])
				{
					if (!flag)
					{
						flag = true;
					}
					num2++;
					if (i == stop && num2 == barWidth)
					{
						num++;
					}
				}
				else
				{
					if (flag && num2 == barWidth)
					{
						num++;
					}
					flag = false;
					num2 = 0;
				}
			}
			return num;
		}

		public override Result decodeRow(int rowNumber, ZXing.Common.BitArray row, IDictionary<DecodeHintType, object> hints)
		{
			if (currentBitmap == null)
			{
				return null;
			}
			int pixelStartOffset = 0;
			int pixelStopOffset = currentBitmap.Width - 1;
			int pixelBarLength = 0;
			if (isIMB(row, ref pixelStartOffset, ref pixelStopOffset, ref pixelBarLength) != 65)
			{
				return null;
			}
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray(currentBitmap.Width);
			ZXing.Common.BitArray bitArray2 = new ZXing.Common.BitArray(currentBitmap.Width);
			int num = rowNumber;
			int num2 = rowNumber;
			do
			{
				if (num <= 0)
				{
					return null;
				}
				num--;
				bitArray = currentBitmap.getBlackRow(num, bitArray);
			}
			while (getNumberBars(bitArray, pixelStartOffset, pixelStopOffset, pixelBarLength) >= 65);
			do
			{
				if (num2 >= currentBitmap.Height - 1)
				{
					return null;
				}
				num2++;
				bitArray2 = currentBitmap.getBlackRow(num2, bitArray2);
			}
			while (getNumberBars(bitArray2, pixelStartOffset, pixelStopOffset, pixelBarLength) >= 65);
			List<int> listRow = new List<int>();
			List<int> listTop = new List<int>();
			List<int> listBot = new List<int>();
			fillLists(row, bitArray, bitArray2, ref listRow, ref listTop, ref listBot, pixelStartOffset, pixelStopOffset);
			string text = "";
			for (int i = 0; i < listRow.Count; i++)
			{
				if (listRow[i] != 0)
				{
					text = ((listBot[i] == 1 && listTop[i] == 1) ? (text + "F") : ((listBot[i] != 1) ? ((listTop[i] != 1) ? (text + "T") : (text + "A")) : (text + "D")));
				}
			}
			string trackingNumber = getTrackingNumber(text);
			if (trackingNumber == null)
			{
				return null;
			}
			ResultPointCallback resultPointCallback = ((hints == null || !hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK)) ? null : ((ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK]));
			if (resultPointCallback != null)
			{
				resultPointCallback(new ResultPoint(pixelStartOffset, rowNumber));
				resultPointCallback(new ResultPoint(pixelStopOffset, rowNumber));
			}
			return new Result(trackingNumber, null, new ResultPoint[2]
			{
				new ResultPoint(pixelStartOffset, rowNumber),
				new ResultPoint(pixelStopOffset, rowNumber)
			}, BarcodeFormat.IMB);
		}
	}
}
namespace ZXing.Datamatrix
{
	public sealed class DataMatrixReader : Reader
	{
		private static readonly ResultPoint[] NO_POINTS = new ResultPoint[0];

		private readonly ZXing.Datamatrix.Internal.Decoder decoder = new ZXing.Datamatrix.Internal.Decoder();

		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			DecoderResult decoderResult;
			ResultPoint[] resultPoints;
			if (hints != null && hints.ContainsKey(DecodeHintType.PURE_BARCODE))
			{
				BitMatrix bitMatrix = extractPureBits(image.BlackMatrix);
				if (bitMatrix == null)
				{
					return null;
				}
				decoderResult = decoder.decode(bitMatrix);
				resultPoints = NO_POINTS;
			}
			else
			{
				DetectorResult detectorResult = new ZXing.Datamatrix.Internal.Detector(image.BlackMatrix).detect();
				if (detectorResult == null)
				{
					return null;
				}
				decoderResult = decoder.decode(detectorResult.Bits);
				resultPoints = detectorResult.Points;
			}
			if (decoderResult == null)
			{
				return null;
			}
			Result result = new Result(decoderResult.Text, decoderResult.RawBytes, resultPoints, BarcodeFormat.DATA_MATRIX);
			IList<byte[]> byteSegments = decoderResult.ByteSegments;
			if (byteSegments != null)
			{
				result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, byteSegments);
			}
			string eCLevel = decoderResult.ECLevel;
			if (eCLevel != null)
			{
				result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, eCLevel);
			}
			return result;
		}

		public void reset()
		{
		}

		private static BitMatrix extractPureBits(BitMatrix image)
		{
			int[] topLeftOnBit = image.getTopLeftOnBit();
			int[] bottomRightOnBit = image.getBottomRightOnBit();
			if (topLeftOnBit == null || bottomRightOnBit == null)
			{
				return null;
			}
			if (!moduleSize(topLeftOnBit, image, out var modulesize))
			{
				return null;
			}
			int num = topLeftOnBit[1];
			int num2 = bottomRightOnBit[1];
			int num3 = topLeftOnBit[0];
			int num4 = (bottomRightOnBit[0] - num3 + 1) / modulesize;
			int num5 = (num2 - num + 1) / modulesize;
			if (num4 <= 0 || num5 <= 0)
			{
				return null;
			}
			int num6 = modulesize >> 1;
			num += num6;
			num3 += num6;
			BitMatrix bitMatrix = new BitMatrix(num4, num5);
			for (int i = 0; i < num5; i++)
			{
				int y = num + i * modulesize;
				for (int j = 0; j < num4; j++)
				{
					if (image[num3 + j * modulesize, y])
					{
						bitMatrix[j, i] = true;
					}
				}
			}
			return bitMatrix;
		}

		private static bool moduleSize(int[] leftTopBlack, BitMatrix image, out int modulesize)
		{
			int width = image.Width;
			int i = leftTopBlack[0];
			for (int y = leftTopBlack[1]; i < width && image[i, y]; i++)
			{
			}
			if (i == width)
			{
				modulesize = 0;
				return false;
			}
			modulesize = i - leftTopBlack[0];
			if (modulesize == 0)
			{
				return false;
			}
			return true;
		}
	}
	public sealed class DataMatrixWriter : Writer
	{
		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			if (string.IsNullOrEmpty(contents))
			{
				throw new ArgumentException("Found empty contents", contents);
			}
			if (format != BarcodeFormat.DATA_MATRIX)
			{
				throw new ArgumentException("Can only encode DATA_MATRIX, but got " + format);
			}
			if (width < 0 || height < 0)
			{
				throw new ArgumentException("Requested dimensions can't be negative: " + width + "x" + height);
			}
			SymbolShapeHint shape = SymbolShapeHint.FORCE_NONE;
			int defaultEncodation = 0;
			Dimension minSize = null;
			Dimension maxSize = null;
			if (hints != null)
			{
				if (hints.ContainsKey(EncodeHintType.DATA_MATRIX_SHAPE))
				{
					object obj = hints[EncodeHintType.DATA_MATRIX_SHAPE];
					if (obj is SymbolShapeHint)
					{
						shape = (SymbolShapeHint)obj;
					}
					else if (Enum.IsDefined(typeof(SymbolShapeHint), obj.ToString()))
					{
						shape = (SymbolShapeHint)Enum.Parse(typeof(SymbolShapeHint), obj.ToString(), ignoreCase: true);
					}
				}
				Dimension dimension = (hints.ContainsKey(EncodeHintType.MIN_SIZE) ? (hints[EncodeHintType.MIN_SIZE] as Dimension) : null);
				if (dimension != null)
				{
					minSize = dimension;
				}
				Dimension dimension2 = (hints.ContainsKey(EncodeHintType.MAX_SIZE) ? (hints[EncodeHintType.MAX_SIZE] as Dimension) : null);
				if (dimension2 != null)
				{
					maxSize = dimension2;
				}
				if (hints.ContainsKey(EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION))
				{
					object obj2 = hints[EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION];
					if (obj2 != null)
					{
						defaultEncodation = Convert.ToInt32(obj2.ToString());
					}
				}
			}
			string text = ZXing.Datamatrix.Encoder.HighLevelEncoder.encodeHighLevel(contents, shape, minSize, maxSize, defaultEncodation);
			SymbolInfo symbolInfo = SymbolInfo.lookup(text.Length, shape, minSize, maxSize, fail: true);
			DefaultPlacement defaultPlacement = new DefaultPlacement(ZXing.Datamatrix.Encoder.ErrorCorrection.encodeECC200(text, symbolInfo), symbolInfo.getSymbolDataWidth(), symbolInfo.getSymbolDataHeight());
			defaultPlacement.place();
			return encodeLowLevel(defaultPlacement, symbolInfo, width, height);
		}

		private static BitMatrix encodeLowLevel(DefaultPlacement placement, SymbolInfo symbolInfo, int width, int height)
		{
			int symbolDataWidth = symbolInfo.getSymbolDataWidth();
			int symbolDataHeight = symbolInfo.getSymbolDataHeight();
			ByteMatrix byteMatrix = new ByteMatrix(symbolInfo.getSymbolWidth(), symbolInfo.getSymbolHeight());
			int num = 0;
			for (int i = 0; i < symbolDataHeight; i++)
			{
				int num2;
				if (i % symbolInfo.matrixHeight == 0)
				{
					num2 = 0;
					for (int j = 0; j < symbolInfo.getSymbolWidth(); j++)
					{
						byteMatrix.set(num2, num, j % 2 == 0);
						num2++;
					}
					num++;
				}
				num2 = 0;
				for (int k = 0; k < symbolDataWidth; k++)
				{
					if (k % symbolInfo.matrixWidth == 0)
					{
						byteMatrix.set(num2, num, value: true);
						num2++;
					}
					byteMatrix.set(num2, num, placement.getBit(k, i));
					num2++;
					if (k % symbolInfo.matrixWidth == symbolInfo.matrixWidth - 1)
					{
						byteMatrix.set(num2, num, i % 2 == 0);
						num2++;
					}
				}
				num++;
				if (i % symbolInfo.matrixHeight == symbolInfo.matrixHeight - 1)
				{
					num2 = 0;
					for (int l = 0; l < symbolInfo.getSymbolWidth(); l++)
					{
						byteMatrix.set(num2, num, value: true);
						num2++;
					}
					num++;
				}
			}
			return convertByteMatrixToBitMatrix(byteMatrix, width, height);
		}

		private static BitMatrix convertByteMatrixToBitMatrix(ByteMatrix matrix, int reqWidth, int reqHeight)
		{
			int width = matrix.Width;
			int height = matrix.Height;
			int num = Math.Max(reqWidth, width);
			int num2 = Math.Max(reqHeight, height);
			int num3 = Math.Min(num / width, num2 / height);
			int num4 = (num - width * num3) / 2;
			int num5 = (num2 - height * num3) / 2;
			BitMatrix bitMatrix;
			if (reqHeight < height || reqWidth < width)
			{
				num4 = 0;
				num5 = 0;
				bitMatrix = new BitMatrix(width, height);
			}
			else
			{
				bitMatrix = new BitMatrix(reqWidth, reqHeight);
			}
			bitMatrix.clear();
			int num6 = 0;
			int num7 = num5;
			while (num6 < height)
			{
				int num8 = 0;
				int num9 = num4;
				while (num8 < width)
				{
					if (matrix[num8, num6] == 1)
					{
						bitMatrix.setRegion(num9, num7, num3, num3);
					}
					num8++;
					num9 += num3;
				}
				num6++;
				num7 += num3;
			}
			return bitMatrix;
		}
	}
	[Serializable]
	public class DatamatrixEncodingOptions : EncodingOptions
	{
		public SymbolShapeHint? SymbolShape
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.DATA_MATRIX_SHAPE))
				{
					return (SymbolShapeHint)base.Hints[EncodeHintType.DATA_MATRIX_SHAPE];
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					if (base.Hints.ContainsKey(EncodeHintType.DATA_MATRIX_SHAPE))
					{
						base.Hints.Remove(EncodeHintType.DATA_MATRIX_SHAPE);
					}
				}
				else
				{
					base.Hints[EncodeHintType.DATA_MATRIX_SHAPE] = value;
				}
			}
		}

		public Dimension MinSize
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.MIN_SIZE))
				{
					return (Dimension)base.Hints[EncodeHintType.MIN_SIZE];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					if (base.Hints.ContainsKey(EncodeHintType.MIN_SIZE))
					{
						base.Hints.Remove(EncodeHintType.MIN_SIZE);
					}
				}
				else
				{
					base.Hints[EncodeHintType.MIN_SIZE] = value;
				}
			}
		}

		public Dimension MaxSize
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.MAX_SIZE))
				{
					return (Dimension)base.Hints[EncodeHintType.MAX_SIZE];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					if (base.Hints.ContainsKey(EncodeHintType.MAX_SIZE))
					{
						base.Hints.Remove(EncodeHintType.MAX_SIZE);
					}
				}
				else
				{
					base.Hints[EncodeHintType.MAX_SIZE] = value;
				}
			}
		}

		public int? DefaultEncodation
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION))
				{
					return (int)base.Hints[EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION];
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					if (base.Hints.ContainsKey(EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION))
					{
						base.Hints.Remove(EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION);
					}
				}
				else
				{
					base.Hints[EncodeHintType.DATA_MATRIX_DEFAULT_ENCODATION] = value;
				}
			}
		}
	}
}
namespace ZXing.Datamatrix.Encoder
{
	internal sealed class ASCIIEncoder : Encoder
	{
		public int EncodingMode => 0;

		public void encode(EncoderContext context)
		{
			if (HighLevelEncoder.determineConsecutiveDigitCount(context.Message, context.Pos) >= 2)
			{
				context.writeCodeword(encodeASCIIDigits(context.Message[context.Pos], context.Message[context.Pos + 1]));
				context.Pos += 2;
				return;
			}
			char currentChar = context.CurrentChar;
			int num = HighLevelEncoder.lookAheadTest(context.Message, context.Pos, EncodingMode);
			if (num != EncodingMode)
			{
				switch (num)
				{
				case 5:
					context.writeCodeword('ç');
					context.signalEncoderChange(5);
					break;
				case 1:
					context.writeCodeword('æ');
					context.signalEncoderChange(1);
					break;
				case 3:
					context.writeCodeword('î');
					context.signalEncoderChange(3);
					break;
				case 2:
					context.writeCodeword('ï');
					context.signalEncoderChange(2);
					break;
				case 4:
					context.writeCodeword('ð');
					context.signalEncoderChange(4);
					break;
				default:
					throw new InvalidOperationException("Illegal mode: " + num);
				}
			}
			else if (HighLevelEncoder.isExtendedASCII(currentChar))
			{
				context.writeCodeword('ë');
				context.writeCodeword((char)(currentChar - 128 + 1));
				context.Pos++;
			}
			else
			{
				if (currentChar == '\u001d' && !context.Fnc1CodewordIsWritten)
				{
					context.writeCodeword('è');
					context.Fnc1CodewordIsWritten = true;
				}
				else
				{
					context.writeCodeword((char)(currentChar + 1));
				}
				context.Pos++;
			}
		}

		private static char encodeASCIIDigits(char digit1, char digit2)
		{
			if (HighLevelEncoder.isDigit(digit1) && HighLevelEncoder.isDigit(digit2))
			{
				return (char)((digit1 - 48) * 10 + (digit2 - 48) + 130);
			}
			throw new ArgumentException("not digits: " + digit1 + digit2);
		}
	}
	internal sealed class Base256Encoder : Encoder
	{
		public int EncodingMode => 5;

		public void encode(EncoderContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('\0');
			while (context.HasMoreCharacters)
			{
				char currentChar = context.CurrentChar;
				stringBuilder.Append(currentChar);
				context.Pos++;
				if (HighLevelEncoder.lookAheadTest(context.Message, context.Pos, EncodingMode) != EncodingMode)
				{
					context.signalEncoderChange(0);
					break;
				}
			}
			int num = stringBuilder.Length - 1;
			int num2 = context.CodewordCount + num + 1;
			context.updateSymbolInfo(num2);
			bool flag = context.SymbolInfo.dataCapacity - num2 > 0;
			if (context.HasMoreCharacters || flag)
			{
				if (num <= 249)
				{
					stringBuilder[0] = (char)num;
				}
				else
				{
					if (num > 1555)
					{
						throw new InvalidOperationException("Message length not in valid ranges: " + num);
					}
					stringBuilder[0] = (char)(num / 250 + 249);
					stringBuilder.Insert(1, new char[1] { (char)(num % 250) });
				}
			}
			int length = stringBuilder.Length;
			for (int i = 0; i < length; i++)
			{
				context.writeCodeword(randomize255State(stringBuilder[i], context.CodewordCount + 1));
			}
		}

		private static char randomize255State(char ch, int codewordPosition)
		{
			int num = 149 * codewordPosition % 255 + 1;
			int num2 = ch + num;
			if (num2 <= 255)
			{
				return (char)num2;
			}
			return (char)(num2 - 256);
		}
	}
	internal class C40Encoder : Encoder
	{
		public virtual int EncodingMode => 1;

		public virtual void encode(EncoderContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (context.HasMoreCharacters)
			{
				char currentChar = context.CurrentChar;
				context.Pos++;
				int num = encodeChar(currentChar, stringBuilder);
				int num2 = stringBuilder.Length / 3 * 2;
				int num3 = context.CodewordCount + num2;
				context.updateSymbolInfo(num3);
				int num4 = context.SymbolInfo.dataCapacity - num3;
				if (!context.HasMoreCharacters)
				{
					StringBuilder removed = new StringBuilder();
					if (stringBuilder.Length % 3 == 2 && (num4 < 2 || num4 > 2))
					{
						num = backtrackOneCharacter(context, stringBuilder, removed, num);
					}
					while (stringBuilder.Length % 3 == 1 && ((num <= 3 && num4 != 1) || num > 3))
					{
						num = backtrackOneCharacter(context, stringBuilder, removed, num);
					}
					break;
				}
				if (stringBuilder.Length % 3 == 0 && HighLevelEncoder.lookAheadTest(context.Message, context.Pos, EncodingMode) != EncodingMode)
				{
					context.signalEncoderChange(0);
					break;
				}
			}
			handleEOD(context, stringBuilder);
		}

		private int backtrackOneCharacter(EncoderContext context, StringBuilder buffer, StringBuilder removed, int lastCharSize)
		{
			int length = buffer.Length;
			buffer.Remove(length - lastCharSize, lastCharSize);
			context.Pos--;
			char currentChar = context.CurrentChar;
			lastCharSize = encodeChar(currentChar, removed);
			context.resetSymbolInfo();
			return lastCharSize;
		}

		internal static void writeNextTriplet(EncoderContext context, StringBuilder buffer)
		{
			context.writeCodewords(encodeToCodewords(buffer, 0));
			buffer.Remove(0, 3);
		}

		protected virtual void handleEOD(EncoderContext context, StringBuilder buffer)
		{
			int num = buffer.Length / 3 * 2;
			int num2 = buffer.Length % 3;
			int num3 = context.CodewordCount + num;
			context.updateSymbolInfo(num3);
			int num4 = context.SymbolInfo.dataCapacity - num3;
			if (num2 == 2)
			{
				buffer.Append('\0');
				while (buffer.Length >= 3)
				{
					writeNextTriplet(context, buffer);
				}
				if (context.HasMoreCharacters)
				{
					context.writeCodeword('þ');
				}
			}
			else if (num4 == 1 && num2 == 1)
			{
				while (buffer.Length >= 3)
				{
					writeNextTriplet(context, buffer);
				}
				if (context.HasMoreCharacters)
				{
					context.writeCodeword('þ');
				}
				context.Pos--;
			}
			else
			{
				if (num2 != 0)
				{
					throw new InvalidOperationException("Unexpected case. Please report!");
				}
				while (buffer.Length >= 3)
				{
					writeNextTriplet(context, buffer);
				}
				if (num4 > 0 || context.HasMoreCharacters)
				{
					context.writeCodeword('þ');
				}
			}
			context.signalEncoderChange(0);
		}

		protected virtual int encodeChar(char c, StringBuilder sb)
		{
			switch (c)
			{
			case ' ':
				sb.Append('\u0003');
				return 1;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				sb.Append((char)(c - 48 + 4));
				return 1;
			default:
				if (c >= 'A' && c <= 'Z')
				{
					sb.Append((char)(c - 65 + 14));
					return 1;
				}
				if (c >= '\0' && c <= '\u001f')
				{
					sb.Append('\0');
					sb.Append(c);
					return 2;
				}
				if (c >= '!' && c <= '/')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 33));
					return 2;
				}
				if (c >= ':' && c <= '@')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 58 + 15));
					return 2;
				}
				if (c >= '[' && c <= '_')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 91 + 22));
					return 2;
				}
				if (c >= '`' && c <= '\u007f')
				{
					sb.Append('\u0002');
					sb.Append((char)(c - 96));
					return 2;
				}
				if (c >= '\u0080')
				{
					sb.Append("\u0001\u001e");
					return 2 + encodeChar((char)(c - 128), sb);
				}
				throw new InvalidOperationException("Illegal character: " + c);
			}
		}

		private static string encodeToCodewords(StringBuilder sb, int startPos)
		{
			char c = sb[startPos];
			char c2 = sb[startPos + 1];
			char c3 = sb[startPos + 2];
			int num = 1600 * c + 40 * c2 + c3 + 1;
			char c4 = (char)(num / 256);
			char c5 = (char)(num % 256);
			return new string(new char[2] { c4, c5 });
		}
	}
	internal sealed class DataMatrixSymbolInfo144 : SymbolInfo
	{
		public DataMatrixSymbolInfo144()
			: base(rectangular: false, 1558, 620, 22, 22, 36, -1, 62)
		{
		}

		public override int getInterleavedBlockCount()
		{
			return 10;
		}

		public override int getDataLengthForInterleavedBlock(int index)
		{
			if (index > 8)
			{
				return 155;
			}
			return 156;
		}
	}
	public class DefaultPlacement
	{
		private readonly string codewords;

		private readonly int numrows;

		private readonly int numcols;

		private readonly byte[] bits;

		public int Numrows => numrows;

		public int Numcols => numcols;

		public byte[] Bits => bits;

		public DefaultPlacement(string codewords, int numcols, int numrows)
		{
			this.codewords = codewords;
			this.numcols = numcols;
			this.numrows = numrows;
			bits = new byte[numcols * numrows];
			SupportClass.Fill(bits, (byte)2);
		}

		public bool getBit(int col, int row)
		{
			return bits[row * numcols + col] == 1;
		}

		private void setBit(int col, int row, bool bit)
		{
			bits[row * numcols + col] = (byte)(bit ? 1u : 0u);
		}

		private bool hasBit(int col, int row)
		{
			return bits[row * numcols + col] < 2;
		}

		public void place()
		{
			int num = 0;
			int num2 = 4;
			int num3 = 0;
			do
			{
				if (num2 == numrows && num3 == 0)
				{
					corner1(num++);
				}
				if (num2 == numrows - 2 && num3 == 0 && numcols % 4 != 0)
				{
					corner2(num++);
				}
				if (num2 == numrows - 2 && num3 == 0 && numcols % 8 == 4)
				{
					corner3(num++);
				}
				if (num2 == numrows + 4 && num3 == 2 && numcols % 8 == 0)
				{
					corner4(num++);
				}
				do
				{
					if (num2 < numrows && num3 >= 0 && !hasBit(num3, num2))
					{
						utah(num2, num3, num++);
					}
					num2 -= 2;
					num3 += 2;
				}
				while (num2 >= 0 && num3 < numcols);
				num2++;
				num3 += 3;
				do
				{
					if (num2 >= 0 && num3 < numcols && !hasBit(num3, num2))
					{
						utah(num2, num3, num++);
					}
					num2 += 2;
					num3 -= 2;
				}
				while (num2 < numrows && num3 >= 0);
				num2 += 3;
				num3++;
			}
			while (num2 < numrows || num3 < numcols);
			if (!hasBit(numcols - 1, numrows - 1))
			{
				setBit(numcols - 1, numrows - 1, bit: true);
				setBit(numcols - 2, numrows - 2, bit: true);
			}
		}

		private void module(int row, int col, int pos, int bit)
		{
			if (row < 0)
			{
				row += numrows;
				col += 4 - (numrows + 4) % 8;
			}
			if (col < 0)
			{
				col += numcols;
				row += 4 - (numcols + 4) % 8;
			}
			int num = codewords[pos];
			num &= 1 << 8 - bit;
			setBit(col, row, num != 0);
		}

		private void utah(int row, int col, int pos)
		{
			module(row - 2, col - 2, pos, 1);
			module(row - 2, col - 1, pos, 2);
			module(row - 1, col - 2, pos, 3);
			module(row - 1, col - 1, pos, 4);
			module(row - 1, col, pos, 5);
			module(row, col - 2, pos, 6);
			module(row, col - 1, pos, 7);
			module(row, col, pos, 8);
		}

		private void corner1(int pos)
		{
			module(numrows - 1, 0, pos, 1);
			module(numrows - 1, 1, pos, 2);
			module(numrows - 1, 2, pos, 3);
			module(0, numcols - 2, pos, 4);
			module(0, numcols - 1, pos, 5);
			module(1, numcols - 1, pos, 6);
			module(2, numcols - 1, pos, 7);
			module(3, numcols - 1, pos, 8);
		}

		private void corner2(int pos)
		{
			module(numrows - 3, 0, pos, 1);
			module(numrows - 2, 0, pos, 2);
			module(numrows - 1, 0, pos, 3);
			module(0, numcols - 4, pos, 4);
			module(0, numcols - 3, pos, 5);
			module(0, numcols - 2, pos, 6);
			module(0, numcols - 1, pos, 7);
			module(1, numcols - 1, pos, 8);
		}

		private void corner3(int pos)
		{
			module(numrows - 3, 0, pos, 1);
			module(numrows - 2, 0, pos, 2);
			module(numrows - 1, 0, pos, 3);
			module(0, numcols - 2, pos, 4);
			module(0, numcols - 1, pos, 5);
			module(1, numcols - 1, pos, 6);
			module(2, numcols - 1, pos, 7);
			module(3, numcols - 1, pos, 8);
		}

		private void corner4(int pos)
		{
			module(numrows - 1, 0, pos, 1);
			module(numrows - 1, numcols - 1, pos, 2);
			module(0, numcols - 3, pos, 3);
			module(0, numcols - 2, pos, 4);
			module(0, numcols - 1, pos, 5);
			module(1, numcols - 3, pos, 6);
			module(1, numcols - 2, pos, 7);
			module(1, numcols - 1, pos, 8);
		}
	}
	internal sealed class EdifactEncoder : Encoder
	{
		public int EncodingMode => 4;

		public void encode(EncoderContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (context.HasMoreCharacters)
			{
				encodeChar(context.CurrentChar, stringBuilder);
				context.Pos++;
				if (stringBuilder.Length >= 4)
				{
					context.writeCodewords(encodeToCodewords(stringBuilder, 0));
					stringBuilder.Remove(0, 4);
					if (HighLevelEncoder.lookAheadTest(context.Message, context.Pos, EncodingMode) != EncodingMode)
					{
						context.signalEncoderChange(0);
						break;
					}
				}
			}
			stringBuilder.Append('\u001f');
			handleEOD(context, stringBuilder);
		}

		private static void handleEOD(EncoderContext context, StringBuilder buffer)
		{
			try
			{
				int length = buffer.Length;
				switch (length)
				{
				case 0:
					return;
				case 1:
				{
					context.updateSymbolInfo();
					int num = context.SymbolInfo.dataCapacity - context.CodewordCount;
					int remainingCharacters = context.RemainingCharacters;
					if (remainingCharacters > num)
					{
						context.updateSymbolInfo(context.CodewordCount + 1);
						num = context.SymbolInfo.dataCapacity - context.CodewordCount;
					}
					if (remainingCharacters <= num && num <= 2)
					{
						return;
					}
					break;
				}
				}
				if (length > 4)
				{
					throw new InvalidOperationException("Count must not exceed 4");
				}
				int num2 = length - 1;
				string text = encodeToCodewords(buffer, 0);
				bool flag = !context.HasMoreCharacters && num2 <= 2;
				if (num2 <= 2)
				{
					context.updateSymbolInfo(context.CodewordCount + num2);
					if (context.SymbolInfo.dataCapacity - context.CodewordCount >= 3)
					{
						flag = false;
						context.updateSymbolInfo(context.CodewordCount + text.Length);
					}
				}
				if (flag)
				{
					context.resetSymbolInfo();
					context.Pos -= num2;
				}
				else
				{
					context.writeCodewords(text);
				}
			}
			finally
			{
				context.signalEncoderChange(0);
			}
		}

		private static void encodeChar(char c, StringBuilder sb)
		{
			if (c >= ' ' && c <= '?')
			{
				sb.Append(c);
			}
			else if (c >= '@' && c <= '^')
			{
				sb.Append((char)(c - 64));
			}
			else
			{
				HighLevelEncoder.illegalCharacter(c);
			}
		}

		private static string encodeToCodewords(StringBuilder sb, int startPos)
		{
			int num = sb.Length - startPos;
			if (num == 0)
			{
				throw new InvalidOperationException("StringBuilder must not be empty");
			}
			char c = sb[startPos];
			char c2 = ((num >= 2) ? sb[startPos + 1] : '\0');
			char c3 = ((num >= 3) ? sb[startPos + 2] : '\0');
			char c4 = ((num >= 4) ? sb[startPos + 3] : '\0');
			uint num2 = ((uint)c << 18) + ((uint)c2 << 12) + ((uint)c3 << 6) + c4;
			char value = (char)(((int)num2 >> 16) & 0xFF);
			char value2 = (char)(((int)num2 >> 8) & 0xFF);
			char value3 = (char)(num2 & 0xFF);
			StringBuilder stringBuilder = new StringBuilder(3);
			stringBuilder.Append(value);
			if (num >= 2)
			{
				stringBuilder.Append(value2);
			}
			if (num >= 3)
			{
				stringBuilder.Append(value3);
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class Encodation
	{
		public const int ASCII = 0;

		public const int C40 = 1;

		public const int TEXT = 2;

		public const int X12 = 3;

		public const int EDIFACT = 4;

		public const int BASE256 = 5;
	}
	internal interface Encoder
	{
		int EncodingMode { get; }

		void encode(EncoderContext context);
	}
	internal sealed class EncoderContext
	{
		private readonly string msg;

		private SymbolShapeHint shape;

		private Dimension minSize;

		private Dimension maxSize;

		private readonly StringBuilder codewords;

		private int pos;

		private int newEncoding;

		private SymbolInfo symbolInfo;

		private int skipAtEnd;

		private static readonly Encoding encoding;

		public char CurrentChar => msg[pos];

		public char Current => msg[pos];

		public int CodewordCount => codewords.Length;

		public bool HasMoreCharacters => pos < TotalMessageCharCount;

		private int TotalMessageCharCount => msg.Length - skipAtEnd;

		public int RemainingCharacters => TotalMessageCharCount - pos;

		public int Pos
		{
			get
			{
				return pos;
			}
			set
			{
				pos = value;
			}
		}

		public StringBuilder Codewords => codewords;

		public SymbolInfo SymbolInfo => symbolInfo;

		public int NewEncoding => newEncoding;

		public string Message => msg;

		public bool Fnc1CodewordIsWritten { get; set; }

		static EncoderContext()
		{
			encoding = Encoding.GetEncoding("UTF-8");
		}

		public EncoderContext(string msg)
		{
			byte[] bytes = encoding.GetBytes(msg);
			StringBuilder stringBuilder = new StringBuilder(bytes.Length);
			int num = bytes.Length;
			for (int i = 0; i < num; i++)
			{
				char c = (char)(bytes[i] & 0xFF);
				if (c == '?' && msg[i] != '?')
				{
					throw new ArgumentException("Message contains characters outside " + encoding.WebName + " encoding.");
				}
				stringBuilder.Append(c);
			}
			this.msg = stringBuilder.ToString();
			shape = SymbolShapeHint.FORCE_NONE;
			codewords = new StringBuilder(msg.Length);
			newEncoding = -1;
		}

		public void setSymbolShape(SymbolShapeHint shape)
		{
			this.shape = shape;
		}

		public void setSizeConstraints(Dimension minSize, Dimension maxSize)
		{
			this.minSize = minSize;
			this.maxSize = maxSize;
		}

		public void setSkipAtEnd(int count)
		{
			skipAtEnd = count;
		}

		public void writeCodewords(string codewords)
		{
			this.codewords.Append(codewords);
		}

		public void writeCodeword(char codeword)
		{
			codewords.Append(codeword);
		}

		public void signalEncoderChange(int encoding)
		{
			newEncoding = encoding;
		}

		public void resetEncoderSignal()
		{
			newEncoding = -1;
		}

		public void updateSymbolInfo()
		{
			updateSymbolInfo(CodewordCount);
		}

		public void updateSymbolInfo(int len)
		{
			if (symbolInfo == null || len > symbolInfo.dataCapacity)
			{
				symbolInfo = SymbolInfo.lookup(len, shape, minSize, maxSize, fail: true);
			}
		}

		public void resetSymbolInfo()
		{
			symbolInfo = null;
		}
	}
	public static class ErrorCorrection
	{
		private static readonly int[] FACTOR_SETS;

		private static readonly int[][] FACTORS;

		private const int MODULO_VALUE = 301;

		private static readonly int[] LOG;

		private static readonly int[] ALOG;

		static ErrorCorrection()
		{
			FACTOR_SETS = new int[16]
			{
				5, 7, 10, 11, 12, 14, 18, 20, 24, 28,
				36, 42, 48, 56, 62, 68
			};
			FACTORS = new int[16][]
			{
				new int[5] { 228, 48, 15, 111, 62 },
				new int[7] { 23, 68, 144, 134, 240, 92, 254 },
				new int[10] { 28, 24, 185, 166, 223, 248, 116, 255, 110, 61 },
				new int[11]
				{
					175, 138, 205, 12, 194, 168, 39, 245, 60, 97,
					120
				},
				new int[12]
				{
					41, 153, 158, 91, 61, 42, 142, 213, 97, 178,
					100, 242
				},
				new int[14]
				{
					156, 97, 192, 252, 95, 9, 157, 119, 138, 45,
					18, 186, 83, 185
				},
				new int[18]
				{
					83, 195, 100, 39, 188, 75, 66, 61, 241, 213,
					109, 129, 94, 254, 225, 48, 90, 188
				},
				new int[20]
				{
					15, 195, 244, 9, 233, 71, 168, 2, 188, 160,
					153, 145, 253, 79, 108, 82, 27, 174, 186, 172
				},
				new int[24]
				{
					52, 190, 88, 205, 109, 39, 176, 21, 155, 197,
					251, 223, 155, 21, 5, 172, 254, 124, 12, 181,
					184, 96, 50, 193
				},
				new int[28]
				{
					211, 231, 43, 97, 71, 96, 103, 174, 37, 151,
					170, 53, 75, 34, 249, 121, 17, 138, 110, 213,
					141, 136, 120, 151, 233, 168, 93, 255
				},
				new int[36]
				{
					245, 127, 242, 218, 130, 250, 162, 181, 102, 120,
					84, 179, 220, 251, 80, 182, 229, 18, 2, 4,
					68, 33, 101, 137, 95, 119, 115, 44, 175, 184,
					59, 25, 225, 98, 81, 112
				},
				new int[42]
				{
					77, 193, 137, 31, 19, 38, 22, 153, 247, 105,
					122, 2, 245, 133, 242, 8, 175, 95, 100, 9,
					167, 105, 214, 111, 57, 121, 21, 1, 253, 57,
					54, 101, 248, 202, 69, 50, 150, 177, 226, 5,
					9, 5
				},
				new int[48]
				{
					245, 132, 172, 223, 96, 32, 117, 22, 238, 133,
					238, 231, 205, 188, 237, 87, 191, 106, 16, 147,
					118, 23, 37, 90, 170, 205, 131, 88, 120, 100,
					66, 138, 186, 240, 82, 44, 176, 87, 187, 147,
					160, 175, 69, 213, 92, 253, 225, 19
				},
				new int[56]
				{
					175, 9, 223, 238, 12, 17, 220, 208, 100, 29,
					175, 170, 230, 192, 215, 235, 150, 159, 36, 223,
					38, 200, 132, 54, 228, 146, 218, 234, 117, 203,
					29, 232, 144, 238, 22, 150, 201, 117, 62, 207,
					164, 13, 137, 245, 127, 67, 247, 28, 155, 43,
					203, 107, 233, 53, 143, 46
				},
				new int[62]
				{
					242, 93, 169, 50, 144, 210, 39, 118, 202, 188,
					201, 189, 143, 108, 196, 37, 185, 112, 134, 230,
					245, 63, 197, 190, 250, 106, 185, 221, 175, 64,
					114, 71, 161, 44, 147, 6, 27, 218, 51, 63,
					87, 10, 40, 130, 188, 17, 163, 31, 176, 170,
					4, 107, 232, 7, 94, 166, 224, 124, 86, 47,
					11, 204
				},
				new int[68]
				{
					220, 228, 173, 89, 251, 149, 159, 56, 89, 33,
					147, 244, 154, 36, 73, 127, 213, 136, 248, 180,
					234, 197, 158, 177, 68, 122, 93, 213, 15, 160,
					227, 236, 66, 139, 153, 185, 202, 167, 179, 25,
					220, 232, 96, 210, 231, 136, 223, 239, 181, 241,
					59, 52, 172, 25, 49, 232, 211, 189, 64, 54,
					108, 153, 132, 63, 96, 103, 82, 186
				}
			};
			LOG = new int[256];
			ALOG = new int[255];
			int num = 1;
			for (int i = 0; i < 255; i++)
			{
				ALOG[i] = num;
				LOG[num] = i;
				num <<= 1;
				if (num >= 256)
				{
					num ^= 0x12D;
				}
			}
		}

		public static string encodeECC200(string codewords, SymbolInfo symbolInfo)
		{
			if (codewords.Length != symbolInfo.dataCapacity)
			{
				throw new ArgumentException("The number of codewords does not match the selected symbol");
			}
			StringBuilder stringBuilder = new StringBuilder(symbolInfo.dataCapacity + symbolInfo.errorCodewords);
			stringBuilder.Append(codewords);
			int interleavedBlockCount = symbolInfo.getInterleavedBlockCount();
			if (interleavedBlockCount == 1)
			{
				string value = createECCBlock(codewords, symbolInfo.errorCodewords);
				stringBuilder.Append(value);
			}
			else
			{
				stringBuilder.Length = stringBuilder.Capacity;
				int[] array = new int[interleavedBlockCount];
				int[] array2 = new int[interleavedBlockCount];
				int[] array3 = new int[interleavedBlockCount];
				for (int i = 0; i < interleavedBlockCount; i++)
				{
					array[i] = symbolInfo.getDataLengthForInterleavedBlock(i + 1);
					array2[i] = symbolInfo.getErrorLengthForInterleavedBlock(i + 1);
					array3[i] = 0;
					if (i > 0)
					{
						array3[i] = array3[i - 1] + array[i];
					}
				}
				for (int j = 0; j < interleavedBlockCount; j++)
				{
					StringBuilder stringBuilder2 = new StringBuilder(array[j]);
					for (int k = j; k < symbolInfo.dataCapacity; k += interleavedBlockCount)
					{
						stringBuilder2.Append(codewords[k]);
					}
					string text = createECCBlock(stringBuilder2.ToString(), array2[j]);
					int num = 0;
					for (int l = j; l < array2[j] * interleavedBlockCount; l += interleavedBlockCount)
					{
						stringBuilder[symbolInfo.dataCapacity + l] = text[num++];
					}
				}
			}
			return stringBuilder.ToString();
		}

		private static string createECCBlock(string codewords, int numECWords)
		{
			return createECCBlock(codewords, 0, codewords.Length, numECWords);
		}

		private static string createECCBlock(string codewords, int start, int len, int numECWords)
		{
			int num = -1;
			for (int i = 0; i < FACTOR_SETS.Length; i++)
			{
				if (FACTOR_SETS[i] == numECWords)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				throw new ArgumentException("Illegal number of error correction codewords specified: " + numECWords);
			}
			int[] array = FACTORS[num];
			char[] array2 = new char[numECWords];
			for (int j = 0; j < numECWords; j++)
			{
				array2[j] = '\0';
			}
			for (int k = start; k < start + len; k++)
			{
				int num2 = array2[numECWords - 1] ^ codewords[k];
				for (int num3 = numECWords - 1; num3 > 0; num3--)
				{
					if (num2 != 0 && array[num3] != 0)
					{
						array2[num3] = (char)(array2[num3 - 1] ^ ALOG[(LOG[num2] + LOG[array[num3]]) % 255]);
					}
					else
					{
						array2[num3] = array2[num3 - 1];
					}
				}
				if (num2 != 0 && array[0] != 0)
				{
					array2[0] = (char)ALOG[(LOG[num2] + LOG[array[0]]) % 255];
				}
				else
				{
					array2[0] = '\0';
				}
			}
			char[] array3 = new char[numECWords];
			for (int l = 0; l < numECWords; l++)
			{
				array3[l] = array2[numECWords - l - 1];
			}
			return new string(array3);
		}
	}
	internal static class HighLevelEncoder
	{
		public const char PAD = '\u0081';

		public const char LATCH_TO_C40 = 'æ';

		public const char LATCH_TO_BASE256 = 'ç';

		public const char FNC1 = 'è';

		public const char STRUCTURED_APPEND = 'é';

		public const char READER_PROGRAMMING = 'ê';

		public const char UPPER_SHIFT = 'ë';

		public const char MACRO_05 = 'ì';

		public const char MACRO_06 = 'í';

		public const char LATCH_TO_ANSIX12 = 'î';

		public const char LATCH_TO_TEXT = 'ï';

		public const char LATCH_TO_EDIFACT = 'ð';

		public const char ECI = 'ñ';

		public const char C40_UNLATCH = 'þ';

		public const char X12_UNLATCH = 'þ';

		public const string MACRO_05_HEADER = "[)>\u001e05\u001d";

		public const string MACRO_06_HEADER = "[)>\u001e06\u001d";

		public const string MACRO_TRAILER = "\u001e\u0004";

		private static char randomize253State(char ch, int codewordPosition)
		{
			int num = 149 * codewordPosition % 253 + 1;
			int num2 = ch + num;
			return (char)((num2 <= 254) ? num2 : (num2 - 254));
		}

		public static string encodeHighLevel(string msg)
		{
			return encodeHighLevel(msg, SymbolShapeHint.FORCE_NONE, null, null, 0);
		}

		public static string encodeHighLevel(string msg, SymbolShapeHint shape, Dimension minSize, Dimension maxSize, int defaultEncodation)
		{
			Encoder[] array = new Encoder[6]
			{
				new ASCIIEncoder(),
				new C40Encoder(),
				new TextEncoder(),
				new X12Encoder(),
				new EdifactEncoder(),
				new Base256Encoder()
			};
			EncoderContext encoderContext = new EncoderContext(msg);
			encoderContext.setSymbolShape(shape);
			encoderContext.setSizeConstraints(minSize, maxSize);
			if (msg.StartsWith("[)>\u001e05\u001d") && msg.EndsWith("\u001e\u0004"))
			{
				encoderContext.writeCodeword('ì');
				encoderContext.setSkipAtEnd(2);
				encoderContext.Pos += "[)>\u001e05\u001d".Length;
			}
			else if (msg.StartsWith("[)>\u001e06\u001d") && msg.EndsWith("\u001e\u0004"))
			{
				encoderContext.writeCodeword('í');
				encoderContext.setSkipAtEnd(2);
				encoderContext.Pos += "[)>\u001e06\u001d".Length;
			}
			int num = defaultEncodation;
			switch (num)
			{
			case 5:
				encoderContext.writeCodeword('ç');
				break;
			case 1:
				encoderContext.writeCodeword('æ');
				break;
			case 3:
				encoderContext.writeCodeword('î');
				break;
			case 2:
				encoderContext.writeCodeword('ï');
				break;
			case 4:
				encoderContext.writeCodeword('ð');
				break;
			default:
				throw new InvalidOperationException("Illegal mode: " + num);
			case 0:
				break;
			}
			while (encoderContext.HasMoreCharacters)
			{
				array[num].encode(encoderContext);
				if (encoderContext.NewEncoding >= 0)
				{
					num = encoderContext.NewEncoding;
					encoderContext.resetEncoderSignal();
				}
			}
			int length = encoderContext.Codewords.Length;
			encoderContext.updateSymbolInfo();
			int dataCapacity = encoderContext.SymbolInfo.dataCapacity;
			if (length < dataCapacity && num != 0 && num != 5 && num != 4)
			{
				encoderContext.writeCodeword('þ');
			}
			StringBuilder codewords = encoderContext.Codewords;
			if (codewords.Length < dataCapacity)
			{
				codewords.Append('\u0081');
			}
			while (codewords.Length < dataCapacity)
			{
				codewords.Append(randomize253State('\u0081', codewords.Length + 1));
			}
			return encoderContext.Codewords.ToString();
		}

		internal static int lookAheadTest(string msg, int startpos, int currentMode)
		{
			if (startpos >= msg.Length)
			{
				return currentMode;
			}
			float[] array;
			if (currentMode == 0)
			{
				array = new float[6] { 0f, 1f, 1f, 1f, 1f, 1.25f };
			}
			else
			{
				array = new float[6] { 1f, 2f, 2f, 2f, 2f, 2.25f };
				array[currentMode] = 0f;
			}
			int num = 0;
			while (true)
			{
				if (startpos + num == msg.Length)
				{
					int min = 2147483647;
					byte[] array2 = new byte[6];
					int[] array3 = new int[6];
					min = findMinimums(array, array3, min, array2);
					int minimumCount = getMinimumCount(array2);
					if (array3[0] == min)
					{
						return 0;
					}
					if (minimumCount == 1 && array2[5] > 0)
					{
						return 5;
					}
					if (minimumCount == 1 && array2[4] > 0)
					{
						return 4;
					}
					if (minimumCount == 1 && array2[2] > 0)
					{
						return 2;
					}
					if (minimumCount == 1 && array2[3] > 0)
					{
						return 3;
					}
					return 1;
				}
				char ch = msg[startpos + num];
				num++;
				if (isDigit(ch))
				{
					array[0] += 0.5f;
				}
				else if (isExtendedASCII(ch))
				{
					array[0] = (float)Math.Ceiling(array[0]);
					array[0] += 2f;
				}
				else
				{
					array[0] = (float)Math.Ceiling(array[0]);
					array[0] += 1f;
				}
				if (isNativeC40(ch))
				{
					array[1] += 2f / 3f;
				}
				else if (isExtendedASCII(ch))
				{
					array[1] += 2.6666667f;
				}
				else
				{
					array[1] += 1.3333334f;
				}
				if (isNativeText(ch))
				{
					array[2] += 2f / 3f;
				}
				else if (isExtendedASCII(ch))
				{
					array[2] += 2.6666667f;
				}
				else
				{
					array[2] += 1.3333334f;
				}
				if (isNativeX12(ch))
				{
					array[3] += 2f / 3f;
				}
				else if (isExtendedASCII(ch))
				{
					array[3] += 4.3333335f;
				}
				else
				{
					array[3] += 3.3333333f;
				}
				if (isNativeEDIFACT(ch))
				{
					array[4] += 0.75f;
				}
				else if (isExtendedASCII(ch))
				{
					array[4] += 4.25f;
				}
				else
				{
					array[4] += 3.25f;
				}
				if (isSpecialB256(ch))
				{
					array[5] += 4f;
				}
				else
				{
					array[5] += 1f;
				}
				if (num < 4)
				{
					continue;
				}
				int[] array4 = new int[6];
				byte[] array5 = new byte[6];
				findMinimums(array, array4, 2147483647, array5);
				int minimumCount2 = getMinimumCount(array5);
				if (array4[0] < array4[5] && array4[0] < array4[1] && array4[0] < array4[2] && array4[0] < array4[3] && array4[0] < array4[4])
				{
					return 0;
				}
				if (array4[5] < array4[0] || array5[1] + array5[2] + array5[3] + array5[4] == 0)
				{
					return 5;
				}
				if (minimumCount2 == 1 && array5[4] > 0)
				{
					return 4;
				}
				if (minimumCount2 == 1 && array5[2] > 0)
				{
					return 2;
				}
				if (minimumCount2 == 1 && array5[3] > 0)
				{
					return 3;
				}
				if (array4[1] + 1 < array4[0] && array4[1] + 1 < array4[5] && array4[1] + 1 < array4[4] && array4[1] + 1 < array4[2])
				{
					if (array4[1] < array4[3])
					{
						return 1;
					}
					if (array4[1] == array4[3])
					{
						break;
					}
				}
			}
			for (int i = startpos + num + 1; i < msg.Length; i++)
			{
				char ch2 = msg[i];
				if (isX12TermSep(ch2))
				{
					return 3;
				}
				if (!isNativeX12(ch2))
				{
					break;
				}
			}
			return 1;
		}

		private static int findMinimums(float[] charCounts, int[] intCharCounts, int min, byte[] mins)
		{
			SupportClass.Fill(mins, (byte)0);
			for (int i = 0; i < 6; i++)
			{
				intCharCounts[i] = (int)Math.Ceiling(charCounts[i]);
				int num = intCharCounts[i];
				if (min > num)
				{
					min = num;
					SupportClass.Fill(mins, (byte)0);
				}
				if (min == num)
				{
					mins[i]++;
				}
			}
			return min;
		}

		private static int getMinimumCount(byte[] mins)
		{
			int num = 0;
			for (int i = 0; i < 6; i++)
			{
				num += mins[i];
			}
			return num;
		}

		internal static bool isDigit(char ch)
		{
			if (ch >= '0')
			{
				return ch <= '9';
			}
			return false;
		}

		internal static bool isExtendedASCII(char ch)
		{
			if (ch >= '\u0080')
			{
				return ch <= 'ÿ';
			}
			return false;
		}

		internal static bool isNativeC40(char ch)
		{
			switch (ch)
			{
			default:
				if (ch >= 'A')
				{
					return ch <= 'Z';
				}
				return false;
			case ' ':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return true;
			}
		}

		internal static bool isNativeText(char ch)
		{
			switch (ch)
			{
			default:
				if (ch < 'a' || ch > 'z')
				{
					return ch == '\u001d';
				}
				break;
			case ' ':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				break;
			}
			return true;
		}

		internal static bool isNativeX12(char ch)
		{
			if (!isX12TermSep(ch))
			{
				switch (ch)
				{
				default:
					if (ch >= 'A')
					{
						return ch <= 'Z';
					}
					return false;
				case ' ':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					break;
				}
			}
			return true;
		}

		internal static bool isX12TermSep(char ch)
		{
			if (ch != '\r' && ch != '*')
			{
				return ch == '>';
			}
			return true;
		}

		internal static bool isNativeEDIFACT(char ch)
		{
			if (ch >= ' ')
			{
				return ch <= '^';
			}
			return false;
		}

		internal static bool isSpecialB256(char ch)
		{
			return false;
		}

		public static int determineConsecutiveDigitCount(string msg, int startpos)
		{
			int num = 0;
			int length = msg.Length;
			int num2 = startpos;
			if (num2 < length)
			{
				char ch = msg[num2];
				while (isDigit(ch) && num2 < length)
				{
					num++;
					num2++;
					if (num2 < length)
					{
						ch = msg[num2];
					}
				}
			}
			return num;
		}

		internal static void illegalCharacter(char c)
		{
			throw new ArgumentException(string.Format("Illegal character: {0} (0x{1:X})", new object[2]
			{
				c,
				(int)c
			}));
		}
	}
	public class SymbolInfo
	{
		internal static readonly SymbolInfo[] PROD_SYMBOLS = new SymbolInfo[30]
		{
			new SymbolInfo(rectangular: false, 3, 5, 8, 8, 1),
			new SymbolInfo(rectangular: false, 5, 7, 10, 10, 1),
			new SymbolInfo(rectangular: true, 5, 7, 16, 6, 1),
			new SymbolInfo(rectangular: false, 8, 10, 12, 12, 1),
			new SymbolInfo(rectangular: true, 10, 11, 14, 6, 2),
			new SymbolInfo(rectangular: false, 12, 12, 14, 14, 1),
			new SymbolInfo(rectangular: true, 16, 14, 24, 10, 1),
			new SymbolInfo(rectangular: false, 18, 14, 16, 16, 1),
			new SymbolInfo(rectangular: false, 22, 18, 18, 18, 1),
			new SymbolInfo(rectangular: true, 22, 18, 16, 10, 2),
			new SymbolInfo(rectangular: false, 30, 20, 20, 20, 1),
			new SymbolInfo(rectangular: true, 32, 24, 16, 14, 2),
			new SymbolInfo(rectangular: false, 36, 24, 22, 22, 1),
			new SymbolInfo(rectangular: false, 44, 28, 24, 24, 1),
			new SymbolInfo(rectangular: true, 49, 28, 22, 14, 2),
			new SymbolInfo(rectangular: false, 62, 36, 14, 14, 4),
			new SymbolInfo(rectangular: false, 86, 42, 16, 16, 4),
			new SymbolInfo(rectangular: false, 114, 48, 18, 18, 4),
			new SymbolInfo(rectangular: false, 144, 56, 20, 20, 4),
			new SymbolInfo(rectangular: false, 174, 68, 22, 22, 4),
			new SymbolInfo(rectangular: false, 204, 84, 24, 24, 4, 102, 42),
			new SymbolInfo(rectangular: false, 280, 112, 14, 14, 16, 140, 56),
			new SymbolInfo(rectangular: false, 368, 144, 16, 16, 16, 92, 36),
			new SymbolInfo(rectangular: false, 456, 192, 18, 18, 16, 114, 48),
			new SymbolInfo(rectangular: false, 576, 224, 20, 20, 16, 144, 56),
			new SymbolInfo(rectangular: false, 696, 272, 22, 22, 16, 174, 68),
			new SymbolInfo(rectangular: false, 816, 336, 24, 24, 16, 136, 56),
			new SymbolInfo(rectangular: false, 1050, 408, 18, 18, 36, 175, 68),
			new SymbolInfo(rectangular: false, 1304, 496, 20, 20, 36, 163, 62),
			new DataMatrixSymbolInfo144()
		};

		private static SymbolInfo[] symbols = PROD_SYMBOLS;

		private readonly bool rectangular;

		internal readonly int dataCapacity;

		internal readonly int errorCodewords;

		public readonly int matrixWidth;

		public readonly int matrixHeight;

		private readonly int dataRegions;

		private readonly int rsBlockData;

		private readonly int rsBlockError;

		public static void overrideSymbolSet(SymbolInfo[] @override)
		{
			symbols = @override;
		}

		public SymbolInfo(bool rectangular, int dataCapacity, int errorCodewords, int matrixWidth, int matrixHeight, int dataRegions)
			: this(rectangular, dataCapacity, errorCodewords, matrixWidth, matrixHeight, dataRegions, dataCapacity, errorCodewords)
		{
		}

		internal SymbolInfo(bool rectangular, int dataCapacity, int errorCodewords, int matrixWidth, int matrixHeight, int dataRegions, int rsBlockData, int rsBlockError)
		{
			this.rectangular = rectangular;
			this.dataCapacity = dataCapacity;
			this.errorCodewords = errorCodewords;
			this.matrixWidth = matrixWidth;
			this.matrixHeight = matrixHeight;
			this.dataRegions = dataRegions;
			this.rsBlockData = rsBlockData;
			this.rsBlockError = rsBlockError;
		}

		public static SymbolInfo lookup(int dataCodewords)
		{
			return lookup(dataCodewords, SymbolShapeHint.FORCE_NONE, fail: true);
		}

		public static SymbolInfo lookup(int dataCodewords, SymbolShapeHint shape)
		{
			return lookup(dataCodewords, shape, fail: true);
		}

		public static SymbolInfo lookup(int dataCodewords, bool allowRectangular, bool fail)
		{
			SymbolShapeHint shape = ((!allowRectangular) ? SymbolShapeHint.FORCE_SQUARE : SymbolShapeHint.FORCE_NONE);
			return lookup(dataCodewords, shape, fail);
		}

		private static SymbolInfo lookup(int dataCodewords, SymbolShapeHint shape, bool fail)
		{
			return lookup(dataCodewords, shape, null, null, fail);
		}

		public static SymbolInfo lookup(int dataCodewords, SymbolShapeHint shape, Dimension minSize, Dimension maxSize, bool fail)
		{
			SymbolInfo[] array = symbols;
			foreach (SymbolInfo symbolInfo in array)
			{
				if ((shape != SymbolShapeHint.FORCE_SQUARE || !symbolInfo.rectangular) && (shape != SymbolShapeHint.FORCE_RECTANGLE || symbolInfo.rectangular) && (minSize == null || (symbolInfo.getSymbolWidth() >= minSize.Width && symbolInfo.getSymbolHeight() >= minSize.Height)) && (maxSize == null || (symbolInfo.getSymbolWidth() <= maxSize.Width && symbolInfo.getSymbolHeight() <= maxSize.Height)) && dataCodewords <= symbolInfo.dataCapacity)
				{
					return symbolInfo;
				}
			}
			if (fail)
			{
				throw new ArgumentException("Can't find a symbol arrangement that matches the message. Data codewords: " + dataCodewords);
			}
			return null;
		}

		private int getHorizontalDataRegions()
		{
			switch (dataRegions)
			{
			case 1:
				return 1;
			case 2:
			case 4:
				return 2;
			case 16:
				return 4;
			case 36:
				return 6;
			default:
				throw new InvalidOperationException("Cannot handle this number of data regions");
			}
		}

		private int getVerticalDataRegions()
		{
			switch (dataRegions)
			{
			case 1:
			case 2:
				return 1;
			case 4:
				return 2;
			case 16:
				return 4;
			case 36:
				return 6;
			default:
				throw new InvalidOperationException("Cannot handle this number of data regions");
			}
		}

		public int getSymbolDataWidth()
		{
			return getHorizontalDataRegions() * matrixWidth;
		}

		public int getSymbolDataHeight()
		{
			return getVerticalDataRegions() * matrixHeight;
		}

		public int getSymbolWidth()
		{
			return getSymbolDataWidth() + getHorizontalDataRegions() * 2;
		}

		public int getSymbolHeight()
		{
			return getSymbolDataHeight() + getVerticalDataRegions() * 2;
		}

		public int getCodewordCount()
		{
			return dataCapacity + errorCodewords;
		}

		public virtual int getInterleavedBlockCount()
		{
			return dataCapacity / rsBlockData;
		}

		public virtual int getDataLengthForInterleavedBlock(int index)
		{
			return rsBlockData;
		}

		public int getErrorLengthForInterleavedBlock(int index)
		{
			return rsBlockError;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(rectangular ? "Rectangular Symbol:" : "Square Symbol:");
			stringBuilder.Append(" data region ").Append(matrixWidth).Append('x')
				.Append(matrixHeight);
			stringBuilder.Append(", symbol size ").Append(getSymbolWidth()).Append('x')
				.Append(getSymbolHeight());
			stringBuilder.Append(", symbol data size ").Append(getSymbolDataWidth()).Append('x')
				.Append(getSymbolDataHeight());
			stringBuilder.Append(", codewords ").Append(dataCapacity).Append('+')
				.Append(errorCodewords);
			return stringBuilder.ToString();
		}
	}
	public enum SymbolShapeHint
	{
		FORCE_NONE,
		FORCE_SQUARE,
		FORCE_RECTANGLE
	}
	internal sealed class TextEncoder : C40Encoder
	{
		public override int EncodingMode => 2;

		protected override int encodeChar(char c, StringBuilder sb)
		{
			switch (c)
			{
			case ' ':
				sb.Append('\u0003');
				return 1;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				sb.Append((char)(c - 48 + 4));
				return 1;
			default:
				if (c >= 'a' && c <= 'z')
				{
					sb.Append((char)(c - 97 + 14));
					return 1;
				}
				if (c >= '\0' && c <= '\u001f')
				{
					sb.Append('\0');
					sb.Append(c);
					return 2;
				}
				if (c >= '!' && c <= '/')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 33));
					return 2;
				}
				if (c >= ':' && c <= '@')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 58 + 15));
					return 2;
				}
				if (c >= '[' && c <= '_')
				{
					sb.Append('\u0001');
					sb.Append((char)(c - 91 + 22));
					return 2;
				}
				switch (c)
				{
				case '`':
					sb.Append('\u0002');
					sb.Append((char)(c - 96));
					return 2;
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'G':
				case 'H':
				case 'I':
				case 'J':
				case 'K':
				case 'L':
				case 'M':
				case 'N':
				case 'O':
				case 'P':
				case 'Q':
				case 'R':
				case 'S':
				case 'T':
				case 'U':
				case 'V':
				case 'W':
				case 'X':
				case 'Y':
				case 'Z':
					sb.Append('\u0002');
					sb.Append((char)(c - 65 + 1));
					return 2;
				default:
					if (c >= '{' && c <= '\u007f')
					{
						sb.Append('\u0002');
						sb.Append((char)(c - 123 + 27));
						return 2;
					}
					if (c >= '\u0080')
					{
						sb.Append("\u0001\u001e");
						return 2 + encodeChar((char)(c - 128), sb);
					}
					HighLevelEncoder.illegalCharacter(c);
					return -1;
				}
			}
		}
	}
	internal sealed class X12Encoder : C40Encoder
	{
		public override int EncodingMode => 3;

		public override void encode(EncoderContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int encodingMode = EncodingMode;
			while (context.HasMoreCharacters)
			{
				char currentChar = context.CurrentChar;
				context.Pos++;
				encodeChar(currentChar, stringBuilder);
				if (stringBuilder.Length % 3 == 0)
				{
					C40Encoder.writeNextTriplet(context, stringBuilder);
					if (HighLevelEncoder.lookAheadTest(context.Message, context.Pos, encodingMode) != encodingMode)
					{
						context.signalEncoderChange(0);
						break;
					}
				}
			}
			handleEOD(context, stringBuilder);
		}

		protected override int encodeChar(char c, StringBuilder sb)
		{
			switch (c)
			{
			case '\r':
				sb.Append('\0');
				break;
			case '*':
				sb.Append('\u0001');
				break;
			case '>':
				sb.Append('\u0002');
				break;
			case ' ':
				sb.Append('\u0003');
				break;
			default:
				if (c >= '0' && c <= '9')
				{
					sb.Append((char)(c - 48 + 4));
				}
				else if (c >= 'A' && c <= 'Z')
				{
					sb.Append((char)(c - 65 + 14));
				}
				else
				{
					HighLevelEncoder.illegalCharacter(c);
				}
				break;
			}
			return 1;
		}

		protected override void handleEOD(EncoderContext context, StringBuilder buffer)
		{
			context.updateSymbolInfo();
			int num = context.SymbolInfo.dataCapacity - context.CodewordCount;
			int length = buffer.Length;
			context.Pos -= length;
			if (context.RemainingCharacters > 1 || num > 1 || context.RemainingCharacters != num)
			{
				context.writeCodeword('þ');
			}
			if (context.NewEncoding < 0)
			{
				context.signalEncoderChange(0);
			}
		}
	}
}
namespace ZXing.Datamatrix.Internal
{
	internal sealed class BitMatrixParser
	{
		private readonly BitMatrix mappingBitMatrix;

		private readonly BitMatrix readMappingMatrix;

		private readonly Version version;

		public Version Version => version;

		internal BitMatrixParser(BitMatrix bitMatrix)
		{
			int height = bitMatrix.Height;
			if (height >= 8 && height <= 144 && (height & 1) == 0)
			{
				version = readVersion(bitMatrix);
				if (version != null)
				{
					mappingBitMatrix = extractDataRegion(bitMatrix);
					readMappingMatrix = new BitMatrix(mappingBitMatrix.Width, mappingBitMatrix.Height);
				}
			}
		}

		internal static Version readVersion(BitMatrix bitMatrix)
		{
			int height = bitMatrix.Height;
			int width = bitMatrix.Width;
			return Version.getVersionForDimensions(height, width);
		}

		internal byte[] readCodewords()
		{
			byte[] array = new byte[version.getTotalCodewords()];
			int num = 0;
			int num2 = 4;
			int num3 = 0;
			int height = mappingBitMatrix.Height;
			int width = mappingBitMatrix.Width;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			do
			{
				if (num2 == height && num3 == 0 && !flag)
				{
					array[num++] = (byte)readCorner1(height, width);
					num2 -= 2;
					num3 += 2;
					flag = true;
					continue;
				}
				if (num2 == height - 2 && num3 == 0 && (width & 3) != 0 && !flag2)
				{
					array[num++] = (byte)readCorner2(height, width);
					num2 -= 2;
					num3 += 2;
					flag2 = true;
					continue;
				}
				if (num2 == height + 4 && num3 == 2 && (width & 7) == 0 && !flag3)
				{
					array[num++] = (byte)readCorner3(height, width);
					num2 -= 2;
					num3 += 2;
					flag3 = true;
					continue;
				}
				if (num2 == height - 2 && num3 == 0 && (width & 7) == 4 && !flag4)
				{
					array[num++] = (byte)readCorner4(height, width);
					num2 -= 2;
					num3 += 2;
					flag4 = true;
					continue;
				}
				do
				{
					if (num2 < height && num3 >= 0 && !readMappingMatrix[num3, num2])
					{
						array[num++] = (byte)readUtah(num2, num3, height, width);
					}
					num2 -= 2;
					num3 += 2;
				}
				while (num2 >= 0 && num3 < width);
				num2++;
				num3 += 3;
				do
				{
					if (num2 >= 0 && num3 < width && !readMappingMatrix[num3, num2])
					{
						array[num++] = (byte)readUtah(num2, num3, height, width);
					}
					num2 += 2;
					num3 -= 2;
				}
				while (num2 < height && num3 >= 0);
				num2 += 3;
				num3++;
			}
			while (num2 < height || num3 < width);
			if (num != version.getTotalCodewords())
			{
				return null;
			}
			return array;
		}

		private bool readModule(int row, int column, int numRows, int numColumns)
		{
			if (row < 0)
			{
				row += numRows;
				column += 4 - ((numRows + 4) & 7);
			}
			if (column < 0)
			{
				column += numColumns;
				row += 4 - ((numColumns + 4) & 7);
			}
			readMappingMatrix[column, row] = true;
			return mappingBitMatrix[column, row];
		}

		private int readUtah(int row, int column, int numRows, int numColumns)
		{
			int num = 0;
			if (readModule(row - 2, column - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row - 2, column - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row - 1, column - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row - 1, column - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row - 1, column, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row, column - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row, column - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(row, column, numRows, numColumns))
			{
				num |= 1;
			}
			return num;
		}

		private int readCorner1(int numRows, int numColumns)
		{
			int num = 0;
			if (readModule(numRows - 1, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 1, 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 1, 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(2, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(3, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			return num;
		}

		private int readCorner2(int numRows, int numColumns)
		{
			int num = 0;
			if (readModule(numRows - 3, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 2, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 1, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 4, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 3, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			return num;
		}

		private int readCorner3(int numRows, int numColumns)
		{
			int num = 0;
			if (readModule(numRows - 1, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 1, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 3, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 3, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			return num;
		}

		private int readCorner4(int numRows, int numColumns)
		{
			int num = 0;
			if (readModule(numRows - 3, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 2, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(numRows - 1, 0, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 2, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(0, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(1, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(2, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			num <<= 1;
			if (readModule(3, numColumns - 1, numRows, numColumns))
			{
				num |= 1;
			}
			return num;
		}

		private BitMatrix extractDataRegion(BitMatrix bitMatrix)
		{
			int symbolSizeRows = version.getSymbolSizeRows();
			int symbolSizeColumns = version.getSymbolSizeColumns();
			if (bitMatrix.Height != symbolSizeRows)
			{
				throw new ArgumentException("Dimension of bitMatrix must match the version size");
			}
			int dataRegionSizeRows = version.getDataRegionSizeRows();
			int dataRegionSizeColumns = version.getDataRegionSizeColumns();
			int num = symbolSizeRows / dataRegionSizeRows;
			int num2 = symbolSizeColumns / dataRegionSizeColumns;
			int height = num * dataRegionSizeRows;
			BitMatrix bitMatrix2 = new BitMatrix(num2 * dataRegionSizeColumns, height);
			for (int i = 0; i < num; i++)
			{
				int num3 = i * dataRegionSizeRows;
				for (int j = 0; j < num2; j++)
				{
					int num4 = j * dataRegionSizeColumns;
					for (int k = 0; k < dataRegionSizeRows; k++)
					{
						int y = i * (dataRegionSizeRows + 2) + 1 + k;
						int y2 = num3 + k;
						for (int l = 0; l < dataRegionSizeColumns; l++)
						{
							int x = j * (dataRegionSizeColumns + 2) + 1 + l;
							if (bitMatrix[x, y])
							{
								int x2 = num4 + l;
								bitMatrix2[x2, y2] = true;
							}
						}
					}
				}
			}
			return bitMatrix2;
		}
	}
	internal sealed class DataBlock
	{
		private readonly int numDataCodewords;

		private readonly byte[] codewords;

		internal int NumDataCodewords => numDataCodewords;

		internal byte[] Codewords => codewords;

		private DataBlock(int numDataCodewords, byte[] codewords)
		{
			this.numDataCodewords = numDataCodewords;
			this.codewords = codewords;
		}

		internal static DataBlock[] getDataBlocks(byte[] rawCodewords, Version version)
		{
			Version.ECBlocks eCBlocks = version.getECBlocks();
			int num = 0;
			Version.ECB[] eCBlocksValue = eCBlocks.ECBlocksValue;
			Version.ECB[] array = eCBlocksValue;
			foreach (Version.ECB eCB in array)
			{
				num += eCB.Count;
			}
			DataBlock[] array2 = new DataBlock[num];
			int num2 = 0;
			array = eCBlocksValue;
			foreach (Version.ECB eCB2 in array)
			{
				for (int j = 0; j < eCB2.Count; j++)
				{
					int dataCodewords = eCB2.DataCodewords;
					int num3 = eCBlocks.ECCodewords + dataCodewords;
					array2[num2++] = new DataBlock(dataCodewords, new byte[num3]);
				}
			}
			int num4 = array2[0].codewords.Length - eCBlocks.ECCodewords;
			int num5 = num4 - 1;
			int num6 = 0;
			for (int k = 0; k < num5; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					array2[l].codewords[k] = rawCodewords[num6++];
				}
			}
			bool flag = version.getVersionNumber() == 24;
			int num7 = (flag ? 8 : num2);
			for (int m = 0; m < num7; m++)
			{
				array2[m].codewords[num4 - 1] = rawCodewords[num6++];
			}
			int num8 = array2[0].codewords.Length;
			for (int n = num4; n < num8; n++)
			{
				for (int num9 = 0; num9 < num2; num9++)
				{
					int num10 = (flag ? ((num9 + 8) % num2) : num9);
					int num11 = ((flag && num10 > 7) ? (n - 1) : n);
					array2[num10].codewords[num11] = rawCodewords[num6++];
				}
			}
			if (num6 != rawCodewords.Length)
			{
				throw new ArgumentException();
			}
			return array2;
		}
	}
	internal static class DecodedBitStreamParser
	{
		private enum Mode
		{
			PAD_ENCODE,
			ASCII_ENCODE,
			C40_ENCODE,
			TEXT_ENCODE,
			ANSIX12_ENCODE,
			EDIFACT_ENCODE,
			BASE256_ENCODE
		}

		private static readonly char[] C40_BASIC_SET_CHARS = new char[40]
		{
			'*', '*', '*', ' ', '0', '1', '2', '3', '4', '5',
			'6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F',
			'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
			'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
		};

		private static readonly char[] C40_SHIFT2_SET_CHARS = new char[27]
		{
			'!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
			'+', ',', '-', '.', '/', ':', ';', '<', '=', '>',
			'?', '@', '[', '\\', ']', '^', '_'
		};

		private static readonly char[] TEXT_BASIC_SET_CHARS = new char[40]
		{
			'*', '*', '*', ' ', '0', '1', '2', '3', '4', '5',
			'6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f',
			'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
			'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
		};

		private static readonly char[] TEXT_SHIFT2_SET_CHARS = C40_SHIFT2_SET_CHARS;

		private static readonly char[] TEXT_SHIFT3_SET_CHARS = new char[32]
		{
			'`', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
			'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
			'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '{', '|', '}',
			'~', '\u007f'
		};

		internal static DecoderResult decode(byte[] bytes)
		{
			BitSource bitSource = new BitSource(bytes);
			StringBuilder stringBuilder = new StringBuilder(100);
			StringBuilder stringBuilder2 = new StringBuilder(0);
			List<byte[]> list = new List<byte[]>(1);
			Mode mode = Mode.ASCII_ENCODE;
			do
			{
				switch (mode)
				{
				case Mode.ASCII_ENCODE:
					if (!decodeAsciiSegment(bitSource, stringBuilder, stringBuilder2, out mode))
					{
						return null;
					}
					break;
				case Mode.C40_ENCODE:
					if (!decodeC40Segment(bitSource, stringBuilder))
					{
						return null;
					}
					goto IL_008c;
				case Mode.TEXT_ENCODE:
					if (!decodeTextSegment(bitSource, stringBuilder))
					{
						return null;
					}
					goto IL_008c;
				case Mode.ANSIX12_ENCODE:
					if (!decodeAnsiX12Segment(bitSource, stringBuilder))
					{
						return null;
					}
					goto IL_008c;
				case Mode.EDIFACT_ENCODE:
					if (!decodeEdifactSegment(bitSource, stringBuilder))
					{
						return null;
					}
					goto IL_008c;
				case Mode.BASE256_ENCODE:
					if (!decodeBase256Segment(bitSource, stringBuilder, list))
					{
						return null;
					}
					goto IL_008c;
				default:
					{
						return null;
					}
					IL_008c:
					mode = Mode.ASCII_ENCODE;
					break;
				}
			}
			while (mode != Mode.PAD_ENCODE && bitSource.available() > 0);
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.Append(stringBuilder2.ToString());
			}
			return new DecoderResult(bytes, stringBuilder.ToString(), (list.Count == 0) ? null : list, null);
		}

		private static bool decodeAsciiSegment(BitSource bits, StringBuilder result, StringBuilder resultTrailer, out Mode mode)
		{
			bool flag = false;
			mode = Mode.ASCII_ENCODE;
			do
			{
				int num = bits.readBits(8);
				if (num == 0)
				{
					return false;
				}
				if (num <= 128)
				{
					if (flag)
					{
						num += 128;
					}
					result.Append((char)(num - 1));
					mode = Mode.ASCII_ENCODE;
					return true;
				}
				if (num == 129)
				{
					mode = Mode.PAD_ENCODE;
					return true;
				}
				if (num <= 229)
				{
					int num2 = num - 130;
					if (num2 < 10)
					{
						result.Append('0');
					}
					result.Append(num2);
					continue;
				}
				switch (num)
				{
				case 230:
					mode = Mode.C40_ENCODE;
					return true;
				case 231:
					mode = Mode.BASE256_ENCODE;
					return true;
				case 232:
					result.Append('\u001d');
					continue;
				case 235:
					flag = true;
					continue;
				case 236:
					result.Append("[)>\u001e05\u001d");
					resultTrailer.Insert(0, "\u001e\u0004");
					continue;
				case 237:
					result.Append("[)>\u001e06\u001d");
					resultTrailer.Insert(0, "\u001e\u0004");
					continue;
				case 238:
					mode = Mode.ANSIX12_ENCODE;
					return true;
				case 239:
					mode = Mode.TEXT_ENCODE;
					return true;
				case 240:
					mode = Mode.EDIFACT_ENCODE;
					return true;
				case 233:
				case 234:
				case 241:
					continue;
				}
				if (num >= 242 && (num != 254 || bits.available() != 0))
				{
					return false;
				}
			}
			while (bits.available() > 0);
			mode = Mode.ASCII_ENCODE;
			return true;
		}

		private static bool decodeC40Segment(BitSource bits, StringBuilder result)
		{
			bool flag = false;
			int[] array = new int[3];
			int num = 0;
			do
			{
				if (bits.available() == 8)
				{
					return true;
				}
				int num2 = bits.readBits(8);
				if (num2 == 254)
				{
					return true;
				}
				parseTwoBytes(num2, bits.readBits(8), array);
				for (int i = 0; i < 3; i++)
				{
					int num3 = array[i];
					switch (num)
					{
					case 0:
						if (num3 < 3)
						{
							num = num3 + 1;
							break;
						}
						if (num3 < C40_BASIC_SET_CHARS.Length)
						{
							char c = C40_BASIC_SET_CHARS[num3];
							if (flag)
							{
								result.Append((char)(c + 128));
								flag = false;
							}
							else
							{
								result.Append(c);
							}
							break;
						}
						return false;
					case 1:
						if (flag)
						{
							result.Append((char)(num3 + 128));
							flag = false;
						}
						else
						{
							result.Append((char)num3);
						}
						num = 0;
						break;
					case 2:
						if (num3 < C40_SHIFT2_SET_CHARS.Length)
						{
							char c2 = C40_SHIFT2_SET_CHARS[num3];
							if (flag)
							{
								result.Append((char)(c2 + 128));
								flag = false;
							}
							else
							{
								result.Append(c2);
							}
						}
						else
						{
							switch (num3)
							{
							case 27:
								result.Append('\u001d');
								break;
							case 30:
								flag = true;
								break;
							default:
								return false;
							}
						}
						num = 0;
						break;
					case 3:
						if (flag)
						{
							result.Append((char)(num3 + 224));
							flag = false;
						}
						else
						{
							result.Append((char)(num3 + 96));
						}
						num = 0;
						break;
					default:
						return false;
					}
				}
			}
			while (bits.available() > 0);
			return true;
		}

		private static bool decodeTextSegment(BitSource bits, StringBuilder result)
		{
			bool flag = false;
			int[] array = new int[3];
			int num = 0;
			do
			{
				if (bits.available() == 8)
				{
					return true;
				}
				int num2 = bits.readBits(8);
				if (num2 == 254)
				{
					return true;
				}
				parseTwoBytes(num2, bits.readBits(8), array);
				for (int i = 0; i < 3; i++)
				{
					int num3 = array[i];
					switch (num)
					{
					case 0:
						if (num3 < 3)
						{
							num = num3 + 1;
							break;
						}
						if (num3 < TEXT_BASIC_SET_CHARS.Length)
						{
							char c3 = TEXT_BASIC_SET_CHARS[num3];
							if (flag)
							{
								result.Append((char)(c3 + 128));
								flag = false;
							}
							else
							{
								result.Append(c3);
							}
							break;
						}
						return false;
					case 1:
						if (flag)
						{
							result.Append((char)(num3 + 128));
							flag = false;
						}
						else
						{
							result.Append((char)num3);
						}
						num = 0;
						break;
					case 2:
						if (num3 < TEXT_SHIFT2_SET_CHARS.Length)
						{
							char c2 = TEXT_SHIFT2_SET_CHARS[num3];
							if (flag)
							{
								result.Append((char)(c2 + 128));
								flag = false;
							}
							else
							{
								result.Append(c2);
							}
						}
						else
						{
							switch (num3)
							{
							case 27:
								result.Append('\u001d');
								break;
							case 30:
								flag = true;
								break;
							default:
								return false;
							}
						}
						num = 0;
						break;
					case 3:
						if (num3 < TEXT_SHIFT3_SET_CHARS.Length)
						{
							char c = TEXT_SHIFT3_SET_CHARS[num3];
							if (flag)
							{
								result.Append((char)(c + 128));
								flag = false;
							}
							else
							{
								result.Append(c);
							}
							num = 0;
							break;
						}
						return false;
					default:
						return false;
					}
				}
			}
			while (bits.available() > 0);
			return true;
		}

		private static bool decodeAnsiX12Segment(BitSource bits, StringBuilder result)
		{
			int[] array = new int[3];
			do
			{
				if (bits.available() == 8)
				{
					return true;
				}
				int num = bits.readBits(8);
				if (num == 254)
				{
					return true;
				}
				parseTwoBytes(num, bits.readBits(8), array);
				for (int i = 0; i < 3; i++)
				{
					int num2 = array[i];
					switch (num2)
					{
					case 0:
						result.Append('\r');
						continue;
					case 1:
						result.Append('*');
						continue;
					case 2:
						result.Append('>');
						continue;
					case 3:
						result.Append(' ');
						continue;
					}
					if (num2 < 14)
					{
						result.Append((char)(num2 + 44));
						continue;
					}
					if (num2 < 40)
					{
						result.Append((char)(num2 + 51));
						continue;
					}
					return false;
				}
			}
			while (bits.available() > 0);
			return true;
		}

		private static void parseTwoBytes(int firstByte, int secondByte, int[] result)
		{
			int num = (firstByte << 8) + secondByte - 1;
			num -= (result[0] = num / 1600) * 1600;
			result[2] = num - (result[1] = num / 40) * 40;
		}

		private static bool decodeEdifactSegment(BitSource bits, StringBuilder result)
		{
			do
			{
				if (bits.available() <= 16)
				{
					return true;
				}
				for (int i = 0; i < 4; i++)
				{
					int num = bits.readBits(6);
					if (num == 31)
					{
						int num2 = 8 - bits.BitOffset;
						if (num2 != 8)
						{
							bits.readBits(num2);
						}
						return true;
					}
					if ((num & 0x20) == 0)
					{
						num |= 0x40;
					}
					result.Append((char)num);
				}
			}
			while (bits.available() > 0);
			return true;
		}

		private static bool decodeBase256Segment(BitSource bits, StringBuilder result, IList<byte[]> byteSegments)
		{
			int num = 1 + bits.ByteOffset;
			int num2 = unrandomize255State(bits.readBits(8), num++);
			int num3 = ((num2 == 0) ? (bits.available() / 8) : ((num2 >= 250) ? (250 * (num2 - 249) + unrandomize255State(bits.readBits(8), num++)) : num2));
			if (num3 < 0)
			{
				return false;
			}
			byte[] array = new byte[num3];
			for (int i = 0; i < num3; i++)
			{
				if (bits.available() < 8)
				{
					return false;
				}
				array[i] = (byte)unrandomize255State(bits.readBits(8), num++);
			}
			byteSegments.Add(array);
			try
			{
				result.Append(Encoding.GetEncoding("ISO-8859-1").GetString(array, 0, array.Length));
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Platform does not support required encoding: " + ex);
			}
			return true;
		}

		private static int unrandomize255State(int randomizedBase256Codeword, int base256CodewordPosition)
		{
			int num = 149 * base256CodewordPosition % 255 + 1;
			int num2 = randomizedBase256Codeword - num;
			if (num2 < 0)
			{
				return num2 + 256;
			}
			return num2;
		}
	}
	public sealed class Decoder
	{
		private readonly ReedSolomonDecoder rsDecoder;

		public Decoder()
		{
			rsDecoder = new ReedSolomonDecoder(GenericGF.DATA_MATRIX_FIELD_256);
		}

		public DecoderResult decode(bool[][] image)
		{
			return decode(BitMatrix.parse(image));
		}

		public DecoderResult decode(BitMatrix bits)
		{
			BitMatrixParser bitMatrixParser = new BitMatrixParser(bits);
			if (bitMatrixParser.Version == null)
			{
				return null;
			}
			byte[] array = bitMatrixParser.readCodewords();
			if (array == null)
			{
				return null;
			}
			DataBlock[] dataBlocks = DataBlock.getDataBlocks(array, bitMatrixParser.Version);
			int num = 0;
			DataBlock[] array2 = dataBlocks;
			foreach (DataBlock dataBlock in array2)
			{
				num += dataBlock.NumDataCodewords;
			}
			byte[] array3 = new byte[num];
			int num2 = dataBlocks.Length;
			for (int j = 0; j < num2; j++)
			{
				DataBlock obj = dataBlocks[j];
				byte[] codewords = obj.Codewords;
				int numDataCodewords = obj.NumDataCodewords;
				if (!correctErrors(codewords, numDataCodewords))
				{
					return null;
				}
				for (int k = 0; k < numDataCodewords; k++)
				{
					array3[k * num2 + j] = codewords[k];
				}
			}
			return DecodedBitStreamParser.decode(array3);
		}

		private bool correctErrors(byte[] codewordBytes, int numDataCodewords)
		{
			int num = codewordBytes.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = codewordBytes[i] & 0xFF;
			}
			int twoS = codewordBytes.Length - numDataCodewords;
			if (!rsDecoder.decode(array, twoS))
			{
				return false;
			}
			for (int j = 0; j < numDataCodewords; j++)
			{
				codewordBytes[j] = (byte)array[j];
			}
			return true;
		}
	}
	public sealed class Version
	{
		internal sealed class ECBlocks
		{
			private readonly int ecCodewords;

			private readonly ECB[] _ecBlocksValue;

			internal int ECCodewords => ecCodewords;

			internal ECB[] ECBlocksValue => _ecBlocksValue;

			internal ECBlocks(int ecCodewords, ECB ecBlocks)
			{
				this.ecCodewords = ecCodewords;
				_ecBlocksValue = new ECB[1] { ecBlocks };
			}

			internal ECBlocks(int ecCodewords, ECB ecBlocks1, ECB ecBlocks2)
			{
				this.ecCodewords = ecCodewords;
				_ecBlocksValue = new ECB[2] { ecBlocks1, ecBlocks2 };
			}
		}

		internal sealed class ECB
		{
			private readonly int count;

			private readonly int dataCodewords;

			internal int Count => count;

			internal int DataCodewords => dataCodewords;

			internal ECB(int count, int dataCodewords)
			{
				this.count = count;
				this.dataCodewords = dataCodewords;
			}
		}

		private static readonly Version[] VERSIONS = buildVersions();

		private readonly int versionNumber;

		private readonly int symbolSizeRows;

		private readonly int symbolSizeColumns;

		private readonly int dataRegionSizeRows;

		private readonly int dataRegionSizeColumns;

		private readonly ECBlocks ecBlocks;

		private readonly int totalCodewords;

		internal Version(int versionNumber, int symbolSizeRows, int symbolSizeColumns, int dataRegionSizeRows, int dataRegionSizeColumns, ECBlocks ecBlocks)
		{
			this.versionNumber = versionNumber;
			this.symbolSizeRows = symbolSizeRows;
			this.symbolSizeColumns = symbolSizeColumns;
			this.dataRegionSizeRows = dataRegionSizeRows;
			this.dataRegionSizeColumns = dataRegionSizeColumns;
			this.ecBlocks = ecBlocks;
			int num = 0;
			int eCCodewords = ecBlocks.ECCodewords;
			ECB[] eCBlocksValue = ecBlocks.ECBlocksValue;
			foreach (ECB eCB in eCBlocksValue)
			{
				num += eCB.Count * (eCB.DataCodewords + eCCodewords);
			}
			totalCodewords = num;
		}

		public int getVersionNumber()
		{
			return versionNumber;
		}

		public int getSymbolSizeRows()
		{
			return symbolSizeRows;
		}

		public int getSymbolSizeColumns()
		{
			return symbolSizeColumns;
		}

		public int getDataRegionSizeRows()
		{
			return dataRegionSizeRows;
		}

		public int getDataRegionSizeColumns()
		{
			return dataRegionSizeColumns;
		}

		public int getTotalCodewords()
		{
			return totalCodewords;
		}

		internal ECBlocks getECBlocks()
		{
			return ecBlocks;
		}

		public static Version getVersionForDimensions(int numRows, int numColumns)
		{
			if ((numRows & 1) != 0 || (numColumns & 1) != 0)
			{
				return null;
			}
			Version[] vERSIONS = VERSIONS;
			foreach (Version version in vERSIONS)
			{
				if (version.symbolSizeRows == numRows && version.symbolSizeColumns == numColumns)
				{
					return version;
				}
			}
			return null;
		}

		public override string ToString()
		{
			int num = versionNumber;
			return num.ToString();
		}

		private static Version[] buildVersions()
		{
			return new Version[30]
			{
				new Version(1, 10, 10, 8, 8, new ECBlocks(5, new ECB(1, 3))),
				new Version(2, 12, 12, 10, 10, new ECBlocks(7, new ECB(1, 5))),
				new Version(3, 14, 14, 12, 12, new ECBlocks(10, new ECB(1, 8))),
				new Version(4, 16, 16, 14, 14, new ECBlocks(12, new ECB(1, 12))),
				new Version(5, 18, 18, 16, 16, new ECBlocks(14, new ECB(1, 18))),
				new Version(6, 20, 20, 18, 18, new ECBlocks(18, new ECB(1, 22))),
				new Version(7, 22, 22, 20, 20, new ECBlocks(20, new ECB(1, 30))),
				new Version(8, 24, 24, 22, 22, new ECBlocks(24, new ECB(1, 36))),
				new Version(9, 26, 26, 24, 24, new ECBlocks(28, new ECB(1, 44))),
				new Version(10, 32, 32, 14, 14, new ECBlocks(36, new ECB(1, 62))),
				new Version(11, 36, 36, 16, 16, new ECBlocks(42, new ECB(1, 86))),
				new Version(12, 40, 40, 18, 18, new ECBlocks(48, new ECB(1, 114))),
				new Version(13, 44, 44, 20, 20, new ECBlocks(56, new ECB(1, 144))),
				new Version(14, 48, 48, 22, 22, new ECBlocks(68, new ECB(1, 174))),
				new Version(15, 52, 52, 24, 24, new ECBlocks(42, new ECB(2, 102))),
				new Version(16, 64, 64, 14, 14, new ECBlocks(56, new ECB(2, 140))),
				new Version(17, 72, 72, 16, 16, new ECBlocks(36, new ECB(4, 92))),
				new Version(18, 80, 80, 18, 18, new ECBlocks(48, new ECB(4, 114))),
				new Version(19, 88, 88, 20, 20, new ECBlocks(56, new ECB(4, 144))),
				new Version(20, 96, 96, 22, 22, new ECBlocks(68, new ECB(4, 174))),
				new Version(21, 104, 104, 24, 24, new ECBlocks(56, new ECB(6, 136))),
				new Version(22, 120, 120, 18, 18, new ECBlocks(68, new ECB(6, 175))),
				new Version(23, 132, 132, 20, 20, new ECBlocks(62, new ECB(8, 163))),
				new Version(24, 144, 144, 22, 22, new ECBlocks(62, new ECB(8, 156), new ECB(2, 155))),
				new Version(25, 8, 18, 6, 16, new ECBlocks(7, new ECB(1, 5))),
				new Version(26, 8, 32, 6, 14, new ECBlocks(11, new ECB(1, 10))),
				new Version(27, 12, 26, 10, 24, new ECBlocks(14, new ECB(1, 16))),
				new Version(28, 12, 36, 10, 16, new ECBlocks(18, new ECB(1, 22))),
				new Version(29, 16, 36, 14, 16, new ECBlocks(24, new ECB(1, 32))),
				new Version(30, 16, 48, 14, 22, new ECBlocks(28, new ECB(1, 49)))
			};
		}
	}
	public sealed class Detector
	{
		private sealed class ResultPointsAndTransitions
		{
			public ResultPoint From { get; private set; }

			public ResultPoint To { get; private set; }

			public int Transitions { get; private set; }

			public ResultPointsAndTransitions(ResultPoint from, ResultPoint to, int transitions)
			{
				From = from;
				To = to;
				Transitions = transitions;
			}

			public override string ToString()
			{
				return string.Concat(From, "/", To, "/", Transitions);
			}
		}

		private sealed class ResultPointsAndTransitionsComparator : IComparer<ResultPointsAndTransitions>
		{
			public int Compare(ResultPointsAndTransitions o1, ResultPointsAndTransitions o2)
			{
				return o1.Transitions - o2.Transitions;
			}
		}

		private readonly BitMatrix image;

		private readonly WhiteRectangleDetector rectangleDetector;

		public Detector(BitMatrix image)
		{
			this.image = image;
			rectangleDetector = WhiteRectangleDetector.Create(image);
		}

		public DetectorResult detect()
		{
			if (rectangleDetector == null)
			{
				return null;
			}
			ResultPoint[] array = rectangleDetector.detect();
			if (array == null)
			{
				return null;
			}
			ResultPoint resultPoint = array[0];
			ResultPoint resultPoint2 = array[1];
			ResultPoint resultPoint3 = array[2];
			ResultPoint resultPoint4 = array[3];
			List<ResultPointsAndTransitions> list = new List<ResultPointsAndTransitions>(4);
			list.Add(transitionsBetween(resultPoint, resultPoint2));
			list.Add(transitionsBetween(resultPoint, resultPoint3));
			list.Add(transitionsBetween(resultPoint2, resultPoint4));
			list.Add(transitionsBetween(resultPoint3, resultPoint4));
			list.Sort(new ResultPointsAndTransitionsComparator());
			ResultPointsAndTransitions resultPointsAndTransitions = list[0];
			ResultPointsAndTransitions resultPointsAndTransitions2 = list[1];
			Dictionary<ResultPoint, int> dictionary = new Dictionary<ResultPoint, int>();
			increment(dictionary, resultPointsAndTransitions.From);
			increment(dictionary, resultPointsAndTransitions.To);
			increment(dictionary, resultPointsAndTransitions2.From);
			increment(dictionary, resultPointsAndTransitions2.To);
			ResultPoint resultPoint5 = null;
			ResultPoint resultPoint6 = null;
			ResultPoint resultPoint7 = null;
			foreach (KeyValuePair<ResultPoint, int> item in dictionary)
			{
				ResultPoint key = item.Key;
				if (item.Value == 2)
				{
					resultPoint6 = key;
				}
				else if (resultPoint5 == null)
				{
					resultPoint5 = key;
				}
				else
				{
					resultPoint7 = key;
				}
			}
			if (resultPoint5 == null || resultPoint6 == null || resultPoint7 == null)
			{
				return null;
			}
			ResultPoint[] obj = new ResultPoint[3] { resultPoint5, resultPoint6, resultPoint7 };
			ResultPoint.orderBestPatterns(obj);
			ResultPoint resultPoint8 = obj[0];
			resultPoint6 = obj[1];
			ResultPoint resultPoint9 = obj[2];
			ResultPoint resultPoint10 = ((!dictionary.ContainsKey(resultPoint)) ? resultPoint : ((!dictionary.ContainsKey(resultPoint2)) ? resultPoint2 : (dictionary.ContainsKey(resultPoint3) ? resultPoint4 : resultPoint3)));
			int num = transitionsBetween(resultPoint9, resultPoint10).Transitions;
			int num2 = transitionsBetween(resultPoint8, resultPoint10).Transitions;
			if ((num & 1) == 1)
			{
				num++;
			}
			num += 2;
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			num2 += 2;
			ResultPoint resultPoint11;
			BitMatrix bitMatrix;
			if (4 * num >= 7 * num2 || 4 * num2 >= 7 * num)
			{
				resultPoint11 = correctTopRightRectangular(resultPoint6, resultPoint8, resultPoint9, resultPoint10, num, num2);
				if (resultPoint11 == null)
				{
					resultPoint11 = resultPoint10;
				}
				num = transitionsBetween(resultPoint9, resultPoint11).Transitions;
				num2 = transitionsBetween(resultPoint8, resultPoint11).Transitions;
				if ((num & 1) == 1)
				{
					num++;
				}
				if ((num2 & 1) == 1)
				{
					num2++;
				}
				bitMatrix = sampleGrid(image, resultPoint9, resultPoint6, resultPoint8, resultPoint11, num, num2);
			}
			else
			{
				int dimension = Math.Min(num2, num);
				resultPoint11 = correctTopRight(resultPoint6, resultPoint8, resultPoint9, resultPoint10, dimension);
				if (resultPoint11 == null)
				{
					resultPoint11 = resultPoint10;
				}
				int num3 = Math.Max(transitionsBetween(resultPoint9, resultPoint11).Transitions, transitionsBetween(resultPoint8, resultPoint11).Transitions);
				num3++;
				if ((num3 & 1) == 1)
				{
					num3++;
				}
				bitMatrix = sampleGrid(image, resultPoint9, resultPoint6, resultPoint8, resultPoint11, num3, num3);
			}
			if (bitMatrix == null)
			{
				return null;
			}
			return new DetectorResult(bitMatrix, new ResultPoint[4] { resultPoint9, resultPoint6, resultPoint8, resultPoint11 });
		}

		private ResultPoint correctTopRightRectangular(ResultPoint bottomLeft, ResultPoint bottomRight, ResultPoint topLeft, ResultPoint topRight, int dimensionTop, int dimensionRight)
		{
			float num = (float)distance(bottomLeft, bottomRight) / (float)dimensionTop;
			int num2 = distance(topLeft, topRight);
			if (num2 == 0)
			{
				return null;
			}
			float num3 = (topRight.X - topLeft.X) / (float)num2;
			float num4 = (topRight.Y - topLeft.Y) / (float)num2;
			ResultPoint resultPoint = new ResultPoint(topRight.X + num * num3, topRight.Y + num * num4);
			num = (float)distance(bottomLeft, topLeft) / (float)dimensionRight;
			num2 = distance(bottomRight, topRight);
			if (num2 == 0)
			{
				return null;
			}
			num3 = (topRight.X - bottomRight.X) / (float)num2;
			num4 = (topRight.Y - bottomRight.Y) / (float)num2;
			ResultPoint resultPoint2 = new ResultPoint(topRight.X + num * num3, topRight.Y + num * num4);
			if (!isValid(resultPoint))
			{
				if (isValid(resultPoint2))
				{
					return resultPoint2;
				}
				return null;
			}
			if (!isValid(resultPoint2))
			{
				return resultPoint;
			}
			int num5 = Math.Abs(dimensionTop - transitionsBetween(topLeft, resultPoint).Transitions) + Math.Abs(dimensionRight - transitionsBetween(bottomRight, resultPoint).Transitions);
			int num6 = Math.Abs(dimensionTop - transitionsBetween(topLeft, resultPoint2).Transitions) + Math.Abs(dimensionRight - transitionsBetween(bottomRight, resultPoint2).Transitions);
			if (num5 <= num6)
			{
				return resultPoint;
			}
			return resultPoint2;
		}

		private ResultPoint correctTopRight(ResultPoint bottomLeft, ResultPoint bottomRight, ResultPoint topLeft, ResultPoint topRight, int dimension)
		{
			float num = (float)distance(bottomLeft, bottomRight) / (float)dimension;
			int num2 = distance(topLeft, topRight);
			if (num2 == 0)
			{
				return null;
			}
			float num3 = (topRight.X - topLeft.X) / (float)num2;
			float num4 = (topRight.Y - topLeft.Y) / (float)num2;
			ResultPoint resultPoint = new ResultPoint(topRight.X + num * num3, topRight.Y + num * num4);
			num = (float)distance(bottomLeft, topLeft) / (float)dimension;
			num2 = distance(bottomRight, topRight);
			if (num2 == 0)
			{
				return null;
			}
			num3 = (topRight.X - bottomRight.X) / (float)num2;
			num4 = (topRight.Y - bottomRight.Y) / (float)num2;
			ResultPoint resultPoint2 = new ResultPoint(topRight.X + num * num3, topRight.Y + num * num4);
			if (!isValid(resultPoint))
			{
				if (isValid(resultPoint2))
				{
					return resultPoint2;
				}
				return null;
			}
			if (!isValid(resultPoint2))
			{
				return resultPoint;
			}
			int num5 = Math.Abs(transitionsBetween(topLeft, resultPoint).Transitions - transitionsBetween(bottomRight, resultPoint).Transitions);
			int num6 = Math.Abs(transitionsBetween(topLeft, resultPoint2).Transitions - transitionsBetween(bottomRight, resultPoint2).Transitions);
			if (num5 > num6)
			{
				return resultPoint2;
			}
			return resultPoint;
		}

		private bool isValid(ResultPoint p)
		{
			if (p.X >= 0f && p.X < (float)image.Width && p.Y > 0f)
			{
				return p.Y < (float)image.Height;
			}
			return false;
		}

		private static int distance(ResultPoint a, ResultPoint b)
		{
			return MathUtils.round(ResultPoint.distance(a, b));
		}

		private static void increment(IDictionary<ResultPoint, int> table, ResultPoint key)
		{
			if (table.ContainsKey(key))
			{
				table[key]++;
			}
			else
			{
				table[key] = 1;
			}
		}

		private static BitMatrix sampleGrid(BitMatrix image, ResultPoint topLeft, ResultPoint bottomLeft, ResultPoint bottomRight, ResultPoint topRight, int dimensionX, int dimensionY)
		{
			return GridSampler.Instance.sampleGrid(image, dimensionX, dimensionY, 0.5f, 0.5f, (float)dimensionX - 0.5f, 0.5f, (float)dimensionX - 0.5f, (float)dimensionY - 0.5f, 0.5f, (float)dimensionY - 0.5f, topLeft.X, topLeft.Y, topRight.X, topRight.Y, bottomRight.X, bottomRight.Y, bottomLeft.X, bottomLeft.Y);
		}

		private ResultPointsAndTransitions transitionsBetween(ResultPoint from, ResultPoint to)
		{
			int num = (int)from.X;
			int num2 = (int)from.Y;
			int num3 = (int)to.X;
			int num4 = (int)to.Y;
			bool flag = Math.Abs(num4 - num2) > Math.Abs(num3 - num);
			if (flag)
			{
				int num5 = num;
				num = num2;
				num2 = num5;
				int num6 = num3;
				num3 = num4;
				num4 = num6;
			}
			int num7 = Math.Abs(num3 - num);
			int num8 = Math.Abs(num4 - num2);
			int num9 = -num7 >> 1;
			int num10 = ((num2 < num4) ? 1 : (-1));
			int num11 = ((num < num3) ? 1 : (-1));
			int num12 = 0;
			bool flag2 = image[flag ? num2 : num, flag ? num : num2];
			int i = num;
			int num13 = num2;
			for (; i != num3; i += num11)
			{
				bool flag3 = image[flag ? num13 : i, flag ? i : num13];
				if (flag3 != flag2)
				{
					num12++;
					flag2 = flag3;
				}
				num9 += num8;
				if (num9 > 0)
				{
					if (num13 == num4)
					{
						break;
					}
					num13 += num10;
					num9 -= num7;
				}
			}
			return new ResultPointsAndTransitions(from, to, num12);
		}
	}
}
namespace ZXing.Common
{
	public sealed class BitArray
	{
		private int[] bits;

		private int size;

		private static readonly int[] _lookup = new int[37]
		{
			32, 0, 1, 26, 2, 23, 27, 0, 3, 16,
			24, 30, 28, 11, 0, 13, 4, 7, 17, 0,
			25, 22, 31, 15, 29, 10, 12, 6, 0, 21,
			14, 9, 5, 20, 8, 19, 18
		};

		public int Size => size;

		public int SizeInBytes => size + 7 >> 3;

		public bool this[int i]
		{
			get
			{
				return (bits[i >> 5] & (1 << i)) != 0;
			}
			set
			{
				if (value)
				{
					bits[i >> 5] |= 1 << i;
				}
			}
		}

		public int[] Array => bits;

		public BitArray()
		{
			size = 0;
			bits = new int[1];
		}

		public BitArray(int size)
		{
			if (size < 1)
			{
				throw new ArgumentException("size must be at least 1");
			}
			this.size = size;
			bits = makeArray(size);
		}

		private BitArray(int[] bits, int size)
		{
			this.bits = bits;
			this.size = size;
		}

		private void ensureCapacity(int size)
		{
			if (size > bits.Length << 5)
			{
				int[] destinationArray = makeArray(size);
				System.Array.Copy(bits, 0, destinationArray, 0, bits.Length);
				bits = destinationArray;
			}
		}

		public void flip(int i)
		{
			bits[i >> 5] ^= 1 << i;
		}

		private static int numberOfTrailingZeros(int num)
		{
			int num2 = (-num & num) % 37;
			if (num2 < 0)
			{
				num2 *= -1;
			}
			return _lookup[num2];
		}

		public int getNextSet(int from)
		{
			if (from >= size)
			{
				return size;
			}
			int num = from >> 5;
			int num2 = bits[num];
			for (num2 &= ~((1 << from) - 1); num2 == 0; num2 = bits[num])
			{
				if (++num == bits.Length)
				{
					return size;
				}
			}
			int num3 = (num << 5) + numberOfTrailingZeros(num2);
			if (num3 <= size)
			{
				return num3;
			}
			return size;
		}

		public int getNextUnset(int from)
		{
			if (from >= size)
			{
				return size;
			}
			int num = from >> 5;
			int num2 = ~bits[num];
			for (num2 &= ~((1 << from) - 1); num2 == 0; num2 = ~bits[num])
			{
				if (++num == bits.Length)
				{
					return size;
				}
			}
			int num3 = (num << 5) + numberOfTrailingZeros(num2);
			if (num3 <= size)
			{
				return num3;
			}
			return size;
		}

		public void setBulk(int i, int newBits)
		{
			bits[i >> 5] = newBits;
		}

		public void setRange(int start, int end)
		{
			if (end < start || start < 0 || end > size)
			{
				throw new ArgumentException();
			}
			if (end != start)
			{
				end--;
				int num = start >> 5;
				int num2 = end >> 5;
				for (int i = num; i <= num2; i++)
				{
					int num3 = ((i <= num) ? (start & 0x1F) : 0);
					int num4 = ((i < num2) ? 31 : (end & 0x1F));
					int num5 = (2 << num4) - (1 << num3);
					bits[i] |= num5;
				}
			}
		}

		public void clear()
		{
			int num = bits.Length;
			for (int i = 0; i < num; i++)
			{
				bits[i] = 0;
			}
		}

		public bool isRange(int start, int end, bool value)
		{
			if (end < start || start < 0 || end > size)
			{
				throw new ArgumentException();
			}
			if (end == start)
			{
				return true;
			}
			end--;
			int num = start >> 5;
			int num2 = end >> 5;
			for (int i = num; i <= num2; i++)
			{
				int num3 = ((i <= num) ? (start & 0x1F) : 0);
				int num4 = ((i < num2) ? 31 : (end & 0x1F));
				int num5 = (2 << num4) - (1 << num3);
				if ((bits[i] & num5) != (value ? num5 : 0))
				{
					return false;
				}
			}
			return true;
		}

		public void appendBit(bool bit)
		{
			ensureCapacity(size + 1);
			if (bit)
			{
				bits[size >> 5] |= 1 << size;
			}
			size++;
		}

		public void appendBits(int value, int numBits)
		{
			if (numBits < 0 || numBits > 32)
			{
				throw new ArgumentException("Num bits must be between 0 and 32");
			}
			ensureCapacity(size + numBits);
			for (int num = numBits; num > 0; num--)
			{
				appendBit(((value >> num - 1) & 1) == 1);
			}
		}

		public void appendBitArray(BitArray other)
		{
			int num = other.size;
			ensureCapacity(size + num);
			for (int i = 0; i < num; i++)
			{
				appendBit(other[i]);
			}
		}

		public void xor(BitArray other)
		{
			if (size != other.size)
			{
				throw new ArgumentException("Sizes don't match");
			}
			for (int i = 0; i < bits.Length; i++)
			{
				bits[i] ^= other.bits[i];
			}
		}

		public void toBytes(int bitOffset, byte[] array, int offset, int numBytes)
		{
			for (int i = 0; i < numBytes; i++)
			{
				int num = 0;
				for (int j = 0; j < 8; j++)
				{
					if (this[bitOffset])
					{
						num |= 1 << 7 - j;
					}
					bitOffset++;
				}
				array[offset + i] = (byte)num;
			}
		}

		public void reverse()
		{
			int[] array = new int[bits.Length];
			int num = size - 1 >> 5;
			int num2 = num + 1;
			for (int i = 0; i < num2; i++)
			{
				long num3 = bits[i];
				num3 = ((num3 >> 1) & 0x55555555) | ((num3 & 0x55555555) << 1);
				num3 = ((num3 >> 2) & 0x33333333) | ((num3 & 0x33333333) << 2);
				num3 = ((num3 >> 4) & 0xF0F0F0F) | ((num3 & 0xF0F0F0F) << 4);
				num3 = ((num3 >> 8) & 0xFF00FF) | ((num3 & 0xFF00FF) << 8);
				num3 = ((num3 >> 16) & 0xFFFF) | ((num3 & 0xFFFF) << 16);
				array[num - i] = (int)num3;
			}
			if (size != num2 * 32)
			{
				int num4 = num2 * 32 - size;
				int num5 = array[0] >>> num4;
				for (int j = 1; j < num2; j++)
				{
					int num6 = array[j];
					num5 |= num6 << 32 - num4;
					array[j - 1] = num5;
					num5 = num6 >>> num4;
				}
				array[num2 - 1] = num5;
			}
			bits = array;
		}

		private static int[] makeArray(int size)
		{
			return new int[size + 31 >> 5];
		}

		public override bool Equals(object o)
		{
			if (!(o is BitArray bitArray))
			{
				return false;
			}
			if (size != bitArray.size)
			{
				return false;
			}
			for (int i = 0; i < bits.Length; i++)
			{
				if (bits[i] != bitArray.bits[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			int num = size;
			int[] array = bits;
			foreach (int num2 in array)
			{
				num = 31 * num + num2.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				if ((i & 7) == 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(this[i] ? 'X' : '.');
			}
			return stringBuilder.ToString();
		}

		public object Clone()
		{
			return new BitArray((int[])bits.Clone(), size);
		}
	}
	public sealed class BitMatrix
	{
		private readonly int width;

		private readonly int height;

		private readonly int rowSize;

		private readonly int[] bits;

		public int Width => width;

		public int Height => height;

		public int Dimension
		{
			get
			{
				if (width != height)
				{
					throw new ArgumentException("Can't call Dimension on a non-square matrix");
				}
				return width;
			}
		}

		public int RowSize => rowSize;

		public bool this[int x, int y]
		{
			get
			{
				int num = y * rowSize + (x >> 5);
				return ((bits[num] >>> x) & 1) != 0;
			}
			set
			{
				if (value)
				{
					int num = y * rowSize + (x >> 5);
					bits[num] |= 1 << x;
				}
				else
				{
					int num2 = y * rowSize + x / 32;
					bits[num2] &= ~(1 << x);
				}
			}
		}

		public BitMatrix(int dimension)
			: this(dimension, dimension)
		{
		}

		public BitMatrix(int width, int height)
		{
			if (width < 1 || height < 1)
			{
				throw new ArgumentException("Both dimensions must be greater than 0");
			}
			this.width = width;
			this.height = height;
			rowSize = width + 31 >> 5;
			bits = new int[rowSize * height];
		}

		internal BitMatrix(int width, int height, int rowSize, int[] bits)
		{
			this.width = width;
			this.height = height;
			this.rowSize = rowSize;
			this.bits = bits;
		}

		internal BitMatrix(int width, int height, int[] bits)
		{
			this.width = width;
			this.height = height;
			rowSize = width + 31 >> 5;
			this.bits = bits;
		}

		public static BitMatrix parse(bool[][] image)
		{
			int num = image.Length;
			int num2 = image[0].Length;
			BitMatrix bitMatrix = new BitMatrix(num2, num);
			for (int i = 0; i < num; i++)
			{
				bool[] array = image[i];
				for (int j = 0; j < num2; j++)
				{
					bitMatrix[j, i] = array[j];
				}
			}
			return bitMatrix;
		}

		public static BitMatrix parse(string stringRepresentation, string setString, string unsetString)
		{
			if (stringRepresentation == null)
			{
				throw new ArgumentException();
			}
			bool[] array = new bool[stringRepresentation.Length];
			int num = 0;
			int num2 = 0;
			int num3 = -1;
			int num4 = 0;
			int num5 = 0;
			while (num5 < stringRepresentation.Length)
			{
				if (stringRepresentation.Substring(num5, 1).Equals("\n") || stringRepresentation.Substring(num5, 1).Equals("\r"))
				{
					if (num > num2)
					{
						if (num3 == -1)
						{
							num3 = num - num2;
						}
						else if (num - num2 != num3)
						{
							throw new ArgumentException("row lengths do not match");
						}
						num2 = num;
						num4++;
					}
					num5++;
				}
				else if (stringRepresentation.Substring(num5, setString.Length).Equals(setString))
				{
					num5 += setString.Length;
					array[num] = true;
					num++;
				}
				else
				{
					if (!stringRepresentation.Substring(num5, unsetString.Length).Equals(unsetString))
					{
						throw new ArgumentException("illegal character encountered: " + stringRepresentation.Substring(num5));
					}
					num5 += unsetString.Length;
					array[num] = false;
					num++;
				}
			}
			if (num > num2)
			{
				if (num3 == -1)
				{
					num3 = num - num2;
				}
				else if (num - num2 != num3)
				{
					throw new ArgumentException("row lengths do not match");
				}
				num4++;
			}
			BitMatrix bitMatrix = new BitMatrix(num3, num4);
			for (int i = 0; i < num; i++)
			{
				if (array[i])
				{
					bitMatrix[i % num3, i / num3] = true;
				}
			}
			return bitMatrix;
		}

		public void flip(int x, int y)
		{
			int num = y * rowSize + (x >> 5);
			bits[num] ^= 1 << x;
		}

		public void flipWhen(Func<int, int, bool> shouldBeFlipped)
		{
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (shouldBeFlipped(i, j))
					{
						int num = i * rowSize + (j >> 5);
						bits[num] ^= 1 << j;
					}
				}
			}
		}

		public void xor(BitMatrix mask)
		{
			if (width != mask.Width || height != mask.Height || rowSize != mask.RowSize)
			{
				throw new ArgumentException("input matrix dimensions do not match");
			}
			BitArray row = new BitArray(width / 32 + 1);
			for (int i = 0; i < height; i++)
			{
				int num = i * rowSize;
				int[] array = mask.getRow(i, row).Array;
				for (int j = 0; j < rowSize; j++)
				{
					bits[num + j] ^= array[j];
				}
			}
		}

		public void clear()
		{
			int num = bits.Length;
			for (int i = 0; i < num; i++)
			{
				bits[i] = 0;
			}
		}

		public void setRegion(int left, int top, int width, int height)
		{
			if (top < 0 || left < 0)
			{
				throw new ArgumentException("Left and top must be nonnegative");
			}
			if (height < 1 || width < 1)
			{
				throw new ArgumentException("Height and width must be at least 1");
			}
			int num = left + width;
			int num2 = top + height;
			if (num2 > this.height || num > this.width)
			{
				throw new ArgumentException("The region must fit inside the matrix");
			}
			for (int i = top; i < num2; i++)
			{
				int num3 = i * rowSize;
				for (int j = left; j < num; j++)
				{
					bits[num3 + (j >> 5)] |= 1 << j;
				}
			}
		}

		public BitArray getRow(int y, BitArray row)
		{
			if (row == null || row.Size < width)
			{
				row = new BitArray(width);
			}
			else
			{
				row.clear();
			}
			int num = y * rowSize;
			for (int i = 0; i < rowSize; i++)
			{
				row.setBulk(i << 5, bits[num + i]);
			}
			return row;
		}

		public void setRow(int y, BitArray row)
		{
			Array.Copy(row.Array, 0, bits, y * rowSize, rowSize);
		}

		public void rotate180()
		{
			int size = Width;
			int num = Height;
			BitArray bitArray = new BitArray(size);
			BitArray bitArray2 = new BitArray(size);
			for (int i = 0; i < (num + 1) / 2; i++)
			{
				bitArray = getRow(i, bitArray);
				bitArray2 = getRow(num - 1 - i, bitArray2);
				bitArray.reverse();
				bitArray2.reverse();
				setRow(i, bitArray2);
				setRow(num - 1 - i, bitArray);
			}
		}

		public int[] getEnclosingRectangle()
		{
			int num = width;
			int num2 = height;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < rowSize; j++)
				{
					int num5 = bits[i * rowSize + j];
					if (num5 == 0)
					{
						continue;
					}
					if (i < num2)
					{
						num2 = i;
					}
					if (i > num4)
					{
						num4 = i;
					}
					if (j * 32 < num)
					{
						int k;
						for (k = 0; num5 << 31 - k == 0; k++)
						{
						}
						if (j * 32 + k < num)
						{
							num = j * 32 + k;
						}
					}
					if (j * 32 + 31 > num3)
					{
						int num6 = 31;
						while (num5 >>> num6 == 0)
						{
							num6--;
						}
						if (j * 32 + num6 > num3)
						{
							num3 = j * 32 + num6;
						}
					}
				}
			}
			if (num3 < num || num4 < num2)
			{
				return null;
			}
			return new int[4]
			{
				num,
				num2,
				num3 - num + 1,
				num4 - num2 + 1
			};
		}

		public int[] getTopLeftOnBit()
		{
			int i;
			for (i = 0; i < bits.Length && bits[i] == 0; i++)
			{
			}
			if (i == bits.Length)
			{
				return null;
			}
			int num = i / rowSize;
			int num2 = i % rowSize << 5;
			int num3 = bits[i];
			int j;
			for (j = 0; num3 << 31 - j == 0; j++)
			{
			}
			num2 += j;
			return new int[2] { num2, num };
		}

		public int[] getBottomRightOnBit()
		{
			int num = bits.Length - 1;
			while (num >= 0 && bits[num] == 0)
			{
				num--;
			}
			if (num < 0)
			{
				return null;
			}
			int num2 = num / rowSize;
			int num3 = num % rowSize << 5;
			int num4 = bits[num];
			int num5 = 31;
			while (num4 >>> num5 == 0)
			{
				num5--;
			}
			num3 += num5;
			return new int[2] { num3, num2 };
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BitMatrix))
			{
				return false;
			}
			BitMatrix bitMatrix = (BitMatrix)obj;
			if (width != bitMatrix.width || height != bitMatrix.height || rowSize != bitMatrix.rowSize || bits.Length != bitMatrix.bits.Length)
			{
				return false;
			}
			for (int i = 0; i < bits.Length; i++)
			{
				if (bits[i] != bitMatrix.bits[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			int num = width;
			num = 31 * num + width;
			num = 31 * num + height;
			num = 31 * num + rowSize;
			int[] array = bits;
			foreach (int num2 in array)
			{
				num = 31 * num + num2.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			return ToString("X ", "  ", Environment.NewLine);
		}

		public string ToString(string setString, string unsetString)
		{
			return buildToString(setString, unsetString, Environment.NewLine);
		}

		public string ToString(string setString, string unsetString, string lineSeparator)
		{
			return buildToString(setString, unsetString, lineSeparator);
		}

		private string buildToString(string setString, string unsetString, string lineSeparator)
		{
			StringBuilder stringBuilder = new StringBuilder(height * (width + 1));
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					stringBuilder.Append(this[j, i] ? setString : unsetString);
				}
				stringBuilder.Append(lineSeparator);
			}
			return stringBuilder.ToString();
		}

		public object Clone()
		{
			return new BitMatrix(width, height, rowSize, (int[])bits.Clone());
		}
	}
	public sealed class BitSource
	{
		private readonly byte[] bytes;

		private int byteOffset;

		private int bitOffset;

		public int BitOffset => bitOffset;

		public int ByteOffset => byteOffset;

		public BitSource(byte[] bytes)
		{
			this.bytes = bytes;
		}

		public int readBits(int numBits)
		{
			if (numBits < 1 || numBits > 32 || numBits > available())
			{
				throw new ArgumentException(numBits.ToString(), "numBits");
			}
			int num = 0;
			if (bitOffset > 0)
			{
				int num2 = 8 - bitOffset;
				int num3 = ((numBits < num2) ? numBits : num2);
				int num4 = num2 - num3;
				int num5 = 255 >> 8 - num3 << num4;
				num = (bytes[byteOffset] & num5) >> num4;
				numBits -= num3;
				bitOffset += num3;
				if (bitOffset == 8)
				{
					bitOffset = 0;
					byteOffset++;
				}
			}
			if (numBits > 0)
			{
				while (numBits >= 8)
				{
					num = (num << 8) | (bytes[byteOffset] & 0xFF);
					byteOffset++;
					numBits -= 8;
				}
				if (numBits > 0)
				{
					int num6 = 8 - numBits;
					int num7 = 255 >> num6 << num6;
					num = (num << numBits) | ((bytes[byteOffset] & num7) >> num6);
					bitOffset += numBits;
				}
			}
			return num;
		}

		public int available()
		{
			return 8 * (bytes.Length - byteOffset) - bitOffset;
		}
	}
	public sealed class CharacterSetECI : ECI
	{
		internal static readonly IDictionary<int, CharacterSetECI> VALUE_TO_ECI;

		internal static readonly IDictionary<string, CharacterSetECI> NAME_TO_ECI;

		private readonly string encodingName;

		public string EncodingName => encodingName;

		static CharacterSetECI()
		{
			VALUE_TO_ECI = new Dictionary<int, CharacterSetECI>();
			NAME_TO_ECI = new Dictionary<string, CharacterSetECI>();
			addCharacterSet(0, "CP437");
			addCharacterSet(1, new string[2] { "ISO-8859-1", "ISO8859_1" });
			addCharacterSet(2, "CP437");
			addCharacterSet(3, new string[2] { "ISO-8859-1", "ISO8859_1" });
			addCharacterSet(4, new string[2] { "ISO-8859-2", "ISO8859_2" });
			addCharacterSet(5, new string[2] { "ISO-8859-3", "ISO8859_3" });
			addCharacterSet(6, new string[2] { "ISO-8859-4", "ISO8859_4" });
			addCharacterSet(7, new string[2] { "ISO-8859-5", "ISO8859_5" });
			addCharacterSet(8, new string[2] { "ISO-8859-6", "ISO8859_6" });
			addCharacterSet(9, new string[2] { "ISO-8859-7", "ISO8859_7" });
			addCharacterSet(10, new string[2] { "ISO-8859-8", "ISO8859_8" });
			addCharacterSet(11, new string[2] { "ISO-8859-9", "ISO8859_9" });
			addCharacterSet(12, new string[3] { "ISO-8859-4", "ISO-8859-10", "ISO8859_10" });
			addCharacterSet(13, new string[2] { "ISO-8859-11", "ISO8859_11" });
			addCharacterSet(15, new string[2] { "ISO-8859-13", "ISO8859_13" });
			addCharacterSet(16, new string[3] { "ISO-8859-1", "ISO-8859-14", "ISO8859_14" });
			addCharacterSet(17, new string[2] { "ISO-8859-15", "ISO8859_15" });
			addCharacterSet(18, new string[3] { "ISO-8859-3", "ISO-8859-16", "ISO8859_16" });
			addCharacterSet(20, new string[2] { "SJIS", "Shift_JIS" });
			addCharacterSet(21, new string[2] { "WINDOWS-1250", "CP1250" });
			addCharacterSet(22, new string[2] { "WINDOWS-1251", "CP1251" });
			addCharacterSet(23, new string[2] { "WINDOWS-1252", "CP1252" });
			addCharacterSet(24, new string[2] { "WINDOWS-1256", "CP1256" });
			addCharacterSet(25, new string[2] { "UTF-16BE", "UNICODEBIG" });
			addCharacterSet(26, new string[2] { "UTF-8", "UTF8" });
			addCharacterSet(27, "US-ASCII");
			addCharacterSet(170, "US-ASCII");
			addCharacterSet(28, "BIG5");
			addCharacterSet(29, new string[4] { "GB18030", "GB2312", "EUC_CN", "GBK" });
			addCharacterSet(30, new string[2] { "EUC-KR", "EUC_KR" });
		}

		private CharacterSetECI(int value, string encodingName)
			: base(value)
		{
			this.encodingName = encodingName;
		}

		private static void addCharacterSet(int value, string encodingName)
		{
			CharacterSetECI value2 = new CharacterSetECI(value, encodingName);
			VALUE_TO_ECI[value] = value2;
			NAME_TO_ECI[encodingName] = value2;
		}

		private static void addCharacterSet(int value, string[] encodingNames)
		{
			CharacterSetECI value2 = new CharacterSetECI(value, encodingNames[0]);
			VALUE_TO_ECI[value] = value2;
			foreach (string key in encodingNames)
			{
				NAME_TO_ECI[key] = value2;
			}
		}

		public static CharacterSetECI getCharacterSetECIByValue(int value)
		{
			if (value < 0 || value >= 900)
			{
				return null;
			}
			return VALUE_TO_ECI[value];
		}

		public static CharacterSetECI getCharacterSetECIByName(string name)
		{
			return NAME_TO_ECI[name.ToUpper()];
		}
	}
	public sealed class DecoderResult
	{
		public byte[] RawBytes { get; private set; }

		public int NumBits { get; private set; }

		public string Text { get; private set; }

		public IList<byte[]> ByteSegments { get; private set; }

		public string ECLevel { get; private set; }

		public bool StructuredAppend
		{
			get
			{
				if (StructuredAppendParity >= 0)
				{
					return StructuredAppendSequenceNumber >= 0;
				}
				return false;
			}
		}

		public int ErrorsCorrected { get; set; }

		public int StructuredAppendSequenceNumber { get; private set; }

		public int Erasures { get; set; }

		public int StructuredAppendParity { get; private set; }

		public object Other { get; set; }

		public DecoderResult(byte[] rawBytes, string text, IList<byte[]> byteSegments, string ecLevel)
			: this(rawBytes, text, byteSegments, ecLevel, -1, -1)
		{
		}

		public DecoderResult(byte[] rawBytes, string text, IList<byte[]> byteSegments, string ecLevel, int saSequence, int saParity)
			: this(rawBytes, (rawBytes != null) ? (8 * rawBytes.Length) : 0, text, byteSegments, ecLevel, saSequence, saParity)
		{
		}

		public DecoderResult(byte[] rawBytes, int numBits, string text, IList<byte[]> byteSegments, string ecLevel)
			: this(rawBytes, numBits, text, byteSegments, ecLevel, -1, -1)
		{
		}

		public DecoderResult(byte[] rawBytes, int numBits, string text, IList<byte[]> byteSegments, string ecLevel, int saSequence, int saParity)
		{
			if (rawBytes == null && text == null)
			{
				throw new ArgumentException();
			}
			RawBytes = rawBytes;
			NumBits = numBits;
			Text = text;
			ByteSegments = byteSegments;
			ECLevel = ecLevel;
			StructuredAppendParity = saParity;
			StructuredAppendSequenceNumber = saSequence;
		}
	}
	[Serializable]
	public class DecodingOptions
	{
		[Serializable]
		private class ChangeNotifyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
		{
			private readonly IDictionary<TKey, TValue> values;

			public ICollection<TKey> Keys => values.Keys;

			public ICollection<TValue> Values => values.Values;

			public TValue this[TKey key]
			{
				get
				{
					return values[key];
				}
				set
				{
					values[key] = value;
					OnValueChanged();
				}
			}

			public int Count => values.Count;

			public bool IsReadOnly => values.IsReadOnly;

			public event Action<object, EventArgs> ValueChanged;

			public ChangeNotifyDictionary()
			{
				values = new Dictionary<TKey, TValue>();
			}

			private void OnValueChanged()
			{
				if (this.ValueChanged != null)
				{
					this.ValueChanged(this, EventArgs.Empty);
				}
			}

			public void Add(TKey key, TValue value)
			{
				values.Add(key, value);
				OnValueChanged();
			}

			public bool ContainsKey(TKey key)
			{
				return values.ContainsKey(key);
			}

			public bool Remove(TKey key)
			{
				bool result = values.Remove(key);
				OnValueChanged();
				return result;
			}

			public bool TryGetValue(TKey key, out TValue value)
			{
				return values.TryGetValue(key, out value);
			}

			public void Add(KeyValuePair<TKey, TValue> item)
			{
				values.Add(item);
				OnValueChanged();
			}

			public void Clear()
			{
				values.Clear();
				OnValueChanged();
			}

			public bool Contains(KeyValuePair<TKey, TValue> item)
			{
				return values.Contains(item);
			}

			public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
				values.CopyTo(array, arrayIndex);
			}

			public bool Remove(KeyValuePair<TKey, TValue> item)
			{
				bool result = values.Remove(item);
				OnValueChanged();
				return result;
			}

			public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return values.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)values).GetEnumerator();
			}
		}

		[Browsable(false)]
		public IDictionary<DecodeHintType, object> Hints { get; private set; }

		public bool TryHarder
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.TRY_HARDER))
				{
					return (bool)Hints[DecodeHintType.TRY_HARDER];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.TRY_HARDER] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.TRY_HARDER))
				{
					Hints.Remove(DecodeHintType.TRY_HARDER);
				}
			}
		}

		public bool PureBarcode
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.PURE_BARCODE))
				{
					return (bool)Hints[DecodeHintType.PURE_BARCODE];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.PURE_BARCODE] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.PURE_BARCODE))
				{
					Hints.Remove(DecodeHintType.PURE_BARCODE);
				}
			}
		}

		public string CharacterSet
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.CHARACTER_SET))
				{
					return (string)Hints[DecodeHintType.CHARACTER_SET];
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					Hints[DecodeHintType.CHARACTER_SET] = value;
				}
				else if (Hints.ContainsKey(DecodeHintType.CHARACTER_SET))
				{
					Hints.Remove(DecodeHintType.CHARACTER_SET);
				}
			}
		}

		public IList<BarcodeFormat> PossibleFormats
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.POSSIBLE_FORMATS))
				{
					return (IList<BarcodeFormat>)Hints[DecodeHintType.POSSIBLE_FORMATS];
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					Hints[DecodeHintType.POSSIBLE_FORMATS] = value;
				}
				else if (Hints.ContainsKey(DecodeHintType.POSSIBLE_FORMATS))
				{
					Hints.Remove(DecodeHintType.POSSIBLE_FORMATS);
				}
			}
		}

		public bool UseCode39ExtendedMode
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.USE_CODE_39_EXTENDED_MODE))
				{
					return (bool)Hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE];
				}
				return false;
			}
			set
			{
				Hints[DecodeHintType.USE_CODE_39_EXTENDED_MODE] = value;
			}
		}

		public bool UseCode39RelaxedExtendedMode
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE))
				{
					return (bool)Hints[DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE))
				{
					Hints.Remove(DecodeHintType.RELAXED_CODE_39_EXTENDED_MODE);
				}
			}
		}

		public bool AssumeCode39CheckDigit
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT))
				{
					return (bool)Hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT))
				{
					Hints.Remove(DecodeHintType.ASSUME_CODE_39_CHECK_DIGIT);
				}
			}
		}

		public bool ReturnCodabarStartEnd
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.RETURN_CODABAR_START_END))
				{
					return (bool)Hints[DecodeHintType.RETURN_CODABAR_START_END];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.RETURN_CODABAR_START_END] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.RETURN_CODABAR_START_END))
				{
					Hints.Remove(DecodeHintType.RETURN_CODABAR_START_END);
				}
			}
		}

		public bool AssumeGS1
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.ASSUME_GS1))
				{
					return (bool)Hints[DecodeHintType.ASSUME_GS1];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.ASSUME_GS1] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.ASSUME_GS1))
				{
					Hints.Remove(DecodeHintType.ASSUME_GS1);
				}
			}
		}

		public bool AssumeMSICheckDigit
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.ASSUME_MSI_CHECK_DIGIT))
				{
					return (bool)Hints[DecodeHintType.ASSUME_MSI_CHECK_DIGIT];
				}
				return false;
			}
			set
			{
				if (value)
				{
					Hints[DecodeHintType.ASSUME_MSI_CHECK_DIGIT] = true;
				}
				else if (Hints.ContainsKey(DecodeHintType.ASSUME_MSI_CHECK_DIGIT))
				{
					Hints.Remove(DecodeHintType.ASSUME_MSI_CHECK_DIGIT);
				}
			}
		}

		public int[] AllowedLengths
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.ALLOWED_LENGTHS))
				{
					return (int[])Hints[DecodeHintType.ALLOWED_LENGTHS];
				}
				return null;
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					Hints[DecodeHintType.ALLOWED_LENGTHS] = value;
				}
				else if (Hints.ContainsKey(DecodeHintType.ALLOWED_LENGTHS))
				{
					Hints.Remove(DecodeHintType.ALLOWED_LENGTHS);
				}
			}
		}

		public int[] AllowedEANExtensions
		{
			get
			{
				if (Hints.ContainsKey(DecodeHintType.ALLOWED_EAN_EXTENSIONS))
				{
					return (int[])Hints[DecodeHintType.ALLOWED_EAN_EXTENSIONS];
				}
				return null;
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					Hints[DecodeHintType.ALLOWED_EAN_EXTENSIONS] = value;
				}
				else if (Hints.ContainsKey(DecodeHintType.ALLOWED_EAN_EXTENSIONS))
				{
					Hints.Remove(DecodeHintType.ALLOWED_EAN_EXTENSIONS);
				}
			}
		}

		[field: NonSerialized]
		public event Action<object, EventArgs> ValueChanged;

		public DecodingOptions()
		{
			ChangeNotifyDictionary<DecodeHintType, object> changeNotifyDictionary = (ChangeNotifyDictionary<DecodeHintType, object>)(Hints = new ChangeNotifyDictionary<DecodeHintType, object>());
			UseCode39ExtendedMode = true;
			UseCode39RelaxedExtendedMode = true;
			changeNotifyDictionary.ValueChanged += delegate
			{
				if (this.ValueChanged != null)
				{
					this.ValueChanged(this, EventArgs.Empty);
				}
			};
		}
	}
	public sealed class DefaultGridSampler : GridSampler
	{
		public override BitMatrix sampleGrid(BitMatrix image, int dimensionX, int dimensionY, float p1ToX, float p1ToY, float p2ToX, float p2ToY, float p3ToX, float p3ToY, float p4ToX, float p4ToY, float p1FromX, float p1FromY, float p2FromX, float p2FromY, float p3FromX, float p3FromY, float p4FromX, float p4FromY)
		{
			PerspectiveTransform transform = PerspectiveTransform.quadrilateralToQuadrilateral(p1ToX, p1ToY, p2ToX, p2ToY, p3ToX, p3ToY, p4ToX, p4ToY, p1FromX, p1FromY, p2FromX, p2FromY, p3FromX, p3FromY, p4FromX, p4FromY);
			return sampleGrid(image, dimensionX, dimensionY, transform);
		}

		public override BitMatrix sampleGrid(BitMatrix image, int dimensionX, int dimensionY, PerspectiveTransform transform)
		{
			if (dimensionX <= 0 || dimensionY <= 0)
			{
				return null;
			}
			BitMatrix bitMatrix = new BitMatrix(dimensionX, dimensionY);
			float[] array = new float[dimensionX << 1];
			for (int i = 0; i < dimensionY; i++)
			{
				int num = array.Length;
				float num2 = (float)i + 0.5f;
				for (int j = 0; j < num; j += 2)
				{
					array[j] = (float)(j >> 1) + 0.5f;
					array[j + 1] = num2;
				}
				transform.transformPoints(array);
				if (!GridSampler.checkAndNudgePoints(image, array))
				{
					return null;
				}
				try
				{
					int width = image.Width;
					int height = image.Height;
					for (int k = 0; k < num; k += 2)
					{
						int num3 = (int)array[k];
						int num4 = (int)array[k + 1];
						if (num3 < 0 || num3 >= width || num4 < 0 || num4 >= height)
						{
							return null;
						}
						bitMatrix[k >> 1, i] = image[num3, num4];
					}
				}
				catch (IndexOutOfRangeException)
				{
					return null;
				}
			}
			return bitMatrix;
		}
	}
	public class DetectorResult
	{
		public BitMatrix Bits { get; private set; }

		public ResultPoint[] Points { get; private set; }

		public DetectorResult(BitMatrix bits, ResultPoint[] points)
		{
			Bits = bits;
			Points = points;
		}
	}
	public abstract class ECI
	{
		public virtual int Value { get; private set; }

		internal ECI(int val)
		{
			Value = val;
		}

		public static ECI getECIByValue(int val)
		{
			if (val < 0 || val > 999999)
			{
				throw new ArgumentException("Bad ECI value: " + val);
			}
			if (val < 900)
			{
				return CharacterSetECI.getCharacterSetECIByValue(val);
			}
			return null;
		}
	}
	[Serializable]
	public class EncodingOptions
	{
		[Browsable(false)]
		public IDictionary<EncodeHintType, object> Hints { get; private set; }

		public int Height
		{
			get
			{
				if (Hints.ContainsKey(EncodeHintType.HEIGHT))
				{
					return (int)Hints[EncodeHintType.HEIGHT];
				}
				return 0;
			}
			set
			{
				Hints[EncodeHintType.HEIGHT] = value;
			}
		}

		public int Width
		{
			get
			{
				if (Hints.ContainsKey(EncodeHintType.WIDTH))
				{
					return (int)Hints[EncodeHintType.WIDTH];
				}
				return 0;
			}
			set
			{
				Hints[EncodeHintType.WIDTH] = value;
			}
		}

		public bool PureBarcode
		{
			get
			{
				if (Hints.ContainsKey(EncodeHintType.PURE_BARCODE))
				{
					return (bool)Hints[EncodeHintType.PURE_BARCODE];
				}
				return false;
			}
			set
			{
				Hints[EncodeHintType.PURE_BARCODE] = value;
			}
		}

		public int Margin
		{
			get
			{
				if (Hints.ContainsKey(EncodeHintType.MARGIN))
				{
					return (int)Hints[EncodeHintType.MARGIN];
				}
				return 0;
			}
			set
			{
				Hints[EncodeHintType.MARGIN] = value;
			}
		}

		public bool GS1Format
		{
			get
			{
				if (Hints.ContainsKey(EncodeHintType.GS1_FORMAT))
				{
					return (bool)Hints[EncodeHintType.GS1_FORMAT];
				}
				return false;
			}
			set
			{
				Hints[EncodeHintType.GS1_FORMAT] = value;
			}
		}

		public EncodingOptions()
		{
			Hints = new Dictionary<EncodeHintType, object>();
		}
	}
	public class GlobalHistogramBinarizer : Binarizer
	{
		private const int LUMINANCE_BITS = 5;

		private const int LUMINANCE_SHIFT = 3;

		private const int LUMINANCE_BUCKETS = 32;

		private static readonly byte[] EMPTY = new byte[0];

		private byte[] luminances;

		private readonly int[] buckets;

		public override BitMatrix BlackMatrix
		{
			get
			{
				LuminanceSource luminanceSource = LuminanceSource;
				int width = luminanceSource.Width;
				int height = luminanceSource.Height;
				BitMatrix bitMatrix = new BitMatrix(width, height);
				initArrays(width);
				int[] array = buckets;
				byte[] row;
				for (int i = 1; i < 5; i++)
				{
					int y = height * i / 5;
					row = luminanceSource.getRow(y, luminances);
					int num = (width << 2) / 5;
					for (int j = width / 5; j < num; j++)
					{
						int num2 = row[j] & 0xFF;
						array[num2 >> 3]++;
					}
				}
				if (!estimateBlackPoint(array, out var blackPoint))
				{
					return null;
				}
				row = luminanceSource.Matrix;
				for (int k = 0; k < height; k++)
				{
					int num3 = k * width;
					for (int l = 0; l < width; l++)
					{
						int num4 = row[num3 + l] & 0xFF;
						bitMatrix[l, k] = num4 < blackPoint;
					}
				}
				return bitMatrix;
			}
		}

		public GlobalHistogramBinarizer(LuminanceSource source)
			: base(source)
		{
			luminances = EMPTY;
			buckets = new int[32];
		}

		public override BitArray getBlackRow(int y, BitArray row)
		{
			LuminanceSource luminanceSource = LuminanceSource;
			int width = luminanceSource.Width;
			if (row == null || row.Size < width)
			{
				row = new BitArray(width);
			}
			else
			{
				row.clear();
			}
			initArrays(width);
			byte[] row2 = luminanceSource.getRow(y, luminances);
			int[] array = buckets;
			for (int i = 0; i < width; i++)
			{
				array[(row2[i] & 0xFF) >> 3]++;
			}
			if (!estimateBlackPoint(array, out var blackPoint))
			{
				return null;
			}
			if (width < 3)
			{
				for (int j = 0; j < width; j++)
				{
					if ((row2[j] & 0xFF) < blackPoint)
					{
						row[j] = true;
					}
				}
			}
			else
			{
				int num = row2[0] & 0xFF;
				int num2 = row2[1] & 0xFF;
				for (int k = 1; k < width - 1; k++)
				{
					int num3 = row2[k + 1] & 0xFF;
					if ((num2 * 4 - num - num3) / 2 < blackPoint)
					{
						row[k] = true;
					}
					num = num2;
					num2 = num3;
				}
			}
			return row;
		}

		public override Binarizer createBinarizer(LuminanceSource source)
		{
			return new GlobalHistogramBinarizer(source);
		}

		private void initArrays(int luminanceSize)
		{
			if (luminances.Length < luminanceSize)
			{
				luminances = new byte[luminanceSize];
			}
			for (int i = 0; i < 32; i++)
			{
				buckets[i] = 0;
			}
		}

		private static bool estimateBlackPoint(int[] buckets, out int blackPoint)
		{
			blackPoint = 0;
			int num = buckets.Length;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < num; i++)
			{
				if (buckets[i] > num4)
				{
					num3 = i;
					num4 = buckets[i];
				}
				if (buckets[i] > num2)
				{
					num2 = buckets[i];
				}
			}
			int num5 = 0;
			int num6 = 0;
			for (int j = 0; j < num; j++)
			{
				int num7 = j - num3;
				int num8 = buckets[j] * num7 * num7;
				if (num8 > num6)
				{
					num5 = j;
					num6 = num8;
				}
			}
			if (num3 > num5)
			{
				int num9 = num3;
				num3 = num5;
				num5 = num9;
			}
			if (num5 - num3 <= num >> 4)
			{
				return false;
			}
			int num10 = num5 - 1;
			int num11 = -1;
			for (int num12 = num5 - 1; num12 > num3; num12--)
			{
				int num13 = num12 - num3;
				int num14 = num13 * num13 * (num5 - num12) * (num2 - buckets[num12]);
				if (num14 > num11)
				{
					num10 = num12;
					num11 = num14;
				}
			}
			blackPoint = num10 << 3;
			return true;
		}
	}
	public abstract class GridSampler
	{
		private static GridSampler gridSampler = new DefaultGridSampler();

		public static GridSampler Instance => gridSampler;

		public static void setGridSampler(GridSampler newGridSampler)
		{
			if (newGridSampler == null)
			{
				throw new ArgumentException();
			}
			gridSampler = newGridSampler;
		}

		public abstract BitMatrix sampleGrid(BitMatrix image, int dimensionX, int dimensionY, float p1ToX, float p1ToY, float p2ToX, float p2ToY, float p3ToX, float p3ToY, float p4ToX, float p4ToY, float p1FromX, float p1FromY, float p2FromX, float p2FromY, float p3FromX, float p3FromY, float p4FromX, float p4FromY);

		public virtual BitMatrix sampleGrid(BitMatrix image, int dimensionX, int dimensionY, PerspectiveTransform transform)
		{
			throw new NotSupportedException();
		}

		protected internal static bool checkAndNudgePoints(BitMatrix image, float[] points)
		{
			int width = image.Width;
			int height = image.Height;
			bool flag = true;
			for (int i = 0; i < points.Length && flag; i += 2)
			{
				int num = (int)points[i];
				int num2 = (int)points[i + 1];
				if (num < -1 || num > width || num2 < -1 || num2 > height)
				{
					return false;
				}
				flag = false;
				if (num == -1)
				{
					points[i] = 0f;
					flag = true;
				}
				else if (num == width)
				{
					points[i] = width - 1;
					flag = true;
				}
				if (num2 == -1)
				{
					points[i + 1] = 0f;
					flag = true;
				}
				else if (num2 == height)
				{
					points[i + 1] = height - 1;
					flag = true;
				}
			}
			flag = true;
			int num3 = points.Length - 2;
			while (num3 >= 0 && flag)
			{
				int num4 = (int)points[num3];
				int num5 = (int)points[num3 + 1];
				if (num4 < -1 || num4 > width || num5 < -1 || num5 > height)
				{
					return false;
				}
				flag = false;
				if (num4 == -1)
				{
					points[num3] = 0f;
					flag = true;
				}
				else if (num4 == width)
				{
					points[num3] = width - 1;
					flag = true;
				}
				if (num5 == -1)
				{
					points[num3 + 1] = 0f;
					flag = true;
				}
				else if (num5 == height)
				{
					points[num3 + 1] = height - 1;
					flag = true;
				}
				num3 -= 2;
			}
			return true;
		}
	}
	public sealed class HybridBinarizer : GlobalHistogramBinarizer
	{
		private const int BLOCK_SIZE_POWER = 3;

		private const int BLOCK_SIZE = 8;

		private const int BLOCK_SIZE_MASK = 7;

		private const int MINIMUM_DIMENSION = 40;

		private const int MIN_DYNAMIC_RANGE = 24;

		private BitMatrix matrix;

		public override BitMatrix BlackMatrix
		{
			get
			{
				binarizeEntireImage();
				return matrix;
			}
		}

		public HybridBinarizer(LuminanceSource source)
			: base(source)
		{
		}

		public override Binarizer createBinarizer(LuminanceSource source)
		{
			return new HybridBinarizer(source);
		}

		private void binarizeEntireImage()
		{
			if (matrix != null)
			{
				return;
			}
			LuminanceSource luminanceSource = LuminanceSource;
			int width = luminanceSource.Width;
			int height = luminanceSource.Height;
			if (width >= 40 && height >= 40)
			{
				byte[] array = luminanceSource.Matrix;
				int num = width >> 3;
				if ((width & 7) != 0)
				{
					num++;
				}
				int num2 = height >> 3;
				if ((height & 7) != 0)
				{
					num2++;
				}
				int[][] blackPoints = calculateBlackPoints(array, num, num2, width, height);
				BitMatrix bitMatrix = new BitMatrix(width, height);
				calculateThresholdForBlock(array, num, num2, width, height, blackPoints, bitMatrix);
				matrix = bitMatrix;
			}
			else
			{
				matrix = base.BlackMatrix;
			}
		}

		private static void calculateThresholdForBlock(byte[] luminances, int subWidth, int subHeight, int width, int height, int[][] blackPoints, BitMatrix matrix)
		{
			int num = height - 8;
			int num2 = width - 8;
			for (int i = 0; i < subHeight; i++)
			{
				int num3 = i << 3;
				if (num3 > num)
				{
					num3 = num;
				}
				int num4 = cap(i, 2, subHeight - 3);
				for (int j = 0; j < subWidth; j++)
				{
					int num5 = j << 3;
					if (num5 > num2)
					{
						num5 = num2;
					}
					int num6 = cap(j, 2, subWidth - 3);
					int num7 = 0;
					for (int k = -2; k <= 2; k++)
					{
						int[] array = blackPoints[num4 + k];
						num7 += array[num6 - 2];
						num7 += array[num6 - 1];
						num7 += array[num6];
						num7 += array[num6 + 1];
						num7 += array[num6 + 2];
					}
					int threshold = num7 / 25;
					thresholdBlock(luminances, num5, num3, threshold, width, matrix);
				}
			}
		}

		private static int cap(int value, int min, int max)
		{
			if (value >= min)
			{
				if (value <= max)
				{
					return value;
				}
				return max;
			}
			return min;
		}

		private static void thresholdBlock(byte[] luminances, int xoffset, int yoffset, int threshold, int stride, BitMatrix matrix)
		{
			int num = yoffset * stride + xoffset;
			int num2 = 0;
			while (num2 < 8)
			{
				for (int i = 0; i < 8; i++)
				{
					int num3 = luminances[num + i] & 0xFF;
					matrix[xoffset + i, yoffset + num2] = num3 <= threshold;
				}
				num2++;
				num += stride;
			}
		}

		private static int[][] calculateBlackPoints(byte[] luminances, int subWidth, int subHeight, int width, int height)
		{
			int num = height - 8;
			int num2 = width - 8;
			int[][] array = new int[subHeight][];
			for (int i = 0; i < subHeight; i++)
			{
				array[i] = new int[subWidth];
			}
			for (int j = 0; j < subHeight; j++)
			{
				int num3 = j << 3;
				if (num3 > num)
				{
					num3 = num;
				}
				int[] array2 = array[j];
				int[] array3 = ((j > 0) ? array[j - 1] : null);
				for (int k = 0; k < subWidth; k++)
				{
					int num4 = k << 3;
					if (num4 > num2)
					{
						num4 = num2;
					}
					int num5 = 0;
					int num6 = 255;
					int num7 = 0;
					int num8 = 0;
					int num9 = num3 * width + num4;
					while (num8 < 8)
					{
						for (int l = 0; l < 8; l++)
						{
							int num10 = luminances[num9 + l] & 0xFF;
							num5 += num10;
							if (num10 < num6)
							{
								num6 = num10;
							}
							if (num10 > num7)
							{
								num7 = num10;
							}
						}
						if (num7 - num6 > 24)
						{
							num8++;
							num9 += width;
							while (num8 < 8)
							{
								for (int m = 0; m < 8; m++)
								{
									num5 += luminances[num9 + m] & 0xFF;
								}
								num8++;
								num9 += width;
							}
						}
						num8++;
						num9 += width;
					}
					int num11 = num5 >> 6;
					if (num7 - num6 <= 24)
					{
						num11 = num6 >> 1;
						if (array3 != null && k > 0)
						{
							int num12 = array3[k] + 2 * array2[k - 1] + array3[k - 1] >> 2;
							if (num6 < num12)
							{
								num11 = num12;
							}
						}
					}
					array2[k] = num11;
				}
			}
			return array;
		}
	}
	public sealed class PerspectiveTransform
	{
		private float a11;

		private float a12;

		private float a13;

		private float a21;

		private float a22;

		private float a23;

		private float a31;

		private float a32;

		private float a33;

		private PerspectiveTransform(float a11, float a21, float a31, float a12, float a22, float a32, float a13, float a23, float a33)
		{
			this.a11 = a11;
			this.a12 = a12;
			this.a13 = a13;
			this.a21 = a21;
			this.a22 = a22;
			this.a23 = a23;
			this.a31 = a31;
			this.a32 = a32;
			this.a33 = a33;
		}

		public static PerspectiveTransform quadrilateralToQuadrilateral(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, float x0p, float y0p, float x1p, float y1p, float x2p, float y2p, float x3p, float y3p)
		{
			PerspectiveTransform other = quadrilateralToSquare(x0, y0, x1, y1, x2, y2, x3, y3);
			return squareToQuadrilateral(x0p, y0p, x1p, y1p, x2p, y2p, x3p, y3p).times(other);
		}

		public void transformPoints(float[] points)
		{
			int num = points.Length;
			float num2 = a11;
			float num3 = a12;
			float num4 = a13;
			float num5 = a21;
			float num6 = a22;
			float num7 = a23;
			float num8 = a31;
			float num9 = a32;
			float num10 = a33;
			for (int i = 0; i < num; i += 2)
			{
				float num11 = points[i];
				float num12 = points[i + 1];
				float num13 = num4 * num11 + num7 * num12 + num10;
				points[i] = (num2 * num11 + num5 * num12 + num8) / num13;
				points[i + 1] = (num3 * num11 + num6 * num12 + num9) / num13;
			}
		}

		public void transformPoints(float[] xValues, float[] yValues)
		{
			int num = xValues.Length;
			for (int i = 0; i < num; i++)
			{
				float num2 = xValues[i];
				float num3 = yValues[i];
				float num4 = a13 * num2 + a23 * num3 + a33;
				xValues[i] = (a11 * num2 + a21 * num3 + a31) / num4;
				yValues[i] = (a12 * num2 + a22 * num3 + a32) / num4;
			}
		}

		public static PerspectiveTransform squareToQuadrilateral(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3)
		{
			float num = x0 - x1 + x2 - x3;
			float num2 = y0 - y1 + y2 - y3;
			if (num == 0f && num2 == 0f)
			{
				return new PerspectiveTransform(x1 - x0, x2 - x1, x0, y1 - y0, y2 - y1, y0, 0f, 0f, 1f);
			}
			float num3 = x1 - x2;
			float num4 = x3 - x2;
			float num5 = y1 - y2;
			float num6 = y3 - y2;
			float num7 = num3 * num6 - num4 * num5;
			float num8 = (num * num6 - num4 * num2) / num7;
			float num9 = (num3 * num2 - num * num5) / num7;
			return new PerspectiveTransform(x1 - x0 + num8 * x1, x3 - x0 + num9 * x3, x0, y1 - y0 + num8 * y1, y3 - y0 + num9 * y3, y0, num8, num9, 1f);
		}

		public static PerspectiveTransform quadrilateralToSquare(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3)
		{
			return squareToQuadrilateral(x0, y0, x1, y1, x2, y2, x3, y3).buildAdjoint();
		}

		internal PerspectiveTransform buildAdjoint()
		{
			return new PerspectiveTransform(a22 * a33 - a23 * a32, a23 * a31 - a21 * a33, a21 * a32 - a22 * a31, a13 * a32 - a12 * a33, a11 * a33 - a13 * a31, a12 * a31 - a11 * a32, a12 * a23 - a13 * a22, a13 * a21 - a11 * a23, a11 * a22 - a12 * a21);
		}

		internal PerspectiveTransform times(PerspectiveTransform other)
		{
			return new PerspectiveTransform(a11 * other.a11 + a21 * other.a12 + a31 * other.a13, a11 * other.a21 + a21 * other.a22 + a31 * other.a23, a11 * other.a31 + a21 * other.a32 + a31 * other.a33, a12 * other.a11 + a22 * other.a12 + a32 * other.a13, a12 * other.a21 + a22 * other.a22 + a32 * other.a23, a12 * other.a31 + a22 * other.a32 + a32 * other.a33, a13 * other.a11 + a23 * other.a12 + a33 * other.a13, a13 * other.a21 + a23 * other.a22 + a33 * other.a23, a13 * other.a31 + a23 * other.a32 + a33 * other.a33);
		}
	}
	public static class StringUtils
	{
		private const string PLATFORM_DEFAULT_ENCODING = "UTF-8";

		public static string SHIFT_JIS = "SJIS";

		public static string GB2312 = "GB2312";

		private const string EUC_JP = "EUC-JP";

		private const string UTF8 = "UTF-8";

		private const string ISO88591 = "ISO-8859-1";

		private static readonly bool ASSUME_SHIFT_JIS = string.Compare(SHIFT_JIS, "UTF-8", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare("EUC-JP", "UTF-8", StringComparison.OrdinalIgnoreCase) == 0;

		public static string guessEncoding(byte[] bytes, IDictionary<DecodeHintType, object> hints)
		{
			if (hints != null && hints.ContainsKey(DecodeHintType.CHARACTER_SET))
			{
				string text = (string)hints[DecodeHintType.CHARACTER_SET];
				if (text != null)
				{
					return text;
				}
			}
			int num = bytes.Length;
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			bool flag4 = bytes.Length > 3 && bytes[0] == 239 && bytes[1] == 187 && bytes[2] == 191;
			for (int i = 0; i < num; i++)
			{
				if (!(flag || flag2 || flag3))
				{
					break;
				}
				int num13 = bytes[i] & 0xFF;
				if (flag3)
				{
					if (num2 > 0)
					{
						if ((num13 & 0x80) == 0)
						{
							flag3 = false;
						}
						else
						{
							num2--;
						}
					}
					else if ((num13 & 0x80) != 0)
					{
						if ((num13 & 0x40) == 0)
						{
							flag3 = false;
						}
						else
						{
							num2++;
							if ((num13 & 0x20) == 0)
							{
								num3++;
							}
							else
							{
								num2++;
								if ((num13 & 0x10) == 0)
								{
									num4++;
								}
								else
								{
									num2++;
									if ((num13 & 8) == 0)
									{
										num5++;
									}
									else
									{
										flag3 = false;
									}
								}
							}
						}
					}
				}
				if (flag)
				{
					if (num13 > 127 && num13 < 160)
					{
						flag = false;
					}
					else
					{
						switch (num13)
						{
						case 160:
						case 161:
						case 162:
						case 163:
						case 164:
						case 165:
						case 166:
						case 167:
						case 168:
						case 169:
						case 170:
						case 171:
						case 172:
						case 173:
						case 174:
						case 175:
						case 176:
						case 177:
						case 178:
						case 179:
						case 180:
						case 181:
						case 182:
						case 183:
						case 184:
						case 185:
						case 186:
						case 187:
						case 188:
						case 189:
						case 190:
						case 191:
						case 215:
						case 247:
							num12++;
							break;
						}
					}
				}
				if (!flag2)
				{
					continue;
				}
				if (num6 > 0)
				{
					if (num13 < 64 || num13 == 127 || num13 > 252)
					{
						flag2 = false;
					}
					else
					{
						num6--;
					}
				}
				else if (num13 == 128 || num13 == 160 || num13 > 239)
				{
					flag2 = false;
				}
				else if (num13 > 160 && num13 < 224)
				{
					num7++;
					num9 = 0;
					num8++;
					if (num8 > num10)
					{
						num10 = num8;
					}
				}
				else if (num13 > 127)
				{
					num6++;
					num8 = 0;
					num9++;
					if (num9 > num11)
					{
						num11 = num9;
					}
				}
				else
				{
					num8 = 0;
					num9 = 0;
				}
			}
			if (flag3 && num2 > 0)
			{
				flag3 = false;
			}
			if (flag2 && num6 > 0)
			{
				flag2 = false;
			}
			if (flag3 && (flag4 || num3 + num4 + num5 > 0))
			{
				return "UTF-8";
			}
			if (flag2 && (ASSUME_SHIFT_JIS || num10 >= 3 || num11 >= 3))
			{
				return SHIFT_JIS;
			}
			if (flag && flag2)
			{
				if ((num10 != 2 || num7 != 2) && num12 * 10 < num)
				{
					return "ISO-8859-1";
				}
				return SHIFT_JIS;
			}
			if (flag)
			{
				return "ISO-8859-1";
			}
			if (flag2)
			{
				return SHIFT_JIS;
			}
			return "UTF-8";
		}
	}
}
namespace ZXing.Common.ReedSolomon
{
	public sealed class GenericGF
	{
		public static GenericGF AZTEC_DATA_12 = new GenericGF(4201, 4096, 1);

		public static GenericGF AZTEC_DATA_10 = new GenericGF(1033, 1024, 1);

		public static GenericGF AZTEC_DATA_6 = new GenericGF(67, 64, 1);

		public static GenericGF AZTEC_PARAM = new GenericGF(19, 16, 1);

		public static GenericGF QR_CODE_FIELD_256 = new GenericGF(285, 256, 0);

		public static GenericGF DATA_MATRIX_FIELD_256 = new GenericGF(301, 256, 1);

		public static GenericGF AZTEC_DATA_8 = DATA_MATRIX_FIELD_256;

		public static GenericGF MAXICODE_FIELD_64 = AZTEC_DATA_6;

		private int[] expTable;

		private int[] logTable;

		private GenericGFPoly zero;

		private GenericGFPoly one;

		private readonly int size;

		private readonly int primitive;

		private readonly int generatorBase;

		internal GenericGFPoly Zero => zero;

		internal GenericGFPoly One => one;

		public int Size => size;

		public int GeneratorBase => generatorBase;

		public GenericGF(int primitive, int size, int genBase)
		{
			this.primitive = primitive;
			this.size = size;
			generatorBase = genBase;
			expTable = new int[size];
			logTable = new int[size];
			int num = 1;
			for (int i = 0; i < size; i++)
			{
				expTable[i] = num;
				num <<= 1;
				if (num >= size)
				{
					num ^= primitive;
					num &= size - 1;
				}
			}
			for (int j = 0; j < size - 1; j++)
			{
				logTable[expTable[j]] = j;
			}
			zero = new GenericGFPoly(this, new int[1]);
			one = new GenericGFPoly(this, new int[1] { 1 });
		}

		internal GenericGFPoly buildMonomial(int degree, int coefficient)
		{
			if (degree < 0)
			{
				throw new ArgumentException();
			}
			if (coefficient == 0)
			{
				return zero;
			}
			int[] array = new int[degree + 1];
			array[0] = coefficient;
			return new GenericGFPoly(this, array);
		}

		internal static int addOrSubtract(int a, int b)
		{
			return a ^ b;
		}

		internal int exp(int a)
		{
			return expTable[a];
		}

		internal int log(int a)
		{
			if (a == 0)
			{
				throw new ArgumentException();
			}
			return logTable[a];
		}

		internal int inverse(int a)
		{
			if (a == 0)
			{
				throw new ArithmeticException();
			}
			return expTable[size - logTable[a] - 1];
		}

		internal int multiply(int a, int b)
		{
			if (a == 0 || b == 0)
			{
				return 0;
			}
			return expTable[(logTable[a] + logTable[b]) % (size - 1)];
		}

		public override string ToString()
		{
			object[] obj = new object[5] { "GF(0x", null, null, null, null };
			int num = primitive;
			obj[1] = num.ToString("X");
			obj[2] = ",";
			obj[3] = size;
			obj[4] = ")";
			return string.Concat(obj);
		}
	}
	internal sealed class GenericGFPoly
	{
		private readonly GenericGF field;

		private readonly int[] coefficients;

		internal int[] Coefficients => coefficients;

		internal int Degree => coefficients.Length - 1;

		internal bool isZero => coefficients[0] == 0;

		internal GenericGFPoly(GenericGF field, int[] coefficients)
		{
			if (coefficients.Length == 0)
			{
				throw new ArgumentException();
			}
			this.field = field;
			int num = coefficients.Length;
			if (num > 1 && coefficients[0] == 0)
			{
				int i;
				for (i = 1; i < num && coefficients[i] == 0; i++)
				{
				}
				if (i == num)
				{
					this.coefficients = new int[1];
					return;
				}
				this.coefficients = new int[num - i];
				Array.Copy(coefficients, i, this.coefficients, 0, this.coefficients.Length);
			}
			else
			{
				this.coefficients = coefficients;
			}
		}

		internal int getCoefficient(int degree)
		{
			return coefficients[coefficients.Length - 1 - degree];
		}

		internal int evaluateAt(int a)
		{
			int num = 0;
			switch (a)
			{
			case 0:
				return getCoefficient(0);
			case 1:
			{
				int[] array = coefficients;
				foreach (int b in array)
				{
					num = GenericGF.addOrSubtract(num, b);
				}
				return num;
			}
			default:
			{
				num = coefficients[0];
				int num2 = coefficients.Length;
				for (int i = 1; i < num2; i++)
				{
					num = GenericGF.addOrSubtract(field.multiply(a, num), coefficients[i]);
				}
				return num;
			}
			}
		}

		internal GenericGFPoly addOrSubtract(GenericGFPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("GenericGFPolys do not have same GenericGF field");
			}
			if (isZero)
			{
				return other;
			}
			if (other.isZero)
			{
				return this;
			}
			int[] array = coefficients;
			int[] array2 = other.coefficients;
			if (array.Length > array2.Length)
			{
				int[] array3 = array;
				array = array2;
				array2 = array3;
			}
			int[] array4 = new int[array2.Length];
			int num = array2.Length - array.Length;
			Array.Copy(array2, 0, array4, 0, num);
			for (int i = num; i < array2.Length; i++)
			{
				array4[i] = GenericGF.addOrSubtract(array[i - num], array2[i]);
			}
			return new GenericGFPoly(field, array4);
		}

		internal GenericGFPoly multiply(GenericGFPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("GenericGFPolys do not have same GenericGF field");
			}
			if (isZero || other.isZero)
			{
				return field.Zero;
			}
			int[] array = coefficients;
			int num = array.Length;
			int[] array2 = other.coefficients;
			int num2 = array2.Length;
			int[] array3 = new int[num + num2 - 1];
			for (int i = 0; i < num; i++)
			{
				int a = array[i];
				for (int j = 0; j < num2; j++)
				{
					array3[i + j] = GenericGF.addOrSubtract(array3[i + j], field.multiply(a, array2[j]));
				}
			}
			return new GenericGFPoly(field, array3);
		}

		internal GenericGFPoly multiply(int scalar)
		{
			switch (scalar)
			{
			case 0:
				return field.Zero;
			case 1:
				return this;
			default:
			{
				int num = coefficients.Length;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = field.multiply(coefficients[i], scalar);
				}
				return new GenericGFPoly(field, array);
			}
			}
		}

		internal GenericGFPoly multiplyByMonomial(int degree, int coefficient)
		{
			if (degree < 0)
			{
				throw new ArgumentException();
			}
			if (coefficient == 0)
			{
				return field.Zero;
			}
			int num = coefficients.Length;
			int[] array = new int[num + degree];
			for (int i = 0; i < num; i++)
			{
				array[i] = field.multiply(coefficients[i], coefficient);
			}
			return new GenericGFPoly(field, array);
		}

		internal GenericGFPoly[] divide(GenericGFPoly other)
		{
			if (!field.Equals(other.field))
			{
				throw new ArgumentException("GenericGFPolys do not have same GenericGF field");
			}
			if (other.isZero)
			{
				throw new ArgumentException("Divide by 0");
			}
			GenericGFPoly genericGFPoly = field.Zero;
			GenericGFPoly genericGFPoly2 = this;
			int coefficient = other.getCoefficient(other.Degree);
			int b = field.inverse(coefficient);
			while (genericGFPoly2.Degree >= other.Degree && !genericGFPoly2.isZero)
			{
				int degree = genericGFPoly2.Degree - other.Degree;
				int coefficient2 = field.multiply(genericGFPoly2.getCoefficient(genericGFPoly2.Degree), b);
				GenericGFPoly other2 = other.multiplyByMonomial(degree, coefficient2);
				GenericGFPoly other3 = field.buildMonomial(degree, coefficient2);
				genericGFPoly = genericGFPoly.addOrSubtract(other3);
				genericGFPoly2 = genericGFPoly2.addOrSubtract(other2);
			}
			return new GenericGFPoly[2] { genericGFPoly, genericGFPoly2 };
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(8 * Degree);
			for (int num = Degree; num >= 0; num--)
			{
				int num2 = getCoefficient(num);
				if (num2 != 0)
				{
					if (num2 < 0)
					{
						stringBuilder.Append(" - ");
						num2 = -num2;
					}
					else if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" + ");
					}
					if (num == 0 || num2 != 1)
					{
						int num3 = field.log(num2);
						switch (num3)
						{
						case 0:
							stringBuilder.Append('1');
							break;
						case 1:
							stringBuilder.Append('a');
							break;
						default:
							stringBuilder.Append("a^");
							stringBuilder.Append(num3);
							break;
						}
					}
					switch (num)
					{
					case 1:
						stringBuilder.Append('x');
						break;
					default:
						stringBuilder.Append("x^");
						stringBuilder.Append(num);
						break;
					case 0:
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class ReedSolomonDecoder
	{
		private readonly GenericGF field;

		public ReedSolomonDecoder(GenericGF field)
		{
			this.field = field;
		}

		public bool decode(int[] received, int twoS)
		{
			GenericGFPoly genericGFPoly = new GenericGFPoly(field, received);
			int[] array = new int[twoS];
			bool flag = true;
			for (int i = 0; i < twoS; i++)
			{
				int num = genericGFPoly.evaluateAt(field.exp(i + field.GeneratorBase));
				array[array.Length - 1 - i] = num;
				if (num != 0)
				{
					flag = false;
				}
			}
			if (flag)
			{
				return true;
			}
			GenericGFPoly b = new GenericGFPoly(field, array);
			GenericGFPoly[] array2 = runEuclideanAlgorithm(field.buildMonomial(twoS, 1), b, twoS);
			if (array2 == null)
			{
				return false;
			}
			GenericGFPoly errorLocator = array2[0];
			int[] array3 = findErrorLocations(errorLocator);
			if (array3 == null)
			{
				return false;
			}
			GenericGFPoly errorEvaluator = array2[1];
			int[] array4 = findErrorMagnitudes(errorEvaluator, array3);
			for (int j = 0; j < array3.Length; j++)
			{
				int num2 = received.Length - 1 - field.log(array3[j]);
				if (num2 < 0)
				{
					return false;
				}
				received[num2] = GenericGF.addOrSubtract(received[num2], array4[j]);
			}
			return true;
		}

		internal GenericGFPoly[] runEuclideanAlgorithm(GenericGFPoly a, GenericGFPoly b, int R)
		{
			if (a.Degree < b.Degree)
			{
				GenericGFPoly genericGFPoly = a;
				a = b;
				b = genericGFPoly;
			}
			GenericGFPoly genericGFPoly2 = a;
			GenericGFPoly genericGFPoly3 = b;
			GenericGFPoly genericGFPoly4 = field.Zero;
			GenericGFPoly genericGFPoly5 = field.One;
			while (genericGFPoly3.Degree >= R / 2)
			{
				GenericGFPoly genericGFPoly6 = genericGFPoly2;
				GenericGFPoly other = genericGFPoly4;
				genericGFPoly2 = genericGFPoly3;
				genericGFPoly4 = genericGFPoly5;
				if (genericGFPoly2.isZero)
				{
					return null;
				}
				genericGFPoly3 = genericGFPoly6;
				GenericGFPoly genericGFPoly7 = field.Zero;
				int coefficient = genericGFPoly2.getCoefficient(genericGFPoly2.Degree);
				int b2 = field.inverse(coefficient);
				while (genericGFPoly3.Degree >= genericGFPoly2.Degree && !genericGFPoly3.isZero)
				{
					int degree = genericGFPoly3.Degree - genericGFPoly2.Degree;
					int coefficient2 = field.multiply(genericGFPoly3.getCoefficient(genericGFPoly3.Degree), b2);
					genericGFPoly7 = genericGFPoly7.addOrSubtract(field.buildMonomial(degree, coefficient2));
					genericGFPoly3 = genericGFPoly3.addOrSubtract(genericGFPoly2.multiplyByMonomial(degree, coefficient2));
				}
				genericGFPoly5 = genericGFPoly7.multiply(genericGFPoly4).addOrSubtract(other);
				if (genericGFPoly3.Degree >= genericGFPoly2.Degree)
				{
					return null;
				}
			}
			int coefficient3 = genericGFPoly5.getCoefficient(0);
			if (coefficient3 == 0)
			{
				return null;
			}
			int scalar = field.inverse(coefficient3);
			GenericGFPoly genericGFPoly8 = genericGFPoly5.multiply(scalar);
			GenericGFPoly genericGFPoly9 = genericGFPoly3.multiply(scalar);
			return new GenericGFPoly[2] { genericGFPoly8, genericGFPoly9 };
		}

		private int[] findErrorLocations(GenericGFPoly errorLocator)
		{
			int degree = errorLocator.Degree;
			if (degree == 1)
			{
				return new int[1] { errorLocator.getCoefficient(1) };
			}
			int[] array = new int[degree];
			int num = 0;
			for (int i = 1; i < field.Size; i++)
			{
				if (num >= degree)
				{
					break;
				}
				if (errorLocator.evaluateAt(i) == 0)
				{
					array[num] = field.inverse(i);
					num++;
				}
			}
			if (num != degree)
			{
				return null;
			}
			return array;
		}

		private int[] findErrorMagnitudes(GenericGFPoly errorEvaluator, int[] errorLocations)
		{
			int num = errorLocations.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = field.inverse(errorLocations[i]);
				int a = 1;
				for (int j = 0; j < num; j++)
				{
					if (i != j)
					{
						int num3 = field.multiply(errorLocations[j], num2);
						int b = (((num3 & 1) == 0) ? (num3 | 1) : (num3 & -2));
						a = field.multiply(a, b);
					}
				}
				array[i] = field.multiply(errorEvaluator.evaluateAt(num2), field.inverse(a));
				if (field.GeneratorBase != 0)
				{
					array[i] = field.multiply(array[i], num2);
				}
			}
			return array;
		}
	}
	public sealed class ReedSolomonEncoder
	{
		private readonly GenericGF field;

		private readonly IList<GenericGFPoly> cachedGenerators;

		public ReedSolomonEncoder(GenericGF field)
		{
			this.field = field;
			cachedGenerators = new List<GenericGFPoly>();
			cachedGenerators.Add(new GenericGFPoly(field, new int[1] { 1 }));
		}

		private GenericGFPoly buildGenerator(int degree)
		{
			if (degree >= cachedGenerators.Count)
			{
				GenericGFPoly genericGFPoly = cachedGenerators[cachedGenerators.Count - 1];
				for (int i = cachedGenerators.Count; i <= degree; i++)
				{
					GenericGFPoly genericGFPoly2 = genericGFPoly.multiply(new GenericGFPoly(field, new int[2]
					{
						1,
						field.exp(i - 1 + field.GeneratorBase)
					}));
					cachedGenerators.Add(genericGFPoly2);
					genericGFPoly = genericGFPoly2;
				}
			}
			return cachedGenerators[degree];
		}

		public void encode(int[] toEncode, int ecBytes)
		{
			if (ecBytes == 0)
			{
				throw new ArgumentException("No error correction bytes");
			}
			int num = toEncode.Length - ecBytes;
			if (num <= 0)
			{
				throw new ArgumentException("No data bytes provided");
			}
			GenericGFPoly other = buildGenerator(ecBytes);
			int[] array = new int[num];
			Array.Copy(toEncode, 0, array, 0, num);
			int[] coefficients = new GenericGFPoly(field, array).multiplyByMonomial(ecBytes, 1).divide(other)[1].Coefficients;
			int num2 = ecBytes - coefficients.Length;
			for (int i = 0; i < num2; i++)
			{
				toEncode[num + i] = 0;
			}
			Array.Copy(coefficients, 0, toEncode, num + num2, coefficients.Length);
		}
	}
}
namespace ZXing.Common.Detector
{
	public static class MathUtils
	{
		public static int round(float d)
		{
			if (float.IsNaN(d))
			{
				return 0;
			}
			if (float.IsPositiveInfinity(d))
			{
				return 2147483647;
			}
			return (int)(d + ((d < 0f) ? (-0.5f) : 0.5f));
		}

		public static float distance(float aX, float aY, float bX, float bY)
		{
			float num = aX - bX;
			float num2 = aY - bY;
			return (float)Math.Sqrt(num * num + num2 * num2);
		}

		public static float distance(int aX, int aY, int bX, int bY)
		{
			int num = aX - bX;
			int num2 = aY - bY;
			return (float)Math.Sqrt(num * num + num2 * num2);
		}

		public static int sum(int[] array)
		{
			int num = 0;
			foreach (int num2 in array)
			{
				num += num2;
			}
			return num;
		}
	}
	[Obsolete]
	public sealed class MonochromeRectangleDetector
	{
		private const int MAX_MODULES = 32;

		private readonly BitMatrix image;

		public MonochromeRectangleDetector(BitMatrix image)
		{
			this.image = image;
		}

		public ResultPoint[] detect()
		{
			int height = image.Height;
			int width = image.Width;
			int num = height >> 1;
			int num2 = width >> 1;
			int num3 = Math.Max(1, height / 256);
			int num4 = Math.Max(1, width / 256);
			int top = 0;
			int bottom = height;
			int left = 0;
			int right = width;
			ResultPoint resultPoint = findCornerFromCenter(num2, 0, left, right, num, -num3, top, bottom, num2 >> 1);
			if (resultPoint == null)
			{
				return null;
			}
			top = (int)resultPoint.Y - 1;
			ResultPoint resultPoint2 = findCornerFromCenter(num2, -num4, left, right, num, 0, top, bottom, num >> 1);
			if (resultPoint2 == null)
			{
				return null;
			}
			left = (int)resultPoint2.X - 1;
			ResultPoint resultPoint3 = findCornerFromCenter(num2, num4, left, right, num, 0, top, bottom, num >> 1);
			if (resultPoint3 == null)
			{
				return null;
			}
			right = (int)resultPoint3.X + 1;
			ResultPoint resultPoint4 = findCornerFromCenter(num2, 0, left, right, num, num3, top, bottom, num2 >> 1);
			if (resultPoint4 == null)
			{
				return null;
			}
			bottom = (int)resultPoint4.Y + 1;
			resultPoint = findCornerFromCenter(num2, 0, left, right, num, -num3, top, bottom, num2 >> 2);
			if (resultPoint == null)
			{
				return null;
			}
			return new ResultPoint[4] { resultPoint, resultPoint2, resultPoint3, resultPoint4 };
		}

		private ResultPoint findCornerFromCenter(int centerX, int deltaX, int left, int right, int centerY, int deltaY, int top, int bottom, int maxWhiteRun)
		{
			int[] array = null;
			int num = centerY;
			int num2 = centerX;
			while (num < bottom && num >= top && num2 < right && num2 >= left)
			{
				int[] array2 = ((deltaX != 0) ? blackWhiteRange(num2, maxWhiteRun, top, bottom, horizontal: false) : blackWhiteRange(num, maxWhiteRun, left, right, horizontal: true));
				if (array2 == null)
				{
					if (array == null)
					{
						return null;
					}
					if (deltaX == 0)
					{
						int num3 = num - deltaY;
						if (array[0] < centerX)
						{
							if (array[1] > centerX)
							{
								return new ResultPoint(array[(deltaY <= 0) ? 1u : 0u], num3);
							}
							return new ResultPoint(array[0], num3);
						}
						return new ResultPoint(array[1], num3);
					}
					int num4 = num2 - deltaX;
					if (array[0] < centerY)
					{
						if (array[1] > centerY)
						{
							return new ResultPoint(num4, array[(deltaX >= 0) ? 1u : 0u]);
						}
						return new ResultPoint(num4, array[0]);
					}
					return new ResultPoint(num4, array[1]);
				}
				array = array2;
				num += deltaY;
				num2 += deltaX;
			}
			return null;
		}

		private int[] blackWhiteRange(int fixedDimension, int maxWhiteRun, int minDim, int maxDim, bool horizontal)
		{
			int num = minDim + maxDim >> 1;
			int num2 = num;
			while (num2 >= minDim)
			{
				if (horizontal ? image[num2, fixedDimension] : image[fixedDimension, num2])
				{
					num2--;
					continue;
				}
				int num3 = num2;
				do
				{
					num2--;
				}
				while (num2 >= minDim && !(horizontal ? image[num2, fixedDimension] : image[fixedDimension, num2]));
				int num4 = num3 - num2;
				if (num2 >= minDim && num4 <= maxWhiteRun)
				{
					continue;
				}
				num2 = num3;
				break;
			}
			num2++;
			int num5 = num;
			while (num5 < maxDim)
			{
				if (horizontal ? image[num5, fixedDimension] : image[fixedDimension, num5])
				{
					num5++;
					continue;
				}
				int num6 = num5;
				do
				{
					num5++;
				}
				while (num5 < maxDim && !(horizontal ? image[num5, fixedDimension] : image[fixedDimension, num5]));
				int num7 = num5 - num6;
				if (num5 < maxDim && num7 <= maxWhiteRun)
				{
					continue;
				}
				num5 = num6;
				break;
			}
			num5--;
			if (num5 <= num2)
			{
				return null;
			}
			return new int[2] { num2, num5 };
		}
	}
	public sealed class WhiteRectangleDetector
	{
		private const int INIT_SIZE = 10;

		private const int CORR = 1;

		private readonly BitMatrix image;

		private readonly int height;

		private readonly int width;

		private readonly int leftInit;

		private readonly int rightInit;

		private readonly int downInit;

		private readonly int upInit;

		public static WhiteRectangleDetector Create(BitMatrix image)
		{
			if (image == null)
			{
				return null;
			}
			WhiteRectangleDetector whiteRectangleDetector = new WhiteRectangleDetector(image);
			if (whiteRectangleDetector.upInit < 0 || whiteRectangleDetector.leftInit < 0 || whiteRectangleDetector.downInit >= whiteRectangleDetector.height || whiteRectangleDetector.rightInit >= whiteRectangleDetector.width)
			{
				return null;
			}
			return whiteRectangleDetector;
		}

		public static WhiteRectangleDetector Create(BitMatrix image, int initSize, int x, int y)
		{
			WhiteRectangleDetector whiteRectangleDetector = new WhiteRectangleDetector(image, initSize, x, y);
			if (whiteRectangleDetector.upInit < 0 || whiteRectangleDetector.leftInit < 0 || whiteRectangleDetector.downInit >= whiteRectangleDetector.height || whiteRectangleDetector.rightInit >= whiteRectangleDetector.width)
			{
				return null;
			}
			return whiteRectangleDetector;
		}

		internal WhiteRectangleDetector(BitMatrix image)
			: this(image, 10, image.Width / 2, image.Height / 2)
		{
		}

		internal WhiteRectangleDetector(BitMatrix image, int initSize, int x, int y)
		{
			this.image = image;
			height = image.Height;
			width = image.Width;
			int num = initSize / 2;
			leftInit = x - num;
			rightInit = x + num;
			upInit = y - num;
			downInit = y + num;
		}

		public ResultPoint[] detect()
		{
			int num = leftInit;
			int num2 = rightInit;
			int num3 = upInit;
			int num4 = downInit;
			bool flag = false;
			bool flag2 = true;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			while (flag2)
			{
				flag2 = false;
				bool flag8 = true;
				while ((flag8 || !flag4) && num2 < width)
				{
					flag8 = containsBlackPoint(num3, num4, num2, horizontal: false);
					if (flag8)
					{
						num2++;
						flag2 = true;
						flag4 = true;
					}
					else if (!flag4)
					{
						num2++;
					}
				}
				if (num2 >= width)
				{
					flag = true;
					break;
				}
				bool flag9 = true;
				while ((flag9 || !flag5) && num4 < height)
				{
					flag9 = containsBlackPoint(num, num2, num4, horizontal: true);
					if (flag9)
					{
						num4++;
						flag2 = true;
						flag5 = true;
					}
					else if (!flag5)
					{
						num4++;
					}
				}
				if (num4 >= height)
				{
					flag = true;
					break;
				}
				bool flag10 = true;
				while ((flag10 || !flag6) && num >= 0)
				{
					flag10 = containsBlackPoint(num3, num4, num, horizontal: false);
					if (flag10)
					{
						num--;
						flag2 = true;
						flag6 = true;
					}
					else if (!flag6)
					{
						num--;
					}
				}
				if (num < 0)
				{
					flag = true;
					break;
				}
				bool flag11 = true;
				while ((flag11 || !flag7) && num3 >= 0)
				{
					flag11 = containsBlackPoint(num, num2, num3, horizontal: true);
					if (flag11)
					{
						num3--;
						flag2 = true;
						flag7 = true;
					}
					else if (!flag7)
					{
						num3--;
					}
				}
				if (num3 < 0)
				{
					flag = true;
					break;
				}
				if (flag2)
				{
					flag3 = true;
				}
			}
			if (!flag && flag3)
			{
				int num5 = num2 - num;
				ResultPoint resultPoint = null;
				int num6 = 1;
				while (resultPoint == null && num6 < num5)
				{
					resultPoint = getBlackPointOnSegment(num, num4 - num6, num + num6, num4);
					num6++;
				}
				if (resultPoint == null)
				{
					return null;
				}
				ResultPoint resultPoint2 = null;
				int num7 = 1;
				while (resultPoint2 == null && num7 < num5)
				{
					resultPoint2 = getBlackPointOnSegment(num, num3 + num7, num + num7, num3);
					num7++;
				}
				if (resultPoint2 == null)
				{
					return null;
				}
				ResultPoint resultPoint3 = null;
				int num8 = 1;
				while (resultPoint3 == null && num8 < num5)
				{
					resultPoint3 = getBlackPointOnSegment(num2, num3 + num8, num2 - num8, num3);
					num8++;
				}
				if (resultPoint3 == null)
				{
					return null;
				}
				ResultPoint resultPoint4 = null;
				int num9 = 1;
				while (resultPoint4 == null && num9 < num5)
				{
					resultPoint4 = getBlackPointOnSegment(num2, num4 - num9, num2 - num9, num4);
					num9++;
				}
				if (resultPoint4 == null)
				{
					return null;
				}
				return centerEdges(resultPoint4, resultPoint, resultPoint3, resultPoint2);
			}
			return null;
		}

		private ResultPoint getBlackPointOnSegment(float aX, float aY, float bX, float bY)
		{
			int num = MathUtils.round(MathUtils.distance(aX, aY, bX, bY));
			float num2 = (bX - aX) / (float)num;
			float num3 = (bY - aY) / (float)num;
			for (int i = 0; i < num; i++)
			{
				int num4 = MathUtils.round(aX + (float)i * num2);
				int num5 = MathUtils.round(aY + (float)i * num3);
				if (image[num4, num5])
				{
					return new ResultPoint(num4, num5);
				}
			}
			return null;
		}

		private ResultPoint[] centerEdges(ResultPoint y, ResultPoint z, ResultPoint x, ResultPoint t)
		{
			float x2 = y.X;
			float y2 = y.Y;
			float x3 = z.X;
			float y3 = z.Y;
			float x4 = x.X;
			float y4 = x.Y;
			float x5 = t.X;
			float y5 = t.Y;
			if (!(x2 < (float)width / 2f))
			{
				return new ResultPoint[4]
				{
					new ResultPoint(x5 + 1f, y5 + 1f),
					new ResultPoint(x3 + 1f, y3 - 1f),
					new ResultPoint(x4 - 1f, y4 + 1f),
					new ResultPoint(x2 - 1f, y2 - 1f)
				};
			}
			return new ResultPoint[4]
			{
				new ResultPoint(x5 - 1f, y5 + 1f),
				new ResultPoint(x3 + 1f, y3 + 1f),
				new ResultPoint(x4 - 1f, y4 - 1f),
				new ResultPoint(x2 + 1f, y2 - 1f)
			};
		}

		private bool containsBlackPoint(int a, int b, int @fixed, bool horizontal)
		{
			if (horizontal)
			{
				for (int i = a; i <= b; i++)
				{
					if (image[i, @fixed])
					{
						return true;
					}
				}
			}
			else
			{
				for (int j = a; j <= b; j++)
				{
					if (image[@fixed, j])
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
namespace ZXing.Client.Result
{
	internal abstract class AbstractDoCoMoResultParser : ResultParser
	{
		internal static string[] matchDoCoMoPrefixedField(string prefix, string rawText, bool trim)
		{
			return ResultParser.matchPrefixedField(prefix, rawText, ';', trim);
		}

		internal static string matchSingleDoCoMoPrefixedField(string prefix, string rawText, bool trim)
		{
			return ResultParser.matchSinglePrefixedField(prefix, rawText, ';', trim);
		}
	}
	internal sealed class AddressBookAUResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || text.IndexOf("MEMORY") < 0 || text.IndexOf("\r\n") < 0)
			{
				return null;
			}
			string value = ResultParser.matchSinglePrefixedField("NAME1:", text, '\r', trim: true);
			string pronunciation = ResultParser.matchSinglePrefixedField("NAME2:", text, '\r', trim: true);
			string[] phoneNumbers = matchMultipleValuePrefix("TEL", 3, text, trim: true);
			string[] emails = matchMultipleValuePrefix("MAIL", 3, text, trim: true);
			string note = ResultParser.matchSinglePrefixedField("MEMORY:", text, '\r', trim: false);
			string text2 = ResultParser.matchSinglePrefixedField("ADD:", text, '\r', trim: true);
			string[] addresses = ((text2 == null) ? null : new string[1] { text2 });
			return new AddressBookParsedResult(ResultParser.maybeWrap(value), null, pronunciation, phoneNumbers, null, emails, null, null, note, addresses, null, null, null, null, null, null);
		}

		private static string[] matchMultipleValuePrefix(string prefix, int max, string rawText, bool trim)
		{
			IList<string> list = null;
			for (int i = 1; i <= max; i++)
			{
				string text = ResultParser.matchSinglePrefixedField(prefix + i + ":", rawText, '\r', trim);
				if (text == null)
				{
					break;
				}
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(text);
			}
			if (list == null)
			{
				return null;
			}
			return SupportClass.toStringArray(list);
		}
	}
	internal sealed class AddressBookDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || !text.StartsWith("MECARD:"))
			{
				return null;
			}
			string[] array = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("N:", text, trim: true);
			if (array == null)
			{
				return null;
			}
			string value = parseName(array[0]);
			string pronunciation = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("SOUND:", text, trim: true);
			string[] phoneNumbers = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("TEL:", text, trim: true);
			string[] emails = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("EMAIL:", text, trim: true);
			string note = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("NOTE:", text, trim: false);
			string[] addresses = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("ADR:", text, trim: true);
			string text2 = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("BDAY:", text, trim: true);
			if (!ResultParser.isStringOfDigits(text2, 8))
			{
				text2 = null;
			}
			return new AddressBookParsedResult(urls: AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("URL:", text, trim: true), org: AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("ORG:", text, trim: true), names: ResultParser.maybeWrap(value), nicknames: null, pronunciation: pronunciation, phoneNumbers: phoneNumbers, phoneTypes: null, emails: emails, emailTypes: null, instantMessenger: null, note: note, addresses: addresses, addressTypes: null, birthday: text2, title: null, geo: null);
		}

		private static string parseName(string name)
		{
			int num = name.IndexOf(',');
			if (num >= 0)
			{
				return name.Substring(num + 1) + " " + name.Substring(0, num);
			}
			return name;
		}
	}
	public sealed class AddressBookParsedResult : ParsedResult
	{
		private readonly string[] names;

		private readonly string[] nicknames;

		private readonly string pronunciation;

		private readonly string[] phoneNumbers;

		private readonly string[] phoneTypes;

		private readonly string[] emails;

		private readonly string[] emailTypes;

		private readonly string instantMessenger;

		private readonly string note;

		private readonly string[] addresses;

		private readonly string[] addressTypes;

		private readonly string org;

		private readonly string birthday;

		private readonly string title;

		private readonly string[] urls;

		private readonly string[] geo;

		public string[] Names => names;

		public string[] Nicknames => nicknames;

		public string Pronunciation => pronunciation;

		public string[] PhoneNumbers => phoneNumbers;

		public string[] PhoneTypes => phoneTypes;

		public string[] Emails => emails;

		public string[] EmailTypes => emailTypes;

		public string InstantMessenger => instantMessenger;

		public string Note => note;

		public string[] Addresses => addresses;

		public string[] AddressTypes => addressTypes;

		public string Title => title;

		public string Org => org;

		public string[] URLs => urls;

		public string Birthday => birthday;

		public string[] Geo => geo;

		public AddressBookParsedResult(string[] names, string[] phoneNumbers, string[] phoneTypes, string[] emails, string[] emailTypes, string[] addresses, string[] addressTypes)
			: this(names, null, null, phoneNumbers, phoneTypes, emails, emailTypes, null, null, addresses, addressTypes, null, null, null, null, null)
		{
		}

		public AddressBookParsedResult(string[] names, string[] nicknames, string pronunciation, string[] phoneNumbers, string[] phoneTypes, string[] emails, string[] emailTypes, string instantMessenger, string note, string[] addresses, string[] addressTypes, string org, string birthday, string title, string[] urls, string[] geo)
			: base(ParsedResultType.ADDRESSBOOK)
		{
			if (phoneNumbers != null && phoneTypes != null && phoneNumbers.Length != phoneTypes.Length)
			{
				throw new ArgumentException("Phone numbers and types lengths differ");
			}
			if (emails != null && emailTypes != null && emails.Length != emailTypes.Length)
			{
				throw new ArgumentException("Emails and types lengths differ");
			}
			if (addresses != null && addressTypes != null && addresses.Length != addressTypes.Length)
			{
				throw new ArgumentException("Addresses and types lengths differ");
			}
			this.names = names;
			this.nicknames = nicknames;
			this.pronunciation = pronunciation;
			this.phoneNumbers = phoneNumbers;
			this.phoneTypes = phoneTypes;
			this.emails = emails;
			this.emailTypes = emailTypes;
			this.instantMessenger = instantMessenger;
			this.note = note;
			this.addresses = addresses;
			this.addressTypes = addressTypes;
			this.org = org;
			this.birthday = birthday;
			this.title = title;
			this.urls = urls;
			this.geo = geo;
			displayResultValue = getDisplayResult();
		}

		private string getDisplayResult()
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			ParsedResult.maybeAppend(names, stringBuilder);
			ParsedResult.maybeAppend(nicknames, stringBuilder);
			ParsedResult.maybeAppend(pronunciation, stringBuilder);
			ParsedResult.maybeAppend(title, stringBuilder);
			ParsedResult.maybeAppend(org, stringBuilder);
			ParsedResult.maybeAppend(addresses, stringBuilder);
			ParsedResult.maybeAppend(phoneNumbers, stringBuilder);
			ParsedResult.maybeAppend(emails, stringBuilder);
			ParsedResult.maybeAppend(instantMessenger, stringBuilder);
			ParsedResult.maybeAppend(urls, stringBuilder);
			ParsedResult.maybeAppend(birthday, stringBuilder);
			ParsedResult.maybeAppend(geo, stringBuilder);
			ParsedResult.maybeAppend(note, stringBuilder);
			return stringBuilder.ToString();
		}
	}
	internal sealed class BizcardResultParser : AbstractDoCoMoResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || !text.StartsWith("BIZCARD:"))
			{
				return null;
			}
			string firstName = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("N:", text, trim: true);
			string lastName = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("X:", text, trim: true);
			string value = buildName(firstName, lastName);
			string title = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("T:", text, trim: true);
			string org = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("C:", text, trim: true);
			string[] addresses = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("A:", text, trim: true);
			string number = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("B:", text, trim: true);
			string number2 = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("M:", text, trim: true);
			string number3 = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("F:", text, trim: true);
			return new AddressBookParsedResult(emails: ResultParser.maybeWrap(AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("E:", text, trim: true)), names: ResultParser.maybeWrap(value), nicknames: null, pronunciation: null, phoneNumbers: buildPhoneNumbers(number, number2, number3), phoneTypes: null, emailTypes: null, instantMessenger: null, note: null, addresses: addresses, addressTypes: null, org: org, birthday: null, title: title, urls: null, geo: null);
		}

		private static string[] buildPhoneNumbers(string number1, string number2, string number3)
		{
			List<string> list = new List<string>();
			if (number1 != null)
			{
				list.Add(number1);
			}
			if (number2 != null)
			{
				list.Add(number2);
			}
			if (number3 != null)
			{
				list.Add(number3);
			}
			if (list.Count == 0)
			{
				return null;
			}
			return SupportClass.toStringArray(list);
		}

		private static string buildName(string firstName, string lastName)
		{
			if (firstName == null)
			{
				return lastName;
			}
			if (lastName != null)
			{
				return firstName + " " + lastName;
			}
			return firstName;
		}
	}
	internal sealed class BookmarkDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || !text.StartsWith("MEBKM:"))
			{
				return null;
			}
			string title = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("TITLE:", text, trim: true);
			string[] array = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("URL:", text, trim: true);
			if (array == null)
			{
				return null;
			}
			string uri = array[0];
			if (!URIResultParser.isBasicallyValidURI(uri))
			{
				return null;
			}
			return new URIParsedResult(uri, title);
		}
	}
	public sealed class CalendarParsedResult : ParsedResult
	{
		private static readonly Regex RFC2445_DURATION = new Regex("\\A(?:P(?:(\\d+)W)?(?:(\\d+)D)?(?:T(?:(\\d+)H)?(?:(\\d+)M)?(?:(\\d+)S)?)?)\\z");

		private static readonly long[] RFC2445_DURATION_FIELD_UNITS = new long[5] { 604800000L, 86400000L, 3600000L, 60000L, 1000L };

		private static readonly Regex DATE_TIME = new Regex("\\A(?:[0-9]{8}(T[0-9]{6}Z?)?)\\z");

		private readonly string summary;

		private readonly DateTime start;

		private readonly bool startAllDay;

		private readonly DateTime? end;

		private readonly bool endAllDay;

		private readonly string location;

		private readonly string organizer;

		private readonly string[] attendees;

		private readonly string description;

		private readonly double latitude;

		private readonly double longitude;

		public string Summary => summary;

		public DateTime Start => start;

		public DateTime? End => end;

		public bool isEndAllDay => endAllDay;

		public string Location => location;

		public string Organizer => organizer;

		public string[] Attendees => attendees;

		public string Description => description;

		public double Latitude => latitude;

		public double Longitude => longitude;

		public CalendarParsedResult(string summary, string startString, string endString, string durationString, string location, string organizer, string[] attendees, string description, double latitude, double longitude)
			: base(ParsedResultType.CALENDAR)
		{
			this.summary = summary;
			try
			{
				start = parseDate(startString);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.ToString());
			}
			if (endString == null)
			{
				long num = parseDurationMS(durationString);
				end = ((num < 0) ? ((DateTime?)null) : new DateTime?(start + new TimeSpan(0, 0, 0, 0, (int)num)));
			}
			else
			{
				try
				{
					end = parseDate(endString);
				}
				catch (Exception ex2)
				{
					throw new ArgumentException(ex2.ToString());
				}
			}
			startAllDay = startString.Length == 8;
			endAllDay = endString != null && endString.Length == 8;
			this.location = location;
			this.organizer = organizer;
			this.attendees = attendees;
			this.description = description;
			this.latitude = latitude;
			this.longitude = longitude;
			StringBuilder stringBuilder = new StringBuilder(100);
			ParsedResult.maybeAppend(summary, stringBuilder);
			ParsedResult.maybeAppend(format(startAllDay, start), stringBuilder);
			ParsedResult.maybeAppend(format(endAllDay, end), stringBuilder);
			ParsedResult.maybeAppend(location, stringBuilder);
			ParsedResult.maybeAppend(organizer, stringBuilder);
			ParsedResult.maybeAppend(attendees, stringBuilder);
			ParsedResult.maybeAppend(description, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}

		public bool isStartAllDay()
		{
			return startAllDay;
		}

		private static DateTime parseDate(string when)
		{
			if (!DATE_TIME.Match(when).Success)
			{
				throw new ArgumentException($"no date format: {when}");
			}
			if (when.Length == 8)
			{
				return DateTime.ParseExact(when, "yyyyMMdd", CultureInfo.InvariantCulture);
			}
			if (when.Length == 16 && when[15] == 'Z')
			{
				return TimeZoneInfo.ConvertTime(parseDateTimeString(when.Substring(0, 15)), TimeZoneInfo.Local);
			}
			return parseDateTimeString(when);
		}

		private static string format(bool allDay, DateTime? date)
		{
			if (!date.HasValue)
			{
				return null;
			}
			if (allDay)
			{
				return date.Value.ToString("D", CultureInfo.CurrentCulture);
			}
			return date.Value.ToString("F", CultureInfo.CurrentCulture);
		}

		private static long parseDurationMS(string durationString)
		{
			if (durationString == null)
			{
				return -1L;
			}
			Match match = RFC2445_DURATION.Match(durationString);
			if (!match.Success)
			{
				return -1L;
			}
			long num = 0L;
			for (int i = 0; i < RFC2445_DURATION_FIELD_UNITS.Length; i++)
			{
				string value = match.Groups[i + 1].Value;
				if (!string.IsNullOrEmpty(value))
				{
					num += RFC2445_DURATION_FIELD_UNITS[i] * int.Parse(value);
				}
			}
			return num;
		}

		private static DateTime parseDateTimeString(string dateTimeString)
		{
			return DateTime.ParseExact(dateTimeString, "yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture);
		}
	}
	public sealed class EmailAddressParsedResult : ParsedResult
	{
		public string EmailAddress
		{
			get
			{
				if (Tos != null && Tos.Length != 0)
				{
					return Tos[0];
				}
				return null;
			}
		}

		public string[] Tos { get; private set; }

		public string[] CCs { get; private set; }

		public string[] BCCs { get; private set; }

		public string Subject { get; private set; }

		public string Body { get; private set; }

		[Obsolete("deprecated without replacement")]
		public string MailtoURI => "mailto:";

		internal EmailAddressParsedResult(string to)
			: this(new string[1] { to }, null, null, null, null)
		{
		}

		internal EmailAddressParsedResult(string[] tos, string[] ccs, string[] bccs, string subject, string body)
			: base(ParsedResultType.EMAIL_ADDRESS)
		{
			Tos = tos;
			CCs = ccs;
			BCCs = bccs;
			Subject = subject;
			Body = body;
			StringBuilder stringBuilder = new StringBuilder(30);
			ParsedResult.maybeAppend(Tos, stringBuilder);
			ParsedResult.maybeAppend(CCs, stringBuilder);
			ParsedResult.maybeAppend(BCCs, stringBuilder);
			ParsedResult.maybeAppend(Subject, stringBuilder);
			ParsedResult.maybeAppend(Body, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}
	}
	internal sealed class EmailAddressResultParser : ResultParser
	{
		private static readonly Regex COMMA = new Regex(",");

		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null)
			{
				return null;
			}
			if (text.ToLower().StartsWith("mailto:"))
			{
				string text2 = text.Substring(7);
				int num = text2.IndexOf('?');
				if (num >= 0)
				{
					text2 = text2.Substring(0, num);
				}
				text2 = ResultParser.urlDecode(text2);
				string[] array = null;
				if (!string.IsNullOrEmpty(text2))
				{
					array = COMMA.Split(text2);
				}
				IDictionary<string, string> dictionary = ResultParser.parseNameValuePairs(text);
				string[] ccs = null;
				string[] bccs = null;
				string value = null;
				string value2 = null;
				if (dictionary != null)
				{
					if (array == null && dictionary.TryGetValue("to", out var value3) && value3 != null)
					{
						array = COMMA.Split(value3);
					}
					if (dictionary.TryGetValue("cc", out var value4) && value4 != null)
					{
						ccs = COMMA.Split(value4);
					}
					if (dictionary.TryGetValue("bcc", out var value5) && value5 != null)
					{
						bccs = COMMA.Split(value5);
					}
					dictionary.TryGetValue("subject", out value);
					dictionary.TryGetValue("body", out value2);
				}
				return new EmailAddressParsedResult(array, ccs, bccs, value, value2);
			}
			if (!EmailDoCoMoResultParser.isBasicallyValidEmailAddress(text))
			{
				return null;
			}
			return new EmailAddressParsedResult(text);
		}
	}
	internal sealed class EmailDoCoMoResultParser : AbstractDoCoMoResultParser
	{
		private static readonly Regex ATEXT_ALPHANUMERIC = new Regex("\\A(?:[a-zA-Z0-9@.!#$%&'*+\\-/=?^_`{|}~]+)\\z");

		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (!text.StartsWith("MATMSG:"))
			{
				return null;
			}
			string[] array = AbstractDoCoMoResultParser.matchDoCoMoPrefixedField("TO:", text, trim: true);
			if (array == null)
			{
				return null;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!isBasicallyValidEmailAddress(array[i]))
				{
					return null;
				}
			}
			string subject = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("SUB:", text, trim: false);
			string body = AbstractDoCoMoResultParser.matchSingleDoCoMoPrefixedField("BODY:", text, trim: false);
			return new EmailAddressParsedResult(array, null, null, subject, body);
		}

		internal static bool isBasicallyValidEmailAddress(string email)
		{
			if (email != null && ATEXT_ALPHANUMERIC.Match(email).Success)
			{
				return email.IndexOf('@') >= 0;
			}
			return false;
		}
	}
	public class ExpandedProductParsedResult : ParsedResult
	{
		public static string KILOGRAM = "KG";

		public static string POUND = "LB";

		private readonly string rawText;

		private readonly string productID;

		private readonly string sscc;

		private readonly string lotNumber;

		private readonly string productionDate;

		private readonly string packagingDate;

		private readonly string bestBeforeDate;

		private readonly string expirationDate;

		private readonly string weight;

		private readonly string weightType;

		private readonly string weightIncrement;

		private readonly string price;

		private readonly string priceIncrement;

		private readonly string priceCurrency;

		private readonly IDictionary<string, string> uncommonAIs;

		public string RawText => rawText;

		public string ProductID => productID;

		public string Sscc => sscc;

		public string LotNumber => lotNumber;

		public string ProductionDate => productionDate;

		public string PackagingDate => packagingDate;

		public string BestBeforeDate => bestBeforeDate;

		public string ExpirationDate => expirationDate;

		public string Weight => weight;

		public string WeightType => weightType;

		public string WeightIncrement => weightIncrement;

		public string Price => price;

		public string PriceIncrement => priceIncrement;

		public string PriceCurrency => priceCurrency;

		public IDictionary<string, string> UncommonAIs => uncommonAIs;

		public override string DisplayResult => rawText;

		public ExpandedProductParsedResult(string rawText, string productID, string sscc, string lotNumber, string productionDate, string packagingDate, string bestBeforeDate, string expirationDate, string weight, string weightType, string weightIncrement, string price, string priceIncrement, string priceCurrency, IDictionary<string, string> uncommonAIs)
			: base(ParsedResultType.PRODUCT)
		{
			this.rawText = rawText;
			this.productID = productID;
			this.sscc = sscc;
			this.lotNumber = lotNumber;
			this.productionDate = productionDate;
			this.packagingDate = packagingDate;
			this.bestBeforeDate = bestBeforeDate;
			this.expirationDate = expirationDate;
			this.weight = weight;
			this.weightType = weightType;
			this.weightIncrement = weightIncrement;
			this.price = price;
			this.priceIncrement = priceIncrement;
			this.priceCurrency = priceCurrency;
			this.uncommonAIs = uncommonAIs;
			displayResultValue = productID;
		}

		public override bool Equals(object o)
		{
			if (!(o is ExpandedProductParsedResult))
			{
				return false;
			}
			ExpandedProductParsedResult expandedProductParsedResult = (ExpandedProductParsedResult)o;
			if (equalsOrNull(productID, expandedProductParsedResult.productID) && equalsOrNull(sscc, expandedProductParsedResult.sscc) && equalsOrNull(lotNumber, expandedProductParsedResult.lotNumber) && equalsOrNull(productionDate, expandedProductParsedResult.productionDate) && equalsOrNull(bestBeforeDate, expandedProductParsedResult.bestBeforeDate) && equalsOrNull(expirationDate, expandedProductParsedResult.expirationDate) && equalsOrNull(weight, expandedProductParsedResult.weight) && equalsOrNull(weightType, expandedProductParsedResult.weightType) && equalsOrNull(weightIncrement, expandedProductParsedResult.weightIncrement) && equalsOrNull(price, expandedProductParsedResult.price) && equalsOrNull(priceIncrement, expandedProductParsedResult.priceIncrement) && equalsOrNull(priceCurrency, expandedProductParsedResult.priceCurrency))
			{
				return equalsOrNull(uncommonAIs, expandedProductParsedResult.uncommonAIs);
			}
			return false;
		}

		private static bool equalsOrNull(object o1, object o2)
		{
			return o1?.Equals(o2) ?? (o2 == null);
		}

		private static bool equalsOrNull(IDictionary<string, string> o1, IDictionary<string, string> o2)
		{
			if (o1 == null)
			{
				return o2 == null;
			}
			if (o1.Count != o2.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, string> item in o1)
			{
				if (!o2.ContainsKey(item.Key))
				{
					return false;
				}
				if (!item.Value.Equals(o2[item.Key]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return 0 ^ hashNotNull(productID) ^ hashNotNull(sscc) ^ hashNotNull(lotNumber) ^ hashNotNull(productionDate) ^ hashNotNull(bestBeforeDate) ^ hashNotNull(expirationDate) ^ hashNotNull(weight) ^ hashNotNull(weightType) ^ hashNotNull(weightIncrement) ^ hashNotNull(price) ^ hashNotNull(priceIncrement) ^ hashNotNull(priceCurrency) ^ hashNotNull(uncommonAIs);
		}

		private static int hashNotNull(object o)
		{
			return o?.GetHashCode() ?? 0;
		}
	}
	public class ExpandedProductResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			if (result.BarcodeFormat != BarcodeFormat.RSS_EXPANDED)
			{
				return null;
			}
			string text = result.Text;
			string productID = null;
			string sscc = null;
			string lotNumber = null;
			string productionDate = null;
			string packagingDate = null;
			string bestBeforeDate = null;
			string expirationDate = null;
			string weight = null;
			string weightType = null;
			string weightIncrement = null;
			string price = null;
			string priceIncrement = null;
			string priceCurrency = null;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = 0;
			while (num < text.Length)
			{
				string text2 = findAIvalue(num, text);
				if (text2 == null)
				{
					return null;
				}
				num += text2.Length + 2;
				string text3 = findValue(num, text);
				num += text3.Length;
				if ("00".Equals(text2))
				{
					sscc = text3;
				}
				else if ("01".Equals(text2))
				{
					productID = text3;
				}
				else if ("10".Equals(text2))
				{
					lotNumber = text3;
				}
				else if ("11".Equals(text2))
				{
					productionDate = text3;
				}
				else if ("13".Equals(text2))
				{
					packagingDate = text3;
				}
				else if ("15".Equals(text2))
				{
					bestBeforeDate = text3;
				}
				else if ("17".Equals(text2))
				{
					expirationDate = text3;
				}
				else if ("3100".Equals(text2) || "3101".Equals(text2) || "3102".Equals(text2) || "3103".Equals(text2) || "3104".Equals(text2) || "3105".Equals(text2) || "3106".Equals(text2) || "3107".Equals(text2) || "3108".Equals(text2) || "3109".Equals(text2))
				{
					weight = text3;
					weightType = ExpandedProductParsedResult.KILOGRAM;
					weightIncrement = text2.Substring(3);
				}
				else if ("3200".Equals(text2) || "3201".Equals(text2) || "3202".Equals(text2) || "3203".Equals(text2) || "3204".Equals(text2) || "3205".Equals(text2) || "3206".Equals(text2) || "3207".Equals(text2) || "3208".Equals(text2) || "3209".Equals(text2))
				{
					weight = text3;
					weightType = ExpandedProductParsedResult.POUND;
					weightIncrement = text2.Substring(3);
				}
				else if ("3920".Equals(text2) || "3921".Equals(text2) || "3922".Equals(text2) || "3923".Equals(text2))
				{
					price = text3;
					priceIncrement = text2.Substring(3);
				}
				else if ("3930".Equals(text2) || "3931".Equals(text2) || "3932".Equals(text2) || "3933".Equals(text2))
				{
					if (text3.Length < 4)
					{
						return null;
					}
					price = text3.Substring(3);
					priceCurrency = text3.Substring(0, 3);
					priceIncrement = text2.Substring(3);
				}
				else
				{
					dictionary[text2] = text3;
				}
			}
			return new ExpandedProductParsedResult(text, productID, sscc, lotNumber, productionDate, packagingDate, bestBeforeDate, expirationDate, weight, weightType, weightIncrement, price, priceIncrement, priceCurrency, dictionary);
		}

		private static string findAIvalue(int i, string rawText)
		{
			if (rawText[i] != '(')
			{
				return null;
			}
			string text = rawText.Substring(i + 1);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in text)
			{
				switch (c)
				{
				case ')':
					return stringBuilder.ToString();
				default:
					return null;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					break;
				}
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		private static string findValue(int i, string rawText)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = rawText.Substring(i);
			for (int j = 0; j < text.Length; j++)
			{
				char c = text[j];
				if (c == '(')
				{
					if (findAIvalue(j, text) != null)
					{
						break;
					}
					stringBuilder.Append('(');
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
	public sealed class GeoParsedResult : ParsedResult
	{
		public double Latitude { get; private set; }

		public double Longitude { get; private set; }

		public double Altitude { get; private set; }

		public string Query { get; private set; }

		public string GeoURI { get; private set; }

		public string GoogleMapsURI { get; private set; }

		internal GeoParsedResult(double latitude, double longitude, double altitude, string query)
			: base(ParsedResultType.GEO)
		{
			Latitude = latitude;
			Longitude = longitude;
			Altitude = altitude;
			Query = query;
			GeoURI = getGeoURI();
			GoogleMapsURI = getGoogleMapsURI();
			displayResultValue = getDisplayResult();
		}

		private string getDisplayResult()
		{
			StringBuilder stringBuilder = new StringBuilder(20);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Latitude });
			stringBuilder.Append(", ");
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Longitude });
			if (Altitude > 0.0)
			{
				stringBuilder.Append(", ");
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Altitude });
				stringBuilder.Append('m');
			}
			if (Query != null)
			{
				stringBuilder.Append(" (");
				stringBuilder.Append(Query);
				stringBuilder.Append(')');
			}
			return stringBuilder.ToString();
		}

		private string getGeoURI()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("geo:");
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Latitude });
			stringBuilder.Append(',');
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Longitude });
			if (Altitude > 0.0)
			{
				stringBuilder.Append(',');
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Altitude });
			}
			if (Query != null)
			{
				stringBuilder.Append('?');
				stringBuilder.Append(Query);
			}
			return stringBuilder.ToString();
		}

		private string getGoogleMapsURI()
		{
			StringBuilder stringBuilder = new StringBuilder(50);
			stringBuilder.Append("http://maps.google.com/?ll=");
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Latitude });
			stringBuilder.Append(',');
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:0.0###########}", new object[1] { Longitude });
			if (Altitude > 0.0)
			{
				int num = (int)(Altitude * 3.28 / 1000.0);
				int num2 = 0;
				while (num > 1 && num2 < 18)
				{
					num >>= 1;
					num2++;
				}
				int value = 19 - num2;
				stringBuilder.Append("&z=");
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}
	}
	internal sealed class GeoResultParser : ResultParser
	{
		private static readonly Regex GEO_URL_PATTERN = new Regex("\\A(?:geo:([\\-0-9.]+),([\\-0-9.]+)(?:,([\\-0-9.]+))?(?:\\?(.*))?)\\z", RegexOptions.IgnoreCase);

		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null)
			{
				return null;
			}
			Match match = GEO_URL_PATTERN.Match(text);
			if (!match.Success)
			{
				return null;
			}
			string text2 = match.Groups[4].Value;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = null;
			}
			double result2 = 0.0;
			if (!double.TryParse(match.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result3))
			{
				return null;
			}
			if (result3 > 90.0 || result3 < -90.0)
			{
				return null;
			}
			if (!double.TryParse(match.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result4))
			{
				return null;
			}
			if (result4 > 180.0 || result4 < -180.0)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(match.Groups[3].Value))
			{
				if (!double.TryParse(match.Groups[3].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result2))
				{
					return null;
				}
				if (result2 < 0.0)
				{
					return null;
				}
			}
			return new GeoParsedResult(result3, result4, result2, text2);
		}
	}
	public sealed class ISBNParsedResult : ParsedResult
	{
		public string ISBN { get; private set; }

		internal ISBNParsedResult(string isbn)
			: base(ParsedResultType.ISBN)
		{
			ISBN = isbn;
			displayResultValue = isbn;
		}
	}
	public class ISBNResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			if (result.BarcodeFormat != BarcodeFormat.EAN_13)
			{
				return null;
			}
			string text = result.Text;
			if (text.Length != 13)
			{
				return null;
			}
			if (!text.StartsWith("978") && !text.StartsWith("979"))
			{
				return null;
			}
			return new ISBNParsedResult(text);
		}
	}
	public abstract class ParsedResult
	{
		protected string displayResultValue;

		public virtual ParsedResultType Type { get; private set; }

		public virtual string DisplayResult => displayResultValue;

		protected ParsedResult(ParsedResultType type)
		{
			Type = type;
		}

		public override string ToString()
		{
			return DisplayResult;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ParsedResult { Type: var type } parsedResult))
			{
				return false;
			}
			if (type.Equals(Type))
			{
				return parsedResult.DisplayResult.Equals(DisplayResult);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Type.GetHashCode() + DisplayResult.GetHashCode();
		}

		public static void maybeAppend(string value, StringBuilder result)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (result.Length > 0)
				{
					result.Append('\n');
				}
				result.Append(value);
			}
		}

		public static void maybeAppend(string[] values, StringBuilder result)
		{
			if (values != null)
			{
				for (int i = 0; i < values.Length; i++)
				{
					maybeAppend(values[i], result);
				}
			}
		}
	}
	public enum ParsedResultType
	{
		ADDRESSBOOK,
		EMAIL_ADDRESS,
		PRODUCT,
		URI,
		TEXT,
		GEO,
		TEL,
		SMS,
		CALENDAR,
		WIFI,
		ISBN,
		VIN
	}
	public sealed class ProductParsedResult : ParsedResult
	{
		public string ProductID { get; private set; }

		public string NormalizedProductID { get; private set; }

		internal ProductParsedResult(string productID)
			: this(productID, productID)
		{
		}

		internal ProductParsedResult(string productID, string normalizedProductID)
			: base(ParsedResultType.PRODUCT)
		{
			ProductID = productID;
			NormalizedProductID = normalizedProductID;
			displayResultValue = productID;
		}
	}
	internal sealed class ProductResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			BarcodeFormat barcodeFormat = result.BarcodeFormat;
			if (barcodeFormat != BarcodeFormat.UPC_A && barcodeFormat != BarcodeFormat.UPC_E && barcodeFormat != BarcodeFormat.EAN_8 && barcodeFormat != BarcodeFormat.EAN_13)
			{
				return null;
			}
			string text = result.Text;
			if (text == null)
			{
				return null;
			}
			if (!ResultParser.isStringOfDigits(text, text.Length))
			{
				return null;
			}
			string normalizedProductID = ((barcodeFormat != BarcodeFormat.UPC_E || text.Length != 8) ? text : UPCEReader.convertUPCEtoUPCA(text));
			return new ProductParsedResult(text, normalizedProductID);
		}
	}
	public abstract class ResultParser
	{
		private static readonly ResultParser[] PARSERS = new ResultParser[20]
		{
			new BookmarkDoCoMoResultParser(),
			new AddressBookDoCoMoResultParser(),
			new EmailDoCoMoResultParser(),
			new AddressBookAUResultParser(),
			new VCardResultParser(),
			new BizcardResultParser(),
			new VEventResultParser(),
			new EmailAddressResultParser(),
			new SMTPResultParser(),
			new TelResultParser(),
			new SMSMMSResultParser(),
			new SMSTOMMSTOResultParser(),
			new GeoResultParser(),
			new WifiResultParser(),
			new URLTOResultParser(),
			new URIResultParser(),
			new ISBNResultParser(),
			new ProductResultParser(),
			new ExpandedProductResultParser(),
			new VINResultParser()
		};

		private static readonly Regex DIGITS = new Regex("\\A(?:\\d+)\\z");

		private static readonly Regex AMPERSAND = new Regex("&");

		private static readonly Regex EQUALS = new Regex("=");

		public abstract ParsedResult parse(ZXing.Result theResult);

		public static ParsedResult parseResult(ZXing.Result theResult)
		{
			ResultParser[] pARSERS = PARSERS;
			for (int i = 0; i < pARSERS.Length; i++)
			{
				ParsedResult parsedResult = pARSERS[i].parse(theResult);
				if (parsedResult != null)
				{
					return parsedResult;
				}
			}
			return new TextParsedResult(theResult.Text, null);
		}

		protected static void maybeAppend(string value, StringBuilder result)
		{
			if (value != null)
			{
				result.Append('\n');
				result.Append(value);
			}
		}

		protected static void maybeAppend(string[] value, StringBuilder result)
		{
			if (value != null)
			{
				for (int i = 0; i < value.Length; i++)
				{
					result.Append('\n');
					result.Append(value[i]);
				}
			}
		}

		protected static string[] maybeWrap(string value)
		{
			if (value != null)
			{
				return new string[1] { value };
			}
			return null;
		}

		protected static string unescapeBackslash(string escaped)
		{
			if (escaped != null)
			{
				int num = escaped.IndexOf('\\');
				if (num >= 0)
				{
					int length = escaped.Length;
					StringBuilder stringBuilder = new StringBuilder(length - 1);
					stringBuilder.Append(escaped.ToCharArray(), 0, num);
					bool flag = false;
					for (int i = num; i < length; i++)
					{
						char c = escaped[i];
						if (flag || c != '\\')
						{
							stringBuilder.Append(c);
							flag = false;
						}
						else
						{
							flag = true;
						}
					}
					return stringBuilder.ToString();
				}
			}
			return escaped;
		}

		protected static int parseHexDigit(char c)
		{
			switch (c)
			{
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
				return 10 + (c - 97);
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
				return 10 + (c - 65);
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return c - 48;
			default:
				return -1;
			}
		}

		internal static bool isStringOfDigits(string value, int length)
		{
			if (value != null && length > 0 && length == value.Length)
			{
				return DIGITS.Match(value).Success;
			}
			return false;
		}

		internal static bool isSubstringOfDigits(string value, int offset, int length)
		{
			if (value == null || length <= 0)
			{
				return false;
			}
			int num = offset + length;
			if (value.Length >= num)
			{
				return DIGITS.Match(value, offset, length).Success;
			}
			return false;
		}

		internal static IDictionary<string, string> parseNameValuePairs(string uri)
		{
			int num = uri.IndexOf('?');
			if (num < 0)
			{
				return null;
			}
			Dictionary<string, string> result = new Dictionary<string, string>(3);
			string[] array = AMPERSAND.Split(uri.Substring(num + 1));
			for (int i = 0; i < array.Length; i++)
			{
				appendKeyValue(array[i], result);
			}
			return result;
		}

		private static void appendKeyValue(string keyValue, IDictionary<string, string> result)
		{
			string[] array = EQUALS.Split(keyValue, 2);
			if (array.Length == 2)
			{
				string key = array[0];
				string escaped = array[1];
				try
				{
					escaped = (result[key] = urlDecode(escaped));
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException("url decoding failed", innerException);
				}
				result[key] = escaped;
			}
		}

		internal static string[] matchPrefixedField(string prefix, string rawText, char endChar, bool trim)
		{
			IList<string> list = null;
			int num = 0;
			int length = rawText.Length;
			while (num < length)
			{
				num = rawText.IndexOf(prefix, num);
				if (num < 0)
				{
					break;
				}
				num += prefix.Length;
				int num2 = num;
				bool flag = false;
				while (!flag)
				{
					num = rawText.IndexOf(endChar, num);
					if (num < 0)
					{
						num = rawText.Length;
						flag = true;
						continue;
					}
					if (countPrecedingBackslashes(rawText, num) % 2 != 0)
					{
						num++;
						continue;
					}
					if (list == null)
					{
						list = new List<string>();
					}
					string text = unescapeBackslash(rawText.Substring(num2, num - num2));
					if (trim)
					{
						text = text.Trim();
					}
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
					num++;
					flag = true;
				}
			}
			if (list == null || list.Count == 0)
			{
				return null;
			}
			return SupportClass.toStringArray(list);
		}

		private static int countPrecedingBackslashes(string s, int pos)
		{
			int num = 0;
			int num2 = pos - 1;
			while (num2 >= 0 && s[num2] == '\\')
			{
				num++;
				num2--;
			}
			return num;
		}

		internal static string matchSinglePrefixedField(string prefix, string rawText, char endChar, bool trim)
		{
			string[] array = matchPrefixedField(prefix, rawText, endChar, trim);
			if (array != null)
			{
				return array[0];
			}
			return null;
		}

		protected static string urlDecode(string escaped)
		{
			if (escaped == null)
			{
				return null;
			}
			char[] array = escaped.ToCharArray();
			int num = findFirstEscape(array);
			if (num < 0)
			{
				return escaped;
			}
			int num2 = array.Length;
			StringBuilder stringBuilder = new StringBuilder(num2 - 2);
			stringBuilder.Append(array, 0, num);
			for (int i = num; i < num2; i++)
			{
				char c = array[i];
				switch (c)
				{
				case '+':
					stringBuilder.Append(' ');
					break;
				case '%':
				{
					if (i >= num2 - 2)
					{
						stringBuilder.Append('%');
						break;
					}
					int num3 = parseHexDigit(array[++i]);
					int num4 = parseHexDigit(array[++i]);
					if (num3 < 0 || num4 < 0)
					{
						stringBuilder.Append('%');
						stringBuilder.Append(array[i - 1]);
						stringBuilder.Append(array[i]);
					}
					stringBuilder.Append((char)((num3 << 4) + num4));
					break;
				}
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			return stringBuilder.ToString();
		}

		private static int findFirstEscape(char[] escapedArray)
		{
			int num = escapedArray.Length;
			for (int i = 0; i < num; i++)
			{
				char c = escapedArray[i];
				if (c == '+' || c == '%')
				{
					return i;
				}
			}
			return -1;
		}
	}
	internal sealed class SMSMMSResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || (!text.StartsWith("sms:") && !text.StartsWith("SMS:") && !text.StartsWith("mms:") && !text.StartsWith("MMS:")))
			{
				return null;
			}
			IDictionary<string, string> dictionary = ResultParser.parseNameValuePairs(text);
			string subject = null;
			string body = null;
			bool flag = false;
			if (dictionary != null && dictionary.Count != 0)
			{
				subject = dictionary["subject"];
				body = dictionary["body"];
				flag = true;
			}
			int num = text.IndexOf('?', 4);
			string text2 = ((num >= 0 && flag) ? text.Substring(4, num - 4) : text.Substring(4));
			int num2 = -1;
			List<string> list = new List<string>(1);
			List<string> list2 = new List<string>(1);
			int num3;
			while ((num3 = text2.IndexOf(',', num2 + 1)) > num2)
			{
				string numberPart = text2.Substring(num2 + 1, num3);
				addNumberVia(list, list2, numberPart);
				num2 = num3;
			}
			addNumberVia(list, list2, text2.Substring(num2 + 1));
			return new SMSParsedResult(SupportClass.toStringArray(list), SupportClass.toStringArray(list2), subject, body);
		}

		private static void addNumberVia(ICollection<string> numbers, ICollection<string> vias, string numberPart)
		{
			int num = numberPart.IndexOf(';');
			if (num < 0)
			{
				numbers.Add(numberPart);
				vias.Add(null);
				return;
			}
			numbers.Add(numberPart.Substring(0, num));
			string text = numberPart.Substring(num + 1);
			string item = ((!text.StartsWith("via=")) ? null : text.Substring(4));
			vias.Add(item);
		}
	}
	public sealed class SMSParsedResult : ParsedResult
	{
		public string[] Numbers { get; private set; }

		public string[] Vias { get; private set; }

		public string Subject { get; private set; }

		public string Body { get; private set; }

		public string SMSURI { get; private set; }

		public SMSParsedResult(string number, string via, string subject, string body)
			: this(new string[1] { number }, new string[1] { via }, subject, body)
		{
		}

		public SMSParsedResult(string[] numbers, string[] vias, string subject, string body)
			: base(ParsedResultType.SMS)
		{
			Numbers = numbers;
			Vias = vias;
			Subject = subject;
			Body = body;
			SMSURI = getSMSURI();
			StringBuilder stringBuilder = new StringBuilder(100);
			ParsedResult.maybeAppend(Numbers, stringBuilder);
			ParsedResult.maybeAppend(Subject, stringBuilder);
			ParsedResult.maybeAppend(Body, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}

		private string getSMSURI()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("sms:");
			bool flag = true;
			for (int i = 0; i < Numbers.Length; i++)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(Numbers[i]);
				if (Vias != null && Vias[i] != null)
				{
					stringBuilder.Append(";via=");
					stringBuilder.Append(Vias[i]);
				}
			}
			bool flag2 = Body != null;
			bool flag3 = Subject != null;
			if (flag2 || flag3)
			{
				stringBuilder.Append('?');
				if (flag2)
				{
					stringBuilder.Append("body=");
					stringBuilder.Append(Body);
				}
				if (flag3)
				{
					if (flag2)
					{
						stringBuilder.Append('&');
					}
					stringBuilder.Append("subject=");
					stringBuilder.Append(Subject);
				}
			}
			return stringBuilder.ToString();
		}
	}
	public class SMSTOMMSTOResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (!text.StartsWith("smsto:") && !text.StartsWith("SMSTO:") && !text.StartsWith("mmsto:") && !text.StartsWith("MMSTO:"))
			{
				return null;
			}
			string text2 = text.Substring(6);
			string body = null;
			int num = text2.IndexOf(':');
			if (num >= 0)
			{
				body = text2.Substring(num + 1);
				text2 = text2.Substring(0, num);
			}
			return new SMSParsedResult(text2, null, null, body);
		}
	}
	public class SMTPResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (!text.StartsWith("smtp:") && !text.StartsWith("SMTP:"))
			{
				return null;
			}
			string text2 = text.Substring(5);
			string text3 = null;
			string body = null;
			int num = text2.IndexOf(':');
			if (num >= 0)
			{
				text3 = text2.Substring(num + 1);
				text2 = text2.Substring(0, num);
				num = text3.IndexOf(':');
				if (num >= 0)
				{
					body = text3.Substring(num + 1);
					text3 = text3.Substring(0, num);
				}
			}
			return new EmailAddressParsedResult(new string[1] { text2 }, null, null, text3, body);
		}
	}
	public sealed class TelParsedResult : ParsedResult
	{
		public string Number { get; private set; }

		public string TelURI { get; private set; }

		public string Title { get; private set; }

		public TelParsedResult(string number, string telURI, string title)
			: base(ParsedResultType.TEL)
		{
			Number = number;
			TelURI = telURI;
			Title = title;
			StringBuilder stringBuilder = new StringBuilder(20);
			ParsedResult.maybeAppend(number, stringBuilder);
			ParsedResult.maybeAppend(title, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}
	}
	internal sealed class TelResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || (!text.StartsWith("tel:") && !text.StartsWith("TEL:")))
			{
				return null;
			}
			string telURI = (text.StartsWith("TEL:") ? ("tel:" + text.Substring(4)) : text);
			int num = text.IndexOf('?', 4);
			return new TelParsedResult((num < 0) ? text.Substring(4) : text.Substring(4, num - 4), telURI, null);
		}
	}
	public sealed class TextParsedResult : ParsedResult
	{
		public string Text { get; private set; }

		public string Language { get; private set; }

		public TextParsedResult(string text, string language)
			: base(ParsedResultType.TEXT)
		{
			Text = text;
			Language = language;
			displayResultValue = text;
		}
	}
	public sealed class URIParsedResult : ParsedResult
	{
		private static readonly Regex USER_IN_HOST = new Regex(":/*([^/@]+)@[^/]+");

		public string URI { get; private set; }

		public string Title { get; private set; }

		public bool PossiblyMaliciousURI { get; private set; }

		public URIParsedResult(string uri, string title)
			: base(ParsedResultType.URI)
		{
			URI = massageURI(uri);
			Title = title;
			PossiblyMaliciousURI = USER_IN_HOST.Match(URI).Success;
			StringBuilder stringBuilder = new StringBuilder(30);
			ParsedResult.maybeAppend(Title, stringBuilder);
			ParsedResult.maybeAppend(URI, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}

		private static string massageURI(string uri)
		{
			int num = uri.IndexOf(':');
			if (num < 0 || isColonFollowedByPortNumber(uri, num))
			{
				uri = "http://" + uri;
			}
			return uri;
		}

		private static bool isColonFollowedByPortNumber(string uri, int protocolEnd)
		{
			int num = protocolEnd + 1;
			int num2 = uri.IndexOf('/', num);
			if (num2 < 0)
			{
				num2 = uri.Length;
			}
			return ResultParser.isSubstringOfDigits(uri, num, num2 - num);
		}
	}
	internal sealed class URIResultParser : ResultParser
	{
		private static readonly Regex URL_WITH_PROTOCOL_PATTERN = new Regex("[a-zA-Z][a-zA-Z0-9+-.]+:");

		private static readonly Regex URL_WITHOUT_PROTOCOL_PATTERN = new Regex("([a-zA-Z0-9\\-]+\\.){1,6}[a-zA-Z]{2,}(:\\d{1,5})?(/|\\?|$)");

		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text.StartsWith("URL:") || text.StartsWith("URI:"))
			{
				return new URIParsedResult(text.Substring(4).Trim(), null);
			}
			text = text.Trim();
			if (!isBasicallyValidURI(text))
			{
				return null;
			}
			return new URIParsedResult(text, null);
		}

		internal static bool isBasicallyValidURI(string uri)
		{
			if (uri.IndexOf(" ") >= 0)
			{
				return false;
			}
			Match match = URL_WITH_PROTOCOL_PATTERN.Match(uri);
			if (match.Success && match.Index == 0)
			{
				return true;
			}
			match = URL_WITHOUT_PROTOCOL_PATTERN.Match(uri);
			if (match.Success)
			{
				return match.Index == 0;
			}
			return false;
		}
	}
	internal sealed class URLTOResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null || (!text.StartsWith("urlto:") && !text.StartsWith("URLTO:")))
			{
				return null;
			}
			int num = text.IndexOf(':', 6);
			if (num < 0)
			{
				return null;
			}
			string title = ((num <= 6) ? null : text.Substring(6, num - 6));
			return new URIParsedResult(text.Substring(num + 1), title);
		}
	}
	internal sealed class VCardResultParser : ResultParser
	{
		private static readonly Regex BEGIN_VCARD = new Regex("BEGIN:VCARD", RegexOptions.IgnoreCase);

		private static readonly Regex VCARD_LIKE_DATE = new Regex("\\A(?:\\d{4}-?\\d{2}-?\\d{2})\\z");

		private static readonly Regex CR_LF_SPACE_TAB = new Regex("\r\n[ \t]");

		private static readonly Regex NEWLINE_ESCAPE = new Regex("\\\\[nN]");

		private static readonly Regex VCARD_ESCAPES = new Regex("\\\\([,;\\\\])");

		private static readonly Regex EQUALS = new Regex("=");

		private static readonly Regex SEMICOLON = new Regex(";");

		private static readonly Regex UNESCAPED_SEMICOLONS = new Regex("(?<!\\\\);+");

		private static readonly Regex COMMA = new Regex(",");

		private static readonly Regex SEMICOLON_OR_COMMA = new Regex("[;,]");

		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			Match match = BEGIN_VCARD.Match(text);
			if (!match.Success || match.Index != 0)
			{
				return null;
			}
			List<List<string>> list = matchVCardPrefixedField("FN", text, trim: true, parseFieldDivider: false);
			if (list == null)
			{
				list = matchVCardPrefixedField("N", text, trim: true, parseFieldDivider: false);
				formatNames(list);
			}
			List<string> list2 = matchSingleVCardPrefixedField("NICKNAME", text, trim: true, parseFieldDivider: false);
			string[] nicknames = ((list2 == null) ? null : COMMA.Split(list2[0]));
			List<List<string>> lists = matchVCardPrefixedField("TEL", text, trim: true, parseFieldDivider: false);
			List<List<string>> lists2 = matchVCardPrefixedField("EMAIL", text, trim: true, parseFieldDivider: false);
			List<string> list3 = matchSingleVCardPrefixedField("NOTE", text, trim: false, parseFieldDivider: false);
			List<List<string>> lists3 = matchVCardPrefixedField("ADR", text, trim: true, parseFieldDivider: true);
			List<string> list4 = matchSingleVCardPrefixedField("ORG", text, trim: true, parseFieldDivider: true);
			List<string> list5 = matchSingleVCardPrefixedField("BDAY", text, trim: true, parseFieldDivider: false);
			if (list5 != null && !isLikeVCardDate(list5[0]))
			{
				list5 = null;
			}
			List<string> list6 = matchSingleVCardPrefixedField("TITLE", text, trim: true, parseFieldDivider: false);
			List<List<string>> lists4 = matchVCardPrefixedField("URL", text, trim: true, parseFieldDivider: false);
			List<string> list7 = matchSingleVCardPrefixedField("IMPP", text, trim: true, parseFieldDivider: false);
			List<string> list8 = matchSingleVCardPrefixedField("GEO", text, trim: true, parseFieldDivider: false);
			string[] array = ((list8 == null) ? null : SEMICOLON_OR_COMMA.Split(list8[0]));
			if (array != null && array.Length != 2)
			{
				array = null;
			}
			return new AddressBookParsedResult(toPrimaryValues(list), nicknames, null, toPrimaryValues(lists), toTypes(lists), toPrimaryValues(lists2), toTypes(lists2), toPrimaryValue(list7), toPrimaryValue(list3), toPrimaryValues(lists3), toTypes(lists3), toPrimaryValue(list4), toPrimaryValue(list5), toPrimaryValue(list6), toPrimaryValues(lists4), array);
		}

		public static List<List<string>> matchVCardPrefixedField(string prefix, string rawText, bool trim, bool parseFieldDivider)
		{
			List<List<string>> list = null;
			int num = 0;
			int length = rawText.Length;
			while (num < length)
			{
				Regex regex = new Regex("(?:^|\n)" + prefix + "(?:;([^:]*))?:", RegexOptions.IgnoreCase);
				if (num > 0)
				{
					num--;
				}
				Match match = regex.Match(rawText, num);
				if (!match.Success)
				{
					break;
				}
				num = match.Index + match.Length;
				string value = match.Groups[1].Value;
				List<string> list2 = null;
				bool flag = false;
				string charset = null;
				string value2 = null;
				if (value != null)
				{
					string[] array = SEMICOLON.Split(value);
					foreach (string text in array)
					{
						if (list2 == null)
						{
							list2 = new List<string>(1);
						}
						list2.Add(text);
						string[] array2 = EQUALS.Split(text, 2);
						if (array2.Length > 1)
						{
							string strB = array2[0];
							string text2 = array2[1];
							if (string.Compare("ENCODING", strB, StringComparison.OrdinalIgnoreCase) == 0 && string.Compare("QUOTED-PRINTABLE", text2, StringComparison.OrdinalIgnoreCase) == 0)
							{
								flag = true;
							}
							else if (string.Compare("CHARSET", strB, StringComparison.OrdinalIgnoreCase) == 0)
							{
								charset = text2;
							}
							else if (string.Compare("VALUE", strB, StringComparison.OrdinalIgnoreCase) == 0)
							{
								value2 = text2;
							}
						}
					}
				}
				int num2 = num;
				while ((num = rawText.IndexOf('\n', num)) >= 0)
				{
					if (num < rawText.Length - 1 && (rawText[num + 1] == ' ' || rawText[num + 1] == '\t'))
					{
						num += 2;
						continue;
					}
					if (!flag || ((num < 1 || rawText[num - 1] != '=') && (num < 2 || rawText[num - 2] != '=')))
					{
						break;
					}
					num++;
				}
				if (num < 0)
				{
					num = length;
				}
				else if (num > num2)
				{
					if (list == null)
					{
						list = new List<List<string>>(1);
					}
					if (num >= 1 && rawText[num - 1] == '\r')
					{
						num--;
					}
					string text3 = rawText.Substring(num2, num - num2);
					if (trim)
					{
						text3 = text3.Trim();
					}
					if (flag)
					{
						text3 = decodeQuotedPrintable(text3, charset);
						if (parseFieldDivider)
						{
							text3 = UNESCAPED_SEMICOLONS.Replace(text3, "\n").Trim();
						}
					}
					else
					{
						if (parseFieldDivider)
						{
							text3 = UNESCAPED_SEMICOLONS.Replace(text3, "\n").Trim();
						}
						text3 = CR_LF_SPACE_TAB.Replace(text3, "");
						text3 = NEWLINE_ESCAPE.Replace(text3, "\n");
						text3 = VCARD_ESCAPES.Replace(text3, "$1");
					}
					if ("uri".Equals(value2))
					{
						try
						{
							if (Uri.TryCreate(text3, UriKind.RelativeOrAbsolute, out var result))
							{
								text3 = result.AbsoluteUri.Replace(result.Scheme + ":", "");
							}
						}
						catch (Exception)
						{
						}
					}
					if (list2 == null)
					{
						List<string> list3 = new List<string>(1);
						list3.Add(text3);
						list.Add(list3);
					}
					else
					{
						list2.Insert(0, text3);
						list.Add(list2);
					}
					num++;
				}
				else
				{
					num++;
				}
			}
			return list;
		}

		private static string decodeQuotedPrintable(string value, string charset)
		{
			int length = value.Length;
			StringBuilder stringBuilder = new StringBuilder(length);
			MemoryStream memoryStream = new MemoryStream();
			for (int i = 0; i < length; i++)
			{
				char c = value[i];
				switch (c)
				{
				case '=':
				{
					if (i >= length - 2)
					{
						break;
					}
					char c2 = value[i + 1];
					if (c2 != '\r' && c2 != '\n')
					{
						char c3 = value[i + 2];
						int num = ResultParser.parseHexDigit(c2);
						int num2 = ResultParser.parseHexDigit(c3);
						if (num >= 0 && num2 >= 0)
						{
							memoryStream.WriteByte((byte)((num << 4) | num2));
						}
						i += 2;
					}
					break;
				}
				default:
					maybeAppendFragment(memoryStream, charset, stringBuilder);
					stringBuilder.Append(c);
					break;
				case '\n':
				case '\r':
					break;
				}
			}
			maybeAppendFragment(memoryStream, charset, stringBuilder);
			return stringBuilder.ToString();
		}

		private static void maybeAppendFragment(MemoryStream fragmentBuffer, string charset, StringBuilder result)
		{
			if (fragmentBuffer.Length <= 0)
			{
				return;
			}
			byte[] array = fragmentBuffer.ToArray();
			string value;
			if (charset == null)
			{
				value = Encoding.UTF8.GetString(array, 0, array.Length);
			}
			else
			{
				try
				{
					value = Encoding.GetEncoding(charset).GetString(array, 0, array.Length);
				}
				catch (Exception)
				{
					value = Encoding.UTF8.GetString(array, 0, array.Length);
				}
			}
			fragmentBuffer.Seek(0L, SeekOrigin.Begin);
			fragmentBuffer.SetLength(0L);
			result.Append(value);
		}

		internal static List<string> matchSingleVCardPrefixedField(string prefix, string rawText, bool trim, bool parseFieldDivider)
		{
			List<List<string>> list = matchVCardPrefixedField(prefix, rawText, trim, parseFieldDivider);
			if (list != null && list.Count != 0)
			{
				return list[0];
			}
			return null;
		}

		private static string toPrimaryValue(List<string> list)
		{
			if (list != null && list.Count != 0)
			{
				return list[0];
			}
			return null;
		}

		private static string[] toPrimaryValues(ICollection<List<string>> lists)
		{
			if (lists == null || lists.Count == 0)
			{
				return null;
			}
			List<string> list = new List<string>(lists.Count);
			foreach (List<string> list2 in lists)
			{
				string text = list2[0];
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			return SupportClass.toStringArray(list);
		}

		private static string[] toTypes(ICollection<List<string>> lists)
		{
			if (lists == null || lists.Count == 0)
			{
				return null;
			}
			List<string> list = new List<string>(lists.Count);
			foreach (List<string> list2 in lists)
			{
				if (string.IsNullOrEmpty(list2[0]))
				{
					continue;
				}
				string item = null;
				for (int i = 1; i < list2.Count; i++)
				{
					string text = list2[i];
					int num = text.IndexOf('=');
					if (num < 0)
					{
						item = text;
						break;
					}
					if (string.Compare("TYPE", text.Substring(0, num), StringComparison.OrdinalIgnoreCase) == 0)
					{
						item = text.Substring(num + 1);
						break;
					}
				}
				list.Add(item);
			}
			return SupportClass.toStringArray(list);
		}

		private static bool isLikeVCardDate(string value)
		{
			if (value != null)
			{
				return VCARD_LIKE_DATE.Match(value).Success;
			}
			return true;
		}

		private static void formatNames(IEnumerable<List<string>> names)
		{
			if (names == null)
			{
				return;
			}
			foreach (List<string> name in names)
			{
				string text = name[0];
				string[] array = new string[5];
				int num = 0;
				int num2 = 0;
				int num3;
				while (num2 < array.Length - 1 && (num3 = text.IndexOf(';', num)) >= 0)
				{
					array[num2] = text.Substring(num, num3 - num);
					num2++;
					num = num3 + 1;
				}
				array[num2] = text.Substring(num);
				StringBuilder stringBuilder = new StringBuilder(100);
				maybeAppendComponent(array, 3, stringBuilder);
				maybeAppendComponent(array, 1, stringBuilder);
				maybeAppendComponent(array, 2, stringBuilder);
				maybeAppendComponent(array, 0, stringBuilder);
				maybeAppendComponent(array, 4, stringBuilder);
				name.Insert(0, stringBuilder.ToString().Trim());
			}
		}

		private static void maybeAppendComponent(string[] components, int i, StringBuilder newName)
		{
			if (!string.IsNullOrEmpty(components[i]))
			{
				if (newName.Length > 0)
				{
					newName.Append(' ');
				}
				newName.Append(components[i]);
			}
		}
	}
	internal sealed class VEventResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (text == null)
			{
				return null;
			}
			if (text.IndexOf("BEGIN:VEVENT") < 0)
			{
				return null;
			}
			string summary = matchSingleVCardPrefixedField("SUMMARY", text, trim: true);
			string text2 = matchSingleVCardPrefixedField("DTSTART", text, trim: true);
			if (text2 == null)
			{
				return null;
			}
			string endString = matchSingleVCardPrefixedField("DTEND", text, trim: true);
			string durationString = matchSingleVCardPrefixedField("DURATION", text, trim: true);
			string location = matchSingleVCardPrefixedField("LOCATION", text, trim: true);
			string organizer = stripMailto(matchSingleVCardPrefixedField("ORGANIZER", text, trim: true));
			string[] array = matchVCardPrefixedField("ATTENDEE", text, trim: true);
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = stripMailto(array[i]);
				}
			}
			string description = matchSingleVCardPrefixedField("DESCRIPTION", text, trim: true);
			string text3 = matchSingleVCardPrefixedField("GEO", text, trim: true);
			double result2;
			double result3;
			if (text3 == null)
			{
				result2 = 0.0 / 0.0;
				result3 = 0.0 / 0.0;
			}
			else
			{
				int num = text3.IndexOf(';');
				if (num < 0)
				{
					return null;
				}
				if (!double.TryParse(text3.Substring(0, num), NumberStyles.Float, CultureInfo.InvariantCulture, out result2))
				{
					return null;
				}
				if (!double.TryParse(text3.Substring(num + 1), NumberStyles.Float, CultureInfo.InvariantCulture, out result3))
				{
					return null;
				}
			}
			try
			{
				return new CalendarParsedResult(summary, text2, endString, durationString, location, organizer, array, description, result2, result3);
			}
			catch (ArgumentException)
			{
				return null;
			}
		}

		private static string matchSingleVCardPrefixedField(string prefix, string rawText, bool trim)
		{
			List<string> list = VCardResultParser.matchSingleVCardPrefixedField(prefix, rawText, trim, parseFieldDivider: false);
			if (list != null && list.Count != 0)
			{
				return list[0];
			}
			return null;
		}

		private static string[] matchVCardPrefixedField(string prefix, string rawText, bool trim)
		{
			List<List<string>> list = VCardResultParser.matchVCardPrefixedField(prefix, rawText, trim, parseFieldDivider: false);
			if (list == null || list.Count == 0)
			{
				return null;
			}
			int count = list.Count;
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = list[i][0];
			}
			return array;
		}

		private static string stripMailto(string s)
		{
			if (s != null && (s.StartsWith("mailto:") || s.StartsWith("MAILTO:")))
			{
				s = s.Substring(7);
			}
			return s;
		}
	}
	public class VINParsedResult : ParsedResult
	{
		public string VIN { get; private set; }

		public string WorldManufacturerID { get; private set; }

		public string VehicleDescriptorSection { get; private set; }

		public string VehicleIdentifierSection { get; private set; }

		public string CountryCode { get; private set; }

		public string VehicleAttributes { get; private set; }

		public int ModelYear { get; private set; }

		public char PlantCode { get; private set; }

		public string SequentialNumber { get; private set; }

		public override string DisplayResult
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(50);
				stringBuilder.Append(WorldManufacturerID).Append(' ');
				stringBuilder.Append(VehicleDescriptorSection).Append(' ');
				stringBuilder.Append(VehicleIdentifierSection).Append('\n');
				if (CountryCode != null)
				{
					stringBuilder.Append(CountryCode).Append(' ');
				}
				stringBuilder.Append(ModelYear).Append(' ');
				stringBuilder.Append(PlantCode).Append(' ');
				stringBuilder.Append(SequentialNumber).Append('\n');
				return stringBuilder.ToString();
			}
		}

		public VINParsedResult(string vin, string worldManufacturerID, string vehicleDescriptorSection, string vehicleIdentifierSection, string countryCode, string vehicleAttributes, int modelYear, char plantCode, string sequentialNumber)
			: base(ParsedResultType.VIN)
		{
			VIN = vin;
			WorldManufacturerID = worldManufacturerID;
			VehicleDescriptorSection = vehicleDescriptorSection;
			VehicleIdentifierSection = vehicleIdentifierSection;
			CountryCode = countryCode;
			VehicleAttributes = vehicleAttributes;
			ModelYear = modelYear;
			PlantCode = plantCode;
			SequentialNumber = sequentialNumber;
		}
	}
	public class VINResultParser : ResultParser
	{
		private static readonly Regex IOQ = new Regex("[IOQ]");

		private static readonly Regex AZ09 = new Regex("\\A(?:[A-Z0-9]{17})\\z");

		public override ParsedResult parse(ZXing.Result result)
		{
			try
			{
				if (result.BarcodeFormat != BarcodeFormat.CODE_39)
				{
					return null;
				}
				string text = result.Text;
				text = IOQ.Replace(text, "").Trim();
				if (!AZ09.Match(text).Success)
				{
					return null;
				}
				if (!checkChecksum(text))
				{
					return null;
				}
				string text2 = text.Substring(0, 3);
				return new VINParsedResult(text, text2, text.Substring(3, 6), text.Substring(9, 8), countryCode(text2), text.Substring(3, 5), modelYear(text[9]), text[10], text.Substring(11));
			}
			catch
			{
				return null;
			}
		}

		private static bool checkChecksum(string vin)
		{
			int num = 0;
			for (int i = 0; i < vin.Length; i++)
			{
				num += vinPositionWeight(i + 1) * vinCharValue(vin[i]);
			}
			char num2 = vin[8];
			char c = checkChar(num % 11);
			return num2 == c;
		}

		private static int vinCharValue(char c)
		{
			if (c >= 'A' && c <= 'I')
			{
				return c - 65 + 1;
			}
			if (c >= 'J' && c <= 'R')
			{
				return c - 74 + 1;
			}
			if (c >= 'S' && c <= 'Z')
			{
				return c - 83 + 2;
			}
			if (c >= '0' && c <= '9')
			{
				return c - 48;
			}
			throw new ArgumentException(c.ToString());
		}

		private static int vinPositionWeight(int position)
		{
			if (position >= 1 && position <= 7)
			{
				return 9 - position;
			}
			switch (position)
			{
			case 8:
				return 10;
			case 9:
				return 0;
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
				return 19 - position;
			default:
				throw new ArgumentException();
			}
		}

		private static char checkChar(int remainder)
		{
			if (remainder < 10)
			{
				return (char)(48 + remainder);
			}
			if (remainder == 10)
			{
				return 'X';
			}
			throw new ArgumentException();
		}

		private static int modelYear(char c)
		{
			if (c >= 'E' && c <= 'H')
			{
				return c - 69 + 1984;
			}
			if (c >= 'J' && c <= 'N')
			{
				return c - 74 + 1988;
			}
			switch (c)
			{
			case 'P':
				return 1993;
			case 'R':
			case 'S':
			case 'T':
				return c - 82 + 1994;
			default:
				if (c >= 'V' && c <= 'Y')
				{
					return c - 86 + 1997;
				}
				if (c >= '1' && c <= '9')
				{
					return c - 49 + 2001;
				}
				if (c >= 'A' && c <= 'D')
				{
					return c - 65 + 2010;
				}
				throw new ArgumentException(c.ToString());
			}
		}

		private static string countryCode(string wmi)
		{
			char c = wmi[0];
			char c2 = wmi[1];
			switch (c)
			{
			case '1':
			case '4':
			case '5':
				return "US";
			case '2':
				return "CA";
			case '3':
				if (c2 >= 'A' && c2 <= 'W')
				{
					return "MX";
				}
				break;
			case '9':
				if ((c2 >= 'A' && c2 <= 'E') || (c2 >= '3' && c2 <= '9'))
				{
					return "BR";
				}
				break;
			case 'J':
				if (c2 >= 'A' && c2 <= 'T')
				{
					return "JP";
				}
				break;
			case 'K':
				if (c2 >= 'L' && c2 <= 'R')
				{
					return "KO";
				}
				break;
			case 'L':
				return "CN";
			case 'M':
				if (c2 >= 'A' && c2 <= 'E')
				{
					return "IN";
				}
				break;
			case 'S':
				if (c2 >= 'A' && c2 <= 'M')
				{
					return "UK";
				}
				if (c2 >= 'N' && c2 <= 'T')
				{
					return "DE";
				}
				break;
			case 'V':
				if (c2 >= 'F' && c2 <= 'R')
				{
					return "FR";
				}
				if (c2 >= 'S' && c2 <= 'W')
				{
					return "ES";
				}
				break;
			case 'W':
				return "DE";
			case 'X':
				switch (c2)
				{
				case '0':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					return "RU";
				}
				break;
			case 'Z':
				if (c2 >= 'A' && c2 <= 'R')
				{
					return "IT";
				}
				break;
			}
			return null;
		}
	}
	public class WifiParsedResult : ParsedResult
	{
		public string Ssid { get; private set; }

		public string NetworkEncryption { get; private set; }

		public string Password { get; private set; }

		public bool Hidden { get; private set; }

		public string Identity { get; private set; }

		public string AnonymousIdentity { get; private set; }

		public string EapMethod { get; private set; }

		public string Phase2Method { get; private set; }

		public WifiParsedResult(string networkEncryption, string ssid, string password)
			: this(networkEncryption, ssid, password, hidden: false)
		{
		}

		public WifiParsedResult(string networkEncryption, string ssid, string password, bool hidden)
			: this(networkEncryption, ssid, password, hidden, null, null, null, null)
		{
		}

		public WifiParsedResult(string networkEncryption, string ssid, string password, bool hidden, string identity, string anonymousIdentity, string eapMethod, string phase2Method)
			: base(ParsedResultType.WIFI)
		{
			Ssid = ssid;
			NetworkEncryption = networkEncryption;
			Password = password;
			Hidden = hidden;
			Identity = identity;
			AnonymousIdentity = anonymousIdentity;
			EapMethod = eapMethod;
			Phase2Method = phase2Method;
			StringBuilder stringBuilder = new StringBuilder(80);
			ParsedResult.maybeAppend(Ssid, stringBuilder);
			ParsedResult.maybeAppend(NetworkEncryption, stringBuilder);
			ParsedResult.maybeAppend(Password, stringBuilder);
			ParsedResult.maybeAppend(Hidden.ToString(), stringBuilder);
			ParsedResult.maybeAppend(Identity, stringBuilder);
			ParsedResult.maybeAppend(AnonymousIdentity, stringBuilder);
			ParsedResult.maybeAppend(EapMethod, stringBuilder);
			ParsedResult.maybeAppend(Phase2Method, stringBuilder);
			displayResultValue = stringBuilder.ToString();
		}
	}
	public class WifiResultParser : ResultParser
	{
		public override ParsedResult parse(ZXing.Result result)
		{
			string text = result.Text;
			if (!text.StartsWith("WIFI:"))
			{
				return null;
			}
			text = text.Substring("WIFI:".Length);
			string text2 = ResultParser.matchSinglePrefixedField("S:", text, ';', trim: false);
			if (string.IsNullOrEmpty(text2))
			{
				return null;
			}
			string password = ResultParser.matchSinglePrefixedField("P:", text, ';', trim: false);
			string networkEncryption = ResultParser.matchSinglePrefixedField("T:", text, ';', trim: false) ?? "nopass";
			bool result2 = false;
			bool.TryParse(ResultParser.matchSinglePrefixedField("H:", text, ';', trim: false), out result2);
			return new WifiParsedResult(identity: ResultParser.matchSinglePrefixedField("I:", text, ';', trim: false), anonymousIdentity: ResultParser.matchSinglePrefixedField("A:", text, ';', trim: false), eapMethod: ResultParser.matchSinglePrefixedField("E:", text, ';', trim: false), phase2Method: ResultParser.matchSinglePrefixedField("H:", text, ';', trim: false), networkEncryption: networkEncryption, ssid: text2, password: password, hidden: result2);
		}
	}
}
namespace ZXing.Aztec
{
	public class AztecReader : Reader
	{
		public Result decode(BinaryBitmap image)
		{
			return decode(image, null);
		}

		public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
		{
			BitMatrix blackMatrix = image.BlackMatrix;
			if (blackMatrix == null)
			{
				return null;
			}
			ZXing.Aztec.Internal.Detector detector = new ZXing.Aztec.Internal.Detector(blackMatrix);
			ResultPoint[] array = null;
			DecoderResult decoderResult = null;
			AztecDetectorResult aztecDetectorResult = detector.detect(isMirror: false);
			if (aztecDetectorResult != null)
			{
				array = aztecDetectorResult.Points;
				decoderResult = new ZXing.Aztec.Internal.Decoder().decode(aztecDetectorResult);
			}
			if (decoderResult == null)
			{
				aztecDetectorResult = detector.detect(isMirror: true);
				if (aztecDetectorResult == null)
				{
					return null;
				}
				array = aztecDetectorResult.Points;
				decoderResult = new ZXing.Aztec.Internal.Decoder().decode(aztecDetectorResult);
				if (decoderResult == null)
				{
					return null;
				}
			}
			if (hints != null && hints.ContainsKey(DecodeHintType.NEED_RESULT_POINT_CALLBACK))
			{
				ResultPointCallback resultPointCallback = (ResultPointCallback)hints[DecodeHintType.NEED_RESULT_POINT_CALLBACK];
				if (resultPointCallback != null)
				{
					ResultPoint[] array2 = array;
					foreach (ResultPoint point in array2)
					{
						resultPointCallback(point);
					}
				}
			}
			Result result = new Result(decoderResult.Text, decoderResult.RawBytes, decoderResult.NumBits, array, BarcodeFormat.AZTEC);
			IList<byte[]> byteSegments = decoderResult.ByteSegments;
			if (byteSegments != null)
			{
				result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, byteSegments);
			}
			string eCLevel = decoderResult.ECLevel;
			if (eCLevel != null)
			{
				result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, eCLevel);
			}
			result.putMetadata(ResultMetadataType.AZTEC_EXTRA_METADATA, new AztecResultMetadata(aztecDetectorResult.Compact, aztecDetectorResult.NbDatablocks, aztecDetectorResult.NbLayers));
			return result;
		}

		public void reset()
		{
		}
	}
	public sealed class AztecResultMetadata
	{
		public bool Compact { get; private set; }

		public int Datablocks { get; private set; }

		public int Layers { get; private set; }

		public AztecResultMetadata(bool compact, int datablocks, int layers)
		{
			Compact = compact;
			Datablocks = datablocks;
			Layers = layers;
		}
	}
	public sealed class AztecWriter : Writer
	{
		private static readonly Encoding DEFAULT_CHARSET;

		static AztecWriter()
		{
			DEFAULT_CHARSET = Encoding.GetEncoding("UTF-8");
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height)
		{
			return encode(contents, format, width, height, null);
		}

		public BitMatrix encode(string contents, BarcodeFormat format, int width, int height, IDictionary<EncodeHintType, object> hints)
		{
			Encoding charset = DEFAULT_CHARSET;
			int eccPercent = 33;
			int layers = 0;
			if (hints != null)
			{
				if (hints.ContainsKey(EncodeHintType.CHARACTER_SET))
				{
					object obj = hints[EncodeHintType.CHARACTER_SET];
					if (obj != null)
					{
						charset = Encoding.GetEncoding(obj.ToString());
					}
				}
				if (hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
				{
					object obj2 = hints[EncodeHintType.ERROR_CORRECTION];
					if (obj2 != null)
					{
						eccPercent = Convert.ToInt32(obj2);
					}
				}
				if (hints.ContainsKey(EncodeHintType.AZTEC_LAYERS))
				{
					object obj3 = hints[EncodeHintType.AZTEC_LAYERS];
					if (obj3 != null)
					{
						layers = Convert.ToInt32(obj3);
					}
				}
			}
			return encode(contents, format, width, height, charset, eccPercent, layers);
		}

		private static BitMatrix encode(string contents, BarcodeFormat format, int width, int height, Encoding charset, int eccPercent, int layers)
		{
			if (format != BarcodeFormat.AZTEC)
			{
				throw new ArgumentException("Can only encode AZTEC code, but got " + format);
			}
			return renderResult(ZXing.Aztec.Internal.Encoder.encode(charset.GetBytes(contents), eccPercent, layers), width, height);
		}

		private static BitMatrix renderResult(AztecCode code, int width, int height)
		{
			BitMatrix matrix = code.Matrix;
			if (matrix == null)
			{
				throw new InvalidOperationException("No input code matrix");
			}
			int width2 = matrix.Width;
			int height2 = matrix.Height;
			int num = Math.Max(width, width2);
			int num2 = Math.Max(height, height2);
			int num3 = Math.Min(num / width2, num2 / height2);
			int num4 = (num - width2 * num3) / 2;
			int num5 = (num2 - height2 * num3) / 2;
			BitMatrix bitMatrix = new BitMatrix(num, num2);
			int num6 = 0;
			int num7 = num5;
			while (num6 < height2)
			{
				int num8 = 0;
				int num9 = num4;
				while (num8 < width2)
				{
					if (matrix[num8, num6])
					{
						bitMatrix.setRegion(num9, num7, num3, num3);
					}
					num8++;
					num9 += num3;
				}
				num6++;
				num7 += num3;
			}
			return bitMatrix;
		}
	}
	[Serializable]
	public class AztecEncodingOptions : EncodingOptions
	{
		public int? ErrorCorrection
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
				{
					return (int)base.Hints[EncodeHintType.ERROR_CORRECTION];
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					if (base.Hints.ContainsKey(EncodeHintType.ERROR_CORRECTION))
					{
						base.Hints.Remove(EncodeHintType.ERROR_CORRECTION);
					}
				}
				else
				{
					base.Hints[EncodeHintType.ERROR_CORRECTION] = value;
				}
			}
		}

		public int? Layers
		{
			get
			{
				if (base.Hints.ContainsKey(EncodeHintType.AZTEC_LAYERS))
				{
					return (int)base.Hints[EncodeHintType.AZTEC_LAYERS];
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					if (base.Hints.ContainsKey(EncodeHintType.AZTEC_LAYERS))
					{
						base.Hints.Remove(EncodeHintType.AZTEC_LAYERS);
					}
				}
				else
				{
					base.Hints[EncodeHintType.AZTEC_LAYERS] = value;
				}
			}
		}
	}
}
namespace ZXing.Aztec.Internal
{
	public class AztecDetectorResult : DetectorResult
	{
		public bool Compact { get; private set; }

		public int NbDatablocks { get; private set; }

		public int NbLayers { get; private set; }

		public AztecDetectorResult(BitMatrix bits, ResultPoint[] points, bool compact, int nbDatablocks, int nbLayers)
			: base(bits, points)
		{
			Compact = compact;
			NbDatablocks = nbDatablocks;
			NbLayers = nbLayers;
		}
	}
	public sealed class Decoder
	{
		private enum Table
		{
			UPPER,
			LOWER,
			MIXED,
			DIGIT,
			PUNCT,
			BINARY
		}

		private static readonly string[] UPPER_TABLE = new string[32]
		{
			"CTRL_PS", " ", "A", "B", "C", "D", "E", "F", "G", "H",
			"I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
			"S", "T", "U", "V", "W", "X", "Y", "Z", "CTRL_LL", "CTRL_ML",
			"CTRL_DL", "CTRL_BS"
		};

		private static readonly string[] LOWER_TABLE = new string[32]
		{
			"CTRL_PS", " ", "a", "b", "c", "d", "e", "f", "g", "h",
			"i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
			"s", "t", "u", "v", "w", "x", "y", "z", "CTRL_US", "CTRL_ML",
			"CTRL_DL", "CTRL_BS"
		};

		private static readonly string[] MIXED_TABLE = new string[32]
		{
			"CTRL_PS", " ", "\u0001", "\u0002", "\u0003", "\u0004", "\u0005", "\u0006", "\a", "\b",
			"\t", "\n", "\r", "\f", "\r", "!", "\"", "#", "$", "%",
			"@", "\\", "^", "_", "`", "|", "~", "±", "CTRL_LL", "CTRL_UL",
			"CTRL_PL", "CTRL_BS"
		};

		private static readonly string[] PUNCT_TABLE = new string[32]
		{
			"", "\r", "\r\n", ". ", ", ", ": ", "!", "\"", "#", "$",
			"%", "&", "'", "(", ")", "*", "+", ",", "-", ".",
			"/", ":", ";", "<", "=", ">", "?", "[", "]", "{",
			"}", "CTRL_UL"
		};

		private static readonly string[] DIGIT_TABLE = new string[16]
		{
			"CTRL_PS", " ", "0", "1", "2", "3", "4", "5", "6", "7",
			"8", "9", ",", ".", "CTRL_UL", "CTRL_US"
		};

		private static readonly IDictionary<Table, string[]> codeTables = new Dictionary<Table, string[]>
		{
			{
				Table.UPPER,
				UPPER_TABLE
			},
			{
				Table.LOWER,
				LOWER_TABLE
			},
			{
				Table.MIXED,
				MIXED_TABLE
			},
			{
				Table.PUNCT,
				PUNCT_TABLE
			},
			{
				Table.DIGIT,
				DIGIT_TABLE
			},
			{
				Table.BINARY,
				null
			}
		};

		private static readonly IDictionary<char, Table> codeTableMap = new Dictionary<char, Table>
		{
			{
				'U',
				Table.UPPER
			},
			{
				'L',
				Table.LOWER
			},
			{
				'M',
				Table.MIXED
			},
			{
				'P',
				Table.PUNCT
			},
			{
				'D',
				Table.DIGIT
			},
			{
				'B',
				Table.BINARY
			}
		};

		private AztecDetectorResult ddata;

		public DecoderResult decode(AztecDetectorResult detectorResult)
		{
			ddata = detectorResult;
			BitMatrix bits = detectorResult.Bits;
			bool[] array = extractBits(bits);
			if (array == null)
			{
				return null;
			}
			bool[] array2 = correctBits(array);
			if (array2 == null)
			{
				return null;
			}
			string encodedData = getEncodedData(array2);
			if (encodedData == null)
			{
				return null;
			}
			return new DecoderResult(convertBoolArrayToByteArray(array2), array2.Length, encodedData, null, null);
		}

		public static string highLevelDecode(bool[] correctedBits)
		{
			return getEncodedData(correctedBits);
		}

		private static string getEncodedData(bool[] correctedBits)
		{
			int num = correctedBits.Length;
			Table table = Table.UPPER;
			Table table2 = Table.UPPER;
			string[] table3 = UPPER_TABLE;
			StringBuilder stringBuilder = new StringBuilder(20);
			int num2 = 0;
			while (num2 < num)
			{
				if (table2 == Table.BINARY)
				{
					if (num - num2 < 5)
					{
						break;
					}
					int num3 = readCode(correctedBits, num2, 5);
					num2 += 5;
					if (num3 == 0)
					{
						if (num - num2 < 11)
						{
							break;
						}
						num3 = readCode(correctedBits, num2, 11) + 31;
						num2 += 11;
					}
					for (int i = 0; i < num3; i++)
					{
						if (num - num2 < 8)
						{
							num2 = num;
							break;
						}
						int num4 = readCode(correctedBits, num2, 8);
						stringBuilder.Append((char)num4);
						num2 += 8;
					}
					table2 = table;
					table3 = codeTables[table2];
					continue;
				}
				int num5 = ((table2 == Table.DIGIT) ? 4 : 5);
				if (num - num2 < num5)
				{
					break;
				}
				int code = readCode(correctedBits, num2, num5);
				num2 += num5;
				string character = getCharacter(table3, code);
				if (character.StartsWith("CTRL_"))
				{
					table = table2;
					table2 = getTable(character[5]);
					table3 = codeTables[table2];
					if (character[6] == 'L')
					{
						table = table2;
					}
				}
				else
				{
					stringBuilder.Append(character);
					table2 = table;
					table3 = codeTables[table2];
				}
			}
			return stringBuilder.ToString();
		}

		private static Table getTable(char t)
		{
			if (!codeTableMap.ContainsKey(t))
			{
				return codeTableMap['U'];
			}
			return codeTableMap[t];
		}

		private static string getCharacter(string[] table, int code)
		{
			return table[code];
		}

		private bool[] correctBits(bool[] rawbits)
		{
			int num;
			GenericGF field;
			if (ddata.NbLayers <= 2)
			{
				num = 6;
				field = GenericGF.AZTEC_DATA_6;
			}
			else if (ddata.NbLayers <= 8)
			{
				num = 8;
				field = GenericGF.AZTEC_DATA_8;
			}
			else if (ddata.NbLayers <= 22)
			{
				num = 10;
				field = GenericGF.AZTEC_DATA_10;
			}
			else
			{
				num = 12;
				field = GenericGF.AZTEC_DATA_12;
			}
			int nbDatablocks = ddata.NbDatablocks;
			int num2 = rawbits.Length / num;
			if (num2 < nbDatablocks)
			{
				return null;
			}
			int num3 = rawbits.Length % num;
			int twoS = num2 - nbDatablocks;
			int[] array = new int[num2];
			int num4 = 0;
			while (num4 < num2)
			{
				array[num4] = readCode(rawbits, num3, num);
				num4++;
				num3 += num;
			}
			if (!new ReedSolomonDecoder(field).decode(array, twoS))
			{
				return null;
			}
			int num5 = (1 << num) - 1;
			int num6 = 0;
			for (int i = 0; i < nbDatablocks; i++)
			{
				int num7 = array[i];
				if (num7 == 0 || num7 == num5)
				{
					return null;
				}
				if (num7 == 1 || num7 == num5 - 1)
				{
					num6++;
				}
			}
			bool[] array2 = new bool[nbDatablocks * num - num6];
			int num8 = 0;
			for (int j = 0; j < nbDatablocks; j++)
			{
				int num9 = array[j];
				if (num9 == 1 || num9 == num5 - 1)
				{
					SupportClass.Fill(array2, num8, num8 + num - 1, num9 > 1);
					num8 += num - 1;
					continue;
				}
				for (int num10 = num - 1; num10 >= 0; num10--)
				{
					array2[num8++] = (num9 & (1 << num10)) != 0;
				}
			}
			if (num8 != array2.Length)
			{
				return null;
			}
			return array2;
		}

		private bool[] extractBits(BitMatrix matrix)
		{
			bool compact = ddata.Compact;
			int nbLayers = ddata.NbLayers;
			int num = (compact ? 11 : 14) + nbLayers * 4;
			int[] array = new int[num];
			bool[] array2 = new bool[totalBitsInLayer(nbLayers, compact)];
			if (compact)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i;
				}
			}
			else
			{
				int num2 = num + 1 + 2 * ((num / 2 - 1) / 15);
				int num3 = num / 2;
				int num4 = num2 / 2;
				for (int j = 0; j < num3; j++)
				{
					int num5 = j + j / 15;
					array[num3 - j - 1] = num4 - num5 - 1;
					array[num3 + j] = num4 + num5 + 1;
				}
			}
			int k = 0;
			int num6 = 0;
			for (; k < nbLayers; k++)
			{
				int num7 = (nbLayers - k) * 4 + (compact ? 9 : 12);
				int num8 = k * 2;
				int num9 = num - 1 - num8;
				for (int l = 0; l < num7; l++)
				{
					int num10 = l * 2;
					for (int m = 0; m < 2; m++)
					{
						array2[num6 + num10 + m] = matrix[array[num8 + m], array[num8 + l]];
						array2[num6 + 2 * num7 + num10 + m] = matrix[array[num8 + l], array[num9 - m]];
						array2[num6 + 4 * num7 + num10 + m] = matrix[array[num9 - m], array[num9 - l]];
						array2[num6 + 6 * num7 + num10 + m] = matrix[array[num9 - l], array[num8 + m]];
					}
				}
				num6 += num7 * 8;
			}
			return array2;
		}

		private static int readCode(bool[] rawbits, int startIndex, int length)
		{
			int num = 0;
			for (int i = startIndex; i < startIndex + length; i++)
			{
				num <<= 1;
				if (rawbits[i])
				{
					num++;
				}
			}
			return num;
		}

		private static byte readByte(bool[] rawbits, int startIndex)
		{
			int num = rawbits.Length - startIndex;
			if (num >= 8)
			{
				return (byte)readCode(rawbits, startIndex, 8);
			}
			return (byte)(readCode(rawbits, startIndex, num) << 8 - num);
		}

		internal static byte[] convertBoolArrayToByteArray(bool[] boolArr)
		{
			byte[] array = new byte[(boolArr.Length + 7) / 8];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = readByte(boolArr, 8 * i);
			}
			return array;
		}

		private static int totalBitsInLayer(int layers, bool compact)
		{
			return ((compact ? 88 : 112) + 16 * layers) * layers;
		}
	}
	public sealed class Detector
	{
		internal sealed class Point
		{
			public int X { get; private set; }

			public int Y { get; private set; }

			public ResultPoint toResultPoint()
			{
				return new ResultPoint(X, Y);
			}

			internal Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override string ToString()
			{
				return "<" + X + " " + Y + ">";
			}
		}

		private static readonly int[] EXPECTED_CORNER_BITS = new int[4] { 3808, 476, 2107, 1799 };

		private readonly BitMatrix image;

		private bool compact;

		private int nbLayers;

		private int nbDataBlocks;

		private int nbCenterLayers;

		private int shift;

		public Detector(BitMatrix image)
		{
			this.image = image;
		}

		public AztecDetectorResult detect()
		{
			return detect(isMirror: false);
		}

		public AztecDetectorResult detect(bool isMirror)
		{
			Point matrixCenter = getMatrixCenter();
			if (matrixCenter == null)
			{
				return null;
			}
			ResultPoint[] bullsEyeCorners = getBullsEyeCorners(matrixCenter);
			if (bullsEyeCorners == null)
			{
				return null;
			}
			if (isMirror)
			{
				ResultPoint resultPoint = bullsEyeCorners[0];
				bullsEyeCorners[0] = bullsEyeCorners[2];
				bullsEyeCorners[2] = resultPoint;
			}
			if (!extractParameters(bullsEyeCorners))
			{
				return null;
			}
			BitMatrix bitMatrix = sampleGrid(image, bullsEyeCorners[shift % 4], bullsEyeCorners[(shift + 1) % 4], bullsEyeCorners[(shift + 2) % 4], bullsEyeCorners[(shift + 3) % 4]);
			if (bitMatrix == null)
			{
				return null;
			}
			ResultPoint[] matrixCornerPoints = getMatrixCornerPoints(bullsEyeCorners);
			if (matrixCornerPoints == null)
			{
				return null;
			}
			return new AztecDetectorResult(bitMatrix, matrixCornerPoints, compact, nbDataBlocks, nbLayers);
		}

		private bool extractParameters(ResultPoint[] bullsEyeCorners)
		{
			if (!isValid(bullsEyeCorners[0]) || !isValid(bullsEyeCorners[1]) || !isValid(bullsEyeCorners[2]) || !isValid(bullsEyeCorners[3]))
			{
				return false;
			}
			int num = 2 * nbCenterLayers;
			int[] array = new int[4]
			{
				sampleLine(bullsEyeCorners[0], bullsEyeCorners[1], num),
				sampleLine(bullsEyeCorners[1], bullsEyeCorners[2], num),
				sampleLine(bullsEyeCorners[2], bullsEyeCorners[3], num),
				sampleLine(bullsEyeCorners[3], bullsEyeCorners[0], num)
			};
			shift = getRotation(array, num);
			if (shift < 0)
			{
				return false;
			}
			long num2 = 0L;
			for (int i = 0; i < 4; i++)
			{
				int num3 = array[(shift + i) % 4];
				if (compact)
				{
					num2 <<= 7;
					num2 += (num3 >> 1) & 0x7F;
				}
				else
				{
					num2 <<= 10;
					num2 += ((num3 >> 2) & 0x3E0) + ((num3 >> 1) & 0x1F);
				}
			}
			int correctedParameterData = getCorrectedParameterData(num2, compact);
			if (correctedParameterData < 0)
			{
				return false;
			}
			if (compact)
			{
				nbLayers = (correctedParameterData >> 6) + 1;
				nbDataBlocks = (correctedParameterData & 0x3F) + 1;
			}
			else
			{
				nbLayers = (correctedParameterData >> 11) + 1;
				nbDataBlocks = (correctedParameterData & 0x7FF) + 1;
			}
			return true;
		}

		private static int getRotation(int[] sides, int length)
		{
			int num = 0;
			foreach (int num2 in sides)
			{
				int num3 = (num2 >> length - 2 << 1) + (num2 & 1);
				num = (num << 3) + num3;
			}
			num = ((num & 1) << 11) + (num >> 1);
			for (int j = 0; j < 4; j++)
			{
				if (SupportClass.bitCount(num ^ EXPECTED_CORNER_BITS[j]) <= 2)
				{
					return j;
				}
			}
			return -1;
		}

		private static int getCorrectedParameterData(long parameterData, bool compact)
		{
			int num;
			int num2;
			if (compact)
			{
				num = 7;
				num2 = 2;
			}
			else
			{
				num = 10;
				num2 = 4;
			}
			int twoS = num - num2;
			int[] array = new int[num];
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				array[num3] = (int)parameterData & 0xF;
				parameterData >>= 4;
			}
			if (!new ReedSolomonDecoder(GenericGF.AZTEC_PARAM).decode(array, twoS))
			{
				return -1;
			}
			int num4 = 0;
			for (int i = 0; i < num2; i++)
			{
				num4 = (num4 << 4) + array[i];
			}
			return num4;
		}

		private ResultPoint[] getBullsEyeCorners(Point pCenter)
		{
			Point point = pCenter;
			Point point2 = pCenter;
			Point point3 = pCenter;
			Point point4 = pCenter;
			bool flag = true;
			for (nbCenterLayers = 1; nbCenterLayers < 9; nbCenterLayers++)
			{
				Point firstDifferent = getFirstDifferent(point, flag, 1, -1);
				Point firstDifferent2 = getFirstDifferent(point2, flag, 1, 1);
				Point firstDifferent3 = getFirstDifferent(point3, flag, -1, 1);
				Point firstDifferent4 = getFirstDifferent(point4, flag, -1, -1);
				if (nbCenterLayers > 2)
				{
					float num = distance(firstDifferent4, firstDifferent) * (float)nbCenterLayers / (distance(point4, point) * (float)(nbCenterLayers + 2));
					if ((double)num < 0.75 || (double)num > 1.25 || !isWhiteOrBlackRectangle(firstDifferent, firstDifferent2, firstDifferent3, firstDifferent4))
					{
						break;
					}
				}
				point = firstDifferent;
				point2 = firstDifferent2;
				point3 = firstDifferent3;
				point4 = firstDifferent4;
				flag = !flag;
			}
			if (nbCenterLayers != 5 && nbCenterLayers != 7)
			{
				return null;
			}
			compact = nbCenterLayers == 5;
			ResultPoint resultPoint = new ResultPoint((float)point.X + 0.5f, (float)point.Y - 0.5f);
			ResultPoint resultPoint2 = new ResultPoint((float)point2.X + 0.5f, (float)point2.Y + 0.5f);
			ResultPoint resultPoint3 = new ResultPoint((float)point3.X - 0.5f, (float)point3.Y + 0.5f);
			ResultPoint resultPoint4 = new ResultPoint((float)point4.X - 0.5f, (float)point4.Y - 0.5f);
			return expandSquare(new ResultPoint[4] { resultPoint, resultPoint2, resultPoint3, resultPoint4 }, 2 * nbCenterLayers - 3, 2 * nbCenterLayers);
		}

		private Point getMatrixCenter()
		{
			WhiteRectangleDetector whiteRectangleDetector = WhiteRectangleDetector.Create(image);
			if (whiteRectangleDetector == null)
			{
				return null;
			}
			ResultPoint[] array = whiteRectangleDetector.detect();
			ResultPoint resultPoint;
			ResultPoint resultPoint2;
			ResultPoint resultPoint3;
			ResultPoint resultPoint4;
			int num;
			int num2;
			if (array != null)
			{
				resultPoint = array[0];
				resultPoint2 = array[1];
				resultPoint3 = array[2];
				resultPoint4 = array[3];
			}
			else
			{
				num = image.Width / 2;
				num2 = image.Height / 2;
				resultPoint = getFirstDifferent(new Point(num + 7, num2 - 7), color: false, 1, -1).toResultPoint();
				resultPoint2 = getFirstDifferent(new Point(num + 7, num2 + 7), color: false, 1, 1).toResultPoint();
				resultPoint3 = getFirstDifferent(new Point(num - 7, num2 + 7), color: false, -1, 1).toResultPoint();
				resultPoint4 = getFirstDifferent(new Point(num - 7, num2 - 7), color: false, -1, -1).toResultPoint();
			}
			num = MathUtils.round((resultPoint.X + resultPoint4.X + resultPoint2.X + resultPoint3.X) / 4f);
			num2 = MathUtils.round((resultPoint.Y + resultPoint4.Y + resultPoint2.Y + resultPoint3.Y) / 4f);
			whiteRectangleDetector = WhiteRectangleDetector.Create(image, 15, num, num2);
			if (whiteRectangleDetector == null)
			{
				return null;
			}
			array = whiteRectangleDetector.detect();
			if (array != null)
			{
				resultPoint = array[0];
				resultPoint2 = array[1];
				resultPoint3 = array[2];
				resultPoint4 = array[3];
			}
			else
			{
				resultPoint = getFirstDifferent(new Point(num + 7, num2 - 7), color: false, 1, -1).toResultPoint();
				resultPoint2 = getFirstDifferent(new Point(num + 7, num2 + 7), color: false, 1, 1).toResultPoint();
				resultPoint3 = getFirstDifferent(new Point(num - 7, num2 + 7), color: false, -1, 1).toResultPoint();
				resultPoint4 = getFirstDifferent(new Point(num - 7, num2 - 7), color: false, -1, -1).toResultPoint();
			}
			num = MathUtils.round((resultPoint.X + resultPoint4.X + resultPoint2.X + resultPoint3.X) / 4f);
			num2 = MathUtils.round((resultPoint.Y + resultPoint4.Y + resultPoint2.Y + resultPoint3.Y) / 4f);
			return new Point(num, num2);
		}

		private ResultPoint[] getMatrixCornerPoints(ResultPoint[] bullsEyeCorners)
		{
			return expandSquare(bullsEyeCorners, 2 * nbCenterLayers, getDimension());
		}

		private BitMatrix sampleGrid(BitMatrix image, ResultPoint topLeft, ResultPoint topRight, ResultPoint bottomRight, ResultPoint bottomLeft)
		{
			GridSampler instance = GridSampler.Instance;
			int dimension = getDimension();
			float num = (float)dimension / 2f - (float)nbCenterLayers;
			float num2 = (float)dimension / 2f + (float)nbCenterLayers;
			return instance.sampleGrid(image, dimension, dimension, num, num, num2, num, num2, num2, num, num2, topLeft.X, topLeft.Y, topRight.X, topRight.Y, bottomRight.X, bottomRight.Y, bottomLeft.X, bottomLeft.Y);
		}

		private int sampleLine(ResultPoint p1, ResultPoint p2, int size)
		{
			int num = 0;
			float num2 = distance(p1, p2);
			float num3 = num2 / (float)size;
			float x = p1.X;
			float y = p1.Y;
			float num4 = num3 * (p2.X - p1.X) / num2;
			float num5 = num3 * (p2.Y - p1.Y) / num2;
			for (int i = 0; i < size; i++)
			{
				if (image[MathUtils.round(x + (float)i * num4), MathUtils.round(y + (float)i * num5)])
				{
					num |= 1 << size - i - 1;
				}
			}
			return num;
		}

		private bool isWhiteOrBlackRectangle(Point p1, Point p2, Point p3, Point p4)
		{
			p1 = new Point(p1.X - 3, p1.Y + 3);
			p2 = new Point(p2.X - 3, p2.Y - 3);
			p3 = new Point(p3.X + 3, p3.Y - 3);
			p4 = new Point(p4.X + 3, p4.Y + 3);
			int color = getColor(p4, p1);
			if (color == 0)
			{
				return false;
			}
			if (getColor(p1, p2) != color)
			{
				return false;
			}
			if (getColor(p2, p3) != color)
			{
				return false;
			}
			return getColor(p3, p4) == color;
		}

		private int getColor(Point p1, Point p2)
		{
			float num = distance(p1, p2);
			float num2 = (float)(p2.X - p1.X) / num;
			float num3 = (float)(p2.Y - p1.Y) / num;
			int num4 = 0;
			float num5 = p1.X;
			float num6 = p1.Y;
			bool flag = image[p1.X, p1.Y];
			int num7 = (int)Math.Ceiling(num);
			for (int i = 0; i < num7; i++)
			{
				num5 += num2;
				num6 += num3;
				if (image[MathUtils.round(num5), MathUtils.round(num6)] != flag)
				{
					num4++;
				}
			}
			float num8 = (float)num4 / num;
			if (num8 > 0.1f && num8 < 0.9f)
			{
				return 0;
			}
			if (num8 <= 0.1f != flag)
			{
				return -1;
			}
			return 1;
		}

		private Point getFirstDifferent(Point init, bool color, int dx, int dy)
		{
			int num = init.X + dx;
			int i;
			for (i = init.Y + dy; isValid(num, i) && image[num, i] == color; i += dy)
			{
				num += dx;
			}
			num -= dx;
			for (i -= dy; isValid(num, i) && image[num, i] == color; num += dx)
			{
			}
			for (num -= dx; isValid(num, i) && image[num, i] == color; i += dy)
			{
			}
			i -= dy;
			return new Point(num, i);
		}

		private static ResultPoint[] expandSquare(ResultPoint[] cornerPoints, float oldSide, float newSide)
		{
			float num = newSide / (2f * oldSide);
			float num2 = cornerPoints[0].X - cornerPoints[2].X;
			float num3 = cornerPoints[0].Y - cornerPoints[2].Y;
			float num4 = (cornerPoints[0].X + cornerPoints[2].X) / 2f;
			float num5 = (cornerPoints[0].Y + cornerPoints[2].Y) / 2f;
			ResultPoint resultPoint = new ResultPoint(num4 + num * num2, num5 + num * num3);
			ResultPoint resultPoint2 = new ResultPoint(num4 - num * num2, num5 - num * num3);
			num2 = cornerPoints[1].X - cornerPoints[3].X;
			num3 = cornerPoints[1].Y - cornerPoints[3].Y;
			float num6 = (cornerPoints[1].X + cornerPoints[3].X) / 2f;
			num5 = (cornerPoints[1].Y + cornerPoints[3].Y) / 2f;
			ResultPoint resultPoint3 = new ResultPoint(num6 + num * num2, num5 + num * num3);
			ResultPoint resultPoint4 = new ResultPoint(num6 - num * num2, num5 - num * num3);
			return new ResultPoint[4] { resultPoint, resultPoint3, resultPoint2, resultPoint4 };
		}

		private bool isValid(int x, int y)
		{
			if (x >= 0 && x < image.Width && y > 0)
			{
				return y < image.Height;
			}
			return false;
		}

		private bool isValid(ResultPoint point)
		{
			int x = MathUtils.round(point.X);
			int y = MathUtils.round(point.Y);
			return isValid(x, y);
		}

		private static float distance(Point a, Point b)
		{
			return MathUtils.distance(a.X, a.Y, b.X, b.Y);
		}

		private static float distance(ResultPoint a, ResultPoint b)
		{
			return MathUtils.distance(a.X, a.Y, b.X, b.Y);
		}

		private int getDimension()
		{
			if (compact)
			{
				return 4 * nbLayers + 11;
			}
			if (nbLayers <= 4)
			{
				return 4 * nbLayers + 15;
			}
			return 4 * nbLayers + 2 * ((nbLayers - 4) / 8 + 1) + 15;
		}
	}
	public sealed class AztecCode
	{
		public bool isCompact { get; set; }

		public int Size { get; set; }

		public int Layers { get; set; }

		public int CodeWords { get; set; }

		public BitMatrix Matrix { get; set; }
	}
	public sealed class BinaryShiftToken : Token
	{
		private readonly short binaryShiftStart;

		private readonly short binaryShiftByteCount;

		public BinaryShiftToken(Token previous, int binaryShiftStart, int binaryShiftByteCount)
			: base(previous)
		{
			this.binaryShiftStart = (short)binaryShiftStart;
			this.binaryShiftByteCount = (short)binaryShiftByteCount;
		}

		public override void appendTo(ZXing.Common.BitArray bitArray, byte[] text)
		{
			for (int i = 0; i < binaryShiftByteCount; i++)
			{
				if (i == 0 || (i == 31 && binaryShiftByteCount <= 62))
				{
					bitArray.appendBits(31, 5);
					if (binaryShiftByteCount > 62)
					{
						bitArray.appendBits(binaryShiftByteCount - 31, 16);
					}
					else if (i == 0)
					{
						bitArray.appendBits(Math.Min(binaryShiftByteCount, (short)31), 5);
					}
					else
					{
						bitArray.appendBits(binaryShiftByteCount - 31, 5);
					}
				}
				bitArray.appendBits(text[binaryShiftStart + i], 8);
			}
		}

		public override string ToString()
		{
			return "<" + binaryShiftStart + "::" + (binaryShiftStart + binaryShiftByteCount - 1) + ">";
		}
	}
	public static class Encoder
	{
		public const int DEFAULT_EC_PERCENT = 33;

		public const int DEFAULT_AZTEC_LAYERS = 0;

		private const int MAX_NB_BITS = 32;

		private const int MAX_NB_BITS_COMPACT = 4;

		private static readonly int[] WORD_SIZE = new int[33]
		{
			4, 6, 6, 8, 8, 8, 8, 8, 8, 10,
			10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
			10, 10, 10, 12, 12, 12, 12, 12, 12, 12,
			12, 12, 12
		};

		public static AztecCode encode(byte[] data)
		{
			return encode(data, 33, 0);
		}

		public static AztecCode encode(byte[] data, int minECCPercent, int userSpecifiedLayers)
		{
			ZXing.Common.BitArray bitArray = new HighLevelEncoder(data).encode();
			int num = bitArray.Size * minECCPercent / 100 + 11;
			int num2 = bitArray.Size + num;
			bool flag;
			int num3;
			int num4;
			int num5;
			ZXing.Common.BitArray bitArray2;
			if (userSpecifiedLayers != 0)
			{
				flag = userSpecifiedLayers < 0;
				num3 = Math.Abs(userSpecifiedLayers);
				if (num3 > (flag ? 4 : 32))
				{
					throw new ArgumentException($"Illegal value {userSpecifiedLayers} for layers");
				}
				num4 = TotalBitsInLayer(num3, flag);
				num5 = WORD_SIZE[num3];
				int num6 = num4 - num4 % num5;
				bitArray2 = stuffBits(bitArray, num5);
				if (bitArray2.Size + num > num6)
				{
					throw new ArgumentException("Data to large for user specified layer");
				}
				if (flag && bitArray2.Size > num5 * 64)
				{
					throw new ArgumentException("Data to large for user specified layer");
				}
			}
			else
			{
				num5 = 0;
				bitArray2 = null;
				int num7 = 0;
				while (true)
				{
					if (num7 > 32)
					{
						throw new ArgumentException("Data too large for an Aztec code");
					}
					flag = num7 <= 3;
					num3 = (flag ? (num7 + 1) : num7);
					num4 = TotalBitsInLayer(num3, flag);
					if (num2 <= num4)
					{
						if (num5 != WORD_SIZE[num3])
						{
							num5 = WORD_SIZE[num3];
							bitArray2 = stuffBits(bitArray, num5);
						}
						if (bitArray2 != null)
						{
							int num8 = num4 - num4 % num5;
							if ((!flag || bitArray2.Size <= num5 * 64) && bitArray2.Size + num <= num8)
							{
								break;
							}
						}
					}
					num7++;
				}
			}
			ZXing.Common.BitArray bitArray3 = generateCheckWords(bitArray2, num4, num5);
			int num9 = bitArray2.Size / num5;
			ZXing.Common.BitArray modeMessage = generateModeMessage(flag, num3, num9);
			int num10 = (flag ? 11 : 14) + num3 * 4;
			int[] array = new int[num10];
			int num11;
			if (flag)
			{
				num11 = num10;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i;
				}
			}
			else
			{
				num11 = num10 + 1 + 2 * ((num10 / 2 - 1) / 15);
				int num12 = num10 / 2;
				int num13 = num11 / 2;
				for (int j = 0; j < num12; j++)
				{
					int num14 = j + j / 15;
					array[num12 - j - 1] = num13 - num14 - 1;
					array[num12 + j] = num13 + num14 + 1;
				}
			}
			BitMatrix bitMatrix = new BitMatrix(num11);
			int k = 0;
			int num15 = 0;
			for (; k < num3; k++)
			{
				int num16 = (num3 - k) * 4 + (flag ? 9 : 12);
				for (int l = 0; l < num16; l++)
				{
					int num17 = l * 2;
					for (int m = 0; m < 2; m++)
					{
						if (bitArray3[num15 + num17 + m])
						{
							bitMatrix[array[k * 2 + m], array[k * 2 + l]] = true;
						}
						if (bitArray3[num15 + num16 * 2 + num17 + m])
						{
							bitMatrix[array[k * 2 + l], array[num10 - 1 - k * 2 - m]] = true;
						}
						if (bitArray3[num15 + num16 * 4 + num17 + m])
						{
							bitMatrix[array[num10 - 1 - k * 2 - m], array[num10 - 1 - k * 2 - l]] = true;
						}
						if (bitArray3[num15 + num16 * 6 + num17 + m])
						{
							bitMatrix[array[num10 - 1 - k * 2 - l], array[k * 2 + m]] = true;
						}
					}
				}
				num15 += num16 * 8;
			}
			drawModeMessage(bitMatrix, flag, num11, modeMessage);
			if (flag)
			{
				drawBullsEye(bitMatrix, num11 / 2, 5);
			}
			else
			{
				drawBullsEye(bitMatrix, num11 / 2, 7);
				int num18 = 0;
				int num19 = 0;
				while (num18 < num10 / 2 - 1)
				{
					for (int n = (num11 / 2) & 1; n < num11; n += 2)
					{
						bitMatrix[num11 / 2 - num19, n] = true;
						bitMatrix[num11 / 2 + num19, n] = true;
						bitMatrix[n, num11 / 2 - num19] = true;
						bitMatrix[n, num11 / 2 + num19] = true;
					}
					num18 += 15;
					num19 += 16;
				}
			}
			return new AztecCode
			{
				isCompact = flag,
				Size = num11,
				Layers = num3,
				CodeWords = num9,
				Matrix = bitMatrix
			};
		}

		private static void drawBullsEye(BitMatrix matrix, int center, int size)
		{
			for (int i = 0; i < size; i += 2)
			{
				for (int j = center - i; j <= center + i; j++)
				{
					matrix[j, center - i] = true;
					matrix[j, center + i] = true;
					matrix[center - i, j] = true;
					matrix[center + i, j] = true;
				}
			}
			matrix[center - size, center - size] = true;
			matrix[center - size + 1, center - size] = true;
			matrix[center - size, center - size + 1] = true;
			matrix[center + size, center - size] = true;
			matrix[center + size, center - size + 1] = true;
			matrix[center + size, center + size - 1] = true;
		}

		internal static ZXing.Common.BitArray generateModeMessage(bool compact, int layers, int messageSizeInWords)
		{
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			if (compact)
			{
				bitArray.appendBits(layers - 1, 2);
				bitArray.appendBits(messageSizeInWords - 1, 6);
				return generateCheckWords(bitArray, 28, 4);
			}
			bitArray.appendBits(layers - 1, 5);
			bitArray.appendBits(messageSizeInWords - 1, 11);
			return generateCheckWords(bitArray, 40, 4);
		}

		private static void drawModeMessage(BitMatrix matrix, bool compact, int matrixSize, ZXing.Common.BitArray modeMessage)
		{
			int num = matrixSize / 2;
			if (compact)
			{
				for (int i = 0; i < 7; i++)
				{
					int num2 = num - 3 + i;
					if (modeMessage[i])
					{
						matrix[num2, num - 5] = true;
					}
					if (modeMessage[i + 7])
					{
						matrix[num + 5, num2] = true;
					}
					if (modeMessage[20 - i])
					{
						matrix[num2, num + 5] = true;
					}
					if (modeMessage[27 - i])
					{
						matrix[num - 5, num2] = true;
					}
				}
				return;
			}
			for (int j = 0; j < 10; j++)
			{
				int num3 = num - 5 + j + j / 5;
				if (modeMessage[j])
				{
					matrix[num3, num - 7] = true;
				}
				if (modeMessage[j + 10])
				{
					matrix[num + 7, num3] = true;
				}
				if (modeMessage[29 - j])
				{
					matrix[num3, num + 7] = true;
				}
				if (modeMessage[39 - j])
				{
					matrix[num - 7, num3] = true;
				}
			}
		}

		private static ZXing.Common.BitArray generateCheckWords(ZXing.Common.BitArray bitArray, int totalBits, int wordSize)
		{
			if (bitArray.Size % wordSize != 0)
			{
				throw new InvalidOperationException("size of bit array is not a multiple of the word size");
			}
			int num = bitArray.Size / wordSize;
			ReedSolomonEncoder reedSolomonEncoder = new ReedSolomonEncoder(getGF(wordSize));
			int num2 = totalBits / wordSize;
			int[] array = bitsToWords(bitArray, wordSize, num2);
			reedSolomonEncoder.encode(array, num2 - num);
			int numBits = totalBits % wordSize;
			ZXing.Common.BitArray bitArray2 = new ZXing.Common.BitArray();
			bitArray2.appendBits(0, numBits);
			int[] array2 = array;
			foreach (int value in array2)
			{
				bitArray2.appendBits(value, wordSize);
			}
			return bitArray2;
		}

		private static int[] bitsToWords(ZXing.Common.BitArray stuffedBits, int wordSize, int totalWords)
		{
			int[] array = new int[totalWords];
			int i = 0;
			for (int num = stuffedBits.Size / wordSize; i < num; i++)
			{
				int num2 = 0;
				for (int j = 0; j < wordSize; j++)
				{
					num2 |= (stuffedBits[i * wordSize + j] ? (1 << wordSize - j - 1) : 0);
				}
				array[i] = num2;
			}
			return array;
		}

		private static GenericGF getGF(int wordSize)
		{
			return wordSize switch
			{
				4 => GenericGF.AZTEC_PARAM, 
				6 => GenericGF.AZTEC_DATA_6, 
				8 => GenericGF.AZTEC_DATA_8, 
				10 => GenericGF.AZTEC_DATA_10, 
				12 => GenericGF.AZTEC_DATA_12, 
				_ => throw new ArgumentException("Unsupported word size " + wordSize), 
			};
		}

		internal static ZXing.Common.BitArray stuffBits(ZXing.Common.BitArray bits, int wordSize)
		{
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			int size = bits.Size;
			int num = (1 << wordSize) - 2;
			for (int i = 0; i < size; i += wordSize)
			{
				int num2 = 0;
				for (int j = 0; j < wordSize; j++)
				{
					if (i + j >= size || bits[i + j])
					{
						num2 |= 1 << wordSize - 1 - j;
					}
				}
				if ((num2 & num) == num)
				{
					bitArray.appendBits(num2 & num, wordSize);
					i--;
				}
				else if ((num2 & num) == 0)
				{
					bitArray.appendBits(num2 | 1, wordSize);
					i--;
				}
				else
				{
					bitArray.appendBits(num2, wordSize);
				}
			}
			return bitArray;
		}

		private static int TotalBitsInLayer(int layers, bool compact)
		{
			return ((compact ? 88 : 112) + 16 * layers) * layers;
		}
	}
	public sealed class HighLevelEncoder
	{
		internal static string[] MODE_NAMES;

		internal const int MODE_UPPER = 0;

		internal const int MODE_LOWER = 1;

		internal const int MODE_DIGIT = 2;

		internal const int MODE_MIXED = 3;

		internal const int MODE_PUNCT = 4;

		internal static readonly int[][] LATCH_TABLE;

		internal static readonly int[][] CHAR_MAP;

		internal static readonly int[][] SHIFT_TABLE;

		private readonly byte[] text;

		static HighLevelEncoder()
		{
			MODE_NAMES = new string[5] { "UPPER", "LOWER", "DIGIT", "MIXED", "PUNCT" };
			LATCH_TABLE = new int[5][]
			{
				new int[5] { 0, 327708, 327710, 327709, 656318 },
				new int[5] { 590318, 0, 327710, 327709, 656318 },
				new int[5] { 262158, 590300, 0, 590301, 932798 },
				new int[5] { 327709, 327708, 656318, 0, 327710 },
				new int[5] { 327711, 656380, 656382, 656381, 0 }
			};
			CHAR_MAP = new int[5][];
			SHIFT_TABLE = new int[6][];
			CHAR_MAP[0] = new int[256];
			CHAR_MAP[1] = new int[256];
			CHAR_MAP[2] = new int[256];
			CHAR_MAP[3] = new int[256];
			CHAR_MAP[4] = new int[256];
			SHIFT_TABLE[0] = new int[6];
			SHIFT_TABLE[1] = new int[6];
			SHIFT_TABLE[2] = new int[6];
			SHIFT_TABLE[3] = new int[6];
			SHIFT_TABLE[4] = new int[6];
			SHIFT_TABLE[5] = new int[6];
			CHAR_MAP[0][32] = 1;
			for (int i = 65; i <= 90; i++)
			{
				CHAR_MAP[0][i] = i - 65 + 2;
			}
			CHAR_MAP[1][32] = 1;
			for (int j = 97; j <= 122; j++)
			{
				CHAR_MAP[1][j] = j - 97 + 2;
			}
			CHAR_MAP[2][32] = 1;
			for (int k = 48; k <= 57; k++)
			{
				CHAR_MAP[2][k] = k - 48 + 2;
			}
			CHAR_MAP[2][44] = 12;
			CHAR_MAP[2][46] = 13;
			int[] array = new int[28]
			{
				0, 32, 1, 2, 3, 4, 5, 6, 7, 8,
				9, 10, 11, 12, 13, 27, 28, 29, 30, 31,
				64, 92, 94, 95, 96, 124, 126, 127
			};
			for (int l = 0; l < array.Length; l++)
			{
				CHAR_MAP[3][array[l]] = l;
			}
			int[] array2 = new int[31]
			{
				0, 13, 0, 0, 0, 0, 33, 39, 35, 36,
				37, 38, 39, 40, 41, 42, 43, 44, 45, 46,
				47, 58, 59, 60, 61, 62, 63, 91, 93, 123,
				125
			};
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m] > 0)
				{
					CHAR_MAP[4][array2[m]] = m;
				}
			}
			int[][] sHIFT_TABLE = SHIFT_TABLE;
			for (int n = 0; n < sHIFT_TABLE.Length; n++)
			{
				SupportClass.Fill(sHIFT_TABLE[n], -1);
			}
			SHIFT_TABLE[0][4] = 0;
			SHIFT_TABLE[1][4] = 0;
			SHIFT_TABLE[1][0] = 28;
			SHIFT_TABLE[3][4] = 0;
			SHIFT_TABLE[2][4] = 0;
			SHIFT_TABLE[2][0] = 15;
		}

		public HighLevelEncoder(byte[] text)
		{
			this.text = text;
		}

		public ZXing.Common.BitArray encode()
		{
			ICollection<State> collection = new Collection<State>();
			collection.Add(State.INITIAL_STATE);
			for (int i = 0; i < text.Length; i++)
			{
				int num = ((i + 1 < text.Length) ? text[i + 1] : 0);
				int num2 = text[i] switch
				{
					13 => (num == 10) ? 2 : 0, 
					46 => (num == 32) ? 3 : 0, 
					44 => (num == 32) ? 4 : 0, 
					58 => (num == 32) ? 5 : 0, 
					_ => 0, 
				};
				if (num2 > 0)
				{
					collection = updateStateListForPair(collection, i, num2);
					i++;
				}
				else
				{
					collection = updateStateListForChar(collection, i);
				}
			}
			State state = null;
			foreach (State item in collection)
			{
				if (state == null)
				{
					state = item;
				}
				else if (item.BitCount < state.BitCount)
				{
					state = item;
				}
			}
			return state.toBitArray(text);
		}

		private ICollection<State> updateStateListForChar(IEnumerable<State> states, int index)
		{
			LinkedList<State> linkedList = new LinkedList<State>();
			foreach (State state in states)
			{
				updateStateForChar(state, index, linkedList);
			}
			return simplifyStates(linkedList);
		}

		private void updateStateForChar(State state, int index, ICollection<State> result)
		{
			char c = (char)(text[index] & 0xFF);
			bool flag = CHAR_MAP[state.Mode][(uint)c] > 0;
			State state2 = null;
			for (int i = 0; i <= 4; i++)
			{
				int num = CHAR_MAP[i][(uint)c];
				if (num > 0)
				{
					if (state2 == null)
					{
						state2 = state.endBinaryShift(index);
					}
					if (!flag || i == state.Mode || i == 2)
					{
						State item = state2.latchAndAppend(i, num);
						result.Add(item);
					}
					if (!flag && SHIFT_TABLE[state.Mode][i] >= 0)
					{
						State item2 = state2.shiftAndAppend(i, num);
						result.Add(item2);
					}
				}
			}
			if (state.BinaryShiftByteCount > 0 || CHAR_MAP[state.Mode][(uint)c] == 0)
			{
				State item3 = state.addBinaryShiftChar(index);
				result.Add(item3);
			}
		}

		private static ICollection<State> updateStateListForPair(IEnumerable<State> states, int index, int pairCode)
		{
			LinkedList<State> linkedList = new LinkedList<State>();
			foreach (State state in states)
			{
				updateStateForPair(state, index, pairCode, linkedList);
			}
			return simplifyStates(linkedList);
		}

		private static void updateStateForPair(State state, int index, int pairCode, ICollection<State> result)
		{
			State state2 = state.endBinaryShift(index);
			result.Add(state2.latchAndAppend(4, pairCode));
			if (state.Mode != 4)
			{
				result.Add(state2.shiftAndAppend(4, pairCode));
			}
			if (pairCode == 3 || pairCode == 4)
			{
				State item = state2.latchAndAppend(2, 16 - pairCode).latchAndAppend(2, 1);
				result.Add(item);
			}
			if (state.BinaryShiftByteCount > 0)
			{
				State item2 = state.addBinaryShiftChar(index).addBinaryShiftChar(index + 1);
				result.Add(item2);
			}
		}

		private static ICollection<State> simplifyStates(IEnumerable<State> states)
		{
			LinkedList<State> linkedList = new LinkedList<State>();
			List<State> list = new List<State>();
			foreach (State state in states)
			{
				bool flag = true;
				list.Clear();
				foreach (State item in linkedList)
				{
					if (item.isBetterThanOrEqualTo(state))
					{
						flag = false;
						break;
					}
					if (state.isBetterThanOrEqualTo(item))
					{
						list.Add(item);
					}
				}
				if (flag)
				{
					linkedList.AddLast(state);
				}
				foreach (State item2 in list)
				{
					linkedList.Remove(item2);
				}
			}
			return linkedList;
		}
	}
	public sealed class SimpleToken : Token
	{
		private readonly short value;

		private readonly short bitCount;

		public SimpleToken(Token previous, int value, int bitCount)
			: base(previous)
		{
			this.value = (short)value;
			this.bitCount = (short)bitCount;
		}

		public override void appendTo(ZXing.Common.BitArray bitArray, byte[] text)
		{
			bitArray.appendBits(value, bitCount);
		}

		public override string ToString()
		{
			int num = value & ((1 << (int)bitCount) - 1);
			num |= 1 << (int)bitCount;
			return "<" + SupportClass.ToBinaryString(num | (1 << (int)bitCount)).Substring(1) + ">";
		}
	}
	internal sealed class State
	{
		public static readonly State INITIAL_STATE = new State(Token.EMPTY, 0, 0, 0);

		private readonly int mode;

		private readonly Token token;

		private readonly int binaryShiftByteCount;

		private readonly int bitCount;

		public int Mode => mode;

		public Token Token => token;

		public int BinaryShiftByteCount => binaryShiftByteCount;

		public int BitCount => bitCount;

		public State(Token token, int mode, int binaryBytes, int bitCount)
		{
			this.token = token;
			this.mode = mode;
			binaryShiftByteCount = binaryBytes;
			this.bitCount = bitCount;
		}

		public State latchAndAppend(int mode, int value)
		{
			int num = bitCount;
			Token token = this.token;
			if (mode != this.mode)
			{
				int num2 = HighLevelEncoder.LATCH_TABLE[this.mode][mode];
				token = token.add(num2 & 0xFFFF, num2 >> 16);
				num += num2 >> 16;
			}
			int num3 = ((mode == 2) ? 4 : 5);
			token = token.add(value, num3);
			return new State(token, mode, 0, num + num3);
		}

		public State shiftAndAppend(int mode, int value)
		{
			Token obj = token;
			int num = ((this.mode == 2) ? 4 : 5);
			return new State(obj.add(HighLevelEncoder.SHIFT_TABLE[this.mode][mode], num).add(value, 5), this.mode, 0, bitCount + num + 5);
		}

		public State addBinaryShiftChar(int index)
		{
			Token token = this.token;
			int num = mode;
			int num2 = bitCount;
			if (mode == 4 || mode == 2)
			{
				int num3 = HighLevelEncoder.LATCH_TABLE[num][0];
				token = token.add(num3 & 0xFFFF, num3 >> 16);
				num2 += num3 >> 16;
				num = 0;
			}
			int num4 = ((binaryShiftByteCount == 0 || binaryShiftByteCount == 31) ? 18 : ((binaryShiftByteCount == 62) ? 9 : 8));
			State state = new State(token, num, binaryShiftByteCount + 1, num2 + num4);
			if (state.binaryShiftByteCount == 2078)
			{
				state = state.endBinaryShift(index + 1);
			}
			return state;
		}

		public State endBinaryShift(int index)
		{
			if (binaryShiftByteCount == 0)
			{
				return this;
			}
			return new State(token.addBinaryShift(index - binaryShiftByteCount, binaryShiftByteCount), mode, 0, bitCount);
		}

		public bool isBetterThanOrEqualTo(State other)
		{
			int num = bitCount + (HighLevelEncoder.LATCH_TABLE[mode][other.mode] >> 16);
			if (other.binaryShiftByteCount > 0 && (binaryShiftByteCount == 0 || binaryShiftByteCount > other.binaryShiftByteCount))
			{
				num += 10;
			}
			return num <= other.bitCount;
		}

		public ZXing.Common.BitArray toBitArray(byte[] text)
		{
			LinkedList<Token> linkedList = new LinkedList<Token>();
			for (Token previous = endBinaryShift(text.Length).token; previous != null; previous = previous.Previous)
			{
				linkedList.AddFirst(previous);
			}
			ZXing.Common.BitArray bitArray = new ZXing.Common.BitArray();
			foreach (Token item in linkedList)
			{
				item.appendTo(bitArray, text);
			}
			return bitArray;
		}

		public override string ToString()
		{
			return string.Format("{0} bits={1} bytes={2}", new object[3]
			{
				HighLevelEncoder.MODE_NAMES[mode],
				bitCount,
				binaryShiftByteCount
			});
		}
	}
	public abstract class Token
	{
		public static Token EMPTY = new SimpleToken(null, 0, 0);

		private readonly Token previous;

		public Token Previous => previous;

		protected Token(Token previous)
		{
			this.previous = previous;
		}

		public Token add(int value, int bitCount)
		{
			return new SimpleToken(this, value, bitCount);
		}

		public Token addBinaryShift(int start, int byteCount)
		{
			if (byteCount > 31)
			{
				_ = 62;
			}
			return new BinaryShiftToken(this, start, byteCount);
		}

		public abstract void appendTo(ZXing.Common.BitArray bitArray, byte[] text);
	}
}
