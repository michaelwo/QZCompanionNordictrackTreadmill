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
[assembly: NamespaceMapping(Java = "androidx.drawerlayout.widget", Managed = "AndroidX.DrawerLayout.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.drawerlayout:drawerlayout'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.DrawerLayout")]
[assembly: AssemblyTitle("Xamarin.AndroidX.DrawerLayout")]
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
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPIZ_V(IntPtr jnienv, IntPtr klass, int p0, bool p1);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPZIIII_V(IntPtr jnienv, IntPtr klass, bool p0, int p1, int p2, int p3, int p4);
namespace AndroidX.DrawerLayout.Widget
{
	[Register("androidx/drawerlayout/widget/DrawerLayout", DoNotGenerateAcw = true)]
	public class DrawerLayout : ViewGroup, IOpenable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", "", "AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker")]
		public interface IDrawerListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onDrawerClosed", "(Landroid/view/View;)V", "GetOnDrawerClosed_Landroid_view_View_Handler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
			void OnDrawerClosed(View drawerView);

			[Register("onDrawerOpened", "(Landroid/view/View;)V", "GetOnDrawerOpened_Landroid_view_View_Handler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
			void OnDrawerOpened(View drawerView);

			[Register("onDrawerSlide", "(Landroid/view/View;F)V", "GetOnDrawerSlide_Landroid_view_View_FHandler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
			void OnDrawerSlide(View drawerView, float slideOffset);

			[Register("onDrawerStateChanged", "(I)V", "GetOnDrawerStateChanged_IHandler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
			void OnDrawerStateChanged(int newState);
		}

		[Register("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", DoNotGenerateAcw = true)]
		internal class IDrawerListenerInvoker : Java.Lang.Object, IDrawerListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", typeof(IDrawerListenerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_onDrawerClosed_Landroid_view_View_;

			private IntPtr id_onDrawerClosed_Landroid_view_View_;

			private static Delegate cb_onDrawerOpened_Landroid_view_View_;

			private IntPtr id_onDrawerOpened_Landroid_view_View_;

			private static Delegate cb_onDrawerSlide_Landroid_view_View_F;

			private IntPtr id_onDrawerSlide_Landroid_view_View_F;

			private static Delegate cb_onDrawerStateChanged_I;

			private IntPtr id_onDrawerStateChanged_I;

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

			public static IDrawerListener GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IDrawerListener>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.drawerlayout.widget.DrawerLayout.DrawerListener'.");
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

			public IDrawerListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetOnDrawerClosed_Landroid_view_View_Handler()
			{
				if ((object)cb_onDrawerClosed_Landroid_view_View_ == null)
				{
					cb_onDrawerClosed_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDrawerClosed_Landroid_view_View_));
				}
				return cb_onDrawerClosed_Landroid_view_View_;
			}

			private static void n_OnDrawerClosed_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView)
			{
				IDrawerListener drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerClosed(drawerView);
			}

			public unsafe void OnDrawerClosed(View drawerView)
			{
				if (id_onDrawerClosed_Landroid_view_View_ == IntPtr.Zero)
				{
					id_onDrawerClosed_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onDrawerClosed", "(Landroid/view/View;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(drawerView?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onDrawerClosed_Landroid_view_View_, ptr);
			}

			private static Delegate GetOnDrawerOpened_Landroid_view_View_Handler()
			{
				if ((object)cb_onDrawerOpened_Landroid_view_View_ == null)
				{
					cb_onDrawerOpened_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnDrawerOpened_Landroid_view_View_));
				}
				return cb_onDrawerOpened_Landroid_view_View_;
			}

			private static void n_OnDrawerOpened_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView)
			{
				IDrawerListener drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerOpened(drawerView);
			}

			public unsafe void OnDrawerOpened(View drawerView)
			{
				if (id_onDrawerOpened_Landroid_view_View_ == IntPtr.Zero)
				{
					id_onDrawerOpened_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onDrawerOpened", "(Landroid/view/View;)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(drawerView?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_onDrawerOpened_Landroid_view_View_, ptr);
			}

			private static Delegate GetOnDrawerSlide_Landroid_view_View_FHandler()
			{
				if ((object)cb_onDrawerSlide_Landroid_view_View_F == null)
				{
					cb_onDrawerSlide_Landroid_view_View_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_OnDrawerSlide_Landroid_view_View_F));
				}
				return cb_onDrawerSlide_Landroid_view_View_F;
			}

			private static void n_OnDrawerSlide_Landroid_view_View_F(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView, float slideOffset)
			{
				IDrawerListener drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerSlide(drawerView, slideOffset);
			}

			public unsafe void OnDrawerSlide(View drawerView, float slideOffset)
			{
				if (id_onDrawerSlide_Landroid_view_View_F == IntPtr.Zero)
				{
					id_onDrawerSlide_Landroid_view_View_F = JNIEnv.GetMethodID(class_ref, "onDrawerSlide", "(Landroid/view/View;F)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(drawerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(slideOffset);
				JNIEnv.CallVoidMethod(base.Handle, id_onDrawerSlide_Landroid_view_View_F, ptr);
			}

			private static Delegate GetOnDrawerStateChanged_IHandler()
			{
				if ((object)cb_onDrawerStateChanged_I == null)
				{
					cb_onDrawerStateChanged_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnDrawerStateChanged_I));
				}
				return cb_onDrawerStateChanged_I;
			}

			private static void n_OnDrawerStateChanged_I(IntPtr jnienv, IntPtr native__this, int newState)
			{
				Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDrawerStateChanged(newState);
			}

			public unsafe void OnDrawerStateChanged(int newState)
			{
				if (id_onDrawerStateChanged_I == IntPtr.Zero)
				{
					id_onDrawerStateChanged_I = JNIEnv.GetMethodID(class_ref, "onDrawerStateChanged", "(I)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(newState);
				JNIEnv.CallVoidMethod(base.Handle, id_onDrawerStateChanged_I, ptr);
			}
		}

		public class DrawerClosedEventArgs : EventArgs
		{
			private View drawerView;

			public DrawerClosedEventArgs(View drawerView)
			{
				this.drawerView = drawerView;
			}
		}

		public class DrawerOpenedEventArgs : EventArgs
		{
			private View drawerView;

			public DrawerOpenedEventArgs(View drawerView)
			{
				this.drawerView = drawerView;
			}
		}

		public class DrawerSlideEventArgs : EventArgs
		{
			private View drawerView;

			private float slideOffset;

			public DrawerSlideEventArgs(View drawerView, float slideOffset)
			{
				this.drawerView = drawerView;
				this.slideOffset = slideOffset;
			}
		}

		public class DrawerStateChangedEventArgs : EventArgs
		{
			private int newState;

			public DrawerStateChangedEventArgs(int newState)
			{
				this.newState = newState;
			}
		}

		[Register("mono/androidx/drawerlayout/widget/DrawerLayout_DrawerListenerImplementor")]
		internal sealed class IDrawerListenerImplementor : Java.Lang.Object, IDrawerListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private object sender;

			public EventHandler<DrawerClosedEventArgs> OnDrawerClosedHandler;

			public EventHandler<DrawerOpenedEventArgs> OnDrawerOpenedHandler;

			public EventHandler<DrawerSlideEventArgs> OnDrawerSlideHandler;

			public EventHandler<DrawerStateChangedEventArgs> OnDrawerStateChangedHandler;

			public IDrawerListenerImplementor(object sender)
				: base(JNIEnv.StartCreateInstance("mono/androidx/drawerlayout/widget/DrawerLayout_DrawerListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
				this.sender = sender;
			}

			public void OnDrawerClosed(View drawerView)
			{
				OnDrawerClosedHandler?.Invoke(sender, new DrawerClosedEventArgs(drawerView));
			}

			public void OnDrawerOpened(View drawerView)
			{
				OnDrawerOpenedHandler?.Invoke(sender, new DrawerOpenedEventArgs(drawerView));
			}

			public void OnDrawerSlide(View drawerView, float slideOffset)
			{
				OnDrawerSlideHandler?.Invoke(sender, new DrawerSlideEventArgs(drawerView, slideOffset));
			}

			public void OnDrawerStateChanged(int newState)
			{
				OnDrawerStateChangedHandler?.Invoke(sender, new DrawerStateChangedEventArgs(newState));
			}

			internal static bool __IsEmpty(IDrawerListenerImplementor value)
			{
				if (value.OnDrawerClosedHandler == null && value.OnDrawerOpenedHandler == null && value.OnDrawerSlideHandler == null)
				{
					return value.OnDrawerStateChangedHandler == null;
				}
				return false;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/drawerlayout/widget/DrawerLayout", typeof(DrawerLayout));

		private static Delegate cb_getDrawerElevation;

		private static Delegate cb_setDrawerElevation_F;

		private static Delegate cb_isOpen;

		private static Delegate cb_getStatusBarBackgroundDrawable;

		private static Delegate cb_addDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;

		private static Delegate cb_addFocusables_Ljava_util_ArrayList_II;

		private static Delegate cb_close;

		private static Delegate cb_closeDrawer_Landroid_view_View_;

		private static Delegate cb_closeDrawer_Landroid_view_View_Z;

		private static Delegate cb_closeDrawer_I;

		private static Delegate cb_closeDrawer_IZ;

		private static Delegate cb_closeDrawers;

		private static Delegate cb_getDrawerLockMode_Landroid_view_View_;

		private static Delegate cb_getDrawerLockMode_I;

		private static Delegate cb_getDrawerTitle_I;

		private static Delegate cb_isDrawerOpen_Landroid_view_View_;

		private static Delegate cb_isDrawerOpen_I;

		private static Delegate cb_isDrawerVisible_Landroid_view_View_;

		private static Delegate cb_isDrawerVisible_I;

		private static Delegate cb_onDraw_Landroid_graphics_Canvas_;

		private static Delegate cb_onLayout_ZIIII;

		private static Delegate cb_open;

		private static Delegate cb_openDrawer_Landroid_view_View_;

		private static Delegate cb_openDrawer_Landroid_view_View_Z;

		private static Delegate cb_openDrawer_I;

		private static Delegate cb_openDrawer_IZ;

		private static Delegate cb_removeDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;

		private static Delegate cb_setChildInsets_Ljava_lang_Object_Z;

		private static Delegate cb_setDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;

		private static Delegate cb_setDrawerLockMode_I;

		private static Delegate cb_setDrawerLockMode_ILandroid_view_View_;

		private static Delegate cb_setDrawerLockMode_II;

		private static Delegate cb_setDrawerShadow_Landroid_graphics_drawable_Drawable_I;

		private static Delegate cb_setDrawerShadow_II;

		private static Delegate cb_setDrawerTitle_ILjava_lang_CharSequence_;

		private static Delegate cb_setScrimColor_I;

		private static Delegate cb_setStatusBarBackground_Landroid_graphics_drawable_Drawable_;

		private static Delegate cb_setStatusBarBackground_I;

		private static Delegate cb_setStatusBarBackgroundColor_I;

		private WeakReference weak_implementor_AddDrawerListener;

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

		public unsafe virtual float DrawerElevation
		{
			[Register("getDrawerElevation", "()F", "GetGetDrawerElevationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getDrawerElevation.()F", this, null);
			}
			[Register("setDrawerElevation", "(F)V", "GetSetDrawerElevation_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerElevation.(F)V", this, ptr);
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

		public unsafe virtual Drawable StatusBarBackgroundDrawable
		{
			[Register("getStatusBarBackgroundDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetStatusBarBackgroundDrawableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStatusBarBackgroundDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public event EventHandler<DrawerClosedEventArgs> DrawerClosed
		{
			add
			{
				EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerClosedHandler = (EventHandler<DrawerClosedEventArgs>)Delegate.Combine(__h.OnDrawerClosedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
				{
					RemoveDrawerListener(__v);
				}, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerClosedHandler = (EventHandler<DrawerClosedEventArgs>)Delegate.Remove(__h.OnDrawerClosedHandler, value);
				});
			}
		}

		public event EventHandler<DrawerOpenedEventArgs> DrawerOpened
		{
			add
			{
				EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerOpenedHandler = (EventHandler<DrawerOpenedEventArgs>)Delegate.Combine(__h.OnDrawerOpenedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
				{
					RemoveDrawerListener(__v);
				}, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerOpenedHandler = (EventHandler<DrawerOpenedEventArgs>)Delegate.Remove(__h.OnDrawerOpenedHandler, value);
				});
			}
		}

		public event EventHandler<DrawerSlideEventArgs> DrawerSlide
		{
			add
			{
				EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerSlideHandler = (EventHandler<DrawerSlideEventArgs>)Delegate.Combine(__h.OnDrawerSlideHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
				{
					RemoveDrawerListener(__v);
				}, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerSlideHandler = (EventHandler<DrawerSlideEventArgs>)Delegate.Remove(__h.OnDrawerSlideHandler, value);
				});
			}
		}

		public event EventHandler<DrawerStateChangedEventArgs> DrawerStateChanged
		{
			add
			{
				EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerStateChangedHandler = (EventHandler<DrawerStateChangedEventArgs>)Delegate.Combine(__h.OnDrawerStateChangedHandler, value);
				});
			}
			remove
			{
				EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
				{
					RemoveDrawerListener(__v);
				}, delegate(IDrawerListenerImplementor __h)
				{
					__h.OnDrawerStateChangedHandler = (EventHandler<DrawerStateChangedEventArgs>)Delegate.Remove(__h.OnDrawerStateChangedHandler, value);
				});
			}
		}

		protected DrawerLayout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe DrawerLayout(Context context)
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
		public unsafe DrawerLayout(Context context, IAttributeSet attrs)
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
		public unsafe DrawerLayout(Context context, IAttributeSet attrs, int defStyleAttr)
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

		private static Delegate GetGetDrawerElevationHandler()
		{
			if ((object)cb_getDrawerElevation == null)
			{
				cb_getDrawerElevation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDrawerElevation));
			}
			return cb_getDrawerElevation;
		}

		private static float n_GetDrawerElevation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerElevation;
		}

		private static Delegate GetSetDrawerElevation_FHandler()
		{
			if ((object)cb_setDrawerElevation_F == null)
			{
				cb_setDrawerElevation_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetDrawerElevation_F));
			}
			return cb_setDrawerElevation_F;
		}

		private static void n_SetDrawerElevation_F(IntPtr jnienv, IntPtr native__this, float elevation)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerElevation = elevation;
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
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen;
		}

		private static Delegate GetGetStatusBarBackgroundDrawableHandler()
		{
			if ((object)cb_getStatusBarBackgroundDrawable == null)
			{
				cb_getStatusBarBackgroundDrawable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStatusBarBackgroundDrawable));
			}
			return cb_getStatusBarBackgroundDrawable;
		}

		private static IntPtr n_GetStatusBarBackgroundDrawable(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusBarBackgroundDrawable);
		}

		private static Delegate GetAddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
		{
			if ((object)cb_addDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ == null)
			{
				cb_addDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_));
			}
			return cb_addDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;
		}

		private static void n_AddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener listener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.AddDrawerListener(listener);
		}

		[Register("addDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetAddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
		public unsafe virtual void AddDrawerListener(IDrawerListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetAddFocusables_Ljava_util_ArrayList_IIHandler()
		{
			if ((object)cb_addFocusables_Ljava_util_ArrayList_II == null)
			{
				cb_addFocusables_Ljava_util_ArrayList_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_AddFocusables_Ljava_util_ArrayList_II));
			}
			return cb_addFocusables_Ljava_util_ArrayList_II;
		}

		private static void n_AddFocusables_Ljava_util_ArrayList_II(IntPtr jnienv, IntPtr native__this, IntPtr native_views, int direction, int focusableMode)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			drawerLayout.AddFocusables(views, direction, focusableMode);
		}

		[Register("addFocusables", "(Ljava/util/ArrayList;II)V", "GetAddFocusables_Ljava_util_ArrayList_IIHandler")]
		public unsafe virtual void AddFocusables(IList<View> views, int direction, int focusableMode)
		{
			IntPtr intPtr = JavaList<View>.ToLocalJniHandle(views);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(direction);
				ptr[2] = new JniArgumentValue(focusableMode);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addFocusables.(Ljava/util/ArrayList;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(views);
			}
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
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		private static Delegate GetCloseDrawer_Landroid_view_View_Handler()
		{
			if ((object)cb_closeDrawer_Landroid_view_View_ == null)
			{
				cb_closeDrawer_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CloseDrawer_Landroid_view_View_));
			}
			return cb_closeDrawer_Landroid_view_View_;
		}

		private static void n_CloseDrawer_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.CloseDrawer(drawerView);
		}

		[Register("closeDrawer", "(Landroid/view/View;)V", "GetCloseDrawer_Landroid_view_View_Handler")]
		public unsafe virtual void CloseDrawer(View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetCloseDrawer_Landroid_view_View_ZHandler()
		{
			if ((object)cb_closeDrawer_Landroid_view_View_Z == null)
			{
				cb_closeDrawer_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_CloseDrawer_Landroid_view_View_Z));
			}
			return cb_closeDrawer_Landroid_view_View_Z;
		}

		private static void n_CloseDrawer_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView, bool animate)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.CloseDrawer(drawerView, animate);
		}

		[Register("closeDrawer", "(Landroid/view/View;Z)V", "GetCloseDrawer_Landroid_view_View_ZHandler")]
		public unsafe virtual void CloseDrawer(View drawerView, bool animate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(animate);
				_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(Landroid/view/View;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetCloseDrawer_IHandler()
		{
			if ((object)cb_closeDrawer_I == null)
			{
				cb_closeDrawer_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_CloseDrawer_I));
			}
			return cb_closeDrawer_I;
		}

		private static void n_CloseDrawer_I(IntPtr jnienv, IntPtr native__this, int gravity)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseDrawer(gravity);
		}

		[Register("closeDrawer", "(I)V", "GetCloseDrawer_IHandler")]
		public unsafe virtual void CloseDrawer(int gravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(I)V", this, ptr);
		}

		private static Delegate GetCloseDrawer_IZHandler()
		{
			if ((object)cb_closeDrawer_IZ == null)
			{
				cb_closeDrawer_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_CloseDrawer_IZ));
			}
			return cb_closeDrawer_IZ;
		}

		private static void n_CloseDrawer_IZ(IntPtr jnienv, IntPtr native__this, int gravity, bool animate)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseDrawer(gravity, animate);
		}

		[Register("closeDrawer", "(IZ)V", "GetCloseDrawer_IZHandler")]
		public unsafe virtual void CloseDrawer(int gravity, bool animate)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(gravity);
			ptr[1] = new JniArgumentValue(animate);
			_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(IZ)V", this, ptr);
		}

		private static Delegate GetCloseDrawersHandler()
		{
			if ((object)cb_closeDrawers == null)
			{
				cb_closeDrawers = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CloseDrawers));
			}
			return cb_closeDrawers;
		}

		private static void n_CloseDrawers(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseDrawers();
		}

		[Register("closeDrawers", "()V", "GetCloseDrawersHandler")]
		public unsafe virtual void CloseDrawers()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawers.()V", this, null);
		}

		private static Delegate GetGetDrawerLockMode_Landroid_view_View_Handler()
		{
			if ((object)cb_getDrawerLockMode_Landroid_view_View_ == null)
			{
				cb_getDrawerLockMode_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetDrawerLockMode_Landroid_view_View_));
			}
			return cb_getDrawerLockMode_Landroid_view_View_;
		}

		private static int n_GetDrawerLockMode_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.GetDrawerLockMode(drawerView);
		}

		[Register("getDrawerLockMode", "(Landroid/view/View;)I", "GetGetDrawerLockMode_Landroid_view_View_Handler")]
		public unsafe virtual int GetDrawerLockMode(View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawerLockMode.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetGetDrawerLockMode_IHandler()
		{
			if ((object)cb_getDrawerLockMode_I == null)
			{
				cb_getDrawerLockMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetDrawerLockMode_I));
			}
			return cb_getDrawerLockMode_I;
		}

		private static int n_GetDrawerLockMode_I(IntPtr jnienv, IntPtr native__this, int edgeGravity)
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDrawerLockMode(edgeGravity);
		}

		[Register("getDrawerLockMode", "(I)I", "GetGetDrawerLockMode_IHandler")]
		public unsafe virtual int GetDrawerLockMode(int edgeGravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(edgeGravity);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawerLockMode.(I)I", this, ptr);
		}

		private static Delegate GetGetDrawerTitle_IHandler()
		{
			if ((object)cb_getDrawerTitle_I == null)
			{
				cb_getDrawerTitle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetDrawerTitle_I));
			}
			return cb_getDrawerTitle_I;
		}

		private static IntPtr n_GetDrawerTitle_I(IntPtr jnienv, IntPtr native__this, int edgeGravity)
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDrawerTitleFormatted(edgeGravity));
		}

		[Register("getDrawerTitle", "(I)Ljava/lang/CharSequence;", "GetGetDrawerTitle_IHandler")]
		public unsafe virtual ICharSequence GetDrawerTitleFormatted(int edgeGravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(edgeGravity);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawerTitle.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		public string GetDrawerTitle(int edgeGravity)
		{
			return GetDrawerTitleFormatted(edgeGravity)?.ToString();
		}

		private static Delegate GetIsDrawerOpen_Landroid_view_View_Handler()
		{
			if ((object)cb_isDrawerOpen_Landroid_view_View_ == null)
			{
				cb_isDrawerOpen_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsDrawerOpen_Landroid_view_View_));
			}
			return cb_isDrawerOpen_Landroid_view_View_;
		}

		private static bool n_IsDrawerOpen_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawer)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawer = Java.Lang.Object.GetObject<View>(native_drawer, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.IsDrawerOpen(drawer);
		}

		[Register("isDrawerOpen", "(Landroid/view/View;)Z", "GetIsDrawerOpen_Landroid_view_View_Handler")]
		public unsafe virtual bool IsDrawerOpen(View drawer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawer?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerOpen.(Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawer);
			}
		}

		private static Delegate GetIsDrawerOpen_IHandler()
		{
			if ((object)cb_isDrawerOpen_I == null)
			{
				cb_isDrawerOpen_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_IsDrawerOpen_I));
			}
			return cb_isDrawerOpen_I;
		}

		private static bool n_IsDrawerOpen_I(IntPtr jnienv, IntPtr native__this, int drawerGravity)
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDrawerOpen(drawerGravity);
		}

		[Register("isDrawerOpen", "(I)Z", "GetIsDrawerOpen_IHandler")]
		public unsafe virtual bool IsDrawerOpen(int drawerGravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerGravity);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerOpen.(I)Z", this, ptr);
		}

		private static Delegate GetIsDrawerVisible_Landroid_view_View_Handler()
		{
			if ((object)cb_isDrawerVisible_Landroid_view_View_ == null)
			{
				cb_isDrawerVisible_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsDrawerVisible_Landroid_view_View_));
			}
			return cb_isDrawerVisible_Landroid_view_View_;
		}

		private static bool n_IsDrawerVisible_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawer)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawer = Java.Lang.Object.GetObject<View>(native_drawer, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.IsDrawerVisible(drawer);
		}

		[Register("isDrawerVisible", "(Landroid/view/View;)Z", "GetIsDrawerVisible_Landroid_view_View_Handler")]
		public unsafe virtual bool IsDrawerVisible(View drawer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawer?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerVisible.(Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawer);
			}
		}

		private static Delegate GetIsDrawerVisible_IHandler()
		{
			if ((object)cb_isDrawerVisible_I == null)
			{
				cb_isDrawerVisible_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_IsDrawerVisible_I));
			}
			return cb_isDrawerVisible_I;
		}

		private static bool n_IsDrawerVisible_I(IntPtr jnienv, IntPtr native__this, int drawerGravity)
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDrawerVisible(drawerGravity);
		}

		[Register("isDrawerVisible", "(I)Z", "GetIsDrawerVisible_IHandler")]
		public unsafe virtual bool IsDrawerVisible(int drawerGravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerGravity);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerVisible.(I)Z", this, ptr);
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
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			drawerLayout.OnDraw(c);
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
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLayout(changed, l, t, r, b);
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
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Open();
		}

		[Register("open", "()V", "GetOpenHandler")]
		public unsafe virtual void Open()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("open.()V", this, null);
		}

		private static Delegate GetOpenDrawer_Landroid_view_View_Handler()
		{
			if ((object)cb_openDrawer_Landroid_view_View_ == null)
			{
				cb_openDrawer_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OpenDrawer_Landroid_view_View_));
			}
			return cb_openDrawer_Landroid_view_View_;
		}

		private static void n_OpenDrawer_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.OpenDrawer(drawerView);
		}

		[Register("openDrawer", "(Landroid/view/View;)V", "GetOpenDrawer_Landroid_view_View_Handler")]
		public unsafe virtual void OpenDrawer(View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetOpenDrawer_Landroid_view_View_ZHandler()
		{
			if ((object)cb_openDrawer_Landroid_view_View_Z == null)
			{
				cb_openDrawer_Landroid_view_View_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_OpenDrawer_Landroid_view_View_Z));
			}
			return cb_openDrawer_Landroid_view_View_Z;
		}

		private static void n_OpenDrawer_Landroid_view_View_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_drawerView, bool animate)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.OpenDrawer(drawerView, animate);
		}

		[Register("openDrawer", "(Landroid/view/View;Z)V", "GetOpenDrawer_Landroid_view_View_ZHandler")]
		public unsafe virtual void OpenDrawer(View drawerView, bool animate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(animate);
				_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(Landroid/view/View;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetOpenDrawer_IHandler()
		{
			if ((object)cb_openDrawer_I == null)
			{
				cb_openDrawer_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OpenDrawer_I));
			}
			return cb_openDrawer_I;
		}

		private static void n_OpenDrawer_I(IntPtr jnienv, IntPtr native__this, int gravity)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenDrawer(gravity);
		}

		[Register("openDrawer", "(I)V", "GetOpenDrawer_IHandler")]
		public unsafe virtual void OpenDrawer(int gravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(I)V", this, ptr);
		}

		private static Delegate GetOpenDrawer_IZHandler()
		{
			if ((object)cb_openDrawer_IZ == null)
			{
				cb_openDrawer_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_OpenDrawer_IZ));
			}
			return cb_openDrawer_IZ;
		}

		private static void n_OpenDrawer_IZ(IntPtr jnienv, IntPtr native__this, int gravity, bool animate)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenDrawer(gravity, animate);
		}

		[Register("openDrawer", "(IZ)V", "GetOpenDrawer_IZHandler")]
		public unsafe virtual void OpenDrawer(int gravity, bool animate)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(gravity);
			ptr[1] = new JniArgumentValue(animate);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(IZ)V", this, ptr);
		}

		private static Delegate GetRemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
		{
			if ((object)cb_removeDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ == null)
			{
				cb_removeDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_));
			}
			return cb_removeDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;
		}

		private static void n_RemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener listener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.RemoveDrawerListener(listener);
		}

		[Register("removeDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetRemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
		public unsafe virtual void RemoveDrawerListener(IDrawerListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetChildInsets_Ljava_lang_Object_ZHandler()
		{
			if ((object)cb_setChildInsets_Ljava_lang_Object_Z == null)
			{
				cb_setChildInsets_Ljava_lang_Object_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_SetChildInsets_Ljava_lang_Object_Z));
			}
			return cb_setChildInsets_Ljava_lang_Object_Z;
		}

		private static void n_SetChildInsets_Ljava_lang_Object_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_insets, bool draw)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object insets = Java.Lang.Object.GetObject<Java.Lang.Object>(native_insets, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetChildInsets(insets, draw);
		}

		[Register("setChildInsets", "(Ljava/lang/Object;Z)V", "GetSetChildInsets_Ljava_lang_Object_ZHandler")]
		public unsafe virtual void SetChildInsets(Java.Lang.Object insets, bool draw)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(draw);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setChildInsets.(Ljava/lang/Object;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(insets);
			}
		}

		private static Delegate GetSetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
		{
			if ((object)cb_setDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ == null)
			{
				cb_setDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_));
			}
			return cb_setDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_;
		}

		private static void n_SetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_listener)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerListener(drawerListener);
		}

		[Register("setDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetSetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
		public unsafe virtual void SetDrawerListener(IDrawerListener listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetSetDrawerLockMode_IHandler()
		{
			if ((object)cb_setDrawerLockMode_I == null)
			{
				cb_setDrawerLockMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetDrawerLockMode_I));
			}
			return cb_setDrawerLockMode_I;
		}

		private static void n_SetDrawerLockMode_I(IntPtr jnienv, IntPtr native__this, int lockMode)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerLockMode(lockMode);
		}

		[Register("setDrawerLockMode", "(I)V", "GetSetDrawerLockMode_IHandler")]
		public unsafe virtual void SetDrawerLockMode(int lockMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(lockMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(I)V", this, ptr);
		}

		private static Delegate GetSetDrawerLockMode_ILandroid_view_View_Handler()
		{
			if ((object)cb_setDrawerLockMode_ILandroid_view_View_ == null)
			{
				cb_setDrawerLockMode_ILandroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetDrawerLockMode_ILandroid_view_View_));
			}
			return cb_setDrawerLockMode_ILandroid_view_View_;
		}

		private static void n_SetDrawerLockMode_ILandroid_view_View_(IntPtr jnienv, IntPtr native__this, int lockMode, IntPtr native_drawerView)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerLockMode(lockMode, drawerView);
		}

		[Register("setDrawerLockMode", "(ILandroid/view/View;)V", "GetSetDrawerLockMode_ILandroid_view_View_Handler")]
		public unsafe virtual void SetDrawerLockMode(int lockMode, View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(lockMode);
				ptr[1] = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(ILandroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		private static Delegate GetSetDrawerLockMode_IIHandler()
		{
			if ((object)cb_setDrawerLockMode_II == null)
			{
				cb_setDrawerLockMode_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetDrawerLockMode_II));
			}
			return cb_setDrawerLockMode_II;
		}

		private static void n_SetDrawerLockMode_II(IntPtr jnienv, IntPtr native__this, int lockMode, int edgeGravity)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerLockMode(lockMode, edgeGravity);
		}

		[Register("setDrawerLockMode", "(II)V", "GetSetDrawerLockMode_IIHandler")]
		public unsafe virtual void SetDrawerLockMode(int lockMode, int edgeGravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(lockMode);
			ptr[1] = new JniArgumentValue(edgeGravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(II)V", this, ptr);
		}

		private static Delegate GetSetDrawerShadow_Landroid_graphics_drawable_Drawable_IHandler()
		{
			if ((object)cb_setDrawerShadow_Landroid_graphics_drawable_Drawable_I == null)
			{
				cb_setDrawerShadow_Landroid_graphics_drawable_Drawable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_SetDrawerShadow_Landroid_graphics_drawable_Drawable_I));
			}
			return cb_setDrawerShadow_Landroid_graphics_drawable_Drawable_I;
		}

		private static void n_SetDrawerShadow_Landroid_graphics_drawable_Drawable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_shadowDrawable, int gravity)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable shadowDrawable = Java.Lang.Object.GetObject<Drawable>(native_shadowDrawable, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerShadow(shadowDrawable, gravity);
		}

		[Register("setDrawerShadow", "(Landroid/graphics/drawable/Drawable;I)V", "GetSetDrawerShadow_Landroid_graphics_drawable_Drawable_IHandler")]
		public unsafe virtual void SetDrawerShadow(Drawable shadowDrawable, int gravity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(shadowDrawable?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(gravity);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerShadow.(Landroid/graphics/drawable/Drawable;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(shadowDrawable);
			}
		}

		private static Delegate GetSetDrawerShadow_IIHandler()
		{
			if ((object)cb_setDrawerShadow_II == null)
			{
				cb_setDrawerShadow_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetDrawerShadow_II));
			}
			return cb_setDrawerShadow_II;
		}

		private static void n_SetDrawerShadow_II(IntPtr jnienv, IntPtr native__this, int resId, int gravity)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerShadow(resId, gravity);
		}

		[Register("setDrawerShadow", "(II)V", "GetSetDrawerShadow_IIHandler")]
		public unsafe virtual void SetDrawerShadow(int resId, int gravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resId);
			ptr[1] = new JniArgumentValue(gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerShadow.(II)V", this, ptr);
		}

		private static Delegate GetSetDrawerTitle_ILjava_lang_CharSequence_Handler()
		{
			if ((object)cb_setDrawerTitle_ILjava_lang_CharSequence_ == null)
			{
				cb_setDrawerTitle_ILjava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetDrawerTitle_ILjava_lang_CharSequence_));
			}
			return cb_setDrawerTitle_ILjava_lang_CharSequence_;
		}

		private static void n_SetDrawerTitle_ILjava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, int edgeGravity, IntPtr native_title)
		{
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerTitle(edgeGravity, title);
		}

		[Register("setDrawerTitle", "(ILjava/lang/CharSequence;)V", "GetSetDrawerTitle_ILjava_lang_CharSequence_Handler")]
		public unsafe virtual void SetDrawerTitle(int edgeGravity, ICharSequence title)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(title);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(edgeGravity);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerTitle.(ILjava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(title);
			}
		}

		public void SetDrawerTitle(int edgeGravity, string title)
		{
			Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
			SetDrawerTitle(edgeGravity, obj);
			obj?.Dispose();
		}

		private static Delegate GetSetScrimColor_IHandler()
		{
			if ((object)cb_setScrimColor_I == null)
			{
				cb_setScrimColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetScrimColor_I));
			}
			return cb_setScrimColor_I;
		}

		private static void n_SetScrimColor_I(IntPtr jnienv, IntPtr native__this, int color)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScrimColor(color);
		}

		[Register("setScrimColor", "(I)V", "GetSetScrimColor_IHandler")]
		public unsafe virtual void SetScrimColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScrimColor.(I)V", this, ptr);
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
			DrawerLayout drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable statusBarBackground = Java.Lang.Object.GetObject<Drawable>(native_bg, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetStatusBarBackground(statusBarBackground);
		}

		[Register("setStatusBarBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual void SetStatusBarBackground(Drawable bg)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bg?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bg);
			}
		}

		private static Delegate GetSetStatusBarBackground_IHandler()
		{
			if ((object)cb_setStatusBarBackground_I == null)
			{
				cb_setStatusBarBackground_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetStatusBarBackground_I));
			}
			return cb_setStatusBarBackground_I;
		}

		private static void n_SetStatusBarBackground_I(IntPtr jnienv, IntPtr native__this, int resId)
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackground(resId);
		}

		[Register("setStatusBarBackground", "(I)V", "GetSetStatusBarBackground_IHandler")]
		public unsafe virtual void SetStatusBarBackground(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(I)V", this, ptr);
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
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundColor(color);
		}

		[Register("setStatusBarBackgroundColor", "(I)V", "GetSetStatusBarBackgroundColor_IHandler")]
		public unsafe virtual void SetStatusBarBackgroundColor(int color)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackgroundColor.(I)V", this, ptr);
		}

		private IDrawerListenerImplementor __CreateIDrawerListenerImplementor()
		{
			return new IDrawerListenerImplementor(this);
		}
	}
}
