#define DEBUG
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid;
using MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Droid.Simple
{
	public abstract class MvxSimpleAndroidSetup : MvxAndroidSetup
	{
		private readonly IEnumerable<Type> _converterTypes;

		protected override IEnumerable<Type> ValueConverterHolders => _converterTypes.ToList();

		protected MvxSimpleAndroidSetup(Context applicationContext, params Type[] converterTypes)
			: base(applicationContext)
		{
			_converterTypes = converterTypes;
		}

		protected override void InitializeViewLookup()
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new MvxSimpleEmptyAndroidApp();
		}

		protected override void InitializeNavigationSerializer()
		{
		}

		protected override IMvxNavigationSerializer CreateNavigationSerializer()
		{
			throw new NotImplementedException("Not used in Simple apps - no navigation needed");
		}
	}
	[Register("mvvmcross.droid.simple.MvxSimpleBindingActivity")]
	public class MvxSimpleBindingActivity : MvxActivity
	{
		public new IMvxViewModel ViewModel
		{
			get
			{
				return base.ViewModel;
			}
			set
			{
				throw new MvxException("You've chosen to use simple binding.... so you need to just use DataContext, not ViewModel");
			}
		}

		protected sealed override void OnViewModelSet()
		{
		}
	}
	[Register("mvvmcross.droid.simple.MvxSimpleEmptyAndroidApp")]
	public class MvxSimpleEmptyAndroidApp : MvxApplication
	{
	}
}
namespace MvvmCross.Droid.Platform
{
	public interface IMvxAndroidActivityLifetimeListener
	{
		void OnCreate(Activity activity);

		void OnStart(Activity activity);

		void OnRestart(Activity activity);

		void OnResume(Activity activity);

		void OnPause(Activity activity);

		void OnStop(Activity activity);

		void OnDestroy(Activity activity);

		void OnViewNewIntent(Activity activity);
	}
	public class MvxAndroidSetupSingleton : MvxSingleton<MvxAndroidSetupSingleton>
	{
		private static readonly object LockObject = new object();

		private static TaskCompletionSource<bool> IsInitialisedTaskCompletionSource;

		private MvxAndroidSetup _setup;

		private bool _initialized;

		private IMvxAndroidSplashScreenActivity _currentSplashScreen;

		public virtual void EnsureInitialized()
		{
			lock (LockObject)
			{
				if (_initialized)
				{
					return;
				}
				if (IsInitialisedTaskCompletionSource != null)
				{
					Mvx.Trace("EnsureInitialized has already been called so now waiting for completion");
					IsInitialisedTaskCompletionSource.Task.Wait();
					return;
				}
				IsInitialisedTaskCompletionSource = new TaskCompletionSource<bool>();
				_setup.Initialize();
				_initialized = true;
				if (_currentSplashScreen != null)
				{
					Mvx.Warning("Current splash screen not null during direct initialization - not sure this should ever happen!");
					Mvx.GetSingleton<IMvxMainThreadDispatcher>().RequestMainThreadAction(delegate
					{
						_currentSplashScreen?.InitializationComplete();
					});
				}
				IsInitialisedTaskCompletionSource.SetResult(result: true);
			}
		}

		public virtual void RemoveSplashScreen(IMvxAndroidSplashScreenActivity splashScreen)
		{
			lock (LockObject)
			{
				_currentSplashScreen = null;
			}
		}

		public virtual void InitializeFromSplashScreen(IMvxAndroidSplashScreenActivity splashScreen)
		{
			lock (LockObject)
			{
				_currentSplashScreen = splashScreen;
				if (_initialized)
				{
					_currentSplashScreen?.InitializationComplete();
				}
				else
				{
					if (IsInitialisedTaskCompletionSource != null)
					{
						return;
					}
					IsInitialisedTaskCompletionSource = new TaskCompletionSource<bool>();
					_setup.InitializePrimary();
					ThreadPool.QueueUserWorkItem(delegate
					{
						_setup.InitializeSecondary();
						lock (LockObject)
						{
							IsInitialisedTaskCompletionSource.SetResult(result: true);
							_initialized = true;
							Mvx.GetSingleton<IMvxMainThreadDispatcher>().RequestMainThreadAction(delegate
							{
								_currentSplashScreen?.InitializationComplete();
							});
						}
					});
				}
			}
		}

		public static MvxAndroidSetupSingleton EnsureSingletonAvailable(Context applicationContext)
		{
			if (MvxSingleton<MvxAndroidSetupSingleton>.Instance != null)
			{
				return MvxSingleton<MvxAndroidSetupSingleton>.Instance;
			}
			lock (LockObject)
			{
				if (MvxSingleton<MvxAndroidSetupSingleton>.Instance != null)
				{
					return MvxSingleton<MvxAndroidSetupSingleton>.Instance;
				}
				new MvxAndroidSetupSingleton().CreateSetup(applicationContext);
				return MvxSingleton<MvxAndroidSetupSingleton>.Instance;
			}
		}

		protected MvxAndroidSetupSingleton()
		{
		}

		protected virtual void CreateSetup(Context applicationContext)
		{
			Type type = FindSetupType();
			if (type == null)
			{
				throw new MvxException("Could not find a Setup class for application");
			}
			try
			{
				_setup = (MvxAndroidSetup)Activator.CreateInstance(type, applicationContext);
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap("Failed to create instance of {0}", type.FullName);
			}
		}

		protected virtual Type FindSetupType()
		{
			return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
				from type in assembly.ExceptionSafeGetTypes()
				where type.Name == "Setup"
				where typeof(MvxAndroidSetup).IsAssignableFrom(type)
				select type).FirstOrDefault();
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				lock (LockObject)
				{
					_currentSplashScreen = null;
				}
			}
			base.Dispose(isDisposing);
		}
	}
	public interface IMvxSavedStateConverter
	{
		IMvxBundle Read(Bundle bundle);

		void Write(Bundle bundle, IMvxBundle savedState);
	}
	public abstract class MvxAndroidSetup : MvxSetup, IMvxAndroidGlobals
	{
		private readonly Context _applicationContext;

		public virtual string ExecutableNamespace => GetType().Namespace;

		public virtual Assembly ExecutableAssembly => GetType().Assembly;

		public Context ApplicationContext => _applicationContext;

		protected virtual IEnumerable<Type> ValueConverterHolders => new List<Type>();

		protected virtual IEnumerable<Assembly> ValueConverterAssemblies
		{
			get
			{
				List<Assembly> list = new List<Assembly>();
				list.AddRange(GetViewModelAssemblies());
				list.AddRange(GetViewAssemblies());
				return list;
			}
		}

		protected virtual IDictionary<string, string> ViewNamespaceAbbreviations => new Dictionary<string, string> { { "Mvx", "MvvmCross.Binding.Droid.Views" } };

		protected virtual IEnumerable<string> ViewNamespaces => new List<string> { "Android.Views", "Android.Widget", "Android.Webkit", "MvvmCross.Binding.Droid.Views" };

		protected virtual IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>
		{
			typeof(View).Assembly,
			typeof(MvxDatePicker).Assembly,
			GetType().Assembly
		};

		protected MvxAndroidSetup(Context applicationContext)
		{
			_applicationContext = applicationContext;
		}

		protected override IMvxPluginManager CreatePluginManager()
		{
			return new MvxFilePluginManager(".Droid", ".dll");
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new MvxDebugTrace();
		}

		protected override void InitializePlatformServices()
		{
			InitializeLifetimeMonitor();
			Mvx.RegisterSingleton((IMvxAndroidGlobals)this);
			MvxIntentResultSink service = new MvxIntentResultSink();
			Mvx.RegisterSingleton((IMvxIntentResultSink)service);
			Mvx.RegisterSingleton((IMvxIntentResultSource)service);
			Mvx.RegisterSingleton((IMvxSingleViewModelCache)new MvxSingleViewModelCache());
			Mvx.RegisterSingleton((IMvxMultipleViewModelCache)new MvxMultipleViewModelCache());
		}

		protected virtual void InitializeLifetimeMonitor()
		{
			MvxAndroidLifetimeMonitor service = CreateLifetimeMonitor();
			Mvx.RegisterSingleton((IMvxAndroidActivityLifetimeListener)service);
			Mvx.RegisterSingleton((IMvxAndroidCurrentTopActivity)service);
			Mvx.RegisterSingleton((IMvxLifetime)service);
		}

		protected virtual MvxAndroidLifetimeMonitor CreateLifetimeMonitor()
		{
			return new MvxAndroidLifetimeMonitor();
		}

		protected virtual void InitializeSavedStateConverter()
		{
			Mvx.RegisterSingleton(CreateSavedStateConverter());
		}

		protected virtual IMvxSavedStateConverter CreateSavedStateConverter()
		{
			return new MvxSavedStateConverter();
		}

		protected sealed override IMvxViewsContainer CreateViewsContainer()
		{
			IMvxAndroidViewsContainer mvxAndroidViewsContainer = CreateViewsContainer(_applicationContext);
			Mvx.RegisterSingleton((IMvxAndroidViewModelRequestTranslator)mvxAndroidViewsContainer);
			Mvx.RegisterSingleton((IMvxAndroidViewModelLoader)mvxAndroidViewsContainer);
			return (mvxAndroidViewsContainer as MvxViewsContainer) ?? throw new MvxException("CreateViewsContainer must return an MvxViewsContainer");
		}

		protected virtual IMvxAndroidViewPresenter CreateViewPresenter()
		{
			return new MvxAndroidViewPresenter();
		}

		protected override IMvxViewDispatcher CreateViewDispatcher()
		{
			return new MvxAndroidViewDispatcher(CreateViewPresenter());
		}

		protected override void InitializeLastChance()
		{
			InitializeSavedStateConverter();
			Mvx.RegisterSingleton((IMvxChildViewModelCache)new MvxChildViewModelCache());
			InitializeBindingBuilder();
			base.InitializeLastChance();
		}

		protected virtual IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
		{
			return new MvxAndroidViewsContainer(applicationContext);
		}

		protected virtual void InitializeBindingBuilder()
		{
			MvxAndroidBindingBuilder mvxAndroidBindingBuilder = CreateBindingBuilder();
			RegisterBindingBuilderCallbacks();
			mvxAndroidBindingBuilder.DoRegistration();
		}

		protected virtual void RegisterBindingBuilderCallbacks()
		{
			Mvx.CallbackWhenRegistered<IMvxValueConverterRegistry>(FillValueConverters);
			Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(FillTargetFactories);
			Mvx.CallbackWhenRegistered<IMvxBindingNameRegistry>(FillBindingNames);
			Mvx.CallbackWhenRegistered<IMvxTypeCache<View>>(FillViewTypes);
			Mvx.CallbackWhenRegistered<IMvxAxmlNameViewTypeResolver>(FillAxmlViewTypeResolver);
			Mvx.CallbackWhenRegistered<IMvxNamespaceListViewTypeResolver>(FillNamespaceListViewTypeResolver);
		}

		protected virtual MvxAndroidBindingBuilder CreateBindingBuilder()
		{
			return new MvxAndroidBindingBuilder();
		}

		protected virtual void FillViewTypes(IMvxTypeCache<View> cache)
		{
			foreach (Assembly androidViewAssembly in AndroidViewAssemblies)
			{
				cache.AddAssembly(androidViewAssembly);
			}
		}

		protected virtual void FillBindingNames(IMvxBindingNameRegistry registry)
		{
		}

		protected virtual void FillAxmlViewTypeResolver(IMvxAxmlNameViewTypeResolver viewTypeResolver)
		{
			foreach (KeyValuePair<string, string> viewNamespaceAbbreviation in ViewNamespaceAbbreviations)
			{
				viewTypeResolver.ViewNamespaceAbbreviations[viewNamespaceAbbreviation.Key] = viewNamespaceAbbreviation.Value;
			}
		}

		protected virtual void FillNamespaceListViewTypeResolver(IMvxNamespaceListViewTypeResolver viewTypeResolver)
		{
			foreach (string viewNamespace in ViewNamespaces)
			{
				viewTypeResolver.Add(viewNamespace);
			}
		}

		protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			registry.Fill(ValueConverterAssemblies);
			registry.Fill(ValueConverterHolders);
		}

		protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
		}

		protected override IMvxNameMapping CreateViewToViewModelNaming()
		{
			return new MvxPostfixAwareViewToViewModelNameMapping("View", "Activity");
		}
	}
	public class MvxDebugTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			Trace(level, tag, message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			Log.Info(tag, message);
			System.Diagnostics.Debug.WriteLine(string.Concat(tag, ":", level, ":", message));
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
				Log.Info(tag, message, args);
				System.Diagnostics.Debug.WriteLine(string.Format(string.Concat(tag, ":", level, ":", message), args));
			}
			catch (FormatException)
			{
				Trace(MvxTraceLevel.Error, tag, "Exception during trace");
				Trace(level, tag, message);
			}
		}
	}
}
namespace MvvmCross.Droid.Views
{
	public interface IMvxAndroidViewModelLoader
	{
		IMvxViewModel Load(Intent intent, IMvxBundle savedState);

		IMvxViewModel Load(Intent intent, IMvxBundle savedState, Type viewModelTypeHint);
	}
	public interface IMvxAndroidViewsContainer : IMvxAndroidViewModelLoader, IMvxAndroidViewModelRequestTranslator
	{
	}
	public interface IMvxMultipleViewModelCache
	{
		void Cache(IMvxViewModel toCache, string viewModelTag = "singleInstanceCache");

		IMvxViewModel GetAndClear(Type viewModelType, string viewModelTag = "singleInstanceCache");

		T GetAndClear<T>(string viewModelTag = "singleInstanceCache") where T : IMvxViewModel;
	}
	public interface IMvxSingleViewModelCache
	{
		void Cache(IMvxViewModel toCache, Bundle bundle);

		IMvxViewModel GetAndClear(Bundle bundle);
	}
	public interface IMvxAndroidViewModelRequestTranslator
	{
		Intent GetIntentFor(MvxViewModelRequest request);

		Tuple<Intent, int> GetIntentWithKeyFor(IMvxViewModel existingViewModelToUse);

		void RemoveSubViewModelWithKey(int key);
	}
	public interface IMvxAndroidSplashScreenActivity
	{
		void InitializationComplete();
	}
	public class MvxMultipleViewModelCache : IMvxMultipleViewModelCache
	{
		private class CachedViewModelType
		{
			public Type ViewModelType { get; }

			public string ViewModelTag { get; }

			public CachedViewModelType(Type viewModelType, string viewModelTag)
			{
				ViewModelType = viewModelType;
				ViewModelTag = viewModelTag ?? string.Empty;
			}

			public override int GetHashCode()
			{
				return (17 * 23 + ViewModelType.GetHashCode()) * 23 + ViewModelTag.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj == this)
				{
					return true;
				}
				if (obj is CachedViewModelType cachedViewModelType && cachedViewModelType.ViewModelTag.Equals(ViewModelTag))
				{
					return cachedViewModelType.ViewModelType == ViewModelType;
				}
				return false;
			}
		}

		private readonly Lazy<ConcurrentDictionary<CachedViewModelType, IMvxViewModel>> _lazyCurrentViewModels;

		private ConcurrentDictionary<CachedViewModelType, IMvxViewModel> CurrentViewModels => _lazyCurrentViewModels.Value;

		public MvxMultipleViewModelCache()
		{
			_lazyCurrentViewModels = new Lazy<ConcurrentDictionary<CachedViewModelType, IMvxViewModel>>(() => new ConcurrentDictionary<CachedViewModelType, IMvxViewModel>());
		}

		public void Cache(IMvxViewModel toCache, string viewModelTag = "singleInstanceCache")
		{
			if (toCache != null)
			{
				CachedViewModelType key = new CachedViewModelType(toCache.GetType(), viewModelTag);
				if (!CurrentViewModels.ContainsKey(key))
				{
					CurrentViewModels.TryAdd(key, toCache);
				}
			}
		}

		public IMvxViewModel GetAndClear(Type viewModelType, string viewModelTag = "singleInstanceCache")
		{
			if (viewModelType == null)
			{
				return null;
			}
			CachedViewModelType key = new CachedViewModelType(viewModelType, viewModelTag);
			CurrentViewModels.TryRemove(key, out var value);
			return value;
		}

		public T GetAndClear<T>(string viewModelTag = "singleInstanceCache") where T : IMvxViewModel
		{
			return (T)GetAndClear(typeof(T), viewModelTag);
		}
	}
	public class MvxSingleViewModelCache : IMvxSingleViewModelCache
	{
		private const string BundleCacheKey = "__mvxVMCacheKey";

		private int _counter;

		private IMvxViewModel _currentViewModel;

		public void Cache(IMvxViewModel toCache, Bundle bundle)
		{
			_currentViewModel = toCache;
			_counter++;
			if (_currentViewModel != null)
			{
				bundle.PutInt("__mvxVMCacheKey", _counter);
			}
		}

		public IMvxViewModel GetAndClear(Bundle bundle)
		{
			IMvxViewModel currentViewModel = _currentViewModel;
			_currentViewModel = null;
			if (bundle == null)
			{
				return null;
			}
			if (bundle.GetInt("__mvxVMCacheKey") != _counter)
			{
				return null;
			}
			return currentViewModel;
		}
	}
	public class MvxTranslatedIntent
	{
		public enum TranslationResult
		{
			Request,
			ExistingViewModel
		}

		public TranslationResult Result { get; private set; }

		public IMvxViewModel ExistingViewModel { get; private set; }

		public MvxViewModelRequest ViewModelRequest { get; private set; }

		public MvxTranslatedIntent(MvxViewModelRequest viewModelRequest)
		{
			ViewModelRequest = viewModelRequest;
			Result = TranslationResult.Request;
		}

		public MvxTranslatedIntent(IMvxViewModel existingViewModel)
		{
			ExistingViewModel = existingViewModel;
			Result = TranslationResult.ExistingViewModel;
		}
	}
	public interface IMvxChildViewModelCache
	{
		int Cache(IMvxViewModel viewModel);

		IMvxViewModel Get(int index);

		void Remove(int index);
	}
	public interface IMvxAndroidViewPresenter : IMvxViewPresenter
	{
	}
	public interface IMvxChildViewModelOwner
	{
		List<int> OwnedSubViewModelIndicies { get; }
	}
	public class MvxActivityAdapter : MvxBaseActivityAdapter
	{
		protected IMvxAndroidView AndroidView => base.Activity as IMvxAndroidView;

		public MvxActivityAdapter(IMvxEventSourceActivity eventSource)
			: base(eventSource)
		{
		}

		protected override void EventSourceOnStopCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewStop();
		}

		protected override void EventSourceOnStartCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewStart();
		}

		protected override void EventSourceOnStartActivityForResultCalled(object sender, MvxValueEventArgs<MvxStartActivityForResultParameters> MvxValueEventArgs)
		{
			int requestCode = MvxValueEventArgs.Value.RequestCode;
			if (requestCode == 30001)
			{
				MvxTrace.Warning("Warning - activity request code may clash with Mvx code for {0}", (MvxIntentRequestCode)requestCode);
			}
		}

		protected override void EventSourceOnResumeCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewResume();
		}

		protected override void EventSourceOnRestartCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewRestart();
		}

		protected override void EventSourceOnPauseCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewPause();
		}

		protected override void EventSourceOnNewIntentCalled(object sender, MvxValueEventArgs<Intent> MvxValueEventArgs)
		{
			AndroidView.OnViewNewIntent();
		}

		protected override void EventSourceOnDestroyCalled(object sender, EventArgs eventArgs)
		{
			AndroidView.OnViewDestroy();
		}

		protected override void EventSourceOnCreateCalled(object sender, MvxValueEventArgs<Bundle> eventArgs)
		{
			AndroidView.OnViewCreate(eventArgs.Value);
		}

		protected override void EventSourceOnSaveInstanceStateCalled(object sender, MvxValueEventArgs<Bundle> bundleArgs)
		{
			IMvxBundle mvxBundle = AndroidView.CreateSaveStateBundle();
			if (mvxBundle != null)
			{
				if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service))
				{
					MvxTrace.Warning("Saved state converter not available - saving state will be hard");
				}
				else
				{
					service.Write(bundleArgs.Value, mvxBundle);
				}
			}
			Mvx.Resolve<IMvxSingleViewModelCache>().Cache(AndroidView.ViewModel, bundleArgs.Value);
		}

		protected override void EventSourceOnActivityResultCalled(object sender, MvxValueEventArgs<MvxActivityResultParameters> args)
		{
			IMvxIntentResultSink mvxIntentResultSink = Mvx.Resolve<IMvxIntentResultSink>();
			MvxActivityResultParameters value = args.Value;
			MvxIntentResultEventArgs result = new MvxIntentResultEventArgs(value.RequestCode, value.ResultCode, value.Data);
			mvxIntentResultSink.OnResult(result);
		}
	}
	public static class MvxActivityViewExtensions
	{
		public static void AddEventListeners(this IMvxEventSourceActivity activity)
		{
			if (activity is IMvxAndroidView)
			{
				new MvxActivityAdapter(activity);
			}
			if (activity is IMvxBindingContextOwner)
			{
				new MvxBindingActivityAdapter(activity);
			}
			if (activity is IMvxChildViewModelOwner)
			{
				new MvxChildViewModelOwnerAdapter(activity);
			}
		}

		public static void OnViewCreate(this IMvxAndroidView androidView, Bundle bundle)
		{
			androidView.EnsureSetupInitialized();
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnCreate(activity);
			});
			IMvxSingleViewModelCache mvxSingleViewModelCache = Mvx.Resolve<IMvxSingleViewModelCache>();
			IMvxViewModel cached = mvxSingleViewModelCache.GetAndClear(bundle);
			IMvxAndroidView view = androidView;
			IMvxBundle savedState = GetSavedStateFromBundle(bundle);
			view.OnViewCreate(() => cached ?? androidView.LoadViewModel(savedState));
		}

		private static IMvxBundle GetSavedStateFromBundle(Bundle bundle)
		{
			if (bundle == null)
			{
				return null;
			}
			if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service))
			{
				MvxTrace.Trace("No saved state converter available - this is OK if seen during start");
				return null;
			}
			return service.Read(bundle);
		}

		public static void OnViewNewIntent(this IMvxAndroidView androidView)
		{
			Mvx.Warning("OnViewNewIntent called - but this is not fully handled within MvvmCross currently. Check https://github.com/slodge/MvvmCross/pull/294 for more info");
		}

		public static void OnViewDestroy(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnDestroy(activity);
			});
			MvxViewExtensionMethods.OnViewDestroy(androidView);
		}

		public static void OnViewStart(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnStart(activity);
			});
		}

		public static void OnViewRestart(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnRestart(activity);
			});
		}

		public static void OnViewStop(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnStop(activity);
			});
		}

		public static void OnViewResume(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnResume(activity);
			});
		}

		public static void OnViewPause(this IMvxAndroidView androidView)
		{
			androidView.OnLifetimeEvent(delegate(IMvxAndroidActivityLifetimeListener listener, Activity activity)
			{
				listener.OnPause(activity);
			});
		}

		private static void OnLifetimeEvent(this IMvxAndroidView androidView, Action<IMvxAndroidActivityLifetimeListener, Activity> report)
		{
			IMvxAndroidActivityLifetimeListener arg = Mvx.Resolve<IMvxAndroidActivityLifetimeListener>();
			report(arg, androidView.ToActivity());
		}

		public static Activity ToActivity(this IMvxAndroidView androidView)
		{
			return (androidView as Activity) ?? throw new MvxException("OnViewCreate called from an IMvxView which is not an Android Activity");
		}

		private static IMvxViewModel LoadViewModel(this IMvxAndroidView androidView, IMvxBundle savedState)
		{
			Activity activity = androidView.ToActivity();
			Type type = androidView.FindAssociatedViewModelTypeOrNull();
			if (type == typeof(MvxNullViewModel))
			{
				return new MvxNullViewModel();
			}
			if (type == null || type == typeof(IMvxViewModel))
			{
				MvxTrace.Trace("No ViewModel class specified for {0} in LoadViewModel", androidView.GetType().Name);
			}
			return Mvx.Resolve<IMvxAndroidViewModelLoader>().Load(activity.Intent, savedState, type);
		}

		private static void EnsureSetupInitialized(this IMvxAndroidView androidView)
		{
			if (!(androidView is IMvxAndroidSplashScreenActivity))
			{
				MvxAndroidSetupSingleton.EnsureSingletonAvailable(androidView.ToActivity().ApplicationContext).EnsureInitialized();
			}
		}
	}
	public class MvxAndroidViewPresenter : MvxViewPresenter, IMvxAndroidViewPresenter, IMvxViewPresenter
	{
		protected Activity Activity => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

		public override void Show(MvxViewModelRequest request)
		{
			Intent intent = CreateIntentForRequest(request);
			Show(intent);
		}

		protected virtual void Show(Intent intent)
		{
			Activity activity = Activity;
			if (activity == null)
			{
				MvxTrace.Warning("Cannot Resolve current top activity");
			}
			else
			{
				activity.StartActivity(intent);
			}
		}

		protected virtual Intent CreateIntentForRequest(MvxViewModelRequest request)
		{
			return Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>().GetIntentFor(request);
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			if (!HandlePresentationChange(hint))
			{
				if (hint is MvxClosePresentationHint mvxClosePresentationHint)
				{
					Close(mvxClosePresentationHint.ViewModelToClose);
					return;
				}
				MvxTrace.Warning("Hint ignored {0}", hint.GetType().Name);
			}
		}

		public virtual void Close(IMvxViewModel viewModel)
		{
			Activity activity = Activity;
			if (!(activity is IMvxView mvxView))
			{
				Mvx.Warning("Ignoring close for viewmodel - rootframe has no current page");
			}
			else if (mvxView.ViewModel != viewModel)
			{
				Mvx.Warning("Ignoring close for viewmodel - rootframe's current page is not the view for the requested viewmodel");
			}
			else
			{
				activity.Finish();
			}
		}
	}
	public class MvxAndroidLifetimeMonitor : MvxLifetimeMonitor, IMvxAndroidActivityLifetimeListener, IMvxAndroidCurrentTopActivity
	{
		private int _createdActivityCount;

		public Activity Activity { get; private set; }

		public virtual void OnCreate(Activity activity)
		{
			_createdActivityCount++;
			if (_createdActivityCount == 1)
			{
				FireLifetimeChange(MvxLifetimeEvent.ActivatedFromDisk);
			}
			Activity = activity;
		}

		public virtual void OnStart(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnRestart(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnResume(Activity activity)
		{
			Activity = activity;
		}

		public virtual void OnPause(Activity activity)
		{
		}

		public virtual void OnStop(Activity activity)
		{
		}

		public virtual void OnDestroy(Activity activity)
		{
			if (Activity == activity)
			{
				Activity = null;
			}
			_createdActivityCount--;
			if (_createdActivityCount == 0)
			{
				FireLifetimeChange(MvxLifetimeEvent.Closing);
			}
		}

		public virtual void OnViewNewIntent(Activity activity)
		{
			Activity = activity;
		}
	}
	[Register("mvvmcross.droid.views.MvxSplashScreenActivity")]
	public abstract class MvxSplashScreenActivity : MvxActivity, IMvxAndroidSplashScreenActivity
	{
		private const int NoContent = 0;

		private readonly int _resourceId;

		private bool _isResumed;

		public new MvxNullViewModel ViewModel
		{
			get
			{
				return base.ViewModel as MvxNullViewModel;
			}
			set
			{
				base.ViewModel = value;
			}
		}

		protected MvxSplashScreenActivity(int resourceId = 0)
		{
			_resourceId = resourceId;
		}

		protected virtual void RequestWindowFeatures()
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
		}

		protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeatures();
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext).InitializeFromSplashScreen(this);
			base.OnCreate(bundle);
			if (_resourceId != 0)
			{
				View contentView = LayoutInflater.Inflate(_resourceId, null);
				SetContentView(contentView);
			}
		}

		protected override void OnResume()
		{
			base.OnResume();
			_isResumed = true;
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext).InitializeFromSplashScreen(this);
		}

		protected override void OnPause()
		{
			_isResumed = false;
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext).RemoveSplashScreen(this);
			base.OnPause();
		}

		public virtual void InitializationComplete()
		{
			if (_isResumed)
			{
				TriggerFirstNavigate();
			}
		}

		protected virtual void TriggerFirstNavigate()
		{
			Mvx.Resolve<IMvxAppStart>().Start();
		}
	}
	public class MvxBindingActivityAdapter : MvxBaseActivityAdapter
	{
		private IMvxAndroidBindingContext BindingContext => (IMvxAndroidBindingContext)((IMvxBindingContextOwner)base.Activity).BindingContext;

		public MvxBindingActivityAdapter(IMvxEventSourceActivity eventSource)
			: base(eventSource)
		{
		}

		protected override void EventSourceOnCreateWillBeCalled(object sender, MvxValueEventArgs<Bundle> MvxValueEventArgs)
		{
			BindingContext.ClearAllBindings();
			base.EventSourceOnCreateWillBeCalled(sender, MvxValueEventArgs);
		}

		protected override void EventSourceOnDestroyCalled(object sender, EventArgs eventArgs)
		{
			BindingContext.ClearAllBindings();
			base.EventSourceOnDestroyCalled(sender, eventArgs);
		}

		protected override void EventSourceOnDisposeCalled(object sender, EventArgs eventArgs)
		{
			BindingContext.ClearAllBindings();
			base.EventSourceOnDisposeCalled(sender, eventArgs);
		}
	}
	public class MvxChildViewModelOwnerAdapter : MvxBaseActivityAdapter
	{
		protected IMvxChildViewModelOwner ChildOwner => (IMvxChildViewModelOwner)base.Activity;

		public MvxChildViewModelOwnerAdapter(IMvxEventSourceActivity eventSource)
			: base(eventSource)
		{
			if (!(eventSource is IMvxChildViewModelOwner))
			{
				throw new MvxException("You cannot use a MvxChildViewModelOwnerAdapter on {0}", eventSource.GetType().Name);
			}
		}

		protected override void EventSourceOnDestroyCalled(object sender, EventArgs eventArgs)
		{
			ChildOwner.ClearOwnedSubIndicies();
			base.EventSourceOnDestroyCalled(sender, eventArgs);
		}

		protected override void EventSourceOnDisposeCalled(object sender, EventArgs eventArgs)
		{
			ChildOwner.ClearOwnedSubIndicies();
			base.EventSourceOnDisposeCalled(sender, eventArgs);
		}
	}
	public static class MvxChildViewModelOwnerExtensions
	{
		public static Intent CreateIntentFor<TTargetViewModel>(this IMvxAndroidView view, object parameterObject) where TTargetViewModel : class, IMvxViewModel
		{
			return view.CreateIntentFor<TTargetViewModel>(parameterObject.ToSimplePropertyDictionary());
		}

		public static Intent CreateIntentFor<TTargetViewModel>(this IMvxAndroidView view, IDictionary<string, string> parameterValues = null) where TTargetViewModel : class, IMvxViewModel
		{
			MvxViewModelRequest<TTargetViewModel> request = new MvxViewModelRequest<TTargetViewModel>(new MvxBundle(parameterValues), null, MvxRequestedBy.UserAction);
			return view.CreateIntentFor(request);
		}

		public static Intent CreateIntentFor(this IMvxAndroidView view, MvxViewModelRequest request)
		{
			return Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>().GetIntentFor(request);
		}

		public static Intent CreateIntentFor(this IMvxChildViewModelOwner view, IMvxViewModel subViewModel)
		{
			Tuple<Intent, int> intentWithKeyFor = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>().GetIntentWithKeyFor(subViewModel);
			view.OwnedSubViewModelIndicies.Add(intentWithKeyFor.Item2);
			return intentWithKeyFor.Item1;
		}

		public static void ClearOwnedSubIndicies(this IMvxChildViewModelOwner view)
		{
			IMvxAndroidViewModelRequestTranslator mvxAndroidViewModelRequestTranslator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
			foreach (int ownedSubViewModelIndicy in view.OwnedSubViewModelIndicies)
			{
				mvxAndroidViewModelRequestTranslator.RemoveSubViewModelWithKey(ownedSubViewModelIndicy);
			}
			view.OwnedSubViewModelIndicies.Clear();
		}
	}
	public class MvxSavedStateConverter : IMvxSavedStateConverter
	{
		private const string ExtrasKey = "MvxSaved";

		public IMvxBundle Read(Bundle bundle)
		{
			string text = bundle?.GetString("MvxSaved");
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			try
			{
				return new MvxBundle(Mvx.Resolve<IMvxNavigationSerializer>().Serializer.DeserializeObject<Dictionary<string, string>>(text));
			}
			catch (Exception)
			{
				MvxTrace.Error("Problem getting the saved state - will return null - from {0}", text);
				return null;
			}
		}

		public void Write(Bundle bundle, IMvxBundle savedState)
		{
			if (savedState != null && savedState.Data.Count != 0)
			{
				string value = Mvx.Resolve<IMvxNavigationSerializer>().Serializer.SerializeObject(savedState.Data);
				bundle.PutString("MvxSaved", value);
			}
		}
	}
	[Obsolete("TabActivity is obsolete. Use ViewPager + Indicator or any other Activity with Toolbar support.")]
	[Register("mvvmcross.droid.views.MvxTabActivity")]
	public abstract class MvxTabActivity : MvxEventSourceTabActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxChildViewModelOwner
	{
		private readonly List<int> _ownedSubViewModelIndicies = new List<int>();

		public List<int> OwnedSubViewModelIndicies => _ownedSubViewModelIndicies;

		public object DataContext
		{
			get
			{
				return BindingContext.DataContext;
			}
			set
			{
				BindingContext.DataContext = value;
			}
		}

		public IMvxViewModel ViewModel
		{
			get
			{
				return DataContext as IMvxViewModel;
			}
			set
			{
				DataContext = value;
				OnViewModelSet();
			}
		}

		public IMvxBindingContext BindingContext { get; set; }

		protected MvxTabActivity()
		{
			BindingContext = new MvxAndroidBindingContext(this, this);
			this.AddEventListeners();
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			StartActivityForResult(intent, requestCode);
		}

		protected virtual void OnViewModelSet()
		{
		}

		public override void SetContentView(int layoutResId)
		{
			View contentView = this.BindingInflate(layoutResId, null);
			SetContentView(contentView);
		}

		protected override void AttachBaseContext(Context @base)
		{
			base.AttachBaseContext(MvxContextWrapper.Wrap(@base, this));
		}
	}
	[Obsolete("TabActivity is obsolete. Use ViewPager + Indicator or any other Activity with Toolbar support.")]
	public class MvxTabActivity<TViewModel> : MvxTabActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get
			{
				return (TViewModel)base.ViewModel;
			}
			set
			{
				base.ViewModel = value;
			}
		}
	}
	public interface IMvxAndroidView : IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
	{
	}
	public interface IMvxAndroidView<TViewModel> : IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
	}
	public class MvxAndroidMainThreadDispatcher : MvxMainThreadDispatcher
	{
		public bool RequestMainThreadAction(Action action)
		{
			if (Application.SynchronizationContext == SynchronizationContext.Current)
			{
				action();
			}
			else
			{
				Application.SynchronizationContext.Post(delegate
				{
					MvxMainThreadDispatcher.ExceptionMaskedAction(action);
				}, null);
			}
			return true;
		}
	}
	public class MvxAndroidViewDispatcher : MvxAndroidMainThreadDispatcher, IMvxViewDispatcher, IMvxMainThreadDispatcher
	{
		private readonly IMvxAndroidViewPresenter _presenter;

		public MvxAndroidViewDispatcher(IMvxAndroidViewPresenter presenter)
		{
			_presenter = presenter;
		}

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			return RequestMainThreadAction(delegate
			{
				_presenter.Show(request);
			});
		}

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			return RequestMainThreadAction(delegate
			{
				_presenter.ChangePresentation(hint);
			});
		}
	}
	public class MvxAndroidViewsContainer : MvxViewsContainer, IMvxAndroidViewsContainer, IMvxAndroidViewModelLoader, IMvxAndroidViewModelRequestTranslator
	{
		private const string ExtrasKey = "MvxLaunchData";

		private const string SubViewModelKey = "MvxSubViewModelKey";

		private readonly Context _applicationContext;

		public MvxAndroidViewsContainer(Context applicationContext)
		{
			_applicationContext = applicationContext;
		}

		public virtual IMvxViewModel Load(Intent intent, IMvxBundle savedState)
		{
			return Load(intent, null, null);
		}

		public virtual IMvxViewModel Load(Intent intent, IMvxBundle savedState, Type viewModelTypeHint)
		{
			if (intent == null)
			{
				MvxTrace.Error("Null Intent seen when creating ViewModel");
				return null;
			}
			if (intent.Action == "android.intent.action.MAIN")
			{
				MvxTrace.Trace("Creating ViewModel for ActionMain");
				return DirectLoad(savedState, viewModelTypeHint);
			}
			if (intent.Extras == null)
			{
				MvxTrace.Trace("Null Extras seen on Intent when creating ViewModel - have you tried to navigate to an MvvmCross View directly? Will try direct load");
				return DirectLoad(savedState, viewModelTypeHint);
			}
			if (TryGetEmbeddedViewModel(intent, out var mvxViewModel))
			{
				MvxTrace.Trace("Embedded ViewModel used");
				return mvxViewModel;
			}
			MvxTrace.Trace("Attempting to load new ViewModel from Intent with Extras");
			IMvxViewModel mvxViewModel2 = CreateViewModelFromIntent(intent, savedState);
			if (mvxViewModel2 != null)
			{
				return mvxViewModel2;
			}
			MvxTrace.Trace("ViewModel not loaded from Extras - will try DirectLoad");
			return DirectLoad(savedState, viewModelTypeHint);
		}

		protected virtual IMvxViewModel DirectLoad(IMvxBundle savedState, Type viewModelTypeHint)
		{
			if (viewModelTypeHint == null)
			{
				Mvx.Error("Unable to load viewmodel - no type hint provided");
				return null;
			}
			IMvxViewModelLoader mvxViewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
			MvxViewModelRequest defaultRequest = MvxViewModelRequest.GetDefaultRequest(viewModelTypeHint);
			return mvxViewModelLoader.LoadViewModel(defaultRequest, savedState);
		}

		protected virtual IMvxViewModel CreateViewModelFromIntent(Intent intent, IMvxBundle savedState)
		{
			string text = intent.Extras.GetString("MvxLaunchData");
			if (text == null)
			{
				return null;
			}
			MvxViewModelRequest viewModelRequest = Mvx.Resolve<IMvxNavigationSerializer>().Serializer.DeserializeObject<MvxViewModelRequest>(text);
			return ViewModelFromRequest(viewModelRequest, savedState);
		}

		protected virtual IMvxViewModel ViewModelFromRequest(MvxViewModelRequest viewModelRequest, IMvxBundle savedState)
		{
			return Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(viewModelRequest, savedState);
		}

		protected virtual bool TryGetEmbeddedViewModel(Intent intent, out IMvxViewModel mvxViewModel)
		{
			int num = intent.Extras.GetInt("MvxSubViewModelKey");
			if (num != 0)
			{
				mvxViewModel = Mvx.Resolve<IMvxChildViewModelCache>().Get(num);
				return true;
			}
			mvxViewModel = null;
			return false;
		}

		public virtual Intent GetIntentFor(MvxViewModelRequest request)
		{
			Type viewType = GetViewType(request.ViewModelType);
			if (viewType == null)
			{
				throw new MvxException("View Type not found for " + request.ViewModelType);
			}
			string value = Mvx.Resolve<IMvxNavigationSerializer>().Serializer.SerializeObject(request);
			Intent intent = new Intent(_applicationContext, viewType);
			intent.PutExtra("MvxLaunchData", value);
			AdjustIntentForPresentation(intent, request);
			return intent;
		}

		protected virtual void AdjustIntentForPresentation(Intent intent, MvxViewModelRequest request)
		{
			intent.AddFlags(ActivityFlags.NewTask);
		}

		public virtual Tuple<Intent, int> GetIntentWithKeyFor(IMvxViewModel viewModel)
		{
			MvxViewModelRequest defaultRequest = MvxViewModelRequest.GetDefaultRequest(viewModel.GetType());
			Intent intentFor = GetIntentFor(defaultRequest);
			int num = Mvx.Resolve<IMvxChildViewModelCache>().Cache(viewModel);
			intentFor.PutExtra("MvxSubViewModelKey", num);
			return new Tuple<Intent, int>(intentFor, num);
		}

		public void RemoveSubViewModelWithKey(int key)
		{
			Mvx.Resolve<IMvxChildViewModelCache>().Remove(key);
		}
	}
	[Register("mvvmcross.droid.views.MvxActivity")]
	public abstract class MvxActivity : MvxEventSourceActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
	{
		public object DataContext
		{
			get
			{
				return BindingContext.DataContext;
			}
			set
			{
				BindingContext.DataContext = value;
			}
		}

		public IMvxViewModel ViewModel
		{
			get
			{
				return DataContext as IMvxViewModel;
			}
			set
			{
				DataContext = value;
				OnViewModelSet();
			}
		}

		public IMvxBindingContext BindingContext { get; set; }

		protected MvxActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected MvxActivity()
		{
			BindingContext = new MvxAndroidBindingContext(this, this);
			this.AddEventListeners();
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			StartActivityForResult(intent, requestCode);
		}

		public override void SetContentView(int layoutResId)
		{
			View contentView = this.BindingInflate(layoutResId, null);
			SetContentView(contentView);
		}

		protected virtual void OnViewModelSet()
		{
		}

		protected override void AttachBaseContext(Context @base)
		{
			if (this is IMvxAndroidSplashScreenActivity)
			{
				base.AttachBaseContext(@base);
			}
			else
			{
				base.AttachBaseContext(MvxContextWrapper.Wrap(@base, this));
			}
		}
	}
	public abstract class MvxActivity<TViewModel> : MvxActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
		public new TViewModel ViewModel
		{
			get
			{
				return (TViewModel)base.ViewModel;
			}
			set
			{
				base.ViewModel = value;
			}
		}
	}
	public class MvxChildViewModelCache : IMvxChildViewModelCache
	{
		private static int _unique = 1;

		private readonly Dictionary<int, IMvxViewModel> _viewModels = new Dictionary<int, IMvxViewModel>();

		public int Cache(IMvxViewModel viewModel)
		{
			int num = _unique++;
			_viewModels[num] = viewModel;
			return num;
		}

		public IMvxViewModel Get(int index)
		{
			return _viewModels[index];
		}

		public void Remove(int index)
		{
			_viewModels.Remove(index);
		}
	}
}
namespace MvvmCross.Droid.ViewModels
{
	public class MvxAndroidPropertyChangedListener : MvxPropertyChangedListener
	{
		private readonly WeakReference<IJavaObject> _target;

		public MvxAndroidPropertyChangedListener(INotifyPropertyChanged source, IJavaObject target)
			: base(source)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			_target = new WeakReference<IJavaObject>(target);
		}

		public override void NotificationObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (_target.TryGetTarget(out var target) && !(target.Handle == IntPtr.Zero))
			{
				base.NotificationObjectOnPropertyChanged(sender, e);
			}
		}
	}
}
namespace MvvmCross.Droid.Services
{
	[Register("mvvmcross.droid.services.MvxBroadcastReceiver")]
	public abstract class MvxBroadcastReceiver : BroadcastReceiver
	{
		protected MvxBroadcastReceiver(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected MvxBroadcastReceiver()
		{
		}

		public override void OnReceive(Context context, Intent intent)
		{
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(context).EnsureInitialized();
		}
	}
	[Register("mvvmcross.droid.services.MvxIntentService")]
	public abstract class MvxIntentService : IntentService
	{
		protected MvxIntentService(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected MvxIntentService(string name)
			: base(name)
		{
		}

		protected override void OnHandleIntent(Intent intent)
		{
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext).EnsureInitialized();
		}
	}
}
