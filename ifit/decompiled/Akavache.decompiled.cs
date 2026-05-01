using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Akavache.Core;
using Akavache.Sqlite3;
using Android.Runtime;
using Microsoft.CodeAnalysis;
using SQLitePCL;
using Splat;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("7.1.1.22514")]
[assembly: AssemblyInformationalVersion("7.1.1+f257b0f8b9")]
[assembly: Akavache.Core.Preserve]
[assembly: ResourceDesigner("Akavache.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("An asynchronous, persistent key-value store for desktop and mobile applications on .NET")]
[assembly: AssemblyProduct("Akavache (MonoAndroid90)")]
[assembly: AssemblyTitle("Akavache")]
[assembly: AssemblyVersion("7.1.0.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
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
	[Microsoft.CodeAnalysis.Embedded]
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
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "7.1.0.0";

	internal const string AssemblyFileVersion = "7.1.1.22514";

	internal const string AssemblyInformationalVersion = "7.1.1+f257b0f8b9";

	internal const string AssemblyName = "Akavache";

	internal const string AssemblyTitle = "Akavache";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "f257b0f8b93ff304a0dc9c9fe33dbad619138537";

	internal const bool IsPublicRelease = true;

	internal const bool IsPrerelease = false;

	internal static readonly DateTime GitCommitDate = new DateTime(637390339680000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Akavache";
}
namespace Akavache
{
	[Akavache.Core.Preserve(AllMembers = true)]
	public class Registrations : IWantsToRegisterStuff
	{
		public static void Start(string applicationName)
		{
			Akavache.Sqlite3.Registrations.Start(applicationName, Batteries_V2.Init);
		}

		public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
		{
			Batteries_V2.Init();
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			static Attribute()
			{
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
namespace Akavache.Sqlite3
{
	[Akavache.Core.Preserve(AllMembers = true)]
	public static class LinkerPreserve
	{
		static LinkerPreserve()
		{
			throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
		}
	}
	public class SQLitePersistentBlobCache : SqlRawPersistentBlobCache
	{
		public SQLitePersistentBlobCache(string databaseFile, IScheduler? scheduler = null)
			: base(databaseFile, scheduler)
		{
		}
	}
}
