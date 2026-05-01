using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using Java.Lang.Reflect;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid.Binders;
using MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.ResourceHelpers;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Droid;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("MvvmCross.Binding.Droid.Resource", IsApplication = false)]
[assembly: AssemblyTitle("MvvmCross.Binding.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Binding.Droid
{
	public class MvxViewAssemblyBootstrapAction<TView> : IMvxBootstrapAction
	{
		public virtual void Run()
		{
			Mvx.CallbackWhenRegistered<IMvxTypeCache<View>>(RegisterViewTypes);
			Mvx.CallbackWhenRegistered<IMvxNamespaceListViewTypeResolver>(RegisterNamespace);
		}

		protected virtual void RegisterViewTypes()
		{
			Mvx.Resolve<IMvxTypeCache<View>>().AddAssembly(typeof(TView).Assembly);
		}

		protected virtual void RegisterNamespace()
		{
			Mvx.Resolve<IMvxNamespaceListViewTypeResolver>().Add(typeof(TView).Namespace);
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			public static int MvxBind;

			public static int MvxDropDownItemTemplate;

			public static int MvxGroupItemTemplate;

			public static int MvxItemTemplate;

			public static int MvxLang;

			public static int MvxSource;

			public static int MvxTemplate;

			static Attribute()
			{
				MvxBind = 2130771968;
				MvxDropDownItemTemplate = 2130771972;
				MvxGroupItemTemplate = 2130771973;
				MvxItemTemplate = 2130771971;
				MvxLang = 2130771969;
				MvxSource = 2130771974;
				MvxTemplate = 2130771970;
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class Id
		{
			public static int MvvmCrossTagId;

			public static int MvxBindingTagUnique;

			static Id()
			{
				MvvmCrossTagId = 2130837504;
				MvxBindingTagUnique = 2130837505;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Styleable
		{
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
				MvxBinding = new int[2] { 2130771968, 2130771969 };
				MvxBinding_MvxBind = 0;
				MvxBinding_MvxLang = 1;
				MvxControl = new int[1] { 2130771970 };
				MvxControl_MvxTemplate = 0;
				MvxExpandableListView = new int[1] { 2130771973 };
				MvxExpandableListView_MvxGroupItemTemplate = 0;
				MvxImageView = new int[1] { 2130771974 };
				MvxImageView_MvxSource = 0;
				MvxListView = new int[2] { 2130771971, 2130771972 };
				MvxListView_MvxDropDownItemTemplate = 1;
				MvxListView_MvxItemTemplate = 0;
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
	public class MvxAndroidBindingBuilder : MvxBindingBuilder
	{
		public override void DoRegistration()
		{
			InitializeAppResourceTypeFinder();
			InitializeBindingResources();
			InitializeLayoutInflation();
			base.DoRegistration();
		}

		protected virtual void InitializeLayoutInflation()
		{
			Mvx.RegisterSingleton(CreateLayoutInflaterFactoryFactory());
			Mvx.RegisterSingleton(CreateAndroidViewFactory());
			Mvx.RegisterSingleton(CreateAndroidViewBinderFactory());
		}

		protected virtual IMvxAndroidViewBinderFactory CreateAndroidViewBinderFactory()
		{
			return new MvxAndroidViewBinderFactory();
		}

		protected virtual IMvxLayoutInflaterHolderFactoryFactory CreateLayoutInflaterFactoryFactory()
		{
			return new MvxLayoutInflaterFactoryFactory();
		}

		protected virtual IMvxAndroidViewFactory CreateAndroidViewFactory()
		{
			return new MvxAndroidViewFactory();
		}

		protected virtual void InitializeBindingResources()
		{
			MvxAndroidBindingResource.Initialize();
		}

		protected virtual void InitializeAppResourceTypeFinder()
		{
			Mvx.RegisterSingleton(CreateAppResourceTypeFinder());
		}

		protected virtual IMvxAppResourceTypeFinder CreateAppResourceTypeFinder()
		{
			return new MvxAppResourceTypeFinder();
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories(registry);
			registry.RegisterCustomBindingFactory("Click", (View view) => new MvxViewClickBinding(view));
			registry.RegisterCustomBindingFactory("Text", (TextView textView) => new MvxTextViewTextTargetBinding(textView));
			registry.RegisterCustomBindingFactory("TextFormatted", (TextView textView) => new MvxTextViewTextFormattedTargetBinding(textView));
			registry.RegisterCustomBindingFactory("Hint", (TextView textView) => new MvxTextViewHintTargetBinding(textView));
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxAutoCompleteTextViewPartialTextTargetBinding), typeof(MvxAutoCompleteTextView), "PartialText");
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxAutoCompleteTextViewSelectedObjectTargetBinding), typeof(MvxAutoCompleteTextView), "SelectedObject");
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxCompoundButtonCheckedTargetBinding), typeof(CompoundButton), "Checked");
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxSeekBarProgressTargetBinding), typeof(SeekBar), "Progress");
			registry.RegisterCustomBindingFactory("Visible", (View view) => new MvxViewVisibleBinding(view));
			registry.RegisterCustomBindingFactory("Hidden", (View view) => new MvxViewHiddenBinding(view));
			registry.RegisterCustomBindingFactory("Bitmap", (ImageView imageView) => new MvxImageViewBitmapTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("Drawable", (ImageView imageView) => new MvxImageViewImageDrawableTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("DrawableId", (ImageView imageView) => new MvxImageViewDrawableTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("DrawableName", (ImageView imageView) => new MvxImageViewDrawableNameTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("ResourceName", (ImageView imageView) => new MvxImageViewResourceNameTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("AssetImagePath", (ImageView imageView) => new MvxImageViewImageTargetBinding(imageView));
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxSpinner spinner) => new MvxSpinnerSelectedItemBinding(spinner));
			registry.RegisterCustomBindingFactory("SelectedItemPosition", (AdapterView adapterView) => new MvxAdapterViewSelectedItemPositionTargetBinding(adapterView));
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxListView adapterView) => new MvxListViewSelectedItemTargetBinding(adapterView));
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxExpandableListView adapterView) => new MvxExpandableListViewSelectedItemTargetBinding(adapterView));
			registry.RegisterCustomBindingFactory("Rating", (RatingBar ratingBar) => new MvxRatingBarRatingTargetBinding(ratingBar));
			registry.RegisterCustomBindingFactory("LongClick", (View view) => new MvxViewLongClickBinding(view));
			registry.RegisterCustomBindingFactory("SelectedItem", (MvxRadioGroup radioGroup) => new MvxRadioGroupSelectedItemBinding(radioGroup));
			registry.RegisterCustomBindingFactory("TextFocus", (EditText view) => new MvxTextViewFocusTargetBinding(view));
			registry.RegisterCustomBindingFactory("Query", (SearchView search) => new MvxSearchViewQueryTextTargetBinding(search));
			registry.RegisterCustomBindingFactory("Value", (Preference preference) => new MvxPreferenceValueTargetBinding(preference));
			registry.RegisterCustomBindingFactory("Text", (EditTextPreference preference) => new MvxEditTextPreferenceTextTargetBinding(preference));
			registry.RegisterCustomBindingFactory("Value", (ListPreference preference) => new MvxListPreferenceTargetBinding(preference));
			registry.RegisterCustomBindingFactory("Checked", (TwoStatePreference preference) => new MvxTwoStatePreferenceCheckedTargetBinding(preference));
		}

		protected override void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
		{
			base.FillDefaultBindingNames(registry);
			registry.AddOrOverwrite(typeof(Button), "Click");
			registry.AddOrOverwrite(typeof(CheckBox), "Checked");
			registry.AddOrOverwrite(typeof(TextView), "Text");
			registry.AddOrOverwrite(typeof(MvxListView), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxLinearLayout), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxGridView), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxRelativeLayout), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxFrameLayout), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxTableLayout), "ItemsSource");
			registry.AddOrOverwrite(typeof(MvxFrameControl), "DataContext");
			registry.AddOrOverwrite(typeof(MvxImageView), "ImageUrl");
			registry.AddOrOverwrite(typeof(MvxDatePicker), "Value");
			registry.AddOrOverwrite(typeof(MvxTimePicker), "Value");
			registry.AddOrOverwrite(typeof(CompoundButton), "Checked");
			registry.AddOrOverwrite(typeof(SeekBar), "Progress");
			registry.AddOrOverwrite(typeof(IMvxImageHelper<Bitmap>), "ImageUrl");
			registry.AddOrOverwrite(typeof(SearchView), "Query");
		}

		protected override void RegisterPlatformSpecificComponents()
		{
			base.RegisterPlatformSpecificComponents();
			InitializeViewTypeResolver();
			InitializeContextStack();
		}

		protected virtual void InitializeContextStack()
		{
			Mvx.RegisterSingleton(CreateContextStack());
		}

		protected virtual IMvxBindingContextStack<IMvxAndroidBindingContext> CreateContextStack()
		{
			return new MvxAndroidBindingContextStack();
		}

		protected virtual void InitializeViewTypeResolver()
		{
			IMvxTypeCache<View> mvxTypeCache = CreateViewTypeCache();
			Mvx.RegisterSingleton(mvxTypeCache);
			MvxAxmlNameViewTypeResolver mvxAxmlNameViewTypeResolver = new MvxAxmlNameViewTypeResolver(mvxTypeCache);
			Mvx.RegisterSingleton((IMvxAxmlNameViewTypeResolver)mvxAxmlNameViewTypeResolver);
			MvxNamespaceListViewTypeResolver mvxNamespaceListViewTypeResolver = new MvxNamespaceListViewTypeResolver(mvxTypeCache);
			Mvx.RegisterSingleton((IMvxNamespaceListViewTypeResolver)mvxNamespaceListViewTypeResolver);
			MvxJustNameViewTypeResolver mvxJustNameViewTypeResolver = new MvxJustNameViewTypeResolver(mvxTypeCache);
			Mvx.RegisterSingleton((IMvxViewTypeResolver)new MvxCachedViewTypeResolver(new MvxCompositeViewTypeResolver(mvxAxmlNameViewTypeResolver, mvxNamespaceListViewTypeResolver, mvxJustNameViewTypeResolver)));
		}

		protected virtual IMvxTypeCache<View> CreateViewTypeCache()
		{
			return new MvxTypeCache<View>();
		}
	}
}
namespace MvvmCross.Binding.Droid.Views
{
	public interface IMvxAdapter : ISpinnerAdapter, IAdapter, IJavaObject, IDisposable, IListAdapter
	{
		int SimpleViewLayoutId { get; set; }

		[MvxSetToNullAfterBinding]
		IEnumerable ItemsSource { get; set; }

		int ItemTemplateId { get; set; }

		int DropDownItemTemplateId { get; set; }

		object GetRawItem(int position);

		int GetPosition(object value);
	}
	public interface IMvxAdapterWithChangedEvent : IMvxAdapter, ISpinnerAdapter, IAdapter, IJavaObject, IDisposable, IListAdapter
	{
		event EventHandler<NotifyCollectionChangedEventArgs> DataSetChanged;
	}
	public interface IMvxLayoutInflaterHolder
	{
		LayoutInflater LayoutInflater { get; }
	}
	public abstract class MvxBaseListItemView : FrameLayout, IMvxBindingContextOwner, ICheckable, IJavaObject, IDisposable
	{
		private readonly IMvxAndroidBindingContext _bindingContext;

		private object _cachedDataContext;

		private bool _isAttachedToWindow;

		private bool _checked;

		protected IMvxAndroidBindingContext AndroidBindingContext => _bindingContext;

		public IMvxBindingContext BindingContext
		{
			get
			{
				return _bindingContext;
			}
			set
			{
				throw new NotImplementedException("BindingContext is readonly in the list item");
			}
		}

		protected View Content => FirstChild;

		public object DataContext
		{
			get
			{
				return _bindingContext.DataContext;
			}
			set
			{
				if (_isAttachedToWindow)
				{
					_bindingContext.DataContext = value;
					return;
				}
				_cachedDataContext = value;
				if (_bindingContext.DataContext != null)
				{
					_bindingContext.DataContext = null;
				}
			}
		}

		protected virtual View FirstChild
		{
			get
			{
				if (ChildCount == 0)
				{
					return null;
				}
				return GetChildAt(0);
			}
		}

		protected virtual ICheckable ContentCheckable => FirstChild as ICheckable;

		public virtual bool Checked
		{
			get
			{
				return ContentCheckable?.Checked ?? _checked;
			}
			set
			{
				_checked = value;
				ICheckable contentCheckable = ContentCheckable;
				if (contentCheckable != null)
				{
					contentCheckable.Checked = value;
					return;
				}
				View firstChild = FirstChild;
				if (firstChild != null && base.Context.ApplicationInfo.TargetSdkVersion >= BuildVersionCodes.Honeycomb && Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				{
					firstChild.Activated = value;
				}
			}
		}

		protected MvxBaseListItemView(Context context, IMvxLayoutInflaterHolder layoutInflaterHolder, object dataContext)
			: base(context)
		{
			_bindingContext = new MvxAndroidBindingContext(context, layoutInflaterHolder, dataContext);
		}

		protected MvxBaseListItemView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			_isAttachedToWindow = true;
			if (_cachedDataContext != null && DataContext == null)
			{
				DataContext = _cachedDataContext;
			}
		}

		protected override void OnDetachedFromWindow()
		{
			_cachedDataContext = DataContext;
			DataContext = null;
			base.OnDetachedFromWindow();
			_isAttachedToWindow = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.ClearAllBindings();
				_cachedDataContext = null;
			}
			base.Dispose(disposing);
		}

		public virtual void Toggle()
		{
			ICheckable contentCheckable = ContentCheckable;
			if (contentCheckable == null)
			{
				_checked = !_checked;
			}
			else
			{
				contentCheckable.Toggle();
			}
		}
	}
	public class MvxContextWrapper : ContextWrapper
	{
		private LayoutInflater _inflater;

		private readonly IMvxBindingContextOwner _bindingContextOwner;

		public static ContextWrapper Wrap(Context @base, IMvxBindingContextOwner bindingContextOwner)
		{
			return new MvxContextWrapper(@base, bindingContextOwner);
		}

		protected MvxContextWrapper(Context context, IMvxBindingContextOwner bindingContextOwner)
			: base(context)
		{
			if (bindingContextOwner == null)
			{
				throw new InvalidOperationException("Wrapper can only be set on IMvxBindingContextOwner");
			}
			_bindingContextOwner = bindingContextOwner;
		}

		public override Java.Lang.Object GetSystemService(string name)
		{
			if (name.Equals("layout_inflater"))
			{
				return _inflater ?? (_inflater = new MvxLayoutInflater(LayoutInflater.From(BaseContext), this, null, cloned: false));
			}
			return base.GetSystemService(name);
		}
	}
	public class MvxExpandableListAdapter : MvxAdapter, IExpandableListAdapter, IJavaObject, IDisposable
	{
		private int _groupTemplateId;

		public int GroupTemplateId
		{
			get
			{
				return _groupTemplateId;
			}
			set
			{
				if (_groupTemplateId != value)
				{
					_groupTemplateId = value;
					if (ItemsSource != null)
					{
						NotifyDataSetChanged();
					}
				}
			}
		}

		public int GroupCount => Count;

		public MvxExpandableListAdapter(Context context)
			: base(context)
		{
		}

		public MvxExpandableListAdapter(Context context, IMvxAndroidBindingContext bindingContext)
			: base(context, bindingContext)
		{
		}

		protected MvxExpandableListAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public virtual void OnGroupExpanded(int groupPosition)
		{
		}

		public virtual void OnGroupCollapsed(int groupPosition)
		{
		}

		public virtual bool IsChildSelectable(int groupPosition, int childPosition)
		{
			return true;
		}

		public virtual View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			object rawGroup = GetRawGroup(groupPosition);
			return GetBindableView(convertView, rawGroup, GroupTemplateId);
		}

		public virtual long GetGroupId(int groupPosition)
		{
			return groupPosition;
		}

		public virtual Java.Lang.Object GetGroup(int groupPosition)
		{
			return null;
		}

		public virtual long GetCombinedGroupId(long groupId)
		{
			return (groupId & 0x7FFFFFFF) << 32;
		}

		public virtual long GetCombinedChildId(long groupId, long childId)
		{
			return -9223372036854775808L | ((groupId & 0x7FFFFFFF) << 32) | (childId & 0xFFFFFFFFu);
		}

		public virtual object GetRawItem(int groupPosition, int position)
		{
			return ((IEnumerable)GetRawGroup(groupPosition)).ElementAt(position);
		}

		public virtual object GetRawGroup(int groupPosition)
		{
			return GetRawItem(groupPosition);
		}

		public virtual View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			object rawItem = GetRawItem(groupPosition, childPosition);
			return GetBindableView(convertView, rawItem, ItemTemplateId);
		}

		public virtual int GetChildrenCount(int groupPosition)
		{
			return ((IEnumerable)GetRawGroup(groupPosition)).Count();
		}

		public virtual long GetChildId(int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public virtual Java.Lang.Object GetChild(int groupPosition, int childPosition)
		{
			return null;
		}

		public virtual Tuple<int, int> GetPositions(object childItem)
		{
			int count = Count;
			int num;
			for (num = 0; num < count; num++)
			{
				int position = ((IEnumerable)GetRawGroup(num)).GetPosition(childItem);
				if (position != -1)
				{
					return new Tuple<int, int>(num, position);
				}
				num++;
			}
			return null;
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxExpandableListView")]
	public class MvxExpandableListView : ExpandableListView
	{
		private bool _groupClickOverloaded;

		private bool _itemClickOverloaded;

		private bool _itemLongClickOverloaded;

		private ICommand _itemClick;

		private ICommand _itemLongClick;

		private ICommand _groupClick;

		private ICommand _groupLongClick;

		protected MvxExpandableListAdapter ThisAdapter => ExpandableListAdapter as MvxExpandableListAdapter;

		[MvxSetToNullAfterBinding]
		public virtual IEnumerable ItemsSource
		{
			get
			{
				return ThisAdapter.ItemsSource;
			}
			set
			{
				ThisAdapter.ItemsSource = value;
			}
		}

		public int ItemTemplateId
		{
			get
			{
				return ThisAdapter.ItemTemplateId;
			}
			set
			{
				ThisAdapter.ItemTemplateId = value;
			}
		}

		public int GroupTemplateId
		{
			get
			{
				return ThisAdapter.GroupTemplateId;
			}
			set
			{
				ThisAdapter.GroupTemplateId = value;
			}
		}

		public new ICommand ItemClick
		{
			get
			{
				return _itemClick;
			}
			set
			{
				_itemClick = value;
				if (_itemClick != null)
				{
					EnsureItemClickOverloaded();
				}
			}
		}

		public new ICommand ItemLongClick
		{
			get
			{
				return _itemLongClick;
			}
			set
			{
				_itemLongClick = value;
				if (_itemLongClick != null)
				{
					EnsureItemLongClickOverloaded();
				}
			}
		}

		public new ICommand GroupClick
		{
			get
			{
				return _groupClick;
			}
			set
			{
				_groupClick = value;
				if (_groupClick != null)
				{
					EnsureGroupClickOverloaded();
				}
			}
		}

		public ICommand GroupLongClick
		{
			get
			{
				return _groupLongClick;
			}
			set
			{
				_groupLongClick = value;
				if (_groupLongClick != null)
				{
					EnsureItemLongClickOverloaded();
				}
			}
		}

		public MvxExpandableListView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxExpandableListAdapter(context))
		{
		}

		public MvxExpandableListView(Context context, IAttributeSet attrs, MvxExpandableListAdapter adapter)
			: base(context, attrs)
		{
			if (adapter != null)
			{
				int groupTemplateId = MvxAttributeHelpers.ReadGroupItemTemplateId(context, attrs);
				int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
				SetAdapter(adapter);
				adapter.GroupTemplateId = groupTemplateId;
				adapter.ItemTemplateId = itemTemplateId;
			}
		}

		protected MvxExpandableListView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private void EnsureItemClickOverloaded()
		{
			if (!_itemClickOverloaded)
			{
				_itemClickOverloaded = true;
				base.ChildClick += ChildOnClick;
			}
		}

		private void ChildOnClick(object sender, ChildClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemClick, e.GroupPosition, e.ChildPosition);
		}

		private void EnsureGroupClickOverloaded()
		{
			if (!_groupClickOverloaded)
			{
				_groupClickOverloaded = true;
				base.GroupClick += GroupOnClick;
			}
		}

		private void GroupOnClick(object sender, GroupClickEventArgs e)
		{
			ExecuteCommandOnGroup(GroupClick, e.GroupPosition);
		}

		private void EnsureItemLongClickOverloaded()
		{
			if (!_itemLongClickOverloaded)
			{
				_itemLongClickOverloaded = true;
				base.ItemLongClick += ItemOnLongClick;
			}
		}

		private void ItemOnLongClick(object sender, ItemLongClickEventArgs e)
		{
			PackedPositionType packedPositionType = ExpandableListView.GetPackedPositionType(e.Id);
			long expandableListPosition = ((ExpandableListView)e.Parent).GetExpandableListPosition(e.Position);
			int packedPositionGroup = ExpandableListView.GetPackedPositionGroup(expandableListPosition);
			int packedPositionChild = ExpandableListView.GetPackedPositionChild(expandableListPosition);
			switch (packedPositionType)
			{
			case PackedPositionType.Child:
				ExecuteCommandOnItem(ItemLongClick, packedPositionGroup, packedPositionChild);
				break;
			case PackedPositionType.Group:
				ExecuteCommandOnGroup(GroupLongClick, packedPositionGroup);
				break;
			}
		}

		protected virtual void ExecuteCommandOnItem(ICommand command, int groupPosition, int position)
		{
			if (command != null)
			{
				object rawItem = ThisAdapter.GetRawItem(groupPosition, position);
				if (rawItem != null && command.CanExecute(rawItem))
				{
					command.Execute(rawItem);
				}
			}
		}

		protected virtual void ExecuteCommandOnGroup(ICommand command, int groupPosition)
		{
			if (command != null)
			{
				object rawGroup = ThisAdapter.GetRawGroup(groupPosition);
				if (rawGroup != null && command.CanExecute(rawGroup))
				{
					command.Execute(rawGroup);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.GroupClick -= GroupOnClick;
				base.ChildClick -= ChildOnClick;
				base.ItemLongClick -= ItemOnLongClick;
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxFrameControl")]
	public class MvxFrameControl : FrameLayout, IMvxBindingContextOwner
	{
		private readonly int _templateId;

		private readonly IMvxAndroidBindingContext _bindingContext;

		private object _cachedDataContext;

		private bool _isAttachedToWindow;

		private View _content;

		protected IMvxAndroidBindingContext AndroidBindingContext => _bindingContext;

		public IMvxBindingContext BindingContext
		{
			get
			{
				return _bindingContext;
			}
			set
			{
				throw new NotImplementedException("BindingContext is readonly in the list item");
			}
		}

		protected View Content
		{
			get
			{
				return _content;
			}
			set
			{
				_content = value;
				OnContentSet();
			}
		}

		[MvxSetToNullAfterBinding]
		public object DataContext
		{
			get
			{
				return _bindingContext.DataContext;
			}
			set
			{
				if (_isAttachedToWindow)
				{
					_bindingContext.DataContext = value;
					return;
				}
				_cachedDataContext = value;
				if (_bindingContext.DataContext != null)
				{
					_bindingContext.DataContext = null;
				}
			}
		}

		public MvxFrameControl(Context context, IAttributeSet attrs)
			: this(MvxAttributeHelpers.ReadTemplateId(context, attrs), context, attrs)
		{
		}

		public MvxFrameControl(int templateId, Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			_templateId = templateId;
			if (!(context is IMvxLayoutInflaterHolder))
			{
				throw Mvx.Exception("The owning Context for a MvxFrameControl must implement LayoutInflater");
			}
			_bindingContext = new MvxAndroidBindingContext(context, (IMvxLayoutInflaterHolder)context);
			this.DelayBind(delegate
			{
				if (Content == null && _templateId != 0)
				{
					Mvx.Trace("DataContext is {0}", DataContext?.ToString() ?? "Null");
					Content = _bindingContext.BindingInflate(_templateId, this);
				}
			});
		}

		protected MvxFrameControl(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.ClearAllBindings();
				_cachedDataContext = null;
			}
			base.Dispose(disposing);
		}

		protected override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			_isAttachedToWindow = true;
			if (_cachedDataContext != null && DataContext == null)
			{
				DataContext = _cachedDataContext;
			}
		}

		protected override void OnDetachedFromWindow()
		{
			_cachedDataContext = DataContext;
			DataContext = null;
			base.OnDetachedFromWindow();
			_isAttachedToWindow = false;
		}

		protected virtual void OnContentSet()
		{
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxDatePicker")]
	public class MvxDatePicker : DatePicker, DatePicker.IOnDateChangedListener, IJavaObject, IDisposable
	{
		private bool _initialized;

		public DateTime Value
		{
			get
			{
				return MvxJavaDateUtils.DateTimeFromJava(Year, Month, DayOfMonth);
			}
			set
			{
				int year = value.Year;
				int num = value.Month - 1;
				int day = value.Day;
				if (!_initialized)
				{
					Init(year, num, day, this);
					_initialized = true;
				}
				else if (Year != year || Month != num || DayOfMonth != day)
				{
					UpdateDate(year, num, day);
				}
			}
		}

		public event EventHandler ValueChanged;

		public MvxDatePicker(Context context)
			: base(context)
		{
		}

		public MvxDatePicker(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		protected MvxDatePicker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			this.ValueChanged?.Invoke(this, null);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxGridView")]
	public class MvxGridView : GridView
	{
		private ICommand _itemClick;

		private ICommand _itemLongClick;

		private bool _itemClickOverloaded;

		private bool _itemLongClickOverloaded;

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
					}
					base.Adapter = value;
					if (adapter != null)
					{
						adapter.ItemsSource = null;
					}
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

		public new ICommand ItemClick
		{
			get
			{
				return _itemClick;
			}
			set
			{
				_itemClick = value;
				if (_itemClick != null)
				{
					EnsureItemClickOverloaded();
				}
			}
		}

		public new ICommand ItemLongClick
		{
			get
			{
				return _itemLongClick;
			}
			set
			{
				_itemLongClick = value;
				if (_itemLongClick != null)
				{
					EnsureItemLongClickOverloaded();
				}
			}
		}

		public MvxGridView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapter(context))
		{
		}

		public MvxGridView(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs)
		{
			if (adapter != null)
			{
				int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
				adapter.ItemTemplateId = itemTemplateId;
				Adapter = adapter;
			}
		}

		protected MvxGridView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private void EnsureItemClickOverloaded()
		{
			if (!_itemClickOverloaded)
			{
				_itemClickOverloaded = true;
				base.ItemClick += ItemOnClick;
			}
		}

		private void ItemOnClick(object sender, ItemClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemClick, e.Position);
		}

		private void EnsureItemLongClickOverloaded()
		{
			if (!_itemLongClickOverloaded)
			{
				_itemLongClickOverloaded = true;
				base.ItemLongClick += ItemOnLongClick;
			}
		}

		private void ItemOnLongClick(object sender, ItemLongClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemLongClick, e.Position);
		}

		protected virtual void ExecuteCommandOnItem(ICommand command, int position)
		{
			if (command != null)
			{
				object rawItem = Adapter.GetRawItem(position);
				if (rawItem != null && command.CanExecute(rawItem))
				{
					command.Execute(rawItem);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.ItemClick -= ItemOnClick;
				base.ItemLongClick -= ItemOnLongClick;
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxAutoCompleteTextView")]
	public class MvxAutoCompleteTextView : AutoCompleteTextView
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
					if (adapter != null)
					{
						adapter.ItemsSource = null;
					}
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

		public MvxAutoCompleteTextView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxFilteringAdapter(context))
		{
		}

		public MvxAutoCompleteTextView(Context context, IAttributeSet attrs, MvxFilteringAdapter adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			adapter.ItemTemplateId = itemTemplateId;
			Adapter = adapter;
			base.ItemClick += OnItemClick;
			base.ItemSelected += OnItemSelected;
		}

		protected MvxAutoCompleteTextView(IntPtr javaReference, JniHandleOwnership transfer)
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
	[Register("mvvmcross.binding.droid.views.MvxLayoutInflater")]
	public class MvxLayoutInflater : LayoutInflater
	{
		public class MvxBindingVisitor
		{
			private static readonly Java.Lang.Boolean TheTruth = Java.Lang.Boolean.True;

			public IMvxLayoutInflaterHolderFactory Factory { get; set; }

			public View OnViewCreated(View view, Context context, IAttributeSet attrs)
			{
				if (Factory != null && view != null && view.GetTag(Resource.Id.MvvmCrossTagId) != TheTruth)
				{
					view = Factory.BindCreatedView(view, context, attrs);
					view.SetTag(Resource.Id.MvvmCrossTagId, TheTruth);
				}
				return view;
			}
		}

		private class DelegateFactory2 : IMvxLayoutInflaterFactory
		{
			private static readonly string Tag = "DelegateFactory2";

			private readonly IFactory2 _factory;

			private readonly MvxBindingVisitor _factoryPlaceholder;

			public DelegateFactory2(IFactory2 factoryToWrap, MvxBindingVisitor binder)
			{
				_factory = factoryToWrap;
				_factoryPlaceholder = binder;
			}

			public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace(Tag, "... OnCreateView ... {0}", name);
				}
				return _factoryPlaceholder.OnViewCreated(_factory.OnCreateView(parent, name, context, attrs), context, attrs);
			}
		}

		private class DelegateFactory1 : IMvxLayoutInflaterFactory
		{
			private static readonly string Tag = "DelegateFactory1";

			private readonly IFactory _factory;

			private readonly MvxBindingVisitor _factoryPlaceholder;

			public DelegateFactory1(IFactory factoryToWrap, MvxBindingVisitor bindingVisitor)
			{
				_factory = factoryToWrap;
				_factoryPlaceholder = bindingVisitor;
			}

			public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace(Tag, "... OnCreateView ... {0}", name);
				}
				return _factoryPlaceholder.OnViewCreated(_factory.OnCreateView(name, context, attrs), context, attrs);
			}
		}

		private class PrivateFactoryWrapper2 : Java.Lang.Object, IFactory2, IFactory, IJavaObject, IDisposable
		{
			private static readonly string Tag = "PrivateFactoryWrapper2";

			private readonly IFactory2 _factory2;

			private readonly MvxBindingVisitor _bindingVisitor;

			private readonly MvxLayoutInflater _inflater;

			internal PrivateFactoryWrapper2(IFactory2 factory2, MvxLayoutInflater inflater, MvxBindingVisitor bindingVisitor)
			{
				_factory2 = factory2;
				_inflater = inflater;
				_bindingVisitor = bindingVisitor;
			}

			public PrivateFactoryWrapper2(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			public View OnCreateView(string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace(Tag, "... OnCreateView 2 ... {0}", name);
				}
				return _bindingVisitor.OnViewCreated(_factory2.OnCreateView(name, context, attrs), context, attrs);
			}

			public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
			{
				if (Debug)
				{
					Mvx.TaggedTrace(Tag, "... OnCreateView 3 ... {0}", name);
				}
				return _bindingVisitor.OnViewCreated(_inflater.CreateCustomViewInternal(parent, _factory2.OnCreateView(parent, name, context, attrs), name, context, attrs), context, attrs);
			}
		}

		public static bool Debug = false;

		private static readonly string Tag = "MvxLayoutInflater";

		internal static BuildVersionCodes Sdk = Build.VERSION.SdkInt;

		private static readonly string[] ClassPrefixList = new string[3] { "android.widget.", "android.webkit.", "android.app." };

		private readonly MvxBindingVisitor _bindingVisitor;

		private IMvxAndroidViewFactory _androidViewFactory;

		private IMvxLayoutInflaterHolderFactoryFactory _layoutInflaterHolderFactoryFactory;

		private Field _constructorArgs;

		private bool _setPrivateFactory;

		protected IMvxAndroidViewFactory AndroidViewFactory => _androidViewFactory ?? (_androidViewFactory = Mvx.Resolve<IMvxAndroidViewFactory>());

		protected IMvxLayoutInflaterHolderFactoryFactory FactoryFactory => _layoutInflaterHolderFactoryFactory ?? (_layoutInflaterHolderFactoryFactory = Mvx.Resolve<IMvxLayoutInflaterHolderFactoryFactory>());

		public MvxLayoutInflater(Context context)
			: base(context)
		{
			_bindingVisitor = new MvxBindingVisitor();
			SetupLayoutFactories(cloned: false);
		}

		public MvxLayoutInflater(LayoutInflater original, Context newContext, MvxBindingVisitor bindingVisitor, bool cloned)
			: base(original, newContext)
		{
			_bindingVisitor = bindingVisitor ?? new MvxBindingVisitor();
			SetupLayoutFactories(cloned);
		}

		public MvxLayoutInflater(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		public override LayoutInflater CloneInContext(Context newContext)
		{
			return new MvxLayoutInflater(this, newContext, _bindingVisitor, cloned: true);
		}

		public override View Inflate(int resource, ViewGroup root, bool attachToRoot)
		{
			SetPrivateFactoryInternal();
			IMvxLayoutInflaterHolderFactory factory = _bindingVisitor.Factory;
			try
			{
				IMvxLayoutInflaterHolderFactory mvxLayoutInflaterHolderFactory = null;
				IMvxAndroidBindingContext mvxAndroidBindingContext = MvxAndroidBindingContextHelpers.Current();
				if (mvxAndroidBindingContext != null)
				{
					mvxLayoutInflaterHolderFactory = FactoryFactory.Create(mvxAndroidBindingContext.DataContext);
					if (mvxLayoutInflaterHolderFactory != null)
					{
						_bindingVisitor.Factory = mvxLayoutInflaterHolderFactory;
					}
				}
				View view = base.Inflate(resource, root, attachToRoot);
				if (mvxAndroidBindingContext != null && mvxLayoutInflaterHolderFactory != null)
				{
					mvxAndroidBindingContext.RegisterBindingsWithClearKey(view, mvxLayoutInflaterHolderFactory.CreatedBindings);
				}
				return view;
			}
			finally
			{
				_bindingVisitor.Factory = factory;
			}
		}

		protected override View OnCreateView(View parent, string name, IAttributeSet attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace(Tag, "... OnCreateView 3 ... {0}", name);
			}
			return _bindingVisitor.OnViewCreated(base.OnCreateView(parent, name, attrs), Context, attrs);
		}

		protected override View OnCreateView(string name, IAttributeSet attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace(Tag, "... OnCreateView 2 ... {0}", name);
			}
			View view = AndroidViewFactory.CreateView(null, name, Context, attrs) ?? PhoneLayoutInflaterOnCreateView(name, attrs) ?? base.OnCreateView(name, attrs);
			return _bindingVisitor.OnViewCreated(view, Context, attrs);
		}

		private View PhoneLayoutInflaterOnCreateView(string name, IAttributeSet attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace(Tag, "... PhoneLayoutInflaterOnCreateView ... {0}", name);
			}
			string[] classPrefixList = ClassPrefixList;
			foreach (string prefix in classPrefixList)
			{
				try
				{
					return CreateView(name, prefix, attrs);
				}
				catch (ClassNotFoundException)
				{
				}
			}
			return null;
		}

		[Export]
		public void setFactory(IFactory factory)
		{
			if (!(factory is MvxLayoutInflaterCompat.FactoryWrapper))
			{
				base.Factory = new MvxLayoutInflaterCompat.FactoryWrapper(new DelegateFactory1(factory, _bindingVisitor));
			}
			else
			{
				base.Factory = factory;
			}
		}

		[Export]
		public void setFactory2(IFactory2 factory2)
		{
			if (!(factory2 is MvxLayoutInflaterCompat.FactoryWrapper2))
			{
				base.Factory2 = new MvxLayoutInflaterCompat.FactoryWrapper2(new DelegateFactory2(factory2, _bindingVisitor));
			}
			else
			{
				base.Factory2 = factory2;
			}
		}

		private void SetupLayoutFactories(bool cloned)
		{
			if (!cloned)
			{
				if (Sdk > BuildVersionCodes.Honeycomb && base.Factory2 != null && !(base.Factory2 is MvxLayoutInflaterCompat.FactoryWrapper2))
				{
					MvxLayoutInflaterCompat.SetFactory(this, new DelegateFactory2(base.Factory2, _bindingVisitor));
				}
				if (base.Factory != null && !(base.Factory is MvxLayoutInflaterCompat.FactoryWrapper))
				{
					MvxLayoutInflaterCompat.SetFactory(this, new DelegateFactory1(base.Factory, _bindingVisitor));
				}
			}
		}

		private void SetPrivateFactoryInternal()
		{
			if (_setPrivateFactory || Build.VERSION.SdkInt < BuildVersionCodes.Honeycomb)
			{
				return;
			}
			if (!(Context is IFactory2))
			{
				_setPrivateFactory = true;
				return;
			}
			Method method = Class.FromType(typeof(LayoutInflater)).GetMethod("setPrivateFactory", Class.FromType(typeof(IFactory2)));
			if (method != null)
			{
				try
				{
					method.Accessible = true;
					method.Invoke(this, new PrivateFactoryWrapper2((IFactory2)Context, this, _bindingVisitor));
				}
				catch (Java.Lang.Exception ex)
				{
					Mvx.Warning("Cannot invoke LayoutInflater.setPrivateFactory :\n{0}", ex.StackTrace);
				}
			}
			_setPrivateFactory = true;
		}

		protected View CreateCustomViewInternal(View parent, View view, string name, Context viewContext, IAttributeSet attrs)
		{
			if (Debug)
			{
				Mvx.TaggedTrace(Tag, "... CreateCustomViewInternal ... {0}", name);
			}
			if (view == null && name.IndexOf('.') > -1)
			{
				if (!name.StartsWith("com.android.internal."))
				{
					view = AndroidViewFactory.CreateView(parent, name, viewContext, attrs);
				}
				if (view == null)
				{
					if (_constructorArgs == null)
					{
						Class obj = Class.FromType(typeof(LayoutInflater));
						_constructorArgs = obj.GetDeclaredField("mConstructorArgs");
						_constructorArgs.Accessible = true;
					}
					Java.Lang.Object[] array = (Java.Lang.Object[])_constructorArgs.Get(this);
					Java.Lang.Object obj2 = array[0];
					array[0] = viewContext;
					_constructorArgs.Set(this, array);
					try
					{
						view = CreateView(name, null, attrs);
					}
					catch (ClassNotFoundException)
					{
					}
					finally
					{
						array[0] = obj2;
						_constructorArgs.Set(this, array);
					}
				}
			}
			return view;
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxRadioGroup")]
	public class MvxRadioGroup : RadioGroup, IMvxWithChangeAdapter
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
				else
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
				if (adapter != null)
				{
					adapter.ItemsSource = null;
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

		public MvxRadioGroup(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxRadioGroup(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
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

		protected MvxRadioGroup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewAdded(object sender, ChildViewAddedEventArgs args)
		{
			if ((args.Child as MvxListItemView)?.GetChildAt(0) is RadioButton radioButton)
			{
				if (radioButton.Id == -1)
				{
					radioButton.Id = GenerateViewId();
				}
				radioButton.CheckedChange += OnRadioButtonCheckedChange;
			}
		}

		private void OnRadioButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
		{
			if (sender is RadioButton radioButton)
			{
				Check(radioButton.Id);
			}
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
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

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_adapter != null)
				{
					_adapter.DataSetChanged -= AdapterOnDataSetChanged;
				}
				base.ChildViewAdded -= OnChildViewAdded;
				base.ChildViewRemoved -= OnChildViewRemoved;
				int childCount = ChildCount;
				for (int i = 0; i < childCount; i++)
				{
					if (GetChildAt(i) is RadioButton radioButton)
					{
						radioButton.CheckedChange -= OnRadioButtonCheckedChange;
					}
				}
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxSpinner")]
	public class MvxSpinner : Spinner
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
					if (adapter != null)
					{
						adapter.ItemsSource = null;
					}
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

		public MvxSpinner(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapter(context)
			{
				SimpleViewLayoutId = 17367050
			})
		{
		}

		public MvxSpinner(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			int dropDownItemTemplateId = MvxAttributeHelpers.ReadDropDownListItemTemplateId(context, attrs);
			adapter.ItemTemplateId = itemTemplateId;
			adapter.DropDownItemTemplateId = dropDownItemTemplateId;
			Adapter = adapter;
			base.ItemSelected += OnItemSelected;
		}

		protected MvxSpinner(IntPtr javaReference, JniHandleOwnership transfer)
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
			if (disposing)
			{
				base.ItemSelected -= OnItemSelected;
			}
			base.Dispose(disposing);
		}
	}
	public class MvxFilteringAdapter : MvxAdapter, IFilterable, IJavaObject, IDisposable
	{
		private class MyFilter : Filter
		{
			private readonly MvxFilteringAdapter _owner;

			public MyFilter(MvxFilteringAdapter owner)
			{
				_owner = owner;
			}

			protected override FilterResults PerformFiltering(ICharSequence constraint)
			{
				string constraintAndWaitForDataChange = ((constraint == null) ? string.Empty : constraint.ToString());
				int count = _owner.SetConstraintAndWaitForDataChange(constraintAndWaitForDataChange);
				return new FilterResults
				{
					Count = count
				};
			}

			protected override void PublishResults(ICharSequence constraint, FilterResults results)
			{
				_owner.NotifyDataSetInvalidated();
			}

			public override ICharSequence ConvertResultToStringFormatted(Java.Lang.Object resultValue)
			{
				if (!(resultValue is MvxJavaContainer mvxJavaContainer))
				{
					return base.ConvertResultToStringFormatted(resultValue);
				}
				return new Java.Lang.String(mvxJavaContainer.Object.ToString());
			}
		}

		private string _partialText;

		private readonly ManualResetEvent _dataChangedEvent = new ManualResetEvent(initialState: false);

		private MvxReplaceableJavaContainer _javaContainer;

		public string PartialText
		{
			get
			{
				return _partialText;
			}
			private set
			{
				_partialText = value;
				FireConstraintChanged();
			}
		}

		public bool ReturnSingleObjectFromGetItem { get; set; }

		public Filter Filter { get; set; }

		public event EventHandler PartialTextChanged;

		private int SetConstraintAndWaitForDataChange(string newConstraint)
		{
			MvxTrace.Trace("Wait starting for {0}", newConstraint);
			_dataChangedEvent.Reset();
			PartialText = newConstraint;
			_dataChangedEvent.WaitOne();
			MvxTrace.Trace("Wait finished with {1} items for {0}", newConstraint, Count);
			return Count;
		}

		private void FireConstraintChanged()
		{
			(base.Context as Activity)?.RunOnUiThread(delegate
			{
				this.PartialTextChanged?.Invoke(this, EventArgs.Empty);
			});
		}

		public override void NotifyDataSetChanged()
		{
			_dataChangedEvent.Set();
			base.NotifyDataSetChanged();
		}

		public MvxFilteringAdapter(Context context)
			: base(context)
		{
			ReturnSingleObjectFromGetItem = true;
			Filter = new MyFilter(this);
		}

		protected MvxFilteringAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override Java.Lang.Object GetItem(int position)
		{
			if (ReturnSingleObjectFromGetItem)
			{
				if (_javaContainer == null)
				{
					_javaContainer = new MvxReplaceableJavaContainer();
				}
				_javaContainer.Object = GetRawItem(position);
				return _javaContainer;
			}
			return base.GetItem(position);
		}
	}
	public interface IMvxListItemView : IMvxDataConsumer
	{
		int TemplateId { get; }
	}
	[Register("mvvmcross.binding.droid.views.MvxLinearLayout")]
	public class MvxLinearLayout : LinearLayout, IMvxWithChangeAdapter
	{
		private IMvxAdapterWithChangedEvent _adapter;

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
				else
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
				if (adapter != null)
				{
					adapter.ItemsSource = null;
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

		public MvxLinearLayout(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxLinearLayout(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			if (adapter != null)
			{
				Adapter = adapter;
				Adapter.ItemTemplateId = itemTemplateId;
			}
			base.ChildViewRemoved += OnChildViewRemoved;
		}

		protected MvxLinearLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_adapter != null)
				{
					_adapter.DataSetChanged -= AdapterOnDataSetChanged;
				}
				base.ChildViewRemoved -= OnChildViewRemoved;
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxListItemView")]
	public class MvxListItemView : MvxBaseListItemView, IMvxListItemView, IMvxDataConsumer
	{
		public int TemplateId { get; }

		public MvxListItemView(Context context, IMvxLayoutInflaterHolder layoutInflaterHolder, object dataContext, int templateId)
			: base(context, layoutInflaterHolder, dataContext)
		{
			TemplateId = templateId;
			base.AndroidBindingContext.BindingInflate(templateId, this);
		}

		protected MvxListItemView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxListView")]
	public class MvxListView : ListView
	{
		private bool _itemClickOverloaded;

		private bool _itemLongClickOverloaded;

		private ICommand _itemClick;

		private ICommand _itemLongClick;

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
					if (value != null && adapter != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateId = adapter.ItemTemplateId;
					}
					base.Adapter = value;
					if (adapter != null)
					{
						adapter.ItemsSource = null;
					}
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

		public new ICommand ItemClick
		{
			get
			{
				return _itemClick;
			}
			set
			{
				_itemClick = value;
				if (_itemClick != null)
				{
					EnsureItemClickOverloaded();
				}
			}
		}

		public new ICommand ItemLongClick
		{
			get
			{
				return _itemLongClick;
			}
			set
			{
				_itemLongClick = value;
				if (_itemLongClick != null)
				{
					EnsureItemLongClickOverloaded();
				}
			}
		}

		public MvxListView(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapter(context))
		{
		}

		public MvxListView(Context context, IAttributeSet attrs, IMvxAdapter adapter)
			: base(context, attrs)
		{
			if (adapter != null)
			{
				int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
				adapter.ItemTemplateId = itemTemplateId;
				Adapter = adapter;
			}
		}

		protected MvxListView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private void EnsureItemClickOverloaded()
		{
			if (!_itemClickOverloaded)
			{
				_itemClickOverloaded = true;
				base.ItemClick += OnItemClick;
			}
		}

		private void EnsureItemLongClickOverloaded()
		{
			if (!_itemLongClickOverloaded)
			{
				_itemLongClickOverloaded = true;
				base.ItemLongClick += OnItemLongClick;
			}
		}

		protected virtual void ExecuteCommandOnItem(ICommand command, int position)
		{
			if (command != null)
			{
				object rawItem = Adapter.GetRawItem(position);
				if (rawItem != null && command.CanExecute(rawItem))
				{
					command.Execute(rawItem);
				}
			}
		}

		private void OnItemClick(object sender, ItemClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemClick, e.Position);
		}

		private void OnItemLongClick(object sender, ItemLongClickEventArgs e)
		{
			ExecuteCommandOnItem(ItemLongClick, e.Position);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.ItemLongClick -= OnItemLongClick;
				base.ItemClick -= OnItemClick;
			}
			base.Dispose(disposing);
		}
	}
	public class MvxAdapter : BaseAdapter, IMvxAdapter, ISpinnerAdapter, IAdapter, IJavaObject, IDisposable, IListAdapter
	{
		private int _itemTemplateId;

		private int _dropDownItemTemplateId;

		private IEnumerable _itemsSource;

		private IDisposable _subscription;

		private int _currentSimpleId;

		private ViewGroup _currentParent;

		protected Context Context { get; }

		protected IMvxAndroidBindingContext BindingContext { get; }

		public int SimpleViewLayoutId { get; set; }

		public int SimpleDropDownViewLayoutId { get; set; }

		public bool ReloadOnAllItemsSourceSets { get; set; }

		[MvxSetToNullAfterBinding]
		public virtual IEnumerable ItemsSource
		{
			get
			{
				return _itemsSource;
			}
			set
			{
				SetItemsSource(value);
			}
		}

		public virtual int ItemTemplateId
		{
			get
			{
				return _itemTemplateId;
			}
			set
			{
				if (_itemTemplateId != value)
				{
					_itemTemplateId = value;
					if (_itemsSource != null)
					{
						NotifyDataSetChanged();
					}
				}
			}
		}

		public virtual int DropDownItemTemplateId
		{
			get
			{
				return _dropDownItemTemplateId;
			}
			set
			{
				if (_dropDownItemTemplateId != value)
				{
					_dropDownItemTemplateId = value;
					if (_itemsSource != null)
					{
						NotifyDataSetChanged();
					}
				}
			}
		}

		public override int Count => _itemsSource.Count();

		public MvxAdapter(Context context)
			: this(context, MvxAndroidBindingContextHelpers.Current())
		{
		}

		public MvxAdapter(Context context, IMvxAndroidBindingContext bindingContext)
		{
			Context = context;
			BindingContext = bindingContext;
			if (BindingContext == null)
			{
				throw new MvxException("bindingContext is null during MvxAdapter creation - Adapter's should only be created when a specific binding context has been placed on the stack");
			}
			SimpleViewLayoutId = 17367043;
			SimpleDropDownViewLayoutId = 17367049;
		}

		protected MvxAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected virtual void SetItemsSource(IEnumerable value)
		{
			if (_itemsSource != value || ReloadOnAllItemsSourceSets)
			{
				if (_subscription != null)
				{
					_subscription.Dispose();
					_subscription = null;
				}
				_itemsSource = value;
				if (_itemsSource != null && !(_itemsSource is IList))
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Warning, "You are currently binding to IEnumerable - this can be inefficient, especially for large collections. Binding to IList is more efficient.");
				}
				if (_itemsSource is INotifyCollectionChanged source)
				{
					_subscription = source.WeakSubscribe(OnItemsSourceCollectionChanged);
				}
				NotifyDataSetChanged();
			}
		}

		protected virtual void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyDataSetChanged(e);
		}

		public virtual void NotifyDataSetChanged(NotifyCollectionChangedEventArgs e)
		{
			RealNotifyDataSetChanged();
		}

		public override void NotifyDataSetChanged()
		{
			RealNotifyDataSetChanged();
		}

		protected virtual void RealNotifyDataSetChanged()
		{
			try
			{
				base.NotifyDataSetChanged();
			}
			catch (System.Exception exception)
			{
				Mvx.Warning("Exception masked during Adapter RealNotifyDataSetChanged {0}. Are you trying to update your collection from a background task? See http://goo.gl/0nW0L6", exception.ToLongString());
			}
		}

		public virtual int GetPosition(object item)
		{
			return _itemsSource.GetPosition(item);
		}

		public virtual object GetRawItem(int position)
		{
			return _itemsSource.ElementAt(position);
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetDropDownView(int position, View convertView, ViewGroup parent)
		{
			_currentSimpleId = SimpleDropDownViewLayoutId;
			_currentParent = parent;
			View view = GetView(position, convertView, parent, DropDownItemTemplateId);
			_currentParent = null;
			return view;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			_currentSimpleId = SimpleViewLayoutId;
			_currentParent = parent;
			View view = GetView(position, convertView, parent, ItemTemplateId);
			_currentParent = null;
			return view;
		}

		protected virtual View GetView(int position, View convertView, ViewGroup parent, int templateId)
		{
			if (_itemsSource == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "GetView called when ItemsSource is null");
				return null;
			}
			object rawItem = GetRawItem(position);
			return GetBindableView(convertView, rawItem, templateId);
		}

		protected virtual View GetSimpleView(View convertView, object dataContext)
		{
			if (convertView == null)
			{
				convertView = CreateSimpleView(dataContext);
			}
			else
			{
				BindSimpleView(convertView, dataContext);
			}
			return convertView;
		}

		protected virtual void BindSimpleView(View convertView, object dataContext)
		{
			if (convertView is TextView textView)
			{
				textView.Text = (dataContext ?? string.Empty).ToString();
			}
		}

		protected virtual View CreateSimpleView(object dataContext)
		{
			View view = BindingContext.BindingInflate(_currentSimpleId, _currentParent, attachToParent: false);
			BindSimpleView(view, dataContext);
			return view;
		}

		protected virtual View GetBindableView(View convertView, object dataContext)
		{
			return GetBindableView(convertView, dataContext, ItemTemplateId);
		}

		protected virtual View GetBindableView(View convertView, object dataContext, int templateId)
		{
			if (templateId == 0)
			{
				return GetSimpleView(convertView, dataContext);
			}
			IMvxListItemView mvxListItemView = convertView as IMvxListItemView;
			if (mvxListItemView != null && mvxListItemView.TemplateId != templateId)
			{
				mvxListItemView = null;
			}
			if (mvxListItemView == null)
			{
				mvxListItemView = CreateBindableView(dataContext, templateId);
			}
			else
			{
				BindBindableView(dataContext, mvxListItemView);
			}
			return mvxListItemView as View;
		}

		protected virtual void BindBindableView(object source, IMvxListItemView viewToUse)
		{
			viewToUse.DataContext = source;
		}

		protected virtual IMvxListItemView CreateBindableView(object dataContext, int templateId)
		{
			return new MvxListItemView(Context, BindingContext.LayoutInflaterHolder, dataContext, templateId);
		}
	}
	public class MvxAdapter<TItem> : MvxAdapter where TItem : class
	{
		[MvxSetToNullAfterBinding]
		public new IEnumerable<TItem> ItemsSource
		{
			get
			{
				return base.ItemsSource as IEnumerable<TItem>;
			}
			set
			{
				base.ItemsSource = value;
			}
		}

		public MvxAdapter(Context context)
			: base(context, MvxAndroidBindingContextHelpers.Current())
		{
		}

		public MvxAdapter(Context context, IMvxAndroidBindingContext bindingContext)
			: base(context, bindingContext)
		{
		}

		public MvxAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	public class MvxAdapterWithChangedEvent : MvxAdapter, IMvxAdapterWithChangedEvent, IMvxAdapter, ISpinnerAdapter, IAdapter, IJavaObject, IDisposable, IListAdapter
	{
		public event EventHandler<NotifyCollectionChangedEventArgs> DataSetChanged;

		public MvxAdapterWithChangedEvent(Context context)
			: base(context)
		{
		}

		protected MvxAdapterWithChangedEvent(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override void NotifyDataSetChanged()
		{
			NotifyDataSetChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public override void NotifyDataSetChanged(NotifyCollectionChangedEventArgs e)
		{
			base.NotifyDataSetChanged(e);
			this.DataSetChanged?.Invoke(this, e);
		}
	}
	public static class MvxAttributeHelpers
	{
		public static int ReadDropDownListItemTemplateId(Context context, IAttributeSet attrs)
		{
			return ReadAttributeValue(context, attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.ListViewStylableGroupId, MvxSingleton<IMvxAndroidBindingResource>.Instance.DropDownListItemTemplateId);
		}

		public static int ReadListItemTemplateId(Context context, IAttributeSet attrs)
		{
			return ReadAttributeValue(context, attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.ListViewStylableGroupId, MvxSingleton<IMvxAndroidBindingResource>.Instance.ListItemTemplateId);
		}

		public static int ReadTemplateId(Context context, IAttributeSet attrs)
		{
			return ReadAttributeValue(context, attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.ControlStylableGroupId, MvxSingleton<IMvxAndroidBindingResource>.Instance.TemplateId);
		}

		public static int ReadGroupItemTemplateId(Context context, IAttributeSet attrs)
		{
			return ReadAttributeValue(context, attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.ExpandableListViewStylableGroupId, MvxSingleton<IMvxAndroidBindingResource>.Instance.GroupItemTemplateId);
		}

		public static int ReadAttributeValue(Context context, IAttributeSet attrs, int[] groupId, int requiredAttributeId)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, groupId);
			try
			{
				int indexCount = typedArray.IndexCount;
				for (int i = 0; i < indexCount; i++)
				{
					int index = typedArray.GetIndex(i);
					if (index == requiredAttributeId)
					{
						return typedArray.GetResourceId(index, 0);
					}
				}
				return 0;
			}
			finally
			{
				typedArray.Recycle();
			}
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxImageView")]
	public class MvxImageView : ImageView
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

		public MvxImageView(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init(context, attrs);
		}

		public MvxImageView(Context context, IAttributeSet attrs)
			: this(context, attrs, 0)
		{
		}

		public MvxImageView(Context context)
			: this(context, null)
		{
		}

		protected MvxImageView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _imageHelper != null)
			{
				_imageHelper.ImageChanged -= ImageHelperOnImageChanged;
				_imageHelper?.Dispose();
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

		private void Init(Context context, IAttributeSet attrs)
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

		public override void SetImageBitmap(Bitmap bm)
		{
			if (base.Handle != IntPtr.Zero && (bm == null || (!(bm.Handle == IntPtr.Zero) && !bm.IsRecycled)))
			{
				base.SetImageBitmap(bm);
			}
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxTimePicker")]
	public class MvxTimePicker : TimePicker, TimePicker.IOnTimeChangedListener, IJavaObject, IDisposable
	{
		private bool _initialized;

		public TimeSpan Value
		{
			get
			{
				int hours = CurrentHour.IntValue();
				int minutes = CurrentMinute.IntValue();
				return new TimeSpan(hours, minutes, 0);
			}
			set
			{
				Integer integer = new Integer(value.Hours);
				Integer integer2 = new Integer(value.Minutes);
				if (!_initialized)
				{
					SetOnTimeChangedListener(this);
					_initialized = true;
				}
				if (CurrentHour != integer)
				{
					CurrentHour = integer;
				}
				if (CurrentMinute != integer2)
				{
					CurrentMinute = integer2;
				}
			}
		}

		public event EventHandler ValueChanged;

		public MvxTimePicker(Context context)
			: base(context)
		{
		}

		public MvxTimePicker(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		protected MvxTimePicker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void OnTimeChanged(TimePicker view, int hourOfDay, int minute)
		{
			this.ValueChanged?.Invoke(this, null);
		}
	}
	public static class MvxViewGroupExtensions
	{
		public static void UpdateDataSetFromChange<T>(this T viewGroup, object sender, NotifyCollectionChangedEventArgs eventArgs) where T : ViewGroup, IMvxWithChangeAdapter
		{
			switch (eventArgs.Action)
			{
			case NotifyCollectionChangedAction.Add:
				viewGroup.Add(viewGroup.Adapter, eventArgs.NewStartingIndex, eventArgs.NewItems.Count);
				break;
			case NotifyCollectionChangedAction.Remove:
				viewGroup.Remove(viewGroup.Adapter, eventArgs.OldStartingIndex, eventArgs.OldItems.Count);
				break;
			case NotifyCollectionChangedAction.Replace:
				if (eventArgs.NewItems.Count != eventArgs.OldItems.Count)
				{
					viewGroup.Refill(viewGroup.Adapter);
				}
				else
				{
					viewGroup.Replace(viewGroup.Adapter, eventArgs.NewStartingIndex, eventArgs.NewItems.Count);
				}
				break;
			case NotifyCollectionChangedAction.Move:
				viewGroup.Refill(viewGroup.Adapter);
				break;
			case NotifyCollectionChangedAction.Reset:
				viewGroup.Refill(viewGroup.Adapter);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private static void Refill(this ViewGroup viewGroup, IAdapter adapter)
		{
			viewGroup.RemoveAllViews();
			int count = adapter.Count;
			for (int i = 0; i < count; i++)
			{
				viewGroup.AddView(adapter.GetView(i, null, viewGroup));
			}
		}

		private static void Add(this ViewGroup viewGroup, IAdapter adapter, int insertionIndex, int count)
		{
			for (int i = 0; i < count; i++)
			{
				viewGroup.AddView(adapter.GetView(insertionIndex + i, null, viewGroup), insertionIndex + i);
			}
		}

		private static void Remove(this ViewGroup viewGroup, IAdapter adapter, int removalIndex, int count)
		{
			for (int i = 0; i < count; i++)
			{
				viewGroup.RemoveViewAt(removalIndex + i);
			}
		}

		private static void Replace(this ViewGroup viewGroup, IAdapter adapter, int startIndex, int count)
		{
			for (int i = 0; i < count; i++)
			{
				viewGroup.RemoveViewAt(startIndex + i);
				viewGroup.AddView(adapter.GetView(startIndex + i, null, viewGroup), startIndex + i);
			}
		}
	}
	public interface IMvxWithChangeAdapter
	{
		IMvxAdapterWithChangedEvent Adapter { get; }
	}
	[Register("mvvmcross.binding.droid.views.MvxRelativeLayout")]
	public class MvxRelativeLayout : RelativeLayout, IMvxWithChangeAdapter
	{
		private IMvxAdapterWithChangedEvent _adapter;

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
				else
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
				if (adapter != null)
				{
					adapter.ItemsSource = null;
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

		public MvxRelativeLayout(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxRelativeLayout(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			if (adapter != null)
			{
				Adapter = adapter;
				Adapter.ItemTemplateId = itemTemplateId;
			}
			base.ChildViewRemoved += OnChildViewRemoved;
		}

		protected MvxRelativeLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.ChildViewRemoved -= OnChildViewRemoved;
				if (_adapter != null)
				{
					_adapter.DataSetChanged -= AdapterOnDataSetChanged;
				}
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxFrameLayout")]
	public class MvxFrameLayout : FrameLayout, IMvxWithChangeAdapter
	{
		private IMvxAdapterWithChangedEvent _adapter;

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
				else
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
				if (adapter != null)
				{
					adapter.ItemsSource = null;
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

		public MvxFrameLayout(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxFrameLayout(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			if (adapter != null)
			{
				Adapter = adapter;
				Adapter.ItemTemplateId = itemTemplateId;
			}
			base.ChildViewRemoved += OnChildViewRemoved;
		}

		protected MvxFrameLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_adapter != null)
				{
					_adapter.DataSetChanged -= AdapterOnDataSetChanged;
				}
				base.ChildViewRemoved -= OnChildViewRemoved;
			}
			base.Dispose(disposing);
		}
	}
	[Register("mvvmcross.binding.droid.views.MvxTableLayout")]
	public class MvxTableLayout : TableLayout, IMvxWithChangeAdapter
	{
		private IMvxAdapterWithChangedEvent _adapter;

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
				else
				{
					MvxBindingTrace.Warning("Setting Adapter to null is not recommended - you may lose ItemsSource binding when doing this");
				}
				if (adapter != null)
				{
					adapter.ItemsSource = null;
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

		public MvxTableLayout(Context context, IAttributeSet attrs)
			: this(context, attrs, new MvxAdapterWithChangedEvent(context))
		{
		}

		public MvxTableLayout(Context context, IAttributeSet attrs, IMvxAdapterWithChangedEvent adapter)
			: base(context, attrs)
		{
			int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
			if (adapter != null)
			{
				Adapter = adapter;
				Adapter.ItemTemplateId = itemTemplateId;
			}
			base.ChildViewRemoved += OnChildViewRemoved;
		}

		protected MvxTableLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public void AdapterOnDataSetChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			this.UpdateDataSetFromChange(sender, eventArgs);
		}

		private void OnChildViewRemoved(object sender, ChildViewRemovedEventArgs childViewRemovedEventArgs)
		{
			(childViewRemovedEventArgs.Child as IMvxBindingContextOwner)?.ClearAllBindings();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_adapter != null)
				{
					_adapter.DataSetChanged -= AdapterOnDataSetChanged;
				}
				base.ChildViewRemoved -= OnChildViewRemoved;
			}
			base.Dispose(disposing);
		}
	}
}
namespace MvvmCross.Binding.Droid.Target
{
	public class MvxImageViewImageDrawableTargetBinding : MvxAndroidTargetBinding
	{
		public override Type TargetType => typeof(ImageView);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public MvxImageViewImageDrawableTargetBinding(ImageView target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			ImageView obj = (ImageView)target;
			Drawable imageDrawable = value as Drawable;
			obj.SetImageDrawable(imageDrawable);
		}
	}
	public class MvxListPreferenceTargetBinding : MvxPreferenceValueTargetBinding
	{
		public MvxListPreferenceTargetBinding(ListPreference preference)
			: base(preference)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			if (target is ListPreference listPreference)
			{
				listPreference.Value = (string)value;
			}
		}
	}
	public abstract class MvxAndroidPropertyInfoTargetBinding : MvxPropertyInfoTargetBinding
	{
		protected MvxAndroidPropertyInfoTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}

		protected override bool ShouldSkipSetValueForPlatformSpecificReasons(object target, object value)
		{
			return MvxAndroidTargetBinding.TargetIsInvalid(target);
		}
	}
	public abstract class MvxAndroidPropertyInfoTargetBinding<TView> : MvxPropertyInfoTargetBinding<TView> where TView : class
	{
		protected MvxAndroidPropertyInfoTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}

		protected override bool ShouldSkipSetValueForPlatformSpecificReasons(object target, object value)
		{
			return MvxAndroidTargetBinding.TargetIsInvalid(target);
		}
	}
	public class MvxTextViewHintTargetBinding : MvxAndroidTargetBinding
	{
		public override Type TargetType => typeof(string);

		public MvxTextViewHintTargetBinding(TextView target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			((TextView)target).Hint = (string)value;
		}
	}
	public class MvxEditTextPreferenceTextTargetBinding : MvxPreferenceValueTargetBinding
	{
		public MvxEditTextPreferenceTextTargetBinding(EditTextPreference preference)
			: base(preference)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			if (target is EditTextPreference editTextPreference)
			{
				editTextPreference.Text = (string)value;
			}
		}
	}
	public class MvxExpandableListViewSelectedItemTargetBinding : MvxAndroidTargetBinding
	{
		private object _currentValue;

		private IDisposable _subscription;

		protected MvxExpandableListView ListView => (MvxExpandableListView)base.Target;

		public override Type TargetType => typeof(object);

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxExpandableListViewSelectedItemTargetBinding(MvxExpandableListView target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			MvxExpandableListView mvxExpandableListView = (MvxExpandableListView)target;
			if (value == null)
			{
				_currentValue = null;
				mvxExpandableListView.ClearChoices();
				return;
			}
			Tuple<int, int> positions = ((MvxExpandableListAdapter)mvxExpandableListView.ExpandableListAdapter).GetPositions(value);
			if (positions == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
				return;
			}
			_currentValue = value;
			mvxExpandableListView.SetSelectedChild(positions.Item1, positions.Item2, shouldExpandGroup: true);
			int flatListPosition = mvxExpandableListView.GetFlatListPosition(ExpandableListView.GetPackedPositionForChild(positions.Item1, positions.Item2));
			mvxExpandableListView.SetItemChecked(flatListPosition, value: true);
		}

		public override void SubscribeToEvents()
		{
			ExpandableListView listView = ListView;
			if (listView != null)
			{
				_subscription = listView.WeakSubscribe<ExpandableListView, ExpandableListView.ChildClickEventArgs>("ChildClick", OnChildClick);
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

		private void OnChildClick(object sender, ExpandableListView.ChildClickEventArgs childClickEventArgs)
		{
			MvxExpandableListView listView = ListView;
			if (listView != null)
			{
				object rawItem = ((MvxExpandableListAdapter)listView.ExpandableListAdapter).GetRawItem(childClickEventArgs.GroupPosition, childClickEventArgs.ChildPosition);
				if (!rawItem.Equals(_currentValue))
				{
					int flatListPosition = listView.GetFlatListPosition(ExpandableListView.GetPackedPositionForChild(childClickEventArgs.GroupPosition, childClickEventArgs.ChildPosition));
					listView.SetItemChecked(flatListPosition, value: true);
					_currentValue = rawItem;
					FireValueChanged(rawItem);
				}
			}
		}
	}
	public class MvxPreferenceValueTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		public Preference Preference => base.Target as Preference;

		public override Type TargetType => typeof(Preference);

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxPreferenceValueTargetBinding(Preference preference)
			: base(preference)
		{
		}

		public override void SubscribeToEvents()
		{
			_subscription = Preference.WeakSubscribe<Preference, Preference.PreferenceChangeEventArgs>("PreferenceChange", HandlePreferenceChange);
		}

		protected void HandlePreferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
		{
			if (e.Preference == Preference)
			{
				FireValueChanged(e.NewValue);
				e.Handled = true;
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

		protected override void SetValueImpl(object target, object value)
		{
			Mvx.Warning("SetValueImpl called on generic Preference target");
		}
	}
	public class MvxRatingBarRatingTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		protected RatingBar RatingBar => (RatingBar)base.Target;

		public override Type TargetType => typeof(float);

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxRatingBarRatingTargetBinding(RatingBar target)
			: base(target)
		{
		}

		public override void SubscribeToEvents()
		{
			_subscription = RatingBar.WeakSubscribe<RatingBar, RatingBar.RatingBarChangeEventArgs>("RatingBarChange", RatingBar_RatingBarChange);
		}

		private void RatingBar_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
		{
			if (base.Target is RatingBar { Rating: var rating })
			{
				FireValueChanged(rating);
			}
		}

		protected override void SetValueImpl(object target, object value)
		{
			((RatingBar)target).Rating = (float)value;
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
	public abstract class MvxBaseStreamImageViewTargetBinding : MvxBaseImageViewTargetBinding
	{
		protected MvxBaseStreamImageViewTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override bool GetBitmap(object value, out Bitmap bitmap)
		{
			Stream stream = GetStream(value);
			if (stream == null)
			{
				bitmap = null;
				return false;
			}
			BitmapFactory.Options opts = new BitmapFactory.Options
			{
				InPurgeable = true
			};
			bitmap = BitmapFactory.DecodeStream(stream, null, opts);
			return true;
		}

		protected override void SetImageBitmap(ImageView imageView, Bitmap bitmap)
		{
			BitmapDrawable imageDrawable = new BitmapDrawable(Resources.System, bitmap);
			imageView.SetImageDrawable(imageDrawable);
		}

		protected abstract Stream GetStream(object value);
	}
	public abstract class MvxBaseViewVisibleBinding : MvxAndroidTargetBinding
	{
		protected View View => (View)base.Target;

		public override Type TargetType => typeof(bool);

		protected MvxBaseViewVisibleBinding(object target)
			: base(target)
		{
		}
	}
	public class MvxImageViewBitmapTargetBinding : MvxBaseImageViewTargetBinding
	{
		public override Type TargetType => typeof(Bitmap);

		public MvxImageViewBitmapTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override bool GetBitmap(object value, out Bitmap bitmap)
		{
			if (!(value is Bitmap))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value was not a valid Bitmap");
				bitmap = null;
				return false;
			}
			bitmap = (Bitmap)value;
			return true;
		}
	}
	public abstract class MvxBaseImageViewTargetBinding : MvxAndroidTargetBinding
	{
		protected ImageView ImageView => (ImageView)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		protected MvxBaseImageViewTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			ImageView imageView = (ImageView)target;
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

		protected virtual void SetImageBitmap(ImageView imageView, Bitmap bitmap)
		{
			imageView.SetImageBitmap(bitmap);
		}

		protected abstract bool GetBitmap(object value, out Bitmap bitmap);
	}
	public class MvxImageViewDrawableNameTargetBinding : MvxImageViewDrawableTargetBinding
	{
		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override Type TargetType => typeof(string);

		public MvxImageViewDrawableNameTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			ImageView imageView = (ImageView)target;
			if (!(value is string))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value '{0}' could not be parsed as a valid string identifier", value);
				imageView.SetImageDrawable(null);
				return;
			}
			int identifier = base.AndroidGlobals.ApplicationContext.Resources.GetIdentifier((string)value, "drawable", base.AndroidGlobals.ApplicationContext.PackageName);
			if (identifier == 0)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value '{0}' was not a known drawable name", value);
				imageView.SetImageDrawable(null);
			}
			else
			{
				base.SetValueImpl(target, (object)identifier);
			}
		}
	}
	public class MvxImageViewImageTargetBinding : MvxBaseStreamImageViewTargetBinding
	{
		public override Type TargetType => typeof(string);

		public MvxImageViewImageTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override Stream GetStream(object value)
		{
			if (value == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Null value passed to ImageView binding");
				return null;
			}
			string text = value as string;
			if (string.IsNullOrWhiteSpace(text))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Empty value passed to ImageView binding");
				return null;
			}
			string imageAssetName = GetImageAssetName(text);
			return base.AndroidGlobals.ApplicationContext.Assets.Open(imageAssetName);
		}

		private static string GetImageAssetName(string rawImage)
		{
			return rawImage.TrimStart(new char[1] { '/' });
		}
	}
	public class MvxListViewSelectedItemTargetBinding : MvxAndroidTargetBinding
	{
		private object _currentValue;

		private IDisposable _subscription;

		protected MvxListView ListView => (MvxListView)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(object);

		public MvxListViewSelectedItemTargetBinding(MvxListView view)
			: base(view)
		{
		}

		private void OnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
		{
			MvxListView listView = ListView;
			if (listView != null)
			{
				object rawItem = listView.Adapter.GetRawItem(itemClickEventArgs.Position);
				if (!rawItem.Equals(_currentValue))
				{
					_currentValue = rawItem;
					FireValueChanged(rawItem);
				}
			}
		}

		protected override void SetValueImpl(object target, object value)
		{
			if (value != null && value != _currentValue)
			{
				MvxListView mvxListView = (MvxListView)target;
				int position = mvxListView.Adapter.GetPosition(value);
				if (position < 0)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
				}
				else
				{
					_currentValue = value;
					mvxListView.SetSelection(position);
				}
			}
		}

		public override void SubscribeToEvents()
		{
			ListView listView = ListView;
			if (listView != null)
			{
				_subscription = listView.WeakSubscribe<ListView, AdapterView.ItemClickEventArgs>("ItemClick", OnItemClick);
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
	public class MvxAdapterViewSelectedItemPositionTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		protected AdapterView AdapterView => (AdapterView)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(int);

		public MvxAdapterViewSelectedItemPositionTargetBinding(AdapterView adapterView)
			: base(adapterView)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			((AdapterView)target).SetSelection((int)value);
		}

		private void AdapterViewOnItemSelected(object sender, AdapterView.ItemSelectedEventArgs itemSelectedEventArgs)
		{
			FireValueChanged(itemSelectedEventArgs.Position);
		}

		public override void SubscribeToEvents()
		{
			AdapterView adapterView = AdapterView;
			if (adapterView != null)
			{
				_subscription = adapterView.WeakSubscribe<AdapterView, AdapterView.ItemSelectedEventArgs>("ItemSelected", AdapterViewOnItemSelected);
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
	public class MvxAutoCompleteTextViewPartialTextTargetBinding : MvxAndroidPropertyInfoTargetBinding<MvxAutoCompleteTextView>
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		public MvxAutoCompleteTextViewPartialTextTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			if (base.View == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in MvxAutoCompleteTextViewPartialTextTargetBinding");
			}
		}

		private void AutoCompleteOnPartialTextChanged(object sender, EventArgs eventArgs)
		{
			FireValueChanged(base.View.PartialText);
		}

		public override void SubscribeToEvents()
		{
			MvxAutoCompleteTextView view = base.View;
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
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxAutoCompleteTextViewSelectedObjectTargetBinding : MvxAndroidPropertyInfoTargetBinding<MvxAutoCompleteTextView>
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		public MvxAutoCompleteTextViewSelectedObjectTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			if (base.View == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in MvxAutoCompleteTextViewSelectedObjectTargetBinding");
			}
		}

		private void AutoCompleteOnSelectedObjectChanged(object sender, EventArgs eventArgs)
		{
			FireValueChanged(base.View.SelectedObject);
		}

		public override void SubscribeToEvents()
		{
			MvxAutoCompleteTextView view = base.View;
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
				_subscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxRadioGroupSelectedItemBinding : MvxAndroidTargetBinding
	{
		private object _currentValue;

		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(object);

		public MvxRadioGroupSelectedItemBinding(MvxRadioGroup radioGroup)
			: base(radioGroup)
		{
			_subscription = radioGroup.WeakSubscribe<RadioGroup, RadioGroup.CheckedChangeEventArgs>("CheckedChange", RadioGroupCheckedChanged);
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
			MvxRadioGroup mvxRadioGroup = (MvxRadioGroup)base.Target;
			if (mvxRadioGroup != null)
			{
				object obj = null;
				if (mvxRadioGroup.FindViewById<RadioButton>(args.CheckedId)?.Parent is MvxListItemView mvxListItemView)
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
			MvxRadioGroup mvxRadioGroup = (MvxRadioGroup)target;
			if (mvxRadioGroup == null || !CheckValueChanged(newValue))
			{
				return;
			}
			int num = -1;
			if (newValue != null)
			{
				for (int i = 0; i < mvxRadioGroup.ChildCount; i++)
				{
					if (mvxRadioGroup.GetChildAt(i) is MvxListItemView mvxListItemView && newValue.Equals(mvxListItemView.DataContext) && mvxListItemView.GetChildAt(0) is RadioButton radioButton)
					{
						num = radioButton.Id;
						break;
					}
				}
			}
			if (num == -1)
			{
				mvxRadioGroup.ClearCheck();
			}
			else
			{
				mvxRadioGroup.Check(num);
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
	public class MvxSearchViewQueryTextTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

		protected SearchView SearchView => (SearchView)base.Target;

		public MvxSearchViewQueryTextTargetBinding(object target)
			: base(target)
		{
		}

		public override void SubscribeToEvents()
		{
			_subscription = SearchView.WeakSubscribe<SearchView, SearchView.QueryTextChangeEventArgs>("QueryTextChange", HandleQueryTextChanged);
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

		private void HandleQueryTextChanged(object sender, SearchView.QueryTextChangeEventArgs e)
		{
			if (base.Target is SearchView { Query: var query })
			{
				FireValueChanged(query);
			}
		}
	}
	public class MvxTextViewFocusTargetBinding : MvxAndroidTargetBinding
	{
		private IDisposable _subscription;

		protected EditText TextField => base.Target as EditText;

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxTextViewFocusTargetBinding(object target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			if (TextField != null)
			{
				value = value ?? string.Empty;
				TextField.Text = value.ToString();
			}
		}

		public override void SubscribeToEvents()
		{
			if (TextField != null)
			{
				_subscription = TextField.WeakSubscribe<View, View.FocusChangeEventArgs>("FocusChange", HandleLostFocus);
			}
		}

		private void HandleLostFocus(object sender, View.FocusChangeEventArgs e)
		{
			if (TextField != null && !e.HasFocus)
			{
				FireValueChanged(TextField.Text);
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
	public class MvxTextViewTextFormattedTargetBinding : MvxAndroidTargetBinding, IMvxEditableTextView
	{
		private readonly bool _isEditTextBinding;

		private IDisposable _subscription;

		protected TextView TextView => base.Target as TextView;

		public override Type TargetType => typeof(ISpanned);

		public override MvxBindingMode DefaultMode
		{
			get
			{
				if (!_isEditTextBinding)
				{
					return MvxBindingMode.OneWay;
				}
				return MvxBindingMode.TwoWay;
			}
		}

		public string CurrentText => TextView?.TextFormatted.ToString();

		public MvxTextViewTextFormattedTargetBinding(TextView target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - TextView is null in MvxTextViewTextFormattedTargetBinding");
			}
			else
			{
				_isEditTextBinding = target is EditText;
			}
		}

		protected override bool ShouldSkipSetValueForViewSpecificReasons(object target, object value)
		{
			if (!_isEditTextBinding)
			{
				return false;
			}
			return this.ShouldSkipSetValueAsHaveNearlyIdenticalNumericText(target, value);
		}

		protected override void SetValueImpl(object target, object toSet)
		{
			((TextView)target).TextFormatted = (ISpanned)toSet;
		}

		public override void SubscribeToEvents()
		{
			TextView textView = TextView;
			if (textView != null)
			{
				_subscription = textView.WeakSubscribe<TextView, AfterTextChangedEventArgs>("AfterTextChanged", EditTextOnAfterTextChanged);
			}
		}

		private void EditTextOnAfterTextChanged(object sender, AfterTextChangedEventArgs afterTextChangedEventArgs)
		{
			FireValueChanged(TextView.TextFormatted);
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
	public class MvxTextViewTextTargetBinding : MvxAndroidTargetBinding, IMvxEditableTextView
	{
		private readonly bool _isEditTextBinding;

		private IDisposable _subscription;

		protected TextView TextView => base.Target as TextView;

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode
		{
			get
			{
				if (!_isEditTextBinding)
				{
					return MvxBindingMode.OneWay;
				}
				return MvxBindingMode.TwoWay;
			}
		}

		public string CurrentText => TextView?.Text;

		public MvxTextViewTextTargetBinding(TextView target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - TextView is null in MvxTextViewTextTargetBinding");
			}
			else
			{
				_isEditTextBinding = target is EditText;
			}
		}

		protected override bool ShouldSkipSetValueForViewSpecificReasons(object target, object value)
		{
			if (!_isEditTextBinding)
			{
				return false;
			}
			return this.ShouldSkipSetValueAsHaveNearlyIdenticalNumericText(target, value);
		}

		protected override void SetValueImpl(object target, object toSet)
		{
			((TextView)target).Text = (string)toSet;
		}

		public override void SubscribeToEvents()
		{
			TextView textView = TextView;
			if (textView != null)
			{
				_subscription = textView.WeakSubscribe<TextView, AfterTextChangedEventArgs>("AfterTextChanged", EditTextOnAfterTextChanged);
			}
		}

		private void EditTextOnAfterTextChanged(object sender, AfterTextChangedEventArgs e)
		{
			FireValueChanged(TextView.Text);
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
	public class MvxSeekBarProgressTargetBinding : MvxPropertyInfoTargetBinding<SeekBar>
	{
		private IDisposable _subscription;

		private int JustForReflection
		{
			get
			{
				return base.View.Progress;
			}
			set
			{
				base.View.Progress = value;
			}
		}

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxSeekBarProgressTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			SeekBar seekBar = (SeekBar)target;
			if (seekBar != null)
			{
				seekBar.Progress = (int)value;
			}
		}

		private void SeekBarProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
		{
			if (e.FromUser)
			{
				FireValueChanged(e.Progress);
			}
		}

		public override void SubscribeToEvents()
		{
			SeekBar view = base.View;
			if (view == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - SeekBar is null in MvxSeekBarProgressTargetBinding");
			}
			else
			{
				_subscription = view.WeakSubscribe<SeekBar, SeekBar.ProgressChangedEventArgs>("ProgressChanged", SeekBarProgressChanged);
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
	public class MvxSpinnerSelectedItemBinding : MvxAndroidTargetBinding
	{
		private object _currentValue;

		private IDisposable _subscription;

		protected MvxSpinner Spinner => (MvxSpinner)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public override Type TargetType => typeof(object);

		public MvxSpinnerSelectedItemBinding(MvxSpinner spinner)
			: base(spinner)
		{
		}

		private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			MvxSpinner spinner = Spinner;
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
			MvxSpinner mvxSpinner = (MvxSpinner)target;
			if (value == null)
			{
				MvxBindingTrace.Warning("Null values not permitted in spinner SelectedItem binding currently");
			}
			else if (!value.Equals(_currentValue))
			{
				int position = mvxSpinner.Adapter.GetPosition(value);
				if (position < 0)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
				}
				else
				{
					_currentValue = value;
					mvxSpinner.SetSelection(position);
				}
			}
		}

		public override void SubscribeToEvents()
		{
			MvxSpinner spinner = Spinner;
			if (spinner != null)
			{
				_subscription = spinner.WeakSubscribe<AdapterView, AdapterView.ItemSelectedEventArgs>("ItemSelected", SpinnerItemSelected);
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
	public class MvxTwoStatePreferenceCheckedTargetBinding : MvxPreferenceValueTargetBinding
	{
		public MvxTwoStatePreferenceCheckedTargetBinding(TwoStatePreference preference)
			: base(preference)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			if (target is TwoStatePreference twoStatePreference)
			{
				twoStatePreference.Checked = (bool)value;
			}
		}
	}
	public class MvxViewClickBinding : MvxAndroidTargetBinding
	{
		private ICommand _command;

		private IDisposable _clickSubscription;

		private IDisposable _canExecuteSubscription;

		private readonly EventHandler<EventArgs> _canExecuteEventHandler;

		protected View View => (View)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override Type TargetType => typeof(ICommand);

		public MvxViewClickBinding(View view)
			: base(view)
		{
			_canExecuteEventHandler = OnCanExecuteChanged;
			_clickSubscription = view.WeakSubscribe("Click", ViewOnClick);
		}

		private void ViewOnClick(object sender, EventArgs args)
		{
			if (_command != null && _command.CanExecute(null))
			{
				_command.Execute(null);
			}
		}

		protected override void SetValueImpl(object target, object value)
		{
			_canExecuteSubscription?.Dispose();
			_canExecuteSubscription = null;
			_command = value as ICommand;
			if (_command != null)
			{
				_canExecuteSubscription = _command.WeakSubscribe(_canExecuteEventHandler);
			}
			RefreshEnabledState();
		}

		private void RefreshEnabledState()
		{
			View view = View;
			if (view != null)
			{
				bool enabled = false;
				if (_command != null)
				{
					enabled = _command.CanExecute(null);
				}
				view.Enabled = enabled;
			}
		}

		private void OnCanExecuteChanged(object sender, EventArgs e)
		{
			RefreshEnabledState();
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_clickSubscription?.Dispose();
				_clickSubscription = null;
				_canExecuteSubscription?.Dispose();
				_canExecuteSubscription = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public class MvxViewHiddenBinding : MvxBaseViewVisibleBinding
	{
		public MvxViewHiddenBinding(object target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			((View)target).Visibility = (value.ConvertToBoolean() ? ViewStates.Gone : ViewStates.Visible);
		}
	}
	public class MvxViewVisibleBinding : MvxBaseViewVisibleBinding
	{
		public MvxViewVisibleBinding(object target)
			: base(target)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			((View)target).Visibility = ((!value.ConvertToBoolean()) ? ViewStates.Gone : ViewStates.Visible);
		}
	}
	public class MvxViewLongClickBinding : MvxAndroidTargetBinding
	{
		private ICommand _command;

		private IDisposable _subscription;

		protected View View => (View)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override Type TargetType => typeof(ICommand);

		public MvxViewLongClickBinding(View view)
			: base(view)
		{
			_subscription = view.WeakSubscribe<View, View.LongClickEventArgs>("LongClick", ViewOnLongClick);
		}

		private void ViewOnLongClick(object sender, View.LongClickEventArgs longClickEventArgs)
		{
			if (_command != null && _command.CanExecute(null))
			{
				_command.Execute(null);
			}
		}

		protected override void SetValueImpl(object target, object value)
		{
			_command = value as ICommand;
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_subscription?.Dispose();
				_subscription = null;
				_command = null;
			}
			base.Dispose(isDisposing);
		}
	}
	public abstract class MvxAndroidTargetBinding : MvxConvertingTargetBinding
	{
		private IMvxAndroidGlobals _androidGlobals;

		protected IMvxAndroidGlobals AndroidGlobals => _androidGlobals ?? (_androidGlobals = Mvx.Resolve<IMvxAndroidGlobals>());

		protected MvxAndroidTargetBinding(object target)
			: base(target)
		{
		}

		protected override bool ShouldSkipSetValueForPlatformSpecificReasons(object target, object value)
		{
			return TargetIsInvalid(target);
		}

		public static bool TargetIsInvalid(object target)
		{
			if (target is IJavaObject javaObject && javaObject.Handle == IntPtr.Zero)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Weak Target has been GCed by Android {0}", javaObject.GetType().Name);
				return true;
			}
			return false;
		}
	}
	public class MvxCompoundButtonCheckedTargetBinding : MvxAndroidPropertyInfoTargetBinding<CompoundButton>
	{
		private IDisposable _subscription;

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

		public MvxCompoundButtonCheckedTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}

		public override void SubscribeToEvents()
		{
			CompoundButton view = base.View;
			if (view == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - compoundButton is null in MvxCompoundButtonCheckedTargetBinding");
			}
			else
			{
				_subscription = view.WeakSubscribe<CompoundButton, CompoundButton.CheckedChangeEventArgs>("CheckedChange", CompoundButtonOnCheckedChange);
			}
		}

		private void CompoundButtonOnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
		{
			FireValueChanged(base.View.Checked);
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
	public class MvxImageViewDrawableTargetBinding : MvxAndroidTargetBinding
	{
		protected ImageView ImageView => (ImageView)base.Target;

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override Type TargetType => typeof(int);

		public MvxImageViewDrawableTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override void SetValueImpl(object target, object value)
		{
			ImageView imageView = (ImageView)target;
			if (!(value is int num))
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value was not a valid Drawable");
				imageView.SetImageDrawable(null);
			}
			else if (num == 0)
			{
				imageView.SetImageDrawable(null);
			}
			else
			{
				SetImage(imageView, num);
			}
		}

		protected virtual void SetImage(ImageView imageView, int id)
		{
			Context context = imageView.Context;
			Drawable drawable = ((Build.VERSION.SdkInt < BuildVersionCodes.Lollipop) ? context?.Resources?.GetDrawable(id) : context?.Resources?.GetDrawable(id, context.Theme));
			if (drawable != null)
			{
				imageView.SetImageDrawable(drawable);
			}
		}
	}
	public class MvxImageViewResourceNameTargetBinding : MvxImageViewDrawableNameTargetBinding
	{
		public MvxImageViewResourceNameTargetBinding(ImageView imageView)
			: base(imageView)
		{
		}

		protected override void SetImage(ImageView imageView, int id)
		{
			imageView.SetImageResource(id);
		}
	}
}
namespace MvvmCross.Binding.Droid.ResourceHelpers
{
	public interface IMvxAndroidBindingResource
	{
		int BindingTagUnique { get; }

		int[] BindingStylableGroupId { get; }

		int BindingBindId { get; }

		int BindingLangId { get; }

		int[] ControlStylableGroupId { get; }

		int TemplateId { get; }

		int[] ImageViewStylableGroupId { get; }

		int SourceBindId { get; }

		int[] ListViewStylableGroupId { get; }

		int ListItemTemplateId { get; }

		int DropDownListItemTemplateId { get; }

		int[] ExpandableListViewStylableGroupId { get; }

		int GroupItemTemplateId { get; }
	}
	public interface IMvxAppResourceTypeFinder
	{
		Type Find();
	}
	public class MvxAndroidBindingResource : MvxSingleton<IMvxAndroidBindingResource>, IMvxAndroidBindingResource
	{
		public int BindingTagUnique { get; }

		public int[] BindingStylableGroupId { get; }

		public int BindingBindId { get; }

		public int BindingLangId { get; }

		public int[] ControlStylableGroupId { get; }

		public int TemplateId { get; }

		public int[] ImageViewStylableGroupId { get; }

		public int SourceBindId { get; }

		public int[] ListViewStylableGroupId { get; }

		public int ListItemTemplateId { get; }

		public int DropDownListItemTemplateId { get; }

		public int[] ExpandableListViewStylableGroupId { get; }

		public int GroupItemTemplateId { get; }

		public static void Initialize()
		{
			if (MvxSingleton<IMvxAndroidBindingResource>.Instance == null)
			{
				new MvxAndroidBindingResource();
			}
		}

		private MvxAndroidBindingResource()
		{
			Type type = Mvx.Resolve<IMvxAppResourceTypeFinder>().Find();
			try
			{
				Type nestedType = type.GetNestedType("Id");
				BindingTagUnique = (int)SafeGetFieldValue(nestedType, "MvxBindingTagUnique");
				Type nestedType2 = type.GetNestedType("Styleable");
				ControlStylableGroupId = (int[])SafeGetFieldValue(nestedType2, "MvxControl", new int[0]);
				TemplateId = (int)SafeGetFieldValue(nestedType2, "MvxControl_MvxTemplate");
				BindingStylableGroupId = (int[])SafeGetFieldValue(nestedType2, "MvxBinding", new int[0]);
				BindingBindId = (int)SafeGetFieldValue(nestedType2, "MvxBinding_MvxBind");
				BindingLangId = (int)SafeGetFieldValue(nestedType2, "MvxBinding_MvxLang");
				ImageViewStylableGroupId = (int[])SafeGetFieldValue(nestedType2, "MvxImageView", new int[0]);
				SourceBindId = (int)SafeGetFieldValue(nestedType2, "MvxImageView_MvxSource");
				ListViewStylableGroupId = (int[])SafeGetFieldValue(nestedType2, "MvxListView");
				ListItemTemplateId = (int)nestedType2.GetField("MvxListView_MvxItemTemplate").GetValue(null);
				DropDownListItemTemplateId = (int)nestedType2.GetField("MvxListView_MvxDropDownItemTemplate").GetValue(null);
				ExpandableListViewStylableGroupId = (int[])SafeGetFieldValue(nestedType2, "MvxExpandableListView", new int[0]);
				GroupItemTemplateId = (int)SafeGetFieldValue(nestedType2, "MvxExpandableListView_MvxGroupItemTemplate");
			}
			catch (System.Exception exception)
			{
				throw exception.MvxWrap("Error finding resource ids for MvxBinding - please make sure ResourcesToCopy are linked into the executable");
			}
		}

		private static object SafeGetFieldValue(Type styleable, string fieldName)
		{
			return SafeGetFieldValue(styleable, fieldName, 0);
		}

		private static object SafeGetFieldValue(Type styleable, string fieldName, object defaultValue)
		{
			FieldInfo field = styleable.GetField(fieldName);
			if (field == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Missing stylable field {0}", fieldName);
				return defaultValue;
			}
			return field.GetValue(null);
		}
	}
	public class MvxAppResourceTypeFinder : IMvxAppResourceTypeFinder
	{
		public Type Find()
		{
			IMvxAndroidGlobals mvxAndroidGlobals = Mvx.Resolve<IMvxAndroidGlobals>();
			string text = mvxAndroidGlobals.ExecutableNamespace + ".Resource";
			Type type = mvxAndroidGlobals.ExecutableAssembly.GetType(text);
			if (type == null)
			{
				throw new MvxException("Unable to find resource type - " + text);
			}
			return type;
		}
	}
}
namespace MvvmCross.Binding.Droid.BindingContext
{
	public static class MvxAndroidBindingContextHelpers
	{
		public static IMvxAndroidBindingContext Current()
		{
			return Current<IMvxAndroidBindingContext>();
		}

		public static T Current<T>() where T : class, IMvxBindingContext
		{
			return Mvx.Resolve<IMvxBindingContextStack<T>>().Current;
		}
	}
	public class MvxAndroidBindingContextStack : MvxBindingContextStack<IMvxAndroidBindingContext>
	{
	}
	public static class MvxBindingContextOwnerExtensions
	{
		public static View BindingInflate(this IMvxBindingContextOwner owner, int resourceId, ViewGroup viewGroup)
		{
			return ((IMvxAndroidBindingContext)owner.BindingContext).BindingInflate(resourceId, viewGroup);
		}

		public static View BindingInflate(this IMvxBindingContextOwner owner, int resourceId, ViewGroup viewGroup, bool attachToParent)
		{
			return ((IMvxAndroidBindingContext)owner.BindingContext).BindingInflate(resourceId, viewGroup, attachToParent);
		}
	}
	public interface IMvxAndroidBindingContext : IMvxBindingContext, IMvxDataConsumer
	{
		IMvxLayoutInflaterHolder LayoutInflaterHolder { get; set; }

		View BindingInflate(int resourceId, ViewGroup viewGroup);

		View BindingInflate(int resourceId, ViewGroup viewGroup, bool attachToParent);
	}
	public class MvxAndroidBindingContext : MvxBindingContext, IMvxAndroidBindingContext, IMvxBindingContext, IMvxDataConsumer
	{
		private readonly Context _droidContext;

		private IMvxLayoutInflaterHolder _layoutInflaterHolder;

		public IMvxLayoutInflaterHolder LayoutInflaterHolder
		{
			get
			{
				return _layoutInflaterHolder;
			}
			set
			{
				_layoutInflaterHolder = value;
			}
		}

		public MvxAndroidBindingContext(Context droidContext, IMvxLayoutInflaterHolder layoutInflaterHolder, object source = null)
			: base(source)
		{
			_droidContext = droidContext;
			_layoutInflaterHolder = layoutInflaterHolder;
		}

		public virtual View BindingInflate(int resourceId, ViewGroup viewGroup)
		{
			return BindingInflate(resourceId, viewGroup, attachToRoot: true);
		}

		public virtual View BindingInflate(int resourceId, ViewGroup viewGroup, bool attachToRoot)
		{
			return CommonInflate(resourceId, viewGroup, attachToRoot);
		}

		[Obsolete("Switch to new CommonInflate method - with additional attachToRoot parameter")]
		protected virtual View CommonInflate(int resourceId, ViewGroup viewGroup)
		{
			return CommonInflate(resourceId, viewGroup, viewGroup != null);
		}

		protected virtual View CommonInflate(int resourceId, ViewGroup viewGroup, bool attachToRoot)
		{
			using (new MvxBindingContextStackRegistration<IMvxAndroidBindingContext>(this))
			{
				return _layoutInflaterHolder.LayoutInflater.Inflate(resourceId, viewGroup, attachToRoot);
			}
		}
	}
}
namespace MvvmCross.Binding.Droid.Binders
{
	public interface IMvxAndroidViewBinder
	{
		IList<KeyValuePair<object, IMvxUpdateableBinding>> CreatedBindings { get; }

		void BindView(View view, Context context, IAttributeSet attrs);
	}
	public interface IMvxAndroidViewBinderFactory
	{
		IMvxAndroidViewBinder Create(object source);
	}
	public interface IMvxAndroidViewFactory
	{
		View CreateView(View parent, string name, Context context, IAttributeSet attrs);
	}
	public interface IMvxLayoutInflaterFactory
	{
		View OnCreateView(View parent, string name, Context context, IAttributeSet attrs);
	}
	public interface IMvxLayoutInflaterFactoryFactory
	{
		IMvxLayoutInflaterFactory Create(object source);
	}
	public interface IMvxLayoutInflaterHolderFactory : IMvxLayoutInflaterFactory
	{
		IList<KeyValuePair<object, IMvxUpdateableBinding>> CreatedBindings { get; }

		View BindCreatedView(View view, Context context, IAttributeSet attrs);
	}
	public interface IMvxLayoutInflaterHolderFactoryFactory
	{
		IMvxLayoutInflaterHolderFactory Create(object source);
	}
	public class MvxAndroidViewBinder : IMvxAndroidViewBinder
	{
		private readonly List<KeyValuePair<object, IMvxUpdateableBinding>> _viewBindings = new List<KeyValuePair<object, IMvxUpdateableBinding>>();

		private readonly object _source;

		private IMvxBinder _binder;

		protected IMvxBinder Binder => _binder ?? (_binder = Mvx.Resolve<IMvxBinder>());

		public IList<KeyValuePair<object, IMvxUpdateableBinding>> CreatedBindings => _viewBindings;

		public MvxAndroidViewBinder(object source)
		{
			_source = source;
		}

		public virtual void BindView(View view, Context context, IAttributeSet attrs)
		{
			using TypedArray typedArray = context.ObtainStyledAttributes(attrs, MvxSingleton<IMvxAndroidBindingResource>.Instance.BindingStylableGroupId);
			int indexCount = typedArray.IndexCount;
			for (int i = 0; i < indexCount; i++)
			{
				int index = typedArray.GetIndex(i);
				if (index == MvxSingleton<IMvxAndroidBindingResource>.Instance.BindingBindId)
				{
					ApplyBindingsFromAttribute(view, typedArray, index);
				}
				else if (index == MvxSingleton<IMvxAndroidBindingResource>.Instance.BindingLangId)
				{
					ApplyLanguageBindingsFromAttribute(view, typedArray, index);
				}
			}
			typedArray.Recycle();
		}

		private void ApplyBindingsFromAttribute(View view, TypedArray typedArray, int attributeId)
		{
			try
			{
				string bindingText = typedArray.GetString(attributeId);
				IEnumerable<IMvxUpdateableBinding> newBindings = Binder.Bind(_source, view, bindingText);
				StoreBindings(view, newBindings);
			}
			catch (System.Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Exception thrown during the view binding {0}", exception.ToLongString());
			}
		}

		private void StoreBindings(View view, IEnumerable<IMvxUpdateableBinding> newBindings)
		{
			if (newBindings != null)
			{
				_viewBindings.AddRange(newBindings.Select((IMvxUpdateableBinding b) => new KeyValuePair<object, IMvxUpdateableBinding>(view, b)));
			}
		}

		private void ApplyLanguageBindingsFromAttribute(View view, TypedArray typedArray, int attributeId)
		{
			try
			{
				string bindingText = typedArray.GetString(attributeId);
				IEnumerable<IMvxUpdateableBinding> newBindings = Binder.LanguageBind(_source, view, bindingText);
				StoreBindings(view, newBindings);
			}
			catch (System.Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Exception thrown during the view language binding {0}", exception.ToLongString());
				throw;
			}
		}
	}
	public class MvxAndroidViewBinderFactory : IMvxAndroidViewBinderFactory
	{
		public IMvxAndroidViewBinder Create(object source)
		{
			return new MvxAndroidViewBinder(source);
		}
	}
	public class MvxAndroidViewFactory : IMvxAndroidViewFactory
	{
		private IMvxViewTypeResolver _viewTypeResolver;

		protected IMvxViewTypeResolver ViewTypeResolver => _viewTypeResolver ?? (_viewTypeResolver = Mvx.Resolve<IMvxViewTypeResolver>());

		public virtual View CreateView(View parent, string name, Context context, IAttributeSet attrs)
		{
			Type type = ViewTypeResolver.Resolve(name);
			if (type == null)
			{
				return null;
			}
			try
			{
				View view = Activator.CreateInstance(type, context, attrs) as View;
				if (view == null)
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Error, "Unable to load view {0} from type {1}", name, type.FullName);
				}
				return view;
			}
			catch (ThreadAbortException)
			{
				throw;
			}
			catch (System.Exception exception)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Exception during creation of {0} from type {1} - exception {2}", name, type.FullName, exception.ToLongString());
				return null;
			}
		}
	}
	public static class MvxLayoutInflaterCompat
	{
		internal class FactoryWrapper : Java.Lang.Object, LayoutInflater.IFactory, IJavaObject, IDisposable
		{
			protected readonly IMvxLayoutInflaterFactory DelegateFactory;

			public FactoryWrapper(IntPtr handle, JniHandleOwnership ownership)
				: base(handle, ownership)
			{
			}

			public FactoryWrapper(IMvxLayoutInflaterFactory delegateFactory)
			{
				DelegateFactory = delegateFactory;
			}

			public View OnCreateView(string name, Context context, IAttributeSet attrs)
			{
				return DelegateFactory.OnCreateView(null, name, context, attrs);
			}
		}

		internal class FactoryWrapper2 : FactoryWrapper, LayoutInflater.IFactory2, LayoutInflater.IFactory, IJavaObject, IDisposable
		{
			public FactoryWrapper2(IntPtr handle, JniHandleOwnership ownership)
				: base(handle, ownership)
			{
			}

			public FactoryWrapper2(IMvxLayoutInflaterFactory delegateFactory)
				: base(delegateFactory)
			{
			}

			public View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
			{
				return DelegateFactory.OnCreateView(parent, name, context, attrs);
			}
		}

		private static readonly int SdkInt = (int)Build.VERSION.SdkInt;

		private static Field _layoutInflaterFactory2Field;

		private static bool _checkedField;

		public static void SetFactory(LayoutInflater layoutInflater, IMvxLayoutInflaterFactory factory)
		{
			if (SdkInt >= 21)
			{
				layoutInflater.Factory2 = ((factory != null) ? new FactoryWrapper2(factory) : null);
			}
			else if (SdkInt >= 11)
			{
				FactoryWrapper2 factoryWrapper = (FactoryWrapper2)(layoutInflater.Factory2 = ((factory != null) ? new FactoryWrapper2(factory) : null));
				LayoutInflater.IFactory2 factory3 = layoutInflater.Factory as LayoutInflater.IFactory2;
				ForceSetFactory2(layoutInflater, factory3 ?? factoryWrapper);
			}
			else
			{
				layoutInflater.Factory = ((factory != null) ? new FactoryWrapper(factory) : null);
			}
		}

		private static void ForceSetFactory2(LayoutInflater inflater, LayoutInflater.IFactory2 factory)
		{
			if (!_checkedField)
			{
				try
				{
					_layoutInflaterFactory2Field = Class.FromType(typeof(LayoutInflater)).GetDeclaredField("mFactory2");
					_layoutInflaterFactory2Field.Accessible = true;
				}
				catch (NoSuchFieldException)
				{
					Mvx.Error("ForceSetFactory2 Could not find field 'mFactory2' on class {0}; inflation may have unexpected results.", Class.FromType(typeof(LayoutInflater)).Name);
				}
				_checkedField = true;
			}
			if (_layoutInflaterFactory2Field != null)
			{
				try
				{
					_layoutInflaterFactory2Field.Set(inflater, (Java.Lang.Object)factory);
				}
				catch (IllegalAccessException)
				{
					Mvx.Error("ForceSetFactory2 could not set the Factory2 on LayoutInflater {0} ; inflation may have unexpected results.", inflater);
				}
			}
		}
	}
	public class MvxLayoutInflaterFactoryFactory : IMvxLayoutInflaterHolderFactoryFactory
	{
		public IMvxLayoutInflaterHolderFactory Create(object bindingSource)
		{
			return new MvxBindingLayoutInflaterFactory(bindingSource);
		}
	}
	public class MvxBindingLayoutInflaterFactory : IMvxLayoutInflaterHolderFactory, IMvxLayoutInflaterFactory
	{
		private readonly object _source;

		private IMvxAndroidViewFactory _androidViewFactory;

		private IMvxAndroidViewBinder _binder;

		protected virtual IMvxAndroidViewFactory AndroidViewFactory => _androidViewFactory ?? (_androidViewFactory = Mvx.Resolve<IMvxAndroidViewFactory>());

		protected virtual IMvxAndroidViewBinder Binder => _binder ?? (_binder = Mvx.Resolve<IMvxAndroidViewBinderFactory>().Create(_source));

		public virtual IList<KeyValuePair<object, IMvxUpdateableBinding>> CreatedBindings => Binder.CreatedBindings;

		public MvxBindingLayoutInflaterFactory(object source)
		{
			_source = source;
		}

		public virtual View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
		{
			if (name == "fragment")
			{
				return null;
			}
			View view = AndroidViewFactory.CreateView(parent, name, context, attrs);
			return BindCreatedView(view, context, attrs);
		}

		public virtual View BindCreatedView(View view, Context context, IAttributeSet attrs)
		{
			if (view != null)
			{
				Binder.BindView(view, context, attrs);
			}
			return view;
		}
	}
}
namespace MvvmCross.Binding.Droid.Binders.ViewTypeResolvers
{
	public interface IMvxAxmlNameViewTypeResolver
	{
		IDictionary<string, string> ViewNamespaceAbbreviations { get; }
	}
	public interface IMvxNamespaceListViewTypeResolver
	{
		void Add(string namespaceName);
	}
	public class MvxCachedViewTypeResolver : IMvxViewTypeResolver
	{
		private readonly Dictionary<string, Type> _cache = new Dictionary<string, Type>();

		private readonly IMvxViewTypeResolver _resolver;

		public MvxCachedViewTypeResolver(IMvxViewTypeResolver resolver)
		{
			_resolver = resolver;
		}

		public Type Resolve(string tagName)
		{
			if (_cache.TryGetValue(tagName, out var value))
			{
				return value;
			}
			value = _resolver.Resolve(tagName);
			_cache[tagName] = value;
			return value;
		}
	}
	public class MvxCompositeViewTypeResolver : IMvxViewTypeResolver
	{
		private readonly List<IMvxViewTypeResolver> _resolvers;

		public MvxCompositeViewTypeResolver(params IMvxViewTypeResolver[] resolvers)
		{
			_resolvers = new List<IMvxViewTypeResolver>(resolvers);
		}

		public Type Resolve(string tagName)
		{
			foreach (IMvxViewTypeResolver resolver in _resolvers)
			{
				Type type = resolver.Resolve(tagName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}
	}
	public class MvxJustNameViewTypeResolver : MvxReflectionViewTypeResolver
	{
		public MvxJustNameViewTypeResolver(IMvxTypeCache<View> typeCache)
			: base(typeCache)
		{
		}

		public override Type Resolve(string tagName)
		{
			if (MvxReflectionViewTypeResolver.IsFullyQualified(tagName))
			{
				return null;
			}
			base.TypeCache.NameCache.TryGetValue(tagName, out var value);
			return value;
		}
	}
	public abstract class MvxLongLowerCaseViewTypeResolver : MvxReflectionViewTypeResolver
	{
		protected MvxLongLowerCaseViewTypeResolver(IMvxTypeCache<View> typeCache)
			: base(typeCache)
		{
		}

		protected Type ResolveLowerCaseTypeName(string longLowerCaseName)
		{
			base.TypeCache.LowerCaseFullNameCache.TryGetValue(longLowerCaseName, out var value);
			return value;
		}
	}
	public class MvxNamespaceListViewTypeResolver : MvxLongLowerCaseViewTypeResolver, IMvxNamespaceListViewTypeResolver
	{
		public IList<string> Namespaces { get; }

		public MvxNamespaceListViewTypeResolver(IMvxTypeCache<View> typeCache)
			: base(typeCache)
		{
			Namespaces = new List<string>();
		}

		public void Add(string namespaceName)
		{
			namespaceName = namespaceName.ToLower();
			if (!namespaceName.EndsWith("."))
			{
				namespaceName += ".";
			}
			Namespaces.Add(namespaceName);
		}

		public override Type Resolve(string tagName)
		{
			if (tagName.Contains("."))
			{
				return null;
			}
			string text = tagName.ToLower();
			foreach (string @namespace in Namespaces)
			{
				string key = @namespace + text;
				if (base.TypeCache.LowerCaseFullNameCache.TryGetValue(key, out var value))
				{
					return value;
				}
			}
			return null;
		}
	}
	public abstract class MvxReflectionViewTypeResolver : IMvxViewTypeResolver
	{
		private readonly IMvxTypeCache<View> _typeCache;

		protected IMvxTypeCache<View> TypeCache => _typeCache;

		protected MvxReflectionViewTypeResolver(IMvxTypeCache<View> typeCache)
		{
			_typeCache = typeCache;
		}

		public abstract Type Resolve(string tagName);

		protected static bool IsFullyQualified(string tagName)
		{
			return tagName.Contains(".");
		}
	}
	public interface IMvxViewTypeResolver
	{
		Type Resolve(string tagName);
	}
	public class MvxAxmlNameViewTypeResolver : MvxLongLowerCaseViewTypeResolver, IMvxAxmlNameViewTypeResolver
	{
		public IDictionary<string, string> ViewNamespaceAbbreviations { get; }

		public MvxAxmlNameViewTypeResolver(IMvxTypeCache<View> typeCache)
			: base(typeCache)
		{
			ViewNamespaceAbbreviations = new Dictionary<string, string>();
		}

		public override Type Resolve(string tagName)
		{
			string tagName2 = UnabbreviateTagName(tagName);
			string lookupName = GetLookupName(tagName2);
			return ResolveLowerCaseTypeName(lookupName);
		}

		private string UnabbreviateTagName(string tagName)
		{
			string result = tagName;
			if (ViewNamespaceAbbreviations != null)
			{
				string[] array = tagName.Split(new char[1] { '.' }, 2, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2)
				{
					string text = array[0];
					if (ViewNamespaceAbbreviations.TryGetValue(text, out var value))
					{
						result = value + "." + array[1];
					}
					else
					{
						MvxBindingTrace.Trace(MvxTraceLevel.Diagnostic, "Abbreviation not found {0}", text);
					}
				}
			}
			return result;
		}

		protected string GetLookupName(string tagName)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (tagName == "View" || tagName == "ViewGroup")
			{
				stringBuilder.Append("android.view.");
			}
			else if (!MvxReflectionViewTypeResolver.IsFullyQualified(tagName))
			{
				stringBuilder.Append("android.widget.");
			}
			stringBuilder.Append(tagName);
			return stringBuilder.ToString().ToLowerInvariant();
		}
	}
}
