using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.Primitives;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "b1d43cf8b49433054e33f4b6ab66cdffb6fa645e")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Abstractions of key-value pair based configuration.\nCommonly used types:\nMicrosoft.Extensions.Configuration.IConfiguration\nMicrosoft.Extensions.Configuration.IConfigurationBuilder\nMicrosoft.Extensions.Configuration.IConfigurationProvider\nMicrosoft.Extensions.Configuration.IConfigurationRoot\nMicrosoft.Extensions.Configuration.IConfigurationSection")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Configuration.Abstractions")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.Configuration;

public static class ConfigurationExtensions
{
	public static IConfigurationBuilder Add<TSource>(this IConfigurationBuilder builder, Action<TSource> configureSource) where TSource : IConfigurationSource, new()
	{
		TSource val = new TSource();
		configureSource?.Invoke(val);
		return builder.Add(val);
	}

	public static string GetConnectionString(this IConfiguration configuration, string name)
	{
		return configuration?.GetSection("ConnectionStrings")?[name];
	}

	public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IConfiguration configuration)
	{
		return configuration.AsEnumerable(makePathsRelative: false);
	}

	public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IConfiguration configuration, bool makePathsRelative)
	{
		Stack<IConfiguration> stack = new Stack<IConfiguration>();
		stack.Push(configuration);
		IConfigurationSection configurationSection = configuration as IConfigurationSection;
		int prefixLength = ((makePathsRelative && configurationSection != null) ? (configurationSection.Path.Length + 1) : 0);
		while (stack.Count > 0)
		{
			IConfiguration config = stack.Pop();
			if (config is IConfigurationSection configurationSection2 && (!makePathsRelative || config != configuration))
			{
				yield return new KeyValuePair<string, string>(configurationSection2.Path.Substring(prefixLength), configurationSection2.Value);
			}
			foreach (IConfigurationSection child in config.GetChildren())
			{
				stack.Push(child);
			}
		}
	}

	public static bool Exists(this IConfigurationSection section)
	{
		if (section == null)
		{
			return false;
		}
		if (section.Value == null)
		{
			return section.GetChildren().Any();
		}
		return true;
	}
}
public static class ConfigurationPath
{
	public static readonly string KeyDelimiter = ":";

	public static string Combine(params string[] pathSegments)
	{
		if (pathSegments == null)
		{
			throw new ArgumentNullException("pathSegments");
		}
		return string.Join(KeyDelimiter, pathSegments);
	}

	public static string Combine(IEnumerable<string> pathSegments)
	{
		if (pathSegments == null)
		{
			throw new ArgumentNullException("pathSegments");
		}
		return string.Join(KeyDelimiter, pathSegments);
	}

	public static string GetSectionKey(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return path;
		}
		int num = path.LastIndexOf(KeyDelimiter, StringComparison.OrdinalIgnoreCase);
		if (num != -1)
		{
			return path.Substring(num + 1);
		}
		return path;
	}

	public static string GetParentPath(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return null;
		}
		int num = path.LastIndexOf(KeyDelimiter, StringComparison.OrdinalIgnoreCase);
		if (num != -1)
		{
			return path.Substring(0, num);
		}
		return null;
	}
}
public interface IConfiguration
{
	string this[string key] { get; set; }

	IConfigurationSection GetSection(string key);

	IEnumerable<IConfigurationSection> GetChildren();

	IChangeToken GetReloadToken();
}
public interface IConfigurationBuilder
{
	IDictionary<string, object> Properties { get; }

	IList<IConfigurationSource> Sources { get; }

	IConfigurationBuilder Add(IConfigurationSource source);

	IConfigurationRoot Build();
}
public interface IConfigurationProvider
{
	bool TryGet(string key, out string value);

	void Set(string key, string value);

	IChangeToken GetReloadToken();

	void Load();

	IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath);
}
public interface IConfigurationRoot : IConfiguration
{
	IEnumerable<IConfigurationProvider> Providers { get; }

	void Reload();
}
public interface IConfigurationSection : IConfiguration
{
	string Key { get; }

	string Path { get; }

	string Value { get; set; }
}
public interface IConfigurationSource
{
	IConfigurationProvider Build(IConfigurationBuilder builder);
}
