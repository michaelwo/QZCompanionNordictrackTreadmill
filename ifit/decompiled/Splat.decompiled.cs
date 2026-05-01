#define DEBUG
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Threading;
using Splat.ApplicationPerformanceMonitoring;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("9.7.1.53962")]
[assembly: AssemblyInformationalVersion("9.7.1+cad2793877")]
[assembly: InternalsVisibleTo("Splat.Tests")]
[assembly: InternalsVisibleTo("Splat.Drawing.Tests")]
[assembly: InternalsVisibleTo("Splat.TestRunner.Android")]
[assembly: InternalsVisibleTo("Splat.TestRunner.Uwp")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("A library to make things cross-platform that should be")]
[assembly: AssemblyProduct("Splat (netstandard2.0)")]
[assembly: AssemblyTitle("Splat")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/reactiveui/splat")]
[assembly: AssemblyVersion("9.7.0.0")]
[GeneratedCode("Nerdbank.GitVersioning.Tasks", "3.3.37.35081")]
[ExcludeFromCodeCoverage]
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "9.7.0.0";

	internal const string AssemblyFileVersion = "9.7.1.53962";

	internal const string AssemblyInformationalVersion = "9.7.1+cad2793877";

	internal const string AssemblyName = "Splat";

	internal const string AssemblyTitle = "Splat";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "cad2793877a3a90b9095e2f5363b33ef3f4c7161";

	internal const bool IsPublicRelease = true;

	internal const bool IsPrerelease = false;

	internal static readonly DateTime GitCommitDate = new DateTime(637407176200000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Splat";
}
namespace Splat
{
	internal static class AssemblyFinder
	{
		public static T AttemptToLoadType<T>(string fullTypeName)
		{
			Type typeFromHandle = typeof(AssemblyFinder);
			AssemblyName[] array = new string[2]
			{
				typeFromHandle.AssemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty),
				typeFromHandle.AssemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty).Replace(".Portable", string.Empty)
			}.Select((string x) => new AssemblyName(x)).ToArray();
			foreach (AssemblyName assemblyName in array)
			{
				Type type = Type.GetType(fullTypeName + ", " + assemblyName.FullName, throwOnError: false);
				if (!(type == null))
				{
					return (T)Activator.CreateInstance(type);
				}
			}
			return default(T);
		}
	}
	internal sealed class ActionDisposable : IDisposable
	{
		private Action _block;

		public static IDisposable Empty => new ActionDisposable(delegate
		{
		});

		public ActionDisposable(Action block)
		{
			_block = block;
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _block, delegate
			{
			})();
		}
	}
	internal sealed class BooleanDisposable : IDisposable
	{
		private volatile bool _isDisposed;

		public bool IsDisposed => _isDisposed;

		public BooleanDisposable()
		{
		}

		private BooleanDisposable(bool isDisposed)
		{
			_isDisposed = isDisposed;
		}

		public void Dispose()
		{
			_isDisposed = true;
		}
	}
	internal sealed class CompositeDisposable : IDisposable
	{
		private const int DefaultCapacity = 16;

		private readonly object _gate = new object();

		private bool _disposed;

		private List<IDisposable> _disposables;

		private int _count;

		public CompositeDisposable()
		{
			_disposables = new List<IDisposable>();
		}

		public CompositeDisposable(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			_disposables = new List<IDisposable>(capacity);
		}

		public CompositeDisposable(params IDisposable[] disposables)
		{
			if (disposables == null)
			{
				throw new ArgumentNullException("disposables");
			}
			Init(disposables, disposables.Length);
		}

		public CompositeDisposable(IEnumerable<IDisposable> disposables)
		{
			if (disposables == null)
			{
				throw new ArgumentNullException("disposables");
			}
			if (disposables is ICollection<IDisposable> collection)
			{
				Init(disposables, collection.Count);
			}
			else
			{
				Init(disposables, 16);
			}
		}

		public void Dispose()
		{
			List<IDisposable> list = null;
			lock (_gate)
			{
				if (!_disposed)
				{
					list = _disposables;
					_disposables = null;
					Volatile.Write(ref _count, 0);
					Volatile.Write(ref _disposed, value: true);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (IDisposable item in list)
			{
				item?.Dispose();
			}
		}

		private void Init(IEnumerable<IDisposable> disposables, int capacityHint)
		{
			List<IDisposable> list = new List<IDisposable>(capacityHint);
			foreach (IDisposable disposable in disposables)
			{
				if (disposable == null)
				{
					throw new ArgumentException("disposables for some reason are null", "disposables");
				}
				list.Add(disposable);
			}
			_disposables = list;
			Volatile.Write(ref _count, _disposables.Count);
		}
	}
	public class ActionLogger : ILogger
	{
		private readonly Action<string, LogLevel> _writeNoType;

		private readonly Action<Exception, string, LogLevel> _writeNoTypeWithException;

		private readonly Action<string, Type, LogLevel> _writeWithType;

		private readonly Action<Exception, string, Type, LogLevel> _writeWithTypeAndException;

		public LogLevel Level { get; set; }

		public ActionLogger(Action<string, LogLevel> writeNoType, Action<string, Type, LogLevel> writeWithType, Action<Exception, string, LogLevel> writeNoTypeWithException, Action<Exception, string, Type, LogLevel> writeWithTypeAndException)
		{
			_writeNoType = writeNoType;
			_writeWithType = writeWithType;
			_writeNoTypeWithException = writeNoTypeWithException;
			_writeWithTypeAndException = writeWithTypeAndException;
		}

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			_writeNoType?.Invoke(message, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			_writeNoTypeWithException?.Invoke(exception, message, logLevel);
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_writeWithType?.Invoke(message, type, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_writeWithTypeAndException?.Invoke(exception, message, type, logLevel);
		}
	}
	public abstract class AllocationFreeLoggerBase : IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
	{
		private readonly ILogger _inner;

		public LogLevel Level => _inner.Level;

		public bool IsDebugEnabled => Level <= LogLevel.Debug;

		public bool IsInfoEnabled => Level <= LogLevel.Info;

		public bool IsWarnEnabled => Level <= LogLevel.Warn;

		public bool IsErrorEnabled => Level <= LogLevel.Error;

		public bool IsFatalEnabled => Level <= LogLevel.Fatal;

		protected AllocationFreeLoggerBase(ILogger inner)
		{
			_inner = inner;
		}

		public virtual void Debug<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument>(Exception exception, string messageFormat, TArgument argument)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Debug);
			}
		}

		public virtual void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Debug);
			}
		}

		public void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsDebugEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Debug);
			}
		}

		public virtual void Info<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Info);
			}
		}

		public void Info<TArgument>(Exception exception, string messageFormat, TArgument argument)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Info);
			}
		}

		public virtual void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Info);
			}
		}

		public void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsInfoEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Info);
			}
		}

		public virtual void Warn<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Warn);
			}
		}

		public void Warn<TArgument>(Exception exception, string messageFormat, TArgument argument)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Warn);
			}
		}

		public virtual void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Warn);
			}
		}

		public void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsWarnEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Warn);
			}
		}

		public virtual void Error<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Error);
			}
		}

		public void Error<TArgument>(Exception exception, string messageFormat, TArgument argument)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Error);
			}
		}

		public virtual void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Error);
			}
		}

		public void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsErrorEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Error);
			}
		}

		public virtual void Fatal<TArgument>([Localizable(false)] string messageFormat, TArgument argument)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument>(Exception exception, string messageFormat, TArgument argument)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9), LogLevel.Fatal);
			}
		}

		public virtual void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Fatal);
			}
		}

		public void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10)
		{
			if (IsFatalEnabled)
			{
				_inner.Write(exception, string.Format(CultureInfo.InvariantCulture, messageFormat, argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10), LogLevel.Fatal);
			}
		}

		public void Write([Localizable(false)] string messageFormat, LogLevel logLevel)
		{
			_inner.Write(messageFormat, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string messageFormat, LogLevel logLevel)
		{
			_inner.Write(exception, messageFormat, logLevel);
		}

		public void Write([Localizable(false)] string messageFormat, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write(messageFormat, type, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string messageFormat, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write(exception, messageFormat, type, logLevel);
		}
	}
	public class ConsoleLogger : ILogger
	{
		public string ExceptionMessageFormat { get; set; } = "{0} - {1}";

		public LogLevel Level { get; set; }

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Console.WriteLine(message);
			}
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Console.WriteLine(string.Format(CultureInfo.InvariantCulture, ExceptionMessageFormat, message, exception));
			}
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Console.WriteLine(message);
			}
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Console.WriteLine(string.Format(CultureInfo.InvariantCulture, ExceptionMessageFormat, message, exception));
			}
		}
	}
	public class DebugLogger : ILogger
	{
		public LogLevel Level { get; set; }

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Debug.WriteLine(message);
			}
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Debug.WriteLine($"{message} - {exception}");
			}
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Debug.WriteLine(message, type?.Name);
			}
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Debug.WriteLine($"{message} - {exception}", type?.Name);
			}
		}
	}
	public sealed class DefaultLogManager : ILogManager
	{
		private static readonly IFullLogger _nullLogger = new WrappingFullLogger(new NullLogger());

		private readonly MemoizingMRUCache<Type, IFullLogger> _loggerCache;

		public DefaultLogManager(IReadonlyDependencyResolver dependencyResolver = null)
		{
			dependencyResolver = dependencyResolver ?? Locator.Current;
			_loggerCache = new MemoizingMRUCache<Type, IFullLogger>((Type type, object _) => new WrappingFullLogger(new WrappingPrefixLogger(dependencyResolver.GetService<ILogger>() ?? throw new LoggingException("Couldn't find an ILogger. This should never happen, your dependency resolver is probably broken."), type)), 64);
		}

		public IFullLogger GetLogger(Type type)
		{
			if (type == typeof(MemoizingMRUCache<Type, IFullLogger>))
			{
				return _nullLogger;
			}
			lock (_loggerCache)
			{
				return _loggerCache.Get(type);
			}
		}
	}
	public static class FullLoggerExtensions
	{
		public static void Debug(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsDebugEnabled)
			{
				logger.Debug(function());
			}
		}

		public static void Debug<T>(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsDebugEnabled)
			{
				logger.Debug<T>(function());
			}
		}

		public static void DebugException(this IFullLogger logger, Func<string> function, Exception exception)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsDebugEnabled)
			{
				logger.DebugException(function(), exception);
			}
		}

		public static void Info(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsInfoEnabled)
			{
				logger.Info(function());
			}
		}

		public static void Info<T>(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsInfoEnabled)
			{
				logger.Info<T>(function());
			}
		}

		public static void InfoException(this IFullLogger logger, Func<string> function, Exception exception)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsInfoEnabled)
			{
				logger.InfoException(function(), exception);
			}
		}

		public static void Warn(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsWarnEnabled)
			{
				logger.Warn(function());
			}
		}

		public static void Warn<T>(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsWarnEnabled)
			{
				logger.Warn<T>(function());
			}
		}

		public static void WarnException(this IFullLogger logger, Func<string> function, Exception exception)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsWarnEnabled)
			{
				logger.WarnException(function(), exception);
			}
		}

		public static void Error(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsErrorEnabled)
			{
				logger.Error(function());
			}
		}

		public static void Error<T>(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsErrorEnabled)
			{
				logger.Error<T>(function());
			}
		}

		public static void ErrorException(this IFullLogger logger, Func<string> function, Exception exception)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsErrorEnabled)
			{
				logger.ErrorException(function(), exception);
			}
		}

		public static void Fatal(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsFatalEnabled)
			{
				logger.Fatal(function());
			}
		}

		public static void Fatal<T>(this IFullLogger logger, Func<string> function)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsFatalEnabled)
			{
				logger.Fatal<T>(function());
			}
		}

		public static void FatalException(this IFullLogger logger, Func<string> function, Exception exception)
		{
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (logger.IsFatalEnabled)
			{
				logger.ErrorException(function(), exception);
			}
		}
	}
	public class FuncLogManager : ILogManager
	{
		private readonly Func<Type, IFullLogger> _inner;

		public FuncLogManager(Func<Type, IFullLogger> getLoggerFunc)
		{
			_inner = getLoggerFunc;
		}

		public IFullLogger GetLogger(Type type)
		{
			return _inner(type);
		}
	}
	public interface IAllocationFreeErrorLogger : ILogger
	{
		void Debug<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

		void Debug<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Debug<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Info<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

		void Info<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Info<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Warn<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

		void Warn<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Warn<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Error<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

		void Error<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Error<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Fatal<TArgument>(Exception exception, [Localizable(false)] string messageFormat, TArgument argument);

		void Fatal<TArgument1, TArgument2>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Fatal<TArgument1, TArgument2, TArgument3>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>(Exception exception, [Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);
	}
	public interface IAllocationFreeLogger : IAllocationFreeErrorLogger, ILogger
	{
		bool IsDebugEnabled { get; }

		bool IsInfoEnabled { get; }

		bool IsWarnEnabled { get; }

		bool IsErrorEnabled { get; }

		bool IsFatalEnabled { get; }

		void Debug<TArgument>([Localizable(false)] string messageFormat, TArgument argument);

		void Debug<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Debug<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Info<TArgument>([Localizable(false)] string messageFormat, TArgument argument);

		void Info<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Info<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Warn<TArgument>([Localizable(false)] string messageFormat, TArgument argument);

		void Warn<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Warn<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Error<TArgument>([Localizable(false)] string messageFormat, TArgument argument);

		void Error<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Error<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);

		void Fatal<TArgument>([Localizable(false)] string messageFormat, TArgument argument);

		void Fatal<TArgument1, TArgument2>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2);

		void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9);

		void Fatal<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TArgument10>([Localizable(false)] string messageFormat, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6, TArgument7 argument7, TArgument8 argument8, TArgument9 argument9, TArgument10 argument10);
	}
	[ComVisible(false)]
	public interface IEnableLogger
	{
	}
	public interface IFullLogger : IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
	{
		void Debug<T>(T value);

		void Debug<T>(IFormatProvider formatProvider, T value);

		[Obsolete("Use void Debug(Exception exception, [Localizable(false)] string message)")]
		void DebugException([Localizable(false)] string message, Exception exception);

		void Debug(Exception exception, [Localizable(false)] string message);

		void Debug(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

		void Debug([Localizable(false)] string message);

		void Debug<T>([Localizable(false)] string message);

		void Debug([Localizable(false)] string message, params object[] args);

		void Debug<T>([Localizable(false)] string message, params object[] args);

		void Debug<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

		void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

		void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Info<T>(T value);

		void Info<T>(IFormatProvider formatProvider, T value);

		[Obsolete("Use void Info(Exception exception, [Localizable(false)] string message)")]
		void InfoException([Localizable(false)] string message, Exception exception);

		void Info(Exception exception, [Localizable(false)] string message);

		void Info(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

		void Info([Localizable(false)] string message);

		void Info<T>([Localizable(false)] string message);

		void Info([Localizable(false)] string message, params object[] args);

		void Info<T>([Localizable(false)] string message, params object[] args);

		void Info<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

		void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

		void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Warn<T>(T value);

		void Warn<T>(IFormatProvider formatProvider, T value);

		[Obsolete("Use void Warn(Exception exception, [Localizable(false)] string message)")]
		void WarnException([Localizable(false)] string message, Exception exception);

		void Warn(Exception exception, [Localizable(false)] string message);

		void Warn(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

		void Warn([Localizable(false)] string message);

		void Warn<T>([Localizable(false)] string message);

		void Warn([Localizable(false)] string message, params object[] args);

		void Warn<T>([Localizable(false)] string message, params object[] args);

		void Warn<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

		void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

		void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Error<T>(T value);

		void Error<T>(IFormatProvider formatProvider, T value);

		[Obsolete("Use void Error(Exception exception, [Localizable(false)] string message)")]
		void ErrorException([Localizable(false)] string message, Exception exception);

		void Error(Exception exception, [Localizable(false)] string message);

		void Error(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

		void Error([Localizable(false)] string message);

		void Error<T>([Localizable(false)] string message);

		void Error([Localizable(false)] string message, params object[] args);

		void Error<T>([Localizable(false)] string message, params object[] args);

		void Error<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

		void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

		void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);

		void Fatal<T>(T value);

		void Fatal<T>(IFormatProvider formatProvider, T value);

		[Obsolete("Use void Fatal(Exception exception, [Localizable(false)] string message)")]
		void FatalException([Localizable(false)] string message, Exception exception);

		void Fatal(Exception exception, [Localizable(false)] string message);

		void Fatal(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);

		void Fatal([Localizable(false)] string message);

		void Fatal<T>([Localizable(false)] string message);

		void Fatal([Localizable(false)] string message, params object[] args);

		void Fatal<T>([Localizable(false)] string message, params object[] args);

		void Fatal<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument);

		void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2);

		void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);
	}
	public interface ILogger
	{
		LogLevel Level { get; }

		void Write([Localizable(false)] string message, LogLevel logLevel);

		void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel);

		void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel);

		void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel);
	}
	public interface ILogManager
	{
		IFullLogger GetLogger(Type type);
	}
	[Serializable]
	public class LoggingException : Exception
	{
		public LoggingException()
		{
		}

		public LoggingException(string message)
			: base(message)
		{
		}

		public LoggingException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected LoggingException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	public static class LogHost
	{
		public static IFullLogger Default => (Locator.Current.GetService<ILogManager>() ?? throw new LoggingException("ILogManager is null. This should never happen, your dependency resolver is broken")).GetLogger(typeof(LogHost));

		public static IFullLogger Log<T>(this T logClassInstance) where T : IEnableLogger
		{
			return (Locator.Current.GetService<ILogManager>() ?? throw new Exception("ILogManager is null. This should never happen, your dependency resolver is broken")).GetLogger<T>();
		}
	}
	public enum LogLevel
	{
		Debug = 1,
		Info,
		Warn,
		Error,
		Fatal
	}
	public static class LogManagerMixin
	{
		public static IFullLogger GetLogger<T>(this ILogManager logManager)
		{
			if (logManager == null)
			{
				throw new ArgumentNullException("logManager");
			}
			return logManager.GetLogger(typeof(T));
		}
	}
	public class NullLogger : ILogger
	{
		public LogLevel Level { get; set; }

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
		}
	}
	public class WrappingFullLogger : AllocationFreeLoggerBase, IFullLogger, IAllocationFreeLogger, IAllocationFreeErrorLogger, ILogger
	{
		private readonly ILogger _inner;

		private readonly MethodInfo _stringFormat;

		public WrappingFullLogger(ILogger inner)
			: base(inner)
		{
			_inner = inner;
			_stringFormat = typeof(string).GetMethod("Format", new Type[3]
			{
				typeof(IFormatProvider),
				typeof(string),
				typeof(object[])
			});
		}

		public void Debug<T>(T value)
		{
			if (value != null)
			{
				_inner.Write(value.ToString(), LogLevel.Debug);
			}
		}

		public void Debug<T>(IFormatProvider formatProvider, T value)
		{
			_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Debug);
		}

		public void DebugException(string message, Exception exception)
		{
			_inner.Write(exception, $"{message}: {exception}", LogLevel.Debug);
		}

		public void Debug(Exception exception, string message)
		{
			_inner.Write(exception, message ?? "", LogLevel.Debug);
		}

		public void Debug(IFormatProvider formatProvider, string message, params object[] args)
		{
			string message2 = InvokeStringFormat(formatProvider, message, args);
			_inner.Write(message2, LogLevel.Debug);
		}

		public void Debug(string message)
		{
			_inner.Write(message, LogLevel.Debug);
		}

		public void Debug<T>(string message)
		{
			_inner.Write(message, typeof(T), LogLevel.Debug);
		}

		public void Debug(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, LogLevel.Debug);
		}

		public void Debug<T>(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, typeof(T), LogLevel.Debug);
		}

		public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Debug);
		}

		public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Debug);
		}

		public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Debug);
		}

		public void Info<T>(T value)
		{
			if (value != null)
			{
				_inner.Write(value.ToString(), LogLevel.Info);
			}
		}

		public void Info<T>(IFormatProvider formatProvider, T value)
		{
			_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Info);
		}

		public void InfoException(string message, Exception exception)
		{
			_inner.Write(exception, $"{message}: {exception}", LogLevel.Info);
		}

		public void Info(Exception exception, string message)
		{
			_inner.Write(exception, message ?? "", LogLevel.Info);
		}

		public void Info(IFormatProvider formatProvider, string message, params object[] args)
		{
			string message2 = InvokeStringFormat(formatProvider, message, args);
			_inner.Write(message2, LogLevel.Info);
		}

		public void Info(string message)
		{
			_inner.Write(message, LogLevel.Info);
		}

		public void Info<T>(string message)
		{
			_inner.Write(message, typeof(T), LogLevel.Info);
		}

		public void Info(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, LogLevel.Info);
		}

		public void Info<T>(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, typeof(T), LogLevel.Info);
		}

		public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Info);
		}

		public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Info);
		}

		public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Info);
		}

		public void Warn<T>(T value)
		{
			if (value != null)
			{
				_inner.Write(value.ToString(), LogLevel.Warn);
			}
		}

		public void Warn<T>(IFormatProvider formatProvider, T value)
		{
			_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Warn);
		}

		public void WarnException(string message, Exception exception)
		{
			_inner.Write(exception, $"{message}: {exception}", LogLevel.Warn);
		}

		public void Warn(Exception exception, string message)
		{
			_inner.Write(exception, message ?? "", LogLevel.Warn);
		}

		public void Warn(IFormatProvider formatProvider, string message, params object[] args)
		{
			string message2 = InvokeStringFormat(formatProvider, message, args);
			_inner.Write(message2, LogLevel.Warn);
		}

		public void Warn(string message)
		{
			_inner.Write(message, LogLevel.Warn);
		}

		public void Warn<T>(string message)
		{
			_inner.Write(message, typeof(T), LogLevel.Warn);
		}

		public void Warn(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, LogLevel.Warn);
		}

		public void Warn<T>(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, typeof(T), LogLevel.Warn);
		}

		public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Warn);
		}

		public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Warn);
		}

		public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Warn);
		}

		public void Error<T>(T value)
		{
			if (value != null)
			{
				_inner.Write(value.ToString(), LogLevel.Error);
			}
		}

		public void Error<T>(IFormatProvider formatProvider, T value)
		{
			_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Error);
		}

		public void ErrorException(string message, Exception exception)
		{
			_inner.Write(exception, $"{message}: {exception}", LogLevel.Error);
		}

		public void Error(Exception exception, string message)
		{
			_inner.Write(exception, message ?? "", LogLevel.Error);
		}

		public void Error(IFormatProvider formatProvider, string message, params object[] args)
		{
			string message2 = InvokeStringFormat(formatProvider, message, args);
			_inner.Write(message2, LogLevel.Error);
		}

		public void Error(string message)
		{
			_inner.Write(message, LogLevel.Error);
		}

		public void Error<T>(string message)
		{
			_inner.Write(message, typeof(T), LogLevel.Error);
		}

		public void Error(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, LogLevel.Error);
		}

		public void Error<T>(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, typeof(T), LogLevel.Error);
		}

		public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Error);
		}

		public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Error);
		}

		public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Error);
		}

		public void Fatal<T>(T value)
		{
			if (value != null)
			{
				_inner.Write(value.ToString(), LogLevel.Fatal);
			}
		}

		public void Fatal<T>(IFormatProvider formatProvider, T value)
		{
			_inner.Write(string.Format(formatProvider, "{0}", value), LogLevel.Fatal);
		}

		public void FatalException(string message, Exception exception)
		{
			_inner.Write(exception, $"{message}: {exception}", LogLevel.Fatal);
		}

		public void Fatal(Exception exception, string message)
		{
			_inner.Write(exception, message ?? "", LogLevel.Fatal);
		}

		public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
		{
			string message2 = InvokeStringFormat(formatProvider, message, args);
			_inner.Write(message2, LogLevel.Fatal);
		}

		public void Fatal(string message)
		{
			_inner.Write(message, LogLevel.Fatal);
		}

		public void Fatal<T>(string message)
		{
			_inner.Write(message, typeof(T), LogLevel.Fatal);
		}

		public void Fatal(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, LogLevel.Fatal);
		}

		public void Fatal<T>(string message, params object[] args)
		{
			string message2 = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
			_inner.Write(message2, typeof(T), LogLevel.Fatal);
		}

		public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
		{
			_inner.Write(string.Format(formatProvider, message, argument), LogLevel.Fatal);
		}

		public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2), LogLevel.Fatal);
		}

		public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			_inner.Write(string.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Fatal);
		}

		private string InvokeStringFormat(IFormatProvider formatProvider, string message, object[] args)
		{
			object[] parameters = new object[3] { formatProvider, message, args };
			return (string)_stringFormat.Invoke(null, parameters);
		}
	}
	public class WrappingLogLevelLogger : ILogger
	{
		private readonly ILogger _inner;

		public LogLevel Level => _inner.Level;

		public WrappingLogLevelLogger(ILogger inner)
		{
			_inner = inner;
		}

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			_inner.Write($"{logLevel}: {message}", logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			_inner.Write(exception, $"{logLevel}: {message}", logLevel);
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write($"{logLevel}: {message}", type, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write(exception, $"{logLevel}: {message}", type, logLevel);
		}
	}
	public class WrappingPrefixLogger : ILogger
	{
		private readonly ILogger _inner;

		private readonly string _prefix;

		public LogLevel Level => _inner.Level;

		public WrappingPrefixLogger(ILogger inner, Type callingType)
		{
			_inner = inner;
			_prefix = callingType?.Name + ": ";
		}

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			_inner.Write(_prefix + message, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, LogLevel logLevel)
		{
			_inner.Write(exception, _prefix + message, logLevel);
		}

		public void Write([Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write(type?.Name + ": " + message, type, logLevel);
		}

		public void Write(Exception exception, [Localizable(false)] string message, [Localizable(false)] Type type, LogLevel logLevel)
		{
			_inner.Write(exception, type?.Name + ": " + message, type, logLevel);
		}
	}
	public static class PointMathExtensions
	{
		public static PointF Floor(this Point value)
		{
			return new PointF((float)Math.Floor(value.X), (float)Math.Ceiling(value.Y));
		}

		public static bool WithinEpsilonOf(this PointF value, PointF other, float epsilon)
		{
			return value.DistanceTo(other) < epsilon;
		}

		public static float DotProduct(this PointF value, PointF other)
		{
			return value.X * other.X + value.Y * other.Y;
		}

		public static PointF ScaledBy(this PointF value, float factor)
		{
			return new PointF(value.X * factor, value.Y * factor);
		}

		public static float Length(this PointF value)
		{
			return PointF.Empty.DistanceTo(value);
		}

		public static PointF Normalize(this PointF value)
		{
			float num = value.Length();
			if (num == 0f)
			{
				return value;
			}
			return new PointF(value.X / num, value.Y / num);
		}

		public static float AngleInDegrees(this PointF value)
		{
			return (float)(Math.Atan2(value.Y, value.X) * 180.0 / Math.PI);
		}

		public static PointF ProjectAlong(this PointF value, PointF direction)
		{
			PointF pointF = direction.Normalize();
			float factor = value.DotProduct(pointF);
			return pointF.ScaledBy(factor);
		}

		public static PointF ProjectAlongAngle(this PointF value, float angleInDegrees)
		{
			double num = (double)angleInDegrees * Math.PI / 180.0;
			PointF direction = new PointF((float)Math.Cos(num), (float)Math.Sin(num));
			return value.ProjectAlong(direction);
		}

		public static float DistanceTo(this PointF value, PointF other)
		{
			float num = other.X - value.X;
			float num2 = other.Y - value.Y;
			return (float)Math.Sqrt(num * num + num2 * num2);
		}
	}
	public static class RectangleMathExtensions
	{
		public static PointF Center(this RectangleF value)
		{
			return new PointF(value.X + value.Width / 2f, value.Y + value.Height / 2f);
		}

		public static Tuple<RectangleF, RectangleF> Divide(this RectangleF value, float amount, RectEdge fromEdge)
		{
			float num = 0f;
			switch (fromEdge)
			{
			case RectEdge.Left:
				num = Math.Max(value.Width, amount);
				return Tuple.Create(value.Copy(null, null, num), value.Copy(value.Left + num, null, value.Width - num));
			case RectEdge.Top:
				num = Math.Max(value.Height, amount);
				return Tuple.Create(value.Copy(null, null, null, amount), value.Copy(null, value.Top + num, null, value.Height - num));
			case RectEdge.Right:
				num = Math.Max(value.Width, amount);
				return Tuple.Create(value.Copy(value.Right - num, null, num), value.Copy(null, null, value.Width - num));
			case RectEdge.Bottom:
				num = Math.Max(value.Height, amount);
				return Tuple.Create(value.Copy(null, value.Bottom - num, null, num), value.Copy(null, null, null, value.Height - num));
			default:
				throw new ArgumentException("edge");
			}
		}

		public static Tuple<RectangleF, RectangleF> DivideWithPadding(this RectangleF value, float sliceAmount, float padding, RectEdge fromEdge)
		{
			Tuple<RectangleF, RectangleF> tuple = value.Divide(sliceAmount, fromEdge);
			return Tuple.Create(item2: value.Divide(padding, fromEdge).Item2, item1: tuple.Item1);
		}

		public static RectangleF InvertWithin(this RectangleF value, RectangleF containingRect)
		{
			return new RectangleF(value.X, containingRect.Height - value.Bottom, value.Width, value.Height);
		}

		public static RectangleF Copy(this RectangleF value, float? x = null, float? y = null, float? width = null, float? height = null, float? top = null, float? bottom = null)
		{
			RectangleF result = new RectangleF(value.Location, value.Size);
			if (x.HasValue)
			{
				result.X = x.Value;
			}
			if (y.HasValue)
			{
				result.Y = y.Value;
			}
			if (width.HasValue)
			{
				result.Width = width.Value;
			}
			if (height.HasValue)
			{
				result.Height = height.Value;
			}
			if (top.HasValue)
			{
				if (y.HasValue)
				{
					throw new ArgumentException("Conflicting Copy arguments Y and Top");
				}
				result.Y = top.Value;
			}
			if (bottom.HasValue)
			{
				if (height.HasValue)
				{
					throw new ArgumentException("Conflicting Copy arguments Height and Bottom");
				}
				result.Height = result.Y + bottom.Value;
			}
			return result;
		}
	}
	public enum RectEdge
	{
		Left,
		Top,
		Right,
		Bottom
	}
	public static class SizeMathExtensions
	{
		public static bool WithinEpsilonOf(this SizeF value, SizeF other, float epsilon)
		{
			float num = other.Width - value.Width;
			float num2 = other.Height - value.Height;
			return Math.Sqrt(num * num + num2 * num2) < (double)epsilon;
		}

		public static SizeF ScaledBy(this SizeF value, float factor)
		{
			return new SizeF(value.Width * factor, value.Height * factor);
		}
	}
	public sealed class MemoizingMRUCache<TParam, TVal>
	{
		private readonly object _lockObject = new object();

		private readonly Func<TParam, object, TVal> _calculationFunction;

		private readonly Action<TVal> _releaseFunction;

		private readonly int _maxCacheSize;

		private readonly IEqualityComparer<TParam> _comparer;

		private LinkedList<TParam> _cacheMRUList;

		private Dictionary<TParam, (LinkedListNode<TParam> param, TVal value)> _cacheEntries;

		public MemoizingMRUCache(Func<TParam, object, TVal> calculationFunc, int maxSize)
			: this(calculationFunc, maxSize, (Action<TVal>)null, (IEqualityComparer<TParam>)EqualityComparer<TParam>.Default)
		{
		}

		public MemoizingMRUCache(Func<TParam, object, TVal> calculationFunc, int maxSize, Action<TVal> onRelease)
			: this(calculationFunc, maxSize, onRelease, (IEqualityComparer<TParam>)EqualityComparer<TParam>.Default)
		{
		}

		public MemoizingMRUCache(Func<TParam, object, TVal> calculationFunc, int maxSize, IEqualityComparer<TParam> paramComparer)
			: this(calculationFunc, maxSize, (Action<TVal>)null, paramComparer)
		{
		}

		public MemoizingMRUCache(Func<TParam, object, TVal> calculationFunc, int maxSize, Action<TVal> onRelease, IEqualityComparer<TParam> paramComparer)
		{
			_calculationFunction = calculationFunc;
			_releaseFunction = onRelease;
			_maxCacheSize = maxSize;
			_comparer = paramComparer ?? EqualityComparer<TParam>.Default;
			InvalidateAll();
		}

		public TVal Get(TParam key)
		{
			return Get(key, null);
		}

		public TVal Get(TParam key, object context = null)
		{
			lock (_lockObject)
			{
				if (_cacheEntries.TryGetValue(key, out (LinkedListNode<TParam>, TVal) value))
				{
					RefreshEntry(value.Item1);
					return value.Item2;
				}
				TVal val = _calculationFunction(key, context);
				LinkedListNode<TParam> linkedListNode = new LinkedListNode<TParam>(key);
				_cacheMRUList.AddFirst(linkedListNode);
				_cacheEntries[key] = (linkedListNode, val);
				MaintainCache();
				return val;
			}
		}

		public bool TryGet(TParam key, out TVal result)
		{
			lock (_lockObject)
			{
				(LinkedListNode<TParam>, TVal) value;
				bool num = _cacheEntries.TryGetValue(key, out value);
				if (num)
				{
					RefreshEntry(value.Item1);
					result = value.Item2;
				}
				else
				{
					result = default(TVal);
				}
				return num;
			}
		}

		public void Invalidate(TParam key)
		{
			lock (_lockObject)
			{
				if (_cacheEntries.TryGetValue(key, out (LinkedListNode<TParam>, TVal) value))
				{
					TVal item = value.Item2;
					_cacheMRUList.Remove(value.Item1);
					_cacheEntries.Remove(key);
					_releaseFunction?.Invoke(item);
				}
			}
		}

		public void InvalidateAll(bool aggregateReleaseExceptions = false)
		{
			Dictionary<TParam, (LinkedListNode<TParam>, TVal)> dictionary = null;
			lock (_lockObject)
			{
				if (_releaseFunction == null || _cacheEntries == null)
				{
					_cacheMRUList = new LinkedList<TParam>();
					_cacheEntries = new Dictionary<TParam, (LinkedListNode<TParam>, TVal)>(_comparer);
					return;
				}
				if (_cacheEntries.Count == 0)
				{
					return;
				}
				if (_releaseFunction != null)
				{
					dictionary = _cacheEntries;
				}
				_cacheMRUList = new LinkedList<TParam>();
				_cacheEntries = new Dictionary<TParam, (LinkedListNode<TParam>, TVal)>(_comparer);
			}
			if (dictionary == null)
			{
				return;
			}
			if (aggregateReleaseExceptions)
			{
				List<Exception> list = new List<Exception>(dictionary.Count);
				foreach (KeyValuePair<TParam, (LinkedListNode<TParam>, TVal)> item2 in dictionary)
				{
					try
					{
						_releaseFunction?.Invoke(item2.Value.Item2);
					}
					catch (Exception item)
					{
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					throw new AggregateException("Exceptions throw during MRU Cache Invalidate All Item Release.", list);
				}
				return;
			}
			foreach (KeyValuePair<TParam, (LinkedListNode<TParam>, TVal)> item3 in dictionary)
			{
				_releaseFunction?.Invoke(item3.Value.Item2);
			}
		}

		public IEnumerable<TVal> CachedValues()
		{
			lock (_lockObject)
			{
				return _cacheEntries.Select((KeyValuePair<TParam, (LinkedListNode<TParam> param, TVal value)> x) => x.Value.value);
			}
		}

		private void MaintainCache()
		{
			while (_cacheMRUList.Count > _maxCacheSize)
			{
				TParam value = _cacheMRUList.Last.Value;
				_releaseFunction?.Invoke(_cacheEntries[value].value);
				_cacheEntries.Remove(_cacheMRUList.Last.Value);
				_cacheMRUList.RemoveLast();
			}
		}

		private void RefreshEntry(LinkedListNode<TParam> item)
		{
			if (_cacheEntries.Count > 1)
			{
				_cacheMRUList.Remove(item);
				_cacheMRUList.AddFirst(item);
			}
		}

		private void Invariants()
		{
		}
	}
	public class DefaultModeDetector : IModeDetector, IEnableLogger
	{
		public bool? InUnitTestRunner()
		{
			string[] assemblyList = new string[9] { "CSUNIT", "NUNIT", "XUNIT", "MBUNIT", "NBEHAVE", "VISUALSTUDIO.QUALITYTOOLS", "VISUALSTUDIO.TESTPLATFORM", "FIXIE", "NCRUNCH" };
			try
			{
				return SearchForAssembly(assemblyList);
			}
			catch (Exception exception)
			{
				this.Log().Debug(exception, "Unable to find unit test runner value");
				return null;
			}
		}

		private static bool SearchForAssembly(IEnumerable<string> assemblyList)
		{
			return (from x in AppDomain.CurrentDomain.GetAssemblies()
				select x.FullName.ToUpperInvariant()).Any((string x) => assemblyList.Any((string name) => x.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) != -1));
		}
	}
	public interface IModeDetector
	{
		bool? InUnitTestRunner();
	}
	public static class ModeDetector
	{
		private static bool? _cachedInUnitTestRunnerResult;

		private static IModeDetector Current { get; set; }

		static ModeDetector()
		{
			Current = new DefaultModeDetector();
		}

		public static void OverrideModeDetector(IModeDetector modeDetector)
		{
			Current = modeDetector;
			_cachedInUnitTestRunnerResult = null;
		}

		public static bool InUnitTestRunner()
		{
			if (_cachedInUnitTestRunnerResult.HasValue)
			{
				return _cachedInUnitTestRunnerResult.Value;
			}
			if (Current != null)
			{
				_cachedInUnitTestRunnerResult = Current.InUnitTestRunner();
				if (_cachedInUnitTestRunnerResult.HasValue)
				{
					return _cachedInUnitTestRunnerResult.Value;
				}
			}
			return false;
		}
	}
	public static class DependencyResolverMixins
	{
		public static T GetService<T>(this IReadonlyDependencyResolver resolver, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			return (T)resolver.GetService(typeof(T), contract);
		}

		public static IEnumerable<T> GetServices<T>(this IReadonlyDependencyResolver resolver, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			return resolver.GetServices(typeof(T), contract).Cast<T>();
		}

		public static IDisposable ServiceRegistrationCallback(this IMutableDependencyResolver resolver, Type serviceType, Action<IDisposable> callback)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			return resolver.ServiceRegistrationCallback(serviceType, null, callback);
		}

		public static IDisposable WithResolver(this IDependencyResolver resolver, bool suppressResolverCallback = true)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			IDisposable disposable2;
			if (!suppressResolverCallback)
			{
				IDisposable disposable = new ActionDisposable(delegate
				{
				});
				disposable2 = disposable;
			}
			else
			{
				disposable2 = Locator.SuppressResolverCallbackChangedNotifications();
			}
			IDisposable disposable3 = disposable2;
			IDependencyResolver origResolver = Locator.GetLocator();
			Locator.SetLocator(resolver);
			return new CompositeDisposable(new ActionDisposable(delegate
			{
				Locator.SetLocator(origResolver);
			}), disposable3);
		}

		public static void Register<T>(this IMutableDependencyResolver resolver, Func<T> factory, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			resolver.Register(() => factory(), typeof(T), contract);
		}

		public static void RegisterConstant(this IMutableDependencyResolver resolver, object value, Type serviceType, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			resolver.Register(() => value, serviceType, contract);
		}

		public static void RegisterConstant<T>(this IMutableDependencyResolver resolver, T value, string contract = null)
		{
			resolver.RegisterConstant(value, typeof(T), contract);
		}

		public static void RegisterLazySingleton(this IMutableDependencyResolver resolver, Func<object> valueFactory, Type serviceType, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			Lazy<object> val = new Lazy<object>(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
			resolver.Register(() => val.Value, serviceType, contract);
		}

		public static void RegisterLazySingleton<T>(this IMutableDependencyResolver resolver, Func<T> valueFactory, string contract = null)
		{
			resolver.RegisterLazySingleton(() => valueFactory(), typeof(T), contract);
		}

		public static void UnregisterCurrent<T>(this IMutableDependencyResolver resolver, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			resolver.UnregisterCurrent(typeof(T), contract);
		}

		public static void UnregisterAll<T>(this IMutableDependencyResolver resolver, string contract = null)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			resolver.UnregisterAll(typeof(T), contract);
		}
	}
	public class FuncDependencyResolver : IDependencyResolver, IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
	{
		private readonly Func<Type, string, IEnumerable<object>> _innerGetServices;

		private readonly Action<Func<object>, Type, string> _innerRegister;

		private readonly Action<Type, string> _unregisterCurrent;

		private readonly Action<Type, string> _unregisterAll;

		private readonly Dictionary<Tuple<Type, string>, List<Action<IDisposable>>> _callbackRegistry = new Dictionary<Tuple<Type, string>, List<Action<IDisposable>>>();

		private IDisposable _inner;

		private bool _isDisposed;

		public FuncDependencyResolver(Func<Type, string, IEnumerable<object>> getAllServices, Action<Func<object>, Type, string> register = null, Action<Type, string> unregisterCurrent = null, Action<Type, string> unregisterAll = null, IDisposable toDispose = null)
		{
			_innerGetServices = getAllServices;
			_innerRegister = register;
			_unregisterCurrent = unregisterCurrent;
			_unregisterAll = unregisterAll;
			_inner = toDispose ?? ActionDisposable.Empty;
		}

		public object GetService(Type serviceType, string contract = null)
		{
			return (GetServices(serviceType, contract) ?? Enumerable.Empty<object>()).LastOrDefault();
		}

		public IEnumerable<object> GetServices(Type serviceType, string contract = null)
		{
			return _innerGetServices(serviceType, contract);
		}

		public bool HasRegistration(Type serviceType, string contract = null)
		{
			return _innerGetServices(serviceType, contract) != null;
		}

		public void Register(Func<object> factory, Type serviceType, string contract = null)
		{
			if (_innerRegister == null)
			{
				throw new NotImplementedException();
			}
			_innerRegister(factory, serviceType, contract);
			Tuple<Type, string> key = Tuple.Create(serviceType, contract ?? string.Empty);
			if (!_callbackRegistry.ContainsKey(key))
			{
				return;
			}
			List<Action<IDisposable>> list = null;
			foreach (Action<IDisposable> item in _callbackRegistry[key])
			{
				BooleanDisposable booleanDisposable = new BooleanDisposable();
				item(booleanDisposable);
				if (booleanDisposable.IsDisposed)
				{
					if (list == null)
					{
						list = new List<Action<IDisposable>>();
					}
					list.Add(item);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (Action<IDisposable> item2 in list)
			{
				_callbackRegistry[key].Remove(item2);
			}
		}

		public void UnregisterCurrent(Type serviceType, string contract = null)
		{
			if (_unregisterCurrent == null)
			{
				throw new NotImplementedException();
			}
			_unregisterCurrent(serviceType, contract);
		}

		public void UnregisterAll(Type serviceType, string contract = null)
		{
			if (_unregisterAll == null)
			{
				throw new NotImplementedException();
			}
			_unregisterAll(serviceType, contract);
		}

		public IDisposable ServiceRegistrationCallback(Type serviceType, string contract, Action<IDisposable> callback)
		{
			Tuple<Type, string> pair = Tuple.Create(serviceType, contract ?? string.Empty);
			if (!_callbackRegistry.ContainsKey(pair))
			{
				_callbackRegistry[pair] = new List<Action<IDisposable>>();
			}
			_callbackRegistry[pair].Add(callback);
			return new ActionDisposable(delegate
			{
				_callbackRegistry[pair].Remove(callback);
			});
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (!_isDisposed)
			{
				if (isDisposing)
				{
					Interlocked.Exchange(ref _inner, ActionDisposable.Empty).Dispose();
				}
				_isDisposed = true;
			}
		}
	}
	public interface IDependencyResolver : IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
	{
	}
	public interface IMutableDependencyResolver
	{
		bool HasRegistration(Type serviceType, string contract = null);

		void Register(Func<object> factory, Type serviceType, string contract = null);

		void UnregisterCurrent(Type serviceType, string contract = null);

		void UnregisterAll(Type serviceType, string contract = null);

		IDisposable ServiceRegistrationCallback(Type serviceType, string contract, Action<IDisposable> callback);
	}
	internal class InternalLocator : IDisposable
	{
		private readonly List<Action> _resolverChanged = new List<Action>();

		private volatile int _resolverChangedNotificationSuspendCount;

		private IDependencyResolver _dependencyResolver;

		public IReadonlyDependencyResolver Current => _dependencyResolver;

		public IMutableDependencyResolver CurrentMutable => _dependencyResolver;

		internal IDependencyResolver Internal => _dependencyResolver;

		internal InternalLocator()
		{
			_dependencyResolver = new ModernDependencyResolver();
			RegisterResolverCallbackChanged(delegate
			{
				if (CurrentMutable != null)
				{
					CurrentMutable.InitializeSplat();
				}
			});
		}

		public void Dispose()
		{
			_dependencyResolver?.Dispose();
		}

		public void SetLocator(IDependencyResolver dependencyResolver)
		{
			_dependencyResolver = dependencyResolver ?? throw new ArgumentNullException("dependencyResolver");
			if (AreResolverCallbackChangedNotificationsEnabled())
			{
				Action[] array = null;
				lock (_resolverChanged)
				{
					array = _resolverChanged.ToArray();
				}
				Action[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i]();
				}
			}
		}

		public IDisposable RegisterResolverCallbackChanged(Action callback)
		{
			lock (_resolverChanged)
			{
				_resolverChanged.Add(callback);
			}
			if (AreResolverCallbackChangedNotificationsEnabled())
			{
				callback();
			}
			return new ActionDisposable(delegate
			{
				lock (_resolverChanged)
				{
					_resolverChanged.Remove(callback);
				}
			});
		}

		public IDisposable SuppressResolverCallbackChangedNotifications()
		{
			Interlocked.Increment(ref _resolverChangedNotificationSuspendCount);
			return new ActionDisposable(delegate
			{
				Interlocked.Decrement(ref _resolverChangedNotificationSuspendCount);
			});
		}

		public bool AreResolverCallbackChangedNotificationsEnabled()
		{
			return _resolverChangedNotificationSuspendCount == 0;
		}
	}
	public interface IReadonlyDependencyResolver
	{
		object GetService(Type serviceType, string contract = null);

		IEnumerable<object> GetServices(Type serviceType, string contract = null);
	}
	public static class Locator
	{
		public static IReadonlyDependencyResolver Current => InternalLocator.Current;

		public static IMutableDependencyResolver CurrentMutable => InternalLocator.CurrentMutable;

		internal static InternalLocator InternalLocator { get; set; }

		static Locator()
		{
			InternalLocator = new InternalLocator();
		}

		public static void SetLocator(IDependencyResolver dependencyResolver)
		{
			InternalLocator.SetLocator(dependencyResolver);
		}

		public static IDependencyResolver GetLocator()
		{
			return InternalLocator.Internal;
		}

		public static IDisposable RegisterResolverCallbackChanged(Action callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			return InternalLocator.RegisterResolverCallbackChanged(callback);
		}

		public static IDisposable SuppressResolverCallbackChangedNotifications()
		{
			return InternalLocator.SuppressResolverCallbackChangedNotifications();
		}

		public static bool AreResolverCallbackChangedNotificationsEnabled()
		{
			return InternalLocator.AreResolverCallbackChangedNotificationsEnabled();
		}
	}
	public class ModernDependencyResolver : IDependencyResolver, IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
	{
		private Dictionary<(Type serviceType, string contract), List<Func<object>>> _registry;

		private Dictionary<(Type serviceType, string contract), List<Action<IDisposable>>> _callbackRegistry;

		private bool _isDisposed;

		public ModernDependencyResolver()
			: this(null)
		{
		}

		protected ModernDependencyResolver(Dictionary<(Type serviceType, string contract), List<Func<object>>> registry)
		{
			_registry = ((registry != null) ? registry.ToDictionary((KeyValuePair<(Type serviceType, string contract), List<Func<object>>> k) => k.Key, (KeyValuePair<(Type serviceType, string contract), List<Func<object>>> v) => v.Value.ToList()) : new Dictionary<(Type, string), List<Func<object>>>());
			_callbackRegistry = new Dictionary<(Type, string), List<Action<IDisposable>>>();
		}

		public bool HasRegistration(Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			if (_registry.TryGetValue(key, out var value))
			{
				return value.Count > 0;
			}
			return false;
		}

		public void Register(Func<object> factory, Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			if (!_registry.ContainsKey(key))
			{
				_registry[key] = new List<Func<object>>();
			}
			_registry[key].Add(factory);
			if (!_callbackRegistry.ContainsKey(key))
			{
				return;
			}
			List<Action<IDisposable>> list = null;
			foreach (Action<IDisposable> item in _callbackRegistry[key])
			{
				BooleanDisposable booleanDisposable = new BooleanDisposable();
				item(booleanDisposable);
				if (booleanDisposable.IsDisposed)
				{
					if (list == null)
					{
						list = new List<Action<IDisposable>>();
					}
					list.Add(item);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (Action<IDisposable> item2 in list)
			{
				_callbackRegistry[key].Remove(item2);
			}
		}

		public object GetService(Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			if (!_registry.ContainsKey(key))
			{
				return null;
			}
			return _registry[key].LastOrDefault()?.Invoke();
		}

		public IEnumerable<object> GetServices(Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			if (!_registry.ContainsKey(key))
			{
				return Enumerable.Empty<object>();
			}
			return _registry[key].Select((Func<object> x) => x()).ToList();
		}

		public void UnregisterCurrent(Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			if (_registry.TryGetValue(key, out var value))
			{
				int num = value.Count - 1;
				if (num >= 0)
				{
					value.RemoveAt(num);
				}
			}
		}

		public void UnregisterAll(Type serviceType, string contract = null)
		{
			(Type, string) key = GetKey(serviceType, contract);
			_registry[key] = new List<Func<object>>();
		}

		public IDisposable ServiceRegistrationCallback(Type serviceType, string contract, Action<IDisposable> callback)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			(Type type, string contract) pair = GetKey(serviceType, contract);
			if (!_callbackRegistry.ContainsKey(pair))
			{
				_callbackRegistry[pair] = new List<Action<IDisposable>>();
			}
			_callbackRegistry[pair].Add(callback);
			ActionDisposable actionDisposable = new ActionDisposable(delegate
			{
				_callbackRegistry[pair].Remove(callback);
			});
			if (_registry.ContainsKey(pair))
			{
				foreach (Func<object> item in _registry[pair])
				{
					_ = item;
					callback(actionDisposable);
				}
			}
			return actionDisposable;
		}

		public ModernDependencyResolver Duplicate()
		{
			return new ModernDependencyResolver(_registry);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (!_isDisposed)
			{
				if (isDisposing)
				{
					_registry = null;
				}
				_isDisposed = true;
			}
		}

		private static (Type type, string contract) GetKey(Type serviceType, string contract = null)
		{
			return (type: serviceType, contract: contract ?? string.Empty);
		}
	}
	public static class ServiceLocationInitialization
	{
		public static void InitializeSplat(this IMutableDependencyResolver resolver)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			RegisterDefaultLogManager(resolver);
			RegisterLogger(resolver);
			RegisterApplicationPerformanceMonitoring(resolver);
		}

		private static void RegisterApplicationPerformanceMonitoring(IMutableDependencyResolver resolver)
		{
			if (!resolver.HasRegistration(typeof(IFeatureUsageTrackingManager)))
			{
				resolver.RegisterConstant(new DefaultFeatureUsageTrackingManager(), typeof(IFeatureUsageTrackingManager));
			}
		}

		private static void RegisterDefaultLogManager(IMutableDependencyResolver resolver)
		{
			if (!resolver.HasRegistration(typeof(ILogManager)))
			{
				resolver.Register(() => new DefaultLogManager(), typeof(ILogManager));
			}
		}

		private static void RegisterLogger(IMutableDependencyResolver resolver)
		{
			if (!resolver.HasRegistration(typeof(ILogger)))
			{
				resolver.RegisterConstant(new DebugLogger(), typeof(ILogger));
			}
		}
	}
	public static class TargetFrameworkExtensions
	{
		public static string GetTargetFrameworkName(this Assembly assembly)
		{
			return GetTargetFrameworkName(assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName);
		}

		internal static string GetTargetFrameworkName(string frameworkName)
		{
			return frameworkName switch
			{
				".NETCoreApp,Version=v5.0" => "net5.0", 
				".NETCoreApp,Version=v3.1" => "netcoreapp3.1", 
				".NETCoreApp,Version=v3.0" => "netcoreapp3.0", 
				".NETCoreApp,Version=v2.2" => "netcoreapp2.2", 
				".NETCoreApp,Version=v2.1" => "netcoreapp2.1", 
				".NETCoreApp,Version=v2.0" => "netcoreapp2.0", 
				".NETCoreApp,Version=v1.1" => "netcoreapp1.1", 
				".NETCoreApp,Version=v1.0" => "netcoreapp1.0", 
				".NETStandard,Version=v2.1" => "netstandard2.1", 
				".NETStandard,Version=v2.0" => "netstandard2.0", 
				".NETStandard,Version=v1.6" => "netstandard1.6", 
				".NETStandard,Version=v1.5" => "netstandard1.5", 
				".NETStandard,Version=v1.4" => "netstandard1.4", 
				".NETStandard,Version=v1.3" => "netstandard1.3", 
				".NETStandard,Version=v1.2" => "netstandard1.2", 
				".NETStandard,Version=v1.1" => "netstandard1.1", 
				".NETStandard,Version=v1.0" => "netstandard1.0", 
				".NETFramework,Version=v4.8" => "net48", 
				".NETFramework,Version=v4.7.2" => "net472", 
				".NETFramework,Version=v4.7.1" => "net471", 
				".NETFramework,Version=v4.7" => "net47", 
				".NETFramework,Version=v4.6.2" => "net462", 
				".NETFramework,Version=v4.6.1" => "net461", 
				".NETFramework,Version=v4.6" => "net46", 
				".NETFramework,Version=v4.5.2" => "net452", 
				".NETFramework,Version=v4.5.1" => "net451", 
				".NETFramework,Version=v4.5" => "net45", 
				".NETFramework,Version=v4.0.3" => "net403", 
				".NETFramework,Version=v4.0" => "net40", 
				".NETFramework,Version=v3.5" => "net35", 
				".NETFramework,Version=v2.0" => "net20", 
				".NETFramework,Version=v1.1" => "net11", 
				_ => null, 
			};
		}
	}
}
namespace Splat.ApplicationPerformanceMonitoring
{
	public sealed class DefaultFeatureUsageTrackingManager : FuncFeatureUsageTrackingManager
	{
		public DefaultFeatureUsageTrackingManager()
			: base((string featureName) => new DefaultFeatureUsageTrackingSession(featureName))
		{
		}
	}
	public sealed class DefaultFeatureUsageTrackingSession : IFeatureUsageTrackingSession<Guid>, IFeatureUsageTrackingSession, IDisposable, IEnableLogger
	{
		public Guid ParentReference { get; }

		public Guid FeatureReference { get; }

		public string FeatureName { get; }

		public DefaultFeatureUsageTrackingSession(string featureName)
			: this(featureName, Guid.Empty)
		{
		}

		internal DefaultFeatureUsageTrackingSession(string featureName, Guid parentReference)
		{
			if (string.IsNullOrWhiteSpace(featureName))
			{
				throw new ArgumentNullException("featureName");
			}
			ParentReference = parentReference;
			FeatureName = featureName;
			FeatureReference = Guid.NewGuid();
			this.Log().Info(GetSessionStartLogMessage);
		}

		public IFeatureUsageTrackingSession SubFeature(string description)
		{
			return new DefaultFeatureUsageTrackingSession(description, FeatureReference);
		}

		public void OnException(Exception exception)
		{
			this.Log().InfoException(() => "Feature Usage Tracking Exception", exception);
		}

		public void Dispose()
		{
			this.Log().Info(() => $"Feature Finish: {FeatureReference}");
		}

		private string GetSessionStartLogMessage()
		{
			string text = $"Feature Start. Reference={FeatureReference}{((ParentReference != Guid.Empty) ? $", Parent Reference={ParentReference}" : null)}";
			if (ParentReference != Guid.Empty)
			{
				text += $", Parent Reference={ParentReference}";
			}
			return text;
		}
	}
	public static class EnableFeatureUsageTrackingExtensions
	{
		public static IFeatureUsageTrackingSession FeatureUsageTrackingSession(this IEnableFeatureUsageTracking instance, string featureName)
		{
			return (Locator.Current.GetService<IFeatureUsageTrackingManager>() ?? throw new Exception("Feature Usage Tracking Manager is null. This should never happen, your dependency resolver is broken")).GetFeatureUsageTrackingSession(featureName);
		}
	}
	public class FuncFeatureUsageTrackingManager : IFeatureUsageTrackingManager
	{
		private readonly Func<string, IFeatureUsageTrackingSession> _featureUsageTrackingSessionFunc;

		public FuncFeatureUsageTrackingManager(Func<string, IFeatureUsageTrackingSession> featureUsageTrackingSessionFunc)
		{
			_featureUsageTrackingSessionFunc = featureUsageTrackingSessionFunc ?? throw new ArgumentNullException("featureUsageTrackingSessionFunc");
		}

		public IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName)
		{
			return _featureUsageTrackingSessionFunc(featureName);
		}
	}
	[ComVisible(false)]
	public interface IEnableFeatureUsageTracking
	{
	}
	public interface IFeatureUsageTrackingManager
	{
		IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName);
	}
	public interface IFeatureUsageTrackingSession : IDisposable
	{
		string FeatureName { get; }

		IFeatureUsageTrackingSession SubFeature(string description);

		void OnException(Exception exception);
	}
	public interface IFeatureUsageTrackingSession<out TReferenceType> : IFeatureUsageTrackingSession, IDisposable
	{
		TReferenceType FeatureReference { get; }

		TReferenceType ParentReference { get; }
	}
	public interface IViewTracking
	{
		void OnViewNavigation(string name);
	}
}
