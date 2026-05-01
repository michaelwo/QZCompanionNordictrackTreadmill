using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.ViewPager.Widget;
using Java.Interop;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Shared.Fragments;
using MvvmCross.Droid.Shared.Fragments.EventSource;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Support.V4.EventSource;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Droid.Views;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("MvvmCross.Droid.Support.Fragment.Resource", IsApplication = false)]
[assembly: AssemblyTitle("MvvmCross.Droid.Support.Fragment")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("martijnvandijk")]
[assembly: AssemblyTrademark("")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace MvvmCross.Droid.Support.V4
{
	[Register("mvvmcross.droid.support.v4.MvxCachingFragmentActivity")]
	public class MvxCachingFragmentActivity : MvxFragmentActivity, IFragmentCacheableActivity, IMvxFragmentHost
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

		protected MvxCachingFragmentActivity()
		{
		}

		protected MvxCachingFragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			MvxAndroidSetupSingleton mvxAndroidSetupSingleton = MvxAndroidSetupSingleton.EnsureSingletonAvailable((Context)(object)this);
			mvxAndroidSetupSingleton.EnsureInitialized();
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
				IMvxNavigationSerializer mvxNavigationSerializer = Mvx.Resolve<IMvxNavigationSerializer>();
				MvxViewModelRequest request = mvxNavigationSerializer.Serializer.DeserializeObject<MvxViewModelRequest>(text);
				IMvxAndroidViewPresenter mvxAndroidViewPresenter = Mvx.Resolve<IMvxAndroidViewPresenter>();
				mvxAndroidViewPresenter.Show(request);
			}
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
			Dictionary<string, Type> dictionary = serializer.DeserializeObject<Dictionary<string, Type>>(text);
			foreach (KeyValuePair<string, Type> item in dictionary)
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
				IMvxCachedFragmentInfo fragmentInfoByTag = GetFragmentInfoByTag(tagFromFragment);
				fragmentInfoByTag.CachedFragment = currentCacheableFragment as IMvxFragmentView;
			}
		}

		private Dictionary<string, Type> CreateFragmentTypesDictionary(Bundle outState)
		{
			if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service))
			{
				return null;
			}
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			List<IMvxCachedFragmentInfo> currentCacheableFragmentsInfo = GetCurrentCacheableFragmentsInfo();
			foreach (IMvxCachedFragmentInfo item in currentCacheableFragmentsInfo)
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
					((AndroidX.Fragment.App.Fragment)cachedFragmentInfo.CachedFragment).Arguments.Clear();
					((AndroidX.Fragment.App.Fragment)cachedFragmentInfo.CachedFragment).Arguments.PutAll(bundle);
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
					IMvxMultipleViewModelCache singleton = Mvx.GetSingleton<IMvxMultipleViewModelCache>();
					singleton.GetAndClear(cachedFragmentInfo.ViewModelType, GetTagFromFragment(cachedFragmentInfo.CachedFragment as AndroidX.Fragment.App.Fragment));
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
			Bundle bundle = ((AndroidX.Fragment.App.Fragment)newFragment.CachedFragment)?.Arguments;
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
			IEnumerable<AndroidX.Fragment.App.Fragment> source = fragments ?? Enumerable.Empty<AndroidX.Fragment.App.Fragment>();
			return from fragment in source
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
			IMvxFragmentView mvxFragmentView = fragment as IMvxFragmentView;
			return mvxFragmentView.UniqueImmutableCacheTag;
		}

		protected virtual void CloseFragment(string tag, int contentId)
		{
			AndroidX.Fragment.App.Fragment fragment = SupportFragmentManager.FindFragmentById(contentId);
			if (fragment != null)
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

		protected IMvxCachedFragmentInfo GetFragmentInfoByTag(string tag)
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

		public bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute)
		{
			string fragmentTag = GetFragmentTag(request, bundle, fragmentType);
			FragmentCacheConfiguration.RegisterFragmentToCache(fragmentTag, fragmentType, request.ViewModelType, fragmentAttribute.AddToBackStack);
			ShowFragment(fragmentTag, fragmentAttribute.FragmentContentId, bundle);
			return true;
		}

		public virtual bool Close(IMvxViewModel viewModel)
		{
			IMvxCachedFragmentInfo mvxCachedFragmentInfo = GetCurrentCacheableFragmentsInfo().FirstOrDefault((IMvxCachedFragmentInfo x) => x.ViewModelType == viewModel.GetType());
			if (mvxCachedFragmentInfo == null)
			{
				return false;
			}
			CloseFragment(mvxCachedFragmentInfo.Tag, mvxCachedFragmentInfo.ContentId);
			return true;
		}
	}
	public abstract class MvxCachingFragmentActivity<TViewModel> : MvxCachingFragmentActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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
	[Register("mvvmcross.droid.support.v4.MvxCachingFragmentPagerAdapter")]
	public abstract class MvxCachingFragmentPagerAdapter : PagerAdapter
	{
		private AndroidX.Fragment.App.Fragment _currentPrimaryItem;

		private AndroidX.Fragment.App.FragmentTransaction _curTransaction;

		private readonly AndroidX.Fragment.App.FragmentManager _fragmentManager;

		private readonly List<AndroidX.Fragment.App.Fragment> _fragments = new List<AndroidX.Fragment.App.Fragment>();

		private List<string> _savedFragmentTags = new List<string>();

		private readonly List<AndroidX.Fragment.App.Fragment.SavedState> _savedState = new List<AndroidX.Fragment.App.Fragment.SavedState>();

		protected MvxCachingFragmentPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected MvxCachingFragmentPagerAdapter(AndroidX.Fragment.App.FragmentManager fragmentManager)
		{
			_fragmentManager = fragmentManager;
		}

		public abstract AndroidX.Fragment.App.Fragment GetItem(int position, AndroidX.Fragment.App.Fragment.SavedState fragmentSavedState = null);

		public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
		{
			AndroidX.Fragment.App.Fragment fragment = (AndroidX.Fragment.App.Fragment)objectValue;
			if (_curTransaction == null)
			{
				_curTransaction = _fragmentManager.BeginTransaction();
			}
			while (_savedState.Count <= position)
			{
				_savedState.Add(null);
				_savedFragmentTags.Add(null);
			}
			_savedState[position] = _fragmentManager.SaveFragmentInstanceState(fragment);
			_savedFragmentTags[position] = fragment.Tag;
			_fragments[position] = null;
			_curTransaction.Remove(fragment);
		}

		public override void FinishUpdate(ViewGroup container)
		{
			if (_curTransaction != null)
			{
				_curTransaction.CommitAllowingStateLoss();
				_curTransaction = null;
				_fragmentManager.ExecutePendingTransactions();
			}
		}

		public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			if (_fragments.Count > position)
			{
				AndroidX.Fragment.App.Fragment fragment = _fragments.ElementAtOrDefault(position);
				if (fragment != null)
				{
					return fragment;
				}
			}
			if (_curTransaction == null)
			{
				_curTransaction = _fragmentManager.BeginTransaction();
			}
			string tag = GetTag(position);
			AndroidX.Fragment.App.Fragment.SavedState savedState = null;
			if (_savedState.Count > position)
			{
				string b = _savedFragmentTags.ElementAtOrDefault(position);
				if (string.Equals(tag, b))
				{
					savedState = _savedState.ElementAtOrDefault(position);
				}
			}
			AndroidX.Fragment.App.Fragment item = GetItem(position, savedState);
			if (savedState != null)
			{
				item.SetInitialSavedState(savedState);
			}
			while (_fragments.Count <= position)
			{
				_fragments.Add(null);
			}
			item.SetMenuVisibility(menuVisible: false);
			item.UserVisibleHint = false;
			_fragments[position] = item;
			_curTransaction.Add(container.Id, item, tag);
			return item;
		}

		public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
		{
			return ((AndroidX.Fragment.App.Fragment)objectValue).View == view;
		}

		public override void RestoreState(IParcelable state, ClassLoader loader)
		{
			if (state == null)
			{
				return;
			}
			Bundle bundle = (Bundle)state;
			bundle.SetClassLoader(loader);
			IParcelable[] parcelableArray = bundle.GetParcelableArray("states");
			_savedState.Clear();
			_fragments.Clear();
			IList<string> stringArrayList = bundle.GetStringArrayList("tags");
			if (stringArrayList != null)
			{
				_savedFragmentTags = stringArrayList.ToList();
			}
			else
			{
				_savedFragmentTags.Clear();
			}
			if (parcelableArray != null)
			{
				for (int i = 0; i < parcelableArray.Length; i++)
				{
					IParcelable instance = parcelableArray.ElementAt(i);
					AndroidX.Fragment.App.Fragment.SavedState item = Android.Runtime.Extensions.JavaCast<AndroidX.Fragment.App.Fragment.SavedState>(instance);
					_savedState.Add(item);
				}
			}
			ICollection<string> collection = bundle.KeySet();
			foreach (string item2 in collection)
			{
				if (!item2.StartsWith("f"))
				{
					continue;
				}
				int num = Integer.ParseInt(item2.Substring(1));
				if (_fragmentManager.Fragments == null)
				{
					break;
				}
				AndroidX.Fragment.App.Fragment fragment = _fragmentManager.GetFragment(bundle, item2);
				if (fragment != null)
				{
					while (_fragments.Count() <= num)
					{
						_fragments.Add(null);
					}
					fragment.SetMenuVisibility(menuVisible: false);
					_fragments[num] = fragment;
				}
			}
		}

		public override IParcelable SaveState()
		{
			Bundle bundle = null;
			if (_savedState.Any())
			{
				bundle = new Bundle();
				IParcelable[] array = new IParcelable[_savedState.Count];
				for (int i = 0; i < _savedState.Count; i++)
				{
					array[i] = _savedState.ElementAt(i);
				}
				bundle.PutParcelableArray("states", array);
				bundle.PutStringArrayList("tags", _savedFragmentTags);
			}
			for (int j = 0; j < _fragments.Count; j++)
			{
				AndroidX.Fragment.App.Fragment fragment = _fragments.ElementAtOrDefault(j);
				if (fragment != null)
				{
					if (bundle == null)
					{
						bundle = new Bundle();
					}
					string key = "f" + j;
					_fragmentManager.PutFragment(bundle, key, fragment);
				}
			}
			return bundle;
		}

		public override void SetPrimaryItem(ViewGroup container, int position, Java.Lang.Object objectValue)
		{
			AndroidX.Fragment.App.Fragment fragment = (AndroidX.Fragment.App.Fragment)objectValue;
			if (fragment != _currentPrimaryItem)
			{
				if (_currentPrimaryItem != null)
				{
					_currentPrimaryItem.SetMenuVisibility(menuVisible: false);
					_currentPrimaryItem.UserVisibleHint = false;
				}
				if (fragment != null)
				{
					fragment.SetMenuVisibility(menuVisible: true);
					fragment.UserVisibleHint = true;
				}
				_currentPrimaryItem = fragment;
			}
		}

		public override void StartUpdate(View container)
		{
		}

		protected virtual string GetTag(int position)
		{
			return null;
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxCachingFragmentStatePagerAdapter")]
	public class MvxCachingFragmentStatePagerAdapter : MvxCachingFragmentPagerAdapter
	{
		public class FragmentInfo
		{
			public Type FragmentType { get; }

			public object ParameterValuesObject { get; }

			public string Tag { get; }

			public string Title { get; }

			public Type ViewModelType { get; }

			public IMvxViewModel ViewModel { get; }

			public FragmentInfo(string title, Type fragmentType, Type viewModelType, object parameterValuesObject = null)
				: this(title, null, fragmentType, viewModelType, parameterValuesObject)
			{
			}

			public FragmentInfo(string title, string tag, Type fragmentType, Type viewModelType, object parameterValuesObject = null)
			{
				Title = title;
				Tag = tag ?? title;
				FragmentType = fragmentType;
				ViewModelType = viewModelType;
				ParameterValuesObject = parameterValuesObject;
			}

			public FragmentInfo(string title, Type fragmentType, IMvxViewModel viewModel, object parameterValuesObject = null)
				: this(title, null, fragmentType, viewModel.GetType(), parameterValuesObject)
			{
				ViewModel = viewModel;
			}

			public FragmentInfo(string title, string tag, Type fragmentType, IMvxViewModel viewModel, object parameterValuesObject = null)
				: this(title, tag, fragmentType, viewModel.GetType(), parameterValuesObject)
			{
				ViewModel = viewModel;
			}
		}

		private readonly Context _context;

		public override int Count => Fragments.Count();

		public IEnumerable<FragmentInfo> Fragments { get; }

		protected MvxCachingFragmentStatePagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public MvxCachingFragmentStatePagerAdapter(Context context, AndroidX.Fragment.App.FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
			: base(fragmentManager)
		{
			_context = context;
			Fragments = fragments;
		}

		protected static string FragmentJavaName(Type fragmentType)
		{
			return Class.FromType(fragmentType).Name;
		}

		public override AndroidX.Fragment.App.Fragment GetItem(int position, AndroidX.Fragment.App.Fragment.SavedState fragmentSavedState = null)
		{
			FragmentInfo fragmentInfo = Fragments.ElementAt(position);
			AndroidX.Fragment.App.Fragment fragment = AndroidX.Fragment.App.Fragment.Instantiate(_context, FragmentJavaName(fragmentInfo.FragmentType));
			if (!(fragment is MvxFragment mvxFragment))
			{
				return fragment;
			}
			if (mvxFragment.GetType().IsFragmentCacheable(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.GetType()) && fragmentSavedState != null)
			{
				return fragment;
			}
			IMvxViewModel viewModel = fragmentInfo.ViewModel ?? CreateViewModel(position);
			mvxFragment.ViewModel = viewModel;
			return fragment;
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(Fragments.ElementAt(position).Title);
		}

		protected override string GetTag(int position)
		{
			return Fragments.ElementAt(position).Tag;
		}

		private IMvxViewModel CreateViewModel(int position)
		{
			FragmentInfo fragmentInfo = Fragments.ElementAt(position);
			MvxBundle parameterBundle = null;
			if (fragmentInfo.ParameterValuesObject != null)
			{
				parameterBundle = new MvxBundle(fragmentInfo.ParameterValuesObject.ToSimplePropertyDictionary());
			}
			MvxViewModelRequest request = new MvxViewModelRequest(fragmentInfo.ViewModelType, parameterBundle, null, null);
			return Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxDialogFragment")]
	public abstract class MvxDialogFragment : MvxEventSourceDialogFragment, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer
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

		protected MvxDialogFragment()
		{
			this.AddEventListeners();
		}

		protected MvxDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected void EnsureBindingContextSet(Bundle b0)
		{
			this.EnsureBindingContextIsSet(b0);
		}
	}
	public abstract class MvxDialogFragment<TViewModel> : MvxDialogFragment, IMvxFragmentView<TViewModel>, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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
	[Register("mvvmcross.droid.support.v4.MvxFragment")]
	public class MvxFragment : MvxEventSourceFragment, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer
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
				OnViewModelSet();
			}
		}

		public virtual string UniqueImmutableCacheTag => base.Tag;

		public static MvxFragment NewInstance(Bundle bundle)
		{
			return new MvxFragment
			{
				Arguments = bundle
			};
		}

		protected MvxFragment()
		{
			this.AddEventListeners();
		}

		protected MvxFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public virtual void OnViewModelSet()
		{
		}
	}
	public abstract class MvxFragment<TViewModel> : MvxFragment, IMvxFragmentView<TViewModel>, IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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

		protected MvxFragment()
		{
		}

		protected MvxFragment(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxFragmentActivity")]
	public class MvxFragmentActivity : MvxEventSourceFragmentActivity, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner
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

		protected MvxFragmentActivity()
		{
			BindingContext = new MvxAndroidBindingContext((Context)(object)this, this);
			this.AddEventListeners();
		}

		protected MvxFragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
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
			((Activity)(object)this).SetContentView(contentView);
		}

		protected override void AttachBaseContext(Context @base)
		{
			((ContextWrapper)(object)this).AttachBaseContext((Context)MvxContextWrapper.Wrap(@base, this));
		}
	}
	public abstract class MvxFragmentActivity<TViewModel> : MvxFragmentActivity, IMvxAndroidView<TViewModel>, IMvxAndroidView, IMvxView, IMvxDataConsumer, IMvxLayoutInflaterHolder, IMvxStartActivityForResult, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
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
	public static class MvxFragmentExtensions
	{
		public static void AddEventListeners(this IMvxEventSourceFragment fragment)
		{
			if (fragment is IMvxFragmentView)
			{
				MvxBindingFragmentAdapter mvxBindingFragmentAdapter = new MvxBindingFragmentAdapter(fragment);
			}
		}

		public static void OnCreate(this IMvxFragmentView fragmentView, IMvxBundle bundle, MvxViewModelRequest request = null)
		{
			if (fragmentView.ViewModel != null)
			{
				RunViewModelLifecycle(fragmentView.ViewModel, bundle, request);
				return;
			}
			AndroidX.Fragment.App.Fragment fragment = fragmentView as AndroidX.Fragment.App.Fragment;
			if (fragmentView == null)
			{
				throw new InvalidOperationException("Something really weird. $fragmentView passed is not a Fragment!");
			}
			Type viewModelType = fragmentView.FindAssociatedViewModelType(((object)fragment.Activity).GetType());
			IMvxView view = fragmentView;
			IMvxMultipleViewModelCache mvxMultipleViewModelCache = Mvx.Resolve<IMvxMultipleViewModelCache>();
			IMvxViewModel cached = mvxMultipleViewModelCache.GetAndClear(viewModelType, fragmentView.UniqueImmutableCacheTag);
			view.OnViewCreate(() => cached ?? fragmentView.LoadViewModel(bundle, ((object)fragment.Activity).GetType(), request));
		}

		public static Type FindAssociatedViewModelType(this IMvxFragmentView fragmentView, Type fragmentActivityParentType)
		{
			Type type = fragmentView.FindAssociatedViewModelTypeOrNull();
			Type type2 = fragmentView.GetType();
			if (type == null)
			{
				if (!type2.HasMvxFragmentAttribute())
				{
					throw new InvalidOperationException("Your fragment is not generic and it does not have MvxFragmentAttribute attribute set!");
				}
				MvxFragmentAttribute mvxFragmentAttribute = type2.GetMvxFragmentAttribute(fragmentActivityParentType);
				if (mvxFragmentAttribute.ViewModelType == null)
				{
					throw new InvalidOperationException("Your fragment is not generic and it does not use MvxFragmentAttribute with ViewModel Type constructor.");
				}
				type = mvxFragmentAttribute.ViewModelType;
			}
			return type;
		}

		public static AndroidX.Fragment.App.Fragment ToFragment(this IMvxFragmentView fragmentView)
		{
			if (!(fragmentView is AndroidX.Fragment.App.Fragment result))
			{
				throw new MvxException("ToFragment called on an IMvxFragmentView which is not an Android Fragment: {0}", fragmentView);
			}
			return result;
		}

		private static void RunViewModelLifecycle(IMvxViewModel viewModel, IMvxBundle savedState, MvxViewModelRequest request)
		{
			try
			{
				if (request != null)
				{
					MvxBundle bundle = new MvxBundle(request.ParameterValues);
					viewModel.CallBundleMethods("Init", bundle);
				}
				if (savedState != null)
				{
					viewModel.CallBundleMethods("ReloadState", savedState);
				}
				viewModel.Start();
			}
			catch (System.Exception exception)
			{
				throw exception.MvxWrap("Problem running viewModel lifecycle of type {0}", viewModel.GetType().Name);
			}
		}

		private static IMvxViewModel LoadViewModel(this IMvxFragmentView fragmentView, IMvxBundle savedState, Type fragmentParentActivityType, MvxViewModelRequest request = null)
		{
			Type type = fragmentView.FindAssociatedViewModelType(fragmentParentActivityType);
			if (type == typeof(MvxNullViewModel))
			{
				return new MvxNullViewModel();
			}
			if (type == null || type == typeof(IMvxViewModel))
			{
				MvxTrace.Trace("No ViewModel class specified for {0} in LoadViewModel", fragmentView.GetType().Name);
			}
			if (request == null)
			{
				request = MvxViewModelRequest.GetDefaultRequest(type);
			}
			IMvxViewModelLoader mvxViewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
			return mvxViewModelLoader.LoadViewModel(request, savedState);
		}

		public static void EnsureBindingContextIsSet(this IMvxFragmentView fragment, LayoutInflater inflater)
		{
			AndroidX.Fragment.App.Fragment fragment2 = (AndroidX.Fragment.App.Fragment)fragment;
			if (fragment.BindingContext == null)
			{
				fragment.BindingContext = new MvxAndroidBindingContext((Context)(object)fragment2.Activity, new MvxSimpleLayoutInflaterHolder(inflater), fragment.DataContext);
			}
			else if (fragment.BindingContext is IMvxAndroidBindingContext mvxAndroidBindingContext)
			{
				mvxAndroidBindingContext.LayoutInflaterHolder = new MvxSimpleLayoutInflaterHolder(inflater);
			}
		}

		public static void EnsureBindingContextIsSet(this IMvxFragmentView fragment, Bundle b0)
		{
			AndroidX.Fragment.App.Fragment fragment2 = (AndroidX.Fragment.App.Fragment)fragment;
			if (fragment.BindingContext == null)
			{
				fragment.BindingContext = new MvxAndroidBindingContext((Context)(object)fragment2.Activity, new MvxSimpleLayoutInflaterHolder(((Activity)(object)fragment2.Activity).LayoutInflater), fragment.DataContext);
			}
			else if (fragment.BindingContext is IMvxAndroidBindingContext mvxAndroidBindingContext)
			{
				mvxAndroidBindingContext.LayoutInflaterHolder = new MvxSimpleLayoutInflaterHolder(((Activity)(object)fragment2.Activity).LayoutInflater);
			}
		}

		public static void EnsureSetupInitialized(this IMvxFragmentView fragmentView)
		{
			AndroidX.Fragment.App.Fragment fragment = fragmentView.ToFragment();
			MvxAndroidSetupSingleton mvxAndroidSetupSingleton = MvxAndroidSetupSingleton.EnsureSingletonAvailable(((Context)(object)fragment.Activity).ApplicationContext);
			mvxAndroidSetupSingleton.EnsureInitialized();
		}

		public static void RegisterFragmentViewToCacheIfNeeded(this IMvxFragmentView fragmentView, Type fragmentParentActivityType)
		{
			if (!(fragmentView is AndroidX.Fragment.App.Fragment { Activity: var activity }))
			{
				throw new InvalidOperationException($"Represented type: {fragmentView.GetType()} is not a Fragment!");
			}
			if (activity == null)
			{
				throw new InvalidOperationException("Something wrong happend, fragment has no activity attached during registration!");
			}
			if (!(activity is IFragmentCacheableActivity fragmentCacheableActivity))
			{
				throw new InvalidOperationException("Fragment has activity attached but it does not implement IFragmentCacheableActivity ! Cannot register fragment to cache!");
			}
			if (string.IsNullOrEmpty(fragmentView.UniqueImmutableCacheTag))
			{
				throw new InvalidOperationException("Contract failed - Fragment tag is null! Fragment tags are not set by default, you should add tag during FragmentTransaction or override UniqueImmutableCacheTag in your Fragment class.");
			}
			IFragmentCacheConfiguration fragmentCacheConfiguration = fragmentCacheableActivity.FragmentCacheConfiguration;
			fragmentCacheConfiguration.RegisterFragmentToCache(fragmentView.UniqueImmutableCacheTag, fragmentView.GetType(), fragmentView.FindAssociatedViewModelType(fragmentParentActivityType));
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxFragmentPagerAdapter")]
	public class MvxFragmentPagerAdapter : FragmentPagerAdapter
	{
		public class FragmentInfo
		{
			public string Title { get; set; }

			public Type FragmentType { get; private set; }

			public Type ViewModelType { get; private set; }

			public AndroidX.Fragment.App.Fragment CachedFragment { get; set; }

			public FragmentInfo(string title, Type fragmentType, Type viewModelType)
			{
				Title = title;
				FragmentType = fragmentType;
				ViewModelType = viewModelType;
			}
		}

		private readonly Context _context;

		public IEnumerable<FragmentInfo> Fragments { get; private set; }

		public override int Count => Fragments.Count();

		protected MvxFragmentPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("MvxFragmentPagerAdapter is deprecated, please use MvxCachingFragmentPagerAdapter instead.")]
		public MvxFragmentPagerAdapter(Context context, AndroidX.Fragment.App.FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
			: base(fragmentManager)
		{
			_context = context;
			Fragments = fragments;
		}

		public override AndroidX.Fragment.App.Fragment GetItem(int position)
		{
			FragmentInfo fragmentInfo = Fragments.ElementAt(position);
			if (fragmentInfo.CachedFragment == null)
			{
				fragmentInfo.CachedFragment = AndroidX.Fragment.App.Fragment.Instantiate(_context, FragmentJavaName(fragmentInfo.FragmentType));
				MvxViewModelRequest request = new MvxViewModelRequest(fragmentInfo.ViewModelType, null, null, null);
				((IMvxView)fragmentInfo.CachedFragment).ViewModel = Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
			}
			return fragmentInfo.CachedFragment;
		}

		protected static string FragmentJavaName(Type fragmentType)
		{
			return Class.FromType(fragmentType).Name;
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(Fragments.ElementAt(position).Title);
		}

		public override void RestoreState(IParcelable state, ClassLoader loader)
		{
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxFragmentStatePagerAdapter")]
	public class MvxFragmentStatePagerAdapter : FragmentStatePagerAdapter
	{
		public class FragmentInfo
		{
			public string Title { get; set; }

			public Type FragmentType { get; private set; }

			public Type ViewModelType { get; private set; }

			public AndroidX.Fragment.App.Fragment CachedFragment { get; set; }

			public FragmentInfo(string title, Type fragmentType, Type viewModelType)
			{
				Title = title;
				FragmentType = fragmentType;
				ViewModelType = viewModelType;
			}
		}

		private readonly Context _context;

		public IEnumerable<FragmentInfo> Fragments { get; private set; }

		public override int Count => Fragments.Count();

		protected MvxFragmentStatePagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("MvxFragmentStatePagerAdapter is deprecated, please use MvxCachingFragmentStatePagerAdapter instead.")]
		public MvxFragmentStatePagerAdapter(Context context, AndroidX.Fragment.App.FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
			: base(fragmentManager)
		{
			_context = context;
			Fragments = fragments;
			throw new InvalidOperationException("MvxFragmentStatePagerAdapter has broken cache implementation, use MvxFragmentPagerAdapter at this moment.");
		}

		public override AndroidX.Fragment.App.Fragment GetItem(int position)
		{
			FragmentInfo fragmentInfo = Fragments.ElementAt(position);
			if (fragmentInfo.CachedFragment == null)
			{
				fragmentInfo.CachedFragment = AndroidX.Fragment.App.Fragment.Instantiate(_context, FragmentJavaName(fragmentInfo.FragmentType));
				MvxViewModelRequest request = new MvxViewModelRequest(fragmentInfo.ViewModelType, null, null, null);
				((IMvxView)fragmentInfo.CachedFragment).ViewModel = Mvx.Resolve<IMvxViewModelLoader>().LoadViewModel(request, null);
			}
			return fragmentInfo.CachedFragment;
		}

		protected static string FragmentJavaName(Type fragmentType)
		{
			return Class.FromType(fragmentType).Name;
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return new Java.Lang.String(Fragments.ElementAt(position).Title);
		}

		public override void RestoreState(IParcelable state, ClassLoader loader)
		{
		}
	}
	public static class MvxFragmentExtensionMethods
	{
		public static TFragment FindFragmentById<TFragment>(this MvxFragmentActivity activity, int resourceId) where TFragment : AndroidX.Fragment.App.Fragment
		{
			AndroidX.Fragment.App.Fragment fragment = activity.SupportFragmentManager.FindFragmentById(resourceId);
			if (fragment == null)
			{
				Mvx.Warning("Failed to find fragment id {0} in {1}", resourceId, ((object)activity).GetType().Name);
				return null;
			}
			return SafeCast<TFragment>(fragment);
		}

		public static TFragment FindFragmentByTag<TFragment>(this MvxFragmentActivity activity, string tag) where TFragment : AndroidX.Fragment.App.Fragment
		{
			AndroidX.Fragment.App.Fragment fragment = activity.SupportFragmentManager.FindFragmentByTag(tag);
			if (fragment == null)
			{
				Mvx.Warning("Failed to find fragment tag {0} in {1}", tag, ((object)activity).GetType().Name);
				return null;
			}
			return SafeCast<TFragment>(fragment);
		}

		private static TFragment SafeCast<TFragment>(AndroidX.Fragment.App.Fragment fragment) where TFragment : AndroidX.Fragment.App.Fragment
		{
			if (!(fragment is TFragment))
			{
				Mvx.Warning("Fragment type mismatch got {0} but expected {1}", fragment.GetType().FullName, typeof(TFragment).FullName);
				return null;
			}
			return (TFragment)fragment;
		}

		public static void LoadViewModelFrom(this IMvxFragmentView view, MvxViewModelRequest request, IMvxBundle savedState = null)
		{
			IMvxViewModelLoader mvxViewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
			IMvxViewModel mvxViewModel = mvxViewModelLoader.LoadViewModel(request, savedState);
			if (mvxViewModel == null)
			{
				Mvx.Warning("ViewModel not loaded for {0}", request.ViewModelType.FullName);
			}
			else
			{
				view.ViewModel = mvxViewModel;
			}
		}
	}
	[Register("mvvmcross.droid.support.v4.MvxTabsFragmentActivity")]
	public abstract class MvxTabsFragmentActivity : MvxFragmentActivity, TabHost.IOnTabChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		protected class TabInfo
		{
			public string Tag { get; private set; }

			public Type FragmentType { get; private set; }

			public Bundle Bundle { get; private set; }

			public IMvxViewModel ViewModel { get; private set; }

			public AndroidX.Fragment.App.Fragment CachedFragment { get; set; }

			public TabInfo(string tag, Type fragmentType, Bundle bundle, IMvxViewModel viewModel)
			{
				Tag = tag;
				FragmentType = fragmentType;
				Bundle = bundle;
				ViewModel = viewModel;
			}
		}

		private class TabFactory : Java.Lang.Object, TabHost.ITabContentFactory, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly Context _context;

			public TabFactory(Context context)
			{
				_context = context;
			}

			public View CreateTabContent(string tag)
			{
				View view = new View(_context);
				view.SetMinimumWidth(0);
				view.SetMinimumHeight(0);
				return view;
			}
		}

		private const string SavedTabIndexStateKey = "__savedTabIndex";

		private readonly Dictionary<string, TabInfo> _lookup = new Dictionary<string, TabInfo>();

		private readonly int _layoutId;

		private TabHost _tabHost;

		private TabInfo _currentTab;

		private readonly int _tabContentId;

		protected MvxTabsFragmentActivity(int layoutId, int tabContentId)
		{
			_layoutId = layoutId;
			_tabContentId = tabContentId;
		}

		protected MvxTabsFragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			((Activity)(object)this).SetContentView(_layoutId);
			InitializeTabHost(savedInstanceState);
			if (savedInstanceState != null)
			{
				_tabHost.SetCurrentTabByTag(savedInstanceState.GetString("__savedTabIndex"));
			}
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutString("__savedTabIndex", _tabHost.CurrentTabTag);
			base.OnSaveInstanceState(outState);
		}

		private void InitializeTabHost(Bundle args)
		{
			_tabHost = (TabHost)((Activity)(object)this).FindViewById(16908306);
			_tabHost.Setup();
			AddTabs(args);
			if (_lookup.Any())
			{
				OnTabChanged(_lookup.First().Key);
			}
			_tabHost.SetOnTabChangedListener(this);
		}

		protected abstract void AddTabs(Bundle args);

		protected void AddTab<TFragment>(string tagAndSpecName, string tabName, Bundle args, IMvxViewModel viewModel)
		{
			TabHost.TabSpec tabSpec = _tabHost.NewTabSpec(tagAndSpecName).SetIndicator(tabName);
			AddTab<TFragment>(args, viewModel, tabSpec);
		}

		protected void AddTab<TFragment>(Bundle args, IMvxViewModel viewModel, TabHost.TabSpec tabSpec)
		{
			TabInfo tabInfo = new TabInfo(tabSpec.Tag, typeof(TFragment), args, viewModel);
			AddTab(this, _tabHost, tabSpec, tabInfo);
			_lookup.Add(tabInfo.Tag, tabInfo);
		}

		private static void AddTab(MvxTabsFragmentActivity activity, TabHost tabHost, TabHost.TabSpec tabSpec, TabInfo tabInfo)
		{
			tabSpec.SetContent(new TabFactory((Context)(object)activity));
			string tag = tabSpec.Tag;
			tabInfo.CachedFragment = activity.SupportFragmentManager.FindFragmentByTag(tag);
			if (tabInfo.CachedFragment != null && !tabInfo.CachedFragment.IsDetached)
			{
				AndroidX.Fragment.App.FragmentTransaction fragmentTransaction = activity.SupportFragmentManager.BeginTransaction();
				fragmentTransaction.Detach(tabInfo.CachedFragment);
				fragmentTransaction.Commit();
				activity.SupportFragmentManager.ExecutePendingTransactions();
			}
			tabHost.AddTab(tabSpec);
		}

		public virtual void OnTabChanged(string tag)
		{
			TabInfo tabInfo = _lookup[tag];
			if (_currentTab == tabInfo)
			{
				return;
			}
			AndroidX.Fragment.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction();
			OnTabFragmentChanging(tag, fragmentTransaction);
			if (_currentTab?.CachedFragment != null)
			{
				fragmentTransaction.Detach(_currentTab.CachedFragment);
			}
			if (tabInfo != null)
			{
				if (tabInfo.CachedFragment == null)
				{
					tabInfo.CachedFragment = AndroidX.Fragment.App.Fragment.Instantiate((Context)(object)this, FragmentJavaName(tabInfo.FragmentType), tabInfo.Bundle);
					FixupDataContext(tabInfo);
					fragmentTransaction.Add(_tabContentId, tabInfo.CachedFragment, tabInfo.Tag);
				}
				else
				{
					FixupDataContext(tabInfo);
					fragmentTransaction.Attach(tabInfo.CachedFragment);
				}
			}
			_currentTab = tabInfo;
			fragmentTransaction.Commit();
			SupportFragmentManager.ExecutePendingTransactions();
		}

		protected virtual void FixupDataContext(TabInfo newTab)
		{
			if (newTab.CachedFragment is IMvxDataConsumer mvxDataConsumer && mvxDataConsumer.DataContext != newTab.ViewModel)
			{
				mvxDataConsumer.DataContext = newTab.ViewModel;
			}
		}

		protected virtual string FragmentJavaName(Type fragmentType)
		{
			return Class.FromType(fragmentType).Name;
		}

		public virtual void OnTabFragmentChanging(string tag, AndroidX.Fragment.App.FragmentTransaction transaction)
		{
		}
	}
}
namespace MvvmCross.Droid.Support.V4.EventSource
{
	public class MvxBaseFragmentAdapter
	{
		private readonly IMvxEventSourceFragment _eventSource;

		protected AndroidX.Fragment.App.Fragment Fragment => _eventSource as AndroidX.Fragment.App.Fragment;

		public MvxBaseFragmentAdapter(IMvxEventSourceFragment eventSource)
		{
			if (eventSource == null)
			{
				throw new ArgumentException("eventSource should not be null", "eventSource");
			}
			if (!(eventSource is AndroidX.Fragment.App.Fragment))
			{
				throw new ArgumentException("eventSource should be a Fragment", "eventSource");
			}
			_eventSource = eventSource;
			_eventSource.DisposeCalled += HandleDisposeCalled;
			_eventSource.CreateViewCalled += HandleCreateViewCalled;
			_eventSource.DestroyViewCalled += HandleDestroyViewCalled;
			_eventSource.AttachCalled += HandleAttachCalled;
			_eventSource.CreateCalled += HandleCreateCalled;
			_eventSource.StartCalled += HandleStartCalled;
			_eventSource.StopCalled += HandleStopCalled;
			_eventSource.PauseCalled += HandlePauseCalled;
			_eventSource.ResumeCalled += HandleResumeCalled;
			_eventSource.DetachCalled += HandleDetachCalled;
			_eventSource.SaveInstanceStateCalled += HandleSaveInstanceStateCalled;
		}

		protected virtual void HandleSaveInstanceStateCalled(object sender, MvxValueEventArgs<Bundle> e)
		{
		}

		protected virtual void HandleDetachCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandleResumeCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandlePauseCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandleStopCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandleStartCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandleCreateCalled(object sender, MvxValueEventArgs<Bundle> e)
		{
		}

		protected virtual void HandleAttachCalled(object sender, MvxValueEventArgs<Activity> e)
		{
		}

		protected virtual void HandleDisposeCalled(object sender, EventArgs e)
		{
		}

		protected virtual void HandleDestroyViewCalled(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void HandleCreateViewCalled(object sender, MvxValueEventArgs<MvxCreateViewParameters> mvxValueEventArgs)
		{
		}
	}
	public class MvxBindingFragmentAdapter : MvxBaseFragmentAdapter
	{
		public IMvxFragmentView FragmentView => base.Fragment as IMvxFragmentView;

		public MvxBindingFragmentAdapter(IMvxEventSourceFragment eventSource)
			: base(eventSource)
		{
			if (!(eventSource is IMvxFragmentView))
			{
				throw new ArgumentException("eventSource must be an IMvxFragmentView");
			}
		}

		protected override void HandleCreateCalled(object sender, MvxValueEventArgs<Bundle> bundleArgs)
		{
			FragmentView.EnsureSetupInitialized();
			if (!FragmentView.GetType().IsFragmentCacheable(((object)base.Fragment.Activity).GetType()))
			{
				return;
			}
			FragmentView.RegisterFragmentViewToCacheIfNeeded(((object)base.Fragment.Activity).GetType());
			Bundle bundle = null;
			MvxViewModelRequest request = null;
			if (bundleArgs?.Value != null)
			{
				bundle = bundleArgs.Value;
			}
			else
			{
				AndroidX.Fragment.App.Fragment fragment = FragmentView as AndroidX.Fragment.App.Fragment;
				if (fragment?.Arguments != null)
				{
					bundle = fragment.Arguments;
					string text = bundle.GetString("__mvxViewModelRequest");
					if (!string.IsNullOrEmpty(text))
					{
						if (!Mvx.TryResolve<IMvxNavigationSerializer>(out var service))
						{
							MvxTrace.Warning("Navigation Serializer not available, deserializing ViewModel Request will be hard");
						}
						else
						{
							request = service.Serializer.DeserializeObject<MvxViewModelRequest>(text);
						}
					}
				}
			}
			if (!Mvx.TryResolve<IMvxSavedStateConverter>(out var service2))
			{
				MvxTrace.Warning("Saved state converter not available - saving state will be hard");
			}
			else if (bundle != null)
			{
				IMvxBundle bundle2 = service2.Read(bundle);
				FragmentView.OnCreate(bundle2, request);
			}
		}

		protected override void HandleCreateViewCalled(object sender, MvxValueEventArgs<MvxCreateViewParameters> args)
		{
			FragmentView.EnsureBindingContextIsSet(args.Value.Inflater);
		}

		protected override void HandleSaveInstanceStateCalled(object sender, MvxValueEventArgs<Bundle> bundleArgs)
		{
			if (!FragmentView.GetType().IsFragmentCacheable(((object)base.Fragment.Activity).GetType()))
			{
				return;
			}
			IMvxBundle mvxBundle = FragmentView.CreateSaveStateBundle();
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
			IMvxMultipleViewModelCache mvxMultipleViewModelCache = Mvx.Resolve<IMvxMultipleViewModelCache>();
			mvxMultipleViewModelCache.Cache(FragmentView.ViewModel, FragmentView.UniqueImmutableCacheTag);
		}

		protected override void HandleDestroyViewCalled(object sender, EventArgs e)
		{
			FragmentView.BindingContext?.ClearAllBindings();
			base.HandleDestroyViewCalled(sender, e);
		}

		protected override void HandleDisposeCalled(object sender, EventArgs e)
		{
			FragmentView.BindingContext?.ClearAllBindings();
			base.HandleDisposeCalled(sender, e);
		}
	}
	public class MvxEventSourceDialogFragment : AndroidX.Fragment.App.DialogFragment, IMvxEventSourceFragment, IMvxDisposeSource
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

		protected MvxEventSourceDialogFragment()
		{
		}

		protected MvxEventSourceDialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
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
	public class MvxEventSourceFragment : AndroidX.Fragment.App.Fragment, IMvxEventSourceFragment, IMvxDisposeSource
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

		public MvxEventSourceFragment()
		{
		}

		public MvxEventSourceFragment(IntPtr javaReference, JniHandleOwnership transfer)
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
	public abstract class MvxEventSourceFragmentActivity : FragmentActivity, IMvxEventSourceActivity, IMvxDisposeSource
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

		protected MvxEventSourceFragmentActivity()
		{
		}

		protected MvxEventSourceFragmentActivity(IntPtr javaReference, JniHandleOwnership transfer)
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
	public class MvxEventSourceListFragment : ListFragment, IMvxEventSourceFragment, IMvxDisposeSource
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

		protected MvxEventSourceListFragment()
		{
		}

		protected MvxEventSourceListFragment(IntPtr javaReference, JniHandleOwnership transfer)
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
}
namespace MvvmCross.Droid.Support.Fragment
{
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Animation
		{
			public static int fragment_close_enter;

			public static int fragment_close_exit;

			public static int fragment_fade_enter;

			public static int fragment_fade_exit;

			public static int fragment_fast_out_extra_slow_in;

			public static int fragment_open_enter;

			public static int fragment_open_exit;

			static Animation()
			{
				fragment_close_enter = 2130771968;
				fragment_close_exit = 2130771969;
				fragment_fade_enter = 2130771970;
				fragment_fade_exit = 2130771971;
				fragment_fast_out_extra_slow_in = 2130771972;
				fragment_open_enter = 2130771973;
				fragment_open_exit = 2130771974;
				ResourceIdManager.UpdateIdValues();
			}

			private Animation()
			{
			}
		}

		public class Attribute
		{
			public static int alpha;

			public static int coordinatorLayoutStyle;

			public static int font;

			public static int fontProviderAuthority;

			public static int fontProviderCerts;

			public static int fontProviderFetchStrategy;

			public static int fontProviderFetchTimeout;

			public static int fontProviderPackage;

			public static int fontProviderQuery;

			public static int fontStyle;

			public static int fontVariationSettings;

			public static int fontWeight;

			public static int keylines;

			public static int layout_anchor;

			public static int layout_anchorGravity;

			public static int layout_behavior;

			public static int layout_dodgeInsetEdges;

			public static int layout_insetEdge;

			public static int layout_keyline;

			public static int MvxBind;

			public static int MvxDropDownItemTemplate;

			public static int MvxGroupItemTemplate;

			public static int MvxItemTemplate;

			public static int MvxLang;

			public static int MvxSource;

			public static int MvxTemplate;

			public static int statusBarBackground;

			public static int ttcIndex;

			static Attribute()
			{
				alpha = 2130837511;
				coordinatorLayoutStyle = 2130837512;
				font = 2130837513;
				fontProviderAuthority = 2130837514;
				fontProviderCerts = 2130837515;
				fontProviderFetchStrategy = 2130837516;
				fontProviderFetchTimeout = 2130837517;
				fontProviderPackage = 2130837518;
				fontProviderQuery = 2130837519;
				fontStyle = 2130837520;
				fontVariationSettings = 2130837521;
				fontWeight = 2130837522;
				keylines = 2130837523;
				layout_anchor = 2130837524;
				layout_anchorGravity = 2130837525;
				layout_behavior = 2130837526;
				layout_dodgeInsetEdges = 2130837527;
				layout_insetEdge = 2130837528;
				layout_keyline = 2130837529;
				MvxBind = 2130837504;
				MvxDropDownItemTemplate = 2130837505;
				MvxGroupItemTemplate = 2130837506;
				MvxItemTemplate = 2130837507;
				MvxLang = 2130837508;
				MvxSource = 2130837509;
				MvxTemplate = 2130837510;
				statusBarBackground = 2130837530;
				ttcIndex = 2130837531;
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class Color
		{
			public static int androidx_core_ripple_material_light;

			public static int androidx_core_secondary_text_default_material_light;

			public static int notification_action_color_filter;

			public static int notification_icon_bg_color;

			public static int notification_material_background_media_default_color;

			public static int primary_text_default_material_dark;

			public static int secondary_text_default_material_dark;

			static Color()
			{
				androidx_core_ripple_material_light = 2130903040;
				androidx_core_secondary_text_default_material_light = 2130903041;
				notification_action_color_filter = 2130903042;
				notification_icon_bg_color = 2130903043;
				notification_material_background_media_default_color = 2130903044;
				primary_text_default_material_dark = 2130903045;
				secondary_text_default_material_dark = 2130903046;
				ResourceIdManager.UpdateIdValues();
			}

			private Color()
			{
			}
		}

		public class Dimension
		{
			public static int compat_button_inset_horizontal_material;

			public static int compat_button_inset_vertical_material;

			public static int compat_button_padding_horizontal_material;

			public static int compat_button_padding_vertical_material;

			public static int compat_control_corner_material;

			public static int compat_notification_large_icon_max_height;

			public static int compat_notification_large_icon_max_width;

			public static int notification_action_icon_size;

			public static int notification_action_text_size;

			public static int notification_big_circle_margin;

			public static int notification_content_margin_start;

			public static int notification_large_icon_height;

			public static int notification_large_icon_width;

			public static int notification_main_column_padding_top;

			public static int notification_media_narrow_margin;

			public static int notification_right_icon_size;

			public static int notification_right_side_padding_top;

			public static int notification_small_icon_background_padding;

			public static int notification_small_icon_size_as_large;

			public static int notification_subtext_size;

			public static int notification_top_pad;

			public static int notification_top_pad_large_text;

			public static int subtitle_corner_radius;

			public static int subtitle_outline_width;

			public static int subtitle_shadow_offset;

			public static int subtitle_shadow_radius;

			static Dimension()
			{
				compat_button_inset_horizontal_material = 2130968576;
				compat_button_inset_vertical_material = 2130968577;
				compat_button_padding_horizontal_material = 2130968578;
				compat_button_padding_vertical_material = 2130968579;
				compat_control_corner_material = 2130968580;
				compat_notification_large_icon_max_height = 2130968581;
				compat_notification_large_icon_max_width = 2130968582;
				notification_action_icon_size = 2130968583;
				notification_action_text_size = 2130968584;
				notification_big_circle_margin = 2130968585;
				notification_content_margin_start = 2130968586;
				notification_large_icon_height = 2130968587;
				notification_large_icon_width = 2130968588;
				notification_main_column_padding_top = 2130968589;
				notification_media_narrow_margin = 2130968590;
				notification_right_icon_size = 2130968591;
				notification_right_side_padding_top = 2130968592;
				notification_small_icon_background_padding = 2130968593;
				notification_small_icon_size_as_large = 2130968594;
				notification_subtext_size = 2130968595;
				notification_top_pad = 2130968596;
				notification_top_pad_large_text = 2130968597;
				subtitle_corner_radius = 2130968598;
				subtitle_outline_width = 2130968599;
				subtitle_shadow_offset = 2130968600;
				subtitle_shadow_radius = 2130968601;
				ResourceIdManager.UpdateIdValues();
			}

			private Dimension()
			{
			}
		}

		public class Drawable
		{
			public static int notification_action_background;

			public static int notification_bg;

			public static int notification_bg_low;

			public static int notification_bg_low_normal;

			public static int notification_bg_low_pressed;

			public static int notification_bg_normal;

			public static int notification_bg_normal_pressed;

			public static int notification_icon_background;

			public static int notification_template_icon_bg;

			public static int notification_template_icon_low_bg;

			public static int notification_tile_bg;

			public static int notify_panel_notification_icon_bg;

			static Drawable()
			{
				notification_action_background = 2131034112;
				notification_bg = 2131034113;
				notification_bg_low = 2131034114;
				notification_bg_low_normal = 2131034115;
				notification_bg_low_pressed = 2131034116;
				notification_bg_normal = 2131034117;
				notification_bg_normal_pressed = 2131034118;
				notification_icon_background = 2131034119;
				notification_template_icon_bg = 2131034120;
				notification_template_icon_low_bg = 2131034121;
				notification_tile_bg = 2131034122;
				notify_panel_notification_icon_bg = 2131034123;
				ResourceIdManager.UpdateIdValues();
			}

			private Drawable()
			{
			}
		}

		public class Id
		{
			public static int accessibility_action_clickable_span;

			public static int accessibility_custom_action_0;

			public static int accessibility_custom_action_1;

			public static int accessibility_custom_action_10;

			public static int accessibility_custom_action_11;

			public static int accessibility_custom_action_12;

			public static int accessibility_custom_action_13;

			public static int accessibility_custom_action_14;

			public static int accessibility_custom_action_15;

			public static int accessibility_custom_action_16;

			public static int accessibility_custom_action_17;

			public static int accessibility_custom_action_18;

			public static int accessibility_custom_action_19;

			public static int accessibility_custom_action_2;

			public static int accessibility_custom_action_20;

			public static int accessibility_custom_action_21;

			public static int accessibility_custom_action_22;

			public static int accessibility_custom_action_23;

			public static int accessibility_custom_action_24;

			public static int accessibility_custom_action_25;

			public static int accessibility_custom_action_26;

			public static int accessibility_custom_action_27;

			public static int accessibility_custom_action_28;

			public static int accessibility_custom_action_29;

			public static int accessibility_custom_action_3;

			public static int accessibility_custom_action_30;

			public static int accessibility_custom_action_31;

			public static int accessibility_custom_action_4;

			public static int accessibility_custom_action_5;

			public static int accessibility_custom_action_6;

			public static int accessibility_custom_action_7;

			public static int accessibility_custom_action_8;

			public static int accessibility_custom_action_9;

			public static int action0;

			public static int actions;

			public static int action_container;

			public static int action_divider;

			public static int action_image;

			public static int action_text;

			public static int all;

			public static int async;

			public static int blocking;

			public static int bottom;

			public static int cancel_action;

			public static int center;

			public static int center_horizontal;

			public static int center_vertical;

			public static int chronometer;

			public static int clip_horizontal;

			public static int clip_vertical;

			public static int dialog_button;

			public static int end;

			public static int end_padder;

			public static int fill;

			public static int fill_horizontal;

			public static int fill_vertical;

			public static int forever;

			public static int fragment_container_view_tag;

			public static int icon;

			public static int icon_group;

			public static int info;

			public static int italic;

			public static int left;

			public static int line1;

			public static int line3;

			public static int media_actions;

			public static int MvvmCrossTagId;

			public static int MvxBindingTagUnique;

			public static int none;

			public static int normal;

			public static int notification_background;

			public static int notification_main_column;

			public static int notification_main_column_container;

			public static int right;

			public static int right_icon;

			public static int right_side;

			public static int start;

			public static int status_bar_latest_event_content;

			public static int tag_accessibility_actions;

			public static int tag_accessibility_clickable_spans;

			public static int tag_accessibility_heading;

			public static int tag_accessibility_pane_title;

			public static int tag_screen_reader_focusable;

			public static int tag_transition_group;

			public static int tag_unhandled_key_event_manager;

			public static int tag_unhandled_key_listeners;

			public static int text;

			public static int text2;

			public static int time;

			public static int title;

			public static int top;

			public static int view_tree_lifecycle_owner;

			public static int view_tree_saved_state_registry_owner;

			public static int view_tree_view_model_store_owner;

			public static int visible_removing_fragment_view_tag;

			static Id()
			{
				accessibility_action_clickable_span = 2131099650;
				accessibility_custom_action_0 = 2131099651;
				accessibility_custom_action_1 = 2131099652;
				accessibility_custom_action_10 = 2131099653;
				accessibility_custom_action_11 = 2131099654;
				accessibility_custom_action_12 = 2131099655;
				accessibility_custom_action_13 = 2131099656;
				accessibility_custom_action_14 = 2131099657;
				accessibility_custom_action_15 = 2131099658;
				accessibility_custom_action_16 = 2131099659;
				accessibility_custom_action_17 = 2131099660;
				accessibility_custom_action_18 = 2131099661;
				accessibility_custom_action_19 = 2131099662;
				accessibility_custom_action_2 = 2131099663;
				accessibility_custom_action_20 = 2131099664;
				accessibility_custom_action_21 = 2131099665;
				accessibility_custom_action_22 = 2131099666;
				accessibility_custom_action_23 = 2131099667;
				accessibility_custom_action_24 = 2131099668;
				accessibility_custom_action_25 = 2131099669;
				accessibility_custom_action_26 = 2131099670;
				accessibility_custom_action_27 = 2131099671;
				accessibility_custom_action_28 = 2131099672;
				accessibility_custom_action_29 = 2131099673;
				accessibility_custom_action_3 = 2131099674;
				accessibility_custom_action_30 = 2131099675;
				accessibility_custom_action_31 = 2131099676;
				accessibility_custom_action_4 = 2131099677;
				accessibility_custom_action_5 = 2131099678;
				accessibility_custom_action_6 = 2131099679;
				accessibility_custom_action_7 = 2131099680;
				accessibility_custom_action_8 = 2131099681;
				accessibility_custom_action_9 = 2131099682;
				action0 = 2131099683;
				actions = 2131099688;
				action_container = 2131099684;
				action_divider = 2131099685;
				action_image = 2131099686;
				action_text = 2131099687;
				all = 2131099689;
				async = 2131099690;
				blocking = 2131099691;
				bottom = 2131099692;
				cancel_action = 2131099693;
				center = 2131099694;
				center_horizontal = 2131099695;
				center_vertical = 2131099696;
				chronometer = 2131099697;
				clip_horizontal = 2131099698;
				clip_vertical = 2131099699;
				dialog_button = 2131099700;
				end = 2131099701;
				end_padder = 2131099702;
				fill = 2131099703;
				fill_horizontal = 2131099704;
				fill_vertical = 2131099705;
				forever = 2131099706;
				fragment_container_view_tag = 2131099707;
				icon = 2131099708;
				icon_group = 2131099709;
				info = 2131099710;
				italic = 2131099711;
				left = 2131099712;
				line1 = 2131099713;
				line3 = 2131099714;
				media_actions = 2131099715;
				MvvmCrossTagId = 2131099648;
				MvxBindingTagUnique = 2131099649;
				none = 2131099716;
				normal = 2131099717;
				notification_background = 2131099718;
				notification_main_column = 2131099719;
				notification_main_column_container = 2131099720;
				right = 2131099721;
				right_icon = 2131099722;
				right_side = 2131099723;
				start = 2131099724;
				status_bar_latest_event_content = 2131099725;
				tag_accessibility_actions = 2131099726;
				tag_accessibility_clickable_spans = 2131099727;
				tag_accessibility_heading = 2131099728;
				tag_accessibility_pane_title = 2131099729;
				tag_screen_reader_focusable = 2131099730;
				tag_transition_group = 2131099731;
				tag_unhandled_key_event_manager = 2131099732;
				tag_unhandled_key_listeners = 2131099733;
				text = 2131099734;
				text2 = 2131099735;
				time = 2131099736;
				title = 2131099737;
				top = 2131099738;
				view_tree_lifecycle_owner = 2131099739;
				view_tree_saved_state_registry_owner = 2131099740;
				view_tree_view_model_store_owner = 2131099741;
				visible_removing_fragment_view_tag = 2131099742;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Integer
		{
			public static int cancel_button_image_alpha;

			public static int status_bar_notification_info_maxnum;

			static Integer()
			{
				cancel_button_image_alpha = 2131165184;
				status_bar_notification_info_maxnum = 2131165185;
				ResourceIdManager.UpdateIdValues();
			}

			private Integer()
			{
			}
		}

		public class Layout
		{
			public static int custom_dialog;

			public static int notification_action;

			public static int notification_action_tombstone;

			public static int notification_media_action;

			public static int notification_media_cancel_action;

			public static int notification_template_big_media;

			public static int notification_template_big_media_custom;

			public static int notification_template_big_media_narrow;

			public static int notification_template_big_media_narrow_custom;

			public static int notification_template_custom_big;

			public static int notification_template_icon_group;

			public static int notification_template_lines_media;

			public static int notification_template_media;

			public static int notification_template_media_custom;

			public static int notification_template_part_chronometer;

			public static int notification_template_part_time;

			static Layout()
			{
				custom_dialog = 2131230720;
				notification_action = 2131230721;
				notification_action_tombstone = 2131230722;
				notification_media_action = 2131230723;
				notification_media_cancel_action = 2131230724;
				notification_template_big_media = 2131230725;
				notification_template_big_media_custom = 2131230726;
				notification_template_big_media_narrow = 2131230727;
				notification_template_big_media_narrow_custom = 2131230728;
				notification_template_custom_big = 2131230729;
				notification_template_icon_group = 2131230730;
				notification_template_lines_media = 2131230731;
				notification_template_media = 2131230732;
				notification_template_media_custom = 2131230733;
				notification_template_part_chronometer = 2131230734;
				notification_template_part_time = 2131230735;
				ResourceIdManager.UpdateIdValues();
			}

			private Layout()
			{
			}
		}

		public class String
		{
			public static int library_name;

			public static int status_bar_notification_info_overflow;

			static String()
			{
				library_name = 2131296256;
				status_bar_notification_info_overflow = 2131296257;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		public class Style
		{
			public static int TextAppearance_Compat_Notification;

			public static int TextAppearance_Compat_Notification_Info;

			public static int TextAppearance_Compat_Notification_Info_Media;

			public static int TextAppearance_Compat_Notification_Line2;

			public static int TextAppearance_Compat_Notification_Line2_Media;

			public static int TextAppearance_Compat_Notification_Media;

			public static int TextAppearance_Compat_Notification_Time;

			public static int TextAppearance_Compat_Notification_Time_Media;

			public static int TextAppearance_Compat_Notification_Title;

			public static int TextAppearance_Compat_Notification_Title_Media;

			public static int Widget_Compat_NotificationActionContainer;

			public static int Widget_Compat_NotificationActionText;

			public static int Widget_Support_CoordinatorLayout;

			static Style()
			{
				TextAppearance_Compat_Notification = 2131361792;
				TextAppearance_Compat_Notification_Info = 2131361793;
				TextAppearance_Compat_Notification_Info_Media = 2131361794;
				TextAppearance_Compat_Notification_Line2 = 2131361795;
				TextAppearance_Compat_Notification_Line2_Media = 2131361796;
				TextAppearance_Compat_Notification_Media = 2131361797;
				TextAppearance_Compat_Notification_Time = 2131361798;
				TextAppearance_Compat_Notification_Time_Media = 2131361799;
				TextAppearance_Compat_Notification_Title = 2131361800;
				TextAppearance_Compat_Notification_Title_Media = 2131361801;
				Widget_Compat_NotificationActionContainer = 2131361802;
				Widget_Compat_NotificationActionText = 2131361803;
				Widget_Support_CoordinatorLayout = 2131361804;
				ResourceIdManager.UpdateIdValues();
			}

			private Style()
			{
			}
		}

		public class Styleable
		{
			public static int[] ColorStateListItem;

			public static int ColorStateListItem_alpha;

			public static int ColorStateListItem_android_alpha;

			public static int ColorStateListItem_android_color;

			public static int[] CoordinatorLayout;

			public static int CoordinatorLayout_keylines;

			public static int[] CoordinatorLayout_Layout;

			public static int CoordinatorLayout_Layout_android_layout_gravity;

			public static int CoordinatorLayout_Layout_layout_anchor;

			public static int CoordinatorLayout_Layout_layout_anchorGravity;

			public static int CoordinatorLayout_Layout_layout_behavior;

			public static int CoordinatorLayout_Layout_layout_dodgeInsetEdges;

			public static int CoordinatorLayout_Layout_layout_insetEdge;

			public static int CoordinatorLayout_Layout_layout_keyline;

			public static int CoordinatorLayout_statusBarBackground;

			public static int[] FontFamily;

			public static int[] FontFamilyFont;

			public static int FontFamilyFont_android_font;

			public static int FontFamilyFont_android_fontStyle;

			public static int FontFamilyFont_android_fontVariationSettings;

			public static int FontFamilyFont_android_fontWeight;

			public static int FontFamilyFont_android_ttcIndex;

			public static int FontFamilyFont_font;

			public static int FontFamilyFont_fontStyle;

			public static int FontFamilyFont_fontVariationSettings;

			public static int FontFamilyFont_fontWeight;

			public static int FontFamilyFont_ttcIndex;

			public static int FontFamily_fontProviderAuthority;

			public static int FontFamily_fontProviderCerts;

			public static int FontFamily_fontProviderFetchStrategy;

			public static int FontFamily_fontProviderFetchTimeout;

			public static int FontFamily_fontProviderPackage;

			public static int FontFamily_fontProviderQuery;

			public static int[] Fragment;

			public static int[] FragmentContainerView;

			public static int FragmentContainerView_android_name;

			public static int FragmentContainerView_android_tag;

			public static int Fragment_android_id;

			public static int Fragment_android_name;

			public static int Fragment_android_tag;

			public static int[] GradientColor;

			public static int[] GradientColorItem;

			public static int GradientColorItem_android_color;

			public static int GradientColorItem_android_offset;

			public static int GradientColor_android_centerColor;

			public static int GradientColor_android_centerX;

			public static int GradientColor_android_centerY;

			public static int GradientColor_android_endColor;

			public static int GradientColor_android_endX;

			public static int GradientColor_android_endY;

			public static int GradientColor_android_gradientRadius;

			public static int GradientColor_android_startColor;

			public static int GradientColor_android_startX;

			public static int GradientColor_android_startY;

			public static int GradientColor_android_tileMode;

			public static int GradientColor_android_type;

			public static int[] MvxBinding;

			public static int MvxBinding_MvxBind;

			public static int MvxBinding_MvxLang;

			public static int[] MvxControl;

			public static int MvxControl_MvxTemplate;

			public static int[] MvxExpandableListView;

			public static int MvxExpandableListView_MvxGroupItemTemplate;

			public static int[] MvxImageView;

			public static int MvxImageView_MvxSource;

			public static int[] MvxListView;

			public static int MvxListView_MvxDropDownItemTemplate;

			public static int MvxListView_MvxItemTemplate;

			static Styleable()
			{
				ColorStateListItem = new int[3] { 16843173, 16843551, 2130837511 };
				ColorStateListItem_alpha = 2;
				ColorStateListItem_android_alpha = 1;
				ColorStateListItem_android_color = 0;
				CoordinatorLayout = new int[2] { 2130837523, 2130837530 };
				CoordinatorLayout_keylines = 0;
				CoordinatorLayout_Layout = new int[7] { 16842931, 2130837524, 2130837525, 2130837526, 2130837527, 2130837528, 2130837529 };
				CoordinatorLayout_Layout_android_layout_gravity = 0;
				CoordinatorLayout_Layout_layout_anchor = 1;
				CoordinatorLayout_Layout_layout_anchorGravity = 2;
				CoordinatorLayout_Layout_layout_behavior = 3;
				CoordinatorLayout_Layout_layout_dodgeInsetEdges = 4;
				CoordinatorLayout_Layout_layout_insetEdge = 5;
				CoordinatorLayout_Layout_layout_keyline = 6;
				CoordinatorLayout_statusBarBackground = 1;
				FontFamily = new int[6] { 2130837514, 2130837515, 2130837516, 2130837517, 2130837518, 2130837519 };
				FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130837513, 2130837520, 2130837521, 2130837522, 2130837531 };
				FontFamilyFont_android_font = 0;
				FontFamilyFont_android_fontStyle = 2;
				FontFamilyFont_android_fontVariationSettings = 4;
				FontFamilyFont_android_fontWeight = 1;
				FontFamilyFont_android_ttcIndex = 3;
				FontFamilyFont_font = 5;
				FontFamilyFont_fontStyle = 6;
				FontFamilyFont_fontVariationSettings = 7;
				FontFamilyFont_fontWeight = 8;
				FontFamilyFont_ttcIndex = 9;
				FontFamily_fontProviderAuthority = 0;
				FontFamily_fontProviderCerts = 1;
				FontFamily_fontProviderFetchStrategy = 2;
				FontFamily_fontProviderFetchTimeout = 3;
				FontFamily_fontProviderPackage = 4;
				FontFamily_fontProviderQuery = 5;
				Fragment = new int[3] { 16842755, 16842960, 16842961 };
				FragmentContainerView = new int[2] { 16842755, 16842961 };
				FragmentContainerView_android_name = 0;
				FragmentContainerView_android_tag = 1;
				Fragment_android_id = 1;
				Fragment_android_name = 0;
				Fragment_android_tag = 2;
				GradientColor = new int[12]
				{
					16843165, 16843166, 16843169, 16843170, 16843171, 16843172, 16843265, 16843275, 16844048, 16844049,
					16844050, 16844051
				};
				GradientColorItem = new int[2] { 16843173, 16844052 };
				GradientColorItem_android_color = 0;
				GradientColorItem_android_offset = 1;
				GradientColor_android_centerColor = 7;
				GradientColor_android_centerX = 3;
				GradientColor_android_centerY = 4;
				GradientColor_android_endColor = 1;
				GradientColor_android_endX = 10;
				GradientColor_android_endY = 11;
				GradientColor_android_gradientRadius = 5;
				GradientColor_android_startColor = 0;
				GradientColor_android_startX = 8;
				GradientColor_android_startY = 9;
				GradientColor_android_tileMode = 6;
				GradientColor_android_type = 2;
				MvxBinding = new int[2] { 2130837504, 2130837508 };
				MvxBinding_MvxBind = 0;
				MvxBinding_MvxLang = 1;
				MvxControl = new int[1] { 2130837510 };
				MvxControl_MvxTemplate = 0;
				MvxExpandableListView = new int[1] { 2130837506 };
				MvxExpandableListView_MvxGroupItemTemplate = 0;
				MvxImageView = new int[1] { 2130837509 };
				MvxImageView_MvxSource = 0;
				MvxListView = new int[2] { 2130837505, 2130837507 };
				MvxListView_MvxDropDownItemTemplate = 0;
				MvxListView_MvxItemTemplate = 1;
				ResourceIdManager.UpdateIdValues();
			}

			private Styleable()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
