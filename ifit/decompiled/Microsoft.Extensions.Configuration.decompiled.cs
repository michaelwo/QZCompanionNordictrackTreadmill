using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Primitives;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.Configuration.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "b1d43cf8b49433054e33f4b6ab66cdffb6fa645e")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Implementation of key-value pair based configuration for Microsoft.Extensions.Configuration. Includes the memory configuration provider.")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Configuration")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.Configuration
{
	public static class ChainedBuilderExtensions
	{
		public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder, IConfiguration config)
		{
			if (configurationBuilder == null)
			{
				throw new ArgumentNullException("configurationBuilder");
			}
			if (config == null)
			{
				throw new ArgumentNullException("config");
			}
			configurationBuilder.Add(new ChainedConfigurationSource
			{
				Configuration = config
			});
			return configurationBuilder;
		}
	}
	public class ChainedConfigurationProvider : IConfigurationProvider
	{
		private readonly IConfiguration _config;

		public ChainedConfigurationProvider(ChainedConfigurationSource source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.Configuration == null)
			{
				throw new ArgumentNullException("Configuration");
			}
			_config = source.Configuration;
		}

		public bool TryGet(string key, out string value)
		{
			value = _config[key];
			return !string.IsNullOrEmpty(value);
		}

		public void Set(string key, string value)
		{
			_config[key] = value;
		}

		public IChangeToken GetReloadToken()
		{
			return _config.GetReloadToken();
		}

		public void Load()
		{
		}

		public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
		{
			IConfiguration configuration;
			if (parentPath != null)
			{
				IConfiguration section = _config.GetSection(parentPath);
				configuration = section;
			}
			else
			{
				configuration = _config;
			}
			IEnumerable<IConfigurationSection> children = configuration.GetChildren();
			List<string> list = new List<string>();
			list.AddRange(children.Select((IConfigurationSection c) => c.Key));
			return list.Concat(earlierKeys).OrderBy((string k) => k, ConfigurationKeyComparer.Instance);
		}
	}
	public class ChainedConfigurationSource : IConfigurationSource
	{
		public IConfiguration Configuration { get; set; }

		public IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			return new ChainedConfigurationProvider(this);
		}
	}
	public class ConfigurationBuilder : IConfigurationBuilder
	{
		public IList<IConfigurationSource> Sources { get; } = new List<IConfigurationSource>();

		public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();

		public IConfigurationBuilder Add(IConfigurationSource source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			Sources.Add(source);
			return this;
		}

		public IConfigurationRoot Build()
		{
			List<IConfigurationProvider> list = new List<IConfigurationProvider>();
			foreach (IConfigurationSource source in Sources)
			{
				IConfigurationProvider item = source.Build(this);
				list.Add(item);
			}
			return new ConfigurationRoot(list);
		}
	}
	public class ConfigurationKeyComparer : IComparer<string>
	{
		private static readonly string[] _keyDelimiterArray = new string[1] { ConfigurationPath.KeyDelimiter };

		public static ConfigurationKeyComparer Instance { get; } = new ConfigurationKeyComparer();

		public int Compare(string x, string y)
		{
			string[] array = x?.Split(_keyDelimiterArray, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
			string[] array2 = y?.Split(_keyDelimiterArray, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
			for (int i = 0; i < Math.Min(array.Length, array2.Length); i++)
			{
				x = array[i];
				y = array2[i];
				int result = 0;
				int result2 = 0;
				bool flag = x != null && int.TryParse(x, out result);
				bool flag2 = y != null && int.TryParse(y, out result2);
				int num = 0;
				num = ((!flag && !flag2) ? string.Compare(x, y, StringComparison.OrdinalIgnoreCase) : ((!(flag && flag2)) ? ((!flag) ? 1 : (-1)) : (result - result2)));
				if (num != 0)
				{
					return num;
				}
			}
			return array.Length - array2.Length;
		}
	}
	public abstract class ConfigurationProvider : IConfigurationProvider
	{
		private ConfigurationReloadToken _reloadToken = new ConfigurationReloadToken();

		protected IDictionary<string, string> Data { get; set; }

		protected ConfigurationProvider()
		{
			Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}

		public virtual bool TryGet(string key, out string value)
		{
			return Data.TryGetValue(key, out value);
		}

		public virtual void Set(string key, string value)
		{
			Data[key] = value;
		}

		public virtual void Load()
		{
		}

		public virtual IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
		{
			string prefix = ((parentPath == null) ? string.Empty : (parentPath + ConfigurationPath.KeyDelimiter));
			return (from kv in Data
				where kv.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
				select Segment(kv.Key, prefix.Length)).Concat(earlierKeys).OrderBy((string k) => k, ConfigurationKeyComparer.Instance);
		}

		private static string Segment(string key, int prefixLength)
		{
			int num = key.IndexOf(ConfigurationPath.KeyDelimiter, prefixLength, StringComparison.OrdinalIgnoreCase);
			if (num >= 0)
			{
				return key.Substring(prefixLength, num - prefixLength);
			}
			return key.Substring(prefixLength);
		}

		public IChangeToken GetReloadToken()
		{
			return _reloadToken;
		}

		protected void OnReload()
		{
			Interlocked.Exchange(ref _reloadToken, new ConfigurationReloadToken()).OnReload();
		}
	}
	public class ConfigurationReloadToken : IChangeToken
	{
		private CancellationTokenSource _cts = new CancellationTokenSource();

		public bool ActiveChangeCallbacks => true;

		public bool HasChanged => _cts.IsCancellationRequested;

		public IDisposable RegisterChangeCallback(Action<object> callback, object state)
		{
			return _cts.Token.Register(callback, state);
		}

		public void OnReload()
		{
			_cts.Cancel();
		}
	}
	public class ConfigurationRoot : IConfigurationRoot, IConfiguration
	{
		private IList<IConfigurationProvider> _providers;

		private ConfigurationReloadToken _changeToken = new ConfigurationReloadToken();

		public IEnumerable<IConfigurationProvider> Providers => _providers;

		public string this[string key]
		{
			get
			{
				foreach (IConfigurationProvider item in _providers.Reverse())
				{
					if (item.TryGet(key, out var value))
					{
						return value;
					}
				}
				return null;
			}
			set
			{
				if (!_providers.Any())
				{
					throw new InvalidOperationException(Resources.Error_NoSources);
				}
				foreach (IConfigurationProvider provider in _providers)
				{
					provider.Set(key, value);
				}
			}
		}

		public ConfigurationRoot(IList<IConfigurationProvider> providers)
		{
			if (providers == null)
			{
				throw new ArgumentNullException("providers");
			}
			_providers = providers;
			foreach (IConfigurationProvider p in providers)
			{
				p.Load();
				ChangeToken.OnChange(() => p.GetReloadToken(), delegate
				{
					RaiseChanged();
				});
			}
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			return GetChildrenImplementation(null);
		}

		internal IEnumerable<IConfigurationSection> GetChildrenImplementation(string path)
		{
			return from key in _providers.Aggregate(Enumerable.Empty<string>(), (IEnumerable<string> seed, IConfigurationProvider source) => source.GetChildKeys(seed, path)).Distinct()
				select GetSection((path == null) ? key : ConfigurationPath.Combine(path, key));
		}

		public IChangeToken GetReloadToken()
		{
			return _changeToken;
		}

		public IConfigurationSection GetSection(string key)
		{
			return new ConfigurationSection(this, key);
		}

		public void Reload()
		{
			foreach (IConfigurationProvider provider in _providers)
			{
				provider.Load();
			}
			RaiseChanged();
		}

		private void RaiseChanged()
		{
			Interlocked.Exchange(ref _changeToken, new ConfigurationReloadToken()).OnReload();
		}
	}
	public class ConfigurationSection : IConfigurationSection, IConfiguration
	{
		private readonly ConfigurationRoot _root;

		private readonly string _path;

		private string _key;

		public string Path => _path;

		public string Key
		{
			get
			{
				if (_key == null)
				{
					_key = ConfigurationPath.GetSectionKey(_path);
				}
				return _key;
			}
		}

		public string Value
		{
			get
			{
				return _root[Path];
			}
			set
			{
				_root[Path] = value;
			}
		}

		public string this[string key]
		{
			get
			{
				return _root[ConfigurationPath.Combine(Path, key)];
			}
			set
			{
				_root[ConfigurationPath.Combine(Path, key)] = value;
			}
		}

		public ConfigurationSection(ConfigurationRoot root, string path)
		{
			if (root == null)
			{
				throw new ArgumentNullException("root");
			}
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			_root = root;
			_path = path;
		}

		public IConfigurationSection GetSection(string key)
		{
			return _root.GetSection(ConfigurationPath.Combine(Path, key));
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			return _root.GetChildrenImplementation(Path);
		}

		public IChangeToken GetReloadToken()
		{
			return _root.GetReloadToken();
		}
	}
	public static class MemoryConfigurationBuilderExtensions
	{
		public static IConfigurationBuilder AddInMemoryCollection(this IConfigurationBuilder configurationBuilder)
		{
			if (configurationBuilder == null)
			{
				throw new ArgumentNullException("configurationBuilder");
			}
			configurationBuilder.Add(new MemoryConfigurationSource());
			return configurationBuilder;
		}

		public static IConfigurationBuilder AddInMemoryCollection(this IConfigurationBuilder configurationBuilder, IEnumerable<KeyValuePair<string, string>> initialData)
		{
			if (configurationBuilder == null)
			{
				throw new ArgumentNullException("configurationBuilder");
			}
			configurationBuilder.Add(new MemoryConfigurationSource
			{
				InitialData = initialData
			});
			return configurationBuilder;
		}
	}
	internal static class Resources
	{
		private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.Configuration.Resources", typeof(Resources).GetTypeInfo().Assembly);

		internal static string Error_NoSources => GetString("Error_NoSources");

		internal static string FormatError_NoSources()
		{
			return GetString("Error_NoSources");
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
namespace Microsoft.Extensions.Configuration.Memory
{
	public class MemoryConfigurationProvider : ConfigurationProvider, IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		private readonly MemoryConfigurationSource _source;

		public MemoryConfigurationProvider(MemoryConfigurationSource source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			_source = source;
			if (_source.InitialData == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> initialDatum in _source.InitialData)
			{
				base.Data.Add(initialDatum.Key, initialDatum.Value);
			}
		}

		public void Add(string key, string value)
		{
			base.Data.Add(key, value);
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return base.Data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	public class MemoryConfigurationSource : IConfigurationSource
	{
		public IEnumerable<KeyValuePair<string, string>> InitialData { get; set; }

		public IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			return new MemoryConfigurationProvider(this);
		}
	}
}
