using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Windows.Input;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Source;
using MvvmCross.Binding.Bindings.Source.Construction;
using MvvmCross.Binding.Parse.PropertyPath.PropertyTokens;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Cirrious.Plugins.MethodBinding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("Cirrious.Plugins.MethodBinding")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile7", FrameworkDisplayName = ".NET Portable Subset")]
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
namespace MvvmCross.Plugins.MethodBinding
{
	[Preserve(AllMembers = true)]
	public class MvxMethodSourceBindingFactoryExtension : IMvxSourceBindingFactoryExtension
	{
		public bool TryCreateBinding(object source, MvxPropertyToken currentToken, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result)
		{
			if (source == null)
			{
				result = null;
				return false;
			}
			if (remainingTokens.Count > 0)
			{
				result = null;
				return false;
			}
			if (!(currentToken is MvxPropertyNamePropertyToken mvxPropertyNamePropertyToken))
			{
				result = null;
				return false;
			}
			MethodInfo methodInfo = FindMethodInfo(source, mvxPropertyNamePropertyToken.PropertyName);
			if ((object)methodInfo == null)
			{
				result = null;
				return false;
			}
			if (methodInfo.GetParameters().Count((ParameterInfo p) => !p.IsOptional) > 1)
			{
				MvxBindingTrace.Warning("Problem binding to Method {0} - too many non-optional parameters");
			}
			result = new MvxMethodSourceBinding(source, methodInfo);
			return true;
		}

		protected MethodInfo FindMethodInfo(object source, string name)
		{
			return ReflectionExtensions.GetMethod(source.GetType(), name);
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxMethodSourceBinding : MvxSourceBinding, ICommand
	{
		private readonly MethodInfo _methodInfo;

		public override Type SourceType => typeof(ICommand);

		public event EventHandler CanExecuteChanged;

		public MvxMethodSourceBinding(object source, MethodInfo methodInfo)
			: base(source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if ((object)methodInfo == null)
			{
				throw new ArgumentNullException("methodInfo");
			}
			_methodInfo = methodInfo;
		}

		public override void SetValue(object value)
		{
		}

		public override object GetValue()
		{
			return this;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			object[] parameters = ((!_methodInfo.GetParameters().Any()) ? new object[0] : new object[1] { parameter });
			_methodInfo.Invoke(base.Source, parameters);
		}
	}
	[Preserve(AllMembers = true)]
	public class PluginLoader : IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		private bool _loaded;

		public void EnsureLoaded()
		{
			if (!_loaded)
			{
				Mvx.CallbackWhenRegistered<IMvxSourceBindingFactoryExtensionHost>(OnHostRegistered);
				_loaded = true;
			}
		}

		private void OnHostRegistered(IMvxSourceBindingFactoryExtensionHost host)
		{
			host.Extensions.Add(new MvxMethodSourceBindingFactoryExtension());
		}
	}
}
