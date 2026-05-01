using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;
using System.Threading;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("ANRWatchDog")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ANRWatchDog")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.4.25")]
[assembly: TargetFramework("MonoAndroid,Version=v4.4", FrameworkDisplayName = "Xamarin.Android v4.4 Support")]
[assembly: AssemblyVersion("1.4.25.0")]
namespace Xamarin.ANRWatchDog;

[Serializable]
public class ANRError : Error, ISerializable
{
	[Serializable]
	private class _ThreadTrace : ISerializable
	{
		[Serializable]
		internal class _Thread : Throwable, ISerializable
		{
			[SecuritySafeCritical]
			protected _Thread(SerializationInfo info, StreamingContext context)
				: base(info.GetString("Name"))
			{
			}

			internal _Thread(_Thread other)
				: base(Name, other)
			{
			}

			public override Throwable FillInStackTrace()
			{
				SetStackTrace(_ThreadTrace.StackTrace);
				return this;
			}

			public override void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				base.GetObjectData(info, context);
				info.AddValue("Name", Name);
			}
		}

		public static string Name { get; private set; }

		public static StackTraceElement[] StackTrace { get; private set; }

		[SecuritySafeCritical]
		protected _ThreadTrace(SerializationInfo info, StreamingContext context)
		{
			Name = info.GetString("Name");
			StackTrace = (StackTraceElement[])info.GetValue("StackTrace", typeof(StackTraceElement[]));
		}

		internal _ThreadTrace(string name, StackTraceElement[] stackTrace)
		{
			Name = name;
			StackTrace = stackTrace;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("StackTrace", StackTrace);
		}
	}

	private class _StackTraceComparer : IEqualityComparer<Java.Lang.Thread>
	{
		private readonly Java.Lang.Thread _mainThread;

		public _StackTraceComparer(Java.Lang.Thread mainThread)
		{
			_mainThread = mainThread;
		}

		public bool Equals(Java.Lang.Thread lhs, Java.Lang.Thread rhs)
		{
			if (lhs == rhs)
			{
				return true;
			}
			if (lhs == _mainThread)
			{
				return false;
			}
			if (rhs == _mainThread)
			{
				return false;
			}
			return rhs.Name.Equals(lhs.Name);
		}

		public int GetHashCode(Java.Lang.Thread obj)
		{
			return obj.GetHashCode();
		}
	}

	private const long SERIAL_VERSION_UID = 1L;

	public readonly long Duration;

	[SecuritySafeCritical]
	protected ANRError(SerializationInfo info, StreamingContext context)
	{
		Duration = info.GetInt64("Duration");
		base.InitCause((Throwable)info.GetValue("Cause", typeof(Throwable)));
	}

	private ANRError(_ThreadTrace._Thread st, long duration)
		: base("Application Not Responding", st)
	{
		Duration = duration;
	}

	public override Throwable FillInStackTrace()
	{
		SetStackTrace(new StackTraceElement[0]);
		return this;
	}

	public static ANRError New(long duration, string prefix, bool logThreadsWithoutStackTrace)
	{
		Java.Lang.Thread thread = Looper.MainLooper.Thread;
		Dictionary<Java.Lang.Thread, StackTraceElement[]> dictionary = new Dictionary<Java.Lang.Thread, StackTraceElement[]>(new _StackTraceComparer(thread));
		foreach (KeyValuePair<Java.Lang.Thread, StackTraceElement[]> allStackTrace in Java.Lang.Thread.AllStackTraces)
		{
			if (allStackTrace.Key == thread || (allStackTrace.Key.Name.StartsWith(prefix, StringComparison.Ordinal) && (logThreadsWithoutStackTrace || allStackTrace.Value.Length != 0)))
			{
				dictionary.Add(allStackTrace.Key, allStackTrace.Value);
			}
		}
		if (!dictionary.ContainsKey(thread))
		{
			dictionary.Add(thread, thread.GetStackTrace());
		}
		_ThreadTrace._Thread thread2 = null;
		foreach (KeyValuePair<Java.Lang.Thread, StackTraceElement[]> item in dictionary)
		{
			new _ThreadTrace(GetThreadTitle(item.Key), item.Value);
			thread2 = new _ThreadTrace._Thread(thread2);
		}
		return new ANRError(thread2, duration);
	}

	public static ANRError NewMainOnly(long duration)
	{
		Java.Lang.Thread thread = Looper.MainLooper.Thread;
		new _ThreadTrace(stackTrace: thread.GetStackTrace(), name: GetThreadTitle(thread));
		return new ANRError(new _ThreadTrace._Thread(null), duration);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("Duration", Duration);
		info.AddValue("Cause", Cause);
	}

	private static string GetThreadTitle(Java.Lang.Thread thread)
	{
		return $"{thread.Name} (state = {thread.GetState()})";
	}
}
public class ANRWatchDog : Java.Lang.Thread, IRunnable, IJavaObject, IDisposable
{
	public interface IANRListener
	{
		void OnAppNotResponding(ANRError error);
	}

	public interface IANRInterceptor
	{
		long Intercept(long duration);
	}

	public interface IInterruptionListener
	{
		void OnInterrupted(InterruptedException e);
	}

	private class DefaultANRListener : IANRListener
	{
		public void OnAppNotResponding(ANRError error)
		{
			throw error;
		}
	}

	public class DefaultANRInterceptor : IANRInterceptor
	{
		public long Intercept(long duration)
		{
			return 0L;
		}
	}

	private class DefaultInterruptionListener : IInterruptionListener
	{
		public void OnInterrupted(InterruptedException e)
		{
			Log.Warn("ANRWatchdog", "Interrupted: " + e.Message);
		}
	}

	private const int DEFAULT_ANR_TIMEOUT = 5000;

	private IANRListener _anrListener = new DefaultANRListener();

	private IANRInterceptor _anrInterceptor = new DefaultANRInterceptor();

	private IInterruptionListener _interruptionListener = new DefaultInterruptionListener();

	private readonly Handler _uiHandler = new Handler(Looper.MainLooper);

	public readonly int TimeoutInterval;

	private string _namePrefix = "";

	private bool _logThreadsWithoutStackTrace;

	private bool _ignoreDebugger;

	private bool _isDisposed;

	private long _tick;

	private volatile bool _reported;

	public ANRWatchDog()
		: this(5000)
	{
	}

	public ANRWatchDog(int timeoutInterval)
	{
		TimeoutInterval = timeoutInterval;
	}

	public ANRWatchDog SetANRListener(IANRListener listener)
	{
		_anrListener = listener ?? new DefaultANRListener();
		return this;
	}

	public ANRWatchDog SetANRInterceptor(IANRInterceptor interceptor)
	{
		_anrInterceptor = interceptor ?? new DefaultANRInterceptor();
		return this;
	}

	public ANRWatchDog SetInterruptionListener(IInterruptionListener listener)
	{
		_interruptionListener = listener ?? new DefaultInterruptionListener();
		return this;
	}

	public ANRWatchDog SetReportThreadNamePrefix(string prefix)
	{
		_namePrefix = prefix ?? string.Empty;
		return this;
	}

	public ANRWatchDog SetReportMainThreadOnly()
	{
		_namePrefix = null;
		return this;
	}

	public ANRWatchDog SetReportAllThreads()
	{
		_namePrefix = string.Empty;
		return this;
	}

	public ANRWatchDog SetLogThreadsWithoutStackTrace(bool logThreadsWithoutStackTrace)
	{
		_logThreadsWithoutStackTrace = logThreadsWithoutStackTrace;
		return this;
	}

	public ANRWatchDog SetIgnoreDebugger(bool ignoreDebugger)
	{
		_ignoreDebugger = ignoreDebugger;
		return this;
	}

	public override void Run()
	{
		base.Name = "|ANR-WatchDog|";
		long num = TimeoutInterval;
		while (!_isDisposed && base.IsAlive && !IsInterrupted)
		{
			bool num2 = Interlocked.Read(ref _tick) == 0;
			Interlocked.Exchange(ref _tick, _tick + num);
			if (num2)
			{
				_uiHandler.Post(delegate
				{
					Interlocked.Exchange(ref _tick, 0L);
					_reported = false;
				});
			}
			try
			{
				Java.Lang.Thread.Sleep(num);
			}
			catch (InterruptedException e)
			{
				_interruptionListener?.OnInterrupted(e);
			}
			if (Interlocked.Read(ref _tick) == 0L || _reported)
			{
				continue;
			}
			if ((!_ignoreDebugger && (Debug.IsDebuggerConnected || Debug.WaitingForDebugger())) || Debugger.IsAttached)
			{
				Log.Warn("ANRWatchdog", "An ANR was detected but ignored because the debugger is connected (you can prevent this with setIgnoreDebugger(true))");
				_reported = true;
				continue;
			}
			num = _anrInterceptor.Intercept(Interlocked.Read(ref _tick));
			if (num <= 0)
			{
				ANRError error = ((_namePrefix != null) ? ANRError.New(Interlocked.Read(ref _tick), _namePrefix, _logThreadsWithoutStackTrace) : ANRError.NewMainOnly(Interlocked.Read(ref _tick)));
				_anrListener?.OnAppNotResponding(error);
				num = TimeoutInterval;
				_reported = true;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!_isDisposed && disposing)
		{
			_isDisposed = true;
			_anrListener = null;
			_interruptionListener = null;
		}
		base.Dispose(disposing);
	}
}
