using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("SourceGear")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright 2014-2020 SourceGear, LLC")]
[assembly: AssemblyDescription("SQLitePCLRaw is a Portable Class Library (PCL) for low-level (raw) access to SQLite")]
[assembly: AssemblyFileVersion("2.0.4.976")]
[assembly: AssemblyInformationalVersion("2.0.4")]
[assembly: AssemblyTitle("SQLitePCLRaw.batteries_v2")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/ericsink/SQLitePCL.raw")]
[assembly: AssemblyVersion("2.0.4.976")]
namespace SQLitePCL;

public static class Batteries
{
	public static void Init()
	{
		Batteries_V2.Init();
	}
}
public static class Batteries_V2
{
	public static void Init()
	{
		raw.SetProvider(new SQLite3Provider_e_sqlite3());
	}
}
