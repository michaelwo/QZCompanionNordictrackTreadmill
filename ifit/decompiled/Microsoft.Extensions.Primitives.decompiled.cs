using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Internal;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "8ddc5722596937430ddb6b2aec2fcea06723d5a7")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Primitives shared by framework extensions. Commonly used types include:\nMicrosoft.Extensions.Primitives.IChangeToken\nMicrosoft.Extensions.Primitives.StringValues\nMicrosoft.Extensions.Primitives.StringSegment")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Primitives")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.1.0.0")]
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
}
namespace Microsoft.Extensions.Internal
{
	internal struct HashCodeCombiner
	{
		private long _combinedHash64;

		public int CombinedHash
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _combinedHash64.GetHashCode();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private HashCodeCombiner(long seed)
		{
			_combinedHash64 = seed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(IEnumerable e)
		{
			if (e == null)
			{
				Add(0);
				return;
			}
			int num = 0;
			foreach (object item in e)
			{
				Add(item);
				num++;
			}
			Add(num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int(HashCodeCombiner self)
		{
			return self.CombinedHash;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(int i)
		{
			_combinedHash64 = ((_combinedHash64 << 5) + _combinedHash64) ^ i;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(string s)
		{
			int i = s?.GetHashCode() ?? 0;
			Add(i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(object o)
		{
			int i = o?.GetHashCode() ?? 0;
			Add(i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add<TValue>(TValue value, IEqualityComparer<TValue> comparer)
		{
			int i = ((value != null) ? comparer.GetHashCode(value) : 0);
			Add(i);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static HashCodeCombiner Start()
		{
			return new HashCodeCombiner(5381L);
		}
	}
}
namespace Microsoft.Extensions.Primitives
{
	public class CancellationChangeToken : IChangeToken
	{
		private class NullDisposable : IDisposable
		{
			public static readonly NullDisposable Instance = new NullDisposable();

			public void Dispose()
			{
			}
		}

		public bool ActiveChangeCallbacks { get; private set; } = true;

		public bool HasChanged => Token.IsCancellationRequested;

		private CancellationToken Token { get; }

		public CancellationChangeToken(CancellationToken cancellationToken)
		{
			Token = cancellationToken;
		}

		public IDisposable RegisterChangeCallback(Action<object> callback, object state)
		{
			try
			{
				return Token.Register(callback, state);
			}
			catch (ObjectDisposedException)
			{
				ActiveChangeCallbacks = false;
			}
			return NullDisposable.Instance;
		}
	}
	public static class ChangeToken
	{
		public static IDisposable OnChange(Func<IChangeToken> changeTokenProducer, Action changeTokenConsumer)
		{
			if (changeTokenProducer == null)
			{
				throw new ArgumentNullException("changeTokenProducer");
			}
			if (changeTokenConsumer == null)
			{
				throw new ArgumentNullException("changeTokenConsumer");
			}
			Action<object> callback = null;
			callback = delegate
			{
				IChangeToken changeToken = changeTokenProducer();
				try
				{
					changeTokenConsumer();
				}
				finally
				{
					changeToken.RegisterChangeCallback(callback, null);
				}
			};
			return changeTokenProducer().RegisterChangeCallback(callback, null);
		}

		public static IDisposable OnChange<TState>(Func<IChangeToken> changeTokenProducer, Action<TState> changeTokenConsumer, TState state)
		{
			if (changeTokenProducer == null)
			{
				throw new ArgumentNullException("changeTokenProducer");
			}
			if (changeTokenConsumer == null)
			{
				throw new ArgumentNullException("changeTokenConsumer");
			}
			Action<object> callback = null;
			callback = delegate(object s)
			{
				IChangeToken changeToken = changeTokenProducer();
				try
				{
					changeTokenConsumer((TState)s);
				}
				finally
				{
					changeToken.RegisterChangeCallback(callback, s);
				}
			};
			return changeTokenProducer().RegisterChangeCallback(callback, state);
		}
	}
	public class CompositeChangeToken : IChangeToken
	{
		private static readonly Action<object> _onChangeDelegate = OnChange;

		private readonly object _callbackLock = new object();

		private CancellationTokenSource _cancellationTokenSource;

		private bool _registeredCallbackProxy;

		private List<IDisposable> _disposables;

		public IReadOnlyList<IChangeToken> ChangeTokens { get; }

		public bool HasChanged
		{
			get
			{
				if (_cancellationTokenSource != null && _cancellationTokenSource.Token.IsCancellationRequested)
				{
					return true;
				}
				for (int i = 0; i < ChangeTokens.Count; i++)
				{
					if (ChangeTokens[i].HasChanged)
					{
						OnChange(this);
						return true;
					}
				}
				return false;
			}
		}

		public bool ActiveChangeCallbacks { get; }

		public CompositeChangeToken(IReadOnlyList<IChangeToken> changeTokens)
		{
			ChangeTokens = changeTokens ?? throw new ArgumentNullException("changeTokens");
			for (int i = 0; i < ChangeTokens.Count; i++)
			{
				if (ChangeTokens[i].ActiveChangeCallbacks)
				{
					ActiveChangeCallbacks = true;
					break;
				}
			}
		}

		public IDisposable RegisterChangeCallback(Action<object> callback, object state)
		{
			EnsureCallbacksInitialized();
			return _cancellationTokenSource.Token.Register(callback, state);
		}

		private void EnsureCallbacksInitialized()
		{
			if (_registeredCallbackProxy)
			{
				return;
			}
			lock (_callbackLock)
			{
				if (_registeredCallbackProxy)
				{
					return;
				}
				_cancellationTokenSource = new CancellationTokenSource();
				_disposables = new List<IDisposable>();
				for (int i = 0; i < ChangeTokens.Count; i++)
				{
					if (ChangeTokens[i].ActiveChangeCallbacks)
					{
						IDisposable item = ChangeTokens[i].RegisterChangeCallback(_onChangeDelegate, this);
						_disposables.Add(item);
					}
				}
				_registeredCallbackProxy = true;
			}
		}

		private static void OnChange(object state)
		{
			CompositeChangeToken compositeChangeToken = (CompositeChangeToken)state;
			if (compositeChangeToken._cancellationTokenSource == null)
			{
				return;
			}
			lock (compositeChangeToken._callbackLock)
			{
				try
				{
					compositeChangeToken._cancellationTokenSource.Cancel();
				}
				catch
				{
				}
			}
			List<IDisposable> disposables = compositeChangeToken._disposables;
			for (int i = 0; i < disposables.Count; i++)
			{
				disposables[i].Dispose();
			}
		}
	}
	public static class Extensions
	{
		public static StringBuilder Append(this StringBuilder builder, StringSegment segment)
		{
			return builder.Append(segment.Buffer, segment.Offset, segment.Length);
		}
	}
	public interface IChangeToken
	{
		bool HasChanged { get; }

		bool ActiveChangeCallbacks { get; }

		IDisposable RegisterChangeCallback(Action<object> callback, object state);
	}
	[DebuggerDisplay("Value = {_value}")]
	public struct InplaceStringBuilder
	{
		private int _offset;

		private int _capacity;

		private string _value;

		public int Capacity
		{
			get
			{
				return _capacity;
			}
			set
			{
				if (value < 0)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value);
				}
				if (_offset > 0)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.Capacity_CannotChangeAfterWriteStarted);
				}
				_capacity = value;
			}
		}

		public InplaceStringBuilder(int capacity)
		{
			this = default(InplaceStringBuilder);
			if (capacity < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
			}
			_capacity = capacity;
		}

		public void Append(string value)
		{
			if (value == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
			}
			Append(value, 0, value.Length);
		}

		public void Append(StringSegment segment)
		{
			Append(segment.Buffer, segment.Offset, segment.Length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Append(string value, int offset, int count)
		{
			EnsureValueIsInitialized();
			if (value == null || offset < 0 || value.Length - offset < count || Capacity - _offset < count)
			{
				ThrowValidationError(value, offset, count);
			}
			fixed (char* value2 = _value)
			{
				fixed (char* ptr = value)
				{
					Unsafe.CopyBlockUnaligned(value2 + _offset, ptr + offset, (uint)(count * 2));
					_offset += count;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Append(char c)
		{
			EnsureValueIsInitialized();
			if (_offset >= Capacity)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.Capacity_NotEnough, 1, Capacity - _offset);
			}
			fixed (char* value = _value)
			{
				value[_offset++] = c;
			}
		}

		public override string ToString()
		{
			if (Capacity != _offset)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.Capacity_NotUsedEntirely, Capacity, _offset);
			}
			return _value;
		}

		private void EnsureValueIsInitialized()
		{
			if (_value == null)
			{
				_value = new string('\0', _capacity);
			}
		}

		private void ThrowValidationError(string value, int offset, int count)
		{
			if (value == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
			}
			if (offset < 0 || value.Length - offset < count)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (Capacity - _offset < count)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.Capacity_NotEnough, value.Length, Capacity - _offset);
			}
		}
	}
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("Microsoft.Extensions.Primitives.Resources", typeof(Resources).GetTypeInfo().Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static string Argument_InvalidOffsetLength => ResourceManager.GetString("Argument_InvalidOffsetLength", resourceCulture);

		internal static string Capacity_CannotChangeAfterWriteStarted => ResourceManager.GetString("Capacity_CannotChangeAfterWriteStarted", resourceCulture);

		internal Resources()
		{
		}
	}
	public readonly struct StringSegment : IEquatable<StringSegment>, IEquatable<string>
	{
		public static readonly StringSegment Empty;

		public string Buffer { get; }

		public int Offset { get; }

		public int Length { get; }

		public string Value
		{
			get
			{
				if (!HasValue)
				{
					return null;
				}
				return Buffer.Substring(Offset, Length);
			}
		}

		public bool HasValue => Buffer != null;

		public char this[int index]
		{
			get
			{
				if ((uint)index >= (uint)Length)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
				}
				return Buffer[Offset + index];
			}
		}

		public StringSegment(string buffer)
		{
			Buffer = buffer;
			Offset = 0;
			Length = buffer?.Length ?? 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public StringSegment(string buffer, int offset, int length)
		{
			if (buffer == null || (uint)offset > (uint)buffer.Length || (uint)length > (uint)(buffer.Length - offset))
			{
				ThrowInvalidArguments(buffer, offset, length);
			}
			Buffer = buffer;
			Offset = offset;
			Length = length;
		}

		private static void ThrowInvalidArguments(string buffer, int offset, int length)
		{
			throw GetInvalidArgumentException(buffer, offset, length);
		}

		private static Exception GetInvalidArgumentException(string buffer, int offset, int length)
		{
			if (buffer == null)
			{
				return ThrowHelper.GetArgumentNullException(ExceptionArgument.buffer);
			}
			if (offset < 0)
			{
				return ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (length < 0)
			{
				return ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.length);
			}
			return ThrowHelper.GetArgumentException(ExceptionResource.Argument_InvalidOffsetLength);
		}

		public ReadOnlySpan<char> AsSpan()
		{
			return MemoryExtensions.AsSpan(Buffer, Offset, Length);
		}

		public ReadOnlyMemory<char> AsMemory()
		{
			return MemoryExtensions.AsMemory(Buffer, Offset, Length);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is StringSegment other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(StringSegment other)
		{
			return Equals(other, StringComparison.Ordinal);
		}

		public bool Equals(StringSegment other, StringComparison comparisonType)
		{
			int length = other.Length;
			if (Length != length)
			{
				return false;
			}
			return string.Compare(Buffer, Offset, other.Buffer, other.Offset, length, comparisonType) == 0;
		}

		public static bool Equals(StringSegment a, StringSegment b, StringComparison comparisonType)
		{
			return a.Equals(b, comparisonType);
		}

		public bool Equals(string text)
		{
			return Equals(text, StringComparison.Ordinal);
		}

		public bool Equals(string text, StringComparison comparisonType)
		{
			if (text == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.text);
			}
			int length = text.Length;
			if (!HasValue || Length != length)
			{
				return false;
			}
			return string.Compare(Buffer, Offset, text, 0, length, comparisonType) == 0;
		}

		public override int GetHashCode()
		{
			if (!HasValue)
			{
				return 0;
			}
			return Value.GetHashCode();
		}

		public static bool operator ==(StringSegment left, StringSegment right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(StringSegment left, StringSegment right)
		{
			return !left.Equals(right);
		}

		public static implicit operator StringSegment(string value)
		{
			return new StringSegment(value);
		}

		public static implicit operator ReadOnlySpan<char>(StringSegment segment)
		{
			return segment.AsSpan();
		}

		public static implicit operator ReadOnlyMemory<char>(StringSegment segment)
		{
			return segment.AsMemory();
		}

		public bool StartsWith(string text, StringComparison comparisonType)
		{
			if (text == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.text);
			}
			int length = text.Length;
			if (!HasValue || Length < length)
			{
				return false;
			}
			return string.Compare(Buffer, Offset, text, 0, length, comparisonType) == 0;
		}

		public bool EndsWith(string text, StringComparison comparisonType)
		{
			if (text == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.text);
			}
			int length = text.Length;
			if (!HasValue || Length < length)
			{
				return false;
			}
			return string.Compare(Buffer, Offset + Length - length, text, 0, length, comparisonType) == 0;
		}

		public string Substring(int offset)
		{
			return Substring(offset, Length - offset);
		}

		public string Substring(int offset, int length)
		{
			if (!HasValue)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (offset < 0 || offset + length > Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (length < 0 || Offset + offset + length > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);
			}
			return Buffer.Substring(Offset + offset, length);
		}

		public StringSegment Subsegment(int offset)
		{
			return Subsegment(offset, Length - offset);
		}

		public StringSegment Subsegment(int offset, int length)
		{
			if (!HasValue)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (offset < 0 || offset + length > Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.offset);
			}
			if (length < 0 || Offset + offset + length > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);
			}
			return new StringSegment(Buffer, Offset + offset, length);
		}

		public int IndexOf(char c, int start, int count)
		{
			if (start < 0 || Offset + start > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
			}
			if (count < 0 || Offset + start + count > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
			}
			int num = Buffer.IndexOf(c, start + Offset, count);
			if (num != -1)
			{
				return num - Offset;
			}
			return num;
		}

		public int IndexOf(char c, int start)
		{
			return IndexOf(c, start, Length - start);
		}

		public int IndexOf(char c)
		{
			return IndexOf(c, 0, Length);
		}

		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			if (!HasValue)
			{
				return -1;
			}
			if (startIndex < 0 || Offset + startIndex > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
			}
			if (count < 0 || Offset + startIndex + count > Buffer.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
			}
			int num = Buffer.IndexOfAny(anyOf, Offset + startIndex, count);
			if (num == -1)
			{
				return num;
			}
			return num - Offset;
		}

		public int IndexOfAny(char[] anyOf, int startIndex)
		{
			return IndexOfAny(anyOf, startIndex, Length - startIndex);
		}

		public int IndexOfAny(char[] anyOf)
		{
			return IndexOfAny(anyOf, 0, Length);
		}

		public int LastIndexOf(char value)
		{
			if (!HasValue)
			{
				return -1;
			}
			int num = Buffer.LastIndexOf(value, Offset + Length - 1, Length);
			if (num == -1)
			{
				return -1;
			}
			return num - Offset;
		}

		public StringSegment Trim()
		{
			return TrimStart().TrimEnd();
		}

		public StringSegment TrimStart()
		{
			int i;
			for (i = Offset; i < Offset + Length && char.IsWhiteSpace(Buffer, i); i++)
			{
			}
			return new StringSegment(Buffer, i, Offset + Length - i);
		}

		public StringSegment TrimEnd()
		{
			int num = Offset + Length - 1;
			while (num >= Offset && char.IsWhiteSpace(Buffer, num))
			{
				num--;
			}
			return new StringSegment(Buffer, Offset, num - Offset + 1);
		}

		public StringTokenizer Split(char[] chars)
		{
			return new StringTokenizer(this, chars);
		}

		public static bool IsNullOrEmpty(StringSegment value)
		{
			if (value.HasValue)
			{
				return value.Length == 0;
			}
			return true;
		}

		public override string ToString()
		{
			return Value ?? string.Empty;
		}

		static StringSegment()
		{
			Empty = string.Empty;
		}
	}
	public class StringSegmentComparer : IEqualityComparer<StringSegment>
	{
		public static StringSegmentComparer Ordinal { get; } = new StringSegmentComparer(StringComparison.Ordinal, StringComparer.Ordinal);

		public static StringSegmentComparer OrdinalIgnoreCase { get; } = new StringSegmentComparer(StringComparison.OrdinalIgnoreCase, StringComparer.OrdinalIgnoreCase);

		private StringComparison Comparison { get; }

		private StringComparer Comparer { get; }

		private StringSegmentComparer(StringComparison comparison, StringComparer comparer)
		{
			Comparison = comparison;
			Comparer = comparer;
		}

		public bool Equals(StringSegment x, StringSegment y)
		{
			return StringSegment.Equals(x, y, Comparison);
		}

		public int GetHashCode(StringSegment obj)
		{
			return Comparer.GetHashCode(obj.Value);
		}
	}
	public readonly struct StringTokenizer : IEnumerable<StringSegment>, IEnumerable
	{
		public struct Enumerator : IEnumerator<StringSegment>, IEnumerator, IDisposable
		{
			private readonly StringSegment _value;

			private readonly char[] _separators;

			private int _index;

			public StringSegment Current { get; private set; }

			object IEnumerator.Current => Current;

			internal Enumerator(in StringSegment value, char[] separators)
			{
				_value = value;
				_separators = separators;
				Current = default(StringSegment);
				_index = 0;
			}

			public Enumerator(ref StringTokenizer tokenizer)
			{
				_value = tokenizer._value;
				_separators = tokenizer._separators;
				Current = default(StringSegment);
				_index = 0;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (!_value.HasValue || _index > _value.Length)
				{
					Current = default(StringSegment);
					return false;
				}
				int num = _value.IndexOfAny(_separators, _index);
				if (num == -1)
				{
					num = _value.Length;
				}
				Current = _value.Subsegment(_index, num - _index);
				_index = num + 1;
				return true;
			}

			public void Reset()
			{
				Current = default(StringSegment);
				_index = 0;
			}
		}

		private readonly StringSegment _value;

		private readonly char[] _separators;

		public StringTokenizer(string value, char[] separators)
		{
			if (value == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
			}
			if (separators == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.separators);
			}
			_value = value;
			_separators = separators;
		}

		public StringTokenizer(StringSegment value, char[] separators)
		{
			if (!value.HasValue)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
			}
			if (separators == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.separators);
			}
			_value = value;
			_separators = separators;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(in _value, _separators);
		}

		IEnumerator<StringSegment> IEnumerable<StringSegment>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	public readonly struct StringValues : IList<string>, ICollection<string>, IEnumerable<string>, IEnumerable, IReadOnlyList<string>, IReadOnlyCollection<string>, IEquatable<StringValues>, IEquatable<string>, IEquatable<string[]>
	{
		public struct Enumerator : IEnumerator<string>, IEnumerator, IDisposable
		{
			private readonly string[] _values;

			private string _current;

			private int _index;

			public string Current => _current;

			object IEnumerator.Current => _current;

			internal Enumerator(string[] values, string value)
			{
				_values = values;
				_current = value;
				_index = 0;
			}

			public Enumerator(ref StringValues values)
			{
				_values = values._values;
				_current = values._value;
				_index = 0;
			}

			public bool MoveNext()
			{
				if (_index < 0)
				{
					return false;
				}
				if (_values != null)
				{
					if (_index < _values.Length)
					{
						_current = _values[_index];
						_index++;
						return true;
					}
					_index = -1;
					return false;
				}
				_index = -1;
				return _current != null;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			public void Dispose()
			{
			}
		}

		private static readonly string[] EmptyArray;

		public static readonly StringValues Empty;

		private readonly string _value;

		private readonly string[] _values;

		public int Count
		{
			get
			{
				if (_value == null)
				{
					string[] values = _values;
					if (values == null)
					{
						return 0;
					}
					return values.Length;
				}
				return 1;
			}
		}

		bool ICollection<string>.IsReadOnly => true;

		string IList<string>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public string this[int index]
		{
			get
			{
				if (_values != null)
				{
					return _values[index];
				}
				if (index == 0 && _value != null)
				{
					return _value;
				}
				return EmptyArray[0];
			}
		}

		public StringValues(string value)
		{
			_value = value;
			_values = null;
		}

		public StringValues(string[] values)
		{
			_value = null;
			_values = values;
		}

		public static implicit operator StringValues(string value)
		{
			return new StringValues(value);
		}

		public static implicit operator StringValues(string[] values)
		{
			return new StringValues(values);
		}

		public static implicit operator string(StringValues values)
		{
			return values.GetStringValue();
		}

		public static implicit operator string[](StringValues value)
		{
			return value.GetArrayValue();
		}

		public override string ToString()
		{
			return GetStringValue() ?? string.Empty;
		}

		private string GetStringValue()
		{
			if (_values == null)
			{
				return _value;
			}
			return _values.Length switch
			{
				0 => null, 
				1 => _values[0], 
				_ => string.Join(",", _values), 
			};
		}

		public string[] ToArray()
		{
			return GetArrayValue() ?? EmptyArray;
		}

		private string[] GetArrayValue()
		{
			if (_value != null)
			{
				return new string[1] { _value };
			}
			return _values;
		}

		int IList<string>.IndexOf(string item)
		{
			return IndexOf(item);
		}

		private int IndexOf(string item)
		{
			if (_values != null)
			{
				string[] values = _values;
				for (int i = 0; i < values.Length; i++)
				{
					if (string.Equals(values[i], item, StringComparison.Ordinal))
					{
						return i;
					}
				}
				return -1;
			}
			if (_value != null)
			{
				if (!string.Equals(_value, item, StringComparison.Ordinal))
				{
					return -1;
				}
				return 0;
			}
			return -1;
		}

		bool ICollection<string>.Contains(string item)
		{
			return IndexOf(item) >= 0;
		}

		void ICollection<string>.CopyTo(string[] array, int arrayIndex)
		{
			CopyTo(array, arrayIndex);
		}

		private void CopyTo(string[] array, int arrayIndex)
		{
			if (_values != null)
			{
				Array.Copy(_values, 0, array, arrayIndex, _values.Length);
			}
			else if (_value != null)
			{
				if (array == null)
				{
					throw new ArgumentNullException("array");
				}
				if (arrayIndex < 0)
				{
					throw new ArgumentOutOfRangeException("arrayIndex");
				}
				if (array.Length - arrayIndex < 1)
				{
					throw new ArgumentException(string.Format("'{0}' is not long enough to copy all the items in the collection. Check '{1}' and '{2}' length.", "array", "arrayIndex", "array"));
				}
				array[arrayIndex] = _value;
			}
		}

		void ICollection<string>.Add(string item)
		{
			throw new NotSupportedException();
		}

		void IList<string>.Insert(int index, string item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<string>.Remove(string item)
		{
			throw new NotSupportedException();
		}

		void IList<string>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<string>.Clear()
		{
			throw new NotSupportedException();
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_values, _value);
		}

		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static bool IsNullOrEmpty(StringValues value)
		{
			if (value._values == null)
			{
				return string.IsNullOrEmpty(value._value);
			}
			return value._values.Length switch
			{
				0 => true, 
				1 => string.IsNullOrEmpty(value._values[0]), 
				_ => false, 
			};
		}

		public static StringValues Concat(StringValues values1, StringValues values2)
		{
			int count = values1.Count;
			int count2 = values2.Count;
			if (count == 0)
			{
				return values2;
			}
			if (count2 == 0)
			{
				return values1;
			}
			string[] array = new string[count + count2];
			values1.CopyTo(array, 0);
			values2.CopyTo(array, count);
			return new StringValues(array);
		}

		public static StringValues Concat(in StringValues values, string value)
		{
			if (value == null)
			{
				return values;
			}
			int count = values.Count;
			if (count == 0)
			{
				return new StringValues(value);
			}
			string[] array = new string[count + 1];
			values.CopyTo(array, 0);
			array[count] = value;
			return new StringValues(array);
		}

		public static StringValues Concat(string value, in StringValues values)
		{
			if (value == null)
			{
				return values;
			}
			int count = values.Count;
			if (count == 0)
			{
				return new StringValues(value);
			}
			string[] array = new string[count + 1];
			array[0] = value;
			values.CopyTo(array, 1);
			return new StringValues(array);
		}

		public static bool Equals(StringValues left, StringValues right)
		{
			int count = left.Count;
			if (count != right.Count)
			{
				return false;
			}
			for (int i = 0; i < count; i++)
			{
				if (left[i] != right[i])
				{
					return false;
				}
			}
			return true;
		}

		public static bool operator ==(StringValues left, StringValues right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(StringValues left, StringValues right)
		{
			return !Equals(left, right);
		}

		public bool Equals(StringValues other)
		{
			return Equals(this, other);
		}

		public static bool Equals(string left, StringValues right)
		{
			return Equals(new StringValues(left), right);
		}

		public static bool Equals(StringValues left, string right)
		{
			return Equals(left, new StringValues(right));
		}

		public bool Equals(string other)
		{
			return Equals(this, new StringValues(other));
		}

		public static bool Equals(string[] left, StringValues right)
		{
			return Equals(new StringValues(left), right);
		}

		public static bool Equals(StringValues left, string[] right)
		{
			return Equals(left, new StringValues(right));
		}

		public bool Equals(string[] other)
		{
			return Equals(this, new StringValues(other));
		}

		public static bool operator ==(StringValues left, string right)
		{
			return Equals(left, new StringValues(right));
		}

		public static bool operator !=(StringValues left, string right)
		{
			return !Equals(left, new StringValues(right));
		}

		public static bool operator ==(string left, StringValues right)
		{
			return Equals(new StringValues(left), right);
		}

		public static bool operator !=(string left, StringValues right)
		{
			return !Equals(new StringValues(left), right);
		}

		public static bool operator ==(StringValues left, string[] right)
		{
			return Equals(left, new StringValues(right));
		}

		public static bool operator !=(StringValues left, string[] right)
		{
			return !Equals(left, new StringValues(right));
		}

		public static bool operator ==(string[] left, StringValues right)
		{
			return Equals(new StringValues(left), right);
		}

		public static bool operator !=(string[] left, StringValues right)
		{
			return !Equals(new StringValues(left), right);
		}

		public static bool operator ==(StringValues left, object right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(StringValues left, object right)
		{
			return !left.Equals(right);
		}

		public static bool operator ==(object left, StringValues right)
		{
			return right.Equals(left);
		}

		public static bool operator !=(object left, StringValues right)
		{
			return !right.Equals(left);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return Equals(this, Empty);
			}
			if (obj is string)
			{
				return Equals(this, (string)obj);
			}
			if (obj is string[])
			{
				return Equals(this, (string[])obj);
			}
			if (obj is StringValues)
			{
				return Equals(this, (StringValues)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (_values == null)
			{
				if (_value != null)
				{
					return _value.GetHashCode();
				}
				return 0;
			}
			HashCodeCombiner hashCodeCombiner = default(HashCodeCombiner);
			for (int i = 0; i < _values.Length; i++)
			{
				hashCodeCombiner.Add(_values[i]);
			}
			return hashCodeCombiner.CombinedHash;
		}

		static StringValues()
		{
			EmptyArray = new string[0];
			Empty = new StringValues(EmptyArray);
		}
	}
	internal static class ThrowHelper
	{
		internal static void ThrowArgumentNullException(ExceptionArgument argument)
		{
			throw new ArgumentNullException(GetArgumentName(argument));
		}

		internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
		{
			throw new ArgumentOutOfRangeException(GetArgumentName(argument));
		}

		internal static void ThrowArgumentException(ExceptionResource resource)
		{
			throw new ArgumentException(GetResourceText(resource));
		}

		internal static void ThrowInvalidOperationException(ExceptionResource resource)
		{
			throw new InvalidOperationException(GetResourceText(resource));
		}

		internal static void ThrowInvalidOperationException(ExceptionResource resource, params object[] args)
		{
			throw new InvalidOperationException(string.Format(GetResourceText(resource), args));
		}

		internal static ArgumentNullException GetArgumentNullException(ExceptionArgument argument)
		{
			return new ArgumentNullException(GetArgumentName(argument));
		}

		internal static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument)
		{
			return new ArgumentOutOfRangeException(GetArgumentName(argument));
		}

		internal static ArgumentException GetArgumentException(ExceptionResource resource)
		{
			return new ArgumentException(GetResourceText(resource));
		}

		private static string GetResourceText(ExceptionResource resource)
		{
			return Resources.ResourceManager.GetString(GetResourceName(resource), Resources.Culture);
		}

		private static string GetArgumentName(ExceptionArgument argument)
		{
			return argument.ToString();
		}

		private static string GetResourceName(ExceptionResource resource)
		{
			return resource.ToString();
		}
	}
	internal enum ExceptionArgument
	{
		buffer,
		offset,
		length,
		text,
		start,
		count,
		index,
		value,
		capacity,
		separators
	}
	internal enum ExceptionResource
	{
		Argument_InvalidOffsetLength,
		Capacity_CannotChangeAfterWriteStarted,
		Capacity_NotEnough,
		Capacity_NotUsedEntirely
	}
}
