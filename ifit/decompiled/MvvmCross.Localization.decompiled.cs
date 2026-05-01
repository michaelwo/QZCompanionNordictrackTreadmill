using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Exceptions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Localization")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Localization;

public interface IMvxLocalizedTextSourceOwner
{
	IMvxLanguageBinder LocalizedTextSource { get; }
}
public class MvxLanguageConverter : MvxValueConverter
{
	public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is IMvxLanguageBinder mvxLanguageBinder))
		{
			return null;
		}
		if (parameter == null)
		{
			return null;
		}
		return mvxLanguageBinder.GetText(parameter.ToString());
	}
}
public interface IMvxLanguageBinder
{
	string GetText(string entryKey);

	string GetText(string entryKey, params object[] args);
}
public interface IMvxTextProvider
{
	string GetText(string namespaceKey, string typeKey, string name);

	string GetText(string namespaceKey, string typeKey, string name, params object[] formatArgs);
}
public class MvxLanguageBinder : IMvxLanguageBinder
{
	private readonly string _namespaceName;

	private readonly string _typeName;

	private IMvxTextProvider _cachedTextProvider;

	protected virtual IMvxTextProvider TextProvider
	{
		get
		{
			if (_cachedTextProvider != null)
			{
				return _cachedTextProvider;
			}
			lock (this)
			{
				Mvx.TryResolve<IMvxTextProvider>(out _cachedTextProvider);
				if (_cachedTextProvider == null)
				{
					throw new MvxException("Missing text provider - please initialize IoC with a suitable IMvxTextProvider");
				}
				return _cachedTextProvider;
			}
		}
	}

	public MvxLanguageBinder(Type owningObject)
		: this(owningObject.Namespace, owningObject.Name)
	{
	}

	public MvxLanguageBinder(string namespaceName = null, string typeName = null)
	{
		_namespaceName = namespaceName;
		_typeName = typeName;
	}

	public virtual string GetText(string entryKey)
	{
		return GetText(_namespaceName, _typeName, entryKey);
	}

	public virtual string GetText(string entryKey, params object[] args)
	{
		return string.Format(GetText(entryKey), args);
	}

	protected virtual string GetText(string namespaceKey, string typeKey, string entryKey)
	{
		return TextProvider.GetText(namespaceKey, typeKey, entryKey);
	}
}
