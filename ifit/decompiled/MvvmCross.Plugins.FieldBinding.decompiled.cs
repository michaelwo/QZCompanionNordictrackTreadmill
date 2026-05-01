using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Source;
using MvvmCross.Binding.Bindings.Source.Construction;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.Parse.PropertyPath.PropertyTokens;
using MvvmCross.FieldBinding;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Plugins.FieldBinding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.Plugins.FieldBinding")]
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
namespace MvvmCross.Plugins.FieldBinding
{
	[Preserve(AllMembers = true)]
	public class MvxChainedFieldSourceBinding : MvxFieldSourceBinding
	{
		private readonly IList<MvxPropertyToken> _childTokens;

		private IMvxSourceBinding _currentChildBinding;

		private IMvxSourceBindingFactory SourceBindingFactory => MvxSingleton<IMvxBindingSingletonCache>.Instance.SourceBindingFactory;

		public override Type SourceType
		{
			get
			{
				if (_currentChildBinding == null)
				{
					return typeof(object);
				}
				return _currentChildBinding.SourceType;
			}
		}

		public MvxChainedFieldSourceBinding(object source, FieldInfo fieldInfo, IList<MvxPropertyToken> childTokens)
			: base(source, fieldInfo)
		{
			_childTokens = childTokens;
			UpdateChildBinding();
		}

		private void UpdateChildBinding()
		{
			if (_currentChildBinding != null)
			{
				_currentChildBinding.Changed -= ChildSourceBindingChanged;
				_currentChildBinding.Dispose();
				_currentChildBinding = null;
			}
			object value = base.FieldInfo.GetValue(base.Source);
			if (value != null)
			{
				_currentChildBinding = SourceBindingFactory.CreateBinding(value, _childTokens);
				_currentChildBinding.Changed += ChildSourceBindingChanged;
			}
		}

		private void ChildSourceBindingChanged(object sender, EventArgs e)
		{
			FireChanged();
		}

		public override void SetValue(object value)
		{
			_currentChildBinding?.SetValue(value);
		}

		public override object GetValue()
		{
			if (_currentChildBinding == null)
			{
				return MvxBindingConstant.UnsetValue;
			}
			return _currentChildBinding.GetValue();
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxChainedNotifyChangeFieldSourceBinding : MvxNotifyChangeFieldSourceBinding
	{
		public static bool DisableWarnIndexedValueBindingWarning;

		private readonly List<MvxPropertyToken> _childTokens;

		private IMvxSourceBinding _currentChildBinding;

		private IMvxSourceBindingFactory SourceBindingFactory => MvxSingleton<IMvxBindingSingletonCache>.Instance.SourceBindingFactory;

		public override Type SourceType
		{
			get
			{
				if (_currentChildBinding == null)
				{
					return typeof(object);
				}
				return _currentChildBinding.SourceType;
			}
		}

		public MvxChainedNotifyChangeFieldSourceBinding(object source, INotifyChange notifyChange, List<MvxPropertyToken> childTokens)
			: base(source, notifyChange)
		{
			_childTokens = childTokens;
			if (!DisableWarnIndexedValueBindingWarning)
			{
				WarnIfChildTokensSuspiciousOfIndexedValueBinding();
			}
			UpdateChildBinding();
		}

		private void WarnIfChildTokensSuspiciousOfIndexedValueBinding()
		{
			if (_childTokens != null && _childTokens.Count >= 2 && _childTokens[0] is MvxPropertyNamePropertyToken mvxPropertyNamePropertyToken && !(mvxPropertyNamePropertyToken.PropertyName != "Value") && _childTokens[1] is MvxIndexerPropertyToken)
			{
				MvxBindingTrace.Warning("Suspicious indexed binding seen to Value[] within INC binding - this may be OK, but is often a result of FluentBinding used on INC<T> - consider using INCList<TValue> or INCDictionary<TKey,TValue> instead - see https://github.com/slodge/MvvmCross/issues/353. This message can be disabled using DisableWarnIndexedValueBindingWarning");
			}
		}

		protected override void NotifyChangeOnChanged(object sender, EventArgs eventArgs)
		{
			UpdateChildBinding();
			FireChanged();
		}

		protected void UpdateChildBinding()
		{
			if (_currentChildBinding != null)
			{
				_currentChildBinding.Changed -= ChildSourceBindingChanged;
				_currentChildBinding.Dispose();
				_currentChildBinding = null;
			}
			if (base.NotifyChange != null)
			{
				object value = base.NotifyChange.Value;
				if (value != null)
				{
					_currentChildBinding = SourceBindingFactory.CreateBinding(value, _childTokens);
					_currentChildBinding.Changed += ChildSourceBindingChanged;
				}
			}
		}

		private void ChildSourceBindingChanged(object sender, EventArgs e)
		{
			FireChanged();
		}

		public override object GetValue()
		{
			if (_currentChildBinding == null)
			{
				return MvxBindingConstant.UnsetValue;
			}
			return _currentChildBinding.GetValue();
		}

		public override void SetValue(object value)
		{
			if (_currentChildBinding == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "SetValue ignored in binding - target property path missing");
			}
			else
			{
				_currentChildBinding.SetValue(value);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing && _currentChildBinding != null)
			{
				_currentChildBinding.Dispose();
				_currentChildBinding = null;
			}
			base.Dispose(isDisposing);
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxLeafFieldSourceBinding : MvxFieldSourceBinding
	{
		public override Type SourceType => base.FieldInfo.FieldType;

		public MvxLeafFieldSourceBinding(object source, FieldInfo fieldInfo)
			: base(source, fieldInfo)
		{
		}

		public override void SetValue(object value)
		{
			object obj = base.FieldInfo.FieldType.MakeSafeValue(value);
			if (!EqualsCurrentValue(obj))
			{
				base.FieldInfo.SetValue(base.Source, obj);
			}
		}

		public override object GetValue()
		{
			return base.FieldInfo.GetValue(base.Source);
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxLeafNotifyChangeFieldSourceBinding : MvxNotifyChangeFieldSourceBinding
	{
		public override Type SourceType => base.NotifyChange.ValueType;

		public MvxLeafNotifyChangeFieldSourceBinding(object source, INotifyChange notifyChange)
			: base(source, notifyChange)
		{
		}

		protected override void NotifyChangeOnChanged(object sender, EventArgs eventArgs)
		{
			FireChanged();
		}

		public override void SetValue(object value)
		{
			object obj = base.NotifyChange.ValueType.MakeSafeValue(value);
			if (!EqualsCurrentValue(obj))
			{
				base.NotifyChange.Value = obj;
			}
		}

		public override object GetValue()
		{
			return base.NotifyChange.Value;
		}
	}
	public abstract class MvxNotifyChangeFieldSourceBinding : MvxSourceBinding
	{
		private static readonly EventInfo NotifyChangeEventInfo = ReflectionExtensions.GetEvent(typeof(INotifyChange), "Changed");

		private readonly INotifyChange _notifyChange;

		private IDisposable _subscription;

		protected INotifyChange NotifyChange => _notifyChange;

		protected MvxNotifyChangeFieldSourceBinding(object source, INotifyChange notifyChange)
			: base(source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (notifyChange == null)
			{
				throw new ArgumentNullException("notifyChange");
			}
			_notifyChange = notifyChange;
			_subscription = NotifyChangeEventInfo.WeakSubscribe(_notifyChange, NotifyChangeOnChanged);
		}

		protected abstract void NotifyChangeOnChanged(object sender, EventArgs eventArgs);

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription.Dispose();
			}
			base.Dispose(isDisposing);
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
			host.Extensions.Add(new MvxFieldSourceBindingFactoryExtension());
		}
	}
	[Preserve(AllMembers = true)]
	public class MvxFieldSourceBindingFactoryExtension : IMvxSourceBindingFactoryExtension
	{
		public bool TryCreateBinding(object source, MvxPropertyToken currentToken, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result)
		{
			if (source == null)
			{
				result = null;
				return false;
			}
			if (!(currentToken is MvxPropertyNamePropertyToken mvxPropertyNamePropertyToken))
			{
				result = null;
				return false;
			}
			FieldInfo fieldInfo = FindFieldInfo(source, mvxPropertyNamePropertyToken.PropertyName);
			if ((object)fieldInfo == null)
			{
				result = null;
				return false;
			}
			if (ReflectionExtensions.IsAssignableFrom(typeof(INotifyChange), fieldInfo.FieldType))
			{
				return TryCreateNotifyChangeBinding(source, remainingTokens, out result, fieldInfo, mvxPropertyNamePropertyToken);
			}
			return TryCreateFieldInfoBinding(source, remainingTokens, out result, fieldInfo);
		}

		protected bool TryCreateFieldInfoBinding(object source, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result, FieldInfo fieldInfo)
		{
			if (remainingTokens.Any())
			{
				result = new MvxChainedFieldSourceBinding(source, fieldInfo, remainingTokens);
			}
			else
			{
				result = new MvxLeafFieldSourceBinding(source, fieldInfo);
			}
			return true;
		}

		protected bool TryCreateNotifyChangeBinding(object source, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result, FieldInfo fieldInfo, MvxPropertyNamePropertyToken propertyNameToken)
		{
			if (!(fieldInfo.GetValue(source) is INotifyChange notifyChange))
			{
				MvxBindingTrace.Warning("INotifyChange is null for {0}", propertyNameToken.PropertyName);
				result = null;
				return false;
			}
			if (remainingTokens.Any())
			{
				result = new MvxChainedNotifyChangeFieldSourceBinding(source, notifyChange, remainingTokens);
			}
			else
			{
				result = new MvxLeafNotifyChangeFieldSourceBinding(source, notifyChange);
			}
			return true;
		}

		protected FieldInfo FindFieldInfo(object source, string name)
		{
			return source.GetType().GetField(name, MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy);
		}
	}
	public abstract class MvxFieldSourceBinding : MvxSourceBinding
	{
		private readonly FieldInfo _fieldInfo;

		protected FieldInfo FieldInfo => _fieldInfo;

		protected MvxFieldSourceBinding(object source, FieldInfo fieldInfo)
			: base(source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if ((object)fieldInfo == null)
			{
				throw new ArgumentNullException("fieldInfo");
			}
			_fieldInfo = fieldInfo;
		}
	}
}
