using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Runtime.Serialization.dll")]
[assembly: AssemblyDescription("System.Runtime.Serialization.dll")]
[assembly: AssemblyDefaultAlias("System.Runtime.Serialization.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("2.0.5.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("../silverlight.pub")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("2.0.5.0")]
[module: UnverifiableCode]
namespace System.Runtime.Serialization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
public sealed class DataContractAttribute : Attribute
{
	private string ns;

	private bool isNamespaceSetExplicitly;

	private bool isReference;

	public bool IsReference => isReference;

	public string Namespace
	{
		set
		{
			ns = value;
			isNamespaceSetExplicitly = true;
		}
	}
}
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class DataMemberAttribute : Attribute
{
	private string name;

	private int order = -1;

	private bool isRequired;

	private bool emitDefaultValue = true;

	public string Name => name;

	public int Order
	{
		get
		{
			return order;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataContractException(SR.GetString("Property 'Order' in DataMemberAttribute attribute cannot be a negative number.")));
			}
			order = value;
		}
	}

	public bool IsRequired => isRequired;

	public bool EmitDefaultValue => emitDefaultValue;
}
[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class EnumMemberAttribute : Attribute
{
	private string value;

	private bool isValueSetExplicitly;

	public string Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
			isValueSetExplicitly = true;
		}
	}
}
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class IgnoreDataMemberAttribute : Attribute
{
}
[Serializable]
public class InvalidDataContractException : Exception
{
	public InvalidDataContractException()
	{
	}

	public InvalidDataContractException(string message)
		: base(message)
	{
	}

	protected InvalidDataContractException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
internal static class DiagnosticUtility
{
	internal static class ExceptionUtility
	{
		internal static Exception ThrowHelperError(Exception e)
		{
			return ThrowHelper(e, TraceEventType.Error);
		}

		internal static Exception ThrowHelper(Exception e, TraceEventType type)
		{
			return e;
		}
	}
}
internal static class SR
{
	internal static string GetString(string name)
	{
		return name;
	}
}
