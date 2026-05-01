using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Shared.Fragments;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Platform;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Droid.Shared")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross.Droid.Shared")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace MvvmCross.Droid.Shared
{
	public class MvxCreateViewParameters
	{
		public LayoutInflater Inflater { get; private set; }

		public ViewGroup Container { get; private set; }

		public Bundle SavedInstanceState { get; private set; }

		public MvxCreateViewParameters(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			SavedInstanceState = savedInstanceState;
			Container = container;
			Inflater = inflater;
		}
	}
}
namespace MvvmCross.Droid.Shared.Presenter
{
	public class FragmentHostRegistrationSettings
	{
		private readonly IEnumerable<Assembly> _assembliesToLookup;

		private readonly IMvxViewModelTypeFinder _viewModelTypeFinder;

		private readonly Dictionary<Type, IList<MvxFragmentAttribute>> _fragmentTypeToMvxFragmentAttributeMap;

		private Dictionary<Type, Type> _viewModelToFragmentTypeMap;

		private bool isInitialized;

		public FragmentHostRegistrationSettings(IEnumerable<Assembly> assembliesToLookup)
		{
			_assembliesToLookup = assembliesToLookup;
			_viewModelTypeFinder = Mvx.Resolve<IMvxViewModelTypeFinder>();
			_fragmentTypeToMvxFragmentAttributeMap = new Dictionary<Type, IList<MvxFragmentAttribute>>();
		}

		private void InitializeIfNeeded()
		{
			lock (this)
			{
				if (isInitialized)
				{
					return;
				}
				isInitialized = true;
				List<Type> list = (from x in _assembliesToLookup.SelectMany((Assembly x) => x.DefinedTypes)
					select x.AsType() into x
					where x.HasMvxFragmentAttribute()
					select x).ToList();
				foreach (Type item in list)
				{
					if (!_fragmentTypeToMvxFragmentAttributeMap.ContainsKey(item))
					{
						_fragmentTypeToMvxFragmentAttributeMap.Add(item, new List<MvxFragmentAttribute>());
					}
					foreach (MvxFragmentAttribute mvxFragmentAttribute in item.GetMvxFragmentAttributes())
					{
						_fragmentTypeToMvxFragmentAttributeMap[item].Add(mvxFragmentAttribute);
					}
				}
				_viewModelToFragmentTypeMap = list.ToDictionary(GetAssociatedViewModelType, (Type fragmentType) => fragmentType);
			}
		}

		private Type GetAssociatedViewModelType(Type fromFragmentType)
		{
			return _viewModelTypeFinder.FindTypeOrNull(fromFragmentType) ?? fromFragmentType.GetMvxFragmentAttributes().First().ViewModelType;
		}

		public virtual bool IsTypeRegisteredAsFragment(Type viewModelType)
		{
			InitializeIfNeeded();
			return _viewModelToFragmentTypeMap.ContainsKey(viewModelType);
		}

		public virtual bool IsActualHostValid(Type forViewModelType)
		{
			InitializeIfNeeded();
			Type activityViewModelType = GetCurrentActivityViewModelType();
			if (activityViewModelType == typeof(MvxNullViewModel))
			{
				return false;
			}
			return GetMvxFragmentAssociatedAttributes(forViewModelType).Any((MvxFragmentAttribute x) => x.ParentActivityViewModelType == activityViewModelType);
		}

		private Type GetCurrentActivityViewModelType()
		{
			Type type = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.GetType();
			return _viewModelTypeFinder.FindTypeOrNull(type);
		}

		public virtual Type GetFragmentHostViewModelType(Type forViewModelType)
		{
			InitializeIfNeeded();
			return GetMvxFragmentAssociatedAttributes(forViewModelType).ToList().First().ParentActivityViewModelType;
		}

		public virtual Type GetFragmentTypeAssociatedWith(Type viewModelType)
		{
			InitializeIfNeeded();
			return _viewModelToFragmentTypeMap[viewModelType];
		}

		private IList<MvxFragmentAttribute> GetMvxFragmentAssociatedAttributes(Type withFragmentViewModelType)
		{
			Type fragmentTypeAssociatedWith = GetFragmentTypeAssociatedWith(withFragmentViewModelType);
			return _fragmentTypeToMvxFragmentAttributeMap[fragmentTypeAssociatedWith];
		}

		public virtual MvxFragmentAttribute GetMvxFragmentAttributeAssociatedWithCurrentHost(Type fragmentViewModelType)
		{
			InitializeIfNeeded();
			Type currentActivityViewModelType = GetCurrentActivityViewModelType();
			Activity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
			IEnumerable<MvxFragmentAttribute> enumerable = from x in GetMvxFragmentAssociatedAttributes(fragmentViewModelType)
				where x.ParentActivityViewModelType == currentActivityViewModelType
				select x;
			MvxFragmentAttribute result = enumerable.FirstOrDefault();
			if (enumerable.Count() > 1)
			{
				foreach (MvxFragmentAttribute item in enumerable)
				{
					if (activity.FindViewById(item.FragmentContentId) != null)
					{
						result = item;
						break;
					}
				}
			}
			return result;
		}
	}
	public interface IMvxFragmentHost
	{
		bool Show(MvxViewModelRequest request, Bundle bundle, Type fragmentType, MvxFragmentAttribute fragmentAttribute);

		bool Close(IMvxViewModel viewModel);
	}
	public class MvxFragmentsPresenter : MvxAndroidViewPresenter
	{
		public const string ViewModelRequestBundleKey = "__mvxViewModelRequest";

		protected FragmentHostRegistrationSettings _fragmentHostRegistrationSettings;

		protected Lazy<IMvxNavigationSerializer> _lazyNavigationSerializerFactory;

		protected IMvxNavigationSerializer Serializer => _lazyNavigationSerializerFactory.Value;

		public MvxFragmentsPresenter(IEnumerable<Assembly> AndroidViewAssemblies)
		{
			_lazyNavigationSerializerFactory = new Lazy<IMvxNavigationSerializer>(Mvx.Resolve<IMvxNavigationSerializer>);
			_fragmentHostRegistrationSettings = new FragmentHostRegistrationSettings(AndroidViewAssemblies);
		}

		public sealed override void Show(MvxViewModelRequest request)
		{
			if (_fragmentHostRegistrationSettings.IsTypeRegisteredAsFragment(request.ViewModelType))
			{
				ShowFragment(request);
			}
			else
			{
				ShowActivity(request);
			}
		}

		protected virtual void ShowActivity(MvxViewModelRequest request, MvxViewModelRequest fragmentRequest = null)
		{
			if (fragmentRequest == null)
			{
				base.Show(request);
			}
			else
			{
				Show(request, fragmentRequest);
			}
		}

		public void Show(MvxViewModelRequest request, MvxViewModelRequest fragmentRequest)
		{
			Intent intent = CreateIntentForRequest(request);
			if (fragmentRequest != null)
			{
				string value = Mvx.Resolve<IMvxNavigationSerializer>().Serializer.SerializeObject(fragmentRequest);
				intent.PutExtra("__mvxViewModelRequest", value);
			}
			Show(intent);
		}

		protected virtual void ShowFragment(MvxViewModelRequest request)
		{
			Bundle bundle = new Bundle();
			string value = Serializer.Serializer.SerializeObject(request);
			bundle.PutString("__mvxViewModelRequest", value);
			if (!_fragmentHostRegistrationSettings.IsActualHostValid(request.ViewModelType))
			{
				MvxViewModelRequest defaultRequest = MvxViewModelRequest.GetDefaultRequest(_fragmentHostRegistrationSettings.GetFragmentHostViewModelType(request.ViewModelType));
				ShowActivity(defaultRequest, request);
			}
			else
			{
				MvxFragmentAttribute mvxFragmentAttributeAssociatedWithCurrentHost = _fragmentHostRegistrationSettings.GetMvxFragmentAttributeAssociatedWithCurrentHost(request.ViewModelType);
				Type fragmentTypeAssociatedWith = _fragmentHostRegistrationSettings.GetFragmentTypeAssociatedWith(request.ViewModelType);
				GetActualFragmentHost().Show(request, bundle, fragmentTypeAssociatedWith, mvxFragmentAttributeAssociatedWithCurrentHost);
			}
		}

		public sealed override void Close(IMvxViewModel viewModel)
		{
			if (_fragmentHostRegistrationSettings.IsTypeRegisteredAsFragment(viewModel.GetType()))
			{
				CloseFragment(viewModel);
			}
			else
			{
				CloseActivity(viewModel);
			}
		}

		protected virtual void CloseActivity(IMvxViewModel viewModel)
		{
			base.Close(viewModel);
		}

		protected virtual void CloseFragment(IMvxViewModel viewModel)
		{
			GetActualFragmentHost().Close(viewModel);
		}

		protected IMvxFragmentHost GetActualFragmentHost()
		{
			Activity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
			return (activity as IMvxFragmentHost) ?? throw new InvalidOperationException($"You are trying to close ViewModel associated with Fragment when currently top Activity ({activity.GetType()} does not implement IMvxFragmentHost interface!");
		}
	}
}
namespace MvvmCross.Droid.Shared.Fragments
{
	public interface IMvxFragmentView : IMvxBindingContextOwner, IMvxView, IMvxDataConsumer
	{
		string UniqueImmutableCacheTag { get; }
	}
	public interface IMvxFragmentView<TViewModel> : IMvxFragmentView, IMvxBindingContextOwner, IMvxView, IMvxDataConsumer, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
	}
	public class MvxSimpleLayoutInflaterHolder : IMvxLayoutInflaterHolder
	{
		public LayoutInflater LayoutInflater { get; private set; }

		public MvxSimpleLayoutInflaterHolder(LayoutInflater layoutInflater)
		{
			LayoutInflater = layoutInflater;
		}
	}
}
namespace MvvmCross.Droid.Shared.Fragments.EventSource
{
	public interface IMvxEventSourceFragment : IMvxDisposeSource
	{
		event EventHandler<MvxValueEventArgs<Activity>> AttachCalled;

		event EventHandler<MvxValueEventArgs<Bundle>> CreateWillBeCalled;

		event EventHandler<MvxValueEventArgs<Bundle>> CreateCalled;

		event EventHandler<MvxValueEventArgs<MvxCreateViewParameters>> CreateViewCalled;

		event EventHandler StartCalled;

		event EventHandler ResumeCalled;

		event EventHandler PauseCalled;

		event EventHandler StopCalled;

		event EventHandler DestroyViewCalled;

		event EventHandler DestroyCalled;

		event EventHandler DetachCalled;

		event EventHandler<MvxValueEventArgs<Bundle>> SaveInstanceStateCalled;
	}
}
namespace MvvmCross.Droid.Shared.Caching
{
	internal class FragmentPresenter
	{
	}
	public class DefaultFragmentCacheConfiguration : FragmentCacheConfiguration<SerializableMvxCachedFragmentInfo>
	{
	}
	public abstract class FragmentCacheConfiguration<TSerializableMvxCachedFragmentInfo> : IFragmentCacheConfiguration
	{
		private Dictionary<string, IMvxCachedFragmentInfo> _lookup;

		private const string SavedFragmentCacheConfiguration = "__mvxSavedFragmentCacheConfiguration";

		private const string SavedFragmentCacheConfigurationEnabledFragmentPoppedCallbackState = "__mvxSavedFragmentCacheConfigurationEnabledFragmentPoppedCallbackState";

		public bool EnableOnFragmentPoppedCallback { get; set; }

		public virtual MvxCachedFragmentInfoFactory MvxCachedFragmentInfoFactory { get; }

		public bool HasAnyFragmentsRegisteredToCache => _lookup.Any();

		protected FragmentCacheConfiguration()
		{
			_lookup = new Dictionary<string, IMvxCachedFragmentInfo>();
			EnableOnFragmentPoppedCallback = true;
			MvxCachedFragmentInfoFactory = new MvxCachedFragmentInfoFactory();
		}

		public bool RegisterFragmentToCache<TFragment, TViewModel>(string tag) where TFragment : IMvxFragmentView where TViewModel : IMvxViewModel
		{
			if (_lookup.ContainsKey(tag))
			{
				return false;
			}
			IMvxCachedFragmentInfo value = MvxCachedFragmentInfoFactory.CreateFragmentInfo(tag, typeof(TFragment), typeof(TViewModel));
			_lookup.Add(tag, value);
			return true;
		}

		public bool RegisterFragmentToCache(string tag, Type fragmentType, Type viewModelType, bool addToBackStack = false)
		{
			if (_lookup.ContainsKey(tag))
			{
				return false;
			}
			IMvxCachedFragmentInfo value = MvxCachedFragmentInfoFactory.CreateFragmentInfo(tag, fragmentType, viewModelType, cacheFragment: true, addToBackStack);
			_lookup.Add(tag, value);
			return true;
		}

		public bool TryGetValue(string registeredFragmentTag, out IMvxCachedFragmentInfo cachedFragmentInfo)
		{
			return _lookup.TryGetValue(registeredFragmentTag, out cachedFragmentInfo);
		}

		public virtual void RestoreCacheConfiguration(Bundle savedInstanceState, IMvxJsonConverter serializer)
		{
			if (savedInstanceState == null)
			{
				return;
			}
			EnableOnFragmentPoppedCallback = savedInstanceState.GetBoolean("__mvxSavedFragmentCacheConfigurationEnabledFragmentPoppedCallbackState", defaultValue: true);
			string empty = string.Empty;
			empty = ((Build.VERSION.SdkInt < BuildVersionCodes.HoneycombMr1) ? savedInstanceState.GetString("__mvxSavedFragmentCacheConfiguration") : savedInstanceState.GetString("__mvxSavedFragmentCacheConfiguration", string.Empty));
			if (!string.IsNullOrEmpty(empty))
			{
				Dictionary<string, TSerializableMvxCachedFragmentInfo> source = serializer.DeserializeObject<Dictionary<string, TSerializableMvxCachedFragmentInfo>>(empty);
				_lookup = source.ToDictionary((KeyValuePair<string, TSerializableMvxCachedFragmentInfo> x) => x.Key, (KeyValuePair<string, TSerializableMvxCachedFragmentInfo> keyValuePair) => MvxCachedFragmentInfoFactory.ConvertSerializableFragmentInfo(keyValuePair.Value as SerializableMvxCachedFragmentInfo));
			}
		}

		public virtual void SaveFragmentCacheConfigurationState(Bundle outState, IMvxJsonConverter serializer)
		{
			if (outState != null)
			{
				Dictionary<string, SerializableMvxCachedFragmentInfo> toSerialise = CreateMvxCachedFragmentInfosToSave();
				string value = serializer.SerializeObject(toSerialise);
				outState.PutString("__mvxSavedFragmentCacheConfiguration", value);
				outState.PutBoolean("__mvxSavedFragmentCacheConfigurationEnabledFragmentPoppedCallbackState", EnableOnFragmentPoppedCallback);
			}
		}

		private Dictionary<string, SerializableMvxCachedFragmentInfo> CreateMvxCachedFragmentInfosToSave()
		{
			return _lookup.ToDictionary((KeyValuePair<string, IMvxCachedFragmentInfo> x) => x.Key, (KeyValuePair<string, IMvxCachedFragmentInfo> keyValuePair) => MvxCachedFragmentInfoFactory.GetSerializableFragmentInfo(keyValuePair.Value));
		}
	}
	public interface IFragmentCacheableActivity
	{
		IFragmentCacheConfiguration FragmentCacheConfiguration { get; }
	}
	public interface IFragmentCacheConfiguration
	{
		bool EnableOnFragmentPoppedCallback { get; set; }

		MvxCachedFragmentInfoFactory MvxCachedFragmentInfoFactory { get; }

		bool HasAnyFragmentsRegisteredToCache { get; }

		bool RegisterFragmentToCache<TFragment, TViewModel>(string tag) where TFragment : IMvxFragmentView where TViewModel : IMvxViewModel;

		bool RegisterFragmentToCache(string tag, Type fragmentType, Type viewModelType, bool addToBackStack = false);

		bool TryGetValue(string registeredFragmentTag, out IMvxCachedFragmentInfo cachedFragmentInfo);

		void RestoreCacheConfiguration(Bundle savedInstanceState, IMvxJsonConverter serializer);

		void SaveFragmentCacheConfigurationState(Bundle outState, IMvxJsonConverter serializer);
	}
	public interface IMvxCachedFragmentInfo
	{
		string Tag { get; set; }

		Type FragmentType { get; set; }

		Type ViewModelType { get; set; }

		IMvxFragmentView CachedFragment { get; set; }

		bool CacheFragment { get; set; }

		int ContentId { get; set; }

		bool AddToBackStack { get; set; }
	}
	public interface IMvxCachedFragmentInfoFactory
	{
		IMvxCachedFragmentInfo CreateFragmentInfo(string tag, Type fragmentType, Type viewModelType, bool cacheFragment = true, bool addToBackstack = false);

		SerializableMvxCachedFragmentInfo GetSerializableFragmentInfo(IMvxCachedFragmentInfo objectToSerialize);

		IMvxCachedFragmentInfo ConvertSerializableFragmentInfo(SerializableMvxCachedFragmentInfo fromSerializableMvxCachedFragmentInfo);
	}
	public class MvxCachedFragmentInfo : IMvxCachedFragmentInfo
	{
		public string Tag { get; set; }

		public Type FragmentType { get; set; }

		public Type ViewModelType { get; set; }

		public IMvxFragmentView CachedFragment { get; set; }

		public bool CacheFragment { get; set; }

		public int ContentId { get; set; }

		public bool AddToBackStack { get; set; }

		public MvxCachedFragmentInfo(string tag, Type fragmentType, Type viewModelType, bool cacheFragment, bool addToBackstack)
		{
			Tag = tag;
			FragmentType = fragmentType;
			ViewModelType = viewModelType;
			CacheFragment = cacheFragment;
			AddToBackStack = addToBackstack;
		}
	}
	public class MvxCachedFragmentInfoFactory : IMvxCachedFragmentInfoFactory
	{
		public virtual IMvxCachedFragmentInfo CreateFragmentInfo(string tag, Type fragmentType, Type viewModelType, bool cacheFragment = true, bool addToBackstack = false)
		{
			if (!typeof(IMvxFragmentView).IsAssignableFrom(fragmentType))
			{
				throw new InvalidOperationException($"Registered fragment isn't an IMvxFragmentView. Received: {fragmentType}");
			}
			if (!typeof(IMvxViewModel).IsAssignableFrom(viewModelType))
			{
				throw new InvalidOperationException($"Registered view model isn't an IMvxViewModel. Received: {viewModelType}");
			}
			return new MvxCachedFragmentInfo(tag, fragmentType, viewModelType, cacheFragment, addToBackstack);
		}

		public virtual SerializableMvxCachedFragmentInfo GetSerializableFragmentInfo(IMvxCachedFragmentInfo objectToSerialize)
		{
			return new SerializableMvxCachedFragmentInfo
			{
				Tag = objectToSerialize.Tag,
				FragmentType = objectToSerialize.FragmentType,
				ViewModelType = objectToSerialize.ViewModelType,
				CacheFragment = objectToSerialize.CacheFragment,
				ContentId = objectToSerialize.ContentId,
				AddToBackStack = objectToSerialize.AddToBackStack
			};
		}

		public virtual IMvxCachedFragmentInfo ConvertSerializableFragmentInfo(SerializableMvxCachedFragmentInfo fromSerializableMvxCachedFragmentInfo)
		{
			return new MvxCachedFragmentInfo(fromSerializableMvxCachedFragmentInfo.Tag, fromSerializableMvxCachedFragmentInfo.FragmentType, fromSerializableMvxCachedFragmentInfo.ViewModelType, fromSerializableMvxCachedFragmentInfo.CacheFragment, fromSerializableMvxCachedFragmentInfo.AddToBackStack)
			{
				ContentId = fromSerializableMvxCachedFragmentInfo.ContentId
			};
		}
	}
	public class SerializableMvxCachedFragmentInfo
	{
		public string Tag { get; set; }

		public Type FragmentType { get; set; }

		public Type ViewModelType { get; set; }

		public bool CacheFragment { get; set; }

		public int ContentId { get; set; }

		public bool AddToBackStack { get; set; }

		public SerializableMvxCachedFragmentInfo()
		{
		}

		public SerializableMvxCachedFragmentInfo(SerializableMvxCachedFragmentInfo serializableMvxCachedFragmentInfoToClone)
		{
			Tag = serializableMvxCachedFragmentInfoToClone.Tag;
			FragmentType = serializableMvxCachedFragmentInfoToClone.FragmentType;
			ViewModelType = serializableMvxCachedFragmentInfoToClone.ViewModelType;
			CacheFragment = serializableMvxCachedFragmentInfoToClone.CacheFragment;
			ContentId = serializableMvxCachedFragmentInfoToClone.ContentId;
			AddToBackStack = serializableMvxCachedFragmentInfoToClone.AddToBackStack;
		}
	}
}
namespace MvvmCross.Droid.Shared.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class MvxFragmentAttribute : Attribute
	{
		public Type ViewModelType { get; set; }

		public bool IsCacheableFragment { get; set; } = true;

		public Type ParentActivityViewModelType { get; private set; }

		public int FragmentContentId { get; private set; }

		public bool AddToBackStack { get; set; }

		public MvxFragmentAttribute(Type parentActivityViewModelType, int fragmentContentId, bool addToBackStack = false)
		{
			ParentActivityViewModelType = parentActivityViewModelType;
			FragmentContentId = fragmentContentId;
			AddToBackStack = addToBackStack;
		}
	}
	public static class MvxFragmentAttributeExtensionMethods
	{
		public static bool HasMvxFragmentAttribute(this Type candidateType)
		{
			return candidateType.GetCustomAttributes(typeof(MvxFragmentAttribute), inherit: true).Length != 0;
		}

		public static IEnumerable<MvxFragmentAttribute> GetMvxFragmentAttributes(this Type fromFragmentType)
		{
			object[] customAttributes = fromFragmentType.GetCustomAttributes(typeof(MvxFragmentAttribute), inherit: true);
			if (!customAttributes.Any())
			{
				throw new InvalidOperationException(string.Format("Type does not have {0} attribute!", "MvxFragmentAttribute"));
			}
			return customAttributes.Cast<MvxFragmentAttribute>();
		}

		public static MvxFragmentAttribute GetMvxFragmentAttribute(this Type fromFragmentType, Type fragmentActivityParentType)
		{
			IEnumerable<MvxFragmentAttribute> mvxFragmentAttributes = fromFragmentType.GetMvxFragmentAttributes();
			Type activityViewModelType = GetActivityViewModelType(fragmentActivityParentType);
			return mvxFragmentAttributes.FirstOrDefault((MvxFragmentAttribute x) => x.ParentActivityViewModelType == activityViewModelType) ?? throw new InvalidOperationException($"Sorry but Fragment Type: {fromFragmentType} hasn't registered any Activity with ViewModel Type {fragmentActivityParentType}");
		}

		private static Type GetActivityViewModelType(Type activityType)
		{
			if (!Mvx.TryResolve<IMvxViewModelTypeFinder>(out var service))
			{
				MvxTrace.Trace("No view model type finder available - assuming we are looking for a splash screen - returning null");
				return typeof(MvxNullViewModel);
			}
			return service.FindTypeOrNull(activityType);
		}

		public static bool IsFragmentCacheable(this Type fragmentType, Type fragmentActivityParentType)
		{
			if (!fragmentType.HasMvxFragmentAttribute())
			{
				return false;
			}
			return fragmentType.GetMvxFragmentAttribute(fragmentActivityParentType).IsCacheableFragment;
		}

		public static Type GetViewModelType(this Type fragmentType)
		{
			if (!fragmentType.HasMvxFragmentAttribute())
			{
				return null;
			}
			return (from x in fragmentType.GetMvxFragmentAttributes()
				select x.ViewModelType).First();
		}
	}
}
