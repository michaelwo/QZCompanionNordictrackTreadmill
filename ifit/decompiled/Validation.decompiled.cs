using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyFileVersion("2.4.22.9105")]
[assembly: AssemblyInformationalVersion("2.4.22+g912324149e")]
[assembly: TargetFramework(".NETStandard,Version=v1.3", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Andrew Arnott")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Method input validation and runtime checks that report errors or throw exceptions when failures are detected.")]
[assembly: AssemblyProduct("Validation")]
[assembly: AssemblyTitle("Validation")]
[assembly: AssemblyVersion("2.4.0.0")]
internal sealed class ThisAssembly
{
	internal const string AssemblyVersion = "2.4.0.0";

	internal const string AssemblyFileVersion = "2.4.22.9105";

	internal const string AssemblyInformationalVersion = "2.4.22+g912324149e";

	internal const string AssemblyName = "Validation";

	internal const string AssemblyTitle = "Validation";

	internal const string AssemblyConfiguration = "Release";

	internal const string PublicKey = "0024000004800000940000000602000000240000525341310004000001000100032361060c4006375786dedbfd3d681f67a574a7826b7acbd1491f723d2902cf8dfe07927427ef8175d65db9d124071b3d1a1b8f621560ab39c2da9179ef2f6992e2d563bb8eb5295eb8fa49e3a4ba97efd7139d313edb7c60101de6aa207465eb941f408a1060ce1fc767619060ecc89aa377b03b1f5e948131566568823d9c";

	internal const string PublicKeyToken = "2fc06f0d701809a7";

	internal const string RootNamespace = "Validation";

	private ThisAssembly()
	{
	}
}
namespace Validation;

public static class Assumes
{
	private class InternalErrorException : Exception
	{
		[DebuggerStepThrough]
		public InternalErrorException(string message = null, bool showAssert = true)
			: base(message ?? Strings.InternalExceptionMessage)
		{
			ShowAssertDialog(showAssert);
		}

		[DebuggerStepThrough]
		public InternalErrorException(string message, Exception innerException, bool showAssert = true)
			: base(message ?? Strings.InternalExceptionMessage, innerException)
		{
			ShowAssertDialog(showAssert);
		}

		[DebuggerStepThrough]
		private void ShowAssertDialog(bool showAssert)
		{
			if (showAssert)
			{
				string text = Message;
				if (base.InnerException != null)
				{
					text = text + " " + base.InnerException;
				}
				Report.Fail(text);
			}
		}
	}

	[DebuggerStepThrough]
	public static void NotNull<T>([ValidatedNotNull] T value) where T : class
	{
		True(value != null);
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] string value)
	{
		NotNull(value);
		True(value.Length > 0);
		True(value[0] != '\0');
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty<T>([ValidatedNotNull] ICollection<T> values)
	{
		NotNull(values);
		True(values.Count > 0);
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> values)
	{
		NotNull(values);
		True(values.Any());
	}

	[DebuggerStepThrough]
	public static void Null<T>(T value) where T : class
	{
		True(value == null);
	}

	[DebuggerStepThrough]
	public static void Is<T>(object value)
	{
		True(value is T);
	}

	[DebuggerStepThrough]
	public static void False(bool condition, string message = null)
	{
		if (condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	public static void False(bool condition, string unformattedMessage, object arg1)
	{
		if (condition)
		{
			Fail(Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	public static void False(bool condition, string unformattedMessage, params object[] args)
	{
		if (condition)
		{
			Fail(Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	public static void True(bool condition, string message = null)
	{
		if (!condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	public static void True(bool condition, string unformattedMessage, object arg1)
	{
		if (!condition)
		{
			Fail(Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	public static void True(bool condition, string unformattedMessage, params object[] args)
	{
		if (!condition)
		{
			Fail(Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	public static Exception NotReachable()
	{
		InternalErrorException ex = new InternalErrorException();
		if (true)
		{
			throw ex;
		}
		return null;
	}

	[DebuggerStepThrough]
	public static void Present<T>(T component)
	{
		if (component == null)
		{
			Type type = PrivateErrorHelpers.TrimGenericWrapper(typeof(T), typeof(Lazy<>));
			Fail(string.Format(CultureInfo.CurrentCulture, Strings.ServiceMissing, type.FullName));
		}
	}

	[DebuggerStepThrough]
	public static Exception Fail(string message = null, bool showAssert = true)
	{
		InternalErrorException ex = new InternalErrorException(message, showAssert);
		if (true)
		{
			throw ex;
		}
		return null;
	}

	public static Exception Fail(string message, Exception innerException, bool showAssert = true)
	{
		InternalErrorException ex = new InternalErrorException(message, innerException, showAssert);
		if (true)
		{
			throw ex;
		}
		return null;
	}

	private static string Format(string format, params object[] arguments)
	{
		return PrivateErrorHelpers.Format(format, arguments);
	}
}
public interface IDisposableObservable : IDisposable
{
	bool IsDisposed { get; }
}
internal static class PrivateErrorHelpers
{
	internal static Type TrimGenericWrapper(Type type, Type wrapper)
	{
		Type[] genericArguments;
		if (type.GetTypeInfo().IsGenericType && (object)type.GetGenericTypeDefinition() == wrapper && (genericArguments = TypeInfoExtensions.GetGenericArguments(type.GetTypeInfo())).Length == 1)
		{
			return genericArguments[0];
		}
		return type;
	}

	internal static string Format(string format, params object[] arguments)
	{
		return string.Format(CultureInfo.CurrentCulture, format, arguments);
	}
}
public static class Report
{
	[DebuggerStepThrough]
	public static void IfNotPresent<T>(T part)
	{
		if (part == null)
		{
			Type type = PrivateErrorHelpers.TrimGenericWrapper(typeof(T), typeof(Lazy<>));
			Fail(Strings.ServiceMissing, type.FullName);
		}
	}

	[DebuggerStepThrough]
	public static void If(bool condition, string message = null)
	{
		if (condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	public static void IfNot(bool condition, string message = null)
	{
		if (!condition)
		{
			Fail(message);
		}
	}

	[DebuggerStepThrough]
	public static void IfNot(bool condition, string message, object arg1)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, arg1));
		}
	}

	[DebuggerStepThrough]
	public static void IfNot(bool condition, string message, object arg1, object arg2)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, arg1, arg2));
		}
	}

	[DebuggerStepThrough]
	public static void IfNot(bool condition, string message, params object[] args)
	{
		if (!condition)
		{
			Fail(PrivateErrorHelpers.Format(message, args));
		}
	}

	[DebuggerStepThrough]
	public static void Fail(string message = null)
	{
		if (message == null)
		{
			message = "A recoverable error has been detected.";
		}
	}

	[DebuggerStepThrough]
	public static void Fail(string message, params object[] args)
	{
		Fail(PrivateErrorHelpers.Format(message, args));
	}
}
public static class Requires
{
	[DebuggerStepThrough]
	public static T NotNull<T>([ValidatedNotNull] T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	public static IntPtr NotNull(IntPtr value, string parameterName)
	{
		if (value == IntPtr.Zero)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	public static void NotNull([ValidatedNotNull] Task value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNull<T>([ValidatedNotNull] Task<T> value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[DebuggerStepThrough]
	public static T NotNullAllowStructs<T>([ValidatedNotNull] T value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] string value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (value.Length == 0 || value[0] == '\0')
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyString, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNullOrWhiteSpace([ValidatedNotNull] string value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (value.Length == 0 || value[0] == '\0')
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyString, parameterName), parameterName);
		}
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException(Format(Strings.Argument_Whitespace, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotNullOrEmpty([ValidatedNotNull] IEnumerable values, string parameterName)
	{
		if (values == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		if (values is ICollection collection)
		{
			if (collection.Count > 0)
			{
				return;
			}
			throw new ArgumentException(Format(Strings.Argument_EmptyArray, parameterName), parameterName);
		}
		IEnumerator enumerator = values.GetEnumerator();
		using (enumerator as IDisposable)
		{
			if (enumerator.MoveNext())
			{
				return;
			}
		}
		throw new ArgumentException(Format(Strings.Argument_EmptyArray, parameterName), parameterName);
	}

	[DebuggerStepThrough]
	public static void NotNullEmptyOrNullElements<T>([ValidatedNotNull] IEnumerable<T> values, string parameterName) where T : class
	{
		NotNull(values, parameterName);
		bool flag = false;
		foreach (T value in values)
		{
			flag = true;
			if (value == null)
			{
				throw new ArgumentException(Format(Strings.Argument_NullElement, parameterName), parameterName);
			}
		}
		if (!flag)
		{
			throw new ArgumentException(Format(Strings.Argument_EmptyArray, parameterName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NullOrNotNullElements<T>(IEnumerable<T> values, string parameterName)
	{
		if (values == null)
		{
			return;
		}
		foreach (T value in values)
		{
			if (value == null)
			{
				throw new ArgumentException(Format(Strings.Argument_NullElement, parameterName), parameterName);
			}
		}
	}

	[DebuggerStepThrough]
	public static void Range(bool condition, string parameterName, string message = null)
	{
		if (!condition)
		{
			FailRange(parameterName, message);
		}
	}

	[DebuggerStepThrough]
	public static Exception FailRange(string parameterName, string message = null)
	{
		if (string.IsNullOrEmpty(message))
		{
			throw new ArgumentOutOfRangeException(parameterName);
		}
		throw new ArgumentOutOfRangeException(parameterName, message);
	}

	[DebuggerStepThrough]
	public static void Defined<T>(T value, string parameterName) where T : struct, IConvertible, IComparable, IFormattable
	{
		if (!Enum.IsDefined(typeof(T), value))
		{
			throw new ArgumentException(Format(Strings.Argument_EnumNotDefined, parameterName, typeof(T).FullName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void NotDefault<T>(T value, string parameterName) where T : struct
	{
		if (default(T).Equals(value))
		{
			throw new ArgumentException(Format(Strings.Argument_StructIsDefault, parameterName, typeof(T).FullName), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message)
	{
		if (!condition)
		{
			throw new ArgumentException(message, parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, object arg1)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, arg1), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, object arg1, object arg2)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, arg1, arg2), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void Argument(bool condition, string parameterName, string message, params object[] args)
	{
		if (!condition)
		{
			throw new ArgumentException(Format(message, args), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void That(bool condition, string parameterName, string unformattedMessage, params object[] args)
	{
		if (!condition)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, unformattedMessage, args), parameterName);
		}
	}

	[DebuggerStepThrough]
	public static void ValidState(bool condition, string message)
	{
		if (!condition)
		{
			throw new InvalidOperationException(message);
		}
	}

	[DebuggerStepThrough]
	public static Exception Fail(string message)
	{
		throw new ArgumentException(message);
	}

	[DebuggerStepThrough]
	public static Exception Fail(string unformattedMessage, params object[] args)
	{
		throw Fail(Format(unformattedMessage, args));
	}

	[DebuggerStepThrough]
	public static Exception Fail(Exception innerException, string unformattedMessage, params object[] args)
	{
		throw new ArgumentException(Format(unformattedMessage, args), innerException);
	}

	private static string Format(string format, params object[] arguments)
	{
		return PrivateErrorHelpers.Format(format, arguments);
	}
}
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Strings
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("Validation.Strings", typeof(Strings).GetTypeInfo().Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string Argument_EmptyArray => ResourceManager.GetString("Argument_EmptyArray", resourceCulture);

	internal static string Argument_EmptyString => ResourceManager.GetString("Argument_EmptyString", resourceCulture);

	internal static string Argument_EnumNotDefined => ResourceManager.GetString("Argument_EnumNotDefined", resourceCulture);

	internal static string Argument_NullElement => ResourceManager.GetString("Argument_NullElement", resourceCulture);

	internal static string Argument_StructIsDefault => ResourceManager.GetString("Argument_StructIsDefault", resourceCulture);

	internal static string Argument_Whitespace => ResourceManager.GetString("Argument_Whitespace", resourceCulture);

	internal static string InternalExceptionMessage => ResourceManager.GetString("InternalExceptionMessage", resourceCulture);

	internal static string ServiceMissing => ResourceManager.GetString("ServiceMissing", resourceCulture);

	internal Strings()
	{
	}
}
internal static class TypeInfoExtensions
{
	internal static Type[] GetGenericArguments(this TypeInfo type)
	{
		return type.GenericTypeArguments;
	}
}
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class ValidatedNotNullAttribute : Attribute
{
}
public static class Verify
{
	[DebuggerStepThrough]
	public static void Operation(bool condition, string message)
	{
		if (!condition)
		{
			throw new InvalidOperationException(message);
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, object arg1)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, arg1));
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, object arg1, object arg2)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, arg1, arg2));
		}
	}

	[DebuggerStepThrough]
	public static void Operation(bool condition, string unformattedMessage, params object[] args)
	{
		if (!condition)
		{
			throw new InvalidOperationException(PrivateErrorHelpers.Format(unformattedMessage, args));
		}
	}

	[DebuggerStepThrough]
	public static Exception FailOperation(string message, params object[] args)
	{
		throw new InvalidOperationException(PrivateErrorHelpers.Format(message, args));
	}

	[DebuggerStepThrough]
	public static void NotDisposed(IDisposableObservable disposedValue, string message = null)
	{
		Requires.NotNull(disposedValue, "disposedValue");
		if (disposedValue.IsDisposed)
		{
			string objectName = ((disposedValue != null) ? disposedValue.GetType().FullName : string.Empty);
			if (message != null)
			{
				throw new ObjectDisposedException(objectName, message);
			}
			throw new ObjectDisposedException(objectName);
		}
	}

	[DebuggerStepThrough]
	public static void NotDisposed(bool condition, object disposedValue, string message = null)
	{
		if (!condition)
		{
			string objectName = ((disposedValue != null) ? disposedValue.GetType().FullName : string.Empty);
			if (message != null)
			{
				throw new ObjectDisposedException(objectName, message);
			}
			throw new ObjectDisposedException(objectName);
		}
	}

	[DebuggerStepThrough]
	public static void NotDisposed(bool condition, string message)
	{
		if (!condition)
		{
			throw new ObjectDisposedException(message);
		}
	}
}
