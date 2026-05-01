using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using Microsoft.Extensions.Logging.Internal;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.Logging.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "6dffd8b4f6b6e2204224ae586cbea19375a7d206")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Logging abstractions for Microsoft.Extensions.Logging.\nCommonly used types:\nMicrosoft.Extensions.Logging.ILogger\nMicrosoft.Extensions.Logging.ILoggerFactory\nMicrosoft.Extensions.Logging.ILogger<TCategoryName>\nMicrosoft.Extensions.Logging.LogLevel\nMicrosoft.Extensions.Logging.Logger<T>\nMicrosoft.Extensions.Logging.LoggerMessage\nMicrosoft.Extensions.Logging.Abstractions.NullLogger")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Logging.Abstractions")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.Logging
{
	public struct EventId
	{
		public int Id { get; }

		public string Name { get; }

		public static implicit operator EventId(int i)
		{
			return new EventId(i);
		}

		public static bool operator ==(EventId left, EventId right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EventId left, EventId right)
		{
			return !left.Equals(right);
		}

		public EventId(int id, string name = null)
		{
			Id = id;
			Name = name;
		}

		public override string ToString()
		{
			return Name ?? Id.ToString();
		}

		public bool Equals(EventId other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is EventId other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}
	public interface IExternalScopeProvider
	{
		void ForEachScope<TState>(Action<object, TState> callback, TState state);

		IDisposable Push(object state);
	}
	public interface ILogger
	{
		void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);

		bool IsEnabled(LogLevel logLevel);

		IDisposable BeginScope<TState>(TState state);
	}
	public interface ILoggerFactory : IDisposable
	{
		ILogger CreateLogger(string categoryName);

		void AddProvider(ILoggerProvider provider);
	}
	public interface ILogger<out TCategoryName> : ILogger
	{
	}
	public interface ILoggerProvider : IDisposable
	{
		ILogger CreateLogger(string categoryName);
	}
	public interface ISupportExternalScope
	{
		void SetScopeProvider(IExternalScopeProvider scopeProvider);
	}
	public static class LoggerExtensions
	{
		private static readonly Func<object, Exception, string> _messageFormatter = MessageFormatter;

		public static void LogDebug(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Debug, eventId, exception, message, args);
		}

		public static void LogDebug(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Debug, eventId, message, args);
		}

		public static void LogDebug(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Debug, exception, message, args);
		}

		public static void LogDebug(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Debug, message, args);
		}

		public static void LogTrace(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Trace, eventId, exception, message, args);
		}

		public static void LogTrace(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Trace, eventId, message, args);
		}

		public static void LogTrace(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Trace, exception, message, args);
		}

		public static void LogTrace(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Trace, message, args);
		}

		public static void LogInformation(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Information, eventId, exception, message, args);
		}

		public static void LogInformation(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Information, eventId, message, args);
		}

		public static void LogInformation(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Information, exception, message, args);
		}

		public static void LogInformation(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Information, message, args);
		}

		public static void LogWarning(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Warning, eventId, exception, message, args);
		}

		public static void LogWarning(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Warning, eventId, message, args);
		}

		public static void LogWarning(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Warning, exception, message, args);
		}

		public static void LogWarning(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Warning, message, args);
		}

		public static void LogError(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Error, eventId, exception, message, args);
		}

		public static void LogError(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Error, eventId, message, args);
		}

		public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Error, exception, message, args);
		}

		public static void LogError(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Error, message, args);
		}

		public static void LogCritical(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Critical, eventId, exception, message, args);
		}

		public static void LogCritical(this ILogger logger, EventId eventId, string message, params object[] args)
		{
			logger.Log(LogLevel.Critical, eventId, message, args);
		}

		public static void LogCritical(this ILogger logger, Exception exception, string message, params object[] args)
		{
			logger.Log(LogLevel.Critical, exception, message, args);
		}

		public static void LogCritical(this ILogger logger, string message, params object[] args)
		{
			logger.Log(LogLevel.Critical, message, args);
		}

		public static void Log(this ILogger logger, LogLevel logLevel, string message, params object[] args)
		{
			logger.Log(logLevel, 0, null, message, args);
		}

		public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, string message, params object[] args)
		{
			logger.Log(logLevel, eventId, null, message, args);
		}

		public static void Log(this ILogger logger, LogLevel logLevel, Exception exception, string message, params object[] args)
		{
			logger.Log(logLevel, 0, exception, message, args);
		}

		public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			logger.Log(logLevel, eventId, new FormattedLogValues(message, args), exception, _messageFormatter);
		}

		public static IDisposable BeginScope(this ILogger logger, string messageFormat, params object[] args)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			return logger.BeginScope(new FormattedLogValues(messageFormat, args));
		}

		private static string MessageFormatter(object state, Exception error)
		{
			return state.ToString();
		}
	}
	public class LoggerExternalScopeProvider : IExternalScopeProvider
	{
		private class Scope : IDisposable
		{
			private readonly LoggerExternalScopeProvider _provider;

			private bool _isDisposed;

			public Scope Parent { get; }

			public object State { get; }

			internal Scope(LoggerExternalScopeProvider provider, object state, Scope parent)
			{
				_provider = provider;
				State = state;
				Parent = parent;
			}

			public override string ToString()
			{
				return State?.ToString();
			}

			public void Dispose()
			{
				if (!_isDisposed)
				{
					_provider._currentScope.Value = Parent;
					_isDisposed = true;
				}
			}
		}

		private readonly AsyncLocal<Scope> _currentScope = new AsyncLocal<Scope>();

		public void ForEachScope<TState>(Action<object, TState> callback, TState state)
		{
			Report(_currentScope.Value);
			void Report(Scope current)
			{
				if (current != null)
				{
					Report(current.Parent);
					callback(current.State, state);
				}
			}
		}

		public IDisposable Push(object state)
		{
			Scope value = _currentScope.Value;
			Scope scope = new Scope(this, state, value);
			_currentScope.Value = scope;
			return scope;
		}
	}
	public static class LoggerFactoryExtensions
	{
		public static ILogger<T> CreateLogger<T>(this ILoggerFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			return new Logger<T>(factory);
		}

		public static ILogger CreateLogger(this ILoggerFactory factory, Type type)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(type));
		}
	}
	public static class LoggerMessage
	{
		private class LogValues : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues)state)._formatter.Format(((LogValues)state).ToArray());

			private static object[] _valueArray = new object[0];

			private readonly LogValuesFormatter _formatter;

			public KeyValuePair<string, object> this[int index]
			{
				get
				{
					if (index == 0)
					{
						return new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat);
					}
					throw new IndexOutOfRangeException("index");
				}
			}

			public int Count => 1;

			public LogValues(LogValuesFormatter formatter)
			{
				_formatter = formatter;
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				yield return this[0];
			}

			public object[] ToArray()
			{
				return _valueArray;
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0>)state)._formatter.Format(((LogValues<T0>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			private readonly T0 _value0;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public int Count => 2;

			public LogValues(LogValuesFormatter formatter, T0 value0)
			{
				_formatter = formatter;
				_value0 = value0;
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			public object[] ToArray()
			{
				return new object[1] { _value0 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1>)state)._formatter.Format(((LogValues<T0, T1>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			private readonly T0 _value0;

			private readonly T1 _value1;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public int Count => 3;

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			public object[] ToArray()
			{
				return new object[2] { _value0, _value1 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1, T2> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1, T2>)state)._formatter.Format(((LogValues<T0, T1, T2>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			public T0 _value0;

			public T1 _value1;

			public T2 _value2;

			public int Count => 4;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>(_formatter.ValueNames[2], _value2), 
				3 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
				_value2 = value2;
			}

			public object[] ToArray()
			{
				return new object[3] { _value0, _value1, _value2 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1, T2, T3> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1, T2, T3>)state)._formatter.Format(((LogValues<T0, T1, T2, T3>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			public T0 _value0;

			public T1 _value1;

			public T2 _value2;

			public T3 _value3;

			public int Count => 5;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>(_formatter.ValueNames[2], _value2), 
				3 => new KeyValuePair<string, object>(_formatter.ValueNames[3], _value3), 
				4 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2, T3 value3)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
				_value2 = value2;
				_value3 = value3;
			}

			public object[] ToArray()
			{
				return new object[4] { _value0, _value1, _value2, _value3 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1, T2, T3, T4> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1, T2, T3, T4>)state)._formatter.Format(((LogValues<T0, T1, T2, T3, T4>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			public T0 _value0;

			public T1 _value1;

			public T2 _value2;

			public T3 _value3;

			public T4 _value4;

			public int Count => 6;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>(_formatter.ValueNames[2], _value2), 
				3 => new KeyValuePair<string, object>(_formatter.ValueNames[3], _value3), 
				4 => new KeyValuePair<string, object>(_formatter.ValueNames[4], _value4), 
				5 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
				_value2 = value2;
				_value3 = value3;
				_value4 = value4;
			}

			public object[] ToArray()
			{
				return new object[5] { _value0, _value1, _value2, _value3, _value4 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1, T2, T3, T4, T5> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1, T2, T3, T4, T5>)state)._formatter.Format(((LogValues<T0, T1, T2, T3, T4, T5>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			public T0 _value0;

			public T1 _value1;

			public T2 _value2;

			public T3 _value3;

			public T4 _value4;

			public T5 _value5;

			public int Count => 7;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>(_formatter.ValueNames[2], _value2), 
				3 => new KeyValuePair<string, object>(_formatter.ValueNames[3], _value3), 
				4 => new KeyValuePair<string, object>(_formatter.ValueNames[4], _value4), 
				5 => new KeyValuePair<string, object>(_formatter.ValueNames[5], _value5), 
				6 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
				_value2 = value2;
				_value3 = value3;
				_value4 = value4;
				_value5 = value5;
			}

			public object[] ToArray()
			{
				return new object[6] { _value0, _value1, _value2, _value3, _value4, _value5 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class LogValues<T0, T1, T2, T3, T4, T5, T6> : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
		{
			public static Func<object, Exception, string> Callback = (object state, Exception exception) => ((LogValues<T0, T1, T2, T3, T4, T5, T6>)state)._formatter.Format(((LogValues<T0, T1, T2, T3, T4, T5, T6>)state).ToArray());

			private readonly LogValuesFormatter _formatter;

			public T0 _value0;

			public T1 _value1;

			public T2 _value2;

			public T3 _value3;

			public T4 _value4;

			public T5 _value5;

			public T6 _value6;

			public int Count => 8;

			public KeyValuePair<string, object> this[int index] => index switch
			{
				0 => new KeyValuePair<string, object>(_formatter.ValueNames[0], _value0), 
				1 => new KeyValuePair<string, object>(_formatter.ValueNames[1], _value1), 
				2 => new KeyValuePair<string, object>(_formatter.ValueNames[2], _value2), 
				3 => new KeyValuePair<string, object>(_formatter.ValueNames[3], _value3), 
				4 => new KeyValuePair<string, object>(_formatter.ValueNames[4], _value4), 
				5 => new KeyValuePair<string, object>(_formatter.ValueNames[5], _value5), 
				6 => new KeyValuePair<string, object>(_formatter.ValueNames[6], _value6), 
				7 => new KeyValuePair<string, object>("{OriginalFormat}", _formatter.OriginalFormat), 
				_ => throw new IndexOutOfRangeException("index"), 
			};

			public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
			{
				_formatter = formatter;
				_value0 = value0;
				_value1 = value1;
				_value2 = value2;
				_value3 = value3;
				_value4 = value4;
				_value5 = value5;
				_value6 = value6;
			}

			public object[] ToArray()
			{
				return new object[7] { _value0, _value1, _value2, _value3, _value4, _value5, _value6 };
			}

			public override string ToString()
			{
				return _formatter.Format(ToArray());
			}

			public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
			{
				int i = 0;
				while (i < Count)
				{
					yield return this[i];
					int num = i + 1;
					i = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public static Func<ILogger, IDisposable> DefineScope(string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 0);
			LogValues logValues = new LogValues(formatter);
			return (ILogger logger) => logger.BeginScope(logValues);
		}

		public static Func<ILogger, T1, IDisposable> DefineScope<T1>(string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 1);
			return (ILogger logger, T1 arg1) => logger.BeginScope(new LogValues<T1>(formatter, arg1));
		}

		public static Func<ILogger, T1, T2, IDisposable> DefineScope<T1, T2>(string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 2);
			return (ILogger logger, T1 arg1, T2 arg2) => logger.BeginScope(new LogValues<T1, T2>(formatter, arg1, arg2));
		}

		public static Func<ILogger, T1, T2, T3, IDisposable> DefineScope<T1, T2, T3>(string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 3);
			return (ILogger logger, T1 arg1, T2 arg2, T3 arg3) => logger.BeginScope(new LogValues<T1, T2, T3>(formatter, arg1, arg2, arg3));
		}

		public static Action<ILogger, Exception> Define(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 0);
			return delegate(ILogger logger, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues(formatter), exception, LogValues.Callback);
				}
			};
		}

		public static Action<ILogger, T1, Exception> Define<T1>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 1);
			return delegate(ILogger logger, T1 arg1, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1>(formatter, arg1), exception, LogValues<T1>.Callback);
				}
			};
		}

		public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 2);
			return delegate(ILogger logger, T1 arg1, T2 arg2, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1, T2>(formatter, arg1, arg2), exception, LogValues<T1, T2>.Callback);
				}
			};
		}

		public static Action<ILogger, T1, T2, T3, Exception> Define<T1, T2, T3>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 3);
			return delegate(ILogger logger, T1 arg1, T2 arg2, T3 arg3, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1, T2, T3>(formatter, arg1, arg2, arg3), exception, LogValues<T1, T2, T3>.Callback);
				}
			};
		}

		public static Action<ILogger, T1, T2, T3, T4, Exception> Define<T1, T2, T3, T4>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 4);
			return delegate(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1, T2, T3, T4>(formatter, arg1, arg2, arg3, arg4), exception, LogValues<T1, T2, T3, T4>.Callback);
				}
			};
		}

		public static Action<ILogger, T1, T2, T3, T4, T5, Exception> Define<T1, T2, T3, T4, T5>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 5);
			return delegate(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1, T2, T3, T4, T5>(formatter, arg1, arg2, arg3, arg4, arg5), exception, LogValues<T1, T2, T3, T4, T5>.Callback);
				}
			};
		}

		public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception> Define<T1, T2, T3, T4, T5, T6>(LogLevel logLevel, EventId eventId, string formatString)
		{
			LogValuesFormatter formatter = CreateLogValuesFormatter(formatString, 6);
			return delegate(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Exception exception)
			{
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(logLevel, eventId, new LogValues<T1, T2, T3, T4, T5, T6>(formatter, arg1, arg2, arg3, arg4, arg5, arg6), exception, LogValues<T1, T2, T3, T4, T5, T6>.Callback);
				}
			};
		}

		private static LogValuesFormatter CreateLogValuesFormatter(string formatString, int expectedNamedParameterCount)
		{
			LogValuesFormatter logValuesFormatter = new LogValuesFormatter(formatString);
			int count = logValuesFormatter.ValueNames.Count;
			if (count != expectedNamedParameterCount)
			{
				throw new ArgumentException(Resource.FormatUnexpectedNumberOfNamedParameters(formatString, expectedNamedParameterCount, count));
			}
			return logValuesFormatter;
		}
	}
	public class Logger<T> : ILogger<T>, ILogger
	{
		private readonly ILogger _logger;

		public Logger(ILoggerFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			_logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
		}

		IDisposable ILogger.BeginScope<TState>(TState state)
		{
			return _logger.BeginScope(state);
		}

		bool ILogger.IsEnabled(LogLevel logLevel)
		{
			return _logger.IsEnabled(logLevel);
		}

		void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_logger.Log(logLevel, eventId, state, exception, formatter);
		}
	}
	public enum LogLevel
	{
		Trace,
		Debug,
		Information,
		Warning,
		Error,
		Critical,
		None
	}
}
namespace Microsoft.Extensions.Logging.Abstractions
{
	public class NullLogger : ILogger
	{
		public static NullLogger Instance { get; } = new NullLogger();

		private NullLogger()
		{
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return NullScope.Instance;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return false;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
		}
	}
	public class NullLoggerFactory : ILoggerFactory, IDisposable
	{
		public static readonly NullLoggerFactory Instance = new NullLoggerFactory();

		public ILogger CreateLogger(string name)
		{
			return NullLogger.Instance;
		}

		public void AddProvider(ILoggerProvider provider)
		{
		}

		public void Dispose()
		{
		}
	}
	public class NullLogger<T> : ILogger<T>, ILogger
	{
		private class NullDisposable : IDisposable
		{
			public static readonly NullDisposable Instance = new NullDisposable();

			public void Dispose()
			{
			}
		}

		public static readonly NullLogger<T> Instance = new NullLogger<T>();

		public IDisposable BeginScope<TState>(TState state)
		{
			return NullDisposable.Instance;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return false;
		}
	}
	public class NullLoggerProvider : ILoggerProvider, IDisposable
	{
		public static NullLoggerProvider Instance { get; } = new NullLoggerProvider();

		private NullLoggerProvider()
		{
		}

		public ILogger CreateLogger(string categoryName)
		{
			return NullLogger.Instance;
		}

		public void Dispose()
		{
		}
	}
	internal static class Resource
	{
		private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.Logging.Abstractions.Resource", typeof(Resource).GetTypeInfo().Assembly);

		internal static string UnexpectedNumberOfNamedParameters => GetString("UnexpectedNumberOfNamedParameters");

		internal static string FormatUnexpectedNumberOfNamedParameters(object p0, object p1, object p2)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("UnexpectedNumberOfNamedParameters"), p0, p1, p2);
		}

		private static string GetString(string name, params string[] formatterNames)
		{
			string text = _resourceManager.GetString(name);
			if (formatterNames != null)
			{
				for (int i = 0; i < formatterNames.Length; i++)
				{
					text = text.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
				}
			}
			return text;
		}
	}
}
namespace Microsoft.Extensions.Logging.Abstractions.Internal
{
	public class NullScope : IDisposable
	{
		public static NullScope Instance { get; } = new NullScope();

		private NullScope()
		{
		}

		public void Dispose()
		{
		}
	}
	public class TypeNameHelper
	{
		private static readonly Dictionary<Type, string> _builtInTypeNames = new Dictionary<Type, string>
		{
			{
				typeof(bool),
				"bool"
			},
			{
				typeof(byte),
				"byte"
			},
			{
				typeof(char),
				"char"
			},
			{
				typeof(decimal),
				"decimal"
			},
			{
				typeof(double),
				"double"
			},
			{
				typeof(float),
				"float"
			},
			{
				typeof(int),
				"int"
			},
			{
				typeof(long),
				"long"
			},
			{
				typeof(object),
				"object"
			},
			{
				typeof(sbyte),
				"sbyte"
			},
			{
				typeof(short),
				"short"
			},
			{
				typeof(string),
				"string"
			},
			{
				typeof(uint),
				"uint"
			},
			{
				typeof(ulong),
				"ulong"
			},
			{
				typeof(ushort),
				"ushort"
			}
		};

		public static string GetTypeDisplayName(Type type)
		{
			if (type.GetTypeInfo().IsGenericType)
			{
				string[] array = type.GetGenericTypeDefinition().FullName.Split(new char[1] { '+' });
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					int num = text.IndexOf('`');
					if (num >= 0)
					{
						text = text.Substring(0, num);
					}
					array[i] = text;
				}
				return string.Join(".", array);
			}
			if (_builtInTypeNames.ContainsKey(type))
			{
				return _builtInTypeNames[type];
			}
			string text2 = type.FullName;
			if (type.IsNested)
			{
				text2 = text2.Replace('+', '.');
			}
			return text2;
		}
	}
}
namespace Microsoft.Extensions.Logging.Internal
{
	public class FormattedLogValues : IReadOnlyList<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, object>>
	{
		internal const int MaxCachedFormatters = 1024;

		private const string NullFormat = "[null]";

		private static int _count;

		private static ConcurrentDictionary<string, LogValuesFormatter> _formatters = new ConcurrentDictionary<string, LogValuesFormatter>();

		private readonly LogValuesFormatter _formatter;

		private readonly object[] _values;

		private readonly string _originalMessage;

		internal LogValuesFormatter Formatter => _formatter;

		public KeyValuePair<string, object> this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException("index");
				}
				if (index == Count - 1)
				{
					return new KeyValuePair<string, object>("{OriginalFormat}", _originalMessage);
				}
				return _formatter.GetValue(_values, index);
			}
		}

		public int Count
		{
			get
			{
				if (_formatter == null)
				{
					return 1;
				}
				return _formatter.ValueNames.Count + 1;
			}
		}

		public FormattedLogValues(string format, params object[] values)
		{
			if ((values == null || values.Length != 0) && format != null)
			{
				if (_count >= 1024)
				{
					if (!_formatters.TryGetValue(format, out _formatter))
					{
						_formatter = new LogValuesFormatter(format);
					}
				}
				else
				{
					_formatter = _formatters.GetOrAdd(format, delegate(string f)
					{
						Interlocked.Increment(ref _count);
						return new LogValuesFormatter(f);
					});
				}
			}
			_originalMessage = format ?? "[null]";
			_values = values;
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			int i = 0;
			while (i < Count)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		public override string ToString()
		{
			if (_formatter == null)
			{
				return _originalMessage;
			}
			return _formatter.Format(_values);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	public class LogValuesFormatter
	{
		private const string NullValue = "(null)";

		private static readonly object[] EmptyArray = new object[0];

		private static readonly char[] FormatDelimiters = new char[2] { ',', ':' };

		private readonly string _format;

		private readonly List<string> _valueNames = new List<string>();

		public string OriginalFormat { get; private set; }

		public List<string> ValueNames => _valueNames;

		public LogValuesFormatter(string format)
		{
			OriginalFormat = format;
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int length = format.Length;
			while (num < length)
			{
				int num2 = FindBraceIndex(format, '{', num, length);
				int num3 = FindBraceIndex(format, '}', num2, length);
				int num4 = FindIndexOfAny(format, FormatDelimiters, num2, num3);
				if (num3 == length)
				{
					stringBuilder.Append(format, num, length - num);
					num = length;
					continue;
				}
				stringBuilder.Append(format, num, num2 - num + 1);
				stringBuilder.Append(_valueNames.Count.ToString(CultureInfo.InvariantCulture));
				_valueNames.Add(format.Substring(num2 + 1, num4 - num2 - 1));
				stringBuilder.Append(format, num4, num3 - num4 + 1);
				num = num3 + 1;
			}
			_format = stringBuilder.ToString();
		}

		private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
		{
			int result = endIndex;
			int i = startIndex;
			int num = 0;
			for (; i < endIndex; i++)
			{
				if (num > 0 && format[i] != brace)
				{
					if (num % 2 != 0)
					{
						break;
					}
					num = 0;
					result = endIndex;
				}
				else
				{
					if (format[i] != brace)
					{
						continue;
					}
					if (brace == '}')
					{
						if (num == 0)
						{
							result = i;
						}
					}
					else
					{
						result = i;
					}
					num++;
				}
			}
			return result;
		}

		private static int FindIndexOfAny(string format, char[] chars, int startIndex, int endIndex)
		{
			int num = format.IndexOfAny(chars, startIndex, endIndex - startIndex);
			if (num != -1)
			{
				return num;
			}
			return endIndex;
		}

		public string Format(object[] values)
		{
			if (values != null)
			{
				for (int i = 0; i < values.Length; i++)
				{
					object obj = values[i];
					if (obj == null)
					{
						values[i] = "(null)";
					}
					else if (!(obj is string) && obj is IEnumerable source)
					{
						values[i] = string.Join(", ", from object o in source
							select o ?? "(null)");
					}
				}
			}
			return string.Format(CultureInfo.InvariantCulture, _format, values ?? EmptyArray);
		}

		public KeyValuePair<string, object> GetValue(object[] values, int index)
		{
			if (index < 0 || index > _valueNames.Count)
			{
				throw new IndexOutOfRangeException("index");
			}
			if (_valueNames.Count > index)
			{
				return new KeyValuePair<string, object>(_valueNames[index], values[index]);
			}
			return new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
		}

		public IEnumerable<KeyValuePair<string, object>> GetValues(object[] values)
		{
			KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[values.Length + 1];
			for (int i = 0; i != _valueNames.Count; i++)
			{
				array[i] = new KeyValuePair<string, object>(_valueNames[i], values[i]);
			}
			array[^1] = new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
			return array;
		}
	}
}
