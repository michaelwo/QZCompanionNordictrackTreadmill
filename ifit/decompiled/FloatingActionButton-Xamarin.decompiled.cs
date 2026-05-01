using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Interop;
using Java.Lang;

[assembly: AssemblyTitle("FloatingActionButton-Xamarin")]
[assembly: AssemblyDescription("Yet another implementation of Floating Action Button for Android with lots of features.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("A Java Library binding for the FloatingActionButton library by Dmitry Tarianyk")]
[assembly: AssemblyCopyright("Fabio Nuno")]
[assembly: AssemblyTrademark("")]
[assembly: NamespaceMapping(Java = "com.github.clans.fab", Managed = "Clans.Fab")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.6.4.0")]
[module: UnverifiableCode]
namespace Clans.Fab
{
	[Register("com/github/clans/fab/FloatingActionButton", DoNotGenerateAcw = true)]
	public class FloatingActionButton : ImageButton
	{
		[Register("com/github/clans/fab/FloatingActionButton$CircleDrawable", DoNotGenerateAcw = true)]
		public class CircleDrawable : ShapeDrawable
		{
			protected CircleDrawable(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/github/clans/fab/FloatingActionButton$ProgressSavedState", DoNotGenerateAcw = true)]
		public class ProgressSavedState : BaseSavedState
		{
			private static IntPtr CREATOR_jfieldId;

			internal static IntPtr java_class_handle;

			[Register("CREATOR")]
			public static IParcelableCreator Creator
			{
				get
				{
					if (CREATOR_jfieldId == IntPtr.Zero)
					{
						CREATOR_jfieldId = JNIEnv.GetStaticFieldID(class_ref, "CREATOR", "Landroid/os/Parcelable$Creator;");
					}
					IntPtr staticObjectField = JNIEnv.GetStaticObjectField(class_ref, CREATOR_jfieldId);
					return Java.Lang.Object.GetObject<IParcelableCreator>(staticObjectField, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/FloatingActionButton$ProgressSavedState", ref java_class_handle);

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(ProgressSavedState);

			protected ProgressSavedState(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("com/github/clans/fab/FloatingActionButton$Shadow", DoNotGenerateAcw = true)]
		public class Shadow : Drawable
		{
			internal static IntPtr java_class_handle;

			private static Delegate cb_getOpacity;

			private static IntPtr id_getOpacity;

			private static Delegate cb_draw_Landroid_graphics_Canvas_;

			private static IntPtr id_draw_Landroid_graphics_Canvas_;

			private static Delegate cb_setAlpha_I;

			private static IntPtr id_setAlpha_I;

			private static Delegate cb_setColorFilter_Landroid_graphics_ColorFilter_;

			private static IntPtr id_setColorFilter_Landroid_graphics_ColorFilter_;

			internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/FloatingActionButton$Shadow", ref java_class_handle);

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(Shadow);

			public override int Opacity
			{
				[Register("getOpacity", "()I", "GetGetOpacityHandler")]
				get
				{
					if (id_getOpacity == IntPtr.Zero)
					{
						id_getOpacity = JNIEnv.GetMethodID(class_ref, "getOpacity", "()I");
					}
					try
					{
						if (GetType() == ThresholdType)
						{
							return JNIEnv.CallIntMethod(base.Handle, id_getOpacity);
						}
						return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getOpacity", "()I"));
					}
					finally
					{
					}
				}
			}

			protected Shadow(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetOpacityHandler()
			{
				if ((object)cb_getOpacity == null)
				{
					cb_getOpacity = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetOpacity));
				}
				return cb_getOpacity;
			}

			private static int n_GetOpacity(IntPtr jnienv, IntPtr native__this)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return shadow.Opacity;
			}

			private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
			{
				if ((object)cb_draw_Landroid_graphics_Canvas_ == null)
				{
					cb_draw_Landroid_graphics_Canvas_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Draw_Landroid_graphics_Canvas_));
				}
				return cb_draw_Landroid_graphics_Canvas_;
			}

			private static void n_Draw_Landroid_graphics_Canvas_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_p0, JniHandleOwnership.DoNotTransfer);
				shadow.Draw(canvas);
			}

			[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
			public unsafe override void Draw(Canvas p0)
			{
				if (id_draw_Landroid_graphics_Canvas_ == IntPtr.Zero)
				{
					id_draw_Landroid_graphics_Canvas_ = JNIEnv.GetMethodID(class_ref, "draw", "(Landroid/graphics/Canvas;)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_draw_Landroid_graphics_Canvas_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "draw", "(Landroid/graphics/Canvas;)V"), ptr);
					}
				}
				finally
				{
				}
			}

			private static Delegate GetSetAlpha_IHandler()
			{
				if ((object)cb_setAlpha_I == null)
				{
					cb_setAlpha_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAlpha_I));
				}
				return cb_setAlpha_I;
			}

			private static void n_SetAlpha_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				shadow.SetAlpha(p0);
			}

			[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
			public unsafe override void SetAlpha(int p0)
			{
				if (id_setAlpha_I == IntPtr.Zero)
				{
					id_setAlpha_I = JNIEnv.GetMethodID(class_ref, "setAlpha", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setAlpha_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAlpha", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}

			private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
			{
				if ((object)cb_setColorFilter_Landroid_graphics_ColorFilter_ == null)
				{
					cb_setColorFilter_Landroid_graphics_ColorFilter_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetColorFilter_Landroid_graphics_ColorFilter_));
				}
				return cb_setColorFilter_Landroid_graphics_ColorFilter_;
			}

			private static void n_SetColorFilter_Landroid_graphics_ColorFilter_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_p0, JniHandleOwnership.DoNotTransfer);
				shadow.SetColorFilter(colorFilter);
			}

			[Register("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
			public unsafe override void SetColorFilter(ColorFilter p0)
			{
				if (id_setColorFilter_Landroid_graphics_ColorFilter_ == IntPtr.Zero)
				{
					id_setColorFilter_Landroid_graphics_ColorFilter_ = JNIEnv.GetMethodID(class_ref, "setColorFilter", "(Landroid/graphics/ColorFilter;)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorFilter_Landroid_graphics_ColorFilter_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorFilter", "(Landroid/graphics/ColorFilter;)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		[Register("SIZE_MINI")]
		public const int SizeMini = 1;

		[Register("SIZE_NORMAL")]
		public const int SizeNormal = 0;

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_II;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

		private static IntPtr id_ctor_Landroid_content_Context_;

		private static Delegate cb_getButtonSize;

		private static Delegate cb_setButtonSize_I;

		private static IntPtr id_getButtonSize;

		private static IntPtr id_setButtonSize_I;

		private static Delegate cb_getColorDisabled;

		private static Delegate cb_setColorDisabled_I;

		private static IntPtr id_getColorDisabled;

		private static IntPtr id_setColorDisabled_I;

		private static Delegate cb_getColorNormal;

		private static Delegate cb_setColorNormal_I;

		private static IntPtr id_getColorNormal;

		private static IntPtr id_setColorNormal_I;

		private static Delegate cb_getColorPressed;

		private static Delegate cb_setColorPressed_I;

		private static IntPtr id_getColorPressed;

		private static IntPtr id_setColorPressed_I;

		private static Delegate cb_getColorRipple;

		private static Delegate cb_setColorRipple_I;

		private static IntPtr id_getColorRipple;

		private static IntPtr id_setColorRipple_I;

		private static Delegate cb_hasShadow;

		private static IntPtr id_hasShadow;

		private static Delegate cb_getIconDrawable;

		private static IntPtr id_getIconDrawable;

		private static Delegate cb_isHidden;

		private static IntPtr id_isHidden;

		private static Delegate cb_isProgressBackgroundShown;

		private static IntPtr id_isProgressBackgroundShown;

		private static Delegate cb_getLabelText;

		private static Delegate cb_setLabelText_Ljava_lang_String_;

		private static IntPtr id_getLabelText;

		private static IntPtr id_setLabelText_Ljava_lang_String_;

		private static Delegate cb_getLabelVisibility;

		private static Delegate cb_setLabelVisibility_I;

		private static IntPtr id_getLabelVisibility;

		private static IntPtr id_setLabelVisibility_I;

		private static Delegate cb_getMax;

		private static Delegate cb_setMax_I;

		private static IntPtr id_getMax;

		private static IntPtr id_setMax_I;

		private static Delegate cb_getProgress;

		private static IntPtr id_getProgress;

		private static Delegate cb_getShadowColor;

		private static Delegate cb_setShadowColor_I;

		private static IntPtr id_getShadowColor;

		private static IntPtr id_setShadowColor_I;

		private static Delegate cb_getShadowRadius;

		private static Delegate cb_setShadowRadius_I;

		private static IntPtr id_getShadowRadius;

		private static IntPtr id_setShadowRadius_I;

		private static Delegate cb_getShadowXOffset;

		private static Delegate cb_setShadowXOffset_I;

		private static IntPtr id_getShadowXOffset;

		private static IntPtr id_setShadowXOffset_I;

		private static Delegate cb_getShadowYOffset;

		private static Delegate cb_setShadowYOffset_I;

		private static IntPtr id_getShadowYOffset;

		private static IntPtr id_setShadowYOffset_I;

		private static Delegate cb_hide_Z;

		private static IntPtr id_hide_Z;

		private static Delegate cb_hideButtonInMenu_Z;

		private static IntPtr id_hideButtonInMenu_Z;

		private static Delegate cb_hideProgress;

		private static IntPtr id_hideProgress;

		private static Delegate cb_onRestoreInstanceState_Landroid_os_Parcelable_;

		private static IntPtr id_onRestoreInstanceState_Landroid_os_Parcelable_;

		private static Delegate cb_onSaveInstanceState;

		private static IntPtr id_onSaveInstanceState;

		private static Delegate cb_setColorDisabledResId_I;

		private static IntPtr id_setColorDisabledResId_I;

		private static Delegate cb_setColorNormalResId_I;

		private static IntPtr id_setColorNormalResId_I;

		private static Delegate cb_setColorPressedResId_I;

		private static IntPtr id_setColorPressedResId_I;

		private static Delegate cb_setColorRippleResId_I;

		private static IntPtr id_setColorRippleResId_I;

		private static Delegate cb_setElevationCompat_F;

		private static IntPtr id_setElevationCompat_F;

		private static Delegate cb_setHideAnimation_Landroid_view_animation_Animation_;

		private static IntPtr id_setHideAnimation_Landroid_view_animation_Animation_;

		private static Delegate cb_setIndeterminate_Z;

		private static IntPtr id_setIndeterminate_Z;

		private static Delegate cb_setLabelColors_III;

		private static IntPtr id_setLabelColors_III;

		private static Delegate cb_setLabelTextColor_Landroid_content_res_ColorStateList_;

		private static IntPtr id_setLabelTextColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_setLabelTextColor_I;

		private static IntPtr id_setLabelTextColor_I;

		private static Delegate cb_setProgress_IZ;

		private static IntPtr id_setProgress_IZ;

		private static Delegate cb_setShadowColorResource_I;

		private static IntPtr id_setShadowColorResource_I;

		private static Delegate cb_setShadowRadius_F;

		private static IntPtr id_setShadowRadius_F;

		private static Delegate cb_setShadowXOffset_F;

		private static IntPtr id_setShadowXOffset_F;

		private static Delegate cb_setShadowYOffset_F;

		private static IntPtr id_setShadowYOffset_F;

		private static Delegate cb_setShowAnimation_Landroid_view_animation_Animation_;

		private static IntPtr id_setShowAnimation_Landroid_view_animation_Animation_;

		private static Delegate cb_setShowProgressBackground_Z;

		private static IntPtr id_setShowProgressBackground_Z;

		private static Delegate cb_setShowShadow_Z;

		private static IntPtr id_setShowShadow_Z;

		private static Delegate cb_show_Z;

		private static IntPtr id_show_Z;

		private static Delegate cb_showButtonInMenu_Z;

		private static IntPtr id_showButtonInMenu_Z;

		private static Delegate cb_toggle_Z;

		private static IntPtr id_toggle_Z;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/FloatingActionButton", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(FloatingActionButton);

		public unsafe virtual int ButtonSize
		{
			[Register("getButtonSize", "()I", "GetGetButtonSizeHandler")]
			get
			{
				if (id_getButtonSize == IntPtr.Zero)
				{
					id_getButtonSize = JNIEnv.GetMethodID(class_ref, "getButtonSize", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getButtonSize);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getButtonSize", "()I"));
				}
				finally
				{
				}
			}
			[Register("setButtonSize", "(I)V", "GetSetButtonSize_IHandler")]
			set
			{
				if (id_setButtonSize_I == IntPtr.Zero)
				{
					id_setButtonSize_I = JNIEnv.GetMethodID(class_ref, "setButtonSize", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setButtonSize_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setButtonSize", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ColorDisabled
		{
			[Register("getColorDisabled", "()I", "GetGetColorDisabledHandler")]
			get
			{
				if (id_getColorDisabled == IntPtr.Zero)
				{
					id_getColorDisabled = JNIEnv.GetMethodID(class_ref, "getColorDisabled", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getColorDisabled);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getColorDisabled", "()I"));
				}
				finally
				{
				}
			}
			[Register("setColorDisabled", "(I)V", "GetSetColorDisabled_IHandler")]
			set
			{
				if (id_setColorDisabled_I == IntPtr.Zero)
				{
					id_setColorDisabled_I = JNIEnv.GetMethodID(class_ref, "setColorDisabled", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorDisabled_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorDisabled", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ColorNormal
		{
			[Register("getColorNormal", "()I", "GetGetColorNormalHandler")]
			get
			{
				if (id_getColorNormal == IntPtr.Zero)
				{
					id_getColorNormal = JNIEnv.GetMethodID(class_ref, "getColorNormal", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getColorNormal);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getColorNormal", "()I"));
				}
				finally
				{
				}
			}
			[Register("setColorNormal", "(I)V", "GetSetColorNormal_IHandler")]
			set
			{
				if (id_setColorNormal_I == IntPtr.Zero)
				{
					id_setColorNormal_I = JNIEnv.GetMethodID(class_ref, "setColorNormal", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorNormal_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorNormal", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ColorPressed
		{
			[Register("getColorPressed", "()I", "GetGetColorPressedHandler")]
			get
			{
				if (id_getColorPressed == IntPtr.Zero)
				{
					id_getColorPressed = JNIEnv.GetMethodID(class_ref, "getColorPressed", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getColorPressed);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getColorPressed", "()I"));
				}
				finally
				{
				}
			}
			[Register("setColorPressed", "(I)V", "GetSetColorPressed_IHandler")]
			set
			{
				if (id_setColorPressed_I == IntPtr.Zero)
				{
					id_setColorPressed_I = JNIEnv.GetMethodID(class_ref, "setColorPressed", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorPressed_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorPressed", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ColorRipple
		{
			[Register("getColorRipple", "()I", "GetGetColorRippleHandler")]
			get
			{
				if (id_getColorRipple == IntPtr.Zero)
				{
					id_getColorRipple = JNIEnv.GetMethodID(class_ref, "getColorRipple", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getColorRipple);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getColorRipple", "()I"));
				}
				finally
				{
				}
			}
			[Register("setColorRipple", "(I)V", "GetSetColorRipple_IHandler")]
			set
			{
				if (id_setColorRipple_I == IntPtr.Zero)
				{
					id_setColorRipple_I = JNIEnv.GetMethodID(class_ref, "setColorRipple", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorRipple_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorRipple", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public virtual bool HasShadow
		{
			[Register("hasShadow", "()Z", "GetHasShadowHandler")]
			get
			{
				if (id_hasShadow == IntPtr.Zero)
				{
					id_hasShadow = JNIEnv.GetMethodID(class_ref, "hasShadow", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_hasShadow);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hasShadow", "()Z"));
				}
				finally
				{
				}
			}
		}

		protected virtual Drawable IconDrawable
		{
			[Register("getIconDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetIconDrawableHandler")]
			get
			{
				if (id_getIconDrawable == IntPtr.Zero)
				{
					id_getIconDrawable = JNIEnv.GetMethodID(class_ref, "getIconDrawable", "()Landroid/graphics/drawable/Drawable;");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return Java.Lang.Object.GetObject<Drawable>(JNIEnv.CallObjectMethod(base.Handle, id_getIconDrawable), JniHandleOwnership.TransferLocalRef);
					}
					return Java.Lang.Object.GetObject<Drawable>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getIconDrawable", "()Landroid/graphics/drawable/Drawable;")), JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
		}

		public virtual bool IsHidden
		{
			[Register("isHidden", "()Z", "GetIsHiddenHandler")]
			get
			{
				if (id_isHidden == IntPtr.Zero)
				{
					id_isHidden = JNIEnv.GetMethodID(class_ref, "isHidden", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isHidden);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isHidden", "()Z"));
				}
				finally
				{
				}
			}
		}

		public virtual bool IsProgressBackgroundShown
		{
			[Register("isProgressBackgroundShown", "()Z", "GetIsProgressBackgroundShownHandler")]
			get
			{
				if (id_isProgressBackgroundShown == IntPtr.Zero)
				{
					id_isProgressBackgroundShown = JNIEnv.GetMethodID(class_ref, "isProgressBackgroundShown", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isProgressBackgroundShown);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isProgressBackgroundShown", "()Z"));
				}
				finally
				{
				}
			}
		}

		public unsafe virtual string LabelText
		{
			[Register("getLabelText", "()Ljava/lang/String;", "GetGetLabelTextHandler")]
			get
			{
				if (id_getLabelText == IntPtr.Zero)
				{
					id_getLabelText = JNIEnv.GetMethodID(class_ref, "getLabelText", "()Ljava/lang/String;");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getLabelText), JniHandleOwnership.TransferLocalRef);
					}
					return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getLabelText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
			[Register("setLabelText", "(Ljava/lang/String;)V", "GetSetLabelText_Ljava_lang_String_Handler")]
			set
			{
				if (id_setLabelText_Ljava_lang_String_ == IntPtr.Zero)
				{
					id_setLabelText_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "setLabelText", "(Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(intPtr);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setLabelText_Ljava_lang_String_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLabelText", "(Ljava/lang/String;)V"), ptr);
					}
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual int LabelVisibility
		{
			[Register("getLabelVisibility", "()I", "GetGetLabelVisibilityHandler")]
			get
			{
				if (id_getLabelVisibility == IntPtr.Zero)
				{
					id_getLabelVisibility = JNIEnv.GetMethodID(class_ref, "getLabelVisibility", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getLabelVisibility);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getLabelVisibility", "()I"));
				}
				finally
				{
				}
			}
			[Register("setLabelVisibility", "(I)V", "GetSetLabelVisibility_IHandler")]
			set
			{
				if (id_setLabelVisibility_I == IntPtr.Zero)
				{
					id_setLabelVisibility_I = JNIEnv.GetMethodID(class_ref, "setLabelVisibility", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setLabelVisibility_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLabelVisibility", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int Max
		{
			[Register("getMax", "()I", "GetGetMaxHandler")]
			get
			{
				if (id_getMax == IntPtr.Zero)
				{
					id_getMax = JNIEnv.GetMethodID(class_ref, "getMax", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getMax);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMax", "()I"));
				}
				finally
				{
				}
			}
			[Register("setMax", "(I)V", "GetSetMax_IHandler")]
			set
			{
				if (id_setMax_I == IntPtr.Zero)
				{
					id_setMax_I = JNIEnv.GetMethodID(class_ref, "setMax", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setMax_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMax", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public virtual int Progress
		{
			[Register("getProgress", "()I", "GetGetProgressHandler")]
			get
			{
				if (id_getProgress == IntPtr.Zero)
				{
					id_getProgress = JNIEnv.GetMethodID(class_ref, "getProgress", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getProgress);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getProgress", "()I"));
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ShadowColor
		{
			[Register("getShadowColor", "()I", "GetGetShadowColorHandler")]
			get
			{
				if (id_getShadowColor == IntPtr.Zero)
				{
					id_getShadowColor = JNIEnv.GetMethodID(class_ref, "getShadowColor", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getShadowColor);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getShadowColor", "()I"));
				}
				finally
				{
				}
			}
			[Register("setShadowColor", "(I)V", "GetSetShadowColor_IHandler")]
			set
			{
				if (id_setShadowColor_I == IntPtr.Zero)
				{
					id_setShadowColor_I = JNIEnv.GetMethodID(class_ref, "setShadowColor", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setShadowColor_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowColor", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ShadowRadius
		{
			[Register("getShadowRadius", "()I", "GetGetShadowRadiusHandler")]
			get
			{
				if (id_getShadowRadius == IntPtr.Zero)
				{
					id_getShadowRadius = JNIEnv.GetMethodID(class_ref, "getShadowRadius", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getShadowRadius);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getShadowRadius", "()I"));
				}
				finally
				{
				}
			}
			[Register("setShadowRadius", "(I)V", "GetSetShadowRadius_IHandler")]
			set
			{
				if (id_setShadowRadius_I == IntPtr.Zero)
				{
					id_setShadowRadius_I = JNIEnv.GetMethodID(class_ref, "setShadowRadius", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setShadowRadius_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowRadius", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ShadowXOffset
		{
			[Register("getShadowXOffset", "()I", "GetGetShadowXOffsetHandler")]
			get
			{
				if (id_getShadowXOffset == IntPtr.Zero)
				{
					id_getShadowXOffset = JNIEnv.GetMethodID(class_ref, "getShadowXOffset", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getShadowXOffset);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getShadowXOffset", "()I"));
				}
				finally
				{
				}
			}
			[Register("setShadowXOffset", "(I)V", "GetSetShadowXOffset_IHandler")]
			set
			{
				if (id_setShadowXOffset_I == IntPtr.Zero)
				{
					id_setShadowXOffset_I = JNIEnv.GetMethodID(class_ref, "setShadowXOffset", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setShadowXOffset_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowXOffset", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int ShadowYOffset
		{
			[Register("getShadowYOffset", "()I", "GetGetShadowYOffsetHandler")]
			get
			{
				if (id_getShadowYOffset == IntPtr.Zero)
				{
					id_getShadowYOffset = JNIEnv.GetMethodID(class_ref, "getShadowYOffset", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getShadowYOffset);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getShadowYOffset", "()I"));
				}
				finally
				{
				}
			}
			[Register("setShadowYOffset", "(I)V", "GetSetShadowYOffset_IHandler")]
			set
			{
				if (id_setShadowYOffset_I == IntPtr.Zero)
				{
					id_setShadowYOffset_I = JNIEnv.GetMethodID(class_ref, "setShadowYOffset", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setShadowYOffset_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowYOffset", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		protected FloatingActionButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
		public unsafe FloatingActionButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[4];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(defStyleAttr);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 3) = new JValue(defStyleRes);
				if (GetType() != typeof(FloatingActionButton))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_II == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_II = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_II, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_II, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe FloatingActionButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(defStyleAttr);
				if (GetType() != typeof(FloatingActionButton))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe FloatingActionButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				if (GetType() != typeof(FloatingActionButton))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe FloatingActionButton(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(context);
				if (GetType() != typeof(FloatingActionButton))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_, ptr);
			}
			finally
			{
			}
		}

		private static Delegate GetGetButtonSizeHandler()
		{
			if ((object)cb_getButtonSize == null)
			{
				cb_getButtonSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetButtonSize));
			}
			return cb_getButtonSize;
		}

		private static int n_GetButtonSize(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ButtonSize;
		}

		private static Delegate GetSetButtonSize_IHandler()
		{
			if ((object)cb_setButtonSize_I == null)
			{
				cb_setButtonSize_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetButtonSize_I));
			}
			return cb_setButtonSize_I;
		}

		private static void n_SetButtonSize_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ButtonSize = p0;
		}

		private static Delegate GetGetColorDisabledHandler()
		{
			if ((object)cb_getColorDisabled == null)
			{
				cb_getColorDisabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetColorDisabled));
			}
			return cb_getColorDisabled;
		}

		private static int n_GetColorDisabled(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ColorDisabled;
		}

		private static Delegate GetSetColorDisabled_IHandler()
		{
			if ((object)cb_setColorDisabled_I == null)
			{
				cb_setColorDisabled_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorDisabled_I));
			}
			return cb_setColorDisabled_I;
		}

		private static void n_SetColorDisabled_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ColorDisabled = p0;
		}

		private static Delegate GetGetColorNormalHandler()
		{
			if ((object)cb_getColorNormal == null)
			{
				cb_getColorNormal = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetColorNormal));
			}
			return cb_getColorNormal;
		}

		private static int n_GetColorNormal(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ColorNormal;
		}

		private static Delegate GetSetColorNormal_IHandler()
		{
			if ((object)cb_setColorNormal_I == null)
			{
				cb_setColorNormal_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorNormal_I));
			}
			return cb_setColorNormal_I;
		}

		private static void n_SetColorNormal_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ColorNormal = p0;
		}

		private static Delegate GetGetColorPressedHandler()
		{
			if ((object)cb_getColorPressed == null)
			{
				cb_getColorPressed = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetColorPressed));
			}
			return cb_getColorPressed;
		}

		private static int n_GetColorPressed(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ColorPressed;
		}

		private static Delegate GetSetColorPressed_IHandler()
		{
			if ((object)cb_setColorPressed_I == null)
			{
				cb_setColorPressed_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorPressed_I));
			}
			return cb_setColorPressed_I;
		}

		private static void n_SetColorPressed_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ColorPressed = p0;
		}

		private static Delegate GetGetColorRippleHandler()
		{
			if ((object)cb_getColorRipple == null)
			{
				cb_getColorRipple = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetColorRipple));
			}
			return cb_getColorRipple;
		}

		private static int n_GetColorRipple(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ColorRipple;
		}

		private static Delegate GetSetColorRipple_IHandler()
		{
			if ((object)cb_setColorRipple_I == null)
			{
				cb_setColorRipple_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorRipple_I));
			}
			return cb_setColorRipple_I;
		}

		private static void n_SetColorRipple_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ColorRipple = p0;
		}

		private static Delegate GetHasShadowHandler()
		{
			if ((object)cb_hasShadow == null)
			{
				cb_hasShadow = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_HasShadow));
			}
			return cb_hasShadow;
		}

		private static bool n_HasShadow(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.HasShadow;
		}

		private static Delegate GetGetIconDrawableHandler()
		{
			if ((object)cb_getIconDrawable == null)
			{
				cb_getIconDrawable = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetIconDrawable));
			}
			return cb_getIconDrawable;
		}

		private static IntPtr n_GetIconDrawable(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(floatingActionButton.IconDrawable);
		}

		private static Delegate GetIsHiddenHandler()
		{
			if ((object)cb_isHidden == null)
			{
				cb_isHidden = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsHidden));
			}
			return cb_isHidden;
		}

		private static bool n_IsHidden(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.IsHidden;
		}

		private static Delegate GetIsProgressBackgroundShownHandler()
		{
			if ((object)cb_isProgressBackgroundShown == null)
			{
				cb_isProgressBackgroundShown = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsProgressBackgroundShown));
			}
			return cb_isProgressBackgroundShown;
		}

		private static bool n_IsProgressBackgroundShown(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.IsProgressBackgroundShown;
		}

		private static Delegate GetGetLabelTextHandler()
		{
			if ((object)cb_getLabelText == null)
			{
				cb_getLabelText = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetLabelText));
			}
			return cb_getLabelText;
		}

		private static IntPtr n_GetLabelText(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(floatingActionButton.LabelText);
		}

		private static Delegate GetSetLabelText_Ljava_lang_String_Handler()
		{
			if ((object)cb_setLabelText_Ljava_lang_String_ == null)
			{
				cb_setLabelText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetLabelText_Ljava_lang_String_));
			}
			return cb_setLabelText_Ljava_lang_String_;
		}

		private static void n_SetLabelText_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string labelText = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.LabelText = labelText;
		}

		private static Delegate GetGetLabelVisibilityHandler()
		{
			if ((object)cb_getLabelVisibility == null)
			{
				cb_getLabelVisibility = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetLabelVisibility));
			}
			return cb_getLabelVisibility;
		}

		private static int n_GetLabelVisibility(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.LabelVisibility;
		}

		private static Delegate GetSetLabelVisibility_IHandler()
		{
			if ((object)cb_setLabelVisibility_I == null)
			{
				cb_setLabelVisibility_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetLabelVisibility_I));
			}
			return cb_setLabelVisibility_I;
		}

		private static void n_SetLabelVisibility_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.LabelVisibility = p0;
		}

		private static Delegate GetGetMaxHandler()
		{
			if ((object)cb_getMax == null)
			{
				cb_getMax = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMax));
			}
			return cb_getMax;
		}

		private static int n_GetMax(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.Max;
		}

		private static Delegate GetSetMax_IHandler()
		{
			if ((object)cb_setMax_I == null)
			{
				cb_setMax_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMax_I));
			}
			return cb_setMax_I;
		}

		private static void n_SetMax_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Max = p0;
		}

		private static Delegate GetGetProgressHandler()
		{
			if ((object)cb_getProgress == null)
			{
				cb_getProgress = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetProgress));
			}
			return cb_getProgress;
		}

		private static int n_GetProgress(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.Progress;
		}

		private static Delegate GetGetShadowColorHandler()
		{
			if ((object)cb_getShadowColor == null)
			{
				cb_getShadowColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetShadowColor));
			}
			return cb_getShadowColor;
		}

		private static int n_GetShadowColor(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ShadowColor;
		}

		private static Delegate GetSetShadowColor_IHandler()
		{
			if ((object)cb_setShadowColor_I == null)
			{
				cb_setShadowColor_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShadowColor_I));
			}
			return cb_setShadowColor_I;
		}

		private static void n_SetShadowColor_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShadowColor = p0;
		}

		private static Delegate GetGetShadowRadiusHandler()
		{
			if ((object)cb_getShadowRadius == null)
			{
				cb_getShadowRadius = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetShadowRadius));
			}
			return cb_getShadowRadius;
		}

		private static int n_GetShadowRadius(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ShadowRadius;
		}

		private static Delegate GetSetShadowRadius_IHandler()
		{
			if ((object)cb_setShadowRadius_I == null)
			{
				cb_setShadowRadius_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShadowRadius_I));
			}
			return cb_setShadowRadius_I;
		}

		private static void n_SetShadowRadius_I(IntPtr jnienv, IntPtr native__this, int dimenResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShadowRadius = dimenResId;
		}

		private static Delegate GetGetShadowXOffsetHandler()
		{
			if ((object)cb_getShadowXOffset == null)
			{
				cb_getShadowXOffset = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetShadowXOffset));
			}
			return cb_getShadowXOffset;
		}

		private static int n_GetShadowXOffset(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ShadowXOffset;
		}

		private static Delegate GetSetShadowXOffset_IHandler()
		{
			if ((object)cb_setShadowXOffset_I == null)
			{
				cb_setShadowXOffset_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShadowXOffset_I));
			}
			return cb_setShadowXOffset_I;
		}

		private static void n_SetShadowXOffset_I(IntPtr jnienv, IntPtr native__this, int dimenResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShadowXOffset = dimenResId;
		}

		private static Delegate GetGetShadowYOffsetHandler()
		{
			if ((object)cb_getShadowYOffset == null)
			{
				cb_getShadowYOffset = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetShadowYOffset));
			}
			return cb_getShadowYOffset;
		}

		private static int n_GetShadowYOffset(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.ShadowYOffset;
		}

		private static Delegate GetSetShadowYOffset_IHandler()
		{
			if ((object)cb_setShadowYOffset_I == null)
			{
				cb_setShadowYOffset_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShadowYOffset_I));
			}
			return cb_setShadowYOffset_I;
		}

		private static void n_SetShadowYOffset_I(IntPtr jnienv, IntPtr native__this, int dimenResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShadowYOffset = dimenResId;
		}

		private static Delegate GetHide_ZHandler()
		{
			if ((object)cb_hide_Z == null)
			{
				cb_hide_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Hide_Z));
			}
			return cb_hide_Z;
		}

		private static void n_Hide_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Hide(animate);
		}

		[Register("hide", "(Z)V", "GetHide_ZHandler")]
		public unsafe virtual void Hide(bool animate)
		{
			if (id_hide_Z == IntPtr.Zero)
			{
				id_hide_Z = JNIEnv.GetMethodID(class_ref, "hide", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_hide_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hide", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetHideButtonInMenu_ZHandler()
		{
			if ((object)cb_hideButtonInMenu_Z == null)
			{
				cb_hideButtonInMenu_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_HideButtonInMenu_Z));
			}
			return cb_hideButtonInMenu_Z;
		}

		private static void n_HideButtonInMenu_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.HideButtonInMenu(animate);
		}

		[Register("hideButtonInMenu", "(Z)V", "GetHideButtonInMenu_ZHandler")]
		public unsafe virtual void HideButtonInMenu(bool animate)
		{
			if (id_hideButtonInMenu_Z == IntPtr.Zero)
			{
				id_hideButtonInMenu_Z = JNIEnv.GetMethodID(class_ref, "hideButtonInMenu", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_hideButtonInMenu_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hideButtonInMenu", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetHideProgressHandler()
		{
			if ((object)cb_hideProgress == null)
			{
				cb_hideProgress = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_HideProgress));
			}
			return cb_hideProgress;
		}

		private static void n_HideProgress(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.HideProgress();
		}

		[Register("hideProgress", "()V", "GetHideProgressHandler")]
		public virtual void HideProgress()
		{
			if (id_hideProgress == IntPtr.Zero)
			{
				id_hideProgress = JNIEnv.GetMethodID(class_ref, "hideProgress", "()V");
			}
			try
			{
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_hideProgress);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hideProgress", "()V"));
				}
			}
			finally
			{
			}
		}

		private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
		{
			if ((object)cb_onRestoreInstanceState_Landroid_os_Parcelable_ == null)
			{
				cb_onRestoreInstanceState_Landroid_os_Parcelable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnRestoreInstanceState_Landroid_os_Parcelable_));
			}
			return cb_onRestoreInstanceState_Landroid_os_Parcelable_;
		}

		private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.OnRestoreInstanceState(state);
		}

		[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
		protected unsafe override void OnRestoreInstanceState(IParcelable state)
		{
			if (id_onRestoreInstanceState_Landroid_os_Parcelable_ == IntPtr.Zero)
			{
				id_onRestoreInstanceState_Landroid_os_Parcelable_ = JNIEnv.GetMethodID(class_ref, "onRestoreInstanceState", "(Landroid/os/Parcelable;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(state);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_onRestoreInstanceState_Landroid_os_Parcelable_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onRestoreInstanceState", "(Landroid/os/Parcelable;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetOnSaveInstanceStateHandler()
		{
			if ((object)cb_onSaveInstanceState == null)
			{
				cb_onSaveInstanceState = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_OnSaveInstanceState));
			}
			return cb_onSaveInstanceState;
		}

		private static IntPtr n_OnSaveInstanceState(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(floatingActionButton.OnSaveInstanceState());
		}

		[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
		protected override IParcelable OnSaveInstanceState()
		{
			if (id_onSaveInstanceState == IntPtr.Zero)
			{
				id_onSaveInstanceState = JNIEnv.GetMethodID(class_ref, "onSaveInstanceState", "()Landroid/os/Parcelable;");
			}
			try
			{
				if (GetType() == ThresholdType)
				{
					return Java.Lang.Object.GetObject<IParcelable>(JNIEnv.CallObjectMethod(base.Handle, id_onSaveInstanceState), JniHandleOwnership.TransferLocalRef);
				}
				return Java.Lang.Object.GetObject<IParcelable>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onSaveInstanceState", "()Landroid/os/Parcelable;")), JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}

		private static Delegate GetSetColorDisabledResId_IHandler()
		{
			if ((object)cb_setColorDisabledResId_I == null)
			{
				cb_setColorDisabledResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorDisabledResId_I));
			}
			return cb_setColorDisabledResId_I;
		}

		private static void n_SetColorDisabledResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetColorDisabledResId(colorResId);
		}

		[Register("setColorDisabledResId", "(I)V", "GetSetColorDisabledResId_IHandler")]
		public unsafe virtual void SetColorDisabledResId(int colorResId)
		{
			if (id_setColorDisabledResId_I == IntPtr.Zero)
			{
				id_setColorDisabledResId_I = JNIEnv.GetMethodID(class_ref, "setColorDisabledResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setColorDisabledResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorDisabledResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetColorNormalResId_IHandler()
		{
			if ((object)cb_setColorNormalResId_I == null)
			{
				cb_setColorNormalResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorNormalResId_I));
			}
			return cb_setColorNormalResId_I;
		}

		private static void n_SetColorNormalResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetColorNormalResId(colorResId);
		}

		[Register("setColorNormalResId", "(I)V", "GetSetColorNormalResId_IHandler")]
		public unsafe virtual void SetColorNormalResId(int colorResId)
		{
			if (id_setColorNormalResId_I == IntPtr.Zero)
			{
				id_setColorNormalResId_I = JNIEnv.GetMethodID(class_ref, "setColorNormalResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setColorNormalResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorNormalResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetColorPressedResId_IHandler()
		{
			if ((object)cb_setColorPressedResId_I == null)
			{
				cb_setColorPressedResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorPressedResId_I));
			}
			return cb_setColorPressedResId_I;
		}

		private static void n_SetColorPressedResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetColorPressedResId(colorResId);
		}

		[Register("setColorPressedResId", "(I)V", "GetSetColorPressedResId_IHandler")]
		public unsafe virtual void SetColorPressedResId(int colorResId)
		{
			if (id_setColorPressedResId_I == IntPtr.Zero)
			{
				id_setColorPressedResId_I = JNIEnv.GetMethodID(class_ref, "setColorPressedResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setColorPressedResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorPressedResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetColorRippleResId_IHandler()
		{
			if ((object)cb_setColorRippleResId_I == null)
			{
				cb_setColorRippleResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetColorRippleResId_I));
			}
			return cb_setColorRippleResId_I;
		}

		private static void n_SetColorRippleResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetColorRippleResId(colorResId);
		}

		[Register("setColorRippleResId", "(I)V", "GetSetColorRippleResId_IHandler")]
		public unsafe virtual void SetColorRippleResId(int colorResId)
		{
			if (id_setColorRippleResId_I == IntPtr.Zero)
			{
				id_setColorRippleResId_I = JNIEnv.GetMethodID(class_ref, "setColorRippleResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setColorRippleResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorRippleResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetElevationCompat_FHandler()
		{
			if ((object)cb_setElevationCompat_F == null)
			{
				cb_setElevationCompat_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetElevationCompat_F));
			}
			return cb_setElevationCompat_F;
		}

		private static void n_SetElevationCompat_F(IntPtr jnienv, IntPtr native__this, float elevation)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetElevationCompat(elevation);
		}

		[Register("setElevationCompat", "(F)V", "GetSetElevationCompat_FHandler")]
		public unsafe virtual void SetElevationCompat(float elevation)
		{
			if (id_setElevationCompat_F == IntPtr.Zero)
			{
				id_setElevationCompat_F = JNIEnv.GetMethodID(class_ref, "setElevationCompat", "(F)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(elevation);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setElevationCompat_F, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setElevationCompat", "(F)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetHideAnimation_Landroid_view_animation_Animation_Handler()
		{
			if ((object)cb_setHideAnimation_Landroid_view_animation_Animation_ == null)
			{
				cb_setHideAnimation_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetHideAnimation_Landroid_view_animation_Animation_));
			}
			return cb_setHideAnimation_Landroid_view_animation_Animation_;
		}

		private static void n_SetHideAnimation_Landroid_view_animation_Animation_(IntPtr jnienv, IntPtr native__this, IntPtr native_hideAnimation)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animation hideAnimation = Java.Lang.Object.GetObject<Animation>(native_hideAnimation, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetHideAnimation(hideAnimation);
		}

		[Register("setHideAnimation", "(Landroid/view/animation/Animation;)V", "GetSetHideAnimation_Landroid_view_animation_Animation_Handler")]
		public unsafe virtual void SetHideAnimation(Animation hideAnimation)
		{
			if (id_setHideAnimation_Landroid_view_animation_Animation_ == IntPtr.Zero)
			{
				id_setHideAnimation_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID(class_ref, "setHideAnimation", "(Landroid/view/animation/Animation;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(hideAnimation);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setHideAnimation_Landroid_view_animation_Animation_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setHideAnimation", "(Landroid/view/animation/Animation;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetIndeterminate_ZHandler()
		{
			if ((object)cb_setIndeterminate_Z == null)
			{
				cb_setIndeterminate_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetIndeterminate_Z));
			}
			return cb_setIndeterminate_Z;
		}

		private static void n_SetIndeterminate_Z(IntPtr jnienv, IntPtr native__this, bool indeterminate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetIndeterminate(indeterminate);
		}

		[Register("setIndeterminate", "(Z)V", "GetSetIndeterminate_ZHandler")]
		public unsafe virtual void SetIndeterminate(bool indeterminate)
		{
			if (id_setIndeterminate_Z == IntPtr.Zero)
			{
				id_setIndeterminate_Z = JNIEnv.GetMethodID(class_ref, "setIndeterminate", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(indeterminate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setIndeterminate_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIndeterminate", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetLabelColors_IIIHandler()
		{
			if ((object)cb_setLabelColors_III == null)
			{
				cb_setLabelColors_III = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int, int>(n_SetLabelColors_III));
			}
			return cb_setLabelColors_III;
		}

		private static void n_SetLabelColors_III(IntPtr jnienv, IntPtr native__this, int colorNormal, int colorPressed, int colorRipple)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetLabelColors(colorNormal, colorPressed, colorRipple);
		}

		[Register("setLabelColors", "(III)V", "GetSetLabelColors_IIIHandler")]
		public unsafe virtual void SetLabelColors(int colorNormal, int colorPressed, int colorRipple)
		{
			if (id_setLabelColors_III == IntPtr.Zero)
			{
				id_setLabelColors_III = JNIEnv.GetMethodID(class_ref, "setLabelColors", "(III)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(colorNormal);
				ptr[1] = new JValue(colorPressed);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(colorRipple);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setLabelColors_III, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLabelColors", "(III)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetLabelTextColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setLabelTextColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setLabelTextColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetLabelTextColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setLabelTextColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetLabelTextColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_colors)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList labelTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_colors, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetLabelTextColor(labelTextColor);
		}

		[Register("setLabelTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetLabelTextColor_Landroid_content_res_ColorStateList_Handler")]
		public unsafe virtual void SetLabelTextColor(ColorStateList colors)
		{
			if (id_setLabelTextColor_Landroid_content_res_ColorStateList_ == IntPtr.Zero)
			{
				id_setLabelTextColor_Landroid_content_res_ColorStateList_ = JNIEnv.GetMethodID(class_ref, "setLabelTextColor", "(Landroid/content/res/ColorStateList;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colors);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setLabelTextColor_Landroid_content_res_ColorStateList_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLabelTextColor", "(Landroid/content/res/ColorStateList;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetLabelTextColor_IHandler()
		{
			if ((object)cb_setLabelTextColor_I == null)
			{
				cb_setLabelTextColor_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetLabelTextColor_I));
			}
			return cb_setLabelTextColor_I;
		}

		private static void n_SetLabelTextColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetLabelTextColor(color);
		}

		[Register("setLabelTextColor", "(I)V", "GetSetLabelTextColor_IHandler")]
		public unsafe virtual void SetLabelTextColor(int color)
		{
			if (id_setLabelTextColor_I == IntPtr.Zero)
			{
				id_setLabelTextColor_I = JNIEnv.GetMethodID(class_ref, "setLabelTextColor", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(color);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setLabelTextColor_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLabelTextColor", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetProgress_IZHandler()
		{
			if ((object)cb_setProgress_IZ == null)
			{
				cb_setProgress_IZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, bool>(n_SetProgress_IZ));
			}
			return cb_setProgress_IZ;
		}

		private static void n_SetProgress_IZ(IntPtr jnienv, IntPtr native__this, int progress, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetProgress(progress, animate);
		}

		[Register("setProgress", "(IZ)V", "GetSetProgress_IZHandler")]
		public unsafe virtual void SetProgress(int progress, bool animate)
		{
			if (id_setProgress_IZ == IntPtr.Zero)
			{
				id_setProgress_IZ = JNIEnv.GetMethodID(class_ref, "setProgress", "(IZ)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(progress);
				ptr[1] = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setProgress_IZ, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setProgress", "(IZ)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShadowColorResource_IHandler()
		{
			if ((object)cb_setShadowColorResource_I == null)
			{
				cb_setShadowColorResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShadowColorResource_I));
			}
			return cb_setShadowColorResource_I;
		}

		private static void n_SetShadowColorResource_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShadowColorResource(p0);
		}

		[Register("setShadowColorResource", "(I)V", "GetSetShadowColorResource_IHandler")]
		public unsafe virtual void SetShadowColorResource(int p0)
		{
			if (id_setShadowColorResource_I == IntPtr.Zero)
			{
				id_setShadowColorResource_I = JNIEnv.GetMethodID(class_ref, "setShadowColorResource", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShadowColorResource_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowColorResource", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShadowRadius_FHandler()
		{
			if ((object)cb_setShadowRadius_F == null)
			{
				cb_setShadowRadius_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetShadowRadius_F));
			}
			return cb_setShadowRadius_F;
		}

		private static void n_SetShadowRadius_F(IntPtr jnienv, IntPtr native__this, float shadowRadiusDp)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShadowRadius(shadowRadiusDp);
		}

		[Register("setShadowRadius", "(F)V", "GetSetShadowRadius_FHandler")]
		public unsafe virtual void SetShadowRadius(float shadowRadiusDp)
		{
			if (id_setShadowRadius_F == IntPtr.Zero)
			{
				id_setShadowRadius_F = JNIEnv.GetMethodID(class_ref, "setShadowRadius", "(F)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(shadowRadiusDp);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShadowRadius_F, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowRadius", "(F)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShadowXOffset_FHandler()
		{
			if ((object)cb_setShadowXOffset_F == null)
			{
				cb_setShadowXOffset_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetShadowXOffset_F));
			}
			return cb_setShadowXOffset_F;
		}

		private static void n_SetShadowXOffset_F(IntPtr jnienv, IntPtr native__this, float shadowXOffsetDp)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShadowXOffset(shadowXOffsetDp);
		}

		[Register("setShadowXOffset", "(F)V", "GetSetShadowXOffset_FHandler")]
		public unsafe virtual void SetShadowXOffset(float shadowXOffsetDp)
		{
			if (id_setShadowXOffset_F == IntPtr.Zero)
			{
				id_setShadowXOffset_F = JNIEnv.GetMethodID(class_ref, "setShadowXOffset", "(F)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(shadowXOffsetDp);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShadowXOffset_F, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowXOffset", "(F)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShadowYOffset_FHandler()
		{
			if ((object)cb_setShadowYOffset_F == null)
			{
				cb_setShadowYOffset_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetShadowYOffset_F));
			}
			return cb_setShadowYOffset_F;
		}

		private static void n_SetShadowYOffset_F(IntPtr jnienv, IntPtr native__this, float shadowYOffsetDp)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShadowYOffset(shadowYOffsetDp);
		}

		[Register("setShadowYOffset", "(F)V", "GetSetShadowYOffset_FHandler")]
		public unsafe virtual void SetShadowYOffset(float shadowYOffsetDp)
		{
			if (id_setShadowYOffset_F == IntPtr.Zero)
			{
				id_setShadowYOffset_F = JNIEnv.GetMethodID(class_ref, "setShadowYOffset", "(F)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(shadowYOffsetDp);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShadowYOffset_F, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShadowYOffset", "(F)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShowAnimation_Landroid_view_animation_Animation_Handler()
		{
			if ((object)cb_setShowAnimation_Landroid_view_animation_Animation_ == null)
			{
				cb_setShowAnimation_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetShowAnimation_Landroid_view_animation_Animation_));
			}
			return cb_setShowAnimation_Landroid_view_animation_Animation_;
		}

		private static void n_SetShowAnimation_Landroid_view_animation_Animation_(IntPtr jnienv, IntPtr native__this, IntPtr native_showAnimation)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animation showAnimation = Java.Lang.Object.GetObject<Animation>(native_showAnimation, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShowAnimation(showAnimation);
		}

		[Register("setShowAnimation", "(Landroid/view/animation/Animation;)V", "GetSetShowAnimation_Landroid_view_animation_Animation_Handler")]
		public unsafe virtual void SetShowAnimation(Animation showAnimation)
		{
			if (id_setShowAnimation_Landroid_view_animation_Animation_ == IntPtr.Zero)
			{
				id_setShowAnimation_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID(class_ref, "setShowAnimation", "(Landroid/view/animation/Animation;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(showAnimation);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShowAnimation_Landroid_view_animation_Animation_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShowAnimation", "(Landroid/view/animation/Animation;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShowProgressBackground_ZHandler()
		{
			if ((object)cb_setShowProgressBackground_Z == null)
			{
				cb_setShowProgressBackground_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetShowProgressBackground_Z));
			}
			return cb_setShowProgressBackground_Z;
		}

		private static void n_SetShowProgressBackground_Z(IntPtr jnienv, IntPtr native__this, bool show)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShowProgressBackground(show);
		}

		[Register("setShowProgressBackground", "(Z)V", "GetSetShowProgressBackground_ZHandler")]
		public unsafe virtual void SetShowProgressBackground(bool show)
		{
			if (id_setShowProgressBackground_Z == IntPtr.Zero)
			{
				id_setShowProgressBackground_Z = JNIEnv.GetMethodID(class_ref, "setShowProgressBackground", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(show);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShowProgressBackground_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShowProgressBackground", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetShowShadow_ZHandler()
		{
			if ((object)cb_setShowShadow_Z == null)
			{
				cb_setShowShadow_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetShowShadow_Z));
			}
			return cb_setShowShadow_Z;
		}

		private static void n_SetShowShadow_Z(IntPtr jnienv, IntPtr native__this, bool show)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetShowShadow(show);
		}

		[Register("setShowShadow", "(Z)V", "GetSetShowShadow_ZHandler")]
		public unsafe virtual void SetShowShadow(bool show)
		{
			if (id_setShowShadow_Z == IntPtr.Zero)
			{
				id_setShowShadow_Z = JNIEnv.GetMethodID(class_ref, "setShowShadow", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(show);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setShowShadow_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setShowShadow", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetShow_ZHandler()
		{
			if ((object)cb_show_Z == null)
			{
				cb_show_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Show_Z));
			}
			return cb_show_Z;
		}

		private static void n_Show_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Show(animate);
		}

		[Register("show", "(Z)V", "GetShow_ZHandler")]
		public unsafe virtual void Show(bool animate)
		{
			if (id_show_Z == IntPtr.Zero)
			{
				id_show_Z = JNIEnv.GetMethodID(class_ref, "show", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_show_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "show", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetShowButtonInMenu_ZHandler()
		{
			if ((object)cb_showButtonInMenu_Z == null)
			{
				cb_showButtonInMenu_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_ShowButtonInMenu_Z));
			}
			return cb_showButtonInMenu_Z;
		}

		private static void n_ShowButtonInMenu_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShowButtonInMenu(animate);
		}

		[Register("showButtonInMenu", "(Z)V", "GetShowButtonInMenu_ZHandler")]
		public unsafe virtual void ShowButtonInMenu(bool animate)
		{
			if (id_showButtonInMenu_Z == IntPtr.Zero)
			{
				id_showButtonInMenu_Z = JNIEnv.GetMethodID(class_ref, "showButtonInMenu", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_showButtonInMenu_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "showButtonInMenu", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetToggle_ZHandler()
		{
			if ((object)cb_toggle_Z == null)
			{
				cb_toggle_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Toggle_Z));
			}
			return cb_toggle_Z;
		}

		private static void n_Toggle_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Toggle(animate);
		}

		[Register("toggle", "(Z)V", "GetToggle_ZHandler")]
		public unsafe virtual void Toggle(bool animate)
		{
			if (id_toggle_Z == IntPtr.Zero)
			{
				id_toggle_Z = JNIEnv.GetMethodID(class_ref, "toggle", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_toggle_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "toggle", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}
	}
	[Register("com/github/clans/fab/FloatingActionMenu", DoNotGenerateAcw = true)]
	public class FloatingActionMenu : ViewGroup
	{
		[Register("com/github/clans/fab/FloatingActionMenu$OnMenuToggleListener", "", "Clans.Fab.FloatingActionMenu/IOnMenuToggleListenerInvoker")]
		public interface IOnMenuToggleListener : IJavaObject, IDisposable
		{
			[Register("onMenuToggle", "(Z)V", "GetOnMenuToggle_ZHandler:Clans.Fab.FloatingActionMenu/IOnMenuToggleListenerInvoker, FloatingActionButton-Xamarin")]
			void OnMenuToggle(bool opened);
		}

		[Register("com/github/clans/fab/FloatingActionMenu$OnMenuToggleListener", DoNotGenerateAcw = true)]
		internal class IOnMenuToggleListenerInvoker : Java.Lang.Object, IOnMenuToggleListener, IJavaObject, IDisposable
		{
			private static IntPtr java_class_ref = JNIEnv.FindClass("com/github/clans/fab/FloatingActionMenu$OnMenuToggleListener");

			private IntPtr class_ref;

			private static Delegate cb_onMenuToggle_Z;

			private IntPtr id_onMenuToggle_Z;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(IOnMenuToggleListenerInvoker);

			public IOnMenuToggleListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			public static IOnMenuToggleListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnMenuToggleListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.clans.fab.FloatingActionMenu.OnMenuToggleListener"));
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			private static Delegate GetOnMenuToggle_ZHandler()
			{
				if ((object)cb_onMenuToggle_Z == null)
				{
					cb_onMenuToggle_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_OnMenuToggle_Z));
				}
				return cb_onMenuToggle_Z;
			}

			private static void n_OnMenuToggle_Z(IntPtr jnienv, IntPtr native__this, bool opened)
			{
				IOnMenuToggleListener onMenuToggleListener = Java.Lang.Object.GetObject<IOnMenuToggleListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				onMenuToggleListener.OnMenuToggle(opened);
			}

			public unsafe void OnMenuToggle(bool opened)
			{
				if (id_onMenuToggle_Z == IntPtr.Zero)
				{
					id_onMenuToggle_Z = JNIEnv.GetMethodID(class_ref, "onMenuToggle", "(Z)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(opened);
				JNIEnv.CallVoidMethod(base.Handle, id_onMenuToggle_Z, ptr);
			}
		}

		public class MenuToggleEventArgs : EventArgs
		{
			private bool opened;

			public bool Opened => opened;

			public MenuToggleEventArgs(bool opened)
			{
				this.opened = opened;
			}
		}

		[Register("mono/com/github/clans/fab/FloatingActionMenu_OnMenuToggleListenerImplementor")]
		internal sealed class IOnMenuToggleListenerImplementor : Java.Lang.Object, IOnMenuToggleListener, IJavaObject, IDisposable
		{
			private object sender;

			public EventHandler<MenuToggleEventArgs> Handler;

			public IOnMenuToggleListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/github/clans/fab/FloatingActionMenu_OnMenuToggleListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnMenuToggle(bool opened)
			{
				Handler?.Invoke(sender, new MenuToggleEventArgs(opened));
			}

			internal static bool __IsEmpty(IOnMenuToggleListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

		private static IntPtr id_ctor_Landroid_content_Context_;

		private static Delegate cb_isAnimated;

		private static Delegate cb_setAnimated_Z;

		private static IntPtr id_isAnimated;

		private static IntPtr id_setAnimated_Z;

		private static Delegate cb_getAnimationDelayPerItem;

		private static Delegate cb_setAnimationDelayPerItem_I;

		private static IntPtr id_getAnimationDelayPerItem;

		private static IntPtr id_setAnimationDelayPerItem_I;

		private static Delegate cb_isIconAnimated;

		private static Delegate cb_setIconAnimated_Z;

		private static IntPtr id_isIconAnimated;

		private static IntPtr id_setIconAnimated_Z;

		private static Delegate cb_getIconToggleAnimatorSet;

		private static Delegate cb_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_;

		private static IntPtr id_getIconToggleAnimatorSet;

		private static IntPtr id_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_;

		private static Delegate cb_isMenuButtonHidden;

		private static IntPtr id_isMenuButtonHidden;

		private static Delegate cb_isMenuHidden;

		private static IntPtr id_isMenuHidden;

		private static Delegate cb_isOpened;

		private static IntPtr id_isOpened;

		private static Delegate cb_getMenuButtonColorNormal;

		private static Delegate cb_setMenuButtonColorNormal_I;

		private static IntPtr id_getMenuButtonColorNormal;

		private static IntPtr id_setMenuButtonColorNormal_I;

		private static Delegate cb_getMenuButtonColorPressed;

		private static Delegate cb_setMenuButtonColorPressed_I;

		private static IntPtr id_getMenuButtonColorPressed;

		private static IntPtr id_setMenuButtonColorPressed_I;

		private static Delegate cb_getMenuButtonColorRipple;

		private static Delegate cb_setMenuButtonColorRipple_I;

		private static IntPtr id_getMenuButtonColorRipple;

		private static IntPtr id_setMenuButtonColorRipple_I;

		private static Delegate cb_getMenuButtonLabelText;

		private static Delegate cb_setMenuButtonLabelText_Ljava_lang_String_;

		private static IntPtr id_getMenuButtonLabelText;

		private static IntPtr id_setMenuButtonLabelText_Ljava_lang_String_;

		private static Delegate cb_getMenuIconView;

		private static IntPtr id_getMenuIconView;

		private static Delegate cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_;

		private static IntPtr id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_;

		private static Delegate cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I;

		private static IntPtr id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I;

		private static Delegate cb_close_Z;

		private static IntPtr id_close_Z;

		private static Delegate cb_hideMenu_Z;

		private static IntPtr id_hideMenu_Z;

		private static Delegate cb_hideMenuButton_Z;

		private static IntPtr id_hideMenuButton_Z;

		private static Delegate cb_onLayout_ZIIII;

		private static IntPtr id_onLayout_ZIIII;

		private static Delegate cb_open_Z;

		private static IntPtr id_open_Z;

		private static Delegate cb_removeAllMenuButtons;

		private static IntPtr id_removeAllMenuButtons;

		private static Delegate cb_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_;

		private static IntPtr id_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_;

		private static Delegate cb_setClosedOnTouchOutside_Z;

		private static IntPtr id_setClosedOnTouchOutside_Z;

		private static Delegate cb_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_;

		private static IntPtr id_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_;

		private static Delegate cb_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_;

		private static IntPtr id_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_;

		private static Delegate cb_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_;

		private static IntPtr id_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_;

		private static Delegate cb_setMenuButtonColorNormalResId_I;

		private static IntPtr id_setMenuButtonColorNormalResId_I;

		private static Delegate cb_setMenuButtonColorPressedResId_I;

		private static IntPtr id_setMenuButtonColorPressedResId_I;

		private static Delegate cb_setMenuButtonColorRippleResId_I;

		private static IntPtr id_setMenuButtonColorRippleResId_I;

		private static Delegate cb_setMenuButtonHideAnimation_Landroid_view_animation_Animation_;

		private static IntPtr id_setMenuButtonHideAnimation_Landroid_view_animation_Animation_;

		private static Delegate cb_setMenuButtonShowAnimation_Landroid_view_animation_Animation_;

		private static IntPtr id_setMenuButtonShowAnimation_Landroid_view_animation_Animation_;

		private static Delegate cb_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_;

		private static IntPtr id_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_;

		private static Delegate cb_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_;

		private static IntPtr id_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_;

		private static Delegate cb_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_;

		private static IntPtr id_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_;

		private static Delegate cb_showMenu_Z;

		private static IntPtr id_showMenu_Z;

		private static Delegate cb_showMenuButton_Z;

		private static IntPtr id_showMenuButton_Z;

		private static Delegate cb_toggle_Z;

		private static IntPtr id_toggle_Z;

		private static Delegate cb_toggleMenu_Z;

		private static IntPtr id_toggleMenu_Z;

		private static Delegate cb_toggleMenuButton_Z;

		private static IntPtr id_toggleMenuButton_Z;

		private WeakReference weak_implementor_SetOnMenuToggleListener;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/FloatingActionMenu", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(FloatingActionMenu);

		public unsafe virtual bool Animated
		{
			[Register("isAnimated", "()Z", "GetIsAnimatedHandler")]
			get
			{
				if (id_isAnimated == IntPtr.Zero)
				{
					id_isAnimated = JNIEnv.GetMethodID(class_ref, "isAnimated", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isAnimated);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isAnimated", "()Z"));
				}
				finally
				{
				}
			}
			[Register("setAnimated", "(Z)V", "GetSetAnimated_ZHandler")]
			set
			{
				if (id_setAnimated_Z == IntPtr.Zero)
				{
					id_setAnimated_Z = JNIEnv.GetMethodID(class_ref, "setAnimated", "(Z)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setAnimated_Z, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAnimated", "(Z)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int AnimationDelayPerItem
		{
			[Register("getAnimationDelayPerItem", "()I", "GetGetAnimationDelayPerItemHandler")]
			get
			{
				if (id_getAnimationDelayPerItem == IntPtr.Zero)
				{
					id_getAnimationDelayPerItem = JNIEnv.GetMethodID(class_ref, "getAnimationDelayPerItem", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getAnimationDelayPerItem);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getAnimationDelayPerItem", "()I"));
				}
				finally
				{
				}
			}
			[Register("setAnimationDelayPerItem", "(I)V", "GetSetAnimationDelayPerItem_IHandler")]
			set
			{
				if (id_setAnimationDelayPerItem_I == IntPtr.Zero)
				{
					id_setAnimationDelayPerItem_I = JNIEnv.GetMethodID(class_ref, "setAnimationDelayPerItem", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setAnimationDelayPerItem_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAnimationDelayPerItem", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual bool IconAnimated
		{
			[Register("isIconAnimated", "()Z", "GetIsIconAnimatedHandler")]
			get
			{
				if (id_isIconAnimated == IntPtr.Zero)
				{
					id_isIconAnimated = JNIEnv.GetMethodID(class_ref, "isIconAnimated", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isIconAnimated);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isIconAnimated", "()Z"));
				}
				finally
				{
				}
			}
			[Register("setIconAnimated", "(Z)V", "GetSetIconAnimated_ZHandler")]
			set
			{
				if (id_setIconAnimated_Z == IntPtr.Zero)
				{
					id_setIconAnimated_Z = JNIEnv.GetMethodID(class_ref, "setIconAnimated", "(Z)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setIconAnimated_Z, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIconAnimated", "(Z)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual AnimatorSet IconToggleAnimatorSet
		{
			[Register("getIconToggleAnimatorSet", "()Landroid/animation/AnimatorSet;", "GetGetIconToggleAnimatorSetHandler")]
			get
			{
				if (id_getIconToggleAnimatorSet == IntPtr.Zero)
				{
					id_getIconToggleAnimatorSet = JNIEnv.GetMethodID(class_ref, "getIconToggleAnimatorSet", "()Landroid/animation/AnimatorSet;");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return Java.Lang.Object.GetObject<AnimatorSet>(JNIEnv.CallObjectMethod(base.Handle, id_getIconToggleAnimatorSet), JniHandleOwnership.TransferLocalRef);
					}
					return Java.Lang.Object.GetObject<AnimatorSet>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getIconToggleAnimatorSet", "()Landroid/animation/AnimatorSet;")), JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
			[Register("setIconToggleAnimatorSet", "(Landroid/animation/AnimatorSet;)V", "GetSetIconToggleAnimatorSet_Landroid_animation_AnimatorSet_Handler")]
			set
			{
				if (id_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_ == IntPtr.Zero)
				{
					id_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_ = JNIEnv.GetMethodID(class_ref, "setIconToggleAnimatorSet", "(Landroid/animation/AnimatorSet;)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIconToggleAnimatorSet", "(Landroid/animation/AnimatorSet;)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public virtual bool IsMenuButtonHidden
		{
			[Register("isMenuButtonHidden", "()Z", "GetIsMenuButtonHiddenHandler")]
			get
			{
				if (id_isMenuButtonHidden == IntPtr.Zero)
				{
					id_isMenuButtonHidden = JNIEnv.GetMethodID(class_ref, "isMenuButtonHidden", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isMenuButtonHidden);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isMenuButtonHidden", "()Z"));
				}
				finally
				{
				}
			}
		}

		public virtual bool IsMenuHidden
		{
			[Register("isMenuHidden", "()Z", "GetIsMenuHiddenHandler")]
			get
			{
				if (id_isMenuHidden == IntPtr.Zero)
				{
					id_isMenuHidden = JNIEnv.GetMethodID(class_ref, "isMenuHidden", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isMenuHidden);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isMenuHidden", "()Z"));
				}
				finally
				{
				}
			}
		}

		public virtual bool IsOpened
		{
			[Register("isOpened", "()Z", "GetIsOpenedHandler")]
			get
			{
				if (id_isOpened == IntPtr.Zero)
				{
					id_isOpened = JNIEnv.GetMethodID(class_ref, "isOpened", "()Z");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallBooleanMethod(base.Handle, id_isOpened);
					}
					return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isOpened", "()Z"));
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int MenuButtonColorNormal
		{
			[Register("getMenuButtonColorNormal", "()I", "GetGetMenuButtonColorNormalHandler")]
			get
			{
				if (id_getMenuButtonColorNormal == IntPtr.Zero)
				{
					id_getMenuButtonColorNormal = JNIEnv.GetMethodID(class_ref, "getMenuButtonColorNormal", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getMenuButtonColorNormal);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMenuButtonColorNormal", "()I"));
				}
				finally
				{
				}
			}
			[Register("setMenuButtonColorNormal", "(I)V", "GetSetMenuButtonColorNormal_IHandler")]
			set
			{
				if (id_setMenuButtonColorNormal_I == IntPtr.Zero)
				{
					id_setMenuButtonColorNormal_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorNormal", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorNormal_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorNormal", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int MenuButtonColorPressed
		{
			[Register("getMenuButtonColorPressed", "()I", "GetGetMenuButtonColorPressedHandler")]
			get
			{
				if (id_getMenuButtonColorPressed == IntPtr.Zero)
				{
					id_getMenuButtonColorPressed = JNIEnv.GetMethodID(class_ref, "getMenuButtonColorPressed", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getMenuButtonColorPressed);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMenuButtonColorPressed", "()I"));
				}
				finally
				{
				}
			}
			[Register("setMenuButtonColorPressed", "(I)V", "GetSetMenuButtonColorPressed_IHandler")]
			set
			{
				if (id_setMenuButtonColorPressed_I == IntPtr.Zero)
				{
					id_setMenuButtonColorPressed_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorPressed", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorPressed_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorPressed", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual int MenuButtonColorRipple
		{
			[Register("getMenuButtonColorRipple", "()I", "GetGetMenuButtonColorRippleHandler")]
			get
			{
				if (id_getMenuButtonColorRipple == IntPtr.Zero)
				{
					id_getMenuButtonColorRipple = JNIEnv.GetMethodID(class_ref, "getMenuButtonColorRipple", "()I");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.CallIntMethod(base.Handle, id_getMenuButtonColorRipple);
					}
					return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMenuButtonColorRipple", "()I"));
				}
				finally
				{
				}
			}
			[Register("setMenuButtonColorRipple", "(I)V", "GetSetMenuButtonColorRipple_IHandler")]
			set
			{
				if (id_setMenuButtonColorRipple_I == IntPtr.Zero)
				{
					id_setMenuButtonColorRipple_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorRipple", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(value);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorRipple_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorRipple", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		public unsafe virtual string MenuButtonLabelText
		{
			[Register("getMenuButtonLabelText", "()Ljava/lang/String;", "GetGetMenuButtonLabelTextHandler")]
			get
			{
				if (id_getMenuButtonLabelText == IntPtr.Zero)
				{
					id_getMenuButtonLabelText = JNIEnv.GetMethodID(class_ref, "getMenuButtonLabelText", "()Ljava/lang/String;");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getMenuButtonLabelText), JniHandleOwnership.TransferLocalRef);
					}
					return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMenuButtonLabelText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
			[Register("setMenuButtonLabelText", "(Ljava/lang/String;)V", "GetSetMenuButtonLabelText_Ljava_lang_String_Handler")]
			set
			{
				if (id_setMenuButtonLabelText_Ljava_lang_String_ == IntPtr.Zero)
				{
					id_setMenuButtonLabelText_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "setMenuButtonLabelText", "(Ljava/lang/String;)V");
				}
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(intPtr);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonLabelText_Ljava_lang_String_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonLabelText", "(Ljava/lang/String;)V"), ptr);
					}
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public virtual ImageView MenuIconView
		{
			[Register("getMenuIconView", "()Landroid/widget/ImageView;", "GetGetMenuIconViewHandler")]
			get
			{
				if (id_getMenuIconView == IntPtr.Zero)
				{
					id_getMenuIconView = JNIEnv.GetMethodID(class_ref, "getMenuIconView", "()Landroid/widget/ImageView;");
				}
				try
				{
					if (GetType() == ThresholdType)
					{
						return Java.Lang.Object.GetObject<ImageView>(JNIEnv.CallObjectMethod(base.Handle, id_getMenuIconView), JniHandleOwnership.TransferLocalRef);
					}
					return Java.Lang.Object.GetObject<ImageView>(JNIEnv.CallNonvirtualObjectMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getMenuIconView", "()Landroid/widget/ImageView;")), JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
		}

		public event EventHandler<MenuToggleEventArgs> MenuToggle
		{
			add
			{
				EventHelper.AddEventHandler<IOnMenuToggleListener, IOnMenuToggleListenerImplementor>(ref weak_implementor_SetOnMenuToggleListener, __CreateIOnMenuToggleListenerImplementor, SetOnMenuToggleListener, delegate(IOnMenuToggleListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MenuToggleEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IOnMenuToggleListener, IOnMenuToggleListenerImplementor>(ref weak_implementor_SetOnMenuToggleListener, IOnMenuToggleListenerImplementor.__IsEmpty, delegate
				{
					SetOnMenuToggleListener(null);
				}, delegate(IOnMenuToggleListenerImplementor __h)
				{
					__h.Handler = (EventHandler<MenuToggleEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected FloatingActionMenu(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe FloatingActionMenu(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(defStyleAttr);
				if (GetType() != typeof(FloatingActionMenu))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe FloatingActionMenu(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				if (GetType() != typeof(FloatingActionMenu))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe FloatingActionMenu(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(context);
				if (GetType() != typeof(FloatingActionMenu))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_, ptr);
			}
			finally
			{
			}
		}

		private static Delegate GetIsAnimatedHandler()
		{
			if ((object)cb_isAnimated == null)
			{
				cb_isAnimated = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsAnimated));
			}
			return cb_isAnimated;
		}

		private static bool n_IsAnimated(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.Animated;
		}

		private static Delegate GetSetAnimated_ZHandler()
		{
			if ((object)cb_setAnimated_Z == null)
			{
				cb_setAnimated_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetAnimated_Z));
			}
			return cb_setAnimated_Z;
		}

		private static void n_SetAnimated_Z(IntPtr jnienv, IntPtr native__this, bool animated)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.Animated = animated;
		}

		private static Delegate GetGetAnimationDelayPerItemHandler()
		{
			if ((object)cb_getAnimationDelayPerItem == null)
			{
				cb_getAnimationDelayPerItem = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetAnimationDelayPerItem));
			}
			return cb_getAnimationDelayPerItem;
		}

		private static int n_GetAnimationDelayPerItem(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.AnimationDelayPerItem;
		}

		private static Delegate GetSetAnimationDelayPerItem_IHandler()
		{
			if ((object)cb_setAnimationDelayPerItem_I == null)
			{
				cb_setAnimationDelayPerItem_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAnimationDelayPerItem_I));
			}
			return cb_setAnimationDelayPerItem_I;
		}

		private static void n_SetAnimationDelayPerItem_I(IntPtr jnienv, IntPtr native__this, int animationDelayPerItem)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.AnimationDelayPerItem = animationDelayPerItem;
		}

		private static Delegate GetIsIconAnimatedHandler()
		{
			if ((object)cb_isIconAnimated == null)
			{
				cb_isIconAnimated = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsIconAnimated));
			}
			return cb_isIconAnimated;
		}

		private static bool n_IsIconAnimated(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.IconAnimated;
		}

		private static Delegate GetSetIconAnimated_ZHandler()
		{
			if ((object)cb_setIconAnimated_Z == null)
			{
				cb_setIconAnimated_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetIconAnimated_Z));
			}
			return cb_setIconAnimated_Z;
		}

		private static void n_SetIconAnimated_Z(IntPtr jnienv, IntPtr native__this, bool animated)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.IconAnimated = animated;
		}

		private static Delegate GetGetIconToggleAnimatorSetHandler()
		{
			if ((object)cb_getIconToggleAnimatorSet == null)
			{
				cb_getIconToggleAnimatorSet = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetIconToggleAnimatorSet));
			}
			return cb_getIconToggleAnimatorSet;
		}

		private static IntPtr n_GetIconToggleAnimatorSet(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(floatingActionMenu.IconToggleAnimatorSet);
		}

		private static Delegate GetSetIconToggleAnimatorSet_Landroid_animation_AnimatorSet_Handler()
		{
			if ((object)cb_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_ == null)
			{
				cb_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconToggleAnimatorSet_Landroid_animation_AnimatorSet_));
			}
			return cb_setIconToggleAnimatorSet_Landroid_animation_AnimatorSet_;
		}

		private static void n_SetIconToggleAnimatorSet_Landroid_animation_AnimatorSet_(IntPtr jnienv, IntPtr native__this, IntPtr native_toggleAnimatorSet)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AnimatorSet iconToggleAnimatorSet = Java.Lang.Object.GetObject<AnimatorSet>(native_toggleAnimatorSet, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.IconToggleAnimatorSet = iconToggleAnimatorSet;
		}

		private static Delegate GetIsMenuButtonHiddenHandler()
		{
			if ((object)cb_isMenuButtonHidden == null)
			{
				cb_isMenuButtonHidden = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsMenuButtonHidden));
			}
			return cb_isMenuButtonHidden;
		}

		private static bool n_IsMenuButtonHidden(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.IsMenuButtonHidden;
		}

		private static Delegate GetIsMenuHiddenHandler()
		{
			if ((object)cb_isMenuHidden == null)
			{
				cb_isMenuHidden = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsMenuHidden));
			}
			return cb_isMenuHidden;
		}

		private static bool n_IsMenuHidden(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.IsMenuHidden;
		}

		private static Delegate GetIsOpenedHandler()
		{
			if ((object)cb_isOpened == null)
			{
				cb_isOpened = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsOpened));
			}
			return cb_isOpened;
		}

		private static bool n_IsOpened(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.IsOpened;
		}

		private static Delegate GetGetMenuButtonColorNormalHandler()
		{
			if ((object)cb_getMenuButtonColorNormal == null)
			{
				cb_getMenuButtonColorNormal = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMenuButtonColorNormal));
			}
			return cb_getMenuButtonColorNormal;
		}

		private static int n_GetMenuButtonColorNormal(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.MenuButtonColorNormal;
		}

		private static Delegate GetSetMenuButtonColorNormal_IHandler()
		{
			if ((object)cb_setMenuButtonColorNormal_I == null)
			{
				cb_setMenuButtonColorNormal_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorNormal_I));
			}
			return cb_setMenuButtonColorNormal_I;
		}

		private static void n_SetMenuButtonColorNormal_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.MenuButtonColorNormal = color;
		}

		private static Delegate GetGetMenuButtonColorPressedHandler()
		{
			if ((object)cb_getMenuButtonColorPressed == null)
			{
				cb_getMenuButtonColorPressed = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMenuButtonColorPressed));
			}
			return cb_getMenuButtonColorPressed;
		}

		private static int n_GetMenuButtonColorPressed(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.MenuButtonColorPressed;
		}

		private static Delegate GetSetMenuButtonColorPressed_IHandler()
		{
			if ((object)cb_setMenuButtonColorPressed_I == null)
			{
				cb_setMenuButtonColorPressed_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorPressed_I));
			}
			return cb_setMenuButtonColorPressed_I;
		}

		private static void n_SetMenuButtonColorPressed_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.MenuButtonColorPressed = color;
		}

		private static Delegate GetGetMenuButtonColorRippleHandler()
		{
			if ((object)cb_getMenuButtonColorRipple == null)
			{
				cb_getMenuButtonColorRipple = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMenuButtonColorRipple));
			}
			return cb_getMenuButtonColorRipple;
		}

		private static int n_GetMenuButtonColorRipple(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return floatingActionMenu.MenuButtonColorRipple;
		}

		private static Delegate GetSetMenuButtonColorRipple_IHandler()
		{
			if ((object)cb_setMenuButtonColorRipple_I == null)
			{
				cb_setMenuButtonColorRipple_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorRipple_I));
			}
			return cb_setMenuButtonColorRipple_I;
		}

		private static void n_SetMenuButtonColorRipple_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.MenuButtonColorRipple = color;
		}

		private static Delegate GetGetMenuButtonLabelTextHandler()
		{
			if ((object)cb_getMenuButtonLabelText == null)
			{
				cb_getMenuButtonLabelText = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetMenuButtonLabelText));
			}
			return cb_getMenuButtonLabelText;
		}

		private static IntPtr n_GetMenuButtonLabelText(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(floatingActionMenu.MenuButtonLabelText);
		}

		private static Delegate GetSetMenuButtonLabelText_Ljava_lang_String_Handler()
		{
			if ((object)cb_setMenuButtonLabelText_Ljava_lang_String_ == null)
			{
				cb_setMenuButtonLabelText_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetMenuButtonLabelText_Ljava_lang_String_));
			}
			return cb_setMenuButtonLabelText_Ljava_lang_String_;
		}

		private static void n_SetMenuButtonLabelText_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string menuButtonLabelText = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.MenuButtonLabelText = menuButtonLabelText;
		}

		private static Delegate GetGetMenuIconViewHandler()
		{
			if ((object)cb_getMenuIconView == null)
			{
				cb_getMenuIconView = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetMenuIconView));
			}
			return cb_getMenuIconView;
		}

		private static IntPtr n_GetMenuIconView(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(floatingActionMenu.MenuIconView);
		}

		private static Delegate GetAddMenuButton_Lcom_github_clans_fab_FloatingActionButton_Handler()
		{
			if ((object)cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_ == null)
			{
				cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AddMenuButton_Lcom_github_clans_fab_FloatingActionButton_));
			}
			return cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_;
		}

		private static void n_AddMenuButton_Lcom_github_clans_fab_FloatingActionButton_(IntPtr jnienv, IntPtr native__this, IntPtr native_fab)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.AddMenuButton(fab);
		}

		[Register("addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V", "GetAddMenuButton_Lcom_github_clans_fab_FloatingActionButton_Handler")]
		public unsafe virtual void AddMenuButton(FloatingActionButton fab)
		{
			if (id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_ == IntPtr.Zero)
			{
				id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_ = JNIEnv.GetMethodID(class_ref, "addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(fab);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetAddMenuButton_Lcom_github_clans_fab_FloatingActionButton_IHandler()
		{
			if ((object)cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I == null)
			{
				cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int>(n_AddMenuButton_Lcom_github_clans_fab_FloatingActionButton_I));
			}
			return cb_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I;
		}

		private static void n_AddMenuButton_Lcom_github_clans_fab_FloatingActionButton_I(IntPtr jnienv, IntPtr native__this, IntPtr native_fab, int p1)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.AddMenuButton(fab, p1);
		}

		[Register("addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;I)V", "GetAddMenuButton_Lcom_github_clans_fab_FloatingActionButton_IHandler")]
		public unsafe virtual void AddMenuButton(FloatingActionButton fab, int p1)
		{
			if (id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I == IntPtr.Zero)
			{
				id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I = JNIEnv.GetMethodID(class_ref, "addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(fab);
				ptr[1] = new JValue(p1);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_addMenuButton_Lcom_github_clans_fab_FloatingActionButton_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "addMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetClose_ZHandler()
		{
			if ((object)cb_close_Z == null)
			{
				cb_close_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Close_Z));
			}
			return cb_close_Z;
		}

		private static void n_Close_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.Close(animate);
		}

		[Register("close", "(Z)V", "GetClose_ZHandler")]
		public unsafe virtual void Close(bool animate)
		{
			if (id_close_Z == IntPtr.Zero)
			{
				id_close_Z = JNIEnv.GetMethodID(class_ref, "close", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_close_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "close", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetHideMenu_ZHandler()
		{
			if ((object)cb_hideMenu_Z == null)
			{
				cb_hideMenu_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_HideMenu_Z));
			}
			return cb_hideMenu_Z;
		}

		private static void n_HideMenu_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.HideMenu(animate);
		}

		[Register("hideMenu", "(Z)V", "GetHideMenu_ZHandler")]
		public unsafe virtual void HideMenu(bool animate)
		{
			if (id_hideMenu_Z == IntPtr.Zero)
			{
				id_hideMenu_Z = JNIEnv.GetMethodID(class_ref, "hideMenu", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_hideMenu_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hideMenu", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetHideMenuButton_ZHandler()
		{
			if ((object)cb_hideMenuButton_Z == null)
			{
				cb_hideMenuButton_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_HideMenuButton_Z));
			}
			return cb_hideMenuButton_Z;
		}

		private static void n_HideMenuButton_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.HideMenuButton(animate);
		}

		[Register("hideMenuButton", "(Z)V", "GetHideMenuButton_ZHandler")]
		public unsafe virtual void HideMenuButton(bool animate)
		{
			if (id_hideMenuButton_Z == IntPtr.Zero)
			{
				id_hideMenuButton_Z = JNIEnv.GetMethodID(class_ref, "hideMenuButton", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_hideMenuButton_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "hideMenuButton", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetOnLayout_ZIIIIHandler()
		{
			if ((object)cb_onLayout_ZIIII == null)
			{
				cb_onLayout_ZIIII = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool, int, int, int, int>(n_OnLayout_ZIIII));
			}
			return cb_onLayout_ZIIII;
		}

		private static void n_OnLayout_ZIIII(IntPtr jnienv, IntPtr native__this, bool p0, int p1, int p2, int p3, int p4)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.OnLayout(p0, p1, p2, p3, p4);
		}

		[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
		protected unsafe override void OnLayout(bool p0, int p1, int p2, int p3, int p4)
		{
			if (id_onLayout_ZIIII == IntPtr.Zero)
			{
				id_onLayout_ZIIII = JNIEnv.GetMethodID(class_ref, "onLayout", "(ZIIII)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[5];
				*ptr = new JValue(p0);
				ptr[1] = new JValue(p1);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(p2);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 3) = new JValue(p3);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 4) = new JValue(p4);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_onLayout_ZIIII, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onLayout", "(ZIIII)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetOpen_ZHandler()
		{
			if ((object)cb_open_Z == null)
			{
				cb_open_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Open_Z));
			}
			return cb_open_Z;
		}

		private static void n_Open_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.Open(animate);
		}

		[Register("open", "(Z)V", "GetOpen_ZHandler")]
		public unsafe virtual void Open(bool animate)
		{
			if (id_open_Z == IntPtr.Zero)
			{
				id_open_Z = JNIEnv.GetMethodID(class_ref, "open", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_open_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "open", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetRemoveAllMenuButtonsHandler()
		{
			if ((object)cb_removeAllMenuButtons == null)
			{
				cb_removeAllMenuButtons = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_RemoveAllMenuButtons));
			}
			return cb_removeAllMenuButtons;
		}

		private static void n_RemoveAllMenuButtons(IntPtr jnienv, IntPtr native__this)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.RemoveAllMenuButtons();
		}

		[Register("removeAllMenuButtons", "()V", "GetRemoveAllMenuButtonsHandler")]
		public virtual void RemoveAllMenuButtons()
		{
			if (id_removeAllMenuButtons == IntPtr.Zero)
			{
				id_removeAllMenuButtons = JNIEnv.GetMethodID(class_ref, "removeAllMenuButtons", "()V");
			}
			try
			{
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_removeAllMenuButtons);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "removeAllMenuButtons", "()V"));
				}
			}
			finally
			{
			}
		}

		private static Delegate GetRemoveMenuButton_Lcom_github_clans_fab_FloatingActionButton_Handler()
		{
			if ((object)cb_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_ == null)
			{
				cb_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RemoveMenuButton_Lcom_github_clans_fab_FloatingActionButton_));
			}
			return cb_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_;
		}

		private static void n_RemoveMenuButton_Lcom_github_clans_fab_FloatingActionButton_(IntPtr jnienv, IntPtr native__this, IntPtr native_fab)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.RemoveMenuButton(fab);
		}

		[Register("removeMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V", "GetRemoveMenuButton_Lcom_github_clans_fab_FloatingActionButton_Handler")]
		public unsafe virtual void RemoveMenuButton(FloatingActionButton fab)
		{
			if (id_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_ == IntPtr.Zero)
			{
				id_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_ = JNIEnv.GetMethodID(class_ref, "removeMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(fab);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_removeMenuButton_Lcom_github_clans_fab_FloatingActionButton_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "removeMenuButton", "(Lcom/github/clans/fab/FloatingActionButton;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetClosedOnTouchOutside_ZHandler()
		{
			if ((object)cb_setClosedOnTouchOutside_Z == null)
			{
				cb_setClosedOnTouchOutside_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetClosedOnTouchOutside_Z));
			}
			return cb_setClosedOnTouchOutside_Z;
		}

		private static void n_SetClosedOnTouchOutside_Z(IntPtr jnienv, IntPtr native__this, bool close)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetClosedOnTouchOutside(close);
		}

		[Register("setClosedOnTouchOutside", "(Z)V", "GetSetClosedOnTouchOutside_ZHandler")]
		public unsafe virtual void SetClosedOnTouchOutside(bool close)
		{
			if (id_setClosedOnTouchOutside_Z == IntPtr.Zero)
			{
				id_setClosedOnTouchOutside_Z = JNIEnv.GetMethodID(class_ref, "setClosedOnTouchOutside", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(close);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setClosedOnTouchOutside_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setClosedOnTouchOutside", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_Handler()
		{
			if ((object)cb_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_ == null)
			{
				cb_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_));
			}
			return cb_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_;
		}

		private static void n_SetIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_closeInterpolator)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator iconAnimationCloseInterpolator = Java.Lang.Object.GetObject<IInterpolator>(native_closeInterpolator, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetIconAnimationCloseInterpolator(iconAnimationCloseInterpolator);
		}

		[Register("setIconAnimationCloseInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_Handler")]
		public unsafe virtual void SetIconAnimationCloseInterpolator(IInterpolator closeInterpolator)
		{
			if (id_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_ == IntPtr.Zero)
			{
				id_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_ = JNIEnv.GetMethodID(class_ref, "setIconAnimationCloseInterpolator", "(Landroid/view/animation/Interpolator;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(closeInterpolator);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setIconAnimationCloseInterpolator_Landroid_view_animation_Interpolator_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIconAnimationCloseInterpolator", "(Landroid/view/animation/Interpolator;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetIconAnimationInterpolator_Landroid_view_animation_Interpolator_Handler()
		{
			if ((object)cb_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_ == null)
			{
				cb_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconAnimationInterpolator_Landroid_view_animation_Interpolator_));
			}
			return cb_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_;
		}

		private static void n_SetIconAnimationInterpolator_Landroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_interpolator)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator iconAnimationInterpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetIconAnimationInterpolator(iconAnimationInterpolator);
		}

		[Register("setIconAnimationInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetIconAnimationInterpolator_Landroid_view_animation_Interpolator_Handler")]
		public unsafe virtual void SetIconAnimationInterpolator(IInterpolator interpolator)
		{
			if (id_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_ == IntPtr.Zero)
			{
				id_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_ = JNIEnv.GetMethodID(class_ref, "setIconAnimationInterpolator", "(Landroid/view/animation/Interpolator;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(interpolator);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setIconAnimationInterpolator_Landroid_view_animation_Interpolator_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIconAnimationInterpolator", "(Landroid/view/animation/Interpolator;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_Handler()
		{
			if ((object)cb_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_ == null)
			{
				cb_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_));
			}
			return cb_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_;
		}

		private static void n_SetIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_(IntPtr jnienv, IntPtr native__this, IntPtr native_openInterpolator)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator iconAnimationOpenInterpolator = Java.Lang.Object.GetObject<IInterpolator>(native_openInterpolator, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetIconAnimationOpenInterpolator(iconAnimationOpenInterpolator);
		}

		[Register("setIconAnimationOpenInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_Handler")]
		public unsafe virtual void SetIconAnimationOpenInterpolator(IInterpolator openInterpolator)
		{
			if (id_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_ == IntPtr.Zero)
			{
				id_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_ = JNIEnv.GetMethodID(class_ref, "setIconAnimationOpenInterpolator", "(Landroid/view/animation/Interpolator;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(openInterpolator);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setIconAnimationOpenInterpolator_Landroid_view_animation_Interpolator_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setIconAnimationOpenInterpolator", "(Landroid/view/animation/Interpolator;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetMenuButtonColorNormalResId_IHandler()
		{
			if ((object)cb_setMenuButtonColorNormalResId_I == null)
			{
				cb_setMenuButtonColorNormalResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorNormalResId_I));
			}
			return cb_setMenuButtonColorNormalResId_I;
		}

		private static void n_SetMenuButtonColorNormalResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetMenuButtonColorNormalResId(colorResId);
		}

		[Register("setMenuButtonColorNormalResId", "(I)V", "GetSetMenuButtonColorNormalResId_IHandler")]
		public unsafe virtual void SetMenuButtonColorNormalResId(int colorResId)
		{
			if (id_setMenuButtonColorNormalResId_I == IntPtr.Zero)
			{
				id_setMenuButtonColorNormalResId_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorNormalResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorNormalResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorNormalResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetMenuButtonColorPressedResId_IHandler()
		{
			if ((object)cb_setMenuButtonColorPressedResId_I == null)
			{
				cb_setMenuButtonColorPressedResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorPressedResId_I));
			}
			return cb_setMenuButtonColorPressedResId_I;
		}

		private static void n_SetMenuButtonColorPressedResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetMenuButtonColorPressedResId(colorResId);
		}

		[Register("setMenuButtonColorPressedResId", "(I)V", "GetSetMenuButtonColorPressedResId_IHandler")]
		public unsafe virtual void SetMenuButtonColorPressedResId(int colorResId)
		{
			if (id_setMenuButtonColorPressedResId_I == IntPtr.Zero)
			{
				id_setMenuButtonColorPressedResId_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorPressedResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorPressedResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorPressedResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetMenuButtonColorRippleResId_IHandler()
		{
			if ((object)cb_setMenuButtonColorRippleResId_I == null)
			{
				cb_setMenuButtonColorRippleResId_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMenuButtonColorRippleResId_I));
			}
			return cb_setMenuButtonColorRippleResId_I;
		}

		private static void n_SetMenuButtonColorRippleResId_I(IntPtr jnienv, IntPtr native__this, int colorResId)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetMenuButtonColorRippleResId(colorResId);
		}

		[Register("setMenuButtonColorRippleResId", "(I)V", "GetSetMenuButtonColorRippleResId_IHandler")]
		public unsafe virtual void SetMenuButtonColorRippleResId(int colorResId)
		{
			if (id_setMenuButtonColorRippleResId_I == IntPtr.Zero)
			{
				id_setMenuButtonColorRippleResId_I = JNIEnv.GetMethodID(class_ref, "setMenuButtonColorRippleResId", "(I)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(colorResId);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonColorRippleResId_I, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonColorRippleResId", "(I)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetMenuButtonHideAnimation_Landroid_view_animation_Animation_Handler()
		{
			if ((object)cb_setMenuButtonHideAnimation_Landroid_view_animation_Animation_ == null)
			{
				cb_setMenuButtonHideAnimation_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetMenuButtonHideAnimation_Landroid_view_animation_Animation_));
			}
			return cb_setMenuButtonHideAnimation_Landroid_view_animation_Animation_;
		}

		private static void n_SetMenuButtonHideAnimation_Landroid_view_animation_Animation_(IntPtr jnienv, IntPtr native__this, IntPtr native_hideAnimation)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animation menuButtonHideAnimation = Java.Lang.Object.GetObject<Animation>(native_hideAnimation, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetMenuButtonHideAnimation(menuButtonHideAnimation);
		}

		[Register("setMenuButtonHideAnimation", "(Landroid/view/animation/Animation;)V", "GetSetMenuButtonHideAnimation_Landroid_view_animation_Animation_Handler")]
		public unsafe virtual void SetMenuButtonHideAnimation(Animation hideAnimation)
		{
			if (id_setMenuButtonHideAnimation_Landroid_view_animation_Animation_ == IntPtr.Zero)
			{
				id_setMenuButtonHideAnimation_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID(class_ref, "setMenuButtonHideAnimation", "(Landroid/view/animation/Animation;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(hideAnimation);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonHideAnimation_Landroid_view_animation_Animation_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonHideAnimation", "(Landroid/view/animation/Animation;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetMenuButtonShowAnimation_Landroid_view_animation_Animation_Handler()
		{
			if ((object)cb_setMenuButtonShowAnimation_Landroid_view_animation_Animation_ == null)
			{
				cb_setMenuButtonShowAnimation_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetMenuButtonShowAnimation_Landroid_view_animation_Animation_));
			}
			return cb_setMenuButtonShowAnimation_Landroid_view_animation_Animation_;
		}

		private static void n_SetMenuButtonShowAnimation_Landroid_view_animation_Animation_(IntPtr jnienv, IntPtr native__this, IntPtr native_showAnimation)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animation menuButtonShowAnimation = Java.Lang.Object.GetObject<Animation>(native_showAnimation, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetMenuButtonShowAnimation(menuButtonShowAnimation);
		}

		[Register("setMenuButtonShowAnimation", "(Landroid/view/animation/Animation;)V", "GetSetMenuButtonShowAnimation_Landroid_view_animation_Animation_Handler")]
		public unsafe virtual void SetMenuButtonShowAnimation(Animation showAnimation)
		{
			if (id_setMenuButtonShowAnimation_Landroid_view_animation_Animation_ == IntPtr.Zero)
			{
				id_setMenuButtonShowAnimation_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID(class_ref, "setMenuButtonShowAnimation", "(Landroid/view/animation/Animation;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(showAnimation);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setMenuButtonShowAnimation_Landroid_view_animation_Animation_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setMenuButtonShowAnimation", "(Landroid/view/animation/Animation;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetOnMenuButtonClickListener_Landroid_view_View_OnClickListener_Handler()
		{
			if ((object)cb_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_ == null)
			{
				cb_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnMenuButtonClickListener_Landroid_view_View_OnClickListener_));
			}
			return cb_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_;
		}

		private static void n_SetOnMenuButtonClickListener_Landroid_view_View_OnClickListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_clickListener)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener onMenuButtonClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_clickListener, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetOnMenuButtonClickListener(onMenuButtonClickListener);
		}

		[Register("setOnMenuButtonClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetOnMenuButtonClickListener_Landroid_view_View_OnClickListener_Handler")]
		public unsafe virtual void SetOnMenuButtonClickListener(IOnClickListener clickListener)
		{
			if (id_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_ == IntPtr.Zero)
			{
				id_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_ = JNIEnv.GetMethodID(class_ref, "setOnMenuButtonClickListener", "(Landroid/view/View$OnClickListener;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(clickListener);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setOnMenuButtonClickListener_Landroid_view_View_OnClickListener_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOnMenuButtonClickListener", "(Landroid/view/View$OnClickListener;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
		{
			if ((object)cb_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_ == null)
			{
				cb_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_));
			}
			return cb_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_;
		}

		private static void n_SetOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_longClickListener)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLongClickListener onMenuButtonLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(native_longClickListener, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetOnMenuButtonLongClickListener(onMenuButtonLongClickListener);
		}

		[Register("setOnMenuButtonLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
		public unsafe virtual void SetOnMenuButtonLongClickListener(IOnLongClickListener longClickListener)
		{
			if (id_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_ == IntPtr.Zero)
			{
				id_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_ = JNIEnv.GetMethodID(class_ref, "setOnMenuButtonLongClickListener", "(Landroid/view/View$OnLongClickListener;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(longClickListener);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setOnMenuButtonLongClickListener_Landroid_view_View_OnLongClickListener_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOnMenuButtonLongClickListener", "(Landroid/view/View$OnLongClickListener;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetSetOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_Handler()
		{
			if ((object)cb_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_ == null)
			{
				cb_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_));
			}
			return cb_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_;
		}

		private static void n_SetOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMenuToggleListener onMenuToggleListener = Java.Lang.Object.GetObject<IOnMenuToggleListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.SetOnMenuToggleListener(onMenuToggleListener);
		}

		[Register("setOnMenuToggleListener", "(Lcom/github/clans/fab/FloatingActionMenu$OnMenuToggleListener;)V", "GetSetOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_Handler")]
		public unsafe virtual void SetOnMenuToggleListener(IOnMenuToggleListener listener)
		{
			if (id_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_ == IntPtr.Zero)
			{
				id_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_ = JNIEnv.GetMethodID(class_ref, "setOnMenuToggleListener", "(Lcom/github/clans/fab/FloatingActionMenu$OnMenuToggleListener;)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(listener);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_setOnMenuToggleListener_Lcom_github_clans_fab_FloatingActionMenu_OnMenuToggleListener_, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setOnMenuToggleListener", "(Lcom/github/clans/fab/FloatingActionMenu$OnMenuToggleListener;)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetShowMenu_ZHandler()
		{
			if ((object)cb_showMenu_Z == null)
			{
				cb_showMenu_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_ShowMenu_Z));
			}
			return cb_showMenu_Z;
		}

		private static void n_ShowMenu_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.ShowMenu(animate);
		}

		[Register("showMenu", "(Z)V", "GetShowMenu_ZHandler")]
		public unsafe virtual void ShowMenu(bool animate)
		{
			if (id_showMenu_Z == IntPtr.Zero)
			{
				id_showMenu_Z = JNIEnv.GetMethodID(class_ref, "showMenu", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_showMenu_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "showMenu", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetShowMenuButton_ZHandler()
		{
			if ((object)cb_showMenuButton_Z == null)
			{
				cb_showMenuButton_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_ShowMenuButton_Z));
			}
			return cb_showMenuButton_Z;
		}

		private static void n_ShowMenuButton_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.ShowMenuButton(animate);
		}

		[Register("showMenuButton", "(Z)V", "GetShowMenuButton_ZHandler")]
		public unsafe virtual void ShowMenuButton(bool animate)
		{
			if (id_showMenuButton_Z == IntPtr.Zero)
			{
				id_showMenuButton_Z = JNIEnv.GetMethodID(class_ref, "showMenuButton", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_showMenuButton_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "showMenuButton", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetToggle_ZHandler()
		{
			if ((object)cb_toggle_Z == null)
			{
				cb_toggle_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Toggle_Z));
			}
			return cb_toggle_Z;
		}

		private static void n_Toggle_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.Toggle(animate);
		}

		[Register("toggle", "(Z)V", "GetToggle_ZHandler")]
		public unsafe virtual void Toggle(bool animate)
		{
			if (id_toggle_Z == IntPtr.Zero)
			{
				id_toggle_Z = JNIEnv.GetMethodID(class_ref, "toggle", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_toggle_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "toggle", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetToggleMenu_ZHandler()
		{
			if ((object)cb_toggleMenu_Z == null)
			{
				cb_toggleMenu_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_ToggleMenu_Z));
			}
			return cb_toggleMenu_Z;
		}

		private static void n_ToggleMenu_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.ToggleMenu(p0);
		}

		[Register("toggleMenu", "(Z)V", "GetToggleMenu_ZHandler")]
		public unsafe virtual void ToggleMenu(bool p0)
		{
			if (id_toggleMenu_Z == IntPtr.Zero)
			{
				id_toggleMenu_Z = JNIEnv.GetMethodID(class_ref, "toggleMenu", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_toggleMenu_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "toggleMenu", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private static Delegate GetToggleMenuButton_ZHandler()
		{
			if ((object)cb_toggleMenuButton_Z == null)
			{
				cb_toggleMenuButton_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_ToggleMenuButton_Z));
			}
			return cb_toggleMenuButton_Z;
		}

		private static void n_ToggleMenuButton_Z(IntPtr jnienv, IntPtr native__this, bool animate)
		{
			FloatingActionMenu floatingActionMenu = Java.Lang.Object.GetObject<FloatingActionMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			floatingActionMenu.ToggleMenuButton(animate);
		}

		[Register("toggleMenuButton", "(Z)V", "GetToggleMenuButton_ZHandler")]
		public unsafe virtual void ToggleMenuButton(bool animate)
		{
			if (id_toggleMenuButton_Z == IntPtr.Zero)
			{
				id_toggleMenuButton_Z = JNIEnv.GetMethodID(class_ref, "toggleMenuButton", "(Z)V");
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(animate);
				if (GetType() == ThresholdType)
				{
					JNIEnv.CallVoidMethod(base.Handle, id_toggleMenuButton_Z, ptr);
				}
				else
				{
					JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "toggleMenuButton", "(Z)V"), ptr);
				}
			}
			finally
			{
			}
		}

		private IOnMenuToggleListenerImplementor __CreateIOnMenuToggleListenerImplementor()
		{
			return new IOnMenuToggleListenerImplementor(this);
		}
	}
	[Register("com/github/clans/fab/Label", DoNotGenerateAcw = true)]
	public class Label : TextView
	{
		[Register("com/github/clans/fab/Label$Shadow", DoNotGenerateAcw = true)]
		public class Shadow : Drawable
		{
			internal static IntPtr java_class_handle;

			private static Delegate cb_getOpacity;

			private static IntPtr id_getOpacity;

			private static Delegate cb_draw_Landroid_graphics_Canvas_;

			private static IntPtr id_draw_Landroid_graphics_Canvas_;

			private static Delegate cb_setAlpha_I;

			private static IntPtr id_setAlpha_I;

			private static Delegate cb_setColorFilter_Landroid_graphics_ColorFilter_;

			private static IntPtr id_setColorFilter_Landroid_graphics_ColorFilter_;

			internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/Label$Shadow", ref java_class_handle);

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => typeof(Shadow);

			public override int Opacity
			{
				[Register("getOpacity", "()I", "GetGetOpacityHandler")]
				get
				{
					if (id_getOpacity == IntPtr.Zero)
					{
						id_getOpacity = JNIEnv.GetMethodID(class_ref, "getOpacity", "()I");
					}
					try
					{
						if (GetType() == ThresholdType)
						{
							return JNIEnv.CallIntMethod(base.Handle, id_getOpacity);
						}
						return JNIEnv.CallNonvirtualIntMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getOpacity", "()I"));
					}
					finally
					{
					}
				}
			}

			protected Shadow(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetOpacityHandler()
			{
				if ((object)cb_getOpacity == null)
				{
					cb_getOpacity = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetOpacity));
				}
				return cb_getOpacity;
			}

			private static int n_GetOpacity(IntPtr jnienv, IntPtr native__this)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return shadow.Opacity;
			}

			private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
			{
				if ((object)cb_draw_Landroid_graphics_Canvas_ == null)
				{
					cb_draw_Landroid_graphics_Canvas_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Draw_Landroid_graphics_Canvas_));
				}
				return cb_draw_Landroid_graphics_Canvas_;
			}

			private static void n_Draw_Landroid_graphics_Canvas_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_p0, JniHandleOwnership.DoNotTransfer);
				shadow.Draw(canvas);
			}

			[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
			public unsafe override void Draw(Canvas p0)
			{
				if (id_draw_Landroid_graphics_Canvas_ == IntPtr.Zero)
				{
					id_draw_Landroid_graphics_Canvas_ = JNIEnv.GetMethodID(class_ref, "draw", "(Landroid/graphics/Canvas;)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_draw_Landroid_graphics_Canvas_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "draw", "(Landroid/graphics/Canvas;)V"), ptr);
					}
				}
				finally
				{
				}
			}

			private static Delegate GetSetAlpha_IHandler()
			{
				if ((object)cb_setAlpha_I == null)
				{
					cb_setAlpha_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAlpha_I));
				}
				return cb_setAlpha_I;
			}

			private static void n_SetAlpha_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				shadow.SetAlpha(p0);
			}

			[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
			public unsafe override void SetAlpha(int p0)
			{
				if (id_setAlpha_I == IntPtr.Zero)
				{
					id_setAlpha_I = JNIEnv.GetMethodID(class_ref, "setAlpha", "(I)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setAlpha_I, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setAlpha", "(I)V"), ptr);
					}
				}
				finally
				{
				}
			}

			private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
			{
				if ((object)cb_setColorFilter_Landroid_graphics_ColorFilter_ == null)
				{
					cb_setColorFilter_Landroid_graphics_ColorFilter_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetColorFilter_Landroid_graphics_ColorFilter_));
				}
				return cb_setColorFilter_Landroid_graphics_ColorFilter_;
			}

			private static void n_SetColorFilter_Landroid_graphics_ColorFilter_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Shadow shadow = Java.Lang.Object.GetObject<Shadow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_p0, JniHandleOwnership.DoNotTransfer);
				shadow.SetColorFilter(colorFilter);
			}

			[Register("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
			public unsafe override void SetColorFilter(ColorFilter p0)
			{
				if (id_setColorFilter_Landroid_graphics_ColorFilter_ == IntPtr.Zero)
				{
					id_setColorFilter_Landroid_graphics_ColorFilter_ = JNIEnv.GetMethodID(class_ref, "setColorFilter", "(Landroid/graphics/ColorFilter;)V");
				}
				try
				{
					JValue* ptr = stackalloc JValue[1];
					*ptr = new JValue(p0);
					if (GetType() == ThresholdType)
					{
						JNIEnv.CallVoidMethod(base.Handle, id_setColorFilter_Landroid_graphics_ColorFilter_, ptr);
					}
					else
					{
						JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setColorFilter", "(Landroid/graphics/ColorFilter;)V"), ptr);
					}
				}
				finally
				{
				}
			}
		}

		internal static IntPtr java_class_handle;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;

		private static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;

		private static IntPtr id_ctor_Landroid_content_Context_;

		internal static IntPtr class_ref => JNIEnv.FindClass("com/github/clans/fab/Label", ref java_class_handle);

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => typeof(Label);

		protected Label(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe Label(Context context, IAttributeSet attrs, int p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				*(JValue*)((byte*)ptr + sizeof(JValue) * 2) = new JValue(p2);
				if (GetType() != typeof(Label))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe Label(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(context);
				ptr[1] = new JValue(attrs);
				if (GetType() != typeof(Label))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, ptr);
			}
			finally
			{
			}
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Label(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(context);
				if (GetType() != typeof(Label))
				{
					SetHandle(JNIEnv.StartCreateInstance(GetType(), "(Landroid/content/Context;)V", ptr), JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance(base.Handle, "(Landroid/content/Context;)V", ptr);
					return;
				}
				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
				{
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID(class_ref, "<init>", "(Landroid/content/Context;)V");
				}
				SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor_Landroid_content_Context_, ptr), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor_Landroid_content_Context_, ptr);
			}
			finally
			{
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_github_clans_fab_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/github/clans/fab" }, new Converter<string, Type>[1] { lookup_com_github_clans_fab_package });
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_com_github_clans_fab_package(string klass)
		{
			if (package_com_github_clans_fab_mappings == null)
			{
				package_com_github_clans_fab_mappings = new string[7] { "com/github/clans/fab/FloatingActionButton:Clans.Fab.FloatingActionButton", "com/github/clans/fab/FloatingActionButton$CircleDrawable:Clans.Fab.FloatingActionButton/CircleDrawable", "com/github/clans/fab/FloatingActionButton$ProgressSavedState:Clans.Fab.FloatingActionButton/ProgressSavedState", "com/github/clans/fab/FloatingActionButton$Shadow:Clans.Fab.FloatingActionButton/Shadow", "com/github/clans/fab/FloatingActionMenu:Clans.Fab.FloatingActionMenu", "com/github/clans/fab/Label:Clans.Fab.Label", "com/github/clans/fab/Label$Shadow:Clans.Fab.Label/Shadow" };
			}
			return Lookup(package_com_github_clans_fab_mappings, klass);
		}
	}
}
