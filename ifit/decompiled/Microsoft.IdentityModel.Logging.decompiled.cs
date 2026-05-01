using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyInformationalVersion("5.6.0.61018232319.2574f3cbc3736db085497b9b241ea5ae338357b9")]
[assembly: AssemblyFileVersion("5.6.0.61018")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Includes Event Source based logging support.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("Microsoft.IdentityModel.Logging")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace Microsoft.IdentityModel.Logging;

[EventSource(Name = "Microsoft.IdentityModel.EventSource")]
public class IdentityModelEventSource : EventSource
{
	private static string _versionLogMessage;

	private static string _dateLogMessage;

	private static string _piiOffLogMessage;

	private static string _piiOnLogMessage;

	public static IdentityModelEventSource Logger { get; }

	public static bool ShowPII { get; set; }

	public static string HiddenPIIString { get; }

	public static bool HeaderWritten { get; set; }

	public EventLevel LogLevel { get; set; }

	static IdentityModelEventSource()
	{
		ShowPII = false;
		HiddenPIIString = "[PII is hidden. For more details, see https://aka.ms/IdentityModel/PII.]";
		HeaderWritten = false;
		_versionLogMessage = "Library version: {0}.";
		_dateLogMessage = "Date: {0}.";
		_piiOffLogMessage = "PII (personally identifiable information) logging is currently turned off. Set IdentityModelEventSource.ShowPII to 'true' to view the full details of exceptions.";
		_piiOnLogMessage = "PII (personally identifiable information) logging is currently turned on. Set IdentityModelEventSource.ShowPII to 'false' to hide PII from log messages.";
		Logger = new IdentityModelEventSource();
	}

	private IdentityModelEventSource()
	{
		LogLevel = EventLevel.Warning;
	}

	[Event(6, Level = EventLevel.LogAlways)]
	public void WriteAlways(string message)
	{
		if (IsEnabled())
		{
			message = PrepareMessage(EventLevel.LogAlways, message);
			WriteEvent(6, message);
		}
	}

	[NonEvent]
	public void WriteAlways(string message, params object[] args)
	{
		if (IsEnabled())
		{
			if (args != null)
			{
				WriteAlways(LogHelper.FormatInvariant(message, args));
			}
			else
			{
				WriteAlways(message);
			}
		}
	}

	[Event(1, Level = EventLevel.Verbose)]
	public void WriteVerbose(string message)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Verbose)
		{
			message = PrepareMessage(EventLevel.Verbose, message);
			WriteEvent(1, message);
		}
	}

	[NonEvent]
	public void WriteVerbose(string message, params object[] args)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Verbose)
		{
			if (args != null)
			{
				WriteVerbose(LogHelper.FormatInvariant(message, args));
			}
			else
			{
				WriteVerbose(message);
			}
		}
	}

	[Event(2, Level = EventLevel.Informational)]
	public void WriteInformation(string message)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Informational)
		{
			message = PrepareMessage(EventLevel.Informational, message);
			WriteEvent(2, message);
		}
	}

	[NonEvent]
	public void WriteInformation(string message, params object[] args)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Informational)
		{
			if (args != null)
			{
				WriteInformation(LogHelper.FormatInvariant(message, args));
			}
			else
			{
				WriteInformation(message);
			}
		}
	}

	[Event(3, Level = EventLevel.Warning)]
	public void WriteWarning(string message)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Warning)
		{
			message = PrepareMessage(EventLevel.Warning, message);
			WriteEvent(3, message);
		}
	}

	[NonEvent]
	public void WriteWarning(string message, params object[] args)
	{
		if (args != null)
		{
			WriteWarning(LogHelper.FormatInvariant(message, args));
		}
		else
		{
			WriteWarning(message);
		}
	}

	[Event(4, Level = EventLevel.Error)]
	public void WriteError(string message)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Error)
		{
			message = PrepareMessage(EventLevel.Error, message);
			WriteEvent(4, message);
		}
	}

	[NonEvent]
	public void WriteError(string message, params object[] args)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Error)
		{
			if (args != null)
			{
				WriteError(LogHelper.FormatInvariant(message, args));
			}
			else
			{
				WriteError(message);
			}
		}
	}

	[Event(5, Level = EventLevel.Critical)]
	public void WriteCritical(string message)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Critical)
		{
			message = PrepareMessage(EventLevel.Critical, message);
			WriteEvent(5, message);
		}
	}

	[NonEvent]
	public void WriteCritical(string message, params object[] args)
	{
		if (IsEnabled() && LogLevel >= EventLevel.Critical)
		{
			if (args != null)
			{
				WriteCritical(LogHelper.FormatInvariant(message, args));
			}
			else
			{
				WriteCritical(message);
			}
		}
	}

	[NonEvent]
	public void Write(EventLevel level, Exception innerException, string message)
	{
		Write(level, innerException, message, null);
	}

	[NonEvent]
	public void Write(EventLevel level, Exception innerException, string message, params object[] args)
	{
		if (innerException != null)
		{
			message = ((ShowPII || LogHelper.IsCustomException(innerException)) ? string.Format(CultureInfo.InvariantCulture, "Message: {0}, InnerException: {1}", message, innerException.Message) : string.Format(CultureInfo.InvariantCulture, "Message: {0}, InnerException: {1}", message, innerException.GetType()));
		}
		if (!HeaderWritten)
		{
			WriteAlways(string.Format(CultureInfo.InvariantCulture, _versionLogMessage, typeof(IdentityModelEventSource).GetTypeInfo().Assembly.GetName().Version.ToString()));
			WriteAlways(string.Format(CultureInfo.InvariantCulture, _dateLogMessage, DateTime.UtcNow));
			if (ShowPII)
			{
				WriteAlways(_piiOnLogMessage);
			}
			else
			{
				WriteAlways(_piiOffLogMessage);
			}
			HeaderWritten = true;
		}
		switch (level)
		{
		case EventLevel.LogAlways:
			WriteAlways(message, args);
			return;
		case EventLevel.Critical:
			WriteCritical(message, args);
			return;
		case EventLevel.Error:
			WriteError(message, args);
			return;
		case EventLevel.Warning:
			WriteWarning(message, args);
			return;
		case EventLevel.Informational:
			WriteInformation(message, args);
			return;
		case EventLevel.Verbose:
			WriteVerbose(message, args);
			return;
		}
		WriteError(LogHelper.FormatInvariant("MIML10002: Unknown log level: {0}.", level));
		WriteError(message, args);
	}

	private string PrepareMessage(EventLevel level, string message, params object[] args)
	{
		if (message == null)
		{
			return string.Empty;
		}
		try
		{
			if (args != null && args.Length != 0)
			{
				return string.Format(CultureInfo.InvariantCulture, "[{0}]{1} {2}", level.ToString(), DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), LogHelper.FormatInvariant(message, args));
			}
			return string.Format(CultureInfo.InvariantCulture, "[{0}]{1} {2}", level.ToString(), DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), message);
		}
		catch
		{
		}
		try
		{
			return LogHelper.FormatInvariant("[{0}]{1} {2}", level.ToString(), DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), message);
		}
		catch (Exception)
		{
			return string.Concat(level, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), message);
		}
	}
}
public class LogHelper
{
	private static readonly List<string> CustomExceptionTypePrefixes = new List<string> { "Microsoft.IdentityModel.Protocols", "Microsoft.IdentityModel.Tokens.SecurityToken", "Microsoft.IdentityModel.Tokens.Saml", "Microsoft.IdentityModel.Xml" };

	public static ArgumentNullException LogArgumentNullException(string argument)
	{
		return LogArgumentException<ArgumentNullException>(EventLevel.Error, argument, "IDX10000: The parameter '{0}' cannot be a 'null' or an empty object.", new object[1] { argument });
	}

	public static T LogException<T>(string message) where T : Exception
	{
		return LogException<T>(EventLevel.Error, null, message, null);
	}

	public static T LogArgumentException<T>(string argumentName, string message) where T : ArgumentException
	{
		return LogArgumentException<T>(EventLevel.Error, argumentName, null, message, null);
	}

	public static T LogException<T>(string format, params object[] args) where T : Exception
	{
		return LogException<T>(EventLevel.Error, null, format, args);
	}

	public static T LogArgumentException<T>(string argumentName, string format, params object[] args) where T : ArgumentException
	{
		return LogArgumentException<T>(EventLevel.Error, argumentName, null, format, args);
	}

	public static T LogException<T>(Exception innerException, string message) where T : Exception
	{
		return LogException<T>(EventLevel.Error, innerException, message, null);
	}

	public static T LogArgumentException<T>(string argumentName, Exception innerException, string message) where T : ArgumentException
	{
		return LogArgumentException<T>(EventLevel.Error, argumentName, innerException, message, null);
	}

	public static T LogException<T>(Exception innerException, string format, params object[] args) where T : Exception
	{
		return LogException<T>(EventLevel.Error, innerException, format, args);
	}

	public static T LogArgumentException<T>(string argumentName, Exception innerException, string format, params object[] args) where T : ArgumentException
	{
		return LogArgumentException<T>(EventLevel.Error, argumentName, innerException, format, args);
	}

	public static T LogException<T>(EventLevel eventLevel, string message) where T : Exception
	{
		return LogException<T>(eventLevel, null, message, null);
	}

	public static T LogArgumentException<T>(EventLevel eventLevel, string argumentName, string message) where T : ArgumentException
	{
		return LogArgumentException<T>(eventLevel, argumentName, null, message, null);
	}

	public static T LogException<T>(EventLevel eventLevel, string format, params object[] args) where T : Exception
	{
		return LogException<T>(eventLevel, null, format, args);
	}

	public static T LogArgumentException<T>(EventLevel eventLevel, string argumentName, string format, params object[] args) where T : ArgumentException
	{
		return LogArgumentException<T>(eventLevel, argumentName, null, format, args);
	}

	public static T LogException<T>(EventLevel eventLevel, Exception innerException, string message) where T : Exception
	{
		return LogException<T>(eventLevel, innerException, message, null);
	}

	public static T LogArgumentException<T>(EventLevel eventLevel, string argumentName, Exception innerException, string message) where T : ArgumentException
	{
		return LogArgumentException<T>(eventLevel, argumentName, innerException, message, null);
	}

	public static T LogException<T>(EventLevel eventLevel, Exception innerException, string format, params object[] args) where T : Exception
	{
		return LogExceptionImpl<T>(eventLevel, null, innerException, format, args);
	}

	public static T LogArgumentException<T>(EventLevel eventLevel, string argumentName, Exception innerException, string format, params object[] args) where T : ArgumentException
	{
		return LogExceptionImpl<T>(eventLevel, argumentName, innerException, format, args);
	}

	public static Exception LogExceptionMessage(Exception exception)
	{
		return LogExceptionMessage(EventLevel.Error, exception);
	}

	public static Exception LogExceptionMessage(EventLevel eventLevel, Exception exception)
	{
		if (IdentityModelEventSource.Logger.IsEnabled() && IdentityModelEventSource.Logger.LogLevel >= eventLevel)
		{
			IdentityModelEventSource.Logger.Write(eventLevel, exception.InnerException, exception.Message);
		}
		return exception;
	}

	public static void LogInformation(string message, params object[] args)
	{
		if (IdentityModelEventSource.Logger.IsEnabled())
		{
			IdentityModelEventSource.Logger.WriteInformation(message, args);
		}
	}

	public static void LogVerbose(string message, params object[] args)
	{
		if (IdentityModelEventSource.Logger.IsEnabled())
		{
			IdentityModelEventSource.Logger.WriteVerbose(message, args);
		}
	}

	public static void LogWarning(string message, params object[] args)
	{
		if (IdentityModelEventSource.Logger.IsEnabled())
		{
			IdentityModelEventSource.Logger.WriteWarning(message, args);
		}
	}

	private static T LogExceptionImpl<T>(EventLevel eventLevel, string argumentName, Exception innerException, string format, params object[] args) where T : Exception
	{
		string text = null;
		text = ((args == null) ? format : string.Format(CultureInfo.InvariantCulture, format, args));
		if (IdentityModelEventSource.Logger.IsEnabled() && IdentityModelEventSource.Logger.LogLevel >= eventLevel)
		{
			IdentityModelEventSource.Logger.Write(eventLevel, innerException, text);
		}
		if (innerException != null)
		{
			if (string.IsNullOrEmpty(argumentName))
			{
				return (T)Activator.CreateInstance(typeof(T), text, innerException);
			}
			return (T)Activator.CreateInstance(typeof(T), argumentName, text, innerException);
		}
		if (string.IsNullOrEmpty(argumentName))
		{
			return (T)Activator.CreateInstance(typeof(T), text);
		}
		return (T)Activator.CreateInstance(typeof(T), argumentName, text);
	}

	public static string FormatInvariant(string format, params object[] args)
	{
		if (!IdentityModelEventSource.ShowPII)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			object[] args2 = args.Select(RemovePII).ToArray();
			return string.Format(invariantCulture, format, args2);
		}
		return string.Format(CultureInfo.InvariantCulture, format, args);
	}

	private static string RemovePII(object arg)
	{
		if (arg is Exception)
		{
			Exception ex = arg as Exception;
			if (IsCustomException(ex))
			{
				return ex.ToString();
			}
			return ex.GetType().ToString();
		}
		return IdentityModelEventSource.HiddenPIIString;
	}

	internal static bool IsCustomException(Exception ex)
	{
		if (CustomExceptionTypePrefixes.Exists((string e) => ex.GetType().FullName.Contains(e)))
		{
			return true;
		}
		return false;
	}
}
internal static class LogMessages
{
	internal const string MIML10000 = "MIML10000: eventData.Payload is null or empty. Not logging any messages.";

	internal const string MIML10001 = "MIML10001: Cannot create the fileStream or StreamWriter to write logs. See inner exception.";

	internal const string MIML10002 = "MIML10002: Unknown log level: {0}.";
}
public class TextWriterEventListener : EventListener
{
	private StreamWriter _streamWriter;

	private bool _disposeStreamWriter = true;

	public static readonly string DefaultLogFileName = "IdentityModelLogs.txt";

	public TextWriterEventListener()
	{
		try
		{
			Stream stream = new FileStream(DefaultLogFileName, FileMode.OpenOrCreate, FileAccess.Write);
			_streamWriter = new StreamWriter(stream);
			_streamWriter.AutoFlush = true;
		}
		catch (Exception innerException)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException("MIML10001: Cannot create the fileStream or StreamWriter to write logs. See inner exception.", innerException));
			throw;
		}
	}

	public TextWriterEventListener(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			throw LogHelper.LogArgumentNullException("filePath");
		}
		try
		{
			Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
			_streamWriter = new StreamWriter(stream);
			_streamWriter.AutoFlush = true;
		}
		catch (Exception innerException)
		{
			LogHelper.LogExceptionMessage(new InvalidOperationException("MIML10001: Cannot create the fileStream or StreamWriter to write logs. See inner exception.", innerException));
			throw;
		}
	}

	public TextWriterEventListener(StreamWriter streamWriter)
	{
		if (streamWriter == null)
		{
			throw LogHelper.LogArgumentNullException("streamWriter");
		}
		_streamWriter = streamWriter;
		_disposeStreamWriter = false;
	}

	protected override void OnEventWritten(EventWrittenEventArgs eventData)
	{
		if (eventData == null)
		{
			throw LogHelper.LogArgumentNullException("eventData");
		}
		if (eventData.Payload == null || eventData.Payload.Count <= 0)
		{
			LogHelper.LogInformation("MIML10000: eventData.Payload is null or empty. Not logging any messages.");
			return;
		}
		for (int i = 0; i < eventData.Payload.Count; i++)
		{
			_streamWriter.WriteLine(eventData.Payload[i].ToString());
		}
	}

	public override void Dispose()
	{
		if (_disposeStreamWriter && _streamWriter != null)
		{
			_streamWriter.Flush();
			_streamWriter.Dispose();
		}
		base.Dispose();
	}
}
