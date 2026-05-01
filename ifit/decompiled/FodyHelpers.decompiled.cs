using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Fody;
using Microsoft.CodeAnalysis;
using Mono.Cecil;
using Mono.Cecil.Cil;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("FodyIsolated, PublicKey=0024000004800000940000000602000000240000525341310004000001000100F1DB6E31BB3DE8567F99174972F4AD7A91DB643505819CBAA82ED27A9BFA391E1BD72CBD4A1EB4C93F7122946B926A9672616F8A2BEF45DABB3C8AC655B365DFD5A1E7FE49E089D9E354499888BB49BDB4E9433C16A5EF61D52D3E39A590233659216EC85753981E4204D3B650DBED653B116DA2C30399A6F1A04196EA587BEC")]
[assembly: InternalsVisibleTo("FodyHelpers.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100F1DB6E31BB3DE8567F99174972F4AD7A91DB643505819CBAA82ED27A9BFA391E1BD72CBD4A1EB4C93F7122946B926A9672616F8A2BEF45DABB3C8AC655B365DFD5A1E7FE49E089D9E354499888BB49BDB4E9433C16A5EF61D52D3E39A590233659216EC85753981E4204D3B650DBED653B116DA2C30399A6F1A04196EA587BEC")]
[assembly: InternalsVisibleTo("Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100F1DB6E31BB3DE8567F99174972F4AD7A91DB643505819CBAA82ED27A9BFA391E1BD72CBD4A1EB4C93F7122946B926A9672616F8A2BEF45DABB3C8AC655B365DFD5A1E7FE49E089D9E354499888BB49BDB4E9433C16A5EF61D52D3E39A590233659216EC85753981E4204D3B650DBED653B116DA2C30399A6F1A04196EA587BEC")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("FodyHelpers")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Helpers for Fody.")]
[assembly: AssemblyFileVersion("6.2.4.0")]
[assembly: AssemblyInformationalVersion("6.2.4+d91549298036712b8f9c01dad01234478f8c6040")]
[assembly: AssemblyProduct("FodyHelpers")]
[assembly: AssemblyTitle("FodyHelpers")]
[assembly: AssemblyVersion("6.2.4.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
internal static class ConfigReader
{
	public static string? ReadString(this XElement element, string name, string? defaultValue = null)
	{
		Guard.AgainstNull("element", element);
		Guard.AgainstNullAndEmpty("name", name);
		XAttribute xAttribute = element.Attribute(name);
		if (xAttribute == null)
		{
			return defaultValue;
		}
		return xAttribute.Value;
	}

	public static bool ReadBool(this XElement element, string name, bool defaultValue)
	{
		Guard.AgainstNull("element", element);
		Guard.AgainstNullAndEmpty("name", name);
		XAttribute xAttribute = element.Attribute(name);
		if (xAttribute == null)
		{
			return defaultValue;
		}
		string value = xAttribute.Value;
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new WeavingException("Could not extract '" + name + "' from xml config. Null, empty, or whitespace are invalid.");
		}
		try
		{
			return XmlConvert.ToBoolean(value);
		}
		catch
		{
			throw new WeavingException("Could not extract '" + name + "' from xml config. Value '" + value + "' could not be converted to a bool. Only '1', '0', 'true', or 'false' are valid.");
		}
	}
}
internal static class ReferenceCleaner
{
	public static void CleanReferences(ModuleDefinition module, BaseModuleWeaver weaver, Action<string> log)
	{
		if (weaver.ShouldCleanReference)
		{
			string weaverLibName = weaver.GetType().Assembly.GetName().Name.ReplaceCaseless(".Fody", "");
			log("\tRemoving reference to '" + weaverLibName + "'.");
			AssemblyNameReference assemblyNameReference = module.AssemblyReferences.FirstOrDefault((AssemblyNameReference x) => x.Name == weaverLibName);
			if (assemblyNameReference != null)
			{
				module.AssemblyReferences.Remove(assemblyNameReference);
			}
			HashSet<string> copyLocalFilesToRemove = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				weaverLibName + ".dll",
				weaverLibName + ".xml",
				weaverLibName + ".pdb"
			};
			weaver.ReferenceCopyLocalPaths.RemoveAll((string refPath) => copyLocalFilesToRemove.Contains(Path.GetFileName(refPath)));
		}
	}
}
internal static class StringExtensions
{
	public static string ReplaceCaseless(this string str, string oldValue, string newValue)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2;
		for (num2 = str.IndexOf(oldValue, StringComparison.OrdinalIgnoreCase); num2 != -1; num2 = str.IndexOf(oldValue, num2, StringComparison.OrdinalIgnoreCase))
		{
			stringBuilder.Append(str.Substring(num, num2 - num));
			stringBuilder.Append(newValue);
			num2 += oldValue.Length;
			num = num2;
		}
		stringBuilder.Append(str.Substring(num));
		return stringBuilder.ToString();
	}
}
internal static class SdkToolFinder
{
	private static string windowsSdkDirectory;

	private static bool foundToolsDirectory;

	static SdkToolFinder()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		windowsSdkDirectory = Path.Combine(folderPath, "Microsoft SDKs\\Windows");
		if (Directory.Exists(windowsSdkDirectory))
		{
			foundToolsDirectory = true;
		}
	}

	public static bool TryFindTool(string tool, [NotNullWhen(true)] out string? path)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		windowsSdkDirectory = Path.Combine(folderPath, "Microsoft SDKs\\Windows");
		if (!foundToolsDirectory)
		{
			path = null;
			return false;
		}
		path = (from x in Directory.EnumerateFiles(windowsSdkDirectory, tool + ".exe", SearchOption.AllDirectories)
			where !x.ToLowerInvariant().Contains("x64")
			select x).OrderByDescending(delegate(string x)
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(x);
			return new Version(versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart);
		}).FirstOrDefault();
		return path != null;
	}
}
internal class SymbolReaderProvider : ISymbolReaderProvider
{
	private DefaultSymbolReaderProvider inner;

	public SymbolReaderProvider()
	{
		inner = new DefaultSymbolReaderProvider(throwIfNoSymbol: false);
	}

	public ISymbolReader? GetSymbolReader(ModuleDefinition module, string fileName)
	{
		ISymbolReader symbolReader = inner.GetSymbolReader(module, fileName);
		if (symbolReader != null)
		{
			return symbolReader;
		}
		string fileName2 = Path.ChangeExtension(fileName, "compile.dll");
		return inner.GetSymbolReader(module, fileName2);
	}

	public ISymbolReader? GetSymbolReader(ModuleDefinition module, Stream symbolStream)
	{
		throw new NotSupportedException();
	}
}
namespace System.Diagnostics.CodeAnalysis
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class AllowNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class DisallowNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class DoesNotReturnAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class DoesNotReturnIfAttribute : Attribute
	{
		public bool ParameterValue { get; }

		public DoesNotReturnIfAttribute(bool parameterValue)
		{
			ParameterValue = parameterValue;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class MaybeNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class MaybeNullWhenAttribute : Attribute
	{
		public bool ReturnValue { get; }

		public MaybeNullWhenAttribute(bool returnValue)
		{
			ReturnValue = returnValue;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class NotNullAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class NotNullIfNotNullAttribute : Attribute
	{
		public string ParameterName { get; }

		public NotNullIfNotNullAttribute(string parameterName)
		{
			ParameterName = parameterName;
		}
	}
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	internal sealed class NotNullWhenAttribute : Attribute
	{
		public bool ReturnValue { get; }

		public NotNullWhenAttribute(bool returnValue)
		{
			ReturnValue = returnValue;
		}
	}
}
namespace Fody
{
	public abstract class BaseModuleWeaver
	{
		private static XElement Empty = new XElement("Empty");

		public XElement Config { get; set; } = Empty;

		[Obsolete("Use WriteDebug", false)]
		public Action<string> LogDebug { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteInfo", false)]
		public Action<string> LogInfo { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteMessage", false)]
		public Action<string, MessageImportance> LogMessage { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteWarning", false)]
		public Action<string> LogWarning { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteWarning", false)]
		public Action<string, SequencePoint?> LogWarningPoint { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteError", false)]
		public Action<string> LogError { get; set; } = delegate
		{
		};

		[Obsolete("Use WriteError", false)]
		public Action<string, SequencePoint?> LogErrorPoint { get; set; } = delegate
		{
		};

		public Func<string, AssemblyDefinition?> ResolveAssembly { get; set; }

		public ModuleDefinition ModuleDefinition { get; set; }

		public TypeSystem TypeSystem { get; set; }

		public string AssemblyFilePath { get; set; }

		public string ProjectDirectoryPath { get; set; }

		public string ProjectFilePath { get; set; }

		public string? DocumentationFilePath { get; set; }

		public string AddinDirectoryPath { get; set; }

		public string SolutionDirectoryPath { get; set; }

		public string References { get; set; }

		public List<string> ReferenceCopyLocalPaths { get; set; } = new List<string>();

		public List<string> DefineConstants { get; set; } = new List<string>();

		[Obsolete("Use FindTypeDefinition", false)]
		public Func<string, TypeDefinition> FindType { get; set; } = delegate
		{
			throw new WeavingException("FindType has not been set.");
		};

		[Obsolete("Use TryFindTypeDefinition", false)]
		public TryFindTypeFunc TryFindType { get; set; } = delegate
		{
			throw new WeavingException("TryFindType has not been set.");
		};

		public virtual bool ShouldCleanReference => false;

		public virtual void WriteDebug(string message)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogDebug(message);
		}

		public virtual void WriteInfo(string message)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogInfo(message);
		}

		public virtual void WriteMessage(string message, MessageImportance importance)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogMessage(message, importance);
		}

		public virtual void WriteWarning(string message)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogWarning(message);
		}

		public virtual void WriteWarning(string message, SequencePoint? sequencePoint)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogWarningPoint(message, sequencePoint);
		}

		public virtual void WriteWarning(string message, MethodDefinition method)
		{
			Guard.AgainstNullAndEmpty("message", message);
			Guard.AgainstNull("method", method);
			LogWarningPoint(message, method.GetSequencePoint());
		}

		public virtual void WriteError(string message)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogError(message);
		}

		public virtual void WriteError(string message, SequencePoint? sequencePoint)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogErrorPoint(message, sequencePoint);
		}

		public virtual void WriteError(string message, MethodDefinition method)
		{
			Guard.AgainstNullAndEmpty("message", message);
			LogErrorPoint(message, method.GetSequencePoint());
		}

		public abstract void Execute();

		public virtual void Cancel()
		{
		}

		public abstract IEnumerable<string> GetAssembliesForScanning();

		public TypeDefinition FindTypeDefinition(string name)
		{
			return FindType(name);
		}

		public bool TryFindTypeDefinition(string name, [NotNullWhen(true)] out TypeDefinition? type)
		{
			return TryFindType(name, out type);
		}

		public virtual void AfterWeaving()
		{
		}
	}
	public static class CecilExtensions
	{
		public static SequencePoint? GetSequencePoint(this MethodDefinition method)
		{
			Guard.AgainstNull("method", method);
			return method.Body.Instructions.Select((Instruction instruction) => method.DebugInformation.GetSequencePoint(instruction)).FirstOrDefault((SequencePoint sequencePoint) => sequencePoint != null);
		}
	}
	[Obsolete("Not for public use")]
	public static class Guard
	{
		public static void AgainstNull(string argumentName, object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(argumentName);
			}
		}

		public static void AgainstNullAndEmpty(string argumentName, string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(argumentName);
			}
		}

		public static void FileExists(string argumentName, string path)
		{
			AgainstNullAndEmpty(argumentName, path);
			if (!File.Exists(path))
			{
				throw new ArgumentException("File not found. Path: " + path);
			}
		}
	}
	[Serializable]
	public enum MessageImportance
	{
		High,
		Normal,
		Low
	}
	public static class MessageImportanceDefaults
	{
		public static readonly MessageImportance Debug = MessageImportance.Low;

		public static readonly MessageImportance Info = MessageImportance.Normal;
	}
	public static class Ildasm
	{
		private static string? ildasmPath;

		public static readonly bool FoundIldasm;

		static Ildasm()
		{
			FoundIldasm = SdkToolFinder.TryFindTool("ildasm", out ildasmPath);
		}

		public static string Decompile(string assemblyPath, string? item = "")
		{
			Guard.AgainstNullAndEmpty("assemblyPath", assemblyPath);
			if (!FoundIldasm)
			{
				throw new Exception("Could not find find ildasm.exe.");
			}
			if (!string.IsNullOrEmpty(item))
			{
				item = "/item:" + item;
			}
			ProcessStartInfo startInfo = new ProcessStartInfo(ildasmPath, "\"" + assemblyPath + "\" /text /linenum /source " + item)
			{
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			using Process process = Process.Start(startInfo);
			StringBuilder stringBuilder = new StringBuilder();
			string text;
			while ((text = process.StandardOutput.ReadLine()) != null)
			{
				text = text.Trim();
				if (text.Length != 0 && !text.Contains(".line ") && !text.Contains(".custom instance void [") && !text.StartsWith("// ") && !text.StartsWith("//0"))
				{
					if (text.StartsWith("  } // end of "))
					{
						stringBuilder.AppendLine("  } ");
					}
					else if (text.StartsWith("} // end of "))
					{
						stringBuilder.AppendLine("}");
					}
					else if (!text.StartsWith("    .get instance ") && !text.StartsWith("    .set instance ") && !text.Contains(".language '"))
					{
						stringBuilder.AppendLine(text);
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
	public class LogMessage
	{
		public string Text { get; }

		public object MessageImportance { get; }

		public LogMessage(string text, object messageImportance)
		{
			Text = text;
			MessageImportance = messageImportance;
		}
	}
	public static class PeVerifier
	{
		public static readonly bool FoundPeVerify;

		private static string? peverifyPath;

		static PeVerifier()
		{
			FoundPeVerify = SdkToolFinder.TryFindTool("peverify", out peverifyPath);
		}

		public static bool Verify(string assemblyPath, IEnumerable<string> ignoreCodes, out string output, string? workingDirectory = null)
		{
			Guard.AgainstNullAndEmpty("assemblyPath", assemblyPath);
			Guard.AgainstNull("ignoreCodes", ignoreCodes);
			if (!FoundPeVerify)
			{
				throw new Exception("Could not find find peverify.exe in.");
			}
			if (ignoreCodes == null)
			{
				throw new ArgumentNullException("ignoreCodes");
			}
			if (string.IsNullOrWhiteSpace(assemblyPath))
			{
				throw new ArgumentNullException("assemblyPath");
			}
			if (!File.Exists(assemblyPath))
			{
				throw new ArgumentNullException("Cannot verify assembly, file '" + assemblyPath + "' does not exist");
			}
			return InnerVerify(assemblyPath, ignoreCodes.ToList(), out output, workingDirectory);
		}

		public static bool Verify(string beforeAssemblyPath, string afterAssemblyPath, IEnumerable<string> ignoreCodes, out string beforeOutput, out string afterOutput, string? workingDirectory = null)
		{
			Guard.AgainstNullAndEmpty("beforeAssemblyPath", beforeAssemblyPath);
			Guard.AgainstNullAndEmpty("afterAssemblyPath", afterAssemblyPath);
			Guard.AgainstNull("ignoreCodes", ignoreCodes);
			List<string> ignoreCodes2 = ignoreCodes.ToList();
			InnerVerify(beforeAssemblyPath, ignoreCodes2, out beforeOutput, workingDirectory);
			InnerVerify(afterAssemblyPath, ignoreCodes2, out afterOutput, workingDirectory);
			afterOutput = TrimLineNumbers(afterOutput);
			beforeOutput = TrimLineNumbers(beforeOutput);
			return afterOutput == beforeOutput;
		}

		public static void ThrowIfDifferent(string beforeAssemblyPath, string afterAssemblyPath, string? workingDirectory = null)
		{
			Guard.AgainstNullAndEmpty("beforeAssemblyPath", beforeAssemblyPath);
			Guard.AgainstNullAndEmpty("afterAssemblyPath", afterAssemblyPath);
			ThrowIfDifferent(beforeAssemblyPath, afterAssemblyPath, Enumerable.Empty<string>(), workingDirectory);
		}

		public static void ThrowIfDifferent(string beforeAssemblyPath, string afterAssemblyPath, IEnumerable<string> ignoreCodes, string? workingDirectory = null)
		{
			Guard.AgainstNullAndEmpty("beforeAssemblyPath", beforeAssemblyPath);
			Guard.AgainstNullAndEmpty("afterAssemblyPath", afterAssemblyPath);
			Verify(beforeAssemblyPath, afterAssemblyPath, ignoreCodes, out string beforeOutput, out string afterOutput, workingDirectory);
			if (beforeOutput == afterOutput)
			{
				return;
			}
			throw new Exception("The files have difference peverify results.\n\nAfterOutput:\n" + afterOutput + "\n\nBeforeOutput:\n" + beforeOutput);
		}

		public static string TrimLineNumbers(string input)
		{
			return Regex.Replace(input, "\\[offset .*\\]", "");
		}

		private static bool InnerVerify(string assemblyPath, List<string> ignoreCodes, out string output, string? workingDirectory = null)
		{
			ignoreCodes.Add("0x80070002");
			ignoreCodes.Add("0x80131252");
			if (workingDirectory == null)
			{
				workingDirectory = Path.GetDirectoryName(assemblyPath);
			}
			ProcessStartInfo startInfo = new ProcessStartInfo(peverifyPath)
			{
				Arguments = "\"" + assemblyPath + "\" /hresult /nologo /ignore=" + string.Join(",", ignoreCodes),
				WorkingDirectory = workingDirectory,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true
			};
			using (Process process = Process.Start(startInfo))
			{
				output = process.StandardOutput.ReadToEnd();
				output = Regex.Replace(output, "^All Classes and Methods.*", "");
				output = output.Trim();
				if (!process.WaitForExit(10000))
				{
					throw new Exception("PeVerify failed to exit");
				}
				if (process.ExitCode != 0)
				{
					return false;
				}
			}
			return true;
		}
	}
	public class SequencePointMessage
	{
		public string Text { get; }

		public SequencePoint? SequencePoint { get; }

		public SequencePointMessage(string text, SequencePoint? sequencePoint)
		{
			Text = text;
			SequencePoint = sequencePoint;
		}
	}
	public class TestAssemblyResolver : IAssemblyResolver, IDisposable
	{
		private Dictionary<string, AssemblyDefinition> definitions = new Dictionary<string, AssemblyDefinition>(StringComparer.OrdinalIgnoreCase);

		public void Dispose()
		{
			foreach (AssemblyDefinition value in definitions.Values)
			{
				value.Dispose();
			}
		}

		public AssemblyDefinition? Resolve(AssemblyNameReference name)
		{
			return Resolve(name.Name);
		}

		public AssemblyDefinition? Resolve(string name)
		{
			if (!definitions.TryGetValue(name, out AssemblyDefinition value))
			{
				if (!TryGetAssemblyLocation(name, out string assemblyLocation))
				{
					return null;
				}
				value = (definitions[name] = GetAssemblyDefinition(assemblyLocation));
			}
			return value;
		}

		private static bool TryGetAssemblyLocation(string name, [NotNullWhen(true)] out string? assemblyLocation)
		{
			if (string.Equals(name, "netstandard", StringComparison.OrdinalIgnoreCase))
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "dotnet\\sdk\\NuGetFallbackFolder\\netstandard.library\\2.0.0\\build\\netstandard2.0\\ref\\netstandard.dll");
				if (File.Exists(text))
				{
					assemblyLocation = text;
					return true;
				}
			}
			Assembly assembly = GetAssembly(name);
			if (assembly == null)
			{
				assemblyLocation = null;
				return false;
			}
			assemblyLocation = assembly.Location;
			return true;
		}

		private static Assembly? GetAssembly(string name)
		{
			if (string.Equals(name, "System", StringComparison.OrdinalIgnoreCase))
			{
				return typeof(GeneratedCodeAttribute).Assembly;
			}
			try
			{
				return Assembly.LoadWithPartialName(name);
			}
			catch (FileNotFoundException)
			{
				return null;
			}
		}

		private AssemblyDefinition GetAssemblyDefinition(string assemblyLocation)
		{
			ReaderParameters parameters = new ReaderParameters(ReadingMode.Deferred)
			{
				ReadWrite = false,
				ReadSymbols = false,
				AssemblyResolver = this
			};
			return AssemblyDefinition.ReadAssembly(assemblyLocation, parameters);
		}

		public AssemblyDefinition? Resolve(AssemblyNameReference name, ReaderParameters parameters)
		{
			return Resolve(name);
		}
	}
	public class TestResult
	{
		private List<LogMessage> messages = new List<LogMessage>();

		private List<SequencePointMessage> warnings = new List<SequencePointMessage>();

		private List<SequencePointMessage> errors = new List<SequencePointMessage>();

		public IReadOnlyList<LogMessage> Messages => messages;

		public IReadOnlyList<SequencePointMessage> Warnings => warnings;

		public IReadOnlyList<SequencePointMessage> Errors => errors;

		public Assembly Assembly { get; internal set; }

		public string AssemblyPath { get; internal set; }

		internal void AddMessage(string text, MessageImportance messageImportance)
		{
			LogMessage item = new LogMessage(text, messageImportance);
			messages.Add(item);
		}

		internal void AddWarning(string text, SequencePoint? sequencePoint)
		{
			SequencePointMessage item = new SequencePointMessage(text, sequencePoint);
			warnings.Add(item);
		}

		internal void AddError(string text, SequencePoint? sequencePoint)
		{
			SequencePointMessage item = new SequencePointMessage(text, sequencePoint);
			errors.Add(item);
		}

		public dynamic GetInstance(string className)
		{
			Guard.AgainstNullAndEmpty("className", className);
			Type type = Assembly.GetType(className, throwOnError: true);
			return Activator.CreateInstance(type);
		}

		public dynamic GetGenericInstance(string className, params Type[] types)
		{
			Guard.AgainstNullAndEmpty("className", className);
			Type type = Assembly.GetType(className, throwOnError: true);
			Type type2 = type.MakeGenericType(types);
			return Activator.CreateInstance(type2);
		}
	}
	public static class WeaverTestHelper
	{
		public static TestResult ExecuteTestRun(this BaseModuleWeaver weaver, string assemblyPath, bool runPeVerify = true, Action<ModuleDefinition>? afterExecuteCallback = null, Action<ModuleDefinition>? beforeExecuteCallback = null, string? assemblyName = null, IEnumerable<string>? ignoreCodes = null, bool writeSymbols = false)
		{
			assemblyPath = Path.GetFullPath(assemblyPath);
			Guard.FileExists("assemblyPath", assemblyPath);
			string text = Path.Combine(Path.GetDirectoryName(assemblyPath), "fodytemp");
			Directory.CreateDirectory(text);
			string path;
			if (assemblyName == null)
			{
				assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);
				path = Path.GetFileName(assemblyPath);
			}
			else
			{
				path = assemblyName + ".dll";
			}
			string text2 = Path.Combine(text, path);
			File.Delete(text2);
			using TestAssemblyResolver testAssemblyResolver = new TestAssemblyResolver();
			TypeCache typeCache = CacheTypes(weaver, testAssemblyResolver);
			TestResult testStatus = new TestResult();
			weaver.LogDebug = delegate(string text3)
			{
				testStatus.AddMessage(text3, MessageImportanceDefaults.Debug);
			};
			weaver.LogInfo = delegate(string text3)
			{
				testStatus.AddMessage(text3, MessageImportanceDefaults.Info);
			};
			weaver.LogMessage = delegate(string text3, MessageImportance messageImportance)
			{
				testStatus.AddMessage(text3, messageImportance);
			};
			weaver.LogWarning = delegate(string text3)
			{
				testStatus.AddWarning(text3, null);
			};
			weaver.LogWarningPoint = delegate(string text3, SequencePoint? sequencePoint)
			{
				testStatus.AddWarning(text3, sequencePoint);
			};
			weaver.LogError = delegate(string text3)
			{
				testStatus.AddError(text3, null);
			};
			weaver.LogErrorPoint = delegate(string text3, SequencePoint? sequencePoint)
			{
				testStatus.AddError(text3, sequencePoint);
			};
			weaver.AssemblyFilePath = assemblyPath;
			weaver.FindType = typeCache.FindType;
			weaver.TryFindType = typeCache.TryFindType;
			weaver.ResolveAssembly = testAssemblyResolver.Resolve;
			ReaderParameters parameters = new ReaderParameters
			{
				AssemblyResolver = testAssemblyResolver,
				SymbolReaderProvider = new SymbolReaderProvider(),
				ReadWrite = false,
				ReadSymbols = true
			};
			using (ModuleDefinition moduleDefinition = ModuleDefinition.ReadModule(assemblyPath, parameters))
			{
				moduleDefinition.Assembly.Name.Name = assemblyName;
				weaver.ModuleDefinition = moduleDefinition;
				weaver.TypeSystem = new TypeSystem(typeCache.FindType, moduleDefinition);
				beforeExecuteCallback?.Invoke(moduleDefinition);
				weaver.Execute();
				ReferenceCleaner.CleanReferences(moduleDefinition, weaver, weaver.LogDebug);
				afterExecuteCallback?.Invoke(moduleDefinition);
				WriterParameters writerParameters = new WriterParameters
				{
					WriteSymbols = writeSymbols
				};
				if (writeSymbols)
				{
					writerParameters.SymbolWriterProvider = new EmbeddedPortablePdbWriterProvider();
				}
				moduleDefinition.Write(text2, writerParameters);
			}
			if (runPeVerify && IsWindows())
			{
				List<string> ignoreCodes2 = ((ignoreCodes != null) ? ignoreCodes.ToList() : new List<string>());
				PeVerifier.ThrowIfDifferent(assemblyPath, text2, ignoreCodes2, Path.GetDirectoryName(assemblyPath));
			}
			testStatus.Assembly = Assembly.Load(File.ReadAllBytes(text2));
			testStatus.AssemblyPath = text2;
			return testStatus;
		}

		private static bool IsWindows()
		{
			string text = Environment.OSVersion.Platform.ToString();
			return text.StartsWith("win", StringComparison.OrdinalIgnoreCase);
		}

		private static TypeCache CacheTypes(BaseModuleWeaver weaver, TestAssemblyResolver assemblyResolver)
		{
			TypeCache typeCache = new TypeCache(assemblyResolver.Resolve);
			typeCache.BuildAssembliesToScan(weaver);
			return typeCache;
		}
	}
	[Obsolete("No longer required as BaseModuleWeaver.TryFindType has been replace with BaseModuleWeaver.TryFindTypeDefinition", false)]
	public delegate bool TryFindTypeFunc(string typeName, [NotNullWhen(true)] out TypeDefinition? type);
	public class TypeCache
	{
		private Func<string, AssemblyDefinition?> resolve;

		public static List<string> defaultAssemblies = new List<string> { "mscorlib", "System", "System.Runtime", "System.Core", "netstandard" };

		private Dictionary<string, TypeDefinition> cachedTypes = new Dictionary<string, TypeDefinition>();

		public TypeCache(Func<string, AssemblyDefinition?> resolve)
		{
			this.resolve = resolve;
		}

		public void BuildAssembliesToScan(BaseModuleWeaver weaver)
		{
			BuildAssembliesToScan(new BaseModuleWeaver[1] { weaver });
		}

		public void BuildAssembliesToScan(IEnumerable<BaseModuleWeaver> weavers)
		{
			Dictionary<string, AssemblyDefinition> dictionary = new Dictionary<string, AssemblyDefinition>(StringComparer.OrdinalIgnoreCase);
			foreach (string item in GetAssembliesForScanning(weavers))
			{
				AssemblyDefinition assemblyDefinition = resolve(item);
				if (assemblyDefinition != null && !dictionary.ContainsKey(item))
				{
					dictionary.Add(item, assemblyDefinition);
				}
			}
			Initialise(dictionary.Values);
		}

		private IEnumerable<string> GetAssembliesForScanning(IEnumerable<BaseModuleWeaver> weavers)
		{
			foreach (string defaultAssembly in defaultAssemblies)
			{
				yield return defaultAssembly;
			}
			foreach (BaseModuleWeaver weaver in weavers)
			{
				foreach (string item in weaver.GetAssembliesForScanning())
				{
					yield return item;
				}
			}
		}

		private void Initialise(IEnumerable<AssemblyDefinition> assemblyDefinitions)
		{
			List<AssemblyDefinition> list = assemblyDefinitions.ToList();
			foreach (AssemblyDefinition item in list)
			{
				foreach (TypeDefinition type in item.MainModule.GetTypes())
				{
					AddIfPublic(type);
				}
			}
			foreach (AssemblyDefinition item2 in list)
			{
				foreach (ExportedType exportedType in item2.MainModule.ExportedTypes)
				{
					if (!list.Any((AssemblyDefinition x) => x.Name.Name == exportedType.Scope.Name))
					{
						TypeDefinition typeDefinition = exportedType.Resolve();
						if (typeDefinition != null)
						{
							AddIfPublic(typeDefinition);
						}
					}
				}
			}
		}

		public virtual TypeDefinition FindType(string typeName)
		{
			if (cachedTypes.TryGetValue(typeName, out TypeDefinition value))
			{
				return value;
			}
			if (FindFromValues(typeName, out TypeDefinition type))
			{
				return type;
			}
			throw new WeavingException("Could not find '" + typeName + "'.");
		}

		private bool FindFromValues(string typeName, [NotNullWhen(true)] out TypeDefinition? type)
		{
			if (!Enumerable.Contains(typeName, '.'))
			{
				List<TypeDefinition> list = cachedTypes.Values.Where((TypeDefinition x) => x.Name == typeName).ToList();
				if (list.Count > 1)
				{
					throw new WeavingException("Found multiple types for '" + typeName + "'.");
				}
				if (list.Count == 0)
				{
					type = null;
					return false;
				}
				type = list[0];
				return true;
			}
			type = null;
			return false;
		}

		public virtual bool TryFindType(string typeName, [NotNullWhen(true)] out TypeDefinition? type)
		{
			if (cachedTypes.TryGetValue(typeName, out type))
			{
				return true;
			}
			return FindFromValues(typeName, out type);
		}

		private void AddIfPublic(TypeDefinition type)
		{
			if (type.IsPublic && !cachedTypes.ContainsKey(type.FullName))
			{
				cachedTypes.Add(type.FullName, type);
			}
		}
	}
	public class TypeSystem
	{
		public TypeReference IntPtrReference { get; }

		public TypeReference UIntPtrReference { get; }

		public TypeReference StringReference { get; }

		public TypeReference ObjectReference { get; }

		public TypeReference VoidReference { get; }

		public TypeReference BooleanReference { get; }

		public TypeReference CharReference { get; }

		public TypeReference SByteReference { get; }

		public TypeReference ByteReference { get; }

		public TypeReference Int16Reference { get; }

		public TypeReference UInt16Reference { get; }

		public TypeReference Int32Reference { get; }

		public TypeReference UInt32Reference { get; }

		public TypeReference Int64Reference { get; }

		public TypeReference UInt64Reference { get; }

		public TypeReference SingleReference { get; }

		public TypeReference DoubleReference { get; }

		public TypeDefinition ObjectDefinition { get; }

		public TypeDefinition VoidDefinition { get; }

		public TypeDefinition BooleanDefinition { get; }

		public TypeDefinition CharDefinition { get; }

		public TypeDefinition SByteDefinition { get; }

		public TypeDefinition ByteDefinition { get; }

		public TypeDefinition Int16Definition { get; }

		public TypeDefinition UInt16Definition { get; }

		public TypeDefinition Int32Definition { get; }

		public TypeDefinition UInt32Definition { get; }

		public TypeDefinition Int64Definition { get; }

		public TypeDefinition UInt64Definition { get; }

		public TypeDefinition SingleDefinition { get; }

		public TypeDefinition DoubleDefinition { get; }

		public TypeDefinition IntPtrDefinition { get; }

		public TypeDefinition UIntPtrDefinition { get; }

		public TypeDefinition StringDefinition { get; }

		public TypeSystem(Func<string, TypeDefinition> resolve, ModuleDefinition module)
		{
			ObjectDefinition = resolve("System.Object");
			ObjectReference = module.ImportReference(ObjectDefinition);
			VoidDefinition = resolve("System.Void");
			VoidReference = module.ImportReference(VoidDefinition);
			BooleanDefinition = resolve("System.Boolean");
			BooleanReference = module.ImportReference(BooleanDefinition);
			CharDefinition = resolve("System.Char");
			CharReference = module.ImportReference(CharDefinition);
			SByteDefinition = resolve("System.SByte");
			SByteReference = module.ImportReference(SByteDefinition);
			ByteDefinition = resolve("System.Byte");
			ByteReference = module.ImportReference(ByteDefinition);
			Int16Definition = resolve("System.Int16");
			Int16Reference = module.ImportReference(Int16Definition);
			UInt16Definition = resolve("System.UInt16");
			UInt16Reference = module.ImportReference(UInt16Definition);
			Int32Definition = resolve("System.Int32");
			Int32Reference = module.ImportReference(Int32Definition);
			UInt32Definition = resolve("System.UInt32");
			UInt32Reference = module.ImportReference(UInt32Definition);
			Int64Definition = resolve("System.Int64");
			Int64Reference = module.ImportReference(Int64Definition);
			UInt64Definition = resolve("System.UInt64");
			UInt64Reference = module.ImportReference(UInt64Definition);
			SingleDefinition = resolve("System.Single");
			SingleReference = module.ImportReference(SingleDefinition);
			DoubleDefinition = resolve("System.Double");
			DoubleReference = module.ImportReference(DoubleDefinition);
			IntPtrDefinition = resolve("System.IntPtr");
			IntPtrReference = module.ImportReference(IntPtrDefinition);
			UIntPtrDefinition = resolve("System.UIntPtr");
			UIntPtrReference = module.ImportReference(UIntPtrDefinition);
			StringDefinition = resolve("System.String");
			StringReference = module.ImportReference(StringDefinition);
		}
	}
	public class WeavingException : Exception
	{
		public SequencePoint? SequencePoint { get; set; }

		public WeavingException(string message)
			: base(message)
		{
		}
	}
}
