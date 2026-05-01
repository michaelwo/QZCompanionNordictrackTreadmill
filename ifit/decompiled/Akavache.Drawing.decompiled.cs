using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Akavache.Core;
using Android.Runtime;
using Splat;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("6.10.4.45720")]
[assembly: AssemblyInformationalVersion("6.10.4+98b267559b")]
[assembly: ResourceDesigner("Akavache.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("An asynchronous, persistent key-value store for desktop and mobile applications on .NET")]
[assembly: AssemblyProduct("Akavache.Drawing (MonoAndroid90)")]
[assembly: AssemblyTitle("Akavache.Drawing")]
[assembly: AssemblyVersion("6.10.0.0")]
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "6.10.0.0";

	internal const string AssemblyFileVersion = "6.10.4.45720";

	internal const string AssemblyInformationalVersion = "6.10.4+98b267559b";

	internal const string AssemblyName = "Akavache.Drawing";

	internal const string AssemblyTitle = "Akavache.Drawing";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "98b267559b5132df0a12cdbf3cbb35adebf2a7ab";

	internal static readonly DateTime GitCommitDate = new DateTime(637164527460000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Akavache";
}
namespace Akavache;

public static class BitmapImageMixin
{
	public static IObservable<IBitmap> LoadImage(this IBlobCache blobCache, string key, float? desiredWidth = null, float? desiredHeight = null)
	{
		if (blobCache == null)
		{
			throw new ArgumentNullException("blobCache");
		}
		return blobCache.Get(key).SelectMany(ThrowOnBadImageBuffer).SelectMany((byte[] x) => BytesToImage(x, desiredWidth, desiredHeight));
	}

	public static IObservable<IBitmap> LoadImageFromUrl(this IBlobCache blobCache, string url, bool fetchAlways = false, float? desiredWidth = null, float? desiredHeight = null, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache == null)
		{
			throw new ArgumentNullException("blobCache");
		}
		return blobCache.DownloadUrl(url, null, fetchAlways, absoluteExpiration).SelectMany(ThrowOnBadImageBuffer).SelectMany((byte[] x) => BytesToImage(x, desiredWidth, desiredHeight));
	}

	public static IObservable<IBitmap> LoadImageFromUrl(this IBlobCache blobCache, Uri url, bool fetchAlways = false, float? desiredWidth = null, float? desiredHeight = null, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache == null)
		{
			throw new ArgumentNullException("blobCache");
		}
		return blobCache.DownloadUrl(url, null, fetchAlways, absoluteExpiration).SelectMany(ThrowOnBadImageBuffer).SelectMany((byte[] x) => BytesToImage(x, desiredWidth, desiredHeight));
	}

	public static IObservable<IBitmap> LoadImageFromUrl(this IBlobCache blobCache, string key, string url, bool fetchAlways = false, float? desiredWidth = null, float? desiredHeight = null, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache == null)
		{
			throw new ArgumentNullException("blobCache");
		}
		return blobCache.DownloadUrl(key, url, null, fetchAlways, absoluteExpiration).SelectMany(ThrowOnBadImageBuffer).SelectMany((byte[] x) => BytesToImage(x, desiredWidth, desiredHeight));
	}

	public static IObservable<IBitmap> LoadImageFromUrl(this IBlobCache blobCache, string key, Uri url, bool fetchAlways = false, float? desiredWidth = null, float? desiredHeight = null, DateTimeOffset? absoluteExpiration = null)
	{
		if (blobCache == null)
		{
			throw new ArgumentNullException("blobCache");
		}
		return blobCache.DownloadUrl(key, url, null, fetchAlways, absoluteExpiration).SelectMany(ThrowOnBadImageBuffer).SelectMany((byte[] x) => BytesToImage(x, desiredWidth, desiredHeight));
	}

	public static IObservable<byte[]> ThrowOnBadImageBuffer(byte[] compressedImage)
	{
		if (compressedImage != null && compressedImage.Length >= 64)
		{
			return Observable.Return(compressedImage);
		}
		return Observable.Throw<byte[]>(new Exception("Invalid Image"));
	}

	private static IObservable<IBitmap> BytesToImage(byte[] compressedImage, float? desiredWidth, float? desiredHeight)
	{
		using MemoryStream sourceStream = new MemoryStream(compressedImage);
		return BitmapLoader.Current.Load(sourceStream, desiredWidth, desiredHeight).ToObservable();
	}
}
[Akavache.Core.Preserve(AllMembers = true)]
public class Registrations : IWantsToRegisterStuff
{
	public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
	{
		if (resolver == null)
		{
			throw new ArgumentNullException("resolver");
		}
		Locator.CurrentMutable.RegisterPlatformBitmapLoader();
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
