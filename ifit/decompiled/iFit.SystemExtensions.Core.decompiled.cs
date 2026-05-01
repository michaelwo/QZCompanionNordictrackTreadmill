using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using iFit.Collections;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("System extensions methods for core logic")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.SystemExtensions.Core")]
[assembly: AssemblyTitle("iFit.SystemExtensions.Core")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Extensions;

public static class ActionExtensions
{
	public static void RunAfterDelay(this Action action, TimeSpan delay)
	{
		if (action != null)
		{
			Task.Run(async delegate
			{
				await Task.Delay(delay);
				action();
			});
		}
	}

	public static async Task RunAfterDelay(this Task task, TimeSpan delay)
	{
		if (task != null)
		{
			await Task.Delay(delay);
			await task;
		}
	}

	public static async Task<T> RunAfterDelay<T>(this Task<T> task, TimeSpan delay)
	{
		if (task == null)
		{
			throw new ArgumentNullException("task");
		}
		await Task.Delay(delay);
		return await task;
	}
}
public static class BoolExtensions
{
	public static string ToJSONString(this bool boolValue)
	{
		return JsonConvert.SerializeObject(boolValue);
	}
}
public static class EnumExtensions
{
	public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
	{
		Type type = value.GetType();
		string name = Enum.GetName(type, value);
		return type.GetRuntimeField(name).GetCustomAttributes(inherit: false).OfType<TAttribute>()
			.SingleOrDefault();
	}

	public static string GetEnumMemberAttributeValue(this Enum value)
	{
		return value.GetType().GetTypeInfo().DeclaredMembers.SingleOrDefault((MemberInfo x) => x.Name == value.ToString())?.GetCustomAttribute<EnumMemberAttribute>(inherit: false)?.Value;
	}
}
public static class ExceptionExtensions
{
	private static readonly Type[] VerboseExceptionTypes = new Type[1] { typeof(TimeoutException) };

	public static string ToConciseString(this Exception e, Type[] verboseExceptionTypes = null)
	{
		if (e == null)
		{
			return string.Empty;
		}
		if (verboseExceptionTypes.CountSafe() == 0)
		{
			verboseExceptionTypes = VerboseExceptionTypes;
		}
		Type type = e.GetType();
		if (!Enumerable.Contains(verboseExceptionTypes, type))
		{
			return e.ToString();
		}
		return type.Name;
	}
}
public static class ICommandExtensions
{
	public static bool SafeExecute(this ICommand command, object parameter = null)
	{
		if (command.CanExecute(parameter))
		{
			command.Execute(parameter);
			return true;
		}
		return false;
	}
}
public interface IDeepCloneable
{
	object DeepClone();
}
public interface IDeepCloneable<T> : IDeepCloneable
{
	new T DeepClone();
}
public static class DeepCloneableExtensions
{
	public static List<T> DeepClone<T>(this List<T> list) where T : IDeepCloneable<T>
	{
		return list?.Select((T x) => x.DeepClone()).ToList();
	}
}
public static class StringExtensions
{
	public static readonly string EmailPattern = "^(?!\\.)(\"([^\"\\r\\\\]|\\\\[\"\\r\\\\])*\"|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\\.)\\.)*)(?<!\\.)@[a-z0-9]+([\\w\\.-][a-z0-9]+)*\\.[a-z][a-z\\.]*[a-z]$";

	public static readonly string ActivationCodePattern = "^[a-z|A-Z|-]+$";

	public static readonly string UsernamePattern = "^[a-zA-Z0-9]{4,30}$";

	private const string VersionPattern = "^(?<mainVersion>(\\d+\\.)?(\\d+\\.)?(\\*|\\d+))(?<stage>-\\w+)?$";

	public static bool IsValidEmail(this string email)
	{
		if (string.IsNullOrWhiteSpace(email))
		{
			return false;
		}
		return new Regex(EmailPattern, RegexOptions.IgnoreCase).IsMatch(email);
	}

	public static bool IsValidUsername(this string username)
	{
		return new Regex(UsernamePattern, RegexOptions.IgnoreCase).IsMatch(username);
	}

	public static bool IsValidActivationCode(this string code)
	{
		return new Regex(ActivationCodePattern, RegexOptions.IgnoreCase).IsMatch(code);
	}

	public static string ToFormattedActivationCode(this string code)
	{
		if (code == null)
		{
			return "";
		}
		string text = "";
		string text2 = code.Replace("-", "");
		for (int i = 0; i < text2.Length; i++)
		{
			if (i > 0 && i % 4 == 0)
			{
				text += "-";
			}
			text += text2[i];
		}
		return text;
	}

	public static Version ToVersion(this string version)
	{
		Match match = new Regex("^(?<mainVersion>(\\d+\\.)?(\\d+\\.)?(\\*|\\d+))(?<stage>-\\w+)?$", RegexOptions.IgnoreCase).Match(version);
		if (!match.Success || match.Groups.Count == 0)
		{
			return null;
		}
		if (Version.TryParse(Regex.Replace(match.Groups["mainVersion"].Value, "\\*$", "0"), out var result))
		{
			return result;
		}
		return null;
	}

	public static string LengthenByXChars(this string str, int xChars)
	{
		if (xChars < 1)
		{
			return str;
		}
		Random random = new Random();
		StringBuilder stringBuilder = new StringBuilder(str);
		for (int i = 0; i < xChars; i++)
		{
			stringBuilder.Append(random.Next(0, 9));
		}
		return stringBuilder.ToString();
	}

	public static string RemoveNonAlphaNumericChars(this string str)
	{
		return new Regex("[^a-zA-Z0-9]").Replace(str, "");
	}

	public static string UsernameFromEmail(this string str, int minimumLength = 4)
	{
		if (str.Length <= 0)
		{
			return "".LengthenByXChars(minimumLength);
		}
		if (str.Contains("@"))
		{
			str = str.Substring(0, str.LastIndexOf('@'));
		}
		str = str.RemoveNonAlphaNumericChars();
		int num = minimumLength - str.Length;
		if (num <= 0)
		{
			return str;
		}
		return str.LengthenByXChars(num);
	}

	public static bool IsValidUrl(this string url)
	{
		if (!string.IsNullOrWhiteSpace(url))
		{
			return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
		}
		return false;
	}

	public static string ToTitleCase(this string str)
	{
		if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
		{
			return str;
		}
		TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
		char[] source = new char[4] { ',', ' ', '.', '\n' };
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (char c in str)
		{
			char value = c;
			if (Enumerable.Contains(source, c))
			{
				flag = true;
			}
			else if (flag)
			{
				value = textInfo.ToUpper(c);
				flag = false;
			}
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	public static string FirstCharToUpper(this string str)
	{
		if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
		{
			return str;
		}
		return CultureInfo.CurrentCulture.TextInfo.ToUpper(str[0]) + str.Substring(1);
	}

	public static string TransformString(this string key, int i)
	{
		char[] array = key.ToCharArray();
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = (char)(array[j] ^ i);
		}
		return new string(array);
	}

	public static string TransformString(this string[] keys)
	{
		List<string> list = new List<string>();
		foreach (string key in keys)
		{
			list.Add(key.TransformString(list.Count + 1));
		}
		return string.Join("", list);
	}

	public static bool IsNotNullOrWhiteSpace(this string s)
	{
		return !string.IsNullOrWhiteSpace(s);
	}
}
