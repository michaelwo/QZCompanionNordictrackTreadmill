using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Retry;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Basic API support used in all iFit API packages")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Api.Support")]
[assembly: AssemblyTitle("iFit.Api.Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Api.Support;

public class ConnectivityException : Exception
{
	public ConnectivityException(string msg = null)
		: base(msg)
	{
	}

	public ConnectivityException(string msg, Exception innerException)
		: base(msg, innerException)
	{
	}
}
public class DefaultPolicies
{
	public static AsyncRetryPolicy DefaultPolicy = Policy.Handle<WebException>().WaitAndRetryAsync(3, (int retryAttempt) => TimeSpan.FromSeconds(Math.Pow(2.0, retryAttempt)));
}
public class DelimiterSeparatedPropertyNamesContractResolver : DefaultContractResolver
{
	private readonly string Separator;

	protected DelimiterSeparatedPropertyNamesContractResolver(char separator)
	{
		Separator = separator.ToString();
	}

	protected override string ResolvePropertyName(string propertyName)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in propertyName)
		{
			if (char.IsUpper(c) && stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
				stringBuilder.Clear();
			}
			stringBuilder.Append(char.ToLower(c));
		}
		if (stringBuilder.Length > 0)
		{
			list.Add(stringBuilder.ToString());
		}
		return string.Join(Separator, list.ToArray());
	}
}
public class SnakeCasePropertyNamesContractResolver : DelimiterSeparatedPropertyNamesContractResolver
{
	public SnakeCasePropertyNamesContractResolver()
		: base('_')
	{
	}
}
public static class StringExtensions
{
	public static string Base64Encoding(this string plainText)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
	}

	public static string TransformString(this string encoded, int key)
	{
		char[] array = encoded.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)(array[i] ^ key);
		}
		return new string(array);
	}

	public static string TransformString(this string[] keys)
	{
		List<string> list = new List<string>();
		foreach (string encoded in keys)
		{
			list.Add(encoded.TransformString(list.Count + 1));
		}
		return string.Join("", list);
	}
}
