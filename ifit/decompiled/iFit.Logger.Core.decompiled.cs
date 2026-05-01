using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using NLog;
using NLog.Targets;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit's base logger")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Logger.Core")]
[assembly: AssemblyTitle("iFit.Logger.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Logger;

public interface ILogger
{
	void Log(LogLevel level, string tag, string text, Exception exception = null);
}
public enum TagMode
{
	Blacklist,
	Whitelist
}
public static class Log
{
	private static readonly HashSet<string> tags = new HashSet<string>();

	private static ILogger logger;

	public static TagMode TagMode { get; set; }

	public static bool AreLogsEnabled { get; set; } = true;

	public static void SetupLogger(ILogger newLogger, TagMode tagMode)
	{
		logger = newLogger;
		AreLogsEnabled = true;
		tags.Clear();
		TagMode = tagMode;
	}

	public static void AddTag(string tag)
	{
		AddTags(tag);
	}

	public static void RemoveTag(string tag)
	{
		RemoveTags(tag);
	}

	public static void AddTags(params string[] tagsToAdd)
	{
		if (tagsToAdd == null || tagsToAdd.Length == 0)
		{
			return;
		}
		foreach (string text in tagsToAdd)
		{
			if (!string.IsNullOrWhiteSpace(text) && !tags.Contains(text))
			{
				tags.Add(text);
			}
		}
	}

	public static void RemoveTags(params string[] tagsToRemove)
	{
		if (tagsToRemove == null || tagsToRemove.Length == 0)
		{
			return;
		}
		foreach (string text in tagsToRemove)
		{
			if (!string.IsNullOrWhiteSpace(text) && tags.Contains(text))
			{
				tags.Remove(text);
			}
		}
	}

	public static void Trace(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Trace, tag, text, exception);
	}

	public static void Debug(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Debug, tag, text, exception);
	}

	public static void Info(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Info, tag, text, exception);
	}

	public static void Warn(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Warn, tag, text, exception);
	}

	public static void Error(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Error, tag, text, exception);
	}

	public static void Fatal(string tag, string text, Exception exception = null)
	{
		DoLog(LogLevel.Fatal, tag, text, exception);
	}

	private static void DoLog(LogLevel level, string tag, string text, Exception exception)
	{
		if (CanLog(tag, text))
		{
			logger.Log(level, tag, text, exception);
		}
	}

	private static bool CanLog(string tag, string text)
	{
		if (logger == null)
		{
			return false;
		}
		if (!AreLogsEnabled)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(tag))
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		if (TagMode == TagMode.Blacklist && tags.Contains(tag))
		{
			return false;
		}
		if (TagMode == TagMode.Whitelist && !tags.Contains(tag))
		{
			return false;
		}
		return true;
	}
}
public static class LogExtensions
{
	[Obsolete("This usage is deprecated and needs to be switched to 'Log.[LogType] (tag, text)'", true)]
	public static void Log(this object _, string tag, string text, Exception exception = null)
	{
		iFit.Logger.Log.Trace(tag, text, exception);
	}
}
public enum LogLevel
{
	Trace,
	Debug,
	Info,
	Warn,
	Error,
	Fatal
}
public static class LogLevelExtensions
{
	public static NLog.LogLevel ToNLog(this LogLevel level)
	{
		return level switch
		{
			LogLevel.Trace => NLog.LogLevel.Trace, 
			LogLevel.Debug => NLog.LogLevel.Debug, 
			LogLevel.Info => NLog.LogLevel.Info, 
			LogLevel.Warn => NLog.LogLevel.Warn, 
			LogLevel.Error => NLog.LogLevel.Error, 
			LogLevel.Fatal => NLog.LogLevel.Fatal, 
			_ => NLog.LogLevel.Trace, 
		};
	}
}
public sealed class NLogRule
{
	public LogLevel MinLevel { get; }

	public LogLevel MaxLevel { get; }

	public Target Target { get; }

	public NLogRule(Target target, LogLevel minLevel = LogLevel.Trace, LogLevel maxLevel = LogLevel.Fatal)
	{
		Target = target;
		MinLevel = minLevel;
		MaxLevel = maxLevel;
	}
}
public static class TargetFactory
{
	public const string DefaultFileLogLayout = "${var:uptime:default=None} ${time} [${level}:${var:tag:default=None}] ${message}${onexception:inner=\\: ${exception}}";

	public const string DefaultConsoleLogLayout = "[${level}:${var:tag:default=None}] ${message}${onexception:inner=\\: ${exception}}";

	public const string DefaultFileNameLayout = "${shortdate}_logs.txt";

	public static ConsoleTarget CreateConsoleTarget(string logLayout = "[${level}:${var:tag:default=None}] ${message}${onexception:inner=\\: ${exception}}")
	{
		return new ConsoleTarget
		{
			Layout = logLayout
		};
	}

	public static FileTarget CreateFileTarget(string dirPath, string logLayout = "${var:uptime:default=None} ${time} [${level}:${var:tag:default=None}] ${message}${onexception:inner=\\: ${exception}}", string fileNameLayout = "${shortdate}_logs.txt", FileArchivePeriod archiveEvery = FileArchivePeriod.Day)
	{
		return new FileTarget
		{
			Layout = logLayout,
			ArchiveEvery = archiveEvery,
			FileName = Path.Combine(dirPath, fileNameLayout),
			MaxArchiveFiles = 14
		};
	}
}
