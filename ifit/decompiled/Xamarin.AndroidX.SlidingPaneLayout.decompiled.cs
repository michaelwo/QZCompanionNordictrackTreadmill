using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.CustomView.Widget;
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
[assembly: NamespaceMapping(Java = "androidx.slidingpanelayout.widget", Managed = "AndroidX.SlidingPaneLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.slidingpanelayout:slidingpanelayout'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.SlidingPaneLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.SlidingPaneLayout")]
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
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1);
internal delegate bool _JniMarshal_PPLZIII_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1, int p2, int p3, int p4);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
namespace AndroidX.SlidingPaneLayout.Widget
{
	[Register("androidx/slidingpanelayout/widget/SlidingPaneLayout", DoNotGenerateAcw = true)]
	public class SlidingPaneLayout : ViewGroup, IOpenable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("androidx/slidingpanelayout/widget/SlidingPaneLayout$PanelSlideListener", "", "AndroidX.SlidingPaneLayout.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker")]
		public interface IPanelSlideListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onPanelClosed", "(Landroid/view/View;)V", "GetOnPanelClosed_Landroid_view_View_Handler:AndroidX.SlidingPaneLayout.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.AndroidX.SlidingPaneLayout")]
			void OnPanelClosed(View panel);

			[Register("onPanelOpened", "(Landroid/view/View;)V", "GetOnPanelOpened_Landroid_view_View_Handler:AndroidX.SlidingPaneLayout.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.AndroidX.SlidingPaneLayout")]
			void OnPanelOpened(View panel);

			[Register("onPanelSlide", "(Landroid/view/View;F)V", "GetOnPanelSlide_Landroid_view_View_FHandler:AndroidX.SlidingPaneLayout.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.AndroidX.SlidingPaneLayout")]
			void OnPanelSlide(View panel, float slideOffset);
		}

		[Register("androidx/slidingpanelayout/widget/SlidingPaneLayout$PanelSlideListener", DoNotGenerateAcw = true)]
		internal class IPanelSlideListenerInvoker : Java.Lang.Object, IPanelSlideListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/slidingpanelayout/widget/SlidingPaneLayout$PanelSlideListener", typeof(IPanelSlideListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onPanelClosed_Landroid_view_View_;

			private IntPtr id_onPanelClosed_Landroid_view_View_;

			private static Delegate cb_onPanelOpened_Landroid_view_View_;

			private IntPtr id_onPanelOpened_Landroid_view_View_;

			private static Delegate cb_onPanelSlide_Landroid_view_View_F;

			private IntPtr id_onPanelSlide_Landroid_view_View_F;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => class_ref;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IPanelSlideListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IPanelSlideListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.slidingpanelayout.widget.SlidingPaneLayout.PanelSlideListener'.");
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

			public IPanelSlideListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnPanelClosed_Landroid_view_View_Handler()
			{
				if ((object)cb_onPanelClosed_Landroid_view_View_ == null)
				{
					cb_onPanelClosed_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPanelClosed_Landroid_view_View_));
				}
				return cb_onPanelClosed_Landroid_view_View_;
			}

			private static void n_OnPanelClosed_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_panel)
			{
				IPanelSlideListener panelSlideListener = Java.Lang.Object.GetObject<IPanelSlideListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View panel = Java.Lang.Object.GetObject<View>(native_panel, JniHandleOwnership.DoNotTransfer);
				panelSlideListener.OnPanelClosed(panel);
			}

			public unsafe void OnPanelClosed(View panel)
			{
				if (id_onPanelClosed_Landroid_view_View_ == IntPtr.Zero)
				{
					id_onPanelClosed_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onPanelClosed", "(Landroid/view/View;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(panel?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPanelClosed_Landroid_view_View_, ptr);
			}

			private static Delegate GetOnPanelOpened_Landroid_view_View_Handler()
			{
				if ((object)cb_onPanelOpened_Landroid_view_View_ == null)
				{
					cb_onPanelOpened_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPanelOpened_Landroid_view_View_));
				}
				return cb_onPanelOpened_Landroid_view_View_;
			}

			private static void n_OnPanelOpened_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_panel)
			{
				IPanelSlideListener panelSlideListener = Java.Lang.Object.GetObject<IPanelSlideListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View panel = Java.Lang.Object.GetObject<View>(native_panel, JniHandleOwnership.DoNotTransfer);
				panelSlideListener.OnPanelOpened(panel);
			}

			public unsafe void OnPanelOpened(View panel)
			{
				if (id_onPanelOpened_Landroid_view_View_ == IntPtr.Zero)
				{
					id_onPanelOpened_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onPanelOpened", "(Landroid/view/View;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(panel?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onPanelOpened_Landroid_view_View_, ptr);
			}

			private static Delegate GetOnPanelSlide_Landroid_view_View_FHandler()
			{
				if ((object)cb_onPanelSlide_Landroid_view_View_F == null)
				{
					cb_onPanelSlide_Landroid_view_View_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_OnPanelSlide_Landroid_view_View_F));
				}
				return cb_onPanelSlide_Landroid_view_View_F;
			}

			private static void n_OnPanelSlide_Landroid_view_View_F(IntPtr jnienv, IntPtr native__this, IntPtr native_panel, float slideOffset)
			{
				IPanelSlideListener panelSlideListener = Java.Lang.Object.GetObject<IPanelSlideListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View panel = Java.Lang.Object.GetObject<View>(native_panel, JniHandleOwnership.DoNotTransfer);
				panelSlideListener.OnPanelSlide(panel, slideOffset);
			}

			public unsafe void OnPanelSlide(View panel, float slideOffset)
			{
				if (id_onPanelSlide_Landroid_view_View_F == IntPtr.Zero)
				{
					id_onPanelSlide_Landroid_view_View_F = JNIEnv.GetMethodID(class_ref, "onPanelSlide", "(Landroid/view/View;F)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(panel?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(slideOffset);
				JNIEnv.CallVoidMethod(base.Handle, id_onPanelSlide_Landroid_view_View_F, ptr);
			}
		}

		public class PanelClosedEventArgs : EventArgs
		{
			private View panel;

			public PanelClosedEventArgs(View panel)
			{
				this.panel = panel;
			}
		}

		public class PanelOpenedEventArgs : EventArgs
		{
			private View panel;

			public PanelOpenedEventArgs(View panel)
			{
				this.panel = panel;
			}
		}

		public class PanelSlideEventArgs : EventArgs
		{
			private View panel;

			private float slideOffset;

			public PanelSlideEventArgs(View panel, float slideOffset)
			{
				this.panel = panel;
				this.slideOffset = slideOffset;
			}
		}

		[Register("mono/androidx/slidingpanelayout/widget/SlidingPaneLayout_PanelSlideListenerImplementor")]
		internal sealed class IPanelSlideListenerImplementor : Java.Lang.Object, IPanelSlideListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<PanelClosedEventArgs> OnPanelClosedHandler;

			public EventHandler<PanelOpenedEventArgs> OnPanelOpenedHandler;

			public EventHandler<PanelSlideEventArgs> OnPanelSlideHandler;

			public IPanelSlideListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/slidingpanelayout/widget/SlidingPaneLayout_PanelSlideListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnPanelClosed(View panel)
			{
				OnPanelClosedHandler?.Invoke(sender, new PanelClosedEventArgs(panel));
			}

			public void OnPanelOpened(View panel)
			{
				OnPanelOpenedHandler?.Invoke(sender, new PanelOpenedEventArgs(panel));
			}

			public void OnPanelSlide(View panel, float slideOffset)
			{
				OnPanelSlideHandler?.Invoke(sender, new PanelSlideEventArgs(panel, slideOffset));
			}

			internal static bool __IsEmpty(IPanelSlideListenerImplementor value)
			{
				if (value.OnPanelClosedHandler == null && value.OnPanelOpenedHandler == null)
				{
					return value.OnPanelSlideHandler == null;
				}
				return false;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/slidingpanelayout/widget/SlidingPaneLayout", typeof(SlidingPaneLayout));

		private static Delegate cb_getCoveredFadeColor;

		private static Delegate cb_setCoveredFadeColor_I;

		private static Delegate cb_isOpen;

		private static Delegate cb_isSlideable;

		private static Delegate cb_getParallaxDistance;

		private static Delegate cb_setParallaxDistance_I;

		private static Delegate cb_getSliderFadeColor;

		private static Delegate cb_setSliderFadeColor_I;

		private static Delegate cb_canScroll_Landroid_view_View_ZIII;

		private static Delegate cb_canSlide;

		private static Delegate cb_close;

		private static Delegate cb_closePane;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_open;

		private static Delegate cb_openPane;

		private static Delegate cb_setPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_;

		private static Delegate cb_setShadowDrawable_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_setShadowDrawableLeft_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_setShadowDrawableRight_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_setShadowResource_I;

		private static Delegate cb_setShadowResourceLeft_I;

		private static Delegate cb_setShadowResourceRight_I;

		private static Delegate cb_smoothSlideClosed;

		private static Delegate cb_smoothSlideOpen;

		private WeakReference weak_implementor_SetPanelSlideListener;

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

		public unsafe virtual int CoveredFadeColor
		{
			[Register("getCoveredFadeColor", "()I", "GetGetCoveredFadeColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCoveredFadeColor.()I", this, null);
			}
			[Register("setCoveredFadeColor", "(I)V", "GetSetCoveredFadeColor_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCoveredFadeColor.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool IsOpen
		{
			[Register("isOpen", "()Z", "GetIsOpenHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOpen.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSlideable
		{
			[Register("isSlideable", "()Z", "GetIsSlideableHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSlideable.()Z", this, null);
			}
		}

		public unsafe int LockMode
		{
			[Register("getLockMode", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLockMode.()I", this, null);
			}
			[Register("setLockMode", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setLockMode.(I)V", this, ptr);
			}
		}

		public unsafe virtual int ParallaxDistance
		{
			[Register("getParallaxDistance", "()I", "GetGetParallaxDistanceHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getParallaxDistance.()I", this, null);
			}
			[Register("setParallaxDistance", "(I)V", "GetSetParallaxDistance_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setParallaxDistance.(I)V", this, ptr);
			}
		}

		public unsafe virtual int SliderFadeColor
		{
			[Register("getSliderFadeColor", "()I", "GetGetSliderFadeColorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSliderFadeColor.()I", this, null);
			}
			[Register("setSliderFadeColor", "(I)V", "GetSetSliderFadeColor_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSliderFadeColor.(I)V", this, ptr);
			}
		}

		public event EventHandler<PanelClosedEventArgs> PanelClosed
		{
			add
			{
				EventHelper.AddEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, __CreateIPanelSlideListenerImplementor, SetPanelSlideListener, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelClosedHandler = (EventHandler<PanelClosedEventArgs>)Delegate.Combine(__h.OnPanelClosedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, IPanelSlideListenerImplementor.__IsEmpty, delegate
				{
					SetPanelSlideListener(null);
				}, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelClosedHandler = (EventHandler<PanelClosedEventArgs>)Delegate.Remove(__h.OnPanelClosedHandler, value);
				});
			}
		}

		public event EventHandler<PanelOpenedEventArgs> PanelOpened
		{
			add
			{
				EventHelper.AddEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, __CreateIPanelSlideListenerImplementor, SetPanelSlideListener, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelOpenedHandler = (EventHandler<PanelOpenedEventArgs>)Delegate.Combine(__h.OnPanelOpenedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, IPanelSlideListenerImplementor.__IsEmpty, delegate
				{
					SetPanelSlideListener(null);
				}, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelOpenedHandler = (EventHandler<PanelOpenedEventArgs>)Delegate.Remove(__h.OnPanelOpenedHandler, value);
				});
			}
		}

		public event EventHandler<PanelSlideEventArgs> PanelSlide
		{
			add
			{
				EventHelper.AddEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, __CreateIPanelSlideListenerImplementor, SetPanelSlideListener, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelSlideHandler = (EventHandler<PanelSlideEventArgs>)Delegate.Combine(__h.OnPanelSlideHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler<IPanelSlideListener, IPanelSlideListenerImplementor>(ref weak_implementor_SetPanelSlideListener, IPanelSlideListenerImplementor.__IsEmpty, delegate
				{
					SetPanelSlideListener(null);
				}, delegate(IPanelSlideListenerImplementor __h)
				{
					__h.OnPanelSlideHandler = (EventHandler<PanelSlideEventArgs>)Delegate.Remove(__h.OnPanelSlideHandler, value);
				});
			}
		}

		protected SlidingPaneLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SlidingPaneLayout(Context context)
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
		public unsafe SlidingPaneLayout(Context context, IAttributeSet attrs)
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
		public unsafe SlidingPaneLayout(Context context, IAttributeSet attrs, int defStyle)
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
				ptr[2] = new JniArgumentValue(defStyle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetCoveredFadeColorHandler()
		{
			if ((object)cb_getCoveredFadeColor == null)
			{
				cb_getCoveredFadeColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCoveredFadeColor));
			}
			return cb_getCoveredFadeColor;
		}

		private static int n_GetCoveredFadeColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CoveredFadeColor;
		}

		private static Delegate GetSetCoveredFadeColor_IHandler()
		{
			if ((object)cb_setCoveredFadeColor_I == null)
			{
				cb_setCoveredFadeColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetCoveredFadeColor_I));
			}
			return cb_setCoveredFadeColor_I;
		}

		private static void n_SetCoveredFadeColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CoveredFadeColor = color;
		}

		private static Delegate GetIsOpenHandler()
		{
			if ((object)cb_isOpen == null)
			{
				cb_isOpen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOpen));
			}
			return cb_isOpen;
		}

		private static bool n_IsOpen(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen;
		}

		private static Delegate GetIsSlideableHandler()
		{
			if ((object)cb_isSlideable == null)
			{
				cb_isSlideable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSlideable));
			}
			return cb_isSlideable;
		}

		private static bool n_IsSlideable(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSlideable;
		}

		private static Delegate GetGetParallaxDistanceHandler()
		{
			if ((object)cb_getParallaxDistance == null)
			{
				cb_getParallaxDistance = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetParallaxDistance));
			}
			return cb_getParallaxDistance;
		}

		private static int n_GetParallaxDistance(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParallaxDistance;
		}

		private static Delegate GetSetParallaxDistance_IHandler()
		{
			if ((object)cb_setParallaxDistance_I == null)
			{
				cb_setParallaxDistance_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetParallaxDistance_I));
			}
			return cb_setParallaxDistance_I;
		}

		private static void n_SetParallaxDistance_I(IntPtr jnienv, IntPtr native__this, int parallaxBy)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParallaxDistance = parallaxBy;
		}

		private static Delegate GetGetSliderFadeColorHandler()
		{
			if ((object)cb_getSliderFadeColor == null)
			{
				cb_getSliderFadeColor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSliderFadeColor));
			}
			return cb_getSliderFadeColor;
		}

		private static int n_GetSliderFadeColor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SliderFadeColor;
		}

		private static Delegate GetSetSliderFadeColor_IHandler()
		{
			if ((object)cb_setSliderFadeColor_I == null)
			{
				cb_setSliderFadeColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetSliderFadeColor_I));
			}
			return cb_setSliderFadeColor_I;
		}

		private static void n_SetSliderFadeColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SliderFadeColor = color;
		}

		private static Delegate GetCanScroll_Landroid_view_View_ZIIIHandler()
		{
			if ((object)cb_canScroll_Landroid_view_View_ZIII == null)
			{
				cb_canScroll_Landroid_view_View_ZIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZIII_Z(n_CanScroll_Landroid_view_View_ZIII));
			}
			return cb_canScroll_Landroid_view_View_ZIII;
		}

		private static bool n_CanScroll_Landroid_view_View_ZIII(IntPtr jnienv, IntPtr native__this, IntPtr native_v, bool checkV, int dx, int x, int y)
		{
			SlidingPaneLayout slidingPaneLayout = Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			return slidingPaneLayout.CanScroll(v, checkV, dx, x, y);
		}

		[Register("canScroll", "(Landroid/view/View;ZIII)Z", "GetCanScroll_Landroid_view_View_ZIIIHandler")]
		protected unsafe virtual bool CanScroll(View v, bool checkV, int dx, int x, int y)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(checkV);
				ptr[2] = new JniArgumentValue(dx);
				ptr[3] = new JniArgumentValue(x);
				ptr[4] = new JniArgumentValue(y);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScroll.(Landroid/view/View;ZIII)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
			}
		}

		private static Delegate GetCanSlideHandler()
		{
			if ((object)cb_canSlide == null)
			{
				cb_canSlide = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_CanSlide));
			}
			return cb_canSlide;
		}

		private static bool n_CanSlide(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanSlide();
		}

		[Register("canSlide", "()Z", "GetCanSlideHandler")]
		public unsafe virtual bool CanSlide()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canSlide.()Z", this, null);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetClosePaneHandler()
		{
			if ((object)cb_closePane == null)
			{
				cb_closePane = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_ClosePane));
			}
			return cb_closePane;
		}

		private static bool n_ClosePane(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClosePane();
		}

		[Register("closePane", "()Z", "GetClosePaneHandler")]
		public unsafe virtual bool ClosePane()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("closePane.()Z", this, null);
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
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
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

		private static Delegate GetOpenHandler()
		{
			if ((object)cb_open == null)
			{
				cb_open = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Open));
			}
			return cb_open;
		}

		private static void n_Open(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Open();
		}

		[Register("open", "()V", "GetOpenHandler")]
		public unsafe virtual void Open()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("open.()V", this, null);
		}

		private static Delegate GetOpenPaneHandler()
		{
			if ((object)cb_openPane == null)
			{
				cb_openPane = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_OpenPane));
			}
			return cb_openPane;
		}

		private static bool n_OpenPane(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenPane();
		}

		[Register("openPane", "()Z", "GetOpenPaneHandler")]
		public unsafe virtual bool OpenPane()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("openPane.()Z", this, null);
		}

		private static Delegate GetSetPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_Handler()
		{
			if ((object)cb_setPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_ == null)
			{
				cb_setPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_));
			}
			return cb_setPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_;
		}

		private static void n_SetPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			SlidingPaneLayout slidingPaneLayout = Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPanelSlideListener panelSlideListener = Java.Lang.Object.GetObject<IPanelSlideListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			slidingPaneLayout.SetPanelSlideListener(panelSlideListener);
		}

		[Register("setPanelSlideListener", "(Landroidx/slidingpanelayout/widget/SlidingPaneLayout$PanelSlideListener;)V", "GetSetPanelSlideListener_Landroidx_slidingpanelayout_widget_SlidingPaneLayout_PanelSlideListener_Handler")]
		public unsafe virtual void SetPanelSlideListener(IPanelSlideListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPanelSlideListener.(Landroidx/slidingpanelayout/widget/SlidingPaneLayout$PanelSlideListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetShadowDrawable_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setShadowDrawable_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setShadowDrawable_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetShadowDrawable_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setShadowDrawable_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetShadowDrawable_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_d)
		{
			SlidingPaneLayout slidingPaneLayout = Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable shadowDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			slidingPaneLayout.SetShadowDrawable(shadowDrawable);
		}

		[Register("setShadowDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetShadowDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual void SetShadowDrawable(Drawable d)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetSetShadowDrawableLeft_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setShadowDrawableLeft_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setShadowDrawableLeft_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetShadowDrawableLeft_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setShadowDrawableLeft_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetShadowDrawableLeft_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_d)
		{
			SlidingPaneLayout slidingPaneLayout = Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable shadowDrawableLeft = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			slidingPaneLayout.SetShadowDrawableLeft(shadowDrawableLeft);
		}

		[Register("setShadowDrawableLeft", "(Landroid/graphics/drawable/Drawable;)V", "GetSetShadowDrawableLeft_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual void SetShadowDrawableLeft(Drawable d)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowDrawableLeft.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetSetShadowDrawableRight_Landroid_graphics_drawable_Drawable_Handler()
		{
			if ((object)cb_setShadowDrawableRight_Landroid_graphics_drawable_Drawable_ == null)
			{
				cb_setShadowDrawableRight_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetShadowDrawableRight_Landroid_graphics_drawable_Drawable_));
			}
			return cb_setShadowDrawableRight_Landroid_graphics_drawable_Drawable_;
		}

		private static void n_SetShadowDrawableRight_Landroid_graphics_drawable_Drawable_(IntPtr jnienv, IntPtr native__this, IntPtr native_d)
		{
			SlidingPaneLayout slidingPaneLayout = Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable shadowDrawableRight = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			slidingPaneLayout.SetShadowDrawableRight(shadowDrawableRight);
		}

		[Register("setShadowDrawableRight", "(Landroid/graphics/drawable/Drawable;)V", "GetSetShadowDrawableRight_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual void SetShadowDrawableRight(Drawable d)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowDrawableRight.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetSetShadowResource_IHandler()
		{
			if ((object)cb_setShadowResource_I == null)
			{
				cb_setShadowResource_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetShadowResource_I));
			}
			return cb_setShadowResource_I;
		}

		private static void n_SetShadowResource_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShadowResource(resId);
		}

		[Register("setShadowResource", "(I)V", "GetSetShadowResource_IHandler")]
		public unsafe virtual void SetShadowResource(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowResource.(I)V", this, ptr);
		}

		private static Delegate GetSetShadowResourceLeft_IHandler()
		{
			if ((object)cb_setShadowResourceLeft_I == null)
			{
				cb_setShadowResourceLeft_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetShadowResourceLeft_I));
			}
			return cb_setShadowResourceLeft_I;
		}

		private static void n_SetShadowResourceLeft_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShadowResourceLeft(resId);
		}

		[Register("setShadowResourceLeft", "(I)V", "GetSetShadowResourceLeft_IHandler")]
		public unsafe virtual void SetShadowResourceLeft(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowResourceLeft.(I)V", this, ptr);
		}

		private static Delegate GetSetShadowResourceRight_IHandler()
		{
			if ((object)cb_setShadowResourceRight_I == null)
			{
				cb_setShadowResourceRight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetShadowResourceRight_I));
			}
			return cb_setShadowResourceRight_I;
		}

		private static void n_SetShadowResourceRight_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShadowResourceRight(resId);
		}

		[Register("setShadowResourceRight", "(I)V", "GetSetShadowResourceRight_IHandler")]
		public unsafe virtual void SetShadowResourceRight(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowResourceRight.(I)V", this, ptr);
		}

		private static Delegate GetSmoothSlideClosedHandler()
		{
			if ((object)cb_smoothSlideClosed == null)
			{
				cb_smoothSlideClosed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SmoothSlideClosed));
			}
			return cb_smoothSlideClosed;
		}

		private static void n_SmoothSlideClosed(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothSlideClosed();
		}

		[Register("smoothSlideClosed", "()V", "GetSmoothSlideClosedHandler")]
		public unsafe virtual void SmoothSlideClosed()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothSlideClosed.()V", this, null);
		}

		private static Delegate GetSmoothSlideOpenHandler()
		{
			if ((object)cb_smoothSlideOpen == null)
			{
				cb_smoothSlideOpen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SmoothSlideOpen));
			}
			return cb_smoothSlideOpen;
		}

		private static void n_SmoothSlideOpen(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SlidingPaneLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothSlideOpen();
		}

		[Register("smoothSlideOpen", "()V", "GetSmoothSlideOpenHandler")]
		public unsafe virtual void SmoothSlideOpen()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothSlideOpen.()V", this, null);
		}

		private IPanelSlideListenerImplementor __CreateIPanelSlideListenerImplementor()
		{
			return new IPanelSlideListenerImplementor(this);
		}
	}
}
