using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Windows.Input;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Java.Lang;
using MvvmCross.Binding;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.ResourceHelpers;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Droid.Support.V7.RecyclerView.AttributeHelpers;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.WeakSubscription;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Droid.Support.V7.RecyclerView")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: ResourceDesigner("MvvmCross.Droid.Support.V7.RecyclerView.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace MvvmCross.Droid.Support.V7.RecyclerView
{
	public interface IMvxRecyclerAdapter
	{
		[MvxSetToNullAfterBinding]
		IEnumerable ItemsSource { get; set; }

		IMvxTemplateSelector ItemTemplateSelector { get; set; }

		ICommand ItemClick { get; set; }

		ICommand ItemLongClick { get; set; }

		int ItemTemplateId { get; set; }

		object GetItem(int position);
	}
	public interface IMvxRecyclerViewHolder : IMvxBindingContextOwner
	{
		object DataContext { get; set; }

		void OnAttachedToWindow();

		void OnDetachedFromWindow();

		void OnViewRecycled();
	}
	[Register("mvvmcross.droid.support.v7.recyclerview.MvxRecyclerAdapter")]
	public class MvxRecyclerAdapter : AndroidX.RecyclerView.Widget.RecyclerView.Adapter, IMvxRecyclerAdapter
	{
		private readonly IMvxAndroidBindingContext _bindingContext;

		private ICommand _itemClick;

		private ICommand _itemLongClick;

		private IEnumerable _itemsSource;

		private IDisposable _subscription;

		private IMvxTemplateSelector _itemTemplateSelector;

		protected IMvxAndroidBindingContext BindingContext => _bindingContext;

		public bool ReloadOnAllItemsSourceSets { get; set; }

		public ICommand ItemClick
		{
			get
			{
				return _itemClick;
			}
			set
			{
				if (_itemClick != value)
				{
					if (_itemClick != null)
					{
						MvxTrace.Warning("Changing ItemClick may cause inconsistencies where some items still call the old command.");
					}
					_itemClick = value;
				}
			}
		}

		public ICommand ItemLongClick
		{
			get
			{
				return _itemLongClick;
			}
			set
			{
				if (_itemLongClick != value)
				{
					if (_itemLongClick != null)
					{
						MvxTrace.Warning("Changing ItemLongClick may cause inconsistencies where some items still call the old command.");
					}
					_itemLongClick = value;
				}
			}
		}

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

		public virtual IMvxTemplateSelector ItemTemplateSelector
		{
			get
			{
				return _itemTemplateSelector;
			}
			set
			{
				if (_itemTemplateSelector != value)
				{
					_itemTemplateSelector = value;
					if (_itemsSource != null)
					{
						NotifyDataSetChanged();
					}
				}
			}
		}

		public override int ItemCount => _itemsSource.Count();

		public int ItemTemplateId { get; set; }

		public MvxRecyclerAdapter()
			: this(MvxAndroidBindingContextHelpers.Current())
		{
		}

		public MvxRecyclerAdapter(IMvxAndroidBindingContext bindingContext)
		{
			_bindingContext = bindingContext;
		}

		public MvxRecyclerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			base.OnViewAttachedToWindow(holder);
			((IMvxRecyclerViewHolder)holder).OnAttachedToWindow();
		}

		public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			base.OnViewDetachedFromWindow(holder);
			((IMvxRecyclerViewHolder)holder).OnDetachedFromWindow();
		}

		public override void OnViewRecycled(Java.Lang.Object holder)
		{
			base.OnViewRecycled(holder);
			((IMvxRecyclerViewHolder)holder).OnViewRecycled();
		}

		public override AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			MvxAndroidBindingContext mvxAndroidBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
			return new MvxRecyclerViewHolder(InflateViewForHolder(parent, viewType, mvxAndroidBindingContext), mvxAndroidBindingContext)
			{
				Click = ItemClick,
				LongClick = ItemLongClick
			};
		}

		public override int GetItemViewType(int position)
		{
			object item = GetItem(position);
			return ItemTemplateSelector.GetItemViewType(item);
		}

		protected virtual View InflateViewForHolder(ViewGroup parent, int viewType, IMvxAndroidBindingContext bindingContext)
		{
			int itemLayoutId = ItemTemplateSelector.GetItemLayoutId(viewType);
			return bindingContext.BindingInflate(itemLayoutId, parent, attachToParent: false);
		}

		public override void OnBindViewHolder(AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder holder, int position)
		{
			((IMvxRecyclerViewHolder)holder).DataContext = GetItem(position);
		}

		public virtual object GetItem(int position)
		{
			return _itemsSource.ElementAt(position);
		}

		protected virtual void SetItemsSource(IEnumerable value)
		{
			if (_itemsSource != value || ReloadOnAllItemsSourceSets)
			{
				_subscription?.Dispose();
				_subscription = null;
				_itemsSource = value;
				if (_itemsSource != null && !(_itemsSource is IList))
				{
					MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Binding to IEnumerable rather than IList - this can be inefficient, especially for large lists");
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
			try
			{
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
					NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
					break;
				case NotifyCollectionChangedAction.Move:
				{
					for (int i = 0; i < e.NewItems.Count; i++)
					{
						object item = e.OldItems[i];
						object item2 = e.NewItems[i];
						NotifyItemMoved(ItemsSource.GetPosition(item), ItemsSource.GetPosition(item2));
					}
					break;
				}
				case NotifyCollectionChangedAction.Replace:
					NotifyItemRangeChanged(e.NewStartingIndex, e.NewItems.Count);
					break;
				case NotifyCollectionChangedAction.Remove:
					NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count);
					break;
				case NotifyCollectionChangedAction.Reset:
					NotifyDataSetChanged();
					break;
				}
			}
			catch (System.Exception exception)
			{
				Mvx.Warning("Exception masked during Adapter RealNotifyDataSetChanged {0}. Are you trying to update your collection from a background task? See http://goo.gl/0nW0L6", exception.ToLongString());
			}
		}
	}
	[Register("mvvmcross.droid.support.v7.recyclerview.MvxRecyclerView")]
	public class MvxRecyclerView : AndroidX.RecyclerView.Widget.RecyclerView
	{
		public new IMvxRecyclerAdapter Adapter
		{
			get
			{
				return base.GetAdapter() as IMvxRecyclerAdapter;
			}
			set
			{
				IMvxRecyclerAdapter adapter = Adapter;
				if (adapter != value)
				{
					if (value != null && adapter != null)
					{
						value.ItemsSource = adapter.ItemsSource;
						value.ItemTemplateSelector = adapter.ItemTemplateSelector;
						value.ItemClick = adapter.ItemClick;
						value.ItemLongClick = adapter.ItemLongClick;
						SwapAdapter((Adapter)value, removeAndRecycleExistingViews: false);
					}
					else
					{
						SetAdapter((Adapter)value);
					}
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
				return ((ItemTemplateSelector as MvxDefaultTemplateSelector) ?? throw new InvalidOperationException("If you wan't to use single item-template RecyclerView Adapter you can't change it'sIMvxTemplateSelector to anything other than MvxDefaultTemplateSelector")).ItemTemplateId;
			}
			set
			{
				if (!(ItemTemplateSelector is MvxDefaultTemplateSelector mvxDefaultTemplateSelector))
				{
					throw new InvalidOperationException("If you wan't to use single item-template RecyclerView Adapter you can't change it'sIMvxTemplateSelector to anything other than MvxDefaultTemplateSelector");
				}
				mvxDefaultTemplateSelector.ItemTemplateId = value;
				Adapter.ItemTemplateSelector = mvxDefaultTemplateSelector;
			}
		}

		public IMvxTemplateSelector ItemTemplateSelector
		{
			get
			{
				return Adapter.ItemTemplateSelector;
			}
			set
			{
				Adapter.ItemTemplateSelector = value;
			}
		}

		public ICommand ItemClick
		{
			get
			{
				return Adapter.ItemClick;
			}
			set
			{
				Adapter.ItemClick = value;
			}
		}

		public ICommand ItemLongClick
		{
			get
			{
				return Adapter.ItemLongClick;
			}
			set
			{
				Adapter.ItemLongClick = value;
			}
		}

		public MvxRecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public MvxRecyclerView(Context context, IAttributeSet attrs)
			: this(context, attrs, 0, new MvxRecyclerAdapter())
		{
		}

		public MvxRecyclerView(Context context, IAttributeSet attrs, int defStyle)
			: this(context, attrs, defStyle, new MvxRecyclerAdapter())
		{
		}

		public MvxRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter)
			: base(context, attrs, defStyle)
		{
			if (adapter != null)
			{
				SetLayoutManager(new LinearLayoutManager(context));
				int itemTemplateId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
				IMvxTemplateSelector mvxTemplateSelector = (adapter.ItemTemplateSelector = MvxRecyclerViewAttributeExtensions.BuildItemTemplateSelector(context, attrs));
				Adapter = adapter;
				if (mvxTemplateSelector.GetType() == typeof(MvxDefaultTemplateSelector))
				{
					ItemTemplateId = itemTemplateId;
				}
			}
		}

		public sealed override void SetLayoutManager(LayoutManager layout)
		{
			base.SetLayoutManager(layout);
		}
	}
	[Register("mvvmcross.droid.support.v7.recyclerview.MvxRecyclerViewHolder")]
	public class MvxRecyclerViewHolder : AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder, IMvxRecyclerViewHolder, IMvxBindingContextOwner
	{
		private readonly IMvxBindingContext _bindingContext;

		private object _cachedDataContext;

		private ICommand _click;

		private ICommand _longClick;

		private bool _clickOverloaded;

		private bool _longClickOverloaded;

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

		public object DataContext
		{
			get
			{
				return _bindingContext.DataContext;
			}
			set
			{
				_bindingContext.DataContext = value;
				if (value != null)
				{
					_cachedDataContext = null;
				}
			}
		}

		public ICommand Click
		{
			get
			{
				return _click;
			}
			set
			{
				_click = value;
				if (_click != null)
				{
					EnsureClickOverloaded();
				}
			}
		}

		public ICommand LongClick
		{
			get
			{
				return _longClick;
			}
			set
			{
				_longClick = value;
				if (_longClick != null)
				{
					EnsureLongClickOverloaded();
				}
			}
		}

		private void EnsureClickOverloaded()
		{
			if (!_clickOverloaded)
			{
				_clickOverloaded = true;
				base.ItemView.Click += OnItemViewOnClick;
			}
		}

		private void EnsureLongClickOverloaded()
		{
			if (!_longClickOverloaded)
			{
				_longClickOverloaded = true;
				base.ItemView.LongClick += OnItemViewOnLongClick;
			}
		}

		protected virtual void ExecuteCommandOnItem(ICommand command)
		{
			if (command != null)
			{
				object dataContext = DataContext;
				if (dataContext != null && command.CanExecute(dataContext))
				{
					command.Execute(dataContext);
				}
			}
		}

		private void OnItemViewOnClick(object sender, EventArgs args)
		{
			ExecuteCommandOnItem(Click);
		}

		private void OnItemViewOnLongClick(object sender, View.LongClickEventArgs args)
		{
			ExecuteCommandOnItem(LongClick);
		}

		public MvxRecyclerViewHolder(View itemView, IMvxAndroidBindingContext context)
			: base(itemView)
		{
			_bindingContext = context;
		}

		public virtual void OnAttachedToWindow()
		{
			if (_cachedDataContext != null && DataContext == null)
			{
				DataContext = _cachedDataContext;
			}
		}

		public virtual void OnDetachedFromWindow()
		{
			_cachedDataContext = DataContext;
			DataContext = null;
		}

		public virtual void OnViewRecycled()
		{
			_cachedDataContext = null;
			DataContext = null;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_bindingContext.ClearAllBindings();
				_cachedDataContext = null;
				if (base.ItemView != null)
				{
					base.ItemView.Click -= OnItemViewOnClick;
					base.ItemView.LongClick -= OnItemViewOnLongClick;
				}
			}
			base.Dispose(disposing);
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Animation
		{
			public static int abc_fade_in;

			public static int abc_fade_out;

			public static int abc_grow_fade_in_from_bottom;

			public static int abc_popup_enter;

			public static int abc_popup_exit;

			public static int abc_shrink_fade_out_from_bottom;

			public static int abc_slide_in_bottom;

			public static int abc_slide_in_top;

			public static int abc_slide_out_bottom;

			public static int abc_slide_out_top;

			public static int abc_tooltip_enter;

			public static int abc_tooltip_exit;

			public static int btn_checkbox_to_checked_box_inner_merged_animation;

			public static int btn_checkbox_to_checked_box_outer_merged_animation;

			public static int btn_checkbox_to_checked_icon_null_animation;

			public static int btn_checkbox_to_unchecked_box_inner_merged_animation;

			public static int btn_checkbox_to_unchecked_check_path_merged_animation;

			public static int btn_checkbox_to_unchecked_icon_null_animation;

			public static int btn_radio_to_off_mtrl_dot_group_animation;

			public static int btn_radio_to_off_mtrl_ring_outer_animation;

			public static int btn_radio_to_off_mtrl_ring_outer_path_animation;

			public static int btn_radio_to_on_mtrl_dot_group_animation;

			public static int btn_radio_to_on_mtrl_ring_outer_animation;

			public static int btn_radio_to_on_mtrl_ring_outer_path_animation;

			public static int fragment_close_enter;

			public static int fragment_close_exit;

			public static int fragment_fade_enter;

			public static int fragment_fade_exit;

			public static int fragment_fast_out_extra_slow_in;

			public static int fragment_open_enter;

			public static int fragment_open_exit;

			static Animation()
			{
				abc_fade_in = 2130771968;
				abc_fade_out = 2130771969;
				abc_grow_fade_in_from_bottom = 2130771970;
				abc_popup_enter = 2130771971;
				abc_popup_exit = 2130771972;
				abc_shrink_fade_out_from_bottom = 2130771973;
				abc_slide_in_bottom = 2130771974;
				abc_slide_in_top = 2130771975;
				abc_slide_out_bottom = 2130771976;
				abc_slide_out_top = 2130771977;
				abc_tooltip_enter = 2130771978;
				abc_tooltip_exit = 2130771979;
				btn_checkbox_to_checked_box_inner_merged_animation = 2130771980;
				btn_checkbox_to_checked_box_outer_merged_animation = 2130771981;
				btn_checkbox_to_checked_icon_null_animation = 2130771982;
				btn_checkbox_to_unchecked_box_inner_merged_animation = 2130771983;
				btn_checkbox_to_unchecked_check_path_merged_animation = 2130771984;
				btn_checkbox_to_unchecked_icon_null_animation = 2130771985;
				btn_radio_to_off_mtrl_dot_group_animation = 2130771986;
				btn_radio_to_off_mtrl_ring_outer_animation = 2130771987;
				btn_radio_to_off_mtrl_ring_outer_path_animation = 2130771988;
				btn_radio_to_on_mtrl_dot_group_animation = 2130771989;
				btn_radio_to_on_mtrl_ring_outer_animation = 2130771990;
				btn_radio_to_on_mtrl_ring_outer_path_animation = 2130771991;
				fragment_close_enter = 2130771992;
				fragment_close_exit = 2130771993;
				fragment_fade_enter = 2130771994;
				fragment_fade_exit = 2130771995;
				fragment_fast_out_extra_slow_in = 2130771996;
				fragment_open_enter = 2130771997;
				fragment_open_exit = 2130771998;
				ResourceIdManager.UpdateIdValues();
			}

			private Animation()
			{
			}
		}

		public class Attribute
		{
			public static int actionBarDivider;

			public static int actionBarItemBackground;

			public static int actionBarPopupTheme;

			public static int actionBarSize;

			public static int actionBarSplitStyle;

			public static int actionBarStyle;

			public static int actionBarTabBarStyle;

			public static int actionBarTabStyle;

			public static int actionBarTabTextStyle;

			public static int actionBarTheme;

			public static int actionBarWidgetTheme;

			public static int actionButtonStyle;

			public static int actionDropDownStyle;

			public static int actionLayout;

			public static int actionMenuTextAppearance;

			public static int actionMenuTextColor;

			public static int actionModeBackground;

			public static int actionModeCloseButtonStyle;

			public static int actionModeCloseDrawable;

			public static int actionModeCopyDrawable;

			public static int actionModeCutDrawable;

			public static int actionModeFindDrawable;

			public static int actionModePasteDrawable;

			public static int actionModePopupWindowStyle;

			public static int actionModeSelectAllDrawable;

			public static int actionModeShareDrawable;

			public static int actionModeSplitBackground;

			public static int actionModeStyle;

			public static int actionModeWebSearchDrawable;

			public static int actionOverflowButtonStyle;

			public static int actionOverflowMenuStyle;

			public static int actionProviderClass;

			public static int actionViewClass;

			public static int activityChooserViewStyle;

			public static int alertDialogButtonGroupStyle;

			public static int alertDialogCenterButtons;

			public static int alertDialogStyle;

			public static int alertDialogTheme;

			public static int allowStacking;

			public static int alpha;

			public static int alphabeticModifiers;

			public static int arrowHeadLength;

			public static int arrowShaftLength;

			public static int autoCompleteTextViewStyle;

			public static int autoSizeMaxTextSize;

			public static int autoSizeMinTextSize;

			public static int autoSizePresetSizes;

			public static int autoSizeStepGranularity;

			public static int autoSizeTextType;

			public static int background;

			public static int backgroundSplit;

			public static int backgroundStacked;

			public static int backgroundTint;

			public static int backgroundTintMode;

			public static int barLength;

			public static int borderlessButtonStyle;

			public static int buttonBarButtonStyle;

			public static int buttonBarNegativeButtonStyle;

			public static int buttonBarNeutralButtonStyle;

			public static int buttonBarPositiveButtonStyle;

			public static int buttonBarStyle;

			public static int buttonCompat;

			public static int buttonGravity;

			public static int buttonIconDimen;

			public static int buttonPanelSideLayout;

			public static int buttonStyle;

			public static int buttonStyleSmall;

			public static int buttonTint;

			public static int buttonTintMode;

			public static int checkboxStyle;

			public static int checkedTextViewStyle;

			public static int closeIcon;

			public static int closeItemLayout;

			public static int collapseContentDescription;

			public static int collapseIcon;

			public static int color;

			public static int colorAccent;

			public static int colorBackgroundFloating;

			public static int colorButtonNormal;

			public static int colorControlActivated;

			public static int colorControlHighlight;

			public static int colorControlNormal;

			public static int colorError;

			public static int colorPrimary;

			public static int colorPrimaryDark;

			public static int colorSwitchThumbNormal;

			public static int commitIcon;

			public static int contentDescription;

			public static int contentInsetEnd;

			public static int contentInsetEndWithActions;

			public static int contentInsetLeft;

			public static int contentInsetRight;

			public static int contentInsetStart;

			public static int contentInsetStartWithNavigation;

			public static int controlBackground;

			public static int coordinatorLayoutStyle;

			public static int customNavigationLayout;

			public static int defaultQueryHint;

			public static int dialogCornerRadius;

			public static int dialogPreferredPadding;

			public static int dialogTheme;

			public static int displayOptions;

			public static int divider;

			public static int dividerHorizontal;

			public static int dividerPadding;

			public static int dividerVertical;

			public static int drawableBottomCompat;

			public static int drawableEndCompat;

			public static int drawableLeftCompat;

			public static int drawableRightCompat;

			public static int drawableSize;

			public static int drawableStartCompat;

			public static int drawableTint;

			public static int drawableTintMode;

			public static int drawableTopCompat;

			public static int drawerArrowStyle;

			public static int dropdownListPreferredItemHeight;

			public static int dropDownListViewStyle;

			public static int editTextBackground;

			public static int editTextColor;

			public static int editTextStyle;

			public static int elevation;

			public static int expandActivityOverflowButtonDrawable;

			public static int fastScrollEnabled;

			public static int fastScrollHorizontalThumbDrawable;

			public static int fastScrollHorizontalTrackDrawable;

			public static int fastScrollVerticalThumbDrawable;

			public static int fastScrollVerticalTrackDrawable;

			public static int firstBaselineToTopHeight;

			public static int font;

			public static int fontFamily;

			public static int fontProviderAuthority;

			public static int fontProviderCerts;

			public static int fontProviderFetchStrategy;

			public static int fontProviderFetchTimeout;

			public static int fontProviderPackage;

			public static int fontProviderQuery;

			public static int fontStyle;

			public static int fontVariationSettings;

			public static int fontWeight;

			public static int gapBetweenBars;

			public static int goIcon;

			public static int height;

			public static int hideOnContentScroll;

			public static int homeAsUpIndicator;

			public static int homeLayout;

			public static int icon;

			public static int iconifiedByDefault;

			public static int iconTint;

			public static int iconTintMode;

			public static int imageButtonStyle;

			public static int indeterminateProgressStyle;

			public static int initialActivityCount;

			public static int isLightTheme;

			public static int itemPadding;

			public static int keylines;

			public static int lastBaselineToBottomHeight;

			public static int layout;

			public static int layoutManager;

			public static int layout_anchor;

			public static int layout_anchorGravity;

			public static int layout_behavior;

			public static int layout_dodgeInsetEdges;

			public static int layout_insetEdge;

			public static int layout_keyline;

			public static int lineHeight;

			public static int listChoiceBackgroundIndicator;

			public static int listChoiceIndicatorMultipleAnimated;

			public static int listChoiceIndicatorSingleAnimated;

			public static int listDividerAlertDialog;

			public static int listItemLayout;

			public static int listLayout;

			public static int listMenuViewStyle;

			public static int listPopupWindowStyle;

			public static int listPreferredItemHeight;

			public static int listPreferredItemHeightLarge;

			public static int listPreferredItemHeightSmall;

			public static int listPreferredItemPaddingEnd;

			public static int listPreferredItemPaddingLeft;

			public static int listPreferredItemPaddingRight;

			public static int listPreferredItemPaddingStart;

			public static int logo;

			public static int logoDescription;

			public static int maxButtonHeight;

			public static int measureWithLargestChild;

			public static int menu;

			public static int multiChoiceItemLayout;

			public static int MvxBind;

			public static int MvxDropDownItemTemplate;

			public static int MvxGroupItemTemplate;

			public static int MvxItemTemplate;

			public static int MvxLang;

			public static int MvxSource;

			public static int MvxTemplate;

			public static int MvxTemplateSelector;

			public static int navigationContentDescription;

			public static int navigationIcon;

			public static int navigationMode;

			public static int numericModifiers;

			public static int overlapAnchor;

			public static int paddingBottomNoButtons;

			public static int paddingEnd;

			public static int paddingStart;

			public static int paddingTopNoTitle;

			public static int panelBackground;

			public static int panelMenuListTheme;

			public static int panelMenuListWidth;

			public static int popupMenuStyle;

			public static int popupTheme;

			public static int popupWindowStyle;

			public static int preserveIconSpacing;

			public static int progressBarPadding;

			public static int progressBarStyle;

			public static int queryBackground;

			public static int queryHint;

			public static int radioButtonStyle;

			public static int ratingBarStyle;

			public static int ratingBarStyleIndicator;

			public static int ratingBarStyleSmall;

			public static int recyclerViewStyle;

			public static int reverseLayout;

			public static int searchHintIcon;

			public static int searchIcon;

			public static int searchViewStyle;

			public static int seekBarStyle;

			public static int selectableItemBackground;

			public static int selectableItemBackgroundBorderless;

			public static int showAsAction;

			public static int showDividers;

			public static int showText;

			public static int showTitle;

			public static int singleChoiceItemLayout;

			public static int spanCount;

			public static int spinBars;

			public static int spinnerDropDownItemStyle;

			public static int spinnerStyle;

			public static int splitTrack;

			public static int srcCompat;

			public static int stackFromEnd;

			public static int state_above_anchor;

			public static int statusBarBackground;

			public static int subMenuArrow;

			public static int submitBackground;

			public static int subtitle;

			public static int subtitleTextAppearance;

			public static int subtitleTextColor;

			public static int subtitleTextStyle;

			public static int suggestionRowLayout;

			public static int switchMinWidth;

			public static int switchPadding;

			public static int switchStyle;

			public static int switchTextAppearance;

			public static int textAllCaps;

			public static int textAppearanceLargePopupMenu;

			public static int textAppearanceListItem;

			public static int textAppearanceListItemSecondary;

			public static int textAppearanceListItemSmall;

			public static int textAppearancePopupMenuHeader;

			public static int textAppearanceSearchResultSubtitle;

			public static int textAppearanceSearchResultTitle;

			public static int textAppearanceSmallPopupMenu;

			public static int textColorAlertDialogListItem;

			public static int textColorSearchUrl;

			public static int textLocale;

			public static int theme;

			public static int thickness;

			public static int thumbTextPadding;

			public static int thumbTint;

			public static int thumbTintMode;

			public static int tickMark;

			public static int tickMarkTint;

			public static int tickMarkTintMode;

			public static int tint;

			public static int tintMode;

			public static int title;

			public static int titleMargin;

			public static int titleMarginBottom;

			public static int titleMarginEnd;

			public static int titleMargins;

			public static int titleMarginStart;

			public static int titleMarginTop;

			public static int titleTextAppearance;

			public static int titleTextColor;

			public static int titleTextStyle;

			public static int toolbarNavigationButtonStyle;

			public static int toolbarStyle;

			public static int tooltipForegroundColor;

			public static int tooltipFrameBackground;

			public static int tooltipText;

			public static int track;

			public static int trackTint;

			public static int trackTintMode;

			public static int ttcIndex;

			public static int viewInflaterClass;

			public static int voiceIcon;

			public static int windowActionBar;

			public static int windowActionBarOverlay;

			public static int windowActionModeOverlay;

			public static int windowFixedHeightMajor;

			public static int windowFixedHeightMinor;

			public static int windowFixedWidthMajor;

			public static int windowFixedWidthMinor;

			public static int windowMinWidthMajor;

			public static int windowMinWidthMinor;

			public static int windowNoTitle;

			static Attribute()
			{
				actionBarDivider = 2130837512;
				actionBarItemBackground = 2130837513;
				actionBarPopupTheme = 2130837514;
				actionBarSize = 2130837515;
				actionBarSplitStyle = 2130837516;
				actionBarStyle = 2130837517;
				actionBarTabBarStyle = 2130837518;
				actionBarTabStyle = 2130837519;
				actionBarTabTextStyle = 2130837520;
				actionBarTheme = 2130837521;
				actionBarWidgetTheme = 2130837522;
				actionButtonStyle = 2130837523;
				actionDropDownStyle = 2130837524;
				actionLayout = 2130837525;
				actionMenuTextAppearance = 2130837526;
				actionMenuTextColor = 2130837527;
				actionModeBackground = 2130837528;
				actionModeCloseButtonStyle = 2130837529;
				actionModeCloseDrawable = 2130837530;
				actionModeCopyDrawable = 2130837531;
				actionModeCutDrawable = 2130837532;
				actionModeFindDrawable = 2130837533;
				actionModePasteDrawable = 2130837534;
				actionModePopupWindowStyle = 2130837535;
				actionModeSelectAllDrawable = 2130837536;
				actionModeShareDrawable = 2130837537;
				actionModeSplitBackground = 2130837538;
				actionModeStyle = 2130837539;
				actionModeWebSearchDrawable = 2130837540;
				actionOverflowButtonStyle = 2130837541;
				actionOverflowMenuStyle = 2130837542;
				actionProviderClass = 2130837543;
				actionViewClass = 2130837544;
				activityChooserViewStyle = 2130837545;
				alertDialogButtonGroupStyle = 2130837546;
				alertDialogCenterButtons = 2130837547;
				alertDialogStyle = 2130837548;
				alertDialogTheme = 2130837549;
				allowStacking = 2130837550;
				alpha = 2130837551;
				alphabeticModifiers = 2130837552;
				arrowHeadLength = 2130837553;
				arrowShaftLength = 2130837554;
				autoCompleteTextViewStyle = 2130837555;
				autoSizeMaxTextSize = 2130837556;
				autoSizeMinTextSize = 2130837557;
				autoSizePresetSizes = 2130837558;
				autoSizeStepGranularity = 2130837559;
				autoSizeTextType = 2130837560;
				background = 2130837561;
				backgroundSplit = 2130837562;
				backgroundStacked = 2130837563;
				backgroundTint = 2130837564;
				backgroundTintMode = 2130837565;
				barLength = 2130837566;
				borderlessButtonStyle = 2130837567;
				buttonBarButtonStyle = 2130837568;
				buttonBarNegativeButtonStyle = 2130837569;
				buttonBarNeutralButtonStyle = 2130837570;
				buttonBarPositiveButtonStyle = 2130837571;
				buttonBarStyle = 2130837572;
				buttonCompat = 2130837573;
				buttonGravity = 2130837574;
				buttonIconDimen = 2130837575;
				buttonPanelSideLayout = 2130837576;
				buttonStyle = 2130837577;
				buttonStyleSmall = 2130837578;
				buttonTint = 2130837579;
				buttonTintMode = 2130837580;
				checkboxStyle = 2130837581;
				checkedTextViewStyle = 2130837582;
				closeIcon = 2130837583;
				closeItemLayout = 2130837584;
				collapseContentDescription = 2130837585;
				collapseIcon = 2130837586;
				color = 2130837587;
				colorAccent = 2130837588;
				colorBackgroundFloating = 2130837589;
				colorButtonNormal = 2130837590;
				colorControlActivated = 2130837591;
				colorControlHighlight = 2130837592;
				colorControlNormal = 2130837593;
				colorError = 2130837594;
				colorPrimary = 2130837595;
				colorPrimaryDark = 2130837596;
				colorSwitchThumbNormal = 2130837597;
				commitIcon = 2130837598;
				contentDescription = 2130837599;
				contentInsetEnd = 2130837600;
				contentInsetEndWithActions = 2130837601;
				contentInsetLeft = 2130837602;
				contentInsetRight = 2130837603;
				contentInsetStart = 2130837604;
				contentInsetStartWithNavigation = 2130837605;
				controlBackground = 2130837606;
				coordinatorLayoutStyle = 2130837607;
				customNavigationLayout = 2130837608;
				defaultQueryHint = 2130837609;
				dialogCornerRadius = 2130837610;
				dialogPreferredPadding = 2130837611;
				dialogTheme = 2130837612;
				displayOptions = 2130837613;
				divider = 2130837614;
				dividerHorizontal = 2130837615;
				dividerPadding = 2130837616;
				dividerVertical = 2130837617;
				drawableBottomCompat = 2130837618;
				drawableEndCompat = 2130837619;
				drawableLeftCompat = 2130837620;
				drawableRightCompat = 2130837621;
				drawableSize = 2130837622;
				drawableStartCompat = 2130837623;
				drawableTint = 2130837624;
				drawableTintMode = 2130837625;
				drawableTopCompat = 2130837626;
				drawerArrowStyle = 2130837627;
				dropdownListPreferredItemHeight = 2130837629;
				dropDownListViewStyle = 2130837628;
				editTextBackground = 2130837630;
				editTextColor = 2130837631;
				editTextStyle = 2130837632;
				elevation = 2130837633;
				expandActivityOverflowButtonDrawable = 2130837634;
				fastScrollEnabled = 2130837635;
				fastScrollHorizontalThumbDrawable = 2130837636;
				fastScrollHorizontalTrackDrawable = 2130837637;
				fastScrollVerticalThumbDrawable = 2130837638;
				fastScrollVerticalTrackDrawable = 2130837639;
				firstBaselineToTopHeight = 2130837640;
				font = 2130837641;
				fontFamily = 2130837642;
				fontProviderAuthority = 2130837643;
				fontProviderCerts = 2130837644;
				fontProviderFetchStrategy = 2130837645;
				fontProviderFetchTimeout = 2130837646;
				fontProviderPackage = 2130837647;
				fontProviderQuery = 2130837648;
				fontStyle = 2130837649;
				fontVariationSettings = 2130837650;
				fontWeight = 2130837651;
				gapBetweenBars = 2130837652;
				goIcon = 2130837653;
				height = 2130837654;
				hideOnContentScroll = 2130837655;
				homeAsUpIndicator = 2130837656;
				homeLayout = 2130837657;
				icon = 2130837658;
				iconifiedByDefault = 2130837661;
				iconTint = 2130837659;
				iconTintMode = 2130837660;
				imageButtonStyle = 2130837662;
				indeterminateProgressStyle = 2130837663;
				initialActivityCount = 2130837664;
				isLightTheme = 2130837665;
				itemPadding = 2130837666;
				keylines = 2130837667;
				lastBaselineToBottomHeight = 2130837668;
				layout = 2130837669;
				layoutManager = 2130837670;
				layout_anchor = 2130837671;
				layout_anchorGravity = 2130837672;
				layout_behavior = 2130837673;
				layout_dodgeInsetEdges = 2130837674;
				layout_insetEdge = 2130837675;
				layout_keyline = 2130837676;
				lineHeight = 2130837677;
				listChoiceBackgroundIndicator = 2130837678;
				listChoiceIndicatorMultipleAnimated = 2130837679;
				listChoiceIndicatorSingleAnimated = 2130837680;
				listDividerAlertDialog = 2130837681;
				listItemLayout = 2130837682;
				listLayout = 2130837683;
				listMenuViewStyle = 2130837684;
				listPopupWindowStyle = 2130837685;
				listPreferredItemHeight = 2130837686;
				listPreferredItemHeightLarge = 2130837687;
				listPreferredItemHeightSmall = 2130837688;
				listPreferredItemPaddingEnd = 2130837689;
				listPreferredItemPaddingLeft = 2130837690;
				listPreferredItemPaddingRight = 2130837691;
				listPreferredItemPaddingStart = 2130837692;
				logo = 2130837693;
				logoDescription = 2130837694;
				maxButtonHeight = 2130837695;
				measureWithLargestChild = 2130837696;
				menu = 2130837697;
				multiChoiceItemLayout = 2130837698;
				MvxBind = 2130837504;
				MvxDropDownItemTemplate = 2130837505;
				MvxGroupItemTemplate = 2130837506;
				MvxItemTemplate = 2130837507;
				MvxLang = 2130837508;
				MvxSource = 2130837509;
				MvxTemplate = 2130837510;
				MvxTemplateSelector = 2130837511;
				navigationContentDescription = 2130837699;
				navigationIcon = 2130837700;
				navigationMode = 2130837701;
				numericModifiers = 2130837702;
				overlapAnchor = 2130837703;
				paddingBottomNoButtons = 2130837704;
				paddingEnd = 2130837705;
				paddingStart = 2130837706;
				paddingTopNoTitle = 2130837707;
				panelBackground = 2130837708;
				panelMenuListTheme = 2130837709;
				panelMenuListWidth = 2130837710;
				popupMenuStyle = 2130837711;
				popupTheme = 2130837712;
				popupWindowStyle = 2130837713;
				preserveIconSpacing = 2130837714;
				progressBarPadding = 2130837715;
				progressBarStyle = 2130837716;
				queryBackground = 2130837717;
				queryHint = 2130837718;
				radioButtonStyle = 2130837719;
				ratingBarStyle = 2130837720;
				ratingBarStyleIndicator = 2130837721;
				ratingBarStyleSmall = 2130837722;
				recyclerViewStyle = 2130837723;
				reverseLayout = 2130837724;
				searchHintIcon = 2130837725;
				searchIcon = 2130837726;
				searchViewStyle = 2130837727;
				seekBarStyle = 2130837728;
				selectableItemBackground = 2130837729;
				selectableItemBackgroundBorderless = 2130837730;
				showAsAction = 2130837731;
				showDividers = 2130837732;
				showText = 2130837733;
				showTitle = 2130837734;
				singleChoiceItemLayout = 2130837735;
				spanCount = 2130837736;
				spinBars = 2130837737;
				spinnerDropDownItemStyle = 2130837738;
				spinnerStyle = 2130837739;
				splitTrack = 2130837740;
				srcCompat = 2130837741;
				stackFromEnd = 2130837742;
				state_above_anchor = 2130837743;
				statusBarBackground = 2130837744;
				subMenuArrow = 2130837745;
				submitBackground = 2130837746;
				subtitle = 2130837747;
				subtitleTextAppearance = 2130837748;
				subtitleTextColor = 2130837749;
				subtitleTextStyle = 2130837750;
				suggestionRowLayout = 2130837751;
				switchMinWidth = 2130837752;
				switchPadding = 2130837753;
				switchStyle = 2130837754;
				switchTextAppearance = 2130837755;
				textAllCaps = 2130837756;
				textAppearanceLargePopupMenu = 2130837757;
				textAppearanceListItem = 2130837758;
				textAppearanceListItemSecondary = 2130837759;
				textAppearanceListItemSmall = 2130837760;
				textAppearancePopupMenuHeader = 2130837761;
				textAppearanceSearchResultSubtitle = 2130837762;
				textAppearanceSearchResultTitle = 2130837763;
				textAppearanceSmallPopupMenu = 2130837764;
				textColorAlertDialogListItem = 2130837765;
				textColorSearchUrl = 2130837766;
				textLocale = 2130837767;
				theme = 2130837768;
				thickness = 2130837769;
				thumbTextPadding = 2130837770;
				thumbTint = 2130837771;
				thumbTintMode = 2130837772;
				tickMark = 2130837773;
				tickMarkTint = 2130837774;
				tickMarkTintMode = 2130837775;
				tint = 2130837776;
				tintMode = 2130837777;
				title = 2130837778;
				titleMargin = 2130837779;
				titleMarginBottom = 2130837780;
				titleMarginEnd = 2130837781;
				titleMargins = 2130837784;
				titleMarginStart = 2130837782;
				titleMarginTop = 2130837783;
				titleTextAppearance = 2130837785;
				titleTextColor = 2130837786;
				titleTextStyle = 2130837787;
				toolbarNavigationButtonStyle = 2130837788;
				toolbarStyle = 2130837789;
				tooltipForegroundColor = 2130837790;
				tooltipFrameBackground = 2130837791;
				tooltipText = 2130837792;
				track = 2130837793;
				trackTint = 2130837794;
				trackTintMode = 2130837795;
				ttcIndex = 2130837796;
				viewInflaterClass = 2130837797;
				voiceIcon = 2130837798;
				windowActionBar = 2130837799;
				windowActionBarOverlay = 2130837800;
				windowActionModeOverlay = 2130837801;
				windowFixedHeightMajor = 2130837802;
				windowFixedHeightMinor = 2130837803;
				windowFixedWidthMajor = 2130837804;
				windowFixedWidthMinor = 2130837805;
				windowMinWidthMajor = 2130837806;
				windowMinWidthMinor = 2130837807;
				windowNoTitle = 2130837808;
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		public class Boolean
		{
			public static int abc_action_bar_embed_tabs;

			public static int abc_allow_stacked_button_bar;

			public static int abc_config_actionMenuItemAllCaps;

			static Boolean()
			{
				abc_action_bar_embed_tabs = 2130903040;
				abc_allow_stacked_button_bar = 2130903041;
				abc_config_actionMenuItemAllCaps = 2130903042;
				ResourceIdManager.UpdateIdValues();
			}

			private Boolean()
			{
			}
		}

		public class Color
		{
			public static int abc_background_cache_hint_selector_material_dark;

			public static int abc_background_cache_hint_selector_material_light;

			public static int abc_btn_colored_borderless_text_material;

			public static int abc_btn_colored_text_material;

			public static int abc_color_highlight_material;

			public static int abc_decor_view_status_guard;

			public static int abc_decor_view_status_guard_light;

			public static int abc_hint_foreground_material_dark;

			public static int abc_hint_foreground_material_light;

			public static int abc_primary_text_disable_only_material_dark;

			public static int abc_primary_text_disable_only_material_light;

			public static int abc_primary_text_material_dark;

			public static int abc_primary_text_material_light;

			public static int abc_search_url_text;

			public static int abc_search_url_text_normal;

			public static int abc_search_url_text_pressed;

			public static int abc_search_url_text_selected;

			public static int abc_secondary_text_material_dark;

			public static int abc_secondary_text_material_light;

			public static int abc_tint_btn_checkable;

			public static int abc_tint_default;

			public static int abc_tint_edittext;

			public static int abc_tint_seek_thumb;

			public static int abc_tint_spinner;

			public static int abc_tint_switch_track;

			public static int accent_material_dark;

			public static int accent_material_light;

			public static int androidx_core_ripple_material_light;

			public static int androidx_core_secondary_text_default_material_light;

			public static int background_floating_material_dark;

			public static int background_floating_material_light;

			public static int background_material_dark;

			public static int background_material_light;

			public static int bright_foreground_disabled_material_dark;

			public static int bright_foreground_disabled_material_light;

			public static int bright_foreground_inverse_material_dark;

			public static int bright_foreground_inverse_material_light;

			public static int bright_foreground_material_dark;

			public static int bright_foreground_material_light;

			public static int button_material_dark;

			public static int button_material_light;

			public static int dim_foreground_disabled_material_dark;

			public static int dim_foreground_disabled_material_light;

			public static int dim_foreground_material_dark;

			public static int dim_foreground_material_light;

			public static int error_color_material_dark;

			public static int error_color_material_light;

			public static int foreground_material_dark;

			public static int foreground_material_light;

			public static int highlighted_text_material_dark;

			public static int highlighted_text_material_light;

			public static int material_blue_grey_800;

			public static int material_blue_grey_900;

			public static int material_blue_grey_950;

			public static int material_deep_teal_200;

			public static int material_deep_teal_500;

			public static int material_grey_100;

			public static int material_grey_300;

			public static int material_grey_50;

			public static int material_grey_600;

			public static int material_grey_800;

			public static int material_grey_850;

			public static int material_grey_900;

			public static int notification_action_color_filter;

			public static int notification_icon_bg_color;

			public static int primary_dark_material_dark;

			public static int primary_dark_material_light;

			public static int primary_material_dark;

			public static int primary_material_light;

			public static int primary_text_default_material_dark;

			public static int primary_text_default_material_light;

			public static int primary_text_disabled_material_dark;

			public static int primary_text_disabled_material_light;

			public static int ripple_material_dark;

			public static int ripple_material_light;

			public static int secondary_text_default_material_dark;

			public static int secondary_text_default_material_light;

			public static int secondary_text_disabled_material_dark;

			public static int secondary_text_disabled_material_light;

			public static int switch_thumb_disabled_material_dark;

			public static int switch_thumb_disabled_material_light;

			public static int switch_thumb_material_dark;

			public static int switch_thumb_material_light;

			public static int switch_thumb_normal_material_dark;

			public static int switch_thumb_normal_material_light;

			public static int tooltip_background_dark;

			public static int tooltip_background_light;

			static Color()
			{
				abc_background_cache_hint_selector_material_dark = 2130968576;
				abc_background_cache_hint_selector_material_light = 2130968577;
				abc_btn_colored_borderless_text_material = 2130968578;
				abc_btn_colored_text_material = 2130968579;
				abc_color_highlight_material = 2130968580;
				abc_decor_view_status_guard = 2130968581;
				abc_decor_view_status_guard_light = 2130968582;
				abc_hint_foreground_material_dark = 2130968583;
				abc_hint_foreground_material_light = 2130968584;
				abc_primary_text_disable_only_material_dark = 2130968585;
				abc_primary_text_disable_only_material_light = 2130968586;
				abc_primary_text_material_dark = 2130968587;
				abc_primary_text_material_light = 2130968588;
				abc_search_url_text = 2130968589;
				abc_search_url_text_normal = 2130968590;
				abc_search_url_text_pressed = 2130968591;
				abc_search_url_text_selected = 2130968592;
				abc_secondary_text_material_dark = 2130968593;
				abc_secondary_text_material_light = 2130968594;
				abc_tint_btn_checkable = 2130968595;
				abc_tint_default = 2130968596;
				abc_tint_edittext = 2130968597;
				abc_tint_seek_thumb = 2130968598;
				abc_tint_spinner = 2130968599;
				abc_tint_switch_track = 2130968600;
				accent_material_dark = 2130968601;
				accent_material_light = 2130968602;
				androidx_core_ripple_material_light = 2130968603;
				androidx_core_secondary_text_default_material_light = 2130968604;
				background_floating_material_dark = 2130968605;
				background_floating_material_light = 2130968606;
				background_material_dark = 2130968607;
				background_material_light = 2130968608;
				bright_foreground_disabled_material_dark = 2130968609;
				bright_foreground_disabled_material_light = 2130968610;
				bright_foreground_inverse_material_dark = 2130968611;
				bright_foreground_inverse_material_light = 2130968612;
				bright_foreground_material_dark = 2130968613;
				bright_foreground_material_light = 2130968614;
				button_material_dark = 2130968615;
				button_material_light = 2130968616;
				dim_foreground_disabled_material_dark = 2130968617;
				dim_foreground_disabled_material_light = 2130968618;
				dim_foreground_material_dark = 2130968619;
				dim_foreground_material_light = 2130968620;
				error_color_material_dark = 2130968621;
				error_color_material_light = 2130968622;
				foreground_material_dark = 2130968623;
				foreground_material_light = 2130968624;
				highlighted_text_material_dark = 2130968625;
				highlighted_text_material_light = 2130968626;
				material_blue_grey_800 = 2130968627;
				material_blue_grey_900 = 2130968628;
				material_blue_grey_950 = 2130968629;
				material_deep_teal_200 = 2130968630;
				material_deep_teal_500 = 2130968631;
				material_grey_100 = 2130968632;
				material_grey_300 = 2130968633;
				material_grey_50 = 2130968634;
				material_grey_600 = 2130968635;
				material_grey_800 = 2130968636;
				material_grey_850 = 2130968637;
				material_grey_900 = 2130968638;
				notification_action_color_filter = 2130968639;
				notification_icon_bg_color = 2130968640;
				primary_dark_material_dark = 2130968641;
				primary_dark_material_light = 2130968642;
				primary_material_dark = 2130968643;
				primary_material_light = 2130968644;
				primary_text_default_material_dark = 2130968645;
				primary_text_default_material_light = 2130968646;
				primary_text_disabled_material_dark = 2130968647;
				primary_text_disabled_material_light = 2130968648;
				ripple_material_dark = 2130968649;
				ripple_material_light = 2130968650;
				secondary_text_default_material_dark = 2130968651;
				secondary_text_default_material_light = 2130968652;
				secondary_text_disabled_material_dark = 2130968653;
				secondary_text_disabled_material_light = 2130968654;
				switch_thumb_disabled_material_dark = 2130968655;
				switch_thumb_disabled_material_light = 2130968656;
				switch_thumb_material_dark = 2130968657;
				switch_thumb_material_light = 2130968658;
				switch_thumb_normal_material_dark = 2130968659;
				switch_thumb_normal_material_light = 2130968660;
				tooltip_background_dark = 2130968661;
				tooltip_background_light = 2130968662;
				ResourceIdManager.UpdateIdValues();
			}

			private Color()
			{
			}
		}

		public class Dimension
		{
			public static int abc_action_bar_content_inset_material;

			public static int abc_action_bar_content_inset_with_nav;

			public static int abc_action_bar_default_height_material;

			public static int abc_action_bar_default_padding_end_material;

			public static int abc_action_bar_default_padding_start_material;

			public static int abc_action_bar_elevation_material;

			public static int abc_action_bar_icon_vertical_padding_material;

			public static int abc_action_bar_overflow_padding_end_material;

			public static int abc_action_bar_overflow_padding_start_material;

			public static int abc_action_bar_stacked_max_height;

			public static int abc_action_bar_stacked_tab_max_width;

			public static int abc_action_bar_subtitle_bottom_margin_material;

			public static int abc_action_bar_subtitle_top_margin_material;

			public static int abc_action_button_min_height_material;

			public static int abc_action_button_min_width_material;

			public static int abc_action_button_min_width_overflow_material;

			public static int abc_alert_dialog_button_bar_height;

			public static int abc_alert_dialog_button_dimen;

			public static int abc_button_inset_horizontal_material;

			public static int abc_button_inset_vertical_material;

			public static int abc_button_padding_horizontal_material;

			public static int abc_button_padding_vertical_material;

			public static int abc_cascading_menus_min_smallest_width;

			public static int abc_config_prefDialogWidth;

			public static int abc_control_corner_material;

			public static int abc_control_inset_material;

			public static int abc_control_padding_material;

			public static int abc_dialog_corner_radius_material;

			public static int abc_dialog_fixed_height_major;

			public static int abc_dialog_fixed_height_minor;

			public static int abc_dialog_fixed_width_major;

			public static int abc_dialog_fixed_width_minor;

			public static int abc_dialog_list_padding_bottom_no_buttons;

			public static int abc_dialog_list_padding_top_no_title;

			public static int abc_dialog_min_width_major;

			public static int abc_dialog_min_width_minor;

			public static int abc_dialog_padding_material;

			public static int abc_dialog_padding_top_material;

			public static int abc_dialog_title_divider_material;

			public static int abc_disabled_alpha_material_dark;

			public static int abc_disabled_alpha_material_light;

			public static int abc_dropdownitem_icon_width;

			public static int abc_dropdownitem_text_padding_left;

			public static int abc_dropdownitem_text_padding_right;

			public static int abc_edit_text_inset_bottom_material;

			public static int abc_edit_text_inset_horizontal_material;

			public static int abc_edit_text_inset_top_material;

			public static int abc_floating_window_z;

			public static int abc_list_item_height_large_material;

			public static int abc_list_item_height_material;

			public static int abc_list_item_height_small_material;

			public static int abc_list_item_padding_horizontal_material;

			public static int abc_panel_menu_list_width;

			public static int abc_progress_bar_height_material;

			public static int abc_search_view_preferred_height;

			public static int abc_search_view_preferred_width;

			public static int abc_seekbar_track_background_height_material;

			public static int abc_seekbar_track_progress_height_material;

			public static int abc_select_dialog_padding_start_material;

			public static int abc_switch_padding;

			public static int abc_text_size_body_1_material;

			public static int abc_text_size_body_2_material;

			public static int abc_text_size_button_material;

			public static int abc_text_size_caption_material;

			public static int abc_text_size_display_1_material;

			public static int abc_text_size_display_2_material;

			public static int abc_text_size_display_3_material;

			public static int abc_text_size_display_4_material;

			public static int abc_text_size_headline_material;

			public static int abc_text_size_large_material;

			public static int abc_text_size_medium_material;

			public static int abc_text_size_menu_header_material;

			public static int abc_text_size_menu_material;

			public static int abc_text_size_small_material;

			public static int abc_text_size_subhead_material;

			public static int abc_text_size_subtitle_material_toolbar;

			public static int abc_text_size_title_material;

			public static int abc_text_size_title_material_toolbar;

			public static int compat_button_inset_horizontal_material;

			public static int compat_button_inset_vertical_material;

			public static int compat_button_padding_horizontal_material;

			public static int compat_button_padding_vertical_material;

			public static int compat_control_corner_material;

			public static int compat_notification_large_icon_max_height;

			public static int compat_notification_large_icon_max_width;

			public static int disabled_alpha_material_dark;

			public static int disabled_alpha_material_light;

			public static int fastscroll_default_thickness;

			public static int fastscroll_margin;

			public static int fastscroll_minimum_range;

			public static int highlight_alpha_material_colored;

			public static int highlight_alpha_material_dark;

			public static int highlight_alpha_material_light;

			public static int hint_alpha_material_dark;

			public static int hint_alpha_material_light;

			public static int hint_pressed_alpha_material_dark;

			public static int hint_pressed_alpha_material_light;

			public static int item_touch_helper_max_drag_scroll_per_frame;

			public static int item_touch_helper_swipe_escape_max_velocity;

			public static int item_touch_helper_swipe_escape_velocity;

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

			public static int tooltip_corner_radius;

			public static int tooltip_horizontal_padding;

			public static int tooltip_margin;

			public static int tooltip_precise_anchor_extra_offset;

			public static int tooltip_precise_anchor_threshold;

			public static int tooltip_vertical_padding;

			public static int tooltip_y_offset_non_touch;

			public static int tooltip_y_offset_touch;

			static Dimension()
			{
				abc_action_bar_content_inset_material = 2131034112;
				abc_action_bar_content_inset_with_nav = 2131034113;
				abc_action_bar_default_height_material = 2131034114;
				abc_action_bar_default_padding_end_material = 2131034115;
				abc_action_bar_default_padding_start_material = 2131034116;
				abc_action_bar_elevation_material = 2131034117;
				abc_action_bar_icon_vertical_padding_material = 2131034118;
				abc_action_bar_overflow_padding_end_material = 2131034119;
				abc_action_bar_overflow_padding_start_material = 2131034120;
				abc_action_bar_stacked_max_height = 2131034121;
				abc_action_bar_stacked_tab_max_width = 2131034122;
				abc_action_bar_subtitle_bottom_margin_material = 2131034123;
				abc_action_bar_subtitle_top_margin_material = 2131034124;
				abc_action_button_min_height_material = 2131034125;
				abc_action_button_min_width_material = 2131034126;
				abc_action_button_min_width_overflow_material = 2131034127;
				abc_alert_dialog_button_bar_height = 2131034128;
				abc_alert_dialog_button_dimen = 2131034129;
				abc_button_inset_horizontal_material = 2131034130;
				abc_button_inset_vertical_material = 2131034131;
				abc_button_padding_horizontal_material = 2131034132;
				abc_button_padding_vertical_material = 2131034133;
				abc_cascading_menus_min_smallest_width = 2131034134;
				abc_config_prefDialogWidth = 2131034135;
				abc_control_corner_material = 2131034136;
				abc_control_inset_material = 2131034137;
				abc_control_padding_material = 2131034138;
				abc_dialog_corner_radius_material = 2131034139;
				abc_dialog_fixed_height_major = 2131034140;
				abc_dialog_fixed_height_minor = 2131034141;
				abc_dialog_fixed_width_major = 2131034142;
				abc_dialog_fixed_width_minor = 2131034143;
				abc_dialog_list_padding_bottom_no_buttons = 2131034144;
				abc_dialog_list_padding_top_no_title = 2131034145;
				abc_dialog_min_width_major = 2131034146;
				abc_dialog_min_width_minor = 2131034147;
				abc_dialog_padding_material = 2131034148;
				abc_dialog_padding_top_material = 2131034149;
				abc_dialog_title_divider_material = 2131034150;
				abc_disabled_alpha_material_dark = 2131034151;
				abc_disabled_alpha_material_light = 2131034152;
				abc_dropdownitem_icon_width = 2131034153;
				abc_dropdownitem_text_padding_left = 2131034154;
				abc_dropdownitem_text_padding_right = 2131034155;
				abc_edit_text_inset_bottom_material = 2131034156;
				abc_edit_text_inset_horizontal_material = 2131034157;
				abc_edit_text_inset_top_material = 2131034158;
				abc_floating_window_z = 2131034159;
				abc_list_item_height_large_material = 2131034160;
				abc_list_item_height_material = 2131034161;
				abc_list_item_height_small_material = 2131034162;
				abc_list_item_padding_horizontal_material = 2131034163;
				abc_panel_menu_list_width = 2131034164;
				abc_progress_bar_height_material = 2131034165;
				abc_search_view_preferred_height = 2131034166;
				abc_search_view_preferred_width = 2131034167;
				abc_seekbar_track_background_height_material = 2131034168;
				abc_seekbar_track_progress_height_material = 2131034169;
				abc_select_dialog_padding_start_material = 2131034170;
				abc_switch_padding = 2131034171;
				abc_text_size_body_1_material = 2131034172;
				abc_text_size_body_2_material = 2131034173;
				abc_text_size_button_material = 2131034174;
				abc_text_size_caption_material = 2131034175;
				abc_text_size_display_1_material = 2131034176;
				abc_text_size_display_2_material = 2131034177;
				abc_text_size_display_3_material = 2131034178;
				abc_text_size_display_4_material = 2131034179;
				abc_text_size_headline_material = 2131034180;
				abc_text_size_large_material = 2131034181;
				abc_text_size_medium_material = 2131034182;
				abc_text_size_menu_header_material = 2131034183;
				abc_text_size_menu_material = 2131034184;
				abc_text_size_small_material = 2131034185;
				abc_text_size_subhead_material = 2131034186;
				abc_text_size_subtitle_material_toolbar = 2131034187;
				abc_text_size_title_material = 2131034188;
				abc_text_size_title_material_toolbar = 2131034189;
				compat_button_inset_horizontal_material = 2131034190;
				compat_button_inset_vertical_material = 2131034191;
				compat_button_padding_horizontal_material = 2131034192;
				compat_button_padding_vertical_material = 2131034193;
				compat_control_corner_material = 2131034194;
				compat_notification_large_icon_max_height = 2131034195;
				compat_notification_large_icon_max_width = 2131034196;
				disabled_alpha_material_dark = 2131034197;
				disabled_alpha_material_light = 2131034198;
				fastscroll_default_thickness = 2131034199;
				fastscroll_margin = 2131034200;
				fastscroll_minimum_range = 2131034201;
				highlight_alpha_material_colored = 2131034202;
				highlight_alpha_material_dark = 2131034203;
				highlight_alpha_material_light = 2131034204;
				hint_alpha_material_dark = 2131034205;
				hint_alpha_material_light = 2131034206;
				hint_pressed_alpha_material_dark = 2131034207;
				hint_pressed_alpha_material_light = 2131034208;
				item_touch_helper_max_drag_scroll_per_frame = 2131034209;
				item_touch_helper_swipe_escape_max_velocity = 2131034210;
				item_touch_helper_swipe_escape_velocity = 2131034211;
				notification_action_icon_size = 2131034212;
				notification_action_text_size = 2131034213;
				notification_big_circle_margin = 2131034214;
				notification_content_margin_start = 2131034215;
				notification_large_icon_height = 2131034216;
				notification_large_icon_width = 2131034217;
				notification_main_column_padding_top = 2131034218;
				notification_media_narrow_margin = 2131034219;
				notification_right_icon_size = 2131034220;
				notification_right_side_padding_top = 2131034221;
				notification_small_icon_background_padding = 2131034222;
				notification_small_icon_size_as_large = 2131034223;
				notification_subtext_size = 2131034224;
				notification_top_pad = 2131034225;
				notification_top_pad_large_text = 2131034226;
				tooltip_corner_radius = 2131034227;
				tooltip_horizontal_padding = 2131034228;
				tooltip_margin = 2131034229;
				tooltip_precise_anchor_extra_offset = 2131034230;
				tooltip_precise_anchor_threshold = 2131034231;
				tooltip_vertical_padding = 2131034232;
				tooltip_y_offset_non_touch = 2131034233;
				tooltip_y_offset_touch = 2131034234;
				ResourceIdManager.UpdateIdValues();
			}

			private Dimension()
			{
			}
		}

		public class Drawable
		{
			public static int abc_ab_share_pack_mtrl_alpha;

			public static int abc_action_bar_item_background_material;

			public static int abc_btn_borderless_material;

			public static int abc_btn_check_material;

			public static int abc_btn_check_material_anim;

			public static int abc_btn_check_to_on_mtrl_000;

			public static int abc_btn_check_to_on_mtrl_015;

			public static int abc_btn_colored_material;

			public static int abc_btn_default_mtrl_shape;

			public static int abc_btn_radio_material;

			public static int abc_btn_radio_material_anim;

			public static int abc_btn_radio_to_on_mtrl_000;

			public static int abc_btn_radio_to_on_mtrl_015;

			public static int abc_btn_switch_to_on_mtrl_00001;

			public static int abc_btn_switch_to_on_mtrl_00012;

			public static int abc_cab_background_internal_bg;

			public static int abc_cab_background_top_material;

			public static int abc_cab_background_top_mtrl_alpha;

			public static int abc_control_background_material;

			public static int abc_dialog_material_background;

			public static int abc_edit_text_material;

			public static int abc_ic_ab_back_material;

			public static int abc_ic_arrow_drop_right_black_24dp;

			public static int abc_ic_clear_material;

			public static int abc_ic_commit_search_api_mtrl_alpha;

			public static int abc_ic_go_search_api_material;

			public static int abc_ic_menu_copy_mtrl_am_alpha;

			public static int abc_ic_menu_cut_mtrl_alpha;

			public static int abc_ic_menu_overflow_material;

			public static int abc_ic_menu_paste_mtrl_am_alpha;

			public static int abc_ic_menu_selectall_mtrl_alpha;

			public static int abc_ic_menu_share_mtrl_alpha;

			public static int abc_ic_search_api_material;

			public static int abc_ic_star_black_16dp;

			public static int abc_ic_star_black_36dp;

			public static int abc_ic_star_black_48dp;

			public static int abc_ic_star_half_black_16dp;

			public static int abc_ic_star_half_black_36dp;

			public static int abc_ic_star_half_black_48dp;

			public static int abc_ic_voice_search_api_material;

			public static int abc_item_background_holo_dark;

			public static int abc_item_background_holo_light;

			public static int abc_list_divider_material;

			public static int abc_list_divider_mtrl_alpha;

			public static int abc_list_focused_holo;

			public static int abc_list_longpressed_holo;

			public static int abc_list_pressed_holo_dark;

			public static int abc_list_pressed_holo_light;

			public static int abc_list_selector_background_transition_holo_dark;

			public static int abc_list_selector_background_transition_holo_light;

			public static int abc_list_selector_disabled_holo_dark;

			public static int abc_list_selector_disabled_holo_light;

			public static int abc_list_selector_holo_dark;

			public static int abc_list_selector_holo_light;

			public static int abc_menu_hardkey_panel_mtrl_mult;

			public static int abc_popup_background_mtrl_mult;

			public static int abc_ratingbar_indicator_material;

			public static int abc_ratingbar_material;

			public static int abc_ratingbar_small_material;

			public static int abc_scrubber_control_off_mtrl_alpha;

			public static int abc_scrubber_control_to_pressed_mtrl_000;

			public static int abc_scrubber_control_to_pressed_mtrl_005;

			public static int abc_scrubber_primary_mtrl_alpha;

			public static int abc_scrubber_track_mtrl_alpha;

			public static int abc_seekbar_thumb_material;

			public static int abc_seekbar_tick_mark_material;

			public static int abc_seekbar_track_material;

			public static int abc_spinner_mtrl_am_alpha;

			public static int abc_spinner_textfield_background_material;

			public static int abc_switch_thumb_material;

			public static int abc_switch_track_mtrl_alpha;

			public static int abc_tab_indicator_material;

			public static int abc_tab_indicator_mtrl_alpha;

			public static int abc_textfield_activated_mtrl_alpha;

			public static int abc_textfield_default_mtrl_alpha;

			public static int abc_textfield_search_activated_mtrl_alpha;

			public static int abc_textfield_search_default_mtrl_alpha;

			public static int abc_textfield_search_material;

			public static int abc_text_cursor_material;

			public static int abc_text_select_handle_left_mtrl_dark;

			public static int abc_text_select_handle_left_mtrl_light;

			public static int abc_text_select_handle_middle_mtrl_dark;

			public static int abc_text_select_handle_middle_mtrl_light;

			public static int abc_text_select_handle_right_mtrl_dark;

			public static int abc_text_select_handle_right_mtrl_light;

			public static int abc_vector_test;

			public static int btn_checkbox_checked_mtrl;

			public static int btn_checkbox_checked_to_unchecked_mtrl_animation;

			public static int btn_checkbox_unchecked_mtrl;

			public static int btn_checkbox_unchecked_to_checked_mtrl_animation;

			public static int btn_radio_off_mtrl;

			public static int btn_radio_off_to_on_mtrl_animation;

			public static int btn_radio_on_mtrl;

			public static int btn_radio_on_to_off_mtrl_animation;

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

			public static int tooltip_frame_dark;

			public static int tooltip_frame_light;

			static Drawable()
			{
				abc_ab_share_pack_mtrl_alpha = 2131099648;
				abc_action_bar_item_background_material = 2131099649;
				abc_btn_borderless_material = 2131099650;
				abc_btn_check_material = 2131099651;
				abc_btn_check_material_anim = 2131099652;
				abc_btn_check_to_on_mtrl_000 = 2131099653;
				abc_btn_check_to_on_mtrl_015 = 2131099654;
				abc_btn_colored_material = 2131099655;
				abc_btn_default_mtrl_shape = 2131099656;
				abc_btn_radio_material = 2131099657;
				abc_btn_radio_material_anim = 2131099658;
				abc_btn_radio_to_on_mtrl_000 = 2131099659;
				abc_btn_radio_to_on_mtrl_015 = 2131099660;
				abc_btn_switch_to_on_mtrl_00001 = 2131099661;
				abc_btn_switch_to_on_mtrl_00012 = 2131099662;
				abc_cab_background_internal_bg = 2131099663;
				abc_cab_background_top_material = 2131099664;
				abc_cab_background_top_mtrl_alpha = 2131099665;
				abc_control_background_material = 2131099666;
				abc_dialog_material_background = 2131099667;
				abc_edit_text_material = 2131099668;
				abc_ic_ab_back_material = 2131099669;
				abc_ic_arrow_drop_right_black_24dp = 2131099670;
				abc_ic_clear_material = 2131099671;
				abc_ic_commit_search_api_mtrl_alpha = 2131099672;
				abc_ic_go_search_api_material = 2131099673;
				abc_ic_menu_copy_mtrl_am_alpha = 2131099674;
				abc_ic_menu_cut_mtrl_alpha = 2131099675;
				abc_ic_menu_overflow_material = 2131099676;
				abc_ic_menu_paste_mtrl_am_alpha = 2131099677;
				abc_ic_menu_selectall_mtrl_alpha = 2131099678;
				abc_ic_menu_share_mtrl_alpha = 2131099679;
				abc_ic_search_api_material = 2131099680;
				abc_ic_star_black_16dp = 2131099681;
				abc_ic_star_black_36dp = 2131099682;
				abc_ic_star_black_48dp = 2131099683;
				abc_ic_star_half_black_16dp = 2131099684;
				abc_ic_star_half_black_36dp = 2131099685;
				abc_ic_star_half_black_48dp = 2131099686;
				abc_ic_voice_search_api_material = 2131099687;
				abc_item_background_holo_dark = 2131099688;
				abc_item_background_holo_light = 2131099689;
				abc_list_divider_material = 2131099690;
				abc_list_divider_mtrl_alpha = 2131099691;
				abc_list_focused_holo = 2131099692;
				abc_list_longpressed_holo = 2131099693;
				abc_list_pressed_holo_dark = 2131099694;
				abc_list_pressed_holo_light = 2131099695;
				abc_list_selector_background_transition_holo_dark = 2131099696;
				abc_list_selector_background_transition_holo_light = 2131099697;
				abc_list_selector_disabled_holo_dark = 2131099698;
				abc_list_selector_disabled_holo_light = 2131099699;
				abc_list_selector_holo_dark = 2131099700;
				abc_list_selector_holo_light = 2131099701;
				abc_menu_hardkey_panel_mtrl_mult = 2131099702;
				abc_popup_background_mtrl_mult = 2131099703;
				abc_ratingbar_indicator_material = 2131099704;
				abc_ratingbar_material = 2131099705;
				abc_ratingbar_small_material = 2131099706;
				abc_scrubber_control_off_mtrl_alpha = 2131099707;
				abc_scrubber_control_to_pressed_mtrl_000 = 2131099708;
				abc_scrubber_control_to_pressed_mtrl_005 = 2131099709;
				abc_scrubber_primary_mtrl_alpha = 2131099710;
				abc_scrubber_track_mtrl_alpha = 2131099711;
				abc_seekbar_thumb_material = 2131099712;
				abc_seekbar_tick_mark_material = 2131099713;
				abc_seekbar_track_material = 2131099714;
				abc_spinner_mtrl_am_alpha = 2131099715;
				abc_spinner_textfield_background_material = 2131099716;
				abc_switch_thumb_material = 2131099717;
				abc_switch_track_mtrl_alpha = 2131099718;
				abc_tab_indicator_material = 2131099719;
				abc_tab_indicator_mtrl_alpha = 2131099720;
				abc_textfield_activated_mtrl_alpha = 2131099728;
				abc_textfield_default_mtrl_alpha = 2131099729;
				abc_textfield_search_activated_mtrl_alpha = 2131099730;
				abc_textfield_search_default_mtrl_alpha = 2131099731;
				abc_textfield_search_material = 2131099732;
				abc_text_cursor_material = 2131099721;
				abc_text_select_handle_left_mtrl_dark = 2131099722;
				abc_text_select_handle_left_mtrl_light = 2131099723;
				abc_text_select_handle_middle_mtrl_dark = 2131099724;
				abc_text_select_handle_middle_mtrl_light = 2131099725;
				abc_text_select_handle_right_mtrl_dark = 2131099726;
				abc_text_select_handle_right_mtrl_light = 2131099727;
				abc_vector_test = 2131099733;
				btn_checkbox_checked_mtrl = 2131099734;
				btn_checkbox_checked_to_unchecked_mtrl_animation = 2131099735;
				btn_checkbox_unchecked_mtrl = 2131099736;
				btn_checkbox_unchecked_to_checked_mtrl_animation = 2131099737;
				btn_radio_off_mtrl = 2131099738;
				btn_radio_off_to_on_mtrl_animation = 2131099739;
				btn_radio_on_mtrl = 2131099740;
				btn_radio_on_to_off_mtrl_animation = 2131099741;
				notification_action_background = 2131099742;
				notification_bg = 2131099743;
				notification_bg_low = 2131099744;
				notification_bg_low_normal = 2131099745;
				notification_bg_low_pressed = 2131099746;
				notification_bg_normal = 2131099747;
				notification_bg_normal_pressed = 2131099748;
				notification_icon_background = 2131099749;
				notification_template_icon_bg = 2131099750;
				notification_template_icon_low_bg = 2131099751;
				notification_tile_bg = 2131099752;
				notify_panel_notification_icon_bg = 2131099753;
				tooltip_frame_dark = 2131099754;
				tooltip_frame_light = 2131099755;
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

			public static int actions;

			public static int action_bar;

			public static int action_bar_activity_content;

			public static int action_bar_container;

			public static int action_bar_root;

			public static int action_bar_spinner;

			public static int action_bar_subtitle;

			public static int action_bar_title;

			public static int action_container;

			public static int action_context_bar;

			public static int action_divider;

			public static int action_image;

			public static int action_menu_divider;

			public static int action_menu_presenter;

			public static int action_mode_bar;

			public static int action_mode_bar_stub;

			public static int action_mode_close_button;

			public static int action_text;

			public static int activity_chooser_view_content;

			public static int add;

			public static int alertTitle;

			public static int all;

			public static int ALT;

			public static int always;

			public static int async;

			public static int beginning;

			public static int blocking;

			public static int bottom;

			public static int buttonPanel;

			public static int center;

			public static int center_horizontal;

			public static int center_vertical;

			public static int checkbox;

			public static int @checked;

			public static int chronometer;

			public static int clip_horizontal;

			public static int clip_vertical;

			public static int collapseActionView;

			public static int content;

			public static int contentPanel;

			public static int CTRL;

			public static int custom;

			public static int customPanel;

			public static int decor_content_parent;

			public static int default_activity_button;

			public static int dialog_button;

			public static int disableHome;

			public static int edit_query;

			public static int end;

			public static int expanded_menu;

			public static int expand_activities_button;

			public static int fill;

			public static int fill_horizontal;

			public static int fill_vertical;

			public static int forever;

			public static int fragment_container_view_tag;

			public static int FUNCTION;

			public static int group_divider;

			public static int home;

			public static int homeAsUp;

			public static int icon;

			public static int icon_group;

			public static int ifRoom;

			public static int image;

			public static int info;

			public static int italic;

			public static int item_touch_helper_previous_elevation;

			public static int left;

			public static int line1;

			public static int line3;

			public static int listMode;

			public static int list_item;

			public static int message;

			public static int META;

			public static int middle;

			public static int multiply;

			public static int MvvmCrossTagId;

			public static int MvxBindingTagUnique;

			public static int never;

			public static int none;

			public static int normal;

			public static int notification_background;

			public static int notification_main_column;

			public static int notification_main_column_container;

			public static int off;

			public static int on;

			public static int parentPanel;

			public static int progress_circular;

			public static int progress_horizontal;

			public static int radio;

			public static int right;

			public static int right_icon;

			public static int right_side;

			public static int screen;

			public static int scrollIndicatorDown;

			public static int scrollIndicatorUp;

			public static int scrollView;

			public static int search_badge;

			public static int search_bar;

			public static int search_button;

			public static int search_close_btn;

			public static int search_edit_frame;

			public static int search_go_btn;

			public static int search_mag_icon;

			public static int search_plate;

			public static int search_src_text;

			public static int search_voice_btn;

			public static int select_dialog_listview;

			public static int SHIFT;

			public static int shortcut;

			public static int showCustom;

			public static int showHome;

			public static int showTitle;

			public static int spacer;

			public static int split_action_bar;

			public static int src_atop;

			public static int src_in;

			public static int src_over;

			public static int start;

			public static int submenuarrow;

			public static int submit_area;

			public static int SYM;

			public static int tabMode;

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

			public static int textSpacerNoButtons;

			public static int textSpacerNoTitle;

			public static int time;

			public static int title;

			public static int titleDividerNoCustom;

			public static int title_template;

			public static int top;

			public static int topPanel;

			public static int @unchecked;

			public static int uniform;

			public static int up;

			public static int useLogo;

			public static int view_tree_lifecycle_owner;

			public static int view_tree_saved_state_registry_owner;

			public static int view_tree_view_model_store_owner;

			public static int visible_removing_fragment_view_tag;

			public static int withText;

			public static int wrap_content;

			static Id()
			{
				accessibility_action_clickable_span = 2131165192;
				accessibility_custom_action_0 = 2131165193;
				accessibility_custom_action_1 = 2131165194;
				accessibility_custom_action_10 = 2131165195;
				accessibility_custom_action_11 = 2131165196;
				accessibility_custom_action_12 = 2131165197;
				accessibility_custom_action_13 = 2131165198;
				accessibility_custom_action_14 = 2131165199;
				accessibility_custom_action_15 = 2131165200;
				accessibility_custom_action_16 = 2131165201;
				accessibility_custom_action_17 = 2131165202;
				accessibility_custom_action_18 = 2131165203;
				accessibility_custom_action_19 = 2131165204;
				accessibility_custom_action_2 = 2131165205;
				accessibility_custom_action_20 = 2131165206;
				accessibility_custom_action_21 = 2131165207;
				accessibility_custom_action_22 = 2131165208;
				accessibility_custom_action_23 = 2131165209;
				accessibility_custom_action_24 = 2131165210;
				accessibility_custom_action_25 = 2131165211;
				accessibility_custom_action_26 = 2131165212;
				accessibility_custom_action_27 = 2131165213;
				accessibility_custom_action_28 = 2131165214;
				accessibility_custom_action_29 = 2131165215;
				accessibility_custom_action_3 = 2131165216;
				accessibility_custom_action_30 = 2131165217;
				accessibility_custom_action_31 = 2131165218;
				accessibility_custom_action_4 = 2131165219;
				accessibility_custom_action_5 = 2131165220;
				accessibility_custom_action_6 = 2131165221;
				accessibility_custom_action_7 = 2131165222;
				accessibility_custom_action_8 = 2131165223;
				accessibility_custom_action_9 = 2131165224;
				actions = 2131165242;
				action_bar = 2131165225;
				action_bar_activity_content = 2131165226;
				action_bar_container = 2131165227;
				action_bar_root = 2131165228;
				action_bar_spinner = 2131165229;
				action_bar_subtitle = 2131165230;
				action_bar_title = 2131165231;
				action_container = 2131165232;
				action_context_bar = 2131165233;
				action_divider = 2131165234;
				action_image = 2131165235;
				action_menu_divider = 2131165236;
				action_menu_presenter = 2131165237;
				action_mode_bar = 2131165238;
				action_mode_bar_stub = 2131165239;
				action_mode_close_button = 2131165240;
				action_text = 2131165241;
				activity_chooser_view_content = 2131165243;
				add = 2131165244;
				alertTitle = 2131165245;
				all = 2131165246;
				ALT = 2131165184;
				always = 2131165247;
				async = 2131165248;
				beginning = 2131165249;
				blocking = 2131165250;
				bottom = 2131165251;
				buttonPanel = 2131165252;
				center = 2131165253;
				center_horizontal = 2131165254;
				center_vertical = 2131165255;
				checkbox = 2131165256;
				@checked = 2131165257;
				chronometer = 2131165258;
				clip_horizontal = 2131165259;
				clip_vertical = 2131165260;
				collapseActionView = 2131165261;
				content = 2131165262;
				contentPanel = 2131165263;
				CTRL = 2131165185;
				custom = 2131165264;
				customPanel = 2131165265;
				decor_content_parent = 2131165266;
				default_activity_button = 2131165267;
				dialog_button = 2131165268;
				disableHome = 2131165269;
				edit_query = 2131165270;
				end = 2131165271;
				expanded_menu = 2131165273;
				expand_activities_button = 2131165272;
				fill = 2131165274;
				fill_horizontal = 2131165275;
				fill_vertical = 2131165276;
				forever = 2131165277;
				fragment_container_view_tag = 2131165278;
				FUNCTION = 2131165186;
				group_divider = 2131165279;
				home = 2131165280;
				homeAsUp = 2131165281;
				icon = 2131165282;
				icon_group = 2131165283;
				ifRoom = 2131165284;
				image = 2131165285;
				info = 2131165286;
				italic = 2131165287;
				item_touch_helper_previous_elevation = 2131165288;
				left = 2131165289;
				line1 = 2131165290;
				line3 = 2131165291;
				listMode = 2131165292;
				list_item = 2131165293;
				message = 2131165294;
				META = 2131165187;
				middle = 2131165295;
				multiply = 2131165296;
				MvvmCrossTagId = 2131165188;
				MvxBindingTagUnique = 2131165189;
				never = 2131165297;
				none = 2131165298;
				normal = 2131165299;
				notification_background = 2131165300;
				notification_main_column = 2131165301;
				notification_main_column_container = 2131165302;
				off = 2131165303;
				on = 2131165304;
				parentPanel = 2131165305;
				progress_circular = 2131165306;
				progress_horizontal = 2131165307;
				radio = 2131165308;
				right = 2131165309;
				right_icon = 2131165310;
				right_side = 2131165311;
				screen = 2131165312;
				scrollIndicatorDown = 2131165313;
				scrollIndicatorUp = 2131165314;
				scrollView = 2131165315;
				search_badge = 2131165316;
				search_bar = 2131165317;
				search_button = 2131165318;
				search_close_btn = 2131165319;
				search_edit_frame = 2131165320;
				search_go_btn = 2131165321;
				search_mag_icon = 2131165322;
				search_plate = 2131165323;
				search_src_text = 2131165324;
				search_voice_btn = 2131165325;
				select_dialog_listview = 2131165326;
				SHIFT = 2131165190;
				shortcut = 2131165327;
				showCustom = 2131165328;
				showHome = 2131165329;
				showTitle = 2131165330;
				spacer = 2131165331;
				split_action_bar = 2131165332;
				src_atop = 2131165333;
				src_in = 2131165334;
				src_over = 2131165335;
				start = 2131165336;
				submenuarrow = 2131165337;
				submit_area = 2131165338;
				SYM = 2131165191;
				tabMode = 2131165339;
				tag_accessibility_actions = 2131165340;
				tag_accessibility_clickable_spans = 2131165341;
				tag_accessibility_heading = 2131165342;
				tag_accessibility_pane_title = 2131165343;
				tag_screen_reader_focusable = 2131165344;
				tag_transition_group = 2131165345;
				tag_unhandled_key_event_manager = 2131165346;
				tag_unhandled_key_listeners = 2131165347;
				text = 2131165348;
				text2 = 2131165349;
				textSpacerNoButtons = 2131165350;
				textSpacerNoTitle = 2131165351;
				time = 2131165352;
				title = 2131165353;
				titleDividerNoCustom = 2131165354;
				title_template = 2131165355;
				top = 2131165356;
				topPanel = 2131165357;
				@unchecked = 2131165358;
				uniform = 2131165359;
				up = 2131165360;
				useLogo = 2131165361;
				view_tree_lifecycle_owner = 2131165362;
				view_tree_saved_state_registry_owner = 2131165363;
				view_tree_view_model_store_owner = 2131165364;
				visible_removing_fragment_view_tag = 2131165365;
				withText = 2131165366;
				wrap_content = 2131165367;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Integer
		{
			public static int abc_config_activityDefaultDur;

			public static int abc_config_activityShortDur;

			public static int cancel_button_image_alpha;

			public static int config_tooltipAnimTime;

			public static int status_bar_notification_info_maxnum;

			static Integer()
			{
				abc_config_activityDefaultDur = 2131230720;
				abc_config_activityShortDur = 2131230721;
				cancel_button_image_alpha = 2131230722;
				config_tooltipAnimTime = 2131230723;
				status_bar_notification_info_maxnum = 2131230724;
				ResourceIdManager.UpdateIdValues();
			}

			private Integer()
			{
			}
		}

		public class Interpolator
		{
			public static int btn_checkbox_checked_mtrl_animation_interpolator_0;

			public static int btn_checkbox_checked_mtrl_animation_interpolator_1;

			public static int btn_checkbox_unchecked_mtrl_animation_interpolator_0;

			public static int btn_checkbox_unchecked_mtrl_animation_interpolator_1;

			public static int btn_radio_to_off_mtrl_animation_interpolator_0;

			public static int btn_radio_to_on_mtrl_animation_interpolator_0;

			public static int fast_out_slow_in;

			static Interpolator()
			{
				btn_checkbox_checked_mtrl_animation_interpolator_0 = 2131296256;
				btn_checkbox_checked_mtrl_animation_interpolator_1 = 2131296257;
				btn_checkbox_unchecked_mtrl_animation_interpolator_0 = 2131296258;
				btn_checkbox_unchecked_mtrl_animation_interpolator_1 = 2131296259;
				btn_radio_to_off_mtrl_animation_interpolator_0 = 2131296260;
				btn_radio_to_on_mtrl_animation_interpolator_0 = 2131296261;
				fast_out_slow_in = 2131296262;
				ResourceIdManager.UpdateIdValues();
			}

			private Interpolator()
			{
			}
		}

		public class Layout
		{
			public static int abc_action_bar_title_item;

			public static int abc_action_bar_up_container;

			public static int abc_action_menu_item_layout;

			public static int abc_action_menu_layout;

			public static int abc_action_mode_bar;

			public static int abc_action_mode_close_item_material;

			public static int abc_activity_chooser_view;

			public static int abc_activity_chooser_view_list_item;

			public static int abc_alert_dialog_button_bar_material;

			public static int abc_alert_dialog_material;

			public static int abc_alert_dialog_title_material;

			public static int abc_cascading_menu_item_layout;

			public static int abc_dialog_title_material;

			public static int abc_expanded_menu_layout;

			public static int abc_list_menu_item_checkbox;

			public static int abc_list_menu_item_icon;

			public static int abc_list_menu_item_layout;

			public static int abc_list_menu_item_radio;

			public static int abc_popup_menu_header_item_layout;

			public static int abc_popup_menu_item_layout;

			public static int abc_screen_content_include;

			public static int abc_screen_simple;

			public static int abc_screen_simple_overlay_action_mode;

			public static int abc_screen_toolbar;

			public static int abc_search_dropdown_item_icons_2line;

			public static int abc_search_view;

			public static int abc_select_dialog_material;

			public static int abc_tooltip;

			public static int custom_dialog;

			public static int notification_action;

			public static int notification_action_tombstone;

			public static int notification_template_custom_big;

			public static int notification_template_icon_group;

			public static int notification_template_part_chronometer;

			public static int notification_template_part_time;

			public static int select_dialog_item_material;

			public static int select_dialog_multichoice_material;

			public static int select_dialog_singlechoice_material;

			public static int support_simple_spinner_dropdown_item;

			static Layout()
			{
				abc_action_bar_title_item = 2131361792;
				abc_action_bar_up_container = 2131361793;
				abc_action_menu_item_layout = 2131361794;
				abc_action_menu_layout = 2131361795;
				abc_action_mode_bar = 2131361796;
				abc_action_mode_close_item_material = 2131361797;
				abc_activity_chooser_view = 2131361798;
				abc_activity_chooser_view_list_item = 2131361799;
				abc_alert_dialog_button_bar_material = 2131361800;
				abc_alert_dialog_material = 2131361801;
				abc_alert_dialog_title_material = 2131361802;
				abc_cascading_menu_item_layout = 2131361803;
				abc_dialog_title_material = 2131361804;
				abc_expanded_menu_layout = 2131361805;
				abc_list_menu_item_checkbox = 2131361806;
				abc_list_menu_item_icon = 2131361807;
				abc_list_menu_item_layout = 2131361808;
				abc_list_menu_item_radio = 2131361809;
				abc_popup_menu_header_item_layout = 2131361810;
				abc_popup_menu_item_layout = 2131361811;
				abc_screen_content_include = 2131361812;
				abc_screen_simple = 2131361813;
				abc_screen_simple_overlay_action_mode = 2131361814;
				abc_screen_toolbar = 2131361815;
				abc_search_dropdown_item_icons_2line = 2131361816;
				abc_search_view = 2131361817;
				abc_select_dialog_material = 2131361818;
				abc_tooltip = 2131361819;
				custom_dialog = 2131361820;
				notification_action = 2131361821;
				notification_action_tombstone = 2131361822;
				notification_template_custom_big = 2131361823;
				notification_template_icon_group = 2131361824;
				notification_template_part_chronometer = 2131361825;
				notification_template_part_time = 2131361826;
				select_dialog_item_material = 2131361827;
				select_dialog_multichoice_material = 2131361828;
				select_dialog_singlechoice_material = 2131361829;
				support_simple_spinner_dropdown_item = 2131361830;
				ResourceIdManager.UpdateIdValues();
			}

			private Layout()
			{
			}
		}

		public class String
		{
			public static int abc_action_bar_home_description;

			public static int abc_action_bar_up_description;

			public static int abc_action_menu_overflow_description;

			public static int abc_action_mode_done;

			public static int abc_activitychooserview_choose_application;

			public static int abc_activity_chooser_view_see_all;

			public static int abc_capital_off;

			public static int abc_capital_on;

			public static int abc_menu_alt_shortcut_label;

			public static int abc_menu_ctrl_shortcut_label;

			public static int abc_menu_delete_shortcut_label;

			public static int abc_menu_enter_shortcut_label;

			public static int abc_menu_function_shortcut_label;

			public static int abc_menu_meta_shortcut_label;

			public static int abc_menu_shift_shortcut_label;

			public static int abc_menu_space_shortcut_label;

			public static int abc_menu_sym_shortcut_label;

			public static int abc_prepend_shortcut_label;

			public static int abc_searchview_description_clear;

			public static int abc_searchview_description_query;

			public static int abc_searchview_description_search;

			public static int abc_searchview_description_submit;

			public static int abc_searchview_description_voice;

			public static int abc_search_hint;

			public static int abc_shareactionprovider_share_with;

			public static int abc_shareactionprovider_share_with_application;

			public static int abc_toolbar_collapse_description;

			public static int search_menu_title;

			public static int status_bar_notification_info_overflow;

			static String()
			{
				abc_action_bar_home_description = 2131427328;
				abc_action_bar_up_description = 2131427329;
				abc_action_menu_overflow_description = 2131427330;
				abc_action_mode_done = 2131427331;
				abc_activitychooserview_choose_application = 2131427333;
				abc_activity_chooser_view_see_all = 2131427332;
				abc_capital_off = 2131427334;
				abc_capital_on = 2131427335;
				abc_menu_alt_shortcut_label = 2131427336;
				abc_menu_ctrl_shortcut_label = 2131427337;
				abc_menu_delete_shortcut_label = 2131427338;
				abc_menu_enter_shortcut_label = 2131427339;
				abc_menu_function_shortcut_label = 2131427340;
				abc_menu_meta_shortcut_label = 2131427341;
				abc_menu_shift_shortcut_label = 2131427342;
				abc_menu_space_shortcut_label = 2131427343;
				abc_menu_sym_shortcut_label = 2131427344;
				abc_prepend_shortcut_label = 2131427345;
				abc_searchview_description_clear = 2131427347;
				abc_searchview_description_query = 2131427348;
				abc_searchview_description_search = 2131427349;
				abc_searchview_description_submit = 2131427350;
				abc_searchview_description_voice = 2131427351;
				abc_search_hint = 2131427346;
				abc_shareactionprovider_share_with = 2131427352;
				abc_shareactionprovider_share_with_application = 2131427353;
				abc_toolbar_collapse_description = 2131427354;
				search_menu_title = 2131427355;
				status_bar_notification_info_overflow = 2131427356;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		public class Style
		{
			public static int AlertDialog_AppCompat;

			public static int AlertDialog_AppCompat_Light;

			public static int Animation_AppCompat_Dialog;

			public static int Animation_AppCompat_DropDownUp;

			public static int Animation_AppCompat_Tooltip;

			public static int Base_AlertDialog_AppCompat;

			public static int Base_AlertDialog_AppCompat_Light;

			public static int Base_Animation_AppCompat_Dialog;

			public static int Base_Animation_AppCompat_DropDownUp;

			public static int Base_Animation_AppCompat_Tooltip;

			public static int Base_DialogWindowTitleBackground_AppCompat;

			public static int Base_DialogWindowTitle_AppCompat;

			public static int Base_TextAppearance_AppCompat;

			public static int Base_TextAppearance_AppCompat_Body1;

			public static int Base_TextAppearance_AppCompat_Body2;

			public static int Base_TextAppearance_AppCompat_Button;

			public static int Base_TextAppearance_AppCompat_Caption;

			public static int Base_TextAppearance_AppCompat_Display1;

			public static int Base_TextAppearance_AppCompat_Display2;

			public static int Base_TextAppearance_AppCompat_Display3;

			public static int Base_TextAppearance_AppCompat_Display4;

			public static int Base_TextAppearance_AppCompat_Headline;

			public static int Base_TextAppearance_AppCompat_Inverse;

			public static int Base_TextAppearance_AppCompat_Large;

			public static int Base_TextAppearance_AppCompat_Large_Inverse;

			public static int Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Large;

			public static int Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Small;

			public static int Base_TextAppearance_AppCompat_Medium;

			public static int Base_TextAppearance_AppCompat_Medium_Inverse;

			public static int Base_TextAppearance_AppCompat_Menu;

			public static int Base_TextAppearance_AppCompat_SearchResult;

			public static int Base_TextAppearance_AppCompat_SearchResult_Subtitle;

			public static int Base_TextAppearance_AppCompat_SearchResult_Title;

			public static int Base_TextAppearance_AppCompat_Small;

			public static int Base_TextAppearance_AppCompat_Small_Inverse;

			public static int Base_TextAppearance_AppCompat_Subhead;

			public static int Base_TextAppearance_AppCompat_Subhead_Inverse;

			public static int Base_TextAppearance_AppCompat_Title;

			public static int Base_TextAppearance_AppCompat_Title_Inverse;

			public static int Base_TextAppearance_AppCompat_Tooltip;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Menu;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Title;

			public static int Base_TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_ActionMode_Subtitle;

			public static int Base_TextAppearance_AppCompat_Widget_ActionMode_Title;

			public static int Base_TextAppearance_AppCompat_Widget_Button;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Borderless_Colored;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Colored;

			public static int Base_TextAppearance_AppCompat_Widget_Button_Inverse;

			public static int Base_TextAppearance_AppCompat_Widget_DropDownItem;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Header;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Large;

			public static int Base_TextAppearance_AppCompat_Widget_PopupMenu_Small;

			public static int Base_TextAppearance_AppCompat_Widget_Switch;

			public static int Base_TextAppearance_AppCompat_Widget_TextView_SpinnerItem;

			public static int Base_TextAppearance_Widget_AppCompat_ExpandedMenu_Item;

			public static int Base_TextAppearance_Widget_AppCompat_Toolbar_Subtitle;

			public static int Base_TextAppearance_Widget_AppCompat_Toolbar_Title;

			public static int Base_ThemeOverlay_AppCompat;

			public static int Base_ThemeOverlay_AppCompat_ActionBar;

			public static int Base_ThemeOverlay_AppCompat_Dark;

			public static int Base_ThemeOverlay_AppCompat_Dark_ActionBar;

			public static int Base_ThemeOverlay_AppCompat_Dialog;

			public static int Base_ThemeOverlay_AppCompat_Dialog_Alert;

			public static int Base_ThemeOverlay_AppCompat_Light;

			public static int Base_Theme_AppCompat;

			public static int Base_Theme_AppCompat_CompactMenu;

			public static int Base_Theme_AppCompat_Dialog;

			public static int Base_Theme_AppCompat_DialogWhenLarge;

			public static int Base_Theme_AppCompat_Dialog_Alert;

			public static int Base_Theme_AppCompat_Dialog_FixedSize;

			public static int Base_Theme_AppCompat_Dialog_MinWidth;

			public static int Base_Theme_AppCompat_Light;

			public static int Base_Theme_AppCompat_Light_DarkActionBar;

			public static int Base_Theme_AppCompat_Light_Dialog;

			public static int Base_Theme_AppCompat_Light_DialogWhenLarge;

			public static int Base_Theme_AppCompat_Light_Dialog_Alert;

			public static int Base_Theme_AppCompat_Light_Dialog_FixedSize;

			public static int Base_Theme_AppCompat_Light_Dialog_MinWidth;

			public static int Base_V21_ThemeOverlay_AppCompat_Dialog;

			public static int Base_V21_Theme_AppCompat;

			public static int Base_V21_Theme_AppCompat_Dialog;

			public static int Base_V21_Theme_AppCompat_Light;

			public static int Base_V21_Theme_AppCompat_Light_Dialog;

			public static int Base_V22_Theme_AppCompat;

			public static int Base_V22_Theme_AppCompat_Light;

			public static int Base_V23_Theme_AppCompat;

			public static int Base_V23_Theme_AppCompat_Light;

			public static int Base_V26_Theme_AppCompat;

			public static int Base_V26_Theme_AppCompat_Light;

			public static int Base_V26_Widget_AppCompat_Toolbar;

			public static int Base_V28_Theme_AppCompat;

			public static int Base_V28_Theme_AppCompat_Light;

			public static int Base_V7_ThemeOverlay_AppCompat_Dialog;

			public static int Base_V7_Theme_AppCompat;

			public static int Base_V7_Theme_AppCompat_Dialog;

			public static int Base_V7_Theme_AppCompat_Light;

			public static int Base_V7_Theme_AppCompat_Light_Dialog;

			public static int Base_V7_Widget_AppCompat_AutoCompleteTextView;

			public static int Base_V7_Widget_AppCompat_EditText;

			public static int Base_V7_Widget_AppCompat_Toolbar;

			public static int Base_Widget_AppCompat_ActionBar;

			public static int Base_Widget_AppCompat_ActionBar_Solid;

			public static int Base_Widget_AppCompat_ActionBar_TabBar;

			public static int Base_Widget_AppCompat_ActionBar_TabText;

			public static int Base_Widget_AppCompat_ActionBar_TabView;

			public static int Base_Widget_AppCompat_ActionButton;

			public static int Base_Widget_AppCompat_ActionButton_CloseMode;

			public static int Base_Widget_AppCompat_ActionButton_Overflow;

			public static int Base_Widget_AppCompat_ActionMode;

			public static int Base_Widget_AppCompat_ActivityChooserView;

			public static int Base_Widget_AppCompat_AutoCompleteTextView;

			public static int Base_Widget_AppCompat_Button;

			public static int Base_Widget_AppCompat_ButtonBar;

			public static int Base_Widget_AppCompat_ButtonBar_AlertDialog;

			public static int Base_Widget_AppCompat_Button_Borderless;

			public static int Base_Widget_AppCompat_Button_Borderless_Colored;

			public static int Base_Widget_AppCompat_Button_ButtonBar_AlertDialog;

			public static int Base_Widget_AppCompat_Button_Colored;

			public static int Base_Widget_AppCompat_Button_Small;

			public static int Base_Widget_AppCompat_CompoundButton_CheckBox;

			public static int Base_Widget_AppCompat_CompoundButton_RadioButton;

			public static int Base_Widget_AppCompat_CompoundButton_Switch;

			public static int Base_Widget_AppCompat_DrawerArrowToggle;

			public static int Base_Widget_AppCompat_DrawerArrowToggle_Common;

			public static int Base_Widget_AppCompat_DropDownItem_Spinner;

			public static int Base_Widget_AppCompat_EditText;

			public static int Base_Widget_AppCompat_ImageButton;

			public static int Base_Widget_AppCompat_Light_ActionBar;

			public static int Base_Widget_AppCompat_Light_ActionBar_Solid;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabBar;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabText;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabText_Inverse;

			public static int Base_Widget_AppCompat_Light_ActionBar_TabView;

			public static int Base_Widget_AppCompat_Light_PopupMenu;

			public static int Base_Widget_AppCompat_Light_PopupMenu_Overflow;

			public static int Base_Widget_AppCompat_ListMenuView;

			public static int Base_Widget_AppCompat_ListPopupWindow;

			public static int Base_Widget_AppCompat_ListView;

			public static int Base_Widget_AppCompat_ListView_DropDown;

			public static int Base_Widget_AppCompat_ListView_Menu;

			public static int Base_Widget_AppCompat_PopupMenu;

			public static int Base_Widget_AppCompat_PopupMenu_Overflow;

			public static int Base_Widget_AppCompat_PopupWindow;

			public static int Base_Widget_AppCompat_ProgressBar;

			public static int Base_Widget_AppCompat_ProgressBar_Horizontal;

			public static int Base_Widget_AppCompat_RatingBar;

			public static int Base_Widget_AppCompat_RatingBar_Indicator;

			public static int Base_Widget_AppCompat_RatingBar_Small;

			public static int Base_Widget_AppCompat_SearchView;

			public static int Base_Widget_AppCompat_SearchView_ActionBar;

			public static int Base_Widget_AppCompat_SeekBar;

			public static int Base_Widget_AppCompat_SeekBar_Discrete;

			public static int Base_Widget_AppCompat_Spinner;

			public static int Base_Widget_AppCompat_Spinner_Underlined;

			public static int Base_Widget_AppCompat_TextView;

			public static int Base_Widget_AppCompat_TextView_SpinnerItem;

			public static int Base_Widget_AppCompat_Toolbar;

			public static int Base_Widget_AppCompat_Toolbar_Button_Navigation;

			public static int Platform_AppCompat;

			public static int Platform_AppCompat_Light;

			public static int Platform_ThemeOverlay_AppCompat;

			public static int Platform_ThemeOverlay_AppCompat_Dark;

			public static int Platform_ThemeOverlay_AppCompat_Light;

			public static int Platform_V21_AppCompat;

			public static int Platform_V21_AppCompat_Light;

			public static int Platform_V25_AppCompat;

			public static int Platform_V25_AppCompat_Light;

			public static int Platform_Widget_AppCompat_Spinner;

			public static int RtlOverlay_DialogWindowTitle_AppCompat;

			public static int RtlOverlay_Widget_AppCompat_ActionBar_TitleItem;

			public static int RtlOverlay_Widget_AppCompat_DialogTitle_Icon;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_InternalGroup;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Shortcut;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_SubmenuArrow;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Text;

			public static int RtlOverlay_Widget_AppCompat_PopupMenuItem_Title;

			public static int RtlOverlay_Widget_AppCompat_SearchView_MagIcon;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Icon1;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Icon2;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Query;

			public static int RtlOverlay_Widget_AppCompat_Search_DropDown_Text;

			public static int RtlUnderlay_Widget_AppCompat_ActionButton;

			public static int RtlUnderlay_Widget_AppCompat_ActionButton_Overflow;

			public static int TextAppearance_AppCompat;

			public static int TextAppearance_AppCompat_Body1;

			public static int TextAppearance_AppCompat_Body2;

			public static int TextAppearance_AppCompat_Button;

			public static int TextAppearance_AppCompat_Caption;

			public static int TextAppearance_AppCompat_Display1;

			public static int TextAppearance_AppCompat_Display2;

			public static int TextAppearance_AppCompat_Display3;

			public static int TextAppearance_AppCompat_Display4;

			public static int TextAppearance_AppCompat_Headline;

			public static int TextAppearance_AppCompat_Inverse;

			public static int TextAppearance_AppCompat_Large;

			public static int TextAppearance_AppCompat_Large_Inverse;

			public static int TextAppearance_AppCompat_Light_SearchResult_Subtitle;

			public static int TextAppearance_AppCompat_Light_SearchResult_Title;

			public static int TextAppearance_AppCompat_Light_Widget_PopupMenu_Large;

			public static int TextAppearance_AppCompat_Light_Widget_PopupMenu_Small;

			public static int TextAppearance_AppCompat_Medium;

			public static int TextAppearance_AppCompat_Medium_Inverse;

			public static int TextAppearance_AppCompat_Menu;

			public static int TextAppearance_AppCompat_SearchResult_Subtitle;

			public static int TextAppearance_AppCompat_SearchResult_Title;

			public static int TextAppearance_AppCompat_Small;

			public static int TextAppearance_AppCompat_Small_Inverse;

			public static int TextAppearance_AppCompat_Subhead;

			public static int TextAppearance_AppCompat_Subhead_Inverse;

			public static int TextAppearance_AppCompat_Title;

			public static int TextAppearance_AppCompat_Title_Inverse;

			public static int TextAppearance_AppCompat_Tooltip;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Menu;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Subtitle;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Title;

			public static int TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Subtitle;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Subtitle_Inverse;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Title;

			public static int TextAppearance_AppCompat_Widget_ActionMode_Title_Inverse;

			public static int TextAppearance_AppCompat_Widget_Button;

			public static int TextAppearance_AppCompat_Widget_Button_Borderless_Colored;

			public static int TextAppearance_AppCompat_Widget_Button_Colored;

			public static int TextAppearance_AppCompat_Widget_Button_Inverse;

			public static int TextAppearance_AppCompat_Widget_DropDownItem;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Header;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Large;

			public static int TextAppearance_AppCompat_Widget_PopupMenu_Small;

			public static int TextAppearance_AppCompat_Widget_Switch;

			public static int TextAppearance_AppCompat_Widget_TextView_SpinnerItem;

			public static int TextAppearance_Compat_Notification;

			public static int TextAppearance_Compat_Notification_Info;

			public static int TextAppearance_Compat_Notification_Line2;

			public static int TextAppearance_Compat_Notification_Time;

			public static int TextAppearance_Compat_Notification_Title;

			public static int TextAppearance_Widget_AppCompat_ExpandedMenu_Item;

			public static int TextAppearance_Widget_AppCompat_Toolbar_Subtitle;

			public static int TextAppearance_Widget_AppCompat_Toolbar_Title;

			public static int ThemeOverlay_AppCompat;

			public static int ThemeOverlay_AppCompat_ActionBar;

			public static int ThemeOverlay_AppCompat_Dark;

			public static int ThemeOverlay_AppCompat_Dark_ActionBar;

			public static int ThemeOverlay_AppCompat_DayNight;

			public static int ThemeOverlay_AppCompat_DayNight_ActionBar;

			public static int ThemeOverlay_AppCompat_Dialog;

			public static int ThemeOverlay_AppCompat_Dialog_Alert;

			public static int ThemeOverlay_AppCompat_Light;

			public static int Theme_AppCompat;

			public static int Theme_AppCompat_CompactMenu;

			public static int Theme_AppCompat_DayNight;

			public static int Theme_AppCompat_DayNight_DarkActionBar;

			public static int Theme_AppCompat_DayNight_Dialog;

			public static int Theme_AppCompat_DayNight_DialogWhenLarge;

			public static int Theme_AppCompat_DayNight_Dialog_Alert;

			public static int Theme_AppCompat_DayNight_Dialog_MinWidth;

			public static int Theme_AppCompat_DayNight_NoActionBar;

			public static int Theme_AppCompat_Dialog;

			public static int Theme_AppCompat_DialogWhenLarge;

			public static int Theme_AppCompat_Dialog_Alert;

			public static int Theme_AppCompat_Dialog_MinWidth;

			public static int Theme_AppCompat_Empty;

			public static int Theme_AppCompat_Light;

			public static int Theme_AppCompat_Light_DarkActionBar;

			public static int Theme_AppCompat_Light_Dialog;

			public static int Theme_AppCompat_Light_DialogWhenLarge;

			public static int Theme_AppCompat_Light_Dialog_Alert;

			public static int Theme_AppCompat_Light_Dialog_MinWidth;

			public static int Theme_AppCompat_Light_NoActionBar;

			public static int Theme_AppCompat_NoActionBar;

			public static int Widget_AppCompat_ActionBar;

			public static int Widget_AppCompat_ActionBar_Solid;

			public static int Widget_AppCompat_ActionBar_TabBar;

			public static int Widget_AppCompat_ActionBar_TabText;

			public static int Widget_AppCompat_ActionBar_TabView;

			public static int Widget_AppCompat_ActionButton;

			public static int Widget_AppCompat_ActionButton_CloseMode;

			public static int Widget_AppCompat_ActionButton_Overflow;

			public static int Widget_AppCompat_ActionMode;

			public static int Widget_AppCompat_ActivityChooserView;

			public static int Widget_AppCompat_AutoCompleteTextView;

			public static int Widget_AppCompat_Button;

			public static int Widget_AppCompat_ButtonBar;

			public static int Widget_AppCompat_ButtonBar_AlertDialog;

			public static int Widget_AppCompat_Button_Borderless;

			public static int Widget_AppCompat_Button_Borderless_Colored;

			public static int Widget_AppCompat_Button_ButtonBar_AlertDialog;

			public static int Widget_AppCompat_Button_Colored;

			public static int Widget_AppCompat_Button_Small;

			public static int Widget_AppCompat_CompoundButton_CheckBox;

			public static int Widget_AppCompat_CompoundButton_RadioButton;

			public static int Widget_AppCompat_CompoundButton_Switch;

			public static int Widget_AppCompat_DrawerArrowToggle;

			public static int Widget_AppCompat_DropDownItem_Spinner;

			public static int Widget_AppCompat_EditText;

			public static int Widget_AppCompat_ImageButton;

			public static int Widget_AppCompat_Light_ActionBar;

			public static int Widget_AppCompat_Light_ActionBar_Solid;

			public static int Widget_AppCompat_Light_ActionBar_Solid_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabBar;

			public static int Widget_AppCompat_Light_ActionBar_TabBar_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabText;

			public static int Widget_AppCompat_Light_ActionBar_TabText_Inverse;

			public static int Widget_AppCompat_Light_ActionBar_TabView;

			public static int Widget_AppCompat_Light_ActionBar_TabView_Inverse;

			public static int Widget_AppCompat_Light_ActionButton;

			public static int Widget_AppCompat_Light_ActionButton_CloseMode;

			public static int Widget_AppCompat_Light_ActionButton_Overflow;

			public static int Widget_AppCompat_Light_ActionMode_Inverse;

			public static int Widget_AppCompat_Light_ActivityChooserView;

			public static int Widget_AppCompat_Light_AutoCompleteTextView;

			public static int Widget_AppCompat_Light_DropDownItem_Spinner;

			public static int Widget_AppCompat_Light_ListPopupWindow;

			public static int Widget_AppCompat_Light_ListView_DropDown;

			public static int Widget_AppCompat_Light_PopupMenu;

			public static int Widget_AppCompat_Light_PopupMenu_Overflow;

			public static int Widget_AppCompat_Light_SearchView;

			public static int Widget_AppCompat_Light_Spinner_DropDown_ActionBar;

			public static int Widget_AppCompat_ListMenuView;

			public static int Widget_AppCompat_ListPopupWindow;

			public static int Widget_AppCompat_ListView;

			public static int Widget_AppCompat_ListView_DropDown;

			public static int Widget_AppCompat_ListView_Menu;

			public static int Widget_AppCompat_PopupMenu;

			public static int Widget_AppCompat_PopupMenu_Overflow;

			public static int Widget_AppCompat_PopupWindow;

			public static int Widget_AppCompat_ProgressBar;

			public static int Widget_AppCompat_ProgressBar_Horizontal;

			public static int Widget_AppCompat_RatingBar;

			public static int Widget_AppCompat_RatingBar_Indicator;

			public static int Widget_AppCompat_RatingBar_Small;

			public static int Widget_AppCompat_SearchView;

			public static int Widget_AppCompat_SearchView_ActionBar;

			public static int Widget_AppCompat_SeekBar;

			public static int Widget_AppCompat_SeekBar_Discrete;

			public static int Widget_AppCompat_Spinner;

			public static int Widget_AppCompat_Spinner_DropDown;

			public static int Widget_AppCompat_Spinner_DropDown_ActionBar;

			public static int Widget_AppCompat_Spinner_Underlined;

			public static int Widget_AppCompat_TextView;

			public static int Widget_AppCompat_TextView_SpinnerItem;

			public static int Widget_AppCompat_Toolbar;

			public static int Widget_AppCompat_Toolbar_Button_Navigation;

			public static int Widget_Compat_NotificationActionContainer;

			public static int Widget_Compat_NotificationActionText;

			public static int Widget_Support_CoordinatorLayout;

			static Style()
			{
				AlertDialog_AppCompat = 2131492864;
				AlertDialog_AppCompat_Light = 2131492865;
				Animation_AppCompat_Dialog = 2131492866;
				Animation_AppCompat_DropDownUp = 2131492867;
				Animation_AppCompat_Tooltip = 2131492868;
				Base_AlertDialog_AppCompat = 2131492869;
				Base_AlertDialog_AppCompat_Light = 2131492870;
				Base_Animation_AppCompat_Dialog = 2131492871;
				Base_Animation_AppCompat_DropDownUp = 2131492872;
				Base_Animation_AppCompat_Tooltip = 2131492873;
				Base_DialogWindowTitleBackground_AppCompat = 2131492875;
				Base_DialogWindowTitle_AppCompat = 2131492874;
				Base_TextAppearance_AppCompat = 2131492876;
				Base_TextAppearance_AppCompat_Body1 = 2131492877;
				Base_TextAppearance_AppCompat_Body2 = 2131492878;
				Base_TextAppearance_AppCompat_Button = 2131492879;
				Base_TextAppearance_AppCompat_Caption = 2131492880;
				Base_TextAppearance_AppCompat_Display1 = 2131492881;
				Base_TextAppearance_AppCompat_Display2 = 2131492882;
				Base_TextAppearance_AppCompat_Display3 = 2131492883;
				Base_TextAppearance_AppCompat_Display4 = 2131492884;
				Base_TextAppearance_AppCompat_Headline = 2131492885;
				Base_TextAppearance_AppCompat_Inverse = 2131492886;
				Base_TextAppearance_AppCompat_Large = 2131492887;
				Base_TextAppearance_AppCompat_Large_Inverse = 2131492888;
				Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Large = 2131492889;
				Base_TextAppearance_AppCompat_Light_Widget_PopupMenu_Small = 2131492890;
				Base_TextAppearance_AppCompat_Medium = 2131492891;
				Base_TextAppearance_AppCompat_Medium_Inverse = 2131492892;
				Base_TextAppearance_AppCompat_Menu = 2131492893;
				Base_TextAppearance_AppCompat_SearchResult = 2131492894;
				Base_TextAppearance_AppCompat_SearchResult_Subtitle = 2131492895;
				Base_TextAppearance_AppCompat_SearchResult_Title = 2131492896;
				Base_TextAppearance_AppCompat_Small = 2131492897;
				Base_TextAppearance_AppCompat_Small_Inverse = 2131492898;
				Base_TextAppearance_AppCompat_Subhead = 2131492899;
				Base_TextAppearance_AppCompat_Subhead_Inverse = 2131492900;
				Base_TextAppearance_AppCompat_Title = 2131492901;
				Base_TextAppearance_AppCompat_Title_Inverse = 2131492902;
				Base_TextAppearance_AppCompat_Tooltip = 2131492903;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Menu = 2131492904;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle = 2131492905;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse = 2131492906;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Title = 2131492907;
				Base_TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse = 2131492908;
				Base_TextAppearance_AppCompat_Widget_ActionMode_Subtitle = 2131492909;
				Base_TextAppearance_AppCompat_Widget_ActionMode_Title = 2131492910;
				Base_TextAppearance_AppCompat_Widget_Button = 2131492911;
				Base_TextAppearance_AppCompat_Widget_Button_Borderless_Colored = 2131492912;
				Base_TextAppearance_AppCompat_Widget_Button_Colored = 2131492913;
				Base_TextAppearance_AppCompat_Widget_Button_Inverse = 2131492914;
				Base_TextAppearance_AppCompat_Widget_DropDownItem = 2131492915;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Header = 2131492916;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Large = 2131492917;
				Base_TextAppearance_AppCompat_Widget_PopupMenu_Small = 2131492918;
				Base_TextAppearance_AppCompat_Widget_Switch = 2131492919;
				Base_TextAppearance_AppCompat_Widget_TextView_SpinnerItem = 2131492920;
				Base_TextAppearance_Widget_AppCompat_ExpandedMenu_Item = 2131492921;
				Base_TextAppearance_Widget_AppCompat_Toolbar_Subtitle = 2131492922;
				Base_TextAppearance_Widget_AppCompat_Toolbar_Title = 2131492923;
				Base_ThemeOverlay_AppCompat = 2131492938;
				Base_ThemeOverlay_AppCompat_ActionBar = 2131492939;
				Base_ThemeOverlay_AppCompat_Dark = 2131492940;
				Base_ThemeOverlay_AppCompat_Dark_ActionBar = 2131492941;
				Base_ThemeOverlay_AppCompat_Dialog = 2131492942;
				Base_ThemeOverlay_AppCompat_Dialog_Alert = 2131492943;
				Base_ThemeOverlay_AppCompat_Light = 2131492944;
				Base_Theme_AppCompat = 2131492924;
				Base_Theme_AppCompat_CompactMenu = 2131492925;
				Base_Theme_AppCompat_Dialog = 2131492926;
				Base_Theme_AppCompat_DialogWhenLarge = 2131492930;
				Base_Theme_AppCompat_Dialog_Alert = 2131492927;
				Base_Theme_AppCompat_Dialog_FixedSize = 2131492928;
				Base_Theme_AppCompat_Dialog_MinWidth = 2131492929;
				Base_Theme_AppCompat_Light = 2131492931;
				Base_Theme_AppCompat_Light_DarkActionBar = 2131492932;
				Base_Theme_AppCompat_Light_Dialog = 2131492933;
				Base_Theme_AppCompat_Light_DialogWhenLarge = 2131492937;
				Base_Theme_AppCompat_Light_Dialog_Alert = 2131492934;
				Base_Theme_AppCompat_Light_Dialog_FixedSize = 2131492935;
				Base_Theme_AppCompat_Light_Dialog_MinWidth = 2131492936;
				Base_V21_ThemeOverlay_AppCompat_Dialog = 2131492949;
				Base_V21_Theme_AppCompat = 2131492945;
				Base_V21_Theme_AppCompat_Dialog = 2131492946;
				Base_V21_Theme_AppCompat_Light = 2131492947;
				Base_V21_Theme_AppCompat_Light_Dialog = 2131492948;
				Base_V22_Theme_AppCompat = 2131492950;
				Base_V22_Theme_AppCompat_Light = 2131492951;
				Base_V23_Theme_AppCompat = 2131492952;
				Base_V23_Theme_AppCompat_Light = 2131492953;
				Base_V26_Theme_AppCompat = 2131492954;
				Base_V26_Theme_AppCompat_Light = 2131492955;
				Base_V26_Widget_AppCompat_Toolbar = 2131492956;
				Base_V28_Theme_AppCompat = 2131492957;
				Base_V28_Theme_AppCompat_Light = 2131492958;
				Base_V7_ThemeOverlay_AppCompat_Dialog = 2131492963;
				Base_V7_Theme_AppCompat = 2131492959;
				Base_V7_Theme_AppCompat_Dialog = 2131492960;
				Base_V7_Theme_AppCompat_Light = 2131492961;
				Base_V7_Theme_AppCompat_Light_Dialog = 2131492962;
				Base_V7_Widget_AppCompat_AutoCompleteTextView = 2131492964;
				Base_V7_Widget_AppCompat_EditText = 2131492965;
				Base_V7_Widget_AppCompat_Toolbar = 2131492966;
				Base_Widget_AppCompat_ActionBar = 2131492967;
				Base_Widget_AppCompat_ActionBar_Solid = 2131492968;
				Base_Widget_AppCompat_ActionBar_TabBar = 2131492969;
				Base_Widget_AppCompat_ActionBar_TabText = 2131492970;
				Base_Widget_AppCompat_ActionBar_TabView = 2131492971;
				Base_Widget_AppCompat_ActionButton = 2131492972;
				Base_Widget_AppCompat_ActionButton_CloseMode = 2131492973;
				Base_Widget_AppCompat_ActionButton_Overflow = 2131492974;
				Base_Widget_AppCompat_ActionMode = 2131492975;
				Base_Widget_AppCompat_ActivityChooserView = 2131492976;
				Base_Widget_AppCompat_AutoCompleteTextView = 2131492977;
				Base_Widget_AppCompat_Button = 2131492978;
				Base_Widget_AppCompat_ButtonBar = 2131492984;
				Base_Widget_AppCompat_ButtonBar_AlertDialog = 2131492985;
				Base_Widget_AppCompat_Button_Borderless = 2131492979;
				Base_Widget_AppCompat_Button_Borderless_Colored = 2131492980;
				Base_Widget_AppCompat_Button_ButtonBar_AlertDialog = 2131492981;
				Base_Widget_AppCompat_Button_Colored = 2131492982;
				Base_Widget_AppCompat_Button_Small = 2131492983;
				Base_Widget_AppCompat_CompoundButton_CheckBox = 2131492986;
				Base_Widget_AppCompat_CompoundButton_RadioButton = 2131492987;
				Base_Widget_AppCompat_CompoundButton_Switch = 2131492988;
				Base_Widget_AppCompat_DrawerArrowToggle = 2131492989;
				Base_Widget_AppCompat_DrawerArrowToggle_Common = 2131492990;
				Base_Widget_AppCompat_DropDownItem_Spinner = 2131492991;
				Base_Widget_AppCompat_EditText = 2131492992;
				Base_Widget_AppCompat_ImageButton = 2131492993;
				Base_Widget_AppCompat_Light_ActionBar = 2131492994;
				Base_Widget_AppCompat_Light_ActionBar_Solid = 2131492995;
				Base_Widget_AppCompat_Light_ActionBar_TabBar = 2131492996;
				Base_Widget_AppCompat_Light_ActionBar_TabText = 2131492997;
				Base_Widget_AppCompat_Light_ActionBar_TabText_Inverse = 2131492998;
				Base_Widget_AppCompat_Light_ActionBar_TabView = 2131492999;
				Base_Widget_AppCompat_Light_PopupMenu = 2131493000;
				Base_Widget_AppCompat_Light_PopupMenu_Overflow = 2131493001;
				Base_Widget_AppCompat_ListMenuView = 2131493002;
				Base_Widget_AppCompat_ListPopupWindow = 2131493003;
				Base_Widget_AppCompat_ListView = 2131493004;
				Base_Widget_AppCompat_ListView_DropDown = 2131493005;
				Base_Widget_AppCompat_ListView_Menu = 2131493006;
				Base_Widget_AppCompat_PopupMenu = 2131493007;
				Base_Widget_AppCompat_PopupMenu_Overflow = 2131493008;
				Base_Widget_AppCompat_PopupWindow = 2131493009;
				Base_Widget_AppCompat_ProgressBar = 2131493010;
				Base_Widget_AppCompat_ProgressBar_Horizontal = 2131493011;
				Base_Widget_AppCompat_RatingBar = 2131493012;
				Base_Widget_AppCompat_RatingBar_Indicator = 2131493013;
				Base_Widget_AppCompat_RatingBar_Small = 2131493014;
				Base_Widget_AppCompat_SearchView = 2131493015;
				Base_Widget_AppCompat_SearchView_ActionBar = 2131493016;
				Base_Widget_AppCompat_SeekBar = 2131493017;
				Base_Widget_AppCompat_SeekBar_Discrete = 2131493018;
				Base_Widget_AppCompat_Spinner = 2131493019;
				Base_Widget_AppCompat_Spinner_Underlined = 2131493020;
				Base_Widget_AppCompat_TextView = 2131493021;
				Base_Widget_AppCompat_TextView_SpinnerItem = 2131493022;
				Base_Widget_AppCompat_Toolbar = 2131493023;
				Base_Widget_AppCompat_Toolbar_Button_Navigation = 2131493024;
				Platform_AppCompat = 2131493025;
				Platform_AppCompat_Light = 2131493026;
				Platform_ThemeOverlay_AppCompat = 2131493027;
				Platform_ThemeOverlay_AppCompat_Dark = 2131493028;
				Platform_ThemeOverlay_AppCompat_Light = 2131493029;
				Platform_V21_AppCompat = 2131493030;
				Platform_V21_AppCompat_Light = 2131493031;
				Platform_V25_AppCompat = 2131493032;
				Platform_V25_AppCompat_Light = 2131493033;
				Platform_Widget_AppCompat_Spinner = 2131493034;
				RtlOverlay_DialogWindowTitle_AppCompat = 2131493035;
				RtlOverlay_Widget_AppCompat_ActionBar_TitleItem = 2131493036;
				RtlOverlay_Widget_AppCompat_DialogTitle_Icon = 2131493037;
				RtlOverlay_Widget_AppCompat_PopupMenuItem = 2131493038;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_InternalGroup = 2131493039;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Shortcut = 2131493040;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_SubmenuArrow = 2131493041;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Text = 2131493042;
				RtlOverlay_Widget_AppCompat_PopupMenuItem_Title = 2131493043;
				RtlOverlay_Widget_AppCompat_SearchView_MagIcon = 2131493049;
				RtlOverlay_Widget_AppCompat_Search_DropDown = 2131493044;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Icon1 = 2131493045;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Icon2 = 2131493046;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Query = 2131493047;
				RtlOverlay_Widget_AppCompat_Search_DropDown_Text = 2131493048;
				RtlUnderlay_Widget_AppCompat_ActionButton = 2131493050;
				RtlUnderlay_Widget_AppCompat_ActionButton_Overflow = 2131493051;
				TextAppearance_AppCompat = 2131493052;
				TextAppearance_AppCompat_Body1 = 2131493053;
				TextAppearance_AppCompat_Body2 = 2131493054;
				TextAppearance_AppCompat_Button = 2131493055;
				TextAppearance_AppCompat_Caption = 2131493056;
				TextAppearance_AppCompat_Display1 = 2131493057;
				TextAppearance_AppCompat_Display2 = 2131493058;
				TextAppearance_AppCompat_Display3 = 2131493059;
				TextAppearance_AppCompat_Display4 = 2131493060;
				TextAppearance_AppCompat_Headline = 2131493061;
				TextAppearance_AppCompat_Inverse = 2131493062;
				TextAppearance_AppCompat_Large = 2131493063;
				TextAppearance_AppCompat_Large_Inverse = 2131493064;
				TextAppearance_AppCompat_Light_SearchResult_Subtitle = 2131493065;
				TextAppearance_AppCompat_Light_SearchResult_Title = 2131493066;
				TextAppearance_AppCompat_Light_Widget_PopupMenu_Large = 2131493067;
				TextAppearance_AppCompat_Light_Widget_PopupMenu_Small = 2131493068;
				TextAppearance_AppCompat_Medium = 2131493069;
				TextAppearance_AppCompat_Medium_Inverse = 2131493070;
				TextAppearance_AppCompat_Menu = 2131493071;
				TextAppearance_AppCompat_SearchResult_Subtitle = 2131493072;
				TextAppearance_AppCompat_SearchResult_Title = 2131493073;
				TextAppearance_AppCompat_Small = 2131493074;
				TextAppearance_AppCompat_Small_Inverse = 2131493075;
				TextAppearance_AppCompat_Subhead = 2131493076;
				TextAppearance_AppCompat_Subhead_Inverse = 2131493077;
				TextAppearance_AppCompat_Title = 2131493078;
				TextAppearance_AppCompat_Title_Inverse = 2131493079;
				TextAppearance_AppCompat_Tooltip = 2131493080;
				TextAppearance_AppCompat_Widget_ActionBar_Menu = 2131493081;
				TextAppearance_AppCompat_Widget_ActionBar_Subtitle = 2131493082;
				TextAppearance_AppCompat_Widget_ActionBar_Subtitle_Inverse = 2131493083;
				TextAppearance_AppCompat_Widget_ActionBar_Title = 2131493084;
				TextAppearance_AppCompat_Widget_ActionBar_Title_Inverse = 2131493085;
				TextAppearance_AppCompat_Widget_ActionMode_Subtitle = 2131493086;
				TextAppearance_AppCompat_Widget_ActionMode_Subtitle_Inverse = 2131493087;
				TextAppearance_AppCompat_Widget_ActionMode_Title = 2131493088;
				TextAppearance_AppCompat_Widget_ActionMode_Title_Inverse = 2131493089;
				TextAppearance_AppCompat_Widget_Button = 2131493090;
				TextAppearance_AppCompat_Widget_Button_Borderless_Colored = 2131493091;
				TextAppearance_AppCompat_Widget_Button_Colored = 2131493092;
				TextAppearance_AppCompat_Widget_Button_Inverse = 2131493093;
				TextAppearance_AppCompat_Widget_DropDownItem = 2131493094;
				TextAppearance_AppCompat_Widget_PopupMenu_Header = 2131493095;
				TextAppearance_AppCompat_Widget_PopupMenu_Large = 2131493096;
				TextAppearance_AppCompat_Widget_PopupMenu_Small = 2131493097;
				TextAppearance_AppCompat_Widget_Switch = 2131493098;
				TextAppearance_AppCompat_Widget_TextView_SpinnerItem = 2131493099;
				TextAppearance_Compat_Notification = 2131493100;
				TextAppearance_Compat_Notification_Info = 2131493101;
				TextAppearance_Compat_Notification_Line2 = 2131493102;
				TextAppearance_Compat_Notification_Time = 2131493103;
				TextAppearance_Compat_Notification_Title = 2131493104;
				TextAppearance_Widget_AppCompat_ExpandedMenu_Item = 2131493105;
				TextAppearance_Widget_AppCompat_Toolbar_Subtitle = 2131493106;
				TextAppearance_Widget_AppCompat_Toolbar_Title = 2131493107;
				ThemeOverlay_AppCompat = 2131493130;
				ThemeOverlay_AppCompat_ActionBar = 2131493131;
				ThemeOverlay_AppCompat_Dark = 2131493132;
				ThemeOverlay_AppCompat_Dark_ActionBar = 2131493133;
				ThemeOverlay_AppCompat_DayNight = 2131493134;
				ThemeOverlay_AppCompat_DayNight_ActionBar = 2131493135;
				ThemeOverlay_AppCompat_Dialog = 2131493136;
				ThemeOverlay_AppCompat_Dialog_Alert = 2131493137;
				ThemeOverlay_AppCompat_Light = 2131493138;
				Theme_AppCompat = 2131493108;
				Theme_AppCompat_CompactMenu = 2131493109;
				Theme_AppCompat_DayNight = 2131493110;
				Theme_AppCompat_DayNight_DarkActionBar = 2131493111;
				Theme_AppCompat_DayNight_Dialog = 2131493112;
				Theme_AppCompat_DayNight_DialogWhenLarge = 2131493115;
				Theme_AppCompat_DayNight_Dialog_Alert = 2131493113;
				Theme_AppCompat_DayNight_Dialog_MinWidth = 2131493114;
				Theme_AppCompat_DayNight_NoActionBar = 2131493116;
				Theme_AppCompat_Dialog = 2131493117;
				Theme_AppCompat_DialogWhenLarge = 2131493120;
				Theme_AppCompat_Dialog_Alert = 2131493118;
				Theme_AppCompat_Dialog_MinWidth = 2131493119;
				Theme_AppCompat_Empty = 2131493121;
				Theme_AppCompat_Light = 2131493122;
				Theme_AppCompat_Light_DarkActionBar = 2131493123;
				Theme_AppCompat_Light_Dialog = 2131493124;
				Theme_AppCompat_Light_DialogWhenLarge = 2131493127;
				Theme_AppCompat_Light_Dialog_Alert = 2131493125;
				Theme_AppCompat_Light_Dialog_MinWidth = 2131493126;
				Theme_AppCompat_Light_NoActionBar = 2131493128;
				Theme_AppCompat_NoActionBar = 2131493129;
				Widget_AppCompat_ActionBar = 2131493139;
				Widget_AppCompat_ActionBar_Solid = 2131493140;
				Widget_AppCompat_ActionBar_TabBar = 2131493141;
				Widget_AppCompat_ActionBar_TabText = 2131493142;
				Widget_AppCompat_ActionBar_TabView = 2131493143;
				Widget_AppCompat_ActionButton = 2131493144;
				Widget_AppCompat_ActionButton_CloseMode = 2131493145;
				Widget_AppCompat_ActionButton_Overflow = 2131493146;
				Widget_AppCompat_ActionMode = 2131493147;
				Widget_AppCompat_ActivityChooserView = 2131493148;
				Widget_AppCompat_AutoCompleteTextView = 2131493149;
				Widget_AppCompat_Button = 2131493150;
				Widget_AppCompat_ButtonBar = 2131493156;
				Widget_AppCompat_ButtonBar_AlertDialog = 2131493157;
				Widget_AppCompat_Button_Borderless = 2131493151;
				Widget_AppCompat_Button_Borderless_Colored = 2131493152;
				Widget_AppCompat_Button_ButtonBar_AlertDialog = 2131493153;
				Widget_AppCompat_Button_Colored = 2131493154;
				Widget_AppCompat_Button_Small = 2131493155;
				Widget_AppCompat_CompoundButton_CheckBox = 2131493158;
				Widget_AppCompat_CompoundButton_RadioButton = 2131493159;
				Widget_AppCompat_CompoundButton_Switch = 2131493160;
				Widget_AppCompat_DrawerArrowToggle = 2131493161;
				Widget_AppCompat_DropDownItem_Spinner = 2131493162;
				Widget_AppCompat_EditText = 2131493163;
				Widget_AppCompat_ImageButton = 2131493164;
				Widget_AppCompat_Light_ActionBar = 2131493165;
				Widget_AppCompat_Light_ActionBar_Solid = 2131493166;
				Widget_AppCompat_Light_ActionBar_Solid_Inverse = 2131493167;
				Widget_AppCompat_Light_ActionBar_TabBar = 2131493168;
				Widget_AppCompat_Light_ActionBar_TabBar_Inverse = 2131493169;
				Widget_AppCompat_Light_ActionBar_TabText = 2131493170;
				Widget_AppCompat_Light_ActionBar_TabText_Inverse = 2131493171;
				Widget_AppCompat_Light_ActionBar_TabView = 2131493172;
				Widget_AppCompat_Light_ActionBar_TabView_Inverse = 2131493173;
				Widget_AppCompat_Light_ActionButton = 2131493174;
				Widget_AppCompat_Light_ActionButton_CloseMode = 2131493175;
				Widget_AppCompat_Light_ActionButton_Overflow = 2131493176;
				Widget_AppCompat_Light_ActionMode_Inverse = 2131493177;
				Widget_AppCompat_Light_ActivityChooserView = 2131493178;
				Widget_AppCompat_Light_AutoCompleteTextView = 2131493179;
				Widget_AppCompat_Light_DropDownItem_Spinner = 2131493180;
				Widget_AppCompat_Light_ListPopupWindow = 2131493181;
				Widget_AppCompat_Light_ListView_DropDown = 2131493182;
				Widget_AppCompat_Light_PopupMenu = 2131493183;
				Widget_AppCompat_Light_PopupMenu_Overflow = 2131493184;
				Widget_AppCompat_Light_SearchView = 2131493185;
				Widget_AppCompat_Light_Spinner_DropDown_ActionBar = 2131493186;
				Widget_AppCompat_ListMenuView = 2131493187;
				Widget_AppCompat_ListPopupWindow = 2131493188;
				Widget_AppCompat_ListView = 2131493189;
				Widget_AppCompat_ListView_DropDown = 2131493190;
				Widget_AppCompat_ListView_Menu = 2131493191;
				Widget_AppCompat_PopupMenu = 2131493192;
				Widget_AppCompat_PopupMenu_Overflow = 2131493193;
				Widget_AppCompat_PopupWindow = 2131493194;
				Widget_AppCompat_ProgressBar = 2131493195;
				Widget_AppCompat_ProgressBar_Horizontal = 2131493196;
				Widget_AppCompat_RatingBar = 2131493197;
				Widget_AppCompat_RatingBar_Indicator = 2131493198;
				Widget_AppCompat_RatingBar_Small = 2131493199;
				Widget_AppCompat_SearchView = 2131493200;
				Widget_AppCompat_SearchView_ActionBar = 2131493201;
				Widget_AppCompat_SeekBar = 2131493202;
				Widget_AppCompat_SeekBar_Discrete = 2131493203;
				Widget_AppCompat_Spinner = 2131493204;
				Widget_AppCompat_Spinner_DropDown = 2131493205;
				Widget_AppCompat_Spinner_DropDown_ActionBar = 2131493206;
				Widget_AppCompat_Spinner_Underlined = 2131493207;
				Widget_AppCompat_TextView = 2131493208;
				Widget_AppCompat_TextView_SpinnerItem = 2131493209;
				Widget_AppCompat_Toolbar = 2131493210;
				Widget_AppCompat_Toolbar_Button_Navigation = 2131493211;
				Widget_Compat_NotificationActionContainer = 2131493212;
				Widget_Compat_NotificationActionText = 2131493213;
				Widget_Support_CoordinatorLayout = 2131493214;
				ResourceIdManager.UpdateIdValues();
			}

			private Style()
			{
			}
		}

		public class Styleable
		{
			public static int[] ActionBar;

			public static int[] ActionBarLayout;

			public static int ActionBarLayout_android_layout_gravity;

			public static int ActionBar_background;

			public static int ActionBar_backgroundSplit;

			public static int ActionBar_backgroundStacked;

			public static int ActionBar_contentInsetEnd;

			public static int ActionBar_contentInsetEndWithActions;

			public static int ActionBar_contentInsetLeft;

			public static int ActionBar_contentInsetRight;

			public static int ActionBar_contentInsetStart;

			public static int ActionBar_contentInsetStartWithNavigation;

			public static int ActionBar_customNavigationLayout;

			public static int ActionBar_displayOptions;

			public static int ActionBar_divider;

			public static int ActionBar_elevation;

			public static int ActionBar_height;

			public static int ActionBar_hideOnContentScroll;

			public static int ActionBar_homeAsUpIndicator;

			public static int ActionBar_homeLayout;

			public static int ActionBar_icon;

			public static int ActionBar_indeterminateProgressStyle;

			public static int ActionBar_itemPadding;

			public static int ActionBar_logo;

			public static int ActionBar_navigationMode;

			public static int ActionBar_popupTheme;

			public static int ActionBar_progressBarPadding;

			public static int ActionBar_progressBarStyle;

			public static int ActionBar_subtitle;

			public static int ActionBar_subtitleTextStyle;

			public static int ActionBar_title;

			public static int ActionBar_titleTextStyle;

			public static int[] ActionMenuItemView;

			public static int ActionMenuItemView_android_minWidth;

			public static int[] ActionMenuView;

			public static int[] ActionMode;

			public static int ActionMode_background;

			public static int ActionMode_backgroundSplit;

			public static int ActionMode_closeItemLayout;

			public static int ActionMode_height;

			public static int ActionMode_subtitleTextStyle;

			public static int ActionMode_titleTextStyle;

			public static int[] ActivityChooserView;

			public static int ActivityChooserView_expandActivityOverflowButtonDrawable;

			public static int ActivityChooserView_initialActivityCount;

			public static int[] AlertDialog;

			public static int AlertDialog_android_layout;

			public static int AlertDialog_buttonIconDimen;

			public static int AlertDialog_buttonPanelSideLayout;

			public static int AlertDialog_listItemLayout;

			public static int AlertDialog_listLayout;

			public static int AlertDialog_multiChoiceItemLayout;

			public static int AlertDialog_showTitle;

			public static int AlertDialog_singleChoiceItemLayout;

			public static int[] AnimatedStateListDrawableCompat;

			public static int AnimatedStateListDrawableCompat_android_constantSize;

			public static int AnimatedStateListDrawableCompat_android_dither;

			public static int AnimatedStateListDrawableCompat_android_enterFadeDuration;

			public static int AnimatedStateListDrawableCompat_android_exitFadeDuration;

			public static int AnimatedStateListDrawableCompat_android_variablePadding;

			public static int AnimatedStateListDrawableCompat_android_visible;

			public static int[] AnimatedStateListDrawableItem;

			public static int AnimatedStateListDrawableItem_android_drawable;

			public static int AnimatedStateListDrawableItem_android_id;

			public static int[] AnimatedStateListDrawableTransition;

			public static int AnimatedStateListDrawableTransition_android_drawable;

			public static int AnimatedStateListDrawableTransition_android_fromId;

			public static int AnimatedStateListDrawableTransition_android_reversible;

			public static int AnimatedStateListDrawableTransition_android_toId;

			public static int[] AppCompatImageView;

			public static int AppCompatImageView_android_src;

			public static int AppCompatImageView_srcCompat;

			public static int AppCompatImageView_tint;

			public static int AppCompatImageView_tintMode;

			public static int[] AppCompatSeekBar;

			public static int AppCompatSeekBar_android_thumb;

			public static int AppCompatSeekBar_tickMark;

			public static int AppCompatSeekBar_tickMarkTint;

			public static int AppCompatSeekBar_tickMarkTintMode;

			public static int[] AppCompatTextHelper;

			public static int AppCompatTextHelper_android_drawableBottom;

			public static int AppCompatTextHelper_android_drawableEnd;

			public static int AppCompatTextHelper_android_drawableLeft;

			public static int AppCompatTextHelper_android_drawableRight;

			public static int AppCompatTextHelper_android_drawableStart;

			public static int AppCompatTextHelper_android_drawableTop;

			public static int AppCompatTextHelper_android_textAppearance;

			public static int[] AppCompatTextView;

			public static int AppCompatTextView_android_textAppearance;

			public static int AppCompatTextView_autoSizeMaxTextSize;

			public static int AppCompatTextView_autoSizeMinTextSize;

			public static int AppCompatTextView_autoSizePresetSizes;

			public static int AppCompatTextView_autoSizeStepGranularity;

			public static int AppCompatTextView_autoSizeTextType;

			public static int AppCompatTextView_drawableBottomCompat;

			public static int AppCompatTextView_drawableEndCompat;

			public static int AppCompatTextView_drawableLeftCompat;

			public static int AppCompatTextView_drawableRightCompat;

			public static int AppCompatTextView_drawableStartCompat;

			public static int AppCompatTextView_drawableTint;

			public static int AppCompatTextView_drawableTintMode;

			public static int AppCompatTextView_drawableTopCompat;

			public static int AppCompatTextView_firstBaselineToTopHeight;

			public static int AppCompatTextView_fontFamily;

			public static int AppCompatTextView_fontVariationSettings;

			public static int AppCompatTextView_lastBaselineToBottomHeight;

			public static int AppCompatTextView_lineHeight;

			public static int AppCompatTextView_textAllCaps;

			public static int AppCompatTextView_textLocale;

			public static int[] AppCompatTheme;

			public static int AppCompatTheme_actionBarDivider;

			public static int AppCompatTheme_actionBarItemBackground;

			public static int AppCompatTheme_actionBarPopupTheme;

			public static int AppCompatTheme_actionBarSize;

			public static int AppCompatTheme_actionBarSplitStyle;

			public static int AppCompatTheme_actionBarStyle;

			public static int AppCompatTheme_actionBarTabBarStyle;

			public static int AppCompatTheme_actionBarTabStyle;

			public static int AppCompatTheme_actionBarTabTextStyle;

			public static int AppCompatTheme_actionBarTheme;

			public static int AppCompatTheme_actionBarWidgetTheme;

			public static int AppCompatTheme_actionButtonStyle;

			public static int AppCompatTheme_actionDropDownStyle;

			public static int AppCompatTheme_actionMenuTextAppearance;

			public static int AppCompatTheme_actionMenuTextColor;

			public static int AppCompatTheme_actionModeBackground;

			public static int AppCompatTheme_actionModeCloseButtonStyle;

			public static int AppCompatTheme_actionModeCloseDrawable;

			public static int AppCompatTheme_actionModeCopyDrawable;

			public static int AppCompatTheme_actionModeCutDrawable;

			public static int AppCompatTheme_actionModeFindDrawable;

			public static int AppCompatTheme_actionModePasteDrawable;

			public static int AppCompatTheme_actionModePopupWindowStyle;

			public static int AppCompatTheme_actionModeSelectAllDrawable;

			public static int AppCompatTheme_actionModeShareDrawable;

			public static int AppCompatTheme_actionModeSplitBackground;

			public static int AppCompatTheme_actionModeStyle;

			public static int AppCompatTheme_actionModeWebSearchDrawable;

			public static int AppCompatTheme_actionOverflowButtonStyle;

			public static int AppCompatTheme_actionOverflowMenuStyle;

			public static int AppCompatTheme_activityChooserViewStyle;

			public static int AppCompatTheme_alertDialogButtonGroupStyle;

			public static int AppCompatTheme_alertDialogCenterButtons;

			public static int AppCompatTheme_alertDialogStyle;

			public static int AppCompatTheme_alertDialogTheme;

			public static int AppCompatTheme_android_windowAnimationStyle;

			public static int AppCompatTheme_android_windowIsFloating;

			public static int AppCompatTheme_autoCompleteTextViewStyle;

			public static int AppCompatTheme_borderlessButtonStyle;

			public static int AppCompatTheme_buttonBarButtonStyle;

			public static int AppCompatTheme_buttonBarNegativeButtonStyle;

			public static int AppCompatTheme_buttonBarNeutralButtonStyle;

			public static int AppCompatTheme_buttonBarPositiveButtonStyle;

			public static int AppCompatTheme_buttonBarStyle;

			public static int AppCompatTheme_buttonStyle;

			public static int AppCompatTheme_buttonStyleSmall;

			public static int AppCompatTheme_checkboxStyle;

			public static int AppCompatTheme_checkedTextViewStyle;

			public static int AppCompatTheme_colorAccent;

			public static int AppCompatTheme_colorBackgroundFloating;

			public static int AppCompatTheme_colorButtonNormal;

			public static int AppCompatTheme_colorControlActivated;

			public static int AppCompatTheme_colorControlHighlight;

			public static int AppCompatTheme_colorControlNormal;

			public static int AppCompatTheme_colorError;

			public static int AppCompatTheme_colorPrimary;

			public static int AppCompatTheme_colorPrimaryDark;

			public static int AppCompatTheme_colorSwitchThumbNormal;

			public static int AppCompatTheme_controlBackground;

			public static int AppCompatTheme_dialogCornerRadius;

			public static int AppCompatTheme_dialogPreferredPadding;

			public static int AppCompatTheme_dialogTheme;

			public static int AppCompatTheme_dividerHorizontal;

			public static int AppCompatTheme_dividerVertical;

			public static int AppCompatTheme_dropdownListPreferredItemHeight;

			public static int AppCompatTheme_dropDownListViewStyle;

			public static int AppCompatTheme_editTextBackground;

			public static int AppCompatTheme_editTextColor;

			public static int AppCompatTheme_editTextStyle;

			public static int AppCompatTheme_homeAsUpIndicator;

			public static int AppCompatTheme_imageButtonStyle;

			public static int AppCompatTheme_listChoiceBackgroundIndicator;

			public static int AppCompatTheme_listChoiceIndicatorMultipleAnimated;

			public static int AppCompatTheme_listChoiceIndicatorSingleAnimated;

			public static int AppCompatTheme_listDividerAlertDialog;

			public static int AppCompatTheme_listMenuViewStyle;

			public static int AppCompatTheme_listPopupWindowStyle;

			public static int AppCompatTheme_listPreferredItemHeight;

			public static int AppCompatTheme_listPreferredItemHeightLarge;

			public static int AppCompatTheme_listPreferredItemHeightSmall;

			public static int AppCompatTheme_listPreferredItemPaddingEnd;

			public static int AppCompatTheme_listPreferredItemPaddingLeft;

			public static int AppCompatTheme_listPreferredItemPaddingRight;

			public static int AppCompatTheme_listPreferredItemPaddingStart;

			public static int AppCompatTheme_panelBackground;

			public static int AppCompatTheme_panelMenuListTheme;

			public static int AppCompatTheme_panelMenuListWidth;

			public static int AppCompatTheme_popupMenuStyle;

			public static int AppCompatTheme_popupWindowStyle;

			public static int AppCompatTheme_radioButtonStyle;

			public static int AppCompatTheme_ratingBarStyle;

			public static int AppCompatTheme_ratingBarStyleIndicator;

			public static int AppCompatTheme_ratingBarStyleSmall;

			public static int AppCompatTheme_searchViewStyle;

			public static int AppCompatTheme_seekBarStyle;

			public static int AppCompatTheme_selectableItemBackground;

			public static int AppCompatTheme_selectableItemBackgroundBorderless;

			public static int AppCompatTheme_spinnerDropDownItemStyle;

			public static int AppCompatTheme_spinnerStyle;

			public static int AppCompatTheme_switchStyle;

			public static int AppCompatTheme_textAppearanceLargePopupMenu;

			public static int AppCompatTheme_textAppearanceListItem;

			public static int AppCompatTheme_textAppearanceListItemSecondary;

			public static int AppCompatTheme_textAppearanceListItemSmall;

			public static int AppCompatTheme_textAppearancePopupMenuHeader;

			public static int AppCompatTheme_textAppearanceSearchResultSubtitle;

			public static int AppCompatTheme_textAppearanceSearchResultTitle;

			public static int AppCompatTheme_textAppearanceSmallPopupMenu;

			public static int AppCompatTheme_textColorAlertDialogListItem;

			public static int AppCompatTheme_textColorSearchUrl;

			public static int AppCompatTheme_toolbarNavigationButtonStyle;

			public static int AppCompatTheme_toolbarStyle;

			public static int AppCompatTheme_tooltipForegroundColor;

			public static int AppCompatTheme_tooltipFrameBackground;

			public static int AppCompatTheme_viewInflaterClass;

			public static int AppCompatTheme_windowActionBar;

			public static int AppCompatTheme_windowActionBarOverlay;

			public static int AppCompatTheme_windowActionModeOverlay;

			public static int AppCompatTheme_windowFixedHeightMajor;

			public static int AppCompatTheme_windowFixedHeightMinor;

			public static int AppCompatTheme_windowFixedWidthMajor;

			public static int AppCompatTheme_windowFixedWidthMinor;

			public static int AppCompatTheme_windowMinWidthMajor;

			public static int AppCompatTheme_windowMinWidthMinor;

			public static int AppCompatTheme_windowNoTitle;

			public static int[] ButtonBarLayout;

			public static int ButtonBarLayout_allowStacking;

			public static int[] ColorStateListItem;

			public static int ColorStateListItem_alpha;

			public static int ColorStateListItem_android_alpha;

			public static int ColorStateListItem_android_color;

			public static int[] CompoundButton;

			public static int CompoundButton_android_button;

			public static int CompoundButton_buttonCompat;

			public static int CompoundButton_buttonTint;

			public static int CompoundButton_buttonTintMode;

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

			public static int[] DrawerArrowToggle;

			public static int DrawerArrowToggle_arrowHeadLength;

			public static int DrawerArrowToggle_arrowShaftLength;

			public static int DrawerArrowToggle_barLength;

			public static int DrawerArrowToggle_color;

			public static int DrawerArrowToggle_drawableSize;

			public static int DrawerArrowToggle_gapBetweenBars;

			public static int DrawerArrowToggle_spinBars;

			public static int DrawerArrowToggle_thickness;

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

			public static int[] LinearLayoutCompat;

			public static int LinearLayoutCompat_android_baselineAligned;

			public static int LinearLayoutCompat_android_baselineAlignedChildIndex;

			public static int LinearLayoutCompat_android_gravity;

			public static int LinearLayoutCompat_android_orientation;

			public static int LinearLayoutCompat_android_weightSum;

			public static int LinearLayoutCompat_divider;

			public static int LinearLayoutCompat_dividerPadding;

			public static int[] LinearLayoutCompat_Layout;

			public static int LinearLayoutCompat_Layout_android_layout_gravity;

			public static int LinearLayoutCompat_Layout_android_layout_height;

			public static int LinearLayoutCompat_Layout_android_layout_weight;

			public static int LinearLayoutCompat_Layout_android_layout_width;

			public static int LinearLayoutCompat_measureWithLargestChild;

			public static int LinearLayoutCompat_showDividers;

			public static int[] ListPopupWindow;

			public static int ListPopupWindow_android_dropDownHorizontalOffset;

			public static int ListPopupWindow_android_dropDownVerticalOffset;

			public static int[] MenuGroup;

			public static int MenuGroup_android_checkableBehavior;

			public static int MenuGroup_android_enabled;

			public static int MenuGroup_android_id;

			public static int MenuGroup_android_menuCategory;

			public static int MenuGroup_android_orderInCategory;

			public static int MenuGroup_android_visible;

			public static int[] MenuItem;

			public static int MenuItem_actionLayout;

			public static int MenuItem_actionProviderClass;

			public static int MenuItem_actionViewClass;

			public static int MenuItem_alphabeticModifiers;

			public static int MenuItem_android_alphabeticShortcut;

			public static int MenuItem_android_checkable;

			public static int MenuItem_android_checked;

			public static int MenuItem_android_enabled;

			public static int MenuItem_android_icon;

			public static int MenuItem_android_id;

			public static int MenuItem_android_menuCategory;

			public static int MenuItem_android_numericShortcut;

			public static int MenuItem_android_onClick;

			public static int MenuItem_android_orderInCategory;

			public static int MenuItem_android_title;

			public static int MenuItem_android_titleCondensed;

			public static int MenuItem_android_visible;

			public static int MenuItem_contentDescription;

			public static int MenuItem_iconTint;

			public static int MenuItem_iconTintMode;

			public static int MenuItem_numericModifiers;

			public static int MenuItem_showAsAction;

			public static int MenuItem_tooltipText;

			public static int[] MenuView;

			public static int MenuView_android_headerBackground;

			public static int MenuView_android_horizontalDivider;

			public static int MenuView_android_itemBackground;

			public static int MenuView_android_itemIconDisabledAlpha;

			public static int MenuView_android_itemTextAppearance;

			public static int MenuView_android_verticalDivider;

			public static int MenuView_android_windowAnimationStyle;

			public static int MenuView_preserveIconSpacing;

			public static int MenuView_subMenuArrow;

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

			public static int[] MvxRecyclerView;

			public static int MvxRecyclerView_MvxTemplateSelector;

			public static int[] PopupWindow;

			public static int[] PopupWindowBackgroundState;

			public static int PopupWindowBackgroundState_state_above_anchor;

			public static int PopupWindow_android_popupAnimationStyle;

			public static int PopupWindow_android_popupBackground;

			public static int PopupWindow_overlapAnchor;

			public static int[] RecycleListView;

			public static int RecycleListView_paddingBottomNoButtons;

			public static int RecycleListView_paddingTopNoTitle;

			public static int[] RecyclerView;

			public static int RecyclerView_android_clipToPadding;

			public static int RecyclerView_android_descendantFocusability;

			public static int RecyclerView_android_orientation;

			public static int RecyclerView_fastScrollEnabled;

			public static int RecyclerView_fastScrollHorizontalThumbDrawable;

			public static int RecyclerView_fastScrollHorizontalTrackDrawable;

			public static int RecyclerView_fastScrollVerticalThumbDrawable;

			public static int RecyclerView_fastScrollVerticalTrackDrawable;

			public static int RecyclerView_layoutManager;

			public static int RecyclerView_reverseLayout;

			public static int RecyclerView_spanCount;

			public static int RecyclerView_stackFromEnd;

			public static int[] SearchView;

			public static int SearchView_android_focusable;

			public static int SearchView_android_imeOptions;

			public static int SearchView_android_inputType;

			public static int SearchView_android_maxWidth;

			public static int SearchView_closeIcon;

			public static int SearchView_commitIcon;

			public static int SearchView_defaultQueryHint;

			public static int SearchView_goIcon;

			public static int SearchView_iconifiedByDefault;

			public static int SearchView_layout;

			public static int SearchView_queryBackground;

			public static int SearchView_queryHint;

			public static int SearchView_searchHintIcon;

			public static int SearchView_searchIcon;

			public static int SearchView_submitBackground;

			public static int SearchView_suggestionRowLayout;

			public static int SearchView_voiceIcon;

			public static int[] Spinner;

			public static int Spinner_android_dropDownWidth;

			public static int Spinner_android_entries;

			public static int Spinner_android_popupBackground;

			public static int Spinner_android_prompt;

			public static int Spinner_popupTheme;

			public static int[] StateListDrawable;

			public static int[] StateListDrawableItem;

			public static int StateListDrawableItem_android_drawable;

			public static int StateListDrawable_android_constantSize;

			public static int StateListDrawable_android_dither;

			public static int StateListDrawable_android_enterFadeDuration;

			public static int StateListDrawable_android_exitFadeDuration;

			public static int StateListDrawable_android_variablePadding;

			public static int StateListDrawable_android_visible;

			public static int[] SwitchCompat;

			public static int SwitchCompat_android_textOff;

			public static int SwitchCompat_android_textOn;

			public static int SwitchCompat_android_thumb;

			public static int SwitchCompat_showText;

			public static int SwitchCompat_splitTrack;

			public static int SwitchCompat_switchMinWidth;

			public static int SwitchCompat_switchPadding;

			public static int SwitchCompat_switchTextAppearance;

			public static int SwitchCompat_thumbTextPadding;

			public static int SwitchCompat_thumbTint;

			public static int SwitchCompat_thumbTintMode;

			public static int SwitchCompat_track;

			public static int SwitchCompat_trackTint;

			public static int SwitchCompat_trackTintMode;

			public static int[] TextAppearance;

			public static int TextAppearance_android_fontFamily;

			public static int TextAppearance_android_shadowColor;

			public static int TextAppearance_android_shadowDx;

			public static int TextAppearance_android_shadowDy;

			public static int TextAppearance_android_shadowRadius;

			public static int TextAppearance_android_textColor;

			public static int TextAppearance_android_textColorHint;

			public static int TextAppearance_android_textColorLink;

			public static int TextAppearance_android_textFontWeight;

			public static int TextAppearance_android_textSize;

			public static int TextAppearance_android_textStyle;

			public static int TextAppearance_android_typeface;

			public static int TextAppearance_fontFamily;

			public static int TextAppearance_fontVariationSettings;

			public static int TextAppearance_textAllCaps;

			public static int TextAppearance_textLocale;

			public static int[] Toolbar;

			public static int Toolbar_android_gravity;

			public static int Toolbar_android_minHeight;

			public static int Toolbar_buttonGravity;

			public static int Toolbar_collapseContentDescription;

			public static int Toolbar_collapseIcon;

			public static int Toolbar_contentInsetEnd;

			public static int Toolbar_contentInsetEndWithActions;

			public static int Toolbar_contentInsetLeft;

			public static int Toolbar_contentInsetRight;

			public static int Toolbar_contentInsetStart;

			public static int Toolbar_contentInsetStartWithNavigation;

			public static int Toolbar_logo;

			public static int Toolbar_logoDescription;

			public static int Toolbar_maxButtonHeight;

			public static int Toolbar_menu;

			public static int Toolbar_navigationContentDescription;

			public static int Toolbar_navigationIcon;

			public static int Toolbar_popupTheme;

			public static int Toolbar_subtitle;

			public static int Toolbar_subtitleTextAppearance;

			public static int Toolbar_subtitleTextColor;

			public static int Toolbar_title;

			public static int Toolbar_titleMargin;

			public static int Toolbar_titleMarginBottom;

			public static int Toolbar_titleMarginEnd;

			public static int Toolbar_titleMargins;

			public static int Toolbar_titleMarginStart;

			public static int Toolbar_titleMarginTop;

			public static int Toolbar_titleTextAppearance;

			public static int Toolbar_titleTextColor;

			public static int[] View;

			public static int[] ViewBackgroundHelper;

			public static int ViewBackgroundHelper_android_background;

			public static int ViewBackgroundHelper_backgroundTint;

			public static int ViewBackgroundHelper_backgroundTintMode;

			public static int[] ViewStubCompat;

			public static int ViewStubCompat_android_id;

			public static int ViewStubCompat_android_inflatedId;

			public static int ViewStubCompat_android_layout;

			public static int View_android_focusable;

			public static int View_android_theme;

			public static int View_paddingEnd;

			public static int View_paddingStart;

			public static int View_theme;

			static Styleable()
			{
				ActionBar = new int[29]
				{
					2130837561, 2130837562, 2130837563, 2130837600, 2130837601, 2130837602, 2130837603, 2130837604, 2130837605, 2130837608,
					2130837613, 2130837614, 2130837633, 2130837654, 2130837655, 2130837656, 2130837657, 2130837658, 2130837663, 2130837666,
					2130837693, 2130837701, 2130837712, 2130837715, 2130837716, 2130837747, 2130837750, 2130837778, 2130837787
				};
				ActionBarLayout = new int[1] { 16842931 };
				ActionBarLayout_android_layout_gravity = 0;
				ActionBar_background = 0;
				ActionBar_backgroundSplit = 1;
				ActionBar_backgroundStacked = 2;
				ActionBar_contentInsetEnd = 3;
				ActionBar_contentInsetEndWithActions = 4;
				ActionBar_contentInsetLeft = 5;
				ActionBar_contentInsetRight = 6;
				ActionBar_contentInsetStart = 7;
				ActionBar_contentInsetStartWithNavigation = 8;
				ActionBar_customNavigationLayout = 9;
				ActionBar_displayOptions = 10;
				ActionBar_divider = 11;
				ActionBar_elevation = 12;
				ActionBar_height = 13;
				ActionBar_hideOnContentScroll = 14;
				ActionBar_homeAsUpIndicator = 15;
				ActionBar_homeLayout = 16;
				ActionBar_icon = 17;
				ActionBar_indeterminateProgressStyle = 18;
				ActionBar_itemPadding = 19;
				ActionBar_logo = 20;
				ActionBar_navigationMode = 21;
				ActionBar_popupTheme = 22;
				ActionBar_progressBarPadding = 23;
				ActionBar_progressBarStyle = 24;
				ActionBar_subtitle = 25;
				ActionBar_subtitleTextStyle = 26;
				ActionBar_title = 27;
				ActionBar_titleTextStyle = 28;
				ActionMenuItemView = new int[1] { 16843071 };
				ActionMenuItemView_android_minWidth = 0;
				ActionMenuView = new int[1] { -1 };
				ActionMode = new int[6] { 2130837561, 2130837562, 2130837584, 2130837654, 2130837750, 2130837787 };
				ActionMode_background = 0;
				ActionMode_backgroundSplit = 1;
				ActionMode_closeItemLayout = 2;
				ActionMode_height = 3;
				ActionMode_subtitleTextStyle = 4;
				ActionMode_titleTextStyle = 5;
				ActivityChooserView = new int[2] { 2130837634, 2130837664 };
				ActivityChooserView_expandActivityOverflowButtonDrawable = 0;
				ActivityChooserView_initialActivityCount = 1;
				AlertDialog = new int[8] { 16842994, 2130837575, 2130837576, 2130837682, 2130837683, 2130837698, 2130837734, 2130837735 };
				AlertDialog_android_layout = 0;
				AlertDialog_buttonIconDimen = 1;
				AlertDialog_buttonPanelSideLayout = 2;
				AlertDialog_listItemLayout = 3;
				AlertDialog_listLayout = 4;
				AlertDialog_multiChoiceItemLayout = 5;
				AlertDialog_showTitle = 6;
				AlertDialog_singleChoiceItemLayout = 7;
				AnimatedStateListDrawableCompat = new int[6] { 16843036, 16843156, 16843157, 16843158, 16843532, 16843533 };
				AnimatedStateListDrawableCompat_android_constantSize = 3;
				AnimatedStateListDrawableCompat_android_dither = 0;
				AnimatedStateListDrawableCompat_android_enterFadeDuration = 4;
				AnimatedStateListDrawableCompat_android_exitFadeDuration = 5;
				AnimatedStateListDrawableCompat_android_variablePadding = 2;
				AnimatedStateListDrawableCompat_android_visible = 1;
				AnimatedStateListDrawableItem = new int[2] { 16842960, 16843161 };
				AnimatedStateListDrawableItem_android_drawable = 1;
				AnimatedStateListDrawableItem_android_id = 0;
				AnimatedStateListDrawableTransition = new int[4] { 16843161, 16843849, 16843850, 16843851 };
				AnimatedStateListDrawableTransition_android_drawable = 0;
				AnimatedStateListDrawableTransition_android_fromId = 2;
				AnimatedStateListDrawableTransition_android_reversible = 3;
				AnimatedStateListDrawableTransition_android_toId = 1;
				AppCompatImageView = new int[4] { 16843033, 2130837741, 2130837776, 2130837777 };
				AppCompatImageView_android_src = 0;
				AppCompatImageView_srcCompat = 1;
				AppCompatImageView_tint = 2;
				AppCompatImageView_tintMode = 3;
				AppCompatSeekBar = new int[4] { 16843074, 2130837773, 2130837774, 2130837775 };
				AppCompatSeekBar_android_thumb = 0;
				AppCompatSeekBar_tickMark = 1;
				AppCompatSeekBar_tickMarkTint = 2;
				AppCompatSeekBar_tickMarkTintMode = 3;
				AppCompatTextHelper = new int[7] { 16842804, 16843117, 16843118, 16843119, 16843120, 16843666, 16843667 };
				AppCompatTextHelper_android_drawableBottom = 2;
				AppCompatTextHelper_android_drawableEnd = 6;
				AppCompatTextHelper_android_drawableLeft = 3;
				AppCompatTextHelper_android_drawableRight = 4;
				AppCompatTextHelper_android_drawableStart = 5;
				AppCompatTextHelper_android_drawableTop = 1;
				AppCompatTextHelper_android_textAppearance = 0;
				AppCompatTextView = new int[21]
				{
					16842804, 2130837556, 2130837557, 2130837558, 2130837559, 2130837560, 2130837618, 2130837619, 2130837620, 2130837621,
					2130837623, 2130837624, 2130837625, 2130837626, 2130837640, 2130837642, 2130837650, 2130837668, 2130837677, 2130837756,
					2130837767
				};
				AppCompatTextView_android_textAppearance = 0;
				AppCompatTextView_autoSizeMaxTextSize = 1;
				AppCompatTextView_autoSizeMinTextSize = 2;
				AppCompatTextView_autoSizePresetSizes = 3;
				AppCompatTextView_autoSizeStepGranularity = 4;
				AppCompatTextView_autoSizeTextType = 5;
				AppCompatTextView_drawableBottomCompat = 6;
				AppCompatTextView_drawableEndCompat = 7;
				AppCompatTextView_drawableLeftCompat = 8;
				AppCompatTextView_drawableRightCompat = 9;
				AppCompatTextView_drawableStartCompat = 10;
				AppCompatTextView_drawableTint = 11;
				AppCompatTextView_drawableTintMode = 12;
				AppCompatTextView_drawableTopCompat = 13;
				AppCompatTextView_firstBaselineToTopHeight = 14;
				AppCompatTextView_fontFamily = 15;
				AppCompatTextView_fontVariationSettings = 16;
				AppCompatTextView_lastBaselineToBottomHeight = 17;
				AppCompatTextView_lineHeight = 18;
				AppCompatTextView_textAllCaps = 19;
				AppCompatTextView_textLocale = 20;
				AppCompatTheme = new int[125]
				{
					16842839, 16842926, 2130837512, 2130837513, 2130837514, 2130837515, 2130837516, 2130837517, 2130837518, 2130837519,
					2130837520, 2130837521, 2130837522, 2130837523, 2130837524, 2130837526, 2130837527, 2130837528, 2130837529, 2130837530,
					2130837531, 2130837532, 2130837533, 2130837534, 2130837535, 2130837536, 2130837537, 2130837538, 2130837539, 2130837540,
					2130837541, 2130837542, 2130837545, 2130837546, 2130837547, 2130837548, 2130837549, 2130837555, 2130837567, 2130837568,
					2130837569, 2130837570, 2130837571, 2130837572, 2130837577, 2130837578, 2130837581, 2130837582, 2130837588, 2130837589,
					2130837590, 2130837591, 2130837592, 2130837593, 2130837594, 2130837595, 2130837596, 2130837597, 2130837606, 2130837610,
					2130837611, 2130837612, 2130837615, 2130837617, 2130837628, 2130837629, 2130837630, 2130837631, 2130837632, 2130837656,
					2130837662, 2130837678, 2130837679, 2130837680, 2130837681, 2130837684, 2130837685, 2130837686, 2130837687, 2130837688,
					2130837689, 2130837690, 2130837691, 2130837692, 2130837708, 2130837709, 2130837710, 2130837711, 2130837713, 2130837719,
					2130837720, 2130837721, 2130837722, 2130837727, 2130837728, 2130837729, 2130837730, 2130837738, 2130837739, 2130837754,
					2130837757, 2130837758, 2130837759, 2130837760, 2130837761, 2130837762, 2130837763, 2130837764, 2130837765, 2130837766,
					2130837788, 2130837789, 2130837790, 2130837791, 2130837797, 2130837799, 2130837800, 2130837801, 2130837802, 2130837803,
					2130837804, 2130837805, 2130837806, 2130837807, 2130837808
				};
				AppCompatTheme_actionBarDivider = 2;
				AppCompatTheme_actionBarItemBackground = 3;
				AppCompatTheme_actionBarPopupTheme = 4;
				AppCompatTheme_actionBarSize = 5;
				AppCompatTheme_actionBarSplitStyle = 6;
				AppCompatTheme_actionBarStyle = 7;
				AppCompatTheme_actionBarTabBarStyle = 8;
				AppCompatTheme_actionBarTabStyle = 9;
				AppCompatTheme_actionBarTabTextStyle = 10;
				AppCompatTheme_actionBarTheme = 11;
				AppCompatTheme_actionBarWidgetTheme = 12;
				AppCompatTheme_actionButtonStyle = 13;
				AppCompatTheme_actionDropDownStyle = 14;
				AppCompatTheme_actionMenuTextAppearance = 15;
				AppCompatTheme_actionMenuTextColor = 16;
				AppCompatTheme_actionModeBackground = 17;
				AppCompatTheme_actionModeCloseButtonStyle = 18;
				AppCompatTheme_actionModeCloseDrawable = 19;
				AppCompatTheme_actionModeCopyDrawable = 20;
				AppCompatTheme_actionModeCutDrawable = 21;
				AppCompatTheme_actionModeFindDrawable = 22;
				AppCompatTheme_actionModePasteDrawable = 23;
				AppCompatTheme_actionModePopupWindowStyle = 24;
				AppCompatTheme_actionModeSelectAllDrawable = 25;
				AppCompatTheme_actionModeShareDrawable = 26;
				AppCompatTheme_actionModeSplitBackground = 27;
				AppCompatTheme_actionModeStyle = 28;
				AppCompatTheme_actionModeWebSearchDrawable = 29;
				AppCompatTheme_actionOverflowButtonStyle = 30;
				AppCompatTheme_actionOverflowMenuStyle = 31;
				AppCompatTheme_activityChooserViewStyle = 32;
				AppCompatTheme_alertDialogButtonGroupStyle = 33;
				AppCompatTheme_alertDialogCenterButtons = 34;
				AppCompatTheme_alertDialogStyle = 35;
				AppCompatTheme_alertDialogTheme = 36;
				AppCompatTheme_android_windowAnimationStyle = 1;
				AppCompatTheme_android_windowIsFloating = 0;
				AppCompatTheme_autoCompleteTextViewStyle = 37;
				AppCompatTheme_borderlessButtonStyle = 38;
				AppCompatTheme_buttonBarButtonStyle = 39;
				AppCompatTheme_buttonBarNegativeButtonStyle = 40;
				AppCompatTheme_buttonBarNeutralButtonStyle = 41;
				AppCompatTheme_buttonBarPositiveButtonStyle = 42;
				AppCompatTheme_buttonBarStyle = 43;
				AppCompatTheme_buttonStyle = 44;
				AppCompatTheme_buttonStyleSmall = 45;
				AppCompatTheme_checkboxStyle = 46;
				AppCompatTheme_checkedTextViewStyle = 47;
				AppCompatTheme_colorAccent = 48;
				AppCompatTheme_colorBackgroundFloating = 49;
				AppCompatTheme_colorButtonNormal = 50;
				AppCompatTheme_colorControlActivated = 51;
				AppCompatTheme_colorControlHighlight = 52;
				AppCompatTheme_colorControlNormal = 53;
				AppCompatTheme_colorError = 54;
				AppCompatTheme_colorPrimary = 55;
				AppCompatTheme_colorPrimaryDark = 56;
				AppCompatTheme_colorSwitchThumbNormal = 57;
				AppCompatTheme_controlBackground = 58;
				AppCompatTheme_dialogCornerRadius = 59;
				AppCompatTheme_dialogPreferredPadding = 60;
				AppCompatTheme_dialogTheme = 61;
				AppCompatTheme_dividerHorizontal = 62;
				AppCompatTheme_dividerVertical = 63;
				AppCompatTheme_dropdownListPreferredItemHeight = 65;
				AppCompatTheme_dropDownListViewStyle = 64;
				AppCompatTheme_editTextBackground = 66;
				AppCompatTheme_editTextColor = 67;
				AppCompatTheme_editTextStyle = 68;
				AppCompatTheme_homeAsUpIndicator = 69;
				AppCompatTheme_imageButtonStyle = 70;
				AppCompatTheme_listChoiceBackgroundIndicator = 71;
				AppCompatTheme_listChoiceIndicatorMultipleAnimated = 72;
				AppCompatTheme_listChoiceIndicatorSingleAnimated = 73;
				AppCompatTheme_listDividerAlertDialog = 74;
				AppCompatTheme_listMenuViewStyle = 75;
				AppCompatTheme_listPopupWindowStyle = 76;
				AppCompatTheme_listPreferredItemHeight = 77;
				AppCompatTheme_listPreferredItemHeightLarge = 78;
				AppCompatTheme_listPreferredItemHeightSmall = 79;
				AppCompatTheme_listPreferredItemPaddingEnd = 80;
				AppCompatTheme_listPreferredItemPaddingLeft = 81;
				AppCompatTheme_listPreferredItemPaddingRight = 82;
				AppCompatTheme_listPreferredItemPaddingStart = 83;
				AppCompatTheme_panelBackground = 84;
				AppCompatTheme_panelMenuListTheme = 85;
				AppCompatTheme_panelMenuListWidth = 86;
				AppCompatTheme_popupMenuStyle = 87;
				AppCompatTheme_popupWindowStyle = 88;
				AppCompatTheme_radioButtonStyle = 89;
				AppCompatTheme_ratingBarStyle = 90;
				AppCompatTheme_ratingBarStyleIndicator = 91;
				AppCompatTheme_ratingBarStyleSmall = 92;
				AppCompatTheme_searchViewStyle = 93;
				AppCompatTheme_seekBarStyle = 94;
				AppCompatTheme_selectableItemBackground = 95;
				AppCompatTheme_selectableItemBackgroundBorderless = 96;
				AppCompatTheme_spinnerDropDownItemStyle = 97;
				AppCompatTheme_spinnerStyle = 98;
				AppCompatTheme_switchStyle = 99;
				AppCompatTheme_textAppearanceLargePopupMenu = 100;
				AppCompatTheme_textAppearanceListItem = 101;
				AppCompatTheme_textAppearanceListItemSecondary = 102;
				AppCompatTheme_textAppearanceListItemSmall = 103;
				AppCompatTheme_textAppearancePopupMenuHeader = 104;
				AppCompatTheme_textAppearanceSearchResultSubtitle = 105;
				AppCompatTheme_textAppearanceSearchResultTitle = 106;
				AppCompatTheme_textAppearanceSmallPopupMenu = 107;
				AppCompatTheme_textColorAlertDialogListItem = 108;
				AppCompatTheme_textColorSearchUrl = 109;
				AppCompatTheme_toolbarNavigationButtonStyle = 110;
				AppCompatTheme_toolbarStyle = 111;
				AppCompatTheme_tooltipForegroundColor = 112;
				AppCompatTheme_tooltipFrameBackground = 113;
				AppCompatTheme_viewInflaterClass = 114;
				AppCompatTheme_windowActionBar = 115;
				AppCompatTheme_windowActionBarOverlay = 116;
				AppCompatTheme_windowActionModeOverlay = 117;
				AppCompatTheme_windowFixedHeightMajor = 118;
				AppCompatTheme_windowFixedHeightMinor = 119;
				AppCompatTheme_windowFixedWidthMajor = 120;
				AppCompatTheme_windowFixedWidthMinor = 121;
				AppCompatTheme_windowMinWidthMajor = 122;
				AppCompatTheme_windowMinWidthMinor = 123;
				AppCompatTheme_windowNoTitle = 124;
				ButtonBarLayout = new int[1] { 2130837550 };
				ButtonBarLayout_allowStacking = 0;
				ColorStateListItem = new int[3] { 16843173, 16843551, 2130837551 };
				ColorStateListItem_alpha = 2;
				ColorStateListItem_android_alpha = 1;
				ColorStateListItem_android_color = 0;
				CompoundButton = new int[4] { 16843015, 2130837573, 2130837579, 2130837580 };
				CompoundButton_android_button = 0;
				CompoundButton_buttonCompat = 1;
				CompoundButton_buttonTint = 2;
				CompoundButton_buttonTintMode = 3;
				CoordinatorLayout = new int[2] { 2130837667, 2130837744 };
				CoordinatorLayout_keylines = 0;
				CoordinatorLayout_Layout = new int[7] { 16842931, 2130837671, 2130837672, 2130837673, 2130837674, 2130837675, 2130837676 };
				CoordinatorLayout_Layout_android_layout_gravity = 0;
				CoordinatorLayout_Layout_layout_anchor = 1;
				CoordinatorLayout_Layout_layout_anchorGravity = 2;
				CoordinatorLayout_Layout_layout_behavior = 3;
				CoordinatorLayout_Layout_layout_dodgeInsetEdges = 4;
				CoordinatorLayout_Layout_layout_insetEdge = 5;
				CoordinatorLayout_Layout_layout_keyline = 6;
				CoordinatorLayout_statusBarBackground = 1;
				DrawerArrowToggle = new int[8] { 2130837553, 2130837554, 2130837566, 2130837587, 2130837622, 2130837652, 2130837737, 2130837769 };
				DrawerArrowToggle_arrowHeadLength = 0;
				DrawerArrowToggle_arrowShaftLength = 1;
				DrawerArrowToggle_barLength = 2;
				DrawerArrowToggle_color = 3;
				DrawerArrowToggle_drawableSize = 4;
				DrawerArrowToggle_gapBetweenBars = 5;
				DrawerArrowToggle_spinBars = 6;
				DrawerArrowToggle_thickness = 7;
				FontFamily = new int[6] { 2130837643, 2130837644, 2130837645, 2130837646, 2130837647, 2130837648 };
				FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130837641, 2130837649, 2130837650, 2130837651, 2130837796 };
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
				LinearLayoutCompat = new int[9] { 16842927, 16842948, 16843046, 16843047, 16843048, 2130837614, 2130837616, 2130837696, 2130837732 };
				LinearLayoutCompat_android_baselineAligned = 2;
				LinearLayoutCompat_android_baselineAlignedChildIndex = 3;
				LinearLayoutCompat_android_gravity = 0;
				LinearLayoutCompat_android_orientation = 1;
				LinearLayoutCompat_android_weightSum = 4;
				LinearLayoutCompat_divider = 5;
				LinearLayoutCompat_dividerPadding = 6;
				LinearLayoutCompat_Layout = new int[4] { 16842931, 16842996, 16842997, 16843137 };
				LinearLayoutCompat_Layout_android_layout_gravity = 0;
				LinearLayoutCompat_Layout_android_layout_height = 2;
				LinearLayoutCompat_Layout_android_layout_weight = 3;
				LinearLayoutCompat_Layout_android_layout_width = 1;
				LinearLayoutCompat_measureWithLargestChild = 7;
				LinearLayoutCompat_showDividers = 8;
				ListPopupWindow = new int[2] { 16843436, 16843437 };
				ListPopupWindow_android_dropDownHorizontalOffset = 0;
				ListPopupWindow_android_dropDownVerticalOffset = 1;
				MenuGroup = new int[6] { 16842766, 16842960, 16843156, 16843230, 16843231, 16843232 };
				MenuGroup_android_checkableBehavior = 5;
				MenuGroup_android_enabled = 0;
				MenuGroup_android_id = 1;
				MenuGroup_android_menuCategory = 3;
				MenuGroup_android_orderInCategory = 4;
				MenuGroup_android_visible = 2;
				MenuItem = new int[23]
				{
					16842754, 16842766, 16842960, 16843014, 16843156, 16843230, 16843231, 16843233, 16843234, 16843235,
					16843236, 16843237, 16843375, 2130837525, 2130837543, 2130837544, 2130837552, 2130837599, 2130837659, 2130837660,
					2130837702, 2130837731, 2130837792
				};
				MenuItem_actionLayout = 13;
				MenuItem_actionProviderClass = 14;
				MenuItem_actionViewClass = 15;
				MenuItem_alphabeticModifiers = 16;
				MenuItem_android_alphabeticShortcut = 9;
				MenuItem_android_checkable = 11;
				MenuItem_android_checked = 3;
				MenuItem_android_enabled = 1;
				MenuItem_android_icon = 0;
				MenuItem_android_id = 2;
				MenuItem_android_menuCategory = 5;
				MenuItem_android_numericShortcut = 10;
				MenuItem_android_onClick = 12;
				MenuItem_android_orderInCategory = 6;
				MenuItem_android_title = 7;
				MenuItem_android_titleCondensed = 8;
				MenuItem_android_visible = 4;
				MenuItem_contentDescription = 17;
				MenuItem_iconTint = 18;
				MenuItem_iconTintMode = 19;
				MenuItem_numericModifiers = 20;
				MenuItem_showAsAction = 21;
				MenuItem_tooltipText = 22;
				MenuView = new int[9] { 16842926, 16843052, 16843053, 16843054, 16843055, 16843056, 16843057, 2130837714, 2130837745 };
				MenuView_android_headerBackground = 4;
				MenuView_android_horizontalDivider = 2;
				MenuView_android_itemBackground = 5;
				MenuView_android_itemIconDisabledAlpha = 6;
				MenuView_android_itemTextAppearance = 1;
				MenuView_android_verticalDivider = 3;
				MenuView_android_windowAnimationStyle = 0;
				MenuView_preserveIconSpacing = 7;
				MenuView_subMenuArrow = 8;
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
				MvxRecyclerView = new int[1] { 2130837511 };
				MvxRecyclerView_MvxTemplateSelector = 0;
				PopupWindow = new int[3] { 16843126, 16843465, 2130837703 };
				PopupWindowBackgroundState = new int[1] { 2130837743 };
				PopupWindowBackgroundState_state_above_anchor = 0;
				PopupWindow_android_popupAnimationStyle = 1;
				PopupWindow_android_popupBackground = 0;
				PopupWindow_overlapAnchor = 2;
				RecycleListView = new int[2] { 2130837704, 2130837707 };
				RecycleListView_paddingBottomNoButtons = 0;
				RecycleListView_paddingTopNoTitle = 1;
				RecyclerView = new int[12]
				{
					16842948, 16842987, 16842993, 2130837635, 2130837636, 2130837637, 2130837638, 2130837639, 2130837670, 2130837724,
					2130837736, 2130837742
				};
				RecyclerView_android_clipToPadding = 1;
				RecyclerView_android_descendantFocusability = 2;
				RecyclerView_android_orientation = 0;
				RecyclerView_fastScrollEnabled = 3;
				RecyclerView_fastScrollHorizontalThumbDrawable = 4;
				RecyclerView_fastScrollHorizontalTrackDrawable = 5;
				RecyclerView_fastScrollVerticalThumbDrawable = 6;
				RecyclerView_fastScrollVerticalTrackDrawable = 7;
				RecyclerView_layoutManager = 8;
				RecyclerView_reverseLayout = 9;
				RecyclerView_spanCount = 10;
				RecyclerView_stackFromEnd = 11;
				SearchView = new int[17]
				{
					16842970, 16843039, 16843296, 16843364, 2130837583, 2130837598, 2130837609, 2130837653, 2130837661, 2130837669,
					2130837717, 2130837718, 2130837725, 2130837726, 2130837746, 2130837751, 2130837798
				};
				SearchView_android_focusable = 0;
				SearchView_android_imeOptions = 3;
				SearchView_android_inputType = 2;
				SearchView_android_maxWidth = 1;
				SearchView_closeIcon = 4;
				SearchView_commitIcon = 5;
				SearchView_defaultQueryHint = 6;
				SearchView_goIcon = 7;
				SearchView_iconifiedByDefault = 8;
				SearchView_layout = 9;
				SearchView_queryBackground = 10;
				SearchView_queryHint = 11;
				SearchView_searchHintIcon = 12;
				SearchView_searchIcon = 13;
				SearchView_submitBackground = 14;
				SearchView_suggestionRowLayout = 15;
				SearchView_voiceIcon = 16;
				Spinner = new int[5] { 16842930, 16843126, 16843131, 16843362, 2130837712 };
				Spinner_android_dropDownWidth = 3;
				Spinner_android_entries = 0;
				Spinner_android_popupBackground = 1;
				Spinner_android_prompt = 2;
				Spinner_popupTheme = 4;
				StateListDrawable = new int[6] { 16843036, 16843156, 16843157, 16843158, 16843532, 16843533 };
				StateListDrawableItem = new int[1] { 16843161 };
				StateListDrawableItem_android_drawable = 0;
				StateListDrawable_android_constantSize = 3;
				StateListDrawable_android_dither = 0;
				StateListDrawable_android_enterFadeDuration = 4;
				StateListDrawable_android_exitFadeDuration = 5;
				StateListDrawable_android_variablePadding = 2;
				StateListDrawable_android_visible = 1;
				SwitchCompat = new int[14]
				{
					16843044, 16843045, 16843074, 2130837733, 2130837740, 2130837752, 2130837753, 2130837755, 2130837770, 2130837771,
					2130837772, 2130837793, 2130837794, 2130837795
				};
				SwitchCompat_android_textOff = 1;
				SwitchCompat_android_textOn = 0;
				SwitchCompat_android_thumb = 2;
				SwitchCompat_showText = 3;
				SwitchCompat_splitTrack = 4;
				SwitchCompat_switchMinWidth = 5;
				SwitchCompat_switchPadding = 6;
				SwitchCompat_switchTextAppearance = 7;
				SwitchCompat_thumbTextPadding = 8;
				SwitchCompat_thumbTint = 9;
				SwitchCompat_thumbTintMode = 10;
				SwitchCompat_track = 11;
				SwitchCompat_trackTint = 12;
				SwitchCompat_trackTintMode = 13;
				TextAppearance = new int[16]
				{
					16842901, 16842902, 16842903, 16842904, 16842906, 16842907, 16843105, 16843106, 16843107, 16843108,
					16843692, 16844165, 2130837642, 2130837650, 2130837756, 2130837767
				};
				TextAppearance_android_fontFamily = 10;
				TextAppearance_android_shadowColor = 6;
				TextAppearance_android_shadowDx = 7;
				TextAppearance_android_shadowDy = 8;
				TextAppearance_android_shadowRadius = 9;
				TextAppearance_android_textColor = 3;
				TextAppearance_android_textColorHint = 4;
				TextAppearance_android_textColorLink = 5;
				TextAppearance_android_textFontWeight = 11;
				TextAppearance_android_textSize = 0;
				TextAppearance_android_textStyle = 2;
				TextAppearance_android_typeface = 1;
				TextAppearance_fontFamily = 12;
				TextAppearance_fontVariationSettings = 13;
				TextAppearance_textAllCaps = 14;
				TextAppearance_textLocale = 15;
				Toolbar = new int[30]
				{
					16842927, 16843072, 2130837574, 2130837585, 2130837586, 2130837600, 2130837601, 2130837602, 2130837603, 2130837604,
					2130837605, 2130837693, 2130837694, 2130837695, 2130837697, 2130837699, 2130837700, 2130837712, 2130837747, 2130837748,
					2130837749, 2130837778, 2130837779, 2130837780, 2130837781, 2130837782, 2130837783, 2130837784, 2130837785, 2130837786
				};
				Toolbar_android_gravity = 0;
				Toolbar_android_minHeight = 1;
				Toolbar_buttonGravity = 2;
				Toolbar_collapseContentDescription = 3;
				Toolbar_collapseIcon = 4;
				Toolbar_contentInsetEnd = 5;
				Toolbar_contentInsetEndWithActions = 6;
				Toolbar_contentInsetLeft = 7;
				Toolbar_contentInsetRight = 8;
				Toolbar_contentInsetStart = 9;
				Toolbar_contentInsetStartWithNavigation = 10;
				Toolbar_logo = 11;
				Toolbar_logoDescription = 12;
				Toolbar_maxButtonHeight = 13;
				Toolbar_menu = 14;
				Toolbar_navigationContentDescription = 15;
				Toolbar_navigationIcon = 16;
				Toolbar_popupTheme = 17;
				Toolbar_subtitle = 18;
				Toolbar_subtitleTextAppearance = 19;
				Toolbar_subtitleTextColor = 20;
				Toolbar_title = 21;
				Toolbar_titleMargin = 22;
				Toolbar_titleMarginBottom = 23;
				Toolbar_titleMarginEnd = 24;
				Toolbar_titleMargins = 27;
				Toolbar_titleMarginStart = 25;
				Toolbar_titleMarginTop = 26;
				Toolbar_titleTextAppearance = 28;
				Toolbar_titleTextColor = 29;
				View = new int[5] { 16842752, 16842970, 2130837705, 2130837706, 2130837768 };
				ViewBackgroundHelper = new int[3] { 16842964, 2130837564, 2130837565 };
				ViewBackgroundHelper_android_background = 0;
				ViewBackgroundHelper_backgroundTint = 1;
				ViewBackgroundHelper_backgroundTintMode = 2;
				ViewStubCompat = new int[3] { 16842960, 16842994, 16842995 };
				ViewStubCompat_android_id = 0;
				ViewStubCompat_android_inflatedId = 2;
				ViewStubCompat_android_layout = 1;
				View_android_focusable = 1;
				View_android_theme = 0;
				View_paddingEnd = 2;
				View_paddingStart = 3;
				View_theme = 4;
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
namespace MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates
{
	public abstract class MvxTemplateSelector<TItem> : IMvxTemplateSelector where TItem : class
	{
		public int GetItemViewType(object forItemObject)
		{
			return SelectItemViewType(forItemObject as TItem);
		}

		public abstract int GetItemLayoutId(int fromViewType);

		protected abstract int SelectItemViewType(TItem forItemObject);
	}
	public class MvxDefaultTemplateSelector : IMvxTemplateSelector
	{
		public int ItemTemplateId { get; set; }

		public MvxDefaultTemplateSelector(int itemTemplateId)
		{
			ItemTemplateId = itemTemplateId;
		}

		public MvxDefaultTemplateSelector()
		{
		}

		public int GetItemViewType(object forItemObject)
		{
			return 0;
		}

		public int GetItemLayoutId(int fromViewType)
		{
			return ItemTemplateId;
		}
	}
	public interface IMvxTemplateSelector
	{
		int GetItemViewType(object forItemObject);

		int GetItemLayoutId(int fromViewType);
	}
}
namespace MvvmCross.Droid.Support.V7.RecyclerView.AttributeHelpers
{
	public static class MvxRecyclerViewAttributeExtensions
	{
		private static bool areBindingResourcesInitialized;

		private static int[] MvxRecyclerViewItemTemplateSelectorGroupId { get; set; }

		private static int MvxRecyclerViewItemTemplateSelector { get; set; }

		private static string ReadRecyclerViewItemTemplateSelectorClassName(Context context, IAttributeSet attrs)
		{
			TryInitializeBindingResourcePaths();
			TypedArray typedArray = null;
			string text = string.Empty;
			try
			{
				typedArray = context.ObtainStyledAttributes(attrs, MvxRecyclerViewItemTemplateSelectorGroupId);
				int indexCount = typedArray.IndexCount;
				for (int i = 0; i < indexCount; i++)
				{
					int index = typedArray.GetIndex(i);
					if (index == MvxRecyclerViewItemTemplateSelector)
					{
						text = typedArray.GetString(index);
					}
				}
			}
			finally
			{
				typedArray?.Recycle();
			}
			if (string.IsNullOrEmpty(text))
			{
				return typeof(MvxDefaultTemplateSelector).FullName;
			}
			return text;
		}

		public static IMvxTemplateSelector BuildItemTemplateSelector(Context context, IAttributeSet attrs)
		{
			string text = ReadRecyclerViewItemTemplateSelectorClassName(context, attrs);
			Type type = Type.GetType(text);
			if (type == null)
			{
				string message = "Sorry but type with class name: " + text + " does not exist.Make sure you have provided full Type name: namespace + class name, AssemblyName.Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
				Mvx.Error(message);
				throw new InvalidOperationException(message);
			}
			if (!typeof(IMvxTemplateSelector).IsAssignableFrom(type))
			{
				string message2 = string.Format("Sorry but type: {0} does not implement {1} interface.", type, "IMvxTemplateSelector");
				Mvx.Error(message2);
				throw new InvalidOperationException(message2);
			}
			if (type.IsAbstract)
			{
				string message3 = string.Format("Sorry can not instatiate {0} as provided type: {1} is abstract/interface.", "IMvxTemplateSelector", type);
				Mvx.Error(message3);
				throw new InvalidOperationException(message3);
			}
			return Activator.CreateInstance(type) as IMvxTemplateSelector;
		}

		private static void TryInitializeBindingResourcePaths()
		{
			if (!areBindingResourcesInitialized)
			{
				areBindingResourcesInitialized = true;
				Type nestedType = Mvx.Resolve<IMvxAppResourceTypeFinder>().Find().GetNestedType("Styleable");
				MvxRecyclerViewItemTemplateSelectorGroupId = (int[])nestedType.GetField("MvxRecyclerView").GetValue(null);
				MvxRecyclerViewItemTemplateSelector = (int)nestedType.GetField("MvxRecyclerView_MvxTemplateSelector").GetValue(null);
			}
		}
	}
}
