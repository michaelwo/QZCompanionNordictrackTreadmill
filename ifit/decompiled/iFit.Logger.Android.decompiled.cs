using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using NLog;
using NLog.Config;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("iFit.Logger.Android.Resource", IsApplication = false)]
[assembly: AssemblyTitle("iFit.Logger.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: TargetFramework("MonoAndroid,Version=v8.0", FrameworkDisplayName = "Xamarin.Android v8.0 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Logger.Android;

[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
public class Resource
{
	public class Attribute
	{
		static Attribute()
		{
			ResourceIdManager.UpdateIdValues();
		}

		private Attribute()
		{
		}
	}

	static Resource()
	{
		ResourceIdManager.UpdateIdValues();
	}
}
public class Logger : ILogger
{
	protected const string TagVarKey = "tag";

	protected const string UptimeVarKey = "uptime";

	protected readonly NLog.Logger logger;

	protected readonly LoggingConfiguration config;

	public Logger(params NLogRule[] rules)
	{
		config = new LoggingConfiguration();
		foreach (NLogRule nLogRule in rules)
		{
			config.AddTarget(nLogRule.Target.GetType().Name, nLogRule.Target);
			config.AddRule(nLogRule.MinLevel.ToNLog(), nLogRule.MaxLevel.ToNLog(), nLogRule.Target);
		}
		LogManager.Configuration = config;
		logger = LogManager.GetCurrentClassLogger();
	}

	public virtual void Log(LogLevel level, string tag, string text, Exception exception = null)
	{
		LogEventInfo logEventInfo = new LogEventInfo(level.ToNLog(), string.Empty, text);
		logEventInfo.Exception = exception;
		if (string.IsNullOrWhiteSpace(tag))
		{
			config.Variables.Remove("tag");
		}
		else
		{
			config.Variables["tag"] = tag;
		}
		string text2 = string.Empty;
		try
		{
			text2 = SystemClock.ElapsedRealtime().ToString();
		}
		catch (Exception)
		{
		}
		config.Variables["uptime"] = text2;
		logger.Log(logEventInfo);
	}
}
