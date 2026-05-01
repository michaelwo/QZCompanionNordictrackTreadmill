using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson.Utilities;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Newtonsoft.Json.Bson.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f561df277c6c0b497d629032b410cdcf286e537c054724f7ffa0164345f62b3e642029d7a80cc351918955328c4adc8a048823ef90b0cf38ea7db0d729caf2b633c3babe08b0310198c1081995c19029bc675193744eab9d7345b8a67258ec17d112cebdbbb2a281487dceeafb9d83aa930f32103fbe1d2911425bc5744002c7")]
[assembly: AssemblyTrademark("")]
[assembly: CLSCompliant(true)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Newtonsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright © James Newton-King 2017")]
[assembly: AssemblyDescription("Json.NET BSON adds support for reading and writing BSON")]
[assembly: AssemblyFileVersion("1.0.2.22727")]
[assembly: AssemblyInformationalVersion("1.0.2+a1db92678e7e72eb733f37079f3a93bfb6215338")]
[assembly: AssemblyProduct("Json.NET BSON")]
[assembly: AssemblyTitle("Json.NET BSON .NET Standard 2.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Newtonsoft.Json.Bson
{
	internal class AsyncBinaryReader : BinaryReader
	{
		private byte[] _buffer;

		private byte[] Buffer => _buffer ?? (_buffer = new byte[16]);

		public AsyncBinaryReader(Stream input)
			: base(input)
		{
		}

		private void EndOfStream()
		{
			throw new EndOfStreamException("Unable to read beyond the end of the stream.");
		}

		private void FileNotOpen()
		{
			throw new ObjectDisposedException("Cannot access a closed file.");
		}

		private async Task<byte[]> ReadBufferAsync(int size, CancellationToken cancellationToken)
		{
			byte[] buffer = Buffer;
			int offset = 0;
			if (BaseStream == null)
			{
				FileNotOpen();
			}
			do
			{
				int num = await BaseStream.ReadAsync(buffer, offset, size, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (num == 0)
				{
					EndOfStream();
				}
				offset += num;
				size -= num;
			}
			while (size > 0);
			return buffer;
		}

		public async Task<byte> ReadByteAsync(CancellationToken cancellationToken)
		{
			return (await ReadBufferAsync(1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))[0];
		}

		public async Task<Newtonsoft.Json.Bson.BsonType> ReadBsonTypeAsync(CancellationToken cancellationToken)
		{
			return (Newtonsoft.Json.Bson.BsonType)(await ReadBufferAsync(1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))[0];
		}

		public async Task<long> ReadInt64Async(CancellationToken cancellationToken)
		{
			byte[] array = await ReadBufferAsync(8, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			uint num = (uint)(array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24));
			return (long)(((ulong)(uint)(array[4] | (array[5] << 8) | (array[6] << 16) | (array[7] << 24)) << 32) | num);
		}

		public async Task<int> ReadInt32Async(CancellationToken cancellationToken)
		{
			byte[] array = await ReadBufferAsync(4, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24);
		}

		public async Task<double> ReadDoubleAsync(CancellationToken cancellationToken)
		{
			byte[] array = await ReadBufferAsync(8, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			uint num = (uint)(array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24));
			return BitConverter.Int64BitsToDouble((long)(((ulong)(uint)(array[4] | (array[5] << 8) | (array[6] << 16) | (array[7] << 24)) << 32) | num));
		}

		public Task<int> ReadAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
		{
			Stream baseStream = BaseStream;
			if (baseStream == null)
			{
				FileNotOpen();
			}
			return baseStream.ReadAsync(buffer, index, count, cancellationToken);
		}

		public async Task<byte[]> ReadBytesAsync(int count, CancellationToken cancellationToken)
		{
			Stream stream = BaseStream;
			if (stream == null)
			{
				FileNotOpen();
			}
			if (count == 0)
			{
				return new byte[0];
			}
			byte[] result = new byte[count];
			int numRead = 0;
			do
			{
				int num = await stream.ReadAsync(result, numRead, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (num == 0)
				{
					break;
				}
				numRead += num;
				count -= num;
			}
			while (count > 0);
			if (numRead != result.Length)
			{
				byte[] array = new byte[numRead];
				result.CopyTo(array, 0);
				return array;
			}
			return result;
		}
	}
	internal sealed class AsyncBinaryReaderOwningReader : AsyncBinaryReader
	{
		private readonly BinaryReader _reader;

		public AsyncBinaryReaderOwningReader(BinaryReader reader)
			: base(reader.BaseStream)
		{
			_reader = reader;
		}

		public override void Close()
		{
			_reader.Close();
		}

		protected override void Dispose(bool disposing)
		{
			((IDisposable)_reader).Dispose();
		}
	}
	internal class AsyncBinaryWriter : BinaryWriter
	{
		private static readonly byte[] ByteValueBuffer = new byte[19]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18
		};

		private byte[] _buffer;

		private byte[] Buffer => _buffer ?? (_buffer = new byte[8]);

		public AsyncBinaryWriter(Stream stream)
			: base(stream)
		{
		}

		public Task FlushAsync(CancellationToken cancellationToken)
		{
			return OutStream.FlushAsync(cancellationToken);
		}

		public Task WriteAsync(bool value, CancellationToken cancellationToken)
		{
			return OutStream.WriteAsync(ByteValueBuffer, value ? 1 : 0, 1, cancellationToken);
		}

		public Task WriteAsync(int value, CancellationToken cancellationToken)
		{
			byte[] buffer = Buffer;
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			buffer[3] = (byte)(value >> 24);
			return OutStream.WriteAsync(buffer, 0, 4, cancellationToken);
		}

		public Task WriteAsync(long value, CancellationToken cancellationToken)
		{
			byte[] buffer = Buffer;
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			buffer[3] = (byte)(value >> 24);
			buffer[4] = (byte)(value >> 32);
			buffer[5] = (byte)(value >> 40);
			buffer[6] = (byte)(value >> 48);
			buffer[7] = (byte)(value >> 56);
			return OutStream.WriteAsync(buffer, 0, 8, cancellationToken);
		}

		public Task WriteAsync(byte value, CancellationToken cancellationToken)
		{
			return OutStream.WriteAsync(ByteValueBuffer, value, 1, cancellationToken);
		}

		public Task WriteAsync(double value, CancellationToken cancellationToken)
		{
			return WriteAsync(BitConverter.DoubleToInt64Bits(value), cancellationToken);
		}

		public Task WriteAsync(byte[] buffer, CancellationToken cancellationToken)
		{
			return OutStream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
		}

		public Task WriteAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
		{
			return OutStream.WriteAsync(buffer, index, count, cancellationToken);
		}
	}
	internal class AsyncBinaryWriterOwningWriter : AsyncBinaryWriter
	{
		private readonly BinaryWriter _writer;

		public AsyncBinaryWriterOwningWriter(BinaryWriter writer)
			: base(writer.BaseStream)
		{
			_writer = writer;
		}

		public override void Close()
		{
			_writer.Close();
		}

		protected override void Dispose(bool disposing)
		{
			_writer.Dispose();
		}
	}
	internal enum BsonBinaryType : byte
	{
		Binary = 0,
		Function = 1,
		[Obsolete("This type has been deprecated in the BSON specification. Use Binary instead.")]
		BinaryOld = 2,
		[Obsolete("This type has been deprecated in the BSON specification. Use Uuid instead.")]
		UuidOld = 3,
		Uuid = 4,
		Md5 = 5,
		UserDefined = 128
	}
	internal class BsonBinaryWriter
	{
		private readonly AsyncBinaryWriter _asyncWriter;

		private static readonly Encoding Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		private readonly BinaryWriter _writer;

		private byte[] _largeByteBuffer;

		public DateTimeKind DateTimeKindHandling { get; set; }

		public Task FlushAsync(CancellationToken cancellationToken)
		{
			if (_asyncWriter == null)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return cancellationToken.FromCanceled();
				}
				Flush();
				return AsyncUtils.CompletedTask;
			}
			return _asyncWriter.FlushAsync(cancellationToken);
		}

		public Task WriteTokenAsync(Newtonsoft.Json.Bson.BsonToken t, CancellationToken cancellationToken)
		{
			if (_asyncWriter == null)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return cancellationToken.FromCanceled();
				}
				WriteToken(t);
				return AsyncUtils.CompletedTask;
			}
			CalculateSize(t);
			return WriteTokenInternalAsync(t, cancellationToken);
		}

		private Task WriteTokenInternalAsync(Newtonsoft.Json.Bson.BsonToken t, CancellationToken cancellationToken)
		{
			switch (t.Type)
			{
			case Newtonsoft.Json.Bson.BsonType.Object:
				return WriteObjectAsync((Newtonsoft.Json.Bson.BsonObject)t, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Array:
				return WriteArrayAsync((Newtonsoft.Json.Bson.BsonArray)t, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Integer:
				return _asyncWriter.WriteAsync(Convert.ToInt32(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Long:
				return _asyncWriter.WriteAsync(Convert.ToInt64(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Number:
				return _asyncWriter.WriteAsync(Convert.ToDouble(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.String:
			{
				Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
				return WriteStringAsync((string)bsonString.Value, bsonString.ByteCount, bsonString.CalculatedSize - 4, cancellationToken);
			}
			case Newtonsoft.Json.Bson.BsonType.Boolean:
				return _asyncWriter.WriteAsync((bool)((Newtonsoft.Json.Bson.BsonValue)t).Value, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Undefined:
			case Newtonsoft.Json.Bson.BsonType.Null:
				return AsyncUtils.CompletedTask;
			case Newtonsoft.Json.Bson.BsonType.Date:
			{
				Newtonsoft.Json.Bson.BsonValue bsonValue = (Newtonsoft.Json.Bson.BsonValue)t;
				return _asyncWriter.WriteAsync(TicksFromDateObject(bsonValue.Value), cancellationToken);
			}
			case Newtonsoft.Json.Bson.BsonType.Binary:
				return WriteBinaryAsync((Newtonsoft.Json.Bson.BsonBinary)t, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Oid:
				return _asyncWriter.WriteAsync((byte[])((Newtonsoft.Json.Bson.BsonValue)t).Value, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Regex:
				return WriteRegexAsync((Newtonsoft.Json.Bson.BsonRegex)t, cancellationToken);
			default:
				throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
			}
		}

		private async Task WriteObjectAsync(Newtonsoft.Json.Bson.BsonObject value, CancellationToken cancellationToken)
		{
			await _asyncWriter.WriteAsync(value.CalculatedSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			foreach (Newtonsoft.Json.Bson.BsonProperty property in value)
			{
				await _asyncWriter.WriteAsync((byte)property.Value.Type, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await WriteStringAsync((string)property.Name.Value, property.Name.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				Newtonsoft.Json.Bson.BsonType type = property.Value.Type;
				if (type != Newtonsoft.Json.Bson.BsonType.Null && type != Newtonsoft.Json.Bson.BsonType.Undefined)
				{
					await WriteTokenInternalAsync(property.Value, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			await _asyncWriter.WriteAsync((byte)0, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task WriteArrayAsync(Newtonsoft.Json.Bson.BsonArray value, CancellationToken cancellationToken)
		{
			await _asyncWriter.WriteAsync(value.CalculatedSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			ulong index = 0uL;
			foreach (Newtonsoft.Json.Bson.BsonToken c in value)
			{
				await _asyncWriter.WriteAsync((byte)c.Type, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await WriteStringAsync(index.ToString(CultureInfo.InvariantCulture), MathUtils.IntLength(index), null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				Newtonsoft.Json.Bson.BsonType type = c.Type;
				if (type != Newtonsoft.Json.Bson.BsonType.Null && type != Newtonsoft.Json.Bson.BsonType.Undefined)
				{
					await WriteTokenInternalAsync(c, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				index++;
			}
			await _asyncWriter.WriteAsync((byte)0, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task WriteBinaryAsync(Newtonsoft.Json.Bson.BsonBinary value, CancellationToken cancellationToken)
		{
			byte[] data = (byte[])value.Value;
			await _asyncWriter.WriteAsync(data.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await _asyncWriter.WriteAsync((byte)value.BinaryType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await _asyncWriter.WriteAsync(data, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task WriteRegexAsync(Newtonsoft.Json.Bson.BsonRegex value, CancellationToken cancellationToken)
		{
			await WriteStringAsync((string)value.Pattern.Value, value.Pattern.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await WriteStringAsync((string)value.Options.Value, value.Options.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task WriteStringAsync(string s, int byteCount, int? calculatedlengthPrefix, CancellationToken cancellationToken)
		{
			if (calculatedlengthPrefix.HasValue)
			{
				return WritePrefixedStringAsync(s, byteCount, calculatedlengthPrefix.GetValueOrDefault(), cancellationToken);
			}
			return WriteUtf8BytesAsync(s, byteCount, cancellationToken);
		}

		private async Task WritePrefixedStringAsync(string s, int byteCount, int calculatedlengthPrefix, CancellationToken cancellationToken)
		{
			await _asyncWriter.WriteAsync(calculatedlengthPrefix, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await WriteUtf8BytesAsync(s, byteCount, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Task WriteUtf8BytesAsync(string s, int byteCount, CancellationToken cancellationToken)
		{
			if (s == null)
			{
				return _asyncWriter.WriteAsync((byte)0, cancellationToken);
			}
			if (byteCount <= 255)
			{
				if (_largeByteBuffer == null)
				{
					_largeByteBuffer = new byte[256];
				}
				else
				{
					_largeByteBuffer[byteCount] = 0;
				}
				Encoding.GetBytes(s, 0, s.Length, _largeByteBuffer, 0);
				return _asyncWriter.WriteAsync(_largeByteBuffer, 0, byteCount + 1, cancellationToken);
			}
			byte[] array = new byte[byteCount + 1];
			Encoding.GetBytes(s, 0, s.Length, array, 0);
			return _asyncWriter.WriteAsync(array, cancellationToken);
		}

		public BsonBinaryWriter(BinaryWriter writer)
		{
			DateTimeKindHandling = DateTimeKind.Utc;
			_asyncWriter = writer as AsyncBinaryWriter;
			_writer = writer;
		}

		public void Flush()
		{
			_writer.Flush();
		}

		public void Close()
		{
			_writer.Close();
		}

		public void WriteToken(Newtonsoft.Json.Bson.BsonToken t)
		{
			CalculateSize(t);
			WriteTokenInternal(t);
		}

		private void WriteTokenInternal(Newtonsoft.Json.Bson.BsonToken t)
		{
			switch (t.Type)
			{
			case Newtonsoft.Json.Bson.BsonType.Object:
			{
				Newtonsoft.Json.Bson.BsonObject bsonObject = (Newtonsoft.Json.Bson.BsonObject)t;
				_writer.Write(bsonObject.CalculatedSize);
				foreach (Newtonsoft.Json.Bson.BsonProperty item in bsonObject)
				{
					_writer.Write((sbyte)item.Value.Type);
					WriteString((string)item.Name.Value, item.Name.ByteCount, null);
					WriteTokenInternal(item.Value);
				}
				_writer.Write((byte)0);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Array:
			{
				Newtonsoft.Json.Bson.BsonArray bsonArray = (Newtonsoft.Json.Bson.BsonArray)t;
				_writer.Write(bsonArray.CalculatedSize);
				ulong num = 0uL;
				foreach (Newtonsoft.Json.Bson.BsonToken item2 in bsonArray)
				{
					_writer.Write((sbyte)item2.Type);
					WriteString(num.ToString(CultureInfo.InvariantCulture), MathUtils.IntLength(num), null);
					WriteTokenInternal(item2);
					num++;
				}
				_writer.Write((byte)0);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Integer:
			{
				Newtonsoft.Json.Bson.BsonValue bsonValue4 = (Newtonsoft.Json.Bson.BsonValue)t;
				_writer.Write(Convert.ToInt32(bsonValue4.Value, CultureInfo.InvariantCulture));
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Long:
			{
				Newtonsoft.Json.Bson.BsonValue bsonValue3 = (Newtonsoft.Json.Bson.BsonValue)t;
				_writer.Write(Convert.ToInt64(bsonValue3.Value, CultureInfo.InvariantCulture));
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Number:
			{
				Newtonsoft.Json.Bson.BsonValue bsonValue2 = (Newtonsoft.Json.Bson.BsonValue)t;
				_writer.Write(Convert.ToDouble(bsonValue2.Value, CultureInfo.InvariantCulture));
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.String:
			{
				Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
				WriteString((string)bsonString.Value, bsonString.ByteCount, bsonString.CalculatedSize - 4);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Boolean:
				_writer.Write(t == Newtonsoft.Json.Bson.BsonBoolean.True);
				break;
			case Newtonsoft.Json.Bson.BsonType.Date:
			{
				Newtonsoft.Json.Bson.BsonValue bsonValue = (Newtonsoft.Json.Bson.BsonValue)t;
				_writer.Write(TicksFromDateObject(bsonValue.Value));
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Binary:
			{
				Newtonsoft.Json.Bson.BsonBinary bsonBinary = (Newtonsoft.Json.Bson.BsonBinary)t;
				byte[] array = (byte[])bsonBinary.Value;
				_writer.Write(array.Length);
				_writer.Write((byte)bsonBinary.BinaryType);
				_writer.Write(array);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Oid:
			{
				byte[] buffer = (byte[])((Newtonsoft.Json.Bson.BsonValue)t).Value;
				_writer.Write(buffer);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Regex:
			{
				Newtonsoft.Json.Bson.BsonRegex bsonRegex = (Newtonsoft.Json.Bson.BsonRegex)t;
				WriteString((string)bsonRegex.Pattern.Value, bsonRegex.Pattern.ByteCount, null);
				WriteString((string)bsonRegex.Options.Value, bsonRegex.Options.ByteCount, null);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
			case Newtonsoft.Json.Bson.BsonType.Undefined:
			case Newtonsoft.Json.Bson.BsonType.Null:
				break;
			}
		}

		private long TicksFromDateObject(object value)
		{
			if (value is DateTimeOffset dateTimeOffset)
			{
				return DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTimeOffset.UtcDateTime, dateTimeOffset.Offset);
			}
			DateTime dateTime = (DateTime)value;
			if (DateTimeKindHandling == DateTimeKind.Utc)
			{
				dateTime = dateTime.ToUniversalTime();
			}
			else if (DateTimeKindHandling == DateTimeKind.Local)
			{
				dateTime = dateTime.ToLocalTime();
			}
			return DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTime, convertToUtc: false);
		}

		private void WriteString(string s, int byteCount, int? calculatedlengthPrefix)
		{
			if (calculatedlengthPrefix.HasValue)
			{
				_writer.Write(calculatedlengthPrefix.GetValueOrDefault());
			}
			WriteUtf8Bytes(s, byteCount);
			_writer.Write((byte)0);
		}

		public void WriteUtf8Bytes(string s, int byteCount)
		{
			if (s == null)
			{
				return;
			}
			if (byteCount <= 256)
			{
				if (_largeByteBuffer == null)
				{
					_largeByteBuffer = new byte[256];
				}
				Encoding.GetBytes(s, 0, s.Length, _largeByteBuffer, 0);
				_writer.Write(_largeByteBuffer, 0, byteCount);
			}
			else
			{
				byte[] bytes = Encoding.GetBytes(s);
				_writer.Write(bytes);
			}
		}

		private int CalculateSize(int stringByteCount)
		{
			return stringByteCount + 1;
		}

		private int CalculateSizeWithLength(int stringByteCount, bool includeSize)
		{
			return ((!includeSize) ? 1 : 5) + stringByteCount;
		}

		private int CalculateSize(Newtonsoft.Json.Bson.BsonToken t)
		{
			switch (t.Type)
			{
			case Newtonsoft.Json.Bson.BsonType.Object:
			{
				Newtonsoft.Json.Bson.BsonObject bsonObject = (Newtonsoft.Json.Bson.BsonObject)t;
				int num4 = 4;
				foreach (Newtonsoft.Json.Bson.BsonProperty item in bsonObject)
				{
					int num5 = 1;
					num5 += CalculateSize(item.Name);
					num5 += CalculateSize(item.Value);
					num4 += num5;
				}
				return bsonObject.CalculatedSize = num4 + 1;
			}
			case Newtonsoft.Json.Bson.BsonType.Array:
			{
				Newtonsoft.Json.Bson.BsonArray bsonArray = (Newtonsoft.Json.Bson.BsonArray)t;
				int num2 = 4;
				ulong num3 = 0uL;
				foreach (Newtonsoft.Json.Bson.BsonToken item2 in bsonArray)
				{
					num2++;
					num2 += CalculateSize(MathUtils.IntLength(num3));
					num2 += CalculateSize(item2);
					num3++;
				}
				num2++;
				bsonArray.CalculatedSize = num2;
				return bsonArray.CalculatedSize;
			}
			case Newtonsoft.Json.Bson.BsonType.Integer:
				return 4;
			case Newtonsoft.Json.Bson.BsonType.Long:
				return 8;
			case Newtonsoft.Json.Bson.BsonType.Number:
				return 8;
			case Newtonsoft.Json.Bson.BsonType.String:
			{
				Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
				string text = (string)bsonString.Value;
				bsonString.ByteCount = ((text != null) ? Encoding.GetByteCount(text) : 0);
				bsonString.CalculatedSize = CalculateSizeWithLength(bsonString.ByteCount, bsonString.IncludeLength);
				return bsonString.CalculatedSize;
			}
			case Newtonsoft.Json.Bson.BsonType.Boolean:
				return 1;
			case Newtonsoft.Json.Bson.BsonType.Undefined:
			case Newtonsoft.Json.Bson.BsonType.Null:
				return 0;
			case Newtonsoft.Json.Bson.BsonType.Date:
				return 8;
			case Newtonsoft.Json.Bson.BsonType.Binary:
			{
				Newtonsoft.Json.Bson.BsonBinary obj = (Newtonsoft.Json.Bson.BsonBinary)t;
				byte[] array = (byte[])obj.Value;
				obj.CalculatedSize = 5 + array.Length;
				return obj.CalculatedSize;
			}
			case Newtonsoft.Json.Bson.BsonType.Oid:
				return 12;
			case Newtonsoft.Json.Bson.BsonType.Regex:
			{
				Newtonsoft.Json.Bson.BsonRegex bsonRegex = (Newtonsoft.Json.Bson.BsonRegex)t;
				int num = 0;
				num += CalculateSize(bsonRegex.Pattern);
				num += CalculateSize(bsonRegex.Options);
				bsonRegex.CalculatedSize = num;
				return bsonRegex.CalculatedSize;
			}
			default:
				throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
			}
		}
	}
	public class BsonDataObjectId
	{
		public byte[] Value { get; private set; }

		public BsonDataObjectId(byte[] value)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			if (value.Length != 12)
			{
				throw new ArgumentException("An ObjectId must be 12 bytes", "value");
			}
			Value = value;
		}
	}
	public class BsonDataReader : JsonReader
	{
		private enum BsonReaderState
		{
			Normal,
			ReferenceStart,
			ReferenceRef,
			ReferenceId,
			CodeWScopeStart,
			CodeWScopeCode,
			CodeWScopeScope,
			CodeWScopeScopeObject,
			CodeWScopeScopeEnd
		}

		private class ContainerContext
		{
			public readonly Newtonsoft.Json.Bson.BsonType Type;

			public int Length;

			public int Position;

			public ContainerContext(Newtonsoft.Json.Bson.BsonType type)
			{
				Type = type;
			}
		}

		private readonly AsyncBinaryReader _asyncReader;

		private const int MaxCharBytesSize = 128;

		private static readonly byte[] SeqRange1 = new byte[2] { 0, 127 };

		private static readonly byte[] SeqRange2 = new byte[2] { 194, 223 };

		private static readonly byte[] SeqRange3 = new byte[2] { 224, 239 };

		private static readonly byte[] SeqRange4 = new byte[2] { 240, 244 };

		private readonly BinaryReader _reader;

		private readonly List<ContainerContext> _stack;

		private byte[] _byteBuffer;

		private char[] _charBuffer;

		private Newtonsoft.Json.Bson.BsonType _currentElementType;

		private BsonReaderState _bsonReaderState;

		private ContainerContext _currentContext;

		private bool _readRootValueAsArray;

		private bool _jsonNet35BinaryCompatibility;

		private DateTimeKind _dateTimeKindHandling;

		[Obsolete("JsonNet35BinaryCompatibility will be removed in a future version of Json.NET.")]
		public bool JsonNet35BinaryCompatibility
		{
			get
			{
				return _jsonNet35BinaryCompatibility;
			}
			set
			{
				_jsonNet35BinaryCompatibility = value;
			}
		}

		public bool ReadRootValueAsArray
		{
			get
			{
				return _readRootValueAsArray;
			}
			set
			{
				_readRootValueAsArray = value;
			}
		}

		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return _dateTimeKindHandling;
			}
			set
			{
				_dateTimeKindHandling = value;
			}
		}

		private Task<string> ReadElementAsync(CancellationToken cancellationToken)
		{
			Task<Newtonsoft.Json.Bson.BsonType> task = ReadTypeAsync(cancellationToken);
			if (task.Status == TaskStatus.RanToCompletion)
			{
				_currentElementType = task.Result;
				return ReadStringAsync(cancellationToken);
			}
			return ReadElementAsync(task, cancellationToken);
		}

		private async Task<string> ReadElementAsync(Task<Newtonsoft.Json.Bson.BsonType> typeReadTask, CancellationToken cancellationToken)
		{
			_currentElementType = await typeReadTask.ConfigureAwait(continueOnCapturedContext: false);
			return await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override Task<bool> ReadAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			Task<bool> task;
			switch (_bsonReaderState)
			{
			case BsonReaderState.Normal:
				task = ReadNormalAsync(cancellationToken);
				break;
			case BsonReaderState.ReferenceStart:
			case BsonReaderState.ReferenceRef:
			case BsonReaderState.ReferenceId:
				task = ReadReferenceAsync(cancellationToken);
				break;
			case BsonReaderState.CodeWScopeStart:
			case BsonReaderState.CodeWScopeCode:
			case BsonReaderState.CodeWScopeScope:
			case BsonReaderState.CodeWScopeScopeObject:
			case BsonReaderState.CodeWScopeScopeEnd:
				task = ReadCodeWScopeAsync(cancellationToken);
				break;
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state: {0}".FormatWith(CultureInfo.InvariantCulture, _bsonReaderState));
			}
			if (task.Status == TaskStatus.RanToCompletion)
			{
				if (!task.Result)
				{
					SetToken(JsonToken.None);
				}
				return task;
			}
			return ReadCatchingEndOfStreamAsync(task);
		}

		private async Task<bool> ReadCatchingEndOfStreamAsync(Task<bool> task)
		{
			try
			{
				if (await task.ConfigureAwait(continueOnCapturedContext: false))
				{
					return true;
				}
			}
			catch (EndOfStreamException)
			{
			}
			SetToken(JsonToken.None);
			return false;
		}

		private async Task<bool> ReadCodeWScopeCodeAsync(CancellationToken cancellationToken)
		{
			await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			_bsonReaderState = BsonReaderState.CodeWScopeScope;
			return true;
		}

		private async Task<bool> ReadCodeWScopeScopeAsync(CancellationToken cancellationToken)
		{
			SetToken(JsonToken.StartObject);
			_bsonReaderState = BsonReaderState.CodeWScopeScopeObject;
			ContainerContext newContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
			PushContext(newContext);
			newContext.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		private async Task<bool> ReadCodeWScopeScopeObjectAsync(CancellationToken cancellationToken)
		{
			bool num = await ReadNormalAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num && TokenType == JsonToken.EndObject)
			{
				_bsonReaderState = BsonReaderState.CodeWScopeScopeEnd;
			}
			return num;
		}

		private Task<bool> ReadCodeWScopeAsync(CancellationToken cancellationToken)
		{
			switch (_bsonReaderState)
			{
			case BsonReaderState.CodeWScopeCode:
				return ReadCodeWScopeCodeAsync(cancellationToken);
			case BsonReaderState.CodeWScopeScope:
				if (base.CurrentState != State.PostValue)
				{
					return ReadCodeWScopeScopeAsync(cancellationToken);
				}
				break;
			case BsonReaderState.CodeWScopeScopeObject:
				return ReadCodeWScopeScopeObjectAsync(cancellationToken);
			default:
				throw new ArgumentOutOfRangeException();
			case BsonReaderState.CodeWScopeStart:
			case BsonReaderState.CodeWScopeScopeEnd:
				break;
			}
			ReadCodeWScope();
			return AsyncUtils.True;
		}

		private async Task<bool> ReadPropertyReferenceAsync(CancellationToken cancellationToken)
		{
			switch (_bsonReaderState)
			{
			case BsonReaderState.ReferenceRef:
				SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				return true;
			case BsonReaderState.ReferenceId:
				SetToken(JsonToken.Bytes, await ReadBytesAsync(12, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				return true;
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
			}
		}

		private Task<bool> ReadReferenceAsync(CancellationToken cancellationToken)
		{
			if (base.CurrentState == State.Property)
			{
				return ReadPropertyReferenceAsync(cancellationToken);
			}
			ReadReference();
			return AsyncUtils.True;
		}

		private async Task<bool> ReadNormalStartAsync(CancellationToken cancellationToken)
		{
			JsonToken token = ((!_readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray);
			Newtonsoft.Json.Bson.BsonType type = ((!_readRootValueAsArray) ? Newtonsoft.Json.Bson.BsonType.Object : Newtonsoft.Json.Bson.BsonType.Array);
			SetToken(token);
			ContainerContext newContext = new ContainerContext(type);
			PushContext(newContext);
			newContext.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		private async Task<bool> ReadNormalPropertyAsync(CancellationToken cancellationToken)
		{
			await ReadTypeAsync(_currentElementType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}

		private async Task<bool> ReadNormalPostValueAsync(ContainerContext context, CancellationToken cancellationToken)
		{
			int num = context.Length - 1;
			if (context.Position < num)
			{
				if (context.Type == Newtonsoft.Json.Bson.BsonType.Array)
				{
					await ReadElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					await ReadTypeAsync(_currentElementType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					SetToken(JsonToken.PropertyName, await ReadElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				}
			}
			else
			{
				if (context.Position != num)
				{
					throw ExceptionUtils.CreateJsonReaderException(this, "Read past end of current container context.");
				}
				if (await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false) != 0)
				{
					throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end of object byte value.");
				}
				PopContext();
				if (_currentContext != null)
				{
					MovePosition(context.Length);
				}
				SetToken((context.Type == Newtonsoft.Json.Bson.BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray);
			}
			return true;
		}

		private Task<bool> ReadNormalAsync(CancellationToken cancellationToken)
		{
			switch (base.CurrentState)
			{
			case State.Start:
				return ReadNormalStartAsync(cancellationToken);
			case State.Property:
				return ReadNormalPropertyAsync(cancellationToken);
			case State.ObjectStart:
			case State.ArrayStart:
			case State.PostValue:
			{
				ContainerContext currentContext = _currentContext;
				if (currentContext != null)
				{
					return ReadNormalPostValueAsync(currentContext, cancellationToken);
				}
				return AsyncUtils.False;
			}
			case State.Complete:
			case State.Closed:
			case State.ConstructorStart:
			case State.Constructor:
			case State.Error:
			case State.Finished:
				return AsyncUtils.False;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private Task<byte> ReadByteAsync(CancellationToken cancellationToken)
		{
			MovePosition(1);
			return _asyncReader.ReadByteAsync(cancellationToken);
		}

		private Task ReadTypeAsync(Newtonsoft.Json.Bson.BsonType type, CancellationToken cancellationToken)
		{
			switch (type)
			{
			case Newtonsoft.Json.Bson.BsonType.Number:
			case Newtonsoft.Json.Bson.BsonType.String:
			case Newtonsoft.Json.Bson.BsonType.Object:
			case Newtonsoft.Json.Bson.BsonType.Array:
			case Newtonsoft.Json.Bson.BsonType.Binary:
			case Newtonsoft.Json.Bson.BsonType.Oid:
			case Newtonsoft.Json.Bson.BsonType.Boolean:
			case Newtonsoft.Json.Bson.BsonType.Date:
			case Newtonsoft.Json.Bson.BsonType.Regex:
			case Newtonsoft.Json.Bson.BsonType.Code:
			case Newtonsoft.Json.Bson.BsonType.Symbol:
			case Newtonsoft.Json.Bson.BsonType.Integer:
			case Newtonsoft.Json.Bson.BsonType.TimeStamp:
			case Newtonsoft.Json.Bson.BsonType.Long:
				return ReadTypeTrulyAsync(type, cancellationToken);
			case Newtonsoft.Json.Bson.BsonType.Undefined:
			case Newtonsoft.Json.Bson.BsonType.Null:
			case Newtonsoft.Json.Bson.BsonType.Reference:
			case Newtonsoft.Json.Bson.BsonType.CodeWScope:
				ReadType(type);
				return AsyncUtils.CompletedTask;
			default:
				throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type);
			}
		}

		private async Task ReadTypeTrulyAsync(Newtonsoft.Json.Bson.BsonType type, CancellationToken cancellationToken)
		{
			switch (type)
			{
			case Newtonsoft.Json.Bson.BsonType.Number:
				if (base.FloatParseHandling == FloatParseHandling.Decimal)
				{
					SetToken(JsonToken.Float, Convert.ToDecimal(await ReadDoubleAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), CultureInfo.InvariantCulture));
				}
				else
				{
					SetToken(JsonToken.Float, await ReadDoubleAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				}
				break;
			case Newtonsoft.Json.Bson.BsonType.String:
			case Newtonsoft.Json.Bson.BsonType.Symbol:
				SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				break;
			case Newtonsoft.Json.Bson.BsonType.Object:
			{
				SetToken(JsonToken.StartObject);
				ContainerContext newContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
				PushContext(newContext);
				newContext.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Array:
			{
				SetToken(JsonToken.StartArray);
				ContainerContext newContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Array);
				PushContext(newContext);
				newContext.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Binary:
			{
				Tuple<byte[], Newtonsoft.Json.Bson.BsonBinaryType> tuple = await ReadBinaryAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				SetToken(JsonToken.Bytes, (tuple.Item2 != Newtonsoft.Json.Bson.BsonBinaryType.Uuid) ? tuple.Item1 : ((object)new Guid(tuple.Item1)));
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Oid:
				SetToken(JsonToken.Bytes, await ReadBytesAsync(12, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				break;
			case Newtonsoft.Json.Bson.BsonType.Boolean:
				SetToken(JsonToken.Boolean, Convert.ToBoolean(await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
				break;
			case Newtonsoft.Json.Bson.BsonType.Date:
			{
				DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(await ReadInt64Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				switch (DateTimeKindHandling)
				{
				case DateTimeKind.Unspecified:
					dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
					break;
				case DateTimeKind.Local:
					dateTime = dateTime.ToLocalTime();
					break;
				}
				SetToken(JsonToken.Date, dateTime);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Regex:
				SetToken(JsonToken.String, "/" + await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false) + "/" + await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				break;
			case Newtonsoft.Json.Bson.BsonType.Code:
				SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				break;
			case Newtonsoft.Json.Bson.BsonType.Integer:
				SetToken(JsonToken.Integer, (long)(await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
				break;
			case Newtonsoft.Json.Bson.BsonType.TimeStamp:
			case Newtonsoft.Json.Bson.BsonType.Long:
				SetToken(JsonToken.Integer, await ReadInt64Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
				break;
			}
		}

		private async Task<Tuple<byte[], Newtonsoft.Json.Bson.BsonBinaryType>> ReadBinaryAsync(CancellationToken cancellationToken)
		{
			int dataLength = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			Newtonsoft.Json.Bson.BsonBinaryType binaryType = (Newtonsoft.Json.Bson.BsonBinaryType)(await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			if (binaryType == Newtonsoft.Json.Bson.BsonBinaryType.BinaryOld && !_jsonNet35BinaryCompatibility)
			{
				dataLength = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return Tuple.Create(await ReadBytesAsync(dataLength, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), binaryType);
		}

		private async Task<string> ReadStringAsync(CancellationToken cancellationToken)
		{
			EnsureBuffers();
			StringBuilder builder = null;
			int totalBytesRead = 0;
			int offset = 0;
			byte b = default(byte);
			while (true)
			{
				int count = offset;
				while (true)
				{
					bool flag = count < 128;
					if (flag)
					{
						byte num = await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						b = num;
						flag = num > 0;
					}
					if (!flag)
					{
						break;
					}
					_byteBuffer[count++] = b;
				}
				int num2 = count - offset;
				totalBytesRead += num2;
				if (count < 128 && builder == null)
				{
					int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num2, _charBuffer, 0);
					MovePosition(totalBytesRead + 1);
					return new string(_charBuffer, 0, chars);
				}
				int lastFullCharStop = GetLastFullCharStop(count - 1);
				int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
				if (builder == null)
				{
					builder = new StringBuilder(256);
				}
				builder.Append(_charBuffer, 0, chars2);
				if (lastFullCharStop < num2 - 1)
				{
					offset = num2 - lastFullCharStop - 1;
					Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, offset);
					continue;
				}
				if (count < 128)
				{
					break;
				}
				offset = 0;
			}
			MovePosition(totalBytesRead + 1);
			return builder.ToString();
		}

		private async Task<string> ReadLengthStringAsync(CancellationToken cancellationToken)
		{
			int num = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			MovePosition(num);
			string s = await GetStringAsync(num - 1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return s;
		}

		private Task<string> GetStringAsync(int length, CancellationToken cancellationToken)
		{
			if (length != 0)
			{
				return GetNonEmptyStringAsync(length, cancellationToken);
			}
			return AsyncUtils.EmptyString;
		}

		private async Task<string> GetNonEmptyStringAsync(int length, CancellationToken cancellationToken)
		{
			EnsureBuffers();
			StringBuilder builder = null;
			int totalBytesRead = 0;
			int offset = 0;
			do
			{
				int count = ((length - totalBytesRead > 128 - offset) ? (128 - offset) : (length - totalBytesRead));
				int num = await _asyncReader.ReadAsync(_byteBuffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (num == 0)
				{
					throw new EndOfStreamException("Unable to read beyond the end of the stream.");
				}
				totalBytesRead += num;
				num += offset;
				if (num == length)
				{
					int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num, _charBuffer, 0);
					return new string(_charBuffer, 0, chars);
				}
				int lastFullCharStop = GetLastFullCharStop(num - 1);
				if (builder == null)
				{
					builder = new StringBuilder(length);
				}
				int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
				builder.Append(_charBuffer, 0, chars2);
				if (lastFullCharStop < num - 1)
				{
					offset = num - lastFullCharStop - 1;
					Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, offset);
				}
				else
				{
					offset = 0;
				}
			}
			while (totalBytesRead < length);
			return builder.ToString();
		}

		private Task<double> ReadDoubleAsync(CancellationToken cancellationToken)
		{
			MovePosition(8);
			return _asyncReader.ReadDoubleAsync(cancellationToken);
		}

		private Task<int> ReadInt32Async(CancellationToken cancellationToken)
		{
			MovePosition(4);
			return _asyncReader.ReadInt32Async(cancellationToken);
		}

		private Task<long> ReadInt64Async(CancellationToken cancellationToken)
		{
			MovePosition(8);
			return _asyncReader.ReadInt64Async(cancellationToken);
		}

		private async Task<Newtonsoft.Json.Bson.BsonType> ReadTypeAsync(CancellationToken cancellationToken)
		{
			MovePosition(1);
			return (Newtonsoft.Json.Bson.BsonType)(await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		}

		private Task<byte[]> ReadBytesAsync(int count, CancellationToken cancellationToken)
		{
			MovePosition(count);
			return _asyncReader.ReadBytesAsync(count, cancellationToken);
		}

		private async Task<JsonToken> GetContentTokenAsync(CancellationToken cancellationToken)
		{
			while (await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				JsonToken tokenType = TokenType;
				if (tokenType != JsonToken.Comment)
				{
					return tokenType;
				}
			}
			SetToken(JsonToken.None);
			return JsonToken.None;
		}

		public override Task<bool?> ReadAsBooleanAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsBooleanAsync(cancellationToken);
			}
			return base.ReadAsBooleanAsync(cancellationToken);
		}

		private async Task<bool?> DoReadAsBooleanAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Integer:
			case JsonToken.Float:
			{
				bool flag = ((!(Value is BigInteger)) ? Convert.ToBoolean(Value, CultureInfo.InvariantCulture) : ((BigInteger)Value != 0L));
				SetToken(JsonToken.Boolean, flag, updateIndex: false);
				return flag;
			}
			case JsonToken.String:
				return ReadBooleanString((string)Value);
			case JsonToken.Boolean:
				return (bool)Value;
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading boolean. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		public override Task<byte[]> ReadAsBytesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsBytesAsync(cancellationToken);
			}
			return base.ReadAsBytesAsync(cancellationToken);
		}

		private async Task<byte[]> DoReadAsBytesAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.StartObject:
			{
				await ReadIntoWrappedTypeObjectAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				byte[] data = await ReadAsBytesAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (TokenType != JsonToken.EndObject)
				{
					throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
				}
				SetToken(JsonToken.Bytes, data, updateIndex: false);
				return data;
			}
			case JsonToken.String:
			{
				string text = (string)Value;
				Guid g;
				byte[] array2 = ((text.Length == 0) ? CollectionUtils.ArrayEmpty<byte>() : ((!ConvertUtils.TryConvertGuid(text, out g)) ? Convert.FromBase64String(text) : g.ToByteArray()));
				SetToken(JsonToken.Bytes, array2, updateIndex: false);
				return array2;
			}
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Bytes:
				if (ValueType == typeof(Guid))
				{
					byte[] array = ((Guid)Value).ToByteArray();
					SetToken(JsonToken.Bytes, array, updateIndex: false);
					return array;
				}
				return (byte[])Value;
			case JsonToken.StartArray:
				return await ReadArrayIntoByteArrayAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		private async Task ReadIntoWrappedTypeObjectAsync(CancellationToken cancellationToken)
		{
			await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (Value?.ToString() == "$type")
			{
				await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (Value != null && Value.ToString().StartsWith("System.Byte[]", StringComparison.Ordinal))
				{
					await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (Value?.ToString() == "$value")
					{
						return;
					}
				}
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, JsonToken.StartObject));
		}

		public override Task<DateTime?> ReadAsDateTimeAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsDateTimeAsync(cancellationToken);
			}
			return base.ReadAsDateTimeAsync(cancellationToken);
		}

		private async Task<DateTime?> DoReadAsDateTimeAsync(CancellationToken cancellationToken)
		{
			switch (await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Date:
				if (Value is DateTimeOffset)
				{
					SetToken(JsonToken.Date, ((DateTimeOffset)Value).DateTime, updateIndex: false);
				}
				return (DateTime)Value;
			case JsonToken.String:
				return ReadDateTimeString((string)Value);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
			}
		}

		public override Task<DateTimeOffset?> ReadAsDateTimeOffsetAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsDateTimeOffsetAsync(cancellationToken);
			}
			return base.ReadAsDateTimeOffsetAsync(cancellationToken);
		}

		private async Task<DateTimeOffset?> DoReadAsDateTimeOffsetAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Date:
				if (Value is DateTime)
				{
					SetToken(JsonToken.Date, new DateTimeOffset((DateTime)Value), updateIndex: false);
				}
				return (DateTimeOffset)Value;
			case JsonToken.String:
				return ReadDateTimeOffsetString((string)Value);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		internal DateTimeOffset? ReadDateTimeOffsetString(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (DateTimeUtils.TryParseDateTimeOffset(s, base.DateFormatString, base.Culture, out var dt))
			{
				SetToken(JsonToken.Date, dt, updateIndex: false);
				return dt;
			}
			if (DateTimeOffset.TryParse(s, base.Culture, DateTimeStyles.RoundtripKind, out dt))
			{
				SetToken(JsonToken.Date, dt, updateIndex: false);
				return dt;
			}
			SetToken(JsonToken.String, s, updateIndex: false);
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to DateTimeOffset: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		public override Task<decimal?> ReadAsDecimalAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsDecimalAsync(cancellationToken);
			}
			return base.ReadAsDecimalAsync(cancellationToken);
		}

		private async Task<decimal?> DoReadAsDecimalAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Integer:
			case JsonToken.Float:
				if (!(Value is decimal))
				{
					SetToken(JsonToken.Float, Convert.ToDecimal(Value, CultureInfo.InvariantCulture), updateIndex: false);
				}
				return (decimal)Value;
			case JsonToken.String:
				return ReadDecimalString((string)Value);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading decimal. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		public override Task<double?> ReadAsDoubleAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsDoubleAsync(cancellationToken);
			}
			return base.ReadAsDoubleAsync(cancellationToken);
		}

		private async Task<double?> DoReadAsDoubleAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Integer:
			case JsonToken.Float:
				if (!(Value is double))
				{
					double num = ((!(Value is BigInteger)) ? Convert.ToDouble(Value, CultureInfo.InvariantCulture) : ((double)(BigInteger)Value));
					SetToken(JsonToken.Float, num, updateIndex: false);
				}
				return (double)Value;
			case JsonToken.String:
				return ReadDoubleString((string)Value);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading double. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		public override Task<int?> ReadAsInt32Async(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsInt32Async(cancellationToken);
			}
			return base.ReadAsInt32Async(cancellationToken);
		}

		private async Task<int?> DoReadAsInt32Async(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.Integer:
			case JsonToken.Float:
				if (!(Value is int))
				{
					SetToken(JsonToken.Integer, Convert.ToInt32(Value, CultureInfo.InvariantCulture), updateIndex: false);
				}
				return (int)Value;
			case JsonToken.String:
			{
				string s = (string)Value;
				return ReadInt32String(s);
			}
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading integer. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		public override Task<string> ReadAsStringAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_asyncReader != null)
			{
				return DoReadAsStringAsync(cancellationToken);
			}
			return base.ReadAsStringAsync(cancellationToken);
		}

		private async Task<string> DoReadAsStringAsync(CancellationToken cancellationToken)
		{
			JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			switch (jsonToken)
			{
			case JsonToken.None:
			case JsonToken.Null:
			case JsonToken.EndArray:
				return null;
			case JsonToken.String:
				return (string)Value;
			default:
				if (JsonTokenUtils.IsPrimitiveToken(jsonToken) && Value != null)
				{
					string text;
					if (Value is IFormattable formattable)
					{
						text = formattable.ToString(null, base.Culture);
					}
					else
					{
						Uri uri = Value as Uri;
						text = ((uri != null) ? uri.OriginalString : Value.ToString());
					}
					SetToken(JsonToken.String, text, updateIndex: false);
					return text;
				}
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading string. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
			}
		}

		internal async Task ReaderReadAndAssertAsync(CancellationToken cancellationToken)
		{
			if (!(await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
			{
				throw CreateUnexpectedEndException();
			}
		}

		internal JsonReaderException CreateUnexpectedEndException()
		{
			return ExceptionUtils.CreateJsonReaderException(this, "Unexpected end when reading JSON.");
		}

		internal async Task<byte[]> ReadArrayIntoByteArrayAsync(CancellationToken cancellationToken)
		{
			List<byte> buffer = new List<byte>();
			do
			{
				if (!(await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
				{
					SetToken(JsonToken.None);
				}
			}
			while (!ReadArrayElementIntoByteArrayReportDone(buffer));
			byte[] array = buffer.ToArray();
			SetToken(JsonToken.Bytes, array, updateIndex: false);
			return array;
		}

		private bool ReadArrayElementIntoByteArrayReportDone(List<byte> buffer)
		{
			switch (TokenType)
			{
			case JsonToken.None:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end when reading bytes.");
			case JsonToken.Integer:
				buffer.Add(Convert.ToByte(Value, CultureInfo.InvariantCulture));
				return false;
			case JsonToken.EndArray:
				return true;
			case JsonToken.Comment:
				return false;
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected token when reading bytes: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
			}
		}

		internal int? ReadInt32String(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (int.TryParse(s, NumberStyles.Integer, base.Culture, out var result))
			{
				SetToken(JsonToken.Integer, result, updateIndex: false);
				return result;
			}
			SetToken(JsonToken.String, s, updateIndex: false);
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to integer: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		internal double? ReadDoubleString(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, base.Culture, out var result))
			{
				SetToken(JsonToken.Float, result, updateIndex: false);
				return result;
			}
			SetToken(JsonToken.String, s, updateIndex: false);
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to double: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		internal decimal? ReadDecimalString(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (decimal.TryParse(s, NumberStyles.Number, base.Culture, out var result))
			{
				SetToken(JsonToken.Float, result, updateIndex: false);
				return result;
			}
			SetToken(JsonToken.String, s, updateIndex: false);
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to decimal: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		internal DateTime? ReadDateTimeString(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (DateTimeUtils.TryParseDateTime(s, base.DateTimeZoneHandling, base.DateFormatString, base.Culture, out var dt))
			{
				dt = DateTimeUtils.EnsureDateTime(dt, base.DateTimeZoneHandling);
				SetToken(JsonToken.Date, dt, updateIndex: false);
				return dt;
			}
			if (DateTime.TryParse(s, base.Culture, DateTimeStyles.RoundtripKind, out dt))
			{
				dt = DateTimeUtils.EnsureDateTime(dt, base.DateTimeZoneHandling);
				SetToken(JsonToken.Date, dt, updateIndex: false);
				return dt;
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to DateTime: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		internal bool? ReadBooleanString(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				SetToken(JsonToken.Null, null, updateIndex: false);
				return null;
			}
			if (bool.TryParse(s, out var result))
			{
				SetToken(JsonToken.Boolean, result, updateIndex: false);
				return result;
			}
			SetToken(JsonToken.String, s, updateIndex: false);
			throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to boolean: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
		}

		public BsonDataReader(Stream stream)
			: this(stream, readRootValueAsArray: false, DateTimeKind.Local)
		{
		}

		public BsonDataReader(BinaryReader reader)
			: this(reader, readRootValueAsArray: false, DateTimeKind.Local)
		{
		}

		public BsonDataReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(stream, "stream");
			_stack = new List<ContainerContext>();
			_readRootValueAsArray = readRootValueAsArray;
			_dateTimeKindHandling = dateTimeKindHandling;
			if (GetType() == typeof(BsonDataReader))
			{
				_reader = (_asyncReader = new AsyncBinaryReader(stream));
			}
			else
			{
				_reader = new BinaryReader(stream);
			}
		}

		public BsonDataReader(BinaryReader reader, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			_stack = new List<ContainerContext>();
			_readRootValueAsArray = readRootValueAsArray;
			_dateTimeKindHandling = dateTimeKindHandling;
			if (GetType() == typeof(BsonDataReader) && reader.GetType() == typeof(BinaryWriter))
			{
				_reader = (_asyncReader = new AsyncBinaryReaderOwningReader(reader));
			}
			else
			{
				_reader = reader;
			}
		}

		private string ReadElement()
		{
			_currentElementType = ReadType();
			return ReadString();
		}

		public override bool Read()
		{
			try
			{
				bool flag;
				switch (_bsonReaderState)
				{
				case BsonReaderState.Normal:
					flag = ReadNormal();
					break;
				case BsonReaderState.ReferenceStart:
				case BsonReaderState.ReferenceRef:
				case BsonReaderState.ReferenceId:
					flag = ReadReference();
					break;
				case BsonReaderState.CodeWScopeStart:
				case BsonReaderState.CodeWScopeCode:
				case BsonReaderState.CodeWScopeScope:
				case BsonReaderState.CodeWScopeScopeObject:
				case BsonReaderState.CodeWScopeScopeEnd:
					flag = ReadCodeWScope();
					break;
				default:
					throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state: {0}".FormatWith(CultureInfo.InvariantCulture, _bsonReaderState));
				}
				if (!flag)
				{
					SetToken(JsonToken.None);
					return false;
				}
				return true;
			}
			catch (EndOfStreamException)
			{
				SetToken(JsonToken.None);
				return false;
			}
		}

		public override void Close()
		{
			base.Close();
			if (base.CloseInput)
			{
				_reader?.Close();
			}
		}

		private bool ReadCodeWScope()
		{
			switch (_bsonReaderState)
			{
			case BsonReaderState.CodeWScopeStart:
				SetToken(JsonToken.PropertyName, "$code");
				_bsonReaderState = BsonReaderState.CodeWScopeCode;
				return true;
			case BsonReaderState.CodeWScopeCode:
				ReadInt32();
				SetToken(JsonToken.String, ReadLengthString());
				_bsonReaderState = BsonReaderState.CodeWScopeScope;
				return true;
			case BsonReaderState.CodeWScopeScope:
			{
				if (base.CurrentState == State.PostValue)
				{
					SetToken(JsonToken.PropertyName, "$scope");
					return true;
				}
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.CodeWScopeScopeObject;
				ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				return true;
			}
			case BsonReaderState.CodeWScopeScopeObject:
			{
				bool num = ReadNormal();
				if (num && TokenType == JsonToken.EndObject)
				{
					_bsonReaderState = BsonReaderState.CodeWScopeScopeEnd;
				}
				return num;
			}
			case BsonReaderState.CodeWScopeScopeEnd:
				SetToken(JsonToken.EndObject);
				_bsonReaderState = BsonReaderState.Normal;
				return true;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private bool ReadReference()
		{
			switch (base.CurrentState)
			{
			case State.ObjectStart:
				SetToken(JsonToken.PropertyName, "$ref");
				_bsonReaderState = BsonReaderState.ReferenceRef;
				return true;
			case State.Property:
				if (_bsonReaderState == BsonReaderState.ReferenceRef)
				{
					SetToken(JsonToken.String, ReadLengthString());
					return true;
				}
				if (_bsonReaderState == BsonReaderState.ReferenceId)
				{
					SetToken(JsonToken.Bytes, ReadBytes(12));
					return true;
				}
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
			case State.PostValue:
				if (_bsonReaderState == BsonReaderState.ReferenceRef)
				{
					SetToken(JsonToken.PropertyName, "$id");
					_bsonReaderState = BsonReaderState.ReferenceId;
					return true;
				}
				if (_bsonReaderState == BsonReaderState.ReferenceId)
				{
					SetToken(JsonToken.EndObject);
					_bsonReaderState = BsonReaderState.Normal;
					return true;
				}
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + base.CurrentState);
			}
		}

		private bool ReadNormal()
		{
			switch (base.CurrentState)
			{
			case State.Start:
			{
				JsonToken token2 = ((!_readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray);
				int type = ((!_readRootValueAsArray) ? 3 : 4);
				SetToken(token2);
				ContainerContext containerContext = new ContainerContext((Newtonsoft.Json.Bson.BsonType)type);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				return true;
			}
			case State.Complete:
			case State.Closed:
				return false;
			case State.Property:
				ReadType(_currentElementType);
				return true;
			case State.ObjectStart:
			case State.ArrayStart:
			case State.PostValue:
			{
				ContainerContext currentContext = _currentContext;
				if (currentContext == null)
				{
					if (!base.SupportMultipleContent)
					{
						return false;
					}
					goto case State.Start;
				}
				int num = currentContext.Length - 1;
				if (currentContext.Position < num)
				{
					if (currentContext.Type == Newtonsoft.Json.Bson.BsonType.Array)
					{
						ReadElement();
						ReadType(_currentElementType);
						return true;
					}
					SetToken(JsonToken.PropertyName, ReadElement());
					return true;
				}
				if (currentContext.Position == num)
				{
					if (ReadByte() != 0)
					{
						throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end of object byte value.");
					}
					PopContext();
					if (_currentContext != null)
					{
						MovePosition(currentContext.Length);
					}
					JsonToken token = ((currentContext.Type == Newtonsoft.Json.Bson.BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray);
					SetToken(token);
					return true;
				}
				throw ExceptionUtils.CreateJsonReaderException(this, "Read past end of current container context.");
			}
			default:
				throw new ArgumentOutOfRangeException();
			case State.ConstructorStart:
			case State.Constructor:
			case State.Error:
			case State.Finished:
				return false;
			}
		}

		private void PopContext()
		{
			_stack.RemoveAt(_stack.Count - 1);
			if (_stack.Count == 0)
			{
				_currentContext = null;
			}
			else
			{
				_currentContext = _stack[_stack.Count - 1];
			}
		}

		private void PushContext(ContainerContext newContext)
		{
			_stack.Add(newContext);
			_currentContext = newContext;
		}

		private byte ReadByte()
		{
			MovePosition(1);
			return _reader.ReadByte();
		}

		private void ReadType(Newtonsoft.Json.Bson.BsonType type)
		{
			switch (type)
			{
			case Newtonsoft.Json.Bson.BsonType.Number:
			{
				double num = ReadDouble();
				if (base.FloatParseHandling == FloatParseHandling.Decimal)
				{
					SetToken(JsonToken.Float, Convert.ToDecimal(num, CultureInfo.InvariantCulture));
				}
				else
				{
					SetToken(JsonToken.Float, num);
				}
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.String:
			case Newtonsoft.Json.Bson.BsonType.Symbol:
				SetToken(JsonToken.String, ReadLengthString());
				break;
			case Newtonsoft.Json.Bson.BsonType.Object:
			{
				SetToken(JsonToken.StartObject);
				ContainerContext containerContext2 = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
				PushContext(containerContext2);
				containerContext2.Length = ReadInt32();
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Array:
			{
				SetToken(JsonToken.StartArray);
				ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Array);
				PushContext(containerContext);
				containerContext.Length = ReadInt32();
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Binary:
			{
				Newtonsoft.Json.Bson.BsonBinaryType binaryType;
				byte[] array = ReadBinary(out binaryType);
				object value3 = ((binaryType != Newtonsoft.Json.Bson.BsonBinaryType.Uuid) ? array : ((object)new Guid(array)));
				SetToken(JsonToken.Bytes, value3);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Undefined:
				SetToken(JsonToken.Undefined);
				break;
			case Newtonsoft.Json.Bson.BsonType.Oid:
			{
				byte[] value2 = ReadBytes(12);
				SetToken(JsonToken.Bytes, value2);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Boolean:
			{
				bool flag = Convert.ToBoolean(ReadByte());
				SetToken(JsonToken.Boolean, flag);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Date:
			{
				DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(ReadInt64());
				SetToken(JsonToken.Date, DateTimeKindHandling switch
				{
					DateTimeKind.Unspecified => DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified), 
					DateTimeKind.Local => dateTime.ToLocalTime(), 
					_ => dateTime, 
				});
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Null:
				SetToken(JsonToken.Null);
				break;
			case Newtonsoft.Json.Bson.BsonType.Regex:
			{
				string text = ReadString();
				string text2 = ReadString();
				string value = "/" + text + "/" + text2;
				SetToken(JsonToken.String, value);
				break;
			}
			case Newtonsoft.Json.Bson.BsonType.Reference:
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.ReferenceStart;
				break;
			case Newtonsoft.Json.Bson.BsonType.Code:
				SetToken(JsonToken.String, ReadLengthString());
				break;
			case Newtonsoft.Json.Bson.BsonType.CodeWScope:
				SetToken(JsonToken.StartObject);
				_bsonReaderState = BsonReaderState.CodeWScopeStart;
				break;
			case Newtonsoft.Json.Bson.BsonType.Integer:
				SetToken(JsonToken.Integer, (long)ReadInt32());
				break;
			case Newtonsoft.Json.Bson.BsonType.TimeStamp:
			case Newtonsoft.Json.Bson.BsonType.Long:
				SetToken(JsonToken.Integer, ReadInt64());
				break;
			default:
				throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type);
			}
		}

		private byte[] ReadBinary(out Newtonsoft.Json.Bson.BsonBinaryType binaryType)
		{
			int count = ReadInt32();
			binaryType = (Newtonsoft.Json.Bson.BsonBinaryType)ReadByte();
			if (binaryType == Newtonsoft.Json.Bson.BsonBinaryType.BinaryOld && !_jsonNet35BinaryCompatibility)
			{
				count = ReadInt32();
			}
			return ReadBytes(count);
		}

		private string ReadString()
		{
			EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				byte b;
				while (num3 < 128 && (b = _reader.ReadByte()) > 0)
				{
					_byteBuffer[num3++] = b;
				}
				int num4 = num3 - num2;
				num += num4;
				if (num3 < 128 && stringBuilder == null)
				{
					int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num4, _charBuffer, 0);
					MovePosition(num + 1);
					return new string(_charBuffer, 0, chars);
				}
				int lastFullCharStop = GetLastFullCharStop(num3 - 1);
				int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(256);
				}
				stringBuilder.Append(_charBuffer, 0, chars2);
				if (lastFullCharStop < num4 - 1)
				{
					num2 = num4 - lastFullCharStop - 1;
					Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num2);
					continue;
				}
				if (num3 < 128)
				{
					break;
				}
				num2 = 0;
			}
			MovePosition(num + 1);
			return stringBuilder.ToString();
		}

		private string ReadLengthString()
		{
			int num = ReadInt32();
			MovePosition(num);
			string result = GetString(num - 1);
			_reader.ReadByte();
			return result;
		}

		private string GetString(int length)
		{
			if (length == 0)
			{
				return string.Empty;
			}
			EnsureBuffers();
			StringBuilder stringBuilder = null;
			int num = 0;
			int num2 = 0;
			do
			{
				int count = ((length - num > 128 - num2) ? (128 - num2) : (length - num));
				int num3 = _reader.Read(_byteBuffer, num2, count);
				if (num3 == 0)
				{
					throw new EndOfStreamException("Unable to read beyond the end of the stream.");
				}
				num += num3;
				num3 += num2;
				if (num3 == length)
				{
					int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num3, _charBuffer, 0);
					return new string(_charBuffer, 0, chars);
				}
				int lastFullCharStop = GetLastFullCharStop(num3 - 1);
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
				stringBuilder.Append(_charBuffer, 0, chars2);
				if (lastFullCharStop < num3 - 1)
				{
					num2 = num3 - lastFullCharStop - 1;
					Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num2);
				}
				else
				{
					num2 = 0;
				}
			}
			while (num < length);
			return stringBuilder.ToString();
		}

		private int GetLastFullCharStop(int start)
		{
			int num = start;
			int num2 = 0;
			for (; num >= 0; num--)
			{
				num2 = BytesInSequence(_byteBuffer[num]);
				switch (num2)
				{
				case 0:
					continue;
				default:
					num--;
					break;
				case 1:
					break;
				}
				break;
			}
			if (num2 == start - num)
			{
				return start;
			}
			return num;
		}

		private int BytesInSequence(byte b)
		{
			if (b <= SeqRange1[1])
			{
				return 1;
			}
			if (b >= SeqRange2[0] && b <= SeqRange2[1])
			{
				return 2;
			}
			if (b >= SeqRange3[0] && b <= SeqRange3[1])
			{
				return 3;
			}
			if (b >= SeqRange4[0] && b <= SeqRange4[1])
			{
				return 4;
			}
			return 0;
		}

		private void EnsureBuffers()
		{
			if (_byteBuffer == null)
			{
				_byteBuffer = new byte[128];
			}
			if (_charBuffer == null)
			{
				int maxCharCount = Encoding.UTF8.GetMaxCharCount(128);
				_charBuffer = new char[maxCharCount];
			}
		}

		private double ReadDouble()
		{
			MovePosition(8);
			return _reader.ReadDouble();
		}

		private int ReadInt32()
		{
			MovePosition(4);
			return _reader.ReadInt32();
		}

		private long ReadInt64()
		{
			MovePosition(8);
			return _reader.ReadInt64();
		}

		private Newtonsoft.Json.Bson.BsonType ReadType()
		{
			MovePosition(1);
			return (Newtonsoft.Json.Bson.BsonType)_reader.ReadSByte();
		}

		private void MovePosition(int count)
		{
			_currentContext.Position += count;
		}

		private byte[] ReadBytes(int count)
		{
			MovePosition(count);
			return _reader.ReadBytes(count);
		}
	}
	public class BsonDataWriter : JsonWriter
	{
		private readonly bool _safeAsync;

		private bool _finishingAsync;

		private readonly Newtonsoft.Json.Bson.BsonBinaryWriter _writer;

		private Newtonsoft.Json.Bson.BsonToken _root;

		private Newtonsoft.Json.Bson.BsonToken _parent;

		private string _propertyName;

		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return _writer.DateTimeKindHandling;
			}
			set
			{
				_writer.DateTimeKindHandling = value;
			}
		}

		public override Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!_safeAsync)
			{
				return base.FlushAsync(cancellationToken);
			}
			return _writer.FlushAsync(cancellationToken);
		}

		public override Task WriteEndAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!_safeAsync || base.Top != 1)
			{
				return base.WriteEndAsync(cancellationToken);
			}
			return CompleteAsync(cancellationToken);
		}

		private bool WillCloseAll(Newtonsoft.Json.Bson.BsonType type)
		{
			if (type != _root.Type)
			{
				return false;
			}
			for (Newtonsoft.Json.Bson.BsonToken parent = _parent; parent != _root; parent = parent.Parent)
			{
				if (parent.Type == type)
				{
					return false;
				}
			}
			return true;
		}

		public override Task WriteEndArrayAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!_safeAsync || !WillCloseAll(Newtonsoft.Json.Bson.BsonType.Array))
			{
				return base.WriteEndArrayAsync(cancellationToken);
			}
			return CompleteAsync(cancellationToken);
		}

		public override Task WriteEndObjectAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!_safeAsync || !WillCloseAll(Newtonsoft.Json.Bson.BsonType.Object))
			{
				return base.WriteEndObjectAsync(cancellationToken);
			}
			return CompleteAsync(cancellationToken);
		}

		public override Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_safeAsync)
			{
				if (base.AutoCompleteOnClose)
				{
					if (base.CloseOutput)
					{
						return CompleteAndCloseOutputAsync(cancellationToken);
					}
					return CompleteAsync(cancellationToken);
				}
				if (base.CloseOutput)
				{
					_writer?.Close();
				}
				return AsyncUtils.CompletedTask;
			}
			return base.CloseAsync(cancellationToken);
		}

		private Task CompleteAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return cancellationToken.FromCanceled();
			}
			int top = base.Top;
			if (top == 0)
			{
				return AsyncUtils.CompletedTask;
			}
			_finishingAsync = true;
			try
			{
				while (top-- != 0)
				{
					WriteEnd();
				}
			}
			finally
			{
				_finishingAsync = false;
			}
			return _writer.WriteTokenAsync(_root, cancellationToken);
		}

		private async Task CompleteAndCloseOutputAsync(CancellationToken cancellationToken)
		{
			await CompleteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_writer?.Close();
		}

		public BsonDataWriter(Stream stream)
		{
			ValidationUtils.ArgumentNotNull(stream, "stream");
			if (GetType() == typeof(BsonDataWriter))
			{
				_safeAsync = true;
				_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(new AsyncBinaryWriter(stream));
			}
			else
			{
				_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(new BinaryWriter(stream));
			}
		}

		public BsonDataWriter(BinaryWriter writer)
		{
			ValidationUtils.ArgumentNotNull(writer, "writer");
			if (GetType() == typeof(BsonDataWriter) && writer.GetType() == typeof(BinaryWriter))
			{
				_safeAsync = true;
				_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(new AsyncBinaryWriterOwningWriter(writer));
			}
			else
			{
				_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(writer);
			}
		}

		public override void Flush()
		{
			_writer.Flush();
		}

		protected override void WriteEnd(JsonToken token)
		{
			base.WriteEnd(token);
			RemoveParent();
			if (!_finishingAsync && base.Top == 0)
			{
				_writer.WriteToken(_root);
			}
		}

		public override void WriteComment(string text)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write JSON comment as BSON.", null);
		}

		public override void WriteStartConstructor(string name)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write JSON constructor as BSON.", null);
		}

		public override void WriteRaw(string json)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write raw JSON as BSON.", null);
		}

		public override void WriteRawValue(string json)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write raw JSON as BSON.", null);
		}

		public override void WriteStartArray()
		{
			base.WriteStartArray();
			AddParent(new Newtonsoft.Json.Bson.BsonArray());
		}

		public override void WriteStartObject()
		{
			base.WriteStartObject();
			AddParent(new Newtonsoft.Json.Bson.BsonObject());
		}

		public override void WritePropertyName(string name)
		{
			base.WritePropertyName(name);
			_propertyName = name;
		}

		public override void Close()
		{
			base.Close();
			if (base.CloseOutput)
			{
				_writer?.Close();
			}
		}

		private void AddParent(Newtonsoft.Json.Bson.BsonToken container)
		{
			AddToken(container);
			_parent = container;
		}

		private void RemoveParent()
		{
			_parent = _parent.Parent;
		}

		private void AddValue(object value, Newtonsoft.Json.Bson.BsonType type)
		{
			AddToken(new Newtonsoft.Json.Bson.BsonValue(value, type));
		}

		internal void AddToken(Newtonsoft.Json.Bson.BsonToken token)
		{
			if (_parent != null)
			{
				if (_parent is Newtonsoft.Json.Bson.BsonObject bsonObject)
				{
					bsonObject.Add(_propertyName, token);
					_propertyName = null;
				}
				else
				{
					((Newtonsoft.Json.Bson.BsonArray)_parent).Add(token);
				}
				return;
			}
			if (token.Type != Newtonsoft.Json.Bson.BsonType.Object && token.Type != Newtonsoft.Json.Bson.BsonType.Array)
			{
				throw ExceptionUtils.CreateJsonWriterException(this, "Error writing {0} value. BSON must start with an Object or Array.".FormatWith(CultureInfo.InvariantCulture, token.Type), null);
			}
			_parent = token;
			_root = token;
		}

		public override void WriteValue(object value)
		{
			if (value is BigInteger)
			{
				SetWriteState(JsonToken.Integer, null);
				AddToken(new Newtonsoft.Json.Bson.BsonBinary(((BigInteger)value).ToByteArray(), Newtonsoft.Json.Bson.BsonBinaryType.Binary));
			}
			else
			{
				base.WriteValue(value);
			}
		}

		public override void WriteNull()
		{
			base.WriteNull();
			AddToken(Newtonsoft.Json.Bson.BsonEmpty.Null);
		}

		public override void WriteUndefined()
		{
			base.WriteUndefined();
			AddToken(Newtonsoft.Json.Bson.BsonEmpty.Undefined);
		}

		public override void WriteValue(string value)
		{
			base.WriteValue(value);
			AddToken((value == null) ? Newtonsoft.Json.Bson.BsonEmpty.Null : new Newtonsoft.Json.Bson.BsonString(value, includeLength: true));
		}

		public override void WriteValue(int value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		[CLSCompliant(false)]
		public override void WriteValue(uint value)
		{
			if (value > 2147483647)
			{
				throw ExceptionUtils.CreateJsonWriterException(this, "Value is too large to fit in a signed 32 bit integer. BSON does not support unsigned values.", null);
			}
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		public override void WriteValue(long value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Long);
		}

		[CLSCompliant(false)]
		public override void WriteValue(ulong value)
		{
			if (value > 9223372036854775807L)
			{
				throw ExceptionUtils.CreateJsonWriterException(this, "Value is too large to fit in a signed 64 bit integer. BSON does not support unsigned values.", null);
			}
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Long);
		}

		public override void WriteValue(float value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
		}

		public override void WriteValue(double value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
		}

		public override void WriteValue(bool value)
		{
			base.WriteValue(value);
			AddToken(value ? Newtonsoft.Json.Bson.BsonBoolean.True : Newtonsoft.Json.Bson.BsonBoolean.False);
		}

		public override void WriteValue(short value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		[CLSCompliant(false)]
		public override void WriteValue(ushort value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		public override void WriteValue(char value)
		{
			base.WriteValue(value);
			string text = null;
			text = value.ToString(CultureInfo.InvariantCulture);
			AddToken(new Newtonsoft.Json.Bson.BsonString(text, includeLength: true));
		}

		public override void WriteValue(byte value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		[CLSCompliant(false)]
		public override void WriteValue(sbyte value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
		}

		public override void WriteValue(decimal value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
		}

		public override void WriteValue(DateTime value)
		{
			base.WriteValue(value);
			value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Date);
		}

		public override void WriteValue(DateTimeOffset value)
		{
			base.WriteValue(value);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Date);
		}

		public override void WriteValue(byte[] value)
		{
			if (value == null)
			{
				WriteNull();
				return;
			}
			base.WriteValue(value);
			AddToken(new Newtonsoft.Json.Bson.BsonBinary(value, Newtonsoft.Json.Bson.BsonBinaryType.Binary));
		}

		public override void WriteValue(Guid value)
		{
			base.WriteValue(value);
			AddToken(new Newtonsoft.Json.Bson.BsonBinary(value.ToByteArray(), Newtonsoft.Json.Bson.BsonBinaryType.Uuid));
		}

		public override void WriteValue(TimeSpan value)
		{
			base.WriteValue(value);
			AddToken(new Newtonsoft.Json.Bson.BsonString(value.ToString(), includeLength: true));
		}

		public override void WriteValue(Uri value)
		{
			if (value == null)
			{
				WriteNull();
				return;
			}
			base.WriteValue(value);
			AddToken(new Newtonsoft.Json.Bson.BsonString(value.ToString(), includeLength: true));
		}

		public void WriteObjectId(byte[] value)
		{
			ValidationUtils.ArgumentNotNull(value, "value");
			if (value.Length != 12)
			{
				throw ExceptionUtils.CreateJsonWriterException(this, "An object id must be 12 bytes", null);
			}
			SetWriteState(JsonToken.Undefined, null);
			AddValue(value, Newtonsoft.Json.Bson.BsonType.Oid);
		}

		public void WriteRegex(string pattern, string options)
		{
			ValidationUtils.ArgumentNotNull(pattern, "pattern");
			SetWriteState(JsonToken.Undefined, null);
			AddToken(new Newtonsoft.Json.Bson.BsonRegex(pattern, options));
		}
	}
	internal abstract class BsonToken
	{
		public abstract Newtonsoft.Json.Bson.BsonType Type { get; }

		public Newtonsoft.Json.Bson.BsonToken Parent { get; set; }

		public int CalculatedSize { get; set; }
	}
	internal class BsonObject : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonProperty>, IEnumerable
	{
		private readonly List<Newtonsoft.Json.Bson.BsonProperty> _children = new List<Newtonsoft.Json.Bson.BsonProperty>();

		public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Object;

		public void Add(string name, Newtonsoft.Json.Bson.BsonToken token)
		{
			_children.Add(new Newtonsoft.Json.Bson.BsonProperty
			{
				Name = new Newtonsoft.Json.Bson.BsonString(name, includeLength: false),
				Value = token
			});
			token.Parent = this;
		}

		public IEnumerator<Newtonsoft.Json.Bson.BsonProperty> GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	internal class BsonArray : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonToken>, IEnumerable
	{
		private readonly List<Newtonsoft.Json.Bson.BsonToken> _children = new List<Newtonsoft.Json.Bson.BsonToken>();

		public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Array;

		public void Add(Newtonsoft.Json.Bson.BsonToken token)
		{
			_children.Add(token);
			token.Parent = this;
		}

		public IEnumerator<Newtonsoft.Json.Bson.BsonToken> GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	internal class BsonEmpty : Newtonsoft.Json.Bson.BsonToken
	{
		public static readonly Newtonsoft.Json.Bson.BsonToken Null = new Newtonsoft.Json.Bson.BsonEmpty(Newtonsoft.Json.Bson.BsonType.Null);

		public static readonly Newtonsoft.Json.Bson.BsonToken Undefined = new Newtonsoft.Json.Bson.BsonEmpty(Newtonsoft.Json.Bson.BsonType.Undefined);

		public override Newtonsoft.Json.Bson.BsonType Type { get; }

		private BsonEmpty(Newtonsoft.Json.Bson.BsonType type)
		{
			Type = type;
		}
	}
	internal class BsonValue : Newtonsoft.Json.Bson.BsonToken
	{
		private readonly object _value;

		private readonly Newtonsoft.Json.Bson.BsonType _type;

		public object Value => _value;

		public override Newtonsoft.Json.Bson.BsonType Type => _type;

		public BsonValue(object value, Newtonsoft.Json.Bson.BsonType type)
		{
			_value = value;
			_type = type;
		}
	}
	internal class BsonBoolean : Newtonsoft.Json.Bson.BsonValue
	{
		public static readonly Newtonsoft.Json.Bson.BsonBoolean False = new Newtonsoft.Json.Bson.BsonBoolean(value: false);

		public static readonly Newtonsoft.Json.Bson.BsonBoolean True = new Newtonsoft.Json.Bson.BsonBoolean(value: true);

		private BsonBoolean(bool value)
			: base(value, Newtonsoft.Json.Bson.BsonType.Boolean)
		{
		}
	}
	internal class BsonString : Newtonsoft.Json.Bson.BsonValue
	{
		public int ByteCount { get; set; }

		public bool IncludeLength { get; }

		public BsonString(object value, bool includeLength)
			: base(value, Newtonsoft.Json.Bson.BsonType.String)
		{
			IncludeLength = includeLength;
		}
	}
	internal class BsonBinary : Newtonsoft.Json.Bson.BsonValue
	{
		public Newtonsoft.Json.Bson.BsonBinaryType BinaryType { get; set; }

		public BsonBinary(byte[] value, Newtonsoft.Json.Bson.BsonBinaryType binaryType)
			: base(value, Newtonsoft.Json.Bson.BsonType.Binary)
		{
			BinaryType = binaryType;
		}
	}
	internal class BsonRegex : Newtonsoft.Json.Bson.BsonToken
	{
		public Newtonsoft.Json.Bson.BsonString Pattern { get; set; }

		public Newtonsoft.Json.Bson.BsonString Options { get; set; }

		public override Newtonsoft.Json.Bson.BsonType Type => Newtonsoft.Json.Bson.BsonType.Regex;

		public BsonRegex(string pattern, string options)
		{
			Pattern = new Newtonsoft.Json.Bson.BsonString(pattern, includeLength: false);
			Options = new Newtonsoft.Json.Bson.BsonString(options, includeLength: false);
		}
	}
	internal class BsonProperty
	{
		public Newtonsoft.Json.Bson.BsonString Name { get; set; }

		public Newtonsoft.Json.Bson.BsonToken Value { get; set; }
	}
	internal enum BsonType : sbyte
	{
		Number = 1,
		String = 2,
		Object = 3,
		Array = 4,
		Binary = 5,
		Undefined = 6,
		Oid = 7,
		Boolean = 8,
		Date = 9,
		Null = 10,
		Regex = 11,
		Reference = 12,
		Code = 13,
		Symbol = 14,
		CodeWScope = 15,
		Integer = 16,
		TimeStamp = 17,
		Long = 18,
		MinKey = -1,
		MaxKey = 127
	}
}
namespace Newtonsoft.Json.Bson.Utilities
{
	internal static class AsyncUtils
	{
		public static readonly Task<bool> False = Task.FromResult(result: false);

		public static readonly Task<bool> True = Task.FromResult(result: true);

		private static Task<string> s_EmptyString;

		internal static readonly Task CompletedTask = Task.Delay(0);

		public static Task<string> EmptyString => s_EmptyString ?? (s_EmptyString = Task.FromResult(""));

		internal static Task<bool> ToAsync(this bool value)
		{
			if (!value)
			{
				return False;
			}
			return True;
		}

		public static Task CancelIfRequestedAsync(this CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return null;
			}
			return cancellationToken.FromCanceled();
		}

		public static Task<T> CancelIfRequestedAsync<T>(this CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return null;
			}
			return cancellationToken.FromCanceled<T>();
		}

		public static Task FromCanceled(this CancellationToken cancellationToken)
		{
			return new Task(delegate
			{
			}, cancellationToken);
		}

		public static Task<T> FromCanceled<T>(this CancellationToken cancellationToken)
		{
			return new Task<T>(() => default(T), cancellationToken);
		}

		public static Task WriteAsync(this TextWriter writer, char value, CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return writer.WriteAsync(value);
			}
			return cancellationToken.FromCanceled();
		}

		public static Task WriteAsync(this TextWriter writer, string value, CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return writer.WriteAsync(value);
			}
			return cancellationToken.FromCanceled();
		}

		public static Task WriteAsync(this TextWriter writer, char[] value, CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return writer.WriteAsync(value);
			}
			return cancellationToken.FromCanceled();
		}

		public static Task WriteAsync(this TextWriter writer, char[] value, int start, int count, CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return writer.WriteAsync(value, start, count);
			}
			return cancellationToken.FromCanceled();
		}

		public static Task<int> ReadAsync(this TextReader reader, char[] buffer, int index, int count, CancellationToken cancellationToken)
		{
			if (!cancellationToken.IsCancellationRequested)
			{
				return reader.ReadAsync(buffer, index, count);
			}
			return cancellationToken.FromCanceled<int>();
		}
	}
	internal class Base64Encoder
	{
		private const int Base64LineSize = 76;

		private const int LineSizeInBytes = 57;

		private readonly char[] _charsLine = new char[76];

		private readonly TextWriter _writer;

		private byte[] _leftOverBytes;

		private int _leftOverBytesCount;

		public Base64Encoder(TextWriter writer)
		{
			ValidationUtils.ArgumentNotNull(writer, "writer");
			_writer = writer;
		}

		private void ValidateEncode(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count > buffer.Length - index)
			{
				throw new ArgumentOutOfRangeException("count");
			}
		}

		public void Encode(byte[] buffer, int index, int count)
		{
			ValidateEncode(buffer, index, count);
			if (_leftOverBytesCount > 0)
			{
				if (FulfillFromLeftover(buffer, index, ref count))
				{
					return;
				}
				int count2 = Convert.ToBase64CharArray(_leftOverBytes, 0, 3, _charsLine, 0);
				WriteChars(_charsLine, 0, count2);
			}
			StoreLeftOverBytes(buffer, index, ref count);
			int num = index + count;
			int num2 = 57;
			while (index < num)
			{
				if (index + num2 > num)
				{
					num2 = num - index;
				}
				int count3 = Convert.ToBase64CharArray(buffer, index, num2, _charsLine, 0);
				WriteChars(_charsLine, 0, count3);
				index += num2;
			}
		}

		private void StoreLeftOverBytes(byte[] buffer, int index, ref int count)
		{
			int num = count % 3;
			if (num > 0)
			{
				count -= num;
				if (_leftOverBytes == null)
				{
					_leftOverBytes = new byte[3];
				}
				for (int i = 0; i < num; i++)
				{
					_leftOverBytes[i] = buffer[index + count + i];
				}
			}
			_leftOverBytesCount = num;
		}

		private bool FulfillFromLeftover(byte[] buffer, int index, ref int count)
		{
			int leftOverBytesCount = _leftOverBytesCount;
			while (leftOverBytesCount < 3 && count > 0)
			{
				_leftOverBytes[leftOverBytesCount++] = buffer[index++];
				count--;
			}
			if (count == 0 && leftOverBytesCount < 3)
			{
				_leftOverBytesCount = leftOverBytesCount;
				return true;
			}
			return false;
		}

		public void Flush()
		{
			if (_leftOverBytesCount > 0)
			{
				int count = Convert.ToBase64CharArray(_leftOverBytes, 0, _leftOverBytesCount, _charsLine, 0);
				WriteChars(_charsLine, 0, count);
				_leftOverBytesCount = 0;
			}
		}

		private void WriteChars(char[] chars, int index, int count)
		{
			_writer.Write(chars, index, count);
		}

		public async Task EncodeAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
		{
			ValidateEncode(buffer, index, count);
			if (_leftOverBytesCount > 0)
			{
				if (FulfillFromLeftover(buffer, index, ref count))
				{
					return;
				}
				int count2 = Convert.ToBase64CharArray(_leftOverBytes, 0, 3, _charsLine, 0);
				await WriteCharsAsync(_charsLine, 0, count2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			StoreLeftOverBytes(buffer, index, ref count);
			int num4 = index + count;
			int length = 57;
			while (index < num4)
			{
				if (index + length > num4)
				{
					length = num4 - index;
				}
				int count3 = Convert.ToBase64CharArray(buffer, index, length, _charsLine, 0);
				await WriteCharsAsync(_charsLine, 0, count3, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				index += length;
			}
		}

		private Task WriteCharsAsync(char[] chars, int index, int count, CancellationToken cancellationToken)
		{
			return _writer.WriteAsync(chars, index, count, cancellationToken);
		}

		public Task FlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return cancellationToken.FromCanceled();
			}
			if (_leftOverBytesCount > 0)
			{
				int count = Convert.ToBase64CharArray(_leftOverBytes, 0, _leftOverBytesCount, _charsLine, 0);
				_leftOverBytesCount = 0;
				return WriteCharsAsync(_charsLine, 0, count, cancellationToken);
			}
			return AsyncUtils.CompletedTask;
		}
	}
	internal static class CollectionUtils
	{
		public static T[] ArrayEmpty<T>()
		{
			return (Enumerable.Empty<T>() as T[]) ?? new T[0];
		}
	}
	internal static class ConvertUtils
	{
		public static bool TryConvertGuid(string s, out Guid g)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (new Regex("^[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}$").Match(s).Success)
			{
				g = new Guid(s);
				return true;
			}
			g = Guid.Empty;
			return false;
		}
	}
	internal enum ParserTimeZone
	{
		Unspecified,
		Utc,
		LocalWestOfUtc,
		LocalEastOfUtc
	}
	internal struct DateTimeParser
	{
		public int Year;

		public int Month;

		public int Day;

		public int Hour;

		public int Minute;

		public int Second;

		public int Fraction;

		public int ZoneHour;

		public int ZoneMinute;

		public ParserTimeZone Zone;

		private string _text;

		private int _end;

		private static readonly int[] Power10;

		private static readonly int Lzyyyy;

		private static readonly int Lzyyyy_;

		private static readonly int Lzyyyy_MM;

		private static readonly int Lzyyyy_MM_;

		private static readonly int Lzyyyy_MM_dd;

		private static readonly int Lzyyyy_MM_ddT;

		private static readonly int LzHH;

		private static readonly int LzHH_;

		private static readonly int LzHH_mm;

		private static readonly int LzHH_mm_;

		private static readonly int LzHH_mm_ss;

		private static readonly int Lz_;

		private static readonly int Lz_zz;

		private const short MaxFractionDigits = 7;

		static DateTimeParser()
		{
			Power10 = new int[7] { -1, 10, 100, 1000, 10000, 100000, 1000000 };
			Lzyyyy = "yyyy".Length;
			Lzyyyy_ = "yyyy-".Length;
			Lzyyyy_MM = "yyyy-MM".Length;
			Lzyyyy_MM_ = "yyyy-MM-".Length;
			Lzyyyy_MM_dd = "yyyy-MM-dd".Length;
			Lzyyyy_MM_ddT = "yyyy-MM-ddT".Length;
			LzHH = "HH".Length;
			LzHH_ = "HH:".Length;
			LzHH_mm = "HH:mm".Length;
			LzHH_mm_ = "HH:mm:".Length;
			LzHH_mm_ss = "HH:mm:ss".Length;
			Lz_ = "-".Length;
			Lz_zz = "-zz".Length;
		}

		public bool Parse(string text, int startIndex, int length)
		{
			_text = text;
			_end = startIndex + length;
			if (ParseDate(startIndex) && ParseChar(Lzyyyy_MM_dd + startIndex, 'T') && ParseTimeAndZoneAndWhitespace(Lzyyyy_MM_ddT + startIndex))
			{
				return true;
			}
			return false;
		}

		private bool ParseDate(int start)
		{
			if (Parse4Digit(start, out Year) && 1 <= Year && ParseChar(start + Lzyyyy, '-') && Parse2Digit(start + Lzyyyy_, out Month) && 1 <= Month && Month <= 12 && ParseChar(start + Lzyyyy_MM, '-') && Parse2Digit(start + Lzyyyy_MM_, out Day) && 1 <= Day)
			{
				return Day <= DateTime.DaysInMonth(Year, Month);
			}
			return false;
		}

		private bool ParseTimeAndZoneAndWhitespace(int start)
		{
			if (ParseTime(ref start))
			{
				return ParseZone(start);
			}
			return false;
		}

		private bool ParseTime(ref int start)
		{
			if (!Parse2Digit(start, out Hour) || Hour > 24 || !ParseChar(start + LzHH, ':') || !Parse2Digit(start + LzHH_, out Minute) || Minute >= 60 || !ParseChar(start + LzHH_mm, ':') || !Parse2Digit(start + LzHH_mm_, out Second) || Second >= 60 || (Hour == 24 && (Minute != 0 || Second != 0)))
			{
				return false;
			}
			start += LzHH_mm_ss;
			if (ParseChar(start, '.'))
			{
				Fraction = 0;
				int num = 0;
				while (++start < _end && num < 7)
				{
					int num2 = _text[start] - 48;
					if (num2 < 0 || num2 > 9)
					{
						break;
					}
					Fraction = Fraction * 10 + num2;
					num++;
				}
				if (num < 7)
				{
					if (num == 0)
					{
						return false;
					}
					Fraction *= Power10[7 - num];
				}
				if (Hour == 24 && Fraction != 0)
				{
					return false;
				}
			}
			return true;
		}

		private bool ParseZone(int start)
		{
			if (start < _end)
			{
				char c = _text[start];
				if (c == 'Z' || c == 'z')
				{
					Zone = ParserTimeZone.Utc;
					start++;
				}
				else
				{
					if (start + 2 < _end && Parse2Digit(start + Lz_, out ZoneHour) && ZoneHour <= 99)
					{
						switch (c)
						{
						case '-':
							Zone = ParserTimeZone.LocalWestOfUtc;
							start += Lz_zz;
							break;
						case '+':
							Zone = ParserTimeZone.LocalEastOfUtc;
							start += Lz_zz;
							break;
						}
					}
					if (start < _end)
					{
						if (ParseChar(start, ':'))
						{
							start++;
							if (start + 1 < _end && Parse2Digit(start, out ZoneMinute) && ZoneMinute <= 99)
							{
								start += 2;
							}
						}
						else if (start + 1 < _end && Parse2Digit(start, out ZoneMinute) && ZoneMinute <= 99)
						{
							start += 2;
						}
					}
				}
			}
			return start == _end;
		}

		private bool Parse4Digit(int start, out int num)
		{
			if (start + 3 < _end)
			{
				int num2 = _text[start] - 48;
				int num3 = _text[start + 1] - 48;
				int num4 = _text[start + 2] - 48;
				int num5 = _text[start + 3] - 48;
				if (0 <= num2 && num2 < 10 && 0 <= num3 && num3 < 10 && 0 <= num4 && num4 < 10 && 0 <= num5 && num5 < 10)
				{
					num = ((num2 * 10 + num3) * 10 + num4) * 10 + num5;
					return true;
				}
			}
			num = 0;
			return false;
		}

		private bool Parse2Digit(int start, out int num)
		{
			if (start + 1 < _end)
			{
				int num2 = _text[start] - 48;
				int num3 = _text[start + 1] - 48;
				if (0 <= num2 && num2 < 10 && 0 <= num3 && num3 < 10)
				{
					num = num2 * 10 + num3;
					return true;
				}
			}
			num = 0;
			return false;
		}

		private bool ParseChar(int start, char ch)
		{
			if (start < _end)
			{
				return _text[start] == ch;
			}
			return false;
		}
	}
	internal static class DateTimeUtils
	{
		internal static readonly long InitialJavaScriptDateTicks;

		private const string IsoDateFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFK";

		private const int DaysPer100Years = 36524;

		private const int DaysPer400Years = 146097;

		private const int DaysPer4Years = 1461;

		private const int DaysPerYear = 365;

		private const long TicksPerDay = 864000000000L;

		private static readonly int[] DaysToMonth365;

		private static readonly int[] DaysToMonth366;

		static DateTimeUtils()
		{
			InitialJavaScriptDateTicks = 621355968000000000L;
			DaysToMonth365 = new int[13]
			{
				0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
				304, 334, 365
			};
			DaysToMonth366 = new int[13]
			{
				0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
				305, 335, 366
			};
		}

		public static TimeSpan GetUtcOffset(this DateTime d)
		{
			return TimeZoneInfo.Local.GetUtcOffset(d);
		}

		public static string ToDateTimeFormat(DateTimeKind kind)
		{
			return kind switch
			{
				DateTimeKind.Local => "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", 
				DateTimeKind.Unspecified => "yyyy-MM-ddTHH:mm:ss.FFFFFFF", 
				DateTimeKind.Utc => "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ", 
				_ => throw MiscellaneousUtils.CreateArgumentOutOfRangeException("kind", kind, "Unexpected DateTimeKind value."), 
			};
		}

		internal static DateTime EnsureDateTime(DateTime value, DateTimeZoneHandling timeZone)
		{
			switch (timeZone)
			{
			case DateTimeZoneHandling.Local:
				value = SwitchToLocalTime(value);
				break;
			case DateTimeZoneHandling.Utc:
				value = SwitchToUtcTime(value);
				break;
			case DateTimeZoneHandling.Unspecified:
				value = new DateTime(value.Ticks, DateTimeKind.Unspecified);
				break;
			default:
				throw new ArgumentException("Invalid date time handling value.");
			case DateTimeZoneHandling.RoundtripKind:
				break;
			}
			return value;
		}

		private static DateTime SwitchToLocalTime(DateTime value)
		{
			return value.Kind switch
			{
				DateTimeKind.Unspecified => new DateTime(value.Ticks, DateTimeKind.Local), 
				DateTimeKind.Utc => value.ToLocalTime(), 
				DateTimeKind.Local => value, 
				_ => value, 
			};
		}

		private static DateTime SwitchToUtcTime(DateTime value)
		{
			return value.Kind switch
			{
				DateTimeKind.Unspecified => new DateTime(value.Ticks, DateTimeKind.Utc), 
				DateTimeKind.Utc => value, 
				DateTimeKind.Local => value.ToUniversalTime(), 
				_ => value, 
			};
		}

		private static long ToUniversalTicks(DateTime dateTime)
		{
			if (dateTime.Kind == DateTimeKind.Utc)
			{
				return dateTime.Ticks;
			}
			return ToUniversalTicks(dateTime, dateTime.GetUtcOffset());
		}

		private static long ToUniversalTicks(DateTime dateTime, TimeSpan offset)
		{
			if (dateTime.Kind == DateTimeKind.Utc || dateTime == DateTime.MaxValue || dateTime == DateTime.MinValue)
			{
				return dateTime.Ticks;
			}
			long num = dateTime.Ticks - offset.Ticks;
			if (num > 3155378975999999999L)
			{
				return 3155378975999999999L;
			}
			if (num < 0)
			{
				return 0L;
			}
			return num;
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, TimeSpan offset)
		{
			return UniversialTicksToJavaScriptTicks(ToUniversalTicks(dateTime, offset));
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime)
		{
			return ConvertDateTimeToJavaScriptTicks(dateTime, convertToUtc: true);
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, bool convertToUtc)
		{
			return UniversialTicksToJavaScriptTicks(convertToUtc ? ToUniversalTicks(dateTime) : dateTime.Ticks);
		}

		private static long UniversialTicksToJavaScriptTicks(long universialTicks)
		{
			return (universialTicks - InitialJavaScriptDateTicks) / 10000;
		}

		internal static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks)
		{
			return new DateTime(javaScriptTicks * 10000 + InitialJavaScriptDateTicks, DateTimeKind.Utc);
		}

		internal static bool TryParseDateTimeIso(string text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt)
		{
			DateTimeParser dateTimeParser = default(DateTimeParser);
			if (!dateTimeParser.Parse(text, 0, text.Length))
			{
				dt = default(DateTime);
				return false;
			}
			DateTime dateTime = CreateDateTime(dateTimeParser);
			switch (dateTimeParser.Zone)
			{
			case ParserTimeZone.Utc:
				dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
				break;
			case ParserTimeZone.LocalWestOfUtc:
			{
				TimeSpan timeSpan2 = new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0);
				long num = dateTime.Ticks + timeSpan2.Ticks;
				long num4 = num;
				DateTime minValue = DateTime.MaxValue;
				if (num4 <= minValue.Ticks)
				{
					dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
					break;
				}
				num += dateTime.GetUtcOffset().Ticks;
				long num5 = num;
				minValue = DateTime.MaxValue;
				if (num5 > minValue.Ticks)
				{
					minValue = DateTime.MaxValue;
					num = minValue.Ticks;
				}
				dateTime = new DateTime(num, DateTimeKind.Local);
				break;
			}
			case ParserTimeZone.LocalEastOfUtc:
			{
				TimeSpan timeSpan = new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0);
				long num = dateTime.Ticks - timeSpan.Ticks;
				long num2 = num;
				DateTime minValue = DateTime.MinValue;
				if (num2 >= minValue.Ticks)
				{
					dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
					break;
				}
				num += dateTime.GetUtcOffset().Ticks;
				long num3 = num;
				minValue = DateTime.MinValue;
				if (num3 < minValue.Ticks)
				{
					minValue = DateTime.MinValue;
					num = minValue.Ticks;
				}
				dateTime = new DateTime(num, DateTimeKind.Local);
				break;
			}
			}
			dt = EnsureDateTime(dateTime, dateTimeZoneHandling);
			return true;
		}

		internal static bool TryParseDateTimeOffsetIso(string text, out DateTimeOffset dt)
		{
			DateTimeParser dateTimeParser = default(DateTimeParser);
			if (!dateTimeParser.Parse(text, 0, text.Length))
			{
				dt = default(DateTimeOffset);
				return false;
			}
			DateTime dateTime = CreateDateTime(dateTimeParser);
			TimeSpan offset = dateTimeParser.Zone switch
			{
				ParserTimeZone.Utc => new TimeSpan(0L), 
				ParserTimeZone.LocalWestOfUtc => new TimeSpan(-dateTimeParser.ZoneHour, -dateTimeParser.ZoneMinute, 0), 
				ParserTimeZone.LocalEastOfUtc => new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0), 
				_ => TimeZoneInfo.Local.GetUtcOffset(dateTime), 
			};
			long num = dateTime.Ticks - offset.Ticks;
			if (num < 0 || num > 3155378975999999999L)
			{
				dt = default(DateTimeOffset);
				return false;
			}
			dt = new DateTimeOffset(dateTime, offset);
			return true;
		}

		private static DateTime CreateDateTime(DateTimeParser dateTimeParser)
		{
			bool flag;
			if (dateTimeParser.Hour == 24)
			{
				flag = true;
				dateTimeParser.Hour = 0;
			}
			else
			{
				flag = false;
			}
			DateTime result = new DateTime(dateTimeParser.Year, dateTimeParser.Month, dateTimeParser.Day, dateTimeParser.Hour, dateTimeParser.Minute, dateTimeParser.Second).AddTicks(dateTimeParser.Fraction);
			if (flag)
			{
				result = result.AddDays(1.0);
			}
			return result;
		}

		internal static bool TryParseDateTime(string s, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
		{
			if (s.Length > 0)
			{
				if (s[0] == '/')
				{
					if (s.Length >= 9 && s.StartsWith("/Date(", StringComparison.Ordinal) && s.EndsWith(")/", StringComparison.Ordinal) && TryParseDateTimeMicrosoft(s, dateTimeZoneHandling, out dt))
					{
						return true;
					}
				}
				else if (s.Length >= 19 && s.Length <= 40 && char.IsDigit(s[0]) && s[10] == 'T' && DateTime.TryParseExact(s, "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt))
				{
					dt = EnsureDateTime(dt, dateTimeZoneHandling);
					return true;
				}
				if (!string.IsNullOrEmpty(dateFormatString) && TryParseDateTimeExact(s, dateTimeZoneHandling, dateFormatString, culture, out dt))
				{
					return true;
				}
			}
			dt = default(DateTime);
			return false;
		}

		internal static bool TryParseDateTimeOffset(string s, string dateFormatString, CultureInfo culture, out DateTimeOffset dt)
		{
			if (s.Length > 0)
			{
				if (s[0] == '/')
				{
					if (s.Length >= 9 && s.StartsWith("/Date(", StringComparison.Ordinal) && s.EndsWith(")/", StringComparison.Ordinal) && TryParseDateTimeOffsetMicrosoft(s, out dt))
					{
						return true;
					}
				}
				else if (s.Length >= 19 && s.Length <= 40 && char.IsDigit(s[0]) && s[10] == 'T' && DateTimeOffset.TryParseExact(s, "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt) && TryParseDateTimeOffsetIso(s, out dt))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(dateFormatString) && TryParseDateTimeOffsetExact(s, dateFormatString, culture, out dt))
				{
					return true;
				}
			}
			dt = default(DateTimeOffset);
			return false;
		}

		private static bool TryParseMicrosoftDate(string text, out long ticks, out TimeSpan offset, out DateTimeKind kind)
		{
			kind = DateTimeKind.Utc;
			int num = text.IndexOf('+', 7, text.Length - 8);
			if (num == -1)
			{
				num = text.IndexOf('-', 7, text.Length - 8);
			}
			if (num != -1)
			{
				kind = DateTimeKind.Local;
				if (!TryReadOffset(text, num, out offset))
				{
					ticks = 0L;
					return false;
				}
			}
			else
			{
				offset = TimeSpan.Zero;
				num = text.Length - 2;
			}
			return long.TryParse(text.Substring(6, num - 6), out ticks);
		}

		private static bool TryParseDateTimeMicrosoft(string text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt)
		{
			if (!TryParseMicrosoftDate(text, out var ticks, out var _, out var kind))
			{
				dt = default(DateTime);
				return false;
			}
			DateTime dateTime = ConvertJavaScriptTicksToDateTime(ticks);
			switch (kind)
			{
			case DateTimeKind.Unspecified:
				dt = DateTime.SpecifyKind(dateTime.ToLocalTime(), DateTimeKind.Unspecified);
				break;
			case DateTimeKind.Local:
				dt = dateTime.ToLocalTime();
				break;
			default:
				dt = dateTime;
				break;
			}
			dt = EnsureDateTime(dt, dateTimeZoneHandling);
			return true;
		}

		private static bool TryParseDateTimeExact(string text, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
		{
			if (DateTime.TryParseExact(text, dateFormatString, culture, DateTimeStyles.RoundtripKind, out var result))
			{
				result = EnsureDateTime(result, dateTimeZoneHandling);
				dt = result;
				return true;
			}
			dt = default(DateTime);
			return false;
		}

		private static bool TryParseDateTimeOffsetMicrosoft(string text, out DateTimeOffset dt)
		{
			if (!TryParseMicrosoftDate(text, out var ticks, out var offset, out var _))
			{
				dt = default(DateTime);
				return false;
			}
			dt = new DateTimeOffset(ConvertJavaScriptTicksToDateTime(ticks).Add(offset).Ticks, offset);
			return true;
		}

		private static bool TryParseDateTimeOffsetExact(string text, string dateFormatString, CultureInfo culture, out DateTimeOffset dt)
		{
			if (DateTimeOffset.TryParseExact(text, dateFormatString, culture, DateTimeStyles.RoundtripKind, out var result))
			{
				dt = result;
				return true;
			}
			dt = default(DateTimeOffset);
			return false;
		}

		private static bool TryReadOffset(string offsetText, int startIndex, out TimeSpan offset)
		{
			bool flag = offsetText[startIndex] == '-';
			if (int.TryParse(offsetText.Substring(startIndex + 1, 2), out var result))
			{
				offset = default(TimeSpan);
				return false;
			}
			int result2 = 0;
			if (offsetText.Length - startIndex > 5 && int.TryParse(offsetText.Substring(startIndex + 3, 2), out result2))
			{
				offset = default(TimeSpan);
				return false;
			}
			offset = TimeSpan.FromHours(result) + TimeSpan.FromMinutes(result2);
			if (flag)
			{
				offset = offset.Negate();
			}
			return true;
		}
	}
	internal static class ExceptionUtils
	{
		internal static JsonReaderException CreateJsonReaderException(JsonReader reader, string message)
		{
			return CreateJsonReaderException(reader, message, null);
		}

		internal static JsonReaderException CreateJsonReaderException(JsonReader reader, string message, Exception ex)
		{
			return CreateJsonReaderException(reader as IJsonLineInfo, reader.Path, message, ex);
		}

		internal static JsonReaderException CreateJsonReaderException(IJsonLineInfo lineInfo, string path, string message, Exception ex)
		{
			message = FormatMessage(lineInfo, path, message);
			int lineNumber;
			int linePosition;
			if (lineInfo != null && lineInfo.HasLineInfo())
			{
				lineNumber = lineInfo.LineNumber;
				linePosition = lineInfo.LinePosition;
			}
			else
			{
				lineNumber = 0;
				linePosition = 0;
			}
			return new JsonReaderException(message, path, lineNumber, linePosition, ex);
		}

		internal static JsonWriterException CreateJsonWriterException(JsonWriter writer, string message, Exception ex)
		{
			return CreateJsonWriterException(writer.Path, message, ex);
		}

		internal static JsonWriterException CreateJsonWriterException(string path, string message, Exception ex)
		{
			message = FormatMessage(null, path, message);
			return new JsonWriterException(message, path, ex);
		}

		internal static JsonSerializationException CreateJsonSerializationException(IJsonLineInfo lineInfo, string path, string message, Exception ex)
		{
			message = FormatMessage(lineInfo, path, message);
			return new JsonSerializationException(message, ex);
		}

		private static string FormatMessage(IJsonLineInfo lineInfo, string path, string message)
		{
			if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
			{
				message = message.Trim();
				if (!message.EndsWith('.'))
				{
					message += ".";
				}
				message += " ";
			}
			message += "Path '{0}'".FormatWith(CultureInfo.InvariantCulture, path);
			if (lineInfo != null && lineInfo.HasLineInfo())
			{
				message += ", line {0}, position {1}".FormatWith(CultureInfo.InvariantCulture, lineInfo.LineNumber, lineInfo.LinePosition);
			}
			message += ".";
			return message;
		}
	}
	internal static class JsonTokenUtils
	{
		internal static bool IsPrimitiveToken(JsonToken token)
		{
			if ((uint)(token - 7) <= 5u || (uint)(token - 16) <= 1u)
			{
				return true;
			}
			return false;
		}
	}
	internal static class MathUtils
	{
		public static int IntLength(ulong i)
		{
			if (i < 10000000000L)
			{
				if (i < 10)
				{
					return 1;
				}
				if (i < 100)
				{
					return 2;
				}
				if (i < 1000)
				{
					return 3;
				}
				if (i < 10000)
				{
					return 4;
				}
				if (i < 100000)
				{
					return 5;
				}
				if (i < 1000000)
				{
					return 6;
				}
				if (i < 10000000)
				{
					return 7;
				}
				if (i < 100000000)
				{
					return 8;
				}
				if (i < 1000000000)
				{
					return 9;
				}
				return 10;
			}
			if (i < 100000000000L)
			{
				return 11;
			}
			if (i < 1000000000000L)
			{
				return 12;
			}
			if (i < 10000000000000L)
			{
				return 13;
			}
			if (i < 100000000000000L)
			{
				return 14;
			}
			if (i < 1000000000000000L)
			{
				return 15;
			}
			if (i < 10000000000000000L)
			{
				return 16;
			}
			if (i < 100000000000000000L)
			{
				return 17;
			}
			if (i < 1000000000000000000L)
			{
				return 18;
			}
			if (i < 10000000000000000000uL)
			{
				return 19;
			}
			return 20;
		}

		public static char IntToHex(int n)
		{
			if (n <= 9)
			{
				return (char)(n + 48);
			}
			return (char)(n - 10 + 97);
		}
	}
	internal static class MiscellaneousUtils
	{
		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string paramName, object actualValue, string message)
		{
			string message2 = message + Environment.NewLine + "Actual value was {0}.".FormatWith(CultureInfo.InvariantCulture, actualValue);
			return new ArgumentOutOfRangeException(paramName, message2);
		}
	}
	internal static class StringUtils
	{
		public const string CarriageReturnLineFeed = "\r\n";

		public const string Empty = "";

		public const char CarriageReturn = '\r';

		public const char LineFeed = '\n';

		public const char Tab = '\t';

		public static string FormatWith(this string format, IFormatProvider provider, object arg0)
		{
			return format.FormatWith(provider, new object[1] { arg0 });
		}

		public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1)
		{
			return format.FormatWith(provider, new object[2] { arg0, arg1 });
		}

		public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1, object arg2)
		{
			return format.FormatWith(provider, new object[3] { arg0, arg1, arg2 });
		}

		public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1, object arg2, object arg3)
		{
			return format.FormatWith(provider, new object[4] { arg0, arg1, arg2, arg3 });
		}

		private static string FormatWith(this string format, IFormatProvider provider, params object[] args)
		{
			ValidationUtils.ArgumentNotNull(format, "format");
			return string.Format(provider, format, args);
		}

		public static bool StartsWith(this string source, char value)
		{
			if (source.Length > 0)
			{
				return source[0] == value;
			}
			return false;
		}

		public static bool EndsWith(this string source, char value)
		{
			if (source.Length > 0)
			{
				return source[source.Length - 1] == value;
			}
			return false;
		}
	}
	internal static class ValidationUtils
	{
		public static void ArgumentNotNull(object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}
namespace Newtonsoft.Json.Bson.Converters
{
	public class BsonDataObjectIdConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			BsonDataObjectId bsonDataObjectId = (BsonDataObjectId)value;
			if (writer is BsonDataWriter bsonDataWriter)
			{
				bsonDataWriter.WriteObjectId(bsonDataObjectId.Value);
			}
			else
			{
				writer.WriteValue(bsonDataObjectId.Value);
			}
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Bytes)
			{
				throw new JsonSerializationException("Expected Bytes but got {0}.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
			}
			return new BsonDataObjectId((byte[])reader.Value);
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(BsonDataObjectId);
		}
	}
	public class BsonDataRegexConverter : JsonConverter
	{
		private const string PatternName = "Pattern";

		private const string OptionsName = "Options";

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			Regex regex = (Regex)value;
			BsonDataWriter bsonDataWriter = writer as BsonDataWriter;
			if (bsonDataWriter == null)
			{
				throw ExceptionUtils.CreateJsonSerializationException(bsonDataWriter as IJsonLineInfo, bsonDataWriter.Path, "BsonDataRegexConverter only supports writing a regex with BsonDataWriter.", null);
			}
			WriteBson(bsonDataWriter, regex);
		}

		private bool HasFlag(RegexOptions options, RegexOptions flag)
		{
			return (options & flag) == flag;
		}

		private void WriteBson(BsonDataWriter writer, Regex regex)
		{
			string text = null;
			if (HasFlag(regex.Options, RegexOptions.IgnoreCase))
			{
				text += "i";
			}
			if (HasFlag(regex.Options, RegexOptions.Multiline))
			{
				text += "m";
			}
			if (HasFlag(regex.Options, RegexOptions.Singleline))
			{
				text += "s";
			}
			text += "u";
			if (HasFlag(regex.Options, RegexOptions.ExplicitCapture))
			{
				text += "x";
			}
			writer.WriteRegex(regex.ToString(), text);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return reader.TokenType switch
			{
				JsonToken.StartObject => ReadRegexObject(reader, serializer), 
				JsonToken.String => ReadRegexString(reader), 
				JsonToken.Null => null, 
				_ => throw ExceptionUtils.CreateJsonSerializationException(reader as IJsonLineInfo, reader.Path, "Unexpected token when reading Regex.", null), 
			};
		}

		private object ReadRegexString(JsonReader reader)
		{
			string obj = (string)reader.Value;
			int num = obj.LastIndexOf('/');
			string pattern = obj.Substring(1, num - 1);
			string text = obj.Substring(num + 1);
			RegexOptions regexOptions = RegexOptions.None;
			string text2 = text;
			for (int i = 0; i < text2.Length; i++)
			{
				switch (text2[i])
				{
				case 'i':
					regexOptions |= RegexOptions.IgnoreCase;
					break;
				case 'm':
					regexOptions |= RegexOptions.Multiline;
					break;
				case 's':
					regexOptions |= RegexOptions.Singleline;
					break;
				case 'x':
					regexOptions |= RegexOptions.ExplicitCapture;
					break;
				}
			}
			return new Regex(pattern, regexOptions);
		}

		private Regex ReadRegexObject(JsonReader reader, JsonSerializer serializer)
		{
			string text = null;
			RegexOptions? regexOptions = null;
			while (reader.Read())
			{
				switch (reader.TokenType)
				{
				case JsonToken.PropertyName:
				{
					string a = reader.Value.ToString();
					if (!reader.Read())
					{
						throw ExceptionUtils.CreateJsonSerializationException(reader as IJsonLineInfo, reader.Path, "Unexpected end when reading Regex.", null);
					}
					if (string.Equals(a, "Pattern", StringComparison.OrdinalIgnoreCase))
					{
						text = (string)reader.Value;
					}
					else if (string.Equals(a, "Options", StringComparison.OrdinalIgnoreCase))
					{
						regexOptions = serializer.Deserialize<RegexOptions>(reader);
					}
					else
					{
						reader.Skip();
					}
					break;
				}
				case JsonToken.EndObject:
					if (text == null)
					{
						throw ExceptionUtils.CreateJsonSerializationException(reader as IJsonLineInfo, reader.Path, "Error deserializing Regex. No pattern found.", null);
					}
					return new Regex(text, regexOptions ?? RegexOptions.None);
				}
			}
			throw ExceptionUtils.CreateJsonSerializationException(reader as IJsonLineInfo, reader.Path, "Unexpected end when reading Regex.", null);
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Regex);
		}
	}
}
