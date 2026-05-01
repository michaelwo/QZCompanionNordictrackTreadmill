using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.View;
using AndroidX.Core.Widget;
using Google.Android.Material.Animation;
using Google.Android.Material.Behavior;
using Google.Android.Material.Expandable;
using Google.Android.Material.Internal;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "d2f57032c10cc4c7cec18644b0c88598d9de9516")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20200605.2")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "6/5/2020 10:54:02 AM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "com.google.android.material.animation", Managed = "Google.Android.Material.Animation")]
[assembly: NamespaceMapping(Java = "com.google.android.material.appbar", Managed = "Google.Android.Material.AppBar")]
[assembly: NamespaceMapping(Java = "com.google.android.material.behavior", Managed = "Google.Android.Material.Behavior")]
[assembly: NamespaceMapping(Java = "com.google.android.material.bottomappbar", Managed = "Google.Android.Material.BottomAppBar")]
[assembly: NamespaceMapping(Java = "com.google.android.material.bottomnavigation", Managed = "Google.Android.Material.BottomNavigation")]
[assembly: NamespaceMapping(Java = "com.google.android.material.bottomsheet", Managed = "Google.Android.Material.BottomSheet")]
[assembly: NamespaceMapping(Java = "com.google.android.material.button", Managed = "Google.Android.Material.Button")]
[assembly: NamespaceMapping(Java = "com.google.android.material.canvas", Managed = "Google.Android.Material.Canvas")]
[assembly: NamespaceMapping(Java = "com.google.android.material.card", Managed = "Google.Android.Material.Card")]
[assembly: NamespaceMapping(Java = "com.google.android.material.chip", Managed = "Google.Android.Material.Chip")]
[assembly: NamespaceMapping(Java = "com.google.android.material.circularreveal", Managed = "Google.Android.Material.CircularReveal")]
[assembly: NamespaceMapping(Java = "com.google.android.material.circularreveal.cardview", Managed = "Google.Android.Material.CircularReveal.CardView")]
[assembly: NamespaceMapping(Java = "com.google.android.material.circularreveal.coordinatorlayout", Managed = "Google.Android.Material.CircularReveal.CoordinatorLayout")]
[assembly: NamespaceMapping(Java = "com.google.android.material.drawable", Managed = "Google.Android.Material.Drawable")]
[assembly: NamespaceMapping(Java = "com.google.android.material.expandable", Managed = "Google.Android.Material.Expandable")]
[assembly: NamespaceMapping(Java = "com.google.android.material.floatingactionbutton", Managed = "Google.Android.Material.FloatingActionButton")]
[assembly: NamespaceMapping(Java = "com.google.android.material.internal", Managed = "Google.Android.Material.Internal")]
[assembly: NamespaceMapping(Java = "com.google.android.material.math", Managed = "Google.Android.Material.Math")]
[assembly: NamespaceMapping(Java = "com.google.android.material.navigation", Managed = "Google.Android.Material.Navigation")]
[assembly: NamespaceMapping(Java = "com.google.android.material.resources", Managed = "Google.Android.Material.Resources")]
[assembly: NamespaceMapping(Java = "com.google.android.material.ripple", Managed = "Google.Android.Material.Ripple")]
[assembly: NamespaceMapping(Java = "com.google.android.material.shadow", Managed = "Google.Android.Material.Shadow")]
[assembly: NamespaceMapping(Java = "com.google.android.material.shape", Managed = "Google.Android.Material.Shape")]
[assembly: NamespaceMapping(Java = "com.google.android.material.snackbar", Managed = "Google.Android.Material.Snackbar")]
[assembly: NamespaceMapping(Java = "com.google.android.material.stateful", Managed = "Google.Android.Material.Stateful")]
[assembly: NamespaceMapping(Java = "com.google.android.material.tabs", Managed = "Google.Android.Material.Tabs")]
[assembly: NamespaceMapping(Java = "com.google.android.material.textfield", Managed = "Google.Android.Material.TextField")]
[assembly: NamespaceMapping(Java = "com.google.android.material.theme", Managed = "Google.Android.Material.Theme")]
[assembly: NamespaceMapping(Java = "com.google.android.material.transformation", Managed = "Google.Android.Material.Transformation")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - material")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Android.Material")]
[assembly: AssemblyTitle("Xamarin.Google.Android.Material")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Google.Android.Material.FloatingActionButton
{
	[Register("com/google/android/material/floatingactionbutton/FloatingActionButton", DoNotGenerateAcw = true)]
	public class FloatingActionButton : VisibilityAwareImageButton, ITintableBackgroundView, IJavaObject, IDisposable, IJavaPeerable, ITintableImageSourceView, IExpandableTransformationWidget, IExpandableWidget
	{
		[Register("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", DoNotGenerateAcw = true)]
		public abstract class OnVisibilityChangedListener : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", typeof(OnVisibilityChangedListener));

			private static Delegate cb_onHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_;

			private static Delegate cb_onShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected OnVisibilityChangedListener(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe OnVisibilityChangedListener()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler()
			{
				if ((object)cb_onHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_ == null)
				{
					cb_onHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_));
				}
				return cb_onHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_;
			}

			private static void n_OnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_(IntPtr jnienv, IntPtr native__this, IntPtr native_fab)
			{
				OnVisibilityChangedListener onVisibilityChangedListener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
				onVisibilityChangedListener.OnHidden(fab);
			}

			[Register("onHidden", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", "GetOnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler")]
			public unsafe virtual void OnHidden(FloatingActionButton fab)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fab?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onHidden.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", this, ptr);
			}

			private static Delegate GetOnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler()
			{
				if ((object)cb_onShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_ == null)
				{
					cb_onShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_));
				}
				return cb_onShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_;
			}

			private static void n_OnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_(IntPtr jnienv, IntPtr native__this, IntPtr native_fab)
			{
				OnVisibilityChangedListener onVisibilityChangedListener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
				onVisibilityChangedListener.OnShown(fab);
			}

			[Register("onShown", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", "GetOnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler")]
			public unsafe virtual void OnShown(FloatingActionButton fab)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fab?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onShown.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", this, ptr);
			}
		}

		[Register("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", DoNotGenerateAcw = true)]
		internal class OnVisibilityChangedListenerInvoker : OnVisibilityChangedListener
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", typeof(OnVisibilityChangedListenerInvoker));

			public override JniPeerMembers JniPeerMembers => _members;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public OnVisibilityChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton", typeof(FloatingActionButton));

		private static Delegate cb_getCompatElevation;

		private static Delegate cb_setCompatElevation_F;

		private static Delegate cb_getCompatHoveredFocusedTranslationZ;

		private static Delegate cb_setCompatHoveredFocusedTranslationZ_F;

		private static Delegate cb_getCompatPressedTranslationZ;

		private static Delegate cb_setCompatPressedTranslationZ_F;

		private static Delegate cb_getContentBackground;

		private static Delegate cb_getCustomSize;

		private static Delegate cb_setCustomSize_I;

		private static Delegate cb_getExpandedComponentIdHint;

		private static Delegate cb_setExpandedComponentIdHint_I;

		private static Delegate cb_getHideMotionSpec;

		private static Delegate cb_setHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_;

		private static Delegate cb_isExpanded;

		private static Delegate cb_isOrWillBeHidden;

		private static Delegate cb_isOrWillBeShown;

		private static Delegate cb_getRippleColor;

		private static Delegate cb_setRippleColor_I;

		private static Delegate cb_getRippleColorStateList;

		private static Delegate cb_getShowMotionSpec;

		private static Delegate cb_setShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_;

		private static Delegate cb_getSize;

		private static Delegate cb_setSize_I;

		private static Delegate cb_getSupportBackgroundTintList;

		private static Delegate cb_setSupportBackgroundTintList_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getSupportBackgroundTintMode;

		private static Delegate cb_setSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_;

		private static Delegate cb_getSupportImageTintList;

		private static Delegate cb_setSupportImageTintList_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getSupportImageTintMode;

		private static Delegate cb_setSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_;

		private static Delegate cb_getUseCompatPadding;

		private static Delegate cb_setUseCompatPadding_Z;

		private static Delegate cb_addOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_;

		private static Delegate cb_addOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_;

		private static Delegate cb_clearCustomSize;

		private static Delegate cb_getContentRect_Landroid_graphics_Rect_;

		private static Delegate cb_getMeasuredContentRect_Landroid_graphics_Rect_;

		private static Delegate cb_hide;

		private static Delegate cb_hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_;

		private static Delegate cb_removeOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_;

		private static Delegate cb_removeOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_;

		private static Delegate cb_setCompatElevationResource_I;

		private static Delegate cb_setCompatHoveredFocusedTranslationZResource_I;

		private static Delegate cb_setCompatPressedTranslationZResource_I;

		private static Delegate cb_setExpanded_Z;

		private static Delegate cb_setHideMotionSpecResource_I;

		private static Delegate cb_setRippleColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_setShowMotionSpecResource_I;

		private static Delegate cb_show;

		private static Delegate cb_show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual float CompatElevation
		{
			[Register("getCompatElevation", "()F", "GetGetCompatElevationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatElevation.()F", this, null);
			}
			[Register("setCompatElevation", "(F)V", "GetSetCompatElevation_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatElevation.(F)V", this, ptr);
			}
		}

		public unsafe virtual float CompatHoveredFocusedTranslationZ
		{
			[Register("getCompatHoveredFocusedTranslationZ", "()F", "GetGetCompatHoveredFocusedTranslationZHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatHoveredFocusedTranslationZ.()F", this, null);
			}
			[Register("setCompatHoveredFocusedTranslationZ", "(F)V", "GetSetCompatHoveredFocusedTranslationZ_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatHoveredFocusedTranslationZ.(F)V", this, ptr);
			}
		}

		public unsafe virtual float CompatPressedTranslationZ
		{
			[Register("getCompatPressedTranslationZ", "()F", "GetGetCompatPressedTranslationZHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatPressedTranslationZ.()F", this, null);
			}
			[Register("setCompatPressedTranslationZ", "(F)V", "GetSetCompatPressedTranslationZ_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatPressedTranslationZ.(F)V", this, ptr);
			}
		}

		public unsafe virtual Drawable ContentBackground
		{
			[Register("getContentBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetContentBackgroundHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int CustomSize
		{
			[Register("getCustomSize", "()I", "GetGetCustomSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCustomSize.()I", this, null);
			}
			[Register("setCustomSize", "(I)V", "GetSetCustomSize_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomSize.(I)V", this, ptr);
			}
		}

		public unsafe virtual int ExpandedComponentIdHint
		{
			[Register("getExpandedComponentIdHint", "()I", "GetGetExpandedComponentIdHintHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getExpandedComponentIdHint.()I", this, null);
			}
			[Register("setExpandedComponentIdHint", "(I)V", "GetSetExpandedComponentIdHint_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setExpandedComponentIdHint.(I)V", this, ptr);
			}
		}

		public unsafe virtual MotionSpec HideMotionSpec
		{
			[Register("getHideMotionSpec", "()Lcom/google/android/material/animation/MotionSpec;", "GetGetHideMotionSpecHandler")]
			get
			{
				return Java.Lang.Object.GetObject<MotionSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHideMotionSpec.()Lcom/google/android/material/animation/MotionSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setHideMotionSpec", "(Lcom/google/android/material/animation/MotionSpec;)V", "GetSetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHideMotionSpec.(Lcom/google/android/material/animation/MotionSpec;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual bool IsExpanded
		{
			[Register("isExpanded", "()Z", "GetIsExpandedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isExpanded.()Z", this, null);
			}
		}

		public unsafe virtual bool IsOrWillBeHidden
		{
			[Register("isOrWillBeHidden", "()Z", "GetIsOrWillBeHiddenHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOrWillBeHidden.()Z", this, null);
			}
		}

		public unsafe virtual bool IsOrWillBeShown
		{
			[Register("isOrWillBeShown", "()Z", "GetIsOrWillBeShownHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOrWillBeShown.()Z", this, null);
			}
		}

		public unsafe virtual int RippleColor
		{
			[Register("getRippleColor", "()I", "GetGetRippleColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRippleColor.()I", this, null);
			}
			[Register("setRippleColor", "(I)V", "GetSetRippleColor_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(I)V", this, ptr);
			}
		}

		public unsafe virtual ColorStateList RippleColorStateList
		{
			[Register("getRippleColorStateList", "()Landroid/content/res/ColorStateList;", "GetGetRippleColorStateListHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRippleColorStateList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual MotionSpec ShowMotionSpec
		{
			[Register("getShowMotionSpec", "()Lcom/google/android/material/animation/MotionSpec;", "GetGetShowMotionSpecHandler")]
			get
			{
				return Java.Lang.Object.GetObject<MotionSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShowMotionSpec.()Lcom/google/android/material/animation/MotionSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setShowMotionSpec", "(Lcom/google/android/material/animation/MotionSpec;)V", "GetSetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShowMotionSpec.(Lcom/google/android/material/animation/MotionSpec;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual int Size
		{
			[Register("getSize", "()I", "GetGetSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSize.()I", this, null);
			}
			[Register("setSize", "(I)V", "GetSetSize_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSize.(I)V", this, ptr);
			}
		}

		public unsafe virtual ColorStateList SupportBackgroundTintList
		{
			[Register("getSupportBackgroundTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportBackgroundTintListHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSupportBackgroundTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual PorterDuff.Mode SupportBackgroundTintMode
		{
			[Register("getSupportBackgroundTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportBackgroundTintModeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSupportBackgroundTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual ColorStateList SupportImageTintList
		{
			[Register("getSupportImageTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportImageTintListHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportImageTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSupportImageTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportImageTintList_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportImageTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual PorterDuff.Mode SupportImageTintMode
		{
			[Register("getSupportImageTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportImageTintModeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportImageTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setSupportImageTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportImageTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual bool UseCompatPadding
		{
			[Register("getUseCompatPadding", "()Z", "GetGetUseCompatPaddingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUseCompatPadding.()Z", this, null);
			}
			[Register("setUseCompatPadding", "(Z)V", "GetSetUseCompatPadding_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setUseCompatPadding.(Z)V", this, ptr);
			}
		}

		protected FloatingActionButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe FloatingActionButton(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe FloatingActionButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe FloatingActionButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetCompatElevationHandler()
		{
			if ((object)cb_getCompatElevation == null)
			{
				cb_getCompatElevation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetCompatElevation));
			}
			return cb_getCompatElevation;
		}

		private static float n_GetCompatElevation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatElevation;
		}

		private static Delegate GetSetCompatElevation_FHandler()
		{
			if ((object)cb_setCompatElevation_F == null)
			{
				cb_setCompatElevation_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetCompatElevation_F));
			}
			return cb_setCompatElevation_F;
		}

		private static void n_SetCompatElevation_F(IntPtr jnienv, IntPtr native__this, float elevation)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatElevation = elevation;
		}

		private static Delegate GetGetCompatHoveredFocusedTranslationZHandler()
		{
			if ((object)cb_getCompatHoveredFocusedTranslationZ == null)
			{
				cb_getCompatHoveredFocusedTranslationZ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetCompatHoveredFocusedTranslationZ));
			}
			return cb_getCompatHoveredFocusedTranslationZ;
		}

		private static float n_GetCompatHoveredFocusedTranslationZ(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatHoveredFocusedTranslationZ;
		}

		private static Delegate GetSetCompatHoveredFocusedTranslationZ_FHandler()
		{
			if ((object)cb_setCompatHoveredFocusedTranslationZ_F == null)
			{
				cb_setCompatHoveredFocusedTranslationZ_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetCompatHoveredFocusedTranslationZ_F));
			}
			return cb_setCompatHoveredFocusedTranslationZ_F;
		}

		private static void n_SetCompatHoveredFocusedTranslationZ_F(IntPtr jnienv, IntPtr native__this, float translationZ)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatHoveredFocusedTranslationZ = translationZ;
		}

		private static Delegate GetGetCompatPressedTranslationZHandler()
		{
			if ((object)cb_getCompatPressedTranslationZ == null)
			{
				cb_getCompatPressedTranslationZ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetCompatPressedTranslationZ));
			}
			return cb_getCompatPressedTranslationZ;
		}

		private static float n_GetCompatPressedTranslationZ(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatPressedTranslationZ;
		}

		private static Delegate GetSetCompatPressedTranslationZ_FHandler()
		{
			if ((object)cb_setCompatPressedTranslationZ_F == null)
			{
				cb_setCompatPressedTranslationZ_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetCompatPressedTranslationZ_F));
			}
			return cb_setCompatPressedTranslationZ_F;
		}

		private static void n_SetCompatPressedTranslationZ_F(IntPtr jnienv, IntPtr native__this, float translationZ)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatPressedTranslationZ = translationZ;
		}

		private static Delegate GetGetContentBackgroundHandler()
		{
			if ((object)cb_getContentBackground == null)
			{
				cb_getContentBackground = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetContentBackground));
			}
			return cb_getContentBackground;
		}

		private static IntPtr n_GetContentBackground(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentBackground);
		}

		private static Delegate GetGetCustomSizeHandler()
		{
			if ((object)cb_getCustomSize == null)
			{
				cb_getCustomSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCustomSize));
			}
			return cb_getCustomSize;
		}

		private static int n_GetCustomSize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomSize;
		}

		private static Delegate GetSetCustomSize_IHandler()
		{
			if ((object)cb_setCustomSize_I == null)
			{
				cb_setCustomSize_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCustomSize_I));
			}
			return cb_setCustomSize_I;
		}

		private static void n_SetCustomSize_I(IntPtr jnienv, IntPtr native__this, int size)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomSize = size;
		}

		private static Delegate GetGetExpandedComponentIdHintHandler()
		{
			if ((object)cb_getExpandedComponentIdHint == null)
			{
				cb_getExpandedComponentIdHint = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetExpandedComponentIdHint));
			}
			return cb_getExpandedComponentIdHint;
		}

		private static int n_GetExpandedComponentIdHint(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint;
		}

		private static Delegate GetSetExpandedComponentIdHint_IHandler()
		{
			if ((object)cb_setExpandedComponentIdHint_I == null)
			{
				cb_setExpandedComponentIdHint_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetExpandedComponentIdHint_I));
			}
			return cb_setExpandedComponentIdHint_I;
		}

		private static void n_SetExpandedComponentIdHint_I(IntPtr jnienv, IntPtr native__this, int expandedComponentIdHint)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint = expandedComponentIdHint;
		}

		private static Delegate GetGetHideMotionSpecHandler()
		{
			if ((object)cb_getHideMotionSpec == null)
			{
				cb_getHideMotionSpec = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetHideMotionSpec));
			}
			return cb_getHideMotionSpec;
		}

		private static IntPtr n_GetHideMotionSpec(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideMotionSpec);
		}

		private static Delegate GetSetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler()
		{
			if ((object)cb_setHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_ == null)
			{
				cb_setHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_));
			}
			return cb_setHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_;
		}

		private static void n_SetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_(IntPtr jnienv, IntPtr native__this, IntPtr native_spec)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionSpec hideMotionSpec = Java.Lang.Object.GetObject<MotionSpec>(native_spec, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.HideMotionSpec = hideMotionSpec;
		}

		private static Delegate GetIsExpandedHandler()
		{
			if ((object)cb_isExpanded == null)
			{
				cb_isExpanded = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsExpanded));
			}
			return cb_isExpanded;
		}

		private static bool n_IsExpanded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExpanded;
		}

		private static Delegate GetIsOrWillBeHiddenHandler()
		{
			if ((object)cb_isOrWillBeHidden == null)
			{
				cb_isOrWillBeHidden = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsOrWillBeHidden));
			}
			return cb_isOrWillBeHidden;
		}

		private static bool n_IsOrWillBeHidden(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOrWillBeHidden;
		}

		private static Delegate GetIsOrWillBeShownHandler()
		{
			if ((object)cb_isOrWillBeShown == null)
			{
				cb_isOrWillBeShown = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsOrWillBeShown));
			}
			return cb_isOrWillBeShown;
		}

		private static bool n_IsOrWillBeShown(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOrWillBeShown;
		}

		private static Delegate GetGetRippleColorHandler()
		{
			if ((object)cb_getRippleColor == null)
			{
				cb_getRippleColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetRippleColor));
			}
			return cb_getRippleColor;
		}

		private static int n_GetRippleColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor;
		}

		private static Delegate GetSetRippleColor_IHandler()
		{
			if ((object)cb_setRippleColor_I == null)
			{
				cb_setRippleColor_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetRippleColor_I));
			}
			return cb_setRippleColor_I;
		}

		private static void n_SetRippleColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor = color;
		}

		private static Delegate GetGetRippleColorStateListHandler()
		{
			if ((object)cb_getRippleColorStateList == null)
			{
				cb_getRippleColorStateList = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetRippleColorStateList));
			}
			return cb_getRippleColorStateList;
		}

		private static IntPtr n_GetRippleColorStateList(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColorStateList);
		}

		private static Delegate GetGetShowMotionSpecHandler()
		{
			if ((object)cb_getShowMotionSpec == null)
			{
				cb_getShowMotionSpec = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetShowMotionSpec));
			}
			return cb_getShowMotionSpec;
		}

		private static IntPtr n_GetShowMotionSpec(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowMotionSpec);
		}

		private static Delegate GetSetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler()
		{
			if ((object)cb_setShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_ == null)
			{
				cb_setShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_));
			}
			return cb_setShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_;
		}

		private static void n_SetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_(IntPtr jnienv, IntPtr native__this, IntPtr native_spec)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionSpec showMotionSpec = Java.Lang.Object.GetObject<MotionSpec>(native_spec, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShowMotionSpec = showMotionSpec;
		}

		private static Delegate GetGetSizeHandler()
		{
			if ((object)cb_getSize == null)
			{
				cb_getSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetSize));
			}
			return cb_getSize;
		}

		private static int n_GetSize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size;
		}

		private static Delegate GetSetSize_IHandler()
		{
			if ((object)cb_setSize_I == null)
			{
				cb_setSize_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetSize_I));
			}
			return cb_setSize_I;
		}

		private static void n_SetSize_I(IntPtr jnienv, IntPtr native__this, int size)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size = size;
		}

		private static Delegate GetGetSupportBackgroundTintListHandler()
		{
			if ((object)cb_getSupportBackgroundTintList == null)
			{
				cb_getSupportBackgroundTintList = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSupportBackgroundTintList));
			}
			return cb_getSupportBackgroundTintList;
		}

		private static IntPtr n_GetSupportBackgroundTintList(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintList);
		}

		private static Delegate GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setSupportBackgroundTintList_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setSupportBackgroundTintList_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_));
			}
			return cb_setSupportBackgroundTintList_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_tint)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportBackgroundTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportBackgroundTintList = supportBackgroundTintList;
		}

		private static Delegate GetGetSupportBackgroundTintModeHandler()
		{
			if ((object)cb_getSupportBackgroundTintMode == null)
			{
				cb_getSupportBackgroundTintMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSupportBackgroundTintMode));
			}
			return cb_getSupportBackgroundTintMode;
		}

		private static IntPtr n_GetSupportBackgroundTintMode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintMode);
		}

		private static Delegate GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
		{
			if ((object)cb_setSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_ == null)
			{
				cb_setSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_));
			}
			return cb_setSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_;
		}

		private static void n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_tintMode)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportBackgroundTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportBackgroundTintMode = supportBackgroundTintMode;
		}

		private static Delegate GetGetSupportImageTintListHandler()
		{
			if ((object)cb_getSupportImageTintList == null)
			{
				cb_getSupportImageTintList = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSupportImageTintList));
			}
			return cb_getSupportImageTintList;
		}

		private static IntPtr n_GetSupportImageTintList(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportImageTintList);
		}

		private static Delegate GetSetSupportImageTintList_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setSupportImageTintList_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setSupportImageTintList_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetSupportImageTintList_Landroid_content_res_ColorStateList_));
			}
			return cb_setSupportImageTintList_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetSupportImageTintList_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_tint)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportImageTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportImageTintList = supportImageTintList;
		}

		private static Delegate GetGetSupportImageTintModeHandler()
		{
			if ((object)cb_getSupportImageTintMode == null)
			{
				cb_getSupportImageTintMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSupportImageTintMode));
			}
			return cb_getSupportImageTintMode;
		}

		private static IntPtr n_GetSupportImageTintMode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportImageTintMode);
		}

		private static Delegate GetSetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
		{
			if ((object)cb_setSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_ == null)
			{
				cb_setSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_));
			}
			return cb_setSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_;
		}

		private static void n_SetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_tintMode)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportImageTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportImageTintMode = supportImageTintMode;
		}

		private static Delegate GetGetUseCompatPaddingHandler()
		{
			if ((object)cb_getUseCompatPadding == null)
			{
				cb_getUseCompatPadding = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_GetUseCompatPadding));
			}
			return cb_getUseCompatPadding;
		}

		private static bool n_GetUseCompatPadding(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding;
		}

		private static Delegate GetSetUseCompatPadding_ZHandler()
		{
			if ((object)cb_setUseCompatPadding_Z == null)
			{
				cb_setUseCompatPadding_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetUseCompatPadding_Z));
			}
			return cb_setUseCompatPadding_Z;
		}

		private static void n_SetUseCompatPadding_Z(IntPtr jnienv, IntPtr native__this, bool useCompatPadding)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding = useCompatPadding;
		}

		private static Delegate GetAddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
		{
			if ((object)cb_addOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_ == null)
			{
				cb_addOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_));
			}
			return cb_addOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_;
		}

		private static void n_AddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.AddOnHideAnimationListener(listener);
		}

		[Register("addOnHideAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetAddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
		public unsafe virtual void AddOnHideAnimationListener(Animator.IAnimatorListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnHideAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetAddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
		{
			if ((object)cb_addOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_ == null)
			{
				cb_addOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_));
			}
			return cb_addOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_;
		}

		private static void n_AddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.AddOnShowAnimationListener(listener);
		}

		[Register("addOnShowAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetAddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
		public unsafe virtual void AddOnShowAnimationListener(Animator.IAnimatorListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnShowAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetClearCustomSizeHandler()
		{
			if ((object)cb_clearCustomSize == null)
			{
				cb_clearCustomSize = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_ClearCustomSize));
			}
			return cb_clearCustomSize;
		}

		private static void n_ClearCustomSize(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearCustomSize();
		}

		[Register("clearCustomSize", "()V", "GetClearCustomSizeHandler")]
		public unsafe virtual void ClearCustomSize()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearCustomSize.()V", this, null);
		}

		private static Delegate GetGetContentRect_Landroid_graphics_Rect_Handler()
		{
			if ((object)cb_getContentRect_Landroid_graphics_Rect_ == null)
			{
				cb_getContentRect_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_GetContentRect_Landroid_graphics_Rect_));
			}
			return cb_getContentRect_Landroid_graphics_Rect_;
		}

		private static bool n_GetContentRect_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_rect)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.GetContentRect(rect);
		}

		[Register("getContentRect", "(Landroid/graphics/Rect;)Z", "GetGetContentRect_Landroid_graphics_Rect_Handler")]
		public unsafe virtual bool GetContentRect(Rect rect)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("getContentRect.(Landroid/graphics/Rect;)Z", this, ptr);
			GC.KeepAlive(rect);
			return result;
		}

		private static Delegate GetGetMeasuredContentRect_Landroid_graphics_Rect_Handler()
		{
			if ((object)cb_getMeasuredContentRect_Landroid_graphics_Rect_ == null)
			{
				cb_getMeasuredContentRect_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_GetMeasuredContentRect_Landroid_graphics_Rect_));
			}
			return cb_getMeasuredContentRect_Landroid_graphics_Rect_;
		}

		private static void n_GetMeasuredContentRect_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_rect)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.GetMeasuredContentRect(rect);
		}

		[Register("getMeasuredContentRect", "(Landroid/graphics/Rect;)V", "GetGetMeasuredContentRect_Landroid_graphics_Rect_Handler")]
		public unsafe virtual void GetMeasuredContentRect(Rect rect)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getMeasuredContentRect.(Landroid/graphics/Rect;)V", this, ptr);
			GC.KeepAlive(rect);
		}

		private static Delegate GetHideHandler()
		{
			if ((object)cb_hide == null)
			{
				cb_hide = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Hide));
			}
			return cb_hide;
		}

		private static void n_Hide(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hide();
		}

		[Register("hide", "()V", "GetHideHandler")]
		public unsafe virtual void Hide()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("hide.()V", this, null);
		}

		private static Delegate GetHide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler()
		{
			if ((object)cb_hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_ == null)
			{
				cb_hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_));
			}
			return cb_hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_;
		}

		private static void n_Hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnVisibilityChangedListener listener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Hide(listener);
		}

		[Register("hide", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", "GetHide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler")]
		public unsafe virtual void Hide(OnVisibilityChangedListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("hide.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetRemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
		{
			if ((object)cb_removeOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_ == null)
			{
				cb_removeOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_));
			}
			return cb_removeOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_;
		}

		private static void n_RemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.RemoveOnHideAnimationListener(listener);
		}

		[Register("removeOnHideAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetRemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
		public unsafe virtual void RemoveOnHideAnimationListener(Animator.IAnimatorListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnHideAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetRemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
		{
			if ((object)cb_removeOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_ == null)
			{
				cb_removeOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_));
			}
			return cb_removeOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_;
		}

		private static void n_RemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.RemoveOnShowAnimationListener(listener);
		}

		[Register("removeOnShowAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetRemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
		public unsafe virtual void RemoveOnShowAnimationListener(Animator.IAnimatorListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnShowAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetSetCompatElevationResource_IHandler()
		{
			if ((object)cb_setCompatElevationResource_I == null)
			{
				cb_setCompatElevationResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCompatElevationResource_I));
			}
			return cb_setCompatElevationResource_I;
		}

		private static void n_SetCompatElevationResource_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatElevationResource(id);
		}

		[Register("setCompatElevationResource", "(I)V", "GetSetCompatElevationResource_IHandler")]
		public unsafe virtual void SetCompatElevationResource(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatElevationResource.(I)V", this, ptr);
		}

		private static Delegate GetSetCompatHoveredFocusedTranslationZResource_IHandler()
		{
			if ((object)cb_setCompatHoveredFocusedTranslationZResource_I == null)
			{
				cb_setCompatHoveredFocusedTranslationZResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCompatHoveredFocusedTranslationZResource_I));
			}
			return cb_setCompatHoveredFocusedTranslationZResource_I;
		}

		private static void n_SetCompatHoveredFocusedTranslationZResource_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatHoveredFocusedTranslationZResource(id);
		}

		[Register("setCompatHoveredFocusedTranslationZResource", "(I)V", "GetSetCompatHoveredFocusedTranslationZResource_IHandler")]
		public unsafe virtual void SetCompatHoveredFocusedTranslationZResource(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatHoveredFocusedTranslationZResource.(I)V", this, ptr);
		}

		private static Delegate GetSetCompatPressedTranslationZResource_IHandler()
		{
			if ((object)cb_setCompatPressedTranslationZResource_I == null)
			{
				cb_setCompatPressedTranslationZResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCompatPressedTranslationZResource_I));
			}
			return cb_setCompatPressedTranslationZResource_I;
		}

		private static void n_SetCompatPressedTranslationZResource_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatPressedTranslationZResource(id);
		}

		[Register("setCompatPressedTranslationZResource", "(I)V", "GetSetCompatPressedTranslationZResource_IHandler")]
		public unsafe virtual void SetCompatPressedTranslationZResource(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatPressedTranslationZResource.(I)V", this, ptr);
		}

		private static Delegate GetSetExpanded_ZHandler()
		{
			if ((object)cb_setExpanded_Z == null)
			{
				cb_setExpanded_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_SetExpanded_Z));
			}
			return cb_setExpanded_Z;
		}

		private static bool n_SetExpanded_Z(IntPtr jnienv, IntPtr native__this, bool expanded)
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExpanded(expanded);
		}

		[Register("setExpanded", "(Z)Z", "GetSetExpanded_ZHandler")]
		public unsafe virtual bool SetExpanded(bool expanded)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(expanded);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setExpanded.(Z)Z", this, ptr);
		}

		private static Delegate GetSetHideMotionSpecResource_IHandler()
		{
			if ((object)cb_setHideMotionSpecResource_I == null)
			{
				cb_setHideMotionSpecResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetHideMotionSpecResource_I));
			}
			return cb_setHideMotionSpecResource_I;
		}

		private static void n_SetHideMotionSpecResource_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHideMotionSpecResource(id);
		}

		[Register("setHideMotionSpecResource", "(I)V", "GetSetHideMotionSpecResource_IHandler")]
		public unsafe virtual void SetHideMotionSpecResource(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHideMotionSpecResource.(I)V", this, ptr);
		}

		private static Delegate GetSetRippleColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setRippleColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setRippleColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetRippleColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setRippleColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetRippleColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_color)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList rippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetRippleColor(rippleColor);
		}

		[Register("setRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetRippleColor_Landroid_content_res_ColorStateList_Handler")]
		public unsafe virtual void SetRippleColor(ColorStateList color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			GC.KeepAlive(color);
		}

		private static Delegate GetSetShowMotionSpecResource_IHandler()
		{
			if ((object)cb_setShowMotionSpecResource_I == null)
			{
				cb_setShowMotionSpecResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetShowMotionSpecResource_I));
			}
			return cb_setShowMotionSpecResource_I;
		}

		private static void n_SetShowMotionSpecResource_I(IntPtr jnienv, IntPtr native__this, int id)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShowMotionSpecResource(id);
		}

		[Register("setShowMotionSpecResource", "(I)V", "GetSetShowMotionSpecResource_IHandler")]
		public unsafe virtual void SetShowMotionSpecResource(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowMotionSpecResource.(I)V", this, ptr);
		}

		private static Delegate GetShowHandler()
		{
			if ((object)cb_show == null)
			{
				cb_show = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Show));
			}
			return cb_show;
		}

		private static void n_Show(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
		}

		[Register("show", "()V", "GetShowHandler")]
		public unsafe virtual void Show()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
		}

		private static Delegate GetShow_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler()
		{
			if ((object)cb_show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_ == null)
			{
				cb_show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_));
			}
			return cb_show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_;
		}

		private static void n_Show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			FloatingActionButton floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnVisibilityChangedListener listener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Show(listener);
		}

		[Register("show", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", "GetShow_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler")]
		public unsafe virtual void Show(OnVisibilityChangedListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}
	}
}
namespace Google.Android.Material.Expandable
{
	[Register("com/google/android/material/expandable/ExpandableTransformationWidget", "", "Google.Android.Material.Expandable.IExpandableTransformationWidgetInvoker")]
	public interface IExpandableTransformationWidget : IExpandableWidget, IJavaObject, IDisposable, IJavaPeerable
	{
		int ExpandedComponentIdHint
		{
			[Register("getExpandedComponentIdHint", "()I", "GetGetExpandedComponentIdHintHandler:Google.Android.Material.Expandable.IExpandableTransformationWidgetInvoker, Xamarin.Google.Android.Material")]
			get;
			[Register("setExpandedComponentIdHint", "(I)V", "GetSetExpandedComponentIdHint_IHandler:Google.Android.Material.Expandable.IExpandableTransformationWidgetInvoker, Xamarin.Google.Android.Material")]
			set;
		}
	}
	[Register("com/google/android/material/expandable/ExpandableTransformationWidget", DoNotGenerateAcw = true)]
	internal class IExpandableTransformationWidgetInvoker : Java.Lang.Object, IExpandableTransformationWidget, IExpandableWidget, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/expandable/ExpandableTransformationWidget", typeof(IExpandableTransformationWidgetInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getExpandedComponentIdHint;

		private static Delegate cb_setExpandedComponentIdHint_I;

		private IntPtr id_getExpandedComponentIdHint;

		private IntPtr id_setExpandedComponentIdHint_I;

		private static Delegate cb_isExpanded;

		private IntPtr id_isExpanded;

		private static Delegate cb_setExpanded_Z;

		private IntPtr id_setExpanded_Z;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int ExpandedComponentIdHint
		{
			get
			{
				if (id_getExpandedComponentIdHint == IntPtr.Zero)
				{
					id_getExpandedComponentIdHint = JNIEnv.GetMethodID(class_ref, "getExpandedComponentIdHint", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getExpandedComponentIdHint);
			}
			set
			{
				if (id_setExpandedComponentIdHint_I == IntPtr.Zero)
				{
					id_setExpandedComponentIdHint_I = JNIEnv.GetMethodID(class_ref, "setExpandedComponentIdHint", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(value);
				JNIEnv.CallVoidMethod(base.Handle, id_setExpandedComponentIdHint_I, ptr);
			}
		}

		public bool IsExpanded
		{
			get
			{
				if (id_isExpanded == IntPtr.Zero)
				{
					id_isExpanded = JNIEnv.GetMethodID(class_ref, "isExpanded", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isExpanded);
			}
		}

		public static IExpandableTransformationWidget GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExpandableTransformationWidget>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.material.expandable.ExpandableTransformationWidget"));
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

		public IExpandableTransformationWidgetInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetExpandedComponentIdHintHandler()
		{
			if ((object)cb_getExpandedComponentIdHint == null)
			{
				cb_getExpandedComponentIdHint = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetExpandedComponentIdHint));
			}
			return cb_getExpandedComponentIdHint;
		}

		private static int n_GetExpandedComponentIdHint(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpandableTransformationWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint;
		}

		private static Delegate GetSetExpandedComponentIdHint_IHandler()
		{
			if ((object)cb_setExpandedComponentIdHint_I == null)
			{
				cb_setExpandedComponentIdHint_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetExpandedComponentIdHint_I));
			}
			return cb_setExpandedComponentIdHint_I;
		}

		private static void n_SetExpandedComponentIdHint_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Java.Lang.Object.GetObject<IExpandableTransformationWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint = p0;
		}

		private static Delegate GetIsExpandedHandler()
		{
			if ((object)cb_isExpanded == null)
			{
				cb_isExpanded = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsExpanded));
			}
			return cb_isExpanded;
		}

		private static bool n_IsExpanded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpandableTransformationWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExpanded;
		}

		private static Delegate GetSetExpanded_ZHandler()
		{
			if ((object)cb_setExpanded_Z == null)
			{
				cb_setExpanded_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_SetExpanded_Z));
			}
			return cb_setExpanded_Z;
		}

		private static bool n_SetExpanded_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return Java.Lang.Object.GetObject<IExpandableTransformationWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExpanded(p0);
		}

		public unsafe bool SetExpanded(bool p0)
		{
			if (id_setExpanded_Z == IntPtr.Zero)
			{
				id_setExpanded_Z = JNIEnv.GetMethodID(class_ref, "setExpanded", "(Z)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			return JNIEnv.CallBooleanMethod(base.Handle, id_setExpanded_Z, ptr);
		}
	}
	[Register("com/google/android/material/expandable/ExpandableWidget", "", "Google.Android.Material.Expandable.IExpandableWidgetInvoker")]
	public interface IExpandableWidget : IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsExpanded
		{
			[Register("isExpanded", "()Z", "GetIsExpandedHandler:Google.Android.Material.Expandable.IExpandableWidgetInvoker, Xamarin.Google.Android.Material")]
			get;
		}

		[Register("setExpanded", "(Z)Z", "GetSetExpanded_ZHandler:Google.Android.Material.Expandable.IExpandableWidgetInvoker, Xamarin.Google.Android.Material")]
		bool SetExpanded(bool p0);
	}
	[Register("com/google/android/material/expandable/ExpandableWidget", DoNotGenerateAcw = true)]
	internal class IExpandableWidgetInvoker : Java.Lang.Object, IExpandableWidget, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/expandable/ExpandableWidget", typeof(IExpandableWidgetInvoker));

		private IntPtr class_ref;

		private static Delegate cb_isExpanded;

		private IntPtr id_isExpanded;

		private static Delegate cb_setExpanded_Z;

		private IntPtr id_setExpanded_Z;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public bool IsExpanded
		{
			get
			{
				if (id_isExpanded == IntPtr.Zero)
				{
					id_isExpanded = JNIEnv.GetMethodID(class_ref, "isExpanded", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isExpanded);
			}
		}

		public static IExpandableWidget GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExpandableWidget>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.material.expandable.ExpandableWidget"));
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

		public IExpandableWidgetInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsExpandedHandler()
		{
			if ((object)cb_isExpanded == null)
			{
				cb_isExpanded = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsExpanded));
			}
			return cb_isExpanded;
		}

		private static bool n_IsExpanded(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExpandableWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExpanded;
		}

		private static Delegate GetSetExpanded_ZHandler()
		{
			if ((object)cb_setExpanded_Z == null)
			{
				cb_setExpanded_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_SetExpanded_Z));
			}
			return cb_setExpanded_Z;
		}

		private static bool n_SetExpanded_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			return Java.Lang.Object.GetObject<IExpandableWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExpanded(p0);
		}

		public unsafe bool SetExpanded(bool p0)
		{
			if (id_setExpanded_Z == IntPtr.Zero)
			{
				id_setExpanded_Z = JNIEnv.GetMethodID(class_ref, "setExpanded", "(Z)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			return JNIEnv.CallBooleanMethod(base.Handle, id_setExpanded_Z, ptr);
		}
	}
}
namespace Google.Android.Material.Button
{
	[Register("com/google/android/material/button/MaterialButton", DoNotGenerateAcw = true)]
	public class MaterialButton : AppCompatButton
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/button/MaterialButton", typeof(MaterialButton));

		private static Delegate cb_getCornerRadius;

		private static Delegate cb_setCornerRadius_I;

		private static Delegate cb_getIcon;

		private static Delegate cb_setIcon_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_getIconGravity;

		private static Delegate cb_setIconGravity_I;

		private static Delegate cb_getIconPadding;

		private static Delegate cb_setIconPadding_I;

		private static Delegate cb_getIconSize;

		private static Delegate cb_setIconSize_I;

		private static Delegate cb_getIconTint;

		private static Delegate cb_setIconTint_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getIconTintMode;

		private static Delegate cb_setIconTintMode_Landroid_graphics_PorterDuff_Mode_;

		private static Delegate cb_getRippleColor;

		private static Delegate cb_setRippleColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getStrokeColor;

		private static Delegate cb_setStrokeColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getStrokeWidth;

		private static Delegate cb_setStrokeWidth_I;

		private static Delegate cb_setCornerRadiusResource_I;

		private static Delegate cb_setIconResource_I;

		private static Delegate cb_setIconTintResource_I;

		private static Delegate cb_setRippleColorResource_I;

		private static Delegate cb_setStrokeColorResource_I;

		private static Delegate cb_setStrokeWidthResource_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int CornerRadius
		{
			[Register("getCornerRadius", "()I", "GetGetCornerRadiusHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCornerRadius.()I", this, null);
			}
			[Register("setCornerRadius", "(I)V", "GetSetCornerRadius_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadius.(I)V", this, ptr);
			}
		}

		public unsafe virtual Drawable Icon
		{
			[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual int IconGravity
		{
			[Register("getIconGravity", "()I", "GetGetIconGravityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getIconGravity.()I", this, null);
			}
			[Register("setIconGravity", "(I)V", "GetSetIconGravity_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconGravity.(I)V", this, ptr);
			}
		}

		public unsafe virtual int IconPadding
		{
			[Register("getIconPadding", "()I", "GetGetIconPaddingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getIconPadding.()I", this, null);
			}
			[Register("setIconPadding", "(I)V", "GetSetIconPadding_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconPadding.(I)V", this, ptr);
			}
		}

		public unsafe virtual int IconSize
		{
			[Register("getIconSize", "()I", "GetGetIconSizeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getIconSize.()I", this, null);
			}
			[Register("setIconSize", "(I)V", "GetSetIconSize_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconSize.(I)V", this, ptr);
			}
		}

		public unsafe virtual ColorStateList IconTint
		{
			[Register("getIconTint", "()Landroid/content/res/ColorStateList;", "GetGetIconTintHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTint.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIconTint", "(Landroid/content/res/ColorStateList;)V", "GetSetIconTint_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTint.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual PorterDuff.Mode IconTintMode
		{
			[Register("getIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetIconTintModeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual ColorStateList RippleColor
		{
			[Register("getRippleColor", "()Landroid/content/res/ColorStateList;", "GetGetRippleColorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRippleColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetRippleColor_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual ColorStateList StrokeColor
		{
			[Register("getStrokeColor", "()Landroid/content/res/ColorStateList;", "GetGetStrokeColorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrokeColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStrokeColor", "(Landroid/content/res/ColorStateList;)V", "GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual int StrokeWidth
		{
			[Register("getStrokeWidth", "()I", "GetGetStrokeWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getStrokeWidth.()I", this, null);
			}
			[Register("setStrokeWidth", "(I)V", "GetSetStrokeWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidth.(I)V", this, ptr);
			}
		}

		protected MaterialButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe MaterialButton(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe MaterialButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe MaterialButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetCornerRadiusHandler()
		{
			if ((object)cb_getCornerRadius == null)
			{
				cb_getCornerRadius = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCornerRadius));
			}
			return cb_getCornerRadius;
		}

		private static int n_GetCornerRadius(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CornerRadius;
		}

		private static Delegate GetSetCornerRadius_IHandler()
		{
			if ((object)cb_setCornerRadius_I == null)
			{
				cb_setCornerRadius_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCornerRadius_I));
			}
			return cb_setCornerRadius_I;
		}

		private static void n_SetCornerRadius_I(IntPtr jnienv, IntPtr native__this, int cornerRadius)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CornerRadius = cornerRadius;
		}

		private static Delegate GetGetIconHandler()
		{
			if ((object)cb_getIcon == null)
			{
				cb_getIcon = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetIcon));
			}
			return cb_getIcon;
		}

		private static IntPtr n_GetIcon(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Icon);
		}

		private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setIcon_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setIcon_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIcon_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setIcon_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_icon)
		{
			MaterialButton materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			materialButton.Icon = icon;
		}

		private static Delegate GetGetIconGravityHandler()
		{
			if ((object)cb_getIconGravity == null)
			{
				cb_getIconGravity = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetIconGravity));
			}
			return cb_getIconGravity;
		}

		private static int n_GetIconGravity(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconGravity;
		}

		private static Delegate GetSetIconGravity_IHandler()
		{
			if ((object)cb_setIconGravity_I == null)
			{
				cb_setIconGravity_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetIconGravity_I));
			}
			return cb_setIconGravity_I;
		}

		private static void n_SetIconGravity_I(IntPtr jnienv, IntPtr native__this, int iconGravity)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconGravity = iconGravity;
		}

		private static Delegate GetGetIconPaddingHandler()
		{
			if ((object)cb_getIconPadding == null)
			{
				cb_getIconPadding = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetIconPadding));
			}
			return cb_getIconPadding;
		}

		private static int n_GetIconPadding(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconPadding;
		}

		private static Delegate GetSetIconPadding_IHandler()
		{
			if ((object)cb_setIconPadding_I == null)
			{
				cb_setIconPadding_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetIconPadding_I));
			}
			return cb_setIconPadding_I;
		}

		private static void n_SetIconPadding_I(IntPtr jnienv, IntPtr native__this, int iconPadding)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconPadding = iconPadding;
		}

		private static Delegate GetGetIconSizeHandler()
		{
			if ((object)cb_getIconSize == null)
			{
				cb_getIconSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetIconSize));
			}
			return cb_getIconSize;
		}

		private static int n_GetIconSize(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconSize;
		}

		private static Delegate GetSetIconSize_IHandler()
		{
			if ((object)cb_setIconSize_I == null)
			{
				cb_setIconSize_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetIconSize_I));
			}
			return cb_setIconSize_I;
		}

		private static void n_SetIconSize_I(IntPtr jnienv, IntPtr native__this, int iconSize)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconSize = iconSize;
		}

		private static Delegate GetGetIconTintHandler()
		{
			if ((object)cb_getIconTint == null)
			{
				cb_getIconTint = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetIconTint));
			}
			return cb_getIconTint;
		}

		private static IntPtr n_GetIconTint(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTint);
		}

		private static Delegate GetSetIconTint_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setIconTint_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setIconTint_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconTint_Landroid_content_res_ColorStateList_));
			}
			return cb_setIconTint_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetIconTint_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_iconTint)
		{
			MaterialButton materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList iconTint = Java.Lang.Object.GetObject<ColorStateList>(native_iconTint, JniHandleOwnership.DoNotTransfer);
			materialButton.IconTint = iconTint;
		}

		private static Delegate GetGetIconTintModeHandler()
		{
			if ((object)cb_getIconTintMode == null)
			{
				cb_getIconTintMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetIconTintMode));
			}
			return cb_getIconTintMode;
		}

		private static IntPtr n_GetIconTintMode(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintMode);
		}

		private static Delegate GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
		{
			if ((object)cb_setIconTintMode_Landroid_graphics_PorterDuff_Mode_ == null)
			{
				cb_setIconTintMode_Landroid_graphics_PorterDuff_Mode_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_));
			}
			return cb_setIconTintMode_Landroid_graphics_PorterDuff_Mode_;
		}

		private static void n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_iconTintMode)
		{
			MaterialButton materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode iconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_iconTintMode, JniHandleOwnership.DoNotTransfer);
			materialButton.IconTintMode = iconTintMode;
		}

		private static Delegate GetGetRippleColorHandler()
		{
			if ((object)cb_getRippleColor == null)
			{
				cb_getRippleColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetRippleColor));
			}
			return cb_getRippleColor;
		}

		private static IntPtr n_GetRippleColor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor);
		}

		private static Delegate GetSetRippleColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setRippleColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setRippleColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetRippleColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setRippleColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetRippleColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_rippleColor)
		{
			MaterialButton materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList rippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_rippleColor, JniHandleOwnership.DoNotTransfer);
			materialButton.RippleColor = rippleColor;
		}

		private static Delegate GetGetStrokeColorHandler()
		{
			if ((object)cb_getStrokeColor == null)
			{
				cb_getStrokeColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetStrokeColor));
			}
			return cb_getStrokeColor;
		}

		private static IntPtr n_GetStrokeColor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColor);
		}

		private static Delegate GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setStrokeColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setStrokeColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetStrokeColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setStrokeColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetStrokeColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_strokeColor)
		{
			MaterialButton materialButton = Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeColor, JniHandleOwnership.DoNotTransfer);
			materialButton.StrokeColor = strokeColor;
		}

		private static Delegate GetGetStrokeWidthHandler()
		{
			if ((object)cb_getStrokeWidth == null)
			{
				cb_getStrokeWidth = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetStrokeWidth));
			}
			return cb_getStrokeWidth;
		}

		private static int n_GetStrokeWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth;
		}

		private static Delegate GetSetStrokeWidth_IHandler()
		{
			if ((object)cb_setStrokeWidth_I == null)
			{
				cb_setStrokeWidth_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetStrokeWidth_I));
			}
			return cb_setStrokeWidth_I;
		}

		private static void n_SetStrokeWidth_I(IntPtr jnienv, IntPtr native__this, int strokeWidth)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = strokeWidth;
		}

		private static Delegate GetSetCornerRadiusResource_IHandler()
		{
			if ((object)cb_setCornerRadiusResource_I == null)
			{
				cb_setCornerRadiusResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCornerRadiusResource_I));
			}
			return cb_setCornerRadiusResource_I;
		}

		private static void n_SetCornerRadiusResource_I(IntPtr jnienv, IntPtr native__this, int cornerRadiusResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCornerRadiusResource(cornerRadiusResourceId);
		}

		[Register("setCornerRadiusResource", "(I)V", "GetSetCornerRadiusResource_IHandler")]
		public unsafe virtual void SetCornerRadiusResource(int cornerRadiusResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerRadiusResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerRadiusResource.(I)V", this, ptr);
		}

		private static Delegate GetSetIconResource_IHandler()
		{
			if ((object)cb_setIconResource_I == null)
			{
				cb_setIconResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetIconResource_I));
			}
			return cb_setIconResource_I;
		}

		private static void n_SetIconResource_I(IntPtr jnienv, IntPtr native__this, int iconResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconResource(iconResourceId);
		}

		[Register("setIconResource", "(I)V", "GetSetIconResource_IHandler")]
		public unsafe virtual void SetIconResource(int iconResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconResource.(I)V", this, ptr);
		}

		private static Delegate GetSetIconTintResource_IHandler()
		{
			if ((object)cb_setIconTintResource_I == null)
			{
				cb_setIconTintResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetIconTintResource_I));
			}
			return cb_setIconTintResource_I;
		}

		private static void n_SetIconTintResource_I(IntPtr jnienv, IntPtr native__this, int iconTintResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconTintResource(iconTintResourceId);
		}

		[Register("setIconTintResource", "(I)V", "GetSetIconTintResource_IHandler")]
		public unsafe virtual void SetIconTintResource(int iconTintResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconTintResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintResource.(I)V", this, ptr);
		}

		private static Delegate GetSetRippleColorResource_IHandler()
		{
			if ((object)cb_setRippleColorResource_I == null)
			{
				cb_setRippleColorResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetRippleColorResource_I));
			}
			return cb_setRippleColorResource_I;
		}

		private static void n_SetRippleColorResource_I(IntPtr jnienv, IntPtr native__this, int rippleColorResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRippleColorResource(rippleColorResourceId);
		}

		[Register("setRippleColorResource", "(I)V", "GetSetRippleColorResource_IHandler")]
		public unsafe virtual void SetRippleColorResource(int rippleColorResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rippleColorResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColorResource.(I)V", this, ptr);
		}

		private static Delegate GetSetStrokeColorResource_IHandler()
		{
			if ((object)cb_setStrokeColorResource_I == null)
			{
				cb_setStrokeColorResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetStrokeColorResource_I));
			}
			return cb_setStrokeColorResource_I;
		}

		private static void n_SetStrokeColorResource_I(IntPtr jnienv, IntPtr native__this, int strokeColorResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeColorResource(strokeColorResourceId);
		}

		[Register("setStrokeColorResource", "(I)V", "GetSetStrokeColorResource_IHandler")]
		public unsafe virtual void SetStrokeColorResource(int strokeColorResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strokeColorResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColorResource.(I)V", this, ptr);
		}

		private static Delegate GetSetStrokeWidthResource_IHandler()
		{
			if ((object)cb_setStrokeWidthResource_I == null)
			{
				cb_setStrokeWidthResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetStrokeWidthResource_I));
			}
			return cb_setStrokeWidthResource_I;
		}

		private static void n_SetStrokeWidthResource_I(IntPtr jnienv, IntPtr native__this, int strokeWidthResourceId)
		{
			Java.Lang.Object.GetObject<MaterialButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeWidthResource(strokeWidthResourceId);
		}

		[Register("setStrokeWidthResource", "(I)V", "GetSetStrokeWidthResource_IHandler")]
		public unsafe virtual void SetStrokeWidthResource(int strokeWidthResourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strokeWidthResourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidthResource.(I)V", this, ptr);
		}
	}
}
namespace Google.Android.Material.Behavior
{
	[Register("com/google/android/material/behavior/SwipeDismissBehavior", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "V extends android.view.View" })]
	public class SwipeDismissBehavior : CoordinatorLayout.Behavior
	{
		[Register("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", "", "Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker")]
		public interface IOnDismissListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onDismiss", "(Landroid/view/View;)V", "GetOnDismiss_Landroid_view_View_Handler:Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker, Xamarin.Google.Android.Material")]
			void OnDismiss(View view);

			[Register("onDragStateChanged", "(I)V", "GetOnDragStateChanged_IHandler:Google.Android.Material.Behavior.SwipeDismissBehavior/IOnDismissListenerInvoker, Xamarin.Google.Android.Material")]
			void OnDragStateChanged(int state);
		}

		[Register("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", DoNotGenerateAcw = true)]
		internal class IOnDismissListenerInvoker : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener", typeof(IOnDismissListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onDismiss_Landroid_view_View_;

			private IntPtr id_onDismiss_Landroid_view_View_;

			private static Delegate cb_onDragStateChanged_I;

			private IntPtr id_onDragStateChanged_I;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOnDismissListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnDismissListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.material.behavior.SwipeDismissBehavior.OnDismissListener"));
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

			public IOnDismissListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnDismiss_Landroid_view_View_Handler()
			{
				if ((object)cb_onDismiss_Landroid_view_View_ == null)
				{
					cb_onDismiss_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnDismiss_Landroid_view_View_));
				}
				return cb_onDismiss_Landroid_view_View_;
			}

			private static void n_OnDismiss_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
			{
				IOnDismissListener onDismissListener = Java.Lang.Object.GetObject<IOnDismissListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onDismissListener.OnDismiss(view);
			}

			public unsafe void OnDismiss(View view)
			{
				if (id_onDismiss_Landroid_view_View_ == IntPtr.Zero)
				{
					id_onDismiss_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onDismiss", "(Landroid/view/View;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(view?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onDismiss_Landroid_view_View_, ptr);
			}

			private static Delegate GetOnDragStateChanged_IHandler()
			{
				if ((object)cb_onDragStateChanged_I == null)
				{
					cb_onDragStateChanged_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_OnDragStateChanged_I));
				}
				return cb_onDragStateChanged_I;
			}

			private static void n_OnDragStateChanged_I(IntPtr jnienv, IntPtr native__this, int state)
			{
				Java.Lang.Object.GetObject<IOnDismissListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDragStateChanged(state);
			}

			public unsafe void OnDragStateChanged(int state)
			{
				if (id_onDragStateChanged_I == IntPtr.Zero)
				{
					id_onDragStateChanged_I = JNIEnv.GetMethodID(class_ref, "onDragStateChanged", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(state);
				JNIEnv.CallVoidMethod(base.Handle, id_onDragStateChanged_I, ptr);
			}
		}

		public class DismissEventArgs : EventArgs
		{
			private View view;

			public DismissEventArgs(View view)
			{
				this.view = view;
			}
		}

		public class DragStateChangedEventArgs : EventArgs
		{
			private int state;

			public DragStateChangedEventArgs(int state)
			{
				this.state = state;
			}
		}

		[Register("mono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor")]
		internal sealed class IOnDismissListenerImplementor : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<DismissEventArgs> OnDismissHandler;

			public EventHandler<DragStateChangedEventArgs> OnDragStateChangedHandler;

			public IOnDismissListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnDismiss(View view)
			{
				OnDismissHandler?.Invoke(sender, new DismissEventArgs(view));
			}

			public void OnDragStateChanged(int state)
			{
				OnDragStateChangedHandler?.Invoke(sender, new DragStateChangedEventArgs(state));
			}

			internal static bool __IsEmpty(IOnDismissListenerImplementor value)
			{
				if (value.OnDismissHandler == null)
				{
					return value.OnDragStateChangedHandler == null;
				}
				return false;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/behavior/SwipeDismissBehavior", typeof(SwipeDismissBehavior));

		private static Delegate cb_getDragState;

		private static Delegate cb_canSwipeDismissView_Landroid_view_View_;

		private static Delegate cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;

		private static Delegate cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;

		private static Delegate cb_setDragDismissDistance_F;

		private static Delegate cb_setEndAlphaSwipeDistance_F;

		private static Delegate cb_setListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_;

		private static Delegate cb_setSensitivity_F;

		private static Delegate cb_setStartAlphaSwipeDistance_F;

		private static Delegate cb_setSwipeDirection_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int DragState
		{
			[Register("getDragState", "()I", "GetGetDragStateHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDragState.()I", this, null);
			}
		}

		protected SwipeDismissBehavior(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SwipeDismissBehavior()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDragStateHandler()
		{
			if ((object)cb_getDragState == null)
			{
				cb_getDragState = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetDragState));
			}
			return cb_getDragState;
		}

		private static int n_GetDragState(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragState;
		}

		private static Delegate GetCanSwipeDismissView_Landroid_view_View_Handler()
		{
			if ((object)cb_canSwipeDismissView_Landroid_view_View_ == null)
			{
				cb_canSwipeDismissView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_CanSwipeDismissView_Landroid_view_View_));
			}
			return cb_canSwipeDismissView_Landroid_view_View_;
		}

		private static bool n_CanSwipeDismissView_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			SwipeDismissBehavior swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.CanSwipeDismissView(view);
		}

		[Register("canSwipeDismissView", "(Landroid/view/View;)Z", "GetCanSwipeDismissView_Landroid_view_View_Handler")]
		public unsafe virtual bool CanSwipeDismissView(View view)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("canSwipeDismissView.(Landroid/view/View;)Z", this, ptr);
			GC.KeepAlive(view);
			return result;
		}

		private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
		{
			if ((object)cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ == null)
			{
				cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, bool>(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_));
			}
			return cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;
		}

		private static bool n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_e)
		{
			SwipeDismissBehavior swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.OnInterceptTouchEvent(parent, child, e);
		}

		[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public new unsafe virtual bool OnInterceptTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				result = _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
			return result;
		}

		private static Delegate GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
		{
			if ((object)cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ == null)
			{
				cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, bool>(n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_));
			}
			return cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;
		}

		private static bool n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_e)
		{
			SwipeDismissBehavior swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return swipeDismissBehavior.OnTouchEvent(parent, child, e);
		}

		[Register("onTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public new unsafe virtual bool OnTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
			bool result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				result = _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(parent);
			GC.KeepAlive(child);
			GC.KeepAlive(e);
			return result;
		}

		private static Delegate GetSetDragDismissDistance_FHandler()
		{
			if ((object)cb_setDragDismissDistance_F == null)
			{
				cb_setDragDismissDistance_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetDragDismissDistance_F));
			}
			return cb_setDragDismissDistance_F;
		}

		private static void n_SetDragDismissDistance_F(IntPtr jnienv, IntPtr native__this, float distance)
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDragDismissDistance(distance);
		}

		[Register("setDragDismissDistance", "(F)V", "GetSetDragDismissDistance_FHandler")]
		public unsafe virtual void SetDragDismissDistance(float distance)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(distance);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDragDismissDistance.(F)V", this, ptr);
		}

		private static Delegate GetSetEndAlphaSwipeDistance_FHandler()
		{
			if ((object)cb_setEndAlphaSwipeDistance_F == null)
			{
				cb_setEndAlphaSwipeDistance_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetEndAlphaSwipeDistance_F));
			}
			return cb_setEndAlphaSwipeDistance_F;
		}

		private static void n_SetEndAlphaSwipeDistance_F(IntPtr jnienv, IntPtr native__this, float fraction)
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEndAlphaSwipeDistance(fraction);
		}

		[Register("setEndAlphaSwipeDistance", "(F)V", "GetSetEndAlphaSwipeDistance_FHandler")]
		public unsafe virtual void SetEndAlphaSwipeDistance(float fraction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fraction);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEndAlphaSwipeDistance.(F)V", this, ptr);
		}

		private static Delegate GetSetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_Handler()
		{
			if ((object)cb_setListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_ == null)
			{
				cb_setListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_));
			}
			return cb_setListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_;
		}

		private static void n_SetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			SwipeDismissBehavior swipeDismissBehavior = Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnDismissListener listener = Java.Lang.Object.GetObject<IOnDismissListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			swipeDismissBehavior.SetListener(listener);
		}

		[Register("setListener", "(Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;)V", "GetSetListener_Lcom_google_android_material_behavior_SwipeDismissBehavior_OnDismissListener_Handler")]
		public unsafe virtual void SetListener(IOnDismissListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setListener.(Lcom/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetSetSensitivity_FHandler()
		{
			if ((object)cb_setSensitivity_F == null)
			{
				cb_setSensitivity_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetSensitivity_F));
			}
			return cb_setSensitivity_F;
		}

		private static void n_SetSensitivity_F(IntPtr jnienv, IntPtr native__this, float sensitivity)
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSensitivity(sensitivity);
		}

		[Register("setSensitivity", "(F)V", "GetSetSensitivity_FHandler")]
		public unsafe virtual void SetSensitivity(float sensitivity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sensitivity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSensitivity.(F)V", this, ptr);
		}

		private static Delegate GetSetStartAlphaSwipeDistance_FHandler()
		{
			if ((object)cb_setStartAlphaSwipeDistance_F == null)
			{
				cb_setStartAlphaSwipeDistance_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetStartAlphaSwipeDistance_F));
			}
			return cb_setStartAlphaSwipeDistance_F;
		}

		private static void n_SetStartAlphaSwipeDistance_F(IntPtr jnienv, IntPtr native__this, float fraction)
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStartAlphaSwipeDistance(fraction);
		}

		[Register("setStartAlphaSwipeDistance", "(F)V", "GetSetStartAlphaSwipeDistance_FHandler")]
		public unsafe virtual void SetStartAlphaSwipeDistance(float fraction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fraction);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartAlphaSwipeDistance.(F)V", this, ptr);
		}

		private static Delegate GetSetSwipeDirection_IHandler()
		{
			if ((object)cb_setSwipeDirection_I == null)
			{
				cb_setSwipeDirection_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetSwipeDirection_I));
			}
			return cb_setSwipeDirection_I;
		}

		private static void n_SetSwipeDirection_I(IntPtr jnienv, IntPtr native__this, int direction)
		{
			Java.Lang.Object.GetObject<SwipeDismissBehavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSwipeDirection(direction);
		}

		[Register("setSwipeDirection", "(I)V", "GetSetSwipeDirection_IHandler")]
		public unsafe virtual void SetSwipeDirection(int direction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(direction);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSwipeDirection.(I)V", this, ptr);
		}

		private IOnDismissListenerImplementor __CreateIOnDismissListenerImplementor()
		{
			return new IOnDismissListenerImplementor(this);
		}
	}
}
namespace Google.Android.Material.TextField
{
	[Register("com/google/android/material/textfield/TextInputLayout", DoNotGenerateAcw = true)]
	public class TextInputLayout : LinearLayout
	{
		[Register("com/google/android/material/textfield/TextInputLayout$AccessibilityDelegate", DoNotGenerateAcw = true)]
		public new class AccessibilityDelegate : AccessibilityDelegateCompat
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout$AccessibilityDelegate", typeof(AccessibilityDelegate));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected AccessibilityDelegate(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lcom/google/android/material/textfield/TextInputLayout;)V", "")]
			public unsafe AccessibilityDelegate(TextInputLayout layout)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/textfield/TextInputLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/textfield/TextInputLayout;)V", this, ptr);
					GC.KeepAlive(layout);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/textfield/TextInputLayout", typeof(TextInputLayout));

		private static Delegate cb_getBoxBackgroundColor;

		private static Delegate cb_setBoxBackgroundColor_I;

		private static Delegate cb_getBoxCornerRadiusBottomEnd;

		private static Delegate cb_getBoxCornerRadiusBottomStart;

		private static Delegate cb_getBoxCornerRadiusTopEnd;

		private static Delegate cb_getBoxCornerRadiusTopStart;

		private static Delegate cb_getBoxStrokeColor;

		private static Delegate cb_setBoxStrokeColor_I;

		private static Delegate cb_isCounterEnabled;

		private static Delegate cb_setCounterEnabled_Z;

		private static Delegate cb_getCounterMaxLength;

		private static Delegate cb_setCounterMaxLength_I;

		private static Delegate cb_getDefaultHintTextColor;

		private static Delegate cb_setDefaultHintTextColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_getEditText;

		private static Delegate cb_getError;

		private static Delegate cb_setError_Ljava_lang_CharSequence_;

		private static Delegate cb_getErrorCurrentTextColors;

		private static Delegate cb_isErrorEnabled;

		private static Delegate cb_setErrorEnabled_Z;

		private static Delegate cb_getHelperText;

		private static Delegate cb_setHelperText_Ljava_lang_CharSequence_;

		private static Delegate cb_getHelperTextCurrentTextColor;

		private static Delegate cb_isHelperTextEnabled;

		private static Delegate cb_setHelperTextEnabled_Z;

		private static Delegate cb_getHint;

		private static Delegate cb_setHint_Ljava_lang_CharSequence_;

		private static Delegate cb_isHintAnimationEnabled;

		private static Delegate cb_setHintAnimationEnabled_Z;

		private static Delegate cb_isHintEnabled;

		private static Delegate cb_setHintEnabled_Z;

		private static Delegate cb_getPasswordVisibilityToggleContentDescription;

		private static Delegate cb_setPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_;

		private static Delegate cb_getPasswordVisibilityToggleDrawable;

		private static Delegate cb_setPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_isPasswordVisibilityToggleEnabled;

		private static Delegate cb_setPasswordVisibilityToggleEnabled_Z;

		private static Delegate cb_getTypeface;

		private static Delegate cb_setTypeface_Landroid_graphics_Typeface_;

		private static Delegate cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_;

		private static Delegate cb_onSaveInstanceState;

		private static Delegate cb_passwordVisibilityToggleRequested_Z;

		private static Delegate cb_setBoxBackgroundColorResource_I;

		private static Delegate cb_setBoxBackgroundMode_I;

		private static Delegate cb_setBoxCornerRadii_FFFF;

		private static Delegate cb_setBoxCornerRadiiResources_IIII;

		private static Delegate cb_setErrorTextAppearance_I;

		private static Delegate cb_setErrorTextColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_setHelperTextColor_Landroid_content_res_ColorStateList_;

		private static Delegate cb_setHelperTextTextAppearance_I;

		private static Delegate cb_setHintTextAppearance_I;

		private static Delegate cb_setPasswordVisibilityToggleContentDescription_I;

		private static Delegate cb_setPasswordVisibilityToggleDrawable_I;

		private static Delegate cb_setPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_;

		private static Delegate cb_setPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_;

		private static Delegate cb_setTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_;

		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int BoxBackgroundColor
		{
			[Register("getBoxBackgroundColor", "()I", "GetGetBoxBackgroundColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxBackgroundColor.()I", this, null);
			}
			[Register("setBoxBackgroundColor", "(I)V", "GetSetBoxBackgroundColor_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundColor.(I)V", this, ptr);
			}
		}

		public unsafe virtual float BoxCornerRadiusBottomEnd
		{
			[Register("getBoxCornerRadiusBottomEnd", "()F", "GetGetBoxCornerRadiusBottomEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusBottomEnd.()F", this, null);
			}
		}

		public unsafe virtual float BoxCornerRadiusBottomStart
		{
			[Register("getBoxCornerRadiusBottomStart", "()F", "GetGetBoxCornerRadiusBottomStartHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusBottomStart.()F", this, null);
			}
		}

		public unsafe virtual float BoxCornerRadiusTopEnd
		{
			[Register("getBoxCornerRadiusTopEnd", "()F", "GetGetBoxCornerRadiusTopEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusTopEnd.()F", this, null);
			}
		}

		public unsafe virtual float BoxCornerRadiusTopStart
		{
			[Register("getBoxCornerRadiusTopStart", "()F", "GetGetBoxCornerRadiusTopStartHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getBoxCornerRadiusTopStart.()F", this, null);
			}
		}

		public unsafe virtual int BoxStrokeColor
		{
			[Register("getBoxStrokeColor", "()I", "GetGetBoxStrokeColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBoxStrokeColor.()I", this, null);
			}
			[Register("setBoxStrokeColor", "(I)V", "GetSetBoxStrokeColor_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxStrokeColor.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool CounterEnabled
		{
			[Register("isCounterEnabled", "()Z", "GetIsCounterEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCounterEnabled.()Z", this, null);
			}
			[Register("setCounterEnabled", "(Z)V", "GetSetCounterEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int CounterMaxLength
		{
			[Register("getCounterMaxLength", "()I", "GetGetCounterMaxLengthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCounterMaxLength.()I", this, null);
			}
			[Register("setCounterMaxLength", "(I)V", "GetSetCounterMaxLength_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCounterMaxLength.(I)V", this, ptr);
			}
		}

		public unsafe virtual ColorStateList DefaultHintTextColor
		{
			[Register("getDefaultHintTextColor", "()Landroid/content/res/ColorStateList;", "GetGetDefaultHintTextColorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultHintTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDefaultHintTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetDefaultHintTextColor_Landroid_content_res_ColorStateList_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDefaultHintTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual EditText EditText
		{
			[Register("getEditText", "()Landroid/widget/EditText;", "GetGetEditTextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<EditText>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEditText.()Landroid/widget/EditText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ICharSequence ErrorFormatted
		{
			[Register("getError", "()Ljava/lang/CharSequence;", "GetGetErrorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getError.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setError", "(Ljava/lang/CharSequence;)V", "GetSetError_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setError.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string Error
		{
			get
			{
				if (ErrorFormatted != null)
				{
					return ErrorFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(ErrorFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual int ErrorCurrentTextColors
		{
			[Register("getErrorCurrentTextColors", "()I", "GetGetErrorCurrentTextColorsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getErrorCurrentTextColors.()I", this, null);
			}
		}

		public unsafe virtual bool ErrorEnabled
		{
			[Register("isErrorEnabled", "()Z", "GetIsErrorEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isErrorEnabled.()Z", this, null);
			}
			[Register("setErrorEnabled", "(Z)V", "GetSetErrorEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual ICharSequence HelperTextFormatted
		{
			[Register("getHelperText", "()Ljava/lang/CharSequence;", "GetGetHelperTextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHelperText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setHelperText", "(Ljava/lang/CharSequence;)V", "GetSetHelperText_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperText.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string HelperText
		{
			get
			{
				if (HelperTextFormatted != null)
				{
					return HelperTextFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(HelperTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual int HelperTextCurrentTextColor
		{
			[Register("getHelperTextCurrentTextColor", "()I", "GetGetHelperTextCurrentTextColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHelperTextCurrentTextColor.()I", this, null);
			}
		}

		public unsafe virtual bool HelperTextEnabled
		{
			[Register("isHelperTextEnabled", "()Z", "GetIsHelperTextEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHelperTextEnabled.()Z", this, null);
			}
			[Register("setHelperTextEnabled", "(Z)V", "GetSetHelperTextEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual ICharSequence HintFormatted
		{
			[Register("getHint", "()Ljava/lang/CharSequence;", "GetGetHintHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHint.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setHint", "(Ljava/lang/CharSequence;)V", "GetSetHint_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setHint.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string Hint
		{
			get
			{
				if (HintFormatted != null)
				{
					return HintFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(HintFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual bool HintAnimationEnabled
		{
			[Register("isHintAnimationEnabled", "()Z", "GetIsHintAnimationEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHintAnimationEnabled.()Z", this, null);
			}
			[Register("setHintAnimationEnabled", "(Z)V", "GetSetHintAnimationEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHintAnimationEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool HintEnabled
		{
			[Register("isHintEnabled", "()Z", "GetIsHintEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHintEnabled.()Z", this, null);
			}
			[Register("setHintEnabled", "(Z)V", "GetSetHintEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHintEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual ICharSequence PasswordVisibilityToggleContentDescriptionFormatted
		{
			[Register("getPasswordVisibilityToggleContentDescription", "()Ljava/lang/CharSequence;", "GetGetPasswordVisibilityToggleContentDescriptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPasswordVisibilityToggleContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPasswordVisibilityToggleContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_Handler")]
			set
			{
				IntPtr intPtr = CharSequence.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		public string PasswordVisibilityToggleContentDescription
		{
			get
			{
				if (PasswordVisibilityToggleContentDescriptionFormatted != null)
				{
					return PasswordVisibilityToggleContentDescriptionFormatted.ToString();
				}
				return null;
			}
			set
			{
				((Java.Lang.Object)(PasswordVisibilityToggleContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
			}
		}

		public unsafe virtual Drawable PasswordVisibilityToggleDrawable
		{
			[Register("getPasswordVisibilityToggleDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetPasswordVisibilityToggleDrawableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPasswordVisibilityToggleDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setPasswordVisibilityToggleDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public unsafe virtual bool PasswordVisibilityToggleEnabled
		{
			[Register("isPasswordVisibilityToggleEnabled", "()Z", "GetIsPasswordVisibilityToggleEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPasswordVisibilityToggleEnabled.()Z", this, null);
			}
			[Register("setPasswordVisibilityToggleEnabled", "(Z)V", "GetSetPasswordVisibilityToggleEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual Typeface Typeface
		{
			[Register("getTypeface", "()Landroid/graphics/Typeface;", "GetGetTypefaceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Typeface>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTypeface.()Landroid/graphics/Typeface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setTypeface", "(Landroid/graphics/Typeface;)V", "GetSetTypeface_Landroid_graphics_Typeface_Handler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTypeface.(Landroid/graphics/Typeface;)V", this, ptr);
				GC.KeepAlive(value);
			}
		}

		public void SetEnabled(bool enabled)
		{
			Enabled = enabled;
		}

		protected TextInputLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe TextInputLayout(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe TextInputLayout(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe TextInputLayout(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetBoxBackgroundColorHandler()
		{
			if ((object)cb_getBoxBackgroundColor == null)
			{
				cb_getBoxBackgroundColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetBoxBackgroundColor));
			}
			return cb_getBoxBackgroundColor;
		}

		private static int n_GetBoxBackgroundColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundColor;
		}

		private static Delegate GetSetBoxBackgroundColor_IHandler()
		{
			if ((object)cb_setBoxBackgroundColor_I == null)
			{
				cb_setBoxBackgroundColor_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetBoxBackgroundColor_I));
			}
			return cb_setBoxBackgroundColor_I;
		}

		private static void n_SetBoxBackgroundColor_I(IntPtr jnienv, IntPtr native__this, int boxBackgroundColor)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxBackgroundColor = boxBackgroundColor;
		}

		private static Delegate GetGetBoxCornerRadiusBottomEndHandler()
		{
			if ((object)cb_getBoxCornerRadiusBottomEnd == null)
			{
				cb_getBoxCornerRadiusBottomEnd = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetBoxCornerRadiusBottomEnd));
			}
			return cb_getBoxCornerRadiusBottomEnd;
		}

		private static float n_GetBoxCornerRadiusBottomEnd(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusBottomEnd;
		}

		private static Delegate GetGetBoxCornerRadiusBottomStartHandler()
		{
			if ((object)cb_getBoxCornerRadiusBottomStart == null)
			{
				cb_getBoxCornerRadiusBottomStart = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetBoxCornerRadiusBottomStart));
			}
			return cb_getBoxCornerRadiusBottomStart;
		}

		private static float n_GetBoxCornerRadiusBottomStart(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusBottomStart;
		}

		private static Delegate GetGetBoxCornerRadiusTopEndHandler()
		{
			if ((object)cb_getBoxCornerRadiusTopEnd == null)
			{
				cb_getBoxCornerRadiusTopEnd = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetBoxCornerRadiusTopEnd));
			}
			return cb_getBoxCornerRadiusTopEnd;
		}

		private static float n_GetBoxCornerRadiusTopEnd(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusTopEnd;
		}

		private static Delegate GetGetBoxCornerRadiusTopStartHandler()
		{
			if ((object)cb_getBoxCornerRadiusTopStart == null)
			{
				cb_getBoxCornerRadiusTopStart = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetBoxCornerRadiusTopStart));
			}
			return cb_getBoxCornerRadiusTopStart;
		}

		private static float n_GetBoxCornerRadiusTopStart(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxCornerRadiusTopStart;
		}

		private static Delegate GetGetBoxStrokeColorHandler()
		{
			if ((object)cb_getBoxStrokeColor == null)
			{
				cb_getBoxStrokeColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetBoxStrokeColor));
			}
			return cb_getBoxStrokeColor;
		}

		private static int n_GetBoxStrokeColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeColor;
		}

		private static Delegate GetSetBoxStrokeColor_IHandler()
		{
			if ((object)cb_setBoxStrokeColor_I == null)
			{
				cb_setBoxStrokeColor_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetBoxStrokeColor_I));
			}
			return cb_setBoxStrokeColor_I;
		}

		private static void n_SetBoxStrokeColor_I(IntPtr jnienv, IntPtr native__this, int boxStrokeColor)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoxStrokeColor = boxStrokeColor;
		}

		private static Delegate GetIsCounterEnabledHandler()
		{
			if ((object)cb_isCounterEnabled == null)
			{
				cb_isCounterEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsCounterEnabled));
			}
			return cb_isCounterEnabled;
		}

		private static bool n_IsCounterEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterEnabled;
		}

		private static Delegate GetSetCounterEnabled_ZHandler()
		{
			if ((object)cb_setCounterEnabled_Z == null)
			{
				cb_setCounterEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetCounterEnabled_Z));
			}
			return cb_setCounterEnabled_Z;
		}

		private static void n_SetCounterEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterEnabled = enabled;
		}

		private static Delegate GetGetCounterMaxLengthHandler()
		{
			if ((object)cb_getCounterMaxLength == null)
			{
				cb_getCounterMaxLength = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCounterMaxLength));
			}
			return cb_getCounterMaxLength;
		}

		private static int n_GetCounterMaxLength(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterMaxLength;
		}

		private static Delegate GetSetCounterMaxLength_IHandler()
		{
			if ((object)cb_setCounterMaxLength_I == null)
			{
				cb_setCounterMaxLength_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetCounterMaxLength_I));
			}
			return cb_setCounterMaxLength_I;
		}

		private static void n_SetCounterMaxLength_I(IntPtr jnienv, IntPtr native__this, int maxLength)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CounterMaxLength = maxLength;
		}

		private static Delegate GetGetDefaultHintTextColorHandler()
		{
			if ((object)cb_getDefaultHintTextColor == null)
			{
				cb_getDefaultHintTextColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetDefaultHintTextColor));
			}
			return cb_getDefaultHintTextColor;
		}

		private static IntPtr n_GetDefaultHintTextColor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultHintTextColor);
		}

		private static Delegate GetSetDefaultHintTextColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setDefaultHintTextColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setDefaultHintTextColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetDefaultHintTextColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setDefaultHintTextColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetDefaultHintTextColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_textColor)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList defaultHintTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_textColor, JniHandleOwnership.DoNotTransfer);
			textInputLayout.DefaultHintTextColor = defaultHintTextColor;
		}

		private static Delegate GetGetEditTextHandler()
		{
			if ((object)cb_getEditText == null)
			{
				cb_getEditText = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetEditText));
			}
			return cb_getEditText;
		}

		private static IntPtr n_GetEditText(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EditText);
		}

		private static Delegate GetGetErrorHandler()
		{
			if ((object)cb_getError == null)
			{
				cb_getError = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetError));
			}
			return cb_getError;
		}

		private static IntPtr n_GetError(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorFormatted);
		}

		private static Delegate GetSetError_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setError_Ljava_lang_CharSequence_ == null)
			{
				cb_setError_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetError_Ljava_lang_CharSequence_));
			}
			return cb_setError_Ljava_lang_CharSequence_;
		}

		private static void n_SetError_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_errorText)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence errorFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_errorText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.ErrorFormatted = errorFormatted;
		}

		private static Delegate GetGetErrorCurrentTextColorsHandler()
		{
			if ((object)cb_getErrorCurrentTextColors == null)
			{
				cb_getErrorCurrentTextColors = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetErrorCurrentTextColors));
			}
			return cb_getErrorCurrentTextColors;
		}

		private static int n_GetErrorCurrentTextColors(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorCurrentTextColors;
		}

		private static Delegate GetIsErrorEnabledHandler()
		{
			if ((object)cb_isErrorEnabled == null)
			{
				cb_isErrorEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsErrorEnabled));
			}
			return cb_isErrorEnabled;
		}

		private static bool n_IsErrorEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorEnabled;
		}

		private static Delegate GetSetErrorEnabled_ZHandler()
		{
			if ((object)cb_setErrorEnabled_Z == null)
			{
				cb_setErrorEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetErrorEnabled_Z));
			}
			return cb_setErrorEnabled_Z;
		}

		private static void n_SetErrorEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorEnabled = enabled;
		}

		private static Delegate GetGetHelperTextHandler()
		{
			if ((object)cb_getHelperText == null)
			{
				cb_getHelperText = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetHelperText));
			}
			return cb_getHelperText;
		}

		private static IntPtr n_GetHelperText(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextFormatted);
		}

		private static Delegate GetSetHelperText_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setHelperText_Ljava_lang_CharSequence_ == null)
			{
				cb_setHelperText_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetHelperText_Ljava_lang_CharSequence_));
			}
			return cb_setHelperText_Ljava_lang_CharSequence_;
		}

		private static void n_SetHelperText_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_helperText)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence helperTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_helperText, JniHandleOwnership.DoNotTransfer);
			textInputLayout.HelperTextFormatted = helperTextFormatted;
		}

		private static Delegate GetGetHelperTextCurrentTextColorHandler()
		{
			if ((object)cb_getHelperTextCurrentTextColor == null)
			{
				cb_getHelperTextCurrentTextColor = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetHelperTextCurrentTextColor));
			}
			return cb_getHelperTextCurrentTextColor;
		}

		private static int n_GetHelperTextCurrentTextColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextCurrentTextColor;
		}

		private static Delegate GetIsHelperTextEnabledHandler()
		{
			if ((object)cb_isHelperTextEnabled == null)
			{
				cb_isHelperTextEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsHelperTextEnabled));
			}
			return cb_isHelperTextEnabled;
		}

		private static bool n_IsHelperTextEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextEnabled;
		}

		private static Delegate GetSetHelperTextEnabled_ZHandler()
		{
			if ((object)cb_setHelperTextEnabled_Z == null)
			{
				cb_setHelperTextEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetHelperTextEnabled_Z));
			}
			return cb_setHelperTextEnabled_Z;
		}

		private static void n_SetHelperTextEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HelperTextEnabled = enabled;
		}

		private static Delegate GetGetHintHandler()
		{
			if ((object)cb_getHint == null)
			{
				cb_getHint = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetHint));
			}
			return cb_getHint;
		}

		private static IntPtr n_GetHint(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintFormatted);
		}

		private static Delegate GetSetHint_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setHint_Ljava_lang_CharSequence_ == null)
			{
				cb_setHint_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetHint_Ljava_lang_CharSequence_));
			}
			return cb_setHint_Ljava_lang_CharSequence_;
		}

		private static void n_SetHint_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_hint)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence hintFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_hint, JniHandleOwnership.DoNotTransfer);
			textInputLayout.HintFormatted = hintFormatted;
		}

		private static Delegate GetIsHintAnimationEnabledHandler()
		{
			if ((object)cb_isHintAnimationEnabled == null)
			{
				cb_isHintAnimationEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsHintAnimationEnabled));
			}
			return cb_isHintAnimationEnabled;
		}

		private static bool n_IsHintAnimationEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintAnimationEnabled;
		}

		private static Delegate GetSetHintAnimationEnabled_ZHandler()
		{
			if ((object)cb_setHintAnimationEnabled_Z == null)
			{
				cb_setHintAnimationEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetHintAnimationEnabled_Z));
			}
			return cb_setHintAnimationEnabled_Z;
		}

		private static void n_SetHintAnimationEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintAnimationEnabled = enabled;
		}

		private static Delegate GetIsHintEnabledHandler()
		{
			if ((object)cb_isHintEnabled == null)
			{
				cb_isHintEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsHintEnabled));
			}
			return cb_isHintEnabled;
		}

		private static bool n_IsHintEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintEnabled;
		}

		private static Delegate GetSetHintEnabled_ZHandler()
		{
			if ((object)cb_setHintEnabled_Z == null)
			{
				cb_setHintEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetHintEnabled_Z));
			}
			return cb_setHintEnabled_Z;
		}

		private static void n_SetHintEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintEnabled = enabled;
		}

		private static Delegate GetGetPasswordVisibilityToggleContentDescriptionHandler()
		{
			if ((object)cb_getPasswordVisibilityToggleContentDescription == null)
			{
				cb_getPasswordVisibilityToggleContentDescription = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetPasswordVisibilityToggleContentDescription));
			}
			return cb_getPasswordVisibilityToggleContentDescription;
		}

		private static IntPtr n_GetPasswordVisibilityToggleContentDescription(IntPtr jnienv, IntPtr native__this)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleContentDescriptionFormatted);
		}

		private static Delegate GetSetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_setPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_ == null)
			{
				cb_setPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_));
			}
			return cb_setPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_;
		}

		private static void n_SetPasswordVisibilityToggleContentDescription_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_description)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence passwordVisibilityToggleContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PasswordVisibilityToggleContentDescriptionFormatted = passwordVisibilityToggleContentDescriptionFormatted;
		}

		private static Delegate GetGetPasswordVisibilityToggleDrawableHandler()
		{
			if ((object)cb_getPasswordVisibilityToggleDrawable == null)
			{
				cb_getPasswordVisibilityToggleDrawable = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetPasswordVisibilityToggleDrawable));
			}
			return cb_getPasswordVisibilityToggleDrawable;
		}

		private static IntPtr n_GetPasswordVisibilityToggleDrawable(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleDrawable);
		}

		private static Delegate GetSetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetPasswordVisibilityToggleDrawable_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_icon)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable passwordVisibilityToggleDrawable = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			textInputLayout.PasswordVisibilityToggleDrawable = passwordVisibilityToggleDrawable;
		}

		private static Delegate GetIsPasswordVisibilityToggleEnabledHandler()
		{
			if ((object)cb_isPasswordVisibilityToggleEnabled == null)
			{
				cb_isPasswordVisibilityToggleEnabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsPasswordVisibilityToggleEnabled));
			}
			return cb_isPasswordVisibilityToggleEnabled;
		}

		private static bool n_IsPasswordVisibilityToggleEnabled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleEnabled;
		}

		private static Delegate GetSetPasswordVisibilityToggleEnabled_ZHandler()
		{
			if ((object)cb_setPasswordVisibilityToggleEnabled_Z == null)
			{
				cb_setPasswordVisibilityToggleEnabled_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetPasswordVisibilityToggleEnabled_Z));
			}
			return cb_setPasswordVisibilityToggleEnabled_Z;
		}

		private static void n_SetPasswordVisibilityToggleEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleEnabled = enabled;
		}

		private static Delegate GetGetTypefaceHandler()
		{
			if ((object)cb_getTypeface == null)
			{
				cb_getTypeface = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetTypeface));
			}
			return cb_getTypeface;
		}

		private static IntPtr n_GetTypeface(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Typeface);
		}

		private static Delegate GetSetTypeface_Landroid_graphics_Typeface_Handler()
		{
			if ((object)cb_setTypeface_Landroid_graphics_Typeface_ == null)
			{
				cb_setTypeface_Landroid_graphics_Typeface_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetTypeface_Landroid_graphics_Typeface_));
			}
			return cb_setTypeface_Landroid_graphics_Typeface_;
		}

		private static void n_SetTypeface_Landroid_graphics_Typeface_(IntPtr jnienv, IntPtr native__this, IntPtr native_typeface)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Typeface typeface = Java.Lang.Object.GetObject<Typeface>(native_typeface, JniHandleOwnership.DoNotTransfer);
			textInputLayout.Typeface = typeface;
		}

		private static Delegate GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler()
		{
			if ((object)cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_ == null)
			{
				cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_DispatchRestoreInstanceState_Landroid_util_SparseArray_));
			}
			return cb_dispatchRestoreInstanceState_Landroid_util_SparseArray_;
		}

		private static void n_DispatchRestoreInstanceState_Landroid_util_SparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			textInputLayout.DispatchRestoreInstanceState(container);
		}

		[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler")]
		protected unsafe override void DispatchRestoreInstanceState(SparseArray container)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
			GC.KeepAlive(container);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
		}

		[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
		public new unsafe virtual IParcelable OnSaveInstanceState()
		{
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPasswordVisibilityToggleRequested_ZHandler()
		{
			if ((object)cb_passwordVisibilityToggleRequested_Z == null)
			{
				cb_passwordVisibilityToggleRequested_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_PasswordVisibilityToggleRequested_Z));
			}
			return cb_passwordVisibilityToggleRequested_Z;
		}

		private static void n_PasswordVisibilityToggleRequested_Z(IntPtr jnienv, IntPtr native__this, bool shouldSkipAnimations)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PasswordVisibilityToggleRequested(shouldSkipAnimations);
		}

		[Register("passwordVisibilityToggleRequested", "(Z)V", "GetPasswordVisibilityToggleRequested_ZHandler")]
		public unsafe virtual void PasswordVisibilityToggleRequested(bool shouldSkipAnimations)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shouldSkipAnimations);
			_members.InstanceMethods.InvokeVirtualVoidMethod("passwordVisibilityToggleRequested.(Z)V", this, ptr);
		}

		private static Delegate GetSetBoxBackgroundColorResource_IHandler()
		{
			if ((object)cb_setBoxBackgroundColorResource_I == null)
			{
				cb_setBoxBackgroundColorResource_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetBoxBackgroundColorResource_I));
			}
			return cb_setBoxBackgroundColorResource_I;
		}

		private static void n_SetBoxBackgroundColorResource_I(IntPtr jnienv, IntPtr native__this, int boxBackgroundColorId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxBackgroundColorResource(boxBackgroundColorId);
		}

		[Register("setBoxBackgroundColorResource", "(I)V", "GetSetBoxBackgroundColorResource_IHandler")]
		public unsafe virtual void SetBoxBackgroundColorResource(int boxBackgroundColorId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(boxBackgroundColorId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundColorResource.(I)V", this, ptr);
		}

		private static Delegate GetSetBoxBackgroundMode_IHandler()
		{
			if ((object)cb_setBoxBackgroundMode_I == null)
			{
				cb_setBoxBackgroundMode_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetBoxBackgroundMode_I));
			}
			return cb_setBoxBackgroundMode_I;
		}

		private static void n_SetBoxBackgroundMode_I(IntPtr jnienv, IntPtr native__this, int boxBackgroundMode)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxBackgroundMode(boxBackgroundMode);
		}

		[Register("setBoxBackgroundMode", "(I)V", "GetSetBoxBackgroundMode_IHandler")]
		public unsafe virtual void SetBoxBackgroundMode(int boxBackgroundMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(boxBackgroundMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxBackgroundMode.(I)V", this, ptr);
		}

		private static Delegate GetSetBoxCornerRadii_FFFFHandler()
		{
			if ((object)cb_setBoxCornerRadii_FFFF == null)
			{
				cb_setBoxCornerRadii_FFFF = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, float, float, float>(n_SetBoxCornerRadii_FFFF));
			}
			return cb_setBoxCornerRadii_FFFF;
		}

		private static void n_SetBoxCornerRadii_FFFF(IntPtr jnienv, IntPtr native__this, float boxCornerRadiusTopStart, float boxCornerRadiusTopEnd, float boxCornerRadiusBottomStart, float boxCornerRadiusBottomEnd)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxCornerRadii(boxCornerRadiusTopStart, boxCornerRadiusTopEnd, boxCornerRadiusBottomStart, boxCornerRadiusBottomEnd);
		}

		[Register("setBoxCornerRadii", "(FFFF)V", "GetSetBoxCornerRadii_FFFFHandler")]
		public unsafe virtual void SetBoxCornerRadii(float boxCornerRadiusTopStart, float boxCornerRadiusTopEnd, float boxCornerRadiusBottomStart, float boxCornerRadiusBottomEnd)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(boxCornerRadiusTopStart);
			ptr[1] = new JniArgumentValue(boxCornerRadiusTopEnd);
			ptr[2] = new JniArgumentValue(boxCornerRadiusBottomStart);
			ptr[3] = new JniArgumentValue(boxCornerRadiusBottomEnd);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCornerRadii.(FFFF)V", this, ptr);
		}

		private static Delegate GetSetBoxCornerRadiiResources_IIIIHandler()
		{
			if ((object)cb_setBoxCornerRadiiResources_IIII == null)
			{
				cb_setBoxCornerRadiiResources_IIII = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int, int, int>(n_SetBoxCornerRadiiResources_IIII));
			}
			return cb_setBoxCornerRadiiResources_IIII;
		}

		private static void n_SetBoxCornerRadiiResources_IIII(IntPtr jnienv, IntPtr native__this, int boxCornerRadiusTopStartId, int boxCornerRadiusTopEndId, int boxCornerRadiusBottomEndId, int boxCornerRadiusBottomStartId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBoxCornerRadiiResources(boxCornerRadiusTopStartId, boxCornerRadiusTopEndId, boxCornerRadiusBottomEndId, boxCornerRadiusBottomStartId);
		}

		[Register("setBoxCornerRadiiResources", "(IIII)V", "GetSetBoxCornerRadiiResources_IIIIHandler")]
		public unsafe virtual void SetBoxCornerRadiiResources(int boxCornerRadiusTopStartId, int boxCornerRadiusTopEndId, int boxCornerRadiusBottomEndId, int boxCornerRadiusBottomStartId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(boxCornerRadiusTopStartId);
			ptr[1] = new JniArgumentValue(boxCornerRadiusTopEndId);
			ptr[2] = new JniArgumentValue(boxCornerRadiusBottomEndId);
			ptr[3] = new JniArgumentValue(boxCornerRadiusBottomStartId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoxCornerRadiiResources.(IIII)V", this, ptr);
		}

		private static Delegate GetSetErrorTextAppearance_IHandler()
		{
			if ((object)cb_setErrorTextAppearance_I == null)
			{
				cb_setErrorTextAppearance_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetErrorTextAppearance_I));
			}
			return cb_setErrorTextAppearance_I;
		}

		private static void n_SetErrorTextAppearance_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetErrorTextAppearance(resId);
		}

		[Register("setErrorTextAppearance", "(I)V", "GetSetErrorTextAppearance_IHandler")]
		public unsafe virtual void SetErrorTextAppearance(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorTextAppearance.(I)V", this, ptr);
		}

		private static Delegate GetSetErrorTextColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setErrorTextColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setErrorTextColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetErrorTextColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setErrorTextColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetErrorTextColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_textColors)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList errorTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_textColors, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetErrorTextColor(errorTextColor);
		}

		[Register("setErrorTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetErrorTextColor_Landroid_content_res_ColorStateList_Handler")]
		public unsafe virtual void SetErrorTextColor(ColorStateList textColors)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textColors?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setErrorTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			GC.KeepAlive(textColors);
		}

		private static Delegate GetSetHelperTextColor_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setHelperTextColor_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setHelperTextColor_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetHelperTextColor_Landroid_content_res_ColorStateList_));
			}
			return cb_setHelperTextColor_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetHelperTextColor_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_textColors)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList helperTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_textColors, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetHelperTextColor(helperTextColor);
		}

		[Register("setHelperTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetHelperTextColor_Landroid_content_res_ColorStateList_Handler")]
		public unsafe virtual void SetHelperTextColor(ColorStateList textColors)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(textColors?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			GC.KeepAlive(textColors);
		}

		private static Delegate GetSetHelperTextTextAppearance_IHandler()
		{
			if ((object)cb_setHelperTextTextAppearance_I == null)
			{
				cb_setHelperTextTextAppearance_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetHelperTextTextAppearance_I));
			}
			return cb_setHelperTextTextAppearance_I;
		}

		private static void n_SetHelperTextTextAppearance_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHelperTextTextAppearance(resId);
		}

		[Register("setHelperTextTextAppearance", "(I)V", "GetSetHelperTextTextAppearance_IHandler")]
		public unsafe virtual void SetHelperTextTextAppearance(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHelperTextTextAppearance.(I)V", this, ptr);
		}

		private static Delegate GetSetHintTextAppearance_IHandler()
		{
			if ((object)cb_setHintTextAppearance_I == null)
			{
				cb_setHintTextAppearance_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetHintTextAppearance_I));
			}
			return cb_setHintTextAppearance_I;
		}

		private static void n_SetHintTextAppearance_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHintTextAppearance(resId);
		}

		[Register("setHintTextAppearance", "(I)V", "GetSetHintTextAppearance_IHandler")]
		public unsafe virtual void SetHintTextAppearance(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHintTextAppearance.(I)V", this, ptr);
		}

		private static Delegate GetSetPasswordVisibilityToggleContentDescription_IHandler()
		{
			if ((object)cb_setPasswordVisibilityToggleContentDescription_I == null)
			{
				cb_setPasswordVisibilityToggleContentDescription_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetPasswordVisibilityToggleContentDescription_I));
			}
			return cb_setPasswordVisibilityToggleContentDescription_I;
		}

		private static void n_SetPasswordVisibilityToggleContentDescription_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPasswordVisibilityToggleContentDescription(resId);
		}

		[Register("setPasswordVisibilityToggleContentDescription", "(I)V", "GetSetPasswordVisibilityToggleContentDescription_IHandler")]
		public unsafe virtual void SetPasswordVisibilityToggleContentDescription(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleContentDescription.(I)V", this, ptr);
		}

		private static Delegate GetSetPasswordVisibilityToggleDrawable_IHandler()
		{
			if ((object)cb_setPasswordVisibilityToggleDrawable_I == null)
			{
				cb_setPasswordVisibilityToggleDrawable_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetPasswordVisibilityToggleDrawable_I));
			}
			return cb_setPasswordVisibilityToggleDrawable_I;
		}

		private static void n_SetPasswordVisibilityToggleDrawable_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPasswordVisibilityToggleDrawable(resId);
		}

		[Register("setPasswordVisibilityToggleDrawable", "(I)V", "GetSetPasswordVisibilityToggleDrawable_IHandler")]
		public unsafe virtual void SetPasswordVisibilityToggleDrawable(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleDrawable.(I)V", this, ptr);
		}

		private static Delegate GetSetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_Handler()
		{
			if ((object)cb_setPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_ == null)
			{
				cb_setPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_));
			}
			return cb_setPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_;
		}

		private static void n_SetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_(IntPtr jnienv, IntPtr native__this, IntPtr native_tintList)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList passwordVisibilityToggleTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tintList, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetPasswordVisibilityToggleTintList(passwordVisibilityToggleTintList);
		}

		[Register("setPasswordVisibilityToggleTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetPasswordVisibilityToggleTintList_Landroid_content_res_ColorStateList_Handler")]
		public unsafe virtual void SetPasswordVisibilityToggleTintList(ColorStateList tintList)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			GC.KeepAlive(tintList);
		}

		private static Delegate GetSetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
		{
			if ((object)cb_setPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_ == null)
			{
				cb_setPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_));
			}
			return cb_setPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_;
		}

		private static void n_SetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_(IntPtr jnienv, IntPtr native__this, IntPtr native_mode)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode passwordVisibilityToggleTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_mode, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetPasswordVisibilityToggleTintMode(passwordVisibilityToggleTintMode);
		}

		[Register("setPasswordVisibilityToggleTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetPasswordVisibilityToggleTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		public unsafe virtual void SetPasswordVisibilityToggleTintMode(PorterDuff.Mode mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPasswordVisibilityToggleTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			GC.KeepAlive(mode);
		}

		private static Delegate GetSetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_Handler()
		{
			if ((object)cb_setTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_ == null)
			{
				cb_setTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_));
			}
			return cb_setTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_;
		}

		private static void n_SetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_(IntPtr jnienv, IntPtr native__this, IntPtr native__delegate)
		{
			TextInputLayout textInputLayout = Java.Lang.Object.GetObject<TextInputLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityDelegate textInputAccessibilityDelegate = Java.Lang.Object.GetObject<AccessibilityDelegate>(native__delegate, JniHandleOwnership.DoNotTransfer);
			textInputLayout.SetTextInputAccessibilityDelegate(textInputAccessibilityDelegate);
		}

		[Register("setTextInputAccessibilityDelegate", "(Lcom/google/android/material/textfield/TextInputLayout$AccessibilityDelegate;)V", "GetSetTextInputAccessibilityDelegate_Lcom_google_android_material_textfield_TextInputLayout_AccessibilityDelegate_Handler")]
		public unsafe virtual void SetTextInputAccessibilityDelegate(AccessibilityDelegate @delegate)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextInputAccessibilityDelegate.(Lcom/google/android/material/textfield/TextInputLayout$AccessibilityDelegate;)V", this, ptr);
			GC.KeepAlive(@delegate);
		}
	}
}
namespace Google.Android.Material.Snackbar
{
	[Register("com/google/android/material/snackbar/Snackbar", DoNotGenerateAcw = true)]
	public sealed class Snackbar : BaseTransientBottomBar
	{
		internal class SnackbarActionClickImplementor : Java.Lang.Object, View.IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private Action<View> handler;

			public SnackbarActionClickImplementor(Action<View> handler)
			{
				this.handler = handler;
			}

			public void OnClick(View v)
			{
				handler?.Invoke(v);
			}
		}

		[Register("com/google/android/material/snackbar/Snackbar$Callback", DoNotGenerateAcw = true)]
		public class Callback : BaseCallback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/Snackbar$Callback", typeof(Callback));

			private static Delegate cb_onDismissed_Lcom_google_android_material_snackbar_Snackbar_I;

			private static Delegate cb_onShown_Lcom_google_android_material_snackbar_Snackbar_;

			internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Callback(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Callback()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnDismissed_Lcom_google_android_material_snackbar_Snackbar_IHandler()
			{
				if ((object)cb_onDismissed_Lcom_google_android_material_snackbar_Snackbar_I == null)
				{
					cb_onDismissed_Lcom_google_android_material_snackbar_Snackbar_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int>(n_OnDismissed_Lcom_google_android_material_snackbar_Snackbar_I));
				}
				return cb_onDismissed_Lcom_google_android_material_snackbar_Snackbar_I;
			}

			private static void n_OnDismissed_Lcom_google_android_material_snackbar_Snackbar_I(IntPtr jnienv, IntPtr native__this, IntPtr native_transientBottomBar, int e)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Snackbar transientBottomBar = Java.Lang.Object.GetObject<Snackbar>(native_transientBottomBar, JniHandleOwnership.DoNotTransfer);
				callback.OnDismissed(transientBottomBar, e);
			}

			[Register("onDismissed", "(Lcom/google/android/material/snackbar/Snackbar;I)V", "GetOnDismissed_Lcom_google_android_material_snackbar_Snackbar_IHandler")]
			public unsafe virtual void OnDismissed(Snackbar transientBottomBar, int e)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(transientBottomBar?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDismissed.(Lcom/google/android/material/snackbar/Snackbar;I)V", this, ptr);
				GC.KeepAlive(transientBottomBar);
			}

			private static Delegate GetOnShown_Lcom_google_android_material_snackbar_Snackbar_Handler()
			{
				if ((object)cb_onShown_Lcom_google_android_material_snackbar_Snackbar_ == null)
				{
					cb_onShown_Lcom_google_android_material_snackbar_Snackbar_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnShown_Lcom_google_android_material_snackbar_Snackbar_));
				}
				return cb_onShown_Lcom_google_android_material_snackbar_Snackbar_;
			}

			private static void n_OnShown_Lcom_google_android_material_snackbar_Snackbar_(IntPtr jnienv, IntPtr native__this, IntPtr native_sb)
			{
				Callback callback = Java.Lang.Object.GetObject<Callback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Snackbar sb = Java.Lang.Object.GetObject<Snackbar>(native_sb, JniHandleOwnership.DoNotTransfer);
				callback.OnShown(sb);
			}

			[Register("onShown", "(Lcom/google/android/material/snackbar/Snackbar;)V", "GetOnShown_Lcom_google_android_material_snackbar_Snackbar_Handler")]
			public unsafe virtual void OnShown(Snackbar sb)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sb?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onShown.(Lcom/google/android/material/snackbar/Snackbar;)V", this, ptr);
				GC.KeepAlive(sb);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/Snackbar", typeof(Snackbar));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public Snackbar SetAction(string text, Action<View> clickHandler)
		{
			return SetAction(text, new SnackbarActionClickImplementor(clickHandler));
		}

		public Snackbar SetAction(ICharSequence text, Action<View> clickHandler)
		{
			return SetAction(text, new SnackbarActionClickImplementor(clickHandler));
		}

		public Snackbar SetAction(int resId, Action<View> clickHandler)
		{
			return SetAction(resId, new SnackbarActionClickImplementor(clickHandler));
		}

		internal Snackbar(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("hasSnackbarButtonStyleAttr", "(Landroid/content/Context;)Z", "")]
		private unsafe static bool HasSnackbarButtonStyleAttr(Context context)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			bool result = _members.StaticMethods.InvokeBooleanMethod("hasSnackbarButtonStyleAttr.(Landroid/content/Context;)Z", ptr);
			GC.KeepAlive(context);
			return result;
		}

		[Register("make", "(Landroid/view/View;II)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe static Snackbar Make(View view, int resId, int duration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resId);
			ptr[2] = new JniArgumentValue(duration);
			Snackbar result = Java.Lang.Object.GetObject<Snackbar>(_members.StaticMethods.InvokeObjectMethod("make.(Landroid/view/View;II)Lcom/google/android/material/snackbar/Snackbar;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(view);
			return result;
		}

		[Register("make", "(Landroid/view/View;Ljava/lang/CharSequence;I)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe static Snackbar Make(View view, ICharSequence text, int duration)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
			Snackbar result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(duration);
				result = Java.Lang.Object.GetObject<Snackbar>(_members.StaticMethods.InvokeObjectMethod("make.(Landroid/view/View;Ljava/lang/CharSequence;I)Lcom/google/android/material/snackbar/Snackbar;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(text);
			return result;
		}

		public static Snackbar Make(View view, string text, int duration)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Snackbar result = Make(view, obj, duration);
			obj?.Dispose();
			return result;
		}

		[Register("setAction", "(ILandroid/view/View$OnClickListener;)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetAction(int resId, View.IOnClickListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resId);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			Snackbar result = Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAction.(ILandroid/view/View$OnClickListener;)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(listener);
			return result;
		}

		[Register("setAction", "(Ljava/lang/CharSequence;Landroid/view/View$OnClickListener;)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetAction(ICharSequence text, View.IOnClickListener listener)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(text);
			Snackbar result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				result = Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAction.(Ljava/lang/CharSequence;Landroid/view/View$OnClickListener;)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(text);
			GC.KeepAlive(listener);
			return result;
		}

		public Snackbar SetAction(string text, View.IOnClickListener listener)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Snackbar result = SetAction(obj, listener);
			obj?.Dispose();
			return result;
		}

		[Register("setActionTextColor", "(Landroid/content/res/ColorStateList;)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetActionTextColor(ColorStateList colors)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colors?.Handle ?? IntPtr.Zero);
			Snackbar result = Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionTextColor.(Landroid/content/res/ColorStateList;)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(colors);
			return result;
		}

		[Register("setActionTextColor", "(I)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetActionTextColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			return Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionTextColor.(I)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setCallback", "(Lcom/google/android/material/snackbar/Snackbar$Callback;)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetCallback(Callback callback)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			Snackbar result = Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCallback.(Lcom/google/android/material/snackbar/Snackbar$Callback;)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(callback);
			return result;
		}

		[Register("setText", "(I)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetText(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setText.(I)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setText", "(Ljava/lang/CharSequence;)Lcom/google/android/material/snackbar/Snackbar;", "")]
		public unsafe Snackbar SetText(ICharSequence message)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(message);
			Snackbar result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Snackbar>(_members.InstanceMethods.InvokeAbstractObjectMethod("setText.(Ljava/lang/CharSequence;)Lcom/google/android/material/snackbar/Snackbar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(message);
			return result;
		}

		public Snackbar SetText(string message)
		{
			Java.Lang.String obj = ((message == null) ? null : new Java.Lang.String(message));
			Snackbar result = SetText(obj);
			obj?.Dispose();
			return result;
		}
	}
	[Register("com/google/android/material/snackbar/BaseTransientBottomBar", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "B extends com.google.android.material.snackbar.BaseTransientBottomBar<B>" })]
	public abstract class BaseTransientBottomBar : Java.Lang.Object
	{
		[Register("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "B" })]
		public abstract class BaseCallback : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", typeof(BaseCallback));

			private static Delegate cb_onDismissed_Ljava_lang_Object_I;

			private static Delegate cb_onShown_Ljava_lang_Object_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected BaseCallback(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe BaseCallback()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnDismissed_Ljava_lang_Object_IHandler()
			{
				if ((object)cb_onDismissed_Ljava_lang_Object_I == null)
				{
					cb_onDismissed_Ljava_lang_Object_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int>(n_OnDismissed_Ljava_lang_Object_I));
				}
				return cb_onDismissed_Ljava_lang_Object_I;
			}

			private static void n_OnDismissed_Ljava_lang_Object_I(IntPtr jnienv, IntPtr native__this, IntPtr native_transientBottomBar, int e)
			{
				BaseCallback baseCallback = Java.Lang.Object.GetObject<BaseCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object transientBottomBar = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transientBottomBar, JniHandleOwnership.DoNotTransfer);
				baseCallback.OnDismissed(transientBottomBar, e);
			}

			[Register("onDismissed", "(Ljava/lang/Object;I)V", "GetOnDismissed_Ljava_lang_Object_IHandler")]
			public unsafe virtual void OnDismissed(Java.Lang.Object transientBottomBar, int e)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(transientBottomBar);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(e);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onDismissed.(Ljava/lang/Object;I)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetOnShown_Ljava_lang_Object_Handler()
			{
				if ((object)cb_onShown_Ljava_lang_Object_ == null)
				{
					cb_onShown_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnShown_Ljava_lang_Object_));
				}
				return cb_onShown_Ljava_lang_Object_;
			}

			private static void n_OnShown_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_transientBottomBar)
			{
				BaseCallback baseCallback = Java.Lang.Object.GetObject<BaseCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object transientBottomBar = Java.Lang.Object.GetObject<Java.Lang.Object>(native_transientBottomBar, JniHandleOwnership.DoNotTransfer);
				baseCallback.OnShown(transientBottomBar);
			}

			[Register("onShown", "(Ljava/lang/Object;)V", "GetOnShown_Ljava_lang_Object_Handler")]
			public unsafe virtual void OnShown(Java.Lang.Object transientBottomBar)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(transientBottomBar);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onShown.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", DoNotGenerateAcw = true)]
		internal class BaseCallbackInvoker : BaseCallback
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback", typeof(BaseCallbackInvoker));

			public override JniPeerMembers JniPeerMembers => _members;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public BaseCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("com/google/android/material/snackbar/BaseTransientBottomBar$Behavior", DoNotGenerateAcw = true)]
		public class Behavior : SwipeDismissBehavior
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar$Behavior", typeof(Behavior));

			private static Delegate cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;

			internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Behavior(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Behavior()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
			{
				if ((object)cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ == null)
				{
					cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, bool>(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_));
				}
				return cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;
			}

			private static bool n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_e)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return behavior.OnInterceptTouchEvent(parent, child, e);
			}

			[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
			public unsafe override bool OnInterceptTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent e)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(e);
				return result;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar", typeof(BaseTransientBottomBar));

		private static Delegate cb_getContext;

		private static Delegate cb_getDuration;

		private static Delegate cb_hasSnackbarStyleAttr;

		private static Delegate cb_isShown;

		private static Delegate cb_isShownOrQueued;

		private static Delegate cb_getNewBehavior;

		private static Delegate cb_getSnackbarBaseLayoutResId;

		private static Delegate cb_getView;

		private static Delegate cb_addCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_;

		private static Delegate cb_dismiss;

		private static Delegate cb_dispatchDismiss_I;

		private static Delegate cb_getBehavior;

		private static Delegate cb_removeCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_;

		private static Delegate cb_setBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_;

		private static Delegate cb_setDuration_I;

		private static Delegate cb_show;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Context Context
		{
			[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Duration
		{
			[Register("getDuration", "()I", "GetGetDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDuration.()I", this, null);
			}
		}

		protected unsafe virtual bool HasSnackbarStyleAttr
		{
			[Register("hasSnackbarStyleAttr", "()Z", "GetHasSnackbarStyleAttrHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasSnackbarStyleAttr.()Z", this, null);
			}
		}

		public unsafe virtual bool IsShown
		{
			[Register("isShown", "()Z", "GetIsShownHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShown.()Z", this, null);
			}
		}

		public unsafe virtual bool IsShownOrQueued
		{
			[Register("isShownOrQueued", "()Z", "GetIsShownOrQueuedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShownOrQueued.()Z", this, null);
			}
		}

		protected unsafe virtual SwipeDismissBehavior NewBehavior
		{
			[Register("getNewBehavior", "()Lcom/google/android/material/behavior/SwipeDismissBehavior;", "GetGetNewBehaviorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SwipeDismissBehavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNewBehavior.()Lcom/google/android/material/behavior/SwipeDismissBehavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe virtual int SnackbarBaseLayoutResId
		{
			[Register("getSnackbarBaseLayoutResId", "()I", "GetGetSnackbarBaseLayoutResIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSnackbarBaseLayoutResId.()I", this, null);
			}
		}

		public unsafe virtual View View
		{
			[Register("getView", "()Landroid/view/View;", "GetGetViewHandler")]
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected BaseTransientBottomBar(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", "")]
		protected unsafe BaseTransientBottomBar(ViewGroup parent, View content, IContentViewCallback contentViewCallback)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(content?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((contentViewCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)contentViewCallback).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup;Landroid/view/View;Lcom/google/android/material/snackbar/ContentViewCallback;)V", this, ptr);
			}
		}

		private static Delegate GetGetContextHandler()
		{
			if ((object)cb_getContext == null)
			{
				cb_getContext = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetContext));
			}
			return cb_getContext;
		}

		private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
		}

		private static Delegate GetGetDurationHandler()
		{
			if ((object)cb_getDuration == null)
			{
				cb_getDuration = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetDuration));
			}
			return cb_getDuration;
		}

		private static int n_GetDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
		}

		private static Delegate GetHasSnackbarStyleAttrHandler()
		{
			if ((object)cb_hasSnackbarStyleAttr == null)
			{
				cb_hasSnackbarStyleAttr = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_HasSnackbarStyleAttr));
			}
			return cb_hasSnackbarStyleAttr;
		}

		private static bool n_HasSnackbarStyleAttr(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSnackbarStyleAttr;
		}

		private static Delegate GetIsShownHandler()
		{
			if ((object)cb_isShown == null)
			{
				cb_isShown = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsShown));
			}
			return cb_isShown;
		}

		private static bool n_IsShown(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShown;
		}

		private static Delegate GetIsShownOrQueuedHandler()
		{
			if ((object)cb_isShownOrQueued == null)
			{
				cb_isShownOrQueued = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsShownOrQueued));
			}
			return cb_isShownOrQueued;
		}

		private static bool n_IsShownOrQueued(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShownOrQueued;
		}

		private static Delegate GetGetNewBehaviorHandler()
		{
			if ((object)cb_getNewBehavior == null)
			{
				cb_getNewBehavior = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetNewBehavior));
			}
			return cb_getNewBehavior;
		}

		private static IntPtr n_GetNewBehavior(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewBehavior);
		}

		private static Delegate GetGetSnackbarBaseLayoutResIdHandler()
		{
			if ((object)cb_getSnackbarBaseLayoutResId == null)
			{
				cb_getSnackbarBaseLayoutResId = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetSnackbarBaseLayoutResId));
			}
			return cb_getSnackbarBaseLayoutResId;
		}

		private static int n_GetSnackbarBaseLayoutResId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SnackbarBaseLayoutResId;
		}

		private static Delegate GetGetViewHandler()
		{
			if ((object)cb_getView == null)
			{
				cb_getView = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetView));
			}
			return cb_getView;
		}

		private static IntPtr n_GetView(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
		}

		private static Delegate GetAddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler()
		{
			if ((object)cb_addCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_ == null)
			{
				cb_addCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_AddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_));
			}
			return cb_addCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_;
		}

		private static IntPtr n_AddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			BaseTransientBottomBar baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BaseCallback callback = Java.Lang.Object.GetObject<BaseCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.AddCallback(callback));
		}

		[Register("addCallback", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetAddCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler")]
		public unsafe virtual Java.Lang.Object AddCallback(BaseCallback callback)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("addCallback.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDismissHandler()
		{
			if ((object)cb_dismiss == null)
			{
				cb_dismiss = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Dismiss));
			}
			return cb_dismiss;
		}

		private static void n_Dismiss(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
		}

		[Register("dismiss", "()V", "GetDismissHandler")]
		public unsafe virtual void Dismiss()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
		}

		private static Delegate GetDispatchDismiss_IHandler()
		{
			if ((object)cb_dispatchDismiss_I == null)
			{
				cb_dispatchDismiss_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_DispatchDismiss_I));
			}
			return cb_dispatchDismiss_I;
		}

		private static void n_DispatchDismiss_I(IntPtr jnienv, IntPtr native__this, int e)
		{
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DispatchDismiss(e);
		}

		[Register("dispatchDismiss", "(I)V", "GetDispatchDismiss_IHandler")]
		protected unsafe virtual void DispatchDismiss(int e)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchDismiss.(I)V", this, ptr);
		}

		private static Delegate GetGetBehaviorHandler()
		{
			if ((object)cb_getBehavior == null)
			{
				cb_getBehavior = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetBehavior));
			}
			return cb_getBehavior;
		}

		private static IntPtr n_GetBehavior(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBehavior());
		}

		[Register("getBehavior", "()Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;", "GetGetBehaviorHandler")]
		public unsafe virtual Behavior GetBehavior()
		{
			return Java.Lang.Object.GetObject<Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler()
		{
			if ((object)cb_removeCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_ == null)
			{
				cb_removeCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_RemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_));
			}
			return cb_removeCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_;
		}

		private static IntPtr n_RemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native__callback)
		{
			BaseTransientBottomBar baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BaseCallback callback = Java.Lang.Object.GetObject<BaseCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.RemoveCallback(callback));
		}

		[Register("removeCallback", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetRemoveCallback_Lcom_google_android_material_snackbar_BaseTransientBottomBar_BaseCallback_Handler")]
		public unsafe virtual Java.Lang.Object RemoveCallback(BaseCallback callback)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeCallback.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_Handler()
		{
			if ((object)cb_setBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_ == null)
			{
				cb_setBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_SetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_));
			}
			return cb_setBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_;
		}

		private static IntPtr n_SetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_(IntPtr jnienv, IntPtr native__this, IntPtr native_behavior)
		{
			BaseTransientBottomBar baseTransientBottomBar = Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Behavior behavior = Java.Lang.Object.GetObject<Behavior>(native_behavior, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseTransientBottomBar.SetBehavior(behavior));
		}

		[Register("setBehavior", "(Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetBehavior_Lcom_google_android_material_snackbar_BaseTransientBottomBar_Behavior_Handler")]
		public unsafe virtual Java.Lang.Object SetBehavior(Behavior behavior)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(behavior?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBehavior.(Lcom/google/android/material/snackbar/BaseTransientBottomBar$Behavior;)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetDuration_IHandler()
		{
			if ((object)cb_setDuration_I == null)
			{
				cb_setDuration_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetDuration_I));
			}
			return cb_setDuration_I;
		}

		private static IntPtr n_SetDuration_I(IntPtr jnienv, IntPtr native__this, int duration)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
		}

		[Register("setDuration", "(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", "GetSetDuration_IHandler")]
		public unsafe virtual Java.Lang.Object SetDuration(int duration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(duration);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(I)Lcom/google/android/material/snackbar/BaseTransientBottomBar;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetShowHandler()
		{
			if ((object)cb_show == null)
			{
				cb_show = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Show));
			}
			return cb_show;
		}

		private static void n_Show(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<BaseTransientBottomBar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
		}

		[Register("show", "()V", "GetShowHandler")]
		public unsafe virtual void Show()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
		}
	}
	[Register("com/google/android/material/snackbar/BaseTransientBottomBar", DoNotGenerateAcw = true)]
	internal class BaseTransientBottomBarInvoker : BaseTransientBottomBar
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar", typeof(BaseTransientBottomBarInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public BaseTransientBottomBarInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("com/google/android/material/snackbar/ContentViewCallback", "", "Google.Android.Material.Snackbar.IContentViewCallbackInvoker")]
	public interface IContentViewCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("animateContentIn", "(II)V", "GetAnimateContentIn_IIHandler:Google.Android.Material.Snackbar.IContentViewCallbackInvoker, Xamarin.Google.Android.Material")]
		void AnimateContentIn(int p0, int p1);

		[Register("animateContentOut", "(II)V", "GetAnimateContentOut_IIHandler:Google.Android.Material.Snackbar.IContentViewCallbackInvoker, Xamarin.Google.Android.Material")]
		void AnimateContentOut(int p0, int p1);
	}
	[Register("com/google/android/material/snackbar/ContentViewCallback", DoNotGenerateAcw = true)]
	internal class IContentViewCallbackInvoker : Java.Lang.Object, IContentViewCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/ContentViewCallback", typeof(IContentViewCallbackInvoker));

		private IntPtr class_ref;

		private static Delegate cb_animateContentIn_II;

		private IntPtr id_animateContentIn_II;

		private static Delegate cb_animateContentOut_II;

		private IntPtr id_animateContentOut_II;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IContentViewCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IContentViewCallback>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.material.snackbar.ContentViewCallback"));
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

		public IContentViewCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAnimateContentIn_IIHandler()
		{
			if ((object)cb_animateContentIn_II == null)
			{
				cb_animateContentIn_II = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int>(n_AnimateContentIn_II));
			}
			return cb_animateContentIn_II;
		}

		private static void n_AnimateContentIn_II(IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			Java.Lang.Object.GetObject<IContentViewCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateContentIn(p0, p1);
		}

		public unsafe void AnimateContentIn(int p0, int p1)
		{
			if (id_animateContentIn_II == IntPtr.Zero)
			{
				id_animateContentIn_II = JNIEnv.GetMethodID(class_ref, "animateContentIn", "(II)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_animateContentIn_II, ptr);
		}

		private static Delegate GetAnimateContentOut_IIHandler()
		{
			if ((object)cb_animateContentOut_II == null)
			{
				cb_animateContentOut_II = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int>(n_AnimateContentOut_II));
			}
			return cb_animateContentOut_II;
		}

		private static void n_AnimateContentOut_II(IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			Java.Lang.Object.GetObject<IContentViewCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateContentOut(p0, p1);
		}

		public unsafe void AnimateContentOut(int p0, int p1)
		{
			if (id_animateContentOut_II == IntPtr.Zero)
			{
				id_animateContentOut_II = JNIEnv.GetMethodID(class_ref, "animateContentOut", "(II)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_animateContentOut_II, ptr);
		}
	}
}
namespace Google.Android.Material.Internal
{
	[Register("com/google/android/material/internal/VisibilityAwareImageButton", DoNotGenerateAcw = true)]
	public class VisibilityAwareImageButton : ImageButton
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/internal/VisibilityAwareImageButton", typeof(VisibilityAwareImageButton));

		public override ViewStates Visibility
		{
			get
			{
				return base.Visibility;
			}
			set
			{
				base.Visibility = value;
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe int UserSetVisibility
		{
			[Register("getUserSetVisibility", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getUserSetVisibility.()I", this, null);
			}
		}

		public void SetVisibility(ViewStates visibility)
		{
			Visibility = visibility;
		}

		protected VisibilityAwareImageButton(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe VisibilityAwareImageButton(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe VisibilityAwareImageButton(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe VisibilityAwareImageButton(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register("internalSetVisibility", "(IZ)V", "")]
		public unsafe void InternalSetVisibility(int visibility, bool fromUser)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(visibility);
			ptr[1] = new JniArgumentValue(fromUser);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("internalSetVisibility.(IZ)V", this, ptr);
		}
	}
}
namespace Google.Android.Material.AppBar
{
	[Register("com/google/android/material/appbar/AppBarLayout", DoNotGenerateAcw = true)]
	public class AppBarLayout : LinearLayout
	{
		[Register("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", "", "Google.Android.Material.AppBar.AppBarLayout/IOnOffsetChangedListenerInvoker")]
		public interface IOnOffsetChangedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onOffsetChanged", "(Lcom/google/android/material/appbar/AppBarLayout;I)V", "GetOnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_IHandler:Google.Android.Material.AppBar.AppBarLayout/IOnOffsetChangedListenerInvoker, Xamarin.Google.Android.Material")]
			void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset);
		}

		[Register("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", DoNotGenerateAcw = true)]
		internal class IOnOffsetChangedListenerInvoker : Java.Lang.Object, IOnOffsetChangedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", typeof(IOnOffsetChangedListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I;

			private IntPtr id_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IOnOffsetChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IOnOffsetChangedListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.android.material.appbar.AppBarLayout.OnOffsetChangedListener"));
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

			public IOnOffsetChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_IHandler()
			{
				if ((object)cb_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I == null)
				{
					cb_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int>(n_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I));
				}
				return cb_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I;
			}

			private static void n_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I(IntPtr jnienv, IntPtr native__this, IntPtr native_appBarLayout, int verticalOffset)
			{
				IOnOffsetChangedListener onOffsetChangedListener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AppBarLayout appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(native_appBarLayout, JniHandleOwnership.DoNotTransfer);
				onOffsetChangedListener.OnOffsetChanged(appBarLayout, verticalOffset);
			}

			public unsafe void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
			{
				if (id_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I == IntPtr.Zero)
				{
					id_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I = JNIEnv.GetMethodID(class_ref, "onOffsetChanged", "(Lcom/google/android/material/appbar/AppBarLayout;I)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(appBarLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(verticalOffset);
				JNIEnv.CallVoidMethod(base.Handle, id_onOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I, ptr);
			}
		}

		public class OffsetChangedEventArgs : EventArgs
		{
			private AppBarLayout appBarLayout;

			private int verticalOffset;

			public OffsetChangedEventArgs(AppBarLayout appBarLayout, int verticalOffset)
			{
				this.appBarLayout = appBarLayout;
				this.verticalOffset = verticalOffset;
			}
		}

		[Register("mono/com/google/android/material/appbar/AppBarLayout_OnOffsetChangedListenerImplementor")]
		internal sealed class IOnOffsetChangedListenerImplementor : Java.Lang.Object, IOnOffsetChangedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<OffsetChangedEventArgs> Handler;

			public IOnOffsetChangedListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/com/google/android/material/appbar/AppBarLayout_OnOffsetChangedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
			{
				Handler?.Invoke(sender, new OffsetChangedEventArgs(appBarLayout, verticalOffset));
			}

			internal static bool __IsEmpty(IOnOffsetChangedListenerImplementor value)
			{
				return value.Handler == null;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/appbar/AppBarLayout", typeof(AppBarLayout));

		private static Delegate cb_isLiftOnScroll;

		private static Delegate cb_setLiftOnScroll_Z;

		private static Delegate cb_getTargetElevation;

		private static Delegate cb_setTargetElevation_F;

		private static Delegate cb_addOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_;

		private static Delegate cb_removeOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_;

		private static Delegate cb_setExpanded_Z;

		private static Delegate cb_setExpanded_ZZ;

		private static Delegate cb_setLiftable_Z;

		private static Delegate cb_setLifted_Z;

		private WeakReference weak_implementor_AddOnOffsetChangedListener;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool LiftOnScroll
		{
			[Register("isLiftOnScroll", "()Z", "GetIsLiftOnScrollHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLiftOnScroll.()Z", this, null);
			}
			[Register("setLiftOnScroll", "(Z)V", "GetSetLiftOnScroll_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLiftOnScroll.(Z)V", this, ptr);
			}
		}

		public unsafe int MinimumHeightForVisibleOverlappingContent
		{
			[Register("getMinimumHeightForVisibleOverlappingContent", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMinimumHeightForVisibleOverlappingContent.()I", this, null);
			}
		}

		public unsafe virtual float TargetElevation
		{
			[Register("getTargetElevation", "()F", "GetGetTargetElevationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getTargetElevation.()F", this, null);
			}
			[Register("setTargetElevation", "(F)V", "GetSetTargetElevation_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetElevation.(F)V", this, ptr);
			}
		}

		public unsafe int TotalScrollRange
		{
			[Register("getTotalScrollRange", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTotalScrollRange.()I", this, null);
			}
		}

		public event EventHandler<OffsetChangedEventArgs> OffsetChanged
		{
			add
			{
				EventHelper.AddEventHandler<IOnOffsetChangedListener, IOnOffsetChangedListenerImplementor>(ref weak_implementor_AddOnOffsetChangedListener, __CreateIOnOffsetChangedListenerImplementor, AddOnOffsetChangedListener, delegate(IOnOffsetChangedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<OffsetChangedEventArgs>)Delegate.Combine(__h.Handler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddOnOffsetChangedListener, IOnOffsetChangedListenerImplementor.__IsEmpty, delegate(IOnOffsetChangedListener __v)
				{
					RemoveOnOffsetChangedListener(__v);
				}, delegate(IOnOffsetChangedListenerImplementor __h)
				{
					__h.Handler = (EventHandler<OffsetChangedEventArgs>)Delegate.Remove(__h.Handler, value);
				});
			}
		}

		protected AppBarLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe AppBarLayout(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe AppBarLayout(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetIsLiftOnScrollHandler()
		{
			if ((object)cb_isLiftOnScroll == null)
			{
				cb_isLiftOnScroll = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsLiftOnScroll));
			}
			return cb_isLiftOnScroll;
		}

		private static bool n_IsLiftOnScroll(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiftOnScroll;
		}

		private static Delegate GetSetLiftOnScroll_ZHandler()
		{
			if ((object)cb_setLiftOnScroll_Z == null)
			{
				cb_setLiftOnScroll_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetLiftOnScroll_Z));
			}
			return cb_setLiftOnScroll_Z;
		}

		private static void n_SetLiftOnScroll_Z(IntPtr jnienv, IntPtr native__this, bool liftOnScroll)
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiftOnScroll = liftOnScroll;
		}

		private static Delegate GetGetTargetElevationHandler()
		{
			if ((object)cb_getTargetElevation == null)
			{
				cb_getTargetElevation = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, float>(n_GetTargetElevation));
			}
			return cb_getTargetElevation;
		}

		private static float n_GetTargetElevation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetElevation;
		}

		private static Delegate GetSetTargetElevation_FHandler()
		{
			if ((object)cb_setTargetElevation_F == null)
			{
				cb_setTargetElevation_F = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float>(n_SetTargetElevation_F));
			}
			return cb_setTargetElevation_F;
		}

		private static void n_SetTargetElevation_F(IntPtr jnienv, IntPtr native__this, float elevation)
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetElevation = elevation;
		}

		private static Delegate GetAddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler()
		{
			if ((object)cb_addOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_ == null)
			{
				cb_addOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_));
			}
			return cb_addOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_;
		}

		private static void n_AddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			AppBarLayout appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnOffsetChangedListener listener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			appBarLayout.AddOnOffsetChangedListener(listener);
		}

		[Register("addOnOffsetChangedListener", "(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", "GetAddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler")]
		public unsafe virtual void AddOnOffsetChangedListener(IOnOffsetChangedListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnOffsetChangedListener.(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetRemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler()
		{
			if ((object)cb_removeOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_ == null)
			{
				cb_removeOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_));
			}
			return cb_removeOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_;
		}

		private static void n_RemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			AppBarLayout appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnOffsetChangedListener listener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			appBarLayout.RemoveOnOffsetChangedListener(listener);
		}

		[Register("removeOnOffsetChangedListener", "(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", "GetRemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler")]
		public unsafe virtual void RemoveOnOffsetChangedListener(IOnOffsetChangedListener listener)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnOffsetChangedListener.(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", this, ptr);
			GC.KeepAlive(listener);
		}

		private static Delegate GetSetExpanded_ZHandler()
		{
			if ((object)cb_setExpanded_Z == null)
			{
				cb_setExpanded_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetExpanded_Z));
			}
			return cb_setExpanded_Z;
		}

		private static void n_SetExpanded_Z(IntPtr jnienv, IntPtr native__this, bool expanded)
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExpanded(expanded);
		}

		[Register("setExpanded", "(Z)V", "GetSetExpanded_ZHandler")]
		public unsafe virtual void SetExpanded(bool expanded)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(expanded);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpanded.(Z)V", this, ptr);
		}

		private static Delegate GetSetExpanded_ZZHandler()
		{
			if ((object)cb_setExpanded_ZZ == null)
			{
				cb_setExpanded_ZZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool, bool>(n_SetExpanded_ZZ));
			}
			return cb_setExpanded_ZZ;
		}

		private static void n_SetExpanded_ZZ(IntPtr jnienv, IntPtr native__this, bool expanded, bool animate)
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExpanded(expanded, animate);
		}

		[Register("setExpanded", "(ZZ)V", "GetSetExpanded_ZZHandler")]
		public unsafe virtual void SetExpanded(bool expanded, bool animate)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(expanded);
			ptr[1] = new JniArgumentValue(animate);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpanded.(ZZ)V", this, ptr);
		}

		private static Delegate GetSetLiftable_ZHandler()
		{
			if ((object)cb_setLiftable_Z == null)
			{
				cb_setLiftable_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_SetLiftable_Z));
			}
			return cb_setLiftable_Z;
		}

		private static bool n_SetLiftable_Z(IntPtr jnienv, IntPtr native__this, bool liftable)
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLiftable(liftable);
		}

		[Register("setLiftable", "(Z)Z", "GetSetLiftable_ZHandler")]
		public unsafe virtual bool SetLiftable(bool liftable)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(liftable);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setLiftable.(Z)Z", this, ptr);
		}

		private static Delegate GetSetLifted_ZHandler()
		{
			if ((object)cb_setLifted_Z == null)
			{
				cb_setLifted_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, bool>(n_SetLifted_Z));
			}
			return cb_setLifted_Z;
		}

		private static bool n_SetLifted_Z(IntPtr jnienv, IntPtr native__this, bool lifted)
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLifted(lifted);
		}

		[Register("setLifted", "(Z)Z", "GetSetLifted_ZHandler")]
		public unsafe virtual bool SetLifted(bool lifted)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(lifted);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setLifted.(Z)Z", this, ptr);
		}

		private IOnOffsetChangedListenerImplementor __CreateIOnOffsetChangedListenerImplementor()
		{
			return new IOnOffsetChangedListenerImplementor(this);
		}
	}
}
namespace Google.Android.Material.Animation
{
	[Register("com/google/android/material/animation/MotionSpec", DoNotGenerateAcw = true)]
	public class MotionSpec : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/animation/MotionSpec", typeof(MotionSpec));

		private static Delegate cb_getTotalDuration;

		private static Delegate cb_getTiming_Ljava_lang_String_;

		private static Delegate cb_hasTiming_Ljava_lang_String_;

		private static Delegate cb_setTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual long TotalDuration
		{
			[Register("getTotalDuration", "()J", "GetGetTotalDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getTotalDuration.()J", this, null);
			}
		}

		protected MotionSpec(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MotionSpec()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetTotalDurationHandler()
		{
			if ((object)cb_getTotalDuration == null)
			{
				cb_getTotalDuration = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_GetTotalDuration));
			}
			return cb_getTotalDuration;
		}

		private static long n_GetTotalDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalDuration;
		}

		[Register("createFromAttribute", "(Landroid/content/Context;Landroid/content/res/TypedArray;I)Lcom/google/android/material/animation/MotionSpec;", "")]
		public unsafe static MotionSpec CreateFromAttribute(Context context, TypedArray attributes, int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(attributes?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(index);
			MotionSpec result = Java.Lang.Object.GetObject<MotionSpec>(_members.StaticMethods.InvokeObjectMethod("createFromAttribute.(Landroid/content/Context;Landroid/content/res/TypedArray;I)Lcom/google/android/material/animation/MotionSpec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(context);
			GC.KeepAlive(attributes);
			return result;
		}

		[Register("createFromResource", "(Landroid/content/Context;I)Lcom/google/android/material/animation/MotionSpec;", "")]
		public unsafe static MotionSpec CreateFromResource(Context context, int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			MotionSpec result = Java.Lang.Object.GetObject<MotionSpec>(_members.StaticMethods.InvokeObjectMethod("createFromResource.(Landroid/content/Context;I)Lcom/google/android/material/animation/MotionSpec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(context);
			return result;
		}

		private static Delegate GetGetTiming_Ljava_lang_String_Handler()
		{
			if ((object)cb_getTiming_Ljava_lang_String_ == null)
			{
				cb_getTiming_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_GetTiming_Ljava_lang_String_));
			}
			return cb_getTiming_Ljava_lang_String_;
		}

		private static IntPtr n_GetTiming_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			MotionSpec motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionSpec.GetTiming(name));
		}

		[Register("getTiming", "(Ljava/lang/String;)Lcom/google/android/material/animation/MotionTiming;", "GetGetTiming_Ljava_lang_String_Handler")]
		public unsafe virtual MotionTiming GetTiming(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<MotionTiming>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTiming.(Ljava/lang/String;)Lcom/google/android/material/animation/MotionTiming;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetHasTiming_Ljava_lang_String_Handler()
		{
			if ((object)cb_hasTiming_Ljava_lang_String_ == null)
			{
				cb_hasTiming_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_HasTiming_Ljava_lang_String_));
			}
			return cb_hasTiming_Ljava_lang_String_;
		}

		private static bool n_HasTiming_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			MotionSpec motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motionSpec.HasTiming(name);
		}

		[Register("hasTiming", "(Ljava/lang/String;)Z", "GetHasTiming_Ljava_lang_String_Handler")]
		public unsafe virtual bool HasTiming(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasTiming.(Ljava/lang/String;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_Handler()
		{
			if ((object)cb_setTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_ == null)
			{
				cb_setTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_SetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_));
			}
			return cb_setTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_;
		}

		private static void n_SetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_(IntPtr jnienv, IntPtr native__this, IntPtr native_name, IntPtr native_timing)
		{
			MotionSpec motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			MotionTiming timing = Java.Lang.Object.GetObject<MotionTiming>(native_timing, JniHandleOwnership.DoNotTransfer);
			motionSpec.SetTiming(name, timing);
		}

		[Register("setTiming", "(Ljava/lang/String;Lcom/google/android/material/animation/MotionTiming;)V", "GetSetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_Handler")]
		public unsafe virtual void SetTiming(string name, MotionTiming timing)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(timing?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTiming.(Ljava/lang/String;Lcom/google/android/material/animation/MotionTiming;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(timing);
			}
		}
	}
	[Register("com/google/android/material/animation/MotionTiming", DoNotGenerateAcw = true)]
	public class MotionTiming : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/animation/MotionTiming", typeof(MotionTiming));

		private static Delegate cb_getDelay;

		private static Delegate cb_getDuration;

		private static Delegate cb_getInterpolator;

		private static Delegate cb_getRepeatCount;

		private static Delegate cb_getRepeatMode;

		private static Delegate cb_apply_Landroid_animation_Animator_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual long Delay
		{
			[Register("getDelay", "()J", "GetGetDelayHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getDelay.()J", this, null);
			}
		}

		public unsafe virtual long Duration
		{
			[Register("getDuration", "()J", "GetGetDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getDuration.()J", this, null);
			}
		}

		public unsafe virtual ITimeInterpolator Interpolator
		{
			[Register("getInterpolator", "()Landroid/animation/TimeInterpolator;", "GetGetInterpolatorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ITimeInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/animation/TimeInterpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int RepeatCount
		{
			[Register("getRepeatCount", "()I", "GetGetRepeatCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRepeatCount.()I", this, null);
			}
		}

		public unsafe virtual int RepeatMode
		{
			[Register("getRepeatMode", "()I", "GetGetRepeatModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRepeatMode.()I", this, null);
			}
		}

		protected MotionTiming(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(JJ)V", "")]
		public unsafe MotionTiming(long delay, long duration)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(delay);
				ptr[1] = new JniArgumentValue(duration);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(JJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(JJ)V", this, ptr);
			}
		}

		[Register(".ctor", "(JJLandroid/animation/TimeInterpolator;)V", "")]
		public unsafe MotionTiming(long delay, long duration, ITimeInterpolator interpolator)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(delay);
				ptr[1] = new JniArgumentValue(duration);
				ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(JJLandroid/animation/TimeInterpolator;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(JJLandroid/animation/TimeInterpolator;)V", this, ptr);
				GC.KeepAlive(interpolator);
			}
		}

		private static Delegate GetGetDelayHandler()
		{
			if ((object)cb_getDelay == null)
			{
				cb_getDelay = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_GetDelay));
			}
			return cb_getDelay;
		}

		private static long n_GetDelay(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delay;
		}

		private static Delegate GetGetDurationHandler()
		{
			if ((object)cb_getDuration == null)
			{
				cb_getDuration = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_GetDuration));
			}
			return cb_getDuration;
		}

		private static long n_GetDuration(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
		}

		private static Delegate GetGetInterpolatorHandler()
		{
			if ((object)cb_getInterpolator == null)
			{
				cb_getInterpolator = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetInterpolator));
			}
			return cb_getInterpolator;
		}

		private static IntPtr n_GetInterpolator(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
		}

		private static Delegate GetGetRepeatCountHandler()
		{
			if ((object)cb_getRepeatCount == null)
			{
				cb_getRepeatCount = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetRepeatCount));
			}
			return cb_getRepeatCount;
		}

		private static int n_GetRepeatCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatCount;
		}

		private static Delegate GetGetRepeatModeHandler()
		{
			if ((object)cb_getRepeatMode == null)
			{
				cb_getRepeatMode = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetRepeatMode));
			}
			return cb_getRepeatMode;
		}

		private static int n_GetRepeatMode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatMode;
		}

		private static Delegate GetApply_Landroid_animation_Animator_Handler()
		{
			if ((object)cb_apply_Landroid_animation_Animator_ == null)
			{
				cb_apply_Landroid_animation_Animator_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Apply_Landroid_animation_Animator_));
			}
			return cb_apply_Landroid_animation_Animator_;
		}

		private static void n_Apply_Landroid_animation_Animator_(IntPtr jnienv, IntPtr native__this, IntPtr native_animator)
		{
			MotionTiming motionTiming = Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animator = Java.Lang.Object.GetObject<Animator>(native_animator, JniHandleOwnership.DoNotTransfer);
			motionTiming.Apply(animator);
		}

		[Register("apply", "(Landroid/animation/Animator;)V", "GetApply_Landroid_animation_Animator_Handler")]
		public unsafe virtual void Apply(Animator animator)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("apply.(Landroid/animation/Animator;)V", this, ptr);
			GC.KeepAlive(animator);
		}
	}
}
