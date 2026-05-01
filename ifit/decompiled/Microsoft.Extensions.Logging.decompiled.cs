using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using Microsoft.Extensions.Options;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.Logging.Configuration, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "6dffd8b4f6b6e2204224ae586cbea19375a7d206")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Logging infrastructure default implementation for Microsoft.Extensions.Logging.")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Logging")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.DependencyInjection
{
	public static class LoggingServiceCollectionExtensions
	{
		public static IServiceCollection AddLogging(this IServiceCollection services)
		{
			return services.AddLogging(delegate
			{
			});
		}

		public static IServiceCollection AddLogging(this IServiceCollection services, Action<ILoggingBuilder> configure)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			services.AddOptions();
			services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
			services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
			services.TryAddEnumerable(ServiceDescriptor.Singleton((IConfigureOptions<LoggerFilterOptions>)new DefaultLoggerLevelConfigureOptions(LogLevel.Information)));
			configure(new LoggingBuilder(services));
			return services;
		}
	}
}
namespace Microsoft.Extensions.Logging
{
	internal class DefaultLoggerLevelConfigureOptions : ConfigureOptions<LoggerFilterOptions>
	{
		public DefaultLoggerLevelConfigureOptions(LogLevel level)
			: base((Action<LoggerFilterOptions>)delegate(LoggerFilterOptions options)
			{
				options.MinLevel = level;
			})
		{
		}
	}
	public static class FilterLoggingBuilderExtensions
	{
		public static ILoggingBuilder AddFilter(this ILoggingBuilder builder, Func<string, string, LogLevel, bool> filter)
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter(filter);
			});
		}

		public static ILoggingBuilder AddFilter(this ILoggingBuilder builder, Func<string, LogLevel, bool> categoryLevelFilter)
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter(categoryLevelFilter);
			});
		}

		public static ILoggingBuilder AddFilter<T>(this ILoggingBuilder builder, Func<string, LogLevel, bool> categoryLevelFilter) where T : ILoggerProvider
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter<T>(categoryLevelFilter);
			});
		}

		public static ILoggingBuilder AddFilter(this ILoggingBuilder builder, Func<LogLevel, bool> levelFilter)
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter(levelFilter);
			});
		}

		public static ILoggingBuilder AddFilter<T>(this ILoggingBuilder builder, Func<LogLevel, bool> levelFilter) where T : ILoggerProvider
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter<T>(levelFilter);
			});
		}

		public static ILoggingBuilder AddFilter(this ILoggingBuilder builder, string category, LogLevel level)
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter(category, level);
			});
		}

		public static ILoggingBuilder AddFilter<T>(this ILoggingBuilder builder, string category, LogLevel level) where T : ILoggerProvider
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter<T>(category, level);
			});
		}

		public static ILoggingBuilder AddFilter(this ILoggingBuilder builder, string category, Func<LogLevel, bool> levelFilter)
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter(category, levelFilter);
			});
		}

		public static ILoggingBuilder AddFilter<T>(this ILoggingBuilder builder, string category, Func<LogLevel, bool> levelFilter) where T : ILoggerProvider
		{
			return builder.ConfigureFilter(delegate(LoggerFilterOptions options)
			{
				options.AddFilter<T>(category, levelFilter);
			});
		}

		public static LoggerFilterOptions AddFilter(this LoggerFilterOptions builder, Func<string, string, LogLevel, bool> filter)
		{
			return AddRule(builder, null, null, null, filter);
		}

		public static LoggerFilterOptions AddFilter(this LoggerFilterOptions builder, Func<string, LogLevel, bool> categoryLevelFilter)
		{
			return AddRule(builder, null, null, null, (string type, string name, LogLevel level) => categoryLevelFilter(name, level));
		}

		public static LoggerFilterOptions AddFilter<T>(this LoggerFilterOptions builder, Func<string, LogLevel, bool> categoryLevelFilter) where T : ILoggerProvider
		{
			return AddRule(builder, typeof(T).FullName, null, null, (string type, string name, LogLevel level) => categoryLevelFilter(name, level));
		}

		public static LoggerFilterOptions AddFilter(this LoggerFilterOptions builder, Func<LogLevel, bool> levelFilter)
		{
			return AddRule(builder, null, null, null, (string type, string name, LogLevel level) => levelFilter(level));
		}

		public static LoggerFilterOptions AddFilter<T>(this LoggerFilterOptions builder, Func<LogLevel, bool> levelFilter) where T : ILoggerProvider
		{
			return AddRule(builder, typeof(T).FullName, null, null, (string type, string name, LogLevel level) => levelFilter(level));
		}

		public static LoggerFilterOptions AddFilter(this LoggerFilterOptions builder, string category, LogLevel level)
		{
			return AddRule(builder, null, category, level);
		}

		public static LoggerFilterOptions AddFilter<T>(this LoggerFilterOptions builder, string category, LogLevel level) where T : ILoggerProvider
		{
			return AddRule(builder, typeof(T).FullName, category, level);
		}

		public static LoggerFilterOptions AddFilter(this LoggerFilterOptions builder, string category, Func<LogLevel, bool> levelFilter)
		{
			return AddRule(builder, null, category, null, (string type, string name, LogLevel level) => levelFilter(level));
		}

		public static LoggerFilterOptions AddFilter<T>(this LoggerFilterOptions builder, string category, Func<LogLevel, bool> levelFilter) where T : ILoggerProvider
		{
			return AddRule(builder, typeof(T).FullName, category, null, (string type, string name, LogLevel level) => levelFilter(level));
		}

		private static ILoggingBuilder ConfigureFilter(this ILoggingBuilder builder, Action<LoggerFilterOptions> configureOptions)
		{
			builder.Services.Configure(configureOptions);
			return builder;
		}

		private static LoggerFilterOptions AddRule(LoggerFilterOptions options, string type = null, string category = null, LogLevel? level = null, Func<string, string, LogLevel, bool> filter = null)
		{
			options.Rules.Add(new LoggerFilterRule(type, category, level, filter));
			return options;
		}
	}
	public interface ILoggingBuilder
	{
		IServiceCollection Services { get; }
	}
	internal class Logger : ILogger
	{
		private class Scope : IDisposable
		{
			private bool _isDisposed;

			private IDisposable _disposable0;

			private IDisposable _disposable1;

			private readonly IDisposable[] _disposable;

			public Scope(int count)
			{
				if (count > 2)
				{
					_disposable = new IDisposable[count - 2];
				}
			}

			public void SetDisposable(int index, IDisposable disposable)
			{
				switch (index)
				{
				case 0:
					_disposable0 = disposable;
					break;
				case 1:
					_disposable1 = disposable;
					break;
				default:
					_disposable[index - 2] = disposable;
					break;
				}
			}

			public void Dispose()
			{
				if (_isDisposed)
				{
					return;
				}
				_disposable0?.Dispose();
				_disposable1?.Dispose();
				if (_disposable != null)
				{
					int num = _disposable.Length;
					for (int i = 0; i != num; i++)
					{
						if (_disposable[i] != null)
						{
							_disposable[i].Dispose();
						}
					}
				}
				_isDisposed = true;
			}
		}

		private readonly LoggerFactory _loggerFactory;

		private LoggerInformation[] _loggers;

		private int _scopeCount;

		public LoggerInformation[] Loggers
		{
			get
			{
				return _loggers;
			}
			set
			{
				int num = 0;
				foreach (LoggerInformation loggerInformation in value)
				{
					if (!loggerInformation.ExternalScope)
					{
						num++;
					}
				}
				_scopeCount = num;
				_loggers = value;
			}
		}

		public Logger(LoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			LoggerInformation[] loggers = Loggers;
			if (loggers == null)
			{
				return;
			}
			List<Exception> list = null;
			LoggerInformation[] array = loggers;
			for (int i = 0; i < array.Length; i++)
			{
				LoggerInformation loggerInformation = array[i];
				if (!loggerInformation.IsEnabled(logLevel))
				{
					continue;
				}
				try
				{
					loggerInformation.Logger.Log(logLevel, eventId, state, exception, formatter);
				}
				catch (Exception item)
				{
					if (list == null)
					{
						list = new List<Exception>();
					}
					list.Add(item);
				}
			}
			if (list == null || list.Count <= 0)
			{
				return;
			}
			throw new AggregateException("An error occurred while writing to logger(s).", list);
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			LoggerInformation[] loggers = Loggers;
			if (loggers == null)
			{
				return false;
			}
			List<Exception> list = null;
			LoggerInformation[] array = loggers;
			for (int i = 0; i < array.Length; i++)
			{
				LoggerInformation loggerInformation = array[i];
				if (!loggerInformation.IsEnabled(logLevel))
				{
					continue;
				}
				try
				{
					if (loggerInformation.Logger.IsEnabled(logLevel))
					{
						return true;
					}
				}
				catch (Exception item)
				{
					if (list == null)
					{
						list = new List<Exception>();
					}
					list.Add(item);
				}
			}
			if (list != null && list.Count > 0)
			{
				throw new AggregateException("An error occurred while writing to logger(s).", list);
			}
			return false;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			LoggerInformation[] loggers = Loggers;
			if (loggers == null)
			{
				return NullScope.Instance;
			}
			LoggerExternalScopeProvider scopeProvider = _loggerFactory.ScopeProvider;
			int num = _scopeCount;
			if (scopeProvider != null)
			{
				if (num == 0)
				{
					return scopeProvider.Push(state);
				}
				num++;
			}
			Scope scope = new Scope(num);
			List<Exception> list = null;
			for (int i = 0; i < loggers.Length; i++)
			{
				LoggerInformation loggerInformation = loggers[i];
				if (loggerInformation.ExternalScope)
				{
					continue;
				}
				try
				{
					num--;
					if (num >= 0)
					{
						IDisposable disposable = loggerInformation.Logger.BeginScope(state);
						scope.SetDisposable(num, disposable);
					}
				}
				catch (Exception item)
				{
					if (list == null)
					{
						list = new List<Exception>();
					}
					list.Add(item);
				}
			}
			if (scopeProvider != null)
			{
				scope.SetDisposable(0, scopeProvider.Push(state));
			}
			if (list != null && list.Count > 0)
			{
				throw new AggregateException("An error occurred while writing to logger(s).", list);
			}
			return scope;
		}
	}
	public class LoggerFactory : ILoggerFactory, IDisposable
	{
		private struct ProviderRegistration
		{
			public ILoggerProvider Provider;

			public bool ShouldDispose;
		}

		private static readonly LoggerRuleSelector RuleSelector = new LoggerRuleSelector();

		private readonly Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>(StringComparer.Ordinal);

		private readonly List<ProviderRegistration> _providerRegistrations = new List<ProviderRegistration>();

		private readonly object _sync = new object();

		private volatile bool _disposed;

		private IDisposable _changeTokenRegistration;

		private LoggerFilterOptions _filterOptions;

		internal LoggerExternalScopeProvider ScopeProvider { get; private set; }

		public LoggerFactory()
			: this(Enumerable.Empty<ILoggerProvider>())
		{
		}

		public LoggerFactory(IEnumerable<ILoggerProvider> providers)
			: this(providers, new StaticFilterOptionsMonitor(new LoggerFilterOptions()))
		{
		}

		public LoggerFactory(IEnumerable<ILoggerProvider> providers, LoggerFilterOptions filterOptions)
			: this(providers, new StaticFilterOptionsMonitor(filterOptions))
		{
		}

		public LoggerFactory(IEnumerable<ILoggerProvider> providers, IOptionsMonitor<LoggerFilterOptions> filterOption)
		{
			foreach (ILoggerProvider provider in providers)
			{
				AddProviderRegistration(provider, dispose: false);
			}
			_changeTokenRegistration = filterOption.OnChange(RefreshFilters);
			RefreshFilters(filterOption.CurrentValue);
		}

		private void RefreshFilters(LoggerFilterOptions filterOptions)
		{
			lock (_sync)
			{
				_filterOptions = filterOptions;
				foreach (KeyValuePair<string, Logger> logger in _loggers)
				{
					LoggerInformation[] loggers = logger.Value.Loggers;
					string key = logger.Key;
					ApplyRules(loggers, key, 0, loggers.Length);
				}
			}
		}

		public ILogger CreateLogger(string categoryName)
		{
			if (CheckDisposed())
			{
				throw new ObjectDisposedException("LoggerFactory");
			}
			lock (_sync)
			{
				if (!_loggers.TryGetValue(categoryName, out var value))
				{
					value = new Logger(this)
					{
						Loggers = CreateLoggers(categoryName)
					};
					_loggers[categoryName] = value;
				}
				return value;
			}
		}

		public void AddProvider(ILoggerProvider provider)
		{
			if (CheckDisposed())
			{
				throw new ObjectDisposedException("LoggerFactory");
			}
			AddProviderRegistration(provider, dispose: true);
			lock (_sync)
			{
				foreach (KeyValuePair<string, Logger> logger in _loggers)
				{
					LoggerInformation[] array = logger.Value.Loggers;
					string key = logger.Key;
					Array.Resize(ref array, array.Length + 1);
					int num = array.Length - 1;
					SetLoggerInformation(ref array[num], provider, key);
					ApplyRules(array, key, num, 1);
					logger.Value.Loggers = array;
				}
			}
		}

		private void AddProviderRegistration(ILoggerProvider provider, bool dispose)
		{
			_providerRegistrations.Add(new ProviderRegistration
			{
				Provider = provider,
				ShouldDispose = dispose
			});
			if (provider is ISupportExternalScope supportExternalScope)
			{
				if (ScopeProvider == null)
				{
					ScopeProvider = new LoggerExternalScopeProvider();
				}
				supportExternalScope.SetScopeProvider(ScopeProvider);
			}
		}

		private void SetLoggerInformation(ref LoggerInformation loggerInformation, ILoggerProvider provider, string categoryName)
		{
			loggerInformation.Logger = provider.CreateLogger(categoryName);
			loggerInformation.ProviderType = provider.GetType();
			loggerInformation.ExternalScope = provider is ISupportExternalScope;
		}

		private LoggerInformation[] CreateLoggers(string categoryName)
		{
			LoggerInformation[] array = new LoggerInformation[_providerRegistrations.Count];
			for (int i = 0; i < _providerRegistrations.Count; i++)
			{
				SetLoggerInformation(ref array[i], _providerRegistrations[i].Provider, categoryName);
			}
			ApplyRules(array, categoryName, 0, array.Length);
			return array;
		}

		private void ApplyRules(LoggerInformation[] loggers, string categoryName, int start, int count)
		{
			for (int i = start; i < start + count; i++)
			{
				ref LoggerInformation reference = ref loggers[i];
				RuleSelector.Select(_filterOptions, reference.ProviderType, categoryName, out var minLevel, out var filter);
				reference.Category = categoryName;
				reference.MinLevel = minLevel;
				reference.Filter = filter;
			}
		}

		protected virtual bool CheckDisposed()
		{
			return _disposed;
		}

		public void Dispose()
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			_changeTokenRegistration?.Dispose();
			foreach (ProviderRegistration providerRegistration in _providerRegistrations)
			{
				try
				{
					if (providerRegistration.ShouldDispose)
					{
						providerRegistration.Provider.Dispose();
					}
				}
				catch
				{
				}
			}
		}
	}
	public class LoggerFilterOptions
	{
		public LogLevel MinLevel { get; set; }

		public IList<LoggerFilterRule> Rules { get; } = new List<LoggerFilterRule>();
	}
	public class LoggerFilterRule
	{
		public string ProviderName { get; }

		public string CategoryName { get; }

		public LogLevel? LogLevel { get; }

		public Func<string, string, LogLevel, bool> Filter { get; }

		public LoggerFilterRule(string providerName, string categoryName, LogLevel? logLevel, Func<string, string, LogLevel, bool> filter)
		{
			ProviderName = providerName;
			CategoryName = categoryName;
			LogLevel = logLevel;
			Filter = filter;
		}

		public override string ToString()
		{
			return string.Format("{0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}'", "ProviderName", ProviderName, "CategoryName", CategoryName, "LogLevel", LogLevel, "Filter", Filter);
		}
	}
	internal struct LoggerInformation
	{
		public ILogger Logger { get; set; }

		public string Category { get; set; }

		public Type ProviderType { get; set; }

		public LogLevel? MinLevel { get; set; }

		public Func<string, string, LogLevel, bool> Filter { get; set; }

		public bool ExternalScope { get; set; }

		public bool IsEnabled(LogLevel level)
		{
			if (MinLevel.HasValue && level < MinLevel)
			{
				return false;
			}
			if (Filter != null)
			{
				return Filter(ProviderType.FullName, Category, level);
			}
			return true;
		}
	}
	internal class LoggerRuleSelector
	{
		public void Select(LoggerFilterOptions options, Type providerType, string category, out LogLevel? minLevel, out Func<string, string, LogLevel, bool> filter)
		{
			filter = null;
			minLevel = options.MinLevel;
			string alias = ProviderAliasUtilities.GetAlias(providerType);
			LoggerFilterRule loggerFilterRule = null;
			foreach (LoggerFilterRule rule in options.Rules)
			{
				if (IsBetter(rule, loggerFilterRule, providerType.FullName, category) || (!string.IsNullOrEmpty(alias) && IsBetter(rule, loggerFilterRule, alias, category)))
				{
					loggerFilterRule = rule;
				}
			}
			if (loggerFilterRule != null)
			{
				filter = loggerFilterRule.Filter;
				minLevel = loggerFilterRule.LogLevel;
			}
		}

		private static bool IsBetter(LoggerFilterRule rule, LoggerFilterRule current, string logger, string category)
		{
			if (rule.ProviderName != null && rule.ProviderName != logger)
			{
				return false;
			}
			if (rule.CategoryName != null && !category.StartsWith(rule.CategoryName, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (current != null && current.ProviderName != null)
			{
				if (rule.ProviderName == null)
				{
					return false;
				}
			}
			else if (rule.ProviderName != null)
			{
				return true;
			}
			if (current != null && current.CategoryName != null)
			{
				if (rule.CategoryName == null)
				{
					return false;
				}
				if (current.CategoryName.Length > rule.CategoryName.Length)
				{
					return false;
				}
			}
			return true;
		}
	}
	internal class LoggingBuilder : ILoggingBuilder
	{
		public IServiceCollection Services { get; }

		public LoggingBuilder(IServiceCollection services)
		{
			Services = services;
		}
	}
	public static class LoggingBuilderExtensions
	{
		public static ILoggingBuilder SetMinimumLevel(this ILoggingBuilder builder, LogLevel level)
		{
			builder.Services.Add(ServiceDescriptor.Singleton((IConfigureOptions<LoggerFilterOptions>)new DefaultLoggerLevelConfigureOptions(level)));
			return builder;
		}

		public static ILoggingBuilder AddProvider(this ILoggingBuilder builder, ILoggerProvider provider)
		{
			builder.Services.AddSingleton(provider);
			return builder;
		}

		public static ILoggingBuilder ClearProviders(this ILoggingBuilder builder)
		{
			builder.Services.RemoveAll<ILoggerProvider>();
			return builder;
		}
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ProviderAliasAttribute : Attribute
	{
		public string Alias { get; }

		public ProviderAliasAttribute(string alias)
		{
			Alias = alias;
		}
	}
	internal class ProviderAliasUtilities
	{
		private const string AliasAttibuteTypeFullName = "Microsoft.Extensions.Logging.ProviderAliasAttribute";

		private const string AliasAttibuteAliasProperty = "Alias";

		internal static string GetAlias(Type providerType)
		{
			object[] customAttributes = providerType.GetTypeInfo().GetCustomAttributes(inherit: false);
			foreach (object obj in customAttributes)
			{
				if (obj.GetType().FullName == "Microsoft.Extensions.Logging.ProviderAliasAttribute")
				{
					PropertyInfo property = obj.GetType().GetProperty("Alias", BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						return property.GetValue(obj) as string;
					}
				}
			}
			return null;
		}
	}
	internal class StaticFilterOptionsMonitor : IOptionsMonitor<LoggerFilterOptions>
	{
		public LoggerFilterOptions CurrentValue { get; }

		public StaticFilterOptionsMonitor(LoggerFilterOptions currentValue)
		{
			CurrentValue = currentValue;
		}

		public IDisposable OnChange(Action<LoggerFilterOptions, string> listener)
		{
			return null;
		}

		public LoggerFilterOptions Get(string name)
		{
			return CurrentValue;
		}
	}
}
