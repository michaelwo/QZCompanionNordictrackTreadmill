using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Parse.StringDictionary;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.ExtensionMethods;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Parse;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Core")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Core
{
	public interface IMvxSingletonCache
	{
		IMvxSettings Settings { get; }

		IMvxInpcInterceptor InpcInterceptor { get; }

		IMvxStringToTypeParser Parser { get; }
	}
	public class MvxSingletonCache : MvxSingleton<IMvxSingletonCache>, IMvxSingletonCache
	{
		private bool _inpcInterceptorResolveAttempted;

		private IMvxInpcInterceptor _inpcInterceptor;

		private IMvxStringToTypeParser _parser;

		private IMvxSettings _settings;

		public IMvxInpcInterceptor InpcInterceptor
		{
			get
			{
				if (_inpcInterceptorResolveAttempted)
				{
					return _inpcInterceptor;
				}
				Mvx.TryResolve<IMvxInpcInterceptor>(out _inpcInterceptor);
				_inpcInterceptorResolveAttempted = true;
				return _inpcInterceptor;
			}
		}

		public IMvxStringToTypeParser Parser
		{
			get
			{
				_parser = _parser ?? Mvx.Resolve<IMvxStringToTypeParser>();
				return _parser;
			}
		}

		public IMvxSettings Settings
		{
			get
			{
				_settings = _settings ?? Mvx.Resolve<IMvxSettings>();
				return _settings;
			}
		}

		public static MvxSingletonCache Initialize()
		{
			if (MvxSingleton<IMvxSingletonCache>.Instance != null)
			{
				throw new MvxException("You should only initialize MvxBindingSingletonCache once");
			}
			return new MvxSingletonCache();
		}

		private MvxSingletonCache()
		{
		}
	}
}
namespace MvvmCross.Core.Views
{
	public interface IMvxViewPresenter
	{
		void Show(MvxViewModelRequest request);

		void ChangePresentation(MvxPresentationHint hint);

		void AddPresentationHintHandler<THint>(Func<THint, bool> action) where THint : MvxPresentationHint;
	}
	public static class MvxViewExtensionMethods
	{
		public static void OnViewCreate(this IMvxView view, Func<IMvxViewModel> viewModelLoader)
		{
			if (view.DataContext == null && view.ViewModel == null)
			{
				IMvxViewModel mvxViewModel = viewModelLoader();
				if (mvxViewModel == null)
				{
					MvxTrace.Warning("ViewModel not loaded for view {0}", view.GetType().Name);
				}
				else
				{
					view.ViewModel = mvxViewModel;
				}
			}
		}

		public static void OnViewNewIntent(this IMvxView view, Func<IMvxViewModel> viewModelLoader)
		{
			MvxTrace.Warning("OnViewNewIntent isn't well understood or tested inside MvvmCross - it's not really a cross-platform concept.");
			throw new MvxException("OnViewNewIntent is not implemented");
		}

		public static void OnViewDestroy(this IMvxView view)
		{
		}

		public static Type FindAssociatedViewModelTypeOrNull(this IMvxView view)
		{
			if (view == null)
			{
				return null;
			}
			if (!Mvx.TryResolve<IMvxViewModelTypeFinder>(out var service))
			{
				MvxTrace.Trace("No view model type finder available - assuming we are looking for a splash screen - returning null");
				return typeof(MvxNullViewModel);
			}
			return service.FindTypeOrNull(view.GetType());
		}

		public static IMvxViewModel ReflectionGetViewModel(this IMvxView view)
		{
			PropertyInfo obj = ((view != null) ? ReflectionExtensions.GetProperty(view.GetType(), "ViewModel") : null);
			return (IMvxViewModel)(((object)obj != null) ? ReflectionExtensions.GetGetMethod(obj).Invoke(view, new object[0]) : null);
		}

		public static IMvxBundle CreateSaveStateBundle(this IMvxView view)
		{
			IMvxViewModel viewModel = view.ViewModel;
			if (viewModel == null)
			{
				return new MvxBundle();
			}
			return viewModel.SaveStateBundle();
		}
	}
	public interface IMvxView : IMvxDataConsumer
	{
		IMvxViewModel ViewModel { get; set; }
	}
	public interface IMvxView<TViewModel> : IMvxView, IMvxDataConsumer where TViewModel : class, IMvxViewModel
	{
		new TViewModel ViewModel { get; set; }
	}
	public interface IMvxViewDispatcher : IMvxMainThreadDispatcher
	{
		bool ShowViewModel(MvxViewModelRequest request);

		bool ChangePresentation(MvxPresentationHint hint);
	}
	public interface IMvxViewFinder
	{
		Type GetViewType(Type viewModelType);
	}
	public interface IMvxViewsContainer : IMvxViewFinder
	{
		void AddAll(IDictionary<Type, Type> viewModelViewLookup);

		void Add(Type viewModelType, Type viewType);

		void Add<TViewModel, TView>() where TViewModel : IMvxViewModel where TView : IMvxView;

		void AddSecondary(IMvxViewFinder finder);

		void SetLastResort(IMvxViewFinder finder);
	}
	public abstract class MvxViewPresenter : IMvxViewPresenter
	{
		private readonly Dictionary<Type, Func<MvxPresentationHint, bool>> _presentationHintHandlers = new Dictionary<Type, Func<MvxPresentationHint, bool>>();

		public void AddPresentationHintHandler<THint>(Func<THint, bool> action) where THint : MvxPresentationHint
		{
			_presentationHintHandlers[typeof(THint)] = (MvxPresentationHint hint) => action((THint)hint);
		}

		protected bool HandlePresentationChange(MvxPresentationHint hint)
		{
			if (_presentationHintHandlers.TryGetValue(hint.GetType(), out var value) && value(hint))
			{
				return true;
			}
			return false;
		}

		public abstract void Show(MvxViewModelRequest request);

		public abstract void ChangePresentation(MvxPresentationHint hint);
	}
	public abstract class MvxViewsContainer : IMvxViewsContainer, IMvxViewFinder
	{
		private readonly Dictionary<Type, Type> _bindingMap = new Dictionary<Type, Type>();

		private readonly List<IMvxViewFinder> _secondaryViewFinders;

		private IMvxViewFinder _lastResortViewFinder;

		protected MvxViewsContainer()
		{
			_secondaryViewFinders = new List<IMvxViewFinder>();
		}

		public void AddAll(IDictionary<Type, Type> lookup)
		{
			foreach (KeyValuePair<Type, Type> item in lookup)
			{
				Add(item.Key, item.Value);
			}
		}

		public void Add(Type viewModelType, Type viewType)
		{
			_bindingMap[viewModelType] = viewType;
		}

		public void Add<TViewModel, TView>() where TViewModel : IMvxViewModel where TView : IMvxView
		{
			Add(typeof(TViewModel), typeof(TView));
		}

		public Type GetViewType(Type viewModelType)
		{
			if (_bindingMap.TryGetValue(viewModelType, out var value))
			{
				return value;
			}
			foreach (IMvxViewFinder secondaryViewFinder in _secondaryViewFinders)
			{
				value = secondaryViewFinder.GetViewType(viewModelType);
				if ((object)value != null)
				{
					return value;
				}
			}
			if (_lastResortViewFinder != null)
			{
				value = _lastResortViewFinder.GetViewType(viewModelType);
				if ((object)value != null)
				{
					return value;
				}
			}
			throw new KeyNotFoundException("Could not find view for " + viewModelType);
		}

		public void AddSecondary(IMvxViewFinder finder)
		{
			_secondaryViewFinders.Add(finder);
		}

		public void SetLastResort(IMvxViewFinder finder)
		{
			_lastResortViewFinder = finder;
		}
	}
}
namespace MvvmCross.Core.ViewModels
{
	public interface IMvxAsyncCommand : IMvxCommand, ICommand
	{
		Task ExecuteAsync(object parameter = null);

		void Cancel();
	}
	public interface IMvxCommandCollection
	{
		IMvxCommand this[string name] { get; }
	}
	public interface IMvxCommandCollectionBuilder
	{
		IMvxCommandCollection BuildCollectionFor(object owner);
	}
	public interface IMvxInpcInterceptor
	{
		MvxInpcInterceptionResult Intercept(IMvxNotifyPropertyChanged sender, PropertyChangedEventArgs args);
	}
	public interface IMvxInteraction
	{
		event EventHandler Requested;
	}
	public interface IMvxInteraction<T>
	{
		event EventHandler<MvxValueEventArgs<T>> Requested;
	}
	public interface IMvxNameMapping
	{
		string Map(string inputName);
	}
	public interface IMvxNotifyPropertyChanged : INotifyPropertyChanged
	{
		bool ShouldAlwaysRaiseInpcOnUserInterfaceThread();

		void ShouldAlwaysRaiseInpcOnUserInterfaceThread(bool value);

		void RaisePropertyChanged<T>(Expression<Func<T>> property);

		void RaisePropertyChanged(string whichProperty);

		void RaisePropertyChanged(PropertyChangedEventArgs changedArgs);
	}
	public interface IMvxTypeFinder
	{
		Type FindTypeOrNull(Type candidateType);
	}
	public interface IMvxViewModelByNameRegistry
	{
		void Add(Type viewModelType);

		void Add<TViewModel>() where TViewModel : IMvxViewModel;

		void AddAll(Assembly assembly);
	}
	public interface IMvxViewModelInitializer<TInit> : IMvxViewModel
	{
		Task Init(string parameter);
	}
	public interface IMvxViewModelTypeFinder : IMvxTypeFinder
	{
	}
	public interface IMvxTypeToTypeLookupBuilder
	{
		IDictionary<Type, Type> Build(IEnumerable<Assembly> sourceAssemblies);
	}
	public interface IMvxViewModelByNameLookup
	{
		bool TryLookupByName(string name, out Type viewModelType);

		bool TryLookupByFullName(string name, out Type viewModelType);
	}
	public abstract class MvxAsyncCommandBase : MvxCommandBase
	{
		private readonly object _syncRoot = new object();

		private readonly bool _allowConcurrentExecutions;

		private CancellationTokenSource _cts;

		private int _concurrentExecutions;

		public bool IsRunning => _concurrentExecutions > 0;

		protected CancellationToken CancelToken => _cts.Token;

		protected MvxAsyncCommandBase(bool allowConcurrentExecutions = false)
		{
			_allowConcurrentExecutions = allowConcurrentExecutions;
		}

		protected abstract bool CanExecuteImpl(object parameter);

		protected abstract Task ExecuteAsyncImpl(object parameter);

		public void Cancel()
		{
			lock (_syncRoot)
			{
				if (_cts == null)
				{
					Mvx.Trace(MvxTraceLevel.Warning, "MvxAsyncCommand : Attempt to cancel a task that is not running");
				}
				else
				{
					_cts.Cancel();
				}
			}
		}

		public bool CanExecute()
		{
			return CanExecute(null);
		}

		public bool CanExecute(object parameter)
		{
			if (!_allowConcurrentExecutions && IsRunning)
			{
				return false;
			}
			return CanExecuteImpl(parameter);
		}

		public async void Execute(object parameter)
		{
			try
			{
				await ExecuteAsync(parameter, hideCanceledException: true).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, "MvxAsyncCommand : exception executing task : ", ex);
				throw;
			}
		}

		public void Execute()
		{
			Execute(null);
		}

		protected async Task ExecuteAsync(object parameter, bool hideCanceledException)
		{
			if (CanExecuteImpl(parameter))
			{
				await ExecuteConcurrentAsync(parameter, hideCanceledException).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private async Task ExecuteConcurrentAsync(object parameter, bool hideCanceledException)
		{
			bool started = false;
			try
			{
				lock (_syncRoot)
				{
					if (_concurrentExecutions == 0)
					{
						InitCancellationTokenSource();
					}
					else if (!_allowConcurrentExecutions)
					{
						Mvx.Trace(MvxTraceLevel.Diagnostic, "MvxAsyncCommand : execute ignored, already running.");
						return;
					}
					_concurrentExecutions++;
					started = true;
				}
				if (!_allowConcurrentExecutions)
				{
					RaiseCanExecuteChanged();
				}
				if (CancelToken.IsCancellationRequested)
				{
					return;
				}
				try
				{
					await ExecuteAsyncImpl(parameter).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException ex)
				{
					Mvx.Trace(MvxTraceLevel.Diagnostic, "MvxAsyncCommand : OperationCanceledException");
					if (!hideCanceledException || ex.CancellationToken != CancelToken)
					{
						throw;
					}
				}
			}
			finally
			{
				if (started)
				{
					lock (_syncRoot)
					{
						_concurrentExecutions--;
						if (_concurrentExecutions == 0)
						{
							ClearCancellationTokenSource();
						}
					}
					if (!_allowConcurrentExecutions)
					{
						RaiseCanExecuteChanged();
					}
				}
			}
		}

		private void ClearCancellationTokenSource()
		{
			if (_cts == null)
			{
				Mvx.Error("MvxAsyncCommand : Unexpected ClearCancellationTokenSource, no token available!");
				return;
			}
			_cts.Dispose();
			_cts = null;
		}

		private void InitCancellationTokenSource()
		{
			if (_cts != null)
			{
				Mvx.Error("MvxAsyncCommand : Unexpected InitCancellationTokenSource, a token is already available!");
			}
			_cts = new CancellationTokenSource();
		}
	}
	public class MvxAsyncCommand : MvxAsyncCommandBase, IMvxAsyncCommand, IMvxCommand, ICommand
	{
		private readonly Func<CancellationToken, Task> _execute;

		private readonly Func<bool> _canExecute;

		public MvxAsyncCommand(Func<Task> execute, Func<bool> canExecute = null, bool allowConcurrentExecutions = false)
			: base(allowConcurrentExecutions)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			_execute = (CancellationToken cancellationToken) => execute();
			_canExecute = canExecute;
		}

		public MvxAsyncCommand(Func<CancellationToken, Task> execute, Func<bool> canExecute = null, bool allowConcurrentExecutions = false)
			: base(allowConcurrentExecutions)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			_execute = execute;
			_canExecute = canExecute;
		}

		protected override bool CanExecuteImpl(object parameter)
		{
			if (_canExecute != null)
			{
				return _canExecute();
			}
			return true;
		}

		protected override Task ExecuteAsyncImpl(object parameter)
		{
			return _execute(base.CancelToken);
		}

		public static MvxAsyncCommand<T> CreateCommand<T>(Func<T, Task> execute, Func<T, bool> canExecute = null, bool allowConcurrentExecutions = false)
		{
			return new MvxAsyncCommand<T>(execute, canExecute, allowConcurrentExecutions);
		}

		public static MvxAsyncCommand<T> CreateCommand<T>(Func<T, CancellationToken, Task> execute, Func<T, bool> canExecute = null, bool allowConcurrentExecutions = false)
		{
			return new MvxAsyncCommand<T>(execute, canExecute, allowConcurrentExecutions);
		}

		public async Task ExecuteAsync(object parameter = null)
		{
			await ExecuteAsync(parameter, hideCanceledException: false).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public class MvxAsyncCommand<T> : MvxAsyncCommandBase, IMvxAsyncCommand, IMvxCommand, ICommand
	{
		private readonly Func<T, CancellationToken, Task> _execute;

		private readonly Func<T, bool> _canExecute;

		public MvxAsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, bool allowConcurrentExecutions = false)
			: base(allowConcurrentExecutions)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			_execute = (T p, CancellationToken c) => execute(p);
			_canExecute = canExecute;
		}

		public MvxAsyncCommand(Func<T, CancellationToken, Task> execute, Func<T, bool> canExecute = null, bool allowConcurrentExecutions = false)
			: base(allowConcurrentExecutions)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			_execute = execute;
			_canExecute = canExecute;
		}

		protected override bool CanExecuteImpl(object parameter)
		{
			if (_canExecute != null)
			{
				return _canExecute((T)typeof(T).MakeSafeValueCore(parameter));
			}
			return true;
		}

		protected override Task ExecuteAsyncImpl(object parameter)
		{
			return _execute((T)typeof(T).MakeSafeValueCore(parameter), base.CancelToken);
		}

		public async Task ExecuteAsync(object parameter)
		{
			await ExecuteAsync(parameter, hideCanceledException: false).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public class MvxInteraction : IMvxInteraction
	{
		public event EventHandler Requested;

		public void Raise()
		{
			this.Requested.Raise(this);
		}
	}
	public class MvxInteraction<T> : IMvxInteraction<T>
	{
		public event EventHandler<MvxValueEventArgs<T>> Requested;

		public void Raise(T request)
		{
			this.Requested.Raise(this, request);
		}
	}
	public static class MvxInteractionExtensionMethods
	{
		public static IDisposable WeakSubscribe(this IMvxInteraction interaction, EventHandler<EventArgs> action)
		{
			return ReflectionExtensions.GetEvent(interaction.GetType(), "Requested").WeakSubscribe(interaction, action);
		}

		public static MvxValueEventSubscription<T> WeakSubscribe<T>(this IMvxInteraction<T> interaction, EventHandler<MvxValueEventArgs<T>> action)
		{
			return ReflectionExtensions.GetEvent(interaction.GetType(), "Requested").WeakSubscribe(interaction, action);
		}

		public static MvxValueEventSubscription<T> WeakSubscribe<T>(this IMvxInteraction<T> interaction, Action<T> action)
		{
			EventHandler<MvxValueEventArgs<T>> action2 = delegate(object sender, MvxValueEventArgs<T> args)
			{
				action(args.Value);
			};
			return interaction.WeakSubscribe(action2);
		}
	}
	public static class MvxNotifyPropertyChangedExtensions
	{
		private static TReturn RaiseAndSetIfChanged<TSource, TReturn, TActionParameter>(TSource source, ref TReturn backingField, TReturn newValue, Action<TActionParameter> raiseAction, TActionParameter raiseActionParameter) where TSource : IMvxNotifyPropertyChanged
		{
			if (!EqualityComparer<TReturn>.Default.Equals(backingField, newValue))
			{
				backingField = newValue;
				raiseAction(raiseActionParameter);
			}
			return newValue;
		}

		public static TReturn RaiseAndSetIfChanged<TSource, TReturn>(this TSource source, ref TReturn backingField, TReturn newValue, Expression<Func<TReturn>> propertySelector) where TSource : IMvxNotifyPropertyChanged
		{
			return RaiseAndSetIfChanged(source, ref backingField, newValue, ((IMvxNotifyPropertyChanged)source).RaisePropertyChanged<TReturn>, propertySelector);
		}

		public static TReturn RaiseAndSetIfChanged<TSource, TReturn>(this TSource source, ref TReturn backingField, TReturn newValue, [CallerMemberName] string propertyName = "") where TSource : IMvxNotifyPropertyChanged
		{
			return RaiseAndSetIfChanged(source, ref backingField, newValue, ((IMvxNotifyPropertyChanged)source).RaisePropertyChanged, propertyName);
		}

		public static TReturn RaiseAndSetIfChanged<TSource, TReturn>(this TSource source, ref TReturn backingField, TReturn newValue, PropertyChangedEventArgs args) where TSource : IMvxNotifyPropertyChanged
		{
			return RaiseAndSetIfChanged(source, ref backingField, newValue, ((IMvxNotifyPropertyChanged)source).RaisePropertyChanged, args);
		}
	}
	public class MvxPostfixAwareViewToViewModelNameMapping : MvxViewToViewModelNameMapping
	{
		private readonly string[] _postfixes;

		public MvxPostfixAwareViewToViewModelNameMapping(params string[] postfixes)
		{
			_postfixes = postfixes;
		}

		public override string Map(string inputName)
		{
			string[] postfixes = _postfixes;
			foreach (string text in postfixes)
			{
				if (inputName.EndsWith(text) && inputName.Length > text.Length)
				{
					inputName = inputName.Substring(0, inputName.Length - text.Length);
					break;
				}
			}
			return base.Map(inputName);
		}
	}
	public class MvxPropertyChangedListener : IDisposable
	{
		private readonly Dictionary<string, List<PropertyChangedEventHandler>> _handlersLookup = new Dictionary<string, List<PropertyChangedEventHandler>>();

		private readonly INotifyPropertyChanged _notificationObject;

		private readonly MvxNotifyPropertyChangedEventSubscription _token;

		public MvxPropertyChangedListener(INotifyPropertyChanged notificationObject)
		{
			if (notificationObject == null)
			{
				throw new ArgumentNullException("notificationObject");
			}
			_notificationObject = notificationObject;
			_token = _notificationObject.WeakSubscribe(NotificationObjectOnPropertyChanged);
		}

		public virtual void NotificationObjectOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			string propertyName = propertyChangedEventArgs.PropertyName;
			List<PropertyChangedEventHandler> value = null;
			if (string.IsNullOrEmpty(propertyName))
			{
				value = _handlersLookup.Values.SelectMany((List<PropertyChangedEventHandler> x) => x).ToList();
			}
			else if (!_handlersLookup.TryGetValue(propertyName, out value))
			{
				return;
			}
			foreach (PropertyChangedEventHandler item in value)
			{
				item(sender, propertyChangedEventArgs);
			}
		}

		~MvxPropertyChangedListener()
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
			if (isDisposing)
			{
				_token.Dispose();
				Clear();
			}
		}

		public void Clear()
		{
			_handlersLookup.Clear();
		}

		public MvxPropertyChangedListener Listen<TProperty>(Expression<Func<TProperty>> property, Action handler)
		{
			return Listen(property, (PropertyChangedEventHandler)delegate
			{
				handler();
			});
		}

		public MvxPropertyChangedListener Listen<TProperty>(Expression<Func<TProperty>> propertyExpression, PropertyChangedEventHandler handler)
		{
			string propertyNameFromExpression = _notificationObject.GetPropertyNameFromExpression(propertyExpression);
			return Listen(propertyNameFromExpression, handler);
		}

		public MvxPropertyChangedListener Listen(string propertyName, Action handler)
		{
			return Listen(propertyName, (PropertyChangedEventHandler)delegate
			{
				handler();
			});
		}

		public MvxPropertyChangedListener Listen(string propertyName, PropertyChangedEventHandler handler)
		{
			List<PropertyChangedEventHandler> value = null;
			if (!_handlersLookup.TryGetValue(propertyName, out value))
			{
				value = new List<PropertyChangedEventHandler>();
				_handlersLookup.Add(propertyName, value);
			}
			value.Add(handler);
			return this;
		}
	}
	public enum MvxInpcInterceptionResult
	{
		NotIntercepted,
		RaisePropertyChanged,
		DoNotRaisePropertyChanged
	}
	public class MvxViewToViewModelNameMapping : IMvxNameMapping
	{
		public string ViewModelPostfix { get; set; }

		public MvxViewToViewModelNameMapping()
		{
			ViewModelPostfix = "ViewModel";
		}

		public virtual string Map(string inputName)
		{
			return inputName + ViewModelPostfix;
		}
	}
	public class MvxClosePresentationHint : MvxPresentationHint
	{
		public IMvxViewModel ViewModelToClose { get; private set; }

		public MvxClosePresentationHint(IMvxViewModel viewModelToClose)
		{
			ViewModelToClose = viewModelToClose;
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public class MvxCommandAttribute : Attribute
	{
		public string CommandName { get; set; }

		public string CanExecutePropertyName { get; set; }

		public MvxCommandAttribute(string commandName, string canExecutePropertyName = null)
		{
			CanExecutePropertyName = canExecutePropertyName;
			CommandName = commandName;
		}
	}
	public class MvxCommandCollectionBuilder : IMvxCommandCollectionBuilder
	{
		public interface IMvxCommandBuilder
		{
			string CanExecutePropertyName { get; }

			IMvxCommand ToCommand(object owner);
		}

		public abstract class MvxBaseCommandBuilder : IMvxCommandBuilder
		{
			private readonly MethodInfo _executeMethodInfo;

			private readonly PropertyInfo _canExecutePropertyInfo;

			protected MethodInfo ExecuteMethodInfo => _executeMethodInfo;

			protected PropertyInfo CanExecutePropertyInfo => _canExecutePropertyInfo;

			public string CanExecutePropertyName => _canExecutePropertyInfo?.Name;

			protected MvxBaseCommandBuilder(MethodInfo executeMethodInfo, PropertyInfo canExecutePropertyInfo)
			{
				_executeMethodInfo = executeMethodInfo;
				_canExecutePropertyInfo = canExecutePropertyInfo;
			}

			public abstract IMvxCommand ToCommand(object owner);
		}

		public class MvxCommandBuilder : MvxBaseCommandBuilder
		{
			public MvxCommandBuilder(MethodInfo executeMethodInfo, PropertyInfo canExecutePropertyInfo)
				: base(executeMethodInfo, canExecutePropertyInfo)
			{
			}

			public override IMvxCommand ToCommand(object owner)
			{
				Action execute = delegate
				{
					base.ExecuteMethodInfo.Invoke(owner, new object[0]);
				};
				Func<bool> canExecute = null;
				if ((object)base.CanExecutePropertyInfo != null)
				{
					canExecute = () => (bool)base.CanExecutePropertyInfo.GetValue(owner, null);
				}
				return new MvxCommand(execute, canExecute);
			}
		}

		public class MvxParameterizedCommandBuilder : MvxBaseCommandBuilder
		{
			public MvxParameterizedCommandBuilder(MethodInfo executeMethodInfo, PropertyInfo canExecutePropertyInfo)
				: base(executeMethodInfo, canExecutePropertyInfo)
			{
			}

			public override IMvxCommand ToCommand(object owner)
			{
				Action<object> execute = delegate(object obj)
				{
					base.ExecuteMethodInfo.Invoke(owner, new object[1] { obj });
				};
				Func<object, bool> canExecute = null;
				if ((object)base.CanExecutePropertyInfo != null)
				{
					canExecute = (object ignored) => (bool)base.CanExecutePropertyInfo.GetValue(owner, null);
				}
				return new MvxCommand<object>(execute, canExecute);
			}
		}

		private const string DefaultCommandSuffix = "Command";

		private const string DefaultCanExecutePrefix = "CanExecute";

		public string CommandSuffix { get; set; }

		public IEnumerable<string> AdditionalCommandSuffixes { get; set; }

		public string CanExecutePrefix { get; set; }

		public MvxCommandCollectionBuilder()
		{
			CanExecutePrefix = "CanExecute";
			CommandSuffix = "Command";
			AdditionalCommandSuffixes = null;
		}

		public virtual IMvxCommandCollection BuildCollectionFor(object owner)
		{
			MvxCommandCollection mvxCommandCollection = new MvxCommandCollection(owner);
			CreateCommands(owner, mvxCommandCollection);
			return mvxCommandCollection;
		}

		protected virtual void CreateCommands(object owner, MvxCommandCollection toReturn)
		{
			foreach (var item in from method in owner.GetType().GetMethods(MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy)
				let parameterCount = method.GetParameters().Count()
				where parameterCount <= 1
				let commandName = GetCommandNameOrNull(method)
				where !string.IsNullOrEmpty(commandName)
				select new
				{
					Method = method,
					CommandName = commandName,
					HasParameter = (parameterCount > 0)
				})
			{
				CreateCommand(owner, toReturn, item.Method, item.CommandName, item.HasParameter);
			}
		}

		protected virtual void CreateCommand(object owner, MvxCommandCollection collection, MethodInfo commandMethod, string commandName, bool hasParameter)
		{
			PropertyInfo canExecutePropertyInfo = CanExecutePropertyInfo(owner.GetType(), commandMethod);
			IMvxCommandBuilder mvxCommandBuilder2;
			if (!hasParameter)
			{
				IMvxCommandBuilder mvxCommandBuilder = new MvxCommandBuilder(commandMethod, canExecutePropertyInfo);
				mvxCommandBuilder2 = mvxCommandBuilder;
			}
			else
			{
				IMvxCommandBuilder mvxCommandBuilder = new MvxParameterizedCommandBuilder(commandMethod, canExecutePropertyInfo);
				mvxCommandBuilder2 = mvxCommandBuilder;
			}
			IMvxCommandBuilder mvxCommandBuilder3 = mvxCommandBuilder2;
			IMvxCommand command = mvxCommandBuilder3.ToCommand(owner);
			collection.Add(command, commandName, mvxCommandBuilder3.CanExecutePropertyName);
		}

		protected virtual PropertyInfo CanExecutePropertyInfo(Type type, MethodInfo commandMethod)
		{
			string text = CanExecuteProperyName(commandMethod);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			PropertyInfo property = type.GetProperty(text, MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy);
			if ((object)property == null)
			{
				return null;
			}
			if ((object)property.PropertyType != typeof(bool))
			{
				return null;
			}
			if (!property.CanRead)
			{
				return null;
			}
			return property;
		}

		protected virtual string GetCommandNameOrNull(MethodInfo method)
		{
			MvxCommandAttribute mvxCommandAttribute = CommandAttribute(method);
			if (mvxCommandAttribute != null)
			{
				return mvxCommandAttribute.CommandName;
			}
			string conventionalCommandNameOrNull = GetConventionalCommandNameOrNull(method, CommandSuffix);
			if (conventionalCommandNameOrNull != null)
			{
				return conventionalCommandNameOrNull;
			}
			if (AdditionalCommandSuffixes != null)
			{
				foreach (string additionalCommandSuffix in AdditionalCommandSuffixes)
				{
					conventionalCommandNameOrNull = GetConventionalCommandNameOrNull(method, additionalCommandSuffix);
					if (conventionalCommandNameOrNull != null)
					{
						return conventionalCommandNameOrNull;
					}
				}
			}
			return null;
		}

		protected virtual string GetConventionalCommandNameOrNull(MethodInfo method, string suffix)
		{
			if (!method.Name.EndsWith(suffix))
			{
				return null;
			}
			int num = method.Name.Length - suffix.Length;
			if (num <= 0)
			{
				return null;
			}
			return method.Name.Substring(0, num);
		}

		protected MvxCommandAttribute CommandAttribute(MethodInfo method)
		{
			return (MvxCommandAttribute)CustomAttributeExtensions.GetCustomAttributes(method, typeof(MvxCommandAttribute), inherit: true).FirstOrDefault();
		}

		protected virtual string CanExecuteProperyName(MethodInfo method)
		{
			MvxCommandAttribute mvxCommandAttribute = CommandAttribute(method);
			if (mvxCommandAttribute != null)
			{
				return mvxCommandAttribute.CanExecutePropertyName;
			}
			return CanExecutePrefix + method.Name;
		}
	}
	public abstract class MvxPresentationHint
	{
		public MvxBundle Body { get; private set; }

		protected MvxPresentationHint()
			: this(new MvxBundle())
		{
		}

		protected MvxPresentationHint(MvxBundle body)
		{
			Body = body;
		}

		protected MvxPresentationHint(IDictionary<string, string> hints)
			: this(new MvxBundle(hints))
		{
		}
	}
	public class MvxStringDictionaryNavigationSerializer : IMvxNavigationSerializer
	{
		public IMvxTextSerializer Serializer => new MvxViewModelRequestCustomTextSerializer();
	}
	public class MvxViewModelViewTypeFinder : IMvxViewModelTypeFinder, IMvxTypeFinder
	{
		private readonly IMvxViewModelByNameLookup _viewModelByNameLookup;

		private readonly IMvxNameMapping _viewToViewModelNameMapping;

		public MvxViewModelViewTypeFinder(IMvxViewModelByNameLookup viewModelByNameLookup, IMvxNameMapping viewToViewModelNameMapping)
		{
			_viewModelByNameLookup = viewModelByNameLookup;
			_viewToViewModelNameMapping = viewToViewModelNameMapping;
		}

		public virtual Type FindTypeOrNull(Type candidateType)
		{
			if (!CheckCandidateTypeIsAView(candidateType))
			{
				return null;
			}
			if (!candidateType.IsConventional())
			{
				return null;
			}
			Type type = LookupAttributedViewModelType(candidateType);
			if ((object)type != null)
			{
				return type;
			}
			Type type2 = LookupAssociatedConcreteViewModelType(candidateType);
			if ((object)type2 != null)
			{
				return type2;
			}
			Type type3 = LookupNamedViewModelType(candidateType);
			if ((object)type3 != null)
			{
				return type3;
			}
			MvxTrace.Trace("No view model association found for candidate view {0}", candidateType.Name);
			return null;
		}

		protected virtual Type LookupAttributedViewModelType(Type candidateType)
		{
			return (ReflectionExtensions.GetCustomAttributes(candidateType, typeof(MvxViewForAttribute), inherit: false).FirstOrDefault() as MvxViewForAttribute)?.ViewModel;
		}

		protected virtual Type LookupNamedViewModelType(Type candidateType)
		{
			string name = candidateType.Name;
			string name2 = _viewToViewModelNameMapping.Map(name);
			_viewModelByNameLookup.TryLookupByName(name2, out var viewModelType);
			return viewModelType;
		}

		protected virtual Type LookupAssociatedConcreteViewModelType(Type candidateType)
		{
			return ReflectionExtensions.GetProperties(candidateType).FirstOrDefault((PropertyInfo x) => x.Name == "ViewModel" && !x.PropertyType.GetTypeInfo().IsInterface && !x.PropertyType.GetTypeInfo().IsAbstract)?.PropertyType;
		}

		protected virtual bool CheckCandidateTypeIsAView(Type candidateType)
		{
			if ((object)candidateType == null)
			{
				return false;
			}
			if (candidateType.GetTypeInfo().IsAbstract)
			{
				return false;
			}
			if (!ReflectionExtensions.IsAssignableFrom(typeof(IMvxView), candidateType))
			{
				return false;
			}
			return true;
		}
	}
	public class MvxViewModelByNameLookup : IMvxViewModelByNameLookup, IMvxViewModelByNameRegistry
	{
		private readonly Dictionary<string, Type> _availableViewModelsByName;

		private readonly Dictionary<string, Type> _availableViewModelsByFullName;

		public MvxViewModelByNameLookup()
		{
			_availableViewModelsByName = new Dictionary<string, Type>();
			_availableViewModelsByFullName = new Dictionary<string, Type>();
		}

		public bool TryLookupByName(string name, out Type viewModelType)
		{
			return _availableViewModelsByName.TryGetValue(name, out viewModelType);
		}

		public bool TryLookupByFullName(string name, out Type viewModelType)
		{
			return _availableViewModelsByFullName.TryGetValue(name, out viewModelType);
		}

		public void Add(Type viewModelType)
		{
			_availableViewModelsByName[viewModelType.Name] = viewModelType;
			_availableViewModelsByFullName[viewModelType.FullName] = viewModelType;
		}

		public void Add<TViewModel>() where TViewModel : IMvxViewModel
		{
			Add(typeof(TViewModel));
		}

		public void AddAll(Assembly assembly)
		{
			foreach (Type item in from type in assembly.ExceptionSafeGetTypes()
				where !type.GetTypeInfo().IsAbstract
				where !type.GetTypeInfo().IsInterface
				where ReflectionExtensions.IsAssignableFrom(typeof(IMvxViewModel), type)
				select type)
			{
				Add(item);
			}
		}
	}
	public class MvxViewModelViewLookupBuilder : IMvxTypeToTypeLookupBuilder
	{
		public virtual IDictionary<Type, Type> Build(IEnumerable<Assembly> sourceAssemblies)
		{
			IMvxViewModelTypeFinder associatedTypeFinder = Mvx.Resolve<IMvxViewModelTypeFinder>();
			IEnumerable<KeyValuePair<Type, Type>> enumerable = from assembly in sourceAssemblies
				from candidateViewType in assembly.ExceptionSafeGetTypes()
				let viewModelType = associatedTypeFinder.FindTypeOrNull(candidateViewType)
				where (object)viewModelType != null
				select new KeyValuePair<Type, Type>(viewModelType, candidateViewType);
			try
			{
				return enumerable.ToDictionary((KeyValuePair<Type, Type> x) => x.Key, (KeyValuePair<Type, Type> x) => x.Value);
			}
			catch (ArgumentException exception)
			{
				throw ReportBuildProblem(enumerable, exception);
			}
		}

		private static Exception ReportBuildProblem(IEnumerable<KeyValuePair<Type, Type>> views, ArgumentException exception)
		{
			string[] array = (from x in views
				group x by x.Key into x
				select new
				{
					Name = x.Key.Name,
					Count = x.Count(),
					ViewNames = x.Select((KeyValuePair<Type, Type> v) => v.Value.Name).ToList()
				} into x
				where x.Count > 1
				select string.Format("{0}*{1} ({2})", new object[3]
				{
					x.Count,
					x.Name,
					string.Join(",", x.ViewNames)
				})).ToArray();
			if (array.Length == 0)
			{
				return exception.MvxWrap("Unknown problem in ViewModelViewLookup construction");
			}
			string text = string.Join(";", array);
			return exception.MvxWrap("Problem seen creating View-ViewModel lookup table - you have more than one View registered for the ViewModels: {0}", text);
		}
	}
	public interface IMvxCommand : ICommand
	{
		void RaiseCanExecuteChanged();

		void Execute();

		bool CanExecute();
	}
	public interface IMvxViewModelLocatorCollection
	{
		IMvxViewModelLocator FindViewModelLocator(MvxViewModelRequest request);
	}
	public abstract class MvxApplication : IMvxApplication, IMvxViewModelLocatorCollection
	{
		private IMvxViewModelLocator _defaultLocator;

		private IMvxViewModelLocator DefaultLocator
		{
			get
			{
				_defaultLocator = _defaultLocator ?? CreateDefaultViewModelLocator();
				return _defaultLocator;
			}
		}

		protected virtual IMvxViewModelLocator CreateDefaultViewModelLocator()
		{
			return new MvxDefaultViewModelLocator();
		}

		public virtual void LoadPlugins(IMvxPluginManager pluginManager)
		{
		}

		public virtual void Initialize()
		{
		}

		public IMvxViewModelLocator FindViewModelLocator(MvxViewModelRequest request)
		{
			return DefaultLocator;
		}

		protected void RegisterAppStart<TViewModel>() where TViewModel : IMvxViewModel
		{
			Mvx.RegisterSingleton((IMvxAppStart)new MvxAppStart<TViewModel>());
		}

		protected void RegisterAppStart(IMvxAppStart appStart)
		{
			Mvx.RegisterSingleton(appStart);
		}

		protected IEnumerable<Type> CreatableTypes()
		{
			return CreatableTypes(GetType().GetTypeInfo().Assembly);
		}

		protected IEnumerable<Type> CreatableTypes(Assembly assembly)
		{
			return assembly.CreatableTypes();
		}
	}
	public class MvxCommandCollection : IMvxCommandCollection
	{
		private readonly object _owner;

		private readonly Dictionary<string, IMvxCommand> _commandLookup = new Dictionary<string, IMvxCommand>();

		private readonly Dictionary<string, List<IMvxCommand>> _canExecuteLookup = new Dictionary<string, List<IMvxCommand>>();

		public IMvxCommand this[string name]
		{
			get
			{
				if (!_commandLookup.Any())
				{
					MvxTrace.Trace("MvxCommandCollection is empty - did you forget to add your commands?");
					return null;
				}
				_commandLookup.TryGetValue(name, out var value);
				return value;
			}
		}

		public MvxCommandCollection(object owner)
		{
			_owner = owner;
			SubscribeToNotifyPropertyChanged();
		}

		private void SubscribeToNotifyPropertyChanged()
		{
			if (_owner is INotifyPropertyChanged notifyPropertyChanged)
			{
				notifyPropertyChanged.PropertyChanged += OnPropertyChanged;
			}
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			if (string.IsNullOrEmpty(args.PropertyName))
			{
				RaiseAllCanExecuteChanged();
			}
			else
			{
				if (!_canExecuteLookup.TryGetValue(args.PropertyName, out var value))
				{
					return;
				}
				foreach (IMvxCommand item in value)
				{
					item.RaiseCanExecuteChanged();
				}
			}
		}

		private void RaiseAllCanExecuteChanged()
		{
			foreach (KeyValuePair<string, IMvxCommand> item in _commandLookup)
			{
				item.Value.RaiseCanExecuteChanged();
			}
		}

		public void Add(IMvxCommand command, string name, string canExecuteName)
		{
			AddToLookup(_commandLookup, command, name);
			AddToLookup(_canExecuteLookup, command, canExecuteName);
		}

		private static void AddToLookup(IDictionary<string, IMvxCommand> lookup, IMvxCommand command, string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (lookup.ContainsKey(name))
				{
					MvxTrace.Warning("Ignoring Commmand - it would overwrite the existing Command, name {0}", name);
				}
				else
				{
					lookup[name] = command;
				}
			}
		}

		private static void AddToLookup(IDictionary<string, List<IMvxCommand>> lookup, IMvxCommand command, string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (!lookup.TryGetValue(name, out var value))
				{
					value = (lookup[name] = new List<IMvxCommand>());
				}
				if (!value.Contains(command))
				{
					value.Add(command);
				}
			}
		}
	}
	public class MvxDefaultViewModelLocator : IMvxViewModelLocator
	{
		public virtual IMvxViewModel Reload(IMvxViewModel viewModel, IMvxBundle parameterValues, IMvxBundle savedState)
		{
			RunViewModelLifecycle(viewModel, parameterValues, savedState);
			return viewModel;
		}

		public virtual IMvxViewModel Load(Type viewModelType, IMvxBundle parameterValues, IMvxBundle savedState)
		{
			IMvxViewModel mvxViewModel;
			try
			{
				mvxViewModel = (IMvxViewModel)Mvx.IocConstruct(viewModelType);
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Problem creating viewModel of type {0}", viewModelType.Name);
			}
			RunViewModelLifecycle(mvxViewModel, parameterValues, savedState);
			return mvxViewModel;
		}

		protected virtual void CallCustomInitMethods(IMvxViewModel viewModel, IMvxBundle parameterValues)
		{
			viewModel.CallBundleMethods("Init", parameterValues);
		}

		protected virtual void CallReloadStateMethods(IMvxViewModel viewModel, IMvxBundle savedState)
		{
			viewModel.CallBundleMethods("ReloadState", savedState);
		}

		protected void RunViewModelLifecycle(IMvxViewModel viewModel, IMvxBundle parameterValues, IMvxBundle savedState)
		{
			try
			{
				CallCustomInitMethods(viewModel, parameterValues);
				if (savedState != null)
				{
					CallReloadStateMethods(viewModel, savedState);
				}
				viewModel.Start();
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Problem running viewModel lifecycle of type {0}", viewModel.GetType().Name);
			}
		}
	}
	public class MvxJsonNavigationSerializer : MvxNavigationSerializer<IMvxJsonConverter>
	{
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class MvxViewForAttribute : Attribute
	{
		public Type ViewModel { get; set; }

		public MvxViewForAttribute(Type viewModel)
		{
			ViewModel = viewModel;
		}
	}
	public class MvxViewModelLoader : IMvxViewModelLoader
	{
		private IMvxViewModelLocatorCollection _locatorCollection;

		protected IMvxViewModelLocatorCollection LocatorCollection
		{
			get
			{
				_locatorCollection = _locatorCollection ?? Mvx.Resolve<IMvxViewModelLocatorCollection>();
				return _locatorCollection;
			}
		}

		public IMvxViewModel ReloadViewModel(IMvxViewModel viewModel, MvxViewModelRequest request, IMvxBundle savedState)
		{
			IMvxViewModelLocator viewModelLocator = FindViewModelLocator(request);
			return ReloadViewModel(viewModel, request, savedState, viewModelLocator);
		}

		private IMvxViewModel ReloadViewModel(IMvxViewModel viewModel, MvxViewModelRequest request, IMvxBundle savedState, IMvxViewModelLocator viewModelLocator)
		{
			if (viewModelLocator == null)
			{
				throw new MvxException("Received view model is null, view model reload failed. ", request.ViewModelType);
			}
			MvxBundle parameterValues = new MvxBundle(request.ParameterValues);
			try
			{
				viewModel = viewModelLocator.Reload(viewModel, parameterValues, savedState);
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Failed to reload a previously created created ViewModel for type {0} from locator {1} - check InnerException for more information", request.ViewModelType, viewModelLocator.GetType().Name);
			}
			viewModel.RequestedBy = request.RequestedBy;
			return viewModel;
		}

		public IMvxViewModel LoadViewModel(MvxViewModelRequest request, IMvxBundle savedState)
		{
			if ((object)request.ViewModelType == typeof(MvxNullViewModel))
			{
				return new MvxNullViewModel();
			}
			IMvxViewModelLocator viewModelLocator = FindViewModelLocator(request);
			return LoadViewModel(request, savedState, viewModelLocator);
		}

		private IMvxViewModel LoadViewModel(MvxViewModelRequest request, IMvxBundle savedState, IMvxViewModelLocator viewModelLocator)
		{
			IMvxViewModel mvxViewModel = null;
			MvxBundle parameterValues = new MvxBundle(request.ParameterValues);
			try
			{
				mvxViewModel = viewModelLocator.Load(request.ViewModelType, parameterValues, savedState);
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Failed to construct and initialize ViewModel for type {0} from locator {1} - check InnerException for more information", request.ViewModelType, viewModelLocator.GetType().Name);
			}
			mvxViewModel.RequestedBy = request.RequestedBy;
			return mvxViewModel;
		}

		private IMvxViewModelLocator FindViewModelLocator(MvxViewModelRequest request)
		{
			IMvxViewModelLocator mvxViewModelLocator = LocatorCollection.FindViewModelLocator(request);
			if (mvxViewModelLocator == null)
			{
				throw new MvxException("Sorry - somehow there's no viewmodel locator registered for {0}", request.ViewModelType);
			}
			return mvxViewModelLocator;
		}
	}
	public interface IMvxNavigationSerializer
	{
		IMvxTextSerializer Serializer { get; }
	}
	public interface IMvxBundle
	{
		IDictionary<string, string> Data { get; }

		void Write(object toStore);

		T Read<T>() where T : new();

		object Read(Type type);

		IEnumerable<object> CreateArgumentList(IEnumerable<ParameterInfo> requiredParameters, string debugText);
	}
	public class MvxBundle : IMvxBundle
	{
		public IDictionary<string, string> Data { get; private set; }

		public MvxBundle()
			: this(new Dictionary<string, string>())
		{
		}

		public MvxBundle(IDictionary<string, string> data)
		{
			Data = data ?? new Dictionary<string, string>();
		}

		public void Write(object toStore)
		{
			Data.Write(toStore);
		}

		public T Read<T>() where T : new()
		{
			return Data.Read<T>();
		}

		public object Read(Type type)
		{
			return Data.Read(type);
		}

		public IEnumerable<object> CreateArgumentList(IEnumerable<ParameterInfo> requiredParameters, string debugText)
		{
			return Data.CreateArgumentList(requiredParameters, debugText);
		}
	}
	public static class MvxViewModelExtensions
	{
		public static void CallBundleMethods(this IMvxViewModel viewModel, string methodName, IMvxBundle bundle)
		{
			foreach (MethodInfo item in (from m in viewModel.GetType().GetMethods(MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy)
				where m.Name == methodName
				where !m.IsAbstract
				select m).ToList())
			{
				viewModel.CallBundleMethod(item, bundle);
			}
		}

		public static void CallBundleMethod(this IMvxViewModel viewModel, MethodInfo methodInfo, IMvxBundle bundle)
		{
			ParameterInfo[] array = methodInfo.GetParameters().ToArray();
			if (array.Count() == 1 && (object)array[0].ParameterType == typeof(IMvxBundle))
			{
				methodInfo.Invoke(viewModel, new object[1] { bundle });
			}
			else if (array.Count() == 1 && !MvxSingleton<IMvxSingletonCache>.Instance.Parser.TypeSupported(array[0].ParameterType))
			{
				object obj = bundle.Read(array[0].ParameterType);
				methodInfo.Invoke(viewModel, new object[1] { obj });
			}
			else
			{
				object[] parameters = bundle.CreateArgumentList(array, viewModel.GetType().Name).ToArray();
				methodInfo.Invoke(viewModel, parameters);
			}
		}

		public static IMvxBundle SaveStateBundle(this IMvxViewModel viewModel)
		{
			MvxBundle mvxBundle = new MvxBundle();
			foreach (MethodInfo item in from m in ReflectionExtensions.GetMethods(viewModel.GetType())
				where m.Name == "SaveState"
				where (object)m.ReturnType != typeof(void)
				where !m.GetParameters().Any()
				select m)
			{
				object obj = item.Invoke(viewModel, new object[0]);
				if (obj != null)
				{
					mvxBundle.Write(obj);
				}
			}
			viewModel.SaveState(mvxBundle);
			return mvxBundle;
		}
	}
	public interface IMvxApplication : IMvxViewModelLocatorCollection
	{
		void LoadPlugins(IMvxPluginManager pluginManager);

		void Initialize();
	}
	public interface IMvxAppStart
	{
		void Start(object hint = null);
	}
	public interface IMvxViewModel
	{
		MvxRequestedBy RequestedBy { get; set; }

		void Init(IMvxBundle parameters);

		void ReloadState(IMvxBundle state);

		void Start();

		void SaveState(IMvxBundle state);
	}
	public interface IMvxViewModelLoader
	{
		IMvxViewModel LoadViewModel(MvxViewModelRequest request, IMvxBundle savedState);

		IMvxViewModel ReloadViewModel(IMvxViewModel viewModel, MvxViewModelRequest request, IMvxBundle savedState);
	}
	public interface IMvxViewModelLocator
	{
		IMvxViewModel Load(Type viewModelType, IMvxBundle parameterValues, IMvxBundle savedState);

		IMvxViewModel Reload(IMvxViewModel viewModel, IMvxBundle parameterValues, IMvxBundle savedState);
	}
	public class MvxRequestedBy
	{
		public static MvxRequestedBy Unknown = new MvxRequestedBy(MvxRequestedByType.Unknown);

		public static MvxRequestedBy Bookmark = new MvxRequestedBy(MvxRequestedByType.Bookmark);

		public static MvxRequestedBy UserAction = new MvxRequestedBy(MvxRequestedByType.UserAction);

		public MvxRequestedByType Type { get; set; }

		public string AdditionalInfo { get; set; }

		public MvxRequestedBy()
			: this(MvxRequestedByType.Unknown)
		{
		}

		public MvxRequestedBy(MvxRequestedByType requestedByType)
			: this(requestedByType, null)
		{
		}

		public MvxRequestedBy(MvxRequestedByType requestedByType, string additionalInfo)
		{
			Type = requestedByType;
			AdditionalInfo = additionalInfo;
		}
	}
	public enum MvxRequestedByType
	{
		Unknown,
		UserAction,
		Bookmark,
		AutomatedService,
		Other
	}
	public abstract class MvxNavigatingObject : MvxNotifyPropertyChanged
	{
		protected IMvxViewDispatcher ViewDispatcher => (IMvxViewDispatcher)base.Dispatcher;

		protected bool Close(IMvxViewModel viewModel)
		{
			return ChangePresentation(new MvxClosePresentationHint(viewModel));
		}

		protected bool ChangePresentation(MvxPresentationHint hint)
		{
			MvxTrace.Trace("Requesting presentation change");
			return ViewDispatcher?.ChangePresentation(hint) ?? false;
		}

		protected bool ShowViewModel<TViewModel, TInit>(TInit parameter, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null) where TViewModel : IMvxViewModelInitializer<TInit>
		{
			if (!Mvx.TryResolve<IMvxJsonConverter>(out var service))
			{
				Mvx.Trace("Could not resolve IMvxJsonConverter, it is going to be hard to initialize with custom object");
				return false;
			}
			string value = service.SerializeObject(parameter);
			return ShowViewModel<TViewModel>(new Dictionary<string, string> { { "parameter", value } }, presentationBundle, requestedBy);
		}

		protected bool ShowViewModel<TViewModel>(object parameterValuesObject, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null) where TViewModel : IMvxViewModel
		{
			return ShowViewModel(typeof(TViewModel), parameterValuesObject.ToSimplePropertyDictionary(), presentationBundle, requestedBy);
		}

		protected bool ShowViewModel<TViewModel>(IDictionary<string, string> parameterValues, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null) where TViewModel : IMvxViewModel
		{
			return ShowViewModel(typeof(TViewModel), new MvxBundle(parameterValues.ToSimplePropertyDictionary()), presentationBundle, requestedBy);
		}

		protected bool ShowViewModel<TViewModel>(IMvxBundle parameterBundle = null, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null) where TViewModel : IMvxViewModel
		{
			return ShowViewModel(typeof(TViewModel), parameterBundle, presentationBundle, requestedBy);
		}

		protected bool ShowViewModel(Type viewModelType, object parameterValuesObject, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null)
		{
			return ShowViewModel(viewModelType, new MvxBundle(parameterValuesObject.ToSimplePropertyDictionary()), presentationBundle, requestedBy);
		}

		protected bool ShowViewModel(Type viewModelType, IDictionary<string, string> parameterValues, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null)
		{
			return ShowViewModel(viewModelType, new MvxBundle(parameterValues), presentationBundle, requestedBy);
		}

		protected bool ShowViewModel(Type viewModelType, IMvxBundle parameterBundle = null, IMvxBundle presentationBundle = null, MvxRequestedBy requestedBy = null)
		{
			return ShowViewModelImpl(viewModelType, parameterBundle, presentationBundle, requestedBy);
		}

		private bool ShowViewModelImpl(Type viewModelType, IMvxBundle parameterBundle, IMvxBundle presentationBundle, MvxRequestedBy requestedBy)
		{
			MvxTrace.Trace("Showing ViewModel {0}", viewModelType.Name);
			return ViewDispatcher?.ShowViewModel(new MvxViewModelRequest(viewModelType, parameterBundle, presentationBundle, requestedBy)) ?? false;
		}
	}
	public abstract class MvxNotifyPropertyChanged : MvxMainThreadDispatchingObject, IMvxNotifyPropertyChanged, INotifyPropertyChanged
	{
		private bool _shouldAlwaysRaiseInpcOnUserInterfaceThread;

		public event PropertyChangedEventHandler PropertyChanged;

		public bool ShouldAlwaysRaiseInpcOnUserInterfaceThread()
		{
			return _shouldAlwaysRaiseInpcOnUserInterfaceThread;
		}

		public void ShouldAlwaysRaiseInpcOnUserInterfaceThread(bool value)
		{
			_shouldAlwaysRaiseInpcOnUserInterfaceThread = value;
		}

		protected MvxNotifyPropertyChanged()
		{
			ShouldAlwaysRaiseInpcOnUserInterfaceThread(MvxSingleton<IMvxSingletonCache>.Instance == null || MvxSingleton<IMvxSingletonCache>.Instance.Settings.AlwaysRaiseInpcOnUserInterfaceThread);
		}

		public void RaisePropertyChanged<T>(Expression<Func<T>> property)
		{
			string propertyNameFromExpression = this.GetPropertyNameFromExpression(property);
			RaisePropertyChanged(propertyNameFromExpression);
		}

		public void RaisePropertyChanged([CallerMemberName] string whichProperty = "")
		{
			PropertyChangedEventArgs changedArgs = new PropertyChangedEventArgs(whichProperty);
			RaisePropertyChanged(changedArgs);
		}

		public virtual void RaiseAllPropertiesChanged()
		{
			PropertyChangedEventArgs changedArgs = new PropertyChangedEventArgs(string.Empty);
			RaisePropertyChanged(changedArgs);
		}

		public virtual void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
		{
			if (InterceptRaisePropertyChanged(changedArgs) == MvxInpcInterceptionResult.DoNotRaisePropertyChanged)
			{
				return;
			}
			Action action = delegate
			{
				this.PropertyChanged?.Invoke(this, changedArgs);
			};
			if (ShouldAlwaysRaiseInpcOnUserInterfaceThread())
			{
				if (this.PropertyChanged != null)
				{
					InvokeOnMainThread(action);
				}
			}
			else
			{
				action();
			}
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			RaisePropertyChanged(propertyName);
			return true;
		}

		protected virtual MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
		{
			if (MvxSingleton<IMvxSingletonCache>.Instance != null)
			{
				IMvxInpcInterceptor inpcInterceptor = MvxSingleton<IMvxSingletonCache>.Instance.InpcInterceptor;
				if (inpcInterceptor != null)
				{
					return inpcInterceptor.Intercept(this, changedArgs);
				}
			}
			return MvxInpcInterceptionResult.NotIntercepted;
		}
	}
	public class MvxNullViewModel : MvxViewModel
	{
	}
	public interface IMvxCommandHelper
	{
		event EventHandler CanExecuteChanged;

		void RaiseCanExecuteChanged(object sender);
	}
	public class MvxStrongCommandHelper : IMvxCommandHelper
	{
		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged(object sender)
		{
			this.CanExecuteChanged?.Invoke(sender, EventArgs.Empty);
		}
	}
	public class MvxWeakCommandHelper : IMvxCommandHelper
	{
		private readonly List<WeakReference> _eventHandlers = new List<WeakReference>();

		private readonly object _syncRoot = new object();

		public event EventHandler CanExecuteChanged
		{
			add
			{
				lock (_syncRoot)
				{
					_eventHandlers.Add(new WeakReference(value));
				}
			}
			remove
			{
				lock (_syncRoot)
				{
					foreach (WeakReference eventHandler in _eventHandlers)
					{
						if (eventHandler.IsAlive && (EventHandler)eventHandler.Target == value)
						{
							_eventHandlers.Remove(eventHandler);
							break;
						}
					}
				}
			}
		}

		private IEnumerable<EventHandler> SafeCopyEventHandlerList()
		{
			lock (_syncRoot)
			{
				List<EventHandler> list = new List<EventHandler>();
				List<WeakReference> list2 = new List<WeakReference>();
				foreach (WeakReference eventHandler2 in _eventHandlers)
				{
					if (!eventHandler2.IsAlive)
					{
						list2.Add(eventHandler2);
						continue;
					}
					EventHandler eventHandler = (EventHandler)eventHandler2.Target;
					if (eventHandler != null)
					{
						list.Add(eventHandler);
					}
				}
				foreach (WeakReference item in list2)
				{
					_eventHandlers.Remove(item);
				}
				return list;
			}
		}

		public void RaiseCanExecuteChanged(object sender)
		{
			foreach (EventHandler item in SafeCopyEventHandlerList())
			{
				item(sender, EventArgs.Empty);
			}
		}
	}
	public class MvxCommandBase : MvxMainThreadDispatchingObject
	{
		private readonly IMvxCommandHelper _commandHelper;

		public bool ShouldAlwaysRaiseCECOnUserInterfaceThread { get; set; }

		public event EventHandler CanExecuteChanged
		{
			add
			{
				_commandHelper.CanExecuteChanged += value;
			}
			remove
			{
				_commandHelper.CanExecuteChanged -= value;
			}
		}

		public MvxCommandBase()
		{
			if (!Mvx.TryResolve<IMvxCommandHelper>(out _commandHelper))
			{
				_commandHelper = new MvxWeakCommandHelper();
			}
			ShouldAlwaysRaiseCECOnUserInterfaceThread = MvxSingleton<IMvxSingletonCache>.Instance == null || MvxSingleton<IMvxSingletonCache>.Instance.Settings.AlwaysRaiseInpcOnUserInterfaceThread;
		}

		public void RaiseCanExecuteChanged()
		{
			if (ShouldAlwaysRaiseCECOnUserInterfaceThread)
			{
				InvokeOnMainThread(delegate
				{
					_commandHelper.RaiseCanExecuteChanged(this);
				});
			}
			else
			{
				_commandHelper.RaiseCanExecuteChanged(this);
			}
		}
	}
	public class MvxCommand : MvxCommandBase, IMvxCommand, ICommand
	{
		private readonly Func<bool> _canExecute;

		private readonly Action _execute;

		public MvxCommand(Action execute)
			: this(execute, null)
		{
		}

		public MvxCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
			{
				return _canExecute();
			}
			return true;
		}

		public bool CanExecute()
		{
			return CanExecute(null);
		}

		public void Execute(object parameter)
		{
			if (CanExecute(parameter))
			{
				_execute();
			}
		}

		public void Execute()
		{
			Execute(null);
		}
	}
	public class MvxCommand<T> : MvxCommandBase, IMvxCommand, ICommand
	{
		private readonly Func<T, bool> _canExecute;

		private readonly Action<T> _execute;

		public MvxCommand(Action<T> execute)
			: this(execute, (Func<T, bool>)null)
		{
		}

		public MvxCommand(Action<T> execute, Func<T, bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
			{
				return _canExecute((T)typeof(T).MakeSafeValueCore(parameter));
			}
			return true;
		}

		public bool CanExecute()
		{
			return CanExecute(null);
		}

		public void Execute(object parameter)
		{
			if (CanExecute(parameter))
			{
				_execute((T)typeof(T).MakeSafeValueCore(parameter));
			}
		}

		public void Execute()
		{
			Execute(null);
		}
	}
	public class MvxNavigationSerializer : IMvxNavigationSerializer
	{
		public IMvxTextSerializer Serializer { get; private set; }

		public MvxNavigationSerializer(IMvxTextSerializer serializer)
		{
			Serializer = serializer;
		}
	}
	public class MvxNavigationSerializer<T> : MvxNavigationSerializer where T : class, IMvxTextSerializer
	{
		public MvxNavigationSerializer()
			: base(Mvx.Resolve<T>())
		{
		}
	}
	public class MvxAppStart<TViewModel> : MvxNavigatingObject, IMvxAppStart where TViewModel : IMvxViewModel
	{
		public void Start(object hint = null)
		{
			if (hint != null)
			{
				MvxTrace.Trace("Hint ignored in default MvxAppStart");
			}
			ShowViewModel<TViewModel>();
		}
	}
	public abstract class MvxViewModel : MvxNavigatingObject, IMvxViewModel
	{
		public MvxRequestedBy RequestedBy { get; set; }

		protected MvxViewModel()
		{
			RequestedBy = MvxRequestedBy.Unknown;
		}

		public void Init(IMvxBundle parameters)
		{
			InitFromBundle(parameters);
		}

		public void ReloadState(IMvxBundle state)
		{
			ReloadFromBundle(state);
		}

		public virtual void Start()
		{
		}

		public void SaveState(IMvxBundle state)
		{
			SaveStateToBundle(state);
		}

		protected virtual void InitFromBundle(IMvxBundle parameters)
		{
		}

		protected virtual void ReloadFromBundle(IMvxBundle state)
		{
		}

		protected virtual void SaveStateToBundle(IMvxBundle bundle)
		{
		}
	}
	public abstract class MvxViewModel<TInit> : MvxViewModel, IMvxViewModelInitializer<TInit>, IMvxViewModel
	{
		public async Task Init(string parameter)
		{
			if (!Mvx.TryResolve<IMvxJsonConverter>(out var service))
			{
				Mvx.Trace("Could not resolve IMvxJsonConverter, it is going to be hard to initialize with custom object");
				return;
			}
			TInit parameter2 = service.DeserializeObject<TInit>(parameter);
			await Init(parameter2);
		}

		protected abstract Task Init(TInit parameter);
	}
	public class MvxViewModelRequest
	{
		public Type ViewModelType { get; set; }

		public IDictionary<string, string> ParameterValues { get; set; }

		public IDictionary<string, string> PresentationValues { get; set; }

		public MvxRequestedBy RequestedBy { get; set; }

		public MvxViewModelRequest()
		{
		}

		public MvxViewModelRequest(Type viewModelType, IMvxBundle parameterBundle, IMvxBundle presentationBundle, MvxRequestedBy requestedBy)
		{
			ViewModelType = viewModelType;
			ParameterValues = parameterBundle.SafeGetData();
			PresentationValues = presentationBundle.SafeGetData();
			RequestedBy = requestedBy;
		}

		public static MvxViewModelRequest GetDefaultRequest(Type viewModelType)
		{
			return new MvxViewModelRequest(viewModelType, null, null, MvxRequestedBy.Unknown);
		}
	}
	public class MvxViewModelRequest<TViewModel> : MvxViewModelRequest where TViewModel : IMvxViewModel
	{
		public MvxViewModelRequest(IMvxBundle parameterBundle, IMvxBundle presentationBundle, MvxRequestedBy requestedBy)
			: base(typeof(TViewModel), parameterBundle, presentationBundle, requestedBy)
		{
		}

		public static MvxViewModelRequest GetDefaultRequest()
		{
			return MvxViewModelRequest.GetDefaultRequest(typeof(TViewModel));
		}
	}
	public interface IMvxPagedViewModel : IMvxViewModel
	{
		string PagedViewId { get; }
	}
	public interface IMvxPageViewModel : IMvxViewModel
	{
		IMvxPagedViewModel GetDefaultViewModel();

		IMvxPagedViewModel GetNextViewModel(IMvxPagedViewModel currentViewModel);

		IMvxPagedViewModel GetPreviousViewModel(IMvxPagedViewModel currentViewModel);
	}
	public class MvxObservableCollection<T> : ObservableCollection<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private bool _suppressEvents;

		public bool SuppressEvents
		{
			get
			{
				return _suppressEvents;
			}
			set
			{
				if (_suppressEvents != value)
				{
					_suppressEvents = value;
					OnPropertyChanged(new PropertyChangedEventArgs("SuppressEvents"));
				}
			}
		}

		public MvxObservableCollection()
		{
		}

		public MvxObservableCollection(IEnumerable<T> items)
			: base(items)
		{
		}

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			if (!SuppressEvents)
			{
				InvokeOnMainThread(delegate
				{
					base.OnCollectionChanged(e);
				});
			}
		}

		public void AddRange(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			try
			{
				SuppressEvents = true;
				foreach (T item in items)
				{
					Add(item);
				}
			}
			finally
			{
				SuppressEvents = false;
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		public void ReplaceWith(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			SuppressEvents = true;
			Clear();
			AddRange(items);
		}

		public void ReplaceRange(IEnumerable<T> items, int firstIndex, int oldSize)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			try
			{
				SuppressEvents = true;
				int num = firstIndex + oldSize - 1;
				while (firstIndex + items.Count() <= num)
				{
					RemoveAt(num--);
				}
				foreach (T item in items)
				{
					if (firstIndex <= num)
					{
						SetItem(firstIndex++, item);
					}
					else
					{
						Insert(firstIndex++, item);
					}
				}
			}
			finally
			{
				SuppressEvents = false;
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		public void SwitchTo(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			int num = 0;
			int num2 = base.Count;
			foreach (T item in items)
			{
				if (num >= num2)
				{
					Add(item);
				}
				else if (!object.Equals(base[num], item))
				{
					base[num] = item;
				}
				num++;
			}
			while (num2 > num)
			{
				RemoveAt(--num2);
			}
		}

		public void RemoveRange(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			try
			{
				SuppressEvents = true;
				foreach (T item in items)
				{
					Remove(item);
				}
			}
			finally
			{
				SuppressEvents = false;
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
			}
		}

		protected void InvokeOnMainThread(Action action)
		{
			MvxSingleton<IMvxMainThreadDispatcher>.Instance?.RequestMainThreadAction(action);
		}

		protected override void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			InvokeOnMainThread(delegate
			{
				base.OnPropertyChanged(e);
			});
		}
	}
}
namespace MvvmCross.Core.Platform
{
	public interface IMvxFillableStringToTypeParser
	{
		IDictionary<Type, MvxStringToTypeParser.IParser> TypeParsers { get; }

		IList<MvxStringToTypeParser.IExtraParser> ExtraParsers { get; }
	}
	public interface IMvxStringToTypeParser
	{
		bool TypeSupported(Type targetType);

		object ReadValue(string rawValue, Type targetType, string fieldOrParameterName);
	}
	public interface IMvxSettings
	{
		bool AlwaysRaiseInpcOnUserInterfaceThread { get; set; }
	}
	public class MvxSettings : IMvxSettings
	{
		public bool AlwaysRaiseInpcOnUserInterfaceThread { get; set; }

		public MvxSettings()
		{
			AlwaysRaiseInpcOnUserInterfaceThread = true;
		}
	}
	public class MvxStringToTypeParser : IMvxStringToTypeParser, IMvxFillableStringToTypeParser
	{
		public interface IParser
		{
			object ReadValue(string input, string fieldOrParameterName);
		}

		public interface IExtraParser
		{
			bool Parses(Type t);

			object ReadValue(Type t, string input, string fieldOrParameterName);
		}

		public class EnumParser : IExtraParser
		{
			public bool Parses(Type t)
			{
				return t.GetTypeInfo().IsEnum;
			}

			public object ReadValue(Type t, string input, string fieldOrParameterName)
			{
				object obj = null;
				try
				{
					obj = Enum.Parse(t, input, ignoreCase: true);
				}
				catch (Exception)
				{
					MvxTrace.Error("Failed to parse enum parameter {0} from string {1}", fieldOrParameterName, input);
				}
				if (obj == null)
				{
					try
					{
						obj = Enum.ToObject(t, (object)0);
					}
					catch (Exception)
					{
						MvxTrace.Error("Failed to create default enum value for {0} - will return null", fieldOrParameterName);
					}
				}
				return obj;
			}
		}

		public class StringParser : IParser
		{
			public object ReadValue(string input, string fieldOrParameterName)
			{
				return input;
			}
		}

		public abstract class ValueParser : IParser
		{
			protected abstract bool TryParse(string input, out object result);

			public object ReadValue(string input, string fieldOrParameterName)
			{
				if (!TryParse(input, out var result))
				{
					MvxTrace.Error("Failed to parse {0} parameter {1} from string {2}", GetType().Name, fieldOrParameterName, input);
				}
				return result;
			}
		}

		public class BoolParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				bool result3;
				bool result2 = bool.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class ShortParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				short result3;
				bool result2 = short.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class IntParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				int result3;
				bool result2 = int.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class LongParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				long result3;
				bool result2 = long.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class UshortParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				ushort result3;
				bool result2 = ushort.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class UintParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				uint result3;
				bool result2 = uint.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class UlongParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				ulong result3;
				bool result2 = ulong.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class FloatParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				float result3;
				bool result2 = float.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class DoubleParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				double result3;
				bool result2 = double.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class GuidParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				Guid result3;
				bool result2 = Guid.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public class DateTimeParser : ValueParser
		{
			protected override bool TryParse(string input, out object result)
			{
				DateTime result3;
				bool result2 = DateTime.TryParse(input, out result3);
				result = result3;
				return result2;
			}
		}

		public IDictionary<Type, IParser> TypeParsers { get; private set; }

		public IList<IExtraParser> ExtraParsers { get; private set; }

		public MvxStringToTypeParser()
		{
			TypeParsers = new Dictionary<Type, IParser>
			{
				{
					typeof(string),
					new StringParser()
				},
				{
					typeof(short),
					new ShortParser()
				},
				{
					typeof(int),
					new IntParser()
				},
				{
					typeof(long),
					new LongParser()
				},
				{
					typeof(ushort),
					new UshortParser()
				},
				{
					typeof(uint),
					new UintParser()
				},
				{
					typeof(ulong),
					new UlongParser()
				},
				{
					typeof(double),
					new DoubleParser()
				},
				{
					typeof(float),
					new FloatParser()
				},
				{
					typeof(bool),
					new BoolParser()
				},
				{
					typeof(Guid),
					new GuidParser()
				},
				{
					typeof(DateTime),
					new DateTimeParser()
				}
			};
			ExtraParsers = new List<IExtraParser>
			{
				new EnumParser()
			};
		}

		public bool TypeSupported(Type targetType)
		{
			if (TypeParsers.ContainsKey(targetType))
			{
				return true;
			}
			return ExtraParsers.Any((IExtraParser x) => x.Parses(targetType));
		}

		public object ReadValue(string rawValue, Type targetType, string fieldOrParameterName)
		{
			if (TypeParsers.TryGetValue(targetType, out var value))
			{
				return value.ReadValue(rawValue, fieldOrParameterName);
			}
			IExtraParser extraParser = ExtraParsers.FirstOrDefault((IExtraParser x) => x.Parses(targetType));
			if (extraParser != null)
			{
				return extraParser.ReadValue(targetType, rawValue, fieldOrParameterName);
			}
			MvxTrace.Error("Parameter {0} is invalid targetType {1}", fieldOrParameterName, targetType.Name);
			return null;
		}
	}
	public static class MvxSimplePropertyDictionaryExtensionMethods
	{
		public static IDictionary<string, string> ToSimpleStringPropertyDictionary(this IDictionary<string, object> input)
		{
			if (input == null)
			{
				return new Dictionary<string, string>();
			}
			return input.ToDictionary((KeyValuePair<string, object> x) => x.Key, (KeyValuePair<string, object> x) => x.Value?.ToString());
		}

		public static IDictionary<string, string> SafeGetData(this IMvxBundle bundle)
		{
			return bundle?.Data;
		}

		public static void Write(this IDictionary<string, string> data, object toStore)
		{
			if (toStore == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> item in toStore.ToSimplePropertyDictionary())
			{
				data[item.Key] = item.Value;
			}
		}

		public static T Read<T>(this IDictionary<string, string> data) where T : new()
		{
			return (T)data.Read(typeof(T));
		}

		public static object Read(this IDictionary<string, string> data, Type type)
		{
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo item in from p in type.GetProperties(MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy)
				where p.CanWrite
				select p)
			{
				if (data.TryGetValue(item.Name, out var value))
				{
					object value2 = MvxSingleton<IMvxSingletonCache>.Instance.Parser.ReadValue(value, item.PropertyType, item.Name);
					item.SetValue(obj, value2, new object[0]);
				}
			}
			return obj;
		}

		public static IEnumerable<object> CreateArgumentList(this IDictionary<string, string> data, IEnumerable<ParameterInfo> requiredParameters, string debugText)
		{
			List<object> list = new List<object>();
			foreach (ParameterInfo requiredParameter in requiredParameters)
			{
				object argumentValue = data.GetArgumentValue(requiredParameter, debugText);
				list.Add(argumentValue);
			}
			return list;
		}

		public static object GetArgumentValue(this IDictionary<string, string> data, ParameterInfo requiredParameter, string debugText)
		{
			if (data == null || !data.TryGetValue(requiredParameter.Name, out var value))
			{
				if (requiredParameter.IsOptional)
				{
					return Type.Missing;
				}
				MvxTrace.Trace("Missing parameter for call to {0} - missing parameter {1} - asssuming null - this may fail for value types!", debugText, requiredParameter.Name);
				value = null;
			}
			return MvxSingleton<IMvxSingletonCache>.Instance.Parser.ReadValue(value, requiredParameter.ParameterType, requiredParameter.Name);
		}

		public static IDictionary<string, string> ToSimplePropertyDictionary(this object input)
		{
			if (input == null)
			{
				return new Dictionary<string, string>();
			}
			if (input is IDictionary<string, string>)
			{
				return (IDictionary<string, string>)input;
			}
			var enumerable = from property in input.GetType().GetProperties(MvvmCross.Platform.BindingFlags.Instance | MvvmCross.Platform.BindingFlags.Public | MvvmCross.Platform.BindingFlags.FlattenHierarchy)
				where property.CanRead
				select new
				{
					CanSerialize = MvxSingleton<IMvxSingletonCache>.Instance.Parser.TypeSupported(property.PropertyType),
					Property = property
				};
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (var item in enumerable)
			{
				if (item.CanSerialize)
				{
					dictionary[item.Property.Name] = input.GetPropertyValueAsString(item.Property);
					continue;
				}
				Mvx.Trace("Skipping serialization of property {0} - don't know how to serialize type {1} - some answers on http://stackoverflow.com/questions/16524236/custom-types-in-navigation-parameters-in-v3", item.Property.Name, item.Property.PropertyType.Name);
			}
			return dictionary;
		}

		public static string GetPropertyValueAsString(this object input, PropertyInfo propertyInfo)
		{
			try
			{
				return propertyInfo.GetValue(input, new object[0])?.ToString();
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Problem accessing object - most likely this is caused by an anonymous object being generated as Internal - please see http://stackoverflow.com/questions/8273399/anonymous-types-and-get-accessors-on-wp7-1");
			}
		}
	}
	public interface IMvxLifetime
	{
		event EventHandler<MvxLifetimeEventArgs> LifetimeChanged;
	}
	public enum MvxLifetimeEvent
	{
		Launching,
		ActivatedFromMemory,
		ActivatedFromDisk,
		Deactivated,
		Closing
	}
	public class MvxLifetimeEventArgs : EventArgs
	{
		public MvxLifetimeEvent LifetimeEvent { get; private set; }

		public MvxLifetimeEventArgs(MvxLifetimeEvent lifetimeEvent)
		{
			LifetimeEvent = lifetimeEvent;
		}
	}
	public abstract class MvxLifetimeMonitor : IMvxLifetime
	{
		public event EventHandler<MvxLifetimeEventArgs> LifetimeChanged;

		protected void FireLifetimeChange(MvxLifetimeEvent which)
		{
			this.LifetimeChanged?.Invoke(this, new MvxLifetimeEventArgs(which));
		}
	}
	public abstract class MvxSetup
	{
		public enum MvxSetupState
		{
			Uninitialized,
			InitializingPrimary,
			InitializedPrimary,
			InitializingSecondary,
			Initialized
		}

		public class MvxSetupStateEventArgs : EventArgs
		{
			public MvxSetupState SetupState { get; private set; }

			public MvxSetupStateEventArgs(MvxSetupState setupState)
			{
				SetupState = setupState;
			}
		}

		private MvxSetupState _state;

		public MvxSetupState State
		{
			get
			{
				return _state;
			}
			private set
			{
				_state = value;
				FireStateChange(value);
			}
		}

		public event EventHandler<MvxSetupStateEventArgs> StateChanged;

		protected abstract IMvxTrace CreateDebugTrace();

		protected abstract IMvxApplication CreateApp();

		protected abstract IMvxViewsContainer CreateViewsContainer();

		protected abstract IMvxViewDispatcher CreateViewDispatcher();

		public virtual void Initialize()
		{
			InitializePrimary();
			InitializeSecondary();
		}

		public virtual void InitializePrimary()
		{
			if (State != MvxSetupState.Uninitialized)
			{
				throw new MvxException("Cannot start primary - as state already {0}", State);
			}
			State = MvxSetupState.InitializingPrimary;
			MvxTrace.Trace("Setup: Primary start");
			InitializeIoC();
			State = MvxSetupState.InitializedPrimary;
			if (State != MvxSetupState.InitializedPrimary)
			{
				throw new MvxException("Cannot start seconday - as state is currently {0}", State);
			}
			State = MvxSetupState.InitializingSecondary;
			MvxTrace.Trace("Setup: FirstChance start");
			InitializeFirstChance();
			MvxTrace.Trace("Setup: DebugServices start");
			InitializeDebugServices();
			MvxTrace.Trace("Setup: PlatformServices start");
			InitializePlatformServices();
			MvxTrace.Trace("Setup: MvvmCross settings start");
			InitializeSettings();
			MvxTrace.Trace("Setup: Singleton Cache start");
			InitializeSingletonCache();
		}

		public virtual void InitializeSecondary()
		{
			MvxTrace.Trace("Setup: Bootstrap actions");
			PerformBootstrapActions();
			MvxTrace.Trace("Setup: StringToTypeParser start");
			InitializeStringToTypeParser();
			MvxTrace.Trace("Setup: CommandHelper start");
			InitializeCommandHelper();
			MvxTrace.Trace("Setup: ViewModelFramework start");
			InitializeViewModelFramework();
			MvxTrace.Trace("Setup: PluginManagerFramework start");
			IMvxPluginManager pluginManager = InitializePluginFramework();
			MvxTrace.Trace("Setup: App start");
			InitializeApp(pluginManager);
			MvxTrace.Trace("Setup: ViewModelTypeFinder start");
			InitializeViewModelTypeFinder();
			MvxTrace.Trace("Setup: ViewsContainer start");
			InitializeViewsContainer();
			MvxTrace.Trace("Setup: ViewDispatcher start");
			InitializeViewDispatcher();
			MvxTrace.Trace("Setup: Views start");
			InitializeViewLookup();
			MvxTrace.Trace("Setup: CommandCollectionBuilder start");
			InitializeCommandCollectionBuilder();
			MvxTrace.Trace("Setup: NavigationSerializer start");
			InitializeNavigationSerializer();
			MvxTrace.Trace("Setup: InpcInterception start");
			InitializeInpcInterception();
			MvxTrace.Trace("Setup: LastChance start");
			InitializeLastChance();
			MvxTrace.Trace("Setup: Secondary end");
			State = MvxSetupState.Initialized;
		}

		protected virtual void InitializeCommandHelper()
		{
			Mvx.RegisterType<IMvxCommandHelper, MvxWeakCommandHelper>();
		}

		protected virtual void InitializeSingletonCache()
		{
			MvxSingletonCache.Initialize();
		}

		protected virtual void InitializeInpcInterception()
		{
		}

		protected virtual void InitializeSettings()
		{
			Mvx.RegisterSingleton(CreateSettings());
		}

		protected virtual IMvxSettings CreateSettings()
		{
			return new MvxSettings();
		}

		protected virtual void InitializeStringToTypeParser()
		{
			MvxStringToTypeParser service = CreateStringToTypeParser();
			Mvx.RegisterSingleton((IMvxStringToTypeParser)service);
			Mvx.RegisterSingleton((IMvxFillableStringToTypeParser)service);
		}

		protected virtual MvxStringToTypeParser CreateStringToTypeParser()
		{
			return new MvxStringToTypeParser();
		}

		protected virtual void PerformBootstrapActions()
		{
			MvxBootstrapRunner mvxBootstrapRunner = new MvxBootstrapRunner();
			foreach (Assembly bootstrapOwningAssembly in GetBootstrapOwningAssemblies())
			{
				mvxBootstrapRunner.Run(bootstrapOwningAssembly);
			}
		}

		protected virtual void InitializeNavigationSerializer()
		{
			Mvx.RegisterSingleton(CreateNavigationSerializer());
		}

		protected virtual IMvxNavigationSerializer CreateNavigationSerializer()
		{
			return new MvxStringDictionaryNavigationSerializer();
		}

		protected virtual void InitializeCommandCollectionBuilder()
		{
			Mvx.RegisterSingleton(CreateCommandCollectionBuilder);
		}

		protected virtual IMvxCommandCollectionBuilder CreateCommandCollectionBuilder()
		{
			return new MvxCommandCollectionBuilder();
		}

		protected virtual void InitializeIoC()
		{
			Mvx.RegisterSingleton(CreateIocProvider());
		}

		protected virtual IMvxIocOptions CreateIocOptions()
		{
			return new MvxIocOptions();
		}

		protected virtual IMvxIoCProvider CreateIocProvider()
		{
			return MvxSimpleIoCContainer.Initialize(CreateIocOptions());
		}

		protected virtual void InitializeFirstChance()
		{
		}

		protected virtual void InitializePlatformServices()
		{
		}

		protected virtual void InitializeDebugServices()
		{
			Mvx.RegisterSingleton(CreateDebugTrace());
			MvxTrace.Initialize();
		}

		protected virtual void InitializeViewModelFramework()
		{
			Mvx.RegisterSingleton(CreateViewModelLoader());
		}

		protected virtual IMvxViewModelLoader CreateViewModelLoader()
		{
			return new MvxViewModelLoader();
		}

		protected virtual IMvxPluginManager InitializePluginFramework()
		{
			IMvxPluginManager mvxPluginManager = CreatePluginManager();
			AddPluginsLoaders(mvxPluginManager.Registry);
			mvxPluginManager.ConfigurationSource = GetPluginConfiguration;
			Mvx.RegisterSingleton(mvxPluginManager);
			LoadPlugins(mvxPluginManager);
			return mvxPluginManager;
		}

		protected virtual void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
		{
		}

		protected abstract IMvxPluginManager CreatePluginManager();

		protected virtual IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
		{
			return null;
		}

		public virtual void LoadPlugins(IMvxPluginManager pluginManager)
		{
		}

		protected virtual void InitializeApp(IMvxPluginManager pluginManager)
		{
			IMvxApplication service = CreateAndInitializeApp(pluginManager);
			Mvx.RegisterSingleton(service);
			Mvx.RegisterSingleton((IMvxViewModelLocatorCollection)service);
		}

		protected virtual IMvxApplication CreateAndInitializeApp(IMvxPluginManager pluginManager)
		{
			IMvxApplication mvxApplication = CreateApp();
			mvxApplication.LoadPlugins(pluginManager);
			mvxApplication.Initialize();
			return mvxApplication;
		}

		protected virtual void InitializeViewsContainer()
		{
			Mvx.RegisterSingleton(CreateViewsContainer());
		}

		protected virtual void InitializeViewDispatcher()
		{
			IMvxViewDispatcher service = CreateViewDispatcher();
			Mvx.RegisterSingleton(service);
			Mvx.RegisterSingleton((IMvxMainThreadDispatcher)service);
		}

		protected virtual IEnumerable<Assembly> GetViewAssemblies()
		{
			Assembly assembly = GetType().GetTypeInfo().Assembly;
			return new Assembly[1] { assembly };
		}

		protected virtual IEnumerable<Assembly> GetViewModelAssemblies()
		{
			Assembly assembly = Mvx.Resolve<IMvxApplication>().GetType().GetTypeInfo()
				.Assembly;
			return new Assembly[1] { assembly };
		}

		protected virtual IEnumerable<Assembly> GetBootstrapOwningAssemblies()
		{
			List<Assembly> list = new List<Assembly>();
			list.AddRange(GetViewAssemblies());
			return list.Distinct().ToArray();
		}

		protected abstract IMvxNameMapping CreateViewToViewModelNaming();

		protected virtual void InitializeViewModelTypeFinder()
		{
			MvxViewModelByNameLookup mvxViewModelByNameLookup = new MvxViewModelByNameLookup();
			foreach (Assembly viewModelAssembly in GetViewModelAssemblies())
			{
				mvxViewModelByNameLookup.AddAll(viewModelAssembly);
			}
			Mvx.RegisterSingleton((IMvxViewModelByNameLookup)mvxViewModelByNameLookup);
			Mvx.RegisterSingleton((IMvxViewModelByNameRegistry)mvxViewModelByNameLookup);
			IMvxNameMapping viewToViewModelNameMapping = CreateViewToViewModelNaming();
			Mvx.RegisterSingleton((IMvxViewModelTypeFinder)new MvxViewModelViewTypeFinder(mvxViewModelByNameLookup, viewToViewModelNameMapping));
		}

		protected virtual void InitializeViewLookup()
		{
			IEnumerable<Assembly> viewAssemblies = GetViewAssemblies();
			IDictionary<Type, Type> dictionary = new MvxViewModelViewLookupBuilder().Build(viewAssemblies);
			if (dictionary != null)
			{
				Mvx.Resolve<IMvxViewsContainer>().AddAll(dictionary);
			}
		}

		protected virtual void InitializeLastChance()
		{
		}

		protected IEnumerable<Type> CreatableTypes()
		{
			return CreatableTypes(GetType().GetTypeInfo().Assembly);
		}

		protected IEnumerable<Type> CreatableTypes(Assembly assembly)
		{
			return assembly.CreatableTypes();
		}

		private void FireStateChange(MvxSetupState state)
		{
			this.StateChanged?.Invoke(this, new MvxSetupStateEventArgs(state));
		}

		public virtual void EnsureInitialized(Type requiredBy)
		{
			switch (State)
			{
			case MvxSetupState.Uninitialized:
				Initialize();
				break;
			case MvxSetupState.InitializingPrimary:
			case MvxSetupState.InitializedPrimary:
			case MvxSetupState.InitializingSecondary:
				throw new MvxException("The default EnsureInitialized method does not handle partial initialization");
			default:
				throw new ArgumentOutOfRangeException();
			case MvxSetupState.Initialized:
				break;
			}
		}
	}
}
namespace MvvmCross.Core.Parse.StringDictionary
{
	public interface IMvxStringDictionaryParser
	{
		IDictionary<string, string> Parse(string textToParse);
	}
	public interface IMvxStringDictionaryWriter
	{
		string Write(IDictionary<string, string> dictionary);
	}
	public class MvxViewModelRequestCustomTextSerializer : IMvxTextSerializer
	{
		private IMvxViewModelByNameLookup _byNameLookup;

		protected IMvxViewModelByNameLookup ByNameLookup
		{
			get
			{
				_byNameLookup = _byNameLookup ?? Mvx.Resolve<IMvxViewModelByNameLookup>();
				return _byNameLookup;
			}
		}

		public T DeserializeObject<T>(string inputText)
		{
			return (T)DeserializeObject(typeof(T), inputText);
		}

		public string SerializeObject(object toSerialise)
		{
			if (toSerialise is MvxViewModelRequest)
			{
				return Serialize((MvxViewModelRequest)toSerialise);
			}
			if (toSerialise is IDictionary<string, string>)
			{
				return Serialize((IDictionary<string, string>)toSerialise);
			}
			throw new MvxException("This serializer only knows about MvxViewModelRequest and IDictionary<string,string>");
		}

		public object DeserializeObject(Type type, string inputText)
		{
			if ((object)type == typeof(MvxViewModelRequest))
			{
				return DeserializeViewModelRequest(inputText);
			}
			if (ReflectionExtensions.IsAssignableFrom(typeof(IDictionary<string, string>), type))
			{
				return DeserializeStringDictionary(inputText);
			}
			throw new MvxException("This serializer only knows about MvxViewModelRequest and IDictionary<string,string>");
		}

		protected virtual IDictionary<string, string> DeserializeStringDictionary(string inputText)
		{
			return new MvxStringDictionaryParser().Parse(inputText);
		}

		protected virtual MvxViewModelRequest DeserializeViewModelRequest(string inputText)
		{
			MvxStringDictionaryParser mvxStringDictionaryParser = new MvxStringDictionaryParser();
			IDictionary<string, string> dictionary = mvxStringDictionaryParser.Parse(inputText);
			MvxViewModelRequest mvxViewModelRequest = new MvxViewModelRequest();
			string viewModelTypeName = SafeGetValue(dictionary, "Type");
			mvxViewModelRequest.ViewModelType = DeserializeViewModelType(viewModelTypeName);
			mvxViewModelRequest.RequestedBy = new MvxRequestedBy
			{
				Type = (MvxRequestedByType)int.Parse(SafeGetValue(dictionary, "By")),
				AdditionalInfo = SafeGetValue(dictionary, "Info")
			};
			mvxViewModelRequest.ParameterValues = mvxStringDictionaryParser.Parse(SafeGetValue(dictionary, "Params"));
			mvxViewModelRequest.PresentationValues = mvxStringDictionaryParser.Parse(SafeGetValue(dictionary, "Pres"));
			return mvxViewModelRequest;
		}

		protected virtual string Serialize(IDictionary<string, string> toSerialise)
		{
			return new MvxStringDictionaryWriter().Write(toSerialise);
		}

		protected virtual string Serialize(MvxViewModelRequest toSerialise)
		{
			MvxStringDictionaryWriter mvxStringDictionaryWriter = new MvxStringDictionaryWriter();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["Type"] = SerializeViewModelName(toSerialise.ViewModelType);
			MvxRequestedBy mvxRequestedBy = toSerialise.RequestedBy ?? new MvxRequestedBy();
			dictionary["By"] = ((int)mvxRequestedBy.Type).ToString();
			dictionary["Info"] = mvxRequestedBy.AdditionalInfo;
			dictionary["Params"] = mvxStringDictionaryWriter.Write(toSerialise.ParameterValues);
			dictionary["Pres"] = mvxStringDictionaryWriter.Write(toSerialise.PresentationValues);
			return mvxStringDictionaryWriter.Write(dictionary);
		}

		protected virtual string SerializeViewModelName(Type viewModelType)
		{
			return viewModelType.FullName;
		}

		protected virtual Type DeserializeViewModelType(string viewModelTypeName)
		{
			if (!ByNameLookup.TryLookupByFullName(viewModelTypeName, out var viewModelType))
			{
				throw new MvxException("Failed to find viewmodel for {0} - is the ViewModel in the same Assembly as App.cs? If not, you can add it by overriding GetViewModelAssemblies() in setup", viewModelTypeName);
			}
			return viewModelType;
		}

		private string SafeGetValue(IDictionary<string, string> dictionary, string key)
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				throw new MvxException("Dictionary missing required keyvalue pair for key {0}", key);
			}
			return value;
		}
	}
	public class MvxStringDictionaryParser : MvxParser, IMvxStringDictionaryParser
	{
		protected Dictionary<string, string> CurrentEntries { get; private set; }

		public IDictionary<string, string> Parse(string textToParse)
		{
			Reset(textToParse);
			while (!base.IsComplete)
			{
				ParseNextKeyValuePair();
				SkipWhitespaceAndCharacters(';');
			}
			return CurrentEntries;
		}

		protected override void Reset(string textToParse)
		{
			CurrentEntries = new Dictionary<string, string>();
			base.Reset(textToParse);
		}

		private void ParseNextKeyValuePair()
		{
			SkipWhitespace();
			if (!base.IsComplete)
			{
				object obj = ReadValue();
				if (!(obj is string))
				{
					throw new MvxException("Unexpected object in key for keyvalue pair {0} at position {1}", obj.GetType().Name, base.CurrentIndex);
				}
				SkipWhitespace();
				if (base.CurrentChar != '=')
				{
					throw new MvxException("Unexpected character in keyvalue pair {0} at position {1}", base.CurrentChar, base.CurrentIndex);
				}
				MoveNext();
				SkipWhitespace();
				object obj2 = ReadValue();
				if (obj2 != null && !(obj2 is string))
				{
					throw new MvxException("Unexpected object in value for keyvalue pair {0} for key {1} at position {2}", obj2.GetType().Name, obj, base.CurrentIndex);
				}
				CurrentEntries[(string)obj] = (string)obj2;
			}
		}
	}
	public class MvxStringDictionaryWriter : IMvxStringDictionaryWriter
	{
		public string Write(IDictionary<string, string> dictionary)
		{
			if (dictionary == null || dictionary.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.AppendFormat("{0}={1}", new object[2]
				{
					Quote(item.Key),
					Quote(item.Value)
				});
			}
			return stringBuilder.ToString();
		}

		private string Quote(string input)
		{
			if (input == null)
			{
				return "null";
			}
			StringBuilder stringBuilder = new StringBuilder(input.Length + 32);
			stringBuilder.Append('\'');
			foreach (char c in input)
			{
				switch ((int)c)
				{
				case 92:
					stringBuilder.Append("\\\\");
					break;
				case 39:
					stringBuilder.Append("\\'");
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			stringBuilder.Append('\'');
			return stringBuilder.ToString();
		}
	}
}
