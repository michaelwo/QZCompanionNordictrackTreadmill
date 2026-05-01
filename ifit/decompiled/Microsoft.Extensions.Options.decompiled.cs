using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.Options.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "393e0356850d031ca0aa44fa8cf2716b55248b31")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides a strongly typed way of specifying and accessing settings using dependency injection.")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Options")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.DependencyInjection
{
	public static class OptionsServiceCollectionExtensions
	{
		public static IServiceCollection AddOptions(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptions<>), typeof(OptionsManager<>)));
			services.TryAdd(ServiceDescriptor.Scoped(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
			services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitor<>), typeof(OptionsMonitor<>)));
			services.TryAdd(ServiceDescriptor.Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>)));
			services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>)));
			return services;
		}

		public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class
		{
			return services.Configure(Microsoft.Extensions.Options.Options.DefaultName, configureOptions);
		}

		public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name, Action<TOptions> configureOptions) where TOptions : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			services.AddOptions();
			services.AddSingleton((IConfigureOptions<TOptions>)new ConfigureNamedOptions<TOptions>(name, configureOptions));
			return services;
		}

		public static IServiceCollection ConfigureAll<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class
		{
			return services.Configure(null, configureOptions);
		}

		public static IServiceCollection PostConfigure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class
		{
			return services.PostConfigure(Microsoft.Extensions.Options.Options.DefaultName, configureOptions);
		}

		public static IServiceCollection PostConfigure<TOptions>(this IServiceCollection services, string name, Action<TOptions> configureOptions) where TOptions : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			services.AddOptions();
			services.AddSingleton((IPostConfigureOptions<TOptions>)new PostConfigureOptions<TOptions>(name, configureOptions));
			return services;
		}

		public static IServiceCollection PostConfigureAll<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class
		{
			return services.PostConfigure(null, configureOptions);
		}

		public static IServiceCollection ConfigureOptions<TConfigureOptions>(this IServiceCollection services) where TConfigureOptions : class
		{
			return services.ConfigureOptions(typeof(TConfigureOptions));
		}

		private static bool IsAction(Type type)
		{
			if (type.GetTypeInfo().IsGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Action<>);
			}
			return false;
		}

		private static IEnumerable<Type> FindIConfigureOptions(Type type)
		{
			IEnumerable<Type> enumerable = type.GetTypeInfo().ImplementedInterfaces.Where((Type t) => t.GetTypeInfo().IsGenericType && (t.GetGenericTypeDefinition() == typeof(IConfigureOptions<>) || t.GetGenericTypeDefinition() == typeof(IPostConfigureOptions<>)));
			if (!enumerable.Any())
			{
				throw new InvalidOperationException(IsAction(type) ? Resources.Error_NoIConfigureOptionsAndAction : Resources.Error_NoIConfigureOptions);
			}
			return enumerable;
		}

		public static IServiceCollection ConfigureOptions(this IServiceCollection services, Type configureType)
		{
			services.AddOptions();
			foreach (Type item in FindIConfigureOptions(configureType))
			{
				services.AddTransient(item, configureType);
			}
			return services;
		}

		public static IServiceCollection ConfigureOptions(this IServiceCollection services, object configureInstance)
		{
			services.AddOptions();
			foreach (Type item in FindIConfigureOptions(configureInstance.GetType()))
			{
				services.AddSingleton(item, configureInstance);
			}
			return services;
		}

		public static OptionsBuilder<TOptions> AddOptions<TOptions>(this IServiceCollection services) where TOptions : class
		{
			return services.AddOptions<TOptions>(Microsoft.Extensions.Options.Options.DefaultName);
		}

		public static OptionsBuilder<TOptions> AddOptions<TOptions>(this IServiceCollection services, string name) where TOptions : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			services.AddOptions();
			return new OptionsBuilder<TOptions>(services, name);
		}
	}
}
namespace Microsoft.Extensions.Options
{
	public class ConfigureNamedOptions<TOptions> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class
	{
		public string Name { get; }

		public Action<TOptions> Action { get; }

		public ConfigureNamedOptions(string name, Action<TOptions> action)
		{
			Name = name;
			Action = action;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureNamedOptions<TOptions, TDep> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class where TDep : class
	{
		public string Name { get; }

		public Action<TOptions, TDep> Action { get; }

		public TDep Dependency { get; }

		public ConfigureNamedOptions(string name, TDep dependency, Action<TOptions, TDep> action)
		{
			Name = name;
			Action = action;
			Dependency = dependency;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureNamedOptions<TOptions, TDep1, TDep2> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public ConfigureNamedOptions(string name, TDep1 dependency, TDep2 dependency2, Action<TOptions, TDep1, TDep2> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency;
			Dependency2 = dependency2;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public ConfigureNamedOptions(string name, TDep1 dependency, TDep2 dependency2, TDep3 dependency3, Action<TOptions, TDep1, TDep2, TDep3> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3, TDep4> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3, TDep4> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public TDep4 Dependency4 { get; }

		public ConfigureNamedOptions(string name, TDep1 dependency1, TDep2 dependency2, TDep3 dependency3, TDep4 dependency4, Action<TOptions, TDep1, TDep2, TDep3, TDep4> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency1;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
			Dependency4 = dependency4;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3, Dependency4);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> : IConfigureNamedOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class where TDep5 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public TDep4 Dependency4 { get; }

		public TDep5 Dependency5 { get; }

		public ConfigureNamedOptions(string name, TDep1 dependency1, TDep2 dependency2, TDep3 dependency3, TDep4 dependency4, TDep5 dependency5, Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency1;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
			Dependency4 = dependency4;
			Dependency5 = dependency5;
		}

		public virtual void Configure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3, Dependency4, Dependency5);
			}
		}

		public void Configure(TOptions options)
		{
			Configure(Options.DefaultName, options);
		}
	}
	public class ConfigureOptions<TOptions> : IConfigureOptions<TOptions> where TOptions : class
	{
		public Action<TOptions> Action { get; }

		public ConfigureOptions(Action<TOptions> action)
		{
			Action = action;
		}

		public virtual void Configure(TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			Action?.Invoke(options);
		}
	}
	public interface IConfigureNamedOptions<in TOptions> : IConfigureOptions<TOptions> where TOptions : class
	{
		void Configure(string name, TOptions options);
	}
	public interface IConfigureOptions<in TOptions> where TOptions : class
	{
		void Configure(TOptions options);
	}
	public interface IOptions<out TOptions> where TOptions : class, new()
	{
		TOptions Value { get; }
	}
	public interface IOptionsChangeTokenSource<out TOptions>
	{
		string Name { get; }

		IChangeToken GetChangeToken();
	}
	public interface IOptionsFactory<TOptions> where TOptions : class, new()
	{
		TOptions Create(string name);
	}
	public interface IOptionsMonitor<out TOptions>
	{
		TOptions CurrentValue { get; }

		TOptions Get(string name);

		IDisposable OnChange(Action<TOptions, string> listener);
	}
	public interface IOptionsMonitorCache<TOptions> where TOptions : class
	{
		TOptions GetOrAdd(string name, Func<TOptions> createOptions);

		bool TryAdd(string name, TOptions options);

		bool TryRemove(string name);

		void Clear();
	}
	public interface IOptionsSnapshot<out TOptions> : IOptions<TOptions> where TOptions : class, new()
	{
		TOptions Get(string name);
	}
	public interface IPostConfigureOptions<in TOptions> where TOptions : class
	{
		void PostConfigure(string name, TOptions options);
	}
	public static class Options
	{
		public static readonly string DefaultName = string.Empty;

		public static IOptions<TOptions> Create<TOptions>(TOptions options) where TOptions : class, new()
		{
			return new OptionsWrapper<TOptions>(options);
		}
	}
	public class OptionsBuilder<TOptions> where TOptions : class
	{
		public string Name { get; }

		public IServiceCollection Services { get; }

		public OptionsBuilder(IServiceCollection services, string name)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			Services = services;
			Name = name ?? Options.DefaultName;
		}

		public virtual OptionsBuilder<TOptions> Configure(Action<TOptions> configureOptions)
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddSingleton((IConfigureOptions<TOptions>)new ConfigureNamedOptions<TOptions>(Name, configureOptions));
			return this;
		}

		public virtual OptionsBuilder<TOptions> Configure<TDep>(Action<TOptions, TDep> configureOptions) where TDep : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IConfigureOptions<TOptions>>)((IServiceProvider sp) => new ConfigureNamedOptions<TOptions, TDep>(Name, sp.GetRequiredService<TDep>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> Configure<TDep1, TDep2>(Action<TOptions, TDep1, TDep2> configureOptions) where TDep1 : class where TDep2 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IConfigureOptions<TOptions>>)((IServiceProvider sp) => new ConfigureNamedOptions<TOptions, TDep1, TDep2>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> Configure<TDep1, TDep2, TDep3>(Action<TOptions, TDep1, TDep2, TDep3> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IConfigureOptions<TOptions>>)((IServiceProvider sp) => new ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> Configure<TDep1, TDep2, TDep3, TDep4>(Action<TOptions, TDep1, TDep2, TDep3, TDep4> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IConfigureOptions<TOptions>>)((IServiceProvider sp) => new ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3, TDep4>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), sp.GetRequiredService<TDep4>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> Configure<TDep1, TDep2, TDep3, TDep4, TDep5>(Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class where TDep5 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IConfigureOptions<TOptions>>)((IServiceProvider sp) => new ConfigureNamedOptions<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), sp.GetRequiredService<TDep4>(), sp.GetRequiredService<TDep5>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure(Action<TOptions> configureOptions)
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddSingleton((IPostConfigureOptions<TOptions>)new PostConfigureOptions<TOptions>(Name, configureOptions));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure<TDep>(Action<TOptions, TDep> configureOptions) where TDep : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IPostConfigureOptions<TOptions>>)((IServiceProvider sp) => new PostConfigureOptions<TOptions, TDep>(Name, sp.GetRequiredService<TDep>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure<TDep1, TDep2>(Action<TOptions, TDep1, TDep2> configureOptions) where TDep1 : class where TDep2 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IPostConfigureOptions<TOptions>>)((IServiceProvider sp) => new PostConfigureOptions<TOptions, TDep1, TDep2>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure<TDep1, TDep2, TDep3>(Action<TOptions, TDep1, TDep2, TDep3> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IPostConfigureOptions<TOptions>>)((IServiceProvider sp) => new PostConfigureOptions<TOptions, TDep1, TDep2, TDep3>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure<TDep1, TDep2, TDep3, TDep4>(Action<TOptions, TDep1, TDep2, TDep3, TDep4> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IPostConfigureOptions<TOptions>>)((IServiceProvider sp) => new PostConfigureOptions<TOptions, TDep1, TDep2, TDep3, TDep4>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), sp.GetRequiredService<TDep4>(), configureOptions)));
			return this;
		}

		public virtual OptionsBuilder<TOptions> PostConfigure<TDep1, TDep2, TDep3, TDep4, TDep5>(Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> configureOptions) where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class where TDep5 : class
		{
			if (configureOptions == null)
			{
				throw new ArgumentNullException("configureOptions");
			}
			Services.AddTransient((Func<IServiceProvider, IPostConfigureOptions<TOptions>>)((IServiceProvider sp) => new PostConfigureOptions<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5>(Name, sp.GetRequiredService<TDep1>(), sp.GetRequiredService<TDep2>(), sp.GetRequiredService<TDep3>(), sp.GetRequiredService<TDep4>(), sp.GetRequiredService<TDep5>(), configureOptions)));
			return this;
		}
	}
	public class OptionsCache<TOptions> : IOptionsMonitorCache<TOptions> where TOptions : class
	{
		private readonly ConcurrentDictionary<string, Lazy<TOptions>> _cache = new ConcurrentDictionary<string, Lazy<TOptions>>(StringComparer.Ordinal);

		public void Clear()
		{
			_cache.Clear();
		}

		public virtual TOptions GetOrAdd(string name, Func<TOptions> createOptions)
		{
			if (createOptions == null)
			{
				throw new ArgumentNullException("createOptions");
			}
			name = name ?? Options.DefaultName;
			return _cache.GetOrAdd(name, new Lazy<TOptions>(createOptions)).Value;
		}

		public virtual bool TryAdd(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			name = name ?? Options.DefaultName;
			return _cache.TryAdd(name, new Lazy<TOptions>(() => options));
		}

		public virtual bool TryRemove(string name)
		{
			name = name ?? Options.DefaultName;
			Lazy<TOptions> value;
			return _cache.TryRemove(name, out value);
		}
	}
	public class OptionsFactory<TOptions> : IOptionsFactory<TOptions> where TOptions : class, new()
	{
		private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;

		private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

		public OptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
		{
			_setups = setups;
			_postConfigures = postConfigures;
		}

		public TOptions Create(string name)
		{
			TOptions val = new TOptions();
			foreach (IConfigureOptions<TOptions> setup in _setups)
			{
				if (setup is IConfigureNamedOptions<TOptions> configureNamedOptions)
				{
					configureNamedOptions.Configure(name, val);
				}
				else if (name == Options.DefaultName)
				{
					setup.Configure(val);
				}
			}
			foreach (IPostConfigureOptions<TOptions> postConfigure in _postConfigures)
			{
				postConfigure.PostConfigure(name, val);
			}
			return val;
		}
	}
	public class OptionsManager<TOptions> : IOptions<TOptions>, IOptionsSnapshot<TOptions> where TOptions : class, new()
	{
		private readonly IOptionsFactory<TOptions> _factory;

		private readonly OptionsCache<TOptions> _cache = new OptionsCache<TOptions>();

		public TOptions Value => Get(Options.DefaultName);

		public OptionsManager(IOptionsFactory<TOptions> factory)
		{
			_factory = factory;
		}

		public virtual TOptions Get(string name)
		{
			name = name ?? Options.DefaultName;
			return _cache.GetOrAdd(name, () => _factory.Create(name));
		}
	}
	public class OptionsMonitor<TOptions> : IOptionsMonitor<TOptions> where TOptions : class, new()
	{
		internal class ChangeTrackerDisposable : IDisposable
		{
			private readonly Action<TOptions, string> _listener;

			private readonly OptionsMonitor<TOptions> _monitor;

			public ChangeTrackerDisposable(OptionsMonitor<TOptions> monitor, Action<TOptions, string> listener)
			{
				_listener = listener;
				_monitor = monitor;
			}

			public void OnChange(TOptions options, string name)
			{
				_listener(options, name);
			}

			public void Dispose()
			{
				_monitor._onChange -= OnChange;
			}
		}

		private readonly IOptionsMonitorCache<TOptions> _cache;

		private readonly IOptionsFactory<TOptions> _factory;

		private readonly IEnumerable<IOptionsChangeTokenSource<TOptions>> _sources;

		public TOptions CurrentValue => Get(Options.DefaultName);

		internal event Action<TOptions, string> _onChange;

		public OptionsMonitor(IOptionsFactory<TOptions> factory, IEnumerable<IOptionsChangeTokenSource<TOptions>> sources, IOptionsMonitorCache<TOptions> cache)
		{
			_factory = factory;
			_sources = sources;
			_cache = cache;
			foreach (IOptionsChangeTokenSource<TOptions> source in _sources)
			{
				ChangeToken.OnChange(() => source.GetChangeToken(), delegate(string name)
				{
					InvokeChanged(name);
				}, source.Name);
			}
		}

		private void InvokeChanged(string name)
		{
			name = name ?? Options.DefaultName;
			_cache.TryRemove(name);
			TOptions arg = Get(name);
			if (this._onChange != null)
			{
				this._onChange(arg, name);
			}
		}

		public virtual TOptions Get(string name)
		{
			name = name ?? Options.DefaultName;
			return _cache.GetOrAdd(name, () => _factory.Create(name));
		}

		public IDisposable OnChange(Action<TOptions, string> listener)
		{
			ChangeTrackerDisposable changeTrackerDisposable = new ChangeTrackerDisposable(this, listener);
			_onChange += changeTrackerDisposable.OnChange;
			return changeTrackerDisposable;
		}
	}
	public static class OptionsMonitorExtensions
	{
		public static IDisposable OnChange<TOptions>(this IOptionsMonitor<TOptions> monitor, Action<TOptions> listener)
		{
			return monitor.OnChange(delegate(TOptions o, string _)
			{
				listener(o);
			});
		}
	}
	public class OptionsWrapper<TOptions> : IOptions<TOptions> where TOptions : class, new()
	{
		public TOptions Value { get; }

		public OptionsWrapper(TOptions options)
		{
			Value = options;
		}

		[Obsolete("This method is obsolete and will be removed in a future version.")]
		public void Add(string name, TOptions options)
		{
			throw new NotImplementedException();
		}

		[Obsolete("This method is obsolete and will be removed in a future version.")]
		public TOptions Get(string name)
		{
			return Value;
		}

		[Obsolete("This method is obsolete and will be removed in a future version.")]
		public bool Remove(string name)
		{
			throw new NotImplementedException();
		}
	}
	public class PostConfigureOptions<TOptions> : IPostConfigureOptions<TOptions> where TOptions : class
	{
		public string Name { get; }

		public Action<TOptions> Action { get; }

		public PostConfigureOptions(string name, Action<TOptions> action)
		{
			Name = name;
			Action = action;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options);
			}
		}
	}
	public class PostConfigureOptions<TOptions, TDep> : IPostConfigureOptions<TOptions> where TOptions : class where TDep : class
	{
		public string Name { get; }

		public Action<TOptions, TDep> Action { get; }

		public TDep Dependency { get; }

		public PostConfigureOptions(string name, TDep dependency, Action<TOptions, TDep> action)
		{
			Name = name;
			Action = action;
			Dependency = dependency;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency);
			}
		}

		public void PostConfigure(TOptions options)
		{
			PostConfigure(Options.DefaultName, options);
		}
	}
	public class PostConfigureOptions<TOptions, TDep1, TDep2> : IPostConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public PostConfigureOptions(string name, TDep1 dependency, TDep2 dependency2, Action<TOptions, TDep1, TDep2> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency;
			Dependency2 = dependency2;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2);
			}
		}

		public void PostConfigure(TOptions options)
		{
			PostConfigure(Options.DefaultName, options);
		}
	}
	public class PostConfigureOptions<TOptions, TDep1, TDep2, TDep3> : IPostConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public PostConfigureOptions(string name, TDep1 dependency, TDep2 dependency2, TDep3 dependency3, Action<TOptions, TDep1, TDep2, TDep3> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3);
			}
		}

		public void PostConfigure(TOptions options)
		{
			PostConfigure(Options.DefaultName, options);
		}
	}
	public class PostConfigureOptions<TOptions, TDep1, TDep2, TDep3, TDep4> : IPostConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3, TDep4> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public TDep4 Dependency4 { get; }

		public PostConfigureOptions(string name, TDep1 dependency1, TDep2 dependency2, TDep3 dependency3, TDep4 dependency4, Action<TOptions, TDep1, TDep2, TDep3, TDep4> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency1;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
			Dependency4 = dependency4;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3, Dependency4);
			}
		}

		public void PostConfigure(TOptions options)
		{
			PostConfigure(Options.DefaultName, options);
		}
	}
	public class PostConfigureOptions<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> : IPostConfigureOptions<TOptions> where TOptions : class where TDep1 : class where TDep2 : class where TDep3 : class where TDep4 : class where TDep5 : class
	{
		public string Name { get; }

		public Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> Action { get; }

		public TDep1 Dependency1 { get; }

		public TDep2 Dependency2 { get; }

		public TDep3 Dependency3 { get; }

		public TDep4 Dependency4 { get; }

		public TDep5 Dependency5 { get; }

		public PostConfigureOptions(string name, TDep1 dependency1, TDep2 dependency2, TDep3 dependency3, TDep4 dependency4, TDep5 dependency5, Action<TOptions, TDep1, TDep2, TDep3, TDep4, TDep5> action)
		{
			Name = name;
			Action = action;
			Dependency1 = dependency1;
			Dependency2 = dependency2;
			Dependency3 = dependency3;
			Dependency4 = dependency4;
			Dependency5 = dependency5;
		}

		public virtual void PostConfigure(string name, TOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (Name == null || name == Name)
			{
				Action?.Invoke(options, Dependency1, Dependency2, Dependency3, Dependency4, Dependency5);
			}
		}

		public void PostConfigure(TOptions options)
		{
			PostConfigure(Options.DefaultName, options);
		}
	}
	internal static class Resources
	{
		private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.Options.Resources", typeof(Resources).GetTypeInfo().Assembly);

		internal static string Error_CannotActivateAbstractOrInterface => GetString("Error_CannotActivateAbstractOrInterface");

		internal static string Error_FailedBinding => GetString("Error_FailedBinding");

		internal static string Error_FailedToActivate => GetString("Error_FailedToActivate");

		internal static string Error_MissingParameterlessConstructor => GetString("Error_MissingParameterlessConstructor");

		internal static string Error_NoIConfigureOptions => GetString("Error_NoIConfigureOptions");

		internal static string Error_NoIConfigureOptionsAndAction => GetString("Error_NoIConfigureOptionsAndAction");

		internal static string FormatError_CannotActivateAbstractOrInterface(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_CannotActivateAbstractOrInterface"), p0);
		}

		internal static string FormatError_FailedBinding(object p0, object p1)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_FailedBinding"), p0, p1);
		}

		internal static string FormatError_FailedToActivate(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_FailedToActivate"), p0);
		}

		internal static string FormatError_MissingParameterlessConstructor(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_MissingParameterlessConstructor"), p0);
		}

		internal static string FormatError_NoIConfigureOptions()
		{
			return GetString("Error_NoIConfigureOptions");
		}

		internal static string FormatError_NoIConfigureOptionsAndAction()
		{
			return GetString("Error_NoIConfigureOptionsAndAction");
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
