using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Mono.Math;
using Mono.Math.Prime.Generator;
using Mono.Net.Security;
using Mono.Security.Cryptography;
using Mono.Security.X509;
using Mono.Security.X509.Extensions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyCompany("MONO development team")]
[assembly: AssemblyCopyright("(c) 2003-2004 Various Authors")]
[assembly: AssemblyDescription("Mono.Security.dll")]
[assembly: AssemblyProduct("MONO CLI")]
[assembly: AssemblyTitle("Mono.Security.dll")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyDelaySign(true)]
[assembly: InternalsVisibleTo("System, PublicKey=00240000048000009400000006020000002400005253413100040000010001008D56C76F9E8649383049F383C44BE0EC204181822A6C31CF5EB7EF486944D032188EA1D3920763712CCB12D75FB77E9811149E6148E5D32FBAAB37611C1878DDC19E20EF135D0CB2CFF2BFEC3D115810C3D9069638FE4BE215DBF795861920E5AB6F7DB2E2CEEF136AC23D5DD2BF031700AEC232F6C6B1C785B4305C123B37AB")]
[assembly: AssemblyVersion("2.0.5.0")]
[module: UnverifiableCode]
internal sealed class Locale
{
	public static string GetText(string msg)
	{
		return msg;
	}

	public static string GetText(string fmt, params object[] args)
	{
		return string.Format(fmt, args);
	}
}
namespace Mono.Security
{
	public class ASN1
	{
		private byte m_nTag;

		private byte[] m_aValue;

		private ArrayList elist;

		public int Count
		{
			get
			{
				if (elist == null)
				{
					return 0;
				}
				return elist.Count;
			}
		}

		public byte Tag => m_nTag;

		public int Length
		{
			get
			{
				if (m_aValue != null)
				{
					return m_aValue.Length;
				}
				return 0;
			}
		}

		public byte[] Value
		{
			get
			{
				if (m_aValue == null)
				{
					GetBytes();
				}
				return (byte[])m_aValue.Clone();
			}
			set
			{
				if (value != null)
				{
					m_aValue = (byte[])value.Clone();
				}
			}
		}

		public ASN1 this[int index]
		{
			get
			{
				try
				{
					if (elist == null || index >= elist.Count)
					{
						return null;
					}
					return (ASN1)elist[index];
				}
				catch (ArgumentOutOfRangeException)
				{
					return null;
				}
			}
		}

		public ASN1(byte tag)
			: this(tag, null)
		{
		}

		public ASN1(byte tag, byte[] data)
		{
			m_nTag = tag;
			m_aValue = data;
		}

		public ASN1(byte[] data)
		{
			m_nTag = data[0];
			int num = 0;
			int num2 = data[1];
			if (num2 > 128)
			{
				num = num2 - 128;
				num2 = 0;
				for (int i = 0; i < num; i++)
				{
					num2 *= 256;
					num2 += data[i + 2];
				}
			}
			else if (num2 == 128)
			{
				throw new NotSupportedException("Undefined length encoding.");
			}
			m_aValue = new byte[num2];
			Buffer.BlockCopy(data, 2 + num, m_aValue, 0, num2);
			if ((m_nTag & 0x20) == 32)
			{
				int anPos = 0;
				Decode(m_aValue, ref anPos, m_aValue.Length);
			}
		}

		private bool CompareArray(byte[] array1, byte[] array2)
		{
			bool flag = array1.Length == array2.Length;
			if (flag)
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return flag;
		}

		public bool CompareValue(byte[] value)
		{
			return CompareArray(m_aValue, value);
		}

		public ASN1 Add(ASN1 asn1)
		{
			if (asn1 != null)
			{
				if (elist == null)
				{
					elist = new ArrayList();
				}
				elist.Add(asn1);
			}
			return asn1;
		}

		public virtual byte[] GetBytes()
		{
			byte[] array = null;
			if (Count > 0)
			{
				int num = 0;
				ArrayList arrayList = new ArrayList();
				foreach (ASN1 item in elist)
				{
					byte[] bytes = item.GetBytes();
					arrayList.Add(bytes);
					num += bytes.Length;
				}
				array = new byte[num];
				int num2 = 0;
				for (int i = 0; i < elist.Count; i++)
				{
					byte[] array2 = (byte[])arrayList[i];
					Buffer.BlockCopy(array2, 0, array, num2, array2.Length);
					num2 += array2.Length;
				}
			}
			else if (m_aValue != null)
			{
				array = m_aValue;
			}
			int num3 = 0;
			byte[] array3;
			if (array != null)
			{
				int num4 = array.Length;
				if (num4 > 127)
				{
					if (num4 <= 255)
					{
						array3 = new byte[3 + num4];
						Buffer.BlockCopy(array, 0, array3, 3, num4);
						num3 = 129;
						array3[2] = (byte)num4;
					}
					else if (num4 <= 65535)
					{
						array3 = new byte[4 + num4];
						Buffer.BlockCopy(array, 0, array3, 4, num4);
						num3 = 130;
						array3[2] = (byte)(num4 >> 8);
						array3[3] = (byte)num4;
					}
					else if (num4 <= 16777215)
					{
						array3 = new byte[5 + num4];
						Buffer.BlockCopy(array, 0, array3, 5, num4);
						num3 = 131;
						array3[2] = (byte)(num4 >> 16);
						array3[3] = (byte)(num4 >> 8);
						array3[4] = (byte)num4;
					}
					else
					{
						array3 = new byte[6 + num4];
						Buffer.BlockCopy(array, 0, array3, 6, num4);
						num3 = 132;
						array3[2] = (byte)(num4 >> 24);
						array3[3] = (byte)(num4 >> 16);
						array3[4] = (byte)(num4 >> 8);
						array3[5] = (byte)num4;
					}
				}
				else
				{
					array3 = new byte[2 + num4];
					Buffer.BlockCopy(array, 0, array3, 2, num4);
					num3 = num4;
				}
				if (m_aValue == null)
				{
					m_aValue = array;
				}
			}
			else
			{
				array3 = new byte[2];
			}
			array3[0] = m_nTag;
			array3[1] = (byte)num3;
			return array3;
		}

		protected void Decode(byte[] asn1, ref int anPos, int anLength)
		{
			while (anPos < anLength - 1)
			{
				DecodeTLV(asn1, ref anPos, out var tag, out var length, out var content);
				if (tag != 0)
				{
					ASN1 aSN = Add(new ASN1(tag, content));
					if ((tag & 0x20) == 32)
					{
						int anPos2 = anPos;
						aSN.Decode(asn1, ref anPos2, anPos2 + length);
					}
					anPos += length;
				}
			}
		}

		protected void DecodeTLV(byte[] asn1, ref int pos, out byte tag, out int length, out byte[] content)
		{
			tag = asn1[pos++];
			length = asn1[pos++];
			if ((length & 0x80) == 128)
			{
				int num = length & 0x7F;
				length = 0;
				for (int i = 0; i < num; i++)
				{
					length = length * 256 + asn1[pos++];
				}
			}
			content = new byte[length];
			Buffer.BlockCopy(asn1, pos, content, 0, length);
		}

		public ASN1 Element(int index, byte anTag)
		{
			try
			{
				if (elist == null || index >= elist.Count)
				{
					return null;
				}
				ASN1 aSN = (ASN1)elist[index];
				if (aSN.Tag == anTag)
				{
					return aSN;
				}
				return null;
			}
			catch (ArgumentOutOfRangeException)
			{
				return null;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Tag: {0} {1}", m_nTag.ToString("X2"), Environment.NewLine);
			stringBuilder.AppendFormat("Length: {0} {1}", Value.Length, Environment.NewLine);
			stringBuilder.Append("Value: ");
			stringBuilder.Append(Environment.NewLine);
			for (int i = 0; i < Value.Length; i++)
			{
				stringBuilder.AppendFormat("{0} ", Value[i].ToString("X2"));
				if ((i + 1) % 16 == 0)
				{
					stringBuilder.AppendFormat(Environment.NewLine);
				}
			}
			return stringBuilder.ToString();
		}
	}
	public static class ASN1Convert
	{
		public static ASN1 FromInt32(int value)
		{
			byte[] bytes = Mono.Security.BitConverterLE.GetBytes(value);
			Array.Reverse(bytes);
			int i;
			for (i = 0; i < bytes.Length && bytes[i] == 0; i++)
			{
			}
			ASN1 aSN = new ASN1(2);
			switch (i)
			{
			case 0:
				aSN.Value = bytes;
				break;
			case 4:
				aSN.Value = new byte[1];
				break;
			default:
			{
				byte[] array = new byte[4 - i];
				Buffer.BlockCopy(bytes, i, array, 0, array.Length);
				aSN.Value = array;
				break;
			}
			}
			return aSN;
		}

		public static ASN1 FromOid(string oid)
		{
			if (oid == null)
			{
				throw new ArgumentNullException("oid");
			}
			return new ASN1(CryptoConfig.EncodeOID(oid));
		}

		public static ASN1 FromUnsignedBigInteger(byte[] big)
		{
			if (big == null)
			{
				throw new ArgumentNullException("big");
			}
			if (big[0] >= 128)
			{
				int num = big.Length + 1;
				byte[] array = new byte[num];
				Buffer.BlockCopy(big, 0, array, 1, num - 1);
				big = array;
			}
			return new ASN1(2, big);
		}

		public static int ToInt32(ASN1 asn1)
		{
			if (asn1 == null)
			{
				throw new ArgumentNullException("asn1");
			}
			if (asn1.Tag != 2)
			{
				throw new FormatException("Only integer can be converted");
			}
			int num = 0;
			for (int i = 0; i < asn1.Value.Length; i++)
			{
				num = (num << 8) + asn1.Value[i];
			}
			return num;
		}

		public static string ToOid(ASN1 asn1)
		{
			if (asn1 == null)
			{
				throw new ArgumentNullException("asn1");
			}
			byte[] value = asn1.Value;
			StringBuilder stringBuilder = new StringBuilder();
			byte b = (byte)(value[0] / 40);
			byte b2 = (byte)(value[0] % 40);
			if (b > 2)
			{
				b2 += (byte)((b - 2) * 40);
				b = 2;
			}
			stringBuilder.Append(b.ToString(CultureInfo.InvariantCulture));
			stringBuilder.Append(".");
			stringBuilder.Append(b2.ToString(CultureInfo.InvariantCulture));
			ulong num = 0uL;
			for (b = 1; b < value.Length; b++)
			{
				num = (num << 7) | (byte)(value[b] & 0x7F);
				if ((value[b] & 0x80) != 128)
				{
					stringBuilder.Append(".");
					stringBuilder.Append(num.ToString(CultureInfo.InvariantCulture));
					num = 0uL;
				}
			}
			return stringBuilder.ToString();
		}

		public static DateTime ToDateTime(ASN1 time)
		{
			if (time == null)
			{
				throw new ArgumentNullException("time");
			}
			string text = Encoding.ASCII.GetString(time.Value);
			string format = null;
			switch (text.Length)
			{
			case 11:
				format = "yyMMddHHmmZ";
				break;
			case 13:
				text = ((Convert.ToInt16(text.Substring(0, 2), CultureInfo.InvariantCulture) < 50) ? ("20" + text) : ("19" + text));
				format = "yyyyMMddHHmmssZ";
				break;
			case 15:
				format = "yyyyMMddHHmmssZ";
				break;
			case 17:
			{
				string text2 = ((Convert.ToInt16(text.Substring(0, 2), CultureInfo.InvariantCulture) >= 50) ? "19" : "20");
				char c = ((text[12] == '+') ? '-' : '+');
				text = $"{text2}{text.Substring(0, 12)}{c}{text[13]}{text[14]}:{text[15]}{text[16]}";
				format = "yyyyMMddHHmmsszzz";
				break;
			}
			}
			return DateTime.ParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
		}
	}
	internal sealed class BitConverterLE
	{
		private unsafe static byte[] GetUIntBytes(byte* bytes)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return new byte[4]
				{
					bytes[3],
					bytes[2],
					bytes[1],
					*bytes
				};
			}
			return new byte[4]
			{
				*bytes,
				bytes[1],
				bytes[2],
				bytes[3]
			};
		}

		private unsafe static byte[] GetULongBytes(byte* bytes)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return new byte[8]
				{
					bytes[7],
					bytes[6],
					bytes[5],
					bytes[4],
					bytes[3],
					bytes[2],
					bytes[1],
					*bytes
				};
			}
			return new byte[8]
			{
				*bytes,
				bytes[1],
				bytes[2],
				bytes[3],
				bytes[4],
				bytes[5],
				bytes[6],
				bytes[7]
			};
		}

		internal unsafe static byte[] GetBytes(int value)
		{
			return GetUIntBytes((byte*)(&value));
		}

		internal unsafe static byte[] GetBytes(long value)
		{
			return GetULongBytes((byte*)(&value));
		}

		private unsafe static void UShortFromBytes(byte* dst, byte[] src, int startIndex)
		{
			if (BitConverter.IsLittleEndian)
			{
				*dst = src[startIndex];
				dst[1] = src[startIndex + 1];
			}
			else
			{
				*dst = src[startIndex + 1];
				dst[1] = src[startIndex];
			}
		}

		private unsafe static void UIntFromBytes(byte* dst, byte[] src, int startIndex)
		{
			if (BitConverter.IsLittleEndian)
			{
				*dst = src[startIndex];
				dst[1] = src[startIndex + 1];
				dst[2] = src[startIndex + 2];
				dst[3] = src[startIndex + 3];
			}
			else
			{
				*dst = src[startIndex + 3];
				dst[1] = src[startIndex + 2];
				dst[2] = src[startIndex + 1];
				dst[3] = src[startIndex];
			}
		}

		internal unsafe static int ToInt32(byte[] value, int startIndex)
		{
			int result = default(int);
			UIntFromBytes((byte*)(&result), value, startIndex);
			return result;
		}

		internal unsafe static ushort ToUInt16(byte[] value, int startIndex)
		{
			ushort result = default(ushort);
			UShortFromBytes((byte*)(&result), value, startIndex);
			return result;
		}

		internal unsafe static uint ToUInt32(byte[] value, int startIndex)
		{
			uint result = default(uint);
			UIntFromBytes((byte*)(&result), value, startIndex);
			return result;
		}
	}
	public sealed class PKCS7
	{
		public class ContentInfo
		{
			private string contentType;

			private ASN1 content;

			public ASN1 ASN1 => GetASN1();

			public ASN1 Content
			{
				get
				{
					return content;
				}
				set
				{
					content = value;
				}
			}

			public string ContentType
			{
				get
				{
					return contentType;
				}
				set
				{
					contentType = value;
				}
			}

			public ContentInfo()
			{
				content = new ASN1(160);
			}

			public ContentInfo(string oid)
				: this()
			{
				contentType = oid;
			}

			public ContentInfo(byte[] data)
				: this(new ASN1(data))
			{
			}

			public ContentInfo(ASN1 asn1)
			{
				if (asn1.Tag != 48 || (asn1.Count < 1 && asn1.Count > 2))
				{
					throw new ArgumentException("Invalid ASN1");
				}
				if (asn1[0].Tag != 6)
				{
					throw new ArgumentException("Invalid contentType");
				}
				contentType = ASN1Convert.ToOid(asn1[0]);
				if (asn1.Count > 1)
				{
					if (asn1[1].Tag != 160)
					{
						throw new ArgumentException("Invalid content");
					}
					content = asn1[1];
				}
			}

			internal ASN1 GetASN1()
			{
				ASN1 aSN = new ASN1(48);
				aSN.Add(ASN1Convert.FromOid(contentType));
				if (content != null && content.Count > 0)
				{
					aSN.Add(content);
				}
				return aSN;
			}
		}

		public class EncryptedData
		{
			private byte _version;

			private ContentInfo _content;

			private ContentInfo _encryptionAlgorithm;

			private byte[] _encrypted;

			public ContentInfo EncryptionAlgorithm => _encryptionAlgorithm;

			public byte[] EncryptedContent
			{
				get
				{
					if (_encrypted == null)
					{
						return null;
					}
					return (byte[])_encrypted.Clone();
				}
			}

			public EncryptedData()
			{
				_version = 0;
			}

			public EncryptedData(ASN1 asn1)
				: this()
			{
				if (asn1.Tag != 48 || asn1.Count < 2)
				{
					throw new ArgumentException("Invalid EncryptedData");
				}
				if (asn1[0].Tag != 2)
				{
					throw new ArgumentException("Invalid version");
				}
				_version = asn1[0].Value[0];
				ASN1 aSN = asn1[1];
				if (aSN.Tag != 48)
				{
					throw new ArgumentException("missing EncryptedContentInfo");
				}
				ASN1 aSN2 = aSN[0];
				if (aSN2.Tag != 6)
				{
					throw new ArgumentException("missing EncryptedContentInfo.ContentType");
				}
				_content = new ContentInfo(ASN1Convert.ToOid(aSN2));
				ASN1 aSN3 = aSN[1];
				if (aSN3.Tag != 48)
				{
					throw new ArgumentException("missing EncryptedContentInfo.ContentEncryptionAlgorithmIdentifier");
				}
				_encryptionAlgorithm = new ContentInfo(ASN1Convert.ToOid(aSN3[0]));
				_encryptionAlgorithm.Content = aSN3[1];
				ASN1 aSN4 = aSN[2];
				if (aSN4.Tag != 128)
				{
					throw new ArgumentException("missing EncryptedContentInfo.EncryptedContent");
				}
				_encrypted = aSN4.Value;
			}
		}

		public class SignedData
		{
			private byte version;

			private string hashAlgorithm;

			private ContentInfo contentInfo;

			private Mono.Security.X509.X509CertificateCollection certs;

			private ArrayList crls;

			private SignerInfo signerInfo;

			private bool mda;

			public Mono.Security.X509.X509CertificateCollection Certificates => certs;

			public ContentInfo ContentInfo => contentInfo;

			public string HashName
			{
				set
				{
					hashAlgorithm = value;
					signerInfo.HashName = value;
				}
			}

			public SignerInfo SignerInfo => signerInfo;

			public SignedData(ASN1 asn1)
			{
				if (asn1[0].Tag != 48 || asn1[0].Count < 4)
				{
					throw new ArgumentException("Invalid SignedData");
				}
				if (asn1[0][0].Tag != 2)
				{
					throw new ArgumentException("Invalid version");
				}
				version = asn1[0][0].Value[0];
				contentInfo = new ContentInfo(asn1[0][2]);
				int num = 3;
				certs = new Mono.Security.X509.X509CertificateCollection();
				if (asn1[0][num].Tag == 160)
				{
					for (int i = 0; i < asn1[0][num].Count; i++)
					{
						certs.Add(new Mono.Security.X509.X509Certificate(asn1[0][num][i].GetBytes()));
					}
					num++;
				}
				crls = new ArrayList();
				if (asn1[0][num].Tag == 161)
				{
					for (int j = 0; j < asn1[0][num].Count; j++)
					{
						crls.Add(asn1[0][num][j].GetBytes());
					}
					num++;
				}
				if (asn1[0][num].Count > 0)
				{
					signerInfo = new SignerInfo(asn1[0][num]);
				}
				else
				{
					signerInfo = new SignerInfo();
				}
				if (signerInfo.HashName != null)
				{
					HashName = OidToName(signerInfo.HashName);
				}
				mda = signerInfo.AuthenticatedAttributes.Count > 0;
			}

			internal string OidToName(string oid)
			{
				return oid switch
				{
					"1.3.14.3.2.26" => "SHA1", 
					"1.2.840.113549.2.2" => "MD2", 
					"1.2.840.113549.2.5" => "MD5", 
					"2.16.840.1.101.3.4.1" => "SHA256", 
					"2.16.840.1.101.3.4.2" => "SHA384", 
					"2.16.840.1.101.3.4.3" => "SHA512", 
					_ => oid, 
				};
			}
		}

		public class SignerInfo
		{
			private byte version;

			private string hashAlgorithm;

			private ArrayList authenticatedAttributes;

			private ArrayList unauthenticatedAttributes;

			private byte[] signature;

			private string issuer;

			private byte[] serial;

			private byte[] ski;

			public string IssuerName => issuer;

			public byte[] SerialNumber
			{
				get
				{
					if (serial == null)
					{
						return null;
					}
					return (byte[])serial.Clone();
				}
			}

			public ArrayList AuthenticatedAttributes => authenticatedAttributes;

			public string HashName
			{
				get
				{
					return hashAlgorithm;
				}
				set
				{
					hashAlgorithm = value;
				}
			}

			public byte[] Signature
			{
				get
				{
					if (signature == null)
					{
						return null;
					}
					return (byte[])signature.Clone();
				}
			}

			public ArrayList UnauthenticatedAttributes => unauthenticatedAttributes;

			public byte Version => version;

			public SignerInfo()
			{
				version = 1;
				authenticatedAttributes = new ArrayList();
				unauthenticatedAttributes = new ArrayList();
			}

			public SignerInfo(ASN1 asn1)
				: this()
			{
				if (asn1[0].Tag != 48 || asn1[0].Count < 5)
				{
					throw new ArgumentException("Invalid SignedData");
				}
				if (asn1[0][0].Tag != 2)
				{
					throw new ArgumentException("Invalid version");
				}
				version = asn1[0][0].Value[0];
				ASN1 aSN = asn1[0][1];
				if (aSN.Tag == 128 && version == 3)
				{
					ski = aSN.Value;
				}
				else
				{
					issuer = X501.ToString(aSN[0]);
					serial = aSN[1].Value;
				}
				ASN1 aSN2 = asn1[0][2];
				hashAlgorithm = ASN1Convert.ToOid(aSN2[0]);
				int num = 3;
				ASN1 aSN3 = asn1[0][num];
				if (aSN3.Tag == 160)
				{
					num++;
					for (int i = 0; i < aSN3.Count; i++)
					{
						authenticatedAttributes.Add(aSN3[i]);
					}
				}
				num++;
				ASN1 aSN4 = asn1[0][num++];
				if (aSN4.Tag == 4)
				{
					signature = aSN4.Value;
				}
				ASN1 aSN5 = asn1[0][num];
				if (aSN5 != null && aSN5.Tag == 161)
				{
					for (int j = 0; j < aSN5.Count; j++)
					{
						unauthenticatedAttributes.Add(aSN5[j]);
					}
				}
			}
		}
	}
}
namespace Mono.Security.X509
{
	internal class SafeBag
	{
		private string _bagOID;

		private ASN1 _asn1;

		public string BagOID => _bagOID;

		public ASN1 ASN1 => _asn1;

		public SafeBag(string bagOID, ASN1 asn1)
		{
			_bagOID = bagOID;
			_asn1 = asn1;
		}
	}
	public class PKCS12 : ICloneable
	{
		public class DeriveBytes
		{
			private static byte[] keyDiversifier = new byte[64]
			{
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
				1, 1, 1, 1
			};

			private static byte[] ivDiversifier = new byte[64]
			{
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2
			};

			private static byte[] macDiversifier = new byte[64]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3
			};

			private string _hashName;

			private int _iterations;

			private byte[] _password;

			private byte[] _salt;

			public string HashName
			{
				set
				{
					_hashName = value;
				}
			}

			public int IterationCount
			{
				set
				{
					_iterations = value;
				}
			}

			public byte[] Password
			{
				set
				{
					if (value == null)
					{
						_password = new byte[0];
					}
					else
					{
						_password = (byte[])value.Clone();
					}
				}
			}

			public byte[] Salt
			{
				set
				{
					if (value != null)
					{
						_salt = (byte[])value.Clone();
					}
					else
					{
						_salt = null;
					}
				}
			}

			private void Adjust(byte[] a, int aOff, byte[] b)
			{
				int num = (b[b.Length - 1] & 0xFF) + (a[aOff + b.Length - 1] & 0xFF) + 1;
				a[aOff + b.Length - 1] = (byte)num;
				num >>= 8;
				for (int num2 = b.Length - 2; num2 >= 0; num2--)
				{
					num += (b[num2] & 0xFF) + (a[aOff + num2] & 0xFF);
					a[aOff + num2] = (byte)num;
					num >>= 8;
				}
			}

			private byte[] Derive(byte[] diversifier, int n)
			{
				HashAlgorithm hashAlgorithm = PKCS1.CreateFromName(_hashName);
				int num = hashAlgorithm.HashSize >> 3;
				int num2 = 64;
				byte[] array = new byte[n];
				byte[] array2;
				if (_salt != null && _salt.Length != 0)
				{
					array2 = new byte[num2 * ((_salt.Length + num2 - 1) / num2)];
					for (int i = 0; i != array2.Length; i++)
					{
						array2[i] = _salt[i % _salt.Length];
					}
				}
				else
				{
					array2 = new byte[0];
				}
				byte[] array3;
				if (_password != null && _password.Length != 0)
				{
					array3 = new byte[num2 * ((_password.Length + num2 - 1) / num2)];
					for (int j = 0; j != array3.Length; j++)
					{
						array3[j] = _password[j % _password.Length];
					}
				}
				else
				{
					array3 = new byte[0];
				}
				byte[] array4 = new byte[array2.Length + array3.Length];
				Buffer.BlockCopy(array2, 0, array4, 0, array2.Length);
				Buffer.BlockCopy(array3, 0, array4, array2.Length, array3.Length);
				byte[] array5 = new byte[num2];
				int num3 = (n + num - 1) / num;
				for (int k = 1; k <= num3; k++)
				{
					hashAlgorithm.TransformBlock(diversifier, 0, diversifier.Length, diversifier, 0);
					hashAlgorithm.TransformFinalBlock(array4, 0, array4.Length);
					byte[] array6 = hashAlgorithm.Hash;
					hashAlgorithm.Initialize();
					for (int l = 1; l != _iterations; l++)
					{
						array6 = hashAlgorithm.ComputeHash(array6, 0, array6.Length);
					}
					for (int m = 0; m != array5.Length; m++)
					{
						array5[m] = array6[m % array6.Length];
					}
					for (int num4 = 0; num4 != array4.Length / num2; num4++)
					{
						Adjust(array4, num4 * num2, array5);
					}
					if (k == num3)
					{
						Buffer.BlockCopy(array6, 0, array, (k - 1) * num, array.Length - (k - 1) * num);
					}
					else
					{
						Buffer.BlockCopy(array6, 0, array, (k - 1) * num, array6.Length);
					}
				}
				return array;
			}

			public byte[] DeriveKey(int size)
			{
				return Derive(keyDiversifier, size);
			}

			public byte[] DeriveIV(int size)
			{
				return Derive(ivDiversifier, size);
			}

			public byte[] DeriveMAC(int size)
			{
				return Derive(macDiversifier, size);
			}
		}

		private byte[] _password;

		private ArrayList _keyBags;

		private ArrayList _secretBags;

		private X509CertificateCollection _certs;

		private bool _keyBagsChanged;

		private bool _secretBagsChanged;

		private bool _certsChanged;

		private int _iterations;

		private ArrayList _safeBags;

		private RandomNumberGenerator _rng;

		private static int password_max_length = 2147483647;

		public string Password
		{
			set
			{
				if (_password != null)
				{
					Array.Clear(_password, 0, _password.Length);
				}
				_password = null;
				if (value == null)
				{
					return;
				}
				if (value.Length > 0)
				{
					int num = value.Length;
					int num2 = 0;
					if (num < MaximumPasswordLength)
					{
						if (value[num - 1] != 0)
						{
							num2 = 1;
						}
					}
					else
					{
						num = MaximumPasswordLength;
					}
					_password = new byte[num + num2 << 1];
					Encoding.BigEndianUnicode.GetBytes(value, 0, num, _password, 0);
				}
				else
				{
					_password = new byte[2];
				}
			}
		}

		public int IterationCount
		{
			get
			{
				return _iterations;
			}
			set
			{
				_iterations = value;
			}
		}

		public ArrayList Keys
		{
			get
			{
				if (_keyBagsChanged)
				{
					_keyBags.Clear();
					foreach (SafeBag safeBag in _safeBags)
					{
						if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.1"))
						{
							byte[] privateKey = new PKCS8.PrivateKeyInfo(safeBag.ASN1[1].Value).PrivateKey;
							switch (privateKey[0])
							{
							case 2:
								_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeDSA(privateKey, default(DSAParameters)));
								break;
							case 48:
								_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeRSA(privateKey));
								break;
							}
							Array.Clear(privateKey, 0, privateKey.Length);
						}
						else if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.2"))
						{
							PKCS8.EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = new PKCS8.EncryptedPrivateKeyInfo(safeBag.ASN1[1].Value);
							byte[] array = Decrypt(encryptedPrivateKeyInfo.Algorithm, encryptedPrivateKeyInfo.Salt, encryptedPrivateKeyInfo.IterationCount, encryptedPrivateKeyInfo.EncryptedData);
							byte[] privateKey2 = new PKCS8.PrivateKeyInfo(array).PrivateKey;
							switch (privateKey2[0])
							{
							case 2:
								_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeDSA(privateKey2, default(DSAParameters)));
								break;
							case 48:
								_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeRSA(privateKey2));
								break;
							}
							Array.Clear(privateKey2, 0, privateKey2.Length);
							Array.Clear(array, 0, array.Length);
						}
					}
					_keyBagsChanged = false;
				}
				return ArrayList.ReadOnly(_keyBags);
			}
		}

		public X509CertificateCollection Certificates
		{
			get
			{
				if (_certsChanged)
				{
					_certs.Clear();
					foreach (SafeBag safeBag in _safeBags)
					{
						if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.3"))
						{
							PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo(safeBag.ASN1[1].Value);
							_certs.Add(new X509Certificate(contentInfo.Content[0].Value));
						}
					}
					_certsChanged = false;
				}
				return _certs;
			}
		}

		internal RandomNumberGenerator RNG
		{
			get
			{
				if (_rng == null)
				{
					_rng = RandomNumberGenerator.Create();
				}
				return _rng;
			}
		}

		public static int MaximumPasswordLength => password_max_length;

		public PKCS12()
		{
			_iterations = 2000;
			_keyBags = new ArrayList();
			_secretBags = new ArrayList();
			_certs = new X509CertificateCollection();
			_keyBagsChanged = false;
			_secretBagsChanged = false;
			_certsChanged = false;
			_safeBags = new ArrayList();
		}

		public PKCS12(byte[] data)
			: this()
		{
			Password = null;
			Decode(data);
		}

		public PKCS12(byte[] data, string password)
			: this()
		{
			Password = password;
			Decode(data);
		}

		private void Decode(byte[] data)
		{
			ASN1 aSN = new ASN1(data);
			if (aSN.Tag != 48)
			{
				throw new ArgumentException("invalid data");
			}
			if (aSN[0].Tag != 2)
			{
				throw new ArgumentException("invalid PFX version");
			}
			PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo(aSN[1]);
			if (contentInfo.ContentType != "1.2.840.113549.1.7.1")
			{
				throw new ArgumentException("invalid authenticated safe");
			}
			if (aSN.Count > 2)
			{
				ASN1 aSN2 = aSN[2];
				if (aSN2.Tag != 48)
				{
					throw new ArgumentException("invalid MAC");
				}
				ASN1 aSN3 = aSN2[0];
				if (aSN3.Tag != 48)
				{
					throw new ArgumentException("invalid MAC");
				}
				if (ASN1Convert.ToOid(aSN3[0][0]) != "1.3.14.3.2.26")
				{
					throw new ArgumentException("unsupported HMAC");
				}
				byte[] value = aSN3[1].Value;
				ASN1 aSN4 = aSN2[1];
				if (aSN4.Tag != 4)
				{
					throw new ArgumentException("missing MAC salt");
				}
				_iterations = 1;
				if (aSN2.Count > 2)
				{
					ASN1 aSN5 = aSN2[2];
					if (aSN5.Tag != 2)
					{
						throw new ArgumentException("invalid MAC iteration");
					}
					_iterations = ASN1Convert.ToInt32(aSN5);
				}
				byte[] value2 = contentInfo.Content[0].Value;
				byte[] actual = MAC(_password, aSN4.Value, _iterations, value2);
				if (!Compare(value, actual))
				{
					byte[] password = new byte[2];
					actual = MAC(password, aSN4.Value, _iterations, value2);
					if (!Compare(value, actual))
					{
						throw new CryptographicException("Invalid MAC - file may have been tampered with!");
					}
					_password = password;
				}
			}
			ASN1 aSN6 = new ASN1(contentInfo.Content[0].Value);
			for (int i = 0; i < aSN6.Count; i++)
			{
				PKCS7.ContentInfo contentInfo2 = new PKCS7.ContentInfo(aSN6[i]);
				switch (contentInfo2.ContentType)
				{
				case "1.2.840.113549.1.7.1":
				{
					ASN1 aSN8 = new ASN1(contentInfo2.Content[0].Value);
					for (int k = 0; k < aSN8.Count; k++)
					{
						ASN1 safeBag2 = aSN8[k];
						ReadSafeBag(safeBag2);
					}
					break;
				}
				case "1.2.840.113549.1.7.6":
				{
					PKCS7.EncryptedData ed = new PKCS7.EncryptedData(contentInfo2.Content[0]);
					ASN1 aSN7 = new ASN1(Decrypt(ed));
					for (int j = 0; j < aSN7.Count; j++)
					{
						ASN1 safeBag = aSN7[j];
						ReadSafeBag(safeBag);
					}
					break;
				}
				case "1.2.840.113549.1.7.3":
					throw new NotImplementedException("public key encrypted");
				default:
					throw new ArgumentException("unknown authenticatedSafe");
				}
			}
		}

		~PKCS12()
		{
			if (_password != null)
			{
				Array.Clear(_password, 0, _password.Length);
			}
			_password = null;
		}

		private bool Compare(byte[] expected, byte[] actual)
		{
			bool result = false;
			if (expected.Length == actual.Length)
			{
				for (int i = 0; i < expected.Length; i++)
				{
					if (expected[i] != actual[i])
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		private SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmOid, byte[] salt, int iterationCount)
		{
			string text = null;
			int size = 8;
			int num = 8;
			DeriveBytes deriveBytes = new DeriveBytes();
			deriveBytes.Password = _password;
			deriveBytes.Salt = salt;
			deriveBytes.IterationCount = iterationCount;
			switch (algorithmOid)
			{
			case "1.2.840.113549.1.5.1":
				deriveBytes.HashName = "MD2";
				text = "DES";
				break;
			case "1.2.840.113549.1.5.3":
				deriveBytes.HashName = "MD5";
				text = "DES";
				break;
			case "1.2.840.113549.1.5.4":
				deriveBytes.HashName = "MD2";
				text = "RC2";
				size = 4;
				break;
			case "1.2.840.113549.1.5.6":
				deriveBytes.HashName = "MD5";
				text = "RC2";
				size = 4;
				break;
			case "1.2.840.113549.1.5.10":
				deriveBytes.HashName = "SHA1";
				text = "DES";
				break;
			case "1.2.840.113549.1.5.11":
				deriveBytes.HashName = "SHA1";
				text = "RC2";
				size = 4;
				break;
			case "1.2.840.113549.1.12.1.1":
				deriveBytes.HashName = "SHA1";
				text = "RC4";
				size = 16;
				num = 0;
				break;
			case "1.2.840.113549.1.12.1.2":
				deriveBytes.HashName = "SHA1";
				text = "RC4";
				size = 5;
				num = 0;
				break;
			case "1.2.840.113549.1.12.1.3":
				deriveBytes.HashName = "SHA1";
				text = "TripleDES";
				size = 24;
				break;
			case "1.2.840.113549.1.12.1.4":
				deriveBytes.HashName = "SHA1";
				text = "TripleDES";
				size = 16;
				break;
			case "1.2.840.113549.1.12.1.5":
				deriveBytes.HashName = "SHA1";
				text = "RC2";
				size = 16;
				break;
			case "1.2.840.113549.1.12.1.6":
				deriveBytes.HashName = "SHA1";
				text = "RC2";
				size = 5;
				break;
			default:
				throw new NotSupportedException("unknown oid " + text);
			}
			SymmetricAlgorithm symmetricAlgorithm = null;
			symmetricAlgorithm = SymmetricAlgorithm.Create(text);
			symmetricAlgorithm.Key = deriveBytes.DeriveKey(size);
			if (num > 0)
			{
				symmetricAlgorithm.IV = deriveBytes.DeriveIV(num);
				symmetricAlgorithm.Mode = CipherMode.CBC;
			}
			return symmetricAlgorithm;
		}

		public byte[] Decrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] encryptedData)
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			byte[] array = null;
			try
			{
				symmetricAlgorithm = GetSymmetricAlgorithm(algorithmOid, salt, iterationCount);
				return symmetricAlgorithm.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
			}
			finally
			{
				symmetricAlgorithm?.Clear();
			}
		}

		public byte[] Decrypt(PKCS7.EncryptedData ed)
		{
			return Decrypt(ed.EncryptionAlgorithm.ContentType, ed.EncryptionAlgorithm.Content[0].Value, ASN1Convert.ToInt32(ed.EncryptionAlgorithm.Content[1]), ed.EncryptedContent);
		}

		public byte[] Encrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] data)
		{
			byte[] array = null;
			using SymmetricAlgorithm symmetricAlgorithm = GetSymmetricAlgorithm(algorithmOid, salt, iterationCount);
			return symmetricAlgorithm.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
		}

		private DSAParameters GetExistingParameters(out bool found)
		{
			foreach (X509Certificate certificate in Certificates)
			{
				if (certificate.KeyAlgorithmParameters != null)
				{
					DSA dSA = certificate.DSA;
					if (dSA != null)
					{
						found = true;
						return dSA.ExportParameters(includePrivateParameters: false);
					}
				}
			}
			found = false;
			return default(DSAParameters);
		}

		private void AddPrivateKey(PKCS8.PrivateKeyInfo pki)
		{
			byte[] privateKey = pki.PrivateKey;
			try
			{
				switch (pki.Algorithm)
				{
				case "1.2.840.113549.1.1.1":
					_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeRSA(privateKey));
					break;
				case "1.2.840.10040.4.1":
				{
					bool found;
					DSAParameters existingParameters = GetExistingParameters(out found);
					if (found)
					{
						_keyBags.Add(PKCS8.PrivateKeyInfo.DecodeDSA(privateKey, existingParameters));
					}
					break;
				}
				default:
					throw new CryptographicException("Unknown private key format");
				}
			}
			finally
			{
				Array.Clear(privateKey, 0, privateKey.Length);
			}
		}

		private void ReadSafeBag(ASN1 safeBag)
		{
			if (safeBag.Tag != 48)
			{
				throw new ArgumentException("invalid safeBag");
			}
			ASN1 aSN = safeBag[0];
			if (aSN.Tag != 6)
			{
				throw new ArgumentException("invalid safeBag id");
			}
			ASN1 aSN2 = safeBag[1];
			string text = ASN1Convert.ToOid(aSN);
			switch (text)
			{
			case "1.2.840.113549.1.12.10.1.1":
				AddPrivateKey(new PKCS8.PrivateKeyInfo(aSN2.Value));
				break;
			case "1.2.840.113549.1.12.10.1.2":
			{
				PKCS8.EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = new PKCS8.EncryptedPrivateKeyInfo(aSN2.Value);
				byte[] array = Decrypt(encryptedPrivateKeyInfo.Algorithm, encryptedPrivateKeyInfo.Salt, encryptedPrivateKeyInfo.IterationCount, encryptedPrivateKeyInfo.EncryptedData);
				AddPrivateKey(new PKCS8.PrivateKeyInfo(array));
				Array.Clear(array, 0, array.Length);
				break;
			}
			case "1.2.840.113549.1.12.10.1.3":
			{
				PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo(aSN2.Value);
				if (contentInfo.ContentType != "1.2.840.113549.1.9.22.1")
				{
					throw new NotSupportedException("unsupport certificate type");
				}
				X509Certificate value2 = new X509Certificate(contentInfo.Content[0].Value);
				_certs.Add(value2);
				break;
			}
			case "1.2.840.113549.1.12.10.1.5":
			{
				byte[] value = aSN2.Value;
				_secretBags.Add(value);
				break;
			}
			default:
				throw new ArgumentException("unknown safeBag oid");
			case "1.2.840.113549.1.12.10.1.4":
			case "1.2.840.113549.1.12.10.1.6":
				break;
			}
			if (safeBag.Count > 2)
			{
				ASN1 aSN3 = safeBag[2];
				if (aSN3.Tag != 49)
				{
					throw new ArgumentException("invalid safeBag attributes id");
				}
				for (int i = 0; i < aSN3.Count; i++)
				{
					ASN1 aSN4 = aSN3[i];
					if (aSN4.Tag != 48)
					{
						throw new ArgumentException("invalid PKCS12 attributes id");
					}
					ASN1 aSN5 = aSN4[0];
					if (aSN5.Tag != 6)
					{
						throw new ArgumentException("invalid attribute id");
					}
					string text2 = ASN1Convert.ToOid(aSN5);
					ASN1 aSN6 = aSN4[1];
					for (int j = 0; j < aSN6.Count; j++)
					{
						ASN1 aSN7 = aSN6[j];
						if (!(text2 == "1.2.840.113549.1.9.20"))
						{
							if (text2 == "1.2.840.113549.1.9.21" && aSN7.Tag != 4)
							{
								throw new ArgumentException("invalid attribute value id");
							}
						}
						else if (aSN7.Tag != 30)
						{
							throw new ArgumentException("invalid attribute value id");
						}
					}
				}
			}
			_safeBags.Add(new SafeBag(text, safeBag));
		}

		private ASN1 Pkcs8ShroudedKeyBagSafeBag(AsymmetricAlgorithm aa, IDictionary attributes)
		{
			PKCS8.PrivateKeyInfo privateKeyInfo = new PKCS8.PrivateKeyInfo();
			if (aa is RSA)
			{
				privateKeyInfo.Algorithm = "1.2.840.113549.1.1.1";
				privateKeyInfo.PrivateKey = PKCS8.PrivateKeyInfo.Encode((RSA)aa);
			}
			else
			{
				if (!(aa is DSA))
				{
					throw new CryptographicException("Unknown asymmetric algorithm {0}", aa.ToString());
				}
				privateKeyInfo.Algorithm = null;
				privateKeyInfo.PrivateKey = PKCS8.PrivateKeyInfo.Encode((DSA)aa);
			}
			PKCS8.EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = new PKCS8.EncryptedPrivateKeyInfo();
			encryptedPrivateKeyInfo.Algorithm = "1.2.840.113549.1.12.1.3";
			encryptedPrivateKeyInfo.IterationCount = _iterations;
			encryptedPrivateKeyInfo.EncryptedData = Encrypt("1.2.840.113549.1.12.1.3", encryptedPrivateKeyInfo.Salt, _iterations, privateKeyInfo.GetBytes());
			ASN1 aSN = new ASN1(48);
			aSN.Add(ASN1Convert.FromOid("1.2.840.113549.1.12.10.1.2"));
			ASN1 aSN2 = new ASN1(160);
			aSN2.Add(new ASN1(encryptedPrivateKeyInfo.GetBytes()));
			aSN.Add(aSN2);
			if (attributes != null)
			{
				ASN1 aSN3 = new ASN1(49);
				IDictionaryEnumerator enumerator = attributes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string text = (string)enumerator.Key;
					if (!(text == "1.2.840.113549.1.9.20"))
					{
						if (!(text == "1.2.840.113549.1.9.21"))
						{
							continue;
						}
						ArrayList arrayList = (ArrayList)enumerator.Value;
						if (arrayList.Count <= 0)
						{
							continue;
						}
						ASN1 aSN4 = new ASN1(48);
						aSN4.Add(ASN1Convert.FromOid("1.2.840.113549.1.9.21"));
						ASN1 aSN5 = new ASN1(49);
						foreach (byte[] item in arrayList)
						{
							ASN1 aSN6 = new ASN1(4);
							aSN6.Value = item;
							aSN5.Add(aSN6);
						}
						aSN4.Add(aSN5);
						aSN3.Add(aSN4);
						continue;
					}
					ArrayList arrayList2 = (ArrayList)enumerator.Value;
					if (arrayList2.Count <= 0)
					{
						continue;
					}
					ASN1 aSN7 = new ASN1(48);
					aSN7.Add(ASN1Convert.FromOid("1.2.840.113549.1.9.20"));
					ASN1 aSN8 = new ASN1(49);
					foreach (byte[] item2 in arrayList2)
					{
						ASN1 aSN9 = new ASN1(30);
						aSN9.Value = item2;
						aSN8.Add(aSN9);
					}
					aSN7.Add(aSN8);
					aSN3.Add(aSN7);
				}
				if (aSN3.Count > 0)
				{
					aSN.Add(aSN3);
				}
			}
			return aSN;
		}

		private ASN1 CertificateSafeBag(X509Certificate x509, IDictionary attributes)
		{
			ASN1 asn = new ASN1(4, x509.RawData);
			PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo();
			contentInfo.ContentType = "1.2.840.113549.1.9.22.1";
			contentInfo.Content.Add(asn);
			ASN1 aSN = new ASN1(160);
			aSN.Add(contentInfo.ASN1);
			ASN1 aSN2 = new ASN1(48);
			aSN2.Add(ASN1Convert.FromOid("1.2.840.113549.1.12.10.1.3"));
			aSN2.Add(aSN);
			if (attributes != null)
			{
				ASN1 aSN3 = new ASN1(49);
				IDictionaryEnumerator enumerator = attributes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string text = (string)enumerator.Key;
					if (!(text == "1.2.840.113549.1.9.20"))
					{
						if (!(text == "1.2.840.113549.1.9.21"))
						{
							continue;
						}
						ArrayList arrayList = (ArrayList)enumerator.Value;
						if (arrayList.Count <= 0)
						{
							continue;
						}
						ASN1 aSN4 = new ASN1(48);
						aSN4.Add(ASN1Convert.FromOid("1.2.840.113549.1.9.21"));
						ASN1 aSN5 = new ASN1(49);
						foreach (byte[] item in arrayList)
						{
							ASN1 aSN6 = new ASN1(4);
							aSN6.Value = item;
							aSN5.Add(aSN6);
						}
						aSN4.Add(aSN5);
						aSN3.Add(aSN4);
						continue;
					}
					ArrayList arrayList2 = (ArrayList)enumerator.Value;
					if (arrayList2.Count <= 0)
					{
						continue;
					}
					ASN1 aSN7 = new ASN1(48);
					aSN7.Add(ASN1Convert.FromOid("1.2.840.113549.1.9.20"));
					ASN1 aSN8 = new ASN1(49);
					foreach (byte[] item2 in arrayList2)
					{
						ASN1 aSN9 = new ASN1(30);
						aSN9.Value = item2;
						aSN8.Add(aSN9);
					}
					aSN7.Add(aSN8);
					aSN3.Add(aSN7);
				}
				if (aSN3.Count > 0)
				{
					aSN2.Add(aSN3);
				}
			}
			return aSN2;
		}

		private byte[] MAC(byte[] password, byte[] salt, int iterations, byte[] data)
		{
			DeriveBytes deriveBytes = new DeriveBytes();
			deriveBytes.HashName = "SHA1";
			deriveBytes.Password = password;
			deriveBytes.Salt = salt;
			deriveBytes.IterationCount = iterations;
			HMACSHA1 obj = (HMACSHA1)HMAC.Create();
			obj.Key = deriveBytes.DeriveMAC(20);
			return obj.ComputeHash(data, 0, data.Length);
		}

		public byte[] GetBytes()
		{
			ASN1 aSN = new ASN1(48);
			ArrayList arrayList = new ArrayList();
			foreach (SafeBag safeBag5 in _safeBags)
			{
				if (safeBag5.BagOID.Equals("1.2.840.113549.1.12.10.1.3"))
				{
					PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo(safeBag5.ASN1[1].Value);
					arrayList.Add(new X509Certificate(contentInfo.Content[0].Value));
				}
			}
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			foreach (X509Certificate certificate in Certificates)
			{
				bool flag = false;
				foreach (X509Certificate item in arrayList)
				{
					if (Compare(certificate.RawData, item.RawData))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					arrayList2.Add(certificate);
				}
			}
			foreach (X509Certificate item2 in arrayList)
			{
				bool flag2 = false;
				foreach (X509Certificate certificate2 in Certificates)
				{
					if (Compare(item2.RawData, certificate2.RawData))
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					arrayList3.Add(item2);
				}
			}
			foreach (X509Certificate item3 in arrayList3)
			{
				RemoveCertificate(item3);
			}
			foreach (X509Certificate item4 in arrayList2)
			{
				AddCertificate(item4);
			}
			if (_safeBags.Count > 0)
			{
				ASN1 aSN2 = new ASN1(48);
				foreach (SafeBag safeBag6 in _safeBags)
				{
					if (safeBag6.BagOID.Equals("1.2.840.113549.1.12.10.1.3"))
					{
						aSN2.Add(safeBag6.ASN1);
					}
				}
				if (aSN2.Count > 0)
				{
					PKCS7.ContentInfo contentInfo2 = EncryptedContentInfo(aSN2, "1.2.840.113549.1.12.1.3");
					aSN.Add(contentInfo2.ASN1);
				}
			}
			if (_safeBags.Count > 0)
			{
				ASN1 aSN3 = new ASN1(48);
				foreach (SafeBag safeBag7 in _safeBags)
				{
					if (safeBag7.BagOID.Equals("1.2.840.113549.1.12.10.1.1") || safeBag7.BagOID.Equals("1.2.840.113549.1.12.10.1.2"))
					{
						aSN3.Add(safeBag7.ASN1);
					}
				}
				if (aSN3.Count > 0)
				{
					ASN1 aSN4 = new ASN1(160);
					aSN4.Add(new ASN1(4, aSN3.GetBytes()));
					PKCS7.ContentInfo contentInfo3 = new PKCS7.ContentInfo("1.2.840.113549.1.7.1");
					contentInfo3.Content = aSN4;
					aSN.Add(contentInfo3.ASN1);
				}
			}
			if (_safeBags.Count > 0)
			{
				ASN1 aSN5 = new ASN1(48);
				foreach (SafeBag safeBag8 in _safeBags)
				{
					if (safeBag8.BagOID.Equals("1.2.840.113549.1.12.10.1.5"))
					{
						aSN5.Add(safeBag8.ASN1);
					}
				}
				if (aSN5.Count > 0)
				{
					PKCS7.ContentInfo contentInfo4 = EncryptedContentInfo(aSN5, "1.2.840.113549.1.12.1.3");
					aSN.Add(contentInfo4.ASN1);
				}
			}
			ASN1 asn = new ASN1(4, aSN.GetBytes());
			ASN1 aSN6 = new ASN1(160);
			aSN6.Add(asn);
			PKCS7.ContentInfo contentInfo5 = new PKCS7.ContentInfo("1.2.840.113549.1.7.1");
			contentInfo5.Content = aSN6;
			ASN1 aSN7 = new ASN1(48);
			if (_password != null)
			{
				byte[] array = new byte[20];
				RNG.GetBytes(array);
				byte[] data = MAC(_password, array, _iterations, contentInfo5.Content[0].Value);
				ASN1 aSN8 = new ASN1(48);
				aSN8.Add(ASN1Convert.FromOid("1.3.14.3.2.26"));
				aSN8.Add(new ASN1(5));
				ASN1 aSN9 = new ASN1(48);
				aSN9.Add(aSN8);
				aSN9.Add(new ASN1(4, data));
				aSN7.Add(aSN9);
				aSN7.Add(new ASN1(4, array));
				aSN7.Add(ASN1Convert.FromInt32(_iterations));
			}
			ASN1 asn2 = new ASN1(2, new byte[1] { 3 });
			ASN1 aSN10 = new ASN1(48);
			aSN10.Add(asn2);
			aSN10.Add(contentInfo5.ASN1);
			if (aSN7.Count > 0)
			{
				aSN10.Add(aSN7);
			}
			return aSN10.GetBytes();
		}

		private PKCS7.ContentInfo EncryptedContentInfo(ASN1 safeBags, string algorithmOid)
		{
			byte[] array = new byte[8];
			RNG.GetBytes(array);
			ASN1 aSN = new ASN1(48);
			aSN.Add(new ASN1(4, array));
			aSN.Add(ASN1Convert.FromInt32(_iterations));
			ASN1 aSN2 = new ASN1(48);
			aSN2.Add(ASN1Convert.FromOid(algorithmOid));
			aSN2.Add(aSN);
			byte[] data = Encrypt(algorithmOid, array, _iterations, safeBags.GetBytes());
			ASN1 asn = new ASN1(128, data);
			ASN1 aSN3 = new ASN1(48);
			aSN3.Add(ASN1Convert.FromOid("1.2.840.113549.1.7.1"));
			aSN3.Add(aSN2);
			aSN3.Add(asn);
			ASN1 asn2 = new ASN1(2, new byte[1]);
			ASN1 aSN4 = new ASN1(48);
			aSN4.Add(asn2);
			aSN4.Add(aSN3);
			ASN1 aSN5 = new ASN1(160);
			aSN5.Add(aSN4);
			return new PKCS7.ContentInfo("1.2.840.113549.1.7.6")
			{
				Content = aSN5
			};
		}

		public void AddCertificate(X509Certificate cert)
		{
			AddCertificate(cert, null);
		}

		public void AddCertificate(X509Certificate cert, IDictionary attributes)
		{
			bool flag = false;
			int num = 0;
			while (!flag && num < _safeBags.Count)
			{
				SafeBag safeBag = (SafeBag)_safeBags[num];
				if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.3"))
				{
					X509Certificate x509Certificate = new X509Certificate(new PKCS7.ContentInfo(safeBag.ASN1[1].Value).Content[0].Value);
					if (Compare(cert.RawData, x509Certificate.RawData))
					{
						flag = true;
					}
				}
				num++;
			}
			if (!flag)
			{
				_safeBags.Add(new SafeBag("1.2.840.113549.1.12.10.1.3", CertificateSafeBag(cert, attributes)));
				_certsChanged = true;
			}
		}

		public void RemoveCertificate(X509Certificate cert)
		{
			RemoveCertificate(cert, null);
		}

		public void RemoveCertificate(X509Certificate cert, IDictionary attrs)
		{
			int num = -1;
			int num2 = 0;
			while (num == -1 && num2 < _safeBags.Count)
			{
				SafeBag safeBag = (SafeBag)_safeBags[num2];
				if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.3"))
				{
					ASN1 aSN = safeBag.ASN1;
					X509Certificate x509Certificate = new X509Certificate(new PKCS7.ContentInfo(aSN[1].Value).Content[0].Value);
					if (Compare(cert.RawData, x509Certificate.RawData))
					{
						if (attrs != null)
						{
							if (aSN.Count == 3)
							{
								ASN1 aSN2 = aSN[2];
								int num3 = 0;
								for (int i = 0; i < aSN2.Count; i++)
								{
									ASN1 aSN3 = aSN2[i];
									string key = ASN1Convert.ToOid(aSN3[0]);
									ArrayList arrayList = (ArrayList)attrs[key];
									if (arrayList == null)
									{
										continue;
									}
									ASN1 aSN4 = aSN3[1];
									if (arrayList.Count != aSN4.Count)
									{
										continue;
									}
									int num4 = 0;
									for (int j = 0; j < aSN4.Count; j++)
									{
										ASN1 aSN5 = aSN4[j];
										byte[] expected = (byte[])arrayList[j];
										if (Compare(expected, aSN5.Value))
										{
											num4++;
										}
									}
									if (num4 == aSN4.Count)
									{
										num3++;
									}
								}
								if (num3 == aSN2.Count)
								{
									num = num2;
								}
							}
						}
						else
						{
							num = num2;
						}
					}
				}
				num2++;
			}
			if (num != -1)
			{
				_safeBags.RemoveAt(num);
				_certsChanged = true;
			}
		}

		private bool CompareAsymmetricAlgorithm(AsymmetricAlgorithm a1, AsymmetricAlgorithm a2)
		{
			if (a1.KeySize != a2.KeySize)
			{
				return false;
			}
			return a1.ToXmlString(includePrivateParameters: false) == a2.ToXmlString(includePrivateParameters: false);
		}

		public void AddPkcs8ShroudedKeyBag(AsymmetricAlgorithm aa, IDictionary attributes)
		{
			bool flag = false;
			int num = 0;
			while (!flag && num < _safeBags.Count)
			{
				SafeBag safeBag = (SafeBag)_safeBags[num];
				if (safeBag.BagOID.Equals("1.2.840.113549.1.12.10.1.2"))
				{
					PKCS8.EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = new PKCS8.EncryptedPrivateKeyInfo(safeBag.ASN1[1].Value);
					byte[] array = Decrypt(encryptedPrivateKeyInfo.Algorithm, encryptedPrivateKeyInfo.Salt, encryptedPrivateKeyInfo.IterationCount, encryptedPrivateKeyInfo.EncryptedData);
					byte[] privateKey = new PKCS8.PrivateKeyInfo(array).PrivateKey;
					AsymmetricAlgorithm asymmetricAlgorithm = null;
					switch (privateKey[0])
					{
					case 2:
						asymmetricAlgorithm = PKCS8.PrivateKeyInfo.DecodeDSA(privateKey, default(DSAParameters));
						break;
					case 48:
						asymmetricAlgorithm = PKCS8.PrivateKeyInfo.DecodeRSA(privateKey);
						break;
					default:
						Array.Clear(array, 0, array.Length);
						Array.Clear(privateKey, 0, privateKey.Length);
						throw new CryptographicException("Unknown private key format");
					}
					Array.Clear(array, 0, array.Length);
					Array.Clear(privateKey, 0, privateKey.Length);
					if (CompareAsymmetricAlgorithm(aa, asymmetricAlgorithm))
					{
						flag = true;
					}
				}
				num++;
			}
			if (!flag)
			{
				_safeBags.Add(new SafeBag("1.2.840.113549.1.12.10.1.2", Pkcs8ShroudedKeyBagSafeBag(aa, attributes)));
				_keyBagsChanged = true;
			}
		}

		public object Clone()
		{
			PKCS12 pKCS = null;
			pKCS = ((_password == null) ? new PKCS12(GetBytes()) : new PKCS12(GetBytes(), Encoding.BigEndianUnicode.GetString(_password)));
			pKCS.IterationCount = IterationCount;
			return pKCS;
		}
	}
	public sealed class X501
	{
		private static byte[] countryName = new byte[3] { 85, 4, 6 };

		private static byte[] organizationName = new byte[3] { 85, 4, 10 };

		private static byte[] organizationalUnitName = new byte[3] { 85, 4, 11 };

		private static byte[] commonName = new byte[3] { 85, 4, 3 };

		private static byte[] localityName = new byte[3] { 85, 4, 7 };

		private static byte[] stateOrProvinceName = new byte[3] { 85, 4, 8 };

		private static byte[] streetAddress = new byte[3] { 85, 4, 9 };

		private static byte[] serialNumber = new byte[3] { 85, 4, 5 };

		private static byte[] domainComponent = new byte[10] { 9, 146, 38, 137, 147, 242, 44, 100, 1, 25 };

		private static byte[] userid = new byte[10] { 9, 146, 38, 137, 147, 242, 44, 100, 1, 1 };

		private static byte[] email = new byte[9] { 42, 134, 72, 134, 247, 13, 1, 9, 1 };

		private static byte[] dnQualifier = new byte[3] { 85, 4, 46 };

		private static byte[] title = new byte[3] { 85, 4, 12 };

		private static byte[] surname = new byte[3] { 85, 4, 4 };

		private static byte[] givenName = new byte[3] { 85, 4, 42 };

		private static byte[] initial = new byte[3] { 85, 4, 43 };

		public static string ToString(ASN1 seq)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < seq.Count; i++)
			{
				ASN1 entry = seq[i];
				AppendEntry(stringBuilder, entry, quotes: true);
				if (i < seq.Count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			return stringBuilder.ToString();
		}

		public static string ToString(ASN1 seq, bool reversed, string separator, bool quotes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (reversed)
			{
				for (int num = seq.Count - 1; num >= 0; num--)
				{
					ASN1 entry = seq[num];
					AppendEntry(stringBuilder, entry, quotes);
					if (num > 0)
					{
						stringBuilder.Append(separator);
					}
				}
			}
			else
			{
				for (int i = 0; i < seq.Count; i++)
				{
					ASN1 entry2 = seq[i];
					AppendEntry(stringBuilder, entry2, quotes);
					if (i < seq.Count - 1)
					{
						stringBuilder.Append(separator);
					}
				}
			}
			return stringBuilder.ToString();
		}

		private static void AppendEntry(StringBuilder sb, ASN1 entry, bool quotes)
		{
			for (int i = 0; i < entry.Count; i++)
			{
				ASN1 aSN = entry[i];
				ASN1 aSN2 = aSN[1];
				if (aSN2 == null)
				{
					continue;
				}
				ASN1 aSN3 = aSN[0];
				if (aSN3 == null)
				{
					continue;
				}
				if (aSN3.CompareValue(countryName))
				{
					sb.Append("C=");
				}
				else if (aSN3.CompareValue(organizationName))
				{
					sb.Append("O=");
				}
				else if (aSN3.CompareValue(organizationalUnitName))
				{
					sb.Append("OU=");
				}
				else if (aSN3.CompareValue(commonName))
				{
					sb.Append("CN=");
				}
				else if (aSN3.CompareValue(localityName))
				{
					sb.Append("L=");
				}
				else if (aSN3.CompareValue(stateOrProvinceName))
				{
					sb.Append("S=");
				}
				else if (aSN3.CompareValue(streetAddress))
				{
					sb.Append("STREET=");
				}
				else if (aSN3.CompareValue(domainComponent))
				{
					sb.Append("DC=");
				}
				else if (aSN3.CompareValue(userid))
				{
					sb.Append("UID=");
				}
				else if (aSN3.CompareValue(email))
				{
					sb.Append("E=");
				}
				else if (aSN3.CompareValue(dnQualifier))
				{
					sb.Append("dnQualifier=");
				}
				else if (aSN3.CompareValue(title))
				{
					sb.Append("T=");
				}
				else if (aSN3.CompareValue(surname))
				{
					sb.Append("SN=");
				}
				else if (aSN3.CompareValue(givenName))
				{
					sb.Append("G=");
				}
				else if (aSN3.CompareValue(initial))
				{
					sb.Append("I=");
				}
				else if (aSN3.CompareValue(serialNumber))
				{
					sb.Append("SERIALNUMBER=");
				}
				else
				{
					sb.Append("OID.");
					sb.Append(ASN1Convert.ToOid(aSN3));
					sb.Append("=");
				}
				string text = null;
				if (aSN2.Tag != 30)
				{
					text = ((aSN2.Tag != 20) ? Encoding.UTF8.GetString(aSN2.Value) : Encoding.UTF7.GetString(aSN2.Value));
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int j = 1; j < aSN2.Value.Length; j += 2)
					{
						stringBuilder.Append((char)aSN2.Value[j]);
					}
					text = stringBuilder.ToString();
				}
				char[] anyOf = new char[9] { ',', '+', '"', '=', '<', '>', ';', '#', '\n' };
				if (quotes && (text.IndexOfAny(anyOf, 0, text.Length) > 0 || text.StartsWith(" ") || text.EndsWith(" ")))
				{
					text = "\"" + text.Replace("\"", "") + "\"";
				}
				sb.Append(text);
				if (i < entry.Count - 1)
				{
					sb.Append(", ");
				}
			}
		}

		private static X520.AttributeTypeAndValue GetAttributeFromOid(string attributeType)
		{
			string text = attributeType.ToUpper(CultureInfo.InvariantCulture).Trim();
			switch (text)
			{
			case "C":
				return new X520.CountryName();
			case "O":
				return new X520.OrganizationName();
			case "OU":
				return new X520.OrganizationalUnitName();
			case "CN":
				return new X520.CommonName();
			case "L":
				return new X520.LocalityName();
			case "S":
			case "ST":
				return new X520.StateOrProvinceName();
			case "E":
				return new X520.EmailAddress();
			case "DC":
				return new X520.DomainComponent();
			case "UID":
				return new X520.UserId();
			case "DNQUALIFIER":
				return new X520.DnQualifier();
			case "T":
				return new X520.Title();
			case "SN":
				return new X520.Surname();
			case "G":
				return new X520.GivenName();
			case "I":
				return new X520.Initial();
			case "SERIALNUMBER":
				return new X520.SerialNumber();
			default:
				if (text.StartsWith("OID."))
				{
					return new X520.Oid(text.Substring(4));
				}
				if (IsOid(text))
				{
					return new X520.Oid(text);
				}
				return null;
			}
		}

		private static bool IsOid(string oid)
		{
			try
			{
				return ASN1Convert.FromOid(oid).Tag == 6;
			}
			catch
			{
				return false;
			}
		}

		private static X520.AttributeTypeAndValue ReadAttribute(string value, ref int pos)
		{
			while (value[pos] == ' ' && pos < value.Length)
			{
				pos++;
			}
			int num = value.IndexOf('=', pos);
			if (num == -1)
			{
				throw new FormatException(global::Locale.GetText("No attribute found."));
			}
			string text = value.Substring(pos, num - pos);
			X520.AttributeTypeAndValue result = GetAttributeFromOid(text) ?? throw new FormatException(string.Format(global::Locale.GetText("Unknown attribute '{0}'."), text));
			pos = num + 1;
			return result;
		}

		private static bool IsHex(char c)
		{
			if (char.IsDigit(c))
			{
				return true;
			}
			char c2 = char.ToUpper(c, CultureInfo.InvariantCulture);
			if (c2 >= 'A')
			{
				return c2 <= 'F';
			}
			return false;
		}

		private static string ReadHex(string value, ref int pos)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(value[pos++]);
			stringBuilder.Append(value[pos]);
			if (pos < value.Length - 4 && value[pos + 1] == '\\' && IsHex(value[pos + 2]))
			{
				pos += 2;
				stringBuilder.Append(value[pos++]);
				stringBuilder.Append(value[pos]);
			}
			byte[] bytes = CryptoConvert.FromHex(stringBuilder.ToString());
			return Encoding.UTF8.GetString(bytes);
		}

		private static int ReadEscaped(StringBuilder sb, string value, int pos)
		{
			switch (value[pos])
			{
			case '"':
			case '#':
			case '+':
			case ',':
			case ';':
			case '<':
			case '=':
			case '>':
			case '\\':
				sb.Append(value[pos]);
				return pos;
			default:
				if (pos >= value.Length - 2)
				{
					throw new FormatException(string.Format(global::Locale.GetText("Malformed escaped value '{0}'."), value.Substring(pos)));
				}
				sb.Append(ReadHex(value, ref pos));
				return pos;
			}
		}

		private static int ReadQuoted(StringBuilder sb, string value, int pos)
		{
			int startIndex = pos;
			while (pos <= value.Length)
			{
				switch (value[pos])
				{
				case '"':
					return pos;
				case '\\':
					return ReadEscaped(sb, value, pos);
				}
				sb.Append(value[pos]);
				pos++;
			}
			throw new FormatException(string.Format(global::Locale.GetText("Malformed quoted value '{0}'."), value.Substring(startIndex)));
		}

		private static string ReadValue(string value, ref int pos)
		{
			int startIndex = pos;
			StringBuilder stringBuilder = new StringBuilder();
			while (pos < value.Length)
			{
				switch (value[pos])
				{
				case '\\':
					pos = ReadEscaped(stringBuilder, value, ++pos);
					break;
				case '"':
					pos = ReadQuoted(stringBuilder, value, ++pos);
					break;
				case ';':
				case '<':
				case '=':
				case '>':
					throw new FormatException(string.Format(global::Locale.GetText("Malformed value '{0}' contains '{1}' outside quotes."), value.Substring(startIndex), value[pos]));
				case '#':
				case '+':
					throw new NotImplementedException();
				case ',':
					pos++;
					return stringBuilder.ToString();
				default:
					stringBuilder.Append(value[pos]);
					break;
				}
				pos++;
			}
			return stringBuilder.ToString();
		}

		public static ASN1 FromString(string rdn)
		{
			if (rdn == null)
			{
				throw new ArgumentNullException("rdn");
			}
			int pos = 0;
			ASN1 aSN = new ASN1(48);
			while (pos < rdn.Length)
			{
				X520.AttributeTypeAndValue attributeTypeAndValue = ReadAttribute(rdn, ref pos);
				attributeTypeAndValue.Value = ReadValue(rdn, ref pos);
				ASN1 aSN2 = new ASN1(49);
				aSN2.Add(attributeTypeAndValue.GetASN1());
				aSN.Add(aSN2);
			}
			return aSN;
		}
	}
	[DefaultMember("Item")]
	public class X509Crl
	{
		public class X509CrlEntry
		{
			private byte[] sn;

			private DateTime revocationDate;

			private X509ExtensionCollection extensions;

			public byte[] SerialNumber => (byte[])sn.Clone();

			public DateTime RevocationDate => revocationDate;

			public X509ExtensionCollection Extensions => extensions;

			internal X509CrlEntry(ASN1 entry)
			{
				sn = entry[0].Value;
				Array.Reverse(sn);
				revocationDate = ASN1Convert.ToDateTime(entry[1]);
				extensions = new X509ExtensionCollection(entry[2]);
			}
		}

		private string issuer;

		private byte version;

		private DateTime thisUpdate;

		private DateTime nextUpdate;

		private ArrayList entries;

		private string signatureOID;

		private byte[] signature;

		private X509ExtensionCollection extensions;

		private byte[] encoded;

		private byte[] hash_value;

		public X509ExtensionCollection Extensions => extensions;

		public byte[] Hash
		{
			get
			{
				if (hash_value == null)
				{
					byte[] bytes = new ASN1(encoded)[0].GetBytes();
					using HashAlgorithm hashAlgorithm = PKCS1.CreateFromOid(signatureOID);
					hash_value = hashAlgorithm.ComputeHash(bytes);
				}
				return hash_value;
			}
		}

		public string IssuerName => issuer;

		public DateTime NextUpdate => nextUpdate;

		public X509Crl(byte[] crl)
		{
			if (crl == null)
			{
				throw new ArgumentNullException("crl");
			}
			encoded = (byte[])crl.Clone();
			Parse(encoded);
		}

		private void Parse(byte[] crl)
		{
			string text = "Input data cannot be coded as a valid CRL.";
			try
			{
				ASN1 aSN = new ASN1(encoded);
				if (aSN.Tag != 48 || aSN.Count != 3)
				{
					throw new CryptographicException(text);
				}
				ASN1 aSN2 = aSN[0];
				if (aSN2.Tag != 48 || aSN2.Count < 3)
				{
					throw new CryptographicException(text);
				}
				int num = 0;
				if (aSN2[num].Tag == 2)
				{
					version = (byte)(aSN2[num++].Value[0] + 1);
				}
				else
				{
					version = 1;
				}
				signatureOID = ASN1Convert.ToOid(aSN2[num++][0]);
				issuer = X501.ToString(aSN2[num++]);
				thisUpdate = ASN1Convert.ToDateTime(aSN2[num++]);
				ASN1 aSN3 = aSN2[num++];
				if (aSN3.Tag == 23 || aSN3.Tag == 24)
				{
					nextUpdate = ASN1Convert.ToDateTime(aSN3);
					aSN3 = aSN2[num++];
				}
				entries = new ArrayList();
				if (aSN3 != null && aSN3.Tag == 48)
				{
					ASN1 aSN4 = aSN3;
					for (int i = 0; i < aSN4.Count; i++)
					{
						entries.Add(new X509CrlEntry(aSN4[i]));
					}
				}
				else
				{
					num--;
				}
				ASN1 aSN5 = aSN2[num];
				if (aSN5 != null && aSN5.Tag == 160 && aSN5.Count == 1)
				{
					extensions = new X509ExtensionCollection(aSN5[0]);
				}
				else
				{
					extensions = new X509ExtensionCollection(null);
				}
				string text2 = ASN1Convert.ToOid(aSN[1][0]);
				if (signatureOID != text2)
				{
					throw new CryptographicException(text + " [Non-matching signature algorithms in CRL]");
				}
				byte[] value = aSN[2].Value;
				signature = new byte[value.Length - 1];
				Buffer.BlockCopy(value, 1, signature, 0, signature.Length);
			}
			catch
			{
				throw new CryptographicException(text);
			}
		}

		private bool Compare(byte[] array1, byte[] array2)
		{
			if (array1 == null && array2 == null)
			{
				return true;
			}
			if (array1 == null || array2 == null)
			{
				return false;
			}
			if (array1.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}

		public X509CrlEntry GetCrlEntry(X509Certificate x509)
		{
			if (x509 == null)
			{
				throw new ArgumentNullException("x509");
			}
			return GetCrlEntry(x509.SerialNumber);
		}

		public X509CrlEntry GetCrlEntry(byte[] serialNumber)
		{
			if (serialNumber == null)
			{
				throw new ArgumentNullException("serialNumber");
			}
			for (int i = 0; i < entries.Count; i++)
			{
				X509CrlEntry x509CrlEntry = (X509CrlEntry)entries[i];
				if (Compare(serialNumber, x509CrlEntry.SerialNumber))
				{
					return x509CrlEntry;
				}
			}
			return null;
		}

		internal bool VerifySignature(DSA dsa)
		{
			if (signatureOID != "1.2.840.10040.4.3")
			{
				throw new CryptographicException("Unsupported hash algorithm: " + signatureOID);
			}
			DSASignatureDeformatter dSASignatureDeformatter = new DSASignatureDeformatter(dsa);
			dSASignatureDeformatter.SetHashAlgorithm("SHA1");
			ASN1 aSN = new ASN1(signature);
			if (aSN == null || aSN.Count != 2)
			{
				return false;
			}
			byte[] value = aSN[0].Value;
			byte[] value2 = aSN[1].Value;
			byte[] array = new byte[40];
			int num = System.Math.Max(0, value.Length - 20);
			int dstOffset = System.Math.Max(0, 20 - value.Length);
			Buffer.BlockCopy(value, num, array, dstOffset, value.Length - num);
			int num2 = System.Math.Max(0, value2.Length - 20);
			int dstOffset2 = System.Math.Max(20, 40 - value2.Length);
			Buffer.BlockCopy(value2, num2, array, dstOffset2, value2.Length - num2);
			return dSASignatureDeformatter.VerifySignature(Hash, array);
		}

		internal bool VerifySignature(RSA rsa)
		{
			RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
			rSAPKCS1SignatureDeformatter.SetHashAlgorithm(PKCS1.HashNameFromOid(signatureOID));
			return rSAPKCS1SignatureDeformatter.VerifySignature(Hash, signature);
		}

		public bool VerifySignature(AsymmetricAlgorithm aa)
		{
			if (aa == null)
			{
				throw new ArgumentNullException("aa");
			}
			if (aa is RSA)
			{
				return VerifySignature(aa as RSA);
			}
			if (aa is DSA)
			{
				return VerifySignature(aa as DSA);
			}
			throw new NotSupportedException("Unknown Asymmetric Algorithm " + aa.ToString());
		}
	}
	public class X509Certificate : ISerializable
	{
		private ASN1 decoder;

		private byte[] m_encodedcert;

		private DateTime m_from;

		private DateTime m_until;

		private ASN1 issuer;

		private string m_issuername;

		private string m_keyalgo;

		private byte[] m_keyalgoparams;

		private ASN1 subject;

		private string m_subject;

		private byte[] m_publickey;

		private byte[] signature;

		private string m_signaturealgo;

		private byte[] m_signaturealgoparams;

		private byte[] certhash;

		private RSA _rsa;

		private DSA _dsa;

		private int version;

		private byte[] serialnumber;

		private byte[] issuerUniqueID;

		private byte[] subjectUniqueID;

		private X509ExtensionCollection extensions;

		private static string encoding_error = global::Locale.GetText("Input data cannot be coded as a valid certificate.");

		public DSA DSA
		{
			get
			{
				if (m_keyalgoparams == null)
				{
					throw new CryptographicException("Missing key algorithm parameters.");
				}
				if (_dsa == null && m_keyalgo == "1.2.840.10040.4.1")
				{
					DSAParameters parameters = default(DSAParameters);
					ASN1 aSN = new ASN1(m_publickey);
					if (aSN == null || aSN.Tag != 2)
					{
						return null;
					}
					parameters.Y = GetUnsignedBigInteger(aSN.Value);
					ASN1 aSN2 = new ASN1(m_keyalgoparams);
					if (aSN2 == null || aSN2.Tag != 48 || aSN2.Count < 3)
					{
						return null;
					}
					if (aSN2[0].Tag != 2 || aSN2[1].Tag != 2 || aSN2[2].Tag != 2)
					{
						return null;
					}
					parameters.P = GetUnsignedBigInteger(aSN2[0].Value);
					parameters.Q = GetUnsignedBigInteger(aSN2[1].Value);
					parameters.G = GetUnsignedBigInteger(aSN2[2].Value);
					_dsa = new DSACryptoServiceProvider(parameters.Y.Length << 3);
					_dsa.ImportParameters(parameters);
				}
				return _dsa;
			}
			set
			{
				_dsa = value;
				if (value != null)
				{
					_rsa = null;
				}
			}
		}

		public X509ExtensionCollection Extensions => extensions;

		public byte[] Hash
		{
			get
			{
				if (certhash == null)
				{
					if (decoder == null || decoder.Count < 1)
					{
						return null;
					}
					string text = PKCS1.HashNameFromOid(m_signaturealgo, throwOnError: false);
					if (text == null)
					{
						return null;
					}
					byte[] bytes = decoder[0].GetBytes();
					using HashAlgorithm hashAlgorithm = PKCS1.CreateFromName(text);
					certhash = hashAlgorithm.ComputeHash(bytes, 0, bytes.Length);
				}
				return (byte[])certhash.Clone();
			}
		}

		public virtual string IssuerName => m_issuername;

		public virtual string KeyAlgorithm => m_keyalgo;

		public virtual byte[] KeyAlgorithmParameters
		{
			get
			{
				if (m_keyalgoparams == null)
				{
					return null;
				}
				return (byte[])m_keyalgoparams.Clone();
			}
			set
			{
				m_keyalgoparams = value;
			}
		}

		public virtual byte[] PublicKey
		{
			get
			{
				if (m_publickey == null)
				{
					return null;
				}
				return (byte[])m_publickey.Clone();
			}
		}

		public virtual RSA RSA
		{
			get
			{
				if (_rsa == null && m_keyalgo == "1.2.840.113549.1.1.1")
				{
					RSAParameters parameters = default(RSAParameters);
					ASN1 aSN = new ASN1(m_publickey);
					ASN1 aSN2 = aSN[0];
					if (aSN2 == null || aSN2.Tag != 2)
					{
						return null;
					}
					ASN1 aSN3 = aSN[1];
					if (aSN3.Tag != 2)
					{
						return null;
					}
					parameters.Modulus = GetUnsignedBigInteger(aSN2.Value);
					parameters.Exponent = aSN3.Value;
					int dwKeySize = parameters.Modulus.Length << 3;
					_rsa = new RSACryptoServiceProvider(dwKeySize);
					_rsa.ImportParameters(parameters);
				}
				return _rsa;
			}
			set
			{
				if (value != null)
				{
					_dsa = null;
				}
				_rsa = value;
			}
		}

		public virtual byte[] RawData
		{
			get
			{
				if (m_encodedcert == null)
				{
					return null;
				}
				return (byte[])m_encodedcert.Clone();
			}
		}

		public virtual byte[] SerialNumber
		{
			get
			{
				if (serialnumber == null)
				{
					return null;
				}
				return (byte[])serialnumber.Clone();
			}
		}

		public virtual byte[] Signature
		{
			get
			{
				if (signature == null)
				{
					return null;
				}
				switch (m_signaturealgo)
				{
				case "1.2.840.113549.1.1.2":
				case "1.2.840.113549.1.1.3":
				case "1.2.840.113549.1.1.4":
				case "1.2.840.113549.1.1.5":
				case "1.3.14.3.2.29":
				case "1.2.840.113549.1.1.11":
				case "1.2.840.113549.1.1.12":
				case "1.2.840.113549.1.1.13":
				case "1.3.36.3.3.1.2":
					return (byte[])signature.Clone();
				case "1.2.840.10040.4.3":
				{
					ASN1 aSN = new ASN1(signature);
					if (aSN == null || aSN.Count != 2)
					{
						return null;
					}
					byte[] value = aSN[0].Value;
					byte[] value2 = aSN[1].Value;
					byte[] array = new byte[40];
					int num = System.Math.Max(0, value.Length - 20);
					int dstOffset = System.Math.Max(0, 20 - value.Length);
					Buffer.BlockCopy(value, num, array, dstOffset, value.Length - num);
					int num2 = System.Math.Max(0, value2.Length - 20);
					int dstOffset2 = System.Math.Max(20, 40 - value2.Length);
					Buffer.BlockCopy(value2, num2, array, dstOffset2, value2.Length - num2);
					return array;
				}
				default:
					throw new CryptographicException("Unsupported hash algorithm: " + m_signaturealgo);
				}
			}
		}

		public virtual string SubjectName => m_subject;

		public virtual DateTime ValidFrom => m_from;

		public virtual DateTime ValidUntil => m_until;

		public int Version => version;

		public bool IsCurrent => WasCurrent(DateTime.UtcNow);

		public bool IsSelfSigned
		{
			get
			{
				if (m_issuername != m_subject)
				{
					return false;
				}
				try
				{
					if (RSA != null)
					{
						return VerifySignature(RSA);
					}
					if (DSA != null)
					{
						return VerifySignature(DSA);
					}
					return false;
				}
				catch (CryptographicException)
				{
					return false;
				}
			}
		}

		private void Parse(byte[] data)
		{
			try
			{
				decoder = new ASN1(data);
				if (decoder.Tag != 48)
				{
					throw new CryptographicException(encoding_error);
				}
				if (decoder[0].Tag != 48)
				{
					throw new CryptographicException(encoding_error);
				}
				ASN1 aSN = decoder[0];
				int num = 0;
				ASN1 aSN2 = decoder[0][num];
				version = 1;
				if (aSN2.Tag == 160 && aSN2.Count > 0)
				{
					version += aSN2[0].Value[0];
					num++;
				}
				ASN1 aSN3 = decoder[0][num++];
				if (aSN3.Tag != 2)
				{
					throw new CryptographicException(encoding_error);
				}
				serialnumber = aSN3.Value;
				Array.Reverse(serialnumber, 0, serialnumber.Length);
				num++;
				issuer = aSN.Element(num++, 48);
				m_issuername = X501.ToString(issuer);
				ASN1 aSN4 = aSN.Element(num++, 48);
				ASN1 time = aSN4[0];
				m_from = ASN1Convert.ToDateTime(time);
				ASN1 time2 = aSN4[1];
				m_until = ASN1Convert.ToDateTime(time2);
				subject = aSN.Element(num++, 48);
				m_subject = X501.ToString(subject);
				ASN1 aSN5 = aSN.Element(num++, 48);
				ASN1 aSN6 = aSN5.Element(0, 48);
				ASN1 asn = aSN6.Element(0, 6);
				m_keyalgo = ASN1Convert.ToOid(asn);
				ASN1 aSN7 = aSN6[1];
				m_keyalgoparams = ((aSN6.Count > 1) ? aSN7.GetBytes() : null);
				ASN1 aSN8 = aSN5.Element(1, 3);
				int num2 = aSN8.Length - 1;
				m_publickey = new byte[num2];
				Buffer.BlockCopy(aSN8.Value, 1, m_publickey, 0, num2);
				byte[] value = decoder[2].Value;
				signature = new byte[value.Length - 1];
				Buffer.BlockCopy(value, 1, signature, 0, signature.Length);
				aSN6 = decoder[1];
				asn = aSN6.Element(0, 6);
				m_signaturealgo = ASN1Convert.ToOid(asn);
				aSN7 = aSN6[1];
				if (aSN7 != null)
				{
					m_signaturealgoparams = aSN7.GetBytes();
				}
				else
				{
					m_signaturealgoparams = null;
				}
				ASN1 aSN9 = aSN.Element(num, 129);
				if (aSN9 != null)
				{
					num++;
					issuerUniqueID = aSN9.Value;
				}
				ASN1 aSN10 = aSN.Element(num, 130);
				if (aSN10 != null)
				{
					num++;
					subjectUniqueID = aSN10.Value;
				}
				ASN1 aSN11 = aSN.Element(num, 163);
				if (aSN11 != null && aSN11.Count == 1)
				{
					extensions = new X509ExtensionCollection(aSN11[0]);
				}
				else
				{
					extensions = new X509ExtensionCollection(null);
				}
				m_encodedcert = (byte[])data.Clone();
			}
			catch (Exception inner)
			{
				throw new CryptographicException(encoding_error, inner);
			}
		}

		public X509Certificate(byte[] data)
		{
			if (data == null)
			{
				return;
			}
			if (data.Length != 0 && data[0] != 48)
			{
				try
				{
					data = PEM("CERTIFICATE", data);
				}
				catch (Exception inner)
				{
					throw new CryptographicException(encoding_error, inner);
				}
			}
			Parse(data);
		}

		private byte[] GetUnsignedBigInteger(byte[] integer)
		{
			if (integer[0] == 0)
			{
				int num = integer.Length - 1;
				byte[] array = new byte[num];
				Buffer.BlockCopy(integer, 1, array, 0, num);
				return array;
			}
			return integer;
		}

		public bool WasCurrent(DateTime instant)
		{
			if (instant > ValidFrom)
			{
				return instant <= ValidUntil;
			}
			return false;
		}

		internal bool VerifySignature(DSA dsa)
		{
			DSASignatureDeformatter dSASignatureDeformatter = new DSASignatureDeformatter(dsa);
			dSASignatureDeformatter.SetHashAlgorithm("SHA1");
			return dSASignatureDeformatter.VerifySignature(Hash, Signature);
		}

		internal bool VerifySignature(RSA rsa)
		{
			if (m_signaturealgo == "1.2.840.10040.4.3")
			{
				return false;
			}
			RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
			rSAPKCS1SignatureDeformatter.SetHashAlgorithm(PKCS1.HashNameFromOid(m_signaturealgo));
			return rSAPKCS1SignatureDeformatter.VerifySignature(Hash, Signature);
		}

		public bool VerifySignature(AsymmetricAlgorithm aa)
		{
			if (aa == null)
			{
				throw new ArgumentNullException("aa");
			}
			if (aa is RSA)
			{
				return VerifySignature(aa as RSA);
			}
			if (aa is DSA)
			{
				return VerifySignature(aa as DSA);
			}
			throw new NotSupportedException("Unknown Asymmetric Algorithm " + aa.ToString());
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("raw", m_encodedcert);
		}

		private static byte[] PEM(string type, byte[] data)
		{
			string text = Encoding.ASCII.GetString(data);
			string text2 = $"-----BEGIN {type}-----";
			string value = $"-----END {type}-----";
			int num = text.IndexOf(text2) + text2.Length;
			int num2 = text.IndexOf(value, num);
			return Convert.FromBase64String(text.Substring(num, num2 - num));
		}
	}
	[Serializable]
	public class X509CertificateCollection : CollectionBase, IEnumerable
	{
		public class X509CertificateEnumerator : IEnumerator
		{
			private IEnumerator enumerator;

			public X509Certificate Current => (X509Certificate)enumerator.Current;

			object IEnumerator.Current => enumerator.Current;

			public X509CertificateEnumerator(X509CertificateCollection mappings)
			{
				enumerator = ((IEnumerable)mappings).GetEnumerator();
			}

			bool IEnumerator.MoveNext()
			{
				return enumerator.MoveNext();
			}

			void IEnumerator.Reset()
			{
				enumerator.Reset();
			}

			public bool MoveNext()
			{
				return enumerator.MoveNext();
			}
		}

		public X509Certificate this[int index] => (X509Certificate)base.InnerList[index];

		public int Add(X509Certificate value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return base.InnerList.Add(value);
		}

		public void AddRange(X509CertificateCollection value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			for (int i = 0; i < value.InnerList.Count; i++)
			{
				base.InnerList.Add(value[i]);
			}
		}

		public bool Contains(X509Certificate value)
		{
			return IndexOf(value) != -1;
		}

		public new X509CertificateEnumerator GetEnumerator()
		{
			return new X509CertificateEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return base.InnerList.GetEnumerator();
		}

		public override int GetHashCode()
		{
			return base.InnerList.GetHashCode();
		}

		public int IndexOf(X509Certificate value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			byte[] hash = value.Hash;
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				X509Certificate x509Certificate = (X509Certificate)base.InnerList[i];
				if (Compare(x509Certificate.Hash, hash))
				{
					return i;
				}
			}
			return -1;
		}

		private bool Compare(byte[] array1, byte[] array2)
		{
			if (array1 == null && array2 == null)
			{
				return true;
			}
			if (array1 == null || array2 == null)
			{
				return false;
			}
			if (array1.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}
	}
	public class X509Chain
	{
		private X509CertificateCollection roots;

		private X509CertificateCollection certs;

		private X509Certificate _root;

		private X509CertificateCollection _chain;

		private X509ChainStatusFlags _status;

		public X509CertificateCollection TrustAnchors
		{
			get
			{
				if (roots == null)
				{
					roots = new X509CertificateCollection();
					roots.AddRange(X509StoreManager.TrustedRootCertificates);
					return roots;
				}
				return roots;
			}
		}

		public X509Chain()
		{
			certs = new X509CertificateCollection();
		}

		public void LoadCertificates(X509CertificateCollection collection)
		{
			certs.AddRange(collection);
		}

		public bool Build(X509Certificate leaf)
		{
			_status = X509ChainStatusFlags.NoError;
			if (_chain == null)
			{
				_chain = new X509CertificateCollection();
				X509Certificate x509Certificate = leaf;
				X509Certificate potentialRoot = x509Certificate;
				while (x509Certificate != null && !x509Certificate.IsSelfSigned)
				{
					potentialRoot = x509Certificate;
					_chain.Add(x509Certificate);
					x509Certificate = FindCertificateParent(x509Certificate);
				}
				_root = FindCertificateRoot(potentialRoot);
			}
			else
			{
				int count = _chain.Count;
				if (count > 0)
				{
					if (IsParent(leaf, _chain[0]))
					{
						int i;
						for (i = 1; i < count && IsParent(_chain[i - 1], _chain[i]); i++)
						{
						}
						if (i == count)
						{
							_root = FindCertificateRoot(_chain[count - 1]);
						}
					}
				}
				else
				{
					_root = FindCertificateRoot(leaf);
				}
			}
			if (_chain != null && _status == X509ChainStatusFlags.NoError)
			{
				foreach (X509Certificate item in _chain)
				{
					if (!IsValid(item))
					{
						return false;
					}
				}
				if (!IsValid(leaf))
				{
					if (_status == X509ChainStatusFlags.NotTimeNested)
					{
						_status = X509ChainStatusFlags.NotTimeValid;
					}
					return false;
				}
				if (_root != null && !IsValid(_root))
				{
					return false;
				}
			}
			return _status == X509ChainStatusFlags.NoError;
		}

		public void Reset()
		{
			_status = X509ChainStatusFlags.NoError;
			roots = null;
			certs.Clear();
			if (_chain != null)
			{
				_chain.Clear();
			}
		}

		private bool IsValid(X509Certificate cert)
		{
			if (!cert.IsCurrent)
			{
				_status = X509ChainStatusFlags.NotTimeNested;
				return false;
			}
			_ = ServicePointManager.CheckCertificateRevocationList;
			return true;
		}

		private X509Certificate FindCertificateParent(X509Certificate child)
		{
			foreach (X509Certificate cert in certs)
			{
				if (IsParent(child, cert))
				{
					return cert;
				}
			}
			return null;
		}

		private X509Certificate FindCertificateRoot(X509Certificate potentialRoot)
		{
			if (potentialRoot == null)
			{
				_status = X509ChainStatusFlags.PartialChain;
				return null;
			}
			if (IsTrusted(potentialRoot))
			{
				return potentialRoot;
			}
			foreach (X509Certificate trustAnchor in TrustAnchors)
			{
				if (IsParent(potentialRoot, trustAnchor))
				{
					return trustAnchor;
				}
			}
			if (potentialRoot.IsSelfSigned)
			{
				_status = X509ChainStatusFlags.UntrustedRoot;
				return potentialRoot;
			}
			_status = X509ChainStatusFlags.PartialChain;
			return null;
		}

		private bool IsTrusted(X509Certificate potentialTrusted)
		{
			return TrustAnchors.Contains(potentialTrusted);
		}

		private bool IsParent(X509Certificate child, X509Certificate parent)
		{
			if (child.IssuerName != parent.SubjectName)
			{
				return false;
			}
			if (parent.Version > 2 && !IsTrusted(parent))
			{
				X509Extension x509Extension = parent.Extensions["2.5.29.19"];
				if (x509Extension != null)
				{
					if (!new BasicConstraintsExtension(x509Extension).CertificateAuthority)
					{
						_status = X509ChainStatusFlags.InvalidBasicConstraints;
					}
				}
				else
				{
					_status = X509ChainStatusFlags.InvalidBasicConstraints;
				}
			}
			if (!child.VerifySignature(parent.RSA))
			{
				_status = X509ChainStatusFlags.NotSignatureValid;
				return false;
			}
			return true;
		}
	}
	[Serializable]
	[Flags]
	public enum X509ChainStatusFlags
	{
		InvalidBasicConstraints = 0x400,
		NoError = 0,
		NotSignatureValid = 8,
		NotTimeNested = 2,
		NotTimeValid = 1,
		PartialChain = 0x10000,
		UntrustedRoot = 0x20
	}
	public class X509Extension
	{
		protected string extnOid;

		protected bool extnCritical;

		protected ASN1 extnValue;

		public string Oid => extnOid;

		public bool Critical => extnCritical;

		public ASN1 Value
		{
			get
			{
				if (extnValue == null)
				{
					Encode();
				}
				return extnValue;
			}
		}

		public X509Extension(ASN1 asn1)
		{
			if (asn1.Tag != 48 || asn1.Count < 2)
			{
				throw new ArgumentException(global::Locale.GetText("Invalid X.509 extension."));
			}
			if (asn1[0].Tag != 6)
			{
				throw new ArgumentException(global::Locale.GetText("Invalid X.509 extension."));
			}
			extnOid = ASN1Convert.ToOid(asn1[0]);
			extnCritical = asn1[1].Tag == 1 && asn1[1].Value[0] == 255;
			extnValue = asn1[asn1.Count - 1];
			if (extnValue.Tag == 4 && extnValue.Length > 0 && extnValue.Count == 0)
			{
				try
				{
					ASN1 asn2 = new ASN1(extnValue.Value);
					extnValue.Value = null;
					extnValue.Add(asn2);
				}
				catch
				{
				}
			}
			Decode();
		}

		public X509Extension(X509Extension extension)
		{
			if (extension == null)
			{
				throw new ArgumentNullException("extension");
			}
			if (extension.Value == null || extension.Value.Tag != 4 || extension.Value.Count != 1)
			{
				throw new ArgumentException(global::Locale.GetText("Invalid X.509 extension."));
			}
			extnOid = extension.Oid;
			extnCritical = extension.Critical;
			extnValue = extension.Value;
			Decode();
		}

		protected virtual void Decode()
		{
		}

		protected virtual void Encode()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is X509Extension x509Extension))
			{
				return false;
			}
			if (extnCritical != x509Extension.extnCritical)
			{
				return false;
			}
			if (extnOid != x509Extension.extnOid)
			{
				return false;
			}
			if (extnValue.Length != x509Extension.extnValue.Length)
			{
				return false;
			}
			for (int i = 0; i < extnValue.Length; i++)
			{
				if (extnValue[i] != x509Extension.extnValue[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return extnOid.GetHashCode();
		}

		private void WriteLine(StringBuilder sb, int n, int pos)
		{
			byte[] value = extnValue.Value;
			int num = pos;
			for (int i = 0; i < 8; i++)
			{
				if (i < n)
				{
					sb.Append(value[num++].ToString("X2", CultureInfo.InvariantCulture));
					sb.Append(" ");
				}
				else
				{
					sb.Append("   ");
				}
			}
			sb.Append("  ");
			num = pos;
			for (int j = 0; j < n; j++)
			{
				byte b = value[num++];
				if (b < 32)
				{
					sb.Append(".");
				}
				else
				{
					sb.Append(Convert.ToChar(b));
				}
			}
			sb.Append(Environment.NewLine);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = extnValue.Length >> 3;
			int n = extnValue.Length - (num << 3);
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				WriteLine(stringBuilder, 8, num2);
				num2 += 8;
			}
			WriteLine(stringBuilder, n, num2);
			return stringBuilder.ToString();
		}
	}
	public sealed class X509ExtensionCollection : CollectionBase, IEnumerable
	{
		private bool readOnly;

		public X509Extension this[string oid]
		{
			get
			{
				int num = IndexOf(oid);
				if (num == -1)
				{
					return null;
				}
				return (X509Extension)base.InnerList[num];
			}
		}

		public X509ExtensionCollection()
		{
		}

		public X509ExtensionCollection(ASN1 asn1)
			: this()
		{
			readOnly = true;
			if (asn1 != null)
			{
				if (asn1.Tag != 48)
				{
					throw new Exception("Invalid extensions format");
				}
				for (int i = 0; i < asn1.Count; i++)
				{
					X509Extension value = new X509Extension(asn1[i]);
					base.InnerList.Add(value);
				}
			}
		}

		public int IndexOf(string oid)
		{
			if (oid == null)
			{
				throw new ArgumentNullException("oid");
			}
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				if (((X509Extension)base.InnerList[i]).Oid == oid)
				{
					return i;
				}
			}
			return -1;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return base.InnerList.GetEnumerator();
		}
	}
	public class X509Store
	{
		private string _storePath;

		private X509CertificateCollection _certificates;

		private ArrayList _crls;

		private bool _crl;

		private bool _newFormat;

		public X509CertificateCollection Certificates
		{
			get
			{
				if (_certificates == null)
				{
					_certificates = BuildCertificatesCollection(_storePath);
				}
				return _certificates;
			}
		}

		public ArrayList Crls
		{
			get
			{
				if (!_crl)
				{
					_crls = new ArrayList();
				}
				if (_crls == null)
				{
					_crls = BuildCrlsCollection(_storePath);
				}
				return _crls;
			}
		}

		internal X509Store(string path, bool crl, bool newFormat)
		{
			_storePath = path;
			_crl = crl;
			_newFormat = newFormat;
		}

		private byte[] Load(string filename)
		{
			byte[] array = null;
			using FileStream fileStream = File.OpenRead(filename);
			array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		private X509Certificate LoadCertificate(string filename)
		{
			return new X509Certificate(Load(filename));
		}

		private X509Crl LoadCrl(string filename)
		{
			return new X509Crl(Load(filename));
		}

		private bool CheckStore(string path, bool throwException)
		{
			try
			{
				if (Directory.Exists(path))
				{
					return true;
				}
				Directory.CreateDirectory(path);
				return Directory.Exists(path);
			}
			catch
			{
				if (throwException)
				{
					throw;
				}
				return false;
			}
		}

		private X509CertificateCollection BuildCertificatesCollection(string storeName)
		{
			X509CertificateCollection x509CertificateCollection = new X509CertificateCollection();
			string path = Path.Combine(_storePath, storeName);
			if (!CheckStore(path, throwException: false))
			{
				return x509CertificateCollection;
			}
			string[] files = Directory.GetFiles(path, _newFormat ? "*.0" : "*.cer");
			if (files != null && files.Length != 0)
			{
				string[] array = files;
				foreach (string filename in array)
				{
					try
					{
						X509Certificate value = LoadCertificate(filename);
						x509CertificateCollection.Add(value);
					}
					catch
					{
					}
				}
			}
			return x509CertificateCollection;
		}

		private ArrayList BuildCrlsCollection(string storeName)
		{
			ArrayList arrayList = new ArrayList();
			string path = Path.Combine(_storePath, storeName);
			if (!CheckStore(path, throwException: false))
			{
				return arrayList;
			}
			string[] files = Directory.GetFiles(path, "*.crl");
			if (files != null && files.Length != 0)
			{
				string[] array = files;
				foreach (string filename in array)
				{
					try
					{
						X509Crl value = LoadCrl(filename);
						arrayList.Add(value);
					}
					catch
					{
					}
				}
			}
			return arrayList;
		}
	}
	public sealed class X509StoreManager
	{
		private static string _userPath;

		private static string _localMachinePath;

		private static X509Stores _userStore;

		private static X509Stores _machineStore;

		internal static string CurrentUserPath
		{
			get
			{
				if (_userPath == null)
				{
					_userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".mono");
					_userPath = Path.Combine(_userPath, "certs");
				}
				return _userPath;
			}
		}

		internal static string LocalMachinePath
		{
			get
			{
				if (_localMachinePath == null)
				{
					_localMachinePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".mono");
					_localMachinePath = Path.Combine(_localMachinePath, "certs");
				}
				return _localMachinePath;
			}
		}

		public static X509Stores CurrentUser
		{
			get
			{
				if (_userStore == null)
				{
					_userStore = new X509Stores(CurrentUserPath, newFormat: false);
				}
				return _userStore;
			}
		}

		public static X509Stores LocalMachine
		{
			get
			{
				if (_machineStore == null)
				{
					_machineStore = new X509Stores(LocalMachinePath, newFormat: false);
				}
				return _machineStore;
			}
		}

		public static X509CertificateCollection TrustedRootCertificates
		{
			get
			{
				X509CertificateCollection x509CertificateCollection = new X509CertificateCollection();
				x509CertificateCollection.AddRange(CurrentUser.TrustedRoot.Certificates);
				x509CertificateCollection.AddRange(LocalMachine.TrustedRoot.Certificates);
				return x509CertificateCollection;
			}
		}
	}
	public class X509Stores
	{
		private string _storePath;

		private bool _newFormat;

		private X509Store _trusted;

		public X509Store TrustedRoot
		{
			get
			{
				if (_trusted == null)
				{
					string path = Path.Combine(_storePath, "Trust");
					_trusted = new X509Store(path, crl: true, _newFormat);
				}
				return _trusted;
			}
		}

		internal X509Stores(string path, bool newFormat)
		{
			_storePath = path;
			_newFormat = newFormat;
		}

		public X509Store Open(string storeName, bool create)
		{
			if (storeName == null)
			{
				throw new ArgumentNullException("storeName");
			}
			string path = Path.Combine(_storePath, storeName);
			if (!create && !Directory.Exists(path))
			{
				return null;
			}
			return new X509Store(path, crl: true, newFormat: false);
		}
	}
	public class X520
	{
		public abstract class AttributeTypeAndValue
		{
			private string oid;

			private string attrValue;

			private int upperBound;

			private byte encoding;

			public string Value
			{
				set
				{
					if (attrValue != null && attrValue.Length > upperBound)
					{
						throw new FormatException(string.Format(global::Locale.GetText("Value length bigger than upperbound ({0})."), upperBound));
					}
					attrValue = value;
				}
			}

			protected AttributeTypeAndValue(string oid, int upperBound)
			{
				this.oid = oid;
				this.upperBound = upperBound;
				encoding = 255;
			}

			protected AttributeTypeAndValue(string oid, int upperBound, byte encoding)
			{
				this.oid = oid;
				this.upperBound = upperBound;
				this.encoding = encoding;
			}

			internal ASN1 GetASN1(byte encoding)
			{
				byte b = encoding;
				if (b == 255)
				{
					b = SelectBestEncoding();
				}
				ASN1 aSN = new ASN1(48);
				aSN.Add(ASN1Convert.FromOid(oid));
				switch (b)
				{
				case 19:
					aSN.Add(new ASN1(19, Encoding.ASCII.GetBytes(attrValue)));
					break;
				case 22:
					aSN.Add(new ASN1(22, Encoding.ASCII.GetBytes(attrValue)));
					break;
				case 30:
					aSN.Add(new ASN1(30, Encoding.BigEndianUnicode.GetBytes(attrValue)));
					break;
				}
				return aSN;
			}

			internal ASN1 GetASN1()
			{
				return GetASN1(encoding);
			}

			private byte SelectBestEncoding()
			{
				string text = attrValue;
				foreach (char c in text)
				{
					if (c == '@' || c == '_')
					{
						return 30;
					}
					if (c > '\u007f')
					{
						return 30;
					}
				}
				return 19;
			}
		}

		public class CommonName : AttributeTypeAndValue
		{
			public CommonName()
				: base("2.5.4.3", 64)
			{
			}
		}

		public class SerialNumber : AttributeTypeAndValue
		{
			public SerialNumber()
				: base("2.5.4.5", 64, 19)
			{
			}
		}

		public class LocalityName : AttributeTypeAndValue
		{
			public LocalityName()
				: base("2.5.4.7", 128)
			{
			}
		}

		public class StateOrProvinceName : AttributeTypeAndValue
		{
			public StateOrProvinceName()
				: base("2.5.4.8", 128)
			{
			}
		}

		public class OrganizationName : AttributeTypeAndValue
		{
			public OrganizationName()
				: base("2.5.4.10", 64)
			{
			}
		}

		public class OrganizationalUnitName : AttributeTypeAndValue
		{
			public OrganizationalUnitName()
				: base("2.5.4.11", 64)
			{
			}
		}

		public class EmailAddress : AttributeTypeAndValue
		{
			public EmailAddress()
				: base("1.2.840.113549.1.9.1", 128, 22)
			{
			}
		}

		public class DomainComponent : AttributeTypeAndValue
		{
			public DomainComponent()
				: base("0.9.2342.19200300.100.1.25", 2147483647, 22)
			{
			}
		}

		public class UserId : AttributeTypeAndValue
		{
			public UserId()
				: base("0.9.2342.19200300.100.1.1", 256)
			{
			}
		}

		public class Oid : AttributeTypeAndValue
		{
			public Oid(string oid)
				: base(oid, 2147483647)
			{
			}
		}

		public class Title : AttributeTypeAndValue
		{
			public Title()
				: base("2.5.4.12", 64)
			{
			}
		}

		public class CountryName : AttributeTypeAndValue
		{
			public CountryName()
				: base("2.5.4.6", 2, 19)
			{
			}
		}

		public class DnQualifier : AttributeTypeAndValue
		{
			public DnQualifier()
				: base("2.5.4.46", 2, 19)
			{
			}
		}

		public class Surname : AttributeTypeAndValue
		{
			public Surname()
				: base("2.5.4.4", 32768)
			{
			}
		}

		public class GivenName : AttributeTypeAndValue
		{
			public GivenName()
				: base("2.5.4.42", 16)
			{
			}
		}

		public class Initial : AttributeTypeAndValue
		{
			public Initial()
				: base("2.5.4.43", 5)
			{
			}
		}
	}
}
namespace Mono.Security.X509.Extensions
{
	public class AuthorityKeyIdentifierExtension : X509Extension
	{
		private byte[] aki;

		public byte[] Identifier
		{
			get
			{
				if (aki == null)
				{
					return null;
				}
				return (byte[])aki.Clone();
			}
		}

		public AuthorityKeyIdentifierExtension(X509Extension extension)
			: base(extension)
		{
		}

		protected override void Decode()
		{
			ASN1 aSN = new ASN1(extnValue.Value);
			if (aSN.Tag != 48)
			{
				throw new ArgumentException("Invalid AuthorityKeyIdentifier extension");
			}
			for (int i = 0; i < aSN.Count; i++)
			{
				ASN1 aSN2 = aSN[i];
				if (aSN2.Tag == 128)
				{
					aki = aSN2.Value;
				}
			}
		}

		protected override void Encode()
		{
			ASN1 aSN = new ASN1(48);
			if (aki == null)
			{
				throw new InvalidOperationException("Invalid AuthorityKeyIdentifier extension");
			}
			aSN.Add(new ASN1(128, aki));
			extnValue = new ASN1(4);
			extnValue.Add(aSN);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (aki != null)
			{
				int i = 0;
				stringBuilder.Append("KeyID=");
				for (; i < aki.Length; i++)
				{
					stringBuilder.Append(aki[i].ToString("X2", CultureInfo.InvariantCulture));
					if (i % 2 == 1)
					{
						stringBuilder.Append(" ");
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
	public class BasicConstraintsExtension : X509Extension
	{
		private bool cA;

		private int pathLenConstraint;

		public bool CertificateAuthority => cA;

		public BasicConstraintsExtension(X509Extension extension)
			: base(extension)
		{
		}

		protected override void Decode()
		{
			cA = false;
			pathLenConstraint = -1;
			ASN1 aSN = new ASN1(extnValue.Value);
			if (aSN.Tag != 48)
			{
				throw new ArgumentException("Invalid BasicConstraints extension");
			}
			int num = 0;
			ASN1 aSN2 = aSN[num++];
			if (aSN2 != null && aSN2.Tag == 1)
			{
				cA = aSN2.Value[0] == 255;
				aSN2 = aSN[num++];
			}
			if (aSN2 != null && aSN2.Tag == 2)
			{
				pathLenConstraint = ASN1Convert.ToInt32(aSN2);
			}
		}

		protected override void Encode()
		{
			ASN1 aSN = new ASN1(48);
			if (cA)
			{
				aSN.Add(new ASN1(1, new byte[1] { 255 }));
			}
			if (cA && pathLenConstraint >= 0)
			{
				aSN.Add(ASN1Convert.FromInt32(pathLenConstraint));
			}
			extnValue = new ASN1(4);
			extnValue.Add(aSN);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Subject Type=");
			stringBuilder.Append(cA ? "CA" : "End Entity");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("Path Length Constraint=");
			if (pathLenConstraint == -1)
			{
				stringBuilder.Append("None");
			}
			else
			{
				stringBuilder.Append(pathLenConstraint.ToString(CultureInfo.InvariantCulture));
			}
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}
	}
}
namespace Mono.Security.Protocol.Ntlm
{
	public class ChallengeResponse : IDisposable
	{
		private static byte[] magic = new byte[8] { 75, 71, 83, 33, 64, 35, 36, 37 };

		private static byte[] nullEncMagic = new byte[8] { 170, 211, 180, 53, 181, 20, 4, 238 };

		private bool _disposed;

		private byte[] _challenge;

		private byte[] _lmpwd;

		private byte[] _ntpwd;

		public string Password
		{
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("too late");
				}
				DES dES = DES.Create();
				dES.Mode = CipherMode.ECB;
				if (value == null || value.Length < 1)
				{
					Buffer.BlockCopy(nullEncMagic, 0, _lmpwd, 0, 8);
				}
				else
				{
					dES.Key = PasswordToKey(value, 0);
					dES.CreateEncryptor().TransformBlock(magic, 0, 8, _lmpwd, 0);
				}
				if (value == null || value.Length < 8)
				{
					Buffer.BlockCopy(nullEncMagic, 0, _lmpwd, 8, 8);
				}
				else
				{
					dES.Key = PasswordToKey(value, 7);
					dES.CreateEncryptor().TransformBlock(magic, 0, 8, _lmpwd, 8);
				}
				MD4 mD = MD4.Create();
				byte[] array = ((value == null) ? new byte[0] : Encoding.Unicode.GetBytes(value));
				byte[] array2 = mD.ComputeHash(array);
				Buffer.BlockCopy(array2, 0, _ntpwd, 0, 16);
				Array.Clear(array, 0, array.Length);
				Array.Clear(array2, 0, array2.Length);
				dES.Clear();
			}
		}

		public byte[] Challenge
		{
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Challenge");
				}
				if (_disposed)
				{
					throw new ObjectDisposedException("too late");
				}
				_challenge = (byte[])value.Clone();
			}
		}

		public byte[] LM
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("too late");
				}
				return GetResponse(_lmpwd);
			}
		}

		public byte[] NT
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("too late");
				}
				return GetResponse(_ntpwd);
			}
		}

		public ChallengeResponse()
		{
			_disposed = false;
			_lmpwd = new byte[21];
			_ntpwd = new byte[21];
		}

		public ChallengeResponse(string password, byte[] challenge)
			: this()
		{
			Password = password;
			Challenge = challenge;
		}

		~ChallengeResponse()
		{
			if (!_disposed)
			{
				Dispose();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				Array.Clear(_lmpwd, 0, _lmpwd.Length);
				Array.Clear(_ntpwd, 0, _ntpwd.Length);
				if (_challenge != null)
				{
					Array.Clear(_challenge, 0, _challenge.Length);
				}
				_disposed = true;
			}
		}

		private byte[] GetResponse(byte[] pwd)
		{
			byte[] array = new byte[24];
			DES dES = DES.Create();
			dES.Mode = CipherMode.ECB;
			dES.Key = PrepareDESKey(pwd, 0);
			dES.CreateEncryptor().TransformBlock(_challenge, 0, 8, array, 0);
			dES.Key = PrepareDESKey(pwd, 7);
			dES.CreateEncryptor().TransformBlock(_challenge, 0, 8, array, 8);
			dES.Key = PrepareDESKey(pwd, 14);
			dES.CreateEncryptor().TransformBlock(_challenge, 0, 8, array, 16);
			return array;
		}

		private byte[] PrepareDESKey(byte[] key56bits, int position)
		{
			return new byte[8]
			{
				key56bits[position],
				(byte)((key56bits[position] << 7) | (key56bits[position + 1] >> 1)),
				(byte)((key56bits[position + 1] << 6) | (key56bits[position + 2] >> 2)),
				(byte)((key56bits[position + 2] << 5) | (key56bits[position + 3] >> 3)),
				(byte)((key56bits[position + 3] << 4) | (key56bits[position + 4] >> 4)),
				(byte)((key56bits[position + 4] << 3) | (key56bits[position + 5] >> 5)),
				(byte)((key56bits[position + 5] << 2) | (key56bits[position + 6] >> 6)),
				(byte)(key56bits[position + 6] << 1)
			};
		}

		private byte[] PasswordToKey(string password, int position)
		{
			byte[] array = new byte[7];
			int charCount = System.Math.Min(password.Length - position, 7);
			Encoding.ASCII.GetBytes(password.ToUpper(CultureInfo.CurrentCulture), position, charCount, array, 0);
			byte[] result = PrepareDESKey(array, 0);
			Array.Clear(array, 0, array.Length);
			return result;
		}
	}
	public static class ChallengeResponse2
	{
		private static byte[] magic = new byte[8] { 75, 71, 83, 33, 64, 35, 36, 37 };

		private static byte[] nullEncMagic = new byte[8] { 170, 211, 180, 53, 181, 20, 4, 238 };

		private static byte[] Compute_LM(string password, byte[] challenge)
		{
			byte[] array = new byte[21];
			DES dES = DES.Create();
			dES.Mode = CipherMode.ECB;
			if (password == null || password.Length < 1)
			{
				Buffer.BlockCopy(nullEncMagic, 0, array, 0, 8);
			}
			else
			{
				dES.Key = PasswordToKey(password, 0);
				dES.CreateEncryptor().TransformBlock(magic, 0, 8, array, 0);
			}
			if (password == null || password.Length < 8)
			{
				Buffer.BlockCopy(nullEncMagic, 0, array, 8, 8);
			}
			else
			{
				dES.Key = PasswordToKey(password, 7);
				dES.CreateEncryptor().TransformBlock(magic, 0, 8, array, 8);
			}
			dES.Clear();
			return GetResponse(challenge, array);
		}

		private static byte[] Compute_NTLM_Password(string password)
		{
			byte[] array = new byte[21];
			MD4 mD = MD4.Create();
			byte[] array2 = ((password == null) ? new byte[0] : Encoding.Unicode.GetBytes(password));
			byte[] array3 = mD.ComputeHash(array2);
			Buffer.BlockCopy(array3, 0, array, 0, 16);
			Array.Clear(array2, 0, array2.Length);
			Array.Clear(array3, 0, array3.Length);
			return array;
		}

		private static byte[] Compute_NTLM(string password, byte[] challenge)
		{
			byte[] pwd = Compute_NTLM_Password(password);
			return GetResponse(challenge, pwd);
		}

		private static void Compute_NTLMv2_Session(string password, byte[] challenge, out byte[] lm, out byte[] ntlm)
		{
			byte[] array = new byte[8];
			RandomNumberGenerator.Create().GetBytes(array);
			byte[] array2 = new byte[challenge.Length + 8];
			challenge.CopyTo(array2, 0);
			array.CopyTo(array2, challenge.Length);
			lm = new byte[24];
			array.CopyTo(lm, 0);
			byte[] array3 = MD5.Create().ComputeHash(array2);
			byte[] array4 = new byte[8];
			Array.Copy(array3, array4, 8);
			ntlm = Compute_NTLM(password, array4);
			Array.Clear(array, 0, array.Length);
			Array.Clear(array2, 0, array2.Length);
			Array.Clear(array4, 0, array4.Length);
			Array.Clear(array3, 0, array3.Length);
		}

		private static byte[] Compute_NTLMv2(Type2Message type2, string username, string password, string domain)
		{
			byte[] array = Compute_NTLM_Password(password);
			byte[] bytes = Encoding.Unicode.GetBytes(username.ToUpperInvariant());
			byte[] bytes2 = Encoding.Unicode.GetBytes(domain);
			byte[] array2 = new byte[bytes.Length + bytes2.Length];
			bytes.CopyTo(array2, 0);
			Array.Copy(bytes2, 0, array2, bytes.Length, bytes2.Length);
			HMACMD5 hMACMD = new HMACMD5(array);
			byte[] array3 = hMACMD.ComputeHash(array2);
			Array.Clear(array, 0, array.Length);
			hMACMD.Clear();
			HMACMD5 hMACMD2 = new HMACMD5(array3);
			long value = DateTime.Now.Ticks - 504911232000000000L;
			byte[] array4 = new byte[8];
			RandomNumberGenerator.Create().GetBytes(array4);
			byte[] array5 = new byte[28 + type2.TargetInfo.Length];
			array5[0] = 1;
			array5[1] = 1;
			Buffer.BlockCopy(Mono.Security.BitConverterLE.GetBytes(value), 0, array5, 8, 8);
			Buffer.BlockCopy(array4, 0, array5, 16, 8);
			Buffer.BlockCopy(type2.TargetInfo, 0, array5, 28, type2.TargetInfo.Length);
			byte[] nonce = type2.Nonce;
			byte[] array6 = new byte[nonce.Length + array5.Length];
			nonce.CopyTo(array6, 0);
			array5.CopyTo(array6, nonce.Length);
			byte[] array7 = hMACMD2.ComputeHash(array6);
			byte[] array8 = new byte[array5.Length + array7.Length];
			array7.CopyTo(array8, 0);
			array5.CopyTo(array8, array7.Length);
			Array.Clear(array3, 0, array3.Length);
			hMACMD2.Clear();
			Array.Clear(array4, 0, array4.Length);
			Array.Clear(array5, 0, array5.Length);
			Array.Clear(array6, 0, array6.Length);
			Array.Clear(array7, 0, array7.Length);
			return array8;
		}

		public static void Compute(Type2Message type2, NtlmAuthLevel level, string username, string password, string domain, out byte[] lm, out byte[] ntlm)
		{
			lm = null;
			switch (level)
			{
			case NtlmAuthLevel.LM_and_NTLM:
				lm = Compute_LM(password, type2.Nonce);
				ntlm = Compute_NTLM(password, type2.Nonce);
				break;
			case NtlmAuthLevel.LM_and_NTLM_and_try_NTLMv2_Session:
				if ((type2.Flags & NtlmFlags.NegotiateNtlm2Key) != 0)
				{
					Compute_NTLMv2_Session(password, type2.Nonce, out lm, out ntlm);
					break;
				}
				goto case NtlmAuthLevel.LM_and_NTLM;
			case NtlmAuthLevel.NTLM_only:
				if ((type2.Flags & NtlmFlags.NegotiateNtlm2Key) != 0)
				{
					Compute_NTLMv2_Session(password, type2.Nonce, out lm, out ntlm);
				}
				else
				{
					ntlm = Compute_NTLM(password, type2.Nonce);
				}
				break;
			case NtlmAuthLevel.NTLMv2_only:
				ntlm = Compute_NTLMv2(type2, username, password, domain);
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		private static byte[] GetResponse(byte[] challenge, byte[] pwd)
		{
			byte[] array = new byte[24];
			DES dES = DES.Create();
			dES.Mode = CipherMode.ECB;
			dES.Key = PrepareDESKey(pwd, 0);
			dES.CreateEncryptor().TransformBlock(challenge, 0, 8, array, 0);
			dES.Key = PrepareDESKey(pwd, 7);
			dES.CreateEncryptor().TransformBlock(challenge, 0, 8, array, 8);
			dES.Key = PrepareDESKey(pwd, 14);
			dES.CreateEncryptor().TransformBlock(challenge, 0, 8, array, 16);
			return array;
		}

		private static byte[] PrepareDESKey(byte[] key56bits, int position)
		{
			return new byte[8]
			{
				key56bits[position],
				(byte)((key56bits[position] << 7) | (key56bits[position + 1] >> 1)),
				(byte)((key56bits[position + 1] << 6) | (key56bits[position + 2] >> 2)),
				(byte)((key56bits[position + 2] << 5) | (key56bits[position + 3] >> 3)),
				(byte)((key56bits[position + 3] << 4) | (key56bits[position + 4] >> 4)),
				(byte)((key56bits[position + 4] << 3) | (key56bits[position + 5] >> 5)),
				(byte)((key56bits[position + 5] << 2) | (key56bits[position + 6] >> 6)),
				(byte)(key56bits[position + 6] << 1)
			};
		}

		private static byte[] PasswordToKey(string password, int position)
		{
			byte[] array = new byte[7];
			int charCount = System.Math.Min(password.Length - position, 7);
			Encoding.ASCII.GetBytes(password.ToUpper(CultureInfo.CurrentCulture), position, charCount, array, 0);
			byte[] result = PrepareDESKey(array, 0);
			Array.Clear(array, 0, array.Length);
			return result;
		}
	}
	public abstract class MessageBase
	{
		private static byte[] header = new byte[8] { 78, 84, 76, 77, 83, 83, 80, 0 };

		private int _type;

		private NtlmFlags _flags;

		public NtlmFlags Flags
		{
			get
			{
				return _flags;
			}
			set
			{
				_flags = value;
			}
		}

		public int Type => _type;

		protected MessageBase(int messageType)
		{
			_type = messageType;
		}

		protected byte[] PrepareMessage(int messageSize)
		{
			byte[] array = new byte[messageSize];
			Buffer.BlockCopy(header, 0, array, 0, 8);
			array[8] = (byte)_type;
			array[9] = (byte)(_type >> 8);
			array[10] = (byte)(_type >> 16);
			array[11] = (byte)(_type >> 24);
			return array;
		}

		protected virtual void Decode(byte[] message)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			if (message.Length < 12)
			{
				string text = global::Locale.GetText("Minimum message length is 12 bytes.");
				throw new ArgumentOutOfRangeException("message", message.Length, text);
			}
			if (!CheckHeader(message))
			{
				throw new ArgumentException(string.Format(global::Locale.GetText("Invalid Type{0} message."), _type), "message");
			}
		}

		protected bool CheckHeader(byte[] message)
		{
			for (int i = 0; i < header.Length; i++)
			{
				if (message[i] != header[i])
				{
					return false;
				}
			}
			return Mono.Security.BitConverterLE.ToUInt32(message, 8) == _type;
		}

		public abstract byte[] GetBytes();
	}
	public enum NtlmAuthLevel
	{
		LM_and_NTLM,
		LM_and_NTLM_and_try_NTLMv2_Session,
		NTLM_only,
		NTLMv2_only
	}
	[Flags]
	public enum NtlmFlags
	{
		NegotiateUnicode = 1,
		NegotiateOem = 2,
		RequestTarget = 4,
		NegotiateNtlm = 0x200,
		NegotiateDomainSupplied = 0x1000,
		NegotiateWorkstationSupplied = 0x2000,
		NegotiateAlwaysSign = 0x8000,
		NegotiateNtlm2Key = 0x80000,
		Negotiate128 = 0x20000000,
		Negotiate56 = -2147483648
	}
	public static class NtlmSettings
	{
		private static NtlmAuthLevel defaultAuthLevel = NtlmAuthLevel.LM_and_NTLM_and_try_NTLMv2_Session;

		public static NtlmAuthLevel DefaultAuthLevel => defaultAuthLevel;
	}
	public class Type1Message : MessageBase
	{
		private string _host;

		private string _domain;

		public string Domain
		{
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (value == "")
				{
					base.Flags &= ~NtlmFlags.NegotiateDomainSupplied;
				}
				else
				{
					base.Flags |= NtlmFlags.NegotiateDomainSupplied;
				}
				_domain = value;
			}
		}

		public string Host
		{
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (value == "")
				{
					base.Flags &= ~NtlmFlags.NegotiateWorkstationSupplied;
				}
				else
				{
					base.Flags |= NtlmFlags.NegotiateWorkstationSupplied;
				}
				_host = value;
			}
		}

		public Type1Message()
			: base(1)
		{
			_domain = Environment.UserDomainName;
			_host = Environment.MachineName;
			base.Flags = NtlmFlags.NegotiateUnicode | NtlmFlags.NegotiateOem | NtlmFlags.RequestTarget | NtlmFlags.NegotiateNtlm | NtlmFlags.NegotiateDomainSupplied | NtlmFlags.NegotiateWorkstationSupplied | NtlmFlags.NegotiateAlwaysSign;
		}

		protected override void Decode(byte[] message)
		{
			base.Decode(message);
			base.Flags = (NtlmFlags)Mono.Security.BitConverterLE.ToUInt32(message, 12);
			int count = Mono.Security.BitConverterLE.ToUInt16(message, 16);
			int index = Mono.Security.BitConverterLE.ToUInt16(message, 20);
			_domain = Encoding.ASCII.GetString(message, index, count);
			int count2 = Mono.Security.BitConverterLE.ToUInt16(message, 24);
			_host = Encoding.ASCII.GetString(message, 32, count2);
		}

		public override byte[] GetBytes()
		{
			short num = (short)_domain.Length;
			short num2 = (short)_host.Length;
			byte[] array = PrepareMessage(32 + num + num2);
			array[12] = (byte)base.Flags;
			array[13] = (byte)((uint)base.Flags >> 8);
			array[14] = (byte)((uint)base.Flags >> 16);
			array[15] = (byte)((uint)base.Flags >> 24);
			short num3 = (short)(32 + num2);
			array[16] = (byte)num;
			array[17] = (byte)(num >> 8);
			array[18] = array[16];
			array[19] = array[17];
			array[20] = (byte)num3;
			array[21] = (byte)(num3 >> 8);
			array[24] = (byte)num2;
			array[25] = (byte)(num2 >> 8);
			array[26] = array[24];
			array[27] = array[25];
			array[28] = 32;
			array[29] = 0;
			byte[] bytes = Encoding.ASCII.GetBytes(_host.ToUpper(CultureInfo.InvariantCulture));
			Buffer.BlockCopy(bytes, 0, array, 32, bytes.Length);
			byte[] bytes2 = Encoding.ASCII.GetBytes(_domain.ToUpper(CultureInfo.InvariantCulture));
			Buffer.BlockCopy(bytes2, 0, array, num3, bytes2.Length);
			return array;
		}
	}
	public class Type2Message : MessageBase
	{
		private byte[] _nonce;

		private string _targetName;

		private byte[] _targetInfo;

		public byte[] Nonce => (byte[])_nonce.Clone();

		public string TargetName => _targetName;

		public byte[] TargetInfo => (byte[])_targetInfo.Clone();

		public Type2Message(byte[] message)
			: base(2)
		{
			_nonce = new byte[8];
			Decode(message);
		}

		~Type2Message()
		{
			if (_nonce != null)
			{
				Array.Clear(_nonce, 0, _nonce.Length);
			}
		}

		protected override void Decode(byte[] message)
		{
			base.Decode(message);
			base.Flags = (NtlmFlags)Mono.Security.BitConverterLE.ToUInt32(message, 20);
			Buffer.BlockCopy(message, 24, _nonce, 0, 8);
			ushort num = Mono.Security.BitConverterLE.ToUInt16(message, 12);
			ushort index = Mono.Security.BitConverterLE.ToUInt16(message, 16);
			if (num > 0)
			{
				if ((base.Flags & NtlmFlags.NegotiateOem) != 0)
				{
					_targetName = Encoding.ASCII.GetString(message, index, num);
				}
				else
				{
					_targetName = Encoding.Unicode.GetString(message, index, num);
				}
			}
			if (message.Length >= 48)
			{
				ushort num2 = Mono.Security.BitConverterLE.ToUInt16(message, 40);
				ushort srcOffset = Mono.Security.BitConverterLE.ToUInt16(message, 44);
				if (num2 > 0)
				{
					_targetInfo = new byte[num2];
					Buffer.BlockCopy(message, srcOffset, _targetInfo, 0, num2);
				}
			}
		}

		public override byte[] GetBytes()
		{
			byte[] array = PrepareMessage(40);
			short num = (short)array.Length;
			array[16] = (byte)num;
			array[17] = (byte)(num >> 8);
			array[20] = (byte)base.Flags;
			array[21] = (byte)((uint)base.Flags >> 8);
			array[22] = (byte)((uint)base.Flags >> 16);
			array[23] = (byte)((uint)base.Flags >> 24);
			Buffer.BlockCopy(_nonce, 0, array, 24, _nonce.Length);
			return array;
		}
	}
	public class Type3Message : MessageBase
	{
		private NtlmAuthLevel _level;

		private byte[] _challenge;

		private string _host;

		private string _domain;

		private string _username;

		private string _password;

		private Type2Message _type2;

		private byte[] _lm;

		private byte[] _nt;

		public string Domain
		{
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (value == "")
				{
					base.Flags &= ~NtlmFlags.NegotiateDomainSupplied;
				}
				else
				{
					base.Flags |= NtlmFlags.NegotiateDomainSupplied;
				}
				_domain = value;
			}
		}

		public string Password
		{
			set
			{
				_password = value;
			}
		}

		public string Username
		{
			set
			{
				_username = value;
			}
		}

		public Type3Message(Type2Message type2)
			: base(3)
		{
			_type2 = type2;
			_level = NtlmSettings.DefaultAuthLevel;
			_challenge = (byte[])type2.Nonce.Clone();
			_domain = type2.TargetName;
			_host = Environment.MachineName;
			_username = Environment.UserName;
			base.Flags = NtlmFlags.NegotiateNtlm | NtlmFlags.NegotiateAlwaysSign;
			if ((type2.Flags & NtlmFlags.NegotiateUnicode) != 0)
			{
				base.Flags |= NtlmFlags.NegotiateUnicode;
			}
			else
			{
				base.Flags |= NtlmFlags.NegotiateOem;
			}
			if ((type2.Flags & NtlmFlags.NegotiateNtlm2Key) != 0)
			{
				base.Flags |= NtlmFlags.NegotiateNtlm2Key;
			}
		}

		~Type3Message()
		{
			if (_challenge != null)
			{
				Array.Clear(_challenge, 0, _challenge.Length);
			}
			if (_lm != null)
			{
				Array.Clear(_lm, 0, _lm.Length);
			}
			if (_nt != null)
			{
				Array.Clear(_nt, 0, _nt.Length);
			}
		}

		protected override void Decode(byte[] message)
		{
			base.Decode(message);
			_password = null;
			if (message.Length >= 64)
			{
				base.Flags = (NtlmFlags)Mono.Security.BitConverterLE.ToUInt32(message, 60);
			}
			else
			{
				base.Flags = NtlmFlags.NegotiateUnicode | NtlmFlags.NegotiateNtlm | NtlmFlags.NegotiateAlwaysSign;
			}
			int num = Mono.Security.BitConverterLE.ToUInt16(message, 12);
			int srcOffset = Mono.Security.BitConverterLE.ToUInt16(message, 16);
			_lm = new byte[num];
			Buffer.BlockCopy(message, srcOffset, _lm, 0, num);
			int num2 = Mono.Security.BitConverterLE.ToUInt16(message, 20);
			int srcOffset2 = Mono.Security.BitConverterLE.ToUInt16(message, 24);
			_nt = new byte[num2];
			Buffer.BlockCopy(message, srcOffset2, _nt, 0, num2);
			int len = Mono.Security.BitConverterLE.ToUInt16(message, 28);
			int offset = Mono.Security.BitConverterLE.ToUInt16(message, 32);
			_domain = DecodeString(message, offset, len);
			int len2 = Mono.Security.BitConverterLE.ToUInt16(message, 36);
			int offset2 = Mono.Security.BitConverterLE.ToUInt16(message, 40);
			_username = DecodeString(message, offset2, len2);
			int len3 = Mono.Security.BitConverterLE.ToUInt16(message, 44);
			int offset3 = Mono.Security.BitConverterLE.ToUInt16(message, 48);
			_host = DecodeString(message, offset3, len3);
		}

		private string DecodeString(byte[] buffer, int offset, int len)
		{
			if ((base.Flags & NtlmFlags.NegotiateUnicode) != 0)
			{
				return Encoding.Unicode.GetString(buffer, offset, len);
			}
			return Encoding.ASCII.GetString(buffer, offset, len);
		}

		private byte[] EncodeString(string text)
		{
			if (text == null)
			{
				return new byte[0];
			}
			if ((base.Flags & NtlmFlags.NegotiateUnicode) != 0)
			{
				return Encoding.Unicode.GetBytes(text);
			}
			return Encoding.ASCII.GetBytes(text);
		}

		public override byte[] GetBytes()
		{
			byte[] array = EncodeString(_domain);
			byte[] array2 = EncodeString(_username);
			byte[] array3 = EncodeString(_host);
			byte[] lm;
			byte[] ntlm;
			if (_type2 == null)
			{
				if (_level != NtlmAuthLevel.LM_and_NTLM)
				{
					throw new InvalidOperationException("Refusing to use legacy-mode LM/NTLM authentication unless explicitly enabled using DefaultAuthLevel.");
				}
				using ChallengeResponse challengeResponse = new ChallengeResponse(_password, _challenge);
				lm = challengeResponse.LM;
				ntlm = challengeResponse.NT;
			}
			else
			{
				ChallengeResponse2.Compute(_type2, _level, _username, _password, _domain, out lm, out ntlm);
			}
			int num = ((lm != null) ? lm.Length : 0);
			int num2 = ((ntlm != null) ? ntlm.Length : 0);
			byte[] array4 = PrepareMessage(64 + array.Length + array2.Length + array3.Length + num + num2);
			short num3 = (short)(64 + array.Length + array2.Length + array3.Length);
			array4[12] = (byte)num;
			array4[13] = 0;
			array4[14] = (byte)num;
			array4[15] = 0;
			array4[16] = (byte)num3;
			array4[17] = (byte)(num3 >> 8);
			short num4 = (short)(num3 + num);
			array4[20] = (byte)num2;
			array4[21] = (byte)(num2 >> 8);
			array4[22] = (byte)num2;
			array4[23] = (byte)(num2 >> 8);
			array4[24] = (byte)num4;
			array4[25] = (byte)(num4 >> 8);
			short num5 = (short)array.Length;
			short num6 = 64;
			array4[28] = (byte)num5;
			array4[29] = (byte)(num5 >> 8);
			array4[30] = array4[28];
			array4[31] = array4[29];
			array4[32] = (byte)num6;
			array4[33] = (byte)(num6 >> 8);
			short num7 = (short)array2.Length;
			short num8 = (short)(num6 + num5);
			array4[36] = (byte)num7;
			array4[37] = (byte)(num7 >> 8);
			array4[38] = array4[36];
			array4[39] = array4[37];
			array4[40] = (byte)num8;
			array4[41] = (byte)(num8 >> 8);
			short num9 = (short)array3.Length;
			short num10 = (short)(num8 + num7);
			array4[44] = (byte)num9;
			array4[45] = (byte)(num9 >> 8);
			array4[46] = array4[44];
			array4[47] = array4[45];
			array4[48] = (byte)num10;
			array4[49] = (byte)(num10 >> 8);
			short num11 = (short)array4.Length;
			array4[56] = (byte)num11;
			array4[57] = (byte)(num11 >> 8);
			int flags = (int)base.Flags;
			array4[60] = (byte)flags;
			array4[61] = (byte)((uint)flags >> 8);
			array4[62] = (byte)((uint)flags >> 16);
			array4[63] = (byte)((uint)flags >> 24);
			Buffer.BlockCopy(array, 0, array4, num6, array.Length);
			Buffer.BlockCopy(array2, 0, array4, num8, array2.Length);
			Buffer.BlockCopy(array3, 0, array4, num10, array3.Length);
			if (lm != null)
			{
				Buffer.BlockCopy(lm, 0, array4, num3, lm.Length);
				Array.Clear(lm, 0, lm.Length);
			}
			Buffer.BlockCopy(ntlm, 0, array4, num4, ntlm.Length);
			Array.Clear(ntlm, 0, ntlm.Length);
			return array4;
		}
	}
}
namespace Mono.Security.Interface
{
	public enum AlertLevel : byte
	{
		Warning = 1,
		Fatal
	}
	public enum AlertDescription : byte
	{
		CloseNotify = 0,
		UnexpectedMessage = 10,
		BadRecordMAC = 20,
		DecryptionFailed_RESERVED = 21,
		RecordOverflow = 22,
		DecompressionFailure = 30,
		HandshakeFailure = 40,
		NoCertificate_RESERVED = 41,
		BadCertificate = 42,
		UnsupportedCertificate = 43,
		CertificateRevoked = 44,
		CertificateExpired = 45,
		CertificateUnknown = 46,
		IlegalParameter = 47,
		UnknownCA = 48,
		AccessDenied = 49,
		DecodeError = 50,
		DecryptError = 51,
		ExportRestriction = 60,
		ProtocolVersion = 70,
		InsuficientSecurity = 71,
		InternalError = 80,
		UserCancelled = 90,
		NoRenegotiation = 100,
		UnsupportedExtension = 110
	}
	public class Alert
	{
		private AlertLevel level;

		private AlertDescription description;

		public AlertLevel Level => level;

		public AlertDescription Description => description;

		public Alert(AlertDescription description)
		{
			this.description = description;
			inferAlertLevel();
		}

		private void inferAlertLevel()
		{
			switch (description)
			{
			case AlertDescription.CloseNotify:
			case AlertDescription.UserCancelled:
			case AlertDescription.NoRenegotiation:
				level = AlertLevel.Warning;
				break;
			default:
				level = AlertLevel.Fatal;
				break;
			}
		}

		public override string ToString()
		{
			return $"[Alert: {Level}:{Description}]";
		}
	}
	public class ValidationResult
	{
		private bool trusted;

		private bool user_denied;

		private int error_code;

		private MonoSslPolicyErrors? policy_errors;

		public bool Trusted => trusted;

		public bool UserDenied => user_denied;

		public ValidationResult(bool trusted, bool user_denied, int error_code, MonoSslPolicyErrors? policy_errors)
		{
			this.trusted = trusted;
			this.user_denied = user_denied;
			this.error_code = error_code;
			this.policy_errors = policy_errors;
		}
	}
	public interface ICertificateValidator
	{
	}
	public enum CipherAlgorithmType
	{
		None,
		Aes128,
		Aes256,
		AesGcm128,
		AesGcm256
	}
	[CLSCompliant(false)]
	public enum CipherSuiteCode : ushort
	{
		TLS_NULL_WITH_NULL_NULL = 0,
		TLS_RSA_WITH_NULL_MD5 = 1,
		TLS_RSA_WITH_NULL_SHA = 2,
		TLS_RSA_EXPORT_WITH_RC4_40_MD5 = 3,
		TLS_RSA_WITH_RC4_128_MD5 = 4,
		TLS_RSA_WITH_RC4_128_SHA = 5,
		TLS_RSA_EXPORT_WITH_RC2_CBC_40_MD5 = 6,
		TLS_RSA_WITH_IDEA_CBC_SHA = 7,
		TLS_RSA_EXPORT_WITH_DES40_CBC_SHA = 8,
		TLS_RSA_WITH_DES_CBC_SHA = 9,
		TLS_RSA_WITH_3DES_EDE_CBC_SHA = 10,
		TLS_DH_DSS_EXPORT_WITH_DES40_CBC_SHA = 11,
		TLS_DH_DSS_WITH_DES_CBC_SHA = 12,
		TLS_DH_DSS_WITH_3DES_EDE_CBC_SHA = 13,
		TLS_DH_RSA_EXPORT_WITH_DES40_CBC_SHA = 14,
		TLS_DH_RSA_WITH_DES_CBC_SHA = 15,
		TLS_DH_RSA_WITH_3DES_EDE_CBC_SHA = 16,
		TLS_DHE_DSS_EXPORT_WITH_DES40_CBC_SHA = 17,
		TLS_DHE_DSS_WITH_DES_CBC_SHA = 18,
		TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA = 19,
		TLS_DHE_RSA_EXPORT_WITH_DES40_CBC_SHA = 20,
		TLS_DHE_RSA_WITH_DES_CBC_SHA = 21,
		TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA = 22,
		TLS_DH_anon_EXPORT_WITH_RC4_40_MD5 = 23,
		TLS_DH_anon_WITH_RC4_128_MD5 = 24,
		TLS_DH_anon_EXPORT_WITH_DES40_CBC_SHA = 25,
		TLS_DH_anon_WITH_DES_CBC_SHA = 26,
		TLS_DH_anon_WITH_3DES_EDE_CBC_SHA = 27,
		TLS_RSA_WITH_AES_128_CBC_SHA = 47,
		TLS_DH_DSS_WITH_AES_128_CBC_SHA = 48,
		TLS_DH_RSA_WITH_AES_128_CBC_SHA = 49,
		TLS_DHE_DSS_WITH_AES_128_CBC_SHA = 50,
		TLS_DHE_RSA_WITH_AES_128_CBC_SHA = 51,
		TLS_DH_anon_WITH_AES_128_CBC_SHA = 52,
		TLS_RSA_WITH_AES_256_CBC_SHA = 53,
		TLS_DH_DSS_WITH_AES_256_CBC_SHA = 54,
		TLS_DH_RSA_WITH_AES_256_CBC_SHA = 55,
		TLS_DHE_DSS_WITH_AES_256_CBC_SHA = 56,
		TLS_DHE_RSA_WITH_AES_256_CBC_SHA = 57,
		TLS_DH_anon_WITH_AES_256_CBC_SHA = 58,
		TLS_RSA_WITH_CAMELLIA_128_CBC_SHA = 65,
		TLS_DH_DSS_WITH_CAMELLIA_128_CBC_SHA = 66,
		TLS_DH_RSA_WITH_CAMELLIA_128_CBC_SHA = 67,
		TLS_DHE_DSS_WITH_CAMELLIA_128_CBC_SHA = 68,
		TLS_DHE_RSA_WITH_CAMELLIA_128_CBC_SHA = 69,
		TLS_DH_anon_WITH_CAMELLIA_128_CBC_SHA = 70,
		TLS_RSA_WITH_CAMELLIA_256_CBC_SHA = 132,
		TLS_DH_DSS_WITH_CAMELLIA_256_CBC_SHA = 133,
		TLS_DH_RSA_WITH_CAMELLIA_256_CBC_SHA = 134,
		TLS_DHE_DSS_WITH_CAMELLIA_256_CBC_SHA = 135,
		TLS_DHE_RSA_WITH_CAMELLIA_256_CBC_SHA = 136,
		TLS_DH_anon_WITH_CAMELLIA_256_CBC_SHA = 137,
		TLS_RSA_WITH_CAMELLIA_128_CBC_SHA256 = 186,
		TLS_DH_DSS_WITH_CAMELLIA_128_CBC_SHA256 = 187,
		TLS_DH_RSA_WITH_CAMELLIA_128_CBC_SHA256 = 188,
		TLS_DHE_DSS_WITH_CAMELLIA_128_CBC_SHA256 = 189,
		TLS_DHE_RSA_WITH_CAMELLIA_128_CBC_SHA256 = 190,
		TLS_DH_anon_WITH_CAMELLIA_128_CBC_SHA256 = 191,
		TLS_RSA_WITH_CAMELLIA_256_CBC_SHA256 = 192,
		TLS_DH_DSS_WITH_CAMELLIA_256_CBC_SHA256 = 193,
		TLS_DH_RSA_WITH_CAMELLIA_256_CBC_SHA256 = 194,
		TLS_DHE_DSS_WITH_CAMELLIA_256_CBC_SHA256 = 195,
		TLS_DHE_RSA_WITH_CAMELLIA_256_CBC_SHA256 = 196,
		TLS_DH_anon_WITH_CAMELLIA_256_CBC_SHA256 = 197,
		TLS_RSA_WITH_SEED_CBC_SHA = 150,
		TLS_DH_DSS_WITH_SEED_CBC_SHA = 151,
		TLS_DH_RSA_WITH_SEED_CBC_SHA = 152,
		TLS_DHE_DSS_WITH_SEED_CBC_SHA = 153,
		TLS_DHE_RSA_WITH_SEED_CBC_SHA = 154,
		TLS_DH_anon_WITH_SEED_CBC_SHA = 155,
		TLS_PSK_WITH_RC4_128_SHA = 138,
		TLS_PSK_WITH_3DES_EDE_CBC_SHA = 139,
		TLS_PSK_WITH_AES_128_CBC_SHA = 140,
		TLS_PSK_WITH_AES_256_CBC_SHA = 141,
		TLS_DHE_PSK_WITH_RC4_128_SHA = 142,
		TLS_DHE_PSK_WITH_3DES_EDE_CBC_SHA = 143,
		TLS_DHE_PSK_WITH_AES_128_CBC_SHA = 144,
		TLS_DHE_PSK_WITH_AES_256_CBC_SHA = 145,
		TLS_RSA_PSK_WITH_RC4_128_SHA = 146,
		TLS_RSA_PSK_WITH_3DES_EDE_CBC_SHA = 147,
		TLS_RSA_PSK_WITH_AES_128_CBC_SHA = 148,
		TLS_RSA_PSK_WITH_AES_256_CBC_SHA = 149,
		TLS_ECDH_ECDSA_WITH_NULL_SHA = 49153,
		TLS_ECDH_ECDSA_WITH_RC4_128_SHA = 49154,
		TLS_ECDH_ECDSA_WITH_3DES_EDE_CBC_SHA = 49155,
		TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA = 49156,
		TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA = 49157,
		TLS_ECDHE_ECDSA_WITH_NULL_SHA = 49158,
		TLS_ECDHE_ECDSA_WITH_RC4_128_SHA = 49159,
		TLS_ECDHE_ECDSA_WITH_3DES_EDE_CBC_SHA = 49160,
		TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA = 49161,
		TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA = 49162,
		TLS_ECDH_RSA_WITH_NULL_SHA = 49163,
		TLS_ECDH_RSA_WITH_RC4_128_SHA = 49164,
		TLS_ECDH_RSA_WITH_3DES_EDE_CBC_SHA = 49165,
		TLS_ECDH_RSA_WITH_AES_128_CBC_SHA = 49166,
		TLS_ECDH_RSA_WITH_AES_256_CBC_SHA = 49167,
		TLS_ECDHE_RSA_WITH_NULL_SHA = 49168,
		TLS_ECDHE_RSA_WITH_RC4_128_SHA = 49169,
		TLS_ECDHE_RSA_WITH_3DES_EDE_CBC_SHA = 49170,
		TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA = 49171,
		TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA = 49172,
		TLS_ECDH_anon_WITH_NULL_SHA = 49173,
		TLS_ECDH_anon_WITH_RC4_128_SHA = 49174,
		TLS_ECDH_anon_WITH_3DES_EDE_CBC_SHA = 49175,
		TLS_ECDH_anon_WITH_AES_128_CBC_SHA = 49176,
		TLS_ECDH_anon_WITH_AES_256_CBC_SHA = 49177,
		TLS_PSK_WITH_NULL_SHA = 44,
		TLS_DHE_PSK_WITH_NULL_SHA = 45,
		TLS_RSA_PSK_WITH_NULL_SHA = 46,
		TLS_SRP_SHA_WITH_3DES_EDE_CBC_SHA = 49178,
		TLS_SRP_SHA_RSA_WITH_3DES_EDE_CBC_SHA = 49179,
		TLS_SRP_SHA_DSS_WITH_3DES_EDE_CBC_SHA = 49180,
		TLS_SRP_SHA_WITH_AES_128_CBC_SHA = 49181,
		TLS_SRP_SHA_RSA_WITH_AES_128_CBC_SHA = 49182,
		TLS_SRP_SHA_DSS_WITH_AES_128_CBC_SHA = 49183,
		TLS_SRP_SHA_WITH_AES_256_CBC_SHA = 49184,
		TLS_SRP_SHA_RSA_WITH_AES_256_CBC_SHA = 49185,
		TLS_SRP_SHA_DSS_WITH_AES_256_CBC_SHA = 49186,
		TLS_RSA_WITH_NULL_SHA256 = 59,
		TLS_RSA_WITH_AES_128_CBC_SHA256 = 60,
		TLS_RSA_WITH_AES_256_CBC_SHA256 = 61,
		TLS_DH_DSS_WITH_AES_128_CBC_SHA256 = 62,
		TLS_DH_RSA_WITH_AES_128_CBC_SHA256 = 63,
		TLS_DHE_DSS_WITH_AES_128_CBC_SHA256 = 64,
		TLS_DHE_RSA_WITH_AES_128_CBC_SHA256 = 103,
		TLS_DH_DSS_WITH_AES_256_CBC_SHA256 = 104,
		TLS_DH_RSA_WITH_AES_256_CBC_SHA256 = 105,
		TLS_DHE_DSS_WITH_AES_256_CBC_SHA256 = 106,
		TLS_DHE_RSA_WITH_AES_256_CBC_SHA256 = 107,
		TLS_DH_anon_WITH_AES_128_CBC_SHA256 = 108,
		TLS_DH_anon_WITH_AES_256_CBC_SHA256 = 109,
		TLS_RSA_WITH_AES_128_GCM_SHA256 = 156,
		TLS_RSA_WITH_AES_256_GCM_SHA384 = 157,
		TLS_DHE_RSA_WITH_AES_128_GCM_SHA256 = 158,
		TLS_DHE_RSA_WITH_AES_256_GCM_SHA384 = 159,
		TLS_DH_RSA_WITH_AES_128_GCM_SHA256 = 160,
		TLS_DH_RSA_WITH_AES_256_GCM_SHA384 = 161,
		TLS_DHE_DSS_WITH_AES_128_GCM_SHA256 = 162,
		TLS_DHE_DSS_WITH_AES_256_GCM_SHA384 = 163,
		TLS_DH_DSS_WITH_AES_128_GCM_SHA256 = 164,
		TLS_DH_DSS_WITH_AES_256_GCM_SHA384 = 165,
		TLS_DH_anon_WITH_AES_128_GCM_SHA256 = 166,
		TLS_DH_anon_WITH_AES_256_GCM_SHA384 = 167,
		TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256 = 49187,
		TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384 = 49188,
		TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA256 = 49189,
		TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA384 = 49190,
		TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256 = 49191,
		TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384 = 49192,
		TLS_ECDH_RSA_WITH_AES_128_CBC_SHA256 = 49193,
		TLS_ECDH_RSA_WITH_AES_256_CBC_SHA384 = 49194,
		TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256 = 49195,
		TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384 = 49196,
		TLS_ECDH_ECDSA_WITH_AES_128_GCM_SHA256 = 49197,
		TLS_ECDH_ECDSA_WITH_AES_256_GCM_SHA384 = 49198,
		TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256 = 49199,
		TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384 = 49200,
		TLS_ECDH_RSA_WITH_AES_128_GCM_SHA256 = 49201,
		TLS_ECDH_RSA_WITH_AES_256_GCM_SHA384 = 49202,
		TLS_PSK_WITH_AES_128_GCM_SHA256 = 168,
		TLS_PSK_WITH_AES_256_GCM_SHA384 = 169,
		TLS_DHE_PSK_WITH_AES_128_GCM_SHA256 = 170,
		TLS_DHE_PSK_WITH_AES_256_GCM_SHA384 = 171,
		TLS_RSA_PSK_WITH_AES_128_GCM_SHA256 = 172,
		TLS_RSA_PSK_WITH_AES_256_GCM_SHA384 = 173,
		TLS_PSK_WITH_AES_128_CBC_SHA256 = 174,
		TLS_PSK_WITH_AES_256_CBC_SHA384 = 175,
		TLS_PSK_WITH_NULL_SHA256 = 176,
		TLS_PSK_WITH_NULL_SHA384 = 177,
		TLS_DHE_PSK_WITH_AES_128_CBC_SHA256 = 178,
		TLS_DHE_PSK_WITH_AES_256_CBC_SHA384 = 179,
		TLS_DHE_PSK_WITH_NULL_SHA256 = 180,
		TLS_DHE_PSK_WITH_NULL_SHA384 = 181,
		TLS_RSA_PSK_WITH_AES_128_CBC_SHA256 = 182,
		TLS_RSA_PSK_WITH_AES_256_CBC_SHA384 = 183,
		TLS_RSA_PSK_WITH_NULL_SHA256 = 184,
		TLS_RSA_PSK_WITH_NULL_SHA384 = 185,
		TLS_ECDHE_PSK_WITH_RC4_128_SHA = 49203,
		TLS_ECDHE_PSK_WITH_3DES_EDE_CBC_SHA = 49204,
		TLS_ECDHE_PSK_WITH_AES_128_CBC_SHA = 49205,
		TLS_ECDHE_PSK_WITH_AES_256_CBC_SHA = 49206,
		TLS_ECDHE_PSK_WITH_AES_128_CBC_SHA256 = 49207,
		TLS_ECDHE_PSK_WITH_AES_256_CBC_SHA384 = 49208,
		TLS_ECDHE_PSK_WITH_NULL_SHA = 49209,
		TLS_ECDHE_PSK_WITH_NULL_SHA256 = 49210,
		TLS_ECDHE_PSK_WITH_NULL_SHA384 = 49211,
		TLS_EMPTY_RENEGOTIATION_INFO_SCSV = 255,
		TLS_ECDHE_ECDSA_WITH_CAMELLIA_128_CBC_SHA256 = 49266,
		TLS_ECDHE_ECDSA_WITH_CAMELLIA_256_CBC_SHA384 = 49267,
		TLS_ECDH_ECDSA_WITH_CAMELLIA_128_CBC_SHA256 = 49268,
		TLS_ECDH_ECDSA_WITH_CAMELLIA_256_CBC_SHA384 = 49269,
		TLS_ECDHE_RSA_WITH_CAMELLIA_128_CBC_SHA256 = 49270,
		TLS_ECDHE_RSA_WITH_CAMELLIA_256_CBC_SHA384 = 49271,
		TLS_ECDH_RSA_WITH_CAMELLIA_128_CBC_SHA256 = 49272,
		TLS_ECDH_RSA_WITH_CAMELLIA_256_CBC_SHA384 = 49273,
		TLS_RSA_WITH_CAMELLIA_128_GCM_SHA256 = 49274,
		TLS_RSA_WITH_CAMELLIA_256_GCM_SHA384 = 49275,
		TLS_DHE_RSA_WITH_CAMELLIA_128_GCM_SHA256 = 49276,
		TLS_DHE_RSA_WITH_CAMELLIA_256_GCM_SHA384 = 49277,
		TLS_DH_RSA_WITH_CAMELLIA_128_GCM_SHA256 = 49278,
		TLS_DH_RSA_WITH_CAMELLIA_256_GCM_SHA384 = 49279,
		TLS_DHE_DSS_WITH_CAMELLIA_128_GCM_SHA256 = 49280,
		TLS_DHE_DSS_WITH_CAMELLIA_256_GCM_SHA384 = 49281,
		TLS_DH_DSS_WITH_CAMELLIA_128_GCM_SHA256 = 49282,
		TLS_DH_DSS_WITH_CAMELLIA_256_GCM_SHA384 = 49283,
		TLS_DH_anon_WITH_CAMELLIA_128_GCM_SHA256 = 49284,
		TLS_DH_anon_WITH_CAMELLIA_256_GCM_SHA384 = 49285,
		TLS_ECDHE_ECDSA_WITH_CAMELLIA_128_GCM_SHA256 = 49286,
		TLS_ECDHE_ECDSA_WITH_CAMELLIA_256_GCM_SHA384 = 49287,
		TLS_ECDH_ECDSA_WITH_CAMELLIA_128_GCM_SHA256 = 49288,
		TLS_ECDH_ECDSA_WITH_CAMELLIA_256_GCM_SHA384 = 49289,
		TLS_ECDHE_RSA_WITH_CAMELLIA_128_GCM_SHA256 = 49290,
		TLS_ECDHE_RSA_WITH_CAMELLIA_256_GCM_SHA384 = 49291,
		TLS_ECDH_RSA_WITH_CAMELLIA_128_GCM_SHA256 = 49292,
		TLS_ECDH_RSA_WITH_CAMELLIA_256_GCM_SHA384 = 49293,
		TLS_PSK_WITH_CAMELLIA_128_GCM_SHA256 = 49294,
		TLS_PSK_WITH_CAMELLIA_256_GCM_SHA384 = 49295,
		TLS_DHE_PSK_WITH_CAMELLIA_128_GCM_SHA256 = 49296,
		TLS_DHE_PSK_WITH_CAMELLIA_256_GCM_SHA384 = 49297,
		TLS_RSA_PSK_WITH_CAMELLIA_128_GCM_SHA256 = 49298,
		TLS_RSA_PSK_WITH_CAMELLIA_256_GCM_SHA384 = 49299,
		TLS_PSK_WITH_CAMELLIA_128_CBC_SHA256 = 49300,
		TLS_PSK_WITH_CAMELLIA_256_CBC_SHA384 = 49301,
		TLS_DHE_PSK_WITH_CAMELLIA_128_CBC_SHA256 = 49302,
		TLS_DHE_PSK_WITH_CAMELLIA_256_CBC_SHA384 = 49303,
		TLS_RSA_PSK_WITH_CAMELLIA_128_CBC_SHA256 = 49304,
		TLS_RSA_PSK_WITH_CAMELLIA_256_CBC_SHA384 = 49305,
		TLS_ECDHE_PSK_WITH_CAMELLIA_128_CBC_SHA256 = 49306,
		TLS_ECDHE_PSK_WITH_CAMELLIA_256_CBC_SHA384 = 49307,
		TLS_RSA_WITH_AES_128_CCM = 49308,
		TLS_RSA_WITH_AES_256_CCM = 49309,
		TLS_DHE_RSA_WITH_AES_128_CCM = 49310,
		TLS_DHE_RSA_WITH_AES_256_CCM = 49311,
		TLS_RSA_WITH_AES_128_CCM_8 = 49312,
		TLS_RSA_WITH_AES_256_CCM_8 = 49313,
		TLS_DHE_RSA_WITH_AES_128_CCM_8 = 49314,
		TLS_DHE_RSA_WITH_AES_256_CCM_8 = 49315,
		TLS_PSK_WITH_AES_128_CCM = 49316,
		TLS_PSK_WITH_AES_256_CCM = 49317,
		TLS_DHE_PSK_WITH_AES_128_CCM = 49318,
		TLS_DHE_PSK_WITH_AES_256_CCM = 49319,
		TLS_PSK_WITH_AES_128_CCM_8 = 49320,
		TLS_PSK_WITH_AES_256_CCM_8 = 49321,
		TLS_PSK_DHE_WITH_AES_128_CCM_8 = 49322,
		TLS_PSK_DHE_WITH_AES_256_CCM_8 = 49323,
		TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256 = 52243,
		TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256 = 52244,
		TLS_DHE_RSA_WITH_CHACHA20_POLY1305_SHA256 = 52245,
		TLS_RSA_WITH_ESTREAM_SALSA20_SHA1 = 58384,
		TLS_RSA_WITH_SALSA20_SHA1 = 58385,
		TLS_ECDHE_RSA_WITH_ESTREAM_SALSA20_SHA1 = 58386,
		TLS_ECDHE_RSA_WITH_SALSA20_SHA1 = 58387,
		TLS_ECDHE_ECDSA_WITH_ESTREAM_SALSA20_SHA1 = 58388,
		TLS_ECDHE_ECDSA_WITH_SALSA20_SHA1 = 58389,
		TLS_PSK_WITH_ESTREAM_SALSA20_SHA1 = 58390,
		TLS_PSK_WITH_SALSA20_SHA1 = 58391,
		TLS_ECDHE_PSK_WITH_ESTREAM_SALSA20_SHA1 = 58392,
		TLS_ECDHE_PSK_WITH_SALSA20_SHA1 = 58393,
		TLS_RSA_PSK_WITH_ESTREAM_SALSA20_SHA1 = 58394,
		TLS_RSA_PSK_WITH_SALSA20_SHA1 = 58395,
		TLS_DHE_PSK_WITH_ESTREAM_SALSA20_SHA1 = 58396,
		TLS_DHE_PSK_WITH_SALSA20_SHA1 = 58397,
		TLS_DHE_RSA_WITH_ESTREAM_SALSA20_SHA1 = 58398,
		TLS_DHE_RSA_WITH_SALSA20_SHA1 = 58399,
		TLS_FALLBACK_SCSV = 22016
	}
	public enum ExchangeAlgorithmType
	{
		None,
		Dhe,
		Rsa,
		EcDhe
	}
	public enum HashAlgorithmType
	{
		None = 0,
		Md5 = 1,
		Sha1 = 2,
		Sha224 = 3,
		Sha256 = 4,
		Sha384 = 5,
		Sha512 = 6,
		Unknown = 255,
		Md5Sha1 = 254
	}
	internal interface IMonoSslClientAuthenticationOptions
	{
	}
	public class MonoTlsConnectionInfo
	{
		[CompilerGenerated]
		private string <PeerDomainName>k__BackingField;

		[CLSCompliant(false)]
		public CipherSuiteCode CipherSuiteCode { get; set; }

		public TlsProtocols ProtocolVersion { get; set; }

		public CipherAlgorithmType CipherAlgorithmType { get; }

		public HashAlgorithmType HashAlgorithmType { get; }

		public ExchangeAlgorithmType ExchangeAlgorithmType { get; }

		public string PeerDomainName
		{
			[CompilerGenerated]
			set
			{
				<PeerDomainName>k__BackingField = value;
			}
		}

		public override string ToString()
		{
			return $"[MonoTlsConnectionInfo: {ProtocolVersion}:{CipherSuiteCode}]";
		}
	}
	[Flags]
	public enum MonoSslPolicyErrors
	{
		None = 0,
		RemoteCertificateNotAvailable = 1,
		RemoteCertificateNameMismatch = 2,
		RemoteCertificateChainErrors = 4
	}
	public delegate bool MonoRemoteCertificateValidationCallback(string targetHost, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, MonoSslPolicyErrors sslPolicyErrors);
	public delegate System.Security.Cryptography.X509Certificates.X509Certificate MonoLocalCertificateSelectionCallback(string targetHost, System.Security.Cryptography.X509Certificates.X509CertificateCollection localCertificates, System.Security.Cryptography.X509Certificates.X509Certificate remoteCertificate, string[] acceptableIssuers);
	public abstract class MonoTlsProvider
	{
		public abstract Guid ID { get; }

		internal MonoTlsProvider()
		{
		}
	}
	public static class MonoTlsProviderFactory
	{
		public static MonoTlsProvider GetProvider()
		{
			return (MonoTlsProvider)NoReflectionHelper.GetProvider();
		}
	}
	public sealed class MonoTlsSettings
	{
		private bool cloned;

		private bool checkCertName = true;

		private bool checkCertRevocationStatus;

		private bool? useServicePointManagerCallback;

		private bool skipSystemValidators;

		private bool callbackNeedsChain = true;

		private ICertificateValidator certificateValidator;

		private static MonoTlsSettings defaultSettings;

		public MonoRemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

		public MonoLocalCertificateSelectionCallback ClientCertificateSelectionCallback { get; set; }

		public bool? UseServicePointManagerCallback
		{
			get
			{
				return useServicePointManagerCallback;
			}
			set
			{
				useServicePointManagerCallback = value;
			}
		}

		public bool CallbackNeedsCertificateChain => callbackNeedsChain;

		public DateTime? CertificateValidationTime { get; set; }

		public System.Security.Cryptography.X509Certificates.X509CertificateCollection TrustAnchors { get; set; }

		public object UserSettings { get; set; }

		internal string[] CertificateSearchPaths { get; set; }

		internal bool SendCloseNotify { get; set; }

		public string[] ClientCertificateIssuers { get; set; }

		public bool DisallowUnauthenticatedCertificateRequest { get; set; }

		public TlsProtocols? EnabledProtocols { get; set; }

		[CLSCompliant(false)]
		public CipherSuiteCode[] EnabledCiphers { get; set; }

		public static MonoTlsSettings DefaultSettings
		{
			get
			{
				if (defaultSettings == null)
				{
					Interlocked.CompareExchange(ref defaultSettings, new MonoTlsSettings(), null);
				}
				return defaultSettings;
			}
		}

		public ICertificateValidator CertificateValidator => certificateValidator;

		public MonoTlsSettings()
		{
		}

		public static MonoTlsSettings CopyDefaultSettings()
		{
			return DefaultSettings.Clone();
		}

		public MonoTlsSettings CloneWithValidator(ICertificateValidator validator)
		{
			if (cloned)
			{
				certificateValidator = validator;
				return this;
			}
			return new MonoTlsSettings(this)
			{
				certificateValidator = validator
			};
		}

		public MonoTlsSettings Clone()
		{
			return new MonoTlsSettings(this);
		}

		private MonoTlsSettings(MonoTlsSettings other)
		{
			RemoteCertificateValidationCallback = other.RemoteCertificateValidationCallback;
			ClientCertificateSelectionCallback = other.ClientCertificateSelectionCallback;
			checkCertName = other.checkCertName;
			checkCertRevocationStatus = other.checkCertRevocationStatus;
			UseServicePointManagerCallback = other.useServicePointManagerCallback;
			skipSystemValidators = other.skipSystemValidators;
			callbackNeedsChain = other.callbackNeedsChain;
			UserSettings = other.UserSettings;
			EnabledProtocols = other.EnabledProtocols;
			EnabledCiphers = other.EnabledCiphers;
			CertificateValidationTime = other.CertificateValidationTime;
			SendCloseNotify = other.SendCloseNotify;
			ClientCertificateIssuers = other.ClientCertificateIssuers;
			DisallowUnauthenticatedCertificateRequest = other.DisallowUnauthenticatedCertificateRequest;
			if (other.TrustAnchors != null)
			{
				TrustAnchors = new System.Security.Cryptography.X509Certificates.X509CertificateCollection(other.TrustAnchors);
			}
			if (other.CertificateSearchPaths != null)
			{
				CertificateSearchPaths = new string[other.CertificateSearchPaths.Length];
				other.CertificateSearchPaths.CopyTo(CertificateSearchPaths, 0);
			}
			cloned = true;
		}
	}
	public sealed class TlsException : Exception
	{
		private Alert alert;

		public TlsException(Alert alert)
			: this(alert, alert.Description.ToString())
		{
		}

		public TlsException(Alert alert, string message)
			: base(message)
		{
			this.alert = alert;
		}

		public TlsException(AlertDescription description)
			: this(new Alert(description))
		{
		}

		public TlsException(AlertDescription description, string message)
			: this(new Alert(description), message)
		{
		}
	}
	public enum TlsProtocolCode : short
	{
		Tls10 = 769,
		Tls11,
		Tls12
	}
	[Flags]
	public enum TlsProtocols
	{
		Zero = 0,
		Tls10Client = 0x80,
		Tls10Server = 0x40,
		Tls10 = 0xC0,
		Tls11Client = 0x200,
		Tls11Server = 0x100,
		Tls11 = 0x300,
		Tls12Client = 0x800,
		Tls12Server = 0x400,
		Tls12 = 0xC00,
		ClientMask = 0xA80,
		ServerMask = 0x540
	}
}
namespace Mono.Security.Cryptography
{
	public sealed class CryptoConvert
	{
		public static string ToHex(byte[] input)
		{
			if (input == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder(input.Length * 2);
			foreach (byte b in input)
			{
				stringBuilder.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			}
			return stringBuilder.ToString();
		}

		private static byte FromHexChar(char c)
		{
			if (c >= 'a' && c <= 'f')
			{
				return (byte)(c - 97 + 10);
			}
			if (c >= 'A' && c <= 'F')
			{
				return (byte)(c - 65 + 10);
			}
			if (c >= '0' && c <= '9')
			{
				return (byte)(c - 48);
			}
			throw new ArgumentException("invalid hex char");
		}

		public static byte[] FromHex(string hex)
		{
			if (hex == null)
			{
				return null;
			}
			if ((hex.Length & 1) == 1)
			{
				throw new ArgumentException("Length must be a multiple of 2");
			}
			byte[] array = new byte[hex.Length >> 1];
			int num = 0;
			int num2 = 0;
			while (num < array.Length)
			{
				array[num] = (byte)(FromHexChar(hex[num2++]) << 4);
				array[num++] += FromHexChar(hex[num2++]);
			}
			return array;
		}
	}
	public abstract class MD4 : HashAlgorithm
	{
		protected MD4()
		{
			HashSizeValue = 128;
		}

		public static MD4 Create()
		{
			return Create("MD4");
		}

		public new static MD4 Create(string hashName)
		{
			object obj = CryptoConfig.CreateFromName(hashName);
			if (obj == null)
			{
				obj = new MD4Managed();
			}
			return (MD4)obj;
		}
	}
	public class MD4Managed : MD4
	{
		private uint[] state;

		private byte[] buffer;

		private uint[] count;

		private uint[] x;

		private byte[] digest;

		public MD4Managed()
		{
			state = new uint[4];
			count = new uint[2];
			buffer = new byte[64];
			digest = new byte[16];
			x = new uint[16];
			Initialize();
		}

		public override void Initialize()
		{
			count[0] = 0u;
			count[1] = 0u;
			state[0] = 1732584193u;
			state[1] = 4023233417u;
			state[2] = 2562383102u;
			state[3] = 271733878u;
			Array.Clear(buffer, 0, 64);
			Array.Clear(x, 0, 16);
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			int num = (int)((count[0] >> 3) & 0x3F);
			count[0] += (uint)(cbSize << 3);
			if (count[0] < cbSize << 3)
			{
				count[1]++;
			}
			count[1] += (uint)(cbSize >> 29);
			int num2 = 64 - num;
			int i = 0;
			if (cbSize >= num2)
			{
				Buffer.BlockCopy(array, ibStart, buffer, num, num2);
				MD4Transform(state, buffer, 0);
				for (i = num2; i + 63 < cbSize; i += 64)
				{
					MD4Transform(state, array, ibStart + i);
				}
				num = 0;
			}
			Buffer.BlockCopy(array, ibStart + i, buffer, num, cbSize - i);
		}

		protected override byte[] HashFinal()
		{
			byte[] array = new byte[8];
			Encode(array, count);
			uint num = (count[0] >> 3) & 0x3F;
			int num2 = (int)((num < 56) ? (56 - num) : (120 - num));
			HashCore(Padding(num2), 0, num2);
			HashCore(array, 0, 8);
			Encode(digest, state);
			Initialize();
			return digest;
		}

		private byte[] Padding(int nLength)
		{
			if (nLength > 0)
			{
				byte[] array = new byte[nLength];
				array[0] = 128;
				return array;
			}
			return null;
		}

		private uint F(uint x, uint y, uint z)
		{
			return (x & y) | (~x & z);
		}

		private uint G(uint x, uint y, uint z)
		{
			return (x & y) | (x & z) | (y & z);
		}

		private uint H(uint x, uint y, uint z)
		{
			return x ^ y ^ z;
		}

		private uint ROL(uint x, byte n)
		{
			return (x << (int)n) | (x >> 32 - n);
		}

		private void FF(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
			a += F(b, c, d) + x;
			a = ROL(a, s);
		}

		private void GG(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
			a += G(b, c, d) + x + 1518500249;
			a = ROL(a, s);
		}

		private void HH(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
			a += H(b, c, d) + x + 1859775393;
			a = ROL(a, s);
		}

		private void Encode(byte[] output, uint[] input)
		{
			int num = 0;
			for (int i = 0; i < output.Length; i += 4)
			{
				output[i] = (byte)input[num];
				output[i + 1] = (byte)(input[num] >> 8);
				output[i + 2] = (byte)(input[num] >> 16);
				output[i + 3] = (byte)(input[num] >> 24);
				num++;
			}
		}

		private void Decode(uint[] output, byte[] input, int index)
		{
			int num = 0;
			int num2 = index;
			while (num < output.Length)
			{
				output[num] = (uint)(input[num2] | (input[num2 + 1] << 8) | (input[num2 + 2] << 16) | (input[num2 + 3] << 24));
				num++;
				num2 += 4;
			}
		}

		private void MD4Transform(uint[] state, byte[] block, int index)
		{
			uint a = state[0];
			uint a2 = state[1];
			uint a3 = state[2];
			uint a4 = state[3];
			Decode(x, block, index);
			FF(ref a, a2, a3, a4, x[0], 3);
			FF(ref a4, a, a2, a3, x[1], 7);
			FF(ref a3, a4, a, a2, x[2], 11);
			FF(ref a2, a3, a4, a, x[3], 19);
			FF(ref a, a2, a3, a4, x[4], 3);
			FF(ref a4, a, a2, a3, x[5], 7);
			FF(ref a3, a4, a, a2, x[6], 11);
			FF(ref a2, a3, a4, a, x[7], 19);
			FF(ref a, a2, a3, a4, x[8], 3);
			FF(ref a4, a, a2, a3, x[9], 7);
			FF(ref a3, a4, a, a2, x[10], 11);
			FF(ref a2, a3, a4, a, x[11], 19);
			FF(ref a, a2, a3, a4, x[12], 3);
			FF(ref a4, a, a2, a3, x[13], 7);
			FF(ref a3, a4, a, a2, x[14], 11);
			FF(ref a2, a3, a4, a, x[15], 19);
			GG(ref a, a2, a3, a4, x[0], 3);
			GG(ref a4, a, a2, a3, x[4], 5);
			GG(ref a3, a4, a, a2, x[8], 9);
			GG(ref a2, a3, a4, a, x[12], 13);
			GG(ref a, a2, a3, a4, x[1], 3);
			GG(ref a4, a, a2, a3, x[5], 5);
			GG(ref a3, a4, a, a2, x[9], 9);
			GG(ref a2, a3, a4, a, x[13], 13);
			GG(ref a, a2, a3, a4, x[2], 3);
			GG(ref a4, a, a2, a3, x[6], 5);
			GG(ref a3, a4, a, a2, x[10], 9);
			GG(ref a2, a3, a4, a, x[14], 13);
			GG(ref a, a2, a3, a4, x[3], 3);
			GG(ref a4, a, a2, a3, x[7], 5);
			GG(ref a3, a4, a, a2, x[11], 9);
			GG(ref a2, a3, a4, a, x[15], 13);
			HH(ref a, a2, a3, a4, x[0], 3);
			HH(ref a4, a, a2, a3, x[8], 9);
			HH(ref a3, a4, a, a2, x[4], 11);
			HH(ref a2, a3, a4, a, x[12], 15);
			HH(ref a, a2, a3, a4, x[2], 3);
			HH(ref a4, a, a2, a3, x[10], 9);
			HH(ref a3, a4, a, a2, x[6], 11);
			HH(ref a2, a3, a4, a, x[14], 15);
			HH(ref a, a2, a3, a4, x[1], 3);
			HH(ref a4, a, a2, a3, x[9], 9);
			HH(ref a3, a4, a, a2, x[5], 11);
			HH(ref a2, a3, a4, a, x[13], 15);
			HH(ref a, a2, a3, a4, x[3], 3);
			HH(ref a4, a, a2, a3, x[11], 9);
			HH(ref a3, a4, a, a2, x[7], 11);
			HH(ref a2, a3, a4, a, x[15], 15);
			state[0] += a;
			state[1] += a2;
			state[2] += a3;
			state[3] += a4;
		}
	}
	public sealed class PKCS1
	{
		private static bool Compare(byte[] array1, byte[] array2)
		{
			bool flag = array1.Length == array2.Length;
			if (flag)
			{
				for (int i = 0; i < array1.Length; i++)
				{
					if (array1[i] != array2[i])
					{
						return false;
					}
				}
			}
			return flag;
		}

		public static byte[] I2OSP(byte[] x, int size)
		{
			byte[] array = new byte[size];
			Buffer.BlockCopy(x, 0, array, array.Length - x.Length, x.Length);
			return array;
		}

		public static byte[] OS2IP(byte[] x)
		{
			int num = 0;
			while (x[num++] == 0 && num < x.Length)
			{
			}
			num--;
			if (num > 0)
			{
				byte[] array = new byte[x.Length - num];
				Buffer.BlockCopy(x, num, array, 0, array.Length);
				return array;
			}
			return x;
		}

		public static byte[] RSAVP1(RSA rsa, byte[] s)
		{
			return rsa.EncryptValue(s);
		}

		public static bool Verify_v15(RSA rsa, HashAlgorithm hash, byte[] hashValue, byte[] signature, bool tryNonStandardEncoding)
		{
			int num = rsa.KeySize >> 3;
			byte[] s = OS2IP(signature);
			byte[] array = I2OSP(RSAVP1(rsa, s), num);
			bool flag = Compare(Encode_v15(hash, hashValue, num), array);
			if (flag || !tryNonStandardEncoding)
			{
				return flag;
			}
			if (array[0] != 0 || array[1] != 1)
			{
				return false;
			}
			int i;
			for (i = 2; i < array.Length - hashValue.Length - 1; i++)
			{
				if (array[i] != 255)
				{
					return false;
				}
			}
			if (array[i++] != 0)
			{
				return false;
			}
			byte[] array2 = new byte[hashValue.Length];
			Buffer.BlockCopy(array, i, array2, 0, array2.Length);
			return Compare(array2, hashValue);
		}

		public static byte[] Encode_v15(HashAlgorithm hash, byte[] hashValue, int emLength)
		{
			if (hashValue.Length != hash.HashSize >> 3)
			{
				throw new CryptographicException("bad hash length for " + hash.ToString());
			}
			byte[] array = null;
			string text = CryptoConfig.MapNameToOID(hash.ToString());
			if (text != null)
			{
				ASN1 aSN = new ASN1(48);
				aSN.Add(new ASN1(CryptoConfig.EncodeOID(text)));
				aSN.Add(new ASN1(5));
				ASN1 asn = new ASN1(4, hashValue);
				ASN1 aSN2 = new ASN1(48);
				aSN2.Add(aSN);
				aSN2.Add(asn);
				array = aSN2.GetBytes();
			}
			else
			{
				array = hashValue;
			}
			Buffer.BlockCopy(hashValue, 0, array, array.Length - hashValue.Length, hashValue.Length);
			int num = System.Math.Max(8, emLength - array.Length - 3);
			byte[] array2 = new byte[num + array.Length + 3];
			array2[1] = 1;
			for (int i = 2; i < num + 2; i++)
			{
				array2[i] = 255;
			}
			Buffer.BlockCopy(array, 0, array2, num + 3, array.Length);
			return array2;
		}

		internal static string HashNameFromOid(string oid, bool throwOnError = true)
		{
			switch (oid)
			{
			case "1.2.840.113549.1.1.2":
				return "MD2";
			case "1.2.840.113549.1.1.3":
				return "MD4";
			case "1.2.840.113549.1.1.4":
				return "MD5";
			case "1.2.840.113549.1.1.5":
			case "1.3.14.3.2.29":
			case "1.2.840.10040.4.3":
				return "SHA1";
			case "1.2.840.113549.1.1.11":
				return "SHA256";
			case "1.2.840.113549.1.1.12":
				return "SHA384";
			case "1.2.840.113549.1.1.13":
				return "SHA512";
			case "1.3.36.3.3.1.2":
				return "RIPEMD160";
			default:
				if (throwOnError)
				{
					throw new CryptographicException("Unsupported hash algorithm: " + oid);
				}
				return null;
			}
		}

		internal static HashAlgorithm CreateFromOid(string oid)
		{
			return CreateFromName(HashNameFromOid(oid));
		}

		internal static HashAlgorithm CreateFromName(string name)
		{
			return HashAlgorithm.Create(name);
		}
	}
	public sealed class PKCS8
	{
		public class PrivateKeyInfo
		{
			private int _version;

			private string _algorithm;

			private byte[] _key;

			private ArrayList _list;

			public string Algorithm
			{
				get
				{
					return _algorithm;
				}
				set
				{
					_algorithm = value;
				}
			}

			public byte[] PrivateKey
			{
				get
				{
					if (_key == null)
					{
						return null;
					}
					return (byte[])_key.Clone();
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("PrivateKey");
					}
					_key = (byte[])value.Clone();
				}
			}

			public PrivateKeyInfo()
			{
				_version = 0;
				_list = new ArrayList();
			}

			public PrivateKeyInfo(byte[] data)
				: this()
			{
				Decode(data);
			}

			private void Decode(byte[] data)
			{
				ASN1 aSN = new ASN1(data);
				if (aSN.Tag != 48)
				{
					throw new CryptographicException("invalid PrivateKeyInfo");
				}
				ASN1 aSN2 = aSN[0];
				if (aSN2.Tag != 2)
				{
					throw new CryptographicException("invalid version");
				}
				_version = aSN2.Value[0];
				ASN1 aSN3 = aSN[1];
				if (aSN3.Tag != 48)
				{
					throw new CryptographicException("invalid algorithm");
				}
				ASN1 aSN4 = aSN3[0];
				if (aSN4.Tag != 6)
				{
					throw new CryptographicException("missing algorithm OID");
				}
				_algorithm = ASN1Convert.ToOid(aSN4);
				ASN1 aSN5 = aSN[2];
				_key = aSN5.Value;
				if (aSN.Count > 3)
				{
					ASN1 aSN6 = aSN[3];
					for (int i = 0; i < aSN6.Count; i++)
					{
						_list.Add(aSN6[i]);
					}
				}
			}

			public byte[] GetBytes()
			{
				ASN1 aSN = new ASN1(48);
				aSN.Add(ASN1Convert.FromOid(_algorithm));
				aSN.Add(new ASN1(5));
				ASN1 aSN2 = new ASN1(48);
				aSN2.Add(new ASN1(2, new byte[1] { (byte)_version }));
				aSN2.Add(aSN);
				aSN2.Add(new ASN1(4, _key));
				if (_list.Count > 0)
				{
					ASN1 aSN3 = new ASN1(160);
					foreach (ASN1 item in _list)
					{
						aSN3.Add(item);
					}
					aSN2.Add(aSN3);
				}
				return aSN2.GetBytes();
			}

			private static byte[] RemoveLeadingZero(byte[] bigInt)
			{
				int srcOffset = 0;
				int num = bigInt.Length;
				if (bigInt[0] == 0)
				{
					srcOffset = 1;
					num--;
				}
				byte[] array = new byte[num];
				Buffer.BlockCopy(bigInt, srcOffset, array, 0, num);
				return array;
			}

			private static byte[] Normalize(byte[] bigInt, int length)
			{
				if (bigInt.Length == length)
				{
					return bigInt;
				}
				if (bigInt.Length > length)
				{
					return RemoveLeadingZero(bigInt);
				}
				byte[] array = new byte[length];
				Buffer.BlockCopy(bigInt, 0, array, length - bigInt.Length, bigInt.Length);
				return array;
			}

			public static RSA DecodeRSA(byte[] keypair)
			{
				ASN1 aSN = new ASN1(keypair);
				if (aSN.Tag != 48)
				{
					throw new CryptographicException("invalid private key format");
				}
				if (aSN[0].Tag != 2)
				{
					throw new CryptographicException("missing version");
				}
				if (aSN.Count < 9)
				{
					throw new CryptographicException("not enough key parameters");
				}
				RSAParameters parameters = new RSAParameters
				{
					Modulus = RemoveLeadingZero(aSN[1].Value)
				};
				int num = parameters.Modulus.Length;
				int length = num >> 1;
				parameters.D = Normalize(aSN[3].Value, num);
				parameters.DP = Normalize(aSN[6].Value, length);
				parameters.DQ = Normalize(aSN[7].Value, length);
				parameters.Exponent = RemoveLeadingZero(aSN[2].Value);
				parameters.InverseQ = Normalize(aSN[8].Value, length);
				parameters.P = Normalize(aSN[4].Value, length);
				parameters.Q = Normalize(aSN[5].Value, length);
				RSA rSA = null;
				try
				{
					rSA = RSA.Create();
					rSA.ImportParameters(parameters);
				}
				catch (CryptographicException)
				{
					rSA = new RSACryptoServiceProvider(new CspParameters
					{
						Flags = CspProviderFlags.UseMachineKeyStore
					});
					rSA.ImportParameters(parameters);
				}
				return rSA;
			}

			public static byte[] Encode(RSA rsa)
			{
				RSAParameters rSAParameters = rsa.ExportParameters(includePrivateParameters: true);
				ASN1 aSN = new ASN1(48);
				aSN.Add(new ASN1(2, new byte[1]));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.Modulus));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.Exponent));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.D));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.P));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.Q));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.DP));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.DQ));
				aSN.Add(ASN1Convert.FromUnsignedBigInteger(rSAParameters.InverseQ));
				return aSN.GetBytes();
			}

			public static DSA DecodeDSA(byte[] privateKey, DSAParameters dsaParameters)
			{
				ASN1 aSN = new ASN1(privateKey);
				if (aSN.Tag != 2)
				{
					throw new CryptographicException("invalid private key format");
				}
				dsaParameters.X = Normalize(aSN.Value, 20);
				DSA dSA = DSA.Create();
				dSA.ImportParameters(dsaParameters);
				return dSA;
			}

			public static byte[] Encode(DSA dsa)
			{
				return ASN1Convert.FromUnsignedBigInteger(dsa.ExportParameters(includePrivateParameters: true).X).GetBytes();
			}
		}

		public class EncryptedPrivateKeyInfo
		{
			private string _algorithm;

			private byte[] _salt;

			private int _iterations;

			private byte[] _data;

			public string Algorithm
			{
				get
				{
					return _algorithm;
				}
				set
				{
					_algorithm = value;
				}
			}

			public byte[] EncryptedData
			{
				get
				{
					if (_data != null)
					{
						return (byte[])_data.Clone();
					}
					return null;
				}
				set
				{
					_data = ((value == null) ? null : ((byte[])value.Clone()));
				}
			}

			public byte[] Salt
			{
				get
				{
					if (_salt == null)
					{
						RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
						_salt = new byte[8];
						randomNumberGenerator.GetBytes(_salt);
					}
					return (byte[])_salt.Clone();
				}
			}

			public int IterationCount
			{
				get
				{
					return _iterations;
				}
				set
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("IterationCount", "Negative");
					}
					_iterations = value;
				}
			}

			public EncryptedPrivateKeyInfo()
			{
			}

			public EncryptedPrivateKeyInfo(byte[] data)
				: this()
			{
				Decode(data);
			}

			private void Decode(byte[] data)
			{
				ASN1 aSN = new ASN1(data);
				if (aSN.Tag != 48)
				{
					throw new CryptographicException("invalid EncryptedPrivateKeyInfo");
				}
				ASN1 aSN2 = aSN[0];
				if (aSN2.Tag != 48)
				{
					throw new CryptographicException("invalid encryptionAlgorithm");
				}
				ASN1 aSN3 = aSN2[0];
				if (aSN3.Tag != 6)
				{
					throw new CryptographicException("invalid algorithm");
				}
				_algorithm = ASN1Convert.ToOid(aSN3);
				if (aSN2.Count > 1)
				{
					ASN1 aSN4 = aSN2[1];
					if (aSN4.Tag != 48)
					{
						throw new CryptographicException("invalid parameters");
					}
					ASN1 aSN5 = aSN4[0];
					if (aSN5.Tag != 4)
					{
						throw new CryptographicException("invalid salt");
					}
					_salt = aSN5.Value;
					ASN1 aSN6 = aSN4[1];
					if (aSN6.Tag != 2)
					{
						throw new CryptographicException("invalid iterationCount");
					}
					_iterations = ASN1Convert.ToInt32(aSN6);
				}
				ASN1 aSN7 = aSN[1];
				if (aSN7.Tag != 4)
				{
					throw new CryptographicException("invalid EncryptedData");
				}
				_data = aSN7.Value;
			}

			public byte[] GetBytes()
			{
				if (_algorithm == null)
				{
					throw new CryptographicException("No algorithm OID specified");
				}
				ASN1 aSN = new ASN1(48);
				aSN.Add(ASN1Convert.FromOid(_algorithm));
				if (_iterations > 0 || _salt != null)
				{
					ASN1 asn = new ASN1(4, _salt);
					ASN1 asn2 = ASN1Convert.FromInt32(_iterations);
					ASN1 aSN2 = new ASN1(48);
					aSN2.Add(asn);
					aSN2.Add(asn2);
					aSN.Add(aSN2);
				}
				ASN1 asn3 = new ASN1(4, _data);
				ASN1 aSN3 = new ASN1(48);
				aSN3.Add(aSN);
				aSN3.Add(asn3);
				return aSN3.GetBytes();
			}
		}
	}
	public class RSAManaged : RSA
	{
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e);

		private bool isCRTpossible;

		private bool keyBlinding = true;

		private bool keypairGenerated;

		private bool m_disposed;

		private BigInteger d;

		private BigInteger p;

		private BigInteger q;

		private BigInteger dp;

		private BigInteger dq;

		private BigInteger qInv;

		private BigInteger n;

		private BigInteger e;

		[CompilerGenerated]
		private KeyGeneratedEventHandler KeyGenerated;

		public override int KeySize
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException(global::Locale.GetText("Keypair was disposed"));
				}
				if (keypairGenerated)
				{
					int num = n.BitCount();
					if ((num & 7) != 0)
					{
						num += 8 - (num & 7);
					}
					return num;
				}
				return base.KeySize;
			}
		}

		public override string KeyExchangeAlgorithm => "RSA-PKCS1-KeyEx";

		public bool PublicOnly
		{
			get
			{
				if (keypairGenerated)
				{
					if (!(d == null))
					{
						return n == null;
					}
					return true;
				}
				return false;
			}
		}

		public override string SignatureAlgorithm => "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

		public RSAManaged()
			: this(1024)
		{
		}

		public RSAManaged(int keySize)
		{
			LegalKeySizesValue = new KeySizes[1];
			LegalKeySizesValue[0] = new KeySizes(384, 16384, 8);
			base.KeySize = keySize;
		}

		~RSAManaged()
		{
			Dispose(disposing: false);
		}

		private void GenerateKeyPair()
		{
			int num = KeySize + 1 >> 1;
			int bits = KeySize - num;
			e = 65537u;
			do
			{
				p = BigInteger.GeneratePseudoPrime(num);
			}
			while (p % 65537u == 1);
			while (true)
			{
				q = BigInteger.GeneratePseudoPrime(bits);
				if (q % 65537u != 1 && p != q)
				{
					n = p * q;
					if (n.BitCount() == KeySize)
					{
						break;
					}
					if (p < q)
					{
						p = q;
					}
				}
			}
			BigInteger bigInteger = p - 1;
			BigInteger bigInteger2 = q - 1;
			BigInteger modulus = bigInteger * bigInteger2;
			d = e.ModInverse(modulus);
			dp = d % bigInteger;
			dq = d % bigInteger2;
			qInv = q.ModInverse(p);
			keypairGenerated = true;
			isCRTpossible = true;
			if (KeyGenerated != null)
			{
				KeyGenerated(this, null);
			}
		}

		public override byte[] DecryptValue(byte[] rgb)
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException("private key");
			}
			if (!keypairGenerated)
			{
				GenerateKeyPair();
			}
			BigInteger bigInteger = new BigInteger(rgb);
			BigInteger bigInteger2 = null;
			if (keyBlinding)
			{
				bigInteger2 = BigInteger.GenerateRandom(n.BitCount());
				bigInteger = bigInteger2.ModPow(e, n) * bigInteger % n;
			}
			BigInteger bigInteger6;
			if (isCRTpossible)
			{
				BigInteger bigInteger3 = bigInteger.ModPow(dp, p);
				BigInteger bigInteger4 = bigInteger.ModPow(dq, q);
				if (bigInteger4 > bigInteger3)
				{
					BigInteger bigInteger5 = p - (bigInteger4 - bigInteger3) * qInv % p;
					bigInteger6 = bigInteger4 + q * bigInteger5;
				}
				else
				{
					BigInteger bigInteger5 = (bigInteger3 - bigInteger4) * qInv % p;
					bigInteger6 = bigInteger4 + q * bigInteger5;
				}
			}
			else
			{
				if (PublicOnly)
				{
					throw new CryptographicException(global::Locale.GetText("Missing private key to decrypt value."));
				}
				bigInteger6 = bigInteger.ModPow(d, n);
			}
			if (keyBlinding)
			{
				bigInteger6 = bigInteger6 * bigInteger2.ModInverse(n) % n;
				bigInteger2.Clear();
			}
			byte[] paddedValue = GetPaddedValue(bigInteger6, KeySize >> 3);
			bigInteger.Clear();
			bigInteger6.Clear();
			return paddedValue;
		}

		public override byte[] EncryptValue(byte[] rgb)
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException("public key");
			}
			if (!keypairGenerated)
			{
				GenerateKeyPair();
			}
			BigInteger bigInteger = new BigInteger(rgb);
			BigInteger bigInteger2 = bigInteger.ModPow(e, n);
			byte[] paddedValue = GetPaddedValue(bigInteger2, KeySize >> 3);
			bigInteger.Clear();
			bigInteger2.Clear();
			return paddedValue;
		}

		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(global::Locale.GetText("Keypair was disposed"));
			}
			if (!keypairGenerated)
			{
				GenerateKeyPair();
			}
			RSAParameters result = new RSAParameters
			{
				Exponent = e.GetBytes(),
				Modulus = n.GetBytes()
			};
			if (includePrivateParameters)
			{
				if (d == null)
				{
					throw new CryptographicException("Missing private key");
				}
				result.D = d.GetBytes();
				if (result.D.Length != result.Modulus.Length)
				{
					byte[] array = new byte[result.Modulus.Length];
					Buffer.BlockCopy(result.D, 0, array, array.Length - result.D.Length, result.D.Length);
					result.D = array;
				}
				if (p != null && q != null && dp != null && dq != null && qInv != null)
				{
					int length = KeySize >> 4;
					result.P = GetPaddedValue(p, length);
					result.Q = GetPaddedValue(q, length);
					result.DP = GetPaddedValue(dp, length);
					result.DQ = GetPaddedValue(dq, length);
					result.InverseQ = GetPaddedValue(qInv, length);
				}
			}
			return result;
		}

		public override void ImportParameters(RSAParameters parameters)
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(global::Locale.GetText("Keypair was disposed"));
			}
			if (parameters.Exponent == null)
			{
				throw new CryptographicException(global::Locale.GetText("Missing Exponent"));
			}
			if (parameters.Modulus == null)
			{
				throw new CryptographicException(global::Locale.GetText("Missing Modulus"));
			}
			e = new BigInteger(parameters.Exponent);
			n = new BigInteger(parameters.Modulus);
			d = (dp = (dq = (qInv = (p = (q = null)))));
			if (parameters.D != null)
			{
				d = new BigInteger(parameters.D);
			}
			if (parameters.DP != null)
			{
				dp = new BigInteger(parameters.DP);
			}
			if (parameters.DQ != null)
			{
				dq = new BigInteger(parameters.DQ);
			}
			if (parameters.InverseQ != null)
			{
				qInv = new BigInteger(parameters.InverseQ);
			}
			if (parameters.P != null)
			{
				p = new BigInteger(parameters.P);
			}
			if (parameters.Q != null)
			{
				q = new BigInteger(parameters.Q);
			}
			keypairGenerated = true;
			bool flag = p != null && q != null && dp != null;
			isCRTpossible = flag && dq != null && qInv != null;
			if (!flag)
			{
				return;
			}
			bool flag2 = n == p * q;
			if (flag2)
			{
				BigInteger bigInteger = p - 1;
				BigInteger bigInteger2 = q - 1;
				BigInteger modulus = bigInteger * bigInteger2;
				BigInteger bigInteger3 = e.ModInverse(modulus);
				flag2 = d == bigInteger3;
				if (!flag2 && isCRTpossible)
				{
					flag2 = dp == bigInteger3 % bigInteger && dq == bigInteger3 % bigInteger2 && qInv == q.ModInverse(p);
				}
			}
			if (flag2)
			{
				return;
			}
			throw new CryptographicException(global::Locale.GetText("Private/public key mismatch"));
		}

		protected override void Dispose(bool disposing)
		{
			if (!m_disposed)
			{
				if (d != null)
				{
					d.Clear();
					d = null;
				}
				if (p != null)
				{
					p.Clear();
					p = null;
				}
				if (q != null)
				{
					q.Clear();
					q = null;
				}
				if (dp != null)
				{
					dp.Clear();
					dp = null;
				}
				if (dq != null)
				{
					dq.Clear();
					dq = null;
				}
				if (qInv != null)
				{
					qInv.Clear();
					qInv = null;
				}
				if (disposing)
				{
					if (e != null)
					{
						e.Clear();
						e = null;
					}
					if (n != null)
					{
						n.Clear();
						n = null;
					}
				}
			}
			m_disposed = true;
		}

		public override string ToXmlString(bool includePrivateParameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			RSAParameters rSAParameters = ExportParameters(includePrivateParameters);
			try
			{
				stringBuilder.Append("<RSAKeyValue>");
				stringBuilder.Append("<Modulus>");
				stringBuilder.Append(Convert.ToBase64String(rSAParameters.Modulus));
				stringBuilder.Append("</Modulus>");
				stringBuilder.Append("<Exponent>");
				stringBuilder.Append(Convert.ToBase64String(rSAParameters.Exponent));
				stringBuilder.Append("</Exponent>");
				if (includePrivateParameters)
				{
					if (rSAParameters.P != null)
					{
						stringBuilder.Append("<P>");
						stringBuilder.Append(Convert.ToBase64String(rSAParameters.P));
						stringBuilder.Append("</P>");
					}
					if (rSAParameters.Q != null)
					{
						stringBuilder.Append("<Q>");
						stringBuilder.Append(Convert.ToBase64String(rSAParameters.Q));
						stringBuilder.Append("</Q>");
					}
					if (rSAParameters.DP != null)
					{
						stringBuilder.Append("<DP>");
						stringBuilder.Append(Convert.ToBase64String(rSAParameters.DP));
						stringBuilder.Append("</DP>");
					}
					if (rSAParameters.DQ != null)
					{
						stringBuilder.Append("<DQ>");
						stringBuilder.Append(Convert.ToBase64String(rSAParameters.DQ));
						stringBuilder.Append("</DQ>");
					}
					if (rSAParameters.InverseQ != null)
					{
						stringBuilder.Append("<InverseQ>");
						stringBuilder.Append(Convert.ToBase64String(rSAParameters.InverseQ));
						stringBuilder.Append("</InverseQ>");
					}
					stringBuilder.Append("<D>");
					stringBuilder.Append(Convert.ToBase64String(rSAParameters.D));
					stringBuilder.Append("</D>");
				}
				stringBuilder.Append("</RSAKeyValue>");
			}
			catch
			{
				if (rSAParameters.P != null)
				{
					Array.Clear(rSAParameters.P, 0, rSAParameters.P.Length);
				}
				if (rSAParameters.Q != null)
				{
					Array.Clear(rSAParameters.Q, 0, rSAParameters.Q.Length);
				}
				if (rSAParameters.DP != null)
				{
					Array.Clear(rSAParameters.DP, 0, rSAParameters.DP.Length);
				}
				if (rSAParameters.DQ != null)
				{
					Array.Clear(rSAParameters.DQ, 0, rSAParameters.DQ.Length);
				}
				if (rSAParameters.InverseQ != null)
				{
					Array.Clear(rSAParameters.InverseQ, 0, rSAParameters.InverseQ.Length);
				}
				if (rSAParameters.D != null)
				{
					Array.Clear(rSAParameters.D, 0, rSAParameters.D.Length);
				}
				throw;
			}
			return stringBuilder.ToString();
		}

		private byte[] GetPaddedValue(BigInteger value, int length)
		{
			byte[] bytes = value.GetBytes();
			if (bytes.Length >= length)
			{
				return bytes;
			}
			byte[] array = new byte[length];
			Buffer.BlockCopy(bytes, 0, array, length - bytes.Length, bytes.Length);
			Array.Clear(bytes, 0, bytes.Length);
			return array;
		}
	}
}
namespace Mono.Security.Authenticode
{
	public class AuthenticodeBase
	{
		private byte[] fileblock;

		private Stream fs;

		private int blockNo;

		private int blockLength;

		private int peOffset;

		private int dirSecurityOffset;

		private int dirSecuritySize;

		private int coffSymbolTableOffset;

		private bool pe64;

		internal int PEOffset
		{
			get
			{
				if (blockNo < 1)
				{
					ReadFirstBlock();
				}
				return peOffset;
			}
		}

		public AuthenticodeBase()
		{
			fileblock = new byte[4096];
		}

		internal void Open(string filename)
		{
			if (fs != null)
			{
				Close();
			}
			fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
			blockNo = 0;
		}

		internal void Open(byte[] rawdata)
		{
			if (fs != null)
			{
				Close();
			}
			fs = new MemoryStream(rawdata, writable: false);
			blockNo = 0;
		}

		internal void Close()
		{
			if (fs != null)
			{
				fs.Close();
				fs = null;
			}
		}

		internal void ReadFirstBlock()
		{
			int num = ProcessFirstBlock();
			if (num != 0)
			{
				throw new NotSupportedException(global::Locale.GetText("Cannot sign non PE files, e.g. .CAB or .MSI files (error {0}).", num));
			}
		}

		internal int ProcessFirstBlock()
		{
			if (fs == null)
			{
				return 1;
			}
			fs.Position = 0L;
			blockLength = fs.Read(fileblock, 0, fileblock.Length);
			blockNo = 1;
			if (blockLength < 64)
			{
				return 2;
			}
			if (Mono.Security.BitConverterLE.ToUInt16(fileblock, 0) != 23117)
			{
				return 3;
			}
			peOffset = Mono.Security.BitConverterLE.ToInt32(fileblock, 60);
			if (peOffset > fileblock.Length)
			{
				throw new NotSupportedException(string.Format(global::Locale.GetText("Header size too big (> {0} bytes)."), fileblock.Length));
			}
			if (peOffset > fs.Length)
			{
				return 4;
			}
			if (Mono.Security.BitConverterLE.ToUInt32(fileblock, peOffset) != 17744)
			{
				return 5;
			}
			ushort num = Mono.Security.BitConverterLE.ToUInt16(fileblock, peOffset + 24);
			pe64 = num == 523;
			if (pe64)
			{
				dirSecurityOffset = Mono.Security.BitConverterLE.ToInt32(fileblock, peOffset + 168);
				dirSecuritySize = Mono.Security.BitConverterLE.ToInt32(fileblock, peOffset + 168 + 4);
			}
			else
			{
				dirSecurityOffset = Mono.Security.BitConverterLE.ToInt32(fileblock, peOffset + 152);
				dirSecuritySize = Mono.Security.BitConverterLE.ToInt32(fileblock, peOffset + 156);
			}
			coffSymbolTableOffset = Mono.Security.BitConverterLE.ToInt32(fileblock, peOffset + 12);
			return 0;
		}

		internal byte[] GetSecurityEntry()
		{
			if (blockNo < 1)
			{
				ReadFirstBlock();
			}
			if (dirSecuritySize > 8)
			{
				byte[] array = new byte[dirSecuritySize - 8];
				fs.Position = dirSecurityOffset + 8;
				fs.Read(array, 0, array.Length);
				return array;
			}
			return null;
		}

		internal byte[] GetHash(HashAlgorithm hash)
		{
			if (blockNo < 1)
			{
				ReadFirstBlock();
			}
			fs.Position = blockLength;
			int num = 0;
			long num2;
			if (dirSecurityOffset > 0)
			{
				if (dirSecurityOffset < blockLength)
				{
					blockLength = dirSecurityOffset;
					num2 = 0L;
				}
				else
				{
					num2 = dirSecurityOffset - blockLength;
				}
			}
			else if (coffSymbolTableOffset > 0)
			{
				fileblock[PEOffset + 12] = 0;
				fileblock[PEOffset + 13] = 0;
				fileblock[PEOffset + 14] = 0;
				fileblock[PEOffset + 15] = 0;
				fileblock[PEOffset + 16] = 0;
				fileblock[PEOffset + 17] = 0;
				fileblock[PEOffset + 18] = 0;
				fileblock[PEOffset + 19] = 0;
				if (coffSymbolTableOffset < blockLength)
				{
					blockLength = coffSymbolTableOffset;
					num2 = 0L;
				}
				else
				{
					num2 = coffSymbolTableOffset - blockLength;
				}
			}
			else
			{
				num = (int)(fs.Length & 7);
				if (num > 0)
				{
					num = 8 - num;
				}
				num2 = fs.Length - blockLength;
			}
			int num3 = peOffset + 88;
			hash.TransformBlock(fileblock, 0, num3, fileblock, 0);
			num3 += 4;
			if (pe64)
			{
				hash.TransformBlock(fileblock, num3, 76, fileblock, num3);
				num3 += 84;
			}
			else
			{
				hash.TransformBlock(fileblock, num3, 60, fileblock, num3);
				num3 += 68;
			}
			if (num2 == 0L)
			{
				hash.TransformFinalBlock(fileblock, num3, blockLength - num3);
			}
			else
			{
				hash.TransformBlock(fileblock, num3, blockLength - num3, fileblock, num3);
				long num4 = num2 >> 12;
				int num5 = (int)(num2 - (num4 << 12));
				if (num5 == 0)
				{
					num4--;
					num5 = 4096;
				}
				while (num4-- > 0)
				{
					fs.Read(fileblock, 0, fileblock.Length);
					hash.TransformBlock(fileblock, 0, fileblock.Length, fileblock, 0);
				}
				if (fs.Read(fileblock, 0, num5) != num5)
				{
					return null;
				}
				if (num > 0)
				{
					hash.TransformBlock(fileblock, 0, num5, fileblock, 0);
					hash.TransformFinalBlock(new byte[num], 0, num);
				}
				else
				{
					hash.TransformFinalBlock(fileblock, 0, num5);
				}
			}
			return hash.Hash;
		}
	}
	public class AuthenticodeDeformatter : AuthenticodeBase
	{
		private string filename;

		private byte[] rawdata;

		private byte[] hash;

		private Mono.Security.X509.X509CertificateCollection coll;

		private ASN1 signedHash;

		private DateTime timestamp;

		private Mono.Security.X509.X509Certificate signingCertificate;

		private int reason;

		private bool trustedRoot;

		private bool trustedTimestampRoot;

		private byte[] entry;

		private Mono.Security.X509.X509Chain signerChain;

		private Mono.Security.X509.X509Chain timestampChain;

		public byte[] RawData
		{
			set
			{
				Reset();
				rawdata = value;
				try
				{
					CheckSignature();
				}
				catch (SecurityException)
				{
					throw;
				}
				catch
				{
					reason = 1;
				}
			}
		}

		public Mono.Security.X509.X509Certificate SigningCertificate => signingCertificate;

		public AuthenticodeDeformatter()
		{
			reason = -1;
			signerChain = new Mono.Security.X509.X509Chain();
			timestampChain = new Mono.Security.X509.X509Chain();
		}

		public AuthenticodeDeformatter(byte[] rawData)
			: this()
		{
			RawData = rawData;
		}

		private bool CheckSignature()
		{
			if (filename != null)
			{
				Open(filename);
			}
			else
			{
				Open(rawdata);
			}
			entry = GetSecurityEntry();
			if (entry == null)
			{
				reason = 1;
				Close();
				return false;
			}
			PKCS7.ContentInfo contentInfo = new PKCS7.ContentInfo(entry);
			if (contentInfo.ContentType != "1.2.840.113549.1.7.2")
			{
				Close();
				return false;
			}
			PKCS7.SignedData signedData = new PKCS7.SignedData(contentInfo.Content);
			if (signedData.ContentInfo.ContentType != "1.3.6.1.4.1.311.2.1.4")
			{
				Close();
				return false;
			}
			coll = signedData.Certificates;
			ASN1 content = signedData.ContentInfo.Content;
			signedHash = content[0][1][1];
			HashAlgorithm hashAlgorithm = null;
			switch (signedHash.Length)
			{
			case 16:
				hashAlgorithm = MD5.Create();
				hash = GetHash(hashAlgorithm);
				break;
			case 20:
				hashAlgorithm = SHA1.Create();
				hash = GetHash(hashAlgorithm);
				break;
			case 32:
				hashAlgorithm = SHA256.Create();
				hash = GetHash(hashAlgorithm);
				break;
			case 48:
				hashAlgorithm = SHA384.Create();
				hash = GetHash(hashAlgorithm);
				break;
			case 64:
				hashAlgorithm = SHA512.Create();
				hash = GetHash(hashAlgorithm);
				break;
			default:
				reason = 5;
				Close();
				return false;
			}
			Close();
			if (!signedHash.CompareValue(hash))
			{
				reason = 2;
			}
			byte[] value = content[0].Value;
			hashAlgorithm.Initialize();
			byte[] calculatedMessageDigest = hashAlgorithm.ComputeHash(value);
			if (VerifySignature(signedData, calculatedMessageDigest, hashAlgorithm))
			{
				return reason == 0;
			}
			return false;
		}

		private bool CompareIssuerSerial(string issuer, byte[] serial, Mono.Security.X509.X509Certificate x509)
		{
			if (issuer != x509.IssuerName)
			{
				return false;
			}
			if (serial.Length != x509.SerialNumber.Length)
			{
				return false;
			}
			int num = serial.Length;
			for (int i = 0; i < serial.Length; i++)
			{
				if (serial[i] != x509.SerialNumber[--num])
				{
					return false;
				}
			}
			return true;
		}

		private bool VerifySignature(PKCS7.SignedData sd, byte[] calculatedMessageDigest, HashAlgorithm ha)
		{
			string text = null;
			ASN1 aSN = null;
			for (int i = 0; i < sd.SignerInfo.AuthenticatedAttributes.Count; i++)
			{
				ASN1 aSN2 = (ASN1)sd.SignerInfo.AuthenticatedAttributes[i];
				switch (ASN1Convert.ToOid(aSN2[0]))
				{
				case "1.2.840.113549.1.9.3":
					text = ASN1Convert.ToOid(aSN2[1][0]);
					break;
				case "1.2.840.113549.1.9.4":
					aSN = aSN2[1][0];
					break;
				}
			}
			if (text != "1.3.6.1.4.1.311.2.1.4")
			{
				return false;
			}
			if (aSN == null)
			{
				return false;
			}
			if (!aSN.CompareValue(calculatedMessageDigest))
			{
				return false;
			}
			string str = CryptoConfig.MapNameToOID(ha.ToString());
			ASN1 aSN3 = new ASN1(49);
			foreach (ASN1 authenticatedAttribute in sd.SignerInfo.AuthenticatedAttributes)
			{
				aSN3.Add(authenticatedAttribute);
			}
			ha.Initialize();
			byte[] rgbHash = ha.ComputeHash(aSN3.GetBytes());
			byte[] signature = sd.SignerInfo.Signature;
			string issuerName = sd.SignerInfo.IssuerName;
			byte[] serialNumber = sd.SignerInfo.SerialNumber;
			foreach (Mono.Security.X509.X509Certificate item in coll)
			{
				if (CompareIssuerSerial(issuerName, serialNumber, item) && item.PublicKey.Length > signature.Length >> 3)
				{
					signingCertificate = item;
					if (((RSACryptoServiceProvider)item.RSA).VerifyHash(rgbHash, str, signature))
					{
						signerChain.LoadCertificates(coll);
						trustedRoot = signerChain.Build(item);
						break;
					}
				}
			}
			bool flag = false;
			Mono.Security.X509.X509Extension x509Extension = ((coll.Count > 0) ? coll[0].Extensions["2.5.29.37"] : null);
			if (x509Extension == null)
			{
				return false;
			}
			ASN1 aSN4 = new ASN1(x509Extension.Value.Value);
			if (aSN4.Tag != 48)
			{
				return false;
			}
			for (int j = 0; j < aSN4.Count; j++)
			{
				if (ASN1Convert.ToOid(aSN4[j]) == "1.3.6.1.5.5.7.3.3")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			if (sd.SignerInfo.UnauthenticatedAttributes.Count == 0)
			{
				trustedTimestampRoot = true;
			}
			else
			{
				for (int k = 0; k < sd.SignerInfo.UnauthenticatedAttributes.Count; k++)
				{
					ASN1 aSN5 = (ASN1)sd.SignerInfo.UnauthenticatedAttributes[k];
					if (ASN1Convert.ToOid(aSN5[0]) == "1.2.840.113549.1.9.6")
					{
						PKCS7.SignerInfo cs = new PKCS7.SignerInfo(aSN5[1]);
						trustedTimestampRoot = VerifyCounterSignature(cs, signature);
					}
				}
			}
			if (trustedRoot)
			{
				return trustedTimestampRoot;
			}
			return false;
		}

		private bool VerifyCounterSignature(PKCS7.SignerInfo cs, byte[] signature)
		{
			if (cs.Version > 1)
			{
				return false;
			}
			string text = null;
			ASN1 aSN = null;
			for (int i = 0; i < cs.AuthenticatedAttributes.Count; i++)
			{
				ASN1 aSN2 = (ASN1)cs.AuthenticatedAttributes[i];
				switch (ASN1Convert.ToOid(aSN2[0]))
				{
				case "1.2.840.113549.1.9.3":
					text = ASN1Convert.ToOid(aSN2[1][0]);
					break;
				case "1.2.840.113549.1.9.4":
					aSN = aSN2[1][0];
					break;
				case "1.2.840.113549.1.9.5":
					timestamp = ASN1Convert.ToDateTime(aSN2[1][0]);
					break;
				}
			}
			if (text != "1.2.840.113549.1.7.1")
			{
				return false;
			}
			if (aSN == null)
			{
				return false;
			}
			string hashName = null;
			switch (aSN.Length)
			{
			case 16:
				hashName = "MD5";
				break;
			case 20:
				hashName = "SHA1";
				break;
			case 32:
				hashName = "SHA256";
				break;
			case 48:
				hashName = "SHA384";
				break;
			case 64:
				hashName = "SHA512";
				break;
			}
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashName);
			if (!aSN.CompareValue(hashAlgorithm.ComputeHash(signature)))
			{
				return false;
			}
			byte[] signature2 = cs.Signature;
			ASN1 aSN3 = new ASN1(49);
			foreach (ASN1 authenticatedAttribute in cs.AuthenticatedAttributes)
			{
				aSN3.Add(authenticatedAttribute);
			}
			byte[] hashValue = hashAlgorithm.ComputeHash(aSN3.GetBytes());
			string issuerName = cs.IssuerName;
			byte[] serialNumber = cs.SerialNumber;
			foreach (Mono.Security.X509.X509Certificate item in coll)
			{
				if (CompareIssuerSerial(issuerName, serialNumber, item) && item.PublicKey.Length > signature2.Length)
				{
					RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)item.RSA;
					RSAManaged rSAManaged = new RSAManaged();
					rSAManaged.ImportParameters(rSACryptoServiceProvider.ExportParameters(includePrivateParameters: false));
					if (PKCS1.Verify_v15(rSAManaged, hashAlgorithm, hashValue, signature2, tryNonStandardEncoding: true))
					{
						timestampChain.LoadCertificates(coll);
						return timestampChain.Build(item);
					}
				}
			}
			return false;
		}

		private void Reset()
		{
			filename = null;
			rawdata = null;
			entry = null;
			hash = null;
			signedHash = null;
			signingCertificate = null;
			reason = -1;
			trustedRoot = false;
			trustedTimestampRoot = false;
			signerChain.Reset();
			timestampChain.Reset();
			timestamp = DateTime.MinValue;
		}
	}
}
namespace Mono.Math
{
	public class BigInteger
	{
		public enum Sign
		{
			Negative = -1,
			Zero,
			Positive
		}

		public sealed class ModulusRing
		{
			private BigInteger mod;

			private BigInteger constant;

			public ModulusRing(BigInteger modulus)
			{
				mod = modulus;
				uint num = mod.length << 1;
				constant = new BigInteger(Sign.Positive, num + 1);
				constant.data[num] = 1u;
				constant /= mod;
			}

			public void BarrettReduction(BigInteger x)
			{
				BigInteger bigInteger = mod;
				uint length = bigInteger.length;
				uint num = length + 1;
				uint num2 = length - 1;
				if (x.length >= length)
				{
					if (x.data.Length < x.length)
					{
						throw new IndexOutOfRangeException("x out of range");
					}
					BigInteger bigInteger2 = new BigInteger(Sign.Positive, x.length - num2 + constant.length);
					Kernel.Multiply(x.data, num2, x.length - num2, constant.data, 0u, constant.length, bigInteger2.data, 0u);
					uint length2 = ((x.length > num) ? num : x.length);
					x.length = length2;
					x.Normalize();
					BigInteger bigInteger3 = new BigInteger(Sign.Positive, num);
					Kernel.MultiplyMod2p32pmod(bigInteger2.data, (int)num, (int)(bigInteger2.length - num), bigInteger.data, 0, (int)bigInteger.length, bigInteger3.data, 0, (int)num);
					bigInteger3.Normalize();
					if (bigInteger3 <= x)
					{
						Kernel.MinusEq(x, bigInteger3);
					}
					else
					{
						BigInteger bigInteger4 = new BigInteger(Sign.Positive, num + 1);
						bigInteger4.data[num] = 1u;
						Kernel.MinusEq(bigInteger4, bigInteger3);
						Kernel.PlusEq(x, bigInteger4);
					}
					while (x >= bigInteger)
					{
						Kernel.MinusEq(x, bigInteger);
					}
				}
			}

			public BigInteger Multiply(BigInteger a, BigInteger b)
			{
				if (a == 0u || b == 0u)
				{
					return 0;
				}
				if (a > mod)
				{
					a %= mod;
				}
				if (b > mod)
				{
					b %= mod;
				}
				BigInteger bigInteger = a * b;
				BarrettReduction(bigInteger);
				return bigInteger;
			}

			public BigInteger Difference(BigInteger a, BigInteger b)
			{
				Sign sign = Kernel.Compare(a, b);
				BigInteger bigInteger;
				switch (sign)
				{
				case Sign.Zero:
					return 0;
				case Sign.Positive:
					bigInteger = a - b;
					break;
				case Sign.Negative:
					bigInteger = b - a;
					break;
				default:
					throw new Exception();
				}
				if (bigInteger >= mod)
				{
					if (bigInteger.length >= mod.length << 1)
					{
						bigInteger %= mod;
					}
					else
					{
						BarrettReduction(bigInteger);
					}
				}
				if (sign == Sign.Negative)
				{
					bigInteger = mod - bigInteger;
				}
				return bigInteger;
			}

			public BigInteger Pow(BigInteger a, BigInteger k)
			{
				BigInteger bigInteger = new BigInteger(1u);
				if (k == 0u)
				{
					return bigInteger;
				}
				BigInteger bigInteger2 = a;
				if (k.TestBit(0))
				{
					bigInteger = a;
				}
				for (int i = 1; i < k.BitCount(); i++)
				{
					bigInteger2 = Multiply(bigInteger2, bigInteger2);
					if (k.TestBit(i))
					{
						bigInteger = Multiply(bigInteger2, bigInteger);
					}
				}
				return bigInteger;
			}

			[CLSCompliant(false)]
			public BigInteger Pow(uint b, BigInteger exp)
			{
				return Pow(new BigInteger(b), exp);
			}
		}

		private sealed class Kernel
		{
			public static BigInteger AddSameSign(BigInteger bi1, BigInteger bi2)
			{
				uint num = 0u;
				uint[] data;
				uint length;
				uint[] data2;
				uint length2;
				if (bi1.length < bi2.length)
				{
					data = bi2.data;
					length = bi2.length;
					data2 = bi1.data;
					length2 = bi1.length;
				}
				else
				{
					data = bi1.data;
					length = bi1.length;
					data2 = bi2.data;
					length2 = bi2.length;
				}
				BigInteger bigInteger = new BigInteger(Sign.Positive, length + 1);
				uint[] data3 = bigInteger.data;
				ulong num2 = 0uL;
				do
				{
					num2 = (ulong)((long)data[num] + (long)data2[num]) + num2;
					data3[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < length2);
				bool flag = num2 != 0;
				if (flag)
				{
					if (num < length)
					{
						do
						{
							flag = (data3[num] = data[num] + 1) == 0;
						}
						while (++num < length && flag);
					}
					if (flag)
					{
						data3[num] = 1u;
						num = (bigInteger.length = num + 1);
						return bigInteger;
					}
				}
				if (num < length)
				{
					do
					{
						data3[num] = data[num];
					}
					while (++num < length);
				}
				bigInteger.Normalize();
				return bigInteger;
			}

			public static BigInteger Subtract(BigInteger big, BigInteger small)
			{
				BigInteger bigInteger = new BigInteger(Sign.Positive, big.length);
				uint[] data = bigInteger.data;
				uint[] data2 = big.data;
				uint[] data3 = small.data;
				uint num = 0u;
				uint num2 = 0u;
				do
				{
					uint num3 = data3[num];
					num2 = ((((num3 += num2) < num2) | ((data[num] = data2[num] - num3) > ~num3)) ? 1u : 0u);
				}
				while (++num < small.length);
				if (num != big.length)
				{
					if (num2 == 1)
					{
						do
						{
							data[num] = data2[num] - 1;
						}
						while (data2[num++] == 0 && num < big.length);
						if (num == big.length)
						{
							goto IL_00b8;
						}
					}
					do
					{
						data[num] = data2[num];
					}
					while (++num < big.length);
				}
				goto IL_00b8;
				IL_00b8:
				bigInteger.Normalize();
				return bigInteger;
			}

			public static void MinusEq(BigInteger big, BigInteger small)
			{
				uint[] data = big.data;
				uint[] data2 = small.data;
				uint num = 0u;
				uint num2 = 0u;
				do
				{
					uint num3 = data2[num];
					num2 = ((((num3 += num2) < num2) | ((data[num] -= num3) > ~num3)) ? 1u : 0u);
				}
				while (++num < small.length);
				if (num != big.length && num2 == 1)
				{
					do
					{
						data[num]--;
					}
					while (data[num++] == 0 && num < big.length);
				}
				while (big.length != 0 && big.data[big.length - 1] == 0)
				{
					big.length--;
				}
				if (big.length == 0)
				{
					big.length++;
				}
			}

			public static void PlusEq(BigInteger bi1, BigInteger bi2)
			{
				uint num = 0u;
				bool flag = false;
				uint[] data;
				uint length;
				uint[] data2;
				uint length2;
				if (bi1.length < bi2.length)
				{
					flag = true;
					data = bi2.data;
					length = bi2.length;
					data2 = bi1.data;
					length2 = bi1.length;
				}
				else
				{
					data = bi1.data;
					length = bi1.length;
					data2 = bi2.data;
					length2 = bi2.length;
				}
				uint[] data3 = bi1.data;
				ulong num2 = 0uL;
				do
				{
					num2 += (ulong)((long)data[num] + (long)data2[num]);
					data3[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < length2);
				bool flag2 = num2 != 0;
				if (flag2)
				{
					if (num < length)
					{
						do
						{
							flag2 = (data3[num] = data[num] + 1) == 0;
						}
						while (++num < length && flag2);
					}
					if (flag2)
					{
						data3[num] = 1u;
						num = (bi1.length = num + 1);
						return;
					}
				}
				if (flag && num < length - 1)
				{
					do
					{
						data3[num] = data[num];
					}
					while (++num < length);
				}
				bi1.length = length + 1;
				bi1.Normalize();
			}

			public static Sign Compare(BigInteger bi1, BigInteger bi2)
			{
				uint num = bi1.length;
				uint num2 = bi2.length;
				while (num != 0 && bi1.data[num - 1] == 0)
				{
					num--;
				}
				while (num2 != 0 && bi2.data[num2 - 1] == 0)
				{
					num2--;
				}
				if (num == 0 && num2 == 0)
				{
					return Sign.Zero;
				}
				if (num < num2)
				{
					return Sign.Negative;
				}
				if (num > num2)
				{
					return Sign.Positive;
				}
				uint num3 = num - 1;
				while (num3 != 0 && bi1.data[num3] == bi2.data[num3])
				{
					num3--;
				}
				if (bi1.data[num3] < bi2.data[num3])
				{
					return Sign.Negative;
				}
				if (bi1.data[num3] > bi2.data[num3])
				{
					return Sign.Positive;
				}
				return Sign.Zero;
			}

			public static uint SingleByteDivideInPlace(BigInteger n, uint d)
			{
				ulong num = 0uL;
				uint length = n.length;
				while (length-- != 0)
				{
					num <<= 32;
					num |= n.data[length];
					n.data[length] = (uint)(num / d);
					num %= d;
				}
				n.Normalize();
				return (uint)num;
			}

			public static uint DwordMod(BigInteger n, uint d)
			{
				ulong num = 0uL;
				uint length = n.length;
				while (length-- != 0)
				{
					num <<= 32;
					num |= n.data[length];
					num %= d;
				}
				return (uint)num;
			}

			public static BigInteger[] DwordDivMod(BigInteger n, uint d)
			{
				BigInteger bigInteger = new BigInteger(Sign.Positive, n.length);
				ulong num = 0uL;
				uint length = n.length;
				while (length-- != 0)
				{
					num <<= 32;
					num |= n.data[length];
					bigInteger.data[length] = (uint)(num / d);
					num %= d;
				}
				bigInteger.Normalize();
				BigInteger bigInteger2 = (uint)num;
				return new BigInteger[2] { bigInteger, bigInteger2 };
			}

			public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2)
			{
				if (Compare(bi1, bi2) == Sign.Negative)
				{
					return new BigInteger[2]
					{
						0,
						new BigInteger(bi1)
					};
				}
				bi1.Normalize();
				bi2.Normalize();
				if (bi2.length == 1)
				{
					return DwordDivMod(bi1, bi2.data[0]);
				}
				uint num = bi1.length + 1;
				int num2 = (int)(bi2.length + 1);
				uint num3 = 2147483648u;
				uint num4 = bi2.data[bi2.length - 1];
				int num5 = 0;
				int num6 = (int)(bi1.length - bi2.length);
				while (num3 != 0 && (num4 & num3) == 0)
				{
					num5++;
					num3 >>= 1;
				}
				BigInteger bigInteger = new BigInteger(Sign.Positive, bi1.length - bi2.length + 1);
				BigInteger bigInteger2 = bi1 << num5;
				uint[] data = bigInteger2.data;
				bi2 <<= num5;
				int num7 = (int)(num - bi2.length);
				int num8 = (int)(num - 1);
				uint num9 = bi2.data[bi2.length - 1];
				ulong num10 = bi2.data[bi2.length - 2];
				while (num7 > 0)
				{
					ulong num11 = ((ulong)data[num8] << 32) + data[num8 - 1];
					ulong num12 = num11 / num9;
					ulong num13 = num11 % num9;
					while (num12 == 4294967296L || num12 * num10 > (num13 << 32) + data[num8 - 2])
					{
						num12--;
						num13 += num9;
						if (num13 >= 4294967296L)
						{
							break;
						}
					}
					uint num14 = 0u;
					int num15 = num8 - num2 + 1;
					ulong num16 = 0uL;
					uint num17 = (uint)num12;
					do
					{
						num16 += (ulong)((long)bi2.data[num14] * (long)num17);
						uint num18 = data[num15];
						data[num15] -= (uint)(int)num16;
						num16 >>= 32;
						if (data[num15] > num18)
						{
							num16++;
						}
						num14++;
						num15++;
					}
					while (num14 < num2);
					num15 = num8 - num2 + 1;
					num14 = 0u;
					if (num16 != 0L)
					{
						num17--;
						ulong num19 = 0uL;
						do
						{
							num19 = (ulong)((long)data[num15] + (long)bi2.data[num14]) + num19;
							data[num15] = (uint)num19;
							num19 >>= 32;
							num14++;
							num15++;
						}
						while (num14 < num2);
					}
					bigInteger.data[num6--] = num17;
					num8--;
					num7--;
				}
				bigInteger.Normalize();
				bigInteger2.Normalize();
				BigInteger[] array = new BigInteger[2] { bigInteger, bigInteger2 };
				if (num5 != 0)
				{
					BigInteger[] array2 = array;
					array2[1] >>= num5;
				}
				return array;
			}

			public static BigInteger LeftShift(BigInteger bi, int n)
			{
				if (n == 0)
				{
					return new BigInteger(bi, bi.length + 1);
				}
				int num = n >> 5;
				n &= 0x1F;
				BigInteger bigInteger = new BigInteger(Sign.Positive, bi.length + 1 + (uint)num);
				uint num2 = 0u;
				uint length = bi.length;
				if (n != 0)
				{
					uint num3 = 0u;
					for (; num2 < length; num2++)
					{
						uint num4 = bi.data[num2];
						bigInteger.data[num2 + num] = (num4 << n) | num3;
						num3 = num4 >> 32 - n;
					}
					bigInteger.data[num2 + num] = num3;
				}
				else
				{
					for (; num2 < length; num2++)
					{
						bigInteger.data[num2 + num] = bi.data[num2];
					}
				}
				bigInteger.Normalize();
				return bigInteger;
			}

			public static BigInteger RightShift(BigInteger bi, int n)
			{
				if (n == 0)
				{
					return new BigInteger(bi);
				}
				int num = n >> 5;
				int num2 = n & 0x1F;
				BigInteger bigInteger = new BigInteger(Sign.Positive, (uint)((int)bi.length - num + 1));
				uint num3 = (uint)(bigInteger.data.Length - 1);
				if (num2 != 0)
				{
					uint num4 = 0u;
					while (num3-- != 0)
					{
						uint num5 = bi.data[num3 + num];
						bigInteger.data[num3] = (num5 >> n) | num4;
						num4 = num5 << 32 - n;
					}
				}
				else
				{
					while (num3-- != 0)
					{
						bigInteger.data[num3] = bi.data[num3 + num];
					}
				}
				bigInteger.Normalize();
				return bigInteger;
			}

			public unsafe static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset)
			{
				fixed (uint* ptr = x)
				{
					fixed (uint* ptr2 = y)
					{
						fixed (uint* ptr3 = d)
						{
							uint* ptr4 = ptr + xOffset;
							uint* ptr5 = ptr4 + xLen;
							uint* ptr6 = ptr2 + yOffset;
							uint* ptr7 = ptr6 + yLen;
							uint* ptr8 = ptr3 + dOffset;
							while (ptr4 < ptr5)
							{
								if (*ptr4 != 0)
								{
									ulong num = 0uL;
									uint* ptr9 = ptr8;
									uint* ptr10 = ptr6;
									while (ptr10 < ptr7)
									{
										num += (ulong)((long)(*ptr4) * (long)(*ptr10) + *ptr9);
										*ptr9 = (uint)num;
										num >>= 32;
										ptr10++;
										ptr9++;
									}
									if (num != 0L)
									{
										*ptr9 = (uint)num;
									}
								}
								ptr4++;
								ptr8++;
							}
						}
					}
				}
			}

			public unsafe static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod)
			{
				fixed (uint* ptr = x)
				{
					fixed (uint* ptr2 = y)
					{
						fixed (uint* ptr3 = d)
						{
							uint* ptr4 = ptr + xOffset;
							uint* ptr5 = ptr4 + xLen;
							uint* ptr6 = ptr2 + yOffest;
							uint* ptr7 = ptr6 + yLen;
							uint* ptr8 = ptr3 + dOffset;
							uint* ptr9 = ptr8 + mod;
							while (ptr4 < ptr5)
							{
								if (*ptr4 != 0)
								{
									ulong num = 0uL;
									uint* ptr10 = ptr8;
									uint* ptr11 = ptr6;
									while (ptr11 < ptr7 && ptr10 < ptr9)
									{
										num += (ulong)((long)(*ptr4) * (long)(*ptr11) + *ptr10);
										*ptr10 = (uint)num;
										num >>= 32;
										ptr11++;
										ptr10++;
									}
									if (num != 0L && ptr10 < ptr9)
									{
										*ptr10 = (uint)num;
									}
								}
								ptr4++;
								ptr8++;
							}
						}
					}
				}
			}

			public static uint modInverse(BigInteger bi, uint modulus)
			{
				uint num = modulus;
				uint num2 = bi % modulus;
				uint num3 = 0u;
				uint num4 = 1u;
				while (true)
				{
					switch (num2)
					{
					case 1u:
						return num4;
					default:
						num3 += num / num2 * num4;
						num %= num2;
						switch (num)
						{
						case 1u:
							return modulus - num3;
						default:
							goto IL_002d;
						case 0u:
							break;
						}
						break;
					case 0u:
						break;
					}
					break;
					IL_002d:
					num4 += num2 / num * num3;
					num2 %= num;
				}
				return 0u;
			}

			public static BigInteger modInverse(BigInteger bi, BigInteger modulus)
			{
				if (modulus.length == 1)
				{
					return modInverse(bi, modulus.data[0]);
				}
				BigInteger[] array = new BigInteger[2] { 0, 1 };
				BigInteger[] array2 = new BigInteger[2];
				BigInteger[] array3 = new BigInteger[2] { 0, 0 };
				int num = 0;
				BigInteger bi2 = modulus;
				BigInteger bigInteger = bi;
				ModulusRing modulusRing = new ModulusRing(modulus);
				while (bigInteger != 0u)
				{
					if (num > 1)
					{
						BigInteger bigInteger2 = modulusRing.Difference(array[0], array[1] * array2[0]);
						array[0] = array[1];
						array[1] = bigInteger2;
					}
					BigInteger[] array4 = multiByteDivide(bi2, bigInteger);
					array2[0] = array2[1];
					array2[1] = array4[0];
					array3[0] = array3[1];
					array3[1] = array4[1];
					bi2 = bigInteger;
					bigInteger = array4[1];
					num++;
				}
				if (array3[0] != 1u)
				{
					throw new ArithmeticException("No inverse!");
				}
				return modulusRing.Difference(array[0], array[1] * array2[0]);
			}
		}

		private uint length = 1u;

		private uint[] data;

		internal static readonly uint[] smallPrimes = new uint[783]
		{
			2u, 3u, 5u, 7u, 11u, 13u, 17u, 19u, 23u, 29u,
			31u, 37u, 41u, 43u, 47u, 53u, 59u, 61u, 67u, 71u,
			73u, 79u, 83u, 89u, 97u, 101u, 103u, 107u, 109u, 113u,
			127u, 131u, 137u, 139u, 149u, 151u, 157u, 163u, 167u, 173u,
			179u, 181u, 191u, 193u, 197u, 199u, 211u, 223u, 227u, 229u,
			233u, 239u, 241u, 251u, 257u, 263u, 269u, 271u, 277u, 281u,
			283u, 293u, 307u, 311u, 313u, 317u, 331u, 337u, 347u, 349u,
			353u, 359u, 367u, 373u, 379u, 383u, 389u, 397u, 401u, 409u,
			419u, 421u, 431u, 433u, 439u, 443u, 449u, 457u, 461u, 463u,
			467u, 479u, 487u, 491u, 499u, 503u, 509u, 521u, 523u, 541u,
			547u, 557u, 563u, 569u, 571u, 577u, 587u, 593u, 599u, 601u,
			607u, 613u, 617u, 619u, 631u, 641u, 643u, 647u, 653u, 659u,
			661u, 673u, 677u, 683u, 691u, 701u, 709u, 719u, 727u, 733u,
			739u, 743u, 751u, 757u, 761u, 769u, 773u, 787u, 797u, 809u,
			811u, 821u, 823u, 827u, 829u, 839u, 853u, 857u, 859u, 863u,
			877u, 881u, 883u, 887u, 907u, 911u, 919u, 929u, 937u, 941u,
			947u, 953u, 967u, 971u, 977u, 983u, 991u, 997u, 1009u, 1013u,
			1019u, 1021u, 1031u, 1033u, 1039u, 1049u, 1051u, 1061u, 1063u, 1069u,
			1087u, 1091u, 1093u, 1097u, 1103u, 1109u, 1117u, 1123u, 1129u, 1151u,
			1153u, 1163u, 1171u, 1181u, 1187u, 1193u, 1201u, 1213u, 1217u, 1223u,
			1229u, 1231u, 1237u, 1249u, 1259u, 1277u, 1279u, 1283u, 1289u, 1291u,
			1297u, 1301u, 1303u, 1307u, 1319u, 1321u, 1327u, 1361u, 1367u, 1373u,
			1381u, 1399u, 1409u, 1423u, 1427u, 1429u, 1433u, 1439u, 1447u, 1451u,
			1453u, 1459u, 1471u, 1481u, 1483u, 1487u, 1489u, 1493u, 1499u, 1511u,
			1523u, 1531u, 1543u, 1549u, 1553u, 1559u, 1567u, 1571u, 1579u, 1583u,
			1597u, 1601u, 1607u, 1609u, 1613u, 1619u, 1621u, 1627u, 1637u, 1657u,
			1663u, 1667u, 1669u, 1693u, 1697u, 1699u, 1709u, 1721u, 1723u, 1733u,
			1741u, 1747u, 1753u, 1759u, 1777u, 1783u, 1787u, 1789u, 1801u, 1811u,
			1823u, 1831u, 1847u, 1861u, 1867u, 1871u, 1873u, 1877u, 1879u, 1889u,
			1901u, 1907u, 1913u, 1931u, 1933u, 1949u, 1951u, 1973u, 1979u, 1987u,
			1993u, 1997u, 1999u, 2003u, 2011u, 2017u, 2027u, 2029u, 2039u, 2053u,
			2063u, 2069u, 2081u, 2083u, 2087u, 2089u, 2099u, 2111u, 2113u, 2129u,
			2131u, 2137u, 2141u, 2143u, 2153u, 2161u, 2179u, 2203u, 2207u, 2213u,
			2221u, 2237u, 2239u, 2243u, 2251u, 2267u, 2269u, 2273u, 2281u, 2287u,
			2293u, 2297u, 2309u, 2311u, 2333u, 2339u, 2341u, 2347u, 2351u, 2357u,
			2371u, 2377u, 2381u, 2383u, 2389u, 2393u, 2399u, 2411u, 2417u, 2423u,
			2437u, 2441u, 2447u, 2459u, 2467u, 2473u, 2477u, 2503u, 2521u, 2531u,
			2539u, 2543u, 2549u, 2551u, 2557u, 2579u, 2591u, 2593u, 2609u, 2617u,
			2621u, 2633u, 2647u, 2657u, 2659u, 2663u, 2671u, 2677u, 2683u, 2687u,
			2689u, 2693u, 2699u, 2707u, 2711u, 2713u, 2719u, 2729u, 2731u, 2741u,
			2749u, 2753u, 2767u, 2777u, 2789u, 2791u, 2797u, 2801u, 2803u, 2819u,
			2833u, 2837u, 2843u, 2851u, 2857u, 2861u, 2879u, 2887u, 2897u, 2903u,
			2909u, 2917u, 2927u, 2939u, 2953u, 2957u, 2963u, 2969u, 2971u, 2999u,
			3001u, 3011u, 3019u, 3023u, 3037u, 3041u, 3049u, 3061u, 3067u, 3079u,
			3083u, 3089u, 3109u, 3119u, 3121u, 3137u, 3163u, 3167u, 3169u, 3181u,
			3187u, 3191u, 3203u, 3209u, 3217u, 3221u, 3229u, 3251u, 3253u, 3257u,
			3259u, 3271u, 3299u, 3301u, 3307u, 3313u, 3319u, 3323u, 3329u, 3331u,
			3343u, 3347u, 3359u, 3361u, 3371u, 3373u, 3389u, 3391u, 3407u, 3413u,
			3433u, 3449u, 3457u, 3461u, 3463u, 3467u, 3469u, 3491u, 3499u, 3511u,
			3517u, 3527u, 3529u, 3533u, 3539u, 3541u, 3547u, 3557u, 3559u, 3571u,
			3581u, 3583u, 3593u, 3607u, 3613u, 3617u, 3623u, 3631u, 3637u, 3643u,
			3659u, 3671u, 3673u, 3677u, 3691u, 3697u, 3701u, 3709u, 3719u, 3727u,
			3733u, 3739u, 3761u, 3767u, 3769u, 3779u, 3793u, 3797u, 3803u, 3821u,
			3823u, 3833u, 3847u, 3851u, 3853u, 3863u, 3877u, 3881u, 3889u, 3907u,
			3911u, 3917u, 3919u, 3923u, 3929u, 3931u, 3943u, 3947u, 3967u, 3989u,
			4001u, 4003u, 4007u, 4013u, 4019u, 4021u, 4027u, 4049u, 4051u, 4057u,
			4073u, 4079u, 4091u, 4093u, 4099u, 4111u, 4127u, 4129u, 4133u, 4139u,
			4153u, 4157u, 4159u, 4177u, 4201u, 4211u, 4217u, 4219u, 4229u, 4231u,
			4241u, 4243u, 4253u, 4259u, 4261u, 4271u, 4273u, 4283u, 4289u, 4297u,
			4327u, 4337u, 4339u, 4349u, 4357u, 4363u, 4373u, 4391u, 4397u, 4409u,
			4421u, 4423u, 4441u, 4447u, 4451u, 4457u, 4463u, 4481u, 4483u, 4493u,
			4507u, 4513u, 4517u, 4519u, 4523u, 4547u, 4549u, 4561u, 4567u, 4583u,
			4591u, 4597u, 4603u, 4621u, 4637u, 4639u, 4643u, 4649u, 4651u, 4657u,
			4663u, 4673u, 4679u, 4691u, 4703u, 4721u, 4723u, 4729u, 4733u, 4751u,
			4759u, 4783u, 4787u, 4789u, 4793u, 4799u, 4801u, 4813u, 4817u, 4831u,
			4861u, 4871u, 4877u, 4889u, 4903u, 4909u, 4919u, 4931u, 4933u, 4937u,
			4943u, 4951u, 4957u, 4967u, 4969u, 4973u, 4987u, 4993u, 4999u, 5003u,
			5009u, 5011u, 5021u, 5023u, 5039u, 5051u, 5059u, 5077u, 5081u, 5087u,
			5099u, 5101u, 5107u, 5113u, 5119u, 5147u, 5153u, 5167u, 5171u, 5179u,
			5189u, 5197u, 5209u, 5227u, 5231u, 5233u, 5237u, 5261u, 5273u, 5279u,
			5281u, 5297u, 5303u, 5309u, 5323u, 5333u, 5347u, 5351u, 5381u, 5387u,
			5393u, 5399u, 5407u, 5413u, 5417u, 5419u, 5431u, 5437u, 5441u, 5443u,
			5449u, 5471u, 5477u, 5479u, 5483u, 5501u, 5503u, 5507u, 5519u, 5521u,
			5527u, 5531u, 5557u, 5563u, 5569u, 5573u, 5581u, 5591u, 5623u, 5639u,
			5641u, 5647u, 5651u, 5653u, 5657u, 5659u, 5669u, 5683u, 5689u, 5693u,
			5701u, 5711u, 5717u, 5737u, 5741u, 5743u, 5749u, 5779u, 5783u, 5791u,
			5801u, 5807u, 5813u, 5821u, 5827u, 5839u, 5843u, 5849u, 5851u, 5857u,
			5861u, 5867u, 5869u, 5879u, 5881u, 5897u, 5903u, 5923u, 5927u, 5939u,
			5953u, 5981u, 5987u
		};

		private static RandomNumberGenerator rng;

		private static RandomNumberGenerator Rng
		{
			get
			{
				if (rng == null)
				{
					rng = RandomNumberGenerator.Create();
				}
				return rng;
			}
		}

		[CLSCompliant(false)]
		public BigInteger(Sign sign, uint len)
		{
			data = new uint[len];
			length = len;
		}

		public BigInteger(BigInteger bi)
		{
			data = (uint[])bi.data.Clone();
			length = bi.length;
		}

		[CLSCompliant(false)]
		public BigInteger(BigInteger bi, uint len)
		{
			data = new uint[len];
			for (uint num = 0u; num < bi.length; num++)
			{
				data[num] = bi.data[num];
			}
			length = bi.length;
		}

		public BigInteger(byte[] inData)
		{
			if (inData.Length == 0)
			{
				inData = new byte[1];
			}
			length = (uint)inData.Length >> 2;
			int num = inData.Length & 3;
			if (num != 0)
			{
				length++;
			}
			data = new uint[length];
			int num2 = inData.Length - 1;
			int num3 = 0;
			while (num2 >= 3)
			{
				data[num3] = (uint)((inData[num2 - 3] << 24) | (inData[num2 - 2] << 16) | (inData[num2 - 1] << 8) | inData[num2]);
				num2 -= 4;
				num3++;
			}
			switch (num)
			{
			case 1:
				data[length - 1] = inData[0];
				break;
			case 2:
				data[length - 1] = (uint)((inData[0] << 8) | inData[1]);
				break;
			case 3:
				data[length - 1] = (uint)((inData[0] << 16) | (inData[1] << 8) | inData[2]);
				break;
			}
			Normalize();
		}

		[CLSCompliant(false)]
		public BigInteger(uint ui)
		{
			data = new uint[1] { ui };
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(uint value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(int value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			return new BigInteger((uint)value);
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			if (bi1 == 0u)
			{
				return new BigInteger(bi2);
			}
			if (bi2 == 0u)
			{
				return new BigInteger(bi1);
			}
			return Kernel.AddSameSign(bi1, bi2);
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			if (bi2 == 0u)
			{
				return new BigInteger(bi1);
			}
			if (bi1 == 0u)
			{
				throw new ArithmeticException("Operation would return a negative value");
			}
			return Kernel.Compare(bi1, bi2) switch
			{
				Sign.Zero => 0, 
				Sign.Positive => Kernel.Subtract(bi1, bi2), 
				Sign.Negative => throw new ArithmeticException("Operation would return a negative value"), 
				_ => throw new Exception(), 
			};
		}

		[CLSCompliant(false)]
		public static uint operator %(BigInteger bi, uint ui)
		{
			return Kernel.DwordMod(bi, ui);
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.multiByteDivide(bi1, bi2)[1];
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.multiByteDivide(bi1, bi2)[0];
		}

		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			if (bi1 == 0u || bi2 == 0u)
			{
				return 0;
			}
			if (bi1.data.Length < bi1.length)
			{
				throw new IndexOutOfRangeException("bi1 out of range");
			}
			if (bi2.data.Length < bi2.length)
			{
				throw new IndexOutOfRangeException("bi2 out of range");
			}
			BigInteger bigInteger = new BigInteger(Sign.Positive, bi1.length + bi2.length);
			Kernel.Multiply(bi1.data, 0u, bi1.length, bi2.data, 0u, bi2.length, bigInteger.data, 0u);
			bigInteger.Normalize();
			return bigInteger;
		}

		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			return Kernel.LeftShift(bi1, shiftVal);
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			return Kernel.RightShift(bi1, shiftVal);
		}

		public static BigInteger GenerateRandom(int bits, RandomNumberGenerator rng)
		{
			int num = bits >> 5;
			int num2 = bits & 0x1F;
			if (num2 != 0)
			{
				num++;
			}
			BigInteger bigInteger = new BigInteger(Sign.Positive, (uint)(num + 1));
			byte[] src = new byte[num << 2];
			rng.GetBytes(src);
			Buffer.BlockCopy(src, 0, bigInteger.data, 0, num << 2);
			if (num2 != 0)
			{
				uint num3 = (uint)(1 << num2 - 1);
				bigInteger.data[num - 1] |= num3;
				num3 = 4294967295u >> 32 - num2;
				bigInteger.data[num - 1] &= num3;
			}
			else
			{
				bigInteger.data[num - 1] |= 2147483648u;
			}
			bigInteger.Normalize();
			return bigInteger;
		}

		public static BigInteger GenerateRandom(int bits)
		{
			return GenerateRandom(bits, Rng);
		}

		public int BitCount()
		{
			Normalize();
			uint num = data[length - 1];
			uint num2 = 2147483648u;
			uint num3 = 32u;
			while (num3 != 0 && (num & num2) == 0)
			{
				num3--;
				num2 >>= 1;
			}
			return (int)(num3 + (length - 1 << 5));
		}

		public bool TestBit(int bitNum)
		{
			if (bitNum < 0)
			{
				throw new IndexOutOfRangeException("bitNum out of range");
			}
			uint num = (uint)bitNum >> 5;
			byte b = (byte)(bitNum & 0x1F);
			uint num2 = (uint)(1 << (int)b);
			return (data[num] | num2) == data[num];
		}

		[CLSCompliant(false)]
		public void SetBit(uint bitNum)
		{
			SetBit(bitNum, value: true);
		}

		[CLSCompliant(false)]
		public void SetBit(uint bitNum, bool value)
		{
			uint num = bitNum >> 5;
			if (num < length)
			{
				uint num2 = (uint)(1 << (int)(bitNum & 0x1F));
				if (value)
				{
					data[num] |= num2;
				}
				else
				{
					data[num] &= ~num2;
				}
			}
		}

		public int LowestSetBit()
		{
			if (this == 0u)
			{
				return -1;
			}
			int i;
			for (i = 0; !TestBit(i); i++)
			{
			}
			return i;
		}

		public byte[] GetBytes()
		{
			if (this == 0u)
			{
				return new byte[1];
			}
			int num = BitCount();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = num2 & 3;
			if (num3 == 0)
			{
				num3 = 4;
			}
			int num4 = 0;
			for (int num5 = (int)(length - 1); num5 >= 0; num5--)
			{
				uint num6 = data[num5];
				for (int num7 = num3 - 1; num7 >= 0; num7--)
				{
					array[num4 + num7] = (byte)(num6 & 0xFF);
					num6 >>= 8;
				}
				num4 += num3;
				num3 = 4;
			}
			return array;
		}

		[CLSCompliant(false)]
		public static bool operator ==(BigInteger bi1, uint ui)
		{
			if (bi1.length != 1)
			{
				bi1.Normalize();
			}
			if (bi1.length == 1)
			{
				return bi1.data[0] == ui;
			}
			return false;
		}

		[CLSCompliant(false)]
		public static bool operator !=(BigInteger bi1, uint ui)
		{
			if (bi1.length != 1)
			{
				bi1.Normalize();
			}
			if (bi1.length == 1)
			{
				return bi1.data[0] != ui;
			}
			return true;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			if ((object)bi1 == bi2)
			{
				return true;
			}
			if (null == bi1 || null == bi2)
			{
				return false;
			}
			return Kernel.Compare(bi1, bi2) == Sign.Zero;
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			if ((object)bi1 == bi2)
			{
				return false;
			}
			if (null == bi1 || null == bi2)
			{
				return true;
			}
			return Kernel.Compare(bi1, bi2) != Sign.Zero;
		}

		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.Compare(bi1, bi2) > Sign.Zero;
		}

		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.Compare(bi1, bi2) < Sign.Zero;
		}

		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.Compare(bi1, bi2) >= Sign.Zero;
		}

		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			return Kernel.Compare(bi1, bi2) <= Sign.Zero;
		}

		[CLSCompliant(false)]
		public string ToString(uint radix)
		{
			return ToString(radix, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}

		[CLSCompliant(false)]
		public string ToString(uint radix, string characterSet)
		{
			if (characterSet.Length < radix)
			{
				throw new ArgumentException("charSet length less than radix", "characterSet");
			}
			if (radix == 1)
			{
				throw new ArgumentException("There is no such thing as radix one notation", "radix");
			}
			if (this == 0u)
			{
				return "0";
			}
			if (this == 1u)
			{
				return "1";
			}
			string text = "";
			BigInteger bigInteger = new BigInteger(this);
			while (bigInteger != 0u)
			{
				uint index = Kernel.SingleByteDivideInPlace(bigInteger, radix);
				text = characterSet[(int)index] + text;
			}
			return text;
		}

		private void Normalize()
		{
			while (length != 0 && data[length - 1] == 0)
			{
				length--;
			}
			if (length == 0)
			{
				length++;
			}
		}

		public void Clear()
		{
			for (int i = 0; i < length; i++)
			{
				data[i] = 0u;
			}
		}

		public override int GetHashCode()
		{
			uint num = 0u;
			for (uint num2 = 0u; num2 < length; num2++)
			{
				num ^= data[num2];
			}
			return (int)num;
		}

		public override string ToString()
		{
			return ToString(10u);
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			if (o is int)
			{
				if ((int)o >= 0)
				{
					return this == (uint)o;
				}
				return false;
			}
			BigInteger bigInteger = o as BigInteger;
			if (bigInteger == null)
			{
				return false;
			}
			return Kernel.Compare(this, bigInteger) == Sign.Zero;
		}

		public BigInteger ModInverse(BigInteger modulus)
		{
			return Kernel.modInverse(this, modulus);
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			return new ModulusRing(n).Pow(this, exp);
		}

		public static BigInteger GeneratePseudoPrime(int bits)
		{
			return new SequentialSearchPrimeGeneratorBase().GenerateNewPrime(bits);
		}

		public void Incr2()
		{
			int num = 0;
			data[0] += 2u;
			if (data[0] < 2)
			{
				data[++num]++;
				while (data[num++] == 0)
				{
					data[num]++;
				}
				if (length == (uint)num)
				{
					length++;
				}
			}
		}
	}
}
namespace Mono.Math.Prime
{
	public enum ConfidenceFactor
	{
		ExtraLow,
		Low,
		Medium,
		High,
		ExtraHigh,
		Provable
	}
	public delegate bool PrimalityTest(BigInteger bi, ConfidenceFactor confidence);
	public sealed class PrimalityTests
	{
		private static int GetSPPRounds(BigInteger bi, ConfidenceFactor confidence)
		{
			int num = bi.BitCount();
			int num2 = ((num <= 100) ? 27 : ((num <= 150) ? 18 : ((num <= 200) ? 15 : ((num <= 250) ? 12 : ((num <= 300) ? 9 : ((num <= 350) ? 8 : ((num <= 400) ? 7 : ((num <= 500) ? 6 : ((num <= 600) ? 5 : ((num <= 800) ? 4 : ((num > 1250) ? 2 : 3)))))))))));
			switch (confidence)
			{
			case ConfidenceFactor.ExtraLow:
				num2 >>= 2;
				if (num2 == 0)
				{
					return 1;
				}
				return num2;
			case ConfidenceFactor.Low:
				num2 >>= 1;
				if (num2 == 0)
				{
					return 1;
				}
				return num2;
			case ConfidenceFactor.Medium:
				return num2;
			case ConfidenceFactor.High:
				return num2 << 1;
			case ConfidenceFactor.ExtraHigh:
				return num2 << 2;
			case ConfidenceFactor.Provable:
				throw new Exception("The Rabin-Miller test can not be executed in a way such that its results are provable");
			default:
				throw new ArgumentOutOfRangeException("confidence");
			}
		}

		public static bool RabinMillerTest(BigInteger n, ConfidenceFactor confidence)
		{
			int num = n.BitCount();
			int sPPRounds = GetSPPRounds(num, confidence);
			BigInteger bigInteger = n - 1;
			int num2 = bigInteger.LowestSetBit();
			BigInteger bigInteger2 = bigInteger >> num2;
			BigInteger.ModulusRing modulusRing = new BigInteger.ModulusRing(n);
			BigInteger bigInteger3 = null;
			if (n.BitCount() > 100)
			{
				bigInteger3 = modulusRing.Pow(2u, bigInteger2);
			}
			for (int i = 0; i < sPPRounds; i++)
			{
				if (i > 0 || bigInteger3 == null)
				{
					BigInteger bigInteger4 = null;
					do
					{
						bigInteger4 = BigInteger.GenerateRandom(num);
					}
					while (bigInteger4 <= 2 && bigInteger4 >= bigInteger);
					bigInteger3 = modulusRing.Pow(bigInteger4, bigInteger2);
				}
				if (bigInteger3 == 1u)
				{
					continue;
				}
				for (int j = 0; j < num2; j++)
				{
					if (!(bigInteger3 != bigInteger))
					{
						break;
					}
					bigInteger3 = modulusRing.Pow(bigInteger3, 2);
					if (bigInteger3 == 1u)
					{
						return false;
					}
				}
				if (bigInteger3 != bigInteger)
				{
					return false;
				}
			}
			return true;
		}
	}
}
namespace Mono.Math.Prime.Generator
{
	public abstract class PrimeGeneratorBase
	{
		public virtual ConfidenceFactor Confidence => ConfidenceFactor.Medium;

		public virtual PrimalityTest PrimalityTest => PrimalityTests.RabinMillerTest;

		public virtual int TrialDivisionBounds => 4000;

		public abstract BigInteger GenerateNewPrime(int bits);
	}
	public class SequentialSearchPrimeGeneratorBase : PrimeGeneratorBase
	{
		protected virtual BigInteger GenerateSearchBase(int bits, object context)
		{
			BigInteger bigInteger = BigInteger.GenerateRandom(bits);
			bigInteger.SetBit(0u);
			return bigInteger;
		}

		public override BigInteger GenerateNewPrime(int bits)
		{
			return GenerateNewPrime(bits, null);
		}

		public virtual BigInteger GenerateNewPrime(int bits, object context)
		{
			BigInteger bigInteger = GenerateSearchBase(bits, context);
			uint num = bigInteger % 3234846615u;
			int trialDivisionBounds = TrialDivisionBounds;
			uint[] smallPrimes = BigInteger.smallPrimes;
			while (true)
			{
				if (num % 3 != 0 && num % 5 != 0 && num % 7 != 0 && num % 11 != 0 && num % 13 != 0 && num % 17 != 0 && num % 19 != 0 && num % 23 != 0 && num % 29 != 0)
				{
					int num2 = 10;
					while (true)
					{
						if (num2 < smallPrimes.Length && smallPrimes[num2] <= trialDivisionBounds)
						{
							if (bigInteger % smallPrimes[num2] == 0)
							{
								break;
							}
							num2++;
							continue;
						}
						if (!IsPrimeAcceptable(bigInteger, context) || !PrimalityTest(bigInteger, Confidence))
						{
							break;
						}
						return bigInteger;
					}
				}
				num += 2;
				if (num >= 3234846615u)
				{
					num -= 3234846615u;
				}
				bigInteger.Incr2();
			}
		}

		protected virtual bool IsPrimeAcceptable(BigInteger bi, object context)
		{
			return true;
		}
	}
}
