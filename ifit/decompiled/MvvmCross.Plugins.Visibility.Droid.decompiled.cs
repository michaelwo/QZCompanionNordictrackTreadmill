using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.Visibility.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.Visibility.Droid")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "Xamarin.Android v5.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins.Visibility.Droid;

[Preserve(AllMembers = true)]
public class MvxDroidVisibility : IMvxNativeVisibility
{
	public object ToNative(MvxVisibility visibility)
	{
		return (visibility != MvxVisibility.Visible) ? ViewStates.Gone : ViewStates.Visible;
	}
}
[Preserve(AllMembers = true)]
public class Plugin : IMvxPlugin
{
	public void Load()
	{
		Mvx.RegisterSingleton((IMvxNativeVisibility)new MvxDroidVisibility());
	}
}
