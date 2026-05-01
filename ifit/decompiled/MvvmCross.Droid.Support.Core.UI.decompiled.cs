using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Windows.Input;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.SwipeRefreshLayout.Widget;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: ResourceDesigner("MvvmCross.Droid.Support.Core.UI.Resource", IsApplication = false)]
[assembly: AssemblyTitle("MvvmCross.Droid.Support.Core.UI")]
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
	[Register("mvvmcross.droid.support.v4.MvxSwipeRefreshLayout")]
	public class MvxSwipeRefreshLayout : SwipeRefreshLayout
	{
		private ICommand _refreshCommand;

		private bool _refreshOverloaded;

		public ICommand RefreshCommand
		{
			get
			{
				return _refreshCommand;
			}
			set
			{
				_refreshCommand = value;
				if (_refreshCommand != null)
				{
					EnsureRefreshCommandOverloaded();
				}
			}
		}

		protected MvxSwipeRefreshLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public MvxSwipeRefreshLayout(Context context)
			: this(context, null)
		{
		}

		public MvxSwipeRefreshLayout(Context context, IAttributeSet attributes)
			: base(context, attributes)
		{
		}

		private void EnsureRefreshCommandOverloaded()
		{
			if (!_refreshOverloaded)
			{
				_refreshOverloaded = true;
				base.Refresh += OnRefresh;
			}
		}

		protected virtual void ExecuteRefreshCommand(ICommand command)
		{
			if (command != null && command.CanExecute(null))
			{
				command.Execute(null);
			}
		}

		private void OnRefresh(object sender, EventArgs args)
		{
			ExecuteRefreshCommand(RefreshCommand);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				base.Refresh -= OnRefresh;
			}
			base.Dispose(disposing);
		}
	}
}
namespace MvvmCross.Droid.Support.Core.UI
{
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			public static int alpha;

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

			public static int ttcIndex;

			static Attribute()
			{
				alpha = 2130771968;
				font = 2130771969;
				fontProviderAuthority = 2130771970;
				fontProviderCerts = 2130771971;
				fontProviderFetchStrategy = 2130771972;
				fontProviderFetchTimeout = 2130771973;
				fontProviderPackage = 2130771974;
				fontProviderQuery = 2130771975;
				fontStyle = 2130771976;
				fontVariationSettings = 2130771977;
				fontWeight = 2130771978;
				ttcIndex = 2130771979;
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

			static Color()
			{
				androidx_core_ripple_material_light = 2130837504;
				androidx_core_secondary_text_default_material_light = 2130837505;
				notification_action_color_filter = 2130837506;
				notification_icon_bg_color = 2130837507;
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

			static Dimension()
			{
				compat_button_inset_horizontal_material = 2130903040;
				compat_button_inset_vertical_material = 2130903041;
				compat_button_padding_horizontal_material = 2130903042;
				compat_button_padding_vertical_material = 2130903043;
				compat_control_corner_material = 2130903044;
				compat_notification_large_icon_max_height = 2130903045;
				compat_notification_large_icon_max_width = 2130903046;
				notification_action_icon_size = 2130903047;
				notification_action_text_size = 2130903048;
				notification_big_circle_margin = 2130903049;
				notification_content_margin_start = 2130903050;
				notification_large_icon_height = 2130903051;
				notification_large_icon_width = 2130903052;
				notification_main_column_padding_top = 2130903053;
				notification_media_narrow_margin = 2130903054;
				notification_right_icon_size = 2130903055;
				notification_right_side_padding_top = 2130903056;
				notification_small_icon_background_padding = 2130903057;
				notification_small_icon_size_as_large = 2130903058;
				notification_subtext_size = 2130903059;
				notification_top_pad = 2130903060;
				notification_top_pad_large_text = 2130903061;
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
				notification_action_background = 2130968576;
				notification_bg = 2130968577;
				notification_bg_low = 2130968578;
				notification_bg_low_normal = 2130968579;
				notification_bg_low_pressed = 2130968580;
				notification_bg_normal = 2130968581;
				notification_bg_normal_pressed = 2130968582;
				notification_icon_background = 2130968583;
				notification_template_icon_bg = 2130968584;
				notification_template_icon_low_bg = 2130968585;
				notification_tile_bg = 2130968586;
				notify_panel_notification_icon_bg = 2130968587;
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

			public static int action_container;

			public static int action_divider;

			public static int action_image;

			public static int action_text;

			public static int async;

			public static int blocking;

			public static int chronometer;

			public static int dialog_button;

			public static int forever;

			public static int icon;

			public static int icon_group;

			public static int info;

			public static int italic;

			public static int line1;

			public static int line3;

			public static int normal;

			public static int notification_background;

			public static int notification_main_column;

			public static int notification_main_column_container;

			public static int right_icon;

			public static int right_side;

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

			static Id()
			{
				accessibility_action_clickable_span = 2131034112;
				accessibility_custom_action_0 = 2131034113;
				accessibility_custom_action_1 = 2131034114;
				accessibility_custom_action_10 = 2131034115;
				accessibility_custom_action_11 = 2131034116;
				accessibility_custom_action_12 = 2131034117;
				accessibility_custom_action_13 = 2131034118;
				accessibility_custom_action_14 = 2131034119;
				accessibility_custom_action_15 = 2131034120;
				accessibility_custom_action_16 = 2131034121;
				accessibility_custom_action_17 = 2131034122;
				accessibility_custom_action_18 = 2131034123;
				accessibility_custom_action_19 = 2131034124;
				accessibility_custom_action_2 = 2131034125;
				accessibility_custom_action_20 = 2131034126;
				accessibility_custom_action_21 = 2131034127;
				accessibility_custom_action_22 = 2131034128;
				accessibility_custom_action_23 = 2131034129;
				accessibility_custom_action_24 = 2131034130;
				accessibility_custom_action_25 = 2131034131;
				accessibility_custom_action_26 = 2131034132;
				accessibility_custom_action_27 = 2131034133;
				accessibility_custom_action_28 = 2131034134;
				accessibility_custom_action_29 = 2131034135;
				accessibility_custom_action_3 = 2131034136;
				accessibility_custom_action_30 = 2131034137;
				accessibility_custom_action_31 = 2131034138;
				accessibility_custom_action_4 = 2131034139;
				accessibility_custom_action_5 = 2131034140;
				accessibility_custom_action_6 = 2131034141;
				accessibility_custom_action_7 = 2131034142;
				accessibility_custom_action_8 = 2131034143;
				accessibility_custom_action_9 = 2131034144;
				actions = 2131034149;
				action_container = 2131034145;
				action_divider = 2131034146;
				action_image = 2131034147;
				action_text = 2131034148;
				async = 2131034150;
				blocking = 2131034151;
				chronometer = 2131034152;
				dialog_button = 2131034153;
				forever = 2131034154;
				icon = 2131034155;
				icon_group = 2131034156;
				info = 2131034157;
				italic = 2131034158;
				line1 = 2131034159;
				line3 = 2131034160;
				normal = 2131034161;
				notification_background = 2131034162;
				notification_main_column = 2131034163;
				notification_main_column_container = 2131034164;
				right_icon = 2131034165;
				right_side = 2131034166;
				tag_accessibility_actions = 2131034167;
				tag_accessibility_clickable_spans = 2131034168;
				tag_accessibility_heading = 2131034169;
				tag_accessibility_pane_title = 2131034170;
				tag_screen_reader_focusable = 2131034171;
				tag_transition_group = 2131034172;
				tag_unhandled_key_event_manager = 2131034173;
				tag_unhandled_key_listeners = 2131034174;
				text = 2131034175;
				text2 = 2131034176;
				time = 2131034177;
				title = 2131034178;
				ResourceIdManager.UpdateIdValues();
			}

			private Id()
			{
			}
		}

		public class Integer
		{
			public static int status_bar_notification_info_maxnum;

			static Integer()
			{
				status_bar_notification_info_maxnum = 2131099648;
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

			public static int notification_template_custom_big;

			public static int notification_template_icon_group;

			public static int notification_template_part_chronometer;

			public static int notification_template_part_time;

			static Layout()
			{
				custom_dialog = 2131165184;
				notification_action = 2131165185;
				notification_action_tombstone = 2131165186;
				notification_template_custom_big = 2131165187;
				notification_template_icon_group = 2131165188;
				notification_template_part_chronometer = 2131165189;
				notification_template_part_time = 2131165190;
				ResourceIdManager.UpdateIdValues();
			}

			private Layout()
			{
			}
		}

		public class String
		{
			public static int status_bar_notification_info_overflow;

			static String()
			{
				status_bar_notification_info_overflow = 2131230720;
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

			public static int TextAppearance_Compat_Notification_Line2;

			public static int TextAppearance_Compat_Notification_Time;

			public static int TextAppearance_Compat_Notification_Title;

			public static int Widget_Compat_NotificationActionContainer;

			public static int Widget_Compat_NotificationActionText;

			static Style()
			{
				TextAppearance_Compat_Notification = 2131296256;
				TextAppearance_Compat_Notification_Info = 2131296257;
				TextAppearance_Compat_Notification_Line2 = 2131296258;
				TextAppearance_Compat_Notification_Time = 2131296259;
				TextAppearance_Compat_Notification_Title = 2131296260;
				Widget_Compat_NotificationActionContainer = 2131296261;
				Widget_Compat_NotificationActionText = 2131296262;
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

			static Styleable()
			{
				ColorStateListItem = new int[3] { 16843173, 16843551, 2130771968 };
				ColorStateListItem_alpha = 2;
				ColorStateListItem_android_alpha = 1;
				ColorStateListItem_android_color = 0;
				FontFamily = new int[6] { 2130771970, 2130771971, 2130771972, 2130771973, 2130771974, 2130771975 };
				FontFamilyFont = new int[10] { 16844082, 16844083, 16844095, 16844143, 16844144, 2130771969, 2130771976, 2130771977, 2130771978, 2130771979 };
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
