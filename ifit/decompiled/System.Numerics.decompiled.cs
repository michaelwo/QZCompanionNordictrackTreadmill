using System;
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Numerics.dll")]
[assembly: AssemblyDescription("System.Numerics.dll")]
[assembly: AssemblyDefaultAlias("System.Numerics.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("2.0.5.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: SecurityCritical]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("2.0.5.0")]
[module: UnverifiableCode]
internal static class SR
{
	internal static string Format(string resourceFormat, object p1)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1);
	}
}
namespace System.Numerics
{
	[Serializable]
	public readonly struct BigInteger : IFormattable, IComparable, IComparable<BigInteger>, IEquatable<BigInteger>
	{
		private enum GetBytesMode
		{
			AllocateArray,
			Count,
			Span
		}

		internal readonly int _sign;

		internal readonly uint[] _bits;

		private static readonly BigInteger s_bnMinInt = new BigInteger(-1, new uint[1] { 2147483648u });

		private static readonly BigInteger s_bnOneInt = new BigInteger(1);

		private static readonly BigInteger s_bnZeroInt = new BigInteger(0);

		private static readonly BigInteger s_bnMinusOneInt = new BigInteger(-1);

		private static readonly byte[] s_success = Array.Empty<byte>();

		public static BigInteger Zero => s_bnZeroInt;

		public static BigInteger One => s_bnOneInt;

		public static BigInteger MinusOne => s_bnMinusOneInt;

		public bool IsZero => _sign == 0;

		public BigInteger(int value)
		{
			if (value == -2147483648)
			{
				this = s_bnMinInt;
				return;
			}
			_sign = value;
			_bits = null;
		}

		[CLSCompliant(false)]
		public BigInteger(uint value)
		{
			if (value <= 2147483647)
			{
				_sign = (int)value;
				_bits = null;
			}
			else
			{
				_sign = 1;
				_bits = new uint[1];
				_bits[0] = value;
			}
		}

		public BigInteger(long value)
		{
			if (-2147483648 < value && value <= 2147483647)
			{
				_sign = (int)value;
				_bits = null;
				return;
			}
			if (value == -2147483648)
			{
				this = s_bnMinInt;
				return;
			}
			ulong num = 0uL;
			if (value < 0)
			{
				num = (ulong)(-value);
				_sign = -1;
			}
			else
			{
				num = (ulong)value;
				_sign = 1;
			}
			if (num <= 4294967295u)
			{
				_bits = new uint[1];
				_bits[0] = (uint)num;
			}
			else
			{
				_bits = new uint[2];
				_bits[0] = (uint)num;
				_bits[1] = (uint)(num >> 32);
			}
		}

		[CLSCompliant(false)]
		public BigInteger(ulong value)
		{
			if (value <= 2147483647)
			{
				_sign = (int)value;
				_bits = null;
			}
			else if (value <= 4294967295u)
			{
				_sign = 1;
				_bits = new uint[1];
				_bits[0] = (uint)value;
			}
			else
			{
				_sign = 1;
				_bits = new uint[2];
				_bits[0] = (uint)value;
				_bits[1] = (uint)(value >> 32);
			}
		}

		public BigInteger(float value)
			: this((double)value)
		{
		}

		public BigInteger(double value)
		{
			if (!double.IsFinite(value))
			{
				if (double.IsInfinity(value))
				{
					throw new OverflowException("BigInteger cannot represent infinity.");
				}
				throw new OverflowException("The value is not a number.");
			}
			_sign = 0;
			_bits = null;
			NumericsHelpers.GetDoubleParts(value, out var sign, out var exp, out var man, out var _);
			if (man == 0L)
			{
				this = Zero;
				return;
			}
			if (exp <= 0)
			{
				if (exp <= -64)
				{
					this = Zero;
					return;
				}
				this = man >> -exp;
				if (sign < 0)
				{
					_sign = -_sign;
				}
				return;
			}
			if (exp <= 11)
			{
				this = man << exp;
				if (sign < 0)
				{
					_sign = -_sign;
				}
				return;
			}
			man <<= 11;
			exp -= 11;
			int num = (exp - 1) / 32 + 1;
			int num2 = num * 32 - exp;
			_bits = new uint[num + 2];
			_bits[num + 1] = (uint)(man >> num2 + 32);
			_bits[num] = (uint)(man >> num2);
			if (num2 > 0)
			{
				_bits[num - 1] = (uint)((int)man << 32 - num2);
			}
			_sign = sign;
		}

		public BigInteger(decimal value)
		{
			int[] bits = decimal.GetBits(decimal.Truncate(value));
			int num = 3;
			while (num > 0 && bits[num - 1] == 0)
			{
				num--;
			}
			switch (num)
			{
			case 0:
				this = s_bnZeroInt;
				return;
			case 1:
				if (bits[0] > 0)
				{
					_sign = bits[0];
					_sign *= (((bits[3] & -2147483648) == 0) ? 1 : (-1));
					_bits = null;
					return;
				}
				break;
			}
			_bits = new uint[num];
			_bits[0] = (uint)bits[0];
			if (num > 1)
			{
				_bits[1] = (uint)bits[1];
			}
			if (num > 2)
			{
				_bits[2] = (uint)bits[2];
			}
			_sign = (((bits[3] & -2147483648) == 0) ? 1 : (-1));
		}

		[CLSCompliant(false)]
		public BigInteger(byte[] value)
			: this(new ReadOnlySpan<byte>(value ?? throw new ArgumentNullException("value")))
		{
		}

		public BigInteger(ReadOnlySpan<byte> value, bool isUnsigned = false, bool isBigEndian = false)
		{
			int num = value.Length;
			bool flag;
			if (num > 0)
			{
				byte num2 = (isBigEndian ? value[0] : value[num - 1]);
				flag = (num2 & 0x80) != 0 && !isUnsigned;
				if (num2 == 0)
				{
					if (isBigEndian)
					{
						int i;
						for (i = 1; i < num && value[i] == 0; i++)
						{
						}
						value = value.Slice(i);
						num = value.Length;
					}
					else
					{
						num -= 2;
						while (num >= 0 && value[num] == 0)
						{
							num--;
						}
						num++;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (num == 0)
			{
				_sign = 0;
				_bits = null;
				return;
			}
			if (num <= 4)
			{
				_sign = (flag ? (-1) : 0);
				if (isBigEndian)
				{
					for (int j = 0; j < num; j++)
					{
						_sign = (_sign << 8) | value[j];
					}
				}
				else
				{
					for (int num3 = num - 1; num3 >= 0; num3--)
					{
						_sign = (_sign << 8) | value[num3];
					}
				}
				_bits = null;
				if (_sign < 0 && !flag)
				{
					_bits = new uint[1] { (uint)_sign };
					_sign = 1;
				}
				if (_sign == -2147483648)
				{
					this = s_bnMinInt;
				}
				return;
			}
			int num4 = num % 4;
			int num5 = num / 4 + ((num4 != 0) ? 1 : 0);
			uint[] array = new uint[num5];
			int num6 = num - 1;
			int k;
			if (isBigEndian)
			{
				int num7 = num - 4;
				for (k = 0; k < num5 - ((num4 != 0) ? 1 : 0); k++)
				{
					for (int l = 0; l < 4; l++)
					{
						byte b = value[num7];
						array[k] = (array[k] << 8) | b;
						num7++;
					}
					num7 -= 8;
				}
			}
			else
			{
				int num7 = 3;
				for (k = 0; k < num5 - ((num4 != 0) ? 1 : 0); k++)
				{
					for (int m = 0; m < 4; m++)
					{
						byte b2 = value[num7];
						array[k] = (array[k] << 8) | b2;
						num7--;
					}
					num7 += 8;
				}
			}
			if (num4 != 0)
			{
				if (flag)
				{
					array[num5 - 1] = 4294967295u;
				}
				if (isBigEndian)
				{
					for (int num7 = 0; num7 < num4; num7++)
					{
						byte b3 = value[num7];
						array[k] = (array[k] << 8) | b3;
					}
				}
				else
				{
					for (int num7 = num6; num7 >= num - num4; num7--)
					{
						byte b4 = value[num7];
						array[k] = (array[k] << 8) | b4;
					}
				}
			}
			if (flag)
			{
				NumericsHelpers.DangerousMakeTwosComplement(array);
				int num8 = array.Length - 1;
				while (num8 >= 0 && array[num8] == 0)
				{
					num8--;
				}
				num8++;
				if (num8 == 1)
				{
					switch (array[0])
					{
					case 1u:
						this = s_bnMinusOneInt;
						return;
					case 2147483648u:
						this = s_bnMinInt;
						return;
					}
					if ((int)array[0] > 0)
					{
						_sign = -1 * (int)array[0];
						_bits = null;
						return;
					}
				}
				if (num8 != array.Length)
				{
					_sign = -1;
					_bits = new uint[num8];
					Array.Copy(array, 0, _bits, 0, num8);
				}
				else
				{
					_sign = -1;
					_bits = array;
				}
			}
			else
			{
				_sign = 1;
				_bits = array;
			}
		}

		internal BigInteger(int n, uint[] rgu)
		{
			_sign = n;
			_bits = rgu;
		}

		internal BigInteger(uint[] value, bool negative)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			int num = value.Length;
			while (num > 0 && value[num - 1] == 0)
			{
				num--;
			}
			switch (num)
			{
			case 0:
				this = s_bnZeroInt;
				break;
			case 1:
				if (value[0] < 2147483648u)
				{
					_sign = (int)(negative ? (0 - value[0]) : value[0]);
					_bits = null;
					if (_sign == -2147483648)
					{
						this = s_bnMinInt;
					}
					break;
				}
				goto default;
			default:
				_sign = ((!negative) ? 1 : (-1));
				_bits = new uint[num];
				Array.Copy(value, 0, _bits, 0, num);
				break;
			}
		}

		public static BigInteger Parse(string value, IFormatProvider provider)
		{
			return Parse(value, NumberStyles.Integer, NumberFormatInfo.GetInstance(provider));
		}

		public static BigInteger Parse(string value, NumberStyles style, IFormatProvider provider)
		{
			return BigNumber.ParseBigInteger(value, style, NumberFormatInfo.GetInstance(provider));
		}

		public static BigInteger Abs(BigInteger value)
		{
			if (!(value >= Zero))
			{
				return -value;
			}
			return value;
		}

		public static BigInteger DivRem(BigInteger dividend, BigInteger divisor, out BigInteger remainder)
		{
			bool flag = dividend._bits == null;
			bool flag2 = divisor._bits == null;
			if (flag && flag2)
			{
				remainder = dividend._sign % divisor._sign;
				return dividend._sign / divisor._sign;
			}
			if (flag)
			{
				remainder = dividend;
				return s_bnZeroInt;
			}
			if (flag2)
			{
				uint remainder2;
				uint[] value = BigIntegerCalculator.Divide(dividend._bits, NumericsHelpers.Abs(divisor._sign), out remainder2);
				remainder = ((dividend._sign < 0) ? (-1 * remainder2) : remainder2);
				return new BigInteger(value, (dividend._sign < 0) ^ (divisor._sign < 0));
			}
			if (dividend._bits.Length < divisor._bits.Length)
			{
				remainder = dividend;
				return s_bnZeroInt;
			}
			uint[] remainder3;
			uint[] value2 = BigIntegerCalculator.Divide(dividend._bits, divisor._bits, out remainder3);
			remainder = new BigInteger(remainder3, dividend._sign < 0);
			return new BigInteger(value2, (dividend._sign < 0) ^ (divisor._sign < 0));
		}

		public static BigInteger GreatestCommonDivisor(BigInteger left, BigInteger right)
		{
			bool flag = left._bits == null;
			bool flag2 = right._bits == null;
			if (flag && flag2)
			{
				return BigIntegerCalculator.Gcd(NumericsHelpers.Abs(left._sign), NumericsHelpers.Abs(right._sign));
			}
			if (flag)
			{
				if (left._sign == 0)
				{
					return new BigInteger(right._bits, negative: false);
				}
				return BigIntegerCalculator.Gcd(right._bits, NumericsHelpers.Abs(left._sign));
			}
			if (flag2)
			{
				if (right._sign == 0)
				{
					return new BigInteger(left._bits, negative: false);
				}
				return BigIntegerCalculator.Gcd(left._bits, NumericsHelpers.Abs(right._sign));
			}
			if (BigIntegerCalculator.Compare(left._bits, right._bits) < 0)
			{
				return GreatestCommonDivisor(right._bits, left._bits);
			}
			return GreatestCommonDivisor(left._bits, right._bits);
		}

		private static BigInteger GreatestCommonDivisor(uint[] leftBits, uint[] rightBits)
		{
			if (rightBits.Length == 1)
			{
				uint right = BigIntegerCalculator.Remainder(leftBits, rightBits[0]);
				return BigIntegerCalculator.Gcd(rightBits[0], right);
			}
			if (rightBits.Length == 2)
			{
				uint[] array = BigIntegerCalculator.Remainder(leftBits, rightBits);
				ulong left = ((ulong)rightBits[1] << 32) | rightBits[0];
				ulong right2 = ((ulong)array[1] << 32) | array[0];
				return BigIntegerCalculator.Gcd(left, right2);
			}
			return new BigInteger(BigIntegerCalculator.Gcd(leftBits, rightBits), negative: false);
		}

		public override int GetHashCode()
		{
			if (_bits == null)
			{
				return _sign;
			}
			int num = _sign;
			int num2 = _bits.Length;
			while (--num2 >= 0)
			{
				num = NumericsHelpers.CombineHash(num, (int)_bits[num2]);
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BigInteger))
			{
				return false;
			}
			return Equals((BigInteger)obj);
		}

		public bool Equals(long other)
		{
			if (_bits == null)
			{
				return _sign == other;
			}
			int num;
			if ((_sign ^ other) < 0 || (num = _bits.Length) > 2)
			{
				return false;
			}
			ulong num2 = (ulong)((other < 0) ? (-other) : other);
			if (num == 1)
			{
				return _bits[0] == num2;
			}
			return NumericsHelpers.MakeUlong(_bits[1], _bits[0]) == num2;
		}

		public bool Equals(BigInteger other)
		{
			if (_sign != other._sign)
			{
				return false;
			}
			if (_bits == other._bits)
			{
				return true;
			}
			if (_bits == null || other._bits == null)
			{
				return false;
			}
			int num = _bits.Length;
			if (num != other._bits.Length)
			{
				return false;
			}
			return GetDiffLength(_bits, other._bits, num) == 0;
		}

		public int CompareTo(long other)
		{
			if (_bits == null)
			{
				return ((long)_sign).CompareTo(other);
			}
			int num;
			if ((_sign ^ other) < 0 || (num = _bits.Length) > 2)
			{
				return _sign;
			}
			ulong value = (ulong)((other < 0) ? (-other) : other);
			ulong num2 = ((num == 2) ? NumericsHelpers.MakeUlong(_bits[1], _bits[0]) : _bits[0]);
			return _sign * num2.CompareTo(value);
		}

		public int CompareTo(BigInteger other)
		{
			if ((_sign ^ other._sign) < 0)
			{
				if (_sign >= 0)
				{
					return 1;
				}
				return -1;
			}
			if (_bits == null)
			{
				if (other._bits == null)
				{
					if (_sign >= other._sign)
					{
						if (_sign <= other._sign)
						{
							return 0;
						}
						return 1;
					}
					return -1;
				}
				return -other._sign;
			}
			int num;
			int num2;
			if (other._bits == null || (num = _bits.Length) > (num2 = other._bits.Length))
			{
				return _sign;
			}
			if (num < num2)
			{
				return -_sign;
			}
			int diffLength = GetDiffLength(_bits, other._bits, num);
			if (diffLength == 0)
			{
				return 0;
			}
			if (_bits[diffLength - 1] >= other._bits[diffLength - 1])
			{
				return _sign;
			}
			return -_sign;
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is BigInteger))
			{
				throw new ArgumentException("The parameter must be a BigInteger.", "obj");
			}
			return CompareTo((BigInteger)obj);
		}

		public byte[] ToByteArray()
		{
			return ToByteArray(false, false);
		}

		public byte[] ToByteArray(bool isUnsigned = false, bool isBigEndian = false)
		{
			int bytesWritten = 0;
			return TryGetBytes(GetBytesMode.AllocateArray, default(Span<byte>), isUnsigned, isBigEndian, ref bytesWritten);
		}

		public bool TryWriteBytes(Span<byte> destination, out int bytesWritten, bool isUnsigned = false, bool isBigEndian = false)
		{
			bytesWritten = 0;
			if (TryGetBytes(GetBytesMode.Span, destination, isUnsigned, isBigEndian, ref bytesWritten) == null)
			{
				bytesWritten = 0;
				return false;
			}
			return true;
		}

		internal bool TryWriteOrCountBytes(Span<byte> destination, out int bytesWritten, bool isUnsigned = false, bool isBigEndian = false)
		{
			bytesWritten = 0;
			return TryGetBytes(GetBytesMode.Span, destination, isUnsigned, isBigEndian, ref bytesWritten) != null;
		}

		private byte[] TryGetBytes(GetBytesMode mode, Span<byte> destination, bool isUnsigned, bool isBigEndian, ref int bytesWritten)
		{
			int sign = _sign;
			if (sign == 0)
			{
				switch (mode)
				{
				case GetBytesMode.AllocateArray:
					return new byte[1];
				case GetBytesMode.Count:
					bytesWritten = 1;
					return null;
				default:
					bytesWritten = 1;
					if (destination.Length != 0)
					{
						destination[0] = 0;
						return s_success;
					}
					return null;
				}
			}
			if (isUnsigned && sign < 0)
			{
				throw new OverflowException("Negative values do not have an unsigned representation.");
			}
			int i = 0;
			uint[] bits = _bits;
			byte b;
			uint num;
			if (bits == null)
			{
				b = (byte)((sign < 0) ? 255u : 0u);
				num = (uint)sign;
			}
			else if (sign == -1)
			{
				b = 255;
				for (; bits[i] == 0; i++)
				{
				}
				num = ~bits[bits.Length - 1];
				if (bits.Length - 1 == i)
				{
					num++;
				}
			}
			else
			{
				b = 0;
				num = bits[bits.Length - 1];
			}
			byte b2;
			int num2;
			if ((b2 = (byte)(num >> 24)) != b)
			{
				num2 = 3;
			}
			else if ((b2 = (byte)(num >> 16)) != b)
			{
				num2 = 2;
			}
			else if ((b2 = (byte)(num >> 8)) != b)
			{
				num2 = 1;
			}
			else
			{
				b2 = (byte)num;
				num2 = 0;
			}
			bool flag = (b2 & 0x80) != (b & 0x80) && !isUnsigned;
			int num3 = num2 + 1 + (flag ? 1 : 0);
			if (bits != null)
			{
				num3 = checked(4 * (bits.Length - 1) + num3);
			}
			byte[] result;
			switch (mode)
			{
			case GetBytesMode.AllocateArray:
				destination = (result = new byte[num3]);
				break;
			case GetBytesMode.Count:
				bytesWritten = num3;
				return null;
			default:
				bytesWritten = num3;
				if (destination.Length < num3)
				{
					return null;
				}
				result = s_success;
				break;
			}
			int num4 = (isBigEndian ? (num3 - 1) : 0);
			int num5 = ((!isBigEndian) ? 1 : (-1));
			if (bits != null)
			{
				for (int j = 0; j < bits.Length - 1; j++)
				{
					uint num6 = bits[j];
					if (sign == -1)
					{
						num6 = ~num6;
						if (j <= i)
						{
							num6++;
						}
					}
					destination[num4] = (byte)num6;
					num4 += num5;
					destination[num4] = (byte)(num6 >> 8);
					num4 += num5;
					destination[num4] = (byte)(num6 >> 16);
					num4 += num5;
					destination[num4] = (byte)(num6 >> 24);
					num4 += num5;
				}
			}
			destination[num4] = (byte)num;
			if (num2 != 0)
			{
				num4 += num5;
				destination[num4] = (byte)(num >> 8);
				if (num2 != 1)
				{
					num4 += num5;
					destination[num4] = (byte)(num >> 16);
					if (num2 != 2)
					{
						num4 += num5;
						destination[num4] = (byte)(num >> 24);
					}
				}
			}
			if (flag)
			{
				num4 += num5;
				destination[num4] = b;
			}
			return result;
		}

		public override string ToString()
		{
			return BigNumber.FormatBigInteger(this, null, NumberFormatInfo.CurrentInfo);
		}

		public string ToString(IFormatProvider provider)
		{
			return BigNumber.FormatBigInteger(this, null, NumberFormatInfo.GetInstance(provider));
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return BigNumber.FormatBigInteger(this, format, NumberFormatInfo.GetInstance(provider));
		}

		private static BigInteger Add(uint[] leftBits, int leftSign, uint[] rightBits, int rightSign)
		{
			bool flag = leftBits == null;
			bool flag2 = rightBits == null;
			if (flag && flag2)
			{
				return (long)leftSign + (long)rightSign;
			}
			if (flag)
			{
				return new BigInteger(BigIntegerCalculator.Add(rightBits, NumericsHelpers.Abs(leftSign)), leftSign < 0);
			}
			if (flag2)
			{
				return new BigInteger(BigIntegerCalculator.Add(leftBits, NumericsHelpers.Abs(rightSign)), leftSign < 0);
			}
			if (leftBits.Length < rightBits.Length)
			{
				return new BigInteger(BigIntegerCalculator.Add(rightBits, leftBits), leftSign < 0);
			}
			return new BigInteger(BigIntegerCalculator.Add(leftBits, rightBits), leftSign < 0);
		}

		public static BigInteger operator -(BigInteger left, BigInteger right)
		{
			if (left._sign < 0 != right._sign < 0)
			{
				return Add(left._bits, left._sign, right._bits, -1 * right._sign);
			}
			return Subtract(left._bits, left._sign, right._bits, right._sign);
		}

		private static BigInteger Subtract(uint[] leftBits, int leftSign, uint[] rightBits, int rightSign)
		{
			bool flag = leftBits == null;
			bool flag2 = rightBits == null;
			if (flag && flag2)
			{
				return (long)leftSign - (long)rightSign;
			}
			if (flag)
			{
				return new BigInteger(BigIntegerCalculator.Subtract(rightBits, NumericsHelpers.Abs(leftSign)), leftSign >= 0);
			}
			if (flag2)
			{
				return new BigInteger(BigIntegerCalculator.Subtract(leftBits, NumericsHelpers.Abs(rightSign)), leftSign < 0);
			}
			if (BigIntegerCalculator.Compare(leftBits, rightBits) < 0)
			{
				return new BigInteger(BigIntegerCalculator.Subtract(rightBits, leftBits), leftSign >= 0);
			}
			return new BigInteger(BigIntegerCalculator.Subtract(leftBits, rightBits), leftSign < 0);
		}

		public static implicit operator BigInteger(byte value)
		{
			return new BigInteger(value);
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(sbyte value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(short value)
		{
			return new BigInteger(value);
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(ushort value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(int value)
		{
			return new BigInteger(value);
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(uint value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(long value)
		{
			return new BigInteger(value);
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(ulong value)
		{
			return new BigInteger(value);
		}

		public static explicit operator BigInteger(double value)
		{
			return new BigInteger(value);
		}

		public static explicit operator byte(BigInteger value)
		{
			return checked((byte)(int)value);
		}

		[CLSCompliant(false)]
		public static explicit operator sbyte(BigInteger value)
		{
			return checked((sbyte)(int)value);
		}

		public static explicit operator short(BigInteger value)
		{
			return checked((short)(int)value);
		}

		[CLSCompliant(false)]
		public static explicit operator ushort(BigInteger value)
		{
			return checked((ushort)(int)value);
		}

		public static explicit operator int(BigInteger value)
		{
			if (value._bits == null)
			{
				return value._sign;
			}
			if (value._bits.Length > 1)
			{
				throw new OverflowException("Value was either too large or too small for an Int32.");
			}
			if (value._sign > 0)
			{
				return checked((int)value._bits[0]);
			}
			if (value._bits[0] > 2147483648u)
			{
				throw new OverflowException("Value was either too large or too small for an Int32.");
			}
			return (int)(0 - value._bits[0]);
		}

		[CLSCompliant(false)]
		public static explicit operator uint(BigInteger value)
		{
			if (value._bits == null)
			{
				return checked((uint)value._sign);
			}
			if (value._bits.Length > 1 || value._sign < 0)
			{
				throw new OverflowException("Value was either too large or too small for a UInt32.");
			}
			return value._bits[0];
		}

		public static explicit operator long(BigInteger value)
		{
			if (value._bits == null)
			{
				return value._sign;
			}
			int num = value._bits.Length;
			if (num > 2)
			{
				throw new OverflowException("Value was either too large or too small for an Int64.");
			}
			ulong num2 = ((num <= 1) ? value._bits[0] : NumericsHelpers.MakeUlong(value._bits[1], value._bits[0]));
			long num3 = (long)((value._sign > 0) ? num2 : (0L - num2));
			if ((num3 > 0 && value._sign > 0) || (num3 < 0 && value._sign < 0))
			{
				return num3;
			}
			throw new OverflowException("Value was either too large or too small for an Int64.");
		}

		[CLSCompliant(false)]
		public static explicit operator ulong(BigInteger value)
		{
			if (value._bits == null)
			{
				return checked((ulong)value._sign);
			}
			int num = value._bits.Length;
			if (num > 2 || value._sign < 0)
			{
				throw new OverflowException("Value was either too large or too small for a UInt64.");
			}
			if (num > 1)
			{
				return NumericsHelpers.MakeUlong(value._bits[1], value._bits[0]);
			}
			return value._bits[0];
		}

		public static explicit operator float(BigInteger value)
		{
			return (float)(double)value;
		}

		public static explicit operator double(BigInteger value)
		{
			int sign = value._sign;
			uint[] bits = value._bits;
			if (bits == null)
			{
				return sign;
			}
			int num = bits.Length;
			if (num > 32)
			{
				if (sign == 1)
				{
					return 1.0 / 0.0;
				}
				return -1.0 / 0.0;
			}
			long num2 = bits[num - 1];
			ulong num3 = ((num > 1) ? bits[num - 2] : 0u);
			ulong num4 = ((num > 2) ? bits[num - 3] : 0u);
			int num5 = NumericsHelpers.CbitHighZero((uint)num2);
			int exp = (num - 2) * 32 - num5;
			ulong man = (ulong)(num2 << 32 + num5) | (num3 << num5) | (num4 >> 32 - num5);
			return NumericsHelpers.GetDoubleFromParts(sign, exp, man);
		}

		public static explicit operator decimal(BigInteger value)
		{
			if (value._bits == null)
			{
				return value._sign;
			}
			int num = value._bits.Length;
			if (num > 3)
			{
				throw new OverflowException("Value was either too large or too small for a Decimal.");
			}
			int lo = 0;
			int mid = 0;
			int hi = 0;
			if (num > 2)
			{
				hi = (int)value._bits[2];
			}
			if (num > 1)
			{
				mid = (int)value._bits[1];
			}
			if (num > 0)
			{
				lo = (int)value._bits[0];
			}
			return new decimal(lo, mid, hi, value._sign < 0, 0);
		}

		public static BigInteger operator <<(BigInteger value, int shift)
		{
			if (shift == 0)
			{
				return value;
			}
			if (shift == -2147483648)
			{
				return value >> 2147483647 >> 1;
			}
			if (shift < 0)
			{
				return value >> -shift;
			}
			int num = shift / 32;
			int num2 = shift - num * 32;
			uint[] xd;
			int xl;
			bool partsForBitManipulation = GetPartsForBitManipulation(ref value, out xd, out xl);
			uint[] array = new uint[xl + num + 1];
			if (num2 == 0)
			{
				for (int i = 0; i < xl; i++)
				{
					array[i + num] = xd[i];
				}
			}
			else
			{
				int num3 = 32 - num2;
				uint num4 = 0u;
				int j;
				for (j = 0; j < xl; j++)
				{
					uint num5 = xd[j];
					array[j + num] = (num5 << num2) | num4;
					num4 = num5 >> num3;
				}
				array[j + num] = num4;
			}
			return new BigInteger(array, partsForBitManipulation);
		}

		public static BigInteger operator >>(BigInteger value, int shift)
		{
			if (shift == 0)
			{
				return value;
			}
			if (shift == -2147483648)
			{
				return value << 2147483647 << 1;
			}
			if (shift < 0)
			{
				return value << -shift;
			}
			int num = shift / 32;
			int num2 = shift - num * 32;
			uint[] xd;
			int xl;
			bool partsForBitManipulation = GetPartsForBitManipulation(ref value, out xd, out xl);
			if (partsForBitManipulation)
			{
				if (shift >= 32 * xl)
				{
					return MinusOne;
				}
				uint[] array = new uint[xl];
				Array.Copy(xd, 0, array, 0, xl);
				xd = array;
				NumericsHelpers.DangerousMakeTwosComplement(xd);
			}
			int num3 = xl - num;
			if (num3 < 0)
			{
				num3 = 0;
			}
			uint[] array2 = new uint[num3];
			if (num2 == 0)
			{
				for (int num4 = xl - 1; num4 >= num; num4--)
				{
					array2[num4 - num] = xd[num4];
				}
			}
			else
			{
				int num5 = 32 - num2;
				uint num6 = 0u;
				for (int num7 = xl - 1; num7 >= num; num7--)
				{
					uint num8 = xd[num7];
					if (partsForBitManipulation && num7 == xl - 1)
					{
						array2[num7 - num] = (num8 >> num2) | (uint)(-1 << num5);
					}
					else
					{
						array2[num7 - num] = (num8 >> num2) | num6;
					}
					num6 = num8 << num5;
				}
			}
			if (partsForBitManipulation)
			{
				NumericsHelpers.DangerousMakeTwosComplement(array2);
			}
			return new BigInteger(array2, partsForBitManipulation);
		}

		public static BigInteger operator -(BigInteger value)
		{
			return new BigInteger(-value._sign, value._bits);
		}

		public static BigInteger operator --(BigInteger value)
		{
			return value - One;
		}

		public static BigInteger operator +(BigInteger left, BigInteger right)
		{
			if (left._sign < 0 != right._sign < 0)
			{
				return Subtract(left._bits, left._sign, right._bits, -1 * right._sign);
			}
			return Add(left._bits, left._sign, right._bits, right._sign);
		}

		public static BigInteger operator *(BigInteger left, BigInteger right)
		{
			bool flag = left._bits == null;
			bool flag2 = right._bits == null;
			if (flag && flag2)
			{
				return (long)left._sign * (long)right._sign;
			}
			if (flag)
			{
				return new BigInteger(BigIntegerCalculator.Multiply(right._bits, NumericsHelpers.Abs(left._sign)), (left._sign < 0) ^ (right._sign < 0));
			}
			if (flag2)
			{
				return new BigInteger(BigIntegerCalculator.Multiply(left._bits, NumericsHelpers.Abs(right._sign)), (left._sign < 0) ^ (right._sign < 0));
			}
			if (left._bits == right._bits)
			{
				return new BigInteger(BigIntegerCalculator.Square(left._bits), (left._sign < 0) ^ (right._sign < 0));
			}
			if (left._bits.Length < right._bits.Length)
			{
				return new BigInteger(BigIntegerCalculator.Multiply(right._bits, left._bits), (left._sign < 0) ^ (right._sign < 0));
			}
			return new BigInteger(BigIntegerCalculator.Multiply(left._bits, right._bits), (left._sign < 0) ^ (right._sign < 0));
		}

		public static BigInteger operator /(BigInteger dividend, BigInteger divisor)
		{
			bool flag = dividend._bits == null;
			bool flag2 = divisor._bits == null;
			if (flag && flag2)
			{
				return dividend._sign / divisor._sign;
			}
			if (flag)
			{
				return s_bnZeroInt;
			}
			if (flag2)
			{
				return new BigInteger(BigIntegerCalculator.Divide(dividend._bits, NumericsHelpers.Abs(divisor._sign)), (dividend._sign < 0) ^ (divisor._sign < 0));
			}
			if (dividend._bits.Length < divisor._bits.Length)
			{
				return s_bnZeroInt;
			}
			return new BigInteger(BigIntegerCalculator.Divide(dividend._bits, divisor._bits), (dividend._sign < 0) ^ (divisor._sign < 0));
		}

		public static BigInteger operator %(BigInteger dividend, BigInteger divisor)
		{
			bool flag = dividend._bits == null;
			bool flag2 = divisor._bits == null;
			if (flag && flag2)
			{
				return dividend._sign % divisor._sign;
			}
			if (flag)
			{
				return dividend;
			}
			if (flag2)
			{
				uint num = BigIntegerCalculator.Remainder(dividend._bits, NumericsHelpers.Abs(divisor._sign));
				return (dividend._sign < 0) ? (-1 * num) : num;
			}
			if (dividend._bits.Length < divisor._bits.Length)
			{
				return dividend;
			}
			return new BigInteger(BigIntegerCalculator.Remainder(dividend._bits, divisor._bits), dividend._sign < 0);
		}

		public static bool operator <(BigInteger left, BigInteger right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(BigInteger left, BigInteger right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(BigInteger left, BigInteger right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(BigInteger left, BigInteger right)
		{
			return left.CompareTo(right) >= 0;
		}

		public static bool operator !=(BigInteger left, BigInteger right)
		{
			return !left.Equals(right);
		}

		public static bool operator <(BigInteger left, long right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(BigInteger left, long right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(BigInteger left, long right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(BigInteger left, long right)
		{
			return left.CompareTo(right) >= 0;
		}

		public static bool operator ==(BigInteger left, long right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(BigInteger left, long right)
		{
			return !left.Equals(right);
		}

		public static bool operator <(long left, BigInteger right)
		{
			return right.CompareTo(left) > 0;
		}

		public static bool operator <=(long left, BigInteger right)
		{
			return right.CompareTo(left) >= 0;
		}

		private static bool GetPartsForBitManipulation(ref BigInteger x, out uint[] xd, out int xl)
		{
			if (x._bits == null)
			{
				if (x._sign < 0)
				{
					xd = new uint[1] { (uint)(-x._sign) };
				}
				else
				{
					xd = new uint[1] { (uint)x._sign };
				}
			}
			else
			{
				xd = x._bits;
			}
			xl = ((x._bits == null) ? 1 : x._bits.Length);
			return x._sign < 0;
		}

		internal static int GetDiffLength(uint[] rgu1, uint[] rgu2, int cu)
		{
			int num = cu;
			while (--num >= 0)
			{
				if (rgu1[num] != rgu2[num])
				{
					return num + 1;
				}
			}
			return 0;
		}
	}
	internal static class BigIntegerCalculator
	{
		internal struct BitsBuffer
		{
			private uint[] _bits;

			private int _length;

			public BitsBuffer(int size, uint[] value)
			{
				_bits = new uint[size];
				_length = ActualLength(value);
				Array.Copy(value, 0, _bits, 0, _length);
			}

			public unsafe void Reduce(ref BitsBuffer modulus)
			{
				if (_length < modulus._length)
				{
					return;
				}
				fixed (uint* bits = _bits)
				{
					fixed (uint* bits2 = modulus._bits)
					{
						Divide(bits, _length, bits2, modulus._length, null, 0);
					}
				}
				_length = ActualLength(_bits, modulus._length);
			}

			public void Overwrite(ulong value)
			{
				if (_length > 2)
				{
					Array.Clear(_bits, 2, _length - 2);
				}
				uint num = (uint)value;
				uint num2 = (uint)(value >> 32);
				_bits[0] = num;
				_bits[1] = num2;
				_length = ((num2 != 0) ? 2 : ((num != 0) ? 1 : 0));
			}

			public void Overwrite(uint value)
			{
				if (_length > 1)
				{
					Array.Clear(_bits, 1, _length - 1);
				}
				_bits[0] = value;
				_length = ((value != 0) ? 1 : 0);
			}

			public uint[] GetBits()
			{
				return _bits;
			}

			public int GetLength()
			{
				return _length;
			}

			public void Refresh(int maxLength)
			{
				if (_length > maxLength)
				{
					Array.Clear(_bits, maxLength, _length - maxLength);
				}
				_length = ActualLength(_bits, maxLength);
			}
		}

		private static int ReducerThreshold = 32;

		private static int SquareThreshold = 32;

		private static int AllocationThreshold = 256;

		private static int MultiplyThreshold = 32;

		public static uint[] Add(uint[] left, uint right)
		{
			uint[] array = new uint[left.Length + 1];
			long num = (long)left[0] + (long)right;
			array[0] = (uint)num;
			long num2 = num >> 32;
			for (int i = 1; i < left.Length; i++)
			{
				num = left[i] + num2;
				array[i] = (uint)num;
				num2 = num >> 32;
			}
			array[left.Length] = (uint)num2;
			return array;
		}

		public unsafe static uint[] Add(uint[] left, uint[] right)
		{
			uint[] array = new uint[left.Length + 1];
			fixed (uint* left2 = left)
			{
				fixed (uint* right2 = right)
				{
					fixed (uint* bits = &array[0])
					{
						Add(left2, left.Length, right2, right.Length, bits, array.Length);
					}
				}
			}
			return array;
		}

		private unsafe static void Add(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength)
		{
			int i = 0;
			long num = 0L;
			for (; i < rightLength; i++)
			{
				long num2 = left[i] + num + right[i];
				bits[i] = (uint)num2;
				num = num2 >> 32;
			}
			for (; i < leftLength; i++)
			{
				long num3 = left[i] + num;
				bits[i] = (uint)num3;
				num = num3 >> 32;
			}
			bits[i] = (uint)num;
		}

		private unsafe static void AddSelf(uint* left, int leftLength, uint* right, int rightLength)
		{
			int i = 0;
			long num = 0L;
			for (; i < rightLength; i++)
			{
				long num2 = left[i] + num + right[i];
				left[i] = (uint)num2;
				num = num2 >> 32;
			}
			while (num != 0L && i < leftLength)
			{
				long num3 = left[i] + num;
				left[i] = (uint)num3;
				num = num3 >> 32;
				i++;
			}
		}

		public static uint[] Subtract(uint[] left, uint right)
		{
			uint[] array = new uint[left.Length];
			long num = (long)left[0] - (long)right;
			array[0] = (uint)num;
			long num2 = num >> 32;
			for (int i = 1; i < left.Length; i++)
			{
				num = left[i] + num2;
				array[i] = (uint)num;
				num2 = num >> 32;
			}
			return array;
		}

		public unsafe static uint[] Subtract(uint[] left, uint[] right)
		{
			uint[] array = new uint[left.Length];
			fixed (uint* left2 = left)
			{
				fixed (uint* right2 = right)
				{
					fixed (uint* bits = array)
					{
						Subtract(left2, left.Length, right2, right.Length, bits, array.Length);
					}
				}
			}
			return array;
		}

		private unsafe static void Subtract(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength)
		{
			int i = 0;
			long num = 0L;
			for (; i < rightLength; i++)
			{
				long num2 = left[i] + num - right[i];
				bits[i] = (uint)num2;
				num = num2 >> 32;
			}
			for (; i < leftLength; i++)
			{
				long num3 = left[i] + num;
				bits[i] = (uint)num3;
				num = num3 >> 32;
			}
		}

		public static int Compare(uint[] left, uint[] right)
		{
			if (left.Length < right.Length)
			{
				return -1;
			}
			if (left.Length > right.Length)
			{
				return 1;
			}
			for (int num = left.Length - 1; num >= 0; num--)
			{
				if (left[num] < right[num])
				{
					return -1;
				}
				if (left[num] > right[num])
				{
					return 1;
				}
			}
			return 0;
		}

		public static uint[] Divide(uint[] left, uint right, out uint remainder)
		{
			uint[] array = new uint[left.Length];
			ulong num = 0uL;
			for (int num2 = left.Length - 1; num2 >= 0; num2--)
			{
				ulong num3 = (num << 32) | left[num2];
				ulong num4 = num3 / right;
				array[num2] = (uint)num4;
				num = num3 - num4 * right;
			}
			remainder = (uint)num;
			return array;
		}

		public static uint[] Divide(uint[] left, uint right)
		{
			uint[] array = new uint[left.Length];
			ulong num = 0uL;
			for (int num2 = left.Length - 1; num2 >= 0; num2--)
			{
				ulong num3 = (num << 32) | left[num2];
				ulong num4 = num3 / right;
				array[num2] = (uint)num4;
				num = num3 - num4 * right;
			}
			return array;
		}

		public static uint Remainder(uint[] left, uint right)
		{
			ulong num = 0uL;
			for (int num2 = left.Length - 1; num2 >= 0; num2--)
			{
				num = ((num << 32) | left[num2]) % right;
			}
			return (uint)num;
		}

		public unsafe static uint[] Divide(uint[] left, uint[] right, out uint[] remainder)
		{
			uint[] array = CreateCopy(left);
			uint[] array2 = new uint[left.Length - right.Length + 1];
			fixed (uint* left2 = &array[0])
			{
				fixed (uint* right2 = &right[0])
				{
					fixed (uint* bits = &array2[0])
					{
						Divide(left2, array.Length, right2, right.Length, bits, array2.Length);
					}
				}
			}
			remainder = array;
			return array2;
		}

		public unsafe static uint[] Divide(uint[] left, uint[] right)
		{
			uint[] array = CreateCopy(left);
			uint[] array2 = new uint[left.Length - right.Length + 1];
			fixed (uint* left2 = &array[0])
			{
				fixed (uint* right2 = &right[0])
				{
					fixed (uint* bits = &array2[0])
					{
						Divide(left2, array.Length, right2, right.Length, bits, array2.Length);
					}
				}
			}
			return array2;
		}

		public unsafe static uint[] Remainder(uint[] left, uint[] right)
		{
			uint[] array = CreateCopy(left);
			fixed (uint* left2 = &array[0])
			{
				fixed (uint* right2 = &right[0])
				{
					Divide(left2, array.Length, right2, right.Length, null, 0);
				}
			}
			return array;
		}

		private unsafe static void Divide(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength)
		{
			uint num = right[rightLength - 1];
			uint num2 = ((rightLength > 1) ? right[rightLength - 2] : 0u);
			int num3 = LeadingZeros(num);
			int num4 = 32 - num3;
			if (num3 > 0)
			{
				uint num5 = ((rightLength > 2) ? right[rightLength - 3] : 0u);
				num = (num << num3) | (num2 >> num4);
				num2 = (num2 << num3) | (num5 >> num4);
			}
			for (int num6 = leftLength; num6 >= rightLength; num6--)
			{
				int num7 = num6 - rightLength;
				uint num8 = ((num6 < leftLength) ? left[num6] : 0u);
				ulong num9 = ((ulong)num8 << 32) | left[num6 - 1];
				uint num10 = ((num6 > 1) ? left[num6 - 2] : 0u);
				if (num3 > 0)
				{
					uint num11 = ((num6 > 2) ? left[num6 - 3] : 0u);
					num9 = (num9 << num3) | (num10 >> num4);
					num10 = (num10 << num3) | (num11 >> num4);
				}
				ulong num12 = num9 / num;
				if (num12 > 4294967295u)
				{
					num12 = 4294967295uL;
				}
				while (DivideGuessTooBig(num12, num9, num10, num, num2))
				{
					num12--;
				}
				if (num12 != 0 && SubtractDivisor(left + num7, leftLength - num7, right, rightLength, num12) != num8)
				{
					AddDivisor(left + num7, leftLength - num7, right, rightLength);
					num12--;
				}
				if (bitsLength != 0)
				{
					bits[num7] = (uint)num12;
				}
				if (num6 < leftLength)
				{
					left[num6] = 0u;
				}
			}
		}

		private unsafe static uint AddDivisor(uint* left, int leftLength, uint* right, int rightLength)
		{
			ulong num = 0uL;
			for (int i = 0; i < rightLength; i++)
			{
				ulong num2 = left[i] + num + right[i];
				left[i] = (uint)num2;
				num = num2 >> 32;
			}
			return (uint)num;
		}

		private unsafe static uint SubtractDivisor(uint* left, int leftLength, uint* right, int rightLength, ulong q)
		{
			ulong num = 0uL;
			for (int i = 0; i < rightLength; i++)
			{
				num += right[i] * q;
				uint num2 = (uint)num;
				num >>= 32;
				if (left[i] < num2)
				{
					num++;
				}
				left[i] -= num2;
			}
			return (uint)num;
		}

		private static bool DivideGuessTooBig(ulong q, ulong valHi, uint valLo, uint divHi, uint divLo)
		{
			ulong num = divHi * q;
			ulong num2 = divLo * q;
			num += num2 >> 32;
			num2 &= 0xFFFFFFFFu;
			if (num < valHi)
			{
				return false;
			}
			if (num > valHi)
			{
				return true;
			}
			if (num2 < valLo)
			{
				return false;
			}
			if (num2 > valLo)
			{
				return true;
			}
			return false;
		}

		private static uint[] CreateCopy(uint[] value)
		{
			uint[] array = new uint[value.Length];
			Array.Copy(value, 0, array, 0, array.Length);
			return array;
		}

		private static int LeadingZeros(uint value)
		{
			if (value == 0)
			{
				return 32;
			}
			int num = 0;
			if ((value & 0xFFFF0000u) == 0)
			{
				num += 16;
				value <<= 16;
			}
			if ((value & 0xFF000000u) == 0)
			{
				num += 8;
				value <<= 8;
			}
			if ((value & 0xF0000000u) == 0)
			{
				num += 4;
				value <<= 4;
			}
			if ((value & 0xC0000000u) == 0)
			{
				num += 2;
				value <<= 2;
			}
			if ((value & 0x80000000u) == 0)
			{
				num++;
			}
			return num;
		}

		public static uint Gcd(uint left, uint right)
		{
			while (right != 0)
			{
				uint num = left % right;
				left = right;
				right = num;
			}
			return left;
		}

		public static ulong Gcd(ulong left, ulong right)
		{
			while (right > 4294967295u)
			{
				ulong num = left % right;
				left = right;
				right = num;
			}
			if (right != 0L)
			{
				return Gcd((uint)right, (uint)(left % right));
			}
			return left;
		}

		public static uint Gcd(uint[] left, uint right)
		{
			uint right2 = Remainder(left, right);
			return Gcd(right, right2);
		}

		public static uint[] Gcd(uint[] left, uint[] right)
		{
			BitsBuffer left2 = new BitsBuffer(left.Length, left);
			BitsBuffer right2 = new BitsBuffer(right.Length, right);
			Gcd(ref left2, ref right2);
			return left2.GetBits();
		}

		private static void Gcd(ref BitsBuffer left, ref BitsBuffer right)
		{
			while (right.GetLength() > 2)
			{
				ExtractDigits(ref left, ref right, out var x, out var y);
				uint num = 1u;
				uint num2 = 0u;
				uint num3 = 0u;
				uint num4 = 1u;
				int num5 = 0;
				while (y != 0L)
				{
					ulong num6 = x / y;
					if (num6 > 4294967295u)
					{
						break;
					}
					ulong num7 = num + num6 * num3;
					ulong num8 = num2 + num6 * num4;
					ulong num9 = x - num6 * y;
					if (num7 > 2147483647 || num8 > 2147483647 || num9 < num8 || num9 + num7 > y - num3)
					{
						break;
					}
					num = (uint)num7;
					num2 = (uint)num8;
					x = num9;
					num5++;
					if (x == num2)
					{
						break;
					}
					num6 = y / x;
					if (num6 > 4294967295u)
					{
						break;
					}
					num7 = num4 + num6 * num2;
					num8 = num3 + num6 * num;
					num9 = y - num6 * x;
					if (num7 > 2147483647 || num8 > 2147483647 || num9 < num8 || num9 + num7 > x - num2)
					{
						break;
					}
					num4 = (uint)num7;
					num3 = (uint)num8;
					y = num9;
					num5++;
					if (y == num3)
					{
						break;
					}
				}
				if (num2 == 0)
				{
					left.Reduce(ref right);
					BitsBuffer bitsBuffer = left;
					left = right;
					right = bitsBuffer;
					continue;
				}
				LehmerCore(ref left, ref right, num, num2, num3, num4);
				if (num5 % 2 == 1)
				{
					BitsBuffer bitsBuffer2 = left;
					left = right;
					right = bitsBuffer2;
				}
			}
			if (right.GetLength() > 0)
			{
				left.Reduce(ref right);
				uint[] bits = right.GetBits();
				uint[] bits2 = left.GetBits();
				ulong left2 = ((ulong)bits[1] << 32) | bits[0];
				ulong right2 = ((ulong)bits2[1] << 32) | bits2[0];
				left.Overwrite(Gcd(left2, right2));
				right.Overwrite(0u);
			}
		}

		private static void ExtractDigits(ref BitsBuffer xBuffer, ref BitsBuffer yBuffer, out ulong x, out ulong y)
		{
			uint[] bits = xBuffer.GetBits();
			int length = xBuffer.GetLength();
			uint[] bits2 = yBuffer.GetBits();
			int length2 = yBuffer.GetLength();
			ulong num = bits[length - 1];
			ulong num2 = bits[length - 2];
			ulong num3 = bits[length - 3];
			ulong num4;
			ulong num5;
			ulong num6;
			switch (length - length2)
			{
			case 0:
				num4 = bits2[length2 - 1];
				num5 = bits2[length2 - 2];
				num6 = bits2[length2 - 3];
				break;
			case 1:
				num4 = 0uL;
				num5 = bits2[length2 - 1];
				num6 = bits2[length2 - 2];
				break;
			case 2:
				num4 = 0uL;
				num5 = 0uL;
				num6 = bits2[length2 - 1];
				break;
			default:
				num4 = 0uL;
				num5 = 0uL;
				num6 = 0uL;
				break;
			}
			int num7 = LeadingZeros((uint)num);
			x = ((num << 32 + num7) | (num2 << num7) | (num3 >> 32 - num7)) >> 1;
			y = ((num4 << 32 + num7) | (num5 << num7) | (num6 >> 32 - num7)) >> 1;
		}

		private static void LehmerCore(ref BitsBuffer xBuffer, ref BitsBuffer yBuffer, long a, long b, long c, long d)
		{
			uint[] bits = xBuffer.GetBits();
			uint[] bits2 = yBuffer.GetBits();
			int length = yBuffer.GetLength();
			long num = 0L;
			long num2 = 0L;
			for (int i = 0; i < length; i++)
			{
				long num3 = a * bits[i] - b * bits2[i] + num;
				long num4 = d * bits2[i] - c * bits[i] + num2;
				num = num3 >> 32;
				num2 = num4 >> 32;
				bits[i] = (uint)num3;
				bits2[i] = (uint)num4;
			}
			xBuffer.Refresh(length);
			yBuffer.Refresh(length);
		}

		private static int ActualLength(uint[] value)
		{
			return ActualLength(value, value.Length);
		}

		private static int ActualLength(uint[] value, int length)
		{
			while (length > 0 && value[length - 1] == 0)
			{
				length--;
			}
			return length;
		}

		public unsafe static uint[] Square(uint[] value)
		{
			uint[] array = new uint[value.Length + value.Length];
			fixed (uint* value2 = value)
			{
				fixed (uint* bits = array)
				{
					Square(value2, value.Length, bits, array.Length);
				}
			}
			return array;
		}

		private unsafe static void Square(uint* value, int valueLength, uint* bits, int bitsLength)
		{
			if (valueLength < SquareThreshold)
			{
				for (int i = 0; i < valueLength; i++)
				{
					ulong num = 0uL;
					for (int j = 0; j < i; j++)
					{
						ulong num2 = bits[i + j] + num;
						ulong num3 = (ulong)value[j] * (ulong)value[i];
						bits[i + j] = (uint)(num2 + (num3 << 1));
						num = num3 + (num2 >> 1) >> 31;
					}
					ulong num4 = (ulong)((long)value[i] * (long)value[i]) + num;
					bits[i + i] = (uint)num4;
					bits[i + i + 1] = (uint)(num4 >> 32);
				}
				return;
			}
			int num5 = valueLength >> 1;
			int num6 = num5 << 1;
			int num7 = num5;
			uint* ptr = value + num5;
			int num8 = valueLength - num5;
			int num9 = num6;
			uint* ptr2 = bits + num6;
			int num10 = bitsLength - num6;
			Square(value, num7, bits, num9);
			Square(ptr, num8, ptr2, num10);
			int num11 = num8 + 1;
			int num12 = num11 + num11;
			if (num12 < AllocationThreshold)
			{
				uint* ptr3 = stackalloc uint[num11];
				uint* ptr4 = stackalloc uint[num12];
				Add(ptr, num8, value, num7, ptr3, num11);
				Square(ptr3, num11, ptr4, num12);
				SubtractCore(ptr2, num10, bits, num9, ptr4, num12);
				AddSelf(bits + num5, bitsLength - num5, ptr4, num12);
				return;
			}
			fixed (uint* ptr5 = new uint[num11])
			{
				fixed (uint* ptr6 = new uint[num12])
				{
					Add(ptr, num8, value, num7, ptr5, num11);
					Square(ptr5, num11, ptr6, num12);
					SubtractCore(ptr2, num10, bits, num9, ptr6, num12);
					AddSelf(bits + num5, bitsLength - num5, ptr6, num12);
				}
			}
		}

		public static uint[] Multiply(uint[] left, uint right)
		{
			int i = 0;
			ulong num = 0uL;
			uint[] array = new uint[left.Length + 1];
			for (; i < left.Length; i++)
			{
				ulong num2 = (ulong)((long)left[i] * (long)right) + num;
				array[i] = (uint)num2;
				num = num2 >> 32;
			}
			array[i] = (uint)num;
			return array;
		}

		public unsafe static uint[] Multiply(uint[] left, uint[] right)
		{
			uint[] array = new uint[left.Length + right.Length];
			fixed (uint* left2 = left)
			{
				fixed (uint* right2 = right)
				{
					fixed (uint* bits = array)
					{
						Multiply(left2, left.Length, right2, right.Length, bits, array.Length);
					}
				}
			}
			return array;
		}

		private unsafe static void Multiply(uint* left, int leftLength, uint* right, int rightLength, uint* bits, int bitsLength)
		{
			if (rightLength < MultiplyThreshold)
			{
				for (int i = 0; i < rightLength; i++)
				{
					ulong num = 0uL;
					for (int j = 0; j < leftLength; j++)
					{
						ulong num2 = bits[i + j] + num + (ulong)((long)left[j] * (long)right[i]);
						bits[i + j] = (uint)num2;
						num = num2 >> 32;
					}
					bits[i + leftLength] = (uint)num;
				}
				return;
			}
			int num3 = rightLength >> 1;
			int num4 = num3 << 1;
			int num5 = num3;
			uint* left2 = left + num3;
			int num6 = leftLength - num3;
			int rightLength2 = num3;
			uint* ptr = right + num3;
			int num7 = rightLength - num3;
			int num8 = num4;
			uint* ptr2 = bits + num4;
			int num9 = bitsLength - num4;
			Multiply(left, num5, right, rightLength2, bits, num8);
			Multiply(left2, num6, ptr, num7, ptr2, num9);
			int num10 = num6 + 1;
			int num11 = num7 + 1;
			int num12 = num10 + num11;
			if (num12 < AllocationThreshold)
			{
				uint* ptr3 = stackalloc uint[num10];
				uint* ptr4 = stackalloc uint[num11];
				uint* ptr5 = stackalloc uint[num12];
				Add(left2, num6, left, num5, ptr3, num10);
				Add(ptr, num7, right, rightLength2, ptr4, num11);
				Multiply(ptr3, num10, ptr4, num11, ptr5, num12);
				SubtractCore(ptr2, num9, bits, num8, ptr5, num12);
				AddSelf(bits + num3, bitsLength - num3, ptr5, num12);
				return;
			}
			fixed (uint* ptr6 = new uint[num10])
			{
				fixed (uint* ptr7 = new uint[num11])
				{
					fixed (uint* ptr8 = new uint[num12])
					{
						Add(left2, num6, left, num5, ptr6, num10);
						Add(ptr, num7, right, rightLength2, ptr7, num11);
						Multiply(ptr6, num10, ptr7, num11, ptr8, num12);
						SubtractCore(ptr2, num9, bits, num8, ptr8, num12);
						AddSelf(bits + num3, bitsLength - num3, ptr8, num12);
					}
				}
			}
		}

		private unsafe static void SubtractCore(uint* left, int leftLength, uint* right, int rightLength, uint* core, int coreLength)
		{
			int i = 0;
			long num = 0L;
			for (; i < rightLength; i++)
			{
				long num2 = core[i] + num - left[i] - right[i];
				core[i] = (uint)num2;
				num = num2 >> 32;
			}
			for (; i < leftLength; i++)
			{
				long num3 = core[i] + num - left[i];
				core[i] = (uint)num3;
				num = num3 >> 32;
			}
			while (num != 0L && i < coreLength)
			{
				long num4 = core[i] + num;
				core[i] = (uint)num4;
				num = num4 >> 32;
				i++;
			}
		}
	}
	internal static class BigNumber
	{
		private struct BigNumberBuffer
		{
			public StringBuilder digits;

			public int precision;

			public int scale;

			public bool sign;

			public static BigNumberBuffer Create()
			{
				return new BigNumberBuffer
				{
					digits = new StringBuilder()
				};
			}
		}

		internal static bool TryValidateParseStyleInteger(NumberStyles style, out ArgumentException e)
		{
			if ((style & ~(NumberStyles.Any | NumberStyles.AllowHexSpecifier)) != NumberStyles.None)
			{
				e = new ArgumentException(global::SR.Format("An undefined NumberStyles value is being used.", "style"));
				return false;
			}
			if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None && (style & ~NumberStyles.HexNumber) != NumberStyles.None)
			{
				e = new ArgumentException("With the AllowHexSpecifier bit set in the enum bit field, the only other valid bits that can be combined into the enum value must be a subset of those in HexNumber.");
				return false;
			}
			e = null;
			return true;
		}

		internal static bool TryParseBigInteger(ReadOnlySpan<char> value, NumberStyles style, NumberFormatInfo info, out BigInteger result)
		{
			result = BigInteger.Zero;
			if (!TryValidateParseStyleInteger(style, out var e))
			{
				throw e;
			}
			BigNumberBuffer number = BigNumberBuffer.Create();
			if (!FormatProvider.TryStringToBigInteger(value, style, info, number.digits, out number.precision, out number.scale, out number.sign))
			{
				return false;
			}
			if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
			{
				if (!HexNumberToBigInteger(ref number, ref result))
				{
					return false;
				}
			}
			else if (!NumberToBigInteger(ref number, ref result))
			{
				return false;
			}
			return true;
		}

		internal static BigInteger ParseBigInteger(string value, NumberStyles style, NumberFormatInfo info)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return ParseBigInteger(value.AsSpan(), style, info);
		}

		internal static BigInteger ParseBigInteger(ReadOnlySpan<char> value, NumberStyles style, NumberFormatInfo info)
		{
			if (!TryValidateParseStyleInteger(style, out var e))
			{
				throw e;
			}
			BigInteger result = BigInteger.Zero;
			if (!TryParseBigInteger(value, style, info, out result))
			{
				throw new FormatException("The value could not be parsed.");
			}
			return result;
		}

		private static bool HexNumberToBigInteger(ref BigNumberBuffer number, ref BigInteger value)
		{
			if (number.digits == null || number.digits.Length == 0)
			{
				return false;
			}
			int num = number.digits.Length - 1;
			byte[] array = new byte[num / 2 + num % 2];
			bool flag = false;
			bool flag2 = false;
			int num2 = 0;
			for (int num3 = num - 1; num3 > -1; num3--)
			{
				char c = number.digits[num3];
				byte b = ((c >= '0' && c <= '9') ? ((byte)(c - 48)) : ((c < 'A' || c > 'F') ? ((byte)(c - 97 + 10)) : ((byte)(c - 65 + 10))));
				if (num3 == 0 && (b & 8) == 8)
				{
					flag2 = true;
				}
				if (flag)
				{
					array[num2] = (byte)(array[num2] | (b << 4));
					num2++;
				}
				else
				{
					array[num2] = (flag2 ? ((byte)(b | 0xF0)) : b);
				}
				flag = !flag;
			}
			value = new BigInteger(array);
			return true;
		}

		private static bool NumberToBigInteger(ref BigNumberBuffer number, ref BigInteger value)
		{
			int num = number.scale;
			int index = 0;
			BigInteger bigInteger = 10;
			value = 0;
			while (--num >= 0)
			{
				value *= bigInteger;
				if (number.digits[index] != 0)
				{
					value += (BigInteger)(number.digits[index++] - 48);
				}
			}
			while (number.digits[index] != 0)
			{
				if (number.digits[index++] != '0')
				{
					return false;
				}
			}
			if (number.sign)
			{
				value = -value;
			}
			return true;
		}

		internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits)
		{
			digits = -1;
			if (format.Length == 0)
			{
				return 'R';
			}
			int num = 0;
			char c = format[num];
			if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
			{
				num++;
				int num2 = -1;
				if (num < format.Length && format[num] >= '0' && format[num] <= '9')
				{
					num2 = format[num++] - 48;
					while (num < format.Length && format[num] >= '0' && format[num] <= '9')
					{
						num2 = num2 * 10 + (format[num++] - 48);
						if (num2 >= 10)
						{
							break;
						}
					}
				}
				if (num >= format.Length || format[num] == '\0')
				{
					digits = num2;
					return c;
				}
			}
			return '\0';
		}

		private static string FormatBigIntegerToHex(bool targetSpan, BigInteger value, char format, int digits, NumberFormatInfo info, Span<char> destination, out int charsWritten, out bool spanSuccess)
		{
			byte[] array = null;
			Span<byte> destination2 = stackalloc byte[64];
			if (!value.TryWriteOrCountBytes(destination2, out var bytesWritten))
			{
				destination2 = (array = ArrayPool<byte>.Shared.Rent(bytesWritten));
				value.TryWriteBytes(destination2, out bytesWritten);
			}
			destination2 = destination2.Slice(0, bytesWritten);
			Span<char> initialBuffer = stackalloc char[128];
			System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(initialBuffer);
			int num = destination2.Length - 1;
			if (num > -1)
			{
				bool flag = false;
				byte b = destination2[num];
				if (b > 247)
				{
					b -= 240;
					flag = true;
				}
				if (b < 8 || flag)
				{
					valueStringBuilder.Append((b < 10) ? ((char)(b + 48)) : ((format == 'X') ? ((char)((b & 0xF) - 10 + 65)) : ((char)((b & 0xF) - 10 + 97))));
					num--;
				}
			}
			if (num > -1)
			{
				Span<char> span = valueStringBuilder.AppendSpan((num + 1) * 2);
				int num2 = 0;
				string text = ((format == 'x') ? "0123456789abcdef" : "0123456789ABCDEF");
				while (num > -1)
				{
					byte b2 = destination2[num--];
					span[num2++] = text[b2 >> 4];
					span[num2++] = text[b2 & 0xF];
				}
			}
			if (digits > valueStringBuilder.Length)
			{
				valueStringBuilder.Insert(0, (value._sign >= 0) ? '0' : ((format == 'x') ? 'f' : 'F'), digits - valueStringBuilder.Length);
			}
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
			if (targetSpan)
			{
				spanSuccess = valueStringBuilder.TryCopyTo(destination, out charsWritten);
				return null;
			}
			charsWritten = 0;
			spanSuccess = false;
			return valueStringBuilder.ToString();
		}

		internal static string FormatBigInteger(BigInteger value, string format, NumberFormatInfo info)
		{
			int charsWritten;
			bool spanSuccess;
			return FormatBigInteger(targetSpan: false, value, format, format, info, default(Span<char>), out charsWritten, out spanSuccess);
		}

		private static string FormatBigInteger(bool targetSpan, BigInteger value, string formatString, ReadOnlySpan<char> formatSpan, NumberFormatInfo info, Span<char> destination, out int charsWritten, out bool spanSuccess)
		{
			int digits = 0;
			char c = ParseFormatSpecifier(formatSpan, out digits);
			if (c == 'x' || c == 'X')
			{
				return FormatBigIntegerToHex(targetSpan, value, c, digits, info, destination, out charsWritten, out spanSuccess);
			}
			if (value._bits == null)
			{
				if (c == 'g' || c == 'G' || c == 'r' || c == 'R')
				{
					formatSpan = (formatString = ((digits > 0) ? $"D{digits}" : "D"));
				}
				if (targetSpan)
				{
					spanSuccess = value._sign.TryFormat(destination, out charsWritten, formatSpan, info);
					return null;
				}
				charsWritten = 0;
				spanSuccess = false;
				return value._sign.ToString(formatString, info);
			}
			int num = value._bits.Length;
			uint[] array;
			int num3;
			int num4;
			checked
			{
				int num2;
				try
				{
					num2 = unchecked(checked(num * 10) / 9) + 2;
				}
				catch (OverflowException innerException)
				{
					throw new FormatException("The value is too large to be represented by this format specifier.", innerException);
				}
				array = new uint[num2];
				num3 = 0;
				num4 = num;
			}
			while (--num4 >= 0)
			{
				uint num5 = value._bits[num4];
				for (int i = 0; i < num3; i++)
				{
					ulong num6 = NumericsHelpers.MakeUlong(array[i], num5);
					array[i] = (uint)(num6 % 1000000000);
					num5 = (uint)(num6 / 1000000000);
				}
				if (num5 != 0)
				{
					array[num3++] = num5 % 1000000000;
					num5 /= 1000000000;
					if (num5 != 0)
					{
						array[num3++] = num5;
					}
				}
			}
			int num7;
			bool flag;
			char[] array2;
			int num9;
			checked
			{
				try
				{
					num7 = num3 * 9;
				}
				catch (OverflowException innerException2)
				{
					throw new FormatException("The value is too large to be represented by this format specifier.", innerException2);
				}
				flag = c == 'g' || c == 'G' || c == 'd' || c == 'D' || c == 'r' || c == 'R';
				if (flag)
				{
					if (digits > 0 && digits > num7)
					{
						num7 = digits;
					}
					if (value._sign < 0)
					{
						try
						{
							num7 += info.NegativeSign.Length;
						}
						catch (OverflowException innerException3)
						{
							throw new FormatException("The value is too large to be represented by this format specifier.", innerException3);
						}
					}
				}
				int num8;
				try
				{
					num8 = num7 + 1;
				}
				catch (OverflowException innerException4)
				{
					throw new FormatException("The value is too large to be represented by this format specifier.", innerException4);
				}
				array2 = new char[num8];
				num9 = num7;
			}
			for (int j = 0; j < num3 - 1; j++)
			{
				uint num10 = array[j];
				int num11 = 9;
				while (--num11 >= 0)
				{
					array2[--num9] = (char)(48 + num10 % 10);
					num10 /= 10;
				}
			}
			for (uint num12 = array[num3 - 1]; num12 != 0; num12 /= 10)
			{
				array2[--num9] = (char)(48 + num12 % 10);
			}
			if (!flag)
			{
				bool sign = value._sign < 0;
				int precision = 29;
				int scale = num7 - num9;
				Span<char> initialBuffer = stackalloc char[128];
				System.Text.ValueStringBuilder sb = new System.Text.ValueStringBuilder(initialBuffer);
				FormatProvider.FormatBigInteger(ref sb, precision, scale, sign, formatSpan, info, array2, num9);
				if (targetSpan)
				{
					spanSuccess = sb.TryCopyTo(destination, out charsWritten);
					return null;
				}
				charsWritten = 0;
				spanSuccess = false;
				return sb.ToString();
			}
			int num13 = num7 - num9;
			while (digits > 0 && digits > num13)
			{
				array2[--num9] = '0';
				digits--;
			}
			if (value._sign < 0)
			{
				_ = info.NegativeSign;
				for (int num14 = info.NegativeSign.Length - 1; num14 > -1; num14--)
				{
					array2[--num9] = info.NegativeSign[num14];
				}
			}
			int num15 = num7 - num9;
			if (!targetSpan)
			{
				charsWritten = 0;
				spanSuccess = false;
				return new string(array2, num9, num7 - num9);
			}
			if (new ReadOnlySpan<char>(array2, num9, num7 - num9).TryCopyTo(destination))
			{
				charsWritten = num15;
				spanSuccess = true;
				return null;
			}
			charsWritten = 0;
			spanSuccess = false;
			return null;
		}
	}
	[Serializable]
	public struct Complex(double real, double imaginary) : IEquatable<Complex>, IFormattable
	{
		public static readonly Complex Zero = new Complex(0.0, 0.0);

		public static readonly Complex One = new Complex(1.0, 0.0);

		public static readonly Complex ImaginaryOne = new Complex(0.0, 1.0);

		private static readonly double s_sqrtRescaleThreshold = 1.7976931348623157E+308 / (Math.Sqrt(2.0) + 1.0);

		private static readonly double s_asinOverflowThreshold = Math.Sqrt(1.7976931348623157E+308) / 2.0;

		private static readonly double s_log2 = Math.Log(2.0);

		private double m_real = real;

		private double m_imaginary = imaginary;

		public double Real => m_real;

		public double Imaginary => m_imaginary;

		public double Magnitude => Abs(this);

		public double Phase => Math.Atan2(m_imaginary, m_real);

		public static Complex FromPolarCoordinates(double magnitude, double phase)
		{
			return new Complex(magnitude * Math.Cos(phase), magnitude * Math.Sin(phase));
		}

		public static Complex Negate(Complex value)
		{
			return -value;
		}

		public static Complex Add(Complex left, Complex right)
		{
			return left + right;
		}

		public static Complex Subtract(Complex left, Complex right)
		{
			return left - right;
		}

		public static Complex Multiply(Complex left, Complex right)
		{
			return left * right;
		}

		public static Complex Divide(Complex dividend, Complex divisor)
		{
			return dividend / divisor;
		}

		public static Complex operator -(Complex value)
		{
			return new Complex(0.0 - value.m_real, 0.0 - value.m_imaginary);
		}

		public static Complex operator +(Complex left, Complex right)
		{
			return new Complex(left.m_real + right.m_real, left.m_imaginary + right.m_imaginary);
		}

		public static Complex operator -(Complex left, Complex right)
		{
			return new Complex(left.m_real - right.m_real, left.m_imaginary - right.m_imaginary);
		}

		public static Complex operator *(Complex left, Complex right)
		{
			double real = left.m_real * right.m_real - left.m_imaginary * right.m_imaginary;
			double imaginary = left.m_imaginary * right.m_real + left.m_real * right.m_imaginary;
			return new Complex(real, imaginary);
		}

		public static Complex operator /(Complex left, Complex right)
		{
			double real = left.m_real;
			double imaginary = left.m_imaginary;
			double real2 = right.m_real;
			double imaginary2 = right.m_imaginary;
			if (Math.Abs(imaginary2) < Math.Abs(real2))
			{
				double num = imaginary2 / real2;
				return new Complex((real + imaginary * num) / (real2 + imaginary2 * num), (imaginary - real * num) / (real2 + imaginary2 * num));
			}
			double num2 = real2 / imaginary2;
			return new Complex((imaginary + real * num2) / (imaginary2 + real2 * num2), (0.0 - real + imaginary * num2) / (imaginary2 + real2 * num2));
		}

		public static double Abs(Complex value)
		{
			return Hypot(value.m_real, value.m_imaginary);
		}

		private static double Hypot(double a, double b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);
			double num;
			double num2;
			if (a < b)
			{
				num = a;
				num2 = b;
			}
			else
			{
				num = b;
				num2 = a;
			}
			if (num == 0.0)
			{
				return num2;
			}
			if (double.IsPositiveInfinity(num2) && !double.IsNaN(num))
			{
				return 1.0 / 0.0;
			}
			double num3 = num / num2;
			return num2 * Math.Sqrt(1.0 + num3 * num3);
		}

		private static double Log1P(double x)
		{
			double num = 1.0 + x;
			if (num == 1.0)
			{
				return x;
			}
			if (x < 0.75)
			{
				return x * Math.Log(num) / (num - 1.0);
			}
			return Math.Log(num);
		}

		public static Complex Conjugate(Complex value)
		{
			return new Complex(value.m_real, 0.0 - value.m_imaginary);
		}

		public static Complex Reciprocal(Complex value)
		{
			if (value.m_real == 0.0 && value.m_imaginary == 0.0)
			{
				return Zero;
			}
			return One / value;
		}

		public static bool operator ==(Complex left, Complex right)
		{
			if (left.m_real == right.m_real)
			{
				return left.m_imaginary == right.m_imaginary;
			}
			return false;
		}

		public static bool operator !=(Complex left, Complex right)
		{
			if (left.m_real == right.m_real)
			{
				return left.m_imaginary != right.m_imaginary;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Complex))
			{
				return false;
			}
			return Equals((Complex)obj);
		}

		public bool Equals(Complex value)
		{
			if (m_real.Equals(value.m_real))
			{
				return m_imaginary.Equals(value.m_imaginary);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 99999997;
			int num2 = m_real.GetHashCode() % num;
			int hashCode = m_imaginary.GetHashCode();
			return num2 ^ hashCode;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0}, {1})", m_real, m_imaginary);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return string.Format(provider, "({0}, {1})", m_real.ToString(format, provider), m_imaginary.ToString(format, provider));
		}

		public static Complex Sin(Complex value)
		{
			double num = Math.Exp(value.m_imaginary);
			double num2 = 1.0 / num;
			double num3 = (num - num2) * 0.5;
			double num4 = (num + num2) * 0.5;
			return new Complex(Math.Sin(value.m_real) * num4, Math.Cos(value.m_real) * num3);
		}

		public static Complex Sinh(Complex value)
		{
			Complex complex = Sin(new Complex(0.0 - value.m_imaginary, value.m_real));
			return new Complex(complex.m_imaginary, 0.0 - complex.m_real);
		}

		public static Complex Asin(Complex value)
		{
			Asin_Internal(Math.Abs(value.Real), Math.Abs(value.Imaginary), out var b, out var bPrime, out var v);
			double num = ((!(bPrime < 0.0)) ? Math.Atan(bPrime) : Math.Asin(b));
			if (value.Real < 0.0)
			{
				num = 0.0 - num;
			}
			if (value.Imaginary < 0.0)
			{
				v = 0.0 - v;
			}
			return new Complex(num, v);
		}

		public static Complex Cos(Complex value)
		{
			double num = Math.Exp(value.m_imaginary);
			double num2 = 1.0 / num;
			double num3 = (num - num2) * 0.5;
			double num4 = (num + num2) * 0.5;
			return new Complex(Math.Cos(value.m_real) * num4, (0.0 - Math.Sin(value.m_real)) * num3);
		}

		public static Complex Cosh(Complex value)
		{
			return Cos(new Complex(0.0 - value.m_imaginary, value.m_real));
		}

		public static Complex Acos(Complex value)
		{
			Asin_Internal(Math.Abs(value.Real), Math.Abs(value.Imaginary), out var b, out var bPrime, out var v);
			double num = ((!(bPrime < 0.0)) ? Math.Atan(1.0 / bPrime) : Math.Acos(b));
			if (value.Real < 0.0)
			{
				num = Math.PI - num;
			}
			if (value.Imaginary > 0.0)
			{
				v = 0.0 - v;
			}
			return new Complex(num, v);
		}

		public static Complex Tan(Complex value)
		{
			double num = 2.0 * value.m_real;
			double num2 = 2.0 * value.m_imaginary;
			double num3 = Math.Exp(num2);
			double num4 = 1.0 / num3;
			double num5 = (num3 + num4) * 0.5;
			if (Math.Abs(value.m_imaginary) <= 4.0)
			{
				double num6 = (num3 - num4) * 0.5;
				double num7 = Math.Cos(num) + num5;
				return new Complex(Math.Sin(num) / num7, num6 / num7);
			}
			double num8 = 1.0 + Math.Cos(num) / num5;
			return new Complex(Math.Sin(num) / num5 / num8, Math.Tanh(num2) / num8);
		}

		public static Complex Tanh(Complex value)
		{
			Complex complex = Tan(new Complex(0.0 - value.m_imaginary, value.m_real));
			return new Complex(complex.m_imaginary, 0.0 - complex.m_real);
		}

		public static Complex Atan(Complex value)
		{
			Complex complex = new Complex(2.0, 0.0);
			return ImaginaryOne / complex * (Log(One - ImaginaryOne * value) - Log(One + ImaginaryOne * value));
		}

		private static void Asin_Internal(double x, double y, out double b, out double bPrime, out double v)
		{
			if (x > s_asinOverflowThreshold || y > s_asinOverflowThreshold)
			{
				b = -1.0;
				bPrime = x / y;
				double num;
				double num2;
				if (x < y)
				{
					num = x;
					num2 = y;
				}
				else
				{
					num = y;
					num2 = x;
				}
				double num3 = num / num2;
				v = s_log2 + Math.Log(num2) + 0.5 * Log1P(num3 * num3);
				return;
			}
			double num4 = Hypot(x + 1.0, y);
			double num5 = Hypot(x - 1.0, y);
			double num6 = (num4 + num5) * 0.5;
			b = x / num6;
			if (b > 0.75)
			{
				if (x <= 1.0)
				{
					double num7 = (y * y / (num4 + (x + 1.0)) + (num5 + (1.0 - x))) * 0.5;
					bPrime = x / Math.Sqrt((num6 + x) * num7);
				}
				else
				{
					double num8 = (1.0 / (num4 + (x + 1.0)) + 1.0 / (num5 + (x - 1.0))) * 0.5;
					bPrime = x / y / Math.Sqrt((num6 + x) * num8);
				}
			}
			else
			{
				bPrime = -1.0;
			}
			if (num6 < 1.5)
			{
				if (x < 1.0)
				{
					double num9 = (1.0 / (num4 + (x + 1.0)) + 1.0 / (num5 + (1.0 - x))) * 0.5;
					double num10 = y * y * num9;
					v = Log1P(num10 + y * Math.Sqrt(num9 * (num6 + 1.0)));
				}
				else
				{
					double num11 = (y * y / (num4 + (x + 1.0)) + (num5 + (x - 1.0))) * 0.5;
					v = Log1P(num11 + Math.Sqrt(num11 * (num6 + 1.0)));
				}
			}
			else
			{
				v = Math.Log(num6 + Math.Sqrt((num6 - 1.0) * (num6 + 1.0)));
			}
		}

		public static Complex Log(Complex value)
		{
			return new Complex(Math.Log(Abs(value)), Math.Atan2(value.m_imaginary, value.m_real));
		}

		public static Complex Log(Complex value, double baseValue)
		{
			return Log(value) / Log(baseValue);
		}

		public static Complex Log10(Complex value)
		{
			return Scale(Log(value), 0.43429448190325);
		}

		public static Complex Exp(Complex value)
		{
			double num = Math.Exp(value.m_real);
			double real = num * Math.Cos(value.m_imaginary);
			double imaginary = num * Math.Sin(value.m_imaginary);
			return new Complex(real, imaginary);
		}

		public static Complex Sqrt(Complex value)
		{
			if (value.m_imaginary == 0.0)
			{
				if (value.m_real < 0.0)
				{
					return new Complex(0.0, Math.Sqrt(0.0 - value.m_real));
				}
				return new Complex(Math.Sqrt(value.m_real), 0.0);
			}
			bool flag = false;
			if (Math.Abs(value.m_real) >= s_sqrtRescaleThreshold || Math.Abs(value.m_imaginary) >= s_sqrtRescaleThreshold)
			{
				if (double.IsInfinity(value.m_imaginary) && !double.IsNaN(value.m_real))
				{
					return new Complex(1.0 / 0.0, value.m_imaginary);
				}
				value.m_real *= 0.25;
				value.m_imaginary *= 0.25;
				flag = true;
			}
			double num;
			double num2;
			if (value.m_real >= 0.0)
			{
				num = Math.Sqrt((Hypot(value.m_real, value.m_imaginary) + value.m_real) * 0.5);
				num2 = value.m_imaginary / (2.0 * num);
			}
			else
			{
				num2 = Math.Sqrt((Hypot(value.m_real, value.m_imaginary) - value.m_real) * 0.5);
				if (value.m_imaginary < 0.0)
				{
					num2 = 0.0 - num2;
				}
				num = value.m_imaginary / (2.0 * num2);
			}
			if (flag)
			{
				num *= 2.0;
				num2 *= 2.0;
			}
			return new Complex(num, num2);
		}

		public static Complex Pow(Complex value, Complex power)
		{
			if (power == Zero)
			{
				return One;
			}
			if (value == Zero)
			{
				return Zero;
			}
			double real = value.m_real;
			double imaginary = value.m_imaginary;
			double real2 = power.m_real;
			double imaginary2 = power.m_imaginary;
			double num = Abs(value);
			double num2 = Math.Atan2(imaginary, real);
			double num3 = real2 * num2 + imaginary2 * Math.Log(num);
			double num4 = Math.Pow(num, real2) * Math.Pow(Math.E, (0.0 - imaginary2) * num2);
			return new Complex(num4 * Math.Cos(num3), num4 * Math.Sin(num3));
		}

		private static Complex Scale(Complex value, double factor)
		{
			double real = factor * value.m_real;
			double imaginary = factor * value.m_imaginary;
			return new Complex(real, imaginary);
		}

		public static implicit operator Complex(int value)
		{
			return new Complex(value, 0.0);
		}

		public static implicit operator Complex(float value)
		{
			return new Complex(value, 0.0);
		}

		public static implicit operator Complex(double value)
		{
			return new Complex(value, 0.0);
		}
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct DoubleUlong
	{
		[FieldOffset(0)]
		public double dbl;

		[FieldOffset(0)]
		public ulong uu;
	}
	internal static class NumericsHelpers
	{
		public static void GetDoubleParts(double dbl, out int sign, out int exp, out ulong man, out bool fFinite)
		{
			DoubleUlong doubleUlong = default(DoubleUlong);
			doubleUlong.uu = 0uL;
			doubleUlong.dbl = dbl;
			sign = 1 - ((int)(doubleUlong.uu >> 62) & 2);
			man = doubleUlong.uu & 0xFFFFFFFFFFFFFL;
			exp = (int)(doubleUlong.uu >> 52) & 0x7FF;
			if (exp == 0)
			{
				fFinite = true;
				if (man != 0L)
				{
					exp = -1074;
				}
			}
			else if (exp == 2047)
			{
				fFinite = false;
				exp = 2147483647;
			}
			else
			{
				fFinite = true;
				man |= 4503599627370496uL;
				exp -= 1075;
			}
		}

		public static double GetDoubleFromParts(int sign, int exp, ulong man)
		{
			DoubleUlong doubleUlong = default(DoubleUlong);
			doubleUlong.dbl = 0.0;
			if (man == 0L)
			{
				doubleUlong.uu = 0uL;
			}
			else
			{
				int num = CbitHighZero(man) - 11;
				man = ((num >= 0) ? (man << num) : (man >> -num));
				exp -= num;
				exp += 1075;
				if (exp >= 2047)
				{
					doubleUlong.uu = 9218868437227405312uL;
				}
				else if (exp <= 0)
				{
					exp--;
					if (exp < -52)
					{
						doubleUlong.uu = 0uL;
					}
					else
					{
						doubleUlong.uu = man >> -exp;
					}
				}
				else
				{
					doubleUlong.uu = (man & 0xFFFFFFFFFFFFFL) | (ulong)((long)exp << 52);
				}
			}
			if (sign < 0)
			{
				doubleUlong.uu |= 9223372036854775808uL;
			}
			return doubleUlong.dbl;
		}

		public static void DangerousMakeTwosComplement(uint[] d)
		{
			if (d != null && d.Length != 0)
			{
				d[0] = ~d[0] + 1;
				int i;
				for (i = 1; d[i - 1] == 0 && i < d.Length; i++)
				{
					d[i] = ~d[i] + 1;
				}
				for (; i < d.Length; i++)
				{
					d[i] = ~d[i];
				}
			}
		}

		public static ulong MakeUlong(uint uHi, uint uLo)
		{
			return ((ulong)uHi << 32) | uLo;
		}

		public static uint Abs(int a)
		{
			uint num = (uint)(a >> 31);
			return ((uint)a ^ num) - num;
		}

		public static uint CombineHash(uint u1, uint u2)
		{
			return ((u1 << 7) | (u1 >> 25)) ^ u2;
		}

		public static int CombineHash(int n1, int n2)
		{
			return (int)CombineHash((uint)n1, (uint)n2);
		}

		public static int CbitHighZero(uint u)
		{
			if (u == 0)
			{
				return 32;
			}
			int num = 0;
			if ((u & 0xFFFF0000u) == 0)
			{
				num += 16;
				u <<= 16;
			}
			if ((u & 0xFF000000u) == 0)
			{
				num += 8;
				u <<= 8;
			}
			if ((u & 0xF0000000u) == 0)
			{
				num += 4;
				u <<= 4;
			}
			if ((u & 0xC0000000u) == 0)
			{
				num += 2;
				u <<= 2;
			}
			if ((u & 0x80000000u) == 0)
			{
				num++;
			}
			return num;
		}

		public static int CbitHighZero(ulong uu)
		{
			if ((uu & 0xFFFFFFFF00000000uL) == 0L)
			{
				return 32 + CbitHighZero((uint)uu);
			}
			return CbitHighZero((uint)(uu >> 32));
		}
	}
}
namespace System.Globalization
{
	internal class FormatProvider
	{
		private class Number
		{
			internal struct NumberBuffer
			{
				public int precision;

				public int scale;

				public bool sign;

				public unsafe char* overrideDigits;

				public unsafe char* digits => overrideDigits;
			}

			private static string[] s_posCurrencyFormats = new string[4] { "$#", "#$", "$ #", "# $" };

			private static string[] s_negCurrencyFormats = new string[16]
			{
				"($#)", "-$#", "$-#", "$#-", "(#$)", "-#$", "#-$", "#$-", "-# $", "-$ #",
				"# $-", "$ #-", "$ -#", "#- $", "($ #)", "(# $)"
			};

			private static string[] s_posPercentFormats = new string[4] { "# %", "#%", "%#", "% #" };

			private static string[] s_negPercentFormats = new string[12]
			{
				"-# %", "-#%", "-%#", "%-#", "%#-", "#-%", "#%-", "-% #", "# %-", "% #-",
				"% -#", "#- %"
			};

			private static string[] s_negNumberFormats = new string[5] { "(#)", "-#", "- #", "#-", "# -" };

			private static string s_posNumberFormat = "#";

			private static bool IsWhite(char ch)
			{
				if (ch != ' ')
				{
					if (ch >= '\t')
					{
						return ch <= '\r';
					}
					return false;
				}
				return true;
			}

			private unsafe static char* MatchChars(char* p, char* pEnd, string str)
			{
				fixed (char* str2 = str)
				{
					return MatchChars(p, pEnd, str2);
				}
			}

			private unsafe static char* MatchChars(char* p, char* pEnd, char* str)
			{
				if (*str == '\0')
				{
					return null;
				}
				while (true)
				{
					char c = ((p < pEnd) ? (*p) : '\0');
					if (c != *str && (*str != '\u00a0' || c != ' '))
					{
						break;
					}
					p++;
					str++;
					if (*str == '\0')
					{
						return p;
					}
				}
				return null;
			}

			private unsafe static bool ParseNumber(ref char* str, char* strEnd, NumberStyles options, ref NumberBuffer number, StringBuilder sb, NumberFormatInfo numfmt, bool parseDecimal)
			{
				number.scale = 0;
				number.sign = false;
				string text = null;
				bool flag = false;
				string str2;
				string str3;
				if ((options & NumberStyles.AllowCurrencySymbol) != NumberStyles.None)
				{
					text = numfmt.CurrencySymbol;
					str2 = numfmt.CurrencyDecimalSeparator;
					str3 = numfmt.CurrencyGroupSeparator;
					flag = true;
				}
				else
				{
					str2 = numfmt.NumberDecimalSeparator;
					str3 = numfmt.NumberGroupSeparator;
				}
				int num = 0;
				bool flag2 = sb != null;
				int num2 = (flag2 ? 2147483647 : 32);
				char* ptr = str;
				char c = ((ptr < strEnd) ? (*ptr) : '\0');
				char* digits = number.digits;
				while (true)
				{
					if (!IsWhite(c) || (options & NumberStyles.AllowLeadingWhite) == 0 || ((num & 1) != 0 && (num & 0x20) == 0 && numfmt.NumberNegativePattern != 2))
					{
						char* ptr2;
						if ((options & NumberStyles.AllowLeadingSign) != NumberStyles.None && (num & 1) == 0 && ((ptr2 = MatchChars(ptr, strEnd, numfmt.PositiveSign)) != null || ((ptr2 = MatchChars(ptr, strEnd, numfmt.NegativeSign)) != null && (number.sign = true))))
						{
							num |= 1;
							ptr = ptr2 - 1;
						}
						else if (c == '(' && (options & NumberStyles.AllowParentheses) != NumberStyles.None && (num & 1) == 0)
						{
							num |= 3;
							number.sign = true;
						}
						else
						{
							if (text == null || (ptr2 = MatchChars(ptr, strEnd, text)) == null)
							{
								break;
							}
							num |= 0x20;
							text = null;
							ptr = ptr2 - 1;
						}
					}
					c = ((++ptr < strEnd) ? (*ptr) : '\0');
				}
				int num3 = 0;
				int num4 = 0;
				while (true)
				{
					char* ptr2;
					if ((c >= '0' && c <= '9') || ((options & NumberStyles.AllowHexSpecifier) != NumberStyles.None && ((c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))))
					{
						num |= 4;
						if (c != '0' || (num & 8) != 0 || (flag2 && (options & NumberStyles.AllowHexSpecifier) != NumberStyles.None))
						{
							if (num3 < num2)
							{
								if (flag2)
								{
									sb.Append(c);
								}
								else
								{
									digits[num3++] = c;
								}
								if (c != '0' || parseDecimal)
								{
									num4 = num3;
								}
							}
							if ((num & 0x10) == 0)
							{
								number.scale++;
							}
							num |= 8;
						}
						else if ((num & 0x10) != 0)
						{
							number.scale--;
						}
					}
					else if ((options & NumberStyles.AllowDecimalPoint) != NumberStyles.None && (num & 0x10) == 0 && ((ptr2 = MatchChars(ptr, strEnd, str2)) != null || (flag && (num & 0x20) == 0 && (ptr2 = MatchChars(ptr, strEnd, numfmt.NumberDecimalSeparator)) != null)))
					{
						num |= 0x10;
						ptr = ptr2 - 1;
					}
					else
					{
						if ((options & NumberStyles.AllowThousands) == 0 || (num & 4) == 0 || (num & 0x10) != 0 || ((ptr2 = MatchChars(ptr, strEnd, str3)) == null && (!flag || (num & 0x20) != 0 || (ptr2 = MatchChars(ptr, strEnd, numfmt.NumberGroupSeparator)) == null)))
						{
							break;
						}
						ptr = ptr2 - 1;
					}
					c = ((++ptr < strEnd) ? (*ptr) : '\0');
				}
				bool flag3 = false;
				number.precision = num4;
				if (flag2)
				{
					sb.Append('\0');
				}
				else
				{
					digits[num4] = '\0';
				}
				if ((num & 4) != 0)
				{
					if ((c == 'E' || c == 'e') && (options & NumberStyles.AllowExponent) != NumberStyles.None)
					{
						char* ptr3 = ptr;
						c = ((++ptr < strEnd) ? (*ptr) : '\0');
						char* ptr2;
						if ((ptr2 = MatchChars(ptr, strEnd, numfmt.PositiveSign)) != null)
						{
							c = (((ptr = ptr2) < strEnd) ? (*ptr) : '\0');
						}
						else if ((ptr2 = MatchChars(ptr, strEnd, numfmt.NegativeSign)) != null)
						{
							c = (((ptr = ptr2) < strEnd) ? (*ptr) : '\0');
							flag3 = true;
						}
						if (c >= '0' && c <= '9')
						{
							int num5 = 0;
							do
							{
								num5 = num5 * 10 + (c - 48);
								c = ((++ptr < strEnd) ? (*ptr) : '\0');
								if (num5 > 1000)
								{
									num5 = 9999;
									while (c >= '0' && c <= '9')
									{
										c = ((++ptr < strEnd) ? (*ptr) : '\0');
									}
								}
							}
							while (c >= '0' && c <= '9');
							if (flag3)
							{
								num5 = -num5;
							}
							number.scale += num5;
						}
						else
						{
							ptr = ptr3;
							c = ((ptr < strEnd) ? (*ptr) : '\0');
						}
					}
					while (true)
					{
						if (!IsWhite(c) || (options & NumberStyles.AllowTrailingWhite) == 0)
						{
							char* ptr2;
							if ((options & NumberStyles.AllowTrailingSign) != NumberStyles.None && (num & 1) == 0 && ((ptr2 = MatchChars(ptr, strEnd, numfmt.PositiveSign)) != null || ((ptr2 = MatchChars(ptr, strEnd, numfmt.NegativeSign)) != null && (number.sign = true))))
							{
								num |= 1;
								ptr = ptr2 - 1;
							}
							else if (c == ')' && (num & 2) != 0)
							{
								num &= -3;
							}
							else
							{
								if (text == null || (ptr2 = MatchChars(ptr, strEnd, text)) == null)
								{
									break;
								}
								text = null;
								ptr = ptr2 - 1;
							}
						}
						c = ((++ptr < strEnd) ? (*ptr) : '\0');
					}
					if ((num & 2) == 0)
					{
						if ((num & 8) == 0)
						{
							if (!parseDecimal)
							{
								number.scale = 0;
							}
							if ((num & 0x10) == 0)
							{
								number.sign = false;
							}
						}
						str = ptr;
						return true;
					}
				}
				str = ptr;
				return false;
			}

			private static bool TrailingZeros(ReadOnlySpan<char> s, int index)
			{
				for (int i = index; i < s.Length; i++)
				{
					if (s[i] != 0)
					{
						return false;
					}
				}
				return true;
			}

			internal unsafe static bool TryStringToNumber(ReadOnlySpan<char> str, NumberStyles options, ref NumberBuffer number, StringBuilder sb, NumberFormatInfo numfmt, bool parseDecimal)
			{
				fixed (char* reference = &MemoryMarshal.GetReference(str))
				{
					char* str2 = reference;
					if (!ParseNumber(ref str2, str2 + str.Length, options, ref number, sb, numfmt, parseDecimal) || (str2 - reference < str.Length && !TrailingZeros(str, (int)(str2 - reference))))
					{
						return false;
					}
				}
				return true;
			}

			internal unsafe static void Int32ToDecChars(char* buffer, ref int index, uint value, int digits)
			{
				while (--digits >= 0 || value != 0)
				{
					buffer[--index] = (char)(value % 10 + 48);
					value /= 10;
				}
			}

			internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits)
			{
				char c = '\0';
				if (format.Length > 0)
				{
					c = format[0];
					if ((uint)(c - 65) <= 25u || (uint)(c - 97) <= 25u)
					{
						if (format.Length == 1)
						{
							digits = -1;
							return c;
						}
						if (format.Length == 2)
						{
							int num = format[1] - 48;
							if ((uint)num < 10u)
							{
								digits = num;
								return c;
							}
						}
						else if (format.Length == 3)
						{
							int num2 = format[1] - 48;
							int num3 = format[2] - 48;
							if ((uint)num2 < 10u && (uint)num3 < 10u)
							{
								digits = num2 * 10 + num3;
								return c;
							}
						}
						int num4 = 0;
						int num5 = 1;
						while (num5 < format.Length && (uint)(format[num5] - 48) < 10u && num4 < 10)
						{
							num4 = num4 * 10 + format[num5++] - 48;
						}
						if (num5 == format.Length || format[num5] == '\0')
						{
							digits = num4;
							return c;
						}
					}
				}
				digits = -1;
				if (format.Length != 0 && c != 0)
				{
					return '\0';
				}
				return 'G';
			}

			internal unsafe static void NumberToString(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, char format, int nMaxDigits, NumberFormatInfo info, bool isDecimal)
			{
				int num = -1;
				switch (format)
				{
				case 'C':
				case 'c':
					num = ((nMaxDigits >= 0) ? nMaxDigits : info.CurrencyDecimalDigits);
					if (nMaxDigits < 0)
					{
						nMaxDigits = info.CurrencyDecimalDigits;
					}
					RoundNumber(ref number, number.scale + nMaxDigits);
					FormatCurrency(ref sb, ref number, num, nMaxDigits, info);
					break;
				case 'F':
				case 'f':
					if (nMaxDigits < 0)
					{
						nMaxDigits = (num = info.NumberDecimalDigits);
					}
					else
					{
						num = nMaxDigits;
					}
					RoundNumber(ref number, number.scale + nMaxDigits);
					if (number.sign)
					{
						sb.Append(info.NegativeSign);
					}
					FormatFixed(ref sb, ref number, num, nMaxDigits, info, null, info.NumberDecimalSeparator, null);
					break;
				case 'N':
				case 'n':
					if (nMaxDigits < 0)
					{
						nMaxDigits = (num = info.NumberDecimalDigits);
					}
					else
					{
						num = nMaxDigits;
					}
					RoundNumber(ref number, number.scale + nMaxDigits);
					FormatNumber(ref sb, ref number, num, nMaxDigits, info);
					break;
				case 'E':
				case 'e':
					if (nMaxDigits < 0)
					{
						nMaxDigits = (num = 6);
					}
					else
					{
						num = nMaxDigits;
					}
					nMaxDigits++;
					RoundNumber(ref number, nMaxDigits);
					if (number.sign)
					{
						sb.Append(info.NegativeSign);
					}
					FormatScientific(ref sb, ref number, num, nMaxDigits, info, format);
					break;
				case 'G':
				case 'g':
				{
					bool flag = true;
					if (nMaxDigits < 1)
					{
						if (isDecimal && nMaxDigits == -1)
						{
							nMaxDigits = (num = 29);
							flag = false;
						}
						else
						{
							nMaxDigits = (num = number.precision);
						}
					}
					else
					{
						num = nMaxDigits;
					}
					if (flag)
					{
						RoundNumber(ref number, nMaxDigits);
					}
					else if (isDecimal && *number.digits == '\0')
					{
						number.sign = false;
					}
					if (number.sign)
					{
						sb.Append(info.NegativeSign);
					}
					FormatGeneral(ref sb, ref number, num, nMaxDigits, info, (char)(format - 2), !flag);
					break;
				}
				case 'P':
				case 'p':
					if (nMaxDigits < 0)
					{
						nMaxDigits = (num = info.PercentDecimalDigits);
					}
					else
					{
						num = nMaxDigits;
					}
					number.scale += 2;
					RoundNumber(ref number, number.scale + nMaxDigits);
					FormatPercent(ref sb, ref number, num, nMaxDigits, info);
					break;
				default:
					throw new FormatException("Format specifier was invalid.");
				}
			}

			private static void FormatCurrency(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info)
			{
				string text = (number.sign ? s_negCurrencyFormats[info.CurrencyNegativePattern] : s_posCurrencyFormats[info.CurrencyPositivePattern]);
				foreach (char c in text)
				{
					switch (c)
					{
					case '#':
						FormatFixed(ref sb, ref number, nMinDigits, nMaxDigits, info, info.CurrencyGroupSizes, info.CurrencyDecimalSeparator, info.CurrencyGroupSeparator);
						break;
					case '-':
						sb.Append(info.NegativeSign);
						break;
					case '$':
						sb.Append(info.CurrencySymbol);
						break;
					default:
						sb.Append(c);
						break;
					}
				}
			}

			private unsafe static int wcslen(char* s)
			{
				int num = 0;
				while (*(s++) != 0)
				{
					num++;
				}
				return num;
			}

			private unsafe static void FormatFixed(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, int[] groupDigits, string sDecimal, string sGroup)
			{
				int scale = number.scale;
				char* ptr = number.digits;
				int num = wcslen(ptr);
				if (scale > 0)
				{
					if (groupDigits != null)
					{
						int num2 = 0;
						int num3 = groupDigits[num2];
						int num4 = groupDigits.Length;
						int num5 = scale;
						int length = sGroup.Length;
						int num6 = 0;
						if (num4 != 0)
						{
							while (scale > num3 && groupDigits[num2] != 0)
							{
								num5 += length;
								if (num2 < num4 - 1)
								{
									num2++;
								}
								num3 += groupDigits[num2];
								if (num3 < 0 || num5 < 0)
								{
									throw new ArgumentOutOfRangeException();
								}
							}
							num6 = ((num3 != 0) ? groupDigits[0] : 0);
						}
						char* ptr2 = stackalloc char[num5];
						num2 = 0;
						int num7 = 0;
						int num8 = ((scale < num) ? scale : num);
						char* ptr3 = ptr2 + num5 - 1;
						for (int num9 = scale - 1; num9 >= 0; num9--)
						{
							*(ptr3--) = ((num9 < num8) ? ptr[num9] : '0');
							if (num6 > 0)
							{
								num7++;
								if (num7 == num6 && num9 != 0)
								{
									for (int num10 = length - 1; num10 >= 0; num10--)
									{
										*(ptr3--) = sGroup[num10];
									}
									if (num2 < num4 - 1)
									{
										num2++;
										num6 = groupDigits[num2];
									}
									num7 = 0;
								}
							}
						}
						sb.Append(ptr2, num5);
						ptr += num8;
					}
					else
					{
						int num11 = Math.Min(num, scale);
						sb.Append(ptr, num11);
						ptr += num11;
						if (scale > num)
						{
							sb.Append('0', scale - num);
						}
					}
				}
				else
				{
					sb.Append('0');
				}
				if (nMaxDigits > 0)
				{
					sb.Append(sDecimal);
					if (scale < 0 && nMaxDigits > 0)
					{
						int num12 = Math.Min(-scale, nMaxDigits);
						sb.Append('0', num12);
						scale += num12;
						nMaxDigits -= num12;
					}
					while (nMaxDigits > 0)
					{
						sb.Append((*ptr != 0) ? (*(ptr++)) : '0');
						nMaxDigits--;
					}
				}
			}

			private static void FormatNumber(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info)
			{
				string text = (number.sign ? s_negNumberFormats[info.NumberNegativePattern] : s_posNumberFormat);
				foreach (char c in text)
				{
					switch (c)
					{
					case '#':
						FormatFixed(ref sb, ref number, nMinDigits, nMaxDigits, info, info.NumberGroupSizes, info.NumberDecimalSeparator, info.NumberGroupSeparator);
						break;
					case '-':
						sb.Append(info.NegativeSign);
						break;
					default:
						sb.Append(c);
						break;
					}
				}
			}

			private unsafe static void FormatScientific(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar)
			{
				char* digits = number.digits;
				sb.Append((*digits != 0) ? (*(digits++)) : '0');
				if (nMaxDigits != 1)
				{
					sb.Append(info.NumberDecimalSeparator);
				}
				while (--nMaxDigits > 0)
				{
					sb.Append((*digits != 0) ? (*(digits++)) : '0');
				}
				int value = ((*number.digits != 0) ? (number.scale - 1) : 0);
				FormatExponent(ref sb, info, value, expChar, 3, positiveSign: true);
			}

			private unsafe static void FormatExponent(ref System.Text.ValueStringBuilder sb, NumberFormatInfo info, int value, char expChar, int minDigits, bool positiveSign)
			{
				sb.Append(expChar);
				if (value < 0)
				{
					sb.Append(info.NegativeSign);
					value = -value;
				}
				else if (positiveSign)
				{
					sb.Append(info.PositiveSign);
				}
				char* ptr = stackalloc char[11];
				int index = 10;
				Int32ToDecChars(ptr, ref index, (uint)value, minDigits);
				int num = 10 - index;
				while (--num >= 0)
				{
					sb.Append(ptr[index++]);
				}
			}

			private unsafe static void FormatGeneral(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar, bool bSuppressScientific)
			{
				int i = number.scale;
				bool flag = false;
				if (!bSuppressScientific && (i > nMaxDigits || i < -3))
				{
					i = 1;
					flag = true;
				}
				char* digits = number.digits;
				if (i > 0)
				{
					do
					{
						sb.Append((*digits != 0) ? (*(digits++)) : '0');
					}
					while (--i > 0);
				}
				else
				{
					sb.Append('0');
				}
				if (*digits != 0 || i < 0)
				{
					sb.Append(info.NumberDecimalSeparator);
					for (; i < 0; i++)
					{
						sb.Append('0');
					}
					while (*digits != 0)
					{
						sb.Append(*(digits++));
					}
				}
				if (flag)
				{
					FormatExponent(ref sb, info, number.scale - 1, expChar, 2, positiveSign: true);
				}
			}

			private static void FormatPercent(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info)
			{
				string text = (number.sign ? s_negPercentFormats[info.PercentNegativePattern] : s_posPercentFormats[info.PercentPositivePattern]);
				foreach (char c in text)
				{
					switch (c)
					{
					case '#':
						FormatFixed(ref sb, ref number, nMinDigits, nMaxDigits, info, info.PercentGroupSizes, info.PercentDecimalSeparator, info.PercentGroupSeparator);
						break;
					case '-':
						sb.Append(info.NegativeSign);
						break;
					case '%':
						sb.Append(info.PercentSymbol);
						break;
					default:
						sb.Append(c);
						break;
					}
				}
			}

			private unsafe static void RoundNumber(ref NumberBuffer number, int pos)
			{
				char* digits = number.digits;
				int i;
				for (i = 0; i < pos && digits[i] != 0; i++)
				{
				}
				if (i == pos && digits[i] >= '5')
				{
					while (i > 0 && digits[i - 1] == '9')
					{
						i--;
					}
					if (i > 0)
					{
						char* num = digits + (i - 1);
						*num = (char)(*num + 1);
					}
					else
					{
						number.scale++;
						*digits = '1';
						i = 1;
					}
				}
				else
				{
					while (i > 0 && digits[i - 1] == '0')
					{
						i--;
					}
				}
				if (i == 0)
				{
					number.scale = 0;
					number.sign = false;
				}
				digits[i] = '\0';
			}

			private unsafe static int FindSection(ReadOnlySpan<char> format, int section)
			{
				if (section == 0)
				{
					return 0;
				}
				fixed (char* reference = &MemoryMarshal.GetReference(format))
				{
					int num = 0;
					while (true)
					{
						if (num >= format.Length)
						{
							return 0;
						}
						char c2;
						char c = (c2 = reference[num++]);
						if ((uint)c <= 34u)
						{
							if (c == '\0')
							{
								break;
							}
							if (c != '"')
							{
								continue;
							}
						}
						else if (c != '\'')
						{
							switch (c)
							{
							default:
								continue;
							case '\\':
								if (num < format.Length && reference[num] != 0)
								{
									num++;
								}
								continue;
							case ';':
								break;
							}
							if (--section == 0)
							{
								if (num >= format.Length || reference[num] == '\0' || reference[num] == ';')
								{
									break;
								}
								return num;
							}
							continue;
						}
						while (num < format.Length && reference[num] != 0 && reference[num++] != c2)
						{
						}
					}
					return 0;
				}
			}

			internal unsafe static void NumberToStringFormat(ref System.Text.ValueStringBuilder sb, ref NumberBuffer number, ReadOnlySpan<char> format, NumberFormatInfo info)
			{
				int num = 0;
				char* digits = number.digits;
				int num2 = FindSection(format, (*digits == '\0') ? 2 : (number.sign ? 1 : 0));
				int num3;
				int num4;
				bool flag;
				bool flag2;
				int num5;
				int num6;
				int num9;
				while (true)
				{
					num3 = 0;
					num4 = -1;
					num5 = 2147483647;
					num6 = 0;
					flag = false;
					int num7 = -1;
					flag2 = false;
					int num8 = 0;
					num9 = num2;
					fixed (char* reference = &MemoryMarshal.GetReference(format))
					{
						char c;
						while (num9 < format.Length && (c = reference[num9++]) != 0)
						{
							switch (c)
							{
							case ';':
								break;
							case '#':
								num3++;
								continue;
							case '0':
								if (num5 == 2147483647)
								{
									num5 = num3;
								}
								num3++;
								num6 = num3;
								continue;
							case '.':
								if (num4 < 0)
								{
									num4 = num3;
								}
								continue;
							case ',':
								if (num3 <= 0 || num4 >= 0)
								{
									continue;
								}
								if (num7 >= 0)
								{
									if (num7 == num3)
									{
										num++;
										continue;
									}
									flag2 = true;
								}
								num7 = num3;
								num = 1;
								continue;
							case '%':
								num8 += 2;
								continue;
							case '‰':
								num8 += 3;
								continue;
							case '"':
							case '\'':
								while (num9 < format.Length && reference[num9] != 0 && reference[num9++] != c)
								{
								}
								continue;
							case '\\':
								if (num9 < format.Length && reference[num9] != 0)
								{
									num9++;
								}
								continue;
							case 'E':
							case 'e':
								if ((num9 < format.Length && reference[num9] == '0') || (num9 + 1 < format.Length && (reference[num9] == '+' || reference[num9] == '-') && reference[num9 + 1] == '0'))
								{
									while (++num9 < format.Length && reference[num9] == '0')
									{
									}
									flag = true;
								}
								continue;
							default:
								continue;
							}
							break;
						}
					}
					if (num4 < 0)
					{
						num4 = num3;
					}
					if (num7 >= 0)
					{
						if (num7 == num4)
						{
							num8 -= num * 3;
						}
						else
						{
							flag2 = true;
						}
					}
					if (*digits != 0)
					{
						number.scale += num8;
						int pos = (flag ? num3 : (number.scale + num3 - num4));
						RoundNumber(ref number, pos);
						if (*digits != 0)
						{
							break;
						}
						num9 = FindSection(format, 2);
						if (num9 == num2)
						{
							break;
						}
						num2 = num9;
						continue;
					}
					number.sign = false;
					number.scale = 0;
					break;
				}
				num5 = ((num5 < num4) ? (num4 - num5) : 0);
				num6 = ((num6 > num4) ? (num4 - num6) : 0);
				int num10;
				int num11;
				if (flag)
				{
					num10 = num4;
					num11 = 0;
				}
				else
				{
					num10 = ((number.scale > num4) ? number.scale : num4);
					num11 = number.scale - num4;
				}
				num9 = num2;
				Span<int> span = stackalloc int[4];
				int num12 = -1;
				if (flag2 && info.NumberGroupSeparator.Length > 0)
				{
					int[] numberGroupSizes = info.NumberGroupSizes;
					int num13 = 0;
					int i = 0;
					int num14 = numberGroupSizes.Length;
					if (num14 != 0)
					{
						i = numberGroupSizes[num13];
					}
					int num15 = i;
					int num16 = num10 + ((num11 < 0) ? num11 : 0);
					for (int num17 = ((num5 > num16) ? num5 : num16); num17 > i; i += num15)
					{
						if (num15 == 0)
						{
							break;
						}
						num12++;
						if (num12 >= span.Length)
						{
							int[] array = new int[span.Length * 2];
							span.CopyTo(array);
							span = array;
						}
						span[num12] = i;
						if (num13 < num14 - 1)
						{
							num13++;
							num15 = numberGroupSizes[num13];
						}
					}
				}
				if (number.sign && num2 == 0)
				{
					sb.Append(info.NegativeSign);
				}
				bool flag3 = false;
				fixed (char* reference2 = &MemoryMarshal.GetReference(format))
				{
					char* ptr = digits;
					char c;
					while (num9 < format.Length && (c = reference2[num9++]) != 0 && c != ';')
					{
						if (num11 > 0 && (c == '#' || c == '.' || c == '0'))
						{
							while (num11 > 0)
							{
								sb.Append((*ptr != 0) ? (*(ptr++)) : '0');
								if (flag2 && num10 > 1 && num12 >= 0 && num10 == span[num12] + 1)
								{
									sb.Append(info.NumberGroupSeparator);
									num12--;
								}
								num10--;
								num11--;
							}
						}
						switch (c)
						{
						case '#':
						case '0':
							if (num11 < 0)
							{
								num11++;
								c = ((num10 <= num5) ? '0' : '\0');
							}
							else
							{
								c = ((*ptr != 0) ? (*(ptr++)) : ((num10 > num6) ? '0' : '\0'));
							}
							if (c != 0)
							{
								sb.Append(c);
								if (flag2 && num10 > 1 && num12 >= 0 && num10 == span[num12] + 1)
								{
									sb.Append(info.NumberGroupSeparator);
									num12--;
								}
							}
							num10--;
							break;
						case '.':
							if (!(num10 != 0 || flag3) && (num6 < 0 || (num4 < num3 && *ptr != 0)))
							{
								sb.Append(info.NumberDecimalSeparator);
								flag3 = true;
							}
							break;
						case '‰':
							sb.Append(info.PerMilleSymbol);
							break;
						case '%':
							sb.Append(info.PercentSymbol);
							break;
						case '"':
						case '\'':
							while (num9 < format.Length && reference2[num9] != 0 && reference2[num9] != c)
							{
								sb.Append(reference2[num9++]);
							}
							if (num9 < format.Length && reference2[num9] != 0)
							{
								num9++;
							}
							break;
						case '\\':
							if (num9 < format.Length && reference2[num9] != 0)
							{
								sb.Append(reference2[num9++]);
							}
							break;
						case 'E':
						case 'e':
						{
							bool positiveSign = false;
							int num18 = 0;
							if (flag)
							{
								if (num9 < format.Length && reference2[num9] == '0')
								{
									num18++;
								}
								else if (num9 + 1 < format.Length && reference2[num9] == '+' && reference2[num9 + 1] == '0')
								{
									positiveSign = true;
								}
								else if (num9 + 1 >= format.Length || reference2[num9] != '-' || reference2[num9 + 1] != '0')
								{
									sb.Append(c);
									break;
								}
								while (++num9 < format.Length && reference2[num9] == '0')
								{
									num18++;
								}
								if (num18 > 10)
								{
									num18 = 10;
								}
								int value = ((*digits != 0) ? (number.scale - num4) : 0);
								FormatExponent(ref sb, info, value, c, num18, positiveSign);
								flag = false;
								break;
							}
							sb.Append(c);
							if (num9 < format.Length)
							{
								if (reference2[num9] == '+' || reference2[num9] == '-')
								{
									sb.Append(reference2[num9++]);
								}
								while (num9 < format.Length && reference2[num9] == '0')
								{
									sb.Append(reference2[num9++]);
								}
							}
							break;
						}
						default:
							sb.Append(c);
							break;
						case ',':
							break;
						}
					}
				}
			}
		}

		internal unsafe static void FormatBigInteger(ref System.Text.ValueStringBuilder sb, int precision, int scale, bool sign, ReadOnlySpan<char> format, NumberFormatInfo numberFormatInfo, char[] digits, int startIndex)
		{
			fixed (char* ptr = digits)
			{
				Number.NumberBuffer number = new Number.NumberBuffer
				{
					overrideDigits = ptr + startIndex,
					precision = precision,
					scale = scale,
					sign = sign
				};
				int digits2;
				char c = Number.ParseFormatSpecifier(format, out digits2);
				if (c != 0)
				{
					Number.NumberToString(ref sb, ref number, c, digits2, numberFormatInfo, isDecimal: false);
				}
				else
				{
					Number.NumberToStringFormat(ref sb, ref number, format, numberFormatInfo);
				}
			}
		}

		internal unsafe static bool TryStringToBigInteger(ReadOnlySpan<char> s, NumberStyles styles, NumberFormatInfo numberFormatInfo, StringBuilder receiver, out int precision, out int scale, out bool sign)
		{
			Number.NumberBuffer number = new Number.NumberBuffer
			{
				overrideDigits = (char*)1
			};
			if (!Number.TryStringToNumber(s, styles, ref number, receiver, numberFormatInfo, parseDecimal: false))
			{
				precision = 0;
				scale = 0;
				sign = false;
				return false;
			}
			precision = number.precision;
			scale = number.scale;
			sign = number.sign;
			return true;
		}
	}
}
namespace System.Text
{
	[DefaultMember("Item")]
	internal ref struct ValueStringBuilder(Span<char> initialBuffer)
	{
		private char[] _arrayToReturnToPool = null;

		private Span<char> _chars = initialBuffer;

		private int _pos = 0;

		public int Length => _pos;

		public override string ToString()
		{
			string result = new string(_chars.Slice(0, _pos));
			Dispose();
			return result;
		}

		public bool TryCopyTo(Span<char> destination, out int charsWritten)
		{
			if (_chars.Slice(0, _pos).TryCopyTo(destination))
			{
				charsWritten = _pos;
				Dispose();
				return true;
			}
			charsWritten = 0;
			Dispose();
			return false;
		}

		public void Insert(int index, char value, int count)
		{
			if (_pos > _chars.Length - count)
			{
				Grow(count);
			}
			int length = _pos - index;
			_chars.Slice(index, length).CopyTo(_chars.Slice(index + count));
			_chars.Slice(index, count).Fill(value);
			_pos += count;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(char c)
		{
			int pos = _pos;
			if (pos < _chars.Length)
			{
				_chars[pos] = c;
				_pos = pos + 1;
			}
			else
			{
				GrowAndAppend(c);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(string s)
		{
			int pos = _pos;
			if (s.Length == 1 && pos < _chars.Length)
			{
				_chars[pos] = s[0];
				_pos = pos + 1;
			}
			else
			{
				AppendSlow(s);
			}
		}

		private void AppendSlow(string s)
		{
			int pos = _pos;
			if (pos > _chars.Length - s.Length)
			{
				Grow(s.Length);
			}
			s.AsSpan().CopyTo(_chars.Slice(pos));
			_pos += s.Length;
		}

		public void Append(char c, int count)
		{
			if (_pos > _chars.Length - count)
			{
				Grow(count);
			}
			Span<char> span = _chars.Slice(_pos, count);
			for (int i = 0; i < span.Length; i++)
			{
				span[i] = c;
			}
			_pos += count;
		}

		public unsafe void Append(char* value, int length)
		{
			if (_pos > _chars.Length - length)
			{
				Grow(length);
			}
			Span<char> span = _chars.Slice(_pos, length);
			for (int i = 0; i < span.Length; i++)
			{
				span[i] = *(value++);
			}
			_pos += length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<char> AppendSpan(int length)
		{
			int pos = _pos;
			if (pos > _chars.Length - length)
			{
				Grow(length);
			}
			_pos = pos + length;
			return _chars.Slice(pos, length);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void GrowAndAppend(char c)
		{
			Grow(1);
			Append(c);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Grow(int requiredAdditionalCapacity)
		{
			char[] array = ArrayPool<char>.Shared.Rent(Math.Max(_pos + requiredAdditionalCapacity, _chars.Length * 2));
			_chars.CopyTo(array);
			char[] arrayToReturnToPool = _arrayToReturnToPool;
			_chars = (_arrayToReturnToPool = array);
			if (arrayToReturnToPool != null)
			{
				ArrayPool<char>.Shared.Return(arrayToReturnToPool);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
			char[] arrayToReturnToPool = _arrayToReturnToPool;
			this = default(System.Text.ValueStringBuilder);
			if (arrayToReturnToPool != null)
			{
				ArrayPool<char>.Shared.Return(arrayToReturnToPool);
			}
		}
	}
}
