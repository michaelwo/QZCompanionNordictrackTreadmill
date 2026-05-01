using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Widget;
using AndroidX.DrawerLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.SlidingPaneLayout.Widget;
using AndroidX.ViewPager.Widget;
using Java.Lang;
using MvvmCross.Binding;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.ResourceHelpers;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Shared.Fragments;
using MvvmCross.Droid.Shared.Fragments.EventSource;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat.EventSource;
using MvvmCross.Droid.Support.V7.AppCompat.Target;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Droid.Support.V7.AppCompat")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace MvvmCross.Droid.Support.V7.AppCompat
{
	public class ActionBarDrawerEventArgs : EventArgs
	{
		public View DrawerView { get; private set; }

		public ActionBarDrawerEventArgs(View drawerView)
		{
			DrawerView = drawerView;
		}
	}
	public sealed class ActionBarDrawerSlideEventArgs : ActionBarDrawerEventArgs
	{
		public float SlideOffset { get; private set; }

		public ActionBarDrawerSlideEventArgs(View drawerView, float slideOffset)
			: base(drawerView)
		{
			SlideOffset = slideOffset;
		}
	}
	public sealed class ActionBarDrawerStateChangeEventArgs : EventArgs
	{
		public int NewState { get; private set; }

		public ActionBarDrawerStateChangeEventArgs(int newState)
		{
			NewState = newState;
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.MvxActionBarDrawerToggle")]
	public sealed class MvxActionBarDrawerToggle : ActionBarDrawerToggle
	{
		public event EventHandler<ActionBarDrawerEventArgs> DrawerClosed;

		public event EventHandler<ActionBarDrawerEventArgs> DrawerOpened;

		public event EventHandler<ActionBarDrawerSlideEventArgs> DrawerSlide;

		public event EventHandler<ActionBarDrawerStateChangeEventArgs> DrawerStateChanged;

		public MvxActionBarDrawerToggle(IntPtr ptr, JniHandleOwnership ownership)
			: base(ptr, ownership)
		{
		}

		public MvxActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, int openDrawerContentDescRes, int closeDrawerContentDescRes)
			: base(activity, drawerLayout, openDrawerContentDescRes, closeDrawerContentDescRes)
		{
		}

		public MvxActionBarDrawerToggle(Activity activity, DrawerLayout drawerLayout, AndroidX.AppCompat.Widget.Toolbar toolbar, int openDrawerContentDescRes, int closeDrawerContentDescRes)
			: base(activity, drawerLayout, toolbar, openDrawerContentDescRes, closeDrawerContentDescRes)
		{
		}

		public override void OnDrawerClosed(View drawerView)
		{
			this.DrawerClosed?.Invoke(this, new ActionBarDrawerEventArgs(drawerView));
			base.OnDrawerClosed(drawerView);
		}

		public override void OnDrawerOpened(View drawerView)
		{
			this.DrawerOpened?.Invoke(this, new ActionBarDrawerEventArgs(drawerView));
			base.OnDrawerOpened(drawerView);
		}

		public override void OnDrawerSlide(View drawerView, float slideOffset)
		{
			this.DrawerSlide?.Invoke(this, new ActionBarDrawerSlideEventArgs(drawerView, slideOffset));
			base.OnDrawerSlide(drawerView, slideOffset);
		}

		public override void OnDrawerStateChanged(int newState)
		{
			this.DrawerStateChanged?.Invoke(this, new ActionBarDrawerStateChangeEventArgs(newState));
			base.OnDrawerStateChanged(newState);
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.MvxAppCompatActivity")]
	public class MvxAppCompatActivity : MvxEventSourceAppCompatActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
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

		protected MvxAppCompatActivity()
		{
			BindingContext = new MvxAndroidBindingContext((Context)(object)this, this);
			this.AddEventListeners();
		}

		protected MvxAppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			((Activity)(object)this).StartActivityForResult(intent, requestCode);
		}

		protected virtual void OnViewModelSet()
		{
		}

		public override void SetContentView(int layoutResId)
		{
			View contentView = this.BindingInflate(layoutResId, null);
			((Activity)(object)this).SetContentView(contentView);
		}

		protected override void AttachBaseContext(Context @base)
		{
			if (this is IMvxAndroidSplashScreenActivity)
			{
				((ContextWrapper)(object)this).AttachBaseContext(@base);
			}
			else
			{
				((ContextWrapper)(object)this).AttachBaseContext((Context)MvxContextWrapper.Wrap(@base, this));
			}
		}

		public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
		{
			return MvxAppCompatActivityHelper.OnCreateView(parent, name, context, attrs) ?? ((Activity)(object)this).OnCreateView(parent, name, context, attrs);
		}
	}
	public abstract class MvxAppCompatActivity<TViewModel> : MvxAppCompatActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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

		protected MvxAppCompatActivity(IntPtr ptr, JniHandleOwnership ownership)
			: base(ptr, ownership)
		{
		}

		protected MvxAppCompatActivity()
		{
		}
	}
	public static class MvxAppCompatActivityHelper
	{
		public static View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
		{
			return name switch
			{
				"MvxSpinner" => new MvxAppCompatSpinner(context, attrs), 
				"MvxImageView" => new MvxAppCompatImageView(context, attrs), 
				"MvxRadioGroup" => new MvxAppCompatRadioGroup(context, attrs), 
				"MvxAutoCompleteTextView" => new MvxAppCompatAutoCompleteTextView(context, attrs), 
				_ => null, 
			};
		}
	}
	public static class MvxAppCompatSetupHelper
	{
		public static void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxAppCompatAutoCompleteTextViewPartialTextTargetBinding), typeof(MvxAppCompatAutoCompleteTextView), "PartialText");
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxAppCompatAutoCompleteTextViewSelectedObjectTargetBinding), typeof(MvxAppCompatAutoCompleteTextView), "SelectedObject");
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxAppCompatSpinner spinner) => new MvxAppCompatSpinnerSelectedItemBinding(spinner));
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxAppCompatRadioGroup radioGroup) => new MvxAppCompatRadioGroupSelectedItemBinding(radioGroup));
			registry.RegisterCustomBindingFactory("Query", (AndroidX.AppCompat.Widget.SearchView search) => new MvxAppCompatSearchViewQueryTextTargetBinding(search));
			registry.RegisterCustomBindingFactory("Subtitle", (AndroidX.AppCompat.Widget.Toolbar toolbar) => new MvxToolbarSubtitleBinding(toolbar));
		}

		public static void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
		{
			registry.AddOrOverwrite(typeof(AndroidX.AppCompat.Widget.SearchView), "Query");
			registry.AddOrOverwrite(typeof(MvxAppCompatImageView), "ImageUrl");
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.MvxAppCompatDialogFragment")]
	public abstract class MvxAppCompatDialogFragment : MvxEventSourceAppCompatDialogFragment, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer
	{
		private object _dataContext;

		public IMvxBindingContext BindingContext { get; set; }

		public object DataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				_dataContext = value;
				if (BindingContext != null)
				{
					BindingContext.DataContext = value;
				}
			}
		}

		public virtual IMvxViewModel ViewModel
		{
			get
			{
				return DataContext as IMvxViewModel;
			}
			set
			{
				DataContext = value;
			}
		}

		public virtual string UniqueImmutableCacheTag => base.Tag;

		protected MvxAppCompatDialogFragment()
		{
			this.AddEventListeners();
		}

		protected MvxAppCompatDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected void EnsureBindingContextSet(Bundle b0)
		{
			this.EnsureBindingContextIsSet(b0);
		}
	}
	public abstract class MvxAppCompatDialogFragment<TViewModel> : MvxAppCompatDialogFragment, IMvxFragmentView<TViewModel>, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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
	[Register("mvvmcross.droid.support.v7.appcompat.MvxSplashScreenAppCompatActivity")]
	public abstract class MvxSplashScreenAppCompatActivity : MvxAppCompatActivity, IMvxAndroidSplashScreenActivity
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

		protected MvxSplashScreenAppCompatActivity(int resourceId = 0)
		{
			_resourceId = resourceId;
		}

		protected virtual void RequestWindowFeatures()
		{
			((Activity)(object)this).RequestWindowFeature(WindowFeatures.NoTitle);
		}

		protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeatures();
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(((Context)(object)this).ApplicationContext).InitializeFromSplashScreen(this);
			base.OnCreate(bundle);
			if (_resourceId != 0)
			{
				View contentView = ((Activity)(object)this).LayoutInflater.Inflate(_resourceId, null);
				((Activity)(object)this).SetContentView(contentView);
			}
		}

		protected override void OnResume()
		{
			base.OnResume();
			_isResumed = true;
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(((Context)(object)this).ApplicationContext).InitializeFromSplashScreen(this);
		}

		protected override void OnPause()
		{
			_isResumed = false;
			MvxAndroidSetupSingleton.EnsureSingletonAvailable(((Context)(object)this).ApplicationContext).RemoveSplashScreen(this);
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
	[Register("mvvmcross.droid.support.v7.appcompat.MvxCachingFragmentCompatActivity")]
	public class MvxCachingFragmentCompatActivity : MvxAppCompatActivity, IFragmentCacheableActivity, IMvxFragmentHost
	{
		protected enum FragmentReplaceMode
		{
			NoReplace,
			ReplaceFragment,
			ReplaceFragmentAndViewModel
		}

		public const string ViewModelRequestBundleKey = "__mvxViewModelRequest";

		private const string SavedFragmentTypesKey = "__mvxSavedFragmentTypes";

		private IFragmentCacheConfiguration _fragmentCacheConfiguration;

		public IFragmentCacheConfiguration FragmentCacheConfiguration => _fragmentCacheConfiguration ?? (_fragmentCacheConfiguration = BuildFragmentCacheConfiguration());

		public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
		{
			return MvxAppCompatActivityHelper.OnCreateView(parent, name, context, attrs) ?? base.OnCreateView(parent, name, context, attrs);
		}

		protected MvxCachingFragmentCompatActivity()
		{
		}

		protected MvxCachingFragmentCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static void RestoreViewModelsFromBundle(IMvxJsonConverter serializer, Bundle savedInstanceState)
		{
			if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service))
			{
				Mvx.Trace("Could not resolve IMvxSavedStateConverter, won't be able to convert saved state");
				return;
			}
			if (!Mvx.TryResolve<IMvxMultipleViewModelCache>(out var service2))
			{
				Mvx.Trace("Could not resolve IMvxMultipleViewModelCache, won't be able to convert saved state");
				return;
			}
			if (!Mvx.TryResolve<IMvxViewModelLoader>(out var service3))
			{
				Mvx.Trace("Could not resolve IMvxViewModelLoader, won't be able to load ViewModel for caching");
				return;
			}
			string text = savedInstanceState.GetString("__mvxSavedFragmentTypes");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			foreach (KeyValuePair<string, Type> item in serializer.DeserializeObject<Dictionary<string, Type>>(text))
			{
				Bundle bundle = savedInstanceState.GetBundle(item.Key);
				if (!bundle.IsEmpty)
				{
					IMvxBundle savedState = service.Read(bundle);
					MvxViewModelRequest defaultRequest = MvxViewModelRequest.GetDefaultRequest(item.Value);
					IMvxViewModel toCache = service3.LoadViewModel(defaultRequest, savedState);
					service2.Cache(toCache, item.Key);
				}
			}
		}

		private void RestoreFragmentsCache()
		{
			foreach (AndroidX.Fragment.App.Fragment currentCacheableFragment in GetCurrentCacheableFragments())
			{
				string tagFromFragment = GetTagFromFragment(currentCacheableFragment);
				GetFragmentInfoByTag(tagFromFragment).CachedFragment = currentCacheableFragment as IMvxFragmentView;
			}
		}

		private Dictionary<string, Type> CreateFragmentTypesDictionary(Bundle outState)
		{
			if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service))
			{
				return null;
			}
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			foreach (IMvxCachedFragmentInfo item in GetCurrentCacheableFragmentsInfo())
			{
				IMvxFragmentView cachedFragment = item.CachedFragment;
				if (cachedFragment != null)
				{
					IMvxBundle savedState = cachedFragment.CreateSaveStateBundle();
					Bundle bundle = new Bundle();
					service.Write(bundle, savedState);
					outState.PutBundle(item.Tag, bundle);
					if (!dictionary.ContainsKey(item.Tag))
					{
						dictionary.Add(item.Tag, item.ViewModelType);
					}
				}
			}
			return dictionary;
		}

		protected virtual void ReplaceFragment(AndroidX.Fragment.App.FragmentTransaction ft, IMvxCachedFragmentInfo fragInfo)
		{
			ft.Replace(fragInfo.ContentId, fragInfo.CachedFragment as AndroidX.Fragment.App.Fragment, fragInfo.Tag);
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			if (FragmentCacheConfiguration.HasAnyFragmentsRegisteredToCache && Mvx.TryResolve<IMvxJsonConverter>(out var service))
			{
				FragmentCacheConfiguration.SaveFragmentCacheConfigurationState(outState, service);
				Dictionary<string, Type> dictionary = CreateFragmentTypesDictionary(outState);
				if (dictionary != null)
				{
					string value = service.SerializeObject(dictionary);
					outState.PutString("__mvxSavedFragmentTypes", value);
				}
			}
		}

		protected virtual void ShowFragment(string tag, int contentId, Bundle bundle, bool forceAddToBackStack = false, bool forceReplaceFragment = false)
		{
			FragmentCacheConfiguration.TryGetValue(tag, out var cachedFragmentInfo);
			IMvxCachedFragmentInfo cachedFragmentInfo2 = null;
			AndroidX.Fragment.App.Fragment fragment = SupportFragmentManager.FindFragmentById(contentId);
			if (fragment != null)
			{
				FragmentCacheConfiguration.TryGetValue(fragment.Tag, out cachedFragmentInfo2);
			}
			if (cachedFragmentInfo == null)
			{
				throw new MvxException("Could not find tag: {0} in cache, you need to register it first.", tag);
			}
			FragmentReplaceMode fragmentReplaceMode = FragmentReplaceMode.ReplaceFragmentAndViewModel;
			if (!forceReplaceFragment)
			{
				fragmentReplaceMode = ShouldReplaceCurrentFragment(cachedFragmentInfo, cachedFragmentInfo2, bundle);
			}
			if (fragmentReplaceMode != FragmentReplaceMode.NoReplace)
			{
				AndroidX.Fragment.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction();
				OnBeforeFragmentChanging(cachedFragmentInfo, fragmentTransaction);
				cachedFragmentInfo.ContentId = contentId;
				if (cachedFragmentInfo.CachedFragment != null && fragmentReplaceMode == FragmentReplaceMode.ReplaceFragment)
				{
					(cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment)?.Arguments.Clear();
					(cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment)?.Arguments.PutAll(bundle);
				}
				else
				{
					cachedFragmentInfo.CachedFragment = AndroidX.Fragment.App.Fragment.Instantiate((Context)(object)this, FragmentJavaName(cachedFragmentInfo.FragmentType), bundle) as IMvxFragmentView;
					OnFragmentCreated(cachedFragmentInfo, fragmentTransaction);
				}
				fragment = cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment;
				fragmentTransaction.Replace(cachedFragmentInfo.ContentId, cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment, cachedFragmentInfo.Tag);
				if (fragmentReplaceMode == FragmentReplaceMode.ReplaceFragmentAndViewModel)
				{
					Mvx.GetSingleton<IMvxMultipleViewModelCache>().GetAndClear(cachedFragmentInfo.ViewModelType, GetTagFromFragment(cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment));
				}
				if ((fragment != null && cachedFragmentInfo.AddToBackStack) || forceAddToBackStack)
				{
					fragmentTransaction.AddToBackStack(cachedFragmentInfo.Tag);
				}
				OnFragmentChanging(cachedFragmentInfo, fragmentTransaction);
				fragmentTransaction.Commit();
				SupportFragmentManager.ExecutePendingTransactions();
				OnFragmentChanged(cachedFragmentInfo);
			}
		}

		protected virtual FragmentReplaceMode ShouldReplaceCurrentFragment(IMvxCachedFragmentInfo newFragment, IMvxCachedFragmentInfo currentFragment, Bundle replacementBundle)
		{
			Bundle bundle = (newFragment.CachedFragment as AndroidX.Fragment.App.Fragment)?.Arguments;
			if (bundle == null)
			{
				return FragmentReplaceMode.ReplaceFragment;
			}
			IMvxNavigationSerializer mvxNavigationSerializer = Mvx.Resolve<IMvxNavigationSerializer>();
			string inputText = bundle.GetString("__mvxViewModelRequest");
			MvxViewModelRequest mvxViewModelRequest = mvxNavigationSerializer.Serializer.DeserializeObject<MvxViewModelRequest>(inputText);
			if (mvxViewModelRequest == null)
			{
				return FragmentReplaceMode.ReplaceFragment;
			}
			inputText = replacementBundle.GetString("__mvxViewModelRequest");
			MvxViewModelRequest mvxViewModelRequest2 = mvxNavigationSerializer.Serializer.DeserializeObject<MvxViewModelRequest>(inputText);
			if (mvxViewModelRequest2 == null)
			{
				return FragmentReplaceMode.ReplaceFragment;
			}
			bool flag = mvxViewModelRequest.ParameterValues == mvxViewModelRequest2.ParameterValues || (mvxViewModelRequest.ParameterValues.Count == mvxViewModelRequest2.ParameterValues.Count && !mvxViewModelRequest.ParameterValues.Except(mvxViewModelRequest2.ParameterValues).Any());
			if (currentFragment?.Tag != newFragment.Tag)
			{
				if (flag)
				{
					return FragmentReplaceMode.ReplaceFragment;
				}
				return FragmentReplaceMode.ReplaceFragmentAndViewModel;
			}
			if (flag)
			{
				return FragmentReplaceMode.NoReplace;
			}
			return FragmentReplaceMode.ReplaceFragmentAndViewModel;
		}

		public override void OnBackPressed()
		{
			if (SupportFragmentManager.BackStackEntryCount >= 1)
			{
				SupportFragmentManager.PopBackStackImmediate();
				if (FragmentCacheConfiguration.EnableOnFragmentPoppedCallback)
				{
					List<IMvxCachedFragmentInfo> currentCacheableFragmentsInfo = GetCurrentCacheableFragmentsInfo();
					OnFragmentPopped(currentCacheableFragmentsInfo);
				}
			}
			else
			{
				((Activity)(object)this).OnBackPressed();
			}
		}

		protected virtual List<IMvxCachedFragmentInfo> GetCurrentCacheableFragmentsInfo()
		{
			return (from frag in GetCurrentCacheableFragments()
				select GetFragmentInfoByTag(GetTagFromFragment(frag))).ToList();
		}

		protected virtual IEnumerable<AndroidX.Fragment.App.Fragment> GetCurrentCacheableFragments()
		{
			IEnumerable<AndroidX.Fragment.App.Fragment> fragments = SupportFragmentManager.Fragments;
			return from fragment in fragments ?? Enumerable.Empty<AndroidX.Fragment.App.Fragment>()
				where fragment != null
				where fragment.GetType().IsFragmentCacheable(((object)this).GetType())
				select fragment;
		}

		protected virtual IMvxCachedFragmentInfo GetLastFragmentInfo()
		{
			List<AndroidX.Fragment.App.Fragment> source = GetCurrentCacheableFragments().ToList();
			if (!source.Any())
			{
				throw new InvalidOperationException("Cannot retrieve last fragment as FragmentManager is empty.");
			}
			AndroidX.Fragment.App.Fragment fragment = source.Last();
			string tagFromFragment = GetTagFromFragment(fragment);
			return GetFragmentInfoByTag(tagFromFragment);
		}

		protected virtual string GetTagFromFragment(AndroidX.Fragment.App.Fragment fragment)
		{
			return (fragment as IMvxFragmentView).UniqueImmutableCacheTag;
		}

		protected override void OnCreate(Bundle bundle)
		{
			MvxAndroidSetupSingleton.EnsureSingletonAvailable((Context)(object)this).EnsureInitialized();
			base.OnCreate(bundle);
			if (bundle == null)
			{
				HandleIntent(((Activity)(object)this).Intent);
				return;
			}
			if (!Mvx.TryResolve<IMvxJsonConverter>(out var service))
			{
				Mvx.Trace("Could not resolve IMvxJsonConverter, it is going to be hard to create ViewModel cache");
				return;
			}
			FragmentCacheConfiguration.RestoreCacheConfiguration(bundle, service);
			RestoreFragmentsCache();
			RestoreViewModelsFromBundle(service, bundle);
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);
			HandleIntent(intent);
		}

		protected virtual void HandleIntent(Intent intent)
		{
			string text = intent.Extras?.GetString("__mvxViewModelRequest");
			if (text != null)
			{
				MvxViewModelRequest request = Mvx.Resolve<IMvxNavigationSerializer>().Serializer.DeserializeObject<MvxViewModelRequest>(text);
				Mvx.Resolve<IMvxAndroidViewPresenter>().Show(request);
			}
		}

		protected virtual void CloseFragment(string tag, int contentId)
		{
			if (SupportFragmentManager.FindFragmentById(contentId) != null)
			{
				SupportFragmentManager.PopBackStackImmediate(tag, 1);
			}
		}

		protected virtual string FragmentJavaName(Type fragmentType)
		{
			return Class.FromType(fragmentType).Name;
		}

		public virtual void OnBeforeFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, AndroidX.Fragment.App.FragmentTransaction transaction)
		{
		}

		public virtual void OnFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, AndroidX.Fragment.App.FragmentTransaction transaction)
		{
		}

		public virtual void OnFragmentChanged(IMvxCachedFragmentInfo fragmentInfo)
		{
		}

		public virtual void OnFragmentPopped(IList<IMvxCachedFragmentInfo> currentFragmentsInfo)
		{
		}

		public virtual void OnFragmentCreated(IMvxCachedFragmentInfo fragmentInfo, AndroidX.Fragment.App.FragmentTransaction transaction)
		{
		}

		protected virtual IMvxCachedFragmentInfo GetFragmentInfoByTag(string tag)
		{
			FragmentCacheConfiguration.TryGetValue(tag, out var cachedFragmentInfo);
			if (cachedFragmentInfo == null)
			{
				throw new MvxException("Could not find tag: {0} in cache, you need to register it first.", tag);
			}
			return cachedFragmentInfo;
		}

		public virtual IFragmentCacheConfiguration BuildFragmentCacheConfiguration()
		{
			return new DefaultFragmentCacheConfiguration();
		}

		protected virtual string GetFragmentTag(MvxViewModelRequest request, Bundle bundle, Type fragmentType)
		{
			return request.ViewModelType.FullName;
		}

		public virtual bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute)
		{
			string fragmentTag = GetFragmentTag(request, bundle, fragmentType);
			FragmentCacheConfiguration.RegisterFragmentToCache(fragmentTag, fragmentType, request.ViewModelType, fragmentAttribute.AddToBackStack);
			ShowFragment(fragmentTag, fragmentAttribute.FragmentContentId, bundle);
			return true;
		}

		public virtual bool Close(IMvxViewModel viewModel)
		{
			if (SupportFragmentManager.BackStackEntryCount == 0)
			{
				((Activity)(object)this).OnBackPressed();
				return true;
			}
			IMvxCachedFragmentInfo mvxCachedFragmentInfo = GetCurrentCacheableFragmentsInfo().FirstOrDefault((IMvxCachedFragmentInfo x) => x.ViewModelType == viewModel.GetType());
			if (mvxCachedFragmentInfo == null)
			{
				return false;
			}
			CloseFragment(mvxCachedFragmentInfo.Tag, mvxCachedFragmentInfo.ContentId);
			return true;
		}
	}
	public abstract class MvxCachingFragmentCompatActivity<TViewModel> : MvxCachingFragmentCompatActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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

		protected MvxCachingFragmentCompatActivity(IntPtr ptr, JniHandleOwnership ownership)
			: base(ptr, ownership)
		{
		}

		protected MvxCachingFragmentCompatActivity()
		{
		}
	}
	public abstract class MvxAppCompatSetup : MvxAndroidSetup
	{
		protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
		{
			typeof(AndroidX.AppCompat.Widget.Toolbar).Assembly,
			typeof(DrawerLayout).Assembly,
			typeof(NestedScrollView).Assembly,
			typeof(SlidingPaneLayout).Assembly,
			typeof(ViewPager).Assembly,
			typeof(MvxSwipeRefreshLayout).Assembly
		};

		protected MvxAppCompatSetup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected abstract override IMvxApplication CreateApp();

		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			MvxFragmentsPresenter mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
			Mvx.RegisterSingleton((IMvxAndroidViewPresenter)mvxFragmentsPresenter);
			return mvxFragmentsPresenter;
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			MvxAppCompatSetupHelper.FillTargetFactories(registry);
			base.FillTargetFactories(registry);
		}

		protected override void FillBindingNames(IMvxBindingNameRegistry registry)
		{
			MvxAppCompatSetupHelper.FillDefaultBindingNames(registry);
			base.FillBindingNames(registry);
		}
	}
}
namespace MvvmCross.Droid.Support.V7.AppCompat.Widget
{
	[Register("mvvmcross.droid.support.v7.appcompat.widget.MvxAppCompatAutoCompleteTextView")]
	public class MvxAppCompatAutoCompleteTextView : AppCompatAutoCompleteTextView
	{
		private object _selectedObject;

		public new MvxFilteringAdapter Adapter
		{
			get
			{
				return base.Adapter as MvxFilteringAdapter;
			}
			set
			{
				MvxFilteringAdapter adapter = Adapter;
				if (adapter != value)
				{
					if (adapter != null)
					{
						adapter.PartialTextChanged -= AdapterOnPartialTextChanged;
					}
					if (adapter != null && value != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateId = adapter.ItemTemplateId;
					}
					if (value != null)
					{
						value.PartialTextChanged += AdapterOnPartialTextChanged;
					}
					base.Adapter = value;
				}
			}
		}

		[MvxSetToNullAfterBinding]
		public IEnumerable ItemsSource
		{
			get
			{
				return Adapter.ItemsSource;
			}
			set
			{
				Adapter.ItemsSource = value;
			}
		}

		public int ItemTemplateId
		{
			get
			{
				return Adapter.ItemTemplateId;
			}
			set
			{
				Adapter.ItemTemplateId = value;
			}
		}

		public string PartialText => Adapter.PartialText;

		public object SelectedObject
		{
			get
			{
				return _selectedObject;
			}
			private set
			{
				if (_selectedObject != value)
				{
					_selectedObject = value;
					FireChanged(this.SelectedObjectChanged);
				}
			}
		}

		public event EventHandler SelectedObjectChanged;

		public event EventHandler PartialTextChanged;

		public MvxAppCompatAutoCompleteTextView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxFilteringAdapter(context))
		{
			base.ItemClick += OnItemClick;
			base.ItemSelected += OnItemSelected;
		}

		public MvxAppCompatAutoCompleteTextView(Context context, IAttributeSet attrs, MvxFilteringAdapter adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			adapter.ItemTemplateId = itemTemplateId;
			Adapter = adapter;
			base.ItemClick += OnItemClick;
		}

		protected MvxAppCompatAutoCompleteTextView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private void OnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
		{
			OnItemClick(itemClickEventArgs.Position);
		}

		private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs itemSelectedEventArgs)
		{
			OnItemSelected(itemSelectedEventArgs.Position);
		}

		protected virtual void OnItemClick(int position)
		{
			object rawItem = Adapter.GetRawItem(position);
			SelectedObject = rawItem;
		}

		protected virtual void OnItemSelected(int position)
		{
			object rawItem = Adapter.GetRawItem(position);
			SelectedObject = rawItem;
		}

		private void AdapterOnPartialTextChanged(object sender, EventArgs eventArgs)
		{
			FireChanged(this.PartialTextChanged);
		}

		private void FireChanged(EventHandler eventHandler)
		{
			eventHandler?.Invoke(this, EventArgs.Empty);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.ItemClick -= OnItemClick;
				base.ItemSelected -= OnItemSelected;
				if (Adapter != null)
				{
					Adapter.PartialTextChanged -= AdapterOnPartialTextChanged;
				}
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.widget.MvxAppCompatImageView")]
	public class MvxAppCompatImageView : AppCompatImageView
	{
		private IMvxImageHelper<Bitmap> _imageHelper;

		public string ImageUrl
		{
			get
			{
				return ImageHelper?.ImageUrl;
			}
			set
			{
				if (ImageHelper != null)
				{
					ImageHelper.ImageUrl = value;
				}
			}
		}

		public string DefaultImagePath
		{
			get
			{
				return ImageHelper.DefaultImagePath;
			}
			set
			{
				ImageHelper.DefaultImagePath = value;
			}
		}

		public string ErrorImagePath
		{
			get
			{
				return ImageHelper.ErrorImagePath;
			}
			set
			{
				ImageHelper.ErrorImagePath = value;
			}
		}

		protected IMvxImageHelper<Bitmap> ImageHelper
		{
			get
			{
				if (_imageHelper == null)
				{
					if (!Mvx.TryResolve<IMvxImageHelper<Bitmap>>(out _imageHelper))
					{
						MvxTrace.Error("No IMvxImageHelper registered - you must provide an image helper before you can use a MvxImageView");
					}
					else
					{
						_imageHelper.ImageChanged += ImageHelperOnImageChanged;
					}
				}
				return _imageHelper;
			}
		}

		public MvxAppCompatImageView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.ImageViewStylableGroupId);
			int indexCount = typedArray.IndexCount;
			for (int i = 0; i < indexCount; i++)
			{
				int index = typedArray.GetIndex(i);
				if (index == MvxSingleton<IMvxAndroidBindingResource>.Instance.SourceBindId)
				{
					ImageUrl = typedArray.GetString(index);
				}
			}
			typedArray.Recycle();
		}

		public MvxAppCompatImageView(Context context)
			: base(context)
		{
		}

		protected MvxAppCompatImageView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override void SetMaxHeight(int maxHeight)
		{
			if (ImageHelper != null)
			{
				ImageHelper.MaxHeight = maxHeight;
			}
			base.SetMaxHeight(maxHeight);
		}

		public override void SetMaxWidth(int maxWidth)
		{
			if (ImageHelper != null)
			{
				ImageHelper.MaxWidth = maxWidth;
			}
			base.SetMaxWidth(maxWidth);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _imageHelper != null)
			{
				_imageHelper.ImageChanged -= ImageHelperOnImageChanged;
				_imageHelper.Dispose();
			}
			base.Dispose(disposing);
		}

		private void ImageHelperOnImageChanged(object sender, MvxValueEventArgs<Bitmap> mvxValueEventArgs)
		{
			using Handler handler = new Handler(Looper.MainLooper);
			handler.Post(delegate
			{
				SetImageBitmap(mvxValueEventArgs.Value);
			});
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.widget.MvxAppCompatRadioGroup")]
	public class MvxAppCompatRadioGroup : RadioGroup, IMvxWithChangeAdapter
	{
		private IMvxAdapterWithChangedEvent _adapter;

		private static long _nextGeneratedViewId = 1L;

		public IMvxAdapterWithChangedEvent Adapter
		{
			get
			{
				return _adapter;
			}
			protected set
			{
				IMvxAdapterWithChangedEvent adapter = _adapter;
				if (adapter == value)
				{
					return;
				}
				if (adapter != null)
				{
					adapter.DataSetChanged -= AdapterOnDataSetChanged;
					if (value != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateId = adapter.ItemTemplateId;
					}
				}
				_adapter = value;
				if (_adapter != null)
				{
					_adapter.DataSetChanged += AdapterOnDataSetChanged;
				}
				if (_adapter == null)
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
			}
		}

		[MvxSetToNullAfterBinding]
		public IEnumerable ItemsSource
		{
			get
			{
				return Adapter.ItemsSource;
			}
			set
			{
				Adapter.ItemsSource = value;
			}
		}

		public int ItemTemplateId
		{
			get
			{
				return Adapter.ItemTemplateId;
			}
			set
			{
				Adapter.ItemTemplateId = value;
			}
		}

		public MvxAppCompatRadioGroup(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxAppCompatRadioGroup(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			if (adapter != null)
			{
				Adapter = adapter;
				Adapter.ItemTemplateId = itemTemplateId;
			}
			base.ChildViewAdded += OnChildViewAdded;
			base.ChildViewRemoved += OnChildViewRemoved;
		}

		protected MvxAppCompatRadioGroup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewAdded(object sender, ChildViewAddedEventArgs args)
		{
			if ((args.Child as MvxListItemView)?.GetChildAt(0) is AppCompatRadioButton appCompatRadioButton)
			{
				if (appCompatRadioButton.Id == -1)
				{
					appCompatRadioButton.Id = GenerateViewId();
				}
				appCompatRadioButton.CheckedChange += OnRadioButtonCheckedChange;
			}
		}

		private void OnRadioButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
		{
			if (sender is AppCompatRadioButton appCompatRadioButton)
			{
				Check(appCompatRadioButton.Id);
			}
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			if (_adapter != null)
			{
				_adapter.DataSetChanged -= AdapterOnDataSetChanged;
			}
			base.ChildViewAdded -= OnChildViewAdded;
			base.ChildViewRemoved -= OnChildViewRemoved;
			int childCount = ChildCount;
			for (int i = 0; i < childCount; i++)
			{
				if (GetChildAt(i) is AppCompatRadioButton appCompatRadioButton)
				{
					appCompatRadioButton.CheckedChange -= OnRadioButtonCheckedChange;
				}
			}
		}

		private new static int GenerateViewId()
		{
			int num;
			int num2;
			do
			{
				num = (int)Interlocked.Read(ref _nextGeneratedViewId);
				num2 = num + 1;
				if (num2 > 16777215)
				{
					num2 = 1;
				}
			}
			while (Interlocked.CompareExchange(ref _nextGeneratedViewId, num2, num) != num);
			return num;
		}
	}
	[Register("mvvmcross.droid.support.v7.appcompat.widget.MvxAppCompatSpinner")]
	public class MvxAppCompatSpinner : AppCompatSpinner
	{
		public new IMvxAdapter Adapter
		{
			get
			{
				return base.Adapter as IMvxAdapter;
			}
			set
			{
				IMvxAdapter adapter = Adapter;
				if (adapter != value)
				{
					if (adapter != null && value != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateId = adapter.ItemTemplateId;
						value.DropDownItemTemplateId = adapter.DropDownItemTemplateId;
					}
					base.Adapter = value;
				}
			}
		}

		[MvxSetToNullAfterBinding]
		public IEnumerable ItemsSource
		{
			get
			{
				return Adapter.ItemsSource;
			}
			set
			{
				Adapter.ItemsSource = value;
			}
		}

		public int ItemTemplateId
		{
			get
			{
				return Adapter.ItemTemplateId;
			}
			set
			{
				Adapter.ItemTemplateId = value;
			}
		}

		public int DropDownItemTemplateId
		{
			get
			{
				return Adapter.DropDownItemTemplateId;
			}
			set
			{
				Adapter.DropDownItemTemplateId = value;
			}
		}

		public ICommand HandleItemSelected { get; set; }

		public MvxAppCompatSpinner(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapter(context)
			{
				SimpleViewLayoutId = 17367050
			})
		{
		}

		public MvxAppCompatSpinner(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			int dropDownItemTemplateId = MvxAttributeHelpers.ReadDropDownListItemTemplateId(context, attrs);
			adapter.ItemTemplateId = itemTemplateId;
			adapter.DropDownItemTemplateId = dropDownItemTemplateId;
			Adapter = adapter;
			base.ItemSelected += OnItemSelected;
		}

		protected MvxAppCompatSpinner(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private void OnItemSelected(object sender, ItemSelectedEventArgs e)
		{
			int position = e.Position;
			HandleSelected(position);
		}

		protected virtual void HandleSelected(int position)
		{
			object rawItem = Adapter.GetRawItem(position);
			if (HandleItemSelected != null && rawItem != null && HandleItemSelected.CanExecute(rawItem))
			{
				HandleItemSelected.Execute(rawItem);
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				base.ItemSelected -= OnItemSelected;
			}
		}
	}
}
namespace MvvmCross.Droid.Support.V7.AppCompat.Target
{
	public class MvxAppCompatAutoCompleteTextViewPartialTextTargetBinding : MvxAndroidPropertyInfoTargetBinding<MvxAppCompatAutoCompleteTextView>
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		public MvxAppCompatAutoCompleteTextViewPartialTextTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			if (base.View == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in MvxAppCompatAutoCompleteTextViewPartialTextTargetBinding");
			}
		}

		private void AutoCompleteOnPartialTextChanged(object sender, EventArgs eventArgs)
		{
			FireValueChanged(base.View.PartialText);
		}

		public override void SubscribeToEvents()
		{
			MvxAppCompatAutoCompleteTextView view = base.View;
			if (view != null)
			{
				_subscription = view.WeakSubscribe("PartialTextChanged", AutoCompleteOnPartialTextChanged);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxAppCompatAutoCompleteTextViewSelectedObjectTargetBinding : MvxAndroidPropertyInfoTargetBinding<MvxAppCompatAutoCompleteTextView>
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		public MvxAppCompatAutoCompleteTextViewSelectedObjectTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			if (base.View == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in MvxAppCompatAutoCompleteTextViewSelectedObjectTargetBinding");
			}
		}

		private void AutoCompleteOnSelectedObjectChanged(object sender, EventArgs eventArgs)
		{
			FireValueChanged(base.View.SelectedObject);
		}

		public override void SubscribeToEvents()
		{
			MvxAppCompatAutoCompleteTextView view = base.View;
			if (view != null)
			{
				_subscription = view.WeakSubscribe("SelectedObjectChanged", AutoCompleteOnSelectedObjectChanged);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
			}
			base.Dispose(isDisposing);
		}
	}
	public abstract class MvxAppCompatBaseImageViewTargetBinding : MvxAndroidTargetBinding
	{
		protected AppCompatImageView ImageView => (AppCompatImageView)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		protected MvxAppCompatBaseImageViewTargetBinding(AppCompatImageView imageView)
			: base(imageView)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			AppCompatImageView imageView = (AppCompatImageView)target;
			try
			{
				if (GetBitmap(value, out var bitmap))
				{
					SetImageBitmap(imageView, bitmap);
				}
			}
			catch (System.Exception exception)
			{
				MvxTrace.Error(exception.ToLongString());
				throw;
			}
		}

		protected virtual void SetImageBitmap(AppCompatImageView imageView, Bitmap bitmap)
		{
			imageView.SetImageBitmap(bitmap);
		}

		protected abstract bool GetBitmap(object value, out Bitmap bitmap);
	}
	public class MvxAppCompatRadioGroupSelectedItemBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		private object _currentValue;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(object);

		public MvxAppCompatRadioGroupSelectedItemBinding(MvxAppCompatRadioGroup radioGroup)
			: base(radioGroup)
		{
			_subscription = radioGroup.WeakSubscribe<MvxAppCompatRadioGroup, RadioGroup.CheckedChangeEventArgs>("CheckedChange", RadioGroupCheckedChanged);
		}

		private bool CheckValueChanged(object newValue)
		{
			if (newValue == null)
			{
				return _currentValue != null;
			}
			return !newValue.Equals(_currentValue);
		}

		private void RadioGroupCheckedChanged(object sender, RadioGroup.CheckedChangeEventArgs args)
		{
			MvxAppCompatRadioGroup mvxAppCompatRadioGroup = (MvxAppCompatRadioGroup)base.Target;
			if (mvxAppCompatRadioGroup != null)
			{
				object obj = null;
				if (mvxAppCompatRadioGroup.FindViewById<AppCompatRadioButton>(args.CheckedId)?.Parent is MvxListItemView mvxListItemView)
				{
					obj = mvxListItemView.DataContext;
				}
				if (CheckValueChanged(obj))
				{
					_currentValue = obj;
					FireValueChanged(obj);
				}
			}
		}

		protected override void SetValueImpl(object target, object newValue)
		{
			MvxAppCompatRadioGroup mvxAppCompatRadioGroup = (MvxAppCompatRadioGroup)target;
			if (mvxAppCompatRadioGroup == null || !CheckValueChanged(newValue))
			{
				return;
			}
			int num = -1;
			if (newValue != null)
			{
				for (int i = 0; i < mvxAppCompatRadioGroup.ChildCount; i++)
				{
					if (mvxAppCompatRadioGroup.GetChildAt(i) is MvxListItemView mvxListItemView && newValue.Equals(mvxListItemView.DataContext) && mvxListItemView.GetChildAt(0) is AppCompatRadioButton appCompatRadioButton)
					{
						num = appCompatRadioButton.Id;
						break;
					}
				}
			}
			if (num == -1)
			{
				mvxAppCompatRadioGroup.ClearCheck();
			}
			else
			{
				mvxAppCompatRadioGroup.Check(num);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxAppCompatSearchViewQueryTextTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		protected AndroidX.AppCompat.Widget.SearchView SearchView => (AndroidX.AppCompat.Widget.SearchView)base.Target;

		public MvxAppCompatSearchViewQueryTextTargetBinding(object target)
			: base(target)
		{
		}

		public override void SubscribeToEvents()
		{
			_subscription = SearchView.WeakSubscribe<AndroidX.AppCompat.Widget.SearchView, AndroidX.AppCompat.Widget.SearchView.QueryTextChangeEventArgs>("QueryTextChange", HandleQueryTextChanged);
		}

		protected override void SetValueImpl(object target, object value)
		{
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}

		private void HandleQueryTextChanged(object sender, AndroidX.AppCompat.Widget.SearchView.QueryTextChangeEventArgs e)
		{
			if (base.Target is AndroidX.AppCompat.Widget.SearchView { Query: var query })
			{
				FireValueChanged(query);
			}
		}
	}
	public class MvxAppCompatSpinnerSelectedItemBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		private object _currentValue;

		protected MvxAppCompatSpinner Spinner => (MvxAppCompatSpinner)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(object);

		public MvxAppCompatSpinnerSelectedItemBinding(MvxAppCompatSpinner spinner)
			: base(spinner)
		{
		}

		private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			MvxAppCompatSpinner spinner = Spinner;
			if (spinner != null)
			{
				object rawItem = spinner.Adapter.GetRawItem(e.Position);
				if ((rawItem != null) ? (!rawItem.Equals(_currentValue)) : (_currentValue != null))
				{
					_currentValue = rawItem;
					FireValueChanged(rawItem);
				}
			}
		}

		protected override void SetValueImpl(object target, object value)
		{
			MvxAppCompatSpinner mvxAppCompatSpinner = (MvxAppCompatSpinner)target;
			if (value == null)
			{
				MvxBindingTrace.Warning("Null values not permitted in spinner SelectedItem binding currently");
			}
			else if (!value.Equals(_currentValue))
			{
				int position = mvxAppCompatSpinner.Adapter.GetPosition(value);
				if (position < 0)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
				}
				else
				{
					_currentValue = value;
					mvxAppCompatSpinner.SetSelection(position);
				}
			}
		}

		public override void SubscribeToEvents()
		{
			MvxAppCompatSpinner spinner = Spinner;
			if (spinner != null)
			{
				_subscription = spinner.WeakSubscribe<MvxAppCompatSpinner, AdapterView.ItemSelectedEventArgs>("ItemSelected", SpinnerItemSelected);
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxToolbarSubtitleBinding : MvxConvertingTargetBinding
	{
		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		protected AndroidX.AppCompat.Widget.Toolbar Toolbar => (AndroidX.AppCompat.Widget.Toolbar)base.Target;

		public MvxToolbarSubtitleBinding(AndroidX.AppCompat.Widget.Toolbar toolbar)
			: base(toolbar)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			((AndroidX.AppCompat.Widget.Toolbar)target).Subtitle = (string)value;
		}
	}
}
namespace MvvmCross.Droid.Support.V7.AppCompat.EventSource
{
	public class MvxEventSourceAppCompatDialogFragment : AppCompatDialogFragment, IMvxEventSourceFragment, IMvxDisposeSource
	{
		public event EventHandler<MvxValueEventArgs<Activity>> AttachCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		public event EventHandler<MvxValueEventArgs<MvxCreateViewParameters>> CreateViewCalled;

		public event EventHandler StartCalled;

		public event EventHandler ResumeCalled;

		public event EventHandler PauseCalled;

		public event EventHandler StopCalled;

		public event EventHandler DestroyViewCalled;

		public event EventHandler DestroyCalled;

		public event EventHandler DetachCalled;

		public event EventHandler DisposeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;

		protected MvxEventSourceAppCompatDialogFragment()
		{
		}

		protected MvxEventSourceAppCompatDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override void OnAttach(Activity activity)
		{
			this.AttachCalled.Raise(this, activity);
			base.OnAttach(activity);
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			this.CreateWillBeCalled.Raise(this, savedInstanceState);
			base.OnCreate(savedInstanceState);
			this.CreateCalled.Raise(this, savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.CreateViewCalled.Raise(this, new MvxCreateViewParameters(inflater, container, savedInstanceState));
			return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnStart()
		{
			this.StartCalled.Raise(this);
			base.OnStart();
		}

		public override void OnResume()
		{
			this.ResumeCalled.Raise(this);
			base.OnResume();
		}

		public override void OnPause()
		{
			this.PauseCalled.Raise(this);
			base.OnPause();
		}

		public override void OnStop()
		{
			this.StopCalled.Raise(this);
			base.OnStop();
		}

		public override void OnDestroyView()
		{
			this.DestroyViewCalled.Raise(this);
			base.OnDestroyView();
		}

		public override void OnDestroy()
		{
			this.DestroyCalled.Raise(this);
			base.OnDestroy();
		}

		public override void OnDetach()
		{
			this.DetachCalled.Raise(this);
			base.OnDetach();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeCalled.Raise(this);
			}
			base.Dispose(disposing);
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			this.SaveInstanceStateCalled.Raise(this, outState);
			base.OnSaveInstanceState(outState);
		}
	}
	public abstract class MvxEventSourceAppCompatActivity : AppCompatActivity, IMvxEventSourceActivity, IMvxDisposeSource
	{
		public event EventHandler DisposeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		public event EventHandler DestroyCalled;

		public event EventHandler<MvxValueEventArgs<Intent>> NewIntentCalled;

		public event EventHandler ResumeCalled;

		public event EventHandler PauseCalled;

		public event EventHandler StartCalled;

		public event EventHandler RestartCalled;

		public event EventHandler StopCalled;

		public event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;

		public event EventHandler<MvxValueEventArgs<MvxStartActivityForResultParameters>> StartActivityForResultCalled;

		public event EventHandler<MvxValueEventArgs<MvxActivityResultParameters>> ActivityResultCalled;

		protected MvxEventSourceAppCompatActivity()
		{
		}

		protected MvxEventSourceAppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			this.CreateWillBeCalled.Raise(this, bundle);
			((Activity)(object)this).OnCreate(bundle);
			this.CreateCalled.Raise(this, bundle);
		}

		protected override void OnDestroy()
		{
			this.DestroyCalled.Raise(this);
			((Activity)(object)this).OnDestroy();
		}

		protected override void OnNewIntent(Intent intent)
		{
			((Activity)(object)this).OnNewIntent(intent);
			this.NewIntentCalled.Raise(this, intent);
		}

		protected override void OnResume()
		{
			((Activity)(object)this).OnResume();
			this.ResumeCalled.Raise(this);
		}

		protected override void OnPause()
		{
			this.PauseCalled.Raise(this);
			((Activity)(object)this).OnPause();
		}

		protected override void OnStart()
		{
			((Activity)(object)this).OnStart();
			this.StartCalled.Raise(this);
		}

		protected override void OnRestart()
		{
			((Activity)(object)this).OnRestart();
			this.RestartCalled.Raise(this);
		}

		protected override void OnStop()
		{
			this.StopCalled.Raise(this);
			((Activity)(object)this).OnStop();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			this.SaveInstanceStateCalled.Raise(this, outState);
			((Activity)(object)this).OnSaveInstanceState(outState);
		}

		public override void StartActivityForResult(Intent intent, int requestCode)
		{
			this.StartActivityForResultCalled.Raise(this, new MvxStartActivityForResultParameters(intent, requestCode));
			((Activity)(object)this).StartActivityForResult(intent, requestCode);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			this.ActivityResultCalled.Raise(this, new MvxActivityResultParameters(requestCode, resultCode, data));
			((Activity)(object)this).OnActivityResult(requestCode, resultCode, data);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeCalled.Raise(this);
			}
			((Java.Lang.Object)(object)this).Dispose(disposing);
		}
	}
}
