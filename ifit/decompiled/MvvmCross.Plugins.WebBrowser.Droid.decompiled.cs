using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Net;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Plugins;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.WebBrowser.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.WebBrowser.Droid")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "Xamarin.Android v5.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins.WebBrowser.Droid;

[Preserve(AllMembers = true)]
public class MvxWebBrowserTask : MvxAndroidTask, IMvxWebBrowserTask
{
	public void ShowWebPage(string url)
	{
		Intent intent = new Intent("android.intent.action.VIEW", Uri.Parse(url));
		StartActivity(intent);
	}
}
[Preserve(AllMembers = true)]
public class Plugin : IMvxPlugin
{
	public void Load()
	{
		Mvx.RegisterType<IMvxWebBrowserTask, MvxWebBrowserTask>();
	}
}
