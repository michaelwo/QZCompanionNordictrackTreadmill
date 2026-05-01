using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.Visibility")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.Visibility")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Plugins
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	public sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
}
namespace MvvmCross.Plugins.Visibility
{
	[Preserve(AllMembers = true)]
	public class PluginLoader : IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		public void EnsureLoaded()
		{
			Mvx.Resolve<IMvxPluginManager>().EnsurePlatformAdaptionLoaded<PluginLoader>();
			Mvx.CallbackWhenRegistered<IMvxValueConverterRegistry>(RegisterValueConverters);
		}

		private void RegisterValueConverters()
		{
			Mvx.Resolve<IMvxValueConverterRegistry>().AddOrOverwriteFrom(GetType().GetTypeInfo().Assembly);
		}
	}
	public abstract class MvxBaseVisibilityValueConverter<T> : MvxBaseVisibilityValueConverter
	{
		protected sealed override MvxVisibility Convert(object value, object parameter, CultureInfo culture)
		{
			return Convert((T)value, parameter, culture);
		}

		protected abstract MvxVisibility Convert(T value, object parameter, CultureInfo culture);
	}
	public abstract class MvxBaseVisibilityValueConverter : MvxValueConverter
	{
		private IMvxNativeVisibility _nativeVisiblity;

		private IMvxNativeVisibility NativeVisibility => _nativeVisiblity ?? (_nativeVisiblity = Mvx.Resolve<IMvxNativeVisibility>());

		protected abstract MvxVisibility Convert(object value, object parameter, CultureInfo culture);

		public sealed override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			MvxVisibility visibility = Convert(value, parameter, culture);
			return NativeVisibility.ToNative(visibility);
		}

		public sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return base.ConvertBack(value, targetType, parameter, culture);
		}

		protected virtual bool IsATrueValue(object value, object parameter, bool defaultValue)
		{
			if (value == null)
			{
				return false;
			}
			if (value is bool)
			{
				return (bool)value;
			}
			if (value is int)
			{
				if (parameter == null)
				{
					return (int)value > 0;
				}
				return (int)value > int.Parse(parameter.ToString());
			}
			if (value is double)
			{
				return (double)value > 0.0;
			}
			if (value is string)
			{
				return !string.IsNullOrWhiteSpace(value as string);
			}
			return defaultValue;
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxInvertedVisibilityValueConverter : MvxVisibilityValueConverter
	{
		protected override MvxVisibility Convert(object value, object parameter, CultureInfo culture)
		{
			if (IsATrueValue(value, parameter, defaultValue: true))
			{
				return MvxVisibility.Collapsed;
			}
			return MvxVisibility.Visible;
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxVisibilityValueConverter : MvxBaseVisibilityValueConverter
	{
		protected override MvxVisibility Convert(object value, object parameter, CultureInfo culture)
		{
			if (!IsATrueValue(value, parameter, defaultValue: true))
			{
				return MvxVisibility.Collapsed;
			}
			return MvxVisibility.Visible;
		}
	}
}
