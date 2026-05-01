using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "791ebe2cb9b9b044bb1d30e9bd4c6097326f4bbe")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20230120.4")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "1/20/2023 8:31:40 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.coordinatorlayout.widget", Managed = "AndroidX.CoordinatorLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.coordinatorlayout:coordinatorlayout'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.CoordinatorLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.CoordinatorLayout")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}
	}
}
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate bool _JniMarshal_PPLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPLIIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5);
internal delegate void _JniMarshal_PPLIIIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5, IntPtr p6);
internal delegate void _JniMarshal_PPLIILI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3, int p4);
internal delegate float _JniMarshal_PPLL_F(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate int _JniMarshal_PPLL_I(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate bool _JniMarshal_PPLLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate bool _JniMarshal_PPLLIIII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3, int p4, int p5);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate bool _JniMarshal_PPLLLFF_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, float p3, float p4);
internal delegate bool _JniMarshal_PPLLLFFZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, float p3, float p4, bool p5);
internal delegate void _JniMarshal_PPLLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3);
internal delegate void _JniMarshal_PPLLLIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4, int p5, int p6);
internal delegate void _JniMarshal_PPLLLIIIII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4, int p5, int p6, int p7);
internal delegate void _JniMarshal_PPLLLIIIIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4, int p5, int p6, int p7, IntPtr p8);
internal delegate void _JniMarshal_PPLLLIIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4, IntPtr p5);
internal delegate void _JniMarshal_PPLLLIILI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4, IntPtr p5, int p6);
internal delegate void _JniMarshal_PPLLLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, int p4);
internal delegate bool _JniMarshal_PPLLLLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, int p4);
internal delegate void _JniMarshal_PPLLLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, int p4, int p5);
internal delegate bool _JniMarshal_PPLLLLII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, int p4, int p5);
internal delegate bool _JniMarshal_PPLLLZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, bool p3);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
namespace AndroidX.CoordinatorLayout.Widget
{
	[Register("androidx/coordinatorlayout/widget/CoordinatorLayout", DoNotGenerateAcw = true)]
	public class CoordinatorLayout : ViewGroup, INestedScrollingParent2, INestedScrollingParent, IJavaObject, IDisposable, IJavaPeerable, INestedScrollingParent3
	{
		[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", DoNotGenerateAcw = true)]
		[JavaTypeParameters(new string[] { "V extends android.view.View" })]
		public abstract class Behavior : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", typeof(Behavior));

			private static Delegate cb_blocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;

			private static Delegate cb_getInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_;

			private static Delegate cb_getScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;

			private static Delegate cb_getScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;

			private static Delegate cb_layoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;

			private static Delegate cb_onApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_;

			private static Delegate cb_onAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_;

			private static Delegate cb_onDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;

			private static Delegate cb_onDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;

			private static Delegate cb_onDetachedFromLayoutParams;

			private static Delegate cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;

			private static Delegate cb_onLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I;

			private static Delegate cb_onMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII;

			private static Delegate cb_onNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ;

			private static Delegate cb_onNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF;

			private static Delegate cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI;

			private static Delegate cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII;

			private static Delegate cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII;

			private static Delegate cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII;

			private static Delegate cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI;

			private static Delegate cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I;

			private static Delegate cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II;

			private static Delegate cb_onRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z;

			private static Delegate cb_onRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_;

			private static Delegate cb_onSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;

			private static Delegate cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I;

			private static Delegate cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II;

			private static Delegate cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;

			private static Delegate cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I;

			private static Delegate cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
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

			[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
			public unsafe Behavior(Context context, IAttributeSet attrs)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(context);
					GC.KeepAlive(attrs);
				}
			}

			private static Delegate GetBlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
			{
				if ((object)cb_blocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ == null)
				{
					cb_blocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_BlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_));
				}
				return cb_blocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;
			}

			private static bool n_BlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.BlocksInteractionBelow(parent, child);
			}

			[Register("blocksInteractionBelow", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Z", "GetBlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
			public unsafe virtual bool BlocksInteractionBelow(CoordinatorLayout parent, Java.Lang.Object child)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("blocksInteractionBelow.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetGetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Handler()
			{
				if ((object)cb_getInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ == null)
				{
					cb_getInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_GetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_));
				}
				return cb_getInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_;
			}

			private static bool n_GetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_rect)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
				return behavior.GetInsetDodgeRect(parent, child, rect);
			}

			[Register("getInsetDodgeRect", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;)Z", "GetGetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Handler")]
			public unsafe virtual bool GetInsetDodgeRect(CoordinatorLayout parent, Java.Lang.Object child, Rect rect)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("getInsetDodgeRect.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(rect);
				}
			}

			private static Delegate GetGetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
			{
				if ((object)cb_getScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ == null)
				{
					cb_getScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_GetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_));
				}
				return cb_getScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;
			}

			private static int n_GetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.GetScrimColor(parent, child);
			}

			[Register("getScrimColor", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)I", "GetGetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
			public unsafe virtual int GetScrimColor(CoordinatorLayout parent, Java.Lang.Object child)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return _members.InstanceMethods.InvokeVirtualInt32Method("getScrimColor.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)I", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetGetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
			{
				if ((object)cb_getScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ == null)
				{
					cb_getScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLL_F(n_GetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_));
				}
				return cb_getScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;
			}

			private static float n_GetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.GetScrimOpacity(parent, child);
			}

			[Register("getScrimOpacity", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)F", "GetGetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
			public unsafe virtual float GetScrimOpacity(CoordinatorLayout parent, Java.Lang.Object child)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return _members.InstanceMethods.InvokeVirtualSingleMethod("getScrimOpacity.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)F", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			[Register("getTag", "(Landroid/view/View;)Ljava/lang/Object;", "")]
			public unsafe static Java.Lang.Object GetTag(View child)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getTag.(Landroid/view/View;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetLayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
			{
				if ((object)cb_layoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ == null)
				{
					cb_layoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_LayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_));
				}
				return cb_layoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;
			}

			private static bool n_LayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_dependency)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				return behavior.LayoutDependsOn(parent, child, dependency);
			}

			[Register("layoutDependsOn", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", "GetLayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
			public unsafe virtual bool LayoutDependsOn(CoordinatorLayout parent, Java.Lang.Object child, View dependency)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("layoutDependsOn.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(dependency);
				}
			}

			private static Delegate GetOnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler()
			{
				if ((object)cb_onApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_ == null)
				{
					cb_onApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_OnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_));
				}
				return cb_onApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_;
			}

			private static IntPtr n_OnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_insets)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				WindowInsetsCompat insets = Java.Lang.Object.GetObject<WindowInsetsCompat>(native_insets, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(behavior.OnApplyWindowInsets(coordinatorLayout, child, insets));
			}

			[Register("onApplyWindowInsets", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", "GetOnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler")]
			public unsafe virtual WindowInsetsCompat OnApplyWindowInsets(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, WindowInsetsCompat insets)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("onApplyWindowInsets.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(insets);
				}
			}

			private static Delegate GetOnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_Handler()
			{
				if ((object)cb_onAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_ == null)
				{
					cb_onAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_));
				}
				return cb_onAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_;
			}

			private static void n_OnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_(IntPtr jnienv, IntPtr native__this, IntPtr native__params)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
				behavior.OnAttachedToLayoutParams(layoutParams);
			}

			[Register("onAttachedToLayoutParams", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", "GetOnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_Handler")]
			public unsafe virtual void OnAttachedToLayoutParams(LayoutParams @params)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToLayoutParams.(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(@params);
				}
			}

			private static Delegate GetOnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
			{
				if ((object)cb_onDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ == null)
				{
					cb_onDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_OnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_));
				}
				return cb_onDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;
			}

			private static bool n_OnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_dependency)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				return behavior.OnDependentViewChanged(parent, child, dependency);
			}

			[Register("onDependentViewChanged", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", "GetOnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
			public unsafe virtual bool OnDependentViewChanged(CoordinatorLayout parent, Java.Lang.Object child, View dependency)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onDependentViewChanged.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(dependency);
				}
			}

			private static Delegate GetOnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
			{
				if ((object)cb_onDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ == null)
				{
					cb_onDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_));
				}
				return cb_onDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;
			}

			private static void n_OnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_dependency)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				behavior.OnDependentViewRemoved(parent, child, dependency);
			}

			[Register("onDependentViewRemoved", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", "GetOnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
			public unsafe virtual void OnDependentViewRemoved(CoordinatorLayout parent, Java.Lang.Object child, View dependency)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onDependentViewRemoved.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(dependency);
				}
			}

			private static Delegate GetOnDetachedFromLayoutParamsHandler()
			{
				if ((object)cb_onDetachedFromLayoutParams == null)
				{
					cb_onDetachedFromLayoutParams = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDetachedFromLayoutParams));
				}
				return cb_onDetachedFromLayoutParams;
			}

			private static void n_OnDetachedFromLayoutParams(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromLayoutParams();
			}

			[Register("onDetachedFromLayoutParams", "()V", "GetOnDetachedFromLayoutParamsHandler")]
			public unsafe virtual void OnDetachedFromLayoutParams()
			{
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromLayoutParams.()V", this, null);
			}

			private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
			{
				if ((object)cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ == null)
				{
					cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_));
				}
				return cb_onInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;
			}

			private static bool n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_ev)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
				return behavior.OnInterceptTouchEvent(parent, child, ev);
			}

			[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
			public unsafe virtual bool OnInterceptTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent ev)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(ev);
				}
			}

			private static Delegate GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler()
			{
				if ((object)cb_onLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I == null)
				{
					cb_onLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_Z(n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I));
				}
				return cb_onLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I;
			}

			private static bool n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, int layoutDirection)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.OnLayoutChild(parent, child, layoutDirection);
			}

			[Register("onLayoutChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", "GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler")]
			public unsafe virtual bool OnLayoutChild(CoordinatorLayout parent, Java.Lang.Object child, int layoutDirection)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(layoutDirection);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onLayoutChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler()
			{
				if ((object)cb_onMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII == null)
				{
					cb_onMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIIII_Z(n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII));
				}
				return cb_onMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII;
			}

			private static bool n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.OnMeasureChild(parent, child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
			}

			[Register("onMeasureChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", "GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler")]
			public unsafe virtual bool OnMeasureChild(CoordinatorLayout parent, Java.Lang.Object child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(parentWidthMeasureSpec);
					ptr[3] = new JniArgumentValue(widthUsed);
					ptr[4] = new JniArgumentValue(parentHeightMeasureSpec);
					ptr[5] = new JniArgumentValue(heightUsed);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMeasureChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetOnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZHandler()
			{
				if ((object)cb_onNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ == null)
				{
					cb_onNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFFZ_Z(n_OnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ));
				}
				return cb_onNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ;
			}

			private static bool n_OnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, float velocityX, float velocityY, bool consumed)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnNestedFling(coordinatorLayout, child, target, velocityX, velocityY, consumed);
			}

			[Register("onNestedFling", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FFZ)Z", "GetOnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZHandler")]
			public unsafe virtual bool OnNestedFling(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, float velocityX, float velocityY, bool consumed)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(velocityX);
					ptr[4] = new JniArgumentValue(velocityY);
					ptr[5] = new JniArgumentValue(consumed);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedFling.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FFZ)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler()
			{
				if ((object)cb_onNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF == null)
				{
					cb_onNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLFF_Z(n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF));
				}
				return cb_onNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF;
			}

			private static bool n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, float velocityX, float velocityY)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnNestedPreFling(coordinatorLayout, child, target, velocityX, velocityY);
			}

			[Register("onNestedPreFling", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", "GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler")]
			public unsafe virtual bool OnNestedPreFling(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, float velocityX, float velocityY)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(velocityX);
					ptr[4] = new JniArgumentValue(velocityY);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedPreFling.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIHandler()
			{
				if ((object)cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI == null)
				{
					cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIIL_V(n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI));
				}
				return cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI;
			}

			private static void n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int dx, int dy, IntPtr native_consumed)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
				}
			}

			[Register("onNestedPreScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[I)V", "GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIHandler")]
			public unsafe virtual void OnNestedPreScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dx, int dy, int[] consumed)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				IntPtr intPtr2 = JNIEnv.NewArray(consumed);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(dx);
					ptr[4] = new JniArgumentValue(dy);
					ptr[5] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[I)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (consumed != null)
					{
						JNIEnv.CopyArray(intPtr2, consumed);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
					GC.KeepAlive(consumed);
				}
			}

			private static Delegate GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler()
			{
				if ((object)cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII == null)
				{
					cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIILI_V(n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII));
				}
				return cb_onNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII;
			}

			private static void n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int dx, int dy, IntPtr native_consumed, int type)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, array, type);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
				}
			}

			[Register("onNestedPreScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler")]
			public unsafe virtual void OnNestedPreScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dx, int dy, int[] consumed, int type)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				IntPtr intPtr2 = JNIEnv.NewArray(consumed);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(dx);
					ptr[4] = new JniArgumentValue(dy);
					ptr[5] = new JniArgumentValue(intPtr2);
					ptr[6] = new JniArgumentValue(type);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (consumed != null)
					{
						JNIEnv.CopyArray(intPtr2, consumed);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
					GC.KeepAlive(consumed);
				}
			}

			private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIHandler()
			{
				if ((object)cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII == null)
				{
					cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIIII_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII));
				}
				return cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII;
			}

			private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);
			}

			[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIII)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIHandler")]
			public unsafe virtual void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(dxConsumed);
					ptr[4] = new JniArgumentValue(dyConsumed);
					ptr[5] = new JniArgumentValue(dxUnconsumed);
					ptr[6] = new JniArgumentValue(dyUnconsumed);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIII)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIHandler()
			{
				if ((object)cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII == null)
				{
					cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIIIII_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII));
				}
				return cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII;
			}

			private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
			}

			[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIHandler")]
			public unsafe virtual void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(dxConsumed);
					ptr[4] = new JniArgumentValue(dyConsumed);
					ptr[5] = new JniArgumentValue(dxUnconsumed);
					ptr[6] = new JniArgumentValue(dyUnconsumed);
					ptr[7] = new JniArgumentValue(type);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler()
			{
				if ((object)cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI == null)
				{
					cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIIIIIL_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI));
				}
				return cb_onNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI;
			}

			private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, IntPtr native_consumed)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
				}
			}

			[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler")]
			public unsafe virtual void OnNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[] consumed)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				IntPtr intPtr2 = JNIEnv.NewArray(consumed);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(dxConsumed);
					ptr[4] = new JniArgumentValue(dyConsumed);
					ptr[5] = new JniArgumentValue(dxUnconsumed);
					ptr[6] = new JniArgumentValue(dyUnconsumed);
					ptr[7] = new JniArgumentValue(type);
					ptr[8] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (consumed != null)
					{
						JNIEnv.CopyArray(intPtr2, consumed);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
					GC.KeepAlive(consumed);
				}
			}

			private static Delegate GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler()
			{
				if ((object)cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I == null)
				{
					cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLI_V(n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I));
				}
				return cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I;
			}

			private static void n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_directTargetChild, IntPtr native_target, int axes)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScrollAccepted(coordinatorLayout, child, directTargetChild, target, axes);
			}

			[Register("onNestedScrollAccepted", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)V", "GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler")]
			public unsafe virtual void OnNestedScrollAccepted(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int axes)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[4] = new JniArgumentValue(axes);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(directTargetChild);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler()
			{
				if ((object)cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II == null)
				{
					cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLII_V(n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II));
				}
				return cb_onNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II;
			}

			private static void n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_directTargetChild, IntPtr native_target, int axes, int type)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScrollAccepted(coordinatorLayout, child, directTargetChild, target, axes, type);
			}

			[Register("onNestedScrollAccepted", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler")]
			public unsafe virtual void OnNestedScrollAccepted(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int axes, int type)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[4] = new JniArgumentValue(axes);
					ptr[5] = new JniArgumentValue(type);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(directTargetChild);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ZHandler()
			{
				if ((object)cb_onRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z == null)
				{
					cb_onRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZ_Z(n_OnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z));
				}
				return cb_onRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z;
			}

			private static bool n_OnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_rectangle, bool immediate)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rectangle = Java.Lang.Object.GetObject<Rect>(native_rectangle, JniHandleOwnership.DoNotTransfer);
				return behavior.OnRequestChildRectangleOnScreen(coordinatorLayout, child, rectangle, immediate);
			}

			[Register("onRequestChildRectangleOnScreen", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetOnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ZHandler")]
			public unsafe virtual bool OnRequestChildRectangleOnScreen(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, Rect rectangle, bool immediate)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(rectangle?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(immediate);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildRectangleOnScreen.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(rectangle);
				}
			}

			private static Delegate GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler()
			{
				if ((object)cb_onRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_ == null)
				{
					cb_onRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_));
				}
				return cb_onRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_;
			}

			private static void n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_state)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
				behavior.OnRestoreInstanceState(parent, child, state);
			}

			[Register("onRestoreInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler")]
			public unsafe virtual void OnRestoreInstanceState(CoordinatorLayout parent, Java.Lang.Object child, IParcelable state)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(state);
				}
			}

			private static Delegate GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
			{
				if ((object)cb_onSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ == null)
				{
					cb_onSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_));
				}
				return cb_onSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_;
			}

			private static IntPtr n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(behavior.OnSaveInstanceState(parent, child));
			}

			[Register("onSaveInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", "GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
			public unsafe virtual IParcelable OnSaveInstanceState(CoordinatorLayout parent, Java.Lang.Object child)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
				}
			}

			private static Delegate GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler()
			{
				if ((object)cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I == null)
				{
					cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLI_Z(n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I));
				}
				return cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I;
			}

			private static bool n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_directTargetChild, IntPtr native_target, int axes)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes);
			}

			[Register("onStartNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)Z", "GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler")]
			public unsafe virtual bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int axes)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[4] = new JniArgumentValue(axes);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(directTargetChild);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler()
			{
				if ((object)cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II == null)
				{
					cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLII_Z(n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II));
				}
				return cb_onStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II;
			}

			private static bool n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_directTargetChild, IntPtr native_target, int axes, int type)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes, type);
			}

			[Register("onStartNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler")]
			public unsafe virtual bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int axes, int type)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[4] = new JniArgumentValue(axes);
					ptr[5] = new JniArgumentValue(type);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(directTargetChild);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
			{
				if ((object)cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ == null)
				{
					cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_));
				}
				return cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_;
			}

			private static void n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnStopNestedScroll(coordinatorLayout, child, target);
			}

			[Register("onStopNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", "GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
			public unsafe virtual void OnStopNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler()
			{
				if ((object)cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I == null)
				{
					cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_V(n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I));
				}
				return cb_onStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I;
			}

			private static void n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_coordinatorLayout, IntPtr native_child, IntPtr native_target, int type)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnStopNestedScroll(coordinatorLayout, child, target, type);
			}

			[Register("onStopNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler")]
			public unsafe virtual void OnStopNestedScroll(CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int type)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
					ptr[3] = new JniArgumentValue(type);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(coordinatorLayout);
					GC.KeepAlive(child);
					GC.KeepAlive(target);
				}
			}

			private static Delegate GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
			{
				if ((object)cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ == null)
				{
					cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_Z(n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_));
				}
				return cb_onTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_;
			}

			private static bool n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, IntPtr native_child, IntPtr native_ev)
			{
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
				return behavior.OnTouchEvent(parent, child, ev);
			}

			[Register("onTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
			public unsafe virtual bool OnTouchEvent(CoordinatorLayout parent, Java.Lang.Object child, MotionEvent ev)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(child);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(parent);
					GC.KeepAlive(child);
					GC.KeepAlive(ev);
				}
			}

			[Register("setTag", "(Landroid/view/View;Ljava/lang/Object;)V", "")]
			public unsafe static void SetTag(View child, Java.Lang.Object tag)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
					_members.StaticMethods.InvokeVoidMethod("setTag.(Landroid/view/View;Ljava/lang/Object;)V", ptr);
				}
				finally
				{
					GC.KeepAlive(child);
					GC.KeepAlive(tag);
				}
			}
		}

		[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", DoNotGenerateAcw = true)]
		internal class BehaviorInvoker : Behavior
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", typeof(BehaviorInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BehaviorInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams", DoNotGenerateAcw = true)]
		public new class LayoutParams : MarginLayoutParams
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams", typeof(LayoutParams));

			private static Delegate cb_getAnchorId;

			private static Delegate cb_setAnchorId_I;

			private static Delegate cb_getBehavior;

			private static Delegate cb_setBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_;

			[Register("anchorGravity")]
			public int AnchorGravity
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("anchorGravity.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("anchorGravity.I", this, value);
				}
			}

			[Register("dodgeInsetEdges")]
			public int DodgeInsetEdges
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("dodgeInsetEdges.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("dodgeInsetEdges.I", this, value);
				}
			}

			[Register("gravity")]
			public int Gravity
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("gravity.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("gravity.I", this, value);
				}
			}

			[Register("insetEdge")]
			public int InsetEdge
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("insetEdge.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("insetEdge.I", this, value);
				}
			}

			[Register("keyline")]
			public int Keyline
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("keyline.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("keyline.I", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe virtual int AnchorId
			{
				[Register("getAnchorId", "()I", "GetGetAnchorIdHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getAnchorId.()I", this, null);
				}
				[Register("setAnchorId", "(I)V", "GetSetAnchorId_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setAnchorId.(I)V", this, ptr);
				}
			}

			public unsafe virtual Behavior Behavior
			{
				[Register("getBehavior", "()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", "GetGetBehaviorHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setBehavior", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;)V", "GetSetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_Handler")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
						_members.InstanceMethods.InvokeVirtualVoidMethod("setBehavior.(Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			protected LayoutParams(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
			public unsafe LayoutParams(ViewGroup.LayoutParams p)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p);
				}
			}

			[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
			public unsafe LayoutParams(MarginLayoutParams p)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p);
				}
			}

			[Register(".ctor", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", "")]
			public unsafe LayoutParams(LayoutParams p)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(p);
				}
			}

			[Register(".ctor", "(II)V", "")]
			public unsafe LayoutParams(int width, int height)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(width);
					ptr[1] = new JniArgumentValue(height);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
				}
			}

			private static Delegate GetGetAnchorIdHandler()
			{
				if ((object)cb_getAnchorId == null)
				{
					cb_getAnchorId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAnchorId));
				}
				return cb_getAnchorId;
			}

			private static int n_GetAnchorId(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorId;
			}

			private static Delegate GetSetAnchorId_IHandler()
			{
				if ((object)cb_setAnchorId_I == null)
				{
					cb_setAnchorId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetAnchorId_I));
				}
				return cb_setAnchorId_I;
			}

			private static void n_SetAnchorId_I(IntPtr jnienv, IntPtr native__this, int id)
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorId = id;
			}

			private static Delegate GetGetBehaviorHandler()
			{
				if ((object)cb_getBehavior == null)
				{
					cb_getBehavior = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBehavior));
				}
				return cb_getBehavior;
			}

			private static IntPtr n_GetBehavior(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Behavior);
			}

			private static Delegate GetSetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_Handler()
			{
				if ((object)cb_setBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_ == null)
				{
					cb_setBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_));
				}
				return cb_setBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_;
			}

			private static void n_SetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_(IntPtr jnienv, IntPtr native__this, IntPtr native_behavior)
			{
				LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(native_behavior, JniHandleOwnership.DoNotTransfer);
				layoutParams.Behavior = behavior;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout", typeof(CoordinatorLayout));

		private static Delegate cb_getStatusBarBackground;

		private static Delegate cb_setStatusBarBackground_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_dispatchDependentViewsChanged_Landroid_view_View_;

		private static Delegate cb_doViewsOverlap_Landroid_view_View_Landroid_view_View_;

		private static Delegate cb_getDependencies_Landroid_view_View_;

		private static Delegate cb_getDependents_Landroid_view_View_;

		private static Delegate cb_isPointInChildBounds_Landroid_view_View_II;

		private static Delegate cb_onAttachedToWindow;

		private static Delegate cb_onDetachedFromWindow;

		private static Delegate cb_onDraw_Landroid_graphics_Canvas_;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_onLayoutChild_Landroid_view_View_I;

		private static Delegate cb_onMeasureChild_Landroid_view_View_IIII;

		private static Delegate cb_onNestedPreScroll_Landroid_view_View_IIarrayII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIII;

		private static Delegate cb_onNestedScroll_Landroid_view_View_IIIIIarrayI;

		private static Delegate cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II;

		private static Delegate cb_onStopNestedScroll_Landroid_view_View_I;

		private static Delegate cb_setStatusBarBackgroundColor_I;

		private static Delegate cb_setStatusBarBackgroundResource_I;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe WindowInsetsCompat LastWindowInsets
		{
			[Register("getLastWindowInsets", "()Landroidx/core/view/WindowInsetsCompat;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastWindowInsets.()Landroidx/core/view/WindowInsetsCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Drawable StatusBarBackground
		{
			[Register("getStatusBarBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetStatusBarBackgroundHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStatusBarBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setStatusBarBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public virtual void OnNestedScrollAccepted(View child, View target, int nestedScrollAxes, int type)
		{
			OnNestedScrollAccepted(child, target, (ScrollAxis)nestedScrollAxes, type);
		}

		public virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
		{
			return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
		}

		protected CoordinatorLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe CoordinatorLayout(Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe CoordinatorLayout(Context context, IAttributeSet attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe CoordinatorLayout(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetStatusBarBackgroundHandler()
		{
			if ((object)cb_getStatusBarBackground == null)
			{
				cb_getStatusBarBackground = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStatusBarBackground));
			}
			return cb_getStatusBarBackground;
		}

		private static IntPtr n_GetStatusBarBackground(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusBarBackground);
		}

		private static Delegate GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setStatusBarBackground_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setStatusBarBackground_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStatusBarBackground_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setStatusBarBackground_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetStatusBarBackground_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_bg)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable statusBarBackground = Java.Lang.Object.GetObject<Drawable>(native_bg, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.StatusBarBackground = statusBarBackground;
		}

		private static Delegate GetDispatchDependentViewsChanged_Landroid_view_View_Handler()
		{
			if ((object)cb_dispatchDependentViewsChanged_Landroid_view_View_ == null)
			{
				cb_dispatchDependentViewsChanged_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_DispatchDependentViewsChanged_Landroid_view_View_));
			}
			return cb_dispatchDependentViewsChanged_Landroid_view_View_;
		}

		private static void n_DispatchDependentViewsChanged_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.DispatchDependentViewsChanged(view);
		}

		[Register("dispatchDependentViewsChanged", "(Landroid/view/View;)V", "GetDispatchDependentViewsChanged_Landroid_view_View_Handler")]
		public unsafe virtual void DispatchDependentViewsChanged(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchDependentViewsChanged.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetDoViewsOverlap_Landroid_view_View_Landroid_view_View_Handler()
		{
			if ((object)cb_doViewsOverlap_Landroid_view_View_Landroid_view_View_ == null)
			{
				cb_doViewsOverlap_Landroid_view_View_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_DoViewsOverlap_Landroid_view_View_Landroid_view_View_));
			}
			return cb_doViewsOverlap_Landroid_view_View_Landroid_view_View_;
		}

		private static bool n_DoViewsOverlap_Landroid_view_View_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_first, IntPtr native_second)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View first = Java.Lang.Object.GetObject<View>(native_first, JniHandleOwnership.DoNotTransfer);
			View second = Java.Lang.Object.GetObject<View>(native_second, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.DoViewsOverlap(first, second);
		}

		[Register("doViewsOverlap", "(Landroid/view/View;Landroid/view/View;)Z", "GetDoViewsOverlap_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool DoViewsOverlap(View first, View second)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(first?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(second?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("doViewsOverlap.(Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(first);
				GC.KeepAlive(second);
			}
		}

		private static Delegate GetGetDependencies_Landroid_view_View_Handler()
		{
			if ((object)cb_getDependencies_Landroid_view_View_ == null)
			{
				cb_getDependencies_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDependencies_Landroid_view_View_));
			}
			return cb_getDependencies_Landroid_view_View_;
		}

		private static IntPtr n_GetDependencies_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return JavaList<View>.ToLocalJniHandle(coordinatorLayout.GetDependencies(child));
		}

		[Register("getDependencies", "(Landroid/view/View;)Ljava/util/List;", "GetGetDependencies_Landroid_view_View_Handler")]
		public unsafe virtual IList<View> GetDependencies(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return JavaList<View>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependencies.(Landroid/view/View;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDependents_Landroid_view_View_Handler()
		{
			if ((object)cb_getDependents_Landroid_view_View_ == null)
			{
				cb_getDependents_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetDependents_Landroid_view_View_));
			}
			return cb_getDependents_Landroid_view_View_;
		}

		private static IntPtr n_GetDependents_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_child)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return JavaList<View>.ToLocalJniHandle(coordinatorLayout.GetDependents(child));
		}

		[Register("getDependents", "(Landroid/view/View;)Ljava/util/List;", "GetGetDependents_Landroid_view_View_Handler")]
		public unsafe virtual IList<View> GetDependents(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return JavaList<View>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependents.(Landroid/view/View;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetIsPointInChildBounds_Landroid_view_View_IIHandler()
		{
			if ((object)cb_isPointInChildBounds_Landroid_view_View_II == null)
			{
				cb_isPointInChildBounds_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_Z(n_IsPointInChildBounds_Landroid_view_View_II));
			}
			return cb_isPointInChildBounds_Landroid_view_View_II;
		}

		private static bool n_IsPointInChildBounds_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int x, int y)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.IsPointInChildBounds(child, x, y);
		}

		[Register("isPointInChildBounds", "(Landroid/view/View;II)Z", "GetIsPointInChildBounds_Landroid_view_View_IIHandler")]
		public unsafe virtual bool IsPointInChildBounds(View child, int x, int y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(x);
				ptr[2] = new JniArgumentValue(y);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPointInChildBounds.(Landroid/view/View;II)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnAttachedToWindowHandler()
		{
			if ((object)cb_onAttachedToWindow == null)
			{
				cb_onAttachedToWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnAttachedToWindow));
			}
			return cb_onAttachedToWindow;
		}

		private static void n_OnAttachedToWindow(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
		}

		[Register("onAttachedToWindow", "()V", "GetOnAttachedToWindowHandler")]
		public new unsafe virtual void OnAttachedToWindow()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
		}

		private static Delegate GetOnDetachedFromWindowHandler()
		{
			if ((object)cb_onDetachedFromWindow == null)
			{
				cb_onDetachedFromWindow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnDetachedFromWindow));
			}
			return cb_onDetachedFromWindow;
		}

		private static void n_OnDetachedFromWindow(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
		}

		[Register("onDetachedFromWindow", "()V", "GetOnDetachedFromWindowHandler")]
		public new unsafe virtual void OnDetachedFromWindow()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.()V", this, null);
		}

		private static Delegate GetOnDraw_Landroid_graphics_Canvas_Handler()
		{
			if ((object)cb_onDraw_Landroid_graphics_Canvas_ == null)
			{
				cb_onDraw_Landroid_graphics_Canvas_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDraw_Landroid_graphics_Canvas_));
			}
			return cb_onDraw_Landroid_graphics_Canvas_;
		}

		private static void n_OnDraw_Landroid_graphics_Canvas_(IntPtr jnienv, IntPtr native__this, IntPtr native_c)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnDraw(c);
		}

		[Register("onDraw", "(Landroid/graphics/Canvas;)V", "GetOnDraw_Landroid_graphics_Canvas_Handler")]
		public new unsafe virtual void OnDraw(Canvas c)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
			}
		}

		private static Delegate GetOnLayout_ZIIIIHandler()
		{
			if ((object)cb_onLayout_ZIIII == null)
			{
				cb_onLayout_ZIIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZIIII_V(n_OnLayout_ZIIII));
			}
			return cb_onLayout_ZIIII;
		}

		private static void n_OnLayout_ZIIII(IntPtr jnienv, IntPtr native__this, bool changed, int l, int t, int r, int b)
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
		}

		[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
		protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(changed);
			ptr[1] = new JniArgumentValue(l);
			ptr[2] = new JniArgumentValue(t);
			ptr[3] = new JniArgumentValue(r);
			ptr[4] = new JniArgumentValue(b);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
		}

		private static Delegate GetOnLayoutChild_Landroid_view_View_IHandler()
		{
			if ((object)cb_onLayoutChild_Landroid_view_View_I == null)
			{
				cb_onLayoutChild_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnLayoutChild_Landroid_view_View_I));
			}
			return cb_onLayoutChild_Landroid_view_View_I;
		}

		private static void n_OnLayoutChild_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int layoutDirection)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnLayoutChild(child, layoutDirection);
		}

		[Register("onLayoutChild", "(Landroid/view/View;I)V", "GetOnLayoutChild_Landroid_view_View_IHandler")]
		public unsafe virtual void OnLayoutChild(View child, int layoutDirection)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(layoutDirection);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutChild.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnMeasureChild_Landroid_view_View_IIIIHandler()
		{
			if ((object)cb_onMeasureChild_Landroid_view_View_IIII == null)
			{
				cb_onMeasureChild_Landroid_view_View_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIII_V(n_OnMeasureChild_Landroid_view_View_IIII));
			}
			return cb_onMeasureChild_Landroid_view_View_IIII;
		}

		private static void n_OnMeasureChild_Landroid_view_View_IIII(IntPtr jnienv, IntPtr native__this, IntPtr native_child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnMeasureChild(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
		}

		[Register("onMeasureChild", "(Landroid/view/View;IIII)V", "GetOnMeasureChild_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void OnMeasureChild(View child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parentWidthMeasureSpec);
				ptr[2] = new JniArgumentValue(widthUsed);
				ptr[3] = new JniArgumentValue(parentHeightMeasureSpec);
				ptr[4] = new JniArgumentValue(heightUsed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasureChild.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler()
		{
			if ((object)cb_onNestedPreScroll_Landroid_view_View_IIarrayII == null)
			{
				cb_onNestedPreScroll_Landroid_view_View_IIarrayII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIILI_V(n_OnNestedPreScroll_Landroid_view_View_IIarrayII));
			}
			return cb_onNestedPreScroll_Landroid_view_View_IIarrayII;
		}

		private static void n_OnNestedPreScroll_Landroid_view_View_IIarrayII(IntPtr jnienv, IntPtr native__this, IntPtr native_target, int dx, int dy, IntPtr native_consumed, int type)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			coordinatorLayout.OnNestedPreScroll(target, dx, dy, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
		}

		[Register("onNestedPreScroll", "(Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler")]
		public unsafe virtual void OnNestedPreScroll(View target, int dx, int dy, int[] consumed, int type)
		{
			IntPtr intPtr = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dx);
				ptr[2] = new JniArgumentValue(dy);
				ptr[3] = new JniArgumentValue(intPtr);
				ptr[4] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroid/view/View;II[II)V", this, ptr);
			}
			finally
			{
				if (consumed != null)
				{
					JNIEnv.CopyArray(intPtr, consumed);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(target);
				GC.KeepAlive(consumed);
			}
		}

		private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIHandler()
		{
			if ((object)cb_onNestedScroll_Landroid_view_View_IIIII == null)
			{
				cb_onNestedScroll_Landroid_view_View_IIIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIIII_V(n_OnNestedScroll_Landroid_view_View_IIIII));
			}
			return cb_onNestedScroll_Landroid_view_View_IIIII;
		}

		private static void n_OnNestedScroll_Landroid_view_View_IIIII(IntPtr jnienv, IntPtr native__this, IntPtr native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
		}

		[Register("onNestedScroll", "(Landroid/view/View;IIIII)V", "GetOnNestedScroll_Landroid_view_View_IIIIIHandler")]
		public unsafe virtual void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dxConsumed);
				ptr[2] = new JniArgumentValue(dyConsumed);
				ptr[3] = new JniArgumentValue(dxUnconsumed);
				ptr[4] = new JniArgumentValue(dyUnconsumed);
				ptr[5] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler()
		{
			if ((object)cb_onNestedScroll_Landroid_view_View_IIIIIarrayI == null)
			{
				cb_onNestedScroll_Landroid_view_View_IIIIIarrayI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIIIIIL_V(n_OnNestedScroll_Landroid_view_View_IIIIIarrayI));
			}
			return cb_onNestedScroll_Landroid_view_View_IIIIIarrayI;
		}

		private static void n_OnNestedScroll_Landroid_view_View_IIIIIarrayI(IntPtr jnienv, IntPtr native__this, IntPtr native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, IntPtr native_consumed)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			coordinatorLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
		}

		[Register("onNestedScroll", "(Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler")]
		public unsafe virtual void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[] consumed)
		{
			IntPtr intPtr = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dxConsumed);
				ptr[2] = new JniArgumentValue(dyConsumed);
				ptr[3] = new JniArgumentValue(dxUnconsumed);
				ptr[4] = new JniArgumentValue(dyUnconsumed);
				ptr[5] = new JniArgumentValue(type);
				ptr[6] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII[I)V", this, ptr);
			}
			finally
			{
				if (consumed != null)
				{
					JNIEnv.CopyArray(intPtr, consumed);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(target);
				GC.KeepAlive(consumed);
			}
		}

		private static Delegate GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler()
		{
			if ((object)cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II == null)
			{
				cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_V(n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II));
			}
			return cb_onNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II;
		}

		private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_target, int native_axes, int type)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
		}

		[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual void OnNestedScrollAccepted(View child, View target, [GeneratedEnum] ScrollAxis axes, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((int)axes);
				ptr[3] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroid/view/View;Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler()
		{
			if ((object)cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II == null)
			{
				cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLII_Z(n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II));
			}
			return cb_onStartNestedScroll_Landroid_view_View_Landroid_view_View_II;
		}

		private static bool n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_child, IntPtr native_target, int native_axes, int type)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type);
		}

		[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual bool OnStartNestedScroll(View child, View target, [GeneratedEnum] ScrollAxis axes, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((int)axes);
				ptr[3] = new JniArgumentValue(type);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnStopNestedScroll_Landroid_view_View_IHandler()
		{
			if ((object)cb_onStopNestedScroll_Landroid_view_View_I == null)
			{
				cb_onStopNestedScroll_Landroid_view_View_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_OnStopNestedScroll_Landroid_view_View_I));
			}
			return cb_onStopNestedScroll_Landroid_view_View_I;
		}

		private static void n_OnStopNestedScroll_Landroid_view_View_I(IntPtr jnienv, IntPtr native__this, IntPtr native_target, int type)
		{
			CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnStopNestedScroll(target, type);
		}

		[Register("onStopNestedScroll", "(Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroid_view_View_IHandler")]
		public unsafe virtual void OnStopNestedScroll(View target, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetSetStatusBarBackgroundColor_IHandler()
		{
			if ((object)cb_setStatusBarBackgroundColor_I == null)
			{
				cb_setStatusBarBackgroundColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetStatusBarBackgroundColor_I));
			}
			return cb_setStatusBarBackgroundColor_I;
		}

		private static void n_SetStatusBarBackgroundColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundColor(color);
		}

		[Register("setStatusBarBackgroundColor", "(I)V", "GetSetStatusBarBackgroundColor_IHandler")]
		public unsafe virtual void SetStatusBarBackgroundColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackgroundColor.(I)V", this, ptr);
		}

		private static Delegate GetSetStatusBarBackgroundResource_IHandler()
		{
			if ((object)cb_setStatusBarBackgroundResource_I == null)
			{
				cb_setStatusBarBackgroundResource_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetStatusBarBackgroundResource_I));
			}
			return cb_setStatusBarBackgroundResource_I;
		}

		private static void n_SetStatusBarBackgroundResource_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundResource(resId);
		}

		[Register("setStatusBarBackgroundResource", "(I)V", "GetSetStatusBarBackgroundResource_IHandler")]
		public unsafe virtual void SetStatusBarBackgroundResource(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackgroundResource.(I)V", this, ptr);
		}
	}
}
