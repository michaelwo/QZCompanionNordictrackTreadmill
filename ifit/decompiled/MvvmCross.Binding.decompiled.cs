using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;
using MvvmCross.Binding.Bindings.Source;
using MvvmCross.Binding.Bindings.Source.Chained;
using MvvmCross.Binding.Bindings.Source.Construction;
using MvvmCross.Binding.Bindings.Source.Leaf;
using MvvmCross.Binding.Bindings.SourceSteps;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Combiners;
using MvvmCross.Binding.ExpressionParse;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.Parse.Binding;
using MvvmCross.Binding.Parse.Binding.Lang;
using MvvmCross.Binding.Parse.Binding.Swiss;
using MvvmCross.Binding.Parse.Binding.Tibet;
using MvvmCross.Binding.Parse.PropertyPath;
using MvvmCross.Binding.Parse.PropertyPath.PropertyTokens;
using MvvmCross.Binding.ValueConverters;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.ExtensionMethods;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Parse;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Binding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile111", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Binding
{
	public interface IMvxBindingSingletonCache
	{
		IMvxAutoValueConverters AutoValueConverters { get; }

		IMvxBindingDescriptionParser BindingDescriptionParser { get; }

		IMvxLanguageBindingParser LanguageParser { get; }

		IMvxPropertyExpressionParser PropertyExpressionParser { get; }

		IMvxValueConverterLookup ValueConverterLookup { get; }

		IMvxBindingNameLookup DefaultBindingNameLookup { get; }

		IMvxBinder Binder { get; }

		IMvxSourceBindingFactory SourceBindingFactory { get; }

		IMvxTargetBindingFactory TargetBindingFactory { get; }

		IMvxSourceStepFactory SourceStepFactory { get; }

		IMvxValueCombinerLookup ValueCombinerLookup { get; }

		IMvxMainThreadDispatcher MainThreadDispatcher { get; }
	}
	public class MvxCoreBindingBuilder
	{
		public virtual void DoRegistration()
		{
			CreateSingleton();
			RegisterCore();
			RegisterValueConverterRegistryFiller();
			RegisterValueConverterProvider();
			RegisterValueCombinerRegistryFiller();
			RegisterValueCombinerProvider();
			RegisterAutoValueConverters();
			RegisterBindingParser();
			RegisterLanguageBindingParser();
			RegisterBindingDescriptionParser();
			RegisterExpressionParser();
			RegisterSourcePropertyPathParser();
			RegisterPlatformSpecificComponents();
			RegisterBindingNameRegistry();
		}

		protected virtual void RegisterAutoValueConverters()
		{
			IMvxAutoValueConverters mvxAutoValueConverters = CreateAutoValueConverters();
			Mvx.RegisterSingleton(mvxAutoValueConverters);
			FillAutoValueConverters(mvxAutoValueConverters);
		}

		protected virtual void FillAutoValueConverters(IMvxAutoValueConverters autoValueConverters)
		{
		}

		protected virtual IMvxAutoValueConverters CreateAutoValueConverters()
		{
			return new MvxAutoValueConverters();
		}

		protected virtual void CreateSingleton()
		{
			MvxBindingSingletonCache.Initialize();
		}

		protected virtual void RegisterValueConverterRegistryFiller()
		{
			IMvxValueConverterRegistryFiller service = CreateValueConverterRegistryFiller();
			Mvx.RegisterSingleton((IMvxNamedInstanceRegistryFiller<IMvxValueConverter>)service);
			Mvx.RegisterSingleton(service);
		}

		protected virtual IMvxValueConverterRegistryFiller CreateValueConverterRegistryFiller()
		{
			return new MvxValueConverterRegistryFiller();
		}

		protected virtual void RegisterValueCombinerRegistryFiller()
		{
			IMvxValueCombinerRegistryFiller service = CreateValueCombinerRegistryFiller();
			Mvx.RegisterSingleton((IMvxNamedInstanceRegistryFiller<IMvxValueCombiner>)service);
			Mvx.RegisterSingleton(service);
		}

		protected virtual IMvxValueCombinerRegistryFiller CreateValueCombinerRegistryFiller()
		{
			return new MvxValueCombinerRegistryFiller();
		}

		protected virtual void RegisterExpressionParser()
		{
			Mvx.RegisterSingleton((IMvxPropertyExpressionParser)new MvxPropertyExpressionParser());
		}

		protected virtual void RegisterCore()
		{
			Mvx.RegisterSingleton((IMvxBinder)new MvxFromTextBinder());
			Mvx.RegisterType<IMvxBindingContext, MvxTaskBasedBindingContext>();
		}

		protected virtual void RegisterValueConverterProvider()
		{
			MvxValueConverterRegistry mvxValueConverterRegistry = CreateValueConverterRegistry();
			Mvx.RegisterSingleton((IMvxNamedInstanceLookup<IMvxValueConverter>)mvxValueConverterRegistry);
			Mvx.RegisterSingleton((IMvxNamedInstanceRegistry<IMvxValueConverter>)mvxValueConverterRegistry);
			Mvx.RegisterSingleton((IMvxValueConverterLookup)mvxValueConverterRegistry);
			Mvx.RegisterSingleton((IMvxValueConverterRegistry)mvxValueConverterRegistry);
			FillValueConverters(mvxValueConverterRegistry);
		}

		protected virtual MvxValueConverterRegistry CreateValueConverterRegistry()
		{
			return new MvxValueConverterRegistry();
		}

		protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			registry.AddOrOverwrite("CommandParameter", new MvxCommandParameterValueConverter());
			registry.AddOrOverwrite("Language", new MvxLanguageConverter());
		}

		protected virtual void RegisterValueCombinerProvider()
		{
			IMvxValueCombinerRegistry mvxValueCombinerRegistry = CreateValueCombinerRegistry();
			Mvx.RegisterSingleton((IMvxNamedInstanceLookup<IMvxValueCombiner>)mvxValueCombinerRegistry);
			Mvx.RegisterSingleton((IMvxNamedInstanceRegistry<IMvxValueCombiner>)mvxValueCombinerRegistry);
			Mvx.RegisterSingleton((IMvxValueCombinerLookup)mvxValueCombinerRegistry);
			Mvx.RegisterSingleton(mvxValueCombinerRegistry);
			FillValueCombiners(mvxValueCombinerRegistry);
		}

		protected virtual IMvxValueCombinerRegistry CreateValueCombinerRegistry()
		{
			return new MvxValueCombinerRegistry();
		}

		protected virtual void FillValueCombiners(IMvxValueCombinerRegistry registry)
		{
			registry.AddOrOverwrite("Add", new MvxAddValueCombiner());
			registry.AddOrOverwrite("Divide", new MvxDivideValueCombiner());
			registry.AddOrOverwrite("Format", new MvxFormatValueCombiner());
			registry.AddOrOverwrite("If", new MvxIfValueCombiner());
			registry.AddOrOverwrite("Modulus", new MvxModulusValueCombiner());
			registry.AddOrOverwrite("Multiply", new MvxMultiplyValueCombiner());
			registry.AddOrOverwrite("Single", new MvxSingleValueCombiner());
			registry.AddOrOverwrite("Subtract", new MvxSubtractValueCombiner());
			registry.AddOrOverwrite("EqualTo", new MvxEqualToValueCombiner());
			registry.AddOrOverwrite("NotEqualTo", new MvxNotEqualToValueCombiner());
			registry.AddOrOverwrite("GreaterThanOrEqualTo", new MvxGreaterThanOrEqualToValueCombiner());
			registry.AddOrOverwrite("GreaterThan", new MvxGreaterThanValueCombiner());
			registry.AddOrOverwrite("LessThanOrEqualTo", new MvxLessThanOrEqualToValueCombiner());
			registry.AddOrOverwrite("LessThan", new MvxLessThanValueCombiner());
			registry.AddOrOverwrite("Not", new MvxNotValueCombiner());
			registry.AddOrOverwrite("And", new MvxAndValueCombiner());
			registry.AddOrOverwrite("Or", new MvxOrValueCombiner());
			registry.AddOrOverwrite("XOr", new MvxXorValueCombiner());
		}

		protected virtual void RegisterBindingParser()
		{
			if (Mvx.CanResolve<IMvxBindingParser>())
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Binding Parser already registered - so skipping Default parser");
				return;
			}
			MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Registering Default Binding Parser");
			Mvx.RegisterSingleton(CreateBindingParser());
		}

		protected virtual IMvxBindingParser CreateBindingParser()
		{
			return new MvxTibetBindingParser();
		}

		protected virtual void RegisterLanguageBindingParser()
		{
			if (Mvx.CanResolve<IMvxLanguageBindingParser>())
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Binding Parser already registered - so skipping Language parser");
				return;
			}
			MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Registering Language Binding Parser");
			Mvx.RegisterSingleton(CreateLanguageBindingParser());
		}

		protected virtual IMvxLanguageBindingParser CreateLanguageBindingParser()
		{
			return new MvxLanguageBindingParser();
		}

		protected virtual void RegisterBindingDescriptionParser()
		{
			Mvx.RegisterSingleton(CreateBindingDescriptionParser());
		}

		private static IMvxBindingDescriptionParser CreateBindingDescriptionParser()
		{
			return new MvxBindingDescriptionParser();
		}

		protected virtual void RegisterSourcePropertyPathParser()
		{
			Mvx.RegisterSingleton(CreateSourcePropertyPathParser());
		}

		protected virtual IMvxSourcePropertyPathParser CreateSourcePropertyPathParser()
		{
			return new MvxSourcePropertyPathParser();
		}

		protected virtual void RegisterBindingNameRegistry()
		{
			MvxBindingNameRegistry mvxBindingNameRegistry = new MvxBindingNameRegistry();
			Mvx.RegisterSingleton((IMvxBindingNameLookup)mvxBindingNameRegistry);
			Mvx.RegisterSingleton((IMvxBindingNameRegistry)mvxBindingNameRegistry);
			FillDefaultBindingNames(mvxBindingNameRegistry);
		}

		protected virtual void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
		{
		}

		protected virtual void RegisterPlatformSpecificComponents()
		{
		}
	}
	public class MvxBindingSingletonCache : MvxSingleton<IMvxBindingSingletonCache>, IMvxBindingSingletonCache
	{
		private IMvxAutoValueConverters _autoValueConverters;

		private IMvxBindingDescriptionParser _bindingDescriptionParser;

		private IMvxSourceBindingFactory _sourceBindingFactory;

		private IMvxTargetBindingFactory _targetBindingFactory;

		private IMvxLanguageBindingParser _languageParser;

		private IMvxPropertyExpressionParser _propertyExpressionParser;

		private IMvxValueConverterLookup _valueConverterLookup;

		private IMvxBindingNameLookup _defaultBindingName;

		private IMvxBinder _binder;

		private IMvxSourceStepFactory _sourceStepFactory;

		private IMvxValueCombinerLookup _valueCombinerLookup;

		private IMvxMainThreadDispatcher _mainThreadDispatcher;

		public IMvxAutoValueConverters AutoValueConverters
		{
			get
			{
				_autoValueConverters = _autoValueConverters ?? Mvx.Resolve<IMvxAutoValueConverters>();
				return _autoValueConverters;
			}
		}

		public IMvxBindingDescriptionParser BindingDescriptionParser
		{
			get
			{
				_bindingDescriptionParser = _bindingDescriptionParser ?? Mvx.Resolve<IMvxBindingDescriptionParser>();
				return _bindingDescriptionParser;
			}
		}

		public IMvxLanguageBindingParser LanguageParser
		{
			get
			{
				_languageParser = _languageParser ?? Mvx.Resolve<IMvxLanguageBindingParser>();
				return _languageParser;
			}
		}

		public IMvxPropertyExpressionParser PropertyExpressionParser
		{
			get
			{
				_propertyExpressionParser = _propertyExpressionParser ?? Mvx.Resolve<IMvxPropertyExpressionParser>();
				return _propertyExpressionParser;
			}
		}

		public IMvxValueConverterLookup ValueConverterLookup
		{
			get
			{
				_valueConverterLookup = _valueConverterLookup ?? Mvx.Resolve<IMvxValueConverterLookup>();
				return _valueConverterLookup;
			}
		}

		public IMvxValueCombinerLookup ValueCombinerLookup
		{
			get
			{
				_valueCombinerLookup = _valueCombinerLookup ?? Mvx.Resolve<IMvxValueCombinerLookup>();
				return _valueCombinerLookup;
			}
		}

		public IMvxBindingNameLookup DefaultBindingNameLookup
		{
			get
			{
				_defaultBindingName = _defaultBindingName ?? Mvx.Resolve<IMvxBindingNameLookup>();
				return _defaultBindingName;
			}
		}

		public IMvxBinder Binder
		{
			get
			{
				_binder = _binder ?? Mvx.Resolve<IMvxBinder>();
				return _binder;
			}
		}

		public IMvxSourceBindingFactory SourceBindingFactory
		{
			get
			{
				_sourceBindingFactory = _sourceBindingFactory ?? Mvx.Resolve<IMvxSourceBindingFactory>();
				return _sourceBindingFactory;
			}
		}

		public IMvxTargetBindingFactory TargetBindingFactory
		{
			get
			{
				_targetBindingFactory = _targetBindingFactory ?? Mvx.Resolve<IMvxTargetBindingFactory>();
				return _targetBindingFactory;
			}
		}

		public IMvxSourceStepFactory SourceStepFactory
		{
			get
			{
				_sourceStepFactory = _sourceStepFactory ?? Mvx.Resolve<IMvxSourceStepFactory>();
				return _sourceStepFactory;
			}
		}

		public IMvxMainThreadDispatcher MainThreadDispatcher
		{
			get
			{
				_mainThreadDispatcher = _mainThreadDispatcher ?? Mvx.Resolve<IMvxMainThreadDispatcher>();
				return _mainThreadDispatcher;
			}
		}

		public static IMvxBindingSingletonCache Initialize()
		{
			if (MvxSingleton<IMvxBindingSingletonCache>.Instance != null)
			{
				throw new MvxException("You should only initialize MvxBindingSingletonCache once");
			}
			return new MvxBindingSingletonCache();
		}
	}
	public enum MvxBindingMode
	{
		Default,
		TwoWay,
		OneWay,
		OneTime,
		OneWayToSource
	}
	public class MvxBindingRequest
	{
		public object Target { get; set; }

		public object Source { get; set; }

		public MvxBindingDescription Description { get; set; }

		public MvxBindingRequest()
		{
		}

		public MvxBindingRequest(object source, object target, MvxBindingDescription description)
		{
			Target = target;
			Source = source;
			Description = description;
		}
	}
	public class MvxBindingBuilder : MvxCoreBindingBuilder
	{
		public override void DoRegistration()
		{
			base.DoRegistration();
			RegisterBindingFactories();
		}

		protected virtual void RegisterBindingFactories()
		{
			RegisterMvxBindingFactories();
		}

		protected virtual void RegisterMvxBindingFactories()
		{
			RegisterSourceStepFactory();
			RegisterSourceFactory();
			RegisterTargetFactory();
		}

		protected virtual void RegisterSourceStepFactory()
		{
			IMvxSourceStepFactoryRegistry mvxSourceStepFactoryRegistry = CreateSourceStepFactoryRegistry();
			FillSourceStepFactory(mvxSourceStepFactoryRegistry);
			Mvx.RegisterSingleton(mvxSourceStepFactoryRegistry);
			Mvx.RegisterSingleton((IMvxSourceStepFactory)mvxSourceStepFactoryRegistry);
		}

		protected virtual void FillSourceStepFactory(IMvxSourceStepFactoryRegistry registry)
		{
			registry.AddOrOverwrite(typeof(MvxCombinerSourceStepDescription), new MvxCombinerSourceStepFactory());
			registry.AddOrOverwrite(typeof(MvxPathSourceStepDescription), new MvxPathSourceStepFactory());
			registry.AddOrOverwrite(typeof(MvxLiteralSourceStepDescription), new MvxLiteralSourceStepFactory());
		}

		protected virtual IMvxSourceStepFactoryRegistry CreateSourceStepFactoryRegistry()
		{
			return new MvxSourceStepFactory();
		}

		protected virtual void RegisterSourceFactory()
		{
			IMvxSourceBindingFactory mvxSourceBindingFactory = CreateSourceBindingFactory();
			Mvx.RegisterSingleton(mvxSourceBindingFactory);
			if (mvxSourceBindingFactory is IMvxSourceBindingFactoryExtensionHost mvxSourceBindingFactoryExtensionHost)
			{
				RegisterSourceBindingFactoryExtensions(mvxSourceBindingFactoryExtensionHost);
				Mvx.RegisterSingleton(mvxSourceBindingFactoryExtensionHost);
			}
			else
			{
				Mvx.Trace("source binding factory extension host not provided - so no source extensions will be used");
			}
		}

		protected virtual void RegisterSourceBindingFactoryExtensions(IMvxSourceBindingFactoryExtensionHost extensionHost)
		{
			extensionHost.Extensions.Add(new MvxPropertySourceBindingFactoryExtension());
		}

		protected virtual IMvxSourceBindingFactory CreateSourceBindingFactory()
		{
			return new MvxSourceBindingFactory();
		}

		protected virtual void RegisterTargetFactory()
		{
			IMvxTargetBindingFactoryRegistry mvxTargetBindingFactoryRegistry = CreateTargetBindingRegistry();
			Mvx.RegisterSingleton(mvxTargetBindingFactoryRegistry);
			Mvx.RegisterSingleton((IMvxTargetBindingFactory)mvxTargetBindingFactoryRegistry);
			FillTargetFactories(mvxTargetBindingFactoryRegistry);
		}

		protected virtual IMvxTargetBindingFactoryRegistry CreateTargetBindingRegistry()
		{
			return new MvxTargetBindingFactoryRegistry();
		}

		protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
		}
	}
	public static class MvxBindingTrace
	{
		public static MvxTraceLevel TraceBindingLevel = MvxTraceLevel.Warning;

		public const string Tag = "MvxBind";

		public static void Trace(MvxTraceLevel level, string message, params object[] args)
		{
			if (level >= TraceBindingLevel)
			{
				MvxTrace.TaggedTrace(level, "MvxBind", message, args);
			}
		}

		public static void Trace(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Diagnostic, message, args);
		}

		public static void Warning(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Warning, message, args);
		}

		public static void Error(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Error, message, args);
		}
	}
}
namespace MvvmCross.Binding.Views
{
	public abstract class MvxBaseImageViewLoader<TImage> : IDisposable where TImage : class
	{
		private readonly IMvxImageHelper<TImage> _imageHelper;

		private readonly Action<TImage> _imageSetAction;

		private IDisposable _subscription;

		public string ImageUrl
		{
			get
			{
				return _imageHelper.ImageUrl;
			}
			set
			{
				_imageHelper.ImageUrl = value;
			}
		}

		public string DefaultImagePath
		{
			get
			{
				return _imageHelper.DefaultImagePath;
			}
			set
			{
				_imageHelper.DefaultImagePath = value;
			}
		}

		public string ErrorImagePath
		{
			get
			{
				return _imageHelper.ErrorImagePath;
			}
			set
			{
				_imageHelper.ErrorImagePath = value;
			}
		}

		protected MvxBaseImageViewLoader(Action<TImage> imageSetAction)
		{
			_imageSetAction = imageSetAction;
			if (!Mvx.TryResolve<IMvxImageHelper<TImage>>(out _imageHelper))
			{
				MvxBindingTrace.Error("Unable to resolve the image helper - have you referenced and called EnsureLoaded on the DownloadCache plugin?");
				return;
			}
			EventInfo eventInfo = ReflectionExtensions.GetEvent(_imageHelper.GetType(), "ImageChanged");
			_subscription = eventInfo.WeakSubscribe<TImage>(_imageHelper, ImageHelperOnImageChanged);
		}

		~MvxBaseImageViewLoader()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public virtual void ImageHelperOnImageChanged(object sender, MvxValueEventArgs<TImage> mvxValueEventArgs)
		{
			_imageSetAction(mvxValueEventArgs.Value);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _subscription != null)
			{
				_subscription.Dispose();
				_subscription = null;
			}
		}
	}
}
namespace MvvmCross.Binding.ExpressionParse
{
	public interface IMvxPropertyExpressionParser
	{
		IMvxParsedExpression Parse<TObj, TRet>(Expression<Func<TObj, TRet>> propertyPath);

		IMvxParsedExpression Parse(LambdaExpression propertyPath);
	}
	public interface IMvxParsedExpression
	{
		string Print();
	}
	public class MvxParsedExpression : IMvxParsedExpression
	{
		public interface INode
		{
			void AppendPrintTo(StringBuilder builder);
		}

		public class PropertyNode : INode
		{
			public string PropertyName { get; }

			public PropertyNode(string propertyName)
			{
				PropertyName = propertyName;
			}

			public void AppendPrintTo(StringBuilder builder)
			{
				if (builder.Length > 0)
				{
					builder.Append(".");
				}
				builder.Append(PropertyName);
			}
		}

		public class IndexedNode : INode
		{
			public string IndexValue { get; }

			public IndexedNode(string indexValue)
			{
				IndexValue = indexValue;
			}

			public void AppendPrintTo(StringBuilder builder)
			{
				builder.AppendFormat("[{0}]", new object[1] { IndexValue });
			}
		}

		private readonly LinkedList<INode> _nodes = new LinkedList<INode>();

		protected LinkedList<INode> Nodes => _nodes;

		protected void Prepend(INode node)
		{
			_nodes.AddFirst(node);
		}

		public void PrependProperty(string propertyName)
		{
			Prepend(new PropertyNode(propertyName));
		}

		public void PrependIndexed(string indexedValue)
		{
			Prepend(new IndexedNode(indexedValue));
		}

		public string Print()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (INode node in Nodes)
			{
				node.AppendPrintTo(stringBuilder);
			}
			return stringBuilder.ToString();
		}
	}
	public class MvxPropertyExpressionParser : IMvxPropertyExpressionParser
	{
		public IMvxParsedExpression Parse<TObj, TRet>(Expression<Func<TObj, TRet>> propertyPath)
		{
			return Parse((LambdaExpression)propertyPath);
		}

		public IMvxParsedExpression Parse(LambdaExpression propertyPath)
		{
			MvxParsedExpression mvxParsedExpression = new MvxParsedExpression();
			Expression expression = propertyPath.Body;
			while (expression != null && expression.NodeType != ExpressionType.Parameter)
			{
				expression = ParseTo(expression, mvxParsedExpression);
			}
			return mvxParsedExpression;
		}

		private static Expression ParseTo(Expression current, MvxParsedExpression toReturn)
		{
			if (current.NodeType == ExpressionType.Convert || current.NodeType == ExpressionType.ConvertChecked)
			{
				return Unbox(current);
			}
			if (current.NodeType == ExpressionType.MemberAccess)
			{
				return ParseProperty(current, toReturn);
			}
			if (current is MethodCallExpression)
			{
				return ParseMethodCall(current, toReturn);
			}
			throw new ArgumentException("Property expression must be of the form 'x => x.SomeProperty.SomeOtherProperty'");
		}

		private static Expression ParseMethodCall(Expression current, MvxParsedExpression toReturn)
		{
			MethodCallExpression methodCallExpression = (MethodCallExpression)current;
			if (methodCallExpression.Method.Name != "get_Item" || methodCallExpression.Arguments.Count != 1)
			{
				throw new ArgumentException("Property expression must be of the form 'x => x.SomeProperty.SomeOtherProperty' or 'x => x.SomeCollection[0].Property'");
			}
			Expression argument = methodCallExpression.Arguments[0];
			argument = ConvertMemberAccessToConstant(argument);
			toReturn.PrependIndexed(argument.ToString());
			current = methodCallExpression.Object;
			return current;
		}

		private static Expression ConvertMemberAccessToConstant(Expression argument)
		{
			if (!(argument is MemberExpression memberExpression))
			{
				return argument;
			}
			try
			{
				object obj = (ConvertMemberAccessToConstant(memberExpression.Expression) as ConstantExpression)?.Value;
				if (memberExpression.Member is PropertyInfo propertyInfo)
				{
					return Expression.Constant(propertyInfo.GetValue(obj));
				}
				if (memberExpression.Member is FieldInfo fieldInfo)
				{
					return Expression.Constant(fieldInfo.GetValue(obj));
				}
			}
			catch
			{
				Mvx.Trace("Failed to evaluate member expression.");
			}
			return argument;
		}

		private static Expression ParseProperty(Expression current, MvxParsedExpression toReturn)
		{
			MemberExpression memberExpression = (MemberExpression)current;
			toReturn.PrependProperty(memberExpression.Member.Name);
			current = memberExpression.Expression;
			return current;
		}

		private static Expression Unbox(Expression current)
		{
			current = ((UnaryExpression)current).Operand;
			return current;
		}
	}
}
namespace MvvmCross.Binding.ValueConverters
{
	public class MvxCommandParameterValueConverter : MvxValueConverter<ICommand, ICommand>
	{
		protected override ICommand Convert(ICommand value, Type targetType, object parameter, CultureInfo culture)
		{
			return new MvxWrappingCommand(value, parameter);
		}
	}
	public class MvxWrappingCommand : ICommand
	{
		private static readonly EventInfo CanExecuteChangedEventInfo = ReflectionExtensions.GetEvent(typeof(ICommand), "CanExecuteChanged");

		private readonly ICommand _wrapped;

		private readonly object _commandParameterOverride;

		private readonly IDisposable _canChangedEventSubscription;

		public event EventHandler CanExecuteChanged;

		public MvxWrappingCommand(ICommand wrapped, object commandParameterOverride)
		{
			_wrapped = wrapped;
			_commandParameterOverride = commandParameterOverride;
			if (_wrapped != null)
			{
				_canChangedEventSubscription = CanExecuteChangedEventInfo.WeakSubscribe(_wrapped, WrappedOnCanExecuteChanged);
			}
		}

		public void WrappedOnCanExecuteChanged(object sender, EventArgs eventArgs)
		{
			this.CanExecuteChanged?.Invoke(this, eventArgs);
		}

		public bool CanExecute(object parameter = null)
		{
			if (_wrapped == null)
			{
				return false;
			}
			if (parameter != null)
			{
				Mvx.Warning("Non-null parameter will be ignored in MvxWrappingCommand.CanExecute");
			}
			return _wrapped.CanExecute(_commandParameterOverride);
		}

		public void Execute(object parameter = null)
		{
			if (_wrapped != null)
			{
				if (parameter != null)
				{
					Mvx.Warning("Non-null parameter overridden in MvxWrappingCommand");
				}
				_wrapped.Execute(_commandParameterOverride);
			}
		}
	}
}
namespace MvvmCross.Binding.Parse.PropertyPath
{
	public class MvxPropertyPathParser : MvxParser
	{
		protected List<MvxPropertyToken> CurrentTokens { get; } = new List<MvxPropertyToken>();

		protected override void Reset(string textToParse)
		{
			CurrentTokens.Clear();
			textToParse = MakeSafe(textToParse);
			base.Reset(textToParse);
		}

		public static string MakeSafe(string textToParse)
		{
			if (textToParse == null)
			{
				return string.Empty;
			}
			if (textToParse.Trim() == ".")
			{
				return string.Empty;
			}
			return textToParse;
		}

		public IList<MvxPropertyToken> Parse(string textToParse)
		{
			Reset(textToParse);
			while (!base.IsComplete)
			{
				ParseNextToken();
			}
			if (CurrentTokens.Count == 0)
			{
				CurrentTokens.Add(new MvxEmptyPropertyToken());
			}
			return CurrentTokens;
		}

		private void ParseNextToken()
		{
			SkipWhitespaceAndPeriods();
			if (base.IsComplete)
			{
				return;
			}
			char currentChar = base.CurrentChar;
			if (currentChar == '[')
			{
				ParseIndexer();
				return;
			}
			if (char.IsLetter(currentChar) || currentChar == '_')
			{
				ParsePropertyName();
				return;
			}
			throw new MvxException("Unexpected character {0} at position {1} in targetProperty text {2}", currentChar, base.CurrentIndex, base.FullText);
		}

		private void ParsePropertyName()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (!base.IsComplete)
			{
				char currentChar = base.CurrentChar;
				if (!char.IsLetterOrDigit(currentChar) && currentChar != '_')
				{
					break;
				}
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			string propertyText = stringBuilder.ToString();
			CurrentTokens.Add(new MvxPropertyNamePropertyToken(propertyText));
		}

		private void ParseIndexer()
		{
			if (base.CurrentChar != '[')
			{
				throw new MvxException("Internal error - ParseIndexer should only be called with a string starting with [");
			}
			MoveNext();
			if (base.IsComplete)
			{
				throw new MvxException("Invalid indexer targetProperty text {0}", base.FullText);
			}
			SkipWhitespaceAndPeriods();
			if (base.IsComplete)
			{
				throw new MvxException("Invalid indexer targetProperty text {0}", base.FullText);
			}
			if (base.CurrentChar == '\'' || base.CurrentChar == '"')
			{
				ParseQuotedStringIndexer();
			}
			else if (char.IsDigit(base.CurrentChar))
			{
				ParseIntegerIndexer();
			}
			else
			{
				ParseUnquotedStringIndexer();
			}
			SkipWhitespaceAndPeriods();
			if (base.IsComplete)
			{
				throw new MvxException("Invalid termination of indexer targetProperty text in {0}", base.FullText);
			}
			if (base.CurrentChar != ']')
			{
				throw new MvxException("Unexpected character {0} at position {1} in targetProperty text {2} - expected terminator", base.CurrentChar, base.CurrentIndex, base.FullText);
			}
			MoveNext();
		}

		private void ParseIntegerIndexer()
		{
			int key = (int)ReadUnsignedInteger();
			CurrentTokens.Add(new MvxIntegerIndexerPropertyToken(key));
		}

		private void ParseQuotedStringIndexer()
		{
			string key = ReadQuotedString();
			CurrentTokens.Add(new MvxStringIndexerPropertyToken(key));
		}

		private void ParseUnquotedStringIndexer()
		{
			string key = ReadTextUntil(']');
			CurrentTokens.Add(new MvxStringIndexerPropertyToken(key));
		}

		private void SkipWhitespaceAndPeriods()
		{
			SkipWhitespaceAndCharacters('.');
		}
	}
	public interface IMvxSourcePropertyPathParser
	{
		IList<MvxPropertyToken> Parse(string textToParse);
	}
	public class MvxSourcePropertyPathParser : IMvxSourcePropertyPathParser
	{
		private static readonly ConcurrentDictionary<int, IList<MvxPropertyToken>> ParseCache = new ConcurrentDictionary<int, IList<MvxPropertyToken>>();

		public IList<MvxPropertyToken> Parse(string textToParse)
		{
			textToParse = MvxPropertyPathParser.MakeSafe(textToParse);
			int hashCode = textToParse.GetHashCode();
			if (ParseCache.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			IList<MvxPropertyToken> list = new MvxPropertyPathParser().Parse(textToParse);
			ParseCache.TryAdd(hashCode, list);
			return list;
		}
	}
}
namespace MvvmCross.Binding.Parse.PropertyPath.PropertyTokens
{
	public class MvxPropertyToken
	{
	}
	public class MvxEmptyPropertyToken : MvxPropertyToken
	{
		public override string ToString()
		{
			return "Property:WholeObject";
		}
	}
	public class MvxIndexerPropertyToken : MvxPropertyToken
	{
		public object Key { get; }

		protected MvxIndexerPropertyToken(object key)
		{
			Key = key;
		}

		public override string ToString()
		{
			return "IndexedProperty:" + ((Key == null) ? "null" : Key.ToString());
		}
	}
	public class MvxIndexerPropertyToken<T> : MvxIndexerPropertyToken
	{
		public new T Key => (T)base.Key;

		protected MvxIndexerPropertyToken(T key)
			: base(key)
		{
		}
	}
	public class MvxIntegerIndexerPropertyToken : MvxIndexerPropertyToken<int>
	{
		public MvxIntegerIndexerPropertyToken(int key)
			: base(key)
		{
		}
	}
	public class MvxPropertyNamePropertyToken : MvxPropertyToken
	{
		public string PropertyName { get; }

		public MvxPropertyNamePropertyToken(string propertyText)
		{
			PropertyName = propertyText;
		}

		public override string ToString()
		{
			return "Property:" + PropertyName;
		}
	}
	public class MvxStringIndexerPropertyToken : MvxIndexerPropertyToken<string>
	{
		public MvxStringIndexerPropertyToken(string key)
			: base(key)
		{
		}
	}
}
namespace MvvmCross.Binding.Parse.Binding
{
	public interface IMvxBindingParser
	{
		bool TryParseBindingDescription(string text, out MvxSerializableBindingDescription requestedDescription);

		bool TryParseBindingSpecification(string text, out MvxSerializableBindingSpecification requestedBindings);
	}
	public abstract class MvxBindingParser : MvxParser, IMvxBindingParser
	{
		protected abstract MvxSerializableBindingDescription ParseBindingDescription();

		public bool TryParseBindingDescription(string text, out MvxSerializableBindingDescription requestedDescription)
		{
			try
			{
				Reset(text);
				requestedDescription = ParseBindingDescription();
				return true;
			}
			catch (Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Problem parsing binding {0}", exception.ToLongString());
				requestedDescription = null;
				return false;
			}
		}

		public bool TryParseBindingSpecification(string text, out MvxSerializableBindingSpecification requestedBindings)
		{
			try
			{
				Reset(text);
				MvxSerializableBindingSpecification mvxSerializableBindingSpecification = new MvxSerializableBindingSpecification();
				while (!base.IsComplete)
				{
					SkipWhitespaceAndDescriptionSeparators();
					KeyValuePair<string, MvxSerializableBindingDescription> keyValuePair = ParseTargetPropertyNameAndDescription();
					mvxSerializableBindingSpecification[keyValuePair.Key] = keyValuePair.Value;
					SkipWhitespaceAndDescriptionSeparators();
				}
				requestedBindings = mvxSerializableBindingSpecification;
				return true;
			}
			catch (Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Problem parsing binding {0}", exception.ToLongString());
				requestedBindings = null;
				return false;
			}
		}

		protected KeyValuePair<string, MvxSerializableBindingDescription> ParseTargetPropertyNameAndDescription()
		{
			string key = ReadTargetPropertyName();
			SkipWhitespace();
			MvxSerializableBindingDescription value = ParseBindingDescription();
			return new KeyValuePair<string, MvxSerializableBindingDescription>(key, value);
		}

		protected void ParseEquals(string block)
		{
			if (base.IsComplete)
			{
				throw new MvxException("Cannot terminate binding expression during option {0} in {1}", block, base.FullText);
			}
			if (base.CurrentChar != '=')
			{
				throw new MvxException("Must follow binding option {0} with an '=' in {1}", block, base.FullText);
			}
			MoveNext();
			if (base.IsComplete)
			{
				throw new MvxException("Cannot terminate binding expression during option {0} in {1}", block, base.FullText);
			}
		}

		protected MvxBindingMode ReadBindingMode()
		{
			return (MvxBindingMode)ReadEnumerationValue(typeof(MvxBindingMode));
		}

		protected string ReadTextUntilNonQuotedOccurrenceOfAnyOf(params char[] terminationCharacters)
		{
			Dictionary<char, bool> dictionary = terminationCharacters.ToDictionary((char c) => c, (char c) => true);
			SkipWhitespace();
			StringBuilder stringBuilder = new StringBuilder();
			while (!base.IsComplete)
			{
				char currentChar = base.CurrentChar;
				if (currentChar == '\'' || currentChar == '"')
				{
					string value = ReadQuotedString();
					stringBuilder.Append(currentChar);
					stringBuilder.Append(value);
					stringBuilder.Append(currentChar);
					continue;
				}
				if (dictionary.ContainsKey(currentChar))
				{
					break;
				}
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			return stringBuilder.ToString();
		}

		protected string ReadTargetPropertyName()
		{
			return ReadValidCSharpName();
		}

		protected void SkipWhitespaceAndOptionSeparators()
		{
			SkipWhitespaceAndCharacters(',');
		}

		protected void SkipWhitespaceAndDescriptionSeparators()
		{
			SkipWhitespaceAndCharacters(';');
		}
	}
	public class MvxSerializableBindingDescription
	{
		public string Converter { get; set; }

		public object ConverterParameter { get; set; }

		public object FallbackValue { get; set; }

		public MvxBindingMode Mode { get; set; }

		public IList<MvxSerializableBindingDescription> Sources { get; set; }

		public string Function { get; set; }

		public object Literal { get; set; }

		public string Path { get; set; }
	}
	public class MvxSerializableBindingSpecification : Dictionary<string, MvxSerializableBindingDescription>
	{
	}
	public class MvxBindingDescriptionParser : IMvxBindingDescriptionParser
	{
		private IMvxBindingParser _bindingParser;

		private IMvxValueConverterLookup _valueConverterLookup;

		private IMvxLanguageBindingParser _languageBindingParser;

		protected IMvxBindingParser BindingParser
		{
			get
			{
				_bindingParser = _bindingParser ?? Mvx.Resolve<IMvxBindingParser>();
				return _bindingParser;
			}
		}

		protected IMvxLanguageBindingParser LanguageBindingParser
		{
			get
			{
				_languageBindingParser = _languageBindingParser ?? Mvx.Resolve<IMvxLanguageBindingParser>();
				return _languageBindingParser;
			}
		}

		protected IMvxValueConverterLookup ValueConverterLookup
		{
			get
			{
				_valueConverterLookup = _valueConverterLookup ?? Mvx.Resolve<IMvxValueConverterLookup>();
				return _valueConverterLookup;
			}
		}

		protected IMvxValueConverter FindConverter(string converterName)
		{
			if (converterName == null)
			{
				return null;
			}
			IMvxValueConverter mvxValueConverter = ValueConverterLookup.Find(converterName);
			if (mvxValueConverter == null)
			{
				MvxBindingTrace.Trace("Could not find named converter for {0}", converterName);
			}
			return mvxValueConverter;
		}

		protected IMvxValueCombiner FindCombiner(string combiner)
		{
			return MvxSingleton<IMvxBindingSingletonCache>.Instance.ValueCombinerLookup.Find(combiner);
		}

		public IEnumerable<MvxBindingDescription> Parse(string text)
		{
			IMvxBindingParser bindingParser = BindingParser;
			return Parse(text, bindingParser);
		}

		public IEnumerable<MvxBindingDescription> LanguageParse(string text)
		{
			IMvxLanguageBindingParser languageBindingParser = LanguageBindingParser;
			return Parse(text, languageBindingParser);
		}

		public IEnumerable<MvxBindingDescription> Parse(string text, IMvxBindingParser parser)
		{
			if (!parser.TryParseBindingSpecification(text, out var requestedBindings))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Failed to parse binding specification starting with {0}", (text == null) ? "" : ((text.Length > 20) ? text.Substring(0, 20) : text));
				return null;
			}
			return requestedBindings?.Select((KeyValuePair<string, MvxSerializableBindingDescription> item) => SerializableBindingToBinding(item.Key, item.Value));
		}

		public MvxBindingDescription ParseSingle(string text)
		{
			if (!BindingParser.TryParseBindingDescription(text, out var requestedDescription))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Failed to parse binding description starting with {0}", (text == null) ? "" : ((text.Length > 20) ? text.Substring(0, 20) : text));
				return null;
			}
			if (requestedDescription == null)
			{
				return null;
			}
			return SerializableBindingToBinding(null, requestedDescription);
		}

		public MvxBindingDescription SerializableBindingToBinding(string targetName, MvxSerializableBindingDescription description)
		{
			return new MvxBindingDescription
			{
				TargetName = targetName,
				Source = SourceStepDescriptionFrom(description),
				Mode = description.Mode
			};
		}

		private MvxSourceStepDescription SourceStepDescriptionFrom(MvxSerializableBindingDescription description)
		{
			if (description.Path != null)
			{
				return new MvxPathSourceStepDescription
				{
					SourcePropertyPath = description.Path,
					Converter = FindConverter(description.Converter),
					ConverterParameter = description.ConverterParameter,
					FallbackValue = description.FallbackValue
				};
			}
			if (description.Literal != null)
			{
				object obj = description.Literal;
				if (obj == MvxTibetBindingParser.LiteralNull)
				{
					obj = null;
				}
				return new MvxLiteralSourceStepDescription
				{
					Literal = obj,
					Converter = FindConverter(description.Converter),
					ConverterParameter = description.ConverterParameter,
					FallbackValue = description.FallbackValue
				};
			}
			if (description.Function != null)
			{
				IMvxValueCombiner mvxValueCombiner = FindCombiner(description.Function);
				if (mvxValueCombiner != null)
				{
					return new MvxCombinerSourceStepDescription
					{
						Combiner = mvxValueCombiner,
						InnerSteps = ((description.Sources == null) ? new List<MvxSourceStepDescription>() : description.Sources.Select((MvxSerializableBindingDescription s) => SourceStepDescriptionFrom(s)).ToList()),
						Converter = FindConverter(description.Converter),
						ConverterParameter = description.ConverterParameter,
						FallbackValue = description.FallbackValue
					};
				}
				IMvxValueConverter mvxValueConverter = FindConverter(description.Function);
				if (mvxValueConverter == null)
				{
					MvxBindingTrace.Error("Failed to find combiner or converter for {0}", description.Function);
				}
				if (description.Sources == null || description.Sources.Count == 0)
				{
					MvxBindingTrace.Error("Value Converter {0} supplied with no source", description.Function);
					return new MvxLiteralSourceStepDescription
					{
						Literal = null
					};
				}
				if (description.Sources.Count > 2)
				{
					MvxBindingTrace.Error("Value Converter {0} supplied with too many parameters - {1}", description.Function, description.Sources.Count);
					return new MvxLiteralSourceStepDescription
					{
						Literal = null
					};
				}
				return new MvxCombinerSourceStepDescription
				{
					Combiner = new MvxValueConverterValueCombiner(mvxValueConverter),
					InnerSteps = description.Sources.Select((MvxSerializableBindingDescription source) => SourceStepDescriptionFrom(source)).ToList(),
					Converter = FindConverter(description.Converter),
					ConverterParameter = description.ConverterParameter,
					FallbackValue = description.FallbackValue
				};
			}
			return new MvxPathSourceStepDescription
			{
				SourcePropertyPath = null,
				Converter = FindConverter(description.Converter),
				ConverterParameter = description.ConverterParameter,
				FallbackValue = description.FallbackValue
			};
		}
	}
}
namespace MvvmCross.Binding.Parse.Binding.Swiss
{
	public class MvxSwissBindingParser : MvxBindingParser
	{
		protected enum ParentIsLookingForComma
		{
			ParentIsLookingForComma,
			ParentIsNotLookingForComma
		}

		protected virtual IEnumerable<char> TerminatingCharacters()
		{
			return new char[5] { '=', ',', ';', '(', ')' };
		}

		protected virtual void ParseNextBindingDescriptionOptionInto(MvxSerializableBindingDescription description)
		{
			if (base.IsComplete)
			{
				return;
			}
			string text = ReadTextUntilNonQuotedOccurrenceOfAnyOf(TerminatingCharacters().ToArray());
			text = text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				HandleEmptyBlock(description);
				return;
			}
			switch (text)
			{
			case "Path":
				ParseEquals(text);
				ThrowExceptionIfPathAlreadyDefined(description);
				description.Path = ReadTextUntilNonQuotedOccurrenceOfAnyOf(',', ';');
				break;
			case "Converter":
			{
				ParseEquals(text);
				string text2 = ReadTargetPropertyName();
				if (!string.IsNullOrEmpty(description.Converter))
				{
					MvxBindingTrace.Warning("Overwriting existing Converter with {0}", text2);
				}
				description.Converter = text2;
				break;
			}
			case "ConverterParameter":
				ParseEquals(text);
				if (description.ConverterParameter != null)
				{
					MvxBindingTrace.Warning("Overwriting existing ConverterParameter");
				}
				description.ConverterParameter = ReadValue();
				break;
			case "CommandParameter":
				if (!base.IsComplete && base.CurrentChar == '(')
				{
					ParseNonKeywordBlockInto(description, text);
					break;
				}
				ParseEquals(text);
				if (!string.IsNullOrEmpty(description.Converter))
				{
					MvxBindingTrace.Warning("Overwriting existing Converter with CommandParameter");
				}
				description.Converter = "CommandParameter";
				description.ConverterParameter = ReadValue();
				break;
			case "FallbackValue":
				ParseEquals(text);
				if (description.FallbackValue != null)
				{
					MvxBindingTrace.Warning("Overwriting existing FallbackValue");
				}
				description.FallbackValue = ReadValue();
				break;
			case "Mode":
				ParseEquals(text);
				description.Mode = ReadBindingMode();
				break;
			default:
				ParseNonKeywordBlockInto(description, text);
				break;
			}
		}

		protected virtual void HandleEmptyBlock(MvxSerializableBindingDescription description)
		{
		}

		protected virtual void ParseNonKeywordBlockInto(MvxSerializableBindingDescription description, string block)
		{
			if (!base.IsComplete && base.CurrentChar == '(')
			{
				ParseFunctionStyleBlockInto(description, block);
				return;
			}
			ThrowExceptionIfPathAlreadyDefined(description);
			description.Path = block;
		}

		protected virtual void ParseFunctionStyleBlockInto(MvxSerializableBindingDescription description, string block)
		{
			description.Converter = block;
			MoveNext();
			if (base.IsComplete)
			{
				throw new MvxException("Unterminated () pair for converter {0}", block);
			}
			ParseChildBindingDescriptionInto(description);
			SkipWhitespace();
			switch (base.CurrentChar)
			{
			case ')':
				MoveNext();
				break;
			case ',':
				MoveNext();
				ReadConverterParameterAndClosingBracket(description);
				break;
			default:
				throw new MvxException("Unexpected character {0} while parsing () contents", base.CurrentChar);
			}
		}

		protected void ReadConverterParameterAndClosingBracket(MvxSerializableBindingDescription description)
		{
			SkipWhitespace();
			description.ConverterParameter = ReadValue();
			SkipWhitespace();
			if (base.CurrentChar != ')')
			{
				throw new MvxException("Unterminated () pair for converter {0}");
			}
			MoveNext();
		}

		protected void ParseChildBindingDescriptionInto(MvxSerializableBindingDescription description, ParentIsLookingForComma parentIsLookingForComma = ParentIsLookingForComma.ParentIsLookingForComma)
		{
			SkipWhitespace();
			description.Function = "Single";
			description.Sources = new MvxSerializableBindingDescription[1] { ParseBindingDescription(parentIsLookingForComma) };
		}

		protected void ThrowExceptionIfPathAlreadyDefined(MvxSerializableBindingDescription description)
		{
			if (description.Path != null && description.Literal != null && description.Function != null)
			{
				throw new MvxException("Make sure you are using ';' to separate multiple bindings. You cannot specify Path/Literal/Combiner more than once - position {0} in {1}", base.CurrentIndex, base.FullText);
			}
		}

		protected override MvxSerializableBindingDescription ParseBindingDescription()
		{
			return ParseBindingDescription(ParentIsLookingForComma.ParentIsNotLookingForComma);
		}

		protected virtual MvxSerializableBindingDescription ParseBindingDescription(ParentIsLookingForComma parentIsLookingForComma)
		{
			MvxSerializableBindingDescription mvxSerializableBindingDescription = new MvxSerializableBindingDescription();
			SkipWhitespace();
			while (true)
			{
				ParseNextBindingDescriptionOptionInto(mvxSerializableBindingDescription);
				SkipWhitespace();
				if (base.IsComplete)
				{
					break;
				}
				switch (base.CurrentChar)
				{
				case ',':
					if (parentIsLookingForComma == ParentIsLookingForComma.ParentIsLookingForComma)
					{
						return mvxSerializableBindingDescription;
					}
					MoveNext();
					continue;
				case ')':
				case ';':
					return mvxSerializableBindingDescription;
				}
				if (DetectOperator())
				{
					ParseOperatorWithLeftHand(mvxSerializableBindingDescription);
					continue;
				}
				throw new MvxException("Unexpected character {0} at position {1} in {2} - expected string-end, ',' or ';'", base.CurrentChar, base.CurrentIndex, base.FullText);
			}
			return mvxSerializableBindingDescription;
		}

		protected virtual MvxSerializableBindingDescription ParseOperatorWithLeftHand(MvxSerializableBindingDescription description)
		{
			throw new MvxException("Operators not expected in base SwissBinding");
		}

		protected virtual bool DetectOperator()
		{
			return false;
		}
	}
}
namespace MvvmCross.Binding.Parse.Binding.Lang
{
	public interface IMvxLanguageBindingParser : IMvxBindingParser
	{
		string DefaultConverterName { get; set; }

		string DefaultTextSourceName { get; set; }
	}
	public class MvxLanguageBindingParser : MvxBindingParser, IMvxLanguageBindingParser, IMvxBindingParser
	{
		public MvxBindingMode DefaultBindingMode { get; set; }

		public string DefaultConverterName { get; set; }

		public string DefaultTextSourceName { get; set; }

		public MvxLanguageBindingParser()
		{
			DefaultConverterName = "Language";
			DefaultTextSourceName = "TextSource";
			DefaultBindingMode = MvxBindingMode.OneTime;
		}

		protected void ParseNextBindingDescriptionOptionInto(MvxSerializableBindingDescription description)
		{
			if (base.IsComplete)
			{
				return;
			}
			string text = ReadTextUntilNonQuotedOccurrenceOfAnyOf('=', ',', ';');
			text = text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			switch (text)
			{
			case "Source":
			{
				ParseEquals(text);
				string path = ReadTextUntilNonQuotedOccurrenceOfAnyOf(',', ';');
				description.Path = path;
				return;
			}
			case "Converter":
				ParseEquals(text);
				description.Converter = ReadValidCSharpName();
				return;
			case "Key":
				ParseEquals(text);
				description.ConverterParameter = ReadValue();
				return;
			case "FallbackValue":
				ParseEquals(text);
				description.FallbackValue = ReadValue();
				return;
			}
			if (description.ConverterParameter != null)
			{
				throw new MvxException("Problem parsing Language Binding near '{0}', Key set to '{1}', position {2} in {3}", text, description.ConverterParameter, base.CurrentIndex, base.FullText);
			}
			text = UnquoteBlockIfNecessary(text);
			description.ConverterParameter = text;
		}

		private static string UnquoteBlockIfNecessary(string block)
		{
			if (string.IsNullOrEmpty(block))
			{
				return block;
			}
			if (block.Length < 2)
			{
				return block;
			}
			if ((block.StartsWith("'") && block.EndsWith("'")) || (block.StartsWith("\"") && block.EndsWith("\"")))
			{
				return block.Substring(1, block.Length - 2);
			}
			return block;
		}

		protected override MvxSerializableBindingDescription ParseBindingDescription()
		{
			MvxSerializableBindingDescription mvxSerializableBindingDescription = new MvxSerializableBindingDescription
			{
				Converter = DefaultConverterName,
				Path = DefaultTextSourceName,
				Mode = DefaultBindingMode
			};
			SkipWhitespace();
			while (true)
			{
				ParseNextBindingDescriptionOptionInto(mvxSerializableBindingDescription);
				SkipWhitespace();
				if (base.IsComplete)
				{
					break;
				}
				switch (base.CurrentChar)
				{
				case ',':
					break;
				case ';':
					return mvxSerializableBindingDescription;
				default:
					throw new MvxException("Unexpected character {0} at position {1} in {2} - expected string-end, ',' or ';'", base.CurrentChar, base.CurrentIndex, base.FullText);
				}
				MoveNext();
			}
			return mvxSerializableBindingDescription;
		}
	}
}
namespace MvvmCross.Binding.Parse.Binding.Tibet
{
	public class MvxTibetBindingParser : MvxSwissBindingParser
	{
		public static readonly object LiteralNull = new object();

		private List<char> _terminatingCharacters;

		protected override IEnumerable<char> TerminatingCharacters()
		{
			return _terminatingCharacters ?? (_terminatingCharacters = base.TerminatingCharacters().Union(OperatorCharacters()).ToList());
		}

		private static char[] OperatorCharacters()
		{
			return new char[11]
			{
				'>', '<', '+', '-', '*', '/', '|', '&', '!', '=',
				'%'
			};
		}

		protected override void ParseNextBindingDescriptionOptionInto(MvxSerializableBindingDescription description)
		{
			if (!base.IsComplete)
			{
				if (TryReadValue(AllowNonQuotedText.DoNotAllow, out var value))
				{
					value = value ?? LiteralNull;
					ThrowExceptionIfPathAlreadyDefined(description);
					description.Literal = value;
				}
				else
				{
					base.ParseNextBindingDescriptionOptionInto(description);
				}
			}
		}

		protected override void ParseFunctionStyleBlockInto(MvxSerializableBindingDescription description, string block)
		{
			description.Function = block;
			MoveNext();
			if (base.IsComplete)
			{
				throw new MvxException("Unterminated () pair for combiner {0}", block);
			}
			bool flag = false;
			List<MvxSerializableBindingDescription> list = new List<MvxSerializableBindingDescription>();
			while (!flag)
			{
				SkipWhitespace();
				list.Add(ParseBindingDescription(ParentIsLookingForComma.ParentIsLookingForComma));
				SkipWhitespace();
				if (base.IsComplete)
				{
					throw new MvxException("Unterminated () while parsing combiner {0}", block);
				}
				switch (base.CurrentChar)
				{
				case ')':
					MoveNext();
					flag = true;
					break;
				case ',':
					MoveNext();
					break;
				default:
					throw new MvxException("Unexpected character {0} while parsing () combiner contents for {1}", base.CurrentChar, block);
				}
			}
			description.Sources = list.ToArray();
		}

		protected override MvxSerializableBindingDescription ParseOperatorWithLeftHand(MvxSerializableBindingDescription description)
		{
			string text = SafePeekString(2);
			string text2 = null;
			uint increment = 0u;
			switch (text)
			{
			case "!=":
				text2 = "NotEqualTo";
				increment = 2u;
				break;
			case ">=":
				text2 = "GreaterThanOrEqualTo";
				increment = 2u;
				break;
			case "<=":
				text2 = "LessThanOrEqualTo";
				increment = 2u;
				break;
			case "==":
				text2 = "EqualTo";
				increment = 2u;
				break;
			case "&&":
				text2 = "And";
				increment = 2u;
				break;
			case "||":
				text2 = "Or";
				increment = 2u;
				break;
			}
			if (text2 == null)
			{
				switch (base.CurrentChar)
				{
				case '>':
					text2 = "GreaterThan";
					increment = 1u;
					break;
				case '<':
					text2 = "LessThan";
					increment = 1u;
					break;
				case '+':
					text2 = "Add";
					increment = 1u;
					break;
				case '-':
					text2 = "Subtract";
					increment = 1u;
					break;
				case '*':
					text2 = "Multiply";
					increment = 1u;
					break;
				case '/':
					text2 = "Divide";
					increment = 1u;
					break;
				case '%':
					text2 = "Modulus";
					increment = 1u;
					break;
				}
			}
			if (text2 == null)
			{
				throw new MvxException("Unexpected operator starting with {0}", base.CurrentChar);
			}
			MoveNext(increment);
			MvxSerializableBindingDescription item = new MvxSerializableBindingDescription
			{
				Path = description.Path,
				Literal = description.Literal,
				Sources = description.Sources,
				Function = description.Function,
				Converter = description.Converter,
				FallbackValue = description.FallbackValue,
				ConverterParameter = description.ConverterParameter,
				Mode = description.Mode
			};
			description.Converter = null;
			description.ConverterParameter = null;
			description.FallbackValue = null;
			description.Path = null;
			description.Mode = MvxBindingMode.Default;
			description.Literal = null;
			description.Function = text2;
			description.Sources = new List<MvxSerializableBindingDescription>
			{
				item,
				ParseBindingDescription(ParentIsLookingForComma.ParentIsLookingForComma)
			};
			return description;
		}

		protected override bool DetectOperator()
		{
			return OperatorCharacters().Contains(base.CurrentChar);
		}

		protected override void HandleEmptyBlock(MvxSerializableBindingDescription description)
		{
			if (!base.IsComplete && base.CurrentChar == '(')
			{
				MoveNext();
				ParseChildBindingDescriptionInto(description, ParentIsLookingForComma.ParentIsNotLookingForComma);
				SkipWhitespace();
				if (base.IsComplete || base.CurrentChar != ')')
				{
					throw new MvxException("Unterminated () pair");
				}
				MoveNext();
				SkipWhitespace();
			}
		}
	}
}
namespace MvvmCross.Binding.ExtensionMethods
{
	public interface IMvxEditableTextView
	{
		string CurrentText { get; }
	}
	public static class MvxEnumerableExtensions
	{
		public static int Count(this IEnumerable enumerable)
		{
			if (enumerable == null)
			{
				return 0;
			}
			if (enumerable is ICollection collection)
			{
				return collection.Count;
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}

		public static int GetPosition(this IEnumerable items, object item)
		{
			if (items == null)
			{
				return -1;
			}
			if (items is IList list)
			{
				return list.IndexOf(item);
			}
			IEnumerator enumerator = items.GetEnumerator();
			int num = 0;
			while (true)
			{
				if (!enumerator.MoveNext())
				{
					return -1;
				}
				if (enumerator.Current == null)
				{
					if (item == null)
					{
						return num;
					}
				}
				else if (enumerator.Current.Equals(item))
				{
					break;
				}
				num++;
			}
			return num;
		}

		public static object ElementAt(this IEnumerable items, int position)
		{
			if (items == null)
			{
				return null;
			}
			if (items is IList list)
			{
				return list[position];
			}
			IEnumerator enumerator = items.GetEnumerator();
			for (int i = 0; i <= position; i++)
			{
				enumerator.MoveNext();
			}
			return enumerator.Current;
		}
	}
	public static class MvxBindingExtensions
	{
		public static bool ShouldSkipSetValueAsHaveNearlyIdenticalNumericText(this IMvxEditableTextView mvxEditableTextView, object target, object value)
		{
			if (value == null)
			{
				return false;
			}
			Type type = value.GetType();
			if ((object)type == typeof(int) || (object)type == typeof(double) || (object)type == typeof(float) || (object)type == typeof(decimal))
			{
				string currentText = mvxEditableTextView.CurrentText;
				if (currentText == null)
				{
					return false;
				}
				try
				{
					if (type.MakeSafeValue(currentText).Equals(value))
					{
						return true;
					}
				}
				catch (FormatException)
				{
					return false;
				}
			}
			return false;
		}

		public static bool ConvertToBoolean(this object result)
		{
			return result.ConvertToBooleanCore();
		}

		public static object MakeSafeValue(this Type propertyType, object value)
		{
			if (value == null)
			{
				return propertyType.CreateDefault();
			}
			IMvxValueConverter mvxValueConverter = MvxSingleton<IMvxBindingSingletonCache>.Instance.AutoValueConverters.Find(value.GetType(), propertyType);
			if (mvxValueConverter != null)
			{
				return mvxValueConverter.Convert(value, propertyType, null, CultureInfo.CurrentUICulture);
			}
			return propertyType.MakeSafeValueCore(value);
		}
	}
}
namespace MvvmCross.Binding.Combiners
{
	public interface IMvxValueCombiner
	{
		Type SourceType(IEnumerable<IMvxSourceStep> steps);

		void SetValue(IEnumerable<IMvxSourceStep> steps, object value);

		bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value);

		IEnumerable<Type> SubStepTargetTypes(IEnumerable<IMvxSourceStep> subSteps, Type overallTargetType);
	}
	public class MvxFormatValueCombiner : MvxValueCombiner
	{
		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			List<IMvxSourceStep> list = steps.ToList();
			if (list.Count < 1)
			{
				MvxBindingTrace.Warning("Format called with no parameters - will fail");
				value = MvxBindingConstant.DoNothing;
				return true;
			}
			object value2 = list.First().GetValue();
			if (value2 == MvxBindingConstant.DoNothing)
			{
				value = MvxBindingConstant.DoNothing;
				return true;
			}
			if (value2 == MvxBindingConstant.UnsetValue)
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			string format = ((value2 == null) ? "" : value2.ToString());
			object[] array = (from s in list.Skip(1)
				select s.GetValue()).ToArray();
			if (array.Any((object v) => v == MvxBindingConstant.DoNothing))
			{
				value = MvxBindingConstant.DoNothing;
				return true;
			}
			if (array.Any((object v) => v == MvxBindingConstant.UnsetValue))
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			value = string.Format(format, array);
			return true;
		}
	}
	public class MvxIfValueCombiner : MvxValueCombiner
	{
		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			List<IMvxSourceStep> list = steps.ToList();
			switch (list.Count)
			{
			case 2:
				return TryEvaluateIf(list[0], list[1], null, out value);
			case 3:
				return TryEvaluateIf(list[0], list[1], list[2], out value);
			default:
				MvxBindingTrace.Warning("Unexpected substep count of {0} in 'If' ValueCombiner", list.Count);
				return base.TryGetValue(list, out value);
			}
		}

		private bool TryEvaluateIf(IMvxSourceStep testStep, IMvxSourceStep ifStep, IMvxSourceStep elseStep, out object value)
		{
			object value2 = testStep.GetValue();
			if (value2 == MvxBindingConstant.DoNothing)
			{
				value = MvxBindingConstant.DoNothing;
				return true;
			}
			if (value2 == MvxBindingConstant.UnsetValue)
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			if (IsTrue(value2))
			{
				value = ReturnSubStepResult(ifStep);
				return true;
			}
			value = ReturnSubStepResult(elseStep);
			return true;
		}

		protected virtual bool IsTrue(object result)
		{
			return result.ConvertToBoolean();
		}

		protected virtual object ReturnSubStepResult(IMvxSourceStep subStep)
		{
			if (subStep == null)
			{
				return MvxBindingConstant.UnsetValue;
			}
			return subStep.GetValue();
		}
	}
	public class MvxSingleValueCombiner : MvxValueCombiner
	{
		public override Type SourceType(IEnumerable<IMvxSourceStep> steps)
		{
			IMvxSourceStep mvxSourceStep = steps.FirstOrDefault();
			if (mvxSourceStep == null)
			{
				return typeof(object);
			}
			return mvxSourceStep.SourceType;
		}

		public override void SetValue(IEnumerable<IMvxSourceStep> steps, object value)
		{
			steps.FirstOrDefault()?.SetValue(value);
		}

		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			IMvxSourceStep mvxSourceStep = steps.FirstOrDefault();
			if (mvxSourceStep == null)
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			value = mvxSourceStep.GetValue();
			return true;
		}
	}
	public interface IMvxValueCombinerLookup : IMvxNamedInstanceLookup<IMvxValueCombiner>
	{
	}
	public interface IMvxValueCombinerRegistry : IMvxNamedInstanceRegistry<IMvxValueCombiner>, IMvxValueCombinerLookup, IMvxNamedInstanceLookup<IMvxValueCombiner>
	{
	}
	public interface IMvxValueCombinerRegistryFiller : IMvxNamedInstanceRegistryFiller<IMvxValueCombiner>
	{
	}
	public class MvxAddValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 + (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 + input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = input2;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineNullAndString(string input2, out object value)
		{
			value = input2;
			return true;
		}

		protected override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 + (double)input2;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 + input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 + input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 + (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 + input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = input2;
			return true;
		}
	}
	public class MvxDivideValueCombiner : MvxNumericOnlyValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 / input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 / input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 / (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = 0m;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 / (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 / input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 / (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = 0.0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 / input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 / input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 / input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = ((input1 >= 0) ? (1.0 / 0.0) : (-1.0 / 0.0));
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = 0m / input2;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0 / input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0 / input2;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = null;
			return true;
		}
	}
	public class MvxModulusValueCombiner : MvxNumericOnlyValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 % input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 % input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 % (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = 0m;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 % (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 % input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 % (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = 0.0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 % input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 % input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 % input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = 0;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = 0m % input2;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0 % input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0 % input2;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = null;
			return true;
		}
	}
	public class MvxMultiplyValueCombiner : MvxNumericOnlyValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 * input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 * input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 * (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 * (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 * input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 * (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 * input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 * input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 * input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = null;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = null;
			return true;
		}
	}
	public abstract class MvxNumericOnlyValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = null;
			return false;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = null;
			return false;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = null;
			return false;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = null;
			return false;
		}

		protected sealed override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = null;
			return false;
		}

		protected sealed override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = null;
			return false;
		}

		protected sealed override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = null;
			return false;
		}

		protected sealed override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = null;
			return false;
		}

		protected sealed override bool CombineNullAndString(string input2, out object value)
		{
			value = null;
			return false;
		}
	}
	public abstract class MvxObjectAsStringPairwiseValueCombiner : MvxPairwiseValueCombiner
	{
		protected abstract bool CombineStringAndString(string input1, string input2, out object value);

		protected abstract bool CombineLongAndString(long input1, string input2, out object value);

		protected abstract bool CombineDoubleAndString(double input1, string input2, out object value);

		protected abstract bool CombineDecimalAndString(decimal input1, string input2, out object value);

		protected abstract bool CombineNullAndString(string input2, out object value);

		protected abstract bool CombineStringAndDouble(string input1, double input2, out object value);

		protected abstract bool CombineStringAndLong(string input1, long input2, out object value);

		protected abstract bool CombineStringAndDecimal(string input1, decimal input2, out object value);

		protected abstract bool CombineStringAndNull(string input1, out object value);

		protected sealed override bool CombineObjectAndObject(object object1, object object2, out object value)
		{
			return CombineStringAndString(object1.ToString(), object2.ToString(), out value);
		}

		protected sealed override bool CombineLongAndObject(long int1, object object1, out object value)
		{
			return CombineLongAndString(int1, object1.ToString(), out value);
		}

		protected sealed override bool CombineDoubleAndObject(double double1, object object1, out object value)
		{
			return CombineDoubleAndString(double1, object1.ToString(), out value);
		}

		protected sealed override bool CombineDecimalAndObject(decimal decimal1, object object1, out object value)
		{
			return CombineDecimalAndString(decimal1, object1.ToString(), out value);
		}

		protected sealed override bool CombineNullAndObject(object object1, out object value)
		{
			return CombineNullAndString(object1.ToString(), out value);
		}

		protected sealed override bool CombineObjectAndDouble(object input1, double input2, out object value)
		{
			return CombineStringAndDouble(input1.ToString(), input2, out value);
		}

		protected sealed override bool CombineObjectAndLong(object input1, long input2, out object value)
		{
			return CombineStringAndLong(input1.ToString(), input2, out value);
		}

		protected sealed override bool CombineObjectAndDecimal(object input1, decimal input2, out object value)
		{
			return CombineStringAndDecimal(input1.ToString(), input2, out value);
		}

		protected sealed override bool CombineObjectAndNull(object input1, out object value)
		{
			return CombineStringAndNull(input1.ToString(), out value);
		}
	}
	public abstract class MvxPairwiseValueCombiner : MvxValueCombiner
	{
		private class ResultPair
		{
			public bool IsAvailable { get; set; }

			public object Value { get; set; }
		}

		public class TypeTuple
		{
			public Type Type1 { get; }

			public Type Type2 { get; }

			public TypeTuple(Type type1, Type type2)
			{
				Type2 = type2;
				Type1 = type1;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is TypeTuple typeTuple))
				{
					return false;
				}
				if ((object)typeTuple.Type2 == Type2)
				{
					return (object)typeTuple.Type1 == Type1;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (Type1?.GetHashCode() ?? 0) + (Type2?.GetHashCode() ?? 0);
			}
		}

		private delegate bool CombinerFunc(out object value);

		private delegate bool CombinerFunc<in T1>(T1 input1, out object value);

		private delegate bool CombinerFunc<in T1, in T2>(T1 input1, T2 input2, out object value);

		private readonly Dictionary<TypeTuple, CombinerFunc<object, object>> _combinerActions;

		public override void SetValue(IEnumerable<IMvxSourceStep> steps, object value)
		{
			Mvx.Trace("The Add Combiner does not support SetValue");
		}

		public override Type SourceType(IEnumerable<IMvxSourceStep> steps)
		{
			return steps.First().SourceType;
		}

		private static Type GetLookupTypeFor(object value)
		{
			if (value == null)
			{
				return null;
			}
			if (value is long)
			{
				return typeof(long);
			}
			if (value is double)
			{
				return typeof(double);
			}
			if (value is decimal)
			{
				return typeof(decimal);
			}
			return typeof(object);
		}

		protected MvxPairwiseValueCombiner()
		{
			_combinerActions = new Dictionary<TypeTuple, CombinerFunc<object, object>>();
			AddSingle<object, object>(CombineObjectAndObject);
			AddSingle<object, double>(CombineObjectAndDouble);
			AddSingle<object, long>(CombineObjectAndLong);
			AddSingle<object, decimal>(CombineObjectAndDecimal);
			AddSingle<double, object>(CombineDoubleAndObject);
			AddSingle<double, double>(CombineDoubleAndDouble);
			AddSingle<double, long>(CombineDoubleAndLong);
			AddSingle<double, decimal>(CombineDoubleAndDecimal);
			AddSingle<long, object>(CombineLongAndObject);
			AddSingle<long, double>(CombineLongAndDouble);
			AddSingle<long, long>(CombineLongAndLong);
			AddSingle<long, decimal>(CombineLongAndDecimal);
			AddSingle<decimal, object>(CombineDecimalAndObject);
			AddSingle<decimal, double>(CombineDecimalAndDouble);
			AddSingle<decimal, long>(CombineDecimalAndLong);
			AddSingle<decimal, decimal>(CombineDecimalAndDecimal);
			AddSingle<object>(CombineObjectAndNull, CombineNullAndObject);
			AddSingle<double>(CombineDoubleAndNull, CombineNullAndDouble);
			AddSingle<long>(CombineLongAndNull, CombineNullAndLong);
			AddSingle<decimal>(CombineDecimalAndNull, CombineNullAndDecimal);
			AddSingle(CombineTwoNulls);
		}

		private void AddSingle(CombinerFunc combinerAction)
		{
			_combinerActions[new TypeTuple(null, null)] = delegate(object x, object y, out object v)
			{
				return combinerAction(out v);
			};
		}

		private void AddSingle<T1>(CombinerFunc<T1> combinerAction, CombinerFunc<T1> switchedCombinerAction)
		{
			_combinerActions[new TypeTuple(typeof(T1), null)] = delegate(object x, object y, out object v)
			{
				return combinerAction((T1)x, out v);
			};
			_combinerActions[new TypeTuple(null, typeof(T1))] = delegate(object x, object y, out object v)
			{
				return switchedCombinerAction((T1)y, out v);
			};
		}

		private void AddSingle<T1, T2>(CombinerFunc<T1, T2> combinerAction)
		{
			_combinerActions[new TypeTuple(typeof(T1), typeof(T2))] = delegate(object x, object y, out object v)
			{
				return combinerAction((T1)x, (T2)y, out v);
			};
		}

		protected virtual object ForceToSimpleValueTypes(object input)
		{
			if (input is int)
			{
				return (long)(int)input;
			}
			if (input is short)
			{
				return (long)(short)input;
			}
			if (input is float)
			{
				return (double)(float)input;
			}
			return input;
		}

		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			List<object> list = steps.Select((IMvxSourceStep step) => step.GetValue()).ToList();
			while (list.Count > 1)
			{
				object obj = list[0];
				object obj2 = list[1];
				if (obj == MvxBindingConstant.DoNothing || obj2 == MvxBindingConstant.DoNothing)
				{
					value = MvxBindingConstant.DoNothing;
					return true;
				}
				if (obj == MvxBindingConstant.UnsetValue || obj2 == MvxBindingConstant.UnsetValue)
				{
					value = MvxBindingConstant.UnsetValue;
					return true;
				}
				obj = ForceToSimpleValueTypes(obj);
				obj2 = ForceToSimpleValueTypes(obj2);
				Type lookupTypeFor = GetLookupTypeFor(obj);
				Type lookupTypeFor2 = GetLookupTypeFor(obj2);
				if (!_combinerActions.TryGetValue(new TypeTuple(lookupTypeFor, lookupTypeFor2), out var value2))
				{
					Mvx.Error("Unknown type pair in Pairwise combiner {0}, {1}", lookupTypeFor, lookupTypeFor2);
					value = MvxBindingConstant.UnsetValue;
					return true;
				}
				if (!value2(obj, obj2, out var value3))
				{
					value = MvxBindingConstant.UnsetValue;
					return true;
				}
				list.RemoveAt(0);
				list[0] = value3;
			}
			value = list[0];
			return true;
		}

		protected abstract bool CombineObjectAndDouble(object input1, double input2, out object value);

		protected abstract bool CombineObjectAndLong(object input1, long input2, out object value);

		protected abstract bool CombineObjectAndObject(object object1, object object2, out object value);

		protected abstract bool CombineObjectAndDecimal(object input1, decimal input2, out object value);

		protected abstract bool CombineObjectAndNull(object input1, out object value);

		protected abstract bool CombineDoubleAndObject(double input1, object input2, out object value);

		protected abstract bool CombineDoubleAndDouble(double input1, double input2, out object value);

		protected abstract bool CombineDoubleAndLong(double input1, long input2, out object value);

		protected abstract bool CombineDoubleAndDecimal(double input1, decimal input2, out object value);

		protected abstract bool CombineDoubleAndNull(double input1, out object value);

		protected abstract bool CombineLongAndObject(long input1, object input2, out object value);

		protected abstract bool CombineLongAndDouble(long input1, double input2, out object value);

		protected abstract bool CombineLongAndLong(long input1, long input2, out object value);

		protected abstract bool CombineLongAndDecimal(long input1, decimal input2, out object value);

		protected abstract bool CombineLongAndNull(long input1, out object value);

		protected abstract bool CombineDecimalAndDouble(decimal input1, double input2, out object value);

		protected abstract bool CombineDecimalAndLong(decimal input1, long input2, out object value);

		protected abstract bool CombineDecimalAndObject(decimal object1, object object2, out object value);

		protected abstract bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value);

		protected abstract bool CombineDecimalAndNull(decimal input1, out object value);

		protected abstract bool CombineNullAndObject(object object1, out object value);

		protected abstract bool CombineNullAndDouble(double input2, out object value);

		protected abstract bool CombineNullAndLong(long input2, out object value);

		protected abstract bool CombineNullAndDecimal(decimal input2, out object value);

		protected abstract bool CombineTwoNulls(out object value);
	}
	public class MvxSubtractValueCombiner : MvxNumericOnlyValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 - input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 - input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 - (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 - (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 - input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 - (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 - input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 - input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 - input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = -input2;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0 - input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = -input2;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = null;
			return true;
		}
	}
	public abstract class MvxValueCombiner : IMvxValueCombiner
	{
		public virtual Type SourceType(IEnumerable<IMvxSourceStep> steps)
		{
			return typeof(object);
		}

		public virtual void SetValue(IEnumerable<IMvxSourceStep> steps, object value)
		{
		}

		public virtual bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			value = null;
			return false;
		}

		public virtual IEnumerable<Type> SubStepTargetTypes(IEnumerable<IMvxSourceStep> subSteps, Type overallTargetType)
		{
			return subSteps.Select((IMvxSourceStep x) => typeof(object));
		}
	}
	public class MvxValueCombinerRegistry : MvxNamedInstanceRegistry<IMvxValueCombiner>, IMvxValueCombinerLookup, IMvxNamedInstanceLookup<IMvxValueCombiner>, IMvxValueCombinerRegistry, IMvxNamedInstanceRegistry<IMvxValueCombiner>
	{
	}
	public class MvxValueCombinerRegistryFiller : MvxNamedInstanceRegistryFiller<IMvxValueCombiner>, IMvxValueCombinerRegistryFiller, IMvxNamedInstanceRegistryFiller<IMvxValueCombiner>
	{
		protected override string FindName(Type type)
		{
			return MvxNamedInstanceRegistryFiller<IMvxValueCombiner>.RemoveTail(MvxNamedInstanceRegistryFiller<IMvxValueCombiner>.RemoveTail(base.FindName(type), "ValueCombiner"), "Combiner");
		}
	}
	[MvxUnconventional]
	public class MvxValueConverterValueCombiner : MvxValueCombiner
	{
		private readonly IMvxValueConverter _valueConverter;

		private Type _targetType = typeof(object);

		public MvxValueConverterValueCombiner(IMvxValueConverter valueConverter)
		{
			_valueConverter = valueConverter;
		}

		public override void SetValue(IEnumerable<IMvxSourceStep> steps, object value)
		{
			IMvxSourceStep mvxSourceStep = steps.First();
			object parameterValue = GetParameterValue(steps);
			if (_valueConverter != null)
			{
				object value2 = _valueConverter.ConvertBack(value, mvxSourceStep.SourceType, parameterValue, CultureInfo.CurrentUICulture);
				mvxSourceStep.SetValue(value2);
			}
		}

		public override IEnumerable<Type> SubStepTargetTypes(IEnumerable<IMvxSourceStep> subSteps, Type overallTargetType)
		{
			_targetType = overallTargetType;
			return base.SubStepTargetTypes(subSteps, overallTargetType);
		}

		private static object GetParameterValue(IEnumerable<IMvxSourceStep> steps)
		{
			IMvxSourceStep mvxSourceStep = steps.Skip(1).FirstOrDefault();
			object result = null;
			if (mvxSourceStep != null)
			{
				result = mvxSourceStep.GetValue();
			}
			return result;
		}

		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			IMvxSourceStep mvxSourceStep = steps.First();
			object parameterValue = GetParameterValue(steps);
			object value2 = mvxSourceStep.GetValue();
			if (value2 == MvxBindingConstant.DoNothing)
			{
				value = MvxBindingConstant.DoNothing;
				return true;
			}
			if (value2 == MvxBindingConstant.UnsetValue)
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			if (_valueConverter == null)
			{
				value = MvxBindingConstant.UnsetValue;
				return true;
			}
			value = _valueConverter.Convert(value2, _targetType, parameterValue, CultureInfo.CurrentUICulture);
			return true;
		}
	}
	public class MvxAndValueCombiner : MvxBooleanValueCombiner
	{
		protected override bool TryCombine(List<bool> stepValues, out object value)
		{
			value = stepValues.All((bool x) => x);
			return true;
		}
	}
	public class MvxOrValueCombiner : MvxBooleanValueCombiner
	{
		protected override bool TryCombine(List<bool> stepValues, out object value)
		{
			value = stepValues.Any((bool x) => x);
			return true;
		}
	}
	public class MvxNotValueCombiner : MvxBooleanValueCombiner
	{
		protected override bool TryCombine(List<bool> stepValues, out object value)
		{
			value = stepValues.All((bool x) => !x);
			return true;
		}
	}
	public class MvxXorValueCombiner : MvxBooleanValueCombiner
	{
		protected override bool TryCombine(List<bool> stepValues, out object value)
		{
			value = stepValues.Any((bool x) => !x) && stepValues.Any((bool x) => x);
			return true;
		}
	}
	public abstract class MvxBooleanValueCombiner : MvxValueCombiner
	{
		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			List<bool> list = new List<bool>();
			foreach (IMvxSourceStep step in steps)
			{
				object value2 = step.GetValue();
				if (value2 == MvxBindingConstant.DoNothing)
				{
					value = MvxBindingConstant.DoNothing;
					return true;
				}
				if (value2 == MvxBindingConstant.UnsetValue)
				{
					value = MvxBindingConstant.UnsetValue;
					return true;
				}
				if (!TryConvertToBool(value2, out var booleanValue))
				{
					value = MvxBindingConstant.UnsetValue;
					return true;
				}
				list.Add(booleanValue);
			}
			return TryCombine(list, out value);
		}

		protected abstract bool TryCombine(List<bool> stepValues, out object value);

		protected virtual bool TryConvertToBool(object objectValue, out bool booleanValue)
		{
			booleanValue = objectValue.ConvertToBoolean();
			return true;
		}
	}
	public class MvxEqualToValueCombiner : MvxPairwiseValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 == input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 == input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 == (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1 == 0m;
			return true;
		}

		protected override bool CombineDecimalAndObject(decimal object1, object object2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 == (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 == input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 == (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1 == 0.0;
			return true;
		}

		protected override bool CombineDoubleAndObject(double double1, object object1, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 == input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 == input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 == input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1 == 0;
			return true;
		}

		protected override bool CombineLongAndObject(long int1, object object1, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = 0m == input2;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0 == input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = input2 == 0;
			return true;
		}

		protected override bool CombineNullAndObject(object object1, out object value)
		{
			value = object1.Equals(null);
			return true;
		}

		protected override bool CombineObjectAndDecimal(object input1, decimal input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineObjectAndDouble(object input1, double input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineObjectAndLong(object input1, long input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineObjectAndNull(object input1, out object value)
		{
			value = input1.Equals(null);
			return true;
		}

		protected override bool CombineObjectAndObject(object object1, object object2, out object value)
		{
			value = object1.Equals(object2);
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = true;
			return true;
		}
	}
	public class MvxGreaterThanOrEqualToValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1.CompareTo(0.0) >= 0;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1.CompareTo(0L) >= 0;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0L.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineNullAndString(string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1.CompareTo((double)input2) >= 0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = input1.CompareTo((long)input2) >= 0;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1.CompareTo(input2) >= 0;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1.CompareTo(0m) >= 0;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			decimal num = 0m;
			value = num.CompareTo(input2) >= 0;
			return true;
		}
	}
	public class MvxGreaterThanValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1.CompareTo(0.0) > 0;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1.CompareTo(0L) > 0;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0L.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineNullAndString(string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1.CompareTo((double)input2) > 0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = input1.CompareTo((long)input2) > 0;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1.CompareTo(input2) > 0;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1.CompareTo(0m) > 0;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			decimal num = 0m;
			value = (decimal)num.CompareTo(input2) > input2;
			return true;
		}
	}
	public class MvxLessThanOrEqualToValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1.CompareTo(0.0) <= 0;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1.CompareTo(0L) <= 0;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0L.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineNullAndString(string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1.CompareTo((double)input2) <= 0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = input1.CompareTo((long)input2) <= 0;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1.CompareTo(input2) <= 0;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1.CompareTo(0m) <= 0;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			decimal num = 0m;
			value = num.CompareTo(input2) <= 0;
			return true;
		}
	}
	public class MvxLessThanValueCombiner : MvxObjectAsStringPairwiseValueCombiner
	{
		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1.CompareTo(0.0) < 0;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1.CompareTo(0L) < 0;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = 0L.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndString(string input1, string input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineLongAndString(long input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndString(double input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineNullAndString(string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDouble(string input1, double input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndLong(string input1, long input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndNull(string input1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineDecimalAndString(decimal input1, string input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineStringAndDecimal(string input1, decimal input2, out object value)
		{
			value = false;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1.CompareTo((double)input2) < 0;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = input1.CompareTo((long)input2) < 0;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = ((double)input1).CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1.CompareTo(input2) < 0;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1.CompareTo(0m) < 0;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			decimal num = 0m;
			value = (decimal)num.CompareTo(input2) < input2;
			return true;
		}
	}
	public class MvxNotEqualToValueCombiner : MvxPairwiseValueCombiner
	{
		protected override bool CombineDecimalAndDecimal(decimal input1, decimal input2, out object value)
		{
			value = input1 != input2;
			return true;
		}

		protected override bool CombineDecimalAndDouble(decimal input1, double input2, out object value)
		{
			value = (double)input1 != input2;
			return true;
		}

		protected override bool CombineDecimalAndLong(decimal input1, long input2, out object value)
		{
			value = input1 != (decimal)input2;
			return true;
		}

		protected override bool CombineDecimalAndNull(decimal input1, out object value)
		{
			value = input1 != 0m;
			return true;
		}

		protected override bool CombineDecimalAndObject(decimal object1, object object2, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineDoubleAndDecimal(double input1, decimal input2, out object value)
		{
			value = input1 != (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndDouble(double input1, double input2, out object value)
		{
			value = input1 != input2;
			return true;
		}

		protected override bool CombineDoubleAndLong(double input1, long input2, out object value)
		{
			value = input1 != (double)input2;
			return true;
		}

		protected override bool CombineDoubleAndNull(double input1, out object value)
		{
			value = input1 != 0.0;
			return true;
		}

		protected override bool CombineDoubleAndObject(double double1, object object1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineLongAndDecimal(long input1, decimal input2, out object value)
		{
			value = (decimal)input1 != input2;
			return true;
		}

		protected override bool CombineLongAndDouble(long input1, double input2, out object value)
		{
			value = (double)input1 != input2;
			return true;
		}

		protected override bool CombineLongAndLong(long input1, long input2, out object value)
		{
			value = input1 != input2;
			return true;
		}

		protected override bool CombineLongAndNull(long input1, out object value)
		{
			value = input1 != 0;
			return true;
		}

		protected override bool CombineLongAndObject(long int1, object object1, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineNullAndDecimal(decimal input2, out object value)
		{
			value = 0m != input2;
			return true;
		}

		protected override bool CombineNullAndDouble(double input2, out object value)
		{
			value = 0.0 != input2;
			return true;
		}

		protected override bool CombineNullAndLong(long input2, out object value)
		{
			value = input2 != 0;
			return true;
		}

		protected override bool CombineNullAndObject(object object1, out object value)
		{
			value = !object1.Equals(null);
			return true;
		}

		protected override bool CombineObjectAndDecimal(object input1, decimal input2, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineObjectAndDouble(object input1, double input2, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineObjectAndLong(object input1, long input2, out object value)
		{
			value = true;
			return true;
		}

		protected override bool CombineObjectAndNull(object input1, out object value)
		{
			value = !input1.Equals(null);
			return true;
		}

		protected override bool CombineObjectAndObject(object object1, object object2, out object value)
		{
			value = !object1.Equals(object2);
			return true;
		}

		protected override bool CombineTwoNulls(out object value)
		{
			value = false;
			return true;
		}
	}
}
namespace MvvmCross.Binding.Bindings
{
	public static class MvxBindingModeExtensionMethods
	{
		public static MvxBindingMode IfDefault(this MvxBindingMode bindingMode, MvxBindingMode modeIfDefault)
		{
			if (bindingMode == MvxBindingMode.Default)
			{
				return modeIfDefault;
			}
			return bindingMode;
		}

		public static bool RequireSourceObservation(this MvxBindingMode bindingMode)
		{
			switch (bindingMode)
			{
			case MvxBindingMode.Default:
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Mode of default seen for binding - assuming OneWay");
				return true;
			case MvxBindingMode.TwoWay:
			case MvxBindingMode.OneWay:
				return true;
			case MvxBindingMode.OneTime:
			case MvxBindingMode.OneWayToSource:
				return false;
			default:
				throw new MvxException("Unexpected ActualBindingMode");
			}
		}

		public static bool RequiresTargetObservation(this MvxBindingMode bindingMode)
		{
			switch (bindingMode)
			{
			case MvxBindingMode.Default:
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Mode of default seen for binding - assuming OneWay");
				return true;
			case MvxBindingMode.OneWay:
			case MvxBindingMode.OneTime:
				return false;
			case MvxBindingMode.TwoWay:
			case MvxBindingMode.OneWayToSource:
				return true;
			default:
				throw new MvxException("Unexpected ActualBindingMode");
			}
		}

		public static bool RequireTargetUpdateOnFirstBind(this MvxBindingMode bindingMode)
		{
			switch (bindingMode)
			{
			case MvxBindingMode.Default:
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Mode of default seen for binding - assuming OneWay");
				return true;
			case MvxBindingMode.TwoWay:
			case MvxBindingMode.OneWay:
			case MvxBindingMode.OneTime:
				return true;
			case MvxBindingMode.OneWayToSource:
				return false;
			default:
				throw new MvxException("Unexpected ActualBindingMode");
			}
		}
	}
	public class MvxFullBinding : MvxBinding, IMvxUpdateableBinding, IMvxBinding, IDisposable
	{
		private readonly MvxBindingDescription _bindingDescription;

		private IMvxSourceStep _sourceStep;

		private IMvxTargetBinding _targetBinding;

		private readonly object _targetLocker = new object();

		private object _dataContext;

		private EventHandler _sourceBindingOnChanged;

		private EventHandler<MvxTargetChangedEventArgs> _targetBindingOnValueChanged;

		private object _defaultTargetValue;

		private CancellationTokenSource _cancelSource = new CancellationTokenSource();

		private IMvxSourceStepFactory SourceStepFactory => MvxSingleton<IMvxBindingSingletonCache>.Instance.SourceStepFactory;

		private IMvxTargetBindingFactory TargetBindingFactory => MvxSingleton<IMvxBindingSingletonCache>.Instance.TargetBindingFactory;

		private IMvxMainThreadDispatcher dispatcher => MvxSingleton<IMvxBindingSingletonCache>.Instance.MainThreadDispatcher;

		public object DataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				if (_dataContext != value)
				{
					_dataContext = value;
					if (_sourceStep != null)
					{
						_sourceStep.DataContext = value;
					}
					UpdateTargetOnBind();
				}
			}
		}

		protected bool NeedToObserveSourceChanges => ActualBindingMode.RequireSourceObservation();

		protected bool NeedToObserveTargetChanges => ActualBindingMode.RequiresTargetObservation();

		protected bool NeedToUpdateTargetOnBind => ActualBindingMode.RequireTargetUpdateOnFirstBind();

		protected MvxBindingMode ActualBindingMode
		{
			get
			{
				MvxBindingMode mvxBindingMode = _bindingDescription.Mode;
				if (mvxBindingMode == MvxBindingMode.Default)
				{
					mvxBindingMode = _targetBinding.DefaultMode;
				}
				return mvxBindingMode;
			}
		}

		public MvxFullBinding(MvxBindingRequest bindingRequest)
		{
			_bindingDescription = bindingRequest.Description;
			CreateTargetBinding(bindingRequest.Target);
			CreateSourceBinding(bindingRequest.Source);
		}

		protected virtual void ClearSourceBinding()
		{
			if (_sourceStep != null)
			{
				if (_sourceBindingOnChanged != null)
				{
					_sourceStep.Changed -= _sourceBindingOnChanged;
					_sourceBindingOnChanged = null;
				}
				_sourceStep.Dispose();
				_sourceStep = null;
			}
		}

		private void CreateSourceBinding(object source)
		{
			_dataContext = source;
			_sourceStep = SourceStepFactory.Create(_bindingDescription.Source);
			_sourceStep.TargetType = _targetBinding.TargetType;
			_sourceStep.DataContext = source;
			if (NeedToObserveSourceChanges)
			{
				_sourceBindingOnChanged = delegate
				{
					CancellationToken token = _cancelSource.Token;
					object value = _sourceStep.GetValue();
					UpdateTargetFromSource(value, token);
				};
				_sourceStep.Changed += _sourceBindingOnChanged;
			}
			UpdateTargetOnBind();
		}

		private void UpdateTargetOnBind()
		{
			if (NeedToUpdateTargetOnBind && _sourceStep != null)
			{
				_cancelSource.Cancel();
				_cancelSource = new CancellationTokenSource();
				CancellationToken token = _cancelSource.Token;
				try
				{
					object value = _sourceStep.GetValue();
					UpdateTargetFromSource(value, token);
				}
				catch (Exception exception)
				{
					MvxBindingTrace.Trace("Exception masked in UpdateTargetOnBind {0}", exception.ToLongString());
				}
			}
		}

		protected virtual void ClearTargetBinding()
		{
			lock (_targetLocker)
			{
				if (_targetBinding != null)
				{
					if (_targetBindingOnValueChanged != null)
					{
						_targetBinding.ValueChanged -= _targetBindingOnValueChanged;
						_targetBindingOnValueChanged = null;
					}
					_targetBinding.Dispose();
					_targetBinding = null;
				}
			}
		}

		private void CreateTargetBinding(object target)
		{
			_targetBinding = TargetBindingFactory.CreateBinding(target, _bindingDescription.TargetName);
			if (_targetBinding == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Failed to create target binding for {0}", _bindingDescription.ToString());
				_targetBinding = new MvxNullTargetBinding();
			}
			if (NeedToObserveTargetChanges)
			{
				_targetBinding.SubscribeToEvents();
				_targetBindingOnValueChanged = delegate(object sender, MvxTargetChangedEventArgs args)
				{
					UpdateSourceFromTarget(args.Value);
				};
				_targetBinding.ValueChanged += _targetBindingOnValueChanged;
			}
			_defaultTargetValue = _targetBinding.TargetType.CreateDefault();
		}

		private void UpdateTargetFromSource(object value, CancellationToken cancel)
		{
			if (value == MvxBindingConstant.DoNothing || cancel.IsCancellationRequested)
			{
				return;
			}
			if (value == MvxBindingConstant.UnsetValue)
			{
				value = _defaultTargetValue;
			}
			dispatcher.RequestMainThreadAction(delegate
			{
				if (cancel.IsCancellationRequested)
				{
					return;
				}
				try
				{
					lock (_targetLocker)
					{
						_targetBinding?.SetValue(value);
					}
				}
				catch (Exception exception)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Error, "Problem seen during binding execution for {0} - problem {1}", _bindingDescription.ToString(), exception.ToLongString());
				}
			});
		}

		private void UpdateSourceFromTarget(object value)
		{
			if (value == MvxBindingConstant.DoNothing || value == MvxBindingConstant.UnsetValue)
			{
				return;
			}
			try
			{
				_sourceStep.SetValue(value);
			}
			catch (Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Problem seen during binding execution for {0} - problem {1}", _bindingDescription.ToString(), exception.ToLongString());
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				ClearTargetBinding();
				ClearSourceBinding();
			}
		}
	}
	public abstract class MvxBinding : IMvxBinding, IDisposable
	{
		~MvxBinding()
		{
			Dispose(isDisposing: false);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
		}
	}
	public class MvxCompositeBinding : MvxBinding
	{
		private readonly List<IMvxBinding> _bindings;

		public MvxCompositeBinding(params IMvxBinding[] args)
		{
			_bindings = args.ToList();
		}

		public void Add(params IMvxBinding[] args)
		{
			_bindings.AddRange(args);
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				foreach (IMvxBinding binding in _bindings)
				{
					binding.Dispose();
				}
				_bindings.Clear();
			}
			base.Dispose(isDisposing);
		}
	}
	public interface IMvxBinding : IDisposable
	{
	}
	public interface IMvxUpdateableBinding : IMvxBinding, IDisposable
	{
		object DataContext { get; set; }
	}
	public class MvxBindingDescription
	{
		public string TargetName { get; set; }

		public MvxBindingMode Mode { get; set; }

		public MvxSourceStepDescription Source { get; set; }

		public MvxBindingDescription()
		{
		}

		public MvxBindingDescription(string targetName, string sourcePropertyPath, IMvxValueConverter converter, object converterParameter, object fallbackValue, MvxBindingMode mode)
		{
			TargetName = targetName;
			Mode = mode;
			Source = new MvxPathSourceStepDescription
			{
				SourcePropertyPath = sourcePropertyPath,
				Converter = converter,
				ConverterParameter = converterParameter,
				FallbackValue = fallbackValue
			};
		}

		public override string ToString()
		{
			return string.Format("binding {0} for {1}", new object[2]
			{
				TargetName,
				(Source == null) ? "-null" : Source.ToString()
			});
		}
	}
}
namespace MvvmCross.Binding.Bindings.Target
{
	public abstract class MvxConvertingTargetBinding : MvxTargetBinding
	{
		private bool _isUpdatingSource;

		private bool _isUpdatingTarget;

		private object _updatingSourceWith;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		protected MvxConvertingTargetBinding(object target)
			: base(target)
		{
		}

		protected abstract void SetValueImpl(object target, object value);

		public override void SetValue(object value)
		{
			MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Receiving SetValue to " + (value ?? ""));
			object target = base.Target;
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Weak Target is null in {0} - skipping set", GetType().Name);
			}
			else
			{
				if (ShouldSkipSetValueForPlatformSpecificReasons(target, value) || ShouldSkipSetValueForViewSpecificReasons(target, value))
				{
					return;
				}
				object obj = MakeSafeValue(value);
				if (_isUpdatingSource)
				{
					if (obj == null)
					{
						if (_updatingSourceWith == null)
						{
							return;
						}
					}
					else if (obj.Equals(_updatingSourceWith))
					{
						return;
					}
				}
				try
				{
					_isUpdatingTarget = true;
					SetValueImpl(target, obj);
				}
				finally
				{
					_isUpdatingTarget = false;
				}
			}
		}

		protected virtual bool ShouldSkipSetValueForViewSpecificReasons(object target, object value)
		{
			return false;
		}

		protected virtual bool ShouldSkipSetValueForPlatformSpecificReasons(object target, object value)
		{
			return false;
		}

		protected virtual object MakeSafeValue(object value)
		{
			return TargetType.MakeSafeValue(value);
		}

		protected sealed override void FireValueChanged(object newValue)
		{
			if (_isUpdatingTarget || _isUpdatingSource)
			{
				return;
			}
			MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Firing changed to " + (newValue ?? ""));
			try
			{
				_isUpdatingSource = true;
				_updatingSourceWith = newValue;
				base.FireValueChanged(newValue);
			}
			finally
			{
				_isUpdatingSource = false;
				_updatingSourceWith = null;
			}
		}
	}
	public class MvxWithEventPropertyInfoTargetBinding : MvxPropertyInfoTargetBinding
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxWithEventPropertyInfoTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - target is null in MvxWithEventPropertyInfoTargetBinding");
			}
		}

		public void OnValueChanged(object sender, EventArgs eventArgs)
		{
			object target = base.Target;
			if (target == null)
			{
				MvxBindingTrace.Trace("Null weak reference target seen during OnValueChanged - unusual as usually Target is the sender of the value changed. Ignoring the value changed");
				return;
			}
			object newValue = ReflectionExtensions.GetGetMethod(base.TargetPropertyInfo).Invoke(target, null);
			FireValueChanged(newValue);
		}

		public override void SubscribeToEvents()
		{
			object target = base.Target;
			if (target == null)
			{
				return;
			}
			Type type = target.GetType();
			string text = base.TargetPropertyInfo.Name + "Changed";
			EventInfo eventInfo = ReflectionExtensions.GetEvent(type, text);
			if ((object)eventInfo != null)
			{
				if ((object)eventInfo.EventHandlerType != typeof(EventHandler))
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Diagnostic - cannot two-way bind to {0}/{1} on type {2} because eventHandler is type {3}", type, text, target.GetType().Name, eventInfo.EventHandlerType.Name);
				}
				else
				{
					_subscription = eventInfo.WeakSubscribe(target, OnValueChanged);
				}
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing && _subscription != null)
			{
				_subscription.Dispose();
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public abstract class MvxTargetBinding : MvxBinding, IMvxTargetBinding, IMvxBinding, IDisposable
	{
		private readonly WeakReference _target;

		protected object Target => _target.Target;

		public abstract Type TargetType { get; }

		public abstract MvxBindingMode DefaultMode { get; }

		public event EventHandler<MvxTargetChangedEventArgs> ValueChanged;

		protected MvxTargetBinding(object target)
		{
			_target = new WeakReference(target);
		}

		public virtual void SubscribeToEvents()
		{
		}

		protected virtual void FireValueChanged(object newValue)
		{
			this.ValueChanged?.Invoke(this, new MvxTargetChangedEventArgs(newValue));
		}

		public abstract void SetValue(object value);
	}
	public class MvxEventHandlerEventInfoTargetBinding : MvxTargetBinding
	{
		private readonly EventInfo _targetEventInfo;

		private ICommand _currentCommand;

		private readonly object _eventHandler;

		public override Type TargetType => typeof(ICommand);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public MvxEventHandlerEventInfoTargetBinding(object target, EventInfo targetEventInfo)
			: base(target)
		{
			_targetEventInfo = targetEventInfo;
			MethodInfo addMethod = ReflectionExtensions.GetAddMethod(_targetEventInfo);
			_eventHandler = new EventHandler(HandleEvent);
			addMethod.Invoke(target, new object[1] { _eventHandler });
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				object target = base.Target;
				if (target != null)
				{
					ReflectionExtensions.GetRemoveMethod(_targetEventInfo).Invoke(target, new object[1] { _eventHandler });
				}
			}
			base.Dispose(isDisposing);
		}

		private void HandleEvent(object sender, EventArgs args)
		{
			_currentCommand?.Execute(null);
		}

		public override void SetValue(object value)
		{
			ICommand currentCommand = value as ICommand;
			_currentCommand = currentCommand;
		}
	}
	public class MvxEventInfoTargetBinding<T> : MvxTargetBinding where T : EventArgs
	{
		private readonly EventInfo _targetEventInfo;

		private ICommand _currentCommand;

		public override Type TargetType => typeof(ICommand);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public MvxEventInfoTargetBinding(object target, EventInfo targetEventInfo)
			: base(target)
		{
			_targetEventInfo = targetEventInfo;
			ReflectionExtensions.GetAddMethod(_targetEventInfo).Invoke(target, new object[1]
			{
				new EventHandler<T>(HandleEvent)
			});
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				object target = base.Target;
				if (target != null)
				{
					ReflectionExtensions.GetRemoveMethod(_targetEventInfo).Invoke(target, new object[1]
					{
						new EventHandler<T>(HandleEvent)
					});
				}
			}
			base.Dispose(isDisposing);
		}

		private void HandleEvent(object sender, T args)
		{
			_currentCommand?.Execute(null);
		}

		public override void SetValue(object value)
		{
			ICommand currentCommand = value as ICommand;
			_currentCommand = currentCommand;
		}
	}
	public class MvxNullTargetBinding : MvxTargetBinding
	{
		public override MvxBindingMode DefaultMode => MvxBindingMode.OneTime;

		public override Type TargetType => typeof(object);

		public MvxNullTargetBinding()
			: base(null)
		{
		}

		public override void SetValue(object value)
		{
		}
	}
	public class MvxPropertyInfoTargetBinding : MvxConvertingTargetBinding
	{
		private readonly PropertyInfo _targetPropertyInfo;

		public override Type TargetType => TargetPropertyInfo.PropertyType;

		protected PropertyInfo TargetPropertyInfo => _targetPropertyInfo;

		public MvxPropertyInfoTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target)
		{
			_targetPropertyInfo = targetPropertyInfo;
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing && TargetPropertyInfo.GetCustomAttribute<MvxSetToNullAfterBindingAttribute>(inherit: true) != null)
			{
				SetValue(null);
			}
			base.Dispose(isDisposing);
		}

		protected override void SetValueImpl(object target, object value)
		{
			ReflectionExtensions.GetSetMethod(TargetPropertyInfo).Invoke(target, new object[1] { value });
		}
	}
	public class MvxPropertyInfoTargetBinding<T> : MvxPropertyInfoTargetBinding where T : class
	{
		protected T View => base.Target as T;

		public MvxPropertyInfoTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}
	}
	public interface IMvxTargetBinding : IMvxBinding, IDisposable
	{
		Type TargetType { get; }

		MvxBindingMode DefaultMode { get; }

		event EventHandler<MvxTargetChangedEventArgs> ValueChanged;

		void SetValue(object value);

		void SubscribeToEvents();
	}
	public class MvxTargetChangedEventArgs : EventArgs
	{
		public object Value { get; private set; }

		public MvxTargetChangedEventArgs(object value)
		{
			Value = value;
		}
	}
}
namespace MvvmCross.Binding.Bindings.Target.Construction
{
	public static class MvxTargetBindingFactoryRegistryExtensions
	{
		public static void RegisterCustomBindingFactory<TView>(this IMvxTargetBindingFactoryRegistry registry, string customName, Func<TView, IMvxTargetBinding> creator) where TView : class
		{
			registry.RegisterFactory(new MvxCustomBindingFactory<TView>(customName, creator));
		}

		public static void RegisterPropertyInfoBindingFactory(this IMvxTargetBindingFactoryRegistry registry, Type bindingType, Type targetType, string targetName)
		{
			registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(bindingType, targetType, targetName));
		}
	}
	public class MvxCustomBindingFactory<TTarget> : IMvxPluginTargetBindingFactory, IMvxTargetBindingFactory where TTarget : class
	{
		private readonly Func<TTarget, IMvxTargetBinding> _targetBindingCreator;

		private readonly string _targetFakePropertyName;

		public IEnumerable<MvxTypeAndNamePair> SupportedTypes => new MvxTypeAndNamePair[1]
		{
			new MvxTypeAndNamePair(typeof(TTarget), _targetFakePropertyName)
		};

		public MvxCustomBindingFactory(string targetFakePropertyName, Func<TTarget, IMvxTargetBinding> targetBindingCreator)
		{
			_targetFakePropertyName = targetFakePropertyName;
			_targetBindingCreator = targetBindingCreator;
		}

		public IMvxTargetBinding CreateBinding(object target, string targetName)
		{
			if (!(target is TTarget arg))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Passed an invalid target for MvxCustomBindingFactory");
				return null;
			}
			return _targetBindingCreator(arg);
		}
	}
	public class MvxPropertyInfoTargetBindingFactory : IMvxPluginTargetBindingFactory, IMvxTargetBindingFactory
	{
		private readonly Func<object, PropertyInfo, IMvxTargetBinding> _bindingCreator;

		private readonly string _targetName;

		private readonly Type _targetType;

		protected Type TargetType => _targetType;

		public IEnumerable<MvxTypeAndNamePair> SupportedTypes => new MvxTypeAndNamePair[1]
		{
			new MvxTypeAndNamePair
			{
				Name = _targetName,
				Type = _targetType
			}
		};

		public MvxPropertyInfoTargetBindingFactory(Type targetType, string targetName, Func<object, PropertyInfo, IMvxTargetBinding> bindingCreator)
		{
			_targetType = targetType;
			_targetName = targetName;
			_bindingCreator = bindingCreator;
		}

		public IMvxTargetBinding CreateBinding(object target, string targetName)
		{
			PropertyInfo property = ReflectionExtensions.GetProperty(target.GetType(), targetName);
			if ((object)property != null)
			{
				try
				{
					return _bindingCreator(target, property);
				}
				catch (Exception ex)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Error, "Problem creating target binding for {0} - exception {1}", _targetType.Name, ex.ToString());
				}
			}
			return null;
		}
	}
	public class MvxSimplePropertyInfoTargetBindingFactory : IMvxPluginTargetBindingFactory, IMvxTargetBindingFactory
	{
		private readonly Type _bindingType;

		private readonly MvxPropertyInfoTargetBindingFactory _innerFactory;

		public IEnumerable<MvxTypeAndNamePair> SupportedTypes => _innerFactory.SupportedTypes;

		public MvxSimplePropertyInfoTargetBindingFactory(Type bindingType, Type targetType, string targetName)
		{
			_bindingType = bindingType;
			_innerFactory = new MvxPropertyInfoTargetBindingFactory(targetType, targetName, CreateTargetBinding);
		}

		public IMvxTargetBinding CreateBinding(object target, string targetName)
		{
			return _innerFactory.CreateBinding(target, targetName);
		}

		private IMvxTargetBinding CreateTargetBinding(object target, PropertyInfo targetPropertyInfo)
		{
			object obj = Activator.CreateInstance(_bindingType, target, targetPropertyInfo);
			IMvxTargetBinding mvxTargetBinding = obj as IMvxTargetBinding;
			if (mvxTargetBinding == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "The TargetBinding created did not support IMvxTargetBinding");
				(obj as IDisposable)?.Dispose();
			}
			return mvxTargetBinding;
		}
	}
	public class MvxTargetBindingFactoryRegistry : IMvxTargetBindingFactoryRegistry, IMvxTargetBindingFactory
	{
		private readonly Dictionary<string, IMvxPluginTargetBindingFactory> _lookups = new Dictionary<string, IMvxPluginTargetBindingFactory>();

		public virtual IMvxTargetBinding CreateBinding(object target, string targetName)
		{
			if (TryCreateSpecificFactoryBinding(target, targetName, out var binding))
			{
				return binding;
			}
			if (TryCreateReflectionBasedBinding(target, targetName, out binding))
			{
				return binding;
			}
			return null;
		}

		protected virtual bool TryCreateReflectionBasedBinding(object target, string targetName, out IMvxTargetBinding binding)
		{
			if (string.IsNullOrEmpty(targetName))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Empty binding target passed to MvxTargetBindingFactoryRegistry");
				binding = null;
				return false;
			}
			if (target == null)
			{
				binding = null;
				return false;
			}
			PropertyInfo property = ReflectionExtensions.GetProperty(target.GetType(), targetName);
			if ((object)property != null && property.CanWrite)
			{
				binding = new MvxWithEventPropertyInfoTargetBinding(target, property);
				return true;
			}
			EventInfo eventInfo = ReflectionExtensions.GetEvent(target.GetType(), targetName);
			if ((object)eventInfo != null && (object)eventInfo.EventHandlerType == typeof(EventHandler))
			{
				binding = new MvxEventHandlerEventInfoTargetBinding(target, eventInfo);
				return true;
			}
			binding = null;
			return false;
		}

		protected virtual bool TryCreateSpecificFactoryBinding(object target, string targetName, out IMvxTargetBinding binding)
		{
			if (target == null)
			{
				binding = null;
				return false;
			}
			IMvxPluginTargetBindingFactory mvxPluginTargetBindingFactory = FindSpecificFactory(target.GetType(), targetName);
			if (mvxPluginTargetBindingFactory != null)
			{
				binding = mvxPluginTargetBindingFactory.CreateBinding(target, targetName);
				return true;
			}
			binding = null;
			return false;
		}

		public void RegisterFactory(IMvxPluginTargetBindingFactory factory)
		{
			foreach (MvxTypeAndNamePair supportedType in factory.SupportedTypes)
			{
				string key = GenerateKey(supportedType.Type, supportedType.Name);
				_lookups[key] = factory;
			}
		}

		private static string GenerateKey(Type type, string name)
		{
			return string.Format("{0}:{1}", new object[2] { type.FullName, name });
		}

		private IMvxPluginTargetBindingFactory FindSpecificFactory(Type type, string name)
		{
			string key = GenerateKey(type, name);
			if (_lookups.TryGetValue(key, out var value))
			{
				return value;
			}
			Type baseType = type.GetTypeInfo().BaseType;
			if ((object)baseType != null)
			{
				value = FindSpecificFactory(baseType, name);
			}
			if (value != null)
			{
				return value;
			}
			foreach (Type implementedInterface in type.GetTypeInfo().ImplementedInterfaces)
			{
				value = FindSpecificFactory(implementedInterface, name);
				if (value != null)
				{
					return value;
				}
			}
			return null;
		}
	}
	public interface IMvxPluginTargetBindingFactory : IMvxTargetBindingFactory
	{
		IEnumerable<MvxTypeAndNamePair> SupportedTypes { get; }
	}
	public interface IMvxTargetBindingFactory
	{
		IMvxTargetBinding CreateBinding(object target, string targetName);
	}
	public interface IMvxTargetBindingFactoryRegistry : IMvxTargetBindingFactory
	{
		void RegisterFactory(IMvxPluginTargetBindingFactory factory);
	}
	public class MvxTypeAndNamePair
	{
		public Type Type { get; set; }

		public string Name { get; set; }

		public MvxTypeAndNamePair()
		{
		}

		public MvxTypeAndNamePair(Type type, string name)
		{
			Type = type;
			Name = name;
		}
	}
}
namespace MvvmCross.Binding.Bindings.Source
{
	public class MvxMissingSourceBinding : MvxSourceBinding
	{
		public override Type SourceType => typeof(object);

		public MvxMissingSourceBinding(object source)
			: base(source)
		{
		}

		public override void SetValue(object value)
		{
		}

		public override object GetValue()
		{
			return MvxBindingConstant.UnsetValue;
		}
	}
	public abstract class MvxPropertyInfoSourceBinding : MvxSourceBinding
	{
		private readonly PropertyInfo _propertyInfo;

		private readonly string _propertyName;

		private IDisposable _subscription;

		protected string PropertyName => _propertyName;

		protected string PropertyNameForChangedEvent
		{
			get
			{
				if (IsIndexedProperty)
				{
					return _propertyName + "[]";
				}
				return _propertyName;
			}
		}

		protected PropertyInfo PropertyInfo => _propertyInfo;

		protected bool IsIndexedProperty => _propertyInfo.GetIndexParameters().Any();

		protected MvxPropertyInfoSourceBinding(object source, PropertyInfo propertyInfo)
			: base(source)
		{
			_propertyInfo = propertyInfo;
			_propertyName = propertyInfo.Name;
			if (base.Source == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Unable to bind to source as it's null", _propertyName);
			}
			else if (base.Source is INotifyPropertyChanged source2)
			{
				_subscription = source2.WeakSubscribe(SourcePropertyChanged);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing && _subscription != null)
			{
				_subscription.Dispose();
				_subscription = null;
			}
		}

		public void SourcePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == PropertyNameForChangedEvent)
			{
				OnBoundPropertyChanged();
			}
		}

		protected abstract void OnBoundPropertyChanged();
	}
	public abstract class MvxSourceBinding : MvxBinding, IMvxSourceBinding, IMvxBinding, IDisposable
	{
		private readonly object _source;

		protected object Source => _source;

		public abstract Type SourceType { get; }

		public event EventHandler Changed;

		protected MvxSourceBinding(object source)
		{
			_source = source;
		}

		public abstract void SetValue(object value);

		public abstract object GetValue();

		protected void FireChanged()
		{
			this.Changed?.Invoke(this, EventArgs.Empty);
		}

		protected bool EqualsCurrentValue(object testValue)
		{
			object value = GetValue();
			if (testValue == null)
			{
				if (value == null)
				{
					return true;
				}
				return false;
			}
			return testValue.Equals(value);
		}
	}
	public interface IMvxSourceBinding : IMvxBinding, IDisposable
	{
		Type SourceType { get; }

		event EventHandler Changed;

		void SetValue(object value);

		object GetValue();
	}
	public class MvxSourcePropertyBindingEventArgs : EventArgs
	{
		private readonly object _value;

		public object Value => _value;

		public MvxSourcePropertyBindingEventArgs(object value)
		{
			_value = value;
		}

		public MvxSourcePropertyBindingEventArgs(IMvxSourceBinding propertySourceBinding)
		{
			_value = propertySourceBinding.GetValue();
		}
	}
}
namespace MvvmCross.Binding.Bindings.Source.Leaf
{
	public class MvxIndexerLeafPropertyInfoSourceBinding : MvxLeafPropertyInfoSourceBinding
	{
		private readonly object _key;

		public MvxIndexerLeafPropertyInfoSourceBinding(object source, PropertyInfo itemPropertyInfo, MvxIndexerPropertyToken indexToken)
			: base(source, itemPropertyInfo)
		{
			_key = indexToken.Key;
		}

		protected override object[] PropertyIndexParameters()
		{
			return new object[1] { _key };
		}
	}
	public class MvxSimpleLeafPropertyInfoSourceBinding : MvxLeafPropertyInfoSourceBinding
	{
		public MvxSimpleLeafPropertyInfoSourceBinding(object source, PropertyInfo propertyInfo)
			: base(source, propertyInfo)
		{
		}

		protected override object[] PropertyIndexParameters()
		{
			return null;
		}
	}
	public class MvxDirectToSourceBinding : MvxSourceBinding
	{
		public override Type SourceType
		{
			get
			{
				if (base.Source != null)
				{
					return base.Source.GetType();
				}
				return typeof(object);
			}
		}

		public MvxDirectToSourceBinding(object source)
			: base(source)
		{
		}

		public override void SetValue(object value)
		{
			MvxBindingTrace.Trace(MvxTraceLevel.Warning, "ToSource binding is not available for direct pathed source bindings");
		}

		public override object GetValue()
		{
			return base.Source;
		}
	}
	public abstract class MvxLeafPropertyInfoSourceBinding : MvxPropertyInfoSourceBinding
	{
		public override Type SourceType => base.PropertyInfo?.PropertyType;

		protected MvxLeafPropertyInfoSourceBinding(object source, PropertyInfo propertyInfo)
			: base(source, propertyInfo)
		{
		}

		protected override void OnBoundPropertyChanged()
		{
			FireChanged();
		}

		public override object GetValue()
		{
			if ((object)base.PropertyInfo == null)
			{
				return MvxBindingConstant.UnsetValue;
			}
			if (!base.PropertyInfo.CanRead)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "GetValue ignored in binding - target property is writeonly");
				return MvxBindingConstant.UnsetValue;
			}
			try
			{
				return base.PropertyInfo.GetValue(base.Source, PropertyIndexParameters());
			}
			catch (TargetInvocationException)
			{
				return MvxBindingConstant.UnsetValue;
			}
		}

		protected abstract object[] PropertyIndexParameters();

		public override void SetValue(object value)
		{
			if ((object)base.PropertyInfo == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "SetValue ignored in binding - source property {0} is missing", base.PropertyName);
				return;
			}
			if (!base.PropertyInfo.CanWrite)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "SetValue ignored in binding - target property is readonly");
				return;
			}
			try
			{
				object obj = base.PropertyInfo.PropertyType.MakeSafeValue(value);
				if (!EqualsCurrentValue(obj))
				{
					base.PropertyInfo.SetValue(base.Source, obj, PropertyIndexParameters());
				}
			}
			catch (Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "SetValue failed with exception - " + exception.ToLongString());
			}
		}
	}
}
namespace MvvmCross.Binding.Bindings.Source.Chained
{
	public class MvxIndexerChainedSourceBinding : MvxChainedSourceBinding
	{
		private readonly MvxIndexerPropertyToken _indexerPropertyToken;

		public MvxIndexerChainedSourceBinding(object source, PropertyInfo itemPropertyInfo, MvxIndexerPropertyToken indexerPropertyToken, IList<MvxPropertyToken> childTokens)
			: base(source, itemPropertyInfo, childTokens)
		{
			_indexerPropertyToken = indexerPropertyToken;
			UpdateChildBinding();
		}

		protected override object[] PropertyIndexParameters()
		{
			return new object[1] { _indexerPropertyToken.Key };
		}
	}
	public class MvxSimpleChainedSourceBinding : MvxChainedSourceBinding
	{
		public MvxSimpleChainedSourceBinding(object source, PropertyInfo propertyInfo, IList<MvxPropertyToken> childTokens)
			: base(source, propertyInfo, childTokens)
		{
			UpdateChildBinding();
		}

		protected override object[] PropertyIndexParameters()
		{
			return null;
		}
	}
	public abstract class MvxChainedSourceBinding : MvxPropertyInfoSourceBinding
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

		protected MvxChainedSourceBinding(object source, PropertyInfo propertyInfo, IList<MvxPropertyToken> childTokens)
			: base(source, propertyInfo)
		{
			_childTokens = childTokens;
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing && _currentChildBinding != null)
			{
				_currentChildBinding.Changed -= ChildSourceBindingChanged;
				_currentChildBinding.Dispose();
				_currentChildBinding = null;
			}
			base.Dispose(isDisposing);
		}

		protected void UpdateChildBinding()
		{
			if (_currentChildBinding != null)
			{
				_currentChildBinding.Changed -= ChildSourceBindingChanged;
				_currentChildBinding.Dispose();
				_currentChildBinding = null;
			}
			if ((object)base.PropertyInfo != null)
			{
				object value = base.PropertyInfo.GetValue(base.Source, PropertyIndexParameters());
				if (value != null)
				{
					_currentChildBinding = SourceBindingFactory.CreateBinding(value, _childTokens);
					_currentChildBinding.Changed += ChildSourceBindingChanged;
				}
			}
		}

		protected abstract object[] PropertyIndexParameters();

		private void ChildSourceBindingChanged(object sender, EventArgs e)
		{
			FireChanged();
		}

		protected override void OnBoundPropertyChanged()
		{
			UpdateChildBinding();
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
	}
}
namespace MvvmCross.Binding.Bindings.Source.Construction
{
	public interface IMvxSourceBindingFactoryExtension
	{
		bool TryCreateBinding(object source, MvxPropertyToken propertyToken, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result);
	}
	public interface IMvxSourceBindingFactoryExtensionHost
	{
		IList<IMvxSourceBindingFactoryExtension> Extensions { get; }
	}
	public class MvxPropertySourceBindingFactoryExtension : IMvxSourceBindingFactoryExtension
	{
		private static readonly ConcurrentDictionary<int, PropertyInfo> PropertyInfoCache = new ConcurrentDictionary<int, PropertyInfo>();

		public bool TryCreateBinding(object source, MvxPropertyToken currentToken, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result)
		{
			if (source == null)
			{
				result = null;
				return false;
			}
			IMvxSourceBinding mvxSourceBinding2;
			if (remainingTokens.Count != 0)
			{
				IMvxSourceBinding mvxSourceBinding = CreateChainedBinding(source, currentToken, remainingTokens);
				mvxSourceBinding2 = mvxSourceBinding;
			}
			else
			{
				mvxSourceBinding2 = CreateLeafBinding(source, currentToken);
			}
			result = mvxSourceBinding2;
			return result != null;
		}

		protected virtual MvxChainedSourceBinding CreateChainedBinding(object source, MvxPropertyToken propertyToken, List<MvxPropertyToken> remainingTokens)
		{
			if (propertyToken is MvxIndexerPropertyToken indexerPropertyToken)
			{
				PropertyInfo propertyInfo = FindPropertyInfo(source);
				if ((object)propertyInfo == null)
				{
					return null;
				}
				return new MvxIndexerChainedSourceBinding(source, propertyInfo, indexerPropertyToken, remainingTokens);
			}
			if (propertyToken is MvxPropertyNamePropertyToken mvxPropertyNamePropertyToken)
			{
				PropertyInfo propertyInfo2 = FindPropertyInfo(source, mvxPropertyNamePropertyToken.PropertyName);
				if ((object)propertyInfo2 == null)
				{
					return null;
				}
				return new MvxSimpleChainedSourceBinding(source, propertyInfo2, remainingTokens);
			}
			throw new MvxException("Unexpected property chaining - seen token type {0}", propertyToken.GetType().FullName);
		}

		protected virtual IMvxSourceBinding CreateLeafBinding(object source, MvxPropertyToken propertyToken)
		{
			if (propertyToken is MvxIndexerPropertyToken indexToken)
			{
				PropertyInfo propertyInfo = FindPropertyInfo(source);
				if ((object)propertyInfo == null)
				{
					return null;
				}
				return new MvxIndexerLeafPropertyInfoSourceBinding(source, propertyInfo, indexToken);
			}
			if (propertyToken is MvxPropertyNamePropertyToken mvxPropertyNamePropertyToken)
			{
				PropertyInfo propertyInfo2 = FindPropertyInfo(source, mvxPropertyNamePropertyToken.PropertyName);
				if ((object)propertyInfo2 == null)
				{
					return null;
				}
				return new MvxSimpleLeafPropertyInfoSourceBinding(source, propertyInfo2);
			}
			if (propertyToken is MvxEmptyPropertyToken)
			{
				return new MvxDirectToSourceBinding(source);
			}
			throw new MvxException("Unexpected property source - seen token type {0}", propertyToken.GetType().FullName);
		}

		protected PropertyInfo FindPropertyInfo(object source, string propertyName = "Item")
		{
			Type type = source.GetType();
			int hashCode = (type.FullName + "." + propertyName).GetHashCode();
			if (PropertyInfoCache.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			value = type.GetProperty(propertyName, MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public);
			if ((object)value == null)
			{
				value = type.GetProperty(propertyName, MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy);
			}
			PropertyInfoCache.TryAdd(hashCode, value);
			return value;
		}
	}
	public class MvxSourceBindingFactory : IMvxSourceBindingFactory, IMvxSourceBindingFactoryExtensionHost
	{
		private IMvxSourcePropertyPathParser _propertyPathParser;

		private readonly List<IMvxSourceBindingFactoryExtension> _extensions = new List<IMvxSourceBindingFactoryExtension>();

		protected IMvxSourcePropertyPathParser SourcePropertyPathParser => _propertyPathParser ?? (_propertyPathParser = Mvx.Resolve<IMvxSourcePropertyPathParser>());

		public IList<IMvxSourceBindingFactoryExtension> Extensions => _extensions;

		protected bool TryCreateBindingFromExtensions(object source, MvxPropertyToken propertyToken, List<MvxPropertyToken> remainingTokens, out IMvxSourceBinding result)
		{
			foreach (IMvxSourceBindingFactoryExtension extension in _extensions)
			{
				if (extension.TryCreateBinding(source, propertyToken, remainingTokens, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}

		public IMvxSourceBinding CreateBinding(object source, string combinedPropertyName)
		{
			IList<MvxPropertyToken> tokens = SourcePropertyPathParser.Parse(combinedPropertyName);
			return CreateBinding(source, tokens);
		}

		public IMvxSourceBinding CreateBinding(object source, IList<MvxPropertyToken> tokens)
		{
			if (tokens == null || tokens.Count == 0)
			{
				throw new MvxException("empty token list passed to CreateBinding");
			}
			MvxPropertyToken mvxPropertyToken = tokens[0];
			List<MvxPropertyToken> remainingTokens = tokens.Skip(1).ToList();
			if (TryCreateBindingFromExtensions(source, mvxPropertyToken, remainingTokens, out var result))
			{
				return result;
			}
			if (source != null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Unable to bind: source property source not found {0} on {1}", mvxPropertyToken, source.GetType().Name);
			}
			return new MvxMissingSourceBinding(source);
		}
	}
	public interface IMvxSourceBindingFactory
	{
		IMvxSourceBinding CreateBinding(object source, string combinedPropertyName);

		IMvxSourceBinding CreateBinding(object source, IList<MvxPropertyToken> tokens);
	}
}
namespace MvvmCross.Binding.Bindings.SourceSteps
{
	public interface IMvxSourceStep : IMvxBinding, IDisposable
	{
		Type TargetType { get; set; }

		Type SourceType { get; }

		object DataContext { get; set; }

		event EventHandler Changed;

		void SetValue(object value);

		object GetValue();
	}
	public interface IMvxSourceStepFactory
	{
		IMvxSourceStep Create(MvxSourceStepDescription description);
	}
	public interface IMvxSourceStepFactoryRegistry : IMvxSourceStepFactory
	{
		void AddOrOverwrite(Type type, IMvxSourceStepFactory factory);
	}
	public class MvxCombinerSourceStep : MvxSourceStep<MvxCombinerSourceStepDescription>
	{
		private readonly List<IMvxSourceStep> _subSteps;

		private bool _isSubscribeToChangedEvents;

		public override Type TargetType
		{
			get
			{
				return base.TargetType;
			}
			set
			{
				base.TargetType = value;
				SetSubTypeTargetTypes();
			}
		}

		public override Type SourceType => base.Description.Combiner.SourceType(_subSteps);

		public MvxCombinerSourceStep(MvxCombinerSourceStepDescription description)
			: base(description)
		{
			IMvxSourceStepFactory sourceStepFactory = MvxSingleton<IMvxBindingSingletonCache>.Instance.SourceStepFactory;
			_subSteps = description.InnerSteps.Select((MvxSourceStepDescription d) => sourceStepFactory.Create(d)).ToList();
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				UnsubscribeFromChangedEvents();
				foreach (IMvxSourceStep subStep in _subSteps)
				{
					subStep.Dispose();
				}
			}
			base.Dispose(isDisposing);
		}

		protected override void OnFirstChangeListenerAdded()
		{
			SubscribeToChangedEvents();
			base.OnFirstChangeListenerAdded();
		}

		private void SetSubTypeTargetTypes()
		{
			List<Type> list = base.Description.Combiner.SubStepTargetTypes(_subSteps, TargetType).ToList();
			if (list.Count != _subSteps.Count)
			{
				throw new MvxException("Description.Combiner provided incorrect length TargetType list");
			}
			for (int i = 0; i < list.Count; i++)
			{
				_subSteps[i].TargetType = list[i];
			}
		}

		private void SubscribeToChangedEvents()
		{
			if (_isSubscribeToChangedEvents)
			{
				return;
			}
			foreach (IMvxSourceStep subStep in _subSteps)
			{
				subStep.Changed += SubStepOnChanged;
			}
			_isSubscribeToChangedEvents = true;
		}

		protected override void OnLastChangeListenerRemoved()
		{
			UnsubscribeFromChangedEvents();
			base.OnLastChangeListenerRemoved();
		}

		private void UnsubscribeFromChangedEvents()
		{
			if (!_isSubscribeToChangedEvents)
			{
				return;
			}
			foreach (IMvxSourceStep subStep in _subSteps)
			{
				subStep.Changed -= SubStepOnChanged;
			}
			_isSubscribeToChangedEvents = false;
		}

		private void SubStepOnChanged(object sender, EventArgs args)
		{
			SendSourcePropertyChanged();
		}

		protected override void OnDataContextChanged()
		{
			foreach (IMvxSourceStep subStep in _subSteps)
			{
				subStep.DataContext = base.DataContext;
			}
			base.OnDataContextChanged();
		}

		protected override void SetSourceValue(object sourceValue)
		{
			if (sourceValue != MvxBindingConstant.UnsetValue && sourceValue != MvxBindingConstant.DoNothing)
			{
				base.Description.Combiner.SetValue(_subSteps, sourceValue);
			}
		}

		protected override object GetSourceValue()
		{
			if (!base.Description.Combiner.TryGetValue(_subSteps, out var value))
			{
				return MvxBindingConstant.UnsetValue;
			}
			return value;
		}
	}
	public class MvxCombinerSourceStepDescription : MvxSourceStepDescription
	{
		public IMvxValueCombiner Combiner { get; set; }

		public List<MvxSourceStepDescription> InnerSteps { get; set; }

		public override string ToString()
		{
			if (Combiner != null)
			{
				return Combiner.GetType().Name + " combiner-operation";
			}
			return "-null-";
		}
	}
	public class MvxCombinerSourceStepFactory : MvxTypedSourceStepFactory<MvxCombinerSourceStepDescription>
	{
		protected override IMvxSourceStep TypedCreate(MvxCombinerSourceStepDescription description)
		{
			return new MvxCombinerSourceStep(description);
		}
	}
	public class MvxLiteralSourceStep : MvxSourceStep<MvxLiteralSourceStepDescription>
	{
		public override Type SourceType
		{
			get
			{
				if (base.Description.Literal == null)
				{
					return typeof(object);
				}
				return base.Description.Literal.GetType();
			}
		}

		public MvxLiteralSourceStep(MvxLiteralSourceStepDescription description)
			: base(description)
		{
		}

		protected override void SetSourceValue(object sourceValue)
		{
		}

		protected override object GetSourceValue()
		{
			return base.Description.Literal;
		}
	}
	public class MvxLiteralSourceStepDescription : MvxSourceStepDescription
	{
		public object Literal { get; set; }

		public override string ToString()
		{
			if (Literal != null)
			{
				return Literal.ToString();
			}
			return "-null-";
		}
	}
	public class MvxLiteralSourceStepFactory : MvxTypedSourceStepFactory<MvxLiteralSourceStepDescription>
	{
		protected override IMvxSourceStep TypedCreate(MvxLiteralSourceStepDescription description)
		{
			return new MvxLiteralSourceStep(description);
		}
	}
	public class MvxPathSourceStep : MvxSourceStep<MvxPathSourceStepDescription>
	{
		private IMvxSourceBinding _sourceBinding;

		private IMvxSourceBindingFactory SourceBindingFactory => MvxSingleton<IMvxBindingSingletonCache>.Instance.SourceBindingFactory;

		public override Type SourceType
		{
			get
			{
				if (_sourceBinding == null)
				{
					return typeof(object);
				}
				return _sourceBinding.SourceType;
			}
		}

		public MvxPathSourceStep(MvxPathSourceStepDescription description)
			: base(description)
		{
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				ClearPathSourceBinding();
			}
			base.Dispose(isDisposing);
		}

		protected override void OnDataContextChanged()
		{
			ClearPathSourceBinding();
			_sourceBinding = SourceBindingFactory.CreateBinding(base.DataContext, base.Description.SourcePropertyPath);
			if (_sourceBinding != null)
			{
				_sourceBinding.Changed += SourceBindingOnChanged;
			}
			base.OnDataContextChanged();
		}

		private void ClearPathSourceBinding()
		{
			if (_sourceBinding != null)
			{
				_sourceBinding.Changed -= SourceBindingOnChanged;
				_sourceBinding.Dispose();
				_sourceBinding = null;
			}
		}

		private void SourceBindingOnChanged(object sender, EventArgs args)
		{
			base.SendSourcePropertyChanged();
		}

		protected override void SetSourceValue(object sourceValue)
		{
			if (_sourceBinding != null && sourceValue != MvxBindingConstant.UnsetValue && sourceValue != MvxBindingConstant.DoNothing)
			{
				_sourceBinding.SetValue(sourceValue);
			}
		}

		protected override object GetSourceValue()
		{
			if (_sourceBinding == null)
			{
				return MvxBindingConstant.UnsetValue;
			}
			return _sourceBinding.GetValue();
		}
	}
	public class MvxPathSourceStepDescription : MvxSourceStepDescription
	{
		public string SourcePropertyPath { get; set; }

		public override string ToString()
		{
			return SourcePropertyPath ?? "-empty-";
		}
	}
	public class MvxPathSourceStepFactory : MvxTypedSourceStepFactory<MvxPathSourceStepDescription>
	{
		protected override IMvxSourceStep TypedCreate(MvxPathSourceStepDescription description)
		{
			return new MvxPathSourceStep(description);
		}
	}
	public abstract class MvxSourceStep : IMvxSourceStep, IMvxBinding, IDisposable
	{
		private readonly MvxSourceStepDescription _description;

		private object _dataContext;

		protected MvxSourceStepDescription Description => _description;

		public virtual Type TargetType { get; set; }

		public virtual Type SourceType => typeof(object);

		public object DataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				_dataContext = value;
				OnDataContextChanged();
			}
		}

		private event EventHandler _changed;

		public event EventHandler Changed
		{
			add
			{
				bool num = this._changed != null;
				_changed += value;
				if (!num)
				{
					OnFirstChangeListenerAdded();
				}
			}
			remove
			{
				_changed -= value;
				if (this._changed == null)
				{
					OnLastChangeListenerRemoved();
				}
			}
		}

		protected MvxSourceStep(MvxSourceStepDescription description)
		{
			_description = description;
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
		}

		protected virtual void OnDataContextChanged()
		{
		}

		public void SetValue(object value)
		{
			object obj = ApplyValueConverterTargetToSource(value);
			if (obj != MvxBindingConstant.DoNothing && obj != MvxBindingConstant.UnsetValue)
			{
				SetSourceValue(obj);
			}
		}

		private object ApplyValueConverterTargetToSource(object value)
		{
			if (_description.Converter == null)
			{
				return value;
			}
			return _description.Converter.ConvertBack(value, SourceType, _description.ConverterParameter, CultureInfo.CurrentUICulture);
		}

		private object ApplyValueConverterSourceToTarget(object value)
		{
			if (_description.Converter == null)
			{
				return value;
			}
			try
			{
				return _description.Converter.Convert(value, TargetType, _description.ConverterParameter, CultureInfo.CurrentUICulture);
			}
			catch (Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Problem seen during binding execution for {0} - problem {1}", _description.ToString(), exception.ToLongString());
			}
			return MvxBindingConstant.UnsetValue;
		}

		protected abstract void SetSourceValue(object sourceValue);

		protected virtual void SendSourcePropertyChanged()
		{
			this._changed?.Invoke(this, EventArgs.Empty);
		}

		private object ConvertSourceToTarget(object value)
		{
			if (value == MvxBindingConstant.DoNothing)
			{
				return value;
			}
			if (value != MvxBindingConstant.UnsetValue)
			{
				value = ApplyValueConverterSourceToTarget(value);
			}
			if (value != MvxBindingConstant.UnsetValue)
			{
				return value;
			}
			if (_description.FallbackValue != null)
			{
				return _description.FallbackValue;
			}
			return MvxBindingConstant.UnsetValue;
		}

		protected virtual void OnLastChangeListenerRemoved()
		{
		}

		protected virtual void OnFirstChangeListenerAdded()
		{
		}

		public object GetValue()
		{
			object sourceValue = GetSourceValue();
			return ConvertSourceToTarget(sourceValue);
		}

		protected abstract object GetSourceValue();
	}
	public abstract class MvxSourceStep<T> : MvxSourceStep where T : MvxSourceStepDescription
	{
		protected new T Description => (T)base.Description;

		protected MvxSourceStep(T description)
			: base(description)
		{
		}
	}
	public class MvxSourceStepDescription
	{
		public IMvxValueConverter Converter { get; set; }

		public object ConverterParameter { get; set; }

		public object FallbackValue { get; set; }
	}
	public class MvxSourceStepFactory : IMvxSourceStepFactoryRegistry, IMvxSourceStepFactory
	{
		private readonly Dictionary<Type, IMvxSourceStepFactory> _subFactories = new Dictionary<Type, IMvxSourceStepFactory>();

		public void AddOrOverwrite(Type type, IMvxSourceStepFactory factory)
		{
			_subFactories[type] = factory;
		}

		public IMvxSourceStep Create(MvxSourceStepDescription description)
		{
			if (!_subFactories.TryGetValue(description.GetType(), out var value))
			{
				throw new MvxException("Failed to get factory for step type {0}", description.GetType().Name);
			}
			return value.Create(description);
		}
	}
	public abstract class MvxTypedSourceStepFactory<T> : IMvxSourceStepFactory where T : MvxSourceStepDescription
	{
		public IMvxSourceStep Create(MvxSourceStepDescription description)
		{
			return TypedCreate((T)description);
		}

		protected abstract IMvxSourceStep TypedCreate(T description);
	}
}
namespace MvvmCross.Binding.BindingContext
{
	public static class MvxFluentBindingDescriptionExtensions
	{
		public static MvxFluentBindingDescription<TTarget, TSource> ToLocalizationId<TTarget, TSource>(this MvxFluentBindingDescription<TTarget, TSource> bindingDescription, string localizationId) where TTarget : class where TSource : IMvxLocalizedTextSourceOwner
		{
			IMvxValueConverter converter = Mvx.Resolve<IMvxValueConverterLookup>().Find("Language");
			return bindingDescription.To((TSource vm) => ((IMvxLocalizedTextSourceOwner)vm).LocalizedTextSource).OneTime().WithConversion(converter, localizationId);
		}
	}
	public class MvxTaskBasedBindingContext : IMvxBindingContext, IMvxDataConsumer
	{
		private readonly List<Action> _delayedActions = new List<Action>();

		private readonly List<MvxBindingContext.TargetAndBinding> _directBindings = new List<MvxBindingContext.TargetAndBinding>();

		private readonly List<KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>>> _viewBindings = new List<KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>>>();

		private object _dataContext;

		private IMvxBinder _binder;

		public bool RunSynchronously { get; set; }

		protected IMvxBinder Binder
		{
			get
			{
				_binder = _binder ?? Mvx.Resolve<IMvxBinder>();
				return _binder;
			}
		}

		public object DataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				_dataContext = value;
				OnDataContextChange();
				this.DataContextChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public event EventHandler DataContextChanged;

		public IMvxBindingContext Init(object dataContext, object firstBindingKey, IEnumerable<MvxBindingDescription> firstBindingValue)
		{
			AddDelayedAction(firstBindingKey, firstBindingValue);
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		public IMvxBindingContext Init(object dataContext, object firstBindingKey, string firstBindingValue)
		{
			AddDelayedAction(firstBindingKey, firstBindingValue);
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		private void AddDelayedAction(object key, string value)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, key, value))
				{
					RegisterBinding(key, item);
				}
			});
		}

		private void AddDelayedAction(object key, IEnumerable<MvxBindingDescription> value)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, key, value))
				{
					RegisterBinding(key, item);
				}
			});
		}

		~MvxTaskBasedBindingContext()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				ClearAllBindings();
			}
		}

		protected virtual void OnDataContextChange()
		{
			if (_delayedActions.Count != 0)
			{
				foreach (Action delayedAction in _delayedActions)
				{
					delayedAction();
				}
				_delayedActions.Clear();
			}
			Action action = delegate
			{
				foreach (KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>> viewBinding in _viewBindings)
				{
					foreach (MvxBindingContext.TargetAndBinding item in viewBinding.Value)
					{
						item.Binding.DataContext = _dataContext;
					}
				}
				foreach (MvxBindingContext.TargetAndBinding directBinding in _directBindings)
				{
					directBinding.Binding.DataContext = _dataContext;
				}
			};
			if (RunSynchronously)
			{
				action();
			}
			else
			{
				Task.Run(action);
			}
		}

		public virtual void DelayBind(Action action)
		{
			_delayedActions.Add(action);
		}

		public virtual void RegisterBinding(object target, IMvxUpdateableBinding binding)
		{
			_directBindings.Add(new MvxBindingContext.TargetAndBinding(target, binding));
		}

		public virtual void RegisterBindingsWithClearKey(object clearKey, IEnumerable<KeyValuePair<object, IMvxUpdateableBinding>> bindings)
		{
			_viewBindings.Add(new KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>>(clearKey, bindings.Select((KeyValuePair<object, IMvxUpdateableBinding> b) => new MvxBindingContext.TargetAndBinding(b.Key, b.Value)).ToList()));
		}

		public virtual void RegisterBindingWithClearKey(object clearKey, object target, IMvxUpdateableBinding binding)
		{
			List<MvxBindingContext.TargetAndBinding> value = new List<MvxBindingContext.TargetAndBinding>
			{
				new MvxBindingContext.TargetAndBinding(target, binding)
			};
			_viewBindings.Add(new KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>>(clearKey, value));
		}

		public virtual void ClearBindings(object clearKey)
		{
			if (clearKey == null)
			{
				return;
			}
			for (int num = _viewBindings.Count - 1; num >= 0; num--)
			{
				KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>> keyValuePair = _viewBindings[num];
				if (keyValuePair.Key.Equals(clearKey))
				{
					foreach (MvxBindingContext.TargetAndBinding item in keyValuePair.Value)
					{
						item.Binding.Dispose();
					}
					_viewBindings.RemoveAt(num);
				}
			}
		}

		public virtual void ClearAllBindings()
		{
			ClearAllViewBindings();
			ClearAllDirectBindings();
			ClearAllDelayedBindings();
		}

		protected virtual void ClearAllDelayedBindings()
		{
			_delayedActions.Clear();
		}

		protected virtual void ClearAllDirectBindings()
		{
			foreach (MvxBindingContext.TargetAndBinding directBinding in _directBindings)
			{
				directBinding.Binding.Dispose();
			}
			_directBindings.Clear();
		}

		protected virtual void ClearAllViewBindings()
		{
			foreach (KeyValuePair<object, IList<MvxBindingContext.TargetAndBinding>> viewBinding in _viewBindings)
			{
				foreach (MvxBindingContext.TargetAndBinding item in viewBinding.Value)
				{
					item.Binding.Dispose();
				}
			}
			_viewBindings.Clear();
		}
	}
	public interface IMvxBindingNameRegistry
	{
		void AddOrOverwrite(Type type, string name);

		void AddOrOverwrite<T>(Expression<Func<T, object>> nameExpression);
	}
	public class MvxBaseFluentBindingDescription<TTarget> : MvxApplicableTo<TTarget> where TTarget : class
	{
		public interface ISourceSpec
		{
			MvxSourceStepDescription CreateSourceStep(MvxSourceStepDescription inputs);
		}

		public class KnownPathSourceSpec : ISourceSpec
		{
			private readonly string _knownSourcePath;

			public KnownPathSourceSpec(string knownSourcePath)
			{
				_knownSourcePath = knownSourcePath;
			}

			public MvxSourceStepDescription CreateSourceStep(MvxSourceStepDescription inputs)
			{
				return new MvxPathSourceStepDescription
				{
					Converter = inputs.Converter,
					ConverterParameter = inputs.ConverterParameter,
					FallbackValue = inputs.FallbackValue,
					SourcePropertyPath = _knownSourcePath
				};
			}
		}

		public class FreeTextSourceSpec : ISourceSpec
		{
			private readonly string _freeText;

			public FreeTextSourceSpec(string freeText)
			{
				_freeText = freeText;
			}

			public MvxSourceStepDescription CreateSourceStep(MvxSourceStepDescription inputs)
			{
				MvxBindingDescription mvxBindingDescription = Mvx.Resolve<IMvxBindingDescriptionParser>().ParseSingle(_freeText);
				if (inputs.Converter == null && inputs.FallbackValue == null)
				{
					return mvxBindingDescription.Source;
				}
				if (mvxBindingDescription.Source.Converter == null && mvxBindingDescription.Source.FallbackValue == null)
				{
					MvxSourceStepDescription source = mvxBindingDescription.Source;
					source.Converter = inputs.Converter;
					source.ConverterParameter = inputs.ConverterParameter;
					source.FallbackValue = inputs.FallbackValue;
					return source;
				}
				return SourceSpecHelpers.WrapInsideSingleCombiner(inputs, mvxBindingDescription.Source);
			}
		}

		public class FullySourceSpec : ISourceSpec
		{
			private readonly MvxSourceStepDescription _sourceStepDescription;

			public FullySourceSpec(MvxSourceStepDescription sourceStepDescription)
			{
				_sourceStepDescription = sourceStepDescription;
			}

			public MvxSourceStepDescription CreateSourceStep(MvxSourceStepDescription inputs)
			{
				if (inputs.Converter == null || inputs.FallbackValue == null)
				{
					return _sourceStepDescription;
				}
				return SourceSpecHelpers.WrapInsideSingleCombiner(inputs, _sourceStepDescription);
			}
		}

		public static class SourceSpecHelpers
		{
			public static MvxSourceStepDescription WrapInsideSingleCombiner(MvxSourceStepDescription inputs, MvxSourceStepDescription sourceStepDescription)
			{
				return new MvxCombinerSourceStepDescription
				{
					Combiner = new MvxSingleValueCombiner(),
					Converter = inputs.Converter,
					ConverterParameter = inputs.ConverterParameter,
					FallbackValue = inputs.FallbackValue,
					InnerSteps = new List<MvxSourceStepDescription> { sourceStepDescription }
				};
			}
		}

		private readonly TTarget _target;

		private readonly IMvxBindingContextOwner _bindingContextOwner;

		private readonly MvxBindingDescription _bindingDescription = new MvxBindingDescription();

		private readonly MvxSourceStepDescription _sourceStepDescription = new MvxSourceStepDescription();

		private ISourceSpec _sourceSpec;

		protected object ClearBindingKey { get; set; }

		protected MvxBindingDescription BindingDescription => _bindingDescription;

		protected MvxSourceStepDescription SourceStepDescription => _sourceStepDescription;

		protected void SetFreeTextPropertyPath(string sourcePropertyPath)
		{
			if (_sourceSpec != null)
			{
				throw new MvxException("You cannot set the source path of a Fluent binding more than once");
			}
			_sourceSpec = new FreeTextSourceSpec(sourcePropertyPath);
		}

		protected void SetKnownTextPropertyPath(string sourcePropertyPath)
		{
			if (_sourceSpec != null)
			{
				throw new MvxException("You cannot set the source path of a Fluent binding more than once");
			}
			_sourceSpec = new KnownPathSourceSpec(sourcePropertyPath);
		}

		[Obsolete("Please use SourceOverwrite instead")]
		protected void Overwrite(MvxBindingDescription bindingDescription)
		{
			SourceOverwrite(bindingDescription);
		}

		protected void SourceOverwrite(MvxBindingDescription bindingDescription)
		{
			if (_sourceSpec != null)
			{
				throw new MvxException("You cannot set the source path of a Fluent binding more than once");
			}
			_bindingDescription.Mode = bindingDescription.Mode;
			_bindingDescription.TargetName = bindingDescription.TargetName;
			_sourceSpec = new FullySourceSpec(bindingDescription.Source);
		}

		protected void FullOverwrite(MvxBindingDescription bindingDescription)
		{
			if (_sourceSpec != null)
			{
				throw new MvxException("You cannot set the source path of a Fluent binding more than once");
			}
			_sourceSpec = new FullySourceSpec(bindingDescription.Source);
		}

		public MvxBaseFluentBindingDescription(IMvxBindingContextOwner bindingContextOwner, TTarget target)
		{
			_bindingContextOwner = bindingContextOwner;
			_target = target;
		}

		protected static string TargetPropertyName(Expression<Func<TTarget, object>> targetPropertyPath)
		{
			return MvxSingleton<IMvxBindingSingletonCache>.Instance.PropertyExpressionParser.Parse(targetPropertyPath).Print();
		}

		protected static string SourcePropertyPath<TSource>(Expression<Func<TSource, object>> sourceProperty)
		{
			return MvxSingleton<IMvxBindingSingletonCache>.Instance.PropertyExpressionParser.Parse(sourceProperty).Print();
		}

		protected static IMvxValueConverter ValueConverterFromName(string converterName)
		{
			return MvxSingleton<IMvxBindingSingletonCache>.Instance.ValueConverterLookup.Find(converterName);
		}

		protected MvxBindingDescription CreateBindingDescription()
		{
			EnsureTargetNameSet();
			MvxSourceStepDescription source = ((_sourceSpec != null) ? _sourceSpec.CreateSourceStep(_sourceStepDescription) : new MvxPathSourceStepDescription
			{
				Converter = _sourceStepDescription.Converter,
				ConverterParameter = _sourceStepDescription.ConverterParameter,
				FallbackValue = _sourceStepDescription.FallbackValue
			});
			return new MvxBindingDescription
			{
				Mode = BindingDescription.Mode,
				TargetName = BindingDescription.TargetName,
				Source = source
			};
		}

		public override void Apply()
		{
			MvxBindingDescription bindingDescription = CreateBindingDescription();
			_bindingContextOwner.AddBinding(_target, bindingDescription, ClearBindingKey);
			base.Apply();
		}

		public override void ApplyTo(TTarget what)
		{
			MvxBindingDescription bindingDescription = CreateBindingDescription();
			_bindingContextOwner.AddBinding(what, bindingDescription, ClearBindingKey);
			base.ApplyTo(what);
		}

		protected void EnsureTargetNameSet()
		{
			if (string.IsNullOrEmpty(BindingDescription.TargetName))
			{
				BindingDescription.TargetName = MvxSingleton<IMvxBindingSingletonCache>.Instance.DefaultBindingNameLookup.DefaultFor(typeof(TTarget));
			}
		}
	}
	public static class MvxBindExtensions
	{
		public static MvxInlineBindingTarget<TViewModel> CreateInlineBindingTarget<TViewModel>(this IMvxBindingContextOwner bindingContextOwner)
		{
			return new MvxInlineBindingTarget<TViewModel>(bindingContextOwner);
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, string descriptionText)
		{
			target.BindingContextOwner.AddBindings(element, descriptionText);
			return element;
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, Expression<Func<TViewModel, object>> sourcePropertyPath, string converterName = null, object converterParameter = null, object fallbackValue = null, MvxBindingMode mode = MvxBindingMode.Default)
		{
			return element.Bind(target, null, sourcePropertyPath, converterName, converterParameter, fallbackValue, mode);
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, Expression<Func<TViewModel, object>> sourcePropertyPath, IMvxValueConverter converter, object converterParameter = null, object fallbackValue = null, MvxBindingMode mode = MvxBindingMode.Default)
		{
			return element.Bind(target, null, sourcePropertyPath, converter, converterParameter, fallbackValue, mode);
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, Expression<Func<T, object>> targetPropertyPath, Expression<Func<TViewModel, object>> sourcePropertyPath, string converterName = null, object converterParameter = null, object fallbackValue = null, MvxBindingMode mode = MvxBindingMode.Default)
		{
			IMvxValueConverter converter = MvxSingleton<IMvxBindingSingletonCache>.Instance.ValueConverterLookup.Find(converterName);
			return element.Bind(target, targetPropertyPath, sourcePropertyPath, converter, converterParameter, fallbackValue, mode);
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, Expression<Func<T, object>> targetPropertyPath, Expression<Func<TViewModel, object>> sourcePropertyPath, IMvxValueConverter converter, object converterParameter = null, object fallbackValue = null, MvxBindingMode mode = MvxBindingMode.Default)
		{
			IMvxPropertyExpressionParser propertyExpressionParser = MvxSingleton<IMvxBindingSingletonCache>.Instance.PropertyExpressionParser;
			string sourcePath = propertyExpressionParser.Parse(sourcePropertyPath).Print();
			string targetPath = ((targetPropertyPath == null) ? null : propertyExpressionParser.Parse(targetPropertyPath).Print());
			return element.Bind(target, targetPath, sourcePath, converter, converterParameter, fallbackValue, mode);
		}

		public static T Bind<T, TViewModel>(this T element, MvxInlineBindingTarget<TViewModel> target, string targetPath, string sourcePath, IMvxValueConverter converter = null, object converterParameter = null, object fallbackValue = null, MvxBindingMode mode = MvxBindingMode.Default)
		{
			if (string.IsNullOrEmpty(targetPath))
			{
				targetPath = MvxSingleton<IMvxBindingSingletonCache>.Instance.DefaultBindingNameLookup.DefaultFor(typeof(T));
			}
			MvxBindingDescription bindingDescription = new MvxBindingDescription(targetPath, sourcePath, converter, converterParameter, fallbackValue, mode);
			target.BindingContextOwner.AddBinding(element, bindingDescription);
			return element;
		}

		public static T Bind<T>(this T element, IMvxBindingContextOwner bindingContextOwner, string descriptionText)
		{
			bindingContextOwner.AddBindings(element, descriptionText);
			return element;
		}

		public static T Bind<T>(this T element, IMvxBindingContextOwner bindingContextOwner, IEnumerable<MvxBindingDescription> descriptions)
		{
			bindingContextOwner.AddBindings(element, descriptions);
			return element;
		}
	}
	public class MvxBindingNameRegistry : IMvxBindingNameLookup, IMvxBindingNameRegistry
	{
		private readonly Dictionary<Type, string> _lookup = new Dictionary<Type, string>();

		public string DefaultFor(Type type)
		{
			TryDefaultFor(type, out var toReturn);
			return toReturn;
		}

		private bool TryDefaultFor(Type type, out string toReturn, bool includeInterfaces = true)
		{
			if ((object)type == typeof(object))
			{
				toReturn = null;
				return false;
			}
			if (_lookup.TryGetValue(type, out toReturn))
			{
				return true;
			}
			if (type.IsConstructedGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				if ((object)genericTypeDefinition != null && _lookup.TryGetValue(genericTypeDefinition, out toReturn))
				{
					return true;
				}
			}
			if (type.GetTypeInfo().IsInterface)
			{
				return false;
			}
			if (includeInterfaces)
			{
				foreach (Type @interface in ReflectionExtensions.GetInterfaces(type))
				{
					if (TryDefaultFor(@interface, out toReturn, includeInterfaces: false))
					{
						return true;
					}
				}
			}
			return TryDefaultFor(type.GetTypeInfo().BaseType, out toReturn, includeInterfaces: false);
		}

		public void AddOrOverwrite(Type type, string name)
		{
			_lookup[type] = name;
		}

		public void AddOrOverwrite<T>(Expression<Func<T, object>> nameExpression)
		{
			IMvxParsedExpression mvxParsedExpression = MvxSingleton<IMvxBindingSingletonCache>.Instance.PropertyExpressionParser.Parse(nameExpression);
			_lookup[typeof(T)] = mvxParsedExpression.Print();
		}
	}
	public class MvxInlineBindingTarget<TViewModel>
	{
		public IMvxBindingContextOwner BindingContextOwner { get; private set; }

		public MvxInlineBindingTarget(IMvxBindingContextOwner bindingContextOwner)
		{
			BindingContextOwner = bindingContextOwner;
		}
	}
	public class MvxFluentBindingDescription<TTarget, TSource> : MvxBaseFluentBindingDescription<TTarget> where TTarget : class
	{
		public MvxFluentBindingDescription(IMvxBindingContextOwner bindingContextOwner, TTarget target)
			: base(bindingContextOwner, target)
		{
		}

		public MvxFluentBindingDescription<TTarget, TSource> For(string targetPropertyName)
		{
			base.BindingDescription.TargetName = targetPropertyName;
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> For(Expression<Func<TTarget, object>> targetPropertyPath)
		{
			string targetPropertyName = MvxBaseFluentBindingDescription<TTarget>.TargetPropertyName(targetPropertyPath);
			return For(targetPropertyName);
		}

		public MvxFluentBindingDescription<TTarget, TSource> TwoWay()
		{
			return Mode(MvxBindingMode.TwoWay);
		}

		public MvxFluentBindingDescription<TTarget, TSource> OneWay()
		{
			return Mode(MvxBindingMode.OneWay);
		}

		public MvxFluentBindingDescription<TTarget, TSource> OneWayToSource()
		{
			return Mode(MvxBindingMode.OneWayToSource);
		}

		public MvxFluentBindingDescription<TTarget, TSource> OneTime()
		{
			return Mode(MvxBindingMode.OneTime);
		}

		public MvxFluentBindingDescription<TTarget, TSource> Mode(MvxBindingMode mode)
		{
			base.BindingDescription.Mode = mode;
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> To(string sourcePropertyPath)
		{
			SetFreeTextPropertyPath(sourcePropertyPath);
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> To(Expression<Func<TSource, object>> sourceProperty)
		{
			string knownTextPropertyPath = MvxBaseFluentBindingDescription<TTarget>.SourcePropertyPath(sourceProperty);
			SetKnownTextPropertyPath(knownTextPropertyPath);
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> CommandParameter(object parameter)
		{
			return WithConversion(new MvxCommandParameterValueConverter(), parameter);
		}

		public MvxFluentBindingDescription<TTarget, TSource> WithConversion(string converterName, object converterParameter = null)
		{
			IMvxValueConverter converter = MvxBaseFluentBindingDescription<TTarget>.ValueConverterFromName(converterName);
			return WithConversion(converter, converterParameter);
		}

		public MvxFluentBindingDescription<TTarget, TSource> WithConversion(IMvxValueConverter converter, object converterParameter = null)
		{
			base.SourceStepDescription.Converter = converter;
			base.SourceStepDescription.ConverterParameter = converterParameter;
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> WithFallback(object fallback)
		{
			base.SourceStepDescription.FallbackValue = fallback;
			return this;
		}

		[Obsolete("Please use SourceDescribed or FullyDescribed instead")]
		public MvxFluentBindingDescription<TTarget, TSource> Described(string bindingDescription)
		{
			MvxBindingDescription description = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.ParseSingle(bindingDescription);
			return Described(description);
		}

		[Obsolete("Please use SourceDescribed or FullyDescribed instead")]
		public MvxFluentBindingDescription<TTarget, TSource> Described(MvxBindingDescription description)
		{
			Overwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> SourceDescribed(string bindingDescription)
		{
			MvxBindingDescription description = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.ParseSingle(bindingDescription);
			return SourceDescribed(description);
		}

		public MvxFluentBindingDescription<TTarget, TSource> SourceDescribed(MvxBindingDescription description)
		{
			SourceOverwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> FullyDescribed(string bindingDescription)
		{
			List<MvxBindingDescription> list = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.Parse(bindingDescription).ToList();
			if (list.Count > 1)
			{
				MvxBindingTrace.Warning("More than one description found - only first will be used in {0}", bindingDescription);
			}
			return FullyDescribed(list.FirstOrDefault());
		}

		public MvxFluentBindingDescription<TTarget, TSource> FullyDescribed(MvxBindingDescription description)
		{
			FullOverwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget, TSource> WithClearBindingKey(object clearBindingKey)
		{
			base.ClearBindingKey = clearBindingKey;
			return this;
		}
	}
	public class MvxFluentBindingDescription<TTarget> : MvxBaseFluentBindingDescription<TTarget> where TTarget : class
	{
		public MvxFluentBindingDescription(IMvxBindingContextOwner bindingContextOwner, TTarget target = null)
			: base(bindingContextOwner, target)
		{
		}

		public MvxFluentBindingDescription<TTarget> For(string targetPropertyName)
		{
			base.BindingDescription.TargetName = targetPropertyName;
			return this;
		}

		public MvxFluentBindingDescription<TTarget> For(Expression<Func<TTarget, object>> targetPropertyPath)
		{
			string targetPropertyName = MvxBaseFluentBindingDescription<TTarget>.TargetPropertyName(targetPropertyPath);
			return For(targetPropertyName);
		}

		public MvxFluentBindingDescription<TTarget> TwoWay()
		{
			return Mode(MvxBindingMode.TwoWay);
		}

		public MvxFluentBindingDescription<TTarget> OneWay()
		{
			return Mode(MvxBindingMode.OneWay);
		}

		public MvxFluentBindingDescription<TTarget> OneWayToSource()
		{
			return Mode(MvxBindingMode.OneWayToSource);
		}

		public MvxFluentBindingDescription<TTarget> OneTime()
		{
			return Mode(MvxBindingMode.OneTime);
		}

		public MvxFluentBindingDescription<TTarget> Mode(MvxBindingMode mode)
		{
			base.BindingDescription.Mode = mode;
			return this;
		}

		public MvxFluentBindingDescription<TTarget> To(string sourcePropertyPath)
		{
			SetFreeTextPropertyPath(sourcePropertyPath);
			return this;
		}

		public MvxFluentBindingDescription<TTarget> To<TSource>(Expression<Func<TSource, object>> sourceProperty)
		{
			string knownTextPropertyPath = MvxBaseFluentBindingDescription<TTarget>.SourcePropertyPath(sourceProperty);
			SetKnownTextPropertyPath(knownTextPropertyPath);
			return this;
		}

		public MvxFluentBindingDescription<TTarget> CommandParameter(object parameter)
		{
			return WithConversion(new MvxCommandParameterValueConverter(), parameter);
		}

		public MvxFluentBindingDescription<TTarget> WithConversion(string converterName, object converterParameter = null)
		{
			IMvxValueConverter converter = MvxBaseFluentBindingDescription<TTarget>.ValueConverterFromName(converterName);
			return WithConversion(converter, converterParameter);
		}

		public MvxFluentBindingDescription<TTarget> WithConversion(IMvxValueConverter converter, object converterParameter)
		{
			base.SourceStepDescription.Converter = converter;
			base.SourceStepDescription.ConverterParameter = converterParameter;
			return this;
		}

		public MvxFluentBindingDescription<TTarget> WithFallback(object fallback)
		{
			base.SourceStepDescription.FallbackValue = fallback;
			return this;
		}

		[Obsolete("Please use SourceDescribed or FullyDescribed instead")]
		public MvxFluentBindingDescription<TTarget> Described(string bindingDescription)
		{
			MvxBindingDescription description = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.ParseSingle(bindingDescription);
			return Described(description);
		}

		[Obsolete("Please use SourceDescribed or FullyDescribed instead")]
		public MvxFluentBindingDescription<TTarget> Described(MvxBindingDescription description)
		{
			Overwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget> SourceDescribed(string bindingDescription)
		{
			MvxBindingDescription description = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.ParseSingle(bindingDescription);
			return SourceDescribed(description);
		}

		public MvxFluentBindingDescription<TTarget> SourceDescribed(MvxBindingDescription description)
		{
			SourceOverwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget> FullyDescribed(string bindingDescription)
		{
			List<MvxBindingDescription> list = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.Parse(bindingDescription).ToList();
			if (list.Count > 1)
			{
				MvxBindingTrace.Warning("More than one description found - only first will be used in {0}", bindingDescription);
			}
			return FullyDescribed(list.FirstOrDefault());
		}

		public MvxFluentBindingDescription<TTarget> FullyDescribed(MvxBindingDescription description)
		{
			FullOverwrite(description ?? new MvxBindingDescription());
			return this;
		}

		public MvxFluentBindingDescription<TTarget> WithClearBindingKey(object clearBindingKey)
		{
			base.ClearBindingKey = clearBindingKey;
			return this;
		}
	}
	public class MvxFluentBindingDescriptionSet<TOwningTarget, TSource> : MvxApplicable where TOwningTarget : class, IMvxBindingContextOwner
	{
		private readonly List<IMvxApplicable> _applicables = new List<IMvxApplicable>();

		private readonly TOwningTarget _bindingContextOwner;

		public MvxFluentBindingDescriptionSet(TOwningTarget bindingContextOwner)
		{
			_bindingContextOwner = bindingContextOwner;
		}

		public MvxFluentBindingDescription<TOwningTarget, TSource> Bind()
		{
			MvxFluentBindingDescription<TOwningTarget, TSource> mvxFluentBindingDescription = new MvxFluentBindingDescription<TOwningTarget, TSource>(_bindingContextOwner, _bindingContextOwner);
			_applicables.Add(mvxFluentBindingDescription);
			return mvxFluentBindingDescription;
		}

		public MvxFluentBindingDescription<TChildTarget, TSource> Bind<TChildTarget>(TChildTarget childTarget) where TChildTarget : class
		{
			MvxFluentBindingDescription<TChildTarget, TSource> mvxFluentBindingDescription = new MvxFluentBindingDescription<TChildTarget, TSource>(_bindingContextOwner, childTarget);
			_applicables.Add(mvxFluentBindingDescription);
			return mvxFluentBindingDescription;
		}

		public MvxFluentBindingDescription<TChildTarget, TSource> Bind<TChildTarget>(TChildTarget childTarget, string bindingDescription) where TChildTarget : class
		{
			MvxFluentBindingDescription<TChildTarget, TSource> mvxFluentBindingDescription = Bind(childTarget);
			mvxFluentBindingDescription.FullyDescribed(bindingDescription);
			return mvxFluentBindingDescription;
		}

		public MvxFluentBindingDescription<TChildTarget, TSource> Bind<TChildTarget>(TChildTarget childTarget, MvxBindingDescription bindingDescription) where TChildTarget : class
		{
			MvxFluentBindingDescription<TChildTarget, TSource> mvxFluentBindingDescription = Bind(childTarget);
			mvxFluentBindingDescription.FullyDescribed(bindingDescription);
			return mvxFluentBindingDescription;
		}

		public override void Apply()
		{
			foreach (IMvxApplicable applicable in _applicables)
			{
				applicable.Apply();
			}
			base.Apply();
		}
	}
	public class MvxBindingContext : IMvxBindingContext, IMvxDataConsumer
	{
		public class TargetAndBinding
		{
			public object Target { get; private set; }

			public IMvxUpdateableBinding Binding { get; }

			public TargetAndBinding(object target, IMvxUpdateableBinding binding)
			{
				Target = target;
				Binding = binding;
			}
		}

		private readonly List<Action> _delayedActions = new List<Action>();

		private readonly List<TargetAndBinding> _directBindings = new List<TargetAndBinding>();

		private readonly List<KeyValuePair<object, IList<TargetAndBinding>>> _viewBindings = new List<KeyValuePair<object, IList<TargetAndBinding>>>();

		private object _dataContext;

		private IMvxBinder _binder;

		protected IMvxBinder Binder
		{
			get
			{
				_binder = _binder ?? Mvx.Resolve<IMvxBinder>();
				return _binder;
			}
		}

		public object DataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				_dataContext = value;
				OnDataContextChange();
				this.DataContextChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public event EventHandler DataContextChanged;

		public MvxBindingContext()
			: this((object)null)
		{
		}

		public MvxBindingContext(object dataContext)
		{
			_dataContext = dataContext;
		}

		public MvxBindingContext(IDictionary<object, string> firstBindings)
		{
			Init(null, firstBindings);
		}

		public MvxBindingContext(object dataContext, IDictionary<object, string> firstBindings)
		{
			Init(dataContext, firstBindings);
		}

		public MvxBindingContext(IDictionary<object, IEnumerable<MvxBindingDescription>> firstBindings)
		{
			Init(null, firstBindings);
		}

		public MvxBindingContext(object dataContext, IDictionary<object, IEnumerable<MvxBindingDescription>> firstBindings)
		{
			Init(dataContext, firstBindings);
		}

		public MvxBindingContext Init(object dataContext, IDictionary<object, IEnumerable<MvxBindingDescription>> firstBindings)
		{
			foreach (KeyValuePair<object, IEnumerable<MvxBindingDescription>> firstBinding in firstBindings)
			{
				AddDelayedAction(firstBinding);
			}
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		public MvxBindingContext Init(object dataContext, IDictionary<object, string> firstBindings)
		{
			foreach (KeyValuePair<object, string> firstBinding in firstBindings)
			{
				AddDelayedAction(firstBinding);
			}
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		public IMvxBindingContext Init(object dataContext, object firstBindingKey, IEnumerable<MvxBindingDescription> firstBindingValue)
		{
			AddDelayedAction(firstBindingKey, firstBindingValue);
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		public IMvxBindingContext Init(object dataContext, object firstBindingKey, string firstBindingValue)
		{
			AddDelayedAction(firstBindingKey, firstBindingValue);
			if (dataContext != null)
			{
				DataContext = dataContext;
			}
			return this;
		}

		private void AddDelayedAction(object key, string value)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, key, value))
				{
					RegisterBinding(key, item);
				}
			});
		}

		private void AddDelayedAction(object key, IEnumerable<MvxBindingDescription> value)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, key, value))
				{
					RegisterBinding(key, item);
				}
			});
		}

		private void AddDelayedAction(KeyValuePair<object, string> kvp)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, kvp.Key, kvp.Value))
				{
					RegisterBinding(kvp.Key, item);
				}
			});
		}

		private void AddDelayedAction(KeyValuePair<object, IEnumerable<MvxBindingDescription>> kvp)
		{
			_delayedActions.Add(delegate
			{
				foreach (IMvxUpdateableBinding item in Binder.Bind(DataContext, kvp.Key, kvp.Value))
				{
					RegisterBinding(kvp.Key, item);
				}
			});
		}

		~MvxBindingContext()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				ClearAllBindings();
			}
		}

		protected virtual void OnDataContextChange()
		{
			foreach (KeyValuePair<object, IList<TargetAndBinding>> viewBinding in _viewBindings)
			{
				foreach (TargetAndBinding item in viewBinding.Value)
				{
					item.Binding.DataContext = _dataContext;
				}
			}
			foreach (TargetAndBinding directBinding in _directBindings)
			{
				directBinding.Binding.DataContext = _dataContext;
			}
			if (_delayedActions.Count == 0)
			{
				return;
			}
			foreach (Action delayedAction in _delayedActions)
			{
				delayedAction();
			}
			_delayedActions.Clear();
		}

		public virtual void DelayBind(Action action)
		{
			_delayedActions.Add(action);
		}

		public virtual void RegisterBinding(object target, IMvxUpdateableBinding binding)
		{
			_directBindings.Add(new TargetAndBinding(target, binding));
		}

		public virtual void RegisterBindingsWithClearKey(object clearKey, IEnumerable<KeyValuePair<object, IMvxUpdateableBinding>> bindings)
		{
			_viewBindings.Add(new KeyValuePair<object, IList<TargetAndBinding>>(clearKey, bindings.Select((KeyValuePair<object, IMvxUpdateableBinding> b) => new TargetAndBinding(b.Key, b.Value)).ToList()));
		}

		public virtual void RegisterBindingWithClearKey(object clearKey, object target, IMvxUpdateableBinding binding)
		{
			List<TargetAndBinding> value = new List<TargetAndBinding>
			{
				new TargetAndBinding(target, binding)
			};
			_viewBindings.Add(new KeyValuePair<object, IList<TargetAndBinding>>(clearKey, value));
		}

		public virtual void ClearBindings(object clearKey)
		{
			if (clearKey == null)
			{
				return;
			}
			for (int num = _viewBindings.Count - 1; num >= 0; num--)
			{
				KeyValuePair<object, IList<TargetAndBinding>> keyValuePair = _viewBindings[num];
				if (keyValuePair.Key.Equals(clearKey))
				{
					foreach (TargetAndBinding item in keyValuePair.Value)
					{
						item.Binding.Dispose();
					}
					_viewBindings.RemoveAt(num);
				}
			}
		}

		public virtual void ClearAllBindings()
		{
			ClearAllViewBindings();
			ClearAllDirectBindings();
			ClearAllDelayedBindings();
		}

		protected virtual void ClearAllDelayedBindings()
		{
			_delayedActions.Clear();
		}

		protected virtual void ClearAllDirectBindings()
		{
			foreach (TargetAndBinding directBinding in _directBindings)
			{
				directBinding.Binding.Dispose();
			}
			_directBindings.Clear();
		}

		protected virtual void ClearAllViewBindings()
		{
			foreach (KeyValuePair<object, IList<TargetAndBinding>> viewBinding in _viewBindings)
			{
				foreach (TargetAndBinding item in viewBinding.Value)
				{
					item.Binding.Dispose();
				}
			}
			_viewBindings.Clear();
		}
	}
	public class MvxBindingContextStack<TContext> : Stack<TContext>, IMvxBindingContextStack<TContext>
	{
		public TContext Current
		{
			get
			{
				if (base.Count == 0)
				{
					return default(TContext);
				}
				return Peek();
			}
		}

		void IMvxBindingContextStack<TContext>.Push(TContext context)
		{
			Push(context);
		}

		TContext IMvxBindingContextStack<TContext>.Pop()
		{
			return Pop();
		}
	}
	public class MvxBindingContextStackRegistration<TBindingContext> : IDisposable
	{
		protected IMvxBindingContextStack<TBindingContext> Stack => Mvx.Resolve<IMvxBindingContextStack<TBindingContext>>();

		public MvxBindingContextStackRegistration(TBindingContext toRegister)
		{
			Stack.Push(toRegister);
		}

		~MvxBindingContextStackRegistration()
		{
			MvxTrace.Error("You should always Dispose of MvxBindingContextStackRegistration");
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				Stack.Pop();
			}
		}
	}
	public interface IMvxBindingContext : IMvxDataConsumer
	{
		event EventHandler DataContextChanged;

		IMvxBindingContext Init(object dataContext, object firstBindingKey, IEnumerable<MvxBindingDescription> firstBindingValue);

		IMvxBindingContext Init(object dataContext, object firstBindingKey, string firstBindingValue);

		void RegisterBinding(object target, IMvxUpdateableBinding binding);

		void RegisterBindingsWithClearKey(object clearKey, IEnumerable<KeyValuePair<object, IMvxUpdateableBinding>> bindings);

		void RegisterBindingWithClearKey(object clearKey, object target, IMvxUpdateableBinding binding);

		void ClearBindings(object clearKey);

		void ClearAllBindings();

		void DelayBind(Action action);
	}
	public interface IMvxBindingContextOwner
	{
		IMvxBindingContext BindingContext { get; set; }
	}
	public interface IMvxBindingContextStack<TContext>
	{
		TContext Current { get; }

		void Push(TContext context);

		TContext Pop();
	}
	public interface IMvxBindingNameLookup
	{
		string DefaultFor(Type type);
	}
	public static class MvxBindingContextOwnerExtensions
	{
		public static IMvxLanguageBindingParser LanguageParser => MvxSingleton<IMvxBindingSingletonCache>.Instance.LanguageParser;

		public static IMvxPropertyExpressionParser PropertyExpressionParser => MvxSingleton<IMvxBindingSingletonCache>.Instance.PropertyExpressionParser;

		public static IMvxValueConverterLookup ValueConverterLookup => MvxSingleton<IMvxBindingSingletonCache>.Instance.ValueConverterLookup;

		public static IMvxBindingNameLookup DefaultBindingNameLookup => MvxSingleton<IMvxBindingSingletonCache>.Instance.DefaultBindingNameLookup;

		public static IMvxBinder Binder => MvxSingleton<IMvxBindingSingletonCache>.Instance.Binder;

		public static MvxFluentBindingDescriptionSet<TTarget, TSource> CreateBindingSet<TTarget, TSource>(this TTarget target) where TTarget : class, IMvxBindingContextOwner
		{
			return new MvxFluentBindingDescriptionSet<TTarget, TSource>(target);
		}

		public static MvxFluentBindingDescription<TTarget> CreateBinding<TTarget>(this TTarget target) where TTarget : class, IMvxBindingContextOwner
		{
			return new MvxFluentBindingDescription<TTarget>(target, target);
		}

		public static MvxFluentBindingDescription<TTarget> CreateBinding<TTarget>(this IMvxBindingContextOwner contextOwner, TTarget target) where TTarget : class
		{
			return new MvxFluentBindingDescription<TTarget>(contextOwner, target);
		}

		public static void BindLanguage<TTarget>(this IMvxBindingContextOwner owner, TTarget target, string sourceKey)
		{
			_ = PropertyExpressionParser;
			string targetPropertyName = MvxSingleton<IMvxBindingSingletonCache>.Instance.DefaultBindingNameLookup.DefaultFor(typeof(TTarget));
			owner.BindLanguage(target, targetPropertyName, sourceKey);
		}

		public static void BindLanguage<TTarget, TViewModel>(this IMvxBindingContextOwner owner, TTarget target, string sourceKey, Expression<Func<TViewModel, IMvxTextProvider>> textProvider)
		{
			IMvxPropertyExpressionParser propertyExpressionParser = PropertyExpressionParser;
			string targetPropertyName = MvxSingleton<IMvxBindingSingletonCache>.Instance.DefaultBindingNameLookup.DefaultFor(typeof(TTarget));
			string sourcePropertyName = propertyExpressionParser.Parse(textProvider).Print();
			owner.BindLanguage(target, targetPropertyName, sourceKey, sourcePropertyName);
		}

		public static void BindLanguage<TTarget>(this IMvxBindingContextOwner owner, TTarget target, Expression<Func<TTarget, object>> targetPropertyExpression, string sourceKey, string sourcePropertyName = null, string fallbackValue = null, string converterName = null)
		{
			string targetPropertyName = PropertyExpressionParser.Parse(targetPropertyExpression).Print();
			owner.BindLanguage(target, targetPropertyName, sourceKey, sourcePropertyName, fallbackValue, converterName);
		}

		public static void BindLanguage<TTarget, TViewModel>(this IMvxBindingContextOwner owner, TTarget target, Expression<Func<TTarget, object>> targetPropertyExpression, string sourceKey, Expression<Func<TViewModel, IMvxLanguageBinder>> sourcePropertyExpression, string fallbackValue = null, string converterName = null)
		{
			IMvxPropertyExpressionParser propertyExpressionParser = PropertyExpressionParser;
			string targetPropertyName = propertyExpressionParser.Parse(targetPropertyExpression).Print();
			string sourcePropertyName = propertyExpressionParser.Parse(sourcePropertyExpression).Print();
			owner.BindLanguage(target, targetPropertyName, sourceKey, sourcePropertyName, fallbackValue, converterName);
		}

		public static void BindLanguage(this IMvxBindingContextOwner owner, string targetPropertyName, string sourceKey, string sourcePropertyName = null, string fallbackValue = null, string converterName = null)
		{
			owner.BindLanguage(owner, targetPropertyName, sourceKey, sourcePropertyName, fallbackValue, converterName);
		}

		public static void BindLanguage(this IMvxBindingContextOwner owner, object target, string targetPropertyName, string sourceKey, string sourcePropertyName = null, string fallbackValue = null, string converterName = null)
		{
			converterName = converterName ?? LanguageParser.DefaultConverterName;
			sourcePropertyName = sourcePropertyName ?? LanguageParser.DefaultTextSourceName;
			IMvxValueConverter converter = ValueConverterLookup.Find(converterName);
			MvxBindingDescription bindingDescription = new MvxBindingDescription
			{
				TargetName = targetPropertyName,
				Source = new MvxPathSourceStepDescription
				{
					SourcePropertyPath = sourcePropertyName,
					Converter = converter,
					ConverterParameter = sourceKey,
					FallbackValue = fallbackValue
				},
				Mode = MvxBindingMode.OneTime
			};
			owner.AddBinding(target, bindingDescription);
		}

		public static void AddLangBindings(this IMvxBindingContextOwner view, object target, string bindingText)
		{
			IEnumerable<IMvxUpdateableBinding> bindings = Binder.LanguageBind(view.BindingContext.DataContext, target, bindingText);
			view.AddBindings(target, bindings);
		}

		public static void AddLangBindings(this IMvxBindingContextOwner view, IDictionary<object, string> lookup)
		{
			foreach (KeyValuePair<object, string> item in lookup)
			{
				view.AddLangBindings(item.Key, item.Value);
			}
		}

		public static void CreateBindingContext(this IMvxBindingContextOwner view)
		{
			view.BindingContext = Mvx.Resolve<IMvxBindingContext>();
		}

		public static void CreateBindingContext(this IMvxBindingContextOwner view, string bindingText)
		{
			view.BindingContext = Mvx.Resolve<IMvxBindingContext>().Init(null, view, bindingText);
		}

		public static void CreateBindingContext(this IMvxBindingContextOwner view, IEnumerable<MvxBindingDescription> bindings)
		{
			view.BindingContext = Mvx.Resolve<IMvxBindingContext>().Init(null, view, bindings);
		}

		public static void DelayBind(this IMvxBindingContextOwner view, Action bindingAction)
		{
			view.BindingContext.DelayBind(bindingAction);
		}

		public static void AddBinding(this IMvxBindingContextOwner view, object target, IMvxUpdateableBinding binding, object clearKey = null)
		{
			if (clearKey == null)
			{
				view.BindingContext.RegisterBinding(target, binding);
			}
			else
			{
				view.BindingContext.RegisterBindingWithClearKey(clearKey, target, binding);
			}
		}

		public static void AddBindings(this IMvxBindingContextOwner view, object target, IEnumerable<IMvxUpdateableBinding> bindings, object clearKey = null)
		{
			if (bindings == null)
			{
				return;
			}
			foreach (IMvxUpdateableBinding binding in bindings)
			{
				view.AddBinding(target, binding, clearKey);
			}
		}

		public static void AddBindings(this IMvxBindingContextOwner view, object target, string bindingText, object clearKey = null)
		{
			IEnumerable<IMvxUpdateableBinding> bindings = Binder.Bind(view.BindingContext.DataContext, target, bindingText);
			view.AddBindings(target, bindings, clearKey);
		}

		public static void AddBinding(this IMvxBindingContextOwner view, object target, MvxBindingDescription bindingDescription, object clearKey = null)
		{
			MvxBindingDescription[] bindingDescriptions = new MvxBindingDescription[1] { bindingDescription };
			view.AddBindings(target, bindingDescriptions, clearKey);
		}

		public static void AddBindings(this IMvxBindingContextOwner view, object target, IEnumerable<MvxBindingDescription> bindingDescriptions, object clearKey = null)
		{
			IEnumerable<IMvxUpdateableBinding> bindings = Binder.Bind(view.BindingContext.DataContext, target, bindingDescriptions);
			view.AddBindings(target, bindings, clearKey);
		}

		public static void AddBindings(this IMvxBindingContextOwner view, IDictionary<object, string> bindingMap, object clearKey = null)
		{
			if (bindingMap == null)
			{
				return;
			}
			foreach (KeyValuePair<object, string> item in bindingMap)
			{
				view.AddBindings(item.Key, item.Value, clearKey);
			}
		}

		public static void AddBindings(this IMvxBindingContextOwner view, IDictionary<object, IEnumerable<MvxBindingDescription>> bindingMap, object clearKey = null)
		{
			if (bindingMap == null)
			{
				return;
			}
			foreach (KeyValuePair<object, IEnumerable<MvxBindingDescription>> item in bindingMap)
			{
				view.AddBindings(item.Key, item.Value, clearKey);
			}
		}

		public static void ClearBindings(this IMvxBindingContextOwner owner, object target)
		{
			owner.BindingContext.ClearBindings(target);
		}

		public static void ClearAllBindings(this IMvxBindingContextOwner owner)
		{
			owner.BindingContext.ClearAllBindings();
		}
	}
}
namespace MvvmCross.Binding.Binders
{
	public interface IMvxAutoValueConverters
	{
		IMvxValueConverter Find(Type viewModelType, Type viewType);

		void Register(Type viewModelType, Type viewType, IMvxValueConverter converter);
	}
	public interface IMvxNamedInstanceRegistryFiller<out T>
	{
		void FillFrom(IMvxNamedInstanceRegistry<T> registry, Type type);

		void FillFrom(IMvxNamedInstanceRegistry<T> registry, Assembly assembly);
	}
	public interface IMvxValueConverterRegistryFiller : IMvxNamedInstanceRegistryFiller<IMvxValueConverter>
	{
	}
	public class MvxAutoValueConverters : IMvxAutoValueConverters
	{
		public class Key
		{
			public Type ViewModelType { get; }

			public Type ViewType { get; }

			public Key(Type viewModel, Type view)
			{
				ViewType = view;
				ViewModelType = viewModel;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is Key key))
				{
					return false;
				}
				if ((object)ViewModelType == key.ViewModelType)
				{
					return (object)ViewType == key.ViewType;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return ViewModelType.GetHashCode() + ViewType.GetHashCode();
			}
		}

		private readonly Dictionary<Key, IMvxValueConverter> _lookup = new Dictionary<Key, IMvxValueConverter>();

		public IMvxValueConverter Find(Type viewModelType, Type viewType)
		{
			_lookup.TryGetValue(new Key(viewModelType, viewType), out var value);
			return value;
		}

		public void Register(Type viewModelType, Type viewType, IMvxValueConverter converter)
		{
			_lookup[new Key(viewModelType, viewType)] = converter;
		}
	}
	public class MvxNamedInstanceRegistry<T> : IMvxNamedInstanceLookup<T>, IMvxNamedInstanceRegistry<T> where T : class
	{
		private readonly Dictionary<string, T> _converters = new Dictionary<string, T>();

		public T Find(string converterName)
		{
			if (string.IsNullOrEmpty(converterName))
			{
				return null;
			}
			_converters.TryGetValue(converterName, out var value);
			return value;
		}

		public void AddOrOverwrite(string name, T converter)
		{
			_converters[name] = converter;
		}

		public void AddOrOverwriteFrom(Assembly assembly)
		{
			this.Fill(assembly);
		}
	}
	public class MvxNamedInstanceRegistryFiller<T> : IMvxNamedInstanceRegistryFiller<T> where T : class
	{
		public virtual void FillFrom(IMvxNamedInstanceRegistry<T> registry, Type type)
		{
			if (type.GetTypeInfo().IsAbstract)
			{
				FillFromStatic(registry, type);
			}
			else
			{
				FillFromInstance(registry, type);
			}
		}

		protected virtual void FillFromInstance(IMvxNamedInstanceRegistry<T> registry, Type type)
		{
			object instance = Activator.CreateInstance(type);
			foreach (var item in from field in ReflectionExtensions.GetFields(type)
				where !field.IsStatic
				where field.IsPublic
				where ReflectionExtensions.IsAssignableFrom(typeof(T), field.FieldType)
				let converter = field.GetValue(instance) as T
				where converter != null
				select new
				{
					Name = field.Name,
					Converter = converter
				})
			{
				registry.AddOrOverwrite(item.Name, item.Converter);
			}
		}

		protected virtual void FillFromStatic(IMvxNamedInstanceRegistry<T> registry, Type type)
		{
			foreach (var item in from field in ReflectionExtensions.GetFields(type)
				where field.IsStatic
				where field.IsPublic
				where ReflectionExtensions.IsAssignableFrom(typeof(T), field.FieldType)
				let converter = field.GetValue(null) as T
				where converter != null
				select new
				{
					Name = field.Name,
					Converter = converter
				})
			{
				registry.AddOrOverwrite(item.Name, item.Converter);
			}
		}

		public virtual void FillFrom(IMvxNamedInstanceRegistry<T> registry, Assembly assembly)
		{
			foreach (var item in from type in assembly.ExceptionSafeGetTypes()
				where type.GetTypeInfo().IsPublic
				where !type.GetTypeInfo().IsAbstract
				where ReflectionExtensions.IsAssignableFrom(typeof(T), type)
				let name = FindName(type)
				where !string.IsNullOrEmpty(name)
				where type.IsConventional()
				select new
				{
					Name = name,
					Type = type
				})
			{
				try
				{
					T instance = Activator.CreateInstance(item.Type) as T;
					MvxBindingTrace.Trace("Registering value converter {0}:{1}", item.Name, item.Type.Name);
					registry.AddOrOverwrite(item.Name, instance);
				}
				catch (Exception)
				{
				}
			}
		}

		protected virtual string FindName(Type type)
		{
			return RemoveHead(type.Name, "Mvx");
		}

		protected static string RemoveHead(string name, string word)
		{
			if (name.StartsWith(word))
			{
				name = name.Substring(word.Length);
			}
			return name;
		}

		protected static string RemoveTail(string name, string word)
		{
			if (name.EndsWith(word))
			{
				name = name.Substring(0, name.Length - word.Length);
			}
			return name;
		}
	}
	public class MvxValueConverterRegistryFiller : MvxNamedInstanceRegistryFiller<IMvxValueConverter>, IMvxValueConverterRegistryFiller, IMvxNamedInstanceRegistryFiller<IMvxValueConverter>
	{
		protected override string FindName(Type type)
		{
			return MvxNamedInstanceRegistryFiller<IMvxValueConverter>.RemoveTail(MvxNamedInstanceRegistryFiller<IMvxValueConverter>.RemoveTail(base.FindName(type), "ValueConverter"), "Converter");
		}
	}
	public static class MvxRegistryFillerExtensions
	{
		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IEnumerable<Assembly> assemblies, IEnumerable<Type> types) where T : class
		{
			IMvxNamedInstanceRegistryFiller<T> filler = Mvx.Resolve<IMvxNamedInstanceRegistryFiller<T>>();
			registry.Fill(filler, assemblies);
			registry.Fill(filler, types);
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IEnumerable<Assembly> assemblies)
		{
			if (assemblies != null)
			{
				IMvxNamedInstanceRegistryFiller<T> filler = Mvx.Resolve<IMvxNamedInstanceRegistryFiller<T>>();
				registry.Fill(filler, assemblies);
			}
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IMvxNamedInstanceRegistryFiller<T> filler, IEnumerable<Assembly> assemblies)
		{
			if (assemblies == null)
			{
				return;
			}
			foreach (Assembly assembly in assemblies)
			{
				registry.Fill(filler, assembly);
			}
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, Assembly assembly)
		{
			IMvxNamedInstanceRegistryFiller<T> filler = Mvx.Resolve<IMvxNamedInstanceRegistryFiller<T>>();
			registry.Fill(filler, assembly);
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IMvxNamedInstanceRegistryFiller<T> filler, Assembly assembly)
		{
			filler.FillFrom(registry, assembly);
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IEnumerable<Type> types)
		{
			if (types != null)
			{
				IMvxNamedInstanceRegistryFiller<T> filler = Mvx.Resolve<IMvxNamedInstanceRegistryFiller<T>>();
				registry.Fill(filler, types);
			}
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IMvxNamedInstanceRegistryFiller<T> filler, IEnumerable<Type> types)
		{
			if (types == null)
			{
				return;
			}
			foreach (Type type in types)
			{
				registry.Fill(filler, type);
			}
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, IMvxNamedInstanceRegistryFiller<T> filler, Type type)
		{
			filler.FillFrom(registry, type);
		}

		public static void Fill<T>(this IMvxNamedInstanceRegistry<T> registry, Type type)
		{
			IMvxNamedInstanceRegistryFiller<T> filler = Mvx.Resolve<IMvxNamedInstanceRegistryFiller<T>>();
			registry.Fill(filler, type);
		}
	}
	public class MvxFromTextBinder : IMvxBinder
	{
		public IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, string bindingText)
		{
			IEnumerable<MvxBindingDescription> bindingDescriptions = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.Parse(bindingText);
			return Bind(source, target, bindingDescriptions);
		}

		public IEnumerable<IMvxUpdateableBinding> LanguageBind(object source, object target, string bindingText)
		{
			IEnumerable<MvxBindingDescription> bindingDescriptions = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.LanguageParse(bindingText);
			return Bind(source, target, bindingDescriptions);
		}

		public IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, IEnumerable<MvxBindingDescription> bindingDescriptions)
		{
			if (bindingDescriptions == null)
			{
				return new IMvxUpdateableBinding[0];
			}
			return bindingDescriptions.Select((MvxBindingDescription description) => BindSingle(new MvxBindingRequest(source, target, description)));
		}

		public IMvxUpdateableBinding BindSingle(object source, object target, string targetPropertyName, string partialBindingDescription)
		{
			MvxBindingDescription mvxBindingDescription = MvxSingleton<IMvxBindingSingletonCache>.Instance.BindingDescriptionParser.ParseSingle(partialBindingDescription);
			if (mvxBindingDescription == null)
			{
				return null;
			}
			mvxBindingDescription.TargetName = targetPropertyName;
			MvxBindingRequest bindingRequest = new MvxBindingRequest(source, target, mvxBindingDescription);
			return BindSingle(bindingRequest);
		}

		public IMvxUpdateableBinding BindSingle(MvxBindingRequest bindingRequest)
		{
			return new MvxFullBinding(bindingRequest);
		}
	}
	public class MvxValueConverterRegistry : MvxNamedInstanceRegistry<IMvxValueConverter>, IMvxValueConverterLookup, IMvxNamedInstanceLookup<IMvxValueConverter>, IMvxValueConverterRegistry, IMvxNamedInstanceRegistry<IMvxValueConverter>
	{
	}
	public interface IMvxBindingDescriptionParser
	{
		IEnumerable<MvxBindingDescription> Parse(string text);

		IEnumerable<MvxBindingDescription> LanguageParse(string text);

		MvxBindingDescription ParseSingle(string text);

		MvxBindingDescription SerializableBindingToBinding(string targetName, MvxSerializableBindingDescription description);
	}
	public interface IMvxNamedInstanceLookup<out T>
	{
		T Find(string name);
	}
	public interface IMvxValueConverterLookup : IMvxNamedInstanceLookup<IMvxValueConverter>
	{
	}
	public interface IMvxBinder
	{
		IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, string bindingText);

		IEnumerable<IMvxUpdateableBinding> LanguageBind(object source, object target, string bindingText);

		IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, IEnumerable<MvxBindingDescription> bindingDescriptions);

		IMvxUpdateableBinding BindSingle(object source, object target, string targetPropertyName, string partialBindingDescription);

		IMvxUpdateableBinding BindSingle(MvxBindingRequest bindingRequest);
	}
}
namespace MvvmCross.Binding.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class MvxSetToNullAfterBindingAttribute : Attribute
	{
	}
}
