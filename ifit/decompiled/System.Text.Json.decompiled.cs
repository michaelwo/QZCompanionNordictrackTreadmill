using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Converters;
using System.Threading;
using System.Threading.Tasks;
using FxResources.System.Text.Json;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyDefaultAlias("System.Text.Json")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.Text.Json")]
[assembly: AssemblyFileVersion("4.700.20.6702")]
[assembly: AssemblyInformationalVersion("3.1.2+e946cebe43a510e8c6476bbc8185d1445df33a1a")]
[assembly: AssemblyProduct("Microsoft® .NET Core")]
[assembly: AssemblyTitle("System.Text.Json")]
[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("4.0.1.1")]
[module: UnverifiableCode]
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
	[CompilerGenerated]
	[Embedded]
	internal sealed class IsByRefLikeAttribute : Attribute
	{
	}
}
namespace FxResources.System.Text.Json
{
	internal static class SR
	{
	}
}
namespace System
{
	internal static class SR
	{
		private static ResourceManager s_resourceManager;

		internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(FxResources.System.Text.Json.SR)));

		internal static string ArrayDepthTooLarge => GetResourceString("ArrayDepthTooLarge");

		internal static string CallFlushToAvoidDataLoss => GetResourceString("CallFlushToAvoidDataLoss");

		internal static string CannotReadIncompleteUTF16 => GetResourceString("CannotReadIncompleteUTF16");

		internal static string CannotReadInvalidUTF16 => GetResourceString("CannotReadInvalidUTF16");

		internal static string CannotStartObjectArrayAfterPrimitiveOrClose => GetResourceString("CannotStartObjectArrayAfterPrimitiveOrClose");

		internal static string CannotStartObjectArrayWithoutProperty => GetResourceString("CannotStartObjectArrayWithoutProperty");

		internal static string CannotTranscodeInvalidUtf8 => GetResourceString("CannotTranscodeInvalidUtf8");

		internal static string CannotDecodeInvalidBase64 => GetResourceString("CannotDecodeInvalidBase64");

		internal static string CannotTranscodeInvalidUtf16 => GetResourceString("CannotTranscodeInvalidUtf16");

		internal static string CannotEncodeInvalidUTF16 => GetResourceString("CannotEncodeInvalidUTF16");

		internal static string CannotEncodeInvalidUTF8 => GetResourceString("CannotEncodeInvalidUTF8");

		internal static string CannotWritePropertyWithinArray => GetResourceString("CannotWritePropertyWithinArray");

		internal static string CannotWritePropertyAfterProperty => GetResourceString("CannotWritePropertyAfterProperty");

		internal static string CannotWriteValueAfterPrimitiveOrClose => GetResourceString("CannotWriteValueAfterPrimitiveOrClose");

		internal static string CannotWriteValueWithinObject => GetResourceString("CannotWriteValueWithinObject");

		internal static string DepthTooLarge => GetResourceString("DepthTooLarge");

		internal static string EmptyJsonIsInvalid => GetResourceString("EmptyJsonIsInvalid");

		internal static string EndOfCommentNotFound => GetResourceString("EndOfCommentNotFound");

		internal static string EndOfStringNotFound => GetResourceString("EndOfStringNotFound");

		internal static string ExpectedEndAfterSingleJson => GetResourceString("ExpectedEndAfterSingleJson");

		internal static string ExpectedEndOfDigitNotFound => GetResourceString("ExpectedEndOfDigitNotFound");

		internal static string ExpectedFalse => GetResourceString("ExpectedFalse");

		internal static string ExpectedJsonTokens => GetResourceString("ExpectedJsonTokens");

		internal static string ExpectedOneCompleteToken => GetResourceString("ExpectedOneCompleteToken");

		internal static string ExpectedNextDigitEValueNotFound => GetResourceString("ExpectedNextDigitEValueNotFound");

		internal static string ExpectedNull => GetResourceString("ExpectedNull");

		internal static string ExpectedSeparatorAfterPropertyNameNotFound => GetResourceString("ExpectedSeparatorAfterPropertyNameNotFound");

		internal static string ExpectedStartOfPropertyNotFound => GetResourceString("ExpectedStartOfPropertyNotFound");

		internal static string ExpectedStartOfPropertyOrValueNotFound => GetResourceString("ExpectedStartOfPropertyOrValueNotFound");

		internal static string ExpectedStartOfValueNotFound => GetResourceString("ExpectedStartOfValueNotFound");

		internal static string ExpectedTrue => GetResourceString("ExpectedTrue");

		internal static string ExpectedValueAfterPropertyNameNotFound => GetResourceString("ExpectedValueAfterPropertyNameNotFound");

		internal static string FailedToGetLargerSpan => GetResourceString("FailedToGetLargerSpan");

		internal static string FoundInvalidCharacter => GetResourceString("FoundInvalidCharacter");

		internal static string InvalidCast => GetResourceString("InvalidCast");

		internal static string InvalidCharacterAfterEscapeWithinString => GetResourceString("InvalidCharacterAfterEscapeWithinString");

		internal static string InvalidCharacterWithinString => GetResourceString("InvalidCharacterWithinString");

		internal static string InvalidEndOfJsonNonPrimitive => GetResourceString("InvalidEndOfJsonNonPrimitive");

		internal static string InvalidHexCharacterWithinString => GetResourceString("InvalidHexCharacterWithinString");

		internal static string JsonDocumentDoesNotSupportComments => GetResourceString("JsonDocumentDoesNotSupportComments");

		internal static string JsonElementHasWrongType => GetResourceString("JsonElementHasWrongType");

		internal static string MaxDepthMustBePositive => GetResourceString("MaxDepthMustBePositive");

		internal static string CommentHandlingMustBeValid => GetResourceString("CommentHandlingMustBeValid");

		internal static string MismatchedObjectArray => GetResourceString("MismatchedObjectArray");

		internal static string CannotWriteEndAfterProperty => GetResourceString("CannotWriteEndAfterProperty");

		internal static string ObjectDepthTooLarge => GetResourceString("ObjectDepthTooLarge");

		internal static string PropertyNameTooLarge => GetResourceString("PropertyNameTooLarge");

		internal static string FormatDecimal => GetResourceString("FormatDecimal");

		internal static string FormatDouble => GetResourceString("FormatDouble");

		internal static string FormatInt32 => GetResourceString("FormatInt32");

		internal static string FormatInt64 => GetResourceString("FormatInt64");

		internal static string FormatSingle => GetResourceString("FormatSingle");

		internal static string FormatUInt32 => GetResourceString("FormatUInt32");

		internal static string FormatUInt64 => GetResourceString("FormatUInt64");

		internal static string RequiredDigitNotFoundAfterDecimal => GetResourceString("RequiredDigitNotFoundAfterDecimal");

		internal static string RequiredDigitNotFoundAfterSign => GetResourceString("RequiredDigitNotFoundAfterSign");

		internal static string RequiredDigitNotFoundEndOfData => GetResourceString("RequiredDigitNotFoundEndOfData");

		internal static string SpecialNumberValuesNotSupported => GetResourceString("SpecialNumberValuesNotSupported");

		internal static string ValueTooLarge => GetResourceString("ValueTooLarge");

		internal static string ZeroDepthAtEnd => GetResourceString("ZeroDepthAtEnd");

		internal static string DeserializeUnableToConvertValue => GetResourceString("DeserializeUnableToConvertValue");

		internal static string DeserializeWrongType => GetResourceString("DeserializeWrongType");

		internal static string SerializationInvalidBufferSize => GetResourceString("SerializationInvalidBufferSize");

		internal static string BufferWriterAdvancedTooFar => GetResourceString("BufferWriterAdvancedTooFar");

		internal static string InvalidComparison => GetResourceString("InvalidComparison");

		internal static string FormatDateTime => GetResourceString("FormatDateTime");

		internal static string FormatDateTimeOffset => GetResourceString("FormatDateTimeOffset");

		internal static string FormatGuid => GetResourceString("FormatGuid");

		internal static string ExpectedStartOfPropertyOrValueAfterComment => GetResourceString("ExpectedStartOfPropertyOrValueAfterComment");

		internal static string TrailingCommaNotAllowedBeforeArrayEnd => GetResourceString("TrailingCommaNotAllowedBeforeArrayEnd");

		internal static string TrailingCommaNotAllowedBeforeObjectEnd => GetResourceString("TrailingCommaNotAllowedBeforeObjectEnd");

		internal static string SerializerOptionsImmutable => GetResourceString("SerializerOptionsImmutable");

		internal static string StreamNotWritable => GetResourceString("StreamNotWritable");

		internal static string CannotWriteCommentWithEmbeddedDelimiter => GetResourceString("CannotWriteCommentWithEmbeddedDelimiter");

		internal static string SerializerPropertyNameConflict => GetResourceString("SerializerPropertyNameConflict");

		internal static string SerializerPropertyNameNull => GetResourceString("SerializerPropertyNameNull");

		internal static string DeserializeDuplicateKey => GetResourceString("DeserializeDuplicateKey");

		internal static string SerializationDataExtensionPropertyInvalid => GetResourceString("SerializationDataExtensionPropertyInvalid");

		internal static string SerializationDuplicateTypeAttribute => GetResourceString("SerializationDuplicateTypeAttribute");

		internal static string SerializationNotSupportedCollectionType => GetResourceString("SerializationNotSupportedCollectionType");

		internal static string SerializationNotSupportedCollection => GetResourceString("SerializationNotSupportedCollection");

		internal static string InvalidCharacterAtStartOfComment => GetResourceString("InvalidCharacterAtStartOfComment");

		internal static string UnexpectedEndOfDataWhileReadingComment => GetResourceString("UnexpectedEndOfDataWhileReadingComment");

		internal static string CannotSkip => GetResourceString("CannotSkip");

		internal static string NotEnoughData => GetResourceString("NotEnoughData");

		internal static string UnexpectedEndOfLineSeparator => GetResourceString("UnexpectedEndOfLineSeparator");

		internal static string JsonSerializerDoesNotSupportComments => GetResourceString("JsonSerializerDoesNotSupportComments");

		internal static string DeserializeMissingParameterlessConstructor => GetResourceString("DeserializeMissingParameterlessConstructor");

		internal static string DeserializePolymorphicInterface => GetResourceString("DeserializePolymorphicInterface");

		internal static string SerializationConverterOnAttributeNotCompatible => GetResourceString("SerializationConverterOnAttributeNotCompatible");

		internal static string SerializationConverterOnAttributeInvalid => GetResourceString("SerializationConverterOnAttributeInvalid");

		internal static string SerializationConverterRead => GetResourceString("SerializationConverterRead");

		internal static string SerializationConverterNotCompatible => GetResourceString("SerializationConverterNotCompatible");

		internal static string SerializationConverterWrite => GetResourceString("SerializationConverterWrite");

		internal static string SerializerDictionaryKeyNull => GetResourceString("SerializerDictionaryKeyNull");

		internal static string SerializationDuplicateAttribute => GetResourceString("SerializationDuplicateAttribute");

		internal static string SerializeUnableToSerialize => GetResourceString("SerializeUnableToSerialize");

		internal static string FormatByte => GetResourceString("FormatByte");

		internal static string FormatInt16 => GetResourceString("FormatInt16");

		internal static string FormatSByte => GetResourceString("FormatSByte");

		internal static string FormatUInt16 => GetResourceString("FormatUInt16");

		internal static string SerializerCycleDetected => GetResourceString("SerializerCycleDetected");

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool UsingResourceKeys()
		{
			return false;
		}

		internal static string GetResourceString(string resourceKey, string defaultString = null)
		{
			if (UsingResourceKeys())
			{
				return defaultString ?? resourceKey;
			}
			string text = null;
			try
			{
				text = ResourceManager.GetString(resourceKey);
			}
			catch (MissingManifestResourceException)
			{
			}
			if (defaultString != null && resourceKey.Equals(text))
			{
				return defaultString;
			}
			return text;
		}

		internal static string Format(string resourceFormat, object p1)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1);
			}
			return string.Format(resourceFormat, p1);
		}

		internal static string Format(string resourceFormat, object p1, object p2)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2);
			}
			return string.Format(resourceFormat, p1, p2);
		}

		internal static string Format(string resourceFormat, object p1, object p2, object p3)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2, p3);
			}
			return string.Format(resourceFormat, p1, p2, p3);
		}

		internal static string Format(string resourceFormat, params object[] args)
		{
			if (args != null)
			{
				if (UsingResourceKeys())
				{
					return resourceFormat + ", " + string.Join(", ", args);
				}
				return string.Format(resourceFormat, args);
			}
			return resourceFormat;
		}

		internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1);
			}
			return string.Format(provider, resourceFormat, p1);
		}

		internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2);
			}
			return string.Format(provider, resourceFormat, p1, p2);
		}

		internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2, object p3)
		{
			if (UsingResourceKeys())
			{
				return string.Join(", ", resourceFormat, p1, p2, p3);
			}
			return string.Format(provider, resourceFormat, p1, p2, p3);
		}

		internal static string Format(IFormatProvider provider, string resourceFormat, params object[] args)
		{
			if (args != null)
			{
				if (UsingResourceKeys())
				{
					return resourceFormat + ", " + string.Join(", ", args);
				}
				return string.Format(provider, resourceFormat, args);
			}
			return resourceFormat;
		}
	}
}
namespace System.Buffers
{
	internal sealed class ArrayBufferWriter<T> : IBufferWriter<T>
	{
		private T[] _buffer;

		private int _index;

		private const int DefaultInitialBufferSize = 256;

		public ReadOnlyMemory<T> WrittenMemory => _buffer.AsMemory(0, _index);

		public ReadOnlySpan<T> WrittenSpan => _buffer.AsSpan(0, _index);

		public int WrittenCount => _index;

		public int Capacity => _buffer.Length;

		public int FreeCapacity => _buffer.Length - _index;

		public ArrayBufferWriter()
		{
			_buffer = Array.Empty<T>();
			_index = 0;
		}

		public ArrayBufferWriter(int initialCapacity)
		{
			if (initialCapacity <= 0)
			{
				throw new ArgumentException("initialCapacity");
			}
			_buffer = new T[initialCapacity];
			_index = 0;
		}

		public void Clear()
		{
			_buffer.AsSpan(0, _index).Clear();
			_index = 0;
		}

		public void Advance(int count)
		{
			if (count < 0)
			{
				throw new ArgumentException("count");
			}
			if (_index > _buffer.Length - count)
			{
				ThrowInvalidOperationException_AdvancedTooFar(_buffer.Length);
			}
			_index += count;
		}

		public Memory<T> GetMemory(int sizeHint = 0)
		{
			CheckAndResizeBuffer(sizeHint);
			return _buffer.AsMemory(_index);
		}

		public Span<T> GetSpan(int sizeHint = 0)
		{
			CheckAndResizeBuffer(sizeHint);
			return _buffer.AsSpan(_index);
		}

		private void CheckAndResizeBuffer(int sizeHint)
		{
			if (sizeHint < 0)
			{
				throw new ArgumentException("sizeHint");
			}
			if (sizeHint == 0)
			{
				sizeHint = 1;
			}
			if (sizeHint > FreeCapacity)
			{
				int num = Math.Max(sizeHint, _buffer.Length);
				if (_buffer.Length == 0)
				{
					num = Math.Max(num, 256);
				}
				int newSize = checked(_buffer.Length + num);
				Array.Resize(ref _buffer, newSize);
			}
		}

		private static void ThrowInvalidOperationException_AdvancedTooFar(int capacity)
		{
			throw new InvalidOperationException(SR.Format(SR.BufferWriterAdvancedTooFar, capacity));
		}
	}
}
namespace System.Buffers.Text
{
	internal enum SequenceValidity
	{
		Empty,
		WellFormed,
		Incomplete,
		Invalid
	}
}
namespace System.Text.Json
{
	internal struct BitStack
	{
		private const int AllocationFreeMaxDepth = 64;

		private const int DefaultInitialArraySize = 2;

		private int[] _array;

		private ulong _allocationFreeContainer;

		private int _currentDepth;

		public int CurrentDepth => _currentDepth;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PushTrue()
		{
			if (_currentDepth < 64)
			{
				_allocationFreeContainer = (_allocationFreeContainer << 1) | 1;
			}
			else
			{
				PushToArray(value: true);
			}
			_currentDepth++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PushFalse()
		{
			if (_currentDepth < 64)
			{
				_allocationFreeContainer <<= 1;
			}
			else
			{
				PushToArray(value: false);
			}
			_currentDepth++;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PushToArray(bool value)
		{
			if (_array == null)
			{
				_array = new int[2];
			}
			int number = _currentDepth - 64;
			int remainder;
			int num = Div32Rem(number, out remainder);
			if (num >= _array.Length)
			{
				DoubleArray(num);
			}
			int num2 = _array[num];
			num2 = ((!value) ? (num2 & ~(1 << remainder)) : (num2 | (1 << remainder)));
			_array[num] = num2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Pop()
		{
			_currentDepth--;
			bool flag = false;
			if (_currentDepth < 64)
			{
				_allocationFreeContainer >>= 1;
				return (_allocationFreeContainer & 1) != 0;
			}
			if (_currentDepth == 64)
			{
				return (_allocationFreeContainer & 1) != 0;
			}
			return PopFromArray();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool PopFromArray()
		{
			int number = _currentDepth - 64 - 1;
			int remainder;
			int num = Div32Rem(number, out remainder);
			return (_array[num] & (1 << remainder)) != 0;
		}

		private void DoubleArray(int minSize)
		{
			int newSize = Math.Max(minSize + 1, _array.Length * 2);
			Array.Resize(ref _array, newSize);
		}

		public void SetFirstBit()
		{
			_currentDepth++;
			_allocationFreeContainer = 1uL;
		}

		public void ResetFirstBit()
		{
			_currentDepth++;
			_allocationFreeContainer = 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int Div32Rem(int number, out int remainder)
		{
			uint result = (uint)number / 32u;
			remainder = number & 0x1F;
			return (int)result;
		}
	}
	public enum JsonCommentHandling : byte
	{
		Disallow,
		Skip,
		Allow
	}
	internal static class JsonConstants
	{
		public const byte OpenBrace = 123;

		public const byte CloseBrace = 125;

		public const byte OpenBracket = 91;

		public const byte CloseBracket = 93;

		public const byte Space = 32;

		public const byte CarriageReturn = 13;

		public const byte LineFeed = 10;

		public const byte Tab = 9;

		public const byte ListSeparator = 44;

		public const byte KeyValueSeperator = 58;

		public const byte Quote = 34;

		public const byte BackSlash = 92;

		public const byte Slash = 47;

		public const byte BackSpace = 8;

		public const byte FormFeed = 12;

		public const byte Asterisk = 42;

		public const byte Colon = 58;

		public const byte Period = 46;

		public const byte Plus = 43;

		public const byte Hyphen = 45;

		public const byte UtcOffsetToken = 90;

		public const byte TimePrefix = 84;

		public const byte StartingByteOfNonStandardSeparator = 226;

		public const int SpacesPerIndent = 2;

		public const int MaxWriterDepth = 1000;

		public const int RemoveFlagsBitMask = 2147483647;

		public const int StackallocThreshold = 256;

		public const int MaxExpansionFactorWhileEscaping = 6;

		public const int MaxExpansionFactorWhileTranscoding = 3;

		public const int MaxEscapedTokenSize = 1000000000;

		public const int MaxUnescapedTokenSize = 166666666;

		public const int MaxBase64ValueTokenSize = 125000000;

		public const int MaxCharacterTokenSize = 166666666;

		public const int MaximumFormatInt64Length = 20;

		public const int MaximumFormatUInt64Length = 20;

		public const int MaximumFormatDoubleLength = 128;

		public const int MaximumFormatSingleLength = 128;

		public const int MaximumFormatDecimalLength = 31;

		public const int MaximumFormatGuidLength = 36;

		public const int MaximumEscapedGuidLength = 216;

		public const int MaximumFormatDateTimeLength = 27;

		public const int MaximumFormatDateTimeOffsetLength = 33;

		public const int MaxDateTimeUtcOffsetHours = 14;

		public const int DateTimeNumFractionDigits = 7;

		public const int MaxDateTimeFraction = 9999999;

		public const int DateTimeParseNumFractionDigits = 16;

		public const int MaximumDateTimeOffsetParseLength = 42;

		public const int MinimumDateTimeParseLength = 10;

		public const int MaximumEscapedDateTimeOffsetParseLength = 252;

		internal const char ScientificNotationFormat = 'e';

		public const char HighSurrogateStart = '\ud800';

		public const char HighSurrogateEnd = '\udbff';

		public const char LowSurrogateStart = '\udc00';

		public const char LowSurrogateEnd = '\udfff';

		public const int UnicodePlane01StartValue = 65536;

		public const int HighSurrogateStartValue = 55296;

		public const int HighSurrogateEndValue = 56319;

		public const int LowSurrogateStartValue = 56320;

		public const int LowSurrogateEndValue = 57343;

		public const int BitShiftBy10 = 1024;

		public static ReadOnlySpan<byte> Utf8Bom => "\ufeff"u8;

		public static ReadOnlySpan<byte> TrueValue => "true"u8;

		public static ReadOnlySpan<byte> FalseValue => "false"u8;

		public static ReadOnlySpan<byte> NullValue => "null"u8;

		public static ReadOnlySpan<byte> Delimiters => ",}] \n\r\t/"u8;

		public static ReadOnlySpan<byte> EscapableChars => "\"nrt/ubf"u8;
	}
	public readonly struct JsonEncodedText : IEquatable<JsonEncodedText>
	{
		private readonly byte[] _utf8Value;

		private readonly string _value;

		public ReadOnlySpan<byte> EncodedUtf8Bytes => _utf8Value;

		private JsonEncodedText(byte[] utf8Value)
		{
			_value = JsonReaderHelper.GetTextFromUtf8(utf8Value);
			_utf8Value = utf8Value;
		}

		public static JsonEncodedText Encode(string value, JavaScriptEncoder encoder = null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Encode(value.AsSpan(), encoder);
		}

		public static JsonEncodedText Encode(ReadOnlySpan<char> value, JavaScriptEncoder encoder = null)
		{
			if (value.Length == 0)
			{
				return new JsonEncodedText(Array.Empty<byte>());
			}
			return TranscodeAndEncode(value, encoder);
		}

		private static JsonEncodedText TranscodeAndEncode(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
		{
			JsonWriterHelper.ValidateValue(value);
			int utf8ByteCount = JsonReaderHelper.GetUtf8ByteCount(value);
			byte[] array = ArrayPool<byte>.Shared.Rent(utf8ByteCount);
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(value, array);
			JsonEncodedText result = EncodeHelper(array.AsSpan(0, utf8FromText), encoder);
			array.AsSpan(0, utf8ByteCount).Clear();
			ArrayPool<byte>.Shared.Return(array);
			return result;
		}

		public static JsonEncodedText Encode(ReadOnlySpan<byte> utf8Value, JavaScriptEncoder encoder = null)
		{
			if (utf8Value.Length == 0)
			{
				return new JsonEncodedText(Array.Empty<byte>());
			}
			JsonWriterHelper.ValidateValue(utf8Value);
			return EncodeHelper(utf8Value, encoder);
		}

		private static JsonEncodedText EncodeHelper(ReadOnlySpan<byte> utf8Value, JavaScriptEncoder encoder)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8Value, encoder);
			if (num != -1)
			{
				return new JsonEncodedText(GetEscapedString(utf8Value, num, encoder));
			}
			return new JsonEncodedText(utf8Value.ToArray());
		}

		private static byte[] GetEscapedString(ReadOnlySpan<byte> utf8Value, int firstEscapeIndexVal, JavaScriptEncoder encoder)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, firstEscapeIndexVal);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8Value, destination, firstEscapeIndexVal, encoder, out var written);
			byte[] result = destination.Slice(0, written).ToArray();
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		public bool Equals(JsonEncodedText other)
		{
			if (_value == null)
			{
				return other._value == null;
			}
			return _value.Equals(other._value);
		}

		public override bool Equals(object obj)
		{
			if (obj is JsonEncodedText other)
			{
				return Equals(other);
			}
			return false;
		}

		public override string ToString()
		{
			return _value ?? string.Empty;
		}

		public override int GetHashCode()
		{
			if (_value != null)
			{
				return _value.GetHashCode();
			}
			return 0;
		}
	}
	[Serializable]
	public class JsonException : Exception
	{
		private string _message;

		internal bool AppendPathInformation { get; set; }

		public long? LineNumber { get; internal set; }

		public long? BytePositionInLine { get; internal set; }

		public string Path { get; internal set; }

		public override string Message => _message;

		public JsonException(string message, string path, long? lineNumber, long? bytePositionInLine, Exception innerException)
			: base(message, innerException)
		{
			_message = message;
			LineNumber = lineNumber;
			BytePositionInLine = bytePositionInLine;
			Path = path;
		}

		public JsonException(string message, string path, long? lineNumber, long? bytePositionInLine)
			: base(message)
		{
			_message = message;
			LineNumber = lineNumber;
			BytePositionInLine = bytePositionInLine;
			Path = path;
		}

		public JsonException(string message, Exception innerException)
			: base(message, innerException)
		{
			_message = message;
		}

		public JsonException(string message)
			: base(message)
		{
			_message = message;
		}

		public JsonException()
		{
		}

		protected JsonException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			LineNumber = (long?)info.GetValue("LineNumber", typeof(long?));
			BytePositionInLine = (long?)info.GetValue("BytePositionInLine", typeof(long?));
			Path = info.GetString("Path");
			SetMessage(info.GetString("ActualMessage"));
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("LineNumber", LineNumber, typeof(long?));
			info.AddValue("BytePositionInLine", BytePositionInLine, typeof(long?));
			info.AddValue("Path", Path, typeof(string));
			info.AddValue("ActualMessage", Message, typeof(string));
		}

		internal void SetMessage(string message)
		{
			_message = message;
		}
	}
	internal static class JsonHelpers
	{
		private struct DateTimeParseData
		{
			public int Year;

			public int Month;

			public int Day;

			public int Hour;

			public int Minute;

			public int Second;

			public int Fraction;

			public int OffsetHours;

			public int OffsetMinutes;

			public byte OffsetToken;

			public bool OffsetNegative => OffsetToken == 45;
		}

		private static readonly int[] s_daysToMonth365 = new int[13]
		{
			0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
			304, 334, 365
		};

		private static readonly int[] s_daysToMonth366 = new int[13]
		{
			0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
			305, 335, 366
		};

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValidUnicodeScalar(uint value)
		{
			return IsInRangeInclusive(value ^ 0xD800, 2048u, 1114111u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRangeInclusive(uint value, uint lowerBound, uint upperBound)
		{
			return value - lowerBound <= upperBound - lowerBound;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRangeInclusive(int value, int lowerBound, int upperBound)
		{
			return (uint)(value - lowerBound) <= (uint)(upperBound - lowerBound);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRangeInclusive(long value, long lowerBound, long upperBound)
		{
			return (ulong)(value - lowerBound) <= (ulong)(upperBound - lowerBound);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRangeInclusive(JsonTokenType value, JsonTokenType lowerBound, JsonTokenType upperBound)
		{
			return value - lowerBound <= upperBound - lowerBound;
		}

		public static bool IsDigit(byte value)
		{
			return (uint)(value - 48) <= 9u;
		}

		internal static string Utf8GetString(ReadOnlySpan<byte> bytes)
		{
			return Encoding.UTF8.GetString(bytes.ToArray());
		}

		internal static bool TryAdd<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = value;
				return true;
			}
			return false;
		}

		public static bool TryParseAsISO(ReadOnlySpan<byte> source, out DateTime value)
		{
			if (!TryParseDateTimeOffset(source, out var parseData))
			{
				value = default(DateTime);
				return false;
			}
			if (parseData.OffsetToken == 90)
			{
				return TryCreateDateTime(parseData, DateTimeKind.Utc, out value);
			}
			if (parseData.OffsetToken == 43 || parseData.OffsetToken == 45)
			{
				if (!TryCreateDateTimeOffset(ref parseData, out var value2))
				{
					value = default(DateTime);
					return false;
				}
				value = value2.LocalDateTime;
				return true;
			}
			return TryCreateDateTime(parseData, DateTimeKind.Unspecified, out value);
		}

		public static bool TryParseAsISO(ReadOnlySpan<byte> source, out DateTimeOffset value)
		{
			if (!TryParseDateTimeOffset(source, out var parseData))
			{
				value = default(DateTimeOffset);
				return false;
			}
			if (parseData.OffsetToken == 90 || parseData.OffsetToken == 43 || parseData.OffsetToken == 45)
			{
				return TryCreateDateTimeOffset(ref parseData, out value);
			}
			return TryCreateDateTimeOffsetInterpretingDataAsLocalTime(parseData, out value);
		}

		private static bool TryParseDateTimeOffset(ReadOnlySpan<byte> source, out DateTimeParseData parseData)
		{
			if (source.Length < 10)
			{
				parseData = default(DateTimeParseData);
				return false;
			}
			parseData = default(DateTimeParseData);
			uint num = (uint)(source[0] - 48);
			uint num2 = (uint)(source[1] - 48);
			uint num3 = (uint)(source[2] - 48);
			uint num4 = (uint)(source[3] - 48);
			if (num > 9 || num2 > 9 || num3 > 9 || num4 > 9)
			{
				return false;
			}
			parseData.Year = (int)(num * 1000 + num2 * 100 + num3 * 10 + num4);
			if (source[4] != 45 || !TryGetNextTwoDigits(source.Slice(5, 2), ref parseData.Month) || source[7] != 45 || !TryGetNextTwoDigits(source.Slice(8, 2), ref parseData.Day))
			{
				return false;
			}
			if (source.Length == 10)
			{
				return true;
			}
			if (source.Length < 16)
			{
				return false;
			}
			if (source[10] != 84 || source[13] != 58 || !TryGetNextTwoDigits(source.Slice(11, 2), ref parseData.Hour) || !TryGetNextTwoDigits(source.Slice(14, 2), ref parseData.Minute))
			{
				return false;
			}
			if (source.Length == 16)
			{
				return true;
			}
			byte b = source[16];
			int num5 = 17;
			switch (b)
			{
			case 90:
				parseData.OffsetToken = 90;
				return num5 == source.Length;
			case 43:
			case 45:
				parseData.OffsetToken = b;
				return ParseOffset(ref parseData, source.Slice(num5));
			default:
				return false;
			case 58:
				if (source.Length < 19 || !TryGetNextTwoDigits(source.Slice(17, 2), ref parseData.Second))
				{
					return false;
				}
				if (source.Length == 19)
				{
					return true;
				}
				b = source[19];
				num5 = 20;
				switch (b)
				{
				case 90:
					parseData.OffsetToken = 90;
					return num5 == source.Length;
				case 43:
				case 45:
					parseData.OffsetToken = b;
					return ParseOffset(ref parseData, source.Slice(num5));
				default:
					return false;
				case 46:
				{
					if (source.Length < 21)
					{
						return false;
					}
					int i = 0;
					for (int num6 = Math.Min(num5 + 16, source.Length); num5 < num6; num5++)
					{
						if (!IsDigit(b = source[num5]))
						{
							break;
						}
						if (i < 7)
						{
							parseData.Fraction = parseData.Fraction * 10 + (b - 48);
							i++;
						}
					}
					if (parseData.Fraction != 0)
					{
						for (; i < 7; i++)
						{
							parseData.Fraction *= 10;
						}
					}
					if (num5 == source.Length)
					{
						return true;
					}
					b = source[num5++];
					switch (b)
					{
					case 90:
						parseData.OffsetToken = 90;
						return num5 == source.Length;
					case 43:
					case 45:
						parseData.OffsetToken = b;
						return ParseOffset(ref parseData, source.Slice(num5));
					default:
						return false;
					}
				}
				}
			}
			static bool ParseOffset(ref DateTimeParseData reference, ReadOnlySpan<byte> offsetData)
			{
				if (offsetData.Length < 2 || !TryGetNextTwoDigits(offsetData.Slice(0, 2), ref reference.OffsetHours))
				{
					return false;
				}
				if (offsetData.Length == 2)
				{
					return true;
				}
				if (offsetData.Length != 5 || offsetData[2] != 58 || !TryGetNextTwoDigits(offsetData.Slice(3), ref reference.OffsetMinutes))
				{
					return false;
				}
				return true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool TryGetNextTwoDigits(ReadOnlySpan<byte> source, ref int value)
		{
			uint num = (uint)(source[0] - 48);
			uint num2 = (uint)(source[1] - 48);
			if (num > 9 || num2 > 9)
			{
				value = 0;
				return false;
			}
			value = (int)(num * 10 + num2);
			return true;
		}

		private static bool TryCreateDateTimeOffset(DateTime dateTime, ref DateTimeParseData parseData, out DateTimeOffset value)
		{
			if ((uint)parseData.OffsetHours > 14u)
			{
				value = default(DateTimeOffset);
				return false;
			}
			if ((uint)parseData.OffsetMinutes > 59u)
			{
				value = default(DateTimeOffset);
				return false;
			}
			if (parseData.OffsetHours == 14 && parseData.OffsetMinutes != 0)
			{
				value = default(DateTimeOffset);
				return false;
			}
			long num = ((long)parseData.OffsetHours * 3600L + (long)parseData.OffsetMinutes * 60L) * 10000000;
			if (parseData.OffsetNegative)
			{
				num = -num;
			}
			try
			{
				value = new DateTimeOffset(dateTime.Ticks, new TimeSpan(num));
			}
			catch (ArgumentOutOfRangeException)
			{
				value = default(DateTimeOffset);
				return false;
			}
			return true;
		}

		private static bool TryCreateDateTimeOffset(ref DateTimeParseData parseData, out DateTimeOffset value)
		{
			if (!TryCreateDateTime(parseData, DateTimeKind.Unspecified, out var value2))
			{
				value = default(DateTimeOffset);
				return false;
			}
			if (!TryCreateDateTimeOffset(value2, ref parseData, out value))
			{
				value = default(DateTimeOffset);
				return false;
			}
			return true;
		}

		private static bool TryCreateDateTimeOffsetInterpretingDataAsLocalTime(DateTimeParseData parseData, out DateTimeOffset value)
		{
			if (!TryCreateDateTime(parseData, DateTimeKind.Local, out var value2))
			{
				value = default(DateTimeOffset);
				return false;
			}
			try
			{
				value = new DateTimeOffset(value2);
			}
			catch (ArgumentOutOfRangeException)
			{
				value = default(DateTimeOffset);
				return false;
			}
			return true;
		}

		private static bool TryCreateDateTime(DateTimeParseData parseData, DateTimeKind kind, out DateTime value)
		{
			if (parseData.Year == 0)
			{
				value = default(DateTime);
				return false;
			}
			if ((uint)(parseData.Month - 1) >= 12u)
			{
				value = default(DateTime);
				return false;
			}
			uint num = (uint)(parseData.Day - 1);
			if (num >= 28 && num >= DateTime.DaysInMonth(parseData.Year, parseData.Month))
			{
				value = default(DateTime);
				return false;
			}
			if ((uint)parseData.Hour > 23u)
			{
				value = default(DateTime);
				return false;
			}
			if ((uint)parseData.Minute > 59u)
			{
				value = default(DateTime);
				return false;
			}
			if ((uint)parseData.Second > 59u)
			{
				value = default(DateTime);
				return false;
			}
			int[] array = (DateTime.IsLeapYear(parseData.Year) ? s_daysToMonth366 : s_daysToMonth365);
			int num2 = parseData.Year - 1;
			int num3 = num2 * 365 + num2 / 4 - num2 / 100 + num2 / 400 + array[parseData.Month - 1] + parseData.Day - 1;
			long num4 = num3 * 864000000000L;
			int num5 = parseData.Hour * 3600 + parseData.Minute * 60 + parseData.Second;
			num4 += (long)num5 * 10000000L;
			num4 += parseData.Fraction;
			value = new DateTime(num4, kind);
			return true;
		}
	}
	public enum JsonTokenType : byte
	{
		None,
		StartObject,
		EndObject,
		StartArray,
		EndArray,
		PropertyName,
		Comment,
		String,
		Number,
		True,
		False,
		Null
	}
	internal static class ThrowHelper
	{
		public const string ExceptionSourceValueToRethrowAsJsonException = "System.Text.Json.Rethrowable";

		public static ArgumentOutOfRangeException GetArgumentOutOfRangeException_MaxDepthMustBePositive(string parameterName)
		{
			return GetArgumentOutOfRangeException(parameterName, SR.MaxDepthMustBePositive);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(string parameterName, string message)
		{
			return new ArgumentOutOfRangeException(parameterName, message);
		}

		public static ArgumentOutOfRangeException GetArgumentOutOfRangeException_CommentEnumMustBeInRange(string parameterName)
		{
			return GetArgumentOutOfRangeException(parameterName, SR.CommentHandlingMustBeValid);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ArgumentException GetArgumentException(string message)
		{
			return new ArgumentException(message);
		}

		public static void ThrowArgumentException(string message)
		{
			throw GetArgumentException(message);
		}

		public static InvalidOperationException GetInvalidOperationException_CallFlushFirst(int _buffered)
		{
			return GetInvalidOperationException(SR.Format(SR.CallFlushToAvoidDataLoss, _buffered));
		}

		public static void ThrowArgumentException_PropertyNameTooLarge(int tokenLength)
		{
			throw GetArgumentException(SR.Format(SR.PropertyNameTooLarge, tokenLength));
		}

		public static void ThrowArgumentException_ValueTooLarge(int tokenLength)
		{
			throw GetArgumentException(SR.Format(SR.ValueTooLarge, tokenLength));
		}

		public static void ThrowArgumentException_ValueNotSupported()
		{
			throw GetArgumentException(SR.SpecialNumberValuesNotSupported);
		}

		public static void ThrowInvalidOperationException_NeedLargerSpan()
		{
			throw GetInvalidOperationException(SR.FailedToGetLargerSpan);
		}

		public static void ThrowArgumentException(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.ValueTooLarge, value.Length));
			}
		}

		public static void ThrowArgumentException(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.ValueTooLarge, value.Length));
			}
		}

		public static void ThrowArgumentException(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.ValueTooLarge, value.Length));
			}
		}

		public static void ThrowArgumentException(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.ValueTooLarge, value.Length));
			}
		}

		public static void ThrowInvalidOperationOrArgumentException(ReadOnlySpan<byte> propertyName, int currentDepth)
		{
			currentDepth &= 0x7FFFFFFF;
			if (currentDepth >= 1000)
			{
				ThrowInvalidOperationException(SR.Format(SR.DepthTooLarge, currentDepth, 1000));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
		}

		public static void ThrowInvalidOperationException(int currentDepth)
		{
			currentDepth &= 0x7FFFFFFF;
			ThrowInvalidOperationException(SR.Format(SR.DepthTooLarge, currentDepth, 1000));
		}

		public static void ThrowInvalidOperationException(string message)
		{
			throw GetInvalidOperationException(message);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static InvalidOperationException GetInvalidOperationException(string message)
		{
			InvalidOperationException ex = new InvalidOperationException(message);
			ex.Source = "System.Text.Json.Rethrowable";
			return ex;
		}

		public static void ThrowInvalidOperationException_DepthNonZeroOrEmptyJson(int currentDepth)
		{
			throw GetInvalidOperationException(currentDepth);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static InvalidOperationException GetInvalidOperationException(int currentDepth)
		{
			currentDepth &= 0x7FFFFFFF;
			if (currentDepth != 0)
			{
				return GetInvalidOperationException(SR.Format(SR.ZeroDepthAtEnd, currentDepth));
			}
			return GetInvalidOperationException(SR.EmptyJsonIsInvalid);
		}

		public static void ThrowInvalidOperationOrArgumentException(ReadOnlySpan<char> propertyName, int currentDepth)
		{
			currentDepth &= 0x7FFFFFFF;
			if (currentDepth >= 1000)
			{
				ThrowInvalidOperationException(SR.Format(SR.DepthTooLarge, currentDepth, 1000));
			}
			else
			{
				ThrowArgumentException(SR.Format(SR.PropertyNameTooLarge, propertyName.Length));
			}
		}

		public static InvalidOperationException GetInvalidOperationException_ExpectedNumber(JsonTokenType tokenType)
		{
			return GetInvalidOperationException("number", tokenType);
		}

		public static InvalidOperationException GetInvalidOperationException_ExpectedBoolean(JsonTokenType tokenType)
		{
			return GetInvalidOperationException("boolean", tokenType);
		}

		public static InvalidOperationException GetInvalidOperationException_ExpectedString(JsonTokenType tokenType)
		{
			return GetInvalidOperationException("string", tokenType);
		}

		public static InvalidOperationException GetInvalidOperationException_ExpectedStringComparison(JsonTokenType tokenType)
		{
			return GetInvalidOperationException(tokenType);
		}

		public static InvalidOperationException GetInvalidOperationException_ExpectedComment(JsonTokenType tokenType)
		{
			return GetInvalidOperationException("comment", tokenType);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static InvalidOperationException GetInvalidOperationException_CannotSkipOnPartial()
		{
			return GetInvalidOperationException(SR.CannotSkip);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static InvalidOperationException GetInvalidOperationException(string message, JsonTokenType tokenType)
		{
			return GetInvalidOperationException(SR.Format(SR.InvalidCast, tokenType, message));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static InvalidOperationException GetInvalidOperationException(JsonTokenType tokenType)
		{
			return GetInvalidOperationException(SR.Format(SR.InvalidComparison, tokenType));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static InvalidOperationException GetJsonElementWrongTypeException(JsonTokenType expectedType, JsonTokenType actualType)
		{
			return GetInvalidOperationException(SR.Format(SR.JsonElementHasWrongType, expectedType.ToValueKind(), actualType.ToValueKind()));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static InvalidOperationException GetJsonElementWrongTypeException(string expectedTypeName, JsonTokenType actualType)
		{
			return GetInvalidOperationException(SR.Format(SR.JsonElementHasWrongType, expectedTypeName, actualType.ToValueKind()));
		}

		public static void ThrowJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte = 0, ReadOnlySpan<byte> bytes = default(ReadOnlySpan<byte>))
		{
			throw GetJsonReaderException(ref json, resource, nextByte, bytes);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static JsonException GetJsonReaderException(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, ReadOnlySpan<byte> bytes)
		{
			string resourceString = GetResourceString(ref json, resource, nextByte, JsonHelpers.Utf8GetString(bytes));
			long lineNumber = json.CurrentState._lineNumber;
			long bytePositionInLine = json.CurrentState._bytePositionInLine;
			resourceString += $" LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
			return new JsonReaderException(resourceString, lineNumber, bytePositionInLine);
		}

		private static bool IsPrintable(byte value)
		{
			if (value >= 32)
			{
				return value < 127;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static string GetPrintableString(byte value)
		{
			if (!IsPrintable(value))
			{
				return $"0x{value:X2}";
			}
			char c = (char)value;
			return c.ToString();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string GetResourceString(ref Utf8JsonReader json, ExceptionResource resource, byte nextByte, string characters)
		{
			string printableString = GetPrintableString(nextByte);
			string result = "";
			switch (resource)
			{
			case ExceptionResource.ArrayDepthTooLarge:
				result = SR.Format(SR.ArrayDepthTooLarge, json.CurrentState.Options.MaxDepth);
				break;
			case ExceptionResource.MismatchedObjectArray:
				result = SR.Format(SR.MismatchedObjectArray, printableString);
				break;
			case ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd:
				result = SR.TrailingCommaNotAllowedBeforeArrayEnd;
				break;
			case ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd:
				result = SR.TrailingCommaNotAllowedBeforeObjectEnd;
				break;
			case ExceptionResource.EndOfStringNotFound:
				result = SR.EndOfStringNotFound;
				break;
			case ExceptionResource.RequiredDigitNotFoundAfterSign:
				result = SR.Format(SR.RequiredDigitNotFoundAfterSign, printableString);
				break;
			case ExceptionResource.RequiredDigitNotFoundAfterDecimal:
				result = SR.Format(SR.RequiredDigitNotFoundAfterDecimal, printableString);
				break;
			case ExceptionResource.RequiredDigitNotFoundEndOfData:
				result = SR.RequiredDigitNotFoundEndOfData;
				break;
			case ExceptionResource.ExpectedEndAfterSingleJson:
				result = SR.Format(SR.ExpectedEndAfterSingleJson, printableString);
				break;
			case ExceptionResource.ExpectedEndOfDigitNotFound:
				result = SR.Format(SR.ExpectedEndOfDigitNotFound, printableString);
				break;
			case ExceptionResource.ExpectedNextDigitEValueNotFound:
				result = SR.Format(SR.ExpectedNextDigitEValueNotFound, printableString);
				break;
			case ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound:
				result = SR.Format(SR.ExpectedSeparatorAfterPropertyNameNotFound, printableString);
				break;
			case ExceptionResource.ExpectedStartOfPropertyNotFound:
				result = SR.Format(SR.ExpectedStartOfPropertyNotFound, printableString);
				break;
			case ExceptionResource.ExpectedStartOfPropertyOrValueNotFound:
				result = SR.ExpectedStartOfPropertyOrValueNotFound;
				break;
			case ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment:
				result = SR.Format(SR.ExpectedStartOfPropertyOrValueAfterComment, printableString);
				break;
			case ExceptionResource.ExpectedStartOfValueNotFound:
				result = SR.Format(SR.ExpectedStartOfValueNotFound, printableString);
				break;
			case ExceptionResource.ExpectedValueAfterPropertyNameNotFound:
				result = SR.ExpectedValueAfterPropertyNameNotFound;
				break;
			case ExceptionResource.FoundInvalidCharacter:
				result = SR.Format(SR.FoundInvalidCharacter, printableString);
				break;
			case ExceptionResource.InvalidEndOfJsonNonPrimitive:
				result = SR.Format(SR.InvalidEndOfJsonNonPrimitive, json.TokenType);
				break;
			case ExceptionResource.ObjectDepthTooLarge:
				result = SR.Format(SR.ObjectDepthTooLarge, json.CurrentState.Options.MaxDepth);
				break;
			case ExceptionResource.ExpectedFalse:
				result = SR.Format(SR.ExpectedFalse, characters);
				break;
			case ExceptionResource.ExpectedNull:
				result = SR.Format(SR.ExpectedNull, characters);
				break;
			case ExceptionResource.ExpectedTrue:
				result = SR.Format(SR.ExpectedTrue, characters);
				break;
			case ExceptionResource.InvalidCharacterWithinString:
				result = SR.Format(SR.InvalidCharacterWithinString, printableString);
				break;
			case ExceptionResource.InvalidCharacterAfterEscapeWithinString:
				result = SR.Format(SR.InvalidCharacterAfterEscapeWithinString, printableString);
				break;
			case ExceptionResource.InvalidHexCharacterWithinString:
				result = SR.Format(SR.InvalidHexCharacterWithinString, printableString);
				break;
			case ExceptionResource.EndOfCommentNotFound:
				result = SR.EndOfCommentNotFound;
				break;
			case ExceptionResource.ZeroDepthAtEnd:
				result = SR.Format(SR.ZeroDepthAtEnd);
				break;
			case ExceptionResource.ExpectedJsonTokens:
				result = SR.ExpectedJsonTokens;
				break;
			case ExceptionResource.NotEnoughData:
				result = SR.NotEnoughData;
				break;
			case ExceptionResource.ExpectedOneCompleteToken:
				result = SR.ExpectedOneCompleteToken;
				break;
			case ExceptionResource.InvalidCharacterAtStartOfComment:
				result = SR.Format(SR.InvalidCharacterAtStartOfComment, printableString);
				break;
			case ExceptionResource.UnexpectedEndOfDataWhileReadingComment:
				result = SR.Format(SR.UnexpectedEndOfDataWhileReadingComment);
				break;
			case ExceptionResource.UnexpectedEndOfLineSeparator:
				result = SR.Format(SR.UnexpectedEndOfLineSeparator);
				break;
			}
			return result;
		}

		public static void ThrowInvalidOperationException(ExceptionResource resource, int currentDepth, byte token, JsonTokenType tokenType)
		{
			throw GetInvalidOperationException(resource, currentDepth, token, tokenType);
		}

		public static void ThrowArgumentException_InvalidCommentValue()
		{
			throw new ArgumentException(SR.CannotWriteCommentWithEmbeddedDelimiter);
		}

		public static void ThrowArgumentException_InvalidUTF8(ReadOnlySpan<byte> value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = Math.Min(value.Length, 10);
			for (int i = 0; i < num; i++)
			{
				byte b = value[i];
				if (IsPrintable(b))
				{
					stringBuilder.Append((char)b);
				}
				else
				{
					stringBuilder.Append($"0x{b:X2}");
				}
			}
			if (num < value.Length)
			{
				stringBuilder.Append("...");
			}
			throw new ArgumentException(SR.Format(SR.CannotEncodeInvalidUTF8, stringBuilder));
		}

		public static void ThrowArgumentException_InvalidUTF16(int charAsInt)
		{
			throw new ArgumentException(SR.Format(SR.CannotEncodeInvalidUTF16, $"0x{charAsInt:X2}"));
		}

		public static void ThrowInvalidOperationException_ReadInvalidUTF16(int charAsInt)
		{
			throw GetInvalidOperationException(SR.Format(SR.CannotReadInvalidUTF16, $"0x{charAsInt:X2}"));
		}

		public static void ThrowInvalidOperationException_ReadInvalidUTF16()
		{
			throw GetInvalidOperationException(SR.CannotReadIncompleteUTF16);
		}

		public static InvalidOperationException GetInvalidOperationException_ReadInvalidUTF8(DecoderFallbackException innerException)
		{
			return GetInvalidOperationException(SR.CannotTranscodeInvalidUtf8, innerException);
		}

		public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException innerException)
		{
			return new ArgumentException(SR.CannotTranscodeInvalidUtf16, innerException);
		}

		public static InvalidOperationException GetInvalidOperationException(string message, Exception innerException)
		{
			InvalidOperationException ex = new InvalidOperationException(message, innerException);
			ex.Source = "System.Text.Json.Rethrowable";
			return ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static InvalidOperationException GetInvalidOperationException(ExceptionResource resource, int currentDepth, byte token, JsonTokenType tokenType)
		{
			string resourceString = GetResourceString(resource, currentDepth, token, tokenType);
			InvalidOperationException invalidOperationException = GetInvalidOperationException(resourceString);
			invalidOperationException.Source = "System.Text.Json.Rethrowable";
			return invalidOperationException;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string GetResourceString(ExceptionResource resource, int currentDepth, byte token, JsonTokenType tokenType)
		{
			string result = "";
			switch (resource)
			{
			case ExceptionResource.MismatchedObjectArray:
				result = ((tokenType == JsonTokenType.PropertyName) ? SR.Format(SR.CannotWriteEndAfterProperty, (char)token) : SR.Format(SR.MismatchedObjectArray, (char)token));
				break;
			case ExceptionResource.DepthTooLarge:
				result = SR.Format(SR.DepthTooLarge, currentDepth & 0x7FFFFFFF, 1000);
				break;
			case ExceptionResource.CannotStartObjectArrayWithoutProperty:
				result = SR.Format(SR.CannotStartObjectArrayWithoutProperty, tokenType);
				break;
			case ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose:
				result = SR.Format(SR.CannotStartObjectArrayAfterPrimitiveOrClose, tokenType);
				break;
			case ExceptionResource.CannotWriteValueWithinObject:
				result = SR.Format(SR.CannotWriteValueWithinObject, tokenType);
				break;
			case ExceptionResource.CannotWritePropertyWithinArray:
				result = ((tokenType == JsonTokenType.PropertyName) ? SR.Format(SR.CannotWritePropertyAfterProperty) : SR.Format(SR.CannotWritePropertyWithinArray, tokenType));
				break;
			case ExceptionResource.CannotWriteValueAfterPrimitiveOrClose:
				result = SR.Format(SR.CannotWriteValueAfterPrimitiveOrClose, tokenType);
				break;
			}
			return result;
		}

		public static FormatException GetFormatException()
		{
			FormatException ex = new FormatException();
			ex.Source = "System.Text.Json.Rethrowable";
			return ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FormatException GetFormatException(NumericType numericType)
		{
			string message = "";
			switch (numericType)
			{
			case NumericType.Byte:
				message = SR.FormatByte;
				break;
			case NumericType.SByte:
				message = SR.FormatSByte;
				break;
			case NumericType.Int16:
				message = SR.FormatInt16;
				break;
			case NumericType.Int32:
				message = SR.FormatInt32;
				break;
			case NumericType.Int64:
				message = SR.FormatInt64;
				break;
			case NumericType.UInt16:
				message = SR.FormatUInt16;
				break;
			case NumericType.UInt32:
				message = SR.FormatUInt32;
				break;
			case NumericType.UInt64:
				message = SR.FormatUInt64;
				break;
			case NumericType.Single:
				message = SR.FormatSingle;
				break;
			case NumericType.Double:
				message = SR.FormatDouble;
				break;
			case NumericType.Decimal:
				message = SR.FormatDecimal;
				break;
			}
			FormatException ex = new FormatException(message);
			ex.Source = "System.Text.Json.Rethrowable";
			return ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FormatException GetFormatException(DataType dateType)
		{
			string message = "";
			switch (dateType)
			{
			case DataType.DateTime:
				message = SR.FormatDateTime;
				break;
			case DataType.DateTimeOffset:
				message = SR.FormatDateTimeOffset;
				break;
			case DataType.Base64String:
				message = SR.CannotDecodeInvalidBase64;
				break;
			case DataType.Guid:
				message = SR.FormatGuid;
				break;
			}
			FormatException ex = new FormatException(message);
			ex.Source = "System.Text.Json.Rethrowable";
			return ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowArgumentException_DeserializeWrongType(Type type, object value)
		{
			throw new ArgumentException(SR.Format(SR.DeserializeWrongType, type, value.GetType()));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static NotSupportedException GetNotSupportedException_SerializationNotSupportedCollection(Type propertyType, Type parentType, MemberInfo memberInfo)
		{
			if (parentType != null && parentType != typeof(object) && memberInfo != null)
			{
				return new NotSupportedException(SR.Format(SR.SerializationNotSupportedCollection, propertyType, $"{parentType}.{memberInfo.Name}"));
			}
			return new NotSupportedException(SR.Format(SR.SerializationNotSupportedCollectionType, propertyType));
		}

		public static void ThrowInvalidOperationException_SerializerCycleDetected(int maxDepth)
		{
			throw new JsonException(SR.Format(SR.SerializerCycleDetected, maxDepth));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException_DeserializeUnableToConvertValue(Type propertyType)
		{
			JsonException ex = new JsonException(SR.Format(SR.DeserializeUnableToConvertValue, propertyType));
			ex.AppendPathInformation = true;
			throw ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException_DeserializeUnableToConvertValue(Type propertyType, string path, Exception innerException = null)
		{
			string message = SR.Format(SR.DeserializeUnableToConvertValue, propertyType) + " Path: " + path + ".";
			throw new JsonException(message, path, null, null, innerException);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException_DepthTooLarge(int currentDepth, JsonSerializerOptions options)
		{
			throw new JsonException(SR.Format(SR.DepthTooLarge, currentDepth, options.EffectiveMaxDepth));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException_SerializationConverterRead(JsonConverter converter)
		{
			JsonException ex = new JsonException(SR.Format(SR.SerializationConverterRead, converter));
			ex.AppendPathInformation = true;
			throw ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException_SerializationConverterWrite(JsonConverter converter)
		{
			JsonException ex = new JsonException(SR.Format(SR.SerializationConverterWrite, converter));
			ex.AppendPathInformation = true;
			throw ex;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowJsonException()
		{
			throw new JsonException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationConverterNotCompatible(Type converterType, Type type)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializationConverterNotCompatible, converterType, type));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationConverterOnAttributeInvalid(Type classType, PropertyInfo propertyInfo)
		{
			string text = classType.ToString();
			if (propertyInfo != null)
			{
				text = text + "." + propertyInfo.Name;
			}
			throw new InvalidOperationException(SR.Format(SR.SerializationConverterOnAttributeInvalid, text));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(Type classTypeAttributeIsOn, PropertyInfo propertyInfo, Type typeToConvert)
		{
			string text = classTypeAttributeIsOn.ToString();
			if (propertyInfo != null)
			{
				text = text + "." + propertyInfo.Name;
			}
			throw new InvalidOperationException(SR.Format(SR.SerializationConverterOnAttributeNotCompatible, text, typeToConvert));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializerOptionsImmutable()
		{
			throw new InvalidOperationException(SR.SerializerOptionsImmutable);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializerPropertyNameConflict(JsonClassInfo jsonClassInfo, JsonPropertyInfo jsonPropertyInfo)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializerPropertyNameConflict, jsonClassInfo.Type, jsonPropertyInfo.PropertyInfo.Name));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializerPropertyNameNull(Type parentType, JsonPropertyInfo jsonPropertyInfo)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializerPropertyNameNull, parentType, jsonPropertyInfo.PropertyInfo.Name));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializerDictionaryKeyNull(Type policyType)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializerDictionaryKeyNull, policyType));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ReThrowWithPath(in ReadStack readStack, JsonReaderException ex)
		{
			string text = readStack.JsonPath();
			string message = ex.Message;
			int num = message.LastIndexOf(" LineNumber: ", StringComparison.InvariantCulture);
			message = ((num < 0) ? (message + " Path: " + text + ".") : (message.Substring(0, num) + " Path: " + text + " |" + message.Substring(num)));
			throw new JsonException(message, text, ex.LineNumber, ex.BytePositionInLine, ex);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ReThrowWithPath(in ReadStack readStack, in Utf8JsonReader reader, Exception ex)
		{
			JsonException ex2 = new JsonException(null, ex);
			AddExceptionInformation(in readStack, in reader, ex2);
			throw ex2;
		}

		public static void AddExceptionInformation(in ReadStack readStack, in Utf8JsonReader reader, JsonException ex)
		{
			long lineNumber = reader.CurrentState._lineNumber;
			ex.LineNumber = lineNumber;
			long bytePositionInLine = reader.CurrentState._bytePositionInLine;
			ex.BytePositionInLine = bytePositionInLine;
			string arg = (ex.Path = readStack.JsonPath());
			string text2 = ex.Message;
			if (string.IsNullOrEmpty(text2))
			{
				Type type = readStack.Current.JsonPropertyInfo?.RuntimePropertyType;
				if (type == null)
				{
					type = readStack.Current.JsonClassInfo.Type;
				}
				text2 = SR.Format(SR.DeserializeUnableToConvertValue, type);
				ex.AppendPathInformation = true;
			}
			if (ex.AppendPathInformation)
			{
				text2 += $" Path: {arg} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
				ex.SetMessage(text2);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ReThrowWithPath(in WriteStack writeStack, Exception ex)
		{
			JsonException ex2 = new JsonException(null, ex);
			AddExceptionInformation(in writeStack, ex2);
			throw ex2;
		}

		public static void AddExceptionInformation(in WriteStack writeStack, JsonException ex)
		{
			string text = (ex.Path = writeStack.PropertyPath());
			string text3 = ex.Message;
			if (string.IsNullOrEmpty(text3))
			{
				text3 = SR.Format(SR.SerializeUnableToSerialize);
				ex.AppendPathInformation = true;
			}
			if (ex.AppendPathInformation)
			{
				text3 = text3 + " Path: " + text + ".";
				ex.SetMessage(text3);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationDuplicateAttribute(Type attribute, Type classType, PropertyInfo propertyInfo)
		{
			string text = classType.ToString();
			if (propertyInfo != null)
			{
				text = text + "." + propertyInfo.Name;
			}
			throw new InvalidOperationException(SR.Format(SR.SerializationDuplicateAttribute, attribute, text));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type classType, Type attribute)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializationDuplicateTypeAttribute, classType, attribute));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(JsonClassInfo jsonClassInfo, JsonPropertyInfo jsonPropertyInfo)
		{
			throw new InvalidOperationException(SR.Format(SR.SerializationDataExtensionPropertyInvalid, jsonClassInfo.Type, jsonPropertyInfo.PropertyInfo.Name));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowNotSupportedException_DeserializeCreateObjectDelegateIsNull(Type invalidType)
		{
			if (invalidType.IsInterface)
			{
				throw new NotSupportedException(SR.Format(SR.DeserializePolymorphicInterface, invalidType));
			}
			throw new NotSupportedException(SR.Format(SR.DeserializeMissingParameterlessConstructor, invalidType));
		}
	}
	internal enum ExceptionResource
	{
		ArrayDepthTooLarge,
		EndOfCommentNotFound,
		EndOfStringNotFound,
		RequiredDigitNotFoundAfterDecimal,
		RequiredDigitNotFoundAfterSign,
		RequiredDigitNotFoundEndOfData,
		ExpectedEndAfterSingleJson,
		ExpectedEndOfDigitNotFound,
		ExpectedFalse,
		ExpectedNextDigitEValueNotFound,
		ExpectedNull,
		ExpectedSeparatorAfterPropertyNameNotFound,
		ExpectedStartOfPropertyNotFound,
		ExpectedStartOfPropertyOrValueNotFound,
		ExpectedStartOfPropertyOrValueAfterComment,
		ExpectedStartOfValueNotFound,
		ExpectedTrue,
		ExpectedValueAfterPropertyNameNotFound,
		FoundInvalidCharacter,
		InvalidCharacterWithinString,
		InvalidCharacterAfterEscapeWithinString,
		InvalidHexCharacterWithinString,
		InvalidEndOfJsonNonPrimitive,
		MismatchedObjectArray,
		ObjectDepthTooLarge,
		ZeroDepthAtEnd,
		DepthTooLarge,
		CannotStartObjectArrayWithoutProperty,
		CannotStartObjectArrayAfterPrimitiveOrClose,
		CannotWriteValueWithinObject,
		CannotWriteValueAfterPrimitiveOrClose,
		CannotWritePropertyWithinArray,
		ExpectedJsonTokens,
		TrailingCommaNotAllowedBeforeArrayEnd,
		TrailingCommaNotAllowedBeforeObjectEnd,
		InvalidCharacterAtStartOfComment,
		UnexpectedEndOfDataWhileReadingComment,
		UnexpectedEndOfLineSeparator,
		ExpectedOneCompleteToken,
		NotEnoughData
	}
	internal enum NumericType
	{
		Byte,
		SByte,
		Int16,
		Int32,
		Int64,
		UInt16,
		UInt32,
		UInt64,
		Single,
		Double,
		Decimal
	}
	internal enum DataType
	{
		DateTime,
		DateTimeOffset,
		Base64String,
		Guid
	}
	public sealed class JsonDocument : IDisposable
	{
		internal struct DbRow
		{
			internal const int Size = 12;

			private int _location;

			private int _sizeOrLengthUnion;

			private readonly int _numberOfRowsAndTypeUnion;

			internal const int UnknownSize = -1;

			internal int Location => _location;

			internal int SizeOrLength => _sizeOrLengthUnion & 0x7FFFFFFF;

			internal bool IsUnknownSize => _sizeOrLengthUnion == -1;

			internal bool HasComplexChildren => _sizeOrLengthUnion < 0;

			internal int NumberOfRows => _numberOfRowsAndTypeUnion & 0xFFFFFFF;

			internal JsonTokenType TokenType => (JsonTokenType)((uint)_numberOfRowsAndTypeUnion >> 28);

			internal bool IsSimpleValue => (int)TokenType >= 5;

			internal DbRow(JsonTokenType jsonTokenType, int location, int sizeOrLength)
			{
				_location = location;
				_sizeOrLengthUnion = sizeOrLength;
				_numberOfRowsAndTypeUnion = (int)((uint)jsonTokenType << 28);
			}
		}

		private struct MetadataDb : IDisposable
		{
			private const int SizeOrLengthOffset = 4;

			private const int NumberOfRowsOffset = 8;

			private byte[] _data;

			internal int Length { get; private set; }

			internal MetadataDb(byte[] completeDb)
			{
				_data = completeDb;
				Length = completeDb.Length;
			}

			internal MetadataDb(int payloadLength)
			{
				int num = 12 + payloadLength;
				if (num > 1048576 && num <= 4194304)
				{
					num = 1048576;
				}
				_data = ArrayPool<byte>.Shared.Rent(num);
				Length = 0;
			}

			internal MetadataDb(MetadataDb source, bool useArrayPools)
			{
				Length = source.Length;
				if (useArrayPools)
				{
					_data = ArrayPool<byte>.Shared.Rent(Length);
					source._data.AsSpan(0, Length).CopyTo(_data);
				}
				else
				{
					_data = source._data.AsSpan(0, Length).ToArray();
				}
			}

			public void Dispose()
			{
				byte[] array = Interlocked.Exchange(ref _data, null);
				if (array != null)
				{
					ArrayPool<byte>.Shared.Return(array);
					Length = 0;
				}
			}

			internal void TrimExcess()
			{
				if (Length <= _data.Length / 2)
				{
					byte[] array = ArrayPool<byte>.Shared.Rent(Length);
					byte[] array2 = array;
					if (array.Length < _data.Length)
					{
						Buffer.BlockCopy(_data, 0, array, 0, Length);
						array2 = _data;
						_data = array;
					}
					ArrayPool<byte>.Shared.Return(array2);
				}
			}

			internal void Append(JsonTokenType tokenType, int startLocation, int length)
			{
				if (Length >= _data.Length - 12)
				{
					Enlarge();
				}
				DbRow value = new DbRow(tokenType, startLocation, length);
				MemoryMarshal.Write(_data.AsSpan(Length), ref value);
				Length += 12;
			}

			private void Enlarge()
			{
				byte[] data = _data;
				_data = ArrayPool<byte>.Shared.Rent(data.Length * 2);
				Buffer.BlockCopy(data, 0, _data, 0, data.Length);
				ArrayPool<byte>.Shared.Return(data);
			}

			[Conditional("DEBUG")]
			private void AssertValidIndex(int index)
			{
			}

			internal void SetLength(int index, int length)
			{
				Span<byte> destination = _data.AsSpan(index + 4);
				MemoryMarshal.Write(destination, ref length);
			}

			internal void SetNumberOfRows(int index, int numberOfRows)
			{
				Span<byte> span = _data.AsSpan(index + 8);
				int num = MemoryMarshal.Read<int>(span);
				int value = (num & -268435456) | numberOfRows;
				MemoryMarshal.Write(span, ref value);
			}

			internal void SetHasComplexChildren(int index)
			{
				Span<byte> span = _data.AsSpan(index + 4);
				int num = MemoryMarshal.Read<int>(span);
				int value = num | -2147483648;
				MemoryMarshal.Write(span, ref value);
			}

			internal int FindIndexOfFirstUnsetSizeOrLength(JsonTokenType lookupType)
			{
				return FindOpenElement(lookupType);
			}

			private int FindOpenElement(JsonTokenType lookupType)
			{
				Span<byte> span = _data.AsSpan(0, Length);
				for (int num = Length - 12; num >= 0; num -= 12)
				{
					DbRow dbRow = MemoryMarshal.Read<DbRow>(span.Slice(num));
					if (dbRow.IsUnknownSize && dbRow.TokenType == lookupType)
					{
						return num;
					}
				}
				return -1;
			}

			internal DbRow Get(int index)
			{
				return MemoryMarshal.Read<DbRow>(_data.AsSpan(index));
			}

			internal JsonTokenType GetJsonTokenType(int index)
			{
				uint num = MemoryMarshal.Read<uint>(_data.AsSpan(index + 8));
				return (JsonTokenType)(num >> 28);
			}

			internal MetadataDb CopySegment(int startIndex, int endIndex)
			{
				DbRow dbRow = Get(startIndex);
				int num = endIndex - startIndex;
				byte[] array = new byte[num];
				_data.AsSpan(startIndex, num).CopyTo(array);
				Span<int> span = MemoryMarshal.Cast<byte, int>((Span<byte>)array);
				int num2 = span[0];
				if (dbRow.TokenType == JsonTokenType.String)
				{
					num2--;
				}
				for (int num3 = (num - 12) / 4; num3 >= 0; num3 -= 3)
				{
					span[num3] -= num2;
				}
				return new MetadataDb(array);
			}
		}

		private struct StackRow(int sizeOrLength = 0, int numberOfRows = -1)
		{
			internal const int Size = 8;

			internal int SizeOrLength = sizeOrLength;

			internal int NumberOfRows = numberOfRows;
		}

		private struct StackRowStack(int initialSize) : IDisposable
		{
			private byte[] _rentedBuffer = ArrayPool<byte>.Shared.Rent(initialSize);

			private int _topOfStack = _rentedBuffer.Length;

			public void Dispose()
			{
				byte[] rentedBuffer = _rentedBuffer;
				_rentedBuffer = null;
				_topOfStack = 0;
				if (rentedBuffer != null)
				{
					ArrayPool<byte>.Shared.Return(rentedBuffer);
				}
			}

			internal void Push(StackRow row)
			{
				if (_topOfStack < 8)
				{
					Enlarge();
				}
				_topOfStack -= 8;
				MemoryMarshal.Write(_rentedBuffer.AsSpan(_topOfStack), ref row);
			}

			internal StackRow Pop()
			{
				StackRow result = MemoryMarshal.Read<StackRow>(_rentedBuffer.AsSpan(_topOfStack));
				_topOfStack += 8;
				return result;
			}

			private void Enlarge()
			{
				byte[] rentedBuffer = _rentedBuffer;
				_rentedBuffer = ArrayPool<byte>.Shared.Rent(rentedBuffer.Length * 2);
				Buffer.BlockCopy(rentedBuffer, _topOfStack, _rentedBuffer, _rentedBuffer.Length - rentedBuffer.Length + _topOfStack, rentedBuffer.Length - _topOfStack);
				_topOfStack += _rentedBuffer.Length - rentedBuffer.Length;
				ArrayPool<byte>.Shared.Return(rentedBuffer);
			}
		}

		private ReadOnlyMemory<byte> _utf8Json;

		private MetadataDb _parsedData;

		private byte[] _extraRentedBytes;

		private (int, string) _lastIndexAndString = (-1, null);

		private const int UnseekableStreamInitialRentSize = 4096;

		internal bool IsDisposable { get; }

		public JsonElement RootElement => new JsonElement(this, 0);

		private JsonDocument(ReadOnlyMemory<byte> utf8Json, MetadataDb parsedData, byte[] extraRentedBytes, bool isDisposable = true)
		{
			_utf8Json = utf8Json;
			_parsedData = parsedData;
			_extraRentedBytes = extraRentedBytes;
			IsDisposable = isDisposable;
		}

		public void Dispose()
		{
			int length = _utf8Json.Length;
			if (length != 0 && IsDisposable)
			{
				_parsedData.Dispose();
				_utf8Json = ReadOnlyMemory<byte>.Empty;
				byte[] array = Interlocked.Exchange(ref _extraRentedBytes, null);
				if (array != null)
				{
					array.AsSpan(0, length).Clear();
					ArrayPool<byte>.Shared.Return(array);
				}
			}
		}

		public void WriteTo(Utf8JsonWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			RootElement.WriteTo(writer);
		}

		internal JsonTokenType GetJsonTokenType(int index)
		{
			CheckNotDisposed();
			return _parsedData.GetJsonTokenType(index);
		}

		internal int GetArrayLength(int index)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.StartArray, dbRow.TokenType);
			return dbRow.SizeOrLength;
		}

		internal JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(currentIndex);
			CheckExpectedType(JsonTokenType.StartArray, dbRow.TokenType);
			int sizeOrLength = dbRow.SizeOrLength;
			if ((uint)arrayIndex >= (uint)sizeOrLength)
			{
				throw new IndexOutOfRangeException();
			}
			if (!dbRow.HasComplexChildren)
			{
				return new JsonElement(this, currentIndex + (arrayIndex + 1) * 12);
			}
			int num = 0;
			for (int i = currentIndex + 12; i < _parsedData.Length; i += 12)
			{
				if (arrayIndex == num)
				{
					return new JsonElement(this, i);
				}
				dbRow = _parsedData.Get(i);
				if (!dbRow.IsSimpleValue)
				{
					i += 12 * dbRow.NumberOfRows;
				}
				num++;
			}
			throw new IndexOutOfRangeException();
		}

		internal int GetEndIndex(int index, bool includeEndElement)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			if (dbRow.IsSimpleValue)
			{
				return index + 12;
			}
			int num = index + 12 * dbRow.NumberOfRows;
			if (includeEndElement)
			{
				num += 12;
			}
			return num;
		}

		private ReadOnlyMemory<byte> GetRawValue(int index, bool includeQuotes)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			if (dbRow.IsSimpleValue)
			{
				if (includeQuotes && dbRow.TokenType == JsonTokenType.String)
				{
					return _utf8Json.Slice(dbRow.Location - 1, dbRow.SizeOrLength + 2);
				}
				return _utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength);
			}
			int endIndex = GetEndIndex(index, includeEndElement: false);
			int location = dbRow.Location;
			dbRow = _parsedData.Get(endIndex);
			return _utf8Json.Slice(location, dbRow.Location - location + dbRow.SizeOrLength);
		}

		private ReadOnlyMemory<byte> GetPropertyRawValue(int valueIndex)
		{
			CheckNotDisposed();
			int num = _parsedData.Get(valueIndex - 12).Location - 1;
			DbRow dbRow = _parsedData.Get(valueIndex);
			int num2;
			if (dbRow.IsSimpleValue)
			{
				num2 = dbRow.Location + dbRow.SizeOrLength;
				if (dbRow.TokenType == JsonTokenType.String)
				{
					num2++;
				}
				return _utf8Json.Slice(num, num2 - num);
			}
			int endIndex = GetEndIndex(valueIndex, includeEndElement: false);
			dbRow = _parsedData.Get(endIndex);
			num2 = dbRow.Location + dbRow.SizeOrLength;
			return _utf8Json.Slice(num, num2 - num);
		}

		internal string GetString(int index, JsonTokenType expectedType)
		{
			CheckNotDisposed();
			int num;
			string result;
			(num, result) = _lastIndexAndString;
			if (num == index)
			{
				return result;
			}
			DbRow dbRow = _parsedData.Get(index);
			JsonTokenType tokenType = dbRow.TokenType;
			if (tokenType == JsonTokenType.Null)
			{
				return null;
			}
			CheckExpectedType(expectedType, tokenType);
			ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (dbRow.HasComplexChildren)
			{
				int idx = readOnlySpan.IndexOf((byte)92);
				result = JsonReaderHelper.GetUnescapedString(readOnlySpan, idx);
			}
			else
			{
				result = JsonReaderHelper.TranscodeHelper(readOnlySpan);
			}
			_lastIndexAndString = (index, result);
			return result;
		}

		internal bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName)
		{
			CheckNotDisposed();
			int num = (isPropertyName ? (index - 12) : index);
			var (num2, text) = _lastIndexAndString;
			if (num2 == num)
			{
				return otherText.SequenceEqual(text.AsSpan());
			}
			byte[] array = null;
			int num3 = checked(otherText.Length * 3);
			Span<byte> span = ((num3 > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num3))) : stackalloc byte[256]);
			Span<byte> utf8Destination = span;
			ReadOnlySpan<byte> utf16Source = MemoryMarshal.AsBytes(otherText);
			int bytesConsumed;
			int bytesWritten;
			OperationStatus operationStatus = JsonWriterHelper.ToUtf8(utf16Source, utf8Destination, out bytesConsumed, out bytesWritten);
			bool result = operationStatus <= OperationStatus.DestinationTooSmall && TextEquals(index, utf8Destination.Slice(0, bytesWritten), isPropertyName);
			if (array != null)
			{
				utf8Destination.Slice(0, bytesWritten).Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		internal bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName)
		{
			CheckNotDisposed();
			int index2 = (isPropertyName ? (index - 12) : index);
			DbRow dbRow = _parsedData.Get(index2);
			CheckExpectedType(isPropertyName ? JsonTokenType.PropertyName : JsonTokenType.String, dbRow.TokenType);
			ReadOnlySpan<byte> span = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (otherUtf8Text.Length > span.Length)
			{
				return false;
			}
			if (dbRow.HasComplexChildren)
			{
				if (otherUtf8Text.Length < span.Length / 6)
				{
					return false;
				}
				int num = span.IndexOf((byte)92);
				if (!otherUtf8Text.StartsWith(span.Slice(0, num)))
				{
					return false;
				}
				return JsonReaderHelper.UnescapeAndCompare(span.Slice(num), otherUtf8Text.Slice(num));
			}
			return span.SequenceEqual(otherUtf8Text);
		}

		internal string GetNameOfPropertyValue(int index)
		{
			return GetString(index - 12, JsonTokenType.PropertyName);
		}

		internal bool TryGetValue(int index, out byte[] value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
			ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (dbRow.HasComplexChildren)
			{
				int idx = readOnlySpan.IndexOf((byte)92);
				return JsonReaderHelper.TryGetUnescapedBase64Bytes(readOnlySpan, idx, out value);
			}
			return JsonReaderHelper.TryDecodeBase64(readOnlySpan, out value);
		}

		internal bool TryGetValue(int index, out sbyte value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out sbyte value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		internal bool TryGetValue(int index, out byte value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out byte value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		internal bool TryGetValue(int index, out short value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out short value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		internal bool TryGetValue(int index, out ushort value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out ushort value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		internal bool TryGetValue(int index, out int value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out int value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		internal bool TryGetValue(int index, out uint value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out uint value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0u;
			return false;
		}

		internal bool TryGetValue(int index, out long value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out long value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0L;
			return false;
		}

		internal bool TryGetValue(int index, out ulong value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (Utf8Parser.TryParse(source, out ulong value2, out int bytesConsumed, '\0') && bytesConsumed == source.Length)
			{
				value = value2;
				return true;
			}
			value = 0uL;
			return false;
		}

		internal bool TryGetValue(int index, out double value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			char standardFormat = (dbRow.HasComplexChildren ? 'e' : '\0');
			if (Utf8Parser.TryParse(source, out double value2, out int bytesConsumed, standardFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0.0;
			return false;
		}

		internal bool TryGetValue(int index, out float value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			char standardFormat = (dbRow.HasComplexChildren ? 'e' : '\0');
			if (Utf8Parser.TryParse(source, out float value2, out int bytesConsumed, standardFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0f;
			return false;
		}

		internal bool TryGetValue(int index, out decimal value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			char standardFormat = (dbRow.HasComplexChildren ? 'e' : '\0');
			if (Utf8Parser.TryParse(source, out decimal value2, out int bytesConsumed, standardFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = default(decimal);
			return false;
		}

		internal bool TryGetValue(int index, out DateTime value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(source.Length))
			{
				value = default(DateTime);
				return false;
			}
			if (dbRow.HasComplexChildren)
			{
				return JsonReaderHelper.TryGetEscapedDateTime(source, out value);
			}
			if (source.Length <= 42 && JsonHelpers.TryParseAsISO(source, out DateTime value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTime);
			return false;
		}

		internal bool TryGetValue(int index, out DateTimeOffset value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(source.Length))
			{
				value = default(DateTimeOffset);
				return false;
			}
			if (dbRow.HasComplexChildren)
			{
				return JsonReaderHelper.TryGetEscapedDateTimeOffset(source, out value);
			}
			if (source.Length <= 42 && JsonHelpers.TryParseAsISO(source, out DateTimeOffset value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTimeOffset);
			return false;
		}

		internal bool TryGetValue(int index, out Guid value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
			ReadOnlySpan<byte> source = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (source.Length > 216)
			{
				value = default(Guid);
				return false;
			}
			if (dbRow.HasComplexChildren)
			{
				return JsonReaderHelper.TryGetEscapedGuid(source, out value);
			}
			if (source.Length == 36 && Utf8Parser.TryParse(source, out Guid value2, out int _, 'D'))
			{
				value = value2;
				return true;
			}
			value = default(Guid);
			return false;
		}

		internal string GetRawValueAsString(int index)
		{
			return JsonReaderHelper.TranscodeHelper(GetRawValue(index, includeQuotes: true).Span);
		}

		internal string GetPropertyRawValueAsString(int valueIndex)
		{
			return JsonReaderHelper.TranscodeHelper(GetPropertyRawValue(valueIndex).Span);
		}

		internal JsonElement CloneElement(int index)
		{
			int endIndex = GetEndIndex(index, includeEndElement: true);
			MetadataDb parsedData = _parsedData.CopySegment(index, endIndex);
			ReadOnlyMemory<byte> utf8Json = GetRawValue(index, includeQuotes: true).ToArray();
			JsonDocument jsonDocument = new JsonDocument(utf8Json, parsedData, null, isDisposable: false);
			return jsonDocument.RootElement;
		}

		internal void WriteElementTo(int index, Utf8JsonWriter writer)
		{
			CheckNotDisposed();
			DbRow row = _parsedData.Get(index);
			switch (row.TokenType)
			{
			case JsonTokenType.StartObject:
				writer.WriteStartObject();
				WriteComplexElement(index, writer);
				break;
			case JsonTokenType.StartArray:
				writer.WriteStartArray();
				WriteComplexElement(index, writer);
				break;
			case JsonTokenType.String:
				WriteString(in row, writer);
				break;
			case JsonTokenType.Number:
				writer.WriteNumberValue(_utf8Json.Slice(row.Location, row.SizeOrLength).Span);
				break;
			case JsonTokenType.True:
				writer.WriteBooleanValue(value: true);
				break;
			case JsonTokenType.False:
				writer.WriteBooleanValue(value: false);
				break;
			case JsonTokenType.Null:
				writer.WriteNullValue();
				break;
			case JsonTokenType.EndObject:
			case JsonTokenType.EndArray:
			case JsonTokenType.PropertyName:
			case JsonTokenType.Comment:
				break;
			}
		}

		private void WriteComplexElement(int index, Utf8JsonWriter writer)
		{
			int endIndex = GetEndIndex(index, includeEndElement: true);
			for (int i = index + 12; i < endIndex; i += 12)
			{
				DbRow row = _parsedData.Get(i);
				switch (row.TokenType)
				{
				case JsonTokenType.String:
					WriteString(in row, writer);
					break;
				case JsonTokenType.Number:
					writer.WriteNumberValue(_utf8Json.Slice(row.Location, row.SizeOrLength).Span);
					break;
				case JsonTokenType.True:
					writer.WriteBooleanValue(value: true);
					break;
				case JsonTokenType.False:
					writer.WriteBooleanValue(value: false);
					break;
				case JsonTokenType.Null:
					writer.WriteNullValue();
					break;
				case JsonTokenType.StartObject:
					writer.WriteStartObject();
					break;
				case JsonTokenType.EndObject:
					writer.WriteEndObject();
					break;
				case JsonTokenType.StartArray:
					writer.WriteStartArray();
					break;
				case JsonTokenType.EndArray:
					writer.WriteEndArray();
					break;
				case JsonTokenType.PropertyName:
					WritePropertyName(in row, writer);
					break;
				}
			}
		}

		private ReadOnlySpan<byte> UnescapeString(in DbRow row, out ArraySegment<byte> rented)
		{
			int location = row.Location;
			int sizeOrLength = row.SizeOrLength;
			ReadOnlySpan<byte> span = _utf8Json.Slice(location, sizeOrLength).Span;
			if (!row.HasComplexChildren)
			{
				rented = default(ArraySegment<byte>);
				return span;
			}
			int num = span.IndexOf((byte)92);
			byte[] array = ArrayPool<byte>.Shared.Rent(sizeOrLength);
			span.Slice(0, num).CopyTo(array);
			JsonReaderHelper.Unescape(span, array, num, out var written);
			rented = new ArraySegment<byte>(array, 0, written);
			return rented.AsSpan();
		}

		private static void ClearAndReturn(ArraySegment<byte> rented)
		{
			if (rented.Array != null)
			{
				rented.AsSpan().Clear();
				ArrayPool<byte>.Shared.Return(rented.Array);
			}
		}

		private void WritePropertyName(in DbRow row, Utf8JsonWriter writer)
		{
			ArraySegment<byte> rented = default(ArraySegment<byte>);
			try
			{
				writer.WritePropertyName(UnescapeString(in row, out rented));
			}
			finally
			{
				ClearAndReturn(rented);
			}
		}

		private void WriteString(in DbRow row, Utf8JsonWriter writer)
		{
			ArraySegment<byte> rented = default(ArraySegment<byte>);
			try
			{
				writer.WriteStringValue(UnescapeString(in row, out rented));
			}
			finally
			{
				ClearAndReturn(rented);
			}
		}

		private static void Parse(ReadOnlySpan<byte> utf8JsonSpan, Utf8JsonReader reader, ref MetadataDb database, ref StackRowStack stack)
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (reader.Read())
			{
				JsonTokenType tokenType = reader.TokenType;
				int num4 = (int)reader.TokenStartIndex;
				switch (tokenType)
				{
				case JsonTokenType.StartObject:
				{
					if (flag)
					{
						num++;
					}
					num3++;
					database.Append(tokenType, num4, -1);
					StackRow row = new StackRow(num2 + 1);
					stack.Push(row);
					num2 = 0;
					break;
				}
				case JsonTokenType.EndObject:
				{
					int index = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartObject);
					num3++;
					num2++;
					database.SetLength(index, num2);
					int length = database.Length;
					database.Append(tokenType, num4, reader.ValueSpan.Length);
					database.SetNumberOfRows(index, num2);
					database.SetNumberOfRows(length, num2);
					num2 += stack.Pop().SizeOrLength;
					break;
				}
				case JsonTokenType.StartArray:
				{
					if (flag)
					{
						num++;
					}
					num2++;
					database.Append(tokenType, num4, -1);
					StackRow row2 = new StackRow(num, num3 + 1);
					stack.Push(row2);
					num = 0;
					num3 = 0;
					break;
				}
				case JsonTokenType.EndArray:
				{
					int num5 = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartArray);
					num3++;
					num2++;
					database.SetLength(num5, num);
					database.SetNumberOfRows(num5, num3);
					if (num + 1 != num3)
					{
						database.SetHasComplexChildren(num5);
					}
					int length2 = database.Length;
					database.Append(tokenType, num4, reader.ValueSpan.Length);
					database.SetNumberOfRows(length2, num3);
					StackRow stackRow = stack.Pop();
					num = stackRow.SizeOrLength;
					num3 += stackRow.NumberOfRows;
					break;
				}
				case JsonTokenType.PropertyName:
					num3++;
					num2++;
					database.Append(tokenType, num4 + 1, reader.ValueSpan.Length);
					if (reader._stringHasEscaping)
					{
						database.SetHasComplexChildren(database.Length - 12);
					}
					break;
				default:
					num3++;
					num2++;
					if (flag)
					{
						num++;
					}
					if (tokenType == JsonTokenType.String)
					{
						database.Append(tokenType, num4 + 1, reader.ValueSpan.Length);
						if (reader._stringHasEscaping)
						{
							database.SetHasComplexChildren(database.Length - 12);
						}
						break;
					}
					database.Append(tokenType, num4, reader.ValueSpan.Length);
					if (tokenType == JsonTokenType.Number)
					{
						char numberFormat = reader._numberFormat;
						if (numberFormat == 'e')
						{
							database.SetHasComplexChildren(database.Length - 12);
						}
					}
					break;
				}
				flag = reader.IsInArray;
			}
			database.TrimExcess();
		}

		private void CheckNotDisposed()
		{
			if (_utf8Json.IsEmpty)
			{
				throw new ObjectDisposedException("JsonDocument");
			}
		}

		private void CheckExpectedType(JsonTokenType expected, JsonTokenType actual)
		{
			if (expected != actual)
			{
				throw ThrowHelper.GetJsonElementWrongTypeException(expected, actual);
			}
		}

		private static void CheckSupportedOptions(JsonReaderOptions readerOptions, string paramName)
		{
			if (readerOptions.CommentHandling == JsonCommentHandling.Allow)
			{
				throw new ArgumentException(SR.JsonDocumentDoesNotSupportComments, paramName);
			}
		}

		public static JsonDocument Parse(ReadOnlyMemory<byte> utf8Json, JsonDocumentOptions options = default(JsonDocumentOptions))
		{
			return Parse(utf8Json, options.GetReaderOptions(), null);
		}

		public static JsonDocument Parse(ReadOnlySequence<byte> utf8Json, JsonDocumentOptions options = default(JsonDocumentOptions))
		{
			JsonReaderOptions readerOptions = options.GetReaderOptions();
			if (utf8Json.IsSingleSegment)
			{
				return Parse(utf8Json.First, readerOptions, null);
			}
			int num = checked((int)utf8Json.Length);
			byte[] array = ArrayPool<byte>.Shared.Rent(num);
			try
			{
				utf8Json.CopyTo(array.AsSpan());
				return Parse(array.AsMemory(0, num), readerOptions, array);
			}
			catch
			{
				array.AsSpan(0, num).Clear();
				ArrayPool<byte>.Shared.Return(array);
				throw;
			}
		}

		public static JsonDocument Parse(Stream utf8Json, JsonDocumentOptions options = default(JsonDocumentOptions))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			ArraySegment<byte> segment = ReadToEnd(utf8Json);
			try
			{
				return Parse(segment.AsMemory(), options.GetReaderOptions(), segment.Array);
			}
			catch
			{
				segment.AsSpan().Clear();
				ArrayPool<byte>.Shared.Return(segment.Array);
				throw;
			}
		}

		public static Task<JsonDocument> ParseAsync(Stream utf8Json, JsonDocumentOptions options = default(JsonDocumentOptions), CancellationToken cancellationToken = default(CancellationToken))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			return ParseAsyncCore(utf8Json, options, cancellationToken);
		}

		private static async Task<JsonDocument> ParseAsyncCore(Stream utf8Json, JsonDocumentOptions options = default(JsonDocumentOptions), CancellationToken cancellationToken = default(CancellationToken))
		{
			ArraySegment<byte> segment = await ReadToEndAsync(utf8Json, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				return Parse(segment.AsMemory(), options.GetReaderOptions(), segment.Array);
			}
			catch
			{
				segment.AsSpan().Clear();
				ArrayPool<byte>.Shared.Return(segment.Array);
				throw;
			}
		}

		public static JsonDocument Parse(ReadOnlyMemory<char> json, JsonDocumentOptions options = default(JsonDocumentOptions))
		{
			ReadOnlySpan<char> span = json.Span;
			int utf8ByteCount = JsonReaderHelper.GetUtf8ByteCount(span);
			byte[] array = ArrayPool<byte>.Shared.Rent(utf8ByteCount);
			try
			{
				int utf8FromText = JsonReaderHelper.GetUtf8FromText(span, array);
				return Parse(array.AsMemory(0, utf8FromText), options.GetReaderOptions(), array);
			}
			catch
			{
				array.AsSpan(0, utf8ByteCount).Clear();
				ArrayPool<byte>.Shared.Return(array);
				throw;
			}
		}

		public static JsonDocument Parse(string json, JsonDocumentOptions options = default(JsonDocumentOptions))
		{
			if (json == null)
			{
				throw new ArgumentNullException("json");
			}
			return Parse(json.AsMemory(), options);
		}

		public static bool TryParseValue(ref Utf8JsonReader reader, out JsonDocument document)
		{
			return TryParseValue(ref reader, out document, shouldThrow: false);
		}

		public static JsonDocument ParseValue(ref Utf8JsonReader reader)
		{
			JsonDocument document;
			bool flag = TryParseValue(ref reader, out document, shouldThrow: true);
			return document;
		}

		private static bool TryParseValue(ref Utf8JsonReader reader, out JsonDocument document, bool shouldThrow)
		{
			JsonReaderState currentState = reader.CurrentState;
			CheckSupportedOptions(currentState.Options, "reader");
			Utf8JsonReader utf8JsonReader = reader;
			ReadOnlySpan<byte> readOnlySpan = default(ReadOnlySpan<byte>);
			ReadOnlySequence<byte> source = default(ReadOnlySequence<byte>);
			try
			{
				JsonTokenType tokenType = reader.TokenType;
				ReadOnlySpan<byte> bytes;
				if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !reader.Read())
				{
					if (shouldThrow)
					{
						bytes = default(ReadOnlySpan<byte>);
						ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedJsonTokens, 0, bytes);
					}
					reader = utf8JsonReader;
					document = null;
					return false;
				}
				switch (reader.TokenType)
				{
				case JsonTokenType.StartObject:
				case JsonTokenType.StartArray:
				{
					long tokenStartIndex = reader.TokenStartIndex;
					int currentDepth = reader.CurrentDepth;
					do
					{
						if (!reader.Read())
						{
							if (shouldThrow)
							{
								bytes = default(ReadOnlySpan<byte>);
								ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedJsonTokens, 0, bytes);
							}
							reader = utf8JsonReader;
							document = null;
							return false;
						}
					}
					while (reader.CurrentDepth > currentDepth);
					long num = reader.BytesConsumed - tokenStartIndex;
					ReadOnlySequence<byte> originalSequence = reader.OriginalSequence;
					if (originalSequence.IsEmpty)
					{
						bytes = reader.OriginalSpan;
						readOnlySpan = checked(bytes.Slice((int)tokenStartIndex, (int)num));
					}
					else
					{
						source = originalSequence.Slice(tokenStartIndex, num);
					}
					break;
				}
				case JsonTokenType.Number:
				case JsonTokenType.True:
				case JsonTokenType.False:
				case JsonTokenType.Null:
					if (reader.HasValueSequence)
					{
						source = reader.ValueSequence;
					}
					else
					{
						readOnlySpan = reader.ValueSpan;
					}
					break;
				case JsonTokenType.String:
				{
					ReadOnlySequence<byte> originalSequence2 = reader.OriginalSequence;
					if (originalSequence2.IsEmpty)
					{
						bytes = reader.ValueSpan;
						int length = bytes.Length + 2;
						readOnlySpan = reader.OriginalSpan.Slice((int)reader.TokenStartIndex, length);
						break;
					}
					long num2 = 2L;
					if (reader.HasValueSequence)
					{
						num2 += reader.ValueSequence.Length;
					}
					else
					{
						long num3 = num2;
						bytes = reader.ValueSpan;
						num2 = num3 + bytes.Length;
					}
					source = originalSequence2.Slice(reader.TokenStartIndex, num2);
					break;
				}
				default:
					if (shouldThrow)
					{
						bytes = reader.ValueSpan;
						byte nextByte = bytes[0];
						bytes = default(ReadOnlySpan<byte>);
						ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedStartOfValueNotFound, nextByte, bytes);
					}
					reader = utf8JsonReader;
					document = null;
					return false;
				}
			}
			catch
			{
				reader = utf8JsonReader;
				throw;
			}
			int num4 = (readOnlySpan.IsEmpty ? checked((int)source.Length) : readOnlySpan.Length);
			byte[] array = ArrayPool<byte>.Shared.Rent(num4);
			Span<byte> destination = array.AsSpan(0, num4);
			try
			{
				if (readOnlySpan.IsEmpty)
				{
					source.CopyTo(destination);
				}
				else
				{
					readOnlySpan.CopyTo(destination);
				}
				document = Parse(array.AsMemory(0, num4), currentState.Options, array);
				return true;
			}
			catch
			{
				destination.Clear();
				ArrayPool<byte>.Shared.Return(array);
				throw;
			}
		}

		private static JsonDocument Parse(ReadOnlyMemory<byte> utf8Json, JsonReaderOptions readerOptions, byte[] extraRentedBytes)
		{
			ReadOnlySpan<byte> span = utf8Json.Span;
			Utf8JsonReader reader = new Utf8JsonReader(span, isFinalBlock: true, new JsonReaderState(readerOptions));
			MetadataDb database = new MetadataDb(utf8Json.Length);
			StackRowStack stack = new StackRowStack(512);
			try
			{
				Parse(span, reader, ref database, ref stack);
			}
			catch
			{
				database.Dispose();
				throw;
			}
			finally
			{
				stack.Dispose();
			}
			return new JsonDocument(utf8Json, database, extraRentedBytes);
		}

		private static ArraySegment<byte> ReadToEnd(Stream stream)
		{
			int num = 0;
			byte[] array = null;
			ReadOnlySpan<byte> utf8Bom = JsonConstants.Utf8Bom;
			try
			{
				if (stream.CanSeek)
				{
					long num2 = Math.Max(utf8Bom.Length, stream.Length - stream.Position) + 1;
					array = ArrayPool<byte>.Shared.Rent(checked((int)num2));
				}
				else
				{
					array = ArrayPool<byte>.Shared.Rent(4096);
				}
				int num3;
				do
				{
					num3 = stream.Read(array, num, utf8Bom.Length - num);
					num += num3;
				}
				while (num3 > 0 && num < utf8Bom.Length);
				if (num == utf8Bom.Length && utf8Bom.SequenceEqual(array.AsSpan(0, utf8Bom.Length)))
				{
					num = 0;
				}
				do
				{
					if (array.Length == num)
					{
						byte[] array2 = array;
						array = ArrayPool<byte>.Shared.Rent(checked(array2.Length * 2));
						Buffer.BlockCopy(array2, 0, array, 0, array2.Length);
						ArrayPool<byte>.Shared.Return(array2, clearArray: true);
					}
					num3 = stream.Read(array, num, array.Length - num);
					num += num3;
				}
				while (num3 > 0);
				return new ArraySegment<byte>(array, 0, num);
			}
			catch
			{
				if (array != null)
				{
					array.AsSpan(0, num).Clear();
					ArrayPool<byte>.Shared.Return(array);
				}
				throw;
			}
		}

		private static async Task<ArraySegment<byte>> ReadToEndAsync(Stream stream, CancellationToken cancellationToken)
		{
			int written = 0;
			byte[] rented = null;
			try
			{
				int utf8BomLength = JsonConstants.Utf8Bom.Length;
				if (stream.CanSeek)
				{
					long num = Math.Max(utf8BomLength, stream.Length - stream.Position) + 1;
					rented = ArrayPool<byte>.Shared.Rent(checked((int)num));
				}
				else
				{
					rented = ArrayPool<byte>.Shared.Rent(4096);
				}
				int num2;
				do
				{
					num2 = await stream.ReadAsync(rented, written, utf8BomLength - written, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					written += num2;
				}
				while (num2 > 0 && written < utf8BomLength);
				if (written == utf8BomLength && JsonConstants.Utf8Bom.SequenceEqual(rented.AsSpan(0, utf8BomLength)))
				{
					written = 0;
				}
				do
				{
					if (rented.Length == written)
					{
						byte[] array = rented;
						rented = ArrayPool<byte>.Shared.Rent(array.Length * 2);
						Buffer.BlockCopy(array, 0, rented, 0, array.Length);
						ArrayPool<byte>.Shared.Return(array, clearArray: true);
					}
					num2 = await stream.ReadAsync(rented, written, rented.Length - written, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					written += num2;
				}
				while (num2 > 0);
				return new ArraySegment<byte>(rented, 0, written);
			}
			catch
			{
				if (rented != null)
				{
					rented.AsSpan(0, written).Clear();
					ArrayPool<byte>.Shared.Return(rented);
				}
				throw;
			}
		}

		internal bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.StartObject, dbRow.TokenType);
			if (dbRow.NumberOfRows == 1)
			{
				value = default(JsonElement);
				return false;
			}
			int maxByteCount = JsonReaderHelper.s_utf8Encoding.GetMaxByteCount(propertyName.Length);
			int startIndex = index + 12;
			int num = checked(dbRow.NumberOfRows * 12 + index);
			if (maxByteCount < 256)
			{
				Span<byte> span = stackalloc byte[256];
				int utf8FromText = JsonReaderHelper.GetUtf8FromText(propertyName, span);
				span = span.Slice(0, utf8FromText);
				return TryGetNamedPropertyValue(startIndex, num, span, out value);
			}
			int length = propertyName.Length;
			int num2;
			for (num2 = num - 12; num2 > index; num2 -= 12)
			{
				int num3 = num2;
				dbRow = _parsedData.Get(num2);
				num2 = ((!dbRow.IsSimpleValue) ? (num2 - 12 * (dbRow.NumberOfRows + 1)) : (num2 - 12));
				if (_parsedData.Get(num2).SizeOrLength >= length)
				{
					byte[] array = ArrayPool<byte>.Shared.Rent(maxByteCount);
					Span<byte> span2 = default(Span<byte>);
					try
					{
						int utf8FromText2 = JsonReaderHelper.GetUtf8FromText(propertyName, array);
						span2 = array.AsSpan(0, utf8FromText2);
						return TryGetNamedPropertyValue(startIndex, num3 + 12, span2, out value);
					}
					finally
					{
						span2.Clear();
						ArrayPool<byte>.Shared.Return(array);
					}
				}
			}
			value = default(JsonElement);
			return false;
		}

		internal bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value)
		{
			CheckNotDisposed();
			DbRow dbRow = _parsedData.Get(index);
			CheckExpectedType(JsonTokenType.StartObject, dbRow.TokenType);
			if (dbRow.NumberOfRows == 1)
			{
				value = default(JsonElement);
				return false;
			}
			int endIndex = checked(dbRow.NumberOfRows * 12 + index);
			return TryGetNamedPropertyValue(index + 12, endIndex, propertyName, out value);
		}

		private bool TryGetNamedPropertyValue(int startIndex, int endIndex, ReadOnlySpan<byte> propertyName, out JsonElement value)
		{
			ReadOnlySpan<byte> span = _utf8Json.Span;
			int num;
			for (num = endIndex - 12; num > startIndex; num -= 12)
			{
				DbRow dbRow = _parsedData.Get(num);
				num = ((!dbRow.IsSimpleValue) ? (num - 12 * (dbRow.NumberOfRows + 1)) : (num - 12));
				dbRow = _parsedData.Get(num);
				ReadOnlySpan<byte> span2 = span.Slice(dbRow.Location, dbRow.SizeOrLength);
				if (dbRow.HasComplexChildren)
				{
					if (span2.Length > propertyName.Length)
					{
						int num2 = span2.IndexOf((byte)92);
						if (propertyName.Length > num2 && span2.Slice(0, num2).SequenceEqual(propertyName.Slice(0, num2)))
						{
							int num3 = span2.Length - num2;
							int written = 0;
							byte[] array = null;
							try
							{
								Span<byte> span3 = ((num3 > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num3))) : stackalloc byte[num3]);
								Span<byte> destination = span3;
								JsonReaderHelper.Unescape(span2.Slice(num2), destination, 0, out written);
								if (destination.Slice(0, written).SequenceEqual(propertyName.Slice(num2)))
								{
									value = new JsonElement(this, num + 12);
									return true;
								}
							}
							finally
							{
								if (array != null)
								{
									array.AsSpan(0, written).Clear();
									ArrayPool<byte>.Shared.Return(array);
								}
							}
						}
					}
				}
				else if (span2.SequenceEqual(propertyName))
				{
					value = new JsonElement(this, num + 12);
					return true;
				}
			}
			value = default(JsonElement);
			return false;
		}
	}
	public struct JsonDocumentOptions
	{
		internal const int DefaultMaxDepth = 64;

		private int _maxDepth;

		private JsonCommentHandling _commentHandling;

		public JsonCommentHandling CommentHandling
		{
			readonly get
			{
				return _commentHandling;
			}
			set
			{
				if ((int)value > 1)
				{
					throw new ArgumentOutOfRangeException("value", SR.JsonDocumentDoesNotSupportComments);
				}
				_commentHandling = value;
			}
		}

		public int MaxDepth
		{
			readonly get
			{
				return _maxDepth;
			}
			set
			{
				if (value < 0)
				{
					throw ThrowHelper.GetArgumentOutOfRangeException_MaxDepthMustBePositive("value");
				}
				_maxDepth = value;
			}
		}

		public bool AllowTrailingCommas { get; set; }

		internal JsonReaderOptions GetReaderOptions()
		{
			return new JsonReaderOptions
			{
				AllowTrailingCommas = AllowTrailingCommas,
				CommentHandling = CommentHandling,
				MaxDepth = MaxDepth
			};
		}
	}
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public readonly struct JsonElement(JsonDocument parent, int idx)
	{
		[DebuggerDisplay("{Current,nq}")]
		public struct ArrayEnumerator(JsonElement target) : IEnumerable<JsonElement>, IEnumerable, IEnumerator<JsonElement>, IEnumerator, IDisposable
		{
			private readonly JsonElement _target = target;

			private int _curIdx = -1;

			private readonly int _endIdx = _target._parent.GetEndIndex(_target._idx, includeEndElement: false);

			public JsonElement Current
			{
				get
				{
					if (_curIdx >= 0)
					{
						return new JsonElement(_target._parent, _curIdx);
					}
					return default(JsonElement);
				}
			}

			object IEnumerator.Current => Current;

			public ArrayEnumerator GetEnumerator()
			{
				ArrayEnumerator result = this;
				result._curIdx = -1;
				return result;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator<JsonElement> IEnumerable<JsonElement>.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Dispose()
			{
				_curIdx = _endIdx;
			}

			public void Reset()
			{
				_curIdx = -1;
			}

			public bool MoveNext()
			{
				if (_curIdx >= _endIdx)
				{
					return false;
				}
				if (_curIdx < 0)
				{
					_curIdx = _target._idx + 12;
				}
				else
				{
					_curIdx = _target._parent.GetEndIndex(_curIdx, includeEndElement: true);
				}
				return _curIdx < _endIdx;
			}
		}

		[DebuggerDisplay("{Current,nq}")]
		public struct ObjectEnumerator(JsonElement target) : IEnumerable<JsonProperty>, IEnumerable, IEnumerator<JsonProperty>, IEnumerator, IDisposable
		{
			private readonly JsonElement _target = target;

			private int _curIdx = -1;

			private readonly int _endIdx = _target._parent.GetEndIndex(_target._idx, includeEndElement: false);

			public JsonProperty Current
			{
				get
				{
					if (_curIdx >= 0)
					{
						return new JsonProperty(new JsonElement(_target._parent, _curIdx));
					}
					return default(JsonProperty);
				}
			}

			object IEnumerator.Current => Current;

			public ObjectEnumerator GetEnumerator()
			{
				ObjectEnumerator result = this;
				result._curIdx = -1;
				return result;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator<JsonProperty> IEnumerable<JsonProperty>.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Dispose()
			{
				_curIdx = _endIdx;
			}

			public void Reset()
			{
				_curIdx = -1;
			}

			public bool MoveNext()
			{
				if (_curIdx >= _endIdx)
				{
					return false;
				}
				if (_curIdx < 0)
				{
					_curIdx = _target._idx + 12;
				}
				else
				{
					_curIdx = _target._parent.GetEndIndex(_curIdx, includeEndElement: true);
				}
				_curIdx += 12;
				return _curIdx < _endIdx;
			}
		}

		private readonly JsonDocument _parent = parent;

		private readonly int _idx = idx;

		private JsonTokenType TokenType => _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;

		public JsonValueKind ValueKind => TokenType.ToValueKind();

		public JsonElement this[int index]
		{
			get
			{
				CheckValidInstance();
				return _parent.GetArrayIndexElement(_idx, index);
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string DebuggerDisplay => $"ValueKind = {ValueKind} : \"{ToString()}\"";

		public int GetArrayLength()
		{
			CheckValidInstance();
			return _parent.GetArrayLength(_idx);
		}

		public JsonElement GetProperty(string propertyName)
		{
			if (propertyName == null)
			{
				throw new ArgumentNullException("propertyName");
			}
			if (TryGetProperty(propertyName, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException();
		}

		public JsonElement GetProperty(ReadOnlySpan<char> propertyName)
		{
			if (TryGetProperty(propertyName, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException();
		}

		public JsonElement GetProperty(ReadOnlySpan<byte> utf8PropertyName)
		{
			if (TryGetProperty(utf8PropertyName, out var value))
			{
				return value;
			}
			throw new KeyNotFoundException();
		}

		public bool TryGetProperty(string propertyName, out JsonElement value)
		{
			if (propertyName == null)
			{
				throw new ArgumentNullException("propertyName");
			}
			return TryGetProperty(propertyName.AsSpan(), out value);
		}

		public bool TryGetProperty(ReadOnlySpan<char> propertyName, out JsonElement value)
		{
			CheckValidInstance();
			return _parent.TryGetNamedPropertyValue(_idx, propertyName, out value);
		}

		public bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, out JsonElement value)
		{
			CheckValidInstance();
			return _parent.TryGetNamedPropertyValue(_idx, utf8PropertyName, out value);
		}

		public bool GetBoolean()
		{
			JsonTokenType tokenType = TokenType;
			return tokenType switch
			{
				JsonTokenType.False => false, 
				JsonTokenType.True => true, 
				_ => throw ThrowHelper.GetJsonElementWrongTypeException("Boolean", tokenType), 
			};
		}

		public string GetString()
		{
			CheckValidInstance();
			return _parent.GetString(_idx, JsonTokenType.String);
		}

		public bool TryGetBytesFromBase64(out byte[] value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public byte[] GetBytesFromBase64()
		{
			if (TryGetBytesFromBase64(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		[CLSCompliant(false)]
		public bool TryGetSByte(out sbyte value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		[CLSCompliant(false)]
		public sbyte GetSByte()
		{
			if (TryGetSByte(out var value))
			{
				return value;
			}
			throw new FormatException();
		}

		public bool TryGetByte(out byte value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public byte GetByte()
		{
			if (TryGetByte(out var value))
			{
				return value;
			}
			throw new FormatException();
		}

		public bool TryGetInt16(out short value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public short GetInt16()
		{
			if (TryGetInt16(out var value))
			{
				return value;
			}
			throw new FormatException();
		}

		[CLSCompliant(false)]
		public bool TryGetUInt16(out ushort value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		[CLSCompliant(false)]
		public ushort GetUInt16()
		{
			if (TryGetUInt16(out var value))
			{
				return value;
			}
			throw new FormatException();
		}

		public bool TryGetInt32(out int value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public int GetInt32()
		{
			if (TryGetInt32(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		[CLSCompliant(false)]
		public bool TryGetUInt32(out uint value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		[CLSCompliant(false)]
		public uint GetUInt32()
		{
			if (TryGetUInt32(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetInt64(out long value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public long GetInt64()
		{
			if (TryGetInt64(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		[CLSCompliant(false)]
		public bool TryGetUInt64(out ulong value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		[CLSCompliant(false)]
		public ulong GetUInt64()
		{
			if (TryGetUInt64(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetDouble(out double value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public double GetDouble()
		{
			if (TryGetDouble(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetSingle(out float value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public float GetSingle()
		{
			if (TryGetSingle(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetDecimal(out decimal value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public decimal GetDecimal()
		{
			if (TryGetDecimal(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetDateTime(out DateTime value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public DateTime GetDateTime()
		{
			if (TryGetDateTime(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetDateTimeOffset(out DateTimeOffset value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public DateTimeOffset GetDateTimeOffset()
		{
			if (TryGetDateTimeOffset(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		public bool TryGetGuid(out Guid value)
		{
			CheckValidInstance();
			return _parent.TryGetValue(_idx, out value);
		}

		public Guid GetGuid()
		{
			if (TryGetGuid(out var value))
			{
				return value;
			}
			throw ThrowHelper.GetFormatException();
		}

		internal string GetPropertyName()
		{
			CheckValidInstance();
			return _parent.GetNameOfPropertyValue(_idx);
		}

		public string GetRawText()
		{
			CheckValidInstance();
			return _parent.GetRawValueAsString(_idx);
		}

		internal string GetPropertyRawText()
		{
			CheckValidInstance();
			return _parent.GetPropertyRawValueAsString(_idx);
		}

		public bool ValueEquals(string text)
		{
			if (TokenType == JsonTokenType.Null)
			{
				return text == null;
			}
			return TextEqualsHelper(text.AsSpan(), isPropertyName: false);
		}

		public bool ValueEquals(ReadOnlySpan<byte> utf8Text)
		{
			if (TokenType == JsonTokenType.Null)
			{
				return utf8Text == default(ReadOnlySpan<byte>);
			}
			return TextEqualsHelper(utf8Text, isPropertyName: false);
		}

		public bool ValueEquals(ReadOnlySpan<char> text)
		{
			if (TokenType == JsonTokenType.Null)
			{
				return text == default(ReadOnlySpan<char>);
			}
			return TextEqualsHelper(text, isPropertyName: false);
		}

		internal bool TextEqualsHelper(ReadOnlySpan<byte> utf8Text, bool isPropertyName)
		{
			CheckValidInstance();
			return _parent.TextEquals(_idx, utf8Text, isPropertyName);
		}

		internal bool TextEqualsHelper(ReadOnlySpan<char> text, bool isPropertyName)
		{
			CheckValidInstance();
			return _parent.TextEquals(_idx, text, isPropertyName);
		}

		public void WriteTo(Utf8JsonWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			CheckValidInstance();
			_parent.WriteElementTo(_idx, writer);
		}

		public ArrayEnumerator EnumerateArray()
		{
			CheckValidInstance();
			JsonTokenType tokenType = TokenType;
			if (tokenType != JsonTokenType.StartArray)
			{
				throw ThrowHelper.GetJsonElementWrongTypeException(JsonTokenType.StartArray, tokenType);
			}
			return new ArrayEnumerator(this);
		}

		public ObjectEnumerator EnumerateObject()
		{
			CheckValidInstance();
			JsonTokenType tokenType = TokenType;
			if (tokenType != JsonTokenType.StartObject)
			{
				throw ThrowHelper.GetJsonElementWrongTypeException(JsonTokenType.StartObject, tokenType);
			}
			return new ObjectEnumerator(this);
		}

		public override string ToString()
		{
			switch (TokenType)
			{
			case JsonTokenType.None:
			case JsonTokenType.Null:
				return string.Empty;
			case JsonTokenType.True:
				return bool.TrueString;
			case JsonTokenType.False:
				return bool.FalseString;
			case JsonTokenType.StartObject:
			case JsonTokenType.StartArray:
			case JsonTokenType.Number:
				return _parent.GetRawValueAsString(_idx);
			case JsonTokenType.String:
				return GetString();
			default:
				return string.Empty;
			}
		}

		public JsonElement Clone()
		{
			CheckValidInstance();
			if (!_parent.IsDisposable)
			{
				return this;
			}
			return _parent.CloneElement(_idx);
		}

		private void CheckValidInstance()
		{
			if (_parent == null)
			{
				throw new InvalidOperationException();
			}
		}
	}
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public readonly struct JsonProperty
	{
		public JsonElement Value { get; }

		public string Name => Value.GetPropertyName();

		private string DebuggerDisplay
		{
			get
			{
				if (Value.ValueKind != JsonValueKind.Undefined)
				{
					return "\"" + ToString() + "\"";
				}
				return "<Undefined>";
			}
		}

		internal JsonProperty(JsonElement value)
		{
			Value = value;
		}

		public bool NameEquals(string text)
		{
			return NameEquals(text.AsSpan());
		}

		public bool NameEquals(ReadOnlySpan<byte> utf8Text)
		{
			return Value.TextEqualsHelper(utf8Text, isPropertyName: true);
		}

		public bool NameEquals(ReadOnlySpan<char> text)
		{
			return Value.TextEqualsHelper(text, isPropertyName: true);
		}

		public void WriteTo(Utf8JsonWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WritePropertyName(Name);
			Value.WriteTo(writer);
		}

		public override string ToString()
		{
			return Value.GetPropertyRawText();
		}
	}
	public enum JsonValueKind : byte
	{
		Undefined,
		Object,
		Array,
		String,
		Number,
		True,
		False,
		Null
	}
	internal enum ConsumeNumberResult : byte
	{
		Success,
		OperationIncomplete,
		NeedMoreData
	}
	internal enum ConsumeTokenResult : byte
	{
		Success,
		NotEnoughDataRollBackState,
		IncompleteNoRollBackNecessary
	}
	internal static class JsonReaderHelper
	{
		private const ulong XorPowerOfTwoToHighByte = 283686952306184uL;

		public static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

		public static (int, int) CountNewLines(ReadOnlySpan<byte> data)
		{
			int item = -1;
			int num = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == 10)
				{
					item = i;
					num++;
				}
			}
			return (num, item);
		}

		internal static JsonValueKind ToValueKind(this JsonTokenType tokenType)
		{
			switch (tokenType)
			{
			case JsonTokenType.None:
				return JsonValueKind.Undefined;
			case JsonTokenType.StartArray:
				return JsonValueKind.Array;
			case JsonTokenType.StartObject:
				return JsonValueKind.Object;
			case JsonTokenType.String:
			case JsonTokenType.Number:
			case JsonTokenType.True:
			case JsonTokenType.False:
			case JsonTokenType.Null:
				return (JsonValueKind)(tokenType - 4);
			default:
				return JsonValueKind.Undefined;
			}
		}

		public static bool IsTokenTypePrimitive(JsonTokenType tokenType)
		{
			return (int)(tokenType - 7) <= 4;
		}

		public static bool IsHexDigit(byte nextByte)
		{
			if ((uint)(nextByte - 48) > 9u && (uint)(nextByte - 65) > 5u)
			{
				return (uint)(nextByte - 97) <= 5u;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexOfQuoteOrAnyControlOrBackSlash(this ReadOnlySpan<byte> span)
		{
			return IndexOfOrLessThan(ref MemoryMarshal.GetReference(span), 34, 92, 32, span.Length);
		}

		private unsafe static int IndexOfOrLessThan(ref byte searchSpace, byte value0, byte value1, byte lessThan, int length)
		{
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)length;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count * 2)
			{
				int num = (int)Unsafe.AsPointer(ref searchSpace) & (Vector<byte>.Count - 1);
				intPtr2 = (IntPtr)((Vector<byte>.Count - num) & (Vector<byte>.Count - 1));
			}
			while (true)
			{
				if ((nuint)(void*)intPtr2 >= (nuint)8u)
				{
					intPtr2 -= 8;
					uint num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_0393;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 1);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_039b;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 2);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_03a9;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 3);
					if (value0 != num2 && value1 != num2 && lessThan <= num2)
					{
						num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 4);
						if (value0 != num2 && value1 != num2 && lessThan <= num2)
						{
							num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 5);
							if (value0 != num2 && value1 != num2 && lessThan <= num2)
							{
								num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 6);
								if (value0 != num2 && value1 != num2 && lessThan <= num2)
								{
									num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 7);
									if (value0 == num2 || value1 == num2 || lessThan > num2)
									{
										break;
									}
									intPtr += 8;
									continue;
								}
								return (int)(void*)(intPtr + 6);
							}
							return (int)(void*)(intPtr + 5);
						}
						return (int)(void*)(intPtr + 4);
					}
					goto IL_03b7;
				}
				if ((nuint)(void*)intPtr2 >= (nuint)4u)
				{
					intPtr2 -= 4;
					uint num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_0393;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 1);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_039b;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 2);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_03a9;
					}
					num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr + 3);
					if (value0 == num2 || value1 == num2 || lessThan > num2)
					{
						goto IL_03b7;
					}
					intPtr += 4;
				}
				while ((void*)intPtr2 != null)
				{
					intPtr2 -= 1;
					uint num2 = Unsafe.AddByteOffset(ref searchSpace, intPtr);
					if (value0 != num2 && value1 != num2 && lessThan <= num2)
					{
						intPtr += 1;
						continue;
					}
					goto IL_0393;
				}
				if (Vector.IsHardwareAccelerated && (int)(void*)intPtr < length)
				{
					intPtr2 = (IntPtr)((length - (int)(void*)intPtr) & ~(Vector<byte>.Count - 1));
					Vector<byte> right = new Vector<byte>(value0);
					Vector<byte> right2 = new Vector<byte>(value1);
					Vector<byte> right3 = new Vector<byte>(lessThan);
					for (; (void*)intPtr2 > (void*)intPtr; intPtr += Vector<byte>.Count)
					{
						Vector<byte> left = Unsafe.ReadUnaligned<Vector<byte>>(ref Unsafe.AddByteOffset(ref searchSpace, intPtr));
						Vector<byte> vector = Vector.BitwiseOr(Vector.BitwiseOr(Vector.Equals(left, right), Vector.Equals(left, right2)), Vector.LessThan(left, right3));
						if (!Vector<byte>.Zero.Equals(vector))
						{
							return (int)(void*)intPtr + LocateFirstFoundByte(vector);
						}
					}
					if ((int)(void*)intPtr < length)
					{
						intPtr2 = (IntPtr)(length - (int)(void*)intPtr);
						continue;
					}
				}
				return -1;
				IL_0393:
				return (int)(void*)intPtr;
				IL_039b:
				return (int)(void*)(intPtr + 1);
				IL_03b7:
				return (int)(void*)(intPtr + 3);
				IL_03a9:
				return (int)(void*)(intPtr + 2);
			}
			return (int)(void*)(intPtr + 7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundByte(Vector<byte> match)
		{
			Vector<ulong> vector = Vector.AsVectorUInt64(match);
			ulong num = 0uL;
			int i;
			for (i = 0; i < Vector<ulong>.Count; i++)
			{
				num = vector[i];
				if (num != 0L)
				{
					break;
				}
			}
			return i * 8 + LocateFirstFoundByte(num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LocateFirstFoundByte(ulong match)
		{
			ulong num = match ^ (match - 1);
			return (int)(num * 283686952306184L >> 57);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValidDateTimeOffsetParseLength(int length)
		{
			return JsonHelpers.IsInRangeInclusive(length, 10, 252);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValidDateTimeOffsetParseLength(long length)
		{
			return JsonHelpers.IsInRangeInclusive(length, 10L, 252L);
		}

		public static bool TryGetEscapedDateTime(ReadOnlySpan<byte> source, out DateTime value)
		{
			int idx = source.IndexOf((byte)92);
			Span<byte> span = stackalloc byte[source.Length];
			Unescape(source, span, idx, out var written);
			span = span.Slice(0, written);
			if (span.Length <= 42 && JsonHelpers.TryParseAsISO((ReadOnlySpan<byte>)span, out DateTime value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTime);
			return false;
		}

		public static bool TryGetEscapedDateTimeOffset(ReadOnlySpan<byte> source, out DateTimeOffset value)
		{
			int idx = source.IndexOf((byte)92);
			Span<byte> span = stackalloc byte[source.Length];
			Unescape(source, span, idx, out var written);
			span = span.Slice(0, written);
			if (span.Length <= 42 && JsonHelpers.TryParseAsISO((ReadOnlySpan<byte>)span, out DateTimeOffset value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTimeOffset);
			return false;
		}

		public static bool TryGetEscapedGuid(ReadOnlySpan<byte> source, out Guid value)
		{
			int idx = source.IndexOf((byte)92);
			Span<byte> span = stackalloc byte[source.Length];
			Unescape(source, span, idx, out var written);
			span = span.Slice(0, written);
			if (span.Length == 36 && Utf8Parser.TryParse((ReadOnlySpan<byte>)span, out Guid value2, out int _, 'D'))
			{
				value = value2;
				return true;
			}
			value = default(Guid);
			return false;
		}

		public static bool TryGetUnescapedBase64Bytes(ReadOnlySpan<byte> utf8Source, int idx, out byte[] bytes)
		{
			byte[] array = null;
			Span<byte> span = ((utf8Source.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(utf8Source.Length))) : stackalloc byte[utf8Source.Length]);
			Span<byte> span2 = span;
			Unescape(utf8Source, span2, idx, out var written);
			span2 = span2.Slice(0, written);
			bool result = TryDecodeBase64InPlace(span2, out bytes);
			if (array != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		public static string GetUnescapedString(ReadOnlySpan<byte> utf8Source, int idx)
		{
			byte[] array = null;
			Span<byte> span = ((utf8Source.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(utf8Source.Length))) : stackalloc byte[utf8Source.Length]);
			Span<byte> span2 = span;
			Unescape(utf8Source, span2, idx, out var written);
			span2 = span2.Slice(0, written);
			string result = TranscodeHelper(span2);
			if (array != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		public static bool UnescapeAndCompare(ReadOnlySpan<byte> utf8Source, ReadOnlySpan<byte> other)
		{
			byte[] array = null;
			Span<byte> span = ((utf8Source.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(utf8Source.Length))) : stackalloc byte[utf8Source.Length]);
			Span<byte> span2 = span;
			Unescape(utf8Source, span2, 0, out var written);
			span2 = span2.Slice(0, written);
			bool result = other.SequenceEqual(span2);
			if (array != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		public static bool UnescapeAndCompare(ReadOnlySequence<byte> utf8Source, ReadOnlySpan<byte> other)
		{
			byte[] array = null;
			byte[] array2 = null;
			int num = checked((int)utf8Source.Length);
			Span<byte> span = ((num > 256) ? ((Span<byte>)(array2 = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[num]);
			Span<byte> span2 = span;
			Span<byte> span3 = ((num > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[num]);
			Span<byte> span4 = span3;
			utf8Source.CopyTo(span4);
			span4 = span4.Slice(0, num);
			Unescape(span4, span2, 0, out var written);
			span2 = span2.Slice(0, written);
			bool result = other.SequenceEqual(span2);
			if (array2 != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array2);
				span4.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		public static bool TryDecodeBase64InPlace(Span<byte> utf8Unescaped, out byte[] bytes)
		{
			if (Base64.DecodeFromUtf8InPlace(utf8Unescaped, out var bytesWritten) != OperationStatus.Done)
			{
				bytes = null;
				return false;
			}
			bytes = utf8Unescaped.Slice(0, bytesWritten).ToArray();
			return true;
		}

		public static bool TryDecodeBase64(ReadOnlySpan<byte> utf8Unescaped, out byte[] bytes)
		{
			byte[] array = null;
			Span<byte> span = ((utf8Unescaped.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(utf8Unescaped.Length))) : stackalloc byte[utf8Unescaped.Length]);
			Span<byte> bytes2 = span;
			if (Base64.DecodeFromUtf8(utf8Unescaped, bytes2, out var _, out var bytesWritten) != OperationStatus.Done)
			{
				bytes = null;
				if (array != null)
				{
					bytes2.Clear();
					ArrayPool<byte>.Shared.Return(array);
				}
				return false;
			}
			bytes = bytes2.Slice(0, bytesWritten).ToArray();
			if (array != null)
			{
				bytes2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return true;
		}

		public unsafe static string TranscodeHelper(ReadOnlySpan<byte> utf8Unescaped)
		{
			try
			{
				if (utf8Unescaped.IsEmpty)
				{
					return string.Empty;
				}
				fixed (byte* bytes = utf8Unescaped)
				{
					return s_utf8Encoding.GetString(bytes, utf8Unescaped.Length);
				}
			}
			catch (DecoderFallbackException innerException)
			{
				throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(innerException);
			}
		}

		internal unsafe static int GetUtf8ByteCount(ReadOnlySpan<char> text)
		{
			try
			{
				if (text.IsEmpty)
				{
					return 0;
				}
				fixed (char* chars = text)
				{
					return s_utf8Encoding.GetByteCount(chars, text.Length);
				}
			}
			catch (EncoderFallbackException innerException)
			{
				throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(innerException);
			}
		}

		internal unsafe static int GetUtf8FromText(ReadOnlySpan<char> text, Span<byte> dest)
		{
			try
			{
				if (text.IsEmpty)
				{
					return 0;
				}
				fixed (char* chars = text)
				{
					fixed (byte* bytes = dest)
					{
						return s_utf8Encoding.GetBytes(chars, text.Length, bytes, dest.Length);
					}
				}
			}
			catch (EncoderFallbackException innerException)
			{
				throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(innerException);
			}
		}

		internal unsafe static string GetTextFromUtf8(ReadOnlySpan<byte> utf8Text)
		{
			if (utf8Text.IsEmpty)
			{
				return string.Empty;
			}
			fixed (byte* bytes = utf8Text)
			{
				return s_utf8Encoding.GetString(bytes, utf8Text.Length);
			}
		}

		internal static void Unescape(ReadOnlySpan<byte> source, Span<byte> destination, int idx, out int written)
		{
			source.Slice(0, idx).CopyTo(destination);
			written = idx;
			while (idx < source.Length)
			{
				byte b = source[idx];
				if (b == 92)
				{
					idx++;
					switch (source[idx])
					{
					case 34:
						destination[written++] = 34;
						break;
					case 110:
						destination[written++] = 10;
						break;
					case 114:
						destination[written++] = 13;
						break;
					case 92:
						destination[written++] = 92;
						break;
					case 47:
						destination[written++] = 47;
						break;
					case 116:
						destination[written++] = 9;
						break;
					case 98:
						destination[written++] = 8;
						break;
					case 102:
						destination[written++] = 12;
						break;
					case 117:
					{
						bool flag = Utf8Parser.TryParse(source.Slice(idx + 1, 4), out int value, out int bytesConsumed, 'x');
						idx += bytesConsumed;
						if (JsonHelpers.IsInRangeInclusive((uint)value, 55296u, 57343u))
						{
							if (value >= 56320)
							{
								ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(value);
							}
							idx += 3;
							if (source.Length < idx + 4 || source[idx - 2] != 92 || source[idx - 1] != 117)
							{
								ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16();
							}
							flag = Utf8Parser.TryParse(source.Slice(idx, 4), out int value2, out bytesConsumed, 'x');
							if (!JsonHelpers.IsInRangeInclusive((uint)value2, 56320u, 57343u))
							{
								ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(value2);
							}
							idx += bytesConsumed - 1;
							value = 1024 * (value - 55296) + (value2 - 56320) + 65536;
						}
						EncodeToUtf8Bytes((uint)value, destination.Slice(written), out var bytesWritten);
						written += bytesWritten;
						break;
					}
					}
				}
				else
				{
					destination[written++] = b;
				}
				idx++;
			}
		}

		private static void EncodeToUtf8Bytes(uint scalar, Span<byte> utf8Destination, out int bytesWritten)
		{
			if (scalar < 128)
			{
				utf8Destination[0] = (byte)scalar;
				bytesWritten = 1;
			}
			else if (scalar < 2048)
			{
				utf8Destination[0] = (byte)(0xC0 | (scalar >> 6));
				utf8Destination[1] = (byte)(0x80 | (scalar & 0x3F));
				bytesWritten = 2;
			}
			else if (scalar < 65536)
			{
				utf8Destination[0] = (byte)(0xE0 | (scalar >> 12));
				utf8Destination[1] = (byte)(0x80 | ((scalar >> 6) & 0x3F));
				utf8Destination[2] = (byte)(0x80 | (scalar & 0x3F));
				bytesWritten = 3;
			}
			else
			{
				utf8Destination[0] = (byte)(0xF0 | (scalar >> 18));
				utf8Destination[1] = (byte)(0x80 | ((scalar >> 12) & 0x3F));
				utf8Destination[2] = (byte)(0x80 | ((scalar >> 6) & 0x3F));
				utf8Destination[3] = (byte)(0x80 | (scalar & 0x3F));
				bytesWritten = 4;
			}
		}
	}
	[Serializable]
	internal sealed class JsonReaderException : JsonException
	{
		public JsonReaderException(string message, long lineNumber, long bytePositionInLine)
			: base(message, null, lineNumber, bytePositionInLine)
		{
		}

		private JsonReaderException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	public struct JsonReaderOptions
	{
		internal const int DefaultMaxDepth = 64;

		private int _maxDepth;

		private JsonCommentHandling _commentHandling;

		public JsonCommentHandling CommentHandling
		{
			readonly get
			{
				return _commentHandling;
			}
			set
			{
				if ((int)value > 2)
				{
					throw ThrowHelper.GetArgumentOutOfRangeException_CommentEnumMustBeInRange("value");
				}
				_commentHandling = value;
			}
		}

		public int MaxDepth
		{
			readonly get
			{
				return _maxDepth;
			}
			set
			{
				if (value < 0)
				{
					throw ThrowHelper.GetArgumentOutOfRangeException_MaxDepthMustBePositive("value");
				}
				_maxDepth = value;
			}
		}

		public bool AllowTrailingCommas { get; set; }
	}
	public struct JsonReaderState(JsonReaderOptions options = default(JsonReaderOptions))
	{
		internal long _lineNumber = 0L;

		internal long _bytePositionInLine = 0L;

		internal bool _inObject = false;

		internal bool _isNotPrimitive = false;

		internal char _numberFormat = '\0';

		internal bool _stringHasEscaping = false;

		internal bool _trailingCommaBeforeComment = false;

		internal JsonTokenType _tokenType = JsonTokenType.None;

		internal JsonTokenType _previousTokenType = JsonTokenType.None;

		internal JsonReaderOptions _readerOptions = options;

		internal BitStack _bitStack = default(BitStack);

		public JsonReaderOptions Options => _readerOptions;
	}
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public ref struct Utf8JsonReader
	{
		private readonly struct PartialStateForRollback(long totalConsumed, long bytePositionInLine, int consumed, SequencePosition currentPosition)
		{
			public readonly long _prevTotalConsumed = totalConsumed;

			public readonly long _prevBytePositionInLine = bytePositionInLine;

			public readonly int _prevConsumed = consumed;

			public readonly SequencePosition _prevCurrentPosition = currentPosition;

			public SequencePosition GetStartPosition(int offset = 0)
			{
				return new SequencePosition(_prevCurrentPosition.GetObject(), _prevCurrentPosition.GetInteger() + _prevConsumed + offset);
			}
		}

		private ReadOnlySpan<byte> _buffer;

		private bool _isFinalBlock;

		private bool _isInputSequence;

		private long _lineNumber;

		private long _bytePositionInLine;

		private int _consumed;

		private bool _inObject;

		private bool _isNotPrimitive;

		internal char _numberFormat;

		private JsonTokenType _tokenType;

		private JsonTokenType _previousTokenType;

		private JsonReaderOptions _readerOptions;

		private BitStack _bitStack;

		private long _totalConsumed;

		private bool _isLastSegment;

		internal bool _stringHasEscaping;

		private readonly bool _isMultiSegment;

		private bool _trailingCommaBeforeComment;

		private SequencePosition _nextPosition;

		private SequencePosition _currentPosition;

		private ReadOnlySequence<byte> _sequence;

		private bool IsLastSpan
		{
			get
			{
				if (_isFinalBlock)
				{
					if (_isMultiSegment)
					{
						return _isLastSegment;
					}
					return true;
				}
				return false;
			}
		}

		internal ReadOnlySequence<byte> OriginalSequence => _sequence;

		internal ReadOnlySpan<byte> OriginalSpan
		{
			get
			{
				if (!_sequence.IsEmpty)
				{
					return default(ReadOnlySpan<byte>);
				}
				return _buffer;
			}
		}

		public ReadOnlySpan<byte> ValueSpan { get; private set; }

		public long BytesConsumed => _totalConsumed + _consumed;

		public long TokenStartIndex { get; private set; }

		public int CurrentDepth
		{
			get
			{
				int num = _bitStack.CurrentDepth;
				if (TokenType == JsonTokenType.StartArray || TokenType == JsonTokenType.StartObject)
				{
					num--;
				}
				return num;
			}
		}

		internal bool IsInArray => !_inObject;

		public JsonTokenType TokenType => _tokenType;

		public bool HasValueSequence { get; private set; }

		public bool IsFinalBlock => _isFinalBlock;

		public ReadOnlySequence<byte> ValueSequence { get; private set; }

		public SequencePosition Position
		{
			get
			{
				if (_isInputSequence)
				{
					return _sequence.GetPosition(_consumed, _currentPosition);
				}
				return default(SequencePosition);
			}
		}

		public JsonReaderState CurrentState => new JsonReaderState
		{
			_lineNumber = _lineNumber,
			_bytePositionInLine = _bytePositionInLine,
			_inObject = _inObject,
			_isNotPrimitive = _isNotPrimitive,
			_numberFormat = _numberFormat,
			_stringHasEscaping = _stringHasEscaping,
			_trailingCommaBeforeComment = _trailingCommaBeforeComment,
			_tokenType = _tokenType,
			_previousTokenType = _previousTokenType,
			_readerOptions = _readerOptions,
			_bitStack = _bitStack
		};

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string DebuggerDisplay => $"TokenType = {DebugTokenType} (TokenStartIndex = {TokenStartIndex}) Consumed = {BytesConsumed}";

		private string DebugTokenType => TokenType switch
		{
			JsonTokenType.Comment => "Comment", 
			JsonTokenType.EndArray => "EndArray", 
			JsonTokenType.EndObject => "EndObject", 
			JsonTokenType.False => "False", 
			JsonTokenType.None => "None", 
			JsonTokenType.Null => "Null", 
			JsonTokenType.Number => "Number", 
			JsonTokenType.PropertyName => "PropertyName", 
			JsonTokenType.StartArray => "StartArray", 
			JsonTokenType.StartObject => "StartObject", 
			JsonTokenType.String => "String", 
			JsonTokenType.True => "True", 
			_ => ((byte)TokenType).ToString(), 
		};

		public Utf8JsonReader(ReadOnlySpan<byte> jsonData, bool isFinalBlock, JsonReaderState state)
		{
			_buffer = jsonData;
			_isFinalBlock = isFinalBlock;
			_isInputSequence = false;
			_lineNumber = state._lineNumber;
			_bytePositionInLine = state._bytePositionInLine;
			_inObject = state._inObject;
			_isNotPrimitive = state._isNotPrimitive;
			_numberFormat = state._numberFormat;
			_stringHasEscaping = state._stringHasEscaping;
			_trailingCommaBeforeComment = state._trailingCommaBeforeComment;
			_tokenType = state._tokenType;
			_previousTokenType = state._previousTokenType;
			_readerOptions = state._readerOptions;
			if (_readerOptions.MaxDepth == 0)
			{
				_readerOptions.MaxDepth = 64;
			}
			_bitStack = state._bitStack;
			_consumed = 0;
			TokenStartIndex = 0L;
			_totalConsumed = 0L;
			_isLastSegment = _isFinalBlock;
			_isMultiSegment = false;
			ValueSpan = ReadOnlySpan<byte>.Empty;
			_currentPosition = default(SequencePosition);
			_nextPosition = default(SequencePosition);
			_sequence = default(ReadOnlySequence<byte>);
			HasValueSequence = false;
			ValueSequence = ReadOnlySequence<byte>.Empty;
		}

		public Utf8JsonReader(ReadOnlySpan<byte> jsonData, JsonReaderOptions options = default(JsonReaderOptions))
		{
			this = new Utf8JsonReader(jsonData, isFinalBlock: true, new JsonReaderState(options));
		}

		public bool Read()
		{
			bool flag = (_isMultiSegment ? ReadMultiSegment() : ReadSingleSegment());
			if (!flag && _isFinalBlock && TokenType == JsonTokenType.None)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedJsonTokens, 0);
			}
			return flag;
		}

		public void Skip()
		{
			if (!_isFinalBlock)
			{
				throw ThrowHelper.GetInvalidOperationException_CannotSkipOnPartial();
			}
			SkipHelper();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SkipHelper()
		{
			if (TokenType == JsonTokenType.PropertyName)
			{
				bool flag = Read();
			}
			if (TokenType == JsonTokenType.StartObject || TokenType == JsonTokenType.StartArray)
			{
				int currentDepth = CurrentDepth;
				do
				{
					bool flag2 = Read();
				}
				while (currentDepth < CurrentDepth);
			}
		}

		public bool TrySkip()
		{
			if (_isFinalBlock)
			{
				SkipHelper();
				return true;
			}
			return TrySkipHelper();
		}

		private bool TrySkipHelper()
		{
			Utf8JsonReader utf8JsonReader = this;
			if (TokenType != JsonTokenType.PropertyName || Read())
			{
				if (TokenType != JsonTokenType.StartObject && TokenType != JsonTokenType.StartArray)
				{
					goto IL_0042;
				}
				int currentDepth = CurrentDepth;
				while (Read())
				{
					if (currentDepth < CurrentDepth)
					{
						continue;
					}
					goto IL_0042;
				}
			}
			this = utf8JsonReader;
			return false;
			IL_0042:
			return true;
		}

		public bool ValueTextEquals(ReadOnlySpan<byte> utf8Text)
		{
			if (!IsTokenTypeString(TokenType))
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedStringComparison(TokenType);
			}
			return TextEqualsHelper(utf8Text);
		}

		public bool ValueTextEquals(string text)
		{
			return ValueTextEquals(text.AsSpan());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool TextEqualsHelper(ReadOnlySpan<byte> otherUtf8Text)
		{
			if (HasValueSequence)
			{
				return CompareToSequence(otherUtf8Text);
			}
			if (_stringHasEscaping)
			{
				return UnescapeAndCompare(otherUtf8Text);
			}
			return otherUtf8Text.SequenceEqual(ValueSpan);
		}

		public unsafe bool ValueTextEquals(ReadOnlySpan<char> text)
		{
			if (!IsTokenTypeString(TokenType))
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedStringComparison(TokenType);
			}
			if (MatchNotPossible(text.Length))
			{
				return false;
			}
			byte[] array = null;
			int num = checked(text.Length * 3);
			Span<byte> utf8Destination;
			if (num > 256)
			{
				array = ArrayPool<byte>.Shared.Rent(num);
				utf8Destination = array;
			}
			else
			{
				byte* pointer = stackalloc byte[256];
				utf8Destination = new Span<byte>(pointer, 256);
			}
			ReadOnlySpan<byte> utf16Source = MemoryMarshal.AsBytes(text);
			int bytesConsumed;
			int bytesWritten;
			OperationStatus operationStatus = JsonWriterHelper.ToUtf8(utf16Source, utf8Destination, out bytesConsumed, out bytesWritten);
			bool result = operationStatus <= OperationStatus.DestinationTooSmall && TextEqualsHelper(utf8Destination.Slice(0, bytesWritten));
			if (array != null)
			{
				utf8Destination.Slice(0, bytesWritten).Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		private bool CompareToSequence(ReadOnlySpan<byte> other)
		{
			if (_stringHasEscaping)
			{
				return UnescapeSequenceAndCompare(other);
			}
			ReadOnlySequence<byte> valueSequence = ValueSequence;
			if (valueSequence.Length != other.Length)
			{
				return false;
			}
			int num = 0;
			ReadOnlySequence<byte>.Enumerator enumerator = valueSequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ReadOnlySpan<byte> span = enumerator.Current.Span;
				if (other.Slice(num).StartsWith(span))
				{
					num += span.Length;
					continue;
				}
				return false;
			}
			return true;
		}

		private bool UnescapeAndCompare(ReadOnlySpan<byte> other)
		{
			ReadOnlySpan<byte> valueSpan = ValueSpan;
			if (valueSpan.Length < other.Length || valueSpan.Length / 6 > other.Length)
			{
				return false;
			}
			int num = valueSpan.IndexOf((byte)92);
			if (!other.StartsWith(valueSpan.Slice(0, num)))
			{
				return false;
			}
			return JsonReaderHelper.UnescapeAndCompare(valueSpan.Slice(num), other.Slice(num));
		}

		private bool UnescapeSequenceAndCompare(ReadOnlySpan<byte> other)
		{
			ReadOnlySequence<byte> valueSequence = ValueSequence;
			long length = valueSequence.Length;
			if (length < other.Length || length / 6 > other.Length)
			{
				return false;
			}
			int num = 0;
			bool result = false;
			ReadOnlySequence<byte>.Enumerator enumerator = valueSequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ReadOnlySpan<byte> span = enumerator.Current.Span;
				int num2 = span.IndexOf((byte)92);
				if (num2 != -1)
				{
					if (other.Slice(num).StartsWith(span.Slice(0, num2)))
					{
						num += num2;
						other = other.Slice(num);
						valueSequence = valueSequence.Slice(num);
						result = ((!valueSequence.IsSingleSegment) ? JsonReaderHelper.UnescapeAndCompare(valueSequence, other) : JsonReaderHelper.UnescapeAndCompare(valueSequence.First.Span, other));
					}
					break;
				}
				if (!other.Slice(num).StartsWith(span))
				{
					break;
				}
				num += span.Length;
			}
			return result;
		}

		private static bool IsTokenTypeString(JsonTokenType tokenType)
		{
			if (tokenType != JsonTokenType.PropertyName)
			{
				return tokenType == JsonTokenType.String;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool MatchNotPossible(int charTextLength)
		{
			if (HasValueSequence)
			{
				return MatchNotPossibleSequence(charTextLength);
			}
			int length = ValueSpan.Length;
			if (length < charTextLength || length / (_stringHasEscaping ? 6 : 3) > charTextLength)
			{
				return true;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MatchNotPossibleSequence(int charTextLength)
		{
			long length = ValueSequence.Length;
			if (length < charTextLength || length / (_stringHasEscaping ? 6 : 3) > charTextLength)
			{
				return true;
			}
			return false;
		}

		private void StartObject()
		{
			if (_bitStack.CurrentDepth >= _readerOptions.MaxDepth)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ObjectDepthTooLarge, 0);
			}
			_bitStack.PushTrue();
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_tokenType = JsonTokenType.StartObject;
			_inObject = true;
		}

		private void EndObject()
		{
			if (!_inObject || _bitStack.CurrentDepth <= 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.MismatchedObjectArray, 125);
			}
			if (_trailingCommaBeforeComment)
			{
				if (!_readerOptions.AllowTrailingCommas)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
				}
				_trailingCommaBeforeComment = false;
			}
			_tokenType = JsonTokenType.EndObject;
			ValueSpan = _buffer.Slice(_consumed, 1);
			UpdateBitStackOnEndToken();
		}

		private void StartArray()
		{
			if (_bitStack.CurrentDepth >= _readerOptions.MaxDepth)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ArrayDepthTooLarge, 0);
			}
			_bitStack.PushFalse();
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_tokenType = JsonTokenType.StartArray;
			_inObject = false;
		}

		private void EndArray()
		{
			if (_inObject || _bitStack.CurrentDepth <= 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.MismatchedObjectArray, 93);
			}
			if (_trailingCommaBeforeComment)
			{
				if (!_readerOptions.AllowTrailingCommas)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
				}
				_trailingCommaBeforeComment = false;
			}
			_tokenType = JsonTokenType.EndArray;
			ValueSpan = _buffer.Slice(_consumed, 1);
			UpdateBitStackOnEndToken();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateBitStackOnEndToken()
		{
			_consumed++;
			_bytePositionInLine++;
			_inObject = _bitStack.Pop();
		}

		private bool ReadSingleSegment()
		{
			bool flag = false;
			ValueSpan = default(ReadOnlySpan<byte>);
			if (HasMoreData())
			{
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData())
					{
						goto IL_0132;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = _consumed;
				if (_tokenType != JsonTokenType.None)
				{
					if (b == 47)
					{
						flag = ConsumeNextTokenOrRollback(b);
					}
					else if (_tokenType == JsonTokenType.StartObject)
					{
						if (b == 125)
						{
							EndObject();
							goto IL_0130;
						}
						if (b != 34)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
						}
						int consumed = _consumed;
						long bytePositionInLine = _bytePositionInLine;
						long lineNumber = _lineNumber;
						flag = ConsumePropertyName();
						if (!flag)
						{
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
						}
					}
					else if (_tokenType != JsonTokenType.StartArray)
					{
						flag = ((_tokenType != JsonTokenType.PropertyName) ? ConsumeNextTokenOrRollback(b) : ConsumeValue(b));
					}
					else
					{
						if (b == 93)
						{
							EndArray();
							goto IL_0130;
						}
						flag = ConsumeValue(b);
					}
				}
				else
				{
					flag = ReadFirstToken(b);
				}
			}
			goto IL_0132;
			IL_0132:
			return flag;
			IL_0130:
			flag = true;
			goto IL_0132;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasMoreData()
		{
			if (_consumed >= (uint)_buffer.Length)
			{
				if (_isNotPrimitive && IsLastSpan)
				{
					if (_bitStack.CurrentDepth != 0)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ZeroDepthAtEnd, 0);
					}
					if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && _tokenType == JsonTokenType.Comment)
					{
						return false;
					}
					if (_tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
					}
				}
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasMoreData(ExceptionResource resource)
		{
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, resource, 0);
				}
				return false;
			}
			return true;
		}

		private bool ReadFirstToken(byte first)
		{
			switch (first)
			{
			case 123:
				_bitStack.SetFirstBit();
				_tokenType = JsonTokenType.StartObject;
				ValueSpan = _buffer.Slice(_consumed, 1);
				_consumed++;
				_bytePositionInLine++;
				_inObject = true;
				_isNotPrimitive = true;
				break;
			case 91:
				_bitStack.ResetFirstBit();
				_tokenType = JsonTokenType.StartArray;
				ValueSpan = _buffer.Slice(_consumed, 1);
				_consumed++;
				_bytePositionInLine++;
				_isNotPrimitive = true;
				break;
			default:
			{
				ReadOnlySpan<byte> buffer = _buffer;
				if (JsonHelpers.IsDigit(first) || first == 45)
				{
					if (!TryGetNumber(buffer.Slice(_consumed), out var consumed))
					{
						return false;
					}
					_tokenType = JsonTokenType.Number;
					_consumed += consumed;
					_bytePositionInLine += consumed;
					return true;
				}
				if (!ConsumeValue(first))
				{
					return false;
				}
				if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
				{
					_isNotPrimitive = true;
				}
				break;
			}
			}
			return true;
		}

		private void SkipWhiteSpace()
		{
			ReadOnlySpan<byte> buffer = _buffer;
			while (_consumed < buffer.Length)
			{
				byte b = buffer[_consumed];
				if (b == 32 || b == 13 || b == 10 || b == 9)
				{
					if (b == 10)
					{
						_lineNumber++;
						_bytePositionInLine = 0L;
					}
					else
					{
						_bytePositionInLine++;
					}
					_consumed++;
					continue;
				}
				break;
			}
		}

		private bool ConsumeValue(byte marker)
		{
			while (true)
			{
				_trailingCommaBeforeComment = false;
				switch (marker)
				{
				case 34:
					return ConsumeString();
				case 123:
					StartObject();
					break;
				case 91:
					StartArray();
					break;
				default:
					if (JsonHelpers.IsDigit(marker) || marker == 45)
					{
						return ConsumeNumber();
					}
					switch (marker)
					{
					case 102:
						return ConsumeLiteral(JsonConstants.FalseValue, JsonTokenType.False);
					case 116:
						return ConsumeLiteral(JsonConstants.TrueValue, JsonTokenType.True);
					case 110:
						return ConsumeLiteral(JsonConstants.NullValue, JsonTokenType.Null);
					}
					switch (_readerOptions.CommentHandling)
					{
					case JsonCommentHandling.Allow:
						if (marker == 47)
						{
							return ConsumeComment();
						}
						break;
					default:
						if (marker != 47)
						{
							break;
						}
						if (SkipComment())
						{
							if (_consumed >= (uint)_buffer.Length)
							{
								if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
								}
								return false;
							}
							marker = _buffer[_consumed];
							if (marker <= 32)
							{
								SkipWhiteSpace();
								if (!HasMoreData())
								{
									return false;
								}
								marker = _buffer[_consumed];
							}
							goto IL_0140;
						}
						return false;
					case JsonCommentHandling.Disallow:
						break;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, marker);
					break;
				}
				break;
				IL_0140:
				TokenStartIndex = _consumed;
			}
			return true;
		}

		private bool ConsumeLiteral(ReadOnlySpan<byte> literal, JsonTokenType tokenType)
		{
			ReadOnlySpan<byte> span = _buffer.Slice(_consumed);
			if (!span.StartsWith(literal))
			{
				return CheckLiteral(span, literal);
			}
			ValueSpan = span.Slice(0, literal.Length);
			_tokenType = tokenType;
			_consumed += literal.Length;
			_bytePositionInLine += literal.Length;
			return true;
		}

		private bool CheckLiteral(ReadOnlySpan<byte> span, ReadOnlySpan<byte> literal)
		{
			int num = 0;
			for (int i = 1; i < literal.Length; i++)
			{
				if (span.Length > i)
				{
					if (span[i] != literal[i])
					{
						_bytePositionInLine += i;
						ThrowInvalidLiteral(span);
					}
					continue;
				}
				num = i;
				break;
			}
			if (IsLastSpan)
			{
				_bytePositionInLine += num;
				ThrowInvalidLiteral(span);
			}
			return false;
		}

		private void ThrowInvalidLiteral(ReadOnlySpan<byte> span)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, span[0] switch
			{
				116 => ExceptionResource.ExpectedTrue, 
				102 => ExceptionResource.ExpectedFalse, 
				_ => ExceptionResource.ExpectedNull, 
			}, 0, span);
		}

		private bool ConsumeNumber()
		{
			if (!TryGetNumber(_buffer.Slice(_consumed), out var consumed))
			{
				return false;
			}
			_tokenType = JsonTokenType.Number;
			_consumed += consumed;
			_bytePositionInLine += consumed;
			if (_consumed >= (uint)_buffer.Length && _isNotPrimitive)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, _buffer[_consumed - 1]);
			}
			return true;
		}

		private bool ConsumePropertyName()
		{
			_trailingCommaBeforeComment = false;
			if (!ConsumeString())
			{
				return false;
			}
			if (!HasMoreData(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
			{
				return false;
			}
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpace();
				if (!HasMoreData(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
				{
					return false;
				}
				b = _buffer[_consumed];
			}
			if (b != 58)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound, b);
			}
			_consumed++;
			_bytePositionInLine++;
			_tokenType = JsonTokenType.PropertyName;
			return true;
		}

		private bool ConsumeString()
		{
			ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
			int num = readOnlySpan.IndexOfQuoteOrAnyControlOrBackSlash();
			if (num >= 0)
			{
				byte b = readOnlySpan[num];
				if (b == 34)
				{
					_bytePositionInLine += num + 2;
					ValueSpan = readOnlySpan.Slice(0, num);
					_stringHasEscaping = false;
					_tokenType = JsonTokenType.String;
					_consumed += num + 2;
					return true;
				}
				return ConsumeStringAndValidate(readOnlySpan, num);
			}
			if (IsLastSpan)
			{
				_bytePositionInLine += readOnlySpan.Length + 1;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
			}
			return false;
		}

		private bool ConsumeStringAndValidate(ReadOnlySpan<byte> data, int idx)
		{
			long bytePositionInLine = _bytePositionInLine;
			long lineNumber = _lineNumber;
			_bytePositionInLine += idx + 1;
			bool flag = false;
			while (true)
			{
				if (idx < data.Length)
				{
					byte b = data[idx];
					if (b == 34)
					{
						if (!flag)
						{
							break;
						}
						flag = false;
					}
					else if (b == 92)
					{
						flag = !flag;
					}
					else if (flag)
					{
						int num = JsonConstants.EscapableChars.IndexOf(b);
						if (num == -1)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b);
						}
						if (b == 117)
						{
							_bytePositionInLine++;
							if (!ValidateHexDigits(data, idx + 1))
							{
								idx = data.Length;
								goto IL_00e5;
							}
							idx += 4;
						}
						flag = false;
					}
					else if (b < 32)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b);
					}
					_bytePositionInLine++;
					idx++;
					continue;
				}
				goto IL_00e5;
				IL_00e5:
				if (idx < data.Length)
				{
					break;
				}
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
				}
				_lineNumber = lineNumber;
				_bytePositionInLine = bytePositionInLine;
				return false;
			}
			_bytePositionInLine++;
			ValueSpan = data.Slice(0, idx);
			_stringHasEscaping = true;
			_tokenType = JsonTokenType.String;
			_consumed += idx + 2;
			return true;
		}

		private bool ValidateHexDigits(ReadOnlySpan<byte> data, int idx)
		{
			for (int i = idx; i < data.Length; i++)
			{
				byte nextByte = data[i];
				if (!JsonReaderHelper.IsHexDigit(nextByte))
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, nextByte);
				}
				if (i - idx >= 3)
				{
					return true;
				}
				_bytePositionInLine++;
			}
			return false;
		}

		private bool TryGetNumber(ReadOnlySpan<byte> data, out int consumed)
		{
			_numberFormat = '\0';
			consumed = 0;
			int i = 0;
			ConsumeNumberResult consumeNumberResult = ConsumeNegativeSign(ref data, ref i);
			if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
			{
				return false;
			}
			byte b = data[i];
			if (b == 48)
			{
				ConsumeNumberResult consumeNumberResult2 = ConsumeZero(ref data, ref i);
				if (consumeNumberResult2 == ConsumeNumberResult.NeedMoreData)
				{
					return false;
				}
				if (consumeNumberResult2 != ConsumeNumberResult.Success)
				{
					b = data[i];
					goto IL_00aa;
				}
			}
			else
			{
				i++;
				ConsumeNumberResult consumeNumberResult3 = ConsumeIntegerDigits(ref data, ref i);
				if (consumeNumberResult3 == ConsumeNumberResult.NeedMoreData)
				{
					return false;
				}
				if (consumeNumberResult3 != ConsumeNumberResult.Success)
				{
					b = data[i];
					if (b != 46 && b != 69 && b != 101)
					{
						_bytePositionInLine += i;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, b);
					}
					goto IL_00aa;
				}
			}
			goto IL_0161;
			IL_00aa:
			if (b == 46)
			{
				i++;
				ConsumeNumberResult consumeNumberResult4 = ConsumeDecimalDigits(ref data, ref i);
				if (consumeNumberResult4 == ConsumeNumberResult.NeedMoreData)
				{
					return false;
				}
				if (consumeNumberResult4 == ConsumeNumberResult.Success)
				{
					goto IL_0161;
				}
				b = data[i];
				if (b != 69 && b != 101)
				{
					_bytePositionInLine += i;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedNextDigitEValueNotFound, b);
				}
			}
			i++;
			_numberFormat = 'e';
			consumeNumberResult = ConsumeSign(ref data, ref i);
			if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
			{
				return false;
			}
			i++;
			switch (ConsumeIntegerDigits(ref data, ref i))
			{
			case ConsumeNumberResult.NeedMoreData:
				return false;
			default:
				_bytePositionInLine += i;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, data[i]);
				break;
			case ConsumeNumberResult.Success:
				break;
			}
			goto IL_0161;
			IL_0161:
			ValueSpan = data.Slice(0, i);
			consumed = i;
			return true;
		}

		private ConsumeNumberResult ConsumeNegativeSign(ref ReadOnlySpan<byte> data, ref int i)
		{
			byte b = data[i];
			if (b == 45)
			{
				i++;
				if (i >= data.Length)
				{
					if (IsLastSpan)
					{
						_bytePositionInLine += i;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				b = data[i];
				if (!JsonHelpers.IsDigit(b))
				{
					_bytePositionInLine += i;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
				}
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private ConsumeNumberResult ConsumeZero(ref ReadOnlySpan<byte> data, ref int i)
		{
			i++;
			byte b = 0;
			if (i < data.Length)
			{
				b = data[i];
				if (JsonConstants.Delimiters.IndexOf(b) >= 0)
				{
					return ConsumeNumberResult.Success;
				}
				b = data[i];
				if (b != 46 && b != 69 && b != 101)
				{
					_bytePositionInLine += i;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, b);
				}
				return ConsumeNumberResult.OperationIncomplete;
			}
			if (IsLastSpan)
			{
				return ConsumeNumberResult.Success;
			}
			return ConsumeNumberResult.NeedMoreData;
		}

		private ConsumeNumberResult ConsumeIntegerDigits(ref ReadOnlySpan<byte> data, ref int i)
		{
			byte value = 0;
			while (i < data.Length)
			{
				value = data[i];
				if (!JsonHelpers.IsDigit(value))
				{
					break;
				}
				i++;
			}
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					return ConsumeNumberResult.Success;
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			if (JsonConstants.Delimiters.IndexOf(value) >= 0)
			{
				return ConsumeNumberResult.Success;
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private ConsumeNumberResult ConsumeDecimalDigits(ref ReadOnlySpan<byte> data, ref int i)
		{
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += i;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			byte b = data[i];
			if (!JsonHelpers.IsDigit(b))
			{
				_bytePositionInLine += i;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterDecimal, b);
			}
			i++;
			return ConsumeIntegerDigits(ref data, ref i);
		}

		private ConsumeNumberResult ConsumeSign(ref ReadOnlySpan<byte> data, ref int i)
		{
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += i;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			byte b = data[i];
			if (b == 43 || b == 45)
			{
				i++;
				if (i >= data.Length)
				{
					if (IsLastSpan)
					{
						_bytePositionInLine += i;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				b = data[i];
			}
			if (!JsonHelpers.IsDigit(b))
			{
				_bytePositionInLine += i;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private bool ConsumeNextTokenOrRollback(byte marker)
		{
			int consumed = _consumed;
			long bytePositionInLine = _bytePositionInLine;
			long lineNumber = _lineNumber;
			JsonTokenType tokenType = _tokenType;
			bool trailingCommaBeforeComment = _trailingCommaBeforeComment;
			switch (ConsumeNextToken(marker))
			{
			case ConsumeTokenResult.Success:
				return true;
			case ConsumeTokenResult.NotEnoughDataRollBackState:
				_consumed = consumed;
				_tokenType = tokenType;
				_bytePositionInLine = bytePositionInLine;
				_lineNumber = lineNumber;
				_trailingCommaBeforeComment = trailingCommaBeforeComment;
				break;
			}
			return false;
		}

		private ConsumeTokenResult ConsumeNextToken(byte marker)
		{
			if (_readerOptions.CommentHandling != JsonCommentHandling.Disallow)
			{
				if (_readerOptions.CommentHandling != JsonCommentHandling.Allow)
				{
					return ConsumeNextTokenUntilAfterAllCommentsAreSkipped(marker);
				}
				if (marker == 47)
				{
					if (!ConsumeComment())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (_tokenType == JsonTokenType.Comment)
				{
					return ConsumeNextTokenFromLastNonCommentToken();
				}
			}
			if (_bitStack.CurrentDepth == 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, marker);
			}
			switch (marker)
			{
			case 44:
			{
				_consumed++;
				_bytePositionInLine++;
				if (_consumed >= (uint)_buffer.Length)
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = _consumed;
				if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && b == 47)
				{
					_trailingCommaBeforeComment = true;
					if (!ConsumeComment())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (_inObject)
				{
					if (b != 34)
					{
						if (b == 125)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndObject();
								return ConsumeTokenResult.Success;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					if (!ConsumePropertyName())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (b == 93)
				{
					if (_readerOptions.AllowTrailingCommas)
					{
						EndArray();
						return ConsumeTokenResult.Success;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
				}
				if (!ConsumeValue(b))
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			case 125:
				EndObject();
				break;
			case 93:
				EndArray();
				break;
			default:
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, marker);
				break;
			}
			return ConsumeTokenResult.Success;
		}

		private ConsumeTokenResult ConsumeNextTokenFromLastNonCommentToken()
		{
			if (JsonReaderHelper.IsTokenTypePrimitive(_previousTokenType))
			{
				_tokenType = (_inObject ? JsonTokenType.StartObject : JsonTokenType.StartArray);
			}
			else
			{
				_tokenType = _previousTokenType;
			}
			if (HasMoreData())
			{
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData())
					{
						goto IL_0343;
					}
					b = _buffer[_consumed];
				}
				if (_bitStack.CurrentDepth == 0 && _tokenType != JsonTokenType.None)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, b);
				}
				TokenStartIndex = _consumed;
				if (b != 44)
				{
					if (b == 125)
					{
						EndObject();
					}
					else
					{
						if (b != 93)
						{
							if (_tokenType == JsonTokenType.None)
							{
								if (ReadFirstToken(b))
								{
									goto IL_0341;
								}
							}
							else if (_tokenType == JsonTokenType.StartObject)
							{
								if (b != 34)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
								}
								int consumed = _consumed;
								long bytePositionInLine = _bytePositionInLine;
								long lineNumber = _lineNumber;
								if (ConsumePropertyName())
								{
									goto IL_0341;
								}
								_consumed = consumed;
								_tokenType = JsonTokenType.StartObject;
								_bytePositionInLine = bytePositionInLine;
								_lineNumber = lineNumber;
							}
							else if (_tokenType == JsonTokenType.StartArray)
							{
								if (ConsumeValue(b))
								{
									goto IL_0341;
								}
							}
							else if (_tokenType == JsonTokenType.PropertyName)
							{
								if (ConsumeValue(b))
								{
									goto IL_0341;
								}
							}
							else if (_inObject)
							{
								if (b != 34)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
								}
								if (ConsumePropertyName())
								{
									goto IL_0341;
								}
							}
							else if (ConsumeValue(b))
							{
								goto IL_0341;
							}
							goto IL_0343;
						}
						EndArray();
					}
					goto IL_0341;
				}
				if ((int)_previousTokenType <= 1 || _previousTokenType == JsonTokenType.StartArray || _trailingCommaBeforeComment)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment, b);
				}
				_consumed++;
				_bytePositionInLine++;
				if (_consumed >= (uint)_buffer.Length)
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
				}
				else
				{
					b = _buffer[_consumed];
					if (b <= 32)
					{
						SkipWhiteSpace();
						if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
						{
							goto IL_0343;
						}
						b = _buffer[_consumed];
					}
					TokenStartIndex = _consumed;
					if (b == 47)
					{
						_trailingCommaBeforeComment = true;
						if (ConsumeComment())
						{
							goto IL_0341;
						}
					}
					else if (_inObject)
					{
						if (b != 34)
						{
							if (b == 125)
							{
								if (_readerOptions.AllowTrailingCommas)
								{
									EndObject();
									goto IL_0341;
								}
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
						}
						if (ConsumePropertyName())
						{
							goto IL_0341;
						}
					}
					else
					{
						if (b == 93)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndArray();
								goto IL_0341;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
						}
						if (ConsumeValue(b))
						{
							goto IL_0341;
						}
					}
				}
			}
			goto IL_0343;
			IL_0343:
			return ConsumeTokenResult.NotEnoughDataRollBackState;
			IL_0341:
			return ConsumeTokenResult.Success;
		}

		private bool SkipAllComments(ref byte marker)
		{
			while (true)
			{
				if (marker == 47)
				{
					if (!SkipComment() || !HasMoreData())
					{
						break;
					}
					marker = _buffer[_consumed];
					if (marker <= 32)
					{
						SkipWhiteSpace();
						if (!HasMoreData())
						{
							break;
						}
						marker = _buffer[_consumed];
					}
					continue;
				}
				return true;
			}
			return false;
		}

		private bool SkipAllComments(ref byte marker, ExceptionResource resource)
		{
			while (true)
			{
				if (marker == 47)
				{
					if (!SkipComment() || !HasMoreData(resource))
					{
						break;
					}
					marker = _buffer[_consumed];
					if (marker <= 32)
					{
						SkipWhiteSpace();
						if (!HasMoreData(resource))
						{
							break;
						}
						marker = _buffer[_consumed];
					}
					continue;
				}
				return true;
			}
			return false;
		}

		private ConsumeTokenResult ConsumeNextTokenUntilAfterAllCommentsAreSkipped(byte marker)
		{
			if (SkipAllComments(ref marker))
			{
				TokenStartIndex = _consumed;
				if (_tokenType == JsonTokenType.StartObject)
				{
					if (marker == 125)
					{
						EndObject();
					}
					else
					{
						if (marker != 34)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, marker);
						}
						int consumed = _consumed;
						long bytePositionInLine = _bytePositionInLine;
						long lineNumber = _lineNumber;
						if (!ConsumePropertyName())
						{
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
							goto IL_0281;
						}
					}
				}
				else if (_tokenType == JsonTokenType.StartArray)
				{
					if (marker == 93)
					{
						EndArray();
					}
					else if (!ConsumeValue(marker))
					{
						goto IL_0281;
					}
				}
				else if (_tokenType == JsonTokenType.PropertyName)
				{
					if (!ConsumeValue(marker))
					{
						goto IL_0281;
					}
				}
				else if (_bitStack.CurrentDepth == 0)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, marker);
				}
				else
				{
					switch (marker)
					{
					case 44:
						_consumed++;
						_bytePositionInLine++;
						if (_consumed >= (uint)_buffer.Length)
						{
							if (IsLastSpan)
							{
								_consumed--;
								_bytePositionInLine--;
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
							}
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
						marker = _buffer[_consumed];
						if (marker <= 32)
						{
							SkipWhiteSpace();
							if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							marker = _buffer[_consumed];
						}
						if (SkipAllComments(ref marker, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
						{
							TokenStartIndex = _consumed;
							if (_inObject)
							{
								if (marker != 34)
								{
									if (marker == 125)
									{
										if (_readerOptions.AllowTrailingCommas)
										{
											EndObject();
											break;
										}
										ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
									}
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, marker);
								}
								if (!ConsumePropertyName())
								{
									return ConsumeTokenResult.NotEnoughDataRollBackState;
								}
								return ConsumeTokenResult.Success;
							}
							if (marker == 93)
							{
								if (_readerOptions.AllowTrailingCommas)
								{
									EndArray();
									break;
								}
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
							}
							if (!ConsumeValue(marker))
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							return ConsumeTokenResult.Success;
						}
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					case 125:
						EndObject();
						break;
					case 93:
						EndArray();
						break;
					default:
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, marker);
						break;
					}
				}
				return ConsumeTokenResult.Success;
			}
			goto IL_0281;
			IL_0281:
			return ConsumeTokenResult.IncompleteNoRollBackNecessary;
		}

		private bool SkipComment()
		{
			ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
			if (readOnlySpan.Length > 0)
			{
				int idx;
				switch (readOnlySpan[0])
				{
				case 47:
					return SkipSingleLineComment(readOnlySpan.Slice(1), out idx);
				case 42:
					return SkipMultiLineComment(readOnlySpan.Slice(1), out idx);
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, 47);
			}
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, 47);
			}
			return false;
		}

		private bool SkipSingleLineComment(ReadOnlySpan<byte> localBuffer, out int idx)
		{
			idx = FindLineSeparator(localBuffer);
			int num = 0;
			if (idx != -1)
			{
				num = idx;
				if (localBuffer[idx] != 10)
				{
					if (idx < localBuffer.Length - 1)
					{
						if (localBuffer[idx + 1] == 10)
						{
							num++;
						}
					}
					else if (!IsLastSpan)
					{
						return false;
					}
				}
				num++;
				_bytePositionInLine = 0L;
				_lineNumber++;
			}
			else
			{
				if (!IsLastSpan)
				{
					return false;
				}
				idx = localBuffer.Length;
				num = idx;
				_bytePositionInLine += 2 + localBuffer.Length;
			}
			_consumed += 2 + num;
			return true;
		}

		private int FindLineSeparator(ReadOnlySpan<byte> localBuffer)
		{
			int num = 0;
			while (true)
			{
				int num2 = localBuffer.IndexOfAny((byte)10, (byte)13, (byte)226);
				if (num2 == -1)
				{
					return -1;
				}
				num += num2;
				if (localBuffer[num2] != 226)
				{
					break;
				}
				num++;
				localBuffer = localBuffer.Slice(num2 + 1);
				ThrowOnDangerousLineSeparator(localBuffer);
			}
			return num;
		}

		private void ThrowOnDangerousLineSeparator(ReadOnlySpan<byte> localBuffer)
		{
			if (localBuffer.Length >= 2)
			{
				byte b = localBuffer[1];
				if (localBuffer[0] == 128 && (b == 168 || b == 169))
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfLineSeparator, 0);
				}
			}
		}

		private bool SkipMultiLineComment(ReadOnlySpan<byte> localBuffer, out int idx)
		{
			idx = 0;
			while (true)
			{
				int num = localBuffer.Slice(idx).IndexOf((byte)47);
				switch (num)
				{
				case -1:
					if (IsLastSpan)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfCommentNotFound, 0);
					}
					return false;
				default:
					if (localBuffer[num + idx - 1] == 42)
					{
						idx += num - 1;
						_consumed += 4 + idx;
						var (num2, num3) = JsonReaderHelper.CountNewLines(localBuffer.Slice(0, idx));
						_lineNumber += num2;
						if (num3 != -1)
						{
							_bytePositionInLine = idx - num3 + 1;
						}
						else
						{
							_bytePositionInLine += 4 + idx;
						}
						return true;
					}
					break;
				case 0:
					break;
				}
				idx += num + 1;
			}
		}

		private bool ConsumeComment()
		{
			ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
			if (readOnlySpan.Length > 0)
			{
				byte b = readOnlySpan[0];
				switch (b)
				{
				case 47:
					return ConsumeSingleLineComment(readOnlySpan.Slice(1), _consumed);
				case 42:
					return ConsumeMultiLineComment(readOnlySpan.Slice(1), _consumed);
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAtStartOfComment, b);
			}
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
			}
			return false;
		}

		private bool ConsumeSingleLineComment(ReadOnlySpan<byte> localBuffer, int previousConsumed)
		{
			if (!SkipSingleLineComment(localBuffer, out var idx))
			{
				return false;
			}
			ValueSpan = _buffer.Slice(previousConsumed + 2, idx);
			if (_tokenType != JsonTokenType.Comment)
			{
				_previousTokenType = _tokenType;
			}
			_tokenType = JsonTokenType.Comment;
			return true;
		}

		private bool ConsumeMultiLineComment(ReadOnlySpan<byte> localBuffer, int previousConsumed)
		{
			if (!SkipMultiLineComment(localBuffer, out var idx))
			{
				return false;
			}
			ValueSpan = _buffer.Slice(previousConsumed + 2, idx);
			if (_tokenType != JsonTokenType.Comment)
			{
				_previousTokenType = _tokenType;
			}
			_tokenType = JsonTokenType.Comment;
			return true;
		}

		public Utf8JsonReader(ReadOnlySequence<byte> jsonData, bool isFinalBlock, JsonReaderState state)
		{
			ReadOnlyMemory<byte> memory = jsonData.First;
			_buffer = memory.Span;
			_isFinalBlock = isFinalBlock;
			_isInputSequence = true;
			_lineNumber = state._lineNumber;
			_bytePositionInLine = state._bytePositionInLine;
			_inObject = state._inObject;
			_isNotPrimitive = state._isNotPrimitive;
			_numberFormat = state._numberFormat;
			_stringHasEscaping = state._stringHasEscaping;
			_trailingCommaBeforeComment = state._trailingCommaBeforeComment;
			_tokenType = state._tokenType;
			_previousTokenType = state._previousTokenType;
			_readerOptions = state._readerOptions;
			if (_readerOptions.MaxDepth == 0)
			{
				_readerOptions.MaxDepth = 64;
			}
			_bitStack = state._bitStack;
			_consumed = 0;
			TokenStartIndex = 0L;
			_totalConsumed = 0L;
			ValueSpan = ReadOnlySpan<byte>.Empty;
			_sequence = jsonData;
			HasValueSequence = false;
			ValueSequence = ReadOnlySequence<byte>.Empty;
			if (jsonData.IsSingleSegment)
			{
				_nextPosition = default(SequencePosition);
				_currentPosition = jsonData.Start;
				_isLastSegment = isFinalBlock;
				_isMultiSegment = false;
				return;
			}
			_currentPosition = jsonData.Start;
			_nextPosition = _currentPosition;
			bool flag = _buffer.Length == 0;
			if (flag)
			{
				SequencePosition nextPosition = _nextPosition;
				ReadOnlyMemory<byte> memory2;
				while (jsonData.TryGet(ref _nextPosition, out memory2))
				{
					_currentPosition = nextPosition;
					if (memory2.Length != 0)
					{
						_buffer = memory2.Span;
						break;
					}
					nextPosition = _nextPosition;
				}
			}
			_isLastSegment = !jsonData.TryGet(ref _nextPosition, out memory, !flag) && isFinalBlock;
			_isMultiSegment = true;
		}

		public Utf8JsonReader(ReadOnlySequence<byte> jsonData, JsonReaderOptions options = default(JsonReaderOptions))
		{
			this = new Utf8JsonReader(jsonData, isFinalBlock: true, new JsonReaderState(options));
		}

		private bool ReadMultiSegment()
		{
			bool flag = false;
			HasValueSequence = false;
			ValueSpan = default(ReadOnlySpan<byte>);
			ValueSequence = default(ReadOnlySequence<byte>);
			if (HasMoreDataMultiSegment())
			{
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment())
					{
						goto IL_016c;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = BytesConsumed;
				if (_tokenType != JsonTokenType.None)
				{
					if (b == 47)
					{
						flag = ConsumeNextTokenOrRollbackMultiSegment(b);
					}
					else if (_tokenType == JsonTokenType.StartObject)
					{
						if (b == 125)
						{
							EndObject();
							goto IL_016a;
						}
						if (b != 34)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
						}
						long totalConsumed = _totalConsumed;
						int consumed = _consumed;
						long bytePositionInLine = _bytePositionInLine;
						long lineNumber = _lineNumber;
						SequencePosition currentPosition = _currentPosition;
						flag = ConsumePropertyNameMultiSegment();
						if (!flag)
						{
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
							_totalConsumed = totalConsumed;
							_currentPosition = currentPosition;
						}
					}
					else if (_tokenType != JsonTokenType.StartArray)
					{
						flag = ((_tokenType != JsonTokenType.PropertyName) ? ConsumeNextTokenOrRollbackMultiSegment(b) : ConsumeValueMultiSegment(b));
					}
					else
					{
						if (b == 93)
						{
							EndArray();
							goto IL_016a;
						}
						flag = ConsumeValueMultiSegment(b);
					}
				}
				else
				{
					flag = ReadFirstTokenMultiSegment(b);
				}
			}
			goto IL_016c;
			IL_016c:
			return flag;
			IL_016a:
			flag = true;
			goto IL_016c;
		}

		private bool ValidateStateAtEndOfData()
		{
			if (_bitStack.CurrentDepth != 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ZeroDepthAtEnd, 0);
			}
			if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && _tokenType == JsonTokenType.Comment)
			{
				return false;
			}
			if (_tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasMoreDataMultiSegment()
		{
			if (_consumed >= (uint)_buffer.Length)
			{
				if (_isNotPrimitive && IsLastSpan && !ValidateStateAtEndOfData())
				{
					return false;
				}
				if (!GetNextSpan())
				{
					if (_isNotPrimitive && IsLastSpan)
					{
						ValidateStateAtEndOfData();
					}
					return false;
				}
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasMoreDataMultiSegment(ExceptionResource resource)
		{
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, resource, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, resource, 0);
					}
					return false;
				}
			}
			return true;
		}

		private bool GetNextSpan()
		{
			ReadOnlyMemory<byte> memory = default(ReadOnlyMemory<byte>);
			while (true)
			{
				SequencePosition currentPosition = _currentPosition;
				_currentPosition = _nextPosition;
				if (!_sequence.TryGet(ref _nextPosition, out memory))
				{
					_currentPosition = currentPosition;
					_isLastSegment = true;
					return false;
				}
				if (memory.Length != 0)
				{
					break;
				}
				_currentPosition = currentPosition;
			}
			if (_isFinalBlock)
			{
				_isLastSegment = !_sequence.TryGet(ref _nextPosition, out var _, advance: false);
			}
			_buffer = memory.Span;
			_totalConsumed += _consumed;
			_consumed = 0;
			return true;
		}

		private bool ReadFirstTokenMultiSegment(byte first)
		{
			switch (first)
			{
			case 123:
				_bitStack.SetFirstBit();
				_tokenType = JsonTokenType.StartObject;
				ValueSpan = _buffer.Slice(_consumed, 1);
				_consumed++;
				_bytePositionInLine++;
				_inObject = true;
				_isNotPrimitive = true;
				break;
			case 91:
				_bitStack.ResetFirstBit();
				_tokenType = JsonTokenType.StartArray;
				ValueSpan = _buffer.Slice(_consumed, 1);
				_consumed++;
				_bytePositionInLine++;
				_isNotPrimitive = true;
				break;
			default:
				if (JsonHelpers.IsDigit(first) || first == 45)
				{
					if (!TryGetNumberMultiSegment(_buffer.Slice(_consumed), out var consumed))
					{
						return false;
					}
					_tokenType = JsonTokenType.Number;
					_consumed += consumed;
					return true;
				}
				if (!ConsumeValueMultiSegment(first))
				{
					return false;
				}
				if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
				{
					_isNotPrimitive = true;
				}
				break;
			}
			return true;
		}

		private void SkipWhiteSpaceMultiSegment()
		{
			do
			{
				SkipWhiteSpace();
			}
			while (_consumed >= _buffer.Length && GetNextSpan());
		}

		private bool ConsumeValueMultiSegment(byte marker)
		{
			while (true)
			{
				_trailingCommaBeforeComment = false;
				switch (marker)
				{
				case 34:
					return ConsumeStringMultiSegment();
				case 123:
					StartObject();
					break;
				case 91:
					StartArray();
					break;
				default:
					if (JsonHelpers.IsDigit(marker) || marker == 45)
					{
						return ConsumeNumberMultiSegment();
					}
					switch (marker)
					{
					case 102:
						return ConsumeLiteralMultiSegment(JsonConstants.FalseValue, JsonTokenType.False);
					case 116:
						return ConsumeLiteralMultiSegment(JsonConstants.TrueValue, JsonTokenType.True);
					case 110:
						return ConsumeLiteralMultiSegment(JsonConstants.NullValue, JsonTokenType.Null);
					}
					switch (_readerOptions.CommentHandling)
					{
					case JsonCommentHandling.Allow:
						if (marker == 47)
						{
							SequencePosition currentPosition2 = _currentPosition;
							if (!SkipOrConsumeCommentMultiSegmentWithRollback())
							{
								_currentPosition = currentPosition2;
								return false;
							}
							return true;
						}
						break;
					default:
					{
						if (marker != 47)
						{
							break;
						}
						SequencePosition currentPosition = _currentPosition;
						if (SkipCommentMultiSegment(out var _))
						{
							if (_consumed >= (uint)_buffer.Length)
							{
								if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
								}
								if (!GetNextSpan())
								{
									if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
									{
										ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
									}
									_currentPosition = currentPosition;
									return false;
								}
							}
							marker = _buffer[_consumed];
							if (marker <= 32)
							{
								SkipWhiteSpaceMultiSegment();
								if (!HasMoreDataMultiSegment())
								{
									_currentPosition = currentPosition;
									return false;
								}
								marker = _buffer[_consumed];
							}
							goto IL_01a8;
						}
						_currentPosition = currentPosition;
						return false;
					}
					case JsonCommentHandling.Disallow:
						break;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, marker);
					break;
				}
				break;
				IL_01a8:
				TokenStartIndex = BytesConsumed;
			}
			return true;
		}

		private bool ConsumeLiteralMultiSegment(ReadOnlySpan<byte> literal, JsonTokenType tokenType)
		{
			ReadOnlySpan<byte> span = _buffer.Slice(_consumed);
			int consumed = literal.Length;
			if (!span.StartsWith(literal))
			{
				int consumed2 = _consumed;
				if (!CheckLiteralMultiSegment(span, literal, out consumed))
				{
					_consumed = consumed2;
					return false;
				}
			}
			else
			{
				ValueSpan = span.Slice(0, literal.Length);
				HasValueSequence = false;
			}
			_tokenType = tokenType;
			_consumed += consumed;
			_bytePositionInLine += consumed;
			return true;
		}

		private bool CheckLiteralMultiSegment(ReadOnlySpan<byte> span, ReadOnlySpan<byte> literal, out int consumed)
		{
			Span<byte> destination = stackalloc byte[literal.Length];
			int num = 0;
			long totalConsumed = _totalConsumed;
			SequencePosition currentPosition = _currentPosition;
			if (span.Length >= literal.Length || IsLastSpan)
			{
				_bytePositionInLine += FindMismatch(span, literal);
				int num2 = Math.Min(span.Length, (int)_bytePositionInLine + 1);
				span.Slice(0, num2).CopyTo(destination);
				num += num2;
			}
			else if (!literal.StartsWith(span))
			{
				_bytePositionInLine += FindMismatch(span, literal);
				int num3 = Math.Min(span.Length, (int)_bytePositionInLine + 1);
				span.Slice(0, num3).CopyTo(destination);
				num += num3;
			}
			else
			{
				ReadOnlySpan<byte> readOnlySpan = literal.Slice(span.Length);
				SequencePosition currentPosition2 = _currentPosition;
				int consumed2 = _consumed;
				int num4 = literal.Length - readOnlySpan.Length;
				while (true)
				{
					_totalConsumed += num4;
					_bytePositionInLine += num4;
					if (!GetNextSpan())
					{
						_totalConsumed = totalConsumed;
						consumed = 0;
						_currentPosition = currentPosition;
						if (IsLastSpan)
						{
							break;
						}
						return false;
					}
					int num5 = Math.Min(span.Length, destination.Length - num);
					span.Slice(0, num5).CopyTo(destination.Slice(num));
					num += num5;
					span = _buffer;
					if (span.StartsWith(readOnlySpan))
					{
						HasValueSequence = true;
						SequencePosition start = new SequencePosition(currentPosition2.GetObject(), currentPosition2.GetInteger() + consumed2);
						SequencePosition end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + readOnlySpan.Length);
						ValueSequence = _sequence.Slice(start, end);
						consumed = readOnlySpan.Length;
						return true;
					}
					if (!readOnlySpan.StartsWith(span))
					{
						_bytePositionInLine += FindMismatch(span, readOnlySpan);
						num5 = Math.Min(span.Length, (int)_bytePositionInLine + 1);
						span.Slice(0, num5).CopyTo(destination.Slice(num));
						num += num5;
						break;
					}
					readOnlySpan = readOnlySpan.Slice(span.Length);
					num4 = span.Length;
				}
			}
			_totalConsumed = totalConsumed;
			consumed = 0;
			_currentPosition = currentPosition;
			throw GetInvalidLiteralMultiSegment(destination.Slice(0, num).ToArray());
		}

		private int FindMismatch(ReadOnlySpan<byte> span, ReadOnlySpan<byte> literal)
		{
			int num = 0;
			int num2 = Math.Min(span.Length, literal.Length);
			int i;
			for (i = 0; i < num2 && span[i] == literal[i]; i++)
			{
			}
			return i;
		}

		private JsonException GetInvalidLiteralMultiSegment(ReadOnlySpan<byte> span)
		{
			return ThrowHelper.GetJsonReaderException(ref this, span[0] switch
			{
				116 => ExceptionResource.ExpectedTrue, 
				102 => ExceptionResource.ExpectedFalse, 
				_ => ExceptionResource.ExpectedNull, 
			}, 0, span);
		}

		private bool ConsumeNumberMultiSegment()
		{
			if (!TryGetNumberMultiSegment(_buffer.Slice(_consumed), out var consumed))
			{
				return false;
			}
			_tokenType = JsonTokenType.Number;
			_consumed += consumed;
			if (_consumed >= (uint)_buffer.Length && _isNotPrimitive)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, _buffer[_consumed - 1]);
			}
			return true;
		}

		private bool ConsumePropertyNameMultiSegment()
		{
			_trailingCommaBeforeComment = false;
			if (!ConsumeStringMultiSegment())
			{
				return false;
			}
			if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
			{
				return false;
			}
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpaceMultiSegment();
				if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
				{
					return false;
				}
				b = _buffer[_consumed];
			}
			if (b != 58)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound, b);
			}
			_consumed++;
			_bytePositionInLine++;
			_tokenType = JsonTokenType.PropertyName;
			return true;
		}

		private bool ConsumeStringMultiSegment()
		{
			ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
			int num = readOnlySpan.IndexOfQuoteOrAnyControlOrBackSlash();
			if (num >= 0)
			{
				byte b = readOnlySpan[num];
				if (b == 34)
				{
					_bytePositionInLine += num + 2;
					ValueSpan = readOnlySpan.Slice(0, num);
					HasValueSequence = false;
					_stringHasEscaping = false;
					_tokenType = JsonTokenType.String;
					_consumed += num + 2;
					return true;
				}
				return ConsumeStringAndValidateMultiSegment(readOnlySpan, num);
			}
			if (IsLastSpan)
			{
				_bytePositionInLine += readOnlySpan.Length + 1;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
			}
			return ConsumeStringNextSegment();
		}

		private bool ConsumeStringNextSegment()
		{
			PartialStateForRollback state = CaptureState();
			HasValueSequence = true;
			int num = _buffer.Length - _consumed;
			ReadOnlySpan<byte> buffer;
			int num2;
			while (true)
			{
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						_bytePositionInLine += num;
						RollBackState(in state, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
					}
					RollBackState(in state);
					return false;
				}
				buffer = _buffer;
				num2 = buffer.IndexOfQuoteOrAnyControlOrBackSlash();
				if (num2 >= 0)
				{
					break;
				}
				_totalConsumed += buffer.Length;
				_bytePositionInLine += buffer.Length;
			}
			byte b = buffer[num2];
			SequencePosition end;
			if (b == 34)
			{
				end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + num2);
				_bytePositionInLine += num + num2 + 1;
				_totalConsumed += num;
				_consumed = num2 + 1;
				_stringHasEscaping = false;
			}
			else
			{
				_bytePositionInLine += num + num2;
				_stringHasEscaping = true;
				bool flag = false;
				while (true)
				{
					if (num2 < buffer.Length)
					{
						byte b2 = buffer[num2];
						if (b2 == 34)
						{
							if (!flag)
							{
								break;
							}
							flag = false;
						}
						else if (b2 == 92)
						{
							flag = !flag;
						}
						else if (flag)
						{
							int num3 = JsonConstants.EscapableChars.IndexOf(b2);
							if (num3 == -1)
							{
								RollBackState(in state, isError: true);
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b2);
							}
							if (b2 == 117)
							{
								_bytePositionInLine++;
								int num4 = 0;
								int num5 = num2 + 1;
								while (true)
								{
									if (num5 < buffer.Length)
									{
										byte nextByte = buffer[num5];
										if (!JsonReaderHelper.IsHexDigit(nextByte))
										{
											RollBackState(in state, isError: true);
											ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, nextByte);
										}
										num4++;
										_bytePositionInLine++;
										if (num4 >= 4)
										{
											break;
										}
										num5++;
										continue;
									}
									if (!GetNextSpan())
									{
										if (IsLastSpan)
										{
											RollBackState(in state, isError: true);
											ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
										}
										RollBackState(in state);
										return false;
									}
									_totalConsumed += buffer.Length;
									buffer = _buffer;
									num5 = 0;
								}
								flag = false;
								num2 = num5 + 1;
								continue;
							}
							flag = false;
						}
						else if (b2 < 32)
						{
							RollBackState(in state, isError: true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b2);
						}
						_bytePositionInLine++;
						num2++;
						continue;
					}
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							RollBackState(in state, isError: true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
						}
						RollBackState(in state);
						return false;
					}
					_totalConsumed += buffer.Length;
					buffer = _buffer;
					num2 = 0;
				}
				_bytePositionInLine++;
				_consumed = num2 + 1;
				_totalConsumed += num;
				end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + num2);
			}
			SequencePosition startPosition = state.GetStartPosition(1);
			ValueSequence = _sequence.Slice(startPosition, end);
			_tokenType = JsonTokenType.String;
			return true;
		}

		private bool ConsumeStringAndValidateMultiSegment(ReadOnlySpan<byte> data, int idx)
		{
			PartialStateForRollback state = CaptureState();
			HasValueSequence = false;
			int num = _buffer.Length - _consumed;
			_bytePositionInLine += idx + 1;
			bool flag = false;
			while (true)
			{
				if (idx < data.Length)
				{
					byte b = data[idx];
					switch (b)
					{
					case 34:
						if (flag)
						{
							flag = false;
							goto IL_01b7;
						}
						if (HasValueSequence)
						{
							_bytePositionInLine++;
							_consumed = idx + 1;
							_totalConsumed += num;
							SequencePosition end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + idx);
							SequencePosition startPosition = state.GetStartPosition(1);
							ValueSequence = _sequence.Slice(startPosition, end);
						}
						else
						{
							_bytePositionInLine++;
							_consumed += idx + 2;
							ValueSpan = data.Slice(0, idx);
						}
						_stringHasEscaping = true;
						_tokenType = JsonTokenType.String;
						return true;
					case 92:
						flag = !flag;
						goto IL_01b7;
					default:
						{
							if (flag)
							{
								int num2 = JsonConstants.EscapableChars.IndexOf(b);
								if (num2 == -1)
								{
									RollBackState(in state, isError: true);
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b);
								}
								if (b == 117)
								{
									_bytePositionInLine++;
									int num3 = 0;
									int num4 = idx + 1;
									while (true)
									{
										if (num4 < data.Length)
										{
											byte nextByte = data[num4];
											if (!JsonReaderHelper.IsHexDigit(nextByte))
											{
												RollBackState(in state, isError: true);
												ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, nextByte);
											}
											num3++;
											_bytePositionInLine++;
											if (num3 >= 4)
											{
												break;
											}
											num4++;
											continue;
										}
										if (!GetNextSpan())
										{
											if (IsLastSpan)
											{
												RollBackState(in state, isError: true);
												ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
											}
											RollBackState(in state);
											return false;
										}
										if (HasValueSequence)
										{
											_totalConsumed += data.Length;
										}
										data = _buffer;
										num4 = 0;
										HasValueSequence = true;
									}
									flag = false;
									idx = num4 + 1;
									break;
								}
								flag = false;
							}
							else if (b < 32)
							{
								RollBackState(in state, isError: true);
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b);
							}
							goto IL_01b7;
						}
						IL_01b7:
						_bytePositionInLine++;
						idx++;
						break;
					}
				}
				else
				{
					if (!GetNextSpan())
					{
						break;
					}
					if (HasValueSequence)
					{
						_totalConsumed += data.Length;
					}
					data = _buffer;
					idx = 0;
					HasValueSequence = true;
				}
			}
			if (IsLastSpan)
			{
				RollBackState(in state, isError: true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
			}
			RollBackState(in state);
			return false;
		}

		private void RollBackState(in PartialStateForRollback state, bool isError = false)
		{
			_totalConsumed = state._prevTotalConsumed;
			if (!isError)
			{
				_bytePositionInLine = state._prevBytePositionInLine;
			}
			_consumed = state._prevConsumed;
			_currentPosition = state._prevCurrentPosition;
		}

		private bool TryGetNumberMultiSegment(ReadOnlySpan<byte> data, out int consumed)
		{
			_numberFormat = '\0';
			PartialStateForRollback rollBackState = CaptureState();
			consumed = 0;
			int i = 0;
			ConsumeNumberResult consumeNumberResult = ConsumeNegativeSignMultiSegment(ref data, ref i, in rollBackState);
			if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
			{
				RollBackState(in rollBackState);
				return false;
			}
			byte b = data[i];
			if (b == 48)
			{
				ConsumeNumberResult consumeNumberResult2 = ConsumeZeroMultiSegment(ref data, ref i, in rollBackState);
				if (consumeNumberResult2 == ConsumeNumberResult.NeedMoreData)
				{
					RollBackState(in rollBackState);
					return false;
				}
				if (consumeNumberResult2 != ConsumeNumberResult.Success)
				{
					b = data[i];
					goto IL_00c6;
				}
			}
			else
			{
				ConsumeNumberResult consumeNumberResult3 = ConsumeIntegerDigitsMultiSegment(ref data, ref i);
				if (consumeNumberResult3 == ConsumeNumberResult.NeedMoreData)
				{
					RollBackState(in rollBackState);
					return false;
				}
				if (consumeNumberResult3 != ConsumeNumberResult.Success)
				{
					b = data[i];
					if (b != 46 && b != 69 && b != 101)
					{
						RollBackState(in rollBackState, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, b);
					}
					goto IL_00c6;
				}
			}
			goto IL_01c0;
			IL_00c6:
			if (b == 46)
			{
				i++;
				_bytePositionInLine++;
				ConsumeNumberResult consumeNumberResult4 = ConsumeDecimalDigitsMultiSegment(ref data, ref i, in rollBackState);
				if (consumeNumberResult4 == ConsumeNumberResult.NeedMoreData)
				{
					RollBackState(in rollBackState);
					return false;
				}
				if (consumeNumberResult4 == ConsumeNumberResult.Success)
				{
					goto IL_01c0;
				}
				b = data[i];
				if (b != 69 && b != 101)
				{
					RollBackState(in rollBackState, isError: true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedNextDigitEValueNotFound, b);
				}
			}
			i++;
			_numberFormat = 'e';
			_bytePositionInLine++;
			consumeNumberResult = ConsumeSignMultiSegment(ref data, ref i, in rollBackState);
			if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
			{
				RollBackState(in rollBackState);
				return false;
			}
			i++;
			_bytePositionInLine++;
			switch (ConsumeIntegerDigitsMultiSegment(ref data, ref i))
			{
			case ConsumeNumberResult.NeedMoreData:
				RollBackState(in rollBackState);
				return false;
			default:
				RollBackState(in rollBackState, isError: true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, data[i]);
				break;
			case ConsumeNumberResult.Success:
				break;
			}
			goto IL_01c0;
			IL_01c0:
			if (HasValueSequence)
			{
				SequencePosition startPosition = rollBackState.GetStartPosition();
				SequencePosition end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + i);
				ValueSequence = _sequence.Slice(startPosition, end);
				consumed = i;
			}
			else
			{
				ValueSpan = data.Slice(0, i);
				consumed = i;
			}
			return true;
		}

		private ConsumeNumberResult ConsumeNegativeSignMultiSegment(ref ReadOnlySpan<byte> data, ref int i, in PartialStateForRollback rollBackState)
		{
			byte b = data[i];
			if (b == 45)
			{
				i++;
				_bytePositionInLine++;
				if (i >= data.Length)
				{
					if (IsLastSpan)
					{
						RollBackState(in rollBackState, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							RollBackState(in rollBackState, isError: true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
						}
						return ConsumeNumberResult.NeedMoreData;
					}
					_totalConsumed += i;
					HasValueSequence = true;
					i = 0;
					data = _buffer;
				}
				b = data[i];
				if (!JsonHelpers.IsDigit(b))
				{
					RollBackState(in rollBackState, isError: true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
				}
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private ConsumeNumberResult ConsumeZeroMultiSegment(ref ReadOnlySpan<byte> data, ref int i, in PartialStateForRollback rollBackState)
		{
			i++;
			_bytePositionInLine++;
			byte value;
			if (i < data.Length)
			{
				value = data[i];
				if (JsonConstants.Delimiters.IndexOf(value) >= 0)
				{
					return ConsumeNumberResult.Success;
				}
			}
			else
			{
				if (IsLastSpan)
				{
					return ConsumeNumberResult.Success;
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						return ConsumeNumberResult.Success;
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += i;
				HasValueSequence = true;
				i = 0;
				data = _buffer;
				value = data[i];
				if (JsonConstants.Delimiters.IndexOf(value) >= 0)
				{
					return ConsumeNumberResult.Success;
				}
			}
			value = data[i];
			if (value != 46 && value != 69 && value != 101)
			{
				RollBackState(in rollBackState, isError: true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, value);
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private ConsumeNumberResult ConsumeIntegerDigitsMultiSegment(ref ReadOnlySpan<byte> data, ref int i)
		{
			byte value = 0;
			int num = 0;
			while (i < data.Length)
			{
				value = data[i];
				if (!JsonHelpers.IsDigit(value))
				{
					break;
				}
				num++;
				i++;
			}
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += num;
					return ConsumeNumberResult.Success;
				}
				while (true)
				{
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							_bytePositionInLine += num;
							return ConsumeNumberResult.Success;
						}
						return ConsumeNumberResult.NeedMoreData;
					}
					_totalConsumed += i;
					_bytePositionInLine += num;
					num = 0;
					HasValueSequence = true;
					i = 0;
					data = _buffer;
					while (i < data.Length)
					{
						value = data[i];
						if (!JsonHelpers.IsDigit(value))
						{
							break;
						}
						i++;
					}
					_bytePositionInLine += i;
					if (i < data.Length)
					{
						break;
					}
					if (IsLastSpan)
					{
						return ConsumeNumberResult.Success;
					}
				}
			}
			else
			{
				_bytePositionInLine += num;
			}
			if (JsonConstants.Delimiters.IndexOf(value) >= 0)
			{
				return ConsumeNumberResult.Success;
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private ConsumeNumberResult ConsumeDecimalDigitsMultiSegment(ref ReadOnlySpan<byte> data, ref int i, in PartialStateForRollback rollBackState)
		{
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					RollBackState(in rollBackState, isError: true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						RollBackState(in rollBackState, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += i;
				HasValueSequence = true;
				i = 0;
				data = _buffer;
			}
			byte b = data[i];
			if (!JsonHelpers.IsDigit(b))
			{
				RollBackState(in rollBackState, isError: true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterDecimal, b);
			}
			i++;
			_bytePositionInLine++;
			return ConsumeIntegerDigitsMultiSegment(ref data, ref i);
		}

		private ConsumeNumberResult ConsumeSignMultiSegment(ref ReadOnlySpan<byte> data, ref int i, in PartialStateForRollback rollBackState)
		{
			if (i >= data.Length)
			{
				if (IsLastSpan)
				{
					RollBackState(in rollBackState, isError: true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						RollBackState(in rollBackState, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += i;
				HasValueSequence = true;
				i = 0;
				data = _buffer;
			}
			byte b = data[i];
			if (b == 43 || b == 45)
			{
				i++;
				_bytePositionInLine++;
				if (i >= data.Length)
				{
					if (IsLastSpan)
					{
						RollBackState(in rollBackState, isError: true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							RollBackState(in rollBackState, isError: true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
						}
						return ConsumeNumberResult.NeedMoreData;
					}
					_totalConsumed += i;
					HasValueSequence = true;
					i = 0;
					data = _buffer;
				}
				b = data[i];
			}
			if (!JsonHelpers.IsDigit(b))
			{
				RollBackState(in rollBackState, isError: true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
			}
			return ConsumeNumberResult.OperationIncomplete;
		}

		private bool ConsumeNextTokenOrRollbackMultiSegment(byte marker)
		{
			long totalConsumed = _totalConsumed;
			int consumed = _consumed;
			long bytePositionInLine = _bytePositionInLine;
			long lineNumber = _lineNumber;
			JsonTokenType tokenType = _tokenType;
			SequencePosition currentPosition = _currentPosition;
			bool trailingCommaBeforeComment = _trailingCommaBeforeComment;
			switch (ConsumeNextTokenMultiSegment(marker))
			{
			case ConsumeTokenResult.Success:
				return true;
			case ConsumeTokenResult.NotEnoughDataRollBackState:
				_consumed = consumed;
				_tokenType = tokenType;
				_bytePositionInLine = bytePositionInLine;
				_lineNumber = lineNumber;
				_totalConsumed = totalConsumed;
				_currentPosition = currentPosition;
				_trailingCommaBeforeComment = trailingCommaBeforeComment;
				break;
			}
			return false;
		}

		private ConsumeTokenResult ConsumeNextTokenMultiSegment(byte marker)
		{
			if (_readerOptions.CommentHandling != JsonCommentHandling.Disallow)
			{
				if (_readerOptions.CommentHandling != JsonCommentHandling.Allow)
				{
					return ConsumeNextTokenUntilAfterAllCommentsAreSkippedMultiSegment(marker);
				}
				if (marker == 47)
				{
					if (!SkipOrConsumeCommentMultiSegmentWithRollback())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (_tokenType == JsonTokenType.Comment)
				{
					return ConsumeNextTokenFromLastNonCommentTokenMultiSegment();
				}
			}
			if (_bitStack.CurrentDepth == 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, marker);
			}
			switch (marker)
			{
			case 44:
			{
				_consumed++;
				_bytePositionInLine++;
				if (_consumed >= (uint)_buffer.Length)
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							_consumed--;
							_bytePositionInLine--;
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
						}
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
				}
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = BytesConsumed;
				if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && b == 47)
				{
					_trailingCommaBeforeComment = true;
					if (!SkipOrConsumeCommentMultiSegmentWithRollback())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (_inObject)
				{
					if (b != 34)
					{
						if (b == 125)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndObject();
								return ConsumeTokenResult.Success;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					if (!ConsumePropertyNameMultiSegment())
					{
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					return ConsumeTokenResult.Success;
				}
				if (b == 93)
				{
					if (_readerOptions.AllowTrailingCommas)
					{
						EndArray();
						return ConsumeTokenResult.Success;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
				}
				if (!ConsumeValueMultiSegment(b))
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			case 125:
				EndObject();
				break;
			case 93:
				EndArray();
				break;
			default:
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, marker);
				break;
			}
			return ConsumeTokenResult.Success;
		}

		private ConsumeTokenResult ConsumeNextTokenFromLastNonCommentTokenMultiSegment()
		{
			if (JsonReaderHelper.IsTokenTypePrimitive(_previousTokenType))
			{
				_tokenType = (_inObject ? JsonTokenType.StartObject : JsonTokenType.StartArray);
			}
			else
			{
				_tokenType = _previousTokenType;
			}
			if (HasMoreDataMultiSegment())
			{
				byte b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment())
					{
						goto IL_0393;
					}
					b = _buffer[_consumed];
				}
				if (_bitStack.CurrentDepth == 0 && _tokenType != JsonTokenType.None)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, b);
				}
				TokenStartIndex = BytesConsumed;
				if (b != 44)
				{
					if (b == 125)
					{
						EndObject();
					}
					else
					{
						if (b != 93)
						{
							if (_tokenType == JsonTokenType.None)
							{
								if (ReadFirstTokenMultiSegment(b))
								{
									goto IL_0391;
								}
							}
							else if (_tokenType == JsonTokenType.StartObject)
							{
								if (b != 34)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
								}
								long totalConsumed = _totalConsumed;
								int consumed = _consumed;
								long bytePositionInLine = _bytePositionInLine;
								long lineNumber = _lineNumber;
								if (ConsumePropertyNameMultiSegment())
								{
									goto IL_0391;
								}
								_consumed = consumed;
								_tokenType = JsonTokenType.StartObject;
								_bytePositionInLine = bytePositionInLine;
								_lineNumber = lineNumber;
								_totalConsumed = totalConsumed;
							}
							else if (_tokenType == JsonTokenType.StartArray)
							{
								if (ConsumeValueMultiSegment(b))
								{
									goto IL_0391;
								}
							}
							else if (_tokenType == JsonTokenType.PropertyName)
							{
								if (ConsumeValueMultiSegment(b))
								{
									goto IL_0391;
								}
							}
							else if (_inObject)
							{
								if (b != 34)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
								}
								if (ConsumePropertyNameMultiSegment())
								{
									goto IL_0391;
								}
							}
							else if (ConsumeValueMultiSegment(b))
							{
								goto IL_0391;
							}
							goto IL_0393;
						}
						EndArray();
					}
					goto IL_0391;
				}
				if ((int)_previousTokenType <= 1 || _previousTokenType == JsonTokenType.StartArray || _trailingCommaBeforeComment)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment, b);
				}
				_consumed++;
				_bytePositionInLine++;
				if (_consumed >= (uint)_buffer.Length)
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
					if (!GetNextSpan())
					{
						if (IsLastSpan)
						{
							_consumed--;
							_bytePositionInLine--;
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
						}
						goto IL_0393;
					}
				}
				b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						goto IL_0393;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = BytesConsumed;
				if (b == 47)
				{
					_trailingCommaBeforeComment = true;
					if (SkipOrConsumeCommentMultiSegmentWithRollback())
					{
						goto IL_0391;
					}
				}
				else if (_inObject)
				{
					if (b != 34)
					{
						if (b == 125)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndObject();
								goto IL_0391;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					if (ConsumePropertyNameMultiSegment())
					{
						goto IL_0391;
					}
				}
				else
				{
					if (b == 93)
					{
						if (_readerOptions.AllowTrailingCommas)
						{
							EndArray();
							goto IL_0391;
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
					}
					if (ConsumeValueMultiSegment(b))
					{
						goto IL_0391;
					}
				}
			}
			goto IL_0393;
			IL_0393:
			return ConsumeTokenResult.NotEnoughDataRollBackState;
			IL_0391:
			return ConsumeTokenResult.Success;
		}

		private bool SkipAllCommentsMultiSegment(ref byte marker)
		{
			while (true)
			{
				if (marker == 47)
				{
					if (!SkipOrConsumeCommentMultiSegmentWithRollback() || !HasMoreDataMultiSegment())
					{
						break;
					}
					marker = _buffer[_consumed];
					if (marker <= 32)
					{
						SkipWhiteSpaceMultiSegment();
						if (!HasMoreDataMultiSegment())
						{
							break;
						}
						marker = _buffer[_consumed];
					}
					continue;
				}
				return true;
			}
			return false;
		}

		private bool SkipAllCommentsMultiSegment(ref byte marker, ExceptionResource resource)
		{
			while (true)
			{
				if (marker == 47)
				{
					if (!SkipOrConsumeCommentMultiSegmentWithRollback() || !HasMoreDataMultiSegment(resource))
					{
						break;
					}
					marker = _buffer[_consumed];
					if (marker <= 32)
					{
						SkipWhiteSpaceMultiSegment();
						if (!HasMoreDataMultiSegment(resource))
						{
							break;
						}
						marker = _buffer[_consumed];
					}
					continue;
				}
				return true;
			}
			return false;
		}

		private ConsumeTokenResult ConsumeNextTokenUntilAfterAllCommentsAreSkippedMultiSegment(byte marker)
		{
			if (SkipAllCommentsMultiSegment(ref marker))
			{
				TokenStartIndex = BytesConsumed;
				if (_tokenType == JsonTokenType.StartObject)
				{
					if (marker == 125)
					{
						EndObject();
					}
					else
					{
						if (marker != 34)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, marker);
						}
						long totalConsumed = _totalConsumed;
						int consumed = _consumed;
						long bytePositionInLine = _bytePositionInLine;
						long lineNumber = _lineNumber;
						SequencePosition currentPosition = _currentPosition;
						if (!ConsumePropertyNameMultiSegment())
						{
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
							_totalConsumed = totalConsumed;
							_currentPosition = currentPosition;
							goto IL_02e7;
						}
					}
				}
				else if (_tokenType == JsonTokenType.StartArray)
				{
					if (marker == 93)
					{
						EndArray();
					}
					else if (!ConsumeValueMultiSegment(marker))
					{
						goto IL_02e7;
					}
				}
				else if (_tokenType == JsonTokenType.PropertyName)
				{
					if (!ConsumeValueMultiSegment(marker))
					{
						goto IL_02e7;
					}
				}
				else if (_bitStack.CurrentDepth == 0)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, marker);
				}
				else
				{
					switch (marker)
					{
					case 44:
						_consumed++;
						_bytePositionInLine++;
						if (_consumed >= (uint)_buffer.Length)
						{
							if (IsLastSpan)
							{
								_consumed--;
								_bytePositionInLine--;
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
							}
							if (!GetNextSpan())
							{
								if (IsLastSpan)
								{
									_consumed--;
									_bytePositionInLine--;
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
								}
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
						}
						marker = _buffer[_consumed];
						if (marker <= 32)
						{
							SkipWhiteSpaceMultiSegment();
							if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							marker = _buffer[_consumed];
						}
						if (SkipAllCommentsMultiSegment(ref marker, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
						{
							TokenStartIndex = BytesConsumed;
							if (_inObject)
							{
								if (marker != 34)
								{
									if (marker == 125)
									{
										if (_readerOptions.AllowTrailingCommas)
										{
											EndObject();
											break;
										}
										ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
									}
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, marker);
								}
								if (!ConsumePropertyNameMultiSegment())
								{
									return ConsumeTokenResult.NotEnoughDataRollBackState;
								}
								return ConsumeTokenResult.Success;
							}
							if (marker == 93)
							{
								if (_readerOptions.AllowTrailingCommas)
								{
									EndArray();
									break;
								}
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
							}
							if (!ConsumeValueMultiSegment(marker))
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							return ConsumeTokenResult.Success;
						}
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					case 125:
						EndObject();
						break;
					case 93:
						EndArray();
						break;
					default:
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, marker);
						break;
					}
				}
				return ConsumeTokenResult.Success;
			}
			goto IL_02e7;
			IL_02e7:
			return ConsumeTokenResult.IncompleteNoRollBackNecessary;
		}

		private bool SkipOrConsumeCommentMultiSegmentWithRollback()
		{
			long bytesConsumed = BytesConsumed;
			SequencePosition start = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + _consumed);
			int tailBytesToIgnore;
			bool flag = SkipCommentMultiSegment(out tailBytesToIgnore);
			if (flag)
			{
				if (_readerOptions.CommentHandling == JsonCommentHandling.Allow)
				{
					SequencePosition end = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + _consumed);
					ReadOnlySequence<byte> readOnlySequence = _sequence.Slice(start, end);
					readOnlySequence = readOnlySequence.Slice(2L, readOnlySequence.Length - 2 - tailBytesToIgnore);
					HasValueSequence = !readOnlySequence.IsSingleSegment;
					if (HasValueSequence)
					{
						ValueSequence = readOnlySequence;
					}
					else
					{
						ValueSpan = readOnlySequence.First.Span;
					}
					if (_tokenType != JsonTokenType.Comment)
					{
						_previousTokenType = _tokenType;
					}
					_tokenType = JsonTokenType.Comment;
				}
			}
			else
			{
				_totalConsumed = bytesConsumed;
				_consumed = 0;
			}
			return flag;
		}

		private bool SkipCommentMultiSegment(out int tailBytesToIgnore)
		{
			_consumed++;
			_bytePositionInLine++;
			ReadOnlySpan<byte> localBuffer = _buffer.Slice(_consumed);
			if (localBuffer.Length == 0)
			{
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
					}
					tailBytesToIgnore = 0;
					return false;
				}
				localBuffer = _buffer;
			}
			byte b = localBuffer[0];
			if (b != 47 && b != 42)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAtStartOfComment, b);
			}
			bool flag = b == 42;
			_consumed++;
			_bytePositionInLine++;
			localBuffer = localBuffer.Slice(1);
			if (localBuffer.Length == 0)
			{
				if (IsLastSpan)
				{
					tailBytesToIgnore = 0;
					if (flag)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
					}
					return true;
				}
				if (!GetNextSpan())
				{
					tailBytesToIgnore = 0;
					if (IsLastSpan)
					{
						if (flag)
						{
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
						}
						return true;
					}
					return false;
				}
				localBuffer = _buffer;
			}
			if (flag)
			{
				tailBytesToIgnore = 2;
				return SkipMultiLineCommentMultiSegment(localBuffer);
			}
			return SkipSingleLineCommentMultiSegment(localBuffer, out tailBytesToIgnore);
		}

		private bool SkipSingleLineCommentMultiSegment(ReadOnlySpan<byte> localBuffer, out int tailBytesToSkip)
		{
			bool flag = false;
			int dangerousLineSeparatorBytesConsumed = 0;
			tailBytesToSkip = 0;
			while (true)
			{
				if (flag)
				{
					if (localBuffer[0] == 10)
					{
						tailBytesToSkip++;
						_consumed++;
					}
					break;
				}
				int num = FindLineSeparatorMultiSegment(localBuffer, ref dangerousLineSeparatorBytesConsumed);
				if (num != -1)
				{
					tailBytesToSkip++;
					_consumed += num + 1;
					_bytePositionInLine += num + 1;
					if (localBuffer[num] == 10)
					{
						break;
					}
					if (num < localBuffer.Length - 1)
					{
						if (localBuffer[num + 1] == 10)
						{
							tailBytesToSkip++;
							_consumed++;
							_bytePositionInLine++;
						}
						break;
					}
					flag = true;
				}
				else
				{
					_consumed += localBuffer.Length;
					_bytePositionInLine += localBuffer.Length;
				}
				if (IsLastSpan)
				{
					if (flag)
					{
						break;
					}
					return true;
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						if (flag)
						{
							break;
						}
						return true;
					}
					return false;
				}
				localBuffer = _buffer;
			}
			_bytePositionInLine = 0L;
			_lineNumber++;
			return true;
		}

		private int FindLineSeparatorMultiSegment(ReadOnlySpan<byte> localBuffer, ref int dangerousLineSeparatorBytesConsumed)
		{
			if (dangerousLineSeparatorBytesConsumed != 0)
			{
				ThrowOnDangerousLineSeparatorMultiSegment(localBuffer, ref dangerousLineSeparatorBytesConsumed);
				if (dangerousLineSeparatorBytesConsumed != 0)
				{
					return -1;
				}
			}
			int num = 0;
			do
			{
				int num2 = localBuffer.IndexOfAny((byte)10, (byte)13, (byte)226);
				dangerousLineSeparatorBytesConsumed = 0;
				if (num2 == -1)
				{
					return -1;
				}
				if (localBuffer[num2] != 226)
				{
					return num + num2;
				}
				int num3 = num2 + 1;
				localBuffer = localBuffer.Slice(num3);
				num += num3;
				dangerousLineSeparatorBytesConsumed++;
				ThrowOnDangerousLineSeparatorMultiSegment(localBuffer, ref dangerousLineSeparatorBytesConsumed);
			}
			while (dangerousLineSeparatorBytesConsumed == 0);
			return -1;
		}

		private void ThrowOnDangerousLineSeparatorMultiSegment(ReadOnlySpan<byte> localBuffer, ref int dangerousLineSeparatorBytesConsumed)
		{
			if (localBuffer.IsEmpty)
			{
				return;
			}
			if (dangerousLineSeparatorBytesConsumed == 1)
			{
				if (localBuffer[0] != 128)
				{
					dangerousLineSeparatorBytesConsumed = 0;
					return;
				}
				localBuffer = localBuffer.Slice(1);
				dangerousLineSeparatorBytesConsumed++;
				if (localBuffer.IsEmpty)
				{
					return;
				}
			}
			if (dangerousLineSeparatorBytesConsumed == 2)
			{
				byte b = localBuffer[0];
				if (b == 168 || b == 169)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfLineSeparator, 0);
				}
				else
				{
					dangerousLineSeparatorBytesConsumed = 0;
				}
			}
		}

		private bool SkipMultiLineCommentMultiSegment(ReadOnlySpan<byte> localBuffer)
		{
			bool flag = false;
			bool flag2 = false;
			while (true)
			{
				if (flag)
				{
					if (localBuffer[0] == 47)
					{
						_consumed++;
						_bytePositionInLine++;
						return true;
					}
					flag = false;
				}
				if (flag2)
				{
					if (localBuffer[0] == 10)
					{
						_consumed++;
						localBuffer = localBuffer.Slice(1);
					}
					flag2 = false;
				}
				int num = localBuffer.IndexOfAny((byte)42, (byte)10, (byte)13);
				if (num != -1)
				{
					int num2 = num + 1;
					byte b = localBuffer[num];
					localBuffer = localBuffer.Slice(num2);
					_consumed += num2;
					switch (b)
					{
					case 42:
						flag = true;
						_bytePositionInLine += num2;
						break;
					case 10:
						_bytePositionInLine = 0L;
						_lineNumber++;
						break;
					default:
						_bytePositionInLine = 0L;
						_lineNumber++;
						flag2 = true;
						break;
					}
				}
				else
				{
					_consumed += localBuffer.Length;
					_bytePositionInLine += localBuffer.Length;
					localBuffer = ReadOnlySpan<byte>.Empty;
				}
				if (!localBuffer.IsEmpty)
				{
					continue;
				}
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
				}
				if (!GetNextSpan())
				{
					if (!IsLastSpan)
					{
						break;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
				}
				localBuffer = _buffer;
			}
			return false;
		}

		private PartialStateForRollback CaptureState()
		{
			return new PartialStateForRollback(_totalConsumed, _bytePositionInLine, _consumed, _currentPosition);
		}

		public string GetString()
		{
			if (TokenType == JsonTokenType.Null)
			{
				return null;
			}
			if (TokenType != JsonTokenType.String && TokenType != JsonTokenType.PropertyName)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedString(TokenType);
			}
			ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (_stringHasEscaping)
			{
				int idx = readOnlySpan.IndexOf((byte)92);
				return JsonReaderHelper.GetUnescapedString(readOnlySpan, idx);
			}
			return JsonReaderHelper.TranscodeHelper(readOnlySpan);
		}

		public string GetComment()
		{
			if (TokenType != JsonTokenType.Comment)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedComment(TokenType);
			}
			ReadOnlySpan<byte> utf8Unescaped = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			return JsonReaderHelper.TranscodeHelper(utf8Unescaped);
		}

		public bool GetBoolean()
		{
			ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (TokenType == JsonTokenType.True)
			{
				return true;
			}
			if (TokenType == JsonTokenType.False)
			{
				return false;
			}
			throw ThrowHelper.GetInvalidOperationException_ExpectedBoolean(TokenType);
		}

		public byte[] GetBytesFromBase64()
		{
			if (!TryGetBytesFromBase64(out var value))
			{
				throw ThrowHelper.GetFormatException(DataType.Base64String);
			}
			return value;
		}

		public byte GetByte()
		{
			if (!TryGetByte(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Byte);
			}
			return value;
		}

		[CLSCompliant(false)]
		public sbyte GetSByte()
		{
			if (!TryGetSByte(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.SByte);
			}
			return value;
		}

		public short GetInt16()
		{
			if (!TryGetInt16(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Int16);
			}
			return value;
		}

		public int GetInt32()
		{
			if (!TryGetInt32(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Int32);
			}
			return value;
		}

		public long GetInt64()
		{
			if (!TryGetInt64(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Int64);
			}
			return value;
		}

		[CLSCompliant(false)]
		public ushort GetUInt16()
		{
			if (!TryGetUInt16(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.UInt16);
			}
			return value;
		}

		[CLSCompliant(false)]
		public uint GetUInt32()
		{
			if (!TryGetUInt32(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.UInt32);
			}
			return value;
		}

		[CLSCompliant(false)]
		public ulong GetUInt64()
		{
			if (!TryGetUInt64(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.UInt64);
			}
			return value;
		}

		public float GetSingle()
		{
			if (!TryGetSingle(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Single);
			}
			return value;
		}

		public double GetDouble()
		{
			if (!TryGetDouble(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Double);
			}
			return value;
		}

		public decimal GetDecimal()
		{
			if (!TryGetDecimal(out var value))
			{
				throw ThrowHelper.GetFormatException(NumericType.Decimal);
			}
			return value;
		}

		public DateTime GetDateTime()
		{
			if (!TryGetDateTime(out var value))
			{
				throw ThrowHelper.GetFormatException(DataType.DateTime);
			}
			return value;
		}

		public DateTimeOffset GetDateTimeOffset()
		{
			if (!TryGetDateTimeOffset(out var value))
			{
				throw ThrowHelper.GetFormatException(DataType.DateTimeOffset);
			}
			return value;
		}

		public Guid GetGuid()
		{
			if (!TryGetGuid(out var value))
			{
				throw ThrowHelper.GetFormatException(DataType.Guid);
			}
			return value;
		}

		public bool TryGetBytesFromBase64(out byte[] value)
		{
			if (TokenType != JsonTokenType.String)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedString(TokenType);
			}
			ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (_stringHasEscaping)
			{
				int idx = readOnlySpan.IndexOf((byte)92);
				return JsonReaderHelper.TryGetUnescapedBase64Bytes(readOnlySpan, idx, out value);
			}
			return JsonReaderHelper.TryDecodeBase64(readOnlySpan, out value);
		}

		public bool TryGetByte(out byte value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out byte value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		[CLSCompliant(false)]
		public bool TryGetSByte(out sbyte value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out sbyte value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		public bool TryGetInt16(out short value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out short value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		public bool TryGetInt32(out int value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out int value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		public bool TryGetInt64(out long value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out long value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0L;
			return false;
		}

		[CLSCompliant(false)]
		public bool TryGetUInt16(out ushort value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out ushort value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0;
			return false;
		}

		[CLSCompliant(false)]
		public bool TryGetUInt32(out uint value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out uint value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0u;
			return false;
		}

		[CLSCompliant(false)]
		public bool TryGetUInt64(out ulong value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out ulong value2, out int bytesConsumed, '\0') && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0uL;
			return false;
		}

		public bool TryGetSingle(out float value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out float value2, out int bytesConsumed, _numberFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0f;
			return false;
		}

		public bool TryGetDouble(out double value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out double value2, out int bytesConsumed, _numberFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = 0.0;
			return false;
		}

		public bool TryGetDecimal(out decimal value)
		{
			if (TokenType != JsonTokenType.Number)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedNumber(TokenType);
			}
			ReadOnlySpan<byte> source = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
			if (Utf8Parser.TryParse(source, out decimal value2, out int bytesConsumed, _numberFormat) && source.Length == bytesConsumed)
			{
				value = value2;
				return true;
			}
			value = default(decimal);
			return false;
		}

		public bool TryGetDateTime(out DateTime value)
		{
			if (TokenType != JsonTokenType.String)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedString(TokenType);
			}
			ReadOnlySpan<byte> readOnlySpan = default(Span<byte>);
			if (HasValueSequence)
			{
				long length = ValueSequence.Length;
				if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(length))
				{
					value = default(DateTime);
					return false;
				}
				Span<byte> span = stackalloc byte[(int)length];
				ValueSequence.CopyTo(span);
				readOnlySpan = span;
			}
			else
			{
				if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(ValueSpan.Length))
				{
					value = default(DateTime);
					return false;
				}
				readOnlySpan = ValueSpan;
			}
			if (_stringHasEscaping)
			{
				return JsonReaderHelper.TryGetEscapedDateTime(readOnlySpan, out value);
			}
			if (readOnlySpan.Length <= 42 && JsonHelpers.TryParseAsISO(readOnlySpan, out DateTime value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTime);
			return false;
		}

		public bool TryGetDateTimeOffset(out DateTimeOffset value)
		{
			if (TokenType != JsonTokenType.String)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedString(TokenType);
			}
			ReadOnlySpan<byte> readOnlySpan = default(Span<byte>);
			if (HasValueSequence)
			{
				long length = ValueSequence.Length;
				if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(length))
				{
					value = default(DateTimeOffset);
					return false;
				}
				Span<byte> span = stackalloc byte[(int)length];
				ValueSequence.CopyTo(span);
				readOnlySpan = span;
			}
			else
			{
				if (!JsonReaderHelper.IsValidDateTimeOffsetParseLength(ValueSpan.Length))
				{
					value = default(DateTimeOffset);
					return false;
				}
				readOnlySpan = ValueSpan;
			}
			if (_stringHasEscaping)
			{
				return JsonReaderHelper.TryGetEscapedDateTimeOffset(readOnlySpan, out value);
			}
			if (readOnlySpan.Length <= 42 && JsonHelpers.TryParseAsISO(readOnlySpan, out DateTimeOffset value2))
			{
				value = value2;
				return true;
			}
			value = default(DateTimeOffset);
			return false;
		}

		public bool TryGetGuid(out Guid value)
		{
			if (TokenType != JsonTokenType.String)
			{
				throw ThrowHelper.GetInvalidOperationException_ExpectedString(TokenType);
			}
			ReadOnlySpan<byte> readOnlySpan = default(Span<byte>);
			if (HasValueSequence)
			{
				long length = ValueSequence.Length;
				if (length > 216)
				{
					value = default(Guid);
					return false;
				}
				Span<byte> span = stackalloc byte[(int)length];
				ValueSequence.CopyTo(span);
				readOnlySpan = span;
			}
			else
			{
				if (ValueSpan.Length > 216)
				{
					value = default(Guid);
					return false;
				}
				readOnlySpan = ValueSpan;
			}
			if (_stringHasEscaping)
			{
				return JsonReaderHelper.TryGetEscapedGuid(readOnlySpan, out value);
			}
			if (readOnlySpan.Length == 36 && Utf8Parser.TryParse(readOnlySpan, out Guid value2, out int _, 'D'))
			{
				value = value2;
				return true;
			}
			value = default(Guid);
			return false;
		}
	}
	internal enum ClassType : byte
	{
		Unknown = 1,
		Object = 2,
		Value = 4,
		Enumerable = 8,
		Dictionary = 0x10,
		IDictionaryConstructible = 0x20
	}
	internal abstract class ImmutableCollectionCreator
	{
		public abstract void RegisterCreatorDelegateFromMethod(MethodInfo creator);

		public abstract bool CreateImmutableEnumerable(IList items, out IEnumerable collection);

		public abstract bool CreateImmutableDictionary(IDictionary items, out IDictionary collection);
	}
	internal sealed class ImmutableEnumerableCreator<TElement, TCollection> : ImmutableCollectionCreator where TCollection : IEnumerable<TElement>
	{
		private Func<IEnumerable<TElement>, TCollection> _creatorDelegate;

		public override void RegisterCreatorDelegateFromMethod(MethodInfo creator)
		{
			_creatorDelegate = (Func<IEnumerable<TElement>, TCollection>)creator.CreateDelegate(typeof(Func<IEnumerable<TElement>, TCollection>));
		}

		public override bool CreateImmutableEnumerable(IList items, out IEnumerable collection)
		{
			collection = _creatorDelegate(CreateGenericTElementIEnumerable(items));
			return true;
		}

		public override bool CreateImmutableDictionary(IDictionary items, out IDictionary collection)
		{
			collection = null;
			return false;
		}

		private IEnumerable<TElement> CreateGenericTElementIEnumerable(IList sourceList)
		{
			foreach (object source in sourceList)
			{
				yield return (TElement)source;
			}
		}
	}
	internal sealed class ImmutableDictionaryCreator<TElement, TCollection> : ImmutableCollectionCreator where TCollection : IReadOnlyDictionary<string, TElement>
	{
		private Func<IEnumerable<KeyValuePair<string, TElement>>, TCollection> _creatorDelegate;

		public override void RegisterCreatorDelegateFromMethod(MethodInfo creator)
		{
			_creatorDelegate = (Func<IEnumerable<KeyValuePair<string, TElement>>, TCollection>)creator.CreateDelegate(typeof(Func<IEnumerable<KeyValuePair<string, TElement>>, TCollection>));
		}

		public override bool CreateImmutableEnumerable(IList items, out IEnumerable collection)
		{
			collection = null;
			return false;
		}

		public override bool CreateImmutableDictionary(IDictionary items, out IDictionary collection)
		{
			collection = (IDictionary)(object)_creatorDelegate(CreateGenericTElementIDictionary(items));
			return true;
		}

		private IEnumerable<KeyValuePair<string, TElement>> CreateGenericTElementIDictionary(IDictionary sourceDictionary)
		{
			foreach (DictionaryEntry item in sourceDictionary)
			{
				yield return new KeyValuePair<string, TElement>((string)item.Key, (TElement)item.Value);
			}
		}
	}
	internal sealed class JsonCamelCaseNamingPolicy : JsonNamingPolicy
	{
		public override string ConvertName(string name)
		{
			if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
			{
				return name;
			}
			char[] array = name.ToCharArray();
			FixCasing(array);
			return new string(array);
		}

		private static void FixCasing(Span<char> chars)
		{
			for (int i = 0; i < chars.Length && (i != 1 || char.IsUpper(chars[i])); i++)
			{
				bool flag = i + 1 < chars.Length;
				if (i > 0 && flag && !char.IsUpper(chars[i + 1]))
				{
					if (chars[i + 1] == ' ')
					{
						chars[i] = char.ToLowerInvariant(chars[i]);
					}
					break;
				}
				chars[i] = char.ToLowerInvariant(chars[i]);
			}
		}
	}
	[DebuggerDisplay("ClassType.{ClassType}, {Type.Name}")]
	internal sealed class JsonClassInfo
	{
		public delegate object ConstructorDelegate();

		private const int PropertyNameKeyLength = 7;

		private const int PropertyNameCountCacheThreshold = 64;

		public volatile Dictionary<string, JsonPropertyInfo> PropertyCache;

		public ConcurrentDictionary<(JsonPropertyInfo, Type), JsonPropertyInfo> RuntimePropertyCache;

		public volatile JsonPropertyInfo[] PropertyCacheArray;

		private volatile PropertyRef[] _propertyRefsSorted;

		private JsonClassInfo _elementClassInfo;

		public const string ImmutableNamespaceName = "System.Collections.Immutable";

		private const string EnumerableGenericInterfaceTypeName = "System.Collections.Generic.IEnumerable`1";

		private const string EnumerableInterfaceTypeName = "System.Collections.IEnumerable";

		private const string ListInterfaceTypeName = "System.Collections.IList";

		private const string ListGenericInterfaceTypeName = "System.Collections.Generic.IList`1";

		private const string ListGenericTypeName = "System.Collections.Generic.List`1";

		private const string CollectionGenericInterfaceTypeName = "System.Collections.Generic.ICollection`1";

		private const string CollectionInterfaceTypeName = "System.Collections.ICollection";

		private const string ReadOnlyListGenericInterfaceTypeName = "System.Collections.Generic.IReadOnlyList`1";

		private const string ReadOnlyCollectionGenericInterfaceTypeName = "System.Collections.Generic.IReadOnlyCollection`1";

		public const string HashtableTypeName = "System.Collections.Hashtable";

		public const string SortedListTypeName = "System.Collections.SortedList";

		public const string StackTypeName = "System.Collections.Stack";

		public const string StackGenericTypeName = "System.Collections.Generic.Stack`1";

		public const string QueueTypeName = "System.Collections.Queue";

		public const string QueueGenericTypeName = "System.Collections.Generic.Queue`1";

		public const string SetGenericInterfaceTypeName = "System.Collections.Generic.ISet`1";

		public const string SortedSetGenericTypeName = "System.Collections.Generic.SortedSet`1";

		public const string HashSetGenericTypeName = "System.Collections.Generic.HashSet`1";

		public const string LinkedListGenericTypeName = "System.Collections.Generic.LinkedList`1";

		public const string DictionaryInterfaceTypeName = "System.Collections.IDictionary";

		public const string DictionaryGenericTypeName = "System.Collections.Generic.Dictionary`2";

		public const string DictionaryGenericInterfaceTypeName = "System.Collections.Generic.IDictionary`2";

		public const string ReadOnlyDictionaryGenericInterfaceTypeName = "System.Collections.Generic.IReadOnlyDictionary`2";

		public const string SortedDictionaryGenericTypeName = "System.Collections.Generic.SortedDictionary`2";

		public const string KeyValuePairGenericTypeName = "System.Collections.Generic.KeyValuePair`2";

		public const string ArrayListTypeName = "System.Collections.ArrayList";

		private static readonly Type[] s_genericInterfacesWithAddMethods = new Type[2]
		{
			typeof(IDictionary<, >),
			typeof(ICollection<>)
		};

		private static readonly Type[] s_nonGenericInterfacesWithAddMethods = new Type[2]
		{
			typeof(IDictionary),
			typeof(IList)
		};

		private static readonly Type[] s_genericInterfacesWithoutAddMethods = new Type[4]
		{
			typeof(IReadOnlyDictionary<, >),
			typeof(IReadOnlyCollection<>),
			typeof(IReadOnlyList<>),
			typeof(IEnumerable<>)
		};

		private static readonly HashSet<string> s_nativelySupportedGenericCollections = new HashSet<string>
		{
			"System.Collections.Generic.List`1", "System.Collections.Generic.IEnumerable`1", "System.Collections.Generic.IList`1", "System.Collections.Generic.ICollection`1", "System.Collections.Generic.IReadOnlyList`1", "System.Collections.Generic.IReadOnlyCollection`1", "System.Collections.Generic.ISet`1", "System.Collections.Generic.Stack`1", "System.Collections.Generic.Queue`1", "System.Collections.Generic.HashSet`1",
			"System.Collections.Generic.LinkedList`1", "System.Collections.Generic.SortedSet`1", "System.Collections.IDictionary", "System.Collections.Generic.Dictionary`2", "System.Collections.Generic.IDictionary`2", "System.Collections.Generic.IReadOnlyDictionary`2", "System.Collections.Generic.SortedDictionary`2", "System.Collections.Generic.KeyValuePair`2", "System.Collections.Immutable.ImmutableArray`1", "System.Collections.Immutable.ImmutableList`1",
			"System.Collections.Immutable.IImmutableList`1", "System.Collections.Immutable.ImmutableStack`1", "System.Collections.Immutable.IImmutableStack`1", "System.Collections.Immutable.ImmutableQueue`1", "System.Collections.Immutable.IImmutableQueue`1", "System.Collections.Immutable.ImmutableSortedSet", "System.Collections.Immutable.ImmutableSortedSet`1", "System.Collections.Immutable.ImmutableHashSet`1", "System.Collections.Immutable.IImmutableSet`1", "System.Collections.Immutable.ImmutableDictionary`2",
			"System.Collections.Immutable.IImmutableDictionary`2", "System.Collections.Immutable.ImmutableSortedDictionary`2"
		};

		private static readonly HashSet<string> s_nativelySupportedNonGenericCollections = new HashSet<string> { "System.Collections.IEnumerable", "System.Collections.ICollection", "System.Collections.IList", "System.Collections.IDictionary", "System.Collections.Stack", "System.Collections.Queue", "System.Collections.Hashtable", "System.Collections.ArrayList", "System.Collections.SortedList" };

		public ConstructorDelegate CreateObject { get; private set; }

		public ConstructorDelegate CreateConcreteDictionary { get; private set; }

		public ClassType ClassType { get; private set; }

		public JsonPropertyInfo DataExtensionProperty { get; private set; }

		public JsonClassInfo ElementClassInfo
		{
			get
			{
				if (_elementClassInfo == null && ElementType != null)
				{
					_elementClassInfo = Options.GetOrAddClass(ElementType);
				}
				return _elementClassInfo;
			}
		}

		public Type ElementType { get; set; }

		public JsonSerializerOptions Options { get; private set; }

		public Type Type { get; private set; }

		public JsonPropertyInfo PolicyProperty { get; private set; }

		public void UpdateSortedPropertyCache(ref ReadStackFrame frame)
		{
			List<PropertyRef> propertyRefCache = frame.PropertyRefCache;
			if (_propertyRefsSorted != null)
			{
				List<PropertyRef> list = new List<PropertyRef>(_propertyRefsSorted);
				while (list.Count + propertyRefCache.Count > 64)
				{
					propertyRefCache.RemoveAt(propertyRefCache.Count - 1);
				}
				list.AddRange(propertyRefCache);
				_propertyRefsSorted = list.ToArray();
			}
			else
			{
				_propertyRefsSorted = propertyRefCache.ToArray();
			}
			frame.PropertyRefCache = null;
		}

		public JsonClassInfo(Type type, JsonSerializerOptions options)
		{
			Type = type;
			Options = options;
			ClassType = GetClassType(type, options);
			CreateObject = options.MemberAccessorStrategy.CreateConstructor(type);
			switch (ClassType)
			{
			case ClassType.Object:
			{
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				Dictionary<string, JsonPropertyInfo> dictionary = CreatePropertyCache(properties.Length);
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					if (propertyInfo.GetIndexParameters().Length != 0)
					{
						continue;
					}
					MethodInfo getMethod = propertyInfo.GetMethod;
					if ((object)getMethod == null || !getMethod.IsPublic)
					{
						MethodInfo setMethod = propertyInfo.SetMethod;
						if ((object)setMethod == null || !setMethod.IsPublic)
						{
							continue;
						}
					}
					JsonPropertyInfo jsonPropertyInfo = AddProperty(propertyInfo.PropertyType, propertyInfo, type, options);
					if (!JsonHelpers.TryAdd(dictionary, jsonPropertyInfo.NameAsString, jsonPropertyInfo))
					{
						JsonPropertyInfo jsonPropertyInfo2 = dictionary[jsonPropertyInfo.NameAsString];
						if (!jsonPropertyInfo2.ShouldDeserialize && !jsonPropertyInfo2.ShouldSerialize)
						{
							dictionary[jsonPropertyInfo.NameAsString] = jsonPropertyInfo;
						}
						else if (jsonPropertyInfo.ShouldDeserialize || jsonPropertyInfo.ShouldSerialize)
						{
							ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameConflict(this, jsonPropertyInfo);
						}
					}
				}
				JsonPropertyInfo[] array2;
				if (DetermineExtensionDataProperty(dictionary))
				{
					dictionary.Remove(DataExtensionProperty.NameAsString);
					array2 = new JsonPropertyInfo[dictionary.Count + 1];
					array2[dictionary.Count] = DataExtensionProperty;
				}
				else
				{
					array2 = new JsonPropertyInfo[dictionary.Count];
				}
				PropertyCache = dictionary;
				dictionary.Values.CopyTo(array2, 0);
				PropertyCacheArray = array2;
				break;
			}
			case ClassType.Enumerable:
			case ClassType.Dictionary:
			{
				AddPolicyProperty(type, options);
				Type classType = ((!IsNativelySupportedCollection(type)) ? PolicyProperty.DeclaredPropertyType : PolicyProperty.RuntimePropertyType);
				CreateObject = options.MemberAccessorStrategy.CreateConstructor(classType);
				ElementType = GetElementType(type, null, null, options);
				break;
			}
			case ClassType.IDictionaryConstructible:
				AddPolicyProperty(type, options);
				ElementType = GetElementType(type, null, null, options);
				CreateConcreteDictionary = options.MemberAccessorStrategy.CreateConstructor(typeof(Dictionary<, >).MakeGenericType(typeof(string), ElementType));
				CreateObject = options.MemberAccessorStrategy.CreateConstructor(PolicyProperty.DeclaredPropertyType);
				break;
			case ClassType.Value:
				AddPolicyProperty(type, options);
				break;
			case ClassType.Unknown:
				AddPolicyProperty(type, options);
				PropertyCache = new Dictionary<string, JsonPropertyInfo>();
				PropertyCacheArray = Array.Empty<JsonPropertyInfo>();
				break;
			}
		}

		private bool DetermineExtensionDataProperty(Dictionary<string, JsonPropertyInfo> cache)
		{
			JsonPropertyInfo propertyWithUniqueAttribute = GetPropertyWithUniqueAttribute(typeof(JsonExtensionDataAttribute), cache);
			if (propertyWithUniqueAttribute != null)
			{
				Type declaredPropertyType = propertyWithUniqueAttribute.DeclaredPropertyType;
				if (!typeof(IDictionary<string, JsonElement>).IsAssignableFrom(declaredPropertyType) && !typeof(IDictionary<string, object>).IsAssignableFrom(declaredPropertyType))
				{
					ThrowHelper.ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(this, propertyWithUniqueAttribute);
				}
				DataExtensionProperty = propertyWithUniqueAttribute;
				return true;
			}
			return false;
		}

		private JsonPropertyInfo GetPropertyWithUniqueAttribute(Type attributeType, Dictionary<string, JsonPropertyInfo> cache)
		{
			JsonPropertyInfo jsonPropertyInfo = null;
			foreach (JsonPropertyInfo value in cache.Values)
			{
				Attribute customAttribute = value.PropertyInfo.GetCustomAttribute(attributeType);
				if (customAttribute != null)
				{
					if (jsonPropertyInfo != null)
					{
						ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type, attributeType);
					}
					jsonPropertyInfo = value;
				}
			}
			return jsonPropertyInfo;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public JsonPropertyInfo GetProperty(ReadOnlySpan<byte> propertyName, ref ReadStackFrame frame)
		{
			JsonPropertyInfo value = null;
			PropertyRef[] propertyRefsSorted = _propertyRefsSorted;
			ulong key = GetKey(propertyName);
			if (propertyRefsSorted != null)
			{
				int propertyIndex = frame.PropertyIndex;
				int num = propertyRefsSorted.Length;
				int num2 = Math.Min(propertyIndex, num);
				int num3 = num2 - 1;
				while (true)
				{
					if (num2 < num)
					{
						PropertyRef propertyRef = propertyRefsSorted[num2];
						if (TryIsPropertyRefEqual(in propertyRef, propertyName, key, ref value))
						{
							return value;
						}
						num2++;
						if (num3 >= 0)
						{
							propertyRef = propertyRefsSorted[num3];
							if (TryIsPropertyRefEqual(in propertyRef, propertyName, key, ref value))
							{
								return value;
							}
							num3--;
						}
					}
					else
					{
						if (num3 < 0)
						{
							break;
						}
						PropertyRef propertyRef2 = propertyRefsSorted[num3];
						if (TryIsPropertyRefEqual(in propertyRef2, propertyName, key, ref value))
						{
							return value;
						}
						num3--;
					}
				}
			}
			string key2 = JsonHelpers.Utf8GetString(propertyName);
			if (!PropertyCache.TryGetValue(key2, out value))
			{
				value = JsonPropertyInfo.s_missingProperty;
			}
			int num4 = 0;
			if (propertyRefsSorted != null)
			{
				num4 = propertyRefsSorted.Length;
			}
			if (num4 < 64)
			{
				if (frame.PropertyRefCache != null)
				{
					num4 += frame.PropertyRefCache.Count;
				}
				if (num4 < 64)
				{
					if (frame.PropertyRefCache == null)
					{
						frame.PropertyRefCache = new List<PropertyRef>();
					}
					PropertyRef item = new PropertyRef(key, value);
					frame.PropertyRefCache.Add(item);
				}
			}
			return value;
		}

		private Dictionary<string, JsonPropertyInfo> CreatePropertyCache(int capacity)
		{
			StringComparer comparer = ((!Options.PropertyNameCaseInsensitive) ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
			return new Dictionary<string, JsonPropertyInfo>(capacity, comparer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool TryIsPropertyRefEqual(in PropertyRef propertyRef, ReadOnlySpan<byte> propertyName, ulong key, ref JsonPropertyInfo info)
		{
			if (key == propertyRef.Key && (propertyName.Length <= 7 || propertyName.SequenceEqual(propertyRef.Info.Name)))
			{
				info = propertyRef.Info;
				return true;
			}
			return false;
		}

		public static ulong GetKey(ReadOnlySpan<byte> propertyName)
		{
			int length = propertyName.Length;
			if (length > 7)
			{
				ulong num = MemoryMarshal.Read<ulong>(propertyName);
				return num | 0xFF00000000000000uL;
			}
			if (length > 3)
			{
				ulong num = MemoryMarshal.Read<uint>(propertyName);
				return length switch
				{
					7 => num | (((ulong)propertyName[6] << 48) | ((ulong)propertyName[5] << 40) | ((ulong)propertyName[4] << 32) | 0x700000000000000L), 
					6 => num | (((ulong)propertyName[5] << 40) | ((ulong)propertyName[4] << 32) | 0x600000000000000L), 
					5 => num | (((ulong)propertyName[4] << 32) | 0x500000000000000L), 
					_ => num | 0x400000000000000L, 
				};
			}
			if (length > 1)
			{
				ulong num = MemoryMarshal.Read<ushort>(propertyName);
				if (length == 3)
				{
					return num | (((ulong)propertyName[2] << 16) | 0x300000000000000L);
				}
				return num | 0x200000000000000L;
			}
			if (length == 1)
			{
				return (ulong)(propertyName[0] | 0x100000000000000L);
			}
			return 0uL;
		}

		public static Type GetElementType(Type propertyType, Type parentType, MemberInfo memberInfo, JsonSerializerOptions options)
		{
			JsonConverter converter;
			Type implementedCollectionType = GetImplementedCollectionType(parentType, propertyType, null, out converter, options);
			if (!typeof(IEnumerable).IsAssignableFrom(implementedCollectionType))
			{
				return null;
			}
			Type elementType = implementedCollectionType.GetElementType();
			if (elementType != null)
			{
				return elementType;
			}
			if (implementedCollectionType.IsGenericType)
			{
				Type[] genericArguments = implementedCollectionType.GetGenericArguments();
				ClassType classType = GetClassType(implementedCollectionType, options);
				if ((classType == ClassType.Dictionary || classType == ClassType.IDictionaryConstructible) && genericArguments.Length >= 2 && genericArguments[0].UnderlyingSystemType == typeof(string))
				{
					return genericArguments[1];
				}
				if (classType == ClassType.Enumerable && genericArguments.Length >= 1)
				{
					return genericArguments[0];
				}
			}
			if (implementedCollectionType.IsAssignableFrom(typeof(IList)) || implementedCollectionType.IsAssignableFrom(typeof(IDictionary)) || IsDeserializedByConstructingWithIList(implementedCollectionType) || IsDeserializedByConstructingWithIDictionary(implementedCollectionType))
			{
				return typeof(object);
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(propertyType, parentType, memberInfo);
		}

		public static ClassType GetClassType(Type type, JsonSerializerOptions options)
		{
			JsonConverter converter;
			Type type2 = GetImplementedCollectionType(typeof(object), type, null, out converter, options);
			if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type2 = Nullable.GetUnderlyingType(type2);
			}
			if (type2 == typeof(object))
			{
				return ClassType.Unknown;
			}
			if (options.HasConverter(type2))
			{
				return ClassType.Value;
			}
			if (DefaultImmutableDictionaryConverter.IsImmutableDictionary(type2) || IsDeserializedByConstructingWithIDictionary(type2))
			{
				return ClassType.IDictionaryConstructible;
			}
			if (typeof(IDictionary).IsAssignableFrom(type2) || IsDictionaryClassType(type2))
			{
				if (type != type2 && !IsNativelySupportedCollection(type))
				{
					return ClassType.IDictionaryConstructible;
				}
				return ClassType.Dictionary;
			}
			if (typeof(IEnumerable).IsAssignableFrom(type2))
			{
				return ClassType.Enumerable;
			}
			return ClassType.Object;
		}

		public static bool IsDictionaryClassType(Type type)
		{
			if (type.IsGenericType)
			{
				if (!(type.GetGenericTypeDefinition() == typeof(IDictionary<, >)))
				{
					return type.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<, >);
				}
				return true;
			}
			return false;
		}

		private void AddPolicyProperty(Type propertyType, JsonSerializerOptions options)
		{
			PolicyProperty = AddProperty(propertyType, null, typeof(object), options);
		}

		private JsonPropertyInfo AddProperty(Type propertyType, PropertyInfo propertyInfo, Type classType, JsonSerializerOptions options)
		{
			JsonConverter converter;
			Type implementedCollectionType = GetImplementedCollectionType(classType, propertyType, propertyInfo, out converter, options);
			JsonPropertyInfo jsonPropertyInfo = ((!(implementedCollectionType != propertyType)) ? CreateProperty(propertyType, propertyType, propertyType, propertyInfo, classType, converter, options) : CreateProperty(implementedCollectionType, implementedCollectionType, implementedCollectionType, propertyInfo, typeof(object), converter, options));
			if (IsNativelySupportedCollection(propertyType) && implementedCollectionType.IsInterface && jsonPropertyInfo.ClassType == ClassType.Dictionary)
			{
				JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(jsonPropertyInfo.ElementType, options);
				Type dictionaryConcreteType = jsonPropertyInfoFromClassInfo.GetDictionaryConcreteType();
				jsonPropertyInfo = ((!(implementedCollectionType != dictionaryConcreteType)) ? CreateProperty(propertyType, implementedCollectionType, implementedCollectionType, propertyInfo, classType, converter, options) : CreateProperty(propertyType, dictionaryConcreteType, implementedCollectionType, propertyInfo, classType, converter, options));
			}
			else if (jsonPropertyInfo.ClassType == ClassType.Enumerable && !implementedCollectionType.IsArray && ((IsDeserializedByAssigningFromList(implementedCollectionType) && IsNativelySupportedCollection(propertyType)) || IsSetInterface(implementedCollectionType)))
			{
				JsonPropertyInfo jsonPropertyInfoFromClassInfo2 = options.GetJsonPropertyInfoFromClassInfo(jsonPropertyInfo.ElementType, options);
				Type concreteType = jsonPropertyInfoFromClassInfo2.GetConcreteType(implementedCollectionType);
				jsonPropertyInfo = ((!(implementedCollectionType != concreteType) || !implementedCollectionType.IsAssignableFrom(concreteType)) ? CreateProperty(propertyType, implementedCollectionType, implementedCollectionType, propertyInfo, classType, converter, options) : CreateProperty(propertyType, concreteType, implementedCollectionType, propertyInfo, classType, converter, options));
			}
			else if (propertyType != implementedCollectionType)
			{
				jsonPropertyInfo = CreateProperty(propertyType, implementedCollectionType, implementedCollectionType, propertyInfo, classType, converter, options);
			}
			return jsonPropertyInfo;
		}

		internal static JsonPropertyInfo CreateProperty(Type declaredPropertyType, Type runtimePropertyType, Type implementedPropertyType, PropertyInfo propertyInfo, Type parentClassType, JsonConverter converter, JsonSerializerOptions options)
		{
			if (JsonPropertyInfo.GetAttribute<JsonIgnoreAttribute>(propertyInfo) != null)
			{
				return JsonPropertyInfo.CreateIgnoredPropertyPlaceholder(propertyInfo, options);
			}
			if (converter == null)
			{
				converter = options.DetermineConverterForProperty(parentClassType, runtimePropertyType, propertyInfo);
			}
			Type type;
			if (runtimePropertyType.IsGenericType && runtimePropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				if (converter != null)
				{
					type = typeof(JsonPropertyInfoNotNullable<, , , >).MakeGenericType(parentClassType, declaredPropertyType, runtimePropertyType, runtimePropertyType);
				}
				else
				{
					Type underlyingType = Nullable.GetUnderlyingType(runtimePropertyType);
					converter = options.DetermineConverterForProperty(parentClassType, underlyingType, propertyInfo);
					type = typeof(JsonPropertyInfoNullable<, >).MakeGenericType(parentClassType, underlyingType);
				}
			}
			else
			{
				Type type2 = converter?.TypeToConvert;
				if (type2 == null)
				{
					type2 = ((!IsNativelySupportedCollection(declaredPropertyType)) ? declaredPropertyType : implementedPropertyType);
				}
				type = ((!runtimePropertyType.IsAssignableFrom(type2)) ? typeof(JsonPropertyInfoNotNullableContravariant<, , , >).MakeGenericType(parentClassType, declaredPropertyType, runtimePropertyType, type2) : typeof(JsonPropertyInfoNotNullable<, , , >).MakeGenericType(parentClassType, declaredPropertyType, runtimePropertyType, type2));
			}
			JsonPropertyInfo jsonPropertyInfo = (JsonPropertyInfo)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
			Type elementType = null;
			if (converter == null)
			{
				switch (GetClassType(runtimePropertyType, options))
				{
				case ClassType.Unknown:
				case ClassType.Enumerable:
				case ClassType.Dictionary:
				case ClassType.IDictionaryConstructible:
					elementType = GetElementType(runtimePropertyType, parentClassType, propertyInfo, options);
					break;
				}
			}
			jsonPropertyInfo.Initialize(parentClassType, declaredPropertyType, runtimePropertyType, implementedPropertyType, propertyInfo, elementType, converter, options);
			return jsonPropertyInfo;
		}

		internal JsonPropertyInfo CreateRootObject(JsonSerializerOptions options)
		{
			return CreateProperty(Type, Type, Type, null, Type, null, options);
		}

		internal JsonPropertyInfo GetOrAddPolymorphicProperty(JsonPropertyInfo property, Type runtimePropertyType, JsonSerializerOptions options)
		{
			ConcurrentDictionary<(JsonPropertyInfo, Type), JsonPropertyInfo> concurrentDictionary = LazyInitializer.EnsureInitialized(ref RuntimePropertyCache, () => new ConcurrentDictionary<(JsonPropertyInfo, Type), JsonPropertyInfo>());
			return concurrentDictionary.GetOrAdd((property, runtimePropertyType), ((JsonPropertyInfo, Type) key) => CreateRuntimeProperty(key, (options: options, classType: Type)));
			static JsonPropertyInfo CreateRuntimeProperty((JsonPropertyInfo property, Type runtimePropertyType) key, (JsonSerializerOptions options, Type classType) arg)
			{
				JsonPropertyInfo jsonPropertyInfo = CreateProperty(key.property.DeclaredPropertyType, key.runtimePropertyType, key.property.ImplementedPropertyType, key.property.PropertyInfo, arg.classType, null, arg.options);
				key.property.CopyRuntimeSettingsTo(jsonPropertyInfo);
				return jsonPropertyInfo;
			}
		}

		public static Type GetImplementedCollectionType(Type parentClassType, Type queryType, PropertyInfo propertyInfo, out JsonConverter converter, JsonSerializerOptions options)
		{
			if (!typeof(IEnumerable).IsAssignableFrom(queryType) || queryType == typeof(string) || queryType.IsInterface || queryType.IsArray || IsNativelySupportedCollection(queryType))
			{
				converter = null;
				return queryType;
			}
			converter = options.DetermineConverterForProperty(parentClassType, queryType, propertyInfo);
			if (converter != null)
			{
				return queryType;
			}
			Type baseType = queryType.GetTypeInfo().BaseType;
			if (IsNativelySupportedCollection(baseType))
			{
				return baseType;
			}
			Type[] array = s_genericInterfacesWithAddMethods;
			foreach (Type interfaceType in array)
			{
				Type type = ExtractGenericInterface(queryType, interfaceType);
				if (type != null)
				{
					return type;
				}
			}
			Type[] array2 = s_nonGenericInterfacesWithAddMethods;
			foreach (Type type2 in array2)
			{
				if (type2.IsAssignableFrom(queryType))
				{
					return type2;
				}
			}
			Type[] array3 = s_genericInterfacesWithoutAddMethods;
			foreach (Type interfaceType2 in array3)
			{
				Type type3 = ExtractGenericInterface(queryType, interfaceType2);
				if (type3 != null)
				{
					return type3;
				}
			}
			return typeof(IEnumerable);
		}

		public static bool IsDeserializedByAssigningFromList(Type type)
		{
			if (type.IsGenericType)
			{
				switch (type.GetGenericTypeDefinition().FullName)
				{
				case "System.Collections.Generic.IEnumerable`1":
				case "System.Collections.Generic.IList`1":
				case "System.Collections.Generic.ICollection`1":
				case "System.Collections.Generic.IReadOnlyList`1":
				case "System.Collections.Generic.IReadOnlyCollection`1":
					return true;
				default:
					return false;
				}
			}
			switch (type.FullName)
			{
			case "System.Collections.IEnumerable":
			case "System.Collections.IList":
			case "System.Collections.ICollection":
				return true;
			default:
				return false;
			}
		}

		public static bool IsSetInterface(Type type)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(ISet<>);
			}
			return false;
		}

		public static bool HasConstructorThatTakesGenericIEnumerable(Type type, JsonSerializerOptions options)
		{
			Type elementType = GetElementType(type, null, null, options);
			return type.GetConstructor(new Type[1] { typeof(List<>).MakeGenericType(elementType) }) != null;
		}

		public static bool IsDeserializedByConstructingWithIList(Type type)
		{
			switch (type.FullName)
			{
			case "System.Collections.Stack":
			case "System.Collections.Queue":
			case "System.Collections.ArrayList":
				return true;
			default:
				return false;
			}
		}

		public static bool IsDeserializedByConstructingWithIDictionary(Type type)
		{
			switch (type.FullName)
			{
			case "System.Collections.Hashtable":
			case "System.Collections.SortedList":
				return true;
			default:
				return false;
			}
		}

		public static bool IsNativelySupportedCollection(Type queryType)
		{
			if (queryType.IsGenericType)
			{
				return s_nativelySupportedGenericCollections.Contains(queryType.GetGenericTypeDefinition().FullName);
			}
			return s_nativelySupportedNonGenericCollections.Contains(queryType.FullName);
		}

		public static Type ExtractGenericInterface(Type queryType, Type interfaceType)
		{
			if (queryType == null)
			{
				throw new ArgumentNullException("queryType");
			}
			if (interfaceType == null)
			{
				throw new ArgumentNullException("interfaceType");
			}
			if (IsGenericInstantiation(queryType, interfaceType))
			{
				return queryType;
			}
			return GetGenericInstantiation(queryType, interfaceType);
		}

		private static bool IsGenericInstantiation(Type candidate, Type interfaceType)
		{
			if (candidate.GetTypeInfo().IsGenericType)
			{
				return candidate.GetGenericTypeDefinition() == interfaceType;
			}
			return false;
		}

		private static Type GetGenericInstantiation(Type queryType, Type interfaceType)
		{
			Type type = null;
			Type[] interfaces = queryType.GetInterfaces();
			Type[] array = interfaces;
			foreach (Type type2 in array)
			{
				if (IsGenericInstantiation(type2, interfaceType))
				{
					if (type == null)
					{
						type = type2;
					}
					else if (StringComparer.Ordinal.Compare(type2.FullName, type.FullName) < 0)
					{
						type = type2;
					}
				}
			}
			if (type != null)
			{
				return type;
			}
			Type type3 = queryType?.GetTypeInfo().BaseType;
			if (type3 == null)
			{
				return null;
			}
			return GetGenericInstantiation(type3, interfaceType);
		}
	}
	internal class JsonDefaultNamingPolicy : JsonNamingPolicy
	{
		public override string ConvertName(string name)
		{
			return name;
		}
	}
	public abstract class JsonNamingPolicy
	{
		public static JsonNamingPolicy CamelCase { get; } = new JsonCamelCaseNamingPolicy();

		internal static JsonNamingPolicy Default { get; } = new JsonDefaultNamingPolicy();

		public abstract string ConvertName(string name);
	}
	[DebuggerDisplay("PropertyInfo={PropertyInfo}, Element={ElementClassInfo}")]
	internal abstract class JsonPropertyInfo
	{
		private static readonly JsonEnumerableConverter s_jsonDerivedEnumerableConverter = new DefaultDerivedEnumerableConverter();

		private static readonly JsonEnumerableConverter s_jsonArrayConverter = new DefaultArrayConverter();

		private static readonly JsonEnumerableConverter s_jsonICollectionConverter = new DefaultICollectionConverter();

		private static readonly JsonEnumerableConverter s_jsonImmutableEnumerableConverter = new DefaultImmutableEnumerableConverter();

		private static readonly JsonDictionaryConverter s_jsonDerivedDictionaryConverter = new DefaultDerivedDictionaryConverter();

		private static readonly JsonDictionaryConverter s_jsonIDictionaryConverter = new DefaultIDictionaryConverter();

		private static readonly JsonDictionaryConverter s_jsonImmutableDictionaryConverter = new DefaultImmutableDictionaryConverter();

		public static readonly JsonPropertyInfo s_missingProperty = GetMissingProperty();

		private JsonClassInfo _elementClassInfo;

		private JsonClassInfo _runtimeClassInfo;

		private JsonClassInfo _declaredTypeClassInfo;

		private JsonPropertyInfo _dictionaryValuePropertyPolicy;

		public ClassType ClassType;

		public JsonEncodedText? EscapedName;

		public bool CanBeNull { get; private set; }

		public abstract JsonConverter ConverterBase { get; set; }

		public Type DeclaredPropertyType { get; private set; }

		public Type ImplementedPropertyType { get; private set; }

		public JsonPropertyInfo DictionaryValuePropertyPolicy
		{
			get
			{
				if ((_dictionaryValuePropertyPolicy = ElementClassInfo.PolicyProperty) == null)
				{
					Type elementType = ElementType;
					_dictionaryValuePropertyPolicy = JsonClassInfo.CreateProperty(elementType, elementType, elementType, null, elementType, null, Options);
				}
				return _dictionaryValuePropertyPolicy;
			}
		}

		public JsonClassInfo ElementClassInfo
		{
			get
			{
				if (_elementClassInfo == null && ElementType != null)
				{
					_elementClassInfo = Options.GetOrAddClass(ElementType);
				}
				return _elementClassInfo;
			}
		}

		public Type ElementType { get; set; }

		public JsonEnumerableConverter EnumerableConverter { get; private set; }

		public JsonDictionaryConverter DictionaryConverter { get; private set; }

		public bool HasGetter { get; set; }

		public bool HasSetter { get; set; }

		public bool HasInternalConverter { get; private set; }

		public bool IgnoreNullValues { get; private set; }

		public bool IsNullableType { get; private set; }

		public bool IsPropertyPolicy { get; protected set; }

		public byte[] JsonPropertyName { get; set; }

		public byte[] Name { get; private set; }

		public string NameAsString { get; private set; }

		public ulong PropertyNameKey { get; set; }

		protected JsonSerializerOptions Options { get; set; }

		public Type ParentClassType { get; private set; }

		public PropertyInfo PropertyInfo { get; private set; }

		public JsonClassInfo RuntimeClassInfo
		{
			get
			{
				if (_runtimeClassInfo == null)
				{
					_runtimeClassInfo = Options.GetOrAddClass(RuntimePropertyType);
				}
				return _runtimeClassInfo;
			}
		}

		public JsonClassInfo DeclaredTypeClassInfo
		{
			get
			{
				if (_declaredTypeClassInfo == null)
				{
					_declaredTypeClassInfo = Options.GetOrAddClass(DeclaredPropertyType);
				}
				return _declaredTypeClassInfo;
			}
		}

		public Type RuntimePropertyType { get; private set; }

		public bool ShouldSerialize { get; private set; }

		public bool ShouldDeserialize { get; private set; }

		private static JsonPropertyInfo GetMissingProperty()
		{
			JsonPropertyInfo jsonPropertyInfo = new JsonPropertyInfoNotNullable<object, object, object, object>();
			jsonPropertyInfo.IsPropertyPolicy = false;
			jsonPropertyInfo.ShouldDeserialize = false;
			jsonPropertyInfo.ShouldSerialize = false;
			return jsonPropertyInfo;
		}

		public void CopyRuntimeSettingsTo(JsonPropertyInfo other)
		{
			other.EscapedName = EscapedName;
			other.Name = Name;
			other.NameAsString = NameAsString;
			other.PropertyNameKey = PropertyNameKey;
		}

		public abstract IList CreateConverterList();

		public abstract IEnumerable CreateDerivedEnumerableInstance(ref ReadStack state, JsonPropertyInfo collectionPropertyInfo, IList sourceList);

		public abstract object CreateDerivedDictionaryInstance(ref ReadStack state, JsonPropertyInfo collectionPropertyInfo, IDictionary sourceDictionary);

		public abstract IEnumerable CreateIEnumerableInstance(ref ReadStack state, Type parentType, IList sourceList);

		public abstract IDictionary CreateIDictionaryInstance(ref ReadStack state, Type parentType, IDictionary sourceDictionary);

		public abstract IEnumerable CreateImmutableCollectionInstance(ref ReadStack state, Type collectionType, string delegateKey, IList sourceList, JsonSerializerOptions options);

		public abstract IDictionary CreateImmutableDictionaryInstance(ref ReadStack state, Type collectionType, string delegateKey, IDictionary sourceDictionary, JsonSerializerOptions options);

		public static JsonPropertyInfo CreateIgnoredPropertyPlaceholder(PropertyInfo propertyInfo, JsonSerializerOptions options)
		{
			JsonPropertyInfo jsonPropertyInfo = new JsonPropertyInfoNotNullable<sbyte, sbyte, sbyte, sbyte>();
			jsonPropertyInfo.Options = options;
			jsonPropertyInfo.PropertyInfo = propertyInfo;
			jsonPropertyInfo.DeterminePropertyName();
			return jsonPropertyInfo;
		}

		private void DeterminePropertyName()
		{
			if (PropertyInfo == null)
			{
				return;
			}
			JsonPropertyNameAttribute attribute = GetAttribute<JsonPropertyNameAttribute>(PropertyInfo);
			if (attribute != null)
			{
				string name = attribute.Name;
				if (name == null)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameNull(ParentClassType, this);
				}
				NameAsString = name;
			}
			else if (Options.PropertyNamingPolicy != null)
			{
				string text = Options.PropertyNamingPolicy.ConvertName(PropertyInfo.Name);
				if (text == null)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameNull(ParentClassType, this);
				}
				NameAsString = text;
			}
			else
			{
				NameAsString = PropertyInfo.Name;
			}
			Name = Encoding.UTF8.GetBytes(NameAsString);
			EscapedName = JsonEncodedText.Encode(Name, Options.Encoder);
			ulong key = JsonClassInfo.GetKey(Name);
			PropertyNameKey = key;
		}

		private void DetermineSerializationCapabilities()
		{
			if (ClassType != ClassType.Enumerable && ClassType != ClassType.Dictionary && ClassType != ClassType.IDictionaryConstructible)
			{
				ShouldSerialize = HasGetter && (HasSetter || !Options.IgnoreReadOnlyProperties);
				ShouldDeserialize = HasSetter;
			}
			else
			{
				if (!HasGetter)
				{
					return;
				}
				ShouldSerialize = true;
				if (!HasSetter)
				{
					return;
				}
				ShouldDeserialize = true;
				if (RuntimePropertyType.IsArray)
				{
					if (RuntimePropertyType.GetArrayRank() > 1)
					{
						throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(RuntimePropertyType, ParentClassType, PropertyInfo);
					}
					EnumerableConverter = s_jsonArrayConverter;
				}
				else if (ClassType == ClassType.IDictionaryConstructible)
				{
					if (DeclaredPropertyType == ImplementedPropertyType)
					{
						if (RuntimePropertyType.FullName.StartsWith("System.Collections.Immutable"))
						{
							DefaultImmutableDictionaryConverter.RegisterImmutableDictionary(RuntimePropertyType, JsonClassInfo.GetElementType(RuntimePropertyType, ParentClassType, PropertyInfo, Options), Options);
							DictionaryConverter = s_jsonImmutableDictionaryConverter;
						}
						else if (JsonClassInfo.IsDeserializedByConstructingWithIDictionary(RuntimePropertyType))
						{
							DictionaryConverter = s_jsonIDictionaryConverter;
						}
					}
					else
					{
						DictionaryConverter = s_jsonDerivedDictionaryConverter;
					}
				}
				else if (ClassType == ClassType.Enumerable)
				{
					if (DeclaredPropertyType != ImplementedPropertyType && (!typeof(IList).IsAssignableFrom(RuntimePropertyType) || ImplementedPropertyType == typeof(ArrayList) || ImplementedPropertyType == typeof(IList)))
					{
						EnumerableConverter = s_jsonDerivedEnumerableConverter;
					}
					else if (JsonClassInfo.IsDeserializedByConstructingWithIList(RuntimePropertyType) || (!typeof(IList).IsAssignableFrom(RuntimePropertyType) && JsonClassInfo.HasConstructorThatTakesGenericIEnumerable(RuntimePropertyType, Options)))
					{
						EnumerableConverter = s_jsonICollectionConverter;
					}
					else if (RuntimePropertyType.IsGenericType && RuntimePropertyType.FullName.StartsWith("System.Collections.Immutable") && RuntimePropertyType.GetGenericArguments().Length == 1)
					{
						DefaultImmutableEnumerableConverter.RegisterImmutableCollection(RuntimePropertyType, JsonClassInfo.GetElementType(RuntimePropertyType, ParentClassType, PropertyInfo, Options), Options);
						EnumerableConverter = s_jsonImmutableEnumerableConverter;
					}
				}
			}
		}

		public static TAttribute GetAttribute<TAttribute>(PropertyInfo propertyInfo) where TAttribute : Attribute
		{
			return (TAttribute)(propertyInfo?.GetCustomAttribute(typeof(TAttribute), inherit: false));
		}

		public abstract Type GetConcreteType(Type type);

		public abstract Type GetDictionaryConcreteType();

		public void GetDictionaryKeyAndValue(ref WriteStackFrame writeStackFrame, out string key, out object value)
		{
			if (writeStackFrame.CollectionEnumerator is IDictionaryEnumerator dictionaryEnumerator)
			{
				if (!(dictionaryEnumerator.Key is string text))
				{
					throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(writeStackFrame.JsonPropertyInfo.DeclaredPropertyType, writeStackFrame.JsonPropertyInfo.ParentClassType, writeStackFrame.JsonPropertyInfo.PropertyInfo);
				}
				key = text;
				value = dictionaryEnumerator.Value;
			}
			else
			{
				DictionaryValuePropertyPolicy.GetDictionaryKeyAndValueFromGenericDictionary(ref writeStackFrame, out key, out value);
			}
		}

		public abstract void GetDictionaryKeyAndValueFromGenericDictionary(ref WriteStackFrame writeStackFrame, out string key, out object value);

		public virtual void GetPolicies()
		{
			DetermineSerializationCapabilities();
			DeterminePropertyName();
			IgnoreNullValues = Options.IgnoreNullValues;
		}

		public abstract object GetValueAsObject(object obj);

		public virtual void Initialize(Type parentClassType, Type declaredPropertyType, Type runtimePropertyType, Type implementedPropertyType, PropertyInfo propertyInfo, Type elementType, JsonConverter converter, JsonSerializerOptions options)
		{
			ParentClassType = parentClassType;
			DeclaredPropertyType = declaredPropertyType;
			RuntimePropertyType = runtimePropertyType;
			ImplementedPropertyType = implementedPropertyType;
			PropertyInfo = propertyInfo;
			ElementType = elementType;
			Options = options;
			IsNullableType = runtimePropertyType.IsGenericType && runtimePropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
			CanBeNull = IsNullableType || !runtimePropertyType.IsValueType;
			if (converter != null)
			{
				ConverterBase = converter;
				HasInternalConverter = converter.GetType().Assembly == GetType().Assembly;
				if (runtimePropertyType == typeof(object))
				{
					ClassType = ClassType.Unknown;
				}
				else
				{
					ClassType = ClassType.Value;
				}
			}
			else if (declaredPropertyType != implementedPropertyType && !JsonClassInfo.IsNativelySupportedCollection(declaredPropertyType))
			{
				ClassType = JsonClassInfo.GetClassType(declaredPropertyType, options);
			}
			else
			{
				ClassType = JsonClassInfo.GetClassType(runtimePropertyType, options);
			}
		}

		protected abstract void OnRead(ref ReadStack state, ref Utf8JsonReader reader);

		protected abstract void OnReadEnumerable(ref ReadStack state, ref Utf8JsonReader reader);

		protected abstract void OnWrite(ref WriteStackFrame current, Utf8JsonWriter writer);

		protected virtual void OnWriteDictionary(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
		}

		protected abstract void OnWriteEnumerable(ref WriteStackFrame current, Utf8JsonWriter writer);

		public void Read(JsonTokenType tokenType, ref ReadStack state, ref Utf8JsonReader reader)
		{
			JsonClassInfo elementClassInfo = ElementClassInfo;
			JsonPropertyInfo policyProperty;
			if (elementClassInfo != null && (policyProperty = elementClassInfo.PolicyProperty) != null)
			{
				if (!state.Current.CollectionPropertyInitialized)
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(policyProperty.RuntimePropertyType);
				}
				policyProperty.ReadEnumerable(tokenType, ref state, ref reader);
			}
			else if (HasInternalConverter)
			{
				OnRead(ref state, ref reader);
			}
			else
			{
				JsonTokenType tokenType2 = reader.TokenType;
				int currentDepth = reader.CurrentDepth;
				long bytesConsumed = reader.BytesConsumed;
				OnRead(ref state, ref reader);
				VerifyRead(tokenType2, currentDepth, bytesConsumed, ref reader);
			}
		}

		public void ReadEnumerable(JsonTokenType tokenType, ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (HasInternalConverter)
			{
				OnReadEnumerable(ref state, ref reader);
				return;
			}
			JsonTokenType tokenType2 = reader.TokenType;
			int currentDepth = reader.CurrentDepth;
			long bytesConsumed = reader.BytesConsumed;
			OnReadEnumerable(ref state, ref reader);
			VerifyRead(tokenType2, currentDepth, bytesConsumed, ref reader);
		}

		public abstract void SetValueAsObject(object obj, object value);

		private void VerifyRead(JsonTokenType tokenType, int depth, long bytesConsumed, ref Utf8JsonReader reader)
		{
			switch (tokenType)
			{
			case JsonTokenType.StartArray:
				if (reader.TokenType != JsonTokenType.EndArray)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterRead(ConverterBase);
				}
				else if (depth != reader.CurrentDepth)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterRead(ConverterBase);
				}
				break;
			case JsonTokenType.StartObject:
				if (reader.TokenType != JsonTokenType.EndObject)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterRead(ConverterBase);
				}
				else if (depth != reader.CurrentDepth)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterRead(ConverterBase);
				}
				break;
			default:
				if (reader.BytesConsumed != bytesConsumed)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterRead(ConverterBase);
				}
				break;
			}
		}

		public void Write(ref WriteStack state, Utf8JsonWriter writer)
		{
			if (state.Current.CollectionEnumerator != null)
			{
				JsonPropertyInfo policyProperty = ElementClassInfo.PolicyProperty;
				policyProperty.WriteEnumerable(ref state, writer);
			}
			else if (HasInternalConverter)
			{
				OnWrite(ref state.Current, writer);
			}
			else
			{
				int currentDepth = writer.CurrentDepth;
				OnWrite(ref state.Current, writer);
				VerifyWrite(currentDepth, writer);
			}
		}

		public void WriteDictionary(ref WriteStack state, Utf8JsonWriter writer)
		{
			if (HasInternalConverter)
			{
				OnWriteDictionary(ref state.Current, writer);
				return;
			}
			int currentDepth = writer.CurrentDepth;
			OnWriteDictionary(ref state.Current, writer);
			VerifyWrite(currentDepth, writer);
		}

		public void WriteEnumerable(ref WriteStack state, Utf8JsonWriter writer)
		{
			if (HasInternalConverter)
			{
				OnWriteEnumerable(ref state.Current, writer);
				return;
			}
			int currentDepth = writer.CurrentDepth;
			OnWriteEnumerable(ref state.Current, writer);
			VerifyWrite(currentDepth, writer);
		}

		private void VerifyWrite(int originalDepth, Utf8JsonWriter writer)
		{
			if (originalDepth != writer.CurrentDepth)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterWrite(ConverterBase);
			}
		}
	}
	internal abstract class JsonPropertyInfoCommon<TClass, TDeclaredProperty, TRuntimeProperty, TConverter> : JsonPropertyInfo
	{
		public Func<object, TDeclaredProperty> Get { get; private set; }

		public Action<object, TDeclaredProperty> Set { get; private set; }

		public JsonConverter<TConverter> Converter { get; internal set; }

		public override JsonConverter ConverterBase
		{
			get
			{
				return Converter;
			}
			set
			{
				Converter = (JsonConverter<TConverter>)value;
			}
		}

		public override void Initialize(Type parentClassType, Type declaredPropertyType, Type runtimePropertyType, Type implementedPropertyType, PropertyInfo propertyInfo, Type elementType, JsonConverter converter, JsonSerializerOptions options)
		{
			base.Initialize(parentClassType, declaredPropertyType, runtimePropertyType, implementedPropertyType, propertyInfo, elementType, converter, options);
			if (propertyInfo != null && declaredPropertyType == propertyInfo.PropertyType)
			{
				MethodInfo getMethod = propertyInfo.GetMethod;
				if ((object)getMethod != null && getMethod.IsPublic)
				{
					base.HasGetter = true;
					Get = options.MemberAccessorStrategy.CreatePropertyGetter<TClass, TDeclaredProperty>(propertyInfo);
				}
				MethodInfo setMethod = propertyInfo.SetMethod;
				if ((object)setMethod != null && setMethod.IsPublic)
				{
					base.HasSetter = true;
					Set = options.MemberAccessorStrategy.CreatePropertySetter<TClass, TDeclaredProperty>(propertyInfo);
				}
			}
			else
			{
				base.IsPropertyPolicy = true;
				base.HasGetter = true;
				base.HasSetter = true;
			}
			GetPolicies();
		}

		public override object GetValueAsObject(object obj)
		{
			if (base.IsPropertyPolicy)
			{
				return obj;
			}
			return Get(obj);
		}

		public override void SetValueAsObject(object obj, object value)
		{
			TDeclaredProperty val = (TDeclaredProperty)value;
			if (val != null || !base.IgnoreNullValues)
			{
				Set(obj, val);
			}
		}

		public override IList CreateConverterList()
		{
			return new List<TDeclaredProperty>();
		}

		public override Type GetConcreteType(Type parentType)
		{
			if (JsonClassInfo.IsDeserializedByAssigningFromList(parentType))
			{
				return typeof(List<TDeclaredProperty>);
			}
			if (JsonClassInfo.IsSetInterface(parentType))
			{
				return typeof(HashSet<TDeclaredProperty>);
			}
			return parentType;
		}

		public override IEnumerable CreateDerivedEnumerableInstance(ref ReadStack state, JsonPropertyInfo collectionPropertyInfo, IList sourceList)
		{
			if (collectionPropertyInfo.DeclaredTypeClassInfo.CreateObject == null)
			{
				throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(collectionPropertyInfo.DeclaredPropertyType, collectionPropertyInfo.ParentClassType, collectionPropertyInfo.PropertyInfo);
			}
			object obj = collectionPropertyInfo.DeclaredTypeClassInfo.CreateObject();
			if (obj is IList { IsReadOnly: false } list)
			{
				{
					foreach (object source in sourceList)
					{
						list.Add(source);
					}
					return list;
				}
			}
			if (obj is ICollection<TDeclaredProperty> { IsReadOnly: false } collection)
			{
				{
					foreach (TDeclaredProperty source2 in sourceList)
					{
						collection.Add(source2);
					}
					return collection;
				}
			}
			if (obj is Stack<TDeclaredProperty> stack)
			{
				{
					foreach (TDeclaredProperty source3 in sourceList)
					{
						stack.Push(source3);
					}
					return stack;
				}
			}
			if (obj is Queue<TDeclaredProperty> queue)
			{
				{
					foreach (TDeclaredProperty source4 in sourceList)
					{
						queue.Enqueue(source4);
					}
					return queue;
				}
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(collectionPropertyInfo.DeclaredPropertyType, collectionPropertyInfo.ParentClassType, collectionPropertyInfo.PropertyInfo);
		}

		public override object CreateDerivedDictionaryInstance(ref ReadStack state, JsonPropertyInfo collectionPropertyInfo, IDictionary sourceDictionary)
		{
			if (collectionPropertyInfo.DeclaredTypeClassInfo.CreateObject == null)
			{
				throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(collectionPropertyInfo.DeclaredPropertyType, collectionPropertyInfo.ParentClassType, collectionPropertyInfo.PropertyInfo);
			}
			object obj = collectionPropertyInfo.DeclaredTypeClassInfo.CreateObject();
			if (obj is IDictionary { IsReadOnly: false } dictionary)
			{
				{
					foreach (DictionaryEntry item in sourceDictionary)
					{
						dictionary.Add((string)item.Key, item.Value);
					}
					return dictionary;
				}
			}
			if (obj is IDictionary<string, TDeclaredProperty> { IsReadOnly: false } dictionary2)
			{
				{
					foreach (DictionaryEntry item2 in sourceDictionary)
					{
						dictionary2.Add((string)item2.Key, (TDeclaredProperty)item2.Value);
					}
					return dictionary2;
				}
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(collectionPropertyInfo.DeclaredPropertyType, collectionPropertyInfo.ParentClassType, collectionPropertyInfo.PropertyInfo);
		}

		public override IEnumerable CreateIEnumerableInstance(ref ReadStack state, Type parentType, IList sourceList)
		{
			if (parentType.IsGenericType)
			{
				Type genericTypeDefinition = parentType.GetGenericTypeDefinition();
				IEnumerable<TDeclaredProperty> enumerable = CreateGenericTDeclaredPropertyIEnumerable(sourceList);
				if (genericTypeDefinition == typeof(Stack<>))
				{
					return new Stack<TDeclaredProperty>(enumerable);
				}
				if (genericTypeDefinition == typeof(Queue<>))
				{
					return new Queue<TDeclaredProperty>(enumerable);
				}
				if (genericTypeDefinition == typeof(HashSet<>))
				{
					return new HashSet<TDeclaredProperty>(enumerable);
				}
				if (genericTypeDefinition == typeof(LinkedList<>))
				{
					return new LinkedList<TDeclaredProperty>(enumerable);
				}
				if (genericTypeDefinition == typeof(SortedSet<>))
				{
					return new SortedSet<TDeclaredProperty>(enumerable);
				}
				return (IEnumerable)Activator.CreateInstance(parentType, enumerable);
			}
			if (parentType == typeof(ArrayList))
			{
				return new ArrayList(sourceList);
			}
			return (IEnumerable)Activator.CreateInstance(parentType, sourceList);
		}

		public override IDictionary CreateIDictionaryInstance(ref ReadStack state, Type parentType, IDictionary sourceDictionary)
		{
			if (parentType.FullName == "System.Collections.Hashtable")
			{
				return new Hashtable(sourceDictionary);
			}
			return (IDictionary)Activator.CreateInstance(parentType, sourceDictionary);
		}

		public override IEnumerable CreateImmutableCollectionInstance(ref ReadStack state, Type collectionType, string delegateKey, IList sourceList, JsonSerializerOptions options)
		{
			IEnumerable collection = null;
			if (!options.TryGetCreateRangeDelegate(delegateKey, out var createRangeDelegate) || !createRangeDelegate.CreateImmutableEnumerable(sourceList, out collection))
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(collectionType, state.JsonPath());
			}
			return collection;
		}

		public override IDictionary CreateImmutableDictionaryInstance(ref ReadStack state, Type collectionType, string delegateKey, IDictionary sourceDictionary, JsonSerializerOptions options)
		{
			IDictionary collection = null;
			if (!options.TryGetCreateRangeDelegate(delegateKey, out var createRangeDelegate) || !createRangeDelegate.CreateImmutableDictionary(sourceDictionary, out collection))
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(collectionType, state.JsonPath());
			}
			return collection;
		}

		private IEnumerable<TDeclaredProperty> CreateGenericTDeclaredPropertyIEnumerable(IList sourceList)
		{
			foreach (object source in sourceList)
			{
				yield return (TDeclaredProperty)source;
			}
		}
	}
	internal sealed class JsonPropertyInfoNotNullable<TClass, TDeclaredProperty, TRuntimeProperty, TConverter> : JsonPropertyInfoCommon<TClass, TDeclaredProperty, TRuntimeProperty, TConverter> where TConverter : TDeclaredProperty
	{
		protected override void OnRead(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			TConverter val = base.Converter.Read(ref reader, base.RuntimePropertyType, base.Options);
			if (state.Current.ReturnValue == null)
			{
				state.Current.ReturnValue = val;
			}
			else
			{
				base.Set(state.Current.ReturnValue, (TDeclaredProperty)(object)val);
			}
		}

		protected override void OnReadEnumerable(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			if (state.Current.KeyName == null && state.Current.IsProcessingDictionaryOrIDictionaryConstructible())
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
				return;
			}
			if (state.Current.IsProcessingEnumerable() && state.Current.TempEnumerableValues == null && state.Current.ReturnValue == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
				return;
			}
			TConverter value = base.Converter.Read(ref reader, base.RuntimePropertyType, base.Options);
			JsonSerializer.ApplyValueToEnumerable(ref value, ref state);
		}

		protected override void OnWrite(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			TConverter val = ((!base.IsPropertyPolicy) ? ((TConverter)(object)base.Get(current.CurrentValue)) : ((TConverter)current.CurrentValue));
			if (val == null)
			{
				if (!base.IgnoreNullValues)
				{
					writer.WriteNull(EscapedName.Value);
				}
			}
			else if (base.Converter != null)
			{
				if (EscapedName.HasValue)
				{
					writer.WritePropertyName(EscapedName.Value);
				}
				base.Converter.Write(writer, val, base.Options);
			}
		}

		protected override void OnWriteDictionary(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			JsonSerializer.WriteDictionary(base.Converter, base.Options, ref current, writer);
		}

		protected override void OnWriteEnumerable(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			if (base.Converter != null)
			{
				TConverter val = ((!(current.CollectionEnumerator is IEnumerator<TConverter> enumerator)) ? ((TConverter)current.CollectionEnumerator.Current) : enumerator.Current);
				if (val == null)
				{
					writer.WriteNullValue();
				}
				else
				{
					base.Converter.Write(writer, val, base.Options);
				}
			}
		}

		public override Type GetDictionaryConcreteType()
		{
			return typeof(Dictionary<string, TRuntimeProperty>);
		}

		public override void GetDictionaryKeyAndValueFromGenericDictionary(ref WriteStackFrame writeStackFrame, out string key, out object value)
		{
			if (writeStackFrame.CollectionEnumerator is IEnumerator<KeyValuePair<string, TDeclaredProperty>> enumerator)
			{
				key = enumerator.Current.Key;
				value = enumerator.Current.Value;
				return;
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(writeStackFrame.JsonPropertyInfo.DeclaredPropertyType, writeStackFrame.JsonPropertyInfo.ParentClassType, writeStackFrame.JsonPropertyInfo.PropertyInfo);
		}
	}
	internal sealed class JsonPropertyInfoNullable<TClass, TProperty> : JsonPropertyInfoCommon<TClass, TProperty?, TProperty, TProperty> where TProperty : struct
	{
		private static readonly Type s_underlyingType = typeof(TProperty);

		protected override void OnRead(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			TProperty val = base.Converter.Read(ref reader, s_underlyingType, base.Options);
			if (state.Current.ReturnValue == null)
			{
				state.Current.ReturnValue = val;
			}
			else
			{
				base.Set(state.Current.ReturnValue, val);
			}
		}

		protected override void OnReadEnumerable(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			TProperty value = base.Converter.Read(ref reader, s_underlyingType, base.Options);
			TProperty? value2 = value;
			JsonSerializer.ApplyValueToEnumerable(ref value2, ref state);
		}

		protected override void OnWrite(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			TProperty? val = ((!base.IsPropertyPolicy) ? base.Get(current.CurrentValue) : ((TProperty?)current.CurrentValue));
			if (!val.HasValue)
			{
				if (!base.IgnoreNullValues)
				{
					writer.WriteNull(EscapedName.Value);
				}
			}
			else if (base.Converter != null)
			{
				if (EscapedName.HasValue)
				{
					writer.WritePropertyName(EscapedName.Value);
				}
				base.Converter.Write(writer, val.GetValueOrDefault(), base.Options);
			}
		}

		protected override void OnWriteDictionary(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			string text = null;
			TProperty? val = null;
			if (current.CollectionEnumerator is IEnumerator<KeyValuePair<string, TProperty?>> { Current: var current2 } enumerator)
			{
				text = current2.Key;
				val = enumerator.Current.Value;
			}
			else if (current.IsIDictionaryConstructible || current.IsIDictionaryConstructibleProperty)
			{
				text = (string)((DictionaryEntry)current.CollectionEnumerator.Current).Key;
				val = (TProperty?)((DictionaryEntry)current.CollectionEnumerator.Current).Value;
			}
			if (base.Options.DictionaryKeyPolicy != null)
			{
				text = base.Options.DictionaryKeyPolicy.ConvertName(text);
				if (text == null)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializerDictionaryKeyNull(base.Options.DictionaryKeyPolicy.GetType());
				}
			}
			if (!val.HasValue)
			{
				writer.WriteNull(text);
				return;
			}
			writer.WritePropertyName(text);
			base.Converter.Write(writer, val.GetValueOrDefault(), base.Options);
		}

		protected override void OnWriteEnumerable(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			if (base.Converter != null)
			{
				TProperty? val = ((!(current.CollectionEnumerator is IEnumerator<TProperty?> enumerator)) ? ((TProperty?)current.CollectionEnumerator.Current) : enumerator.Current);
				if (!val.HasValue)
				{
					writer.WriteNullValue();
				}
				else
				{
					base.Converter.Write(writer, val.GetValueOrDefault(), base.Options);
				}
			}
		}

		public override Type GetDictionaryConcreteType()
		{
			return typeof(Dictionary<string, TProperty?>);
		}

		public override void GetDictionaryKeyAndValueFromGenericDictionary(ref WriteStackFrame writeStackFrame, out string key, out object value)
		{
			if (writeStackFrame.CollectionEnumerator is IEnumerator<KeyValuePair<string, TProperty?>> enumerator)
			{
				key = enumerator.Current.Key;
				value = enumerator.Current.Value;
				return;
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(writeStackFrame.JsonPropertyInfo.DeclaredPropertyType, writeStackFrame.JsonPropertyInfo.ParentClassType, writeStackFrame.JsonPropertyInfo.PropertyInfo);
		}
	}
	public static class JsonSerializer
	{
		private static void HandleStartArray(JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack state)
		{
			if (state.Current.SkipProperty)
			{
				state.Push();
				state.Current.Drain = true;
				return;
			}
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			if (jsonPropertyInfo == null)
			{
				jsonPropertyInfo = state.Current.JsonClassInfo.CreateRootObject(options);
			}
			if (((ClassType)56 & jsonPropertyInfo.ClassType) == 0)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(jsonPropertyInfo.RuntimePropertyType);
			}
			if (state.Current.CollectionPropertyInitialized)
			{
				Type type = jsonPropertyInfo.ElementClassInfo.Type;
				state.Push();
				state.Current.Initialize(type, options);
			}
			state.Current.CollectionPropertyInitialized = true;
			if (state.Current.JsonPropertyInfo == null || state.Current.JsonPropertyInfo.ClassType != ClassType.Enumerable)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(state.Current.JsonClassInfo.Type);
			}
			object obj = ReadStackFrame.CreateEnumerableValue(ref reader, ref state);
			if (obj != null)
			{
				if (state.Current.ReturnValue != null)
				{
					state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, obj);
				}
				else
				{
					state.Current.SetReturnValue(obj);
				}
			}
		}

		private static bool HandleEndArray(JsonSerializerOptions options, ref ReadStack state)
		{
			bool isLastFrame = state.IsLastFrame;
			if (state.Current.Drain)
			{
				state.Pop();
				return isLastFrame;
			}
			IEnumerable enumerable = ReadStackFrame.GetEnumerableValue(in state.Current);
			if (state.Current.TempEnumerableValues != null)
			{
				JsonEnumerableConverter enumerableConverter = state.Current.JsonPropertyInfo.EnumerableConverter;
				enumerable = enumerableConverter.CreateFromList(ref state, (IList)enumerable, options);
				state.Current.TempEnumerableValues = null;
			}
			else if (state.Current.IsProcessingProperty(ClassType.Enumerable))
			{
				state.Current.EndProperty();
				return false;
			}
			if (isLastFrame)
			{
				if (state.Current.ReturnValue == null)
				{
					state.Current.Reset();
					state.Current.ReturnValue = enumerable;
					return true;
				}
				if (state.Current.IsProcessingCollectionObject())
				{
					return true;
				}
			}
			else if (state.Current.IsProcessingObject(ClassType.Enumerable))
			{
				state.Pop();
			}
			ApplyObjectToEnumerable(enumerable, ref state);
			return false;
		}

		internal static void ApplyObjectToEnumerable(object value, ref ReadStack state, bool setPropertyDirectly = false)
		{
			if (state.Current.IsProcessingObject(ClassType.Enumerable))
			{
				if (state.Current.TempEnumerableValues != null)
				{
					state.Current.TempEnumerableValues.Add(value);
				}
				else if (!(state.Current.ReturnValue is IList list))
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(value.GetType());
				}
				else
				{
					list.Add(value);
				}
			}
			else if (!setPropertyDirectly && state.Current.IsProcessingProperty(ClassType.Enumerable))
			{
				if (state.Current.TempEnumerableValues != null)
				{
					state.Current.TempEnumerableValues.Add(value);
					return;
				}
				IList list2 = (IList)state.Current.JsonPropertyInfo.GetValueAsObject(state.Current.ReturnValue);
				if (list2 == null || state.Current.JsonPropertyInfo.RuntimePropertyType.FullName.StartsWith("System.Collections.Immutable.ImmutableArray`1"))
				{
					state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, value);
				}
				else
				{
					list2.Add(value);
				}
			}
			else if (state.Current.IsProcessingObject(ClassType.Dictionary) || (state.Current.IsProcessingProperty(ClassType.Dictionary) && !setPropertyDirectly))
			{
				IDictionary dictionary = (IDictionary)state.Current.JsonPropertyInfo.GetValueAsObject(state.Current.ReturnValue);
				string keyName = state.Current.KeyName;
				dictionary[keyName] = value;
			}
			else if (state.Current.IsProcessingObject(ClassType.IDictionaryConstructible) || (state.Current.IsProcessingProperty(ClassType.IDictionaryConstructible) && !setPropertyDirectly))
			{
				IDictionary tempDictionaryValues = state.Current.TempDictionaryValues;
				string keyName2 = state.Current.KeyName;
				tempDictionaryValues[keyName2] = value;
			}
			else
			{
				state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, value);
			}
		}

		internal static void ApplyValueToEnumerable<TProperty>(ref TProperty value, ref ReadStack state)
		{
			if (state.Current.IsProcessingObject(ClassType.Enumerable))
			{
				if (state.Current.TempEnumerableValues != null)
				{
					((IList<TProperty>)state.Current.TempEnumerableValues).Add(value);
				}
				else
				{
					((IList<TProperty>)state.Current.ReturnValue).Add(value);
				}
			}
			else if (state.Current.IsProcessingProperty(ClassType.Enumerable))
			{
				if (state.Current.TempEnumerableValues != null)
				{
					((IList<TProperty>)state.Current.TempEnumerableValues).Add(value);
					return;
				}
				IList<TProperty> list = (IList<TProperty>)state.Current.JsonPropertyInfo.GetValueAsObject(state.Current.ReturnValue);
				if (list == null)
				{
					state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, value);
				}
				else
				{
					list.Add(value);
				}
			}
			else if (state.Current.IsProcessingDictionary())
			{
				object valueAsObject = state.Current.JsonPropertyInfo.GetValueAsObject(state.Current.ReturnValue);
				string keyName = state.Current.KeyName;
				if (valueAsObject is IDictionary<string, TProperty> dictionary)
				{
					dictionary[keyName] = value;
					return;
				}
				if (!(valueAsObject is IDictionary dictionary2))
				{
					throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(valueAsObject.GetType(), null, null);
				}
				dictionary2[keyName] = value;
			}
			else if (state.Current.IsProcessingIDictionaryConstructible())
			{
				IDictionary<string, TProperty> dictionary3 = (IDictionary<string, TProperty>)state.Current.TempDictionaryValues;
				string keyName2 = state.Current.KeyName;
				dictionary3[keyName2] = value;
			}
			else
			{
				state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, value);
			}
		}

		private static void HandleStartDictionary(JsonSerializerOptions options, ref ReadStack state)
		{
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			if (jsonPropertyInfo == null)
			{
				jsonPropertyInfo = state.Current.JsonClassInfo.CreateRootObject(options);
			}
			if (state.Current.CollectionPropertyInitialized)
			{
				state.Push();
				state.Current.JsonClassInfo = jsonPropertyInfo.ElementClassInfo;
				state.Current.InitializeJsonPropertyInfo();
				JsonClassInfo jsonClassInfo = state.Current.JsonClassInfo;
				if (state.Current.IsProcessingIDictionaryConstructible())
				{
					state.Current.TempDictionaryValues = (IDictionary)jsonClassInfo.CreateConcreteDictionary();
					state.Current.CollectionPropertyInitialized = true;
				}
				else if (state.Current.IsProcessingDictionary())
				{
					if (jsonClassInfo.CreateObject == null)
					{
						throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(jsonClassInfo.Type, null, null);
					}
					state.Current.ReturnValue = jsonClassInfo.CreateObject();
					state.Current.CollectionPropertyInitialized = true;
				}
				else if (state.Current.IsProcessingObject(ClassType.Object))
				{
					if (jsonClassInfo.CreateObject == null)
					{
						ThrowHelper.ThrowNotSupportedException_DeserializeCreateObjectDelegateIsNull(jsonClassInfo.Type);
					}
					state.Current.ReturnValue = jsonClassInfo.CreateObject();
				}
				else
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(jsonClassInfo.Type);
				}
				return;
			}
			state.Current.CollectionPropertyInitialized = true;
			if (state.Current.IsProcessingIDictionaryConstructible())
			{
				JsonClassInfo jsonClassInfo2 = ((!(jsonPropertyInfo.DeclaredPropertyType == jsonPropertyInfo.ImplementedPropertyType)) ? options.GetOrAddClass(jsonPropertyInfo.DeclaredPropertyType) : options.GetOrAddClass(jsonPropertyInfo.RuntimePropertyType));
				state.Current.TempDictionaryValues = (IDictionary)jsonClassInfo2.CreateConcreteDictionary();
				return;
			}
			JsonClassInfo runtimeClassInfo = jsonPropertyInfo.RuntimeClassInfo;
			IDictionary dictionary = (IDictionary)runtimeClassInfo.CreateObject();
			if (dictionary != null)
			{
				if (state.Current.ReturnValue != null)
				{
					state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, dictionary);
				}
				else
				{
					state.Current.SetReturnValue(dictionary);
				}
			}
		}

		private static void HandleEndDictionary(JsonSerializerOptions options, ref ReadStack state)
		{
			if (state.Current.IsProcessingProperty(ClassType.Dictionary))
			{
				if (state.Current.JsonClassInfo.DataExtensionProperty == state.Current.JsonPropertyInfo)
				{
					HandleEndObject(ref state);
				}
				else
				{
					state.Current.EndProperty();
				}
				return;
			}
			if (state.Current.IsProcessingProperty(ClassType.IDictionaryConstructible))
			{
				JsonDictionaryConverter dictionaryConverter = state.Current.JsonPropertyInfo.DictionaryConverter;
				state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, dictionaryConverter.CreateFromDictionary(ref state, state.Current.TempDictionaryValues, options));
				state.Current.EndProperty();
				return;
			}
			object obj;
			if (state.Current.TempDictionaryValues != null)
			{
				JsonDictionaryConverter dictionaryConverter2 = state.Current.JsonPropertyInfo.DictionaryConverter;
				obj = dictionaryConverter2.CreateFromDictionary(ref state, state.Current.TempDictionaryValues, options);
			}
			else
			{
				obj = state.Current.ReturnValue;
			}
			if (state.IsLastFrame)
			{
				state.Current.Reset();
				state.Current.ReturnValue = obj;
			}
			else
			{
				state.Pop();
				ApplyObjectToEnumerable(obj, ref state);
			}
		}

		private static void HandleStartObject(JsonSerializerOptions options, ref ReadStack state)
		{
			if (state.Current.IsProcessingEnumerable())
			{
				if (!state.Current.CollectionPropertyInitialized)
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(state.Current.JsonPropertyInfo.DeclaredPropertyType);
				}
				Type elementType = state.Current.GetElementType();
				state.Push();
				state.Current.Initialize(elementType, options);
			}
			else if (state.Current.JsonPropertyInfo != null)
			{
				Type runtimePropertyType = state.Current.JsonPropertyInfo.RuntimePropertyType;
				state.Push();
				state.Current.Initialize(runtimePropertyType, options);
			}
			JsonClassInfo jsonClassInfo = state.Current.JsonClassInfo;
			if (state.Current.IsProcessingObject(ClassType.IDictionaryConstructible))
			{
				state.Current.TempDictionaryValues = (IDictionary)jsonClassInfo.CreateConcreteDictionary();
				state.Current.CollectionPropertyInitialized = true;
			}
			else if (state.Current.IsProcessingObject(ClassType.Dictionary))
			{
				if (jsonClassInfo.CreateObject == null)
				{
					throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(jsonClassInfo.Type, null, null);
				}
				state.Current.ReturnValue = jsonClassInfo.CreateObject();
				state.Current.CollectionPropertyInitialized = true;
			}
			else if (state.Current.IsProcessingObject(ClassType.Object))
			{
				if (jsonClassInfo.CreateObject == null)
				{
					ThrowHelper.ThrowNotSupportedException_DeserializeCreateObjectDelegateIsNull(jsonClassInfo.Type);
				}
				state.Current.ReturnValue = jsonClassInfo.CreateObject();
				if (state.Current.IsProcessingDictionary())
				{
					state.Current.CollectionPropertyInitialized = true;
				}
			}
			else
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(jsonClassInfo.Type);
			}
		}

		private static void HandleEndObject(ref ReadStack state)
		{
			if (state.Current.JsonClassInfo.ClassType == ClassType.Value)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(state.Current.JsonPropertyInfo.RuntimePropertyType);
			}
			if (state.Current.PropertyRefCache != null)
			{
				state.Current.JsonClassInfo.UpdateSortedPropertyCache(ref state.Current);
			}
			object returnValue = state.Current.ReturnValue;
			if (state.IsLastFrame)
			{
				state.Current.Reset();
				state.Current.ReturnValue = returnValue;
			}
			else
			{
				state.Pop();
				ApplyObjectToEnumerable(returnValue, ref state);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void HandlePropertyName(JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack state)
		{
			if (state.Current.Drain)
			{
				return;
			}
			bool flag = state.Current.IsProcessingDictionaryOrIDictionaryConstructibleObject();
			if ((flag || state.Current.IsProcessingDictionaryOrIDictionaryConstructibleProperty()) && state.Current.JsonClassInfo.DataExtensionProperty != state.Current.JsonPropertyInfo)
			{
				if (flag)
				{
					state.Current.JsonPropertyInfo = state.Current.JsonClassInfo.PolicyProperty;
				}
				state.Current.KeyName = reader.GetString();
				return;
			}
			state.Current.EndProperty();
			ReadOnlySpan<byte> readOnlySpan = (reader.HasValueSequence ? ((ReadOnlySpan<byte>)reader.ValueSequence.ToArray<byte>()) : reader.ValueSpan);
			if (reader._stringHasEscaping)
			{
				int idx = readOnlySpan.IndexOf((byte)92);
				readOnlySpan = GetUnescapedString(readOnlySpan, idx);
			}
			JsonPropertyInfo property = state.Current.JsonClassInfo.GetProperty(readOnlySpan, ref state.Current);
			if (property == JsonPropertyInfo.s_missingProperty)
			{
				JsonPropertyInfo dataExtensionProperty = state.Current.JsonClassInfo.DataExtensionProperty;
				if (dataExtensionProperty == null)
				{
					state.Current.JsonPropertyInfo = JsonPropertyInfo.s_missingProperty;
				}
				else
				{
					state.Current.JsonPropertyInfo = dataExtensionProperty;
					state.Current.JsonPropertyName = readOnlySpan.ToArray();
					state.Current.KeyName = JsonHelpers.Utf8GetString(readOnlySpan);
					state.Current.CollectionPropertyInitialized = true;
					CreateDataExtensionProperty(dataExtensionProperty, ref state);
				}
			}
			else
			{
				state.Current.JsonPropertyInfo = property;
				if (property.JsonPropertyName == null)
				{
					byte[] jsonPropertyName = readOnlySpan.ToArray();
					if (options.PropertyNameCaseInsensitive)
					{
						state.Current.JsonPropertyName = jsonPropertyName;
					}
					else
					{
						state.Current.JsonPropertyInfo.JsonPropertyName = jsonPropertyName;
					}
				}
			}
			state.Current.PropertyIndex++;
		}

		private static void CreateDataExtensionProperty(JsonPropertyInfo jsonPropertyInfo, ref ReadStack state)
		{
			IDictionary dictionary = (IDictionary)jsonPropertyInfo.GetValueAsObject(state.Current.ReturnValue);
			if (dictionary == null)
			{
				dictionary = (IDictionary)jsonPropertyInfo.RuntimeClassInfo.CreateObject();
				jsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, dictionary);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void HandleValue(JsonTokenType tokenType, JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack state)
		{
			if (!state.Current.SkipProperty)
			{
				JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
				if (jsonPropertyInfo == null)
				{
					jsonPropertyInfo = state.Current.JsonClassInfo.CreateRootObject(options);
				}
				else if (state.Current.JsonClassInfo.ClassType == ClassType.Unknown)
				{
					jsonPropertyInfo = state.Current.JsonClassInfo.GetOrAddPolymorphicProperty(jsonPropertyInfo, typeof(object), options);
				}
				jsonPropertyInfo.Read(tokenType, ref state, ref reader);
			}
		}

		private static object ReadCore(Type returnType, JsonSerializerOptions options, ref Utf8JsonReader reader)
		{
			ReadStack readStack = default(ReadStack);
			readStack.Current.Initialize(returnType, options);
			ReadCore(options, ref reader, ref readStack);
			return readStack.Current.ReturnValue;
		}

		public static ValueTask<TValue> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			return ReadAsync<TValue>(utf8Json, typeof(TValue), options, cancellationToken);
		}

		public static ValueTask<object> DeserializeAsync(Stream utf8Json, Type returnType, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			return ReadAsync<object>(utf8Json, returnType, options, cancellationToken);
		}

		private static async ValueTask<TValue> ReadAsync<TValue>(Stream utf8Json, Type returnType, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			ReadStack readStack = default(ReadStack);
			readStack.Current.Initialize(returnType, options);
			JsonReaderState readerState = new JsonReaderState(options.GetReaderOptions());
			int utf8BomLength = JsonConstants.Utf8Bom.Length;
			byte[] buffer = ArrayPool<byte>.Shared.Rent(Math.Max(options.DefaultBufferSize, utf8BomLength));
			int bytesInBuffer = 0;
			long totalBytesRead = 0L;
			int clearMax = 0;
			bool firstIteration = true;
			try
			{
				while (true)
				{
					bool isFinalBlock = false;
					do
					{
						int num = await utf8Json.ReadAsync(buffer, bytesInBuffer, buffer.Length - bytesInBuffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (num == 0)
						{
							isFinalBlock = true;
							break;
						}
						totalBytesRead += num;
						bytesInBuffer += num;
					}
					while (bytesInBuffer != buffer.Length);
					if (bytesInBuffer > clearMax)
					{
						clearMax = bytesInBuffer;
					}
					int num2 = 0;
					if (firstIteration)
					{
						firstIteration = false;
						if (buffer.AsSpan().StartsWith(JsonConstants.Utf8Bom))
						{
							num2 += utf8BomLength;
							bytesInBuffer -= utf8BomLength;
						}
					}
					ReadCore(ref readerState, isFinalBlock, new ReadOnlySpan<byte>(buffer, num2, bytesInBuffer), options, ref readStack);
					int num3 = checked((int)readStack.BytesConsumed);
					bytesInBuffer -= num3;
					if (!isFinalBlock)
					{
						if ((uint)bytesInBuffer > (uint)buffer.Length / 2u)
						{
							byte[] array = ArrayPool<byte>.Shared.Rent((buffer.Length < 1073741823) ? (buffer.Length * 2) : 2147483647);
							Buffer.BlockCopy(buffer, num3 + num2, array, 0, bytesInBuffer);
							new Span<byte>(buffer, 0, clearMax).Clear();
							ArrayPool<byte>.Shared.Return(buffer);
							clearMax = bytesInBuffer;
							buffer = array;
						}
						else if (bytesInBuffer != 0)
						{
							Buffer.BlockCopy(buffer, num3 + num2, buffer, 0, bytesInBuffer);
						}
						continue;
					}
					break;
				}
			}
			finally
			{
				new Span<byte>(buffer, 0, clearMax).Clear();
				ArrayPool<byte>.Shared.Return(buffer);
			}
			return (TValue)readStack.Current.ReturnValue;
		}

		private static void ReadCore(ref JsonReaderState readerState, bool isFinalBlock, ReadOnlySpan<byte> buffer, JsonSerializerOptions options, ref ReadStack readStack)
		{
			Utf8JsonReader reader = new Utf8JsonReader(buffer, isFinalBlock, readerState);
			readStack.ReadAhead = !isFinalBlock;
			readStack.BytesConsumed = 0L;
			ReadCore(options, ref reader, ref readStack);
			readerState = reader.CurrentState;
		}

		public static TValue Deserialize<TValue>(string json, JsonSerializerOptions options = null)
		{
			return (TValue)Deserialize(json, typeof(TValue), options);
		}

		public static object Deserialize(string json, Type returnType, JsonSerializerOptions options = null)
		{
			if (json == null)
			{
				throw new ArgumentNullException("json");
			}
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			byte[] array = null;
			Span<byte> span = (((long)json.Length > 349525L) ? new byte[JsonReaderHelper.GetUtf8ByteCount(json.AsSpan())] : (array = ArrayPool<byte>.Shared.Rent(json.Length * 3)));
			try
			{
				int utf8FromText = JsonReaderHelper.GetUtf8FromText(json.AsSpan(), span);
				span = span.Slice(0, utf8FromText);
				Utf8JsonReader reader = new Utf8JsonReader(state: new JsonReaderState(options.GetReaderOptions()), jsonData: span, isFinalBlock: true);
				return ReadCore(returnType, options, ref reader);
			}
			finally
			{
				if (array != null)
				{
					span.Clear();
					ArrayPool<byte>.Shared.Return(array);
				}
			}
		}

		private static void ReadCore(JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack readStack)
		{
			try
			{
				JsonReaderState initialState = default(JsonReaderState);
				long initialBytesConsumed = 0L;
				while (true)
				{
					if (readStack.ReadAhead)
					{
						initialState = reader.CurrentState;
						initialBytesConsumed = reader.BytesConsumed;
					}
					if (!reader.Read())
					{
						break;
					}
					JsonTokenType tokenType = reader.TokenType;
					if (JsonHelpers.IsInRangeInclusive(tokenType, JsonTokenType.String, JsonTokenType.False))
					{
						HandleValue(tokenType, options, ref reader, ref readStack);
						continue;
					}
					switch (tokenType)
					{
					case JsonTokenType.PropertyName:
						HandlePropertyName(options, ref reader, ref readStack);
						break;
					case JsonTokenType.StartObject:
						if (readStack.Current.SkipProperty)
						{
							readStack.Push();
							readStack.Current.Drain = true;
						}
						else if (readStack.Current.IsProcessingValue())
						{
							if (!HandleObjectAsValue(tokenType, options, ref reader, ref readStack, ref initialState, initialBytesConsumed))
							{
								goto end_IL_000b;
							}
						}
						else if (readStack.Current.IsProcessingDictionaryOrIDictionaryConstructible())
						{
							HandleStartDictionary(options, ref readStack);
						}
						else
						{
							HandleStartObject(options, ref readStack);
						}
						break;
					case JsonTokenType.EndObject:
						if (readStack.Current.Drain)
						{
							readStack.Pop();
							readStack.Current.EndProperty();
						}
						else if (readStack.Current.IsProcessingDictionaryOrIDictionaryConstructible())
						{
							HandleEndDictionary(options, ref readStack);
						}
						else
						{
							HandleEndObject(ref readStack);
						}
						break;
					case JsonTokenType.StartArray:
						if (!readStack.Current.IsProcessingValue())
						{
							HandleStartArray(options, ref reader, ref readStack);
						}
						else if (!HandleObjectAsValue(tokenType, options, ref reader, ref readStack, ref initialState, initialBytesConsumed))
						{
							goto end_IL_000b;
						}
						break;
					case JsonTokenType.EndArray:
						HandleEndArray(options, ref readStack);
						break;
					case JsonTokenType.Null:
						HandleNull(ref reader, ref readStack);
						break;
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			catch (JsonReaderException ex)
			{
				ThrowHelper.ReThrowWithPath(in readStack, ex);
			}
			catch (FormatException ex2) when (ex2.Source == "System.Text.Json.Rethrowable")
			{
				ThrowHelper.ReThrowWithPath(in readStack, in reader, ex2);
			}
			catch (InvalidOperationException ex3) when (ex3.Source == "System.Text.Json.Rethrowable")
			{
				ThrowHelper.ReThrowWithPath(in readStack, in reader, ex3);
			}
			catch (JsonException ex4)
			{
				ThrowHelper.AddExceptionInformation(in readStack, in reader, ex4);
				throw;
			}
			readStack.BytesConsumed += reader.BytesConsumed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HandleObjectAsValue(JsonTokenType tokenType, JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack readStack, ref JsonReaderState initialState, long initialBytesConsumed)
		{
			if (readStack.ReadAhead)
			{
				bool flag = reader.TrySkip();
				reader = new Utf8JsonReader(reader.OriginalSpan.Slice(checked((int)initialBytesConsumed)), reader.IsFinalBlock, initialState);
				readStack.BytesConsumed += initialBytesConsumed;
				if (!flag)
				{
					return false;
				}
				reader.Read();
			}
			HandleValue(tokenType, options, ref reader, ref readStack);
			return true;
		}

		private static ReadOnlySpan<byte> GetUnescapedString(ReadOnlySpan<byte> utf8Source, int idx)
		{
			int length = utf8Source.Length;
			byte[] array = null;
			Span<byte> span = ((length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(length))) : stackalloc byte[length]);
			Span<byte> destination = span;
			JsonReaderHelper.Unescape(utf8Source, destination, idx, out var written);
			ReadOnlySpan<byte> result = destination.Slice(0, written).ToArray();
			if (array != null)
			{
				new Span<byte>(array, 0, written).Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return result;
		}

		private static bool HandleNull(ref Utf8JsonReader reader, ref ReadStack state)
		{
			if (state.Current.SkipProperty)
			{
				state.Current.EndProperty();
				return false;
			}
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			if (jsonPropertyInfo == null || (reader.CurrentDepth == 0 && jsonPropertyInfo.CanBeNull))
			{
				return true;
			}
			if (state.Current.IsProcessingCollectionObject())
			{
				AddNullToCollection(jsonPropertyInfo, ref reader, ref state);
				return false;
			}
			if (state.Current.IsProcessingCollectionProperty())
			{
				if (state.Current.CollectionPropertyInitialized)
				{
					AddNullToCollection(jsonPropertyInfo, ref reader, ref state);
				}
				else
				{
					ApplyObjectToEnumerable(null, ref state, setPropertyDirectly: true);
					state.Current.EndProperty();
				}
				return false;
			}
			if (!jsonPropertyInfo.CanBeNull)
			{
				jsonPropertyInfo.Read(JsonTokenType.Null, ref state, ref reader);
				return false;
			}
			if (state.Current.ReturnValue == null)
			{
				return true;
			}
			if (!jsonPropertyInfo.IgnoreNullValues)
			{
				state.Current.JsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, null);
			}
			return false;
		}

		private static void AddNullToCollection(JsonPropertyInfo jsonPropertyInfo, ref Utf8JsonReader reader, ref ReadStack state)
		{
			JsonPropertyInfo policyProperty = jsonPropertyInfo.ElementClassInfo.PolicyProperty;
			if (policyProperty != null && !policyProperty.CanBeNull)
			{
				policyProperty.ReadEnumerable(JsonTokenType.Null, ref state, ref reader);
			}
			else
			{
				ApplyObjectToEnumerable(null, ref state);
			}
		}

		public static TValue Deserialize<TValue>(ReadOnlySpan<byte> utf8Json, JsonSerializerOptions options = null)
		{
			return (TValue)ParseCore(utf8Json, typeof(TValue), options);
		}

		public static object Deserialize(ReadOnlySpan<byte> utf8Json, Type returnType, JsonSerializerOptions options = null)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			return ParseCore(utf8Json, returnType, options);
		}

		private static object ParseCore(ReadOnlySpan<byte> utf8Json, Type returnType, JsonSerializerOptions options)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			JsonReaderState state = new JsonReaderState(options.GetReaderOptions());
			Utf8JsonReader reader = new Utf8JsonReader(utf8Json, isFinalBlock: true, state);
			return ReadCore(returnType, options, ref reader);
		}

		public static TValue Deserialize<TValue>(ref Utf8JsonReader reader, JsonSerializerOptions options = null)
		{
			return (TValue)ReadValueCore(ref reader, typeof(TValue), options);
		}

		public static object Deserialize(ref Utf8JsonReader reader, Type returnType, JsonSerializerOptions options = null)
		{
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			return ReadValueCore(ref reader, returnType, options);
		}

		private static object ReadValueCore(ref Utf8JsonReader reader, Type returnType, JsonSerializerOptions options)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			ReadStack readStack = default(ReadStack);
			readStack.Current.Initialize(returnType, options);
			ReadValueCore(options, ref reader, ref readStack);
			return readStack.Current.ReturnValue;
		}

		private static void CheckSupportedOptions(JsonReaderOptions readerOptions, string paramName)
		{
			if (readerOptions.CommentHandling == JsonCommentHandling.Allow)
			{
				throw new ArgumentException(SR.JsonSerializerDoesNotSupportComments, paramName);
			}
		}

		private static void ReadValueCore(JsonSerializerOptions options, ref Utf8JsonReader reader, ref ReadStack readStack)
		{
			CheckSupportedOptions(reader.CurrentState.Options, "reader");
			Utf8JsonReader utf8JsonReader = reader;
			ReadOnlySpan<byte> readOnlySpan = default(ReadOnlySpan<byte>);
			ReadOnlySequence<byte> source = default(ReadOnlySequence<byte>);
			try
			{
				JsonTokenType tokenType = reader.TokenType;
				ReadOnlySpan<byte> bytes;
				if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !reader.Read())
				{
					bytes = default(ReadOnlySpan<byte>);
					ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedOneCompleteToken, 0, bytes);
				}
				switch (reader.TokenType)
				{
				case JsonTokenType.StartObject:
				case JsonTokenType.StartArray:
				{
					long tokenStartIndex = reader.TokenStartIndex;
					if (!reader.TrySkip())
					{
						bytes = default(ReadOnlySpan<byte>);
						ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.NotEnoughData, 0, bytes);
					}
					long num = reader.BytesConsumed - tokenStartIndex;
					ReadOnlySequence<byte> originalSequence = reader.OriginalSequence;
					if (originalSequence.IsEmpty)
					{
						bytes = reader.OriginalSpan;
						readOnlySpan = checked(bytes.Slice((int)tokenStartIndex, (int)num));
					}
					else
					{
						source = originalSequence.Slice(tokenStartIndex, num);
					}
					break;
				}
				case JsonTokenType.Number:
				case JsonTokenType.True:
				case JsonTokenType.False:
				case JsonTokenType.Null:
					if (reader.HasValueSequence)
					{
						source = reader.ValueSequence;
					}
					else
					{
						readOnlySpan = reader.ValueSpan;
					}
					break;
				case JsonTokenType.String:
				{
					ReadOnlySequence<byte> originalSequence2 = reader.OriginalSequence;
					if (originalSequence2.IsEmpty)
					{
						bytes = reader.ValueSpan;
						int length = bytes.Length + 2;
						readOnlySpan = reader.OriginalSpan.Slice((int)reader.TokenStartIndex, length);
						break;
					}
					long num2 = 2L;
					if (reader.HasValueSequence)
					{
						num2 += reader.ValueSequence.Length;
					}
					else
					{
						long num3 = num2;
						bytes = reader.ValueSpan;
						num2 = num3 + bytes.Length;
					}
					source = originalSequence2.Slice(reader.TokenStartIndex, num2);
					break;
				}
				default:
				{
					byte b;
					if (reader.HasValueSequence)
					{
						bytes = reader.ValueSequence.First.Span;
						b = bytes[0];
					}
					else
					{
						bytes = reader.ValueSpan;
						b = bytes[0];
					}
					byte nextByte = b;
					bytes = default(ReadOnlySpan<byte>);
					ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedStartOfValueNotFound, nextByte, bytes);
					break;
				}
				}
			}
			catch (JsonReaderException ex)
			{
				reader = utf8JsonReader;
				ThrowHelper.ReThrowWithPath(in readStack, ex);
			}
			int num4 = (readOnlySpan.IsEmpty ? checked((int)source.Length) : readOnlySpan.Length);
			byte[] array = ArrayPool<byte>.Shared.Rent(num4);
			Span<byte> span = array.AsSpan(0, num4);
			try
			{
				if (readOnlySpan.IsEmpty)
				{
					source.CopyTo(span);
				}
				else
				{
					readOnlySpan.CopyTo(span);
				}
				Utf8JsonReader reader2 = new Utf8JsonReader(span, isFinalBlock: true, default(JsonReaderState));
				ReadCore(options, ref reader2, ref readStack);
			}
			catch (JsonException)
			{
				reader = utf8JsonReader;
				throw;
			}
			finally
			{
				span.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private static bool Write(Utf8JsonWriter writer, int originalWriterDepth, int flushThreshold, JsonSerializerOptions options, ref WriteStack state)
		{
			try
			{
				while (true)
				{
					bool flag;
					switch (state.Current.JsonClassInfo.ClassType)
					{
					case ClassType.Enumerable:
						flag = HandleEnumerable(state.Current.JsonClassInfo.ElementClassInfo, options, writer, ref state);
						break;
					case ClassType.Value:
						state.Current.JsonPropertyInfo.Write(ref state, writer);
						flag = true;
						break;
					case ClassType.Dictionary:
					case ClassType.IDictionaryConstructible:
						flag = HandleDictionary(state.Current.JsonClassInfo.ElementClassInfo, options, writer, ref state);
						break;
					default:
						flag = WriteObject(options, writer, ref state);
						break;
					}
					if (flag)
					{
						if (writer.CurrentDepth == originalWriterDepth)
						{
							break;
						}
					}
					else if (writer.CurrentDepth >= options.EffectiveMaxDepth)
					{
						ThrowHelper.ThrowInvalidOperationException_SerializerCycleDetected(options.MaxDepth);
					}
					if (flushThreshold >= 0 && writer.BytesPending > flushThreshold)
					{
						return false;
					}
				}
			}
			catch (InvalidOperationException ex) when (ex.Source == "System.Text.Json.Rethrowable")
			{
				ThrowHelper.ReThrowWithPath(in state, ex);
			}
			catch (JsonException ex2)
			{
				ThrowHelper.AddExceptionInformation(in state, ex2);
				throw;
			}
			return true;
		}

		public static byte[] SerializeToUtf8Bytes<TValue>(TValue value, JsonSerializerOptions options = null)
		{
			return WriteCoreBytes(value, typeof(TValue), options);
		}

		public static byte[] SerializeToUtf8Bytes(object value, Type inputType, JsonSerializerOptions options = null)
		{
			VerifyValueAndType(value, inputType);
			return WriteCoreBytes(value, inputType, options);
		}

		private static bool HandleDictionary(JsonClassInfo elementClassInfo, JsonSerializerOptions options, Utf8JsonWriter writer, ref WriteStack state)
		{
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			if (state.Current.CollectionEnumerator == null)
			{
				IEnumerable enumerable = (IEnumerable)jsonPropertyInfo.GetValueAsObject(state.Current.CurrentValue);
				if (enumerable == null)
				{
					if ((state.Current.JsonClassInfo.ClassType != ClassType.Object || !state.Current.JsonPropertyInfo.IgnoreNullValues) && state.Current.ExtensionDataStatus != ExtensionDataWriteStatus.Writing)
					{
						state.Current.WriteObjectOrArrayStart(ClassType.Dictionary, writer, options, writeNull: true);
					}
					if (state.Current.PopStackOnEndCollection)
					{
						state.Pop();
					}
					return true;
				}
				state.Current.CollectionEnumerator = enumerable.GetEnumerator();
				if (state.Current.ExtensionDataStatus != ExtensionDataWriteStatus.Writing)
				{
					state.Current.WriteObjectOrArrayStart(ClassType.Dictionary, writer, options);
				}
			}
			if (state.Current.CollectionEnumerator.MoveNext())
			{
				bool flag = false;
				string key = null;
				object value = null;
				if (elementClassInfo.ClassType == ClassType.Unknown)
				{
					jsonPropertyInfo.GetDictionaryKeyAndValue(ref state.Current, out key, out value);
					GetRuntimeClassInfo(value, ref elementClassInfo, options);
					flag = true;
				}
				if (elementClassInfo.ClassType == ClassType.Value)
				{
					elementClassInfo.PolicyProperty.WriteDictionary(ref state, writer);
				}
				else
				{
					if (!flag)
					{
						jsonPropertyInfo.GetDictionaryKeyAndValue(ref state.Current, out key, out value);
					}
					state.Push(elementClassInfo, value);
					state.Current.KeyName = key;
				}
				return false;
			}
			if (state.Current.ExtensionDataStatus == ExtensionDataWriteStatus.Writing)
			{
				state.Current.ExtensionDataStatus = ExtensionDataWriteStatus.Finished;
			}
			else
			{
				writer.WriteEndObject();
			}
			if (state.Current.PopStackOnEndCollection)
			{
				state.Pop();
			}
			else
			{
				state.Current.EndDictionary();
			}
			return true;
		}

		internal static void WriteDictionary<TProperty>(JsonConverter<TProperty> converter, JsonSerializerOptions options, ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			string text;
			TProperty val;
			if (current.CollectionEnumerator is IEnumerator<KeyValuePair<string, TProperty>> { Current: var current2 } enumerator)
			{
				text = current2.Key;
				val = enumerator.Current.Value;
			}
			else if (current.CollectionEnumerator is IEnumerator<KeyValuePair<string, object>> { Current: var current3 } enumerator2)
			{
				text = current3.Key;
				val = (TProperty)enumerator2.Current.Value;
			}
			else
			{
				if (!(current.CollectionEnumerator is IDictionaryEnumerator { Key: string key } dictionaryEnumerator))
				{
					throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(current.JsonPropertyInfo.DeclaredPropertyType, current.JsonPropertyInfo.ParentClassType, current.JsonPropertyInfo.PropertyInfo);
				}
				text = key;
				val = (TProperty)dictionaryEnumerator.Value;
			}
			if (options.DictionaryKeyPolicy != null && current.ExtensionDataStatus != ExtensionDataWriteStatus.Writing)
			{
				text = options.DictionaryKeyPolicy.ConvertName(text);
				if (text == null)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializerDictionaryKeyNull(options.DictionaryKeyPolicy.GetType());
				}
			}
			if (val == null)
			{
				writer.WriteNull(text);
				return;
			}
			writer.WritePropertyName(text);
			converter.Write(writer, val, options);
		}

		private static bool HandleEnumerable(JsonClassInfo elementClassInfo, JsonSerializerOptions options, Utf8JsonWriter writer, ref WriteStack state)
		{
			if (state.Current.CollectionEnumerator == null)
			{
				IEnumerable enumerable = (IEnumerable)state.Current.JsonPropertyInfo.GetValueAsObject(state.Current.CurrentValue);
				if (enumerable == null)
				{
					if (state.Current.JsonClassInfo.ClassType != ClassType.Object || !state.Current.JsonPropertyInfo.IgnoreNullValues)
					{
						state.Current.WriteObjectOrArrayStart(ClassType.Enumerable, writer, options, writeNull: true);
					}
					if (state.Current.PopStackOnEndCollection)
					{
						state.Pop();
					}
					return true;
				}
				state.Current.CollectionEnumerator = enumerable.GetEnumerator();
				state.Current.WriteObjectOrArrayStart(ClassType.Enumerable, writer, options);
			}
			if (state.Current.CollectionEnumerator.MoveNext())
			{
				if (elementClassInfo.ClassType == ClassType.Unknown)
				{
					object current = state.Current.CollectionEnumerator.Current;
					GetRuntimeClassInfo(current, ref elementClassInfo, options);
				}
				if (elementClassInfo.ClassType == ClassType.Value)
				{
					elementClassInfo.PolicyProperty.WriteEnumerable(ref state, writer);
				}
				else if (state.Current.CollectionEnumerator.Current == null)
				{
					writer.WriteNullValue();
				}
				else
				{
					object current2 = state.Current.CollectionEnumerator.Current;
					state.Push(elementClassInfo, current2);
				}
				return false;
			}
			writer.WriteEndArray();
			if (state.Current.PopStackOnEndCollection)
			{
				state.Pop();
			}
			else
			{
				state.Current.EndArray();
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool WriteObject(JsonSerializerOptions options, Utf8JsonWriter writer, ref WriteStack state)
		{
			if (!state.Current.StartObjectWritten)
			{
				if (state.Current.CurrentValue == null)
				{
					state.Current.WriteObjectOrArrayStart(ClassType.Object, writer, options, writeNull: true);
					return WriteEndObject(ref state);
				}
				state.Current.WriteObjectOrArrayStart(ClassType.Object, writer, options);
				state.Current.MoveToNextProperty = true;
			}
			if (state.Current.MoveToNextProperty)
			{
				state.Current.NextProperty();
			}
			if (state.Current.ExtensionDataStatus != ExtensionDataWriteStatus.Finished)
			{
				JsonPropertyInfo jsonPropertyInfo = state.Current.JsonClassInfo.PropertyCacheArray[state.Current.PropertyEnumeratorIndex - 1];
				HandleObject(jsonPropertyInfo, options, writer, ref state);
				return false;
			}
			writer.WriteEndObject();
			return WriteEndObject(ref state);
		}

		private static bool WriteEndObject(ref WriteStack state)
		{
			if (state.Current.PopStackOnEndObject)
			{
				state.Pop();
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void HandleObject(JsonPropertyInfo jsonPropertyInfo, JsonSerializerOptions options, Utf8JsonWriter writer, ref WriteStack state)
		{
			if (!jsonPropertyInfo.ShouldSerialize)
			{
				state.Current.MoveToNextProperty = true;
				return;
			}
			bool flag = false;
			object obj = null;
			if (jsonPropertyInfo.ClassType == ClassType.Unknown)
			{
				obj = jsonPropertyInfo.GetValueAsObject(state.Current.CurrentValue);
				flag = true;
				GetRuntimePropertyInfo(obj, state.Current.JsonClassInfo, ref jsonPropertyInfo, options);
			}
			state.Current.JsonPropertyInfo = jsonPropertyInfo;
			if (jsonPropertyInfo.ClassType == ClassType.Value)
			{
				jsonPropertyInfo.Write(ref state, writer);
				state.Current.MoveToNextProperty = true;
				return;
			}
			if (jsonPropertyInfo.ClassType == ClassType.Enumerable)
			{
				if (HandleEnumerable(jsonPropertyInfo.ElementClassInfo, options, writer, ref state))
				{
					state.Current.MoveToNextProperty = true;
				}
				return;
			}
			if (jsonPropertyInfo.ClassType == ClassType.Dictionary)
			{
				if (HandleDictionary(jsonPropertyInfo.ElementClassInfo, options, writer, ref state))
				{
					state.Current.MoveToNextProperty = true;
				}
				return;
			}
			if (jsonPropertyInfo.ClassType == ClassType.IDictionaryConstructible)
			{
				state.Current.IsIDictionaryConstructibleProperty = true;
				if (HandleDictionary(jsonPropertyInfo.ElementClassInfo, options, writer, ref state))
				{
					state.Current.MoveToNextProperty = true;
				}
				return;
			}
			if (!flag)
			{
				obj = jsonPropertyInfo.GetValueAsObject(state.Current.CurrentValue);
			}
			if (obj != null)
			{
				JsonPropertyInfo jsonPropertyInfo2 = state.Current.JsonPropertyInfo;
				state.Current.MoveToNextProperty = true;
				JsonClassInfo runtimeClassInfo = jsonPropertyInfo.RuntimeClassInfo;
				state.Push(runtimeClassInfo, obj);
				state.Current.JsonPropertyInfo = jsonPropertyInfo2;
			}
			else
			{
				if (!jsonPropertyInfo.IgnoreNullValues)
				{
					writer.WriteNull(jsonPropertyInfo.EscapedName.Value);
				}
				state.Current.MoveToNextProperty = true;
			}
		}

		private static void GetRuntimeClassInfo(object value, ref JsonClassInfo jsonClassInfo, JsonSerializerOptions options)
		{
			if (value != null)
			{
				Type type = value.GetType();
				if (type != typeof(object))
				{
					jsonClassInfo = options.GetOrAddClass(type);
				}
			}
		}

		private static void GetRuntimePropertyInfo(object value, JsonClassInfo jsonClassInfo, ref JsonPropertyInfo jsonPropertyInfo, JsonSerializerOptions options)
		{
			if (value != null)
			{
				Type type = value.GetType();
				if (type != typeof(object))
				{
					jsonPropertyInfo = jsonClassInfo.GetOrAddPolymorphicProperty(jsonPropertyInfo, type, options);
				}
			}
		}

		private static void VerifyValueAndType(object value, Type type)
		{
			if (type == null)
			{
				if (value != null)
				{
					throw new ArgumentNullException("type");
				}
			}
			else if (value != null && !type.IsAssignableFrom(value.GetType()))
			{
				ThrowHelper.ThrowArgumentException_DeserializeWrongType(type, value);
			}
		}

		private static byte[] WriteCoreBytes(object value, Type type, JsonSerializerOptions options)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			using PooledByteBufferWriter pooledByteBufferWriter = new PooledByteBufferWriter(options.DefaultBufferSize);
			WriteCore(pooledByteBufferWriter, value, type, options);
			return pooledByteBufferWriter.WrittenMemory.ToArray();
		}

		private static string WriteCoreString(object value, Type type, JsonSerializerOptions options)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			using PooledByteBufferWriter pooledByteBufferWriter = new PooledByteBufferWriter(options.DefaultBufferSize);
			WriteCore(pooledByteBufferWriter, value, type, options);
			return JsonReaderHelper.TranscodeHelper(pooledByteBufferWriter.WrittenMemory.Span);
		}

		private static void WriteValueCore(Utf8JsonWriter writer, object value, Type type, JsonSerializerOptions options)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			WriteCore(writer, value, type, options);
		}

		private static void WriteCore(PooledByteBufferWriter output, object value, Type type, JsonSerializerOptions options)
		{
			using Utf8JsonWriter writer = new Utf8JsonWriter(output, options.GetWriterOptions());
			WriteCore(writer, value, type, options);
		}

		private static void WriteCore(Utf8JsonWriter writer, object value, Type type, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
			}
			else
			{
				if (type == typeof(object))
				{
					type = value.GetType();
				}
				WriteStack state = default(WriteStack);
				state.Current.Initialize(type, options);
				state.Current.CurrentValue = value;
				Write(writer, writer.CurrentDepth, -1, options, ref state);
			}
			writer.Flush();
		}

		public static Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return WriteAsyncCore(utf8Json, value, typeof(TValue), options, cancellationToken);
		}

		public static Task SerializeAsync(Stream utf8Json, object value, Type inputType, JsonSerializerOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			VerifyValueAndType(value, inputType);
			return WriteAsyncCore(utf8Json, value, inputType, options, cancellationToken);
		}

		private static async Task WriteAsyncCore(Stream utf8Json, object value, Type inputType, JsonSerializerOptions options, CancellationToken cancellationToken)
		{
			if (options == null)
			{
				options = JsonSerializerOptions.s_defaultOptions;
			}
			JsonWriterOptions writerOptions = options.GetWriterOptions();
			using PooledByteBufferWriter bufferWriter = new PooledByteBufferWriter(options.DefaultBufferSize);
			using Utf8JsonWriter writer = new Utf8JsonWriter(bufferWriter, writerOptions);
			if (value == null)
			{
				writer.WriteNullValue();
				writer.Flush();
				await bufferWriter.WriteToStreamAsync(utf8Json, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			if (inputType == null)
			{
				inputType = value.GetType();
			}
			WriteStack state = default(WriteStack);
			state.Current.Initialize(inputType, options);
			state.Current.CurrentValue = value;
			bool isFinalBlock;
			do
			{
				int flushThreshold = (int)((double)bufferWriter.Capacity * 0.9);
				isFinalBlock = Write(writer, 0, flushThreshold, options, ref state);
				writer.Flush();
				await bufferWriter.WriteToStreamAsync(utf8Json, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				bufferWriter.Clear();
			}
			while (!isFinalBlock);
		}

		public static string Serialize<TValue>(TValue value, JsonSerializerOptions options = null)
		{
			return WriteCoreString(value, typeof(TValue), options);
		}

		public static string Serialize(object value, Type inputType, JsonSerializerOptions options = null)
		{
			VerifyValueAndType(value, inputType);
			return WriteCoreString(value, inputType, options);
		}

		public static void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions options = null)
		{
			WriteValueCore(writer, value, typeof(TValue), options);
		}

		public static void Serialize(Utf8JsonWriter writer, object value, Type inputType, JsonSerializerOptions options = null)
		{
			VerifyValueAndType(value, inputType);
			WriteValueCore(writer, value, inputType, options);
		}
	}
	public sealed class JsonSerializerOptions
	{
		internal const int BufferSizeDefault = 16384;

		internal static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

		private readonly ConcurrentDictionary<Type, JsonClassInfo> _classes = new ConcurrentDictionary<Type, JsonClassInfo>();

		private readonly ConcurrentDictionary<Type, JsonPropertyInfo> _objectJsonProperties = new ConcurrentDictionary<Type, JsonPropertyInfo>();

		private static ConcurrentDictionary<string, ImmutableCollectionCreator> s_createRangeDelegates = new ConcurrentDictionary<string, ImmutableCollectionCreator>();

		private MemberAccessor _memberAccessorStrategy;

		private JsonNamingPolicy _dictionayKeyPolicy;

		private JsonNamingPolicy _jsonPropertyNamingPolicy;

		private JsonCommentHandling _readCommentHandling;

		private JavaScriptEncoder _encoder;

		private int _defaultBufferSize = 16384;

		private int _maxDepth;

		private bool _allowTrailingCommas;

		private bool _haveTypesBeenCreated;

		private bool _ignoreNullValues;

		private bool _ignoreReadOnlyProperties;

		private bool _propertyNameCaseInsensitive;

		private bool _writeIndented;

		private static readonly Dictionary<Type, JsonConverter> s_defaultSimpleConverters = GetDefaultSimpleConverters();

		private static readonly List<JsonConverter> s_defaultFactoryConverters = GetDefaultConverters();

		private readonly ConcurrentDictionary<Type, JsonConverter> _converters = new ConcurrentDictionary<Type, JsonConverter>();

		private const int NumberOfSimpleConverters = 21;

		public bool AllowTrailingCommas
		{
			get
			{
				return _allowTrailingCommas;
			}
			set
			{
				VerifyMutable();
				_allowTrailingCommas = value;
			}
		}

		public int DefaultBufferSize
		{
			get
			{
				return _defaultBufferSize;
			}
			set
			{
				VerifyMutable();
				if (value < 1)
				{
					throw new ArgumentException(SR.SerializationInvalidBufferSize);
				}
				_defaultBufferSize = value;
			}
		}

		public JavaScriptEncoder Encoder
		{
			get
			{
				return _encoder;
			}
			set
			{
				VerifyMutable();
				_encoder = value;
			}
		}

		public JsonNamingPolicy DictionaryKeyPolicy
		{
			get
			{
				return _dictionayKeyPolicy;
			}
			set
			{
				VerifyMutable();
				_dictionayKeyPolicy = value;
			}
		}

		public bool IgnoreNullValues
		{
			get
			{
				return _ignoreNullValues;
			}
			set
			{
				VerifyMutable();
				_ignoreNullValues = value;
			}
		}

		public bool IgnoreReadOnlyProperties
		{
			get
			{
				return _ignoreReadOnlyProperties;
			}
			set
			{
				VerifyMutable();
				_ignoreReadOnlyProperties = value;
			}
		}

		public int MaxDepth
		{
			get
			{
				return _maxDepth;
			}
			set
			{
				VerifyMutable();
				if (value < 0)
				{
					throw ThrowHelper.GetArgumentOutOfRangeException_MaxDepthMustBePositive("value");
				}
				_maxDepth = value;
				EffectiveMaxDepth = ((value == 0) ? 64 : value);
			}
		}

		internal int EffectiveMaxDepth { get; private set; } = 64;

		public JsonNamingPolicy PropertyNamingPolicy
		{
			get
			{
				return _jsonPropertyNamingPolicy;
			}
			set
			{
				VerifyMutable();
				_jsonPropertyNamingPolicy = value;
			}
		}

		public bool PropertyNameCaseInsensitive
		{
			get
			{
				return _propertyNameCaseInsensitive;
			}
			set
			{
				VerifyMutable();
				_propertyNameCaseInsensitive = value;
			}
		}

		public JsonCommentHandling ReadCommentHandling
		{
			get
			{
				return _readCommentHandling;
			}
			set
			{
				VerifyMutable();
				if ((int)value > 1)
				{
					throw new ArgumentOutOfRangeException("value", SR.JsonSerializerDoesNotSupportComments);
				}
				_readCommentHandling = value;
			}
		}

		public bool WriteIndented
		{
			get
			{
				return _writeIndented;
			}
			set
			{
				VerifyMutable();
				_writeIndented = value;
			}
		}

		internal MemberAccessor MemberAccessorStrategy
		{
			get
			{
				if (_memberAccessorStrategy == null)
				{
					_memberAccessorStrategy = new ReflectionMemberAccessor();
				}
				return _memberAccessorStrategy;
			}
		}

		public IList<JsonConverter> Converters { get; }

		private static IEnumerable<JsonConverter> DefaultSimpleConverters
		{
			get
			{
				yield return new JsonConverterBoolean();
				yield return new JsonConverterByte();
				yield return new JsonConverterByteArray();
				yield return new JsonConverterChar();
				yield return new JsonConverterDateTime();
				yield return new JsonConverterDateTimeOffset();
				yield return new JsonConverterDouble();
				yield return new JsonConverterDecimal();
				yield return new JsonConverterGuid();
				yield return new JsonConverterInt16();
				yield return new JsonConverterInt32();
				yield return new JsonConverterInt64();
				yield return new JsonConverterJsonElement();
				yield return new JsonConverterObject();
				yield return new JsonConverterSByte();
				yield return new JsonConverterSingle();
				yield return new JsonConverterString();
				yield return new JsonConverterUInt16();
				yield return new JsonConverterUInt32();
				yield return new JsonConverterUInt64();
				yield return new JsonConverterUri();
			}
		}

		public JsonSerializerOptions()
		{
			Converters = new ConverterList(this);
		}

		internal JsonClassInfo GetOrAddClass(Type classType)
		{
			_haveTypesBeenCreated = true;
			if (!_classes.TryGetValue(classType, out var value))
			{
				return _classes.GetOrAdd(classType, new JsonClassInfo(classType, this));
			}
			return value;
		}

		internal JsonReaderOptions GetReaderOptions()
		{
			return new JsonReaderOptions
			{
				AllowTrailingCommas = AllowTrailingCommas,
				CommentHandling = ReadCommentHandling,
				MaxDepth = MaxDepth
			};
		}

		internal JsonWriterOptions GetWriterOptions()
		{
			return new JsonWriterOptions
			{
				Encoder = Encoder,
				Indented = WriteIndented,
				SkipValidation = true
			};
		}

		internal JsonPropertyInfo GetJsonPropertyInfoFromClassInfo(Type objectType, JsonSerializerOptions options)
		{
			if (!_objectJsonProperties.TryGetValue(objectType, out var value))
			{
				value = JsonClassInfo.CreateProperty(objectType, objectType, objectType, null, typeof(object), null, options);
				_objectJsonProperties[objectType] = value;
			}
			return value;
		}

		internal bool CreateRangeDelegatesContainsKey(string key)
		{
			return s_createRangeDelegates.ContainsKey(key);
		}

		internal bool TryGetCreateRangeDelegate(string delegateKey, out ImmutableCollectionCreator createRangeDelegate)
		{
			if (s_createRangeDelegates.TryGetValue(delegateKey, out createRangeDelegate))
			{
				return createRangeDelegate != null;
			}
			return false;
		}

		internal bool TryAddCreateRangeDelegate(string key, ImmutableCollectionCreator createRangeDelegate)
		{
			return s_createRangeDelegates.TryAdd(key, createRangeDelegate);
		}

		internal void VerifyMutable()
		{
			if (_haveTypesBeenCreated)
			{
				ThrowHelper.ThrowInvalidOperationException_SerializerOptionsImmutable();
			}
		}

		private static Dictionary<Type, JsonConverter> GetDefaultSimpleConverters()
		{
			Dictionary<Type, JsonConverter> dictionary = new Dictionary<Type, JsonConverter>(21);
			foreach (JsonConverter defaultSimpleConverter in DefaultSimpleConverters)
			{
				dictionary.Add(defaultSimpleConverter.TypeToConvert, defaultSimpleConverter);
			}
			return dictionary;
		}

		private static List<JsonConverter> GetDefaultConverters()
		{
			List<JsonConverter> list = new List<JsonConverter>(2);
			list.Add(new JsonConverterEnum());
			list.Add(new JsonKeyValuePairConverter());
			return list;
		}

		internal JsonConverter DetermineConverterForProperty(Type parentClassType, Type runtimePropertyType, PropertyInfo propertyInfo)
		{
			JsonConverter jsonConverter = null;
			if (propertyInfo != null)
			{
				JsonConverterAttribute jsonConverterAttribute = (JsonConverterAttribute)GetAttributeThatCanHaveMultiple(parentClassType, typeof(JsonConverterAttribute), propertyInfo);
				if (jsonConverterAttribute != null)
				{
					jsonConverter = GetConverterFromAttribute(jsonConverterAttribute, runtimePropertyType, parentClassType, propertyInfo);
				}
			}
			if (jsonConverter == null)
			{
				jsonConverter = GetConverter(runtimePropertyType);
			}
			if (jsonConverter is JsonConverterFactory jsonConverterFactory)
			{
				jsonConverter = jsonConverterFactory.GetConverterInternal(runtimePropertyType, this);
			}
			return jsonConverter;
		}

		public JsonConverter GetConverter(Type typeToConvert)
		{
			if (_converters.TryGetValue(typeToConvert, out var value))
			{
				return value;
			}
			foreach (JsonConverter converter in Converters)
			{
				if (converter.CanConvert(typeToConvert))
				{
					value = converter;
					break;
				}
			}
			if (value == null)
			{
				JsonConverterAttribute jsonConverterAttribute = (JsonConverterAttribute)GetAttributeThatCanHaveMultiple(typeToConvert, typeof(JsonConverterAttribute));
				if (jsonConverterAttribute != null)
				{
					value = GetConverterFromAttribute(jsonConverterAttribute, typeToConvert, typeToConvert, null);
				}
			}
			if (value == null)
			{
				if (s_defaultSimpleConverters.TryGetValue(typeToConvert, out var value2))
				{
					value = value2;
				}
				else
				{
					foreach (JsonConverter s_defaultFactoryConverter in s_defaultFactoryConverters)
					{
						if (s_defaultFactoryConverter.CanConvert(typeToConvert))
						{
							value = s_defaultFactoryConverter;
							break;
						}
					}
				}
			}
			if (value is JsonConverterFactory jsonConverterFactory)
			{
				value = jsonConverterFactory.GetConverterInternal(typeToConvert, this);
				if (value == null || value.TypeToConvert == null)
				{
					throw new ArgumentNullException("typeToConvert");
				}
			}
			if (value != null)
			{
				Type typeToConvert2 = value.TypeToConvert;
				if (!typeToConvert2.IsAssignableFrom(typeToConvert) && !typeToConvert.IsAssignableFrom(typeToConvert2))
				{
					ThrowHelper.ThrowInvalidOperationException_SerializationConverterNotCompatible(value.GetType(), typeToConvert);
				}
			}
			if (_haveTypesBeenCreated)
			{
				_converters.TryAdd(typeToConvert, value);
			}
			return value;
		}

		internal bool HasConverter(Type typeToConvert)
		{
			return GetConverter(typeToConvert) != null;
		}

		private JsonConverter GetConverterFromAttribute(JsonConverterAttribute converterAttribute, Type typeToConvert, Type classTypeAttributeIsOn, PropertyInfo propertyInfo)
		{
			Type converterType = converterAttribute.ConverterType;
			JsonConverter jsonConverter;
			if (converterType == null)
			{
				jsonConverter = converterAttribute.CreateConverter(typeToConvert);
				if (jsonConverter == null)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(classTypeAttributeIsOn, propertyInfo, typeToConvert);
				}
			}
			else
			{
				ConstructorInfo constructor = converterType.GetConstructor(Type.EmptyTypes);
				if (!typeof(JsonConverter).IsAssignableFrom(converterType) || !constructor.IsPublic)
				{
					ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeInvalid(classTypeAttributeIsOn, propertyInfo);
				}
				jsonConverter = (JsonConverter)Activator.CreateInstance(converterType);
			}
			if (!jsonConverter.CanConvert(typeToConvert))
			{
				ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(classTypeAttributeIsOn, propertyInfo, typeToConvert);
			}
			return jsonConverter;
		}

		private static Attribute GetAttributeThatCanHaveMultiple(Type classType, Type attributeType, PropertyInfo propertyInfo)
		{
			object[] attributes = propertyInfo?.GetCustomAttributes(attributeType, inherit: false);
			return GetAttributeThatCanHaveMultiple(attributeType, classType, propertyInfo, attributes);
		}

		private static Attribute GetAttributeThatCanHaveMultiple(Type classType, Type attributeType)
		{
			object[] customAttributes = classType.GetCustomAttributes(attributeType, inherit: false);
			return GetAttributeThatCanHaveMultiple(attributeType, classType, null, customAttributes);
		}

		private static Attribute GetAttributeThatCanHaveMultiple(Type attributeType, Type classType, PropertyInfo propertyInfo, object[] attributes)
		{
			if (attributes.Length == 0)
			{
				return null;
			}
			if (attributes.Length == 1)
			{
				return (Attribute)attributes[0];
			}
			ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateAttribute(attributeType, classType, propertyInfo);
			return null;
		}
	}
	internal abstract class MemberAccessor
	{
		public abstract JsonClassInfo.ConstructorDelegate CreateConstructor(Type classType);

		public abstract ImmutableCollectionCreator ImmutableCollectionCreateRange(Type constructingType, Type collectionType, Type elementType);

		public abstract ImmutableCollectionCreator ImmutableDictionaryCreateRange(Type constructingType, Type collectionType, Type elementType);

		protected MethodInfo ImmutableCollectionCreateRangeMethod(Type constructingType, Type elementType)
		{
			MethodInfo methodInfo = FindImmutableCreateRangeMethod(constructingType);
			if (methodInfo == null)
			{
				return null;
			}
			return methodInfo.MakeGenericMethod(elementType);
		}

		protected MethodInfo ImmutableDictionaryCreateRangeMethod(Type constructingType, Type elementType)
		{
			MethodInfo methodInfo = FindImmutableCreateRangeMethod(constructingType);
			if (methodInfo == null)
			{
				return null;
			}
			return methodInfo.MakeGenericMethod(typeof(string), elementType);
		}

		private MethodInfo FindImmutableCreateRangeMethod(Type constructingType)
		{
			MethodInfo[] methods = constructingType.GetMethods();
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo in array)
			{
				if (methodInfo.Name == "CreateRange" && methodInfo.GetParameters().Length == 1)
				{
					return methodInfo;
				}
			}
			return null;
		}

		public abstract Func<object, TProperty> CreatePropertyGetter<TClass, TProperty>(PropertyInfo propertyInfo);

		public abstract Action<object, TProperty> CreatePropertySetter<TClass, TProperty>(PropertyInfo propertyInfo);
	}
	internal sealed class PooledByteBufferWriter : IBufferWriter<byte>, IDisposable
	{
		private byte[] _rentedBuffer;

		private int _index;

		private const int MinimumBufferSize = 256;

		public ReadOnlyMemory<byte> WrittenMemory => _rentedBuffer.AsMemory(0, _index);

		public int WrittenCount => _index;

		public int Capacity => _rentedBuffer.Length;

		public int FreeCapacity => _rentedBuffer.Length - _index;

		public PooledByteBufferWriter(int initialCapacity)
		{
			_rentedBuffer = ArrayPool<byte>.Shared.Rent(initialCapacity);
			_index = 0;
		}

		public void Clear()
		{
			ClearHelper();
		}

		private void ClearHelper()
		{
			_rentedBuffer.AsSpan(0, _index).Clear();
			_index = 0;
		}

		public void Dispose()
		{
			if (_rentedBuffer != null)
			{
				ClearHelper();
				ArrayPool<byte>.Shared.Return(_rentedBuffer);
				_rentedBuffer = null;
			}
		}

		public void Advance(int count)
		{
			_index += count;
		}

		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			CheckAndResizeBuffer(sizeHint);
			return _rentedBuffer.AsMemory(_index);
		}

		public Span<byte> GetSpan(int sizeHint = 0)
		{
			CheckAndResizeBuffer(sizeHint);
			return _rentedBuffer.AsSpan(_index);
		}

		internal Task WriteToStreamAsync(Stream destination, CancellationToken cancellationToken)
		{
			return destination.WriteAsync(_rentedBuffer, 0, _index, cancellationToken);
		}

		private void CheckAndResizeBuffer(int sizeHint)
		{
			if (sizeHint == 0)
			{
				sizeHint = 256;
			}
			int num = _rentedBuffer.Length - _index;
			if (sizeHint > num)
			{
				int num2 = Math.Max(sizeHint, _rentedBuffer.Length);
				int minimumLength = checked(_rentedBuffer.Length + num2);
				byte[] rentedBuffer = _rentedBuffer;
				_rentedBuffer = ArrayPool<byte>.Shared.Rent(minimumLength);
				Span<byte> span = rentedBuffer.AsSpan(0, _index);
				span.CopyTo(_rentedBuffer);
				span.Clear();
				ArrayPool<byte>.Shared.Return(rentedBuffer);
			}
		}
	}
	internal readonly struct PropertyRef(ulong key, JsonPropertyInfo info)
	{
		public readonly ulong Key = key;

		public readonly JsonPropertyInfo Info = info;
	}
	[DebuggerDisplay("Path:{JsonPath()} Current: ClassType.{Current.JsonClassInfo.ClassType}, {Current.JsonClassInfo.Type.Name}")]
	internal struct ReadStack
	{
		internal static readonly char[] SpecialCharacters = new char[18]
		{
			'.', ' ', '\'', '/', '"', '[', ']', '(', ')', '\t',
			'\n', '\r', '\f', '\b', '\\', '\u0085', '\u2028', '\u2029'
		};

		public ReadStackFrame Current;

		private List<ReadStackFrame> _previous;

		public int _index;

		public long BytesConsumed;

		internal bool ReadAhead;

		public bool IsLastFrame => _index == 0;

		public void Push()
		{
			if (_previous == null)
			{
				_previous = new List<ReadStackFrame>();
			}
			if (_index == _previous.Count)
			{
				_previous.Add(Current);
			}
			else
			{
				_previous[_index] = Current;
			}
			Current.Reset();
			_index++;
		}

		public void Pop()
		{
			Current = _previous[--_index];
		}

		public string JsonPath()
		{
			StringBuilder stringBuilder = new StringBuilder("$");
			for (int i = 0; i < _index; i++)
			{
				AppendStackFrame(stringBuilder, _previous[i]);
			}
			AppendStackFrame(stringBuilder, in Current);
			return stringBuilder.ToString();
		}

		private void AppendStackFrame(StringBuilder sb, in ReadStackFrame frame)
		{
			string propertyName = GetPropertyName(in frame);
			AppendPropertyName(sb, propertyName);
			if (frame.JsonClassInfo == null)
			{
				return;
			}
			if (frame.IsProcessingDictionary())
			{
				AppendPropertyName(sb, frame.KeyName);
			}
			else if (frame.IsProcessingEnumerable())
			{
				IList list = frame.TempEnumerableValues;
				if (list == null && frame.ReturnValue != null)
				{
					list = (IList)(frame.JsonPropertyInfo?.GetValueAsObject(frame.ReturnValue));
				}
				if (list != null)
				{
					sb.Append("[");
					sb.Append(list.Count);
					sb.Append("]");
				}
			}
		}

		private void AppendPropertyName(StringBuilder sb, string propertyName)
		{
			if (propertyName != null)
			{
				if (propertyName.IndexOfAny(SpecialCharacters) != -1)
				{
					sb.Append("['");
					sb.Append(propertyName);
					sb.Append("']");
				}
				else
				{
					sb.Append('.');
					sb.Append(propertyName);
				}
			}
		}

		private string GetPropertyName(in ReadStackFrame frame)
		{
			byte[] array = frame.JsonPropertyName;
			if (array == null)
			{
				array = frame.JsonPropertyInfo?.JsonPropertyName;
			}
			if (array != null)
			{
				return JsonHelpers.Utf8GetString(array);
			}
			return null;
		}
	}
	[DebuggerDisplay("ClassType.{JsonClassInfo.ClassType}, {JsonClassInfo.Type.Name}")]
	internal struct ReadStackFrame
	{
		public object ReturnValue;

		public JsonClassInfo JsonClassInfo;

		public string KeyName;

		public byte[] JsonPropertyName;

		public JsonPropertyInfo JsonPropertyInfo;

		public IList TempEnumerableValues;

		public bool CollectionPropertyInitialized;

		public bool Drain;

		public IDictionary TempDictionaryValues;

		public int PropertyIndex;

		public List<PropertyRef> PropertyRefCache;

		public bool SkipProperty
		{
			get
			{
				if (!Drain)
				{
					if (JsonPropertyInfo != null && !JsonPropertyInfo.IsPropertyPolicy)
					{
						return !JsonPropertyInfo.ShouldDeserialize;
					}
					return false;
				}
				return true;
			}
		}

		public bool IsProcessingCollectionObject()
		{
			return IsProcessingObject((ClassType)56);
		}

		public bool IsProcessingCollectionProperty()
		{
			return IsProcessingProperty((ClassType)56);
		}

		public bool IsProcessingCollection()
		{
			if (!IsProcessingObject((ClassType)56))
			{
				return IsProcessingProperty((ClassType)56);
			}
			return true;
		}

		public bool IsProcessingDictionary()
		{
			if (!IsProcessingObject(ClassType.Dictionary))
			{
				return IsProcessingProperty(ClassType.Dictionary);
			}
			return true;
		}

		public bool IsProcessingIDictionaryConstructible()
		{
			if (!IsProcessingObject(ClassType.IDictionaryConstructible))
			{
				return IsProcessingProperty(ClassType.IDictionaryConstructible);
			}
			return true;
		}

		public bool IsProcessingDictionaryOrIDictionaryConstructibleObject()
		{
			return IsProcessingObject((ClassType)48);
		}

		public bool IsProcessingDictionaryOrIDictionaryConstructibleProperty()
		{
			return IsProcessingProperty((ClassType)48);
		}

		public bool IsProcessingDictionaryOrIDictionaryConstructible()
		{
			if (!IsProcessingObject((ClassType)48))
			{
				return IsProcessingProperty((ClassType)48);
			}
			return true;
		}

		public bool IsProcessingEnumerable()
		{
			if (!IsProcessingObject(ClassType.Enumerable))
			{
				return IsProcessingProperty(ClassType.Enumerable);
			}
			return true;
		}

		public bool IsProcessingObject(ClassType classTypes)
		{
			return (JsonClassInfo.ClassType & classTypes) != 0;
		}

		public bool IsProcessingProperty(ClassType classTypes)
		{
			if (JsonPropertyInfo != null && !JsonPropertyInfo.IsPropertyPolicy)
			{
				return (JsonPropertyInfo.ClassType & classTypes) != 0;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsProcessingValue()
		{
			if (SkipProperty)
			{
				return false;
			}
			ClassType classType = (CollectionPropertyInitialized ? JsonPropertyInfo.ElementClassInfo.ClassType : ((JsonPropertyInfo != null) ? JsonPropertyInfo.ClassType : JsonClassInfo.ClassType));
			return (classType & (ClassType)5) != 0;
		}

		public void Initialize(Type type, JsonSerializerOptions options)
		{
			JsonClassInfo = options.GetOrAddClass(type);
			InitializeJsonPropertyInfo();
		}

		public void InitializeJsonPropertyInfo()
		{
			if (IsProcessingObject((ClassType)60))
			{
				JsonPropertyInfo = JsonClassInfo.PolicyProperty;
			}
		}

		public void Reset()
		{
			Drain = false;
			JsonClassInfo = null;
			PropertyRefCache = null;
			ReturnValue = null;
			EndObject();
		}

		public void EndObject()
		{
			PropertyIndex = 0;
			EndProperty();
		}

		public void EndProperty()
		{
			CollectionPropertyInitialized = false;
			JsonPropertyInfo = null;
			TempEnumerableValues = null;
			TempDictionaryValues = null;
			JsonPropertyName = null;
			KeyName = null;
		}

		public static object CreateEnumerableValue(ref Utf8JsonReader reader, ref ReadStack state)
		{
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			if (jsonPropertyInfo.EnumerableConverter != null)
			{
				JsonClassInfo elementClassInfo = jsonPropertyInfo.ElementClassInfo;
				IList tempEnumerableValues = ((elementClassInfo.ClassType != ClassType.Value) ? new List<object>() : elementClassInfo.PolicyProperty.CreateConverterList());
				state.Current.TempEnumerableValues = tempEnumerableValues;
				if (!jsonPropertyInfo.IsPropertyPolicy && !state.Current.JsonPropertyInfo.RuntimePropertyType.FullName.StartsWith("System.Collections.Immutable.ImmutableArray`1"))
				{
					jsonPropertyInfo.SetValueAsObject(state.Current.ReturnValue, null);
				}
				return null;
			}
			Type runtimePropertyType = jsonPropertyInfo.RuntimePropertyType;
			if (typeof(IList).IsAssignableFrom(runtimePropertyType))
			{
				JsonClassInfo jsonClassInfo = ((!(jsonPropertyInfo.DeclaredPropertyType == jsonPropertyInfo.ImplementedPropertyType)) ? jsonPropertyInfo.DeclaredTypeClassInfo : jsonPropertyInfo.RuntimeClassInfo);
				if (jsonClassInfo.CreateObject() is IList result)
				{
					return result;
				}
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(jsonPropertyInfo.DeclaredPropertyType);
				return null;
			}
			ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(runtimePropertyType);
			return null;
		}

		public Type GetElementType()
		{
			if (IsProcessingCollectionProperty())
			{
				return JsonPropertyInfo.ElementClassInfo.Type;
			}
			if (IsProcessingCollectionObject())
			{
				return JsonClassInfo.ElementClassInfo.Type;
			}
			return JsonPropertyInfo.RuntimePropertyType;
		}

		public static IEnumerable GetEnumerableValue(in ReadStackFrame current)
		{
			if (current.IsProcessingObject(ClassType.Enumerable) && current.ReturnValue != null)
			{
				return (IEnumerable)current.ReturnValue;
			}
			return current.TempEnumerableValues;
		}

		public void SetReturnValue(object value)
		{
			ReturnValue = value;
		}
	}
	internal sealed class ReflectionMemberAccessor : MemberAccessor
	{
		private delegate TProperty GetProperty<TClass, TProperty>(TClass obj);

		private delegate TProperty GetPropertyByRef<TClass, TProperty>(ref TClass obj);

		private delegate void SetProperty<TClass, TProperty>(TClass obj, TProperty value);

		private delegate void SetPropertyByRef<TClass, TProperty>(ref TClass obj, TProperty value);

		private delegate Func<object, TProperty> GetPropertyByRefFactory<TClass, TProperty>(GetPropertyByRef<TClass, TProperty> set);

		private delegate Action<object, TProperty> SetPropertyByRefFactory<TClass, TProperty>(SetPropertyByRef<TClass, TProperty> set);

		private static readonly MethodInfo s_createStructPropertyGetterMethod = new GetPropertyByRefFactory<int, int>(CreateStructPropertyGetter).Method.GetGenericMethodDefinition();

		private static readonly MethodInfo s_createStructPropertySetterMethod = new SetPropertyByRefFactory<int, int>(CreateStructPropertySetter).Method.GetGenericMethodDefinition();

		public override JsonClassInfo.ConstructorDelegate CreateConstructor(Type type)
		{
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			if (type.IsAbstract)
			{
				return null;
			}
			if (constructor == null && !type.IsValueType)
			{
				return null;
			}
			return () => Activator.CreateInstance(type);
		}

		public override ImmutableCollectionCreator ImmutableCollectionCreateRange(Type constructingType, Type collectionType, Type elementType)
		{
			MethodInfo methodInfo = ImmutableCollectionCreateRangeMethod(constructingType, elementType);
			if (methodInfo == null)
			{
				return null;
			}
			Type type = typeof(ImmutableEnumerableCreator<, >).MakeGenericType(elementType, collectionType);
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			ImmutableCollectionCreator immutableCollectionCreator = (ImmutableCollectionCreator)constructor.Invoke(new object[0]);
			immutableCollectionCreator.RegisterCreatorDelegateFromMethod(methodInfo);
			return immutableCollectionCreator;
		}

		public override ImmutableCollectionCreator ImmutableDictionaryCreateRange(Type constructingType, Type collectionType, Type elementType)
		{
			MethodInfo methodInfo = ImmutableDictionaryCreateRangeMethod(constructingType, elementType);
			if (methodInfo == null)
			{
				return null;
			}
			Type type = typeof(ImmutableDictionaryCreator<, >).MakeGenericType(elementType, collectionType);
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			ImmutableCollectionCreator immutableCollectionCreator = (ImmutableCollectionCreator)constructor.Invoke(new object[0]);
			immutableCollectionCreator.RegisterCreatorDelegateFromMethod(methodInfo);
			return immutableCollectionCreator;
		}

		public override Func<object, TProperty> CreatePropertyGetter<TClass, TProperty>(PropertyInfo propertyInfo)
		{
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (typeof(TClass).IsValueType)
			{
				GetPropertyByRefFactory<TClass, TProperty> getPropertyByRefFactory = CreateDelegate<GetPropertyByRefFactory<TClass, TProperty>>(s_createStructPropertyGetterMethod.MakeGenericMethod(typeof(TClass), typeof(TProperty)));
				GetPropertyByRef<TClass, TProperty> set = CreateDelegate<GetPropertyByRef<TClass, TProperty>>(getMethod);
				return getPropertyByRefFactory(set);
			}
			GetProperty<TClass, TProperty> propertyGetter = CreateDelegate<GetProperty<TClass, TProperty>>(getMethod);
			return (object obj) => propertyGetter((TClass)obj);
		}

		public override Action<object, TProperty> CreatePropertySetter<TClass, TProperty>(PropertyInfo propertyInfo)
		{
			MethodInfo setMethod = propertyInfo.GetSetMethod();
			if (typeof(TClass).IsValueType)
			{
				SetPropertyByRefFactory<TClass, TProperty> setPropertyByRefFactory = CreateDelegate<SetPropertyByRefFactory<TClass, TProperty>>(s_createStructPropertySetterMethod.MakeGenericMethod(typeof(TClass), typeof(TProperty)));
				SetPropertyByRef<TClass, TProperty> set = CreateDelegate<SetPropertyByRef<TClass, TProperty>>(setMethod);
				return setPropertyByRefFactory(set);
			}
			SetProperty<TClass, TProperty> propertySetter = CreateDelegate<SetProperty<TClass, TProperty>>(setMethod);
			return delegate(object obj, TProperty value)
			{
				propertySetter((TClass)obj, value);
			};
		}

		private static TDelegate CreateDelegate<TDelegate>(MethodInfo methodInfo) where TDelegate : Delegate
		{
			return (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), methodInfo);
		}

		private static Func<object, TProperty> CreateStructPropertyGetter<TClass, TProperty>(GetPropertyByRef<TClass, TProperty> get) where TClass : struct
		{
			return (object obj) => get(ref Unsafe.Unbox<TClass>(obj));
		}

		private static Action<object, TProperty> CreateStructPropertySetter<TClass, TProperty>(SetPropertyByRef<TClass, TProperty> set) where TClass : struct
		{
			return delegate(object obj, TProperty value)
			{
				set(ref Unsafe.Unbox<TClass>(obj), value);
			};
		}
	}
	[DebuggerDisplay("Path:{PropertyPath()} Current: ClassType.{Current.JsonClassInfo.ClassType}, {Current.JsonClassInfo.Type.Name}")]
	internal struct WriteStack
	{
		public WriteStackFrame Current;

		private List<WriteStackFrame> _previous;

		private int _index;

		public void Push()
		{
			if (_previous == null)
			{
				_previous = new List<WriteStackFrame>();
			}
			if (_index == _previous.Count)
			{
				_previous.Add(Current);
			}
			else
			{
				_previous[_index] = Current;
			}
			Current.Reset();
			_index++;
		}

		public void Push(JsonClassInfo nextClassInfo, object nextValue)
		{
			Push();
			Current.JsonClassInfo = nextClassInfo;
			Current.CurrentValue = nextValue;
			ClassType classType = nextClassInfo.ClassType;
			if (classType == ClassType.Enumerable || nextClassInfo.ClassType == ClassType.Dictionary)
			{
				Current.PopStackOnEndCollection = true;
				Current.JsonPropertyInfo = Current.JsonClassInfo.PolicyProperty;
			}
			else if (classType == ClassType.IDictionaryConstructible)
			{
				Current.PopStackOnEndCollection = true;
				Current.JsonPropertyInfo = Current.JsonClassInfo.PolicyProperty;
				Current.IsIDictionaryConstructible = true;
			}
			else
			{
				Current.PopStackOnEndObject = true;
			}
		}

		public void Pop()
		{
			Current = _previous[--_index];
		}

		public string PropertyPath()
		{
			StringBuilder stringBuilder = new StringBuilder("$");
			for (int i = 0; i < _index; i++)
			{
				AppendStackFrame(stringBuilder, _previous[i]);
			}
			AppendStackFrame(stringBuilder, in Current);
			return stringBuilder.ToString();
		}

		private void AppendStackFrame(StringBuilder sb, in WriteStackFrame frame)
		{
			string propertyName = frame.JsonPropertyInfo?.PropertyInfo?.Name;
			AppendPropertyName(sb, propertyName);
		}

		private void AppendPropertyName(StringBuilder sb, string propertyName)
		{
			if (propertyName != null)
			{
				if (propertyName.IndexOfAny(ReadStack.SpecialCharacters) != -1)
				{
					sb.Append("['");
					sb.Append(propertyName);
					sb.Append("']");
				}
				else
				{
					sb.Append('.');
					sb.Append(propertyName);
				}
			}
		}
	}
	internal struct WriteStackFrame
	{
		public object CurrentValue;

		public JsonClassInfo JsonClassInfo;

		public string KeyName;

		public IEnumerator CollectionEnumerator;

		public bool PopStackOnEndCollection;

		public bool IsIDictionaryConstructible;

		public bool IsIDictionaryConstructibleProperty;

		public bool PopStackOnEndObject;

		public bool StartObjectWritten;

		public bool MoveToNextProperty;

		public int PropertyEnumeratorIndex;

		public ExtensionDataWriteStatus ExtensionDataStatus;

		public JsonPropertyInfo JsonPropertyInfo;

		public void Initialize(Type type, JsonSerializerOptions options)
		{
			JsonClassInfo = options.GetOrAddClass(type);
			if (JsonClassInfo.ClassType == ClassType.Value || JsonClassInfo.ClassType == ClassType.Enumerable || JsonClassInfo.ClassType == ClassType.Dictionary)
			{
				JsonPropertyInfo = JsonClassInfo.PolicyProperty;
			}
			else if (JsonClassInfo.ClassType == ClassType.IDictionaryConstructible)
			{
				JsonPropertyInfo = JsonClassInfo.PolicyProperty;
				IsIDictionaryConstructible = true;
			}
		}

		public void WriteObjectOrArrayStart(ClassType classType, Utf8JsonWriter writer, JsonSerializerOptions options, bool writeNull = false)
		{
			JsonPropertyInfo jsonPropertyInfo = JsonPropertyInfo;
			if (jsonPropertyInfo != null && jsonPropertyInfo.EscapedName.HasValue)
			{
				WriteObjectOrArrayStart(classType, JsonPropertyInfo.EscapedName.Value, writer, writeNull);
			}
			else if (KeyName != null)
			{
				JsonEncodedText propertyName = JsonEncodedText.Encode(KeyName, options.Encoder);
				WriteObjectOrArrayStart(classType, propertyName, writer, writeNull);
			}
			else if (classType == ClassType.Object || classType == ClassType.Dictionary || classType == ClassType.IDictionaryConstructible)
			{
				writer.WriteStartObject();
				StartObjectWritten = true;
			}
			else
			{
				writer.WriteStartArray();
			}
		}

		private void WriteObjectOrArrayStart(ClassType classType, JsonEncodedText propertyName, Utf8JsonWriter writer, bool writeNull)
		{
			if (writeNull)
			{
				writer.WriteNull(propertyName);
			}
			else if (classType == ClassType.Object || classType == ClassType.Dictionary || classType == ClassType.IDictionaryConstructible)
			{
				writer.WriteStartObject(propertyName);
				StartObjectWritten = true;
			}
			else
			{
				writer.WriteStartArray(propertyName);
			}
		}

		public void Reset()
		{
			CurrentValue = null;
			CollectionEnumerator = null;
			ExtensionDataStatus = ExtensionDataWriteStatus.NotStarted;
			IsIDictionaryConstructible = false;
			JsonClassInfo = null;
			PropertyEnumeratorIndex = 0;
			PopStackOnEndCollection = false;
			PopStackOnEndObject = false;
			StartObjectWritten = false;
			EndProperty();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EndProperty()
		{
			IsIDictionaryConstructibleProperty = false;
			JsonPropertyInfo = null;
			KeyName = null;
			MoveToNextProperty = false;
		}

		public void EndDictionary()
		{
			CollectionEnumerator = null;
			PopStackOnEndCollection = false;
		}

		public void EndArray()
		{
			CollectionEnumerator = null;
			PopStackOnEndCollection = false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NextProperty()
		{
			EndProperty();
			int num = JsonClassInfo.PropertyCacheArray.Length;
			PropertyEnumeratorIndex++;
			if (PropertyEnumeratorIndex >= num)
			{
				if (PropertyEnumeratorIndex > num)
				{
					ExtensionDataStatus = ExtensionDataWriteStatus.Finished;
				}
				else if (JsonClassInfo.DataExtensionProperty != null)
				{
					ExtensionDataStatus = ExtensionDataWriteStatus.Writing;
				}
			}
		}
	}
	internal static class JsonWriterHelper
	{
		public const int LastAsciiCharacter = 127;

		private static readonly StandardFormat s_hexStandardFormat = new StandardFormat('X', 4);

		private static ReadOnlySpan<byte> AllowList => new byte[256]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 1, 0, 1, 1, 1, 0, 0,
			1, 1, 1, 0, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			0, 1, 0, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 0, 1, 1, 1, 0, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0
		};

		public static void WriteIndentation(Span<byte> buffer, int indent)
		{
			if (indent < 8)
			{
				int num = 0;
				while (num < indent)
				{
					buffer[num++] = 32;
					buffer[num++] = 32;
				}
			}
			else
			{
				buffer.Slice(0, indent).Fill(32);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateProperty(ReadOnlySpan<byte> propertyName)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException_PropertyNameTooLarge(propertyName.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateValue(ReadOnlySpan<byte> value)
		{
			if (value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException_ValueTooLarge(value.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateBytes(ReadOnlySpan<byte> bytes)
		{
			if (bytes.Length > 125000000)
			{
				ThrowHelper.ThrowArgumentException_ValueTooLarge(bytes.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateDouble(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				ThrowHelper.ThrowArgumentException_ValueNotSupported();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateSingle(float value)
		{
			if (float.IsNaN(value) || float.IsInfinity(value))
			{
				ThrowHelper.ThrowArgumentException_ValueNotSupported();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateProperty(ReadOnlySpan<char> propertyName)
		{
			if (propertyName.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException_PropertyNameTooLarge(propertyName.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateValue(ReadOnlySpan<char> value)
		{
			if (value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException_ValueTooLarge(value.Length);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			if (propertyName.Length > 166666666 || value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException(propertyName, value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value)
		{
			if (propertyName.Length > 166666666 || value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException(propertyName, value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
		{
			if (propertyName.Length > 166666666 || value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException(propertyName, value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
		{
			if (propertyName.Length > 166666666 || value.Length > 166666666)
			{
				ThrowHelper.ThrowArgumentException(propertyName, value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndBytes(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
		{
			if (propertyName.Length > 166666666 || bytes.Length > 125000000)
			{
				ThrowHelper.ThrowArgumentException(propertyName, bytes);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePropertyAndBytes(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> bytes)
		{
			if (propertyName.Length > 166666666 || bytes.Length > 125000000)
			{
				ThrowHelper.ThrowArgumentException(propertyName, bytes);
			}
		}

		internal static void ValidateNumber(ReadOnlySpan<byte> utf8FormattedNumber)
		{
			int i = 0;
			if (utf8FormattedNumber[i] == 45)
			{
				i++;
				if (utf8FormattedNumber.Length <= i)
				{
					throw new ArgumentException(SR.RequiredDigitNotFoundEndOfData, "utf8FormattedNumber");
				}
			}
			if (utf8FormattedNumber[i] == 48)
			{
				i++;
			}
			else
			{
				for (; i < utf8FormattedNumber.Length && JsonHelpers.IsDigit(utf8FormattedNumber[i]); i++)
				{
				}
			}
			if (i == utf8FormattedNumber.Length)
			{
				return;
			}
			byte b = utf8FormattedNumber[i];
			if (b == 46)
			{
				i++;
				if (utf8FormattedNumber.Length <= i)
				{
					throw new ArgumentException(SR.RequiredDigitNotFoundEndOfData, "utf8FormattedNumber");
				}
				for (; i < utf8FormattedNumber.Length && JsonHelpers.IsDigit(utf8FormattedNumber[i]); i++)
				{
				}
				if (i == utf8FormattedNumber.Length)
				{
					return;
				}
				b = utf8FormattedNumber[i];
			}
			if (b == 101 || b == 69)
			{
				i++;
				if (utf8FormattedNumber.Length <= i)
				{
					throw new ArgumentException(SR.RequiredDigitNotFoundEndOfData, "utf8FormattedNumber");
				}
				b = utf8FormattedNumber[i];
				if (b == 43 || b == 45)
				{
					i++;
				}
				if (utf8FormattedNumber.Length <= i)
				{
					throw new ArgumentException(SR.RequiredDigitNotFoundEndOfData, "utf8FormattedNumber");
				}
				for (; i < utf8FormattedNumber.Length && JsonHelpers.IsDigit(utf8FormattedNumber[i]); i++)
				{
				}
				if (i == utf8FormattedNumber.Length)
				{
					return;
				}
				throw new ArgumentException(SR.Format(SR.ExpectedEndOfDigitNotFound, ThrowHelper.GetPrintableString(utf8FormattedNumber[i])), "utf8FormattedNumber");
			}
			throw new ArgumentException(SR.Format(SR.ExpectedEndOfDigitNotFound, ThrowHelper.GetPrintableString(b)), "utf8FormattedNumber");
		}

		public static void TrimDateTimeOffset(Span<byte> buffer, out int bytesWritten)
		{
			uint num = (uint)(buffer[26] - 48);
			uint num2 = (uint)(buffer[25] - 48);
			uint num3 = (uint)(buffer[24] - 48);
			uint num4 = (uint)(buffer[23] - 48);
			uint num5 = (uint)(buffer[22] - 48);
			uint num6 = (uint)(buffer[21] - 48);
			uint num7 = (uint)(buffer[20] - 48);
			uint num8 = num7 * 1000000 + num6 * 100000 + num5 * 10000 + num4 * 1000 + num3 * 100 + num2 * 10 + num;
			int num9 = 19;
			if (num8 != 0)
			{
				int num10 = 7;
				while (true)
				{
					uint modulo;
					uint num11 = DivMod(num8, 10u, out modulo);
					if (modulo != 0)
					{
						break;
					}
					num8 = num11;
					num10--;
				}
				int num12 = 19 + num10;
				for (int num13 = num12; num13 > num9; num13--)
				{
					buffer[num13] = (byte)(num8 % 10 + 48);
					num8 /= 10;
				}
				num9 = num12 + 1;
			}
			bytesWritten = num9;
			if (buffer.Length > 27)
			{
				buffer[num9] = buffer[27];
				bytesWritten = num9 + 1;
				if (buffer.Length == 33)
				{
					int num14 = num9 + 5;
					byte b = buffer[31];
					byte b2 = buffer[29];
					byte b3 = buffer[28];
					buffer[num14] = buffer[32];
					buffer[num14 - 1] = b;
					buffer[num14 - 2] = 58;
					buffer[num14 - 3] = b2;
					buffer[num14 - 4] = b3;
					bytesWritten = num14 + 1;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint DivMod(uint numerator, uint denominator, out uint modulo)
		{
			uint num = numerator / denominator;
			modulo = numerator - num * denominator;
			return num;
		}

		private static bool NeedsEscaping(byte value)
		{
			return AllowList[value] == 0;
		}

		private static bool NeedsEscapingNoBoundsCheck(char value)
		{
			return AllowList[value] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool NeedsEscaping(char value)
		{
			if (value <= '\u007f')
			{
				return AllowList[value] == 0;
			}
			return true;
		}

		public static int NeedsEscaping(ReadOnlySpan<byte> value, JavaScriptEncoder encoder)
		{
			int num;
			if (encoder != null)
			{
				num = encoder.FindFirstCharacterToEncodeUtf8(value);
			}
			else
			{
				num = 0;
				while (true)
				{
					if (num < value.Length)
					{
						if (NeedsEscaping(value[num]))
						{
							break;
						}
						num++;
						continue;
					}
					num = -1;
					break;
				}
			}
			return num;
		}

		public unsafe static int NeedsEscaping(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
		{
			int num;
			if (encoder != null && !value.IsEmpty)
			{
				fixed (char* text = value)
				{
					num = encoder.FindFirstCharacterToEncode(text, value.Length);
				}
			}
			else
			{
				num = 0;
				while (true)
				{
					if (num < value.Length)
					{
						if (NeedsEscaping(value[num]))
						{
							break;
						}
						num++;
						continue;
					}
					num = -1;
					break;
				}
			}
			return num;
		}

		public static int GetMaxEscapedLength(int textLength, int firstIndexToEscape)
		{
			return firstIndexToEscape + 6 * (textLength - firstIndexToEscape);
		}

		private static void EscapeString(ReadOnlySpan<byte> value, Span<byte> destination, JavaScriptEncoder encoder, ref int written)
		{
			if (encoder.EncodeUtf8(value, destination, out var _, out var bytesWritten) != OperationStatus.Done)
			{
				ThrowHelper.ThrowArgumentException_InvalidUTF8(value.Slice(bytesWritten));
			}
			written += bytesWritten;
		}

		public static void EscapeString(ReadOnlySpan<byte> value, Span<byte> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int written)
		{
			value.Slice(0, indexOfFirstByteToEscape).CopyTo(destination);
			written = indexOfFirstByteToEscape;
			if (encoder != null)
			{
				destination = destination.Slice(indexOfFirstByteToEscape);
				value = value.Slice(indexOfFirstByteToEscape);
				EscapeString(value, destination, encoder, ref written);
				return;
			}
			while (indexOfFirstByteToEscape < value.Length)
			{
				byte b = value[indexOfFirstByteToEscape];
				if (IsAsciiValue(b))
				{
					if (NeedsEscaping(b))
					{
						EscapeNextBytes(b, destination, ref written);
						indexOfFirstByteToEscape++;
					}
					else
					{
						destination[written] = b;
						written++;
						indexOfFirstByteToEscape++;
					}
					continue;
				}
				destination = destination.Slice(written);
				value = value.Slice(indexOfFirstByteToEscape);
				EscapeString(value, destination, JavaScriptEncoder.Default, ref written);
				break;
			}
		}

		private static void EscapeNextBytes(byte value, Span<byte> destination, ref int written)
		{
			destination[written++] = 92;
			switch (value)
			{
			case 34:
				destination[written++] = 117;
				destination[written++] = 48;
				destination[written++] = 48;
				destination[written++] = 50;
				destination[written++] = 50;
				break;
			case 10:
				destination[written++] = 110;
				break;
			case 13:
				destination[written++] = 114;
				break;
			case 9:
				destination[written++] = 116;
				break;
			case 92:
				destination[written++] = 92;
				break;
			case 8:
				destination[written++] = 98;
				break;
			case 12:
				destination[written++] = 102;
				break;
			default:
			{
				destination[written++] = 117;
				int bytesWritten;
				bool flag = Utf8Formatter.TryFormat(value, destination.Slice(written), out bytesWritten, s_hexStandardFormat);
				written += bytesWritten;
				break;
			}
			}
		}

		private static bool IsAsciiValue(byte value)
		{
			return value <= 127;
		}

		private static bool IsAsciiValue(char value)
		{
			return value <= '\u007f';
		}

		private static void EscapeString(ReadOnlySpan<char> value, Span<char> destination, JavaScriptEncoder encoder, ref int written)
		{
			if (encoder.Encode(value, destination, out var _, out var charsWritten) != OperationStatus.Done)
			{
				ThrowHelper.ThrowArgumentException_InvalidUTF16(value[charsWritten]);
			}
			written += charsWritten;
		}

		public static void EscapeString(ReadOnlySpan<char> value, Span<char> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int written)
		{
			value.Slice(0, indexOfFirstByteToEscape).CopyTo(destination);
			written = indexOfFirstByteToEscape;
			if (encoder != null)
			{
				destination = destination.Slice(indexOfFirstByteToEscape);
				value = value.Slice(indexOfFirstByteToEscape);
				EscapeString(value, destination, encoder, ref written);
				return;
			}
			while (indexOfFirstByteToEscape < value.Length)
			{
				char c = value[indexOfFirstByteToEscape];
				if (IsAsciiValue(c))
				{
					if (NeedsEscapingNoBoundsCheck(c))
					{
						EscapeNextChars(c, destination, ref written);
						indexOfFirstByteToEscape++;
					}
					else
					{
						destination[written] = c;
						written++;
						indexOfFirstByteToEscape++;
					}
					continue;
				}
				destination = destination.Slice(written);
				value = value.Slice(indexOfFirstByteToEscape);
				EscapeString(value, destination, JavaScriptEncoder.Default, ref written);
				break;
			}
		}

		private static void EscapeNextChars(char value, Span<char> destination, ref int written)
		{
			destination[written++] = '\\';
			switch ((byte)value)
			{
			case 34:
				destination[written++] = 'u';
				destination[written++] = '0';
				destination[written++] = '0';
				destination[written++] = '2';
				destination[written++] = '2';
				break;
			case 10:
				destination[written++] = 'n';
				break;
			case 13:
				destination[written++] = 'r';
				break;
			case 9:
				destination[written++] = 't';
				break;
			case 92:
				destination[written++] = '\\';
				break;
			case 8:
				destination[written++] = 'b';
				break;
			case 12:
				destination[written++] = 'f';
				break;
			default:
				destination[written++] = 'u';
				written = WriteHex(value, destination, written);
				break;
			}
		}

		private static int WriteHex(int value, Span<char> destination, int written)
		{
			destination[written++] = (char)Int32LsbToHexDigit(value >> 12);
			destination[written++] = (char)Int32LsbToHexDigit((int)((long)(value >> 8) & 0xFL));
			destination[written++] = (char)Int32LsbToHexDigit((int)((long)(value >> 4) & 0xFL));
			destination[written++] = (char)Int32LsbToHexDigit((int)((long)value & 0xFL));
			return written;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static byte Int32LsbToHexDigit(int value)
		{
			return (byte)((value < 10) ? (48 + value) : (65 + (value - 10)));
		}

		public unsafe static OperationStatus ToUtf8(ReadOnlySpan<byte> utf16Source, Span<byte> utf8Destination, out int bytesConsumed, out int bytesWritten)
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(utf16Source))
			{
				fixed (byte* reference2 = &MemoryMarshal.GetReference(utf8Destination))
				{
					char* ptr = (char*)reference;
					byte* ptr2 = reference2;
					char* ptr3 = (char*)(reference + utf16Source.Length);
					byte* ptr4 = ptr2 + utf8Destination.Length;
					while (true)
					{
						IL_0205:
						if (ptr3 - ptr > 13)
						{
							int num = Math.Min(PtrDiff(ptr3, ptr), PtrDiff(ptr4, ptr2));
							char* ptr5 = ptr + num - 5;
							if (ptr < ptr5)
							{
								while (true)
								{
									int num2 = *ptr;
									ptr++;
									if (num2 > 127)
									{
										goto IL_012c;
									}
									*ptr2 = (byte)num2;
									ptr2++;
									if (((int)ptr & 2) != 0)
									{
										num2 = *ptr;
										ptr++;
										if (num2 > 127)
										{
											goto IL_012c;
										}
										*ptr2 = (byte)num2;
										ptr2++;
									}
									while (ptr < ptr5)
									{
										num2 = *(int*)ptr;
										int num3 = *(int*)(ptr + 2);
										if (((num2 | num3) & -8323200) == 0)
										{
											*ptr2 = (byte)num2;
											ptr2[1] = (byte)(num2 >> 16);
											ptr += 4;
											ptr2[2] = (byte)num3;
											ptr2[3] = (byte)(num3 >> 16);
											ptr2 += 4;
											continue;
										}
										goto IL_010a;
									}
									goto IL_01fc;
									IL_010a:
									num2 = (ushort)num2;
									ptr++;
									if (num2 > 127)
									{
										goto IL_012c;
									}
									*ptr2 = (byte)num2;
									ptr2++;
									goto IL_01fc;
									IL_01fc:
									if (ptr < ptr5)
									{
										continue;
									}
									goto IL_0205;
									IL_012c:
									int num4;
									if (num2 <= 2047)
									{
										num4 = -64 | (num2 >> 6);
									}
									else
									{
										if (!JsonHelpers.IsInRangeInclusive(num2, 55296, 57343))
										{
											num4 = -32 | (num2 >> 12);
										}
										else
										{
											if (num2 > 56319)
											{
												break;
											}
											num4 = *ptr;
											if (!JsonHelpers.IsInRangeInclusive(num4, 56320, 57343))
											{
												break;
											}
											ptr++;
											num2 = num4 + (num2 << 10) + -56613888;
											*ptr2 = (byte)(-16 | (num2 >> 18));
											ptr2++;
											num4 = -128 | ((num2 >> 12) & 0x3F);
										}
										*ptr2 = (byte)num4;
										ptr5--;
										ptr2++;
										num4 = -128 | ((num2 >> 6) & 0x3F);
									}
									*ptr2 = (byte)num4;
									ptr5--;
									ptr2[1] = (byte)(-128 | (num2 & 0x3F));
									ptr2 += 2;
									goto IL_01fc;
								}
								break;
							}
						}
						while (true)
						{
							int num5;
							int num6;
							if (ptr < ptr3)
							{
								num5 = *ptr;
								ptr++;
								if (num5 <= 127)
								{
									if (ptr4 - ptr2 > 0)
									{
										*ptr2 = (byte)num5;
										ptr2++;
										continue;
									}
								}
								else if (num5 <= 2047)
								{
									if (ptr4 - ptr2 > 1)
									{
										num6 = -64 | (num5 >> 6);
										goto IL_032b;
									}
								}
								else if (!JsonHelpers.IsInRangeInclusive(num5, 55296, 57343))
								{
									if (ptr4 - ptr2 > 2)
									{
										num6 = -32 | (num5 >> 12);
										goto IL_0313;
									}
								}
								else if (ptr4 - ptr2 > 3)
								{
									if (num5 > 56319)
									{
										break;
									}
									if (ptr < ptr3)
									{
										num6 = *ptr;
										if (!JsonHelpers.IsInRangeInclusive(num6, 56320, 57343))
										{
											break;
										}
										ptr++;
										num5 = num6 + (num5 << 10) + -56613888;
										*ptr2 = (byte)(-16 | (num5 >> 18));
										ptr2++;
										num6 = -128 | ((num5 >> 12) & 0x3F);
										goto IL_0313;
									}
									bytesConsumed = (int)((byte*)(ptr - 1) - reference);
									bytesWritten = (int)(ptr2 - reference2);
									return OperationStatus.NeedMoreData;
								}
								bytesConsumed = (int)((byte*)(ptr - 1) - reference);
								bytesWritten = (int)(ptr2 - reference2);
								return OperationStatus.DestinationTooSmall;
							}
							bytesConsumed = (int)((byte*)ptr - reference);
							bytesWritten = (int)(ptr2 - reference2);
							return OperationStatus.Done;
							IL_0313:
							*ptr2 = (byte)num6;
							ptr2++;
							num6 = -128 | ((num5 >> 6) & 0x3F);
							goto IL_032b;
							IL_032b:
							*ptr2 = (byte)num6;
							ptr2[1] = (byte)(-128 | (num5 & 0x3F));
							ptr2 += 2;
						}
						break;
					}
					bytesConsumed = (int)((byte*)(ptr - 1) - reference);
					bytesWritten = (int)(ptr2 - reference2);
					return OperationStatus.InvalidData;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static int PtrDiff(char* a, char* b)
		{
			return (int)((uint)((byte*)a - (byte*)b) >> 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static int PtrDiff(byte* a, byte* b)
		{
			return (int)(a - b);
		}
	}
	public struct JsonWriterOptions
	{
		private int _optionsMask;

		private const int IndentBit = 1;

		private const int SkipValidationBit = 2;

		public JavaScriptEncoder Encoder { get; set; }

		public bool Indented
		{
			get
			{
				return (_optionsMask & 1) != 0;
			}
			set
			{
				if (value)
				{
					_optionsMask |= 1;
				}
				else
				{
					_optionsMask &= -2;
				}
			}
		}

		public bool SkipValidation
		{
			get
			{
				return (_optionsMask & 2) != 0;
			}
			set
			{
				if (value)
				{
					_optionsMask |= 2;
				}
				else
				{
					_optionsMask &= -3;
				}
			}
		}

		internal bool IndentedOrNotSkipValidation => _optionsMask != 2;
	}
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
	{
		private static readonly int s_newLineLength = Environment.NewLine.Length;

		private const int DefaultGrowthSize = 4096;

		private const int InitialGrowthSize = 256;

		private IBufferWriter<byte> _output;

		private Stream _stream;

		private ArrayBufferWriter<byte> _arrayBufferWriter;

		private Memory<byte> _memory;

		private bool _inObject;

		private JsonTokenType _tokenType;

		private BitStack _bitStack;

		private int _currentDepth;

		private JsonWriterOptions _options;

		private static char[] s_singleLineCommentDelimiter = new char[2] { '*', '/' };

		private static readonly StandardFormat s_dateTimeStandardFormat = new StandardFormat('O', 255);

		public int BytesPending { get; private set; }

		public long BytesCommitted { get; private set; }

		public JsonWriterOptions Options => _options;

		private int Indentation => CurrentDepth * 2;

		public int CurrentDepth => _currentDepth & 0x7FFFFFFF;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string DebuggerDisplay => $"BytesCommitted = {BytesCommitted} BytesPending = {BytesPending} CurrentDepth = {CurrentDepth}";

		private static ReadOnlySpan<byte> SingleLineCommentDelimiterUtf8 => "*/"u8;

		public Utf8JsonWriter(IBufferWriter<byte> bufferWriter, JsonWriterOptions options = default(JsonWriterOptions))
		{
			_output = bufferWriter ?? throw new ArgumentNullException("bufferWriter");
			_stream = null;
			_arrayBufferWriter = null;
			BytesPending = 0;
			BytesCommitted = 0L;
			_memory = default(Memory<byte>);
			_inObject = false;
			_tokenType = JsonTokenType.None;
			_currentDepth = 0;
			_options = options;
			_bitStack = default(BitStack);
		}

		public Utf8JsonWriter(Stream utf8Json, JsonWriterOptions options = default(JsonWriterOptions))
		{
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			if (!utf8Json.CanWrite)
			{
				throw new ArgumentException(SR.StreamNotWritable);
			}
			_stream = utf8Json;
			_arrayBufferWriter = new ArrayBufferWriter<byte>();
			_output = null;
			BytesPending = 0;
			BytesCommitted = 0L;
			_memory = default(Memory<byte>);
			_inObject = false;
			_tokenType = JsonTokenType.None;
			_currentDepth = 0;
			_options = options;
			_bitStack = default(BitStack);
		}

		public void Reset()
		{
			CheckNotDisposed();
			_arrayBufferWriter?.Clear();
			ResetHelper();
		}

		public void Reset(Stream utf8Json)
		{
			CheckNotDisposed();
			if (utf8Json == null)
			{
				throw new ArgumentNullException("utf8Json");
			}
			if (!utf8Json.CanWrite)
			{
				throw new ArgumentException(SR.StreamNotWritable);
			}
			_stream = utf8Json;
			if (_arrayBufferWriter == null)
			{
				_arrayBufferWriter = new ArrayBufferWriter<byte>();
			}
			else
			{
				_arrayBufferWriter.Clear();
			}
			_output = null;
			ResetHelper();
		}

		public void Reset(IBufferWriter<byte> bufferWriter)
		{
			CheckNotDisposed();
			_output = bufferWriter ?? throw new ArgumentNullException("bufferWriter");
			_stream = null;
			_arrayBufferWriter = null;
			ResetHelper();
		}

		private void ResetHelper()
		{
			BytesPending = 0;
			BytesCommitted = 0L;
			_memory = default(Memory<byte>);
			_inObject = false;
			_tokenType = JsonTokenType.None;
			_currentDepth = 0;
			_bitStack = default(BitStack);
		}

		private void CheckNotDisposed()
		{
			if (_stream == null && _output == null)
			{
				throw new ObjectDisposedException("Utf8JsonWriter");
			}
		}

		public void Flush()
		{
			CheckNotDisposed();
			_memory = default(Memory<byte>);
			if (_stream != null)
			{
				if (BytesPending != 0)
				{
					_arrayBufferWriter.Advance(BytesPending);
					BytesPending = 0;
					ArraySegment<byte> segment;
					bool flag = MemoryMarshal.TryGetArray(_arrayBufferWriter.WrittenMemory, out segment);
					_stream.Write(segment.Array, segment.Offset, segment.Count);
					BytesCommitted += _arrayBufferWriter.WrittenCount;
					_arrayBufferWriter.Clear();
				}
				_stream.Flush();
			}
			else if (BytesPending != 0)
			{
				_output.Advance(BytesPending);
				BytesCommitted += BytesPending;
				BytesPending = 0;
			}
		}

		public void Dispose()
		{
			if (_stream != null || _output != null)
			{
				Flush();
				ResetHelper();
				_stream = null;
				_arrayBufferWriter = null;
				_output = null;
			}
		}

		public async ValueTask DisposeAsync()
		{
			if (_stream != null || _output != null)
			{
				await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
				ResetHelper();
				_stream = null;
				_arrayBufferWriter = null;
				_output = null;
			}
		}

		public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			CheckNotDisposed();
			_memory = default(Memory<byte>);
			if (_stream != null)
			{
				if (BytesPending != 0)
				{
					_arrayBufferWriter.Advance(BytesPending);
					BytesPending = 0;
					MemoryMarshal.TryGetArray(_arrayBufferWriter.WrittenMemory, out var segment);
					await _stream.WriteAsync(segment.Array, segment.Offset, segment.Count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					BytesCommitted += _arrayBufferWriter.WrittenCount;
					_arrayBufferWriter.Clear();
				}
				await _stream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else if (BytesPending != 0)
			{
				_output.Advance(BytesPending);
				BytesCommitted += BytesPending;
				BytesPending = 0;
			}
		}

		public void WriteStartArray()
		{
			WriteStart(91);
			_tokenType = JsonTokenType.StartArray;
		}

		public void WriteStartObject()
		{
			WriteStart(123);
			_tokenType = JsonTokenType.StartObject;
		}

		private void WriteStart(byte token)
		{
			if (CurrentDepth >= 1000)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.DepthTooLarge, _currentDepth, 0, JsonTokenType.None);
			}
			if (_options.IndentedOrNotSkipValidation)
			{
				WriteStartSlow(token);
			}
			else
			{
				WriteStartMinimized(token);
			}
			_currentDepth &= 2147483647;
			_currentDepth++;
		}

		private void WriteStartMinimized(byte token)
		{
			if (_memory.Length - BytesPending < 2)
			{
				Grow(2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = token;
		}

		private void WriteStartSlow(byte token)
		{
			if (_options.Indented)
			{
				if (!_options.SkipValidation)
				{
					ValidateStart();
					UpdateBitStackOnStart(token);
				}
				WriteStartIndented(token);
			}
			else
			{
				ValidateStart();
				UpdateBitStackOnStart(token);
				WriteStartMinimized(token);
			}
		}

		private void ValidateStart()
		{
			if (_inObject)
			{
				if (_tokenType != JsonTokenType.PropertyName)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayWithoutProperty, 0, 0, _tokenType);
				}
			}
			else if (CurrentDepth == 0 && _tokenType != JsonTokenType.None)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose, 0, 0, _tokenType);
			}
		}

		private void WriteStartIndented(byte token)
		{
			int indentation = Indentation;
			int num = indentation + 1;
			int num2 = num + 3;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = token;
		}

		public void WriteStartArray(JsonEncodedText propertyName)
		{
			WriteStartHelper(propertyName.EncodedUtf8Bytes, 91);
			_tokenType = JsonTokenType.StartArray;
		}

		public void WriteStartObject(JsonEncodedText propertyName)
		{
			WriteStartHelper(propertyName.EncodedUtf8Bytes, 123);
			_tokenType = JsonTokenType.StartObject;
		}

		private void WriteStartHelper(ReadOnlySpan<byte> utf8PropertyName, byte token)
		{
			ValidateDepth();
			WriteStartByOptions(utf8PropertyName, token);
			_currentDepth &= 2147483647;
			_currentDepth++;
		}

		public void WriteStartArray(ReadOnlySpan<byte> utf8PropertyName)
		{
			ValidatePropertyNameAndDepth(utf8PropertyName);
			WriteStartEscape(utf8PropertyName, 91);
			_currentDepth &= 2147483647;
			_currentDepth++;
			_tokenType = JsonTokenType.StartArray;
		}

		public void WriteStartObject(ReadOnlySpan<byte> utf8PropertyName)
		{
			ValidatePropertyNameAndDepth(utf8PropertyName);
			WriteStartEscape(utf8PropertyName, 123);
			_currentDepth &= 2147483647;
			_currentDepth++;
			_tokenType = JsonTokenType.StartObject;
		}

		private void WriteStartEscape(ReadOnlySpan<byte> utf8PropertyName, byte token)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStartEscapeProperty(utf8PropertyName, token, num);
			}
			else
			{
				WriteStartByOptions(utf8PropertyName, token);
			}
		}

		private void WriteStartByOptions(ReadOnlySpan<byte> utf8PropertyName, byte token)
		{
			ValidateWritingProperty(token);
			if (_options.Indented)
			{
				WritePropertyNameIndented(utf8PropertyName, token);
			}
			else
			{
				WritePropertyNameMinimized(utf8PropertyName, token);
			}
		}

		private void WriteStartEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, byte token, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStartByOptions(destination.Slice(0, written), token);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		public void WriteStartArray(string propertyName)
		{
			WriteStartArray((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan());
		}

		public void WriteStartObject(string propertyName)
		{
			WriteStartObject((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan());
		}

		public void WriteStartArray(ReadOnlySpan<char> propertyName)
		{
			ValidatePropertyNameAndDepth(propertyName);
			WriteStartEscape(propertyName, 91);
			_currentDepth &= 2147483647;
			_currentDepth++;
			_tokenType = JsonTokenType.StartArray;
		}

		public void WriteStartObject(ReadOnlySpan<char> propertyName)
		{
			ValidatePropertyNameAndDepth(propertyName);
			WriteStartEscape(propertyName, 123);
			_currentDepth &= 2147483647;
			_currentDepth++;
			_tokenType = JsonTokenType.StartObject;
		}

		private void WriteStartEscape(ReadOnlySpan<char> propertyName, byte token)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStartEscapeProperty(propertyName, token, num);
			}
			else
			{
				WriteStartByOptions(propertyName, token);
			}
		}

		private void WriteStartByOptions(ReadOnlySpan<char> propertyName, byte token)
		{
			ValidateWritingProperty(token);
			if (_options.Indented)
			{
				WritePropertyNameIndented(propertyName, token);
			}
			else
			{
				WritePropertyNameMinimized(propertyName, token);
			}
		}

		private void WriteStartEscapeProperty(ReadOnlySpan<char> propertyName, byte token, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStartByOptions(destination.Slice(0, written), token);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		public void WriteEndArray()
		{
			WriteEnd(93);
			_tokenType = JsonTokenType.EndArray;
		}

		public void WriteEndObject()
		{
			WriteEnd(125);
			_tokenType = JsonTokenType.EndObject;
		}

		private void WriteEnd(byte token)
		{
			if (_options.IndentedOrNotSkipValidation)
			{
				WriteEndSlow(token);
			}
			else
			{
				WriteEndMinimized(token);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			if (CurrentDepth != 0)
			{
				_currentDepth--;
			}
		}

		private void WriteEndMinimized(byte token)
		{
			if (_memory.Length - BytesPending < 1)
			{
				Grow(1);
			}
			_memory.Span[BytesPending++] = token;
		}

		private void WriteEndSlow(byte token)
		{
			if (_options.Indented)
			{
				if (!_options.SkipValidation)
				{
					ValidateEnd(token);
				}
				WriteEndIndented(token);
			}
			else
			{
				ValidateEnd(token);
				WriteEndMinimized(token);
			}
		}

		private void ValidateEnd(byte token)
		{
			if (_bitStack.CurrentDepth <= 0 || _tokenType == JsonTokenType.PropertyName)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, token, _tokenType);
			}
			if (token == 93)
			{
				if (_inObject)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, token, _tokenType);
				}
			}
			else if (!_inObject)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, token, _tokenType);
			}
			_inObject = _bitStack.Pop();
		}

		private void WriteEndIndented(byte token)
		{
			if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
			{
				WriteEndMinimized(token);
				return;
			}
			int num = Indentation;
			if (num != 0)
			{
				num -= 2;
			}
			int num2 = num + 3;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			WriteNewLine(span);
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), num);
			BytesPending += num;
			span[BytesPending++] = token;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void WriteNewLine(Span<byte> output)
		{
			if (s_newLineLength == 2)
			{
				output[BytesPending++] = 13;
			}
			output[BytesPending++] = 10;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateBitStackOnStart(byte token)
		{
			if (token == 91)
			{
				_bitStack.PushFalse();
				_inObject = false;
			}
			else
			{
				_bitStack.PushTrue();
				_inObject = true;
			}
		}

		private void Grow(int requiredSize)
		{
			if (_memory.Length == 0)
			{
				FirstCallToGetMemory(requiredSize);
				return;
			}
			int num = Math.Max(4096, requiredSize);
			if (_stream != null)
			{
				_memory = _arrayBufferWriter.GetMemory(checked(BytesPending + num));
				return;
			}
			_output.Advance(BytesPending);
			BytesCommitted += BytesPending;
			BytesPending = 0;
			_memory = _output.GetMemory(num);
			if (_memory.Length < num)
			{
				ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
			}
		}

		private void FirstCallToGetMemory(int requiredSize)
		{
			int num = Math.Max(256, requiredSize);
			if (_stream != null)
			{
				_memory = _arrayBufferWriter.GetMemory(num);
				return;
			}
			_memory = _output.GetMemory(num);
			if (_memory.Length < num)
			{
				ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
			}
		}

		private void SetFlagToAddListSeparatorBeforeNextItem()
		{
			_currentDepth |= -2147483648;
		}

		public void WriteBase64String(JsonEncodedText propertyName, ReadOnlySpan<byte> bytes)
		{
			WriteBase64StringHelper(propertyName.EncodedUtf8Bytes, bytes);
		}

		private void WriteBase64StringHelper(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
		{
			JsonWriterHelper.ValidateBytes(bytes);
			WriteBase64ByOptions(utf8PropertyName, bytes);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteBase64String(string propertyName, ReadOnlySpan<byte> bytes)
		{
			WriteBase64String((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), bytes);
		}

		public void WriteBase64String(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
		{
			JsonWriterHelper.ValidatePropertyAndBytes(propertyName, bytes);
			WriteBase64Escape(propertyName, bytes);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteBase64String(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
		{
			JsonWriterHelper.ValidatePropertyAndBytes(utf8PropertyName, bytes);
			WriteBase64Escape(utf8PropertyName, bytes);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteBase64Escape(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteBase64EscapeProperty(propertyName, bytes, num);
			}
			else
			{
				WriteBase64ByOptions(propertyName, bytes);
			}
		}

		private void WriteBase64Escape(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteBase64EscapeProperty(utf8PropertyName, bytes, num);
			}
			else
			{
				WriteBase64ByOptions(utf8PropertyName, bytes);
			}
		}

		private void WriteBase64EscapeProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteBase64ByOptions(destination.Slice(0, written), bytes);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteBase64EscapeProperty(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteBase64ByOptions(destination.Slice(0, written), bytes);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteBase64ByOptions(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteBase64Indented(propertyName, bytes);
			}
			else
			{
				WriteBase64Minimized(propertyName, bytes);
			}
		}

		private void WriteBase64ByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteBase64Indented(utf8PropertyName, bytes);
			}
			else
			{
				WriteBase64Minimized(utf8PropertyName, bytes);
			}
		}

		private void WriteBase64Minimized(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> bytes)
		{
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = escapedPropertyName.Length * 3 + maxEncodedToUtf8Length + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		private void WriteBase64Minimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> bytes)
		{
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = escapedPropertyName.Length + maxEncodedToUtf8Length + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		private void WriteBase64Indented(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> bytes)
		{
			int indentation = Indentation;
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = indentation + escapedPropertyName.Length * 3 + maxEncodedToUtf8Length + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		private void WriteBase64Indented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> bytes)
		{
			int indentation = Indentation;
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = indentation + escapedPropertyName.Length + maxEncodedToUtf8Length + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		public void WriteString(JsonEncodedText propertyName, DateTime value)
		{
			WriteStringHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteStringHelper(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
		{
			WriteStringByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, DateTime value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteString(ReadOnlySpan<char> propertyName, DateTime value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteStringEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteStringEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringEscape(ReadOnlySpan<char> propertyName, DateTime value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteStringByOptions(propertyName, value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, value);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<char> propertyName, DateTime value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, DateTime value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> propertyName, DateTime value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(propertyName, value);
			}
			else
			{
				WriteStringMinimized(propertyName, value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(utf8PropertyName, value);
			}
			else
			{
				WriteStringMinimized(utf8PropertyName, value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedPropertyName, DateTime value)
		{
			int num = escapedPropertyName.Length * 3 + 33 + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, DateTime value)
		{
			int num = escapedPropertyName.Length + 33 + 5;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedPropertyName, DateTime value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 33 + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, DateTime value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 33 + 6;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		public void WriteString(JsonEncodedText propertyName, DateTimeOffset value)
		{
			WriteStringHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteStringHelper(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
		{
			WriteStringByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, DateTimeOffset value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteString(ReadOnlySpan<char> propertyName, DateTimeOffset value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteStringEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteStringEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringEscape(ReadOnlySpan<char> propertyName, DateTimeOffset value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteStringByOptions(propertyName, value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, value);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<char> propertyName, DateTimeOffset value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> propertyName, DateTimeOffset value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(propertyName, value);
			}
			else
			{
				WriteStringMinimized(propertyName, value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(utf8PropertyName, value);
			}
			else
			{
				WriteStringMinimized(utf8PropertyName, value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedPropertyName, DateTimeOffset value)
		{
			int num = escapedPropertyName.Length * 3 + 33 + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, DateTimeOffset value)
		{
			int num = escapedPropertyName.Length + 33 + 5;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedPropertyName, DateTimeOffset value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 33 + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, DateTimeOffset value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 33 + 6;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		public void WriteNumber(JsonEncodedText propertyName, decimal value)
		{
			WriteNumberHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteNumberHelper(ReadOnlySpan<byte> utf8PropertyName, decimal value)
		{
			WriteNumberByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(string propertyName, decimal value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteNumber(ReadOnlySpan<char> propertyName, decimal value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteNumberEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, decimal value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteNumberEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, decimal value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, decimal value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, decimal value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, decimal value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, decimal value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(propertyName, value);
			}
			else
			{
				WriteNumberMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, decimal value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(utf8PropertyName, value);
			}
			else
			{
				WriteNumberMinimized(utf8PropertyName, value);
			}
		}

		private void WriteNumberMinimized(ReadOnlySpan<char> escapedPropertyName, decimal value)
		{
			int num = escapedPropertyName.Length * 3 + 31 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, decimal value)
		{
			int num = escapedPropertyName.Length + 31 + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<char> escapedPropertyName, decimal value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 31 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, decimal value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 31 + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteNumber(JsonEncodedText propertyName, double value)
		{
			WriteNumberHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteNumberHelper(ReadOnlySpan<byte> utf8PropertyName, double value)
		{
			JsonWriterHelper.ValidateDouble(value);
			WriteNumberByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(string propertyName, double value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteNumber(ReadOnlySpan<char> propertyName, double value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			JsonWriterHelper.ValidateDouble(value);
			WriteNumberEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, double value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			JsonWriterHelper.ValidateDouble(value);
			WriteNumberEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, double value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, double value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, double value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, double value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, double value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(propertyName, value);
			}
			else
			{
				WriteNumberMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, double value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(utf8PropertyName, value);
			}
			else
			{
				WriteNumberMinimized(utf8PropertyName, value);
			}
		}

		private void WriteNumberMinimized(ReadOnlySpan<char> escapedPropertyName, double value)
		{
			int num = escapedPropertyName.Length * 3 + 128 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, double value)
		{
			int num = escapedPropertyName.Length + 128 + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<char> escapedPropertyName, double value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 128 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, double value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 128 + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteNumber(JsonEncodedText propertyName, float value)
		{
			WriteNumberHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteNumberHelper(ReadOnlySpan<byte> utf8PropertyName, float value)
		{
			JsonWriterHelper.ValidateSingle(value);
			WriteNumberByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(string propertyName, float value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteNumber(ReadOnlySpan<char> propertyName, float value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			JsonWriterHelper.ValidateSingle(value);
			WriteNumberEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, float value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			JsonWriterHelper.ValidateSingle(value);
			WriteNumberEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, float value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, float value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, float value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, float value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, float value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(propertyName, value);
			}
			else
			{
				WriteNumberMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, float value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(utf8PropertyName, value);
			}
			else
			{
				WriteNumberMinimized(utf8PropertyName, value);
			}
		}

		private void WriteNumberMinimized(ReadOnlySpan<char> escapedPropertyName, float value)
		{
			int num = escapedPropertyName.Length * 3 + 128 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, float value)
		{
			int num = escapedPropertyName.Length + 128 + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<char> escapedPropertyName, float value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 128 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, float value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 128 + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		internal void WriteNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8FormattedNumber)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			JsonWriterHelper.ValidateValue(utf8FormattedNumber);
			JsonWriterHelper.ValidateNumber(utf8FormattedNumber);
			WriteNumberEscape(propertyName, utf8FormattedNumber);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		internal void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8FormattedNumber)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			JsonWriterHelper.ValidateValue(utf8FormattedNumber);
			JsonWriterHelper.ValidateNumber(utf8FormattedNumber);
			WriteNumberEscape(utf8PropertyName, utf8FormattedNumber);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		internal void WriteNumber(JsonEncodedText propertyName, ReadOnlySpan<byte> utf8FormattedNumber)
		{
			JsonWriterHelper.ValidateValue(utf8FormattedNumber);
			JsonWriterHelper.ValidateNumber(utf8FormattedNumber);
			WriteNumberByOptions(propertyName.EncodedUtf8Bytes, utf8FormattedNumber);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteLiteralIndented(propertyName, value);
			}
			else
			{
				WriteLiteralMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteLiteralIndented(utf8PropertyName, value);
			}
			else
			{
				WriteLiteralMinimized(utf8PropertyName, value);
			}
		}

		public void WriteString(JsonEncodedText propertyName, Guid value)
		{
			WriteStringHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteStringHelper(ReadOnlySpan<byte> utf8PropertyName, Guid value)
		{
			WriteStringByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, Guid value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteString(ReadOnlySpan<char> propertyName, Guid value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteStringEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, Guid value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteStringEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringEscape(ReadOnlySpan<char> propertyName, Guid value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteStringByOptions(propertyName, value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8PropertyName, Guid value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, value);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<char> propertyName, Guid value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, Guid value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> propertyName, Guid value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(propertyName, value);
			}
			else
			{
				WriteStringMinimized(propertyName, value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, Guid value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(utf8PropertyName, value);
			}
			else
			{
				WriteStringMinimized(utf8PropertyName, value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedPropertyName, Guid value)
		{
			int num = escapedPropertyName.Length * 3 + 36 + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, Guid value)
		{
			int num = escapedPropertyName.Length + 36 + 5;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedPropertyName, Guid value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 36 + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, Guid value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 36 + 6;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidatePropertyNameAndDepth(ReadOnlySpan<char> propertyName)
		{
			if (propertyName.Length > 166666666 || CurrentDepth >= 1000)
			{
				ThrowHelper.ThrowInvalidOperationOrArgumentException(propertyName, _currentDepth);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidatePropertyNameAndDepth(ReadOnlySpan<byte> utf8PropertyName)
		{
			if (utf8PropertyName.Length > 166666666 || CurrentDepth >= 1000)
			{
				ThrowHelper.ThrowInvalidOperationOrArgumentException(utf8PropertyName, _currentDepth);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateDepth()
		{
			if (CurrentDepth >= 1000)
			{
				ThrowHelper.ThrowInvalidOperationException(_currentDepth);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateWritingProperty()
		{
			if (!_options.SkipValidation && (!_inObject || _tokenType == JsonTokenType.PropertyName))
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWritePropertyWithinArray, 0, 0, _tokenType);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateWritingProperty(byte token)
		{
			if (!_options.SkipValidation)
			{
				if (!_inObject || _tokenType == JsonTokenType.PropertyName)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWritePropertyWithinArray, 0, 0, _tokenType);
				}
				UpdateBitStackOnStart(token);
			}
		}

		private void WritePropertyNameMinimized(ReadOnlySpan<byte> escapedPropertyName, byte token)
		{
			int num = escapedPropertyName.Length + 4;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = token;
		}

		private void WritePropertyNameIndented(ReadOnlySpan<byte> escapedPropertyName, byte token)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 5;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = token;
		}

		private void WritePropertyNameMinimized(ReadOnlySpan<char> escapedPropertyName, byte token)
		{
			int num = escapedPropertyName.Length * 3 + 5;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = token;
		}

		private void WritePropertyNameIndented(ReadOnlySpan<char> escapedPropertyName, byte token)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 6 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = token;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TranscodeAndWrite(ReadOnlySpan<char> escapedPropertyName, Span<byte> output)
		{
			ReadOnlySpan<byte> utf16Source = MemoryMarshal.AsBytes(escapedPropertyName);
			int bytesConsumed;
			int bytesWritten;
			OperationStatus operationStatus = JsonWriterHelper.ToUtf8(utf16Source, output.Slice(BytesPending), out bytesConsumed, out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteNull(JsonEncodedText propertyName)
		{
			WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.NullValue);
			_tokenType = JsonTokenType.Null;
		}

		private void WriteLiteralHelper(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
		{
			WriteLiteralByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
		}

		public void WriteNull(string propertyName)
		{
			WriteNull((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan());
		}

		public void WriteNull(ReadOnlySpan<char> propertyName)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			ReadOnlySpan<byte> nullValue = JsonConstants.NullValue;
			WriteLiteralEscape(propertyName, nullValue);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Null;
		}

		public void WriteNull(ReadOnlySpan<byte> utf8PropertyName)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			ReadOnlySpan<byte> nullValue = JsonConstants.NullValue;
			WriteLiteralEscape(utf8PropertyName, nullValue);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Null;
		}

		public void WriteBoolean(JsonEncodedText propertyName, bool value)
		{
			if (value)
			{
				WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.TrueValue);
				_tokenType = JsonTokenType.True;
			}
			else
			{
				WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.FalseValue);
				_tokenType = JsonTokenType.False;
			}
		}

		public void WriteBoolean(string propertyName, bool value)
		{
			WriteBoolean((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteBoolean(ReadOnlySpan<char> propertyName, bool value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			ReadOnlySpan<byte> value2 = (value ? JsonConstants.TrueValue : JsonConstants.FalseValue);
			WriteLiteralEscape(propertyName, value2);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = (value ? JsonTokenType.True : JsonTokenType.False);
		}

		public void WriteBoolean(ReadOnlySpan<byte> utf8PropertyName, bool value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			ReadOnlySpan<byte> value2 = (value ? JsonConstants.TrueValue : JsonConstants.FalseValue);
			WriteLiteralEscape(utf8PropertyName, value2);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = (value ? JsonTokenType.True : JsonTokenType.False);
		}

		private void WriteLiteralEscape(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteLiteralEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteLiteralByOptions(propertyName, value);
			}
		}

		private void WriteLiteralEscape(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteLiteralEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteLiteralByOptions(utf8PropertyName, value);
			}
		}

		private void WriteLiteralEscapeProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteLiteralByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteLiteralEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteLiteralByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteLiteralByOptions(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteLiteralIndented(propertyName, value);
			}
			else
			{
				WriteLiteralMinimized(propertyName, value);
			}
		}

		private void WriteLiteralByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteLiteralIndented(utf8PropertyName, value);
			}
			else
			{
				WriteLiteralMinimized(utf8PropertyName, value);
			}
		}

		private void WriteLiteralMinimized(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> value)
		{
			int num = escapedPropertyName.Length * 3 + value.Length + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			value.CopyTo(span.Slice(BytesPending));
			BytesPending += value.Length;
		}

		private void WriteLiteralMinimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> value)
		{
			int num = escapedPropertyName.Length + value.Length + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			value.CopyTo(span.Slice(BytesPending));
			BytesPending += value.Length;
		}

		private void WriteLiteralIndented(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + value.Length + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			value.CopyTo(span.Slice(BytesPending));
			BytesPending += value.Length;
		}

		private void WriteLiteralIndented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + value.Length + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			value.CopyTo(span.Slice(BytesPending));
			BytesPending += value.Length;
		}

		public void WriteNumber(JsonEncodedText propertyName, long value)
		{
			WriteNumberHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteNumberHelper(ReadOnlySpan<byte> utf8PropertyName, long value)
		{
			WriteNumberByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(string propertyName, long value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteNumber(ReadOnlySpan<char> propertyName, long value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteNumberEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, long value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteNumberEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		public void WriteNumber(JsonEncodedText propertyName, int value)
		{
			WriteNumber(propertyName, (long)value);
		}

		public void WriteNumber(string propertyName, int value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), (long)value);
		}

		public void WriteNumber(ReadOnlySpan<char> propertyName, int value)
		{
			WriteNumber(propertyName, (long)value);
		}

		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, int value)
		{
			WriteNumber(utf8PropertyName, (long)value);
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, long value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, long value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, long value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, long value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, long value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(propertyName, value);
			}
			else
			{
				WriteNumberMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, long value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(utf8PropertyName, value);
			}
			else
			{
				WriteNumberMinimized(utf8PropertyName, value);
			}
		}

		private void WriteNumberMinimized(ReadOnlySpan<char> escapedPropertyName, long value)
		{
			int num = escapedPropertyName.Length * 3 + 20 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, long value)
		{
			int num = escapedPropertyName.Length + 20 + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<char> escapedPropertyName, long value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 20 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, long value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 20 + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WritePropertyName(JsonEncodedText propertyName)
		{
			WritePropertyNameHelper(propertyName.EncodedUtf8Bytes);
		}

		private void WritePropertyNameHelper(ReadOnlySpan<byte> utf8PropertyName)
		{
			WriteStringByOptionsPropertyName(utf8PropertyName);
			_currentDepth &= 2147483647;
			_tokenType = JsonTokenType.PropertyName;
		}

		public void WritePropertyName(string propertyName)
		{
			WritePropertyName((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan());
		}

		public void WritePropertyName(ReadOnlySpan<char> propertyName)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(propertyName, num);
			}
			else
			{
				WriteStringByOptionsPropertyName(propertyName);
			}
			_currentDepth &= 2147483647;
			_tokenType = JsonTokenType.PropertyName;
		}

		private unsafe void WriteStringEscapeProperty(ReadOnlySpan<char> propertyName, int firstEscapeIndexProp)
		{
			char[] array = null;
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
				Span<char> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<char>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					char* pointer = stackalloc char[maxEscapedLength];
					destination = new Span<char>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
				propertyName = destination.Slice(0, written);
			}
			WriteStringByOptionsPropertyName(propertyName);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringByOptionsPropertyName(ReadOnlySpan<char> propertyName)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndentedPropertyName(propertyName);
			}
			else
			{
				WriteStringMinimizedPropertyName(propertyName);
			}
		}

		private void WriteStringMinimizedPropertyName(ReadOnlySpan<char> escapedPropertyName)
		{
			int num = escapedPropertyName.Length * 3 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
		}

		private void WriteStringIndentedPropertyName(ReadOnlySpan<char> escapedPropertyName)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
		}

		public void WritePropertyName(ReadOnlySpan<byte> utf8PropertyName)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeProperty(utf8PropertyName, num);
			}
			else
			{
				WriteStringByOptionsPropertyName(utf8PropertyName);
			}
			_currentDepth &= 2147483647;
			_tokenType = JsonTokenType.PropertyName;
		}

		private unsafe void WriteStringEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, int firstEscapeIndexProp)
		{
			byte[] array = null;
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
				Span<byte> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<byte>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					byte* pointer = stackalloc byte[(int)(uint)maxEscapedLength];
					destination = new Span<byte>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
				utf8PropertyName = destination.Slice(0, written);
			}
			WriteStringByOptionsPropertyName(utf8PropertyName);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringByOptionsPropertyName(ReadOnlySpan<byte> utf8PropertyName)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndentedPropertyName(utf8PropertyName);
			}
			else
			{
				WriteStringMinimizedPropertyName(utf8PropertyName);
			}
		}

		private void WriteStringMinimizedPropertyName(ReadOnlySpan<byte> escapedPropertyName)
		{
			int num = escapedPropertyName.Length + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
		}

		private void WriteStringIndentedPropertyName(ReadOnlySpan<byte> escapedPropertyName)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
		}

		public void WriteString(JsonEncodedText propertyName, JsonEncodedText value)
		{
			WriteStringHelper(propertyName.EncodedUtf8Bytes, value.EncodedUtf8Bytes);
		}

		private void WriteStringHelper(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			WriteStringByOptions(utf8PropertyName, utf8Value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, JsonEncodedText value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteString(string propertyName, string value)
		{
			if (propertyName == null)
			{
				throw new ArgumentNullException("propertyName");
			}
			if (value == null)
			{
				WriteNull(propertyName.AsSpan());
			}
			else
			{
				WriteString(propertyName.AsSpan(), value.AsSpan());
			}
		}

		public void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
		{
			JsonWriterHelper.ValidatePropertyAndValue(propertyName, value);
			WriteStringEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidatePropertyAndValue(utf8PropertyName, utf8Value);
			WriteStringEscape(utf8PropertyName, utf8Value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(JsonEncodedText propertyName, string value)
		{
			if (value == null)
			{
				WriteNull(propertyName);
			}
			else
			{
				WriteString(propertyName, value.AsSpan());
			}
		}

		public void WriteString(JsonEncodedText propertyName, ReadOnlySpan<char> value)
		{
			WriteStringHelperEscapeValue(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteStringHelperEscapeValue(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
		{
			JsonWriterHelper.ValidateValue(value);
			int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeValueOnly(utf8PropertyName, value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, ReadOnlySpan<char> value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
		{
			JsonWriterHelper.ValidatePropertyAndValue(utf8PropertyName, value);
			WriteStringEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(JsonEncodedText propertyName, ReadOnlySpan<byte> utf8Value)
		{
			WriteStringHelperEscapeValue(propertyName.EncodedUtf8Bytes, utf8Value);
		}

		private void WriteStringHelperEscapeValue(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidateValue(utf8Value);
			int num = JsonWriterHelper.NeedsEscaping(utf8Value, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeValueOnly(utf8PropertyName, utf8Value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, utf8Value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(string propertyName, ReadOnlySpan<byte> utf8Value)
		{
			WriteString((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), utf8Value);
		}

		public void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidatePropertyAndValue(propertyName, utf8Value);
			WriteStringEscape(propertyName, utf8Value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<char> propertyName, JsonEncodedText value)
		{
			WriteStringHelperEscapeProperty(propertyName, value.EncodedUtf8Bytes);
		}

		private void WriteStringHelperEscapeProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapePropertyOnly(propertyName, utf8Value, num);
			}
			else
			{
				WriteStringByOptions(propertyName, utf8Value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<char> propertyName, string value)
		{
			if (value == null)
			{
				WriteNull(propertyName);
			}
			else
			{
				WriteString(propertyName, value.AsSpan());
			}
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, JsonEncodedText value)
		{
			WriteStringHelperEscapeProperty(utf8PropertyName, value.EncodedUtf8Bytes);
		}

		private void WriteStringHelperEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapePropertyOnly(utf8PropertyName, utf8Value, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, utf8Value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteString(ReadOnlySpan<byte> utf8PropertyName, string value)
		{
			if (value == null)
			{
				WriteNull(utf8PropertyName);
			}
			else
			{
				WriteString(utf8PropertyName, value.AsSpan());
			}
		}

		private void WriteStringEscapeValueOnly(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> utf8Value, int firstEscapeIndex)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, firstEscapeIndex);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8Value, destination, firstEscapeIndex, _options.Encoder, out var written);
			WriteStringByOptions(escapedPropertyName, destination.Slice(0, written));
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringEscapeValueOnly(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> value, int firstEscapeIndex)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndex);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(value, destination, firstEscapeIndex, _options.Encoder, out var written);
			WriteStringByOptions(escapedPropertyName, destination.Slice(0, written));
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringEscapePropertyOnly(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> escapedValue, int firstEscapeIndex)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndex);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndex, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), escapedValue);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteStringEscapePropertyOnly(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> escapedValue, int firstEscapeIndex)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndex);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndex, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written), escapedValue);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
			int num2 = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num + num2 != -2)
			{
				WriteStringEscapePropertyOrValue(propertyName, value, num2, num);
			}
			else
			{
				WriteStringByOptions(propertyName, value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8Value, _options.Encoder);
			int num2 = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num + num2 != -2)
			{
				WriteStringEscapePropertyOrValue(utf8PropertyName, utf8Value, num2, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, utf8Value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8Value, _options.Encoder);
			int num2 = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num + num2 != -2)
			{
				WriteStringEscapePropertyOrValue(propertyName, utf8Value, num2, num);
			}
			else
			{
				WriteStringByOptions(propertyName, utf8Value);
			}
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
			int num2 = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num + num2 != -2)
			{
				WriteStringEscapePropertyOrValue(utf8PropertyName, value, num2, num);
			}
			else
			{
				WriteStringByOptions(utf8PropertyName, value);
			}
		}

		private unsafe void WriteStringEscapePropertyOrValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value, int firstEscapeIndexProp, int firstEscapeIndexVal)
		{
			char[] array = null;
			char[] array2 = null;
			if (firstEscapeIndexVal != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndexVal);
				Span<char> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<char>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					char* pointer = stackalloc char[maxEscapedLength];
					destination = new Span<char>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
				value = destination.Slice(0, written);
			}
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength2 = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
				Span<char> destination2;
				if (maxEscapedLength2 > 256)
				{
					array2 = ArrayPool<char>.Shared.Rent(maxEscapedLength2);
					destination2 = array2;
				}
				else
				{
					char* pointer2 = stackalloc char[maxEscapedLength2];
					destination2 = new Span<char>(pointer2, maxEscapedLength2);
				}
				JsonWriterHelper.EscapeString(propertyName, destination2, firstEscapeIndexProp, _options.Encoder, out var written2);
				propertyName = destination2.Slice(0, written2);
			}
			WriteStringByOptions(propertyName, value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			if (array2 != null)
			{
				ArrayPool<char>.Shared.Return(array2);
			}
		}

		private unsafe void WriteStringEscapePropertyOrValue(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value, int firstEscapeIndexProp, int firstEscapeIndexVal)
		{
			byte[] array = null;
			byte[] array2 = null;
			if (firstEscapeIndexVal != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, firstEscapeIndexVal);
				Span<byte> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<byte>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					byte* pointer = stackalloc byte[(int)(uint)maxEscapedLength];
					destination = new Span<byte>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(utf8Value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
				utf8Value = destination.Slice(0, written);
			}
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength2 = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
				Span<byte> destination2;
				if (maxEscapedLength2 > 256)
				{
					array2 = ArrayPool<byte>.Shared.Rent(maxEscapedLength2);
					destination2 = array2;
				}
				else
				{
					byte* pointer2 = stackalloc byte[(int)(uint)maxEscapedLength2];
					destination2 = new Span<byte>(pointer2, maxEscapedLength2);
				}
				JsonWriterHelper.EscapeString(utf8PropertyName, destination2, firstEscapeIndexProp, _options.Encoder, out var written2);
				utf8PropertyName = destination2.Slice(0, written2);
			}
			WriteStringByOptions(utf8PropertyName, utf8Value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
			if (array2 != null)
			{
				ArrayPool<byte>.Shared.Return(array2);
			}
		}

		private unsafe void WriteStringEscapePropertyOrValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value, int firstEscapeIndexProp, int firstEscapeIndexVal)
		{
			byte[] array = null;
			char[] array2 = null;
			if (firstEscapeIndexVal != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, firstEscapeIndexVal);
				Span<byte> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<byte>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					byte* pointer = stackalloc byte[(int)(uint)maxEscapedLength];
					destination = new Span<byte>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(utf8Value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
				utf8Value = destination.Slice(0, written);
			}
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength2 = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
				Span<char> destination2;
				if (maxEscapedLength2 > 256)
				{
					array2 = ArrayPool<char>.Shared.Rent(maxEscapedLength2);
					destination2 = array2;
				}
				else
				{
					char* pointer2 = stackalloc char[maxEscapedLength2];
					destination2 = new Span<char>(pointer2, maxEscapedLength2);
				}
				JsonWriterHelper.EscapeString(propertyName, destination2, firstEscapeIndexProp, _options.Encoder, out var written2);
				propertyName = destination2.Slice(0, written2);
			}
			WriteStringByOptions(propertyName, utf8Value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
			if (array2 != null)
			{
				ArrayPool<char>.Shared.Return(array2);
			}
		}

		private unsafe void WriteStringEscapePropertyOrValue(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value, int firstEscapeIndexProp, int firstEscapeIndexVal)
		{
			char[] array = null;
			byte[] array2 = null;
			if (firstEscapeIndexVal != -1)
			{
				int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndexVal);
				Span<char> destination;
				if (maxEscapedLength > 256)
				{
					array = ArrayPool<char>.Shared.Rent(maxEscapedLength);
					destination = array;
				}
				else
				{
					char* pointer = stackalloc char[maxEscapedLength];
					destination = new Span<char>(pointer, maxEscapedLength);
				}
				JsonWriterHelper.EscapeString(value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
				value = destination.Slice(0, written);
			}
			if (firstEscapeIndexProp != -1)
			{
				int maxEscapedLength2 = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
				Span<byte> destination2;
				if (maxEscapedLength2 > 256)
				{
					array2 = ArrayPool<byte>.Shared.Rent(maxEscapedLength2);
					destination2 = array2;
				}
				else
				{
					byte* pointer2 = stackalloc byte[(int)(uint)maxEscapedLength2];
					destination2 = new Span<byte>(pointer2, maxEscapedLength2);
				}
				JsonWriterHelper.EscapeString(utf8PropertyName, destination2, firstEscapeIndexProp, _options.Encoder, out var written2);
				utf8PropertyName = destination2.Slice(0, written2);
			}
			WriteStringByOptions(utf8PropertyName, value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			if (array2 != null)
			{
				ArrayPool<byte>.Shared.Return(array2);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(propertyName, value);
			}
			else
			{
				WriteStringMinimized(propertyName, value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(utf8PropertyName, utf8Value);
			}
			else
			{
				WriteStringMinimized(utf8PropertyName, utf8Value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(propertyName, utf8Value);
			}
			else
			{
				WriteStringMinimized(propertyName, utf8Value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteStringIndented(utf8PropertyName, value);
			}
			else
			{
				WriteStringMinimized(utf8PropertyName, value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<char> escapedValue)
		{
			int num = (escapedPropertyName.Length + escapedValue.Length) * 3 + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> escapedValue)
		{
			int num = escapedPropertyName.Length + escapedValue.Length + 5;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> escapedValue)
		{
			int num = escapedPropertyName.Length * 3 + escapedValue.Length + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> escapedValue)
		{
			int num = escapedValue.Length * 3 + escapedPropertyName.Length + 6;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<char> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + (escapedPropertyName.Length + escapedValue.Length) * 3 + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + escapedValue.Length + 6;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedPropertyName, ReadOnlySpan<byte> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + escapedValue.Length + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + escapedValue.Length * 3 + escapedPropertyName.Length + 7 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		[CLSCompliant(false)]
		public void WriteNumber(JsonEncodedText propertyName, ulong value)
		{
			WriteNumberHelper(propertyName.EncodedUtf8Bytes, value);
		}

		private void WriteNumberHelper(ReadOnlySpan<byte> utf8PropertyName, ulong value)
		{
			WriteNumberByOptions(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		[CLSCompliant(false)]
		public void WriteNumber(string propertyName, ulong value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), value);
		}

		[CLSCompliant(false)]
		public void WriteNumber(ReadOnlySpan<char> propertyName, ulong value)
		{
			JsonWriterHelper.ValidateProperty(propertyName);
			WriteNumberEscape(propertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		[CLSCompliant(false)]
		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ulong value)
		{
			JsonWriterHelper.ValidateProperty(utf8PropertyName);
			WriteNumberEscape(utf8PropertyName, value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		[CLSCompliant(false)]
		public void WriteNumber(JsonEncodedText propertyName, uint value)
		{
			WriteNumber(propertyName, (ulong)value);
		}

		[CLSCompliant(false)]
		public void WriteNumber(string propertyName, uint value)
		{
			WriteNumber((propertyName ?? throw new ArgumentNullException("propertyName")).AsSpan(), (ulong)value);
		}

		[CLSCompliant(false)]
		public void WriteNumber(ReadOnlySpan<char> propertyName, uint value)
		{
			WriteNumber(propertyName, (ulong)value);
		}

		[CLSCompliant(false)]
		public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, uint value)
		{
			WriteNumber(utf8PropertyName, (ulong)value);
		}

		private void WriteNumberEscape(ReadOnlySpan<char> propertyName, ulong value)
		{
			int num = JsonWriterHelper.NeedsEscaping(propertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(propertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(propertyName, value);
			}
		}

		private void WriteNumberEscape(ReadOnlySpan<byte> utf8PropertyName, ulong value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8PropertyName, _options.Encoder);
			if (num != -1)
			{
				WriteNumberEscapeProperty(utf8PropertyName, value, num);
			}
			else
			{
				WriteNumberByOptions(utf8PropertyName, value);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<char> propertyName, ulong value, int firstEscapeIndexProp)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(propertyName.Length, firstEscapeIndexProp);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(propertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		private void WriteNumberEscapeProperty(ReadOnlySpan<byte> utf8PropertyName, ulong value, int firstEscapeIndexProp)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8PropertyName.Length, firstEscapeIndexProp);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8PropertyName, destination, firstEscapeIndexProp, _options.Encoder, out var written);
			WriteNumberByOptions(destination.Slice(0, written), value);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<char> propertyName, ulong value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(propertyName, value);
			}
			else
			{
				WriteNumberMinimized(propertyName, value);
			}
		}

		private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, ulong value)
		{
			ValidateWritingProperty();
			if (_options.Indented)
			{
				WriteNumberIndented(utf8PropertyName, value);
			}
			else
			{
				WriteNumberMinimized(utf8PropertyName, value);
			}
		}

		private void WriteNumberMinimized(ReadOnlySpan<char> escapedPropertyName, ulong value)
		{
			int num = escapedPropertyName.Length * 3 + 20 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, ulong value)
		{
			int num = escapedPropertyName.Length + 20 + 3;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<char> escapedPropertyName, ulong value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length * 3 + 20 + 5 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedPropertyName, span);
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, ulong value)
		{
			int indentation = Indentation;
			int num = indentation + escapedPropertyName.Length + 20 + 4;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 34;
			escapedPropertyName.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedPropertyName.Length;
			span[BytesPending++] = 34;
			span[BytesPending++] = 58;
			span[BytesPending++] = 32;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteBase64StringValue(ReadOnlySpan<byte> bytes)
		{
			JsonWriterHelper.ValidateBytes(bytes);
			WriteBase64ByOptions(bytes);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteBase64ByOptions(ReadOnlySpan<byte> bytes)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteBase64Indented(bytes);
			}
			else
			{
				WriteBase64Minimized(bytes);
			}
		}

		private void WriteBase64Minimized(ReadOnlySpan<byte> bytes)
		{
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = maxEncodedToUtf8Length + 3;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		private void WriteBase64Indented(ReadOnlySpan<byte> bytes)
		{
			int indentation = Indentation;
			int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(bytes.Length);
			int num = indentation + maxEncodedToUtf8Length + 3 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			Base64EncodeAndWrite(bytes, span, maxEncodedToUtf8Length);
			span[BytesPending++] = 34;
		}

		public void WriteCommentValue(string value)
		{
			WriteCommentValue((value ?? throw new ArgumentNullException("value")).AsSpan());
		}

		public void WriteCommentValue(ReadOnlySpan<char> value)
		{
			JsonWriterHelper.ValidateValue(value);
			if (value.IndexOf(s_singleLineCommentDelimiter) != -1)
			{
				ThrowHelper.ThrowArgumentException_InvalidCommentValue();
			}
			WriteCommentByOptions(value);
		}

		private void WriteCommentByOptions(ReadOnlySpan<char> value)
		{
			if (_options.Indented)
			{
				WriteCommentIndented(value);
			}
			else
			{
				WriteCommentMinimized(value);
			}
		}

		private void WriteCommentMinimized(ReadOnlySpan<char> value)
		{
			int num = value.Length * 3 + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			span[BytesPending++] = 47;
			int bytesConsumed = BytesPending++;
			span[bytesConsumed] = 42;
			ReadOnlySpan<byte> utf16Source = MemoryMarshal.AsBytes(value);
			int bytesWritten;
			OperationStatus operationStatus = JsonWriterHelper.ToUtf8(utf16Source, span.Slice(BytesPending), out bytesConsumed, out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 42;
			span[BytesPending++] = 47;
		}

		private void WriteCommentIndented(ReadOnlySpan<char> value)
		{
			int indentation = Indentation;
			int num = indentation + value.Length * 3 + 4 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
			span[BytesPending++] = 47;
			int bytesConsumed = BytesPending++;
			span[bytesConsumed] = 42;
			ReadOnlySpan<byte> utf16Source = MemoryMarshal.AsBytes(value);
			int bytesWritten;
			OperationStatus operationStatus = JsonWriterHelper.ToUtf8(utf16Source, span.Slice(BytesPending), out bytesConsumed, out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 42;
			span[BytesPending++] = 47;
		}

		public void WriteCommentValue(ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidateValue(utf8Value);
			if (utf8Value.IndexOf(SingleLineCommentDelimiterUtf8) != -1)
			{
				ThrowHelper.ThrowArgumentException_InvalidCommentValue();
			}
			WriteCommentByOptions(utf8Value);
		}

		private void WriteCommentByOptions(ReadOnlySpan<byte> utf8Value)
		{
			if (_options.Indented)
			{
				WriteCommentIndented(utf8Value);
			}
			else
			{
				WriteCommentMinimized(utf8Value);
			}
		}

		private void WriteCommentMinimized(ReadOnlySpan<byte> utf8Value)
		{
			int num = utf8Value.Length + 4;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			span[BytesPending++] = 47;
			span[BytesPending++] = 42;
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
			span[BytesPending++] = 42;
			span[BytesPending++] = 47;
		}

		private void WriteCommentIndented(ReadOnlySpan<byte> utf8Value)
		{
			int indentation = Indentation;
			int num = indentation + utf8Value.Length + 4;
			int num2 = num + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 47;
			span[BytesPending++] = 42;
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
			span[BytesPending++] = 42;
			span[BytesPending++] = 47;
		}

		public void WriteStringValue(DateTime value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteStringValueIndented(value);
			}
			else
			{
				WriteStringValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringValueMinimized(DateTime value)
		{
			int num = 36;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringValueIndented(DateTime value)
		{
			int indentation = Indentation;
			int num = indentation + 33 + 3 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		public void WriteStringValue(DateTimeOffset value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteStringValueIndented(value);
			}
			else
			{
				WriteStringValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringValueMinimized(DateTimeOffset value)
		{
			int num = 36;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringValueIndented(DateTimeOffset value)
		{
			int indentation = Indentation;
			int num = indentation + 33 + 3 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			Span<byte> destination = stackalloc byte[33];
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, destination, out bytesWritten, s_dateTimeStandardFormat);
			JsonWriterHelper.TrimDateTimeOffset(destination.Slice(0, bytesWritten), out bytesWritten);
			destination.Slice(0, bytesWritten).CopyTo(span.Slice(BytesPending));
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		public void WriteNumberValue(decimal value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(value);
			}
			else
			{
				WriteNumberValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(decimal value)
		{
			int num = 32;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberValueIndented(decimal value)
		{
			int indentation = Indentation;
			int num = indentation + 31 + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteNumberValue(double value)
		{
			JsonWriterHelper.ValidateDouble(value);
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(value);
			}
			else
			{
				WriteNumberValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(double value)
		{
			int num = 129;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberValueIndented(double value)
		{
			int indentation = Indentation;
			int num = indentation + 128 + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			int bytesWritten;
			bool flag = TryFormatDouble(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private static bool TryFormatDouble(double value, Span<byte> destination, out int bytesWritten)
		{
			string text = value.ToString("G17", CultureInfo.InvariantCulture);
			if (text.Length > destination.Length)
			{
				bytesWritten = 0;
				return false;
			}
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				if (bytes.Length > destination.Length)
				{
					bytesWritten = 0;
					return false;
				}
				bytes.CopyTo(destination);
				bytesWritten = bytes.Length;
				return true;
			}
			catch
			{
				bytesWritten = 0;
				return false;
			}
		}

		public void WriteNumberValue(float value)
		{
			JsonWriterHelper.ValidateSingle(value);
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(value);
			}
			else
			{
				WriteNumberValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(float value)
		{
			int num = 129;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberValueIndented(float value)
		{
			int indentation = Indentation;
			int num = indentation + 128 + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			int bytesWritten;
			bool flag = TryFormatSingle(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private static bool TryFormatSingle(float value, Span<byte> destination, out int bytesWritten)
		{
			string text = value.ToString("G9", CultureInfo.InvariantCulture);
			if (text.Length > destination.Length)
			{
				bytesWritten = 0;
				return false;
			}
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				if (bytes.Length > destination.Length)
				{
					bytesWritten = 0;
					return false;
				}
				bytes.CopyTo(destination);
				bytesWritten = bytes.Length;
				return true;
			}
			catch
			{
				bytesWritten = 0;
				return false;
			}
		}

		internal void WriteNumberValue(ReadOnlySpan<byte> utf8FormattedNumber)
		{
			JsonWriterHelper.ValidateValue(utf8FormattedNumber);
			JsonWriterHelper.ValidateNumber(utf8FormattedNumber);
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(utf8FormattedNumber);
			}
			else
			{
				WriteNumberValueMinimized(utf8FormattedNumber);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(ReadOnlySpan<byte> utf8Value)
		{
			int num = utf8Value.Length + 1;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
		}

		private void WriteNumberValueIndented(ReadOnlySpan<byte> utf8Value)
		{
			int indentation = Indentation;
			int num = indentation + utf8Value.Length + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
		}

		public void WriteStringValue(Guid value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteStringValueIndented(value);
			}
			else
			{
				WriteStringValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringValueMinimized(Guid value)
		{
			int num = 39;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void WriteStringValueIndented(Guid value)
		{
			int indentation = Indentation;
			int num = indentation + 36 + 3 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
			span[BytesPending++] = 34;
		}

		private void ValidateWritingValue()
		{
			if (_options.SkipValidation)
			{
				return;
			}
			if (_inObject)
			{
				if (_tokenType != JsonTokenType.PropertyName)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWriteValueWithinObject, 0, 0, _tokenType);
				}
			}
			else if (CurrentDepth == 0 && _tokenType != JsonTokenType.None)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWriteValueAfterPrimitiveOrClose, 0, 0, _tokenType);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Base64EncodeAndWrite(ReadOnlySpan<byte> bytes, Span<byte> output, int encodingLength)
		{
			byte[] array = null;
			Span<byte> span = ((encodingLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(encodingLength))) : stackalloc byte[encodingLength]);
			Span<byte> utf = span;
			int bytesConsumed;
			int bytesWritten;
			OperationStatus operationStatus = Base64.EncodeToUtf8(bytes, utf, out bytesConsumed, out bytesWritten);
			utf = utf.Slice(0, bytesWritten);
			Span<byte> destination = output.Slice(BytesPending);
			utf.Slice(0, bytesWritten).CopyTo(destination);
			BytesPending += bytesWritten;
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		public void WriteNullValue()
		{
			WriteLiteralByOptions(JsonConstants.NullValue);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Null;
		}

		public void WriteBooleanValue(bool value)
		{
			if (value)
			{
				WriteLiteralByOptions(JsonConstants.TrueValue);
				_tokenType = JsonTokenType.True;
			}
			else
			{
				WriteLiteralByOptions(JsonConstants.FalseValue);
				_tokenType = JsonTokenType.False;
			}
			SetFlagToAddListSeparatorBeforeNextItem();
		}

		private void WriteLiteralByOptions(ReadOnlySpan<byte> utf8Value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteLiteralIndented(utf8Value);
			}
			else
			{
				WriteLiteralMinimized(utf8Value);
			}
		}

		private void WriteLiteralMinimized(ReadOnlySpan<byte> utf8Value)
		{
			int num = utf8Value.Length + 1;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
		}

		private void WriteLiteralIndented(ReadOnlySpan<byte> utf8Value)
		{
			int indentation = Indentation;
			int num = indentation + utf8Value.Length + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			utf8Value.CopyTo(span.Slice(BytesPending));
			BytesPending += utf8Value.Length;
		}

		public void WriteNumberValue(int value)
		{
			WriteNumberValue((long)value);
		}

		public void WriteNumberValue(long value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(value);
			}
			else
			{
				WriteNumberValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(long value)
		{
			int num = 21;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberValueIndented(long value)
		{
			int indentation = Indentation;
			int num = indentation + 20 + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		public void WriteStringValue(JsonEncodedText value)
		{
			WriteStringValueHelper(value.EncodedUtf8Bytes);
		}

		private void WriteStringValueHelper(ReadOnlySpan<byte> utf8Value)
		{
			WriteStringByOptions(utf8Value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		public void WriteStringValue(string value)
		{
			if (value == null)
			{
				WriteNullValue();
			}
			else
			{
				WriteStringValue(value.AsSpan());
			}
		}

		public void WriteStringValue(ReadOnlySpan<char> value)
		{
			JsonWriterHelper.ValidateValue(value);
			WriteStringEscape(value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringEscape(ReadOnlySpan<char> value)
		{
			int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeValue(value, num);
			}
			else
			{
				WriteStringByOptions(value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<char> value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteStringIndented(value);
			}
			else
			{
				WriteStringMinimized(value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<char> escapedValue)
		{
			int num = escapedValue.Length * 3 + 3;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<char> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + escapedValue.Length * 3 + 3 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			TranscodeAndWrite(escapedValue, span);
			span[BytesPending++] = 34;
		}

		private void WriteStringEscapeValue(ReadOnlySpan<char> value, int firstEscapeIndexVal)
		{
			char[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndexVal);
			Span<char> span = ((maxEscapedLength > 256) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[maxEscapedLength]);
			Span<char> destination = span;
			JsonWriterHelper.EscapeString(value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written));
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		public void WriteStringValue(ReadOnlySpan<byte> utf8Value)
		{
			JsonWriterHelper.ValidateValue(utf8Value);
			WriteStringEscape(utf8Value);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.String;
		}

		private void WriteStringEscape(ReadOnlySpan<byte> utf8Value)
		{
			int num = JsonWriterHelper.NeedsEscaping(utf8Value, _options.Encoder);
			if (num != -1)
			{
				WriteStringEscapeValue(utf8Value, num);
			}
			else
			{
				WriteStringByOptions(utf8Value);
			}
		}

		private void WriteStringByOptions(ReadOnlySpan<byte> utf8Value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteStringIndented(utf8Value);
			}
			else
			{
				WriteStringMinimized(utf8Value);
			}
		}

		private void WriteStringMinimized(ReadOnlySpan<byte> escapedValue)
		{
			int num = escapedValue.Length + 2;
			int num2 = num + 1;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringIndented(ReadOnlySpan<byte> escapedValue)
		{
			int indentation = Indentation;
			int num = indentation + escapedValue.Length + 2;
			int num2 = num + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num2)
			{
				Grow(num2);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			span[BytesPending++] = 34;
			escapedValue.CopyTo(span.Slice(BytesPending));
			BytesPending += escapedValue.Length;
			span[BytesPending++] = 34;
		}

		private void WriteStringEscapeValue(ReadOnlySpan<byte> utf8Value, int firstEscapeIndexVal)
		{
			byte[] array = null;
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(utf8Value.Length, firstEscapeIndexVal);
			Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[maxEscapedLength]);
			Span<byte> destination = span;
			JsonWriterHelper.EscapeString(utf8Value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
			WriteStringByOptions(destination.Slice(0, written));
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		[CLSCompliant(false)]
		public void WriteNumberValue(uint value)
		{
			WriteNumberValue((ulong)value);
		}

		[CLSCompliant(false)]
		public void WriteNumberValue(ulong value)
		{
			ValidateWritingValue();
			if (_options.Indented)
			{
				WriteNumberValueIndented(value);
			}
			else
			{
				WriteNumberValueMinimized(value);
			}
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Number;
		}

		private void WriteNumberValueMinimized(ulong value)
		{
			int num = 21;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}

		private void WriteNumberValueIndented(ulong value)
		{
			int indentation = Indentation;
			int num = indentation + 20 + 1 + s_newLineLength;
			if (_memory.Length - BytesPending < num)
			{
				Grow(num);
			}
			Span<byte> span = _memory.Span;
			if (_currentDepth < 0)
			{
				span[BytesPending++] = 44;
			}
			if (_tokenType != JsonTokenType.PropertyName)
			{
				if (_tokenType != JsonTokenType.None)
				{
					WriteNewLine(span);
				}
				JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
				BytesPending += indentation;
			}
			int bytesWritten;
			bool flag = Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out bytesWritten);
			BytesPending += bytesWritten;
		}
	}
}
namespace System.Text.Json.Serialization
{
	internal sealed class ConverterList : IList<JsonConverter>, ICollection<JsonConverter>, IEnumerable<JsonConverter>, IEnumerable
	{
		private readonly List<JsonConverter> _list = new List<JsonConverter>();

		private JsonSerializerOptions _options;

		public JsonConverter this[int index]
		{
			get
			{
				return _list[index];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_options.VerifyMutable();
				_list[index] = value;
			}
		}

		public int Count => _list.Count;

		public bool IsReadOnly => false;

		public ConverterList(JsonSerializerOptions options)
		{
			_options = options;
		}

		public void Add(JsonConverter item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			_options.VerifyMutable();
			_list.Add(item);
		}

		public void Clear()
		{
			_options.VerifyMutable();
			_list.Clear();
		}

		public bool Contains(JsonConverter item)
		{
			return _list.Contains(item);
		}

		public void CopyTo(JsonConverter[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		public IEnumerator<JsonConverter> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public int IndexOf(JsonConverter item)
		{
			return _list.IndexOf(item);
		}

		public void Insert(int index, JsonConverter item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			_options.VerifyMutable();
			_list.Insert(index, item);
		}

		public bool Remove(JsonConverter item)
		{
			_options.VerifyMutable();
			return _list.Remove(item);
		}

		public void RemoveAt(int index)
		{
			_options.VerifyMutable();
			_list.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}
	}
	internal enum ExtensionDataWriteStatus : byte
	{
		NotStarted,
		Writing,
		Finished
	}
	public abstract class JsonAttribute : Attribute
	{
	}
	public abstract class JsonConverter
	{
		internal virtual Type TypeToConvert => null;

		internal JsonConverter()
		{
		}

		public abstract bool CanConvert(Type typeToConvert);
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property, AllowMultiple = false)]
	public class JsonConverterAttribute : JsonAttribute
	{
		public Type ConverterType { get; private set; }

		public JsonConverterAttribute(Type converterType)
		{
			ConverterType = converterType;
		}

		protected JsonConverterAttribute()
		{
		}

		public virtual JsonConverter CreateConverter(Type typeToConvert)
		{
			return null;
		}
	}
	public abstract class JsonConverterFactory : JsonConverter
	{
		internal JsonConverter GetConverterInternal(Type typeToConvert, JsonSerializerOptions options)
		{
			return CreateConverter(typeToConvert, options);
		}

		public abstract JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options);
	}
	public abstract class JsonConverter<T> : JsonConverter
	{
		internal override Type TypeToConvert => typeof(T);

		protected internal JsonConverter()
		{
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(T);
		}

		public abstract T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);

		public abstract void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options);
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class JsonExtensionDataAttribute : JsonAttribute
	{
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class JsonIgnoreAttribute : JsonAttribute
	{
	}
	internal sealed class JsonPropertyInfoNotNullableContravariant<TClass, TDeclaredProperty, TRuntimeProperty, TConverter> : JsonPropertyInfoCommon<TClass, TDeclaredProperty, TRuntimeProperty, TConverter> where TDeclaredProperty : TConverter
	{
		protected override void OnRead(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			TConverter val = base.Converter.Read(ref reader, base.RuntimePropertyType, base.Options);
			if (state.Current.ReturnValue == null)
			{
				state.Current.ReturnValue = val;
			}
			else
			{
				base.Set(state.Current.ReturnValue, (TDeclaredProperty)(object)val);
			}
		}

		protected override void OnReadEnumerable(ref ReadStack state, ref Utf8JsonReader reader)
		{
			if (base.Converter == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
			}
			if (state.Current.KeyName == null && state.Current.IsProcessingDictionaryOrIDictionaryConstructible())
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
				return;
			}
			if (state.Current.IsProcessingEnumerable() && state.Current.TempEnumerableValues == null && state.Current.ReturnValue == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(base.RuntimePropertyType);
				return;
			}
			TConverter value = base.Converter.Read(ref reader, base.RuntimePropertyType, base.Options);
			JsonSerializer.ApplyValueToEnumerable(ref value, ref state);
		}

		protected override void OnWrite(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			TConverter val = ((!base.IsPropertyPolicy) ? ((TConverter)(object)base.Get(current.CurrentValue)) : ((TConverter)current.CurrentValue));
			if (val == null)
			{
				if (!base.IgnoreNullValues)
				{
					writer.WriteNull(EscapedName.Value);
				}
			}
			else if (base.Converter != null)
			{
				if (EscapedName.HasValue)
				{
					writer.WritePropertyName(EscapedName.Value);
				}
				base.Converter.Write(writer, val, base.Options);
			}
		}

		protected override void OnWriteDictionary(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			JsonSerializer.WriteDictionary(base.Converter, base.Options, ref current, writer);
		}

		protected override void OnWriteEnumerable(ref WriteStackFrame current, Utf8JsonWriter writer)
		{
			if (base.Converter != null)
			{
				TConverter val = ((!(current.CollectionEnumerator is IEnumerator<TConverter> enumerator)) ? ((TConverter)current.CollectionEnumerator.Current) : enumerator.Current);
				if (val == null)
				{
					writer.WriteNullValue();
				}
				else
				{
					base.Converter.Write(writer, val, base.Options);
				}
			}
		}

		public override Type GetDictionaryConcreteType()
		{
			return typeof(Dictionary<string, TRuntimeProperty>);
		}

		public override void GetDictionaryKeyAndValueFromGenericDictionary(ref WriteStackFrame writeStackFrame, out string key, out object value)
		{
			if (writeStackFrame.CollectionEnumerator is IEnumerator<KeyValuePair<string, TDeclaredProperty>> enumerator)
			{
				key = enumerator.Current.Key;
				value = enumerator.Current.Value;
				return;
			}
			throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(writeStackFrame.JsonPropertyInfo.DeclaredPropertyType, writeStackFrame.JsonPropertyInfo.ParentClassType, writeStackFrame.JsonPropertyInfo.PropertyInfo);
		}
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class JsonPropertyNameAttribute : JsonAttribute
	{
		public string Name { get; }

		public JsonPropertyNameAttribute(string name)
		{
			Name = name;
		}
	}
	public sealed class JsonStringEnumConverter : JsonConverterFactory
	{
		private readonly JsonNamingPolicy _namingPolicy;

		private readonly EnumConverterOptions _converterOptions;

		public JsonStringEnumConverter()
			: this(null, true)
		{
		}

		public JsonStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
		{
			_namingPolicy = namingPolicy;
			_converterOptions = ((!allowIntegerValues) ? EnumConverterOptions.AllowStrings : (EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers));
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert.IsEnum;
		}

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			return (JsonConverter)Activator.CreateInstance(typeof(JsonConverterEnum<>).MakeGenericType(typeToConvert), BindingFlags.Instance | BindingFlags.Public, null, new object[2] { _converterOptions, _namingPolicy }, null);
		}
	}
}
namespace System.Text.Json.Serialization.Converters
{
	internal sealed class DefaultDerivedDictionaryConverter : JsonDictionaryConverter
	{
		public override object CreateFromDictionary(ref ReadStack state, IDictionary sourceDictionary, JsonSerializerOptions options)
		{
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(jsonPropertyInfo.ElementType, options);
			return jsonPropertyInfoFromClassInfo.CreateDerivedDictionaryInstance(ref state, jsonPropertyInfo, sourceDictionary);
		}
	}
	internal sealed class DefaultDerivedEnumerableConverter : JsonEnumerableConverter
	{
		public override IEnumerable CreateFromList(ref ReadStack state, IList sourceList, JsonSerializerOptions options)
		{
			JsonPropertyInfo jsonPropertyInfo = state.Current.JsonPropertyInfo;
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(jsonPropertyInfo.ElementType, options);
			return jsonPropertyInfoFromClassInfo.CreateDerivedEnumerableInstance(ref state, jsonPropertyInfo, sourceList);
		}
	}
	internal sealed class DefaultArrayConverter : JsonEnumerableConverter
	{
		public override IEnumerable CreateFromList(ref ReadStack state, IList sourceList, JsonSerializerOptions options)
		{
			Type elementType = state.Current.GetElementType();
			Array array2;
			if (sourceList.Count > 0 && sourceList[0] is Array array)
			{
				array2 = Array.CreateInstance(array.GetType(), sourceList.Count);
				int num = 0;
				foreach (IList source in sourceList)
				{
					if (source is Array value)
					{
						array2.SetValue(value, num++);
					}
				}
			}
			else
			{
				array2 = Array.CreateInstance(elementType, sourceList.Count);
				sourceList.CopyTo(array2, 0);
			}
			return array2;
		}
	}
	internal sealed class DefaultICollectionConverter : JsonEnumerableConverter
	{
		public override IEnumerable CreateFromList(ref ReadStack state, IList sourceList, JsonSerializerOptions options)
		{
			Type runtimePropertyType = state.Current.JsonPropertyInfo.RuntimePropertyType;
			Type elementType = state.Current.JsonPropertyInfo.ElementType;
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(elementType, options);
			return jsonPropertyInfoFromClassInfo.CreateIEnumerableInstance(ref state, runtimePropertyType, sourceList);
		}
	}
	internal sealed class DefaultIDictionaryConverter : JsonDictionaryConverter
	{
		public override object CreateFromDictionary(ref ReadStack state, IDictionary sourceDictionary, JsonSerializerOptions options)
		{
			Type runtimePropertyType = state.Current.JsonPropertyInfo.RuntimePropertyType;
			Type elementType = state.Current.JsonPropertyInfo.ElementType;
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(elementType, options);
			return jsonPropertyInfoFromClassInfo.CreateIDictionaryInstance(ref state, runtimePropertyType, sourceDictionary);
		}
	}
	internal sealed class DefaultImmutableEnumerableConverter : JsonEnumerableConverter
	{
		public const string ImmutableArrayTypeName = "System.Collections.Immutable.ImmutableArray";

		public const string ImmutableArrayGenericTypeName = "System.Collections.Immutable.ImmutableArray`1";

		private const string ImmutableListTypeName = "System.Collections.Immutable.ImmutableList";

		public const string ImmutableListGenericTypeName = "System.Collections.Immutable.ImmutableList`1";

		public const string ImmutableListGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableList`1";

		private const string ImmutableStackTypeName = "System.Collections.Immutable.ImmutableStack";

		public const string ImmutableStackGenericTypeName = "System.Collections.Immutable.ImmutableStack`1";

		public const string ImmutableStackGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableStack`1";

		private const string ImmutableQueueTypeName = "System.Collections.Immutable.ImmutableQueue";

		public const string ImmutableQueueGenericTypeName = "System.Collections.Immutable.ImmutableQueue`1";

		public const string ImmutableQueueGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableQueue`1";

		public const string ImmutableSortedSetTypeName = "System.Collections.Immutable.ImmutableSortedSet";

		public const string ImmutableSortedSetGenericTypeName = "System.Collections.Immutable.ImmutableSortedSet`1";

		private const string ImmutableHashSetTypeName = "System.Collections.Immutable.ImmutableHashSet";

		public const string ImmutableHashSetGenericTypeName = "System.Collections.Immutable.ImmutableHashSet`1";

		public const string ImmutableSetGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableSet`1";

		public static string GetDelegateKey(Type immutableCollectionType, Type elementType, out Type underlyingType, out string constructingTypeName)
		{
			underlyingType = immutableCollectionType.GetGenericTypeDefinition();
			switch (underlyingType.FullName)
			{
			case "System.Collections.Immutable.ImmutableArray`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableArray";
				break;
			case "System.Collections.Immutable.ImmutableList`1":
			case "System.Collections.Immutable.IImmutableList`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableList";
				break;
			case "System.Collections.Immutable.ImmutableStack`1":
			case "System.Collections.Immutable.IImmutableStack`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableStack";
				break;
			case "System.Collections.Immutable.ImmutableQueue`1":
			case "System.Collections.Immutable.IImmutableQueue`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableQueue";
				break;
			case "System.Collections.Immutable.ImmutableSortedSet`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableSortedSet";
				break;
			case "System.Collections.Immutable.ImmutableHashSet`1":
			case "System.Collections.Immutable.IImmutableSet`1":
				constructingTypeName = "System.Collections.Immutable.ImmutableHashSet";
				break;
			case "System.Collections.Immutable.ImmutableDictionary`2":
			case "System.Collections.Immutable.IImmutableDictionary`2":
				constructingTypeName = "System.Collections.Immutable.ImmutableDictionary";
				break;
			case "System.Collections.Immutable.ImmutableSortedDictionary`2":
				constructingTypeName = "System.Collections.Immutable.ImmutableSortedDictionary";
				break;
			default:
				throw ThrowHelper.GetNotSupportedException_SerializationNotSupportedCollection(immutableCollectionType, null, null);
			}
			return constructingTypeName + ":" + elementType.FullName;
		}

		public static void RegisterImmutableCollection(Type immutableCollectionType, Type elementType, JsonSerializerOptions options)
		{
			Type underlyingType;
			string constructingTypeName;
			string delegateKey = GetDelegateKey(immutableCollectionType, elementType, out underlyingType, out constructingTypeName);
			if (!options.CreateRangeDelegatesContainsKey(delegateKey))
			{
				Type type = underlyingType.Assembly.GetType(constructingTypeName);
				ImmutableCollectionCreator createRangeDelegate = options.MemberAccessorStrategy.ImmutableCollectionCreateRange(type, immutableCollectionType, elementType);
				options.TryAddCreateRangeDelegate(delegateKey, createRangeDelegate);
			}
		}

		public override IEnumerable CreateFromList(ref ReadStack state, IList sourceList, JsonSerializerOptions options)
		{
			Type runtimePropertyType = state.Current.JsonPropertyInfo.RuntimePropertyType;
			Type elementType = state.Current.GetElementType();
			Type underlyingType;
			string constructingTypeName;
			string delegateKey = GetDelegateKey(runtimePropertyType, elementType, out underlyingType, out constructingTypeName);
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(elementType, options);
			return jsonPropertyInfoFromClassInfo.CreateImmutableCollectionInstance(ref state, runtimePropertyType, delegateKey, sourceList, options);
		}
	}
	internal sealed class DefaultImmutableDictionaryConverter : JsonDictionaryConverter
	{
		public const string ImmutableDictionaryTypeName = "System.Collections.Immutable.ImmutableDictionary";

		public const string ImmutableDictionaryGenericTypeName = "System.Collections.Immutable.ImmutableDictionary`2";

		public const string ImmutableDictionaryGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableDictionary`2";

		public const string ImmutableSortedDictionaryTypeName = "System.Collections.Immutable.ImmutableSortedDictionary";

		public const string ImmutableSortedDictionaryGenericTypeName = "System.Collections.Immutable.ImmutableSortedDictionary`2";

		public static void RegisterImmutableDictionary(Type immutableCollectionType, Type elementType, JsonSerializerOptions options)
		{
			Type underlyingType;
			string constructingTypeName;
			string delegateKey = DefaultImmutableEnumerableConverter.GetDelegateKey(immutableCollectionType, elementType, out underlyingType, out constructingTypeName);
			if (!options.CreateRangeDelegatesContainsKey(delegateKey))
			{
				Type type = underlyingType.Assembly.GetType(constructingTypeName);
				ImmutableCollectionCreator createRangeDelegate = options.MemberAccessorStrategy.ImmutableDictionaryCreateRange(type, immutableCollectionType, elementType);
				options.TryAddCreateRangeDelegate(delegateKey, createRangeDelegate);
			}
		}

		public static bool IsImmutableDictionary(Type type)
		{
			if (!type.IsGenericType)
			{
				return false;
			}
			switch (type.GetGenericTypeDefinition().FullName)
			{
			case "System.Collections.Immutable.ImmutableDictionary`2":
			case "System.Collections.Immutable.IImmutableDictionary`2":
			case "System.Collections.Immutable.ImmutableSortedDictionary`2":
				return true;
			default:
				return false;
			}
		}

		public override object CreateFromDictionary(ref ReadStack state, IDictionary sourceDictionary, JsonSerializerOptions options)
		{
			Type runtimePropertyType = state.Current.JsonPropertyInfo.RuntimePropertyType;
			Type elementType = state.Current.GetElementType();
			Type underlyingType;
			string constructingTypeName;
			string delegateKey = DefaultImmutableEnumerableConverter.GetDelegateKey(runtimePropertyType, elementType, out underlyingType, out constructingTypeName);
			JsonPropertyInfo jsonPropertyInfoFromClassInfo = options.GetJsonPropertyInfoFromClassInfo(elementType, options);
			return jsonPropertyInfoFromClassInfo.CreateImmutableDictionaryInstance(ref state, runtimePropertyType, delegateKey, sourceDictionary, options);
		}
	}
	[Flags]
	internal enum EnumConverterOptions
	{
		AllowStrings = 1,
		AllowNumbers = 2
	}
	internal sealed class JsonKeyValuePairConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert)
		{
			if (!typeToConvert.IsGenericType)
			{
				return false;
			}
			Type genericTypeDefinition = typeToConvert.GetGenericTypeDefinition();
			return genericTypeDefinition == typeof(KeyValuePair<, >);
		}

		public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
		{
			Type type2 = type.GetGenericArguments()[0];
			Type type3 = type.GetGenericArguments()[1];
			return (JsonConverter)Activator.CreateInstance(typeof(JsonKeyValuePairConverter<, >).MakeGenericType(type2, type3), BindingFlags.Instance | BindingFlags.Public, null, null, null);
		}
	}
	internal sealed class JsonConverterBoolean : JsonConverter<bool>
	{
		public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetBoolean();
		}

		public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
		{
			writer.WriteBooleanValue(value);
		}
	}
	internal sealed class JsonConverterByte : JsonConverter<byte>
	{
		public override byte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetByte();
		}

		public override void Write(Utf8JsonWriter writer, byte value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterByteArray : JsonConverter<byte[]>
	{
		public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetBytesFromBase64();
		}

		public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
		{
			writer.WriteBase64StringValue(value);
		}
	}
	internal sealed class JsonConverterChar : JsonConverter<char>
	{
		public override char Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString()[0];
		}

		public override void Write(Utf8JsonWriter writer, char value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToString());
		}
	}
	internal sealed class JsonConverterDateTime : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetDateTime();
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value);
		}
	}
	internal sealed class JsonConverterDateTimeOffset : JsonConverter<DateTimeOffset>
	{
		public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetDateTimeOffset();
		}

		public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value);
		}
	}
	internal sealed class JsonConverterDecimal : JsonConverter<decimal>
	{
		public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetDecimal();
		}

		public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterDouble : JsonConverter<double>
	{
		public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetDouble();
		}

		public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterEnum : JsonConverterFactory
	{
		public override bool CanConvert(Type type)
		{
			return type.IsEnum;
		}

		public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
		{
			return (JsonConverter)Activator.CreateInstance(typeof(JsonConverterEnum<>).MakeGenericType(type), BindingFlags.Instance | BindingFlags.Public, null, new object[1] { EnumConverterOptions.AllowNumbers }, null);
		}
	}
	internal class JsonConverterEnum<T> : JsonConverter<T> where T : struct, Enum
	{
		private static readonly TypeCode s_enumTypeCode = Type.GetTypeCode(typeof(T));

		private static readonly string s_negativeSign = (((int)s_enumTypeCode % 2 == 0) ? null : NumberFormatInfo.CurrentInfo.NegativeSign);

		private readonly EnumConverterOptions _converterOptions;

		private readonly JsonNamingPolicy _namingPolicy;

		private readonly ConcurrentDictionary<string, string> _nameCache;

		public override bool CanConvert(Type type)
		{
			return type.IsEnum;
		}

		public JsonConverterEnum(EnumConverterOptions options)
			: this(options, (JsonNamingPolicy)null)
		{
		}

		public JsonConverterEnum(EnumConverterOptions options, JsonNamingPolicy namingPolicy)
		{
			_converterOptions = options;
			if (namingPolicy != null)
			{
				_nameCache = new ConcurrentDictionary<string, string>();
			}
			else
			{
				namingPolicy = JsonNamingPolicy.Default;
			}
			_namingPolicy = namingPolicy;
		}

		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
			case JsonTokenType.String:
			{
				if (!_converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
				{
					ThrowHelper.ThrowJsonException();
					return default(T);
				}
				string value9 = reader.GetString();
				if (!Enum.TryParse<T>(value9, out var result) && !Enum.TryParse<T>(value9, ignoreCase: true, out result))
				{
					ThrowHelper.ThrowJsonException();
					return default(T);
				}
				return result;
			}
			case JsonTokenType.Number:
				if (_converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
				{
					switch (s_enumTypeCode)
					{
					case TypeCode.Int32:
					{
						if (reader.TryGetInt32(out var value6))
						{
							return Unsafe.As<int, T>(ref value6);
						}
						break;
					}
					case TypeCode.UInt32:
					{
						if (reader.TryGetUInt32(out var value2))
						{
							return Unsafe.As<uint, T>(ref value2);
						}
						break;
					}
					case TypeCode.UInt64:
					{
						if (reader.TryGetUInt64(out var value5))
						{
							return Unsafe.As<ulong, T>(ref value5);
						}
						break;
					}
					case TypeCode.Int64:
					{
						if (reader.TryGetInt64(out var value8))
						{
							return Unsafe.As<long, T>(ref value8);
						}
						break;
					}
					case TypeCode.SByte:
					{
						if (reader.TryGetInt32(out var value3) && JsonHelpers.IsInRangeInclusive(value3, -128, 127))
						{
							sbyte source2 = (sbyte)value3;
							return Unsafe.As<sbyte, T>(ref source2);
						}
						break;
					}
					case TypeCode.Byte:
					{
						if (reader.TryGetUInt32(out var value7) && JsonHelpers.IsInRangeInclusive(value7, 0u, 255u))
						{
							byte source4 = (byte)value7;
							return Unsafe.As<byte, T>(ref source4);
						}
						break;
					}
					case TypeCode.Int16:
					{
						if (reader.TryGetInt32(out var value4) && JsonHelpers.IsInRangeInclusive(value4, -32768, 32767))
						{
							short source3 = (short)value4;
							return Unsafe.As<short, T>(ref source3);
						}
						break;
					}
					case TypeCode.UInt16:
					{
						if (reader.TryGetUInt32(out var value) && JsonHelpers.IsInRangeInclusive(value, 0u, 65535u))
						{
							ushort source = (ushort)value;
							return Unsafe.As<ushort, T>(ref source);
						}
						break;
					}
					}
					ThrowHelper.ThrowJsonException();
					return default(T);
				}
				goto default;
			default:
				ThrowHelper.ThrowJsonException();
				return default(T);
			}
		}

		private static bool IsValidIdentifier(string value)
		{
			if (value[0] >= 'A')
			{
				if (s_negativeSign != null)
				{
					return !value.StartsWith(s_negativeSign);
				}
				return true;
			}
			return false;
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			if (_converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
			{
				string text = value.ToString();
				if (_nameCache != null && _nameCache.TryGetValue(text, out var value2))
				{
					writer.WriteStringValue(value2);
					return;
				}
				if (IsValidIdentifier(text))
				{
					value2 = _namingPolicy.ConvertName(text);
					writer.WriteStringValue(value2);
					if (_nameCache != null)
					{
						_nameCache.TryAdd(text, value2);
					}
					return;
				}
			}
			if (!_converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
			{
				ThrowHelper.ThrowJsonException();
			}
			switch (s_enumTypeCode)
			{
			case TypeCode.Int32:
				writer.WriteNumberValue(Unsafe.As<T, int>(ref value));
				break;
			case TypeCode.UInt32:
				writer.WriteNumberValue(Unsafe.As<T, uint>(ref value));
				break;
			case TypeCode.UInt64:
				writer.WriteNumberValue(Unsafe.As<T, ulong>(ref value));
				break;
			case TypeCode.Int64:
				writer.WriteNumberValue(Unsafe.As<T, long>(ref value));
				break;
			case TypeCode.Int16:
				writer.WriteNumberValue(Unsafe.As<T, short>(ref value));
				break;
			case TypeCode.UInt16:
				writer.WriteNumberValue(Unsafe.As<T, ushort>(ref value));
				break;
			case TypeCode.Byte:
				writer.WriteNumberValue(Unsafe.As<T, byte>(ref value));
				break;
			case TypeCode.SByte:
				writer.WriteNumberValue(Unsafe.As<T, sbyte>(ref value));
				break;
			default:
				ThrowHelper.ThrowJsonException();
				break;
			}
		}
	}
	internal sealed class JsonConverterGuid : JsonConverter<Guid>
	{
		public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetGuid();
		}

		public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value);
		}
	}
	internal sealed class JsonConverterInt16 : JsonConverter<short>
	{
		public override short Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetInt16();
		}

		public override void Write(Utf8JsonWriter writer, short value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterInt32 : JsonConverter<int>
	{
		public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetInt32();
		}

		public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterInt64 : JsonConverter<long>
	{
		public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetInt64();
		}

		public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterJsonElement : JsonConverter<JsonElement>
	{
		public override JsonElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);
			return jsonDocument.RootElement.Clone();
		}

		public override void Write(Utf8JsonWriter writer, JsonElement value, JsonSerializerOptions options)
		{
			value.WriteTo(writer);
		}
	}
	internal sealed class JsonKeyValuePairConverter<TKey, TValue> : JsonConverter<KeyValuePair<TKey, TValue>>
	{
		private const string KeyName = "Key";

		private const string ValueName = "Value";

		private static readonly JsonEncodedText _keyName = JsonEncodedText.Encode("Key");

		private static readonly JsonEncodedText _valueName = JsonEncodedText.Encode("Value");

		public override KeyValuePair<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
			{
				ThrowHelper.ThrowJsonException();
			}
			TKey key = default(TKey);
			bool flag = false;
			TValue value = default(TValue);
			bool flag2 = false;
			reader.Read();
			if (reader.TokenType != JsonTokenType.PropertyName)
			{
				ThrowHelper.ThrowJsonException();
			}
			string text = reader.GetString();
			if (text == "Key")
			{
				key = ReadProperty<TKey>(ref reader, typeToConvert, options);
				flag = true;
			}
			else if (text == "Value")
			{
				value = ReadProperty<TValue>(ref reader, typeToConvert, options);
				flag2 = true;
			}
			else
			{
				ThrowHelper.ThrowJsonException();
			}
			reader.Read();
			if (reader.TokenType != JsonTokenType.PropertyName)
			{
				ThrowHelper.ThrowJsonException();
			}
			text = reader.GetString();
			if (text == "Value")
			{
				value = ReadProperty<TValue>(ref reader, typeToConvert, options);
				flag2 = true;
			}
			else if (text == "Key")
			{
				key = ReadProperty<TKey>(ref reader, typeToConvert, options);
				flag = true;
			}
			else
			{
				ThrowHelper.ThrowJsonException();
			}
			if (!flag || !flag2)
			{
				ThrowHelper.ThrowJsonException();
			}
			reader.Read();
			if (reader.TokenType != JsonTokenType.EndObject)
			{
				ThrowHelper.ThrowJsonException();
			}
			return new KeyValuePair<TKey, TValue>(key, value);
		}

		private T ReadProperty<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (typeToConvert != typeof(object) && options?.GetConverter(typeToConvert) is JsonConverter<T> jsonConverter)
			{
				reader.Read();
				return jsonConverter.Read(ref reader, typeToConvert, options);
			}
			return JsonSerializer.Deserialize<T>(ref reader, options);
		}

		private void WriteProperty<T>(Utf8JsonWriter writer, T value, JsonEncodedText name, JsonSerializerOptions options)
		{
			Type typeFromHandle = typeof(T);
			writer.WritePropertyName(name);
			if (typeFromHandle != typeof(object) && options?.GetConverter(typeFromHandle) is JsonConverter<T> jsonConverter)
			{
				jsonConverter.Write(writer, value, options);
			}
			else
			{
				JsonSerializer.Serialize(writer, value, options);
			}
		}

		public override void Write(Utf8JsonWriter writer, KeyValuePair<TKey, TValue> value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			WriteProperty(writer, value.Key, _keyName, options);
			WriteProperty(writer, value.Value, _valueName, options);
			writer.WriteEndObject();
		}
	}
	internal sealed class JsonConverterObject : JsonConverter<object>
	{
		public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);
			return jsonDocument.RootElement.Clone();
		}

		public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
		{
			throw new InvalidOperationException();
		}
	}
	internal sealed class JsonConverterSByte : JsonConverter<sbyte>
	{
		public override sbyte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetSByte();
		}

		public override void Write(Utf8JsonWriter writer, sbyte value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterSingle : JsonConverter<float>
	{
		public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetSingle();
		}

		public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterString : JsonConverter<string>
	{
		public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString();
		}

		public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value);
		}
	}
	internal sealed class JsonConverterUInt16 : JsonConverter<ushort>
	{
		public override ushort Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetUInt16();
		}

		public override void Write(Utf8JsonWriter writer, ushort value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterUInt32 : JsonConverter<uint>
	{
		public override uint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetUInt32();
		}

		public override void Write(Utf8JsonWriter writer, uint value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterUInt64 : JsonConverter<ulong>
	{
		public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetUInt64();
		}

		public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}
	internal sealed class JsonConverterUri : JsonConverter<Uri>
	{
		public override Uri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string uriString = reader.GetString();
			if (Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out var result))
			{
				return result;
			}
			ThrowHelper.ThrowJsonException();
			return null;
		}

		public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.OriginalString);
		}
	}
	internal abstract class JsonDictionaryConverter
	{
		public abstract object CreateFromDictionary(ref ReadStack state, IDictionary sourceDictionary, JsonSerializerOptions options);
	}
	internal abstract class JsonEnumerableConverter
	{
		public abstract IEnumerable CreateFromList(ref ReadStack state, IList sourceList, JsonSerializerOptions options);
	}
}
